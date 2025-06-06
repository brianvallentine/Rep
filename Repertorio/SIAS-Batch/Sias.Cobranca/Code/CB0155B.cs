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
using Sias.Cobranca.DB2.CB0155B;

namespace Code
{
    public class CB0155B
    {
        public bool IsCall { get; set; }

        public CB0155B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  COBRANCA                           *      */
        /*"      *   PROGRAMA ...............  CB0155B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  CLOVIS                             *      */
        /*"      *   PROGRAMADOR ............  CLOVIS                             *      */
        /*"      *   DATA CODIFICACAO .......  26/10/2005                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  GERA RELACAO DE AVISOS COM SALDO   *      */
        /*"      *                             PENDENTE.                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   ALTERACAO EM 24/10/2011.  CADMUS GEFIC 62337.                *      */
        /*"      *                             CLOVIS        V.01                 *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _CB0155B1 { get; set; } = new FileBasis(new PIC("X", "250", "X(250)"));

        public FileBasis CB0155B1
        {
            get
            {
                _.Move(REG_CB0155B1, _CB0155B1); VarBasis.RedefinePassValue(REG_CB0155B1, _CB0155B1, REG_CB0155B1); return _CB0155B1;
            }
        }
        public FileBasis _CB0155B2 { get; set; } = new FileBasis(new PIC("X", "150", "X(150)"));

        public FileBasis CB0155B2
        {
            get
            {
                _.Move(REG_CB0155B2, _CB0155B2); VarBasis.RedefinePassValue(REG_CB0155B2, _CB0155B2, REG_CB0155B2); return _CB0155B2;
            }
        }
        public FileBasis _CB0155B3 { get; set; } = new FileBasis(new PIC("X", "250", "X(250)"));

        public FileBasis CB0155B3
        {
            get
            {
                _.Move(REG_CB0155B3, _CB0155B3); VarBasis.RedefinePassValue(REG_CB0155B3, _CB0155B3, REG_CB0155B3); return _CB0155B3;
            }
        }
        public SortBasis<CB0155B_REG_ARQSORT> ARQSORT { get; set; } = new SortBasis<CB0155B_REG_ARQSORT>(new CB0155B_REG_ARQSORT());
        /*"01        REG-ARQSORT.*/
        public CB0155B_REG_ARQSORT REG_ARQSORT { get; set; } = new CB0155B_REG_ARQSORT();
        public class CB0155B_REG_ARQSORT : VarBasis
        {
            /*"  05      SOR-TIPOREG               PIC  9(002).*/
            public IntBasis SOR_TIPOREG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05      SOR-BCOAVISO              PIC  9(004).*/
            public IntBasis SOR_BCOAVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      SOR-AGEAVISO              PIC  9(004).*/
            public IntBasis SOR_AGEAVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      SOR-NRAVISO               PIC  9(009).*/
            public IntBasis SOR_NRAVISO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05      SOR-NRSEQ                 PIC  9(004).*/
            public IntBasis SOR_NRSEQ { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      SOR-ORIGEM                PIC  9(004).*/
            public IntBasis SOR_ORIGEM { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      SOR-TIPOAVI               PIC  X(001).*/
            public StringBasis SOR_TIPOAVI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      SOR-DTMOVTO               PIC  X(010).*/
            public StringBasis SOR_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05      SOR-DTAVISO               PIC  X(010).*/
            public StringBasis SOR_DTAVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05      SOR-VLPRMTOT              PIC S9(013)V99.*/
            public DoubleBasis SOR_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99."), 2);
            /*"  05      SOR-VLDESPES              PIC S9(013)V99.*/
            public DoubleBasis SOR_VLDESPES { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99."), 2);
            /*"  05      SOR-VLPRMLIQ              PIC S9(013)V99.*/
            public DoubleBasis SOR_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99."), 2);
            /*"  05      SOR-SDOATU                PIC S9(013)V99.*/
            public DoubleBasis SOR_SDOATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99."), 2);
            /*"  05      SOR-SITUACAO              PIC  X(001).*/
            public StringBasis SOR_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      SOR-VLFOLLOW              PIC S9(013)V99.*/
            public DoubleBasis SOR_VLFOLLOW { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99."), 2);
            /*"  05      SOR-VLRCAP                PIC S9(013)V99.*/
            public DoubleBasis SOR_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99."), 2);
            /*"  05      SOR-VLDEMAIS              PIC S9(013)V99.*/
            public DoubleBasis SOR_VLDEMAIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99."), 2);
            /*"01        REG-CB0155B1              PIC  X(250).*/
        }
        public StringBasis REG_CB0155B1 { get; set; } = new StringBasis(new PIC("X", "250", "X(250)."), @"");
        /*"01        REG-CB0155B2              PIC  X(150).*/
        public StringBasis REG_CB0155B2 { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");
        /*"01        REG-CB0155B3              PIC  X(250).*/
        public StringBasis REG_CB0155B3 { get; set; } = new StringBasis(new PIC("X", "250", "X(250)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77    VIND-ORIGEM               PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_ORIGEM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NRTIT                PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_NRTIT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-CODPRODU             PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-AGECOBR              PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NRCERTIF             PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  W.*/
        public CB0155B_W W { get; set; } = new CB0155B_W();
        public class CB0155B_W : VarBasis
        {
            /*"  03  WFIM-MOVIMENTO            PIC  X(001)         VALUE SPACES*/
            public StringBasis WFIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WFIM-SORT                 PIC  X(001)         VALUE SPACES*/
            public StringBasis WFIM_SORT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WTEM-REGISTRO             PIC  X(001)         VALUE SPACES*/
            public StringBasis WTEM_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  LD-AVISOCRE               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis LD_AVISOCRE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  GV-AVISOCRE               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis GV_AVISOCRE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  LD-RCAP                   PIC  9(007)         VALUE ZEROS.*/
            public IntBasis LD_RCAP { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  GV-RCAP                   PIC  9(007)         VALUE ZEROS.*/
            public IntBasis GV_RCAP { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  LD-FOLLOW                 PIC  9(007)         VALUE ZEROS.*/
            public IntBasis LD_FOLLOW { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  GV-FOLLOW                 PIC  9(007)         VALUE ZEROS.*/
            public IntBasis GV_FOLLOW { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  LD-MOVICOB                PIC  9(007)         VALUE ZEROS.*/
            public IntBasis LD_MOVICOB { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  GV-MOVICOB                PIC  9(007)         VALUE ZEROS.*/
            public IntBasis GV_MOVICOB { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  GV-SORT                   PIC  9(007)         VALUE ZEROS.*/
            public IntBasis GV_SORT { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  LD-SORT                   PIC  9(007)         VALUE ZEROS.*/
            public IntBasis LD_SORT { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  GV-ARQSAI1                PIC  9(007)         VALUE ZEROS.*/
            public IntBasis GV_ARQSAI1 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  GV-ARQSAI2                PIC  9(007)         VALUE ZEROS.*/
            public IntBasis GV_ARQSAI2 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  GV-ARQSAI3                PIC  9(007)         VALUE ZEROS.*/
            public IntBasis GV_ARQSAI3 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  OR-SDOATU                 PIC S9(013)V99      VALUE ZEROS.*/
            public DoubleBasis OR_SDOATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  OR-SDOTOT                 PIC S9(013)V99      VALUE ZEROS.*/
            public DoubleBasis OR_SDOTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  OR-VLFOLLOW               PIC S9(013)V99      VALUE ZEROS.*/
            public DoubleBasis OR_VLFOLLOW { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  OR-VLRCAP                 PIC S9(013)V99      VALUE ZEROS.*/
            public DoubleBasis OR_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  OR-VLDEMAIS               PIC S9(013)V99      VALUE ZEROS.*/
            public DoubleBasis OR_VLDEMAIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  OR-VLONLINE               PIC S9(013)V99      VALUE ZEROS.*/
            public DoubleBasis OR_VLONLINE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  GE-SDOATU                 PIC S9(013)V99      VALUE ZEROS.*/
            public DoubleBasis GE_SDOATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  GE-SDOTOT                 PIC S9(013)V99      VALUE ZEROS.*/
            public DoubleBasis GE_SDOTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  GE-VLFOLLOW               PIC S9(013)V99      VALUE ZEROS.*/
            public DoubleBasis GE_VLFOLLOW { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  GE-VLRCAP                 PIC S9(013)V99      VALUE ZEROS.*/
            public DoubleBasis GE_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  GE-VLDEMAIS               PIC S9(013)V99      VALUE ZEROS.*/
            public DoubleBasis GE_VLDEMAIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  GE-VLONLINE               PIC S9(013)V99      VALUE ZEROS.*/
            public DoubleBasis GE_VLONLINE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  WS-SDOATU                 PIC S9(013)V99      VALUE ZEROS.*/
            public DoubleBasis WS_SDOATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  WS-VLFOLLOW               PIC S9(013)V99      VALUE ZEROS.*/
            public DoubleBasis WS_VLFOLLOW { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  WS-VLRCAP                 PIC S9(013)V99      VALUE ZEROS.*/
            public DoubleBasis WS_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  WS-VLDEMAIS               PIC S9(013)V99      VALUE ZEROS.*/
            public DoubleBasis WS_VLDEMAIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  WS-VALOR                  PIC S9(013)V99      VALUE ZEROS.*/
            public DoubleBasis WS_VALOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  WS-VLPRMTOT               PIC S9(013)V99      VALUE ZEROS.*/
            public DoubleBasis WS_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  WS-SDOFINAL               PIC S9(013)V99      VALUE ZEROS.*/
            public DoubleBasis WS_SDOFINAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03         WS-CHAVE-ATU.*/
            public CB0155B_WS_CHAVE_ATU WS_CHAVE_ATU { get; set; } = new CB0155B_WS_CHAVE_ATU();
            public class CB0155B_WS_CHAVE_ATU : VarBasis
            {
                /*"    05       ATU-ORIGEM          PIC  9(004).*/
                public IntBasis ATU_ORIGEM { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05       ATU-BCOAVISO        PIC  9(004).*/
                public IntBasis ATU_BCOAVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05       ATU-AGEAVISO        PIC  9(004).*/
                public IntBasis ATU_AGEAVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05       ATU-NRAVISO         PIC  9(009).*/
                public IntBasis ATU_NRAVISO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    05       ATU-NRSEQ           PIC  9(004).*/
                public IntBasis ATU_NRSEQ { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  03         WS-CHAVE-ANT.*/
            }
            public CB0155B_WS_CHAVE_ANT WS_CHAVE_ANT { get; set; } = new CB0155B_WS_CHAVE_ANT();
            public class CB0155B_WS_CHAVE_ANT : VarBasis
            {
                /*"    05       ANT-ORIGEM          PIC  9(004).*/
                public IntBasis ANT_ORIGEM { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05       ANT-BCOAVISO        PIC  9(004).*/
                public IntBasis ANT_BCOAVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05       ANT-AGEAVISO        PIC  9(004).*/
                public IntBasis ANT_AGEAVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05       ANT-NRAVISO         PIC  9(009).*/
                public IntBasis ANT_NRAVISO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    05       ANT-NRSEQ           PIC  9(004).*/
                public IntBasis ANT_NRSEQ { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  03         WDATA-REL         PIC  X(010)    VALUE SPACES.*/
            }
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03         FILLER            REDEFINES      WDATA-REL.*/
            private _REDEF_CB0155B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_CB0155B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_CB0155B_FILLER_0(); _.Move(WDATA_REL, _filler_0); VarBasis.RedefinePassValue(WDATA_REL, _filler_0, WDATA_REL); _filler_0.ValueChanged += () => { _.Move(_filler_0, WDATA_REL); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WDATA_REL); }
            }  //Redefines
            public class _REDEF_CB0155B_FILLER_0 : VarBasis
            {
                /*"    10       WDAT-REL-ANO      PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-MES      PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-DIA      PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WDATA-CABEC.*/

                public _REDEF_CB0155B_FILLER_0()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public CB0155B_WDATA_CABEC WDATA_CABEC { get; set; } = new CB0155B_WDATA_CABEC();
            public class CB0155B_WDATA_CABEC : VarBasis
            {
                /*"    05       WDATA-DD-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05       WDATA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05       WDATA-AA-CABEC    PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  03         WHORA-CABEC.*/
            }
            public CB0155B_WHORA_CABEC WHORA_CABEC { get; set; } = new CB0155B_WHORA_CABEC();
            public class CB0155B_WHORA_CABEC : VarBasis
            {
                /*"    05       WHORA-HH-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_HH_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05       FILLER            PIC  X(001)    VALUE ':'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"    05       WHORA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05       FILLER            PIC  X(001)    VALUE ':'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"    05       WHORA-SS-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_SS_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  03         WTIME-DAY          PIC  99.99.99.99.*/
            }
            public IntBasis WTIME_DAY { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
            /*"  03         FILLER             REDEFINES      WTIME-DAY.*/
            private _REDEF_CB0155B_FILLER_7 _filler_7 { get; set; }
            public _REDEF_CB0155B_FILLER_7 FILLER_7
            {
                get { _filler_7 = new _REDEF_CB0155B_FILLER_7(); _.Move(WTIME_DAY, _filler_7); VarBasis.RedefinePassValue(WTIME_DAY, _filler_7, WTIME_DAY); _filler_7.ValueChanged += () => { _.Move(_filler_7, WTIME_DAY); }; return _filler_7; }
                set { VarBasis.RedefinePassValue(value, _filler_7, WTIME_DAY); }
            }  //Redefines
            public class _REDEF_CB0155B_FILLER_7 : VarBasis
            {
                /*"    05       WTIME-DAYR.*/
                public CB0155B_WTIME_DAYR WTIME_DAYR { get; set; } = new CB0155B_WTIME_DAYR();
                public class CB0155B_WTIME_DAYR : VarBasis
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

                    public CB0155B_WTIME_DAYR()
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

                public _REDEF_CB0155B_FILLER_7()
                {
                    WTIME_DAYR.ValueChanged += OnValueChanged;
                    WTIME_2PT3.ValueChanged += OnValueChanged;
                    WTIME_CCSE.ValueChanged += OnValueChanged;
                }

            }
            public CB0155B_WS_TIME WS_TIME { get; set; } = new CB0155B_WS_TIME();
            public class CB0155B_WS_TIME : VarBasis
            {
                /*"      10     WS-HH-TIME         PIC  9(002).*/
                public IntBasis WS_HH_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-MM-TIME         PIC  9(002).*/
                public IntBasis WS_MM_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-SS-TIME         PIC  9(002).*/
                public IntBasis WS_SS_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-CC-TIME         PIC  9(002).*/
                public IntBasis WS_CC_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03          LC01.*/
            }
            public CB0155B_LC01 LC01 { get; set; } = new CB0155B_LC01();
            public class CB0155B_LC01 : VarBasis
            {
                /*"    10        FILLER              PIC  X(010)  VALUE             'CB0155B - '.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"CB0155B - ");
                /*"    10        FILLER              PIC  X(040)  VALUE             'RELACAO DE AVISOS E DEPOSITOS COM SALDO '.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"RELACAO DE AVISOS E DEPOSITOS COM SALDO ");
                /*"    10        FILLER              PIC  X(012)  VALUE             'PENDENTE EM '.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PENDENTE EM ");
                /*"    10        LC01-DTMOVTO        PIC  X(010).*/
                public StringBasis LC01_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"  03          LC02.*/
            }
            public CB0155B_LC02 LC02 { get; set; } = new CB0155B_LC02();
            public class CB0155B_LC02 : VarBasis
            {
                /*"    10        FILLER              PIC  X(027)  VALUE             'ORIGEM DO AVISO'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "27", "X(027)"), @"ORIGEM DO AVISO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ; '.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
                /*"    10        FILLER              PIC  X(019)  VALUE             'NUMERO DO AVISO'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"NUMERO DO AVISO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ; '.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
                /*"    10        FILLER              PIC  X(010)  VALUE             'TIPO'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"TIPO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ; '.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
                /*"    10        FILLER              PIC  X(010)  VALUE             'CADASTRO'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"CADASTRO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ; '.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
                /*"    10        FILLER              PIC  X(010)  VALUE             'OCORRENCIA'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"OCORRENCIA");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ; '.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
                /*"    10        FILLER              PIC  X(015)  VALUE             'BRUTO'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"BRUTO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ; '.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
                /*"    10        FILLER              PIC  X(015)  VALUE             'DESPESAS'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"DESPESAS");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ; '.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
                /*"    10        FILLER              PIC  X(015)  VALUE             'LIQUIDO'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"LIQUIDO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ; '.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
                /*"    10        FILLER              PIC  X(015)  VALUE             'SALDO DO AVISO'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"SALDO DO AVISO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ; '.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
                /*"    10        FILLER              PIC  X(015)  VALUE             'FOLLOWUP'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"FOLLOWUP");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ; '.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
                /*"    10        FILLER              PIC  X(015)  VALUE             'R.C.A.P.'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"R.C.A.P.");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ; '.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
                /*"    10        FILLER              PIC  X(015)  VALUE             'DEMAIS'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"DEMAIS");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ; '.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
                /*"    10        FILLER              PIC  X(010)  VALUE             'SITUACAO'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"SITUACAO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ; '.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
                /*"    10        FILLER              PIC  X(020)  VALUE             'SALDO ATUAL'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"SALDO ATUAL");
                /*"  03          LC03.*/
            }
            public CB0155B_LC03 LC03 { get; set; } = new CB0155B_LC03();
            public class CB0155B_LC03 : VarBasis
            {
                /*"    10        FILLER              PIC  X(027)  VALUE             'ORIGEM DO AVISO'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "27", "X(027)"), @"ORIGEM DO AVISO");
                /*"    10        FILLER              PIC  X(004)  VALUE ' ; '.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @" ; ");
                /*"    10        FILLER              PIC  X(014)  VALUE             'SALDO DO AVISO'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"SALDO DO AVISO");
                /*"    10        FILLER              PIC  X(005)  VALUE ' ; '.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @" ; ");
                /*"    10        FILLER              PIC  X(013)  VALUE             'SALDO A+B+C+D'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"SALDO A+B+C+D");
                /*"    10        FILLER              PIC  X(006)  VALUE ' ; '.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @" ; ");
                /*"    10        FILLER              PIC  X(012)  VALUE             'A = FOLLOWUP'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"A = FOLLOWUP");
                /*"    10        FILLER              PIC  X(006)  VALUE ' ; '.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @" ; ");
                /*"    10        FILLER              PIC  X(012)  VALUE             'B = R.C.A.P.'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"B = R.C.A.P.");
                /*"    10        FILLER              PIC  X(007)  VALUE ' ; '.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @" ; ");
                /*"    10        FILLER              PIC  X(011)  VALUE             'C = MOVICOB'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"C = MOVICOB");
                /*"    10        FILLER              PIC  X(007)  VALUE ' ; '.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @" ; ");
                /*"    10        FILLER              PIC  X(011)  VALUE             'D = ON-LINE'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"D = ON-LINE");
                /*"    10        FILLER              PIC  X(015).*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                /*"  03          LC04.*/
            }
            public CB0155B_LC04 LC04 { get; set; } = new CB0155B_LC04();
            public class CB0155B_LC04 : VarBasis
            {
                /*"    10        FILLER              PIC  X(010)  VALUE             'CB0155B - '.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"CB0155B - ");
                /*"    10        FILLER              PIC  X(044)  VALUE             'RELACAO DE DOCUMENTOS COM SALDO PENDENTE EM '.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "44", "X(044)"), @"RELACAO DE DOCUMENTOS COM SALDO PENDENTE EM ");
                /*"    10        LC04-DTMOVTO        PIC  X(010).*/
                public StringBasis LC04_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"  03          LC05.*/
            }
            public CB0155B_LC05 LC05 { get; set; } = new CB0155B_LC05();
            public class CB0155B_LC05 : VarBasis
            {
                /*"    10        FILLER              PIC  X(010)  VALUE             'BASE'.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"BASE");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ; '.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
                /*"    10        FILLER              PIC  X(019)  VALUE             'NUMERO DO AVISO'.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"NUMERO DO AVISO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ; '.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
                /*"    10        FILLER              PIC  X(010)  VALUE             'CADASTRO'.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"CADASTRO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ; '.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
                /*"    10        FILLER              PIC  X(010)  VALUE             'QUITACAO'.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"QUITACAO");
                /*"    10        FILLER              PIC  X(004)  VALUE ' ; '.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @" ; ");
                /*"    10        FILLER              PIC  X(004)  VALUE             'DIAS'.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"DIAS");
                /*"    10        FILLER              PIC  X(013)  VALUE ' ; '.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" ; ");
                /*"    10        FILLER              PIC  X(005)  VALUE             'VALOR'.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"VALOR");
                /*"    10        FILLER              PIC  X(011)  VALUE ' ; '.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @" ; ");
                /*"    10        FILLER              PIC  X(008)  VALUE             'PROPOSTA'.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"PROPOSTA");
                /*"    10        FILLER              PIC  X(008)  VALUE ' ; '.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @" ; ");
                /*"    10        FILLER              PIC  X(006)  VALUE             'TITULO'.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"TITULO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ; '.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
                /*"    10        FILLER              PIC  X(011)  VALUE             'COMPLEMENTO'.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"COMPLEMENTO");
                /*"    10        FILLER              PIC  X(009)  VALUE ' ; '.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" ; ");
                /*"    10        FILLER              PIC  X(007)  VALUE             'APOLICE'.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"APOLICE");
                /*"    10        FILLER              PIC  X(005)  VALUE ' ; '.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @" ; ");
                /*"    10        FILLER              PIC  X(007)  VALUE             'ENDOSSO'.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"ENDOSSO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ; '.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
                /*"    10        FILLER              PIC  X(007)  VALUE             'PARCELA'.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"PARCELA");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ; '.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
                /*"    10        FILLER              PIC  X(007)  VALUE             'PRODUTO'.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"PRODUTO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ; '.*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
                /*"    10        FILLER              PIC  X(007)  VALUE             'AGENCIA'.*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"AGENCIA");
                /*"  03          LD01.*/
            }
            public CB0155B_LD01 LD01 { get; set; } = new CB0155B_LD01();
            public class CB0155B_LD01 : VarBasis
            {
                /*"    10        LD01-ORIGEM         PIC  9(004).*/
                public IntBasis LD01_ORIGEM { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        FILLER              PIC  X(003).*/
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"    10        LD01-DESCORIGEM     PIC  X(020).*/
                public StringBasis LD01_DESCORIGEM { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"    10        FILLER              PIC  X(003).*/
                public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"    10        LD01-BCOAVISO       PIC  9(004).*/
                public IntBasis LD01_BCOAVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        FILLER              PIC  X(001).*/
                public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        LD01-AGEAVISO       PIC  9(004).*/
                public IntBasis LD01_AGEAVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        FILLER              PIC  X(001).*/
                public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        LD01-NRAVISO        PIC  9(009).*/
                public IntBasis LD01_NRAVISO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10        FILLER              PIC  X(003).*/
                public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"    10        LD01-TIPOAVI        PIC  X(010).*/
                public StringBasis LD01_TIPOAVI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER              PIC  X(003).*/
                public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"    10        LD01-DTMOVTO        PIC  X(010).*/
                public StringBasis LD01_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER              PIC  X(003).*/
                public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"    10        LD01-DTAVISO        PIC  X(010).*/
                public StringBasis LD01_DTAVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER              PIC  X(003).*/
                public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"    10        LD01-VLPRMTOT       PIC  ----.---.--9,99.*/
                public DoubleBasis LD01_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("9", "10", "----.---.--9V99."), 2);
                /*"    10        FILLER              PIC  X(003).*/
                public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"    10        LD01-VLDESPES       PIC  ----.---.--9,99.*/
                public DoubleBasis LD01_VLDESPES { get; set; } = new DoubleBasis(new PIC("9", "10", "----.---.--9V99."), 2);
                /*"    10        FILLER              PIC  X(003).*/
                public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"    10        LD01-VLPRMLIQ       PIC  ----.---.--9,99.*/
                public DoubleBasis LD01_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("9", "10", "----.---.--9V99."), 2);
                /*"    10        FILLER              PIC  X(003).*/
                public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"    10        LD01-SDOATU         PIC  ----.---.--9,99.*/
                public DoubleBasis LD01_SDOATU { get; set; } = new DoubleBasis(new PIC("9", "10", "----.---.--9V99."), 2);
                /*"    10        FILLER              PIC  X(003).*/
                public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"    10        LD01-VLFOLLOW       PIC  ----.---.--9,99.*/
                public DoubleBasis LD01_VLFOLLOW { get; set; } = new DoubleBasis(new PIC("9", "10", "----.---.--9V99."), 2);
                /*"    10        FILLER              PIC  X(003).*/
                public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"    10        LD01-VLRCAP         PIC  ----.---.--9,99.*/
                public DoubleBasis LD01_VLRCAP { get; set; } = new DoubleBasis(new PIC("9", "10", "----.---.--9V99."), 2);
                /*"    10        FILLER              PIC  X(003).*/
                public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"    10        LD01-VLDEMAIS       PIC  ----.---.--9,99.*/
                public DoubleBasis LD01_VLDEMAIS { get; set; } = new DoubleBasis(new PIC("9", "10", "----.---.--9V99."), 2);
                /*"    10        FILLER              PIC  X(003)  VALUE ' ; '.*/
                public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
                /*"    10        LD01-SITUACAO       PIC  X(010).*/
                public StringBasis LD01_SITUACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER              PIC  X(003).*/
                public StringBasis FILLER_96 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"    10        LD01-SDOFINAL       PIC  ----.---.--9,99.*/
                public DoubleBasis LD01_SDOFINAL { get; set; } = new DoubleBasis(new PIC("9", "10", "----.---.--9V99."), 2);
                /*"    10        FILLER              PIC  X(005).*/
                public StringBasis FILLER_97 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                /*"  03          LD02.*/
            }
            public CB0155B_LD02 LD02 { get; set; } = new CB0155B_LD02();
            public class CB0155B_LD02 : VarBasis
            {
                /*"    10        FILLER              PIC  X(004)  VALUE SPACES.*/
                public StringBasis FILLER_98 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' - '.*/
                public StringBasis FILLER_99 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" - ");
                /*"    10        FILLER              PIC  X(020)  VALUE SPACES.*/
                public StringBasis FILLER_100 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ; '.*/
                public StringBasis FILLER_101 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
                /*"    10        FILLER              PIC  X(004)  VALUE SPACES.*/
                public StringBasis FILLER_102 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10        FILLER              PIC  X(001)  VALUE '/'.*/
                public StringBasis FILLER_103 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10        FILLER              PIC  X(004)  VALUE SPACES.*/
                public StringBasis FILLER_104 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10        FILLER              PIC  X(001)  VALUE '/'.*/
                public StringBasis FILLER_105 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10        FILLER              PIC  X(009)  VALUE SPACES.*/
                public StringBasis FILLER_106 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ; '.*/
                public StringBasis FILLER_107 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
                /*"    10        FILLER              PIC  X(010)  VALUE SPACES.*/
                public StringBasis FILLER_108 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ; '.*/
                public StringBasis FILLER_109 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
                /*"    10        FILLER              PIC  X(010)  VALUE SPACES.*/
                public StringBasis FILLER_110 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ; '.*/
                public StringBasis FILLER_111 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
                /*"    10        FILLER              PIC  X(010)  VALUE SPACES.*/
                public StringBasis FILLER_112 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ; '.*/
                public StringBasis FILLER_113 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
                /*"    10        FILLER              PIC  X(015)  VALUE SPACES.*/
                public StringBasis FILLER_114 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ; '.*/
                public StringBasis FILLER_115 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
                /*"    10        FILLER              PIC  X(015)  VALUE SPACES.*/
                public StringBasis FILLER_116 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ; '.*/
                public StringBasis FILLER_117 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
                /*"    10        FILLER              PIC  X(015)  VALUE SPACES.*/
                public StringBasis FILLER_118 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ; '.*/
                public StringBasis FILLER_119 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
                /*"    10        FILLER              PIC  X(015)  VALUE SPACES.*/
                public StringBasis FILLER_120 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ; '.*/
                public StringBasis FILLER_121 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
                /*"    10        FILLER              PIC  X(015)  VALUE SPACES.*/
                public StringBasis FILLER_122 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ; '.*/
                public StringBasis FILLER_123 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
                /*"    10        FILLER              PIC  X(015)  VALUE SPACES.*/
                public StringBasis FILLER_124 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ; '.*/
                public StringBasis FILLER_125 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
                /*"    10        FILLER              PIC  X(015)  VALUE SPACES.*/
                public StringBasis FILLER_126 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ; '.*/
                public StringBasis FILLER_127 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
                /*"    10        FILLER              PIC  X(010)  VALUE SPACES.*/
                public StringBasis FILLER_128 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ; '.*/
                public StringBasis FILLER_129 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
                /*"    10        FILLER              PIC  X(015)  VALUE SPACES.*/
                public StringBasis FILLER_130 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"    10        FILLER              PIC  X(005)  VALUE SPACES.*/
                public StringBasis FILLER_131 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"  03          LD03.*/
            }
            public CB0155B_LD03 LD03 { get; set; } = new CB0155B_LD03();
            public class CB0155B_LD03 : VarBasis
            {
                /*"    10        LD03-BASE           PIC  X(010).*/
                public StringBasis LD03_BASE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ; '.*/
                public StringBasis FILLER_132 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
                /*"    10        LD03-BCOAVISO       PIC  9(004).*/
                public IntBasis LD03_BCOAVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        FILLER              PIC  X(001)  VALUE '/'.*/
                public StringBasis FILLER_133 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10        LD03-AGEAVISO       PIC  9(004).*/
                public IntBasis LD03_AGEAVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        FILLER              PIC  X(001)  VALUE '/'.*/
                public StringBasis FILLER_134 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10        LD03-NRAVISO        PIC  9(009).*/
                public IntBasis LD03_NRAVISO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ; '.*/
                public StringBasis FILLER_135 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
                /*"    10        LD03-DTMOVTO        PIC  X(010).*/
                public StringBasis LD03_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ; '.*/
                public StringBasis FILLER_136 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
                /*"    10        LD03-DTQITBCO       PIC  X(010).*/
                public StringBasis LD03_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ; '.*/
                public StringBasis FILLER_137 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
                /*"    10        LD03-QTDIAS         PIC  ZZZZ9.*/
                public IntBasis LD03_QTDIAS { get; set; } = new IntBasis(new PIC("9", "5", "ZZZZ9."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ; '.*/
                public StringBasis FILLER_138 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
                /*"    10        LD03-VLPREMIO       PIC  ----.---.--9,99.*/
                public DoubleBasis LD03_VLPREMIO { get; set; } = new DoubleBasis(new PIC("9", "10", "----.---.--9V99."), 2);
                /*"    10        FILLER              PIC  X(003)  VALUE ' ; '.*/
                public StringBasis FILLER_139 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
                /*"    10        LD03-PROPOSTA       PIC  ZZZZZZZZZZZZZZZ9.*/
                public IntBasis LD03_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "16", "ZZZZZZZZZZZZZZZ9."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ; '.*/
                public StringBasis FILLER_140 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
                /*"    10        LD03-TITULO         PIC  ZZZZZZZZZZ9.*/
                public IntBasis LD03_TITULO { get; set; } = new IntBasis(new PIC("9", "11", "ZZZZZZZZZZ9."));
                /*"    10        FILLER              PIC  X(005)  VALUE ' ; '.*/
                public StringBasis FILLER_141 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @" ; ");
                /*"    10        LD03-NRRCAPCO       PIC  ZZZZZZZZ9.*/
                public IntBasis LD03_NRRCAPCO { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZZZZ9."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ; '.*/
                public StringBasis FILLER_142 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
                /*"    10        LD03-APOLICE        PIC  ZZZZZZZZZZZZ9.*/
                public IntBasis LD03_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "ZZZZZZZZZZZZ9."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ; '.*/
                public StringBasis FILLER_143 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
                /*"    10        LD03-ENDOSSO        PIC  ZZZZZZZZ9.*/
                public IntBasis LD03_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZZZZ9."));
                /*"    10        FILLER              PIC  X(005)  VALUE ' ; '.*/
                public StringBasis FILLER_144 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @" ; ");
                /*"    10        LD03-PARCELA        PIC  ZZZZ9.*/
                public IntBasis LD03_PARCELA { get; set; } = new IntBasis(new PIC("9", "5", "ZZZZ9."));
                /*"    10        FILLER              PIC  X(005)  VALUE ' ; '.*/
                public StringBasis FILLER_145 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @" ; ");
                /*"    10        LD03-PRODUTO        PIC  ZZZZ9.*/
                public IntBasis LD03_PRODUTO { get; set; } = new IntBasis(new PIC("9", "5", "ZZZZ9."));
                /*"    10        FILLER              PIC  X(005)  VALUE ' ; '.*/
                public StringBasis FILLER_146 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @" ; ");
                /*"    10        LD03-AGENCIA        PIC  ZZZZ9.*/
                public IntBasis LD03_AGENCIA { get; set; } = new IntBasis(new PIC("9", "5", "ZZZZ9."));
                /*"  03          LT01.*/
            }
            public CB0155B_LT01 LT01 { get; set; } = new CB0155B_LT01();
            public class CB0155B_LT01 : VarBasis
            {
                /*"    10        LT01-ORIGEM         PIC  9(004).*/
                public IntBasis LT01_ORIGEM { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        FILLER              PIC  X(003).*/
                public StringBasis FILLER_147 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"    10        LT01-DESCORIGEM     PIC  X(020).*/
                public StringBasis LT01_DESCORIGEM { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"    10        FILLER              PIC  X(003).*/
                public StringBasis FILLER_148 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"    10        LT01-SDOATU         PIC  ----.---.--9,99.*/
                public DoubleBasis LT01_SDOATU { get; set; } = new DoubleBasis(new PIC("9", "10", "----.---.--9V99."), 2);
                /*"    10        FILLER              PIC  X(003).*/
                public StringBasis FILLER_149 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"    10        LT01-SDOTOT         PIC  ----.---.--9,99.*/
                public DoubleBasis LT01_SDOTOT { get; set; } = new DoubleBasis(new PIC("9", "10", "----.---.--9V99."), 2);
                /*"    10        FILLER              PIC  X(003).*/
                public StringBasis FILLER_150 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"    10        LT01-VLFOLLOW       PIC  ----.---.--9,99.*/
                public DoubleBasis LT01_VLFOLLOW { get; set; } = new DoubleBasis(new PIC("9", "10", "----.---.--9V99."), 2);
                /*"    10        FILLER              PIC  X(003).*/
                public StringBasis FILLER_151 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"    10        LT01-VLRCAP         PIC  ----.---.--9,99.*/
                public DoubleBasis LT01_VLRCAP { get; set; } = new DoubleBasis(new PIC("9", "10", "----.---.--9V99."), 2);
                /*"    10        FILLER              PIC  X(003).*/
                public StringBasis FILLER_152 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"    10        LT01-VLDEMAIS       PIC  ----.---.--9,99.*/
                public DoubleBasis LT01_VLDEMAIS { get; set; } = new DoubleBasis(new PIC("9", "10", "----.---.--9V99."), 2);
                /*"    10        FILLER              PIC  X(003).*/
                public StringBasis FILLER_153 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"    10        LT01-VLONLINE       PIC  ----.---.--9,99.*/
                public DoubleBasis LT01_VLONLINE { get; set; } = new DoubleBasis(new PIC("9", "10", "----.---.--9V99."), 2);
                /*"    10        FILLER              PIC  X(015).*/
                public StringBasis FILLER_154 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                /*"  03          LT02.*/
            }
            public CB0155B_LT02 LT02 { get; set; } = new CB0155B_LT02();
            public class CB0155B_LT02 : VarBasis
            {
                /*"    10        FILLER              PIC  X(004)  VALUE SPACES.*/
                public StringBasis FILLER_155 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' - '.*/
                public StringBasis FILLER_156 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" - ");
                /*"    10        FILLER              PIC  X(020)  VALUE SPACES.*/
                public StringBasis FILLER_157 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ; '.*/
                public StringBasis FILLER_158 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
                /*"    10        FILLER              PIC  X(015)  VALUE SPACES.*/
                public StringBasis FILLER_159 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ; '.*/
                public StringBasis FILLER_160 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
                /*"    10        FILLER              PIC  X(015)  VALUE SPACES.*/
                public StringBasis FILLER_161 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ; '.*/
                public StringBasis FILLER_162 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
                /*"    10        FILLER              PIC  X(015)  VALUE SPACES.*/
                public StringBasis FILLER_163 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ; '.*/
                public StringBasis FILLER_164 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
                /*"    10        FILLER              PIC  X(015)  VALUE SPACES.*/
                public StringBasis FILLER_165 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ; '.*/
                public StringBasis FILLER_166 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
                /*"    10        FILLER              PIC  X(015)  VALUE SPACES.*/
                public StringBasis FILLER_167 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ; '.*/
                public StringBasis FILLER_168 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
                /*"    10        FILLER              PIC  X(030)  VALUE SPACES.*/
                public StringBasis FILLER_169 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"  03        WABEND.*/
            }
            public CB0155B_WABEND WABEND { get; set; } = new CB0155B_WABEND();
            public class CB0155B_WABEND : VarBasis
            {
                /*"    05      FILLER              PIC  X(010) VALUE           ' CB0155B  '.*/
                public StringBasis FILLER_170 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" CB0155B  ");
                /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_171 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05      WNR-EXEC-SQL        PIC  X(004) VALUE    SPACES.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
                public StringBasis FILLER_172 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"    05      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD1 = '.*/
                public StringBasis FILLER_173 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"    05      WSQLERRD1           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD2 = '.*/
                public StringBasis FILLER_174 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05      WSQLERRD2           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"01            LPARM.*/
            }
        }
        public CB0155B_LPARM LPARM { get; set; } = new CB0155B_LPARM();
        public class CB0155B_LPARM : VarBasis
        {
            /*"  03          LPARM01.*/
            public CB0155B_LPARM01 LPARM01 { get; set; } = new CB0155B_LPARM01();
            public class CB0155B_LPARM01 : VarBasis
            {
                /*"    10        LPARM01-DD          PIC  9(002).*/
                public IntBasis LPARM01_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10        LPARM01-MM          PIC  9(002).*/
                public IntBasis LPARM01_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10        LPARM01-AA          PIC  9(004).*/
                public IntBasis LPARM01_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  03          LPARM02.*/
            }
            public CB0155B_LPARM02 LPARM02 { get; set; } = new CB0155B_LPARM02();
            public class CB0155B_LPARM02 : VarBasis
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
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.AVISOCRE AVISOCRE { get; set; } = new Dclgens.AVISOCRE();
        public Dclgens.AVISOSAL AVISOSAL { get; set; } = new Dclgens.AVISOSAL();
        public Dclgens.RCAPS RCAPS { get; set; } = new Dclgens.RCAPS();
        public Dclgens.RCAPCOMP RCAPCOMP { get; set; } = new Dclgens.RCAPCOMP();
        public Dclgens.FOLLOUP FOLLOUP { get; set; } = new Dclgens.FOLLOUP();
        public Dclgens.MOVIMCOB MOVIMCOB { get; set; } = new Dclgens.MOVIMCOB();
        public Dclgens.ORIGEAVI ORIGEAVI { get; set; } = new Dclgens.ORIGEAVI();
        public Dclgens.PARCEHIS PARCEHIS { get; set; } = new Dclgens.PARCEHIS();
        public Dclgens.CONDESCE CONDESCE { get; set; } = new Dclgens.CONDESCE();
        public Dclgens.SI111 SI111 { get; set; } = new Dclgens.SI111();
        public Dclgens.SI127 SI127 { get; set; } = new Dclgens.SI127();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public CB0155B_V0AVISOCRE V0AVISOCRE { get; set; } = new CB0155B_V0AVISOCRE();
        public CB0155B_V0RCAP V0RCAP { get; set; } = new CB0155B_V0RCAP();
        public CB0155B_V0FOLLOW V0FOLLOW { get; set; } = new CB0155B_V0FOLLOW();
        public CB0155B_V0MOVICOB V0MOVICOB { get; set; } = new CB0155B_V0MOVICOB();
        public CB0155B_V0MOVICOB1 V0MOVICOB1 { get; set; } = new CB0155B_V0MOVICOB1();
        public CB0155B_V0FOLLOW1 V0FOLLOW1 { get; set; } = new CB0155B_V0FOLLOW1();
        public CB0155B_V0RCAP1 V0RCAP1 { get; set; } = new CB0155B_V0RCAP1();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string ARQSORT_FILE_NAME_P, string CB0155B1_FILE_NAME_P, string CB0155B2_FILE_NAME_P, string CB0155B3_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                ARQSORT.SetFile(ARQSORT_FILE_NAME_P);
                CB0155B1.SetFile(CB0155B1_FILE_NAME_P);
                CB0155B2.SetFile(CB0155B2_FILE_NAME_P);
                CB0155B3.SetFile(CB0155B3_FILE_NAME_P);

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
            /*" -550- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", W.WABEND.WNR_EXEC_SQL);

            /*" -551- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -553- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -555- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -561- PERFORM R0050-00-INICIO. */

            R0050_00_INICIO_SECTION();

            /*" -574- SORT ARQSORT ON ASCENDING KEY SOR-ORIGEM SOR-BCOAVISO SOR-AGEAVISO SOR-NRAVISO SOR-NRSEQ SOR-TIPOREG INPUT PROCEDURE R0200-00-INPUT-SORT THRU R0200-99-SAIDA OUTPUT PROCEDURE R0950-00-OUTPUT-SORT THRU R0950-99-SAIDA. */
            ARQSORT.Sort("SOR-ORIGEM,SOR-BCOAVISO,SOR-AGEAVISO,SOR-NRAVISO,SOR-NRSEQ,SOR-TIPOREG", () => R0200_00_INPUT_SORT_SECTION(), () => R0950_00_OUTPUT_SORT_SECTION());

            /*" -577- PERFORM R3000-00-LISTA-DOCUMENTOS. */

            R3000_00_LISTA_DOCUMENTOS_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -582- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -588- CLOSE CB0155B1 CB0155B2 CB0155B3. */
            CB0155B1.Close();
            CB0155B2.Close();
            CB0155B3.Close();

            /*" -590- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -591- DISPLAY ' ' */
            _.Display($" ");

            /*" -592- DISPLAY 'CB0155B - FIM NORMAL' . */
            _.Display($"CB0155B - FIM NORMAL");

            /*" -595- DISPLAY ' ' */
            _.Display($" ");

            /*" -595- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0050-00-INICIO-SECTION */
        private void R0050_00_INICIO_SECTION()
        {
            /*" -608- MOVE '0050' TO WNR-EXEC-SQL. */
            _.Move("0050", W.WABEND.WNR_EXEC_SQL);

            /*" -613- OPEN OUTPUT CB0155B1 CB0155B2 CB0155B3. */
            CB0155B1.Open(REG_CB0155B1);
            CB0155B2.Open(REG_CB0155B2);
            CB0155B3.Open(REG_CB0155B3);

            /*" -616- PERFORM R0100-00-SELECT-V0SISTEMA. */

            R0100_00_SELECT_V0SISTEMA_SECTION();

            /*" -616- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-SECTION */
        private void R0100_00_SELECT_V0SISTEMA_SECTION()
        {
            /*" -628- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", W.WABEND.WNR_EXEC_SQL);

            /*" -633- PERFORM R0100_00_SELECT_V0SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V0SISTEMA_DB_SELECT_1();

            /*" -636- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -637- DISPLAY 'R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)' */
                _.Display($"R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)");

                /*" -640- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -642- MOVE SISTEMAS-DATA-MOV-ABERTO TO WDATA-REL */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, W.WDATA_REL);

            /*" -643- MOVE WDAT-REL-DIA TO WDATA-DD-CABEC */
            _.Move(W.FILLER_0.WDAT_REL_DIA, W.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -644- MOVE WDAT-REL-MES TO WDATA-MM-CABEC */
            _.Move(W.FILLER_0.WDAT_REL_MES, W.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -645- MOVE WDAT-REL-ANO TO WDATA-AA-CABEC */
            _.Move(W.FILLER_0.WDAT_REL_ANO, W.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -646- MOVE WDATA-CABEC TO LC01-DTMOVTO LC04-DTMOVTO. */
            _.Move(W.WDATA_CABEC, W.LC01.LC01_DTMOVTO, W.LC04.LC04_DTMOVTO);

        }

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V0SISTEMA_DB_SELECT_1()
        {
            /*" -633- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'CB' END-EXEC. */

            var r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-INPUT-SORT-SECTION */
        private void R0200_00_INPUT_SORT_SECTION()
        {
            /*" -659- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", W.WABEND.WNR_EXEC_SQL);

            /*" -660- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", W.WFIM_MOVIMENTO);

            /*" -662- PERFORM R0300-00-DECLARE-AVISOCRE. */

            R0300_00_DECLARE_AVISOCRE_SECTION();

            /*" -664- PERFORM R0310-00-FETCH-AVISOCRE. */

            R0310_00_FETCH_AVISOCRE_SECTION();

            /*" -667- PERFORM R0350-00-PROCESSA-AVISOCRE UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!W.WFIM_MOVIMENTO.IsEmpty()))
            {

                R0350_00_PROCESSA_AVISOCRE_SECTION();
            }

            /*" -668- DISPLAY ' ' . */
            _.Display($" ");

            /*" -669- DISPLAY 'LIDOS AVISOCRED ............ ' LD-AVISOCRE. */
            _.Display($"LIDOS AVISOCRED ............ {W.LD_AVISOCRE}");

            /*" -670- DISPLAY 'GRAVA AVISOCRED ............ ' GV-AVISOCRE. */
            _.Display($"GRAVA AVISOCRED ............ {W.GV_AVISOCRE}");

            /*" -672- DISPLAY ' ' . */
            _.Display($" ");

            /*" -672- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -676- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", W.WFIM_MOVIMENTO);

            /*" -678- PERFORM R0400-00-DECLARE-RCAP. */

            R0400_00_DECLARE_RCAP_SECTION();

            /*" -680- PERFORM R0410-00-FETCH-RCAP. */

            R0410_00_FETCH_RCAP_SECTION();

            /*" -683- PERFORM R0450-00-PROCESSA-RCAP UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!W.WFIM_MOVIMENTO.IsEmpty()))
            {

                R0450_00_PROCESSA_RCAP_SECTION();
            }

            /*" -684- DISPLAY ' ' . */
            _.Display($" ");

            /*" -685- DISPLAY 'LIDOS RCAP ................. ' LD-RCAP. */
            _.Display($"LIDOS RCAP ................. {W.LD_RCAP}");

            /*" -686- DISPLAY 'GRAVA RCAP ................. ' GV-RCAP. */
            _.Display($"GRAVA RCAP ................. {W.GV_RCAP}");

            /*" -688- DISPLAY ' ' . */
            _.Display($" ");

            /*" -688- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -692- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", W.WFIM_MOVIMENTO);

            /*" -694- PERFORM R0500-00-DECLARE-FOLLOW. */

            R0500_00_DECLARE_FOLLOW_SECTION();

            /*" -696- PERFORM R0510-00-FETCH-FOLLOW. */

            R0510_00_FETCH_FOLLOW_SECTION();

            /*" -699- PERFORM R0550-00-PROCESSA-FOLLOW UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!W.WFIM_MOVIMENTO.IsEmpty()))
            {

                R0550_00_PROCESSA_FOLLOW_SECTION();
            }

            /*" -700- DISPLAY ' ' . */
            _.Display($" ");

            /*" -701- DISPLAY 'LIDOS FOLLOW ............... ' LD-FOLLOW. */
            _.Display($"LIDOS FOLLOW ............... {W.LD_FOLLOW}");

            /*" -702- DISPLAY 'GRAVA FOLLOW ............... ' GV-FOLLOW. */
            _.Display($"GRAVA FOLLOW ............... {W.GV_FOLLOW}");

            /*" -704- DISPLAY ' ' . */
            _.Display($" ");

            /*" -704- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -708- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", W.WFIM_MOVIMENTO);

            /*" -710- PERFORM R0600-00-DECLARE-MOVICOB. */

            R0600_00_DECLARE_MOVICOB_SECTION();

            /*" -712- PERFORM R0610-00-FETCH-MOVICOB. */

            R0610_00_FETCH_MOVICOB_SECTION();

            /*" -715- PERFORM R0650-00-PROCESSA-MOVICOB UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!W.WFIM_MOVIMENTO.IsEmpty()))
            {

                R0650_00_PROCESSA_MOVICOB_SECTION();
            }

            /*" -716- DISPLAY ' ' . */
            _.Display($" ");

            /*" -717- DISPLAY 'LIDOS MOVICOB .............. ' LD-MOVICOB. */
            _.Display($"LIDOS MOVICOB .............. {W.LD_MOVICOB}");

            /*" -718- DISPLAY 'GRAVA MOVICOB .............. ' GV-MOVICOB. */
            _.Display($"GRAVA MOVICOB .............. {W.GV_MOVICOB}");

            /*" -719- DISPLAY ' ' . */
            _.Display($" ");

            /*" -720- DISPLAY 'GRAVA SORT ................. ' GV-SORT. */
            _.Display($"GRAVA SORT ................. {W.GV_SORT}");

            /*" -722- DISPLAY ' ' . */
            _.Display($" ");

            /*" -722- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-DECLARE-AVISOCRE-SECTION */
        private void R0300_00_DECLARE_AVISOCRE_SECTION()
        {
            /*" -735- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", W.WABEND.WNR_EXEC_SQL);

            /*" -764- PERFORM R0300_00_DECLARE_AVISOCRE_DB_DECLARE_1 */

            R0300_00_DECLARE_AVISOCRE_DB_DECLARE_1();

            /*" -766- PERFORM R0300_00_DECLARE_AVISOCRE_DB_OPEN_1 */

            R0300_00_DECLARE_AVISOCRE_DB_OPEN_1();

            /*" -770- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -771- DISPLAY 'R0300-00 - PROBLEMAS DECLARE (AVISOCRE)   ' */
                _.Display($"R0300-00 - PROBLEMAS DECLARE (AVISOCRE)   ");

                /*" -771- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0300-00-DECLARE-AVISOCRE-DB-DECLARE-1 */
        public void R0300_00_DECLARE_AVISOCRE_DB_DECLARE_1()
        {
            /*" -764- EXEC SQL DECLARE V0AVISOCRE CURSOR FOR SELECT A.BCO_AVISO , A.AGE_AVISO , A.NUM_AVISO_CREDITO , A.NUM_SEQUENCIA , A.DATA_MOVIMENTO , A.TIPO_AVISO , A.DATA_AVISO , A.VAL_DESPESA , A.PRM_LIQUIDO , A.PRM_TOTAL , A.ORIGEM_AVISO , B.SALDO_ATUAL , B.SIT_REGISTRO FROM SEGUROS.AVISO_CREDITO A, SEGUROS.AVISOS_SALDOS B WHERE A.DATA_MOVIMENTO >= '2000-11-01' AND A.AGE_AVISO = B.AGE_AVISO AND A.NUM_AVISO_CREDITO = B.NUM_AVISO_CREDITO AND B.BCO_AVISO = A.BCO_AVISO AND B.AGE_AVISO = A.AGE_AVISO AND B.NUM_AVISO_CREDITO = A.NUM_AVISO_CREDITO AND B.SALDO_ATUAL <> 0 END-EXEC. */
            V0AVISOCRE = new CB0155B_V0AVISOCRE(false);
            string GetQuery_V0AVISOCRE()
            {
                var query = @$"SELECT A.BCO_AVISO
							, 
							A.AGE_AVISO
							, 
							A.NUM_AVISO_CREDITO
							, 
							A.NUM_SEQUENCIA
							, 
							A.DATA_MOVIMENTO
							, 
							A.TIPO_AVISO
							, 
							A.DATA_AVISO
							, 
							A.VAL_DESPESA
							, 
							A.PRM_LIQUIDO
							, 
							A.PRM_TOTAL
							, 
							A.ORIGEM_AVISO
							, 
							B.SALDO_ATUAL
							, 
							B.SIT_REGISTRO 
							FROM SEGUROS.AVISO_CREDITO A
							, 
							SEGUROS.AVISOS_SALDOS B 
							WHERE A.DATA_MOVIMENTO >= '2000-11-01' 
							AND A.AGE_AVISO = B.AGE_AVISO 
							AND A.NUM_AVISO_CREDITO = B.NUM_AVISO_CREDITO 
							AND B.BCO_AVISO = A.BCO_AVISO 
							AND B.AGE_AVISO = A.AGE_AVISO 
							AND B.NUM_AVISO_CREDITO = A.NUM_AVISO_CREDITO 
							AND B.SALDO_ATUAL <> 0";

                return query;
            }
            V0AVISOCRE.GetQueryEvent += GetQuery_V0AVISOCRE;

        }

        [StopWatch]
        /*" R0300-00-DECLARE-AVISOCRE-DB-OPEN-1 */
        public void R0300_00_DECLARE_AVISOCRE_DB_OPEN_1()
        {
            /*" -766- EXEC SQL OPEN V0AVISOCRE END-EXEC. */

            V0AVISOCRE.Open();

        }

        [StopWatch]
        /*" R0400-00-DECLARE-RCAP-DB-DECLARE-1 */
        public void R0400_00_DECLARE_RCAP_DB_DECLARE_1()
        {
            /*" -896- EXEC SQL DECLARE V0RCAP CURSOR FOR SELECT BCO_AVISO , AGE_AVISO , NUM_AVISO_CREDITO , VAL_RCAP FROM SEGUROS.RCAP_COMPLEMENTAR WHERE DATA_MOVIMENTO >= '2000-11-01' AND SIT_REGISTRO = '0' AND COD_OPERACAO IN (100,110,310,320,500) ORDER BY BCO_AVISO , AGE_AVISO , NUM_AVISO_CREDITO END-EXEC. */
            V0RCAP = new CB0155B_V0RCAP(false);
            string GetQuery_V0RCAP()
            {
                var query = @$"SELECT BCO_AVISO
							, 
							AGE_AVISO
							, 
							NUM_AVISO_CREDITO
							, 
							VAL_RCAP 
							FROM SEGUROS.RCAP_COMPLEMENTAR 
							WHERE DATA_MOVIMENTO >= '2000-11-01' 
							AND SIT_REGISTRO = '0' 
							AND COD_OPERACAO IN (100
							,110
							,310
							,320
							,500) 
							ORDER BY BCO_AVISO
							, 
							AGE_AVISO
							, 
							NUM_AVISO_CREDITO";

                return query;
            }
            V0RCAP.GetQueryEvent += GetQuery_V0RCAP;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0310-00-FETCH-AVISOCRE-SECTION */
        private void R0310_00_FETCH_AVISOCRE_SECTION()
        {
            /*" -784- MOVE '0310' TO WNR-EXEC-SQL. */
            _.Move("0310", W.WABEND.WNR_EXEC_SQL);

            /*" -798- PERFORM R0310_00_FETCH_AVISOCRE_DB_FETCH_1 */

            R0310_00_FETCH_AVISOCRE_DB_FETCH_1();

            /*" -802- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -802- PERFORM R0310_00_FETCH_AVISOCRE_DB_CLOSE_1 */

                R0310_00_FETCH_AVISOCRE_DB_CLOSE_1();

                /*" -804- MOVE 'S' TO WFIM-MOVIMENTO */
                _.Move("S", W.WFIM_MOVIMENTO);

                /*" -806- GO TO R0310-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/ //GOTO
                return;
            }


            /*" -807- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -808- DISPLAY 'R0310-00 - PROBLEMAS FETCH   (AVISOCRE)   ' */
                _.Display($"R0310-00 - PROBLEMAS FETCH   (AVISOCRE)   ");

                /*" -810- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -811- IF VIND-ORIGEM LESS ZEROS */

            if (VIND_ORIGEM < 00)
            {

                /*" -815- MOVE ZEROS TO AVISOCRE-ORIGEM-AVISO. */
                _.Move(0, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_ORIGEM_AVISO);
            }


            /*" -815- ADD 1 TO LD-AVISOCRE. */
            W.LD_AVISOCRE.Value = W.LD_AVISOCRE + 1;

        }

        [StopWatch]
        /*" R0310-00-FETCH-AVISOCRE-DB-FETCH-1 */
        public void R0310_00_FETCH_AVISOCRE_DB_FETCH_1()
        {
            /*" -798- EXEC SQL FETCH V0AVISOCRE INTO :AVISOCRE-BCO-AVISO , :AVISOCRE-AGE-AVISO , :AVISOCRE-NUM-AVISO-CREDITO , :AVISOCRE-NUM-SEQUENCIA , :AVISOCRE-DATA-MOVIMENTO , :AVISOCRE-TIPO-AVISO , :AVISOCRE-DATA-AVISO , :AVISOCRE-VAL-DESPESA , :AVISOCRE-PRM-LIQUIDO , :AVISOCRE-PRM-TOTAL , :AVISOCRE-ORIGEM-AVISO:VIND-ORIGEM , :AVISOSAL-SALDO-ATUAL , :AVISOSAL-SIT-REGISTRO END-EXEC. */

            if (V0AVISOCRE.Fetch())
            {
                _.Move(V0AVISOCRE.AVISOCRE_BCO_AVISO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_BCO_AVISO);
                _.Move(V0AVISOCRE.AVISOCRE_AGE_AVISO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_AGE_AVISO);
                _.Move(V0AVISOCRE.AVISOCRE_NUM_AVISO_CREDITO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO);
                _.Move(V0AVISOCRE.AVISOCRE_NUM_SEQUENCIA, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_SEQUENCIA);
                _.Move(V0AVISOCRE.AVISOCRE_DATA_MOVIMENTO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_MOVIMENTO);
                _.Move(V0AVISOCRE.AVISOCRE_TIPO_AVISO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_TIPO_AVISO);
                _.Move(V0AVISOCRE.AVISOCRE_DATA_AVISO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_AVISO);
                _.Move(V0AVISOCRE.AVISOCRE_VAL_DESPESA, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_VAL_DESPESA);
                _.Move(V0AVISOCRE.AVISOCRE_PRM_LIQUIDO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_LIQUIDO);
                _.Move(V0AVISOCRE.AVISOCRE_PRM_TOTAL, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_TOTAL);
                _.Move(V0AVISOCRE.AVISOCRE_ORIGEM_AVISO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_ORIGEM_AVISO);
                _.Move(V0AVISOCRE.VIND_ORIGEM, VIND_ORIGEM);
                _.Move(V0AVISOCRE.AVISOSAL_SALDO_ATUAL, AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SALDO_ATUAL);
                _.Move(V0AVISOCRE.AVISOSAL_SIT_REGISTRO, AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SIT_REGISTRO);
            }

        }

        [StopWatch]
        /*" R0310-00-FETCH-AVISOCRE-DB-CLOSE-1 */
        public void R0310_00_FETCH_AVISOCRE_DB_CLOSE_1()
        {
            /*" -802- EXEC SQL CLOSE V0AVISOCRE END-EXEC */

            V0AVISOCRE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/

        [StopWatch]
        /*" R0350-00-PROCESSA-AVISOCRE-SECTION */
        private void R0350_00_PROCESSA_AVISOCRE_SECTION()
        {
            /*" -828- MOVE '0350' TO WNR-EXEC-SQL. */
            _.Move("0350", W.WABEND.WNR_EXEC_SQL);

            /*" -830- MOVE 01 TO SOR-TIPOREG. */
            _.Move(01, REG_ARQSORT.SOR_TIPOREG);

            /*" -832- MOVE AVISOCRE-BCO-AVISO TO SOR-BCOAVISO. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_BCO_AVISO, REG_ARQSORT.SOR_BCOAVISO);

            /*" -834- MOVE AVISOCRE-AGE-AVISO TO SOR-AGEAVISO. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_AGE_AVISO, REG_ARQSORT.SOR_AGEAVISO);

            /*" -836- MOVE AVISOCRE-NUM-AVISO-CREDITO TO SOR-NRAVISO. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO, REG_ARQSORT.SOR_NRAVISO);

            /*" -838- MOVE AVISOCRE-NUM-SEQUENCIA TO SOR-NRSEQ. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_SEQUENCIA, REG_ARQSORT.SOR_NRSEQ);

            /*" -840- MOVE AVISOCRE-ORIGEM-AVISO TO SOR-ORIGEM. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_ORIGEM_AVISO, REG_ARQSORT.SOR_ORIGEM);

            /*" -842- MOVE AVISOCRE-TIPO-AVISO TO SOR-TIPOAVI. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_TIPO_AVISO, REG_ARQSORT.SOR_TIPOAVI);

            /*" -844- MOVE AVISOCRE-DATA-MOVIMENTO TO SOR-DTMOVTO. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_MOVIMENTO, REG_ARQSORT.SOR_DTMOVTO);

            /*" -846- MOVE AVISOCRE-DATA-AVISO TO SOR-DTAVISO. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_AVISO, REG_ARQSORT.SOR_DTAVISO);

            /*" -848- MOVE AVISOCRE-PRM-TOTAL TO SOR-VLPRMTOT. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_TOTAL, REG_ARQSORT.SOR_VLPRMTOT);

            /*" -850- MOVE AVISOCRE-VAL-DESPESA TO SOR-VLDESPES. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_VAL_DESPESA, REG_ARQSORT.SOR_VLDESPES);

            /*" -852- MOVE AVISOCRE-PRM-LIQUIDO TO SOR-VLPRMLIQ. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_LIQUIDO, REG_ARQSORT.SOR_VLPRMLIQ);

            /*" -854- MOVE AVISOSAL-SALDO-ATUAL TO SOR-SDOATU. */
            _.Move(AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SALDO_ATUAL, REG_ARQSORT.SOR_SDOATU);

            /*" -856- MOVE AVISOSAL-SIT-REGISTRO TO SOR-SITUACAO. */
            _.Move(AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SIT_REGISTRO, REG_ARQSORT.SOR_SITUACAO);

            /*" -862- MOVE ZEROS TO SOR-VLFOLLOW SOR-VLRCAP SOR-VLDEMAIS. */
            _.Move(0, REG_ARQSORT.SOR_VLFOLLOW, REG_ARQSORT.SOR_VLRCAP, REG_ARQSORT.SOR_VLDEMAIS);

            /*" -864- RELEASE REG-ARQSORT. */
            ARQSORT.Release(REG_ARQSORT);

            /*" -865- ADD 1 TO GV-AVISOCRE GV-SORT. */
            W.GV_AVISOCRE.Value = W.GV_AVISOCRE + 1;
            W.GV_SORT.Value = W.GV_SORT + 1;

            /*" -0- FLUXCONTROL_PERFORM R0350_90_LEITURA */

            R0350_90_LEITURA();

        }

        [StopWatch]
        /*" R0350-90-LEITURA */
        private void R0350_90_LEITURA(bool isPerform = false)
        {
            /*" -870- PERFORM R0310-00-FETCH-AVISOCRE. */

            R0310_00_FETCH_AVISOCRE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-DECLARE-RCAP-SECTION */
        private void R0400_00_DECLARE_RCAP_SECTION()
        {
            /*" -882- MOVE '0400' TO WNR-EXEC-SQL. */
            _.Move("0400", W.WABEND.WNR_EXEC_SQL);

            /*" -896- PERFORM R0400_00_DECLARE_RCAP_DB_DECLARE_1 */

            R0400_00_DECLARE_RCAP_DB_DECLARE_1();

            /*" -898- PERFORM R0400_00_DECLARE_RCAP_DB_OPEN_1 */

            R0400_00_DECLARE_RCAP_DB_OPEN_1();

            /*" -902- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -903- DISPLAY 'R0400-00 - PROBLEMAS DECLARE (RCAP)       ' */
                _.Display($"R0400-00 - PROBLEMAS DECLARE (RCAP)       ");

                /*" -903- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0400-00-DECLARE-RCAP-DB-OPEN-1 */
        public void R0400_00_DECLARE_RCAP_DB_OPEN_1()
        {
            /*" -898- EXEC SQL OPEN V0RCAP END-EXEC. */

            V0RCAP.Open();

        }

        [StopWatch]
        /*" R0500-00-DECLARE-FOLLOW-DB-DECLARE-1 */
        public void R0500_00_DECLARE_FOLLOW_DB_DECLARE_1()
        {
            /*" -1219- EXEC SQL DECLARE V0FOLLOW CURSOR FOR SELECT BCO_AVISO , AGE_AVISO , NUM_AVISO_CREDITO , VAL_OPERACAO FROM SEGUROS.FOLLOW_UP WHERE SIT_REGISTRO = '0' ORDER BY BCO_AVISO , AGE_AVISO , NUM_AVISO_CREDITO END-EXEC. */
            V0FOLLOW = new CB0155B_V0FOLLOW(false);
            string GetQuery_V0FOLLOW()
            {
                var query = @$"SELECT BCO_AVISO
							, 
							AGE_AVISO
							, 
							NUM_AVISO_CREDITO
							, 
							VAL_OPERACAO 
							FROM SEGUROS.FOLLOW_UP 
							WHERE SIT_REGISTRO = '0' 
							ORDER BY BCO_AVISO
							, 
							AGE_AVISO
							, 
							NUM_AVISO_CREDITO";

                return query;
            }
            V0FOLLOW.GetQueryEvent += GetQuery_V0FOLLOW;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0410-00-FETCH-RCAP-SECTION */
        private void R0410_00_FETCH_RCAP_SECTION()
        {
            /*" -916- MOVE '0410' TO WNR-EXEC-SQL. */
            _.Move("0410", W.WABEND.WNR_EXEC_SQL);

            /*" -921- PERFORM R0410_00_FETCH_RCAP_DB_FETCH_1 */

            R0410_00_FETCH_RCAP_DB_FETCH_1();

            /*" -925- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -925- PERFORM R0410_00_FETCH_RCAP_DB_CLOSE_1 */

                R0410_00_FETCH_RCAP_DB_CLOSE_1();

                /*" -927- MOVE 'S' TO WFIM-MOVIMENTO */
                _.Move("S", W.WFIM_MOVIMENTO);

                /*" -931- MOVE 9999 TO ATU-BCOAVISO ATU-AGEAVISO ATU-ORIGEM ATU-NRSEQ */
                _.Move(9999, W.WS_CHAVE_ATU.ATU_BCOAVISO, W.WS_CHAVE_ATU.ATU_AGEAVISO, W.WS_CHAVE_ATU.ATU_ORIGEM, W.WS_CHAVE_ATU.ATU_NRSEQ);

                /*" -932- MOVE 999999999 TO ATU-NRAVISO */
                _.Move(999999999, W.WS_CHAVE_ATU.ATU_NRAVISO);

                /*" -934- GO TO R0410-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0410_99_SAIDA*/ //GOTO
                return;
            }


            /*" -935- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -936- DISPLAY 'R0410-00 - PROBLEMAS FETCH   (RCAP)       ' */
                _.Display($"R0410-00 - PROBLEMAS FETCH   (RCAP)       ");

                /*" -939- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -942- ADD 1 TO LD-RCAP. */
            W.LD_RCAP.Value = W.LD_RCAP + 1;

            /*" -945- MOVE ZEROS TO ATU-ORIGEM ATU-NRSEQ. */
            _.Move(0, W.WS_CHAVE_ATU.ATU_ORIGEM, W.WS_CHAVE_ATU.ATU_NRSEQ);

            /*" -947- MOVE RCAPCOMP-BCO-AVISO TO ATU-BCOAVISO. */
            _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO, W.WS_CHAVE_ATU.ATU_BCOAVISO);

            /*" -949- MOVE RCAPCOMP-AGE-AVISO TO ATU-AGEAVISO. */
            _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO, W.WS_CHAVE_ATU.ATU_AGEAVISO);

            /*" -950- MOVE RCAPCOMP-NUM-AVISO-CREDITO TO ATU-NRAVISO. */
            _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO, W.WS_CHAVE_ATU.ATU_NRAVISO);

        }

        [StopWatch]
        /*" R0410-00-FETCH-RCAP-DB-FETCH-1 */
        public void R0410_00_FETCH_RCAP_DB_FETCH_1()
        {
            /*" -921- EXEC SQL FETCH V0RCAP INTO :RCAPCOMP-BCO-AVISO , :RCAPCOMP-AGE-AVISO , :RCAPCOMP-NUM-AVISO-CREDITO , :RCAPCOMP-VAL-RCAP END-EXEC. */

            if (V0RCAP.Fetch())
            {
                _.Move(V0RCAP.RCAPCOMP_BCO_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO);
                _.Move(V0RCAP.RCAPCOMP_AGE_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO);
                _.Move(V0RCAP.RCAPCOMP_NUM_AVISO_CREDITO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO);
                _.Move(V0RCAP.RCAPCOMP_VAL_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP);
            }

        }

        [StopWatch]
        /*" R0410-00-FETCH-RCAP-DB-CLOSE-1 */
        public void R0410_00_FETCH_RCAP_DB_CLOSE_1()
        {
            /*" -925- EXEC SQL CLOSE V0RCAP END-EXEC */

            V0RCAP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0410_99_SAIDA*/

        [StopWatch]
        /*" R0450-00-PROCESSA-RCAP-SECTION */
        private void R0450_00_PROCESSA_RCAP_SECTION()
        {
            /*" -963- MOVE '0450' TO WNR-EXEC-SQL. */
            _.Move("0450", W.WABEND.WNR_EXEC_SQL);

            /*" -966- PERFORM R0460-00-SELECT-V0AVISOCRE. */

            R0460_00_SELECT_V0AVISOCRE_SECTION();

            /*" -967- IF AVISOCRE-TIPO-AVISO NOT EQUAL 'R' */

            if (AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_TIPO_AVISO != "R")
            {

                /*" -973- DISPLAY 'AVISO NAO E RCAP  ' '  ' RCAPCOMP-BCO-AVISO '  ' RCAPCOMP-AGE-AVISO '  ' RCAPCOMP-NUM-AVISO-CREDITO. */

                $"AVISO NAO E RCAP    {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO}  {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO}  {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO}"
                .Display();
            }


            /*" -975- MOVE 02 TO SOR-TIPOREG. */
            _.Move(02, REG_ARQSORT.SOR_TIPOREG);

            /*" -977- MOVE AVISOCRE-BCO-AVISO TO SOR-BCOAVISO. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_BCO_AVISO, REG_ARQSORT.SOR_BCOAVISO);

            /*" -979- MOVE AVISOCRE-AGE-AVISO TO SOR-AGEAVISO. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_AGE_AVISO, REG_ARQSORT.SOR_AGEAVISO);

            /*" -981- MOVE AVISOCRE-NUM-AVISO-CREDITO TO SOR-NRAVISO. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO, REG_ARQSORT.SOR_NRAVISO);

            /*" -983- MOVE AVISOCRE-NUM-SEQUENCIA TO SOR-NRSEQ. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_SEQUENCIA, REG_ARQSORT.SOR_NRSEQ);

            /*" -985- MOVE AVISOCRE-ORIGEM-AVISO TO SOR-ORIGEM. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_ORIGEM_AVISO, REG_ARQSORT.SOR_ORIGEM);

            /*" -987- MOVE AVISOCRE-TIPO-AVISO TO SOR-TIPOAVI. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_TIPO_AVISO, REG_ARQSORT.SOR_TIPOAVI);

            /*" -989- MOVE AVISOCRE-DATA-MOVIMENTO TO SOR-DTMOVTO. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_MOVIMENTO, REG_ARQSORT.SOR_DTMOVTO);

            /*" -991- MOVE AVISOCRE-DATA-AVISO TO SOR-DTAVISO. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_AVISO, REG_ARQSORT.SOR_DTAVISO);

            /*" -993- MOVE AVISOCRE-PRM-TOTAL TO SOR-VLPRMTOT. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_TOTAL, REG_ARQSORT.SOR_VLPRMTOT);

            /*" -995- MOVE AVISOCRE-VAL-DESPESA TO SOR-VLDESPES. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_VAL_DESPESA, REG_ARQSORT.SOR_VLDESPES);

            /*" -997- MOVE AVISOCRE-PRM-LIQUIDO TO SOR-VLPRMLIQ. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_LIQUIDO, REG_ARQSORT.SOR_VLPRMLIQ);

            /*" -999- MOVE AVISOSAL-SALDO-ATUAL TO SOR-SDOATU. */
            _.Move(AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SALDO_ATUAL, REG_ARQSORT.SOR_SDOATU);

            /*" -1001- MOVE AVISOSAL-SIT-REGISTRO TO SOR-SITUACAO. */
            _.Move(AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SIT_REGISTRO, REG_ARQSORT.SOR_SITUACAO);

            /*" -1007- MOVE ZEROS TO SOR-VLFOLLOW SOR-VLRCAP SOR-VLDEMAIS. */
            _.Move(0, REG_ARQSORT.SOR_VLFOLLOW, REG_ARQSORT.SOR_VLRCAP, REG_ARQSORT.SOR_VLDEMAIS);

            /*" -1009- MOVE WS-CHAVE-ATU TO WS-CHAVE-ANT. */
            _.Move(W.WS_CHAVE_ATU, W.WS_CHAVE_ANT);

            /*" -1014- PERFORM R0470-00-ACUMULA-RCAP UNTIL WS-CHAVE-ATU NOT EQUAL WS-CHAVE-ANT OR WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(W.WS_CHAVE_ATU != W.WS_CHAVE_ANT || !W.WFIM_MOVIMENTO.IsEmpty()))
            {

                R0470_00_ACUMULA_RCAP_SECTION();
            }

            /*" -1016- RELEASE REG-ARQSORT. */
            ARQSORT.Release(REG_ARQSORT);

            /*" -1017- ADD 1 TO GV-RCAP GV-SORT. */
            W.GV_RCAP.Value = W.GV_RCAP + 1;
            W.GV_SORT.Value = W.GV_SORT + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/

        [StopWatch]
        /*" R0460-00-SELECT-V0AVISOCRE-SECTION */
        private void R0460_00_SELECT_V0AVISOCRE_SECTION()
        {
            /*" -1029- MOVE '0460' TO WNR-EXEC-SQL. */
            _.Move("0460", W.WABEND.WNR_EXEC_SQL);

            /*" -1080- PERFORM R0460_00_SELECT_V0AVISOCRE_DB_SELECT_1 */

            R0460_00_SELECT_V0AVISOCRE_DB_SELECT_1();

            /*" -1084- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1085- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, W.WABEND.WSQLCODE);

                /*" -1090- DISPLAY 'R0460-00 - PROBLEMAS NO SELECT(AVISOCRE)' '  ' RCAPCOMP-BCO-AVISO '  ' RCAPCOMP-AGE-AVISO '  ' RCAPCOMP-NUM-AVISO-CREDITO '  ' WSQLCODE */

                $"R0460-00 - PROBLEMAS NO SELECT(AVISOCRE)  {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO}  {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO}  {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO}  {W.WABEND.WSQLCODE}"
                .Display();

                /*" -1091- PERFORM R0465-00-SELECT-V0AVISOCRE */

                R0465_00_SELECT_V0AVISOCRE_SECTION();

                /*" -1092- ELSE */
            }
            else
            {


                /*" -1093- IF VIND-ORIGEM LESS ZEROS */

                if (VIND_ORIGEM < 00)
                {

                    /*" -1094- MOVE ZEROS TO AVISOCRE-ORIGEM-AVISO. */
                    _.Move(0, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_ORIGEM_AVISO);
                }

            }


        }

        [StopWatch]
        /*" R0460-00-SELECT-V0AVISOCRE-DB-SELECT-1 */
        public void R0460_00_SELECT_V0AVISOCRE_DB_SELECT_1()
        {
            /*" -1080- EXEC SQL SELECT A.BCO_AVISO , A.AGE_AVISO , A.NUM_AVISO_CREDITO , A.NUM_SEQUENCIA , A.DATA_MOVIMENTO , A.TIPO_AVISO , A.DATA_AVISO , A.VAL_DESPESA , A.PRM_LIQUIDO , A.PRM_TOTAL , A.ORIGEM_AVISO , B.SALDO_ATUAL , B.SIT_REGISTRO INTO :AVISOCRE-BCO-AVISO , :AVISOCRE-AGE-AVISO , :AVISOCRE-NUM-AVISO-CREDITO , :AVISOCRE-NUM-SEQUENCIA , :AVISOCRE-DATA-MOVIMENTO , :AVISOCRE-TIPO-AVISO , :AVISOCRE-DATA-AVISO , :AVISOCRE-VAL-DESPESA , :AVISOCRE-PRM-LIQUIDO , :AVISOCRE-PRM-TOTAL , :AVISOCRE-ORIGEM-AVISO:VIND-ORIGEM , :AVISOSAL-SALDO-ATUAL , :AVISOSAL-SIT-REGISTRO FROM SEGUROS.AVISO_CREDITO A, SEGUROS.AVISOS_SALDOS B WHERE B.BCO_AVISO = :RCAPCOMP-BCO-AVISO AND B.AGE_AVISO = :RCAPCOMP-AGE-AVISO AND B.NUM_AVISO_CREDITO = :RCAPCOMP-NUM-AVISO-CREDITO AND A.AGE_AVISO = B.AGE_AVISO AND A.NUM_AVISO_CREDITO = B.NUM_AVISO_CREDITO AND A.BCO_AVISO = B.BCO_AVISO AND A.NUM_SEQUENCIA = 1 END-EXEC. */

            var r0460_00_SELECT_V0AVISOCRE_DB_SELECT_1_Query1 = new R0460_00_SELECT_V0AVISOCRE_DB_SELECT_1_Query1()
            {
                RCAPCOMP_NUM_AVISO_CREDITO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO.ToString(),
                RCAPCOMP_BCO_AVISO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO.ToString(),
                RCAPCOMP_AGE_AVISO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO.ToString(),
            };

            var executed_1 = R0460_00_SELECT_V0AVISOCRE_DB_SELECT_1_Query1.Execute(r0460_00_SELECT_V0AVISOCRE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AVISOCRE_BCO_AVISO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_BCO_AVISO);
                _.Move(executed_1.AVISOCRE_AGE_AVISO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_AGE_AVISO);
                _.Move(executed_1.AVISOCRE_NUM_AVISO_CREDITO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO);
                _.Move(executed_1.AVISOCRE_NUM_SEQUENCIA, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_SEQUENCIA);
                _.Move(executed_1.AVISOCRE_DATA_MOVIMENTO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_MOVIMENTO);
                _.Move(executed_1.AVISOCRE_TIPO_AVISO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_TIPO_AVISO);
                _.Move(executed_1.AVISOCRE_DATA_AVISO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_AVISO);
                _.Move(executed_1.AVISOCRE_VAL_DESPESA, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_VAL_DESPESA);
                _.Move(executed_1.AVISOCRE_PRM_LIQUIDO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_LIQUIDO);
                _.Move(executed_1.AVISOCRE_PRM_TOTAL, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_TOTAL);
                _.Move(executed_1.AVISOCRE_ORIGEM_AVISO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_ORIGEM_AVISO);
                _.Move(executed_1.VIND_ORIGEM, VIND_ORIGEM);
                _.Move(executed_1.AVISOSAL_SALDO_ATUAL, AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SALDO_ATUAL);
                _.Move(executed_1.AVISOSAL_SIT_REGISTRO, AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SIT_REGISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0460_99_SAIDA*/

        [StopWatch]
        /*" R0465-00-SELECT-V0AVISOCRE-SECTION */
        private void R0465_00_SELECT_V0AVISOCRE_SECTION()
        {
            /*" -1106- MOVE '0465' TO WNR-EXEC-SQL. */
            _.Move("0465", W.WABEND.WNR_EXEC_SQL);

            /*" -1146- PERFORM R0465_00_SELECT_V0AVISOCRE_DB_SELECT_1 */

            R0465_00_SELECT_V0AVISOCRE_DB_SELECT_1();

            /*" -1150- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1151- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, W.WABEND.WSQLCODE);

                /*" -1156- DISPLAY 'R0465-00 - PROBLEMAS NO SELECT(AVISOCRE)' '  ' RCAPCOMP-BCO-AVISO '  ' RCAPCOMP-AGE-AVISO '  ' RCAPCOMP-NUM-AVISO-CREDITO '  ' WSQLCODE */

                $"R0465-00 - PROBLEMAS NO SELECT(AVISOCRE)  {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO}  {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO}  {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO}  {W.WABEND.WSQLCODE}"
                .Display();

                /*" -1158- MOVE RCAPCOMP-BCO-AVISO TO AVISOCRE-BCO-AVISO */
                _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_BCO_AVISO);

                /*" -1160- MOVE RCAPCOMP-AGE-AVISO TO AVISOCRE-AGE-AVISO */
                _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_AGE_AVISO);

                /*" -1162- MOVE RCAPCOMP-NUM-AVISO-CREDITO TO AVISOCRE-NUM-AVISO-CREDITO */
                _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO);

                /*" -1168- MOVE ZEROS TO AVISOCRE-VAL-DESPESA AVISOCRE-PRM-LIQUIDO AVISOCRE-PRM-TOTAL AVISOCRE-ORIGEM-AVISO AVISOSAL-SALDO-ATUAL */
                _.Move(0, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_VAL_DESPESA, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_LIQUIDO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_TOTAL, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_ORIGEM_AVISO, AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SALDO_ATUAL);

                /*" -1172- MOVE SPACES TO AVISOCRE-DATA-MOVIMENTO AVISOCRE-TIPO-AVISO AVISOCRE-DATA-AVISO */
                _.Move("", AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_MOVIMENTO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_TIPO_AVISO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_AVISO);

                /*" -1173- ELSE */
            }
            else
            {


                /*" -1175- MOVE ZEROS TO AVISOSAL-SALDO-ATUAL */
                _.Move(0, AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SALDO_ATUAL);

                /*" -1176- IF VIND-ORIGEM LESS ZEROS */

                if (VIND_ORIGEM < 00)
                {

                    /*" -1177- MOVE ZEROS TO AVISOCRE-ORIGEM-AVISO. */
                    _.Move(0, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_ORIGEM_AVISO);
                }

            }


        }

        [StopWatch]
        /*" R0465-00-SELECT-V0AVISOCRE-DB-SELECT-1 */
        public void R0465_00_SELECT_V0AVISOCRE_DB_SELECT_1()
        {
            /*" -1146- EXEC SQL SELECT BCO_AVISO , AGE_AVISO , NUM_AVISO_CREDITO , NUM_SEQUENCIA , DATA_MOVIMENTO , TIPO_AVISO , DATA_AVISO , VAL_DESPESA , PRM_LIQUIDO , PRM_TOTAL , ORIGEM_AVISO INTO :AVISOCRE-BCO-AVISO , :AVISOCRE-AGE-AVISO , :AVISOCRE-NUM-AVISO-CREDITO , :AVISOCRE-NUM-SEQUENCIA , :AVISOCRE-DATA-MOVIMENTO , :AVISOCRE-TIPO-AVISO , :AVISOCRE-DATA-AVISO , :AVISOCRE-VAL-DESPESA , :AVISOCRE-PRM-LIQUIDO , :AVISOCRE-PRM-TOTAL , :AVISOCRE-ORIGEM-AVISO:VIND-ORIGEM FROM SEGUROS.AVISO_CREDITO WHERE AGE_AVISO = :RCAPCOMP-AGE-AVISO AND NUM_AVISO_CREDITO = :RCAPCOMP-NUM-AVISO-CREDITO AND NUM_SEQUENCIA = 1 AND BCO_AVISO = :RCAPCOMP-BCO-AVISO END-EXEC. */

            var r0465_00_SELECT_V0AVISOCRE_DB_SELECT_1_Query1 = new R0465_00_SELECT_V0AVISOCRE_DB_SELECT_1_Query1()
            {
                RCAPCOMP_NUM_AVISO_CREDITO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO.ToString(),
                RCAPCOMP_AGE_AVISO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO.ToString(),
                RCAPCOMP_BCO_AVISO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO.ToString(),
            };

            var executed_1 = R0465_00_SELECT_V0AVISOCRE_DB_SELECT_1_Query1.Execute(r0465_00_SELECT_V0AVISOCRE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AVISOCRE_BCO_AVISO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_BCO_AVISO);
                _.Move(executed_1.AVISOCRE_AGE_AVISO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_AGE_AVISO);
                _.Move(executed_1.AVISOCRE_NUM_AVISO_CREDITO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO);
                _.Move(executed_1.AVISOCRE_NUM_SEQUENCIA, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_SEQUENCIA);
                _.Move(executed_1.AVISOCRE_DATA_MOVIMENTO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_MOVIMENTO);
                _.Move(executed_1.AVISOCRE_TIPO_AVISO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_TIPO_AVISO);
                _.Move(executed_1.AVISOCRE_DATA_AVISO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_AVISO);
                _.Move(executed_1.AVISOCRE_VAL_DESPESA, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_VAL_DESPESA);
                _.Move(executed_1.AVISOCRE_PRM_LIQUIDO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_LIQUIDO);
                _.Move(executed_1.AVISOCRE_PRM_TOTAL, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_TOTAL);
                _.Move(executed_1.AVISOCRE_ORIGEM_AVISO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_ORIGEM_AVISO);
                _.Move(executed_1.VIND_ORIGEM, VIND_ORIGEM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0465_99_SAIDA*/

        [StopWatch]
        /*" R0470-00-ACUMULA-RCAP-SECTION */
        private void R0470_00_ACUMULA_RCAP_SECTION()
        {
            /*" -1190- MOVE '0470' TO WNR-EXEC-SQL. */
            _.Move("0470", W.WABEND.WNR_EXEC_SQL);

            /*" -1191- ADD RCAPCOMP-VAL-RCAP TO SOR-VLRCAP. */
            REG_ARQSORT.SOR_VLRCAP.Value = REG_ARQSORT.SOR_VLRCAP + RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP;

            /*" -0- FLUXCONTROL_PERFORM R0470_90_LEITURA */

            R0470_90_LEITURA();

        }

        [StopWatch]
        /*" R0470-90-LEITURA */
        private void R0470_90_LEITURA(bool isPerform = false)
        {
            /*" -1196- PERFORM R0410-00-FETCH-RCAP. */

            R0410_00_FETCH_RCAP_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0470_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-DECLARE-FOLLOW-SECTION */
        private void R0500_00_DECLARE_FOLLOW_SECTION()
        {
            /*" -1208- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", W.WABEND.WNR_EXEC_SQL);

            /*" -1219- PERFORM R0500_00_DECLARE_FOLLOW_DB_DECLARE_1 */

            R0500_00_DECLARE_FOLLOW_DB_DECLARE_1();

            /*" -1221- PERFORM R0500_00_DECLARE_FOLLOW_DB_OPEN_1 */

            R0500_00_DECLARE_FOLLOW_DB_OPEN_1();

            /*" -1225- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1226- DISPLAY 'R0500-00 - PROBLEMAS DECLARE (FOLLOW)     ' */
                _.Display($"R0500-00 - PROBLEMAS DECLARE (FOLLOW)     ");

                /*" -1226- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0500-00-DECLARE-FOLLOW-DB-OPEN-1 */
        public void R0500_00_DECLARE_FOLLOW_DB_OPEN_1()
        {
            /*" -1221- EXEC SQL OPEN V0FOLLOW END-EXEC. */

            V0FOLLOW.Open();

        }

        [StopWatch]
        /*" R0600-00-DECLARE-MOVICOB-DB-DECLARE-1 */
        public void R0600_00_DECLARE_MOVICOB_DB_DECLARE_1()
        {
            /*" -1378- EXEC SQL DECLARE V0MOVICOB CURSOR FOR SELECT COD_BANCO , COD_AGENCIA , NUM_AVISO , VAL_TITULO FROM SEGUROS.MOVIMENTO_COBRANCA WHERE SIT_REGISTRO = ' ' ORDER BY COD_BANCO , COD_AGENCIA , NUM_AVISO END-EXEC. */
            V0MOVICOB = new CB0155B_V0MOVICOB(false);
            string GetQuery_V0MOVICOB()
            {
                var query = @$"SELECT COD_BANCO
							, 
							COD_AGENCIA
							, 
							NUM_AVISO
							, 
							VAL_TITULO 
							FROM SEGUROS.MOVIMENTO_COBRANCA 
							WHERE SIT_REGISTRO = ' ' 
							ORDER BY COD_BANCO
							, 
							COD_AGENCIA
							, 
							NUM_AVISO";

                return query;
            }
            V0MOVICOB.GetQueryEvent += GetQuery_V0MOVICOB;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0510-00-FETCH-FOLLOW-SECTION */
        private void R0510_00_FETCH_FOLLOW_SECTION()
        {
            /*" -1239- MOVE '0510' TO WNR-EXEC-SQL. */
            _.Move("0510", W.WABEND.WNR_EXEC_SQL);

            /*" -1244- PERFORM R0510_00_FETCH_FOLLOW_DB_FETCH_1 */

            R0510_00_FETCH_FOLLOW_DB_FETCH_1();

            /*" -1248- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1248- PERFORM R0510_00_FETCH_FOLLOW_DB_CLOSE_1 */

                R0510_00_FETCH_FOLLOW_DB_CLOSE_1();

                /*" -1250- MOVE 'S' TO WFIM-MOVIMENTO */
                _.Move("S", W.WFIM_MOVIMENTO);

                /*" -1254- MOVE 9999 TO ATU-BCOAVISO ATU-AGEAVISO ATU-ORIGEM ATU-NRSEQ */
                _.Move(9999, W.WS_CHAVE_ATU.ATU_BCOAVISO, W.WS_CHAVE_ATU.ATU_AGEAVISO, W.WS_CHAVE_ATU.ATU_ORIGEM, W.WS_CHAVE_ATU.ATU_NRSEQ);

                /*" -1255- MOVE 999999999 TO ATU-NRAVISO */
                _.Move(999999999, W.WS_CHAVE_ATU.ATU_NRAVISO);

                /*" -1257- GO TO R0510-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1258- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1259- DISPLAY 'R0510-00 - PROBLEMAS FETCH   (FOLLOW)     ' */
                _.Display($"R0510-00 - PROBLEMAS FETCH   (FOLLOW)     ");

                /*" -1262- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1265- ADD 1 TO LD-FOLLOW. */
            W.LD_FOLLOW.Value = W.LD_FOLLOW + 1;

            /*" -1268- MOVE ZEROS TO ATU-ORIGEM ATU-NRSEQ. */
            _.Move(0, W.WS_CHAVE_ATU.ATU_ORIGEM, W.WS_CHAVE_ATU.ATU_NRSEQ);

            /*" -1271- MOVE FOLLOUP-BCO-AVISO TO RCAPCOMP-BCO-AVISO ATU-BCOAVISO. */
            _.Move(FOLLOUP.DCLFOLLOW_UP.FOLLOUP_BCO_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO, W.WS_CHAVE_ATU.ATU_BCOAVISO);

            /*" -1274- MOVE FOLLOUP-AGE-AVISO TO RCAPCOMP-AGE-AVISO ATU-AGEAVISO. */
            _.Move(FOLLOUP.DCLFOLLOW_UP.FOLLOUP_AGE_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO, W.WS_CHAVE_ATU.ATU_AGEAVISO);

            /*" -1276- MOVE FOLLOUP-NUM-AVISO-CREDITO TO RCAPCOMP-NUM-AVISO-CREDITO ATU-NRAVISO. */
            _.Move(FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_AVISO_CREDITO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO, W.WS_CHAVE_ATU.ATU_NRAVISO);

        }

        [StopWatch]
        /*" R0510-00-FETCH-FOLLOW-DB-FETCH-1 */
        public void R0510_00_FETCH_FOLLOW_DB_FETCH_1()
        {
            /*" -1244- EXEC SQL FETCH V0FOLLOW INTO :FOLLOUP-BCO-AVISO , :FOLLOUP-AGE-AVISO , :FOLLOUP-NUM-AVISO-CREDITO , :FOLLOUP-VAL-OPERACAO END-EXEC. */

            if (V0FOLLOW.Fetch())
            {
                _.Move(V0FOLLOW.FOLLOUP_BCO_AVISO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_BCO_AVISO);
                _.Move(V0FOLLOW.FOLLOUP_AGE_AVISO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_AGE_AVISO);
                _.Move(V0FOLLOW.FOLLOUP_NUM_AVISO_CREDITO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_AVISO_CREDITO);
                _.Move(V0FOLLOW.FOLLOUP_VAL_OPERACAO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_VAL_OPERACAO);
            }

        }

        [StopWatch]
        /*" R0510-00-FETCH-FOLLOW-DB-CLOSE-1 */
        public void R0510_00_FETCH_FOLLOW_DB_CLOSE_1()
        {
            /*" -1248- EXEC SQL CLOSE V0FOLLOW END-EXEC */

            V0FOLLOW.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_99_SAIDA*/

        [StopWatch]
        /*" R0550-00-PROCESSA-FOLLOW-SECTION */
        private void R0550_00_PROCESSA_FOLLOW_SECTION()
        {
            /*" -1289- MOVE '0550' TO WNR-EXEC-SQL. */
            _.Move("0550", W.WABEND.WNR_EXEC_SQL);

            /*" -1292- PERFORM R0460-00-SELECT-V0AVISOCRE. */

            R0460_00_SELECT_V0AVISOCRE_SECTION();

            /*" -1294- MOVE 03 TO SOR-TIPOREG. */
            _.Move(03, REG_ARQSORT.SOR_TIPOREG);

            /*" -1296- MOVE AVISOCRE-BCO-AVISO TO SOR-BCOAVISO. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_BCO_AVISO, REG_ARQSORT.SOR_BCOAVISO);

            /*" -1298- MOVE AVISOCRE-AGE-AVISO TO SOR-AGEAVISO. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_AGE_AVISO, REG_ARQSORT.SOR_AGEAVISO);

            /*" -1300- MOVE AVISOCRE-NUM-AVISO-CREDITO TO SOR-NRAVISO. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO, REG_ARQSORT.SOR_NRAVISO);

            /*" -1302- MOVE AVISOCRE-NUM-SEQUENCIA TO SOR-NRSEQ. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_SEQUENCIA, REG_ARQSORT.SOR_NRSEQ);

            /*" -1304- MOVE AVISOCRE-ORIGEM-AVISO TO SOR-ORIGEM. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_ORIGEM_AVISO, REG_ARQSORT.SOR_ORIGEM);

            /*" -1306- MOVE AVISOCRE-TIPO-AVISO TO SOR-TIPOAVI. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_TIPO_AVISO, REG_ARQSORT.SOR_TIPOAVI);

            /*" -1308- MOVE AVISOCRE-DATA-MOVIMENTO TO SOR-DTMOVTO. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_MOVIMENTO, REG_ARQSORT.SOR_DTMOVTO);

            /*" -1310- MOVE AVISOCRE-DATA-AVISO TO SOR-DTAVISO. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_AVISO, REG_ARQSORT.SOR_DTAVISO);

            /*" -1312- MOVE AVISOCRE-PRM-TOTAL TO SOR-VLPRMTOT. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_TOTAL, REG_ARQSORT.SOR_VLPRMTOT);

            /*" -1314- MOVE AVISOCRE-VAL-DESPESA TO SOR-VLDESPES. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_VAL_DESPESA, REG_ARQSORT.SOR_VLDESPES);

            /*" -1316- MOVE AVISOCRE-PRM-LIQUIDO TO SOR-VLPRMLIQ. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_LIQUIDO, REG_ARQSORT.SOR_VLPRMLIQ);

            /*" -1318- MOVE AVISOSAL-SALDO-ATUAL TO SOR-SDOATU. */
            _.Move(AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SALDO_ATUAL, REG_ARQSORT.SOR_SDOATU);

            /*" -1320- MOVE AVISOSAL-SIT-REGISTRO TO SOR-SITUACAO. */
            _.Move(AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SIT_REGISTRO, REG_ARQSORT.SOR_SITUACAO);

            /*" -1326- MOVE ZEROS TO SOR-VLFOLLOW SOR-VLRCAP SOR-VLDEMAIS. */
            _.Move(0, REG_ARQSORT.SOR_VLFOLLOW, REG_ARQSORT.SOR_VLRCAP, REG_ARQSORT.SOR_VLDEMAIS);

            /*" -1328- MOVE WS-CHAVE-ATU TO WS-CHAVE-ANT. */
            _.Move(W.WS_CHAVE_ATU, W.WS_CHAVE_ANT);

            /*" -1333- PERFORM R0570-00-ACUMULA-FOLLOW UNTIL WS-CHAVE-ATU NOT EQUAL WS-CHAVE-ANT OR WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(W.WS_CHAVE_ATU != W.WS_CHAVE_ANT || !W.WFIM_MOVIMENTO.IsEmpty()))
            {

                R0570_00_ACUMULA_FOLLOW_SECTION();
            }

            /*" -1335- RELEASE REG-ARQSORT. */
            ARQSORT.Release(REG_ARQSORT);

            /*" -1336- ADD 1 TO GV-FOLLOW GV-SORT. */
            W.GV_FOLLOW.Value = W.GV_FOLLOW + 1;
            W.GV_SORT.Value = W.GV_SORT + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0550_99_SAIDA*/

        [StopWatch]
        /*" R0570-00-ACUMULA-FOLLOW-SECTION */
        private void R0570_00_ACUMULA_FOLLOW_SECTION()
        {
            /*" -1349- MOVE '0570' TO WNR-EXEC-SQL. */
            _.Move("0570", W.WABEND.WNR_EXEC_SQL);

            /*" -1350- ADD FOLLOUP-VAL-OPERACAO TO SOR-VLFOLLOW. */
            REG_ARQSORT.SOR_VLFOLLOW.Value = REG_ARQSORT.SOR_VLFOLLOW + FOLLOUP.DCLFOLLOW_UP.FOLLOUP_VAL_OPERACAO;

            /*" -0- FLUXCONTROL_PERFORM R0570_90_LEITURA */

            R0570_90_LEITURA();

        }

        [StopWatch]
        /*" R0570-90-LEITURA */
        private void R0570_90_LEITURA(bool isPerform = false)
        {
            /*" -1355- PERFORM R0510-00-FETCH-FOLLOW. */

            R0510_00_FETCH_FOLLOW_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0570_99_SAIDA*/

        [StopWatch]
        /*" R0600-00-DECLARE-MOVICOB-SECTION */
        private void R0600_00_DECLARE_MOVICOB_SECTION()
        {
            /*" -1367- MOVE '0600' TO WNR-EXEC-SQL. */
            _.Move("0600", W.WABEND.WNR_EXEC_SQL);

            /*" -1378- PERFORM R0600_00_DECLARE_MOVICOB_DB_DECLARE_1 */

            R0600_00_DECLARE_MOVICOB_DB_DECLARE_1();

            /*" -1380- PERFORM R0600_00_DECLARE_MOVICOB_DB_OPEN_1 */

            R0600_00_DECLARE_MOVICOB_DB_OPEN_1();

            /*" -1384- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1385- DISPLAY 'R0600-00 - PROBLEMAS DECLARE (MOVICOB)    ' */
                _.Display($"R0600-00 - PROBLEMAS DECLARE (MOVICOB)    ");

                /*" -1385- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0600-00-DECLARE-MOVICOB-DB-OPEN-1 */
        public void R0600_00_DECLARE_MOVICOB_DB_OPEN_1()
        {
            /*" -1380- EXEC SQL OPEN V0MOVICOB END-EXEC. */

            V0MOVICOB.Open();

        }

        [StopWatch]
        /*" R3100-00-DECLARE-MOVICOB-DB-DECLARE-1 */
        public void R3100_00_DECLARE_MOVICOB_DB_DECLARE_1()
        {
            /*" -3065- EXEC SQL DECLARE V0MOVICOB1 CURSOR FOR SELECT COD_BANCO , COD_AGENCIA , NUM_AVISO , DATA_MOVIMENTO , DATA_QUITACAO , NUM_TITULO , NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , VAL_TITULO , NUM_NOSSO_TITULO FROM SEGUROS.MOVIMENTO_COBRANCA WHERE SIT_REGISTRO = ' ' ORDER BY COD_BANCO , COD_AGENCIA , NUM_AVISO , DATA_QUITACAO , NUM_TITULO END-EXEC. */
            V0MOVICOB1 = new CB0155B_V0MOVICOB1(false);
            string GetQuery_V0MOVICOB1()
            {
                var query = @$"SELECT COD_BANCO
							, 
							COD_AGENCIA
							, 
							NUM_AVISO
							, 
							DATA_MOVIMENTO
							, 
							DATA_QUITACAO
							, 
							NUM_TITULO
							, 
							NUM_APOLICE
							, 
							NUM_ENDOSSO
							, 
							NUM_PARCELA
							, 
							VAL_TITULO
							, 
							NUM_NOSSO_TITULO 
							FROM SEGUROS.MOVIMENTO_COBRANCA 
							WHERE SIT_REGISTRO = ' ' 
							ORDER BY COD_BANCO
							, 
							COD_AGENCIA
							, 
							NUM_AVISO
							, 
							DATA_QUITACAO
							, 
							NUM_TITULO";

                return query;
            }
            V0MOVICOB1.GetQueryEvent += GetQuery_V0MOVICOB1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/

        [StopWatch]
        /*" R0610-00-FETCH-MOVICOB-SECTION */
        private void R0610_00_FETCH_MOVICOB_SECTION()
        {
            /*" -1398- MOVE '0610' TO WNR-EXEC-SQL. */
            _.Move("0610", W.WABEND.WNR_EXEC_SQL);

            /*" -1403- PERFORM R0610_00_FETCH_MOVICOB_DB_FETCH_1 */

            R0610_00_FETCH_MOVICOB_DB_FETCH_1();

            /*" -1407- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1407- PERFORM R0610_00_FETCH_MOVICOB_DB_CLOSE_1 */

                R0610_00_FETCH_MOVICOB_DB_CLOSE_1();

                /*" -1409- MOVE 'S' TO WFIM-MOVIMENTO */
                _.Move("S", W.WFIM_MOVIMENTO);

                /*" -1413- MOVE 9999 TO ATU-BCOAVISO ATU-AGEAVISO ATU-ORIGEM ATU-NRSEQ */
                _.Move(9999, W.WS_CHAVE_ATU.ATU_BCOAVISO, W.WS_CHAVE_ATU.ATU_AGEAVISO, W.WS_CHAVE_ATU.ATU_ORIGEM, W.WS_CHAVE_ATU.ATU_NRSEQ);

                /*" -1414- MOVE 999999999 TO ATU-NRAVISO */
                _.Move(999999999, W.WS_CHAVE_ATU.ATU_NRAVISO);

                /*" -1416- GO TO R0610-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0610_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1417- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1418- DISPLAY 'R0610-00 - PROBLEMAS FETCH   (MOVICOB)    ' */
                _.Display($"R0610-00 - PROBLEMAS FETCH   (MOVICOB)    ");

                /*" -1421- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1424- ADD 1 TO LD-MOVICOB. */
            W.LD_MOVICOB.Value = W.LD_MOVICOB + 1;

            /*" -1427- MOVE ZEROS TO ATU-ORIGEM ATU-NRSEQ. */
            _.Move(0, W.WS_CHAVE_ATU.ATU_ORIGEM, W.WS_CHAVE_ATU.ATU_NRSEQ);

            /*" -1430- MOVE MOVIMCOB-COD-BANCO TO RCAPCOMP-BCO-AVISO ATU-BCOAVISO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO, W.WS_CHAVE_ATU.ATU_BCOAVISO);

            /*" -1433- MOVE MOVIMCOB-COD-AGENCIA TO RCAPCOMP-AGE-AVISO ATU-AGEAVISO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO, W.WS_CHAVE_ATU.ATU_AGEAVISO);

            /*" -1435- MOVE MOVIMCOB-NUM-AVISO TO RCAPCOMP-NUM-AVISO-CREDITO ATU-NRAVISO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO, W.WS_CHAVE_ATU.ATU_NRAVISO);

        }

        [StopWatch]
        /*" R0610-00-FETCH-MOVICOB-DB-FETCH-1 */
        public void R0610_00_FETCH_MOVICOB_DB_FETCH_1()
        {
            /*" -1403- EXEC SQL FETCH V0MOVICOB INTO :MOVIMCOB-COD-BANCO , :MOVIMCOB-COD-AGENCIA , :MOVIMCOB-NUM-AVISO , :MOVIMCOB-VAL-TITULO END-EXEC. */

            if (V0MOVICOB.Fetch())
            {
                _.Move(V0MOVICOB.MOVIMCOB_COD_BANCO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO);
                _.Move(V0MOVICOB.MOVIMCOB_COD_AGENCIA, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA);
                _.Move(V0MOVICOB.MOVIMCOB_NUM_AVISO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO);
                _.Move(V0MOVICOB.MOVIMCOB_VAL_TITULO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO);
            }

        }

        [StopWatch]
        /*" R0610-00-FETCH-MOVICOB-DB-CLOSE-1 */
        public void R0610_00_FETCH_MOVICOB_DB_CLOSE_1()
        {
            /*" -1407- EXEC SQL CLOSE V0MOVICOB END-EXEC */

            V0MOVICOB.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0610_99_SAIDA*/

        [StopWatch]
        /*" R0650-00-PROCESSA-MOVICOB-SECTION */
        private void R0650_00_PROCESSA_MOVICOB_SECTION()
        {
            /*" -1448- MOVE '0650' TO WNR-EXEC-SQL. */
            _.Move("0650", W.WABEND.WNR_EXEC_SQL);

            /*" -1451- PERFORM R0460-00-SELECT-V0AVISOCRE. */

            R0460_00_SELECT_V0AVISOCRE_SECTION();

            /*" -1453- MOVE 04 TO SOR-TIPOREG. */
            _.Move(04, REG_ARQSORT.SOR_TIPOREG);

            /*" -1455- MOVE AVISOCRE-BCO-AVISO TO SOR-BCOAVISO. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_BCO_AVISO, REG_ARQSORT.SOR_BCOAVISO);

            /*" -1457- MOVE AVISOCRE-AGE-AVISO TO SOR-AGEAVISO. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_AGE_AVISO, REG_ARQSORT.SOR_AGEAVISO);

            /*" -1459- MOVE AVISOCRE-NUM-AVISO-CREDITO TO SOR-NRAVISO. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO, REG_ARQSORT.SOR_NRAVISO);

            /*" -1461- MOVE AVISOCRE-NUM-SEQUENCIA TO SOR-NRSEQ. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_SEQUENCIA, REG_ARQSORT.SOR_NRSEQ);

            /*" -1463- MOVE AVISOCRE-ORIGEM-AVISO TO SOR-ORIGEM. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_ORIGEM_AVISO, REG_ARQSORT.SOR_ORIGEM);

            /*" -1465- MOVE AVISOCRE-TIPO-AVISO TO SOR-TIPOAVI. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_TIPO_AVISO, REG_ARQSORT.SOR_TIPOAVI);

            /*" -1467- MOVE AVISOCRE-DATA-MOVIMENTO TO SOR-DTMOVTO. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_MOVIMENTO, REG_ARQSORT.SOR_DTMOVTO);

            /*" -1469- MOVE AVISOCRE-DATA-AVISO TO SOR-DTAVISO. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_AVISO, REG_ARQSORT.SOR_DTAVISO);

            /*" -1471- MOVE AVISOCRE-PRM-TOTAL TO SOR-VLPRMTOT. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_TOTAL, REG_ARQSORT.SOR_VLPRMTOT);

            /*" -1473- MOVE AVISOCRE-VAL-DESPESA TO SOR-VLDESPES. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_VAL_DESPESA, REG_ARQSORT.SOR_VLDESPES);

            /*" -1475- MOVE AVISOCRE-PRM-LIQUIDO TO SOR-VLPRMLIQ. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_LIQUIDO, REG_ARQSORT.SOR_VLPRMLIQ);

            /*" -1477- MOVE AVISOSAL-SALDO-ATUAL TO SOR-SDOATU. */
            _.Move(AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SALDO_ATUAL, REG_ARQSORT.SOR_SDOATU);

            /*" -1479- MOVE AVISOSAL-SIT-REGISTRO TO SOR-SITUACAO. */
            _.Move(AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SIT_REGISTRO, REG_ARQSORT.SOR_SITUACAO);

            /*" -1485- MOVE ZEROS TO SOR-VLFOLLOW SOR-VLRCAP SOR-VLDEMAIS. */
            _.Move(0, REG_ARQSORT.SOR_VLFOLLOW, REG_ARQSORT.SOR_VLRCAP, REG_ARQSORT.SOR_VLDEMAIS);

            /*" -1487- MOVE WS-CHAVE-ATU TO WS-CHAVE-ANT. */
            _.Move(W.WS_CHAVE_ATU, W.WS_CHAVE_ANT);

            /*" -1492- PERFORM R0670-00-ACUMULA-MOVICOB UNTIL WS-CHAVE-ATU NOT EQUAL WS-CHAVE-ANT OR WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(W.WS_CHAVE_ATU != W.WS_CHAVE_ANT || !W.WFIM_MOVIMENTO.IsEmpty()))
            {

                R0670_00_ACUMULA_MOVICOB_SECTION();
            }

            /*" -1494- RELEASE REG-ARQSORT. */
            ARQSORT.Release(REG_ARQSORT);

            /*" -1495- ADD 1 TO GV-MOVICOB GV-SORT. */
            W.GV_MOVICOB.Value = W.GV_MOVICOB + 1;
            W.GV_SORT.Value = W.GV_SORT + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0650_99_SAIDA*/

        [StopWatch]
        /*" R0670-00-ACUMULA-MOVICOB-SECTION */
        private void R0670_00_ACUMULA_MOVICOB_SECTION()
        {
            /*" -1508- MOVE '0670' TO WNR-EXEC-SQL. */
            _.Move("0670", W.WABEND.WNR_EXEC_SQL);

            /*" -1509- ADD MOVIMCOB-VAL-TITULO TO SOR-VLDEMAIS. */
            REG_ARQSORT.SOR_VLDEMAIS.Value = REG_ARQSORT.SOR_VLDEMAIS + MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO;

            /*" -0- FLUXCONTROL_PERFORM R0670_90_LEITURA */

            R0670_90_LEITURA();

        }

        [StopWatch]
        /*" R0670-90-LEITURA */
        private void R0670_90_LEITURA(bool isPerform = false)
        {
            /*" -1514- PERFORM R0610-00-FETCH-MOVICOB. */

            R0610_00_FETCH_MOVICOB_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0670_99_SAIDA*/

        [StopWatch]
        /*" R0950-00-OUTPUT-SORT-SECTION */
        private void R0950_00_OUTPUT_SORT_SECTION()
        {
            /*" -1526- MOVE '0950' TO WNR-EXEC-SQL. */
            _.Move("0950", W.WABEND.WNR_EXEC_SQL);

            /*" -1534- MOVE ZEROS TO GE-SDOATU GE-SDOTOT GE-VLFOLLOW GE-VLRCAP GE-VLDEMAIS GE-VLONLINE. */
            _.Move(0, W.GE_SDOATU, W.GE_SDOTOT, W.GE_VLFOLLOW, W.GE_VLRCAP, W.GE_VLDEMAIS, W.GE_VLONLINE);

            /*" -1535- MOVE SPACES TO WFIM-SORT. */
            _.Move("", W.WFIM_SORT);

            /*" -1538- PERFORM R1000-00-LE-ARQSORT. */

            R1000_00_LE_ARQSORT_SECTION();

            /*" -1539- IF WFIM-SORT NOT EQUAL SPACES */

            if (!W.WFIM_SORT.IsEmpty())
            {

                /*" -1542- GO TO R0950-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0950_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1543- WRITE REG-CB0155B1 FROM LC01. */
            _.Move(W.LC01.GetMoveValues(), REG_CB0155B1);

            CB0155B1.Write(REG_CB0155B1.GetMoveValues().ToString());

            /*" -1545- WRITE REG-CB0155B1 FROM LC02. */
            _.Move(W.LC02.GetMoveValues(), REG_CB0155B1);

            CB0155B1.Write(REG_CB0155B1.GetMoveValues().ToString());

            /*" -1546- WRITE REG-CB0155B2 FROM LC01. */
            _.Move(W.LC01.GetMoveValues(), REG_CB0155B2);

            CB0155B2.Write(REG_CB0155B2.GetMoveValues().ToString());

            /*" -1549- WRITE REG-CB0155B2 FROM LC03. */
            _.Move(W.LC03.GetMoveValues(), REG_CB0155B2);

            CB0155B2.Write(REG_CB0155B2.GetMoveValues().ToString());

            /*" -1553- PERFORM R1010-00-PROCESSA-SORT UNTIL WFIM-SORT NOT EQUAL SPACES. */

            while (!(!W.WFIM_SORT.IsEmpty()))
            {

                R1010_00_PROCESSA_SORT_SECTION();
            }

            /*" -1554- MOVE LT02 TO LT01. */
            _.Move(W.LT02, W.LT01);

            /*" -1556- MOVE 'TOTAL GERAL ' TO LT01-DESCORIGEM. */
            _.Move("TOTAL GERAL ", W.LT01.LT01_DESCORIGEM);

            /*" -1562- COMPUTE GE-SDOTOT EQUAL (GE-VLFOLLOW + GE-VLRCAP + GE-VLDEMAIS + GE-VLONLINE). */
            W.GE_SDOTOT.Value = (W.GE_VLFOLLOW + W.GE_VLRCAP + W.GE_VLDEMAIS + W.GE_VLONLINE);

            /*" -1563- MOVE GE-SDOATU TO LT01-SDOATU. */
            _.Move(W.GE_SDOATU, W.LT01.LT01_SDOATU);

            /*" -1564- MOVE GE-SDOTOT TO LT01-SDOTOT. */
            _.Move(W.GE_SDOTOT, W.LT01.LT01_SDOTOT);

            /*" -1565- MOVE GE-VLFOLLOW TO LT01-VLFOLLOW. */
            _.Move(W.GE_VLFOLLOW, W.LT01.LT01_VLFOLLOW);

            /*" -1566- MOVE GE-VLRCAP TO LT01-VLRCAP. */
            _.Move(W.GE_VLRCAP, W.LT01.LT01_VLRCAP);

            /*" -1567- MOVE GE-VLDEMAIS TO LT01-VLDEMAIS. */
            _.Move(W.GE_VLDEMAIS, W.LT01.LT01_VLDEMAIS);

            /*" -1569- MOVE GE-VLONLINE TO LT01-VLONLINE. */
            _.Move(W.GE_VLONLINE, W.LT01.LT01_VLONLINE);

            /*" -1570- WRITE REG-CB0155B2 FROM LT01. */
            _.Move(W.LT01.GetMoveValues(), REG_CB0155B2);

            CB0155B2.Write(REG_CB0155B2.GetMoveValues().ToString());

            /*" -1573- ADD 1 TO GV-ARQSAI2. */
            W.GV_ARQSAI2.Value = W.GV_ARQSAI2 + 1;

            /*" -1573- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1577- DISPLAY ' ' */
            _.Display($" ");

            /*" -1578- DISPLAY 'LIDOS SORT ................. ' LD-SORT */
            _.Display($"LIDOS SORT ................. {W.LD_SORT}");

            /*" -1579- DISPLAY 'GRAVA ARQUIVO 01 ........... ' GV-ARQSAI1 */
            _.Display($"GRAVA ARQUIVO 01 ........... {W.GV_ARQSAI1}");

            /*" -1580- DISPLAY 'GRAVA ARQUIVO 02 ........... ' GV-ARQSAI2 */
            _.Display($"GRAVA ARQUIVO 02 ........... {W.GV_ARQSAI2}");

            /*" -1580- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0950_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-LE-ARQSORT-SECTION */
        private void R1000_00_LE_ARQSORT_SECTION()
        {
            /*" -1592- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", W.WABEND.WNR_EXEC_SQL);

            /*" -1594- RETURN ARQSORT AT END */
            try
            {
                ARQSORT.Return(REG_ARQSORT, () =>
                {

                    /*" -1595- MOVE 'S' TO WFIM-SORT */
                    _.Move("S", W.WFIM_SORT);

                    /*" -1599- MOVE 9999 TO ATU-BCOAVISO ATU-AGEAVISO ATU-ORIGEM ATU-NRSEQ */
                    _.Move(9999, W.WS_CHAVE_ATU.ATU_BCOAVISO, W.WS_CHAVE_ATU.ATU_AGEAVISO, W.WS_CHAVE_ATU.ATU_ORIGEM, W.WS_CHAVE_ATU.ATU_NRSEQ);

                    /*" -1600- MOVE 999999999 TO ATU-NRAVISO */
                    _.Move(999999999, W.WS_CHAVE_ATU.ATU_NRAVISO);

                    /*" -1603- GO TO R1000-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                    return;

                });
            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -1604- MOVE SOR-BCOAVISO TO ATU-BCOAVISO. */
            _.Move(REG_ARQSORT.SOR_BCOAVISO, W.WS_CHAVE_ATU.ATU_BCOAVISO);

            /*" -1605- MOVE SOR-AGEAVISO TO ATU-AGEAVISO. */
            _.Move(REG_ARQSORT.SOR_AGEAVISO, W.WS_CHAVE_ATU.ATU_AGEAVISO);

            /*" -1606- MOVE SOR-NRAVISO TO ATU-NRAVISO. */
            _.Move(REG_ARQSORT.SOR_NRAVISO, W.WS_CHAVE_ATU.ATU_NRAVISO);

            /*" -1607- MOVE SOR-ORIGEM TO ATU-ORIGEM. */
            _.Move(REG_ARQSORT.SOR_ORIGEM, W.WS_CHAVE_ATU.ATU_ORIGEM);

            /*" -1610- MOVE SOR-NRSEQ TO ATU-NRSEQ. */
            _.Move(REG_ARQSORT.SOR_NRSEQ, W.WS_CHAVE_ATU.ATU_NRSEQ);

            /*" -1610- ADD 1 TO LD-SORT. */
            W.LD_SORT.Value = W.LD_SORT + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1010-00-PROCESSA-SORT-SECTION */
        private void R1010_00_PROCESSA_SORT_SECTION()
        {
            /*" -1623- MOVE '1010' TO WNR-EXEC-SQL. */
            _.Move("1010", W.WABEND.WNR_EXEC_SQL);

            /*" -1631- MOVE ZEROS TO OR-SDOATU OR-SDOTOT OR-VLFOLLOW OR-VLRCAP OR-VLDEMAIS OR-VLONLINE. */
            _.Move(0, W.OR_SDOATU, W.OR_SDOTOT, W.OR_VLFOLLOW, W.OR_VLRCAP, W.OR_VLDEMAIS, W.OR_VLONLINE);

            /*" -1634- MOVE SOR-ORIGEM TO ORIGEAVI-ORIGEM-AVISO. */
            _.Move(REG_ARQSORT.SOR_ORIGEM, ORIGEAVI.DCLORIGEM_AVISO.ORIGEAVI_ORIGEM_AVISO);

            /*" -1637- PERFORM R1015-00-SELECT-V0ORIGEM. */

            R1015_00_SELECT_V0ORIGEM_SECTION();

            /*" -1639- MOVE ATU-ORIGEM TO ANT-ORIGEM. */
            _.Move(W.WS_CHAVE_ATU.ATU_ORIGEM, W.WS_CHAVE_ANT.ANT_ORIGEM);

            /*" -1644- PERFORM R1030-00-PROCESSA-ORIGEM UNTIL ATU-ORIGEM NOT EQUAL ANT-ORIGEM OR WFIM-SORT NOT EQUAL SPACES. */

            while (!(W.WS_CHAVE_ATU.ATU_ORIGEM != W.WS_CHAVE_ANT.ANT_ORIGEM || !W.WFIM_SORT.IsEmpty()))
            {

                R1030_00_PROCESSA_ORIGEM_SECTION();
            }

            /*" -1645- MOVE LT02 TO LT01. */
            _.Move(W.LT02, W.LT01);

            /*" -1646- MOVE ANT-ORIGEM TO LT01-ORIGEM. */
            _.Move(W.WS_CHAVE_ANT.ANT_ORIGEM, W.LT01.LT01_ORIGEM);

            /*" -1649- MOVE ORIGEAVI-DESCRICAO-ORIGEM TO LT01-DESCORIGEM. */
            _.Move(ORIGEAVI.DCLORIGEM_AVISO.ORIGEAVI_DESCRICAO_ORIGEM, W.LT01.LT01_DESCORIGEM);

            /*" -1655- COMPUTE OR-SDOTOT EQUAL (OR-VLFOLLOW + OR-VLRCAP + OR-VLDEMAIS + OR-VLONLINE). */
            W.OR_SDOTOT.Value = (W.OR_VLFOLLOW + W.OR_VLRCAP + W.OR_VLDEMAIS + W.OR_VLONLINE);

            /*" -1656- MOVE OR-SDOATU TO LT01-SDOATU. */
            _.Move(W.OR_SDOATU, W.LT01.LT01_SDOATU);

            /*" -1657- MOVE OR-SDOTOT TO LT01-SDOTOT. */
            _.Move(W.OR_SDOTOT, W.LT01.LT01_SDOTOT);

            /*" -1658- MOVE OR-VLFOLLOW TO LT01-VLFOLLOW. */
            _.Move(W.OR_VLFOLLOW, W.LT01.LT01_VLFOLLOW);

            /*" -1659- MOVE OR-VLRCAP TO LT01-VLRCAP. */
            _.Move(W.OR_VLRCAP, W.LT01.LT01_VLRCAP);

            /*" -1660- MOVE OR-VLDEMAIS TO LT01-VLDEMAIS. */
            _.Move(W.OR_VLDEMAIS, W.LT01.LT01_VLDEMAIS);

            /*" -1662- MOVE OR-VLONLINE TO LT01-VLONLINE. */
            _.Move(W.OR_VLONLINE, W.LT01.LT01_VLONLINE);

            /*" -1663- WRITE REG-CB0155B2 FROM LT01. */
            _.Move(W.LT01.GetMoveValues(), REG_CB0155B2);

            CB0155B2.Write(REG_CB0155B2.GetMoveValues().ToString());

            /*" -1663- ADD 1 TO GV-ARQSAI2. */
            W.GV_ARQSAI2.Value = W.GV_ARQSAI2 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_99_SAIDA*/

        [StopWatch]
        /*" R1015-00-SELECT-V0ORIGEM-SECTION */
        private void R1015_00_SELECT_V0ORIGEM_SECTION()
        {
            /*" -1675- MOVE '1015' TO WNR-EXEC-SQL. */
            _.Move("1015", W.WABEND.WNR_EXEC_SQL);

            /*" -1681- PERFORM R1015_00_SELECT_V0ORIGEM_DB_SELECT_1 */

            R1015_00_SELECT_V0ORIGEM_DB_SELECT_1();

            /*" -1685- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1687- DISPLAY 'R1015-00 - PROBLEMAS NO SELECT(ORIGEAVI)  ' '  ' ORIGEAVI-ORIGEM-AVISO */

                $"R1015-00 - PROBLEMAS NO SELECT(ORIGEAVI)    {ORIGEAVI.DCLORIGEM_AVISO.ORIGEAVI_ORIGEM_AVISO}"
                .Display();

                /*" -1688- MOVE 'NAO CADASTRADO ' TO ORIGEAVI-DESCRICAO-ORIGEM. */
                _.Move("NAO CADASTRADO ", ORIGEAVI.DCLORIGEM_AVISO.ORIGEAVI_DESCRICAO_ORIGEM);
            }


        }

        [StopWatch]
        /*" R1015-00-SELECT-V0ORIGEM-DB-SELECT-1 */
        public void R1015_00_SELECT_V0ORIGEM_DB_SELECT_1()
        {
            /*" -1681- EXEC SQL SELECT DESCRICAO_ORIGEM INTO :ORIGEAVI-DESCRICAO-ORIGEM FROM SEGUROS.ORIGEM_AVISO WHERE ORIGEM_AVISO = :ORIGEAVI-ORIGEM-AVISO AND COD_EMPRESA = 0 END-EXEC. */

            var r1015_00_SELECT_V0ORIGEM_DB_SELECT_1_Query1 = new R1015_00_SELECT_V0ORIGEM_DB_SELECT_1_Query1()
            {
                ORIGEAVI_ORIGEM_AVISO = ORIGEAVI.DCLORIGEM_AVISO.ORIGEAVI_ORIGEM_AVISO.ToString(),
            };

            var executed_1 = R1015_00_SELECT_V0ORIGEM_DB_SELECT_1_Query1.Execute(r1015_00_SELECT_V0ORIGEM_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ORIGEAVI_DESCRICAO_ORIGEM, ORIGEAVI.DCLORIGEM_AVISO.ORIGEAVI_DESCRICAO_ORIGEM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1015_99_SAIDA*/

        [StopWatch]
        /*" R1030-00-PROCESSA-ORIGEM-SECTION */
        private void R1030_00_PROCESSA_ORIGEM_SECTION()
        {
            /*" -1701- MOVE '1030' TO WNR-EXEC-SQL. */
            _.Move("1030", W.WABEND.WNR_EXEC_SQL);

            /*" -1702- MOVE ATU-BCOAVISO TO ANT-BCOAVISO. */
            _.Move(W.WS_CHAVE_ATU.ATU_BCOAVISO, W.WS_CHAVE_ANT.ANT_BCOAVISO);

            /*" -1703- MOVE ATU-AGEAVISO TO ANT-AGEAVISO. */
            _.Move(W.WS_CHAVE_ATU.ATU_AGEAVISO, W.WS_CHAVE_ANT.ANT_AGEAVISO);

            /*" -1704- MOVE ATU-NRAVISO TO ANT-NRAVISO. */
            _.Move(W.WS_CHAVE_ATU.ATU_NRAVISO, W.WS_CHAVE_ANT.ANT_NRAVISO);

            /*" -1706- MOVE ATU-NRSEQ TO ANT-NRSEQ. */
            _.Move(W.WS_CHAVE_ATU.ATU_NRSEQ, W.WS_CHAVE_ANT.ANT_NRSEQ);

            /*" -1707- MOVE LD02 TO LD01. */
            _.Move(W.LD02, W.LD01);

            /*" -1708- MOVE SOR-BCOAVISO TO LD01-BCOAVISO. */
            _.Move(REG_ARQSORT.SOR_BCOAVISO, W.LD01.LD01_BCOAVISO);

            /*" -1709- MOVE SOR-AGEAVISO TO LD01-AGEAVISO. */
            _.Move(REG_ARQSORT.SOR_AGEAVISO, W.LD01.LD01_AGEAVISO);

            /*" -1710- MOVE SOR-NRAVISO TO LD01-NRAVISO. */
            _.Move(REG_ARQSORT.SOR_NRAVISO, W.LD01.LD01_NRAVISO);

            /*" -1711- MOVE SOR-ORIGEM TO LD01-ORIGEM. */
            _.Move(REG_ARQSORT.SOR_ORIGEM, W.LD01.LD01_ORIGEM);

            /*" -1713- MOVE ORIGEAVI-DESCRICAO-ORIGEM TO LD01-DESCORIGEM. */
            _.Move(ORIGEAVI.DCLORIGEM_AVISO.ORIGEAVI_DESCRICAO_ORIGEM, W.LD01.LD01_DESCORIGEM);

            /*" -1715- MOVE SOR-VLPRMTOT TO LD01-VLPRMTOT WS-VLPRMTOT. */
            _.Move(REG_ARQSORT.SOR_VLPRMTOT, W.LD01.LD01_VLPRMTOT, W.WS_VLPRMTOT);

            /*" -1716- MOVE SOR-VLDESPES TO LD01-VLDESPES. */
            _.Move(REG_ARQSORT.SOR_VLDESPES, W.LD01.LD01_VLDESPES);

            /*" -1717- MOVE SOR-VLPRMLIQ TO LD01-VLPRMLIQ. */
            _.Move(REG_ARQSORT.SOR_VLPRMLIQ, W.LD01.LD01_VLPRMLIQ);

            /*" -1719- MOVE SOR-SDOATU TO LD01-SDOATU WS-SDOATU. */
            _.Move(REG_ARQSORT.SOR_SDOATU, W.LD01.LD01_SDOATU, W.WS_SDOATU);

            /*" -1721- ADD SOR-SDOATU TO OR-SDOATU GE-SDOATU. */
            W.OR_SDOATU.Value = W.OR_SDOATU + REG_ARQSORT.SOR_SDOATU;
            W.GE_SDOATU.Value = W.GE_SDOATU + REG_ARQSORT.SOR_SDOATU;

            /*" -1730- MOVE ZEROS TO LD01-VLFOLLOW LD01-VLRCAP LD01-VLDEMAIS WS-VALOR WS-VLFOLLOW WS-VLRCAP WS-VLDEMAIS. */
            _.Move(0, W.LD01.LD01_VLFOLLOW, W.LD01.LD01_VLRCAP, W.LD01.LD01_VLDEMAIS, W.WS_VALOR, W.WS_VLFOLLOW, W.WS_VLRCAP, W.WS_VLDEMAIS);

            /*" -1731- IF SOR-TIPOAVI EQUAL 'C' */

            if (REG_ARQSORT.SOR_TIPOAVI == "C")
            {

                /*" -1732- MOVE 'CREDITO   ' TO LD01-TIPOAVI */
                _.Move("CREDITO   ", W.LD01.LD01_TIPOAVI);

                /*" -1733- ELSE */
            }
            else
            {


                /*" -1734- IF SOR-TIPOAVI EQUAL 'R' */

                if (REG_ARQSORT.SOR_TIPOAVI == "R")
                {

                    /*" -1735- MOVE 'RECIBO    ' TO LD01-TIPOAVI */
                    _.Move("RECIBO    ", W.LD01.LD01_TIPOAVI);

                    /*" -1736- ELSE */
                }
                else
                {


                    /*" -1737- IF SOR-TIPOAVI EQUAL 'D' */

                    if (REG_ARQSORT.SOR_TIPOAVI == "D")
                    {

                        /*" -1738- MOVE 'DEBITO    ' TO LD01-TIPOAVI */
                        _.Move("DEBITO    ", W.LD01.LD01_TIPOAVI);

                        /*" -1739- ELSE */
                    }
                    else
                    {


                        /*" -1741- MOVE 'OUTROS    ' TO LD01-TIPOAVI. */
                        _.Move("OUTROS    ", W.LD01.LD01_TIPOAVI);
                    }

                }

            }


            /*" -1742- IF SOR-DTMOVTO NOT EQUAL SPACES */

            if (!REG_ARQSORT.SOR_DTMOVTO.IsEmpty())
            {

                /*" -1743- MOVE SOR-DTMOVTO TO WDATA-REL */
                _.Move(REG_ARQSORT.SOR_DTMOVTO, W.WDATA_REL);

                /*" -1744- MOVE WDAT-REL-DIA TO WDATA-DD-CABEC */
                _.Move(W.FILLER_0.WDAT_REL_DIA, W.WDATA_CABEC.WDATA_DD_CABEC);

                /*" -1745- MOVE WDAT-REL-MES TO WDATA-MM-CABEC */
                _.Move(W.FILLER_0.WDAT_REL_MES, W.WDATA_CABEC.WDATA_MM_CABEC);

                /*" -1746- MOVE WDAT-REL-ANO TO WDATA-AA-CABEC */
                _.Move(W.FILLER_0.WDAT_REL_ANO, W.WDATA_CABEC.WDATA_AA_CABEC);

                /*" -1748- MOVE WDATA-CABEC TO LD01-DTMOVTO. */
                _.Move(W.WDATA_CABEC, W.LD01.LD01_DTMOVTO);
            }


            /*" -1749- IF SOR-DTAVISO NOT EQUAL SPACES */

            if (!REG_ARQSORT.SOR_DTAVISO.IsEmpty())
            {

                /*" -1750- MOVE SOR-DTAVISO TO WDATA-REL */
                _.Move(REG_ARQSORT.SOR_DTAVISO, W.WDATA_REL);

                /*" -1751- MOVE WDAT-REL-DIA TO WDATA-DD-CABEC */
                _.Move(W.FILLER_0.WDAT_REL_DIA, W.WDATA_CABEC.WDATA_DD_CABEC);

                /*" -1752- MOVE WDAT-REL-MES TO WDATA-MM-CABEC */
                _.Move(W.FILLER_0.WDAT_REL_MES, W.WDATA_CABEC.WDATA_MM_CABEC);

                /*" -1753- MOVE WDAT-REL-ANO TO WDATA-AA-CABEC */
                _.Move(W.FILLER_0.WDAT_REL_ANO, W.WDATA_CABEC.WDATA_AA_CABEC);

                /*" -1756- MOVE WDATA-CABEC TO LD01-DTAVISO. */
                _.Move(W.WDATA_CABEC, W.LD01.LD01_DTAVISO);
            }


            /*" -1757- IF SOR-SITUACAO NOT EQUAL '0' */

            if (REG_ARQSORT.SOR_SITUACAO != "0")
            {

                /*" -1758- MOVE 'CANCELADO ' TO LD01-SITUACAO */
                _.Move("CANCELADO ", W.LD01.LD01_SITUACAO);

                /*" -1759- ELSE */
            }
            else
            {


                /*" -1762- MOVE SPACES TO LD01-SITUACAO. */
                _.Move("", W.LD01.LD01_SITUACAO);
            }


            /*" -1767- PERFORM R1050-00-PROCESSA-AVISO UNTIL WS-CHAVE-ATU NOT EQUAL WS-CHAVE-ANT OR WFIM-SORT NOT EQUAL SPACES. */

            while (!(W.WS_CHAVE_ATU != W.WS_CHAVE_ANT || !W.WFIM_SORT.IsEmpty()))
            {

                R1050_00_PROCESSA_AVISO_SECTION();
            }

            /*" -1768- IF LD01-SITUACAO NOT EQUAL SPACES */

            if (!W.LD01.LD01_SITUACAO.IsEmpty())
            {

                /*" -1770- ADD WS-SDOATU TO OR-VLONLINE GE-VLONLINE */
                W.OR_VLONLINE.Value = W.OR_VLONLINE + W.WS_SDOATU;
                W.GE_VLONLINE.Value = W.GE_VLONLINE + W.WS_SDOATU;

                /*" -1771- WRITE REG-CB0155B1 FROM LD01 */
                _.Move(W.LD01.GetMoveValues(), REG_CB0155B1);

                CB0155B1.Write(REG_CB0155B1.GetMoveValues().ToString());

                /*" -1772- ADD 1 TO GV-ARQSAI1 */
                W.GV_ARQSAI1.Value = W.GV_ARQSAI1 + 1;

                /*" -1775- GO TO R1030-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1030_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1776- IF WS-VLPRMTOT EQUAL ZEROS */

            if (W.WS_VLPRMTOT == 00)
            {

                /*" -1777- MOVE 'VLR ZERO  ' TO LD01-SITUACAO */
                _.Move("VLR ZERO  ", W.LD01.LD01_SITUACAO);

                /*" -1779- ADD WS-SDOATU TO OR-VLONLINE GE-VLONLINE */
                W.OR_VLONLINE.Value = W.OR_VLONLINE + W.WS_SDOATU;
                W.GE_VLONLINE.Value = W.GE_VLONLINE + W.WS_SDOATU;

                /*" -1780- WRITE REG-CB0155B1 FROM LD01 */
                _.Move(W.LD01.GetMoveValues(), REG_CB0155B1);

                CB0155B1.Write(REG_CB0155B1.GetMoveValues().ToString());

                /*" -1781- ADD 1 TO GV-ARQSAI1 */
                W.GV_ARQSAI1.Value = W.GV_ARQSAI1 + 1;

                /*" -1784- GO TO R1030-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1030_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1784- PERFORM R1500-00-TRATA-CADASTRO. */

            R1500_00_TRATA_CADASTRO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1030_99_SAIDA*/

        [StopWatch]
        /*" R1050-00-PROCESSA-AVISO-SECTION */
        private void R1050_00_PROCESSA_AVISO_SECTION()
        {
            /*" -1797- MOVE '1050' TO WNR-EXEC-SQL. */
            _.Move("1050", W.WABEND.WNR_EXEC_SQL);

            /*" -1798- IF SOR-TIPOREG EQUAL 02 */

            if (REG_ARQSORT.SOR_TIPOREG == 02)
            {

                /*" -1800- MOVE SOR-VLRCAP TO LD01-VLRCAP WS-VLRCAP */
                _.Move(REG_ARQSORT.SOR_VLRCAP, W.LD01.LD01_VLRCAP, W.WS_VLRCAP);

                /*" -1802- ADD SOR-VLRCAP TO OR-VLRCAP GE-VLRCAP */
                W.OR_VLRCAP.Value = W.OR_VLRCAP + REG_ARQSORT.SOR_VLRCAP;
                W.GE_VLRCAP.Value = W.GE_VLRCAP + REG_ARQSORT.SOR_VLRCAP;

                /*" -1803- ELSE */
            }
            else
            {


                /*" -1804- IF SOR-TIPOREG EQUAL 03 */

                if (REG_ARQSORT.SOR_TIPOREG == 03)
                {

                    /*" -1806- MOVE SOR-VLFOLLOW TO LD01-VLFOLLOW WS-VLFOLLOW */
                    _.Move(REG_ARQSORT.SOR_VLFOLLOW, W.LD01.LD01_VLFOLLOW, W.WS_VLFOLLOW);

                    /*" -1808- ADD SOR-VLFOLLOW TO OR-VLFOLLOW GE-VLFOLLOW */
                    W.OR_VLFOLLOW.Value = W.OR_VLFOLLOW + REG_ARQSORT.SOR_VLFOLLOW;
                    W.GE_VLFOLLOW.Value = W.GE_VLFOLLOW + REG_ARQSORT.SOR_VLFOLLOW;

                    /*" -1809- ELSE */
                }
                else
                {


                    /*" -1810- IF SOR-TIPOREG EQUAL 04 */

                    if (REG_ARQSORT.SOR_TIPOREG == 04)
                    {

                        /*" -1812- MOVE SOR-VLDEMAIS TO LD01-VLDEMAIS WS-VLDEMAIS */
                        _.Move(REG_ARQSORT.SOR_VLDEMAIS, W.LD01.LD01_VLDEMAIS, W.WS_VLDEMAIS);

                        /*" -1813- ADD SOR-VLDEMAIS TO OR-VLDEMAIS GE-VLDEMAIS. */
                        W.OR_VLDEMAIS.Value = W.OR_VLDEMAIS + REG_ARQSORT.SOR_VLDEMAIS;
                        W.GE_VLDEMAIS.Value = W.GE_VLDEMAIS + REG_ARQSORT.SOR_VLDEMAIS;
                    }

                }

            }


            /*" -0- FLUXCONTROL_PERFORM R1050_90_LEITURA */

            R1050_90_LEITURA();

        }

        [StopWatch]
        /*" R1050-90-LEITURA */
        private void R1050_90_LEITURA(bool isPerform = false)
        {
            /*" -1818- PERFORM R1000-00-LE-ARQSORT. */

            R1000_00_LE_ARQSORT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1050_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-TRATA-CADASTRO-SECTION */
        private void R1500_00_TRATA_CADASTRO_SECTION()
        {
            /*" -1830- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", W.WABEND.WNR_EXEC_SQL);

            /*" -1834- COMPUTE WS-VALOR EQUAL (WS-VLRCAP + WS-VLFOLLOW + WS-VLDEMAIS). */
            W.WS_VALOR.Value = (W.WS_VLRCAP + W.WS_VLFOLLOW + W.WS_VLDEMAIS);

            /*" -1835- IF LD01-TIPOAVI EQUAL 'DEBITO    ' */

            if (W.LD01.LD01_TIPOAVI == "DEBITO    ")
            {

                /*" -1836- IF WS-VALOR NOT EQUAL WS-SDOATU */

                if (W.WS_VALOR != W.WS_SDOATU)
                {

                    /*" -1837- MOVE 'DIV DEBITO' TO LD01-SITUACAO */
                    _.Move("DIV DEBITO", W.LD01.LD01_SITUACAO);

                    /*" -1838- WRITE REG-CB0155B1 FROM LD01 */
                    _.Move(W.LD01.GetMoveValues(), REG_CB0155B1);

                    CB0155B1.Write(REG_CB0155B1.GetMoveValues().ToString());

                    /*" -1839- ADD 1 TO GV-ARQSAI1 */
                    W.GV_ARQSAI1.Value = W.GV_ARQSAI1 + 1;

                    /*" -1840- GO TO R1500-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/ //GOTO
                    return;

                    /*" -1841- ELSE */
                }
                else
                {


                    /*" -1842- MOVE 'DEBITO OK ' TO LD01-SITUACAO */
                    _.Move("DEBITO OK ", W.LD01.LD01_SITUACAO);

                    /*" -1843- WRITE REG-CB0155B1 FROM LD01 */
                    _.Move(W.LD01.GetMoveValues(), REG_CB0155B1);

                    CB0155B1.Write(REG_CB0155B1.GetMoveValues().ToString());

                    /*" -1844- ADD 1 TO GV-ARQSAI1 */
                    W.GV_ARQSAI1.Value = W.GV_ARQSAI1 + 1;

                    /*" -1845- GO TO R1500-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/ //GOTO
                    return;

                    /*" -1846- ELSE */
                }

            }
            else
            {


                /*" -1847- IF LD01-TIPOAVI EQUAL 'RECIBO    ' */

                if (W.LD01.LD01_TIPOAVI == "RECIBO    ")
                {

                    /*" -1848- IF WS-VALOR GREATER ZEROS */

                    if (W.WS_VALOR > 00)
                    {

                        /*" -1849- IF WS-VALOR NOT EQUAL WS-SDOATU */

                        if (W.WS_VALOR != W.WS_SDOATU)
                        {

                            /*" -1850- MOVE 'DIVERGE   ' TO LD01-SITUACAO */
                            _.Move("DIVERGE   ", W.LD01.LD01_SITUACAO);

                            /*" -1851- WRITE REG-CB0155B1 FROM LD01 */
                            _.Move(W.LD01.GetMoveValues(), REG_CB0155B1);

                            CB0155B1.Write(REG_CB0155B1.GetMoveValues().ToString());

                            /*" -1852- ADD 1 TO GV-ARQSAI1 */
                            W.GV_ARQSAI1.Value = W.GV_ARQSAI1 + 1;

                            /*" -1853- GO TO R1500-99-SAIDA */
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/ //GOTO
                            return;

                            /*" -1854- ELSE */
                        }
                        else
                        {


                            /*" -1855- MOVE 'SALDO OK  ' TO LD01-SITUACAO */
                            _.Move("SALDO OK  ", W.LD01.LD01_SITUACAO);

                            /*" -1856- WRITE REG-CB0155B1 FROM LD01 */
                            _.Move(W.LD01.GetMoveValues(), REG_CB0155B1);

                            CB0155B1.Write(REG_CB0155B1.GetMoveValues().ToString());

                            /*" -1857- ADD 1 TO GV-ARQSAI1 */
                            W.GV_ARQSAI1.Value = W.GV_ARQSAI1 + 1;

                            /*" -1858- GO TO R1500-99-SAIDA */
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/ //GOTO
                            return;

                            /*" -1860- ELSE NEXT SENTENCE */
                        }

                    }
                    else
                    {


                        /*" -1861- ELSE */
                    }

                }
                else
                {


                    /*" -1862- IF WS-VALOR GREATER ZEROS */

                    if (W.WS_VALOR > 00)
                    {

                        /*" -1863- IF WS-VALOR NOT EQUAL WS-SDOATU */

                        if (W.WS_VALOR != W.WS_SDOATU)
                        {

                            /*" -1864- MOVE 'DIVERGE   ' TO LD01-SITUACAO */
                            _.Move("DIVERGE   ", W.LD01.LD01_SITUACAO);

                            /*" -1865- WRITE REG-CB0155B1 FROM LD01 */
                            _.Move(W.LD01.GetMoveValues(), REG_CB0155B1);

                            CB0155B1.Write(REG_CB0155B1.GetMoveValues().ToString());

                            /*" -1866- ADD 1 TO GV-ARQSAI1 */
                            W.GV_ARQSAI1.Value = W.GV_ARQSAI1 + 1;

                            /*" -1867- GO TO R1500-99-SAIDA */
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/ //GOTO
                            return;

                            /*" -1868- ELSE */
                        }
                        else
                        {


                            /*" -1869- MOVE 'SALDO OK  ' TO LD01-SITUACAO */
                            _.Move("SALDO OK  ", W.LD01.LD01_SITUACAO);

                            /*" -1870- WRITE REG-CB0155B1 FROM LD01 */
                            _.Move(W.LD01.GetMoveValues(), REG_CB0155B1);

                            CB0155B1.Write(REG_CB0155B1.GetMoveValues().ToString());

                            /*" -1871- ADD 1 TO GV-ARQSAI1 */
                            W.GV_ARQSAI1.Value = W.GV_ARQSAI1 + 1;

                            /*" -1874- GO TO R1500-99-SAIDA. */
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/ //GOTO
                            return;
                        }

                    }

                }

            }


            /*" -1875- MOVE SPACES TO WTEM-REGISTRO. */
            _.Move("", W.WTEM_REGISTRO);

            /*" -1877- MOVE ZEROS TO WS-SDOFINAL. */
            _.Move(0, W.WS_SDOFINAL);

            /*" -1878- IF LD01-TIPOAVI EQUAL 'RECIBO    ' */

            if (W.LD01.LD01_TIPOAVI == "RECIBO    ")
            {

                /*" -1879- PERFORM R1600-00-TRATA-RCAPCOMP */

                R1600_00_TRATA_RCAPCOMP_SECTION();

                /*" -1880- ELSE */
            }
            else
            {


                /*" -1881- IF LD01-TIPOAVI EQUAL 'CREDITO   ' */

                if (W.LD01.LD01_TIPOAVI == "CREDITO   ")
                {

                    /*" -1881- PERFORM R1700-00-TRATA-MOVIMCOB. */

                    R1700_00_TRATA_MOVIMCOB_SECTION();
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-TRATA-RCAPCOMP-SECTION */
        private void R1600_00_TRATA_RCAPCOMP_SECTION()
        {
            /*" -1900- MOVE '1600' TO WNR-EXEC-SQL. */
            _.Move("1600", W.WABEND.WNR_EXEC_SQL);

            /*" -1902- PERFORM R1610-00-SELECT-V0RCAPCOMP. */

            R1610_00_SELECT_V0RCAPCOMP_SECTION();

            /*" -1903- IF WTEM-REGISTRO NOT EQUAL SPACES */

            if (!W.WTEM_REGISTRO.IsEmpty())
            {

                /*" -1904- PERFORM R1620-00-SELECT-V0RCAPCOMP */

                R1620_00_SELECT_V0RCAPCOMP_SECTION();

                /*" -1910- PERFORM R1630-00-SELECT-V0RCAPCOMP. */

                R1630_00_SELECT_V0RCAPCOMP_SECTION();
            }


            /*" -1913- PERFORM R1640-00-SELECT-V0FOLLOWUP. */

            R1640_00_SELECT_V0FOLLOWUP_SECTION();

            /*" -1914- IF WTEM-REGISTRO NOT EQUAL 'S' */

            if (W.WTEM_REGISTRO != "S")
            {

                /*" -1915- MOVE 'SEM RCAP  ' TO LD01-SITUACAO */
                _.Move("SEM RCAP  ", W.LD01.LD01_SITUACAO);

                /*" -1917- ADD WS-SDOATU TO OR-VLONLINE GE-VLONLINE */
                W.OR_VLONLINE.Value = W.OR_VLONLINE + W.WS_SDOATU;
                W.GE_VLONLINE.Value = W.GE_VLONLINE + W.WS_SDOATU;

                /*" -1918- WRITE REG-CB0155B1 FROM LD01 */
                _.Move(W.LD01.GetMoveValues(), REG_CB0155B1);

                CB0155B1.Write(REG_CB0155B1.GetMoveValues().ToString());

                /*" -1919- ADD 1 TO GV-ARQSAI1 */
                W.GV_ARQSAI1.Value = W.GV_ARQSAI1 + 1;

                /*" -1922- GO TO R1600-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1923- IF WS-SDOFINAL NOT EQUAL WS-VLPRMTOT */

            if (W.WS_SDOFINAL != W.WS_VLPRMTOT)
            {

                /*" -1924- MOVE WS-SDOFINAL TO LD01-SDOFINAL */
                _.Move(W.WS_SDOFINAL, W.LD01.LD01_SDOFINAL);

                /*" -1925- MOVE 'RCAP DIF  ' TO LD01-SITUACAO */
                _.Move("RCAP DIF  ", W.LD01.LD01_SITUACAO);

                /*" -1927- ADD WS-SDOATU TO OR-VLONLINE GE-VLONLINE */
                W.OR_VLONLINE.Value = W.OR_VLONLINE + W.WS_SDOATU;
                W.GE_VLONLINE.Value = W.GE_VLONLINE + W.WS_SDOATU;

                /*" -1928- WRITE REG-CB0155B1 FROM LD01 */
                _.Move(W.LD01.GetMoveValues(), REG_CB0155B1);

                CB0155B1.Write(REG_CB0155B1.GetMoveValues().ToString());

                /*" -1929- ADD 1 TO GV-ARQSAI1 */
                W.GV_ARQSAI1.Value = W.GV_ARQSAI1 + 1;

                /*" -1932- GO TO R1600-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1934- MOVE SPACES TO WTEM-REGISTRO. */
            _.Move("", W.WTEM_REGISTRO);

            /*" -1941- MOVE WS-VLPRMTOT TO WS-SDOFINAL. */
            _.Move(W.WS_VLPRMTOT, W.WS_SDOFINAL);

            /*" -1948- PERFORM R1850-00-SELECT-V0FOLLOWUP. */

            R1850_00_SELECT_V0FOLLOWUP_SECTION();

            /*" -1955- PERFORM R1900-00-SELECT-V0RCAPCOMP. */

            R1900_00_SELECT_V0RCAPCOMP_SECTION();

            /*" -1958- PERFORM R1950-00-SELECT-V0RCAPCOMP. */

            R1950_00_SELECT_V0RCAPCOMP_SECTION();

            /*" -1959- IF WTEM-REGISTRO NOT EQUAL 'S' */

            if (W.WTEM_REGISTRO != "S")
            {

                /*" -1960- MOVE 'RCAP NAO  ' TO LD01-SITUACAO */
                _.Move("RCAP NAO  ", W.LD01.LD01_SITUACAO);

                /*" -1962- ADD WS-SDOATU TO OR-VLONLINE GE-VLONLINE */
                W.OR_VLONLINE.Value = W.OR_VLONLINE + W.WS_SDOATU;
                W.GE_VLONLINE.Value = W.GE_VLONLINE + W.WS_SDOATU;

                /*" -1963- WRITE REG-CB0155B1 FROM LD01 */
                _.Move(W.LD01.GetMoveValues(), REG_CB0155B1);

                CB0155B1.Write(REG_CB0155B1.GetMoveValues().ToString());

                /*" -1964- ADD 1 TO GV-ARQSAI1 */
                W.GV_ARQSAI1.Value = W.GV_ARQSAI1 + 1;

                /*" -1967- GO TO R1600-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1969- MOVE WS-SDOFINAL TO LD01-SDOFINAL. */
            _.Move(W.WS_SDOFINAL, W.LD01.LD01_SDOFINAL);

            /*" -1970- MOVE 'RCAP FIM  ' TO LD01-SITUACAO */
            _.Move("RCAP FIM  ", W.LD01.LD01_SITUACAO);

            /*" -1972- ADD WS-SDOATU TO OR-VLONLINE GE-VLONLINE */
            W.OR_VLONLINE.Value = W.OR_VLONLINE + W.WS_SDOATU;
            W.GE_VLONLINE.Value = W.GE_VLONLINE + W.WS_SDOATU;

            /*" -1973- WRITE REG-CB0155B1 FROM LD01 */
            _.Move(W.LD01.GetMoveValues(), REG_CB0155B1);

            CB0155B1.Write(REG_CB0155B1.GetMoveValues().ToString());

            /*" -1973- ADD 1 TO GV-ARQSAI1. */
            W.GV_ARQSAI1.Value = W.GV_ARQSAI1 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1610-00-SELECT-V0RCAPCOMP-SECTION */
        private void R1610_00_SELECT_V0RCAPCOMP_SECTION()
        {
            /*" -1986- MOVE '1610' TO WNR-EXEC-SQL. */
            _.Move("1610", W.WABEND.WNR_EXEC_SQL);

            /*" -1988- MOVE ANT-BCOAVISO TO RCAPCOMP-BCO-AVISO. */
            _.Move(W.WS_CHAVE_ANT.ANT_BCOAVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO);

            /*" -1990- MOVE ANT-AGEAVISO TO RCAPCOMP-AGE-AVISO. */
            _.Move(W.WS_CHAVE_ANT.ANT_AGEAVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO);

            /*" -1994- MOVE ANT-NRAVISO TO RCAPCOMP-NUM-AVISO-CREDITO. */
            _.Move(W.WS_CHAVE_ANT.ANT_NRAVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO);

            /*" -2005- PERFORM R1610_00_SELECT_V0RCAPCOMP_DB_SELECT_1 */

            R1610_00_SELECT_V0RCAPCOMP_DB_SELECT_1();

            /*" -2009- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2011- MOVE ZEROS TO RCAPCOMP-VAL-RCAP */
                _.Move(0, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP);

                /*" -2012- ELSE */
            }
            else
            {


                /*" -2013- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2014- MOVE SQLCODE TO WSQLCODE */
                    _.Move(DB.SQLCODE, W.WABEND.WSQLCODE);

                    /*" -2019- DISPLAY 'R1610-00 - PROBLEMAS NO SELECT(RCAPCOMP)' '  ' RCAPCOMP-BCO-AVISO '  ' RCAPCOMP-AGE-AVISO '  ' RCAPCOMP-NUM-AVISO-CREDITO '  ' WSQLCODE */

                    $"R1610-00 - PROBLEMAS NO SELECT(RCAPCOMP)  {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO}  {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO}  {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO}  {W.WABEND.WSQLCODE}"
                    .Display();

                    /*" -2021- MOVE ZEROS TO RCAPCOMP-VAL-RCAP */
                    _.Move(0, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP);

                    /*" -2022- ELSE */
                }
                else
                {


                    /*" -2023- IF VIND-ORIGEM LESS ZEROS */

                    if (VIND_ORIGEM < 00)
                    {

                        /*" -2027- MOVE ZEROS TO RCAPCOMP-VAL-RCAP. */
                        _.Move(0, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP);
                    }

                }

            }


            /*" -2028- IF RCAPCOMP-VAL-RCAP NOT EQUAL ZEROS */

            if (RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP != 00)
            {

                /*" -2030- ADD RCAPCOMP-VAL-RCAP TO WS-SDOFINAL */
                W.WS_SDOFINAL.Value = W.WS_SDOFINAL + RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP;

                /*" -2030- MOVE 'S' TO WTEM-REGISTRO. */
                _.Move("S", W.WTEM_REGISTRO);
            }


        }

        [StopWatch]
        /*" R1610-00-SELECT-V0RCAPCOMP-DB-SELECT-1 */
        public void R1610_00_SELECT_V0RCAPCOMP_DB_SELECT_1()
        {
            /*" -2005- EXEC SQL SELECT SUM(VAL_RCAP) INTO :RCAPCOMP-VAL-RCAP:VIND-ORIGEM FROM SEGUROS.RCAP_COMPLEMENTAR WHERE BCO_AVISO = :RCAPCOMP-BCO-AVISO AND AGE_AVISO = :RCAPCOMP-AGE-AVISO AND NUM_AVISO_CREDITO = :RCAPCOMP-NUM-AVISO-CREDITO AND COD_OPERACAO IN (100,110) END-EXEC. */

            var r1610_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1 = new R1610_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1()
            {
                RCAPCOMP_NUM_AVISO_CREDITO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO.ToString(),
                RCAPCOMP_BCO_AVISO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO.ToString(),
                RCAPCOMP_AGE_AVISO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO.ToString(),
            };

            var executed_1 = R1610_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1.Execute(r1610_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPCOMP_VAL_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP);
                _.Move(executed_1.VIND_ORIGEM, VIND_ORIGEM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1610_99_SAIDA*/

        [StopWatch]
        /*" R1620-00-SELECT-V0RCAPCOMP-SECTION */
        private void R1620_00_SELECT_V0RCAPCOMP_SECTION()
        {
            /*" -2043- MOVE '1620' TO WNR-EXEC-SQL. */
            _.Move("1620", W.WABEND.WNR_EXEC_SQL);

            /*" -2045- MOVE ANT-BCOAVISO TO RCAPCOMP-BCO-AVISO. */
            _.Move(W.WS_CHAVE_ANT.ANT_BCOAVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO);

            /*" -2047- MOVE ANT-AGEAVISO TO RCAPCOMP-AGE-AVISO. */
            _.Move(W.WS_CHAVE_ANT.ANT_AGEAVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO);

            /*" -2051- MOVE ANT-NRAVISO TO RCAPCOMP-NUM-AVISO-CREDITO. */
            _.Move(W.WS_CHAVE_ANT.ANT_NRAVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO);

            /*" -2062- PERFORM R1620_00_SELECT_V0RCAPCOMP_DB_SELECT_1 */

            R1620_00_SELECT_V0RCAPCOMP_DB_SELECT_1();

            /*" -2066- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2068- MOVE ZEROS TO RCAPCOMP-VAL-RCAP */
                _.Move(0, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP);

                /*" -2069- ELSE */
            }
            else
            {


                /*" -2070- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2071- MOVE SQLCODE TO WSQLCODE */
                    _.Move(DB.SQLCODE, W.WABEND.WSQLCODE);

                    /*" -2076- DISPLAY 'R1620-00 - PROBLEMAS NO SELECT(RCAPCOMP)' '  ' RCAPCOMP-BCO-AVISO '  ' RCAPCOMP-AGE-AVISO '  ' RCAPCOMP-NUM-AVISO-CREDITO '  ' WSQLCODE */

                    $"R1620-00 - PROBLEMAS NO SELECT(RCAPCOMP)  {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO}  {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO}  {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO}  {W.WABEND.WSQLCODE}"
                    .Display();

                    /*" -2078- MOVE ZEROS TO RCAPCOMP-VAL-RCAP */
                    _.Move(0, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP);

                    /*" -2079- ELSE */
                }
                else
                {


                    /*" -2080- IF VIND-ORIGEM LESS ZEROS */

                    if (VIND_ORIGEM < 00)
                    {

                        /*" -2084- MOVE ZEROS TO RCAPCOMP-VAL-RCAP. */
                        _.Move(0, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP);
                    }

                }

            }


            /*" -2085- IF RCAPCOMP-VAL-RCAP NOT EQUAL ZEROS */

            if (RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP != 00)
            {

                /*" -2086- SUBTRACT RCAPCOMP-VAL-RCAP FROM WS-SDOFINAL. */
                W.WS_SDOFINAL.Value = W.WS_SDOFINAL - RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP;
            }


        }

        [StopWatch]
        /*" R1620-00-SELECT-V0RCAPCOMP-DB-SELECT-1 */
        public void R1620_00_SELECT_V0RCAPCOMP_DB_SELECT_1()
        {
            /*" -2062- EXEC SQL SELECT SUM(VAL_RCAP) INTO :RCAPCOMP-VAL-RCAP:VIND-ORIGEM FROM SEGUROS.RCAP_COMPLEMENTAR WHERE BCO_AVISO = :RCAPCOMP-BCO-AVISO AND AGE_AVISO = :RCAPCOMP-AGE-AVISO AND NUM_AVISO_CREDITO = :RCAPCOMP-NUM-AVISO-CREDITO AND COD_OPERACAO = 300 END-EXEC. */

            var r1620_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1 = new R1620_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1()
            {
                RCAPCOMP_NUM_AVISO_CREDITO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO.ToString(),
                RCAPCOMP_BCO_AVISO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO.ToString(),
                RCAPCOMP_AGE_AVISO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO.ToString(),
            };

            var executed_1 = R1620_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1.Execute(r1620_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPCOMP_VAL_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP);
                _.Move(executed_1.VIND_ORIGEM, VIND_ORIGEM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1620_99_SAIDA*/

        [StopWatch]
        /*" R1630-00-SELECT-V0RCAPCOMP-SECTION */
        private void R1630_00_SELECT_V0RCAPCOMP_SECTION()
        {
            /*" -2099- MOVE '1630' TO WNR-EXEC-SQL. */
            _.Move("1630", W.WABEND.WNR_EXEC_SQL);

            /*" -2101- MOVE ANT-BCOAVISO TO RCAPCOMP-BCO-AVISO. */
            _.Move(W.WS_CHAVE_ANT.ANT_BCOAVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO);

            /*" -2103- MOVE ANT-AGEAVISO TO RCAPCOMP-AGE-AVISO. */
            _.Move(W.WS_CHAVE_ANT.ANT_AGEAVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO);

            /*" -2107- MOVE ANT-NRAVISO TO RCAPCOMP-NUM-AVISO-CREDITO. */
            _.Move(W.WS_CHAVE_ANT.ANT_NRAVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO);

            /*" -2119- PERFORM R1630_00_SELECT_V0RCAPCOMP_DB_SELECT_1 */

            R1630_00_SELECT_V0RCAPCOMP_DB_SELECT_1();

            /*" -2123- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2125- MOVE ZEROS TO RCAPCOMP-VAL-RCAP */
                _.Move(0, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP);

                /*" -2126- ELSE */
            }
            else
            {


                /*" -2127- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2128- MOVE SQLCODE TO WSQLCODE */
                    _.Move(DB.SQLCODE, W.WABEND.WSQLCODE);

                    /*" -2133- DISPLAY 'R1630-00 - PROBLEMAS NO SELECT(RCAPCOMP)' '  ' RCAPCOMP-BCO-AVISO '  ' RCAPCOMP-AGE-AVISO '  ' RCAPCOMP-NUM-AVISO-CREDITO '  ' WSQLCODE */

                    $"R1630-00 - PROBLEMAS NO SELECT(RCAPCOMP)  {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO}  {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO}  {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO}  {W.WABEND.WSQLCODE}"
                    .Display();

                    /*" -2135- MOVE ZEROS TO RCAPCOMP-VAL-RCAP */
                    _.Move(0, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP);

                    /*" -2136- ELSE */
                }
                else
                {


                    /*" -2137- IF VIND-ORIGEM LESS ZEROS */

                    if (VIND_ORIGEM < 00)
                    {

                        /*" -2141- MOVE ZEROS TO RCAPCOMP-VAL-RCAP. */
                        _.Move(0, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP);
                    }

                }

            }


            /*" -2142- IF RCAPCOMP-VAL-RCAP NOT EQUAL ZEROS */

            if (RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP != 00)
            {

                /*" -2143- SUBTRACT RCAPCOMP-VAL-RCAP FROM WS-SDOFINAL. */
                W.WS_SDOFINAL.Value = W.WS_SDOFINAL - RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP;
            }


        }

        [StopWatch]
        /*" R1630-00-SELECT-V0RCAPCOMP-DB-SELECT-1 */
        public void R1630_00_SELECT_V0RCAPCOMP_DB_SELECT_1()
        {
            /*" -2119- EXEC SQL SELECT SUM(VAL_RCAP) INTO :RCAPCOMP-VAL-RCAP:VIND-ORIGEM FROM SEGUROS.RCAP_COMPLEMENTAR WHERE BCO_AVISO = :RCAPCOMP-BCO-AVISO AND AGE_AVISO = :RCAPCOMP-AGE-AVISO AND NUM_AVISO_CREDITO = :RCAPCOMP-NUM-AVISO-CREDITO AND COD_OPERACAO = 400 AND SIT_CONTABIL = '1' END-EXEC. */

            var r1630_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1 = new R1630_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1()
            {
                RCAPCOMP_NUM_AVISO_CREDITO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO.ToString(),
                RCAPCOMP_BCO_AVISO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO.ToString(),
                RCAPCOMP_AGE_AVISO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO.ToString(),
            };

            var executed_1 = R1630_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1.Execute(r1630_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPCOMP_VAL_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP);
                _.Move(executed_1.VIND_ORIGEM, VIND_ORIGEM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1630_99_SAIDA*/

        [StopWatch]
        /*" R1640-00-SELECT-V0FOLLOWUP-SECTION */
        private void R1640_00_SELECT_V0FOLLOWUP_SECTION()
        {
            /*" -2156- MOVE '1640' TO WNR-EXEC-SQL. */
            _.Move("1640", W.WABEND.WNR_EXEC_SQL);

            /*" -2158- MOVE ANT-BCOAVISO TO FOLLOUP-BCO-AVISO. */
            _.Move(W.WS_CHAVE_ANT.ANT_BCOAVISO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_BCO_AVISO);

            /*" -2160- MOVE ANT-AGEAVISO TO FOLLOUP-AGE-AVISO. */
            _.Move(W.WS_CHAVE_ANT.ANT_AGEAVISO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_AGE_AVISO);

            /*" -2164- MOVE ANT-NRAVISO TO FOLLOUP-NUM-AVISO-CREDITO. */
            _.Move(W.WS_CHAVE_ANT.ANT_NRAVISO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_AVISO_CREDITO);

            /*" -2174- PERFORM R1640_00_SELECT_V0FOLLOWUP_DB_SELECT_1 */

            R1640_00_SELECT_V0FOLLOWUP_DB_SELECT_1();

            /*" -2178- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2180- MOVE ZEROS TO FOLLOUP-VAL-OPERACAO */
                _.Move(0, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_VAL_OPERACAO);

                /*" -2181- ELSE */
            }
            else
            {


                /*" -2182- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2183- MOVE SQLCODE TO WSQLCODE */
                    _.Move(DB.SQLCODE, W.WABEND.WSQLCODE);

                    /*" -2188- DISPLAY 'R1640-00 - PROBLEMAS NO SELECT(FOLLOWUP)' '  ' FOLLOUP-BCO-AVISO '  ' FOLLOUP-AGE-AVISO '  ' FOLLOUP-NUM-AVISO-CREDITO '  ' WSQLCODE */

                    $"R1640-00 - PROBLEMAS NO SELECT(FOLLOWUP)  {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_BCO_AVISO}  {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_AGE_AVISO}  {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_AVISO_CREDITO}  {W.WABEND.WSQLCODE}"
                    .Display();

                    /*" -2190- MOVE ZEROS TO FOLLOUP-VAL-OPERACAO */
                    _.Move(0, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_VAL_OPERACAO);

                    /*" -2191- ELSE */
                }
                else
                {


                    /*" -2192- IF VIND-ORIGEM LESS ZEROS */

                    if (VIND_ORIGEM < 00)
                    {

                        /*" -2196- MOVE ZEROS TO FOLLOUP-VAL-OPERACAO. */
                        _.Move(0, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_VAL_OPERACAO);
                    }

                }

            }


            /*" -2197- IF FOLLOUP-VAL-OPERACAO NOT EQUAL ZEROS */

            if (FOLLOUP.DCLFOLLOW_UP.FOLLOUP_VAL_OPERACAO != 00)
            {

                /*" -2198- MOVE 'S' TO WTEM-REGISTRO */
                _.Move("S", W.WTEM_REGISTRO);

                /*" -2199- ADD FOLLOUP-VAL-OPERACAO TO WS-SDOFINAL. */
                W.WS_SDOFINAL.Value = W.WS_SDOFINAL + FOLLOUP.DCLFOLLOW_UP.FOLLOUP_VAL_OPERACAO;
            }


        }

        [StopWatch]
        /*" R1640-00-SELECT-V0FOLLOWUP-DB-SELECT-1 */
        public void R1640_00_SELECT_V0FOLLOWUP_DB_SELECT_1()
        {
            /*" -2174- EXEC SQL SELECT SUM(VAL_OPERACAO) INTO :FOLLOUP-VAL-OPERACAO:VIND-ORIGEM FROM SEGUROS.FOLLOW_UP WHERE BCO_AVISO = :FOLLOUP-BCO-AVISO AND AGE_AVISO = :FOLLOUP-AGE-AVISO AND NUM_AVISO_CREDITO = :FOLLOUP-NUM-AVISO-CREDITO END-EXEC. */

            var r1640_00_SELECT_V0FOLLOWUP_DB_SELECT_1_Query1 = new R1640_00_SELECT_V0FOLLOWUP_DB_SELECT_1_Query1()
            {
                FOLLOUP_NUM_AVISO_CREDITO = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_AVISO_CREDITO.ToString(),
                FOLLOUP_BCO_AVISO = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_BCO_AVISO.ToString(),
                FOLLOUP_AGE_AVISO = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_AGE_AVISO.ToString(),
            };

            var executed_1 = R1640_00_SELECT_V0FOLLOWUP_DB_SELECT_1_Query1.Execute(r1640_00_SELECT_V0FOLLOWUP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FOLLOUP_VAL_OPERACAO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_VAL_OPERACAO);
                _.Move(executed_1.VIND_ORIGEM, VIND_ORIGEM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1640_99_SAIDA*/

        [StopWatch]
        /*" R1700-00-TRATA-MOVIMCOB-SECTION */
        private void R1700_00_TRATA_MOVIMCOB_SECTION()
        {
            /*" -2215- MOVE '1700' TO WNR-EXEC-SQL. */
            _.Move("1700", W.WABEND.WNR_EXEC_SQL);

            /*" -2218- PERFORM R2200-00-SELECT-V0CONDESCE. */

            R2200_00_SELECT_V0CONDESCE_SECTION();

            /*" -2219- IF CONDESCE-QTD-REGISTROS EQUAL ZEROS */

            if (CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_QTD_REGISTROS == 00)
            {

                /*" -2220- PERFORM R2000-00-TRATA-ONLINE */

                R2000_00_TRATA_ONLINE_SECTION();

                /*" -2226- GO TO R1700-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2227- IF LD01-ORIGEM EQUAL 18 */

            if (W.LD01.LD01_ORIGEM == 18)
            {

                /*" -2228- MOVE 'RES DIV   ' TO LD01-SITUACAO */
                _.Move("RES DIV   ", W.LD01.LD01_SITUACAO);

                /*" -2230- ADD WS-SDOATU TO OR-VLONLINE GE-VLONLINE */
                W.OR_VLONLINE.Value = W.OR_VLONLINE + W.WS_SDOATU;
                W.GE_VLONLINE.Value = W.GE_VLONLINE + W.WS_SDOATU;

                /*" -2231- WRITE REG-CB0155B1 FROM LD01 */
                _.Move(W.LD01.GetMoveValues(), REG_CB0155B1);

                CB0155B1.Write(REG_CB0155B1.GetMoveValues().ToString());

                /*" -2232- ADD 1 TO GV-ARQSAI1 */
                W.GV_ARQSAI1.Value = W.GV_ARQSAI1 + 1;

                /*" -2235- GO TO R1700-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2236- MOVE SPACES TO WTEM-REGISTRO. */
            _.Move("", W.WTEM_REGISTRO);

            /*" -2243- MOVE WS-VLPRMTOT TO WS-SDOFINAL. */
            _.Move(W.WS_VLPRMTOT, W.WS_SDOFINAL);

            /*" -2250- PERFORM R1800-00-SELECT-V0PARCEHIS. */

            R1800_00_SELECT_V0PARCEHIS_SECTION();

            /*" -2253- PERFORM R1850-00-SELECT-V0FOLLOWUP. */

            R1850_00_SELECT_V0FOLLOWUP_SECTION();

            /*" -2254- IF WTEM-REGISTRO NOT EQUAL 'S' */

            if (W.WTEM_REGISTRO != "S")
            {

                /*" -2255- MOVE 'CRED NAO  ' TO LD01-SITUACAO */
                _.Move("CRED NAO  ", W.LD01.LD01_SITUACAO);

                /*" -2257- ADD WS-SDOATU TO OR-VLONLINE GE-VLONLINE */
                W.OR_VLONLINE.Value = W.OR_VLONLINE + W.WS_SDOATU;
                W.GE_VLONLINE.Value = W.GE_VLONLINE + W.WS_SDOATU;

                /*" -2258- WRITE REG-CB0155B1 FROM LD01 */
                _.Move(W.LD01.GetMoveValues(), REG_CB0155B1);

                CB0155B1.Write(REG_CB0155B1.GetMoveValues().ToString());

                /*" -2259- ADD 1 TO GV-ARQSAI1 */
                W.GV_ARQSAI1.Value = W.GV_ARQSAI1 + 1;

                /*" -2262- GO TO R1700-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2265- MOVE WS-SDOFINAL TO LD01-SDOFINAL. */
            _.Move(W.WS_SDOFINAL, W.LD01.LD01_SDOFINAL);

            /*" -2266- IF WS-SDOFINAL NOT EQUAL WS-SDOATU */

            if (W.WS_SDOFINAL != W.WS_SDOATU)
            {

                /*" -2268- IF WS-SDOFINAL LESS ZEROS OR WS-SDOATU LESS ZEROS */

                if (W.WS_SDOFINAL < 00 || W.WS_SDOATU < 00)
                {

                    /*" -2269- MOVE 'CRED NEG 1' TO LD01-SITUACAO */
                    _.Move("CRED NEG 1", W.LD01.LD01_SITUACAO);

                    /*" -2271- ADD WS-SDOATU TO OR-VLONLINE GE-VLONLINE */
                    W.OR_VLONLINE.Value = W.OR_VLONLINE + W.WS_SDOATU;
                    W.GE_VLONLINE.Value = W.GE_VLONLINE + W.WS_SDOATU;

                    /*" -2272- WRITE REG-CB0155B1 FROM LD01 */
                    _.Move(W.LD01.GetMoveValues(), REG_CB0155B1);

                    CB0155B1.Write(REG_CB0155B1.GetMoveValues().ToString());

                    /*" -2273- ADD 1 TO GV-ARQSAI1 */
                    W.GV_ARQSAI1.Value = W.GV_ARQSAI1 + 1;

                    /*" -2274- ELSE */
                }
                else
                {


                    /*" -2275- MOVE 'CRED DIV  ' TO LD01-SITUACAO */
                    _.Move("CRED DIV  ", W.LD01.LD01_SITUACAO);

                    /*" -2277- ADD WS-SDOATU TO OR-VLONLINE GE-VLONLINE */
                    W.OR_VLONLINE.Value = W.OR_VLONLINE + W.WS_SDOATU;
                    W.GE_VLONLINE.Value = W.GE_VLONLINE + W.WS_SDOATU;

                    /*" -2278- WRITE REG-CB0155B1 FROM LD01 */
                    _.Move(W.LD01.GetMoveValues(), REG_CB0155B1);

                    CB0155B1.Write(REG_CB0155B1.GetMoveValues().ToString());

                    /*" -2279- ADD 1 TO GV-ARQSAI1 */
                    W.GV_ARQSAI1.Value = W.GV_ARQSAI1 + 1;

                    /*" -2280- ELSE */
                }

            }
            else
            {


                /*" -2281- IF WS-SDOATU LESS ZEROS */

                if (W.WS_SDOATU < 00)
                {

                    /*" -2282- MOVE 'CRED NEG 2' TO LD01-SITUACAO */
                    _.Move("CRED NEG 2", W.LD01.LD01_SITUACAO);

                    /*" -2284- ADD WS-SDOATU TO OR-VLONLINE GE-VLONLINE */
                    W.OR_VLONLINE.Value = W.OR_VLONLINE + W.WS_SDOATU;
                    W.GE_VLONLINE.Value = W.GE_VLONLINE + W.WS_SDOATU;

                    /*" -2285- WRITE REG-CB0155B1 FROM LD01 */
                    _.Move(W.LD01.GetMoveValues(), REG_CB0155B1);

                    CB0155B1.Write(REG_CB0155B1.GetMoveValues().ToString());

                    /*" -2286- ADD 1 TO GV-ARQSAI1 */
                    W.GV_ARQSAI1.Value = W.GV_ARQSAI1 + 1;

                    /*" -2287- ELSE */
                }
                else
                {


                    /*" -2288- MOVE 'CREDITO OK' TO LD01-SITUACAO */
                    _.Move("CREDITO OK", W.LD01.LD01_SITUACAO);

                    /*" -2290- ADD WS-SDOATU TO OR-VLONLINE GE-VLONLINE */
                    W.OR_VLONLINE.Value = W.OR_VLONLINE + W.WS_SDOATU;
                    W.GE_VLONLINE.Value = W.GE_VLONLINE + W.WS_SDOATU;

                    /*" -2291- WRITE REG-CB0155B1 FROM LD01 */
                    _.Move(W.LD01.GetMoveValues(), REG_CB0155B1);

                    CB0155B1.Write(REG_CB0155B1.GetMoveValues().ToString());

                    /*" -2291- ADD 1 TO GV-ARQSAI1. */
                    W.GV_ARQSAI1.Value = W.GV_ARQSAI1 + 1;
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/

        [StopWatch]
        /*" R1800-00-SELECT-V0PARCEHIS-SECTION */
        private void R1800_00_SELECT_V0PARCEHIS_SECTION()
        {
            /*" -2304- MOVE '1800' TO WNR-EXEC-SQL. */
            _.Move("1800", W.WABEND.WNR_EXEC_SQL);

            /*" -2306- MOVE ANT-BCOAVISO TO PARCEHIS-BCO-COBRANCA. */
            _.Move(W.WS_CHAVE_ANT.ANT_BCOAVISO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_BCO_COBRANCA);

            /*" -2308- MOVE ANT-AGEAVISO TO PARCEHIS-AGE-COBRANCA. */
            _.Move(W.WS_CHAVE_ANT.ANT_AGEAVISO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_AGE_COBRANCA);

            /*" -2312- MOVE ANT-NRAVISO TO PARCEHIS-NUM-AVISO-CREDITO. */
            _.Move(W.WS_CHAVE_ANT.ANT_NRAVISO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_AVISO_CREDITO);

            /*" -2323- PERFORM R1800_00_SELECT_V0PARCEHIS_DB_SELECT_1 */

            R1800_00_SELECT_V0PARCEHIS_DB_SELECT_1();

            /*" -2327- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2329- MOVE ZEROS TO PARCEHIS-VAL-OPERACAO */
                _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_OPERACAO);

                /*" -2330- ELSE */
            }
            else
            {


                /*" -2331- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2332- MOVE SQLCODE TO WSQLCODE */
                    _.Move(DB.SQLCODE, W.WABEND.WSQLCODE);

                    /*" -2337- DISPLAY 'R1800-00 - PROBLEMAS NO SELECT(PARCEHIS)' '  ' PARCEHIS-BCO-COBRANCA '  ' PARCEHIS-AGE-COBRANCA '  ' PARCEHIS-NUM-AVISO-CREDITO '  ' WSQLCODE */

                    $"R1800-00 - PROBLEMAS NO SELECT(PARCEHIS)  {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_BCO_COBRANCA}  {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_AGE_COBRANCA}  {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_AVISO_CREDITO}  {W.WABEND.WSQLCODE}"
                    .Display();

                    /*" -2339- MOVE ZEROS TO PARCEHIS-VAL-OPERACAO */
                    _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_OPERACAO);

                    /*" -2340- ELSE */
                }
                else
                {


                    /*" -2341- IF VIND-ORIGEM LESS ZEROS */

                    if (VIND_ORIGEM < 00)
                    {

                        /*" -2345- MOVE ZEROS TO PARCEHIS-VAL-OPERACAO. */
                        _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_OPERACAO);
                    }

                }

            }


            /*" -2346- IF PARCEHIS-VAL-OPERACAO NOT EQUAL ZEROS */

            if (PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_OPERACAO != 00)
            {

                /*" -2348- SUBTRACT PARCEHIS-VAL-OPERACAO FROM WS-SDOFINAL */
                W.WS_SDOFINAL.Value = W.WS_SDOFINAL - PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_OPERACAO;

                /*" -2349- MOVE 'S' TO WTEM-REGISTRO */
                _.Move("S", W.WTEM_REGISTRO);

                /*" -2349- PERFORM R1810-00-SELECT-V0PARCEHIS. */

                R1810_00_SELECT_V0PARCEHIS_SECTION();
            }


        }

        [StopWatch]
        /*" R1800-00-SELECT-V0PARCEHIS-DB-SELECT-1 */
        public void R1800_00_SELECT_V0PARCEHIS_DB_SELECT_1()
        {
            /*" -2323- EXEC SQL SELECT SUM(VAL_OPERACAO) INTO :PARCEHIS-VAL-OPERACAO:VIND-ORIGEM FROM SEGUROS.PARCELA_HISTORICO WHERE BCO_COBRANCA = :PARCEHIS-BCO-COBRANCA AND AGE_COBRANCA = :PARCEHIS-AGE-COBRANCA AND NUM_AVISO_CREDITO = :PARCEHIS-NUM-AVISO-CREDITO AND COD_OPERACAO BETWEEN 200 AND 299 END-EXEC. */

            var r1800_00_SELECT_V0PARCEHIS_DB_SELECT_1_Query1 = new R1800_00_SELECT_V0PARCEHIS_DB_SELECT_1_Query1()
            {
                PARCEHIS_NUM_AVISO_CREDITO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_AVISO_CREDITO.ToString(),
                PARCEHIS_BCO_COBRANCA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_BCO_COBRANCA.ToString(),
                PARCEHIS_AGE_COBRANCA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_AGE_COBRANCA.ToString(),
            };

            var executed_1 = R1800_00_SELECT_V0PARCEHIS_DB_SELECT_1_Query1.Execute(r1800_00_SELECT_V0PARCEHIS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARCEHIS_VAL_OPERACAO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_OPERACAO);
                _.Move(executed_1.VIND_ORIGEM, VIND_ORIGEM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1800_99_SAIDA*/

        [StopWatch]
        /*" R1810-00-SELECT-V0PARCEHIS-SECTION */
        private void R1810_00_SELECT_V0PARCEHIS_SECTION()
        {
            /*" -2362- MOVE '1810' TO WNR-EXEC-SQL. */
            _.Move("1810", W.WABEND.WNR_EXEC_SQL);

            /*" -2364- MOVE ANT-BCOAVISO TO PARCEHIS-BCO-COBRANCA. */
            _.Move(W.WS_CHAVE_ANT.ANT_BCOAVISO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_BCO_COBRANCA);

            /*" -2366- MOVE ANT-AGEAVISO TO PARCEHIS-AGE-COBRANCA. */
            _.Move(W.WS_CHAVE_ANT.ANT_AGEAVISO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_AGE_COBRANCA);

            /*" -2370- MOVE ANT-NRAVISO TO PARCEHIS-NUM-AVISO-CREDITO. */
            _.Move(W.WS_CHAVE_ANT.ANT_NRAVISO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_AVISO_CREDITO);

            /*" -2381- PERFORM R1810_00_SELECT_V0PARCEHIS_DB_SELECT_1 */

            R1810_00_SELECT_V0PARCEHIS_DB_SELECT_1();

            /*" -2385- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2387- MOVE ZEROS TO PARCEHIS-VAL-OPERACAO */
                _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_OPERACAO);

                /*" -2388- ELSE */
            }
            else
            {


                /*" -2389- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2390- MOVE SQLCODE TO WSQLCODE */
                    _.Move(DB.SQLCODE, W.WABEND.WSQLCODE);

                    /*" -2395- DISPLAY 'R1810-00 - PROBLEMAS NO SELECT(PARCEHIS)' '  ' PARCEHIS-BCO-COBRANCA '  ' PARCEHIS-AGE-COBRANCA '  ' PARCEHIS-NUM-AVISO-CREDITO '  ' WSQLCODE */

                    $"R1810-00 - PROBLEMAS NO SELECT(PARCEHIS)  {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_BCO_COBRANCA}  {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_AGE_COBRANCA}  {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_AVISO_CREDITO}  {W.WABEND.WSQLCODE}"
                    .Display();

                    /*" -2397- MOVE ZEROS TO PARCEHIS-VAL-OPERACAO */
                    _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_OPERACAO);

                    /*" -2398- ELSE */
                }
                else
                {


                    /*" -2399- IF VIND-ORIGEM LESS ZEROS */

                    if (VIND_ORIGEM < 00)
                    {

                        /*" -2403- MOVE ZEROS TO PARCEHIS-VAL-OPERACAO. */
                        _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_OPERACAO);
                    }

                }

            }


            /*" -2404- IF PARCEHIS-VAL-OPERACAO NOT EQUAL ZEROS */

            if (PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_OPERACAO != 00)
            {

                /*" -2405- ADD PARCEHIS-VAL-OPERACAO TO WS-SDOFINAL. */
                W.WS_SDOFINAL.Value = W.WS_SDOFINAL + PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_OPERACAO;
            }


        }

        [StopWatch]
        /*" R1810-00-SELECT-V0PARCEHIS-DB-SELECT-1 */
        public void R1810_00_SELECT_V0PARCEHIS_DB_SELECT_1()
        {
            /*" -2381- EXEC SQL SELECT SUM(VAL_OPERACAO) INTO :PARCEHIS-VAL-OPERACAO:VIND-ORIGEM FROM SEGUROS.PARCELA_HISTORICO WHERE BCO_COBRANCA = :PARCEHIS-BCO-COBRANCA AND AGE_COBRANCA = :PARCEHIS-AGE-COBRANCA AND NUM_AVISO_CREDITO = :PARCEHIS-NUM-AVISO-CREDITO AND COD_OPERACAO = 300 END-EXEC. */

            var r1810_00_SELECT_V0PARCEHIS_DB_SELECT_1_Query1 = new R1810_00_SELECT_V0PARCEHIS_DB_SELECT_1_Query1()
            {
                PARCEHIS_NUM_AVISO_CREDITO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_AVISO_CREDITO.ToString(),
                PARCEHIS_BCO_COBRANCA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_BCO_COBRANCA.ToString(),
                PARCEHIS_AGE_COBRANCA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_AGE_COBRANCA.ToString(),
            };

            var executed_1 = R1810_00_SELECT_V0PARCEHIS_DB_SELECT_1_Query1.Execute(r1810_00_SELECT_V0PARCEHIS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARCEHIS_VAL_OPERACAO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_OPERACAO);
                _.Move(executed_1.VIND_ORIGEM, VIND_ORIGEM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1810_99_SAIDA*/

        [StopWatch]
        /*" R1850-00-SELECT-V0FOLLOWUP-SECTION */
        private void R1850_00_SELECT_V0FOLLOWUP_SECTION()
        {
            /*" -2418- MOVE '1850' TO WNR-EXEC-SQL. */
            _.Move("1850", W.WABEND.WNR_EXEC_SQL);

            /*" -2420- MOVE ANT-BCOAVISO TO FOLLOUP-BCO-AVISO. */
            _.Move(W.WS_CHAVE_ANT.ANT_BCOAVISO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_BCO_AVISO);

            /*" -2422- MOVE ANT-AGEAVISO TO FOLLOUP-AGE-AVISO. */
            _.Move(W.WS_CHAVE_ANT.ANT_AGEAVISO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_AGE_AVISO);

            /*" -2426- MOVE ANT-NRAVISO TO FOLLOUP-NUM-AVISO-CREDITO. */
            _.Move(W.WS_CHAVE_ANT.ANT_NRAVISO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_AVISO_CREDITO);

            /*" -2437- PERFORM R1850_00_SELECT_V0FOLLOWUP_DB_SELECT_1 */

            R1850_00_SELECT_V0FOLLOWUP_DB_SELECT_1();

            /*" -2441- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2443- MOVE ZEROS TO FOLLOUP-VAL-OPERACAO */
                _.Move(0, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_VAL_OPERACAO);

                /*" -2444- ELSE */
            }
            else
            {


                /*" -2445- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2446- MOVE SQLCODE TO WSQLCODE */
                    _.Move(DB.SQLCODE, W.WABEND.WSQLCODE);

                    /*" -2451- DISPLAY 'R1850-00 - PROBLEMAS NO SELECT(FOLLOWUP)' '  ' FOLLOUP-BCO-AVISO '  ' FOLLOUP-AGE-AVISO '  ' FOLLOUP-NUM-AVISO-CREDITO '  ' WSQLCODE */

                    $"R1850-00 - PROBLEMAS NO SELECT(FOLLOWUP)  {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_BCO_AVISO}  {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_AGE_AVISO}  {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_AVISO_CREDITO}  {W.WABEND.WSQLCODE}"
                    .Display();

                    /*" -2453- MOVE ZEROS TO FOLLOUP-VAL-OPERACAO */
                    _.Move(0, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_VAL_OPERACAO);

                    /*" -2454- ELSE */
                }
                else
                {


                    /*" -2455- IF VIND-ORIGEM LESS ZEROS */

                    if (VIND_ORIGEM < 00)
                    {

                        /*" -2459- MOVE ZEROS TO FOLLOUP-VAL-OPERACAO. */
                        _.Move(0, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_VAL_OPERACAO);
                    }

                }

            }


            /*" -2460- IF FOLLOUP-VAL-OPERACAO NOT EQUAL ZEROS */

            if (FOLLOUP.DCLFOLLOW_UP.FOLLOUP_VAL_OPERACAO != 00)
            {

                /*" -2461- MOVE 'S' TO WTEM-REGISTRO */
                _.Move("S", W.WTEM_REGISTRO);

                /*" -2462- SUBTRACT FOLLOUP-VAL-OPERACAO FROM WS-SDOFINAL. */
                W.WS_SDOFINAL.Value = W.WS_SDOFINAL - FOLLOUP.DCLFOLLOW_UP.FOLLOUP_VAL_OPERACAO;
            }


        }

        [StopWatch]
        /*" R1850-00-SELECT-V0FOLLOWUP-DB-SELECT-1 */
        public void R1850_00_SELECT_V0FOLLOWUP_DB_SELECT_1()
        {
            /*" -2437- EXEC SQL SELECT SUM(VAL_OPERACAO) INTO :FOLLOUP-VAL-OPERACAO:VIND-ORIGEM FROM SEGUROS.FOLLOW_UP WHERE BCO_AVISO = :FOLLOUP-BCO-AVISO AND AGE_AVISO = :FOLLOUP-AGE-AVISO AND NUM_AVISO_CREDITO = :FOLLOUP-NUM-AVISO-CREDITO AND COD_OPERACAO IN (202,203,204,205,402) END-EXEC. */

            var r1850_00_SELECT_V0FOLLOWUP_DB_SELECT_1_Query1 = new R1850_00_SELECT_V0FOLLOWUP_DB_SELECT_1_Query1()
            {
                FOLLOUP_NUM_AVISO_CREDITO = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_AVISO_CREDITO.ToString(),
                FOLLOUP_BCO_AVISO = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_BCO_AVISO.ToString(),
                FOLLOUP_AGE_AVISO = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_AGE_AVISO.ToString(),
            };

            var executed_1 = R1850_00_SELECT_V0FOLLOWUP_DB_SELECT_1_Query1.Execute(r1850_00_SELECT_V0FOLLOWUP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FOLLOUP_VAL_OPERACAO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_VAL_OPERACAO);
                _.Move(executed_1.VIND_ORIGEM, VIND_ORIGEM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1850_99_SAIDA*/

        [StopWatch]
        /*" R1900-00-SELECT-V0RCAPCOMP-SECTION */
        private void R1900_00_SELECT_V0RCAPCOMP_SECTION()
        {
            /*" -2475- MOVE '1900' TO WNR-EXEC-SQL. */
            _.Move("1900", W.WABEND.WNR_EXEC_SQL);

            /*" -2477- MOVE ANT-BCOAVISO TO RCAPCOMP-BCO-AVISO. */
            _.Move(W.WS_CHAVE_ANT.ANT_BCOAVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO);

            /*" -2479- MOVE ANT-AGEAVISO TO RCAPCOMP-AGE-AVISO. */
            _.Move(W.WS_CHAVE_ANT.ANT_AGEAVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO);

            /*" -2483- MOVE ANT-NRAVISO TO RCAPCOMP-NUM-AVISO-CREDITO. */
            _.Move(W.WS_CHAVE_ANT.ANT_NRAVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO);

            /*" -2494- PERFORM R1900_00_SELECT_V0RCAPCOMP_DB_SELECT_1 */

            R1900_00_SELECT_V0RCAPCOMP_DB_SELECT_1();

            /*" -2498- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2500- MOVE ZEROS TO RCAPCOMP-VAL-RCAP */
                _.Move(0, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP);

                /*" -2501- ELSE */
            }
            else
            {


                /*" -2502- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2503- MOVE SQLCODE TO WSQLCODE */
                    _.Move(DB.SQLCODE, W.WABEND.WSQLCODE);

                    /*" -2508- DISPLAY 'R1900-00 - PROBLEMAS NO SELECT(RCAPCOMP)' '  ' RCAPCOMP-BCO-AVISO '  ' RCAPCOMP-AGE-AVISO '  ' RCAPCOMP-NUM-AVISO-CREDITO '  ' WSQLCODE */

                    $"R1900-00 - PROBLEMAS NO SELECT(RCAPCOMP)  {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO}  {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO}  {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO}  {W.WABEND.WSQLCODE}"
                    .Display();

                    /*" -2510- MOVE ZEROS TO RCAPCOMP-VAL-RCAP */
                    _.Move(0, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP);

                    /*" -2511- ELSE */
                }
                else
                {


                    /*" -2512- IF VIND-ORIGEM LESS ZEROS */

                    if (VIND_ORIGEM < 00)
                    {

                        /*" -2516- MOVE ZEROS TO RCAPCOMP-VAL-RCAP. */
                        _.Move(0, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP);
                    }

                }

            }


            /*" -2517- IF RCAPCOMP-VAL-RCAP NOT EQUAL ZEROS */

            if (RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP != 00)
            {

                /*" -2518- MOVE 'S' TO WTEM-REGISTRO */
                _.Move("S", W.WTEM_REGISTRO);

                /*" -2520- SUBTRACT RCAPCOMP-VAL-RCAP FROM WS-SDOFINAL */
                W.WS_SDOFINAL.Value = W.WS_SDOFINAL - RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP;

                /*" -2520- PERFORM R1910-00-SELECT-V0RCAPCOMP. */

                R1910_00_SELECT_V0RCAPCOMP_SECTION();
            }


        }

        [StopWatch]
        /*" R1900-00-SELECT-V0RCAPCOMP-DB-SELECT-1 */
        public void R1900_00_SELECT_V0RCAPCOMP_DB_SELECT_1()
        {
            /*" -2494- EXEC SQL SELECT SUM(VAL_RCAP) INTO :RCAPCOMP-VAL-RCAP:VIND-ORIGEM FROM SEGUROS.RCAP_COMPLEMENTAR WHERE BCO_AVISO = :RCAPCOMP-BCO-AVISO AND AGE_AVISO = :RCAPCOMP-AGE-AVISO AND NUM_AVISO_CREDITO = :RCAPCOMP-NUM-AVISO-CREDITO AND COD_OPERACAO = 210 END-EXEC. */

            var r1900_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1 = new R1900_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1()
            {
                RCAPCOMP_NUM_AVISO_CREDITO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO.ToString(),
                RCAPCOMP_BCO_AVISO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO.ToString(),
                RCAPCOMP_AGE_AVISO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO.ToString(),
            };

            var executed_1 = R1900_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1.Execute(r1900_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPCOMP_VAL_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP);
                _.Move(executed_1.VIND_ORIGEM, VIND_ORIGEM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/

        [StopWatch]
        /*" R1910-00-SELECT-V0RCAPCOMP-SECTION */
        private void R1910_00_SELECT_V0RCAPCOMP_SECTION()
        {
            /*" -2533- MOVE '1910' TO WNR-EXEC-SQL. */
            _.Move("1910", W.WABEND.WNR_EXEC_SQL);

            /*" -2535- MOVE ANT-BCOAVISO TO RCAPCOMP-BCO-AVISO. */
            _.Move(W.WS_CHAVE_ANT.ANT_BCOAVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO);

            /*" -2537- MOVE ANT-AGEAVISO TO RCAPCOMP-AGE-AVISO. */
            _.Move(W.WS_CHAVE_ANT.ANT_AGEAVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO);

            /*" -2541- MOVE ANT-NRAVISO TO RCAPCOMP-NUM-AVISO-CREDITO. */
            _.Move(W.WS_CHAVE_ANT.ANT_NRAVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO);

            /*" -2552- PERFORM R1910_00_SELECT_V0RCAPCOMP_DB_SELECT_1 */

            R1910_00_SELECT_V0RCAPCOMP_DB_SELECT_1();

            /*" -2556- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2558- MOVE ZEROS TO RCAPCOMP-VAL-RCAP */
                _.Move(0, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP);

                /*" -2559- ELSE */
            }
            else
            {


                /*" -2560- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2561- MOVE SQLCODE TO WSQLCODE */
                    _.Move(DB.SQLCODE, W.WABEND.WSQLCODE);

                    /*" -2566- DISPLAY 'R1910-00 - PROBLEMAS NO SELECT(RCAPCOMP)' '  ' RCAPCOMP-BCO-AVISO '  ' RCAPCOMP-AGE-AVISO '  ' RCAPCOMP-NUM-AVISO-CREDITO '  ' WSQLCODE */

                    $"R1910-00 - PROBLEMAS NO SELECT(RCAPCOMP)  {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO}  {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO}  {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO}  {W.WABEND.WSQLCODE}"
                    .Display();

                    /*" -2568- MOVE ZEROS TO RCAPCOMP-VAL-RCAP */
                    _.Move(0, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP);

                    /*" -2569- ELSE */
                }
                else
                {


                    /*" -2570- IF VIND-ORIGEM LESS ZEROS */

                    if (VIND_ORIGEM < 00)
                    {

                        /*" -2574- MOVE ZEROS TO RCAPCOMP-VAL-RCAP. */
                        _.Move(0, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP);
                    }

                }

            }


            /*" -2575- IF RCAPCOMP-VAL-RCAP NOT EQUAL ZEROS */

            if (RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP != 00)
            {

                /*" -2576- ADD RCAPCOMP-VAL-RCAP TO WS-SDOFINAL. */
                W.WS_SDOFINAL.Value = W.WS_SDOFINAL + RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP;
            }


        }

        [StopWatch]
        /*" R1910-00-SELECT-V0RCAPCOMP-DB-SELECT-1 */
        public void R1910_00_SELECT_V0RCAPCOMP_DB_SELECT_1()
        {
            /*" -2552- EXEC SQL SELECT SUM(VAL_RCAP) INTO :RCAPCOMP-VAL-RCAP:VIND-ORIGEM FROM SEGUROS.RCAP_COMPLEMENTAR WHERE BCO_AVISO = :RCAPCOMP-BCO-AVISO AND AGE_AVISO = :RCAPCOMP-AGE-AVISO AND NUM_AVISO_CREDITO = :RCAPCOMP-NUM-AVISO-CREDITO AND COD_OPERACAO = 310 END-EXEC. */

            var r1910_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1 = new R1910_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1()
            {
                RCAPCOMP_NUM_AVISO_CREDITO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO.ToString(),
                RCAPCOMP_BCO_AVISO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO.ToString(),
                RCAPCOMP_AGE_AVISO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO.ToString(),
            };

            var executed_1 = R1910_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1.Execute(r1910_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPCOMP_VAL_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP);
                _.Move(executed_1.VIND_ORIGEM, VIND_ORIGEM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1910_99_SAIDA*/

        [StopWatch]
        /*" R1950-00-SELECT-V0RCAPCOMP-SECTION */
        private void R1950_00_SELECT_V0RCAPCOMP_SECTION()
        {
            /*" -2589- MOVE '1950' TO WNR-EXEC-SQL. */
            _.Move("1950", W.WABEND.WNR_EXEC_SQL);

            /*" -2591- MOVE ANT-BCOAVISO TO RCAPCOMP-BCO-AVISO. */
            _.Move(W.WS_CHAVE_ANT.ANT_BCOAVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO);

            /*" -2593- MOVE ANT-AGEAVISO TO RCAPCOMP-AGE-AVISO. */
            _.Move(W.WS_CHAVE_ANT.ANT_AGEAVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO);

            /*" -2597- MOVE ANT-NRAVISO TO RCAPCOMP-NUM-AVISO-CREDITO. */
            _.Move(W.WS_CHAVE_ANT.ANT_NRAVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO);

            /*" -2608- PERFORM R1950_00_SELECT_V0RCAPCOMP_DB_SELECT_1 */

            R1950_00_SELECT_V0RCAPCOMP_DB_SELECT_1();

            /*" -2612- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2614- MOVE ZEROS TO RCAPCOMP-VAL-RCAP */
                _.Move(0, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP);

                /*" -2615- ELSE */
            }
            else
            {


                /*" -2616- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2617- MOVE SQLCODE TO WSQLCODE */
                    _.Move(DB.SQLCODE, W.WABEND.WSQLCODE);

                    /*" -2622- DISPLAY 'R1950-00 - PROBLEMAS NO SELECT(RCAPCOMP)' '  ' RCAPCOMP-BCO-AVISO '  ' RCAPCOMP-AGE-AVISO '  ' RCAPCOMP-NUM-AVISO-CREDITO '  ' WSQLCODE */

                    $"R1950-00 - PROBLEMAS NO SELECT(RCAPCOMP)  {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO}  {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO}  {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO}  {W.WABEND.WSQLCODE}"
                    .Display();

                    /*" -2624- MOVE ZEROS TO RCAPCOMP-VAL-RCAP */
                    _.Move(0, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP);

                    /*" -2625- ELSE */
                }
                else
                {


                    /*" -2626- IF VIND-ORIGEM LESS ZEROS */

                    if (VIND_ORIGEM < 00)
                    {

                        /*" -2630- MOVE ZEROS TO RCAPCOMP-VAL-RCAP. */
                        _.Move(0, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP);
                    }

                }

            }


            /*" -2631- IF RCAPCOMP-VAL-RCAP NOT EQUAL ZEROS */

            if (RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP != 00)
            {

                /*" -2632- MOVE 'S' TO WTEM-REGISTRO */
                _.Move("S", W.WTEM_REGISTRO);

                /*" -2634- SUBTRACT RCAPCOMP-VAL-RCAP FROM WS-SDOFINAL */
                W.WS_SDOFINAL.Value = W.WS_SDOFINAL - RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP;

                /*" -2634- PERFORM R1960-00-SELECT-V0RCAPCOMP. */

                R1960_00_SELECT_V0RCAPCOMP_SECTION();
            }


        }

        [StopWatch]
        /*" R1950-00-SELECT-V0RCAPCOMP-DB-SELECT-1 */
        public void R1950_00_SELECT_V0RCAPCOMP_DB_SELECT_1()
        {
            /*" -2608- EXEC SQL SELECT SUM(VAL_RCAP) INTO :RCAPCOMP-VAL-RCAP:VIND-ORIGEM FROM SEGUROS.RCAP_COMPLEMENTAR WHERE BCO_AVISO = :RCAPCOMP-BCO-AVISO AND AGE_AVISO = :RCAPCOMP-AGE-AVISO AND NUM_AVISO_CREDITO = :RCAPCOMP-NUM-AVISO-CREDITO AND COD_OPERACAO = 220 END-EXEC. */

            var r1950_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1 = new R1950_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1()
            {
                RCAPCOMP_NUM_AVISO_CREDITO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO.ToString(),
                RCAPCOMP_BCO_AVISO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO.ToString(),
                RCAPCOMP_AGE_AVISO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO.ToString(),
            };

            var executed_1 = R1950_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1.Execute(r1950_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPCOMP_VAL_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP);
                _.Move(executed_1.VIND_ORIGEM, VIND_ORIGEM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1950_99_SAIDA*/

        [StopWatch]
        /*" R1960-00-SELECT-V0RCAPCOMP-SECTION */
        private void R1960_00_SELECT_V0RCAPCOMP_SECTION()
        {
            /*" -2647- MOVE '1960' TO WNR-EXEC-SQL. */
            _.Move("1960", W.WABEND.WNR_EXEC_SQL);

            /*" -2649- MOVE ANT-BCOAVISO TO RCAPCOMP-BCO-AVISO. */
            _.Move(W.WS_CHAVE_ANT.ANT_BCOAVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO);

            /*" -2651- MOVE ANT-AGEAVISO TO RCAPCOMP-AGE-AVISO. */
            _.Move(W.WS_CHAVE_ANT.ANT_AGEAVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO);

            /*" -2655- MOVE ANT-NRAVISO TO RCAPCOMP-NUM-AVISO-CREDITO. */
            _.Move(W.WS_CHAVE_ANT.ANT_NRAVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO);

            /*" -2666- PERFORM R1960_00_SELECT_V0RCAPCOMP_DB_SELECT_1 */

            R1960_00_SELECT_V0RCAPCOMP_DB_SELECT_1();

            /*" -2670- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2672- MOVE ZEROS TO RCAPCOMP-VAL-RCAP */
                _.Move(0, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP);

                /*" -2673- ELSE */
            }
            else
            {


                /*" -2674- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2675- MOVE SQLCODE TO WSQLCODE */
                    _.Move(DB.SQLCODE, W.WABEND.WSQLCODE);

                    /*" -2680- DISPLAY 'R1960-00 - PROBLEMAS NO SELECT(RCAPCOMP)' '  ' RCAPCOMP-BCO-AVISO '  ' RCAPCOMP-AGE-AVISO '  ' RCAPCOMP-NUM-AVISO-CREDITO '  ' WSQLCODE */

                    $"R1960-00 - PROBLEMAS NO SELECT(RCAPCOMP)  {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO}  {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO}  {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO}  {W.WABEND.WSQLCODE}"
                    .Display();

                    /*" -2682- MOVE ZEROS TO RCAPCOMP-VAL-RCAP */
                    _.Move(0, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP);

                    /*" -2683- ELSE */
                }
                else
                {


                    /*" -2684- IF VIND-ORIGEM LESS ZEROS */

                    if (VIND_ORIGEM < 00)
                    {

                        /*" -2688- MOVE ZEROS TO RCAPCOMP-VAL-RCAP. */
                        _.Move(0, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP);
                    }

                }

            }


            /*" -2689- IF RCAPCOMP-VAL-RCAP NOT EQUAL ZEROS */

            if (RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP != 00)
            {

                /*" -2690- ADD RCAPCOMP-VAL-RCAP TO WS-SDOFINAL. */
                W.WS_SDOFINAL.Value = W.WS_SDOFINAL + RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP;
            }


        }

        [StopWatch]
        /*" R1960-00-SELECT-V0RCAPCOMP-DB-SELECT-1 */
        public void R1960_00_SELECT_V0RCAPCOMP_DB_SELECT_1()
        {
            /*" -2666- EXEC SQL SELECT SUM(VAL_RCAP) INTO :RCAPCOMP-VAL-RCAP:VIND-ORIGEM FROM SEGUROS.RCAP_COMPLEMENTAR WHERE BCO_AVISO = :RCAPCOMP-BCO-AVISO AND AGE_AVISO = :RCAPCOMP-AGE-AVISO AND NUM_AVISO_CREDITO = :RCAPCOMP-NUM-AVISO-CREDITO AND COD_OPERACAO = 320 END-EXEC. */

            var r1960_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1 = new R1960_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1()
            {
                RCAPCOMP_NUM_AVISO_CREDITO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO.ToString(),
                RCAPCOMP_BCO_AVISO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO.ToString(),
                RCAPCOMP_AGE_AVISO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO.ToString(),
            };

            var executed_1 = R1960_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1.Execute(r1960_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPCOMP_VAL_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP);
                _.Move(executed_1.VIND_ORIGEM, VIND_ORIGEM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1960_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-TRATA-ONLINE-SECTION */
        private void R2000_00_TRATA_ONLINE_SECTION()
        {
            /*" -2706- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", W.WABEND.WNR_EXEC_SQL);

            /*" -2707- IF LD01-ORIGEM EQUAL 18 */

            if (W.LD01.LD01_ORIGEM == 18)
            {

                /*" -2708- PERFORM R2100-00-TRATA-RESSAR */

                R2100_00_TRATA_RESSAR_SECTION();

                /*" -2711- GO TO R2000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2712- MOVE SPACES TO WTEM-REGISTRO. */
            _.Move("", W.WTEM_REGISTRO);

            /*" -2719- MOVE WS-VLPRMTOT TO WS-SDOFINAL. */
            _.Move(W.WS_VLPRMTOT, W.WS_SDOFINAL);

            /*" -2726- PERFORM R1800-00-SELECT-V0PARCEHIS. */

            R1800_00_SELECT_V0PARCEHIS_SECTION();

            /*" -2729- PERFORM R1850-00-SELECT-V0FOLLOWUP. */

            R1850_00_SELECT_V0FOLLOWUP_SECTION();

            /*" -2730- IF WTEM-REGISTRO NOT EQUAL 'S' */

            if (W.WTEM_REGISTRO != "S")
            {

                /*" -2731- IF WS-SDOATU LESS ZEROS */

                if (W.WS_SDOATU < 00)
                {

                    /*" -2732- MOVE 'LINE NEG 1' TO LD01-SITUACAO */
                    _.Move("LINE NEG 1", W.LD01.LD01_SITUACAO);

                    /*" -2734- ADD WS-SDOATU TO OR-VLONLINE GE-VLONLINE */
                    W.OR_VLONLINE.Value = W.OR_VLONLINE + W.WS_SDOATU;
                    W.GE_VLONLINE.Value = W.GE_VLONLINE + W.WS_SDOATU;

                    /*" -2735- WRITE REG-CB0155B1 FROM LD01 */
                    _.Move(W.LD01.GetMoveValues(), REG_CB0155B1);

                    CB0155B1.Write(REG_CB0155B1.GetMoveValues().ToString());

                    /*" -2736- ADD 1 TO GV-ARQSAI1 */
                    W.GV_ARQSAI1.Value = W.GV_ARQSAI1 + 1;

                    /*" -2737- GO TO R2000-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/ //GOTO
                    return;

                    /*" -2738- ELSE */
                }
                else
                {


                    /*" -2739- MOVE 'LINE OK   ' TO LD01-SITUACAO */
                    _.Move("LINE OK   ", W.LD01.LD01_SITUACAO);

                    /*" -2741- ADD WS-SDOATU TO OR-VLONLINE GE-VLONLINE */
                    W.OR_VLONLINE.Value = W.OR_VLONLINE + W.WS_SDOATU;
                    W.GE_VLONLINE.Value = W.GE_VLONLINE + W.WS_SDOATU;

                    /*" -2742- WRITE REG-CB0155B1 FROM LD01 */
                    _.Move(W.LD01.GetMoveValues(), REG_CB0155B1);

                    CB0155B1.Write(REG_CB0155B1.GetMoveValues().ToString());

                    /*" -2743- ADD 1 TO GV-ARQSAI1 */
                    W.GV_ARQSAI1.Value = W.GV_ARQSAI1 + 1;

                    /*" -2746- GO TO R2000-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -2749- MOVE WS-SDOFINAL TO LD01-SDOFINAL. */
            _.Move(W.WS_SDOFINAL, W.LD01.LD01_SDOFINAL);

            /*" -2750- IF WS-SDOFINAL NOT EQUAL WS-SDOATU */

            if (W.WS_SDOFINAL != W.WS_SDOATU)
            {

                /*" -2751- MOVE 'LINE DIV  ' TO LD01-SITUACAO */
                _.Move("LINE DIV  ", W.LD01.LD01_SITUACAO);

                /*" -2753- ADD WS-SDOATU TO OR-VLONLINE GE-VLONLINE */
                W.OR_VLONLINE.Value = W.OR_VLONLINE + W.WS_SDOATU;
                W.GE_VLONLINE.Value = W.GE_VLONLINE + W.WS_SDOATU;

                /*" -2754- WRITE REG-CB0155B1 FROM LD01 */
                _.Move(W.LD01.GetMoveValues(), REG_CB0155B1);

                CB0155B1.Write(REG_CB0155B1.GetMoveValues().ToString());

                /*" -2755- ADD 1 TO GV-ARQSAI1 */
                W.GV_ARQSAI1.Value = W.GV_ARQSAI1 + 1;

                /*" -2756- ELSE */
            }
            else
            {


                /*" -2757- IF WS-SDOATU LESS ZEROS */

                if (W.WS_SDOATU < 00)
                {

                    /*" -2758- MOVE 'LINE NEG 2' TO LD01-SITUACAO */
                    _.Move("LINE NEG 2", W.LD01.LD01_SITUACAO);

                    /*" -2760- ADD WS-SDOATU TO OR-VLONLINE GE-VLONLINE */
                    W.OR_VLONLINE.Value = W.OR_VLONLINE + W.WS_SDOATU;
                    W.GE_VLONLINE.Value = W.GE_VLONLINE + W.WS_SDOATU;

                    /*" -2761- WRITE REG-CB0155B1 FROM LD01 */
                    _.Move(W.LD01.GetMoveValues(), REG_CB0155B1);

                    CB0155B1.Write(REG_CB0155B1.GetMoveValues().ToString());

                    /*" -2762- ADD 1 TO GV-ARQSAI1 */
                    W.GV_ARQSAI1.Value = W.GV_ARQSAI1 + 1;

                    /*" -2763- ELSE */
                }
                else
                {


                    /*" -2764- MOVE 'ON-LINE OK' TO LD01-SITUACAO */
                    _.Move("ON-LINE OK", W.LD01.LD01_SITUACAO);

                    /*" -2766- ADD WS-SDOATU TO OR-VLONLINE GE-VLONLINE */
                    W.OR_VLONLINE.Value = W.OR_VLONLINE + W.WS_SDOATU;
                    W.GE_VLONLINE.Value = W.GE_VLONLINE + W.WS_SDOATU;

                    /*" -2767- WRITE REG-CB0155B1 FROM LD01 */
                    _.Move(W.LD01.GetMoveValues(), REG_CB0155B1);

                    CB0155B1.Write(REG_CB0155B1.GetMoveValues().ToString());

                    /*" -2767- ADD 1 TO GV-ARQSAI1. */
                    W.GV_ARQSAI1.Value = W.GV_ARQSAI1 + 1;
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-TRATA-RESSAR-SECTION */
        private void R2100_00_TRATA_RESSAR_SECTION()
        {
            /*" -2780- MOVE '2100' TO WNR-EXEC-SQL. */
            _.Move("2100", W.WABEND.WNR_EXEC_SQL);

            /*" -2781- MOVE SPACES TO WTEM-REGISTRO. */
            _.Move("", W.WTEM_REGISTRO);

            /*" -2784- MOVE WS-VLPRMTOT TO WS-SDOFINAL. */
            _.Move(W.WS_VLPRMTOT, W.WS_SDOFINAL);

            /*" -2787- PERFORM R2150-00-SELECT-V0PARCAVISO. */

            R2150_00_SELECT_V0PARCAVISO_SECTION();

            /*" -2788- IF WTEM-REGISTRO NOT EQUAL 'S' */

            if (W.WTEM_REGISTRO != "S")
            {

                /*" -2789- IF WS-SDOATU LESS ZEROS */

                if (W.WS_SDOATU < 00)
                {

                    /*" -2790- MOVE 'RES NEG 1 ' TO LD01-SITUACAO */
                    _.Move("RES NEG 1 ", W.LD01.LD01_SITUACAO);

                    /*" -2792- ADD WS-SDOATU TO OR-VLONLINE GE-VLONLINE */
                    W.OR_VLONLINE.Value = W.OR_VLONLINE + W.WS_SDOATU;
                    W.GE_VLONLINE.Value = W.GE_VLONLINE + W.WS_SDOATU;

                    /*" -2793- WRITE REG-CB0155B1 FROM LD01 */
                    _.Move(W.LD01.GetMoveValues(), REG_CB0155B1);

                    CB0155B1.Write(REG_CB0155B1.GetMoveValues().ToString());

                    /*" -2794- ADD 1 TO GV-ARQSAI1 */
                    W.GV_ARQSAI1.Value = W.GV_ARQSAI1 + 1;

                    /*" -2795- GO TO R2100-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/ //GOTO
                    return;

                    /*" -2796- ELSE */
                }
                else
                {


                    /*" -2797- MOVE 'RES OK    ' TO LD01-SITUACAO */
                    _.Move("RES OK    ", W.LD01.LD01_SITUACAO);

                    /*" -2799- ADD WS-SDOATU TO OR-VLONLINE GE-VLONLINE */
                    W.OR_VLONLINE.Value = W.OR_VLONLINE + W.WS_SDOATU;
                    W.GE_VLONLINE.Value = W.GE_VLONLINE + W.WS_SDOATU;

                    /*" -2800- WRITE REG-CB0155B1 FROM LD01 */
                    _.Move(W.LD01.GetMoveValues(), REG_CB0155B1);

                    CB0155B1.Write(REG_CB0155B1.GetMoveValues().ToString());

                    /*" -2801- ADD 1 TO GV-ARQSAI1 */
                    W.GV_ARQSAI1.Value = W.GV_ARQSAI1 + 1;

                    /*" -2804- GO TO R2100-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -2807- MOVE WS-SDOFINAL TO LD01-SDOFINAL. */
            _.Move(W.WS_SDOFINAL, W.LD01.LD01_SDOFINAL);

            /*" -2808- IF WS-SDOFINAL NOT EQUAL WS-SDOATU */

            if (W.WS_SDOFINAL != W.WS_SDOATU)
            {

                /*" -2810- IF WS-SDOFINAL LESS ZEROS OR WS-SDOATU LESS ZEROS */

                if (W.WS_SDOFINAL < 00 || W.WS_SDOATU < 00)
                {

                    /*" -2811- MOVE 'RES NEG 2 ' TO LD01-SITUACAO */
                    _.Move("RES NEG 2 ", W.LD01.LD01_SITUACAO);

                    /*" -2813- ADD WS-SDOATU TO OR-VLONLINE GE-VLONLINE */
                    W.OR_VLONLINE.Value = W.OR_VLONLINE + W.WS_SDOATU;
                    W.GE_VLONLINE.Value = W.GE_VLONLINE + W.WS_SDOATU;

                    /*" -2814- WRITE REG-CB0155B1 FROM LD01 */
                    _.Move(W.LD01.GetMoveValues(), REG_CB0155B1);

                    CB0155B1.Write(REG_CB0155B1.GetMoveValues().ToString());

                    /*" -2815- ADD 1 TO GV-ARQSAI1 */
                    W.GV_ARQSAI1.Value = W.GV_ARQSAI1 + 1;

                    /*" -2816- ELSE */
                }
                else
                {


                    /*" -2817- MOVE 'DIV RESSAR' TO LD01-SITUACAO */
                    _.Move("DIV RESSAR", W.LD01.LD01_SITUACAO);

                    /*" -2819- ADD WS-SDOATU TO OR-VLONLINE GE-VLONLINE */
                    W.OR_VLONLINE.Value = W.OR_VLONLINE + W.WS_SDOATU;
                    W.GE_VLONLINE.Value = W.GE_VLONLINE + W.WS_SDOATU;

                    /*" -2820- WRITE REG-CB0155B1 FROM LD01 */
                    _.Move(W.LD01.GetMoveValues(), REG_CB0155B1);

                    CB0155B1.Write(REG_CB0155B1.GetMoveValues().ToString());

                    /*" -2821- ADD 1 TO GV-ARQSAI1 */
                    W.GV_ARQSAI1.Value = W.GV_ARQSAI1 + 1;

                    /*" -2822- ELSE */
                }

            }
            else
            {


                /*" -2823- IF WS-SDOATU LESS ZEROS */

                if (W.WS_SDOATU < 00)
                {

                    /*" -2824- MOVE 'RES NEG 3 ' TO LD01-SITUACAO */
                    _.Move("RES NEG 3 ", W.LD01.LD01_SITUACAO);

                    /*" -2826- ADD WS-SDOATU TO OR-VLONLINE GE-VLONLINE */
                    W.OR_VLONLINE.Value = W.OR_VLONLINE + W.WS_SDOATU;
                    W.GE_VLONLINE.Value = W.GE_VLONLINE + W.WS_SDOATU;

                    /*" -2827- WRITE REG-CB0155B1 FROM LD01 */
                    _.Move(W.LD01.GetMoveValues(), REG_CB0155B1);

                    CB0155B1.Write(REG_CB0155B1.GetMoveValues().ToString());

                    /*" -2828- ADD 1 TO GV-ARQSAI1 */
                    W.GV_ARQSAI1.Value = W.GV_ARQSAI1 + 1;

                    /*" -2829- ELSE */
                }
                else
                {


                    /*" -2830- MOVE 'RESSAR OK ' TO LD01-SITUACAO */
                    _.Move("RESSAR OK ", W.LD01.LD01_SITUACAO);

                    /*" -2832- ADD WS-SDOATU TO OR-VLONLINE GE-VLONLINE */
                    W.OR_VLONLINE.Value = W.OR_VLONLINE + W.WS_SDOATU;
                    W.GE_VLONLINE.Value = W.GE_VLONLINE + W.WS_SDOATU;

                    /*" -2833- WRITE REG-CB0155B1 FROM LD01 */
                    _.Move(W.LD01.GetMoveValues(), REG_CB0155B1);

                    CB0155B1.Write(REG_CB0155B1.GetMoveValues().ToString());

                    /*" -2833- ADD 1 TO GV-ARQSAI1. */
                    W.GV_ARQSAI1.Value = W.GV_ARQSAI1 + 1;
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2150-00-SELECT-V0PARCAVISO-SECTION */
        private void R2150_00_SELECT_V0PARCAVISO_SECTION()
        {
            /*" -2846- MOVE '2150' TO WNR-EXEC-SQL. */
            _.Move("2150", W.WABEND.WNR_EXEC_SQL);

            /*" -2848- MOVE ANT-BCOAVISO TO SI127-BCO-AVISO. */
            _.Move(W.WS_CHAVE_ANT.ANT_BCOAVISO, SI127.DCLSI_PARCELA_AVISO.SI127_BCO_AVISO);

            /*" -2850- MOVE ANT-AGEAVISO TO SI127-AGE-AVISO. */
            _.Move(W.WS_CHAVE_ANT.ANT_AGEAVISO, SI127.DCLSI_PARCELA_AVISO.SI127_AGE_AVISO);

            /*" -2854- MOVE ANT-NRAVISO TO SI127-NUM-AVISO-CREDITO. */
            _.Move(W.WS_CHAVE_ANT.ANT_NRAVISO, SI127.DCLSI_PARCELA_AVISO.SI127_NUM_AVISO_CREDITO);

            /*" -2880- PERFORM R2150_00_SELECT_V0PARCAVISO_DB_SELECT_1 */

            R2150_00_SELECT_V0PARCAVISO_DB_SELECT_1();

            /*" -2884- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2886- MOVE ZEROS TO SINISHIS-VAL-OPERACAO */
                _.Move(0, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);

                /*" -2887- ELSE */
            }
            else
            {


                /*" -2888- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2889- MOVE SQLCODE TO WSQLCODE */
                    _.Move(DB.SQLCODE, W.WABEND.WSQLCODE);

                    /*" -2894- DISPLAY 'R2150-00 - PROBLEMAS NO SELECT(SIAVISO )' '  ' SI127-BCO-AVISO '  ' SI127-AGE-AVISO '  ' SI127-NUM-AVISO-CREDITO '  ' WSQLCODE */

                    $"R2150-00 - PROBLEMAS NO SELECT(SIAVISO )  {SI127.DCLSI_PARCELA_AVISO.SI127_BCO_AVISO}  {SI127.DCLSI_PARCELA_AVISO.SI127_AGE_AVISO}  {SI127.DCLSI_PARCELA_AVISO.SI127_NUM_AVISO_CREDITO}  {W.WABEND.WSQLCODE}"
                    .Display();

                    /*" -2896- MOVE ZEROS TO SINISHIS-VAL-OPERACAO */
                    _.Move(0, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);

                    /*" -2897- ELSE */
                }
                else
                {


                    /*" -2898- IF VIND-ORIGEM LESS ZEROS */

                    if (VIND_ORIGEM < 00)
                    {

                        /*" -2902- MOVE ZEROS TO SINISHIS-VAL-OPERACAO. */
                        _.Move(0, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);
                    }

                }

            }


            /*" -2903- IF SINISHIS-VAL-OPERACAO NOT EQUAL ZEROS */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO != 00)
            {

                /*" -2904- MOVE 'S' TO WTEM-REGISTRO */
                _.Move("S", W.WTEM_REGISTRO);

                /*" -2905- SUBTRACT SINISHIS-VAL-OPERACAO FROM WS-SDOFINAL. */
                W.WS_SDOFINAL.Value = W.WS_SDOFINAL - SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO;
            }


        }

        [StopWatch]
        /*" R2150-00-SELECT-V0PARCAVISO-DB-SELECT-1 */
        public void R2150_00_SELECT_V0PARCAVISO_DB_SELECT_1()
        {
            /*" -2880- EXEC SQL SELECT SUM(C.VAL_OPERACAO) INTO :SINISHIS-VAL-OPERACAO:VIND-ORIGEM FROM SEGUROS.SI_RESSARC_PARCELA A , SEGUROS.SI_PARCELA_AVISO B , SEGUROS.SINISTRO_HISTORICO C WHERE B.BCO_AVISO = :SI127-BCO-AVISO AND B.AGE_AVISO = :SI127-AGE-AVISO AND B.NUM_AVISO_CREDITO = :SI127-NUM-AVISO-CREDITO AND C.COD_OPERACAO = 4100 AND C.NUM_APOL_SINISTRO = A.NUM_APOL_SINISTRO AND C.OCORR_HISTORICO = A.OCORR_HISTORICO AND C.COD_OPERACAO = A.COD_OPERACAO AND C.NUM_APOL_SINISTRO = B.NUM_APOL_SINISTRO AND C.OCORR_HISTORICO = B.OCORR_HISTORICO AND C.COD_OPERACAO = B.COD_OPERACAO_SINI AND A.NUM_APOL_SINISTRO = B.NUM_APOL_SINISTRO AND A.OCORR_HISTORICO = B.OCORR_HISTORICO AND A.COD_OPERACAO = B.COD_OPERACAO_SINI AND A.NUM_RESSARC = B.NUM_RESSARC AND A.SEQ_RESSARC = B.SEQ_RESSARC AND A.NUM_PARCELA = B.NUM_PARCELA END-EXEC. */

            var r2150_00_SELECT_V0PARCAVISO_DB_SELECT_1_Query1 = new R2150_00_SELECT_V0PARCAVISO_DB_SELECT_1_Query1()
            {
                SI127_NUM_AVISO_CREDITO = SI127.DCLSI_PARCELA_AVISO.SI127_NUM_AVISO_CREDITO.ToString(),
                SI127_BCO_AVISO = SI127.DCLSI_PARCELA_AVISO.SI127_BCO_AVISO.ToString(),
                SI127_AGE_AVISO = SI127.DCLSI_PARCELA_AVISO.SI127_AGE_AVISO.ToString(),
            };

            var executed_1 = R2150_00_SELECT_V0PARCAVISO_DB_SELECT_1_Query1.Execute(r2150_00_SELECT_V0PARCAVISO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISHIS_VAL_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);
                _.Move(executed_1.VIND_ORIGEM, VIND_ORIGEM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2160_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-SELECT-V0CONDESCE-SECTION */
        private void R2200_00_SELECT_V0CONDESCE_SECTION()
        {
            /*" -2918- MOVE '2200' TO WNR-EXEC-SQL. */
            _.Move("2200", W.WABEND.WNR_EXEC_SQL);

            /*" -2920- MOVE ANT-BCOAVISO TO CONDESCE-BCO-AVISO. */
            _.Move(W.WS_CHAVE_ANT.ANT_BCOAVISO, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_BCO_AVISO);

            /*" -2922- MOVE ANT-AGEAVISO TO CONDESCE-AGE-AVISO. */
            _.Move(W.WS_CHAVE_ANT.ANT_AGEAVISO, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_AGE_AVISO);

            /*" -2926- MOVE ANT-NRAVISO TO CONDESCE-NUM-AVISO-CREDITO. */
            _.Move(W.WS_CHAVE_ANT.ANT_NRAVISO, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_NUM_AVISO_CREDITO);

            /*" -2937- PERFORM R2200_00_SELECT_V0CONDESCE_DB_SELECT_1 */

            R2200_00_SELECT_V0CONDESCE_DB_SELECT_1();

            /*" -2941- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2943- MOVE ZEROS TO CONDESCE-QTD-REGISTROS */
                _.Move(0, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_QTD_REGISTROS);

                /*" -2944- ELSE */
            }
            else
            {


                /*" -2945- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2946- MOVE SQLCODE TO WSQLCODE */
                    _.Move(DB.SQLCODE, W.WABEND.WSQLCODE);

                    /*" -2951- DISPLAY 'R2200-00 - PROBLEMAS NO SELECT(CONDESCE)' '  ' CONDESCE-BCO-AVISO '  ' CONDESCE-AGE-AVISO '  ' CONDESCE-NUM-AVISO-CREDITO '  ' WSQLCODE */

                    $"R2200-00 - PROBLEMAS NO SELECT(CONDESCE)  {CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_BCO_AVISO}  {CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_AGE_AVISO}  {CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_NUM_AVISO_CREDITO}  {W.WABEND.WSQLCODE}"
                    .Display();

                    /*" -2953- MOVE ZEROS TO CONDESCE-QTD-REGISTROS */
                    _.Move(0, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_QTD_REGISTROS);

                    /*" -2954- ELSE */
                }
                else
                {


                    /*" -2955- IF VIND-ORIGEM LESS ZEROS */

                    if (VIND_ORIGEM < 00)
                    {

                        /*" -2956- MOVE ZEROS TO CONDESCE-QTD-REGISTROS. */
                        _.Move(0, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_QTD_REGISTROS);
                    }

                }

            }


        }

        [StopWatch]
        /*" R2200-00-SELECT-V0CONDESCE-DB-SELECT-1 */
        public void R2200_00_SELECT_V0CONDESCE_DB_SELECT_1()
        {
            /*" -2937- EXEC SQL SELECT SUM(QTD_REGISTROS) INTO :CONDESCE-QTD-REGISTROS:VIND-ORIGEM FROM SEGUROS.CONTROL_DESPES_CEF WHERE BCO_AVISO = :CONDESCE-BCO-AVISO AND AGE_AVISO = :CONDESCE-AGE-AVISO AND NUM_AVISO_CREDITO = :CONDESCE-NUM-AVISO-CREDITO AND COD_EMPRESA = 0 END-EXEC. */

            var r2200_00_SELECT_V0CONDESCE_DB_SELECT_1_Query1 = new R2200_00_SELECT_V0CONDESCE_DB_SELECT_1_Query1()
            {
                CONDESCE_NUM_AVISO_CREDITO = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_NUM_AVISO_CREDITO.ToString(),
                CONDESCE_BCO_AVISO = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_BCO_AVISO.ToString(),
                CONDESCE_AGE_AVISO = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_AGE_AVISO.ToString(),
            };

            var executed_1 = R2200_00_SELECT_V0CONDESCE_DB_SELECT_1_Query1.Execute(r2200_00_SELECT_V0CONDESCE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONDESCE_QTD_REGISTROS, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_QTD_REGISTROS);
                _.Move(executed_1.VIND_ORIGEM, VIND_ORIGEM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-LISTA-DOCUMENTOS-SECTION */
        private void R3000_00_LISTA_DOCUMENTOS_SECTION()
        {
            /*" -2969- MOVE '3000' TO WNR-EXEC-SQL. */
            _.Move("3000", W.WABEND.WNR_EXEC_SQL);

            /*" -2970- WRITE REG-CB0155B3 FROM LC04. */
            _.Move(W.LC04.GetMoveValues(), REG_CB0155B3);

            CB0155B3.Write(REG_CB0155B3.GetMoveValues().ToString());

            /*" -2973- WRITE REG-CB0155B3 FROM LC05. */
            _.Move(W.LC05.GetMoveValues(), REG_CB0155B3);

            CB0155B3.Write(REG_CB0155B3.GetMoveValues().ToString());

            /*" -2976- MOVE ZEROS TO LD-MOVICOB GV-MOVICOB. */
            _.Move(0, W.LD_MOVICOB, W.GV_MOVICOB);

            /*" -2977- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", W.WFIM_MOVIMENTO);

            /*" -2979- PERFORM R3100-00-DECLARE-MOVICOB. */

            R3100_00_DECLARE_MOVICOB_SECTION();

            /*" -2981- PERFORM R3110-00-FETCH-MOVICOB. */

            R3110_00_FETCH_MOVICOB_SECTION();

            /*" -2984- PERFORM R3150-00-PROCESSA-MOVICOB UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!W.WFIM_MOVIMENTO.IsEmpty()))
            {

                R3150_00_PROCESSA_MOVICOB_SECTION();
            }

            /*" -2985- DISPLAY ' ' . */
            _.Display($" ");

            /*" -2986- DISPLAY 'LIDOS MOVICOB .............. ' LD-MOVICOB. */
            _.Display($"LIDOS MOVICOB .............. {W.LD_MOVICOB}");

            /*" -2987- DISPLAY 'GRAVA MOVICOB .............. ' GV-MOVICOB. */
            _.Display($"GRAVA MOVICOB .............. {W.GV_MOVICOB}");

            /*" -2989- DISPLAY ' ' . */
            _.Display($" ");

            /*" -2989- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -2995- MOVE ZEROS TO LD-FOLLOW GV-FOLLOW. */
            _.Move(0, W.LD_FOLLOW, W.GV_FOLLOW);

            /*" -2996- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", W.WFIM_MOVIMENTO);

            /*" -2998- PERFORM R3200-00-DECLARE-FOLLOW. */

            R3200_00_DECLARE_FOLLOW_SECTION();

            /*" -3000- PERFORM R3210-00-FETCH-FOLLOW. */

            R3210_00_FETCH_FOLLOW_SECTION();

            /*" -3003- PERFORM R3250-00-PROCESSA-FOLLOW UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!W.WFIM_MOVIMENTO.IsEmpty()))
            {

                R3250_00_PROCESSA_FOLLOW_SECTION();
            }

            /*" -3004- DISPLAY ' ' . */
            _.Display($" ");

            /*" -3005- DISPLAY 'LIDOS FOLLOW ............... ' LD-FOLLOW. */
            _.Display($"LIDOS FOLLOW ............... {W.LD_FOLLOW}");

            /*" -3006- DISPLAY 'GRAVA FOLLOW ............... ' GV-FOLLOW. */
            _.Display($"GRAVA FOLLOW ............... {W.GV_FOLLOW}");

            /*" -3008- DISPLAY ' ' . */
            _.Display($" ");

            /*" -3008- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -3014- MOVE ZEROS TO LD-RCAP GV-RCAP. */
            _.Move(0, W.LD_RCAP, W.GV_RCAP);

            /*" -3015- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", W.WFIM_MOVIMENTO);

            /*" -3017- PERFORM R3400-00-DECLARE-RCAP. */

            R3400_00_DECLARE_RCAP_SECTION();

            /*" -3019- PERFORM R3410-00-FETCH-RCAP. */

            R3410_00_FETCH_RCAP_SECTION();

            /*" -3022- PERFORM R3450-00-PROCESSA-RCAP UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!W.WFIM_MOVIMENTO.IsEmpty()))
            {

                R3450_00_PROCESSA_RCAP_SECTION();
            }

            /*" -3023- DISPLAY ' ' . */
            _.Display($" ");

            /*" -3024- DISPLAY 'LIDOS RCAP ................. ' LD-RCAP. */
            _.Display($"LIDOS RCAP ................. {W.LD_RCAP}");

            /*" -3025- DISPLAY 'GRAVA RCAP ................. ' GV-RCAP. */
            _.Display($"GRAVA RCAP ................. {W.GV_RCAP}");

            /*" -3027- DISPLAY ' ' . */
            _.Display($" ");

            /*" -3027- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -3031- DISPLAY ' ' . */
            _.Display($" ");

            /*" -3032- DISPLAY 'GRAVA ARQUIVO 03 ........... ' GV-ARQSAI3 */
            _.Display($"GRAVA ARQUIVO 03 ........... {W.GV_ARQSAI3}");

            /*" -3032- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-DECLARE-MOVICOB-SECTION */
        private void R3100_00_DECLARE_MOVICOB_SECTION()
        {
            /*" -3045- MOVE '3100' TO WNR-EXEC-SQL. */
            _.Move("3100", W.WABEND.WNR_EXEC_SQL);

            /*" -3065- PERFORM R3100_00_DECLARE_MOVICOB_DB_DECLARE_1 */

            R3100_00_DECLARE_MOVICOB_DB_DECLARE_1();

            /*" -3067- PERFORM R3100_00_DECLARE_MOVICOB_DB_OPEN_1 */

            R3100_00_DECLARE_MOVICOB_DB_OPEN_1();

            /*" -3071- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3072- DISPLAY 'R3100-00 - PROBLEMAS DECLARE (MOVICOB)    ' */
                _.Display($"R3100-00 - PROBLEMAS DECLARE (MOVICOB)    ");

                /*" -3072- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3100-00-DECLARE-MOVICOB-DB-OPEN-1 */
        public void R3100_00_DECLARE_MOVICOB_DB_OPEN_1()
        {
            /*" -3067- EXEC SQL OPEN V0MOVICOB1 END-EXEC. */

            V0MOVICOB1.Open();

        }

        [StopWatch]
        /*" R3200-00-DECLARE-FOLLOW-DB-DECLARE-1 */
        public void R3200_00_DECLARE_FOLLOW_DB_DECLARE_1()
        {
            /*" -3235- EXEC SQL DECLARE V0FOLLOW1 CURSOR FOR SELECT NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , DATA_MOVIMENTO , VAL_OPERACAO , BCO_AVISO , AGE_AVISO , NUM_AVISO_CREDITO , DATA_QUITACAO , NUM_NOSSO_TITULO FROM SEGUROS.FOLLOW_UP WHERE SIT_REGISTRO = '0' ORDER BY BCO_AVISO , AGE_AVISO , NUM_AVISO_CREDITO , DATA_QUITACAO , NUM_APOLICE END-EXEC. */
            V0FOLLOW1 = new CB0155B_V0FOLLOW1(false);
            string GetQuery_V0FOLLOW1()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							NUM_ENDOSSO
							, 
							NUM_PARCELA
							, 
							DATA_MOVIMENTO
							, 
							VAL_OPERACAO
							, 
							BCO_AVISO
							, 
							AGE_AVISO
							, 
							NUM_AVISO_CREDITO
							, 
							DATA_QUITACAO
							, 
							NUM_NOSSO_TITULO 
							FROM SEGUROS.FOLLOW_UP 
							WHERE SIT_REGISTRO = '0' 
							ORDER BY BCO_AVISO
							, 
							AGE_AVISO
							, 
							NUM_AVISO_CREDITO
							, 
							DATA_QUITACAO
							, 
							NUM_APOLICE";

                return query;
            }
            V0FOLLOW1.GetQueryEvent += GetQuery_V0FOLLOW1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R3110-00-FETCH-MOVICOB-SECTION */
        private void R3110_00_FETCH_MOVICOB_SECTION()
        {
            /*" -3085- MOVE '3110' TO WNR-EXEC-SQL. */
            _.Move("3110", W.WABEND.WNR_EXEC_SQL);

            /*" -3097- PERFORM R3110_00_FETCH_MOVICOB_DB_FETCH_1 */

            R3110_00_FETCH_MOVICOB_DB_FETCH_1();

            /*" -3101- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3101- PERFORM R3110_00_FETCH_MOVICOB_DB_CLOSE_1 */

                R3110_00_FETCH_MOVICOB_DB_CLOSE_1();

                /*" -3103- MOVE 'S' TO WFIM-MOVIMENTO */
                _.Move("S", W.WFIM_MOVIMENTO);

                /*" -3105- GO TO R3110-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3110_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3106- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3107- DISPLAY 'R3110-00 - PROBLEMAS FETCH   (MOVICOB)    ' */
                _.Display($"R3110-00 - PROBLEMAS FETCH   (MOVICOB)    ");

                /*" -3110- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3110- ADD 1 TO LD-MOVICOB. */
            W.LD_MOVICOB.Value = W.LD_MOVICOB + 1;

        }

        [StopWatch]
        /*" R3110-00-FETCH-MOVICOB-DB-FETCH-1 */
        public void R3110_00_FETCH_MOVICOB_DB_FETCH_1()
        {
            /*" -3097- EXEC SQL FETCH V0MOVICOB1 INTO :MOVIMCOB-COD-BANCO , :MOVIMCOB-COD-AGENCIA , :MOVIMCOB-NUM-AVISO , :MOVIMCOB-DATA-MOVIMENTO , :MOVIMCOB-DATA-QUITACAO , :MOVIMCOB-NUM-TITULO , :MOVIMCOB-NUM-APOLICE , :MOVIMCOB-NUM-ENDOSSO , :MOVIMCOB-NUM-PARCELA , :MOVIMCOB-VAL-TITULO , :MOVIMCOB-NUM-NOSSO-TITULO END-EXEC. */

            if (V0MOVICOB1.Fetch())
            {
                _.Move(V0MOVICOB1.MOVIMCOB_COD_BANCO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO);
                _.Move(V0MOVICOB1.MOVIMCOB_COD_AGENCIA, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA);
                _.Move(V0MOVICOB1.MOVIMCOB_NUM_AVISO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO);
                _.Move(V0MOVICOB1.MOVIMCOB_DATA_MOVIMENTO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_MOVIMENTO);
                _.Move(V0MOVICOB1.MOVIMCOB_DATA_QUITACAO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_QUITACAO);
                _.Move(V0MOVICOB1.MOVIMCOB_NUM_TITULO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO);
                _.Move(V0MOVICOB1.MOVIMCOB_NUM_APOLICE, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE);
                _.Move(V0MOVICOB1.MOVIMCOB_NUM_ENDOSSO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO);
                _.Move(V0MOVICOB1.MOVIMCOB_NUM_PARCELA, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA);
                _.Move(V0MOVICOB1.MOVIMCOB_VAL_TITULO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO);
                _.Move(V0MOVICOB1.MOVIMCOB_NUM_NOSSO_TITULO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO);
            }

        }

        [StopWatch]
        /*" R3110-00-FETCH-MOVICOB-DB-CLOSE-1 */
        public void R3110_00_FETCH_MOVICOB_DB_CLOSE_1()
        {
            /*" -3101- EXEC SQL CLOSE V0MOVICOB1 END-EXEC */

            V0MOVICOB1.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3110_99_SAIDA*/

        [StopWatch]
        /*" R3150-00-PROCESSA-MOVICOB-SECTION */
        private void R3150_00_PROCESSA_MOVICOB_SECTION()
        {
            /*" -3123- MOVE '3150' TO WNR-EXEC-SQL. */
            _.Move("3150", W.WABEND.WNR_EXEC_SQL);

            /*" -3125- MOVE 'MOVICOB   ' TO LD03-BASE. */
            _.Move("MOVICOB   ", W.LD03.LD03_BASE);

            /*" -3127- MOVE MOVIMCOB-COD-BANCO TO LD03-BCOAVISO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO, W.LD03.LD03_BCOAVISO);

            /*" -3129- MOVE MOVIMCOB-COD-AGENCIA TO LD03-AGEAVISO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA, W.LD03.LD03_AGEAVISO);

            /*" -3132- MOVE MOVIMCOB-NUM-AVISO TO LD03-NRAVISO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO, W.LD03.LD03_NRAVISO);

            /*" -3134- MOVE MOVIMCOB-DATA-MOVIMENTO TO WDATA-REL. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_MOVIMENTO, W.WDATA_REL);

            /*" -3135- MOVE WDAT-REL-DIA TO WDATA-DD-CABEC */
            _.Move(W.FILLER_0.WDAT_REL_DIA, W.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -3136- MOVE WDAT-REL-MES TO WDATA-MM-CABEC */
            _.Move(W.FILLER_0.WDAT_REL_MES, W.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -3137- MOVE WDAT-REL-ANO TO WDATA-AA-CABEC */
            _.Move(W.FILLER_0.WDAT_REL_ANO, W.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -3139- MOVE WDATA-CABEC TO LD03-DTMOVTO. */
            _.Move(W.WDATA_CABEC, W.LD03.LD03_DTMOVTO);

            /*" -3141- MOVE MOVIMCOB-DATA-QUITACAO TO WDATA-REL. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_QUITACAO, W.WDATA_REL);

            /*" -3142- MOVE WDAT-REL-DIA TO WDATA-DD-CABEC */
            _.Move(W.FILLER_0.WDAT_REL_DIA, W.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -3143- MOVE WDAT-REL-MES TO WDATA-MM-CABEC */
            _.Move(W.FILLER_0.WDAT_REL_MES, W.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -3144- MOVE WDAT-REL-ANO TO WDATA-AA-CABEC */
            _.Move(W.FILLER_0.WDAT_REL_ANO, W.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -3146- MOVE WDATA-CABEC TO LD03-DTQITBCO. */
            _.Move(W.WDATA_CABEC, W.LD03.LD03_DTQITBCO);

            /*" -3148- MOVE MOVIMCOB-VAL-TITULO TO LD03-VLPREMIO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO, W.LD03.LD03_VLPREMIO);

            /*" -3150- MOVE MOVIMCOB-NUM-NOSSO-TITULO TO LD03-PROPOSTA. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO, W.LD03.LD03_PROPOSTA);

            /*" -3152- MOVE MOVIMCOB-NUM-TITULO TO LD03-TITULO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO, W.LD03.LD03_TITULO);

            /*" -3154- MOVE ZEROS TO LD03-NRRCAPCO. */
            _.Move(0, W.LD03.LD03_NRRCAPCO);

            /*" -3156- MOVE MOVIMCOB-NUM-APOLICE TO LD03-APOLICE. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE, W.LD03.LD03_APOLICE);

            /*" -3158- MOVE MOVIMCOB-NUM-ENDOSSO TO LD03-ENDOSSO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO, W.LD03.LD03_ENDOSSO);

            /*" -3160- MOVE MOVIMCOB-NUM-PARCELA TO LD03-PARCELA. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA, W.LD03.LD03_PARCELA);

            /*" -3162- MOVE ZEROS TO LD03-PRODUTO. */
            _.Move(0, W.LD03.LD03_PRODUTO);

            /*" -3166- MOVE ZEROS TO LD03-AGENCIA. */
            _.Move(0, W.LD03.LD03_AGENCIA);

            /*" -3168- MOVE MOVIMCOB-DATA-QUITACAO TO WDATA-REL. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_QUITACAO, W.WDATA_REL);

            /*" -3169- MOVE WDAT-REL-DIA TO LPARM02-DD */
            _.Move(W.FILLER_0.WDAT_REL_DIA, LPARM.LPARM02.LPARM02_DD);

            /*" -3170- MOVE WDAT-REL-MES TO LPARM02-MM */
            _.Move(W.FILLER_0.WDAT_REL_MES, LPARM.LPARM02.LPARM02_MM);

            /*" -3172- MOVE WDAT-REL-ANO TO LPARM02-AA. */
            _.Move(W.FILLER_0.WDAT_REL_ANO, LPARM.LPARM02.LPARM02_AA);

            /*" -3174- PERFORM R3160-00-CALCULA-DIAS. */

            R3160_00_CALCULA_DIAS_SECTION();

            /*" -3177- MOVE LPARM03 TO LD03-QTDIAS. */
            _.Move(LPARM.LPARM03, W.LD03.LD03_QTDIAS);

            /*" -3178- WRITE REG-CB0155B3 FROM LD03. */
            _.Move(W.LD03.GetMoveValues(), REG_CB0155B3);

            CB0155B3.Write(REG_CB0155B3.GetMoveValues().ToString());

            /*" -3178- ADD 1 TO GV-ARQSAI3. */
            W.GV_ARQSAI3.Value = W.GV_ARQSAI3 + 1;

            /*" -0- FLUXCONTROL_PERFORM R3150_90_LEITURA */

            R3150_90_LEITURA();

        }

        [StopWatch]
        /*" R3150-90-LEITURA */
        private void R3150_90_LEITURA(bool isPerform = false)
        {
            /*" -3183- PERFORM R3110-00-FETCH-MOVICOB. */

            R3110_00_FETCH_MOVICOB_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3150_99_SAIDA*/

        [StopWatch]
        /*" R3160-00-CALCULA-DIAS-SECTION */
        private void R3160_00_CALCULA_DIAS_SECTION()
        {
            /*" -3195- MOVE '3160' TO WNR-EXEC-SQL. */
            _.Move("3160", W.WABEND.WNR_EXEC_SQL);

            /*" -3197- MOVE SISTEMAS-DATA-MOV-ABERTO TO WDATA-REL. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, W.WDATA_REL);

            /*" -3198- MOVE WDAT-REL-DIA TO LPARM01-DD */
            _.Move(W.FILLER_0.WDAT_REL_DIA, LPARM.LPARM01.LPARM01_DD);

            /*" -3199- MOVE WDAT-REL-MES TO LPARM01-MM */
            _.Move(W.FILLER_0.WDAT_REL_MES, LPARM.LPARM01.LPARM01_MM);

            /*" -3201- MOVE WDAT-REL-ANO TO LPARM01-AA. */
            _.Move(W.FILLER_0.WDAT_REL_ANO, LPARM.LPARM01.LPARM01_AA);

            /*" -3203- MOVE ZEROS TO LPARM03. */
            _.Move(0, LPARM.LPARM03);

            /*" -3203- CALL 'PRODIFC1' USING LPARM. */
            _.Call("PRODIFC1", LPARM);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3160_99_SAIDA*/

        [StopWatch]
        /*" R3200-00-DECLARE-FOLLOW-SECTION */
        private void R3200_00_DECLARE_FOLLOW_SECTION()
        {
            /*" -3216- MOVE '3200' TO WNR-EXEC-SQL. */
            _.Move("3200", W.WABEND.WNR_EXEC_SQL);

            /*" -3235- PERFORM R3200_00_DECLARE_FOLLOW_DB_DECLARE_1 */

            R3200_00_DECLARE_FOLLOW_DB_DECLARE_1();

            /*" -3237- PERFORM R3200_00_DECLARE_FOLLOW_DB_OPEN_1 */

            R3200_00_DECLARE_FOLLOW_DB_OPEN_1();

            /*" -3241- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3242- DISPLAY 'R3200-00 - PROBLEMAS DECLARE (FOLLOW)     ' */
                _.Display($"R3200-00 - PROBLEMAS DECLARE (FOLLOW)     ");

                /*" -3242- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3200-00-DECLARE-FOLLOW-DB-OPEN-1 */
        public void R3200_00_DECLARE_FOLLOW_DB_OPEN_1()
        {
            /*" -3237- EXEC SQL OPEN V0FOLLOW1 END-EXEC. */

            V0FOLLOW1.Open();

        }

        [StopWatch]
        /*" R3400-00-DECLARE-RCAP-DB-DECLARE-1 */
        public void R3400_00_DECLARE_RCAP_DB_DECLARE_1()
        {
            /*" -3392- EXEC SQL DECLARE V0RCAP1 CURSOR FOR SELECT A.NUM_RCAP , A.NUM_RCAP_COMPLEMEN , A.DATA_MOVIMENTO , A.BCO_AVISO , A.AGE_AVISO , A.NUM_AVISO_CREDITO , A.VAL_RCAP , A.DATA_RCAP , B.NUM_TITULO , B.CODIGO_PRODUTO , B.AGE_COBRANCA , B.NUM_CERTIFICADO FROM SEGUROS.RCAP_COMPLEMENTAR A, SEGUROS.RCAPS B WHERE A.DATA_MOVIMENTO >= '2000-11-01' AND A.SIT_REGISTRO = '0' AND A.COD_OPERACAO IN (100,110,310,320,500) AND A.COD_FONTE = B.COD_FONTE AND A.NUM_RCAP = B.NUM_RCAP ORDER BY A.BCO_AVISO , A.AGE_AVISO , A.NUM_AVISO_CREDITO , A.DATA_RCAP , A.NUM_RCAP , A.NUM_RCAP_COMPLEMEN END-EXEC. */
            V0RCAP1 = new CB0155B_V0RCAP1(false);
            string GetQuery_V0RCAP1()
            {
                var query = @$"SELECT A.NUM_RCAP
							, 
							A.NUM_RCAP_COMPLEMEN
							, 
							A.DATA_MOVIMENTO
							, 
							A.BCO_AVISO
							, 
							A.AGE_AVISO
							, 
							A.NUM_AVISO_CREDITO
							, 
							A.VAL_RCAP
							, 
							A.DATA_RCAP
							, 
							B.NUM_TITULO
							, 
							B.CODIGO_PRODUTO
							, 
							B.AGE_COBRANCA
							, 
							B.NUM_CERTIFICADO 
							FROM SEGUROS.RCAP_COMPLEMENTAR A
							, 
							SEGUROS.RCAPS B 
							WHERE A.DATA_MOVIMENTO >= '2000-11-01' 
							AND A.SIT_REGISTRO = '0' 
							AND A.COD_OPERACAO IN (100
							,110
							,310
							,320
							,500) 
							AND A.COD_FONTE = B.COD_FONTE 
							AND A.NUM_RCAP = B.NUM_RCAP 
							ORDER BY A.BCO_AVISO
							, 
							A.AGE_AVISO
							, 
							A.NUM_AVISO_CREDITO
							, 
							A.DATA_RCAP
							, 
							A.NUM_RCAP
							, 
							A.NUM_RCAP_COMPLEMEN";

                return query;
            }
            V0RCAP1.GetQueryEvent += GetQuery_V0RCAP1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/

        [StopWatch]
        /*" R3210-00-FETCH-FOLLOW-SECTION */
        private void R3210_00_FETCH_FOLLOW_SECTION()
        {
            /*" -3255- MOVE '3210' TO WNR-EXEC-SQL. */
            _.Move("3210", W.WABEND.WNR_EXEC_SQL);

            /*" -3266- PERFORM R3210_00_FETCH_FOLLOW_DB_FETCH_1 */

            R3210_00_FETCH_FOLLOW_DB_FETCH_1();

            /*" -3270- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3270- PERFORM R3210_00_FETCH_FOLLOW_DB_CLOSE_1 */

                R3210_00_FETCH_FOLLOW_DB_CLOSE_1();

                /*" -3272- MOVE 'S' TO WFIM-MOVIMENTO */
                _.Move("S", W.WFIM_MOVIMENTO);

                /*" -3274- GO TO R3210-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3210_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3275- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3276- DISPLAY 'R3210-00 - PROBLEMAS FETCH   (FOLLOW)     ' */
                _.Display($"R3210-00 - PROBLEMAS FETCH   (FOLLOW)     ");

                /*" -3279- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3279- ADD 1 TO LD-FOLLOW. */
            W.LD_FOLLOW.Value = W.LD_FOLLOW + 1;

        }

        [StopWatch]
        /*" R3210-00-FETCH-FOLLOW-DB-FETCH-1 */
        public void R3210_00_FETCH_FOLLOW_DB_FETCH_1()
        {
            /*" -3266- EXEC SQL FETCH V0FOLLOW1 INTO :FOLLOUP-NUM-APOLICE , :FOLLOUP-NUM-ENDOSSO , :FOLLOUP-NUM-PARCELA , :FOLLOUP-DATA-MOVIMENTO , :FOLLOUP-VAL-OPERACAO , :FOLLOUP-BCO-AVISO , :FOLLOUP-AGE-AVISO , :FOLLOUP-NUM-AVISO-CREDITO , :FOLLOUP-DATA-QUITACAO , :FOLLOUP-NUM-NOSSO-TITULO END-EXEC. */

            if (V0FOLLOW1.Fetch())
            {
                _.Move(V0FOLLOW1.FOLLOUP_NUM_APOLICE, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_APOLICE);
                _.Move(V0FOLLOW1.FOLLOUP_NUM_ENDOSSO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_ENDOSSO);
                _.Move(V0FOLLOW1.FOLLOUP_NUM_PARCELA, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_PARCELA);
                _.Move(V0FOLLOW1.FOLLOUP_DATA_MOVIMENTO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_DATA_MOVIMENTO);
                _.Move(V0FOLLOW1.FOLLOUP_VAL_OPERACAO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_VAL_OPERACAO);
                _.Move(V0FOLLOW1.FOLLOUP_BCO_AVISO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_BCO_AVISO);
                _.Move(V0FOLLOW1.FOLLOUP_AGE_AVISO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_AGE_AVISO);
                _.Move(V0FOLLOW1.FOLLOUP_NUM_AVISO_CREDITO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_AVISO_CREDITO);
                _.Move(V0FOLLOW1.FOLLOUP_DATA_QUITACAO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_DATA_QUITACAO);
                _.Move(V0FOLLOW1.FOLLOUP_NUM_NOSSO_TITULO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_NOSSO_TITULO);
            }

        }

        [StopWatch]
        /*" R3210-00-FETCH-FOLLOW-DB-CLOSE-1 */
        public void R3210_00_FETCH_FOLLOW_DB_CLOSE_1()
        {
            /*" -3270- EXEC SQL CLOSE V0FOLLOW1 END-EXEC */

            V0FOLLOW1.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3210_99_SAIDA*/

        [StopWatch]
        /*" R3250-00-PROCESSA-FOLLOW-SECTION */
        private void R3250_00_PROCESSA_FOLLOW_SECTION()
        {
            /*" -3292- MOVE '3250' TO WNR-EXEC-SQL. */
            _.Move("3250", W.WABEND.WNR_EXEC_SQL);

            /*" -3294- MOVE 'FOLLOWUP  ' TO LD03-BASE. */
            _.Move("FOLLOWUP  ", W.LD03.LD03_BASE);

            /*" -3296- MOVE FOLLOUP-BCO-AVISO TO LD03-BCOAVISO. */
            _.Move(FOLLOUP.DCLFOLLOW_UP.FOLLOUP_BCO_AVISO, W.LD03.LD03_BCOAVISO);

            /*" -3298- MOVE FOLLOUP-AGE-AVISO TO LD03-AGEAVISO. */
            _.Move(FOLLOUP.DCLFOLLOW_UP.FOLLOUP_AGE_AVISO, W.LD03.LD03_AGEAVISO);

            /*" -3301- MOVE FOLLOUP-NUM-AVISO-CREDITO TO LD03-NRAVISO. */
            _.Move(FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_AVISO_CREDITO, W.LD03.LD03_NRAVISO);

            /*" -3303- MOVE FOLLOUP-DATA-MOVIMENTO TO WDATA-REL. */
            _.Move(FOLLOUP.DCLFOLLOW_UP.FOLLOUP_DATA_MOVIMENTO, W.WDATA_REL);

            /*" -3304- MOVE WDAT-REL-DIA TO WDATA-DD-CABEC */
            _.Move(W.FILLER_0.WDAT_REL_DIA, W.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -3305- MOVE WDAT-REL-MES TO WDATA-MM-CABEC */
            _.Move(W.FILLER_0.WDAT_REL_MES, W.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -3306- MOVE WDAT-REL-ANO TO WDATA-AA-CABEC */
            _.Move(W.FILLER_0.WDAT_REL_ANO, W.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -3308- MOVE WDATA-CABEC TO LD03-DTMOVTO. */
            _.Move(W.WDATA_CABEC, W.LD03.LD03_DTMOVTO);

            /*" -3310- MOVE FOLLOUP-DATA-QUITACAO TO WDATA-REL. */
            _.Move(FOLLOUP.DCLFOLLOW_UP.FOLLOUP_DATA_QUITACAO, W.WDATA_REL);

            /*" -3311- MOVE WDAT-REL-DIA TO WDATA-DD-CABEC */
            _.Move(W.FILLER_0.WDAT_REL_DIA, W.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -3312- MOVE WDAT-REL-MES TO WDATA-MM-CABEC */
            _.Move(W.FILLER_0.WDAT_REL_MES, W.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -3313- MOVE WDAT-REL-ANO TO WDATA-AA-CABEC */
            _.Move(W.FILLER_0.WDAT_REL_ANO, W.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -3315- MOVE WDATA-CABEC TO LD03-DTQITBCO. */
            _.Move(W.WDATA_CABEC, W.LD03.LD03_DTQITBCO);

            /*" -3317- MOVE FOLLOUP-VAL-OPERACAO TO LD03-VLPREMIO. */
            _.Move(FOLLOUP.DCLFOLLOW_UP.FOLLOUP_VAL_OPERACAO, W.LD03.LD03_VLPREMIO);

            /*" -3319- MOVE FOLLOUP-NUM-NOSSO-TITULO TO LD03-PROPOSTA. */
            _.Move(FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_NOSSO_TITULO, W.LD03.LD03_PROPOSTA);

            /*" -3321- MOVE ZEROS TO LD03-TITULO. */
            _.Move(0, W.LD03.LD03_TITULO);

            /*" -3323- MOVE ZEROS TO LD03-NRRCAPCO. */
            _.Move(0, W.LD03.LD03_NRRCAPCO);

            /*" -3325- MOVE FOLLOUP-NUM-APOLICE TO LD03-APOLICE. */
            _.Move(FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_APOLICE, W.LD03.LD03_APOLICE);

            /*" -3327- MOVE FOLLOUP-NUM-ENDOSSO TO LD03-ENDOSSO. */
            _.Move(FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_ENDOSSO, W.LD03.LD03_ENDOSSO);

            /*" -3329- MOVE FOLLOUP-NUM-PARCELA TO LD03-PARCELA. */
            _.Move(FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_PARCELA, W.LD03.LD03_PARCELA);

            /*" -3331- MOVE ZEROS TO LD03-PRODUTO. */
            _.Move(0, W.LD03.LD03_PRODUTO);

            /*" -3335- MOVE ZEROS TO LD03-AGENCIA. */
            _.Move(0, W.LD03.LD03_AGENCIA);

            /*" -3337- MOVE FOLLOUP-DATA-QUITACAO TO WDATA-REL. */
            _.Move(FOLLOUP.DCLFOLLOW_UP.FOLLOUP_DATA_QUITACAO, W.WDATA_REL);

            /*" -3338- MOVE WDAT-REL-DIA TO LPARM02-DD */
            _.Move(W.FILLER_0.WDAT_REL_DIA, LPARM.LPARM02.LPARM02_DD);

            /*" -3339- MOVE WDAT-REL-MES TO LPARM02-MM */
            _.Move(W.FILLER_0.WDAT_REL_MES, LPARM.LPARM02.LPARM02_MM);

            /*" -3341- MOVE WDAT-REL-ANO TO LPARM02-AA. */
            _.Move(W.FILLER_0.WDAT_REL_ANO, LPARM.LPARM02.LPARM02_AA);

            /*" -3343- PERFORM R3160-00-CALCULA-DIAS. */

            R3160_00_CALCULA_DIAS_SECTION();

            /*" -3346- MOVE LPARM03 TO LD03-QTDIAS. */
            _.Move(LPARM.LPARM03, W.LD03.LD03_QTDIAS);

            /*" -3347- WRITE REG-CB0155B3 FROM LD03. */
            _.Move(W.LD03.GetMoveValues(), REG_CB0155B3);

            CB0155B3.Write(REG_CB0155B3.GetMoveValues().ToString());

            /*" -3347- ADD 1 TO GV-ARQSAI3. */
            W.GV_ARQSAI3.Value = W.GV_ARQSAI3 + 1;

            /*" -0- FLUXCONTROL_PERFORM R3250_90_LEITURA */

            R3250_90_LEITURA();

        }

        [StopWatch]
        /*" R3250-90-LEITURA */
        private void R3250_90_LEITURA(bool isPerform = false)
        {
            /*" -3352- PERFORM R3210-00-FETCH-FOLLOW. */

            R3210_00_FETCH_FOLLOW_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3250_99_SAIDA*/

        [StopWatch]
        /*" R3400-00-DECLARE-RCAP-SECTION */
        private void R3400_00_DECLARE_RCAP_SECTION()
        {
            /*" -3364- MOVE '3400' TO WNR-EXEC-SQL. */
            _.Move("3400", W.WABEND.WNR_EXEC_SQL);

            /*" -3392- PERFORM R3400_00_DECLARE_RCAP_DB_DECLARE_1 */

            R3400_00_DECLARE_RCAP_DB_DECLARE_1();

            /*" -3394- PERFORM R3400_00_DECLARE_RCAP_DB_OPEN_1 */

            R3400_00_DECLARE_RCAP_DB_OPEN_1();

            /*" -3398- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3399- DISPLAY 'R3400-00 - PROBLEMAS DECLARE (RCAP)       ' */
                _.Display($"R3400-00 - PROBLEMAS DECLARE (RCAP)       ");

                /*" -3399- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3400-00-DECLARE-RCAP-DB-OPEN-1 */
        public void R3400_00_DECLARE_RCAP_DB_OPEN_1()
        {
            /*" -3394- EXEC SQL OPEN V0RCAP1 END-EXEC. */

            V0RCAP1.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3400_99_SAIDA*/

        [StopWatch]
        /*" R3410-00-FETCH-RCAP-SECTION */
        private void R3410_00_FETCH_RCAP_SECTION()
        {
            /*" -3412- MOVE '3410' TO WNR-EXEC-SQL. */
            _.Move("3410", W.WABEND.WNR_EXEC_SQL);

            /*" -3425- PERFORM R3410_00_FETCH_RCAP_DB_FETCH_1 */

            R3410_00_FETCH_RCAP_DB_FETCH_1();

            /*" -3429- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3429- PERFORM R3410_00_FETCH_RCAP_DB_CLOSE_1 */

                R3410_00_FETCH_RCAP_DB_CLOSE_1();

                /*" -3431- MOVE 'S' TO WFIM-MOVIMENTO */
                _.Move("S", W.WFIM_MOVIMENTO);

                /*" -3433- GO TO R3410-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3410_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3434- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3435- DISPLAY 'R3410-00 - PROBLEMAS FETCH   (RCAP)       ' */
                _.Display($"R3410-00 - PROBLEMAS FETCH   (RCAP)       ");

                /*" -3438- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3439- IF VIND-NRTIT LESS ZEROS */

            if (VIND_NRTIT < 00)
            {

                /*" -3442- MOVE ZEROS TO RCAPS-NUM-TITULO. */
                _.Move(0, RCAPS.DCLRCAPS.RCAPS_NUM_TITULO);
            }


            /*" -3443- IF VIND-CODPRODU LESS ZEROS */

            if (VIND_CODPRODU < 00)
            {

                /*" -3446- MOVE ZEROS TO RCAPS-CODIGO-PRODUTO. */
                _.Move(0, RCAPS.DCLRCAPS.RCAPS_CODIGO_PRODUTO);
            }


            /*" -3447- IF VIND-AGECOBR LESS ZEROS */

            if (VIND_AGECOBR < 00)
            {

                /*" -3450- MOVE ZEROS TO RCAPS-AGE-COBRANCA. */
                _.Move(0, RCAPS.DCLRCAPS.RCAPS_AGE_COBRANCA);
            }


            /*" -3451- IF VIND-NRCERTIF LESS ZEROS */

            if (VIND_NRCERTIF < 00)
            {

                /*" -3455- MOVE ZEROS TO RCAPS-NUM-CERTIFICADO. */
                _.Move(0, RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO);
            }


            /*" -3455- ADD 1 TO LD-RCAP. */
            W.LD_RCAP.Value = W.LD_RCAP + 1;

        }

        [StopWatch]
        /*" R3410-00-FETCH-RCAP-DB-FETCH-1 */
        public void R3410_00_FETCH_RCAP_DB_FETCH_1()
        {
            /*" -3425- EXEC SQL FETCH V0RCAP1 INTO :RCAPCOMP-NUM-RCAP , :RCAPCOMP-NUM-RCAP-COMPLEMEN , :RCAPCOMP-DATA-MOVIMENTO , :RCAPCOMP-BCO-AVISO , :RCAPCOMP-AGE-AVISO , :RCAPCOMP-NUM-AVISO-CREDITO , :RCAPCOMP-VAL-RCAP , :RCAPCOMP-DATA-RCAP , :RCAPS-NUM-TITULO:VIND-NRTIT , :RCAPS-CODIGO-PRODUTO:VIND-CODPRODU , :RCAPS-AGE-COBRANCA:VIND-AGECOBR , :RCAPS-NUM-CERTIFICADO:VIND-NRCERTIF END-EXEC. */

            if (V0RCAP1.Fetch())
            {
                _.Move(V0RCAP1.RCAPCOMP_NUM_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP);
                _.Move(V0RCAP1.RCAPCOMP_NUM_RCAP_COMPLEMEN, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP_COMPLEMEN);
                _.Move(V0RCAP1.RCAPCOMP_DATA_MOVIMENTO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_MOVIMENTO);
                _.Move(V0RCAP1.RCAPCOMP_BCO_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO);
                _.Move(V0RCAP1.RCAPCOMP_AGE_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO);
                _.Move(V0RCAP1.RCAPCOMP_NUM_AVISO_CREDITO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO);
                _.Move(V0RCAP1.RCAPCOMP_VAL_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP);
                _.Move(V0RCAP1.RCAPCOMP_DATA_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP);
                _.Move(V0RCAP1.RCAPS_NUM_TITULO, RCAPS.DCLRCAPS.RCAPS_NUM_TITULO);
                _.Move(V0RCAP1.VIND_NRTIT, VIND_NRTIT);
                _.Move(V0RCAP1.RCAPS_CODIGO_PRODUTO, RCAPS.DCLRCAPS.RCAPS_CODIGO_PRODUTO);
                _.Move(V0RCAP1.VIND_CODPRODU, VIND_CODPRODU);
                _.Move(V0RCAP1.RCAPS_AGE_COBRANCA, RCAPS.DCLRCAPS.RCAPS_AGE_COBRANCA);
                _.Move(V0RCAP1.VIND_AGECOBR, VIND_AGECOBR);
                _.Move(V0RCAP1.RCAPS_NUM_CERTIFICADO, RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO);
                _.Move(V0RCAP1.VIND_NRCERTIF, VIND_NRCERTIF);
            }

        }

        [StopWatch]
        /*" R3410-00-FETCH-RCAP-DB-CLOSE-1 */
        public void R3410_00_FETCH_RCAP_DB_CLOSE_1()
        {
            /*" -3429- EXEC SQL CLOSE V0RCAP1 END-EXEC */

            V0RCAP1.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3410_99_SAIDA*/

        [StopWatch]
        /*" R3450-00-PROCESSA-RCAP-SECTION */
        private void R3450_00_PROCESSA_RCAP_SECTION()
        {
            /*" -3468- MOVE '3450' TO WNR-EXEC-SQL. */
            _.Move("3450", W.WABEND.WNR_EXEC_SQL);

            /*" -3470- MOVE 'R.C.A.P.  ' TO LD03-BASE. */
            _.Move("R.C.A.P.  ", W.LD03.LD03_BASE);

            /*" -3472- MOVE RCAPCOMP-BCO-AVISO TO LD03-BCOAVISO. */
            _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO, W.LD03.LD03_BCOAVISO);

            /*" -3474- MOVE RCAPCOMP-AGE-AVISO TO LD03-AGEAVISO. */
            _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO, W.LD03.LD03_AGEAVISO);

            /*" -3477- MOVE RCAPCOMP-NUM-AVISO-CREDITO TO LD03-NRAVISO. */
            _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO, W.LD03.LD03_NRAVISO);

            /*" -3479- MOVE RCAPCOMP-DATA-MOVIMENTO TO WDATA-REL. */
            _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_MOVIMENTO, W.WDATA_REL);

            /*" -3480- MOVE WDAT-REL-DIA TO WDATA-DD-CABEC */
            _.Move(W.FILLER_0.WDAT_REL_DIA, W.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -3481- MOVE WDAT-REL-MES TO WDATA-MM-CABEC */
            _.Move(W.FILLER_0.WDAT_REL_MES, W.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -3482- MOVE WDAT-REL-ANO TO WDATA-AA-CABEC */
            _.Move(W.FILLER_0.WDAT_REL_ANO, W.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -3484- MOVE WDATA-CABEC TO LD03-DTMOVTO. */
            _.Move(W.WDATA_CABEC, W.LD03.LD03_DTMOVTO);

            /*" -3486- MOVE RCAPCOMP-DATA-RCAP TO WDATA-REL. */
            _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP, W.WDATA_REL);

            /*" -3487- MOVE WDAT-REL-DIA TO WDATA-DD-CABEC */
            _.Move(W.FILLER_0.WDAT_REL_DIA, W.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -3488- MOVE WDAT-REL-MES TO WDATA-MM-CABEC */
            _.Move(W.FILLER_0.WDAT_REL_MES, W.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -3489- MOVE WDAT-REL-ANO TO WDATA-AA-CABEC */
            _.Move(W.FILLER_0.WDAT_REL_ANO, W.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -3491- MOVE WDATA-CABEC TO LD03-DTQITBCO. */
            _.Move(W.WDATA_CABEC, W.LD03.LD03_DTQITBCO);

            /*" -3493- MOVE RCAPCOMP-VAL-RCAP TO LD03-VLPREMIO. */
            _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP, W.LD03.LD03_VLPREMIO);

            /*" -3495- MOVE RCAPS-NUM-CERTIFICADO TO LD03-PROPOSTA. */
            _.Move(RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO, W.LD03.LD03_PROPOSTA);

            /*" -3497- MOVE RCAPS-NUM-TITULO TO LD03-TITULO. */
            _.Move(RCAPS.DCLRCAPS.RCAPS_NUM_TITULO, W.LD03.LD03_TITULO);

            /*" -3499- MOVE RCAPCOMP-NUM-RCAP-COMPLEMEN TO LD03-NRRCAPCO. */
            _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP_COMPLEMEN, W.LD03.LD03_NRRCAPCO);

            /*" -3501- MOVE ZEROS TO LD03-APOLICE. */
            _.Move(0, W.LD03.LD03_APOLICE);

            /*" -3503- MOVE ZEROS TO LD03-ENDOSSO. */
            _.Move(0, W.LD03.LD03_ENDOSSO);

            /*" -3505- MOVE ZEROS TO LD03-PARCELA. */
            _.Move(0, W.LD03.LD03_PARCELA);

            /*" -3507- MOVE RCAPS-CODIGO-PRODUTO TO LD03-PRODUTO. */
            _.Move(RCAPS.DCLRCAPS.RCAPS_CODIGO_PRODUTO, W.LD03.LD03_PRODUTO);

            /*" -3511- MOVE RCAPS-AGE-COBRANCA TO LD03-AGENCIA. */
            _.Move(RCAPS.DCLRCAPS.RCAPS_AGE_COBRANCA, W.LD03.LD03_AGENCIA);

            /*" -3513- MOVE RCAPCOMP-DATA-RCAP TO WDATA-REL. */
            _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP, W.WDATA_REL);

            /*" -3514- MOVE WDAT-REL-DIA TO LPARM02-DD */
            _.Move(W.FILLER_0.WDAT_REL_DIA, LPARM.LPARM02.LPARM02_DD);

            /*" -3515- MOVE WDAT-REL-MES TO LPARM02-MM */
            _.Move(W.FILLER_0.WDAT_REL_MES, LPARM.LPARM02.LPARM02_MM);

            /*" -3517- MOVE WDAT-REL-ANO TO LPARM02-AA. */
            _.Move(W.FILLER_0.WDAT_REL_ANO, LPARM.LPARM02.LPARM02_AA);

            /*" -3519- PERFORM R3160-00-CALCULA-DIAS. */

            R3160_00_CALCULA_DIAS_SECTION();

            /*" -3522- MOVE LPARM03 TO LD03-QTDIAS. */
            _.Move(LPARM.LPARM03, W.LD03.LD03_QTDIAS);

            /*" -3523- WRITE REG-CB0155B3 FROM LD03. */
            _.Move(W.LD03.GetMoveValues(), REG_CB0155B3);

            CB0155B3.Write(REG_CB0155B3.GetMoveValues().ToString());

            /*" -3523- ADD 1 TO GV-ARQSAI3. */
            W.GV_ARQSAI3.Value = W.GV_ARQSAI3 + 1;

            /*" -0- FLUXCONTROL_PERFORM R3450_90_LEITURA */

            R3450_90_LEITURA();

        }

        [StopWatch]
        /*" R3450-90-LEITURA */
        private void R3450_90_LEITURA(bool isPerform = false)
        {
            /*" -3528- PERFORM R3410-00-FETCH-RCAP. */

            R3410_00_FETCH_RCAP_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3450_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -3538- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, W.WABEND.WSQLCODE);

            /*" -3539- MOVE SQLERRD(1) TO WSQLERRD1 */
            _.Move(DB.SQLERRD[1], W.WABEND.WSQLERRD1);

            /*" -3540- MOVE SQLERRD(2) TO WSQLERRD2 */
            _.Move(DB.SQLERRD[2], W.WABEND.WSQLERRD2);

            /*" -3542- DISPLAY WABEND. */
            _.Display(W.WABEND);

            /*" -3542- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -3548- CLOSE CB0155B1 CB0155B2 CB0155B3. */
            CB0155B1.Close();
            CB0155B2.Close();
            CB0155B3.Close();

            /*" -3551- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -3551- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}