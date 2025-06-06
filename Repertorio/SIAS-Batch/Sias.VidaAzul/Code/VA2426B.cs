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
using Sias.VidaAzul.DB2.VA2426B;

namespace Code
{
    public class VA2426B
    {
        public bool IsCall { get; set; }

        public VA2426B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                    OBJETIVO DO PROGRAMA                        *      */
        /*"      ******************************************************************      */
        /*"      *   EMISSAO DO DEMONSTRATIVO DE FATURA DE TODAS AS APOLICES EXIS_*      */
        /*"      * TENTES NA ESTRUTURA DO PRODUTO VIDAZUL MULTIPREMIADO           *      */
        /*"      * PARA AS APOLICE PREFERENCIAL VIDA                              *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO   *    DATA    *    AUTOR     *       HISTORICO       *      */
        /*"      *            *            *              *                       *      */
        /*"      *     01     *  23/11/98  *   MESSIAS    *                       *      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        public FileBasis _RVA2426B { get; set; } = new FileBasis(new PIC("X", "132", "X(132)"));

        public FileBasis RVA2426B
        {
            get
            {
                _.Move(REG_RVA2426B, _RVA2426B); VarBasis.RedefinePassValue(REG_RVA2426B, _RVA2426B, REG_RVA2426B); return _RVA2426B;
            }
        }
        public SortBasis<VA2426B_REG_SORT> SVA2426B { get; set; } = new SortBasis<VA2426B_REG_SORT>(new VA2426B_REG_SORT());
        /*"01                REG-RVA2426B     PIC  X(132).*/
        public StringBasis REG_RVA2426B { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");
        /*"01                REG-SORT.*/
        public VA2426B_REG_SORT REG_SORT { get; set; } = new VA2426B_REG_SORT();
        public class VA2426B_REG_SORT : VarBasis
        {
            /*"    05            SOR-APOLICE      PIC  9(015).*/
            public IntBasis SOR_APOLICE { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05            SOR-CODSUBES     PIC  9(004).*/
            public IntBasis SOR_CODSUBES { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05            SOR-NOMPRODU     PIC  X(030).*/
            public StringBasis SOR_NOMPRODU { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
            /*"    05            SOR-PARCELA      PIC  9(004).*/
            public IntBasis SOR_PARCELA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05            SOR-CODOPER      PIC  9(004).*/
            public IntBasis SOR_CODOPER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05            SOR-TIPOREG      PIC  9(001).*/
            public IntBasis SOR_TIPOREG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05            SOR-DTMOVTO      PIC  X(010).*/
            public StringBasis SOR_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05            SOR-PREMIO       PIC  9(009)V99.*/
            public DoubleBasis SOR_PREMIO { get; set; } = new DoubleBasis(new PIC("9", "9", "9(009)V99."), 2);
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis SORT_RETURN { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis SORT_FILE_SIZE { get; set; } = new IntBasis(new PIC("S9", "08", "S9(08)"));
        /*"77                V1SIST-DTMOVABE  PIC  X(10).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77                V1EMPR-NOM-EMP   PIC  X(40).*/
        public StringBasis V1EMPR_NOM_EMP { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77                V0RELA-DTREFER   PIC  X(10).*/
        public StringBasis V0RELA_DTREFER { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77                V0RELA-DTMAXIM   PIC  X(10).*/
        public StringBasis V0RELA_DTMAXIM { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77                V0PROD-NOMPRODU  PIC  X(30).*/
        public StringBasis V0PROD_NOMPRODU { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"77                V0HCON-APOLICE   PIC S9(15)    COMP-3.*/
        public IntBasis V0HCON_APOLICE { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77                V0HCON-CODSUBES  PIC S9(04)    COMP.*/
        public IntBasis V0HCON_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77                V0HCON-NRPARCEL  PIC S9(04)    COMP.*/
        public IntBasis V0HCON_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77                V0HCON-CODOPER   PIC S9(04)    COMP.*/
        public IntBasis V0HCON_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77                V0HCON-DTMOVTO   PIC  X(10).*/
        public StringBasis V0HCON_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77                V0HCON-PRMTOTAL  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0HCON_PRMTOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01                WORK-AREA.*/
        public VA2426B_WORK_AREA WORK_AREA { get; set; } = new VA2426B_WORK_AREA();
        public class VA2426B_WORK_AREA : VarBasis
        {
            /*"    05            WDATA-REL        PIC  X(010)    VALUE SPACES.*/
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    05            FILLER           REDEFINES      WDATA-REL.*/
            private _REDEF_VA2426B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_VA2426B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_VA2426B_FILLER_0(); _.Move(WDATA_REL, _filler_0); VarBasis.RedefinePassValue(WDATA_REL, _filler_0, WDATA_REL); _filler_0.ValueChanged += () => { _.Move(_filler_0, WDATA_REL); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WDATA_REL); }
            }  //Redefines
            public class _REDEF_VA2426B_FILLER_0 : VarBasis
            {
                /*"      10          WDAT-REL-ANO     PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10          FILLER           PIC  X(001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10          WDAT-REL-MES     PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10          FILLER           PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10          WDAT-REL-DIA     PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05            WDAT-REL-LIT.*/

                public _REDEF_VA2426B_FILLER_0()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public VA2426B_WDAT_REL_LIT WDAT_REL_LIT { get; set; } = new VA2426B_WDAT_REL_LIT();
            public class VA2426B_WDAT_REL_LIT : VarBasis
            {
                /*"      10          WDAT-LIT-DIA     PIC  9(002).*/
                public IntBasis WDAT_LIT_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10          FILLER           PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10          WDAT-LIT-MES     PIC  9(002).*/
                public IntBasis WDAT_LIT_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10          FILLER           PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10          WDAT-LIT-ANO     PIC  9(004).*/
                public IntBasis WDAT_LIT_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05            WREFE-DATA-INI   PIC  X(010)    VALUE SPACES.*/
            }
            public StringBasis WREFE_DATA_INI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    05            FILLER           REDEFINES      WREFE-DATA-INI*/
            private _REDEF_VA2426B_FILLER_5 _filler_5 { get; set; }
            public _REDEF_VA2426B_FILLER_5 FILLER_5
            {
                get { _filler_5 = new _REDEF_VA2426B_FILLER_5(); _.Move(WREFE_DATA_INI, _filler_5); VarBasis.RedefinePassValue(WREFE_DATA_INI, _filler_5, WREFE_DATA_INI); _filler_5.ValueChanged += () => { _.Move(_filler_5, WREFE_DATA_INI); }; return _filler_5; }
                set { VarBasis.RedefinePassValue(value, _filler_5, WREFE_DATA_INI); }
            }  //Redefines
            public class _REDEF_VA2426B_FILLER_5 : VarBasis
            {
                /*"      10          WREFE-ANO-INI    PIC  9(004).*/
                public IntBasis WREFE_ANO_INI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10          WREFE-BR1-INI    PIC  X(001).*/
                public StringBasis WREFE_BR1_INI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10          WREFE-MES-INI    PIC  9(002).*/
                public IntBasis WREFE_MES_INI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10          WREFE-BR2-INI    PIC  X(001).*/
                public StringBasis WREFE_BR2_INI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10          WREFE-DIA-INI    PIC  9(002).*/
                public IntBasis WREFE_DIA_INI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05            WREFE-DATA-TER   PIC  X(010)    VALUE SPACES.*/

                public _REDEF_VA2426B_FILLER_5()
                {
                    WREFE_ANO_INI.ValueChanged += OnValueChanged;
                    WREFE_BR1_INI.ValueChanged += OnValueChanged;
                    WREFE_MES_INI.ValueChanged += OnValueChanged;
                    WREFE_BR2_INI.ValueChanged += OnValueChanged;
                    WREFE_DIA_INI.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WREFE_DATA_TER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    05            FILLER           REDEFINES      WREFE-DATA-TER*/
            private _REDEF_VA2426B_FILLER_6 _filler_6 { get; set; }
            public _REDEF_VA2426B_FILLER_6 FILLER_6
            {
                get { _filler_6 = new _REDEF_VA2426B_FILLER_6(); _.Move(WREFE_DATA_TER, _filler_6); VarBasis.RedefinePassValue(WREFE_DATA_TER, _filler_6, WREFE_DATA_TER); _filler_6.ValueChanged += () => { _.Move(_filler_6, WREFE_DATA_TER); }; return _filler_6; }
                set { VarBasis.RedefinePassValue(value, _filler_6, WREFE_DATA_TER); }
            }  //Redefines
            public class _REDEF_VA2426B_FILLER_6 : VarBasis
            {
                /*"      10          WREFE-ANO-TER    PIC  9(004).*/
                public IntBasis WREFE_ANO_TER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10          WREFE-BR1-TER    PIC  X(001).*/
                public StringBasis WREFE_BR1_TER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10          WREFE-MES-TER    PIC  9(002).*/
                public IntBasis WREFE_MES_TER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10          WREFE-BR2-TER    PIC  X(001).*/
                public StringBasis WREFE_BR2_TER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10          WREFE-DIA-TER    PIC  9(002).*/
                public IntBasis WREFE_DIA_TER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05            WHORA-CURR.*/

                public _REDEF_VA2426B_FILLER_6()
                {
                    WREFE_ANO_TER.ValueChanged += OnValueChanged;
                    WREFE_BR1_TER.ValueChanged += OnValueChanged;
                    WREFE_MES_TER.ValueChanged += OnValueChanged;
                    WREFE_BR2_TER.ValueChanged += OnValueChanged;
                    WREFE_DIA_TER.ValueChanged += OnValueChanged;
                }

            }
            public VA2426B_WHORA_CURR WHORA_CURR { get; set; } = new VA2426B_WHORA_CURR();
            public class VA2426B_WHORA_CURR : VarBasis
            {
                /*"      10          WHORA-HH-CURR    PIC  9(002).*/
                public IntBasis WHORA_HH_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10          WHORA-MM-CURR    PIC  9(002).*/
                public IntBasis WHORA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10          WHORA-SS-CURR    PIC  9(002).*/
                public IntBasis WHORA_SS_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10          WHORA-CC-CURR    PIC  9(002).*/
                public IntBasis WHORA_CC_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05            WHORA-CABEC.*/
            }
            public VA2426B_WHORA_CABEC WHORA_CABEC { get; set; } = new VA2426B_WHORA_CABEC();
            public class VA2426B_WHORA_CABEC : VarBasis
            {
                /*"      10          WHORA-HH-CABEC   PIC  9(002).*/
                public IntBasis WHORA_HH_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10          FILLER           PIC  X(001)    VALUE '.'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"      10          WHORA-MM-CABEC   PIC  9(002).*/
                public IntBasis WHORA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10          FILLER           PIC  X(001)    VALUE '.'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"      10          WHORA-SS-CABEC   PIC  9(002).*/
                public IntBasis WHORA_SS_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05            DATA-MAQ.*/
            }
            public VA2426B_DATA_MAQ DATA_MAQ { get; set; } = new VA2426B_DATA_MAQ();
            public class VA2426B_DATA_MAQ : VarBasis
            {
                /*"      10          MES              PIC  9(002).*/
                public IntBasis MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10          FILLER           PIC  X(001).*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10          DIA              PIC  9(002).*/
                public IntBasis DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10          FILLER           PIC  X(001).*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10          ANO              PIC  9(004).*/
                public IntBasis ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05            WNUM-FATURA.*/
            }
            public VA2426B_WNUM_FATURA WNUM_FATURA { get; set; } = new VA2426B_WNUM_FATURA();
            public class VA2426B_WNUM_FATURA : VarBasis
            {
                /*"      10          WANO-FATURA      PIC  9(004).*/
                public IntBasis WANO_FATURA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10          WMES-FATURA      PIC  9(002).*/
                public IntBasis WMES_FATURA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05            WFIM-HCONTABILVA PIC  X(001)    VALUE SPACE.*/
            }
            public StringBasis WFIM_HCONTABILVA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05            WFIM-SISTEMA     PIC  X(001)    VALUE SPACE.*/
            public StringBasis WFIM_SISTEMA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05            WFIM-RELATORIO   PIC  X(001)    VALUE SPACE.*/
            public StringBasis WFIM_RELATORIO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05            WFIM-SORT        PIC  X(001)    VALUE SPACE.*/
            public StringBasis WFIM_SORT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05            AC-LIDOS         PIC  9(006)    VALUE ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-LINHAS        PIC  9(006)    VALUE 90.*/
            public IntBasis AC_LINHAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"), 90);
            /*"    05            AC-PAGINA        PIC  9(006)    VALUE ZEROS.*/
            public IntBasis AC_PAGINA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-IMPRESSOS     PIC  9(006)    VALUE ZEROS.*/
            public IntBasis AC_IMPRESSOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-PREMIO        PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis AC_PREMIO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05            WS-PREMIO        PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis WS_PREMIO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05            WS-VLOPER-OPER   PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis WS_VLOPER_OPER { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05            WS-VLOPER-TOT    PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis WS_VLOPER_TOT { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05            PRODUTO-ANT      PIC  X(040)    VALUE SPACES.*/
            public StringBasis PRODUTO_ANT { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"    05            TIPOREG-ANT      PIC  9(001)    VALUE ZEROES.*/
            public IntBasis TIPOREG_ANT { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05            DATA-ANT         PIC  X(010)    VALUE SPACES.*/
            public StringBasis DATA_ANT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    05            LC00.*/
            public VA2426B_LC00 LC00 { get; set; } = new VA2426B_LC00();
            public class VA2426B_LC00 : VarBasis
            {
                /*"      10          FILLER           PIC  X(132)    VALUE SPACES.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
                /*"    05            LC01.*/
            }
            public VA2426B_LC01 LC01 { get; set; } = new VA2426B_LC01();
            public class VA2426B_LC01 : VarBasis
            {
                /*"      10          FILLER           PIC  X(132)    VALUE ALL '-'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
                /*"    05            LC02.*/
            }
            public VA2426B_LC02 LC02 { get; set; } = new VA2426B_LC02();
            public class VA2426B_LC02 : VarBasis
            {
                /*"      10          FILLER           PIC  X(001)    VALUE '*'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                /*"      10          FILLER           PIC  X(130)    VALUE SPACES.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "130", "X(130)"), @"");
                /*"      10          FILLER           PIC  X(001)    VALUE '*'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                /*"    05            LC03.*/
            }
            public VA2426B_LC03 LC03 { get; set; } = new VA2426B_LC03();
            public class VA2426B_LC03 : VarBasis
            {
                /*"      10          FILLER           PIC  X(044)    VALUE                                                 '* VA2426B'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "44", "X(044)"), @"* VA2426B");
                /*"      10          LC03-EMPRESA     PIC  X(040)    VALUE SPACES.*/
                public StringBasis LC03_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"      10          FILLER           PIC  X(031)    VALUE SPACES.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "31", "X(031)"), @"");
                /*"      10          FILLER           PIC  X(007)    VALUE 'PAGINA'*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"PAGINA");
                /*"      10          LC03-PAGINA      PIC  ZZZZ.ZZ9.*/
                public IntBasis LC03_PAGINA { get; set; } = new IntBasis(new PIC("9", "7", "ZZZZ.ZZ9."));
                /*"      10          FILLER           PIC  X(002)    VALUE ' *'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" *");
                /*"    05            LC04.*/
            }
            public VA2426B_LC04 LC04 { get; set; } = new VA2426B_LC04();
            public class VA2426B_LC04 : VarBasis
            {
                /*"      10          FILLER           PIC  X(115)    VALUE '*'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "115", "X(115)"), @"*");
                /*"      10          FILLER           PIC  X(005)    VALUE 'DATA'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"DATA");
                /*"      10          LC04-DATA        PIC  X(010)    VALUE SPACES.*/
                public StringBasis LC04_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"      10          FILLER           PIC  X(002)    VALUE ' *'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" *");
                /*"    05            LC05.*/
            }
            public VA2426B_LC05 LC05 { get; set; } = new VA2426B_LC05();
            public class VA2426B_LC05 : VarBasis
            {
                /*"      10          FILLER           PIC  X(001)    VALUE '*'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                /*"      10          FILLER           PIC  X(037)    VALUE SPACES.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"");
                /*"      10          FILLER           PIC  X(048)    VALUE            'SISTEMA DE VIDA EM GRUPO E/OU ACIDENTES PESSOAIS'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"SISTEMA DE VIDA EM GRUPO E/OU ACIDENTES PESSOAIS");
                /*"      10          FILLER           PIC  X(009)    VALUE                ' COLETIVO'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" COLETIVO");
                /*"      10          FILLER           PIC  X(020)    VALUE SPACES.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"      10          FILLER           PIC  X(007)    VALUE 'HORA '.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"HORA ");
                /*"      10          CAB3-HORA        PIC  99.99.99.*/
                public IntBasis CAB3_HORA { get; set; } = new IntBasis(new PIC("9", "6", "99.99.99."));
                /*"      10          FILLER           PIC  X(002)    VALUE ' *'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" *");
                /*"    05            LC06.*/
            }
            public VA2426B_LC06 LC06 { get; set; } = new VA2426B_LC06();
            public class VA2426B_LC06 : VarBasis
            {
                /*"      10          FILLER           PIC  X(001)    VALUE '*'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                /*"      10          FILLER           PIC  X(032)    VALUE SPACES.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "32", "X(032)"), @"");
                /*"      10          FILLER           PIC  X(038)    VALUE                 'DEMONSTRATIVO FINANCEIRO DA FATURA DO'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "38", "X(038)"), @"DEMONSTRATIVO FINANCEIRO DA FATURA DO");
                /*"      10          LC06-TIPO        PIC  X(040)    VALUE SPACES.*/
                public StringBasis LC06_TIPO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"      10          FILLER           PIC  X(020)    VALUE SPACES.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"      10          FILLER           PIC  X(001)    VALUE '*'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                /*"    05            LC07.*/
            }
            public VA2426B_LC07 LC07 { get; set; } = new VA2426B_LC07();
            public class VA2426B_LC07 : VarBasis
            {
                /*"      10          FILLER           PIC  X(001)    VALUE '*'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                /*"      10          FILLER           PIC  X(042)    VALUE SPACES.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "42", "X(042)"), @"");
                /*"      10          FILLER           PIC  X(009)    VALUE                 'FATURA - '.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"FATURA - ");
                /*"      10          LC07-FATURA      PIC  9(006)    VALUE ZEROES.*/
                public IntBasis LC07_FATURA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
                /*"      10          FILLER           PIC  X(014)    VALUE                 '  -  VIGENCIA '.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"  -  VIGENCIA ");
                /*"      10          LC07-DIA-INI     PIC  9(002)    VALUE ZEROES.*/
                public IntBasis LC07_DIA_INI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"      10          FILLER           PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10          LC07-MES-INI     PIC  9(002)    VALUE ZEROES.*/
                public IntBasis LC07_MES_INI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"      10          FILLER           PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10          LC07-ANO-INI     PIC  9(004)    VALUE ZEROES.*/
                public IntBasis LC07_ANO_INI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"      10          FILLER           PIC  X(003)    VALUE ' A '.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" A ");
                /*"      10          LC07-DIA-TER     PIC  9(002)    VALUE ZEROES.*/
                public IntBasis LC07_DIA_TER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"      10          FILLER           PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10          LC07-MES-TER     PIC  9(002)    VALUE ZEROES.*/
                public IntBasis LC07_MES_TER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"      10          FILLER           PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10          LC07-ANO-TER     PIC  9(004)    VALUE ZEROES.*/
                public IntBasis LC07_ANO_TER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"      10          FILLER           PIC  X(036)    VALUE SPACES.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"");
                /*"      10          FILLER           PIC  X(001)    VALUE '*'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                /*"    05            LC08.*/
            }
            public VA2426B_LC08 LC08 { get; set; } = new VA2426B_LC08();
            public class VA2426B_LC08 : VarBasis
            {
                /*"      10          FILLER           PIC  X(001)    VALUE '*'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                /*"      10          FILLER           PIC  X(032)    VALUE SPACES.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "32", "X(032)"), @"");
                /*"      10          FILLER           PIC  X(017)    VALUE                 'DATA-MOVIMENTACAO'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"DATA-MOVIMENTACAO");
                /*"      10          FILLER           PIC  X(032)    VALUE SPACES.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "32", "X(032)"), @"");
                /*"      10          FILLER           PIC  X(034)    VALUE                 'VALOR DA OPERACAO'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"VALOR DA OPERACAO");
                /*"    05            LC09.*/
            }
            public VA2426B_LC09 LC09 { get; set; } = new VA2426B_LC09();
            public class VA2426B_LC09 : VarBasis
            {
                /*"      10          FILLER           PIC  X(003)    VALUE SPACES.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"      10          LC09-OPERACAO    PIC  X(019)    VALUE SPACES.*/
                public StringBasis LC09_OPERACAO { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"");
                /*"    05            DET-1.*/
            }
            public VA2426B_DET_1 DET_1 { get; set; } = new VA2426B_DET_1();
            public class VA2426B_DET_1 : VarBasis
            {
                /*"      10          FILLER           PIC  X(035)    VALUE SPACES.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"");
                /*"      10          DET1-DIA-MOV     PIC  9(002)    VALUE ZEROES.*/
                public IntBasis DET1_DIA_MOV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"      10          FILLER           PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10          DET1-MES-MOV     PIC  9(002)    VALUE ZEROES.*/
                public IntBasis DET1_MES_MOV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"      10          FILLER           PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10          DET1-ANO-MOV     PIC  9(004)    VALUE ZEROES.*/
                public IntBasis DET1_ANO_MOV { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"      10          FILLER           PIC  X(036)    VALUE SPACES.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"");
                /*"      10          DET1-VALOR       PIC  ZZ.ZZZ.ZZZ.ZZ9,99-.*/
                public DoubleBasis DET1_VALOR { get; set; } = new DoubleBasis(new PIC("9", "11", "ZZ.ZZZ.ZZZ.ZZ9V99-."), 3);
                /*"    05            TOT-CAB-1.*/
            }
            public VA2426B_TOT_CAB_1 TOT_CAB_1 { get; set; } = new VA2426B_TOT_CAB_1();
            public class VA2426B_TOT_CAB_1 : VarBasis
            {
                /*"      10          FILLER           PIC  X(032)    VALUE SPACES.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "32", "X(032)"), @"");
                /*"      10          FILLER           PIC  X(006)    VALUE 'TOTAL '*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"TOTAL ");
                /*"      10          CAB-1-TIPO       PIC  X(008)    VALUE SPACES.*/
                public StringBasis CAB_1_TIPO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"      10          FILLER           PIC  X(033)    VALUE SPACES.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "33", "X(033)"), @"");
                /*"      10          CAB-1-TOTAL      PIC  ZZ.ZZZ.ZZZ.ZZ9,99-.*/
                public DoubleBasis CAB_1_TOTAL { get; set; } = new DoubleBasis(new PIC("9", "11", "ZZ.ZZZ.ZZZ.ZZ9V99-."), 3);
                /*"    05            LK-LINK.*/
            }
            public VA2426B_LK_LINK LK_LINK { get; set; } = new VA2426B_LK_LINK();
            public class VA2426B_LK_LINK : VarBasis
            {
                /*"      10          LK-RTCODE        PIC S9(004)    VALUE +0 COMP.*/
                public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"      10          LK-TAMANHO       PIC S9(004)    VALUE +40 COMP*/
                public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
                /*"      10          LK-TITULO        PIC  X(132)    VALUE SPACES.*/
                public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
                /*"    05            WABEND.*/
            }
            public VA2426B_WABEND WABEND { get; set; } = new VA2426B_WABEND();
            public class VA2426B_WABEND : VarBasis
            {
                /*"      10          FILLER           PIC  X(010)    VALUE                 ' VA2426B'.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VA2426B");
                /*"      10          FILLER           PIC  X(026)    VALUE                 ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"      10          WNR-EXEC-SQL     PIC  X(004)    VALUE '0000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                /*"      10          FILLER           PIC  X(013)    VALUE                 ' *** SQLCODE '.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"      10          WSQLCODE         PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            }
        }


        public VA2426B_CHCONT CHCONT { get; set; } = new VA2426B_CHCONT();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string RVA2426B_FILE_NAME_P, string SVA2426B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                RVA2426B.SetFile(RVA2426B_FILE_NAME_P);
                SVA2426B.SetFile(SVA2426B_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM M-0000-PRINCIPAL */

                M_0000_PRINCIPAL();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" M-0000-PRINCIPAL */
        private void M_0000_PRINCIPAL(bool isPerform = false)
        {
            /*" -338- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -341- EXEC SQL WHENEVER SQLERROR GO TO R9999-00-ROT-ERRO END-EXEC. */

            /*" -344- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -348- MOVE +500000 TO SORT-FILE-SIZE. */
            _.Move(+500000, SORT_FILE_SIZE);

            /*" -353- SORT SVA2426B ON ASCENDING KEY SOR-NOMPRODU SOR-TIPOREG SOR-DTMOVTO INPUT PROCEDURE R0010-00-INPUT THRU R0010-99-SAIDA OUTPUT PROCEDURE R0020-00-OUTPUT THRU R0020-99-SAIDA. */
            SORT_RETURN.Value = SVA2426B.Sort("SOR-NOMPRODU,SOR-TIPOREG,SOR-DTMOVTO", () => R0010_00_INPUT_SECTION(), () => R0020_00_OUTPUT_SECTION());

            /*" -356- IF SORT-RETURN NOT EQUAL ZEROS */

            if (SORT_RETURN != 00)
            {

                /*" -357- DISPLAY 'PROBLEMAS NO SORT ' SORT-RETURN */
                _.Display($"PROBLEMAS NO SORT {SORT_RETURN}");

                /*" -357- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -363- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -363- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -366- DISPLAY '*** VA2426B - ' */
            _.Display($"*** VA2426B - ");

            /*" -367- DISPLAY 'LIDOS V0HISTCONTABILVA   ' AC-LIDOS. */
            _.Display($"LIDOS V0HISTCONTABILVA   {WORK_AREA.AC_LIDOS}");

            /*" -369- DISPLAY '*** VA2426B - TERMINO NORMAL ***' */
            _.Display($"*** VA2426B - TERMINO NORMAL ***");

            /*" -369- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0010-00-INPUT-SECTION */
        private void R0010_00_INPUT_SECTION()
        {
            /*" -382- MOVE '0010' TO WNR-EXEC-SQL. */
            _.Move("0010", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -384- PERFORM R8000-00-ABRE-ARQUIVOS. */

            R8000_00_ABRE_ARQUIVOS_SECTION();

            /*" -386- PERFORM R0100-00-SELECT-V1SISTEMA. */

            R0100_00_SELECT_V1SISTEMA_SECTION();

            /*" -387- IF WFIM-SISTEMA NOT EQUAL SPACES */

            if (!WORK_AREA.WFIM_SISTEMA.IsEmpty())
            {

                /*" -388- MOVE 9 TO RETURN-CODE */
                _.Move(9, RETURN_CODE);

                /*" -390- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -392- PERFORM R0150-00-MONTA-EMPRESA. */

            R0150_00_MONTA_EMPRESA_SECTION();

            /*" -394- PERFORM R0200-00-SELECT-V0RELATORIOS. */

            R0200_00_SELECT_V0RELATORIOS_SECTION();

            /*" -395- IF WFIM-RELATORIO NOT EQUAL SPACES */

            if (!WORK_AREA.WFIM_RELATORIO.IsEmpty())
            {

                /*" -396- MOVE 9 TO RETURN-CODE */
                _.Move(9, RETURN_CODE);

                /*" -398- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -400- PERFORM R0900-00-DECLARE-V0HCONTABILVA. */

            R0900_00_DECLARE_V0HCONTABILVA_SECTION();

            /*" -402- PERFORM R0910-00-FETCH-V0HCONTABILVA. */

            R0910_00_FETCH_V0HCONTABILVA_SECTION();

            /*" -403- IF WFIM-HCONTABILVA EQUAL 'S' */

            if (WORK_AREA.WFIM_HCONTABILVA == "S")
            {

                /*" -404- DISPLAY '***********  VA2426B  *************' */
                _.Display($"***********  VA2426B  *************");

                /*" -405- DISPLAY 'NENHUM REG. SELECIONADO NA V0HISTCONTABILVA' */
                _.Display($"NENHUM REG. SELECIONADO NA V0HISTCONTABILVA");

                /*" -406- MOVE ZEROS TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -408- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -410- MOVE SPACES TO REG-SORT. */
            _.Move("", REG_SORT);

            /*" -411- PERFORM R1000-00-PROCESSA-INPUT UNTIL WFIM-HCONTABILVA EQUAL 'S' . */

            while (!(WORK_AREA.WFIM_HCONTABILVA == "S"))
            {

                R1000_00_PROCESSA_INPUT_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_99_SAIDA*/

        [StopWatch]
        /*" R0020-00-OUTPUT-SECTION */
        private void R0020_00_OUTPUT_SECTION()
        {
            /*" -424- MOVE '0020' TO WNR-EXEC-SQL. */
            _.Move("0020", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -426- PERFORM R2100-00-RETURN */

            R2100_00_RETURN_SECTION();

            /*" -427- IF SOR-TIPOREG EQUAL 1 */

            if (REG_SORT.SOR_TIPOREG == 1)
            {

                /*" -428- MOVE 'VENDAS NOVAS    (+)' TO LC09-OPERACAO */
                _.Move("VENDAS NOVAS    (+)", WORK_AREA.LC09.LC09_OPERACAO);

                /*" -429- ELSE */
            }
            else
            {


                /*" -430- IF SOR-TIPOREG EQUAL 2 */

                if (REG_SORT.SOR_TIPOREG == 2)
                {

                    /*" -431- MOVE 'DEMAIS PARCELAS (+)' TO LC09-OPERACAO */
                    _.Move("DEMAIS PARCELAS (+)", WORK_AREA.LC09.LC09_OPERACAO);

                    /*" -432- ELSE */
                }
                else
                {


                    /*" -433- IF SOR-TIPOREG EQUAL 3 */

                    if (REG_SORT.SOR_TIPOREG == 3)
                    {

                        /*" -434- MOVE 'CANCELAMENTOS   (-)' TO LC09-OPERACAO */
                        _.Move("CANCELAMENTOS   (-)", WORK_AREA.LC09.LC09_OPERACAO);

                        /*" -435- ELSE */
                    }
                    else
                    {


                        /*" -436- IF SOR-TIPOREG EQUAL 4 */

                        if (REG_SORT.SOR_TIPOREG == 4)
                        {

                            /*" -438- MOVE 'RESTITUICOES    (-)' TO LC09-OPERACAO. */
                            _.Move("RESTITUICOES    (-)", WORK_AREA.LC09.LC09_OPERACAO);
                        }

                    }

                }

            }


            /*" -441- PERFORM R2000-00-PROCESSA-OUTPUT UNTIL WFIM-SORT EQUAL 'S' . */

            while (!(WORK_AREA.WFIM_SORT == "S"))
            {

                R2000_00_PROCESSA_OUTPUT_SECTION();
            }

            /*" -443- PERFORM R4000-00-UPDATE-RELATORIO. */

            R4000_00_UPDATE_RELATORIO_SECTION();

            /*" -443- PERFORM R9000-00-FECHA-ARQUIVOS. */

            R9000_00_FECHA_ARQUIVOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-SECTION */
        private void R0100_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -456- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -461- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -464- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -465- DISPLAY 'VA2426B - SISTEMA VA NAO ESTA CADASTRADO' */
                _.Display($"VA2426B - SISTEMA VA NAO ESTA CADASTRADO");

                /*" -466- MOVE 'S' TO WFIM-SISTEMA */
                _.Move("S", WORK_AREA.WFIM_SISTEMA);

                /*" -468- GO TO R0100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -470- MOVE V1SIST-DTMOVABE TO WDATA-REL */
            _.Move(V1SIST_DTMOVABE, WORK_AREA.WDATA_REL);

            /*" -471- MOVE WDAT-REL-DIA TO WDAT-LIT-DIA */
            _.Move(WORK_AREA.FILLER_0.WDAT_REL_DIA, WORK_AREA.WDAT_REL_LIT.WDAT_LIT_DIA);

            /*" -472- MOVE WDAT-REL-MES TO WDAT-LIT-MES */
            _.Move(WORK_AREA.FILLER_0.WDAT_REL_MES, WORK_AREA.WDAT_REL_LIT.WDAT_LIT_MES);

            /*" -473- MOVE WDAT-REL-ANO TO WDAT-LIT-ANO */
            _.Move(WORK_AREA.FILLER_0.WDAT_REL_ANO, WORK_AREA.WDAT_REL_LIT.WDAT_LIT_ANO);

            /*" -473- MOVE WDAT-REL-LIT TO LC04-DATA. */
            _.Move(WORK_AREA.WDAT_REL_LIT, WORK_AREA.LC04.LC04_DATA);

        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -461- EXEC SQL SELECT DTMOVABE INTO :V1SIST-DTMOVABE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VA' END-EXEC. */

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
        /*" R0150-00-MONTA-EMPRESA-SECTION */
        private void R0150_00_MONTA_EMPRESA_SECTION()
        {
            /*" -486- MOVE '0150' TO WNR-EXEC-SQL. */
            _.Move("0150", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -487- ACCEPT WHORA-CURR FROM TIME */
            _.Move(_.AcceptDate("TIME"), WORK_AREA.WHORA_CURR);

            /*" -488- MOVE WHORA-HH-CURR TO WHORA-HH-CABEC */
            _.Move(WORK_AREA.WHORA_CURR.WHORA_HH_CURR, WORK_AREA.WHORA_CABEC.WHORA_HH_CABEC);

            /*" -489- MOVE WHORA-MM-CURR TO WHORA-MM-CABEC */
            _.Move(WORK_AREA.WHORA_CURR.WHORA_MM_CURR, WORK_AREA.WHORA_CABEC.WHORA_MM_CABEC);

            /*" -490- MOVE WHORA-SS-CURR TO WHORA-SS-CABEC */
            _.Move(WORK_AREA.WHORA_CURR.WHORA_SS_CURR, WORK_AREA.WHORA_CABEC.WHORA_SS_CABEC);

            /*" -492- MOVE WHORA-CABEC TO CAB3-HORA */
            _.Move(WORK_AREA.WHORA_CABEC, WORK_AREA.LC05.CAB3_HORA);

            /*" -497- PERFORM R0150_00_MONTA_EMPRESA_DB_SELECT_1 */

            R0150_00_MONTA_EMPRESA_DB_SELECT_1();

            /*" -500- MOVE V1EMPR-NOM-EMP TO LK-TITULO */
            _.Move(V1EMPR_NOM_EMP, WORK_AREA.LK_LINK.LK_TITULO);

            /*" -502- CALL 'PROALN01' USING LK-LINK */
            _.Call("PROALN01", WORK_AREA.LK_LINK);

            /*" -503- IF LK-RTCODE EQUAL ZEROS */

            if (WORK_AREA.LK_LINK.LK_RTCODE == 00)
            {

                /*" -504- MOVE LK-TITULO TO LC03-EMPRESA */
                _.Move(WORK_AREA.LK_LINK.LK_TITULO, WORK_AREA.LC03.LC03_EMPRESA);

                /*" -505- ELSE */
            }
            else
            {


                /*" -506- DISPLAY 'VA2426B - PROBLEMA CALL V1EMPRESA' */
                _.Display($"VA2426B - PROBLEMA CALL V1EMPRESA");

                /*" -506- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


        }

        [StopWatch]
        /*" R0150-00-MONTA-EMPRESA-DB-SELECT-1 */
        public void R0150_00_MONTA_EMPRESA_DB_SELECT_1()
        {
            /*" -497- EXEC SQL SELECT NOME_EMPRESA INTO :V1EMPR-NOM-EMP FROM SEGUROS.V1EMPRESA WHERE COD_EMPRESA = 0 END-EXEC. */

            var r0150_00_MONTA_EMPRESA_DB_SELECT_1_Query1 = new R0150_00_MONTA_EMPRESA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0150_00_MONTA_EMPRESA_DB_SELECT_1_Query1.Execute(r0150_00_MONTA_EMPRESA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1EMPR_NOM_EMP, V1EMPR_NOM_EMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-SELECT-V0RELATORIOS-SECTION */
        private void R0200_00_SELECT_V0RELATORIOS_SECTION()
        {
            /*" -532- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -538- PERFORM R0200_00_SELECT_V0RELATORIOS_DB_SELECT_1 */

            R0200_00_SELECT_V0RELATORIOS_DB_SELECT_1();

            /*" -541- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -542- DISPLAY 'VA2426B - REGISTRO NAO ENCONTRADO V0RELATORIOS' */
                _.Display($"VA2426B - REGISTRO NAO ENCONTRADO V0RELATORIOS");

                /*" -543- MOVE 'S' TO WFIM-RELATORIO */
                _.Move("S", WORK_AREA.WFIM_RELATORIO);

                /*" -546- GO TO R0200-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/ //GOTO
                return;
            }


            /*" -547- MOVE V0RELA-DTREFER TO WREFE-DATA-INI */
            _.Move(V0RELA_DTREFER, WORK_AREA.WREFE_DATA_INI);

            /*" -548- MOVE 01 TO LC07-DIA-INI */
            _.Move(01, WORK_AREA.LC07.LC07_DIA_INI);

            /*" -549- MOVE WREFE-MES-INI TO LC07-MES-INI */
            _.Move(WORK_AREA.FILLER_5.WREFE_MES_INI, WORK_AREA.LC07.LC07_MES_INI);

            /*" -551- MOVE WREFE-ANO-INI TO LC07-ANO-INI. */
            _.Move(WORK_AREA.FILLER_5.WREFE_ANO_INI, WORK_AREA.LC07.LC07_ANO_INI);

            /*" -552- MOVE V0RELA-DTREFER TO WREFE-DATA-TER */
            _.Move(V0RELA_DTREFER, WORK_AREA.WREFE_DATA_TER);

            /*" -553- MOVE WREFE-DIA-TER TO LC07-DIA-TER */
            _.Move(WORK_AREA.FILLER_6.WREFE_DIA_TER, WORK_AREA.LC07.LC07_DIA_TER);

            /*" -554- MOVE WREFE-MES-TER TO LC07-MES-TER */
            _.Move(WORK_AREA.FILLER_6.WREFE_MES_TER, WORK_AREA.LC07.LC07_MES_TER);

            /*" -556- MOVE WREFE-ANO-TER TO LC07-ANO-TER. */
            _.Move(WORK_AREA.FILLER_6.WREFE_ANO_TER, WORK_AREA.LC07.LC07_ANO_TER);

            /*" -557- MOVE WREFE-ANO-TER TO WANO-FATURA. */
            _.Move(WORK_AREA.FILLER_6.WREFE_ANO_TER, WORK_AREA.WNUM_FATURA.WANO_FATURA);

            /*" -557- MOVE WREFE-MES-TER TO WMES-FATURA. */
            _.Move(WORK_AREA.FILLER_6.WREFE_MES_TER, WORK_AREA.WNUM_FATURA.WMES_FATURA);

        }

        [StopWatch]
        /*" R0200-00-SELECT-V0RELATORIOS-DB-SELECT-1 */
        public void R0200_00_SELECT_V0RELATORIOS_DB_SELECT_1()
        {
            /*" -538- EXEC SQL SELECT DATA_REFERENCIA INTO :V0RELA-DTREFER FROM SEGUROS.V0RELATORIOS WHERE CODRELAT = 'VA2417B' AND SITUACAO = '2' END-EXEC. */

            var r0200_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1 = new R0200_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0200_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1.Execute(r0200_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RELA_DTREFER, V0RELA_DTREFER);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-V0HCONTABILVA-SECTION */
        private void R0900_00_DECLARE_V0HCONTABILVA_SECTION()
        {
            /*" -570- MOVE '0900' TO WNR-EXEC-SQL. */
            _.Move("0900", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -592- PERFORM R0900_00_DECLARE_V0HCONTABILVA_DB_DECLARE_1 */

            R0900_00_DECLARE_V0HCONTABILVA_DB_DECLARE_1();

            /*" -594- PERFORM R0900_00_DECLARE_V0HCONTABILVA_DB_OPEN_1 */

            R0900_00_DECLARE_V0HCONTABILVA_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V0HCONTABILVA-DB-DECLARE-1 */
        public void R0900_00_DECLARE_V0HCONTABILVA_DB_DECLARE_1()
        {
            /*" -592- EXEC SQL DECLARE CHCONT CURSOR FOR SELECT A.NUM_APOLICE , A.CODSUBES , B.NOMPRODU , A.NRPARCEL , A.CODOPER , A.DTMOVTO , A.PRMVG + A.PRMAP FROM SEGUROS.V0HISTCONTABILVA A, SEGUROS.V0PRODUTOSVG B WHERE A.DTFATUR = :V0RELA-DTREFER AND A.SITUACAO IN ( ' ' , '1' ) AND A.NUM_APOLICE = B.NUM_APOLICE AND A.CODSUBES = B.CODSUBES AND A.CODOPER �= 1000 AND B.ESTR_COBR = 'MULT' AND B.ORIG_PRODU = 'CEF DEB CC' ORDER BY A.NUM_APOLICE , A.CODSUBES , A.NRPARCEL , A.CODOPER END-EXEC. */
            CHCONT = new VA2426B_CHCONT(true);
            string GetQuery_CHCONT()
            {
                var query = @$"SELECT A.NUM_APOLICE
							, 
							A.CODSUBES
							, 
							B.NOMPRODU
							, 
							A.NRPARCEL
							, 
							A.CODOPER
							, 
							A.DTMOVTO
							, 
							A.PRMVG + A.PRMAP 
							FROM SEGUROS.V0HISTCONTABILVA A
							, 
							SEGUROS.V0PRODUTOSVG B 
							WHERE A.DTFATUR = '{V0RELA_DTREFER}' 
							AND A.SITUACAO IN ( ' '
							, '1' ) 
							AND A.NUM_APOLICE = B.NUM_APOLICE 
							AND A.CODSUBES = B.CODSUBES 
							AND A.CODOPER �= 1000 
							AND B.ESTR_COBR = 'MULT' 
							AND B.ORIG_PRODU = 'CEF DEB CC' 
							ORDER BY A.NUM_APOLICE
							, 
							A.CODSUBES
							, 
							A.NRPARCEL
							, 
							A.CODOPER";

                return query;
            }
            CHCONT.GetQueryEvent += GetQuery_CHCONT;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V0HCONTABILVA-DB-OPEN-1 */
        public void R0900_00_DECLARE_V0HCONTABILVA_DB_OPEN_1()
        {
            /*" -594- EXEC SQL OPEN CHCONT END-EXEC. */

            CHCONT.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-V0HCONTABILVA-SECTION */
        private void R0910_00_FETCH_V0HCONTABILVA_SECTION()
        {
            /*" -607- MOVE '0910' TO WNR-EXEC-SQL. */
            _.Move("0910", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -615- PERFORM R0910_00_FETCH_V0HCONTABILVA_DB_FETCH_1 */

            R0910_00_FETCH_V0HCONTABILVA_DB_FETCH_1();

            /*" -618- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -619- MOVE 'S' TO WFIM-HCONTABILVA */
                _.Move("S", WORK_AREA.WFIM_HCONTABILVA);

                /*" -619- PERFORM R0910_00_FETCH_V0HCONTABILVA_DB_CLOSE_1 */

                R0910_00_FETCH_V0HCONTABILVA_DB_CLOSE_1();

                /*" -622- GO TO R0910-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                return;
            }


            /*" -622- ADD 1 TO AC-LIDOS. */
            WORK_AREA.AC_LIDOS.Value = WORK_AREA.AC_LIDOS + 1;

        }

        [StopWatch]
        /*" R0910-00-FETCH-V0HCONTABILVA-DB-FETCH-1 */
        public void R0910_00_FETCH_V0HCONTABILVA_DB_FETCH_1()
        {
            /*" -615- EXEC SQL FETCH CHCONT INTO :V0HCON-APOLICE , :V0HCON-CODSUBES , :V0PROD-NOMPRODU , :V0HCON-NRPARCEL , :V0HCON-CODOPER , :V0HCON-DTMOVTO , :V0HCON-PRMTOTAL END-EXEC. */

            if (CHCONT.Fetch())
            {
                _.Move(CHCONT.V0HCON_APOLICE, V0HCON_APOLICE);
                _.Move(CHCONT.V0HCON_CODSUBES, V0HCON_CODSUBES);
                _.Move(CHCONT.V0PROD_NOMPRODU, V0PROD_NOMPRODU);
                _.Move(CHCONT.V0HCON_NRPARCEL, V0HCON_NRPARCEL);
                _.Move(CHCONT.V0HCON_CODOPER, V0HCON_CODOPER);
                _.Move(CHCONT.V0HCON_DTMOVTO, V0HCON_DTMOVTO);
                _.Move(CHCONT.V0HCON_PRMTOTAL, V0HCON_PRMTOTAL);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-V0HCONTABILVA-DB-CLOSE-1 */
        public void R0910_00_FETCH_V0HCONTABILVA_DB_CLOSE_1()
        {
            /*" -619- EXEC SQL CLOSE CHCONT END-EXEC */

            CHCONT.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-INPUT-SECTION */
        private void R1000_00_PROCESSA_INPUT_SECTION()
        {
            /*" -634- MOVE V0HCON-APOLICE TO SOR-APOLICE. */
            _.Move(V0HCON_APOLICE, REG_SORT.SOR_APOLICE);

            /*" -635- MOVE V0HCON-CODSUBES TO SOR-CODSUBES. */
            _.Move(V0HCON_CODSUBES, REG_SORT.SOR_CODSUBES);

            /*" -636- MOVE V0PROD-NOMPRODU TO SOR-NOMPRODU. */
            _.Move(V0PROD_NOMPRODU, REG_SORT.SOR_NOMPRODU);

            /*" -637- MOVE V0HCON-NRPARCEL TO SOR-PARCELA. */
            _.Move(V0HCON_NRPARCEL, REG_SORT.SOR_PARCELA);

            /*" -638- MOVE V0HCON-CODOPER TO SOR-CODOPER. */
            _.Move(V0HCON_CODOPER, REG_SORT.SOR_CODOPER);

            /*" -639- MOVE V0HCON-DTMOVTO TO SOR-DTMOVTO. */
            _.Move(V0HCON_DTMOVTO, REG_SORT.SOR_DTMOVTO);

            /*" -641- MOVE V0HCON-PRMTOTAL TO SOR-PREMIO. */
            _.Move(V0HCON_PRMTOTAL, REG_SORT.SOR_PREMIO);

            /*" -644- IF V0HCON-CODOPER > 199 AND V0HCON-CODOPER < 300 AND V0HCON-NRPARCEL = 1 */

            if (V0HCON_CODOPER > 199 && V0HCON_CODOPER < 300 && V0HCON_NRPARCEL == 1)
            {

                /*" -646- MOVE 1 TO SOR-TIPOREG. */
                _.Move(1, REG_SORT.SOR_TIPOREG);
            }


            /*" -649- IF V0HCON-CODOPER > 199 AND V0HCON-CODOPER < 300 AND V0HCON-NRPARCEL > 1 */

            if (V0HCON_CODOPER > 199 && V0HCON_CODOPER < 300 && V0HCON_NRPARCEL > 1)
            {

                /*" -651- MOVE 2 TO SOR-TIPOREG. */
                _.Move(2, REG_SORT.SOR_TIPOREG);
            }


            /*" -653- IF V0HCON-CODOPER > 399 AND V0HCON-CODOPER < 500 */

            if (V0HCON_CODOPER > 399 && V0HCON_CODOPER < 500)
            {

                /*" -655- MOVE 3 TO SOR-TIPOREG. */
                _.Move(3, REG_SORT.SOR_TIPOREG);
            }


            /*" -657- IF V0HCON-CODOPER > 499 AND V0HCON-CODOPER < 600 */

            if (V0HCON_CODOPER > 499 && V0HCON_CODOPER < 600)
            {

                /*" -659- MOVE 4 TO SOR-TIPOREG. */
                _.Move(4, REG_SORT.SOR_TIPOREG);
            }


            /*" -659- RELEASE REG-SORT. */
            SVA2426B.Release(REG_SORT);

            /*" -0- FLUXCONTROL_PERFORM R1000_10_NEXT */

            R1000_10_NEXT();

        }

        [StopWatch]
        /*" R1000-10-NEXT */
        private void R1000_10_NEXT(bool isPerform = false)
        {
            /*" -663- PERFORM R0910-00-FETCH-V0HCONTABILVA. */

            R0910_00_FETCH_V0HCONTABILVA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-PROCESSA-OUTPUT-SECTION */
        private void R2000_00_PROCESSA_OUTPUT_SECTION()
        {
            /*" -677- MOVE SOR-NOMPRODU TO LC06-TIPO PRODUTO-ANT. */
            _.Move(REG_SORT.SOR_NOMPRODU, WORK_AREA.LC06.LC06_TIPO, WORK_AREA.PRODUTO_ANT);

            /*" -679- PERFORM R3000-00-CABECALHOS. */

            R3000_00_CABECALHOS_SECTION();

            /*" -683- PERFORM R2200-00-QUEBRA-PRODUTO UNTIL WFIM-SORT EQUAL 'S' OR SOR-NOMPRODU NOT EQUAL PRODUTO-ANT. */

            while (!(WORK_AREA.WFIM_SORT == "S" || REG_SORT.SOR_NOMPRODU != WORK_AREA.PRODUTO_ANT))
            {

                R2200_00_QUEBRA_PRODUTO_SECTION();
            }

            /*" -684- MOVE 'PRODUTO ' TO CAB-1-TIPO. */
            _.Move("PRODUTO ", WORK_AREA.TOT_CAB_1.CAB_1_TIPO);

            /*" -686- MOVE WS-VLOPER-TOT TO CAB-1-TOTAL. */
            _.Move(WORK_AREA.WS_VLOPER_TOT, WORK_AREA.TOT_CAB_1.CAB_1_TOTAL);

            /*" -689- WRITE REG-RVA2426B FROM TOT-CAB-1 AFTER 2. */
            _.Move(WORK_AREA.TOT_CAB_1.GetMoveValues(), REG_RVA2426B);

            RVA2426B.Write(REG_RVA2426B.GetMoveValues().ToString());

            /*" -691- MOVE ZEROS TO WS-VLOPER-TOT. */
            _.Move(0, WORK_AREA.WS_VLOPER_TOT);

            /*" -692- IF WFIM-SORT NOT EQUAL 'S' */

            if (WORK_AREA.WFIM_SORT != "S")
            {

                /*" -693- IF SOR-TIPOREG EQUAL 1 */

                if (REG_SORT.SOR_TIPOREG == 1)
                {

                    /*" -694- MOVE 'VENDAS NOVAS    (+)' TO LC09-OPERACAO */
                    _.Move("VENDAS NOVAS    (+)", WORK_AREA.LC09.LC09_OPERACAO);

                    /*" -695- ELSE */
                }
                else
                {


                    /*" -696- IF SOR-TIPOREG EQUAL 2 */

                    if (REG_SORT.SOR_TIPOREG == 2)
                    {

                        /*" -697- MOVE 'DEMAIS PARCELAS (+)' TO LC09-OPERACAO */
                        _.Move("DEMAIS PARCELAS (+)", WORK_AREA.LC09.LC09_OPERACAO);

                        /*" -698- ELSE */
                    }
                    else
                    {


                        /*" -699- IF SOR-TIPOREG EQUAL 3 */

                        if (REG_SORT.SOR_TIPOREG == 3)
                        {

                            /*" -700- MOVE 'CANCELAMENTOS   (-)' TO LC09-OPERACAO */
                            _.Move("CANCELAMENTOS   (-)", WORK_AREA.LC09.LC09_OPERACAO);

                            /*" -701- ELSE */
                        }
                        else
                        {


                            /*" -702- IF SOR-TIPOREG EQUAL 4 */

                            if (REG_SORT.SOR_TIPOREG == 4)
                            {

                                /*" -702- MOVE 'RESTITUICOES    (-)' TO LC09-OPERACAO. */
                                _.Move("RESTITUICOES    (-)", WORK_AREA.LC09.LC09_OPERACAO);
                            }

                        }

                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-RETURN-SECTION */
        private void R2100_00_RETURN_SECTION()
        {
            /*" -715- MOVE '2100' TO WNR-EXEC-SQL. */
            _.Move("2100", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -717- RETURN SVA2426B AT END */
            try
            {
                SVA2426B.Return(REG_SORT, () =>
                {

                    /*" -718- MOVE 'S' TO WFIM-SORT */
                    _.Move("S", WORK_AREA.WFIM_SORT);

                    /*" -718- GO TO R2100-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/ //GOTO
                    return;

                });
            }
            catch (GoToException ex)
            {
                return;
            }
        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-QUEBRA-PRODUTO-SECTION */
        private void R2200_00_QUEBRA_PRODUTO_SECTION()
        {
            /*" -731- MOVE '2200' TO WNR-EXEC-SQL. */
            _.Move("2200", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -733- MOVE SOR-TIPOREG TO TIPOREG-ANT. */
            _.Move(REG_SORT.SOR_TIPOREG, WORK_AREA.TIPOREG_ANT);

            /*" -738- PERFORM R2300-00-QUEBRA-TIPOREG UNTIL WFIM-SORT EQUAL 'S' OR SOR-NOMPRODU NOT EQUAL PRODUTO-ANT OR SOR-TIPOREG NOT EQUAL TIPOREG-ANT. */

            while (!(WORK_AREA.WFIM_SORT == "S" || REG_SORT.SOR_NOMPRODU != WORK_AREA.PRODUTO_ANT || REG_SORT.SOR_TIPOREG != WORK_AREA.TIPOREG_ANT))
            {

                R2300_00_QUEBRA_TIPOREG_SECTION();
            }

            /*" -739- IF TIPOREG-ANT EQUAL 1 */

            if (WORK_AREA.TIPOREG_ANT == 1)
            {

                /*" -741- ADD AC-PREMIO TO WS-VLOPER-OPER WS-VLOPER-TOT */
                WORK_AREA.WS_VLOPER_OPER.Value = WORK_AREA.WS_VLOPER_OPER + WORK_AREA.AC_PREMIO;
                WORK_AREA.WS_VLOPER_TOT.Value = WORK_AREA.WS_VLOPER_TOT + WORK_AREA.AC_PREMIO;

                /*" -742- ELSE */
            }
            else
            {


                /*" -743- IF TIPOREG-ANT EQUAL 2 */

                if (WORK_AREA.TIPOREG_ANT == 2)
                {

                    /*" -745- ADD AC-PREMIO TO WS-VLOPER-OPER WS-VLOPER-TOT */
                    WORK_AREA.WS_VLOPER_OPER.Value = WORK_AREA.WS_VLOPER_OPER + WORK_AREA.AC_PREMIO;
                    WORK_AREA.WS_VLOPER_TOT.Value = WORK_AREA.WS_VLOPER_TOT + WORK_AREA.AC_PREMIO;

                    /*" -746- ELSE */
                }
                else
                {


                    /*" -747- IF TIPOREG-ANT EQUAL 3 */

                    if (WORK_AREA.TIPOREG_ANT == 3)
                    {

                        /*" -748- ADD AC-PREMIO TO WS-VLOPER-OPER */
                        WORK_AREA.WS_VLOPER_OPER.Value = WORK_AREA.WS_VLOPER_OPER + WORK_AREA.AC_PREMIO;

                        /*" -749- SUBTRACT AC-PREMIO FROM WS-VLOPER-TOT */
                        WORK_AREA.WS_VLOPER_TOT.Value = WORK_AREA.WS_VLOPER_TOT - WORK_AREA.AC_PREMIO;

                        /*" -750- ELSE */
                    }
                    else
                    {


                        /*" -751- IF TIPOREG-ANT EQUAL 4 */

                        if (WORK_AREA.TIPOREG_ANT == 4)
                        {

                            /*" -752- ADD AC-PREMIO TO WS-VLOPER-OPER */
                            WORK_AREA.WS_VLOPER_OPER.Value = WORK_AREA.WS_VLOPER_OPER + WORK_AREA.AC_PREMIO;

                            /*" -754- SUBTRACT AC-PREMIO FROM WS-VLOPER-TOT. */
                            WORK_AREA.WS_VLOPER_TOT.Value = WORK_AREA.WS_VLOPER_TOT - WORK_AREA.AC_PREMIO;
                        }

                    }

                }

            }


            /*" -756- MOVE ZEROS TO AC-PREMIO. */
            _.Move(0, WORK_AREA.AC_PREMIO);

            /*" -757- MOVE 'OPERACAO' TO CAB-1-TIPO. */
            _.Move("OPERACAO", WORK_AREA.TOT_CAB_1.CAB_1_TIPO);

            /*" -759- MOVE WS-VLOPER-OPER TO CAB-1-TOTAL. */
            _.Move(WORK_AREA.WS_VLOPER_OPER, WORK_AREA.TOT_CAB_1.CAB_1_TOTAL);

            /*" -761- ADD +4 TO AC-LINHAS. */
            WORK_AREA.AC_LINHAS.Value = WORK_AREA.AC_LINHAS + +4;

            /*" -762- IF AC-LINHAS GREATER +55 */

            if (WORK_AREA.AC_LINHAS > +55)
            {

                /*" -764- PERFORM R3000-00-CABECALHOS. */

                R3000_00_CABECALHOS_SECTION();
            }


            /*" -767- WRITE REG-RVA2426B FROM TOT-CAB-1 AFTER 2. */
            _.Move(WORK_AREA.TOT_CAB_1.GetMoveValues(), REG_RVA2426B);

            RVA2426B.Write(REG_RVA2426B.GetMoveValues().ToString());

            /*" -769- MOVE ZEROS TO WS-VLOPER-OPER. */
            _.Move(0, WORK_AREA.WS_VLOPER_OPER);

            /*" -771- IF WFIM-SORT NOT EQUAL 'S' AND SOR-NOMPRODU EQUAL PRODUTO-ANT */

            if (WORK_AREA.WFIM_SORT != "S" && REG_SORT.SOR_NOMPRODU == WORK_AREA.PRODUTO_ANT)
            {

                /*" -772- IF SOR-TIPOREG EQUAL 1 */

                if (REG_SORT.SOR_TIPOREG == 1)
                {

                    /*" -773- MOVE 'VENDAS NOVAS    (+)' TO LC09-OPERACAO */
                    _.Move("VENDAS NOVAS    (+)", WORK_AREA.LC09.LC09_OPERACAO);

                    /*" -774- WRITE REG-RVA2426B FROM LC09 AFTER 1 */
                    _.Move(WORK_AREA.LC09.GetMoveValues(), REG_RVA2426B);

                    RVA2426B.Write(REG_RVA2426B.GetMoveValues().ToString());

                    /*" -775- ELSE */
                }
                else
                {


                    /*" -776- IF SOR-TIPOREG EQUAL 2 */

                    if (REG_SORT.SOR_TIPOREG == 2)
                    {

                        /*" -777- MOVE 'DEMAIS PARCELAS (+)' TO LC09-OPERACAO */
                        _.Move("DEMAIS PARCELAS (+)", WORK_AREA.LC09.LC09_OPERACAO);

                        /*" -778- WRITE REG-RVA2426B FROM LC09 AFTER 1 */
                        _.Move(WORK_AREA.LC09.GetMoveValues(), REG_RVA2426B);

                        RVA2426B.Write(REG_RVA2426B.GetMoveValues().ToString());

                        /*" -779- ELSE */
                    }
                    else
                    {


                        /*" -780- IF SOR-TIPOREG EQUAL 3 */

                        if (REG_SORT.SOR_TIPOREG == 3)
                        {

                            /*" -781- MOVE 'CANCELAMENTOS   (-)' TO LC09-OPERACAO */
                            _.Move("CANCELAMENTOS   (-)", WORK_AREA.LC09.LC09_OPERACAO);

                            /*" -782- WRITE REG-RVA2426B FROM LC09 AFTER 1 */
                            _.Move(WORK_AREA.LC09.GetMoveValues(), REG_RVA2426B);

                            RVA2426B.Write(REG_RVA2426B.GetMoveValues().ToString());

                            /*" -783- ELSE */
                        }
                        else
                        {


                            /*" -784- IF SOR-TIPOREG EQUAL 4 */

                            if (REG_SORT.SOR_TIPOREG == 4)
                            {

                                /*" -785- MOVE 'RESTITUICOES    (-)' TO LC09-OPERACAO */
                                _.Move("RESTITUICOES    (-)", WORK_AREA.LC09.LC09_OPERACAO);

                                /*" -785- WRITE REG-RVA2426B FROM LC09 AFTER 1. */
                                _.Move(WORK_AREA.LC09.GetMoveValues(), REG_RVA2426B);

                                RVA2426B.Write(REG_RVA2426B.GetMoveValues().ToString());
                            }

                        }

                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-QUEBRA-TIPOREG-SECTION */
        private void R2300_00_QUEBRA_TIPOREG_SECTION()
        {
            /*" -798- MOVE '2300' TO WNR-EXEC-SQL. */
            _.Move("2300", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -800- MOVE SOR-DTMOVTO TO DATA-ANT. */
            _.Move(REG_SORT.SOR_DTMOVTO, WORK_AREA.DATA_ANT);

            /*" -806- PERFORM R2400-00-QUEBRA-DATA UNTIL WFIM-SORT EQUAL 'S' OR SOR-NOMPRODU NOT EQUAL PRODUTO-ANT OR SOR-TIPOREG NOT EQUAL TIPOREG-ANT OR SOR-DTMOVTO NOT EQUAL DATA-ANT. */

            while (!(WORK_AREA.WFIM_SORT == "S" || REG_SORT.SOR_NOMPRODU != WORK_AREA.PRODUTO_ANT || REG_SORT.SOR_TIPOREG != WORK_AREA.TIPOREG_ANT || REG_SORT.SOR_DTMOVTO != WORK_AREA.DATA_ANT))
            {

                R2400_00_QUEBRA_DATA_SECTION();
            }

            /*" -806- PERFORM R2500-00-IMPRIME. */

            R2500_00_IMPRIME_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-QUEBRA-DATA-SECTION */
        private void R2400_00_QUEBRA_DATA_SECTION()
        {
            /*" -820- ADD SOR-PREMIO TO AC-PREMIO WS-PREMIO. */
            WORK_AREA.AC_PREMIO.Value = WORK_AREA.AC_PREMIO + REG_SORT.SOR_PREMIO;
            WORK_AREA.WS_PREMIO.Value = WORK_AREA.WS_PREMIO + REG_SORT.SOR_PREMIO;

            /*" -820- PERFORM R2100-00-RETURN. */

            R2100_00_RETURN_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-IMPRIME-SECTION */
        private void R2500_00_IMPRIME_SECTION()
        {
            /*" -833- MOVE '2500' TO WNR-EXEC-SQL. */
            _.Move("2500", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -834- MOVE DATA-ANT TO WDATA-REL. */
            _.Move(WORK_AREA.DATA_ANT, WORK_AREA.WDATA_REL);

            /*" -835- MOVE WDAT-REL-ANO TO DET1-ANO-MOV. */
            _.Move(WORK_AREA.FILLER_0.WDAT_REL_ANO, WORK_AREA.DET_1.DET1_ANO_MOV);

            /*" -836- MOVE WDAT-REL-MES TO DET1-MES-MOV. */
            _.Move(WORK_AREA.FILLER_0.WDAT_REL_MES, WORK_AREA.DET_1.DET1_MES_MOV);

            /*" -838- MOVE WDAT-REL-DIA TO DET1-DIA-MOV. */
            _.Move(WORK_AREA.FILLER_0.WDAT_REL_DIA, WORK_AREA.DET_1.DET1_DIA_MOV);

            /*" -840- MOVE WS-PREMIO TO DET1-VALOR. */
            _.Move(WORK_AREA.WS_PREMIO, WORK_AREA.DET_1.DET1_VALOR);

            /*" -842- ADD +1 TO AC-LINHAS. */
            WORK_AREA.AC_LINHAS.Value = WORK_AREA.AC_LINHAS + +1;

            /*" -843- IF AC-LINHAS GREATER +55 */

            if (WORK_AREA.AC_LINHAS > +55)
            {

                /*" -845- PERFORM R3000-00-CABECALHOS. */

                R3000_00_CABECALHOS_SECTION();
            }


            /*" -847- WRITE REG-RVA2426B FROM DET-1 AFTER 1. */
            _.Move(WORK_AREA.DET_1.GetMoveValues(), REG_RVA2426B);

            RVA2426B.Write(REG_RVA2426B.GetMoveValues().ToString());

            /*" -847- MOVE ZEROS TO WS-PREMIO. */
            _.Move(0, WORK_AREA.WS_PREMIO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-CABECALHOS-SECTION */
        private void R3000_00_CABECALHOS_SECTION()
        {
            /*" -860- MOVE '3000' TO WNR-EXEC-SQL. */
            _.Move("3000", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -862- MOVE WNUM-FATURA TO LC07-FATURA. */
            _.Move(WORK_AREA.WNUM_FATURA, WORK_AREA.LC07.LC07_FATURA);

            /*" -863- ADD +1 TO AC-PAGINA. */
            WORK_AREA.AC_PAGINA.Value = WORK_AREA.AC_PAGINA + +1;

            /*" -864- MOVE AC-PAGINA TO LC03-PAGINA. */
            _.Move(WORK_AREA.AC_PAGINA, WORK_AREA.LC03.LC03_PAGINA);

            /*" -866- MOVE 11 TO AC-LINHAS. */
            _.Move(11, WORK_AREA.AC_LINHAS);

            /*" -867- WRITE REG-RVA2426B FROM LC01 AFTER PAGE */
            _.Move(WORK_AREA.LC01.GetMoveValues(), REG_RVA2426B);

            RVA2426B.Write(REG_RVA2426B.GetMoveValues().ToString());

            /*" -868- WRITE REG-RVA2426B FROM LC02 AFTER 1 */
            _.Move(WORK_AREA.LC02.GetMoveValues(), REG_RVA2426B);

            RVA2426B.Write(REG_RVA2426B.GetMoveValues().ToString());

            /*" -869- WRITE REG-RVA2426B FROM LC03 AFTER 1 */
            _.Move(WORK_AREA.LC03.GetMoveValues(), REG_RVA2426B);

            RVA2426B.Write(REG_RVA2426B.GetMoveValues().ToString());

            /*" -870- WRITE REG-RVA2426B FROM LC04 AFTER 1 */
            _.Move(WORK_AREA.LC04.GetMoveValues(), REG_RVA2426B);

            RVA2426B.Write(REG_RVA2426B.GetMoveValues().ToString());

            /*" -871- WRITE REG-RVA2426B FROM LC05 AFTER 1 */
            _.Move(WORK_AREA.LC05.GetMoveValues(), REG_RVA2426B);

            RVA2426B.Write(REG_RVA2426B.GetMoveValues().ToString());

            /*" -872- WRITE REG-RVA2426B FROM LC06 AFTER 1 */
            _.Move(WORK_AREA.LC06.GetMoveValues(), REG_RVA2426B);

            RVA2426B.Write(REG_RVA2426B.GetMoveValues().ToString());

            /*" -873- WRITE REG-RVA2426B FROM LC07 AFTER 1 */
            _.Move(WORK_AREA.LC07.GetMoveValues(), REG_RVA2426B);

            RVA2426B.Write(REG_RVA2426B.GetMoveValues().ToString());

            /*" -874- WRITE REG-RVA2426B FROM LC01 AFTER 1 */
            _.Move(WORK_AREA.LC01.GetMoveValues(), REG_RVA2426B);

            RVA2426B.Write(REG_RVA2426B.GetMoveValues().ToString());

            /*" -875- WRITE REG-RVA2426B FROM LC08 AFTER 2 */
            _.Move(WORK_AREA.LC08.GetMoveValues(), REG_RVA2426B);

            RVA2426B.Write(REG_RVA2426B.GetMoveValues().ToString());

            /*" -875- WRITE REG-RVA2426B FROM LC09 AFTER 1. */
            _.Move(WORK_AREA.LC09.GetMoveValues(), REG_RVA2426B);

            RVA2426B.Write(REG_RVA2426B.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-UPDATE-RELATORIO-SECTION */
        private void R4000_00_UPDATE_RELATORIO_SECTION()
        {
            /*" -888- MOVE '400' TO WNR-EXEC-SQL. */
            _.Move("400", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -893- PERFORM R4000_00_UPDATE_RELATORIO_DB_UPDATE_1 */

            R4000_00_UPDATE_RELATORIO_DB_UPDATE_1();

            /*" -896- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -897- DISPLAY 'PROBLEMAS NO UPDATE V0RELATORIOS ' */
                _.Display($"PROBLEMAS NO UPDATE V0RELATORIOS ");

                /*" -897- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4000-00-UPDATE-RELATORIO-DB-UPDATE-1 */
        public void R4000_00_UPDATE_RELATORIO_DB_UPDATE_1()
        {
            /*" -893- EXEC SQL UPDATE SEGUROS.V0RELATORIOS SET SITUACAO = '3' WHERE CODRELAT = 'VA2417B' AND SITUACAO = '2' END-EXEC */

            var r4000_00_UPDATE_RELATORIO_DB_UPDATE_1_Update1 = new R4000_00_UPDATE_RELATORIO_DB_UPDATE_1_Update1()
            {
            };

            R4000_00_UPDATE_RELATORIO_DB_UPDATE_1_Update1.Execute(r4000_00_UPDATE_RELATORIO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R8000-00-ABRE-ARQUIVOS-SECTION */
        private void R8000_00_ABRE_ARQUIVOS_SECTION()
        {
            /*" -910- MOVE '8000' TO WNR-EXEC-SQL. */
            _.Move("8000", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -910- OPEN OUTPUT RVA2426B. */
            RVA2426B.Open(REG_RVA2426B);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-FECHA-ARQUIVOS-SECTION */
        private void R9000_00_FECHA_ARQUIVOS_SECTION()
        {
            /*" -923- MOVE '9000' TO WNR-EXEC-SQL. */
            _.Move("9000", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -923- CLOSE RVA2426B. */
            RVA2426B.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -937- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WORK_AREA.WABEND.WSQLCODE);

            /*" -939- DISPLAY WABEND */
            _.Display(WORK_AREA.WABEND);

            /*" -939- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -941- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -945- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -947- CLOSE RVA2426B */
            RVA2426B.Close();

            /*" -947- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}