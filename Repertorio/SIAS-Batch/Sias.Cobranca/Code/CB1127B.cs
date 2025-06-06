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
using Sias.Cobranca.DB2.CB1127B;

namespace Code
{
    public class CB1127B
    {
        public bool IsCall { get; set; }

        public CB1127B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  COBRANCA                           *      */
        /*"      *   PROGRAMA ...............  CB1127B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  CLOVIS                             *      */
        /*"      *   PROGRAMADOR ............  CLOVIS                             *      */
        /*"      *   DATA CODIFICACAO .......  21/08/2006                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  GERA ARQUIVO TXT DOS RCAPS         *      */
        /*"      *                             PENDENTES  V0RCAP/V0RCAPCOMP.      *      */
        /*"      *                    RECIBOS PENDENTES QUITADOS COM MAIS DE      *      */
        /*"      *                    015 DIAS. (VER DATABASE). RAMO VIDA         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 01 - HIST 188.713                                     *      */
        /*"      *             - PREPARAR PROGRAMA PARA PROCESSAMENTO DA JV1      *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/01/2019 - HUSNI ALI HUSNI                              *      */
        /*"      *                                       PROCURE POR JV101        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _MOVTO { get; set; } = new FileBasis(new PIC("X", "150", "X(150)"));

        public FileBasis MOVTO
        {
            get
            {
                _.Move(SAI_MOVTO, _MOVTO); VarBasis.RedefinePassValue(SAI_MOVTO, _MOVTO, SAI_MOVTO); return _MOVTO;
            }
        }
        public FileBasis _MOVTO1 { get; set; } = new FileBasis(new PIC("X", "150", "X(150)"));

        public FileBasis MOVTO1
        {
            get
            {
                _.Move(SAI_MOVTO1, _MOVTO1); VarBasis.RedefinePassValue(SAI_MOVTO1, _MOVTO1, SAI_MOVTO1); return _MOVTO1;
            }
        }
        /*"01  SAI-MOVTO                    PIC  X(150).*/
        public StringBasis SAI_MOVTO { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");
        /*"01  SAI-MOVTO1                   PIC  X(150).*/
        public StringBasis SAI_MOVTO1 { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis WS_PRD { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"77    VIND-NRTIT                PIC S9(004)    COMP.*/
        public IntBasis VIND_NRTIT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-CODPRODU             PIC S9(004)    COMP.*/
        public IntBasis VIND_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-AGECOBR              PIC S9(004)    COMP.*/
        public IntBasis VIND_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NRCERTIF             PIC S9(004)    COMP.*/
        public IntBasis VIND_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-ORIGEM               PIC S9(004)    COMP.*/
        public IntBasis VIND_ORIGEM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0SIST-DTMOVABE           PIC  X(010).*/
        public StringBasis V0SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSHOST-DATA015            PIC  X(010).*/
        public StringBasis WSHOST_DATA015 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSHOST-DATA365            PIC  X(010).*/
        public StringBasis WSHOST_DATA365 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0RCAP-VLRCAP             PIC S9(013)V99 COMP-3.*/
        public DoubleBasis V0RCAP_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0RCAP-VALPRI             PIC S9(013)V99 COMP-3.*/
        public DoubleBasis V0RCAP_VALPRI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0RCAP-OPERACAO           PIC S9(004)    COMP.*/
        public IntBasis V0RCAP_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0RCAP-NRTIT              PIC S9(013)    COMP-3.*/
        public IntBasis V0RCAP_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0RCAP-CODPRODU           PIC S9(004)    COMP.*/
        public IntBasis V0RCAP_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0RCAP-AGECOBR            PIC S9(004)    COMP.*/
        public IntBasis V0RCAP_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0RCAP-NRCERTIF           PIC S9(015)    COMP-3.*/
        public IntBasis V0RCAP_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0RCOM-FONTE              PIC S9(004)    COMP.*/
        public IntBasis V0RCOM_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0RCOM-NRRCAP             PIC S9(009)    COMP.*/
        public IntBasis V0RCOM_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0RCOM-NRRCAPCO           PIC S9(009)    COMP.*/
        public IntBasis V0RCOM_NRRCAPCO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0RCOM-OPERACAO           PIC S9(004)    COMP.*/
        public IntBasis V0RCOM_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0RCOM-BCOAVISO           PIC S9(004)    COMP.*/
        public IntBasis V0RCOM_BCOAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0RCOM-AGEAVISO           PIC S9(004)    COMP.*/
        public IntBasis V0RCOM_AGEAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0RCOM-NRAVISO            PIC S9(009)    COMP.*/
        public IntBasis V0RCOM_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0RCOM-VLRCAP             PIC S9(013)V99 COMP-3.*/
        public DoubleBasis V0RCOM_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0RCOM-DATARCAP           PIC  X(010).*/
        public StringBasis V0RCOM_DATARCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0RCOM-DTCADAST           PIC  X(010).*/
        public StringBasis V0RCOM_DTCADAST { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0RCOM-SITCONTB           PIC  X(001).*/
        public StringBasis V0RCOM_SITCONTB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0AVIS-ORIGEM             PIC S9(004)    COMP.*/
        public IntBasis V0AVIS_ORIGEM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  W.*/
        public CB1127B_W W { get; set; } = new CB1127B_W();
        public class CB1127B_W : VarBasis
        {
            /*"  03  WFIM-V0RCAP               PIC  X(001)    VALUE  'N'.*/
            public StringBasis WFIM_V0RCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03  DP-PRODUTO                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_PRODUTO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-DATA                   PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_DATA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-OPERACAO               PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_OPERACAO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-GRAVA                  PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_GRAVA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-GRAVA1                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_GRAVA1 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  WS-PRODUTO                PIC  9(004)    VALUE   ZEROS.*/
            public IntBasis WS_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03  WS-SUBS                   PIC  9(004)         VALUE ZEROS.*/
            public IntBasis WS_SUBS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03  WS-QTDE                   PIC S9(009)    COMP.*/
            public IntBasis WS_QTDE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03  WS-VALOR                  PIC S9(013)V99 COMP-3.*/
            public DoubleBasis WS_VALOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03         AC-LIDOS           PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         FILLER             REDEFINES      AC-LIDOS.*/
            private _REDEF_CB1127B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_CB1127B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_CB1127B_FILLER_0(); _.Move(AC_LIDOS, _filler_0); VarBasis.RedefinePassValue(AC_LIDOS, _filler_0, AC_LIDOS); _filler_0.ValueChanged += () => { _.Move(_filler_0, AC_LIDOS); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, AC_LIDOS); }
            }  //Redefines
            public class _REDEF_CB1127B_FILLER_0 : VarBasis
            {
                /*"      10     LD-PARTE1          PIC  9(003).*/
                public IntBasis LD_PARTE1 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"      10     LD-PARTE2          PIC  9(004).*/
                public IntBasis LD_PARTE2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  03         WTIME-DAY          PIC  99.99.99.99.*/

                public _REDEF_CB1127B_FILLER_0()
                {
                    LD_PARTE1.ValueChanged += OnValueChanged;
                    LD_PARTE2.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WTIME_DAY { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
            /*"  03         FILLER             REDEFINES      WTIME-DAY.*/
            private _REDEF_CB1127B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_CB1127B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_CB1127B_FILLER_1(); _.Move(WTIME_DAY, _filler_1); VarBasis.RedefinePassValue(WTIME_DAY, _filler_1, WTIME_DAY); _filler_1.ValueChanged += () => { _.Move(_filler_1, WTIME_DAY); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, WTIME_DAY); }
            }  //Redefines
            public class _REDEF_CB1127B_FILLER_1 : VarBasis
            {
                /*"    05       WTIME-DAYR.*/
                public CB1127B_WTIME_DAYR WTIME_DAYR { get; set; } = new CB1127B_WTIME_DAYR();
                public class CB1127B_WTIME_DAYR : VarBasis
                {
                    /*"      10     WTIME-HORA         PIC  X(002).*/
                    public StringBasis WTIME_HORA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"      10     WTIME-2PT1         PIC  X(001).*/
                    public StringBasis WTIME_2PT1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      10     WTIME-MINU         PIC  X(002).*/
                    public StringBasis WTIME_MINU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"      10     WTIME-2PT2         PIC  X(001).*/
                    public StringBasis WTIME_2PT2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      10     WTIME-SEGU         PIC  X(002).*/
                    public StringBasis WTIME_SEGU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"    05       WTIME-2PT3         PIC  X(001).*/

                    public CB1127B_WTIME_DAYR()
                    {
                        WTIME_HORA.ValueChanged += OnValueChanged;
                        WTIME_2PT1.ValueChanged += OnValueChanged;
                        WTIME_MINU.ValueChanged += OnValueChanged;
                        WTIME_2PT2.ValueChanged += OnValueChanged;
                        WTIME_SEGU.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis WTIME_2PT3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05       WTIME-CCSE         PIC  X(002).*/
                public StringBasis WTIME_CCSE { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"  03         WS-TIME.*/

                public _REDEF_CB1127B_FILLER_1()
                {
                    WTIME_DAYR.ValueChanged += OnValueChanged;
                    WTIME_2PT3.ValueChanged += OnValueChanged;
                    WTIME_CCSE.ValueChanged += OnValueChanged;
                }

            }
            public CB1127B_WS_TIME WS_TIME { get; set; } = new CB1127B_WS_TIME();
            public class CB1127B_WS_TIME : VarBasis
            {
                /*"      10     WS-HH-TIME         PIC  9(002).*/
                public IntBasis WS_HH_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-MM-TIME         PIC  9(002).*/
                public IntBasis WS_MM_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-SS-TIME         PIC  9(002).*/
                public IntBasis WS_SS_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-CC-TIME         PIC  9(002).*/
                public IntBasis WS_CC_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WDATA-REL          PIC  X(010)    VALUE   SPACES.*/
            }
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03         FILLER             REDEFINES      WDATA-REL.*/
            private _REDEF_CB1127B_FILLER_2 _filler_2 { get; set; }
            public _REDEF_CB1127B_FILLER_2 FILLER_2
            {
                get { _filler_2 = new _REDEF_CB1127B_FILLER_2(); _.Move(WDATA_REL, _filler_2); VarBasis.RedefinePassValue(WDATA_REL, _filler_2, WDATA_REL); _filler_2.ValueChanged += () => { _.Move(_filler_2, WDATA_REL); }; return _filler_2; }
                set { VarBasis.RedefinePassValue(value, _filler_2, WDATA_REL); }
            }  //Redefines
            public class _REDEF_CB1127B_FILLER_2 : VarBasis
            {
                /*"    10       WDAT-REL-ANO       PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER             PIC  X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-MES       PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER             PIC  X(001).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-DIA       PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WDATA-CABEC.*/

                public _REDEF_CB1127B_FILLER_2()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_3.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_4.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public CB1127B_WDATA_CABEC WDATA_CABEC { get; set; } = new CB1127B_WDATA_CABEC();
            public class CB1127B_WDATA_CABEC : VarBasis
            {
                /*"    05       WDATA-DD-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05       WDATA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05       WDATA-AA-CABEC    PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  03         WS-CHAVE-ATU.*/
            }
            public CB1127B_WS_CHAVE_ATU WS_CHAVE_ATU { get; set; } = new CB1127B_WS_CHAVE_ATU();
            public class CB1127B_WS_CHAVE_ATU : VarBasis
            {
                /*"    10       ATU-FONTE         PIC  9(004).*/
                public IntBasis ATU_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       ATU-NRRCAP        PIC  9(009).*/
                public IntBasis ATU_NRRCAP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"  03         WS-CHAVE-ANT.*/
            }
            public CB1127B_WS_CHAVE_ANT WS_CHAVE_ANT { get; set; } = new CB1127B_WS_CHAVE_ANT();
            public class CB1127B_WS_CHAVE_ANT : VarBasis
            {
                /*"    10       ANT-FONTE         PIC  9(004).*/
                public IntBasis ANT_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       ANT-NRRCAP        PIC  9(009).*/
                public IntBasis ANT_NRRCAP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"  03        WABEND.*/
            }
            public CB1127B_WABEND WABEND { get; set; } = new CB1127B_WABEND();
            public class CB1127B_WABEND : VarBasis
            {
                /*"    05      FILLER              PIC  X(010) VALUE           ' CB1127B  '.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" CB1127B  ");
                /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05      WNR-EXEC-SQL        PIC  X(004) VALUE    SPACES.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"    05      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD1 = '.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"    05      WSQLERRD1           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD2 = '.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05      WSQLERRD2           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"  03          LC03.*/
            }
            public CB1127B_LC03 LC03 { get; set; } = new CB1127B_LC03();
            public class CB1127B_LC03 : VarBasis
            {
                /*"    10        FILLER              PIC  X(033)  VALUE             'RECIBOS PROVISORIOS PENDENTES EM '.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "33", "X(033)"), @"RECIBOS PROVISORIOS PENDENTES EM ");
                /*"    10        LC03-DATAPROC       PIC  X(010).*/
                public StringBasis LC03_DATAPROC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER              PIC  X(016)  VALUE             ' E QUITADOS ATE '.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @" E QUITADOS ATE ");
                /*"    10        LC03-DATABASE       PIC  X(010).*/
                public StringBasis LC03_DATABASE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER              PIC  X(081)  VALUE SPACES.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "81", "X(081)"), @"");
                /*"  03          LC04.*/
            }
            public CB1127B_LC04 LC04 { get; set; } = new CB1127B_LC04();
            public class CB1127B_LC04 : VarBasis
            {
                /*"    10        FILLER              PIC  X(033)  VALUE             'RECIBOS PROVISORIOS PENDENTES EM '.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "33", "X(033)"), @"RECIBOS PROVISORIOS PENDENTES EM ");
                /*"    10        LC04-DATAPROC       PIC  X(010).*/
                public StringBasis LC04_DATAPROC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER              PIC  X(107)  VALUE SPACES.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "107", "X(107)"), @"");
                /*"  03          LD00.*/
            }
            public CB1127B_LD00 LD00 { get; set; } = new CB1127B_LD00();
            public class CB1127B_LD00 : VarBasis
            {
                /*"    10        FILLER              PIC  X(013)  VALUE             'FONTE ;'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"FONTE ;");
                /*"    10        FILLER              PIC  X(016)  VALUE             'TITULO ;'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"TITULO ;");
                /*"    10        FILLER              PIC  X(011)  VALUE             'PROPOSTA ;'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"PROPOSTA ;");
                /*"    10        FILLER              PIC  X(013)  VALUE             'COMPLEMEN ;'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"COMPLEMEN ;");
                /*"    10        FILLER              PIC  X(011)  VALUE             'PRODUTO ;'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"PRODUTO ;");
                /*"    10        FILLER              PIC  X(006)  VALUE             'BCO ;'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"BCO ;");
                /*"    10        FILLER              PIC  X(011)  VALUE             'AGEN ;'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"AGEN ;");
                /*"    10        FILLER              PIC  X(008)  VALUE             'AVISO ;'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"AVISO ;");
                /*"    10        FILLER              PIC  X(011)  VALUE             'ORIGEM ;'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"ORIGEM ;");
                /*"    10        FILLER              PIC  X(013)  VALUE             'CADASTRO ;'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"CADASTRO ;");
                /*"    10        FILLER              PIC  X(011)  VALUE             'QUITACAO ;'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"QUITACAO ;");
                /*"    10        FILLER              PIC  X(015)  VALUE             'AGECOBR ;'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"AGECOBR ;");
                /*"    10        FILLER              PIC  X(007)  VALUE             'VALOR ;'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"VALOR ;");
                /*"    10        FILLER              PIC  X(004)  VALUE             'DIAS'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"DIAS");
                /*"  03          LD01.*/
            }
            public CB1127B_LD01 LD01 { get; set; } = new CB1127B_LD01();
            public class CB1127B_LD01 : VarBasis
            {
                /*"    10        FILLER              PIC  X(001)  VALUE SPACES.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10        LD01-FONTE          PIC  9(004).*/
                public IntBasis LD01_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-NRTIT          PIC  ZZZZZZZZZZ9.*/
                public IntBasis LD01_NRTIT { get; set; } = new IntBasis(new PIC("9", "11", "ZZZZZZZZZZ9."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-NRCERTIF       PIC  ZZZZZZZZZZZZZZ9.*/
                public IntBasis LD01_NRCERTIF { get; set; } = new IntBasis(new PIC("9", "15", "ZZZZZZZZZZZZZZ9."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-NRRCAPCO       PIC  ZZZZZZZZ9.*/
                public IntBasis LD01_NRRCAPCO { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZZZZ9."));
                /*"    10        FILLER              PIC  X(006)  VALUE ' ;'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @" ;");
                /*"    10        LD01-CODPRODU       PIC  ZZZZ9.*/
                public IntBasis LD01_CODPRODU { get; set; } = new IntBasis(new PIC("9", "5", "ZZZZ9."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-BCOAVISO       PIC  9(004).*/
                public IntBasis LD01_BCOAVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-AGEAVISO       PIC  9(004).*/
                public IntBasis LD01_AGEAVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-NRAVISO        PIC  ZZZZZZZZ9.*/
                public IntBasis LD01_NRAVISO { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZZZZ9."));
                /*"    10        FILLER              PIC  X(005)  VALUE ' ;'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @" ;");
                /*"    10        LD01-ORIGEM         PIC  9(004).*/
                public IntBasis LD01_ORIGEM { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-DTCADAST       PIC  X(010).*/
                public StringBasis LD01_DTCADAST { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-DATARCAP       PIC  X(010).*/
                public StringBasis LD01_DATARCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER              PIC  X(006)  VALUE ' ;'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @" ;");
                /*"    10        LD01-AGECOBR        PIC  9(004).*/
                public IntBasis LD01_AGECOBR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-VLRCAP         PIC  ZZZ.ZZ9,99-.*/
                public DoubleBasis LD01_VLRCAP { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V99-."), 3);
                /*"    10        FILLER              PIC  X(001)  VALUE ';'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10        LD01-QTDIAS         PIC  ZZZ9.*/
                public IntBasis LD01_QTDIAS { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
                /*"  03          LD02.*/
            }
            public CB1127B_LD02 LD02 { get; set; } = new CB1127B_LD02();
            public class CB1127B_LD02 : VarBasis
            {
                /*"    10        FILLER              PIC  X(030)  VALUE SPACES.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(026)  VALUE             'ATE 015 DIAS'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"ATE 015 DIAS");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(026)  VALUE             'DE 016 ATE 365 DIAS'.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"DE 016 ATE 365 DIAS");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(026)  VALUE             'ACIMA DE 365 DIAS'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"ACIMA DE 365 DIAS");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(026)  VALUE             'TOTAL GERAL'.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"TOTAL GERAL");
                /*"    10        FILLER              PIC  X(004)  VALUE ' ;'.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @" ;");
                /*"  03          LD03.*/
            }
            public CB1127B_LD03 LD03 { get; set; } = new CB1127B_LD03();
            public class CB1127B_LD03 : VarBasis
            {
                /*"    10        FILLER              PIC  X(030)  VALUE             'PRODUTO'.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"PRODUTO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(021)  VALUE             'QUANTIDADE ;'.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"QUANTIDADE ;");
                /*"    10        FILLER              PIC  X(005)  VALUE             'VALOR'.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"VALOR");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(021)  VALUE             'QUANTIDADE ;'.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"QUANTIDADE ;");
                /*"    10        FILLER              PIC  X(005)  VALUE             'VALOR'.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"VALOR");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(021)  VALUE             'QUANTIDADE ;'.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"QUANTIDADE ;");
                /*"    10        FILLER              PIC  X(005)  VALUE             'VALOR'.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"VALOR");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(021)  VALUE             'QUANTIDADE ;'.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"QUANTIDADE ;");
                /*"    10        FILLER              PIC  X(005)  VALUE             'VALOR'.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"VALOR");
                /*"    10        FILLER              PIC  X(004)  VALUE ' ;'.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @" ;");
                /*"  03          LD04.*/
            }
            public CB1127B_LD04 LD04 { get; set; } = new CB1127B_LD04();
            public class CB1127B_LD04 : VarBasis
            {
                /*"    10        LD04-PRODUTO        PIC  X(030).*/
                public StringBasis LD04_PRODUTO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"    10        FILLER              PIC  X(006)  VALUE ' ;'.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @" ;");
                /*"    10        LD04-QTD015         PIC  ZZZ.ZZ9.*/
                public IntBasis LD04_QTD015 { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.ZZ9."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD04-VLR015         PIC  ZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LD04_VLR015 { get; set; } = new DoubleBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9V99."), 2);
                /*"    10        FILLER              PIC  X(006)  VALUE ' ;'.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @" ;");
                /*"    10        LD04-QTD365         PIC  ZZZ.ZZ9.*/
                public IntBasis LD04_QTD365 { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.ZZ9."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD04-VLR365         PIC  ZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LD04_VLR365 { get; set; } = new DoubleBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9V99."), 2);
                /*"    10        FILLER              PIC  X(006)  VALUE ' ;'.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @" ;");
                /*"    10        LD04-QTD366         PIC  ZZZ.ZZ9.*/
                public IntBasis LD04_QTD366 { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.ZZ9."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD04-VLR366         PIC  ZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LD04_VLR366 { get; set; } = new DoubleBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9V99."), 2);
                /*"    10        FILLER              PIC  X(006)  VALUE ' ;'.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @" ;");
                /*"    10        LD04-QTDTOT         PIC  ZZZ.ZZ9.*/
                public IntBasis LD04_QTDTOT { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.ZZ9."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD04-VLRTOT         PIC  ZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LD04_VLRTOT { get; set; } = new DoubleBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9V99."), 2);
                /*"    10        FILLER              PIC  X(004)  VALUE ' ;'.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @" ;");
                /*"01            LPARM.*/
            }
        }
        public CB1127B_LPARM LPARM { get; set; } = new CB1127B_LPARM();
        public class CB1127B_LPARM : VarBasis
        {
            /*"  03          LPARM01.*/
            public CB1127B_LPARM01 LPARM01 { get; set; } = new CB1127B_LPARM01();
            public class CB1127B_LPARM01 : VarBasis
            {
                /*"    10        LPARM01-DD          PIC  9(002).*/
                public IntBasis LPARM01_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10        LPARM01-MM          PIC  9(002).*/
                public IntBasis LPARM01_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10        LPARM01-AA          PIC  9(004).*/
                public IntBasis LPARM01_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  03          LPARM02.*/
            }
            public CB1127B_LPARM02 LPARM02 { get; set; } = new CB1127B_LPARM02();
            public class CB1127B_LPARM02 : VarBasis
            {
                /*"    10        LPARM02-DD          PIC  9(002).*/
                public IntBasis LPARM02_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10        LPARM02-MM          PIC  9(002).*/
                public IntBasis LPARM02_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10        LPARM02-AA          PIC  9(004).*/
                public IntBasis LPARM02_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  03          LPARM03             PIC S9(005)    COMP-3.*/
            }
            public IntBasis LPARM03 { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"01            WS-TABELAS.*/
        }
        public CB1127B_WS_TABELAS WS_TABELAS { get; set; } = new CB1127B_WS_TABELAS();
        public class CB1127B_WS_TABELAS : VarBasis
        {
            /*"  03          WTPRD-PRODUTO.*/
            public CB1127B_WTPRD_PRODUTO WTPRD_PRODUTO { get; set; } = new CB1127B_WTPRD_PRODUTO();
            public class CB1127B_WTPRD_PRODUTO : VarBasis
            {
                /*"    05        WTPRD-OCORREPRD     OCCURS       20    TIMES                                  INDEXED      BY    WS-PRD.*/
                public ListBasis<CB1127B_WTPRD_OCORREPRD> WTPRD_OCORREPRD { get; set; } = new ListBasis<CB1127B_WTPRD_OCORREPRD>(20);
                public class CB1127B_WTPRD_OCORREPRD : VarBasis
                {
                    /*"      10      WTPRD-CODPRODU      PIC  9(004).*/
                    public IntBasis WTPRD_CODPRODU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      10      WTPRD-NOMEPRD       PIC  X(030).*/
                    public StringBasis WTPRD_NOMEPRD { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                    /*"      10      WTPRD-QTD015        PIC S9(009)        COMP.*/
                    public IntBasis WTPRD_QTD015 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                    /*"      10      WTPRD-VLR015        PIC S9(013)V99     COMP-3.*/
                    public DoubleBasis WTPRD_VLR015 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                    /*"      10      WTPRD-QTD365        PIC S9(009)        COMP.*/
                    public IntBasis WTPRD_QTD365 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                    /*"      10      WTPRD-VLR365        PIC S9(013)V99     COMP-3.*/
                    public DoubleBasis WTPRD_VLR365 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                    /*"      10      WTPRD-QTD366        PIC S9(009)        COMP.*/
                    public IntBasis WTPRD_QTD366 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                    /*"      10      WTPRD-VLR366        PIC S9(013)V99     COMP-3.*/
                    public DoubleBasis WTPRD_VLR366 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                }
            }
        }


        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public CB1127B_V0RCAP V0RCAP { get; set; } = new CB1127B_V0RCAP();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string MOVTO_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                MOVTO.SetFile(MOVTO_FILE_NAME_P);

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
            /*" -376- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", W.WABEND.WNR_EXEC_SQL);

            /*" -377- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -379- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -381- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -388- OPEN OUTPUT MOVTO MOVTO1. */
            MOVTO.Open(SAI_MOVTO);
            MOVTO1.Open(SAI_MOVTO1);

            /*" -389- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), W.WS_TIME);

            /*" -390- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_1.WTIME_DAYR.WTIME_HORA);

            /*" -391- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", W.FILLER_1.WTIME_DAYR.WTIME_2PT1);

            /*" -392- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_1.WTIME_DAYR.WTIME_MINU);

            /*" -393- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", W.FILLER_1.WTIME_DAYR.WTIME_2PT2);

            /*" -394- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_1.WTIME_DAYR.WTIME_SEGU);

            /*" -397- DISPLAY 'INICIO PROCESSAMENTO   ' WTIME-DAYR. */
            _.Display($"INICIO PROCESSAMENTO   {W.FILLER_1.WTIME_DAYR}");

            /*" -399- PERFORM R0100-00-SELECT-V0SISTEMA. */

            R0100_00_SELECT_V0SISTEMA_SECTION();

            /*" -400- SET WS-PRD TO 1. */
            WS_PRD.Value = 1;

            /*" -403- PERFORM R0200-00-LIMPA-V0MOVTO 20 TIMES. */

            for (int i = 0; i < 20; i++)
            {

                R0200_00_LIMPA_V0MOVTO_SECTION();

            }

            /*" -404- MOVE SPACES TO WFIM-V0RCAP. */
            _.Move("", W.WFIM_V0RCAP);

            /*" -405- PERFORM R0300-00-DECLARE-V0RCAP. */

            R0300_00_DECLARE_V0RCAP_SECTION();

            /*" -407- PERFORM R0310-00-FETCH-V0RCAP. */

            R0310_00_FETCH_V0RCAP_SECTION();

            /*" -411- PERFORM R0400-00-PROCESSA-V0RCAP UNTIL WFIM-V0RCAP NOT EQUAL SPACES. */

            while (!(!W.WFIM_V0RCAP.IsEmpty()))
            {

                R0400_00_PROCESSA_V0RCAP_SECTION();
            }

            /*" -411- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -415- SET WS-PRD TO 1. */
            WS_PRD.Value = 1;

            /*" -415- PERFORM R1000-00-IMPRIME-RESUMO 20 TIMES. */

            for (int i = 0; i < 20; i++)
            {

                R1000_00_IMPRIME_RESUMO_SECTION();

            }

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -420- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -425- CLOSE MOVTO MOVTO1. */
            MOVTO.Close();
            MOVTO1.Close();

            /*" -427- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -428- DISPLAY ' ' */
            _.Display($" ");

            /*" -429- DISPLAY 'CB1127B - FIM NORMAL' . */
            _.Display($"CB1127B - FIM NORMAL");

            /*" -430- DISPLAY ' ' */
            _.Display($" ");

            /*" -431- DISPLAY 'REGISTROS LIDOS........ ' AC-LIDOS */
            _.Display($"REGISTROS LIDOS........ {W.AC_LIDOS}");

            /*" -432- DISPLAY ' ' */
            _.Display($" ");

            /*" -433- DISPLAY 'DESPREZA OPERACAO ..... ' DP-OPERACAO */
            _.Display($"DESPREZA OPERACAO ..... {W.DP_OPERACAO}");

            /*" -434- DISPLAY 'DESPREZA DATA ......... ' DP-DATA */
            _.Display($"DESPREZA DATA ......... {W.DP_DATA}");

            /*" -435- DISPLAY 'DESPREZA PRODUTO ...... ' DP-PRODUTO */
            _.Display($"DESPREZA PRODUTO ...... {W.DP_PRODUTO}");

            /*" -436- DISPLAY ' ' */
            _.Display($" ");

            /*" -437- DISPLAY 'REGISTROS GRAVADOS..... ' AC-GRAVA */
            _.Display($"REGISTROS GRAVADOS..... {W.AC_GRAVA}");

            /*" -438- DISPLAY ' ' */
            _.Display($" ");

            /*" -439- DISPLAY 'RESUMO    GRAVADOS..... ' AC-GRAVA1 */
            _.Display($"RESUMO    GRAVADOS..... {W.AC_GRAVA1}");

            /*" -440- DISPLAY ' ' */
            _.Display($" ");

            /*" -441- DISPLAY 'CB1127B - FIM NORMAL' . */
            _.Display($"CB1127B - FIM NORMAL");

            /*" -444- DISPLAY ' ' */
            _.Display($" ");

            /*" -444- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-SECTION */
        private void R0100_00_SELECT_V0SISTEMA_SECTION()
        {
            /*" -456- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", W.WABEND.WNR_EXEC_SQL);

            /*" -466- PERFORM R0100_00_SELECT_V0SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V0SISTEMA_DB_SELECT_1();

            /*" -469- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -470- DISPLAY 'R0100-00 - PROBLEMAS NO SELECT(V0SISTEMA)' */
                _.Display($"R0100-00 - PROBLEMAS NO SELECT(V0SISTEMA)");

                /*" -473- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -474- MOVE V0SIST-DTMOVABE TO WDATA-REL */
            _.Move(V0SIST_DTMOVABE, W.WDATA_REL);

            /*" -475- MOVE WDAT-REL-DIA TO WDATA-DD-CABEC */
            _.Move(W.FILLER_2.WDAT_REL_DIA, W.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -476- MOVE WDAT-REL-MES TO WDATA-MM-CABEC */
            _.Move(W.FILLER_2.WDAT_REL_MES, W.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -477- MOVE WDAT-REL-ANO TO WDATA-AA-CABEC */
            _.Move(W.FILLER_2.WDAT_REL_ANO, W.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -480- MOVE WDATA-CABEC TO LC03-DATAPROC LC04-DATAPROC. */
            _.Move(W.WDATA_CABEC, W.LC03.LC03_DATAPROC, W.LC04.LC04_DATAPROC);

            /*" -481- MOVE WSHOST-DATA015 TO WDATA-REL */
            _.Move(WSHOST_DATA015, W.WDATA_REL);

            /*" -482- MOVE WDAT-REL-DIA TO WDATA-DD-CABEC */
            _.Move(W.FILLER_2.WDAT_REL_DIA, W.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -483- MOVE WDAT-REL-MES TO WDATA-MM-CABEC */
            _.Move(W.FILLER_2.WDAT_REL_MES, W.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -484- MOVE WDAT-REL-ANO TO WDATA-AA-CABEC */
            _.Move(W.FILLER_2.WDAT_REL_ANO, W.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -487- MOVE WDATA-CABEC TO LC03-DATABASE. */
            _.Move(W.WDATA_CABEC, W.LC03.LC03_DATABASE);

            /*" -488- WRITE SAI-MOVTO FROM LC03. */
            _.Move(W.LC03.GetMoveValues(), SAI_MOVTO);

            MOVTO.Write(SAI_MOVTO.GetMoveValues().ToString());

            /*" -491- WRITE SAI-MOVTO FROM LD00. */
            _.Move(W.LD00.GetMoveValues(), SAI_MOVTO);

            MOVTO.Write(SAI_MOVTO.GetMoveValues().ToString());

            /*" -492- WRITE SAI-MOVTO1 FROM LC04. */
            _.Move(W.LC04.GetMoveValues(), SAI_MOVTO1);

            MOVTO1.Write(SAI_MOVTO1.GetMoveValues().ToString());

            /*" -493- WRITE SAI-MOVTO1 FROM LD02. */
            _.Move(W.LD02.GetMoveValues(), SAI_MOVTO1);

            MOVTO1.Write(SAI_MOVTO1.GetMoveValues().ToString());

            /*" -493- WRITE SAI-MOVTO1 FROM LD03. */
            _.Move(W.LD03.GetMoveValues(), SAI_MOVTO1);

            MOVTO1.Write(SAI_MOVTO1.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V0SISTEMA_DB_SELECT_1()
        {
            /*" -466- EXEC SQL SELECT DTMOVABE , (DTMOVABE - 015 DAYS), (DTMOVABE - 365 DAYS) INTO :V0SIST-DTMOVABE , :WSHOST-DATA015 , :WSHOST-DATA365 FROM SEGUROS.V0SISTEMA WHERE IDSISTEM = 'CB' WITH UR END-EXEC. */

            var r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SIST_DTMOVABE, V0SIST_DTMOVABE);
                _.Move(executed_1.WSHOST_DATA015, WSHOST_DATA015);
                _.Move(executed_1.WSHOST_DATA365, WSHOST_DATA365);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-LIMPA-V0MOVTO-SECTION */
        private void R0200_00_LIMPA_V0MOVTO_SECTION()
        {
            /*" -506- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", W.WABEND.WNR_EXEC_SQL);

            /*" -509- SET WS-SUBS TO WS-PRD. */
            W.WS_SUBS.Value = WS_PRD;

            /*" -510- IF WS-SUBS EQUAL 01 */

            if (W.WS_SUBS == 01)
            {

                /*" -512- MOVE 8101 TO WTPRD-CODPRODU(WS-PRD) */
                _.Move(8101, WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_CODPRODU);

                /*" -514- MOVE 'APOLICES ESPECIFICAS          ' TO WTPRD-NOMEPRD(WS-PRD) */
                _.Move("APOLICES ESPECIFICAS          ", WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_NOMEPRD);

                /*" -515- ELSE */
            }
            else
            {


                /*" -516- IF WS-SUBS EQUAL 02 */

                if (W.WS_SUBS == 02)
                {

                    /*" -518- MOVE 9312 TO WTPRD-CODPRODU(WS-PRD) */
                    _.Move(9312, WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_CODPRODU);

                    /*" -520- MOVE 'VIDA DA GENTE                 ' TO WTPRD-NOMEPRD(WS-PRD) */
                    _.Move("VIDA DA GENTE                 ", WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_NOMEPRD);

                    /*" -521- ELSE */
                }
                else
                {


                    /*" -522- IF WS-SUBS EQUAL 03 */

                    if (W.WS_SUBS == 03)
                    {

                        /*" -524- MOVE 9309 TO WTPRD-CODPRODU(WS-PRD) */
                        _.Move(9309, WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_CODPRODU);

                        /*" -526- MOVE 'MULTIPREMIADO SUPER           ' TO WTPRD-NOMEPRD(WS-PRD) */
                        _.Move("MULTIPREMIADO SUPER           ", WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_NOMEPRD);

                        /*" -527- ELSE */
                    }
                    else
                    {


                        /*" -528- IF WS-SUBS EQUAL 04 */

                        if (W.WS_SUBS == 04)
                        {

                            /*" -530- MOVE 9315 TO WTPRD-CODPRODU(WS-PRD) */
                            _.Move(9315, WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_CODPRODU);

                            /*" -532- MOVE 'VIDAZUL EMPRESARIAL           ' TO WTPRD-NOMEPRD(WS-PRD) */
                            _.Move("VIDAZUL EMPRESARIAL           ", WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_NOMEPRD);

                            /*" -533- ELSE */
                        }
                        else
                        {


                            /*" -534- IF WS-SUBS EQUAL 05 */

                            if (W.WS_SUBS == 05)
                            {

                                /*" -536- MOVE 9327 TO WTPRD-CODPRODU(WS-PRD) */
                                _.Move(9327, WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_CODPRODU);

                                /*" -538- MOVE 'VIDA MULHER                   ' TO WTPRD-NOMEPRD(WS-PRD) */
                                _.Move("VIDA MULHER                   ", WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_NOMEPRD);

                                /*" -539- ELSE */
                            }
                            else
                            {


                                /*" -540- IF WS-SUBS EQUAL 06 */

                                if (W.WS_SUBS == 06)
                                {

                                    /*" -542- MOVE 9703 TO WTPRD-CODPRODU(WS-PRD) */
                                    _.Move(9703, WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_CODPRODU);

                                    /*" -544- MOVE 'VIDAZUL SENIOR                ' TO WTPRD-NOMEPRD(WS-PRD) */
                                    _.Move("VIDAZUL SENIOR                ", WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_NOMEPRD);

                                    /*" -545- ELSE */
                                }
                                else
                                {


                                    /*" -546- IF WS-SUBS EQUAL 07 */

                                    if (W.WS_SUBS == 07)
                                    {

                                        /*" -548- MOVE 8202 TO WTPRD-CODPRODU(WS-PRD) */
                                        _.Move(8202, WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_CODPRODU);

                                        /*" -550- MOVE 'BILHETE AP                    ' TO WTPRD-NOMEPRD(WS-PRD) */
                                        _.Move("BILHETE AP                    ", WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_NOMEPRD);

                                        /*" -551- ELSE */
                                    }
                                    else
                                    {


                                        /*" -552- IF WS-SUBS EQUAL 08 */

                                        if (W.WS_SUBS == 08)
                                        {

                                            /*" -554- MOVE 9300 TO WTPRD-CODPRODU(WS-PRD) */
                                            _.Move(9300, WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_CODPRODU);

                                            /*" -556- MOVE 'FEDERAL CLUBE                 ' TO WTPRD-NOMEPRD(WS-PRD) */
                                            _.Move("FEDERAL CLUBE                 ", WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_NOMEPRD);

                                            /*" -557- ELSE */
                                        }
                                        else
                                        {


                                            /*" -558- IF WS-SUBS EQUAL 09 */

                                            if (W.WS_SUBS == 09)
                                            {

                                                /*" -560- MOVE 9705 TO WTPRD-CODPRODU(WS-PRD) */
                                                _.Move(9705, WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_CODPRODU);

                                                /*" -562- MOVE 'VIDAZUL EXECUTIVO             ' TO WTPRD-NOMEPRD(WS-PRD) */
                                                _.Move("VIDAZUL EXECUTIVO             ", WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_NOMEPRD);

                                                /*" -563- ELSE */
                                            }
                                            else
                                            {


                                                /*" -564- IF WS-SUBS EQUAL 10 */

                                                if (W.WS_SUBS == 10)
                                                {

                                                    /*" -566- MOVE 9707 TO WTPRD-CODPRODU(WS-PRD) */
                                                    _.Move(9707, WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_CODPRODU);

                                                    /*" -568- MOVE 'VIDAZUL MULTIPREMIADO         ' TO WTPRD-NOMEPRD(WS-PRD) */
                                                    _.Move("VIDAZUL MULTIPREMIADO         ", WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_NOMEPRD);

                                                    /*" -569- ELSE */
                                                }
                                                else
                                                {


                                                    /*" -570- IF WS-SUBS EQUAL 11 */

                                                    if (W.WS_SUBS == 11)
                                                    {

                                                        /*" -572- MOVE 5555 TO WTPRD-CODPRODU(WS-PRD) */
                                                        _.Move(5555, WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_CODPRODU);

                                                        /*" -574- MOVE 'PENDENCIAS VIDAZUL            ' TO WTPRD-NOMEPRD(WS-PRD) */
                                                        _.Move("PENDENCIAS VIDAZUL            ", WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_NOMEPRD);

                                                        /*" -575- ELSE */
                                                    }
                                                    else
                                                    {


                                                        /*" -576- IF WS-SUBS EQUAL 12 */

                                                        if (W.WS_SUBS == 12)
                                                        {

                                                            /*" -578- MOVE 6666 TO WTPRD-CODPRODU(WS-PRD) */
                                                            _.Move(6666, WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_CODPRODU);

                                                            /*" -580- MOVE 'PENDENCIAS OUTROS PRODUTOS    ' TO WTPRD-NOMEPRD(WS-PRD) */
                                                            _.Move("PENDENCIAS OUTROS PRODUTOS    ", WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_NOMEPRD);

                                                            /*" -581- ELSE */
                                                        }
                                                        else
                                                        {


                                                            /*" -582- IF WS-SUBS EQUAL 13 */

                                                            if (W.WS_SUBS == 13)
                                                            {

                                                                /*" -584- MOVE 7777 TO WTPRD-CODPRODU(WS-PRD) */
                                                                _.Move(7777, WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_CODPRODU);

                                                                /*" -586- MOVE 'PENDENCIAS AVULSOS            ' TO WTPRD-NOMEPRD(WS-PRD) */
                                                                _.Move("PENDENCIAS AVULSOS            ", WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_NOMEPRD);

                                                                /*" -587- ELSE */
                                                            }
                                                            else
                                                            {


                                                                /*" -588- IF WS-SUBS EQUAL 20 */

                                                                if (W.WS_SUBS == 20)
                                                                {

                                                                    /*" -590- MOVE 9999 TO WTPRD-CODPRODU(WS-PRD) */
                                                                    _.Move(9999, WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_CODPRODU);

                                                                    /*" -592- MOVE 'TOTAL PENDENCIAS              ' TO WTPRD-NOMEPRD(WS-PRD) */
                                                                    _.Move("TOTAL PENDENCIAS              ", WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_NOMEPRD);

                                                                    /*" -593- ELSE */
                                                                }
                                                                else
                                                                {


                                                                    /*" -595- MOVE ZEROS TO WTPRD-CODPRODU(WS-PRD) */
                                                                    _.Move(0, WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_CODPRODU);

                                                                    /*" -599- MOVE SPACES TO WTPRD-NOMEPRD(WS-PRD). */
                                                                    _.Move("", WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_NOMEPRD);
                                                                }

                                                            }

                                                        }

                                                    }

                                                }

                                            }

                                        }

                                    }

                                }

                            }

                        }

                    }

                }

            }


            /*" -608- MOVE ZEROS TO WTPRD-QTD015(WS-PRD) WTPRD-VLR015(WS-PRD) WTPRD-QTD365(WS-PRD) WTPRD-VLR365(WS-PRD) WTPRD-QTD366(WS-PRD) WTPRD-VLR366(WS-PRD). */
            _.Move(0, WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_QTD015, WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_VLR015, WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_QTD365, WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_VLR365, WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_QTD366, WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_VLR366);

            /*" -608- SET WS-PRD UP BY 1. */
            WS_PRD.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-DECLARE-V0RCAP-SECTION */
        private void R0300_00_DECLARE_V0RCAP_SECTION()
        {
            /*" -621- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", W.WABEND.WNR_EXEC_SQL);

            /*" -655- PERFORM R0300_00_DECLARE_V0RCAP_DB_DECLARE_1 */

            R0300_00_DECLARE_V0RCAP_DB_DECLARE_1();

            /*" -657- PERFORM R0300_00_DECLARE_V0RCAP_DB_OPEN_1 */

            R0300_00_DECLARE_V0RCAP_DB_OPEN_1();

            /*" -661- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -662- DISPLAY 'R0300-00 - PROBLEMAS DECLARE (V0RCAP)    ' */
                _.Display($"R0300-00 - PROBLEMAS DECLARE (V0RCAP)    ");

                /*" -662- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0300-00-DECLARE-V0RCAP-DB-DECLARE-1 */
        public void R0300_00_DECLARE_V0RCAP_DB_DECLARE_1()
        {
            /*" -655- EXEC SQL DECLARE V0RCAP CURSOR FOR SELECT A.VLRCAP , A.VALPRI , A.OPERACAO , A.NRTIT , A.CODPRODU , A.AGECOBR , A.NRCERTIF , B.FONTE , B.NRRCAP , B.NRRCAPCO , B.OPERACAO , B.BCOAVISO , B.AGEAVISO , B.NRAVISO , B.VLRCAP , B.DATARCAP , B.DTCADAST , B.SITCONTB , C.ORIGAVISO FROM SEGUROS.V0RCAP A, SEGUROS.V0RCAPCOMP B, SEGUROS.V0AVISOCRED C WHERE A.SITUACAO = '0' AND B.FONTE = A.FONTE AND B.NRRCAP = A.NRRCAP AND B.SITUACAO = '0' AND C.BCOAVISO = B.BCOAVISO AND C.AGEAVISO = B.AGEAVISO AND C.NRAVISO = B.NRAVISO AND C.NRSEQ = 1 ORDER BY B.FONTE, B.NRRCAP, B.NRRCAPCO END-EXEC. */
            V0RCAP = new CB1127B_V0RCAP(false);
            string GetQuery_V0RCAP()
            {
                var query = @$"SELECT A.VLRCAP
							, 
							A.VALPRI
							, 
							A.OPERACAO
							, 
							A.NRTIT
							, 
							A.CODPRODU
							, 
							A.AGECOBR
							, 
							A.NRCERTIF
							, 
							B.FONTE
							, 
							B.NRRCAP
							, 
							B.NRRCAPCO
							, 
							B.OPERACAO
							, 
							B.BCOAVISO
							, 
							B.AGEAVISO
							, 
							B.NRAVISO
							, 
							B.VLRCAP
							, 
							B.DATARCAP
							, 
							B.DTCADAST
							, 
							B.SITCONTB
							, 
							C.ORIGAVISO 
							FROM SEGUROS.V0RCAP A
							, 
							SEGUROS.V0RCAPCOMP B
							, 
							SEGUROS.V0AVISOCRED C 
							WHERE A.SITUACAO = '0' 
							AND B.FONTE = A.FONTE 
							AND B.NRRCAP = A.NRRCAP 
							AND B.SITUACAO = '0' 
							AND C.BCOAVISO = B.BCOAVISO 
							AND C.AGEAVISO = B.AGEAVISO 
							AND C.NRAVISO = B.NRAVISO 
							AND C.NRSEQ = 1 
							ORDER BY B.FONTE
							, B.NRRCAP
							, B.NRRCAPCO";

                return query;
            }
            V0RCAP.GetQueryEvent += GetQuery_V0RCAP;

        }

        [StopWatch]
        /*" R0300-00-DECLARE-V0RCAP-DB-OPEN-1 */
        public void R0300_00_DECLARE_V0RCAP_DB_OPEN_1()
        {
            /*" -657- EXEC SQL OPEN V0RCAP END-EXEC. */

            V0RCAP.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0310-00-FETCH-V0RCAP-SECTION */
        private void R0310_00_FETCH_V0RCAP_SECTION()
        {
            /*" -675- MOVE '0310' TO WNR-EXEC-SQL. */
            _.Move("0310", W.WABEND.WNR_EXEC_SQL);

            /*" -695- PERFORM R0310_00_FETCH_V0RCAP_DB_FETCH_1 */

            R0310_00_FETCH_V0RCAP_DB_FETCH_1();

            /*" -699- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -699- PERFORM R0310_00_FETCH_V0RCAP_DB_CLOSE_1 */

                R0310_00_FETCH_V0RCAP_DB_CLOSE_1();

                /*" -701- MOVE 'S' TO WFIM-V0RCAP */
                _.Move("S", W.WFIM_V0RCAP);

                /*" -703- MOVE ZEROS TO ATU-FONTE ATU-NRRCAP */
                _.Move(0, W.WS_CHAVE_ATU.ATU_FONTE, W.WS_CHAVE_ATU.ATU_NRRCAP);

                /*" -705- GO TO R0310-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/ //GOTO
                return;
            }


            /*" -706- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -707- DISPLAY 'R0310-00 - PROBLEMAS FETCH   (V0RCAP)    ' */
                _.Display($"R0310-00 - PROBLEMAS FETCH   (V0RCAP)    ");

                /*" -710- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -711- IF VIND-NRTIT LESS ZEROS */

            if (VIND_NRTIT < 00)
            {

                /*" -713- MOVE ZEROS TO V0RCAP-NRTIT. */
                _.Move(0, V0RCAP_NRTIT);
            }


            /*" -714- IF VIND-NRCERTIF LESS ZEROS */

            if (VIND_NRCERTIF < 00)
            {

                /*" -716- MOVE ZEROS TO V0RCAP-NRCERTIF. */
                _.Move(0, V0RCAP_NRCERTIF);
            }


            /*" -717- IF VIND-CODPRODU LESS ZEROS */

            if (VIND_CODPRODU < 00)
            {

                /*" -719- MOVE ZEROS TO V0RCAP-CODPRODU. */
                _.Move(0, V0RCAP_CODPRODU);
            }


            /*" -720- IF VIND-AGECOBR LESS ZEROS */

            if (VIND_AGECOBR < 00)
            {

                /*" -722- MOVE ZEROS TO V0RCAP-AGECOBR. */
                _.Move(0, V0RCAP_AGECOBR);
            }


            /*" -723- IF VIND-ORIGEM LESS ZEROS */

            if (VIND_ORIGEM < 00)
            {

                /*" -726- MOVE 1 TO V0AVIS-ORIGEM. */
                _.Move(1, V0AVIS_ORIGEM);
            }


            /*" -729- ADD 1 TO AC-LIDOS. */
            W.AC_LIDOS.Value = W.AC_LIDOS + 1;

            /*" -730- MOVE V0RCOM-FONTE TO ATU-FONTE */
            _.Move(V0RCOM_FONTE, W.WS_CHAVE_ATU.ATU_FONTE);

            /*" -733- MOVE V0RCOM-NRRCAP TO ATU-NRRCAP. */
            _.Move(V0RCOM_NRRCAP, W.WS_CHAVE_ATU.ATU_NRRCAP);

            /*" -736- IF AC-LIDOS EQUAL 1000 OR LD-PARTE2 EQUAL ZEROS OR LD-PARTE2 EQUAL 5000 */

            if (W.AC_LIDOS == 1000 || W.FILLER_0.LD_PARTE2 == 00 || W.FILLER_0.LD_PARTE2 == 5000)
            {

                /*" -737- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), W.WS_TIME);

                /*" -738- MOVE WS-HH-TIME TO WTIME-HORA */
                _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_1.WTIME_DAYR.WTIME_HORA);

                /*" -739- MOVE '.' TO WTIME-2PT1 */
                _.Move(".", W.FILLER_1.WTIME_DAYR.WTIME_2PT1);

                /*" -740- MOVE WS-MM-TIME TO WTIME-MINU */
                _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_1.WTIME_DAYR.WTIME_MINU);

                /*" -741- MOVE '.' TO WTIME-2PT2 */
                _.Move(".", W.FILLER_1.WTIME_DAYR.WTIME_2PT2);

                /*" -742- MOVE WS-SS-TIME TO WTIME-SEGU */
                _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_1.WTIME_DAYR.WTIME_SEGU);

                /*" -746- DISPLAY 'REGISTROS PROCESSADOS  ' AC-LIDOS '              ' WTIME-DAYR. */

                $"REGISTROS PROCESSADOS  {W.AC_LIDOS}              {W.FILLER_1.WTIME_DAYR}"
                .Display();
            }


            /*" -748- IF V0RCOM-OPERACAO LESS 100 OR V0RCOM-OPERACAO GREATER 599 */

            if (V0RCOM_OPERACAO < 100 || V0RCOM_OPERACAO > 599)
            {

                /*" -749- ADD 1 TO DP-OPERACAO */
                W.DP_OPERACAO.Value = W.DP_OPERACAO + 1;

                /*" -751- GO TO R0310-00-FETCH-V0RCAP. */
                new Task(() => R0310_00_FETCH_V0RCAP_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -753- IF V0RCOM-OPERACAO GREATER 199 AND V0RCOM-OPERACAO LESS 301 */

            if (V0RCOM_OPERACAO > 199 && V0RCOM_OPERACAO < 301)
            {

                /*" -754- ADD 1 TO DP-OPERACAO */
                W.DP_OPERACAO.Value = W.DP_OPERACAO + 1;

                /*" -756- GO TO R0310-00-FETCH-V0RCAP. */
                new Task(() => R0310_00_FETCH_V0RCAP_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -758- IF V0RCOM-OPERACAO GREATER 399 AND V0RCOM-OPERACAO LESS 500 */

            if (V0RCOM_OPERACAO > 399 && V0RCOM_OPERACAO < 500)
            {

                /*" -759- ADD 1 TO DP-OPERACAO */
                W.DP_OPERACAO.Value = W.DP_OPERACAO + 1;

                /*" -759- GO TO R0310-00-FETCH-V0RCAP. */
                new Task(() => R0310_00_FETCH_V0RCAP_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }

        [StopWatch]
        /*" R0310-00-FETCH-V0RCAP-DB-FETCH-1 */
        public void R0310_00_FETCH_V0RCAP_DB_FETCH_1()
        {
            /*" -695- EXEC SQL FETCH V0RCAP INTO :V0RCAP-VLRCAP , :V0RCAP-VALPRI , :V0RCAP-OPERACAO , :V0RCAP-NRTIT:VIND-NRTIT , :V0RCAP-CODPRODU:VIND-CODPRODU , :V0RCAP-AGECOBR:VIND-AGECOBR , :V0RCAP-NRCERTIF:VIND-NRCERTIF , :V0RCOM-FONTE , :V0RCOM-NRRCAP , :V0RCOM-NRRCAPCO , :V0RCOM-OPERACAO , :V0RCOM-BCOAVISO , :V0RCOM-AGEAVISO , :V0RCOM-NRAVISO , :V0RCOM-VLRCAP , :V0RCOM-DATARCAP , :V0RCOM-DTCADAST , :V0RCOM-SITCONTB , :V0AVIS-ORIGEM:VIND-ORIGEM END-EXEC. */

            if (V0RCAP.Fetch())
            {
                _.Move(V0RCAP.V0RCAP_VLRCAP, V0RCAP_VLRCAP);
                _.Move(V0RCAP.V0RCAP_VALPRI, V0RCAP_VALPRI);
                _.Move(V0RCAP.V0RCAP_OPERACAO, V0RCAP_OPERACAO);
                _.Move(V0RCAP.V0RCAP_NRTIT, V0RCAP_NRTIT);
                _.Move(V0RCAP.VIND_NRTIT, VIND_NRTIT);
                _.Move(V0RCAP.V0RCAP_CODPRODU, V0RCAP_CODPRODU);
                _.Move(V0RCAP.VIND_CODPRODU, VIND_CODPRODU);
                _.Move(V0RCAP.V0RCAP_AGECOBR, V0RCAP_AGECOBR);
                _.Move(V0RCAP.VIND_AGECOBR, VIND_AGECOBR);
                _.Move(V0RCAP.V0RCAP_NRCERTIF, V0RCAP_NRCERTIF);
                _.Move(V0RCAP.VIND_NRCERTIF, VIND_NRCERTIF);
                _.Move(V0RCAP.V0RCOM_FONTE, V0RCOM_FONTE);
                _.Move(V0RCAP.V0RCOM_NRRCAP, V0RCOM_NRRCAP);
                _.Move(V0RCAP.V0RCOM_NRRCAPCO, V0RCOM_NRRCAPCO);
                _.Move(V0RCAP.V0RCOM_OPERACAO, V0RCOM_OPERACAO);
                _.Move(V0RCAP.V0RCOM_BCOAVISO, V0RCOM_BCOAVISO);
                _.Move(V0RCAP.V0RCOM_AGEAVISO, V0RCOM_AGEAVISO);
                _.Move(V0RCAP.V0RCOM_NRAVISO, V0RCOM_NRAVISO);
                _.Move(V0RCAP.V0RCOM_VLRCAP, V0RCOM_VLRCAP);
                _.Move(V0RCAP.V0RCOM_DATARCAP, V0RCOM_DATARCAP);
                _.Move(V0RCAP.V0RCOM_DTCADAST, V0RCOM_DTCADAST);
                _.Move(V0RCAP.V0RCOM_SITCONTB, V0RCOM_SITCONTB);
                _.Move(V0RCAP.V0AVIS_ORIGEM, V0AVIS_ORIGEM);
                _.Move(V0RCAP.VIND_ORIGEM, VIND_ORIGEM);
            }

        }

        [StopWatch]
        /*" R0310-00-FETCH-V0RCAP-DB-CLOSE-1 */
        public void R0310_00_FETCH_V0RCAP_DB_CLOSE_1()
        {
            /*" -699- EXEC SQL CLOSE V0RCAP END-EXEC */

            V0RCAP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-PROCESSA-V0RCAP-SECTION */
        private void R0400_00_PROCESSA_V0RCAP_SECTION()
        {
            /*" -772- MOVE '0400' TO WNR-EXEC-SQL. */
            _.Move("0400", W.WABEND.WNR_EXEC_SQL);

            /*" -774- MOVE WS-CHAVE-ATU TO WS-CHAVE-ANT. */
            _.Move(W.WS_CHAVE_ATU, W.WS_CHAVE_ANT);

            /*" -776- PERFORM R0500-00-PROCESSA-RECIBO UNTIL WS-CHAVE-ATU NOT EQUAL WS-CHAVE-ANT OR WFIM-V0RCAP NOT EQUAL SPACES. */

            while (!(W.WS_CHAVE_ATU != W.WS_CHAVE_ANT || !W.WFIM_V0RCAP.IsEmpty()))
            {

                R0500_00_PROCESSA_RECIBO_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-PROCESSA-RECIBO-SECTION */
        private void R0500_00_PROCESSA_RECIBO_SECTION()
        {
            /*" -789- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", W.WABEND.WNR_EXEC_SQL);

            /*" -790- MOVE V0RCOM-FONTE TO LD01-FONTE. */
            _.Move(V0RCOM_FONTE, W.LD01.LD01_FONTE);

            /*" -791- MOVE V0RCAP-NRTIT TO LD01-NRTIT. */
            _.Move(V0RCAP_NRTIT, W.LD01.LD01_NRTIT);

            /*" -792- MOVE V0RCAP-NRCERTIF TO LD01-NRCERTIF. */
            _.Move(V0RCAP_NRCERTIF, W.LD01.LD01_NRCERTIF);

            /*" -793- MOVE V0RCOM-NRRCAPCO TO LD01-NRRCAPCO. */
            _.Move(V0RCOM_NRRCAPCO, W.LD01.LD01_NRRCAPCO);

            /*" -794- MOVE V0RCAP-CODPRODU TO LD01-CODPRODU. */
            _.Move(V0RCAP_CODPRODU, W.LD01.LD01_CODPRODU);

            /*" -795- MOVE V0RCOM-BCOAVISO TO LD01-BCOAVISO. */
            _.Move(V0RCOM_BCOAVISO, W.LD01.LD01_BCOAVISO);

            /*" -796- MOVE V0RCOM-AGEAVISO TO LD01-AGEAVISO. */
            _.Move(V0RCOM_AGEAVISO, W.LD01.LD01_AGEAVISO);

            /*" -797- MOVE V0RCOM-NRAVISO TO LD01-NRAVISO. */
            _.Move(V0RCOM_NRAVISO, W.LD01.LD01_NRAVISO);

            /*" -798- MOVE V0AVIS-ORIGEM TO LD01-ORIGEM. */
            _.Move(V0AVIS_ORIGEM, W.LD01.LD01_ORIGEM);

            /*" -799- MOVE V0RCAP-AGECOBR TO LD01-AGECOBR. */
            _.Move(V0RCAP_AGECOBR, W.LD01.LD01_AGECOBR);

            /*" -801- MOVE V0RCOM-VLRCAP TO LD01-VLRCAP. */
            _.Move(V0RCOM_VLRCAP, W.LD01.LD01_VLRCAP);

            /*" -802- MOVE V0RCOM-DTCADAST TO WDATA-REL */
            _.Move(V0RCOM_DTCADAST, W.WDATA_REL);

            /*" -803- MOVE WDAT-REL-DIA TO WDATA-DD-CABEC */
            _.Move(W.FILLER_2.WDAT_REL_DIA, W.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -804- MOVE WDAT-REL-MES TO WDATA-MM-CABEC */
            _.Move(W.FILLER_2.WDAT_REL_MES, W.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -805- MOVE WDAT-REL-ANO TO WDATA-AA-CABEC */
            _.Move(W.FILLER_2.WDAT_REL_ANO, W.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -807- MOVE WDATA-CABEC TO LD01-DTCADAST. */
            _.Move(W.WDATA_CABEC, W.LD01.LD01_DTCADAST);

            /*" -808- MOVE V0RCOM-DATARCAP TO WDATA-REL */
            _.Move(V0RCOM_DATARCAP, W.WDATA_REL);

            /*" -809- MOVE WDAT-REL-DIA TO WDATA-DD-CABEC */
            _.Move(W.FILLER_2.WDAT_REL_DIA, W.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -810- MOVE WDAT-REL-MES TO WDATA-MM-CABEC */
            _.Move(W.FILLER_2.WDAT_REL_MES, W.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -811- MOVE WDAT-REL-ANO TO WDATA-AA-CABEC */
            _.Move(W.FILLER_2.WDAT_REL_ANO, W.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -814- MOVE WDATA-CABEC TO LD01-DATARCAP. */
            _.Move(W.WDATA_CABEC, W.LD01.LD01_DATARCAP);

            /*" -816- PERFORM R0550-00-CALCULA-DIAS. */

            R0550_00_CALCULA_DIAS_SECTION();

            /*" -819- MOVE LPARM03 TO LD01-QTDIAS. */
            _.Move(LPARM.LPARM03, W.LD01.LD01_QTDIAS);

            /*" -819- PERFORM R0600-00-SUMARIZA-PENDENTE. */

            R0600_00_SUMARIZA_PENDENTE_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0500_90_LEITURA */

            R0500_90_LEITURA();

        }

        [StopWatch]
        /*" R0500-90-LEITURA */
        private void R0500_90_LEITURA(bool isPerform = false)
        {
            /*" -824- PERFORM R0310-00-FETCH-V0RCAP. */

            R0310_00_FETCH_V0RCAP_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0550-00-CALCULA-DIAS-SECTION */
        private void R0550_00_CALCULA_DIAS_SECTION()
        {
            /*" -836- MOVE '0550' TO WNR-EXEC-SQL. */
            _.Move("0550", W.WABEND.WNR_EXEC_SQL);

            /*" -837- MOVE V0SIST-DTMOVABE TO WDATA-REL */
            _.Move(V0SIST_DTMOVABE, W.WDATA_REL);

            /*" -838- MOVE WDAT-REL-DIA TO LPARM01-DD */
            _.Move(W.FILLER_2.WDAT_REL_DIA, LPARM.LPARM01.LPARM01_DD);

            /*" -839- MOVE WDAT-REL-MES TO LPARM01-MM */
            _.Move(W.FILLER_2.WDAT_REL_MES, LPARM.LPARM01.LPARM01_MM);

            /*" -841- MOVE WDAT-REL-ANO TO LPARM01-AA. */
            _.Move(W.FILLER_2.WDAT_REL_ANO, LPARM.LPARM01.LPARM01_AA);

            /*" -842- MOVE V0RCOM-DATARCAP TO WDATA-REL */
            _.Move(V0RCOM_DATARCAP, W.WDATA_REL);

            /*" -843- MOVE WDAT-REL-DIA TO LPARM02-DD */
            _.Move(W.FILLER_2.WDAT_REL_DIA, LPARM.LPARM02.LPARM02_DD);

            /*" -844- MOVE WDAT-REL-MES TO LPARM02-MM */
            _.Move(W.FILLER_2.WDAT_REL_MES, LPARM.LPARM02.LPARM02_MM);

            /*" -846- MOVE WDAT-REL-ANO TO LPARM02-AA. */
            _.Move(W.FILLER_2.WDAT_REL_ANO, LPARM.LPARM02.LPARM02_AA);

            /*" -848- MOVE ZEROS TO LPARM03. */
            _.Move(0, LPARM.LPARM03);

            /*" -848- CALL 'PRODIFC1' USING LPARM. */
            _.Call("PRODIFC1", LPARM);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0550_99_SAIDA*/

        [StopWatch]
        /*" R0600-00-SUMARIZA-PENDENTE-SECTION */
        private void R0600_00_SUMARIZA_PENDENTE_SECTION()
        {
            /*" -861- MOVE '0600' TO WNR-EXEC-SQL. */
            _.Move("0600", W.WABEND.WNR_EXEC_SQL);

            /*" -865- IF V0RCAP-CODPRODU EQUAL 8101 OR 8203 OR 9311 OR JVPRD9311 */

            if (V0RCAP_CODPRODU.In("8101", "8203", "9311", JVBKINCL.JV_PRODUTOS.JVPRD9311.ToString()))
            {

                /*" -866- MOVE 8101 TO WS-PRODUTO */
                _.Move(8101, W.WS_PRODUTO);

                /*" -867- PERFORM R0650-00-SUMARIZA-VIDAZUL */

                R0650_00_SUMARIZA_VIDAZUL_SECTION();

                /*" -868- ELSE */
            }
            else
            {


                /*" -871- IF V0RCAP-CODPRODU EQUAL 9312 OR 9318 OR 9319 */

                if (V0RCAP_CODPRODU.In("9312", "9318", "9319"))
                {

                    /*" -872- MOVE 9312 TO WS-PRODUTO */
                    _.Move(9312, W.WS_PRODUTO);

                    /*" -873- PERFORM R0650-00-SUMARIZA-VIDAZUL */

                    R0650_00_SUMARIZA_VIDAZUL_SECTION();

                    /*" -874- ELSE */
                }
                else
                {


                    /*" -879- IF V0RCAP-CODPRODU EQUAL 9309 OR 9320 OR 9321 OR JVPRD9320 OR JVPRD9321 */

                    if (V0RCAP_CODPRODU.In("9309", "9320", "9321", JVBKINCL.JV_PRODUTOS.JVPRD9320.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9321.ToString()))
                    {

                        /*" -880- MOVE 9309 TO WS-PRODUTO */
                        _.Move(9309, W.WS_PRODUTO);

                        /*" -881- PERFORM R0650-00-SUMARIZA-VIDAZUL */

                        R0650_00_SUMARIZA_VIDAZUL_SECTION();

                        /*" -882- ELSE */
                    }
                    else
                    {


                        /*" -889- IF V0RCAP-CODPRODU EQUAL 9315 OR 9322 OR 9323 OR 9324 OR 9325 OR 9326 OR 9706 */

                        if (V0RCAP_CODPRODU.In("9315", "9322", "9323", "9324", "9325", "9326", "9706"))
                        {

                            /*" -890- MOVE 9315 TO WS-PRODUTO */
                            _.Move(9315, W.WS_PRODUTO);

                            /*" -891- PERFORM R0650-00-SUMARIZA-VIDAZUL */

                            R0650_00_SUMARIZA_VIDAZUL_SECTION();

                            /*" -892- ELSE */
                        }
                        else
                        {


                            /*" -896- IF V0RCAP-CODPRODU EQUAL 9327 OR 9328 OR JVPRD9327 OR JVPRD9328 */

                            if (V0RCAP_CODPRODU.In("9327", "9328", JVBKINCL.JV_PRODUTOS.JVPRD9327.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9328.ToString()))
                            {

                                /*" -897- MOVE 9327 TO WS-PRODUTO */
                                _.Move(9327, W.WS_PRODUTO);

                                /*" -898- PERFORM R0650-00-SUMARIZA-VIDAZUL */

                                R0650_00_SUMARIZA_VIDAZUL_SECTION();

                                /*" -899- ELSE */
                            }
                            else
                            {


                                /*" -902- IF V0RCAP-CODPRODU EQUAL 9703 OR 9314 OR JVPRD9314 */

                                if (V0RCAP_CODPRODU.In("9703", "9314", JVBKINCL.JV_PRODUTOS.JVPRD9314.ToString()))
                                {

                                    /*" -903- MOVE 9703 TO WS-PRODUTO */
                                    _.Move(9703, W.WS_PRODUTO);

                                    /*" -904- PERFORM R0650-00-SUMARIZA-VIDAZUL */

                                    R0650_00_SUMARIZA_VIDAZUL_SECTION();

                                    /*" -905- ELSE */
                                }
                                else
                                {


                                    /*" -907- IF V0RCAP-CODPRODU EQUAL 8201 OR 8202 */

                                    if (V0RCAP_CODPRODU.In("8201", "8202"))
                                    {

                                        /*" -908- MOVE 8202 TO WS-PRODUTO */
                                        _.Move(8202, W.WS_PRODUTO);

                                        /*" -909- PERFORM R0650-00-SUMARIZA-VIDAZUL */

                                        R0650_00_SUMARIZA_VIDAZUL_SECTION();

                                        /*" -910- ELSE */
                                    }
                                    else
                                    {


                                        /*" -911- IF V0RCAP-CODPRODU EQUAL 9300 */

                                        if (V0RCAP_CODPRODU == 9300)
                                        {

                                            /*" -912- MOVE 9300 TO WS-PRODUTO */
                                            _.Move(9300, W.WS_PRODUTO);

                                            /*" -913- PERFORM R0650-00-SUMARIZA-VIDAZUL */

                                            R0650_00_SUMARIZA_VIDAZUL_SECTION();

                                            /*" -914- ELSE */
                                        }
                                        else
                                        {


                                            /*" -915- IF V0RCAP-CODPRODU EQUAL 9705 */

                                            if (V0RCAP_CODPRODU == 9705)
                                            {

                                                /*" -916- MOVE 9705 TO WS-PRODUTO */
                                                _.Move(9705, W.WS_PRODUTO);

                                                /*" -917- PERFORM R0650-00-SUMARIZA-VIDAZUL */

                                                R0650_00_SUMARIZA_VIDAZUL_SECTION();

                                                /*" -918- ELSE */
                                            }
                                            else
                                            {


                                                /*" -919- IF V0RCAP-CODPRODU EQUAL 9707 */

                                                if (V0RCAP_CODPRODU == 9707)
                                                {

                                                    /*" -920- MOVE 9707 TO WS-PRODUTO */
                                                    _.Move(9707, W.WS_PRODUTO);

                                                    /*" -921- PERFORM R0650-00-SUMARIZA-VIDAZUL */

                                                    R0650_00_SUMARIZA_VIDAZUL_SECTION();

                                                    /*" -922- ELSE */
                                                }
                                                else
                                                {


                                                    /*" -923- IF V0RCAP-CODPRODU EQUAL ZEROS */

                                                    if (V0RCAP_CODPRODU == 00)
                                                    {

                                                        /*" -924- MOVE 7777 TO WS-PRODUTO */
                                                        _.Move(7777, W.WS_PRODUTO);

                                                        /*" -925- PERFORM R0660-00-SUMARIZA-OUTROS */

                                                        R0660_00_SUMARIZA_OUTROS_SECTION();

                                                        /*" -926- ELSE */
                                                    }
                                                    else
                                                    {


                                                        /*" -927- MOVE 6666 TO WS-PRODUTO */
                                                        _.Move(6666, W.WS_PRODUTO);

                                                        /*" -927- PERFORM R0660-00-SUMARIZA-OUTROS. */

                                                        R0660_00_SUMARIZA_OUTROS_SECTION();
                                                    }

                                                }

                                            }

                                        }

                                    }

                                }

                            }

                        }

                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/

        [StopWatch]
        /*" R0650-00-SUMARIZA-VIDAZUL-SECTION */
        private void R0650_00_SUMARIZA_VIDAZUL_SECTION()
        {
            /*" -940- MOVE '0650' TO WNR-EXEC-SQL. */
            _.Move("0650", W.WABEND.WNR_EXEC_SQL);

            /*" -941- SET WS-PRD TO 1 */
            WS_PRD.Value = 1;

            /*" -942- SEARCH WTPRD-OCORREPRD */
            for (; WS_PRD < WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD.Items.Count; WS_PRD.Value++)
            {

                /*" -944- WHEN WS-PRODUTO EQUAL WTPRD-CODPRODU(WS-PRD) */

                if (W.WS_PRODUTO == WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_CODPRODU)
                {


                    /*" -944- PERFORM R0700-00-ACUMULA  END-SEARCH. */

                    R0700_00_ACUMULA_SECTION();
                    break;
                }
            }


            /*" -949- MOVE 5555 TO WS-PRODUTO. */
            _.Move(5555, W.WS_PRODUTO);

            /*" -950- SET WS-PRD TO 1 */
            WS_PRD.Value = 1;

            /*" -951- SEARCH WTPRD-OCORREPRD */
            for (; WS_PRD < WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD.Items.Count; WS_PRD.Value++)
            {

                /*" -953- WHEN WS-PRODUTO EQUAL WTPRD-CODPRODU(WS-PRD) */

                if (W.WS_PRODUTO == WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_CODPRODU)
                {


                    /*" -953- PERFORM R0710-00-ACUMULA-TOTAL  END-SEARCH. */

                    R0710_00_ACUMULA_TOTAL_SECTION();
                    break;
                }
            }


            /*" -957- IF V0RCOM-DATARCAP GREATER WSHOST-DATA015 */

            if (V0RCOM_DATARCAP > WSHOST_DATA015)
            {

                /*" -958- ADD 1 TO DP-DATA */
                W.DP_DATA.Value = W.DP_DATA + 1;

                /*" -961- GO TO R0650-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0650_99_SAIDA*/ //GOTO
                return;
            }


            /*" -962- WRITE SAI-MOVTO FROM LD01. */
            _.Move(W.LD01.GetMoveValues(), SAI_MOVTO);

            MOVTO.Write(SAI_MOVTO.GetMoveValues().ToString());

            /*" -962- ADD 1 TO AC-GRAVA. */
            W.AC_GRAVA.Value = W.AC_GRAVA + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0650_99_SAIDA*/

        [StopWatch]
        /*" R0660-00-SUMARIZA-OUTROS-SECTION */
        private void R0660_00_SUMARIZA_OUTROS_SECTION()
        {
            /*" -975- MOVE '0660' TO WNR-EXEC-SQL. */
            _.Move("0660", W.WABEND.WNR_EXEC_SQL);

            /*" -976- SET WS-PRD TO 1 */
            WS_PRD.Value = 1;

            /*" -977- SEARCH WTPRD-OCORREPRD */
            for (; WS_PRD < WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD.Items.Count; WS_PRD.Value++)
            {

                /*" -979- WHEN WS-PRODUTO EQUAL WTPRD-CODPRODU(WS-PRD) */

                if (W.WS_PRODUTO == WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_CODPRODU)
                {


                    /*" -979- PERFORM R0710-00-ACUMULA-TOTAL  END-SEARCH. */

                    R0710_00_ACUMULA_TOTAL_SECTION();
                    break;
                }
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0660_99_SAIDA*/

        [StopWatch]
        /*" R0700-00-ACUMULA-SECTION */
        private void R0700_00_ACUMULA_SECTION()
        {
            /*" -992- MOVE '0700' TO WNR-EXEC-SQL. */
            _.Move("0700", W.WABEND.WNR_EXEC_SQL);

            /*" -993- IF V0RCOM-DATARCAP GREATER WSHOST-DATA015 */

            if (V0RCOM_DATARCAP > WSHOST_DATA015)
            {

                /*" -995- ADD 1 TO WTPRD-QTD015(WS-PRD) */
                WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_QTD015.Value = WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_QTD015 + 1;

                /*" -997- ADD V0RCOM-VLRCAP TO WTPRD-VLR015(WS-PRD) */
                WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_VLR015.Value = WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_VLR015 + V0RCOM_VLRCAP;

                /*" -998- ELSE */
            }
            else
            {


                /*" -999- IF V0RCOM-DATARCAP GREATER WSHOST-DATA365 */

                if (V0RCOM_DATARCAP > WSHOST_DATA365)
                {

                    /*" -1001- ADD 1 TO WTPRD-QTD365(WS-PRD) */
                    WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_QTD365.Value = WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_QTD365 + 1;

                    /*" -1003- ADD V0RCOM-VLRCAP TO WTPRD-VLR365(WS-PRD) */
                    WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_VLR365.Value = WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_VLR365 + V0RCOM_VLRCAP;

                    /*" -1004- ELSE */
                }
                else
                {


                    /*" -1006- ADD 1 TO WTPRD-QTD366(WS-PRD) */
                    WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_QTD366.Value = WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_QTD366 + 1;

                    /*" -1007- ADD V0RCOM-VLRCAP TO WTPRD-VLR366(WS-PRD). */
                    WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_VLR366.Value = WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_VLR366 + V0RCOM_VLRCAP;
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/

        [StopWatch]
        /*" R0710-00-ACUMULA-TOTAL-SECTION */
        private void R0710_00_ACUMULA_TOTAL_SECTION()
        {
            /*" -1020- MOVE '0710' TO WNR-EXEC-SQL. */
            _.Move("0710", W.WABEND.WNR_EXEC_SQL);

            /*" -1021- IF V0RCOM-DATARCAP GREATER WSHOST-DATA015 */

            if (V0RCOM_DATARCAP > WSHOST_DATA015)
            {

                /*" -1024- ADD 1 TO WTPRD-QTD015(WS-PRD) WTPRD-QTD015(20) */
                WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_QTD015.Value = WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_QTD015 + 1;
                WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[20].WTPRD_QTD015.Value = WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[20].WTPRD_QTD015 + 1;

                /*" -1027- ADD V0RCOM-VLRCAP TO WTPRD-VLR015(WS-PRD) WTPRD-VLR015(20) */
                WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_VLR015.Value = WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_VLR015 + V0RCOM_VLRCAP;
                WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[20].WTPRD_VLR015.Value = WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[20].WTPRD_VLR015 + V0RCOM_VLRCAP;

                /*" -1028- ELSE */
            }
            else
            {


                /*" -1029- IF V0RCOM-DATARCAP GREATER WSHOST-DATA365 */

                if (V0RCOM_DATARCAP > WSHOST_DATA365)
                {

                    /*" -1032- ADD 1 TO WTPRD-QTD365(WS-PRD) WTPRD-QTD365(20) */
                    WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_QTD365.Value = WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_QTD365 + 1;
                    WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[20].WTPRD_QTD365.Value = WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[20].WTPRD_QTD365 + 1;

                    /*" -1035- ADD V0RCOM-VLRCAP TO WTPRD-VLR365(WS-PRD) WTPRD-VLR365(20) */
                    WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_VLR365.Value = WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_VLR365 + V0RCOM_VLRCAP;
                    WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[20].WTPRD_VLR365.Value = WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[20].WTPRD_VLR365 + V0RCOM_VLRCAP;

                    /*" -1036- ELSE */
                }
                else
                {


                    /*" -1039- ADD 1 TO WTPRD-QTD366(WS-PRD) WTPRD-QTD366(20) */
                    WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_QTD366.Value = WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_QTD366 + 1;
                    WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[20].WTPRD_QTD366.Value = WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[20].WTPRD_QTD366 + 1;

                    /*" -1041- ADD V0RCOM-VLRCAP TO WTPRD-VLR366(WS-PRD) WTPRD-VLR366(20). */
                    WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_VLR366.Value = WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_VLR366 + V0RCOM_VLRCAP;
                    WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[20].WTPRD_VLR366.Value = WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[20].WTPRD_VLR366 + V0RCOM_VLRCAP;
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0710_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-IMPRIME-RESUMO-SECTION */
        private void R1000_00_IMPRIME_RESUMO_SECTION()
        {
            /*" -1054- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", W.WABEND.WNR_EXEC_SQL);

            /*" -1056- MOVE WTPRD-NOMEPRD(WS-PRD) TO LD04-PRODUTO. */
            _.Move(WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_NOMEPRD, W.LD04.LD04_PRODUTO);

            /*" -1058- MOVE WTPRD-QTD015(WS-PRD) TO LD04-QTD015. */
            _.Move(WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_QTD015, W.LD04.LD04_QTD015);

            /*" -1060- MOVE WTPRD-VLR015(WS-PRD) TO LD04-VLR015. */
            _.Move(WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_VLR015, W.LD04.LD04_VLR015);

            /*" -1062- MOVE WTPRD-QTD365(WS-PRD) TO LD04-QTD365. */
            _.Move(WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_QTD365, W.LD04.LD04_QTD365);

            /*" -1064- MOVE WTPRD-VLR365(WS-PRD) TO LD04-VLR365. */
            _.Move(WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_VLR365, W.LD04.LD04_VLR365);

            /*" -1066- MOVE WTPRD-QTD366(WS-PRD) TO LD04-QTD366. */
            _.Move(WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_QTD366, W.LD04.LD04_QTD366);

            /*" -1069- MOVE WTPRD-VLR366(WS-PRD) TO LD04-VLR366. */
            _.Move(WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_VLR366, W.LD04.LD04_VLR366);

            /*" -1072- MOVE ZEROS TO WS-QTDE WS-VALOR. */
            _.Move(0, W.WS_QTDE, W.WS_VALOR);

            /*" -1074- ADD WTPRD-QTD015(WS-PRD) TO WS-QTDE. */
            W.WS_QTDE.Value = W.WS_QTDE + WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_QTD015;

            /*" -1076- ADD WTPRD-QTD365(WS-PRD) TO WS-QTDE. */
            W.WS_QTDE.Value = W.WS_QTDE + WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_QTD365;

            /*" -1079- ADD WTPRD-QTD366(WS-PRD) TO WS-QTDE. */
            W.WS_QTDE.Value = W.WS_QTDE + WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_QTD366;

            /*" -1081- ADD WTPRD-VLR015(WS-PRD) TO WS-VALOR. */
            W.WS_VALOR.Value = W.WS_VALOR + WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_VLR015;

            /*" -1083- ADD WTPRD-VLR365(WS-PRD) TO WS-VALOR. */
            W.WS_VALOR.Value = W.WS_VALOR + WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_VLR365;

            /*" -1086- ADD WTPRD-VLR366(WS-PRD) TO WS-VALOR. */
            W.WS_VALOR.Value = W.WS_VALOR + WS_TABELAS.WTPRD_PRODUTO.WTPRD_OCORREPRD[WS_PRD].WTPRD_VLR366;

            /*" -1088- MOVE WS-QTDE TO LD04-QTDTOT. */
            _.Move(W.WS_QTDE, W.LD04.LD04_QTDTOT);

            /*" -1092- MOVE WS-VALOR TO LD04-VLRTOT. */
            _.Move(W.WS_VALOR, W.LD04.LD04_VLRTOT);

            /*" -1094- IF WS-QTDE NOT EQUAL ZEROS OR WS-VALOR NOT EQUAL ZEROS */

            if (W.WS_QTDE != 00 || W.WS_VALOR != 00)
            {

                /*" -1095- WRITE SAI-MOVTO1 FROM LD04 */
                _.Move(W.LD04.GetMoveValues(), SAI_MOVTO1);

                MOVTO1.Write(SAI_MOVTO1.GetMoveValues().ToString());

                /*" -1098- ADD 1 TO AC-GRAVA1. */
                W.AC_GRAVA1.Value = W.AC_GRAVA1 + 1;
            }


            /*" -1098- SET WS-PRD UP BY 1. */
            WS_PRD.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1109- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, W.WABEND.WSQLCODE);

            /*" -1110- MOVE SQLERRD(1) TO WSQLERRD1 */
            _.Move(DB.SQLERRD[1], W.WABEND.WSQLERRD1);

            /*" -1111- MOVE SQLERRD(2) TO WSQLERRD2 */
            _.Move(DB.SQLERRD[2], W.WABEND.WSQLERRD2);

            /*" -1113- DISPLAY WABEND. */
            _.Display(W.WABEND);

            /*" -1113- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1119- CLOSE MOVTO MOVTO1. */
            MOVTO.Close();
            MOVTO1.Close();

            /*" -1119- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}