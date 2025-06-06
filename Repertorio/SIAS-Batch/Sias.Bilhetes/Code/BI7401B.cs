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
using Sias.Bilhetes.DB2.BI7401B;

namespace Code
{
    public class BI7401B
    {
        public bool IsCall { get; set; }

        public BI7401B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  BILHETE                            *      */
        /*"      *   PROGRAMA ...............  BI7401B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  CLOVIS                             *      */
        /*"      *   PROGRAMADOR ............  CLOVIS                             *      */
        /*"      *   DATA CODIFICACAO .......  10/05/2019                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  CANCELAMENTO SOLICITADO DOS        *      */
        /*"      *                             BILHETES PARCELA UNICA.            *      */
        /*"      *                                                                *      */
        /*"      *   HIST�RIA 192855           VERSAO DO PROGRAMA BI6401B.        *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 01 - SOLICITACAO DA GECOC - ABEND RG0022B E RG0029B   *      */
        /*"      *             - PREENCHER O CAMPO DATA QUITACAO NA OPERACAO DE   *      */
        /*"      *             BAIXA 290, POIS ESTA CAUSANDO ABENDS EM PRODUCAO.  *      */
        /*"      *                                                                *      */
        /*"      *   EM 06/01/2020 - FRANK CARVALHO                               *      */
        /*"      *                                       PROCURE POR V.01         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        #endregion


        #region VARIABLES

        public FileBasis _SAIDA01 { get; set; } = new FileBasis(new PIC("X", "0300", "X(0300)"));

        public FileBasis SAIDA01
        {
            get
            {
                _.Move(REG_SAIDA01, _SAIDA01); VarBasis.RedefinePassValue(REG_SAIDA01, _SAIDA01, REG_SAIDA01); return _SAIDA01;
            }
        }
        public FileBasis _SAIDA02 { get; set; } = new FileBasis(new PIC("X", "0300", "X(0300)"));

        public FileBasis SAIDA02
        {
            get
            {
                _.Move(REG_SAIDA02, _SAIDA02); VarBasis.RedefinePassValue(REG_SAIDA02, _SAIDA02, REG_SAIDA02); return _SAIDA02;
            }
        }
        public SortBasis<BI7401B_REG_SBI7401B> SBI7401B { get; set; } = new SortBasis<BI7401B_REG_SBI7401B>(new BI7401B_REG_SBI7401B());
        /*"01         REG-SBI7401B.*/
        public BI7401B_REG_SBI7401B REG_SBI7401B { get; set; } = new BI7401B_REG_SBI7401B();
        public class BI7401B_REG_SBI7401B : VarBasis
        {
            /*"  05       SOR-NRSEQ             PIC 9(001).*/
            public IntBasis SOR_NRSEQ { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05       SOR-BILHETE           PIC 9(011).*/
            public IntBasis SOR_BILHETE { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
            /*"  05       SOR-APOLICE           PIC 9(013).*/
            public IntBasis SOR_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"  05       SOR-ENDOSSO           PIC 9(009).*/
            public IntBasis SOR_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05       SOR-PARCELA           PIC 9(004).*/
            public IntBasis SOR_PARCELA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       SOR-RAMO              PIC 9(004).*/
            public IntBasis SOR_RAMO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       SOR-PRODUTO           PIC 9(004).*/
            public IntBasis SOR_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       SOR-MODALIDA          PIC 9(004).*/
            public IntBasis SOR_MODALIDA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       SOR-AGEVENDA          PIC 9(004).*/
            public IntBasis SOR_AGEVENDA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       SOR-DTVENDA           PIC X(010).*/
            public StringBasis SOR_DTVENDA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05       SOR-DTCANCEL          PIC X(010).*/
            public StringBasis SOR_DTCANCEL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05       SOR-VALOR             PIC 9(013)V99.*/
            public DoubleBasis SOR_VALOR { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"  05       SOR-SEGURADO          PIC X(040).*/
            public StringBasis SOR_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  05       SOR-CGCCPF            PIC 9(015).*/
            public IntBasis SOR_CGCCPF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"  05       SOR-BCOAVISO          PIC 9(004).*/
            public IntBasis SOR_BCOAVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       SOR-AGEAVISO          PIC 9(004).*/
            public IntBasis SOR_AGEAVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       SOR-NRAVISO           PIC 9(009).*/
            public IntBasis SOR_NRAVISO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05       SOR-PROPOSTA          PIC 9(015).*/
            public IntBasis SOR_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"  05       SOR-PARCELADO         PIC X(001).*/
            public StringBasis SOR_PARCELADO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05       SOR-TIPO-ENDOSSO      PIC X(001).*/
            public StringBasis SOR_TIPO_ENDOSSO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05       SOR-IND-DEFINIT       PIC X(001).*/
            public StringBasis SOR_IND_DEFINIT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05       SOR-IND-RESUMO        PIC X(001).*/
            public StringBasis SOR_IND_RESUMO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05       SOR-FONTE             PIC 9(004).*/
            public IntBasis SOR_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       SOR-NRRCAP            PIC 9(009).*/
            public IntBasis SOR_NRRCAP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05       SOR-OPERACAO          PIC 9(004).*/
            public IntBasis SOR_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"01         REG-SAIDA01           PIC  X(300).*/
        }
        public StringBasis REG_SAIDA01 { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");
        /*"01         REG-SAIDA02           PIC  X(300).*/
        public StringBasis REG_SAIDA02 { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77    VIND-NULL01               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL01 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL02               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL02 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DATA-RCAP            PIC S9(004)     COMP.*/
        public IntBasis VIND_DATA_RCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-COD-EMPRESA          PIC S9(004)     COMP.*/
        public IntBasis VIND_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-TIPO-CORRECAO        PIC S9(004)     COMP.*/
        public IntBasis VIND_TIPO_CORRECAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-ISENTA-CUSTO         PIC S9(004)     COMP.*/
        public IntBasis VIND_ISENTA_CUSTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTVENCTO             PIC S9(004)     COMP.*/
        public IntBasis VIND_DTVENCTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-COEF-PREFIX          PIC S9(004)     COMP.*/
        public IntBasis VIND_COEF_PREFIX { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-VAL-CUSTO            PIC S9(004)     COMP.*/
        public IntBasis VIND_VAL_CUSTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    HOST-COUNT                PIC S9(009)     COMP.*/
        public IntBasis HOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V1SIST-DTMOVABE-1Y        PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE_1Y { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  W.*/
        public BI7401B_W W { get; set; } = new BI7401B_W();
        public class BI7401B_W : VarBasis
        {
            /*"  03  WFIM-MOVIMENTO            PIC  X(001)         VALUE SPACES*/
            public StringBasis WFIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WFIM-SORT                 PIC  X(001)         VALUE SPACES*/
            public StringBasis WFIM_SORT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  LD-RCAPCOMP               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis LD_RCAPCOMP { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  LD-RELATORI               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis LD_RELATORI { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  LD-SORT                   PIC  9(009)         VALUE  ZEROS*/
            public IntBasis LD_SORT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  DP-BI16A                  PIC  9(009)         VALUE  ZEROS*/
            public IntBasis DP_BI16A { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-ENDOSSO                PIC  9(007)         VALUE ZEROS.*/
            public IntBasis AC_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-PARCELADO              PIC  9(007)         VALUE ZEROS.*/
            public IntBasis AC_PARCELADO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-DEVOLVIDO              PIC  9(007)         VALUE ZEROS.*/
            public IntBasis AC_DEVOLVIDO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-ATUAL                  PIC  9(007)         VALUE ZEROS.*/
            public IntBasis AC_ATUAL { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-UPDATE                 PIC  9(007)         VALUE ZEROS.*/
            public IntBasis AC_UPDATE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-CONTROLE               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis AC_CONTROLE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-RCAPS                  PIC  9(007)         VALUE ZEROS.*/
            public IntBasis TT_RCAPS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  GV-SORT                   PIC  9(009)         VALUE  ZEROS*/
            public IntBasis GV_SORT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  GV-ARQUIVO01              PIC  9(009)         VALUE ZEROS.*/
            public IntBasis GV_ARQUIVO01 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  GV-ARQUIVO02              PIC  9(009)         VALUE ZEROS.*/
            public IntBasis GV_ARQUIVO02 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  NT-RELATORI               PIC  9(009)         VALUE ZEROS.*/
            public IntBasis NT_RELATORI { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  NT-BILHETE                PIC  9(009)         VALUE ZEROS.*/
            public IntBasis NT_BILHETE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  UP-RELATORI               PIC  9(009)         VALUE ZEROS.*/
            public IntBasis UP_RELATORI { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  UP-BILHETE                PIC  9(009)         VALUE ZEROS.*/
            public IntBasis UP_BILHETE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  UP-RCAPS                  PIC  9(009)         VALUE ZEROS.*/
            public IntBasis UP_RCAPS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  IN-ENDOSSOS               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis IN_ENDOSSOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  IN-APOLICOB               PIC  9(009)         VALUE ZEROS.*/
            public IntBasis IN_APOLICOB { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03         AC-LIDOS           PIC  9(013)    VALUE   ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  03         FILLER             REDEFINES      AC-LIDOS.*/
            private _REDEF_BI7401B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_BI7401B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_BI7401B_FILLER_0(); _.Move(AC_LIDOS, _filler_0); VarBasis.RedefinePassValue(AC_LIDOS, _filler_0, AC_LIDOS); _filler_0.ValueChanged += () => { _.Move(_filler_0, AC_LIDOS); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, AC_LIDOS); }
            }  //Redefines
            public class _REDEF_BI7401B_FILLER_0 : VarBasis
            {
                /*"      10     LD-PARTE1          PIC  9(009).*/
                public IntBasis LD_PARTE1 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"      10     LD-PARTE2          PIC  9(004).*/
                public IntBasis LD_PARTE2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  03         WDATA-REL         PIC  X(010)    VALUE SPACES.*/

                public _REDEF_BI7401B_FILLER_0()
                {
                    LD_PARTE1.ValueChanged += OnValueChanged;
                    LD_PARTE2.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03         FILLER            REDEFINES      WDATA-REL.*/
            private _REDEF_BI7401B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_BI7401B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_BI7401B_FILLER_1(); _.Move(WDATA_REL, _filler_1); VarBasis.RedefinePassValue(WDATA_REL, _filler_1, WDATA_REL); _filler_1.ValueChanged += () => { _.Move(_filler_1, WDATA_REL); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, WDATA_REL); }
            }  //Redefines
            public class _REDEF_BI7401B_FILLER_1 : VarBasis
            {
                /*"    10       WDAT-REL-ANO      PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-MES      PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-DIA      PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WTIME-DAY          PIC  99.99.99.99.*/

                public _REDEF_BI7401B_FILLER_1()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_3.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WTIME_DAY { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
            /*"  03         FILLER             REDEFINES      WTIME-DAY.*/
            private _REDEF_BI7401B_FILLER_4 _filler_4 { get; set; }
            public _REDEF_BI7401B_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_BI7401B_FILLER_4(); _.Move(WTIME_DAY, _filler_4); VarBasis.RedefinePassValue(WTIME_DAY, _filler_4, WTIME_DAY); _filler_4.ValueChanged += () => { _.Move(_filler_4, WTIME_DAY); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, WTIME_DAY); }
            }  //Redefines
            public class _REDEF_BI7401B_FILLER_4 : VarBasis
            {
                /*"    10       WTIME-DAYR.*/
                public BI7401B_WTIME_DAYR WTIME_DAYR { get; set; } = new BI7401B_WTIME_DAYR();
                public class BI7401B_WTIME_DAYR : VarBasis
                {
                    /*"      15     WTIME-HORA         PIC  X(002).*/
                    public StringBasis WTIME_HORA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"      15     WTIME-2PT1         PIC  X(001).*/
                    public StringBasis WTIME_2PT1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15     WTIME-MINU         PIC  X(002).*/
                    public StringBasis WTIME_MINU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"      15     WTIME-2PT2         PIC  X(001).*/
                    public StringBasis WTIME_2PT2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15     WTIME-SEGU         PIC  X(002).*/
                    public StringBasis WTIME_SEGU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"    10       WTIME-2PT3         PIC  X(001).*/

                    public BI7401B_WTIME_DAYR()
                    {
                        WTIME_HORA.ValueChanged += OnValueChanged;
                        WTIME_2PT1.ValueChanged += OnValueChanged;
                        WTIME_MINU.ValueChanged += OnValueChanged;
                        WTIME_2PT2.ValueChanged += OnValueChanged;
                        WTIME_SEGU.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis WTIME_2PT3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WTIME-CCSE         PIC  X(002).*/
                public StringBasis WTIME_CCSE { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"  03         WS-TIME.*/

                public _REDEF_BI7401B_FILLER_4()
                {
                    WTIME_DAYR.ValueChanged += OnValueChanged;
                    WTIME_2PT3.ValueChanged += OnValueChanged;
                    WTIME_CCSE.ValueChanged += OnValueChanged;
                }

            }
            public BI7401B_WS_TIME WS_TIME { get; set; } = new BI7401B_WS_TIME();
            public class BI7401B_WS_TIME : VarBasis
            {
                /*"      10     WS-HH-TIME         PIC  9(002).*/
                public IntBasis WS_HH_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-MM-TIME         PIC  9(002).*/
                public IntBasis WS_MM_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-SS-TIME         PIC  9(002).*/
                public IntBasis WS_SS_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-CC-TIME         PIC  9(002).*/
                public IntBasis WS_CC_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03        WABEND.*/
            }
            public BI7401B_WABEND WABEND { get; set; } = new BI7401B_WABEND();
            public class BI7401B_WABEND : VarBasis
            {
                /*"    05      FILLER              PIC  X(010) VALUE           ' BI7401B  '.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" BI7401B  ");
                /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05      WNR-EXEC-SQL        PIC  X(004) VALUE    SPACES.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"    05      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD1 = '.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"    05      WSQLERRD1           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD2 = '.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05      WSQLERRD2           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRMC = '.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRMC = ");
                /*"    05      WSQLERRMC           PIC  X(070) VALUE    SPACES.*/
                public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                /*"01            AUX-RELATORIO.*/
            }
        }
        public BI7401B_AUX_RELATORIO AUX_RELATORIO { get; set; } = new BI7401B_AUX_RELATORIO();
        public class BI7401B_AUX_RELATORIO : VarBasis
        {
            /*"  03          LC02.*/
            public BI7401B_LC02 LC02 { get; set; } = new BI7401B_LC02();
            public class BI7401B_LC02 : VarBasis
            {
                /*"    10        FILLER              PIC  X(011)  VALUE             'BILHETE'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"BILHETE");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(013)  VALUE             'APOLICE      '.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"APOLICE      ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(004)  VALUE             'RAMO'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"RAMO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(007)  VALUE             'PRODUTO'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"PRODUTO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(011)  VALUE             'PONTO VENDA'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"PONTO VENDA");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(010)  VALUE             'DATA VENDA'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DATA VENDA");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(011)  VALUE             '     VALOR'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"     VALOR");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(010)  VALUE             'CANCELA  '.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"CANCELA  ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(040)  VALUE             'SEGURADO'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"SEGURADO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(015)  VALUE             'CGCCPF '.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"CGCCPF ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(015)  VALUE             'PROPOSTA'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"PROPOSTA");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(095)  VALUE             'MENSAGEM'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "95", "X(095)"), @"MENSAGEM");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(022)  VALUE  SPACES.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "22", "X(022)"), @"");
                /*"  03          LD02.*/
            }
            public BI7401B_LD02 LD02 { get; set; } = new BI7401B_LD02();
            public class BI7401B_LD02 : VarBasis
            {
                /*"    10        LD02-BILHETE        PIC  ZZZZZZZZZZ9.*/
                public IntBasis LD02_BILHETE { get; set; } = new IntBasis(new PIC("9", "11", "ZZZZZZZZZZ9."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-APOLICE        PIC  ZZZZZZZZZZZZ9.*/
                public IntBasis LD02_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "ZZZZZZZZZZZZ9."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-RAMO           PIC  ZZZ9.*/
                public IntBasis LD02_RAMO { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-PRODUTO        PIC  ZZZZZZ9.*/
                public IntBasis LD02_PRODUTO { get; set; } = new IntBasis(new PIC("9", "7", "ZZZZZZ9."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-AGEVENDA       PIC  ZZZZZZZZZZ9.*/
                public IntBasis LD02_AGEVENDA { get; set; } = new IntBasis(new PIC("9", "11", "ZZZZZZZZZZ9."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-DTVENDA        PIC  X(010).*/
                public StringBasis LD02_DTVENDA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-VALOR          PIC  ZZZ.ZZ9,99-.*/
                public DoubleBasis LD02_VALOR { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V99-."), 3);
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-DTCANCEL       PIC  X(010).*/
                public StringBasis LD02_DTCANCEL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-SEGURADO       PIC  X(040).*/
                public StringBasis LD02_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-CGCCPF         PIC  9(015).*/
                public IntBasis LD02_CGCCPF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-PROPOSTA       PIC  ZZZZZZZZZZZZZZ9.*/
                public IntBasis LD02_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "15", "ZZZZZZZZZZZZZZ9."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-MENSAGEM       PIC  X(095).*/
                public StringBasis LD02_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "95", "X(095)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(022)  VALUE  SPACES.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "22", "X(022)"), @"");
                /*"  03          WS02.*/
            }
            public BI7401B_WS02 WS02 { get; set; } = new BI7401B_WS02();
            public class BI7401B_WS02 : VarBasis
            {
                /*"    10        FILLER              PIC  X(010)  VALUE             'APOLICE = '.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"APOLICE = ");
                /*"    10        WS02-APOLICE        PIC  ZZZZZZZZZZZZ9.*/
                public IntBasis WS02_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "ZZZZZZZZZZZZ9."));
                /*"    10        FILLER              PIC  X(001)  VALUE  SPACES.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10        FILLER              PIC  X(010)  VALUE             'ENDOSSO = '.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"ENDOSSO = ");
                /*"    10        WS02-ENDOSSO        PIC  ZZZZZZZZ9.*/
                public IntBasis WS02_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZZZZ9."));
                /*"    10        FILLER              PIC  X(001)  VALUE  SPACES.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10        FILLER              PIC  X(010)  VALUE             'PARCELA = '.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"PARCELA = ");
                /*"    10        WS02-PARCELA        PIC  ZZZ9.*/
                public IntBasis WS02_PARCELA { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
                /*"    10        FILLER              PIC  X(001)  VALUE  SPACES.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10        FILLER              PIC  X(023)  VALUE             'ENDOSSO CANCELAMENTO = '.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"ENDOSSO CANCELAMENTO = ");
                /*"    10        WS02-NRENDOCA       PIC  ZZZZZZZZ9.*/
                public IntBasis WS02_NRENDOCA { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZZZZ9."));
                /*"    10        FILLER              PIC  X(004)  VALUE  SPACES.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
            }
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.BILHETE BILHETE { get; set; } = new Dclgens.BILHETE();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.CONVERSI CONVERSI { get; set; } = new Dclgens.CONVERSI();
        public Dclgens.MOVDEBCE MOVDEBCE { get; set; } = new Dclgens.MOVDEBCE();
        public Dclgens.RCAPS RCAPS { get; set; } = new Dclgens.RCAPS();
        public Dclgens.RCAPCOMP RCAPCOMP { get; set; } = new Dclgens.RCAPCOMP();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.PARCELAS PARCELAS { get; set; } = new Dclgens.PARCELAS();
        public Dclgens.PARCEHIS PARCEHIS { get; set; } = new Dclgens.PARCEHIS();
        public Dclgens.APOLICOB APOLICOB { get; set; } = new Dclgens.APOLICOB();
        public Dclgens.NUMERAES NUMERAES { get; set; } = new Dclgens.NUMERAES();
        public Dclgens.FONTES FONTES { get; set; } = new Dclgens.FONTES();
        public BI7401B_V0RELATORI V0RELATORI { get; set; } = new BI7401B_V0RELATORI();
        public BI7401B_V0RCAPCOMP V0RCAPCOMP { get; set; } = new BI7401B_V0RCAPCOMP();
        public BI7401B_V1RELATORI V1RELATORI { get; set; } = new BI7401B_V1RELATORI();
        public BI7401B_V2RELATORI V2RELATORI { get; set; } = new BI7401B_V2RELATORI();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SBI7401B_FILE_NAME_P, string SAIDA01_FILE_NAME_P, string SAIDA02_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SBI7401B.SetFile(SBI7401B_FILE_NAME_P);
                SAIDA01.SetFile(SAIDA01_FILE_NAME_P);
                SAIDA02.SetFile(SAIDA02_FILE_NAME_P);

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
            /*" -307- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", W.WABEND.WNR_EXEC_SQL);

            /*" -308- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -310- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -312- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -315- DISPLAY '----------------------------------' */
            _.Display($"----------------------------------");

            /*" -316- DISPLAY '                                  ' */
            _.Display($"                                  ");

            /*" -317- DISPLAY 'PROGRAMA EM EXECUCAO BI7401B      ' */
            _.Display($"PROGRAMA EM EXECUCAO BI7401B      ");

            /*" -318- DISPLAY '                                  ' */
            _.Display($"                                  ");

            /*" -325- DISPLAY 'VERSAO V.01 179.542 06/01/2020 ' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) ' AS ' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) */

            $"VERSAO V.01 179.542 06/01/2020 FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)} AS FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}"
            .Display();

            /*" -326- DISPLAY '----------------------------------' . */
            _.Display($"----------------------------------");

            /*" -329- DISPLAY ' ' . */
            _.Display($" ");

            /*" -332- PERFORM R0050-00-INICIO. */

            R0050_00_INICIO_SECTION();

            /*" -342- SORT SBI7401B ON ASCENDING KEY SOR-NRSEQ SOR-BILHETE SOR-NRRCAP INPUT PROCEDURE R0190-00-SELECIONA THRU R0190-99-SAIDA OUTPUT PROCEDURE R0300-00-PROCESSA-SORT THRU R0300-99-SAIDA. */
            SBI7401B.Sort("SOR-NRSEQ,SOR-BILHETE,SOR-NRRCAP", () => R0190_00_SELECIONA_SECTION(), () => R0300_00_PROCESSA_SORT_SECTION());

            /*" -346- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), W.WS_TIME);

            /*" -347- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

            /*" -348- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

            /*" -349- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

            /*" -350- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

            /*" -351- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

            /*" -351- DISPLAY 'FIM    BI7401B    ' WTIME-DAYR. */
            _.Display($"FIM    BI7401B    {W.FILLER_4.WTIME_DAYR}");

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -356- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -361- CLOSE SAIDA01 SAIDA02. */
            SAIDA01.Close();
            SAIDA02.Close();

            /*" -363- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -364- DISPLAY ' ' */
            _.Display($" ");

            /*" -365- DISPLAY 'BI7401B - FIM NORMAL' */
            _.Display($"BI7401B - FIM NORMAL");

            /*" -368- DISPLAY ' ' */
            _.Display($" ");

            /*" -368- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0050-00-INICIO-SECTION */
        private void R0050_00_INICIO_SECTION()
        {
            /*" -377- MOVE '0050' TO WNR-EXEC-SQL. */
            _.Move("0050", W.WABEND.WNR_EXEC_SQL);

            /*" -378- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), W.WS_TIME);

            /*" -379- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

            /*" -380- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

            /*" -381- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

            /*" -382- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

            /*" -383- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

            /*" -386- DISPLAY 'INICIO BI7401B    ' WTIME-DAYR. */
            _.Display($"INICIO BI7401B    {W.FILLER_4.WTIME_DAYR}");

            /*" -390- OPEN OUTPUT SAIDA01 SAIDA02. */
            SAIDA01.Open(REG_SAIDA01);
            SAIDA02.Open(REG_SAIDA02);

            /*" -393- PERFORM R0100-00-SELECT-SISTEMAS. */

            R0100_00_SELECT_SISTEMAS_SECTION();

            /*" -394- DISPLAY ' ' . */
            _.Display($" ");

            /*" -396- DISPLAY 'DATA DE MOVIMENTO ..... ' SISTEMAS-DATA-MOV-ABERTO. */
            _.Display($"DATA DE MOVIMENTO ..... {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -398- DISPLAY 'DATA DE MOVIMENTO - 01 ANO ...... ' V1SIST-DTMOVABE-1Y */
            _.Display($"DATA DE MOVIMENTO - 01 ANO ...... {V1SIST_DTMOVABE_1Y}");

            /*" -401- DISPLAY ' ' . */
            _.Display($" ");

            /*" -402- WRITE REG-SAIDA01 FROM LC02. */
            _.Move(AUX_RELATORIO.LC02.GetMoveValues(), REG_SAIDA01);

            SAIDA01.Write(REG_SAIDA01.GetMoveValues().ToString());

            /*" -404- WRITE REG-SAIDA02 FROM LC02. */
            _.Move(AUX_RELATORIO.LC02.GetMoveValues(), REG_SAIDA02);

            SAIDA02.Write(REG_SAIDA02.GetMoveValues().ToString());

            /*" -404- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-SECTION */
        private void R0100_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -417- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", W.WABEND.WNR_EXEC_SQL);

            /*" -426- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -430- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -431- DISPLAY 'R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)' */
                _.Display($"R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)");

                /*" -431- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -426- EXEC SQL SELECT DATA_MOV_ABERTO ,DATA_MOV_ABERTO - 1 YEAR INTO :SISTEMAS-DATA-MOV-ABERTO ,:V1SIST-DTMOVABE-1Y FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'CB' FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.V1SIST_DTMOVABE_1Y, V1SIST_DTMOVABE_1Y);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0190-00-SELECIONA-SECTION */
        private void R0190_00_SELECIONA_SECTION()
        {
            /*" -444- MOVE '0190' TO WNR-EXEC-SQL. */
            _.Move("0190", W.WABEND.WNR_EXEC_SQL);

            /*" -447- PERFORM R2190-00-TRATA-RCAPCOMP. */

            R2190_00_TRATA_RCAPCOMP_SECTION();

            /*" -450- PERFORM R2590-00-TRATA-BI16A. */

            R2590_00_TRATA_BI16A_SECTION();

            /*" -451- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), W.WS_TIME);

            /*" -452- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

            /*" -453- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

            /*" -454- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

            /*" -455- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

            /*" -456- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

            /*" -458- DISPLAY 'LEITURA RELATORI  ' WTIME-DAYR. */
            _.Display($"LEITURA RELATORI  {W.FILLER_4.WTIME_DAYR}");

            /*" -460- MOVE ZEROS TO GV-SORT LD-RELATORI. */
            _.Move(0, W.GV_SORT, W.LD_RELATORI);

            /*" -461- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", W.WFIM_MOVIMENTO);

            /*" -463- PERFORM R0200-00-DECLARE-RELATORI. */

            R0200_00_DECLARE_RELATORI_SECTION();

            /*" -465- PERFORM R0210-00-FETCH-RELATORI. */

            R0210_00_FETCH_RELATORI_SECTION();

            /*" -468- PERFORM R0220-00-PROCESSA-RELATORI UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!W.WFIM_MOVIMENTO.IsEmpty()))
            {

                R0220_00_PROCESSA_RELATORI_SECTION();
            }

            /*" -469- DISPLAY ' ' . */
            _.Display($" ");

            /*" -470- DISPLAY 'LIDOS RELATORI ............. ' LD-RELATORI. */
            _.Display($"LIDOS RELATORI ............. {W.LD_RELATORI}");

            /*" -471- DISPLAY 'GRAVADOS SORT .............. ' GV-SORT. */
            _.Display($"GRAVADOS SORT .............. {W.GV_SORT}");

            /*" -473- DISPLAY ' ' . */
            _.Display($" ");

            /*" -473- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0190_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-DECLARE-RELATORI-SECTION */
        private void R0200_00_DECLARE_RELATORI_SECTION()
        {
            /*" -486- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", W.WABEND.WNR_EXEC_SQL);

            /*" -503- PERFORM R0200_00_DECLARE_RELATORI_DB_DECLARE_1 */

            R0200_00_DECLARE_RELATORI_DB_DECLARE_1();

            /*" -505- PERFORM R0200_00_DECLARE_RELATORI_DB_OPEN_1 */

            R0200_00_DECLARE_RELATORI_DB_OPEN_1();

            /*" -509- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -510- DISPLAY 'R0200-00 - PROBLEMAS DECLARE (RELATORI)   ' */
                _.Display($"R0200-00 - PROBLEMAS DECLARE (RELATORI)   ");

                /*" -510- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0200-00-DECLARE-RELATORI-DB-DECLARE-1 */
        public void R0200_00_DECLARE_RELATORI_DB_DECLARE_1()
        {
            /*" -503- EXEC SQL DECLARE V0RELATORI CURSOR WITH HOLD FOR SELECT DATA_SOLICITACAO ,IDE_SISTEMA ,COD_RELATORIO ,QUANTIDADE ,RAMO_EMISSOR ,NUM_APOLICE ,NUM_TITULO ,SIT_REGISTRO ,IND_PREV_DEFINIT ,IND_ANAL_RESUMO FROM SEGUROS.RELATORIOS WHERE COD_RELATORIO = 'BI6401B1' AND SIT_REGISTRO = '1' AND RAMO_EMISSOR NOT IN (14,72) AND DATA_SOLICITACAO >= :V1SIST-DTMOVABE-1Y END-EXEC. */
            V0RELATORI = new BI7401B_V0RELATORI(true);
            string GetQuery_V0RELATORI()
            {
                var query = @$"SELECT DATA_SOLICITACAO 
							,IDE_SISTEMA 
							,COD_RELATORIO 
							,QUANTIDADE 
							,RAMO_EMISSOR 
							,NUM_APOLICE 
							,NUM_TITULO 
							,SIT_REGISTRO 
							,IND_PREV_DEFINIT 
							,IND_ANAL_RESUMO 
							FROM SEGUROS.RELATORIOS 
							WHERE COD_RELATORIO = 'BI6401B1' 
							AND SIT_REGISTRO = '1' 
							AND RAMO_EMISSOR NOT IN (14
							,72) 
							AND DATA_SOLICITACAO >= '{V1SIST_DTMOVABE_1Y}'";

                return query;
            }
            V0RELATORI.GetQueryEvent += GetQuery_V0RELATORI;

        }

        [StopWatch]
        /*" R0200-00-DECLARE-RELATORI-DB-OPEN-1 */
        public void R0200_00_DECLARE_RELATORI_DB_OPEN_1()
        {
            /*" -505- EXEC SQL OPEN V0RELATORI END-EXEC. */

            V0RELATORI.Open();

        }

        [StopWatch]
        /*" R2200-00-DECLARE-RCAPCOMP-DB-DECLARE-1 */
        public void R2200_00_DECLARE_RCAPCOMP_DB_DECLARE_1()
        {
            /*" -2243- EXEC SQL DECLARE V0RCAPCOMP CURSOR WITH HOLD FOR SELECT COD_FONTE ,NUM_RCAP ,NUM_RCAP_COMPLEMEN ,COUNT(*) FROM SEGUROS.RCAP_COMPLEMENTAR WHERE NUM_RCAP > 0 AND NUM_RCAP_COMPLEMEN = 0 AND SIT_REGISTRO = '0' GROUP BY COD_FONTE,NUM_RCAP,NUM_RCAP_COMPLEMEN HAVING COUNT(*) > 1 END-EXEC. */
            V0RCAPCOMP = new BI7401B_V0RCAPCOMP(false);
            string GetQuery_V0RCAPCOMP()
            {
                var query = @$"SELECT COD_FONTE 
							,NUM_RCAP 
							,NUM_RCAP_COMPLEMEN 
							,COUNT(*) 
							FROM SEGUROS.RCAP_COMPLEMENTAR 
							WHERE NUM_RCAP > 0 
							AND NUM_RCAP_COMPLEMEN = 0 
							AND SIT_REGISTRO = '0' 
							GROUP BY COD_FONTE
							,NUM_RCAP
							,NUM_RCAP_COMPLEMEN 
							HAVING COUNT(*) > 1";

                return query;
            }
            V0RCAPCOMP.GetQueryEvent += GetQuery_V0RCAPCOMP;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-FETCH-RELATORI-SECTION */
        private void R0210_00_FETCH_RELATORI_SECTION()
        {
            /*" -523- MOVE '0210' TO WNR-EXEC-SQL. */
            _.Move("0210", W.WABEND.WNR_EXEC_SQL);

            /*" -534- PERFORM R0210_00_FETCH_RELATORI_DB_FETCH_1 */

            R0210_00_FETCH_RELATORI_DB_FETCH_1();

            /*" -538- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -538- PERFORM R0210_00_FETCH_RELATORI_DB_CLOSE_1 */

                R0210_00_FETCH_RELATORI_DB_CLOSE_1();

                /*" -540- MOVE 'S' TO WFIM-MOVIMENTO */
                _.Move("S", W.WFIM_MOVIMENTO);

                /*" -542- GO TO R0210-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/ //GOTO
                return;
            }


            /*" -543- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -544- DISPLAY 'R0210-00 - PROBLEMAS FETCH   (RELATORI)   ' */
                _.Display($"R0210-00 - PROBLEMAS FETCH   (RELATORI)   ");

                /*" -547- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -550- ADD 1 TO LD-RELATORI. */
            W.LD_RELATORI.Value = W.LD_RELATORI + 1;

            /*" -552- MOVE LD-RELATORI TO AC-LIDOS. */
            _.Move(W.LD_RELATORI, W.AC_LIDOS);

            /*" -554- IF LD-PARTE2 EQUAL ZEROS OR LD-PARTE2 EQUAL 5000 */

            if (W.FILLER_0.LD_PARTE2 == 00 || W.FILLER_0.LD_PARTE2 == 5000)
            {

                /*" -555- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), W.WS_TIME);

                /*" -556- MOVE WS-HH-TIME TO WTIME-HORA */
                _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

                /*" -557- MOVE '.' TO WTIME-2PT1 */
                _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

                /*" -558- MOVE WS-MM-TIME TO WTIME-MINU */
                _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

                /*" -559- MOVE '.' TO WTIME-2PT2 */
                _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

                /*" -560- MOVE WS-SS-TIME TO WTIME-SEGU */
                _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

                /*" -561- DISPLAY 'LIDOS RELATORI     ' AC-LIDOS '    ' WTIME-DAYR. */

                $"LIDOS RELATORI     {W.AC_LIDOS}    {W.FILLER_4.WTIME_DAYR}"
                .Display();
            }


        }

        [StopWatch]
        /*" R0210-00-FETCH-RELATORI-DB-FETCH-1 */
        public void R0210_00_FETCH_RELATORI_DB_FETCH_1()
        {
            /*" -534- EXEC SQL FETCH V0RELATORI INTO :RELATORI-DATA-SOLICITACAO ,:RELATORI-IDE-SISTEMA ,:RELATORI-COD-RELATORIO ,:RELATORI-QUANTIDADE ,:RELATORI-RAMO-EMISSOR ,:RELATORI-NUM-APOLICE ,:RELATORI-NUM-TITULO ,:RELATORI-SIT-REGISTRO ,:RELATORI-IND-PREV-DEFINIT ,:RELATORI-IND-ANAL-RESUMO END-EXEC. */

            if (V0RELATORI.Fetch())
            {
                _.Move(V0RELATORI.RELATORI_DATA_SOLICITACAO, RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO);
                _.Move(V0RELATORI.RELATORI_IDE_SISTEMA, RELATORI.DCLRELATORIOS.RELATORI_IDE_SISTEMA);
                _.Move(V0RELATORI.RELATORI_COD_RELATORIO, RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO);
                _.Move(V0RELATORI.RELATORI_QUANTIDADE, RELATORI.DCLRELATORIOS.RELATORI_QUANTIDADE);
                _.Move(V0RELATORI.RELATORI_RAMO_EMISSOR, RELATORI.DCLRELATORIOS.RELATORI_RAMO_EMISSOR);
                _.Move(V0RELATORI.RELATORI_NUM_APOLICE, RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE);
                _.Move(V0RELATORI.RELATORI_NUM_TITULO, RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO);
                _.Move(V0RELATORI.RELATORI_SIT_REGISTRO, RELATORI.DCLRELATORIOS.RELATORI_SIT_REGISTRO);
                _.Move(V0RELATORI.RELATORI_IND_PREV_DEFINIT, RELATORI.DCLRELATORIOS.RELATORI_IND_PREV_DEFINIT);
                _.Move(V0RELATORI.RELATORI_IND_ANAL_RESUMO, RELATORI.DCLRELATORIOS.RELATORI_IND_ANAL_RESUMO);
            }

        }

        [StopWatch]
        /*" R0210-00-FETCH-RELATORI-DB-CLOSE-1 */
        public void R0210_00_FETCH_RELATORI_DB_CLOSE_1()
        {
            /*" -538- EXEC SQL CLOSE V0RELATORI END-EXEC */

            V0RELATORI.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/

        [StopWatch]
        /*" R0220-00-PROCESSA-RELATORI-SECTION */
        private void R0220_00_PROCESSA_RELATORI_SECTION()
        {
            /*" -574- MOVE '0220' TO WNR-EXEC-SQL. */
            _.Move("0220", W.WABEND.WNR_EXEC_SQL);

            /*" -576- MOVE 2 TO SOR-NRSEQ. */
            _.Move(2, REG_SBI7401B.SOR_NRSEQ);

            /*" -583- MOVE SPACES TO SOR-DTCANCEL SOR-SEGURADO SOR-DTVENDA SOR-TIPO-ENDOSSO SOR-IND-DEFINIT SOR-IND-RESUMO SOR-PARCELADO. */
            _.Move("", REG_SBI7401B.SOR_DTCANCEL, REG_SBI7401B.SOR_SEGURADO, REG_SBI7401B.SOR_DTVENDA, REG_SBI7401B.SOR_TIPO_ENDOSSO, REG_SBI7401B.SOR_IND_DEFINIT, REG_SBI7401B.SOR_IND_RESUMO, REG_SBI7401B.SOR_PARCELADO);

            /*" -600- MOVE ZEROS TO SOR-BILHETE SOR-APOLICE SOR-ENDOSSO SOR-PARCELA SOR-RAMO SOR-PRODUTO SOR-AGEVENDA SOR-VALOR SOR-CGCCPF SOR-BCOAVISO SOR-AGEAVISO SOR-NRAVISO SOR-FONTE SOR-NRRCAP SOR-OPERACAO SOR-PROPOSTA. */
            _.Move(0, REG_SBI7401B.SOR_BILHETE, REG_SBI7401B.SOR_APOLICE, REG_SBI7401B.SOR_ENDOSSO, REG_SBI7401B.SOR_PARCELA, REG_SBI7401B.SOR_RAMO, REG_SBI7401B.SOR_PRODUTO, REG_SBI7401B.SOR_AGEVENDA, REG_SBI7401B.SOR_VALOR, REG_SBI7401B.SOR_CGCCPF, REG_SBI7401B.SOR_BCOAVISO, REG_SBI7401B.SOR_AGEAVISO, REG_SBI7401B.SOR_NRAVISO, REG_SBI7401B.SOR_FONTE, REG_SBI7401B.SOR_NRRCAP, REG_SBI7401B.SOR_OPERACAO, REG_SBI7401B.SOR_PROPOSTA);

            /*" -602- MOVE RELATORI-NUM-APOLICE TO SOR-APOLICE. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE, REG_SBI7401B.SOR_APOLICE);

            /*" -604- MOVE RELATORI-RAMO-EMISSOR TO SOR-RAMO. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_RAMO_EMISSOR, REG_SBI7401B.SOR_RAMO);

            /*" -606- MOVE RELATORI-NUM-TITULO TO SOR-BILHETE. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO, REG_SBI7401B.SOR_BILHETE);

            /*" -608- MOVE RELATORI-IND-PREV-DEFINIT TO SOR-IND-DEFINIT. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_IND_PREV_DEFINIT, REG_SBI7401B.SOR_IND_DEFINIT);

            /*" -612- MOVE RELATORI-IND-ANAL-RESUMO TO SOR-IND-RESUMO. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_IND_ANAL_RESUMO, REG_SBI7401B.SOR_IND_RESUMO);

            /*" -614- PERFORM R0230-00-SELECT-APOLICES. */

            R0230_00_SELECT_APOLICES_SECTION();

            /*" -616- PERFORM R0240-00-SELECT-ENDOSSOS. */

            R0240_00_SELECT_ENDOSSOS_SECTION();

            /*" -619- PERFORM R0250-00-SELECT-ENDOSSOS. */

            R0250_00_SELECT_ENDOSSOS_SECTION();

            /*" -620- RELEASE REG-SBI7401B. */
            SBI7401B.Release(REG_SBI7401B);

            /*" -620- ADD 1 TO GV-SORT. */
            W.GV_SORT.Value = W.GV_SORT + 1;

            /*" -0- FLUXCONTROL_PERFORM R0220_90_LEITURA */

            R0220_90_LEITURA();

        }

        [StopWatch]
        /*" R0220-90-LEITURA */
        private void R0220_90_LEITURA(bool isPerform = false)
        {
            /*" -625- PERFORM R0210-00-FETCH-RELATORI. */

            R0210_00_FETCH_RELATORI_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_99_SAIDA*/

        [StopWatch]
        /*" R0230-00-SELECT-APOLICES-SECTION */
        private void R0230_00_SELECT_APOLICES_SECTION()
        {
            /*" -637- MOVE '0230' TO WNR-EXEC-SQL. */
            _.Move("0230", W.WABEND.WNR_EXEC_SQL);

            /*" -646- PERFORM R0230_00_SELECT_APOLICES_DB_SELECT_1 */

            R0230_00_SELECT_APOLICES_DB_SELECT_1();

            /*" -650- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -652- MOVE ZEROS TO SOR-PRODUTO */
                _.Move(0, REG_SBI7401B.SOR_PRODUTO);

                /*" -653- ELSE */
            }
            else
            {


                /*" -654- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -655- DISPLAY 'R0230-00 - PROBLEMAS NO SELECT(APOLICES)' */
                    _.Display($"R0230-00 - PROBLEMAS NO SELECT(APOLICES)");

                    /*" -656- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -657- ELSE */
                }
                else
                {


                    /*" -659- MOVE APOLICES-COD-MODALIDADE TO SOR-MODALIDA */
                    _.Move(APOLICES.DCLAPOLICES.APOLICES_COD_MODALIDADE, REG_SBI7401B.SOR_MODALIDA);

                    /*" -660- MOVE APOLICES-COD-PRODUTO TO SOR-PRODUTO. */
                    _.Move(APOLICES.DCLAPOLICES.APOLICES_COD_PRODUTO, REG_SBI7401B.SOR_PRODUTO);
                }

            }


        }

        [StopWatch]
        /*" R0230-00-SELECT-APOLICES-DB-SELECT-1 */
        public void R0230_00_SELECT_APOLICES_DB_SELECT_1()
        {
            /*" -646- EXEC SQL SELECT COD_MODALIDADE ,COD_PRODUTO INTO :APOLICES-COD-MODALIDADE ,:APOLICES-COD-PRODUTO FROM SEGUROS.APOLICES WHERE NUM_BILHETE = :RELATORI-NUM-TITULO FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0230_00_SELECT_APOLICES_DB_SELECT_1_Query1 = new R0230_00_SELECT_APOLICES_DB_SELECT_1_Query1()
            {
                RELATORI_NUM_TITULO = RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO.ToString(),
            };

            var executed_1 = R0230_00_SELECT_APOLICES_DB_SELECT_1_Query1.Execute(r0230_00_SELECT_APOLICES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICES_COD_MODALIDADE, APOLICES.DCLAPOLICES.APOLICES_COD_MODALIDADE);
                _.Move(executed_1.APOLICES_COD_PRODUTO, APOLICES.DCLAPOLICES.APOLICES_COD_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0230_99_SAIDA*/

        [StopWatch]
        /*" R0240-00-SELECT-ENDOSSOS-SECTION */
        private void R0240_00_SELECT_ENDOSSOS_SECTION()
        {
            /*" -672- MOVE '0240' TO WNR-EXEC-SQL. */
            _.Move("0240", W.WABEND.WNR_EXEC_SQL);

            /*" -680- PERFORM R0240_00_SELECT_ENDOSSOS_DB_SELECT_1 */

            R0240_00_SELECT_ENDOSSOS_DB_SELECT_1();

            /*" -684- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -686- MOVE SPACES TO SOR-TIPO-ENDOSSO */
                _.Move("", REG_SBI7401B.SOR_TIPO_ENDOSSO);

                /*" -687- ELSE */
            }
            else
            {


                /*" -688- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -689- DISPLAY 'R0240-00 - PROBLEMAS NO SELECT(ENDOSSOS)' */
                    _.Display($"R0240-00 - PROBLEMAS NO SELECT(ENDOSSOS)");

                    /*" -690- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -691- ELSE */
                }
                else
                {


                    /*" -692- MOVE '5' TO SOR-TIPO-ENDOSSO. */
                    _.Move("5", REG_SBI7401B.SOR_TIPO_ENDOSSO);
                }

            }


        }

        [StopWatch]
        /*" R0240-00-SELECT-ENDOSSOS-DB-SELECT-1 */
        public void R0240_00_SELECT_ENDOSSOS_DB_SELECT_1()
        {
            /*" -680- EXEC SQL SELECT COD_PRODUTO INTO :ENDOSSOS-COD-PRODUTO FROM SEGUROS.ENDOSSOS WHERE NUM_APOLICE = :RELATORI-NUM-APOLICE AND TIPO_ENDOSSO IN ( '3' , '5' ) FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0240_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 = new R0240_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1()
            {
                RELATORI_NUM_APOLICE = RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0240_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1.Execute(r0240_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDOSSOS_COD_PRODUTO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0240_99_SAIDA*/

        [StopWatch]
        /*" R0250-00-SELECT-ENDOSSOS-SECTION */
        private void R0250_00_SELECT_ENDOSSOS_SECTION()
        {
            /*" -704- MOVE '0250' TO WNR-EXEC-SQL. */
            _.Move("0250", W.WABEND.WNR_EXEC_SQL);

            /*" -711- PERFORM R0250_00_SELECT_ENDOSSOS_DB_SELECT_1 */

            R0250_00_SELECT_ENDOSSOS_DB_SELECT_1();

            /*" -715- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -717- MOVE SPACES TO SOR-PARCELADO */
                _.Move("", REG_SBI7401B.SOR_PARCELADO);

                /*" -718- ELSE */
            }
            else
            {


                /*" -719- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -720- DISPLAY 'R0250-00 - PROBLEMAS NO SELECT(ENDOSSOS)' */
                    _.Display($"R0250-00 - PROBLEMAS NO SELECT(ENDOSSOS)");

                    /*" -721- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -722- ELSE */
                }
                else
                {


                    /*" -723- IF VIND-NULL01 LESS ZEROS */

                    if (VIND_NULL01 < 00)
                    {

                        /*" -725- MOVE SPACES TO SOR-PARCELADO */
                        _.Move("", REG_SBI7401B.SOR_PARCELADO);

                        /*" -726- ELSE */
                    }
                    else
                    {


                        /*" -727- IF HOST-COUNT NOT EQUAL 1 */

                        if (HOST_COUNT != 1)
                        {

                            /*" -728- MOVE 'P' TO SOR-PARCELADO. */
                            _.Move("P", REG_SBI7401B.SOR_PARCELADO);
                        }

                    }

                }

            }


        }

        [StopWatch]
        /*" R0250-00-SELECT-ENDOSSOS-DB-SELECT-1 */
        public void R0250_00_SELECT_ENDOSSOS_DB_SELECT_1()
        {
            /*" -711- EXEC SQL SELECT COUNT(*) INTO :HOST-COUNT:VIND-NULL01 FROM SEGUROS.ENDOSSOS WHERE NUM_APOLICE = :RELATORI-NUM-APOLICE AND TIPO_ENDOSSO NOT IN ( '3' , '4' , '5' ) WITH UR END-EXEC. */

            var r0250_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 = new R0250_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1()
            {
                RELATORI_NUM_APOLICE = RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0250_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1.Execute(r0250_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_COUNT, HOST_COUNT);
                _.Move(executed_1.VIND_NULL01, VIND_NULL01);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-PROCESSA-SORT-SECTION */
        private void R0300_00_PROCESSA_SORT_SECTION()
        {
            /*" -741- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", W.WABEND.WNR_EXEC_SQL);

            /*" -742- MOVE SPACES TO WFIM-SORT. */
            _.Move("", W.WFIM_SORT);

            /*" -744- PERFORM R0310-00-LER-SORT. */

            R0310_00_LER_SORT_SECTION();

            /*" -745- IF WFIM-SORT NOT EQUAL SPACES */

            if (!W.WFIM_SORT.IsEmpty())
            {

                /*" -748- GO TO R0300-90-DISPLAY. */

                R0300_90_DISPLAY(); //GOTO
                return;
            }


            /*" -749- PERFORM R0320-00-PROCESSA-SORT UNTIL WFIM-SORT NOT EQUAL SPACES. */

            while (!(!W.WFIM_SORT.IsEmpty()))
            {

                R0320_00_PROCESSA_SORT_SECTION();
            }

            /*" -0- FLUXCONTROL_PERFORM R0300_90_DISPLAY */

            R0300_90_DISPLAY();

        }

        [StopWatch]
        /*" R0300-90-DISPLAY */
        private void R0300_90_DISPLAY(bool isPerform = false)
        {
            /*" -755- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -759- DISPLAY ' ' . */
            _.Display($" ");

            /*" -760- DISPLAY 'LIDOS SORT ................ ' LD-SORT */
            _.Display($"LIDOS SORT ................ {W.LD_SORT}");

            /*" -761- DISPLAY 'TRATA RCAPS ............... ' TT-RCAPS */
            _.Display($"TRATA RCAPS ............... {W.TT_RCAPS}");

            /*" -762- DISPLAY ' ' . */
            _.Display($" ");

            /*" -763- DISPLAY 'ENDOSSO CANCELAMENTO ....... ' AC-ENDOSSO. */
            _.Display($"ENDOSSO CANCELAMENTO ....... {W.AC_ENDOSSO}");

            /*" -764- DISPLAY 'BILHETE PARCELADO .......... ' AC-PARCELADO. */
            _.Display($"BILHETE PARCELADO .......... {W.AC_PARCELADO}");

            /*" -765- DISPLAY 'DEVOLVIDO .................. ' AC-DEVOLVIDO. */
            _.Display($"DEVOLVIDO .................. {W.AC_DEVOLVIDO}");

            /*" -766- DISPLAY 'ATUALIZADO ................. ' AC-ATUAL. */
            _.Display($"ATUALIZADO ................. {W.AC_ATUAL}");

            /*" -767- DISPLAY 'ALTERA SITUACAO ............ ' AC-UPDATE. */
            _.Display($"ALTERA SITUACAO ............ {W.AC_UPDATE}");

            /*" -768- DISPLAY ' ' . */
            _.Display($" ");

            /*" -769- DISPLAY 'SEM    RELATORI ............ ' NT-RELATORI. */
            _.Display($"SEM    RELATORI ............ {W.NT_RELATORI}");

            /*" -770- DISPLAY 'ALTERA RELATORI ............ ' UP-RELATORI. */
            _.Display($"ALTERA RELATORI ............ {W.UP_RELATORI}");

            /*" -771- DISPLAY ' ' . */
            _.Display($" ");

            /*" -772- DISPLAY 'SEM    BILHETE ............. ' NT-BILHETE. */
            _.Display($"SEM    BILHETE ............. {W.NT_BILHETE}");

            /*" -773- DISPLAY 'ALTERA BILHETE ............. ' UP-BILHETE. */
            _.Display($"ALTERA BILHETE ............. {W.UP_BILHETE}");

            /*" -774- DISPLAY ' ' . */
            _.Display($" ");

            /*" -775- DISPLAY 'ALTERA RCAPS ............... ' UP-RCAPS. */
            _.Display($"ALTERA RCAPS ............... {W.UP_RCAPS}");

            /*" -776- DISPLAY ' ' . */
            _.Display($" ");

            /*" -777- DISPLAY 'INSERE ENDOSSOS ............ ' IN-ENDOSSOS. */
            _.Display($"INSERE ENDOSSOS ............ {W.IN_ENDOSSOS}");

            /*" -778- DISPLAY 'INSERT APOLICOB ........... ' IN-APOLICOB. */
            _.Display($"INSERT APOLICOB ........... {W.IN_APOLICOB}");

            /*" -779- DISPLAY ' ' . */
            _.Display($" ");

            /*" -780- DISPLAY 'GRAVADOS ARQUIVO1 .......... ' GV-ARQUIVO01. */
            _.Display($"GRAVADOS ARQUIVO1 .......... {W.GV_ARQUIVO01}");

            /*" -781- DISPLAY 'GRAVADOS ARQUIVO2 .......... ' GV-ARQUIVO02. */
            _.Display($"GRAVADOS ARQUIVO2 .......... {W.GV_ARQUIVO02}");

            /*" -781- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0310-00-LER-SORT-SECTION */
        private void R0310_00_LER_SORT_SECTION()
        {
            /*" -794- MOVE '0310' TO WNR-EXEC-SQL. */
            _.Move("0310", W.WABEND.WNR_EXEC_SQL);

            /*" -796- RETURN SBI7401B AT END */
            try
            {
                SBI7401B.Return(REG_SBI7401B, () =>
                {

                    /*" -797- MOVE 'S' TO WFIM-SORT */
                    _.Move("S", W.WFIM_SORT);

                    /*" -800- GO TO R0310-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/ //GOTO
                    return;

                });
            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -803- ADD 1 TO LD-SORT. */
            W.LD_SORT.Value = W.LD_SORT + 1;

            /*" -805- MOVE LD-SORT TO AC-LIDOS. */
            _.Move(W.LD_SORT, W.AC_LIDOS);

            /*" -807- IF LD-PARTE2 EQUAL ZEROS OR LD-PARTE2 EQUAL 5000 */

            if (W.FILLER_0.LD_PARTE2 == 00 || W.FILLER_0.LD_PARTE2 == 5000)
            {

                /*" -808- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), W.WS_TIME);

                /*" -809- MOVE WS-HH-TIME TO WTIME-HORA */
                _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

                /*" -810- MOVE '.' TO WTIME-2PT1 */
                _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

                /*" -811- MOVE WS-MM-TIME TO WTIME-MINU */
                _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

                /*" -812- MOVE '.' TO WTIME-2PT2 */
                _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

                /*" -813- MOVE WS-SS-TIME TO WTIME-SEGU */
                _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

                /*" -814- DISPLAY 'LIDOS SORT         ' AC-LIDOS '    ' WTIME-DAYR. */

                $"LIDOS SORT         {W.AC_LIDOS}    {W.FILLER_4.WTIME_DAYR}"
                .Display();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/

        [StopWatch]
        /*" R0320-00-PROCESSA-SORT-SECTION */
        private void R0320_00_PROCESSA_SORT_SECTION()
        {
            /*" -827- MOVE '0320' TO WNR-EXEC-SQL. */
            _.Move("0320", W.WABEND.WNR_EXEC_SQL);

            /*" -830- MOVE SPACES TO LD02-MENSAGEM. */
            _.Move("", AUX_RELATORIO.LD02.LD02_MENSAGEM);

            /*" -831- IF SOR-NRSEQ EQUAL 1 */

            if (REG_SBI7401B.SOR_NRSEQ == 1)
            {

                /*" -832- ADD 1 TO TT-RCAPS */
                W.TT_RCAPS.Value = W.TT_RCAPS + 1;

                /*" -833- PERFORM R2500-00-TRATA-RCAPS */

                R2500_00_TRATA_RCAPS_SECTION();

                /*" -836- GO TO R0320-90-LEITURA. */

                R0320_90_LEITURA(); //GOTO
                return;
            }


            /*" -837- IF SOR-NRSEQ EQUAL 3 */

            if (REG_SBI7401B.SOR_NRSEQ == 3)
            {

                /*" -838- PERFORM R2700-00-VERIFICA-BI16A */

                R2700_00_VERIFICA_BI16A_SECTION();

                /*" -841- GO TO R0320-90-LEITURA. */

                R0320_90_LEITURA(); //GOTO
                return;
            }


            /*" -842- IF SOR-TIPO-ENDOSSO EQUAL '5' */

            if (REG_SBI7401B.SOR_TIPO_ENDOSSO == "5")
            {

                /*" -843- ADD 1 TO AC-ENDOSSO */
                W.AC_ENDOSSO.Value = W.AC_ENDOSSO + 1;

                /*" -845- MOVE 'E' TO RELATORI-IND-PREV-DEFINIT */
                _.Move("E", RELATORI.DCLRELATORIOS.RELATORI_IND_PREV_DEFINIT);

                /*" -847- MOVE 'E' TO RELATORI-IND-ANAL-RESUMO */
                _.Move("E", RELATORI.DCLRELATORIOS.RELATORI_IND_ANAL_RESUMO);

                /*" -848- PERFORM R1020-00-UPDATE-V0RELATORI */

                R1020_00_UPDATE_V0RELATORI_SECTION();

                /*" -851- GO TO R0320-90-LEITURA. */

                R0320_90_LEITURA(); //GOTO
                return;
            }


            /*" -852- IF SOR-PARCELADO NOT EQUAL SPACES */

            if (!REG_SBI7401B.SOR_PARCELADO.IsEmpty())
            {

                /*" -853- ADD 1 TO AC-PARCELADO */
                W.AC_PARCELADO.Value = W.AC_PARCELADO + 1;

                /*" -855- MOVE 'P' TO RELATORI-IND-PREV-DEFINIT */
                _.Move("P", RELATORI.DCLRELATORIOS.RELATORI_IND_PREV_DEFINIT);

                /*" -857- MOVE 'P' TO RELATORI-IND-ANAL-RESUMO */
                _.Move("P", RELATORI.DCLRELATORIOS.RELATORI_IND_ANAL_RESUMO);

                /*" -858- PERFORM R1020-00-UPDATE-V0RELATORI */

                R1020_00_UPDATE_V0RELATORI_SECTION();

                /*" -861- GO TO R0320-90-LEITURA. */

                R0320_90_LEITURA(); //GOTO
                return;
            }


            /*" -863- MOVE SOR-APOLICE TO RELATORI-NUM-APOLICE. */
            _.Move(REG_SBI7401B.SOR_APOLICE, RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE);

            /*" -865- MOVE SOR-RAMO TO RELATORI-RAMO-EMISSOR. */
            _.Move(REG_SBI7401B.SOR_RAMO, RELATORI.DCLRELATORIOS.RELATORI_RAMO_EMISSOR);

            /*" -869- MOVE SOR-BILHETE TO RELATORI-NUM-TITULO. */
            _.Move(REG_SBI7401B.SOR_BILHETE, RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO);

            /*" -871- PERFORM R0325-00-SELECT-PARCELAS. */

            R0325_00_SELECT_PARCELAS_SECTION();

            /*" -872- IF HOST-COUNT GREATER 1 */

            if (HOST_COUNT > 1)
            {

                /*" -873- ADD 1 TO AC-PARCELADO */
                W.AC_PARCELADO.Value = W.AC_PARCELADO + 1;

                /*" -875- MOVE 'P' TO RELATORI-IND-PREV-DEFINIT */
                _.Move("P", RELATORI.DCLRELATORIOS.RELATORI_IND_PREV_DEFINIT);

                /*" -877- MOVE 'P' TO RELATORI-IND-ANAL-RESUMO */
                _.Move("P", RELATORI.DCLRELATORIOS.RELATORI_IND_ANAL_RESUMO);

                /*" -878- PERFORM R1020-00-UPDATE-V0RELATORI */

                R1020_00_UPDATE_V0RELATORI_SECTION();

                /*" -881- GO TO R0320-90-LEITURA. */

                R0320_90_LEITURA(); //GOTO
                return;
            }


            /*" -884- PERFORM R0330-00-SELECT-BILHETE. */

            R0330_00_SELECT_BILHETE_SECTION();

            /*" -885- IF LD02-MENSAGEM EQUAL 'RCAP DEVOLVIDO' */

            if (AUX_RELATORIO.LD02.LD02_MENSAGEM == "RCAP DEVOLVIDO")
            {

                /*" -886- IF RELATORI-IND-PREV-DEFINIT EQUAL 'N' */

                if (RELATORI.DCLRELATORIOS.RELATORI_IND_PREV_DEFINIT == "N")
                {

                    /*" -887- ADD 1 TO AC-DEVOLVIDO */
                    W.AC_DEVOLVIDO.Value = W.AC_DEVOLVIDO + 1;

                    /*" -888- GO TO R0320-90-LEITURA */

                    R0320_90_LEITURA(); //GOTO
                    return;

                    /*" -889- ELSE */
                }
                else
                {


                    /*" -890- IF RELATORI-IND-PREV-DEFINIT EQUAL 'S' */

                    if (RELATORI.DCLRELATORIOS.RELATORI_IND_PREV_DEFINIT == "S")
                    {

                        /*" -891- ADD 1 TO AC-ATUAL */
                        W.AC_ATUAL.Value = W.AC_ATUAL + 1;

                        /*" -892- GO TO R0320-90-LEITURA */

                        R0320_90_LEITURA(); //GOTO
                        return;

                        /*" -893- ELSE */
                    }
                    else
                    {


                        /*" -894- ADD 1 TO AC-UPDATE */
                        W.AC_UPDATE.Value = W.AC_UPDATE + 1;

                        /*" -896- MOVE 'N' TO RELATORI-IND-PREV-DEFINIT */
                        _.Move("N", RELATORI.DCLRELATORIOS.RELATORI_IND_PREV_DEFINIT);

                        /*" -898- MOVE 'N' TO RELATORI-IND-ANAL-RESUMO */
                        _.Move("N", RELATORI.DCLRELATORIOS.RELATORI_IND_ANAL_RESUMO);

                        /*" -899- PERFORM R1020-00-UPDATE-V0RELATORI */

                        R1020_00_UPDATE_V0RELATORI_SECTION();

                        /*" -900- GO TO R0320-90-LEITURA */

                        R0320_90_LEITURA(); //GOTO
                        return;

                        /*" -901- ELSE */
                    }

                }

            }
            else
            {


                /*" -902- IF LD02-MENSAGEM NOT EQUAL SPACES */

                if (!AUX_RELATORIO.LD02.LD02_MENSAGEM.IsEmpty())
                {

                    /*" -903- PERFORM R2000-00-GRAVA-ARQUIVO01 */

                    R2000_00_GRAVA_ARQUIVO01_SECTION();

                    /*" -906- GO TO R0320-90-LEITURA. */

                    R0320_90_LEITURA(); //GOTO
                    return;
                }

            }


            /*" -906- PERFORM R1000-00-ATUALIZA-REGISTRO. */

            R1000_00_ATUALIZA_REGISTRO_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0320_90_LEITURA */

            R0320_90_LEITURA();

        }

        [StopWatch]
        /*" R0320-90-LEITURA */
        private void R0320_90_LEITURA(bool isPerform = false)
        {
            /*" -911- PERFORM R0310-00-LER-SORT. */

            R0310_00_LER_SORT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0320_99_SAIDA*/

        [StopWatch]
        /*" R0325-00-SELECT-PARCELAS-SECTION */
        private void R0325_00_SELECT_PARCELAS_SECTION()
        {
            /*" -923- MOVE '0325' TO WNR-EXEC-SQL. */
            _.Move("0325", W.WABEND.WNR_EXEC_SQL);

            /*" -930- PERFORM R0325_00_SELECT_PARCELAS_DB_SELECT_1 */

            R0325_00_SELECT_PARCELAS_DB_SELECT_1();

            /*" -934- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -936- MOVE ZEROS TO HOST-COUNT */
                _.Move(0, HOST_COUNT);

                /*" -937- ELSE */
            }
            else
            {


                /*" -938- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -939- DISPLAY 'R0325-00 - PROBLEMAS NO SELECT(PARCELAS)' */
                    _.Display($"R0325-00 - PROBLEMAS NO SELECT(PARCELAS)");

                    /*" -940- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -941- ELSE */
                }
                else
                {


                    /*" -942- IF VIND-NULL01 LESS ZEROS */

                    if (VIND_NULL01 < 00)
                    {

                        /*" -943- MOVE ZEROS TO HOST-COUNT. */
                        _.Move(0, HOST_COUNT);
                    }

                }

            }


        }

        [StopWatch]
        /*" R0325-00-SELECT-PARCELAS-DB-SELECT-1 */
        public void R0325_00_SELECT_PARCELAS_DB_SELECT_1()
        {
            /*" -930- EXEC SQL SELECT COUNT(*) INTO :HOST-COUNT:VIND-NULL01 FROM SEGUROS.PARCELAS WHERE NUM_APOLICE = :RELATORI-NUM-APOLICE AND NUM_ENDOSSO = 0 WITH UR END-EXEC. */

            var r0325_00_SELECT_PARCELAS_DB_SELECT_1_Query1 = new R0325_00_SELECT_PARCELAS_DB_SELECT_1_Query1()
            {
                RELATORI_NUM_APOLICE = RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0325_00_SELECT_PARCELAS_DB_SELECT_1_Query1.Execute(r0325_00_SELECT_PARCELAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_COUNT, HOST_COUNT);
                _.Move(executed_1.VIND_NULL01, VIND_NULL01);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0325_99_SAIDA*/

        [StopWatch]
        /*" R0330-00-SELECT-BILHETE-SECTION */
        private void R0330_00_SELECT_BILHETE_SECTION()
        {
            /*" -956- MOVE '0330' TO WNR-EXEC-SQL. */
            _.Move("0330", W.WABEND.WNR_EXEC_SQL);

            /*" -987- PERFORM R0330_00_SELECT_BILHETE_DB_SELECT_1 */

            R0330_00_SELECT_BILHETE_DB_SELECT_1();

            /*" -991- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -993- MOVE 'BILHETE NAO EMITIDO                   ' TO LD02-MENSAGEM */
                _.Move("BILHETE NAO EMITIDO                   ", AUX_RELATORIO.LD02.LD02_MENSAGEM);

                /*" -995- GO TO R0330-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0330_99_SAIDA*/ //GOTO
                return;
            }


            /*" -996- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -997- DISPLAY 'R0330-00 - PROBLEMAS NO SELECT(BILHETE)' */
                _.Display($"R0330-00 - PROBLEMAS NO SELECT(BILHETE)");

                /*" -1000- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1002- MOVE BILHETE-NUM-APOLICE TO SOR-APOLICE. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE, REG_SBI7401B.SOR_APOLICE);

            /*" -1004- MOVE BILHETE-RAMO TO SOR-RAMO. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_RAMO, REG_SBI7401B.SOR_RAMO);

            /*" -1006- MOVE BILHETE-NUM-BILHETE TO SOR-BILHETE. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE, REG_SBI7401B.SOR_BILHETE);

            /*" -1008- MOVE BILHETE-AGE-COBRANCA TO SOR-AGEVENDA. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_AGE_COBRANCA, REG_SBI7401B.SOR_AGEVENDA);

            /*" -1010- MOVE BILHETE-VAL-RCAP TO SOR-VALOR. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_VAL_RCAP, REG_SBI7401B.SOR_VALOR);

            /*" -1012- MOVE BILHETE-DATA-VENDA TO SOR-DTVENDA. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_DATA_VENDA, REG_SBI7401B.SOR_DTVENDA);

            /*" -1014- MOVE CLIENTES-NOME-RAZAO TO SOR-SEGURADO. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, REG_SBI7401B.SOR_SEGURADO);

            /*" -1017- MOVE CLIENTES-CGCCPF TO SOR-CGCCPF. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, REG_SBI7401B.SOR_CGCCPF);

            /*" -1018- IF VIND-NULL01 LESS ZEROS */

            if (VIND_NULL01 < 00)
            {

                /*" -1021- MOVE SISTEMAS-DATA-MOV-ABERTO TO BILHETE-DATA-CANCELAMENTO SOR-DTCANCEL */
                _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, BILHETE.DCLBILHETE.BILHETE_DATA_CANCELAMENTO, REG_SBI7401B.SOR_DTCANCEL);

                /*" -1022- ELSE */
            }
            else
            {


                /*" -1026- MOVE BILHETE-DATA-CANCELAMENTO TO SOR-DTCANCEL. */
                _.Move(BILHETE.DCLBILHETE.BILHETE_DATA_CANCELAMENTO, REG_SBI7401B.SOR_DTCANCEL);
            }


            /*" -1026- PERFORM R0335-00-SELECT-CONVERSI. */

            R0335_00_SELECT_CONVERSI_SECTION();

        }

        [StopWatch]
        /*" R0330-00-SELECT-BILHETE-DB-SELECT-1 */
        public void R0330_00_SELECT_BILHETE_DB_SELECT_1()
        {
            /*" -987- EXEC SQL SELECT A.NUM_BILHETE ,A.NUM_APOLICE ,A.FONTE ,A.AGE_COBRANCA ,A.VAL_RCAP ,A.RAMO ,A.DATA_VENDA ,A.SITUACAO ,A.TIP_CANCELAMENTO ,A.DATA_CANCELAMENTO ,UCASE(C.NOME_RAZAO) ,C.CGCCPF INTO :BILHETE-NUM-BILHETE ,:BILHETE-NUM-APOLICE ,:BILHETE-FONTE ,:BILHETE-AGE-COBRANCA ,:BILHETE-VAL-RCAP ,:BILHETE-RAMO ,:BILHETE-DATA-VENDA ,:BILHETE-SITUACAO ,:BILHETE-TIP-CANCELAMENTO ,:BILHETE-DATA-CANCELAMENTO:VIND-NULL01 ,:CLIENTES-NOME-RAZAO ,:CLIENTES-CGCCPF FROM SEGUROS.BILHETE A ,SEGUROS.CLIENTES C WHERE A.NUM_BILHETE = :RELATORI-NUM-TITULO AND C.COD_CLIENTE = A.COD_CLIENTE FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0330_00_SELECT_BILHETE_DB_SELECT_1_Query1 = new R0330_00_SELECT_BILHETE_DB_SELECT_1_Query1()
            {
                RELATORI_NUM_TITULO = RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO.ToString(),
            };

            var executed_1 = R0330_00_SELECT_BILHETE_DB_SELECT_1_Query1.Execute(r0330_00_SELECT_BILHETE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.BILHETE_NUM_BILHETE, BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE);
                _.Move(executed_1.BILHETE_NUM_APOLICE, BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE);
                _.Move(executed_1.BILHETE_FONTE, BILHETE.DCLBILHETE.BILHETE_FONTE);
                _.Move(executed_1.BILHETE_AGE_COBRANCA, BILHETE.DCLBILHETE.BILHETE_AGE_COBRANCA);
                _.Move(executed_1.BILHETE_VAL_RCAP, BILHETE.DCLBILHETE.BILHETE_VAL_RCAP);
                _.Move(executed_1.BILHETE_RAMO, BILHETE.DCLBILHETE.BILHETE_RAMO);
                _.Move(executed_1.BILHETE_DATA_VENDA, BILHETE.DCLBILHETE.BILHETE_DATA_VENDA);
                _.Move(executed_1.BILHETE_SITUACAO, BILHETE.DCLBILHETE.BILHETE_SITUACAO);
                _.Move(executed_1.BILHETE_TIP_CANCELAMENTO, BILHETE.DCLBILHETE.BILHETE_TIP_CANCELAMENTO);
                _.Move(executed_1.BILHETE_DATA_CANCELAMENTO, BILHETE.DCLBILHETE.BILHETE_DATA_CANCELAMENTO);
                _.Move(executed_1.VIND_NULL01, VIND_NULL01);
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(executed_1.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0330_99_SAIDA*/

        [StopWatch]
        /*" R0335-00-SELECT-CONVERSI-SECTION */
        private void R0335_00_SELECT_CONVERSI_SECTION()
        {
            /*" -1039- MOVE '0335' TO WNR-EXEC-SQL. */
            _.Move("0335", W.WABEND.WNR_EXEC_SQL);

            /*" -1050- PERFORM R0335_00_SELECT_CONVERSI_DB_SELECT_1 */

            R0335_00_SELECT_CONVERSI_DB_SELECT_1();

            /*" -1054- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1055- MOVE ZEROS TO SOR-PROPOSTA */
                _.Move(0, REG_SBI7401B.SOR_PROPOSTA);

                /*" -1056- ELSE */
            }
            else
            {


                /*" -1057- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1058- DISPLAY 'R0335-00 - PROBLEMAS NO SELECT(CONVERSI)' */
                    _.Display($"R0335-00 - PROBLEMAS NO SELECT(CONVERSI)");

                    /*" -1059- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1060- ELSE */
                }
                else
                {


                    /*" -1064- MOVE CONVERSI-NUM-PROPOSTA-SIVPF TO SOR-PROPOSTA. */
                    _.Move(CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF, REG_SBI7401B.SOR_PROPOSTA);
                }

            }


            /*" -1064- PERFORM R0340-00-SELECT-MOVDEBCE. */

            R0340_00_SELECT_MOVDEBCE_SECTION();

        }

        [StopWatch]
        /*" R0335-00-SELECT-CONVERSI-DB-SELECT-1 */
        public void R0335_00_SELECT_CONVERSI_DB_SELECT_1()
        {
            /*" -1050- EXEC SQL SELECT NUM_PROPOSTA_SIVPF ,NUM_SICOB ,COD_PRODUTO_SIVPF INTO :CONVERSI-NUM-PROPOSTA-SIVPF ,:CONVERSI-NUM-SICOB ,:CONVERSI-COD-PRODUTO-SIVPF FROM SEGUROS.CONVERSAO_SICOB WHERE NUM_SICOB = :BILHETE-NUM-BILHETE FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0335_00_SELECT_CONVERSI_DB_SELECT_1_Query1 = new R0335_00_SELECT_CONVERSI_DB_SELECT_1_Query1()
            {
                BILHETE_NUM_BILHETE = BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE.ToString(),
            };

            var executed_1 = R0335_00_SELECT_CONVERSI_DB_SELECT_1_Query1.Execute(r0335_00_SELECT_CONVERSI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONVERSI_NUM_PROPOSTA_SIVPF, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF);
                _.Move(executed_1.CONVERSI_NUM_SICOB, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_SICOB);
                _.Move(executed_1.CONVERSI_COD_PRODUTO_SIVPF, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_COD_PRODUTO_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0335_99_SAIDA*/

        [StopWatch]
        /*" R0340-00-SELECT-MOVDEBCE-SECTION */
        private void R0340_00_SELECT_MOVDEBCE_SECTION()
        {
            /*" -1077- MOVE '0340' TO WNR-EXEC-SQL. */
            _.Move("0340", W.WABEND.WNR_EXEC_SQL);

            /*" -1091- PERFORM R0340_00_SELECT_MOVDEBCE_DB_SELECT_1 */

            R0340_00_SELECT_MOVDEBCE_DB_SELECT_1();

            /*" -1095- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1096- PERFORM R0345-00-SELECT-MOVDEBCE */

                R0345_00_SELECT_MOVDEBCE_SECTION();

                /*" -1097- PERFORM R0370-00-SELECT-PARCEHIS */

                R0370_00_SELECT_PARCEHIS_SECTION();

                /*" -1099- GO TO R0340-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0340_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1100- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1101- DISPLAY 'R0340-00 - PROBLEMAS NO SELECT(MOVDEBCE)' */
                _.Display($"R0340-00 - PROBLEMAS NO SELECT(MOVDEBCE)");

                /*" -1104- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1106- MOVE MOVDEBCE-NUM-APOLICE TO SOR-APOLICE. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE, REG_SBI7401B.SOR_APOLICE);

            /*" -1108- MOVE MOVDEBCE-NUM-ENDOSSO TO SOR-ENDOSSO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO, REG_SBI7401B.SOR_ENDOSSO);

            /*" -1112- MOVE MOVDEBCE-NUM-PARCELA TO SOR-PARCELA. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA, REG_SBI7401B.SOR_PARCELA);

            /*" -1112- PERFORM R0350-00-SELECT-RCAPS. */

            R0350_00_SELECT_RCAPS_SECTION();

        }

        [StopWatch]
        /*" R0340-00-SELECT-MOVDEBCE-DB-SELECT-1 */
        public void R0340_00_SELECT_MOVDEBCE_DB_SELECT_1()
        {
            /*" -1091- EXEC SQL SELECT NUM_APOLICE ,NUM_ENDOSSO ,NUM_PARCELA ,SITUACAO_COBRANCA INTO :MOVDEBCE-NUM-APOLICE ,:MOVDEBCE-NUM-ENDOSSO ,:MOVDEBCE-NUM-PARCELA ,:MOVDEBCE-SITUACAO-COBRANCA FROM SEGUROS.MOVTO_DEBITOCC_CEF WHERE NUM_APOLICE = :BILHETE-NUM-APOLICE AND SITUACAO_COBRANCA = '8' FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0340_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1 = new R0340_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1()
            {
                BILHETE_NUM_APOLICE = BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0340_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1.Execute(r0340_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVDEBCE_NUM_APOLICE, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);
                _.Move(executed_1.MOVDEBCE_NUM_ENDOSSO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);
                _.Move(executed_1.MOVDEBCE_NUM_PARCELA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA);
                _.Move(executed_1.MOVDEBCE_SITUACAO_COBRANCA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0340_99_SAIDA*/

        [StopWatch]
        /*" R0345-00-SELECT-MOVDEBCE-SECTION */
        private void R0345_00_SELECT_MOVDEBCE_SECTION()
        {
            /*" -1125- MOVE '0345' TO WNR-EXEC-SQL. */
            _.Move("0345", W.WABEND.WNR_EXEC_SQL);

            /*" -1139- PERFORM R0345_00_SELECT_MOVDEBCE_DB_SELECT_1 */

            R0345_00_SELECT_MOVDEBCE_DB_SELECT_1();

            /*" -1143- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1145- MOVE 'DEVOLUCAO NAO ENCONTRADA MOVDEBCE  ' TO LD02-MENSAGEM */
                _.Move("DEVOLUCAO NAO ENCONTRADA MOVDEBCE  ", AUX_RELATORIO.LD02.LD02_MENSAGEM);

                /*" -1146- ELSE */
            }
            else
            {


                /*" -1147- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1148- DISPLAY 'R0345-00 - PROBLEMAS NO SELECT(MOVDEBCE)' */
                    _.Display($"R0345-00 - PROBLEMAS NO SELECT(MOVDEBCE)");

                    /*" -1149- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1150- ELSE */
                }
                else
                {


                    /*" -1151- MOVE 'AGUARDANDO RETORNO MOVDEBCE       ' TO LD02-MENSAGEM. */
                    _.Move("AGUARDANDO RETORNO MOVDEBCE       ", AUX_RELATORIO.LD02.LD02_MENSAGEM);
                }

            }


        }

        [StopWatch]
        /*" R0345-00-SELECT-MOVDEBCE-DB-SELECT-1 */
        public void R0345_00_SELECT_MOVDEBCE_DB_SELECT_1()
        {
            /*" -1139- EXEC SQL SELECT NUM_APOLICE ,NUM_ENDOSSO ,NUM_PARCELA ,SITUACAO_COBRANCA INTO :MOVDEBCE-NUM-APOLICE ,:MOVDEBCE-NUM-ENDOSSO ,:MOVDEBCE-NUM-PARCELA ,:MOVDEBCE-SITUACAO-COBRANCA FROM SEGUROS.MOVTO_DEBITOCC_CEF WHERE NUM_APOLICE = :BILHETE-NUM-APOLICE AND SITUACAO_COBRANCA = '1' FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0345_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1 = new R0345_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1()
            {
                BILHETE_NUM_APOLICE = BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0345_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1.Execute(r0345_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVDEBCE_NUM_APOLICE, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);
                _.Move(executed_1.MOVDEBCE_NUM_ENDOSSO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);
                _.Move(executed_1.MOVDEBCE_NUM_PARCELA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA);
                _.Move(executed_1.MOVDEBCE_SITUACAO_COBRANCA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0345_99_SAIDA*/

        [StopWatch]
        /*" R0350-00-SELECT-RCAPS-SECTION */
        private void R0350_00_SELECT_RCAPS_SECTION()
        {
            /*" -1164- MOVE '0350' TO WNR-EXEC-SQL. */
            _.Move("0350", W.WABEND.WNR_EXEC_SQL);

            /*" -1200- PERFORM R0350_00_SELECT_RCAPS_DB_SELECT_1 */

            R0350_00_SELECT_RCAPS_DB_SELECT_1();

            /*" -1204- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1206- MOVE 'CREDITO NAO ENCONTRADO RCAPS        ' TO LD02-MENSAGEM */
                _.Move("CREDITO NAO ENCONTRADO RCAPS        ", AUX_RELATORIO.LD02.LD02_MENSAGEM);

                /*" -1208- GO TO R0350-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1209- IF SQLCODE EQUAL -811 */

            if (DB.SQLCODE == -811)
            {

                /*" -1211- MOVE 'CREDITO DUPLICADO RCAPS        ' TO LD02-MENSAGEM */
                _.Move("CREDITO DUPLICADO RCAPS        ", AUX_RELATORIO.LD02.LD02_MENSAGEM);

                /*" -1212- PERFORM R0400-00-TRATA-DUPLICIDADE */

                R0400_00_TRATA_DUPLICIDADE_SECTION();

                /*" -1214- GO TO R0350-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1215- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1216- DISPLAY 'R0350-00 - PROBLEMAS NO SELECT(RCAPS)   ' */
                _.Display($"R0350-00 - PROBLEMAS NO SELECT(RCAPS)   ");

                /*" -1218- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1219- IF VIND-NULL01 LESS ZEROS */

            if (VIND_NULL01 < 00)
            {

                /*" -1223- MOVE ZEROS TO RCAPCOMP-COD-EMPRESA. */
                _.Move(0, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_EMPRESA);
            }


            /*" -1224- IF RCAPS-COD-OPERACAO EQUAL 210 */

            if (RCAPS.DCLRCAPS.RCAPS_COD_OPERACAO == 210)
            {

                /*" -1226- MOVE 'RCAP DEVOLVIDO                 ' TO LD02-MENSAGEM */
                _.Move("RCAP DEVOLVIDO                 ", AUX_RELATORIO.LD02.LD02_MENSAGEM);

                /*" -1228- GO TO R0350-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1231- IF RCAPS-COD-OPERACAO EQUAL 200 OR 220 NEXT SENTENCE */

            if (RCAPS.DCLRCAPS.RCAPS_COD_OPERACAO.In("200", "220"))
            {

                /*" -1232- ELSE */
            }
            else
            {


                /*" -1234- MOVE 'OPERACAO RCAP DIVERGE          ' TO LD02-MENSAGEM */
                _.Move("OPERACAO RCAP DIVERGE          ", AUX_RELATORIO.LD02.LD02_MENSAGEM);

                /*" -1237- GO TO R0350-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1237- PERFORM R0370-00-SELECT-PARCEHIS. */

            R0370_00_SELECT_PARCEHIS_SECTION();

        }

        [StopWatch]
        /*" R0350-00-SELECT-RCAPS-DB-SELECT-1 */
        public void R0350_00_SELECT_RCAPS_DB_SELECT_1()
        {
            /*" -1200- EXEC SQL SELECT A.SIT_REGISTRO ,A.COD_OPERACAO ,B.COD_FONTE ,B.NUM_RCAP ,B.NUM_RCAP_COMPLEMEN ,B.COD_OPERACAO ,B.BCO_AVISO ,B.AGE_AVISO ,B.NUM_AVISO_CREDITO ,B.VAL_RCAP ,B.DATA_RCAP ,B.DATA_CADASTRAMENTO ,B.SIT_CONTABIL ,B.COD_EMPRESA INTO :RCAPS-SIT-REGISTRO ,:RCAPS-COD-OPERACAO ,:RCAPCOMP-COD-FONTE ,:RCAPCOMP-NUM-RCAP ,:RCAPCOMP-NUM-RCAP-COMPLEMEN ,:RCAPCOMP-COD-OPERACAO ,:RCAPCOMP-BCO-AVISO ,:RCAPCOMP-AGE-AVISO ,:RCAPCOMP-NUM-AVISO-CREDITO ,:RCAPCOMP-VAL-RCAP ,:RCAPCOMP-DATA-RCAP ,:RCAPCOMP-DATA-CADASTRAMENTO ,:RCAPCOMP-SIT-CONTABIL ,:RCAPCOMP-COD-EMPRESA:VIND-NULL01 FROM SEGUROS.RCAPS A ,SEGUROS.RCAP_COMPLEMENTAR B WHERE A.NUM_TITULO = :BILHETE-NUM-BILHETE AND B.NUM_RCAP = A.NUM_RCAP AND B.COD_FONTE = A.COD_FONTE AND B.SIT_REGISTRO = '0' WITH UR END-EXEC. */

            var r0350_00_SELECT_RCAPS_DB_SELECT_1_Query1 = new R0350_00_SELECT_RCAPS_DB_SELECT_1_Query1()
            {
                BILHETE_NUM_BILHETE = BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE.ToString(),
            };

            var executed_1 = R0350_00_SELECT_RCAPS_DB_SELECT_1_Query1.Execute(r0350_00_SELECT_RCAPS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_SIT_REGISTRO, RCAPS.DCLRCAPS.RCAPS_SIT_REGISTRO);
                _.Move(executed_1.RCAPS_COD_OPERACAO, RCAPS.DCLRCAPS.RCAPS_COD_OPERACAO);
                _.Move(executed_1.RCAPCOMP_COD_FONTE, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_FONTE);
                _.Move(executed_1.RCAPCOMP_NUM_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP);
                _.Move(executed_1.RCAPCOMP_NUM_RCAP_COMPLEMEN, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP_COMPLEMEN);
                _.Move(executed_1.RCAPCOMP_COD_OPERACAO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_OPERACAO);
                _.Move(executed_1.RCAPCOMP_BCO_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO);
                _.Move(executed_1.RCAPCOMP_AGE_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO);
                _.Move(executed_1.RCAPCOMP_NUM_AVISO_CREDITO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO);
                _.Move(executed_1.RCAPCOMP_VAL_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP);
                _.Move(executed_1.RCAPCOMP_DATA_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP);
                _.Move(executed_1.RCAPCOMP_DATA_CADASTRAMENTO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_CADASTRAMENTO);
                _.Move(executed_1.RCAPCOMP_SIT_CONTABIL, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_SIT_CONTABIL);
                _.Move(executed_1.RCAPCOMP_COD_EMPRESA, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_EMPRESA);
                _.Move(executed_1.VIND_NULL01, VIND_NULL01);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_99_SAIDA*/

        [StopWatch]
        /*" R0370-00-SELECT-PARCEHIS-SECTION */
        private void R0370_00_SELECT_PARCEHIS_SECTION()
        {
            /*" -1250- MOVE '0370' TO WNR-EXEC-SQL. */
            _.Move("0370", W.WABEND.WNR_EXEC_SQL);

            /*" -1312- PERFORM R0370_00_SELECT_PARCEHIS_DB_SELECT_1 */

            R0370_00_SELECT_PARCEHIS_DB_SELECT_1();

            /*" -1316- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1318- MOVE 'PARCELA SEM BAIXA PARCEHIS          ' TO LD02-MENSAGEM */
                _.Move("PARCELA SEM BAIXA PARCEHIS          ", AUX_RELATORIO.LD02.LD02_MENSAGEM);

                /*" -1320- GO TO R0370-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0370_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1321- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1322- DISPLAY 'R0370-00 - PROBLEMAS NO SELECT(PARCEHIS)' */
                _.Display($"R0370-00 - PROBLEMAS NO SELECT(PARCEHIS)");

                /*" -1324- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1325- IF VIND-NULL01 LESS ZEROS */

            if (VIND_NULL01 < 00)
            {

                /*" -1328- MOVE RCAPCOMP-DATA-RCAP TO PARCEHIS-DATA-QUITACAO. */
                _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO);
            }


            /*" -1329- IF VIND-NULL02 LESS ZEROS */

            if (VIND_NULL02 < 00)
            {

                /*" -1330- MOVE ZEROS TO PARCEHIS-COD-EMPRESA. */
                _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_EMPRESA);
            }


        }

        [StopWatch]
        /*" R0370-00-SELECT-PARCEHIS-DB-SELECT-1 */
        public void R0370_00_SELECT_PARCEHIS_DB_SELECT_1()
        {
            /*" -1312- EXEC SQL SELECT B.NUM_APOLICE ,B.NUM_ENDOSSO ,B.NUM_PARCELA ,B.DAC_PARCELA ,B.COD_OPERACAO ,B.OCORR_HISTORICO ,B.PRM_TARIFARIO ,B.VAL_DESCONTO ,B.PRM_LIQUIDO ,B.ADICIONAL_FRACIO ,B.VAL_CUSTO_EMISSAO ,B.VAL_IOCC ,B.PRM_TOTAL ,B.VAL_OPERACAO ,B.DATA_VENCIMENTO ,B.BCO_COBRANCA ,B.AGE_COBRANCA ,B.NUM_AVISO_CREDITO ,B.SIT_CONTABIL ,B.DATA_QUITACAO ,B.COD_EMPRESA ,C.ORGAO_EMISSOR ,C.RAMO_EMISSOR INTO :PARCEHIS-NUM-APOLICE ,:PARCEHIS-NUM-ENDOSSO ,:PARCEHIS-NUM-PARCELA ,:PARCEHIS-DAC-PARCELA ,:PARCEHIS-COD-OPERACAO ,:PARCEHIS-OCORR-HISTORICO ,:PARCEHIS-PRM-TARIFARIO ,:PARCEHIS-VAL-DESCONTO ,:PARCEHIS-PRM-LIQUIDO ,:PARCEHIS-ADICIONAL-FRACIO ,:PARCEHIS-VAL-CUSTO-EMISSAO ,:PARCEHIS-VAL-IOCC ,:PARCEHIS-PRM-TOTAL ,:PARCEHIS-VAL-OPERACAO ,:PARCEHIS-DATA-VENCIMENTO ,:PARCEHIS-BCO-COBRANCA ,:PARCEHIS-AGE-COBRANCA ,:PARCEHIS-NUM-AVISO-CREDITO ,:PARCEHIS-SIT-CONTABIL ,:PARCEHIS-DATA-QUITACAO:VIND-NULL01 ,:PARCEHIS-COD-EMPRESA:VIND-NULL02 ,:APOLICES-ORGAO-EMISSOR ,:APOLICES-RAMO-EMISSOR FROM SEGUROS.APOLICES C ,SEGUROS.PARCELAS A ,SEGUROS.PARCELA_HISTORICO B ,SEGUROS.ENDOSSOS D WHERE C.NUM_APOLICE = :BILHETE-NUM-APOLICE AND D.NUM_APOLICE = C.NUM_APOLICE AND D.TIPO_ENDOSSO IN ( '0' , '1' ) AND D.NUM_APOLICE = A.NUM_APOLICE AND D.NUM_ENDOSSO = A.NUM_ENDOSSO AND B.NUM_APOLICE = A.NUM_APOLICE AND B.NUM_ENDOSSO = A.NUM_ENDOSSO AND B.NUM_PARCELA = A.NUM_PARCELA AND B.OCORR_HISTORICO = A.OCORR_HISTORICO AND B.COD_OPERACAO BETWEEN 200 AND 299 WITH UR END-EXEC. */

            var r0370_00_SELECT_PARCEHIS_DB_SELECT_1_Query1 = new R0370_00_SELECT_PARCEHIS_DB_SELECT_1_Query1()
            {
                BILHETE_NUM_APOLICE = BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0370_00_SELECT_PARCEHIS_DB_SELECT_1_Query1.Execute(r0370_00_SELECT_PARCEHIS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARCEHIS_NUM_APOLICE, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE);
                _.Move(executed_1.PARCEHIS_NUM_ENDOSSO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO);
                _.Move(executed_1.PARCEHIS_NUM_PARCELA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA);
                _.Move(executed_1.PARCEHIS_DAC_PARCELA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DAC_PARCELA);
                _.Move(executed_1.PARCEHIS_COD_OPERACAO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO);
                _.Move(executed_1.PARCEHIS_OCORR_HISTORICO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO);
                _.Move(executed_1.PARCEHIS_PRM_TARIFARIO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TARIFARIO);
                _.Move(executed_1.PARCEHIS_VAL_DESCONTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_DESCONTO);
                _.Move(executed_1.PARCEHIS_PRM_LIQUIDO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_LIQUIDO);
                _.Move(executed_1.PARCEHIS_ADICIONAL_FRACIO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ADICIONAL_FRACIO);
                _.Move(executed_1.PARCEHIS_VAL_CUSTO_EMISSAO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_CUSTO_EMISSAO);
                _.Move(executed_1.PARCEHIS_VAL_IOCC, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_IOCC);
                _.Move(executed_1.PARCEHIS_PRM_TOTAL, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL);
                _.Move(executed_1.PARCEHIS_VAL_OPERACAO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_OPERACAO);
                _.Move(executed_1.PARCEHIS_DATA_VENCIMENTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO);
                _.Move(executed_1.PARCEHIS_BCO_COBRANCA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_BCO_COBRANCA);
                _.Move(executed_1.PARCEHIS_AGE_COBRANCA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_AGE_COBRANCA);
                _.Move(executed_1.PARCEHIS_NUM_AVISO_CREDITO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_AVISO_CREDITO);
                _.Move(executed_1.PARCEHIS_SIT_CONTABIL, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_SIT_CONTABIL);
                _.Move(executed_1.PARCEHIS_DATA_QUITACAO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO);
                _.Move(executed_1.VIND_NULL01, VIND_NULL01);
                _.Move(executed_1.PARCEHIS_COD_EMPRESA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_EMPRESA);
                _.Move(executed_1.VIND_NULL02, VIND_NULL02);
                _.Move(executed_1.APOLICES_ORGAO_EMISSOR, APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR);
                _.Move(executed_1.APOLICES_RAMO_EMISSOR, APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0370_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-TRATA-DUPLICIDADE-SECTION */
        private void R0400_00_TRATA_DUPLICIDADE_SECTION()
        {
            /*" -1343- MOVE '0400' TO WNR-EXEC-SQL. */
            _.Move("0400", W.WABEND.WNR_EXEC_SQL);

            /*" -1345- PERFORM R0410-00-SELECT-RCAPCOMP. */

            R0410_00_SELECT_RCAPCOMP_SECTION();

            /*" -1346- IF RCAPCOMP-NUM-RCAP NOT EQUAL ZEROS */

            if (RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP != 00)
            {

                /*" -1349- GO TO R0400-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1351- PERFORM R0420-00-SELECT-RCAPS. */

            R0420_00_SELECT_RCAPS_SECTION();

            /*" -1352- IF RCAPS-COD-OPERACAO NOT EQUAL 210 */

            if (RCAPS.DCLRCAPS.RCAPS_COD_OPERACAO != 210)
            {

                /*" -1355- GO TO R0400-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1357- PERFORM R0440-00-UPDATE-RCAPCOMP. */

            R0440_00_UPDATE_RCAPCOMP_SECTION();

            /*" -1359- MOVE SPACES TO LD02-MENSAGEM. */
            _.Move("", AUX_RELATORIO.LD02.LD02_MENSAGEM);

            /*" -1359- PERFORM R0450-00-SELECT-RCAPS. */

            R0450_00_SELECT_RCAPS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0410-00-SELECT-RCAPCOMP-SECTION */
        private void R0410_00_SELECT_RCAPCOMP_SECTION()
        {
            /*" -1372- MOVE '0410' TO WNR-EXEC-SQL. */
            _.Move("0410", W.WABEND.WNR_EXEC_SQL);

            /*" -1385- PERFORM R0410_00_SELECT_RCAPCOMP_DB_SELECT_1 */

            R0410_00_SELECT_RCAPCOMP_DB_SELECT_1();

            /*" -1389- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1392- MOVE ZEROS TO RCAPCOMP-NUM-RCAP RCAPCOMP-NUM-RCAP-COMPLEMEN */
                _.Move(0, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP_COMPLEMEN);

                /*" -1393- ELSE */
            }
            else
            {


                /*" -1394- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1395- DISPLAY 'R0410-00 - PROBLEMAS NO SELECT(RCAPCOMP)' */
                    _.Display($"R0410-00 - PROBLEMAS NO SELECT(RCAPCOMP)");

                    /*" -1395- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0410-00-SELECT-RCAPCOMP-DB-SELECT-1 */
        public void R0410_00_SELECT_RCAPCOMP_DB_SELECT_1()
        {
            /*" -1385- EXEC SQL SELECT B.NUM_RCAP ,B.NUM_RCAP_COMPLEMEN INTO :RCAPCOMP-NUM-RCAP ,:RCAPCOMP-NUM-RCAP-COMPLEMEN FROM SEGUROS.RCAPS A ,SEGUROS.RCAP_COMPLEMENTAR B WHERE A.NUM_TITULO = :BILHETE-NUM-BILHETE AND B.NUM_RCAP = A.NUM_RCAP AND B.COD_FONTE = A.COD_FONTE AND B.NUM_RCAP_COMPLEMEN <> 0 FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0410_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1 = new R0410_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1()
            {
                BILHETE_NUM_BILHETE = BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE.ToString(),
            };

            var executed_1 = R0410_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1.Execute(r0410_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPCOMP_NUM_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP);
                _.Move(executed_1.RCAPCOMP_NUM_RCAP_COMPLEMEN, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP_COMPLEMEN);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0410_99_SAIDA*/

        [StopWatch]
        /*" R0420-00-SELECT-RCAPS-SECTION */
        private void R0420_00_SELECT_RCAPS_SECTION()
        {
            /*" -1407- MOVE '0420' TO WNR-EXEC-SQL. */
            _.Move("0420", W.WABEND.WNR_EXEC_SQL);

            /*" -1415- PERFORM R0420_00_SELECT_RCAPS_DB_SELECT_1 */

            R0420_00_SELECT_RCAPS_DB_SELECT_1();

            /*" -1419- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1421- MOVE ZEROS TO RCAPS-COD-OPERACAO */
                _.Move(0, RCAPS.DCLRCAPS.RCAPS_COD_OPERACAO);

                /*" -1422- ELSE */
            }
            else
            {


                /*" -1423- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1424- DISPLAY 'R0420-00 - PROBLEMAS NO SELECT(RCAPS)' */
                    _.Display($"R0420-00 - PROBLEMAS NO SELECT(RCAPS)");

                    /*" -1424- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0420-00-SELECT-RCAPS-DB-SELECT-1 */
        public void R0420_00_SELECT_RCAPS_DB_SELECT_1()
        {
            /*" -1415- EXEC SQL SELECT NUM_RCAP ,COD_OPERACAO INTO :RCAPCOMP-NUM-RCAP ,:RCAPS-COD-OPERACAO FROM SEGUROS.RCAPS WHERE NUM_TITULO = :BILHETE-NUM-BILHETE WITH UR END-EXEC. */

            var r0420_00_SELECT_RCAPS_DB_SELECT_1_Query1 = new R0420_00_SELECT_RCAPS_DB_SELECT_1_Query1()
            {
                BILHETE_NUM_BILHETE = BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE.ToString(),
            };

            var executed_1 = R0420_00_SELECT_RCAPS_DB_SELECT_1_Query1.Execute(r0420_00_SELECT_RCAPS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPCOMP_NUM_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP);
                _.Move(executed_1.RCAPS_COD_OPERACAO, RCAPS.DCLRCAPS.RCAPS_COD_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0420_99_SAIDA*/

        [StopWatch]
        /*" R0440-00-UPDATE-RCAPCOMP-SECTION */
        private void R0440_00_UPDATE_RCAPCOMP_SECTION()
        {
            /*" -1437- MOVE '0440' TO WNR-EXEC-SQL. */
            _.Move("0440", W.WABEND.WNR_EXEC_SQL);

            /*" -1442- PERFORM R0440_00_UPDATE_RCAPCOMP_DB_UPDATE_1 */

            R0440_00_UPDATE_RCAPCOMP_DB_UPDATE_1();

            /*" -1445- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1446- DISPLAY 'R0440-00 - PROBLEMAS UPDATE (RCAPCOMP)' */
                _.Display($"R0440-00 - PROBLEMAS UPDATE (RCAPCOMP)");

                /*" -1447- DISPLAY ' BILHETE   =      ' BILHETE-NUM-BILHETE */
                _.Display($" BILHETE   =      {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

                /*" -1447- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0440-00-UPDATE-RCAPCOMP-DB-UPDATE-1 */
        public void R0440_00_UPDATE_RCAPCOMP_DB_UPDATE_1()
        {
            /*" -1442- EXEC SQL UPDATE SEGUROS.RCAP_COMPLEMENTAR SET SIT_REGISTRO = '1' WHERE NUM_RCAP = :RCAPCOMP-NUM-RCAP AND COD_OPERACAO <> 210 END-EXEC. */

            var r0440_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1 = new R0440_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1()
            {
                RCAPCOMP_NUM_RCAP = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP.ToString(),
            };

            R0440_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1.Execute(r0440_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0440_99_SAIDA*/

        [StopWatch]
        /*" R0450-00-SELECT-RCAPS-SECTION */
        private void R0450_00_SELECT_RCAPS_SECTION()
        {
            /*" -1460- MOVE '0450' TO WNR-EXEC-SQL. */
            _.Move("0450", W.WABEND.WNR_EXEC_SQL);

            /*" -1496- PERFORM R0450_00_SELECT_RCAPS_DB_SELECT_1 */

            R0450_00_SELECT_RCAPS_DB_SELECT_1();

            /*" -1500- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1502- MOVE 'CREDITO NAO ENCONTRADO RCAPS        ' TO LD02-MENSAGEM */
                _.Move("CREDITO NAO ENCONTRADO RCAPS        ", AUX_RELATORIO.LD02.LD02_MENSAGEM);

                /*" -1504- GO TO R0450-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1505- IF SQLCODE EQUAL -811 */

            if (DB.SQLCODE == -811)
            {

                /*" -1507- MOVE 'CREDITO DUPLICADO RCAPS        ' TO LD02-MENSAGEM */
                _.Move("CREDITO DUPLICADO RCAPS        ", AUX_RELATORIO.LD02.LD02_MENSAGEM);

                /*" -1508- PERFORM R0400-00-TRATA-DUPLICIDADE */

                R0400_00_TRATA_DUPLICIDADE_SECTION();

                /*" -1510- GO TO R0450-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1511- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1512- DISPLAY 'R0450-00 - PROBLEMAS NO SELECT(RCAPS)   ' */
                _.Display($"R0450-00 - PROBLEMAS NO SELECT(RCAPS)   ");

                /*" -1514- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1515- IF VIND-NULL01 LESS ZEROS */

            if (VIND_NULL01 < 00)
            {

                /*" -1519- MOVE ZEROS TO RCAPCOMP-COD-EMPRESA. */
                _.Move(0, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_EMPRESA);
            }


            /*" -1520- IF RCAPS-COD-OPERACAO EQUAL 210 */

            if (RCAPS.DCLRCAPS.RCAPS_COD_OPERACAO == 210)
            {

                /*" -1522- MOVE 'RCAP DEVOLVIDO                 ' TO LD02-MENSAGEM */
                _.Move("RCAP DEVOLVIDO                 ", AUX_RELATORIO.LD02.LD02_MENSAGEM);

                /*" -1524- GO TO R0450-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1527- IF RCAPS-COD-OPERACAO EQUAL 200 OR 220 NEXT SENTENCE */

            if (RCAPS.DCLRCAPS.RCAPS_COD_OPERACAO.In("200", "220"))
            {

                /*" -1528- ELSE */
            }
            else
            {


                /*" -1530- MOVE 'OPERACAO RCAP DIVERGE          ' TO LD02-MENSAGEM */
                _.Move("OPERACAO RCAP DIVERGE          ", AUX_RELATORIO.LD02.LD02_MENSAGEM);

                /*" -1533- GO TO R0450-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1533- PERFORM R0370-00-SELECT-PARCEHIS. */

            R0370_00_SELECT_PARCEHIS_SECTION();

        }

        [StopWatch]
        /*" R0450-00-SELECT-RCAPS-DB-SELECT-1 */
        public void R0450_00_SELECT_RCAPS_DB_SELECT_1()
        {
            /*" -1496- EXEC SQL SELECT A.SIT_REGISTRO ,A.COD_OPERACAO ,B.COD_FONTE ,B.NUM_RCAP ,B.NUM_RCAP_COMPLEMEN ,B.COD_OPERACAO ,B.BCO_AVISO ,B.AGE_AVISO ,B.NUM_AVISO_CREDITO ,B.VAL_RCAP ,B.DATA_RCAP ,B.DATA_CADASTRAMENTO ,B.SIT_CONTABIL ,B.COD_EMPRESA INTO :RCAPS-SIT-REGISTRO ,:RCAPS-COD-OPERACAO ,:RCAPCOMP-COD-FONTE ,:RCAPCOMP-NUM-RCAP ,:RCAPCOMP-NUM-RCAP-COMPLEMEN ,:RCAPCOMP-COD-OPERACAO ,:RCAPCOMP-BCO-AVISO ,:RCAPCOMP-AGE-AVISO ,:RCAPCOMP-NUM-AVISO-CREDITO ,:RCAPCOMP-VAL-RCAP ,:RCAPCOMP-DATA-RCAP ,:RCAPCOMP-DATA-CADASTRAMENTO ,:RCAPCOMP-SIT-CONTABIL ,:RCAPCOMP-COD-EMPRESA:VIND-NULL01 FROM SEGUROS.RCAPS A ,SEGUROS.RCAP_COMPLEMENTAR B WHERE A.NUM_TITULO = :BILHETE-NUM-BILHETE AND B.NUM_RCAP = A.NUM_RCAP AND B.COD_FONTE = A.COD_FONTE AND B.SIT_REGISTRO = '0' WITH UR END-EXEC. */

            var r0450_00_SELECT_RCAPS_DB_SELECT_1_Query1 = new R0450_00_SELECT_RCAPS_DB_SELECT_1_Query1()
            {
                BILHETE_NUM_BILHETE = BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE.ToString(),
            };

            var executed_1 = R0450_00_SELECT_RCAPS_DB_SELECT_1_Query1.Execute(r0450_00_SELECT_RCAPS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_SIT_REGISTRO, RCAPS.DCLRCAPS.RCAPS_SIT_REGISTRO);
                _.Move(executed_1.RCAPS_COD_OPERACAO, RCAPS.DCLRCAPS.RCAPS_COD_OPERACAO);
                _.Move(executed_1.RCAPCOMP_COD_FONTE, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_FONTE);
                _.Move(executed_1.RCAPCOMP_NUM_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP);
                _.Move(executed_1.RCAPCOMP_NUM_RCAP_COMPLEMEN, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP_COMPLEMEN);
                _.Move(executed_1.RCAPCOMP_COD_OPERACAO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_OPERACAO);
                _.Move(executed_1.RCAPCOMP_BCO_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO);
                _.Move(executed_1.RCAPCOMP_AGE_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO);
                _.Move(executed_1.RCAPCOMP_NUM_AVISO_CREDITO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO);
                _.Move(executed_1.RCAPCOMP_VAL_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP);
                _.Move(executed_1.RCAPCOMP_DATA_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP);
                _.Move(executed_1.RCAPCOMP_DATA_CADASTRAMENTO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_CADASTRAMENTO);
                _.Move(executed_1.RCAPCOMP_SIT_CONTABIL, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_SIT_CONTABIL);
                _.Move(executed_1.RCAPCOMP_COD_EMPRESA, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_EMPRESA);
                _.Move(executed_1.VIND_NULL01, VIND_NULL01);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-ATUALIZA-REGISTRO-SECTION */
        private void R1000_00_ATUALIZA_REGISTRO_SECTION()
        {
            /*" -1546- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", W.WABEND.WNR_EXEC_SQL);

            /*" -1548- MOVE 'S' TO RELATORI-IND-PREV-DEFINIT. */
            _.Move("S", RELATORI.DCLRELATORIOS.RELATORI_IND_PREV_DEFINIT);

            /*" -1551- MOVE 'S' TO RELATORI-IND-ANAL-RESUMO. */
            _.Move("S", RELATORI.DCLRELATORIOS.RELATORI_IND_ANAL_RESUMO);

            /*" -1553- PERFORM R1020-00-UPDATE-V0RELATORI. */

            R1020_00_UPDATE_V0RELATORI_SECTION();

            /*" -1555- PERFORM R1040-00-UPDATE-V0BILHETE. */

            R1040_00_UPDATE_V0BILHETE_SECTION();

            /*" -1557- PERFORM R1300-00-MONTA-RCAP. */

            R1300_00_MONTA_RCAP_SECTION();

            /*" -1559- PERFORM R1430-00-SELECT-NUMERO-AES. */

            R1430_00_SELECT_NUMERO_AES_SECTION();

            /*" -1561- PERFORM R1500-00-ALTERA-PARCELAS. */

            R1500_00_ALTERA_PARCELAS_SECTION();

            /*" -1561- PERFORM R2050-00-GRAVA-ARQUIVO02. */

            R2050_00_GRAVA_ARQUIVO02_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1020-00-UPDATE-V0RELATORI-SECTION */
        private void R1020_00_UPDATE_V0RELATORI_SECTION()
        {
            /*" -1574- MOVE '1020' TO WNR-EXEC-SQL. */
            _.Move("1020", W.WABEND.WNR_EXEC_SQL);

            /*" -1584- PERFORM R1020_00_UPDATE_V0RELATORI_DB_UPDATE_1 */

            R1020_00_UPDATE_V0RELATORI_DB_UPDATE_1();

            /*" -1588- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1589- ADD 1 TO NT-RELATORI */
                W.NT_RELATORI.Value = W.NT_RELATORI + 1;

                /*" -1590- ELSE */
            }
            else
            {


                /*" -1591- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1592- DISPLAY 'R1020-00 - PROBLEMAS UPDATE (RELATORI)  ' */
                    _.Display($"R1020-00 - PROBLEMAS UPDATE (RELATORI)  ");

                    /*" -1593- DISPLAY ' BILHETE   =      ' BILHETE-NUM-BILHETE */
                    _.Display($" BILHETE   =      {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

                    /*" -1594- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1595- ELSE */
                }
                else
                {


                    /*" -1595- ADD 1 TO UP-RELATORI. */
                    W.UP_RELATORI.Value = W.UP_RELATORI + 1;
                }

            }


        }

        [StopWatch]
        /*" R1020-00-UPDATE-V0RELATORI-DB-UPDATE-1 */
        public void R1020_00_UPDATE_V0RELATORI_DB_UPDATE_1()
        {
            /*" -1584- EXEC SQL UPDATE SEGUROS.RELATORIOS SET SIT_REGISTRO = '2' ,IND_PREV_DEFINIT = :RELATORI-IND-PREV-DEFINIT ,IND_ANAL_RESUMO = :RELATORI-IND-ANAL-RESUMO WHERE COD_RELATORIO = 'BI6401B1' AND NUM_TITULO = :RELATORI-NUM-TITULO END-EXEC. */

            var r1020_00_UPDATE_V0RELATORI_DB_UPDATE_1_Update1 = new R1020_00_UPDATE_V0RELATORI_DB_UPDATE_1_Update1()
            {
                RELATORI_IND_PREV_DEFINIT = RELATORI.DCLRELATORIOS.RELATORI_IND_PREV_DEFINIT.ToString(),
                RELATORI_IND_ANAL_RESUMO = RELATORI.DCLRELATORIOS.RELATORI_IND_ANAL_RESUMO.ToString(),
                RELATORI_NUM_TITULO = RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO.ToString(),
            };

            R1020_00_UPDATE_V0RELATORI_DB_UPDATE_1_Update1.Execute(r1020_00_UPDATE_V0RELATORI_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1020_99_SAIDA*/

        [StopWatch]
        /*" R1040-00-UPDATE-V0BILHETE-SECTION */
        private void R1040_00_UPDATE_V0BILHETE_SECTION()
        {
            /*" -1608- MOVE '1040' TO WNR-EXEC-SQL. */
            _.Move("1040", W.WABEND.WNR_EXEC_SQL);

            /*" -1611- MOVE ZEROS TO VIND-NULL01. */
            _.Move(0, VIND_NULL01);

            /*" -1621- PERFORM R1040_00_UPDATE_V0BILHETE_DB_UPDATE_1 */

            R1040_00_UPDATE_V0BILHETE_DB_UPDATE_1();

            /*" -1625- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1626- ADD 1 TO NT-BILHETE */
                W.NT_BILHETE.Value = W.NT_BILHETE + 1;

                /*" -1627- ELSE */
            }
            else
            {


                /*" -1628- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1629- DISPLAY 'R1040-00 - PROBLEMAS UPDATE (BILHETE)   ' */
                    _.Display($"R1040-00 - PROBLEMAS UPDATE (BILHETE)   ");

                    /*" -1630- DISPLAY ' BILHETE   =      ' BILHETE-NUM-BILHETE */
                    _.Display($" BILHETE   =      {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

                    /*" -1631- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1632- ELSE */
                }
                else
                {


                    /*" -1632- ADD 1 TO UP-BILHETE. */
                    W.UP_BILHETE.Value = W.UP_BILHETE + 1;
                }

            }


        }

        [StopWatch]
        /*" R1040-00-UPDATE-V0BILHETE-DB-UPDATE-1 */
        public void R1040_00_UPDATE_V0BILHETE_DB_UPDATE_1()
        {
            /*" -1621- EXEC SQL UPDATE SEGUROS.BILHETE SET SITUACAO = '8' ,TIP_CANCELAMENTO = '1' ,DATA_CANCELAMENTO = :BILHETE-DATA-CANCELAMENTO:VIND-NULL01 WHERE NUM_BILHETE = :BILHETE-NUM-BILHETE END-EXEC. */

            var r1040_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 = new R1040_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1()
            {
                BILHETE_DATA_CANCELAMENTO = BILHETE.DCLBILHETE.BILHETE_DATA_CANCELAMENTO.ToString(),
                VIND_NULL01 = VIND_NULL01.ToString(),
                BILHETE_NUM_BILHETE = BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE.ToString(),
            };

            R1040_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1.Execute(r1040_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1040_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-MONTA-RCAP-SECTION */
        private void R1300_00_MONTA_RCAP_SECTION()
        {
            /*" -1645- MOVE '1300' TO WNR-EXEC-SQL. */
            _.Move("1300", W.WABEND.WNR_EXEC_SQL);

            /*" -1651- ADD 1 TO UP-RCAPS. */
            W.UP_RCAPS.Value = W.UP_RCAPS + 1;

            /*" -1653- MOVE '1' TO RCAPS-SIT-REGISTRO. */
            _.Move("1", RCAPS.DCLRCAPS.RCAPS_SIT_REGISTRO);

            /*" -1657- MOVE 210 TO RCAPS-COD-OPERACAO. */
            _.Move(210, RCAPS.DCLRCAPS.RCAPS_COD_OPERACAO);

            /*" -1663- PERFORM R1330-00-UPDATE-RCAP. */

            R1330_00_UPDATE_RCAP_SECTION();

            /*" -1669- PERFORM R1340-00-UPDATE-RCAPCOMP. */

            R1340_00_UPDATE_RCAPCOMP_SECTION();

            /*" -1671- MOVE SISTEMAS-DATA-MOV-ABERTO TO RCAPCOMP-DATA-MOVIMENTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_MOVIMENTO);

            /*" -1673- MOVE '0' TO RCAPCOMP-SIT-CONTABIL. */
            _.Move("0", RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_SIT_CONTABIL);

            /*" -1676- MOVE ZEROS TO RCAPCOMP-COD-EMPRESA. */
            _.Move(0, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_EMPRESA);

            /*" -1677- MOVE ZEROS TO VIND-NULL01. */
            _.Move(0, VIND_NULL01);

            /*" -1679- MOVE 320 TO RCAPCOMP-COD-OPERACAO. */
            _.Move(320, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_OPERACAO);

            /*" -1683- MOVE '1' TO RCAPCOMP-SIT-REGISTRO. */
            _.Move("1", RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_SIT_REGISTRO);

            /*" -1689- PERFORM R1350-00-INSERT-RCAPCOMP. */

            R1350_00_INSERT_RCAPCOMP_SECTION();

            /*" -1691- MOVE 210 TO RCAPCOMP-COD-OPERACAO. */
            _.Move(210, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_OPERACAO);

            /*" -1695- MOVE '0' TO RCAPCOMP-SIT-REGISTRO. */
            _.Move("0", RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_SIT_REGISTRO);

            /*" -1695- PERFORM R1350-00-INSERT-RCAPCOMP. */

            R1350_00_INSERT_RCAPCOMP_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1330-00-UPDATE-RCAP-SECTION */
        private void R1330_00_UPDATE_RCAP_SECTION()
        {
            /*" -1708- MOVE '1330' TO WNR-EXEC-SQL. */
            _.Move("1330", W.WABEND.WNR_EXEC_SQL);

            /*" -1713- PERFORM R1330_00_UPDATE_RCAP_DB_UPDATE_1 */

            R1330_00_UPDATE_RCAP_DB_UPDATE_1();

            /*" -1716- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1717- DISPLAY 'R1330-00 - PROBLEMAS UPDATE (RCAPS)   ' */
                _.Display($"R1330-00 - PROBLEMAS UPDATE (RCAPS)   ");

                /*" -1718- DISPLAY ' BILHETE   =      ' BILHETE-NUM-BILHETE */
                _.Display($" BILHETE   =      {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

                /*" -1718- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1330-00-UPDATE-RCAP-DB-UPDATE-1 */
        public void R1330_00_UPDATE_RCAP_DB_UPDATE_1()
        {
            /*" -1713- EXEC SQL UPDATE SEGUROS.RCAPS SET SIT_REGISTRO = :RCAPS-SIT-REGISTRO ,COD_OPERACAO = :RCAPS-COD-OPERACAO WHERE NUM_RCAP = :RCAPCOMP-NUM-RCAP END-EXEC. */

            var r1330_00_UPDATE_RCAP_DB_UPDATE_1_Update1 = new R1330_00_UPDATE_RCAP_DB_UPDATE_1_Update1()
            {
                RCAPS_SIT_REGISTRO = RCAPS.DCLRCAPS.RCAPS_SIT_REGISTRO.ToString(),
                RCAPS_COD_OPERACAO = RCAPS.DCLRCAPS.RCAPS_COD_OPERACAO.ToString(),
                RCAPCOMP_NUM_RCAP = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP.ToString(),
            };

            R1330_00_UPDATE_RCAP_DB_UPDATE_1_Update1.Execute(r1330_00_UPDATE_RCAP_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1330_99_SAIDA*/

        [StopWatch]
        /*" R1340-00-UPDATE-RCAPCOMP-SECTION */
        private void R1340_00_UPDATE_RCAPCOMP_SECTION()
        {
            /*" -1731- MOVE '1340' TO WNR-EXEC-SQL. */
            _.Move("1340", W.WABEND.WNR_EXEC_SQL);

            /*" -1735- PERFORM R1340_00_UPDATE_RCAPCOMP_DB_UPDATE_1 */

            R1340_00_UPDATE_RCAPCOMP_DB_UPDATE_1();

            /*" -1738- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1739- DISPLAY 'R1340-00 - PROBLEMAS UPDATE (RCAPCOMP)' */
                _.Display($"R1340-00 - PROBLEMAS UPDATE (RCAPCOMP)");

                /*" -1740- DISPLAY ' BILHETE   =      ' BILHETE-NUM-BILHETE */
                _.Display($" BILHETE   =      {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

                /*" -1740- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1340-00-UPDATE-RCAPCOMP-DB-UPDATE-1 */
        public void R1340_00_UPDATE_RCAPCOMP_DB_UPDATE_1()
        {
            /*" -1735- EXEC SQL UPDATE SEGUROS.RCAP_COMPLEMENTAR SET SIT_REGISTRO = '1' WHERE NUM_RCAP = :RCAPCOMP-NUM-RCAP END-EXEC. */

            var r1340_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1 = new R1340_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1()
            {
                RCAPCOMP_NUM_RCAP = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP.ToString(),
            };

            R1340_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1.Execute(r1340_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1340_99_SAIDA*/

        [StopWatch]
        /*" R1350-00-INSERT-RCAPCOMP-SECTION */
        private void R1350_00_INSERT_RCAPCOMP_SECTION()
        {
            /*" -1753- MOVE '1350' TO WNR-EXEC-SQL. */
            _.Move("1350", W.WABEND.WNR_EXEC_SQL);

            /*" -1788- PERFORM R1350_00_INSERT_RCAPCOMP_DB_INSERT_1 */

            R1350_00_INSERT_RCAPCOMP_DB_INSERT_1();

            /*" -1792- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1793- DISPLAY ' R1350-00 - PROBLEMAS NO INSERT(RCAPCOMP)   ' */
                _.Display($" R1350-00 - PROBLEMAS NO INSERT(RCAPCOMP)   ");

                /*" -1794- DISPLAY ' BILHETE   =      ' BILHETE-NUM-BILHETE */
                _.Display($" BILHETE   =      {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

                /*" -1794- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1350-00-INSERT-RCAPCOMP-DB-INSERT-1 */
        public void R1350_00_INSERT_RCAPCOMP_DB_INSERT_1()
        {
            /*" -1788- EXEC SQL INSERT INTO SEGUROS.RCAP_COMPLEMENTAR (COD_FONTE , NUM_RCAP , NUM_RCAP_COMPLEMEN , COD_OPERACAO , DATA_MOVIMENTO , HORA_OPERACAO , SIT_REGISTRO , BCO_AVISO , AGE_AVISO , NUM_AVISO_CREDITO , VAL_RCAP , DATA_RCAP , DATA_CADASTRAMENTO , SIT_CONTABIL , COD_EMPRESA , TIMESTAMP) VALUES (:RCAPCOMP-COD-FONTE , :RCAPCOMP-NUM-RCAP , :RCAPCOMP-NUM-RCAP-COMPLEMEN , :RCAPCOMP-COD-OPERACAO , :RCAPCOMP-DATA-MOVIMENTO , CURRENT TIME , :RCAPCOMP-SIT-REGISTRO , :RCAPCOMP-BCO-AVISO , :RCAPCOMP-AGE-AVISO , :RCAPCOMP-NUM-AVISO-CREDITO , :RCAPCOMP-VAL-RCAP , :RCAPCOMP-DATA-RCAP , :RCAPCOMP-DATA-CADASTRAMENTO , :RCAPCOMP-SIT-CONTABIL , :RCAPCOMP-COD-EMPRESA:VIND-NULL01 , CURRENT TIMESTAMP) END-EXEC. */

            var r1350_00_INSERT_RCAPCOMP_DB_INSERT_1_Insert1 = new R1350_00_INSERT_RCAPCOMP_DB_INSERT_1_Insert1()
            {
                RCAPCOMP_COD_FONTE = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_FONTE.ToString(),
                RCAPCOMP_NUM_RCAP = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP.ToString(),
                RCAPCOMP_NUM_RCAP_COMPLEMEN = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP_COMPLEMEN.ToString(),
                RCAPCOMP_COD_OPERACAO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_OPERACAO.ToString(),
                RCAPCOMP_DATA_MOVIMENTO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_MOVIMENTO.ToString(),
                RCAPCOMP_SIT_REGISTRO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_SIT_REGISTRO.ToString(),
                RCAPCOMP_BCO_AVISO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO.ToString(),
                RCAPCOMP_AGE_AVISO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO.ToString(),
                RCAPCOMP_NUM_AVISO_CREDITO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO.ToString(),
                RCAPCOMP_VAL_RCAP = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP.ToString(),
                RCAPCOMP_DATA_RCAP = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP.ToString(),
                RCAPCOMP_DATA_CADASTRAMENTO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_CADASTRAMENTO.ToString(),
                RCAPCOMP_SIT_CONTABIL = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_SIT_CONTABIL.ToString(),
                RCAPCOMP_COD_EMPRESA = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_EMPRESA.ToString(),
                VIND_NULL01 = VIND_NULL01.ToString(),
            };

            R1350_00_INSERT_RCAPCOMP_DB_INSERT_1_Insert1.Execute(r1350_00_INSERT_RCAPCOMP_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1350_99_SAIDA*/

        [StopWatch]
        /*" R1430-00-SELECT-NUMERO-AES-SECTION */
        private void R1430_00_SELECT_NUMERO_AES_SECTION()
        {
            /*" -1807- MOVE '1430' TO WNR-EXEC-SQL. */
            _.Move("1430", W.WABEND.WNR_EXEC_SQL);

            /*" -1819- PERFORM R1430_00_SELECT_NUMERO_AES_DB_SELECT_1 */

            R1430_00_SELECT_NUMERO_AES_DB_SELECT_1();

            /*" -1823- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1824- DISPLAY 'R1430-00 - PROBLEMAS NO SELECT(NUMERAES)' */
                _.Display($"R1430-00 - PROBLEMAS NO SELECT(NUMERAES)");

                /*" -1827- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1831- ADD 1 TO NUMERAES-ENDOS-CANCELA. */
            NUMERAES.DCLNUMERO_AES.NUMERAES_ENDOS_CANCELA.Value = NUMERAES.DCLNUMERO_AES.NUMERAES_ENDOS_CANCELA + 1;

            /*" -1831- PERFORM R1440-00-UPDATE-NUMERO-AES. */

            R1440_00_UPDATE_NUMERO_AES_SECTION();

        }

        [StopWatch]
        /*" R1430-00-SELECT-NUMERO-AES-DB-SELECT-1 */
        public void R1430_00_SELECT_NUMERO_AES_DB_SELECT_1()
        {
            /*" -1819- EXEC SQL SELECT ORGAO_EMISSOR ,RAMO_EMISSOR ,ENDOS_CANCELA INTO :NUMERAES-ORGAO-EMISSOR ,:NUMERAES-RAMO-EMISSOR ,:NUMERAES-ENDOS-CANCELA FROM SEGUROS.NUMERO_AES WHERE ORGAO_EMISSOR = :APOLICES-ORGAO-EMISSOR AND RAMO_EMISSOR = :APOLICES-RAMO-EMISSOR FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r1430_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1 = new R1430_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1()
            {
                APOLICES_ORGAO_EMISSOR = APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR.ToString(),
                APOLICES_RAMO_EMISSOR = APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR.ToString(),
            };

            var executed_1 = R1430_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1.Execute(r1430_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUMERAES_ORGAO_EMISSOR, NUMERAES.DCLNUMERO_AES.NUMERAES_ORGAO_EMISSOR);
                _.Move(executed_1.NUMERAES_RAMO_EMISSOR, NUMERAES.DCLNUMERO_AES.NUMERAES_RAMO_EMISSOR);
                _.Move(executed_1.NUMERAES_ENDOS_CANCELA, NUMERAES.DCLNUMERO_AES.NUMERAES_ENDOS_CANCELA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1430_99_SAIDA*/

        [StopWatch]
        /*" R1440-00-UPDATE-NUMERO-AES-SECTION */
        private void R1440_00_UPDATE_NUMERO_AES_SECTION()
        {
            /*" -1844- MOVE '1440' TO WNR-EXEC-SQL. */
            _.Move("1440", W.WABEND.WNR_EXEC_SQL);

            /*" -1852- PERFORM R1440_00_UPDATE_NUMERO_AES_DB_UPDATE_1 */

            R1440_00_UPDATE_NUMERO_AES_DB_UPDATE_1();

            /*" -1856- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1857- DISPLAY 'R1440-00 - PROBLEMAS UPDATE (NUMERAES)  ' */
                _.Display($"R1440-00 - PROBLEMAS UPDATE (NUMERAES)  ");

                /*" -1857- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1440-00-UPDATE-NUMERO-AES-DB-UPDATE-1 */
        public void R1440_00_UPDATE_NUMERO_AES_DB_UPDATE_1()
        {
            /*" -1852- EXEC SQL UPDATE SEGUROS.NUMERO_AES SET ENDOS_CANCELA = :NUMERAES-ENDOS-CANCELA WHERE ORGAO_EMISSOR = :NUMERAES-ORGAO-EMISSOR AND RAMO_EMISSOR = :NUMERAES-RAMO-EMISSOR END-EXEC. */

            var r1440_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1 = new R1440_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1()
            {
                NUMERAES_ENDOS_CANCELA = NUMERAES.DCLNUMERO_AES.NUMERAES_ENDOS_CANCELA.ToString(),
                NUMERAES_ORGAO_EMISSOR = NUMERAES.DCLNUMERO_AES.NUMERAES_ORGAO_EMISSOR.ToString(),
                NUMERAES_RAMO_EMISSOR = NUMERAES.DCLNUMERO_AES.NUMERAES_RAMO_EMISSOR.ToString(),
            };

            R1440_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1.Execute(r1440_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1440_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-ALTERA-PARCELAS-SECTION */
        private void R1500_00_ALTERA_PARCELAS_SECTION()
        {
            /*" -1870- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", W.WABEND.WNR_EXEC_SQL);

            /*" -1872- MOVE RCAPCOMP-BCO-AVISO TO PARCEHIS-BCO-COBRANCA. */
            _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_BCO_COBRANCA);

            /*" -1874- MOVE RCAPCOMP-AGE-AVISO TO PARCEHIS-AGE-COBRANCA. */
            _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_AGE_COBRANCA);

            /*" -1877- MOVE RCAPCOMP-NUM-AVISO-CREDITO TO PARCEHIS-NUM-AVISO-CREDITO. */
            _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_AVISO_CREDITO);

            /*" -1883- PERFORM R1510-00-UPDATE-PARCEHIS. */

            R1510_00_UPDATE_PARCEHIS_SECTION();

            /*" -1885- MOVE SISTEMAS-DATA-MOV-ABERTO TO PARCEHIS-DATA-MOVIMENTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO);

            /*" -1889- MOVE ZEROS TO PARCEHIS-RENUM-DOCUMENTO VIND-NULL01 VIND-NULL02. */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_RENUM_DOCUMENTO, VIND_NULL01, VIND_NULL02);

            /*" -1891- MOVE 'BI7401B' TO PARCEHIS-COD-USUARIO. */
            _.Move("BI7401B", PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_USUARIO);

            /*" -1893- MOVE ZEROS TO PARCEHIS-ENDOS-CANCELA. */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ENDOS_CANCELA);

            /*" -1895- MOVE 300 TO PARCEHIS-COD-OPERACAO. */
            _.Move(300, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO);

            /*" -1899- ADD 1 TO PARCEHIS-OCORR-HISTORICO. */
            PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO.Value = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO + 1;

            /*" -1905- PERFORM R1550-00-INSERT-PARCEHIS. */

            R1550_00_INSERT_PARCEHIS_SECTION();

            /*" -1907- MOVE NUMERAES-ENDOS-CANCELA TO PARCEHIS-ENDOS-CANCELA. */
            _.Move(NUMERAES.DCLNUMERO_AES.NUMERAES_ENDOS_CANCELA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ENDOS_CANCELA);

            /*" -1909- MOVE 402 TO PARCEHIS-COD-OPERACAO. */
            _.Move(402, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO);

            /*" -1911- ADD 1 TO PARCEHIS-OCORR-HISTORICO. */
            PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO.Value = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO + 1;

            /*" -1915- MOVE ZEROS TO PARCEHIS-NUM-AVISO-CREDITO. */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_AVISO_CREDITO);

            /*" -1917- PERFORM R1550-00-INSERT-PARCEHIS. */

            R1550_00_INSERT_PARCEHIS_SECTION();

            /*" -1919- PERFORM R1560-00-UPDATE-PARCELAS. */

            R1560_00_UPDATE_PARCELAS_SECTION();

            /*" -1922- PERFORM R1570-00-UPDATE-ENDOSSOS. */

            R1570_00_UPDATE_ENDOSSOS_SECTION();

            /*" -1922- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1510-00-UPDATE-PARCEHIS-SECTION */
        private void R1510_00_UPDATE_PARCEHIS_SECTION()
        {
            /*" -1935- MOVE '1510' TO WNR-EXEC-SQL. */
            _.Move("1510", W.WABEND.WNR_EXEC_SQL);

            /*" -1947- PERFORM R1510_00_UPDATE_PARCEHIS_DB_UPDATE_1 */

            R1510_00_UPDATE_PARCEHIS_DB_UPDATE_1();

            /*" -1951- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1952- DISPLAY 'R1510-00 - PROBLEMAS UPDATE (PARCEHIS)  ' */
                _.Display($"R1510-00 - PROBLEMAS UPDATE (PARCEHIS)  ");

                /*" -1953- DISPLAY ' APOLICE   =  ' PARCEHIS-NUM-APOLICE */
                _.Display($" APOLICE   =  {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                /*" -1954- DISPLAY ' ENDOSSO   =  ' PARCEHIS-NUM-ENDOSSO */
                _.Display($" ENDOSSO   =  {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                /*" -1955- DISPLAY ' PARCELA   =  ' PARCEHIS-NUM-PARCELA */
                _.Display($" PARCELA   =  {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}");

                /*" -1955- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1510-00-UPDATE-PARCEHIS-DB-UPDATE-1 */
        public void R1510_00_UPDATE_PARCEHIS_DB_UPDATE_1()
        {
            /*" -1947- EXEC SQL UPDATE SEGUROS.PARCELA_HISTORICO SET BCO_COBRANCA = :PARCEHIS-BCO-COBRANCA ,AGE_COBRANCA = :PARCEHIS-AGE-COBRANCA ,NUM_AVISO_CREDITO = :PARCEHIS-NUM-AVISO-CREDITO WHERE NUM_APOLICE = :PARCEHIS-NUM-APOLICE AND NUM_ENDOSSO = :PARCEHIS-NUM-ENDOSSO AND NUM_PARCELA = :PARCEHIS-NUM-PARCELA AND OCORR_HISTORICO = :PARCEHIS-OCORR-HISTORICO END-EXEC. */

            var r1510_00_UPDATE_PARCEHIS_DB_UPDATE_1_Update1 = new R1510_00_UPDATE_PARCEHIS_DB_UPDATE_1_Update1()
            {
                PARCEHIS_NUM_AVISO_CREDITO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_AVISO_CREDITO.ToString(),
                PARCEHIS_BCO_COBRANCA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_BCO_COBRANCA.ToString(),
                PARCEHIS_AGE_COBRANCA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_AGE_COBRANCA.ToString(),
                PARCEHIS_OCORR_HISTORICO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO.ToString(),
                PARCEHIS_NUM_APOLICE = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.ToString(),
                PARCEHIS_NUM_ENDOSSO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO.ToString(),
                PARCEHIS_NUM_PARCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA.ToString(),
            };

            R1510_00_UPDATE_PARCEHIS_DB_UPDATE_1_Update1.Execute(r1510_00_UPDATE_PARCEHIS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1510_99_SAIDA*/

        [StopWatch]
        /*" R1550-00-INSERT-PARCEHIS-SECTION */
        private void R1550_00_INSERT_PARCEHIS_SECTION()
        {
            /*" -1968- MOVE '1550' TO WNR-EXEC-SQL. */
            _.Move("1550", W.WABEND.WNR_EXEC_SQL);

            /*" -2025- PERFORM R1550_00_INSERT_PARCEHIS_DB_INSERT_1 */

            R1550_00_INSERT_PARCEHIS_DB_INSERT_1();

            /*" -2029- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2030- DISPLAY 'R1550-00 - PROBLEMAS NO INSERT(PARCEHIS)   ' */
                _.Display($"R1550-00 - PROBLEMAS NO INSERT(PARCEHIS)   ");

                /*" -2031- DISPLAY ' APOLICE   =  ' PARCEHIS-NUM-APOLICE */
                _.Display($" APOLICE   =  {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                /*" -2032- DISPLAY ' ENDOSSO   =  ' PARCEHIS-NUM-ENDOSSO */
                _.Display($" ENDOSSO   =  {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                /*" -2033- DISPLAY ' PARCELA   =  ' PARCEHIS-NUM-PARCELA */
                _.Display($" PARCELA   =  {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}");

                /*" -2033- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1550-00-INSERT-PARCEHIS-DB-INSERT-1 */
        public void R1550_00_INSERT_PARCEHIS_DB_INSERT_1()
        {
            /*" -2025- EXEC SQL INSERT INTO SEGUROS.PARCELA_HISTORICO (NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , DAC_PARCELA , DATA_MOVIMENTO , COD_OPERACAO , HORA_OPERACAO , OCORR_HISTORICO , PRM_TARIFARIO , VAL_DESCONTO , PRM_LIQUIDO , ADICIONAL_FRACIO , VAL_CUSTO_EMISSAO , VAL_IOCC , PRM_TOTAL , VAL_OPERACAO , DATA_VENCIMENTO , BCO_COBRANCA , AGE_COBRANCA , NUM_AVISO_CREDITO , ENDOS_CANCELA , SIT_CONTABIL , COD_USUARIO , RENUM_DOCUMENTO , DATA_QUITACAO , COD_EMPRESA , TIMESTAMP) VALUES (:PARCEHIS-NUM-APOLICE , :PARCEHIS-NUM-ENDOSSO , :PARCEHIS-NUM-PARCELA , :PARCEHIS-DAC-PARCELA , :PARCEHIS-DATA-MOVIMENTO , :PARCEHIS-COD-OPERACAO , CURRENT TIME , :PARCEHIS-OCORR-HISTORICO , :PARCEHIS-PRM-TARIFARIO , :PARCEHIS-VAL-DESCONTO , :PARCEHIS-PRM-LIQUIDO , :PARCEHIS-ADICIONAL-FRACIO , :PARCEHIS-VAL-CUSTO-EMISSAO , :PARCEHIS-VAL-IOCC , :PARCEHIS-PRM-TOTAL , :PARCEHIS-VAL-OPERACAO , :PARCEHIS-DATA-VENCIMENTO , :PARCEHIS-BCO-COBRANCA , :PARCEHIS-AGE-COBRANCA , :PARCEHIS-NUM-AVISO-CREDITO , :PARCEHIS-ENDOS-CANCELA , :PARCEHIS-SIT-CONTABIL , :PARCEHIS-COD-USUARIO , :PARCEHIS-RENUM-DOCUMENTO , :PARCEHIS-DATA-QUITACAO:VIND-NULL01 , :PARCEHIS-COD-EMPRESA:VIND-NULL02 , CURRENT TIMESTAMP) END-EXEC. */

            var r1550_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1 = new R1550_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1()
            {
                PARCEHIS_NUM_APOLICE = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.ToString(),
                PARCEHIS_NUM_ENDOSSO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO.ToString(),
                PARCEHIS_NUM_PARCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA.ToString(),
                PARCEHIS_DAC_PARCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DAC_PARCELA.ToString(),
                PARCEHIS_DATA_MOVIMENTO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO.ToString(),
                PARCEHIS_COD_OPERACAO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO.ToString(),
                PARCEHIS_OCORR_HISTORICO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO.ToString(),
                PARCEHIS_PRM_TARIFARIO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TARIFARIO.ToString(),
                PARCEHIS_VAL_DESCONTO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_DESCONTO.ToString(),
                PARCEHIS_PRM_LIQUIDO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_LIQUIDO.ToString(),
                PARCEHIS_ADICIONAL_FRACIO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ADICIONAL_FRACIO.ToString(),
                PARCEHIS_VAL_CUSTO_EMISSAO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_CUSTO_EMISSAO.ToString(),
                PARCEHIS_VAL_IOCC = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_IOCC.ToString(),
                PARCEHIS_PRM_TOTAL = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL.ToString(),
                PARCEHIS_VAL_OPERACAO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_OPERACAO.ToString(),
                PARCEHIS_DATA_VENCIMENTO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO.ToString(),
                PARCEHIS_BCO_COBRANCA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_BCO_COBRANCA.ToString(),
                PARCEHIS_AGE_COBRANCA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_AGE_COBRANCA.ToString(),
                PARCEHIS_NUM_AVISO_CREDITO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_AVISO_CREDITO.ToString(),
                PARCEHIS_ENDOS_CANCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ENDOS_CANCELA.ToString(),
                PARCEHIS_SIT_CONTABIL = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_SIT_CONTABIL.ToString(),
                PARCEHIS_COD_USUARIO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_USUARIO.ToString(),
                PARCEHIS_RENUM_DOCUMENTO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_RENUM_DOCUMENTO.ToString(),
                PARCEHIS_DATA_QUITACAO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO.ToString(),
                VIND_NULL01 = VIND_NULL01.ToString(),
                PARCEHIS_COD_EMPRESA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_EMPRESA.ToString(),
                VIND_NULL02 = VIND_NULL02.ToString(),
            };

            R1550_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1.Execute(r1550_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1550_99_SAIDA*/

        [StopWatch]
        /*" R1560-00-UPDATE-PARCELAS-SECTION */
        private void R1560_00_UPDATE_PARCELAS_SECTION()
        {
            /*" -2046- MOVE '1560' TO WNR-EXEC-SQL. */
            _.Move("1560", W.WABEND.WNR_EXEC_SQL);

            /*" -2056- PERFORM R1560_00_UPDATE_PARCELAS_DB_UPDATE_1 */

            R1560_00_UPDATE_PARCELAS_DB_UPDATE_1();

            /*" -2060- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2061- DISPLAY 'R1560-00 - PROBLEMAS UPDATE (PARCELAS)  ' */
                _.Display($"R1560-00 - PROBLEMAS UPDATE (PARCELAS)  ");

                /*" -2062- DISPLAY ' APOLICE   =  ' PARCEHIS-NUM-APOLICE */
                _.Display($" APOLICE   =  {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                /*" -2063- DISPLAY ' ENDOSSO   =  ' PARCEHIS-NUM-ENDOSSO */
                _.Display($" ENDOSSO   =  {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                /*" -2064- DISPLAY ' PARCELA   =  ' PARCEHIS-NUM-PARCELA */
                _.Display($" PARCELA   =  {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}");

                /*" -2064- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1560-00-UPDATE-PARCELAS-DB-UPDATE-1 */
        public void R1560_00_UPDATE_PARCELAS_DB_UPDATE_1()
        {
            /*" -2056- EXEC SQL UPDATE SEGUROS.PARCELAS SET SIT_REGISTRO = '2' ,OCORR_HISTORICO = :PARCEHIS-OCORR-HISTORICO WHERE NUM_APOLICE = :PARCEHIS-NUM-APOLICE AND NUM_ENDOSSO = :PARCEHIS-NUM-ENDOSSO AND NUM_PARCELA = :PARCEHIS-NUM-PARCELA END-EXEC. */

            var r1560_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1 = new R1560_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1()
            {
                PARCEHIS_OCORR_HISTORICO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO.ToString(),
                PARCEHIS_NUM_APOLICE = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.ToString(),
                PARCEHIS_NUM_ENDOSSO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO.ToString(),
                PARCEHIS_NUM_PARCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA.ToString(),
            };

            R1560_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1.Execute(r1560_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1560_99_SAIDA*/

        [StopWatch]
        /*" R1570-00-UPDATE-ENDOSSOS-SECTION */
        private void R1570_00_UPDATE_ENDOSSOS_SECTION()
        {
            /*" -2077- MOVE '1570' TO WNR-EXEC-SQL. */
            _.Move("1570", W.WABEND.WNR_EXEC_SQL);

            /*" -2085- PERFORM R1570_00_UPDATE_ENDOSSOS_DB_UPDATE_1 */

            R1570_00_UPDATE_ENDOSSOS_DB_UPDATE_1();

            /*" -2089- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2090- DISPLAY 'R1570-00 - PROBLEMAS UPDATE (ENDOSSOS)  ' */
                _.Display($"R1570-00 - PROBLEMAS UPDATE (ENDOSSOS)  ");

                /*" -2091- DISPLAY ' APOLICE   =  ' PARCEHIS-NUM-APOLICE */
                _.Display($" APOLICE   =  {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                /*" -2092- DISPLAY ' ENDOSSO   =  ' PARCEHIS-NUM-ENDOSSO */
                _.Display($" ENDOSSO   =  {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                /*" -2092- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1570-00-UPDATE-ENDOSSOS-DB-UPDATE-1 */
        public void R1570_00_UPDATE_ENDOSSOS_DB_UPDATE_1()
        {
            /*" -2085- EXEC SQL UPDATE SEGUROS.ENDOSSOS SET SIT_REGISTRO = '2' WHERE NUM_APOLICE = :PARCEHIS-NUM-APOLICE AND NUM_ENDOSSO = :PARCEHIS-NUM-ENDOSSO END-EXEC. */

            var r1570_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1 = new R1570_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1()
            {
                PARCEHIS_NUM_APOLICE = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.ToString(),
                PARCEHIS_NUM_ENDOSSO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO.ToString(),
            };

            R1570_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1.Execute(r1570_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1570_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-GRAVA-ARQUIVO01-SECTION */
        private void R2000_00_GRAVA_ARQUIVO01_SECTION()
        {
            /*" -2105- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", W.WABEND.WNR_EXEC_SQL);

            /*" -2107- IF LD02-MENSAGEM EQUAL 'DEVOLUCAO NAO ENCONTRADA MOVDEBCE  ' */

            if (AUX_RELATORIO.LD02.LD02_MENSAGEM == "DEVOLUCAO NAO ENCONTRADA MOVDEBCE  ")
            {

                /*" -2108- PERFORM R3000-00-GERA-CANCELAMENTO */

                R3000_00_GERA_CANCELAMENTO_SECTION();

                /*" -2111- GO TO R2000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2113- MOVE SOR-BILHETE TO LD02-BILHETE. */
            _.Move(REG_SBI7401B.SOR_BILHETE, AUX_RELATORIO.LD02.LD02_BILHETE);

            /*" -2115- MOVE SOR-APOLICE TO LD02-APOLICE. */
            _.Move(REG_SBI7401B.SOR_APOLICE, AUX_RELATORIO.LD02.LD02_APOLICE);

            /*" -2117- MOVE SOR-RAMO TO LD02-RAMO. */
            _.Move(REG_SBI7401B.SOR_RAMO, AUX_RELATORIO.LD02.LD02_RAMO);

            /*" -2119- MOVE SOR-PRODUTO TO LD02-PRODUTO. */
            _.Move(REG_SBI7401B.SOR_PRODUTO, AUX_RELATORIO.LD02.LD02_PRODUTO);

            /*" -2121- MOVE SOR-AGEVENDA TO LD02-AGEVENDA. */
            _.Move(REG_SBI7401B.SOR_AGEVENDA, AUX_RELATORIO.LD02.LD02_AGEVENDA);

            /*" -2123- MOVE SOR-DTVENDA TO LD02-DTVENDA. */
            _.Move(REG_SBI7401B.SOR_DTVENDA, AUX_RELATORIO.LD02.LD02_DTVENDA);

            /*" -2125- MOVE SOR-VALOR TO LD02-VALOR. */
            _.Move(REG_SBI7401B.SOR_VALOR, AUX_RELATORIO.LD02.LD02_VALOR);

            /*" -2127- MOVE SOR-DTCANCEL TO LD02-DTCANCEL. */
            _.Move(REG_SBI7401B.SOR_DTCANCEL, AUX_RELATORIO.LD02.LD02_DTCANCEL);

            /*" -2129- MOVE SOR-SEGURADO TO LD02-SEGURADO. */
            _.Move(REG_SBI7401B.SOR_SEGURADO, AUX_RELATORIO.LD02.LD02_SEGURADO);

            /*" -2131- MOVE SOR-CGCCPF TO LD02-CGCCPF. */
            _.Move(REG_SBI7401B.SOR_CGCCPF, AUX_RELATORIO.LD02.LD02_CGCCPF);

            /*" -2135- MOVE SOR-PROPOSTA TO LD02-PROPOSTA. */
            _.Move(REG_SBI7401B.SOR_PROPOSTA, AUX_RELATORIO.LD02.LD02_PROPOSTA);

            /*" -2136- WRITE REG-SAIDA01 FROM LD02. */
            _.Move(AUX_RELATORIO.LD02.GetMoveValues(), REG_SAIDA01);

            SAIDA01.Write(REG_SAIDA01.GetMoveValues().ToString());

            /*" -2136- ADD 1 TO GV-ARQUIVO01. */
            W.GV_ARQUIVO01.Value = W.GV_ARQUIVO01 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2050-00-GRAVA-ARQUIVO02-SECTION */
        private void R2050_00_GRAVA_ARQUIVO02_SECTION()
        {
            /*" -2149- MOVE '2050' TO WNR-EXEC-SQL. */
            _.Move("2050", W.WABEND.WNR_EXEC_SQL);

            /*" -2151- MOVE SOR-BILHETE TO LD02-BILHETE. */
            _.Move(REG_SBI7401B.SOR_BILHETE, AUX_RELATORIO.LD02.LD02_BILHETE);

            /*" -2153- MOVE SOR-APOLICE TO LD02-APOLICE. */
            _.Move(REG_SBI7401B.SOR_APOLICE, AUX_RELATORIO.LD02.LD02_APOLICE);

            /*" -2155- MOVE SOR-RAMO TO LD02-RAMO. */
            _.Move(REG_SBI7401B.SOR_RAMO, AUX_RELATORIO.LD02.LD02_RAMO);

            /*" -2157- MOVE SOR-PRODUTO TO LD02-PRODUTO. */
            _.Move(REG_SBI7401B.SOR_PRODUTO, AUX_RELATORIO.LD02.LD02_PRODUTO);

            /*" -2159- MOVE SOR-AGEVENDA TO LD02-AGEVENDA. */
            _.Move(REG_SBI7401B.SOR_AGEVENDA, AUX_RELATORIO.LD02.LD02_AGEVENDA);

            /*" -2161- MOVE SOR-DTVENDA TO LD02-DTVENDA. */
            _.Move(REG_SBI7401B.SOR_DTVENDA, AUX_RELATORIO.LD02.LD02_DTVENDA);

            /*" -2163- MOVE SOR-VALOR TO LD02-VALOR. */
            _.Move(REG_SBI7401B.SOR_VALOR, AUX_RELATORIO.LD02.LD02_VALOR);

            /*" -2165- MOVE SOR-DTCANCEL TO LD02-DTCANCEL. */
            _.Move(REG_SBI7401B.SOR_DTCANCEL, AUX_RELATORIO.LD02.LD02_DTCANCEL);

            /*" -2167- MOVE SOR-SEGURADO TO LD02-SEGURADO. */
            _.Move(REG_SBI7401B.SOR_SEGURADO, AUX_RELATORIO.LD02.LD02_SEGURADO);

            /*" -2169- MOVE SOR-CGCCPF TO LD02-CGCCPF. */
            _.Move(REG_SBI7401B.SOR_CGCCPF, AUX_RELATORIO.LD02.LD02_CGCCPF);

            /*" -2172- MOVE SOR-PROPOSTA TO LD02-PROPOSTA. */
            _.Move(REG_SBI7401B.SOR_PROPOSTA, AUX_RELATORIO.LD02.LD02_PROPOSTA);

            /*" -2174- MOVE PARCEHIS-NUM-APOLICE TO WS02-APOLICE. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE, AUX_RELATORIO.WS02.WS02_APOLICE);

            /*" -2176- MOVE PARCEHIS-NUM-ENDOSSO TO WS02-ENDOSSO. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO, AUX_RELATORIO.WS02.WS02_ENDOSSO);

            /*" -2178- MOVE PARCEHIS-NUM-PARCELA TO WS02-PARCELA. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA, AUX_RELATORIO.WS02.WS02_PARCELA);

            /*" -2180- MOVE PARCEHIS-ENDOS-CANCELA TO WS02-NRENDOCA. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ENDOS_CANCELA, AUX_RELATORIO.WS02.WS02_NRENDOCA);

            /*" -2183- MOVE WS02 TO LD02-MENSAGEM. */
            _.Move(AUX_RELATORIO.WS02, AUX_RELATORIO.LD02.LD02_MENSAGEM);

            /*" -2184- WRITE REG-SAIDA02 FROM LD02. */
            _.Move(AUX_RELATORIO.LD02.GetMoveValues(), REG_SAIDA02);

            SAIDA02.Write(REG_SAIDA02.GetMoveValues().ToString());

            /*" -2184- ADD 1 TO GV-ARQUIVO02. */
            W.GV_ARQUIVO02.Value = W.GV_ARQUIVO02 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2050_99_SAIDA*/

        [StopWatch]
        /*" R2190-00-TRATA-RCAPCOMP-SECTION */
        private void R2190_00_TRATA_RCAPCOMP_SECTION()
        {
            /*" -2197- MOVE '2190' TO WNR-EXEC-SQL. */
            _.Move("2190", W.WABEND.WNR_EXEC_SQL);

            /*" -2198- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), W.WS_TIME);

            /*" -2199- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

            /*" -2200- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

            /*" -2201- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

            /*" -2202- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

            /*" -2203- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

            /*" -2205- DISPLAY 'LEITURA RCAPCOMP  ' WTIME-DAYR. */
            _.Display($"LEITURA RCAPCOMP  {W.FILLER_4.WTIME_DAYR}");

            /*" -2206- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", W.WFIM_MOVIMENTO);

            /*" -2208- PERFORM R2200-00-DECLARE-RCAPCOMP. */

            R2200_00_DECLARE_RCAPCOMP_SECTION();

            /*" -2210- PERFORM R2210-00-FETCH-RCAPCOMP. */

            R2210_00_FETCH_RCAPCOMP_SECTION();

            /*" -2213- PERFORM R2220-00-PROCESSA-RCAPCOMP UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!W.WFIM_MOVIMENTO.IsEmpty()))
            {

                R2220_00_PROCESSA_RCAPCOMP_SECTION();
            }

            /*" -2214- DISPLAY ' ' . */
            _.Display($" ");

            /*" -2215- DISPLAY 'LIDOS RCAPCOMP ............. ' LD-RCAPCOMP. */
            _.Display($"LIDOS RCAPCOMP ............. {W.LD_RCAPCOMP}");

            /*" -2216- DISPLAY 'GRAVADOS SORT .............. ' GV-SORT. */
            _.Display($"GRAVADOS SORT .............. {W.GV_SORT}");

            /*" -2218- DISPLAY ' ' . */
            _.Display($" ");

            /*" -2218- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2190_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-DECLARE-RCAPCOMP-SECTION */
        private void R2200_00_DECLARE_RCAPCOMP_SECTION()
        {
            /*" -2231- MOVE '2200' TO WNR-EXEC-SQL. */
            _.Move("2200", W.WABEND.WNR_EXEC_SQL);

            /*" -2243- PERFORM R2200_00_DECLARE_RCAPCOMP_DB_DECLARE_1 */

            R2200_00_DECLARE_RCAPCOMP_DB_DECLARE_1();

            /*" -2245- PERFORM R2200_00_DECLARE_RCAPCOMP_DB_OPEN_1 */

            R2200_00_DECLARE_RCAPCOMP_DB_OPEN_1();

            /*" -2249- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2250- DISPLAY 'R2200-00 - PROBLEMAS DECLARE (RCAPCOMP)   ' */
                _.Display($"R2200-00 - PROBLEMAS DECLARE (RCAPCOMP)   ");

                /*" -2250- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2200-00-DECLARE-RCAPCOMP-DB-OPEN-1 */
        public void R2200_00_DECLARE_RCAPCOMP_DB_OPEN_1()
        {
            /*" -2245- EXEC SQL OPEN V0RCAPCOMP END-EXEC. */

            V0RCAPCOMP.Open();

        }

        [StopWatch]
        /*" R2600-00-DECLARE-RELATORI-DB-DECLARE-1 */
        public void R2600_00_DECLARE_RELATORI_DB_DECLARE_1()
        {
            /*" -2569- EXEC SQL DECLARE V1RELATORI CURSOR WITH HOLD FOR SELECT A.RAMO_EMISSOR ,A.NUM_APOLICE ,A.NUM_TITULO ,A.IND_PREV_DEFINIT ,A.IND_ANAL_RESUMO FROM SEGUROS.RELATORIOS A ,SEGUROS.BILHETE B ,SEGUROS.RCAPS C WHERE A.COD_RELATORIO = 'BI16A' AND A.DATA_SOLICITACAO >= :V1SIST-DTMOVABE-1Y AND A.RAMO_EMISSOR NOT IN (14,72) AND B.NUM_BILHETE = A.NUM_TITULO AND B.SITUACAO = '9' AND C.NUM_TITULO = A.NUM_TITULO AND C.SIT_REGISTRO = '1' AND C.COD_OPERACAO <> 210 GROUP BY A.RAMO_EMISSOR ,A.NUM_APOLICE ,A.NUM_TITULO ,A.IND_PREV_DEFINIT ,A.IND_ANAL_RESUMO END-EXEC. */
            V1RELATORI = new BI7401B_V1RELATORI(true);
            string GetQuery_V1RELATORI()
            {
                var query = @$"SELECT A.RAMO_EMISSOR 
							,A.NUM_APOLICE 
							,A.NUM_TITULO 
							,A.IND_PREV_DEFINIT 
							,A.IND_ANAL_RESUMO 
							FROM SEGUROS.RELATORIOS A 
							,SEGUROS.BILHETE B 
							,SEGUROS.RCAPS C 
							WHERE A.COD_RELATORIO = 'BI16A' 
							AND A.DATA_SOLICITACAO >= '{V1SIST_DTMOVABE_1Y}' 
							AND A.RAMO_EMISSOR NOT IN (14
							,72) 
							AND B.NUM_BILHETE = A.NUM_TITULO 
							AND B.SITUACAO = '9' 
							AND C.NUM_TITULO = A.NUM_TITULO 
							AND C.SIT_REGISTRO = '1' 
							AND C.COD_OPERACAO <> 210 
							GROUP BY A.RAMO_EMISSOR 
							,A.NUM_APOLICE 
							,A.NUM_TITULO 
							,A.IND_PREV_DEFINIT 
							,A.IND_ANAL_RESUMO";

                return query;
            }
            V1RELATORI.GetQueryEvent += GetQuery_V1RELATORI;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2210-00-FETCH-RCAPCOMP-SECTION */
        private void R2210_00_FETCH_RCAPCOMP_SECTION()
        {
            /*" -2263- MOVE '2210' TO WNR-EXEC-SQL. */
            _.Move("2210", W.WABEND.WNR_EXEC_SQL);

            /*" -2268- PERFORM R2210_00_FETCH_RCAPCOMP_DB_FETCH_1 */

            R2210_00_FETCH_RCAPCOMP_DB_FETCH_1();

            /*" -2272- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2272- PERFORM R2210_00_FETCH_RCAPCOMP_DB_CLOSE_1 */

                R2210_00_FETCH_RCAPCOMP_DB_CLOSE_1();

                /*" -2274- MOVE 'S' TO WFIM-MOVIMENTO */
                _.Move("S", W.WFIM_MOVIMENTO);

                /*" -2276- GO TO R2210-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2210_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2277- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2278- DISPLAY 'R2210-00 - PROBLEMAS FETCH   (RCAPCOMP)   ' */
                _.Display($"R2210-00 - PROBLEMAS FETCH   (RCAPCOMP)   ");

                /*" -2281- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2284- ADD 1 TO LD-RCAPCOMP. */
            W.LD_RCAPCOMP.Value = W.LD_RCAPCOMP + 1;

            /*" -2286- MOVE LD-RCAPCOMP TO AC-LIDOS. */
            _.Move(W.LD_RCAPCOMP, W.AC_LIDOS);

            /*" -2288- IF LD-PARTE2 EQUAL ZEROS OR LD-PARTE2 EQUAL 5000 */

            if (W.FILLER_0.LD_PARTE2 == 00 || W.FILLER_0.LD_PARTE2 == 5000)
            {

                /*" -2289- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), W.WS_TIME);

                /*" -2290- MOVE WS-HH-TIME TO WTIME-HORA */
                _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

                /*" -2291- MOVE '.' TO WTIME-2PT1 */
                _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

                /*" -2292- MOVE WS-MM-TIME TO WTIME-MINU */
                _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

                /*" -2293- MOVE '.' TO WTIME-2PT2 */
                _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

                /*" -2294- MOVE WS-SS-TIME TO WTIME-SEGU */
                _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

                /*" -2295- DISPLAY 'LIDOS RCAPCOMP     ' AC-LIDOS '    ' WTIME-DAYR. */

                $"LIDOS RCAPCOMP     {W.AC_LIDOS}    {W.FILLER_4.WTIME_DAYR}"
                .Display();
            }


        }

        [StopWatch]
        /*" R2210-00-FETCH-RCAPCOMP-DB-FETCH-1 */
        public void R2210_00_FETCH_RCAPCOMP_DB_FETCH_1()
        {
            /*" -2268- EXEC SQL FETCH V0RCAPCOMP INTO :RCAPCOMP-COD-FONTE ,:RCAPCOMP-NUM-RCAP ,:RCAPCOMP-NUM-RCAP-COMPLEMEN ,:HOST-COUNT END-EXEC. */

            if (V0RCAPCOMP.Fetch())
            {
                _.Move(V0RCAPCOMP.RCAPCOMP_COD_FONTE, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_FONTE);
                _.Move(V0RCAPCOMP.RCAPCOMP_NUM_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP);
                _.Move(V0RCAPCOMP.RCAPCOMP_NUM_RCAP_COMPLEMEN, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP_COMPLEMEN);
                _.Move(V0RCAPCOMP.HOST_COUNT, HOST_COUNT);
            }

        }

        [StopWatch]
        /*" R2210-00-FETCH-RCAPCOMP-DB-CLOSE-1 */
        public void R2210_00_FETCH_RCAPCOMP_DB_CLOSE_1()
        {
            /*" -2272- EXEC SQL CLOSE V0RCAPCOMP END-EXEC */

            V0RCAPCOMP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2210_99_SAIDA*/

        [StopWatch]
        /*" R2220-00-PROCESSA-RCAPCOMP-SECTION */
        private void R2220_00_PROCESSA_RCAPCOMP_SECTION()
        {
            /*" -2308- MOVE '2220' TO WNR-EXEC-SQL. */
            _.Move("2220", W.WABEND.WNR_EXEC_SQL);

            /*" -2310- MOVE 1 TO SOR-NRSEQ. */
            _.Move(1, REG_SBI7401B.SOR_NRSEQ);

            /*" -2317- MOVE SPACES TO SOR-DTCANCEL SOR-SEGURADO SOR-DTVENDA SOR-TIPO-ENDOSSO SOR-IND-DEFINIT SOR-IND-RESUMO SOR-PARCELADO. */
            _.Move("", REG_SBI7401B.SOR_DTCANCEL, REG_SBI7401B.SOR_SEGURADO, REG_SBI7401B.SOR_DTVENDA, REG_SBI7401B.SOR_TIPO_ENDOSSO, REG_SBI7401B.SOR_IND_DEFINIT, REG_SBI7401B.SOR_IND_RESUMO, REG_SBI7401B.SOR_PARCELADO);

            /*" -2334- MOVE ZEROS TO SOR-BILHETE SOR-APOLICE SOR-ENDOSSO SOR-PARCELA SOR-RAMO SOR-PRODUTO SOR-AGEVENDA SOR-VALOR SOR-CGCCPF SOR-BCOAVISO SOR-AGEAVISO SOR-NRAVISO SOR-FONTE SOR-NRRCAP SOR-OPERACAO SOR-PROPOSTA. */
            _.Move(0, REG_SBI7401B.SOR_BILHETE, REG_SBI7401B.SOR_APOLICE, REG_SBI7401B.SOR_ENDOSSO, REG_SBI7401B.SOR_PARCELA, REG_SBI7401B.SOR_RAMO, REG_SBI7401B.SOR_PRODUTO, REG_SBI7401B.SOR_AGEVENDA, REG_SBI7401B.SOR_VALOR, REG_SBI7401B.SOR_CGCCPF, REG_SBI7401B.SOR_BCOAVISO, REG_SBI7401B.SOR_AGEAVISO, REG_SBI7401B.SOR_NRAVISO, REG_SBI7401B.SOR_FONTE, REG_SBI7401B.SOR_NRRCAP, REG_SBI7401B.SOR_OPERACAO, REG_SBI7401B.SOR_PROPOSTA);

            /*" -2336- MOVE RCAPCOMP-COD-FONTE TO SOR-FONTE. */
            _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_FONTE, REG_SBI7401B.SOR_FONTE);

            /*" -2340- MOVE RCAPCOMP-NUM-RCAP TO SOR-NRRCAP. */
            _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP, REG_SBI7401B.SOR_NRRCAP);

            /*" -2343- PERFORM R2250-00-SELECT-RCAPS. */

            R2250_00_SELECT_RCAPS_SECTION();

            /*" -2344- RELEASE REG-SBI7401B. */
            SBI7401B.Release(REG_SBI7401B);

            /*" -2344- ADD 1 TO GV-SORT. */
            W.GV_SORT.Value = W.GV_SORT + 1;

            /*" -0- FLUXCONTROL_PERFORM R2220_90_LEITURA */

            R2220_90_LEITURA();

        }

        [StopWatch]
        /*" R2220-90-LEITURA */
        private void R2220_90_LEITURA(bool isPerform = false)
        {
            /*" -2349- PERFORM R2210-00-FETCH-RCAPCOMP. */

            R2210_00_FETCH_RCAPCOMP_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2220_99_SAIDA*/

        [StopWatch]
        /*" R2250-00-SELECT-RCAPS-SECTION */
        private void R2250_00_SELECT_RCAPS_SECTION()
        {
            /*" -2361- MOVE '2250' TO WNR-EXEC-SQL. */
            _.Move("2250", W.WABEND.WNR_EXEC_SQL);

            /*" -2371- PERFORM R2250_00_SELECT_RCAPS_DB_SELECT_1 */

            R2250_00_SELECT_RCAPS_DB_SELECT_1();

            /*" -2375- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2377- MOVE ZEROS TO SOR-OPERACAO */
                _.Move(0, REG_SBI7401B.SOR_OPERACAO);

                /*" -2378- ELSE */
            }
            else
            {


                /*" -2379- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2380- DISPLAY 'R2250-00 - PROBLEMAS NO SELECT(RCAPS)   ' */
                    _.Display($"R2250-00 - PROBLEMAS NO SELECT(RCAPS)   ");

                    /*" -2381- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2382- ELSE */
                }
                else
                {


                    /*" -2383- MOVE RCAPS-COD-OPERACAO TO SOR-OPERACAO. */
                    _.Move(RCAPS.DCLRCAPS.RCAPS_COD_OPERACAO, REG_SBI7401B.SOR_OPERACAO);
                }

            }


        }

        [StopWatch]
        /*" R2250-00-SELECT-RCAPS-DB-SELECT-1 */
        public void R2250_00_SELECT_RCAPS_DB_SELECT_1()
        {
            /*" -2371- EXEC SQL SELECT SIT_REGISTRO ,COD_OPERACAO INTO :RCAPS-SIT-REGISTRO ,:RCAPS-COD-OPERACAO FROM SEGUROS.RCAPS WHERE COD_FONTE = :RCAPCOMP-COD-FONTE AND NUM_RCAP = :RCAPCOMP-NUM-RCAP FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r2250_00_SELECT_RCAPS_DB_SELECT_1_Query1 = new R2250_00_SELECT_RCAPS_DB_SELECT_1_Query1()
            {
                RCAPCOMP_COD_FONTE = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_FONTE.ToString(),
                RCAPCOMP_NUM_RCAP = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP.ToString(),
            };

            var executed_1 = R2250_00_SELECT_RCAPS_DB_SELECT_1_Query1.Execute(r2250_00_SELECT_RCAPS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_SIT_REGISTRO, RCAPS.DCLRCAPS.RCAPS_SIT_REGISTRO);
                _.Move(executed_1.RCAPS_COD_OPERACAO, RCAPS.DCLRCAPS.RCAPS_COD_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2250_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-TRATA-RCAPS-SECTION */
        private void R2500_00_TRATA_RCAPS_SECTION()
        {
            /*" -2396- MOVE '2500' TO WNR-EXEC-SQL. */
            _.Move("2500", W.WABEND.WNR_EXEC_SQL);

            /*" -2398- MOVE SOR-FONTE TO RCAPS-COD-FONTE. */
            _.Move(REG_SBI7401B.SOR_FONTE, RCAPS.DCLRCAPS.RCAPS_COD_FONTE);

            /*" -2400- MOVE SOR-NRRCAP TO RCAPS-NUM-RCAP. */
            _.Move(REG_SBI7401B.SOR_NRRCAP, RCAPS.DCLRCAPS.RCAPS_NUM_RCAP);

            /*" -2404- MOVE SOR-OPERACAO TO RCAPS-COD-OPERACAO. */
            _.Move(REG_SBI7401B.SOR_OPERACAO, RCAPS.DCLRCAPS.RCAPS_COD_OPERACAO);

            /*" -2407- IF RCAPS-COD-OPERACAO EQUAL 200 OR 210 OR 220 */

            if (RCAPS.DCLRCAPS.RCAPS_COD_OPERACAO.In("200", "210", "220"))
            {

                /*" -2409- MOVE '1' TO RCAPS-SIT-REGISTRO */
                _.Move("1", RCAPS.DCLRCAPS.RCAPS_SIT_REGISTRO);

                /*" -2410- ELSE */
            }
            else
            {


                /*" -2411- IF RCAPS-COD-OPERACAO EQUAL 400 */

                if (RCAPS.DCLRCAPS.RCAPS_COD_OPERACAO == 400)
                {

                    /*" -2413- MOVE '2' TO RCAPS-SIT-REGISTRO */
                    _.Move("2", RCAPS.DCLRCAPS.RCAPS_SIT_REGISTRO);

                    /*" -2414- ELSE */
                }
                else
                {


                    /*" -2415- IF RCAPS-COD-OPERACAO NOT EQUAL ZEROS */

                    if (RCAPS.DCLRCAPS.RCAPS_COD_OPERACAO != 00)
                    {

                        /*" -2417- MOVE '0' TO RCAPS-SIT-REGISTRO */
                        _.Move("0", RCAPS.DCLRCAPS.RCAPS_SIT_REGISTRO);

                        /*" -2418- ELSE */
                    }
                    else
                    {


                        /*" -2421- GO TO R2500-99-SAIDA. */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/ //GOTO
                        return;
                    }

                }

            }


            /*" -2423- PERFORM R2530-00-UPDATE-RCAP. */

            R2530_00_UPDATE_RCAP_SECTION();

            /*" -2423- PERFORM R2540-00-UPDATE-RCAPCOMP. */

            R2540_00_UPDATE_RCAPCOMP_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R2530-00-UPDATE-RCAP-SECTION */
        private void R2530_00_UPDATE_RCAP_SECTION()
        {
            /*" -2436- MOVE '2530' TO WNR-EXEC-SQL. */
            _.Move("2530", W.WABEND.WNR_EXEC_SQL);

            /*" -2441- PERFORM R2530_00_UPDATE_RCAP_DB_UPDATE_1 */

            R2530_00_UPDATE_RCAP_DB_UPDATE_1();

            /*" -2445- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -2446- DISPLAY 'R2530-00 - PROBLEMAS UPDATE (RCAPS)   ' */
                _.Display($"R2530-00 - PROBLEMAS UPDATE (RCAPS)   ");

                /*" -2446- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2530-00-UPDATE-RCAP-DB-UPDATE-1 */
        public void R2530_00_UPDATE_RCAP_DB_UPDATE_1()
        {
            /*" -2441- EXEC SQL UPDATE SEGUROS.RCAPS SET SIT_REGISTRO = :RCAPS-SIT-REGISTRO WHERE COD_FONTE = :RCAPS-COD-FONTE AND NUM_RCAP = :RCAPS-NUM-RCAP END-EXEC. */

            var r2530_00_UPDATE_RCAP_DB_UPDATE_1_Update1 = new R2530_00_UPDATE_RCAP_DB_UPDATE_1_Update1()
            {
                RCAPS_SIT_REGISTRO = RCAPS.DCLRCAPS.RCAPS_SIT_REGISTRO.ToString(),
                RCAPS_COD_FONTE = RCAPS.DCLRCAPS.RCAPS_COD_FONTE.ToString(),
                RCAPS_NUM_RCAP = RCAPS.DCLRCAPS.RCAPS_NUM_RCAP.ToString(),
            };

            R2530_00_UPDATE_RCAP_DB_UPDATE_1_Update1.Execute(r2530_00_UPDATE_RCAP_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2530_99_SAIDA*/

        [StopWatch]
        /*" R2540-00-UPDATE-RCAPCOMP-SECTION */
        private void R2540_00_UPDATE_RCAPCOMP_SECTION()
        {
            /*" -2459- MOVE '2540' TO WNR-EXEC-SQL. */
            _.Move("2540", W.WABEND.WNR_EXEC_SQL);

            /*" -2466- PERFORM R2540_00_UPDATE_RCAPCOMP_DB_UPDATE_1 */

            R2540_00_UPDATE_RCAPCOMP_DB_UPDATE_1();

            /*" -2470- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -2471- DISPLAY 'R2540-00 - PROBLEMAS UPDATE (RCAPCOMP)' */
                _.Display($"R2540-00 - PROBLEMAS UPDATE (RCAPCOMP)");

                /*" -2471- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2540-00-UPDATE-RCAPCOMP-DB-UPDATE-1 */
        public void R2540_00_UPDATE_RCAPCOMP_DB_UPDATE_1()
        {
            /*" -2466- EXEC SQL UPDATE SEGUROS.RCAP_COMPLEMENTAR SET SIT_REGISTRO = '1' WHERE COD_FONTE = :RCAPS-COD-FONTE AND NUM_RCAP = :RCAPS-NUM-RCAP AND NUM_RCAP_COMPLEMEN = 0 AND COD_OPERACAO <> :RCAPS-COD-OPERACAO END-EXEC. */

            var r2540_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1 = new R2540_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1()
            {
                RCAPS_COD_OPERACAO = RCAPS.DCLRCAPS.RCAPS_COD_OPERACAO.ToString(),
                RCAPS_COD_FONTE = RCAPS.DCLRCAPS.RCAPS_COD_FONTE.ToString(),
                RCAPS_NUM_RCAP = RCAPS.DCLRCAPS.RCAPS_NUM_RCAP.ToString(),
            };

            R2540_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1.Execute(r2540_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2540_99_SAIDA*/

        [StopWatch]
        /*" R2590-00-TRATA-BI16A-SECTION */
        private void R2590_00_TRATA_BI16A_SECTION()
        {
            /*" -2484- MOVE '2590' TO WNR-EXEC-SQL. */
            _.Move("2590", W.WABEND.WNR_EXEC_SQL);

            /*" -2485- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), W.WS_TIME);

            /*" -2486- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

            /*" -2487- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

            /*" -2488- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

            /*" -2489- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

            /*" -2490- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

            /*" -2492- DISPLAY 'LEITURA BI16A - SIT9 ' WTIME-DAYR. */
            _.Display($"LEITURA BI16A - SIT9 {W.FILLER_4.WTIME_DAYR}");

            /*" -2494- MOVE ZEROS TO GV-SORT LD-RELATORI. */
            _.Move(0, W.GV_SORT, W.LD_RELATORI);

            /*" -2495- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", W.WFIM_MOVIMENTO);

            /*" -2497- PERFORM R2600-00-DECLARE-RELATORI. */

            R2600_00_DECLARE_RELATORI_SECTION();

            /*" -2499- PERFORM R2610-00-FETCH-RELATORI. */

            R2610_00_FETCH_RELATORI_SECTION();

            /*" -2502- PERFORM R2620-00-PROCESSA-RELATORI UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!W.WFIM_MOVIMENTO.IsEmpty()))
            {

                R2620_00_PROCESSA_RELATORI_SECTION();
            }

            /*" -2503- DISPLAY ' ' . */
            _.Display($" ");

            /*" -2504- DISPLAY 'LIDOS RELATORI ............. ' LD-RELATORI. */
            _.Display($"LIDOS RELATORI ............. {W.LD_RELATORI}");

            /*" -2505- DISPLAY 'GRAVADOS SORT .............. ' GV-SORT. */
            _.Display($"GRAVADOS SORT .............. {W.GV_SORT}");

            /*" -2507- DISPLAY ' ' . */
            _.Display($" ");

            /*" -2507- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -2511- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), W.WS_TIME);

            /*" -2512- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

            /*" -2513- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

            /*" -2514- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

            /*" -2515- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

            /*" -2516- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

            /*" -2518- DISPLAY 'LEITURA BI16A - SIT8 ' WTIME-DAYR. */
            _.Display($"LEITURA BI16A - SIT8 {W.FILLER_4.WTIME_DAYR}");

            /*" -2520- MOVE ZEROS TO GV-SORT LD-RELATORI. */
            _.Move(0, W.GV_SORT, W.LD_RELATORI);

            /*" -2521- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", W.WFIM_MOVIMENTO);

            /*" -2523- PERFORM R2650-00-DECLARE-RELATORI. */

            R2650_00_DECLARE_RELATORI_SECTION();

            /*" -2525- PERFORM R2660-00-FETCH-RELATORI. */

            R2660_00_FETCH_RELATORI_SECTION();

            /*" -2528- PERFORM R2670-00-PROCESSA-RELATORI UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!W.WFIM_MOVIMENTO.IsEmpty()))
            {

                R2670_00_PROCESSA_RELATORI_SECTION();
            }

            /*" -2529- DISPLAY ' ' . */
            _.Display($" ");

            /*" -2530- DISPLAY 'LIDOS RELATORI ............. ' LD-RELATORI. */
            _.Display($"LIDOS RELATORI ............. {W.LD_RELATORI}");

            /*" -2531- DISPLAY 'GRAVADOS SORT .............. ' GV-SORT. */
            _.Display($"GRAVADOS SORT .............. {W.GV_SORT}");

            /*" -2533- DISPLAY ' ' . */
            _.Display($" ");

            /*" -2533- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2590_99_SAIDA*/

        [StopWatch]
        /*" R2600-00-DECLARE-RELATORI-SECTION */
        private void R2600_00_DECLARE_RELATORI_SECTION()
        {
            /*" -2546- MOVE '2600' TO WNR-EXEC-SQL. */
            _.Move("2600", W.WABEND.WNR_EXEC_SQL);

            /*" -2569- PERFORM R2600_00_DECLARE_RELATORI_DB_DECLARE_1 */

            R2600_00_DECLARE_RELATORI_DB_DECLARE_1();

            /*" -2571- PERFORM R2600_00_DECLARE_RELATORI_DB_OPEN_1 */

            R2600_00_DECLARE_RELATORI_DB_OPEN_1();

            /*" -2575- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2576- DISPLAY 'R2600-00 - PROBLEMAS DECLARE (RELATORI)   ' */
                _.Display($"R2600-00 - PROBLEMAS DECLARE (RELATORI)   ");

                /*" -2576- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2600-00-DECLARE-RELATORI-DB-OPEN-1 */
        public void R2600_00_DECLARE_RELATORI_DB_OPEN_1()
        {
            /*" -2571- EXEC SQL OPEN V1RELATORI END-EXEC. */

            V1RELATORI.Open();

        }

        [StopWatch]
        /*" R2650-00-DECLARE-RELATORI-DB-DECLARE-1 */
        public void R2650_00_DECLARE_RELATORI_DB_DECLARE_1()
        {
            /*" -2732- EXEC SQL DECLARE V2RELATORI CURSOR WITH HOLD FOR SELECT A.RAMO_EMISSOR ,A.NUM_APOLICE ,A.NUM_TITULO ,A.IND_PREV_DEFINIT ,A.IND_ANAL_RESUMO FROM SEGUROS.RELATORIOS A ,SEGUROS.BILHETE B ,SEGUROS.RCAPS C WHERE A.COD_RELATORIO = 'BI16A' AND A.DATA_SOLICITACAO = :SISTEMAS-DATA-MOV-ABERTO AND A.RAMO_EMISSOR NOT IN (14,72) AND B.NUM_BILHETE = A.NUM_TITULO AND B.SITUACAO = '8' AND B.DATA_CANCELAMENTO = :SISTEMAS-DATA-MOV-ABERTO AND C.NUM_TITULO = A.NUM_TITULO AND C.SIT_REGISTRO = '1' AND C.COD_OPERACAO <> 210 GROUP BY A.RAMO_EMISSOR ,A.NUM_APOLICE ,A.NUM_TITULO ,A.IND_PREV_DEFINIT ,A.IND_ANAL_RESUMO END-EXEC. */
            V2RELATORI = new BI7401B_V2RELATORI(true);
            string GetQuery_V2RELATORI()
            {
                var query = @$"SELECT A.RAMO_EMISSOR 
							,A.NUM_APOLICE 
							,A.NUM_TITULO 
							,A.IND_PREV_DEFINIT 
							,A.IND_ANAL_RESUMO 
							FROM SEGUROS.RELATORIOS A 
							,SEGUROS.BILHETE B 
							,SEGUROS.RCAPS C 
							WHERE A.COD_RELATORIO = 'BI16A' 
							AND A.DATA_SOLICITACAO = '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND A.RAMO_EMISSOR NOT IN (14
							,72) 
							AND B.NUM_BILHETE = A.NUM_TITULO 
							AND B.SITUACAO = '8' 
							AND B.DATA_CANCELAMENTO = '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND C.NUM_TITULO = A.NUM_TITULO 
							AND C.SIT_REGISTRO = '1' 
							AND C.COD_OPERACAO <> 210 
							GROUP BY A.RAMO_EMISSOR 
							,A.NUM_APOLICE 
							,A.NUM_TITULO 
							,A.IND_PREV_DEFINIT 
							,A.IND_ANAL_RESUMO";

                return query;
            }
            V2RELATORI.GetQueryEvent += GetQuery_V2RELATORI;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2600_99_SAIDA*/

        [StopWatch]
        /*" R2610-00-FETCH-RELATORI-SECTION */
        private void R2610_00_FETCH_RELATORI_SECTION()
        {
            /*" -2589- MOVE '2610' TO WNR-EXEC-SQL. */
            _.Move("2610", W.WABEND.WNR_EXEC_SQL);

            /*" -2595- PERFORM R2610_00_FETCH_RELATORI_DB_FETCH_1 */

            R2610_00_FETCH_RELATORI_DB_FETCH_1();

            /*" -2599- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2599- PERFORM R2610_00_FETCH_RELATORI_DB_CLOSE_1 */

                R2610_00_FETCH_RELATORI_DB_CLOSE_1();

                /*" -2601- MOVE 'S' TO WFIM-MOVIMENTO */
                _.Move("S", W.WFIM_MOVIMENTO);

                /*" -2603- GO TO R2610-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2610_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2604- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2605- DISPLAY 'R2610-00 - PROBLEMAS FETCH   (RELATORI)   ' */
                _.Display($"R2610-00 - PROBLEMAS FETCH   (RELATORI)   ");

                /*" -2608- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2611- ADD 1 TO LD-RELATORI. */
            W.LD_RELATORI.Value = W.LD_RELATORI + 1;

            /*" -2613- MOVE LD-RELATORI TO AC-LIDOS. */
            _.Move(W.LD_RELATORI, W.AC_LIDOS);

            /*" -2615- IF LD-PARTE2 EQUAL ZEROS OR LD-PARTE2 EQUAL 5000 */

            if (W.FILLER_0.LD_PARTE2 == 00 || W.FILLER_0.LD_PARTE2 == 5000)
            {

                /*" -2616- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), W.WS_TIME);

                /*" -2617- MOVE WS-HH-TIME TO WTIME-HORA */
                _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

                /*" -2618- MOVE '.' TO WTIME-2PT1 */
                _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

                /*" -2619- MOVE WS-MM-TIME TO WTIME-MINU */
                _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

                /*" -2620- MOVE '.' TO WTIME-2PT2 */
                _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

                /*" -2621- MOVE WS-SS-TIME TO WTIME-SEGU */
                _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

                /*" -2622- DISPLAY 'LIDOS BI16A        ' AC-LIDOS '    ' WTIME-DAYR. */

                $"LIDOS BI16A        {W.AC_LIDOS}    {W.FILLER_4.WTIME_DAYR}"
                .Display();
            }


        }

        [StopWatch]
        /*" R2610-00-FETCH-RELATORI-DB-FETCH-1 */
        public void R2610_00_FETCH_RELATORI_DB_FETCH_1()
        {
            /*" -2595- EXEC SQL FETCH V1RELATORI INTO :RELATORI-RAMO-EMISSOR ,:RELATORI-NUM-APOLICE ,:RELATORI-NUM-TITULO ,:RELATORI-IND-PREV-DEFINIT ,:RELATORI-IND-ANAL-RESUMO END-EXEC. */

            if (V1RELATORI.Fetch())
            {
                _.Move(V1RELATORI.RELATORI_RAMO_EMISSOR, RELATORI.DCLRELATORIOS.RELATORI_RAMO_EMISSOR);
                _.Move(V1RELATORI.RELATORI_NUM_APOLICE, RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE);
                _.Move(V1RELATORI.RELATORI_NUM_TITULO, RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO);
                _.Move(V1RELATORI.RELATORI_IND_PREV_DEFINIT, RELATORI.DCLRELATORIOS.RELATORI_IND_PREV_DEFINIT);
                _.Move(V1RELATORI.RELATORI_IND_ANAL_RESUMO, RELATORI.DCLRELATORIOS.RELATORI_IND_ANAL_RESUMO);
            }

        }

        [StopWatch]
        /*" R2610-00-FETCH-RELATORI-DB-CLOSE-1 */
        public void R2610_00_FETCH_RELATORI_DB_CLOSE_1()
        {
            /*" -2599- EXEC SQL CLOSE V1RELATORI END-EXEC */

            V1RELATORI.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2610_99_SAIDA*/

        [StopWatch]
        /*" R2620-00-PROCESSA-RELATORI-SECTION */
        private void R2620_00_PROCESSA_RELATORI_SECTION()
        {
            /*" -2635- MOVE '2620' TO WNR-EXEC-SQL. */
            _.Move("2620", W.WABEND.WNR_EXEC_SQL);

            /*" -2637- MOVE 3 TO SOR-NRSEQ. */
            _.Move(3, REG_SBI7401B.SOR_NRSEQ);

            /*" -2644- MOVE SPACES TO SOR-DTCANCEL SOR-SEGURADO SOR-DTVENDA SOR-TIPO-ENDOSSO SOR-IND-DEFINIT SOR-IND-RESUMO SOR-PARCELADO. */
            _.Move("", REG_SBI7401B.SOR_DTCANCEL, REG_SBI7401B.SOR_SEGURADO, REG_SBI7401B.SOR_DTVENDA, REG_SBI7401B.SOR_TIPO_ENDOSSO, REG_SBI7401B.SOR_IND_DEFINIT, REG_SBI7401B.SOR_IND_RESUMO, REG_SBI7401B.SOR_PARCELADO);

            /*" -2661- MOVE ZEROS TO SOR-BILHETE SOR-APOLICE SOR-ENDOSSO SOR-PARCELA SOR-RAMO SOR-PRODUTO SOR-AGEVENDA SOR-VALOR SOR-CGCCPF SOR-BCOAVISO SOR-AGEAVISO SOR-NRAVISO SOR-FONTE SOR-NRRCAP SOR-OPERACAO SOR-PROPOSTA. */
            _.Move(0, REG_SBI7401B.SOR_BILHETE, REG_SBI7401B.SOR_APOLICE, REG_SBI7401B.SOR_ENDOSSO, REG_SBI7401B.SOR_PARCELA, REG_SBI7401B.SOR_RAMO, REG_SBI7401B.SOR_PRODUTO, REG_SBI7401B.SOR_AGEVENDA, REG_SBI7401B.SOR_VALOR, REG_SBI7401B.SOR_CGCCPF, REG_SBI7401B.SOR_BCOAVISO, REG_SBI7401B.SOR_AGEAVISO, REG_SBI7401B.SOR_NRAVISO, REG_SBI7401B.SOR_FONTE, REG_SBI7401B.SOR_NRRCAP, REG_SBI7401B.SOR_OPERACAO, REG_SBI7401B.SOR_PROPOSTA);

            /*" -2663- MOVE RELATORI-NUM-APOLICE TO SOR-APOLICE. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE, REG_SBI7401B.SOR_APOLICE);

            /*" -2665- MOVE RELATORI-RAMO-EMISSOR TO SOR-RAMO. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_RAMO_EMISSOR, REG_SBI7401B.SOR_RAMO);

            /*" -2667- MOVE RELATORI-NUM-TITULO TO SOR-BILHETE. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO, REG_SBI7401B.SOR_BILHETE);

            /*" -2669- MOVE RELATORI-IND-PREV-DEFINIT TO SOR-IND-DEFINIT. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_IND_PREV_DEFINIT, REG_SBI7401B.SOR_IND_DEFINIT);

            /*" -2673- MOVE RELATORI-IND-ANAL-RESUMO TO SOR-IND-RESUMO. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_IND_ANAL_RESUMO, REG_SBI7401B.SOR_IND_RESUMO);

            /*" -2675- PERFORM R0230-00-SELECT-APOLICES. */

            R0230_00_SELECT_APOLICES_SECTION();

            /*" -2677- PERFORM R0240-00-SELECT-ENDOSSOS. */

            R0240_00_SELECT_ENDOSSOS_SECTION();

            /*" -2680- PERFORM R0250-00-SELECT-ENDOSSOS. */

            R0250_00_SELECT_ENDOSSOS_SECTION();

            /*" -2681- IF SOR-TIPO-ENDOSSO EQUAL '5' */

            if (REG_SBI7401B.SOR_TIPO_ENDOSSO == "5")
            {

                /*" -2682- ADD 1 TO DP-BI16A */
                W.DP_BI16A.Value = W.DP_BI16A + 1;

                /*" -2685- GO TO R2620-90-LEITURA. */

                R2620_90_LEITURA(); //GOTO
                return;
            }


            /*" -2686- IF SOR-PARCELADO NOT EQUAL SPACES */

            if (!REG_SBI7401B.SOR_PARCELADO.IsEmpty())
            {

                /*" -2687- ADD 1 TO DP-BI16A */
                W.DP_BI16A.Value = W.DP_BI16A + 1;

                /*" -2690- GO TO R2620-90-LEITURA. */

                R2620_90_LEITURA(); //GOTO
                return;
            }


            /*" -2691- RELEASE REG-SBI7401B. */
            SBI7401B.Release(REG_SBI7401B);

            /*" -2691- ADD 1 TO GV-SORT. */
            W.GV_SORT.Value = W.GV_SORT + 1;

            /*" -0- FLUXCONTROL_PERFORM R2620_90_LEITURA */

            R2620_90_LEITURA();

        }

        [StopWatch]
        /*" R2620-90-LEITURA */
        private void R2620_90_LEITURA(bool isPerform = false)
        {
            /*" -2696- PERFORM R2610-00-FETCH-RELATORI. */

            R2610_00_FETCH_RELATORI_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2620_99_SAIDA*/

        [StopWatch]
        /*" R2650-00-DECLARE-RELATORI-SECTION */
        private void R2650_00_DECLARE_RELATORI_SECTION()
        {
            /*" -2708- MOVE '2650' TO WNR-EXEC-SQL. */
            _.Move("2650", W.WABEND.WNR_EXEC_SQL);

            /*" -2732- PERFORM R2650_00_DECLARE_RELATORI_DB_DECLARE_1 */

            R2650_00_DECLARE_RELATORI_DB_DECLARE_1();

            /*" -2734- PERFORM R2650_00_DECLARE_RELATORI_DB_OPEN_1 */

            R2650_00_DECLARE_RELATORI_DB_OPEN_1();

            /*" -2738- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2739- DISPLAY 'R2650-00 - PROBLEMAS DECLARE (RELATORI)   ' */
                _.Display($"R2650-00 - PROBLEMAS DECLARE (RELATORI)   ");

                /*" -2739- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2650-00-DECLARE-RELATORI-DB-OPEN-1 */
        public void R2650_00_DECLARE_RELATORI_DB_OPEN_1()
        {
            /*" -2734- EXEC SQL OPEN V2RELATORI END-EXEC. */

            V2RELATORI.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2650_99_SAIDA*/

        [StopWatch]
        /*" R2660-00-FETCH-RELATORI-SECTION */
        private void R2660_00_FETCH_RELATORI_SECTION()
        {
            /*" -2752- MOVE '2660' TO WNR-EXEC-SQL. */
            _.Move("2660", W.WABEND.WNR_EXEC_SQL);

            /*" -2758- PERFORM R2660_00_FETCH_RELATORI_DB_FETCH_1 */

            R2660_00_FETCH_RELATORI_DB_FETCH_1();

            /*" -2762- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2762- PERFORM R2660_00_FETCH_RELATORI_DB_CLOSE_1 */

                R2660_00_FETCH_RELATORI_DB_CLOSE_1();

                /*" -2764- MOVE 'S' TO WFIM-MOVIMENTO */
                _.Move("S", W.WFIM_MOVIMENTO);

                /*" -2766- GO TO R2660-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2660_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2767- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2768- DISPLAY 'R2660-00 - PROBLEMAS FETCH   (RELATORI)   ' */
                _.Display($"R2660-00 - PROBLEMAS FETCH   (RELATORI)   ");

                /*" -2771- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2774- ADD 1 TO LD-RELATORI. */
            W.LD_RELATORI.Value = W.LD_RELATORI + 1;

            /*" -2776- MOVE LD-RELATORI TO AC-LIDOS. */
            _.Move(W.LD_RELATORI, W.AC_LIDOS);

            /*" -2778- IF LD-PARTE2 EQUAL ZEROS OR LD-PARTE2 EQUAL 5000 */

            if (W.FILLER_0.LD_PARTE2 == 00 || W.FILLER_0.LD_PARTE2 == 5000)
            {

                /*" -2779- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), W.WS_TIME);

                /*" -2780- MOVE WS-HH-TIME TO WTIME-HORA */
                _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

                /*" -2781- MOVE '.' TO WTIME-2PT1 */
                _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

                /*" -2782- MOVE WS-MM-TIME TO WTIME-MINU */
                _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

                /*" -2783- MOVE '.' TO WTIME-2PT2 */
                _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

                /*" -2784- MOVE WS-SS-TIME TO WTIME-SEGU */
                _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

                /*" -2785- DISPLAY 'LIDOS BI16A        ' AC-LIDOS '    ' WTIME-DAYR. */

                $"LIDOS BI16A        {W.AC_LIDOS}    {W.FILLER_4.WTIME_DAYR}"
                .Display();
            }


        }

        [StopWatch]
        /*" R2660-00-FETCH-RELATORI-DB-FETCH-1 */
        public void R2660_00_FETCH_RELATORI_DB_FETCH_1()
        {
            /*" -2758- EXEC SQL FETCH V2RELATORI INTO :RELATORI-RAMO-EMISSOR ,:RELATORI-NUM-APOLICE ,:RELATORI-NUM-TITULO ,:RELATORI-IND-PREV-DEFINIT ,:RELATORI-IND-ANAL-RESUMO END-EXEC. */

            if (V2RELATORI.Fetch())
            {
                _.Move(V2RELATORI.RELATORI_RAMO_EMISSOR, RELATORI.DCLRELATORIOS.RELATORI_RAMO_EMISSOR);
                _.Move(V2RELATORI.RELATORI_NUM_APOLICE, RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE);
                _.Move(V2RELATORI.RELATORI_NUM_TITULO, RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO);
                _.Move(V2RELATORI.RELATORI_IND_PREV_DEFINIT, RELATORI.DCLRELATORIOS.RELATORI_IND_PREV_DEFINIT);
                _.Move(V2RELATORI.RELATORI_IND_ANAL_RESUMO, RELATORI.DCLRELATORIOS.RELATORI_IND_ANAL_RESUMO);
            }

        }

        [StopWatch]
        /*" R2660-00-FETCH-RELATORI-DB-CLOSE-1 */
        public void R2660_00_FETCH_RELATORI_DB_CLOSE_1()
        {
            /*" -2762- EXEC SQL CLOSE V2RELATORI END-EXEC */

            V2RELATORI.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2660_99_SAIDA*/

        [StopWatch]
        /*" R2670-00-PROCESSA-RELATORI-SECTION */
        private void R2670_00_PROCESSA_RELATORI_SECTION()
        {
            /*" -2798- MOVE '2670' TO WNR-EXEC-SQL. */
            _.Move("2670", W.WABEND.WNR_EXEC_SQL);

            /*" -2800- MOVE 3 TO SOR-NRSEQ. */
            _.Move(3, REG_SBI7401B.SOR_NRSEQ);

            /*" -2807- MOVE SPACES TO SOR-DTCANCEL SOR-SEGURADO SOR-DTVENDA SOR-TIPO-ENDOSSO SOR-IND-DEFINIT SOR-IND-RESUMO SOR-PARCELADO. */
            _.Move("", REG_SBI7401B.SOR_DTCANCEL, REG_SBI7401B.SOR_SEGURADO, REG_SBI7401B.SOR_DTVENDA, REG_SBI7401B.SOR_TIPO_ENDOSSO, REG_SBI7401B.SOR_IND_DEFINIT, REG_SBI7401B.SOR_IND_RESUMO, REG_SBI7401B.SOR_PARCELADO);

            /*" -2824- MOVE ZEROS TO SOR-BILHETE SOR-APOLICE SOR-ENDOSSO SOR-PARCELA SOR-RAMO SOR-PRODUTO SOR-AGEVENDA SOR-VALOR SOR-CGCCPF SOR-BCOAVISO SOR-AGEAVISO SOR-NRAVISO SOR-FONTE SOR-NRRCAP SOR-OPERACAO SOR-PROPOSTA. */
            _.Move(0, REG_SBI7401B.SOR_BILHETE, REG_SBI7401B.SOR_APOLICE, REG_SBI7401B.SOR_ENDOSSO, REG_SBI7401B.SOR_PARCELA, REG_SBI7401B.SOR_RAMO, REG_SBI7401B.SOR_PRODUTO, REG_SBI7401B.SOR_AGEVENDA, REG_SBI7401B.SOR_VALOR, REG_SBI7401B.SOR_CGCCPF, REG_SBI7401B.SOR_BCOAVISO, REG_SBI7401B.SOR_AGEAVISO, REG_SBI7401B.SOR_NRAVISO, REG_SBI7401B.SOR_FONTE, REG_SBI7401B.SOR_NRRCAP, REG_SBI7401B.SOR_OPERACAO, REG_SBI7401B.SOR_PROPOSTA);

            /*" -2826- MOVE RELATORI-NUM-APOLICE TO SOR-APOLICE. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE, REG_SBI7401B.SOR_APOLICE);

            /*" -2828- MOVE RELATORI-RAMO-EMISSOR TO SOR-RAMO. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_RAMO_EMISSOR, REG_SBI7401B.SOR_RAMO);

            /*" -2830- MOVE RELATORI-NUM-TITULO TO SOR-BILHETE. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO, REG_SBI7401B.SOR_BILHETE);

            /*" -2832- MOVE RELATORI-IND-PREV-DEFINIT TO SOR-IND-DEFINIT. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_IND_PREV_DEFINIT, REG_SBI7401B.SOR_IND_DEFINIT);

            /*" -2836- MOVE RELATORI-IND-ANAL-RESUMO TO SOR-IND-RESUMO. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_IND_ANAL_RESUMO, REG_SBI7401B.SOR_IND_RESUMO);

            /*" -2838- PERFORM R0230-00-SELECT-APOLICES. */

            R0230_00_SELECT_APOLICES_SECTION();

            /*" -2840- PERFORM R0240-00-SELECT-ENDOSSOS. */

            R0240_00_SELECT_ENDOSSOS_SECTION();

            /*" -2843- PERFORM R0250-00-SELECT-ENDOSSOS. */

            R0250_00_SELECT_ENDOSSOS_SECTION();

            /*" -2844- IF SOR-TIPO-ENDOSSO EQUAL '5' */

            if (REG_SBI7401B.SOR_TIPO_ENDOSSO == "5")
            {

                /*" -2845- ADD 1 TO DP-BI16A */
                W.DP_BI16A.Value = W.DP_BI16A + 1;

                /*" -2848- GO TO R2670-90-LEITURA. */

                R2670_90_LEITURA(); //GOTO
                return;
            }


            /*" -2849- IF SOR-PARCELADO NOT EQUAL SPACES */

            if (!REG_SBI7401B.SOR_PARCELADO.IsEmpty())
            {

                /*" -2850- ADD 1 TO DP-BI16A */
                W.DP_BI16A.Value = W.DP_BI16A + 1;

                /*" -2853- GO TO R2670-90-LEITURA. */

                R2670_90_LEITURA(); //GOTO
                return;
            }


            /*" -2854- RELEASE REG-SBI7401B. */
            SBI7401B.Release(REG_SBI7401B);

            /*" -2854- ADD 1 TO GV-SORT. */
            W.GV_SORT.Value = W.GV_SORT + 1;

            /*" -0- FLUXCONTROL_PERFORM R2670_90_LEITURA */

            R2670_90_LEITURA();

        }

        [StopWatch]
        /*" R2670-90-LEITURA */
        private void R2670_90_LEITURA(bool isPerform = false)
        {
            /*" -2859- PERFORM R2660-00-FETCH-RELATORI. */

            R2660_00_FETCH_RELATORI_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2670_99_SAIDA*/

        [StopWatch]
        /*" R2700-00-VERIFICA-BI16A-SECTION */
        private void R2700_00_VERIFICA_BI16A_SECTION()
        {
            /*" -2871- MOVE '2700' TO WNR-EXEC-SQL. */
            _.Move("2700", W.WABEND.WNR_EXEC_SQL);

            /*" -2874- MOVE SPACES TO LD02-MENSAGEM. */
            _.Move("", AUX_RELATORIO.LD02.LD02_MENSAGEM);

            /*" -2876- MOVE SOR-APOLICE TO RELATORI-NUM-APOLICE. */
            _.Move(REG_SBI7401B.SOR_APOLICE, RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE);

            /*" -2878- MOVE SOR-RAMO TO RELATORI-RAMO-EMISSOR. */
            _.Move(REG_SBI7401B.SOR_RAMO, RELATORI.DCLRELATORIOS.RELATORI_RAMO_EMISSOR);

            /*" -2882- MOVE SOR-BILHETE TO RELATORI-NUM-TITULO. */
            _.Move(REG_SBI7401B.SOR_BILHETE, RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO);

            /*" -2884- PERFORM R0325-00-SELECT-PARCELAS. */

            R0325_00_SELECT_PARCELAS_SECTION();

            /*" -2885- IF HOST-COUNT GREATER 1 */

            if (HOST_COUNT > 1)
            {

                /*" -2888- GO TO R2700-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2700_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2891- PERFORM R0330-00-SELECT-BILHETE. */

            R0330_00_SELECT_BILHETE_SECTION();

            /*" -2893- IF MOVDEBCE-SITUACAO-COBRANCA EQUAL '8' NEXT SENTENCE */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA == "8")
            {

                /*" -2894- ELSE */
            }
            else
            {


                /*" -2897- IF LD02-MENSAGEM EQUAL SPACES OR LD02-MENSAGEM EQUAL 'DEVOLUCAO NAO ENCONTRADA MOVDEBCE  ' */

                if (AUX_RELATORIO.LD02.LD02_MENSAGEM.IsEmpty() || AUX_RELATORIO.LD02.LD02_MENSAGEM == "DEVOLUCAO NAO ENCONTRADA MOVDEBCE  ")
                {

                    /*" -2897- PERFORM R3000-00-GERA-CANCELAMENTO. */

                    R3000_00_GERA_CANCELAMENTO_SECTION();
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2700_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-GERA-CANCELAMENTO-SECTION */
        private void R3000_00_GERA_CANCELAMENTO_SECTION()
        {
            /*" -2910- MOVE '3000' TO WNR-EXEC-SQL. */
            _.Move("3000", W.WABEND.WNR_EXEC_SQL);

            /*" -2912- MOVE 'S' TO RELATORI-IND-PREV-DEFINIT. */
            _.Move("S", RELATORI.DCLRELATORIOS.RELATORI_IND_PREV_DEFINIT);

            /*" -2916- MOVE 'S' TO RELATORI-IND-ANAL-RESUMO. */
            _.Move("S", RELATORI.DCLRELATORIOS.RELATORI_IND_ANAL_RESUMO);

            /*" -2917- IF SOR-NRSEQ NOT EQUAL 3 */

            if (REG_SBI7401B.SOR_NRSEQ != 3)
            {

                /*" -2920- PERFORM R1020-00-UPDATE-V0RELATORI. */

                R1020_00_UPDATE_V0RELATORI_SECTION();
            }


            /*" -2922- PERFORM R1040-00-UPDATE-V0BILHETE. */

            R1040_00_UPDATE_V0BILHETE_SECTION();

            /*" -2924- PERFORM R3030-00-SELECT-NUMERO-AES. */

            R3030_00_SELECT_NUMERO_AES_SECTION();

            /*" -2926- PERFORM R3050-00-SELECT-FONTES. */

            R3050_00_SELECT_FONTES_SECTION();

            /*" -2932- PERFORM R3100-00-SELECT-ENDOSSOS. */

            R3100_00_SELECT_ENDOSSOS_SECTION();

            /*" -2934- MOVE NUMERAES-ENDOS-CANC-RESTI TO ENDOSSOS-NUM-ENDOSSO. */
            _.Move(NUMERAES.DCLNUMERO_AES.NUMERAES_ENDOS_CANC_RESTI, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);

            /*" -2936- MOVE FONTES-ULT-PROP-AUTOMAT TO ENDOSSOS-NUM-PROPOSTA. */
            _.Move(FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_PROPOSTA);

            /*" -2938- MOVE SISTEMAS-DATA-MOV-ABERTO TO ENDOSSOS-DATA-EMISSAO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_EMISSAO);

            /*" -2943- MOVE ZEROS TO ENDOSSOS-NUM-RCAP ENDOSSOS-VAL-RCAP ENDOSSOS-BCO-RCAP ENDOSSOS-AGE-RCAP. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_RCAP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_VAL_RCAP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_BCO_RCAP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_AGE_RCAP);

            /*" -2946- MOVE '0' TO ENDOSSOS-DAC-RCAP ENDOSSOS-TIPO-RCAP. */
            _.Move("0", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DAC_RCAP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_RCAP);

            /*" -2948- MOVE 'BI7401B' TO ENDOSSOS-COD-USUARIO. */
            _.Move("BI7401B", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_USUARIO);

            /*" -2950- MOVE '1' TO ENDOSSOS-SIT-REGISTRO. */
            _.Move("1", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_SIT_REGISTRO);

            /*" -2952- MOVE '5' TO ENDOSSOS-TIPO-ENDOSSO. */
            _.Move("5", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_ENDOSSO);

            /*" -2954- MOVE SPACES TO ENDOSSOS-DATA-RCAP. */
            _.Move("", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_RCAP);

            /*" -2958- MOVE -1 TO VIND-DATA-RCAP. */
            _.Move(-1, VIND_DATA_RCAP);

            /*" -2964- PERFORM R3120-00-INSERT-ENDOSSOS. */

            R3120_00_INSERT_ENDOSSOS_SECTION();

            /*" -2966- MOVE ENDOSSOS-NUM-APOLICE TO PARCELAS-NUM-APOLICE. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE, PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE);

            /*" -2968- MOVE ENDOSSOS-NUM-ENDOSSO TO PARCELAS-NUM-ENDOSSO. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO, PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO);

            /*" -2970- MOVE ZEROS TO PARCELAS-NUM-PARCELA. */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA);

            /*" -2972- MOVE '0' TO PARCELAS-DAC-PARCELA. */
            _.Move("0", PARCELAS.DCLPARCELAS.PARCELAS_DAC_PARCELA);

            /*" -2974- MOVE ENDOSSOS-COD-FONTE TO PARCELAS-COD-FONTE. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE, PARCELAS.DCLPARCELAS.PARCELAS_COD_FONTE);

            /*" -2976- MOVE ZEROS TO PARCELAS-NUM-TITULO. */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_NUM_TITULO);

            /*" -2978- MOVE 2 TO PARCELAS-OCORR-HISTORICO. */
            _.Move(2, PARCELAS.DCLPARCELAS.PARCELAS_OCORR_HISTORICO);

            /*" -2980- MOVE ZEROS TO PARCELAS-QTD-DOCUMENTOS. */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_QTD_DOCUMENTOS);

            /*" -2982- MOVE '1' TO PARCELAS-SIT-REGISTRO. */
            _.Move("1", PARCELAS.DCLPARCELAS.PARCELAS_SIT_REGISTRO);

            /*" -2984- MOVE ENDOSSOS-COD-EMPRESA TO PARCELAS-COD-EMPRESA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_EMPRESA, PARCELAS.DCLPARCELAS.PARCELAS_COD_EMPRESA);

            /*" -2986- MOVE SPACES TO PARCELAS-SITUACAO-COBRANCA. */
            _.Move("", PARCELAS.DCLPARCELAS.PARCELAS_SITUACAO_COBRANCA);

            /*" -2996- MOVE ZEROS TO PARCELAS-PRM-TARIFARIO-IX PARCELAS-VAL-DESCONTO-IX PARCELAS-PRM-LIQUIDO-IX PARCELAS-ADICIONAL-FRAC-IX PARCELAS-VAL-CUSTO-EMIS-IX PARCELAS-VAL-IOCC-IX PARCELAS-PRM-TOTAL-IX. */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX, PARCELAS.DCLPARCELAS.PARCELAS_VAL_DESCONTO_IX, PARCELAS.DCLPARCELAS.PARCELAS_PRM_LIQUIDO_IX, PARCELAS.DCLPARCELAS.PARCELAS_ADICIONAL_FRAC_IX, PARCELAS.DCLPARCELAS.PARCELAS_VAL_CUSTO_EMIS_IX, PARCELAS.DCLPARCELAS.PARCELAS_VAL_IOCC_IX, PARCELAS.DCLPARCELAS.PARCELAS_PRM_TOTAL_IX);

            /*" -2997- MOVE ZEROS TO VIND-NULL01. */
            _.Move(0, VIND_NULL01);

            /*" -3000- MOVE -1 TO VIND-NULL02. */
            _.Move(-1, VIND_NULL02);

            /*" -3006- PERFORM R3130-00-INSERT-PARCELAS. */

            R3130_00_INSERT_PARCELAS_SECTION();

            /*" -3008- MOVE PARCELAS-NUM-APOLICE TO PARCEHIS-NUM-APOLICE. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE);

            /*" -3010- MOVE PARCELAS-NUM-ENDOSSO TO PARCEHIS-NUM-ENDOSSO. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO);

            /*" -3012- MOVE PARCELAS-NUM-PARCELA TO PARCEHIS-NUM-PARCELA. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA);

            /*" -3014- MOVE PARCELAS-DAC-PARCELA TO PARCEHIS-DAC-PARCELA. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_DAC_PARCELA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DAC_PARCELA);

            /*" -3016- MOVE SISTEMAS-DATA-MOV-ABERTO TO PARCEHIS-DATA-MOVIMENTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO);

            /*" -3018- MOVE 101 TO PARCEHIS-COD-OPERACAO. */
            _.Move(101, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO);

            /*" -3020- MOVE 1 TO PARCEHIS-OCORR-HISTORICO. */
            _.Move(1, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO);

            /*" -3029- MOVE ZEROS TO PARCEHIS-PRM-TARIFARIO PARCEHIS-VAL-DESCONTO PARCEHIS-PRM-LIQUIDO PARCEHIS-ADICIONAL-FRACIO PARCEHIS-VAL-CUSTO-EMISSAO PARCEHIS-VAL-IOCC PARCEHIS-PRM-TOTAL PARCEHIS-VAL-OPERACAO. */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TARIFARIO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_DESCONTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_LIQUIDO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ADICIONAL_FRACIO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_CUSTO_EMISSAO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_IOCC, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_OPERACAO);

            /*" -3031- MOVE ENDOSSOS-DATA-EMISSAO TO PARCEHIS-DATA-VENCIMENTO. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_EMISSAO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO);

            /*" -3033- IF ENDOSSOS-DATA-EMISSAO GREATER ENDOSSOS-DATA-TERVIGENCIA */

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_EMISSAO > ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA)
            {

                /*" -3036- MOVE ENDOSSOS-DATA-TERVIGENCIA TO PARCEHIS-DATA-VENCIMENTO. */
                _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO);
            }


            /*" -3038- MOVE ENDOSSOS-BCO-COBRANCA TO PARCEHIS-BCO-COBRANCA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_BCO_COBRANCA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_BCO_COBRANCA);

            /*" -3040- MOVE ENDOSSOS-AGE-COBRANCA TO PARCEHIS-AGE-COBRANCA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_AGE_COBRANCA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_AGE_COBRANCA);

            /*" -3042- MOVE ZEROS TO PARCEHIS-NUM-AVISO-CREDITO. */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_AVISO_CREDITO);

            /*" -3044- MOVE ZEROS TO PARCEHIS-ENDOS-CANCELA. */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ENDOS_CANCELA);

            /*" -3046- MOVE '0' TO PARCEHIS-SIT-CONTABIL. */
            _.Move("0", PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_SIT_CONTABIL);

            /*" -3048- MOVE ENDOSSOS-COD-USUARIO TO PARCEHIS-COD-USUARIO. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_USUARIO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_USUARIO);

            /*" -3050- MOVE ZEROS TO PARCEHIS-RENUM-DOCUMENTO. */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_RENUM_DOCUMENTO);

            /*" -3052- MOVE SPACES TO PARCEHIS-DATA-QUITACAO. */
            _.Move("", PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO);

            /*" -3055- MOVE PARCELAS-COD-EMPRESA TO PARCEHIS-COD-EMPRESA. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_COD_EMPRESA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_EMPRESA);

            /*" -3056- MOVE -1 TO VIND-NULL01. */
            _.Move(-1, VIND_NULL01);

            /*" -3059- MOVE ZEROS TO VIND-NULL02. */
            _.Move(0, VIND_NULL02);

            /*" -3065- PERFORM R3150-00-INSERT-PARCEHIS. */

            R3150_00_INSERT_PARCEHIS_SECTION();

            /*" -3067- MOVE 290 TO PARCEHIS-COD-OPERACAO. */
            _.Move(290, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO);

            /*" -3069- ADD 1 TO PARCEHIS-OCORR-HISTORICO. */
            PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO.Value = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO + 1;

            /*" -3071- MOVE PARCEHIS-DATA-VENCIMENTO TO PARCEHIS-DATA-QUITACAO */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO);

            /*" -3074- MOVE ZEROS TO VIND-NULL01 */
            _.Move(0, VIND_NULL01);

            /*" -3080- PERFORM R3150-00-INSERT-PARCEHIS. */

            R3150_00_INSERT_PARCEHIS_SECTION();

            /*" -3082- PERFORM R3200-00-SELECT-APOLICOB. */

            R3200_00_SELECT_APOLICOB_SECTION();

            /*" -3084- MOVE ENDOSSOS-NUM-ENDOSSO TO APOLICOB-NUM-ENDOSSO. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ENDOSSO);

            /*" -3086- MOVE ENDOSSOS-DATA-INIVIGENCIA TO APOLICOB-DATA-INIVIGENCIA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_INIVIGENCIA);

            /*" -3088- MOVE ENDOSSOS-DATA-TERVIGENCIA TO APOLICOB-DATA-TERVIGENCIA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_TERVIGENCIA);

            /*" -3093- MOVE ZEROS TO APOLICOB-PRM-TARIFARIO-IX APOLICOB-PRM-TARIFARIO-VAR. */
            _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_VAR);

            /*" -3096- PERFORM R3210-00-INSERT-APOLICOB. */

            R3210_00_INSERT_APOLICOB_SECTION();

            /*" -3096- PERFORM R2050-00-GRAVA-ARQUIVO02. */

            R2050_00_GRAVA_ARQUIVO02_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3030-00-SELECT-NUMERO-AES-SECTION */
        private void R3030_00_SELECT_NUMERO_AES_SECTION()
        {
            /*" -3109- MOVE '3030' TO WNR-EXEC-SQL. */
            _.Move("3030", W.WABEND.WNR_EXEC_SQL);

            /*" -3121- PERFORM R3030_00_SELECT_NUMERO_AES_DB_SELECT_1 */

            R3030_00_SELECT_NUMERO_AES_DB_SELECT_1();

            /*" -3125- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3126- DISPLAY 'R3030-00 - PROBLEMAS NO SELECT(NUMERAES)' */
                _.Display($"R3030-00 - PROBLEMAS NO SELECT(NUMERAES)");

                /*" -3127- DISPLAY 'ORGAO_EMISSOR = ' APOLICES-ORGAO-EMISSOR */
                _.Display($"ORGAO_EMISSOR = {APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR}");

                /*" -3128- DISPLAY 'RAMO_EMISSOR  = ' APOLICES-RAMO-EMISSOR */
                _.Display($"RAMO_EMISSOR  = {APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR}");

                /*" -3131- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3135- ADD 1 TO NUMERAES-ENDOS-CANC-RESTI. */
            NUMERAES.DCLNUMERO_AES.NUMERAES_ENDOS_CANC_RESTI.Value = NUMERAES.DCLNUMERO_AES.NUMERAES_ENDOS_CANC_RESTI + 1;

            /*" -3135- PERFORM R3040-00-UPDATE-NUMERO-AES. */

            R3040_00_UPDATE_NUMERO_AES_SECTION();

        }

        [StopWatch]
        /*" R3030-00-SELECT-NUMERO-AES-DB-SELECT-1 */
        public void R3030_00_SELECT_NUMERO_AES_DB_SELECT_1()
        {
            /*" -3121- EXEC SQL SELECT ORGAO_EMISSOR ,RAMO_EMISSOR ,ENDOS_CANC_RESTI INTO :NUMERAES-ORGAO-EMISSOR ,:NUMERAES-RAMO-EMISSOR ,:NUMERAES-ENDOS-CANC-RESTI FROM SEGUROS.NUMERO_AES WHERE ORGAO_EMISSOR = :APOLICES-ORGAO-EMISSOR AND RAMO_EMISSOR = :APOLICES-RAMO-EMISSOR FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r3030_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1 = new R3030_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1()
            {
                APOLICES_ORGAO_EMISSOR = APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR.ToString(),
                APOLICES_RAMO_EMISSOR = APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR.ToString(),
            };

            var executed_1 = R3030_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1.Execute(r3030_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUMERAES_ORGAO_EMISSOR, NUMERAES.DCLNUMERO_AES.NUMERAES_ORGAO_EMISSOR);
                _.Move(executed_1.NUMERAES_RAMO_EMISSOR, NUMERAES.DCLNUMERO_AES.NUMERAES_RAMO_EMISSOR);
                _.Move(executed_1.NUMERAES_ENDOS_CANC_RESTI, NUMERAES.DCLNUMERO_AES.NUMERAES_ENDOS_CANC_RESTI);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3030_99_SAIDA*/

        [StopWatch]
        /*" R3040-00-UPDATE-NUMERO-AES-SECTION */
        private void R3040_00_UPDATE_NUMERO_AES_SECTION()
        {
            /*" -3148- MOVE '3040' TO WNR-EXEC-SQL. */
            _.Move("3040", W.WABEND.WNR_EXEC_SQL);

            /*" -3156- PERFORM R3040_00_UPDATE_NUMERO_AES_DB_UPDATE_1 */

            R3040_00_UPDATE_NUMERO_AES_DB_UPDATE_1();

            /*" -3160- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3161- DISPLAY 'R3040-00 - PROBLEMAS UPDATE (NUMERAES)  ' */
                _.Display($"R3040-00 - PROBLEMAS UPDATE (NUMERAES)  ");

                /*" -3161- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3040-00-UPDATE-NUMERO-AES-DB-UPDATE-1 */
        public void R3040_00_UPDATE_NUMERO_AES_DB_UPDATE_1()
        {
            /*" -3156- EXEC SQL UPDATE SEGUROS.NUMERO_AES SET ENDOS_CANC_RESTI = :NUMERAES-ENDOS-CANC-RESTI WHERE ORGAO_EMISSOR = :NUMERAES-ORGAO-EMISSOR AND RAMO_EMISSOR = :NUMERAES-RAMO-EMISSOR END-EXEC. */

            var r3040_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1 = new R3040_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1()
            {
                NUMERAES_ENDOS_CANC_RESTI = NUMERAES.DCLNUMERO_AES.NUMERAES_ENDOS_CANC_RESTI.ToString(),
                NUMERAES_ORGAO_EMISSOR = NUMERAES.DCLNUMERO_AES.NUMERAES_ORGAO_EMISSOR.ToString(),
                NUMERAES_RAMO_EMISSOR = NUMERAES.DCLNUMERO_AES.NUMERAES_RAMO_EMISSOR.ToString(),
            };

            R3040_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1.Execute(r3040_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3040_99_SAIDA*/

        [StopWatch]
        /*" R3050-00-SELECT-FONTES-SECTION */
        private void R3050_00_SELECT_FONTES_SECTION()
        {
            /*" -3174- MOVE '3050' TO WNR-EXEC-SQL. */
            _.Move("3050", W.WABEND.WNR_EXEC_SQL);

            /*" -3182- PERFORM R3050_00_SELECT_FONTES_DB_SELECT_1 */

            R3050_00_SELECT_FONTES_DB_SELECT_1();

            /*" -3186- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3187- DISPLAY 'R3050-00 - PROBLEMAS NO SELECT(FONTES)  ' */
                _.Display($"R3050-00 - PROBLEMAS NO SELECT(FONTES)  ");

                /*" -3188- DISPLAY ' FONTE        =  ' BILHETE-FONTE */
                _.Display($" FONTE        =  {BILHETE.DCLBILHETE.BILHETE_FONTE}");

                /*" -3191- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3195- COMPUTE FONTES-ULT-PROP-AUTOMAT EQUAL (FONTES-ULT-PROP-AUTOMAT + 1). */
            FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT.Value = (FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT + 1);

            /*" -3197- MOVE ZEROS TO AC-CONTROLE. */
            _.Move(0, W.AC_CONTROLE);

            /*" -3200- PERFORM R3060-00-SELECT-ENDOSSOS. */

            R3060_00_SELECT_ENDOSSOS_SECTION();

            /*" -3200- PERFORM R3070-00-UPDATE-FONTES. */

            R3070_00_UPDATE_FONTES_SECTION();

        }

        [StopWatch]
        /*" R3050-00-SELECT-FONTES-DB-SELECT-1 */
        public void R3050_00_SELECT_FONTES_DB_SELECT_1()
        {
            /*" -3182- EXEC SQL SELECT ULT_PROP_AUTOMAT INTO :FONTES-ULT-PROP-AUTOMAT FROM SEGUROS.FONTES WHERE COD_FONTE = :BILHETE-FONTE WITH UR END-EXEC. */

            var r3050_00_SELECT_FONTES_DB_SELECT_1_Query1 = new R3050_00_SELECT_FONTES_DB_SELECT_1_Query1()
            {
                BILHETE_FONTE = BILHETE.DCLBILHETE.BILHETE_FONTE.ToString(),
            };

            var executed_1 = R3050_00_SELECT_FONTES_DB_SELECT_1_Query1.Execute(r3050_00_SELECT_FONTES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FONTES_ULT_PROP_AUTOMAT, FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3050_99_SAIDA*/

        [StopWatch]
        /*" R3060-00-SELECT-ENDOSSOS-SECTION */
        private void R3060_00_SELECT_ENDOSSOS_SECTION()
        {
            /*" -3213- MOVE '3060' TO WNR-EXEC-SQL. */
            _.Move("3060", W.WABEND.WNR_EXEC_SQL);

            /*" -3221- PERFORM R3060_00_SELECT_ENDOSSOS_DB_SELECT_1 */

            R3060_00_SELECT_ENDOSSOS_DB_SELECT_1();

            /*" -3225- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3228- GO TO R3060-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3060_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3229- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3230- DISPLAY 'R3060-00 - PROBLEMAS NO SELECT(ENDOSSOS)' */
                _.Display($"R3060-00 - PROBLEMAS NO SELECT(ENDOSSOS)");

                /*" -3231- DISPLAY 'COD-FONTE        = ' BILHETE-FONTE */
                _.Display($"COD-FONTE        = {BILHETE.DCLBILHETE.BILHETE_FONTE}");

                /*" -3232- DISPLAY 'NUM_PROPOSTA     = ' FONTES-ULT-PROP-AUTOMAT */
                _.Display($"NUM_PROPOSTA     = {FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT}");

                /*" -3235- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3240- ADD 1 TO AC-CONTROLE. */
            W.AC_CONTROLE.Value = W.AC_CONTROLE + 1;

            /*" -3241- IF AC-CONTROLE GREATER 5000 */

            if (W.AC_CONTROLE > 5000)
            {

                /*" -3242- DISPLAY 'R3060-00 - PROPOSTA DUPLICIDADE ENDOSSOS' */
                _.Display($"R3060-00 - PROPOSTA DUPLICIDADE ENDOSSOS");

                /*" -3243- DISPLAY 'COD-FONTE        = ' BILHETE-FONTE */
                _.Display($"COD-FONTE        = {BILHETE.DCLBILHETE.BILHETE_FONTE}");

                /*" -3244- DISPLAY 'NUM_PROPOSTA     = ' FONTES-ULT-PROP-AUTOMAT */
                _.Display($"NUM_PROPOSTA     = {FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT}");

                /*" -3246- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3250- COMPUTE FONTES-ULT-PROP-AUTOMAT EQUAL (FONTES-ULT-PROP-AUTOMAT + 1). */
            FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT.Value = (FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT + 1);

            /*" -3250- GO TO R3060-00-SELECT-ENDOSSOS. */
            new Task(() => R3060_00_SELECT_ENDOSSOS_SECTION()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R3060-00-SELECT-ENDOSSOS-DB-SELECT-1 */
        public void R3060_00_SELECT_ENDOSSOS_DB_SELECT_1()
        {
            /*" -3221- EXEC SQL SELECT NUM_PROPOSTA INTO :ENDOSSOS-NUM-PROPOSTA FROM SEGUROS.ENDOSSOS WHERE COD_FONTE = :BILHETE-FONTE AND NUM_PROPOSTA = :FONTES-ULT-PROP-AUTOMAT WITH UR END-EXEC. */

            var r3060_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 = new R3060_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1()
            {
                FONTES_ULT_PROP_AUTOMAT = FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT.ToString(),
                BILHETE_FONTE = BILHETE.DCLBILHETE.BILHETE_FONTE.ToString(),
            };

            var executed_1 = R3060_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1.Execute(r3060_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDOSSOS_NUM_PROPOSTA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_PROPOSTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3060_99_SAIDA*/

        [StopWatch]
        /*" R3070-00-UPDATE-FONTES-SECTION */
        private void R3070_00_UPDATE_FONTES_SECTION()
        {
            /*" -3263- MOVE '3070' TO WNR-EXEC-SQL. */
            _.Move("3070", W.WABEND.WNR_EXEC_SQL);

            /*" -3269- PERFORM R3070_00_UPDATE_FONTES_DB_UPDATE_1 */

            R3070_00_UPDATE_FONTES_DB_UPDATE_1();

            /*" -3272- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3273- DISPLAY 'R3070-00 - PROBLEMAS UPDATE (FONTES)      ' */
                _.Display($"R3070-00 - PROBLEMAS UPDATE (FONTES)      ");

                /*" -3274- DISPLAY 'COD-FONTE        = ' BILHETE-FONTE */
                _.Display($"COD-FONTE        = {BILHETE.DCLBILHETE.BILHETE_FONTE}");

                /*" -3275- DISPLAY 'NUM_PROPOSTA     = ' FONTES-ULT-PROP-AUTOMAT */
                _.Display($"NUM_PROPOSTA     = {FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT}");

                /*" -3275- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3070-00-UPDATE-FONTES-DB-UPDATE-1 */
        public void R3070_00_UPDATE_FONTES_DB_UPDATE_1()
        {
            /*" -3269- EXEC SQL UPDATE SEGUROS.FONTES SET ULT_PROP_AUTOMAT = :FONTES-ULT-PROP-AUTOMAT WHERE COD_FONTE = :BILHETE-FONTE END-EXEC. */

            var r3070_00_UPDATE_FONTES_DB_UPDATE_1_Update1 = new R3070_00_UPDATE_FONTES_DB_UPDATE_1_Update1()
            {
                FONTES_ULT_PROP_AUTOMAT = FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT.ToString(),
                BILHETE_FONTE = BILHETE.DCLBILHETE.BILHETE_FONTE.ToString(),
            };

            R3070_00_UPDATE_FONTES_DB_UPDATE_1_Update1.Execute(r3070_00_UPDATE_FONTES_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3070_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-SELECT-ENDOSSOS-SECTION */
        private void R3100_00_SELECT_ENDOSSOS_SECTION()
        {
            /*" -3288- MOVE '3100' TO WNR-EXEC-SQL. */
            _.Move("3100", W.WABEND.WNR_EXEC_SQL);

            /*" -3292- MOVE SOR-APOLICE TO ENDOSSOS-NUM-APOLICE. */
            _.Move(REG_SBI7401B.SOR_APOLICE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE);

            /*" -3384- PERFORM R3100_00_SELECT_ENDOSSOS_DB_SELECT_1 */

            R3100_00_SELECT_ENDOSSOS_DB_SELECT_1();

            /*" -3388- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3389- DISPLAY 'R3100-00 - PROBLEMAS NO SELECT(ENDOSSOS)' */
                _.Display($"R3100-00 - PROBLEMAS NO SELECT(ENDOSSOS)");

                /*" -3390- DISPLAY ' APOLICE    = ' ENDOSSOS-NUM-APOLICE */
                _.Display($" APOLICE    = {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE}");

                /*" -3393- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3393- PERFORM R3110-00-UPDATE-ENDOSSOS. */

            R3110_00_UPDATE_ENDOSSOS_SECTION();

        }

        [StopWatch]
        /*" R3100-00-SELECT-ENDOSSOS-DB-SELECT-1 */
        public void R3100_00_SELECT_ENDOSSOS_DB_SELECT_1()
        {
            /*" -3384- EXEC SQL SELECT NUM_APOLICE ,NUM_ENDOSSO ,RAMO_EMISSOR ,COD_PRODUTO ,COD_SUBGRUPO ,COD_FONTE ,NUM_PROPOSTA ,DATA_PROPOSTA ,DATA_LIBERACAO ,DATA_EMISSAO ,NUM_RCAP ,VAL_RCAP ,BCO_RCAP ,AGE_RCAP ,DAC_RCAP ,TIPO_RCAP ,BCO_COBRANCA ,AGE_COBRANCA ,DAC_COBRANCA ,DATA_INIVIGENCIA ,DATA_TERVIGENCIA ,PLANO_SEGURO ,PCT_ENTRADA ,PCT_ADIC_FRACIO ,QTD_DIAS_PRIMEIRA ,QTD_PARCELAS ,QTD_PRESTACOES ,QTD_ITENS ,COD_TEXTO_PADRAO ,COD_ACEITACAO ,COD_MOEDA_IMP ,COD_MOEDA_PRM ,TIPO_ENDOSSO ,COD_USUARIO ,OCORR_ENDERECO ,SIT_REGISTRO ,DATA_RCAP ,COD_EMPRESA ,TIPO_CORRECAO ,ISENTA_CUSTO ,DATA_VENCIMENTO ,COEF_PREFIX ,VAL_CUSTO_EMISSAO INTO :ENDOSSOS-NUM-APOLICE ,:ENDOSSOS-NUM-ENDOSSO ,:ENDOSSOS-RAMO-EMISSOR ,:ENDOSSOS-COD-PRODUTO ,:ENDOSSOS-COD-SUBGRUPO ,:ENDOSSOS-COD-FONTE ,:ENDOSSOS-NUM-PROPOSTA ,:ENDOSSOS-DATA-PROPOSTA ,:ENDOSSOS-DATA-LIBERACAO ,:ENDOSSOS-DATA-EMISSAO ,:ENDOSSOS-NUM-RCAP ,:ENDOSSOS-VAL-RCAP ,:ENDOSSOS-BCO-RCAP ,:ENDOSSOS-AGE-RCAP ,:ENDOSSOS-DAC-RCAP ,:ENDOSSOS-TIPO-RCAP ,:ENDOSSOS-BCO-COBRANCA ,:ENDOSSOS-AGE-COBRANCA ,:ENDOSSOS-DAC-COBRANCA ,:ENDOSSOS-DATA-INIVIGENCIA ,:ENDOSSOS-DATA-TERVIGENCIA ,:ENDOSSOS-PLANO-SEGURO ,:ENDOSSOS-PCT-ENTRADA ,:ENDOSSOS-PCT-ADIC-FRACIO ,:ENDOSSOS-QTD-DIAS-PRIMEIRA ,:ENDOSSOS-QTD-PARCELAS ,:ENDOSSOS-QTD-PRESTACOES ,:ENDOSSOS-QTD-ITENS ,:ENDOSSOS-COD-TEXTO-PADRAO ,:ENDOSSOS-COD-ACEITACAO ,:ENDOSSOS-COD-MOEDA-IMP ,:ENDOSSOS-COD-MOEDA-PRM ,:ENDOSSOS-TIPO-ENDOSSO ,:ENDOSSOS-COD-USUARIO ,:ENDOSSOS-OCORR-ENDERECO ,:ENDOSSOS-SIT-REGISTRO ,:ENDOSSOS-DATA-RCAP:VIND-DATA-RCAP ,:ENDOSSOS-COD-EMPRESA:VIND-COD-EMPRESA ,:ENDOSSOS-TIPO-CORRECAO:VIND-TIPO-CORRECAO ,:ENDOSSOS-ISENTA-CUSTO:VIND-ISENTA-CUSTO ,:ENDOSSOS-DATA-VENCIMENTO:VIND-DTVENCTO ,:ENDOSSOS-COEF-PREFIX:VIND-COEF-PREFIX ,:ENDOSSOS-VAL-CUSTO-EMISSAO:VIND-VAL-CUSTO FROM SEGUROS.ENDOSSOS WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE AND NUM_ENDOSSO = 0 FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r3100_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 = new R3100_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1()
            {
                ENDOSSOS_NUM_APOLICE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.ToString(),
            };

            var executed_1 = R3100_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1.Execute(r3100_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDOSSOS_NUM_APOLICE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE);
                _.Move(executed_1.ENDOSSOS_NUM_ENDOSSO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);
                _.Move(executed_1.ENDOSSOS_RAMO_EMISSOR, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR);
                _.Move(executed_1.ENDOSSOS_COD_PRODUTO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO);
                _.Move(executed_1.ENDOSSOS_COD_SUBGRUPO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_SUBGRUPO);
                _.Move(executed_1.ENDOSSOS_COD_FONTE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE);
                _.Move(executed_1.ENDOSSOS_NUM_PROPOSTA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_PROPOSTA);
                _.Move(executed_1.ENDOSSOS_DATA_PROPOSTA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_PROPOSTA);
                _.Move(executed_1.ENDOSSOS_DATA_LIBERACAO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_LIBERACAO);
                _.Move(executed_1.ENDOSSOS_DATA_EMISSAO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_EMISSAO);
                _.Move(executed_1.ENDOSSOS_NUM_RCAP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_RCAP);
                _.Move(executed_1.ENDOSSOS_VAL_RCAP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_VAL_RCAP);
                _.Move(executed_1.ENDOSSOS_BCO_RCAP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_BCO_RCAP);
                _.Move(executed_1.ENDOSSOS_AGE_RCAP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_AGE_RCAP);
                _.Move(executed_1.ENDOSSOS_DAC_RCAP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DAC_RCAP);
                _.Move(executed_1.ENDOSSOS_TIPO_RCAP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_RCAP);
                _.Move(executed_1.ENDOSSOS_BCO_COBRANCA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_BCO_COBRANCA);
                _.Move(executed_1.ENDOSSOS_AGE_COBRANCA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_AGE_COBRANCA);
                _.Move(executed_1.ENDOSSOS_DAC_COBRANCA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DAC_COBRANCA);
                _.Move(executed_1.ENDOSSOS_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);
                _.Move(executed_1.ENDOSSOS_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);
                _.Move(executed_1.ENDOSSOS_PLANO_SEGURO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_PLANO_SEGURO);
                _.Move(executed_1.ENDOSSOS_PCT_ENTRADA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_PCT_ENTRADA);
                _.Move(executed_1.ENDOSSOS_PCT_ADIC_FRACIO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_PCT_ADIC_FRACIO);
                _.Move(executed_1.ENDOSSOS_QTD_DIAS_PRIMEIRA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_DIAS_PRIMEIRA);
                _.Move(executed_1.ENDOSSOS_QTD_PARCELAS, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_PARCELAS);
                _.Move(executed_1.ENDOSSOS_QTD_PRESTACOES, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_PRESTACOES);
                _.Move(executed_1.ENDOSSOS_QTD_ITENS, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_ITENS);
                _.Move(executed_1.ENDOSSOS_COD_TEXTO_PADRAO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_TEXTO_PADRAO);
                _.Move(executed_1.ENDOSSOS_COD_ACEITACAO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_ACEITACAO);
                _.Move(executed_1.ENDOSSOS_COD_MOEDA_IMP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_MOEDA_IMP);
                _.Move(executed_1.ENDOSSOS_COD_MOEDA_PRM, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_MOEDA_PRM);
                _.Move(executed_1.ENDOSSOS_TIPO_ENDOSSO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_ENDOSSO);
                _.Move(executed_1.ENDOSSOS_COD_USUARIO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_USUARIO);
                _.Move(executed_1.ENDOSSOS_OCORR_ENDERECO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_OCORR_ENDERECO);
                _.Move(executed_1.ENDOSSOS_SIT_REGISTRO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_SIT_REGISTRO);
                _.Move(executed_1.ENDOSSOS_DATA_RCAP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_RCAP);
                _.Move(executed_1.VIND_DATA_RCAP, VIND_DATA_RCAP);
                _.Move(executed_1.ENDOSSOS_COD_EMPRESA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_EMPRESA);
                _.Move(executed_1.VIND_COD_EMPRESA, VIND_COD_EMPRESA);
                _.Move(executed_1.ENDOSSOS_TIPO_CORRECAO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_CORRECAO);
                _.Move(executed_1.VIND_TIPO_CORRECAO, VIND_TIPO_CORRECAO);
                _.Move(executed_1.ENDOSSOS_ISENTA_CUSTO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_ISENTA_CUSTO);
                _.Move(executed_1.VIND_ISENTA_CUSTO, VIND_ISENTA_CUSTO);
                _.Move(executed_1.ENDOSSOS_DATA_VENCIMENTO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_VENCIMENTO);
                _.Move(executed_1.VIND_DTVENCTO, VIND_DTVENCTO);
                _.Move(executed_1.ENDOSSOS_COEF_PREFIX, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COEF_PREFIX);
                _.Move(executed_1.VIND_COEF_PREFIX, VIND_COEF_PREFIX);
                _.Move(executed_1.ENDOSSOS_VAL_CUSTO_EMISSAO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_VAL_CUSTO_EMISSAO);
                _.Move(executed_1.VIND_VAL_CUSTO, VIND_VAL_CUSTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R3110-00-UPDATE-ENDOSSOS-SECTION */
        private void R3110_00_UPDATE_ENDOSSOS_SECTION()
        {
            /*" -3406- MOVE '3110' TO WNR-EXEC-SQL. */
            _.Move("3110", W.WABEND.WNR_EXEC_SQL);

            /*" -3410- PERFORM R3110_00_UPDATE_ENDOSSOS_DB_UPDATE_1 */

            R3110_00_UPDATE_ENDOSSOS_DB_UPDATE_1();

            /*" -3413- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3414- DISPLAY 'R3110-00 - PROBLEMAS UPDATE (ENDOSSOS)' */
                _.Display($"R3110-00 - PROBLEMAS UPDATE (ENDOSSOS)");

                /*" -3415- DISPLAY ' APOLICE   =      ' ENDOSSOS-NUM-APOLICE */
                _.Display($" APOLICE   =      {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE}");

                /*" -3415- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3110-00-UPDATE-ENDOSSOS-DB-UPDATE-1 */
        public void R3110_00_UPDATE_ENDOSSOS_DB_UPDATE_1()
        {
            /*" -3410- EXEC SQL UPDATE SEGUROS.ENDOSSOS SET SIT_REGISTRO = '2' WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE END-EXEC. */

            var r3110_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1 = new R3110_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1()
            {
                ENDOSSOS_NUM_APOLICE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.ToString(),
            };

            R3110_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1.Execute(r3110_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3110_99_SAIDA*/

        [StopWatch]
        /*" R3120-00-INSERT-ENDOSSOS-SECTION */
        private void R3120_00_INSERT_ENDOSSOS_SECTION()
        {
            /*" -3428- MOVE '3120' TO WNR-EXEC-SQL. */
            _.Move("3120", W.WABEND.WNR_EXEC_SQL);

            /*" -3519- PERFORM R3120_00_INSERT_ENDOSSOS_DB_INSERT_1 */

            R3120_00_INSERT_ENDOSSOS_DB_INSERT_1();

            /*" -3523- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3524- DISPLAY 'R3120-00 - PROBLEMAS NO INSERT(ENDOSSOS)   ' */
                _.Display($"R3120-00 - PROBLEMAS NO INSERT(ENDOSSOS)   ");

                /*" -3525- DISPLAY ' APOLICE    = ' ENDOSSOS-NUM-APOLICE */
                _.Display($" APOLICE    = {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE}");

                /*" -3526- DISPLAY ' ENDOSSO    = ' ENDOSSOS-NUM-ENDOSSO */
                _.Display($" ENDOSSO    = {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO}");

                /*" -3529- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3529- ADD 1 TO IN-ENDOSSOS. */
            W.IN_ENDOSSOS.Value = W.IN_ENDOSSOS + 1;

        }

        [StopWatch]
        /*" R3120-00-INSERT-ENDOSSOS-DB-INSERT-1 */
        public void R3120_00_INSERT_ENDOSSOS_DB_INSERT_1()
        {
            /*" -3519- EXEC SQL INSERT INTO SEGUROS.ENDOSSOS (NUM_APOLICE ,NUM_ENDOSSO ,RAMO_EMISSOR ,COD_PRODUTO ,COD_SUBGRUPO ,COD_FONTE ,NUM_PROPOSTA ,DATA_PROPOSTA ,DATA_LIBERACAO ,DATA_EMISSAO ,NUM_RCAP ,VAL_RCAP ,BCO_RCAP ,AGE_RCAP ,DAC_RCAP ,TIPO_RCAP ,BCO_COBRANCA ,AGE_COBRANCA ,DAC_COBRANCA ,DATA_INIVIGENCIA ,DATA_TERVIGENCIA ,PLANO_SEGURO ,PCT_ENTRADA ,PCT_ADIC_FRACIO ,QTD_DIAS_PRIMEIRA ,QTD_PARCELAS ,QTD_PRESTACOES ,QTD_ITENS ,COD_TEXTO_PADRAO ,COD_ACEITACAO ,COD_MOEDA_IMP ,COD_MOEDA_PRM ,TIPO_ENDOSSO ,COD_USUARIO ,OCORR_ENDERECO ,SIT_REGISTRO ,DATA_RCAP ,COD_EMPRESA ,TIPO_CORRECAO ,ISENTA_CUSTO ,TIMESTAMP ,DATA_VENCIMENTO ,COEF_PREFIX ,VAL_CUSTO_EMISSAO) VALUES (:ENDOSSOS-NUM-APOLICE ,:ENDOSSOS-NUM-ENDOSSO ,:ENDOSSOS-RAMO-EMISSOR ,:ENDOSSOS-COD-PRODUTO ,:ENDOSSOS-COD-SUBGRUPO ,:ENDOSSOS-COD-FONTE ,:ENDOSSOS-NUM-PROPOSTA ,:ENDOSSOS-DATA-PROPOSTA ,:ENDOSSOS-DATA-LIBERACAO ,:ENDOSSOS-DATA-EMISSAO ,:ENDOSSOS-NUM-RCAP ,:ENDOSSOS-VAL-RCAP ,:ENDOSSOS-BCO-RCAP ,:ENDOSSOS-AGE-RCAP ,:ENDOSSOS-DAC-RCAP ,:ENDOSSOS-TIPO-RCAP ,:ENDOSSOS-BCO-COBRANCA ,:ENDOSSOS-AGE-COBRANCA ,:ENDOSSOS-DAC-COBRANCA ,:ENDOSSOS-DATA-INIVIGENCIA ,:ENDOSSOS-DATA-TERVIGENCIA ,:ENDOSSOS-PLANO-SEGURO ,:ENDOSSOS-PCT-ENTRADA ,:ENDOSSOS-PCT-ADIC-FRACIO ,:ENDOSSOS-QTD-DIAS-PRIMEIRA ,:ENDOSSOS-QTD-PARCELAS ,:ENDOSSOS-QTD-PRESTACOES ,:ENDOSSOS-QTD-ITENS ,:ENDOSSOS-COD-TEXTO-PADRAO ,:ENDOSSOS-COD-ACEITACAO ,:ENDOSSOS-COD-MOEDA-IMP ,:ENDOSSOS-COD-MOEDA-PRM ,:ENDOSSOS-TIPO-ENDOSSO ,:ENDOSSOS-COD-USUARIO ,:ENDOSSOS-OCORR-ENDERECO ,:ENDOSSOS-SIT-REGISTRO ,:ENDOSSOS-DATA-RCAP:VIND-DATA-RCAP ,:ENDOSSOS-COD-EMPRESA:VIND-COD-EMPRESA ,:ENDOSSOS-TIPO-CORRECAO:VIND-TIPO-CORRECAO ,:ENDOSSOS-ISENTA-CUSTO:VIND-ISENTA-CUSTO , CURRENT TIMESTAMP ,:ENDOSSOS-DATA-VENCIMENTO:VIND-DTVENCTO ,:ENDOSSOS-COEF-PREFIX:VIND-COEF-PREFIX ,:ENDOSSOS-VAL-CUSTO-EMISSAO:VIND-VAL-CUSTO) END-EXEC. */

            var r3120_00_INSERT_ENDOSSOS_DB_INSERT_1_Insert1 = new R3120_00_INSERT_ENDOSSOS_DB_INSERT_1_Insert1()
            {
                ENDOSSOS_NUM_APOLICE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.ToString(),
                ENDOSSOS_NUM_ENDOSSO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO.ToString(),
                ENDOSSOS_RAMO_EMISSOR = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR.ToString(),
                ENDOSSOS_COD_PRODUTO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO.ToString(),
                ENDOSSOS_COD_SUBGRUPO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_SUBGRUPO.ToString(),
                ENDOSSOS_COD_FONTE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE.ToString(),
                ENDOSSOS_NUM_PROPOSTA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_PROPOSTA.ToString(),
                ENDOSSOS_DATA_PROPOSTA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_PROPOSTA.ToString(),
                ENDOSSOS_DATA_LIBERACAO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_LIBERACAO.ToString(),
                ENDOSSOS_DATA_EMISSAO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_EMISSAO.ToString(),
                ENDOSSOS_NUM_RCAP = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_RCAP.ToString(),
                ENDOSSOS_VAL_RCAP = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_VAL_RCAP.ToString(),
                ENDOSSOS_BCO_RCAP = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_BCO_RCAP.ToString(),
                ENDOSSOS_AGE_RCAP = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_AGE_RCAP.ToString(),
                ENDOSSOS_DAC_RCAP = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DAC_RCAP.ToString(),
                ENDOSSOS_TIPO_RCAP = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_RCAP.ToString(),
                ENDOSSOS_BCO_COBRANCA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_BCO_COBRANCA.ToString(),
                ENDOSSOS_AGE_COBRANCA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_AGE_COBRANCA.ToString(),
                ENDOSSOS_DAC_COBRANCA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DAC_COBRANCA.ToString(),
                ENDOSSOS_DATA_INIVIGENCIA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA.ToString(),
                ENDOSSOS_DATA_TERVIGENCIA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA.ToString(),
                ENDOSSOS_PLANO_SEGURO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_PLANO_SEGURO.ToString(),
                ENDOSSOS_PCT_ENTRADA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_PCT_ENTRADA.ToString(),
                ENDOSSOS_PCT_ADIC_FRACIO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_PCT_ADIC_FRACIO.ToString(),
                ENDOSSOS_QTD_DIAS_PRIMEIRA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_DIAS_PRIMEIRA.ToString(),
                ENDOSSOS_QTD_PARCELAS = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_PARCELAS.ToString(),
                ENDOSSOS_QTD_PRESTACOES = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_PRESTACOES.ToString(),
                ENDOSSOS_QTD_ITENS = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_ITENS.ToString(),
                ENDOSSOS_COD_TEXTO_PADRAO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_TEXTO_PADRAO.ToString(),
                ENDOSSOS_COD_ACEITACAO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_ACEITACAO.ToString(),
                ENDOSSOS_COD_MOEDA_IMP = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_MOEDA_IMP.ToString(),
                ENDOSSOS_COD_MOEDA_PRM = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_MOEDA_PRM.ToString(),
                ENDOSSOS_TIPO_ENDOSSO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_ENDOSSO.ToString(),
                ENDOSSOS_COD_USUARIO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_USUARIO.ToString(),
                ENDOSSOS_OCORR_ENDERECO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_OCORR_ENDERECO.ToString(),
                ENDOSSOS_SIT_REGISTRO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_SIT_REGISTRO.ToString(),
                ENDOSSOS_DATA_RCAP = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_RCAP.ToString(),
                VIND_DATA_RCAP = VIND_DATA_RCAP.ToString(),
                ENDOSSOS_COD_EMPRESA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_EMPRESA.ToString(),
                VIND_COD_EMPRESA = VIND_COD_EMPRESA.ToString(),
                ENDOSSOS_TIPO_CORRECAO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_CORRECAO.ToString(),
                VIND_TIPO_CORRECAO = VIND_TIPO_CORRECAO.ToString(),
                ENDOSSOS_ISENTA_CUSTO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_ISENTA_CUSTO.ToString(),
                VIND_ISENTA_CUSTO = VIND_ISENTA_CUSTO.ToString(),
                ENDOSSOS_DATA_VENCIMENTO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_VENCIMENTO.ToString(),
                VIND_DTVENCTO = VIND_DTVENCTO.ToString(),
                ENDOSSOS_COEF_PREFIX = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COEF_PREFIX.ToString(),
                VIND_COEF_PREFIX = VIND_COEF_PREFIX.ToString(),
                ENDOSSOS_VAL_CUSTO_EMISSAO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_VAL_CUSTO_EMISSAO.ToString(),
                VIND_VAL_CUSTO = VIND_VAL_CUSTO.ToString(),
            };

            R3120_00_INSERT_ENDOSSOS_DB_INSERT_1_Insert1.Execute(r3120_00_INSERT_ENDOSSOS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3120_99_SAIDA*/

        [StopWatch]
        /*" R3130-00-INSERT-PARCELAS-SECTION */
        private void R3130_00_INSERT_PARCELAS_SECTION()
        {
            /*" -3542- MOVE '3130' TO WNR-EXEC-SQL. */
            _.Move("3130", W.WABEND.WNR_EXEC_SQL);

            /*" -3583- PERFORM R3130_00_INSERT_PARCELAS_DB_INSERT_1 */

            R3130_00_INSERT_PARCELAS_DB_INSERT_1();

            /*" -3587- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3588- DISPLAY 'R3130-00 - PROBLEMAS NO INSERT(PARCELAS)   ' */
                _.Display($"R3130-00 - PROBLEMAS NO INSERT(PARCELAS)   ");

                /*" -3589- DISPLAY ' APOLICE    = ' PARCELAS-NUM-APOLICE */
                _.Display($" APOLICE    = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE}");

                /*" -3590- DISPLAY ' ENDOSSO    = ' PARCELAS-NUM-ENDOSSO */
                _.Display($" ENDOSSO    = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO}");

                /*" -3590- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3130-00-INSERT-PARCELAS-DB-INSERT-1 */
        public void R3130_00_INSERT_PARCELAS_DB_INSERT_1()
        {
            /*" -3583- EXEC SQL INSERT INTO SEGUROS.PARCELAS (NUM_APOLICE ,NUM_ENDOSSO ,NUM_PARCELA ,DAC_PARCELA ,COD_FONTE ,NUM_TITULO ,PRM_TARIFARIO_IX ,VAL_DESCONTO_IX ,PRM_LIQUIDO_IX ,ADICIONAL_FRAC_IX ,VAL_CUSTO_EMIS_IX ,VAL_IOCC_IX ,PRM_TOTAL_IX ,OCORR_HISTORICO ,QTD_DOCUMENTOS ,SIT_REGISTRO ,COD_EMPRESA ,TIMESTAMP ,SITUACAO_COBRANCA) VALUES (:PARCELAS-NUM-APOLICE ,:PARCELAS-NUM-ENDOSSO ,:PARCELAS-NUM-PARCELA ,:PARCELAS-DAC-PARCELA ,:PARCELAS-COD-FONTE ,:PARCELAS-NUM-TITULO ,:PARCELAS-PRM-TARIFARIO-IX ,:PARCELAS-VAL-DESCONTO-IX ,:PARCELAS-PRM-LIQUIDO-IX ,:PARCELAS-ADICIONAL-FRAC-IX ,:PARCELAS-VAL-CUSTO-EMIS-IX ,:PARCELAS-VAL-IOCC-IX ,:PARCELAS-PRM-TOTAL-IX ,:PARCELAS-OCORR-HISTORICO ,:PARCELAS-QTD-DOCUMENTOS ,:PARCELAS-SIT-REGISTRO ,:PARCELAS-COD-EMPRESA:VIND-NULL01 , CURRENT TIMESTAMP ,:PARCELAS-SITUACAO-COBRANCA:VIND-NULL02) END-EXEC. */

            var r3130_00_INSERT_PARCELAS_DB_INSERT_1_Insert1 = new R3130_00_INSERT_PARCELAS_DB_INSERT_1_Insert1()
            {
                PARCELAS_NUM_APOLICE = PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE.ToString(),
                PARCELAS_NUM_ENDOSSO = PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO.ToString(),
                PARCELAS_NUM_PARCELA = PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA.ToString(),
                PARCELAS_DAC_PARCELA = PARCELAS.DCLPARCELAS.PARCELAS_DAC_PARCELA.ToString(),
                PARCELAS_COD_FONTE = PARCELAS.DCLPARCELAS.PARCELAS_COD_FONTE.ToString(),
                PARCELAS_NUM_TITULO = PARCELAS.DCLPARCELAS.PARCELAS_NUM_TITULO.ToString(),
                PARCELAS_PRM_TARIFARIO_IX = PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX.ToString(),
                PARCELAS_VAL_DESCONTO_IX = PARCELAS.DCLPARCELAS.PARCELAS_VAL_DESCONTO_IX.ToString(),
                PARCELAS_PRM_LIQUIDO_IX = PARCELAS.DCLPARCELAS.PARCELAS_PRM_LIQUIDO_IX.ToString(),
                PARCELAS_ADICIONAL_FRAC_IX = PARCELAS.DCLPARCELAS.PARCELAS_ADICIONAL_FRAC_IX.ToString(),
                PARCELAS_VAL_CUSTO_EMIS_IX = PARCELAS.DCLPARCELAS.PARCELAS_VAL_CUSTO_EMIS_IX.ToString(),
                PARCELAS_VAL_IOCC_IX = PARCELAS.DCLPARCELAS.PARCELAS_VAL_IOCC_IX.ToString(),
                PARCELAS_PRM_TOTAL_IX = PARCELAS.DCLPARCELAS.PARCELAS_PRM_TOTAL_IX.ToString(),
                PARCELAS_OCORR_HISTORICO = PARCELAS.DCLPARCELAS.PARCELAS_OCORR_HISTORICO.ToString(),
                PARCELAS_QTD_DOCUMENTOS = PARCELAS.DCLPARCELAS.PARCELAS_QTD_DOCUMENTOS.ToString(),
                PARCELAS_SIT_REGISTRO = PARCELAS.DCLPARCELAS.PARCELAS_SIT_REGISTRO.ToString(),
                PARCELAS_COD_EMPRESA = PARCELAS.DCLPARCELAS.PARCELAS_COD_EMPRESA.ToString(),
                VIND_NULL01 = VIND_NULL01.ToString(),
                PARCELAS_SITUACAO_COBRANCA = PARCELAS.DCLPARCELAS.PARCELAS_SITUACAO_COBRANCA.ToString(),
                VIND_NULL02 = VIND_NULL02.ToString(),
            };

            R3130_00_INSERT_PARCELAS_DB_INSERT_1_Insert1.Execute(r3130_00_INSERT_PARCELAS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3130_99_SAIDA*/

        [StopWatch]
        /*" R3150-00-INSERT-PARCEHIS-SECTION */
        private void R3150_00_INSERT_PARCEHIS_SECTION()
        {
            /*" -3603- MOVE '3150' TO WNR-EXEC-SQL. */
            _.Move("3150", W.WABEND.WNR_EXEC_SQL);

            /*" -3660- PERFORM R3150_00_INSERT_PARCEHIS_DB_INSERT_1 */

            R3150_00_INSERT_PARCEHIS_DB_INSERT_1();

            /*" -3664- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3665- DISPLAY 'R3150-00 - PROBLEMAS NO INSERT(PARCEHIS)   ' */
                _.Display($"R3150-00 - PROBLEMAS NO INSERT(PARCEHIS)   ");

                /*" -3666- DISPLAY ' APOLICE    = ' PARCEHIS-NUM-APOLICE */
                _.Display($" APOLICE    = {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                /*" -3667- DISPLAY ' ENDOSSO    = ' PARCEHIS-NUM-ENDOSSO */
                _.Display($" ENDOSSO    = {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                /*" -3667- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3150-00-INSERT-PARCEHIS-DB-INSERT-1 */
        public void R3150_00_INSERT_PARCEHIS_DB_INSERT_1()
        {
            /*" -3660- EXEC SQL INSERT INTO SEGUROS.PARCELA_HISTORICO (NUM_APOLICE ,NUM_ENDOSSO ,NUM_PARCELA ,DAC_PARCELA ,DATA_MOVIMENTO ,COD_OPERACAO ,HORA_OPERACAO ,OCORR_HISTORICO ,PRM_TARIFARIO ,VAL_DESCONTO ,PRM_LIQUIDO ,ADICIONAL_FRACIO ,VAL_CUSTO_EMISSAO ,VAL_IOCC ,PRM_TOTAL ,VAL_OPERACAO ,DATA_VENCIMENTO ,BCO_COBRANCA ,AGE_COBRANCA ,NUM_AVISO_CREDITO ,ENDOS_CANCELA ,SIT_CONTABIL ,COD_USUARIO ,RENUM_DOCUMENTO ,DATA_QUITACAO ,COD_EMPRESA ,TIMESTAMP) VALUES (:PARCEHIS-NUM-APOLICE ,:PARCEHIS-NUM-ENDOSSO ,:PARCEHIS-NUM-PARCELA ,:PARCEHIS-DAC-PARCELA ,:PARCEHIS-DATA-MOVIMENTO ,:PARCEHIS-COD-OPERACAO , CURRENT TIME ,:PARCEHIS-OCORR-HISTORICO ,:PARCEHIS-PRM-TARIFARIO ,:PARCEHIS-VAL-DESCONTO ,:PARCEHIS-PRM-LIQUIDO ,:PARCEHIS-ADICIONAL-FRACIO ,:PARCEHIS-VAL-CUSTO-EMISSAO ,:PARCEHIS-VAL-IOCC ,:PARCEHIS-PRM-TOTAL ,:PARCEHIS-VAL-OPERACAO ,:PARCEHIS-DATA-VENCIMENTO ,:PARCEHIS-BCO-COBRANCA ,:PARCEHIS-AGE-COBRANCA ,:PARCEHIS-NUM-AVISO-CREDITO ,:PARCEHIS-ENDOS-CANCELA ,:PARCEHIS-SIT-CONTABIL ,:PARCEHIS-COD-USUARIO ,:PARCEHIS-RENUM-DOCUMENTO ,:PARCEHIS-DATA-QUITACAO:VIND-NULL01 ,:PARCEHIS-COD-EMPRESA:VIND-NULL02 , CURRENT TIMESTAMP) END-EXEC. */

            var r3150_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1 = new R3150_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1()
            {
                PARCEHIS_NUM_APOLICE = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.ToString(),
                PARCEHIS_NUM_ENDOSSO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO.ToString(),
                PARCEHIS_NUM_PARCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA.ToString(),
                PARCEHIS_DAC_PARCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DAC_PARCELA.ToString(),
                PARCEHIS_DATA_MOVIMENTO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO.ToString(),
                PARCEHIS_COD_OPERACAO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO.ToString(),
                PARCEHIS_OCORR_HISTORICO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO.ToString(),
                PARCEHIS_PRM_TARIFARIO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TARIFARIO.ToString(),
                PARCEHIS_VAL_DESCONTO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_DESCONTO.ToString(),
                PARCEHIS_PRM_LIQUIDO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_LIQUIDO.ToString(),
                PARCEHIS_ADICIONAL_FRACIO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ADICIONAL_FRACIO.ToString(),
                PARCEHIS_VAL_CUSTO_EMISSAO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_CUSTO_EMISSAO.ToString(),
                PARCEHIS_VAL_IOCC = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_IOCC.ToString(),
                PARCEHIS_PRM_TOTAL = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL.ToString(),
                PARCEHIS_VAL_OPERACAO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_OPERACAO.ToString(),
                PARCEHIS_DATA_VENCIMENTO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO.ToString(),
                PARCEHIS_BCO_COBRANCA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_BCO_COBRANCA.ToString(),
                PARCEHIS_AGE_COBRANCA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_AGE_COBRANCA.ToString(),
                PARCEHIS_NUM_AVISO_CREDITO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_AVISO_CREDITO.ToString(),
                PARCEHIS_ENDOS_CANCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ENDOS_CANCELA.ToString(),
                PARCEHIS_SIT_CONTABIL = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_SIT_CONTABIL.ToString(),
                PARCEHIS_COD_USUARIO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_USUARIO.ToString(),
                PARCEHIS_RENUM_DOCUMENTO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_RENUM_DOCUMENTO.ToString(),
                PARCEHIS_DATA_QUITACAO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO.ToString(),
                VIND_NULL01 = VIND_NULL01.ToString(),
                PARCEHIS_COD_EMPRESA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_EMPRESA.ToString(),
                VIND_NULL02 = VIND_NULL02.ToString(),
            };

            R3150_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1.Execute(r3150_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3150_99_SAIDA*/

        [StopWatch]
        /*" R3200-00-SELECT-APOLICOB-SECTION */
        private void R3200_00_SELECT_APOLICOB_SECTION()
        {
            /*" -3680- MOVE '3200' TO WNR-EXEC-SQL. */
            _.Move("3200", W.WABEND.WNR_EXEC_SQL);

            /*" -3719- PERFORM R3200_00_SELECT_APOLICOB_DB_SELECT_1 */

            R3200_00_SELECT_APOLICOB_DB_SELECT_1();

            /*" -3723- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3724- DISPLAY 'R3200-00 - PROBLEMAS NO SELECT(APOLICOB)' */
                _.Display($"R3200-00 - PROBLEMAS NO SELECT(APOLICOB)");

                /*" -3725- DISPLAY ' APOLICE    = ' ENDOSSOS-NUM-APOLICE */
                _.Display($" APOLICE    = {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE}");

                /*" -3725- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3200-00-SELECT-APOLICOB-DB-SELECT-1 */
        public void R3200_00_SELECT_APOLICOB_DB_SELECT_1()
        {
            /*" -3719- EXEC SQL SELECT NUM_APOLICE ,NUM_ENDOSSO ,NUM_ITEM ,OCORR_HISTORICO ,RAMO_COBERTURA ,MODALI_COBERTURA ,COD_COBERTURA ,IMP_SEGURADA_IX ,PRM_TARIFARIO_IX ,IMP_SEGURADA_VAR ,PRM_TARIFARIO_VAR ,PCT_COBERTURA ,FATOR_MULTIPLICA ,DATA_INIVIGENCIA ,DATA_TERVIGENCIA ,COD_EMPRESA ,SIT_REGISTRO INTO :APOLICOB-NUM-APOLICE ,:APOLICOB-NUM-ENDOSSO ,:APOLICOB-NUM-ITEM ,:APOLICOB-OCORR-HISTORICO ,:APOLICOB-RAMO-COBERTURA ,:APOLICOB-MODALI-COBERTURA ,:APOLICOB-COD-COBERTURA ,:APOLICOB-IMP-SEGURADA-IX ,:APOLICOB-PRM-TARIFARIO-IX ,:APOLICOB-IMP-SEGURADA-VAR ,:APOLICOB-PRM-TARIFARIO-VAR ,:APOLICOB-PCT-COBERTURA ,:APOLICOB-FATOR-MULTIPLICA ,:APOLICOB-DATA-INIVIGENCIA ,:APOLICOB-DATA-TERVIGENCIA ,:APOLICOB-COD-EMPRESA:VIND-NULL01 ,:APOLICOB-SIT-REGISTRO:VIND-NULL02 FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r3200_00_SELECT_APOLICOB_DB_SELECT_1_Query1 = new R3200_00_SELECT_APOLICOB_DB_SELECT_1_Query1()
            {
                ENDOSSOS_NUM_APOLICE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.ToString(),
            };

            var executed_1 = R3200_00_SELECT_APOLICOB_DB_SELECT_1_Query1.Execute(r3200_00_SELECT_APOLICOB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICOB_NUM_APOLICE, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE);
                _.Move(executed_1.APOLICOB_NUM_ENDOSSO, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ENDOSSO);
                _.Move(executed_1.APOLICOB_NUM_ITEM, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ITEM);
                _.Move(executed_1.APOLICOB_OCORR_HISTORICO, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_OCORR_HISTORICO);
                _.Move(executed_1.APOLICOB_RAMO_COBERTURA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA);
                _.Move(executed_1.APOLICOB_MODALI_COBERTURA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_MODALI_COBERTURA);
                _.Move(executed_1.APOLICOB_COD_COBERTURA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA);
                _.Move(executed_1.APOLICOB_IMP_SEGURADA_IX, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX);
                _.Move(executed_1.APOLICOB_PRM_TARIFARIO_IX, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX);
                _.Move(executed_1.APOLICOB_IMP_SEGURADA_VAR, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_VAR);
                _.Move(executed_1.APOLICOB_PRM_TARIFARIO_VAR, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_VAR);
                _.Move(executed_1.APOLICOB_PCT_COBERTURA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PCT_COBERTURA);
                _.Move(executed_1.APOLICOB_FATOR_MULTIPLICA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);
                _.Move(executed_1.APOLICOB_DATA_INIVIGENCIA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_INIVIGENCIA);
                _.Move(executed_1.APOLICOB_DATA_TERVIGENCIA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_TERVIGENCIA);
                _.Move(executed_1.APOLICOB_COD_EMPRESA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_EMPRESA);
                _.Move(executed_1.VIND_NULL01, VIND_NULL01);
                _.Move(executed_1.APOLICOB_SIT_REGISTRO, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_SIT_REGISTRO);
                _.Move(executed_1.VIND_NULL02, VIND_NULL02);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/

        [StopWatch]
        /*" R3210-00-INSERT-APOLICOB-SECTION */
        private void R3210_00_INSERT_APOLICOB_SECTION()
        {
            /*" -3738- MOVE '3210' TO WNR-EXEC-SQL. */
            _.Move("3210", W.WABEND.WNR_EXEC_SQL);

            /*" -3741- ADD 1 TO IN-APOLICOB. */
            W.IN_APOLICOB.Value = W.IN_APOLICOB + 1;

            /*" -3780- PERFORM R3210_00_INSERT_APOLICOB_DB_INSERT_1 */

            R3210_00_INSERT_APOLICOB_DB_INSERT_1();

            /*" -3784- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3785- DISPLAY 'R3210-00 - PROBLEMAS NO INSERT(APOLICOB)   ' */
                _.Display($"R3210-00 - PROBLEMAS NO INSERT(APOLICOB)   ");

                /*" -3786- DISPLAY ' APOLICE    = ' APOLICOB-NUM-APOLICE */
                _.Display($" APOLICE    = {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE}");

                /*" -3787- DISPLAY ' ENDOSSO    = ' APOLICOB-NUM-ENDOSSO */
                _.Display($" ENDOSSO    = {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ENDOSSO}");

                /*" -3788- DISPLAY ' RAMO       = ' APOLICOB-RAMO-COBERTURA */
                _.Display($" RAMO       = {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA}");

                /*" -3789- DISPLAY ' COBERTURA  = ' APOLICOB-COD-COBERTURA */
                _.Display($" COBERTURA  = {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA}");

                /*" -3789- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3210-00-INSERT-APOLICOB-DB-INSERT-1 */
        public void R3210_00_INSERT_APOLICOB_DB_INSERT_1()
        {
            /*" -3780- EXEC SQL INSERT INTO SEGUROS.APOLICE_COBERTURAS (NUM_APOLICE ,NUM_ENDOSSO ,NUM_ITEM ,OCORR_HISTORICO ,RAMO_COBERTURA ,MODALI_COBERTURA ,COD_COBERTURA ,IMP_SEGURADA_IX ,PRM_TARIFARIO_IX ,IMP_SEGURADA_VAR ,PRM_TARIFARIO_VAR ,PCT_COBERTURA ,FATOR_MULTIPLICA ,DATA_INIVIGENCIA ,DATA_TERVIGENCIA ,COD_EMPRESA ,TIMESTAMP ,SIT_REGISTRO) VALUES (:APOLICOB-NUM-APOLICE ,:APOLICOB-NUM-ENDOSSO ,:APOLICOB-NUM-ITEM ,:APOLICOB-OCORR-HISTORICO ,:APOLICOB-RAMO-COBERTURA ,:APOLICOB-MODALI-COBERTURA ,:APOLICOB-COD-COBERTURA ,:APOLICOB-IMP-SEGURADA-IX ,:APOLICOB-PRM-TARIFARIO-IX ,:APOLICOB-IMP-SEGURADA-VAR ,:APOLICOB-PRM-TARIFARIO-VAR ,:APOLICOB-PCT-COBERTURA ,:APOLICOB-FATOR-MULTIPLICA ,:APOLICOB-DATA-INIVIGENCIA ,:APOLICOB-DATA-TERVIGENCIA ,:APOLICOB-COD-EMPRESA:VIND-NULL01 , CURRENT TIMESTAMP ,:APOLICOB-SIT-REGISTRO:VIND-NULL02) END-EXEC. */

            var r3210_00_INSERT_APOLICOB_DB_INSERT_1_Insert1 = new R3210_00_INSERT_APOLICOB_DB_INSERT_1_Insert1()
            {
                APOLICOB_NUM_APOLICE = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE.ToString(),
                APOLICOB_NUM_ENDOSSO = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ENDOSSO.ToString(),
                APOLICOB_NUM_ITEM = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ITEM.ToString(),
                APOLICOB_OCORR_HISTORICO = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_OCORR_HISTORICO.ToString(),
                APOLICOB_RAMO_COBERTURA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA.ToString(),
                APOLICOB_MODALI_COBERTURA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_MODALI_COBERTURA.ToString(),
                APOLICOB_COD_COBERTURA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA.ToString(),
                APOLICOB_IMP_SEGURADA_IX = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX.ToString(),
                APOLICOB_PRM_TARIFARIO_IX = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX.ToString(),
                APOLICOB_IMP_SEGURADA_VAR = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_VAR.ToString(),
                APOLICOB_PRM_TARIFARIO_VAR = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_VAR.ToString(),
                APOLICOB_PCT_COBERTURA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PCT_COBERTURA.ToString(),
                APOLICOB_FATOR_MULTIPLICA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA.ToString(),
                APOLICOB_DATA_INIVIGENCIA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_INIVIGENCIA.ToString(),
                APOLICOB_DATA_TERVIGENCIA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_TERVIGENCIA.ToString(),
                APOLICOB_COD_EMPRESA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_EMPRESA.ToString(),
                VIND_NULL01 = VIND_NULL01.ToString(),
                APOLICOB_SIT_REGISTRO = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_SIT_REGISTRO.ToString(),
                VIND_NULL02 = VIND_NULL02.ToString(),
            };

            R3210_00_INSERT_APOLICOB_DB_INSERT_1_Insert1.Execute(r3210_00_INSERT_APOLICOB_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3210_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -3801- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, W.WABEND.WSQLCODE);

            /*" -3802- MOVE SQLERRD(1) TO WSQLERRD1 */
            _.Move(DB.SQLERRD[1], W.WABEND.WSQLERRD1);

            /*" -3803- MOVE SQLERRD(2) TO WSQLERRD2 */
            _.Move(DB.SQLERRD[2], W.WABEND.WSQLERRD2);

            /*" -3804- MOVE SQLERRMC TO WSQLERRMC */
            _.Move(DB.SQLERRMC, W.WABEND.WSQLERRMC);

            /*" -3806- DISPLAY WABEND. */
            _.Display(W.WABEND);

            /*" -3806- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -3811- CLOSE SAIDA01 SAIDA02. */
            SAIDA01.Close();
            SAIDA02.Close();

            /*" -3813- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -3813- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}