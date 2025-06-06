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
using Sias.Bilhetes.DB2.BI5166B;

namespace Code
{
    public class BI5166B
    {
        public bool IsCall { get; set; }

        public BI5166B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  BILHETE                            *      */
        /*"      *   PROGRAMA ...............  BI5166B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  CLOVIS                             *      */
        /*"      *   PROGRAMADOR ............  CLOVIS                             *      */
        /*"      *   DATA CODIFICACAO .......  11/07/2019                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  GERA RELATORIO DE BILHETES EM      *      */
        /*"      *                             CRITICA.                           *      */
        /*"      *                                                                *      */
        /*"      *   HIST�RIA 204961           GEROU A NECESSIDADE DO RELTORIO.   *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.03  *   VERSAO 03 - INCIDENTE 472.492   TAREFA 472505                *      */
        /*"      *             - DEVE SER PEGAR O SEQ-CRITICA RETORNADO NA        *      */
        /*"      *               CONSULTA E PASSAR PARA REALIZAR A EXCLUSAO LOGICA*      */
        /*"      *                                                                *      */
        /*"      *   EM 28/02/2023 - HUSNI ALI HUSNI                              *      */
        /*"      *                                        PROCURE POR V.03        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.02  *   VERSAO 02 - DEMANDA 402.982                                  *      */
        /*"      *             - GRAVAR ERROS DA PROPOSTA NA NOVA TABELA          *      */
        /*"      *               VG_CRITICA_PROPOSTA PARA POSTERIOR ANALISE DO    *      */
        /*"      *               GESTOR NO ATALHO 04.23                           *      */
        /*"      *                                                                *      */
        /*"      *   EM 14/02/2023 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                        PROCURE POR V.02        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        #endregion


        #region VARIABLES

        public FileBasis _SAIDA01 { get; set; } = new FileBasis(new PIC("X", "0600", "X(0600)"));

        public FileBasis SAIDA01
        {
            get
            {
                _.Move(REG_SAIDA01, _SAIDA01); VarBasis.RedefinePassValue(REG_SAIDA01, _SAIDA01, REG_SAIDA01); return _SAIDA01;
            }
        }
        public FileBasis _SAIDA02 { get; set; } = new FileBasis(new PIC("X", "0600", "X(0600)"));

        public FileBasis SAIDA02
        {
            get
            {
                _.Move(REG_SAIDA02, _SAIDA02); VarBasis.RedefinePassValue(REG_SAIDA02, _SAIDA02, REG_SAIDA02); return _SAIDA02;
            }
        }
        public FileBasis _SAIDA03 { get; set; } = new FileBasis(new PIC("X", "0600", "X(0600)"));

        public FileBasis SAIDA03
        {
            get
            {
                _.Move(REG_SAIDA03, _SAIDA03); VarBasis.RedefinePassValue(REG_SAIDA03, _SAIDA03, REG_SAIDA03); return _SAIDA03;
            }
        }
        public FileBasis _SAIDA04 { get; set; } = new FileBasis(new PIC("X", "0600", "X(0600)"));

        public FileBasis SAIDA04
        {
            get
            {
                _.Move(REG_SAIDA04, _SAIDA04); VarBasis.RedefinePassValue(REG_SAIDA04, _SAIDA04, REG_SAIDA04); return _SAIDA04;
            }
        }
        /*"01         REG-SAIDA01           PIC  X(600).*/
        public StringBasis REG_SAIDA01 { get; set; } = new StringBasis(new PIC("X", "600", "X(600)."), @"");
        /*"01         REG-SAIDA02           PIC  X(600).*/
        public StringBasis REG_SAIDA02 { get; set; } = new StringBasis(new PIC("X", "600", "X(600)."), @"");
        /*"01         REG-SAIDA03           PIC  X(600).*/
        public StringBasis REG_SAIDA03 { get; set; } = new StringBasis(new PIC("X", "600", "X(600)."), @"");
        /*"01         REG-SAIDA04           PIC  X(600).*/
        public StringBasis REG_SAIDA04 { get; set; } = new StringBasis(new PIC("X", "600", "X(600)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77    VIND-NULL01               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL01 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL02               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL02 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V1SIST-DTMOVABE-01Y       PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE_01Y { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V1SIST-DTMOVABE-15D       PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE_15D { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V1SIST-DTMOVABE-06D       PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE_06D { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WPREMIO-BASE              PIC S9(013)V99      COMP-3.*/
        public DoubleBasis WPREMIO_BASE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  W.*/
        public BI5166B_W W { get; set; } = new BI5166B_W();
        public class BI5166B_W : VarBasis
        {
            /*"  03  WFIM-MOVIMENTO            PIC  X(001)         VALUE SPACES*/
            public StringBasis WFIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WFIM-ERROS                PIC  X(001)         VALUE SPACES*/
            public StringBasis WFIM_ERROS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WTEM-CREDITO              PIC  X(001)         VALUE SPACES*/
            public StringBasis WTEM_CREDITO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  AC-ARQUIVO                PIC  9(001)         VALUE ZEROS.*/
            public IntBasis AC_ARQUIVO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  03  LD-BILHETE                PIC  9(007)         VALUE ZEROS.*/
            public IntBasis LD_BILHETE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-COBERTURA              PIC  9(009)         VALUE ZEROS.*/
            public IntBasis DP_COBERTURA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  DP-APOLICE                PIC  9(009)         VALUE ZEROS.*/
            public IntBasis DP_APOLICE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  DP-CREDITO                PIC  9(009)         VALUE ZEROS.*/
            public IntBasis DP_CREDITO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  DP-VENCTO                 PIC  9(009)         VALUE ZEROS.*/
            public IntBasis DP_VENCTO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  DP-PLANO                  PIC  9(009)         VALUE ZEROS.*/
            public IntBasis DP_PLANO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  GV-ARQUIVO01              PIC  9(009)         VALUE ZEROS.*/
            public IntBasis GV_ARQUIVO01 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  GV-ARQUIVO02              PIC  9(009)         VALUE ZEROS.*/
            public IntBasis GV_ARQUIVO02 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  GV-ARQUIVO03              PIC  9(009)         VALUE ZEROS.*/
            public IntBasis GV_ARQUIVO03 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  GV-ARQUIVO04              PIC  9(009)         VALUE ZEROS.*/
            public IntBasis GV_ARQUIVO04 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  NT-BILHEERR               PIC  9(009)         VALUE ZEROS.*/
            public IntBasis NT_BILHEERR { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  UP-BILHEERR               PIC  9(009)         VALUE ZEROS.*/
            public IntBasis UP_BILHEERR { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  UP-BILHETE                PIC  9(009)         VALUE  ZEROS*/
            public IntBasis UP_BILHETE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  NT-BILHETE                PIC  9(009)         VALUE  ZEROS*/
            public IntBasis NT_BILHETE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03         AC-LIDOS           PIC  9(013)    VALUE   ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  03         FILLER             REDEFINES      AC-LIDOS.*/
            private _REDEF_BI5166B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_BI5166B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_BI5166B_FILLER_0(); _.Move(AC_LIDOS, _filler_0); VarBasis.RedefinePassValue(AC_LIDOS, _filler_0, AC_LIDOS); _filler_0.ValueChanged += () => { _.Move(_filler_0, AC_LIDOS); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, AC_LIDOS); }
            }  //Redefines
            public class _REDEF_BI5166B_FILLER_0 : VarBasis
            {
                /*"      10     LD-PARTE1          PIC  9(009).*/
                public IntBasis LD_PARTE1 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"      10     LD-PARTE2          PIC  9(004).*/
                public IntBasis LD_PARTE2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  03         WDATA-REL         PIC  X(010)    VALUE SPACES.*/

                public _REDEF_BI5166B_FILLER_0()
                {
                    LD_PARTE1.ValueChanged += OnValueChanged;
                    LD_PARTE2.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03         FILLER            REDEFINES      WDATA-REL.*/
            private _REDEF_BI5166B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_BI5166B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_BI5166B_FILLER_1(); _.Move(WDATA_REL, _filler_1); VarBasis.RedefinePassValue(WDATA_REL, _filler_1, WDATA_REL); _filler_1.ValueChanged += () => { _.Move(_filler_1, WDATA_REL); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, WDATA_REL); }
            }  //Redefines
            public class _REDEF_BI5166B_FILLER_1 : VarBasis
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

                public _REDEF_BI5166B_FILLER_1()
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
            private _REDEF_BI5166B_FILLER_4 _filler_4 { get; set; }
            public _REDEF_BI5166B_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_BI5166B_FILLER_4(); _.Move(WTIME_DAY, _filler_4); VarBasis.RedefinePassValue(WTIME_DAY, _filler_4, WTIME_DAY); _filler_4.ValueChanged += () => { _.Move(_filler_4, WTIME_DAY); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, WTIME_DAY); }
            }  //Redefines
            public class _REDEF_BI5166B_FILLER_4 : VarBasis
            {
                /*"    10       WTIME-DAYR.*/
                public BI5166B_WTIME_DAYR WTIME_DAYR { get; set; } = new BI5166B_WTIME_DAYR();
                public class BI5166B_WTIME_DAYR : VarBasis
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

                    public BI5166B_WTIME_DAYR()
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

                public _REDEF_BI5166B_FILLER_4()
                {
                    WTIME_DAYR.ValueChanged += OnValueChanged;
                    WTIME_2PT3.ValueChanged += OnValueChanged;
                    WTIME_CCSE.ValueChanged += OnValueChanged;
                }

            }
            public BI5166B_WS_TIME WS_TIME { get; set; } = new BI5166B_WS_TIME();
            public class BI5166B_WS_TIME : VarBasis
            {
                /*"      10     WS-HH-TIME         PIC  9(002).*/
                public IntBasis WS_HH_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-MM-TIME         PIC  9(002).*/
                public IntBasis WS_MM_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-SS-TIME         PIC  9(002).*/
                public IntBasis WS_SS_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-CC-TIME         PIC  9(002).*/
                public IntBasis WS_CC_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WS-ERROS.*/
            }
            public BI5166B_WS_ERROS WS_ERROS { get; set; } = new BI5166B_WS_ERROS();
            public class BI5166B_WS_ERROS : VarBasis
            {
                /*"      10     WS-CODERRO         PIC  9(005).*/
                public IntBasis WS_CODERRO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"      10     FILLER             PIC  X(003)  VALUE ' -'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" -");
                /*"      10     WS-DESERRO         PIC  X(039).*/
                public StringBasis WS_DESERRO { get; set; } = new StringBasis(new PIC("X", "39", "X(039)."), @"");
                /*"  03        WABEND.*/
            }
            public BI5166B_WABEND WABEND { get; set; } = new BI5166B_WABEND();
            public class BI5166B_WABEND : VarBasis
            {
                /*"    05      FILLER              PIC  X(010) VALUE           ' BI5166B  '.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" BI5166B  ");
                /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05      WNR-EXEC-SQL        PIC  X(004) VALUE    SPACES.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"    05      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD1 = '.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"    05      WSQLERRD1           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD2 = '.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05      WSQLERRD2           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRMC = '.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRMC = ");
                /*"    05      WSQLERRMC           PIC  X(070) VALUE    SPACES.*/
                public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                /*"01            AUX-RELATORIO.*/
            }
        }
        public BI5166B_AUX_RELATORIO AUX_RELATORIO { get; set; } = new BI5166B_AUX_RELATORIO();
        public class BI5166B_AUX_RELATORIO : VarBasis
        {
            /*"  03          LC01.*/
            public BI5166B_LC01 LC01 { get; set; } = new BI5166B_LC01();
            public class BI5166B_LC01 : VarBasis
            {
                /*"    10        FILLER              PIC  X(016)  VALUE             'PROPOSTA'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"PROPOSTA");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(011)  VALUE             'BILHETE'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"BILHETE");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(005)  VALUE             'FONTE'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"FONTE");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(004)  VALUE             'RAMO'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"RAMO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(007)  VALUE             'PRODUTO'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"PRODUTO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(007)  VALUE             'PRDSIVP'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"PRDSIVP");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(011)  VALUE             'PONTO VENDA'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"PONTO VENDA");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(010)  VALUE             'DATA VENDA'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DATA VENDA");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(010)  VALUE             'QUITACAO'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"QUITACAO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(011)  VALUE             '     VALOR '.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"     VALOR ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(040)  VALUE             'SEGURADO'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"SEGURADO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(015)  VALUE             'CGCCPF '.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"CGCCPF ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(010)  VALUE             'NASCIMENTO'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"NASCIMENTO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(020)  VALUE             'PROFISSAO'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"PROFISSAO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(004)  VALUE             'SEXO'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"SEXO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(008)  VALUE             'ESTCIVIL'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"ESTCIVIL");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(008)  VALUE             'USUARIO'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"USUARIO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(013)  VALUE             'APOLANT      '.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"APOLANT      ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(054)  VALUE             'SITUACAO     '.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "54", "X(054)"), @"SITUACAO     ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(009)  VALUE             'TIPCANCEL'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"TIPCANCEL");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(008)  VALUE             'SINISTRO'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"SINISTRO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(010)  VALUE             'DTCANCEL'.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DTCANCEL");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(005)  VALUE             'OPCAO'.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"OPCAO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(018)  VALUE             'CONTA BILHETE '.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"CONTA BILHETE ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(005)  VALUE             'COBER'.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"COBER");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(018)  VALUE             'CONTA PROPOFID'.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"CONTA PROPOFID");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(006)  VALUE             'ORIGEM'.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"ORIGEM");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(005)  VALUE             'PLANO'.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"PLANO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(065)  VALUE             'MENSAGEM'.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "65", "X(065)"), @"MENSAGEM");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(010)  VALUE             'DATA PAGTO'.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DATA PAGTO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(010)  VALUE             'DT VENCTO '.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DT VENCTO ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(010)  VALUE             'DT ENVIO  '.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DT ENVIO  ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(040)  VALUE             'DESCRICAO ERRO '.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"DESCRICAO ERRO ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(018)  VALUE  SPACES.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"");
                /*"  03          LD01.*/
            }
            public BI5166B_LD01 LD01 { get; set; } = new BI5166B_LD01();
            public class BI5166B_LD01 : VarBasis
            {
                /*"    10        LD01-PROPOSTA       PIC  ZZZZZZZZZZZZZZZ9.*/
                public IntBasis LD01_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "16", "ZZZZZZZZZZZZZZZ9."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-BILHETE        PIC  ZZZZZZZZZZ9.*/
                public IntBasis LD01_BILHETE { get; set; } = new IntBasis(new PIC("9", "11", "ZZZZZZZZZZ9."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-FONTE          PIC  ZZZZ9.*/
                public IntBasis LD01_FONTE { get; set; } = new IntBasis(new PIC("9", "5", "ZZZZ9."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-RAMO           PIC  ZZZ9.*/
                public IntBasis LD01_RAMO { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-PRODUTO        PIC  ZZZZZZ9.*/
                public IntBasis LD01_PRODUTO { get; set; } = new IntBasis(new PIC("9", "7", "ZZZZZZ9."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-PRDSIVPF       PIC  ZZZZZZ9.*/
                public IntBasis LD01_PRDSIVPF { get; set; } = new IntBasis(new PIC("9", "7", "ZZZZZZ9."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-AGEVENDA       PIC  ZZZZZZZZZZ9.*/
                public IntBasis LD01_AGEVENDA { get; set; } = new IntBasis(new PIC("9", "11", "ZZZZZZZZZZ9."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-DTVENDA        PIC  X(010).*/
                public StringBasis LD01_DTVENDA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-DTQITBCO       PIC  X(010).*/
                public StringBasis LD01_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-VALOR          PIC  ZZZ.ZZ9,99-.*/
                public DoubleBasis LD01_VALOR { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V99-."), 3);
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-SEGURADO       PIC  X(040).*/
                public StringBasis LD01_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-CGCCPF         PIC  ZZZZZZZZZZZZZZ9.*/
                public IntBasis LD01_CGCCPF { get; set; } = new IntBasis(new PIC("9", "15", "ZZZZZZZZZZZZZZ9."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-DTNASC         PIC  X(010).*/
                public StringBasis LD01_DTNASC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-PROFISSAO      PIC  X(020).*/
                public StringBasis LD01_PROFISSAO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(003)  VALUE  SPACES.*/
                public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10        LD01-SEXO           PIC  X(001).*/
                public StringBasis LD01_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(007)  VALUE  SPACES.*/
                public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"    10        LD01-ESTCIVIL       PIC  X(001).*/
                public StringBasis LD01_ESTCIVIL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_96 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-USUARIO        PIC  X(008).*/
                public StringBasis LD01_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_97 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-APOLANT        PIC  ZZZZZZZZZZZZ9.*/
                public IntBasis LD01_APOLANT { get; set; } = new IntBasis(new PIC("9", "13", "ZZZZZZZZZZZZ9."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_98 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-SITUACAO       PIC  X(001).*/
                public StringBasis LD01_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' -'.*/
                public StringBasis FILLER_99 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" -");
                /*"    10        LD01-DESCSITU       PIC  X(050).*/
                public StringBasis LD01_DESCSITU { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_100 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(008)  VALUE  SPACES.*/
                public StringBasis FILLER_101 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"    10        LD01-TIPCANCEL      PIC  X(001).*/
                public StringBasis LD01_TIPCANCEL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_102 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(007)  VALUE  SPACES.*/
                public StringBasis FILLER_103 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"    10        LD01-SINISTRO       PIC  X(001).*/
                public StringBasis LD01_SINISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_104 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-DTCANCEL       PIC  X(010).*/
                public StringBasis LD01_DTCANCEL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_105 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-OPCAO          PIC  ZZZZ9.*/
                public IntBasis LD01_OPCAO { get; set; } = new IntBasis(new PIC("9", "5", "ZZZZ9."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_106 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-NUMCONTA       PIC  ZZZZZZZZZZZZ9.*/
                public IntBasis LD01_NUMCONTA { get; set; } = new IntBasis(new PIC("9", "13", "ZZZZZZZZZZZZ9."));
                /*"    10        FILLER              PIC  X(001)  VALUE '-'.*/
                public StringBasis FILLER_107 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10        LD01-DIGCONTA       PIC  ZZZ9.*/
                public IntBasis LD01_DIGCONTA { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_108 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(004)  VALUE  SPACES.*/
                public StringBasis FILLER_109 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10        LD01-OPCOBER        PIC  X(001).*/
                public StringBasis LD01_OPCOBER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_110 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-NUMCTAVEN      PIC  ZZZZZZZZZZZZ9.*/
                public IntBasis LD01_NUMCTAVEN { get; set; } = new IntBasis(new PIC("9", "13", "ZZZZZZZZZZZZ9."));
                /*"    10        FILLER              PIC  X(001)  VALUE '-'.*/
                public StringBasis FILLER_111 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10        LD01-DIGCTAVEN      PIC  ZZZ9.*/
                public IntBasis LD01_DIGCTAVEN { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_112 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-ORIGEM         PIC  ZZZZZ9.*/
                public IntBasis LD01_ORIGEM { get; set; } = new IntBasis(new PIC("9", "6", "ZZZZZ9."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_113 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-PLANO          PIC  ZZZZ9.*/
                public IntBasis LD01_PLANO { get; set; } = new IntBasis(new PIC("9", "5", "ZZZZ9."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_114 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-MENSERRO.*/
                public BI5166B_LD01_MENSERRO LD01_MENSERRO { get; set; } = new BI5166B_LD01_MENSERRO();
                public class BI5166B_LD01_MENSERRO : VarBasis
                {
                    /*"      15      LD01-MENSAGEM       PIC  X(035).*/
                    public StringBasis LD01_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "35", "X(035)."), @"");
                    /*"      15      LD01-MENSAGEM1      PIC  X(030).*/
                    public StringBasis LD01_MENSAGEM1 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                    /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                }
                public StringBasis FILLER_115 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-DTPAGTO        PIC  X(010).*/
                public StringBasis LD01_DTPAGTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_116 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-DTVENCTO       PIC  X(010).*/
                public StringBasis LD01_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_117 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-DTENVIO        PIC  X(010).*/
                public StringBasis LD01_DTENVIO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_118 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-DESCERRO       PIC  X(040).*/
                public StringBasis LD01_DESCERRO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_119 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(018)  VALUE  SPACES.*/
                public StringBasis FILLER_120 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"");
            }
        }


        public Copies.SPVG001V SPVG001V { get; set; } = new Copies.SPVG001V();
        public Copies.SPVG001W SPVG001W { get; set; } = new Copies.SPVG001W();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.BILHETE BILHETE { get; set; } = new Dclgens.BILHETE();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.BILHECOB BILHECOB { get; set; } = new Dclgens.BILHECOB();
        public Dclgens.RCAPS RCAPS { get; set; } = new Dclgens.RCAPS();
        public Dclgens.MOVDEBCE MOVDEBCE { get; set; } = new Dclgens.MOVDEBCE();
        public Dclgens.BILHEERR BILHEERR { get; set; } = new Dclgens.BILHEERR();
        public BI5166B_V0BILHETE V0BILHETE { get; set; } = new BI5166B_V0BILHETE();
        public BI5166B_V0BILHEERR V0BILHEERR { get; set; } = new BI5166B_V0BILHEERR();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SAIDA01_FILE_NAME_P, string SAIDA02_FILE_NAME_P, string SAIDA03_FILE_NAME_P, string SAIDA04_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SAIDA01.SetFile(SAIDA01_FILE_NAME_P);
                SAIDA02.SetFile(SAIDA02_FILE_NAME_P);
                SAIDA03.SetFile(SAIDA03_FILE_NAME_P);
                SAIDA04.SetFile(SAIDA04_FILE_NAME_P);

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
            /*" -403- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", W.WABEND.WNR_EXEC_SQL);

            /*" -404- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -406- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -408- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -411- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -412- DISPLAY '          PROGRAMA EM EXECUCAO BI5166B             ' */
            _.Display($"          PROGRAMA EM EXECUCAO BI5166B             ");

            /*" -413- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -414- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -415- DISPLAY 'VERSAO V.03: ' FUNCTION WHEN-COMPILED ' - 472.492' */

            $"VERSAO V.03: FUNCTION{_.WhenCompiled()} - 472.492"
            .Display();

            /*" -416- DISPLAY ' ' */
            _.Display($" ");

            /*" -423- DISPLAY 'INICIOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"INICIOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -424- DISPLAY '                               ' */
            _.Display($"                               ");

            /*" -425- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -428- DISPLAY '                               ' */
            _.Display($"                               ");

            /*" -431- PERFORM R0050-00-INICIO. */

            R0050_00_INICIO_SECTION();

            /*" -434- PERFORM R0150-00-SELECIONA. */

            R0150_00_SELECIONA_SECTION();

            /*" -435- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), W.WS_TIME);

            /*" -436- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

            /*" -437- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

            /*" -438- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

            /*" -439- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

            /*" -440- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

            /*" -440- DISPLAY 'FIM    BI5166B    ' WTIME-DAYR. */
            _.Display($"FIM    BI5166B    {W.FILLER_4.WTIME_DAYR}");

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -445- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -452- CLOSE SAIDA01 SAIDA02 SAIDA03 SAIDA04. */
            SAIDA01.Close();
            SAIDA02.Close();
            SAIDA03.Close();
            SAIDA04.Close();

            /*" -454- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -455- DISPLAY ' ' */
            _.Display($" ");

            /*" -456- DISPLAY 'BI5166B - FIM NORMAL' */
            _.Display($"BI5166B - FIM NORMAL");

            /*" -459- DISPLAY ' ' */
            _.Display($" ");

            /*" -459- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0050-00-INICIO-SECTION */
        private void R0050_00_INICIO_SECTION()
        {
            /*" -468- MOVE '0050' TO WNR-EXEC-SQL. */
            _.Move("0050", W.WABEND.WNR_EXEC_SQL);

            /*" -469- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), W.WS_TIME);

            /*" -470- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

            /*" -471- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

            /*" -472- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

            /*" -473- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

            /*" -474- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

            /*" -477- DISPLAY 'INICIO BI5166B    ' WTIME-DAYR. */
            _.Display($"INICIO BI5166B    {W.FILLER_4.WTIME_DAYR}");

            /*" -483- OPEN OUTPUT SAIDA01 SAIDA02 SAIDA03 SAIDA04. */
            SAIDA01.Open(REG_SAIDA01);
            SAIDA02.Open(REG_SAIDA02);
            SAIDA03.Open(REG_SAIDA03);
            SAIDA04.Open(REG_SAIDA04);

            /*" -486- PERFORM R0100-00-SELECT-SISTEMAS. */

            R0100_00_SELECT_SISTEMAS_SECTION();

            /*" -487- DISPLAY ' ' . */
            _.Display($" ");

            /*" -489- DISPLAY 'DATA DE MOVIMENTO ............... ' SISTEMAS-DATA-MOV-ABERTO. */
            _.Display($"DATA DE MOVIMENTO ............... {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -491- DISPLAY 'DATA DE MOVIMENTO - 06 DIAS ..... ' V1SIST-DTMOVABE-06D */
            _.Display($"DATA DE MOVIMENTO - 06 DIAS ..... {V1SIST_DTMOVABE_06D}");

            /*" -493- DISPLAY 'DATA DE MOVIMENTO - 15 DIAS ..... ' V1SIST-DTMOVABE-15D */
            _.Display($"DATA DE MOVIMENTO - 15 DIAS ..... {V1SIST_DTMOVABE_15D}");

            /*" -495- DISPLAY 'DATA DE MOVIMENTO - 01 ANO ...... ' V1SIST-DTMOVABE-01Y */
            _.Display($"DATA DE MOVIMENTO - 01 ANO ...... {V1SIST_DTMOVABE_01Y}");

            /*" -498- DISPLAY ' ' . */
            _.Display($" ");

            /*" -499- WRITE REG-SAIDA01 FROM LC01. */
            _.Move(AUX_RELATORIO.LC01.GetMoveValues(), REG_SAIDA01);

            SAIDA01.Write(REG_SAIDA01.GetMoveValues().ToString());

            /*" -500- WRITE REG-SAIDA02 FROM LC01. */
            _.Move(AUX_RELATORIO.LC01.GetMoveValues(), REG_SAIDA02);

            SAIDA02.Write(REG_SAIDA02.GetMoveValues().ToString());

            /*" -501- WRITE REG-SAIDA03 FROM LC01. */
            _.Move(AUX_RELATORIO.LC01.GetMoveValues(), REG_SAIDA03);

            SAIDA03.Write(REG_SAIDA03.GetMoveValues().ToString());

            /*" -503- WRITE REG-SAIDA04 FROM LC01. */
            _.Move(AUX_RELATORIO.LC01.GetMoveValues(), REG_SAIDA04);

            SAIDA04.Write(REG_SAIDA04.GetMoveValues().ToString());

            /*" -503- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-SECTION */
        private void R0100_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -516- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", W.WABEND.WNR_EXEC_SQL);

            /*" -529- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -533- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -534- DISPLAY 'R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)' */
                _.Display($"R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)");

                /*" -534- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -529- EXEC SQL SELECT DATA_MOV_ABERTO ,DATA_MOV_ABERTO - 01 YEAR ,DATA_MOV_ABERTO - 06 DAYS ,DATA_MOV_ABERTO - 15 DAYS INTO :SISTEMAS-DATA-MOV-ABERTO ,:V1SIST-DTMOVABE-01Y ,:V1SIST-DTMOVABE-06D ,:V1SIST-DTMOVABE-15D FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'CB' FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.V1SIST_DTMOVABE_01Y, V1SIST_DTMOVABE_01Y);
                _.Move(executed_1.V1SIST_DTMOVABE_06D, V1SIST_DTMOVABE_06D);
                _.Move(executed_1.V1SIST_DTMOVABE_15D, V1SIST_DTMOVABE_15D);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0150-00-SELECIONA-SECTION */
        private void R0150_00_SELECIONA_SECTION()
        {
            /*" -547- MOVE '0150' TO WNR-EXEC-SQL. */
            _.Move("0150", W.WABEND.WNR_EXEC_SQL);

            /*" -548- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), W.WS_TIME);

            /*" -549- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

            /*" -550- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

            /*" -551- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

            /*" -552- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

            /*" -553- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

            /*" -555- DISPLAY 'LEITURA BILHETE   ' WTIME-DAYR. */
            _.Display($"LEITURA BILHETE   {W.FILLER_4.WTIME_DAYR}");

            /*" -556- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", W.WFIM_MOVIMENTO);

            /*" -558- PERFORM R0160-00-DECLARE-BILHETE. */

            R0160_00_DECLARE_BILHETE_SECTION();

            /*" -560- PERFORM R0170-00-FETCH-BILHETE. */

            R0170_00_FETCH_BILHETE_SECTION();

            /*" -563- PERFORM R0180-00-PROCESSA-BILHETE UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!W.WFIM_MOVIMENTO.IsEmpty()))
            {

                R0180_00_PROCESSA_BILHETE_SECTION();
            }

            /*" -564- DISPLAY ' ' . */
            _.Display($" ");

            /*" -565- DISPLAY 'LIDOS BILHETE .............. ' LD-BILHETE. */
            _.Display($"LIDOS BILHETE .............. {W.LD_BILHETE}");

            /*" -566- DISPLAY 'DESPREZA APOLICE EMITIDA ... ' DP-APOLICE. */
            _.Display($"DESPREZA APOLICE EMITIDA ... {W.DP_APOLICE}");

            /*" -567- DISPLAY 'DESPREZA SEM PAGAMENTO ..... ' DP-CREDITO. */
            _.Display($"DESPREZA SEM PAGAMENTO ..... {W.DP_CREDITO}");

            /*" -568- DISPLAY 'DESPREZA A VENCER .......... ' DP-VENCTO. */
            _.Display($"DESPREZA A VENCER .......... {W.DP_VENCTO}");

            /*" -569- DISPLAY ' ' . */
            _.Display($" ");

            /*" -570- DISPLAY 'DELETE ERRO 1802 ........... ' UP-BILHEERR. */
            _.Display($"DELETE ERRO 1802 ........... {W.UP_BILHEERR}");

            /*" -571- DISPLAY 'SEM    ERRO 1802 ........... ' NT-BILHEERR. */
            _.Display($"SEM    ERRO 1802 ........... {W.NT_BILHEERR}");

            /*" -572- DISPLAY ' ' . */
            _.Display($" ");

            /*" -573- DISPLAY 'DESPREZA COBERTURA ......... ' DP-COBERTURA. */
            _.Display($"DESPREZA COBERTURA ......... {W.DP_COBERTURA}");

            /*" -574- DISPLAY 'DESPREZA PLANO ............. ' DP-PLANO. */
            _.Display($"DESPREZA PLANO ............. {W.DP_PLANO}");

            /*" -575- DISPLAY ' ' . */
            _.Display($" ");

            /*" -576- DISPLAY 'ALTERA BILHETE ............ ' UP-BILHETE */
            _.Display($"ALTERA BILHETE ............ {W.UP_BILHETE}");

            /*" -577- DISPLAY 'SEM    BILHETE ............ ' NT-BILHETE */
            _.Display($"SEM    BILHETE ............ {W.NT_BILHETE}");

            /*" -578- DISPLAY ' ' . */
            _.Display($" ");

            /*" -579- DISPLAY 'GRAVADOS SAIDA 01 .......... ' GV-ARQUIVO01. */
            _.Display($"GRAVADOS SAIDA 01 .......... {W.GV_ARQUIVO01}");

            /*" -580- DISPLAY 'GRAVADOS SAIDA 02 .......... ' GV-ARQUIVO02. */
            _.Display($"GRAVADOS SAIDA 02 .......... {W.GV_ARQUIVO02}");

            /*" -581- DISPLAY 'GRAVADOS SAIDA 03 .......... ' GV-ARQUIVO03. */
            _.Display($"GRAVADOS SAIDA 03 .......... {W.GV_ARQUIVO03}");

            /*" -582- DISPLAY 'GRAVADOS SAIDA 04 .......... ' GV-ARQUIVO04. */
            _.Display($"GRAVADOS SAIDA 04 .......... {W.GV_ARQUIVO04}");

            /*" -584- DISPLAY ' ' . */
            _.Display($" ");

            /*" -584- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_99_SAIDA*/

        [StopWatch]
        /*" R0160-00-DECLARE-BILHETE-SECTION */
        private void R0160_00_DECLARE_BILHETE_SECTION()
        {
            /*" -609- MOVE '0160' TO WNR-EXEC-SQL. */
            _.Move("0160", W.WABEND.WNR_EXEC_SQL);

            /*" -644- PERFORM R0160_00_DECLARE_BILHETE_DB_DECLARE_1 */

            R0160_00_DECLARE_BILHETE_DB_DECLARE_1();

            /*" -646- PERFORM R0160_00_DECLARE_BILHETE_DB_OPEN_1 */

            R0160_00_DECLARE_BILHETE_DB_OPEN_1();

            /*" -650- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -651- DISPLAY 'R0160-00 - PROBLEMAS DECLARE (BILHETE)   ' */
                _.Display($"R0160-00 - PROBLEMAS DECLARE (BILHETE)   ");

                /*" -651- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0160-00-DECLARE-BILHETE-DB-DECLARE-1 */
        public void R0160_00_DECLARE_BILHETE_DB_DECLARE_1()
        {
            /*" -644- EXEC SQL DECLARE V0BILHETE CURSOR WITH HOLD FOR SELECT A.NUM_BILHETE ,A.NUM_APOLICE ,A.FONTE ,A.AGE_COBRANCA ,A.NUM_CONTA ,A.DIG_CONTA ,A.COD_CLIENTE ,A.PROFISSAO ,A.IDE_SEXO ,A.ESTADO_CIVIL ,A.OCORR_ENDERECO ,A.OPC_COBERTURA ,A.DATA_QUITACAO ,A.VAL_RCAP ,A.RAMO ,A.DATA_VENDA ,A.NUM_APOL_ANTERIOR ,A.SITUACAO ,A.TIP_CANCELAMENTO ,A.SIT_SINISTRO ,A.COD_USUARIO ,A.DATA_CANCELAMENTO ,UCASE(B.NOME_RAZAO) ,B.CGCCPF ,B.DATA_NASCIMENTO FROM SEGUROS.BILHETE A ,SEGUROS.CLIENTES B WHERE A.DATA_QUITACAO >= :V1SIST-DTMOVABE-01Y AND A.DATA_QUITACAO < '9999-12-31' AND A.SITUACAO NOT IN ( '*' , 'P' , 'R' , 'T' , 'X' , 'V' , '7' , '8' , '9' ) AND B.COD_CLIENTE = A.COD_CLIENTE ORDER BY A.NUM_BILHETE END-EXEC. */
            V0BILHETE = new BI5166B_V0BILHETE(true);
            string GetQuery_V0BILHETE()
            {
                var query = @$"SELECT A.NUM_BILHETE 
							,A.NUM_APOLICE 
							,A.FONTE 
							,A.AGE_COBRANCA 
							,A.NUM_CONTA 
							,A.DIG_CONTA 
							,A.COD_CLIENTE 
							,A.PROFISSAO 
							,A.IDE_SEXO 
							,A.ESTADO_CIVIL 
							,A.OCORR_ENDERECO 
							,A.OPC_COBERTURA 
							,A.DATA_QUITACAO 
							,A.VAL_RCAP 
							,A.RAMO 
							,A.DATA_VENDA 
							,A.NUM_APOL_ANTERIOR 
							,A.SITUACAO 
							,A.TIP_CANCELAMENTO 
							,A.SIT_SINISTRO 
							,A.COD_USUARIO 
							,A.DATA_CANCELAMENTO 
							,UCASE(B.NOME_RAZAO) 
							,B.CGCCPF 
							,B.DATA_NASCIMENTO 
							FROM SEGUROS.BILHETE A 
							,SEGUROS.CLIENTES B 
							WHERE A.DATA_QUITACAO >= '{V1SIST_DTMOVABE_01Y}' 
							AND A.DATA_QUITACAO < '9999-12-31' 
							AND A.SITUACAO NOT IN 
							( '*'
							, 'P'
							, 'R'
							, 'T'
							, 'X'
							, 'V'
							, '7'
							, '8'
							, '9' ) 
							AND B.COD_CLIENTE = A.COD_CLIENTE 
							ORDER BY A.NUM_BILHETE";

                return query;
            }
            V0BILHETE.GetQueryEvent += GetQuery_V0BILHETE;

        }

        [StopWatch]
        /*" R0160-00-DECLARE-BILHETE-DB-OPEN-1 */
        public void R0160_00_DECLARE_BILHETE_DB_OPEN_1()
        {
            /*" -646- EXEC SQL OPEN V0BILHETE END-EXEC. */

            V0BILHETE.Open();

        }

        [StopWatch]
        /*" R1160-00-DECLARE-BILHEERR-DB-DECLARE-1 */
        public void R1160_00_DECLARE_BILHEERR_DB_DECLARE_1()
        {
            /*" -1533- EXEC SQL DECLARE V0BILHEERR CURSOR WITH HOLD FOR SELECT A.COD_MSG_CRITICA FROM SEGUROS.VG_CRITICA_PROPOSTA A, SEGUROS.VG_DM_MSG_CRITICA B WHERE A.NUM_CERTIFICADO = :BILHETE-NUM-BILHETE AND A.STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' ) AND A.COD_MSG_CRITICA = B.COD_MSG_CRITICA AND B.COD_TP_MSG_CRITICA = 1 WITH UR END-EXEC. */
            V0BILHEERR = new BI5166B_V0BILHEERR(true);
            string GetQuery_V0BILHEERR()
            {
                var query = @$"SELECT A.COD_MSG_CRITICA 
							FROM SEGUROS.VG_CRITICA_PROPOSTA A
							, 
							SEGUROS.VG_DM_MSG_CRITICA B 
							WHERE A.NUM_CERTIFICADO = '{BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}' 
							AND A.STA_CRITICA IN ( '0'
							, '1'
							, '2'
							, '4'
							, '5'
							, '8' ) 
							AND A.COD_MSG_CRITICA = B.COD_MSG_CRITICA 
							AND B.COD_TP_MSG_CRITICA = 1";

                return query;
            }
            V0BILHEERR.GetQueryEvent += GetQuery_V0BILHEERR;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0160_99_SAIDA*/

        [StopWatch]
        /*" R0170-00-FETCH-BILHETE-SECTION */
        private void R0170_00_FETCH_BILHETE_SECTION()
        {
            /*" -664- MOVE '0170' TO WNR-EXEC-SQL. */
            _.Move("0170", W.WABEND.WNR_EXEC_SQL);

            /*" -690- PERFORM R0170_00_FETCH_BILHETE_DB_FETCH_1 */

            R0170_00_FETCH_BILHETE_DB_FETCH_1();

            /*" -694- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -694- PERFORM R0170_00_FETCH_BILHETE_DB_CLOSE_1 */

                R0170_00_FETCH_BILHETE_DB_CLOSE_1();

                /*" -696- MOVE 'S' TO WFIM-MOVIMENTO */
                _.Move("S", W.WFIM_MOVIMENTO);

                /*" -698- GO TO R0170-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0170_99_SAIDA*/ //GOTO
                return;
            }


            /*" -699- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -700- DISPLAY 'R0170-00 - PROBLEMAS FETCH   (BILHETE)   ' */
                _.Display($"R0170-00 - PROBLEMAS FETCH   (BILHETE)   ");

                /*" -702- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -703- IF VIND-NULL01 LESS ZEROS */

            if (VIND_NULL01 < 00)
            {

                /*" -706- MOVE SPACES TO BILHETE-DATA-CANCELAMENTO. */
                _.Move("", BILHETE.DCLBILHETE.BILHETE_DATA_CANCELAMENTO);
            }


            /*" -707- IF VIND-NULL02 LESS ZEROS */

            if (VIND_NULL02 < 00)
            {

                /*" -711- MOVE SPACES TO CLIENTES-DATA-NASCIMENTO. */
                _.Move("", CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);
            }


            /*" -714- ADD 1 TO LD-BILHETE. */
            W.LD_BILHETE.Value = W.LD_BILHETE + 1;

            /*" -716- MOVE LD-BILHETE TO AC-LIDOS. */
            _.Move(W.LD_BILHETE, W.AC_LIDOS);

            /*" -718- IF LD-PARTE2 EQUAL ZEROS OR LD-PARTE2 EQUAL 5000 */

            if (W.FILLER_0.LD_PARTE2 == 00 || W.FILLER_0.LD_PARTE2 == 5000)
            {

                /*" -719- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), W.WS_TIME);

                /*" -720- MOVE WS-HH-TIME TO WTIME-HORA */
                _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

                /*" -721- MOVE '.' TO WTIME-2PT1 */
                _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

                /*" -722- MOVE WS-MM-TIME TO WTIME-MINU */
                _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

                /*" -723- MOVE '.' TO WTIME-2PT2 */
                _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

                /*" -724- MOVE WS-SS-TIME TO WTIME-SEGU */
                _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

                /*" -725- DISPLAY 'LIDOS BILHETE      ' AC-LIDOS '    ' WTIME-DAYR. */

                $"LIDOS BILHETE      {W.AC_LIDOS}    {W.FILLER_4.WTIME_DAYR}"
                .Display();
            }


        }

        [StopWatch]
        /*" R0170-00-FETCH-BILHETE-DB-FETCH-1 */
        public void R0170_00_FETCH_BILHETE_DB_FETCH_1()
        {
            /*" -690- EXEC SQL FETCH V0BILHETE INTO :BILHETE-NUM-BILHETE ,:BILHETE-NUM-APOLICE ,:BILHETE-FONTE ,:BILHETE-AGE-COBRANCA ,:BILHETE-NUM-CONTA ,:BILHETE-DIG-CONTA ,:BILHETE-COD-CLIENTE ,:BILHETE-PROFISSAO ,:BILHETE-IDE-SEXO ,:BILHETE-ESTADO-CIVIL ,:BILHETE-OCORR-ENDERECO ,:BILHETE-OPC-COBERTURA ,:BILHETE-DATA-QUITACAO ,:BILHETE-VAL-RCAP ,:BILHETE-RAMO ,:BILHETE-DATA-VENDA ,:BILHETE-NUM-APOL-ANTERIOR ,:BILHETE-SITUACAO ,:BILHETE-TIP-CANCELAMENTO ,:BILHETE-SIT-SINISTRO ,:BILHETE-COD-USUARIO ,:BILHETE-DATA-CANCELAMENTO:VIND-NULL01 ,:CLIENTES-NOME-RAZAO ,:CLIENTES-CGCCPF ,:CLIENTES-DATA-NASCIMENTO:VIND-NULL02 END-EXEC. */

            if (V0BILHETE.Fetch())
            {
                _.Move(V0BILHETE.BILHETE_NUM_BILHETE, BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE);
                _.Move(V0BILHETE.BILHETE_NUM_APOLICE, BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE);
                _.Move(V0BILHETE.BILHETE_FONTE, BILHETE.DCLBILHETE.BILHETE_FONTE);
                _.Move(V0BILHETE.BILHETE_AGE_COBRANCA, BILHETE.DCLBILHETE.BILHETE_AGE_COBRANCA);
                _.Move(V0BILHETE.BILHETE_NUM_CONTA, BILHETE.DCLBILHETE.BILHETE_NUM_CONTA);
                _.Move(V0BILHETE.BILHETE_DIG_CONTA, BILHETE.DCLBILHETE.BILHETE_DIG_CONTA);
                _.Move(V0BILHETE.BILHETE_COD_CLIENTE, BILHETE.DCLBILHETE.BILHETE_COD_CLIENTE);
                _.Move(V0BILHETE.BILHETE_PROFISSAO, BILHETE.DCLBILHETE.BILHETE_PROFISSAO);
                _.Move(V0BILHETE.BILHETE_IDE_SEXO, BILHETE.DCLBILHETE.BILHETE_IDE_SEXO);
                _.Move(V0BILHETE.BILHETE_ESTADO_CIVIL, BILHETE.DCLBILHETE.BILHETE_ESTADO_CIVIL);
                _.Move(V0BILHETE.BILHETE_OCORR_ENDERECO, BILHETE.DCLBILHETE.BILHETE_OCORR_ENDERECO);
                _.Move(V0BILHETE.BILHETE_OPC_COBERTURA, BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA);
                _.Move(V0BILHETE.BILHETE_DATA_QUITACAO, BILHETE.DCLBILHETE.BILHETE_DATA_QUITACAO);
                _.Move(V0BILHETE.BILHETE_VAL_RCAP, BILHETE.DCLBILHETE.BILHETE_VAL_RCAP);
                _.Move(V0BILHETE.BILHETE_RAMO, BILHETE.DCLBILHETE.BILHETE_RAMO);
                _.Move(V0BILHETE.BILHETE_DATA_VENDA, BILHETE.DCLBILHETE.BILHETE_DATA_VENDA);
                _.Move(V0BILHETE.BILHETE_NUM_APOL_ANTERIOR, BILHETE.DCLBILHETE.BILHETE_NUM_APOL_ANTERIOR);
                _.Move(V0BILHETE.BILHETE_SITUACAO, BILHETE.DCLBILHETE.BILHETE_SITUACAO);
                _.Move(V0BILHETE.BILHETE_TIP_CANCELAMENTO, BILHETE.DCLBILHETE.BILHETE_TIP_CANCELAMENTO);
                _.Move(V0BILHETE.BILHETE_SIT_SINISTRO, BILHETE.DCLBILHETE.BILHETE_SIT_SINISTRO);
                _.Move(V0BILHETE.BILHETE_COD_USUARIO, BILHETE.DCLBILHETE.BILHETE_COD_USUARIO);
                _.Move(V0BILHETE.BILHETE_DATA_CANCELAMENTO, BILHETE.DCLBILHETE.BILHETE_DATA_CANCELAMENTO);
                _.Move(V0BILHETE.VIND_NULL01, VIND_NULL01);
                _.Move(V0BILHETE.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(V0BILHETE.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
                _.Move(V0BILHETE.CLIENTES_DATA_NASCIMENTO, CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);
                _.Move(V0BILHETE.VIND_NULL02, VIND_NULL02);
            }

        }

        [StopWatch]
        /*" R0170-00-FETCH-BILHETE-DB-CLOSE-1 */
        public void R0170_00_FETCH_BILHETE_DB_CLOSE_1()
        {
            /*" -694- EXEC SQL CLOSE V0BILHETE END-EXEC */

            V0BILHETE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0170_99_SAIDA*/

        [StopWatch]
        /*" R0180-00-PROCESSA-BILHETE-SECTION */
        private void R0180_00_PROCESSA_BILHETE_SECTION()
        {
            /*" -738- MOVE '0180' TO WNR-EXEC-SQL. */
            _.Move("0180", W.WABEND.WNR_EXEC_SQL);

            /*" -741- PERFORM R0200-00-MOVE-DADOS-BILHETE. */

            R0200_00_MOVE_DADOS_BILHETE_SECTION();

            /*" -744- PERFORM R0210-00-SELECT-PROPOFID. */

            R0210_00_SELECT_PROPOFID_SECTION();

            /*" -746- PERFORM R0220-00-SELECT-APOLICES. */

            R0220_00_SELECT_APOLICES_SECTION();

            /*" -747- IF APOLICES-NUM-APOLICE NOT EQUAL ZEROS */

            if (APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE != 00)
            {

                /*" -748- ADD 1 TO DP-APOLICE */
                W.DP_APOLICE.Value = W.DP_APOLICE + 1;

                /*" -751- GO TO R0180-90-LEITURA. */

                R0180_90_LEITURA(); //GOTO
                return;
            }


            /*" -752- MOVE SPACES TO WTEM-CREDITO. */
            _.Move("", W.WTEM_CREDITO);

            /*" -754- PERFORM R0230-00-SELECT-RCAPS. */

            R0230_00_SELECT_RCAPS_SECTION();

            /*" -755- IF WTEM-CREDITO NOT EQUAL 'S' */

            if (W.WTEM_CREDITO != "S")
            {

                /*" -756- ADD 1 TO DP-CREDITO */
                W.DP_CREDITO.Value = W.DP_CREDITO + 1;

                /*" -763- GO TO R0180-90-LEITURA. */

                R0180_90_LEITURA(); //GOTO
                return;
            }


            /*" -764- IF MOVDEBCE-SITUACAO-COBRANCA EQUAL '1' */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA == "1")
            {

                /*" -766- IF MOVDEBCE-DATA-VENCIMENTO GREATER V1SIST-DTMOVABE-06D */

                if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO > V1SIST_DTMOVABE_06D)
                {

                    /*" -767- ADD 1 TO DP-VENCTO */
                    W.DP_VENCTO.Value = W.DP_VENCTO + 1;

                    /*" -775- GO TO R0180-90-LEITURA. */

                    R0180_90_LEITURA(); //GOTO
                    return;
                }

            }


            /*" -777- PERFORM R3000-00-CONS-DELETE-VGCRITICA. */

            R3000_00_CONS_DELETE_VGCRITICA_SECTION();

            /*" -778- IF BILHETE-OPC-COBERTURA EQUAL ZEROS */

            if (BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA == 00)
            {

                /*" -780- MOVE 'OPCAO DE COBERTURA NAO INFORMADA ' TO LD01-MENSAGEM */
                _.Move("OPCAO DE COBERTURA NAO INFORMADA ", AUX_RELATORIO.LD01.LD01_MENSERRO.LD01_MENSAGEM);

                /*" -783- PERFORM R0520-00-VERIFICA-OPCAO. */

                R0520_00_VERIFICA_OPCAO_SECTION();
            }


            /*" -784- IF LD01-MENSAGEM NOT EQUAL SPACES */

            if (!AUX_RELATORIO.LD01.LD01_MENSERRO.LD01_MENSAGEM.IsEmpty())
            {

                /*" -785- MOVE 1 TO AC-ARQUIVO */
                _.Move(1, W.AC_ARQUIVO);

                /*" -786- ADD 1 TO DP-COBERTURA */
                W.DP_COBERTURA.Value = W.DP_COBERTURA + 1;

                /*" -787- PERFORM R2000-00-GRAVA-ARQUIVO */

                R2000_00_GRAVA_ARQUIVO_SECTION();

                /*" -790- GO TO R0180-90-LEITURA. */

                R0180_90_LEITURA(); //GOTO
                return;
            }


            /*" -791- IF PROPOFID-COD-PLANO NOT EQUAL ZEROS */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO != 00)
            {

                /*" -793- PERFORM R0260-00-CONSISTE-PLANO. */

                R0260_00_CONSISTE_PLANO_SECTION();
            }


            /*" -794- IF LD01-MENSAGEM NOT EQUAL SPACES */

            if (!AUX_RELATORIO.LD01.LD01_MENSERRO.LD01_MENSAGEM.IsEmpty())
            {

                /*" -795- MOVE 1 TO AC-ARQUIVO */
                _.Move(1, W.AC_ARQUIVO);

                /*" -796- ADD 1 TO DP-PLANO */
                W.DP_PLANO.Value = W.DP_PLANO + 1;

                /*" -797- PERFORM R2000-00-GRAVA-ARQUIVO */

                R2000_00_GRAVA_ARQUIVO_SECTION();

                /*" -800- GO TO R0180-90-LEITURA. */

                R0180_90_LEITURA(); //GOTO
                return;
            }


            /*" -802- PERFORM R0300-00-SELECT-BILHECOB. */

            R0300_00_SELECT_BILHECOB_SECTION();

            /*" -803- IF LD01-MENSAGEM NOT EQUAL SPACES */

            if (!AUX_RELATORIO.LD01.LD01_MENSERRO.LD01_MENSAGEM.IsEmpty())
            {

                /*" -804- MOVE 1 TO AC-ARQUIVO */
                _.Move(1, W.AC_ARQUIVO);

                /*" -805- ADD 1 TO DP-COBERTURA */
                W.DP_COBERTURA.Value = W.DP_COBERTURA + 1;

                /*" -806- PERFORM R2000-00-GRAVA-ARQUIVO */

                R2000_00_GRAVA_ARQUIVO_SECTION();

                /*" -809- GO TO R0180-90-LEITURA. */

                R0180_90_LEITURA(); //GOTO
                return;
            }


            /*" -809- PERFORM R1150-00-TRATA-ERROS. */

            R1150_00_TRATA_ERROS_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0180_90_LEITURA */

            R0180_90_LEITURA();

        }

        [StopWatch]
        /*" R0180-90-LEITURA */
        private void R0180_90_LEITURA(bool isPerform = false)
        {
            /*" -814- PERFORM R0170-00-FETCH-BILHETE. */

            R0170_00_FETCH_BILHETE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0180_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-MOVE-DADOS-BILHETE-SECTION */
        private void R0200_00_MOVE_DADOS_BILHETE_SECTION()
        {
            /*" -826- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", W.WABEND.WNR_EXEC_SQL);

            /*" -828- MOVE ZEROS TO LD01-PRODUTO. */
            _.Move(0, AUX_RELATORIO.LD01.LD01_PRODUTO);

            /*" -835- MOVE SPACES TO LD01-MENSAGEM LD01-MENSAGEM1 LD01-DESCERRO LD01-DTPAGTO LD01-DTVENCTO LD01-DTENVIO. */
            _.Move("", AUX_RELATORIO.LD01.LD01_MENSERRO.LD01_MENSAGEM, AUX_RELATORIO.LD01.LD01_MENSERRO.LD01_MENSAGEM1, AUX_RELATORIO.LD01.LD01_DESCERRO, AUX_RELATORIO.LD01.LD01_DTPAGTO, AUX_RELATORIO.LD01.LD01_DTVENCTO, AUX_RELATORIO.LD01.LD01_DTENVIO);

            /*" -837- MOVE BILHETE-NUM-BILHETE TO LD01-BILHETE. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE, AUX_RELATORIO.LD01.LD01_BILHETE);

            /*" -839- MOVE BILHETE-FONTE TO LD01-FONTE. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_FONTE, AUX_RELATORIO.LD01.LD01_FONTE);

            /*" -841- MOVE BILHETE-AGE-COBRANCA TO LD01-AGEVENDA. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_AGE_COBRANCA, AUX_RELATORIO.LD01.LD01_AGEVENDA);

            /*" -843- MOVE BILHETE-NUM-CONTA TO LD01-NUMCONTA. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_CONTA, AUX_RELATORIO.LD01.LD01_NUMCONTA);

            /*" -845- MOVE BILHETE-DIG-CONTA TO LD01-DIGCONTA. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_DIG_CONTA, AUX_RELATORIO.LD01.LD01_DIGCONTA);

            /*" -847- MOVE BILHETE-PROFISSAO TO LD01-PROFISSAO. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_PROFISSAO, AUX_RELATORIO.LD01.LD01_PROFISSAO);

            /*" -849- MOVE BILHETE-IDE-SEXO TO LD01-SEXO. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_IDE_SEXO, AUX_RELATORIO.LD01.LD01_SEXO);

            /*" -851- MOVE BILHETE-ESTADO-CIVIL TO LD01-ESTCIVIL. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_ESTADO_CIVIL, AUX_RELATORIO.LD01.LD01_ESTCIVIL);

            /*" -853- MOVE BILHETE-OPC-COBERTURA TO LD01-OPCAO. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA, AUX_RELATORIO.LD01.LD01_OPCAO);

            /*" -855- MOVE BILHETE-DATA-QUITACAO TO LD01-DTQITBCO. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_DATA_QUITACAO, AUX_RELATORIO.LD01.LD01_DTQITBCO);

            /*" -857- MOVE BILHETE-VAL-RCAP TO LD01-VALOR. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_VAL_RCAP, AUX_RELATORIO.LD01.LD01_VALOR);

            /*" -859- MOVE BILHETE-RAMO TO LD01-RAMO. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_RAMO, AUX_RELATORIO.LD01.LD01_RAMO);

            /*" -861- MOVE BILHETE-DATA-VENDA TO LD01-DTVENDA. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_DATA_VENDA, AUX_RELATORIO.LD01.LD01_DTVENDA);

            /*" -863- MOVE BILHETE-NUM-APOL-ANTERIOR TO LD01-APOLANT. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_APOL_ANTERIOR, AUX_RELATORIO.LD01.LD01_APOLANT);

            /*" -865- MOVE BILHETE-TIP-CANCELAMENTO TO LD01-TIPCANCEL. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_TIP_CANCELAMENTO, AUX_RELATORIO.LD01.LD01_TIPCANCEL);

            /*" -867- MOVE BILHETE-SIT-SINISTRO TO LD01-SINISTRO. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_SIT_SINISTRO, AUX_RELATORIO.LD01.LD01_SINISTRO);

            /*" -869- MOVE BILHETE-COD-USUARIO TO LD01-USUARIO. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_COD_USUARIO, AUX_RELATORIO.LD01.LD01_USUARIO);

            /*" -871- MOVE BILHETE-DATA-CANCELAMENTO TO LD01-DTCANCEL. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_DATA_CANCELAMENTO, AUX_RELATORIO.LD01.LD01_DTCANCEL);

            /*" -873- MOVE CLIENTES-NOME-RAZAO TO LD01-SEGURADO. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, AUX_RELATORIO.LD01.LD01_SEGURADO);

            /*" -875- MOVE CLIENTES-CGCCPF TO LD01-CGCCPF. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, AUX_RELATORIO.LD01.LD01_CGCCPF);

            /*" -878- MOVE CLIENTES-DATA-NASCIMENTO TO LD01-DTNASC. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO, AUX_RELATORIO.LD01.LD01_DTNASC);

            /*" -881- MOVE BILHETE-SITUACAO TO LD01-SITUACAO. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_SITUACAO, AUX_RELATORIO.LD01.LD01_SITUACAO);

            /*" -882- IF BILHETE-SITUACAO EQUAL '0' */

            if (BILHETE.DCLBILHETE.BILHETE_SITUACAO == "0")
            {

                /*" -884- MOVE 'PENDENTE A INTEGRAR                               ' TO LD01-DESCSITU */
                _.Move("PENDENTE A INTEGRAR                               ", AUX_RELATORIO.LD01.LD01_DESCSITU);

                /*" -885- ELSE */
            }
            else
            {


                /*" -886- IF BILHETE-SITUACAO EQUAL '1' */

                if (BILHETE.DCLBILHETE.BILHETE_SITUACAO == "1")
                {

                    /*" -888- MOVE 'EM CRITICA                                        ' TO LD01-DESCSITU */
                    _.Move("EM CRITICA                                        ", AUX_RELATORIO.LD01.LD01_DESCSITU);

                    /*" -889- ELSE */
                }
                else
                {


                    /*" -891- IF BILHETE-SITUACAO EQUAL '2' OR '3' */

                    if (BILHETE.DCLBILHETE.BILHETE_SITUACAO.In("2", "3"))
                    {

                        /*" -893- MOVE 'FALTA PAGAMENTO - RCAP                            ' TO LD01-DESCSITU */
                        _.Move("FALTA PAGAMENTO - RCAP                            ", AUX_RELATORIO.LD01.LD01_DESCSITU);

                        /*" -894- ELSE */
                    }
                    else
                    {


                        /*" -895- IF BILHETE-SITUACAO EQUAL '4' */

                        if (BILHETE.DCLBILHETE.BILHETE_SITUACAO == "4")
                        {

                            /*" -897- MOVE 'RCAP CADASTRADO INDEVIDAMENTE                     ' TO LD01-DESCSITU */
                            _.Move("RCAP CADASTRADO INDEVIDAMENTE                     ", AUX_RELATORIO.LD01.LD01_DESCSITU);

                            /*" -898- ELSE */
                        }
                        else
                        {


                            /*" -899- IF BILHETE-SITUACAO EQUAL '5' */

                            if (BILHETE.DCLBILHETE.BILHETE_SITUACAO == "5")
                            {

                                /*" -901- MOVE 'A DEBITAR                                         ' TO LD01-DESCSITU */
                                _.Move("A DEBITAR                                         ", AUX_RELATORIO.LD01.LD01_DESCSITU);

                                /*" -902- ELSE */
                            }
                            else
                            {


                                /*" -903- IF BILHETE-SITUACAO EQUAL '6' */

                                if (BILHETE.DCLBILHETE.BILHETE_SITUACAO == "6")
                                {

                                    /*" -905- MOVE 'DEBITO ENVIADO                                    ' TO LD01-DESCSITU */
                                    _.Move("DEBITO ENVIADO                                    ", AUX_RELATORIO.LD01.LD01_DESCSITU);

                                    /*" -906- ELSE */
                                }
                                else
                                {


                                    /*" -907- IF BILHETE-SITUACAO EQUAL 'L' */

                                    if (BILHETE.DCLBILHETE.BILHETE_SITUACAO == "L")
                                    {

                                        /*" -909- MOVE 'PENDENTE A INTEGRAR. SISTEMA SAF                  ' TO LD01-DESCSITU */
                                        _.Move("PENDENTE A INTEGRAR. SISTEMA SAF                  ", AUX_RELATORIO.LD01.LD01_DESCSITU);

                                        /*" -910- ELSE */
                                    }
                                    else
                                    {


                                        /*" -911- IF BILHETE-SITUACAO EQUAL 'F' */

                                        if (BILHETE.DCLBILHETE.BILHETE_SITUACAO == "F")
                                        {

                                            /*" -913- MOVE 'AGUARDANDO PAGAMENTO                              ' TO LD01-DESCSITU */
                                            _.Move("AGUARDANDO PAGAMENTO                              ", AUX_RELATORIO.LD01.LD01_DESCSITU);

                                            /*" -914- ELSE */
                                        }
                                        else
                                        {


                                            /*" -915- IF BILHETE-SITUACAO EQUAL 'C' */

                                            if (BILHETE.DCLBILHETE.BILHETE_SITUACAO == "C")
                                            {

                                                /*" -917- MOVE 'PENDENTE A INTEGRAR - EXTRA-REDE                  ' TO LD01-DESCSITU */
                                                _.Move("PENDENTE A INTEGRAR - EXTRA-REDE                  ", AUX_RELATORIO.LD01.LD01_DESCSITU);

                                                /*" -918- ELSE */
                                            }
                                            else
                                            {


                                                /*" -919- IF BILHETE-SITUACAO EQUAL 'R' */

                                                if (BILHETE.DCLBILHETE.BILHETE_SITUACAO == "R")
                                                {

                                                    /*" -921- MOVE 'REJEITADO                                         ' TO LD01-DESCSITU */
                                                    _.Move("REJEITADO                                         ", AUX_RELATORIO.LD01.LD01_DESCSITU);

                                                    /*" -922- ELSE */
                                                }
                                                else
                                                {


                                                    /*" -923- IF BILHETE-SITUACAO EQUAL 'E' */

                                                    if (BILHETE.DCLBILHETE.BILHETE_SITUACAO == "E")
                                                    {

                                                        /*" -925- MOVE 'FALTA RCAP OU EM CRITICA - PRODUTO CRESCER        ' TO LD01-DESCSITU */
                                                        _.Move("FALTA RCAP OU EM CRITICA - PRODUTO CRESCER        ", AUX_RELATORIO.LD01.LD01_DESCSITU);

                                                        /*" -926- ELSE */
                                                    }
                                                    else
                                                    {


                                                        /*" -927- IF BILHETE-SITUACAO EQUAL 'D' */

                                                        if (BILHETE.DCLBILHETE.BILHETE_SITUACAO == "D")
                                                        {

                                                            /*" -929- MOVE 'PENDENTE A INTEGRAR - PRODUTO CRESCER             ' TO LD01-DESCSITU */
                                                            _.Move("PENDENTE A INTEGRAR - PRODUTO CRESCER             ", AUX_RELATORIO.LD01.LD01_DESCSITU);

                                                            /*" -930- ELSE */
                                                        }
                                                        else
                                                        {


                                                            /*" -931- IF BILHETE-SITUACAO EQUAL 'P' */

                                                            if (BILHETE.DCLBILHETE.BILHETE_SITUACAO == "P")
                                                            {

                                                                /*" -933- MOVE 'CANCELADO POR FALTA DE PAGAMENTO                  ' TO LD01-DESCSITU */
                                                                _.Move("CANCELADO POR FALTA DE PAGAMENTO                  ", AUX_RELATORIO.LD01.LD01_DESCSITU);

                                                                /*" -934- ELSE */
                                                            }
                                                            else
                                                            {


                                                                /*" -935- IF BILHETE-SITUACAO EQUAL 'T' */

                                                                if (BILHETE.DCLBILHETE.BILHETE_SITUACAO == "T")
                                                                {

                                                                    /*" -937- MOVE 'DECLINADO POR DECURSO DE PRAZO                    ' TO LD01-DESCSITU */
                                                                    _.Move("DECLINADO POR DECURSO DE PRAZO                    ", AUX_RELATORIO.LD01.LD01_DESCSITU);

                                                                    /*" -938- ELSE */
                                                                }
                                                                else
                                                                {


                                                                    /*" -939- MOVE 'SITUACAO NAO PREVISTA                             ' TO LD01-DESCSITU. */
                                                                    _.Move("SITUACAO NAO PREVISTA                             ", AUX_RELATORIO.LD01.LD01_DESCSITU);
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


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-SELECT-PROPOFID-SECTION */
        private void R0210_00_SELECT_PROPOFID_SECTION()
        {
            /*" -952- MOVE '0210' TO WNR-EXEC-SQL. */
            _.Move("0210", W.WABEND.WNR_EXEC_SQL);

            /*" -973- PERFORM R0210_00_SELECT_PROPOFID_DB_SELECT_1 */

            R0210_00_SELECT_PROPOFID_DB_SELECT_1();

            /*" -977- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -985- MOVE ZEROS TO PROPOFID-NUM-PROPOSTA-SIVPF PROPOFID-NUM-IDENTIFICACAO PROPOFID-COD-PRODUTO-SIVPF PROPOFID-NUMCTAVEN PROPOFID-DIGCTAVEN PROPOFID-ORIGEM-PROPOSTA PROPOFID-COD-PLANO */
                _.Move(0, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTAVEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTAVEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO);

                /*" -987- MOVE SPACES TO PROPOFID-OPCAO-COBER */
                _.Move("", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER);

                /*" -988- ELSE */
            }
            else
            {


                /*" -989- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -990- DISPLAY 'R0210-00 - PROBLEMAS NO SELECT(PROPOFID)' */
                    _.Display($"R0210-00 - PROBLEMAS NO SELECT(PROPOFID)");

                    /*" -993- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -995- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO LD01-PROPOSTA. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, AUX_RELATORIO.LD01.LD01_PROPOSTA);

            /*" -997- MOVE PROPOFID-COD-PRODUTO-SIVPF TO LD01-PRDSIVPF. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF, AUX_RELATORIO.LD01.LD01_PRDSIVPF);

            /*" -999- MOVE PROPOFID-NUMCTAVEN TO LD01-NUMCTAVEN. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTAVEN, AUX_RELATORIO.LD01.LD01_NUMCTAVEN);

            /*" -1001- MOVE PROPOFID-DIGCTAVEN TO LD01-DIGCTAVEN. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTAVEN, AUX_RELATORIO.LD01.LD01_DIGCTAVEN);

            /*" -1003- MOVE PROPOFID-ORIGEM-PROPOSTA TO LD01-ORIGEM. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA, AUX_RELATORIO.LD01.LD01_ORIGEM);

            /*" -1005- MOVE PROPOFID-COD-PLANO TO LD01-PLANO. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO, AUX_RELATORIO.LD01.LD01_PLANO);

            /*" -1006- MOVE PROPOFID-OPCAO-COBER TO LD01-OPCOBER. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER, AUX_RELATORIO.LD01.LD01_OPCOBER);

        }

        [StopWatch]
        /*" R0210-00-SELECT-PROPOFID-DB-SELECT-1 */
        public void R0210_00_SELECT_PROPOFID_DB_SELECT_1()
        {
            /*" -973- EXEC SQL SELECT NUM_PROPOSTA_SIVPF ,NUM_IDENTIFICACAO ,COD_PRODUTO_SIVPF ,NUMCTAVEN ,DIGCTAVEN ,ORIGEM_PROPOSTA ,OPCAO_COBER ,COD_PLANO INTO :PROPOFID-NUM-PROPOSTA-SIVPF ,:PROPOFID-NUM-IDENTIFICACAO ,:PROPOFID-COD-PRODUTO-SIVPF ,:PROPOFID-NUMCTAVEN ,:PROPOFID-DIGCTAVEN ,:PROPOFID-ORIGEM-PROPOSTA ,:PROPOFID-OPCAO-COBER ,:PROPOFID-COD-PLANO FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_SICOB = :BILHETE-NUM-BILHETE FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0210_00_SELECT_PROPOFID_DB_SELECT_1_Query1 = new R0210_00_SELECT_PROPOFID_DB_SELECT_1_Query1()
            {
                BILHETE_NUM_BILHETE = BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE.ToString(),
            };

            var executed_1 = R0210_00_SELECT_PROPOFID_DB_SELECT_1_Query1.Execute(r0210_00_SELECT_PROPOFID_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOFID_NUM_PROPOSTA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);
                _.Move(executed_1.PROPOFID_NUM_IDENTIFICACAO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO);
                _.Move(executed_1.PROPOFID_COD_PRODUTO_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF);
                _.Move(executed_1.PROPOFID_NUMCTAVEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTAVEN);
                _.Move(executed_1.PROPOFID_DIGCTAVEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTAVEN);
                _.Move(executed_1.PROPOFID_ORIGEM_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA);
                _.Move(executed_1.PROPOFID_OPCAO_COBER, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER);
                _.Move(executed_1.PROPOFID_COD_PLANO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/

        [StopWatch]
        /*" R0220-00-SELECT-APOLICES-SECTION */
        private void R0220_00_SELECT_APOLICES_SECTION()
        {
            /*" -1019- MOVE '0220' TO WNR-EXEC-SQL. */
            _.Move("0220", W.WABEND.WNR_EXEC_SQL);

            /*" -1020- IF BILHETE-NUM-APOLICE EQUAL ZEROS */

            if (BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE == 00)
            {

                /*" -1022- MOVE ZEROS TO APOLICES-NUM-APOLICE */
                _.Move(0, APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE);

                /*" -1025- GO TO R0220-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1032- PERFORM R0220_00_SELECT_APOLICES_DB_SELECT_1 */

            R0220_00_SELECT_APOLICES_DB_SELECT_1();

            /*" -1036- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1038- MOVE ZEROS TO APOLICES-NUM-APOLICE */
                _.Move(0, APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE);

                /*" -1039- ELSE */
            }
            else
            {


                /*" -1040- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1041- DISPLAY 'R0220-00 - PROBLEMAS NO SELECT(APOLICES)' */
                    _.Display($"R0220-00 - PROBLEMAS NO SELECT(APOLICES)");

                    /*" -1041- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0220-00-SELECT-APOLICES-DB-SELECT-1 */
        public void R0220_00_SELECT_APOLICES_DB_SELECT_1()
        {
            /*" -1032- EXEC SQL SELECT NUM_APOLICE INTO :APOLICES-NUM-APOLICE FROM SEGUROS.APOLICES WHERE NUM_APOLICE = :BILHETE-NUM-APOLICE FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0220_00_SELECT_APOLICES_DB_SELECT_1_Query1 = new R0220_00_SELECT_APOLICES_DB_SELECT_1_Query1()
            {
                BILHETE_NUM_APOLICE = BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0220_00_SELECT_APOLICES_DB_SELECT_1_Query1.Execute(r0220_00_SELECT_APOLICES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICES_NUM_APOLICE, APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_99_SAIDA*/

        [StopWatch]
        /*" R0230-00-SELECT-RCAPS-SECTION */
        private void R0230_00_SELECT_RCAPS_SECTION()
        {
            /*" -1054- MOVE '0230' TO WNR-EXEC-SQL. */
            _.Move("0230", W.WABEND.WNR_EXEC_SQL);

            /*" -1062- PERFORM R0230_00_SELECT_RCAPS_DB_SELECT_1 */

            R0230_00_SELECT_RCAPS_DB_SELECT_1();

            /*" -1066- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1067- PERFORM R0240-00-SELECT-MOVDEBCE */

                R0240_00_SELECT_MOVDEBCE_SECTION();

                /*" -1068- ELSE */
            }
            else
            {


                /*" -1069- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1070- DISPLAY 'R0230-00 - PROBLEMAS NO SELECT(RCAPS)   ' */
                    _.Display($"R0230-00 - PROBLEMAS NO SELECT(RCAPS)   ");

                    /*" -1071- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1072- ELSE */
                }
                else
                {


                    /*" -1074- MOVE '*' TO MOVDEBCE-SITUACAO-COBRANCA */
                    _.Move("*", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);

                    /*" -1076- MOVE RCAPS-DATA-CADASTRAMENTO TO LD01-DTPAGTO */
                    _.Move(RCAPS.DCLRCAPS.RCAPS_DATA_CADASTRAMENTO, AUX_RELATORIO.LD01.LD01_DTPAGTO);

                    /*" -1078- MOVE ' - CREDITO PENDENTE           ' TO LD01-MENSAGEM1 */
                    _.Move(" - CREDITO PENDENTE           ", AUX_RELATORIO.LD01.LD01_MENSERRO.LD01_MENSAGEM1);

                    /*" -1078- MOVE 'S' TO WTEM-CREDITO. */
                    _.Move("S", W.WTEM_CREDITO);
                }

            }


        }

        [StopWatch]
        /*" R0230-00-SELECT-RCAPS-DB-SELECT-1 */
        public void R0230_00_SELECT_RCAPS_DB_SELECT_1()
        {
            /*" -1062- EXEC SQL SELECT DATA_CADASTRAMENTO INTO :RCAPS-DATA-CADASTRAMENTO FROM SEGUROS.RCAPS WHERE NUM_TITULO = :BILHETE-NUM-BILHETE AND SIT_REGISTRO = '0' FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0230_00_SELECT_RCAPS_DB_SELECT_1_Query1 = new R0230_00_SELECT_RCAPS_DB_SELECT_1_Query1()
            {
                BILHETE_NUM_BILHETE = BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE.ToString(),
            };

            var executed_1 = R0230_00_SELECT_RCAPS_DB_SELECT_1_Query1.Execute(r0230_00_SELECT_RCAPS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_DATA_CADASTRAMENTO, RCAPS.DCLRCAPS.RCAPS_DATA_CADASTRAMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0230_99_SAIDA*/

        [StopWatch]
        /*" R0240-00-SELECT-MOVDEBCE-SECTION */
        private void R0240_00_SELECT_MOVDEBCE_SECTION()
        {
            /*" -1091- MOVE '0240' TO WNR-EXEC-SQL. */
            _.Move("0240", W.WABEND.WNR_EXEC_SQL);

            /*" -1102- PERFORM R0240_00_SELECT_MOVDEBCE_DB_SELECT_1 */

            R0240_00_SELECT_MOVDEBCE_DB_SELECT_1();

            /*" -1106- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1107- MOVE 'N' TO WTEM-CREDITO */
                _.Move("N", W.WTEM_CREDITO);

                /*" -1110- GO TO R0240-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0240_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1111- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1112- DISPLAY 'R0240-00 - PROBLEMAS NO SELECT(MOVDEBCE)' */
                _.Display($"R0240-00 - PROBLEMAS NO SELECT(MOVDEBCE)");

                /*" -1115- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1116- IF VIND-NULL01 LESS ZEROS */

            if (VIND_NULL01 < 00)
            {

                /*" -1120- MOVE SPACES TO MOVDEBCE-DATA-ENVIO. */
                _.Move("", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_ENVIO);
            }


            /*" -1122- MOVE MOVDEBCE-DATA-VENCIMENTO TO LD01-DTVENCTO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO, AUX_RELATORIO.LD01.LD01_DTVENCTO);

            /*" -1126- MOVE MOVDEBCE-DATA-ENVIO TO LD01-DTENVIO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_ENVIO, AUX_RELATORIO.LD01.LD01_DTENVIO);

            /*" -1127- IF MOVDEBCE-SITUACAO-COBRANCA EQUAL '1' */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA == "1")
            {

                /*" -1128- MOVE 'S' TO WTEM-CREDITO */
                _.Move("S", W.WTEM_CREDITO);

                /*" -1130- MOVE ' - AGUARDANDO RETORNO         ' TO LD01-MENSAGEM1 */
                _.Move(" - AGUARDANDO RETORNO         ", AUX_RELATORIO.LD01.LD01_MENSERRO.LD01_MENSAGEM1);

                /*" -1131- ELSE */
            }
            else
            {


                /*" -1132- IF MOVDEBCE-SITUACAO-COBRANCA EQUAL '2' */

                if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA == "2")
                {

                    /*" -1133- MOVE 'S' TO WTEM-CREDITO */
                    _.Move("S", W.WTEM_CREDITO);

                    /*" -1135- MOVE ' - CREDITO PENDENTE           ' TO LD01-MENSAGEM1 */
                    _.Move(" - CREDITO PENDENTE           ", AUX_RELATORIO.LD01.LD01_MENSERRO.LD01_MENSAGEM1);

                    /*" -1136- ELSE */
                }
                else
                {


                    /*" -1136- MOVE 'N' TO WTEM-CREDITO. */
                    _.Move("N", W.WTEM_CREDITO);
                }

            }


        }

        [StopWatch]
        /*" R0240-00-SELECT-MOVDEBCE-DB-SELECT-1 */
        public void R0240_00_SELECT_MOVDEBCE_DB_SELECT_1()
        {
            /*" -1102- EXEC SQL SELECT SITUACAO_COBRANCA ,DATA_VENCIMENTO ,DATA_ENVIO INTO :MOVDEBCE-SITUACAO-COBRANCA ,:MOVDEBCE-DATA-VENCIMENTO ,:MOVDEBCE-DATA-ENVIO:VIND-NULL01 FROM SEGUROS.MOVTO_DEBITOCC_CEF WHERE NUM_APOLICE = :BILHETE-NUM-BILHETE FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0240_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1 = new R0240_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1()
            {
                BILHETE_NUM_BILHETE = BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE.ToString(),
            };

            var executed_1 = R0240_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1.Execute(r0240_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVDEBCE_SITUACAO_COBRANCA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);
                _.Move(executed_1.MOVDEBCE_DATA_VENCIMENTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO);
                _.Move(executed_1.MOVDEBCE_DATA_ENVIO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_ENVIO);
                _.Move(executed_1.VIND_NULL01, VIND_NULL01);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0240_99_SAIDA*/

        [StopWatch]
        /*" R0260-00-CONSISTE-PLANO-SECTION */
        private void R0260_00_CONSISTE_PLANO_SECTION()
        {
            /*" -1149- MOVE '0260' TO WNR-EXEC-SQL. */
            _.Move("0260", W.WABEND.WNR_EXEC_SQL);

            /*" -1151- IF PROPOFID-COD-PLANO GREATER 3699 AND PROPOFID-COD-PLANO LESS 3800 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO > 3699 && PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO < 3800)
            {

                /*" -1152- IF BILHETE-RAMO NOT EQUAL 37 */

                if (BILHETE.DCLBILHETE.BILHETE_RAMO != 37)
                {

                    /*" -1154- MOVE 'PLANO / RAMO DIVERGENTE 37       ' TO LD01-MENSAGEM */
                    _.Move("PLANO / RAMO DIVERGENTE 37       ", AUX_RELATORIO.LD01.LD01_MENSERRO.LD01_MENSAGEM);

                    /*" -1156- ELSE NEXT SENTENCE */
                }
                else
                {


                    /*" -1157- ELSE */
                }

            }
            else
            {


                /*" -1159- IF PROPOFID-COD-PLANO GREATER 6899 AND PROPOFID-COD-PLANO LESS 7000 */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO > 6899 && PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO < 7000)
                {

                    /*" -1160- IF BILHETE-RAMO NOT EQUAL 69 */

                    if (BILHETE.DCLBILHETE.BILHETE_RAMO != 69)
                    {

                        /*" -1162- MOVE 'PLANO / RAMO DIVERGENTE 69       ' TO LD01-MENSAGEM */
                        _.Move("PLANO / RAMO DIVERGENTE 69       ", AUX_RELATORIO.LD01.LD01_MENSERRO.LD01_MENSAGEM);

                        /*" -1164- ELSE NEXT SENTENCE */
                    }
                    else
                    {


                        /*" -1165- ELSE */
                    }

                }
                else
                {


                    /*" -1167- IF PROPOFID-COD-PLANO GREATER 8099 AND PROPOFID-COD-PLANO LESS 8200 */

                    if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO > 8099 && PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO < 8200)
                    {

                        /*" -1168- IF BILHETE-RAMO NOT EQUAL 81 */

                        if (BILHETE.DCLBILHETE.BILHETE_RAMO != 81)
                        {

                            /*" -1170- MOVE 'PLANO / RAMO DIVERGENTE 81       ' TO LD01-MENSAGEM */
                            _.Move("PLANO / RAMO DIVERGENTE 81       ", AUX_RELATORIO.LD01.LD01_MENSERRO.LD01_MENSAGEM);

                            /*" -1172- ELSE NEXT SENTENCE */
                        }
                        else
                        {


                            /*" -1173- ELSE */
                        }

                    }
                    else
                    {


                        /*" -1174- MOVE 'PLANO DIVERGENTE                 ' TO LD01-MENSAGEM. */
                        _.Move("PLANO DIVERGENTE                 ", AUX_RELATORIO.LD01.LD01_MENSERRO.LD01_MENSAGEM);
                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0260_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-SELECT-BILHECOB-SECTION */
        private void R0300_00_SELECT_BILHECOB_SECTION()
        {
            /*" -1187- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", W.WABEND.WNR_EXEC_SQL);

            /*" -1197- PERFORM R0300_00_SELECT_BILHECOB_DB_SELECT_1 */

            R0300_00_SELECT_BILHECOB_DB_SELECT_1();

            /*" -1201- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1203- MOVE ZEROS TO BILHECOB-COD-PRODUTO */
                _.Move(0, BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_PRODUTO);

                /*" -1205- MOVE 'OPCAO DE COBERTURA NAO CADASTRADA' TO LD01-MENSAGEM */
                _.Move("OPCAO DE COBERTURA NAO CADASTRADA", AUX_RELATORIO.LD01.LD01_MENSERRO.LD01_MENSAGEM);

                /*" -1206- ELSE */
            }
            else
            {


                /*" -1207- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1208- DISPLAY 'R0300-00 - PROBLEMAS NO SELECT(BILHECOB)' */
                    _.Display($"R0300-00 - PROBLEMAS NO SELECT(BILHECOB)");

                    /*" -1211- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1212- MOVE BILHECOB-COD-PRODUTO TO LD01-PRODUTO. */
            _.Move(BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_PRODUTO, AUX_RELATORIO.LD01.LD01_PRODUTO);

        }

        [StopWatch]
        /*" R0300-00-SELECT-BILHECOB-DB-SELECT-1 */
        public void R0300_00_SELECT_BILHECOB_DB_SELECT_1()
        {
            /*" -1197- EXEC SQL SELECT COD_PRODUTO INTO :BILHECOB-COD-PRODUTO FROM SEGUROS.BILHETE_COBERTURA WHERE RAMO_COBERTURA = :BILHETE-RAMO AND COD_OPCAO_PLANO = :BILHETE-OPC-COBERTURA AND DATA_INIVIGENCIA <= :BILHETE-DATA-QUITACAO AND DATA_TERVIGENCIA >= :BILHETE-DATA-QUITACAO FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0300_00_SELECT_BILHECOB_DB_SELECT_1_Query1 = new R0300_00_SELECT_BILHECOB_DB_SELECT_1_Query1()
            {
                BILHETE_OPC_COBERTURA = BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA.ToString(),
                BILHETE_DATA_QUITACAO = BILHETE.DCLBILHETE.BILHETE_DATA_QUITACAO.ToString(),
                BILHETE_RAMO = BILHETE.DCLBILHETE.BILHETE_RAMO.ToString(),
            };

            var executed_1 = R0300_00_SELECT_BILHECOB_DB_SELECT_1_Query1.Execute(r0300_00_SELECT_BILHECOB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.BILHECOB_COD_PRODUTO, BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0520-00-VERIFICA-OPCAO-SECTION */
        private void R0520_00_VERIFICA_OPCAO_SECTION()
        {
            /*" -1225- MOVE '0520' TO WNR-EXEC-SQL. */
            _.Move("0520", W.WABEND.WNR_EXEC_SQL);

            /*" -1230- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 8119 OR 8120 OR 8121 OR 8122 OR 8123 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF.In("8119", "8120", "8121", "8122", "8123"))
            {

                /*" -1231- PERFORM R0550-00-TRATA-FACIL */

                R0550_00_TRATA_FACIL_SECTION();

                /*" -1232- ELSE */
            }
            else
            {


                /*" -1237- IF PROPOFID-COD-PLANO EQUAL 6901 OR 6904 OR 6907 OR 6919 OR 6920 */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO.In("6901", "6904", "6907", "6919", "6920"))
                {

                    /*" -1238- PERFORM R0560-00-TRATA-VIAGEM */

                    R0560_00_TRATA_VIAGEM_SECTION();

                    /*" -1239- ELSE */
                }
                else
                {


                    /*" -1242- IF PROPOFID-NUMCTAVEN EQUAL ZEROS OR PROPOFID-DIGCTAVEN EQUAL ZEROS NEXT SENTENCE */

                    if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTAVEN == 00 || PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTAVEN == 00)
                    {

                        /*" -1243- ELSE */
                    }
                    else
                    {


                        /*" -1245- IF PROPOFID-COD-PLANO NOT EQUAL 3705 NEXT SENTENCE */

                        if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO != 3705)
                        {

                            /*" -1246- ELSE */
                        }
                        else
                        {


                            /*" -1246- PERFORM R0570-00-TRATA-FAMILIA. */

                            R0570_00_TRATA_FAMILIA_SECTION();
                        }

                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0520_99_SAIDA*/

        [StopWatch]
        /*" R0550-00-TRATA-FACIL-SECTION */
        private void R0550_00_TRATA_FACIL_SECTION()
        {
            /*" -1259- MOVE '0550' TO WNR-EXEC-SQL. */
            _.Move("0550", W.WABEND.WNR_EXEC_SQL);

            /*" -1261- MOVE 'C' TO BILHETE-SITUACAO. */
            _.Move("C", BILHETE.DCLBILHETE.BILHETE_SITUACAO);

            /*" -1265- MOVE 81 TO BILHETE-RAMO. */
            _.Move(81, BILHETE.DCLBILHETE.BILHETE_RAMO);

            /*" -1266- IF BILHETE-VAL-RCAP EQUAL 14,90 */

            if (BILHETE.DCLBILHETE.BILHETE_VAL_RCAP == 14.90)
            {

                /*" -1267- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 8119 */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 8119)
                {

                    /*" -1269- MOVE 45 TO BILHETE-OPC-COBERTURA */
                    _.Move(45, BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA);

                    /*" -1270- ELSE */
                }
                else
                {


                    /*" -1271- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 8120 */

                    if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 8120)
                    {

                        /*" -1273- MOVE 55 TO BILHETE-OPC-COBERTURA */
                        _.Move(55, BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA);

                        /*" -1274- ELSE */
                    }
                    else
                    {


                        /*" -1275- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 8121 */

                        if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 8121)
                        {

                            /*" -1277- MOVE 65 TO BILHETE-OPC-COBERTURA */
                            _.Move(65, BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA);

                            /*" -1278- ELSE */
                        }
                        else
                        {


                            /*" -1279- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 8122 */

                            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 8122)
                            {

                                /*" -1281- MOVE 75 TO BILHETE-OPC-COBERTURA */
                                _.Move(75, BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA);

                                /*" -1282- ELSE */
                            }
                            else
                            {


                                /*" -1283- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 8123 */

                                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 8123)
                                {

                                    /*" -1285- MOVE 95 TO BILHETE-OPC-COBERTURA */
                                    _.Move(95, BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA);

                                    /*" -1286- ELSE */
                                }
                                else
                                {


                                    /*" -1287- GO TO R0550-99-SAIDA */
                                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0550_99_SAIDA*/ //GOTO
                                    return;

                                    /*" -1288- ELSE */
                                }

                            }

                        }

                    }

                }

            }
            else
            {


                /*" -1289- IF BILHETE-VAL-RCAP EQUAL 29,90 */

                if (BILHETE.DCLBILHETE.BILHETE_VAL_RCAP == 29.90)
                {

                    /*" -1290- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 8119 */

                    if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 8119)
                    {

                        /*" -1292- MOVE 46 TO BILHETE-OPC-COBERTURA */
                        _.Move(46, BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA);

                        /*" -1293- ELSE */
                    }
                    else
                    {


                        /*" -1294- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 8120 */

                        if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 8120)
                        {

                            /*" -1296- MOVE 56 TO BILHETE-OPC-COBERTURA */
                            _.Move(56, BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA);

                            /*" -1297- ELSE */
                        }
                        else
                        {


                            /*" -1298- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 8121 */

                            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 8121)
                            {

                                /*" -1300- MOVE 66 TO BILHETE-OPC-COBERTURA */
                                _.Move(66, BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA);

                                /*" -1301- ELSE */
                            }
                            else
                            {


                                /*" -1302- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 8122 */

                                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 8122)
                                {

                                    /*" -1304- MOVE 76 TO BILHETE-OPC-COBERTURA */
                                    _.Move(76, BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA);

                                    /*" -1305- ELSE */
                                }
                                else
                                {


                                    /*" -1306- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 8123 */

                                    if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 8123)
                                    {

                                        /*" -1308- MOVE 96 TO BILHETE-OPC-COBERTURA */
                                        _.Move(96, BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA);

                                        /*" -1309- ELSE */
                                    }
                                    else
                                    {


                                        /*" -1310- GO TO R0550-99-SAIDA */
                                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0550_99_SAIDA*/ //GOTO
                                        return;

                                        /*" -1311- ELSE */
                                    }

                                }

                            }

                        }

                    }

                }
                else
                {


                    /*" -1312- IF BILHETE-VAL-RCAP EQUAL 45,90 */

                    if (BILHETE.DCLBILHETE.BILHETE_VAL_RCAP == 45.90)
                    {

                        /*" -1313- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 8119 */

                        if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 8119)
                        {

                            /*" -1315- MOVE 47 TO BILHETE-OPC-COBERTURA */
                            _.Move(47, BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA);

                            /*" -1316- ELSE */
                        }
                        else
                        {


                            /*" -1317- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 8120 */

                            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 8120)
                            {

                                /*" -1319- MOVE 57 TO BILHETE-OPC-COBERTURA */
                                _.Move(57, BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA);

                                /*" -1320- ELSE */
                            }
                            else
                            {


                                /*" -1321- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 8121 */

                                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 8121)
                                {

                                    /*" -1323- MOVE 67 TO BILHETE-OPC-COBERTURA */
                                    _.Move(67, BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA);

                                    /*" -1324- ELSE */
                                }
                                else
                                {


                                    /*" -1325- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 8122 */

                                    if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 8122)
                                    {

                                        /*" -1327- MOVE 77 TO BILHETE-OPC-COBERTURA */
                                        _.Move(77, BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA);

                                        /*" -1328- ELSE */
                                    }
                                    else
                                    {


                                        /*" -1329- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 8123 */

                                        if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 8123)
                                        {

                                            /*" -1331- MOVE 97 TO BILHETE-OPC-COBERTURA */
                                            _.Move(97, BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA);

                                            /*" -1332- ELSE */
                                        }
                                        else
                                        {


                                            /*" -1333- GO TO R0550-99-SAIDA */
                                            /*Método Suprimido por falta de linha ou apenas EXIT nome: R0550_99_SAIDA*/ //GOTO
                                            return;

                                            /*" -1334- ELSE */
                                        }

                                    }

                                }

                            }

                        }

                    }
                    else
                    {


                        /*" -1335- IF BILHETE-VAL-RCAP EQUAL 77,90 */

                        if (BILHETE.DCLBILHETE.BILHETE_VAL_RCAP == 77.90)
                        {

                            /*" -1336- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 8119 */

                            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 8119)
                            {

                                /*" -1338- MOVE 48 TO BILHETE-OPC-COBERTURA */
                                _.Move(48, BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA);

                                /*" -1339- ELSE */
                            }
                            else
                            {


                                /*" -1340- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 8120 */

                                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 8120)
                                {

                                    /*" -1342- MOVE 58 TO BILHETE-OPC-COBERTURA */
                                    _.Move(58, BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA);

                                    /*" -1343- ELSE */
                                }
                                else
                                {


                                    /*" -1344- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 8121 */

                                    if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 8121)
                                    {

                                        /*" -1346- MOVE 68 TO BILHETE-OPC-COBERTURA */
                                        _.Move(68, BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA);

                                        /*" -1347- ELSE */
                                    }
                                    else
                                    {


                                        /*" -1348- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 8122 */

                                        if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 8122)
                                        {

                                            /*" -1350- MOVE 78 TO BILHETE-OPC-COBERTURA */
                                            _.Move(78, BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA);

                                            /*" -1351- ELSE */
                                        }
                                        else
                                        {


                                            /*" -1352- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 8123 */

                                            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 8123)
                                            {

                                                /*" -1354- MOVE 98 TO BILHETE-OPC-COBERTURA */
                                                _.Move(98, BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA);

                                                /*" -1355- ELSE */
                                            }
                                            else
                                            {


                                                /*" -1356- GO TO R0550-99-SAIDA */
                                                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0550_99_SAIDA*/ //GOTO
                                                return;

                                                /*" -1357- ELSE */
                                            }

                                        }

                                    }

                                }

                            }

                        }
                        else
                        {


                            /*" -1360- GO TO R0550-99-SAIDA. */
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: R0550_99_SAIDA*/ //GOTO
                            return;
                        }

                    }

                }

            }


            /*" -1360- PERFORM R0900-00-UPDATE-V0BILHETE. */

            R0900_00_UPDATE_V0BILHETE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0550_99_SAIDA*/

        [StopWatch]
        /*" R0560-00-TRATA-VIAGEM-SECTION */
        private void R0560_00_TRATA_VIAGEM_SECTION()
        {
            /*" -1373- MOVE '0560' TO WNR-EXEC-SQL. */
            _.Move("0560", W.WABEND.WNR_EXEC_SQL);

            /*" -1375- MOVE 'E' TO BILHETE-SITUACAO. */
            _.Move("E", BILHETE.DCLBILHETE.BILHETE_SITUACAO);

            /*" -1379- MOVE 69 TO BILHETE-RAMO. */
            _.Move(69, BILHETE.DCLBILHETE.BILHETE_RAMO);

            /*" -1380- IF PROPOFID-COD-PLANO EQUAL 6901 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO == 6901)
            {

                /*" -1382- MOVE 611 TO BILHETE-OPC-COBERTURA */
                _.Move(611, BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA);

                /*" -1383- ELSE */
            }
            else
            {


                /*" -1384- IF PROPOFID-COD-PLANO EQUAL 6904 */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO == 6904)
                {

                    /*" -1386- MOVE 614 TO BILHETE-OPC-COBERTURA */
                    _.Move(614, BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA);

                    /*" -1387- ELSE */
                }
                else
                {


                    /*" -1388- IF PROPOFID-COD-PLANO EQUAL 6907 */

                    if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO == 6907)
                    {

                        /*" -1390- MOVE 617 TO BILHETE-OPC-COBERTURA */
                        _.Move(617, BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA);

                        /*" -1391- ELSE */
                    }
                    else
                    {


                        /*" -1392- IF PROPOFID-COD-PLANO EQUAL 6919 */

                        if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO == 6919)
                        {

                            /*" -1394- MOVE 663 TO BILHETE-OPC-COBERTURA */
                            _.Move(663, BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA);

                            /*" -1395- ELSE */
                        }
                        else
                        {


                            /*" -1396- IF PROPOFID-COD-PLANO EQUAL 6920 */

                            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO == 6920)
                            {

                                /*" -1398- MOVE 664 TO BILHETE-OPC-COBERTURA */
                                _.Move(664, BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA);

                                /*" -1399- ELSE */
                            }
                            else
                            {


                                /*" -1402- GO TO R0560-99-SAIDA */
                                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0560_99_SAIDA*/ //GOTO
                                return;
                            }

                        }

                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0560_99_SAIDA*/

        [StopWatch]
        /*" R0570-00-TRATA-FAMILIA-SECTION */
        private void R0570_00_TRATA_FAMILIA_SECTION()
        {
            /*" -1415- MOVE '0570' TO WNR-EXEC-SQL. */
            _.Move("0570", W.WABEND.WNR_EXEC_SQL);

            /*" -1417- MOVE 'E' TO BILHETE-SITUACAO. */
            _.Move("E", BILHETE.DCLBILHETE.BILHETE_SITUACAO);

            /*" -1421- MOVE 37 TO BILHETE-RAMO. */
            _.Move(37, BILHETE.DCLBILHETE.BILHETE_RAMO);

            /*" -1422- MOVE ZEROS TO WPREMIO-BASE. */
            _.Move(0, WPREMIO_BASE);

            /*" -1426- COMPUTE WPREMIO-BASE EQUAL (BILHETE-VAL-RCAP / BILHETE-DIG-CONTA). */
            WPREMIO_BASE.Value = (BILHETE.DCLBILHETE.BILHETE_VAL_RCAP / BILHETE.DCLBILHETE.BILHETE_DIG_CONTA);

            /*" -1427- IF WPREMIO-BASE EQUAL 4,50 */

            if (WPREMIO_BASE == 4.50)
            {

                /*" -1429- MOVE 511 TO BILHETE-OPC-COBERTURA */
                _.Move(511, BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA);

                /*" -1430- ELSE */
            }
            else
            {


                /*" -1431- IF WPREMIO-BASE EQUAL 6,00 */

                if (WPREMIO_BASE == 6.00)
                {

                    /*" -1433- MOVE 512 TO BILHETE-OPC-COBERTURA */
                    _.Move(512, BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA);

                    /*" -1434- ELSE */
                }
                else
                {


                    /*" -1435- IF WPREMIO-BASE EQUAL 8,00 */

                    if (WPREMIO_BASE == 8.00)
                    {

                        /*" -1437- MOVE 513 TO BILHETE-OPC-COBERTURA */
                        _.Move(513, BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA);

                        /*" -1438- ELSE */
                    }
                    else
                    {


                        /*" -1439- IF WPREMIO-BASE EQUAL 10,00 */

                        if (WPREMIO_BASE == 10.00)
                        {

                            /*" -1441- MOVE 514 TO BILHETE-OPC-COBERTURA */
                            _.Move(514, BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA);

                            /*" -1442- ELSE */
                        }
                        else
                        {


                            /*" -1445- GO TO R0570-99-SAIDA. */
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: R0570_99_SAIDA*/ //GOTO
                            return;
                        }

                    }

                }

            }


            /*" -1445- PERFORM R0900-00-UPDATE-V0BILHETE. */

            R0900_00_UPDATE_V0BILHETE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0570_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-UPDATE-V0BILHETE-SECTION */
        private void R0900_00_UPDATE_V0BILHETE_SECTION()
        {
            /*" -1458- MOVE '0900' TO WNR-EXEC-SQL. */
            _.Move("0900", W.WABEND.WNR_EXEC_SQL);

            /*" -1467- PERFORM R0900_00_UPDATE_V0BILHETE_DB_UPDATE_1 */

            R0900_00_UPDATE_V0BILHETE_DB_UPDATE_1();

            /*" -1471- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1472- ADD 1 TO NT-BILHETE */
                W.NT_BILHETE.Value = W.NT_BILHETE + 1;

                /*" -1473- ELSE */
            }
            else
            {


                /*" -1474- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1475- DISPLAY 'R0900-00 - PROBLEMAS UPDATE (BILHETE)  ' */
                    _.Display($"R0900-00 - PROBLEMAS UPDATE (BILHETE)  ");

                    /*" -1476- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1477- ELSE */
                }
                else
                {


                    /*" -1478- MOVE SPACES TO LD01-MENSAGEM */
                    _.Move("", AUX_RELATORIO.LD01.LD01_MENSERRO.LD01_MENSAGEM);

                    /*" -1478- ADD 1 TO UP-BILHETE. */
                    W.UP_BILHETE.Value = W.UP_BILHETE + 1;
                }

            }


        }

        [StopWatch]
        /*" R0900-00-UPDATE-V0BILHETE-DB-UPDATE-1 */
        public void R0900_00_UPDATE_V0BILHETE_DB_UPDATE_1()
        {
            /*" -1467- EXEC SQL UPDATE SEGUROS.BILHETE SET OPC_COBERTURA = :BILHETE-OPC-COBERTURA ,RAMO = :BILHETE-RAMO ,SITUACAO = :BILHETE-SITUACAO WHERE NUM_BILHETE = :BILHETE-NUM-BILHETE END-EXEC. */

            var r0900_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 = new R0900_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1()
            {
                BILHETE_OPC_COBERTURA = BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA.ToString(),
                BILHETE_SITUACAO = BILHETE.DCLBILHETE.BILHETE_SITUACAO.ToString(),
                BILHETE_RAMO = BILHETE.DCLBILHETE.BILHETE_RAMO.ToString(),
                BILHETE_NUM_BILHETE = BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE.ToString(),
            };

            R0900_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1.Execute(r0900_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R1150-00-TRATA-ERROS-SECTION */
        private void R1150_00_TRATA_ERROS_SECTION()
        {
            /*" -1491- MOVE '1150' TO WNR-EXEC-SQL. */
            _.Move("1150", W.WABEND.WNR_EXEC_SQL);

            /*" -1492- MOVE SPACES TO WFIM-ERROS. */
            _.Move("", W.WFIM_ERROS);

            /*" -1494- PERFORM R1160-00-DECLARE-BILHEERR. */

            R1160_00_DECLARE_BILHEERR_SECTION();

            /*" -1496- PERFORM R1170-00-FETCH-BILHEERR. */

            R1170_00_FETCH_BILHEERR_SECTION();

            /*" -1497- IF WFIM-ERROS NOT EQUAL SPACES */

            if (!W.WFIM_ERROS.IsEmpty())
            {

                /*" -1498- MOVE 2 TO AC-ARQUIVO */
                _.Move(2, W.AC_ARQUIVO);

                /*" -1501- PERFORM R2000-00-GRAVA-ARQUIVO. */

                R2000_00_GRAVA_ARQUIVO_SECTION();
            }


            /*" -1502- PERFORM R1180-00-PROCESSA-BILHEERR UNTIL WFIM-ERROS NOT EQUAL SPACES. */

            while (!(!W.WFIM_ERROS.IsEmpty()))
            {

                R1180_00_PROCESSA_BILHEERR_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1150_99_SAIDA*/

        [StopWatch]
        /*" R1160-00-DECLARE-BILHEERR-SECTION */
        private void R1160_00_DECLARE_BILHEERR_SECTION()
        {
            /*" -1523- MOVE '1160' TO WNR-EXEC-SQL. */
            _.Move("1160", W.WABEND.WNR_EXEC_SQL);

            /*" -1533- PERFORM R1160_00_DECLARE_BILHEERR_DB_DECLARE_1 */

            R1160_00_DECLARE_BILHEERR_DB_DECLARE_1();

            /*" -1535- PERFORM R1160_00_DECLARE_BILHEERR_DB_OPEN_1 */

            R1160_00_DECLARE_BILHEERR_DB_OPEN_1();

            /*" -1539- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1540- DISPLAY 'R1160-00 - PROBLEMAS DECLARE (BILHEERR)  ' */
                _.Display($"R1160-00 - PROBLEMAS DECLARE (BILHEERR)  ");

                /*" -1540- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1160-00-DECLARE-BILHEERR-DB-OPEN-1 */
        public void R1160_00_DECLARE_BILHEERR_DB_OPEN_1()
        {
            /*" -1535- EXEC SQL OPEN V0BILHEERR END-EXEC. */

            V0BILHEERR.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1160_99_SAIDA*/

        [StopWatch]
        /*" R1170-00-FETCH-BILHEERR-SECTION */
        private void R1170_00_FETCH_BILHEERR_SECTION()
        {
            /*" -1553- MOVE '1170' TO WNR-EXEC-SQL. */
            _.Move("1170", W.WABEND.WNR_EXEC_SQL);

            /*" -1555- PERFORM R1170_00_FETCH_BILHEERR_DB_FETCH_1 */

            R1170_00_FETCH_BILHEERR_DB_FETCH_1();

            /*" -1559- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1559- PERFORM R1170_00_FETCH_BILHEERR_DB_CLOSE_1 */

                R1170_00_FETCH_BILHEERR_DB_CLOSE_1();

                /*" -1561- MOVE 'S' TO WFIM-ERROS */
                _.Move("S", W.WFIM_ERROS);

                /*" -1563- GO TO R1170-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1170_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1564- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1565- DISPLAY 'R1170-00 - PROBLEMAS FETCH   (BILHEERR)  ' */
                _.Display($"R1170-00 - PROBLEMAS FETCH   (BILHEERR)  ");

                /*" -1565- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1170-00-FETCH-BILHEERR-DB-FETCH-1 */
        public void R1170_00_FETCH_BILHEERR_DB_FETCH_1()
        {
            /*" -1555- EXEC SQL FETCH V0BILHEERR INTO :BILHEERR-COD-ERRO END-EXEC. */

            if (V0BILHEERR.Fetch())
            {
                _.Move(V0BILHEERR.BILHEERR_COD_ERRO, BILHEERR.DCLBILHETE_ERROS.BILHEERR_COD_ERRO);
            }

        }

        [StopWatch]
        /*" R1170-00-FETCH-BILHEERR-DB-CLOSE-1 */
        public void R1170_00_FETCH_BILHEERR_DB_CLOSE_1()
        {
            /*" -1559- EXEC SQL CLOSE V0BILHEERR END-EXEC */

            V0BILHEERR.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1170_99_SAIDA*/

        [StopWatch]
        /*" R1180-00-PROCESSA-BILHEERR-SECTION */
        private void R1180_00_PROCESSA_BILHEERR_SECTION()
        {
            /*" -1578- MOVE '1180' TO WNR-EXEC-SQL. */
            _.Move("1180", W.WABEND.WNR_EXEC_SQL);

            /*" -1581- MOVE BILHEERR-COD-ERRO TO WS-CODERRO. */
            _.Move(BILHEERR.DCLBILHETE_ERROS.BILHEERR_COD_ERRO, W.WS_ERROS.WS_CODERRO);

            /*" -1582- IF BILHEERR-COD-ERRO EQUAL 10702 */

            if (BILHEERR.DCLBILHETE_ERROS.BILHEERR_COD_ERRO == 10702)
            {

                /*" -1584- MOVE 'EMPREGADO NAO ENCONTRADO   ' TO WS-DESERRO */
                _.Move("EMPREGADO NAO ENCONTRADO   ", W.WS_ERROS.WS_DESERRO);

                /*" -1585- ELSE */
            }
            else
            {


                /*" -1586- IF BILHEERR-COD-ERRO EQUAL 0834 */

                if (BILHEERR.DCLBILHETE_ERROS.BILHEERR_COD_ERRO == 0834)
                {

                    /*" -1588- MOVE 'ULTRAPASSA LIMITE DE RISCO' TO WS-DESERRO */
                    _.Move("ULTRAPASSA LIMITE DE RISCO", W.WS_ERROS.WS_DESERRO);

                    /*" -1590- ELSE */
                }
                else
                {


                    /*" -1591- IF BILHEERR-COD-ERRO EQUAL 10902 */

                    if (BILHEERR.DCLBILHETE_ERROS.BILHEERR_COD_ERRO == 10902)
                    {

                        /*" -1593- MOVE 'CGCCPF INVALIDO            ' TO WS-DESERRO */
                        _.Move("CGCCPF INVALIDO            ", W.WS_ERROS.WS_DESERRO);

                        /*" -1595- ELSE */
                    }
                    else
                    {


                        /*" -1596- IF BILHEERR-COD-ERRO EQUAL 10903 */

                        if (BILHEERR.DCLBILHETE_ERROS.BILHEERR_COD_ERRO == 10903)
                        {

                            /*" -1598- MOVE 'ULTRAPASSA QTDE PROPOSTAS  ' TO WS-DESERRO */
                            _.Move("ULTRAPASSA QTDE PROPOSTAS  ", W.WS_ERROS.WS_DESERRO);

                            /*" -1600- ELSE */
                        }
                        else
                        {


                            /*" -1601- IF BILHEERR-COD-ERRO EQUAL 11001 */

                            if (BILHEERR.DCLBILHETE_ERROS.BILHEERR_COD_ERRO == 11001)
                            {

                                /*" -1603- MOVE 'SEM DATA NASCIMENTO       ' TO WS-DESERRO */
                                _.Move("SEM DATA NASCIMENTO       ", W.WS_ERROS.WS_DESERRO);

                                /*" -1605- ELSE */
                            }
                            else
                            {


                                /*" -1606- IF BILHEERR-COD-ERRO EQUAL 11101 */

                                if (BILHEERR.DCLBILHETE_ERROS.BILHEERR_COD_ERRO == 11101)
                                {

                                    /*" -1608- MOVE 'IDADE FORA DA COBERTURA ' TO WS-DESERRO */
                                    _.Move("IDADE FORA DA COBERTURA ", W.WS_ERROS.WS_DESERRO);

                                    /*" -1610- ELSE */
                                }
                                else
                                {


                                    /*" -1612- IF BILHEERR-COD-ERRO EQUAL 11502 OR 1503 */

                                    if (BILHEERR.DCLBILHETE_ERROS.BILHEERR_COD_ERRO.In("11502", "1503"))
                                    {

                                        /*" -1614- MOVE 'OPCAO DE COBERTURA INVALIDA' TO WS-DESERRO */
                                        _.Move("OPCAO DE COBERTURA INVALIDA", W.WS_ERROS.WS_DESERRO);

                                        /*" -1616- ELSE */
                                    }
                                    else
                                    {


                                        /*" -1617- IF BILHEERR-COD-ERRO EQUAL 11802 */

                                        if (BILHEERR.DCLBILHETE_ERROS.BILHEERR_COD_ERRO == 11802)
                                        {

                                            /*" -1619- MOVE 'DADOS PAG/CRED NAO CADASTRADO' TO WS-DESERRO */
                                            _.Move("DADOS PAG/CRED NAO CADASTRADO", W.WS_ERROS.WS_DESERRO);

                                            /*" -1620- ELSE */
                                        }
                                        else
                                        {


                                            /*" -1621- IF BILHEERR-COD-ERRO EQUAL 1885 */

                                            if (BILHEERR.DCLBILHETE_ERROS.BILHEERR_COD_ERRO == 1885)
                                            {

                                                /*" -1623- MOVE 'CANCELADO ACUMULO DE RISCO' TO WS-DESERRO */
                                                _.Move("CANCELADO ACUMULO DE RISCO", W.WS_ERROS.WS_DESERRO);

                                                /*" -1625- ELSE */
                                            }
                                            else
                                            {


                                                /*" -1626- IF BILHEERR-COD-ERRO EQUAL 11901 */

                                                if (BILHEERR.DCLBILHETE_ERROS.BILHEERR_COD_ERRO == 11901)
                                                {

                                                    /*" -1628- MOVE 'DATA PAGAMENTO DIVERGE  ' TO WS-DESERRO */
                                                    _.Move("DATA PAGAMENTO DIVERGE  ", W.WS_ERROS.WS_DESERRO);

                                                    /*" -1630- ELSE */
                                                }
                                                else
                                                {


                                                    /*" -1631- IF BILHEERR-COD-ERRO EQUAL 12101 */

                                                    if (BILHEERR.DCLBILHETE_ERROS.BILHEERR_COD_ERRO == 12101)
                                                    {

                                                        /*" -1633- MOVE 'VALOR DIVERGENTE        ' TO WS-DESERRO */
                                                        _.Move("VALOR DIVERGENTE        ", W.WS_ERROS.WS_DESERRO);

                                                        /*" -1634- ELSE */
                                                    }
                                                    else
                                                    {


                                                        /*" -1637- MOVE 'OUTRAS DIVERGENCIAS     ' TO WS-DESERRO. */
                                                        _.Move("OUTRAS DIVERGENCIAS     ", W.WS_ERROS.WS_DESERRO);
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


            /*" -1640- MOVE WS-ERROS TO LD01-DESCERRO. */
            _.Move(W.WS_ERROS, AUX_RELATORIO.LD01.LD01_DESCERRO);

            /*" -1641- MOVE 2 TO AC-ARQUIVO. */
            _.Move(2, W.AC_ARQUIVO);

            /*" -1641- PERFORM R2000-00-GRAVA-ARQUIVO. */

            R2000_00_GRAVA_ARQUIVO_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R1180_90_LEITURA */

            R1180_90_LEITURA();

        }

        [StopWatch]
        /*" R1180-90-LEITURA */
        private void R1180_90_LEITURA(bool isPerform = false)
        {
            /*" -1646- PERFORM R1170-00-FETCH-BILHEERR. */

            R1170_00_FETCH_BILHEERR_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1180_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-GRAVA-ARQUIVO-SECTION */
        private void R2000_00_GRAVA_ARQUIVO_SECTION()
        {
            /*" -1658- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", W.WABEND.WNR_EXEC_SQL);

            /*" -1659- IF LD01-DTCANCEL NOT EQUAL SPACES */

            if (!AUX_RELATORIO.LD01.LD01_DTCANCEL.IsEmpty())
            {

                /*" -1660- WRITE REG-SAIDA03 FROM LD01 */
                _.Move(AUX_RELATORIO.LD01.GetMoveValues(), REG_SAIDA03);

                SAIDA03.Write(REG_SAIDA03.GetMoveValues().ToString());

                /*" -1661- ADD 1 TO GV-ARQUIVO03 */
                W.GV_ARQUIVO03.Value = W.GV_ARQUIVO03 + 1;

                /*" -1662- ELSE */
            }
            else
            {


                /*" -1663- IF AC-ARQUIVO EQUAL 1 */

                if (W.AC_ARQUIVO == 1)
                {

                    /*" -1664- WRITE REG-SAIDA01 FROM LD01 */
                    _.Move(AUX_RELATORIO.LD01.GetMoveValues(), REG_SAIDA01);

                    SAIDA01.Write(REG_SAIDA01.GetMoveValues().ToString());

                    /*" -1665- ADD 1 TO GV-ARQUIVO01 */
                    W.GV_ARQUIVO01.Value = W.GV_ARQUIVO01 + 1;

                    /*" -1666- ELSE */
                }
                else
                {


                    /*" -1668- IF LD01-DTQITBCO GREATER V1SIST-DTMOVABE-15D */

                    if (AUX_RELATORIO.LD01.LD01_DTQITBCO > V1SIST_DTMOVABE_15D)
                    {

                        /*" -1669- WRITE REG-SAIDA04 FROM LD01 */
                        _.Move(AUX_RELATORIO.LD01.GetMoveValues(), REG_SAIDA04);

                        SAIDA04.Write(REG_SAIDA04.GetMoveValues().ToString());

                        /*" -1670- ADD 1 TO GV-ARQUIVO04 */
                        W.GV_ARQUIVO04.Value = W.GV_ARQUIVO04 + 1;

                        /*" -1671- ELSE */
                    }
                    else
                    {


                        /*" -1672- WRITE REG-SAIDA02 FROM LD01 */
                        _.Move(AUX_RELATORIO.LD01.GetMoveValues(), REG_SAIDA02);

                        SAIDA02.Write(REG_SAIDA02.GetMoveValues().ToString());

                        /*" -1672- ADD 1 TO GV-ARQUIVO02. */
                        W.GV_ARQUIVO02.Value = W.GV_ARQUIVO02 + 1;
                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-CONS-DELETE-VGCRITICA-SECTION */
        private void R3000_00_CONS_DELETE_VGCRITICA_SECTION()
        {
            /*" -1716- MOVE '3000' TO WNR-EXEC-SQL. */
            _.Move("3000", W.WABEND.WNR_EXEC_SQL);

            /*" -1718- INITIALIZE LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Initialize(
                SPVG001W.LK_VG001_TRACE
                , SPVG001W.LK_VG001_TIPO_ACAO
                , SPVG001W.LK_VG001_NUM_CERTIFICADO
                , SPVG001W.LK_VG001_SEQ_CRITICA
                , SPVG001W.LK_VG001_IND_TP_PROPOSTA
                , SPVG001W.LK_VG001_NUM_CPF_CNPJ
                , SPVG001W.LK_VG001_COD_MSG_CRITICA
                , SPVG001W.LK_VG001_COD_USUARIO
                , SPVG001W.LK_VG001_NOM_PROGRAMA
                , SPVG001W.LK_VG001_STA_CRITICA
                , SPVG001W.LK_VG001_DES_COMPLEMENTAR
                , SPVG001W.LK_VG001_S_NUM_CERTIFICADO
                , SPVG001W.LK_VG001_S_SEQ_CRITICA
                , SPVG001W.LK_VG001_S_IND_TP_PROPOSTA
                , SPVG001W.LK_VG001_S_COD_MSG_CRITICA
                , SPVG001W.LK_VG001_S_DES_MSG_CRITICA
                , SPVG001W.LK_VG001_S_DES_ABREV_MSG_CRIT
                , SPVG001W.LK_VG001_S_NUM_CPF_CNPJ
                , SPVG001W.LK_VG001_S_NUM_PROPOSTA
                , SPVG001W.LK_VG001_S_VLR_IS
                , SPVG001W.LK_VG001_S_VLR_PREMIO
                , SPVG001W.LK_VG001_S_DTA_OCORRENCIA
                , SPVG001W.LK_VG001_S_DTA_RCAP
                , SPVG001W.LK_VG001_S_STA_CRITICA
                , SPVG001W.LK_VG001_S_DES_STA_CRITICA
                , SPVG001W.LK_VG001_S_DES_COMPLEMENTAR
                , SPVG001W.LK_VG001_S_COD_USUARIO
                , SPVG001W.LK_VG001_S_NOM_PROGRAMA
                , SPVG001W.LK_VG001_S_DTH_CADASTRAMENTO
                , SPVG001W.LK_VG001_S_STA_PARA
                , SPVG001W.LK_VG001_IND_ERRO
                , SPVG001W.LK_VG001_MSG_ERRO
                , SPVG001W.LK_VG001_NOM_TABELA
                , SPVG001W.LK_VG001_SQLCODE
                , SPVG001W.LK_VG001_SQLERRMC
            );

            /*" -1719- MOVE 'N' TO LK-VG001-TRACE */
            _.Move("N", SPVG001W.LK_VG001_TRACE);

            /*" -1720- MOVE 07 TO LK-VG001-TIPO-ACAO */
            _.Move(07, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -1721- MOVE BILHETE-NUM-BILHETE TO LK-VG001-NUM-CERTIFICADO */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE, SPVG001W.LK_VG001_NUM_CERTIFICADO);

            /*" -1722- MOVE 11802 TO LK-VG001-COD-MSG-CRITICA */
            _.Move(11802, SPVG001W.LK_VG001_COD_MSG_CRITICA);

            /*" -1723- MOVE 0 TO LK-VG001-SEQ-CRITICA */
            _.Move(0, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -1724- MOVE 'BI' TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("BI", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -1725- MOVE 0 TO LK-VG001-NUM-CPF-CNPJ */
            _.Move(0, SPVG001W.LK_VG001_NUM_CPF_CNPJ);

            /*" -1726- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -1727- MOVE 'BI5166B' TO LK-VG001-NOM-PROGRAMA */
            _.Move("BI5166B", SPVG001W.LK_VG001_NOM_PROGRAMA);

            /*" -1728- MOVE 'SPBVG001' TO VG001-PROGRAMA */
            _.Move("SPBVG001", SPVG001V.VG001_PROGRAMA);

            /*" -1730- MOVE SPACES TO LK-VG001-STA-CRITICA */
            _.Move("", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -1732- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -1733- IF LK-VG001-IND-ERRO = 0 */

            if (SPVG001W.LK_VG001_IND_ERRO == 0)
            {

                /*" -1734- IF LK-VG001-S-NUM-CERTIFICADO > 0 */

                if (SPVG001W.LK_VG001_S_NUM_CERTIFICADO > 0)
                {

                    /*" -1735- PERFORM R3100-00-DELETE-VGCRITICA */

                    R3100_00_DELETE_VGCRITICA_SECTION();

                    /*" -1736- ADD 1 TO UP-BILHEERR */
                    W.UP_BILHEERR.Value = W.UP_BILHEERR + 1;

                    /*" -1737- ELSE */
                }
                else
                {


                    /*" -1739- ADD 1 TO NT-BILHEERR */
                    W.NT_BILHEERR.Value = W.NT_BILHEERR + 1;

                    /*" -1740- END-IF */
                }


                /*" -1741- ELSE */
            }
            else
            {


                /*" -1742- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -1743- DISPLAY '* R3000 -  PROBLEMAS CALL SUBROTINA SPBVG001  *' */
                _.Display($"* R3000 -  PROBLEMAS CALL SUBROTINA SPBVG001  *");

                /*" -1744- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -1745- DISPLAY '* NUM-CERTIF..: ' LK-VG001-NUM-CERTIFICADO */
                _.Display($"* NUM-CERTIF..: {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                /*" -1746- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                /*" -1747- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                /*" -1748- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                /*" -1749- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                /*" -1750- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                /*" -1752- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -1753- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1754- END-IF */
            }


            /*" -1754- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-DELETE-VGCRITICA-SECTION */
        private void R3100_00_DELETE_VGCRITICA_SECTION()
        {
            /*" -1766- MOVE '3100' TO WNR-EXEC-SQL. */
            _.Move("3100", W.WABEND.WNR_EXEC_SQL);

            /*" -1767- MOVE 'N' TO LK-VG001-TRACE */
            _.Move("N", SPVG001W.LK_VG001_TRACE);

            /*" -1768- MOVE 03 TO LK-VG001-TIPO-ACAO */
            _.Move(03, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -1769- MOVE LK-VG001-S-SEQ-CRITICA TO LK-VG001-SEQ-CRITICA */
            _.Move(SPVG001W.LK_VG001_S_SEQ_CRITICA, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -1770- MOVE 'BI' TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("BI", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -1771- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -1772- MOVE 'BI5166B' TO LK-VG001-NOM-PROGRAMA */
            _.Move("BI5166B", SPVG001W.LK_VG001_NOM_PROGRAMA);

            /*" -1773- MOVE 'SPBVG001' TO VG001-PROGRAMA */
            _.Move("SPBVG001", SPVG001V.VG001_PROGRAMA);

            /*" -1774- MOVE 'B' TO LK-VG001-STA-CRITICA */
            _.Move("B", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -1775- MOVE 50 TO LK-VG001-DES-COMPLEMENTAR-L */
            _.Move(50, SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_L);

            /*" -1778- MOVE 'EXCLUSAO LOGICA DE ERRO DA PROPOSTA ' TO LK-VG001-DES-COMPLEMENTAR-T */
            _.Move("EXCLUSAO LOGICA DE ERRO DA PROPOSTA ", SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_T);

            /*" -1780- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -1781- IF LK-VG001-IND-ERRO NOT EQUAL ZEROS */

            if (SPVG001W.LK_VG001_IND_ERRO != 00)
            {

                /*" -1782- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -1783- DISPLAY '* R3100 -  PROBLEMAS CALL SUBROTINA SPBVG001  *' */
                _.Display($"* R3100 -  PROBLEMAS CALL SUBROTINA SPBVG001  *");

                /*" -1784- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -1785- DISPLAY '* NUM-CERTIF..: ' LK-VG001-NUM-CERTIFICADO */
                _.Display($"* NUM-CERTIF..: {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                /*" -1786- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                /*" -1787- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                /*" -1788- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                /*" -1789- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                /*" -1790- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                /*" -1792- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -1793- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1794- END-IF */
            }


            /*" -1794- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1802- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, W.WABEND.WSQLCODE);

            /*" -1803- MOVE SQLERRD(1) TO WSQLERRD1 */
            _.Move(DB.SQLERRD[1], W.WABEND.WSQLERRD1);

            /*" -1804- MOVE SQLERRD(2) TO WSQLERRD2 */
            _.Move(DB.SQLERRD[2], W.WABEND.WSQLERRD2);

            /*" -1805- MOVE SQLERRMC TO WSQLERRMC */
            _.Move(DB.SQLERRMC, W.WABEND.WSQLERRMC);

            /*" -1807- DISPLAY WABEND. */
            _.Display(W.WABEND);

            /*" -1807- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1814- CLOSE SAIDA01 SAIDA02 SAIDA03 SAIDA04. */
            SAIDA01.Close();
            SAIDA02.Close();
            SAIDA03.Close();
            SAIDA04.Close();

            /*" -1816- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1816- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}