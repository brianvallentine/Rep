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
using Sias.Sinistro.DB2.SI9101B;

namespace Code
{
    public class SI9101B
    {
        public bool IsCall { get; set; }

        public SI9101B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SINISTROS                          *      */
        /*"      *   PROGRAMA ...............  SI9101B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  PRODEXTER                          *      */
        /*"      *   PROGRAMADOR ............  PRODEXTER                          *      */
        /*"      *   DATA CODIFICACAO .......  MAIO/2003                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  AVISO DE SINISTRO A PARTIR DE      *      */
        /*"      *                             MOVIMENTO DE SINISTRO DO CONVENIO  *      */
        /*"      *                             AUTO VERA CRUZ                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ESTE PROGRAMA FOI ALTERADA POR SOLICITACAO SSI 12179 INCLUINDO*      */
        /*"      *  NOVAS COBERTURAS E TRATANDO A NOVA CAUSA 6 RAMO 31 VIDROS.    *      */
        /*"      *  ALTERADO - ALEXIS VEAS ITURRIAGA EM 22/11/2006                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ESTE PROGRAMA FOI ALTERADA POR SOLICITACAO SSI 15518 ALTERANDO*      */
        /*"      *  A COBERTURA PARA APOLICES CANCELADAS.                         *      */
        /*"      *  ALTERADO - ALEXIS VEAS ITURRIAGA EM 21/05/2007                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *--------------------------------------                                 */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis IX1 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"01       WS-COD-COBERTURA       PIC S9(004) VALUE +0 COMP.*/
        public IntBasis WS_COD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01       IND-COD-ERRO           PIC S9(004) VALUE +0 COMP.*/
        public IntBasis IND_COD_ERRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01       WS-NUM-APOL-SINISTRO   PIC  9(013) VALUE ZEROS.*/
        public IntBasis WS_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
        /*"01       FILLER                 REDEFINES   WS-NUM-APOL-SINISTRO*/
        private _REDEF_SI9101B_FILLER_0 _filler_0 { get; set; }
        public _REDEF_SI9101B_FILLER_0 FILLER_0
        {
            get { _filler_0 = new _REDEF_SI9101B_FILLER_0(); _.Move(WS_NUM_APOL_SINISTRO, _filler_0); VarBasis.RedefinePassValue(WS_NUM_APOL_SINISTRO, _filler_0, WS_NUM_APOL_SINISTRO); _filler_0.ValueChanged += () => { _.Move(_filler_0, WS_NUM_APOL_SINISTRO); }; return _filler_0; }
            set { VarBasis.RedefinePassValue(value, _filler_0, WS_NUM_APOL_SINISTRO); }
        }  //Redefines
        public class _REDEF_SI9101B_FILLER_0 : VarBasis
        {
            /*"  05     WS-ORGAO-EMISSOR       PIC  9(003).*/
            public IntBasis WS_ORGAO_EMISSOR { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05     WS-RAMO-EMISSOR        PIC  9(002).*/
            public IntBasis WS_RAMO_EMISSOR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05     WS-SEQ-SINISTRO        PIC  9(008).*/
            public IntBasis WS_SEQ_SINISTRO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"01       HOST-NUM-ITEM-INI      PIC S9(009) VALUE +0 COMP.*/

            public _REDEF_SI9101B_FILLER_0()
            {
                WS_ORGAO_EMISSOR.ValueChanged += OnValueChanged;
                WS_RAMO_EMISSOR.ValueChanged += OnValueChanged;
                WS_SEQ_SINISTRO.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis HOST_NUM_ITEM_INI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01       HOST-NUM-ITEM-FIM      PIC S9(009) VALUE +0 COMP.*/
        public IntBasis HOST_NUM_ITEM_FIM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01       WS-NUM-ITEM            PIC  9(009) VALUE ZEROS.*/
        public IntBasis WS_NUM_ITEM { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       FILLER                 REDEFINES   WS-NUM-ITEM.*/
        private _REDEF_SI9101B_FILLER_1 _filler_1 { get; set; }
        public _REDEF_SI9101B_FILLER_1 FILLER_1
        {
            get { _filler_1 = new _REDEF_SI9101B_FILLER_1(); _.Move(WS_NUM_ITEM, _filler_1); VarBasis.RedefinePassValue(WS_NUM_ITEM, _filler_1, WS_NUM_ITEM); _filler_1.ValueChanged += () => { _.Move(_filler_1, WS_NUM_ITEM); }; return _filler_1; }
            set { VarBasis.RedefinePassValue(value, _filler_1, WS_NUM_ITEM); }
        }  //Redefines
        public class _REDEF_SI9101B_FILLER_1 : VarBasis
        {
            /*"  05     WS-ITEM                PIC  9(007).*/
            public IntBasis WS_ITEM { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
            /*"  05     FILLER                 PIC  9(002).*/
            public IntBasis FILLER_2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"01       WFIM-SIARDEVC          PIC  X(001) VALUE SPACES.*/

            public _REDEF_SI9101B_FILLER_1()
            {
                WS_ITEM.ValueChanged += OnValueChanged;
                FILLER_2.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WFIM_SIARDEVC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01       WTEM-COBERTURA         PIC  X(001) VALUE SPACES.*/
        public StringBasis WTEM_COBERTURA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01       WTEM-ENDOSSOS          PIC  X(001) VALUE SPACES.*/
        public StringBasis WTEM_ENDOSSOS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01       WS-REJEITA-AVISO       PIC  X(001) VALUE SPACES.*/
        public StringBasis WS_REJEITA_AVISO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01       AC-L-SIARDEVC          PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_L_SIARDEVC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-U-SIARDEVC          PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_U_SIARDEVC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-I-SINISCON          PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_I_SINISCON { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-I-SINISACO          PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_I_SINISACO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-I-SINISMES          PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_I_SINISMES { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-I-SINIITEM          PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_I_SINIITEM { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-I-SINISHIS          PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_I_SINISHIS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-I-SINISAUT          PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_I_SINISAUT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-I-SINIMPSE          PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_I_SINIMPSE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       TABELA-COBERTURAS.*/
        public SI9101B_TABELA_COBERTURAS TABELA_COBERTURAS { get; set; } = new SI9101B_TABELA_COBERTURAS();
        public class SI9101B_TABELA_COBERTURAS : VarBasis
        {
            /*"    10       FILLER            PIC  X(057)    VALUE            '2013101COLISAO, INCENDIO, ROUBO E DANOS TOTAIS    '*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "57", "X(057)"), @"2013101COLISAO, INCENDIO, ROUBO E DANOS TOTAIS    ");
            /*"    10       FILLER            PIC  X(057)    VALUE            '1133118DESPESAS EXTRAS                            '*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "57", "X(057)"), @"1133118DESPESAS EXTRAS                            ");
            /*"    10       FILLER            PIC  X(057)    VALUE            '1143109EXT.GAR.VEIC.NOVO-6 MESES INC/ROUBO        '*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "57", "X(057)"), @"1143109EXT.GAR.VEIC.NOVO-6 MESES INC/ROUBO        ");
            /*"    10       FILLER            PIC  X(057)    VALUE            '2045301RC - DANOS MATERIAIS                       '*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "57", "X(057)"), @"2045301RC - DANOS MATERIAIS                       ");
            /*"    10       FILLER            PIC  X(057)    VALUE            '2055302RC - DANOS CORPORAIS                       '*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "57", "X(057)"), @"2055302RC - DANOS CORPORAIS                       ");
            /*"    10       FILLER            PIC  X(057)    VALUE            '1165303RC - DANOS MORAIS                          '*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "57", "X(057)"), @"1165303RC - DANOS MORAIS                          ");
            /*"    10       FILLER            PIC  X(057)    VALUE            '2085304RC - DEFESA CIVIL                          '*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "57", "X(057)"), @"2085304RC - DEFESA CIVIL                          ");
            /*"    10       FILLER            PIC  X(057)    VALUE            '2075305RC - DEFESA PENAL                          '*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "57", "X(057)"), @"2075305RC - DEFESA PENAL                          ");
            /*"    10       FILLER            PIC  X(057)    VALUE            '2065306RC - OBJETOS TRANSPORTADOS                 '*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "57", "X(057)"), @"2065306RC - OBJETOS TRANSPORTADOS                 ");
            /*"    10       FILLER            PIC  X(057)    VALUE            '2873121INDENIZ POR IMOBILIZACAO - 350, 700 E 1.000'*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "57", "X(057)"), @"2873121INDENIZ POR IMOBILIZACAO - 350, 700 E 1.000");
            /*"    10       FILLER            PIC  X(057)    VALUE            '2643121INDENIZACAO POR IMOBILIZACAO               '*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "57", "X(057)"), @"2643121INDENIZACAO POR IMOBILIZACAO               ");
            /*"    10       FILLER            PIC  X(057)    VALUE            '1192001APO - MORTE (P/ OCUPANTE)                  '*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "57", "X(057)"), @"1192001APO - MORTE (P/ OCUPANTE)                  ");
            /*"    10       FILLER            PIC  X(057)    VALUE            '1202002APO - INV. PERMANENTE (P/ OCUPANTE)        '*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "57", "X(057)"), @"1202002APO - INV. PERMANENTE (P/ OCUPANTE)        ");
            /*"    10       FILLER            PIC  X(057)    VALUE            '2113123ASSISTENCIA DIA E NOITE                    '*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "57", "X(057)"), @"2113123ASSISTENCIA DIA E NOITE                    ");
            /*"    10       FILLER            PIC  X(057)    VALUE            '2803123ASSISTENCIA DIA E NOITE                    '*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "57", "X(057)"), @"2803123ASSISTENCIA DIA E NOITE                    ");
            /*"    10       FILLER            PIC  X(057)    VALUE            '2143105ACESS. REF. A SOM E IMAGEM                 '*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "57", "X(057)"), @"2143105ACESS. REF. A SOM E IMAGEM                 ");
            /*"    10       FILLER            PIC  X(057)    VALUE            '1153124CARRO RESERVA - 7, 15 E 30 DIARIAS         '*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "57", "X(057)"), @"1153124CARRO RESERVA - 7, 15 E 30 DIARIAS         ");
            /*"    10       FILLER            PIC  X(057)    VALUE            '1553124CARRO RESERVA                              '*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "57", "X(057)"), @"1553124CARRO RESERVA                              ");
            /*"    10       FILLER            PIC  X(057)    VALUE            '2263125VIDROS                                     '*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "57", "X(057)"), @"2263125VIDROS                                     ");
            /*"    10       FILLER            PIC  X(057)    VALUE            '3943125VIDROS                                     '*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "57", "X(057)"), @"3943125VIDROS                                     ");
            /*"    10       FILLER            PIC  X(057)    VALUE            '2813129BLINDAGEM                                  '*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "57", "X(057)"), @"2813129BLINDAGEM                                  ");
            /*"    10       FILLER            PIC  X(057)    VALUE            '2823130KIT GAS                                    '*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "57", "X(057)"), @"2823130KIT GAS                                    ");
            /*"    10       FILLER            PIC  X(057)    VALUE            '2273131CARRO RESERVA GRATUITO - 10 DIAS           '*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "57", "X(057)"), @"2273131CARRO RESERVA GRATUITO - 10 DIAS           ");
            /*"    10       FILLER            PIC  X(057)    VALUE            '2883132CARRO RESERVA GRATUITO - 15 DIAS           '*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "57", "X(057)"), @"2883132CARRO RESERVA GRATUITO - 15 DIAS           ");
            /*"    10       FILLER            PIC  X(057)    VALUE            '2773132CARRO RESERVA GRATUITO - 15 DIAS           '*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "57", "X(057)"), @"2773132CARRO RESERVA GRATUITO - 15 DIAS           ");
            /*"    10       FILLER            PIC  X(057)    VALUE            '2903126ASSISTENCIA DIA E NOITE ESPECIAL           '*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "57", "X(057)"), @"2903126ASSISTENCIA DIA E NOITE ESPECIAL           ");
            /*"    10       FILLER            PIC  X(057)    VALUE            '2863110EXT.GAR.VEIC.NOVO-12 MESES INC/ROUBO       '*/
            public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "57", "X(057)"), @"2863110EXT.GAR.VEIC.NOVO-12 MESES INC/ROUBO       ");
            /*"    10       FILLER            PIC  X(057)    VALUE            '3903127ASSISTENCIA DOMICILIAR                     '*/
            public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "57", "X(057)"), @"3903127ASSISTENCIA DOMICILIAR                     ");
            /*"    10       FILLER            PIC  X(057)    VALUE            '1173119EQUIPAMENTOS                               '*/
            public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "57", "X(057)"), @"1173119EQUIPAMENTOS                               ");
            /*"    10       FILLER            PIC  X(057)    VALUE            '2853128ASSISTENCIA A VANS                         '*/
            public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "57", "X(057)"), @"2853128ASSISTENCIA A VANS                         ");
            /*"    10       FILLER            PIC  X(057)    VALUE            '7553125VIDROS                                     '*/
            public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "57", "X(057)"), @"7553125VIDROS                                     ");
            /*"    10       FILLER            PIC  X(057)    VALUE            '7513122ASSISTENCIA VEICULO SEGURADO               '*/
            public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "57", "X(057)"), @"7513122ASSISTENCIA VEICULO SEGURADO               ");
            /*"    10       FILLER            PIC  X(057)    VALUE            '7503123ASSISTENCIA DIA E NOITE                    '*/
            public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "57", "X(057)"), @"7503123ASSISTENCIA DIA E NOITE                    ");
            /*"01       FILLER                 REDEFINES   TABELA-COBERTURAS.*/
        }
        private _REDEF_SI9101B_FILLER_36 _filler_36 { get; set; }
        public _REDEF_SI9101B_FILLER_36 FILLER_36
        {
            get { _filler_36 = new _REDEF_SI9101B_FILLER_36(); _.Move(TABELA_COBERTURAS, _filler_36); VarBasis.RedefinePassValue(TABELA_COBERTURAS, _filler_36, TABELA_COBERTURAS); _filler_36.ValueChanged += () => { _.Move(_filler_36, TABELA_COBERTURAS); }; return _filler_36; }
            set { VarBasis.RedefinePassValue(value, _filler_36, TABELA_COBERTURAS); }
        }  //Redefines
        public class _REDEF_SI9101B_FILLER_36 : VarBasis
        {
            /*"  05     TABC-COBERTURAS        OCCURS      33                                INDEXED BY  IX1.*/
            public ListBasis<SI9101B_TABC_COBERTURAS> TABC_COBERTURAS { get; set; } = new ListBasis<SI9101B_TABC_COBERTURAS>(33);
            public class SI9101B_TABC_COBERTURAS : VarBasis
            {
                /*"    10   TABC-VCRUZ             PIC  9(003).*/
                public IntBasis TABC_VCRUZ { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10   TABC-CAIXA             PIC  9(004).*/
                public IntBasis TABC_CAIXA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10   TABC-DESCR             PIC  X(050).*/
                public StringBasis TABC_DESCR { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
                /*"01       WABEND.*/

                public SI9101B_TABC_COBERTURAS()
                {
                    TABC_VCRUZ.ValueChanged += OnValueChanged;
                    TABC_CAIXA.ValueChanged += OnValueChanged;
                    TABC_DESCR.ValueChanged += OnValueChanged;
                }

            }

            public _REDEF_SI9101B_FILLER_36()
            {
                TABC_COBERTURAS.ValueChanged += OnValueChanged;
            }

        }
        public SI9101B_WABEND WABEND { get; set; } = new SI9101B_WABEND();
        public class SI9101B_WABEND : VarBasis
        {
            /*"  05     FILLER                 PIC  X(010) VALUE        ' SI9101B'.*/
            public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SI9101B");
            /*"  05     FILLER                 PIC  X(026) VALUE        ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"  05     WNR-EXEC-SQL           PIC  X(004) VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"  05     FILLER                 PIC  X(013) VALUE        ' *** SQLCODE '.*/
            public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"  05     WSQLCODE               PIC  ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
        }


        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.APOLIAUT APOLIAUT { get; set; } = new Dclgens.APOLIAUT();
        public Dclgens.AUTOCOBE AUTOCOBE { get; set; } = new Dclgens.AUTOCOBE();
        public Dclgens.APOLCOSS APOLCOSS { get; set; } = new Dclgens.APOLCOSS();
        public Dclgens.SINISCAU SINISCAU { get; set; } = new Dclgens.SINISCAU();
        public Dclgens.SINISCON SINISCON { get; set; } = new Dclgens.SINISCON();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.SINISACO SINISACO { get; set; } = new Dclgens.SINISACO();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.SINIITEM SINIITEM { get; set; } = new Dclgens.SINIITEM();
        public Dclgens.SINISAUT SINISAUT { get; set; } = new Dclgens.SINISAUT();
        public Dclgens.SINIMPSE SINIMPSE { get; set; } = new Dclgens.SINIMPSE();
        public Dclgens.NUMERAES NUMERAES { get; set; } = new Dclgens.NUMERAES();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.SIARDEVC SIARDEVC { get; set; } = new Dclgens.SIARDEVC();
        public Dclgens.PARCEHIS PARCEHIS { get; set; } = new Dclgens.PARCEHIS();
        public SI9101B_C01_SIARDEVC C01_SIARDEVC { get; set; } = new SI9101B_C01_SIARDEVC();
        public SI9101B_C01_APOLIAUT C01_APOLIAUT { get; set; } = new SI9101B_C01_APOLIAUT();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -186- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -187- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -188- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -188- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -196- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", WABEND.WNR_EXEC_SQL);

            /*" -198- PERFORM R0100-00-LE-SISTEMAS */

            R0100_00_LE_SISTEMAS_SECTION();

            /*" -199- PERFORM R0900-00-DECLARA-SIARDEVC */

            R0900_00_DECLARA_SIARDEVC_SECTION();

            /*" -201- PERFORM R0910-00-LE-SIARDEVC */

            R0910_00_LE_SIARDEVC_SECTION();

            /*" -202- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-SIARDEVC NOT EQUAL SPACES. */

            while (!(!WFIM_SIARDEVC.IsEmpty()))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -207- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -208- DISPLAY '*    SI9101B - FIM NORMAL    *' */
            _.Display($"*    SI9101B - FIM NORMAL    *");

            /*" -209- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -210- DISPLAY 'LIDOS     SIARDEVC - ' AC-L-SIARDEVC */
            _.Display($"LIDOS     SIARDEVC - {AC_L_SIARDEVC}");

            /*" -211- DISPLAY 'INSERIDOS SINISCON - ' AC-I-SINISCON */
            _.Display($"INSERIDOS SINISCON - {AC_I_SINISCON}");

            /*" -212- DISPLAY '          SINISACO - ' AC-I-SINISACO */
            _.Display($"          SINISACO - {AC_I_SINISACO}");

            /*" -213- DISPLAY '          SINISMES - ' AC-I-SINISMES */
            _.Display($"          SINISMES - {AC_I_SINISMES}");

            /*" -214- DISPLAY '          SINIITEM - ' AC-I-SINIITEM */
            _.Display($"          SINIITEM - {AC_I_SINIITEM}");

            /*" -215- DISPLAY '          SINISHIS - ' AC-I-SINISHIS */
            _.Display($"          SINISHIS - {AC_I_SINISHIS}");

            /*" -216- DISPLAY '          SINISAUT - ' AC-I-SINISAUT */
            _.Display($"          SINISAUT - {AC_I_SINISAUT}");

            /*" -217- DISPLAY '          SINIMPSE - ' AC-I-SINIMPSE */
            _.Display($"          SINIMPSE - {AC_I_SINIMPSE}");

            /*" -219- DISPLAY 'ALTERADOS SIARDEVC - ' AC-U-SIARDEVC */
            _.Display($"ALTERADOS SIARDEVC - {AC_U_SIARDEVC}");

            /*" -221- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -221- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0100-00-LE-SISTEMAS-SECTION */
        private void R0100_00_LE_SISTEMAS_SECTION()
        {
            /*" -229- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", WABEND.WNR_EXEC_SQL);

            /*" -234- PERFORM R0100_00_LE_SISTEMAS_DB_SELECT_1 */

            R0100_00_LE_SISTEMAS_DB_SELECT_1();

            /*" -237- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -238- DISPLAY 'PROBLEMAS NO SELECT SISTEMAS' */
                _.Display($"PROBLEMAS NO SELECT SISTEMAS");

                /*" -240- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -241- DISPLAY 'DATA DO SISTEMA DE SINISTRO -' ' ' SISTEMAS-DATA-MOV-ABERTO. */

            $"DATA DO SISTEMA DE SINISTRO - {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}"
            .Display();

        }

        [StopWatch]
        /*" R0100-00-LE-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_LE_SISTEMAS_DB_SELECT_1()
        {
            /*" -234- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' END-EXEC. */

            var r0100_00_LE_SISTEMAS_DB_SELECT_1_Query1 = new R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1.Execute(r0100_00_LE_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARA-SIARDEVC-SECTION */
        private void R0900_00_DECLARA_SIARDEVC_SECTION()
        {
            /*" -251- MOVE '0900' TO WNR-EXEC-SQL. */
            _.Move("0900", WABEND.WNR_EXEC_SQL);

            /*" -276- PERFORM R0900_00_DECLARA_SIARDEVC_DB_DECLARE_1 */

            R0900_00_DECLARA_SIARDEVC_DB_DECLARE_1();

            /*" -278- PERFORM R0900_00_DECLARA_SIARDEVC_DB_OPEN_1 */

            R0900_00_DECLARA_SIARDEVC_DB_OPEN_1();

            /*" -281- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -282- DISPLAY 'PROBLEMAS NO OPEN SIARDEVC' */
                _.Display($"PROBLEMAS NO OPEN SIARDEVC");

                /*" -282- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARA-SIARDEVC-DB-DECLARE-1 */
        public void R0900_00_DECLARA_SIARDEVC_DB_DECLARE_1()
        {
            /*" -276- EXEC SQL DECLARE C01_SIARDEVC CURSOR FOR SELECT NOM_ARQUIVO, SEQ_GERACAO, TIPO_REGISTRO, SEQ_REGISTRO, COD_OPERACAO, NUM_APOLICE, NUM_ENDOSSO, NUM_ITEM, COD_RAMO, COD_COBERTURA, DATA_COMUNICADO, DATA_OCORRENCIA, NUM_ITEM, COD_CAUSA, VAL_TOT_MOVIMENTO, NUM_SINISTRO_VC FROM SEGUROS.SI_AR_DETALHE_VC WHERE NOM_ARQUIVO = 'VCMOVSIN' AND COD_OPERACAO = 0101 AND STA_PROCESSAMENTO = '0' ORDER BY NUM_APOLICE, NUM_ITEM, DATA_OCORRENCIA END-EXEC. */
            C01_SIARDEVC = new SI9101B_C01_SIARDEVC(false);
            string GetQuery_C01_SIARDEVC()
            {
                var query = @$"SELECT NOM_ARQUIVO
							, 
							SEQ_GERACAO
							, 
							TIPO_REGISTRO
							, 
							SEQ_REGISTRO
							, 
							COD_OPERACAO
							, 
							NUM_APOLICE
							, 
							NUM_ENDOSSO
							, 
							NUM_ITEM
							, 
							COD_RAMO
							, 
							COD_COBERTURA
							, 
							DATA_COMUNICADO
							, 
							DATA_OCORRENCIA
							, 
							NUM_ITEM
							, 
							COD_CAUSA
							, 
							VAL_TOT_MOVIMENTO
							, 
							NUM_SINISTRO_VC 
							FROM SEGUROS.SI_AR_DETALHE_VC 
							WHERE NOM_ARQUIVO = 'VCMOVSIN' 
							AND COD_OPERACAO = 0101 
							AND STA_PROCESSAMENTO = '0' 
							ORDER BY NUM_APOLICE
							, 
							NUM_ITEM
							, 
							DATA_OCORRENCIA";

                return query;
            }
            C01_SIARDEVC.GetQueryEvent += GetQuery_C01_SIARDEVC;

        }

        [StopWatch]
        /*" R0900-00-DECLARA-SIARDEVC-DB-OPEN-1 */
        public void R0900_00_DECLARA_SIARDEVC_DB_OPEN_1()
        {
            /*" -278- EXEC SQL OPEN C01_SIARDEVC END-EXEC. */

            C01_SIARDEVC.Open();

        }

        [StopWatch]
        /*" R1200-00-LE-APOLIAUT-DB-DECLARE-1 */
        public void R1200_00_LE_APOLIAUT_DB_DECLARE_1()
        {
            /*" -528- EXEC SQL DECLARE C01_APOLIAUT CURSOR FOR SELECT NUM_ITEM, NUM_ENDOSSO, DATA_INIVIGENCIA, SIT_REGISTRO FROM SEGUROS.APOLICE_AUTO WHERE NUM_APOLICE = :SIARDEVC-NUM-APOLICE AND NUM_ITEM >= :HOST-NUM-ITEM-INI AND NUM_ITEM <= :HOST-NUM-ITEM-FIM AND DATA_INIVIGENCIA <= :SIARDEVC-DATA-OCORRENCIA AND DATA_TERVIGENCIA >= :SIARDEVC-DATA-OCORRENCIA AND SIT_REGISTRO = ' ' ORDER BY DATA_INIVIGENCIA DESC END-EXEC */
            C01_APOLIAUT = new SI9101B_C01_APOLIAUT(true);
            string GetQuery_C01_APOLIAUT()
            {
                var query = @$"SELECT NUM_ITEM
							, 
							NUM_ENDOSSO
							, 
							DATA_INIVIGENCIA
							, 
							SIT_REGISTRO 
							FROM SEGUROS.APOLICE_AUTO 
							WHERE NUM_APOLICE = '{SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE}' 
							AND NUM_ITEM >= '{HOST_NUM_ITEM_INI}' 
							AND NUM_ITEM <= '{HOST_NUM_ITEM_FIM}' 
							AND DATA_INIVIGENCIA <= '{SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_OCORRENCIA}' 
							AND DATA_TERVIGENCIA >= '{SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_OCORRENCIA}' 
							AND SIT_REGISTRO = ' ' 
							ORDER BY DATA_INIVIGENCIA DESC";

                return query;
            }
            C01_APOLIAUT.GetQueryEvent += GetQuery_C01_APOLIAUT;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-LE-SIARDEVC-SECTION */
        private void R0910_00_LE_SIARDEVC_SECTION()
        {
            /*" -292- MOVE '0910' TO WNR-EXEC-SQL. */
            _.Move("0910", WABEND.WNR_EXEC_SQL);

            /*" -309- PERFORM R0910_00_LE_SIARDEVC_DB_FETCH_1 */

            R0910_00_LE_SIARDEVC_DB_FETCH_1();

            /*" -312- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -313- ADD 1 TO AC-L-SIARDEVC */
                AC_L_SIARDEVC.Value = AC_L_SIARDEVC + 1;

                /*" -314- ELSE */
            }
            else
            {


                /*" -315- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -316- MOVE 'S' TO WFIM-SIARDEVC */
                    _.Move("S", WFIM_SIARDEVC);

                    /*" -316- PERFORM R0910_00_LE_SIARDEVC_DB_CLOSE_1 */

                    R0910_00_LE_SIARDEVC_DB_CLOSE_1();

                    /*" -318- ELSE */
                }
                else
                {


                    /*" -319- DISPLAY 'PROBLEMAS NO FETCH SIARDEVC' */
                    _.Display($"PROBLEMAS NO FETCH SIARDEVC");

                    /*" -319- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0910-00-LE-SIARDEVC-DB-FETCH-1 */
        public void R0910_00_LE_SIARDEVC_DB_FETCH_1()
        {
            /*" -309- EXEC SQL FETCH C01_SIARDEVC INTO :SIARDEVC-NOM-ARQUIVO, :SIARDEVC-SEQ-GERACAO, :SIARDEVC-TIPO-REGISTRO, :SIARDEVC-SEQ-REGISTRO, :SIARDEVC-COD-OPERACAO, :SIARDEVC-NUM-APOLICE, :SIARDEVC-NUM-ENDOSSO, :SIARDEVC-NUM-ITEM, :SIARDEVC-COD-RAMO, :SIARDEVC-COD-COBERTURA, :SIARDEVC-DATA-COMUNICADO, :SIARDEVC-DATA-OCORRENCIA, :SIARDEVC-NUM-ITEM, :SIARDEVC-COD-CAUSA, :SIARDEVC-VAL-TOT-MOVIMENTO, :SIARDEVC-NUM-SINISTRO-VC END-EXEC. */

            if (C01_SIARDEVC.Fetch())
            {
                _.Move(C01_SIARDEVC.SIARDEVC_NOM_ARQUIVO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO);
                _.Move(C01_SIARDEVC.SIARDEVC_SEQ_GERACAO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO);
                _.Move(C01_SIARDEVC.SIARDEVC_TIPO_REGISTRO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO);
                _.Move(C01_SIARDEVC.SIARDEVC_SEQ_REGISTRO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO);
                _.Move(C01_SIARDEVC.SIARDEVC_COD_OPERACAO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_OPERACAO);
                _.Move(C01_SIARDEVC.SIARDEVC_NUM_APOLICE, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE);
                _.Move(C01_SIARDEVC.SIARDEVC_NUM_ENDOSSO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_ENDOSSO);
                _.Move(C01_SIARDEVC.SIARDEVC_NUM_ITEM, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_ITEM);
                _.Move(C01_SIARDEVC.SIARDEVC_COD_RAMO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_RAMO);
                _.Move(C01_SIARDEVC.SIARDEVC_COD_COBERTURA, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_COBERTURA);
                _.Move(C01_SIARDEVC.SIARDEVC_DATA_COMUNICADO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_COMUNICADO);
                _.Move(C01_SIARDEVC.SIARDEVC_DATA_OCORRENCIA, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_OCORRENCIA);
                _.Move(C01_SIARDEVC.SIARDEVC_NUM_ITEM, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_ITEM);
                _.Move(C01_SIARDEVC.SIARDEVC_COD_CAUSA, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_CAUSA);
                _.Move(C01_SIARDEVC.SIARDEVC_VAL_TOT_MOVIMENTO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_TOT_MOVIMENTO);
                _.Move(C01_SIARDEVC.SIARDEVC_NUM_SINISTRO_VC, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_SINISTRO_VC);
            }

        }

        [StopWatch]
        /*" R0910-00-LE-SIARDEVC-DB-CLOSE-1 */
        public void R0910_00_LE_SIARDEVC_DB_CLOSE_1()
        {
            /*" -316- EXEC SQL CLOSE C01_SIARDEVC END-EXEC */

            C01_SIARDEVC.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -346- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", WABEND.WNR_EXEC_SQL);

            /*" -348- PERFORM R1100-00-LE-ENDOSSOS */

            R1100_00_LE_ENDOSSOS_SECTION();

            /*" -350- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -351- MOVE 10 TO SIARDEVC-COD-ERRO */
                _.Move(10, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO);

                /*" -352- MOVE 0 TO IND-COD-ERRO */
                _.Move(0, IND_COD_ERRO);

                /*" -353- MOVE '2' TO SIARDEVC-STA-PROCESSAMENTO */
                _.Move("2", SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO);

                /*" -355- MOVE ZEROS TO SIARDEVC-NUM-APOL-SINISTRO SIARDEVC-OCORR-HISTORICO */
                _.Move(0, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO);

                /*" -359- GO TO R1000-10-LER. */

                R1000_10_LER(); //GOTO
                return;
            }


            /*" -361- IF ENDOSSOS-SIT-REGISTRO EQUAL '2' */

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_SIT_REGISTRO == "2")
            {

                /*" -362- MOVE 'N' TO WS-REJEITA-AVISO */
                _.Move("N", WS_REJEITA_AVISO);

                /*" -363- PERFORM R1600-00-VER-CANCELAMENTO */

                R1600_00_VER_CANCELAMENTO_SECTION();

                /*" -365- IF WS-REJEITA-AVISO EQUAL 'S' */

                if (WS_REJEITA_AVISO == "S")
                {

                    /*" -366- MOVE 11 TO SIARDEVC-COD-ERRO */
                    _.Move(11, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO);

                    /*" -367- MOVE 0 TO IND-COD-ERRO */
                    _.Move(0, IND_COD_ERRO);

                    /*" -368- MOVE '2' TO SIARDEVC-STA-PROCESSAMENTO */
                    _.Move("2", SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO);

                    /*" -370- MOVE ZEROS TO SIARDEVC-NUM-APOL-SINISTRO SIARDEVC-OCORR-HISTORICO */
                    _.Move(0, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO);

                    /*" -374- GO TO R1000-10-LER. */

                    R1000_10_LER(); //GOTO
                    return;
                }

            }


            /*" -375- MOVE 01 TO WS-NUM-ITEM */
            _.Move(01, WS_NUM_ITEM);

            /*" -377- MOVE SIARDEVC-NUM-ITEM TO WS-ITEM */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_ITEM, FILLER_1.WS_ITEM);

            /*" -379- MOVE WS-NUM-ITEM TO HOST-NUM-ITEM-INI */
            _.Move(WS_NUM_ITEM, HOST_NUM_ITEM_INI);

            /*" -380- MOVE 99 TO WS-NUM-ITEM */
            _.Move(99, WS_NUM_ITEM);

            /*" -382- MOVE SIARDEVC-NUM-ITEM TO WS-ITEM */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_ITEM, FILLER_1.WS_ITEM);

            /*" -384- MOVE WS-NUM-ITEM TO HOST-NUM-ITEM-FIM */
            _.Move(WS_NUM_ITEM, HOST_NUM_ITEM_FIM);

            /*" -386- PERFORM R1200-00-LE-APOLIAUT */

            R1200_00_LE_APOLIAUT_SECTION();

            /*" -388- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -389- MOVE 12 TO SIARDEVC-COD-ERRO */
                _.Move(12, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO);

                /*" -390- MOVE 0 TO IND-COD-ERRO */
                _.Move(0, IND_COD_ERRO);

                /*" -391- MOVE '2' TO SIARDEVC-STA-PROCESSAMENTO */
                _.Move("2", SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO);

                /*" -393- MOVE ZEROS TO SIARDEVC-NUM-APOL-SINISTRO SIARDEVC-OCORR-HISTORICO */
                _.Move(0, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO);

                /*" -395- GO TO R1000-10-LER. */

                R1000_10_LER(); //GOTO
                return;
            }


            /*" -398- IF APOLIAUT-SIT-REGISTRO EQUAL '2' */

            if (APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_SIT_REGISTRO == "2")
            {

                /*" -399- MOVE 13 TO SIARDEVC-COD-ERRO */
                _.Move(13, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO);

                /*" -400- MOVE 0 TO IND-COD-ERRO */
                _.Move(0, IND_COD_ERRO);

                /*" -401- MOVE '2' TO SIARDEVC-STA-PROCESSAMENTO */
                _.Move("2", SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO);

                /*" -403- MOVE ZEROS TO SIARDEVC-NUM-APOL-SINISTRO SIARDEVC-OCORR-HISTORICO */
                _.Move(0, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO);

                /*" -407- GO TO R1000-10-LER. */

                R1000_10_LER(); //GOTO
                return;
            }


            /*" -411- PERFORM R1300-00-LE-ENDOSSOS */

            R1300_00_LE_ENDOSSOS_SECTION();

            /*" -413- PERFORM R1450-00-OBTEM-COBERTURA */

            R1450_00_OBTEM_COBERTURA_SECTION();

            /*" -415- IF WTEM-COBERTURA EQUAL 'N' */

            if (WTEM_COBERTURA == "N")
            {

                /*" -416- MOVE 14 TO SIARDEVC-COD-ERRO */
                _.Move(14, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO);

                /*" -417- MOVE 0 TO IND-COD-ERRO */
                _.Move(0, IND_COD_ERRO);

                /*" -418- MOVE '2' TO SIARDEVC-STA-PROCESSAMENTO */
                _.Move("2", SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO);

                /*" -420- MOVE ZEROS TO SIARDEVC-NUM-APOL-SINISTRO SIARDEVC-OCORR-HISTORICO */
                _.Move(0, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO);

                /*" -422- GO TO R1000-10-LER. */

                R1000_10_LER(); //GOTO
                return;
            }


            /*" -424- PERFORM R1400-00-LE-AUTOCOBE */

            R1400_00_LE_AUTOCOBE_SECTION();

            /*" -426- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -427- MOVE 15 TO SIARDEVC-COD-ERRO */
                _.Move(15, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO);

                /*" -428- MOVE 0 TO IND-COD-ERRO */
                _.Move(0, IND_COD_ERRO);

                /*" -429- MOVE '2' TO SIARDEVC-STA-PROCESSAMENTO */
                _.Move("2", SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO);

                /*" -431- MOVE ZEROS TO SIARDEVC-NUM-APOL-SINISTRO SIARDEVC-OCORR-HISTORICO */
                _.Move(0, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO);

                /*" -433- GO TO R1000-10-LER. */

                R1000_10_LER(); //GOTO
                return;
            }


            /*" -436- IF AUTOCOBE-SIT-REGISTRO EQUAL '2' */

            if (AUTOCOBE.DCLAUTO_COBERTURAS.AUTOCOBE_SIT_REGISTRO == "2")
            {

                /*" -437- MOVE 16 TO SIARDEVC-COD-ERRO */
                _.Move(16, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO);

                /*" -438- MOVE 0 TO IND-COD-ERRO */
                _.Move(0, IND_COD_ERRO);

                /*" -439- MOVE '2' TO SIARDEVC-STA-PROCESSAMENTO */
                _.Move("2", SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO);

                /*" -441- MOVE ZEROS TO SIARDEVC-NUM-APOL-SINISTRO SIARDEVC-OCORR-HISTORICO */
                _.Move(0, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO);

                /*" -445- GO TO R1000-10-LER. */

                R1000_10_LER(); //GOTO
                return;
            }


            /*" -447- PERFORM R1500-LE-SINISCAU */

            R1500_LE_SINISCAU_SECTION();

            /*" -449- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -450- MOVE 17 TO SIARDEVC-COD-ERRO */
                _.Move(17, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO);

                /*" -451- MOVE 0 TO IND-COD-ERRO */
                _.Move(0, IND_COD_ERRO);

                /*" -452- MOVE '2' TO SIARDEVC-STA-PROCESSAMENTO */
                _.Move("2", SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO);

                /*" -454- MOVE ZEROS TO SIARDEVC-NUM-APOL-SINISTRO SIARDEVC-OCORR-HISTORICO */
                _.Move(0, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO);

                /*" -458- GO TO R1000-10-LER. */

                R1000_10_LER(); //GOTO
                return;
            }


            /*" -459- IF AUTOCOBE-COD-COBERTURA EQUAL 3125 */

            if (AUTOCOBE.DCLAUTO_COBERTURAS.AUTOCOBE_COD_COBERTURA == 3125)
            {

                /*" -461- IF SIARDEVC-COD-CAUSA NOT EQUAL 6 */

                if (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_CAUSA != 6)
                {

                    /*" -462- MOVE 66 TO SIARDEVC-COD-ERRO */
                    _.Move(66, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO);

                    /*" -463- MOVE ZEROS TO IND-COD-ERRO */
                    _.Move(0, IND_COD_ERRO);

                    /*" -464- MOVE '2' TO SIARDEVC-STA-PROCESSAMENTO */
                    _.Move("2", SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO);

                    /*" -465- MOVE ZEROS TO SIARDEVC-NUM-APOL-SINISTRO */
                    _.Move(0, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO);

                    /*" -466- MOVE ZEROS TO SIARDEVC-OCORR-HISTORICO */
                    _.Move(0, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO);

                    /*" -467- GO TO R1000-10-LER */

                    R1000_10_LER(); //GOTO
                    return;

                    /*" -468- END-IF */
                }


                /*" -470- END-IF. */
            }


            /*" -472- PERFORM R2000-00-GERA-SINISTRO */

            R2000_00_GERA_SINISTRO_SECTION();

            /*" -473- MOVE 0 TO SIARDEVC-COD-ERRO */
            _.Move(0, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO);

            /*" -474- MOVE -1 TO IND-COD-ERRO */
            _.Move(-1, IND_COD_ERRO);

            /*" -475- MOVE '1' TO SIARDEVC-STA-PROCESSAMENTO */
            _.Move("1", SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO);

            /*" -477- MOVE SINISMES-NUM-APOL-SINISTRO TO SIARDEVC-NUM-APOL-SINISTRO */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO);

            /*" -477- MOVE 1 TO SIARDEVC-OCORR-HISTORICO. */
            _.Move(1, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO);

            /*" -0- FLUXCONTROL_PERFORM R1000_10_LER */

            R1000_10_LER();

        }

        [StopWatch]
        /*" R1000-10-LER */
        private void R1000_10_LER(bool isPerform = false)
        {
            /*" -483- PERFORM R3100-00-ALTERA-SIARDEVC */

            R3100_00_ALTERA_SIARDEVC_SECTION();

            /*" -483- PERFORM R0910-00-LE-SIARDEVC. */

            R0910_00_LE_SIARDEVC_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-LE-ENDOSSOS-SECTION */
        private void R1100_00_LE_ENDOSSOS_SECTION()
        {
            /*" -493- MOVE '1100' TO WNR-EXEC-SQL */
            _.Move("1100", WABEND.WNR_EXEC_SQL);

            /*" -499- PERFORM R1100_00_LE_ENDOSSOS_DB_SELECT_1 */

            R1100_00_LE_ENDOSSOS_DB_SELECT_1();

            /*" -502- IF SQLCODE NOT EQUAL 0 AND 100 */

            if (!DB.SQLCODE.In("0", "100"))
            {

                /*" -505- DISPLAY 'PROBLEMAS NO SELECT ENDOSSOS' ' ' SIARDEVC-NUM-APOLICE ' ' SIARDEVC-NUM-ENDOSSO */

                $"PROBLEMAS NO SELECT ENDOSSOS {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_ENDOSSO}"
                .Display();

                /*" -505- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1100-00-LE-ENDOSSOS-DB-SELECT-1 */
        public void R1100_00_LE_ENDOSSOS_DB_SELECT_1()
        {
            /*" -499- EXEC SQL SELECT SIT_REGISTRO INTO :ENDOSSOS-SIT-REGISTRO FROM SEGUROS.ENDOSSOS WHERE NUM_APOLICE = :SIARDEVC-NUM-APOLICE AND NUM_ENDOSSO = 0 END-EXEC */

            var r1100_00_LE_ENDOSSOS_DB_SELECT_1_Query1 = new R1100_00_LE_ENDOSSOS_DB_SELECT_1_Query1()
            {
                SIARDEVC_NUM_APOLICE = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1100_00_LE_ENDOSSOS_DB_SELECT_1_Query1.Execute(r1100_00_LE_ENDOSSOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDOSSOS_SIT_REGISTRO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_SIT_REGISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-LE-APOLIAUT-SECTION */
        private void R1200_00_LE_APOLIAUT_SECTION()
        {
            /*" -515- MOVE '1200' TO WNR-EXEC-SQL */
            _.Move("1200", WABEND.WNR_EXEC_SQL);

            /*" -528- PERFORM R1200_00_LE_APOLIAUT_DB_DECLARE_1 */

            R1200_00_LE_APOLIAUT_DB_DECLARE_1();

            /*" -530- PERFORM R1200_00_LE_APOLIAUT_DB_OPEN_1 */

            R1200_00_LE_APOLIAUT_DB_OPEN_1();

            /*" -533- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -538- DISPLAY 'PROBLEMAS NO OPEN APOLICE_AUTO' ' ' SIARDEVC-NUM-APOLICE ' ' SIARDEVC-NUM-ENDOSSO ' ' HOST-NUM-ITEM-INI ' ' HOST-NUM-ITEM-FIM */

                $"PROBLEMAS NO OPEN APOLICE_AUTO {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_ENDOSSO} {HOST_NUM_ITEM_INI} {HOST_NUM_ITEM_FIM}"
                .Display();

                /*" -540- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -545- PERFORM R1200_00_LE_APOLIAUT_DB_FETCH_1 */

            R1200_00_LE_APOLIAUT_DB_FETCH_1();

            /*" -548- IF SQLCODE NOT EQUAL 0 AND 100 */

            if (!DB.SQLCODE.In("0", "100"))
            {

                /*" -553- DISPLAY 'PROBLEMAS NO FETCH APOLICE_AUTO' ' ' SIARDEVC-NUM-APOLICE ' ' SIARDEVC-NUM-ENDOSSO ' ' HOST-NUM-ITEM-INI ' ' HOST-NUM-ITEM-FIM */

                $"PROBLEMAS NO FETCH APOLICE_AUTO {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_ENDOSSO} {HOST_NUM_ITEM_INI} {HOST_NUM_ITEM_FIM}"
                .Display();

                /*" -555- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -555- PERFORM R1200_00_LE_APOLIAUT_DB_CLOSE_1 */

            R1200_00_LE_APOLIAUT_DB_CLOSE_1();

        }

        [StopWatch]
        /*" R1200-00-LE-APOLIAUT-DB-OPEN-1 */
        public void R1200_00_LE_APOLIAUT_DB_OPEN_1()
        {
            /*" -530- EXEC SQL OPEN C01_APOLIAUT END-EXEC */

            C01_APOLIAUT.Open();

        }

        [StopWatch]
        /*" R1200-00-LE-APOLIAUT-DB-FETCH-1 */
        public void R1200_00_LE_APOLIAUT_DB_FETCH_1()
        {
            /*" -545- EXEC SQL FETCH C01_APOLIAUT INTO :APOLIAUT-NUM-ITEM, :APOLIAUT-NUM-ENDOSSO, :APOLIAUT-DATA-INIVIGENCIA, :APOLIAUT-SIT-REGISTRO END-EXEC */

            if (C01_APOLIAUT.Fetch())
            {
                _.Move(C01_APOLIAUT.APOLIAUT_NUM_ITEM, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_ITEM);
                _.Move(C01_APOLIAUT.APOLIAUT_NUM_ENDOSSO, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_ENDOSSO);
                _.Move(C01_APOLIAUT.APOLIAUT_DATA_INIVIGENCIA, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_DATA_INIVIGENCIA);
                _.Move(C01_APOLIAUT.APOLIAUT_SIT_REGISTRO, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_SIT_REGISTRO);
            }

        }

        [StopWatch]
        /*" R1200-00-LE-APOLIAUT-DB-CLOSE-1 */
        public void R1200_00_LE_APOLIAUT_DB_CLOSE_1()
        {
            /*" -555- EXEC SQL CLOSE C01_APOLIAUT END-EXEC. */

            C01_APOLIAUT.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-LE-ENDOSSOS-SECTION */
        private void R1300_00_LE_ENDOSSOS_SECTION()
        {
            /*" -565- MOVE '1300' TO WNR-EXEC-SQL */
            _.Move("1300", WABEND.WNR_EXEC_SQL);

            /*" -579- PERFORM R1300_00_LE_ENDOSSOS_DB_SELECT_1 */

            R1300_00_LE_ENDOSSOS_DB_SELECT_1();

            /*" -582- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -585- DISPLAY 'PROBLEMAS NO SELECT ENDOSSOS/APOLICES' ' ' SIARDEVC-NUM-APOLICE ' ' APOLIAUT-NUM-ENDOSSO */

                $"PROBLEMAS NO SELECT ENDOSSOS/APOLICES {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE} {APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_ENDOSSO}"
                .Display();

                /*" -585- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1300-00-LE-ENDOSSOS-DB-SELECT-1 */
        public void R1300_00_LE_ENDOSSOS_DB_SELECT_1()
        {
            /*" -579- EXEC SQL SELECT A.COD_PRODUTO, A.COD_FONTE, B.ORGAO_EMISSOR, B.COD_CLIENTE INTO :ENDOSSOS-COD-PRODUTO, :ENDOSSOS-COD-FONTE, :APOLICES-ORGAO-EMISSOR, :APOLICES-COD-CLIENTE FROM SEGUROS.ENDOSSOS A, SEGUROS.APOLICES B WHERE A.NUM_APOLICE = B.NUM_APOLICE AND A.NUM_APOLICE = :SIARDEVC-NUM-APOLICE AND A.NUM_ENDOSSO = :APOLIAUT-NUM-ENDOSSO END-EXEC */

            var r1300_00_LE_ENDOSSOS_DB_SELECT_1_Query1 = new R1300_00_LE_ENDOSSOS_DB_SELECT_1_Query1()
            {
                SIARDEVC_NUM_APOLICE = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE.ToString(),
                APOLIAUT_NUM_ENDOSSO = APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = R1300_00_LE_ENDOSSOS_DB_SELECT_1_Query1.Execute(r1300_00_LE_ENDOSSOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDOSSOS_COD_PRODUTO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO);
                _.Move(executed_1.ENDOSSOS_COD_FONTE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE);
                _.Move(executed_1.APOLICES_ORGAO_EMISSOR, APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR);
                _.Move(executed_1.APOLICES_COD_CLIENTE, APOLICES.DCLAPOLICES.APOLICES_COD_CLIENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-LE-AUTOCOBE-SECTION */
        private void R1400_00_LE_AUTOCOBE_SECTION()
        {
            /*" -595- MOVE '1400' TO WNR-EXEC-SQL */
            _.Move("1400", WABEND.WNR_EXEC_SQL);

            /*" -607- PERFORM R1400_00_LE_AUTOCOBE_DB_SELECT_1 */

            R1400_00_LE_AUTOCOBE_DB_SELECT_1();

            /*" -610- IF SQLCODE EQUAL -811 */

            if (DB.SQLCODE == -811)
            {

                /*" -616- DISPLAY 'MAIS DE UM REGISTRO NA AUTO_COBERTURAS...' ' ' SIARDEVC-NUM-APOLICE ' ' APOLIAUT-NUM-ITEM ' ' SIARDEVC-COD-RAMO ' ' AUTOCOBE-COD-COBERTURA ' ' SIARDEVC-DATA-OCORRENCIA */

                $"MAIS DE UM REGISTRO NA AUTO_COBERTURAS... {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE} {APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_ITEM} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_RAMO} {AUTOCOBE.DCLAUTO_COBERTURAS.AUTOCOBE_COD_COBERTURA} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_OCORRENCIA}"
                .Display();

                /*" -617- PERFORM R1410-00-LE-AUTOCOBE */

                R1410_00_LE_AUTOCOBE_SECTION();

                /*" -618- ELSE */
            }
            else
            {


                /*" -619- IF SQLCODE NOT EQUAL 0 AND 100 */

                if (!DB.SQLCODE.In("0", "100"))
                {

                    /*" -625- DISPLAY 'PROBLEMAS NO SELECT AUTO_COBERTURAS' ' ' SIARDEVC-NUM-APOLICE ' ' APOLIAUT-NUM-ITEM ' ' SIARDEVC-COD-RAMO ' ' AUTOCOBE-COD-COBERTURA ' ' SIARDEVC-DATA-OCORRENCIA */

                    $"PROBLEMAS NO SELECT AUTO_COBERTURAS {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE} {APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_ITEM} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_RAMO} {AUTOCOBE.DCLAUTO_COBERTURAS.AUTOCOBE_COD_COBERTURA} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_OCORRENCIA}"
                    .Display();

                    /*" -625- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1400-00-LE-AUTOCOBE-DB-SELECT-1 */
        public void R1400_00_LE_AUTOCOBE_DB_SELECT_1()
        {
            /*" -607- EXEC SQL SELECT IMP_SEGURADA_IX, SIT_REGISTRO INTO :AUTOCOBE-IMP-SEGURADA-IX, :AUTOCOBE-SIT-REGISTRO FROM SEGUROS.AUTO_COBERTURAS WHERE NUM_APOLICE = :SIARDEVC-NUM-APOLICE AND NUM_ITEM = :APOLIAUT-NUM-ITEM AND RAMO_COBERTURA = :SIARDEVC-COD-RAMO AND COD_COBERTURA = :AUTOCOBE-COD-COBERTURA AND DATA_INIVIGENCIA <= :SIARDEVC-DATA-OCORRENCIA AND DATA_TERVIGENCIA >= :SIARDEVC-DATA-OCORRENCIA END-EXEC */

            var r1400_00_LE_AUTOCOBE_DB_SELECT_1_Query1 = new R1400_00_LE_AUTOCOBE_DB_SELECT_1_Query1()
            {
                SIARDEVC_DATA_OCORRENCIA = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_OCORRENCIA.ToString(),
                AUTOCOBE_COD_COBERTURA = AUTOCOBE.DCLAUTO_COBERTURAS.AUTOCOBE_COD_COBERTURA.ToString(),
                SIARDEVC_NUM_APOLICE = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE.ToString(),
                APOLIAUT_NUM_ITEM = APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_ITEM.ToString(),
                SIARDEVC_COD_RAMO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_RAMO.ToString(),
            };

            var executed_1 = R1400_00_LE_AUTOCOBE_DB_SELECT_1_Query1.Execute(r1400_00_LE_AUTOCOBE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AUTOCOBE_IMP_SEGURADA_IX, AUTOCOBE.DCLAUTO_COBERTURAS.AUTOCOBE_IMP_SEGURADA_IX);
                _.Move(executed_1.AUTOCOBE_SIT_REGISTRO, AUTOCOBE.DCLAUTO_COBERTURAS.AUTOCOBE_SIT_REGISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1410-00-LE-AUTOCOBE-SECTION */
        private void R1410_00_LE_AUTOCOBE_SECTION()
        {
            /*" -635- MOVE '1410' TO WNR-EXEC-SQL */
            _.Move("1410", WABEND.WNR_EXEC_SQL);

            /*" -657- PERFORM R1410_00_LE_AUTOCOBE_DB_SELECT_1 */

            R1410_00_LE_AUTOCOBE_DB_SELECT_1();

            /*" -660- IF SQLCODE NOT EQUAL 0 AND 100 */

            if (!DB.SQLCODE.In("0", "100"))
            {

                /*" -667- DISPLAY 'PROBLEMAS NO SELECT2 AUTO_COBERTURAS' ' ' SIARDEVC-NUM-APOLICE ' ' APOLIAUT-NUM-ITEM ' ' APOLIAUT-NUM-ENDOSSO ' ' SIARDEVC-COD-RAMO ' ' AUTOCOBE-COD-COBERTURA ' ' SIARDEVC-DATA-OCORRENCIA */

                $"PROBLEMAS NO SELECT2 AUTO_COBERTURAS {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE} {APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_ITEM} {APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_ENDOSSO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_RAMO} {AUTOCOBE.DCLAUTO_COBERTURAS.AUTOCOBE_COD_COBERTURA} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_OCORRENCIA}"
                .Display();

                /*" -667- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1410-00-LE-AUTOCOBE-DB-SELECT-1 */
        public void R1410_00_LE_AUTOCOBE_DB_SELECT_1()
        {
            /*" -657- EXEC SQL SELECT A.IMP_SEGURADA_IX, A.SIT_REGISTRO INTO :AUTOCOBE-IMP-SEGURADA-IX, :AUTOCOBE-SIT-REGISTRO FROM SEGUROS.AUTO_COBERTURAS A WHERE A.NUM_APOLICE = :SIARDEVC-NUM-APOLICE AND A.NUM_ITEM = :APOLIAUT-NUM-ITEM AND A.NUM_ENDOSSO = :APOLIAUT-NUM-ENDOSSO AND A.RAMO_COBERTURA = :SIARDEVC-COD-RAMO AND A.COD_COBERTURA = :AUTOCOBE-COD-COBERTURA AND A.DATA_INIVIGENCIA = (SELECT MAX(B.DATA_INIVIGENCIA) FROM SEGUROS.AUTO_COBERTURAS B WHERE B.NUM_APOLICE = :SIARDEVC-NUM-APOLICE AND B.NUM_ITEM = :APOLIAUT-NUM-ITEM AND B.NUM_ENDOSSO = :APOLIAUT-NUM-ENDOSSO AND B.RAMO_COBERTURA = :SIARDEVC-COD-RAMO AND B.COD_COBERTURA = :AUTOCOBE-COD-COBERTURA AND B.DATA_INIVIGENCIA <= :SIARDEVC-DATA-OCORRENCIA AND B.DATA_TERVIGENCIA >= :SIARDEVC-DATA-OCORRENCIA) END-EXEC */

            var r1410_00_LE_AUTOCOBE_DB_SELECT_1_Query1 = new R1410_00_LE_AUTOCOBE_DB_SELECT_1_Query1()
            {
                SIARDEVC_DATA_OCORRENCIA = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_OCORRENCIA.ToString(),
                AUTOCOBE_COD_COBERTURA = AUTOCOBE.DCLAUTO_COBERTURAS.AUTOCOBE_COD_COBERTURA.ToString(),
                SIARDEVC_NUM_APOLICE = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE.ToString(),
                APOLIAUT_NUM_ENDOSSO = APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_ENDOSSO.ToString(),
                APOLIAUT_NUM_ITEM = APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_ITEM.ToString(),
                SIARDEVC_COD_RAMO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_RAMO.ToString(),
            };

            var executed_1 = R1410_00_LE_AUTOCOBE_DB_SELECT_1_Query1.Execute(r1410_00_LE_AUTOCOBE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AUTOCOBE_IMP_SEGURADA_IX, AUTOCOBE.DCLAUTO_COBERTURAS.AUTOCOBE_IMP_SEGURADA_IX);
                _.Move(executed_1.AUTOCOBE_SIT_REGISTRO, AUTOCOBE.DCLAUTO_COBERTURAS.AUTOCOBE_SIT_REGISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1410_99_SAIDA*/

        [StopWatch]
        /*" R1450-00-OBTEM-COBERTURA-SECTION */
        private void R1450_00_OBTEM_COBERTURA_SECTION()
        {
            /*" -677- MOVE '1450' TO WNR-EXEC-SQL */
            _.Move("1450", WABEND.WNR_EXEC_SQL);

            /*" -678- MOVE SPACES TO WTEM-COBERTURA */
            _.Move("", WTEM_COBERTURA);

            /*" -684- MOVE SIARDEVC-COD-COBERTURA TO WS-COD-COBERTURA */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_COBERTURA, WS_COD_COBERTURA);

            /*" -686- IF SIARDEVC-COD-COBERTURA EQUAL 202 OR 203 OR 218 */

            if (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_COBERTURA.In("202", "203", "218"))
            {

                /*" -688- MOVE 201 TO WS-COD-COBERTURA. */
                _.Move(201, WS_COD_COBERTURA);
            }


            /*" -690- SET IX1 TO +1 */
            IX1.Value = +1;

            /*" -692- SEARCH TABC-COBERTURAS AT END */
            void SearchAtEnd0()
            {

                /*" -693- MOVE 'N' TO WTEM-COBERTURA */
                _.Move("N", WTEM_COBERTURA);

                /*" -694- WHEN WS-COD-COBERTURA EQUAL TABC-VCRUZ(IX1) */
            };

            var mustSearchAtEnd0 = true;
            for (; IX1 < FILLER_36.TABC_COBERTURAS.Items.Count; IX1.Value++)
            {

                if (WS_COD_COBERTURA == FILLER_36.TABC_COBERTURAS[IX1].TABC_VCRUZ)
                {

                    mustSearchAtEnd0 = false;

                    /*" -694- MOVE TABC-CAIXA(IX1) TO AUTOCOBE-COD-COBERTURA  END-SEARCH. */
                    break;
                }
            }

            if (mustSearchAtEnd0)
                SearchAtEnd0();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1450_99_SAIDA*/

        [StopWatch]
        /*" R1500-LE-SINISCAU-SECTION */
        private void R1500_LE_SINISCAU_SECTION()
        {
            /*" -704- MOVE '1500' TO WNR-EXEC-SQL */
            _.Move("1500", WABEND.WNR_EXEC_SQL);

            /*" -710- PERFORM R1500_LE_SINISCAU_DB_SELECT_1 */

            R1500_LE_SINISCAU_DB_SELECT_1();

            /*" -713- IF SQLCODE NOT EQUAL 0 AND 100 */

            if (!DB.SQLCODE.In("0", "100"))
            {

                /*" -721- DISPLAY 'PROBLEMAS NO SELECT SINISTRO_CAUSA' ' ' SIARDEVC-NUM-APOLICE ' ' APOLIAUT-NUM-ITEM ' ' SIARDEVC-COD-RAMO ' ' AUTOCOBE-COD-COBERTURA ' ' SIARDEVC-DATA-OCORRENCIA ' ' SIARDEVC-COD-RAMO ' ' SIARDEVC-COD-CAUSA */

                $"PROBLEMAS NO SELECT SINISTRO_CAUSA {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE} {APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_ITEM} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_RAMO} {AUTOCOBE.DCLAUTO_COBERTURAS.AUTOCOBE_COD_COBERTURA} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_OCORRENCIA} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_RAMO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_CAUSA}"
                .Display();

                /*" -721- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1500-LE-SINISCAU-DB-SELECT-1 */
        public void R1500_LE_SINISCAU_DB_SELECT_1()
        {
            /*" -710- EXEC SQL SELECT DESCR_CAUSA INTO :SINISCAU-DESCR-CAUSA FROM SEGUROS.SINISTRO_CAUSA WHERE RAMO_EMISSOR = :SIARDEVC-COD-RAMO AND COD_CAUSA = :SIARDEVC-COD-CAUSA END-EXEC. */

            var r1500_LE_SINISCAU_DB_SELECT_1_Query1 = new R1500_LE_SINISCAU_DB_SELECT_1_Query1()
            {
                SIARDEVC_COD_CAUSA = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_CAUSA.ToString(),
                SIARDEVC_COD_RAMO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_RAMO.ToString(),
            };

            var executed_1 = R1500_LE_SINISCAU_DB_SELECT_1_Query1.Execute(r1500_LE_SINISCAU_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISCAU_DESCR_CAUSA, SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_DESCR_CAUSA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_EXIT*/

        [StopWatch]
        /*" R1600-00-VER-CANCELAMENTO-SECTION */
        private void R1600_00_VER_CANCELAMENTO_SECTION()
        {
            /*" -750- MOVE '1600' TO WNR-EXEC-SQL */
            _.Move("1600", WABEND.WNR_EXEC_SQL);

            /*" -751- MOVE 'N' TO WTEM-ENDOSSOS */
            _.Move("N", WTEM_ENDOSSOS);

            /*" -753- PERFORM R1610-00-LE-ENDOSSOS */

            R1610_00_LE_ENDOSSOS_SECTION();

            /*" -754- IF WTEM-ENDOSSOS EQUAL 'S' */

            if (WTEM_ENDOSSOS == "S")
            {

                /*" -756- IF SIARDEVC-DATA-OCORRENCIA GREATER ENDOSSOS-DATA-INIVIGENCIA */

                if (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_OCORRENCIA > ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA)
                {

                    /*" -757- MOVE 'S' TO WS-REJEITA-AVISO */
                    _.Move("S", WS_REJEITA_AVISO);

                    /*" -758- END-IF */
                }


                /*" -759- ELSE */
            }
            else
            {


                /*" -760- PERFORM R1620-00-LE-PARCEHIS */

                R1620_00_LE_PARCEHIS_SECTION();

                /*" -763- IF PARCEHIS-DATA-MOVIMENTO NOT EQUAL '0001-01-01' AND SIARDEVC-DATA-OCORRENCIA GREATER PARCEHIS-DATA-MOVIMENTO */

                if (PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO != "0001-01-01" && SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_OCORRENCIA > PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO)
                {

                    /*" -764- MOVE 'S' TO WS-REJEITA-AVISO */
                    _.Move("S", WS_REJEITA_AVISO);

                    /*" -765- END-IF */
                }


                /*" -765- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1610-00-LE-ENDOSSOS-SECTION */
        private void R1610_00_LE_ENDOSSOS_SECTION()
        {
            /*" -775- MOVE '1610' TO WNR-EXEC-SQL */
            _.Move("1610", WABEND.WNR_EXEC_SQL);

            /*" -788- PERFORM R1610_00_LE_ENDOSSOS_DB_SELECT_1 */

            R1610_00_LE_ENDOSSOS_DB_SELECT_1();

            /*" -791- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -792- MOVE 'S' TO WTEM-ENDOSSOS */
                _.Move("S", WTEM_ENDOSSOS);

                /*" -793- ELSE */
            }
            else
            {


                /*" -794- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -797- DISPLAY 'PROBLEMAS NO SELECT ENDOSSOS' ' ' SIARDEVC-NUM-APOLICE ' ' SIARDEVC-NUM-ENDOSSO */

                    $"PROBLEMAS NO SELECT ENDOSSOS {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_ENDOSSO}"
                    .Display();

                    /*" -797- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1610-00-LE-ENDOSSOS-DB-SELECT-1 */
        public void R1610_00_LE_ENDOSSOS_DB_SELECT_1()
        {
            /*" -788- EXEC SQL SELECT DATA_INIVIGENCIA INTO :ENDOSSOS-DATA-INIVIGENCIA FROM SEGUROS.ENDOSSOS A WHERE A.NUM_APOLICE = :SIARDEVC-NUM-APOLICE AND A.TIPO_ENDOSSO = '5' AND A.SIT_REGISTRO <> '2' AND A.DATA_EMISSAO = (SELECT MAX(B.DATA_EMISSAO) FROM SEGUROS.ENDOSSOS B WHERE A.NUM_APOLICE = B.NUM_APOLICE AND B.TIPO_ENDOSSO = '5' AND B.SIT_REGISTRO <> '2' ) END-EXEC */

            var r1610_00_LE_ENDOSSOS_DB_SELECT_1_Query1 = new R1610_00_LE_ENDOSSOS_DB_SELECT_1_Query1()
            {
                SIARDEVC_NUM_APOLICE = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1610_00_LE_ENDOSSOS_DB_SELECT_1_Query1.Execute(r1610_00_LE_ENDOSSOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDOSSOS_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1610_99_SAIDA*/

        [StopWatch]
        /*" R1620-00-LE-PARCEHIS-SECTION */
        private void R1620_00_LE_PARCEHIS_SECTION()
        {
            /*" -807- MOVE '1620' TO WNR-EXEC-SQL */
            _.Move("1620", WABEND.WNR_EXEC_SQL);

            /*" -820- PERFORM R1620_00_LE_PARCEHIS_DB_SELECT_1 */

            R1620_00_LE_PARCEHIS_DB_SELECT_1();

            /*" -823- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -826- DISPLAY 'PROBLEMAS NO SELECT PARCELA_HISTORICO' ' ' SIARDEVC-NUM-APOLICE ' ' SIARDEVC-NUM-ENDOSSO */

                $"PROBLEMAS NO SELECT PARCELA_HISTORICO {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_ENDOSSO}"
                .Display();

                /*" -826- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1620-00-LE-PARCEHIS-DB-SELECT-1 */
        public void R1620_00_LE_PARCEHIS_DB_SELECT_1()
        {
            /*" -820- EXEC SQL SELECT VALUE(MAX(A.DATA_MOVIMENTO),DATE( '0001-01-01' )) INTO :PARCEHIS-DATA-MOVIMENTO FROM SEGUROS.PARCELA_HISTORICO A WHERE A.NUM_APOLICE = :SIARDEVC-NUM-APOLICE AND A.NUM_ENDOSSO = 0 AND A.COD_OPERACAO BETWEEN 400 AND 499 AND A.OCORR_HISTORICO = (SELECT MAX(B.OCORR_HISTORICO) FROM SEGUROS.PARCELA_HISTORICO B WHERE A.NUM_APOLICE = B.NUM_APOLICE AND A.NUM_ENDOSSO = B.NUM_ENDOSSO AND A.NUM_PARCELA = B.NUM_PARCELA) END-EXEC */

            var r1620_00_LE_PARCEHIS_DB_SELECT_1_Query1 = new R1620_00_LE_PARCEHIS_DB_SELECT_1_Query1()
            {
                SIARDEVC_NUM_APOLICE = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1620_00_LE_PARCEHIS_DB_SELECT_1_Query1.Execute(r1620_00_LE_PARCEHIS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARCEHIS_DATA_MOVIMENTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1620_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-GERA-SINISTRO-SECTION */
        private void R2000_00_GERA_SINISTRO_SECTION()
        {
            /*" -836- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", WABEND.WNR_EXEC_SQL);

            /*" -837- MOVE '0' TO SINISCON-DAC-PROTOCOLO-SINI */
            _.Move("0", SINISCON.DCLSINISTRO_CONTROLE.SINISCON_DAC_PROTOCOLO_SINI);

            /*" -839- PERFORM R2100-00-MAX-SINISCON */

            R2100_00_MAX_SINISCON_SECTION();

            /*" -840- ADD 1 TO SINISCON-NUM-PROTOCOLO-SINI */
            SINISCON.DCLSINISTRO_CONTROLE.SINISCON_NUM_PROTOCOLO_SINI.Value = SINISCON.DCLSINISTRO_CONTROLE.SINISCON_NUM_PROTOCOLO_SINI + 1;

            /*" -841- PERFORM R2200-00-INCLUI-SINISCON */

            R2200_00_INCLUI_SINISCON_SECTION();

            /*" -843- PERFORM R2300-00-INCLUI-SINISACO */

            R2300_00_INCLUI_SINISACO_SECTION();

            /*" -845- PERFORM R2400-00-SUM-APOLCOSS */

            R2400_00_SUM_APOLCOSS_SECTION();

            /*" -849- COMPUTE APOLCOSS-PCT-PART-COSSEGURO = 100 - APOLCOSS-PCT-PART-COSSEGURO */
            APOLCOSS.DCLAPOL_COSSEGURADORA.APOLCOSS_PCT_PART_COSSEGURO.Value = 100 - APOLCOSS.DCLAPOL_COSSEGURADORA.APOLCOSS_PCT_PART_COSSEGURO;

            /*" -850- MOVE 1 TO SINISMES-COD-MOEDA-SINI */
            _.Move(1, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_MOEDA_SINI);

            /*" -852- MOVE ZEROS TO SINISMES-PCT-PART-RESSEGURO */
            _.Move(0, SINISMES.DCLSINISTRO_MESTRE.SINISMES_PCT_PART_RESSEGURO);

            /*" -854- PERFORM R2500-00-MAX-NUMERAES */

            R2500_00_MAX_NUMERAES_SECTION();

            /*" -855- ADD 1 TO NUMERAES-SEQ-SINISTRO */
            NUMERAES.DCLNUMERO_AES.NUMERAES_SEQ_SINISTRO.Value = NUMERAES.DCLNUMERO_AES.NUMERAES_SEQ_SINISTRO + 1;

            /*" -857- PERFORM R2550-00-ALTERA-NUMERAES */

            R2550_00_ALTERA_NUMERAES_SECTION();

            /*" -859- MOVE APOLICES-ORGAO-EMISSOR TO WS-ORGAO-EMISSOR */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR, FILLER_0.WS_ORGAO_EMISSOR);

            /*" -861- MOVE SIARDEVC-COD-RAMO TO WS-RAMO-EMISSOR */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_RAMO, FILLER_0.WS_RAMO_EMISSOR);

            /*" -863- MOVE NUMERAES-SEQ-SINISTRO TO WS-SEQ-SINISTRO */
            _.Move(NUMERAES.DCLNUMERO_AES.NUMERAES_SEQ_SINISTRO, FILLER_0.WS_SEQ_SINISTRO);

            /*" -866- MOVE WS-NUM-APOL-SINISTRO TO SINISMES-NUM-APOL-SINISTRO */
            _.Move(WS_NUM_APOL_SINISTRO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO);

            /*" -868- PERFORM R2600-00-INCLUI-SINISMES */

            R2600_00_INCLUI_SINISMES_SECTION();

            /*" -870- PERFORM R2700-00-INCLUI-SINIITEM */

            R2700_00_INCLUI_SINIITEM_SECTION();

            /*" -872- PERFORM R2800-00-INCLUI-SINISHIS */

            R2800_00_INCLUI_SINISHIS_SECTION();

            /*" -874- PERFORM R2900-00-INCLUI-SINISAUT */

            R2900_00_INCLUI_SINISAUT_SECTION();

            /*" -874- PERFORM R3000-00-INCLUI-SINIMPSE. */

            R3000_00_INCLUI_SINIMPSE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-MAX-SINISCON-SECTION */
        private void R2100_00_MAX_SINISCON_SECTION()
        {
            /*" -884- MOVE '2100' TO WNR-EXEC-SQL. */
            _.Move("2100", WABEND.WNR_EXEC_SQL);

            /*" -889- PERFORM R2100_00_MAX_SINISCON_DB_SELECT_1 */

            R2100_00_MAX_SINISCON_DB_SELECT_1();

            /*" -892- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -899- DISPLAY 'PROBLEMAS NO MAX SINISTRO_CONTROLE' ' ' SIARDEVC-NUM-APOLICE ' ' APOLIAUT-NUM-ITEM ' ' SIARDEVC-COD-RAMO ' ' AUTOCOBE-COD-COBERTURA ' ' SIARDEVC-DATA-OCORRENCIA ' ' ENDOSSOS-COD-FONTE */

                $"PROBLEMAS NO MAX SINISTRO_CONTROLE {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE} {APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_ITEM} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_RAMO} {AUTOCOBE.DCLAUTO_COBERTURAS.AUTOCOBE_COD_COBERTURA} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_OCORRENCIA} {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE}"
                .Display();

                /*" -899- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2100-00-MAX-SINISCON-DB-SELECT-1 */
        public void R2100_00_MAX_SINISCON_DB_SELECT_1()
        {
            /*" -889- EXEC SQL SELECT VALUE(MAX(NUM_PROTOCOLO_SINI),0) INTO :SINISCON-NUM-PROTOCOLO-SINI FROM SEGUROS.SINISTRO_CONTROLE WHERE COD_FONTE = :ENDOSSOS-COD-FONTE END-EXEC */

            var r2100_00_MAX_SINISCON_DB_SELECT_1_Query1 = new R2100_00_MAX_SINISCON_DB_SELECT_1_Query1()
            {
                ENDOSSOS_COD_FONTE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE.ToString(),
            };

            var executed_1 = R2100_00_MAX_SINISCON_DB_SELECT_1_Query1.Execute(r2100_00_MAX_SINISCON_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISCON_NUM_PROTOCOLO_SINI, SINISCON.DCLSINISTRO_CONTROLE.SINISCON_NUM_PROTOCOLO_SINI);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-INCLUI-SINISCON-SECTION */
        private void R2200_00_INCLUI_SINISCON_SECTION()
        {
            /*" -909- MOVE '2200' TO WNR-EXEC-SQL. */
            _.Move("2200", WABEND.WNR_EXEC_SQL);

            /*" -937- PERFORM R2200_00_INCLUI_SINISCON_DB_INSERT_1 */

            R2200_00_INCLUI_SINISCON_DB_INSERT_1();

            /*" -940- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -949- DISPLAY 'PROBLEMAS NO INSERT SINISTRO_CONTROLE' ' ' SIARDEVC-NUM-APOLICE ' ' APOLIAUT-NUM-ITEM ' ' SIARDEVC-COD-RAMO ' ' AUTOCOBE-COD-COBERTURA ' ' SIARDEVC-DATA-OCORRENCIA ' ' ENDOSSOS-COD-FONTE ' ' SINISCON-NUM-PROTOCOLO-SINI ' ' SINISCON-DAC-PROTOCOLO-SINI */

                $"PROBLEMAS NO INSERT SINISTRO_CONTROLE {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE} {APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_ITEM} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_RAMO} {AUTOCOBE.DCLAUTO_COBERTURAS.AUTOCOBE_COD_COBERTURA} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_OCORRENCIA} {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE} {SINISCON.DCLSINISTRO_CONTROLE.SINISCON_NUM_PROTOCOLO_SINI} {SINISCON.DCLSINISTRO_CONTROLE.SINISCON_DAC_PROTOCOLO_SINI}"
                .Display();

                /*" -951- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -951- ADD 1 TO AC-I-SINISCON. */
            AC_I_SINISCON.Value = AC_I_SINISCON + 1;

        }

        [StopWatch]
        /*" R2200-00-INCLUI-SINISCON-DB-INSERT-1 */
        public void R2200_00_INCLUI_SINISCON_DB_INSERT_1()
        {
            /*" -937- EXEC SQL INSERT INTO SEGUROS.SINISTRO_CONTROLE (COD_FONTE, NUM_PROTOCOLO_SINI, DAC_PROTOCOLO_SINI, NUM_APOLICE, COD_SUBGRUPO, OCORR_HISTORICO, PEND_VISTORIA, PEND_RESSEGURO, SIT_REGISTRO, PEND_VIST_COMPL, COD_EMPRESA, TIMESTAMP, NUM_CERTIFICADO) VALUES (:ENDOSSOS-COD-FONTE, :SINISCON-NUM-PROTOCOLO-SINI, :SINISCON-DAC-PROTOCOLO-SINI, :SIARDEVC-NUM-APOLICE, 0, 1, 'N' , 'N' , '0' , 'N' , 0, CURRENT TIMESTAMP, 0) END-EXEC. */

            var r2200_00_INCLUI_SINISCON_DB_INSERT_1_Insert1 = new R2200_00_INCLUI_SINISCON_DB_INSERT_1_Insert1()
            {
                ENDOSSOS_COD_FONTE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE.ToString(),
                SINISCON_NUM_PROTOCOLO_SINI = SINISCON.DCLSINISTRO_CONTROLE.SINISCON_NUM_PROTOCOLO_SINI.ToString(),
                SINISCON_DAC_PROTOCOLO_SINI = SINISCON.DCLSINISTRO_CONTROLE.SINISCON_DAC_PROTOCOLO_SINI.ToString(),
                SIARDEVC_NUM_APOLICE = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE.ToString(),
            };

            R2200_00_INCLUI_SINISCON_DB_INSERT_1_Insert1.Execute(r2200_00_INCLUI_SINISCON_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-INCLUI-SINISACO-SECTION */
        private void R2300_00_INCLUI_SINISACO_SECTION()
        {
            /*" -961- MOVE '2300' TO WNR-EXEC-SQL. */
            _.Move("2300", WABEND.WNR_EXEC_SQL);

            /*" -983- PERFORM R2300_00_INCLUI_SINISACO_DB_INSERT_1 */

            R2300_00_INCLUI_SINISACO_DB_INSERT_1();

            /*" -986- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -995- DISPLAY 'PROBLEMAS NO INSERT SINISTRO_ACOMPANHA' ' ' SIARDEVC-NUM-APOLICE ' ' APOLIAUT-NUM-ITEM ' ' SIARDEVC-COD-RAMO ' ' AUTOCOBE-COD-COBERTURA ' ' SIARDEVC-DATA-OCORRENCIA ' ' ENDOSSOS-COD-FONTE ' ' SINISCON-NUM-PROTOCOLO-SINI ' ' SINISCON-DAC-PROTOCOLO-SINI */

                $"PROBLEMAS NO INSERT SINISTRO_ACOMPANHA {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE} {APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_ITEM} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_RAMO} {AUTOCOBE.DCLAUTO_COBERTURAS.AUTOCOBE_COD_COBERTURA} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_OCORRENCIA} {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE} {SINISCON.DCLSINISTRO_CONTROLE.SINISCON_NUM_PROTOCOLO_SINI} {SINISCON.DCLSINISTRO_CONTROLE.SINISCON_DAC_PROTOCOLO_SINI}"
                .Display();

                /*" -997- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -997- ADD 1 TO AC-I-SINISACO. */
            AC_I_SINISACO.Value = AC_I_SINISACO + 1;

        }

        [StopWatch]
        /*" R2300-00-INCLUI-SINISACO-DB-INSERT-1 */
        public void R2300_00_INCLUI_SINISACO_DB_INSERT_1()
        {
            /*" -983- EXEC SQL INSERT INTO SEGUROS.SINISTRO_ACOMPANHA (COD_FONTE, NUM_PROTOCOLO_SINI, DAC_PROTOCOLO_SINI, COD_OPERACAO, DATA_OPERACAO, HORA_OPERACAO, OCORR_HISTORICO, COD_USUARIO, COD_EMPRESA, TIMESTAMP) VALUES (:ENDOSSOS-COD-FONTE, :SINISCON-NUM-PROTOCOLO-SINI, :SINISCON-DAC-PROTOCOLO-SINI, 9020, :SISTEMAS-DATA-MOV-ABERTO, CURRENT TIME, 1, 'SI9101B' , 0, CURRENT TIMESTAMP) END-EXEC. */

            var r2300_00_INCLUI_SINISACO_DB_INSERT_1_Insert1 = new R2300_00_INCLUI_SINISACO_DB_INSERT_1_Insert1()
            {
                ENDOSSOS_COD_FONTE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE.ToString(),
                SINISCON_NUM_PROTOCOLO_SINI = SINISCON.DCLSINISTRO_CONTROLE.SINISCON_NUM_PROTOCOLO_SINI.ToString(),
                SINISCON_DAC_PROTOCOLO_SINI = SINISCON.DCLSINISTRO_CONTROLE.SINISCON_DAC_PROTOCOLO_SINI.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
            };

            R2300_00_INCLUI_SINISACO_DB_INSERT_1_Insert1.Execute(r2300_00_INCLUI_SINISACO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-SUM-APOLCOSS-SECTION */
        private void R2400_00_SUM_APOLCOSS_SECTION()
        {
            /*" -1007- MOVE '2400' TO WNR-EXEC-SQL. */
            _.Move("2400", WABEND.WNR_EXEC_SQL);

            /*" -1014- PERFORM R2400_00_SUM_APOLCOSS_DB_SELECT_1 */

            R2400_00_SUM_APOLCOSS_DB_SELECT_1();

            /*" -1017- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1024- DISPLAY 'PROBLEMAS NO SELECT APOL_COSSEGURADORA' ' ' SIARDEVC-NUM-APOLICE ' ' APOLIAUT-NUM-ITEM ' ' SIARDEVC-COD-RAMO ' ' AUTOCOBE-COD-COBERTURA ' ' SIARDEVC-DATA-OCORRENCIA ' ' APOLIAUT-DATA-INIVIGENCIA */

                $"PROBLEMAS NO SELECT APOL_COSSEGURADORA {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE} {APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_ITEM} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_RAMO} {AUTOCOBE.DCLAUTO_COBERTURAS.AUTOCOBE_COD_COBERTURA} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_OCORRENCIA} {APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_DATA_INIVIGENCIA}"
                .Display();

                /*" -1024- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2400-00-SUM-APOLCOSS-DB-SELECT-1 */
        public void R2400_00_SUM_APOLCOSS_DB_SELECT_1()
        {
            /*" -1014- EXEC SQL SELECT VALUE(SUM(PCT_PART_COSSEGURO),0) INTO :APOLCOSS-PCT-PART-COSSEGURO FROM SEGUROS.APOL_COSSEGURADORA WHERE NUM_APOLICE = :SIARDEVC-NUM-APOLICE AND DATA_INIVIGENCIA <= :APOLIAUT-DATA-INIVIGENCIA AND DATA_TERVIGENCIA >= :APOLIAUT-DATA-INIVIGENCIA END-EXEC. */

            var r2400_00_SUM_APOLCOSS_DB_SELECT_1_Query1 = new R2400_00_SUM_APOLCOSS_DB_SELECT_1_Query1()
            {
                APOLIAUT_DATA_INIVIGENCIA = APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_DATA_INIVIGENCIA.ToString(),
                SIARDEVC_NUM_APOLICE = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE.ToString(),
            };

            var executed_1 = R2400_00_SUM_APOLCOSS_DB_SELECT_1_Query1.Execute(r2400_00_SUM_APOLCOSS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLCOSS_PCT_PART_COSSEGURO, APOLCOSS.DCLAPOL_COSSEGURADORA.APOLCOSS_PCT_PART_COSSEGURO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-MAX-NUMERAES-SECTION */
        private void R2500_00_MAX_NUMERAES_SECTION()
        {
            /*" -1034- MOVE '2500' TO WNR-EXEC-SQL. */
            _.Move("2500", WABEND.WNR_EXEC_SQL);

            /*" -1040- PERFORM R2500_00_MAX_NUMERAES_DB_SELECT_1 */

            R2500_00_MAX_NUMERAES_DB_SELECT_1();

            /*" -1051- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1058- DISPLAY 'PROBLEMAS NO MAX NUMERO_AES' ' ' SIARDEVC-NUM-APOLICE ' ' APOLIAUT-NUM-ITEM ' ' SIARDEVC-COD-RAMO ' ' AUTOCOBE-COD-COBERTURA ' ' SIARDEVC-DATA-OCORRENCIA ' ' APOLICES-ORGAO-EMISSOR */

                $"PROBLEMAS NO MAX NUMERO_AES {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE} {APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_ITEM} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_RAMO} {AUTOCOBE.DCLAUTO_COBERTURAS.AUTOCOBE_COD_COBERTURA} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_OCORRENCIA} {APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR}"
                .Display();

                /*" -1058- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2500-00-MAX-NUMERAES-DB-SELECT-1 */
        public void R2500_00_MAX_NUMERAES_DB_SELECT_1()
        {
            /*" -1040- EXEC SQL SELECT VALUE(MAX(SEQ_SINISTRO),0) INTO :NUMERAES-SEQ-SINISTRO FROM SEGUROS.NUMERO_AES WHERE ORGAO_EMISSOR = :APOLICES-ORGAO-EMISSOR AND RAMO_EMISSOR = :SIARDEVC-COD-RAMO END-EXEC. */

            var r2500_00_MAX_NUMERAES_DB_SELECT_1_Query1 = new R2500_00_MAX_NUMERAES_DB_SELECT_1_Query1()
            {
                APOLICES_ORGAO_EMISSOR = APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR.ToString(),
                SIARDEVC_COD_RAMO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_RAMO.ToString(),
            };

            var executed_1 = R2500_00_MAX_NUMERAES_DB_SELECT_1_Query1.Execute(r2500_00_MAX_NUMERAES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUMERAES_SEQ_SINISTRO, NUMERAES.DCLNUMERO_AES.NUMERAES_SEQ_SINISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R2550-00-ALTERA-NUMERAES-SECTION */
        private void R2550_00_ALTERA_NUMERAES_SECTION()
        {
            /*" -1068- MOVE '2550' TO WNR-EXEC-SQL. */
            _.Move("2550", WABEND.WNR_EXEC_SQL);

            /*" -1074- PERFORM R2550_00_ALTERA_NUMERAES_DB_UPDATE_1 */

            R2550_00_ALTERA_NUMERAES_DB_UPDATE_1();

            /*" -1086- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1093- DISPLAY 'PROBLEMAS NO UPDATE NUMERO_AES' ' ' SIARDEVC-NUM-APOLICE ' ' APOLIAUT-NUM-ITEM ' ' SIARDEVC-COD-RAMO ' ' AUTOCOBE-COD-COBERTURA ' ' SIARDEVC-DATA-OCORRENCIA ' ' APOLICES-ORGAO-EMISSOR */

                $"PROBLEMAS NO UPDATE NUMERO_AES {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE} {APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_ITEM} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_RAMO} {AUTOCOBE.DCLAUTO_COBERTURAS.AUTOCOBE_COD_COBERTURA} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_OCORRENCIA} {APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR}"
                .Display();

                /*" -1093- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2550-00-ALTERA-NUMERAES-DB-UPDATE-1 */
        public void R2550_00_ALTERA_NUMERAES_DB_UPDATE_1()
        {
            /*" -1074- EXEC SQL UPDATE SEGUROS.NUMERO_AES SET SEQ_SINISTRO = :NUMERAES-SEQ-SINISTRO, TIMESTAMP = CURRENT TIMESTAMP WHERE ORGAO_EMISSOR = :APOLICES-ORGAO-EMISSOR AND RAMO_EMISSOR = :SIARDEVC-COD-RAMO END-EXEC. */

            var r2550_00_ALTERA_NUMERAES_DB_UPDATE_1_Update1 = new R2550_00_ALTERA_NUMERAES_DB_UPDATE_1_Update1()
            {
                NUMERAES_SEQ_SINISTRO = NUMERAES.DCLNUMERO_AES.NUMERAES_SEQ_SINISTRO.ToString(),
                APOLICES_ORGAO_EMISSOR = APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR.ToString(),
                SIARDEVC_COD_RAMO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_RAMO.ToString(),
            };

            R2550_00_ALTERA_NUMERAES_DB_UPDATE_1_Update1.Execute(r2550_00_ALTERA_NUMERAES_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2550_99_SAIDA*/

        [StopWatch]
        /*" R2600-00-INCLUI-SINISMES-SECTION */
        private void R2600_00_INCLUI_SINISMES_SECTION()
        {
            /*" -1103- MOVE '2500' TO WNR-EXEC-SQL. */
            _.Move("2500", WABEND.WNR_EXEC_SQL);

            /*" -1207- PERFORM R2600_00_INCLUI_SINISMES_DB_INSERT_1 */

            R2600_00_INCLUI_SINISMES_DB_INSERT_1();

            /*" -1210- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1220- DISPLAY 'PROBLEMAS NO INSERT SINISTRO_MESTRE' ' ' SIARDEVC-NUM-APOLICE ' ' APOLIAUT-NUM-ITEM ' ' SIARDEVC-COD-RAMO ' ' AUTOCOBE-COD-COBERTURA ' ' SIARDEVC-DATA-OCORRENCIA ' ' ENDOSSOS-COD-FONTE ' ' SINISCON-NUM-PROTOCOLO-SINI ' ' SINISCON-DAC-PROTOCOLO-SINI ' ' SINISMES-NUM-APOL-SINISTRO */

                $"PROBLEMAS NO INSERT SINISTRO_MESTRE {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE} {APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_ITEM} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_RAMO} {AUTOCOBE.DCLAUTO_COBERTURAS.AUTOCOBE_COD_COBERTURA} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_OCORRENCIA} {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE} {SINISCON.DCLSINISTRO_CONTROLE.SINISCON_NUM_PROTOCOLO_SINI} {SINISCON.DCLSINISTRO_CONTROLE.SINISCON_DAC_PROTOCOLO_SINI} {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}"
                .Display();

                /*" -1222- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1222- ADD 1 TO AC-I-SINISMES. */
            AC_I_SINISMES.Value = AC_I_SINISMES + 1;

        }

        [StopWatch]
        /*" R2600-00-INCLUI-SINISMES-DB-INSERT-1 */
        public void R2600_00_INCLUI_SINISMES_DB_INSERT_1()
        {
            /*" -1207- EXEC SQL INSERT INTO SEGUROS.SINISTRO_MESTRE (COD_EMPRESA, TIPO_REGISTRO, COD_FONTE, NUM_PROTOCOLO_SINI, DAC_PROTOCOLO_SINI, NUM_APOL_SINISTRO, NUM_APOLICE, NUM_ENDOSSO, COD_SUBGRUPO, NUM_CERTIFICADO, DAC_CERTIFICADO, TIPO_SEGURADO, NUM_EMBARQUE, REF_EMBARQUE, OCORR_HISTORICO, COD_LIDER, NUM_SINI_LIDER, DATA_COMUNICADO, DATA_OCORRENCIA, DATA_TECNICA, COD_CAUSA, NUM_IRB, NUM_AVISO_IRB, COD_MOEDA_SINI, SALDO_PAGAR_IX, TOT_PAGAMENTO_IX, SALDO_RECUPERAR_IX, TOT_RECUPERADO_IX, SALDO_RESSARCIR_IX, TOT_RESSARCIDO_IX, TOT_DESPESAS_IX, TOT_HONORARIOS_IX, ADIA_RECUPERAR_IX, ADIA_RECUPERADO_IX, IMP_SEGURADA_IX, PCT_PART_COSSEGURO, PCT_PART_RESSEGURO, APROVACAO_ALCADA, IND_SALVADO, INTEGRAL_ESPECIAL, NUM_MOV_SINI_ATU, NUM_MOV_SINI_ANT, DATA_ULT_MOVIMENTO, SIT_REGISTRO, TIMESTAMP, BANCO_ORDEM_PAG, AGENCIA_ORDEM_PAG, TIPO_PAGAMENTO, RAMO, NUMERO_ORDEM, COD_PRODUTO) VALUES (0, '1' , :ENDOSSOS-COD-FONTE, :SINISCON-NUM-PROTOCOLO-SINI, :SINISCON-DAC-PROTOCOLO-SINI, :SINISMES-NUM-APOL-SINISTRO, :SIARDEVC-NUM-APOLICE, :APOLIAUT-NUM-ENDOSSO, 0, 0, ' ' , ' ' , 0, 0, 1, 0, ' ' , :SIARDEVC-DATA-COMUNICADO, :SIARDEVC-DATA-OCORRENCIA, :SISTEMAS-DATA-MOV-ABERTO, :SIARDEVC-COD-CAUSA, 0, ' ' , :SINISMES-COD-MOEDA-SINI, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, :AUTOCOBE-IMP-SEGURADA-IX, :APOLCOSS-PCT-PART-COSSEGURO, :SINISMES-PCT-PART-RESSEGURO, 31, ' ' , ' ' , 0, 0, :SISTEMAS-DATA-MOV-ABERTO, '0' , CURRENT TIMESTAMP, 0, 0, '1' , :SIARDEVC-COD-RAMO, 0, :ENDOSSOS-COD-PRODUTO) END-EXEC. */

            var r2600_00_INCLUI_SINISMES_DB_INSERT_1_Insert1 = new R2600_00_INCLUI_SINISMES_DB_INSERT_1_Insert1()
            {
                ENDOSSOS_COD_FONTE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE.ToString(),
                SINISCON_NUM_PROTOCOLO_SINI = SINISCON.DCLSINISTRO_CONTROLE.SINISCON_NUM_PROTOCOLO_SINI.ToString(),
                SINISCON_DAC_PROTOCOLO_SINI = SINISCON.DCLSINISTRO_CONTROLE.SINISCON_DAC_PROTOCOLO_SINI.ToString(),
                SINISMES_NUM_APOL_SINISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.ToString(),
                SIARDEVC_NUM_APOLICE = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE.ToString(),
                APOLIAUT_NUM_ENDOSSO = APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_ENDOSSO.ToString(),
                SIARDEVC_DATA_COMUNICADO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_COMUNICADO.ToString(),
                SIARDEVC_DATA_OCORRENCIA = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_OCORRENCIA.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                SIARDEVC_COD_CAUSA = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_CAUSA.ToString(),
                SINISMES_COD_MOEDA_SINI = SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_MOEDA_SINI.ToString(),
                AUTOCOBE_IMP_SEGURADA_IX = AUTOCOBE.DCLAUTO_COBERTURAS.AUTOCOBE_IMP_SEGURADA_IX.ToString(),
                APOLCOSS_PCT_PART_COSSEGURO = APOLCOSS.DCLAPOL_COSSEGURADORA.APOLCOSS_PCT_PART_COSSEGURO.ToString(),
                SINISMES_PCT_PART_RESSEGURO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_PCT_PART_RESSEGURO.ToString(),
                SIARDEVC_COD_RAMO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_RAMO.ToString(),
                ENDOSSOS_COD_PRODUTO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO.ToString(),
            };

            R2600_00_INCLUI_SINISMES_DB_INSERT_1_Insert1.Execute(r2600_00_INCLUI_SINISMES_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2600_99_SAIDA*/

        [StopWatch]
        /*" R2700-00-INCLUI-SINIITEM-SECTION */
        private void R2700_00_INCLUI_SINIITEM_SECTION()
        {
            /*" -1232- MOVE '2600' TO WNR-EXEC-SQL. */
            _.Move("2600", WABEND.WNR_EXEC_SQL);

            /*" -1240- PERFORM R2700_00_INCLUI_SINIITEM_DB_INSERT_1 */

            R2700_00_INCLUI_SINIITEM_DB_INSERT_1();

            /*" -1243- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1254- DISPLAY 'PROBLEMAS NO INSERT SINISTRO_ITEM' ' ' SIARDEVC-NUM-APOLICE ' ' APOLIAUT-NUM-ITEM ' ' SIARDEVC-COD-RAMO ' ' AUTOCOBE-COD-COBERTURA ' ' SIARDEVC-DATA-OCORRENCIA ' ' ENDOSSOS-COD-FONTE ' ' SINISCON-NUM-PROTOCOLO-SINI ' ' SINISCON-DAC-PROTOCOLO-SINI ' ' SINISMES-NUM-APOL-SINISTRO ' ' APOLICES-COD-CLIENTE */

                $"PROBLEMAS NO INSERT SINISTRO_ITEM {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE} {APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_ITEM} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_RAMO} {AUTOCOBE.DCLAUTO_COBERTURAS.AUTOCOBE_COD_COBERTURA} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_OCORRENCIA} {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE} {SINISCON.DCLSINISTRO_CONTROLE.SINISCON_NUM_PROTOCOLO_SINI} {SINISCON.DCLSINISTRO_CONTROLE.SINISCON_DAC_PROTOCOLO_SINI} {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO} {APOLICES.DCLAPOLICES.APOLICES_COD_CLIENTE}"
                .Display();

                /*" -1256- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1256- ADD 1 TO AC-I-SINIITEM. */
            AC_I_SINIITEM.Value = AC_I_SINIITEM + 1;

        }

        [StopWatch]
        /*" R2700-00-INCLUI-SINIITEM-DB-INSERT-1 */
        public void R2700_00_INCLUI_SINIITEM_DB_INSERT_1()
        {
            /*" -1240- EXEC SQL INSERT INTO SEGUROS.SINISTRO_ITEM (NUM_APOL_SINISTRO, COD_CLIENTE, COD_FONTE) VALUES (:SINISMES-NUM-APOL-SINISTRO, :APOLICES-COD-CLIENTE, :ENDOSSOS-COD-FONTE) END-EXEC. */

            var r2700_00_INCLUI_SINIITEM_DB_INSERT_1_Insert1 = new R2700_00_INCLUI_SINIITEM_DB_INSERT_1_Insert1()
            {
                SINISMES_NUM_APOL_SINISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.ToString(),
                APOLICES_COD_CLIENTE = APOLICES.DCLAPOLICES.APOLICES_COD_CLIENTE.ToString(),
                ENDOSSOS_COD_FONTE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE.ToString(),
            };

            R2700_00_INCLUI_SINIITEM_DB_INSERT_1_Insert1.Execute(r2700_00_INCLUI_SINIITEM_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2700_99_SAIDA*/

        [StopWatch]
        /*" R2800-00-INCLUI-SINISHIS-SECTION */
        private void R2800_00_INCLUI_SINISHIS_SECTION()
        {
            /*" -1266- MOVE '2700' TO WNR-EXEC-SQL. */
            _.Move("2700", WABEND.WNR_EXEC_SQL);

            /*" -1320- PERFORM R2800_00_INCLUI_SINISHIS_DB_INSERT_1 */

            R2800_00_INCLUI_SINISHIS_DB_INSERT_1();

            /*" -1323- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1324- DISPLAY ' ' SQLCA */
                _.Display($" {DB.SQLCA}");

                /*" -1335- DISPLAY 'PROBLEMAS NO INSERT SINISTRO_HISTORICO' ' ' SIARDEVC-NUM-APOLICE ' ' APOLIAUT-NUM-ITEM ' ' SIARDEVC-COD-RAMO ' ' AUTOCOBE-COD-COBERTURA ' ' SIARDEVC-DATA-OCORRENCIA ' ' ENDOSSOS-COD-FONTE ' ' SINISCON-NUM-PROTOCOLO-SINI ' ' SINISCON-DAC-PROTOCOLO-SINI ' ' SINISMES-NUM-APOL-SINISTRO ' ' SIARDEVC-COD-OPERACAO */

                $"PROBLEMAS NO INSERT SINISTRO_HISTORICO {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE} {APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_ITEM} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_RAMO} {AUTOCOBE.DCLAUTO_COBERTURAS.AUTOCOBE_COD_COBERTURA} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_OCORRENCIA} {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE} {SINISCON.DCLSINISTRO_CONTROLE.SINISCON_NUM_PROTOCOLO_SINI} {SINISCON.DCLSINISTRO_CONTROLE.SINISCON_DAC_PROTOCOLO_SINI} {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_OPERACAO}"
                .Display();

                /*" -1337- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1337- ADD 1 TO AC-I-SINISHIS. */
            AC_I_SINISHIS.Value = AC_I_SINISHIS + 1;

        }

        [StopWatch]
        /*" R2800-00-INCLUI-SINISHIS-DB-INSERT-1 */
        public void R2800_00_INCLUI_SINISHIS_DB_INSERT_1()
        {
            /*" -1320- EXEC SQL INSERT INTO SEGUROS.SINISTRO_HISTORICO (COD_EMPRESA, TIPO_REGISTRO, NUM_APOL_SINISTRO, OCORR_HISTORICO, COD_OPERACAO, DATA_MOVIMENTO, HORA_OPERACAO, NOME_FAVORECIDO, VAL_OPERACAO, DATA_LIM_CORRECAO, TIPO_FAVORECIDO, DATA_NEGOCIADA, FONTE_PAGAMENTO, COD_PREST_SERVICO, COD_SERVICO, ORDEM_PAGAMENTO, NUM_RECIBO, NUM_MOV_SINISTRO, COD_USUARIO, SIT_CONTABIL, SIT_REGISTRO, TIMESTAMP, NUM_APOLICE, COD_PRODUTO, NOM_PROGRAMA) VALUES (0, '1' , :SINISMES-NUM-APOL-SINISTRO, 1, :SIARDEVC-COD-OPERACAO, :SISTEMAS-DATA-MOV-ABERTO, CURRENT TIME, ' ' , :SIARDEVC-VAL-TOT-MOVIMENTO, '9999-12-31' , '0' , '9999-12-31' , 0, 0, 0, 0, 0, 0, 'VERACRUZ' , '0' , '0' , CURRENT TIMESTAMP , :SIARDEVC-NUM-APOLICE, :ENDOSSOS-COD-PRODUTO, 'SI9101B' ) END-EXEC. */

            var r2800_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1 = new R2800_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1()
            {
                SINISMES_NUM_APOL_SINISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.ToString(),
                SIARDEVC_COD_OPERACAO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_OPERACAO.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                SIARDEVC_VAL_TOT_MOVIMENTO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_TOT_MOVIMENTO.ToString(),
                SIARDEVC_NUM_APOLICE = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE.ToString(),
                ENDOSSOS_COD_PRODUTO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO.ToString(),
            };

            R2800_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1.Execute(r2800_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2800_99_SAIDA*/

        [StopWatch]
        /*" R2900-00-INCLUI-SINISAUT-SECTION */
        private void R2900_00_INCLUI_SINISAUT_SECTION()
        {
            /*" -1347- MOVE '2800' TO WNR-EXEC-SQL. */
            _.Move("2800", WABEND.WNR_EXEC_SQL);

            /*" -1361- PERFORM R2900_00_INCLUI_SINISAUT_DB_INSERT_1 */

            R2900_00_INCLUI_SINISAUT_DB_INSERT_1();

            /*" -1364- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1375- DISPLAY 'PROBLEMAS NO INSERT SINISTRO_AUTO1' ' ' SIARDEVC-NUM-APOLICE ' ' APOLIAUT-NUM-ITEM ' ' SIARDEVC-COD-RAMO ' ' AUTOCOBE-COD-COBERTURA ' ' SIARDEVC-DATA-OCORRENCIA ' ' ENDOSSOS-COD-FONTE ' ' SINISCON-NUM-PROTOCOLO-SINI ' ' SINISCON-DAC-PROTOCOLO-SINI ' ' SINISMES-NUM-APOL-SINISTRO ' ' SIARDEVC-COD-OPERACAO */

                $"PROBLEMAS NO INSERT SINISTRO_AUTO1 {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE} {APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_ITEM} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_RAMO} {AUTOCOBE.DCLAUTO_COBERTURAS.AUTOCOBE_COD_COBERTURA} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_OCORRENCIA} {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE} {SINISCON.DCLSINISTRO_CONTROLE.SINISCON_NUM_PROTOCOLO_SINI} {SINISCON.DCLSINISTRO_CONTROLE.SINISCON_DAC_PROTOCOLO_SINI} {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_OPERACAO}"
                .Display();

                /*" -1377- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1377- ADD 1 TO AC-I-SINISAUT. */
            AC_I_SINISAUT.Value = AC_I_SINISAUT + 1;

        }

        [StopWatch]
        /*" R2900-00-INCLUI-SINISAUT-DB-INSERT-1 */
        public void R2900_00_INCLUI_SINISAUT_DB_INSERT_1()
        {
            /*" -1361- EXEC SQL INSERT INTO SEGUROS.SINISTRO_AUTO1 (NUM_APOLICE, NUM_APOL_SINISTRO, NUM_ITEM, RAMO, SIT_REGISTRO, TIMESTAMP) VALUES (:SIARDEVC-NUM-APOLICE, :SINISMES-NUM-APOL-SINISTRO, :APOLIAUT-NUM-ITEM, :SIARDEVC-COD-RAMO, ' ' , CURRENT TIMESTAMP) END-EXEC. */

            var r2900_00_INCLUI_SINISAUT_DB_INSERT_1_Insert1 = new R2900_00_INCLUI_SINISAUT_DB_INSERT_1_Insert1()
            {
                SIARDEVC_NUM_APOLICE = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE.ToString(),
                SINISMES_NUM_APOL_SINISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.ToString(),
                APOLIAUT_NUM_ITEM = APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_ITEM.ToString(),
                SIARDEVC_COD_RAMO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_RAMO.ToString(),
            };

            R2900_00_INCLUI_SINISAUT_DB_INSERT_1_Insert1.Execute(r2900_00_INCLUI_SINISAUT_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2900_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-INCLUI-SINIMPSE-SECTION */
        private void R3000_00_INCLUI_SINIMPSE_SECTION()
        {
            /*" -1387- MOVE '2900' TO WNR-EXEC-SQL. */
            _.Move("2900", WABEND.WNR_EXEC_SQL);

            /*" -1405- PERFORM R3000_00_INCLUI_SINIMPSE_DB_INSERT_1 */

            R3000_00_INCLUI_SINIMPSE_DB_INSERT_1();

            /*" -1408- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1420- DISPLAY 'PROBLEMAS NO INSERT SINISTRO_IMP_SEG' ' ' SIARDEVC-NUM-APOLICE ' ' APOLIAUT-NUM-ITEM ' ' SIARDEVC-COD-RAMO ' ' AUTOCOBE-COD-COBERTURA ' ' SIARDEVC-DATA-OCORRENCIA ' ' ENDOSSOS-COD-FONTE ' ' SINISCON-NUM-PROTOCOLO-SINI ' ' SINISCON-DAC-PROTOCOLO-SINI ' ' SINISMES-NUM-APOL-SINISTRO ' ' SIARDEVC-COD-CAUSA ' ' AUTOCOBE-IMP-SEGURADA-IX */

                $"PROBLEMAS NO INSERT SINISTRO_IMP_SEG {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE} {APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_ITEM} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_RAMO} {AUTOCOBE.DCLAUTO_COBERTURAS.AUTOCOBE_COD_COBERTURA} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_OCORRENCIA} {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE} {SINISCON.DCLSINISTRO_CONTROLE.SINISCON_NUM_PROTOCOLO_SINI} {SINISCON.DCLSINISTRO_CONTROLE.SINISCON_DAC_PROTOCOLO_SINI} {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_CAUSA} {AUTOCOBE.DCLAUTO_COBERTURAS.AUTOCOBE_IMP_SEGURADA_IX}"
                .Display();

                /*" -1422- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1422- ADD 1 TO AC-I-SINIMPSE. */
            AC_I_SINIMPSE.Value = AC_I_SINIMPSE + 1;

        }

        [StopWatch]
        /*" R3000-00-INCLUI-SINIMPSE-DB-INSERT-1 */
        public void R3000_00_INCLUI_SINIMPSE_DB_INSERT_1()
        {
            /*" -1405- EXEC SQL INSERT INTO SEGUROS.SINISTRO_IMP_SEG (NUM_APOL_SINISTRO, OCORR_HISTORICO, SIT_REGISTRO, COD_CAUSA, VAL_IS_DATA_OCORR, DATA_MOVIMENTO, DATA_OCORRENCIA, TIMESTAMP) VALUES (:SINISMES-NUM-APOL-SINISTRO, 1, ' ' , :SIARDEVC-COD-CAUSA, :AUTOCOBE-IMP-SEGURADA-IX, :SISTEMAS-DATA-MOV-ABERTO, :SIARDEVC-DATA-OCORRENCIA, CURRENT TIMESTAMP) END-EXEC. */

            var r3000_00_INCLUI_SINIMPSE_DB_INSERT_1_Insert1 = new R3000_00_INCLUI_SINIMPSE_DB_INSERT_1_Insert1()
            {
                SINISMES_NUM_APOL_SINISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.ToString(),
                SIARDEVC_COD_CAUSA = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_CAUSA.ToString(),
                AUTOCOBE_IMP_SEGURADA_IX = AUTOCOBE.DCLAUTO_COBERTURAS.AUTOCOBE_IMP_SEGURADA_IX.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                SIARDEVC_DATA_OCORRENCIA = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_OCORRENCIA.ToString(),
            };

            R3000_00_INCLUI_SINIMPSE_DB_INSERT_1_Insert1.Execute(r3000_00_INCLUI_SINIMPSE_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-ALTERA-SIARDEVC-SECTION */
        private void R3100_00_ALTERA_SIARDEVC_SECTION()
        {
            /*" -1432- MOVE '3100' TO WNR-EXEC-SQL */
            _.Move("3100", WABEND.WNR_EXEC_SQL);

            /*" -1447- PERFORM R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1 */

            R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1();

            /*" -1450- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1458- DISPLAY 'PROBLEMAS NO UPDATE SI_AR_DETALHE_VC' ' ' SIARDEVC-NOM-ARQUIVO ' ' SIARDEVC-SEQ-GERACAO ' ' SIARDEVC-TIPO-REGISTRO ' ' SIARDEVC-SEQ-REGISTRO ' ' SIARDEVC-NUM-APOLICE ' ' SIARDEVC-NUM-ENDOSSO ' ' SIARDEVC-NUM-ITEM */

                $"PROBLEMAS NO UPDATE SI_AR_DETALHE_VC {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_ENDOSSO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_ITEM}"
                .Display();

                /*" -1460- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1460- ADD 1 TO AC-U-SIARDEVC. */
            AC_U_SIARDEVC.Value = AC_U_SIARDEVC + 1;

        }

        [StopWatch]
        /*" R3100-00-ALTERA-SIARDEVC-DB-UPDATE-1 */
        public void R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1()
        {
            /*" -1447- EXEC SQL UPDATE SEGUROS.SI_AR_DETALHE_VC SET STA_PROCESSAMENTO = :SIARDEVC-STA-PROCESSAMENTO, STA_RETORNO = '1' , NUM_APOL_SINISTRO = :SIARDEVC-NUM-APOL-SINISTRO, OCORR_HISTORICO = :SIARDEVC-OCORR-HISTORICO, COD_ERRO = :SIARDEVC-COD-ERRO:IND-COD-ERRO WHERE NOM_ARQUIVO = :SIARDEVC-NOM-ARQUIVO AND SEQ_GERACAO = :SIARDEVC-SEQ-GERACAO AND TIPO_REGISTRO = :SIARDEVC-TIPO-REGISTRO AND SEQ_REGISTRO = :SIARDEVC-SEQ-REGISTRO END-EXEC */

            var r3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1 = new R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1()
            {
                SIARDEVC_COD_ERRO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO.ToString(),
                IND_COD_ERRO = IND_COD_ERRO.ToString(),
                SIARDEVC_STA_PROCESSAMENTO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO.ToString(),
                SIARDEVC_NUM_APOL_SINISTRO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO.ToString(),
                SIARDEVC_OCORR_HISTORICO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO.ToString(),
                SIARDEVC_TIPO_REGISTRO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO.ToString(),
                SIARDEVC_SEQ_REGISTRO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO.ToString(),
                SIARDEVC_NOM_ARQUIVO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO.ToString(),
                SIARDEVC_SEQ_GERACAO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO.ToString(),
            };

            R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1.Execute(r3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1474- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -1476- DISPLAY WABEND */
            _.Display(WABEND);

            /*" -1477- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -1478- DISPLAY '*    SI9101B - CANCELADO     *' */
            _.Display($"*    SI9101B - CANCELADO     *");

            /*" -1480- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -1480- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1484- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1484- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}