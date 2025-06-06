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
using Sias.VidaAzul.DB2.VA0460B;

namespace Code
{
    public class VA0460B
    {
        public bool IsCall { get; set; }

        public VA0460B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  COBRANCA                           *      */
        /*"      *   PROGRAMA ...............  VA0460B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  CLOVIS                             *      */
        /*"      *   PROGRAMADOR ............  CLOVIS                             *      */
        /*"      *   DATA CODIFICACAO .......  23/07/2002                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  EMITE SOLICITACAO DE DEVOLUCAO     *      */
        /*"      *                             COM CHEQUE NA TABELA RELATORIOS.   *      */
        /*"      *                             SUBSTITUI O PGM VA0461B.           *      */
        /*"      *   VER PROC01                                                   *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                  A L T E R A C O E S                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  002 - 20/04/2004 - MANOEL MESSIAS  =====> PROCURE POR MM0404  *      */
        /*"      *                                                                *      */
        /*"      *    RECUPERA O VALOR A SER DEVOLVIDO NA TABELA V0HISTCONTABILVA *      */
        /*"      * EM SUBSTITUICAO A TABELA V0HISTCOBVA.                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  001 - 11/09/2003 - MANOEL MESSIAS  =====> PROCURE POR MM0903  *      */
        /*"      *                                                                *      */
        /*"      *    RECUPERA O CODIGO DE USUARIO DA V0HISTCONTAVA AO INVES DE   *      */
        /*"      * PEGAR DA V0PROPOSTA,QUE AS VEZES CONTINHA COMO USUARIO O CODIGO*      */
        /*"      * DE UM PROGRAMA (EX: VG0001B).                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _VA0460B1 { get; set; } = new FileBasis(new PIC("X", "132", "X(132)"));

        public FileBasis VA0460B1
        {
            get
            {
                _.Move(REG_VA0460B, _VA0460B1); VarBasis.RedefinePassValue(REG_VA0460B, _VA0460B1, REG_VA0460B); return _VA0460B1;
            }
        }
        /*"01        REG-VA0460B                 PIC  X(132).*/
        public StringBasis REG_VA0460B { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77    VIND-RAMO                 PIC S9(004)     COMP.*/
        public IntBasis VIND_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-CODPRODU             PIC S9(004)     COMP.*/
        public IntBasis VIND_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-AGECOBR              PIC S9(004)     COMP.*/
        public IntBasis VIND_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-CODENDER             PIC S9(004)     COMP.*/
        public IntBasis VIND_CODENDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  W.*/
        public VA0460B_W W { get; set; } = new VA0460B_W();
        public class VA0460B_W : VarBasis
        {
            /*"  03  WFIM-MOVIMENTO            PIC  X(001)         VALUE SPACES*/
            public StringBasis WFIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WFIM-V0RCAPCOMP           PIC  X(001)         VALUE SPACES*/
            public StringBasis WFIM_V0RCAPCOMP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  LD-COBHISVI               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis LD_COBHISVI { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-DESPREZA               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis DP_DESPREZA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-RCAPS                  PIC  9(007)         VALUE ZEROS.*/
            public IntBasis DP_RCAPS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-AGENCIA                PIC  9(007)         VALUE ZEROS.*/
            public IntBasis DP_AGENCIA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-ESCRITORIO             PIC  9(007)         VALUE ZEROS.*/
            public IntBasis DP_ESCRITORIO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-FILIAL                 PIC  9(007)         VALUE ZEROS.*/
            public IntBasis DP_FILIAL { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-CLIENTE                PIC  9(007)         VALUE ZEROS.*/
            public IntBasis DP_CLIENTE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-ENDERECO               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis DP_ENDERECO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-MOTIVO                 PIC  9(007)         VALUE ZEROS.*/
            public IntBasis DP_MOTIVO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-USUARIO                PIC  9(007)         VALUE ZEROS.*/
            public IntBasis DP_USUARIO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-PRODUTO                PIC  9(007)         VALUE ZEROS.*/
            public IntBasis DP_PRODUTO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-RELATORIOS             PIC  9(007)         VALUE ZEROS.*/
            public IntBasis AC_RELATORIOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-IMPRESSOS              PIC  9(007)         VALUE ZEROS.*/
            public IntBasis AC_IMPRESSOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-PAGINA                 PIC  9(004)         VALUE ZEROS.*/
            public IntBasis AC_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03  AC-LINHAS                 PIC  9(004)         VALUE 100.*/
            public IntBasis AC_LINHAS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"), 100);
            /*"  03  AUX-COD-FONTE             PIC  9(004)         VALUE ZEROS.*/
            public IntBasis AUX_COD_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03  AUX-COD-DESPESA           PIC  9(004)         VALUE ZEROS.*/
            public IntBasis AUX_COD_DESPESA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03  AUX-HORAOPER              PIC  X(008)         VALUE SPACES*/
            public StringBasis AUX_HORAOPER { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"  03  AUX-SITUACAO              PIC  X(001)         VALUE SPACES*/
            public StringBasis AUX_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  TEM-AVISO                 PIC  X(001)         VALUE SPACES*/
            public StringBasis TEM_AVISO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03         WDATA-REL         PIC  X(010)    VALUE SPACES.*/
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03         FILLER            REDEFINES      WDATA-REL.*/
            private _REDEF_VA0460B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_VA0460B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_VA0460B_FILLER_0(); _.Move(WDATA_REL, _filler_0); VarBasis.RedefinePassValue(WDATA_REL, _filler_0, WDATA_REL); _filler_0.ValueChanged += () => { _.Move(_filler_0, WDATA_REL); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WDATA_REL); }
            }  //Redefines
            public class _REDEF_VA0460B_FILLER_0 : VarBasis
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

                public _REDEF_VA0460B_FILLER_0()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public VA0460B_WDATA_CABEC WDATA_CABEC { get; set; } = new VA0460B_WDATA_CABEC();
            public class VA0460B_WDATA_CABEC : VarBasis
            {
                /*"    10       WDATA-DD-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDATA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDATA-AA-CABEC    PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  03         WTIME-DAY         PIC  99.99.99.99.*/
            }
            public IntBasis WTIME_DAY { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
            /*"  03         FILLER            REDEFINES      WTIME-DAY.*/
            private _REDEF_VA0460B_FILLER_5 _filler_5 { get; set; }
            public _REDEF_VA0460B_FILLER_5 FILLER_5
            {
                get { _filler_5 = new _REDEF_VA0460B_FILLER_5(); _.Move(WTIME_DAY, _filler_5); VarBasis.RedefinePassValue(WTIME_DAY, _filler_5, WTIME_DAY); _filler_5.ValueChanged += () => { _.Move(_filler_5, WTIME_DAY); }; return _filler_5; }
                set { VarBasis.RedefinePassValue(value, _filler_5, WTIME_DAY); }
            }  //Redefines
            public class _REDEF_VA0460B_FILLER_5 : VarBasis
            {
                /*"    10       WTIME-DAYR.*/
                public VA0460B_WTIME_DAYR WTIME_DAYR { get; set; } = new VA0460B_WTIME_DAYR();
                public class VA0460B_WTIME_DAYR : VarBasis
                {
                    /*"      15     WTIME-HORA        PIC  X(002).*/
                    public StringBasis WTIME_HORA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"      15     WTIME-2PT1        PIC  X(001).*/
                    public StringBasis WTIME_2PT1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15     WTIME-MINU        PIC  X(002).*/
                    public StringBasis WTIME_MINU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"      15     WTIME-2PT2        PIC  X(001).*/
                    public StringBasis WTIME_2PT2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15     WTIME-SEGU        PIC  X(002).*/
                    public StringBasis WTIME_SEGU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"    10       WTIME-2PT3        PIC  X(001).*/

                    public VA0460B_WTIME_DAYR()
                    {
                        WTIME_HORA.ValueChanged += OnValueChanged;
                        WTIME_2PT1.ValueChanged += OnValueChanged;
                        WTIME_MINU.ValueChanged += OnValueChanged;
                        WTIME_2PT2.ValueChanged += OnValueChanged;
                        WTIME_SEGU.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis WTIME_2PT3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WTIME-CCSE        PIC  X(002).*/
                public StringBasis WTIME_CCSE { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"  03         WS-TIME.*/

                public _REDEF_VA0460B_FILLER_5()
                {
                    WTIME_DAYR.ValueChanged += OnValueChanged;
                    WTIME_2PT3.ValueChanged += OnValueChanged;
                    WTIME_CCSE.ValueChanged += OnValueChanged;
                }

            }
            public VA0460B_WS_TIME WS_TIME { get; set; } = new VA0460B_WS_TIME();
            public class VA0460B_WS_TIME : VarBasis
            {
                /*"    10       WS-HH-TIME        PIC  9(002).*/
                public IntBasis WS_HH_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WS-MM-TIME        PIC  9(002).*/
                public IntBasis WS_MM_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WS-SS-TIME        PIC  9(002).*/
                public IntBasis WS_SS_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WS-CC-TIME        PIC  9(002).*/
                public IntBasis WS_CC_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WHORA-CABEC.*/
            }
            public VA0460B_WHORA_CABEC WHORA_CABEC { get; set; } = new VA0460B_WHORA_CABEC();
            public class VA0460B_WHORA_CABEC : VarBasis
            {
                /*"    10       WHORA-HH-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_HH_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '.'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10       WHORA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '.'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10       WHORA-SS-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_SS_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  03         WS-VLALFA         PIC  X(015)    VALUE SPACES.*/
            }
            public StringBasis WS_VLALFA { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
            /*"  03         FILLER            REDEFINES      WS-VLALFA.*/
            private _REDEF_VA0460B_FILLER_8 _filler_8 { get; set; }
            public _REDEF_VA0460B_FILLER_8 FILLER_8
            {
                get { _filler_8 = new _REDEF_VA0460B_FILLER_8(); _.Move(WS_VLALFA, _filler_8); VarBasis.RedefinePassValue(WS_VLALFA, _filler_8, WS_VLALFA); _filler_8.ValueChanged += () => { _.Move(_filler_8, WS_VLALFA); }; return _filler_8; }
                set { VarBasis.RedefinePassValue(value, _filler_8, WS_VLALFA); }
            }  //Redefines
            public class _REDEF_VA0460B_FILLER_8 : VarBasis
            {
                /*"    10       WS-VLNUME         PIC  9(013)V99.*/
                public DoubleBasis WS_VLNUME { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"  03          LC01.*/

                public _REDEF_VA0460B_FILLER_8()
                {
                    WS_VLNUME.ValueChanged += OnValueChanged;
                }

            }
            public VA0460B_LC01 LC01 { get; set; } = new VA0460B_LC01();
            public class VA0460B_LC01 : VarBasis
            {
                /*"    10        FILLER              PIC  X(007)  VALUE             'VA0460B'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"VA0460B");
                /*"    10        FILLER              PIC  X(033)  VALUE SPACES.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "33", "X(033)"), @"");
                /*"    10        LC01-EMPRESA        PIC  X(040).*/
                public StringBasis LC01_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    10        FILLER              PIC  X(032)  VALUE SPACES.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "32", "X(032)"), @"");
                /*"    10        FILLER              PIC  X(010)  VALUE             'PAGINA: '.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"PAGINA: ");
                /*"    10        FILLER              PIC  X(005)  VALUE SPACES.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"    10        LC01-PAGINA         PIC  ZZZZ9.*/
                public IntBasis LC01_PAGINA { get; set; } = new IntBasis(new PIC("9", "5", "ZZZZ9."));
                /*"  03          LC02.*/
            }
            public VA0460B_LC02 LC02 { get; set; } = new VA0460B_LC02();
            public class VA0460B_LC02 : VarBasis
            {
                /*"    10        FILLER              PIC  X(112)  VALUE SPACES.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "112", "X(112)"), @"");
                /*"    10        FILLER              PIC  X(010)  VALUE             'DATA  : '.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DATA  : ");
                /*"    10        LC02-DATA           PIC  X(010).*/
                public StringBasis LC02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"  03          LC03.*/
            }
            public VA0460B_LC03 LC03 { get; set; } = new VA0460B_LC03();
            public class VA0460B_LC03 : VarBasis
            {
                /*"    10        FILLER              PIC  X(025)  VALUE SPACES.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
                /*"    10        FILLER              PIC  X(038)  VALUE             'DEVOLUCAO DE PREMIO POR NAO ACEITACAO '.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "38", "X(038)"), @"DEVOLUCAO DE PREMIO POR NAO ACEITACAO ");
                /*"    10        FILLER              PIC  X(020)  VALUE             'DE PROPOSTA VIDAZUL '.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"DE PROPOSTA VIDAZUL ");
                /*"    10        LC03-DATA           PIC  X(010)  VALUE SPACES.*/
                public StringBasis LC03_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10        FILLER              PIC  X(019)  VALUE SPACES.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"");
                /*"    10        FILLER              PIC  X(010)  VALUE             'HORA  : '.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"HORA  : ");
                /*"    10        FILLER              PIC  X(002)  VALUE SPACES.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10        LC03-HORA           PIC  X(008).*/
                public StringBasis LC03_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"  03          LC04.*/
            }
            public VA0460B_LC04 LC04 { get; set; } = new VA0460B_LC04();
            public class VA0460B_LC04 : VarBasis
            {
                /*"    10        FILLER              PIC  X(132)  VALUE             'RELACAO DE PROPOSTAS NAO DEVOLVIDAS'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"RELACAO DE PROPOSTAS NAO DEVOLVIDAS");
                /*"  03          LC05.*/
            }
            public VA0460B_LC05 LC05 { get; set; } = new VA0460B_LC05();
            public class VA0460B_LC05 : VarBasis
            {
                /*"    10        FILLER              PIC  X(132)  VALUE ALL '-'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
                /*"  03          LC06.*/
            }
            public VA0460B_LC06 LC06 { get; set; } = new VA0460B_LC06();
            public class VA0460B_LC06 : VarBasis
            {
                /*"    10        FILLER              PIC  X(004)  VALUE SPACES.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10        FILLER              PIC  X(020)  VALUE             'CERTIFICADO'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"CERTIFICADO");
                /*"    10        FILLER              PIC  X(007)  VALUE             'TITULO'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"TITULO");
                /*"    10        FILLER              PIC  X(008)  VALUE             'PARCELA'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"PARCELA");
                /*"    10        FILLER              PIC  X(043)  VALUE             'SEGURADO'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "43", "X(043)"), @"SEGURADO");
                /*"    10        FILLER              PIC  X(018)  VALUE             'QUITACAO'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"QUITACAO");
                /*"    10        FILLER              PIC  X(007)  VALUE             'VALOR'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"VALOR");
                /*"    10        FILLER              PIC  X(025)  VALUE             'OCORRENCIA'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"OCORRENCIA");
                /*"  03          LC08.*/
            }
            public VA0460B_LC08 LC08 { get; set; } = new VA0460B_LC08();
            public class VA0460B_LC08 : VarBasis
            {
                /*"    10        FILLER              PIC  X(132)  VALUE SPACES.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
                /*"  03          LD01.*/
            }
            public VA0460B_LD01 LD01 { get; set; } = new VA0460B_LD01();
            public class VA0460B_LD01 : VarBasis
            {
                /*"    10        LD01-NRCERTIF       PIC  ZZZZ99999999999.*/
                public IntBasis LD01_NRCERTIF { get; set; } = new IntBasis(new PIC("9", "15", "ZZZZ99999999999."));
                /*"    10        FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10        LD01-NRTIT          PIC  ZZZ99999999999.*/
                public IntBasis LD01_NRTIT { get; set; } = new IntBasis(new PIC("9", "14", "ZZZ99999999999."));
                /*"    10        FILLER              PIC  X(003) VALUE SPACES.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10        LD01-NRPARCEL       PIC  ZZZZ9.*/
                public IntBasis LD01_NRPARCEL { get; set; } = new IntBasis(new PIC("9", "5", "ZZZZ9."));
                /*"    10        FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10        LD01-SEGURADO       PIC  X(040).*/
                public StringBasis LD01_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    10        FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10        LD01-QUITACAO       PIC  X(010).*/
                public StringBasis LD01_QUITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10        LD01-VALOR          PIC  ZZZ.ZZZ.ZZ9,99-.*/
                public DoubleBasis LD01_VALOR { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99-."), 3);
                /*"    10        FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10        LD01-DESCRICAO      PIC  X(025).*/
                public StringBasis LD01_DESCRICAO { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
                /*"  03        WABEND.*/
            }
            public VA0460B_WABEND WABEND { get; set; } = new VA0460B_WABEND();
            public class VA0460B_WABEND : VarBasis
            {
                /*"    05      FILLER              PIC  X(010) VALUE           ' VA0460B  '.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VA0460B  ");
                /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05      WNR-EXEC-SQL        PIC  X(004) VALUE    SPACES.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"    05      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD1 = '.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"    05      WSQLERRD1           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD2 = '.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05      WSQLERRD2           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"01  LK-LINK.*/
            }
        }
        public VA0460B_LK_LINK LK_LINK { get; set; } = new VA0460B_LK_LINK();
        public class VA0460B_LK_LINK : VarBasis
        {
            /*"  03          LK-RTCODE           PIC S9(004)   VALUE +0   COMP.*/
            public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03          LK-TAMANHO          PIC S9(004)   VALUE +40  COMP.*/
            public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
            /*"  03          LK-TITULO           PIC  X(132)   VALUE  SPACES.*/
            public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.EMPRESAS EMPRESAS { get; set; } = new Dclgens.EMPRESAS();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.COBHISVI COBHISVI { get; set; } = new Dclgens.COBHISVI();
        public Dclgens.PRODUVG PRODUVG { get; set; } = new Dclgens.PRODUVG();
        public Dclgens.RCAPS RCAPS { get; set; } = new Dclgens.RCAPS();
        public Dclgens.AGENCCEF AGENCCEF { get; set; } = new Dclgens.AGENCCEF();
        public Dclgens.MALHACEF MALHACEF { get; set; } = new Dclgens.MALHACEF();
        public Dclgens.ESCRINEG ESCRINEG { get; set; } = new Dclgens.ESCRINEG();
        public Dclgens.FONTES FONTES { get; set; } = new Dclgens.FONTES();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.ENDERECO ENDERECO { get; set; } = new Dclgens.ENDERECO();
        public Dclgens.DEVOLVID DEVOLVID { get; set; } = new Dclgens.DEVOLVID();
        public Dclgens.USUARIOS USUARIOS { get; set; } = new Dclgens.USUARIOS();
        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();
        public Dclgens.RCAPCOMP RCAPCOMP { get; set; } = new Dclgens.RCAPCOMP();
        public Dclgens.AVISOSAL AVISOSAL { get; set; } = new Dclgens.AVISOSAL();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.HISLANCT HISLANCT { get; set; } = new Dclgens.HISLANCT();
        public Dclgens.HISCONPA HISCONPA { get; set; } = new Dclgens.HISCONPA();
        public VA0460B_V0HISTCOBVA V0HISTCOBVA { get; set; } = new VA0460B_V0HISTCOBVA();
        public VA0460B_V0RCAPCOMP V0RCAPCOMP { get; set; } = new VA0460B_V0RCAPCOMP();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string VA0460B1_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                VA0460B1.SetFile(VA0460B1_FILE_NAME_P);

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
            /*" -298- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", W.WABEND.WNR_EXEC_SQL);

            /*" -299- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -301- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -303- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -309- PERFORM R0050-00-INICIO. */

            R0050_00_INICIO_SECTION();

            /*" -310- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", W.WFIM_MOVIMENTO);

            /*" -312- PERFORM R0300-00-DECLARE-V0HISTCOBVA. */

            R0300_00_DECLARE_V0HISTCOBVA_SECTION();

            /*" -314- PERFORM R0310-00-FETCH-V0HISTCOBVA. */

            R0310_00_FETCH_V0HISTCOBVA_SECTION();

            /*" -315- PERFORM R0350-00-PROCESSA-V0HISTCOBVA UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!W.WFIM_MOVIMENTO.IsEmpty()))
            {

                R0350_00_PROCESSA_V0HISTCOBVA_SECTION();
            }

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -320- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -324- CLOSE VA0460B1. */
            VA0460B1.Close();

            /*" -326- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -327- DISPLAY ' ' */
            _.Display($" ");

            /*" -328- DISPLAY 'VA0460B - FIM NORMAL' . */
            _.Display($"VA0460B - FIM NORMAL");

            /*" -329- DISPLAY ' ' */
            _.Display($" ");

            /*" -330- DISPLAY 'SOLICITACOES LIDAS .......... ' LD-COBHISVI */
            _.Display($"SOLICITACOES LIDAS .......... {W.LD_COBHISVI}");

            /*" -331- DISPLAY 'SOLICITACOES DESPREZADAS .... ' DP-DESPREZA */
            _.Display($"SOLICITACOES DESPREZADAS .... {W.DP_DESPREZA}");

            /*" -332- DISPLAY 'SOLICITACOES EFETUADAS ...... ' AC-RELATORIOS */
            _.Display($"SOLICITACOES EFETUADAS ...... {W.AC_RELATORIOS}");

            /*" -333- DISPLAY ' ' */
            _.Display($" ");

            /*" -334- DISPLAY 'DOCUMENTOS IMPRESSOS ........ ' AC-IMPRESSOS */
            _.Display($"DOCUMENTOS IMPRESSOS ........ {W.AC_IMPRESSOS}");

            /*" -335- DISPLAY ' ' */
            _.Display($" ");

            /*" -336- DISPLAY 'R.C.A.P. JA DEVOLVIDO ........' DP-RCAPS */
            _.Display($"R.C.A.P. JA DEVOLVIDO ........{W.DP_RCAPS}");

            /*" -337- DISPLAY 'AGENCIA NAO CADASTRADA .......' DP-AGENCIA */
            _.Display($"AGENCIA NAO CADASTRADA .......{W.DP_AGENCIA}");

            /*" -338- DISPLAY 'ESCRITORIO NAO CADASTRADO ....' DP-ESCRITORIO */
            _.Display($"ESCRITORIO NAO CADASTRADO ....{W.DP_ESCRITORIO}");

            /*" -339- DISPLAY 'FILIAL NAO CADASTRADA ........' DP-FILIAL */
            _.Display($"FILIAL NAO CADASTRADA ........{W.DP_FILIAL}");

            /*" -340- DISPLAY 'CLIENTE NAO CADASTRADO .......' DP-CLIENTE */
            _.Display($"CLIENTE NAO CADASTRADO .......{W.DP_CLIENTE}");

            /*" -341- DISPLAY 'ENDERECO NAO CADASTRADO ......' DP-ENDERECO */
            _.Display($"ENDERECO NAO CADASTRADO ......{W.DP_ENDERECO}");

            /*" -342- DISPLAY 'MOTIVO NAO CADASTRADO ........' DP-MOTIVO */
            _.Display($"MOTIVO NAO CADASTRADO ........{W.DP_MOTIVO}");

            /*" -343- DISPLAY 'USUARIO NAO CADASTRADO .......' DP-USUARIO */
            _.Display($"USUARIO NAO CADASTRADO .......{W.DP_USUARIO}");

            /*" -344- DISPLAY 'PRODUTO NAO CADASTRADO .......' DP-PRODUTO */
            _.Display($"PRODUTO NAO CADASTRADO .......{W.DP_PRODUTO}");

            /*" -345- DISPLAY ' ' */
            _.Display($" ");

            /*" -346- DISPLAY 'VA0460B - FIM NORMAL' . */
            _.Display($"VA0460B - FIM NORMAL");

            /*" -349- DISPLAY ' ' */
            _.Display($" ");

            /*" -349- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0050-00-INICIO-SECTION */
        private void R0050_00_INICIO_SECTION()
        {
            /*" -362- MOVE '0050' TO WNR-EXEC-SQL. */
            _.Move("0050", W.WABEND.WNR_EXEC_SQL);

            /*" -365- OPEN OUTPUT VA0460B1. */
            VA0460B1.Open(REG_VA0460B);

            /*" -368- PERFORM R0100-00-SELECT-V0SISTEMA. */

            R0100_00_SELECT_V0SISTEMA_SECTION();

            /*" -371- PERFORM R0150-00-SELECT-V0EMPRESA. */

            R0150_00_SELECT_V0EMPRESA_SECTION();

            /*" -371- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-SECTION */
        private void R0100_00_SELECT_V0SISTEMA_SECTION()
        {
            /*" -383- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", W.WABEND.WNR_EXEC_SQL);

            /*" -388- PERFORM R0100_00_SELECT_V0SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V0SISTEMA_DB_SELECT_1();

            /*" -391- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -392- DISPLAY 'R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)' */
                _.Display($"R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)");

                /*" -395- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -397- MOVE SISTEMAS-DATA-MOV-ABERTO TO WDATA-REL */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, W.WDATA_REL);

            /*" -398- MOVE WDAT-REL-DIA TO WDATA-DD-CABEC */
            _.Move(W.FILLER_0.WDAT_REL_DIA, W.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -399- MOVE WDAT-REL-MES TO WDATA-MM-CABEC */
            _.Move(W.FILLER_0.WDAT_REL_MES, W.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -400- MOVE WDAT-REL-ANO TO WDATA-AA-CABEC */
            _.Move(W.FILLER_0.WDAT_REL_ANO, W.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -403- MOVE WDATA-CABEC TO LC02-DATA. */
            _.Move(W.WDATA_CABEC, W.LC02.LC02_DATA);

            /*" -404- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), W.WS_TIME);

            /*" -405- MOVE WS-HH-TIME TO WHORA-HH-CABEC */
            _.Move(W.WS_TIME.WS_HH_TIME, W.WHORA_CABEC.WHORA_HH_CABEC);

            /*" -406- MOVE WS-MM-TIME TO WHORA-MM-CABEC */
            _.Move(W.WS_TIME.WS_MM_TIME, W.WHORA_CABEC.WHORA_MM_CABEC);

            /*" -407- MOVE WS-SS-TIME TO WHORA-SS-CABEC */
            _.Move(W.WS_TIME.WS_SS_TIME, W.WHORA_CABEC.WHORA_SS_CABEC);

            /*" -407- MOVE WHORA-CABEC TO LC03-HORA. */
            _.Move(W.WHORA_CABEC, W.LC03.LC03_HORA);

        }

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V0SISTEMA_DB_SELECT_1()
        {
            /*" -388- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VA' END-EXEC. */

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
        /*" R0150-00-SELECT-V0EMPRESA-SECTION */
        private void R0150_00_SELECT_V0EMPRESA_SECTION()
        {
            /*" -419- MOVE '0150' TO WNR-EXEC-SQL. */
            _.Move("0150", W.WABEND.WNR_EXEC_SQL);

            /*" -424- PERFORM R0150_00_SELECT_V0EMPRESA_DB_SELECT_1 */

            R0150_00_SELECT_V0EMPRESA_DB_SELECT_1();

            /*" -428- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -429- DISPLAY 'R0150-00 - PROBLEMAS NO SELECT(V0EMPRESA)   ' */
                _.Display($"R0150-00 - PROBLEMAS NO SELECT(V0EMPRESA)   ");

                /*" -432- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -434- MOVE EMPRESAS-NOME-EMPRESA TO LK-TITULO */
            _.Move(EMPRESAS.DCLEMPRESAS.EMPRESAS_NOME_EMPRESA, LK_LINK.LK_TITULO);

            /*" -436- CALL 'PROALN01' USING LK-LINK. */
            _.Call("PROALN01", LK_LINK);

            /*" -437- IF LK-RTCODE EQUAL ZEROS */

            if (LK_LINK.LK_RTCODE == 00)
            {

                /*" -438- MOVE LK-TITULO TO LC01-EMPRESA */
                _.Move(LK_LINK.LK_TITULO, W.LC01.LC01_EMPRESA);

                /*" -439- ELSE */
            }
            else
            {


                /*" -440- DISPLAY 'R0150-00 - PROBLEMAS NO CALL  (V0EMPRESA)   ' */
                _.Display($"R0150-00 - PROBLEMAS NO CALL  (V0EMPRESA)   ");

                /*" -440- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0150-00-SELECT-V0EMPRESA-DB-SELECT-1 */
        public void R0150_00_SELECT_V0EMPRESA_DB_SELECT_1()
        {
            /*" -424- EXEC SQL SELECT NOME_EMPRESA INTO :EMPRESAS-NOME-EMPRESA FROM SEGUROS.EMPRESAS WHERE COD_EMPRESA = 0 END-EXEC. */

            var r0150_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1 = new R0150_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0150_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1.Execute(r0150_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.EMPRESAS_NOME_EMPRESA, EMPRESAS.DCLEMPRESAS.EMPRESAS_NOME_EMPRESA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-DECLARE-V0HISTCOBVA-SECTION */
        private void R0300_00_DECLARE_V0HISTCOBVA_SECTION()
        {
            /*" -453- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", W.WABEND.WNR_EXEC_SQL);

            /*" -484- PERFORM R0300_00_DECLARE_V0HISTCOBVA_DB_DECLARE_1 */

            R0300_00_DECLARE_V0HISTCOBVA_DB_DECLARE_1();

            /*" -486- PERFORM R0300_00_DECLARE_V0HISTCOBVA_DB_OPEN_1 */

            R0300_00_DECLARE_V0HISTCOBVA_DB_OPEN_1();

            /*" -490- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -491- DISPLAY 'R0300-00 - PROBLEMAS DECLARE (COBHISVI)   ' */
                _.Display($"R0300-00 - PROBLEMAS DECLARE (COBHISVI)   ");

                /*" -491- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0300-00-DECLARE-V0HISTCOBVA-DB-DECLARE-1 */
        public void R0300_00_DECLARE_V0HISTCOBVA_DB_DECLARE_1()
        {
            /*" -484- EXEC SQL DECLARE V0HISTCOBVA CURSOR FOR SELECT A.NUM_CERTIFICADO , A.NUM_PARCELA , A.NUM_TITULO , A.PRM_TOTAL , A.OCORR_HISTORICO , A.COD_DEVOLUCAO , B.COD_CLIENTE , B.OCOREND , B.AGE_COBRANCA , B.DATA_QUITACAO , B.COD_USUARIO , C.NUM_APOLICE , C.COD_SUBGRUPO , C.COD_PRODUTO , C.RAMO , D.PREMIO_VG , D.PREMIO_AP FROM SEGUROS.COBER_HIST_VIDAZUL A, SEGUROS.PROPOSTAS_VA B, SEGUROS.PRODUTOS_VG C, SEGUROS.HIST_CONT_PARCELVA D WHERE A.SIT_REGISTRO = '4' AND B.NUM_CERTIFICADO = A.NUM_CERTIFICADO AND C.NUM_APOLICE = B.NUM_APOLICE AND C.COD_SUBGRUPO = B.COD_SUBGRUPO AND C.ESTR_COBR = 'MULT' AND D.NUM_CERTIFICADO = A.NUM_CERTIFICADO AND D.NUM_PARCELA = A.NUM_PARCELA AND D.OCORR_HISTORICO = A.OCORR_HISTORICO END-EXEC. */
            V0HISTCOBVA = new VA0460B_V0HISTCOBVA(false);
            string GetQuery_V0HISTCOBVA()
            {
                var query = @$"SELECT A.NUM_CERTIFICADO
							, 
							A.NUM_PARCELA
							, 
							A.NUM_TITULO
							, 
							A.PRM_TOTAL
							, 
							A.OCORR_HISTORICO
							, 
							A.COD_DEVOLUCAO
							, 
							B.COD_CLIENTE
							, 
							B.OCOREND
							, 
							B.AGE_COBRANCA
							, 
							B.DATA_QUITACAO
							, 
							B.COD_USUARIO
							, 
							C.NUM_APOLICE
							, 
							C.COD_SUBGRUPO
							, 
							C.COD_PRODUTO
							, 
							C.RAMO
							, 
							D.PREMIO_VG
							, 
							D.PREMIO_AP 
							FROM SEGUROS.COBER_HIST_VIDAZUL A
							, 
							SEGUROS.PROPOSTAS_VA B
							, 
							SEGUROS.PRODUTOS_VG C
							, 
							SEGUROS.HIST_CONT_PARCELVA D 
							WHERE A.SIT_REGISTRO = '4' 
							AND B.NUM_CERTIFICADO = A.NUM_CERTIFICADO 
							AND C.NUM_APOLICE = B.NUM_APOLICE 
							AND C.COD_SUBGRUPO = B.COD_SUBGRUPO 
							AND C.ESTR_COBR = 'MULT' 
							AND D.NUM_CERTIFICADO = A.NUM_CERTIFICADO 
							AND D.NUM_PARCELA = A.NUM_PARCELA 
							AND D.OCORR_HISTORICO = A.OCORR_HISTORICO";

                return query;
            }
            V0HISTCOBVA.GetQueryEvent += GetQuery_V0HISTCOBVA;

        }

        [StopWatch]
        /*" R0300-00-DECLARE-V0HISTCOBVA-DB-OPEN-1 */
        public void R0300_00_DECLARE_V0HISTCOBVA_DB_OPEN_1()
        {
            /*" -486- EXEC SQL OPEN V0HISTCOBVA END-EXEC. */

            V0HISTCOBVA.Open();

        }

        [StopWatch]
        /*" R3700-00-DECLARE-V0RCAPCOMP-DB-DECLARE-1 */
        public void R3700_00_DECLARE_V0RCAPCOMP_DB_DECLARE_1()
        {
            /*" -1218- EXEC SQL DECLARE V0RCAPCOMP CURSOR FOR SELECT COD_FONTE , NUM_RCAP , NUM_RCAP_COMPLEMEN , COD_OPERACAO , DATA_MOVIMENTO , HORA_OPERACAO , SIT_REGISTRO , BCO_AVISO , AGE_AVISO , NUM_AVISO_CREDITO , VAL_RCAP , DATA_RCAP , DATA_CADASTRAMENTO , SIT_CONTABIL , COD_EMPRESA FROM SEGUROS.RCAP_COMPLEMENTAR WHERE COD_FONTE = :RCAPCOMP-COD-FONTE AND NUM_RCAP = :RCAPCOMP-NUM-RCAP AND SIT_REGISTRO = '0' END-EXEC. */
            V0RCAPCOMP = new VA0460B_V0RCAPCOMP(true);
            string GetQuery_V0RCAPCOMP()
            {
                var query = @$"SELECT COD_FONTE
							, 
							NUM_RCAP
							, 
							NUM_RCAP_COMPLEMEN
							, 
							COD_OPERACAO
							, 
							DATA_MOVIMENTO
							, 
							HORA_OPERACAO
							, 
							SIT_REGISTRO
							, 
							BCO_AVISO
							, 
							AGE_AVISO
							, 
							NUM_AVISO_CREDITO
							, 
							VAL_RCAP
							, 
							DATA_RCAP
							, 
							DATA_CADASTRAMENTO
							, 
							SIT_CONTABIL
							, 
							COD_EMPRESA 
							FROM SEGUROS.RCAP_COMPLEMENTAR 
							WHERE COD_FONTE = '{RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_FONTE}' 
							AND NUM_RCAP = '{RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP}' 
							AND SIT_REGISTRO = '0'";

                return query;
            }
            V0RCAPCOMP.GetQueryEvent += GetQuery_V0RCAPCOMP;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0310-00-FETCH-V0HISTCOBVA-SECTION */
        private void R0310_00_FETCH_V0HISTCOBVA_SECTION()
        {
            /*" -504- MOVE '0310' TO WNR-EXEC-SQL. */
            _.Move("0310", W.WABEND.WNR_EXEC_SQL);

            /*" -522- PERFORM R0310_00_FETCH_V0HISTCOBVA_DB_FETCH_1 */

            R0310_00_FETCH_V0HISTCOBVA_DB_FETCH_1();

            /*" -526- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -526- PERFORM R0310_00_FETCH_V0HISTCOBVA_DB_CLOSE_1 */

                R0310_00_FETCH_V0HISTCOBVA_DB_CLOSE_1();

                /*" -528- MOVE 'S' TO WFIM-MOVIMENTO */
                _.Move("S", W.WFIM_MOVIMENTO);

                /*" -531- GO TO R0310-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/ //GOTO
                return;
            }


            /*" -532- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -533- DISPLAY 'R0310-00 - PROBLEMAS FETCH   (COBHISVI)   ' */
                _.Display($"R0310-00 - PROBLEMAS FETCH   (COBHISVI)   ");

                /*" -536- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -537- IF VIND-RAMO LESS ZEROS */

            if (VIND_RAMO < 00)
            {

                /*" -541- MOVE ZEROS TO PRODUVG-RAMO. */
                _.Move(0, PRODUVG.DCLPRODUTOS_VG.PRODUVG_RAMO);
            }


            /*" -545- COMPUTE COBHISVI-PRM-TOTAL = HISCONPA-PREMIO-VG + HISCONPA-PREMIO-AP. */
            COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_PRM_TOTAL.Value = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_VG + HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_AP;

            /*" -545- ADD 1 TO LD-COBHISVI. */
            W.LD_COBHISVI.Value = W.LD_COBHISVI + 1;

        }

        [StopWatch]
        /*" R0310-00-FETCH-V0HISTCOBVA-DB-FETCH-1 */
        public void R0310_00_FETCH_V0HISTCOBVA_DB_FETCH_1()
        {
            /*" -522- EXEC SQL FETCH V0HISTCOBVA INTO :COBHISVI-NUM-CERTIFICADO , :COBHISVI-NUM-PARCELA , :COBHISVI-NUM-TITULO , :COBHISVI-PRM-TOTAL , :COBHISVI-OCORR-HISTORICO , :COBHISVI-COD-DEVOLUCAO , :PROPOVA-COD-CLIENTE , :PROPOVA-OCOREND , :PROPOVA-AGE-COBRANCA , :PROPOVA-DATA-QUITACAO , :PROPOVA-COD-USUARIO , :PRODUVG-NUM-APOLICE , :PRODUVG-COD-SUBGRUPO , :PRODUVG-COD-PRODUTO , :PRODUVG-RAMO:VIND-RAMO , :HISCONPA-PREMIO-VG , :HISCONPA-PREMIO-AP END-EXEC. */

            if (V0HISTCOBVA.Fetch())
            {
                _.Move(V0HISTCOBVA.COBHISVI_NUM_CERTIFICADO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_CERTIFICADO);
                _.Move(V0HISTCOBVA.COBHISVI_NUM_PARCELA, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_PARCELA);
                _.Move(V0HISTCOBVA.COBHISVI_NUM_TITULO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO);
                _.Move(V0HISTCOBVA.COBHISVI_PRM_TOTAL, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_PRM_TOTAL);
                _.Move(V0HISTCOBVA.COBHISVI_OCORR_HISTORICO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_OCORR_HISTORICO);
                _.Move(V0HISTCOBVA.COBHISVI_COD_DEVOLUCAO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_COD_DEVOLUCAO);
                _.Move(V0HISTCOBVA.PROPOVA_COD_CLIENTE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE);
                _.Move(V0HISTCOBVA.PROPOVA_OCOREND, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCOREND);
                _.Move(V0HISTCOBVA.PROPOVA_AGE_COBRANCA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_AGE_COBRANCA);
                _.Move(V0HISTCOBVA.PROPOVA_DATA_QUITACAO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO);
                _.Move(V0HISTCOBVA.PROPOVA_COD_USUARIO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_USUARIO);
                _.Move(V0HISTCOBVA.PRODUVG_NUM_APOLICE, PRODUVG.DCLPRODUTOS_VG.PRODUVG_NUM_APOLICE);
                _.Move(V0HISTCOBVA.PRODUVG_COD_SUBGRUPO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_SUBGRUPO);
                _.Move(V0HISTCOBVA.PRODUVG_COD_PRODUTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO);
                _.Move(V0HISTCOBVA.PRODUVG_RAMO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_RAMO);
                _.Move(V0HISTCOBVA.VIND_RAMO, VIND_RAMO);
                _.Move(V0HISTCOBVA.HISCONPA_PREMIO_VG, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_VG);
                _.Move(V0HISTCOBVA.HISCONPA_PREMIO_AP, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_AP);
            }

        }

        [StopWatch]
        /*" R0310-00-FETCH-V0HISTCOBVA-DB-CLOSE-1 */
        public void R0310_00_FETCH_V0HISTCOBVA_DB_CLOSE_1()
        {
            /*" -526- EXEC SQL CLOSE V0HISTCOBVA END-EXEC */

            V0HISTCOBVA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/

        [StopWatch]
        /*" R0350-00-PROCESSA-V0HISTCOBVA-SECTION */
        private void R0350_00_PROCESSA_V0HISTCOBVA_SECTION()
        {
            /*" -558- MOVE '0350' TO WNR-EXEC-SQL. */
            _.Move("0350", W.WABEND.WNR_EXEC_SQL);

            /*" -564- MOVE SPACES TO LD01. */
            _.Move("", W.LD01);

            /*" -566- MOVE PROPOVA-COD-CLIENTE TO CLIENTES-COD-CLIENTE. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE, CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE);

            /*" -568- PERFORM R0380-00-SELECT-V0CLIENTES. */

            R0380_00_SELECT_V0CLIENTES_SECTION();

            /*" -569- IF CLIENTES-COD-CLIENTE EQUAL ZEROS */

            if (CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE == 00)
            {

                /*" -571- MOVE 'SEGURADO NAO CADASTRADO  ' TO LD01-DESCRICAO */
                _.Move("SEGURADO NAO CADASTRADO  ", W.LD01.LD01_DESCRICAO);

                /*" -573- ADD 1 TO DP-CLIENTE DP-DESPREZA */
                W.DP_CLIENTE.Value = W.DP_CLIENTE + 1;
                W.DP_DESPREZA.Value = W.DP_DESPREZA + 1;

                /*" -574- PERFORM R1500-00-IMPRIME-ERRO */

                R1500_00_IMPRIME_ERRO_SECTION();

                /*" -580- GO TO R0350-90-LEITURA. */

                R0350_90_LEITURA(); //GOTO
                return;
            }


            /*" -582- MOVE COBHISVI-NUM-TITULO TO RCAPS-NUM-TITULO. */
            _.Move(COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO, RCAPS.DCLRCAPS.RCAPS_NUM_TITULO);

            /*" -584- PERFORM R0400-00-SELECT-V0RCAP. */

            R0400_00_SELECT_V0RCAP_SECTION();

            /*" -585- IF RCAPS-COD-OPERACAO EQUAL 210 */

            if (RCAPS.DCLRCAPS.RCAPS_COD_OPERACAO == 210)
            {

                /*" -587- MOVE 'R.C.A.P. JA DEVOLVIDO    ' TO LD01-DESCRICAO */
                _.Move("R.C.A.P. JA DEVOLVIDO    ", W.LD01.LD01_DESCRICAO);

                /*" -589- ADD 1 TO DP-RCAPS DP-DESPREZA */
                W.DP_RCAPS.Value = W.DP_RCAPS + 1;
                W.DP_DESPREZA.Value = W.DP_DESPREZA + 1;

                /*" -590- PERFORM R1500-00-IMPRIME-ERRO */

                R1500_00_IMPRIME_ERRO_SECTION();

                /*" -596- GO TO R0350-90-LEITURA. */

                R0350_90_LEITURA(); //GOTO
                return;
            }


            /*" -598- MOVE PROPOVA-AGE-COBRANCA TO AGENCCEF-COD-AGENCIA. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_AGE_COBRANCA, AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_AGENCIA);

            /*" -600- PERFORM R0420-00-SELECT-V0AGENCIACEF. */

            R0420_00_SELECT_V0AGENCIACEF_SECTION();

            /*" -601- IF AGENCCEF-COD-AGENCIA EQUAL ZEROS */

            if (AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_AGENCIA == 00)
            {

                /*" -602- IF RCAPS-AGE-COBRANCA NOT EQUAL ZEROS */

                if (RCAPS.DCLRCAPS.RCAPS_AGE_COBRANCA != 00)
                {

                    /*" -604- MOVE RCAPS-AGE-COBRANCA TO AGENCCEF-COD-AGENCIA */
                    _.Move(RCAPS.DCLRCAPS.RCAPS_AGE_COBRANCA, AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_AGENCIA);

                    /*" -606- PERFORM R0420-00-SELECT-V0AGENCIACEF. */

                    R0420_00_SELECT_V0AGENCIACEF_SECTION();
                }

            }


            /*" -607- IF AGENCCEF-COD-AGENCIA EQUAL ZEROS */

            if (AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_AGENCIA == 00)
            {

                /*" -609- MOVE 'AGENCIA NAO CADASTRADA   ' TO LD01-DESCRICAO */
                _.Move("AGENCIA NAO CADASTRADA   ", W.LD01.LD01_DESCRICAO);

                /*" -611- ADD 1 TO DP-AGENCIA DP-DESPREZA */
                W.DP_AGENCIA.Value = W.DP_AGENCIA + 1;
                W.DP_DESPREZA.Value = W.DP_DESPREZA + 1;

                /*" -612- PERFORM R1500-00-IMPRIME-ERRO */

                R1500_00_IMPRIME_ERRO_SECTION();

                /*" -618- GO TO R0350-90-LEITURA. */

                R0350_90_LEITURA(); //GOTO
                return;
            }


            /*" -620- MOVE AGENCCEF-COD-ESCNEG TO ESCRINEG-COD-ESCNEG. */
            _.Move(AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_ESCNEG, ESCRINEG.DCLESCRITORIO_NEGOCIO.ESCRINEG_COD_ESCNEG);

            /*" -622- PERFORM R0440-00-SELECT-V0ESCNEG. */

            R0440_00_SELECT_V0ESCNEG_SECTION();

            /*" -623- IF ESCRINEG-COD-ESCNEG EQUAL ZEROS */

            if (ESCRINEG.DCLESCRITORIO_NEGOCIO.ESCRINEG_COD_ESCNEG == 00)
            {

                /*" -625- MOVE 'ESCRITORIO NAO CADASTRADO' TO LD01-DESCRICAO */
                _.Move("ESCRITORIO NAO CADASTRADO", W.LD01.LD01_DESCRICAO);

                /*" -627- ADD 1 TO DP-ESCRITORIO DP-DESPREZA */
                W.DP_ESCRITORIO.Value = W.DP_ESCRITORIO + 1;
                W.DP_DESPREZA.Value = W.DP_DESPREZA + 1;

                /*" -628- PERFORM R1500-00-IMPRIME-ERRO */

                R1500_00_IMPRIME_ERRO_SECTION();

                /*" -634- GO TO R0350-90-LEITURA. */

                R0350_90_LEITURA(); //GOTO
                return;
            }


            /*" -636- MOVE MALHACEF-COD-FONTE TO FONTES-COD-FONTE. */
            _.Move(MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE, FONTES.DCLFONTES.FONTES_COD_FONTE);

            /*" -638- PERFORM R0460-00-SELECT-V0FONTE. */

            R0460_00_SELECT_V0FONTE_SECTION();

            /*" -639- IF FONTES-COD-FONTE EQUAL ZEROS */

            if (FONTES.DCLFONTES.FONTES_COD_FONTE == 00)
            {

                /*" -641- MOVE 'FILIAL NAO CADASTRADA    ' TO LD01-DESCRICAO */
                _.Move("FILIAL NAO CADASTRADA    ", W.LD01.LD01_DESCRICAO);

                /*" -643- ADD 1 TO DP-FILIAL DP-DESPREZA */
                W.DP_FILIAL.Value = W.DP_FILIAL + 1;
                W.DP_DESPREZA.Value = W.DP_DESPREZA + 1;

                /*" -644- PERFORM R1500-00-IMPRIME-ERRO */

                R1500_00_IMPRIME_ERRO_SECTION();

                /*" -650- GO TO R0350-90-LEITURA. */

                R0350_90_LEITURA(); //GOTO
                return;
            }


            /*" -652- MOVE PROPOVA-COD-CLIENTE TO ENDERECO-COD-CLIENTE. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE, ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE);

            /*" -654- MOVE PROPOVA-OCOREND TO ENDERECO-OCORR-ENDERECO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCOREND, ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO);

            /*" -656- PERFORM R0500-00-SELECT-V0ENDERECOS. */

            R0500_00_SELECT_V0ENDERECOS_SECTION();

            /*" -657- IF ENDERECO-COD-CLIENTE EQUAL ZEROS */

            if (ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE == 00)
            {

                /*" -659- MOVE 'ENDERECO NAO CADASTRADO  ' TO LD01-DESCRICAO */
                _.Move("ENDERECO NAO CADASTRADO  ", W.LD01.LD01_DESCRICAO);

                /*" -661- ADD 1 TO DP-ENDERECO DP-DESPREZA */
                W.DP_ENDERECO.Value = W.DP_ENDERECO + 1;
                W.DP_DESPREZA.Value = W.DP_DESPREZA + 1;

                /*" -662- PERFORM R1500-00-IMPRIME-ERRO */

                R1500_00_IMPRIME_ERRO_SECTION();

                /*" -668- GO TO R0350-90-LEITURA. */

                R0350_90_LEITURA(); //GOTO
                return;
            }


            /*" -670- MOVE COBHISVI-COD-DEVOLUCAO TO DEVOLVID-COD-DEVOLUCAO. */
            _.Move(COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_COD_DEVOLUCAO, DEVOLVID.DCLDEVOLUCAO_VIDAZUL.DEVOLVID_COD_DEVOLUCAO);

            /*" -672- PERFORM R0520-00-SELECT-V0DEVOLUCAOVA. */

            R0520_00_SELECT_V0DEVOLUCAOVA_SECTION();

            /*" -673- IF DEVOLVID-COD-DEVOLUCAO EQUAL ZEROS */

            if (DEVOLVID.DCLDEVOLUCAO_VIDAZUL.DEVOLVID_COD_DEVOLUCAO == 00)
            {

                /*" -675- MOVE 'MOTIVO NAO CADASTRADO    ' TO LD01-DESCRICAO */
                _.Move("MOTIVO NAO CADASTRADO    ", W.LD01.LD01_DESCRICAO);

                /*" -677- ADD 1 TO DP-MOTIVO DP-DESPREZA */
                W.DP_MOTIVO.Value = W.DP_MOTIVO + 1;
                W.DP_DESPREZA.Value = W.DP_DESPREZA + 1;

                /*" -678- PERFORM R1500-00-IMPRIME-ERRO */

                R1500_00_IMPRIME_ERRO_SECTION();

                /*" -684- GO TO R0350-90-LEITURA. */

                R0350_90_LEITURA(); //GOTO
                return;
            }


            /*" -685- PERFORM R0530-00-SELECT-V0HISTCONTAVA. */

            R0530_00_SELECT_V0HISTCONTAVA_SECTION();

            /*" -689- MOVE HISLANCT-COD-USUARIO TO USUARIOS-COD-USUARIO. */
            _.Move(HISLANCT.DCLHIST_LANC_CTA.HISLANCT_COD_USUARIO, USUARIOS.DCLUSUARIOS.USUARIOS_COD_USUARIO);

            /*" -691- PERFORM R0540-00-SELECT-V0USUARIOS. */

            R0540_00_SELECT_V0USUARIOS_SECTION();

            /*" -693- IF USUARIOS-COD-USUARIO EQUAL SPACES */

            if (USUARIOS.DCLUSUARIOS.USUARIOS_COD_USUARIO.IsEmpty())
            {

                /*" -695- MOVE 'JOSENL' TO USUARIOS-COD-USUARIO */
                _.Move("JOSENL", USUARIOS.DCLUSUARIOS.USUARIOS_COD_USUARIO);

                /*" -697- PERFORM R0540-00-SELECT-V0USUARIOS. */

                R0540_00_SELECT_V0USUARIOS_SECTION();
            }


            /*" -698- IF USUARIOS-COD-USUARIO EQUAL SPACES */

            if (USUARIOS.DCLUSUARIOS.USUARIOS_COD_USUARIO.IsEmpty())
            {

                /*" -700- MOVE 'USUARIO NAO CADASTRADO   ' TO LD01-DESCRICAO */
                _.Move("USUARIO NAO CADASTRADO   ", W.LD01.LD01_DESCRICAO);

                /*" -702- ADD 1 TO DP-USUARIO DP-DESPREZA */
                W.DP_USUARIO.Value = W.DP_USUARIO + 1;
                W.DP_DESPREZA.Value = W.DP_DESPREZA + 1;

                /*" -703- PERFORM R1500-00-IMPRIME-ERRO */

                R1500_00_IMPRIME_ERRO_SECTION();

                /*" -709- GO TO R0350-90-LEITURA. */

                R0350_90_LEITURA(); //GOTO
                return;
            }


            /*" -711- MOVE PRODUVG-COD-PRODUTO TO PRODUTO-COD-PRODUTO. */
            _.Move(PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO, PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO);

            /*" -713- PERFORM R0560-00-SELECT-V0PRODUTO */

            R0560_00_SELECT_V0PRODUTO_SECTION();

            /*" -714- IF PRODUTO-COD-PRODUTO EQUAL ZEROS */

            if (PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO == 00)
            {

                /*" -716- MOVE 'PRODUTO NAO CADASTRADO   ' TO LD01-DESCRICAO */
                _.Move("PRODUTO NAO CADASTRADO   ", W.LD01.LD01_DESCRICAO);

                /*" -718- ADD 1 TO DP-PRODUTO DP-DESPREZA */
                W.DP_PRODUTO.Value = W.DP_PRODUTO + 1;
                W.DP_DESPREZA.Value = W.DP_DESPREZA + 1;

                /*" -719- PERFORM R1500-00-IMPRIME-ERRO */

                R1500_00_IMPRIME_ERRO_SECTION();

                /*" -725- GO TO R0350-90-LEITURA. */

                R0350_90_LEITURA(); //GOTO
                return;
            }


            /*" -726- MOVE RCAPS-COD-FONTE TO AUX-COD-FONTE */
            _.Move(RCAPS.DCLRCAPS.RCAPS_COD_FONTE, W.AUX_COD_FONTE);

            /*" -727- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), W.WS_TIME);

            /*" -728- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_5.WTIME_DAYR.WTIME_HORA);

            /*" -729- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", W.FILLER_5.WTIME_DAYR.WTIME_2PT1);

            /*" -730- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_5.WTIME_DAYR.WTIME_MINU);

            /*" -731- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", W.FILLER_5.WTIME_DAYR.WTIME_2PT2);

            /*" -732- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_5.WTIME_DAYR.WTIME_SEGU);

            /*" -738- MOVE WTIME-DAYR TO AUX-HORAOPER. */
            _.Move(W.FILLER_5.WTIME_DAYR, W.AUX_HORAOPER);

            /*" -740- IF RCAPS-SIT-REGISTRO EQUAL '0' OR '2' */

            if (RCAPS.DCLRCAPS.RCAPS_SIT_REGISTRO.In("0", "2"))
            {

                /*" -742- MOVE RCAPS-SIT-REGISTRO TO AUX-SITUACAO */
                _.Move(RCAPS.DCLRCAPS.RCAPS_SIT_REGISTRO, W.AUX_SITUACAO);

                /*" -743- MOVE 1205 TO AUX-COD-DESPESA */
                _.Move(1205, W.AUX_COD_DESPESA);

                /*" -744- PERFORM R3500-00-TRATA-RCAP */

                R3500_00_TRATA_RCAP_SECTION();

                /*" -748- ELSE */
            }
            else
            {


                /*" -749- IF RCAPS-SIT-REGISTRO EQUAL '1' */

                if (RCAPS.DCLRCAPS.RCAPS_SIT_REGISTRO == "1")
                {

                    /*" -750- MOVE 1205 TO AUX-COD-DESPESA */
                    _.Move(1205, W.AUX_COD_DESPESA);

                    /*" -754- ELSE */
                }
                else
                {


                    /*" -760- MOVE 1208 TO AUX-COD-DESPESA. */
                    _.Move(1208, W.AUX_COD_DESPESA);
                }

            }


            /*" -770- PERFORM R5000-00-INSERT-V0RELATORIOS. */

            R5000_00_INSERT_V0RELATORIOS_SECTION();

            /*" -770- PERFORM R5500-00-UPDATE-V0HISTCOBVA. */

            R5500_00_UPDATE_V0HISTCOBVA_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0350_90_LEITURA */

            R0350_90_LEITURA();

        }

        [StopWatch]
        /*" R0350-90-LEITURA */
        private void R0350_90_LEITURA(bool isPerform = false)
        {
            /*" -775- PERFORM R0310-00-FETCH-V0HISTCOBVA. */

            R0310_00_FETCH_V0HISTCOBVA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_99_SAIDA*/

        [StopWatch]
        /*" R0380-00-SELECT-V0CLIENTES-SECTION */
        private void R0380_00_SELECT_V0CLIENTES_SECTION()
        {
            /*" -786- MOVE '0380' TO WNR-EXEC-SQL. */
            _.Move("0380", W.WABEND.WNR_EXEC_SQL);

            /*" -793- PERFORM R0380_00_SELECT_V0CLIENTES_DB_SELECT_1 */

            R0380_00_SELECT_V0CLIENTES_DB_SELECT_1();

            /*" -797- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -799- MOVE ZEROS TO CLIENTES-COD-CLIENTE */
                _.Move(0, CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE);

                /*" -800- MOVE SPACES TO CLIENTES-NOME-RAZAO. */
                _.Move("", CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
            }


        }

        [StopWatch]
        /*" R0380-00-SELECT-V0CLIENTES-DB-SELECT-1 */
        public void R0380_00_SELECT_V0CLIENTES_DB_SELECT_1()
        {
            /*" -793- EXEC SQL SELECT COD_CLIENTE , NOME_RAZAO INTO :CLIENTES-COD-CLIENTE , :CLIENTES-NOME-RAZAO FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :CLIENTES-COD-CLIENTE END-EXEC. */

            var r0380_00_SELECT_V0CLIENTES_DB_SELECT_1_Query1 = new R0380_00_SELECT_V0CLIENTES_DB_SELECT_1_Query1()
            {
                CLIENTES_COD_CLIENTE = CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE.ToString(),
            };

            var executed_1 = R0380_00_SELECT_V0CLIENTES_DB_SELECT_1_Query1.Execute(r0380_00_SELECT_V0CLIENTES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_COD_CLIENTE, CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE);
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0380_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-SELECT-V0RCAP-SECTION */
        private void R0400_00_SELECT_V0RCAP_SECTION()
        {
            /*" -812- MOVE '0400' TO WNR-EXEC-SQL. */
            _.Move("0400", W.WABEND.WNR_EXEC_SQL);

            /*" -831- PERFORM R0400_00_SELECT_V0RCAP_DB_SELECT_1 */

            R0400_00_SELECT_V0RCAP_DB_SELECT_1();

            /*" -835- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -842- MOVE ZEROS TO RCAPS-COD-FONTE RCAPS-NUM-RCAP RCAPS-VAL-RCAP RCAPS-COD-OPERACAO RCAPS-CODIGO-PRODUTO RCAPS-AGE-COBRANCA */
                _.Move(0, RCAPS.DCLRCAPS.RCAPS_COD_FONTE, RCAPS.DCLRCAPS.RCAPS_NUM_RCAP, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP, RCAPS.DCLRCAPS.RCAPS_COD_OPERACAO, RCAPS.DCLRCAPS.RCAPS_CODIGO_PRODUTO, RCAPS.DCLRCAPS.RCAPS_AGE_COBRANCA);

                /*" -844- MOVE SPACES TO RCAPS-SIT-REGISTRO */
                _.Move("", RCAPS.DCLRCAPS.RCAPS_SIT_REGISTRO);

                /*" -847- GO TO R0400-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/ //GOTO
                return;
            }


            /*" -848- IF VIND-CODPRODU LESS ZEROS */

            if (VIND_CODPRODU < 00)
            {

                /*" -851- MOVE ZEROS TO RCAPS-CODIGO-PRODUTO. */
                _.Move(0, RCAPS.DCLRCAPS.RCAPS_CODIGO_PRODUTO);
            }


            /*" -852- IF VIND-AGECOBR LESS ZEROS */

            if (VIND_AGECOBR < 00)
            {

                /*" -853- MOVE ZEROS TO RCAPS-AGE-COBRANCA. */
                _.Move(0, RCAPS.DCLRCAPS.RCAPS_AGE_COBRANCA);
            }


        }

        [StopWatch]
        /*" R0400-00-SELECT-V0RCAP-DB-SELECT-1 */
        public void R0400_00_SELECT_V0RCAP_DB_SELECT_1()
        {
            /*" -831- EXEC SQL SELECT COD_FONTE , NUM_RCAP , VAL_RCAP , VAL_RCAP_PRINCIPAL , SIT_REGISTRO , COD_OPERACAO , CODIGO_PRODUTO , AGE_COBRANCA INTO :RCAPS-COD-FONTE , :RCAPS-NUM-RCAP , :RCAPS-VAL-RCAP , :RCAPS-VAL-RCAP-PRINCIPAL, :RCAPS-SIT-REGISTRO , :RCAPS-COD-OPERACAO , :RCAPS-CODIGO-PRODUTO:VIND-CODPRODU , :RCAPS-AGE-COBRANCA:VIND-AGECOBR FROM SEGUROS.RCAPS WHERE NUM_TITULO = :RCAPS-NUM-TITULO END-EXEC. */

            var r0400_00_SELECT_V0RCAP_DB_SELECT_1_Query1 = new R0400_00_SELECT_V0RCAP_DB_SELECT_1_Query1()
            {
                RCAPS_NUM_TITULO = RCAPS.DCLRCAPS.RCAPS_NUM_TITULO.ToString(),
            };

            var executed_1 = R0400_00_SELECT_V0RCAP_DB_SELECT_1_Query1.Execute(r0400_00_SELECT_V0RCAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_COD_FONTE, RCAPS.DCLRCAPS.RCAPS_COD_FONTE);
                _.Move(executed_1.RCAPS_NUM_RCAP, RCAPS.DCLRCAPS.RCAPS_NUM_RCAP);
                _.Move(executed_1.RCAPS_VAL_RCAP, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP);
                _.Move(executed_1.RCAPS_VAL_RCAP_PRINCIPAL, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP_PRINCIPAL);
                _.Move(executed_1.RCAPS_SIT_REGISTRO, RCAPS.DCLRCAPS.RCAPS_SIT_REGISTRO);
                _.Move(executed_1.RCAPS_COD_OPERACAO, RCAPS.DCLRCAPS.RCAPS_COD_OPERACAO);
                _.Move(executed_1.RCAPS_CODIGO_PRODUTO, RCAPS.DCLRCAPS.RCAPS_CODIGO_PRODUTO);
                _.Move(executed_1.VIND_CODPRODU, VIND_CODPRODU);
                _.Move(executed_1.RCAPS_AGE_COBRANCA, RCAPS.DCLRCAPS.RCAPS_AGE_COBRANCA);
                _.Move(executed_1.VIND_AGECOBR, VIND_AGECOBR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0420-00-SELECT-V0AGENCIACEF-SECTION */
        private void R0420_00_SELECT_V0AGENCIACEF_SECTION()
        {
            /*" -865- MOVE '0420' TO WNR-EXEC-SQL. */
            _.Move("0420", W.WABEND.WNR_EXEC_SQL);

            /*" -876- PERFORM R0420_00_SELECT_V0AGENCIACEF_DB_SELECT_1 */

            R0420_00_SELECT_V0AGENCIACEF_DB_SELECT_1();

            /*" -880- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -883- MOVE ZEROS TO AGENCCEF-COD-AGENCIA AGENCCEF-COD-ESCNEG MALHACEF-COD-FONTE. */
                _.Move(0, AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_AGENCIA, AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_ESCNEG, MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE);
            }


        }

        [StopWatch]
        /*" R0420-00-SELECT-V0AGENCIACEF-DB-SELECT-1 */
        public void R0420_00_SELECT_V0AGENCIACEF_DB_SELECT_1()
        {
            /*" -876- EXEC SQL SELECT A.COD_AGENCIA , A.COD_ESCNEG , B.COD_FONTE INTO :AGENCCEF-COD-AGENCIA , :AGENCCEF-COD-ESCNEG , :MALHACEF-COD-FONTE FROM SEGUROS.AGENCIAS_CEF A, SEGUROS.MALHA_CEF B WHERE A.COD_AGENCIA = :AGENCCEF-COD-AGENCIA AND A.COD_SUREG = B.COD_SUREG END-EXEC. */

            var r0420_00_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1 = new R0420_00_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1()
            {
                AGENCCEF_COD_AGENCIA = AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_AGENCIA.ToString(),
            };

            var executed_1 = R0420_00_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1.Execute(r0420_00_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AGENCCEF_COD_AGENCIA, AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_AGENCIA);
                _.Move(executed_1.AGENCCEF_COD_ESCNEG, AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_ESCNEG);
                _.Move(executed_1.MALHACEF_COD_FONTE, MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0420_99_SAIDA*/

        [StopWatch]
        /*" R0440-00-SELECT-V0ESCNEG-SECTION */
        private void R0440_00_SELECT_V0ESCNEG_SECTION()
        {
            /*" -895- MOVE '0440' TO WNR-EXEC-SQL. */
            _.Move("0440", W.WABEND.WNR_EXEC_SQL);

            /*" -900- PERFORM R0440_00_SELECT_V0ESCNEG_DB_SELECT_1 */

            R0440_00_SELECT_V0ESCNEG_DB_SELECT_1();

            /*" -904- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -905- MOVE ZEROS TO ESCRINEG-COD-ESCNEG. */
                _.Move(0, ESCRINEG.DCLESCRITORIO_NEGOCIO.ESCRINEG_COD_ESCNEG);
            }


        }

        [StopWatch]
        /*" R0440-00-SELECT-V0ESCNEG-DB-SELECT-1 */
        public void R0440_00_SELECT_V0ESCNEG_DB_SELECT_1()
        {
            /*" -900- EXEC SQL SELECT COD_ESCNEG INTO :ESCRINEG-COD-ESCNEG FROM SEGUROS.ESCRITORIO_NEGOCIO WHERE COD_ESCNEG = :ESCRINEG-COD-ESCNEG END-EXEC. */

            var r0440_00_SELECT_V0ESCNEG_DB_SELECT_1_Query1 = new R0440_00_SELECT_V0ESCNEG_DB_SELECT_1_Query1()
            {
                ESCRINEG_COD_ESCNEG = ESCRINEG.DCLESCRITORIO_NEGOCIO.ESCRINEG_COD_ESCNEG.ToString(),
            };

            var executed_1 = R0440_00_SELECT_V0ESCNEG_DB_SELECT_1_Query1.Execute(r0440_00_SELECT_V0ESCNEG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ESCRINEG_COD_ESCNEG, ESCRINEG.DCLESCRITORIO_NEGOCIO.ESCRINEG_COD_ESCNEG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0440_99_SAIDA*/

        [StopWatch]
        /*" R0460-00-SELECT-V0FONTE-SECTION */
        private void R0460_00_SELECT_V0FONTE_SECTION()
        {
            /*" -917- MOVE '0460' TO WNR-EXEC-SQL. */
            _.Move("0460", W.WABEND.WNR_EXEC_SQL);

            /*" -922- PERFORM R0460_00_SELECT_V0FONTE_DB_SELECT_1 */

            R0460_00_SELECT_V0FONTE_DB_SELECT_1();

            /*" -926- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -927- MOVE ZEROS TO FONTES-COD-FONTE. */
                _.Move(0, FONTES.DCLFONTES.FONTES_COD_FONTE);
            }


        }

        [StopWatch]
        /*" R0460-00-SELECT-V0FONTE-DB-SELECT-1 */
        public void R0460_00_SELECT_V0FONTE_DB_SELECT_1()
        {
            /*" -922- EXEC SQL SELECT COD_FONTE INTO :FONTES-COD-FONTE FROM SEGUROS.FONTES WHERE COD_FONTE = :FONTES-COD-FONTE END-EXEC. */

            var r0460_00_SELECT_V0FONTE_DB_SELECT_1_Query1 = new R0460_00_SELECT_V0FONTE_DB_SELECT_1_Query1()
            {
                FONTES_COD_FONTE = FONTES.DCLFONTES.FONTES_COD_FONTE.ToString(),
            };

            var executed_1 = R0460_00_SELECT_V0FONTE_DB_SELECT_1_Query1.Execute(r0460_00_SELECT_V0FONTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FONTES_COD_FONTE, FONTES.DCLFONTES.FONTES_COD_FONTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0460_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-SELECT-V0ENDERECOS-SECTION */
        private void R0500_00_SELECT_V0ENDERECOS_SECTION()
        {
            /*" -940- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", W.WABEND.WNR_EXEC_SQL);

            /*" -947- PERFORM R0500_00_SELECT_V0ENDERECOS_DB_SELECT_1 */

            R0500_00_SELECT_V0ENDERECOS_DB_SELECT_1();

            /*" -951- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -953- MOVE ZEROS TO ENDERECO-COD-CLIENTE */
                _.Move(0, ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE);

                /*" -954- ELSE */
            }
            else
            {


                /*" -955- IF VIND-CODENDER LESS ZEROS */

                if (VIND_CODENDER < 00)
                {

                    /*" -956- MOVE ZEROS TO ENDERECO-COD-CLIENTE. */
                    _.Move(0, ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE);
                }

            }


        }

        [StopWatch]
        /*" R0500-00-SELECT-V0ENDERECOS-DB-SELECT-1 */
        public void R0500_00_SELECT_V0ENDERECOS_DB_SELECT_1()
        {
            /*" -947- EXEC SQL SELECT MAX(COD_ENDERECO) INTO :ENDERECO-COD-ENDERECO:VIND-CODENDER FROM SEGUROS.ENDERECOS WHERE COD_CLIENTE = :ENDERECO-COD-CLIENTE AND OCORR_ENDERECO = :ENDERECO-OCORR-ENDERECO END-EXEC. */

            var r0500_00_SELECT_V0ENDERECOS_DB_SELECT_1_Query1 = new R0500_00_SELECT_V0ENDERECOS_DB_SELECT_1_Query1()
            {
                ENDERECO_OCORR_ENDERECO = ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO.ToString(),
                ENDERECO_COD_CLIENTE = ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE.ToString(),
            };

            var executed_1 = R0500_00_SELECT_V0ENDERECOS_DB_SELECT_1_Query1.Execute(r0500_00_SELECT_V0ENDERECOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDERECO_COD_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_COD_ENDERECO);
                _.Move(executed_1.VIND_CODENDER, VIND_CODENDER);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0520-00-SELECT-V0DEVOLUCAOVA-SECTION */
        private void R0520_00_SELECT_V0DEVOLUCAOVA_SECTION()
        {
            /*" -969- MOVE '0520' TO WNR-EXEC-SQL. */
            _.Move("0520", W.WABEND.WNR_EXEC_SQL);

            /*" -975- PERFORM R0520_00_SELECT_V0DEVOLUCAOVA_DB_SELECT_1 */

            R0520_00_SELECT_V0DEVOLUCAOVA_DB_SELECT_1();

            /*" -979- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -980- MOVE ZEROS TO DEVOLVID-COD-DEVOLUCAO. */
                _.Move(0, DEVOLVID.DCLDEVOLUCAO_VIDAZUL.DEVOLVID_COD_DEVOLUCAO);
            }


        }

        [StopWatch]
        /*" R0520-00-SELECT-V0DEVOLUCAOVA-DB-SELECT-1 */
        public void R0520_00_SELECT_V0DEVOLUCAOVA_DB_SELECT_1()
        {
            /*" -975- EXEC SQL SELECT COD_DEVOLUCAO INTO :DEVOLVID-COD-DEVOLUCAO FROM SEGUROS.DEVOLUCAO_VIDAZUL WHERE COD_DEVOLUCAO = :DEVOLVID-COD-DEVOLUCAO END-EXEC. */

            var r0520_00_SELECT_V0DEVOLUCAOVA_DB_SELECT_1_Query1 = new R0520_00_SELECT_V0DEVOLUCAOVA_DB_SELECT_1_Query1()
            {
                DEVOLVID_COD_DEVOLUCAO = DEVOLVID.DCLDEVOLUCAO_VIDAZUL.DEVOLVID_COD_DEVOLUCAO.ToString(),
            };

            var executed_1 = R0520_00_SELECT_V0DEVOLUCAOVA_DB_SELECT_1_Query1.Execute(r0520_00_SELECT_V0DEVOLUCAOVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.DEVOLVID_COD_DEVOLUCAO, DEVOLVID.DCLDEVOLUCAO_VIDAZUL.DEVOLVID_COD_DEVOLUCAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0520_99_SAIDA*/

        [StopWatch]
        /*" R0530-00-SELECT-V0HISTCONTAVA-SECTION */
        private void R0530_00_SELECT_V0HISTCONTAVA_SECTION()
        {
            /*" -993- MOVE '0530' TO WNR-EXEC-SQL. */
            _.Move("0530", W.WABEND.WNR_EXEC_SQL);

            /*" -1004- PERFORM R0530_00_SELECT_V0HISTCONTAVA_DB_SELECT_1 */

            R0530_00_SELECT_V0HISTCONTAVA_DB_SELECT_1();

            /*" -1008- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1011- MOVE SPACES TO HISLANCT-COD-USUARIO. */
                _.Move("", HISLANCT.DCLHIST_LANC_CTA.HISLANCT_COD_USUARIO);
            }


        }

        [StopWatch]
        /*" R0530-00-SELECT-V0HISTCONTAVA-DB-SELECT-1 */
        public void R0530_00_SELECT_V0HISTCONTAVA_DB_SELECT_1()
        {
            /*" -1004- EXEC SQL SELECT A.COD_USUARIO INTO :HISLANCT-COD-USUARIO FROM SEGUROS.HIST_LANC_CTA A, SEGUROS.PARCELAS_VIDAZUL B WHERE A.NUM_CERTIFICADO = :COBHISVI-NUM-CERTIFICADO AND A.NUM_PARCELA = :COBHISVI-NUM-PARCELA AND A.NUM_CERTIFICADO = B.NUM_CERTIFICADO AND A.NUM_PARCELA = B.NUM_PARCELA AND A.OCORR_HISTORICOCTA = B.OCORR_HISTORICO END-EXEC. */

            var r0530_00_SELECT_V0HISTCONTAVA_DB_SELECT_1_Query1 = new R0530_00_SELECT_V0HISTCONTAVA_DB_SELECT_1_Query1()
            {
                COBHISVI_NUM_CERTIFICADO = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_CERTIFICADO.ToString(),
                COBHISVI_NUM_PARCELA = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_PARCELA.ToString(),
            };

            var executed_1 = R0530_00_SELECT_V0HISTCONTAVA_DB_SELECT_1_Query1.Execute(r0530_00_SELECT_V0HISTCONTAVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISLANCT_COD_USUARIO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_COD_USUARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0530_99_SAIDA*/

        [StopWatch]
        /*" R0540-00-SELECT-V0USUARIOS-SECTION */
        private void R0540_00_SELECT_V0USUARIOS_SECTION()
        {
            /*" -1022- MOVE '0540' TO WNR-EXEC-SQL. */
            _.Move("0540", W.WABEND.WNR_EXEC_SQL);

            /*" -1028- PERFORM R0540_00_SELECT_V0USUARIOS_DB_SELECT_1 */

            R0540_00_SELECT_V0USUARIOS_DB_SELECT_1();

            /*" -1032- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1033- MOVE SPACES TO USUARIOS-COD-USUARIO. */
                _.Move("", USUARIOS.DCLUSUARIOS.USUARIOS_COD_USUARIO);
            }


        }

        [StopWatch]
        /*" R0540-00-SELECT-V0USUARIOS-DB-SELECT-1 */
        public void R0540_00_SELECT_V0USUARIOS_DB_SELECT_1()
        {
            /*" -1028- EXEC SQL SELECT COD_USUARIO INTO :USUARIOS-COD-USUARIO FROM SEGUROS.USUARIOS WHERE COD_USUARIO = :USUARIOS-COD-USUARIO END-EXEC. */

            var r0540_00_SELECT_V0USUARIOS_DB_SELECT_1_Query1 = new R0540_00_SELECT_V0USUARIOS_DB_SELECT_1_Query1()
            {
                USUARIOS_COD_USUARIO = USUARIOS.DCLUSUARIOS.USUARIOS_COD_USUARIO.ToString(),
            };

            var executed_1 = R0540_00_SELECT_V0USUARIOS_DB_SELECT_1_Query1.Execute(r0540_00_SELECT_V0USUARIOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.USUARIOS_COD_USUARIO, USUARIOS.DCLUSUARIOS.USUARIOS_COD_USUARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0540_99_SAIDA*/

        [StopWatch]
        /*" R0560-00-SELECT-V0PRODUTO-SECTION */
        private void R0560_00_SELECT_V0PRODUTO_SECTION()
        {
            /*" -1045- MOVE '0560' TO WNR-EXEC-SQL. */
            _.Move("0560", W.WABEND.WNR_EXEC_SQL);

            /*" -1050- PERFORM R0560_00_SELECT_V0PRODUTO_DB_SELECT_1 */

            R0560_00_SELECT_V0PRODUTO_DB_SELECT_1();

            /*" -1053- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1054- MOVE ZEROS TO PRODUTO-COD-PRODUTO. */
                _.Move(0, PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO);
            }


        }

        [StopWatch]
        /*" R0560-00-SELECT-V0PRODUTO-DB-SELECT-1 */
        public void R0560_00_SELECT_V0PRODUTO_DB_SELECT_1()
        {
            /*" -1050- EXEC SQL SELECT RAMO_EMISSOR INTO :PRODUTO-RAMO-EMISSOR FROM SEGUROS.PRODUTO WHERE COD_PRODUTO = :PRODUTO-COD-PRODUTO END-EXEC. */

            var r0560_00_SELECT_V0PRODUTO_DB_SELECT_1_Query1 = new R0560_00_SELECT_V0PRODUTO_DB_SELECT_1_Query1()
            {
                PRODUTO_COD_PRODUTO = PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO.ToString(),
            };

            var executed_1 = R0560_00_SELECT_V0PRODUTO_DB_SELECT_1_Query1.Execute(r0560_00_SELECT_V0PRODUTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUTO_RAMO_EMISSOR, PRODUTO.DCLPRODUTO.PRODUTO_RAMO_EMISSOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0560_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-IMPRIME-ERRO-SECTION */
        private void R1500_00_IMPRIME_ERRO_SECTION()
        {
            /*" -1067- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", W.WABEND.WNR_EXEC_SQL);

            /*" -1069- MOVE COBHISVI-NUM-CERTIFICADO TO LD01-NRCERTIF. */
            _.Move(COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_CERTIFICADO, W.LD01.LD01_NRCERTIF);

            /*" -1071- MOVE COBHISVI-NUM-TITULO TO LD01-NRTIT. */
            _.Move(COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO, W.LD01.LD01_NRTIT);

            /*" -1073- MOVE COBHISVI-NUM-PARCELA TO LD01-NRPARCEL. */
            _.Move(COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_PARCELA, W.LD01.LD01_NRPARCEL);

            /*" -1076- MOVE COBHISVI-PRM-TOTAL TO LD01-VALOR. */
            _.Move(COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_PRM_TOTAL, W.LD01.LD01_VALOR);

            /*" -1079- MOVE CLIENTES-NOME-RAZAO TO LD01-SEGURADO. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, W.LD01.LD01_SEGURADO);

            /*" -1081- MOVE PROPOVA-DATA-QUITACAO TO WDATA-REL */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO, W.WDATA_REL);

            /*" -1082- MOVE WDAT-REL-DIA TO WDATA-DD-CABEC */
            _.Move(W.FILLER_0.WDAT_REL_DIA, W.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -1083- MOVE WDAT-REL-MES TO WDATA-MM-CABEC */
            _.Move(W.FILLER_0.WDAT_REL_MES, W.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -1084- MOVE WDAT-REL-ANO TO WDATA-AA-CABEC */
            _.Move(W.FILLER_0.WDAT_REL_ANO, W.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -1087- MOVE WDATA-CABEC TO LD01-QUITACAO. */
            _.Move(W.WDATA_CABEC, W.LD01.LD01_QUITACAO);

            /*" -1088- IF AC-LINHAS GREATER 56 */

            if (W.AC_LINHAS > 56)
            {

                /*" -1091- PERFORM R2000-00-CABECALHOS. */

                R2000_00_CABECALHOS_SECTION();
            }


            /*" -1093- WRITE REG-VA0460B FROM LD01 AFTER 1. */
            _.Move(W.LD01.GetMoveValues(), REG_VA0460B);

            VA0460B1.Write(REG_VA0460B.GetMoveValues().ToString());

            /*" -1094- ADD 1 TO AC-IMPRESSOS AC-LINHAS. */
            W.AC_IMPRESSOS.Value = W.AC_IMPRESSOS + 1;
            W.AC_LINHAS.Value = W.AC_LINHAS + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-CABECALHOS-SECTION */
        private void R2000_00_CABECALHOS_SECTION()
        {
            /*" -1107- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", W.WABEND.WNR_EXEC_SQL);

            /*" -1108- ADD 1 TO AC-PAGINA */
            W.AC_PAGINA.Value = W.AC_PAGINA + 1;

            /*" -1110- MOVE AC-PAGINA TO LC01-PAGINA. */
            _.Move(W.AC_PAGINA, W.LC01.LC01_PAGINA);

            /*" -1111- WRITE REG-VA0460B FROM LC01 AFTER PAGE */
            _.Move(W.LC01.GetMoveValues(), REG_VA0460B);

            VA0460B1.Write(REG_VA0460B.GetMoveValues().ToString());

            /*" -1112- WRITE REG-VA0460B FROM LC02 AFTER 1 */
            _.Move(W.LC02.GetMoveValues(), REG_VA0460B);

            VA0460B1.Write(REG_VA0460B.GetMoveValues().ToString());

            /*" -1113- WRITE REG-VA0460B FROM LC03 AFTER 1 */
            _.Move(W.LC03.GetMoveValues(), REG_VA0460B);

            VA0460B1.Write(REG_VA0460B.GetMoveValues().ToString());

            /*" -1114- WRITE REG-VA0460B FROM LC04 AFTER 2 */
            _.Move(W.LC04.GetMoveValues(), REG_VA0460B);

            VA0460B1.Write(REG_VA0460B.GetMoveValues().ToString());

            /*" -1115- WRITE REG-VA0460B FROM LC05 AFTER 1 */
            _.Move(W.LC05.GetMoveValues(), REG_VA0460B);

            VA0460B1.Write(REG_VA0460B.GetMoveValues().ToString());

            /*" -1116- WRITE REG-VA0460B FROM LC06 AFTER 1. */
            _.Move(W.LC06.GetMoveValues(), REG_VA0460B);

            VA0460B1.Write(REG_VA0460B.GetMoveValues().ToString());

            /*" -1117- WRITE REG-VA0460B FROM LC05 AFTER 1. */
            _.Move(W.LC05.GetMoveValues(), REG_VA0460B);

            VA0460B1.Write(REG_VA0460B.GetMoveValues().ToString());

            /*" -1119- WRITE REG-VA0460B FROM LC08 AFTER 1. */
            _.Move(W.LC08.GetMoveValues(), REG_VA0460B);

            VA0460B1.Write(REG_VA0460B.GetMoveValues().ToString());

            /*" -1119- MOVE 9 TO AC-LINHAS. */
            _.Move(9, W.AC_LINHAS);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R3500-00-TRATA-RCAP-SECTION */
        private void R3500_00_TRATA_RCAP_SECTION()
        {
            /*" -1132- MOVE '3500' TO WNR-EXEC-SQL. */
            _.Move("3500", W.WABEND.WNR_EXEC_SQL);

            /*" -1133- IF RCAPS-SIT-REGISTRO EQUAL '0' */

            if (RCAPS.DCLRCAPS.RCAPS_SIT_REGISTRO == "0")
            {

                /*" -1134- MOVE 'S' TO TEM-AVISO */
                _.Move("S", W.TEM_AVISO);

                /*" -1135- ELSE */
            }
            else
            {


                /*" -1138- MOVE SPACES TO TEM-AVISO. */
                _.Move("", W.TEM_AVISO);
            }


            /*" -1140- MOVE RCAPS-COD-FONTE TO RCAPCOMP-COD-FONTE. */
            _.Move(RCAPS.DCLRCAPS.RCAPS_COD_FONTE, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_FONTE);

            /*" -1144- MOVE RCAPS-NUM-RCAP TO RCAPCOMP-NUM-RCAP. */
            _.Move(RCAPS.DCLRCAPS.RCAPS_NUM_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP);

            /*" -1147- PERFORM R3600-00-UPDATE-V0RCAP. */

            R3600_00_UPDATE_V0RCAP_SECTION();

            /*" -1148- MOVE SPACES TO WFIM-V0RCAPCOMP. */
            _.Move("", W.WFIM_V0RCAPCOMP);

            /*" -1150- PERFORM R3700-00-DECLARE-V0RCAPCOMP. */

            R3700_00_DECLARE_V0RCAPCOMP_SECTION();

            /*" -1157- PERFORM R3750-00-FETCH-V0RCAPCOMP UNTIL WFIM-V0RCAPCOMP NOT EQUAL SPACES. */

            while (!(!W.WFIM_V0RCAPCOMP.IsEmpty()))
            {

                R3750_00_FETCH_V0RCAPCOMP_SECTION();
            }

            /*" -1159- MOVE RCAPS-COD-FONTE TO RCAPCOMP-COD-FONTE. */
            _.Move(RCAPS.DCLRCAPS.RCAPS_COD_FONTE, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_FONTE);

            /*" -1162- MOVE RCAPS-NUM-RCAP TO RCAPCOMP-NUM-RCAP. */
            _.Move(RCAPS.DCLRCAPS.RCAPS_NUM_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP);

            /*" -1162- PERFORM R3950-00-UPDATE-V0RCAPCOMP. */

            R3950_00_UPDATE_V0RCAPCOMP_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3500_99_SAIDA*/

        [StopWatch]
        /*" R3600-00-UPDATE-V0RCAP-SECTION */
        private void R3600_00_UPDATE_V0RCAP_SECTION()
        {
            /*" -1174- MOVE '3600' TO WNR-EXEC-SQL. */
            _.Move("3600", W.WABEND.WNR_EXEC_SQL);

            /*" -1179- PERFORM R3600_00_UPDATE_V0RCAP_DB_UPDATE_1 */

            R3600_00_UPDATE_V0RCAP_DB_UPDATE_1();

            /*" -1183- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1184- DISPLAY 'R3600-00 - PROBLEMAS UPDATE (V0RCAP) ' */
                _.Display($"R3600-00 - PROBLEMAS UPDATE (V0RCAP) ");

                /*" -1185- DISPLAY 'NRTIT    ' RCAPS-NUM-TITULO */
                _.Display($"NRTIT    {RCAPS.DCLRCAPS.RCAPS_NUM_TITULO}");

                /*" -1185- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3600-00-UPDATE-V0RCAP-DB-UPDATE-1 */
        public void R3600_00_UPDATE_V0RCAP_DB_UPDATE_1()
        {
            /*" -1179- EXEC SQL UPDATE SEGUROS.RCAPS SET SIT_REGISTRO = '1' , COD_OPERACAO = 210 WHERE NUM_TITULO = :RCAPS-NUM-TITULO END-EXEC. */

            var r3600_00_UPDATE_V0RCAP_DB_UPDATE_1_Update1 = new R3600_00_UPDATE_V0RCAP_DB_UPDATE_1_Update1()
            {
                RCAPS_NUM_TITULO = RCAPS.DCLRCAPS.RCAPS_NUM_TITULO.ToString(),
            };

            R3600_00_UPDATE_V0RCAP_DB_UPDATE_1_Update1.Execute(r3600_00_UPDATE_V0RCAP_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3600_99_SAIDA*/

        [StopWatch]
        /*" R3700-00-DECLARE-V0RCAPCOMP-SECTION */
        private void R3700_00_DECLARE_V0RCAPCOMP_SECTION()
        {
            /*" -1198- MOVE '3700' TO WNR-EXEC-SQL. */
            _.Move("3700", W.WABEND.WNR_EXEC_SQL);

            /*" -1218- PERFORM R3700_00_DECLARE_V0RCAPCOMP_DB_DECLARE_1 */

            R3700_00_DECLARE_V0RCAPCOMP_DB_DECLARE_1();

            /*" -1221- PERFORM R3700_00_DECLARE_V0RCAPCOMP_DB_OPEN_1 */

            R3700_00_DECLARE_V0RCAPCOMP_DB_OPEN_1();

            /*" -1224- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1225- DISPLAY 'R3700-00 - PROBLEMAS DECLARE (V0RCAPCOMP) ' */
                _.Display($"R3700-00 - PROBLEMAS DECLARE (V0RCAPCOMP) ");

                /*" -1226- DISPLAY 'FONTE    ' RCAPCOMP-COD-FONTE */
                _.Display($"FONTE    {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_FONTE}");

                /*" -1227- DISPLAY 'NRRCAP   ' RCAPCOMP-NUM-RCAP */
                _.Display($"NRRCAP   {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP}");

                /*" -1227- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3700-00-DECLARE-V0RCAPCOMP-DB-OPEN-1 */
        public void R3700_00_DECLARE_V0RCAPCOMP_DB_OPEN_1()
        {
            /*" -1221- EXEC SQL OPEN V0RCAPCOMP END-EXEC. */

            V0RCAPCOMP.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3700_99_SAIDA*/

        [StopWatch]
        /*" R3750-00-FETCH-V0RCAPCOMP-SECTION */
        private void R3750_00_FETCH_V0RCAPCOMP_SECTION()
        {
            /*" -1240- MOVE '3750' TO WNR-EXEC-SQL. */
            _.Move("3750", W.WABEND.WNR_EXEC_SQL);

            /*" -1256- PERFORM R3750_00_FETCH_V0RCAPCOMP_DB_FETCH_1 */

            R3750_00_FETCH_V0RCAPCOMP_DB_FETCH_1();

            /*" -1260- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1260- PERFORM R3750_00_FETCH_V0RCAPCOMP_DB_CLOSE_1 */

                R3750_00_FETCH_V0RCAPCOMP_DB_CLOSE_1();

                /*" -1262- MOVE 'S' TO WFIM-V0RCAPCOMP */
                _.Move("S", W.WFIM_V0RCAPCOMP);

                /*" -1264- GO TO R3750-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3750_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1265- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1266- DISPLAY 'R3750-00 - PROBLEMAS FETCH  (V0RCAPCOMP) ' */
                _.Display($"R3750-00 - PROBLEMAS FETCH  (V0RCAPCOMP) ");

                /*" -1267- DISPLAY 'FONTE    ' RCAPCOMP-COD-FONTE */
                _.Display($"FONTE    {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_FONTE}");

                /*" -1268- DISPLAY 'NRRCAP   ' RCAPCOMP-NUM-RCAP */
                _.Display($"NRRCAP   {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP}");

                /*" -1271- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1272- IF RCAPS-VAL-RCAP-PRINCIPAL EQUAL RCAPS-VAL-RCAP */

            if (RCAPS.DCLRCAPS.RCAPS_VAL_RCAP_PRINCIPAL == RCAPS.DCLRCAPS.RCAPS_VAL_RCAP)
            {

                /*" -1273- IF RCAPCOMP-NUM-RCAP-COMPLEMEN NOT EQUAL ZEROS */

                if (RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP_COMPLEMEN != 00)
                {

                    /*" -1274- GO TO R3750-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3750_99_SAIDA*/ //GOTO
                    return;

                    /*" -1275- ELSE */
                }
                else
                {


                    /*" -1276- PERFORM R3800-00-TRATA-V0RCAPCOMP */

                    R3800_00_TRATA_V0RCAPCOMP_SECTION();

                    /*" -1277- ELSE */
                }

            }
            else
            {


                /*" -1279- IF AUX-SITUACAO EQUAL '0' AND RCAPCOMP-COD-OPERACAO EQUAL 400 */

                if (W.AUX_SITUACAO == "0" && RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_OPERACAO == 400)
                {

                    /*" -1280- GO TO R3750-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3750_99_SAIDA*/ //GOTO
                    return;

                    /*" -1281- ELSE */
                }
                else
                {


                    /*" -1281- PERFORM R3800-00-TRATA-V0RCAPCOMP. */

                    R3800_00_TRATA_V0RCAPCOMP_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R3750-00-FETCH-V0RCAPCOMP-DB-FETCH-1 */
        public void R3750_00_FETCH_V0RCAPCOMP_DB_FETCH_1()
        {
            /*" -1256- EXEC SQL FETCH V0RCAPCOMP INTO :RCAPCOMP-COD-FONTE , :RCAPCOMP-NUM-RCAP , :RCAPCOMP-NUM-RCAP-COMPLEMEN , :RCAPCOMP-COD-OPERACAO , :RCAPCOMP-DATA-MOVIMENTO , :RCAPCOMP-HORA-OPERACAO , :RCAPCOMP-SIT-REGISTRO , :RCAPCOMP-BCO-AVISO , :RCAPCOMP-AGE-AVISO , :RCAPCOMP-NUM-AVISO-CREDITO , :RCAPCOMP-VAL-RCAP , :RCAPCOMP-DATA-RCAP , :RCAPCOMP-DATA-CADASTRAMENTO , :RCAPCOMP-SIT-CONTABIL , :RCAPCOMP-COD-EMPRESA END-EXEC. */

            if (V0RCAPCOMP.Fetch())
            {
                _.Move(V0RCAPCOMP.RCAPCOMP_COD_FONTE, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_FONTE);
                _.Move(V0RCAPCOMP.RCAPCOMP_NUM_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP);
                _.Move(V0RCAPCOMP.RCAPCOMP_NUM_RCAP_COMPLEMEN, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP_COMPLEMEN);
                _.Move(V0RCAPCOMP.RCAPCOMP_COD_OPERACAO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_OPERACAO);
                _.Move(V0RCAPCOMP.RCAPCOMP_DATA_MOVIMENTO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_MOVIMENTO);
                _.Move(V0RCAPCOMP.RCAPCOMP_HORA_OPERACAO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_HORA_OPERACAO);
                _.Move(V0RCAPCOMP.RCAPCOMP_SIT_REGISTRO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_SIT_REGISTRO);
                _.Move(V0RCAPCOMP.RCAPCOMP_BCO_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO);
                _.Move(V0RCAPCOMP.RCAPCOMP_AGE_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO);
                _.Move(V0RCAPCOMP.RCAPCOMP_NUM_AVISO_CREDITO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO);
                _.Move(V0RCAPCOMP.RCAPCOMP_VAL_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP);
                _.Move(V0RCAPCOMP.RCAPCOMP_DATA_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP);
                _.Move(V0RCAPCOMP.RCAPCOMP_DATA_CADASTRAMENTO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_CADASTRAMENTO);
                _.Move(V0RCAPCOMP.RCAPCOMP_SIT_CONTABIL, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_SIT_CONTABIL);
                _.Move(V0RCAPCOMP.RCAPCOMP_COD_EMPRESA, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_EMPRESA);
            }

        }

        [StopWatch]
        /*" R3750-00-FETCH-V0RCAPCOMP-DB-CLOSE-1 */
        public void R3750_00_FETCH_V0RCAPCOMP_DB_CLOSE_1()
        {
            /*" -1260- EXEC SQL CLOSE V0RCAPCOMP END-EXEC */

            V0RCAPCOMP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3750_99_SAIDA*/

        [StopWatch]
        /*" R3800-00-TRATA-V0RCAPCOMP-SECTION */
        private void R3800_00_TRATA_V0RCAPCOMP_SECTION()
        {
            /*" -1294- MOVE '3800' TO WNR-EXEC-SQL. */
            _.Move("3800", W.WABEND.WNR_EXEC_SQL);

            /*" -1300- PERFORM R3850-00-UPDATE-V0RCAPCOMP. */

            R3850_00_UPDATE_V0RCAPCOMP_SECTION();

            /*" -1301- IF RCAPCOMP-COD-OPERACAO EQUAL 400 */

            if (RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_OPERACAO == 400)
            {

                /*" -1303- MOVE 500 TO RCAPCOMP-COD-OPERACAO */
                _.Move(500, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_OPERACAO);

                /*" -1305- MOVE SISTEMAS-DATA-MOV-ABERTO TO RCAPCOMP-DATA-MOVIMENTO */
                _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_MOVIMENTO);

                /*" -1307- MOVE '1' TO RCAPCOMP-SIT-REGISTRO */
                _.Move("1", RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_SIT_REGISTRO);

                /*" -1309- MOVE '0' TO RCAPCOMP-SIT-CONTABIL */
                _.Move("0", RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_SIT_CONTABIL);

                /*" -1311- MOVE ZEROS TO RCAPCOMP-COD-EMPRESA */
                _.Move(0, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_EMPRESA);

                /*" -1312- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), W.WS_TIME);

                /*" -1313- MOVE WS-HH-TIME TO WTIME-HORA */
                _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_5.WTIME_DAYR.WTIME_HORA);

                /*" -1314- MOVE '.' TO WTIME-2PT1 */
                _.Move(".", W.FILLER_5.WTIME_DAYR.WTIME_2PT1);

                /*" -1315- MOVE WS-MM-TIME TO WTIME-MINU */
                _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_5.WTIME_DAYR.WTIME_MINU);

                /*" -1316- MOVE '.' TO WTIME-2PT2 */
                _.Move(".", W.FILLER_5.WTIME_DAYR.WTIME_2PT2);

                /*" -1317- MOVE WS-SS-TIME TO WTIME-SEGU */
                _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_5.WTIME_DAYR.WTIME_SEGU);

                /*" -1319- MOVE WTIME-DAYR TO RCAPCOMP-HORA-OPERACAO */
                _.Move(W.FILLER_5.WTIME_DAYR, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_HORA_OPERACAO);

                /*" -1328- PERFORM R3900-00-INSERT-V0RCAPCOMP. */

                R3900_00_INSERT_V0RCAPCOMP_SECTION();
            }


            /*" -1330- MOVE 210 TO RCAPCOMP-COD-OPERACAO */
            _.Move(210, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_OPERACAO);

            /*" -1332- MOVE SISTEMAS-DATA-MOV-ABERTO TO RCAPCOMP-DATA-MOVIMENTO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_MOVIMENTO);

            /*" -1334- MOVE '9' TO RCAPCOMP-SIT-REGISTRO */
            _.Move("9", RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_SIT_REGISTRO);

            /*" -1336- MOVE '0' TO RCAPCOMP-SIT-CONTABIL */
            _.Move("0", RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_SIT_CONTABIL);

            /*" -1338- MOVE ZEROS TO RCAPCOMP-COD-EMPRESA */
            _.Move(0, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_EMPRESA);

            /*" -1339- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), W.WS_TIME);

            /*" -1340- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_5.WTIME_DAYR.WTIME_HORA);

            /*" -1341- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", W.FILLER_5.WTIME_DAYR.WTIME_2PT1);

            /*" -1342- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_5.WTIME_DAYR.WTIME_MINU);

            /*" -1343- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", W.FILLER_5.WTIME_DAYR.WTIME_2PT2);

            /*" -1344- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_5.WTIME_DAYR.WTIME_SEGU);

            /*" -1347- MOVE WTIME-DAYR TO RCAPCOMP-HORA-OPERACAO AUX-HORAOPER */
            _.Move(W.FILLER_5.WTIME_DAYR, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_HORA_OPERACAO, W.AUX_HORAOPER);

            /*" -1353- PERFORM R3900-00-INSERT-V0RCAPCOMP. */

            R3900_00_INSERT_V0RCAPCOMP_SECTION();

            /*" -1354- IF TEM-AVISO NOT EQUAL SPACES */

            if (!W.TEM_AVISO.IsEmpty())
            {

                /*" -1354- PERFORM R4000-00-TRATA-AVISO. */

                R4000_00_TRATA_AVISO_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3800_99_SAIDA*/

        [StopWatch]
        /*" R3850-00-UPDATE-V0RCAPCOMP-SECTION */
        private void R3850_00_UPDATE_V0RCAPCOMP_SECTION()
        {
            /*" -1367- MOVE '3850' TO WNR-EXEC-SQL. */
            _.Move("3850", W.WABEND.WNR_EXEC_SQL);

            /*" -1376- PERFORM R3850_00_UPDATE_V0RCAPCOMP_DB_UPDATE_1 */

            R3850_00_UPDATE_V0RCAPCOMP_DB_UPDATE_1();

            /*" -1380- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1381- DISPLAY 'R3850-00 - PROBLEMAS UPDATE (V0RCAPCOMP) ' */
                _.Display($"R3850-00 - PROBLEMAS UPDATE (V0RCAPCOMP) ");

                /*" -1382- DISPLAY 'FONTE    ' RCAPCOMP-COD-FONTE */
                _.Display($"FONTE    {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_FONTE}");

                /*" -1383- DISPLAY 'NRRCAP   ' RCAPCOMP-NUM-RCAP */
                _.Display($"NRRCAP   {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP}");

                /*" -1384- DISPLAY 'NRRCAPCO ' RCAPCOMP-NUM-RCAP-COMPLEMEN */
                _.Display($"NRRCAPCO {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP_COMPLEMEN}");

                /*" -1385- DISPLAY 'OPERACAO ' RCAPCOMP-COD-OPERACAO */
                _.Display($"OPERACAO {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_OPERACAO}");

                /*" -1385- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3850-00-UPDATE-V0RCAPCOMP-DB-UPDATE-1 */
        public void R3850_00_UPDATE_V0RCAPCOMP_DB_UPDATE_1()
        {
            /*" -1376- EXEC SQL UPDATE SEGUROS.RCAP_COMPLEMENTAR SET SIT_REGISTRO = '1' WHERE DATA_MOVIMENTO = :RCAPCOMP-DATA-MOVIMENTO AND HORA_OPERACAO = :RCAPCOMP-HORA-OPERACAO AND COD_FONTE = :RCAPCOMP-COD-FONTE AND NUM_RCAP = :RCAPCOMP-NUM-RCAP AND NUM_RCAP_COMPLEMEN = :RCAPCOMP-NUM-RCAP-COMPLEMEN AND COD_OPERACAO = :RCAPCOMP-COD-OPERACAO END-EXEC. */

            var r3850_00_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1 = new R3850_00_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1()
            {
                RCAPCOMP_NUM_RCAP_COMPLEMEN = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP_COMPLEMEN.ToString(),
                RCAPCOMP_DATA_MOVIMENTO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_MOVIMENTO.ToString(),
                RCAPCOMP_HORA_OPERACAO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_HORA_OPERACAO.ToString(),
                RCAPCOMP_COD_OPERACAO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_OPERACAO.ToString(),
                RCAPCOMP_COD_FONTE = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_FONTE.ToString(),
                RCAPCOMP_NUM_RCAP = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP.ToString(),
            };

            R3850_00_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1.Execute(r3850_00_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3850_99_SAIDA*/

        [StopWatch]
        /*" R3900-00-INSERT-V0RCAPCOMP-SECTION */
        private void R3900_00_INSERT_V0RCAPCOMP_SECTION()
        {
            /*" -1398- MOVE '3900' TO WNR-EXEC-SQL. */
            _.Move("3900", W.WABEND.WNR_EXEC_SQL);

            /*" -1433- PERFORM R3900_00_INSERT_V0RCAPCOMP_DB_INSERT_1 */

            R3900_00_INSERT_V0RCAPCOMP_DB_INSERT_1();

            /*" -1436- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1437- DISPLAY 'R3900-00 - PROBLEMAS INSERT (V0RCAPCOMP) ' */
                _.Display($"R3900-00 - PROBLEMAS INSERT (V0RCAPCOMP) ");

                /*" -1438- DISPLAY 'FONTE    ' RCAPCOMP-COD-FONTE */
                _.Display($"FONTE    {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_FONTE}");

                /*" -1439- DISPLAY 'NRRCAP   ' RCAPCOMP-NUM-RCAP */
                _.Display($"NRRCAP   {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP}");

                /*" -1440- DISPLAY 'OPERACAO ' RCAPCOMP-COD-OPERACAO */
                _.Display($"OPERACAO {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_OPERACAO}");

                /*" -1440- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3900-00-INSERT-V0RCAPCOMP-DB-INSERT-1 */
        public void R3900_00_INSERT_V0RCAPCOMP_DB_INSERT_1()
        {
            /*" -1433- EXEC SQL INSERT INTO SEGUROS.RCAP_COMPLEMENTAR (COD_FONTE , NUM_RCAP , NUM_RCAP_COMPLEMEN , COD_OPERACAO , DATA_MOVIMENTO , HORA_OPERACAO , SIT_REGISTRO , BCO_AVISO , AGE_AVISO , NUM_AVISO_CREDITO , VAL_RCAP , DATA_RCAP , DATA_CADASTRAMENTO , SIT_CONTABIL , COD_EMPRESA , TIMESTAMP ) VALUES (:RCAPCOMP-COD-FONTE , :RCAPCOMP-NUM-RCAP , :RCAPCOMP-NUM-RCAP-COMPLEMEN , :RCAPCOMP-COD-OPERACAO , :RCAPCOMP-DATA-MOVIMENTO , :RCAPCOMP-HORA-OPERACAO , :RCAPCOMP-SIT-REGISTRO , :RCAPCOMP-BCO-AVISO , :RCAPCOMP-AGE-AVISO , :RCAPCOMP-NUM-AVISO-CREDITO , :RCAPCOMP-VAL-RCAP , :RCAPCOMP-DATA-RCAP , :RCAPCOMP-DATA-CADASTRAMENTO , :RCAPCOMP-SIT-CONTABIL , :RCAPCOMP-COD-EMPRESA , CURRENT TIMESTAMP ) END-EXEC. */

            var r3900_00_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1 = new R3900_00_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1()
            {
                RCAPCOMP_COD_FONTE = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_FONTE.ToString(),
                RCAPCOMP_NUM_RCAP = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP.ToString(),
                RCAPCOMP_NUM_RCAP_COMPLEMEN = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP_COMPLEMEN.ToString(),
                RCAPCOMP_COD_OPERACAO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_OPERACAO.ToString(),
                RCAPCOMP_DATA_MOVIMENTO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_MOVIMENTO.ToString(),
                RCAPCOMP_HORA_OPERACAO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_HORA_OPERACAO.ToString(),
                RCAPCOMP_SIT_REGISTRO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_SIT_REGISTRO.ToString(),
                RCAPCOMP_BCO_AVISO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO.ToString(),
                RCAPCOMP_AGE_AVISO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO.ToString(),
                RCAPCOMP_NUM_AVISO_CREDITO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO.ToString(),
                RCAPCOMP_VAL_RCAP = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP.ToString(),
                RCAPCOMP_DATA_RCAP = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP.ToString(),
                RCAPCOMP_DATA_CADASTRAMENTO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_CADASTRAMENTO.ToString(),
                RCAPCOMP_SIT_CONTABIL = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_SIT_CONTABIL.ToString(),
                RCAPCOMP_COD_EMPRESA = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_EMPRESA.ToString(),
            };

            R3900_00_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1.Execute(r3900_00_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3900_99_SAIDA*/

        [StopWatch]
        /*" R3950-00-UPDATE-V0RCAPCOMP-SECTION */
        private void R3950_00_UPDATE_V0RCAPCOMP_SECTION()
        {
            /*" -1453- MOVE '3950' TO WNR-EXEC-SQL. */
            _.Move("3950", W.WABEND.WNR_EXEC_SQL);

            /*" -1459- PERFORM R3950_00_UPDATE_V0RCAPCOMP_DB_UPDATE_1 */

            R3950_00_UPDATE_V0RCAPCOMP_DB_UPDATE_1();

        }

        [StopWatch]
        /*" R3950-00-UPDATE-V0RCAPCOMP-DB-UPDATE-1 */
        public void R3950_00_UPDATE_V0RCAPCOMP_DB_UPDATE_1()
        {
            /*" -1459- EXEC SQL UPDATE SEGUROS.RCAP_COMPLEMENTAR SET SIT_REGISTRO = '0' WHERE COD_FONTE = :RCAPCOMP-COD-FONTE AND NUM_RCAP = :RCAPCOMP-NUM-RCAP AND SIT_REGISTRO = '9' END-EXEC. */

            var r3950_00_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1 = new R3950_00_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1()
            {
                RCAPCOMP_COD_FONTE = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_FONTE.ToString(),
                RCAPCOMP_NUM_RCAP = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP.ToString(),
            };

            R3950_00_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1.Execute(r3950_00_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3950_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-TRATA-AVISO-SECTION */
        private void R4000_00_TRATA_AVISO_SECTION()
        {
            /*" -1472- MOVE '4000' TO WNR-EXEC-SQL. */
            _.Move("4000", W.WABEND.WNR_EXEC_SQL);

            /*" -1474- MOVE RCAPCOMP-BCO-AVISO TO AVISOSAL-BCO-AVISO. */
            _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO, AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_BCO_AVISO);

            /*" -1476- MOVE RCAPCOMP-AGE-AVISO TO AVISOSAL-AGE-AVISO. */
            _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO, AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_AGE_AVISO);

            /*" -1479- MOVE RCAPCOMP-NUM-AVISO-CREDITO TO AVISOSAL-NUM-AVISO-CREDITO. */
            _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO, AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_NUM_AVISO_CREDITO);

            /*" -1482- PERFORM R4100-00-SELECT-V0AVISO. */

            R4100_00_SELECT_V0AVISO_SECTION();

            /*" -1484- IF AVISOSAL-SALDO-ATUAL LESS RCAPCOMP-VAL-RCAP */

            if (AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SALDO_ATUAL < RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP)
            {

                /*" -1487- GO TO R4000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1491- COMPUTE AVISOSAL-SALDO-ATUAL EQUAL (AVISOSAL-SALDO-ATUAL - RCAPCOMP-VAL-RCAP). */
            AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SALDO_ATUAL.Value = (AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SALDO_ATUAL - RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP);

            /*" -1491- PERFORM R4200-00-UPDATE-V0AVISO. */

            R4200_00_UPDATE_V0AVISO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R4100-00-SELECT-V0AVISO-SECTION */
        private void R4100_00_SELECT_V0AVISO_SECTION()
        {
            /*" -1503- MOVE '4100' TO WNR-EXEC-SQL. */
            _.Move("4100", W.WABEND.WNR_EXEC_SQL);

            /*" -1510- PERFORM R4100_00_SELECT_V0AVISO_DB_SELECT_1 */

            R4100_00_SELECT_V0AVISO_DB_SELECT_1();

            /*" -1514- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1515- MOVE ZEROS TO AVISOSAL-SALDO-ATUAL. */
                _.Move(0, AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SALDO_ATUAL);
            }


        }

        [StopWatch]
        /*" R4100-00-SELECT-V0AVISO-DB-SELECT-1 */
        public void R4100_00_SELECT_V0AVISO_DB_SELECT_1()
        {
            /*" -1510- EXEC SQL SELECT SALDO_ATUAL INTO :AVISOSAL-SALDO-ATUAL FROM SEGUROS.AVISOS_SALDOS WHERE BCO_AVISO = :AVISOSAL-BCO-AVISO AND AGE_AVISO = :AVISOSAL-AGE-AVISO AND NUM_AVISO_CREDITO = :AVISOSAL-NUM-AVISO-CREDITO END-EXEC. */

            var r4100_00_SELECT_V0AVISO_DB_SELECT_1_Query1 = new R4100_00_SELECT_V0AVISO_DB_SELECT_1_Query1()
            {
                AVISOSAL_NUM_AVISO_CREDITO = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_NUM_AVISO_CREDITO.ToString(),
                AVISOSAL_BCO_AVISO = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_BCO_AVISO.ToString(),
                AVISOSAL_AGE_AVISO = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_AGE_AVISO.ToString(),
            };

            var executed_1 = R4100_00_SELECT_V0AVISO_DB_SELECT_1_Query1.Execute(r4100_00_SELECT_V0AVISO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AVISOSAL_SALDO_ATUAL, AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SALDO_ATUAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4100_99_SAIDA*/

        [StopWatch]
        /*" R4200-00-UPDATE-V0AVISO-SECTION */
        private void R4200_00_UPDATE_V0AVISO_SECTION()
        {
            /*" -1528- MOVE '4200' TO WNR-EXEC-SQL. */
            _.Move("4200", W.WABEND.WNR_EXEC_SQL);

            /*" -1534- PERFORM R4200_00_UPDATE_V0AVISO_DB_UPDATE_1 */

            R4200_00_UPDATE_V0AVISO_DB_UPDATE_1();

            /*" -1538- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1539- DISPLAY 'R4200-00 - PROBLEMAS UPDATE (V0AVISO)    ' */
                _.Display($"R4200-00 - PROBLEMAS UPDATE (V0AVISO)    ");

                /*" -1540- DISPLAY ' BCOAVISO     ' AVISOSAL-BCO-AVISO */
                _.Display($" BCOAVISO     {AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_BCO_AVISO}");

                /*" -1541- DISPLAY ' AGEAVISO     ' AVISOSAL-AGE-AVISO */
                _.Display($" AGEAVISO     {AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_AGE_AVISO}");

                /*" -1541- DISPLAY ' NRAVISO      ' AVISOSAL-NUM-AVISO-CREDITO. */
                _.Display($" NRAVISO      {AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_NUM_AVISO_CREDITO}");
            }


        }

        [StopWatch]
        /*" R4200-00-UPDATE-V0AVISO-DB-UPDATE-1 */
        public void R4200_00_UPDATE_V0AVISO_DB_UPDATE_1()
        {
            /*" -1534- EXEC SQL UPDATE SEGUROS.AVISOS_SALDOS SET SALDO_ATUAL = :AVISOSAL-SALDO-ATUAL WHERE BCO_AVISO = :AVISOSAL-BCO-AVISO AND AGE_AVISO = :AVISOSAL-AGE-AVISO AND NUM_AVISO_CREDITO = :AVISOSAL-NUM-AVISO-CREDITO END-EXEC. */

            var r4200_00_UPDATE_V0AVISO_DB_UPDATE_1_Update1 = new R4200_00_UPDATE_V0AVISO_DB_UPDATE_1_Update1()
            {
                AVISOSAL_SALDO_ATUAL = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SALDO_ATUAL.ToString(),
                AVISOSAL_NUM_AVISO_CREDITO = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_NUM_AVISO_CREDITO.ToString(),
                AVISOSAL_BCO_AVISO = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_BCO_AVISO.ToString(),
                AVISOSAL_AGE_AVISO = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_AGE_AVISO.ToString(),
            };

            R4200_00_UPDATE_V0AVISO_DB_UPDATE_1_Update1.Execute(r4200_00_UPDATE_V0AVISO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4200_99_SAIDA*/

        [StopWatch]
        /*" R5000-00-INSERT-V0RELATORIOS-SECTION */
        private void R5000_00_INSERT_V0RELATORIOS_SECTION()
        {
            /*" -1554- MOVE '5000' TO WNR-EXEC-SQL. */
            _.Move("5000", W.WABEND.WNR_EXEC_SQL);

            /*" -1556- MOVE USUARIOS-COD-USUARIO TO RELATORI-COD-USUARIO. */
            _.Move(USUARIOS.DCLUSUARIOS.USUARIOS_COD_USUARIO, RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO);

            /*" -1558- MOVE SISTEMAS-DATA-MOV-ABERTO TO RELATORI-DATA-SOLICITACAO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO);

            /*" -1560- MOVE 'CB' TO RELATORI-IDE-SISTEMA. */
            _.Move("CB", RELATORI.DCLRELATORIOS.RELATORI_IDE_SISTEMA);

            /*" -1562- MOVE 'CB0355B1' TO RELATORI-COD-RELATORIO. */
            _.Move("CB0355B1", RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO);

            /*" -1564- MOVE AUX-COD-DESPESA TO RELATORI-NUM-COPIAS. */
            _.Move(W.AUX_COD_DESPESA, RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS);

            /*" -1566- MOVE DEVOLVID-COD-DEVOLUCAO TO RELATORI-QUANTIDADE. */
            _.Move(DEVOLVID.DCLDEVOLUCAO_VIDAZUL.DEVOLVID_COD_DEVOLUCAO, RELATORI.DCLRELATORIOS.RELATORI_QUANTIDADE);

            /*" -1569- MOVE SISTEMAS-DATA-MOV-ABERTO TO RELATORI-PERI-INICIAL RELATORI-PERI-FINAL. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL, RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL);

            /*" -1571- MOVE PROPOVA-DATA-QUITACAO TO RELATORI-DATA-REFERENCIA. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO, RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA);

            /*" -1573- MOVE ENDERECO-OCORR-ENDERECO TO RELATORI-MES-REFERENCIA. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO, RELATORI.DCLRELATORIOS.RELATORI_MES_REFERENCIA);

            /*" -1575- MOVE ENDERECO-COD-ENDERECO TO RELATORI-ANO-REFERENCIA. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_COD_ENDERECO, RELATORI.DCLRELATORIOS.RELATORI_ANO_REFERENCIA);

            /*" -1577- MOVE ZEROS TO RELATORI-ORGAO-EMISSOR. */
            _.Move(0, RELATORI.DCLRELATORIOS.RELATORI_ORGAO_EMISSOR);

            /*" -1579- MOVE AUX-COD-FONTE TO RELATORI-COD-FONTE. */
            _.Move(W.AUX_COD_FONTE, RELATORI.DCLRELATORIOS.RELATORI_COD_FONTE);

            /*" -1581- MOVE CLIENTES-COD-CLIENTE TO RELATORI-COD-PRODUTOR. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE, RELATORI.DCLRELATORIOS.RELATORI_COD_PRODUTOR);

            /*" -1583- MOVE PRODUTO-RAMO-EMISSOR TO RELATORI-RAMO-EMISSOR. */
            _.Move(PRODUTO.DCLPRODUTO.PRODUTO_RAMO_EMISSOR, RELATORI.DCLRELATORIOS.RELATORI_RAMO_EMISSOR);

            /*" -1585- MOVE 0005 TO RELATORI-COD-MODALIDADE. */
            _.Move(0005, RELATORI.DCLRELATORIOS.RELATORI_COD_MODALIDADE);

            /*" -1587- MOVE AGENCCEF-COD-AGENCIA TO RELATORI-COD-CONGENERE. */
            _.Move(AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_AGENCIA, RELATORI.DCLRELATORIOS.RELATORI_COD_CONGENERE);

            /*" -1589- MOVE PRODUVG-NUM-APOLICE TO RELATORI-NUM-APOLICE. */
            _.Move(PRODUVG.DCLPRODUTOS_VG.PRODUVG_NUM_APOLICE, RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE);

            /*" -1591- MOVE ZEROS TO RELATORI-NUM-ENDOSSO. */
            _.Move(0, RELATORI.DCLRELATORIOS.RELATORI_NUM_ENDOSSO);

            /*" -1593- MOVE COBHISVI-NUM-PARCELA TO RELATORI-NUM-PARCELA. */
            _.Move(COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_PARCELA, RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA);

            /*" -1595- MOVE COBHISVI-NUM-CERTIFICADO TO RELATORI-NUM-CERTIFICADO. */
            _.Move(COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_CERTIFICADO, RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO);

            /*" -1597- MOVE COBHISVI-NUM-TITULO TO RELATORI-NUM-TITULO. */
            _.Move(COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO, RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO);

            /*" -1599- MOVE PRODUVG-COD-SUBGRUPO TO RELATORI-COD-SUBGRUPO. */
            _.Move(PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_SUBGRUPO, RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO);

            /*" -1601- MOVE FONTES-COD-FONTE TO RELATORI-COD-OPERACAO. */
            _.Move(FONTES.DCLFONTES.FONTES_COD_FONTE, RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO);

            /*" -1603- MOVE ESCRINEG-COD-ESCNEG TO RELATORI-COD-PLANO. */
            _.Move(ESCRINEG.DCLESCRITORIO_NEGOCIO.ESCRINEG_COD_ESCNEG, RELATORI.DCLRELATORIOS.RELATORI_COD_PLANO);

            /*" -1605- MOVE COBHISVI-OCORR-HISTORICO TO RELATORI-OCORR-HISTORICO. */
            _.Move(COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_OCORR_HISTORICO, RELATORI.DCLRELATORIOS.RELATORI_OCORR_HISTORICO);

            /*" -1607- MOVE AUX-HORAOPER TO RELATORI-ENDOS-LIDER. */
            _.Move(W.AUX_HORAOPER, RELATORI.DCLRELATORIOS.RELATORI_ENDOS_LIDER);

            /*" -1611- MOVE ZEROS TO RELATORI-NUM-PARC-LIDER RELATORI-NUM-SINISTRO RELATORI-NUM-ORDEM. */
            _.Move(0, RELATORI.DCLRELATORIOS.RELATORI_NUM_PARC_LIDER, RELATORI.DCLRELATORIOS.RELATORI_NUM_SINISTRO, RELATORI.DCLRELATORIOS.RELATORI_NUM_ORDEM);

            /*" -1613- MOVE PRODUTO-COD-PRODUTO TO RELATORI-COD-MOEDA. */
            _.Move(PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO, RELATORI.DCLRELATORIOS.RELATORI_COD_MOEDA);

            /*" -1615- MOVE 'S' TO RELATORI-TIPO-CORRECAO. */
            _.Move("S", RELATORI.DCLRELATORIOS.RELATORI_TIPO_CORRECAO);

            /*" -1617- MOVE '0' TO RELATORI-SIT-REGISTRO. */
            _.Move("0", RELATORI.DCLRELATORIOS.RELATORI_SIT_REGISTRO);

            /*" -1619- MOVE SPACES TO RELATORI-IND-PREV-DEFINIT. */
            _.Move("", RELATORI.DCLRELATORIOS.RELATORI_IND_PREV_DEFINIT);

            /*" -1621- MOVE '2' TO RELATORI-IND-ANAL-RESUMO. */
            _.Move("2", RELATORI.DCLRELATORIOS.RELATORI_IND_ANAL_RESUMO);

            /*" -1626- MOVE ZEROS TO RELATORI-COD-EMPRESA RELATORI-PERI-RENOVACAO RELATORI-PCT-AUMENTO. */
            _.Move(0, RELATORI.DCLRELATORIOS.RELATORI_COD_EMPRESA, RELATORI.DCLRELATORIOS.RELATORI_PERI_RENOVACAO, RELATORI.DCLRELATORIOS.RELATORI_PCT_AUMENTO);

            /*" -1628- MOVE COBHISVI-PRM-TOTAL TO WS-VLNUME. */
            _.Move(COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_PRM_TOTAL, W.FILLER_8.WS_VLNUME);

            /*" -1633- MOVE WS-VLALFA TO RELATORI-NUM-APOL-LIDER RELATORI-NUM-SINI-LIDER. */
            _.Move(W.WS_VLALFA, RELATORI.DCLRELATORIOS.RELATORI_NUM_APOL_LIDER, RELATORI.DCLRELATORIOS.RELATORI_NUM_SINI_LIDER);

            /*" -1718- PERFORM R5000_00_INSERT_V0RELATORIOS_DB_INSERT_1 */

            R5000_00_INSERT_V0RELATORIOS_DB_INSERT_1();

            /*" -1722- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1723- DISPLAY 'R5000-00 - PROBLEMAS NO INSERT(RELATORIOS) ' */
                _.Display($"R5000-00 - PROBLEMAS NO INSERT(RELATORIOS) ");

                /*" -1726- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1726- ADD 1 TO AC-RELATORIOS. */
            W.AC_RELATORIOS.Value = W.AC_RELATORIOS + 1;

        }

        [StopWatch]
        /*" R5000-00-INSERT-V0RELATORIOS-DB-INSERT-1 */
        public void R5000_00_INSERT_V0RELATORIOS_DB_INSERT_1()
        {
            /*" -1718- EXEC SQL INSERT INTO SEGUROS.RELATORIOS (COD_USUARIO , DATA_SOLICITACAO , IDE_SISTEMA , COD_RELATORIO , NUM_COPIAS , QUANTIDADE , PERI_INICIAL , PERI_FINAL , DATA_REFERENCIA , MES_REFERENCIA , ANO_REFERENCIA , ORGAO_EMISSOR , COD_FONTE , COD_PRODUTOR , RAMO_EMISSOR , COD_MODALIDADE , COD_CONGENERE , NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , NUM_CERTIFICADO , NUM_TITULO , COD_SUBGRUPO , COD_OPERACAO , COD_PLANO , OCORR_HISTORICO , NUM_APOL_LIDER , ENDOS_LIDER , NUM_PARC_LIDER , NUM_SINISTRO , NUM_SINI_LIDER , NUM_ORDEM , COD_MOEDA , TIPO_CORRECAO , SIT_REGISTRO , IND_PREV_DEFINIT , IND_ANAL_RESUMO , COD_EMPRESA , PERI_RENOVACAO , PCT_AUMENTO , TIMESTAMP ) VALUES (:RELATORI-COD-USUARIO , :RELATORI-DATA-SOLICITACAO , :RELATORI-IDE-SISTEMA , :RELATORI-COD-RELATORIO , :RELATORI-NUM-COPIAS , :RELATORI-QUANTIDADE , :RELATORI-PERI-INICIAL , :RELATORI-PERI-FINAL , :RELATORI-DATA-REFERENCIA , :RELATORI-MES-REFERENCIA , :RELATORI-ANO-REFERENCIA , :RELATORI-ORGAO-EMISSOR , :RELATORI-COD-FONTE , :RELATORI-COD-PRODUTOR , :RELATORI-RAMO-EMISSOR , :RELATORI-COD-MODALIDADE , :RELATORI-COD-CONGENERE , :RELATORI-NUM-APOLICE , :RELATORI-NUM-ENDOSSO , :RELATORI-NUM-PARCELA , :RELATORI-NUM-CERTIFICADO , :RELATORI-NUM-TITULO , :RELATORI-COD-SUBGRUPO , :RELATORI-COD-OPERACAO , :RELATORI-COD-PLANO , :RELATORI-OCORR-HISTORICO , :RELATORI-NUM-APOL-LIDER , :RELATORI-ENDOS-LIDER , :RELATORI-NUM-PARC-LIDER , :RELATORI-NUM-SINISTRO , :RELATORI-NUM-SINI-LIDER , :RELATORI-NUM-ORDEM , :RELATORI-COD-MOEDA , :RELATORI-TIPO-CORRECAO , :RELATORI-SIT-REGISTRO , :RELATORI-IND-PREV-DEFINIT , :RELATORI-IND-ANAL-RESUMO , :RELATORI-COD-EMPRESA , :RELATORI-PERI-RENOVACAO , :RELATORI-PCT-AUMENTO , CURRENT TIMESTAMP ) END-EXEC. */

            var r5000_00_INSERT_V0RELATORIOS_DB_INSERT_1_Insert1 = new R5000_00_INSERT_V0RELATORIOS_DB_INSERT_1_Insert1()
            {
                RELATORI_COD_USUARIO = RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO.ToString(),
                RELATORI_DATA_SOLICITACAO = RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO.ToString(),
                RELATORI_IDE_SISTEMA = RELATORI.DCLRELATORIOS.RELATORI_IDE_SISTEMA.ToString(),
                RELATORI_COD_RELATORIO = RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO.ToString(),
                RELATORI_NUM_COPIAS = RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS.ToString(),
                RELATORI_QUANTIDADE = RELATORI.DCLRELATORIOS.RELATORI_QUANTIDADE.ToString(),
                RELATORI_PERI_INICIAL = RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL.ToString(),
                RELATORI_PERI_FINAL = RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL.ToString(),
                RELATORI_DATA_REFERENCIA = RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA.ToString(),
                RELATORI_MES_REFERENCIA = RELATORI.DCLRELATORIOS.RELATORI_MES_REFERENCIA.ToString(),
                RELATORI_ANO_REFERENCIA = RELATORI.DCLRELATORIOS.RELATORI_ANO_REFERENCIA.ToString(),
                RELATORI_ORGAO_EMISSOR = RELATORI.DCLRELATORIOS.RELATORI_ORGAO_EMISSOR.ToString(),
                RELATORI_COD_FONTE = RELATORI.DCLRELATORIOS.RELATORI_COD_FONTE.ToString(),
                RELATORI_COD_PRODUTOR = RELATORI.DCLRELATORIOS.RELATORI_COD_PRODUTOR.ToString(),
                RELATORI_RAMO_EMISSOR = RELATORI.DCLRELATORIOS.RELATORI_RAMO_EMISSOR.ToString(),
                RELATORI_COD_MODALIDADE = RELATORI.DCLRELATORIOS.RELATORI_COD_MODALIDADE.ToString(),
                RELATORI_COD_CONGENERE = RELATORI.DCLRELATORIOS.RELATORI_COD_CONGENERE.ToString(),
                RELATORI_NUM_APOLICE = RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE.ToString(),
                RELATORI_NUM_ENDOSSO = RELATORI.DCLRELATORIOS.RELATORI_NUM_ENDOSSO.ToString(),
                RELATORI_NUM_PARCELA = RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA.ToString(),
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
                RELATORI_NUM_TITULO = RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO.ToString(),
                RELATORI_COD_SUBGRUPO = RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO.ToString(),
                RELATORI_COD_OPERACAO = RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO.ToString(),
                RELATORI_COD_PLANO = RELATORI.DCLRELATORIOS.RELATORI_COD_PLANO.ToString(),
                RELATORI_OCORR_HISTORICO = RELATORI.DCLRELATORIOS.RELATORI_OCORR_HISTORICO.ToString(),
                RELATORI_NUM_APOL_LIDER = RELATORI.DCLRELATORIOS.RELATORI_NUM_APOL_LIDER.ToString(),
                RELATORI_ENDOS_LIDER = RELATORI.DCLRELATORIOS.RELATORI_ENDOS_LIDER.ToString(),
                RELATORI_NUM_PARC_LIDER = RELATORI.DCLRELATORIOS.RELATORI_NUM_PARC_LIDER.ToString(),
                RELATORI_NUM_SINISTRO = RELATORI.DCLRELATORIOS.RELATORI_NUM_SINISTRO.ToString(),
                RELATORI_NUM_SINI_LIDER = RELATORI.DCLRELATORIOS.RELATORI_NUM_SINI_LIDER.ToString(),
                RELATORI_NUM_ORDEM = RELATORI.DCLRELATORIOS.RELATORI_NUM_ORDEM.ToString(),
                RELATORI_COD_MOEDA = RELATORI.DCLRELATORIOS.RELATORI_COD_MOEDA.ToString(),
                RELATORI_TIPO_CORRECAO = RELATORI.DCLRELATORIOS.RELATORI_TIPO_CORRECAO.ToString(),
                RELATORI_SIT_REGISTRO = RELATORI.DCLRELATORIOS.RELATORI_SIT_REGISTRO.ToString(),
                RELATORI_IND_PREV_DEFINIT = RELATORI.DCLRELATORIOS.RELATORI_IND_PREV_DEFINIT.ToString(),
                RELATORI_IND_ANAL_RESUMO = RELATORI.DCLRELATORIOS.RELATORI_IND_ANAL_RESUMO.ToString(),
                RELATORI_COD_EMPRESA = RELATORI.DCLRELATORIOS.RELATORI_COD_EMPRESA.ToString(),
                RELATORI_PERI_RENOVACAO = RELATORI.DCLRELATORIOS.RELATORI_PERI_RENOVACAO.ToString(),
                RELATORI_PCT_AUMENTO = RELATORI.DCLRELATORIOS.RELATORI_PCT_AUMENTO.ToString(),
            };

            R5000_00_INSERT_V0RELATORIOS_DB_INSERT_1_Insert1.Execute(r5000_00_INSERT_V0RELATORIOS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_99_SAIDA*/

        [StopWatch]
        /*" R5500-00-UPDATE-V0HISTCOBVA-SECTION */
        private void R5500_00_UPDATE_V0HISTCOBVA_SECTION()
        {
            /*" -1738- MOVE '5500' TO WNR-EXEC-SQL. */
            _.Move("5500", W.WABEND.WNR_EXEC_SQL);

            /*" -1745- PERFORM R5500_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1 */

            R5500_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1();

            /*" -1749- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1750- DISPLAY 'R5500-00 - PROBLEMAS UPDATE (V0HISTCOBVA) ' */
                _.Display($"R5500-00 - PROBLEMAS UPDATE (V0HISTCOBVA) ");

                /*" -1751- DISPLAY 'NRCERTIF ' COBHISVI-NUM-CERTIFICADO */
                _.Display($"NRCERTIF {COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_CERTIFICADO}");

                /*" -1752- DISPLAY 'NRPARCEL ' COBHISVI-NUM-PARCELA */
                _.Display($"NRPARCEL {COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_PARCELA}");

                /*" -1753- DISPLAY 'NRTIT    ' COBHISVI-NUM-TITULO */
                _.Display($"NRTIT    {COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO}");

                /*" -1753- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R5500-00-UPDATE-V0HISTCOBVA-DB-UPDATE-1 */
        public void R5500_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1()
        {
            /*" -1745- EXEC SQL UPDATE SEGUROS.COBER_HIST_VIDAZUL SET SIT_REGISTRO = '7' WHERE NUM_CERTIFICADO = :COBHISVI-NUM-CERTIFICADO AND NUM_PARCELA = :COBHISVI-NUM-PARCELA AND NUM_TITULO = :COBHISVI-NUM-TITULO AND SIT_REGISTRO = '4' END-EXEC. */

            var r5500_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1_Update1 = new R5500_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1_Update1()
            {
                COBHISVI_NUM_CERTIFICADO = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_CERTIFICADO.ToString(),
                COBHISVI_NUM_PARCELA = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_PARCELA.ToString(),
                COBHISVI_NUM_TITULO = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO.ToString(),
            };

            R5500_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1_Update1.Execute(r5500_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5500_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1764- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, W.WABEND.WSQLCODE);

            /*" -1765- MOVE SQLERRD(1) TO WSQLERRD1 */
            _.Move(DB.SQLERRD[1], W.WABEND.WSQLERRD1);

            /*" -1766- MOVE SQLERRD(2) TO WSQLERRD2 */
            _.Move(DB.SQLERRD[2], W.WABEND.WSQLERRD2);

            /*" -1768- DISPLAY WABEND. */
            _.Display(W.WABEND);

            /*" -1770- CLOSE VA0460B1. */
            VA0460B1.Close();

            /*" -1770- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1776- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1776- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}