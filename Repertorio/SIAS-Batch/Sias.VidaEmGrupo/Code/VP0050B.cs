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
using Sias.VidaEmGrupo.DB2.VP0050B;

namespace Code
{
    public class VP0050B
    {
        public bool IsCall { get; set; }

        public VP0050B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  VIDA EM GRUPO                      *      */
        /*"      *   PROGRAMA ...............  VP0050B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  JOSE AGNALDO                       *      */
        /*"      *   DATA CODIFICACAO .......  AGOSTO/1992                        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  LISTAR TOTAL DE AVERBACOES NA RU-  *      */
        /*"      *                             BRICA 636 POR SUREG                *      */
        /*"      *                             (APOLICE PREFERENCIAL VIDA)        *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/1998 - LUIZ CARLOS.                                    *      */
        /*"      *   PASSOU A GERAR NA V0RELATORIOS, SOLICITACAO PARA PROCESSAMEN-*      */
        /*"      *   TO DOS PROGRAMAS QUE IRAO GERAR MOVIMENTO PARA EMISSAO DO RE-*      */
        /*"      *   PASSE MENSAL DE SAF E CDG DA APOLICE 109300000218, SUBGRUPO 1*      */
        /*"      *   PREFERENCIAL VIDA PLUS - PESSOAL SASSE.                      *      */
        /*"      *                                                                *      */
        /*"      *   EM 09/1998 - LUIZ CARLOS.                                    *      */
        /*"      *   PASSOU A GERAR NA V0RELATORIOS, SOLICITACAO PARA PROCESSAMEN-*      */
        /*"      *   TO DOS PROGRAMAS QUE IRAO GERAR MOVIMENTO PARA EMISSAO DO RE-*      */
        /*"      *   PASSE MENSAL DE SAF E CDG DA APOLICE 93010000890, SUBGRUPO 3 *      */
        /*"      *   PREFERENCIAL VIDA PLUS - FENAE CORRETORA.                    *      */
        /*"      *                                                                *      */
        /*"      *   EM 09/1999 - LUIZ CARLOS.                                    *      */
        /*"      *   ESTE PROGRAMA FOI REESTRUTURADO PARA TRATAR OS SEGURADOS TAN-*      */
        /*"      *   TO NA ESTRUTURA ANTIGO DO SISTEMA,  COMO NA ESTRUTURA DO MUL-*      */
        /*"      *   TIPREMIADO. PASSA A TRATAR UM OU MAIS MOVIMENTO NO MES PARA  *      */
        /*"      *   A MESMA MATRICULA.                                           *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                            VIEW                 ACESSO  *      */
        /*"      * --------------------------------- -----------------    ------- *      */
        /*"      * SISTEMAS                          V1SISTEMA            INPUT   *      */
        /*"      * EMPRESAS                          V1EMPRESA            INPUT   *      */
        /*"      * RELATORIOS                        V1RELATORIOS         INPUT   *      */
        /*"      * AVERBACOES CEF                    V0AVERBCEF           INPUT   *      */
        /*"      * FUNCIONARIOS CEF                  V0FUNCIOCEF          INPUT   *      */
        /*"      * SUREGS                            V0SUREG              INPUT   *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _RVP0050B { get; set; } = new FileBasis(new PIC("X", "132", "X(132)"));

        public FileBasis RVP0050B
        {
            get
            {
                _.Move(REG_VP0050B, _RVP0050B); VarBasis.RedefinePassValue(REG_VP0050B, _RVP0050B, REG_VP0050B); return _RVP0050B;
            }
        }
        /*"01              REG-VP0050B        PIC  X(132).*/
        public StringBasis REG_VP0050B { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77         VIND-COD-EMP        PIC S9(004)                COMP.*/
        public IntBasis VIND_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-NRMATRIC-ANT  PIC S9(015) VALUE +0       COMP-3*/
        public IntBasis WHOST_NRMATRIC_ANT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77          VIND-VLCUSTSAF    PIC S9(004) COMP.*/
        public IntBasis VIND_VLCUSTSAF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1SIST-DTMOVABE   PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V0SURE-NOME-SUREG PIC  X(040).*/
        public StringBasis V0SURE_NOME_SUREG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77         V1EMPR-COD-EMP      PIC S9(004)                COMP.*/
        public IntBasis V1EMPR_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1EMPR-NOM-EMP      PIC  X(040).*/
        public StringBasis V1EMPR_NOM_EMP { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77         V1EMPR-CGCCPF       PIC S9(015)                COMP-3*/
        public IntBasis V1EMPR_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V1RELA-MES-REFER    PIC S9(004)                COMP.*/
        public IntBasis V1RELA_MES_REFER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1RELA-ANO-REFER    PIC S9(004)                COMP.*/
        public IntBasis V1RELA_ANO_REFER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1RELA-CODRELAT     PIC  X(008).*/
        public StringBasis V1RELA_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V1RELA-DATA-REFER   PIC  X(010).*/
        public StringBasis V1RELA_DATA_REFER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1RELA-SITUACAO     PIC  X(001).*/
        public StringBasis V1RELA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0FUNC-COD-SUREG    PIC  S9(004)     COMP.*/
        public IntBasis V0FUNC_COD_SUREG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0FUNC-NRMATRIC     PIC  S9(15)      COMP-3.*/
        public IntBasis V0FUNC_NRMATRIC { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77         V0AVER-NRMATRIC     PIC  S9(15)      COMP-3.*/
        public IntBasis V0AVER_NRMATRIC { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77         V0AVER-VAL-AVERB    PIC  S9(09)V99   COMP-3.*/
        public DoubleBasis V0AVER_VAL_AVERB { get; set; } = new DoubleBasis(new PIC("S9", "9", "S9(09)V99"), 2);
        /*"77         V0AVER-TPMOVTO      PIC  X(001).*/
        public StringBasis V0AVER_TPMOVTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0AVER-COD-SUREG    PIC  S9(004)     COMP.*/
        public IntBasis V0AVER_COD_SUREG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HIST-NRPARCEL     PIC  S9(004)     COMP.*/
        public IntBasis V0HIST_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HIST-DTVENCTO     PIC   X(010).*/
        public StringBasis V0HIST_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0HIST-SITUACAO     PIC   X(001).*/
        public StringBasis V0HIST_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0HIST-VLPRMTOT     PIC  S9(013)V99  COMP-3.*/
        public DoubleBasis V0HIST_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COBP-VLTITCAP     PIC  S9(13)V99   COMP-3.*/
        public DoubleBasis V0COBP_VLTITCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77         V0SEGV-NRCERTIF     PIC  S9(15)      COMP-3.*/
        public IntBasis V0SEGV_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77         V0SEGV-CODCLIEN     PIC  S9(09)      COMP-3.*/
        public IntBasis V0SEGV_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01           AREA-DE-WORK.*/
        public VP0050B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VP0050B_AREA_DE_WORK();
        public class VP0050B_AREA_DE_WORK : VarBasis
        {
            /*"  05         WS-SUREG-ANT      PIC S9(004)    COMP.*/
            public IntBasis WS_SUREG_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05         WSL-SQLCODE       PIC  9(009)    VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WRESTO            PIC S9(003)    VALUE +0 COMP-3.*/
            public IntBasis WRESTO { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
            /*"  05         AC-LINHAS         PIC  9(002)    VALUE 80.*/
            public IntBasis AC_LINHAS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 80);
            /*"  05         AC-SEG-NAO-EXISTE PIC  9(004)    VALUE ZEROS.*/
            public IntBasis AC_SEG_NAO_EXISTE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         AC-PAGINA         PIC  9(004)    VALUE ZEROS.*/
            public IntBasis AC_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         WHORA             PIC  99.99.99.99.*/
            public IntBasis WHORA { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
            /*"  05         AC-LIDOS          PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         WS-TOT-VIDAS-SUR  PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WS_TOT_VIDAS_SUR { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WS-VAL-AVERB-SUR  PIC S9(012)V99 VALUE ZEROS.*/
            public DoubleBasis WS_VAL_AVERB_SUR { get; set; } = new DoubleBasis(new PIC("S9", "12", "S9(012)V99"), 2);
            /*"  05         WS-TOT-VIDAS-GER  PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WS_TOT_VIDAS_GER { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WS-VAL-AVERB-GER  PIC S9(012)V99 VALUE ZEROS.*/
            public DoubleBasis WS_VAL_AVERB_GER { get; set; } = new DoubleBasis(new PIC("S9", "12", "S9(012)V99"), 2);
            /*"  05         WS-SUREG-DISP     PIC  9(002)    VALUE ZEROS.*/
            public IntBasis WS_SUREG_DISP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05         WS-TOT-PREMI-GER  PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WS_TOT_PREMI_GER { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WS-VAL-PREMI-GER  PIC S9(012)V99 VALUE ZEROS.*/
            public DoubleBasis WS_VAL_PREMI_GER { get; set; } = new DoubleBasis(new PIC("S9", "12", "S9(012)V99"), 2);
            /*"  05         WS-TOT-CDG-GER    PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WS_TOT_CDG_GER { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WS-VAL-CDG-GER    PIC S9(012)V99 VALUE ZEROS.*/
            public DoubleBasis WS_VAL_CDG_GER { get; set; } = new DoubleBasis(new PIC("S9", "12", "S9(012)V99"), 2);
            /*"  05         WS-TOT-SAF-GER    PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WS_TOT_SAF_GER { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WS-VAL-SAF-GER    PIC S9(012)V99 VALUE ZEROS.*/
            public DoubleBasis WS_VAL_SAF_GER { get; set; } = new DoubleBasis(new PIC("S9", "12", "S9(012)V99"), 2);
            /*"  05         WS-ACHOU-PARCELA  PIC  X(003)    VALUE SPACES.*/
            public StringBasis WS_ACHOU_PARCELA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05         WS-MULTIPREMIADO  PIC  X(003)    VALUE SPACES.*/
            public StringBasis WS_MULTIPREMIADO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05         WFIM-V0SEGURAVG   PIC  X(003)    VALUE SPACES.*/
            public StringBasis WFIM_V0SEGURAVG { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05         WFIM-V0HISTCOBVA  PIC  X(003)    VALUE SPACES.*/
            public StringBasis WFIM_V0HISTCOBVA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05         WFIM-V1SISTEMA    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1SISTEMA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V0FUNCIOCEF  PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V0FUNCIOCEF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V0AVERBCEF   PIC  X(003)    VALUE SPACES.*/
            public StringBasis WFIM_V0AVERBCEF { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05         WFIM-V1RELATORIO  PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1RELATORIO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1NUMEROREGI PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1NUMEROREGI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         CH-CHAVE-ATU.*/
            public VP0050B_CH_CHAVE_ATU CH_CHAVE_ATU { get; set; } = new VP0050B_CH_CHAVE_ATU();
            public class VP0050B_CH_CHAVE_ATU : VarBasis
            {
                /*"    10       CH-LIDER-ATU      PIC X(004)    VALUE LOW-VALUES.*/
                public StringBasis CH_LIDER_ATU { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"S");
                /*"    10       CH-LIDER-ATUR     REDEFINES     CH-LIDER-ATU                               PIC 9(004).*/
                private _REDEF_IntBasis _ch_lider_atur { get; set; }
                public _REDEF_IntBasis CH_LIDER_ATUR
                {
                    get { _ch_lider_atur = new _REDEF_IntBasis(new PIC("9", "004", "9(004).")); ; _.Move(CH_LIDER_ATU, _ch_lider_atur); VarBasis.RedefinePassValue(CH_LIDER_ATU, _ch_lider_atur, CH_LIDER_ATU); _ch_lider_atur.ValueChanged += () => { _.Move(_ch_lider_atur, CH_LIDER_ATU); }; return _ch_lider_atur; }
                    set { VarBasis.RedefinePassValue(value, _ch_lider_atur, CH_LIDER_ATU); }
                }  //Redefines
                /*"  05         AC-L-V0FUNCIOCEF  PIC  9(004)    VALUE ZEROS.*/
            }
            public IntBasis AC_L_V0FUNCIOCEF { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         AC-R-V1PREMIOS    PIC  9(004)    VALUE ZEROS.*/
            public IntBasis AC_R_V1PREMIOS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         AC-P-V1PREMIOS    PIC  9(004)    VALUE ZEROS.*/
            public IntBasis AC_P_V1PREMIOS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         AC-I-V0FUNCIOCEF  PIC  9(004)    VALUE ZEROS.*/
            public IntBasis AC_I_V0FUNCIOCEF { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         AC-I-V0AVERBCEF   PIC  9(004)    VALUE ZEROS.*/
            public IntBasis AC_I_V0AVERBCEF { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         WDIA              PIC  9(002)    VALUE ZEROS.*/
            public IntBasis WDIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05         WMES              PIC  9(002)    VALUE ZEROS.*/
            public IntBasis WMES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05         WANO              PIC  9(004)    VALUE ZEROS.*/
            public IntBasis WANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         WDATA-CURR.*/
            public VP0050B_WDATA_CURR WDATA_CURR { get; set; } = new VP0050B_WDATA_CURR();
            public class VP0050B_WDATA_CURR : VarBasis
            {
                /*"    10       WDATA-MM-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE SPACES.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WDATA-DD-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_DD_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE SPACES.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WDATA-AA-CURR     PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDATA_AA_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05         WHORA-CURR.*/
            }
            public VP0050B_WHORA_CURR WHORA_CURR { get; set; } = new VP0050B_WHORA_CURR();
            public class VP0050B_WHORA_CURR : VarBasis
            {
                /*"    10       WHORA-HH-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_HH_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORA-MM-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORA-SS-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_SS_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORA-CC-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_CC_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WDATA-CABEC.*/
            }
            public VP0050B_WDATA_CABEC WDATA_CABEC { get; set; } = new VP0050B_WDATA_CABEC();
            public class VP0050B_WDATA_CABEC : VarBasis
            {
                /*"    10       WDATA-DD-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDATA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDATA-AA-CABEC    PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05         WHORA-CABEC.*/
            }
            public VP0050B_WHORA_CABEC WHORA_CABEC { get; set; } = new VP0050B_WHORA_CABEC();
            public class VP0050B_WHORA_CABEC : VarBasis
            {
                /*"    10       WHORA-HH-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_HH_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '.'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10       WHORA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '.'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10       WHORA-SS-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_SS_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WDATA-REL         PIC  X(010)    VALUE SPACES.*/
            }
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WDATA-REL.*/
            private _REDEF_VP0050B_FILLER_6 _filler_6 { get; set; }
            public _REDEF_VP0050B_FILLER_6 FILLER_6
            {
                get { _filler_6 = new _REDEF_VP0050B_FILLER_6(); _.Move(WDATA_REL, _filler_6); VarBasis.RedefinePassValue(WDATA_REL, _filler_6, WDATA_REL); _filler_6.ValueChanged += () => { _.Move(_filler_6, WDATA_REL); }; return _filler_6; }
                set { VarBasis.RedefinePassValue(value, _filler_6, WDATA_REL); }
            }  //Redefines
            public class _REDEF_VP0050B_FILLER_6 : VarBasis
            {
                /*"    10       WDAT-REL-ANO      PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-MES      PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-DIA      PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDTVENCTO         PIC  X(010)    VALUE SPACES.*/

                public _REDEF_VP0050B_FILLER_6()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_7.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_8.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WDTVENCTO.*/
            private _REDEF_VP0050B_FILLER_9 _filler_9 { get; set; }
            public _REDEF_VP0050B_FILLER_9 FILLER_9
            {
                get { _filler_9 = new _REDEF_VP0050B_FILLER_9(); _.Move(WDTVENCTO, _filler_9); VarBasis.RedefinePassValue(WDTVENCTO, _filler_9, WDTVENCTO); _filler_9.ValueChanged += () => { _.Move(_filler_9, WDTVENCTO); }; return _filler_9; }
                set { VarBasis.RedefinePassValue(value, _filler_9, WDTVENCTO); }
            }  //Redefines
            public class _REDEF_VP0050B_FILLER_9 : VarBasis
            {
                /*"    10       WDTVENCTO-ANO     PIC  9(004).*/
                public IntBasis WDTVENCTO_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDTVENCTO-MES     PIC  9(002).*/
                public IntBasis WDTVENCTO_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDTVENCTO-DIA     PIC  9(002).*/
                public IntBasis WDTVENCTO_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDAT-REL-LIT.*/

                public _REDEF_VP0050B_FILLER_9()
                {
                    WDTVENCTO_ANO.ValueChanged += OnValueChanged;
                    FILLER_10.ValueChanged += OnValueChanged;
                    WDTVENCTO_MES.ValueChanged += OnValueChanged;
                    FILLER_11.ValueChanged += OnValueChanged;
                    WDTVENCTO_DIA.ValueChanged += OnValueChanged;
                }

            }
            public VP0050B_WDAT_REL_LIT WDAT_REL_LIT { get; set; } = new VP0050B_WDAT_REL_LIT();
            public class VP0050B_WDAT_REL_LIT : VarBasis
            {
                /*"    10       WDAT-LIT-DIA      PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDAT_LIT_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDAT-LIT-MES      PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDAT_LIT_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDAT-LIT-ANO      PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDAT_LIT_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05         WDATA-DTMOVTO     PIC  X(010)    VALUE SPACES.*/
            }
            public StringBasis WDATA_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WDATA-DTMOVTO.*/
            private _REDEF_VP0050B_FILLER_14 _filler_14 { get; set; }
            public _REDEF_VP0050B_FILLER_14 FILLER_14
            {
                get { _filler_14 = new _REDEF_VP0050B_FILLER_14(); _.Move(WDATA_DTMOVTO, _filler_14); VarBasis.RedefinePassValue(WDATA_DTMOVTO, _filler_14, WDATA_DTMOVTO); _filler_14.ValueChanged += () => { _.Move(_filler_14, WDATA_DTMOVTO); }; return _filler_14; }
                set { VarBasis.RedefinePassValue(value, _filler_14, WDATA_DTMOVTO); }
            }  //Redefines
            public class _REDEF_VP0050B_FILLER_14 : VarBasis
            {
                /*"    10       WDATA-ANOMOV      PIC  9(004).*/
                public IntBasis WDATA_ANOMOV { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-MESMOV      PIC  9(002).*/
                public IntBasis WDATA_MESMOV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-DIAMOV      PIC  9(002).*/
                public IntBasis WDATA_DIAMOV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05        TABELA-MESES.*/

                public _REDEF_VP0050B_FILLER_14()
                {
                    WDATA_ANOMOV.ValueChanged += OnValueChanged;
                    FILLER_15.ValueChanged += OnValueChanged;
                    WDATA_MESMOV.ValueChanged += OnValueChanged;
                    FILLER_16.ValueChanged += OnValueChanged;
                    WDATA_DIAMOV.ValueChanged += OnValueChanged;
                }

            }
            public VP0050B_TABELA_MESES TABELA_MESES { get; set; } = new VP0050B_TABELA_MESES();
            public class VP0050B_TABELA_MESES : VarBasis
            {
                /*"    10      FILLER              PIC  X(009) VALUE 'JANEIRO'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"JANEIRO");
                /*"    10      FILLER              PIC  X(009) VALUE 'FEVEREIRO'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"FEVEREIRO");
                /*"    10      FILLER              PIC  X(009) VALUE 'MARCO'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"MARCO");
                /*"    10      FILLER              PIC  X(009) VALUE 'ABRIL'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"ABRIL");
                /*"    10      FILLER              PIC  X(009) VALUE 'MAIO'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"MAIO");
                /*"    10      FILLER              PIC  X(009) VALUE 'JUNHO'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"JUNHO");
                /*"    10      FILLER              PIC  X(009) VALUE 'JULHO'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"JULHO");
                /*"    10      FILLER              PIC  X(009) VALUE 'AGOSTO'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"AGOSTO");
                /*"    10      FILLER              PIC  X(009) VALUE 'SETEMBRO'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"SETEMBRO");
                /*"    10      FILLER              PIC  X(009) VALUE 'OUTUBRO'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"OUTUBRO");
                /*"    10      FILLER              PIC  X(009) VALUE 'NOVEMBRO'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"NOVEMBRO");
                /*"    10      FILLER              PIC  X(009) VALUE 'DEZEMBRO'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"DEZEMBRO");
                /*"  05        TABELA-MESES-R      REDEFINES   TABELA-MESES.*/
            }
            private _REDEF_VP0050B_TABELA_MESES_R _tabela_meses_r { get; set; }
            public _REDEF_VP0050B_TABELA_MESES_R TABELA_MESES_R
            {
                get { _tabela_meses_r = new _REDEF_VP0050B_TABELA_MESES_R(); _.Move(TABELA_MESES, _tabela_meses_r); VarBasis.RedefinePassValue(TABELA_MESES, _tabela_meses_r, TABELA_MESES); _tabela_meses_r.ValueChanged += () => { _.Move(_tabela_meses_r, TABELA_MESES); }; return _tabela_meses_r; }
                set { VarBasis.RedefinePassValue(value, _tabela_meses_r, TABELA_MESES); }
            }  //Redefines
            public class _REDEF_VP0050B_TABELA_MESES_R : VarBasis
            {
                /*"    10      TAB-MES             OCCURS      12                                PIC  X(009).*/
                public ListBasis<StringBasis, string> TAB_MES { get; set; } = new ListBasis<StringBasis, string>(new PIC("9", "9", "X(009)."), 12);
                /*"  05            LC01.*/

                public _REDEF_VP0050B_TABELA_MESES_R()
                {
                    TAB_MES.ValueChanged += OnValueChanged;
                }

            }
            public VP0050B_LC01 LC01 { get; set; } = new VP0050B_LC01();
            public class VP0050B_LC01 : VarBasis
            {
                /*"    10          FILLER          PIC  X(132) VALUE  ALL '*'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
                /*"  05            LC02.*/
            }
            public VP0050B_LC02 LC02 { get; set; } = new VP0050B_LC02();
            public class VP0050B_LC02 : VarBasis
            {
                /*"    10          FILLER          PIC  X(001) VALUE '*'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                /*"    10          FILLER          PIC  X(130) VALUE  SPACES.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "130", "X(130)"), @"");
                /*"    10          FILLER          PIC  X(001) VALUE '*'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                /*"  05            LC03.*/
            }
            public VP0050B_LC03 LC03 { get; set; } = new VP0050B_LC03();
            public class VP0050B_LC03 : VarBasis
            {
                /*"    10          FILLER          PIC  X(044) VALUE '* VP0050B'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "44", "X(044)"), @"* VP0050B");
                /*"    10          LC03-EMPRESA    PIC  X(040) VALUE  SPACES.*/
                public StringBasis LC03_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    10          FILLER          PIC  X(031) VALUE  SPACES.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "31", "X(031)"), @"");
                /*"    10          FILLER          PIC  X(007) VALUE 'PAGINA'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"PAGINA");
                /*"    10          LC03-PAGINA     PIC  ZZZZ.ZZ9.*/
                public IntBasis LC03_PAGINA { get; set; } = new IntBasis(new PIC("9", "7", "ZZZZ.ZZ9."));
                /*"    10          FILLER          PIC  X(002) VALUE ' *'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" *");
                /*"  05            LC04.*/
            }
            public VP0050B_LC04 LC04 { get; set; } = new VP0050B_LC04();
            public class VP0050B_LC04 : VarBasis
            {
                /*"    10          FILLER          PIC  X(115) VALUE '*'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "115", "X(115)"), @"*");
                /*"    10          FILLER          PIC  X(007) VALUE 'DATA'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"DATA");
                /*"    10          LC04-DATA       PIC  X(008) VALUE  SPACES.*/
                public StringBasis LC04_DATA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"    10          FILLER          PIC  X(002) VALUE ' *'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" *");
                /*"  05            LC05.*/
            }
            public VP0050B_LC05 LC05 { get; set; } = new VP0050B_LC05();
            public class VP0050B_LC05 : VarBasis
            {
                /*"    10          FILLER          PIC  X(034) VALUE '*'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"*");
                /*"    10          FILLER          PIC  X(049) VALUE               'AVERBACOES PREFERENCIAL VIDA NA FOLHA PAGTO. DE'*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "49", "X(049)"), @"AVERBACOES PREFERENCIAL VIDA NA FOLHA PAGTO. DE");
                /*"    10          LC05-MESEMI     PIC  X(010) VALUE  SPACES.*/
                public StringBasis LC05_MESEMI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10          FILLER          PIC  X(004) VALUE ' DE '.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @" DE ");
                /*"    10          LC05-ANOEMI     PIC  X(004) VALUE  SPACES.*/
                public StringBasis LC05_ANOEMI { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10          FILLER          PIC  X(014) VALUE '.'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @".");
                /*"    10          FILLER          PIC  X(007) VALUE 'HORA'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"HORA");
                /*"    10          LC05-HORA       PIC  X(008) VALUE  SPACES.*/
                public StringBasis LC05_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"    10          FILLER          PIC  X(002) VALUE ' *'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" *");
                /*"  05              LC06.*/
            }
            public VP0050B_LC06 LC06 { get; set; } = new VP0050B_LC06();
            public class VP0050B_LC06 : VarBasis
            {
                /*"    10          FILLER          PIC  X(19) VALUE SPACES.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "19", "X(19)"), @"");
                /*"    10          FILLER          PIC  X(57) VALUE '  S U R E G'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "57", "X(57)"), @"  S U R E G");
                /*"    10          FILLER          PIC  X(28) VALUE 'VIDAS'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "28", "X(28)"), @"VIDAS");
                /*"    10          FILLER          PIC  X(09) VALUE 'DESCONTOS'.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"DESCONTOS");
                /*"  05              LD01.*/
            }
            public VP0050B_LD01 LD01 { get; set; } = new VP0050B_LD01();
            public class VP0050B_LD01 : VarBasis
            {
                /*"    10          FILLER             PIC X(15) VALUE SPACES.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"");
                /*"    10          LD01-SUREG-R       PIC Z99.*/
                public IntBasis LD01_SUREG_R { get; set; } = new IntBasis(new PIC("9", "3", "Z99."));
                /*"    10          FILLER             PIC X     VALUE '-'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X"), @"-");
                /*"    10          LD01-NOME-SUREG-R  PIC X(40).*/
                public StringBasis LD01_NOME_SUREG_R { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"    10          FILLER             PIC X(16) VALUE SPACES.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"");
                /*"    10          LD01-ACS-VIDAS-R   PIC ZZZ.ZZ9.*/
                public IntBasis LD01_ACS_VIDAS_R { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.ZZ9."));
                /*"    10          FILLER             PIC X(16) VALUE SPACES.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"");
                /*"    10          LD01-ACS-PREMIOS-R PIC ZZZ.ZZZ.ZZZ.ZZ9,99-.*/
                public DoubleBasis LD01_ACS_PREMIOS_R { get; set; } = new DoubleBasis(new PIC("9", "12", "ZZZ.ZZZ.ZZZ.ZZ9V99-."), 3);
                /*"  05              LD02.*/
            }
            public VP0050B_LD02 LD02 { get; set; } = new VP0050B_LD02();
            public class VP0050B_LD02 : VarBasis
            {
                /*"    10          FILLER             PIC X(29) VALUE SPACES.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "29", "X(29)"), @"");
                /*"    10          FILLER             PIC X(46) VALUE               'TOTAL DE VIDAS - PREMIO'.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "46", "X(46)"), @"TOTAL DE VIDAS - PREMIO");
                /*"    10          LD02-ACT-VIDAS-R   PIC ZZZ.ZZ9.*/
                public IntBasis LD02_ACT_VIDAS_R { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.ZZ9."));
                /*"    10          FILLER             PIC X(16) VALUE SPACES.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"");
                /*"    10          LD02-ACT-PREMIOS-R PIC ZZZ.ZZZ.ZZZ.ZZ9,99-.*/
                public DoubleBasis LD02_ACT_PREMIOS_R { get; set; } = new DoubleBasis(new PIC("9", "12", "ZZZ.ZZZ.ZZZ.ZZ9V99-."), 3);
                /*"  05              LD03.*/
            }
            public VP0050B_LD03 LD03 { get; set; } = new VP0050B_LD03();
            public class VP0050B_LD03 : VarBasis
            {
                /*"    10          FILLER             PIC X(29) VALUE SPACES.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "29", "X(29)"), @"");
                /*"    10          FILLER             PIC X(46) VALUE               'TOTAL DE TITULO - VALOR TOTAL BRUTO'.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "46", "X(46)"), @"TOTAL DE TITULO - VALOR TOTAL BRUTO");
                /*"    10          LD03-ACT-VIDAS-R   PIC ZZZ.ZZ9.*/
                public IntBasis LD03_ACT_VIDAS_R { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.ZZ9."));
                /*"    10          FILLER             PIC X(16) VALUE SPACES.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"");
                /*"    10          LD03-ACT-PREMIOS-R PIC ZZZ.ZZZ.ZZZ.ZZ9,99-.*/
                public DoubleBasis LD03_ACT_PREMIOS_R { get; set; } = new DoubleBasis(new PIC("9", "12", "ZZZ.ZZZ.ZZZ.ZZ9V99-."), 3);
                /*"  05        WABEND.*/
            }
            public VP0050B_WABEND WABEND { get; set; } = new VP0050B_WABEND();
            public class VP0050B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(010) VALUE           ' VP0050B'.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VP0050B");
                /*"    10      FILLER              PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC  X(007) VALUE '0000000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"0000000");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"01          LK-LINK.*/
            }
        }
        public VP0050B_LK_LINK LK_LINK { get; set; } = new VP0050B_LK_LINK();
        public class VP0050B_LK_LINK : VarBasis
        {
            /*"  05        LK-RTCODE           PIC  S9(004)   VALUE +0   COMP.*/
            public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05        LK-TAMANHO          PIC  S9(004)   VALUE +40  COMP.*/
            public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
            /*"  05        LK-TITULO           PIC   X(132)   VALUE  SPACES.*/
            public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
        }


        public VP0050B_V0FUNCIOCEF V0FUNCIOCEF { get; set; } = new VP0050B_V0FUNCIOCEF();
        public VP0050B_V0SEGURAVG V0SEGURAVG { get; set; } = new VP0050B_V0SEGURAVG();
        public VP0050B_V0HISTCOBVA V0HISTCOBVA { get; set; } = new VP0050B_V0HISTCOBVA();
        public VP0050B_V0AVERBCEF V0AVERBCEF { get; set; } = new VP0050B_V0AVERBCEF();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string RVP0050B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                RVP0050B.SetFile(RVP0050B_FILE_NAME_P);

                /*" -421- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -422- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -425- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -429- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -429- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -436- PERFORM R0100-00-SELECT-V1SISTEMA */

            R0100_00_SELECT_V1SISTEMA_SECTION();

            /*" -437- IF WFIM-V1SISTEMA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1SISTEMA.IsEmpty())
            {

                /*" -439- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -441- PERFORM R8000-00-OPEN-ARQUIVOS */

            R8000_00_OPEN_ARQUIVOS_SECTION();

            /*" -442- PERFORM R0200-00-SELECT-V1RELATORIO */

            R0200_00_SELECT_V1RELATORIO_SECTION();

            /*" -443- IF WFIM-V1RELATORIO NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1RELATORIO.IsEmpty())
            {

                /*" -444- PERFORM R9800-00-ENCERRA-SEM-SOLIC */

                R9800_00_ENCERRA_SEM_SOLIC_SECTION();

                /*" -446- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -448- PERFORM R0500-00-MONTA-EMPRESA */

            R0500_00_MONTA_EMPRESA_SECTION();

            /*" -449- ACCEPT WHORA FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA);

            /*" -450- DISPLAY 'INICIO DECLARE V0FUNCIOCEF  ' WHORA */
            _.Display($"INICIO DECLARE V0FUNCIOCEF  {AREA_DE_WORK.WHORA}");

            /*" -451- PERFORM R0900-00-DECLARE-V0FUNCIOCEF */

            R0900_00_DECLARE_V0FUNCIOCEF_SECTION();

            /*" -452- ACCEPT WHORA FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA);

            /*" -454- DISPLAY 'FINAL  DECLARE V0FUNCIOCEF  ' WHORA */
            _.Display($"FINAL  DECLARE V0FUNCIOCEF  {AREA_DE_WORK.WHORA}");

            /*" -455- PERFORM R0910-00-FETCH-V0FUNCIOCEF */

            R0910_00_FETCH_V0FUNCIOCEF_SECTION();

            /*" -456- IF WFIM-V0FUNCIOCEF NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V0FUNCIOCEF.IsEmpty())
            {

                /*" -457- PERFORM R9900-00-ENCERRA-SEM-MOVTO */

                R9900_00_ENCERRA_SEM_MOVTO_SECTION();

                /*" -459- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -461- MOVE V0FUNC-COD-SUREG TO WS-SUREG-ANT. */
            _.Move(V0FUNC_COD_SUREG, AREA_DE_WORK.WS_SUREG_ANT);

            /*" -463- PERFORM R1300-SELECT-SUREG THRU R1300-FIM. */

            R1300_SELECT_SUREG_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_FIM*/


            /*" -466- PERFORM R1000-00-PROCESSA-FUNCIOCEF UNTIL CH-CHAVE-ATU EQUAL HIGH-VALUES */

            while (!(AREA_DE_WORK.CH_CHAVE_ATU.IsHighValues))
            {

                R1000_00_PROCESSA_FUNCIOCEF_SECTION();
            }

            /*" -468- PERFORM R1200-00-QUEBRA-SUREG THRU R1200-00-FIM. */

            R1200_00_QUEBRA_SUREG_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_00_FIM*/


            /*" -469- MOVE WS-VAL-AVERB-GER TO LD02-ACT-PREMIOS-R */
            _.Move(AREA_DE_WORK.WS_VAL_AVERB_GER, AREA_DE_WORK.LD02.LD02_ACT_PREMIOS_R);

            /*" -470- MOVE WS-TOT-VIDAS-GER TO LD02-ACT-VIDAS-R. */
            _.Move(AREA_DE_WORK.WS_TOT_VIDAS_GER, AREA_DE_WORK.LD02.LD02_ACT_VIDAS_R);

            /*" -471- MOVE WS-VAL-PREMI-GER TO LD03-ACT-PREMIOS-R */
            _.Move(AREA_DE_WORK.WS_VAL_PREMI_GER, AREA_DE_WORK.LD03.LD03_ACT_PREMIOS_R);

            /*" -473- MOVE WS-TOT-PREMI-GER TO LD03-ACT-VIDAS-R. */
            _.Move(AREA_DE_WORK.WS_TOT_PREMI_GER, AREA_DE_WORK.LD03.LD03_ACT_VIDAS_R);

            /*" -474- IF AC-LINHAS > 50 */

            if (AREA_DE_WORK.AC_LINHAS > 50)
            {

                /*" -476- PERFORM R3000-00-CABECALHOS THRU R3000-99-SAIDA. */

                R3000_00_CABECALHOS_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

            }


            /*" -477- WRITE REG-VP0050B FROM LD02 AFTER 1. */
            _.Move(AREA_DE_WORK.LD02.GetMoveValues(), REG_VP0050B);

            RVP0050B.Write(REG_VP0050B.GetMoveValues().ToString());

            /*" -479- WRITE REG-VP0050B FROM LD03 AFTER 1. */
            _.Move(AREA_DE_WORK.LD03.GetMoveValues(), REG_VP0050B);

            RVP0050B.Write(REG_VP0050B.GetMoveValues().ToString());

            /*" -480- DISPLAY '*--- VP0050B          ' */
            _.Display($"*--- VP0050B          ");

            /*" -482- DISPLAY '   . DOCUMENTOS LIDOS...............  ' AC-L-V0FUNCIOCEF */
            _.Display($"   . DOCUMENTOS LIDOS...............  {AREA_DE_WORK.AC_L_V0FUNCIOCEF}");

            /*" -484- DISPLAY '   . MATRICULAS NAO ENCONTRADAS.....  ' AC-SEG-NAO-EXISTE */
            _.Display($"   . MATRICULAS NAO ENCONTRADAS.....  {AREA_DE_WORK.AC_SEG_NAO_EXISTE}");

            /*" -487- DISPLAY '   . DOCUMENTOS IMPRESSOS...........  ' AC-I-V0FUNCIOCEF. */
            _.Display($"   . DOCUMENTOS IMPRESSOS...........  {AREA_DE_WORK.AC_I_V0FUNCIOCEF}");

            /*" -489- PERFORM R0210-00-DELETE-V0RELATORIO. */

            R0210_00_DELETE_V0RELATORIO_SECTION();

            /*" -489- PERFORM R9100-00-INSERT-V0RELATORIO. */

            R9100_00_INSERT_V0RELATORIO_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -497- PERFORM R9000-00-CLOSE-ARQUIVOS */

            R9000_00_CLOSE_ARQUIVOS_SECTION();

            /*" -497- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -501- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -501- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-SECTION */
        private void R0100_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -516- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -521- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -524- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -525- DISPLAY 'VP0050B - SISTEMA NAO ESTA CADASTRADO' */
                _.Display($"VP0050B - SISTEMA NAO ESTA CADASTRADO");

                /*" -526- MOVE 'S' TO WFIM-V1SISTEMA */
                _.Move("S", AREA_DE_WORK.WFIM_V1SISTEMA);

                /*" -528- GO TO R0100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -529- MOVE V1SIST-DTMOVABE TO WDATA-REL */
            _.Move(V1SIST_DTMOVABE, AREA_DE_WORK.WDATA_REL);

            /*" -530- MOVE WDAT-REL-DIA TO WDAT-LIT-DIA */
            _.Move(AREA_DE_WORK.FILLER_6.WDAT_REL_DIA, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_DIA);

            /*" -531- MOVE WDAT-REL-MES TO WDAT-LIT-MES */
            _.Move(AREA_DE_WORK.FILLER_6.WDAT_REL_MES, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_MES);

            /*" -532- MOVE WDAT-REL-ANO TO WDAT-LIT-ANO */
            _.Move(AREA_DE_WORK.FILLER_6.WDAT_REL_ANO, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_ANO);

            /*" -532- MOVE WDAT-REL-LIT TO LC04-DATA. */
            _.Move(AREA_DE_WORK.WDAT_REL_LIT, AREA_DE_WORK.LC04.LC04_DATA);

        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -521- EXEC SQL SELECT DTMOVABE INTO :V1SIST-DTMOVABE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VG' END-EXEC. */

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
        /*" R0200-00-SELECT-V1RELATORIO-SECTION */
        private void R0200_00_SELECT_V1RELATORIO_SECTION()
        {
            /*" -547- MOVE '020' TO WNR-EXEC-SQL. */
            _.Move("020", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -559- PERFORM R0200_00_SELECT_V1RELATORIO_DB_SELECT_1 */

            R0200_00_SELECT_V1RELATORIO_DB_SELECT_1();

            /*" -562- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -564- MOVE 'S' TO WFIM-V1RELATORIO */
                _.Move("S", AREA_DE_WORK.WFIM_V1RELATORIO);

                /*" -566- END-IF. */
            }


            /*" -567- MOVE V1RELA-MES-REFER TO WDAT-REL-MES. */
            _.Move(V1RELA_MES_REFER, AREA_DE_WORK.FILLER_6.WDAT_REL_MES);

            /*" -569- MOVE V1RELA-ANO-REFER TO WDAT-REL-ANO. */
            _.Move(V1RELA_ANO_REFER, AREA_DE_WORK.FILLER_6.WDAT_REL_ANO);

            /*" -570- MOVE TAB-MES (WDAT-REL-MES) TO LC05-MESEMI. */
            _.Move(AREA_DE_WORK.TABELA_MESES_R.TAB_MES[AREA_DE_WORK.FILLER_6.WDAT_REL_MES], AREA_DE_WORK.LC05.LC05_MESEMI);

            /*" -570- MOVE WDAT-REL-ANO TO LC05-ANOEMI. */
            _.Move(AREA_DE_WORK.FILLER_6.WDAT_REL_ANO, AREA_DE_WORK.LC05.LC05_ANOEMI);

        }

        [StopWatch]
        /*" R0200-00-SELECT-V1RELATORIO-DB-SELECT-1 */
        public void R0200_00_SELECT_V1RELATORIO_DB_SELECT_1()
        {
            /*" -559- EXEC SQL SELECT DATA_REFERENCIA , MES_REFERENCIA , ANO_REFERENCIA , SITUACAO INTO :V1RELA-DATA-REFER , :V1RELA-MES-REFER , :V1RELA-ANO-REFER , :V1RELA-SITUACAO FROM SEGUROS.V1RELATORIOS WHERE CODRELAT = 'VP0050B1' AND SITUACAO = '0' END-EXEC. */

            var r0200_00_SELECT_V1RELATORIO_DB_SELECT_1_Query1 = new R0200_00_SELECT_V1RELATORIO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0200_00_SELECT_V1RELATORIO_DB_SELECT_1_Query1.Execute(r0200_00_SELECT_V1RELATORIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1RELA_DATA_REFER, V1RELA_DATA_REFER);
                _.Move(executed_1.V1RELA_MES_REFER, V1RELA_MES_REFER);
                _.Move(executed_1.V1RELA_ANO_REFER, V1RELA_ANO_REFER);
                _.Move(executed_1.V1RELA_SITUACAO, V1RELA_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-DELETE-V0RELATORIO-SECTION */
        private void R0210_00_DELETE_V0RELATORIO_SECTION()
        {
            /*" -585- MOVE '021' TO WNR-EXEC-SQL. */
            _.Move("021", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -589- PERFORM R0210_00_DELETE_V0RELATORIO_DB_DELETE_1 */

            R0210_00_DELETE_V0RELATORIO_DB_DELETE_1();

        }

        [StopWatch]
        /*" R0210-00-DELETE-V0RELATORIO-DB-DELETE-1 */
        public void R0210_00_DELETE_V0RELATORIO_DB_DELETE_1()
        {
            /*" -589- EXEC SQL DELETE FROM SEGUROS.V0RELATORIOS WHERE CODRELAT = 'VP0050B1' AND SITUACAO = '0' END-EXEC. */

            var r0210_00_DELETE_V0RELATORIO_DB_DELETE_1_Delete1 = new R0210_00_DELETE_V0RELATORIO_DB_DELETE_1_Delete1()
            {
            };

            R0210_00_DELETE_V0RELATORIO_DB_DELETE_1_Delete1.Execute(r0210_00_DELETE_V0RELATORIO_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-MONTA-EMPRESA-SECTION */
        private void R0500_00_MONTA_EMPRESA_SECTION()
        {
            /*" -606- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -607- ACCEPT WHORA-CURR FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_CURR);

            /*" -608- MOVE WHORA-HH-CURR TO WHORA-HH-CABEC */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_HH_CURR, AREA_DE_WORK.WHORA_CABEC.WHORA_HH_CABEC);

            /*" -609- MOVE WHORA-MM-CURR TO WHORA-MM-CABEC */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_MM_CURR, AREA_DE_WORK.WHORA_CABEC.WHORA_MM_CABEC);

            /*" -610- MOVE WHORA-SS-CURR TO WHORA-SS-CABEC */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_SS_CURR, AREA_DE_WORK.WHORA_CABEC.WHORA_SS_CABEC);

            /*" -612- MOVE WHORA-CABEC TO LC05-HORA */
            _.Move(AREA_DE_WORK.WHORA_CABEC, AREA_DE_WORK.LC05.LC05_HORA);

            /*" -616- PERFORM R0500_00_MONTA_EMPRESA_DB_SELECT_1 */

            R0500_00_MONTA_EMPRESA_DB_SELECT_1();

            /*" -619- MOVE V1EMPR-NOM-EMP TO LK-TITULO */
            _.Move(V1EMPR_NOM_EMP, LK_LINK.LK_TITULO);

            /*" -621- CALL 'PROALN01' USING LK-LINK */
            _.Call("PROALN01", LK_LINK);

            /*" -622- IF LK-RTCODE EQUAL ZEROS */

            if (LK_LINK.LK_RTCODE == 00)
            {

                /*" -623- MOVE LK-TITULO TO LC03-EMPRESA */
                _.Move(LK_LINK.LK_TITULO, AREA_DE_WORK.LC03.LC03_EMPRESA);

                /*" -624- ELSE */
            }
            else
            {


                /*" -625- DISPLAY 'VP0050B - PROBLEMA CALL V1EMPRESA' */
                _.Display($"VP0050B - PROBLEMA CALL V1EMPRESA");

                /*" -625- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


        }

        [StopWatch]
        /*" R0500-00-MONTA-EMPRESA-DB-SELECT-1 */
        public void R0500_00_MONTA_EMPRESA_DB_SELECT_1()
        {
            /*" -616- EXEC SQL SELECT NOME_EMPRESA INTO :V1EMPR-NOM-EMP FROM SEGUROS.V1EMPRESA WHERE COD_EMPRESA = 0 END-EXEC. */

            var r0500_00_MONTA_EMPRESA_DB_SELECT_1_Query1 = new R0500_00_MONTA_EMPRESA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0500_00_MONTA_EMPRESA_DB_SELECT_1_Query1.Execute(r0500_00_MONTA_EMPRESA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1EMPR_NOM_EMP, V1EMPR_NOM_EMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-V0FUNCIOCEF-SECTION */
        private void R0900_00_DECLARE_V0FUNCIOCEF_SECTION()
        {
            /*" -640- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -650- PERFORM R0900_00_DECLARE_V0FUNCIOCEF_DB_DECLARE_1 */

            R0900_00_DECLARE_V0FUNCIOCEF_DB_DECLARE_1();

            /*" -652- PERFORM R0900_00_DECLARE_V0FUNCIOCEF_DB_OPEN_1 */

            R0900_00_DECLARE_V0FUNCIOCEF_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V0FUNCIOCEF-DB-DECLARE-1 */
        public void R0900_00_DECLARE_V0FUNCIOCEF_DB_DECLARE_1()
        {
            /*" -650- EXEC SQL DECLARE V0FUNCIOCEF CURSOR FOR SELECT A.COD_SUREG, A.NUM_MATRICULA FROM SEGUROS.V0FUNCIOCEF A, SEGUROS.V0SUREG B WHERE A.COD_RUBRICA = 636 AND A.COD_SUREG = B.COD_SUREG ORDER BY A.COD_SUREG, A.NUM_MATRICULA END-EXEC. */
            V0FUNCIOCEF = new VP0050B_V0FUNCIOCEF(false);
            string GetQuery_V0FUNCIOCEF()
            {
                var query = @$"SELECT A.COD_SUREG
							, 
							A.NUM_MATRICULA 
							FROM SEGUROS.V0FUNCIOCEF A
							, 
							SEGUROS.V0SUREG B 
							WHERE A.COD_RUBRICA = 636 
							AND A.COD_SUREG = B.COD_SUREG 
							ORDER BY A.COD_SUREG
							, 
							A.NUM_MATRICULA";

                return query;
            }
            V0FUNCIOCEF.GetQueryEvent += GetQuery_V0FUNCIOCEF;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V0FUNCIOCEF-DB-OPEN-1 */
        public void R0900_00_DECLARE_V0FUNCIOCEF_DB_OPEN_1()
        {
            /*" -652- EXEC SQL OPEN V0FUNCIOCEF END-EXEC. */

            V0FUNCIOCEF.Open();

        }

        [StopWatch]
        /*" R5001-00-DECLER-V0SEGURAVG-DB-DECLARE-1 */
        public void R5001_00_DECLER_V0SEGURAVG_DB_DECLARE_1()
        {
            /*" -833- EXEC SQL DECLARE V0SEGURAVG CURSOR FOR SELECT NUM_CERTIFICADO, COD_CLIENTE FROM SEGUROS.V0SEGURAVG WHERE NUM_APOLICE = 93010000890 AND COD_SUBGRUPO = 13 AND NUM_MATRICULA = :V0FUNC-NRMATRIC END-EXEC. */
            V0SEGURAVG = new VP0050B_V0SEGURAVG(true);
            string GetQuery_V0SEGURAVG()
            {
                var query = @$"SELECT NUM_CERTIFICADO
							, 
							COD_CLIENTE 
							FROM SEGUROS.V0SEGURAVG 
							WHERE NUM_APOLICE = 93010000890 
							AND COD_SUBGRUPO = 13 
							AND NUM_MATRICULA = '{V0FUNC_NRMATRIC}'";

                return query;
            }
            V0SEGURAVG.GetQueryEvent += GetQuery_V0SEGURAVG;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-V0FUNCIOCEF-SECTION */
        private void R0910_00_FETCH_V0FUNCIOCEF_SECTION()
        {
            /*" -667- MOVE '091' TO WNR-EXEC-SQL. */
            _.Move("091", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -670- PERFORM R0910_00_FETCH_V0FUNCIOCEF_DB_FETCH_1 */

            R0910_00_FETCH_V0FUNCIOCEF_DB_FETCH_1();

            /*" -673- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -674- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -675- MOVE 'S' TO WFIM-V0FUNCIOCEF */
                    _.Move("S", AREA_DE_WORK.WFIM_V0FUNCIOCEF);

                    /*" -676- MOVE HIGH-VALUES TO CH-CHAVE-ATU */

                    AREA_DE_WORK.CH_CHAVE_ATU.IsHighValues = true;

                    /*" -676- PERFORM R0910_00_FETCH_V0FUNCIOCEF_DB_CLOSE_1 */

                    R0910_00_FETCH_V0FUNCIOCEF_DB_CLOSE_1();

                    /*" -678- GO TO R0910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;

                    /*" -679- ELSE */
                }
                else
                {


                    /*" -680- DISPLAY 'VP0050B - ERRO FETCH V0FUNCIOCEF...  ' SQLCODE */
                    _.Display($"VP0050B - ERRO FETCH V0FUNCIOCEF...  {DB.SQLCODE}");

                    /*" -682- PERFORM R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION();
                }

            }


            /*" -687- ADD 1 TO AC-LIDOS */
            AREA_DE_WORK.AC_LIDOS.Value = AREA_DE_WORK.AC_LIDOS + 1;

            /*" -687- ADD 1 TO AC-L-V0FUNCIOCEF. */
            AREA_DE_WORK.AC_L_V0FUNCIOCEF.Value = AREA_DE_WORK.AC_L_V0FUNCIOCEF + 1;

        }

        [StopWatch]
        /*" R0910-00-FETCH-V0FUNCIOCEF-DB-FETCH-1 */
        public void R0910_00_FETCH_V0FUNCIOCEF_DB_FETCH_1()
        {
            /*" -670- EXEC SQL FETCH V0FUNCIOCEF INTO :V0FUNC-COD-SUREG, :V0FUNC-NRMATRIC END-EXEC. */

            if (V0FUNCIOCEF.Fetch())
            {
                _.Move(V0FUNCIOCEF.V0FUNC_COD_SUREG, V0FUNC_COD_SUREG);
                _.Move(V0FUNCIOCEF.V0FUNC_NRMATRIC, V0FUNC_NRMATRIC);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-V0FUNCIOCEF-DB-CLOSE-1 */
        public void R0910_00_FETCH_V0FUNCIOCEF_DB_CLOSE_1()
        {
            /*" -676- EXEC SQL CLOSE V0FUNCIOCEF END-EXEC */

            V0FUNCIOCEF.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-FUNCIOCEF-SECTION */
        private void R1000_00_PROCESSA_FUNCIOCEF_SECTION()
        {
            /*" -700- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -702- MOVE 'NAO' TO WS-MULTIPREMIADO. */
            _.Move("NAO", AREA_DE_WORK.WS_MULTIPREMIADO);

            /*" -704- MOVE SPACES TO WS-ACHOU-PARCELA. */
            _.Move("", AREA_DE_WORK.WS_ACHOU_PARCELA);

            /*" -706- PERFORM R5000-00-PROC-ESTRUTURA-MULT. */

            R5000_00_PROC_ESTRUTURA_MULT_SECTION();

            /*" -707- IF WS-MULTIPREMIADO EQUAL 'NAO' */

            if (AREA_DE_WORK.WS_MULTIPREMIADO == "NAO")
            {

                /*" -709- PERFORM R6000-00-ESTRUTURA-ANTIGA. */

                R6000_00_ESTRUTURA_ANTIGA_SECTION();
            }


            /*" -709- PERFORM R0910-00-FETCH-V0FUNCIOCEF. */

            R0910_00_FETCH_V0FUNCIOCEF_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-QUEBRA-SUREG-SECTION */
        private void R1200_00_QUEBRA_SUREG_SECTION()
        {
            /*" -722- MOVE WS-VAL-AVERB-SUR TO LD01-ACS-PREMIOS-R */
            _.Move(AREA_DE_WORK.WS_VAL_AVERB_SUR, AREA_DE_WORK.LD01.LD01_ACS_PREMIOS_R);

            /*" -724- MOVE WS-TOT-VIDAS-SUR TO LD01-ACS-VIDAS-R. */
            _.Move(AREA_DE_WORK.WS_TOT_VIDAS_SUR, AREA_DE_WORK.LD01.LD01_ACS_VIDAS_R);

            /*" -725- IF AC-LINHAS > 55 */

            if (AREA_DE_WORK.AC_LINHAS > 55)
            {

                /*" -727- PERFORM R3000-00-CABECALHOS THRU R3000-99-SAIDA. */

                R3000_00_CABECALHOS_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

            }


            /*" -728- WRITE REG-VP0050B FROM LD01 AFTER 1. */
            _.Move(AREA_DE_WORK.LD01.GetMoveValues(), REG_VP0050B);

            RVP0050B.Write(REG_VP0050B.GetMoveValues().ToString());

            /*" -731- ADD 1 TO AC-LINHAS, AC-I-V0FUNCIOCEF. */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 1;
            AREA_DE_WORK.AC_I_V0FUNCIOCEF.Value = AREA_DE_WORK.AC_I_V0FUNCIOCEF + 1;

            /*" -734- MOVE ZEROES TO WS-VAL-AVERB-SUR WS-TOT-VIDAS-SUR. */
            _.Move(0, AREA_DE_WORK.WS_VAL_AVERB_SUR, AREA_DE_WORK.WS_TOT_VIDAS_SUR);

            /*" -736- PERFORM R1300-SELECT-SUREG THRU R1300-FIM. */

            R1300_SELECT_SUREG_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_FIM*/


            /*" -736- MOVE V0FUNC-COD-SUREG TO WS-SUREG-ANT. */
            _.Move(V0FUNC_COD_SUREG, AREA_DE_WORK.WS_SUREG_ANT);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_00_FIM*/

        [StopWatch]
        /*" R1300-SELECT-SUREG-SECTION */
        private void R1300_SELECT_SUREG_SECTION()
        {
            /*" -749- MOVE '120' TO WNR-EXEC-SQL. */
            _.Move("120", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -754- PERFORM R1300_SELECT_SUREG_DB_SELECT_1 */

            R1300_SELECT_SUREG_DB_SELECT_1();

            /*" -757- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -758- MOVE V0FUNC-COD-SUREG TO WS-SUREG-DISP */
                _.Move(V0FUNC_COD_SUREG, AREA_DE_WORK.WS_SUREG_DISP);

                /*" -759- DISPLAY 'VP0050B - SUREG NAO CADASTRADA ' WS-SUREG-DISP */
                _.Display($"VP0050B - SUREG NAO CADASTRADA {AREA_DE_WORK.WS_SUREG_DISP}");

                /*" -760- DISPLAY 'VP0050B - INFORME O ANALISTA RESPONSAVEL' */
                _.Display($"VP0050B - INFORME O ANALISTA RESPONSAVEL");

                /*" -761- DISPLAY 'VP0050B - PROCESSAMENTO INTERROMPIDO...' */
                _.Display($"VP0050B - PROCESSAMENTO INTERROMPIDO...");

                /*" -762- DISPLAY ' ' */
                _.Display($" ");

                /*" -764- PERFORM R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION();
            }


            /*" -765- MOVE V0FUNC-COD-SUREG TO LD01-SUREG-R. */
            _.Move(V0FUNC_COD_SUREG, AREA_DE_WORK.LD01.LD01_SUREG_R);

            /*" -765- MOVE V0SURE-NOME-SUREG TO LD01-NOME-SUREG-R. */
            _.Move(V0SURE_NOME_SUREG, AREA_DE_WORK.LD01.LD01_NOME_SUREG_R);

        }

        [StopWatch]
        /*" R1300-SELECT-SUREG-DB-SELECT-1 */
        public void R1300_SELECT_SUREG_DB_SELECT_1()
        {
            /*" -754- EXEC SQL SELECT NOME_SUREG INTO :V0SURE-NOME-SUREG FROM SEGUROS.V0SUREG WHERE COD_SUREG = :V0FUNC-COD-SUREG END-EXEC. */

            var r1300_SELECT_SUREG_DB_SELECT_1_Query1 = new R1300_SELECT_SUREG_DB_SELECT_1_Query1()
            {
                V0FUNC_COD_SUREG = V0FUNC_COD_SUREG.ToString(),
            };

            var executed_1 = R1300_SELECT_SUREG_DB_SELECT_1_Query1.Execute(r1300_SELECT_SUREG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SURE_NOME_SUREG, V0SURE_NOME_SUREG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_FIM*/

        [StopWatch]
        /*" R3000-00-CABECALHOS-SECTION */
        private void R3000_00_CABECALHOS_SECTION()
        {
            /*" -777- MOVE '300' TO WNR-EXEC-SQL. */
            _.Move("300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -778- ADD 1 TO AC-PAGINA */
            AREA_DE_WORK.AC_PAGINA.Value = AREA_DE_WORK.AC_PAGINA + 1;

            /*" -779- MOVE AC-PAGINA TO LC03-PAGINA */
            _.Move(AREA_DE_WORK.AC_PAGINA, AREA_DE_WORK.LC03.LC03_PAGINA);

            /*" -781- MOVE ZEROS TO AC-LINHAS */
            _.Move(0, AREA_DE_WORK.AC_LINHAS);

            /*" -782- WRITE REG-VP0050B FROM LC01 AFTER PAGE */
            _.Move(AREA_DE_WORK.LC01.GetMoveValues(), REG_VP0050B);

            RVP0050B.Write(REG_VP0050B.GetMoveValues().ToString());

            /*" -783- WRITE REG-VP0050B FROM LC02 AFTER 1 */
            _.Move(AREA_DE_WORK.LC02.GetMoveValues(), REG_VP0050B);

            RVP0050B.Write(REG_VP0050B.GetMoveValues().ToString());

            /*" -784- WRITE REG-VP0050B FROM LC03 AFTER 1 */
            _.Move(AREA_DE_WORK.LC03.GetMoveValues(), REG_VP0050B);

            RVP0050B.Write(REG_VP0050B.GetMoveValues().ToString());

            /*" -785- WRITE REG-VP0050B FROM LC04 AFTER 1 */
            _.Move(AREA_DE_WORK.LC04.GetMoveValues(), REG_VP0050B);

            RVP0050B.Write(REG_VP0050B.GetMoveValues().ToString());

            /*" -786- WRITE REG-VP0050B FROM LC05 AFTER 1 */
            _.Move(AREA_DE_WORK.LC05.GetMoveValues(), REG_VP0050B);

            RVP0050B.Write(REG_VP0050B.GetMoveValues().ToString());

            /*" -787- WRITE REG-VP0050B FROM LC01 AFTER 1 */
            _.Move(AREA_DE_WORK.LC01.GetMoveValues(), REG_VP0050B);

            RVP0050B.Write(REG_VP0050B.GetMoveValues().ToString());

            /*" -789- WRITE REG-VP0050B FROM LC06 AFTER 2. */
            _.Move(AREA_DE_WORK.LC06.GetMoveValues(), REG_VP0050B);

            RVP0050B.Write(REG_VP0050B.GetMoveValues().ToString());

            /*" -790- MOVE SPACES TO REG-VP0050B. */
            _.Move("", REG_VP0050B);

            /*" -792- WRITE REG-VP0050B. */
            RVP0050B.Write(REG_VP0050B.GetMoveValues().ToString());

            /*" -792- MOVE 9 TO AC-LINHAS. */
            _.Move(9, AREA_DE_WORK.AC_LINHAS);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R5000-00-PROC-ESTRUTURA-MULT-SECTION */
        private void R5000_00_PROC_ESTRUTURA_MULT_SECTION()
        {
            /*" -806- MOVE '5000' TO WNR-EXEC-SQL. */
            _.Move("5000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -808- PERFORM R5001-00-DECLER-V0SEGURAVG. */

            R5001_00_DECLER_V0SEGURAVG_SECTION();

            /*" -810- MOVE SPACES TO WFIM-V0SEGURAVG. */
            _.Move("", AREA_DE_WORK.WFIM_V0SEGURAVG);

            /*" -811- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -812- PERFORM R5002-00-FETCH-V0SEGURAVG */

                R5002_00_FETCH_V0SEGURAVG_SECTION();

                /*" -813- PERFORM R5003-00-CERTIFICADOS UNTIL WFIM-V0SEGURAVG NOT EQUAL SPACES. */

                while (!(!AREA_DE_WORK.WFIM_V0SEGURAVG.IsEmpty()))
                {

                    R5003_00_CERTIFICADOS_SECTION();
                }
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_99_SAIDA*/

        [StopWatch]
        /*" R5001-00-DECLER-V0SEGURAVG-SECTION */
        private void R5001_00_DECLER_V0SEGURAVG_SECTION()
        {
            /*" -825- MOVE '5001' TO WNR-EXEC-SQL. */
            _.Move("5001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -833- PERFORM R5001_00_DECLER_V0SEGURAVG_DB_DECLARE_1 */

            R5001_00_DECLER_V0SEGURAVG_DB_DECLARE_1();

            /*" -835- PERFORM R5001_00_DECLER_V0SEGURAVG_DB_OPEN_1 */

            R5001_00_DECLER_V0SEGURAVG_DB_OPEN_1();

        }

        [StopWatch]
        /*" R5001-00-DECLER-V0SEGURAVG-DB-OPEN-1 */
        public void R5001_00_DECLER_V0SEGURAVG_DB_OPEN_1()
        {
            /*" -835- EXEC SQL OPEN V0SEGURAVG END-EXEC. */

            V0SEGURAVG.Open();

        }

        [StopWatch]
        /*" R5004-00-DECLER-V0HISTCOBVA-DB-DECLARE-1 */
        public void R5004_00_DECLER_V0HISTCOBVA_DB_DECLARE_1()
        {
            /*" -900- EXEC SQL DECLARE V0HISTCOBVA CURSOR FOR SELECT NRPARCEL, DTVENCTO, SITUACAO, VLPRMTOT FROM SEGUROS.V0HISTCOBVA WHERE NRCERTIF = :V0SEGV-NRCERTIF AND DTVENCTO >= :V1RELA-DATA-REFER ORDER BY NRPARCEL, DTVENCTO END-EXEC. */
            V0HISTCOBVA = new VP0050B_V0HISTCOBVA(true);
            string GetQuery_V0HISTCOBVA()
            {
                var query = @$"SELECT NRPARCEL
							, 
							DTVENCTO
							, 
							SITUACAO
							, 
							VLPRMTOT 
							FROM SEGUROS.V0HISTCOBVA 
							WHERE NRCERTIF = '{V0SEGV_NRCERTIF}' 
							AND DTVENCTO >= '{V1RELA_DATA_REFER}' 
							ORDER BY NRPARCEL
							, DTVENCTO";

                return query;
            }
            V0HISTCOBVA.GetQueryEvent += GetQuery_V0HISTCOBVA;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5001_99_SAIDA*/

        [StopWatch]
        /*" R5002-00-FETCH-V0SEGURAVG-SECTION */
        private void R5002_00_FETCH_V0SEGURAVG_SECTION()
        {
            /*" -847- MOVE '5002' TO WNR-EXEC-SQL. */
            _.Move("5002", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -850- PERFORM R5002_00_FETCH_V0SEGURAVG_DB_FETCH_1 */

            R5002_00_FETCH_V0SEGURAVG_DB_FETCH_1();

            /*" -853- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -854- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -855- MOVE 'FIM' TO WFIM-V0SEGURAVG */
                    _.Move("FIM", AREA_DE_WORK.WFIM_V0SEGURAVG);

                    /*" -855- PERFORM R5002_00_FETCH_V0SEGURAVG_DB_CLOSE_1 */

                    R5002_00_FETCH_V0SEGURAVG_DB_CLOSE_1();

                    /*" -857- ELSE */
                }
                else
                {


                    /*" -858- DISPLAY 'VP0050B - ERRO FETCH V0SEGURAVG....  ' SQLCODE */
                    _.Display($"VP0050B - ERRO FETCH V0SEGURAVG....  {DB.SQLCODE}");

                    /*" -858- PERFORM R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R5002-00-FETCH-V0SEGURAVG-DB-FETCH-1 */
        public void R5002_00_FETCH_V0SEGURAVG_DB_FETCH_1()
        {
            /*" -850- EXEC SQL FETCH V0SEGURAVG INTO :V0SEGV-NRCERTIF, :V0SEGV-CODCLIEN END-EXEC. */

            if (V0SEGURAVG.Fetch())
            {
                _.Move(V0SEGURAVG.V0SEGV_NRCERTIF, V0SEGV_NRCERTIF);
                _.Move(V0SEGURAVG.V0SEGV_CODCLIEN, V0SEGV_CODCLIEN);
            }

        }

        [StopWatch]
        /*" R5002-00-FETCH-V0SEGURAVG-DB-CLOSE-1 */
        public void R5002_00_FETCH_V0SEGURAVG_DB_CLOSE_1()
        {
            /*" -855- EXEC SQL CLOSE V0SEGURAVG END-EXEC */

            V0SEGURAVG.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5002_99_SAIDA*/

        [StopWatch]
        /*" R5003-00-CERTIFICADOS-SECTION */
        private void R5003_00_CERTIFICADOS_SECTION()
        {
            /*" -870- MOVE '5003' TO WNR-EXEC-SQL. */
            _.Move("5003", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -872- PERFORM R5004-00-DECLER-V0HISTCOBVA. */

            R5004_00_DECLER_V0HISTCOBVA_SECTION();

            /*" -874- MOVE SPACES TO WFIM-V0HISTCOBVA */
            _.Move("", AREA_DE_WORK.WFIM_V0HISTCOBVA);

            /*" -875- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -878- PERFORM R5005-00-LER-PARCELAS UNTIL WFIM-V0HISTCOBVA NOT EQUAL SPACES. */

                while (!(!AREA_DE_WORK.WFIM_V0HISTCOBVA.IsEmpty()))
                {

                    R5005_00_LER_PARCELAS_SECTION();
                }
            }


            /*" -878- PERFORM R5002-00-FETCH-V0SEGURAVG. */

            R5002_00_FETCH_V0SEGURAVG_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5003_99_SAIDA*/

        [StopWatch]
        /*" R5004-00-DECLER-V0HISTCOBVA-SECTION */
        private void R5004_00_DECLER_V0HISTCOBVA_SECTION()
        {
            /*" -890- MOVE '5004' TO WNR-EXEC-SQL. */
            _.Move("5004", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -900- PERFORM R5004_00_DECLER_V0HISTCOBVA_DB_DECLARE_1 */

            R5004_00_DECLER_V0HISTCOBVA_DB_DECLARE_1();

            /*" -902- PERFORM R5004_00_DECLER_V0HISTCOBVA_DB_OPEN_1 */

            R5004_00_DECLER_V0HISTCOBVA_DB_OPEN_1();

        }

        [StopWatch]
        /*" R5004-00-DECLER-V0HISTCOBVA-DB-OPEN-1 */
        public void R5004_00_DECLER_V0HISTCOBVA_DB_OPEN_1()
        {
            /*" -902- EXEC SQL OPEN V0HISTCOBVA END-EXEC. */

            V0HISTCOBVA.Open();

        }

        [StopWatch]
        /*" R6001-00-DECLER-V0AVERBCEF-DB-DECLARE-1 */
        public void R6001_00_DECLER_V0AVERBCEF_DB_DECLARE_1()
        {
            /*" -1053- EXEC SQL DECLARE V0AVERBCEF CURSOR FOR SELECT NUM_MATRICULA, VALOR_AVERBACAO, TPMOVTO FROM SEGUROS.V0AVERBCEF WHERE NUM_MATRICULA = :V0FUNC-NRMATRIC AND SITUACAO = '4' AND DATA_REFERENCIA = :V1RELA-DATA-REFER ORDER BY TPMOVTO END-EXEC. */
            V0AVERBCEF = new VP0050B_V0AVERBCEF(true);
            string GetQuery_V0AVERBCEF()
            {
                var query = @$"SELECT NUM_MATRICULA
							, 
							VALOR_AVERBACAO
							, 
							TPMOVTO 
							FROM SEGUROS.V0AVERBCEF 
							WHERE NUM_MATRICULA = '{V0FUNC_NRMATRIC}' 
							AND SITUACAO = '4' 
							AND DATA_REFERENCIA = '{V1RELA_DATA_REFER}' 
							ORDER BY TPMOVTO";

                return query;
            }
            V0AVERBCEF.GetQueryEvent += GetQuery_V0AVERBCEF;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5004_99_SAIDA*/

        [StopWatch]
        /*" R5005-00-LER-PARCELAS-SECTION */
        private void R5005_00_LER_PARCELAS_SECTION()
        {
            /*" -914- MOVE '5005' TO WNR-EXEC-SQL. */
            _.Move("5005", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -919- PERFORM R5005_00_LER_PARCELAS_DB_FETCH_1 */

            R5005_00_LER_PARCELAS_DB_FETCH_1();

            /*" -923- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -924- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -925- MOVE 'SIM' TO WFIM-V0HISTCOBVA */
                    _.Move("SIM", AREA_DE_WORK.WFIM_V0HISTCOBVA);

                    /*" -925- PERFORM R5005_00_LER_PARCELAS_DB_CLOSE_1 */

                    R5005_00_LER_PARCELAS_DB_CLOSE_1();

                    /*" -927- ELSE */
                }
                else
                {


                    /*" -928- DISPLAY 'VP0050B - ERRO FETCH V0HISTCOBVA' */
                    _.Display($"VP0050B - ERRO FETCH V0HISTCOBVA");

                    /*" -929- DISPLAY '          CERTIFICADO......  ' V0SEGV-NRCERTIF */
                    _.Display($"          CERTIFICADO......  {V0SEGV_NRCERTIF}");

                    /*" -930- DISPLAY '          SQLCODE..........  ' SQLCODE */
                    _.Display($"          SQLCODE..........  {DB.SQLCODE}");

                    /*" -931- PERFORM R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION();

                    /*" -932- ELSE */
                }

            }
            else
            {


                /*" -933- MOVE V0HIST-DTVENCTO TO WDTVENCTO */
                _.Move(V0HIST_DTVENCTO, AREA_DE_WORK.WDTVENCTO);

                /*" -935- IF WDTVENCTO-ANO EQUAL V1RELA-ANO-REFER AND WDTVENCTO-MES EQUAL V1RELA-MES-REFER */

                if (AREA_DE_WORK.FILLER_9.WDTVENCTO_ANO == V1RELA_ANO_REFER && AREA_DE_WORK.FILLER_9.WDTVENCTO_MES == V1RELA_MES_REFER)
                {

                    /*" -936- MOVE 'SIM' TO WS-MULTIPREMIADO */
                    _.Move("SIM", AREA_DE_WORK.WS_MULTIPREMIADO);

                    /*" -936- PERFORM R5010-00-NOVA-ESTRUTURA. */

                    R5010_00_NOVA_ESTRUTURA_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R5005-00-LER-PARCELAS-DB-FETCH-1 */
        public void R5005_00_LER_PARCELAS_DB_FETCH_1()
        {
            /*" -919- EXEC SQL FETCH V0HISTCOBVA INTO :V0HIST-NRPARCEL, :V0HIST-DTVENCTO, :V0HIST-SITUACAO, :V0HIST-VLPRMTOT END-EXEC. */

            if (V0HISTCOBVA.Fetch())
            {
                _.Move(V0HISTCOBVA.V0HIST_NRPARCEL, V0HIST_NRPARCEL);
                _.Move(V0HISTCOBVA.V0HIST_DTVENCTO, V0HIST_DTVENCTO);
                _.Move(V0HISTCOBVA.V0HIST_SITUACAO, V0HIST_SITUACAO);
                _.Move(V0HISTCOBVA.V0HIST_VLPRMTOT, V0HIST_VLPRMTOT);
            }

        }

        [StopWatch]
        /*" R5005-00-LER-PARCELAS-DB-CLOSE-1 */
        public void R5005_00_LER_PARCELAS_DB_CLOSE_1()
        {
            /*" -925- EXEC SQL CLOSE V0HISTCOBVA END-EXEC */

            V0HISTCOBVA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5005_99_SAIDA*/

        [StopWatch]
        /*" R5010-00-NOVA-ESTRUTURA-SECTION */
        private void R5010_00_NOVA_ESTRUTURA_SECTION()
        {
            /*" -948- MOVE '5010' TO WNR-EXEC-SQL. */
            _.Move("5010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -949- IF V0FUNC-COD-SUREG NOT = WS-SUREG-ANT */

            if (V0FUNC_COD_SUREG != AREA_DE_WORK.WS_SUREG_ANT)
            {

                /*" -951- PERFORM R1200-00-QUEBRA-SUREG THRU R1200-00-FIM. */

                R1200_00_QUEBRA_SUREG_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_00_FIM*/

            }


            /*" -952- IF V0HIST-SITUACAO = '1' */

            if (V0HIST_SITUACAO == "1")
            {

                /*" -954- ADD V0HIST-VLPRMTOT TO WS-VAL-AVERB-SUR WS-VAL-AVERB-GER */
                AREA_DE_WORK.WS_VAL_AVERB_SUR.Value = AREA_DE_WORK.WS_VAL_AVERB_SUR + V0HIST_VLPRMTOT;
                AREA_DE_WORK.WS_VAL_AVERB_GER.Value = AREA_DE_WORK.WS_VAL_AVERB_GER + V0HIST_VLPRMTOT;

                /*" -955- ELSE */
            }
            else
            {


                /*" -956- SUBTRACT V0HIST-VLPRMTOT FROM WS-VAL-AVERB-SUR */
                AREA_DE_WORK.WS_VAL_AVERB_SUR.Value = AREA_DE_WORK.WS_VAL_AVERB_SUR - V0HIST_VLPRMTOT;

                /*" -958- SUBTRACT V0HIST-VLPRMTOT FROM WS-VAL-AVERB-GER. */
                AREA_DE_WORK.WS_VAL_AVERB_GER.Value = AREA_DE_WORK.WS_VAL_AVERB_GER - V0HIST_VLPRMTOT;
            }


            /*" -959- IF V0HIST-SITUACAO = '1' */

            if (V0HIST_SITUACAO == "1")
            {

                /*" -960- PERFORM R5020-00-SELECT-V0COBERPROPVA */

                R5020_00_SELECT_V0COBERPROPVA_SECTION();

                /*" -961- ADD 1 TO WS-TOT-VIDAS-SUR WS-TOT-VIDAS-GER. */
                AREA_DE_WORK.WS_TOT_VIDAS_SUR.Value = AREA_DE_WORK.WS_TOT_VIDAS_SUR + 1;
                AREA_DE_WORK.WS_TOT_VIDAS_GER.Value = AREA_DE_WORK.WS_TOT_VIDAS_GER + 1;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5010_99_SAIDA*/

        [StopWatch]
        /*" R5020-00-SELECT-V0COBERPROPVA-SECTION */
        private void R5020_00_SELECT_V0COBERPROPVA_SECTION()
        {
            /*" -974- IF V0FUNC-NRMATRIC NOT EQUAL WHOST-NRMATRIC-ANT */

            if (V0FUNC_NRMATRIC != WHOST_NRMATRIC_ANT)
            {

                /*" -975- MOVE V0FUNC-NRMATRIC TO WHOST-NRMATRIC-ANT */
                _.Move(V0FUNC_NRMATRIC, WHOST_NRMATRIC_ANT);

                /*" -976- ELSE */
            }
            else
            {


                /*" -978- GO TO R5020-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R5020_99_SAIDA*/ //GOTO
                return;
            }


            /*" -980- MOVE '5020' TO WNR-EXEC-SQL */
            _.Move("5020", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -987- PERFORM R5020_00_SELECT_V0COBERPROPVA_DB_SELECT_1 */

            R5020_00_SELECT_V0COBERPROPVA_DB_SELECT_1();

            /*" -990- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -992- IF SQLCODE = 100 OR -811 NEXT SENTENCE */

                if (DB.SQLCODE.In("100", "-811"))
                {

                    /*" -993- ELSE */
                }
                else
                {


                    /*" -994- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -995- ELSE */
                }

            }
            else
            {


                /*" -996- IF V0COBP-VLTITCAP > 0 */

                if (V0COBP_VLTITCAP > 0)
                {

                    /*" -997- ADD 1 TO WS-TOT-PREMI-GER */
                    AREA_DE_WORK.WS_TOT_PREMI_GER.Value = AREA_DE_WORK.WS_TOT_PREMI_GER + 1;

                    /*" -997- ADD V0COBP-VLTITCAP TO WS-VAL-PREMI-GER. */
                    AREA_DE_WORK.WS_VAL_PREMI_GER.Value = AREA_DE_WORK.WS_VAL_PREMI_GER + V0COBP_VLTITCAP;
                }

            }


        }

        [StopWatch]
        /*" R5020-00-SELECT-V0COBERPROPVA-DB-SELECT-1 */
        public void R5020_00_SELECT_V0COBERPROPVA_DB_SELECT_1()
        {
            /*" -987- EXEC SQL SELECT VLTITCAP INTO :V0COBP-VLTITCAP FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :V0SEGV-NRCERTIF AND DTINIVIG <= :V1RELA-DATA-REFER AND DTTERVIG >= :V1RELA-DATA-REFER END-EXEC */

            var r5020_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1 = new R5020_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1()
            {
                V1RELA_DATA_REFER = V1RELA_DATA_REFER.ToString(),
                V0SEGV_NRCERTIF = V0SEGV_NRCERTIF.ToString(),
            };

            var executed_1 = R5020_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1.Execute(r5020_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBP_VLTITCAP, V0COBP_VLTITCAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5020_99_SAIDA*/

        [StopWatch]
        /*" R6000-00-ESTRUTURA-ANTIGA-SECTION */
        private void R6000_00_ESTRUTURA_ANTIGA_SECTION()
        {
            /*" -1013- MOVE '6000' TO WNR-EXEC-SQL. */
            _.Move("6000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1015- PERFORM R6001-00-DECLER-V0AVERBCEF. */

            R6001_00_DECLER_V0AVERBCEF_SECTION();

            /*" -1017- MOVE SPACES TO WFIM-V0AVERBCEF. */
            _.Move("", AREA_DE_WORK.WFIM_V0AVERBCEF);

            /*" -1018- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -1020- PERFORM R6010-00-LER-V0AVERBCEF */

                R6010_00_LER_V0AVERBCEF_SECTION();

                /*" -1021- IF SQLCODE EQUAL 00 */

                if (DB.SQLCODE == 00)
                {

                    /*" -1023- PERFORM R6020-00-PROCESSA-V0AVERBCEF UNTIL WFIM-V0AVERBCEF NOT EQUAL SPACES */

                    while (!(!AREA_DE_WORK.WFIM_V0AVERBCEF.IsEmpty()))
                    {

                        R6020_00_PROCESSA_V0AVERBCEF_SECTION();
                    }

                    /*" -1024- ELSE */
                }
                else
                {


                    /*" -1025- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -1026- ADD 1 TO AC-SEG-NAO-EXISTE */
                        AREA_DE_WORK.AC_SEG_NAO_EXISTE.Value = AREA_DE_WORK.AC_SEG_NAO_EXISTE + 1;

                        /*" -1027- ELSE */
                    }
                    else
                    {


                        /*" -1028- DISPLAY 'VP0050B - ERRO ACESSO V0AVERBCEF' */
                        _.Display($"VP0050B - ERRO ACESSO V0AVERBCEF");

                        /*" -1029- DISPLAY '          MATRICULA..  ' V0FUNC-NRMATRIC */
                        _.Display($"          MATRICULA..  {V0FUNC_NRMATRIC}");

                        /*" -1030- DISPLAY '          SQLCODE....  ' SQLCODE */
                        _.Display($"          SQLCODE....  {DB.SQLCODE}");

                        /*" -1030- PERFORM R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION();
                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6000_99_SAIDA*/

        [StopWatch]
        /*" R6001-00-DECLER-V0AVERBCEF-SECTION */
        private void R6001_00_DECLER_V0AVERBCEF_SECTION()
        {
            /*" -1042- MOVE '6001' TO WNR-EXEC-SQL. */
            _.Move("6001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1053- PERFORM R6001_00_DECLER_V0AVERBCEF_DB_DECLARE_1 */

            R6001_00_DECLER_V0AVERBCEF_DB_DECLARE_1();

            /*" -1055- PERFORM R6001_00_DECLER_V0AVERBCEF_DB_OPEN_1 */

            R6001_00_DECLER_V0AVERBCEF_DB_OPEN_1();

        }

        [StopWatch]
        /*" R6001-00-DECLER-V0AVERBCEF-DB-OPEN-1 */
        public void R6001_00_DECLER_V0AVERBCEF_DB_OPEN_1()
        {
            /*" -1055- EXEC SQL OPEN V0AVERBCEF END-EXEC. */

            V0AVERBCEF.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6001_99_SAIDA*/

        [StopWatch]
        /*" R6010-00-LER-V0AVERBCEF-SECTION */
        private void R6010_00_LER_V0AVERBCEF_SECTION()
        {
            /*" -1067- MOVE '6010' TO WNR-EXEC-SQL. */
            _.Move("6010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1071- PERFORM R6010_00_LER_V0AVERBCEF_DB_FETCH_1 */

            R6010_00_LER_V0AVERBCEF_DB_FETCH_1();

            /*" -1074- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1075- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1076- MOVE 'FIM' TO WFIM-V0AVERBCEF */
                    _.Move("FIM", AREA_DE_WORK.WFIM_V0AVERBCEF);

                    /*" -1076- PERFORM R6010_00_LER_V0AVERBCEF_DB_CLOSE_1 */

                    R6010_00_LER_V0AVERBCEF_DB_CLOSE_1();

                    /*" -1078- ELSE */
                }
                else
                {


                    /*" -1079- DISPLAY 'VP0050B - ERRO FETCH V0AVERBCEF....  ' SQLCODE */
                    _.Display($"VP0050B - ERRO FETCH V0AVERBCEF....  {DB.SQLCODE}");

                    /*" -1079- PERFORM R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R6010-00-LER-V0AVERBCEF-DB-FETCH-1 */
        public void R6010_00_LER_V0AVERBCEF_DB_FETCH_1()
        {
            /*" -1071- EXEC SQL FETCH V0AVERBCEF INTO :V0AVER-NRMATRIC, :V0AVER-VAL-AVERB, :V0AVER-TPMOVTO END-EXEC. */

            if (V0AVERBCEF.Fetch())
            {
                _.Move(V0AVERBCEF.V0AVER_NRMATRIC, V0AVER_NRMATRIC);
                _.Move(V0AVERBCEF.V0AVER_VAL_AVERB, V0AVER_VAL_AVERB);
                _.Move(V0AVERBCEF.V0AVER_TPMOVTO, V0AVER_TPMOVTO);
            }

        }

        [StopWatch]
        /*" R6010-00-LER-V0AVERBCEF-DB-CLOSE-1 */
        public void R6010_00_LER_V0AVERBCEF_DB_CLOSE_1()
        {
            /*" -1076- EXEC SQL CLOSE V0AVERBCEF END-EXEC */

            V0AVERBCEF.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6010_99_SAIDA*/

        [StopWatch]
        /*" R6020-00-PROCESSA-V0AVERBCEF-SECTION */
        private void R6020_00_PROCESSA_V0AVERBCEF_SECTION()
        {
            /*" -1091- MOVE '6020' TO WNR-EXEC-SQL. */
            _.Move("6020", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1092- IF V0FUNC-COD-SUREG NOT = WS-SUREG-ANT */

            if (V0FUNC_COD_SUREG != AREA_DE_WORK.WS_SUREG_ANT)
            {

                /*" -1094- PERFORM R1200-00-QUEBRA-SUREG THRU R1200-00-FIM. */

                R1200_00_QUEBRA_SUREG_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_00_FIM*/

            }


            /*" -1095- IF V0AVER-TPMOVTO = '3' OR '4' */

            if (V0AVER_TPMOVTO.In("3", "4"))
            {

                /*" -1097- ADD V0AVER-VAL-AVERB TO WS-VAL-AVERB-SUR WS-VAL-AVERB-GER */
                AREA_DE_WORK.WS_VAL_AVERB_SUR.Value = AREA_DE_WORK.WS_VAL_AVERB_SUR + V0AVER_VAL_AVERB;
                AREA_DE_WORK.WS_VAL_AVERB_GER.Value = AREA_DE_WORK.WS_VAL_AVERB_GER + V0AVER_VAL_AVERB;

                /*" -1098- ELSE */
            }
            else
            {


                /*" -1099- SUBTRACT V0AVER-VAL-AVERB FROM WS-VAL-AVERB-SUR */
                AREA_DE_WORK.WS_VAL_AVERB_SUR.Value = AREA_DE_WORK.WS_VAL_AVERB_SUR - V0AVER_VAL_AVERB;

                /*" -1101- SUBTRACT V0AVER-VAL-AVERB FROM WS-VAL-AVERB-GER. */
                AREA_DE_WORK.WS_VAL_AVERB_GER.Value = AREA_DE_WORK.WS_VAL_AVERB_GER - V0AVER_VAL_AVERB;
            }


            /*" -1102- IF V0AVER-TPMOVTO = '4' */

            if (V0AVER_TPMOVTO == "4")
            {

                /*" -1103- PERFORM R6030-00-SELECT-COBERTURAS */

                R6030_00_SELECT_COBERTURAS_SECTION();

                /*" -1106- ADD 1 TO WS-TOT-VIDAS-SUR WS-TOT-VIDAS-GER. */
                AREA_DE_WORK.WS_TOT_VIDAS_SUR.Value = AREA_DE_WORK.WS_TOT_VIDAS_SUR + 1;
                AREA_DE_WORK.WS_TOT_VIDAS_GER.Value = AREA_DE_WORK.WS_TOT_VIDAS_GER + 1;
            }


            /*" -1106- PERFORM R6010-00-LER-V0AVERBCEF. */

            R6010_00_LER_V0AVERBCEF_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6020_99_SAIDA*/

        [StopWatch]
        /*" R6030-00-SELECT-COBERTURAS-SECTION */
        private void R6030_00_SELECT_COBERTURAS_SECTION()
        {
            /*" -1120- MOVE '6030A' TO WNR-EXEC-SQL */
            _.Move("6030A", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1121- IF V0AVER-NRMATRIC NOT EQUAL WHOST-NRMATRIC-ANT */

            if (V0AVER_NRMATRIC != WHOST_NRMATRIC_ANT)
            {

                /*" -1122- MOVE V0AVER-NRMATRIC TO WHOST-NRMATRIC-ANT */
                _.Move(V0AVER_NRMATRIC, WHOST_NRMATRIC_ANT);

                /*" -1123- ELSE */
            }
            else
            {


                /*" -1128- GO TO R6030-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R6030_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1138- PERFORM R6030_00_SELECT_COBERTURAS_DB_SELECT_1 */

            R6030_00_SELECT_COBERTURAS_DB_SELECT_1();

            /*" -1141- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1143- IF SQLCODE = 100 OR -811 NEXT SENTENCE */

                if (DB.SQLCODE.In("100", "-811"))
                {

                    /*" -1144- ELSE */
                }
                else
                {


                    /*" -1145- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1146- ELSE */
                }

            }
            else
            {


                /*" -1147- MOVE '6030B' TO WNR-EXEC-SQL */
                _.Move("6030B", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -1154- PERFORM R6030_00_SELECT_COBERTURAS_DB_SELECT_2 */

                R6030_00_SELECT_COBERTURAS_DB_SELECT_2();

                /*" -1156- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1158- IF SQLCODE = 100 OR -811 NEXT SENTENCE */

                    if (DB.SQLCODE.In("100", "-811"))
                    {

                        /*" -1159- ELSE */
                    }
                    else
                    {


                        /*" -1160- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -1161- ELSE */
                    }

                }
                else
                {


                    /*" -1162- IF V0COBP-VLTITCAP > 0 */

                    if (V0COBP_VLTITCAP > 0)
                    {

                        /*" -1163- ADD 1 TO WS-TOT-PREMI-GER */
                        AREA_DE_WORK.WS_TOT_PREMI_GER.Value = AREA_DE_WORK.WS_TOT_PREMI_GER + 1;

                        /*" -1163- ADD V0COBP-VLTITCAP TO WS-VAL-PREMI-GER. */
                        AREA_DE_WORK.WS_VAL_PREMI_GER.Value = AREA_DE_WORK.WS_VAL_PREMI_GER + V0COBP_VLTITCAP;
                    }

                }

            }


        }

        [StopWatch]
        /*" R6030-00-SELECT-COBERTURAS-DB-SELECT-1 */
        public void R6030_00_SELECT_COBERTURAS_DB_SELECT_1()
        {
            /*" -1138- EXEC SQL SELECT NUM_CERTIFICADO, COD_CLIENTE INTO :V0SEGV-NRCERTIF, :V0SEGV-CODCLIEN FROM SEGUROS.V0SEGURAVG WHERE NUM_MATRICULA = :V0AVER-NRMATRIC AND NUM_APOLICE = 93010000890 AND COD_SUBGRUPO = 1 AND SIT_REGISTRO IN ( '0' , '1' ) END-EXEC */

            var r6030_00_SELECT_COBERTURAS_DB_SELECT_1_Query1 = new R6030_00_SELECT_COBERTURAS_DB_SELECT_1_Query1()
            {
                V0AVER_NRMATRIC = V0AVER_NRMATRIC.ToString(),
            };

            var executed_1 = R6030_00_SELECT_COBERTURAS_DB_SELECT_1_Query1.Execute(r6030_00_SELECT_COBERTURAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SEGV_NRCERTIF, V0SEGV_NRCERTIF);
                _.Move(executed_1.V0SEGV_CODCLIEN, V0SEGV_CODCLIEN);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6030_99_SAIDA*/

        [StopWatch]
        /*" R6030-00-SELECT-COBERTURAS-DB-SELECT-2 */
        public void R6030_00_SELECT_COBERTURAS_DB_SELECT_2()
        {
            /*" -1154- EXEC SQL SELECT VLTITCAP INTO :V0COBP-VLTITCAP FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :V0SEGV-NRCERTIF AND DTINIVIG <= :V1RELA-DATA-REFER AND DTTERVIG >= :V1RELA-DATA-REFER END-EXEC */

            var r6030_00_SELECT_COBERTURAS_DB_SELECT_2_Query1 = new R6030_00_SELECT_COBERTURAS_DB_SELECT_2_Query1()
            {
                V1RELA_DATA_REFER = V1RELA_DATA_REFER.ToString(),
                V0SEGV_NRCERTIF = V0SEGV_NRCERTIF.ToString(),
            };

            var executed_1 = R6030_00_SELECT_COBERTURAS_DB_SELECT_2_Query1.Execute(r6030_00_SELECT_COBERTURAS_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBP_VLTITCAP, V0COBP_VLTITCAP);
            }


        }

        [StopWatch]
        /*" R8000-00-OPEN-ARQUIVOS-SECTION */
        private void R8000_00_OPEN_ARQUIVOS_SECTION()
        {
            /*" -1178- OPEN OUTPUT RVP0050B. */
            RVP0050B.Open(REG_VP0050B);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-CLOSE-ARQUIVOS-SECTION */
        private void R9000_00_CLOSE_ARQUIVOS_SECTION()
        {
            /*" -1192- CLOSE RVP0050B. */
            RVP0050B.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9100-00-INSERT-V0RELATORIO-SECTION */
        private void R9100_00_INSERT_V0RELATORIO_SECTION()
        {
            /*" -1204- MOVE 'R9100A' TO WNR-EXEC-SQL. */
            _.Move("R9100A", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1247- PERFORM R9100_00_INSERT_V0RELATORIO_DB_INSERT_1 */

            R9100_00_INSERT_V0RELATORIO_DB_INSERT_1();

            /*" -1250- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1251- DISPLAY 'VP0050B - ERRO INSERT VA0421B....  ' SQLCODE */
                _.Display($"VP0050B - ERRO INSERT VA0421B....  {DB.SQLCODE}");

                /*" -1253- PERFORM R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION();
            }


            /*" -1255- MOVE 'R9100B' TO WNR-EXEC-SQL. */
            _.Move("R9100B", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1298- PERFORM R9100_00_INSERT_V0RELATORIO_DB_INSERT_2 */

            R9100_00_INSERT_V0RELATORIO_DB_INSERT_2();

            /*" -1301- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1302- DISPLAY 'VP0050B - ERRO INSERT VA0419B....  ' SQLCODE */
                _.Display($"VP0050B - ERRO INSERT VA0419B....  {DB.SQLCODE}");

                /*" -1305- PERFORM R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION();
            }


            /*" -1307- MOVE 'R9100C' TO WNR-EXEC-SQL. */
            _.Move("R9100C", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1350- PERFORM R9100_00_INSERT_V0RELATORIO_DB_INSERT_3 */

            R9100_00_INSERT_V0RELATORIO_DB_INSERT_3();

            /*" -1354- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1355- DISPLAY 'VP0050B - ERRO INSERT VA1421B....  ' SQLCODE */
                _.Display($"VP0050B - ERRO INSERT VA1421B....  {DB.SQLCODE}");

                /*" -1357- PERFORM R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION();
            }


            /*" -1359- MOVE 'R9100D' TO WNR-EXEC-SQL. */
            _.Move("R9100D", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1402- PERFORM R9100_00_INSERT_V0RELATORIO_DB_INSERT_4 */

            R9100_00_INSERT_V0RELATORIO_DB_INSERT_4();

            /*" -1406- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1407- DISPLAY 'VP0050B - ERRO INSERT VA1419B....  ' SQLCODE */
                _.Display($"VP0050B - ERRO INSERT VA1419B....  {DB.SQLCODE}");

                /*" -1409- PERFORM R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION();
            }


            /*" -1411- MOVE 'R9100E' TO WNR-EXEC-SQL. */
            _.Move("R9100E", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1454- PERFORM R9100_00_INSERT_V0RELATORIO_DB_INSERT_5 */

            R9100_00_INSERT_V0RELATORIO_DB_INSERT_5();

            /*" -1458- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1459- DISPLAY 'VP0050B - ERRO INSERT VA2421B....  ' SQLCODE */
                _.Display($"VP0050B - ERRO INSERT VA2421B....  {DB.SQLCODE}");

                /*" -1461- PERFORM R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION();
            }


            /*" -1463- MOVE 'R9100F' TO WNR-EXEC-SQL. */
            _.Move("R9100F", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1506- PERFORM R9100_00_INSERT_V0RELATORIO_DB_INSERT_6 */

            R9100_00_INSERT_V0RELATORIO_DB_INSERT_6();

            /*" -1510- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1511- DISPLAY 'VP0050B - ERRO INSERT VA2419B....  ' SQLCODE */
                _.Display($"VP0050B - ERRO INSERT VA2419B....  {DB.SQLCODE}");

                /*" -1513- PERFORM R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION();
            }


            /*" -1515- MOVE 'R9100G' TO WNR-EXEC-SQL. */
            _.Move("R9100G", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1558- PERFORM R9100_00_INSERT_V0RELATORIO_DB_INSERT_7 */

            R9100_00_INSERT_V0RELATORIO_DB_INSERT_7();

            /*" -1561- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1562- DISPLAY 'VP0050B - ERRO INSERT VA3419B....  ' SQLCODE */
                _.Display($"VP0050B - ERRO INSERT VA3419B....  {DB.SQLCODE}");

                /*" -1562- PERFORM R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION();
            }


        }

        [StopWatch]
        /*" R9100-00-INSERT-V0RELATORIO-DB-INSERT-1 */
        public void R9100_00_INSERT_V0RELATORIO_DB_INSERT_1()
        {
            /*" -1247- EXEC SQL INSERT INTO SEGUROS.V0RELATORIOS VALUES ( 'VP0050B' , :V1SIST-DTMOVABE, 'VP' , 'VA0421B1' , 0, 0, :V1SIST-DTMOVABE, :V1SIST-DTMOVABE, :V1SIST-DTMOVABE, :V1RELA-MES-REFER, :V1RELA-ANO-REFER, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '0' , ' ' , ' ' , 0, 0, 0, CURRENT TIMESTAMP) END-EXEC. */

            var r9100_00_INSERT_V0RELATORIO_DB_INSERT_1_Insert1 = new R9100_00_INSERT_V0RELATORIO_DB_INSERT_1_Insert1()
            {
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
                V1RELA_MES_REFER = V1RELA_MES_REFER.ToString(),
                V1RELA_ANO_REFER = V1RELA_ANO_REFER.ToString(),
            };

            R9100_00_INSERT_V0RELATORIO_DB_INSERT_1_Insert1.Execute(r9100_00_INSERT_V0RELATORIO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9100_99_SAIDA*/

        [StopWatch]
        /*" R9100-00-INSERT-V0RELATORIO-DB-INSERT-2 */
        public void R9100_00_INSERT_V0RELATORIO_DB_INSERT_2()
        {
            /*" -1298- EXEC SQL INSERT INTO SEGUROS.V0RELATORIOS VALUES ( 'VP0050B' , :V1SIST-DTMOVABE, 'VP' , 'VA0419B1' , 0, 0, :V1SIST-DTMOVABE, :V1SIST-DTMOVABE, :V1SIST-DTMOVABE, :V1RELA-MES-REFER, :V1RELA-ANO-REFER, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '0' , ' ' , ' ' , 0, 0, 0, CURRENT TIMESTAMP) END-EXEC. */

            var r9100_00_INSERT_V0RELATORIO_DB_INSERT_2_Insert1 = new R9100_00_INSERT_V0RELATORIO_DB_INSERT_2_Insert1()
            {
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
                V1RELA_MES_REFER = V1RELA_MES_REFER.ToString(),
                V1RELA_ANO_REFER = V1RELA_ANO_REFER.ToString(),
            };

            R9100_00_INSERT_V0RELATORIO_DB_INSERT_2_Insert1.Execute(r9100_00_INSERT_V0RELATORIO_DB_INSERT_2_Insert1);

        }

        [StopWatch]
        /*" R9800-00-ENCERRA-SEM-SOLIC-SECTION */
        private void R9800_00_ENCERRA_SEM_SOLIC_SECTION()
        {
            /*" -1582- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -1583- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1584- DISPLAY '*   VP0050B - TOTAL DE AVERBACOES DA       *' */
            _.Display($"*   VP0050B - TOTAL DE AVERBACOES DA       *");

            /*" -1585- DISPLAY '*   -------   RUBRICA 636 POR SUREG        *' */
            _.Display($"*   -------   RUBRICA 636 POR SUREG        *");

            /*" -1586- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1587- DISPLAY '*   NAO HOUVE SOLICITACAO PARA EMISSAO     *' */
            _.Display($"*   NAO HOUVE SOLICITACAO PARA EMISSAO     *");

            /*" -1588- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1588- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }

        [StopWatch]
        /*" R9100-00-INSERT-V0RELATORIO-DB-INSERT-3 */
        public void R9100_00_INSERT_V0RELATORIO_DB_INSERT_3()
        {
            /*" -1350- EXEC SQL INSERT INTO SEGUROS.V0RELATORIOS VALUES ( 'VP0050B' , :V1SIST-DTMOVABE, 'VP' , 'VA1421B1' , 0, 0, :V1SIST-DTMOVABE, :V1SIST-DTMOVABE, :V1SIST-DTMOVABE, :V1RELA-MES-REFER, :V1RELA-ANO-REFER, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '0' , ' ' , ' ' , 0, 0, 0, CURRENT TIMESTAMP) END-EXEC. */

            var r9100_00_INSERT_V0RELATORIO_DB_INSERT_3_Insert1 = new R9100_00_INSERT_V0RELATORIO_DB_INSERT_3_Insert1()
            {
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
                V1RELA_MES_REFER = V1RELA_MES_REFER.ToString(),
                V1RELA_ANO_REFER = V1RELA_ANO_REFER.ToString(),
            };

            R9100_00_INSERT_V0RELATORIO_DB_INSERT_3_Insert1.Execute(r9100_00_INSERT_V0RELATORIO_DB_INSERT_3_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9800_99_SAIDA*/

        [StopWatch]
        /*" R9100-00-INSERT-V0RELATORIO-DB-INSERT-4 */
        public void R9100_00_INSERT_V0RELATORIO_DB_INSERT_4()
        {
            /*" -1402- EXEC SQL INSERT INTO SEGUROS.V0RELATORIOS VALUES ( 'VP0050B' , :V1SIST-DTMOVABE, 'VP' , 'VA1419B1' , 0, 0, :V1SIST-DTMOVABE, :V1SIST-DTMOVABE, :V1SIST-DTMOVABE, :V1RELA-MES-REFER, :V1RELA-ANO-REFER, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '0' , ' ' , ' ' , 0, 0, 0, CURRENT TIMESTAMP) END-EXEC. */

            var r9100_00_INSERT_V0RELATORIO_DB_INSERT_4_Insert1 = new R9100_00_INSERT_V0RELATORIO_DB_INSERT_4_Insert1()
            {
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
                V1RELA_MES_REFER = V1RELA_MES_REFER.ToString(),
                V1RELA_ANO_REFER = V1RELA_ANO_REFER.ToString(),
            };

            R9100_00_INSERT_V0RELATORIO_DB_INSERT_4_Insert1.Execute(r9100_00_INSERT_V0RELATORIO_DB_INSERT_4_Insert1);

        }

        [StopWatch]
        /*" R9900-00-ENCERRA-SEM-MOVTO-SECTION */
        private void R9900_00_ENCERRA_SEM_MOVTO_SECTION()
        {
            /*" -1605- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -1606- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1607- DISPLAY '*   VP0050B - TOTAL DE AVERBACOES DA       *' */
            _.Display($"*   VP0050B - TOTAL DE AVERBACOES DA       *");

            /*" -1608- DISPLAY '*   -------   RUBRICA 636 POR SUREG        *' */
            _.Display($"*   -------   RUBRICA 636 POR SUREG        *");

            /*" -1609- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1610- DISPLAY '*    NAO HOUVE MOVIMENTACAO NO PERIODO     *' */
            _.Display($"*    NAO HOUVE MOVIMENTACAO NO PERIODO     *");

            /*" -1611- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1611- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }

        [StopWatch]
        /*" R9100-00-INSERT-V0RELATORIO-DB-INSERT-5 */
        public void R9100_00_INSERT_V0RELATORIO_DB_INSERT_5()
        {
            /*" -1454- EXEC SQL INSERT INTO SEGUROS.V0RELATORIOS VALUES ( 'VP0050B' , :V1SIST-DTMOVABE, 'VP' , 'VA2421B1' , 0, 0, :V1SIST-DTMOVABE, :V1SIST-DTMOVABE, :V1SIST-DTMOVABE, :V1RELA-MES-REFER, :V1RELA-ANO-REFER, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '0' , ' ' , ' ' , 0, 0, 0, CURRENT TIMESTAMP) END-EXEC. */

            var r9100_00_INSERT_V0RELATORIO_DB_INSERT_5_Insert1 = new R9100_00_INSERT_V0RELATORIO_DB_INSERT_5_Insert1()
            {
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
                V1RELA_MES_REFER = V1RELA_MES_REFER.ToString(),
                V1RELA_ANO_REFER = V1RELA_ANO_REFER.ToString(),
            };

            R9100_00_INSERT_V0RELATORIO_DB_INSERT_5_Insert1.Execute(r9100_00_INSERT_V0RELATORIO_DB_INSERT_5_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/

        [StopWatch]
        /*" R9100-00-INSERT-V0RELATORIO-DB-INSERT-6 */
        public void R9100_00_INSERT_V0RELATORIO_DB_INSERT_6()
        {
            /*" -1506- EXEC SQL INSERT INTO SEGUROS.V0RELATORIOS VALUES ( 'VP0050B' , :V1SIST-DTMOVABE, 'VP' , 'VA2419B1' , 0, 0, :V1SIST-DTMOVABE, :V1SIST-DTMOVABE, :V1SIST-DTMOVABE, :V1RELA-MES-REFER, :V1RELA-ANO-REFER, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '0' , ' ' , ' ' , 0, 0, 0, CURRENT TIMESTAMP) END-EXEC. */

            var r9100_00_INSERT_V0RELATORIO_DB_INSERT_6_Insert1 = new R9100_00_INSERT_V0RELATORIO_DB_INSERT_6_Insert1()
            {
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
                V1RELA_MES_REFER = V1RELA_MES_REFER.ToString(),
                V1RELA_ANO_REFER = V1RELA_ANO_REFER.ToString(),
            };

            R9100_00_INSERT_V0RELATORIO_DB_INSERT_6_Insert1.Execute(r9100_00_INSERT_V0RELATORIO_DB_INSERT_6_Insert1);

        }

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1629- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -1631- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -1633- CLOSE RVP0050B */
            RVP0050B.Close();

            /*" -1633- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1635- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1638- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -1638- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R9100-00-INSERT-V0RELATORIO-DB-INSERT-7 */
        public void R9100_00_INSERT_V0RELATORIO_DB_INSERT_7()
        {
            /*" -1558- EXEC SQL INSERT INTO SEGUROS.V0RELATORIOS VALUES ( 'VP0050B' , :V1SIST-DTMOVABE, 'VP' , 'VA3419B1' , 0, 0, :V1SIST-DTMOVABE, :V1SIST-DTMOVABE, :V1SIST-DTMOVABE, :V1RELA-MES-REFER, :V1RELA-ANO-REFER, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '0' , ' ' , ' ' , 0, 0, 0, CURRENT TIMESTAMP) END-EXEC. */

            var r9100_00_INSERT_V0RELATORIO_DB_INSERT_7_Insert1 = new R9100_00_INSERT_V0RELATORIO_DB_INSERT_7_Insert1()
            {
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
                V1RELA_MES_REFER = V1RELA_MES_REFER.ToString(),
                V1RELA_ANO_REFER = V1RELA_ANO_REFER.ToString(),
            };

            R9100_00_INSERT_V0RELATORIO_DB_INSERT_7_Insert1.Execute(r9100_00_INSERT_V0RELATORIO_DB_INSERT_7_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}