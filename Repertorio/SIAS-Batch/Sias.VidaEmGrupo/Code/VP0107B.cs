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
using Sias.VidaEmGrupo.DB2.VP0107B;

namespace Code
{
    public class VP0107B
    {
        public bool IsCall { get; set; }

        public VP0107B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  LISTA RELACAO DE  SEGURADOS        *      */
        /*"      *                             ATIVOS DA CEF QUE POSSUEM O        *      */
        /*"      *                             SEGURO PREFERENCIAL VIDA.          *      */
        /*"      *                                                                *      */
        /*"      *                             LEITURA  TABELAS..: V0SEGURAVG     *      */
        /*"      *                                                 V0COBERAPOL    *      */
        /*"      *                                                 V0FUNCIOCEF    *      */
        /*"      *                                                 V0SUREG        *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA/PROGRAMADOR....  LUIZ FERNANDO GONCALVES            *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  VP0107B                            *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  FEVEREIRO/93                       *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *  PROGRAMA ALTERADO EM 15/07/94                                 *      */
        /*"      *  MOTIVO - MUDANCA DA MOEDA, DE CRUZEIRO REAL PARA REAL         *      */
        /*"      *  CONTEUDO - BUSCAR A MOEDA USADA PARA IMPORTANCIA SEGU-        *      */
        /*"      *             RADA/PREMIO DA V0HISTSEGVG E V1MOEDA               *      */
        /*"      *  EFETUADO POR -   EDSON LUIZ NUNES GUIMARAES                   *      */
        /*"      ******************************************************************      */
        /*"      *   ALTERACAO: INCLUIDA A EMISSAO DE SOLICITACAO POR SUREG.      *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  NOVEMBRO/94                        *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        public FileBasis _RELPREFV { get; set; } = new FileBasis(new PIC("X", "132", "X(132)"));

        public FileBasis RELPREFV
        {
            get
            {
                _.Move(REG_IMPRESSAO, _RELPREFV); VarBasis.RedefinePassValue(REG_IMPRESSAO, _RELPREFV, REG_IMPRESSAO); return _RELPREFV;
            }
        }
        /*"01   REG-IMPRESSAO              PIC  X(132).*/
        public StringBasis REG_IMPRESSAO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  FSUREG                     PIC S9(04)      COMP.*/
        public IntBasis FSUREG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  FUNIDADE                   PIC S9(04)      COMP.*/
        public IntBasis FUNIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  FCOD-UNIDADE               PIC S9(004)      COMP.*/
        public IntBasis FCOD_UNIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  FNOME-UNIDADE              PIC  X(040).*/
        public StringBasis FNOME_UNIDADE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"01  FMATRICULA                 PIC S9(15)      COMP-3.*/
        public IntBasis FMATRICULA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  FNOME-FUNC                 PIC X(40).*/
        public StringBasis FNOME_FUNC { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"01  SUREG                      PIC X(40).*/
        public StringBasis SUREG { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"01  DATA-SOLICITACAO           PIC X(10).*/
        public StringBasis DATA_SOLICITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  NRCOPIAS                   PIC S9(004)      COMP.*/
        public IntBasis NRCOPIAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  SNUM-CERTIFICADO           PIC S9(015)      COMP-3.*/
        public IntBasis SNUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77  SNUM-ITEM                  PIC S9(009)      COMP.*/
        public IntBasis SNUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  SOCORR-HISTORICO           PIC S9(004)      COMP.*/
        public IntBasis SOCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V1SIST-DTMOVABE            PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  V1SIST-DTCURRENT           PIC  X(010).*/
        public StringBasis V1SIST_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  CIMP-SEGURADA-IX         PIC S9(013)V99   COMP-3.*/
        public DoubleBasis CIMP_SEGURADA_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  CPRM-TARIFARIO-IX        PIC S9(010)V9(5) COMP-3.*/
        public DoubleBasis CPRM_TARIFARIO_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"01  DVLCRUZAD-IMP             PIC S9(06)V9(9) COMP-3.*/
        public DoubleBasis DVLCRUZAD_IMP { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(9)"), 9);
        /*"01  DVLCRUZAD-PRM             PIC S9(06)V9(9) COMP-3.*/
        public DoubleBasis DVLCRUZAD_PRM { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(9)"), 9);
        /*"01  ECOD-MOEDA-IMP             PIC S9(04)       COMP.*/
        public IntBasis ECOD_MOEDA_IMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  ECOD-MOEDA-PRM             PIC S9(04)       COMP.*/
        public IntBasis ECOD_MOEDA_PRM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  XDATA-MOVIMENTO            PIC X(010).*/
        public StringBasis XDATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"  03        TRACO.*/
        public VP0107B_TRACO TRACO { get; set; } = new VP0107B_TRACO();
        public class VP0107B_TRACO : VarBasis
        {
            /*"      05    FILLER              PIC  X(132) VALUE ALL '-'.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
            /*"  03        CABEC01.*/
        }
        public VP0107B_CABEC01 CABEC01 { get; set; } = new VP0107B_CABEC01();
        public class VP0107B_CABEC01 : VarBasis
        {
            /*"      05    FILLER              PIC  X(046) VALUE      'SASSE               '.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "46", "X(046)"), @"SASSE               ");
            /*"      05    FILLER              PIC  X(030) VALUE      'CIA NACIONAL DE SEGUROS GERAIS'.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"CIA NACIONAL DE SEGUROS GERAIS");
            /*"      05    FILLER              PIC  X(040) VALUE SPACES.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"      05    FILLER              PIC  X(008) VALUE 'PAGINA. '.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"PAGINA. ");
            /*"      05    PAGINA-C01          PIC  ZZZZ.ZZ9.*/
            public IntBasis PAGINA_C01 { get; set; } = new IntBasis(new PIC("9", "7", "ZZZZ.ZZ9."));
            /*"  03        CABEC02.*/
        }
        public VP0107B_CABEC02 CABEC02 { get; set; } = new VP0107B_CABEC02();
        public class VP0107B_CABEC02 : VarBasis
        {
            /*"      05    FILLER              PIC  X(007) VALUE 'VP0107B'.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"VP0107B");
            /*"      05    FILLER              PIC  X(033) VALUE SPACES.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "33", "X(033)"), @"");
            /*"      05    FILLER              PIC  X(044) VALUE      'RELACAO DOS  FUNCIONARIOS ATIVOS  DA CEF '.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "44", "X(044)"), @"RELACAO DOS  FUNCIONARIOS ATIVOS  DA CEF ");
            /*"      05    FILLER              PIC  X(030) VALUE SPACES.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
            /*"      05    FILLER              PIC  X(008) VALUE 'DATA. '.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"DATA. ");
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
        public VP0107B_CABEC02A CABEC02A { get; set; } = new VP0107B_CABEC02A();
        public class VP0107B_CABEC02A : VarBasis
        {
            /*"      05    FILLER              PIC  X(041) VALUE SPACES.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "41", "X(041)"), @"");
            /*"      05    FILLER              PIC  X(073) VALUE      'QUE POSSUEM O SEGURO PREFERENCIAL VIDA   '.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "73", "X(073)"), @"QUE POSSUEM O SEGURO PREFERENCIAL VIDA   ");
            /*"      05    FILLER              PIC  X(010) VALUE 'HORA. '.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"HORA. ");
            /*"      05    HORA-C02            PIC  X(008).*/
            public StringBasis HORA_C02 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03        CABEC03.*/
        }
        public VP0107B_CABEC03 CABEC03 { get; set; } = new VP0107B_CABEC03();
        public class VP0107B_CABEC03 : VarBasis
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
        public VP0107B_CABEC03A CABEC03A { get; set; } = new VP0107B_CABEC03A();
        public class VP0107B_CABEC03A : VarBasis
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
        public VP0107B_CABEC04 CABEC04 { get; set; } = new VP0107B_CABEC04();
        public class VP0107B_CABEC04 : VarBasis
        {
            /*"      05 FILLER PIC X(30) VALUE 'MATRICULA  CERTIFICADO  NOME D'*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"MATRICULA  CERTIFICADO  NOME D");
            /*"      05 FILLER PIC X(30) VALUE 'O FUNCIONARIO                 '*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"O FUNCIONARIO                 ");
            /*"      05 FILLER PIC X(30) VALUE '     MORTE NATURAL     MORTE A'*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"     MORTE NATURAL     MORTE A");
            /*"      05 FILLER PIC X(30) VALUE 'CIDENTAL   INV. PERMANENTE   P'*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"CIDENTAL   INV. PERMANENTE   P");
            /*"      05 FILLER PIC X(12) VALUE 'REMIO       '.*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"REMIO       ");
            /*"  03        DETALHE.*/
        }
        public VP0107B_DETALHE DETALHE { get; set; } = new VP0107B_DETALHE();
        public class VP0107B_DETALHE : VarBasis
        {
            /*"      05    MATRICULA-DET       PIC  ZZZZZZZZ9.*/
            public IntBasis MATRICULA_DET { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZZZZ9."));
            /*"      05    FILLER              PIC  X(001) VALUE SPACES.*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"      05    CERTIF-DET          PIC  ZZZZZZZZZZZZ9.*/
            public IntBasis CERTIF_DET { get; set; } = new IntBasis(new PIC("9", "13", "ZZZZZZZZZZZZ9."));
            /*"      05    FILLER              PIC  X(001) VALUE SPACES.*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"      05    NOME-DET            PIC  X(040).*/
            public StringBasis NOME_DET { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"      05    FILLER              PIC  X(001) VALUE SPACES.*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"      05    MORTE-NAT-DET       PIC  ZZ.ZZZ.ZZZ.ZZ9,99.*/
            public DoubleBasis MORTE_NAT_DET { get; set; } = new DoubleBasis(new PIC("9", "11", "ZZ.ZZZ.ZZZ.ZZ9V99."), 2);
            /*"      05    FILLER              PIC  X(001) VALUE SPACES.*/
            public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"      05    MORTE-ACI-DET       PIC  ZZ.ZZZ.ZZZ.ZZ9,99.*/
            public DoubleBasis MORTE_ACI_DET { get; set; } = new DoubleBasis(new PIC("9", "11", "ZZ.ZZZ.ZZZ.ZZ9V99."), 2);
            /*"      05    FILLER              PIC  X(001) VALUE SPACES.*/
            public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"      05    INV-PERM-DET        PIC  ZZ.ZZZ.ZZZ.ZZ9,99.*/
            public DoubleBasis INV_PERM_DET { get; set; } = new DoubleBasis(new PIC("9", "11", "ZZ.ZZZ.ZZZ.ZZ9V99."), 2);
            /*"      05    FILLER              PIC  X(001) VALUE SPACES.*/
            public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"      05    PREMIO-DET          PIC  ZZ.ZZZ.ZZ9,99.*/
            public DoubleBasis PREMIO_DET { get; set; } = new DoubleBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9V99."), 2);
            /*"  03        TOTAL-FILIAL.*/
        }
        public VP0107B_TOTAL_FILIAL TOTAL_FILIAL { get; set; } = new VP0107B_TOTAL_FILIAL();
        public class VP0107B_TOTAL_FILIAL : VarBasis
        {
            /*"      05    FILLER              PIC  X(019) VALUE SPACES.*/
            public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"");
            /*"      05    FILLER              PIC  X(040) VALUE      '................  TOTAL DE PREMIOS   '.*/
            public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"................  TOTAL DE PREMIOS   ");
            /*"      05    FILLER              PIC  X(015) VALUE SPACES.*/
            public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
            /*"      05    DESCONTO-TOT-FL     PIC  ZZZ.ZZZ.ZZZ.ZZ9,99.*/
            public DoubleBasis DESCONTO_TOT_FL { get; set; } = new DoubleBasis(new PIC("9", "12", "ZZZ.ZZZ.ZZZ.ZZ9V99."), 2);
            /*"  03        TOTAL-GERAL.*/
        }
        public VP0107B_TOTAL_GERAL TOTAL_GERAL { get; set; } = new VP0107B_TOTAL_GERAL();
        public class VP0107B_TOTAL_GERAL : VarBasis
        {
            /*"      05    FILLER              PIC  X(019) VALUE SPACES.*/
            public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"");
            /*"      05    FILLER              PIC  X(040) VALUE      '................  TOTAL GERAL        '.*/
            public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"................  TOTAL GERAL        ");
            /*"      05    FILLER              PIC  X(009) VALUE SPACES.*/
            public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
            /*"      05    DESCONTO-GERAL      PIC  Z.ZZZ.ZZZ.ZZZ.ZZZ.ZZ9,99.*/
            public DoubleBasis DESCONTO_GERAL { get; set; } = new DoubleBasis(new PIC("9", "16", "Z.ZZZ.ZZZ.ZZZ.ZZZ.ZZ9V99."), 2);
            /*"  03        WSQLCODE3           PIC S9(009) COMP.*/
        }
        public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"  03        WHORA               PIC  99.99.99.99.*/
        public IntBasis WHORA { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
        /*"  03            WFIM-INCLUSAO       PIC  X(001) VALUE 'N'.*/
        public StringBasis WFIM_INCLUSAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"  03            WFIM-FUNCIOCEF      PIC  X(001) VALUE 'N'.*/
        public StringBasis WFIM_FUNCIOCEF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"  03            WFIM-RELATORIOS     PIC  X(001) VALUE 'N'.*/
        public StringBasis WFIM_RELATORIOS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"  03            WS-VARIAVEIS-ANTERIORES.*/
        public VP0107B_WS_VARIAVEIS_ANTERIORES WS_VARIAVEIS_ANTERIORES { get; set; } = new VP0107B_WS_VARIAVEIS_ANTERIORES();
        public class VP0107B_WS_VARIAVEIS_ANTERIORES : VarBasis
        {
            /*"    05          WSUREG-ANT          PIC S9(004) COMP.*/
            public IntBasis WSUREG_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05          WS-LOTACAO-ANT      PIC S9(004) COMP VALUE ZEROS*/
            public IntBasis WS_LOTACAO_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03         WDATA-CURRENT     PIC  X(010)    VALUE SPACES.*/
        }
        public StringBasis WDATA_CURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"  03         FILLER            REDEFINES      WDATA-CURRENT.*/
        private _REDEF_VP0107B_FILLER_38 _filler_38 { get; set; }
        public _REDEF_VP0107B_FILLER_38 FILLER_38
        {
            get { _filler_38 = new _REDEF_VP0107B_FILLER_38(); _.Move(WDATA_CURRENT, _filler_38); VarBasis.RedefinePassValue(WDATA_CURRENT, _filler_38, WDATA_CURRENT); _filler_38.ValueChanged += () => { _.Move(_filler_38, WDATA_CURRENT); }; return _filler_38; }
            set { VarBasis.RedefinePassValue(value, _filler_38, WDATA_CURRENT); }
        }  //Redefines
        public class _REDEF_VP0107B_FILLER_38 : VarBasis
        {
            /*"    05       WDATA-CURR-ANO    PIC  9(004).*/
            public IntBasis WDATA_CURR_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05       FILLER            PIC  X(001).*/
            public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05       WDATA-CURR-MES    PIC  9(002).*/
            public IntBasis WDATA_CURR_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05       FILLER            PIC  X(001).*/
            public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05       WDATA-CURR-DIA    PIC  9(002).*/
            public IntBasis WDATA_CURR_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  03         WS-DATA-HOJE      PIC  9(008)    VALUE ZEROS.*/

            public _REDEF_VP0107B_FILLER_38()
            {
                WDATA_CURR_ANO.ValueChanged += OnValueChanged;
                FILLER_39.ValueChanged += OnValueChanged;
                WDATA_CURR_MES.ValueChanged += OnValueChanged;
                FILLER_40.ValueChanged += OnValueChanged;
                WDATA_CURR_DIA.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis WS_DATA_HOJE { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"  03         WS-DATA-HOJE-RD   REDEFINES      WS-DATA-HOJE.*/
        private _REDEF_VP0107B_WS_DATA_HOJE_RD _ws_data_hoje_rd { get; set; }
        public _REDEF_VP0107B_WS_DATA_HOJE_RD WS_DATA_HOJE_RD
        {
            get { _ws_data_hoje_rd = new _REDEF_VP0107B_WS_DATA_HOJE_RD(); _.Move(WS_DATA_HOJE, _ws_data_hoje_rd); VarBasis.RedefinePassValue(WS_DATA_HOJE, _ws_data_hoje_rd, WS_DATA_HOJE); _ws_data_hoje_rd.ValueChanged += () => { _.Move(_ws_data_hoje_rd, WS_DATA_HOJE); }; return _ws_data_hoje_rd; }
            set { VarBasis.RedefinePassValue(value, _ws_data_hoje_rd, WS_DATA_HOJE); }
        }  //Redefines
        public class _REDEF_VP0107B_WS_DATA_HOJE_RD : VarBasis
        {
            /*"    10       WS-AA-HOJE        PIC  9(004).*/
            public IntBasis WS_AA_HOJE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    10       WS-MM-HOJE        PIC  9(002).*/
            public IntBasis WS_MM_HOJE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    10       WS-DD-HOJE        PIC  9(002).*/
            public IntBasis WS_DD_HOJE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  03         WS-HORA-ATUAL.*/

            public _REDEF_VP0107B_WS_DATA_HOJE_RD()
            {
                WS_AA_HOJE.ValueChanged += OnValueChanged;
                WS_MM_HOJE.ValueChanged += OnValueChanged;
                WS_DD_HOJE.ValueChanged += OnValueChanged;
            }

        }
        public VP0107B_WS_HORA_ATUAL WS_HORA_ATUAL { get; set; } = new VP0107B_WS_HORA_ATUAL();
        public class VP0107B_WS_HORA_ATUAL : VarBasis
        {
            /*"    10       WS-HH-ATUAL       PIC  9(002).*/
            public IntBasis WS_HH_ATUAL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    10       WS-MM-ATUAL       PIC  9(002).*/
            public IntBasis WS_MM_ATUAL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    10       WS-SS-ATUAL       PIC  9(002).*/
            public IntBasis WS_SS_ATUAL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  03         WS-HORA-CABEC.*/
        }
        public VP0107B_WS_HORA_CABEC WS_HORA_CABEC { get; set; } = new VP0107B_WS_HORA_CABEC();
        public class VP0107B_WS_HORA_CABEC : VarBasis
        {
            /*"    10       WS-HH-CABEC       PIC  9(002).*/
            public IntBasis WS_HH_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    10       FILLER            PIC  X(001) VALUE ':'.*/
            public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
            /*"    10       WS-MM-CABEC       PIC  9(002).*/
            public IntBasis WS_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    10       FILLER            PIC  X(001) VALUE ':'.*/
            public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
            /*"    10       WS-SS-CABEC       PIC  9(002).*/
            public IntBasis WS_SS_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  03        WS-MORTE-ACI             PIC S9(013)V99                                        VALUE +0 COMP-3.*/
        }
        public DoubleBasis WS_MORTE_ACI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"  03        WTOT-PREMIO-L            PIC S9(013)V99                                        VALUE +0 COMP-3.*/
        public DoubleBasis WTOT_PREMIO_L { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"  03        WTOT-PREMIO-S            PIC S9(013)V99                                        VALUE +0 COMP-3.*/
        public DoubleBasis WTOT_PREMIO_S { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"  03        WTOT-PREMIO-G            PIC S9(016)V99                                        VALUE +0 COMP-3.*/
        public DoubleBasis WTOT_PREMIO_G { get; set; } = new DoubleBasis(new PIC("S9", "16", "S9(016)V99"), 2);
        /*"  03        W-LIDOS                  PIC  9(007) VALUE 0.*/
        public IntBasis W_LIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"  03        W-CONT-LINHA             PIC  9(007) VALUE 0.*/
        public IntBasis W_CONT_LINHA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"  03        W-PAGINA                 PIC  9(007) VALUE 0.*/
        public IntBasis W_PAGINA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"    03  WS-COUNT         PIC 9(09) VALUE 0.*/
        public IntBasis WS_COUNT { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"    03  ON-INTERVAL      PIC 9(05) VALUE 10000.*/
        public IntBasis ON_INTERVAL { get; set; } = new IntBasis(new PIC("9", "5", "9(05)"), 10000);
        /*"    03  ON-COUNTER       PIC 9(04) VALUE 0.*/
        public IntBasis ON_COUNTER { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
        /*"    03  WS-TIME          PIC 99.99.99.99.*/
        public IntBasis WS_TIME { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
        /*"  03        WABEND.*/
        public VP0107B_WABEND WABEND { get; set; } = new VP0107B_WABEND();
        public class VP0107B_WABEND : VarBasis
        {
            /*"    05      FILLER              PIC  X(010) VALUE           ' VP0107B'.*/
            public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VP0107B");
            /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
            public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
            /*"    05      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
            /*"    05      FILLER              PIC  X(017) VALUE           ' *** PARAGRAFO = '.*/
            public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @" *** PARAGRAFO = ");
            /*"    05      PARAGRAFO           PIC  X(030) VALUE SPACES.*/
            public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
            /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
            public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
            /*"    05      WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE1= '.*/
            public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE1= ");
            /*"    05      WSQLCODE1           PIC  ZZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE1 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE2= '.*/
            public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE2= ");
            /*"    05      WSQLCODE2           PIC  ZZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE2 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
        }


        public VP0107B_TRELAT TRELAT { get; set; } = new VP0107B_TRELAT();
        public VP0107B_TFUNCIOCEF TFUNCIOCEF { get; set; } = new VP0107B_TFUNCIOCEF();
        public VP0107B_TFUNCIOSUR TFUNCIOSUR { get; set; } = new VP0107B_TFUNCIOSUR();
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
            /*" -277- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -279- EXEC SQL WHENEVER SQLERROR GO TO 999-999-ROT-ERRO END-EXEC. */

            /*" -281- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -283- PERFORM 010-000-INICIO-PROCESSO. */

            M_010_000_INICIO_PROCESSO(true);

        }

        [StopWatch]
        /*" M-010-000-INICIO-PROCESSO */
        private void M_010_000_INICIO_PROCESSO(bool isPerform = false)
        {
            /*" -289- MOVE '010-000-INICIO-PROCESSO  ' TO PARAGRAFO. */
            _.Move("010-000-INICIO-PROCESSO  ", WABEND.PARAGRAFO);

            /*" -291- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", WABEND.WNR_EXEC_SQL);

            /*" -293- PERFORM 012-000-SELECT-V1SISTEMA */

            M_012_000_SELECT_V1SISTEMA_SECTION();

            /*" -294- MOVE V1SIST-DTCURRENT TO WDATA-CURRENT. */
            _.Move(V1SIST_DTCURRENT, WDATA_CURRENT);

            /*" -295- MOVE WDATA-CURR-DIA TO WS-DD-HOJE. */
            _.Move(FILLER_38.WDATA_CURR_DIA, WS_DATA_HOJE_RD.WS_DD_HOJE);

            /*" -296- MOVE WDATA-CURR-MES TO WS-MM-HOJE. */
            _.Move(FILLER_38.WDATA_CURR_MES, WS_DATA_HOJE_RD.WS_MM_HOJE);

            /*" -298- MOVE WDATA-CURR-ANO TO WS-AA-HOJE. */
            _.Move(FILLER_38.WDATA_CURR_ANO, WS_DATA_HOJE_RD.WS_AA_HOJE);

            /*" -300- ACCEPT WS-HORA-ATUAL FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WS_HORA_ATUAL);

            /*" -301- MOVE WS-HH-ATUAL TO WS-HH-CABEC. */
            _.Move(WS_HORA_ATUAL.WS_HH_ATUAL, WS_HORA_CABEC.WS_HH_CABEC);

            /*" -302- MOVE WS-MM-ATUAL TO WS-MM-CABEC. */
            _.Move(WS_HORA_ATUAL.WS_MM_ATUAL, WS_HORA_CABEC.WS_MM_CABEC);

            /*" -304- MOVE WS-SS-ATUAL TO WS-SS-CABEC. */
            _.Move(WS_HORA_ATUAL.WS_SS_ATUAL, WS_HORA_CABEC.WS_SS_CABEC);

            /*" -305- MOVE WS-HORA-CABEC TO HORA-C02. */
            _.Move(WS_HORA_CABEC, CABEC02A.HORA_C02);

            /*" -306- OPEN OUTPUT RELPREFV. */
            RELPREFV.Open(REG_IMPRESSAO);

            /*" -312- ACCEPT WHORA FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WHORA);

            /*" -319- PERFORM M_010_000_INICIO_PROCESSO_DB_DECLARE_1 */

            M_010_000_INICIO_PROCESSO_DB_DECLARE_1();

            /*" -321- PERFORM M_010_000_INICIO_PROCESSO_DB_OPEN_1 */

            M_010_000_INICIO_PROCESSO_DB_OPEN_1();

            /*" -325- PERFORM 102-000-FETCH-V0RELATORIOS. */

            M_102_000_FETCH_V0RELATORIOS_SECTION();

            /*" -326- IF WFIM-RELATORIOS EQUAL 'S' */

            if (WFIM_RELATORIOS == "S")
            {

                /*" -327- DISPLAY '*** VP0107B - NAO HOUVE SOLICITACAO ***' */
                _.Display($"*** VP0107B - NAO HOUVE SOLICITACAO ***");

                /*" -329- GO TO 900-000-FINALIZA. */

                M_900_000_FINALIZA_SECTION(); //GOTO
                return;
            }


            /*" -332- PERFORM 015-000-PROCESSA UNTIL WFIM-RELATORIOS EQUAL 'S' . */

            while (!(WFIM_RELATORIOS == "S"))
            {

                M_015_000_PROCESSA_SECTION();
            }

            /*" -332- PERFORM 900-000-FINALIZA. */

            M_900_000_FINALIZA_SECTION();

        }

        [StopWatch]
        /*" M-010-000-INICIO-PROCESSO-DB-DECLARE-1 */
        public void M_010_000_INICIO_PROCESSO_DB_DECLARE_1()
        {
            /*" -319- EXEC SQL DECLARE TRELAT CURSOR FOR SELECT DATA_SOLICITACAO, NRCOPIAS FROM SEGUROS.V1RELATORIOS WHERE CODRELAT = 'VP0107B' AND SITUACAO = '0' END-EXEC. */
            TRELAT = new VP0107B_TRELAT(false);
            string GetQuery_TRELAT()
            {
                var query = @$"SELECT DATA_SOLICITACAO
							, 
							NRCOPIAS 
							FROM SEGUROS.V1RELATORIOS 
							WHERE CODRELAT = 'VP0107B' AND 
							SITUACAO = '0'";

                return query;
            }
            TRELAT.GetQueryEvent += GetQuery_TRELAT;

        }

        [StopWatch]
        /*" M-010-000-INICIO-PROCESSO-DB-OPEN-1 */
        public void M_010_000_INICIO_PROCESSO_DB_OPEN_1()
        {
            /*" -321- EXEC SQL OPEN TRELAT END-EXEC. */

            TRELAT.Open();

        }

        [StopWatch]
        /*" M-090-000-CURSOR-V0FUNCIOCEF-DB-DECLARE-1 */
        public void M_090_000_CURSOR_V0FUNCIOCEF_DB_DECLARE_1()
        {
            /*" -509- EXEC SQL DECLARE TFUNCIOCEF CURSOR FOR SELECT A.COD_SUREG, A.COD_UNIDADE, A.NOME_UNIDADE, A.NUM_MATRICULA, A.NOME_FUNCIONARIO, B.NUM_CERTIFICADO, B.NUM_ITEM, B.OCORR_HISTORICO FROM SEGUROS.V0FUNCIOCEF A, SEGUROS.V0SEGURAVG B WHERE A.TIPO_VINCULO = 'EMPREGADO CEF' AND A.NUM_MATRICULA = B.NUM_MATRICULA AND B.NUM_APOLICE = 93010000890 AND B.COD_SUBGRUPO = 1 AND B.TIPO_SEGURADO = '1' AND B.SIT_REGISTRO <> '2' ORDER BY A.COD_SUREG, A.COD_UNIDADE, A.NOME_FUNCIONARIO END-EXEC. */
            TFUNCIOCEF = new VP0107B_TFUNCIOCEF(false);
            string GetQuery_TFUNCIOCEF()
            {
                var query = @$"SELECT 
							A.COD_SUREG
							, 
							A.COD_UNIDADE
							, 
							A.NOME_UNIDADE
							, 
							A.NUM_MATRICULA
							, 
							A.NOME_FUNCIONARIO
							, 
							B.NUM_CERTIFICADO
							, 
							B.NUM_ITEM
							, 
							B.OCORR_HISTORICO 
							FROM SEGUROS.V0FUNCIOCEF A
							, 
							SEGUROS.V0SEGURAVG B 
							WHERE 
							A.TIPO_VINCULO = 'EMPREGADO CEF' 
							AND A.NUM_MATRICULA = B.NUM_MATRICULA 
							AND B.NUM_APOLICE = 93010000890 
							AND B.COD_SUBGRUPO = 1 
							AND B.TIPO_SEGURADO = '1' 
							AND B.SIT_REGISTRO <> '2' 
							ORDER BY 
							A.COD_SUREG
							, 
							A.COD_UNIDADE
							, 
							A.NOME_FUNCIONARIO";

                return query;
            }
            TFUNCIOCEF.GetQueryEvent += GetQuery_TFUNCIOCEF;

        }

        [StopWatch]
        /*" M-012-000-SELECT-V1SISTEMA-SECTION */
        private void M_012_000_SELECT_V1SISTEMA_SECTION()
        {
            /*" -339- MOVE '012-000-PROCESSA       ' TO PARAGRAFO. */
            _.Move("012-000-PROCESSA       ", WABEND.PARAGRAFO);

            /*" -341- MOVE '012' TO WNR-EXEC-SQL. */
            _.Move("012", WABEND.WNR_EXEC_SQL);

            /*" -346- PERFORM M_012_000_SELECT_V1SISTEMA_DB_SELECT_1 */

            M_012_000_SELECT_V1SISTEMA_DB_SELECT_1();

        }

        [StopWatch]
        /*" M-012-000-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void M_012_000_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -346- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :V1SIST-DTMOVABE, :V1SIST-DTCURRENT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VP' END-EXEC. */

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
            /*" -355- MOVE '015-000-PROCESSA         ' TO PARAGRAFO. */
            _.Move("015-000-PROCESSA         ", WABEND.PARAGRAFO);

            /*" -357- MOVE '015' TO WNR-EXEC-SQL. */
            _.Move("015", WABEND.WNR_EXEC_SQL);

            /*" -360- DISPLAY 'INICIO DO DECLARE NA V0FUNCIOCEF' WHORA UPON CONSOLE. */
            _.Display($"INICIO DO DECLARE NA V0FUNCIOCEF{WHORA}");

            /*" -361- IF NRCOPIAS EQUAL 0 */

            if (NRCOPIAS == 0)
            {

                /*" -362- PERFORM 090-000-CURSOR-V0FUNCIOCEF */

                M_090_000_CURSOR_V0FUNCIOCEF_SECTION();

                /*" -363- ELSE */
            }
            else
            {


                /*" -365- PERFORM 091-000-CURSOR-V0FUNCIOSUR. */

                M_091_000_CURSOR_V0FUNCIOSUR_SECTION();
            }


            /*" -366- ACCEPT WHORA FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WHORA);

            /*" -369- DISPLAY 'FIM DO DECLARE NA V0FUNCIOCEF' WHORA UPON CONSOLE. */
            _.Display($"FIM DO DECLARE NA V0FUNCIOCEF{WHORA}");

            /*" -370- IF NRCOPIAS EQUAL 0 */

            if (NRCOPIAS == 0)
            {

                /*" -371- PERFORM 100-000-FETCH-V0FUNCIOCEF */

                M_100_000_FETCH_V0FUNCIOCEF_SECTION();

                /*" -372- ELSE */
            }
            else
            {


                /*" -374- PERFORM 101-000-FETCH-V0FUNCIOSUR. */

                M_101_000_FETCH_V0FUNCIOSUR_SECTION();
            }


            /*" -376- IF WFIM-FUNCIOCEF EQUAL 'N' NEXT SENTENCE */

            if (WFIM_FUNCIOCEF == "N")
            {

                /*" -377- ELSE */
            }
            else
            {


                /*" -379- DISPLAY '------------------------------------------------- '---------------------------------------' */
                _.Display($"------------------------------------------------- ---------------------------------------");

                /*" -381- DISPLAY ' VP0107B - NAO HOUVE SELECAO DE SEGURADO DO SEGU' 'RO PREFERENCIAL VIDA' */
                _.Display($" VP0107B - NAO HOUVE SELECAO DE SEGURADO DO SEGURO PREFERENCIAL VIDA");

                /*" -383- DISPLAY '------------------------------------------------- '---------------------------------------' */
                _.Display($"------------------------------------------------- ---------------------------------------");

                /*" -385- DISPLAY ' ' . */
                _.Display($" ");
            }


            /*" -388- PERFORM 020-000-PROCESSA UNTIL WFIM-FUNCIOCEF EQUAL 'S' . */

            while (!(WFIM_FUNCIOCEF == "S"))
            {

                M_020_000_PROCESSA_SECTION();
            }

            /*" -394- PERFORM M_015_000_PROCESSA_DB_UPDATE_1 */

            M_015_000_PROCESSA_DB_UPDATE_1();

            /*" -398- PERFORM 800-000-TOTAL-GERAL. */

            M_800_000_TOTAL_GERAL_SECTION();

            /*" -399- MOVE 'N' TO WFIM-FUNCIOCEF. */
            _.Move("N", WFIM_FUNCIOCEF);

            /*" -405- MOVE ZEROS TO WTOT-PREMIO-L WTOT-PREMIO-S WTOT-PREMIO-G W-PAGINA W-CONT-LINHA. */
            _.Move(0, WTOT_PREMIO_L, WTOT_PREMIO_S, WTOT_PREMIO_G, W_PAGINA, W_CONT_LINHA);

            /*" -405- PERFORM 102-000-FETCH-V0RELATORIOS. */

            M_102_000_FETCH_V0RELATORIOS_SECTION();

        }

        [StopWatch]
        /*" M-015-000-PROCESSA-DB-UPDATE-1 */
        public void M_015_000_PROCESSA_DB_UPDATE_1()
        {
            /*" -394- EXEC SQL UPDATE SEGUROS.V1RELATORIOS SET SITUACAO = '1' WHERE CODRELAT = 'VP0107B' AND SITUACAO = '0' AND NRCOPIAS = :NRCOPIAS END-EXEC. */

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
            /*" -414- MOVE '020-000-PROCESSA         ' TO PARAGRAFO. */
            _.Move("020-000-PROCESSA         ", WABEND.PARAGRAFO);

            /*" -416- MOVE '020' TO WNR-EXEC-SQL. */
            _.Move("020", WABEND.WNR_EXEC_SQL);

            /*" -418- MOVE FSUREG TO WSUREG-ANT */
            _.Move(FSUREG, WS_VARIAVEIS_ANTERIORES.WSUREG_ANT);

            /*" -420- PERFORM 150-000-SELECT-V0SUREG. */

            M_150_000_SELECT_V0SUREG_SECTION();

            /*" -422- MOVE ZEROS TO WTOT-PREMIO-S. */
            _.Move(0, WTOT_PREMIO_S);

            /*" -426- PERFORM 030-000-TRATA-SUREG UNTIL FSUREG NOT = WSUREG-ANT OR WFIM-FUNCIOCEF EQUAL 'S' . */

            while (!(FSUREG != WS_VARIAVEIS_ANTERIORES.WSUREG_ANT || WFIM_FUNCIOCEF == "S"))
            {

                M_030_000_TRATA_SUREG_SECTION();
            }

            /*" -426- PERFORM 270-000-TOTAL-SUREG. */

            M_270_000_TOTAL_SUREG_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_020_999_EXIT*/

        [StopWatch]
        /*" M-030-000-TRATA-SUREG-SECTION */
        private void M_030_000_TRATA_SUREG_SECTION()
        {
            /*" -435- MOVE '030-000-TRATA-SUREG      ' TO PARAGRAFO. */
            _.Move("030-000-TRATA-SUREG      ", WABEND.PARAGRAFO);

            /*" -437- MOVE '030' TO WNR-EXEC-SQL. */
            _.Move("030", WABEND.WNR_EXEC_SQL);

            /*" -438- MOVE FCOD-UNIDADE TO WS-LOTACAO-ANT */
            _.Move(FCOD_UNIDADE, WS_VARIAVEIS_ANTERIORES.WS_LOTACAO_ANT);

            /*" -439- MOVE FCOD-UNIDADE TO CODLOTACAO-C03. */
            _.Move(FCOD_UNIDADE, CABEC03A.CODLOTACAO_C03);

            /*" -441- MOVE FNOME-UNIDADE TO NOMLOTACAO-C03. */
            _.Move(FNOME_UNIDADE, CABEC03A.NOMLOTACAO_C03);

            /*" -443- PERFORM 265-000-CABECALHO. */

            M_265_000_CABECALHO_SECTION();

            /*" -445- MOVE ZEROS TO WTOT-PREMIO-L. */
            _.Move(0, WTOT_PREMIO_L);

            /*" -449- PERFORM 040-000-TRATA-LOTACAO UNTIL FCOD-UNIDADE NOT = WS-LOTACAO-ANT OR WFIM-FUNCIOCEF EQUAL 'S' . */

            while (!(FCOD_UNIDADE != WS_VARIAVEIS_ANTERIORES.WS_LOTACAO_ANT || WFIM_FUNCIOCEF == "S"))
            {

                M_040_000_TRATA_LOTACAO_SECTION();
            }

            /*" -449- PERFORM 280-000-TOTAL-LOTACAO. */

            M_280_000_TOTAL_LOTACAO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_030_999_EXIT*/

        [StopWatch]
        /*" M-040-000-TRATA-LOTACAO-SECTION */
        private void M_040_000_TRATA_LOTACAO_SECTION()
        {
            /*" -458- MOVE '040-000-TRATA-LOTACAO    ' TO PARAGRAFO. */
            _.Move("040-000-TRATA-LOTACAO    ", WABEND.PARAGRAFO);

            /*" -460- MOVE '040' TO WNR-EXEC-SQL. */
            _.Move("040", WABEND.WNR_EXEC_SQL);

            /*" -461- ADD 1 TO W-LIDOS. */
            W_LIDOS.Value = W_LIDOS + 1;

            /*" -464- PERFORM 8888-DISPLAY-TOTAIS THRU 8888-EXIT. */

            M_8888_DISPLAY_TOTAIS_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8888_EXIT*/


            /*" -466- PERFORM 230-000-SELECT-V0COBERAPOL. */

            M_230_000_SELECT_V0COBERAPOL_SECTION();

            /*" -468- PERFORM 255-000-MONTA-DETALHE. */

            M_255_000_MONTA_DETALHE_SECTION();

            /*" -470- PERFORM 260-000-IMPRIME-RELACAO. */

            M_260_000_IMPRIME_RELACAO_SECTION();

            /*" -471- IF NRCOPIAS EQUAL 0 */

            if (NRCOPIAS == 0)
            {

                /*" -472- PERFORM 100-000-FETCH-V0FUNCIOCEF */

                M_100_000_FETCH_V0FUNCIOCEF_SECTION();

                /*" -473- ELSE */
            }
            else
            {


                /*" -473- PERFORM 101-000-FETCH-V0FUNCIOSUR. */

                M_101_000_FETCH_V0FUNCIOSUR_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_040_999_EXIT*/

        [StopWatch]
        /*" M-090-000-CURSOR-V0FUNCIOCEF-SECTION */
        private void M_090_000_CURSOR_V0FUNCIOCEF_SECTION()
        {
            /*" -482- MOVE '090-000-CURSOR-V0FUNCIOCEF' TO PARAGRAFO. */
            _.Move("090-000-CURSOR-V0FUNCIOCEF", WABEND.PARAGRAFO);

            /*" -483- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", WABEND.WNR_EXEC_SQL);

            /*" -485- MOVE 'N' TO WFIM-FUNCIOCEF. */
            _.Move("N", WFIM_FUNCIOCEF);

            /*" -509- PERFORM M_090_000_CURSOR_V0FUNCIOCEF_DB_DECLARE_1 */

            M_090_000_CURSOR_V0FUNCIOCEF_DB_DECLARE_1();

            /*" -511- PERFORM M_090_000_CURSOR_V0FUNCIOCEF_DB_OPEN_1 */

            M_090_000_CURSOR_V0FUNCIOCEF_DB_OPEN_1();

        }

        [StopWatch]
        /*" M-090-000-CURSOR-V0FUNCIOCEF-DB-OPEN-1 */
        public void M_090_000_CURSOR_V0FUNCIOCEF_DB_OPEN_1()
        {
            /*" -511- EXEC SQL OPEN TFUNCIOCEF END-EXEC. */

            TFUNCIOCEF.Open();

        }

        [StopWatch]
        /*" M-091-000-CURSOR-V0FUNCIOSUR-DB-DECLARE-1 */
        public void M_091_000_CURSOR_V0FUNCIOSUR_DB_DECLARE_1()
        {
            /*" -549- EXEC SQL DECLARE TFUNCIOSUR CURSOR FOR SELECT A.COD_SUREG, A.COD_UNIDADE, A.NOME_UNIDADE, A.NUM_MATRICULA, A.NOME_FUNCIONARIO, B.NUM_CERTIFICADO, B.NUM_ITEM, B.OCORR_HISTORICO FROM SEGUROS.V0FUNCIOCEF A, SEGUROS.V0SEGURAVG B WHERE A.TIPO_VINCULO = 'EMPREGADO CEF' AND A.NUM_MATRICULA = B.NUM_MATRICULA AND B.NUM_APOLICE = 93010000890 AND B.COD_SUBGRUPO = 1 AND B.TIPO_SEGURADO = '1' AND B.SIT_REGISTRO <> '2' AND A.COD_SUREG = :NRCOPIAS ORDER BY A.COD_SUREG, A.COD_UNIDADE, A.NOME_FUNCIONARIO END-EXEC. */
            TFUNCIOSUR = new VP0107B_TFUNCIOSUR(true);
            string GetQuery_TFUNCIOSUR()
            {
                var query = @$"SELECT 
							A.COD_SUREG
							, 
							A.COD_UNIDADE
							, 
							A.NOME_UNIDADE
							, 
							A.NUM_MATRICULA
							, 
							A.NOME_FUNCIONARIO
							, 
							B.NUM_CERTIFICADO
							, 
							B.NUM_ITEM
							, 
							B.OCORR_HISTORICO 
							FROM SEGUROS.V0FUNCIOCEF A
							, 
							SEGUROS.V0SEGURAVG B 
							WHERE 
							A.TIPO_VINCULO = 'EMPREGADO CEF' 
							AND A.NUM_MATRICULA = B.NUM_MATRICULA 
							AND B.NUM_APOLICE = 93010000890 
							AND B.COD_SUBGRUPO = 1 
							AND B.TIPO_SEGURADO = '1' 
							AND B.SIT_REGISTRO <> '2' 
							AND A.COD_SUREG = '{NRCOPIAS}' 
							ORDER BY 
							A.COD_SUREG
							, 
							A.COD_UNIDADE
							, 
							A.NOME_FUNCIONARIO";

                return query;
            }
            TFUNCIOSUR.GetQueryEvent += GetQuery_TFUNCIOSUR;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_090_999_EXIT*/

        [StopWatch]
        /*" M-091-000-CURSOR-V0FUNCIOSUR-SECTION */
        private void M_091_000_CURSOR_V0FUNCIOSUR_SECTION()
        {
            /*" -521- MOVE '091-000-CURSOR-V0FUNCIOSUR' TO PARAGRAFO. */
            _.Move("091-000-CURSOR-V0FUNCIOSUR", WABEND.PARAGRAFO);

            /*" -522- MOVE '091' TO WNR-EXEC-SQL. */
            _.Move("091", WABEND.WNR_EXEC_SQL);

            /*" -524- MOVE 'N' TO WFIM-FUNCIOCEF. */
            _.Move("N", WFIM_FUNCIOCEF);

            /*" -549- PERFORM M_091_000_CURSOR_V0FUNCIOSUR_DB_DECLARE_1 */

            M_091_000_CURSOR_V0FUNCIOSUR_DB_DECLARE_1();

            /*" -551- PERFORM M_091_000_CURSOR_V0FUNCIOSUR_DB_OPEN_1 */

            M_091_000_CURSOR_V0FUNCIOSUR_DB_OPEN_1();

        }

        [StopWatch]
        /*" M-091-000-CURSOR-V0FUNCIOSUR-DB-OPEN-1 */
        public void M_091_000_CURSOR_V0FUNCIOSUR_DB_OPEN_1()
        {
            /*" -551- EXEC SQL OPEN TFUNCIOSUR END-EXEC. */

            TFUNCIOSUR.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_091_999_EXIT*/

        [StopWatch]
        /*" M-100-000-FETCH-V0FUNCIOCEF-SECTION */
        private void M_100_000_FETCH_V0FUNCIOCEF_SECTION()
        {
            /*" -560- MOVE '100-000-FETCH-V0FUNCIOCEF' TO PARAGRAFO. */
            _.Move("100-000-FETCH-V0FUNCIOCEF", WABEND.PARAGRAFO);

            /*" -562- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", WABEND.WNR_EXEC_SQL);

            /*" -572- PERFORM M_100_000_FETCH_V0FUNCIOCEF_DB_FETCH_1 */

            M_100_000_FETCH_V0FUNCIOCEF_DB_FETCH_1();

            /*" -575- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -576- MOVE 'S' TO WFIM-FUNCIOCEF */
                _.Move("S", WFIM_FUNCIOCEF);

                /*" -576- PERFORM M_100_000_FETCH_V0FUNCIOCEF_DB_CLOSE_1 */

                M_100_000_FETCH_V0FUNCIOCEF_DB_CLOSE_1();

                /*" -577- GO TO 100-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_999_EXIT*/ //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-100-000-FETCH-V0FUNCIOCEF-DB-FETCH-1 */
        public void M_100_000_FETCH_V0FUNCIOCEF_DB_FETCH_1()
        {
            /*" -572- EXEC SQL FETCH TFUNCIOCEF INTO :FSUREG, :FCOD-UNIDADE, :FNOME-UNIDADE, :FMATRICULA, :FNOME-FUNC, :SNUM-CERTIFICADO, :SNUM-ITEM, :SOCORR-HISTORICO END-EXEC. */

            if (TFUNCIOCEF.Fetch())
            {
                _.Move(TFUNCIOCEF.FSUREG, FSUREG);
                _.Move(TFUNCIOCEF.FCOD_UNIDADE, FCOD_UNIDADE);
                _.Move(TFUNCIOCEF.FNOME_UNIDADE, FNOME_UNIDADE);
                _.Move(TFUNCIOCEF.FMATRICULA, FMATRICULA);
                _.Move(TFUNCIOCEF.FNOME_FUNC, FNOME_FUNC);
                _.Move(TFUNCIOCEF.SNUM_CERTIFICADO, SNUM_CERTIFICADO);
                _.Move(TFUNCIOCEF.SNUM_ITEM, SNUM_ITEM);
                _.Move(TFUNCIOCEF.SOCORR_HISTORICO, SOCORR_HISTORICO);
            }

        }

        [StopWatch]
        /*" M-100-000-FETCH-V0FUNCIOCEF-DB-CLOSE-1 */
        public void M_100_000_FETCH_V0FUNCIOCEF_DB_CLOSE_1()
        {
            /*" -576- EXEC SQL CLOSE TFUNCIOCEF END-EXEC. */

            TFUNCIOCEF.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_999_EXIT*/

        [StopWatch]
        /*" M-101-000-FETCH-V0FUNCIOSUR-SECTION */
        private void M_101_000_FETCH_V0FUNCIOSUR_SECTION()
        {
            /*" -587- MOVE '101-000-FETCH-V0FUNCIOSUR' TO PARAGRAFO. */
            _.Move("101-000-FETCH-V0FUNCIOSUR", WABEND.PARAGRAFO);

            /*" -589- MOVE '101' TO WNR-EXEC-SQL. */
            _.Move("101", WABEND.WNR_EXEC_SQL);

            /*" -599- PERFORM M_101_000_FETCH_V0FUNCIOSUR_DB_FETCH_1 */

            M_101_000_FETCH_V0FUNCIOSUR_DB_FETCH_1();

            /*" -602- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -603- MOVE 'S' TO WFIM-FUNCIOCEF */
                _.Move("S", WFIM_FUNCIOCEF);

                /*" -603- PERFORM M_101_000_FETCH_V0FUNCIOSUR_DB_CLOSE_1 */

                M_101_000_FETCH_V0FUNCIOSUR_DB_CLOSE_1();

                /*" -604- GO TO 101-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_101_999_EXIT*/ //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-101-000-FETCH-V0FUNCIOSUR-DB-FETCH-1 */
        public void M_101_000_FETCH_V0FUNCIOSUR_DB_FETCH_1()
        {
            /*" -599- EXEC SQL FETCH TFUNCIOSUR INTO :FSUREG, :FCOD-UNIDADE, :FNOME-UNIDADE, :FMATRICULA, :FNOME-FUNC, :SNUM-CERTIFICADO, :SNUM-ITEM, :SOCORR-HISTORICO END-EXEC. */

            if (TFUNCIOSUR.Fetch())
            {
                _.Move(TFUNCIOSUR.FSUREG, FSUREG);
                _.Move(TFUNCIOSUR.FCOD_UNIDADE, FCOD_UNIDADE);
                _.Move(TFUNCIOSUR.FNOME_UNIDADE, FNOME_UNIDADE);
                _.Move(TFUNCIOSUR.FMATRICULA, FMATRICULA);
                _.Move(TFUNCIOSUR.FNOME_FUNC, FNOME_FUNC);
                _.Move(TFUNCIOSUR.SNUM_CERTIFICADO, SNUM_CERTIFICADO);
                _.Move(TFUNCIOSUR.SNUM_ITEM, SNUM_ITEM);
                _.Move(TFUNCIOSUR.SOCORR_HISTORICO, SOCORR_HISTORICO);
            }

        }

        [StopWatch]
        /*" M-101-000-FETCH-V0FUNCIOSUR-DB-CLOSE-1 */
        public void M_101_000_FETCH_V0FUNCIOSUR_DB_CLOSE_1()
        {
            /*" -603- EXEC SQL CLOSE TFUNCIOSUR END-EXEC. */

            TFUNCIOSUR.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_101_999_EXIT*/

        [StopWatch]
        /*" M-102-000-FETCH-V0RELATORIOS-SECTION */
        private void M_102_000_FETCH_V0RELATORIOS_SECTION()
        {
            /*" -614- MOVE '102-000-FETCH-V0RELATORIO' TO PARAGRAFO. */
            _.Move("102-000-FETCH-V0RELATORIO", WABEND.PARAGRAFO);

            /*" -616- MOVE '102' TO WNR-EXEC-SQL. */
            _.Move("102", WABEND.WNR_EXEC_SQL);

            /*" -620- PERFORM M_102_000_FETCH_V0RELATORIOS_DB_FETCH_1 */

            M_102_000_FETCH_V0RELATORIOS_DB_FETCH_1();

            /*" -623- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -624- MOVE 'S' TO WFIM-RELATORIOS */
                _.Move("S", WFIM_RELATORIOS);

                /*" -624- PERFORM M_102_000_FETCH_V0RELATORIOS_DB_CLOSE_1 */

                M_102_000_FETCH_V0RELATORIOS_DB_CLOSE_1();

                /*" -625- GO TO 102-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_102_999_EXIT*/ //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-102-000-FETCH-V0RELATORIOS-DB-FETCH-1 */
        public void M_102_000_FETCH_V0RELATORIOS_DB_FETCH_1()
        {
            /*" -620- EXEC SQL FETCH TRELAT INTO :DATA-SOLICITACAO, :NRCOPIAS END-EXEC. */

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
            /*" -624- EXEC SQL CLOSE TRELAT END-EXEC. */

            TRELAT.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_102_999_EXIT*/

        [StopWatch]
        /*" M-150-000-SELECT-V0SUREG-SECTION */
        private void M_150_000_SELECT_V0SUREG_SECTION()
        {
            /*" -634- MOVE '150-000-SELECT-V0SUREG' TO PARAGRAFO. */
            _.Move("150-000-SELECT-V0SUREG", WABEND.PARAGRAFO);

            /*" -636- MOVE '150' TO WNR-EXEC-SQL. */
            _.Move("150", WABEND.WNR_EXEC_SQL);

            /*" -644- PERFORM M_150_000_SELECT_V0SUREG_DB_SELECT_1 */

            M_150_000_SELECT_V0SUREG_DB_SELECT_1();

            /*" -648- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -650- MOVE FSUREG TO SUREG. */
                _.Move(FSUREG, SUREG);
            }


            /*" -651- MOVE FSUREG TO CODFILIAL-C03. */
            _.Move(FSUREG, CABEC03.CODFILIAL_C03);

            /*" -651- MOVE SUREG TO FILIAL-C03. */
            _.Move(SUREG, CABEC03.FILIAL_C03);

        }

        [StopWatch]
        /*" M-150-000-SELECT-V0SUREG-DB-SELECT-1 */
        public void M_150_000_SELECT_V0SUREG_DB_SELECT_1()
        {
            /*" -644- EXEC SQL SELECT NOME_SUREG INTO :SUREG FROM SEGUROS.V0SUREG WHERE COD_SUREG = :FSUREG END-EXEC. */

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
        /*" M-230-000-SELECT-V0COBERAPOL-SECTION */
        private void M_230_000_SELECT_V0COBERAPOL_SECTION()
        {
            /*" -667- MOVE '230-000-SELECT-V0COBERAPOL' TO PARAGRAFO. */
            _.Move("230-000-SELECT-V0COBERAPOL", WABEND.PARAGRAFO);

            /*" -669- MOVE '230' TO WNR-EXEC-SQL. */
            _.Move("230", WABEND.WNR_EXEC_SQL);

            /*" -685- PERFORM M_230_000_SELECT_V0COBERAPOL_DB_SELECT_1 */

            M_230_000_SELECT_V0COBERAPOL_DB_SELECT_1();

            /*" -688- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -690- MOVE +0 TO CIMP-SEGURADA-IX CPRM-TARIFARIO-IX */
                _.Move(+0, CIMP_SEGURADA_IX, CPRM_TARIFARIO_IX);

                /*" -691- ELSE */
            }
            else
            {


                /*" -692- PERFORM 1000-000-COTACAO */

                M_1000_000_COTACAO_SECTION();

                /*" -694- COMPUTE CIMP-SEGURADA-IX = CIMP-SEGURADA-IX * DVLCRUZAD-IMP */
                CIMP_SEGURADA_IX.Value = CIMP_SEGURADA_IX * DVLCRUZAD_IMP;

                /*" -695- COMPUTE CPRM-TARIFARIO-IX = CPRM-TARIFARIO-IX * DVLCRUZAD-PRM. */
                CPRM_TARIFARIO_IX.Value = CPRM_TARIFARIO_IX * DVLCRUZAD_PRM;
            }


        }

        [StopWatch]
        /*" M-230-000-SELECT-V0COBERAPOL-DB-SELECT-1 */
        public void M_230_000_SELECT_V0COBERAPOL_DB_SELECT_1()
        {
            /*" -685- EXEC SQL SELECT IMP_SEGURADA_IX, PRM_TARIFARIO_IX INTO :CIMP-SEGURADA-IX, :CPRM-TARIFARIO-IX FROM SEGUROS.V0COBERAPOL WHERE NUM_APOLICE = 93010000890 AND NRENDOS = 0 AND NUM_ITEM = :SNUM-ITEM AND OCORHIST = :SOCORR-HISTORICO AND MODALIFR = 0 AND RAMOFR = 93 END-EXEC. */

            var m_230_000_SELECT_V0COBERAPOL_DB_SELECT_1_Query1 = new M_230_000_SELECT_V0COBERAPOL_DB_SELECT_1_Query1()
            {
                SOCORR_HISTORICO = SOCORR_HISTORICO.ToString(),
                SNUM_ITEM = SNUM_ITEM.ToString(),
            };

            var executed_1 = M_230_000_SELECT_V0COBERAPOL_DB_SELECT_1_Query1.Execute(m_230_000_SELECT_V0COBERAPOL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CIMP_SEGURADA_IX, CIMP_SEGURADA_IX);
                _.Move(executed_1.CPRM_TARIFARIO_IX, CPRM_TARIFARIO_IX);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_230_999_EXIT*/

        [StopWatch]
        /*" M-255-000-MONTA-DETALHE-SECTION */
        private void M_255_000_MONTA_DETALHE_SECTION()
        {
            /*" -710- MOVE FMATRICULA TO MATRICULA-DET. */
            _.Move(FMATRICULA, DETALHE.MATRICULA_DET);

            /*" -711- MOVE SNUM-CERTIFICADO TO CERTIF-DET. */
            _.Move(SNUM_CERTIFICADO, DETALHE.CERTIF_DET);

            /*" -712- MOVE FNOME-FUNC TO NOME-DET. */
            _.Move(FNOME_FUNC, DETALHE.NOME_DET);

            /*" -713- MOVE CIMP-SEGURADA-IX TO MORTE-NAT-DET. */
            _.Move(CIMP_SEGURADA_IX, DETALHE.MORTE_NAT_DET);

            /*" -714- COMPUTE WS-MORTE-ACI = CIMP-SEGURADA-IX * 2. */
            WS_MORTE_ACI.Value = CIMP_SEGURADA_IX * 2;

            /*" -716- MOVE WS-MORTE-ACI TO MORTE-ACI-DET INV-PERM-DET. */
            _.Move(WS_MORTE_ACI, DETALHE.MORTE_ACI_DET, DETALHE.INV_PERM_DET);

            /*" -716- MOVE CPRM-TARIFARIO-IX TO PREMIO-DET. */
            _.Move(CPRM_TARIFARIO_IX, DETALHE.PREMIO_DET);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_255_999_EXIT*/

        [StopWatch]
        /*" M-260-000-IMPRIME-RELACAO-SECTION */
        private void M_260_000_IMPRIME_RELACAO_SECTION()
        {
            /*" -733- ADD CPRM-TARIFARIO-IX TO WTOT-PREMIO-L WTOT-PREMIO-S WTOT-PREMIO-G. */
            WTOT_PREMIO_L.Value = WTOT_PREMIO_L + CPRM_TARIFARIO_IX;
            WTOT_PREMIO_S.Value = WTOT_PREMIO_S + CPRM_TARIFARIO_IX;
            WTOT_PREMIO_G.Value = WTOT_PREMIO_G + CPRM_TARIFARIO_IX;

            /*" -734- IF W-CONT-LINHA = 48 */

            if (W_CONT_LINHA == 48)
            {

                /*" -736- PERFORM 265-000-CABECALHO. */

                M_265_000_CABECALHO_SECTION();
            }


            /*" -738- WRITE REG-IMPRESSAO FROM DETALHE AFTER 1. */
            _.Move(DETALHE.GetMoveValues(), REG_IMPRESSAO);

            RELPREFV.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -738- ADD 1 TO W-CONT-LINHA. */
            W_CONT_LINHA.Value = W_CONT_LINHA + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_260_999_EXIT*/

        [StopWatch]
        /*" M-265-000-CABECALHO-SECTION */
        private void M_265_000_CABECALHO_SECTION()
        {
            /*" -753- ADD 1 TO W-PAGINA */
            W_PAGINA.Value = W_PAGINA + 1;

            /*" -755- MOVE W-PAGINA TO PAGINA-C01 */
            _.Move(W_PAGINA, CABEC01.PAGINA_C01);

            /*" -756- MOVE WS-AA-HOJE TO ANO-C02 */
            _.Move(WS_DATA_HOJE_RD.WS_AA_HOJE, CABEC02.ANO_C02);

            /*" -757- MOVE WS-MM-HOJE TO MES-C02 */
            _.Move(WS_DATA_HOJE_RD.WS_MM_HOJE, CABEC02.MES_C02);

            /*" -759- MOVE WS-DD-HOJE TO DIA-C02 */
            _.Move(WS_DATA_HOJE_RD.WS_DD_HOJE, CABEC02.DIA_C02);

            /*" -760- WRITE REG-IMPRESSAO FROM TRACO AFTER PAGE. */
            _.Move(TRACO.GetMoveValues(), REG_IMPRESSAO);

            RELPREFV.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -761- WRITE REG-IMPRESSAO FROM CABEC01 AFTER 1. */
            _.Move(CABEC01.GetMoveValues(), REG_IMPRESSAO);

            RELPREFV.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -762- WRITE REG-IMPRESSAO FROM CABEC02 AFTER 1. */
            _.Move(CABEC02.GetMoveValues(), REG_IMPRESSAO);

            RELPREFV.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -763- WRITE REG-IMPRESSAO FROM CABEC02A AFTER 1. */
            _.Move(CABEC02A.GetMoveValues(), REG_IMPRESSAO);

            RELPREFV.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -764- WRITE REG-IMPRESSAO FROM TRACO AFTER 1. */
            _.Move(TRACO.GetMoveValues(), REG_IMPRESSAO);

            RELPREFV.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -765- WRITE REG-IMPRESSAO FROM CABEC03 AFTER 1. */
            _.Move(CABEC03.GetMoveValues(), REG_IMPRESSAO);

            RELPREFV.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -766- WRITE REG-IMPRESSAO FROM CABEC03A AFTER 1. */
            _.Move(CABEC03A.GetMoveValues(), REG_IMPRESSAO);

            RELPREFV.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -768- WRITE REG-IMPRESSAO FROM CABEC04 AFTER 2. */
            _.Move(CABEC04.GetMoveValues(), REG_IMPRESSAO);

            RELPREFV.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -769- MOVE SPACES TO REG-IMPRESSAO. */
            _.Move("", REG_IMPRESSAO);

            /*" -771- WRITE REG-IMPRESSAO AFTER 1. */
            RELPREFV.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -771- MOVE ZEROS TO W-CONT-LINHA. */
            _.Move(0, W_CONT_LINHA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_265_999_EXIT*/

        [StopWatch]
        /*" M-270-000-TOTAL-SUREG-SECTION */
        private void M_270_000_TOTAL_SUREG_SECTION()
        {
            /*" -788- MOVE WTOT-PREMIO-S TO DESCONTO-TOT-FL. */
            _.Move(WTOT_PREMIO_S, TOTAL_FILIAL.DESCONTO_TOT_FL);

            /*" -788- WRITE REG-IMPRESSAO FROM TOTAL-FILIAL AFTER 3. */
            _.Move(TOTAL_FILIAL.GetMoveValues(), REG_IMPRESSAO);

            RELPREFV.Write(REG_IMPRESSAO.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_270_999_EXIT*/

        [StopWatch]
        /*" M-280-000-TOTAL-LOTACAO-SECTION */
        private void M_280_000_TOTAL_LOTACAO_SECTION()
        {
            /*" -800- MOVE WTOT-PREMIO-L TO DESCONTO-TOT-FL. */
            _.Move(WTOT_PREMIO_L, TOTAL_FILIAL.DESCONTO_TOT_FL);

            /*" -800- WRITE REG-IMPRESSAO FROM TOTAL-FILIAL AFTER 3. */
            _.Move(TOTAL_FILIAL.GetMoveValues(), REG_IMPRESSAO);

            RELPREFV.Write(REG_IMPRESSAO.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_280_999_EXIT*/

        [StopWatch]
        /*" M-800-000-TOTAL-GERAL-SECTION */
        private void M_800_000_TOTAL_GERAL_SECTION()
        {
            /*" -814- IF W-LIDOS EQUAL ZEROS */

            if (W_LIDOS == 00)
            {

                /*" -816- GO TO 800-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_800_999_EXIT*/ //GOTO
                return;
            }


            /*" -818- MOVE WTOT-PREMIO-G TO DESCONTO-GERAL. */
            _.Move(WTOT_PREMIO_G, TOTAL_GERAL.DESCONTO_GERAL);

            /*" -818- WRITE REG-IMPRESSAO FROM TOTAL-GERAL AFTER 2. */
            _.Move(TOTAL_GERAL.GetMoveValues(), REG_IMPRESSAO);

            RELPREFV.Write(REG_IMPRESSAO.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_800_999_EXIT*/

        [StopWatch]
        /*" M-900-000-FINALIZA-SECTION */
        private void M_900_000_FINALIZA_SECTION()
        {
            /*" -832- CLOSE RELPREFV. */
            RELPREFV.Close();

            /*" -834- EXEC SQL COMMIT WORK END-EXEC */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -838- IF W-LIDOS NOT EQUAL ZEROS */

            if (W_LIDOS != 00)
            {

                /*" -839- DISPLAY 'VP0107B --------------------------------------' */
                _.Display($"VP0107B --------------------------------------");

                /*" -840- DISPLAY '  TOTAL DE REGISTROS PROCESSADOS.             ' */
                _.Display($"  TOTAL DE REGISTROS PROCESSADOS.             ");

                /*" -841- DISPLAY '      TOTAL DE LIDOS............ ' W-LIDOS */
                _.Display($"      TOTAL DE LIDOS............ {W_LIDOS}");

                /*" -842- DISPLAY '----------------------------------------------' */
                _.Display($"----------------------------------------------");

                /*" -844- DISPLAY 'FIM NORMAL      **** VP0107B ****' . */
                _.Display($"FIM NORMAL      **** VP0107B ****");
            }


            /*" -846- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -846- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_900_999_EXIT*/

        [StopWatch]
        /*" M-1000-000-COTACAO-SECTION */
        private void M_1000_000_COTACAO_SECTION()
        {
            /*" -855- MOVE '1000-000-COTACAO  ' TO PARAGRAFO. */
            _.Move("1000-000-COTACAO  ", WABEND.PARAGRAFO);

            /*" -857- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", WABEND.WNR_EXEC_SQL);

            /*" -872- PERFORM M_1000_000_COTACAO_DB_SELECT_1 */

            M_1000_000_COTACAO_DB_SELECT_1();

            /*" -876- IF ECOD-MOEDA-IMP = 0 OR ECOD-MOEDA-PRM = 0 */

            if (ECOD_MOEDA_IMP == 0 || ECOD_MOEDA_PRM == 0)
            {

                /*" -877- DISPLAY 'VP0105B -  HISTSEGVG SEM MOEDA' */
                _.Display($"VP0105B -  HISTSEGVG SEM MOEDA");

                /*" -879- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -880- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -881- DISPLAY 'VP0105B - NAO EXISTE HISTSEGVG P/ A APOLICE ' */
                _.Display($"VP0105B - NAO EXISTE HISTSEGVG P/ A APOLICE ");

                /*" -883- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -884- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -885- DISPLAY 'VP0105B - ERRO NO SELECT NA V1HISTSEGVG' */
                _.Display($"VP0105B - ERRO NO SELECT NA V1HISTSEGVG");

                /*" -886- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -886- PERFORM 1200-ACESSA-V1MOEDA. */

            M_1200_ACESSA_V1MOEDA_SECTION();

        }

        [StopWatch]
        /*" M-1000-000-COTACAO-DB-SELECT-1 */
        public void M_1000_000_COTACAO_DB_SELECT_1()
        {
            /*" -872- EXEC SQL SELECT DATA_MOVIMENTO, VALUE(COD_MOEDA_IMP, 0), VALUE(COD_MOEDA_PRM, 0) INTO :XDATA-MOVIMENTO, :ECOD-MOEDA-IMP, :ECOD-MOEDA-PRM FROM SEGUROS.V1HISTSEGVG WHERE NUM_APOLICE = 93010000890 AND NUM_ITEM = :SNUM-ITEM AND OCORR_HISTORICO = :SOCORR-HISTORICO END-EXEC. */

            var m_1000_000_COTACAO_DB_SELECT_1_Query1 = new M_1000_000_COTACAO_DB_SELECT_1_Query1()
            {
                SOCORR_HISTORICO = SOCORR_HISTORICO.ToString(),
                SNUM_ITEM = SNUM_ITEM.ToString(),
            };

            var executed_1 = M_1000_000_COTACAO_DB_SELECT_1_Query1.Execute(m_1000_000_COTACAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.XDATA_MOVIMENTO, XDATA_MOVIMENTO);
                _.Move(executed_1.ECOD_MOEDA_IMP, ECOD_MOEDA_IMP);
                _.Move(executed_1.ECOD_MOEDA_PRM, ECOD_MOEDA_PRM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1000_999_EXIT*/

        [StopWatch]
        /*" M-1200-ACESSA-V1MOEDA-SECTION */
        private void M_1200_ACESSA_V1MOEDA_SECTION()
        {
            /*" -901- MOVE '1200-ACESSA-V1MOEDA' TO PARAGRAFO. */
            _.Move("1200-ACESSA-V1MOEDA", WABEND.PARAGRAFO);

            /*" -903- MOVE '1200' TO WNR-EXEC-SQL. */
            _.Move("1200", WABEND.WNR_EXEC_SQL);

            /*" -912- PERFORM M_1200_ACESSA_V1MOEDA_DB_SELECT_1 */

            M_1200_ACESSA_V1MOEDA_DB_SELECT_1();

            /*" -915- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -917- DISPLAY 'VP0105B - NAO CONSTA REGISTRO NA V1MOEDA ' ECOD-MOEDA-IMP ' ' XDATA-MOVIMENTO */

                $"VP0105B - NAO CONSTA REGISTRO NA V1MOEDA {ECOD_MOEDA_IMP} {XDATA_MOVIMENTO}"
                .Display();

                /*" -919- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -920- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -921- DISPLAY 'VP0105B - ERRO NO SELECT  NA V1MOEDA  1 ' */
                _.Display($"VP0105B - ERRO NO SELECT  NA V1MOEDA  1 ");

                /*" -924- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -925- IF ECOD-MOEDA-IMP EQUAL ECOD-MOEDA-PRM */

            if (ECOD_MOEDA_IMP == ECOD_MOEDA_PRM)
            {

                /*" -926- MOVE DVLCRUZAD-IMP TO DVLCRUZAD-PRM */
                _.Move(DVLCRUZAD_IMP, DVLCRUZAD_PRM);

                /*" -928- GO TO 1200-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1200_EXIT*/ //GOTO
                return;
            }


            /*" -937- PERFORM M_1200_ACESSA_V1MOEDA_DB_SELECT_2 */

            M_1200_ACESSA_V1MOEDA_DB_SELECT_2();

            /*" -940- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -942- DISPLAY 'VP0105B - NAO CONSTA REGISTRO NA V1MOEDA ' ECOD-MOEDA-PRM ' ' XDATA-MOVIMENTO */

                $"VP0105B - NAO CONSTA REGISTRO NA V1MOEDA {ECOD_MOEDA_PRM} {XDATA_MOVIMENTO}"
                .Display();

                /*" -944- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -945- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -946- DISPLAY 'VP0105B - ERRO NO SELECT  NA V1MOEDA  2 ' */
                _.Display($"VP0105B - ERRO NO SELECT  NA V1MOEDA  2 ");

                /*" -946- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-1200-ACESSA-V1MOEDA-DB-SELECT-1 */
        public void M_1200_ACESSA_V1MOEDA_DB_SELECT_1()
        {
            /*" -912- EXEC SQL SELECT VLCRUZAD INTO :DVLCRUZAD-IMP FROM SEGUROS.V1MOEDA WHERE CODUNIMO = :ECOD-MOEDA-IMP AND DTINIVIG <= :XDATA-MOVIMENTO AND DTTERVIG >= :XDATA-MOVIMENTO AND SITUACAO = '0' END-EXEC. */

            var m_1200_ACESSA_V1MOEDA_DB_SELECT_1_Query1 = new M_1200_ACESSA_V1MOEDA_DB_SELECT_1_Query1()
            {
                XDATA_MOVIMENTO = XDATA_MOVIMENTO.ToString(),
                ECOD_MOEDA_IMP = ECOD_MOEDA_IMP.ToString(),
            };

            var executed_1 = M_1200_ACESSA_V1MOEDA_DB_SELECT_1_Query1.Execute(m_1200_ACESSA_V1MOEDA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.DVLCRUZAD_IMP, DVLCRUZAD_IMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1200_EXIT*/

        [StopWatch]
        /*" M-1200-ACESSA-V1MOEDA-DB-SELECT-2 */
        public void M_1200_ACESSA_V1MOEDA_DB_SELECT_2()
        {
            /*" -937- EXEC SQL SELECT VLCRUZAD INTO :DVLCRUZAD-PRM FROM SEGUROS.V1MOEDA WHERE CODUNIMO = :ECOD-MOEDA-PRM AND DTINIVIG <= :XDATA-MOVIMENTO AND DTTERVIG >= :XDATA-MOVIMENTO AND SITUACAO = '0' END-EXEC. */

            var m_1200_ACESSA_V1MOEDA_DB_SELECT_2_Query1 = new M_1200_ACESSA_V1MOEDA_DB_SELECT_2_Query1()
            {
                XDATA_MOVIMENTO = XDATA_MOVIMENTO.ToString(),
                ECOD_MOEDA_PRM = ECOD_MOEDA_PRM.ToString(),
            };

            var executed_1 = M_1200_ACESSA_V1MOEDA_DB_SELECT_2_Query1.Execute(m_1200_ACESSA_V1MOEDA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.DVLCRUZAD_PRM, DVLCRUZAD_PRM);
            }


        }

        [StopWatch]
        /*" M-8888-DISPLAY-TOTAIS-SECTION */
        private void M_8888_DISPLAY_TOTAIS_SECTION()
        {
            /*" -956- ADD 1 TO WS-COUNT ON-COUNTER. */
            WS_COUNT.Value = WS_COUNT + 1;
            ON_COUNTER.Value = ON_COUNTER + 1;

            /*" -958- IF WS-COUNT EQUAL 10000 OR ON-COUNTER EQUAL ON-INTERVAL */

            if (WS_COUNT == 10000 || ON_COUNTER == ON_INTERVAL)
            {

                /*" -959- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), WS_TIME);

                /*" -960- DISPLAY 'FUNC LIDOS ' WS-COUNT ' ' WS-TIME UPON CONSOLE */

                $"FUNC LIDOS {WS_COUNT} {WS_TIME}"
                .Display();

                /*" -960- MOVE 0 TO ON-COUNTER. */
                _.Move(0, ON_COUNTER);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8888_EXIT*/

        [StopWatch]
        /*" M-999-999-ROT-ERRO-SECTION */
        private void M_999_999_ROT_ERRO_SECTION()
        {
            /*" -975- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -976- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.WSQLCODE);

                /*" -977- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], WABEND.WSQLCODE1);

                /*" -978- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], WABEND.WSQLCODE2);

                /*" -979- MOVE SQLCODE TO WSQLCODE3 */
                _.Move(DB.SQLCODE, WSQLCODE3);

                /*" -981- DISPLAY WABEND. */
                _.Display(WABEND);
            }


            /*" -983- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -987- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -991- MOVE 9 TO RETURN-CODE */
            _.Move(9, RETURN_CODE);

            /*" -991- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}