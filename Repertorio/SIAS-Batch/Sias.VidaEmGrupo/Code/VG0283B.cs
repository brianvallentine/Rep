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
using Sias.VidaEmGrupo.DB2.VG0283B;

namespace Code
{
    public class VG0283B
    {
        public bool IsCall { get; set; }

        public VG0283B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................ VIDA EM GRUPO                       *      */
        /*"      *   PROGRAMA ............... VG0283B                             *      */
        /*"      *   ANALISTA ............... PROCAS                              *      */
        /*"      *   PROGRAMADOR ............ PROCAS / WANGER                     *      */
        /*"      *   DATA CODIFICACAO ....... NOVEMBRO / 1994                     *      */
        /*"      *   FUNCAO ................. DEMONSTRATIVO DE EXCEDENTE TECNICO  *      */
        /*"      *                            AGENCIAMENTOS                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                             VIEW              ACESSO    *      */
        /*"      * SISTEMAS                           V1SISTEMA         INPUT     *      */
        /*"      * RELATORIOS                         V1RELATORIOS      I-O       *      */
        /*"      * COMISSOES                          V1COMISSAO        INPUT     *      */
        /*"      *                                                                *      */
        /*"      * RECONVERSAO ANO 2000            CONSEDA4           11/09/1998  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _RVG0283B { get; set; } = new FileBasis(new PIC("X", "132", "X(132)"));

        public FileBasis RVG0283B
        {
            get
            {
                _.Move(REG_VG0283B, _RVG0283B); VarBasis.RedefinePassValue(REG_VG0283B, _RVG0283B, REG_VG0283B); return _RVG0283B;
            }
        }
        /*"01                  REG-VG0283B        PIC  X(132).*/
        public StringBasis REG_VG0283B { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77         WHOST-DTINIVIG      PIC  X(010).*/
        public StringBasis WHOST_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WHOST-CODCLIEN      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis WHOST_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1SIST-DTMOVABE     PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-DTCURRENT    PIC  X(010).*/
        public StringBasis V1SIST_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0MOED-SIGLUNIM     PIC  X(006).*/
        public StringBasis V0MOED_SIGLUNIM { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
        /*"77         V1EMPR-COD-EMP      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1EMPR_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1EMPR-NOM-EMP      PIC  X(040).*/
        public StringBasis V1EMPR_NOM_EMP { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77         V1RELA-NUM-APOL     PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V1RELA_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1RELA-CODSUBES     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1RELA_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1RELA-CODUNIMO     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1RELA_CODUNIMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1RELA-CODRELAT     PIC  X(008).*/
        public StringBasis V1RELA_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V1RELA-PERI-INI     PIC  X(010).*/
        public StringBasis V1RELA_PERI_INI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1RELA-PERI-FIN     PIC  X(010).*/
        public StringBasis V1RELA_PERI_FIN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V1MOED-VLCRUZAD   PIC S9(006)V9(09)  VALUE +0 COMP-3*/
        public DoubleBasis V1MOED_VLCRUZAD { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(09)"), 9);
        /*"77         V1COMI-CODSUBES    PIC S9(004)        VALUE +0 COMP.*/
        public IntBasis V1COMI_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COMI-OPERACAO    PIC S9(004)        VALUE +0 COMP.*/
        public IntBasis V1COMI_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COMI-VLCOMIS     PIC S9(013)V99     VALUE +0 COMP-3*/
        public DoubleBasis V1COMI_VLCOMIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1COMI-TIPCOM      PIC  X(001).*/
        public StringBasis V1COMI_TIPCOM { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1COMI-DTMOVTO     PIC  X(010).*/
        public StringBasis V1COMI_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1COMI-VLVARMON    PIC S9(013)V99     VALUE +0 COMP-3*/
        public DoubleBasis V1COMI_VLVARMON { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1SUBG-CODCLIEN    PIC S9(009)        VALUE +0 COMP.*/
        public IntBasis V1SUBG_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1APOL-CODCLIEN    PIC S9(009)        VALUE +0 COMP.*/
        public IntBasis V1APOL_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1CLIE-NOME        PIC  X(040).*/
        public StringBasis V1CLIE_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"01           AREA-DE-WORK.*/
        public VG0283B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VG0283B_AREA_DE_WORK();
        public class VG0283B_AREA_DE_WORK : VarBasis
        {
            /*"  05         WSL-SQLCODE       PIC  9(009)      VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WCH-FINAL         PIC  X(001)      VALUE SPACES.*/
            public StringBasis WCH_FINAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1SISTEMA    PIC  X(001)      VALUE SPACES.*/
            public StringBasis WFIM_V1SISTEMA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1EMPRESA    PIC  X(001)      VALUE SPACES.*/
            public StringBasis WFIM_V1EMPRESA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V2COMISSAO   PIC  X(001)      VALUE SPACES.*/
            public StringBasis WFIM_V2COMISSAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1COMISSAO   PIC  X(001)      VALUE SPACES.*/
            public StringBasis WFIM_V1COMISSAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1MOEDA      PIC  X(001)      VALUE SPACES.*/
            public StringBasis WFIM_V1MOEDA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1RELATOR    PIC  X(001)      VALUE SPACES.*/
            public StringBasis WFIM_V1RELATOR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WTEM-V1COMISSAO   PIC  X(001)      VALUE SPACES.*/
            public StringBasis WTEM_V1COMISSAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WTEM-V1RELATOR    PIC  X(001)      VALUE SPACES.*/
            public StringBasis WTEM_V1RELATOR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WTEM-V2COMISSAO   PIC  X(001)      VALUE SPACES.*/
            public StringBasis WTEM_V2COMISSAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         AC-LINHAS         PIC  9(002)      VALUE  80.*/
            public IntBasis AC_LINHAS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 80);
            /*"  05         AC-PAGINA         PIC  9(004)      VALUE  ZEROS.*/
            public IntBasis AC_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         CH-CHAVE-ATU.*/
            public VG0283B_CH_CHAVE_ATU CH_CHAVE_ATU { get; set; } = new VG0283B_CH_CHAVE_ATU();
            public class VG0283B_CH_CHAVE_ATU : VarBasis
            {
                /*"    10       CH-CODSB-ATU      PIC  9(004)      VALUE  ZEROS.*/
                public IntBasis CH_CODSB_ATU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10       CH-VIGEN-ATU      PIC  X(010)      VALUE  ZEROS.*/
                public StringBasis CH_VIGEN_ATU { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  05         CH-CHAVE-ANT.*/
            }
            public VG0283B_CH_CHAVE_ANT CH_CHAVE_ANT { get; set; } = new VG0283B_CH_CHAVE_ANT();
            public class VG0283B_CH_CHAVE_ANT : VarBasis
            {
                /*"    10       CH-CODSB-ANT      PIC  9(004)      VALUE  ZEROS.*/
                public IntBasis CH_CODSB_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10       CH-VIGEN-ANT      PIC  X(010)      VALUE  ZEROS.*/
                public StringBasis CH_VIGEN_ANT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  05         CH-NAPOL-ANT      PIC  9(013)      VALUE  ZEROS.*/
            }
            public IntBasis CH_NAPOL_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  05         WWORK-VALOR       PIC S9(013)V99   VALUE +0  COMP-3*/
            public DoubleBasis WWORK_VALOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         AC-AGE-VALOR      PIC S9(013)V99   VALUE +0  COMP-3*/
            public DoubleBasis AC_AGE_VALOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         AC-AGE-FATOR      PIC S9(013)V99   VALUE +0  COMP-3*/
            public DoubleBasis AC_AGE_FATOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         ACT-AGE-VALOR     PIC S9(013)V99   VALUE +0  COMP-3*/
            public DoubleBasis ACT_AGE_VALOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         ACT-AGE-FATOR     PIC S9(013)V99   VALUE +0  COMP-3*/
            public DoubleBasis ACT_AGE_FATOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         ACA-AGE-VALOR     PIC S9(013)V99   VALUE +0  COMP-3*/
            public DoubleBasis ACA_AGE_VALOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         ACA-AGE-FATOR     PIC S9(013)V99   VALUE +0  COMP-3*/
            public DoubleBasis ACA_AGE_FATOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         ACG-AGE-VALOR     PIC S9(013)V99   VALUE +0  COMP-3*/
            public DoubleBasis ACG_AGE_VALOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         ACG-AGE-FATOR     PIC S9(013)V99   VALUE +0  COMP-3*/
            public DoubleBasis ACG_AGE_FATOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         WDATA-CURR.*/
            public VG0283B_WDATA_CURR WDATA_CURR { get; set; } = new VG0283B_WDATA_CURR();
            public class VG0283B_WDATA_CURR : VarBasis
            {
                /*"    10       WDATA-AA-CURR     PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDATA_AA_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-MM-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-DD-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_DD_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WHORA-CURR.*/
            }
            public VG0283B_WHORA_CURR WHORA_CURR { get; set; } = new VG0283B_WHORA_CURR();
            public class VG0283B_WHORA_CURR : VarBasis
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
            public VG0283B_WDATA_CABEC WDATA_CABEC { get; set; } = new VG0283B_WDATA_CABEC();
            public class VG0283B_WDATA_CABEC : VarBasis
            {
                /*"    10       WDATA-DD-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDATA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDATA-AA-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WHORA-CABEC.*/
            }
            public VG0283B_WHORA_CABEC WHORA_CABEC { get; set; } = new VG0283B_WHORA_CABEC();
            public class VG0283B_WHORA_CABEC : VarBasis
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
                /*"  05         WDATA-VIGENCIA.*/
            }
            public VG0283B_WDATA_VIGENCIA WDATA_VIGENCIA { get; set; } = new VG0283B_WDATA_VIGENCIA();
            public class VG0283B_WDATA_VIGENCIA : VarBasis
            {
                /*"    10       WDATA-VIG-ANO     PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDATA_VIG_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10       FILLER            PIC  X(001)    VALUE SPACES.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WDATA-VIG-MES     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_VIG_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE SPACES.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WDATA-VIG-DIA     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_VIG_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05            LC01.*/
            }
            public VG0283B_LC01 LC01 { get; set; } = new VG0283B_LC01();
            public class VG0283B_LC01 : VarBasis
            {
                /*"    10          LC01-RELATOR   PIC  X(010) VALUE 'VG0283B.1'.*/
                public StringBasis LC01_RELATOR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VG0283B.1");
                /*"    10          FILLER         PIC  X(033) VALUE  SPACES.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "33", "X(033)"), @"");
                /*"    10          LC01-EMPRESA   PIC  X(040) VALUE  SPACES.*/
                public StringBasis LC01_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    10          FILLER         PIC  X(034) VALUE  SPACES.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"");
                /*"    10          FILLER         PIC  X(011) VALUE 'PAGINA'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"PAGINA");
                /*"    10          LC01-PAGINA    PIC  ZZZ9.*/
                public IntBasis LC01_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
                /*"  05            LC02.*/
            }
            public VG0283B_LC02 LC02 { get; set; } = new VG0283B_LC02();
            public class VG0283B_LC02 : VarBasis
            {
                /*"    10          FILLER         PIC  X(117) VALUE  SPACES.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "117", "X(117)"), @"");
                /*"    10          FILLER         PIC  X(005) VALUE 'DATA'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"DATA");
                /*"    10          LC02-DATA      PIC  X(010) VALUE  SPACES.*/
                public StringBasis LC02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  05            LC03.*/
            }
            public VG0283B_LC03 LC03 { get; set; } = new VG0283B_LC03();
            public class VG0283B_LC03 : VarBasis
            {
                /*"    10          FILLER         PIC  X(033) VALUE SPACES.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "33", "X(033)"), @"");
                /*"    10          FILLER         PIC  X(038) VALUE               'DEMONSTRATIVO DE EXCEDENTE TECNICO DE '.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "38", "X(038)"), @"DEMONSTRATIVO DE EXCEDENTE TECNICO DE ");
                /*"    10          LC03-DIA-INI   PIC  9(002) VALUE  ZEROS.*/
                public IntBasis LC03_DIA_INI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          FILLER         PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LC03-MES-INI   PIC  9(002) VALUE  ZEROS.*/
                public IntBasis LC03_MES_INI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          FILLER         PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LC03-ANO-INI   PIC  9(004) VALUE  ZEROS.*/
                public IntBasis LC03_ANO_INI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10          FILLER         PIC  X(003) VALUE ' A '.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" A ");
                /*"    10          LC03-DIA-TER   PIC  9(002) VALUE  ZEROS.*/
                public IntBasis LC03_DIA_TER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          FILLER         PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LC03-MES-TER   PIC  9(002) VALUE  ZEROS.*/
                public IntBasis LC03_MES_TER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          FILLER         PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LC03-ANO-TER   PIC  9(004) VALUE  ZEROS.*/
                public IntBasis LC03_ANO_TER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10          FILLER         PIC  X(023) VALUE  SPACES.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"");
                /*"    10          FILLER         PIC  X(007) VALUE 'HORA'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"HORA");
                /*"    10          LC03-HORA      PIC  X(008) VALUE  SPACES.*/
                public StringBasis LC03_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"  05            LC03A.*/
            }
            public VG0283B_LC03A LC03A { get; set; } = new VG0283B_LC03A();
            public class VG0283B_LC03A : VarBasis
            {
                /*"    10          FILLER         PIC  X(103) VALUE  SPACES.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "103", "X(103)"), @"");
                /*"    10          FILLER         PIC  X(021) VALUE                'FATORES EXPRESSOS EM '.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"FATORES EXPRESSOS EM ");
                /*"    10          LC03A-DESCR    PIC  X(006) VALUE  SPACES.*/
                public StringBasis LC03A_DESCR { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"  05            LC04.*/
            }
            public VG0283B_LC04 LC04 { get; set; } = new VG0283B_LC04();
            public class VG0283B_LC04 : VarBasis
            {
                /*"    10          FILLER         PIC  X(016) VALUE                               'ESTIPULANTE - '.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"ESTIPULANTE - ");
                /*"    10          LC04-ESTIPUL   PIC  X(040) VALUE  SPACES.*/
                public StringBasis LC04_ESTIPUL { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"  05            LC05.*/
            }
            public VG0283B_LC05 LC05 { get; set; } = new VG0283B_LC05();
            public class VG0283B_LC05 : VarBasis
            {
                /*"    10          FILLER         PIC  X(016) VALUE 'SUB ESTIPULANTE               ' '.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"SUB ESTIPULANTE               ");
                /*"    10          LC05-CODSUBES  PIC  99999.*/
                public IntBasis LC05_CODSUBES { get; set; } = new IntBasis(new PIC("9", "5", "99999."));
                /*"    10          FILLER         PIC  X(003) VALUE  SPACES.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10          LC05-SUBEST    PIC  X(040) VALUE  SPACES.*/
                public StringBasis LC05_SUBEST { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"  05            LC06.*/
            }
            public VG0283B_LC06 LC06 { get; set; } = new VG0283B_LC06();
            public class VG0283B_LC06 : VarBasis
            {
                /*"    10          FILLER         PIC  X(016) VALUE 'APOLICE'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"APOLICE");
                /*"    10          LC06-NUM-APOL  PIC  9(013) VALUE  ZEROS.*/
                public IntBasis LC06_NUM_APOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
                /*"  05            LC07.*/
            }
            public VG0283B_LC07 LC07 { get; set; } = new VG0283B_LC07();
            public class VG0283B_LC07 : VarBasis
            {
                /*"    10          FILLER         PIC  X(132) VALUE  ALL '-'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
                /*"  05            LC08.*/
            }
            public VG0283B_LC08 LC08 { get; set; } = new VG0283B_LC08();
            public class VG0283B_LC08 : VarBasis
            {
                /*"    10          FILLER         PIC  X(025) VALUE                '           DATA PAGAMENTO'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"           DATA PAGAMENTO");
                /*"    10          FILLER         PIC  X(025) VALUE                '    VALOR DE AGENCIAMENTO'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"    VALOR DE AGENCIAMENTO");
                /*"    10          FILLER         PIC  X(025) VALUE                '                    FATOR'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"                    FATOR");
                /*"  05            LD01.*/
            }
            public VG0283B_LD01 LD01 { get; set; } = new VG0283B_LD01();
            public class VG0283B_LD01 : VarBasis
            {
                /*"    10          FILLER         PIC  X(015) VALUE  SPACES.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"    10          LD01-DIA-PGT   PIC  9(002) VALUE  ZEROS.*/
                public IntBasis LD01_DIA_PGT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          FILLER         PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LD01-MES-PGT   PIC  9(002) VALUE  ZEROS.*/
                public IntBasis LD01_MES_PGT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          FILLER         PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LD01-ANO-PGT   PIC  9(004) VALUE  ZEROS.*/
                public IntBasis LD01_ANO_PGT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10          FILLER         PIC  X(011) VALUE  SPACES.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"");
                /*"    10          LD01-VLR-AGE   PIC  ZZ.ZZZ.ZZ9,99-.*/
                public DoubleBasis LD01_VLR_AGE { get; set; } = new DoubleBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9V99-."), 3);
                /*"    10          FILLER         PIC  X(011) VALUE  SPACES.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"");
                /*"    10          LD01-FAT-AGE   PIC  ZZ.ZZZ.ZZ9,99-.*/
                public DoubleBasis LD01_FAT_AGE { get; set; } = new DoubleBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9V99-."), 3);
                /*"  05            LD02.*/
            }
            public VG0283B_LD02 LD02 { get; set; } = new VG0283B_LD02();
            public class VG0283B_LD02 : VarBasis
            {
                /*"    10          FILLER         PIC  X(005) VALUE  SPACES.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"    10          LD02-TITULO    PIC  X(020) VALUE  SPACES.*/
                public StringBasis LD02_TITULO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"    10          FILLER         PIC  X(010) VALUE  SPACES.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10          LD02-VLR-AGE   PIC  ZZZ.ZZZ.ZZ9,99-.*/
                public DoubleBasis LD02_VLR_AGE { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99-."), 3);
                /*"    10          FILLER         PIC  X(010) VALUE  SPACES.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10          LD02-FAT-AGE   PIC  ZZZ.ZZZ.ZZ9,99-.*/
                public DoubleBasis LD02_FAT_AGE { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99-."), 3);
                /*"  05        WABEND.*/
            }
            public VG0283B_WABEND WABEND { get; set; } = new VG0283B_WABEND();
            public class VG0283B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(010) VALUE           ' VG0283B'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VG0283B");
                /*"    10      FILLER              PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"01          LK-LINK.*/
            }
        }
        public VG0283B_LK_LINK LK_LINK { get; set; } = new VG0283B_LK_LINK();
        public class VG0283B_LK_LINK : VarBasis
        {
            /*"  03        LK-RTCODE           PIC  S9(004)   VALUE +0   COMP.*/
            public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03        LK-TAMANHO          PIC  S9(004)   VALUE +40  COMP.*/
            public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
            /*"  03        LK-TITULO           PIC   X(132)   VALUE  SPACES.*/
            public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
        }


        public VG0283B_V1RELATORIOS V1RELATORIOS { get; set; } = new VG0283B_V1RELATORIOS();
        public VG0283B_V2COMISSAO V2COMISSAO { get; set; } = new VG0283B_V2COMISSAO();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string RVG0283B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                RVG0283B.SetFile(RVG0283B_FILE_NAME_P);

                /*" -392- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -393- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -396- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -399- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -399- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -413- PERFORM R8000-00-OPEN-ARQUIVOS */

            R8000_00_OPEN_ARQUIVOS_SECTION();

            /*" -414- PERFORM R0100-00-SELECT-V1SISTEMA */

            R0100_00_SELECT_V1SISTEMA_SECTION();

            /*" -415- IF WFIM-V1SISTEMA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1SISTEMA.IsEmpty())
            {

                /*" -416- MOVE 'B' TO WCH-FINAL */
                _.Move("B", AREA_DE_WORK.WCH_FINAL);

                /*" -420- GO TO R0000-90-ENCERRA. */

                R0000_90_ENCERRA(); //GOTO
                return;
            }


            /*" -421- MOVE SPACES TO WFIM-V1RELATOR */
            _.Move("", AREA_DE_WORK.WFIM_V1RELATOR);

            /*" -422- MOVE SPACES TO WTEM-V1RELATOR */
            _.Move("", AREA_DE_WORK.WTEM_V1RELATOR);

            /*" -424- PERFORM R0200-00-DECLARE-V1RELATORIOS. */

            R0200_00_DECLARE_V1RELATORIOS_SECTION();

            /*" -425- PERFORM R0210-00-FETCH-V1RELATORIOS */

            R0210_00_FETCH_V1RELATORIOS_SECTION();

            /*" -426- IF WFIM-V1RELATOR NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1RELATOR.IsEmpty())
            {

                /*" -427- IF WTEM-V1RELATOR EQUAL SPACES */

                if (AREA_DE_WORK.WTEM_V1RELATOR.IsEmpty())
                {

                    /*" -428- MOVE 'A' TO WCH-FINAL */
                    _.Move("A", AREA_DE_WORK.WCH_FINAL);

                    /*" -429- GO TO R0000-90-ENCERRA */

                    R0000_90_ENCERRA(); //GOTO
                    return;

                    /*" -430- ELSE */
                }
                else
                {


                    /*" -431- MOVE SPACES TO WCH-FINAL */
                    _.Move("", AREA_DE_WORK.WCH_FINAL);

                    /*" -432- GO TO R0000-90-ENCERRA. */

                    R0000_90_ENCERRA(); //GOTO
                    return;
                }

            }


            /*" -436- MOVE V1RELA-NUM-APOL TO CH-NAPOL-ANT. */
            _.Move(V1RELA_NUM_APOL, AREA_DE_WORK.CH_NAPOL_ANT);

            /*" -437- PERFORM R0300-00-MONTA-CABECALHOS */

            R0300_00_MONTA_CABECALHOS_SECTION();

            /*" -438- IF WFIM-V1EMPRESA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1EMPRESA.IsEmpty())
            {

                /*" -439- MOVE 'B' TO WCH-FINAL */
                _.Move("B", AREA_DE_WORK.WCH_FINAL);

                /*" -441- GO TO R0000-90-ENCERRA. */

                R0000_90_ENCERRA(); //GOTO
                return;
            }


            /*" -442- PERFORM R0990-00-PROCESSA-APOLICE UNTIL WFIM-V1RELATOR NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V1RELATOR.IsEmpty()))
            {

                R0990_00_PROCESSA_APOLICE_SECTION();
            }

            /*" -0- FLUXCONTROL_PERFORM R0000_90_ENCERRA */

            R0000_90_ENCERRA();

        }

        [StopWatch]
        /*" R0000-90-ENCERRA */
        private void R0000_90_ENCERRA(bool isPerform = false)
        {
            /*" -447- IF WCH-FINAL EQUAL SPACES */

            if (AREA_DE_WORK.WCH_FINAL.IsEmpty())
            {

                /*" -448- MOVE SPACES TO LC04-ESTIPUL */
                _.Move("", AREA_DE_WORK.LC04.LC04_ESTIPUL);

                /*" -449- MOVE 99999 TO LC05-CODSUBES */
                _.Move(99999, AREA_DE_WORK.LC05.LC05_CODSUBES);

                /*" -450- MOVE SPACES TO LC05-SUBEST */
                _.Move("", AREA_DE_WORK.LC05.LC05_SUBEST);

                /*" -451- MOVE 9999999999999 TO LC06-NUM-APOL */
                _.Move(9999999999999, AREA_DE_WORK.LC06.LC06_NUM_APOL);

                /*" -452- MOVE 'TOTAL GERAL' TO LD02-TITULO */
                _.Move("TOTAL GERAL", AREA_DE_WORK.LD02.LD02_TITULO);

                /*" -453- MOVE ACG-AGE-VALOR TO LD02-VLR-AGE */
                _.Move(AREA_DE_WORK.ACG_AGE_VALOR, AREA_DE_WORK.LD02.LD02_VLR_AGE);

                /*" -454- MOVE ACG-AGE-FATOR TO LD02-FAT-AGE */
                _.Move(AREA_DE_WORK.ACG_AGE_FATOR, AREA_DE_WORK.LD02.LD02_FAT_AGE);

                /*" -455- ADD 1 TO AC-LINHAS */
                AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 1;

                /*" -456- IF AC-LINHAS GREATER 53 */

                if (AREA_DE_WORK.AC_LINHAS > 53)
                {

                    /*" -457- PERFORM R5000-00-CABECALHOS */

                    R5000_00_CABECALHOS_SECTION();

                    /*" -458- WRITE REG-VG0283B FROM LD02 AFTER 1 */
                    _.Move(AREA_DE_WORK.LD02.GetMoveValues(), REG_VG0283B);

                    RVG0283B.Write(REG_VG0283B.GetMoveValues().ToString());

                    /*" -459- ELSE */
                }
                else
                {


                    /*" -461- WRITE REG-VG0283B FROM LD02 AFTER 1. */
                    _.Move(AREA_DE_WORK.LD02.GetMoveValues(), REG_VG0283B);

                    RVG0283B.Write(REG_VG0283B.GetMoveValues().ToString());
                }

            }


            /*" -462- IF WCH-FINAL EQUAL SPACES */

            if (AREA_DE_WORK.WCH_FINAL.IsEmpty())
            {

                /*" -463- PERFORM R0220-00-UPDATE-V0RELATORIOS */

                R0220_00_UPDATE_V0RELATORIOS_SECTION();

                /*" -464- DISPLAY 'VG0283B - FIM NORMAL' */
                _.Display($"VG0283B - FIM NORMAL");

                /*" -465- ELSE */
            }
            else
            {


                /*" -466- IF WCH-FINAL EQUAL 'A' */

                if (AREA_DE_WORK.WCH_FINAL == "A")
                {

                    /*" -467- DISPLAY 'VG0283B - NAO HOUVE SOLICITACAO' */
                    _.Display($"VG0283B - NAO HOUVE SOLICITACAO");

                    /*" -468- ELSE */
                }
                else
                {


                    /*" -469- IF WCH-FINAL EQUAL 'B' */

                    if (AREA_DE_WORK.WCH_FINAL == "B")
                    {

                        /*" -473- DISPLAY 'VG0283B - ENCERRADO COM PROBLEMAS' . */
                        _.Display($"VG0283B - ENCERRADO COM PROBLEMAS");
                    }

                }

            }


            /*" -475- PERFORM R9000-00-CLOSE-ARQUIVOS */

            R9000_00_CLOSE_ARQUIVOS_SECTION();

            /*" -475- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -479- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -479- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-SECTION */
        private void R0100_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -492- MOVE '050' TO WNR-EXEC-SQL. */
            _.Move("050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -497- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -500- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -501- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -502- DISPLAY 'VG0283B - SISTEMA DE VIDA NAO CADASTRADO' */
                    _.Display($"VG0283B - SISTEMA DE VIDA NAO CADASTRADO");

                    /*" -503- MOVE 'S' TO WFIM-V1SISTEMA */
                    _.Move("S", AREA_DE_WORK.WFIM_V1SISTEMA);

                    /*" -504- ELSE */
                }
                else
                {


                    /*" -505- DISPLAY 'ERRO ACESSO V1SISTEMA' */
                    _.Display($"ERRO ACESSO V1SISTEMA");

                    /*" -505- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -497- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :V1SIST-DTMOVABE, :V1SIST-DTCURRENT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VG' END-EXEC. */

            var r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
                _.Move(executed_1.V1SIST_DTCURRENT, V1SIST_DTCURRENT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-DECLARE-V1RELATORIOS-SECTION */
        private void R0200_00_DECLARE_V1RELATORIOS_SECTION()
        {
            /*" -518- MOVE '020' TO WNR-EXEC-SQL. */
            _.Move("020", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -529- PERFORM R0200_00_DECLARE_V1RELATORIOS_DB_DECLARE_1 */

            R0200_00_DECLARE_V1RELATORIOS_DB_DECLARE_1();

            /*" -531- PERFORM R0200_00_DECLARE_V1RELATORIOS_DB_OPEN_1 */

            R0200_00_DECLARE_V1RELATORIOS_DB_OPEN_1();

            /*" -534- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -535- DISPLAY 'PROBLEMAS DECLARE V1RELATORIOS ... ' */
                _.Display($"PROBLEMAS DECLARE V1RELATORIOS ... ");

                /*" -535- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0200-00-DECLARE-V1RELATORIOS-DB-DECLARE-1 */
        public void R0200_00_DECLARE_V1RELATORIOS_DB_DECLARE_1()
        {
            /*" -529- EXEC SQL DECLARE V1RELATORIOS CURSOR FOR SELECT NUM_APOLICE , CODSUBES , CODUNIMO , PERI_INICIAL , PERI_FINAL FROM SEGUROS.V1RELATORIOS WHERE CODRELAT = 'VG0282B1' AND SITUACAO = '1' ORDER BY NUM_APOLICE, CODSUBES END-EXEC. */
            V1RELATORIOS = new VG0283B_V1RELATORIOS(false);
            string GetQuery_V1RELATORIOS()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							CODSUBES
							, 
							CODUNIMO
							, 
							PERI_INICIAL
							, 
							PERI_FINAL 
							FROM SEGUROS.V1RELATORIOS 
							WHERE CODRELAT = 'VG0282B1' 
							AND SITUACAO = '1' 
							ORDER BY NUM_APOLICE
							, 
							CODSUBES";

                return query;
            }
            V1RELATORIOS.GetQueryEvent += GetQuery_V1RELATORIOS;

        }

        [StopWatch]
        /*" R0200-00-DECLARE-V1RELATORIOS-DB-OPEN-1 */
        public void R0200_00_DECLARE_V1RELATORIOS_DB_OPEN_1()
        {
            /*" -531- EXEC SQL OPEN V1RELATORIOS END-EXEC. */

            V1RELATORIOS.Open();

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V2COMISSAO-DB-DECLARE-1 */
        public void R0900_00_DECLARE_V2COMISSAO_DB_DECLARE_1()
        {
            /*" -691- EXEC SQL DECLARE V2COMISSAO CURSOR FOR SELECT CODSUBES, OPERACAO, DTMOVTO, SUM(VLCOMIS) FROM SEGUROS.V1COMISSAO WHERE NUM_APOLICE = :V1RELA-NUM-APOL AND NRENDOS > 0 AND CODPDT �= 999059 AND DTMOVTO >= :V1RELA-PERI-INI AND DTMOVTO <= :V1RELA-PERI-FIN AND OPERACAO IN (1101, 1102, 1103) GROUP BY CODSUBES, OPERACAO, DTMOVTO ORDER BY CODSUBES, DTMOVTO END-EXEC. */
            V2COMISSAO = new VG0283B_V2COMISSAO(true);
            string GetQuery_V2COMISSAO()
            {
                var query = @$"SELECT CODSUBES
							, 
							OPERACAO
							, 
							DTMOVTO
							, 
							SUM(VLCOMIS) 
							FROM SEGUROS.V1COMISSAO 
							WHERE NUM_APOLICE = '{V1RELA_NUM_APOL}' 
							AND NRENDOS > 0 
							AND CODPDT �= 999059 
							AND DTMOVTO >= '{V1RELA_PERI_INI}' 
							AND DTMOVTO <= '{V1RELA_PERI_FIN}' 
							AND OPERACAO IN (1101
							, 1102
							, 1103) 
							GROUP BY CODSUBES
							, OPERACAO
							, DTMOVTO 
							ORDER BY CODSUBES
							, DTMOVTO";

                return query;
            }
            V2COMISSAO.GetQueryEvent += GetQuery_V2COMISSAO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-FETCH-V1RELATORIOS-SECTION */
        private void R0210_00_FETCH_V1RELATORIOS_SECTION()
        {
            /*" -548- MOVE '021' TO WNR-EXEC-SQL. */
            _.Move("021", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -554- PERFORM R0210_00_FETCH_V1RELATORIOS_DB_FETCH_1 */

            R0210_00_FETCH_V1RELATORIOS_DB_FETCH_1();

            /*" -557- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -558- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -559- MOVE 'S' TO WFIM-V1RELATOR */
                    _.Move("S", AREA_DE_WORK.WFIM_V1RELATOR);

                    /*" -560- MOVE 9999999999999 TO V1RELA-NUM-APOL */
                    _.Move(9999999999999, V1RELA_NUM_APOL);

                    /*" -561- GO TO R0210-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/ //GOTO
                    return;

                    /*" -562- ELSE */
                }
                else
                {


                    /*" -563- DISPLAY 'PROBLEMAS ACESSO V1RELATORIOS' */
                    _.Display($"PROBLEMAS ACESSO V1RELATORIOS");

                    /*" -565- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -565- MOVE '*' TO WTEM-V1RELATOR. */
            _.Move("*", AREA_DE_WORK.WTEM_V1RELATOR);

        }

        [StopWatch]
        /*" R0210-00-FETCH-V1RELATORIOS-DB-FETCH-1 */
        public void R0210_00_FETCH_V1RELATORIOS_DB_FETCH_1()
        {
            /*" -554- EXEC SQL FETCH V1RELATORIOS INTO :V1RELA-NUM-APOL , :V1RELA-CODSUBES , :V1RELA-CODUNIMO , :V1RELA-PERI-INI , :V1RELA-PERI-FIN END-EXEC. */

            if (V1RELATORIOS.Fetch())
            {
                _.Move(V1RELATORIOS.V1RELA_NUM_APOL, V1RELA_NUM_APOL);
                _.Move(V1RELATORIOS.V1RELA_CODSUBES, V1RELA_CODSUBES);
                _.Move(V1RELATORIOS.V1RELA_CODUNIMO, V1RELA_CODUNIMO);
                _.Move(V1RELATORIOS.V1RELA_PERI_INI, V1RELA_PERI_INI);
                _.Move(V1RELATORIOS.V1RELA_PERI_FIN, V1RELA_PERI_FIN);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/

        [StopWatch]
        /*" R0220-00-UPDATE-V0RELATORIOS-SECTION */
        private void R0220_00_UPDATE_V0RELATORIOS_SECTION()
        {
            /*" -578- MOVE '022' TO WNR-EXEC-SQL. */
            _.Move("022", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -583- PERFORM R0220_00_UPDATE_V0RELATORIOS_DB_UPDATE_1 */

            R0220_00_UPDATE_V0RELATORIOS_DB_UPDATE_1();

            /*" -586- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -587- DISPLAY 'PROBLEMA UPDATE V0RELATORIOS' */
                _.Display($"PROBLEMA UPDATE V0RELATORIOS");

                /*" -587- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0220-00-UPDATE-V0RELATORIOS-DB-UPDATE-1 */
        public void R0220_00_UPDATE_V0RELATORIOS_DB_UPDATE_1()
        {
            /*" -583- EXEC SQL UPDATE SEGUROS.V0RELATORIOS SET SITUACAO = '9' , TIMESTAMP = CURRENT TIMESTAMP WHERE CODRELAT = 'VG0282B1' AND SITUACAO = '1' END-EXEC. */

            var r0220_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1 = new R0220_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1()
            {
            };

            R0220_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1.Execute(r0220_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-MONTA-CABECALHOS-SECTION */
        private void R0300_00_MONTA_CABECALHOS_SECTION()
        {
            /*" -610- MOVE '030' TO WNR-EXEC-SQL. */
            _.Move("030", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -611- MOVE V1SIST-DTCURRENT TO WDATA-CURR */
            _.Move(V1SIST_DTCURRENT, AREA_DE_WORK.WDATA_CURR);

            /*" -612- MOVE WDATA-DD-CURR TO WDATA-DD-CABEC */
            _.Move(AREA_DE_WORK.WDATA_CURR.WDATA_DD_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -613- MOVE WDATA-MM-CURR TO WDATA-MM-CABEC */
            _.Move(AREA_DE_WORK.WDATA_CURR.WDATA_MM_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -614- MOVE WDATA-AA-CURR TO WDATA-AA-CABEC */
            _.Move(AREA_DE_WORK.WDATA_CURR.WDATA_AA_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -616- MOVE WDATA-CABEC TO LC02-DATA. */
            _.Move(AREA_DE_WORK.WDATA_CABEC, AREA_DE_WORK.LC02.LC02_DATA);

            /*" -617- ACCEPT WHORA-CURR FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_CURR);

            /*" -618- MOVE WHORA-HH-CURR TO WHORA-HH-CABEC */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_HH_CURR, AREA_DE_WORK.WHORA_CABEC.WHORA_HH_CABEC);

            /*" -619- MOVE WHORA-MM-CURR TO WHORA-MM-CABEC */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_MM_CURR, AREA_DE_WORK.WHORA_CABEC.WHORA_MM_CABEC);

            /*" -620- MOVE WHORA-SS-CURR TO WHORA-SS-CABEC */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_SS_CURR, AREA_DE_WORK.WHORA_CABEC.WHORA_SS_CABEC);

            /*" -622- MOVE WHORA-CABEC TO LC03-HORA. */
            _.Move(AREA_DE_WORK.WHORA_CABEC, AREA_DE_WORK.LC03.LC03_HORA);

            /*" -626- PERFORM R0300_00_MONTA_CABECALHOS_DB_SELECT_1 */

            R0300_00_MONTA_CABECALHOS_DB_SELECT_1();

            /*" -629- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -630- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -631- DISPLAY 'EMPRESA NAO CADASTRADA' */
                    _.Display($"EMPRESA NAO CADASTRADA");

                    /*" -632- MOVE 'S' TO WFIM-V1EMPRESA */
                    _.Move("S", AREA_DE_WORK.WFIM_V1EMPRESA);

                    /*" -633- GO TO R0300-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/ //GOTO
                    return;

                    /*" -634- ELSE */
                }
                else
                {


                    /*" -635- DISPLAY 'PROBLEMAS ACESSO V1EMPRESA' */
                    _.Display($"PROBLEMAS ACESSO V1EMPRESA");

                    /*" -637- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -638- MOVE V1EMPR-NOM-EMP TO LK-TITULO */
            _.Move(V1EMPR_NOM_EMP, LK_LINK.LK_TITULO);

            /*" -640- CALL 'PROALN01' USING LK-LINK */
            _.Call("PROALN01", LK_LINK);

            /*" -641- IF LK-RTCODE EQUAL ZEROS */

            if (LK_LINK.LK_RTCODE == 00)
            {

                /*" -642- MOVE LK-TITULO TO LC01-EMPRESA */
                _.Move(LK_LINK.LK_TITULO, AREA_DE_WORK.LC01.LC01_EMPRESA);

                /*" -643- ELSE */
            }
            else
            {


                /*" -644- DISPLAY 'PROBLEMA CALL V1EMPRESA' */
                _.Display($"PROBLEMA CALL V1EMPRESA");

                /*" -646- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -650- PERFORM R0300_00_MONTA_CABECALHOS_DB_SELECT_2 */

            R0300_00_MONTA_CABECALHOS_DB_SELECT_2();

            /*" -653- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -654- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -655- DISPLAY 'MOEDA NAO CADASTRADA' */
                    _.Display($"MOEDA NAO CADASTRADA");

                    /*" -656- MOVE 'MOEDA NAO CADASTRADA' TO V0MOED-SIGLUNIM */
                    _.Move("MOEDA NAO CADASTRADA", V0MOED_SIGLUNIM);

                    /*" -657- GO TO R0300-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/ //GOTO
                    return;

                    /*" -658- ELSE */
                }
                else
                {


                    /*" -659- DISPLAY 'PROBLEMAS ACESSO V0MOEDA' */
                    _.Display($"PROBLEMAS ACESSO V0MOEDA");

                    /*" -662- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -662- MOVE V0MOED-SIGLUNIM TO LC03A-DESCR. */
            _.Move(V0MOED_SIGLUNIM, AREA_DE_WORK.LC03A.LC03A_DESCR);

        }

        [StopWatch]
        /*" R0300-00-MONTA-CABECALHOS-DB-SELECT-1 */
        public void R0300_00_MONTA_CABECALHOS_DB_SELECT_1()
        {
            /*" -626- EXEC SQL SELECT NOME_EMPRESA INTO :V1EMPR-NOM-EMP FROM SEGUROS.V1EMPRESA WHERE COD_EMPRESA = 0 END-EXEC. */

            var r0300_00_MONTA_CABECALHOS_DB_SELECT_1_Query1 = new R0300_00_MONTA_CABECALHOS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0300_00_MONTA_CABECALHOS_DB_SELECT_1_Query1.Execute(r0300_00_MONTA_CABECALHOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1EMPR_NOM_EMP, V1EMPR_NOM_EMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-MONTA-CABECALHOS-DB-SELECT-2 */
        public void R0300_00_MONTA_CABECALHOS_DB_SELECT_2()
        {
            /*" -650- EXEC SQL SELECT SIGLUNIM INTO :V0MOED-SIGLUNIM FROM SEGUROS.V0MOEDA WHERE CODUNIMO = :V1RELA-CODUNIMO END-EXEC. */

            var r0300_00_MONTA_CABECALHOS_DB_SELECT_2_Query1 = new R0300_00_MONTA_CABECALHOS_DB_SELECT_2_Query1()
            {
                V1RELA_CODUNIMO = V1RELA_CODUNIMO.ToString(),
            };

            var executed_1 = R0300_00_MONTA_CABECALHOS_DB_SELECT_2_Query1.Execute(r0300_00_MONTA_CABECALHOS_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0MOED_SIGLUNIM, V0MOED_SIGLUNIM);
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-V2COMISSAO-SECTION */
        private void R0900_00_DECLARE_V2COMISSAO_SECTION()
        {
            /*" -676- MOVE '900' TO WNR-EXEC-SQL. */
            _.Move("900", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -691- PERFORM R0900_00_DECLARE_V2COMISSAO_DB_DECLARE_1 */

            R0900_00_DECLARE_V2COMISSAO_DB_DECLARE_1();

            /*" -693- PERFORM R0900_00_DECLARE_V2COMISSAO_DB_OPEN_1 */

            R0900_00_DECLARE_V2COMISSAO_DB_OPEN_1();

            /*" -696- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -697- DISPLAY 'PROBLEMAS DECLARE V2COMISSAO ... ' */
                _.Display($"PROBLEMAS DECLARE V2COMISSAO ... ");

                /*" -697- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-V2COMISSAO-DB-OPEN-1 */
        public void R0900_00_DECLARE_V2COMISSAO_DB_OPEN_1()
        {
            /*" -693- EXEC SQL OPEN V2COMISSAO END-EXEC. */

            V2COMISSAO.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-V2COMISSAO-SECTION */
        private void R0910_00_FETCH_V2COMISSAO_SECTION()
        {
            /*" -710- MOVE '910' TO WNR-EXEC-SQL. */
            _.Move("910", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -715- PERFORM R0910_00_FETCH_V2COMISSAO_DB_FETCH_1 */

            R0910_00_FETCH_V2COMISSAO_DB_FETCH_1();

            /*" -718- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -719- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -720- MOVE 'S' TO WFIM-V2COMISSAO */
                    _.Move("S", AREA_DE_WORK.WFIM_V2COMISSAO);

                    /*" -721- MOVE 9999 TO CH-CHAVE-ATU */
                    _.Move(9999, AREA_DE_WORK.CH_CHAVE_ATU);

                    /*" -721- PERFORM R0910_00_FETCH_V2COMISSAO_DB_CLOSE_1 */

                    R0910_00_FETCH_V2COMISSAO_DB_CLOSE_1();

                    /*" -723- GO TO R0910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;

                    /*" -724- ELSE */
                }
                else
                {


                    /*" -725- DISPLAY 'R0910-00 PROBLEMAS NO FETCH ... ' */
                    _.Display($"R0910-00 PROBLEMAS NO FETCH ... ");

                    /*" -727- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -728- IF V1RELA-CODSUBES GREATER ZEROS */

            if (V1RELA_CODSUBES > 00)
            {

                /*" -729- IF V1RELA-CODSUBES NOT = V1COMI-CODSUBES */

                if (V1RELA_CODSUBES != V1COMI_CODSUBES)
                {

                    /*" -731- GO TO R0910-00-FETCH-V2COMISSAO. */
                    new Task(() => R0910_00_FETCH_V2COMISSAO_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...
                }

            }


            /*" -732- MOVE V1COMI-CODSUBES TO CH-CODSB-ATU */
            _.Move(V1COMI_CODSUBES, AREA_DE_WORK.CH_CHAVE_ATU.CH_CODSB_ATU);

            /*" -732- MOVE V1COMI-DTMOVTO TO CH-VIGEN-ATU. */
            _.Move(V1COMI_DTMOVTO, AREA_DE_WORK.CH_CHAVE_ATU.CH_VIGEN_ATU);

        }

        [StopWatch]
        /*" R0910-00-FETCH-V2COMISSAO-DB-FETCH-1 */
        public void R0910_00_FETCH_V2COMISSAO_DB_FETCH_1()
        {
            /*" -715- EXEC SQL FETCH V2COMISSAO INTO :V1COMI-CODSUBES , :V1COMI-OPERACAO , :V1COMI-DTMOVTO , :V1COMI-VLCOMIS END-EXEC. */

            if (V2COMISSAO.Fetch())
            {
                _.Move(V2COMISSAO.V1COMI_CODSUBES, V1COMI_CODSUBES);
                _.Move(V2COMISSAO.V1COMI_OPERACAO, V1COMI_OPERACAO);
                _.Move(V2COMISSAO.V1COMI_DTMOVTO, V1COMI_DTMOVTO);
                _.Move(V2COMISSAO.V1COMI_VLCOMIS, V1COMI_VLCOMIS);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-V2COMISSAO-DB-CLOSE-1 */
        public void R0910_00_FETCH_V2COMISSAO_DB_CLOSE_1()
        {
            /*" -721- EXEC SQL CLOSE V2COMISSAO END-EXEC */

            V2COMISSAO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R0990-00-PROCESSA-APOLICE-SECTION */
        private void R0990_00_PROCESSA_APOLICE_SECTION()
        {
            /*" -747- MOVE '990' TO WNR-EXEC-SQL. */
            _.Move("990", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -748- PERFORM R0900-00-DECLARE-V2COMISSAO */

            R0900_00_DECLARE_V2COMISSAO_SECTION();

            /*" -750- PERFORM R0910-00-FETCH-V2COMISSAO */

            R0910_00_FETCH_V2COMISSAO_SECTION();

            /*" -751- IF WFIM-V2COMISSAO EQUAL HIGH-VALUES */

            if (AREA_DE_WORK.WFIM_V2COMISSAO.IsHighValues)
            {

                /*" -753- GO TO R0990-10-NEXT. */

                R0990_10_NEXT(); //GOTO
                return;
            }


            /*" -754- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-V2COMISSAO NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V2COMISSAO.IsEmpty()))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -0- FLUXCONTROL_PERFORM R0990_10_NEXT */

            R0990_10_NEXT();

        }

        [StopWatch]
        /*" R0990-10-NEXT */
        private void R0990_10_NEXT(bool isPerform = false)
        {
            /*" -759- MOVE +80 TO AC-LINHAS */
            _.Move(+80, AREA_DE_WORK.AC_LINHAS);

            /*" -760- MOVE ZEROS TO AC-PAGINA */
            _.Move(0, AREA_DE_WORK.AC_PAGINA);

            /*" -761- MOVE SPACES TO WFIM-V2COMISSAO */
            _.Move("", AREA_DE_WORK.WFIM_V2COMISSAO);

            /*" -763- MOVE SPACES TO WFIM-V1COMISSAO */
            _.Move("", AREA_DE_WORK.WFIM_V1COMISSAO);

            /*" -765- PERFORM R0210-00-FETCH-V1RELATORIOS. */

            R0210_00_FETCH_V1RELATORIOS_SECTION();

            /*" -766- IF V1RELA-NUM-APOL NOT EQUAL CH-NAPOL-ANT */

            if (V1RELA_NUM_APOL != AREA_DE_WORK.CH_NAPOL_ANT)
            {

                /*" -767- MOVE V1RELA-NUM-APOL TO CH-NAPOL-ANT */
                _.Move(V1RELA_NUM_APOL, AREA_DE_WORK.CH_NAPOL_ANT);

                /*" -768- IF ACA-AGE-VALOR GREATER ZEROS */

                if (AREA_DE_WORK.ACA_AGE_VALOR > 00)
                {

                    /*" -769- MOVE 9999 TO LC05-CODSUBES */
                    _.Move(9999, AREA_DE_WORK.LC05.LC05_CODSUBES);

                    /*" -770- MOVE SPACES TO LC05-SUBEST */
                    _.Move("", AREA_DE_WORK.LC05.LC05_SUBEST);

                    /*" -771- PERFORM R5000-00-CABECALHOS */

                    R5000_00_CABECALHOS_SECTION();

                    /*" -772- MOVE 'TOTAL APOLICE' TO LD02-TITULO */
                    _.Move("TOTAL APOLICE", AREA_DE_WORK.LD02.LD02_TITULO);

                    /*" -773- MOVE ACA-AGE-VALOR TO LD02-VLR-AGE */
                    _.Move(AREA_DE_WORK.ACA_AGE_VALOR, AREA_DE_WORK.LD02.LD02_VLR_AGE);

                    /*" -774- MOVE ACA-AGE-FATOR TO LD02-FAT-AGE */
                    _.Move(AREA_DE_WORK.ACA_AGE_FATOR, AREA_DE_WORK.LD02.LD02_FAT_AGE);

                    /*" -775- WRITE REG-VG0283B FROM LD02 AFTER 1 */
                    _.Move(AREA_DE_WORK.LD02.GetMoveValues(), REG_VG0283B);

                    RVG0283B.Write(REG_VG0283B.GetMoveValues().ToString());

                    /*" -776- ADD ACA-AGE-VALOR TO ACG-AGE-VALOR */
                    AREA_DE_WORK.ACG_AGE_VALOR.Value = AREA_DE_WORK.ACG_AGE_VALOR + AREA_DE_WORK.ACA_AGE_VALOR;

                    /*" -777- ADD ACA-AGE-FATOR TO ACG-AGE-FATOR */
                    AREA_DE_WORK.ACG_AGE_FATOR.Value = AREA_DE_WORK.ACG_AGE_FATOR + AREA_DE_WORK.ACA_AGE_FATOR;

                    /*" -778- MOVE ZEROS TO ACA-AGE-VALOR ACA-AGE-FATOR. */
                    _.Move(0, AREA_DE_WORK.ACA_AGE_VALOR, AREA_DE_WORK.ACA_AGE_FATOR);
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0990_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -791- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -792- MOVE V1RELA-PERI-INI TO WDATA-VIGENCIA */
            _.Move(V1RELA_PERI_INI, AREA_DE_WORK.WDATA_VIGENCIA);

            /*" -793- MOVE WDATA-VIG-DIA TO LC03-DIA-INI */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_DIA, AREA_DE_WORK.LC03.LC03_DIA_INI);

            /*" -794- MOVE WDATA-VIG-MES TO LC03-MES-INI */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES, AREA_DE_WORK.LC03.LC03_MES_INI);

            /*" -796- MOVE WDATA-VIG-ANO TO LC03-ANO-INI */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_ANO, AREA_DE_WORK.LC03.LC03_ANO_INI);

            /*" -797- MOVE V1RELA-PERI-FIN TO WDATA-VIGENCIA */
            _.Move(V1RELA_PERI_FIN, AREA_DE_WORK.WDATA_VIGENCIA);

            /*" -798- MOVE WDATA-VIG-DIA TO LC03-DIA-TER */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_DIA, AREA_DE_WORK.LC03.LC03_DIA_TER);

            /*" -799- MOVE WDATA-VIG-MES TO LC03-MES-TER */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES, AREA_DE_WORK.LC03.LC03_MES_TER);

            /*" -803- MOVE WDATA-VIG-ANO TO LC03-ANO-TER */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_ANO, AREA_DE_WORK.LC03.LC03_ANO_TER);

            /*" -804- PERFORM R2100-00-SELECT-V1APOLICE */

            R2100_00_SELECT_V1APOLICE_SECTION();

            /*" -805- MOVE V1APOL-CODCLIEN TO WHOST-CODCLIEN */
            _.Move(V1APOL_CODCLIEN, WHOST_CODCLIEN);

            /*" -806- PERFORM R2300-00-SELECT-V1CLIENTE */

            R2300_00_SELECT_V1CLIENTE_SECTION();

            /*" -810- MOVE V1CLIE-NOME TO LC04-ESTIPUL */
            _.Move(V1CLIE_NOME, AREA_DE_WORK.LC04.LC04_ESTIPUL);

            /*" -811- PERFORM R2200-00-SELECT-V1SUBGRUPO */

            R2200_00_SELECT_V1SUBGRUPO_SECTION();

            /*" -812- MOVE V1SUBG-CODCLIEN TO WHOST-CODCLIEN */
            _.Move(V1SUBG_CODCLIEN, WHOST_CODCLIEN);

            /*" -814- PERFORM R2300-00-SELECT-V1CLIENTE */

            R2300_00_SELECT_V1CLIENTE_SECTION();

            /*" -815- MOVE V1COMI-CODSUBES TO LC05-CODSUBES */
            _.Move(V1COMI_CODSUBES, AREA_DE_WORK.LC05.LC05_CODSUBES);

            /*" -817- MOVE V1CLIE-NOME TO LC05-SUBEST */
            _.Move(V1CLIE_NOME, AREA_DE_WORK.LC05.LC05_SUBEST);

            /*" -819- MOVE V1RELA-NUM-APOL TO LC06-NUM-APOL */
            _.Move(V1RELA_NUM_APOL, AREA_DE_WORK.LC06.LC06_NUM_APOL);

            /*" -821- PERFORM R5000-00-CABECALHOS */

            R5000_00_CABECALHOS_SECTION();

            /*" -822- MOVE CH-CODSB-ATU TO CH-CODSB-ANT */
            _.Move(AREA_DE_WORK.CH_CHAVE_ATU.CH_CODSB_ATU, AREA_DE_WORK.CH_CHAVE_ANT.CH_CODSB_ANT);

            /*" -824- MOVE CH-VIGEN-ATU TO CH-VIGEN-ANT */
            _.Move(AREA_DE_WORK.CH_CHAVE_ATU.CH_VIGEN_ATU, AREA_DE_WORK.CH_CHAVE_ANT.CH_VIGEN_ANT);

            /*" -827- PERFORM R1100-00-PROCESSA-SUBESTIP UNTIL CH-CODSB-ATU NOT EQUAL CH-CODSB-ANT */

            while (!(AREA_DE_WORK.CH_CHAVE_ATU.CH_CODSB_ATU != AREA_DE_WORK.CH_CHAVE_ANT.CH_CODSB_ANT))
            {

                R1100_00_PROCESSA_SUBESTIP_SECTION();
            }

            /*" -829- ADD 1 TO AC-LINHAS */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 1;

            /*" -832- MOVE ZEROS TO AC-AGE-VALOR AC-AGE-FATOR. */
            _.Move(0, AREA_DE_WORK.AC_AGE_VALOR, AREA_DE_WORK.AC_AGE_FATOR);

            /*" -834- MOVE 'TOTAL SUBGRUPO' TO LD02-TITULO */
            _.Move("TOTAL SUBGRUPO", AREA_DE_WORK.LD02.LD02_TITULO);

            /*" -835- MOVE ACT-AGE-VALOR TO LD02-VLR-AGE */
            _.Move(AREA_DE_WORK.ACT_AGE_VALOR, AREA_DE_WORK.LD02.LD02_VLR_AGE);

            /*" -837- MOVE ACT-AGE-FATOR TO LD02-FAT-AGE */
            _.Move(AREA_DE_WORK.ACT_AGE_FATOR, AREA_DE_WORK.LD02.LD02_FAT_AGE);

            /*" -839- ADD 1 TO AC-LINHAS */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 1;

            /*" -840- IF AC-LINHAS GREATER 53 */

            if (AREA_DE_WORK.AC_LINHAS > 53)
            {

                /*" -842- PERFORM R5000-00-CABECALHOS. */

                R5000_00_CABECALHOS_SECTION();
            }


            /*" -844- WRITE REG-VG0283B FROM LD02 AFTER 1 */
            _.Move(AREA_DE_WORK.LD02.GetMoveValues(), REG_VG0283B);

            RVG0283B.Write(REG_VG0283B.GetMoveValues().ToString());

            /*" -845- ADD ACT-AGE-VALOR TO ACA-AGE-VALOR */
            AREA_DE_WORK.ACA_AGE_VALOR.Value = AREA_DE_WORK.ACA_AGE_VALOR + AREA_DE_WORK.ACT_AGE_VALOR;

            /*" -847- ADD ACT-AGE-FATOR TO ACA-AGE-FATOR */
            AREA_DE_WORK.ACA_AGE_FATOR.Value = AREA_DE_WORK.ACA_AGE_FATOR + AREA_DE_WORK.ACT_AGE_FATOR;

            /*" -848- MOVE ZEROS TO ACT-AGE-VALOR ACT-AGE-FATOR. */
            _.Move(0, AREA_DE_WORK.ACT_AGE_VALOR, AREA_DE_WORK.ACT_AGE_FATOR);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-PROCESSA-SUBESTIP-SECTION */
        private void R1100_00_PROCESSA_SUBESTIP_SECTION()
        {
            /*" -861- MOVE '110' TO WNR-EXEC-SQL. */
            _.Move("110", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -863- MOVE CH-VIGEN-ATU TO CH-VIGEN-ANT */
            _.Move(AREA_DE_WORK.CH_CHAVE_ATU.CH_VIGEN_ATU, AREA_DE_WORK.CH_CHAVE_ANT.CH_VIGEN_ANT);

            /*" -867- PERFORM R1200-00-PROCESSA-DATA UNTIL CH-VIGEN-ATU NOT EQUAL CH-VIGEN-ANT. */

            while (!(AREA_DE_WORK.CH_CHAVE_ATU.CH_VIGEN_ATU != AREA_DE_WORK.CH_CHAVE_ANT.CH_VIGEN_ANT))
            {

                R1200_00_PROCESSA_DATA_SECTION();
            }

            /*" -868- MOVE CH-VIGEN-ANT TO WDATA-VIGENCIA */
            _.Move(AREA_DE_WORK.CH_CHAVE_ANT.CH_VIGEN_ANT, AREA_DE_WORK.WDATA_VIGENCIA);

            /*" -869- MOVE WDATA-VIG-DIA TO LD01-DIA-PGT */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_DIA, AREA_DE_WORK.LD01.LD01_DIA_PGT);

            /*" -870- MOVE WDATA-VIG-MES TO LD01-MES-PGT */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES, AREA_DE_WORK.LD01.LD01_MES_PGT);

            /*" -871- MOVE WDATA-VIG-ANO TO LD01-ANO-PGT */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_ANO, AREA_DE_WORK.LD01.LD01_ANO_PGT);

            /*" -872- MOVE AC-AGE-VALOR TO LD01-VLR-AGE */
            _.Move(AREA_DE_WORK.AC_AGE_VALOR, AREA_DE_WORK.LD01.LD01_VLR_AGE);

            /*" -874- MOVE AC-AGE-FATOR TO LD01-FAT-AGE */
            _.Move(AREA_DE_WORK.AC_AGE_FATOR, AREA_DE_WORK.LD01.LD01_FAT_AGE);

            /*" -876- ADD 1 TO AC-LINHAS */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 1;

            /*" -877- IF AC-LINHAS GREATER 53 */

            if (AREA_DE_WORK.AC_LINHAS > 53)
            {

                /*" -879- PERFORM R5000-00-CABECALHOS. */

                R5000_00_CABECALHOS_SECTION();
            }


            /*" -880- WRITE REG-VG0283B FROM LD01 AFTER 1 */
            _.Move(AREA_DE_WORK.LD01.GetMoveValues(), REG_VG0283B);

            RVG0283B.Write(REG_VG0283B.GetMoveValues().ToString());

            /*" -881- MOVE CH-VIGEN-ATU TO CH-VIGEN-ANT */
            _.Move(AREA_DE_WORK.CH_CHAVE_ATU.CH_VIGEN_ATU, AREA_DE_WORK.CH_CHAVE_ANT.CH_VIGEN_ANT);

            /*" -882- ADD AC-AGE-VALOR TO ACT-AGE-VALOR */
            AREA_DE_WORK.ACT_AGE_VALOR.Value = AREA_DE_WORK.ACT_AGE_VALOR + AREA_DE_WORK.AC_AGE_VALOR;

            /*" -883- ADD AC-AGE-FATOR TO ACT-AGE-FATOR */
            AREA_DE_WORK.ACT_AGE_FATOR.Value = AREA_DE_WORK.ACT_AGE_FATOR + AREA_DE_WORK.AC_AGE_FATOR;

            /*" -884- MOVE ZEROS TO AC-AGE-VALOR AC-AGE-FATOR. */
            _.Move(0, AREA_DE_WORK.AC_AGE_VALOR, AREA_DE_WORK.AC_AGE_FATOR);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-PROCESSA-DATA-SECTION */
        private void R1200_00_PROCESSA_DATA_SECTION()
        {
            /*" -897- MOVE '120' TO WNR-EXEC-SQL. */
            _.Move("120", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -898- MOVE V1COMI-DTMOVTO TO WHOST-DTINIVIG */
            _.Move(V1COMI_DTMOVTO, WHOST_DTINIVIG);

            /*" -900- PERFORM R2400-00-SELECT-V1MOEDA */

            R2400_00_SELECT_V1MOEDA_SECTION();

            /*" -901- IF V1COMI-DTMOVTO LESS '1994-07-01' */

            if (V1COMI_DTMOVTO < "1994-07-01")
            {

                /*" -904- COMPUTE V1COMI-VLCOMIS = V1COMI-VLCOMIS / 2750. */
                V1COMI_VLCOMIS.Value = V1COMI_VLCOMIS / 2750f;
            }


            /*" -905- IF V1COMI-OPERACAO EQUAL 1103 */

            if (V1COMI_OPERACAO == 1103)
            {

                /*" -908- COMPUTE V1COMI-VLCOMIS = V1COMI-VLCOMIS * - 1. */
                V1COMI_VLCOMIS.Value = V1COMI_VLCOMIS * -1;
            }


            /*" -909- ADD V1COMI-VLCOMIS TO AC-AGE-VALOR */
            AREA_DE_WORK.AC_AGE_VALOR.Value = AREA_DE_WORK.AC_AGE_VALOR + V1COMI_VLCOMIS;

            /*" -911- COMPUTE WWORK-VALOR = V1COMI-VLCOMIS / V1MOED-VLCRUZAD. */
            AREA_DE_WORK.WWORK_VALOR.Value = V1COMI_VLCOMIS / V1MOED_VLCRUZAD;

            /*" -915- ADD WWORK-VALOR TO AC-AGE-FATOR. */
            AREA_DE_WORK.AC_AGE_FATOR.Value = AREA_DE_WORK.AC_AGE_FATOR + AREA_DE_WORK.WWORK_VALOR;

            /*" -915- PERFORM R0910-00-FETCH-V2COMISSAO. */

            R0910_00_FETCH_V2COMISSAO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-SELECT-V1APOLICE-SECTION */
        private void R2100_00_SELECT_V1APOLICE_SECTION()
        {
            /*" -929- MOVE '210' TO WNR-EXEC-SQL. */
            _.Move("210", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -934- PERFORM R2100_00_SELECT_V1APOLICE_DB_SELECT_1 */

            R2100_00_SELECT_V1APOLICE_DB_SELECT_1();

            /*" -937- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -938- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -939- MOVE ZEROS TO V1APOL-CODCLIEN */
                    _.Move(0, V1APOL_CODCLIEN);

                    /*" -940- ELSE */
                }
                else
                {


                    /*" -941- DISPLAY 'ERRO ACESSO V1APOLICE' */
                    _.Display($"ERRO ACESSO V1APOLICE");

                    /*" -941- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2100-00-SELECT-V1APOLICE-DB-SELECT-1 */
        public void R2100_00_SELECT_V1APOLICE_DB_SELECT_1()
        {
            /*" -934- EXEC SQL SELECT CODCLIEN INTO :V1APOL-CODCLIEN FROM SEGUROS.V0APOLICE WHERE NUM_APOLICE = :V1RELA-NUM-APOL END-EXEC. */

            var r2100_00_SELECT_V1APOLICE_DB_SELECT_1_Query1 = new R2100_00_SELECT_V1APOLICE_DB_SELECT_1_Query1()
            {
                V1RELA_NUM_APOL = V1RELA_NUM_APOL.ToString(),
            };

            var executed_1 = R2100_00_SELECT_V1APOLICE_DB_SELECT_1_Query1.Execute(r2100_00_SELECT_V1APOLICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1APOL_CODCLIEN, V1APOL_CODCLIEN);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-SELECT-V1SUBGRUPO-SECTION */
        private void R2200_00_SELECT_V1SUBGRUPO_SECTION()
        {
            /*" -954- MOVE '220' TO WNR-EXEC-SQL. */
            _.Move("220", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -960- PERFORM R2200_00_SELECT_V1SUBGRUPO_DB_SELECT_1 */

            R2200_00_SELECT_V1SUBGRUPO_DB_SELECT_1();

            /*" -963- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -964- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -965- MOVE ZEROS TO V1SUBG-CODCLIEN */
                    _.Move(0, V1SUBG_CODCLIEN);

                    /*" -966- ELSE */
                }
                else
                {


                    /*" -967- DISPLAY 'ERRO ACESSO V1SUBGRUPO' */
                    _.Display($"ERRO ACESSO V1SUBGRUPO");

                    /*" -967- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2200-00-SELECT-V1SUBGRUPO-DB-SELECT-1 */
        public void R2200_00_SELECT_V1SUBGRUPO_DB_SELECT_1()
        {
            /*" -960- EXEC SQL SELECT COD_CLIENTE INTO :V1SUBG-CODCLIEN FROM SEGUROS.V0SUBGRUPO WHERE NUM_APOLICE = :V1RELA-NUM-APOL AND COD_SUBGRUPO = :V1COMI-CODSUBES END-EXEC. */

            var r2200_00_SELECT_V1SUBGRUPO_DB_SELECT_1_Query1 = new R2200_00_SELECT_V1SUBGRUPO_DB_SELECT_1_Query1()
            {
                V1RELA_NUM_APOL = V1RELA_NUM_APOL.ToString(),
                V1COMI_CODSUBES = V1COMI_CODSUBES.ToString(),
            };

            var executed_1 = R2200_00_SELECT_V1SUBGRUPO_DB_SELECT_1_Query1.Execute(r2200_00_SELECT_V1SUBGRUPO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SUBG_CODCLIEN, V1SUBG_CODCLIEN);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-SELECT-V1CLIENTE-SECTION */
        private void R2300_00_SELECT_V1CLIENTE_SECTION()
        {
            /*" -980- MOVE '230' TO WNR-EXEC-SQL. */
            _.Move("230", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -985- PERFORM R2300_00_SELECT_V1CLIENTE_DB_SELECT_1 */

            R2300_00_SELECT_V1CLIENTE_DB_SELECT_1();

            /*" -988- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -989- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -990- MOVE SPACES TO V1CLIE-NOME */
                    _.Move("", V1CLIE_NOME);

                    /*" -991- ELSE */
                }
                else
                {


                    /*" -992- DISPLAY 'ERRO ACESSO V1CLIENTE' */
                    _.Display($"ERRO ACESSO V1CLIENTE");

                    /*" -992- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2300-00-SELECT-V1CLIENTE-DB-SELECT-1 */
        public void R2300_00_SELECT_V1CLIENTE_DB_SELECT_1()
        {
            /*" -985- EXEC SQL SELECT NOME_RAZAO INTO :V1CLIE-NOME FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = :WHOST-CODCLIEN END-EXEC. */

            var r2300_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1 = new R2300_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1()
            {
                WHOST_CODCLIEN = WHOST_CODCLIEN.ToString(),
            };

            var executed_1 = R2300_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1.Execute(r2300_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1CLIE_NOME, V1CLIE_NOME);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-SELECT-V1MOEDA-SECTION */
        private void R2400_00_SELECT_V1MOEDA_SECTION()
        {
            /*" -1005- MOVE '240' TO WNR-EXEC-SQL. */
            _.Move("240", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1012- PERFORM R2400_00_SELECT_V1MOEDA_DB_SELECT_1 */

            R2400_00_SELECT_V1MOEDA_DB_SELECT_1();

            /*" -1015- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1016- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1017- MOVE 1 TO V1MOED-VLCRUZAD */
                    _.Move(1, V1MOED_VLCRUZAD);

                    /*" -1018- ELSE */
                }
                else
                {


                    /*" -1019- DISPLAY 'PROBLEMAS SELECT V1MOEDA ... ' */
                    _.Display($"PROBLEMAS SELECT V1MOEDA ... ");

                    /*" -1019- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2400-00-SELECT-V1MOEDA-DB-SELECT-1 */
        public void R2400_00_SELECT_V1MOEDA_DB_SELECT_1()
        {
            /*" -1012- EXEC SQL SELECT VLCRUZAD INTO :V1MOED-VLCRUZAD FROM SEGUROS.V1MOEDA WHERE CODUNIMO = :V1RELA-CODUNIMO AND DTINIVIG <= :WHOST-DTINIVIG AND DTTERVIG >= :WHOST-DTINIVIG END-EXEC. */

            var r2400_00_SELECT_V1MOEDA_DB_SELECT_1_Query1 = new R2400_00_SELECT_V1MOEDA_DB_SELECT_1_Query1()
            {
                V1RELA_CODUNIMO = V1RELA_CODUNIMO.ToString(),
                WHOST_DTINIVIG = WHOST_DTINIVIG.ToString(),
            };

            var executed_1 = R2400_00_SELECT_V1MOEDA_DB_SELECT_1_Query1.Execute(r2400_00_SELECT_V1MOEDA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1MOED_VLCRUZAD, V1MOED_VLCRUZAD);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R5000-00-CABECALHOS-SECTION */
        private void R5000_00_CABECALHOS_SECTION()
        {
            /*" -1031- MOVE '500' TO WNR-EXEC-SQL. */
            _.Move("500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1032- ADD 1 TO AC-PAGINA */
            AREA_DE_WORK.AC_PAGINA.Value = AREA_DE_WORK.AC_PAGINA + 1;

            /*" -1033- MOVE AC-PAGINA TO LC01-PAGINA */
            _.Move(AREA_DE_WORK.AC_PAGINA, AREA_DE_WORK.LC01.LC01_PAGINA);

            /*" -1035- MOVE ZEROS TO AC-LINHAS */
            _.Move(0, AREA_DE_WORK.AC_LINHAS);

            /*" -1036- WRITE REG-VG0283B FROM LC01 AFTER PAGE */
            _.Move(AREA_DE_WORK.LC01.GetMoveValues(), REG_VG0283B);

            RVG0283B.Write(REG_VG0283B.GetMoveValues().ToString());

            /*" -1037- WRITE REG-VG0283B FROM LC02 AFTER 1 */
            _.Move(AREA_DE_WORK.LC02.GetMoveValues(), REG_VG0283B);

            RVG0283B.Write(REG_VG0283B.GetMoveValues().ToString());

            /*" -1038- WRITE REG-VG0283B FROM LC03 AFTER 1 */
            _.Move(AREA_DE_WORK.LC03.GetMoveValues(), REG_VG0283B);

            RVG0283B.Write(REG_VG0283B.GetMoveValues().ToString());

            /*" -1039- WRITE REG-VG0283B FROM LC03A AFTER 1 */
            _.Move(AREA_DE_WORK.LC03A.GetMoveValues(), REG_VG0283B);

            RVG0283B.Write(REG_VG0283B.GetMoveValues().ToString());

            /*" -1040- WRITE REG-VG0283B FROM LC04 AFTER 1 */
            _.Move(AREA_DE_WORK.LC04.GetMoveValues(), REG_VG0283B);

            RVG0283B.Write(REG_VG0283B.GetMoveValues().ToString());

            /*" -1041- WRITE REG-VG0283B FROM LC05 AFTER 1 */
            _.Move(AREA_DE_WORK.LC05.GetMoveValues(), REG_VG0283B);

            RVG0283B.Write(REG_VG0283B.GetMoveValues().ToString());

            /*" -1042- WRITE REG-VG0283B FROM LC06 AFTER 1 */
            _.Move(AREA_DE_WORK.LC06.GetMoveValues(), REG_VG0283B);

            RVG0283B.Write(REG_VG0283B.GetMoveValues().ToString());

            /*" -1043- WRITE REG-VG0283B FROM LC07 AFTER 1 */
            _.Move(AREA_DE_WORK.LC07.GetMoveValues(), REG_VG0283B);

            RVG0283B.Write(REG_VG0283B.GetMoveValues().ToString());

            /*" -1044- WRITE REG-VG0283B FROM LC08 AFTER 1 */
            _.Move(AREA_DE_WORK.LC08.GetMoveValues(), REG_VG0283B);

            RVG0283B.Write(REG_VG0283B.GetMoveValues().ToString());

            /*" -1044- WRITE REG-VG0283B FROM LC07 AFTER 1. */
            _.Move(AREA_DE_WORK.LC07.GetMoveValues(), REG_VG0283B);

            RVG0283B.Write(REG_VG0283B.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_99_SAIDA*/

        [StopWatch]
        /*" R8000-00-OPEN-ARQUIVOS-SECTION */
        private void R8000_00_OPEN_ARQUIVOS_SECTION()
        {
            /*" -1057- MOVE '800' TO WNR-EXEC-SQL. */
            _.Move("800", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1057- OPEN OUTPUT RVG0283B. */
            RVG0283B.Open(REG_VG0283B);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-CLOSE-ARQUIVOS-SECTION */
        private void R9000_00_CLOSE_ARQUIVOS_SECTION()
        {
            /*" -1070- MOVE '900' TO WNR-EXEC-SQL. */
            _.Move("900", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1070- CLOSE RVG0283B. */
            RVG0283B.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1085- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -1087- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -1089- CLOSE RVG0283B */
            RVG0283B.Close();

            /*" -1089- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1091- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1095- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1095- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}