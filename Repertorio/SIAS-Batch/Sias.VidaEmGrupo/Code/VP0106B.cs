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
using Sias.VidaEmGrupo.DB2.VP0106B;

namespace Code
{
    public class VP0106B
    {
        public bool IsCall { get; set; }

        public VP0106B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  LISTA RELACAO DE SEGURADOS INATI-  *      */
        /*"      *                             VOS DA CEF  QUE  NAO  POSSUEM  O   *      */
        /*"      *                             SEGURO PREFERENCIAL VIDA.          *      */
        /*"      *                                                                *      */
        /*"      *                             LEITURA  TABELAS..: V0COBERAPOL    *      */
        /*"      *                                                 V0FUNCIOCEF    *      */
        /*"      *                                                 V0SUREG        *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA/PROGRAMADOR....  LUIZ FERNANDO GONCALVES            *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  VP0106B                            *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  FEVEREIRO/93                       *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *   ALTERACAO: INCLUIDA A EMISSAO DE SOLICITACAO POR SUREG.      *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  NOVEMBRO/94                        *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        public FileBasis _RELPREFV { get; set; } = new FileBasis(new PIC("X", "80", "X(80)"));

        public FileBasis RELPREFV
        {
            get
            {
                _.Move(REG_IMPRESSAO, _RELPREFV); VarBasis.RedefinePassValue(REG_IMPRESSAO, _RELPREFV, REG_IMPRESSAO); return _RELPREFV;
            }
        }
        /*"01   REG-IMPRESSAO              PIC  X(080).*/
        public StringBasis REG_IMPRESSAO { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  FSUREG                     PIC S9(04)      COMP.*/
        public IntBasis FSUREG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  FUNIDADE                   PIC S9(04)      COMP.*/
        public IntBasis FUNIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  FCOD-UNIDADE               PIC S9(04)      COMP.*/
        public IntBasis FCOD_UNIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  FNOME-UNIDADE              PIC  X(40).*/
        public StringBasis FNOME_UNIDADE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"01  FMATRICULA                 PIC S9(15)      COMP-3.*/
        public IntBasis FMATRICULA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  FNOME-FUNC                 PIC X(40).*/
        public StringBasis FNOME_FUNC { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"01  SUREG                      PIC X(40).*/
        public StringBasis SUREG { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"01         V1SIST-DTMOVABE     PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V1SIST-DTCURRENT    PIC  X(010).*/
        public StringBasis V1SIST_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  DATA-SOLICITACAO           PIC X(10).*/
        public StringBasis DATA_SOLICITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  NRCOPIAS                   PIC S9(004)      COMP.*/
        public IntBasis NRCOPIAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"  03        TRACO.*/
        public VP0106B_TRACO TRACO { get; set; } = new VP0106B_TRACO();
        public class VP0106B_TRACO : VarBasis
        {
            /*"      05    FILLER              PIC  X(080) VALUE ALL '-'.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"ALL");
            /*"  03        CABEC01.*/
        }
        public VP0106B_CABEC01 CABEC01 { get; set; } = new VP0106B_CABEC01();
        public class VP0106B_CABEC01 : VarBasis
        {
            /*"      05    FILLER              PIC  X(020) VALUE      'SASSE'.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"SASSE");
            /*"      05    FILLER              PIC  X(030) VALUE      'CIA NACIONAL DE SEGUROS GERAIS'.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"CIA NACIONAL DE SEGUROS GERAIS");
            /*"      05    FILLER              PIC  X(064) VALUE SPACES.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "64", "X(064)"), @"");
            /*"      05    FILLER              PIC  X(010) VALUE 'PAGINA. '.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"PAGINA. ");
            /*"      05    PAGINA-C01          PIC  ZZZZ.ZZ9.*/
            public IntBasis PAGINA_C01 { get; set; } = new IntBasis(new PIC("9", "7", "ZZZZ.ZZ9."));
            /*"  03        CABEC02.*/
        }
        public VP0106B_CABEC02 CABEC02 { get; set; } = new VP0106B_CABEC02();
        public class VP0106B_CABEC02 : VarBasis
        {
            /*"      05    FILLER              PIC  X(007) VALUE 'VP0106B'.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"VP0106B");
            /*"      05    FILLER              PIC  X(007) VALUE SPACES.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
            /*"      05    FILLER              PIC  X(044) VALUE      '   RELACAO DOS FUNCIONARIOS INATIVOS DA CEF '.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "44", "X(044)"), @"   RELACAO DOS FUNCIONARIOS INATIVOS DA CEF ");
            /*"      05    FILLER              PIC  X(058) VALUE SPACES.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "58", "X(058)"), @"");
            /*"      05    FILLER              PIC  X(006) VALUE 'DATA. '.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"DATA. ");
            /*"      05    DIA-C02             PIC  9(002).*/
            public IntBasis DIA_C02 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"      05    FILLER              PIC  X(001) VALUE '/'.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
            /*"      05    MES-C02             PIC  9(002).*/
            public IntBasis MES_C02 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"      05    FILLER              PIC  X(001) VALUE '/'.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
            /*"      05    ANO-C02             PIC  9(004).*/
            public IntBasis ANO_C02 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  03        CABEC02A.*/
        }
        public VP0106B_CABEC02A CABEC02A { get; set; } = new VP0106B_CABEC02A();
        public class VP0106B_CABEC02A : VarBasis
        {
            /*"      05    FILLER              PIC  X(017) VALUE SPACES.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"");
            /*"      05    FILLER              PIC  X(097) VALUE      'QUE NAO POSSUEM O SEGURO PREFERENCIAL VIDA'.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "97", "X(097)"), @"QUE NAO POSSUEM O SEGURO PREFERENCIAL VIDA");
            /*"      05    FILLER              PIC  X(010) VALUE 'HORA. '.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"HORA. ");
            /*"      05    HORA-C02            PIC  X(008).*/
            public StringBasis HORA_C02 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03        CABEC03.*/
        }
        public VP0106B_CABEC03 CABEC03 { get; set; } = new VP0106B_CABEC03();
        public class VP0106B_CABEC03 : VarBasis
        {
            /*"     05     FILLER          PIC  X(002) VALUE SPACES.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"     05     FILLER          PIC  X(012) VALUE 'SUREG  :   '.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"SUREG  :   ");
            /*"     05     CODFILIAL-C03   PIC  9(002) VALUE  ZEROS.*/
            public IntBasis CODFILIAL_C03 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"     05     FILLER          PIC  X(003) VALUE ' - '.*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" - ");
            /*"     05     FILIAL-C03      PIC  X(040) VALUE SPACES.*/
            public StringBasis FILIAL_C03 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"  03        CABEC03A.*/
        }
        public VP0106B_CABEC03A CABEC03A { get; set; } = new VP0106B_CABEC03A();
        public class VP0106B_CABEC03A : VarBasis
        {
            /*"    05      FILLER          PIC  X(002) VALUE SPACES.*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"    05      FILLER          PIC  X(010) VALUE 'LOTACAO: '.*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"LOTACAO: ");
            /*"    05      CODLOTACAO-C03  PIC  ZZZ9.*/
            public IntBasis CODLOTACAO_C03 { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
            /*"    05      FILLER          PIC  X(003) VALUE ' - '.*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" - ");
            /*"    05      NOMLOTACAO-C03  PIC  X(040) VALUE  SPACES.*/
            public StringBasis NOMLOTACAO_C03 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"  03        CABEC04.*/
        }
        public VP0106B_CABEC04 CABEC04 { get; set; } = new VP0106B_CABEC04();
        public class VP0106B_CABEC04 : VarBasis
        {
            /*"      05    FILLER              PIC  X(051) VALUE      'MATRICULA  NOME DO FUNCIONARIO                     '.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"MATRICULA  NOME DO FUNCIONARIO                     ");
            /*"      05    FILLER              PIC  X(029) VALUE      '                             '.*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "29", "X(029)"), @"                             ");
            /*"  03        DETALHE.*/
        }
        public VP0106B_DETALHE DETALHE { get; set; } = new VP0106B_DETALHE();
        public class VP0106B_DETALHE : VarBasis
        {
            /*"      05    MATRICULA-DET       PIC  ZZZZZZZZ9.*/
            public IntBasis MATRICULA_DET { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZZZZ9."));
            /*"      05    FILLER              PIC  X(002) VALUE SPACES.*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"      05    NOME-DET            PIC  X(040).*/
            public StringBasis NOME_DET { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"      05    FILLER              PIC  X(002) VALUE SPACES.*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"      05    FILLER              PIC  X(014) VALUE SPACES.*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
            /*"      05    FILLER              PIC  X(002) VALUE SPACES.*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"      05    FILLER              PIC  X(011) VALUE SPACES.*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"");
            /*"  03        TOTAL-FILIAL.*/
        }
        public VP0106B_TOTAL_FILIAL TOTAL_FILIAL { get; set; } = new VP0106B_TOTAL_FILIAL();
        public class VP0106B_TOTAL_FILIAL : VarBasis
        {
            /*"      05    FILLER              PIC  X(019) VALUE SPACES.*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"");
            /*"      05    FILLER              PIC  X(040) VALUE      '................  TOTAL DE FUNCIONARIOS '.*/
            public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"................  TOTAL DE FUNCIONARIOS ");
            /*"      05    FILLER              PIC  X(005) VALUE SPACES.*/
            public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
            /*"      05    DESCONTO-TOT-FL     PIC  ZZZ.ZZZ.ZZ9.*/
            public IntBasis DESCONTO_TOT_FL { get; set; } = new IntBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9."));
            /*"  03        TOTAL-GERAL.*/
        }
        public VP0106B_TOTAL_GERAL TOTAL_GERAL { get; set; } = new VP0106B_TOTAL_GERAL();
        public class VP0106B_TOTAL_GERAL : VarBasis
        {
            /*"      05    FILLER              PIC  X(019) VALUE SPACES.*/
            public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"");
            /*"      05    FILLER              PIC  X(040) VALUE      '................  TOTAL GERAL        '.*/
            public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"................  TOTAL GERAL        ");
            /*"      05    FILLER              PIC  X(005) VALUE SPACES.*/
            public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
            /*"      05    DESCONTO-GERAL      PIC  ZZZ.ZZZ.ZZ9.*/
            public IntBasis DESCONTO_GERAL { get; set; } = new IntBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9."));
            /*"  03        WSQLCODE3           PIC S9(009) COMP.*/
        }
        public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"  03        WHORA               PIC  99.99.99.99.*/
        public IntBasis WHORA { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
        /*"  03            WFIM-FUNCIOCEF      PIC  X(001) VALUE 'N'.*/
        public StringBasis WFIM_FUNCIOCEF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"  03            WFIM-RELATORIOS     PIC  X(001) VALUE 'N'.*/
        public StringBasis WFIM_RELATORIOS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"  03            WS-VARIAVEIS-ANTERIORES.*/
        public VP0106B_WS_VARIAVEIS_ANTERIORES WS_VARIAVEIS_ANTERIORES { get; set; } = new VP0106B_WS_VARIAVEIS_ANTERIORES();
        public class VP0106B_WS_VARIAVEIS_ANTERIORES : VarBasis
        {
            /*"    05          WSUREG-ANT          PIC S9(004)    COMP.*/
            public IntBasis WSUREG_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05          WS-LOTACAO-ANT      PIC S9(004) COMP VALUE ZEROS*/
            public IntBasis WS_LOTACAO_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03         WS-DATA-HOJE      PIC  9(008)    VALUE ZEROS.*/
        }
        public IntBasis WS_DATA_HOJE { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"  03         WS-DATA-HOJE-RD   REDEFINES      WS-DATA-HOJE.*/
        private _REDEF_VP0106B_WS_DATA_HOJE_RD _ws_data_hoje_rd { get; set; }
        public _REDEF_VP0106B_WS_DATA_HOJE_RD WS_DATA_HOJE_RD
        {
            get { _ws_data_hoje_rd = new _REDEF_VP0106B_WS_DATA_HOJE_RD(); _.Move(WS_DATA_HOJE, _ws_data_hoje_rd); VarBasis.RedefinePassValue(WS_DATA_HOJE, _ws_data_hoje_rd, WS_DATA_HOJE); _ws_data_hoje_rd.ValueChanged += () => { _.Move(_ws_data_hoje_rd, WS_DATA_HOJE); }; return _ws_data_hoje_rd; }
            set { VarBasis.RedefinePassValue(value, _ws_data_hoje_rd, WS_DATA_HOJE); }
        }  //Redefines
        public class _REDEF_VP0106B_WS_DATA_HOJE_RD : VarBasis
        {
            /*"    10       WS-AA-HOJE        PIC  9(004).*/
            public IntBasis WS_AA_HOJE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    10       WS-MM-HOJE        PIC  9(002).*/
            public IntBasis WS_MM_HOJE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    10       WS-DD-HOJE        PIC  9(002).*/
            public IntBasis WS_DD_HOJE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  03         WDATA-CURRENT     PIC  X(010)    VALUE SPACES.*/

            public _REDEF_VP0106B_WS_DATA_HOJE_RD()
            {
                WS_AA_HOJE.ValueChanged += OnValueChanged;
                WS_MM_HOJE.ValueChanged += OnValueChanged;
                WS_DD_HOJE.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WDATA_CURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"  03         FILLER            REDEFINES      WDATA-CURRENT.*/
        private _REDEF_VP0106B_FILLER_34 _filler_34 { get; set; }
        public _REDEF_VP0106B_FILLER_34 FILLER_34
        {
            get { _filler_34 = new _REDEF_VP0106B_FILLER_34(); _.Move(WDATA_CURRENT, _filler_34); VarBasis.RedefinePassValue(WDATA_CURRENT, _filler_34, WDATA_CURRENT); _filler_34.ValueChanged += () => { _.Move(_filler_34, WDATA_CURRENT); }; return _filler_34; }
            set { VarBasis.RedefinePassValue(value, _filler_34, WDATA_CURRENT); }
        }  //Redefines
        public class _REDEF_VP0106B_FILLER_34 : VarBasis
        {
            /*"    10       WDATA-CURR-ANO    PIC  9(004).*/
            public IntBasis WDATA_CURR_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    10       FILLER            PIC  X(001).*/
            public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    10       WDATA-CURR-MES    PIC  9(002).*/
            public IntBasis WDATA_CURR_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    10       FILLER            PIC  X(001).*/
            public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    10       WDATA-CURR-DIA    PIC  9(002).*/
            public IntBasis WDATA_CURR_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  03         WS-HORA-ATUAL.*/

            public _REDEF_VP0106B_FILLER_34()
            {
                WDATA_CURR_ANO.ValueChanged += OnValueChanged;
                FILLER_35.ValueChanged += OnValueChanged;
                WDATA_CURR_MES.ValueChanged += OnValueChanged;
                FILLER_36.ValueChanged += OnValueChanged;
                WDATA_CURR_DIA.ValueChanged += OnValueChanged;
            }

        }
        public VP0106B_WS_HORA_ATUAL WS_HORA_ATUAL { get; set; } = new VP0106B_WS_HORA_ATUAL();
        public class VP0106B_WS_HORA_ATUAL : VarBasis
        {
            /*"    10       WS-HH-ATUAL       PIC  9(002).*/
            public IntBasis WS_HH_ATUAL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    10       WS-MM-ATUAL       PIC  9(002).*/
            public IntBasis WS_MM_ATUAL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    10       WS-SS-ATUAL       PIC  9(002).*/
            public IntBasis WS_SS_ATUAL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  03         WS-HORA-CABEC.*/
        }
        public VP0106B_WS_HORA_CABEC WS_HORA_CABEC { get; set; } = new VP0106B_WS_HORA_CABEC();
        public class VP0106B_WS_HORA_CABEC : VarBasis
        {
            /*"    10       WS-HH-CABEC       PIC  9(002).*/
            public IntBasis WS_HH_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    10       FILLER            PIC  X(001) VALUE ':'.*/
            public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
            /*"    10       WS-MM-CABEC       PIC  9(002).*/
            public IntBasis WS_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    10       FILLER            PIC  X(001) VALUE ':'.*/
            public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
            /*"    10       WS-SS-CABEC       PIC  9(002).*/
            public IntBasis WS_SS_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  03        WTOT-PREMIO-L            PIC S9(009) VALUE +0 COMP.*/
        }
        public IntBasis WTOT_PREMIO_L { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"  03        WTOT-PREMIO-S            PIC S9(009) VALUE +0 COMP.*/
        public IntBasis WTOT_PREMIO_S { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"  03        WTOT-PREMIO-G            PIC S9(009) VALUE +0 COMP.*/
        public IntBasis WTOT_PREMIO_G { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"  03        W-LIDOS                  PIC  9(007) VALUE 0.*/
        public IntBasis W_LIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"  03        W-CONT-LINHA             PIC  9(007) VALUE 0.*/
        public IntBasis W_CONT_LINHA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"  03        W-PAGINA                 PIC  9(007) VALUE 0.*/
        public IntBasis W_PAGINA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"  03  WS-COUNT         PIC 9(09) VALUE 0.*/
        public IntBasis WS_COUNT { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"  03  ON-INTERVAL      PIC 9(05) VALUE 10000.*/
        public IntBasis ON_INTERVAL { get; set; } = new IntBasis(new PIC("9", "5", "9(05)"), 10000);
        /*"  03  ON-COUNTER       PIC 9(04) VALUE 0.*/
        public IntBasis ON_COUNTER { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
        /*"  03  WS-TIME          PIC 99.99.99.99.*/
        public IntBasis WS_TIME { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
        /*"  03        WABEND.*/
        public VP0106B_WABEND WABEND { get; set; } = new VP0106B_WABEND();
        public class VP0106B_WABEND : VarBasis
        {
            /*"    05      FILLER              PIC  X(010) VALUE           ' VP0106B'.*/
            public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VP0106B");
            /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
            public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
            /*"    05      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
            /*"    05      FILLER              PIC  X(017) VALUE           ' *** PARAGRAFO = '.*/
            public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @" *** PARAGRAFO = ");
            /*"    05      PARAGRAFO           PIC  X(030) VALUE SPACES.*/
            public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
            /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
            public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
            /*"    05      WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE1= '.*/
            public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE1= ");
            /*"    05      WSQLCODE1           PIC  ZZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE1 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE2= '.*/
            public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE2= ");
            /*"    05      WSQLCODE2           PIC  ZZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE2 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
        }


        public VP0106B_TRELAT TRELAT { get; set; } = new VP0106B_TRELAT();
        public VP0106B_TFUNCIOCEF TFUNCIOCEF { get; set; } = new VP0106B_TFUNCIOCEF();
        public VP0106B_TFUNCIOSUR TFUNCIOSUR { get; set; } = new VP0106B_TFUNCIOSUR();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string RELPREFV_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                RELPREFV.SetFile(RELPREFV_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM M-000-000-PRINCIPAL */

                M_000_000_PRINCIPAL();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" M-000-000-PRINCIPAL */
        private void M_000_000_PRINCIPAL(bool isPerform = false)
        {
            /*" -247- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -249- EXEC SQL WHENEVER SQLERROR GO TO 999-999-ROT-ERRO END-EXEC. */

            /*" -251- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -253- PERFORM 010-000-INICIO-PROCESSO. */

            M_010_000_INICIO_PROCESSO(true);

        }

        [StopWatch]
        /*" M-010-000-INICIO-PROCESSO */
        private void M_010_000_INICIO_PROCESSO(bool isPerform = false)
        {
            /*" -258- MOVE '010-000-INICIO-PROCESSO' TO PARAGRAFO. */
            _.Move("010-000-INICIO-PROCESSO", WABEND.PARAGRAFO);

            /*" -260- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", WABEND.WNR_EXEC_SQL);

            /*" -262- PERFORM 012-000-SELECT-V1SISTEMA */

            M_012_000_SELECT_V1SISTEMA_SECTION();

            /*" -263- MOVE V1SIST-DTCURRENT TO WDATA-CURRENT. */
            _.Move(V1SIST_DTCURRENT, WDATA_CURRENT);

            /*" -264- MOVE WDATA-CURR-DIA TO WS-DD-HOJE. */
            _.Move(FILLER_34.WDATA_CURR_DIA, WS_DATA_HOJE_RD.WS_DD_HOJE);

            /*" -265- MOVE WDATA-CURR-MES TO WS-MM-HOJE. */
            _.Move(FILLER_34.WDATA_CURR_MES, WS_DATA_HOJE_RD.WS_MM_HOJE);

            /*" -267- MOVE WDATA-CURR-ANO TO WS-AA-HOJE. */
            _.Move(FILLER_34.WDATA_CURR_ANO, WS_DATA_HOJE_RD.WS_AA_HOJE);

            /*" -269- ACCEPT WS-HORA-ATUAL FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WS_HORA_ATUAL);

            /*" -270- MOVE WS-HH-ATUAL TO WS-HH-CABEC. */
            _.Move(WS_HORA_ATUAL.WS_HH_ATUAL, WS_HORA_CABEC.WS_HH_CABEC);

            /*" -271- MOVE WS-MM-ATUAL TO WS-MM-CABEC. */
            _.Move(WS_HORA_ATUAL.WS_MM_ATUAL, WS_HORA_CABEC.WS_MM_CABEC);

            /*" -273- MOVE WS-SS-ATUAL TO WS-SS-CABEC. */
            _.Move(WS_HORA_ATUAL.WS_SS_ATUAL, WS_HORA_CABEC.WS_SS_CABEC);

            /*" -275- MOVE WS-HORA-CABEC TO HORA-C02. */
            _.Move(WS_HORA_CABEC, CABEC02A.HORA_C02);

            /*" -277- OPEN OUTPUT RELPREFV. */
            RELPREFV.Open(REG_IMPRESSAO);

            /*" -283- ACCEPT WHORA FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WHORA);

            /*" -291- PERFORM M_010_000_INICIO_PROCESSO_DB_DECLARE_1 */

            M_010_000_INICIO_PROCESSO_DB_DECLARE_1();

            /*" -293- PERFORM M_010_000_INICIO_PROCESSO_DB_OPEN_1 */

            M_010_000_INICIO_PROCESSO_DB_OPEN_1();

            /*" -297- PERFORM 102-000-FETCH-V0RELATORIOS. */

            M_102_000_FETCH_V0RELATORIOS_SECTION();

            /*" -298- IF WFIM-RELATORIOS EQUAL 'S' */

            if (WFIM_RELATORIOS == "S")
            {

                /*" -299- DISPLAY '*** VP0106B - NAO HOUVE SOLICITACAO ***' */
                _.Display($"*** VP0106B - NAO HOUVE SOLICITACAO ***");

                /*" -301- GO TO 900-000-FINALIZA. */

                M_900_000_FINALIZA_SECTION(); //GOTO
                return;
            }


            /*" -304- PERFORM 015-000-PROCESSA UNTIL WFIM-RELATORIOS EQUAL 'S' . */

            while (!(WFIM_RELATORIOS == "S"))
            {

                M_015_000_PROCESSA_SECTION();
            }

            /*" -304- PERFORM 900-000-FINALIZA. */

            M_900_000_FINALIZA_SECTION();

        }

        [StopWatch]
        /*" M-010-000-INICIO-PROCESSO-DB-DECLARE-1 */
        public void M_010_000_INICIO_PROCESSO_DB_DECLARE_1()
        {
            /*" -291- EXEC SQL DECLARE TRELAT CURSOR FOR SELECT DATA_SOLICITACAO, NRCOPIAS FROM SEGUROS.V1RELATORIOS WHERE CODRELAT = 'VP0106B' AND SITUACAO = '0' END-EXEC. */
            TRELAT = new VP0106B_TRELAT(false);
            string GetQuery_TRELAT()
            {
                var query = @$"SELECT DATA_SOLICITACAO
							, 
							NRCOPIAS 
							FROM SEGUROS.V1RELATORIOS 
							WHERE CODRELAT = 'VP0106B' AND 
							SITUACAO = '0'";

                return query;
            }
            TRELAT.GetQueryEvent += GetQuery_TRELAT;

        }

        [StopWatch]
        /*" M-010-000-INICIO-PROCESSO-DB-OPEN-1 */
        public void M_010_000_INICIO_PROCESSO_DB_OPEN_1()
        {
            /*" -293- EXEC SQL OPEN TRELAT END-EXEC. */

            TRELAT.Open();

        }

        [StopWatch]
        /*" M-090-000-CURSOR-V0FUNCIOCEF-DB-DECLARE-1 */
        public void M_090_000_CURSOR_V0FUNCIOCEF_DB_DECLARE_1()
        {
            /*" -466- EXEC SQL DECLARE TFUNCIOCEF CURSOR FOR SELECT COD_SUREG, COD_UNIDADE, NOME_UNIDADE, NUM_MATRICULA, NOME_FUNCIONARIO FROM SEGUROS.V0FUNCIOCEF WHERE TIPO_VINCULO <> 'EMPREGADO CEF' AND VALOR3 = 0 ORDER BY COD_SUREG, COD_UNIDADE, NOME_FUNCIONARIO END-EXEC. */
            TFUNCIOCEF = new VP0106B_TFUNCIOCEF(false);
            string GetQuery_TFUNCIOCEF()
            {
                var query = @$"SELECT 
							COD_SUREG
							, 
							COD_UNIDADE
							, 
							NOME_UNIDADE
							, 
							NUM_MATRICULA
							, 
							NOME_FUNCIONARIO 
							FROM SEGUROS.V0FUNCIOCEF 
							WHERE 
							TIPO_VINCULO <> 'EMPREGADO CEF' 
							AND VALOR3 = 0 
							ORDER BY 
							COD_SUREG
							, 
							COD_UNIDADE
							, 
							NOME_FUNCIONARIO";

                return query;
            }
            TFUNCIOCEF.GetQueryEvent += GetQuery_TFUNCIOCEF;

        }

        [StopWatch]
        /*" M-012-000-SELECT-V1SISTEMA-SECTION */
        private void M_012_000_SELECT_V1SISTEMA_SECTION()
        {
            /*" -310- MOVE '012-000-PROCESSA       ' TO PARAGRAFO. */
            _.Move("012-000-PROCESSA       ", WABEND.PARAGRAFO);

            /*" -312- MOVE '012' TO WNR-EXEC-SQL. */
            _.Move("012", WABEND.WNR_EXEC_SQL);

            /*" -317- PERFORM M_012_000_SELECT_V1SISTEMA_DB_SELECT_1 */

            M_012_000_SELECT_V1SISTEMA_DB_SELECT_1();

        }

        [StopWatch]
        /*" M-012-000-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void M_012_000_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -317- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :V1SIST-DTMOVABE, :V1SIST-DTCURRENT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VP' END-EXEC. */

            var m_012_000_SELECT_V1SISTEMA_DB_SELECT_1_Query1 = new M_012_000_SELECT_V1SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_012_000_SELECT_V1SISTEMA_DB_SELECT_1_Query1.Execute(m_012_000_SELECT_V1SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
                _.Move(executed_1.V1SIST_DTCURRENT, V1SIST_DTCURRENT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_012_999_EXIT*/

        [StopWatch]
        /*" M-015-000-PROCESSA-SECTION */
        private void M_015_000_PROCESSA_SECTION()
        {
            /*" -327- MOVE '015-000-PROCESSA       ' TO PARAGRAFO. */
            _.Move("015-000-PROCESSA       ", WABEND.PARAGRAFO);

            /*" -329- MOVE '015' TO WNR-EXEC-SQL. */
            _.Move("015", WABEND.WNR_EXEC_SQL);

            /*" -332- DISPLAY 'INICIO DO DECLARE NA V0FUNCIOCEF' WHORA UPON CONSOLE. */
            _.Display($"INICIO DO DECLARE NA V0FUNCIOCEF{WHORA}");

            /*" -333- IF NRCOPIAS EQUAL 0 */

            if (NRCOPIAS == 0)
            {

                /*" -334- PERFORM 090-000-CURSOR-V0FUNCIOCEF */

                M_090_000_CURSOR_V0FUNCIOCEF_SECTION();

                /*" -335- ELSE */
            }
            else
            {


                /*" -337- PERFORM 091-000-CURSOR-V0FUNCIOSUR. */

                M_091_000_CURSOR_V0FUNCIOSUR_SECTION();
            }


            /*" -338- ACCEPT WHORA FROM TIME */
            _.Move(_.AcceptDate("TIME"), WHORA);

            /*" -341- DISPLAY 'FIM DO DECLARE NA V0FUNCIOCEF' WHORA UPON CONSOLE. */
            _.Display($"FIM DO DECLARE NA V0FUNCIOCEF{WHORA}");

            /*" -342- IF NRCOPIAS EQUAL 0 */

            if (NRCOPIAS == 0)
            {

                /*" -343- PERFORM 100-000-FETCH-V0FUNCIOCEF */

                M_100_000_FETCH_V0FUNCIOCEF_SECTION();

                /*" -344- ELSE */
            }
            else
            {


                /*" -346- PERFORM 101-000-FETCH-V0FUNCIOSUR. */

                M_101_000_FETCH_V0FUNCIOSUR_SECTION();
            }


            /*" -348- IF WFIM-FUNCIOCEF EQUAL 'N' NEXT SENTENCE */

            if (WFIM_FUNCIOCEF == "N")
            {

                /*" -349- ELSE */
            }
            else
            {


                /*" -351- DISPLAY '------------------------------------------------- '---------------------------------------' */
                _.Display($"------------------------------------------------- ---------------------------------------");

                /*" -353- DISPLAY ' VP0106B - NAO HOUVE SELECAO DE SEGURADO DO SEGU' 'RO PREFERENCIAL VIDA' */
                _.Display($" VP0106B - NAO HOUVE SELECAO DE SEGURADO DO SEGURO PREFERENCIAL VIDA");

                /*" -355- DISPLAY '------------------------------------------------- '---------------------------------------' */
                _.Display($"------------------------------------------------- ---------------------------------------");

                /*" -357- DISPLAY ' ' . */
                _.Display($" ");
            }


            /*" -360- PERFORM 020-000-PROCESSA UNTIL WFIM-FUNCIOCEF EQUAL 'S' . */

            while (!(WFIM_FUNCIOCEF == "S"))
            {

                M_020_000_PROCESSA_SECTION();
            }

            /*" -366- PERFORM M_015_000_PROCESSA_DB_UPDATE_1 */

            M_015_000_PROCESSA_DB_UPDATE_1();

            /*" -370- PERFORM 800-000-TOTAL-GERAL. */

            M_800_000_TOTAL_GERAL_SECTION();

            /*" -371- MOVE 'N' TO WFIM-FUNCIOCEF. */
            _.Move("N", WFIM_FUNCIOCEF);

            /*" -377- MOVE ZEROS TO WTOT-PREMIO-L WTOT-PREMIO-S WTOT-PREMIO-G W-PAGINA W-CONT-LINHA. */
            _.Move(0, WTOT_PREMIO_L, WTOT_PREMIO_S, WTOT_PREMIO_G, W_PAGINA, W_CONT_LINHA);

            /*" -377- PERFORM 102-000-FETCH-V0RELATORIOS. */

            M_102_000_FETCH_V0RELATORIOS_SECTION();

        }

        [StopWatch]
        /*" M-015-000-PROCESSA-DB-UPDATE-1 */
        public void M_015_000_PROCESSA_DB_UPDATE_1()
        {
            /*" -366- EXEC SQL UPDATE SEGUROS.V1RELATORIOS SET SITUACAO = '1' WHERE CODRELAT = 'VP0106B' AND SITUACAO = '0' AND NRCOPIAS = :NRCOPIAS END-EXEC. */

            var m_015_000_PROCESSA_DB_UPDATE_1_Update1 = new M_015_000_PROCESSA_DB_UPDATE_1_Update1()
            {
                NRCOPIAS = NRCOPIAS.ToString(),
            };

            M_015_000_PROCESSA_DB_UPDATE_1_Update1.Execute(m_015_000_PROCESSA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_015_999_EXIT*/

        [StopWatch]
        /*" M-020-000-PROCESSA-SECTION */
        private void M_020_000_PROCESSA_SECTION()
        {
            /*" -386- MOVE '020-000-PROCESSA       ' TO PARAGRAFO. */
            _.Move("020-000-PROCESSA       ", WABEND.PARAGRAFO);

            /*" -388- MOVE '020' TO WNR-EXEC-SQL. */
            _.Move("020", WABEND.WNR_EXEC_SQL);

            /*" -389- MOVE FSUREG TO WSUREG-ANT */
            _.Move(FSUREG, WS_VARIAVEIS_ANTERIORES.WSUREG_ANT);

            /*" -390- PERFORM 150-000-SELECT-V0SUREG. */

            M_150_000_SELECT_V0SUREG_SECTION();

            /*" -392- MOVE ZEROS TO WTOT-PREMIO-S. */
            _.Move(0, WTOT_PREMIO_S);

            /*" -396- PERFORM 030-000-TRATA-SUREG UNTIL FSUREG NOT = WSUREG-ANT OR WFIM-FUNCIOCEF EQUAL 'S' . */

            while (!(FSUREG != WS_VARIAVEIS_ANTERIORES.WSUREG_ANT || WFIM_FUNCIOCEF == "S"))
            {

                M_030_000_TRATA_SUREG_SECTION();
            }

            /*" -396- PERFORM 270-000-TOTAL-SUREG. */

            M_270_000_TOTAL_SUREG_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_020_999_EXIT*/

        [StopWatch]
        /*" M-030-000-TRATA-SUREG-SECTION */
        private void M_030_000_TRATA_SUREG_SECTION()
        {
            /*" -405- MOVE FCOD-UNIDADE TO WS-LOTACAO-ANT */
            _.Move(FCOD_UNIDADE, WS_VARIAVEIS_ANTERIORES.WS_LOTACAO_ANT);

            /*" -406- MOVE FCOD-UNIDADE TO CODLOTACAO-C03. */
            _.Move(FCOD_UNIDADE, CABEC03A.CODLOTACAO_C03);

            /*" -408- MOVE FNOME-UNIDADE TO NOMLOTACAO-C03. */
            _.Move(FNOME_UNIDADE, CABEC03A.NOMLOTACAO_C03);

            /*" -410- PERFORM 265-000-CABECALHO. */

            M_265_000_CABECALHO_SECTION();

            /*" -412- MOVE ZEROS TO WTOT-PREMIO-L. */
            _.Move(0, WTOT_PREMIO_L);

            /*" -416- PERFORM 040-000-TRATA-LOTACAO UNTIL FCOD-UNIDADE NOT = WS-LOTACAO-ANT OR WFIM-FUNCIOCEF EQUAL 'S' . */

            while (!(FCOD_UNIDADE != WS_VARIAVEIS_ANTERIORES.WS_LOTACAO_ANT || WFIM_FUNCIOCEF == "S"))
            {

                M_040_000_TRATA_LOTACAO_SECTION();
            }

            /*" -416- PERFORM 280-000-TOTAL-LOTACAO. */

            M_280_000_TOTAL_LOTACAO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_030_999_EXIT*/

        [StopWatch]
        /*" M-040-000-TRATA-LOTACAO-SECTION */
        private void M_040_000_TRATA_LOTACAO_SECTION()
        {
            /*" -424- ADD 1 TO W-LIDOS. */
            W_LIDOS.Value = W_LIDOS + 1;

            /*" -426- PERFORM 8888-DISPLAY-TOTAIS THRU 8888-EXIT */

            M_8888_DISPLAY_TOTAIS_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8888_EXIT*/


            /*" -428- PERFORM 255-000-MONTA-DETALHE. */

            M_255_000_MONTA_DETALHE_SECTION();

            /*" -430- PERFORM 260-000-IMPRIME-RELACAO. */

            M_260_000_IMPRIME_RELACAO_SECTION();

            /*" -431- IF NRCOPIAS EQUAL 0 */

            if (NRCOPIAS == 0)
            {

                /*" -432- PERFORM 100-000-FETCH-V0FUNCIOCEF */

                M_100_000_FETCH_V0FUNCIOCEF_SECTION();

                /*" -433- ELSE */
            }
            else
            {


                /*" -433- PERFORM 101-000-FETCH-V0FUNCIOSUR. */

                M_101_000_FETCH_V0FUNCIOSUR_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_040_999_EXIT*/

        [StopWatch]
        /*" M-090-000-CURSOR-V0FUNCIOCEF-SECTION */
        private void M_090_000_CURSOR_V0FUNCIOCEF_SECTION()
        {
            /*" -447- MOVE '090-000-CURSOR-V0FUNCIOCEF' TO PARAGRAFO. */
            _.Move("090-000-CURSOR-V0FUNCIOCEF", WABEND.PARAGRAFO);

            /*" -448- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", WABEND.WNR_EXEC_SQL);

            /*" -450- MOVE 'N' TO WFIM-FUNCIOCEF. */
            _.Move("N", WFIM_FUNCIOCEF);

            /*" -466- PERFORM M_090_000_CURSOR_V0FUNCIOCEF_DB_DECLARE_1 */

            M_090_000_CURSOR_V0FUNCIOCEF_DB_DECLARE_1();

            /*" -468- PERFORM M_090_000_CURSOR_V0FUNCIOCEF_DB_OPEN_1 */

            M_090_000_CURSOR_V0FUNCIOCEF_DB_OPEN_1();

        }

        [StopWatch]
        /*" M-090-000-CURSOR-V0FUNCIOCEF-DB-OPEN-1 */
        public void M_090_000_CURSOR_V0FUNCIOCEF_DB_OPEN_1()
        {
            /*" -468- EXEC SQL OPEN TFUNCIOCEF END-EXEC. */

            TFUNCIOCEF.Open();

        }

        [StopWatch]
        /*" M-091-000-CURSOR-V0FUNCIOSUR-DB-DECLARE-1 */
        public void M_091_000_CURSOR_V0FUNCIOSUR_DB_DECLARE_1()
        {
            /*" -502- EXEC SQL DECLARE TFUNCIOSUR CURSOR FOR SELECT COD_SUREG, COD_UNIDADE, NOME_UNIDADE, NUM_MATRICULA, NOME_FUNCIONARIO FROM SEGUROS.V0FUNCIOCEF WHERE TIPO_VINCULO <> 'EMPREGADO CEF' AND VALOR3 = 0 AND COD_SUREG = :NRCOPIAS ORDER BY COD_SUREG, COD_UNIDADE, NOME_FUNCIONARIO END-EXEC. */
            TFUNCIOSUR = new VP0106B_TFUNCIOSUR(true);
            string GetQuery_TFUNCIOSUR()
            {
                var query = @$"SELECT 
							COD_SUREG
							, 
							COD_UNIDADE
							, 
							NOME_UNIDADE
							, 
							NUM_MATRICULA
							, 
							NOME_FUNCIONARIO 
							FROM SEGUROS.V0FUNCIOCEF 
							WHERE 
							TIPO_VINCULO <> 'EMPREGADO CEF' 
							AND VALOR3 = 0 
							AND COD_SUREG = '{NRCOPIAS}' 
							ORDER BY 
							COD_SUREG
							, 
							COD_UNIDADE
							, 
							NOME_FUNCIONARIO";

                return query;
            }
            TFUNCIOSUR.GetQueryEvent += GetQuery_TFUNCIOSUR;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_090_999_EXIT*/

        [StopWatch]
        /*" M-091-000-CURSOR-V0FUNCIOSUR-SECTION */
        private void M_091_000_CURSOR_V0FUNCIOSUR_SECTION()
        {
            /*" -482- MOVE '091-000-CURSOR-V0FUNCIOSUR' TO PARAGRAFO. */
            _.Move("091-000-CURSOR-V0FUNCIOSUR", WABEND.PARAGRAFO);

            /*" -483- MOVE '091' TO WNR-EXEC-SQL. */
            _.Move("091", WABEND.WNR_EXEC_SQL);

            /*" -485- MOVE 'N' TO WFIM-FUNCIOCEF. */
            _.Move("N", WFIM_FUNCIOCEF);

            /*" -502- PERFORM M_091_000_CURSOR_V0FUNCIOSUR_DB_DECLARE_1 */

            M_091_000_CURSOR_V0FUNCIOSUR_DB_DECLARE_1();

            /*" -504- PERFORM M_091_000_CURSOR_V0FUNCIOSUR_DB_OPEN_1 */

            M_091_000_CURSOR_V0FUNCIOSUR_DB_OPEN_1();

        }

        [StopWatch]
        /*" M-091-000-CURSOR-V0FUNCIOSUR-DB-OPEN-1 */
        public void M_091_000_CURSOR_V0FUNCIOSUR_DB_OPEN_1()
        {
            /*" -504- EXEC SQL OPEN TFUNCIOSUR END-EXEC. */

            TFUNCIOSUR.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_091_999_EXIT*/

        [StopWatch]
        /*" M-100-000-FETCH-V0FUNCIOCEF-SECTION */
        private void M_100_000_FETCH_V0FUNCIOCEF_SECTION()
        {
            /*" -518- MOVE '100-000-FETCH-V0FUNCIOCEF' TO PARAGRAFO. */
            _.Move("100-000-FETCH-V0FUNCIOCEF", WABEND.PARAGRAFO);

            /*" -520- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", WABEND.WNR_EXEC_SQL);

            /*" -527- PERFORM M_100_000_FETCH_V0FUNCIOCEF_DB_FETCH_1 */

            M_100_000_FETCH_V0FUNCIOCEF_DB_FETCH_1();

            /*" -530- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -531- MOVE 'S' TO WFIM-FUNCIOCEF */
                _.Move("S", WFIM_FUNCIOCEF);

                /*" -531- PERFORM M_100_000_FETCH_V0FUNCIOCEF_DB_CLOSE_1 */

                M_100_000_FETCH_V0FUNCIOCEF_DB_CLOSE_1();

                /*" -532- GO TO 100-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_999_EXIT*/ //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-100-000-FETCH-V0FUNCIOCEF-DB-FETCH-1 */
        public void M_100_000_FETCH_V0FUNCIOCEF_DB_FETCH_1()
        {
            /*" -527- EXEC SQL FETCH TFUNCIOCEF INTO :FSUREG, :FCOD-UNIDADE, :FNOME-UNIDADE, :FMATRICULA, :FNOME-FUNC END-EXEC. */

            if (TFUNCIOCEF.Fetch())
            {
                _.Move(TFUNCIOCEF.FSUREG, FSUREG);
                _.Move(TFUNCIOCEF.FCOD_UNIDADE, FCOD_UNIDADE);
                _.Move(TFUNCIOCEF.FNOME_UNIDADE, FNOME_UNIDADE);
                _.Move(TFUNCIOCEF.FMATRICULA, FMATRICULA);
                _.Move(TFUNCIOCEF.FNOME_FUNC, FNOME_FUNC);
            }

        }

        [StopWatch]
        /*" M-100-000-FETCH-V0FUNCIOCEF-DB-CLOSE-1 */
        public void M_100_000_FETCH_V0FUNCIOCEF_DB_CLOSE_1()
        {
            /*" -531- EXEC SQL CLOSE TFUNCIOCEF END-EXEC */

            TFUNCIOCEF.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_999_EXIT*/

        [StopWatch]
        /*" M-101-000-FETCH-V0FUNCIOSUR-SECTION */
        private void M_101_000_FETCH_V0FUNCIOSUR_SECTION()
        {
            /*" -546- MOVE '101-000-FETCH-V0FUNCIOSUR' TO PARAGRAFO. */
            _.Move("101-000-FETCH-V0FUNCIOSUR", WABEND.PARAGRAFO);

            /*" -548- MOVE '101' TO WNR-EXEC-SQL. */
            _.Move("101", WABEND.WNR_EXEC_SQL);

            /*" -555- PERFORM M_101_000_FETCH_V0FUNCIOSUR_DB_FETCH_1 */

            M_101_000_FETCH_V0FUNCIOSUR_DB_FETCH_1();

            /*" -558- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -559- MOVE 'S' TO WFIM-FUNCIOCEF */
                _.Move("S", WFIM_FUNCIOCEF);

                /*" -559- PERFORM M_101_000_FETCH_V0FUNCIOSUR_DB_CLOSE_1 */

                M_101_000_FETCH_V0FUNCIOSUR_DB_CLOSE_1();

                /*" -560- GO TO 101-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_101_999_EXIT*/ //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-101-000-FETCH-V0FUNCIOSUR-DB-FETCH-1 */
        public void M_101_000_FETCH_V0FUNCIOSUR_DB_FETCH_1()
        {
            /*" -555- EXEC SQL FETCH TFUNCIOSUR INTO :FSUREG, :FCOD-UNIDADE, :FNOME-UNIDADE, :FMATRICULA, :FNOME-FUNC END-EXEC. */

            if (TFUNCIOSUR.Fetch())
            {
                _.Move(TFUNCIOSUR.FSUREG, FSUREG);
                _.Move(TFUNCIOSUR.FCOD_UNIDADE, FCOD_UNIDADE);
                _.Move(TFUNCIOSUR.FNOME_UNIDADE, FNOME_UNIDADE);
                _.Move(TFUNCIOSUR.FMATRICULA, FMATRICULA);
                _.Move(TFUNCIOSUR.FNOME_FUNC, FNOME_FUNC);
            }

        }

        [StopWatch]
        /*" M-101-000-FETCH-V0FUNCIOSUR-DB-CLOSE-1 */
        public void M_101_000_FETCH_V0FUNCIOSUR_DB_CLOSE_1()
        {
            /*" -559- EXEC SQL CLOSE TFUNCIOSUR END-EXEC */

            TFUNCIOSUR.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_101_999_EXIT*/

        [StopWatch]
        /*" M-102-000-FETCH-V0RELATORIOS-SECTION */
        private void M_102_000_FETCH_V0RELATORIOS_SECTION()
        {
            /*" -570- MOVE '102-000-FETCH-V0RELATORIO' TO PARAGRAFO. */
            _.Move("102-000-FETCH-V0RELATORIO", WABEND.PARAGRAFO);

            /*" -572- MOVE '102' TO WNR-EXEC-SQL. */
            _.Move("102", WABEND.WNR_EXEC_SQL);

            /*" -575- PERFORM M_102_000_FETCH_V0RELATORIOS_DB_FETCH_1 */

            M_102_000_FETCH_V0RELATORIOS_DB_FETCH_1();

            /*" -578- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -579- MOVE 'S' TO WFIM-RELATORIOS */
                _.Move("S", WFIM_RELATORIOS);

                /*" -579- PERFORM M_102_000_FETCH_V0RELATORIOS_DB_CLOSE_1 */

                M_102_000_FETCH_V0RELATORIOS_DB_CLOSE_1();

                /*" -580- GO TO 102-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_102_999_EXIT*/ //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-102-000-FETCH-V0RELATORIOS-DB-FETCH-1 */
        public void M_102_000_FETCH_V0RELATORIOS_DB_FETCH_1()
        {
            /*" -575- EXEC SQL FETCH TRELAT INTO :DATA-SOLICITACAO, :NRCOPIAS END-EXEC. */

            if (TRELAT.Fetch())
            {
                _.Move(TRELAT.DATA_SOLICITACAO, DATA_SOLICITACAO);
                _.Move(TRELAT.NRCOPIAS, NRCOPIAS);
            }

        }

        [StopWatch]
        /*" M-102-000-FETCH-V0RELATORIOS-DB-CLOSE-1 */
        public void M_102_000_FETCH_V0RELATORIOS_DB_CLOSE_1()
        {
            /*" -579- EXEC SQL CLOSE TRELAT END-EXEC */

            TRELAT.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_102_999_EXIT*/

        [StopWatch]
        /*" M-150-000-SELECT-V0SUREG-SECTION */
        private void M_150_000_SELECT_V0SUREG_SECTION()
        {
            /*" -594- MOVE '150-000-SELECT-V0SUREG' TO PARAGRAFO. */
            _.Move("150-000-SELECT-V0SUREG", WABEND.PARAGRAFO);

            /*" -596- MOVE '150' TO WNR-EXEC-SQL. */
            _.Move("150", WABEND.WNR_EXEC_SQL);

            /*" -604- PERFORM M_150_000_SELECT_V0SUREG_DB_SELECT_1 */

            M_150_000_SELECT_V0SUREG_DB_SELECT_1();

            /*" -608- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -610- MOVE FSUREG TO SUREG. */
                _.Move(FSUREG, SUREG);
            }


            /*" -611- MOVE FSUREG TO CODFILIAL-C03. */
            _.Move(FSUREG, CABEC03.CODFILIAL_C03);

            /*" -611- MOVE SUREG TO FILIAL-C03. */
            _.Move(SUREG, CABEC03.FILIAL_C03);

        }

        [StopWatch]
        /*" M-150-000-SELECT-V0SUREG-DB-SELECT-1 */
        public void M_150_000_SELECT_V0SUREG_DB_SELECT_1()
        {
            /*" -604- EXEC SQL SELECT NOME_SUREG INTO :SUREG FROM SEGUROS.V0SUREG WHERE COD_SUREG = :FSUREG END-EXEC. */

            var m_150_000_SELECT_V0SUREG_DB_SELECT_1_Query1 = new M_150_000_SELECT_V0SUREG_DB_SELECT_1_Query1()
            {
                FSUREG = FSUREG.ToString(),
            };

            var executed_1 = M_150_000_SELECT_V0SUREG_DB_SELECT_1_Query1.Execute(m_150_000_SELECT_V0SUREG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SUREG, SUREG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_220_999_EXIT*/

        [StopWatch]
        /*" M-255-000-MONTA-DETALHE-SECTION */
        private void M_255_000_MONTA_DETALHE_SECTION()
        {
            /*" -623- MOVE FMATRICULA TO MATRICULA-DET. */
            _.Move(FMATRICULA, DETALHE.MATRICULA_DET);

            /*" -623- MOVE FNOME-FUNC TO NOME-DET. */
            _.Move(FNOME_FUNC, DETALHE.NOME_DET);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_255_999_EXIT*/

        [StopWatch]
        /*" M-260-000-IMPRIME-RELACAO-SECTION */
        private void M_260_000_IMPRIME_RELACAO_SECTION()
        {
            /*" -640- ADD 1 TO WTOT-PREMIO-L WTOT-PREMIO-S WTOT-PREMIO-G. */
            WTOT_PREMIO_L.Value = WTOT_PREMIO_L + 1;
            WTOT_PREMIO_S.Value = WTOT_PREMIO_S + 1;
            WTOT_PREMIO_G.Value = WTOT_PREMIO_G + 1;

            /*" -641- IF W-CONT-LINHA = 48 */

            if (W_CONT_LINHA == 48)
            {

                /*" -643- PERFORM 265-000-CABECALHO. */

                M_265_000_CABECALHO_SECTION();
            }


            /*" -645- WRITE REG-IMPRESSAO FROM DETALHE AFTER 1. */
            _.Move(DETALHE.GetMoveValues(), REG_IMPRESSAO);

            RELPREFV.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -645- ADD 1 TO W-CONT-LINHA. */
            W_CONT_LINHA.Value = W_CONT_LINHA + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_260_999_EXIT*/

        [StopWatch]
        /*" M-265-000-CABECALHO-SECTION */
        private void M_265_000_CABECALHO_SECTION()
        {
            /*" -658- ADD 1 TO W-PAGINA */
            W_PAGINA.Value = W_PAGINA + 1;

            /*" -660- MOVE W-PAGINA TO PAGINA-C01 */
            _.Move(W_PAGINA, CABEC01.PAGINA_C01);

            /*" -661- MOVE WS-AA-HOJE TO ANO-C02 */
            _.Move(WS_DATA_HOJE_RD.WS_AA_HOJE, CABEC02.ANO_C02);

            /*" -662- MOVE WS-MM-HOJE TO MES-C02 */
            _.Move(WS_DATA_HOJE_RD.WS_MM_HOJE, CABEC02.MES_C02);

            /*" -664- MOVE WS-DD-HOJE TO DIA-C02 */
            _.Move(WS_DATA_HOJE_RD.WS_DD_HOJE, CABEC02.DIA_C02);

            /*" -665- WRITE REG-IMPRESSAO FROM TRACO AFTER PAGE. */
            _.Move(TRACO.GetMoveValues(), REG_IMPRESSAO);

            RELPREFV.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -666- WRITE REG-IMPRESSAO FROM CABEC01 AFTER 1. */
            _.Move(CABEC01.GetMoveValues(), REG_IMPRESSAO);

            RELPREFV.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -667- WRITE REG-IMPRESSAO FROM CABEC02 AFTER 1. */
            _.Move(CABEC02.GetMoveValues(), REG_IMPRESSAO);

            RELPREFV.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -668- WRITE REG-IMPRESSAO FROM CABEC02A AFTER 1. */
            _.Move(CABEC02A.GetMoveValues(), REG_IMPRESSAO);

            RELPREFV.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -669- WRITE REG-IMPRESSAO FROM TRACO AFTER 1. */
            _.Move(TRACO.GetMoveValues(), REG_IMPRESSAO);

            RELPREFV.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -670- WRITE REG-IMPRESSAO FROM CABEC03 AFTER 1. */
            _.Move(CABEC03.GetMoveValues(), REG_IMPRESSAO);

            RELPREFV.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -671- WRITE REG-IMPRESSAO FROM CABEC03A AFTER 1. */
            _.Move(CABEC03A.GetMoveValues(), REG_IMPRESSAO);

            RELPREFV.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -673- WRITE REG-IMPRESSAO FROM CABEC04 AFTER 2. */
            _.Move(CABEC04.GetMoveValues(), REG_IMPRESSAO);

            RELPREFV.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -674- MOVE SPACES TO REG-IMPRESSAO. */
            _.Move("", REG_IMPRESSAO);

            /*" -676- WRITE REG-IMPRESSAO AFTER 1. */
            RELPREFV.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -676- MOVE ZEROS TO W-CONT-LINHA. */
            _.Move(0, W_CONT_LINHA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_265_999_EXIT*/

        [StopWatch]
        /*" M-270-000-TOTAL-SUREG-SECTION */
        private void M_270_000_TOTAL_SUREG_SECTION()
        {
            /*" -691- MOVE WTOT-PREMIO-S TO DESCONTO-TOT-FL. */
            _.Move(WTOT_PREMIO_S, TOTAL_FILIAL.DESCONTO_TOT_FL);

            /*" -691- WRITE REG-IMPRESSAO FROM TOTAL-FILIAL AFTER 3. */
            _.Move(TOTAL_FILIAL.GetMoveValues(), REG_IMPRESSAO);

            RELPREFV.Write(REG_IMPRESSAO.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_270_999_EXIT*/

        [StopWatch]
        /*" M-280-000-TOTAL-LOTACAO-SECTION */
        private void M_280_000_TOTAL_LOTACAO_SECTION()
        {
            /*" -702- MOVE WTOT-PREMIO-L TO DESCONTO-TOT-FL. */
            _.Move(WTOT_PREMIO_L, TOTAL_FILIAL.DESCONTO_TOT_FL);

            /*" -702- WRITE REG-IMPRESSAO FROM TOTAL-FILIAL AFTER 3. */
            _.Move(TOTAL_FILIAL.GetMoveValues(), REG_IMPRESSAO);

            RELPREFV.Write(REG_IMPRESSAO.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_270_999_EXIT*/

        [StopWatch]
        /*" M-800-000-TOTAL-GERAL-SECTION */
        private void M_800_000_TOTAL_GERAL_SECTION()
        {
            /*" -712- IF W-LIDOS EQUAL ZEROS */

            if (W_LIDOS == 00)
            {

                /*" -714- GO TO 800-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_800_999_EXIT*/ //GOTO
                return;
            }


            /*" -715- MOVE WTOT-PREMIO-G TO DESCONTO-GERAL. */
            _.Move(WTOT_PREMIO_G, TOTAL_GERAL.DESCONTO_GERAL);

            /*" -715- WRITE REG-IMPRESSAO FROM TOTAL-GERAL AFTER 2. */
            _.Move(TOTAL_GERAL.GetMoveValues(), REG_IMPRESSAO);

            RELPREFV.Write(REG_IMPRESSAO.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_800_999_EXIT*/

        [StopWatch]
        /*" M-8888-DISPLAY-TOTAIS-SECTION */
        private void M_8888_DISPLAY_TOTAIS_SECTION()
        {
            /*" -726- ADD 1 TO WS-COUNT ON-COUNTER. */
            WS_COUNT.Value = WS_COUNT + 1;
            ON_COUNTER.Value = ON_COUNTER + 1;

            /*" -728- IF WS-COUNT EQUAL 10000 OR ON-COUNTER EQUAL ON-INTERVAL */

            if (WS_COUNT == 10000 || ON_COUNTER == ON_INTERVAL)
            {

                /*" -729- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), WS_TIME);

                /*" -731- DISPLAY 'FUNCIONARIOS LIDOS ' WS-COUNT ' ' WS-TIME UPON CONSOLE */

                $"FUNCIONARIOS LIDOS {WS_COUNT} {WS_TIME}"
                .Display();

                /*" -731- MOVE 0 TO ON-COUNTER. */
                _.Move(0, ON_COUNTER);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8888_EXIT*/

        [StopWatch]
        /*" M-900-000-FINALIZA-SECTION */
        private void M_900_000_FINALIZA_SECTION()
        {
            /*" -740- CLOSE RELPREFV. */
            RELPREFV.Close();

            /*" -740- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -743- IF W-LIDOS NOT EQUAL ZEROS */

            if (W_LIDOS != 00)
            {

                /*" -744- DISPLAY 'VP0106B --------------------------------------' */
                _.Display($"VP0106B --------------------------------------");

                /*" -745- DISPLAY '  TOTAL DE REGISTROS PROCESSADOS.             ' */
                _.Display($"  TOTAL DE REGISTROS PROCESSADOS.             ");

                /*" -746- DISPLAY '      TOTAL DE LIDOS............ ' W-LIDOS */
                _.Display($"      TOTAL DE LIDOS............ {W_LIDOS}");

                /*" -747- DISPLAY '----------------------------------------------' */
                _.Display($"----------------------------------------------");

                /*" -749- DISPLAY 'FIM NORMAL      **** VP0106B ****' . */
                _.Display($"FIM NORMAL      **** VP0106B ****");
            }


            /*" -750- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -750- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_900_999_EXIT*/

        [StopWatch]
        /*" M-999-999-ROT-ERRO */
        private void M_999_999_ROT_ERRO(bool isPerform = false)
        {
            /*" -762- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -763- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.WSQLCODE);

                /*" -764- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], WABEND.WSQLCODE1);

                /*" -765- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], WABEND.WSQLCODE2);

                /*" -766- MOVE SQLCODE TO WSQLCODE3 */
                _.Move(DB.SQLCODE, WSQLCODE3);

                /*" -768- DISPLAY WABEND. */
                _.Display(WABEND);
            }


            /*" -770- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -774- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -778- MOVE 9 TO RETURN-CODE */
            _.Move(9, RETURN_CODE);

            /*" -778- GOBACK. */

            throw new GoBack();

        }
    }
}