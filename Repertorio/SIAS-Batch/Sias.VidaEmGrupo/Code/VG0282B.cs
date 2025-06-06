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
using Sias.VidaEmGrupo.DB2.VG0282B;

namespace Code
{
    public class VG0282B
    {
        public bool IsCall { get; set; }

        public VG0282B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................ VIDA EM GRUPO                       *      */
        /*"      *   PROGRAMA ............... VG0282B                             *      */
        /*"      *   ANALISTA ............... PROCAS                              *      */
        /*"      *   PROGRAMADOR ............ PROCAS / VANDO                      *      */
        /*"      *   DATA CODIFICACAO ....... SETEMBRO / 1994                     *      */
        /*"      *   FUNCAO ................. DEMONSTRATIVO DE EXCEDENTE TECNICO  *      */
        /*"      *                            COBRANCA DE PREMIOS                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                             VIEW              ACESSO    *      */
        /*"      * SISTEMAS                           V1SISTEMA         INPUT     *      */
        /*"      * RELATORIOS                         V1RELATORIOS      I-O       *      */
        /*"      * ENDOSSOS                           V1ENDOSSO         INPUT     *      */
        /*"      * HISTORICO DE PARCELAS              V1HISTOPARC       INPUT     *      */
        /*"      * COMISSOES                          V1COMISSAO        INPUT     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *        A L T E R A C O E S                                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * RECONVERSAO ANO 2000            CONSEDA4           11/09/1998  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  001 - 17/08/01 - MANOEL MESSIAS                               *      */
        /*"      *                                                                *      */
        /*"      *   PASSA A IDENTIFICAR A SITUACAO DO ENDOSSO ASSIM:             *      */
        /*"      *   E - ENDOSSO PENDENTE OU EMITIDO                              *      */
        /*"      *   P - ENDOSSO PAGO                                             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _RVG0282B { get; set; } = new FileBasis(new PIC("X", "132", "X(132)"));

        public FileBasis RVG0282B
        {
            get
            {
                _.Move(REG_VG0282B, _RVG0282B); VarBasis.RedefinePassValue(REG_VG0282B, _RVG0282B, REG_VG0282B); return _RVG0282B;
            }
        }
        /*"01                  REG-VG0282B        PIC  X(132).*/
        public StringBasis REG_VG0282B { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77         VIND-DTMOVTO        PIC S9(004)        COMP.*/
        public IntBasis VIND_DTMOVTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-DTINIVIG      PIC  X(010).*/
        public StringBasis WHOST_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WS-DATA-ADM         PIC  X(010).*/
        public StringBasis WS_DATA_ADM { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WS-DATA-COR         PIC  X(010).*/
        public StringBasis WS_DATA_COR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WHOST-CODCLIEN      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis WHOST_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1SIST-DTMOVABE     PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-DTCURRENT    PIC  X(010).*/
        public StringBasis V1SIST_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
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
        /*"77          V0MOED-SIGLUNIM   PIC  X(006).*/
        public StringBasis V0MOED_SIGLUNIM { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
        /*"77         V1ENDO-NUM-APOL    PIC S9(013)        VALUE +0 COMP-3*/
        public IntBasis V1ENDO_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1ENDO-NRENDOS     PIC S9(009)        VALUE +0 COMP.*/
        public IntBasis V1ENDO_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1ENDO-CODSUBES    PIC S9(004)        VALUE +0 COMP.*/
        public IntBasis V1ENDO_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-DTINIVIG    PIC  X(010).*/
        public StringBasis V1ENDO_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1ENDO-DTTERVIG    PIC  X(010).*/
        public StringBasis V1ENDO_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1ENDO-SITUACAO    PIC  X(001).*/
        public StringBasis V1ENDO_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1HISP-OPERACAO     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1HISP_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1HISP-DTMOVTO      PIC  X(010).*/
        public StringBasis V1HISP_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1HISP-VLPRMLIQ     PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V1HISP_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1HISP-DTQITBCO     PIC  X(010).*/
        public StringBasis V1HISP_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         VIND-DTQITBCO       PIC S9(004)                COMP.*/
        public IntBasis VIND_DTQITBCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COMI-OPERACAO    PIC S9(004)        VALUE +0 COMP.*/
        public IntBasis V1COMI_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COMI-VLCOMIS     PIC S9(013)V99     VALUE +0 COMP-3*/
        public DoubleBasis V1COMI_VLCOMIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1COMI-DATCLO      PIC  X(010).*/
        public StringBasis V1COMI_DATCLO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1COMI-TIPCOM      PIC  X(001).*/
        public StringBasis V1COMI_TIPCOM { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1COMI-DTMOVTO     PIC  X(010).*/
        public StringBasis V1COMI_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1COMI-VLVARMON    PIC S9(013)V99     VALUE +0 COMP-3*/
        public DoubleBasis V1COMI_VLVARMON { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1COMI-NRENDOS     PIC S9(009)        VALUE +0 COMP.*/
        public IntBasis V1COMI_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1SUBG-CODCLIEN    PIC S9(009)        VALUE +0 COMP.*/
        public IntBasis V1SUBG_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1APOL-CODCLIEN    PIC S9(009)        VALUE +0 COMP.*/
        public IntBasis V1APOL_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1CLIE-NOME        PIC  X(040).*/
        public StringBasis V1CLIE_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"01           AREA-DE-WORK.*/
        public VG0282B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VG0282B_AREA_DE_WORK();
        public class VG0282B_AREA_DE_WORK : VarBasis
        {
            /*"  05         WSL-SQLCODE       PIC  9(009)      VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WCH-FINAL         PIC  X(001)      VALUE SPACES.*/
            public StringBasis WCH_FINAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1SISTEMA    PIC  X(001)      VALUE SPACES.*/
            public StringBasis WFIM_V1SISTEMA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1EMPRESA    PIC  X(001)      VALUE SPACES.*/
            public StringBasis WFIM_V1EMPRESA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1ENDOSSO    PIC  X(001)      VALUE SPACES.*/
            public StringBasis WFIM_V1ENDOSSO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1HISTOPARC  PIC  X(001)      VALUE SPACES.*/
            public StringBasis WFIM_V1HISTOPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1COMISSAO   PIC  X(001)      VALUE SPACES.*/
            public StringBasis WFIM_V1COMISSAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1MOEDA      PIC  X(001)      VALUE SPACES.*/
            public StringBasis WFIM_V1MOEDA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1RELATOR    PIC  X(001)      VALUE SPACES.*/
            public StringBasis WFIM_V1RELATOR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WTEM-V1HISTOPARC  PIC  X(001)      VALUE SPACES.*/
            public StringBasis WTEM_V1HISTOPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WTEM-V1COMISSAO   PIC  X(001)      VALUE SPACES.*/
            public StringBasis WTEM_V1COMISSAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WTEM-V1RELATOR    PIC  X(001)      VALUE SPACES.*/
            public StringBasis WTEM_V1RELATOR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         AC-LINHAS         PIC  9(002)      VALUE  80.*/
            public IntBasis AC_LINHAS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 80);
            /*"  05         AC-PAGINA         PIC  9(004)      VALUE  ZEROS.*/
            public IntBasis AC_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         CH-CHAVE-ATU.*/
            public VG0282B_CH_CHAVE_ATU CH_CHAVE_ATU { get; set; } = new VG0282B_CH_CHAVE_ATU();
            public class VG0282B_CH_CHAVE_ATU : VarBasis
            {
                /*"    10       CH-CODSB-ATU      PIC  9(005)      VALUE  ZEROS.*/
                public IntBasis CH_CODSB_ATU { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
                /*"    10       CH-VIGEN-ATU      PIC  X(010)      VALUE  ZEROS.*/
                public StringBasis CH_VIGEN_ATU { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  05         CH-CHAVE-ANT.*/
            }
            public VG0282B_CH_CHAVE_ANT CH_CHAVE_ANT { get; set; } = new VG0282B_CH_CHAVE_ANT();
            public class VG0282B_CH_CHAVE_ANT : VarBasis
            {
                /*"    10       CH-CODSB-ANT      PIC  9(005)      VALUE  ZEROS.*/
                public IntBasis CH_CODSB_ANT { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
                /*"    10       CH-VIGEN-ANT      PIC  X(010)      VALUE  ZEROS.*/
                public StringBasis CH_VIGEN_ANT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  05         CH-NAPOL-ANT      PIC  9(013)      VALUE  ZEROS.*/
            }
            public IntBasis CH_NAPOL_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  05         WWORK-VALOR       PIC S9(013)V9(5) VALUE +0  COMP-3*/
            public DoubleBasis WWORK_VALOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"  05         WWORK-VALOR1      PIC S9(013)V9(5) VALUE +0  COMP-3*/
            public DoubleBasis WWORK_VALOR1 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"  05         AC-PRM-VALOR      PIC S9(013)V99   VALUE +0  COMP-3*/
            public DoubleBasis AC_PRM_VALOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         AC-PRM-FATOR      PIC S9(013)V9(5) VALUE +0  COMP-3*/
            public DoubleBasis AC_PRM_FATOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"  05         AC-EMI-VALOR      PIC S9(013)V99   VALUE +0  COMP-3*/
            public DoubleBasis AC_EMI_VALOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         AC-EMI-FATOR      PIC S9(013)V9(5) VALUE +0  COMP-3*/
            public DoubleBasis AC_EMI_FATOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"  05         AC-COB-VALOR      PIC S9(013)V99   VALUE +0  COMP-3*/
            public DoubleBasis AC_COB_VALOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         AC-COB-FATOR      PIC S9(013)V9(5) VALUE +0  COMP-3*/
            public DoubleBasis AC_COB_FATOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"  05         AC-ADM-VALOR      PIC S9(013)V99   VALUE +0  COMP-3*/
            public DoubleBasis AC_ADM_VALOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         AC-ADM-FATOR      PIC S9(013)V9(5) VALUE +0  COMP-3*/
            public DoubleBasis AC_ADM_FATOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"  05         AC-COR-VALOR      PIC S9(013)V99   VALUE +0  COMP-3*/
            public DoubleBasis AC_COR_VALOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         AC-COR-FATOR      PIC S9(013)V9(5) VALUE +0  COMP-3*/
            public DoubleBasis AC_COR_FATOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"  05         ACT-PRM-VALOR     PIC S9(013)V99   VALUE +0  COMP-3*/
            public DoubleBasis ACT_PRM_VALOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         ACT-PRM-FATOR     PIC S9(013)V9(5) VALUE +0  COMP-3*/
            public DoubleBasis ACT_PRM_FATOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"  05         ACT-ADM-VALOR     PIC S9(013)V99   VALUE +0  COMP-3*/
            public DoubleBasis ACT_ADM_VALOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         ACT-ADM-FATOR     PIC S9(013)V9(5) VALUE +0  COMP-3*/
            public DoubleBasis ACT_ADM_FATOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"  05         ACT-COR-VALOR     PIC S9(013)V99   VALUE +0  COMP-3*/
            public DoubleBasis ACT_COR_VALOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         ACT-COR-FATOR     PIC S9(013)V9(5) VALUE +0  COMP-3*/
            public DoubleBasis ACT_COR_FATOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"  05         ACG-PRM-VALOR     PIC S9(013)V99   VALUE +0  COMP-3*/
            public DoubleBasis ACG_PRM_VALOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         ACG-PRM-FATOR     PIC S9(013)V9(5) VALUE +0  COMP-3*/
            public DoubleBasis ACG_PRM_FATOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"  05         ACG-ADM-VALOR     PIC S9(013)V99   VALUE +0  COMP-3*/
            public DoubleBasis ACG_ADM_VALOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         ACG-ADM-FATOR     PIC S9(013)V9(5) VALUE +0  COMP-3*/
            public DoubleBasis ACG_ADM_FATOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"  05         ACG-COR-VALOR     PIC S9(013)V99   VALUE +0  COMP-3*/
            public DoubleBasis ACG_COR_VALOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         ACG-COR-FATOR     PIC S9(013)V9(5) VALUE +0  COMP-3*/
            public DoubleBasis ACG_COR_FATOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"  05         ACA-PRM-VALOR     PIC S9(013)V99   VALUE +0  COMP-3*/
            public DoubleBasis ACA_PRM_VALOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         ACA-PRM-FATOR     PIC S9(013)V9(5) VALUE +0  COMP-3*/
            public DoubleBasis ACA_PRM_FATOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"  05         ACA-ADM-VALOR     PIC S9(013)V99   VALUE +0  COMP-3*/
            public DoubleBasis ACA_ADM_VALOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         ACA-ADM-FATOR     PIC S9(013)V9(5) VALUE +0  COMP-3*/
            public DoubleBasis ACA_ADM_FATOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"  05         ACA-COR-VALOR     PIC S9(013)V99   VALUE +0  COMP-3*/
            public DoubleBasis ACA_COR_VALOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         ACA-COR-FATOR     PIC S9(013)V9(5) VALUE +0  COMP-3*/
            public DoubleBasis ACA_COR_FATOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"  05         WDATA-CURR.*/
            public VG0282B_WDATA_CURR WDATA_CURR { get; set; } = new VG0282B_WDATA_CURR();
            public class VG0282B_WDATA_CURR : VarBasis
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
                /*"    05          HORA-1              PIC 99999999.*/
                public IntBasis HORA_1 { get; set; } = new IntBasis(new PIC("9", "8", "99999999."));
                /*"    05          WHORA-PER-X REDEFINES HORA-1.*/
                private _REDEF_VG0282B_WHORA_PER_X _whora_per_x { get; set; }
                public _REDEF_VG0282B_WHORA_PER_X WHORA_PER_X
                {
                    get { _whora_per_x = new _REDEF_VG0282B_WHORA_PER_X(); _.Move(HORA_1, _whora_per_x); VarBasis.RedefinePassValue(HORA_1, _whora_per_x, HORA_1); _whora_per_x.ValueChanged += () => { _.Move(_whora_per_x, HORA_1); }; return _whora_per_x; }
                    set { VarBasis.RedefinePassValue(value, _whora_per_x, HORA_1); }
                }  //Redefines
                public class _REDEF_VG0282B_WHORA_PER_X : VarBasis
                {
                    /*"       10       HORA-2              PIC 999999.*/
                    public IntBasis HORA_2 { get; set; } = new IntBasis(new PIC("9", "6", "999999."));
                    /*"       10       FILLER              PIC 99.*/
                    public IntBasis FILLER_2 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"  05         WHORA-CURR.*/

                    public _REDEF_VG0282B_WHORA_PER_X()
                    {
                        HORA_2.ValueChanged += OnValueChanged;
                        FILLER_2.ValueChanged += OnValueChanged;
                    }

                }
            }
            public VG0282B_WHORA_CURR WHORA_CURR { get; set; } = new VG0282B_WHORA_CURR();
            public class VG0282B_WHORA_CURR : VarBasis
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
            public VG0282B_WDATA_CABEC WDATA_CABEC { get; set; } = new VG0282B_WDATA_CABEC();
            public class VG0282B_WDATA_CABEC : VarBasis
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
                /*"  05         WHORA-CABEC.*/
            }
            public VG0282B_WHORA_CABEC WHORA_CABEC { get; set; } = new VG0282B_WHORA_CABEC();
            public class VG0282B_WHORA_CABEC : VarBasis
            {
                /*"    10       WHORA-HH-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_HH_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '.'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10       WHORA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '.'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10       WHORA-SS-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_SS_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WDATA-VIGENCIA.*/
            }
            public VG0282B_WDATA_VIGENCIA WDATA_VIGENCIA { get; set; } = new VG0282B_WDATA_VIGENCIA();
            public class VG0282B_WDATA_VIGENCIA : VarBasis
            {
                /*"    10       WDATA-VIG-ANO     PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDATA_VIG_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10       FILLER            PIC  X(001)    VALUE SPACES.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WDATA-VIG-MES     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_VIG_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE SPACES.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WDATA-VIG-DIA     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_VIG_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05            LC01.*/
            }
            public VG0282B_LC01 LC01 { get; set; } = new VG0282B_LC01();
            public class VG0282B_LC01 : VarBasis
            {
                /*"    10          LC01-RELATOR   PIC  X(010) VALUE 'VG0282B.1'.*/
                public StringBasis LC01_RELATOR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VG0282B.1");
                /*"    10          FILLER         PIC  X(033) VALUE  SPACES.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "33", "X(033)"), @"");
                /*"    10          LC01-EMPRESA   PIC  X(040) VALUE  SPACES.*/
                public StringBasis LC01_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    10          FILLER         PIC  X(036) VALUE  SPACES.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"");
                /*"    10          FILLER         PIC  X(009) VALUE 'PAGINA'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"PAGINA");
                /*"    10          LC01-PAGINA    PIC  ZZZ9.*/
                public IntBasis LC01_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
                /*"  05            LC02.*/
            }
            public VG0282B_LC02 LC02 { get; set; } = new VG0282B_LC02();
            public class VG0282B_LC02 : VarBasis
            {
                /*"    10          FILLER         PIC  X(117) VALUE  SPACES.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "117", "X(117)"), @"");
                /*"    10          FILLER         PIC  X(005) VALUE 'DATA'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"DATA");
                /*"    10          LC02-DATA      PIC  X(010) VALUE  SPACES.*/
                public StringBasis LC02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  05            LC03.*/
            }
            public VG0282B_LC03 LC03 { get; set; } = new VG0282B_LC03();
            public class VG0282B_LC03 : VarBasis
            {
                /*"    10          FILLER         PIC  X(033) VALUE SPACES.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "33", "X(033)"), @"");
                /*"    10          FILLER         PIC  X(038) VALUE               'DEMONSTRATIVO DE EXCEDENTE TECNICO DE '.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "38", "X(038)"), @"DEMONSTRATIVO DE EXCEDENTE TECNICO DE ");
                /*"    10          LC03-DIA-INI   PIC  9(002) VALUE  ZEROS.*/
                public IntBasis LC03_DIA_INI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          FILLER         PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LC03-MES-INI   PIC  9(002) VALUE  ZEROS.*/
                public IntBasis LC03_MES_INI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          FILLER         PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LC03-ANO-INI   PIC  9(004) VALUE  ZEROS.*/
                public IntBasis LC03_ANO_INI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10          FILLER         PIC  X(003) VALUE ' A '.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" A ");
                /*"    10          LC03-DIA-TER   PIC  9(002) VALUE  ZEROS.*/
                public IntBasis LC03_DIA_TER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          FILLER         PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LC03-MES-TER   PIC  9(002) VALUE  ZEROS.*/
                public IntBasis LC03_MES_TER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          FILLER         PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LC03-ANO-TER   PIC  9(004) VALUE  ZEROS.*/
                public IntBasis LC03_ANO_TER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10          FILLER         PIC  X(023) VALUE  SPACES.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"");
                /*"    10          FILLER         PIC  X(007) VALUE 'HORA'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"HORA");
                /*"    10          LC03-HORA      PIC  X(008) VALUE  SPACES.*/
                public StringBasis LC03_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"  05            LC04.*/
            }
            public VG0282B_LC04 LC04 { get; set; } = new VG0282B_LC04();
            public class VG0282B_LC04 : VarBasis
            {
                /*"    10          FILLER         PIC  X(016) VALUE 'ESTIPULANTE'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"ESTIPULANTE");
                /*"    10          LC04-ESTIPUL   PIC  X(040) VALUE  SPACES.*/
                public StringBasis LC04_ESTIPUL { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"  05            LC05.*/
            }
            public VG0282B_LC05 LC05 { get; set; } = new VG0282B_LC05();
            public class VG0282B_LC05 : VarBasis
            {
                /*"    10          FILLER         PIC  X(016) VALUE 'SUB ESTIPULANTE               ' '.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"SUB ESTIPULANTE               ");
                /*"    10          LC05-CODSUBES  PIC  9(005) VALUE  ZEROS.*/
                public IntBasis LC05_CODSUBES { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
                /*"    10          FILLER         PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10          LC05-SUBEST    PIC  X(040) VALUE  SPACES.*/
                public StringBasis LC05_SUBEST { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"  05            LC06.*/
            }
            public VG0282B_LC06 LC06 { get; set; } = new VG0282B_LC06();
            public class VG0282B_LC06 : VarBasis
            {
                /*"    10          FILLER         PIC  X(016) VALUE 'APOLICE'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"APOLICE");
                /*"    10          LC06-NUM-APOL  PIC  9(013) VALUE  ZEROS.*/
                public IntBasis LC06_NUM_APOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
                /*"    10          FILLER         PIC  X(071) VALUE  SPACES.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "71", "X(071)"), @"");
                /*"    10          FILLER         PIC  X(021) VALUE                               'FATORES EXPRESSOS EM '.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"FATORES EXPRESSOS EM ");
                /*"    10          LC06-MOEDA     PIC  X(010) VALUE  SPACES.*/
                public StringBasis LC06_MOEDA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  05            LC07.*/
            }
            public VG0282B_LC07 LC07 { get; set; } = new VG0282B_LC07();
            public class VG0282B_LC07 : VarBasis
            {
                /*"    10          FILLER         PIC  X(132) VALUE  ALL '-'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
                /*"  05            LC08.*/
            }
            public VG0282B_LC08 LC08 { get; set; } = new VG0282B_LC08();
            public class VG0282B_LC08 : VarBasis
            {
                /*"    10          FILLER         PIC  X(008) VALUE 'PERIODO'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"PERIODO");
                /*"    10          FILLER         PIC  X(008) VALUE 'ENDOSSO'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"ENDOSSO");
                /*"    10          FILLER         PIC  X(008) VALUE 'QUITACAO'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"QUITACAO");
                /*"    10          FILLER         PIC  X(017) VALUE SPACES.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"");
                /*"    10          FILLER         PIC  X(014) VALUE 'PREMIO'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"PREMIO");
                /*"    10          FILLER         PIC  X(021) VALUE 'QUITACAO'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"QUITACAO");
                /*"    10          FILLER         PIC  X(018) VALUE 'ADMINISTRACAO'*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"ADMINISTRACAO");
                /*"    10          FILLER         PIC  X(023) VALUE 'QUITACAO'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"QUITACAO");
                /*"    10          FILLER         PIC  X(010) VALUE 'CORRETAGEM'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"CORRETAGEM");
                /*"  05            LC09.*/
            }
            public VG0282B_LC09 LC09 { get; set; } = new VG0282B_LC09();
            public class VG0282B_LC09 : VarBasis
            {
                /*"    10          FILLER         PIC  X(008) VALUE  SPACES.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"    10          FILLER         PIC  X(008) VALUE  'SIT.    '.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"SIT.    ");
                /*"    10          FILLER         PIC  X(007) VALUE  'ENDOSSO'.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"ENDOSSO");
                /*"    10          FILLER         PIC  X(011) VALUE  SPACES.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"");
                /*"    10          FILLER         PIC  X(020) VALUE 'VALOR               'FATOR'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"VALOR               ");
                /*"    10          FILLER         PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          FILLER         PIC  X(008) VALUE 'ADMINIST'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"ADMINIST");
                /*"    10          FILLER         PIC  X(010) VALUE SPACES.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10          FILLER         PIC  X(020) VALUE 'VALOR               'FATOR'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"VALOR               ");
                /*"    10          FILLER         PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          FILLER         PIC  X(008) VALUE 'CORRETOR'.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"CORRETOR");
                /*"    10          FILLER         PIC  X(010) VALUE SPACES.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10          FILLER         PIC  X(026) VALUE 'VALOR               'FATOR'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"VALOR               ");
                /*"  05            LD01.*/
            }
            public VG0282B_LD01 LD01 { get; set; } = new VG0282B_LD01();
            public class VG0282B_LD01 : VarBasis
            {
                /*"    10          FILLER         PIC  X(001) VALUE  SPACES.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          LD01-MES-VIG   PIC  X(004) VALUE  SPACES.*/
                public StringBasis LD01_MES_VIG { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10          LD01-ANO-VIG   PIC  9(004) VALUE  ZEROS.*/
                public IntBasis LD01_ANO_VIG { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10          FILLER         PIC  X(001) VALUE  SPACES.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          LD01-NRENDOS   PIC  9(006) VALUE  ZEROS.*/
                public IntBasis LD01_NRENDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
                /*"    10          LD01-SITUACAO  PIC  X(001) VALUE  SPACE.*/
                public StringBasis LD01_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          FILLER         PIC  X(001) VALUE  SPACE.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          LD01-DIA-PGT   PIC  9(002) VALUE  ZEROS.*/
                public IntBasis LD01_DIA_PGT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          FILLER         PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LD01-MES-PGT   PIC  9(002) VALUE  ZEROS.*/
                public IntBasis LD01_MES_PGT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          FILLER         PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LD01-ANO-PGT   PIC  9(004) VALUE  ZEROS.*/
                public IntBasis LD01_ANO_PGT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10          FILLER         PIC  X(001) VALUE  SPACES.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          LD01-VLR-PRM   PIC  Z.ZZZ.ZZ9,99.*/
                public DoubleBasis LD01_VLR_PRM { get; set; } = new DoubleBasis(new PIC("9", "7", "Z.ZZZ.ZZ9V99."), 2);
                /*"    10          FILLER         PIC  X(001) VALUE  SPACES.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          LD01-FAT-PRM   PIC  Z.ZZZ.ZZ9,99.*/
                public DoubleBasis LD01_FAT_PRM { get; set; } = new DoubleBasis(new PIC("9", "7", "Z.ZZZ.ZZ9V99."), 2);
                /*"    10          FILLER         PIC  X(001) VALUE  SPACES.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          LD01-DIA-PGT1  PIC  9(002) BLANK WHEN ZEROS.*/
                public IntBasis LD01_DIA_PGT1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          LD01-BARRA1    PIC  X(001) VALUE '/'.*/
                public StringBasis LD01_BARRA1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LD01-MES-PGT1  PIC  9(002) BLANK WHEN ZEROS.*/
                public IntBasis LD01_MES_PGT1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          LD01-BARRA2    PIC  X(001) VALUE '/'.*/
                public StringBasis LD01_BARRA2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LD01-ANO-PGT1  PIC  9(004) BLANK WHEN ZEROS.*/
                public IntBasis LD01_ANO_PGT1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10          FILLER         PIC  X(001) VALUE  SPACES.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          LD01-VLR-ADM   PIC  ZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LD01_VLR_ADM { get; set; } = new DoubleBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9V99."), 2);
                /*"    10          FILLER         PIC  X(001) VALUE  SPACES.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          LD01-FAT-ADM   PIC  ZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LD01_FAT_ADM { get; set; } = new DoubleBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9V99."), 2);
                /*"    10          FILLER         PIC  X(001) VALUE  SPACES.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          LD01-DIA-PGT2  PIC  9(002) BLANK WHEN ZEROS.*/
                public IntBasis LD01_DIA_PGT2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          LD01-BARRA3    PIC  X(001) VALUE '/'.*/
                public StringBasis LD01_BARRA3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LD01-MES-PGT2  PIC  9(002) BLANK WHEN ZEROS.*/
                public IntBasis LD01_MES_PGT2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          LD01-BARRA4    PIC  X(001) VALUE '/'.*/
                public StringBasis LD01_BARRA4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LD01-ANO-PGT2  PIC  9(004) BLANK WHEN ZEROS.*/
                public IntBasis LD01_ANO_PGT2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10          FILLER         PIC  X(001) VALUE  SPACES.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          LD01-VLR-COR   PIC  ZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LD01_VLR_COR { get; set; } = new DoubleBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9V99."), 2);
                /*"    10          FILLER         PIC  X(001) VALUE  SPACES.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          LD01-FAT-COR   PIC  ZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LD01_FAT_COR { get; set; } = new DoubleBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9V99."), 2);
                /*"  05            LD02.*/
            }
            public VG0282B_LD02 LD02 { get; set; } = new VG0282B_LD02();
            public class VG0282B_LD02 : VarBasis
            {
                /*"    10          FILLER         PIC  X(001) VALUE  SPACES.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          LD02-TITULO    PIC  X(023) VALUE  SPACES.*/
                public StringBasis LD02_TITULO { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"");
                /*"    10          LD02-VLR-PRM   PIC  ZZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LD02_VLR_PRM { get; set; } = new DoubleBasis(new PIC("9", "10", "ZZZZ.ZZZ.ZZ9V99."), 2);
                /*"    10          LD02-FAT-PRM   PIC  ZZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LD02_FAT_PRM { get; set; } = new DoubleBasis(new PIC("9", "10", "ZZZZ.ZZZ.ZZ9V99."), 2);
                /*"    10          FILLER         PIC  X(009) VALUE  SPACES.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
                /*"    10          LD02-VLR-ADM   PIC  ZZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LD02_VLR_ADM { get; set; } = new DoubleBasis(new PIC("9", "10", "ZZZZ.ZZZ.ZZ9V99."), 2);
                /*"    10          LD02-FAT-ADM   PIC  ZZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LD02_FAT_ADM { get; set; } = new DoubleBasis(new PIC("9", "10", "ZZZZ.ZZZ.ZZ9V99."), 2);
                /*"    10          FILLER         PIC  X(009) VALUE  SPACES.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
                /*"    10          LD02-VLR-COR   PIC  ZZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LD02_VLR_COR { get; set; } = new DoubleBasis(new PIC("9", "10", "ZZZZ.ZZZ.ZZ9V99."), 2);
                /*"    10          LD02-FAT-COR   PIC  ZZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LD02_FAT_COR { get; set; } = new DoubleBasis(new PIC("9", "10", "ZZZZ.ZZZ.ZZ9V99."), 2);
                /*"  05            TABELA-MESES.*/
            }
            public VG0282B_TABELA_MESES TABELA_MESES { get; set; } = new VG0282B_TABELA_MESES();
            public class VG0282B_TABELA_MESES : VarBasis
            {
                /*"    10          FILLER          PIC X(004)  VALUE 'JAN/'.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"JAN/");
                /*"    10          FILLER          PIC X(004)  VALUE 'FEV/'.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"FEV/");
                /*"    10          FILLER          PIC X(004)  VALUE 'MAR/'.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"MAR/");
                /*"    10          FILLER          PIC X(004)  VALUE 'ABR/'.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"ABR/");
                /*"    10          FILLER          PIC X(004)  VALUE 'MAI/'.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"MAI/");
                /*"    10          FILLER          PIC X(004)  VALUE 'JUN/'.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"JUN/");
                /*"    10          FILLER          PIC X(004)  VALUE 'JUL/'.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"JUL/");
                /*"    10          FILLER          PIC X(004)  VALUE 'AGO/'.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"AGO/");
                /*"    10          FILLER          PIC X(004)  VALUE 'SET/'.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"SET/");
                /*"    10          FILLER          PIC X(004)  VALUE 'OUT/'.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"OUT/");
                /*"    10          FILLER          PIC X(004)  VALUE 'NOV/'.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"NOV/");
                /*"    10          FILLER          PIC X(004)  VALUE 'DEZ/'.*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"DEZ/");
                /*"  05            FILLER          REDEFINES   TABELA-MESES                                OCCURS      12.*/
            }
            private ListBasis<_REDEF_VG0282B_FILLER_80> _filler_80 { get; set; }
            public ListBasis<_REDEF_VG0282B_FILLER_80> FILLER_80
            {
                get { _filler_80 = new ListBasis<_REDEF_VG0282B_FILLER_80>(12); _.Move(TABELA_MESES, _filler_80); VarBasis.RedefinePassValue(TABELA_MESES, _filler_80, TABELA_MESES); _filler_80.ValueChanged += () => { _.Move(_filler_80, TABELA_MESES); }; return _filler_80; }
                set { VarBasis.RedefinePassValue(value, _filler_80, TABELA_MESES); }
            }  //Redefines
            public class _REDEF_VG0282B_FILLER_80 : VarBasis
            {
                /*"    10          TAB-MES         PIC  X(004).*/
                public StringBasis TAB_MES { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"  05        WABEND.*/

                public _REDEF_VG0282B_FILLER_80()
                {
                    TAB_MES.ValueChanged += OnValueChanged;
                }

            }
            public VG0282B_WABEND WABEND { get; set; } = new VG0282B_WABEND();
            public class VG0282B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(010) VALUE           ' VG0282B'.*/
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VG0282B");
                /*"    10      FILLER              PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"01          LK-LINK.*/
            }
        }
        public VG0282B_LK_LINK LK_LINK { get; set; } = new VG0282B_LK_LINK();
        public class VG0282B_LK_LINK : VarBasis
        {
            /*"  03        LK-RTCODE           PIC  S9(004)   VALUE +0   COMP.*/
            public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03        LK-TAMANHO          PIC  S9(004)   VALUE +40  COMP.*/
            public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
            /*"  03        LK-TITULO           PIC   X(132)   VALUE  SPACES.*/
            public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
        }


        public VG0282B_V1RELATORIOS V1RELATORIOS { get; set; } = new VG0282B_V1RELATORIOS();
        public VG0282B_V1ENDOSSO V1ENDOSSO { get; set; } = new VG0282B_V1ENDOSSO();
        public VG0282B_V1HISTOPARC V1HISTOPARC { get; set; } = new VG0282B_V1HISTOPARC();
        public VG0282B_V1COMISSAO V1COMISSAO { get; set; } = new VG0282B_V1COMISSAO();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string RVG0282B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                RVG0282B.SetFile(RVG0282B_FILE_NAME_P);

                /*" -522- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -523- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -526- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -529- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -529- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -543- PERFORM R8000-00-OPEN-ARQUIVOS */

            R8000_00_OPEN_ARQUIVOS_SECTION();

            /*" -544- PERFORM R0100-00-SELECT-V1SISTEMA */

            R0100_00_SELECT_V1SISTEMA_SECTION();

            /*" -545- IF WFIM-V1SISTEMA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1SISTEMA.IsEmpty())
            {

                /*" -546- MOVE 'B' TO WCH-FINAL */
                _.Move("B", AREA_DE_WORK.WCH_FINAL);

                /*" -550- GO TO R0000-90-ENCERRA. */

                R0000_90_ENCERRA(); //GOTO
                return;
            }


            /*" -551- MOVE SPACES TO WFIM-V1RELATOR */
            _.Move("", AREA_DE_WORK.WFIM_V1RELATOR);

            /*" -552- MOVE SPACES TO WTEM-V1RELATOR */
            _.Move("", AREA_DE_WORK.WTEM_V1RELATOR);

            /*" -554- PERFORM R0200-00-DECLARE-V1RELATORIOS. */

            R0200_00_DECLARE_V1RELATORIOS_SECTION();

            /*" -555- PERFORM R0210-00-FETCH-V1RELATORIOS */

            R0210_00_FETCH_V1RELATORIOS_SECTION();

            /*" -556- IF WFIM-V1RELATOR NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1RELATOR.IsEmpty())
            {

                /*" -557- IF WTEM-V1RELATOR EQUAL SPACES */

                if (AREA_DE_WORK.WTEM_V1RELATOR.IsEmpty())
                {

                    /*" -558- MOVE 'A' TO WCH-FINAL */
                    _.Move("A", AREA_DE_WORK.WCH_FINAL);

                    /*" -559- GO TO R0000-90-ENCERRA */

                    R0000_90_ENCERRA(); //GOTO
                    return;

                    /*" -560- ELSE */
                }
                else
                {


                    /*" -561- MOVE SPACES TO WCH-FINAL */
                    _.Move("", AREA_DE_WORK.WCH_FINAL);

                    /*" -563- GO TO R0000-90-ENCERRA. */

                    R0000_90_ENCERRA(); //GOTO
                    return;
                }

            }


            /*" -567- MOVE V1RELA-NUM-APOL TO CH-NAPOL-ANT. */
            _.Move(V1RELA_NUM_APOL, AREA_DE_WORK.CH_NAPOL_ANT);

            /*" -568- PERFORM R0300-00-MONTA-CABECALHOS */

            R0300_00_MONTA_CABECALHOS_SECTION();

            /*" -569- IF WFIM-V1EMPRESA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1EMPRESA.IsEmpty())
            {

                /*" -570- MOVE 'B' TO WCH-FINAL */
                _.Move("B", AREA_DE_WORK.WCH_FINAL);

                /*" -574- GO TO R0000-90-ENCERRA. */

                R0000_90_ENCERRA(); //GOTO
                return;
            }


            /*" -575- PERFORM R0990-00-PROCESSA-APOLICE UNTIL WFIM-V1RELATOR NOT EQUAL SPACES. */

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
            /*" -580- IF WCH-FINAL EQUAL SPACES */

            if (AREA_DE_WORK.WCH_FINAL.IsEmpty())
            {

                /*" -581- MOVE SPACES TO LC04-ESTIPUL */
                _.Move("", AREA_DE_WORK.LC04.LC04_ESTIPUL);

                /*" -582- MOVE 99999 TO LC05-CODSUBES */
                _.Move(99999, AREA_DE_WORK.LC05.LC05_CODSUBES);

                /*" -583- MOVE SPACES TO LC05-SUBEST */
                _.Move("", AREA_DE_WORK.LC05.LC05_SUBEST);

                /*" -584- MOVE 9999999999999 TO LC06-NUM-APOL */
                _.Move(9999999999999, AREA_DE_WORK.LC06.LC06_NUM_APOL);

                /*" -585- MOVE 'TOTAL GERAL' TO LD02-TITULO */
                _.Move("TOTAL GERAL", AREA_DE_WORK.LD02.LD02_TITULO);

                /*" -586- MOVE ACG-PRM-VALOR TO LD02-VLR-PRM */
                _.Move(AREA_DE_WORK.ACG_PRM_VALOR, AREA_DE_WORK.LD02.LD02_VLR_PRM);

                /*" -587- MOVE ACG-PRM-FATOR TO LD02-FAT-PRM */
                _.Move(AREA_DE_WORK.ACG_PRM_FATOR, AREA_DE_WORK.LD02.LD02_FAT_PRM);

                /*" -588- MOVE ACG-ADM-VALOR TO LD02-VLR-ADM */
                _.Move(AREA_DE_WORK.ACG_ADM_VALOR, AREA_DE_WORK.LD02.LD02_VLR_ADM);

                /*" -589- MOVE ACG-ADM-FATOR TO LD02-FAT-ADM */
                _.Move(AREA_DE_WORK.ACG_ADM_FATOR, AREA_DE_WORK.LD02.LD02_FAT_ADM);

                /*" -590- MOVE ACG-COR-VALOR TO LD02-VLR-COR */
                _.Move(AREA_DE_WORK.ACG_COR_VALOR, AREA_DE_WORK.LD02.LD02_VLR_COR);

                /*" -591- MOVE ACG-COR-FATOR TO LD02-FAT-COR */
                _.Move(AREA_DE_WORK.ACG_COR_FATOR, AREA_DE_WORK.LD02.LD02_FAT_COR);

                /*" -592- PERFORM R5000-00-CABECALHOS */

                R5000_00_CABECALHOS_SECTION();

                /*" -594- WRITE REG-VG0282B FROM LD02 AFTER 1. */
                _.Move(AREA_DE_WORK.LD02.GetMoveValues(), REG_VG0282B);

                RVG0282B.Write(REG_VG0282B.GetMoveValues().ToString());
            }


            /*" -595- IF WCH-FINAL EQUAL SPACES */

            if (AREA_DE_WORK.WCH_FINAL.IsEmpty())
            {

                /*" -596- PERFORM R0220-00-UPDATE-V0RELATORIOS */

                R0220_00_UPDATE_V0RELATORIOS_SECTION();

                /*" -597- DISPLAY 'VG0282B - FIM NORMAL' */
                _.Display($"VG0282B - FIM NORMAL");

                /*" -598- ELSE */
            }
            else
            {


                /*" -599- IF WCH-FINAL EQUAL 'A' */

                if (AREA_DE_WORK.WCH_FINAL == "A")
                {

                    /*" -600- DISPLAY 'VG0282B - NAO HOUVE SOLICITACAO' */
                    _.Display($"VG0282B - NAO HOUVE SOLICITACAO");

                    /*" -601- ELSE */
                }
                else
                {


                    /*" -602- IF WCH-FINAL EQUAL 'B' */

                    if (AREA_DE_WORK.WCH_FINAL == "B")
                    {

                        /*" -604- DISPLAY 'VG0282B - ENCERRADO COM PROBLEMAS' . */
                        _.Display($"VG0282B - ENCERRADO COM PROBLEMAS");
                    }

                }

            }


            /*" -604- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -608- PERFORM R9000-00-CLOSE-ARQUIVOS. */

            R9000_00_CLOSE_ARQUIVOS_SECTION();

            /*" -610- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -610- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-SECTION */
        private void R0100_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -623- MOVE '050' TO WNR-EXEC-SQL. */
            _.Move("050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -628- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -631- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -632- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -633- DISPLAY 'VG0282B - SISTEMA DE VIDA NAO CADASTRADO' */
                    _.Display($"VG0282B - SISTEMA DE VIDA NAO CADASTRADO");

                    /*" -634- MOVE 'S' TO WFIM-V1SISTEMA */
                    _.Move("S", AREA_DE_WORK.WFIM_V1SISTEMA);

                    /*" -635- ELSE */
                }
                else
                {


                    /*" -636- DISPLAY 'ERRO ACESSO V1SISTEMA' */
                    _.Display($"ERRO ACESSO V1SISTEMA");

                    /*" -636- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -628- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :V1SIST-DTMOVABE, :V1SIST-DTCURRENT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VG' END-EXEC. */

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
            /*" -650- MOVE '020' TO WNR-EXEC-SQL. */
            _.Move("020", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -661- PERFORM R0200_00_DECLARE_V1RELATORIOS_DB_DECLARE_1 */

            R0200_00_DECLARE_V1RELATORIOS_DB_DECLARE_1();

            /*" -663- PERFORM R0200_00_DECLARE_V1RELATORIOS_DB_OPEN_1 */

            R0200_00_DECLARE_V1RELATORIOS_DB_OPEN_1();

            /*" -666- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -667- DISPLAY 'PROBLEMAS DECLARE V1RELATORIOS ... ' */
                _.Display($"PROBLEMAS DECLARE V1RELATORIOS ... ");

                /*" -667- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0200-00-DECLARE-V1RELATORIOS-DB-DECLARE-1 */
        public void R0200_00_DECLARE_V1RELATORIOS_DB_DECLARE_1()
        {
            /*" -661- EXEC SQL DECLARE V1RELATORIOS CURSOR FOR SELECT NUM_APOLICE , CODSUBES , CODUNIMO , PERI_INICIAL , PERI_FINAL FROM SEGUROS.V1RELATORIOS WHERE CODRELAT = 'VG0282B1' AND SITUACAO = '0' ORDER BY NUM_APOLICE, CODSUBES END-EXEC. */
            V1RELATORIOS = new VG0282B_V1RELATORIOS(false);
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
							AND SITUACAO = '0' 
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
            /*" -663- EXEC SQL OPEN V1RELATORIOS END-EXEC. */

            V1RELATORIOS.Open();

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V1ENDOSSO-DB-DECLARE-1 */
        public void R0900_00_DECLARE_V1ENDOSSO_DB_DECLARE_1()
        {
            /*" -817- EXEC SQL DECLARE V1ENDOSSO CURSOR FOR SELECT NUM_APOLICE , NRENDOS , CODSUBES , DTINIVIG, DTTERVIG, SITUACAO FROM SEGUROS.V0ENDOSSO WHERE NUM_APOLICE = :V1RELA-NUM-APOL AND DTINIVIG >= :V1RELA-PERI-INI AND DTINIVIG <= :V1RELA-PERI-FIN AND TIPO_ENDOSSO IN ( '0' , '1' ) AND SITUACAO �= '2' ORDER BY NUM_APOLICE , CODSUBES , DTINIVIG END-EXEC. */
            V1ENDOSSO = new VG0282B_V1ENDOSSO(true);
            string GetQuery_V1ENDOSSO()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							NRENDOS
							, 
							CODSUBES
							, 
							DTINIVIG
							, 
							DTTERVIG
							, 
							SITUACAO 
							FROM SEGUROS.V0ENDOSSO 
							WHERE NUM_APOLICE = '{V1RELA_NUM_APOL}' 
							AND DTINIVIG >= '{V1RELA_PERI_INI}' 
							AND DTINIVIG <= '{V1RELA_PERI_FIN}' 
							AND TIPO_ENDOSSO IN ( '0'
							, '1' ) 
							AND SITUACAO �= '2' 
							ORDER BY NUM_APOLICE
							, 
							CODSUBES
							, 
							DTINIVIG";

                return query;
            }
            V1ENDOSSO.GetQueryEvent += GetQuery_V1ENDOSSO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-FETCH-V1RELATORIOS-SECTION */
        private void R0210_00_FETCH_V1RELATORIOS_SECTION()
        {
            /*" -680- MOVE '021' TO WNR-EXEC-SQL. */
            _.Move("021", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -686- PERFORM R0210_00_FETCH_V1RELATORIOS_DB_FETCH_1 */

            R0210_00_FETCH_V1RELATORIOS_DB_FETCH_1();

            /*" -689- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -690- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -691- MOVE 'S' TO WFIM-V1RELATOR */
                    _.Move("S", AREA_DE_WORK.WFIM_V1RELATOR);

                    /*" -692- MOVE 9999999999999 TO V1RELA-NUM-APOL */
                    _.Move(9999999999999, V1RELA_NUM_APOL);

                    /*" -693- GO TO R0210-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/ //GOTO
                    return;

                    /*" -694- ELSE */
                }
                else
                {


                    /*" -695- DISPLAY 'PROBLEMAS ACESSO V1RELATORIOS' */
                    _.Display($"PROBLEMAS ACESSO V1RELATORIOS");

                    /*" -697- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -697- MOVE '*' TO WTEM-V1RELATOR. */
            _.Move("*", AREA_DE_WORK.WTEM_V1RELATOR);

        }

        [StopWatch]
        /*" R0210-00-FETCH-V1RELATORIOS-DB-FETCH-1 */
        public void R0210_00_FETCH_V1RELATORIOS_DB_FETCH_1()
        {
            /*" -686- EXEC SQL FETCH V1RELATORIOS INTO :V1RELA-NUM-APOL , :V1RELA-CODSUBES , :V1RELA-CODUNIMO , :V1RELA-PERI-INI , :V1RELA-PERI-FIN END-EXEC. */

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
            /*" -710- MOVE '022' TO WNR-EXEC-SQL. */
            _.Move("022", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -715- PERFORM R0220_00_UPDATE_V0RELATORIOS_DB_UPDATE_1 */

            R0220_00_UPDATE_V0RELATORIOS_DB_UPDATE_1();

            /*" -718- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -719- DISPLAY 'PROBLEMA UPDATE V0RELATORIOS' */
                _.Display($"PROBLEMA UPDATE V0RELATORIOS");

                /*" -721- DISPLAY V1RELA-PERI-INI '-' V1RELA-PERI-FIN */

                $"{V1RELA_PERI_INI}-{V1RELA_PERI_FIN}"
                .Display();

                /*" -721- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0220-00-UPDATE-V0RELATORIOS-DB-UPDATE-1 */
        public void R0220_00_UPDATE_V0RELATORIOS_DB_UPDATE_1()
        {
            /*" -715- EXEC SQL UPDATE SEGUROS.V0RELATORIOS SET SITUACAO = '1' , TIMESTAMP = CURRENT TIMESTAMP WHERE CODRELAT = 'VG0282B1' AND SITUACAO = '0' END-EXEC. */

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
            /*" -736- MOVE '030' TO WNR-EXEC-SQL. */
            _.Move("030", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -737- MOVE V1SIST-DTCURRENT TO WDATA-CURR */
            _.Move(V1SIST_DTCURRENT, AREA_DE_WORK.WDATA_CURR);

            /*" -738- MOVE WDATA-DD-CURR TO WDATA-DD-CABEC */
            _.Move(AREA_DE_WORK.WDATA_CURR.WDATA_DD_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -739- MOVE WDATA-MM-CURR TO WDATA-MM-CABEC */
            _.Move(AREA_DE_WORK.WDATA_CURR.WDATA_MM_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -740- MOVE WDATA-AA-CURR TO WDATA-AA-CABEC */
            _.Move(AREA_DE_WORK.WDATA_CURR.WDATA_AA_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -742- MOVE WDATA-CABEC TO LC02-DATA. */
            _.Move(AREA_DE_WORK.WDATA_CABEC, AREA_DE_WORK.LC02.LC02_DATA);

            /*" -743- ACCEPT HORA-1 FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WDATA_CURR.HORA_1);

            /*" -744- MOVE HORA-2 TO WHORA-CURR */
            _.Move(AREA_DE_WORK.WDATA_CURR.WHORA_PER_X.HORA_2, AREA_DE_WORK.WHORA_CURR);

            /*" -745- MOVE WHORA-HH-CURR TO WHORA-HH-CABEC */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_HH_CURR, AREA_DE_WORK.WHORA_CABEC.WHORA_HH_CABEC);

            /*" -746- MOVE WHORA-MM-CURR TO WHORA-MM-CABEC */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_MM_CURR, AREA_DE_WORK.WHORA_CABEC.WHORA_MM_CABEC);

            /*" -747- MOVE WHORA-SS-CURR TO WHORA-SS-CABEC */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_SS_CURR, AREA_DE_WORK.WHORA_CABEC.WHORA_SS_CABEC);

            /*" -749- MOVE WHORA-CABEC TO LC03-HORA. */
            _.Move(AREA_DE_WORK.WHORA_CABEC, AREA_DE_WORK.LC03.LC03_HORA);

            /*" -753- PERFORM R0300_00_MONTA_CABECALHOS_DB_SELECT_1 */

            R0300_00_MONTA_CABECALHOS_DB_SELECT_1();

            /*" -756- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -757- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -758- DISPLAY 'EMPRESA NAO CADASTRADA' */
                    _.Display($"EMPRESA NAO CADASTRADA");

                    /*" -759- MOVE 'S' TO WFIM-V1EMPRESA */
                    _.Move("S", AREA_DE_WORK.WFIM_V1EMPRESA);

                    /*" -760- GO TO R0300-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/ //GOTO
                    return;

                    /*" -761- ELSE */
                }
                else
                {


                    /*" -762- DISPLAY 'PROBLEMAS ACESSO V1EMPRESA' */
                    _.Display($"PROBLEMAS ACESSO V1EMPRESA");

                    /*" -764- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -765- MOVE V1EMPR-NOM-EMP TO LK-TITULO */
            _.Move(V1EMPR_NOM_EMP, LK_LINK.LK_TITULO);

            /*" -767- CALL 'PROALN01' USING LK-LINK */
            _.Call("PROALN01", LK_LINK);

            /*" -768- IF LK-RTCODE EQUAL ZEROS */

            if (LK_LINK.LK_RTCODE == 00)
            {

                /*" -769- MOVE LK-TITULO TO LC01-EMPRESA */
                _.Move(LK_LINK.LK_TITULO, AREA_DE_WORK.LC01.LC01_EMPRESA);

                /*" -770- ELSE */
            }
            else
            {


                /*" -771- DISPLAY 'PROBLEMA CALL V1EMPRESA' */
                _.Display($"PROBLEMA CALL V1EMPRESA");

                /*" -773- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -777- PERFORM R0300_00_MONTA_CABECALHOS_DB_SELECT_2 */

            R0300_00_MONTA_CABECALHOS_DB_SELECT_2();

            /*" -780- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -781- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -782- DISPLAY 'MOEDA SOLICITADA NAO CADASTRADA' */
                    _.Display($"MOEDA SOLICITADA NAO CADASTRADA");

                    /*" -783- MOVE 'S' TO WFIM-V1EMPRESA */
                    _.Move("S", AREA_DE_WORK.WFIM_V1EMPRESA);

                    /*" -784- GO TO R0300-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/ //GOTO
                    return;

                    /*" -785- ELSE */
                }
                else
                {


                    /*" -786- DISPLAY 'PROBLEMAS ACESSO V0MOEDA' */
                    _.Display($"PROBLEMAS ACESSO V0MOEDA");

                    /*" -788- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -788- MOVE V0MOED-SIGLUNIM TO LC06-MOEDA. */
            _.Move(V0MOED_SIGLUNIM, AREA_DE_WORK.LC06.LC06_MOEDA);

        }

        [StopWatch]
        /*" R0300-00-MONTA-CABECALHOS-DB-SELECT-1 */
        public void R0300_00_MONTA_CABECALHOS_DB_SELECT_1()
        {
            /*" -753- EXEC SQL SELECT NOME_EMPRESA INTO :V1EMPR-NOM-EMP FROM SEGUROS.V1EMPRESA WHERE COD_EMPRESA = 0 END-EXEC. */

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
            /*" -777- EXEC SQL SELECT SIGLUNIM INTO :V0MOED-SIGLUNIM FROM SEGUROS.V0MOEDA WHERE CODUNIMO = :V1RELA-CODUNIMO END-EXEC. */

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
        /*" R0900-00-DECLARE-V1ENDOSSO-SECTION */
        private void R0900_00_DECLARE_V1ENDOSSO_SECTION()
        {
            /*" -801- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -817- PERFORM R0900_00_DECLARE_V1ENDOSSO_DB_DECLARE_1 */

            R0900_00_DECLARE_V1ENDOSSO_DB_DECLARE_1();

            /*" -819- PERFORM R0900_00_DECLARE_V1ENDOSSO_DB_OPEN_1 */

            R0900_00_DECLARE_V1ENDOSSO_DB_OPEN_1();

            /*" -822- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -823- DISPLAY 'PROBLEMAS DECLARE V1ENDOSSO ... ' */
                _.Display($"PROBLEMAS DECLARE V1ENDOSSO ... ");

                /*" -823- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-V1ENDOSSO-DB-OPEN-1 */
        public void R0900_00_DECLARE_V1ENDOSSO_DB_OPEN_1()
        {
            /*" -819- EXEC SQL OPEN V1ENDOSSO END-EXEC. */

            V1ENDOSSO.Open();

        }

        [StopWatch]
        /*" R3100-00-DECLARE-V1HISTOPARC-DB-DECLARE-1 */
        public void R3100_00_DECLARE_V1HISTOPARC_DB_DECLARE_1()
        {
            /*" -1250- EXEC SQL DECLARE V1HISTOPARC CURSOR FOR SELECT OPERACAO , DTMOVTO , VLPRMLIQ , DTQITBCO FROM SEGUROS.V1HISTOPARC WHERE NUM_APOLICE = :V1ENDO-NUM-APOL AND NRENDOS = :V1ENDO-NRENDOS AND OPERACAO >= 100 AND OPERACAO <= 300 END-EXEC. */
            V1HISTOPARC = new VG0282B_V1HISTOPARC(true);
            string GetQuery_V1HISTOPARC()
            {
                var query = @$"SELECT OPERACAO
							, 
							DTMOVTO
							, 
							VLPRMLIQ
							, 
							DTQITBCO 
							FROM SEGUROS.V1HISTOPARC 
							WHERE NUM_APOLICE = '{V1ENDO_NUM_APOL}' 
							AND NRENDOS = '{V1ENDO_NRENDOS}' 
							AND OPERACAO >= 100 
							AND OPERACAO <= 300";

                return query;
            }
            V1HISTOPARC.GetQueryEvent += GetQuery_V1HISTOPARC;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-V1ENDOSSO-SECTION */
        private void R0910_00_FETCH_V1ENDOSSO_SECTION()
        {
            /*" -836- MOVE '091' TO WNR-EXEC-SQL. */
            _.Move("091", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -843- PERFORM R0910_00_FETCH_V1ENDOSSO_DB_FETCH_1 */

            R0910_00_FETCH_V1ENDOSSO_DB_FETCH_1();

            /*" -846- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -847- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -848- MOVE 'S' TO WFIM-V1ENDOSSO */
                    _.Move("S", AREA_DE_WORK.WFIM_V1ENDOSSO);

                    /*" -849- MOVE 9999 TO CH-CHAVE-ATU */
                    _.Move(9999, AREA_DE_WORK.CH_CHAVE_ATU);

                    /*" -849- PERFORM R0910_00_FETCH_V1ENDOSSO_DB_CLOSE_1 */

                    R0910_00_FETCH_V1ENDOSSO_DB_CLOSE_1();

                    /*" -851- GO TO R0910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;

                    /*" -852- ELSE */
                }
                else
                {


                    /*" -856- DISPLAY 'R0910-00 PROBLEMAS NO FETCH ... ' V1ENDO-NUM-APOL ' ' V1ENDO-NRENDOS ' ' V1ENDO-CODSUBES */

                    $"R0910-00 PROBLEMAS NO FETCH ... {V1ENDO_NUM_APOL} {V1ENDO_NRENDOS} {V1ENDO_CODSUBES}"
                    .Display();

                    /*" -858- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -859- IF V1RELA-CODSUBES GREATER ZEROS */

            if (V1RELA_CODSUBES > 00)
            {

                /*" -860- IF V1ENDO-CODSUBES NOT = V1RELA-CODSUBES */

                if (V1ENDO_CODSUBES != V1RELA_CODSUBES)
                {

                    /*" -862- GO TO R0910-00-FETCH-V1ENDOSSO. */
                    new Task(() => R0910_00_FETCH_V1ENDOSSO_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...
                }

            }


            /*" -863- MOVE V1ENDO-CODSUBES TO CH-CODSB-ATU */
            _.Move(V1ENDO_CODSUBES, AREA_DE_WORK.CH_CHAVE_ATU.CH_CODSB_ATU);

            /*" -863- MOVE V1ENDO-DTINIVIG TO CH-VIGEN-ATU. */
            _.Move(V1ENDO_DTINIVIG, AREA_DE_WORK.CH_CHAVE_ATU.CH_VIGEN_ATU);

        }

        [StopWatch]
        /*" R0910-00-FETCH-V1ENDOSSO-DB-FETCH-1 */
        public void R0910_00_FETCH_V1ENDOSSO_DB_FETCH_1()
        {
            /*" -843- EXEC SQL FETCH V1ENDOSSO INTO :V1ENDO-NUM-APOL , :V1ENDO-NRENDOS , :V1ENDO-CODSUBES , :V1ENDO-DTINIVIG, :V1ENDO-DTTERVIG, :V1ENDO-SITUACAO END-EXEC. */

            if (V1ENDOSSO.Fetch())
            {
                _.Move(V1ENDOSSO.V1ENDO_NUM_APOL, V1ENDO_NUM_APOL);
                _.Move(V1ENDOSSO.V1ENDO_NRENDOS, V1ENDO_NRENDOS);
                _.Move(V1ENDOSSO.V1ENDO_CODSUBES, V1ENDO_CODSUBES);
                _.Move(V1ENDOSSO.V1ENDO_DTINIVIG, V1ENDO_DTINIVIG);
                _.Move(V1ENDOSSO.V1ENDO_DTTERVIG, V1ENDO_DTTERVIG);
                _.Move(V1ENDOSSO.V1ENDO_SITUACAO, V1ENDO_SITUACAO);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-V1ENDOSSO-DB-CLOSE-1 */
        public void R0910_00_FETCH_V1ENDOSSO_DB_CLOSE_1()
        {
            /*" -849- EXEC SQL CLOSE V1ENDOSSO END-EXEC */

            V1ENDOSSO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R0990-00-PROCESSA-APOLICE-SECTION */
        private void R0990_00_PROCESSA_APOLICE_SECTION()
        {
            /*" -878- MOVE '990' TO WNR-EXEC-SQL. */
            _.Move("990", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -879- PERFORM R0900-00-DECLARE-V1ENDOSSO */

            R0900_00_DECLARE_V1ENDOSSO_SECTION();

            /*" -880- PERFORM R0910-00-FETCH-V1ENDOSSO */

            R0910_00_FETCH_V1ENDOSSO_SECTION();

            /*" -881- IF WFIM-V1ENDOSSO EQUAL HIGH-VALUES */

            if (AREA_DE_WORK.WFIM_V1ENDOSSO.IsHighValues)
            {

                /*" -883- GO TO R0990-10-NEXT. */

                R0990_10_NEXT(); //GOTO
                return;
            }


            /*" -884- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-V1ENDOSSO NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V1ENDOSSO.IsEmpty()))
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
            /*" -889- MOVE +80 TO AC-LINHAS */
            _.Move(+80, AREA_DE_WORK.AC_LINHAS);

            /*" -890- MOVE ZEROS TO AC-PAGINA */
            _.Move(0, AREA_DE_WORK.AC_PAGINA);

            /*" -891- MOVE SPACES TO WFIM-V1ENDOSSO */
            _.Move("", AREA_DE_WORK.WFIM_V1ENDOSSO);

            /*" -893- MOVE SPACES TO WFIM-V1COMISSAO */
            _.Move("", AREA_DE_WORK.WFIM_V1COMISSAO);

            /*" -895- PERFORM R0210-00-FETCH-V1RELATORIOS. */

            R0210_00_FETCH_V1RELATORIOS_SECTION();

            /*" -896- IF V1RELA-NUM-APOL NOT EQUAL CH-NAPOL-ANT */

            if (V1RELA_NUM_APOL != AREA_DE_WORK.CH_NAPOL_ANT)
            {

                /*" -897- MOVE V1RELA-NUM-APOL TO CH-NAPOL-ANT */
                _.Move(V1RELA_NUM_APOL, AREA_DE_WORK.CH_NAPOL_ANT);

                /*" -898- IF ACA-PRM-VALOR GREATER ZEROS */

                if (AREA_DE_WORK.ACA_PRM_VALOR > 00)
                {

                    /*" -899- MOVE 99999 TO LC05-CODSUBES */
                    _.Move(99999, AREA_DE_WORK.LC05.LC05_CODSUBES);

                    /*" -900- MOVE SPACES TO LC05-SUBEST */
                    _.Move("", AREA_DE_WORK.LC05.LC05_SUBEST);

                    /*" -901- PERFORM R5000-00-CABECALHOS */

                    R5000_00_CABECALHOS_SECTION();

                    /*" -902- MOVE 'TOTAL APOLICE' TO LD02-TITULO */
                    _.Move("TOTAL APOLICE", AREA_DE_WORK.LD02.LD02_TITULO);

                    /*" -903- MOVE ACA-PRM-VALOR TO LD02-VLR-PRM */
                    _.Move(AREA_DE_WORK.ACA_PRM_VALOR, AREA_DE_WORK.LD02.LD02_VLR_PRM);

                    /*" -904- MOVE ACA-PRM-FATOR TO LD02-FAT-PRM */
                    _.Move(AREA_DE_WORK.ACA_PRM_FATOR, AREA_DE_WORK.LD02.LD02_FAT_PRM);

                    /*" -905- MOVE ACA-ADM-VALOR TO LD02-VLR-ADM */
                    _.Move(AREA_DE_WORK.ACA_ADM_VALOR, AREA_DE_WORK.LD02.LD02_VLR_ADM);

                    /*" -906- MOVE ACA-ADM-FATOR TO LD02-FAT-ADM */
                    _.Move(AREA_DE_WORK.ACA_ADM_FATOR, AREA_DE_WORK.LD02.LD02_FAT_ADM);

                    /*" -907- MOVE ACA-COR-VALOR TO LD02-VLR-COR */
                    _.Move(AREA_DE_WORK.ACA_COR_VALOR, AREA_DE_WORK.LD02.LD02_VLR_COR);

                    /*" -908- MOVE ACA-COR-FATOR TO LD02-FAT-COR */
                    _.Move(AREA_DE_WORK.ACA_COR_FATOR, AREA_DE_WORK.LD02.LD02_FAT_COR);

                    /*" -909- WRITE REG-VG0282B FROM LD02 AFTER 1 */
                    _.Move(AREA_DE_WORK.LD02.GetMoveValues(), REG_VG0282B);

                    RVG0282B.Write(REG_VG0282B.GetMoveValues().ToString());

                    /*" -910- ADD ACA-PRM-VALOR TO ACG-PRM-VALOR */
                    AREA_DE_WORK.ACG_PRM_VALOR.Value = AREA_DE_WORK.ACG_PRM_VALOR + AREA_DE_WORK.ACA_PRM_VALOR;

                    /*" -911- ADD ACA-PRM-FATOR TO ACG-PRM-FATOR */
                    AREA_DE_WORK.ACG_PRM_FATOR.Value = AREA_DE_WORK.ACG_PRM_FATOR + AREA_DE_WORK.ACA_PRM_FATOR;

                    /*" -912- ADD ACA-ADM-VALOR TO ACG-ADM-VALOR */
                    AREA_DE_WORK.ACG_ADM_VALOR.Value = AREA_DE_WORK.ACG_ADM_VALOR + AREA_DE_WORK.ACA_ADM_VALOR;

                    /*" -913- ADD ACA-ADM-FATOR TO ACG-ADM-FATOR */
                    AREA_DE_WORK.ACG_ADM_FATOR.Value = AREA_DE_WORK.ACG_ADM_FATOR + AREA_DE_WORK.ACA_ADM_FATOR;

                    /*" -914- ADD ACA-COR-VALOR TO ACG-COR-VALOR */
                    AREA_DE_WORK.ACG_COR_VALOR.Value = AREA_DE_WORK.ACG_COR_VALOR + AREA_DE_WORK.ACA_COR_VALOR;

                    /*" -915- ADD ACA-COR-FATOR TO ACG-COR-FATOR */
                    AREA_DE_WORK.ACG_COR_FATOR.Value = AREA_DE_WORK.ACG_COR_FATOR + AREA_DE_WORK.ACA_COR_FATOR;

                    /*" -920- MOVE ZEROS TO ACA-PRM-VALOR ACA-PRM-FATOR ACA-ADM-VALOR ACA-ADM-FATOR ACA-COR-VALOR ACA-COR-FATOR. */
                    _.Move(0, AREA_DE_WORK.ACA_PRM_VALOR, AREA_DE_WORK.ACA_PRM_FATOR, AREA_DE_WORK.ACA_ADM_VALOR, AREA_DE_WORK.ACA_ADM_FATOR, AREA_DE_WORK.ACA_COR_VALOR, AREA_DE_WORK.ACA_COR_FATOR);
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0990_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -933- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -934- MOVE V1RELA-PERI-INI TO WDATA-VIGENCIA */
            _.Move(V1RELA_PERI_INI, AREA_DE_WORK.WDATA_VIGENCIA);

            /*" -935- MOVE WDATA-VIG-DIA TO LC03-DIA-INI */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_DIA, AREA_DE_WORK.LC03.LC03_DIA_INI);

            /*" -936- MOVE WDATA-VIG-MES TO LC03-MES-INI */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES, AREA_DE_WORK.LC03.LC03_MES_INI);

            /*" -938- MOVE WDATA-VIG-ANO TO LC03-ANO-INI */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_ANO, AREA_DE_WORK.LC03.LC03_ANO_INI);

            /*" -939- MOVE V1RELA-PERI-FIN TO WDATA-VIGENCIA */
            _.Move(V1RELA_PERI_FIN, AREA_DE_WORK.WDATA_VIGENCIA);

            /*" -940- MOVE WDATA-VIG-DIA TO LC03-DIA-TER */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_DIA, AREA_DE_WORK.LC03.LC03_DIA_TER);

            /*" -941- MOVE WDATA-VIG-MES TO LC03-MES-TER */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES, AREA_DE_WORK.LC03.LC03_MES_TER);

            /*" -945- MOVE WDATA-VIG-ANO TO LC03-ANO-TER */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_ANO, AREA_DE_WORK.LC03.LC03_ANO_TER);

            /*" -946- PERFORM R2100-00-SELECT-V1APOLICE */

            R2100_00_SELECT_V1APOLICE_SECTION();

            /*" -947- MOVE V1APOL-CODCLIEN TO WHOST-CODCLIEN */
            _.Move(V1APOL_CODCLIEN, WHOST_CODCLIEN);

            /*" -948- PERFORM R2300-00-SELECT-V1CLIENTE */

            R2300_00_SELECT_V1CLIENTE_SECTION();

            /*" -952- MOVE V1CLIE-NOME TO LC04-ESTIPUL */
            _.Move(V1CLIE_NOME, AREA_DE_WORK.LC04.LC04_ESTIPUL);

            /*" -953- PERFORM R2200-00-SELECT-V1SUBGRUPO */

            R2200_00_SELECT_V1SUBGRUPO_SECTION();

            /*" -954- MOVE V1SUBG-CODCLIEN TO WHOST-CODCLIEN */
            _.Move(V1SUBG_CODCLIEN, WHOST_CODCLIEN);

            /*" -956- PERFORM R2300-00-SELECT-V1CLIENTE */

            R2300_00_SELECT_V1CLIENTE_SECTION();

            /*" -957- MOVE V1ENDO-CODSUBES TO LC05-CODSUBES */
            _.Move(V1ENDO_CODSUBES, AREA_DE_WORK.LC05.LC05_CODSUBES);

            /*" -959- MOVE V1CLIE-NOME TO LC05-SUBEST */
            _.Move(V1CLIE_NOME, AREA_DE_WORK.LC05.LC05_SUBEST);

            /*" -961- MOVE V1RELA-NUM-APOL TO LC06-NUM-APOL */
            _.Move(V1RELA_NUM_APOL, AREA_DE_WORK.LC06.LC06_NUM_APOL);

            /*" -963- PERFORM R5000-00-CABECALHOS */

            R5000_00_CABECALHOS_SECTION();

            /*" -965- MOVE CH-CODSB-ATU TO CH-CODSB-ANT */
            _.Move(AREA_DE_WORK.CH_CHAVE_ATU.CH_CODSB_ATU, AREA_DE_WORK.CH_CHAVE_ANT.CH_CODSB_ANT);

            /*" -968- PERFORM R1100-00-PROCESSA-SUBESTIP UNTIL CH-CODSB-ATU NOT EQUAL CH-CODSB-ANT. */

            while (!(AREA_DE_WORK.CH_CHAVE_ATU.CH_CODSB_ATU != AREA_DE_WORK.CH_CHAVE_ANT.CH_CODSB_ANT))
            {

                R1100_00_PROCESSA_SUBESTIP_SECTION();
            }

            /*" -970- MOVE 'TOTAL SUBGRUPO' TO LD02-TITULO */
            _.Move("TOTAL SUBGRUPO", AREA_DE_WORK.LD02.LD02_TITULO);

            /*" -971- MOVE ACT-PRM-VALOR TO LD02-VLR-PRM */
            _.Move(AREA_DE_WORK.ACT_PRM_VALOR, AREA_DE_WORK.LD02.LD02_VLR_PRM);

            /*" -972- MOVE ACT-PRM-FATOR TO LD02-FAT-PRM */
            _.Move(AREA_DE_WORK.ACT_PRM_FATOR, AREA_DE_WORK.LD02.LD02_FAT_PRM);

            /*" -973- MOVE ACT-ADM-VALOR TO LD02-VLR-ADM */
            _.Move(AREA_DE_WORK.ACT_ADM_VALOR, AREA_DE_WORK.LD02.LD02_VLR_ADM);

            /*" -974- MOVE ACT-ADM-FATOR TO LD02-FAT-ADM */
            _.Move(AREA_DE_WORK.ACT_ADM_FATOR, AREA_DE_WORK.LD02.LD02_FAT_ADM);

            /*" -975- MOVE ACT-COR-VALOR TO LD02-VLR-COR */
            _.Move(AREA_DE_WORK.ACT_COR_VALOR, AREA_DE_WORK.LD02.LD02_VLR_COR);

            /*" -977- MOVE ACT-COR-FATOR TO LD02-FAT-COR */
            _.Move(AREA_DE_WORK.ACT_COR_FATOR, AREA_DE_WORK.LD02.LD02_FAT_COR);

            /*" -978- ADD 1 TO AC-LINHAS */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 1;

            /*" -979- IF AC-LINHAS GREATER 53 */

            if (AREA_DE_WORK.AC_LINHAS > 53)
            {

                /*" -981- PERFORM R5000-00-CABECALHOS. */

                R5000_00_CABECALHOS_SECTION();
            }


            /*" -983- WRITE REG-VG0282B FROM LD02 AFTER 1 */
            _.Move(AREA_DE_WORK.LD02.GetMoveValues(), REG_VG0282B);

            RVG0282B.Write(REG_VG0282B.GetMoveValues().ToString());

            /*" -984- ADD ACT-PRM-VALOR TO ACA-PRM-VALOR */
            AREA_DE_WORK.ACA_PRM_VALOR.Value = AREA_DE_WORK.ACA_PRM_VALOR + AREA_DE_WORK.ACT_PRM_VALOR;

            /*" -985- ADD ACT-PRM-FATOR TO ACA-PRM-FATOR */
            AREA_DE_WORK.ACA_PRM_FATOR.Value = AREA_DE_WORK.ACA_PRM_FATOR + AREA_DE_WORK.ACT_PRM_FATOR;

            /*" -986- ADD ACT-ADM-VALOR TO ACA-ADM-VALOR */
            AREA_DE_WORK.ACA_ADM_VALOR.Value = AREA_DE_WORK.ACA_ADM_VALOR + AREA_DE_WORK.ACT_ADM_VALOR;

            /*" -987- ADD ACT-ADM-FATOR TO ACA-ADM-FATOR */
            AREA_DE_WORK.ACA_ADM_FATOR.Value = AREA_DE_WORK.ACA_ADM_FATOR + AREA_DE_WORK.ACT_ADM_FATOR;

            /*" -988- ADD ACT-COR-VALOR TO ACA-COR-VALOR */
            AREA_DE_WORK.ACA_COR_VALOR.Value = AREA_DE_WORK.ACA_COR_VALOR + AREA_DE_WORK.ACT_COR_VALOR;

            /*" -990- ADD ACT-COR-FATOR TO ACA-COR-FATOR */
            AREA_DE_WORK.ACA_COR_FATOR.Value = AREA_DE_WORK.ACA_COR_FATOR + AREA_DE_WORK.ACT_COR_FATOR;

            /*" -995- MOVE ZEROS TO ACT-PRM-VALOR ACT-PRM-FATOR ACT-ADM-VALOR ACT-ADM-FATOR ACT-COR-VALOR ACT-COR-FATOR. */
            _.Move(0, AREA_DE_WORK.ACT_PRM_VALOR, AREA_DE_WORK.ACT_PRM_FATOR, AREA_DE_WORK.ACT_ADM_VALOR, AREA_DE_WORK.ACT_ADM_FATOR, AREA_DE_WORK.ACT_COR_VALOR, AREA_DE_WORK.ACT_COR_FATOR);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-PROCESSA-SUBESTIP-SECTION */
        private void R1100_00_PROCESSA_SUBESTIP_SECTION()
        {
            /*" -1008- MOVE '110' TO WNR-EXEC-SQL. */
            _.Move("110", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1010- MOVE CH-CHAVE-ATU TO CH-CHAVE-ANT */
            _.Move(AREA_DE_WORK.CH_CHAVE_ATU, AREA_DE_WORK.CH_CHAVE_ANT);

            /*" -1011- MOVE ZEROS TO AC-EMI-VALOR */
            _.Move(0, AREA_DE_WORK.AC_EMI_VALOR);

            /*" -1012- MOVE ZEROS TO AC-EMI-FATOR */
            _.Move(0, AREA_DE_WORK.AC_EMI_FATOR);

            /*" -1013- MOVE ZEROS TO AC-COB-VALOR */
            _.Move(0, AREA_DE_WORK.AC_COB_VALOR);

            /*" -1015- MOVE ZEROS TO AC-COB-FATOR */
            _.Move(0, AREA_DE_WORK.AC_COB_FATOR);

            /*" -1016- MOVE ZEROS TO AC-ADM-VALOR */
            _.Move(0, AREA_DE_WORK.AC_ADM_VALOR);

            /*" -1017- MOVE ZEROS TO AC-ADM-FATOR */
            _.Move(0, AREA_DE_WORK.AC_ADM_FATOR);

            /*" -1018- MOVE ZEROS TO AC-COR-VALOR */
            _.Move(0, AREA_DE_WORK.AC_COR_VALOR);

            /*" -1020- MOVE ZEROS TO AC-COR-FATOR */
            _.Move(0, AREA_DE_WORK.AC_COR_FATOR);

            /*" -1021- MOVE V1ENDO-DTINIVIG TO WDATA-VIGENCIA */
            _.Move(V1ENDO_DTINIVIG, AREA_DE_WORK.WDATA_VIGENCIA);

            /*" -1022- MOVE TAB-MES(WDATA-VIG-MES) TO LD01-MES-VIG */
            _.Move(AREA_DE_WORK.FILLER_80[AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES].TAB_MES, AREA_DE_WORK.LD01.LD01_MES_VIG);

            /*" -1023- MOVE WDATA-VIG-ANO TO LD01-ANO-VIG */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_ANO, AREA_DE_WORK.LD01.LD01_ANO_VIG);

            /*" -1024- MOVE V1ENDO-NRENDOS TO LD01-NRENDOS */
            _.Move(V1ENDO_NRENDOS, AREA_DE_WORK.LD01.LD01_NRENDOS);

            /*" -1025- IF V1ENDO-SITUACAO EQUAL '1' */

            if (V1ENDO_SITUACAO == "1")
            {

                /*" -1026- MOVE 'P' TO LD01-SITUACAO */
                _.Move("P", AREA_DE_WORK.LD01.LD01_SITUACAO);

                /*" -1027- ELSE */
            }
            else
            {


                /*" -1029- MOVE 'E' TO LD01-SITUACAO. */
                _.Move("E", AREA_DE_WORK.LD01.LD01_SITUACAO);
            }


            /*" -1032- PERFORM R1200-00-PROCESSA-VIGENCIA UNTIL CH-CHAVE-ATU NOT EQUAL CH-CHAVE-ANT */

            while (!(AREA_DE_WORK.CH_CHAVE_ATU != AREA_DE_WORK.CH_CHAVE_ANT))
            {

                R1200_00_PROCESSA_VIGENCIA_SECTION();
            }

            /*" -1033- IF AC-COB-FATOR EQUAL ZEROS */

            if (AREA_DE_WORK.AC_COB_FATOR == 00)
            {

                /*" -1034- MOVE V1HISP-DTMOVTO TO WDATA-VIGENCIA */
                _.Move(V1HISP_DTMOVTO, AREA_DE_WORK.WDATA_VIGENCIA);

                /*" -1035- MOVE WDATA-VIG-DIA TO LD01-DIA-PGT */
                _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_DIA, AREA_DE_WORK.LD01.LD01_DIA_PGT);

                /*" -1036- MOVE WDATA-VIG-MES TO LD01-MES-PGT */
                _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES, AREA_DE_WORK.LD01.LD01_MES_PGT);

                /*" -1037- MOVE WDATA-VIG-ANO TO LD01-ANO-PGT */
                _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_ANO, AREA_DE_WORK.LD01.LD01_ANO_PGT);

                /*" -1038- MOVE AC-EMI-VALOR TO LD01-VLR-PRM */
                _.Move(AREA_DE_WORK.AC_EMI_VALOR, AREA_DE_WORK.LD01.LD01_VLR_PRM);

                /*" -1039- MOVE AC-EMI-FATOR TO LD01-FAT-PRM */
                _.Move(AREA_DE_WORK.AC_EMI_FATOR, AREA_DE_WORK.LD01.LD01_FAT_PRM);

                /*" -1040- ADD AC-EMI-VALOR TO ACT-PRM-VALOR */
                AREA_DE_WORK.ACT_PRM_VALOR.Value = AREA_DE_WORK.ACT_PRM_VALOR + AREA_DE_WORK.AC_EMI_VALOR;

                /*" -1041- ADD AC-EMI-FATOR TO ACT-PRM-FATOR */
                AREA_DE_WORK.ACT_PRM_FATOR.Value = AREA_DE_WORK.ACT_PRM_FATOR + AREA_DE_WORK.AC_EMI_FATOR;

                /*" -1042- ELSE */
            }
            else
            {


                /*" -1043- MOVE V1HISP-DTQITBCO TO WDATA-VIGENCIA */
                _.Move(V1HISP_DTQITBCO, AREA_DE_WORK.WDATA_VIGENCIA);

                /*" -1044- MOVE WDATA-VIG-DIA TO LD01-DIA-PGT */
                _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_DIA, AREA_DE_WORK.LD01.LD01_DIA_PGT);

                /*" -1045- MOVE WDATA-VIG-MES TO LD01-MES-PGT */
                _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES, AREA_DE_WORK.LD01.LD01_MES_PGT);

                /*" -1046- MOVE WDATA-VIG-ANO TO LD01-ANO-PGT */
                _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_ANO, AREA_DE_WORK.LD01.LD01_ANO_PGT);

                /*" -1047- MOVE AC-COB-VALOR TO LD01-VLR-PRM */
                _.Move(AREA_DE_WORK.AC_COB_VALOR, AREA_DE_WORK.LD01.LD01_VLR_PRM);

                /*" -1048- MOVE AC-COB-FATOR TO LD01-FAT-PRM */
                _.Move(AREA_DE_WORK.AC_COB_FATOR, AREA_DE_WORK.LD01.LD01_FAT_PRM);

                /*" -1049- ADD AC-COB-VALOR TO ACT-PRM-VALOR */
                AREA_DE_WORK.ACT_PRM_VALOR.Value = AREA_DE_WORK.ACT_PRM_VALOR + AREA_DE_WORK.AC_COB_VALOR;

                /*" -1051- ADD AC-COB-FATOR TO ACT-PRM-FATOR. */
                AREA_DE_WORK.ACT_PRM_FATOR.Value = AREA_DE_WORK.ACT_PRM_FATOR + AREA_DE_WORK.AC_COB_FATOR;
            }


            /*" -1052- MOVE AC-ADM-VALOR TO LD01-VLR-ADM */
            _.Move(AREA_DE_WORK.AC_ADM_VALOR, AREA_DE_WORK.LD01.LD01_VLR_ADM);

            /*" -1053- MOVE AC-ADM-FATOR TO LD01-FAT-ADM */
            _.Move(AREA_DE_WORK.AC_ADM_FATOR, AREA_DE_WORK.LD01.LD01_FAT_ADM);

            /*" -1054- MOVE AC-COR-VALOR TO LD01-VLR-COR */
            _.Move(AREA_DE_WORK.AC_COR_VALOR, AREA_DE_WORK.LD01.LD01_VLR_COR);

            /*" -1056- MOVE AC-COR-FATOR TO LD01-FAT-COR */
            _.Move(AREA_DE_WORK.AC_COR_FATOR, AREA_DE_WORK.LD01.LD01_FAT_COR);

            /*" -1057- IF AC-ADM-FATOR NOT EQUAL ZEROS */

            if (AREA_DE_WORK.AC_ADM_FATOR != 00)
            {

                /*" -1058- MOVE WS-DATA-ADM TO WDATA-VIGENCIA */
                _.Move(WS_DATA_ADM, AREA_DE_WORK.WDATA_VIGENCIA);

                /*" -1059- MOVE '/' TO LD01-BARRA1 */
                _.Move("/", AREA_DE_WORK.LD01.LD01_BARRA1);

                /*" -1060- MOVE '/' TO LD01-BARRA2 */
                _.Move("/", AREA_DE_WORK.LD01.LD01_BARRA2);

                /*" -1061- MOVE WDATA-VIG-DIA TO LD01-DIA-PGT1 */
                _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_DIA, AREA_DE_WORK.LD01.LD01_DIA_PGT1);

                /*" -1062- MOVE WDATA-VIG-MES TO LD01-MES-PGT1 */
                _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES, AREA_DE_WORK.LD01.LD01_MES_PGT1);

                /*" -1063- MOVE WDATA-VIG-ANO TO LD01-ANO-PGT1 */
                _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_ANO, AREA_DE_WORK.LD01.LD01_ANO_PGT1);

                /*" -1064- ELSE */
            }
            else
            {


                /*" -1065- MOVE ' ' TO LD01-BARRA1 */
                _.Move(" ", AREA_DE_WORK.LD01.LD01_BARRA1);

                /*" -1066- MOVE ' ' TO LD01-BARRA2 */
                _.Move(" ", AREA_DE_WORK.LD01.LD01_BARRA2);

                /*" -1067- MOVE ZEROS TO LD01-DIA-PGT1 */
                _.Move(0, AREA_DE_WORK.LD01.LD01_DIA_PGT1);

                /*" -1068- MOVE ZEROS TO LD01-MES-PGT1 */
                _.Move(0, AREA_DE_WORK.LD01.LD01_MES_PGT1);

                /*" -1070- MOVE ZEROS TO LD01-ANO-PGT1. */
                _.Move(0, AREA_DE_WORK.LD01.LD01_ANO_PGT1);
            }


            /*" -1071- IF AC-COR-FATOR NOT EQUAL ZEROS */

            if (AREA_DE_WORK.AC_COR_FATOR != 00)
            {

                /*" -1072- MOVE WS-DATA-COR TO WDATA-VIGENCIA */
                _.Move(WS_DATA_COR, AREA_DE_WORK.WDATA_VIGENCIA);

                /*" -1073- MOVE '/' TO LD01-BARRA3 */
                _.Move("/", AREA_DE_WORK.LD01.LD01_BARRA3);

                /*" -1074- MOVE '/' TO LD01-BARRA4 */
                _.Move("/", AREA_DE_WORK.LD01.LD01_BARRA4);

                /*" -1075- MOVE WDATA-VIG-DIA TO LD01-DIA-PGT2 */
                _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_DIA, AREA_DE_WORK.LD01.LD01_DIA_PGT2);

                /*" -1076- MOVE WDATA-VIG-MES TO LD01-MES-PGT2 */
                _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES, AREA_DE_WORK.LD01.LD01_MES_PGT2);

                /*" -1077- MOVE WDATA-VIG-ANO TO LD01-ANO-PGT2 */
                _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_ANO, AREA_DE_WORK.LD01.LD01_ANO_PGT2);

                /*" -1078- ELSE */
            }
            else
            {


                /*" -1079- MOVE ' ' TO LD01-BARRA3 */
                _.Move(" ", AREA_DE_WORK.LD01.LD01_BARRA3);

                /*" -1080- MOVE ' ' TO LD01-BARRA4 */
                _.Move(" ", AREA_DE_WORK.LD01.LD01_BARRA4);

                /*" -1081- MOVE ZEROS TO LD01-DIA-PGT2 */
                _.Move(0, AREA_DE_WORK.LD01.LD01_DIA_PGT2);

                /*" -1082- MOVE ZEROS TO LD01-MES-PGT2 */
                _.Move(0, AREA_DE_WORK.LD01.LD01_MES_PGT2);

                /*" -1084- MOVE ZEROS TO LD01-ANO-PGT2. */
                _.Move(0, AREA_DE_WORK.LD01.LD01_ANO_PGT2);
            }


            /*" -1085- ADD 1 TO AC-LINHAS */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 1;

            /*" -1086- IF AC-LINHAS GREATER 53 */

            if (AREA_DE_WORK.AC_LINHAS > 53)
            {

                /*" -1088- PERFORM R5000-00-CABECALHOS. */

                R5000_00_CABECALHOS_SECTION();
            }


            /*" -1090- WRITE REG-VG0282B FROM LD01 AFTER 1. */
            _.Move(AREA_DE_WORK.LD01.GetMoveValues(), REG_VG0282B);

            RVG0282B.Write(REG_VG0282B.GetMoveValues().ToString());

            /*" -1091- ADD AC-ADM-VALOR TO ACT-ADM-VALOR. */
            AREA_DE_WORK.ACT_ADM_VALOR.Value = AREA_DE_WORK.ACT_ADM_VALOR + AREA_DE_WORK.AC_ADM_VALOR;

            /*" -1092- ADD AC-ADM-FATOR TO ACT-ADM-FATOR. */
            AREA_DE_WORK.ACT_ADM_FATOR.Value = AREA_DE_WORK.ACT_ADM_FATOR + AREA_DE_WORK.AC_ADM_FATOR;

            /*" -1093- ADD AC-COR-VALOR TO ACT-COR-VALOR. */
            AREA_DE_WORK.ACT_COR_VALOR.Value = AREA_DE_WORK.ACT_COR_VALOR + AREA_DE_WORK.AC_COR_VALOR;

            /*" -1093- ADD AC-COR-FATOR TO ACT-COR-FATOR. */
            AREA_DE_WORK.ACT_COR_FATOR.Value = AREA_DE_WORK.ACT_COR_FATOR + AREA_DE_WORK.AC_COR_FATOR;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-PROCESSA-VIGENCIA-SECTION */
        private void R1200_00_PROCESSA_VIGENCIA_SECTION()
        {
            /*" -1108- MOVE '120' TO WNR-EXEC-SQL. */
            _.Move("120", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1111- MOVE SPACES TO WFIM-V1HISTOPARC WTEM-V1HISTOPARC */
            _.Move("", AREA_DE_WORK.WFIM_V1HISTOPARC, AREA_DE_WORK.WTEM_V1HISTOPARC);

            /*" -1112- PERFORM R3100-00-DECLARE-V1HISTOPARC */

            R3100_00_DECLARE_V1HISTOPARC_SECTION();

            /*" -1117- PERFORM R3110-00-FETCH-V1HISTOPARC UNTIL WFIM-V1HISTOPARC NOT EQUAL SPACES */

            while (!(!AREA_DE_WORK.WFIM_V1HISTOPARC.IsEmpty()))
            {

                R3110_00_FETCH_V1HISTOPARC_SECTION();
            }

            /*" -1120- MOVE SPACES TO WFIM-V1COMISSAO WTEM-V1COMISSAO */
            _.Move("", AREA_DE_WORK.WFIM_V1COMISSAO, AREA_DE_WORK.WTEM_V1COMISSAO);

            /*" -1121- PERFORM R3200-00-DECLARE-V1COMISSAO */

            R3200_00_DECLARE_V1COMISSAO_SECTION();

            /*" -1124- PERFORM R3210-00-FETCH-V1COMISSAO UNTIL WFIM-V1COMISSAO NOT EQUAL SPACES */

            while (!(!AREA_DE_WORK.WFIM_V1COMISSAO.IsEmpty()))
            {

                R3210_00_FETCH_V1COMISSAO_SECTION();
            }

            /*" -1124- PERFORM R0910-00-FETCH-V1ENDOSSO. */

            R0910_00_FETCH_V1ENDOSSO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-SELECT-V1APOLICE-SECTION */
        private void R2100_00_SELECT_V1APOLICE_SECTION()
        {
            /*" -1137- MOVE '210' TO WNR-EXEC-SQL. */
            _.Move("210", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1142- PERFORM R2100_00_SELECT_V1APOLICE_DB_SELECT_1 */

            R2100_00_SELECT_V1APOLICE_DB_SELECT_1();

            /*" -1145- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1146- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1147- MOVE ZEROS TO V1APOL-CODCLIEN */
                    _.Move(0, V1APOL_CODCLIEN);

                    /*" -1148- ELSE */
                }
                else
                {


                    /*" -1149- DISPLAY 'ERRO ACESSO V1APOLICE' */
                    _.Display($"ERRO ACESSO V1APOLICE");

                    /*" -1149- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2100-00-SELECT-V1APOLICE-DB-SELECT-1 */
        public void R2100_00_SELECT_V1APOLICE_DB_SELECT_1()
        {
            /*" -1142- EXEC SQL SELECT CODCLIEN INTO :V1APOL-CODCLIEN FROM SEGUROS.V0APOLICE WHERE NUM_APOLICE = :V1RELA-NUM-APOL END-EXEC. */

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
            /*" -1162- MOVE '220' TO WNR-EXEC-SQL. */
            _.Move("220", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1168- PERFORM R2200_00_SELECT_V1SUBGRUPO_DB_SELECT_1 */

            R2200_00_SELECT_V1SUBGRUPO_DB_SELECT_1();

            /*" -1171- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1172- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1173- MOVE ZEROS TO V1SUBG-CODCLIEN */
                    _.Move(0, V1SUBG_CODCLIEN);

                    /*" -1174- ELSE */
                }
                else
                {


                    /*" -1175- DISPLAY 'ERRO ACESSO V1SUBGRUPO' */
                    _.Display($"ERRO ACESSO V1SUBGRUPO");

                    /*" -1175- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2200-00-SELECT-V1SUBGRUPO-DB-SELECT-1 */
        public void R2200_00_SELECT_V1SUBGRUPO_DB_SELECT_1()
        {
            /*" -1168- EXEC SQL SELECT COD_CLIENTE INTO :V1SUBG-CODCLIEN FROM SEGUROS.V0SUBGRUPO WHERE NUM_APOLICE = :V1ENDO-NUM-APOL AND COD_SUBGRUPO = :V1ENDO-CODSUBES END-EXEC. */

            var r2200_00_SELECT_V1SUBGRUPO_DB_SELECT_1_Query1 = new R2200_00_SELECT_V1SUBGRUPO_DB_SELECT_1_Query1()
            {
                V1ENDO_NUM_APOL = V1ENDO_NUM_APOL.ToString(),
                V1ENDO_CODSUBES = V1ENDO_CODSUBES.ToString(),
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
            /*" -1188- MOVE '230' TO WNR-EXEC-SQL. */
            _.Move("230", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1193- PERFORM R2300_00_SELECT_V1CLIENTE_DB_SELECT_1 */

            R2300_00_SELECT_V1CLIENTE_DB_SELECT_1();

            /*" -1196- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1197- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1198- MOVE SPACES TO V1CLIE-NOME */
                    _.Move("", V1CLIE_NOME);

                    /*" -1199- ELSE */
                }
                else
                {


                    /*" -1200- DISPLAY 'ERRO ACESSO V1CLIENTE' */
                    _.Display($"ERRO ACESSO V1CLIENTE");

                    /*" -1200- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2300-00-SELECT-V1CLIENTE-DB-SELECT-1 */
        public void R2300_00_SELECT_V1CLIENTE_DB_SELECT_1()
        {
            /*" -1193- EXEC SQL SELECT NOME_RAZAO INTO :V1CLIE-NOME FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = :WHOST-CODCLIEN END-EXEC. */

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
            /*" -1213- MOVE '240' TO WNR-EXEC-SQL. */
            _.Move("240", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1220- PERFORM R2400_00_SELECT_V1MOEDA_DB_SELECT_1 */

            R2400_00_SELECT_V1MOEDA_DB_SELECT_1();

            /*" -1223- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1224- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1225- MOVE 1 TO V1MOED-VLCRUZAD */
                    _.Move(1, V1MOED_VLCRUZAD);

                    /*" -1226- ELSE */
                }
                else
                {


                    /*" -1227- DISPLAY 'PROBLEMAS SELECT V1MOEDA ... ' */
                    _.Display($"PROBLEMAS SELECT V1MOEDA ... ");

                    /*" -1227- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2400-00-SELECT-V1MOEDA-DB-SELECT-1 */
        public void R2400_00_SELECT_V1MOEDA_DB_SELECT_1()
        {
            /*" -1220- EXEC SQL SELECT VLCRUZAD INTO :V1MOED-VLCRUZAD FROM SEGUROS.V1MOEDA WHERE CODUNIMO = :V1RELA-CODUNIMO AND DTINIVIG <= :WHOST-DTINIVIG AND DTTERVIG >= :WHOST-DTINIVIG END-EXEC. */

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
        /*" R3100-00-DECLARE-V1HISTOPARC-SECTION */
        private void R3100_00_DECLARE_V1HISTOPARC_SECTION()
        {
            /*" -1240- MOVE '310' TO WNR-EXEC-SQL. */
            _.Move("310", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1250- PERFORM R3100_00_DECLARE_V1HISTOPARC_DB_DECLARE_1 */

            R3100_00_DECLARE_V1HISTOPARC_DB_DECLARE_1();

            /*" -1252- PERFORM R3100_00_DECLARE_V1HISTOPARC_DB_OPEN_1 */

            R3100_00_DECLARE_V1HISTOPARC_DB_OPEN_1();

            /*" -1255- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1256- DISPLAY 'PROBLEMAS DECLARE V1HISTOPARC ... ' */
                _.Display($"PROBLEMAS DECLARE V1HISTOPARC ... ");

                /*" -1256- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3100-00-DECLARE-V1HISTOPARC-DB-OPEN-1 */
        public void R3100_00_DECLARE_V1HISTOPARC_DB_OPEN_1()
        {
            /*" -1252- EXEC SQL OPEN V1HISTOPARC END-EXEC. */

            V1HISTOPARC.Open();

        }

        [StopWatch]
        /*" R3200-00-DECLARE-V1COMISSAO-DB-DECLARE-1 */
        public void R3200_00_DECLARE_V1COMISSAO_DB_DECLARE_1()
        {
            /*" -1336- EXEC SQL DECLARE V1COMISSAO CURSOR FOR SELECT NRENDOS , OPERACAO , DTMOVTO , VLCOMIS , DATCLO FROM SEGUROS.V1COMISSAO WHERE NUM_APOLICE = :V1ENDO-NUM-APOL AND NRENDOS = :V1ENDO-NRENDOS END-EXEC. */
            V1COMISSAO = new VG0282B_V1COMISSAO(true);
            string GetQuery_V1COMISSAO()
            {
                var query = @$"SELECT NRENDOS
							, 
							OPERACAO
							, 
							DTMOVTO
							, 
							VLCOMIS
							, 
							DATCLO 
							FROM SEGUROS.V1COMISSAO 
							WHERE NUM_APOLICE = '{V1ENDO_NUM_APOL}' 
							AND NRENDOS = '{V1ENDO_NRENDOS}'";

                return query;
            }
            V1COMISSAO.GetQueryEvent += GetQuery_V1COMISSAO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R3110-00-FETCH-V1HISTOPARC-SECTION */
        private void R3110_00_FETCH_V1HISTOPARC_SECTION()
        {
            /*" -1269- MOVE '311' TO WNR-EXEC-SQL. */
            _.Move("311", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1274- PERFORM R3110_00_FETCH_V1HISTOPARC_DB_FETCH_1 */

            R3110_00_FETCH_V1HISTOPARC_DB_FETCH_1();

            /*" -1277- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1278- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1279- MOVE 'S' TO WFIM-V1HISTOPARC */
                    _.Move("S", AREA_DE_WORK.WFIM_V1HISTOPARC);

                    /*" -1279- PERFORM R3110_00_FETCH_V1HISTOPARC_DB_CLOSE_1 */

                    R3110_00_FETCH_V1HISTOPARC_DB_CLOSE_1();

                    /*" -1281- GO TO R3110-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3110_99_SAIDA*/ //GOTO
                    return;

                    /*" -1282- ELSE */
                }
                else
                {


                    /*" -1283- DISPLAY 'R3110-00 PROBLEMAS NO FETCH ... ' */
                    _.Display($"R3110-00 PROBLEMAS NO FETCH ... ");

                    /*" -1285- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1286- IF VIND-DTQITBCO LESS 0 */

            if (VIND_DTQITBCO < 0)
            {

                /*" -1288- MOVE '9999-12-31' TO V1HISP-DTQITBCO. */
                _.Move("9999-12-31", V1HISP_DTQITBCO);
            }


            /*" -1289- IF V1HISP-OPERACAO EQUAL 101 */

            if (V1HISP_OPERACAO == 101)
            {

                /*" -1290- ADD V1HISP-VLPRMLIQ TO AC-EMI-VALOR */
                AREA_DE_WORK.AC_EMI_VALOR.Value = AREA_DE_WORK.AC_EMI_VALOR + V1HISP_VLPRMLIQ;

                /*" -1291- MOVE V1HISP-DTMOVTO TO WHOST-DTINIVIG */
                _.Move(V1HISP_DTMOVTO, WHOST_DTINIVIG);

                /*" -1292- PERFORM R2400-00-SELECT-V1MOEDA */

                R2400_00_SELECT_V1MOEDA_SECTION();

                /*" -1294- COMPUTE WWORK-VALOR = V1HISP-VLPRMLIQ / V1MOED-VLCRUZAD */
                AREA_DE_WORK.WWORK_VALOR.Value = V1HISP_VLPRMLIQ / V1MOED_VLCRUZAD;

                /*" -1295- ADD WWORK-VALOR TO AC-EMI-FATOR */
                AREA_DE_WORK.AC_EMI_FATOR.Value = AREA_DE_WORK.AC_EMI_FATOR + AREA_DE_WORK.WWORK_VALOR;

                /*" -1296- ELSE */
            }
            else
            {


                /*" -1297- IF V1HISP-OPERACAO EQUAL 300 */

                if (V1HISP_OPERACAO == 300)
                {

                    /*" -1299- COMPUTE AC-COB-VALOR = AC-COB-VALOR - V1HISP-VLPRMLIQ */
                    AREA_DE_WORK.AC_COB_VALOR.Value = AREA_DE_WORK.AC_COB_VALOR - V1HISP_VLPRMLIQ;

                    /*" -1300- MOVE V1HISP-DTQITBCO TO WHOST-DTINIVIG */
                    _.Move(V1HISP_DTQITBCO, WHOST_DTINIVIG);

                    /*" -1301- PERFORM R2400-00-SELECT-V1MOEDA */

                    R2400_00_SELECT_V1MOEDA_SECTION();

                    /*" -1303- COMPUTE WWORK-VALOR = V1HISP-VLPRMLIQ / V1MOED-VLCRUZAD */
                    AREA_DE_WORK.WWORK_VALOR.Value = V1HISP_VLPRMLIQ / V1MOED_VLCRUZAD;

                    /*" -1305- COMPUTE AC-COB-FATOR = AC-COB-FATOR - WWORK-VALOR */
                    AREA_DE_WORK.AC_COB_FATOR.Value = AREA_DE_WORK.AC_COB_FATOR - AREA_DE_WORK.WWORK_VALOR;

                    /*" -1306- ELSE */
                }
                else
                {


                    /*" -1307- ADD V1HISP-VLPRMLIQ TO AC-COB-VALOR */
                    AREA_DE_WORK.AC_COB_VALOR.Value = AREA_DE_WORK.AC_COB_VALOR + V1HISP_VLPRMLIQ;

                    /*" -1308- MOVE V1HISP-DTQITBCO TO WHOST-DTINIVIG */
                    _.Move(V1HISP_DTQITBCO, WHOST_DTINIVIG);

                    /*" -1309- PERFORM R2400-00-SELECT-V1MOEDA */

                    R2400_00_SELECT_V1MOEDA_SECTION();

                    /*" -1311- COMPUTE WWORK-VALOR = V1HISP-VLPRMLIQ / V1MOED-VLCRUZAD */
                    AREA_DE_WORK.WWORK_VALOR.Value = V1HISP_VLPRMLIQ / V1MOED_VLCRUZAD;

                    /*" -1311- ADD WWORK-VALOR TO AC-COB-FATOR. */
                    AREA_DE_WORK.AC_COB_FATOR.Value = AREA_DE_WORK.AC_COB_FATOR + AREA_DE_WORK.WWORK_VALOR;
                }

            }


        }

        [StopWatch]
        /*" R3110-00-FETCH-V1HISTOPARC-DB-FETCH-1 */
        public void R3110_00_FETCH_V1HISTOPARC_DB_FETCH_1()
        {
            /*" -1274- EXEC SQL FETCH V1HISTOPARC INTO :V1HISP-OPERACAO , :V1HISP-DTMOVTO , :V1HISP-VLPRMLIQ , :V1HISP-DTQITBCO:VIND-DTQITBCO END-EXEC. */

            if (V1HISTOPARC.Fetch())
            {
                _.Move(V1HISTOPARC.V1HISP_OPERACAO, V1HISP_OPERACAO);
                _.Move(V1HISTOPARC.V1HISP_DTMOVTO, V1HISP_DTMOVTO);
                _.Move(V1HISTOPARC.V1HISP_VLPRMLIQ, V1HISP_VLPRMLIQ);
                _.Move(V1HISTOPARC.V1HISP_DTQITBCO, V1HISP_DTQITBCO);
                _.Move(V1HISTOPARC.VIND_DTQITBCO, VIND_DTQITBCO);
            }

        }

        [StopWatch]
        /*" R3110-00-FETCH-V1HISTOPARC-DB-CLOSE-1 */
        public void R3110_00_FETCH_V1HISTOPARC_DB_CLOSE_1()
        {
            /*" -1279- EXEC SQL CLOSE V1HISTOPARC END-EXEC */

            V1HISTOPARC.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3110_99_SAIDA*/

        [StopWatch]
        /*" R3200-00-DECLARE-V1COMISSAO-SECTION */
        private void R3200_00_DECLARE_V1COMISSAO_SECTION()
        {
            /*" -1324- MOVE '320' TO WNR-EXEC-SQL. */
            _.Move("320", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1336- PERFORM R3200_00_DECLARE_V1COMISSAO_DB_DECLARE_1 */

            R3200_00_DECLARE_V1COMISSAO_DB_DECLARE_1();

            /*" -1338- PERFORM R3200_00_DECLARE_V1COMISSAO_DB_OPEN_1 */

            R3200_00_DECLARE_V1COMISSAO_DB_OPEN_1();

            /*" -1341- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1342- DISPLAY 'PROBLEMAS DECLARE V1COMISSAO ... ' */
                _.Display($"PROBLEMAS DECLARE V1COMISSAO ... ");

                /*" -1344- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1345- MOVE SPACES TO WS-DATA-COR. */
            _.Move("", WS_DATA_COR);

            /*" -1345- MOVE SPACES TO WS-DATA-ADM. */
            _.Move("", WS_DATA_ADM);

        }

        [StopWatch]
        /*" R3200-00-DECLARE-V1COMISSAO-DB-OPEN-1 */
        public void R3200_00_DECLARE_V1COMISSAO_DB_OPEN_1()
        {
            /*" -1338- EXEC SQL OPEN V1COMISSAO END-EXEC. */

            V1COMISSAO.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/

        [StopWatch]
        /*" R3210-00-FETCH-V1COMISSAO-SECTION */
        private void R3210_00_FETCH_V1COMISSAO_SECTION()
        {
            /*" -1358- MOVE '321' TO WNR-EXEC-SQL. */
            _.Move("321", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1364- PERFORM R3210_00_FETCH_V1COMISSAO_DB_FETCH_1 */

            R3210_00_FETCH_V1COMISSAO_DB_FETCH_1();

            /*" -1367- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1368- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1369- MOVE 'S' TO WFIM-V1COMISSAO */
                    _.Move("S", AREA_DE_WORK.WFIM_V1COMISSAO);

                    /*" -1369- PERFORM R3210_00_FETCH_V1COMISSAO_DB_CLOSE_1 */

                    R3210_00_FETCH_V1COMISSAO_DB_CLOSE_1();

                    /*" -1371- GO TO R3210-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3210_99_SAIDA*/ //GOTO
                    return;

                    /*" -1372- ELSE */
                }
                else
                {


                    /*" -1373- DISPLAY 'R3210-00 PROBLEMAS NO FETCH ... ' */
                    _.Display($"R3210-00 PROBLEMAS NO FETCH ... ");

                    /*" -1375- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1381- IF V1COMI-OPERACAO NOT EQUAL 1001 AND V1COMI-OPERACAO NOT EQUAL 1002 AND V1COMI-OPERACAO NOT EQUAL 1003 AND V1COMI-OPERACAO NOT EQUAL 1201 AND V1COMI-OPERACAO NOT EQUAL 1202 AND V1COMI-OPERACAO NOT EQUAL 1203 */

            if (V1COMI_OPERACAO != 1001 && V1COMI_OPERACAO != 1002 && V1COMI_OPERACAO != 1003 && V1COMI_OPERACAO != 1201 && V1COMI_OPERACAO != 1202 && V1COMI_OPERACAO != 1203)
            {

                /*" -1383- GO TO R3210-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3210_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1384- IF VIND-DTMOVTO LESS THAN ZEROS */

            if (VIND_DTMOVTO < 00)
            {

                /*" -1386- GO TO R3210-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3210_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1388- MOVE V1COMI-VLCOMIS TO WWORK-VALOR1. */
            _.Move(V1COMI_VLCOMIS, AREA_DE_WORK.WWORK_VALOR1);

            /*" -1389- IF V1COMI-DTMOVTO LESS '1994-07-01' */

            if (V1COMI_DTMOVTO < "1994-07-01")
            {

                /*" -1391- COMPUTE WWORK-VALOR1 = WWORK-VALOR1 / 2750. */
                AREA_DE_WORK.WWORK_VALOR1.Value = AREA_DE_WORK.WWORK_VALOR1 / 2750f;
            }


            /*" -1392- MOVE V1COMI-DATCLO TO WHOST-DTINIVIG */
            _.Move(V1COMI_DATCLO, WHOST_DTINIVIG);

            /*" -1394- PERFORM R2400-00-SELECT-V1MOEDA */

            R2400_00_SELECT_V1MOEDA_SECTION();

            /*" -1396- IF V1COMI-OPERACAO EQUAL 1003 OR 1203 */

            if (V1COMI_OPERACAO.In("1003", "1203"))
            {

                /*" -1398- COMPUTE WWORK-VALOR1 = WWORK-VALOR1 * -1. */
                AREA_DE_WORK.WWORK_VALOR1.Value = AREA_DE_WORK.WWORK_VALOR1 * -1;
            }


            /*" -1401- IF V1COMI-OPERACAO EQUAL 1001 OR 1002 OR 1003 */

            if (V1COMI_OPERACAO.In("1001", "1002", "1003"))
            {

                /*" -1402- ADD WWORK-VALOR1 TO AC-COR-VALOR */
                AREA_DE_WORK.AC_COR_VALOR.Value = AREA_DE_WORK.AC_COR_VALOR + AREA_DE_WORK.WWORK_VALOR1;

                /*" -1404- COMPUTE WWORK-VALOR = WWORK-VALOR1 / V1MOED-VLCRUZAD */
                AREA_DE_WORK.WWORK_VALOR.Value = AREA_DE_WORK.WWORK_VALOR1 / V1MOED_VLCRUZAD;

                /*" -1405- ADD WWORK-VALOR TO AC-COR-FATOR */
                AREA_DE_WORK.AC_COR_FATOR.Value = AREA_DE_WORK.AC_COR_FATOR + AREA_DE_WORK.WWORK_VALOR;

                /*" -1406- MOVE V1COMI-DTMOVTO TO WS-DATA-COR */
                _.Move(V1COMI_DTMOVTO, WS_DATA_COR);

                /*" -1407- ELSE */
            }
            else
            {


                /*" -1410- IF V1COMI-OPERACAO EQUAL 1201 OR 1202 OR 1203 */

                if (V1COMI_OPERACAO.In("1201", "1202", "1203"))
                {

                    /*" -1411- ADD WWORK-VALOR1 TO AC-ADM-VALOR */
                    AREA_DE_WORK.AC_ADM_VALOR.Value = AREA_DE_WORK.AC_ADM_VALOR + AREA_DE_WORK.WWORK_VALOR1;

                    /*" -1413- COMPUTE WWORK-VALOR = WWORK-VALOR1 / V1MOED-VLCRUZAD */
                    AREA_DE_WORK.WWORK_VALOR.Value = AREA_DE_WORK.WWORK_VALOR1 / V1MOED_VLCRUZAD;

                    /*" -1414- ADD WWORK-VALOR TO AC-ADM-FATOR */
                    AREA_DE_WORK.AC_ADM_FATOR.Value = AREA_DE_WORK.AC_ADM_FATOR + AREA_DE_WORK.WWORK_VALOR;

                    /*" -1414- MOVE V1COMI-DTMOVTO TO WS-DATA-ADM. */
                    _.Move(V1COMI_DTMOVTO, WS_DATA_ADM);
                }

            }


        }

        [StopWatch]
        /*" R3210-00-FETCH-V1COMISSAO-DB-FETCH-1 */
        public void R3210_00_FETCH_V1COMISSAO_DB_FETCH_1()
        {
            /*" -1364- EXEC SQL FETCH V1COMISSAO INTO :V1COMI-NRENDOS, :V1COMI-OPERACAO , :V1COMI-DTMOVTO:VIND-DTMOVTO, :V1COMI-VLCOMIS , :V1COMI-DATCLO END-EXEC. */

            if (V1COMISSAO.Fetch())
            {
                _.Move(V1COMISSAO.V1COMI_NRENDOS, V1COMI_NRENDOS);
                _.Move(V1COMISSAO.V1COMI_OPERACAO, V1COMI_OPERACAO);
                _.Move(V1COMISSAO.V1COMI_DTMOVTO, V1COMI_DTMOVTO);
                _.Move(V1COMISSAO.VIND_DTMOVTO, VIND_DTMOVTO);
                _.Move(V1COMISSAO.V1COMI_VLCOMIS, V1COMI_VLCOMIS);
                _.Move(V1COMISSAO.V1COMI_DATCLO, V1COMI_DATCLO);
            }

        }

        [StopWatch]
        /*" R3210-00-FETCH-V1COMISSAO-DB-CLOSE-1 */
        public void R3210_00_FETCH_V1COMISSAO_DB_CLOSE_1()
        {
            /*" -1369- EXEC SQL CLOSE V1COMISSAO END-EXEC */

            V1COMISSAO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3210_99_SAIDA*/

        [StopWatch]
        /*" R5000-00-CABECALHOS-SECTION */
        private void R5000_00_CABECALHOS_SECTION()
        {
            /*" -1427- MOVE '500' TO WNR-EXEC-SQL. */
            _.Move("500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1428- ADD 1 TO AC-PAGINA */
            AREA_DE_WORK.AC_PAGINA.Value = AREA_DE_WORK.AC_PAGINA + 1;

            /*" -1429- MOVE AC-PAGINA TO LC01-PAGINA */
            _.Move(AREA_DE_WORK.AC_PAGINA, AREA_DE_WORK.LC01.LC01_PAGINA);

            /*" -1431- MOVE ZEROS TO AC-LINHAS */
            _.Move(0, AREA_DE_WORK.AC_LINHAS);

            /*" -1432- WRITE REG-VG0282B FROM LC01 AFTER PAGE */
            _.Move(AREA_DE_WORK.LC01.GetMoveValues(), REG_VG0282B);

            RVG0282B.Write(REG_VG0282B.GetMoveValues().ToString());

            /*" -1433- WRITE REG-VG0282B FROM LC02 AFTER 1 */
            _.Move(AREA_DE_WORK.LC02.GetMoveValues(), REG_VG0282B);

            RVG0282B.Write(REG_VG0282B.GetMoveValues().ToString());

            /*" -1434- WRITE REG-VG0282B FROM LC03 AFTER 1 */
            _.Move(AREA_DE_WORK.LC03.GetMoveValues(), REG_VG0282B);

            RVG0282B.Write(REG_VG0282B.GetMoveValues().ToString());

            /*" -1435- WRITE REG-VG0282B FROM LC04 AFTER 1 */
            _.Move(AREA_DE_WORK.LC04.GetMoveValues(), REG_VG0282B);

            RVG0282B.Write(REG_VG0282B.GetMoveValues().ToString());

            /*" -1436- WRITE REG-VG0282B FROM LC05 AFTER 1 */
            _.Move(AREA_DE_WORK.LC05.GetMoveValues(), REG_VG0282B);

            RVG0282B.Write(REG_VG0282B.GetMoveValues().ToString());

            /*" -1437- WRITE REG-VG0282B FROM LC06 AFTER 1 */
            _.Move(AREA_DE_WORK.LC06.GetMoveValues(), REG_VG0282B);

            RVG0282B.Write(REG_VG0282B.GetMoveValues().ToString());

            /*" -1438- WRITE REG-VG0282B FROM LC07 AFTER 1 */
            _.Move(AREA_DE_WORK.LC07.GetMoveValues(), REG_VG0282B);

            RVG0282B.Write(REG_VG0282B.GetMoveValues().ToString());

            /*" -1439- WRITE REG-VG0282B FROM LC08 AFTER 1 */
            _.Move(AREA_DE_WORK.LC08.GetMoveValues(), REG_VG0282B);

            RVG0282B.Write(REG_VG0282B.GetMoveValues().ToString());

            /*" -1440- WRITE REG-VG0282B FROM LC09 AFTER 1 */
            _.Move(AREA_DE_WORK.LC09.GetMoveValues(), REG_VG0282B);

            RVG0282B.Write(REG_VG0282B.GetMoveValues().ToString());

            /*" -1440- WRITE REG-VG0282B FROM LC07 AFTER 1. */
            _.Move(AREA_DE_WORK.LC07.GetMoveValues(), REG_VG0282B);

            RVG0282B.Write(REG_VG0282B.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_99_SAIDA*/

        [StopWatch]
        /*" R8000-00-OPEN-ARQUIVOS-SECTION */
        private void R8000_00_OPEN_ARQUIVOS_SECTION()
        {
            /*" -1453- MOVE '800' TO WNR-EXEC-SQL. */
            _.Move("800", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1453- OPEN OUTPUT RVG0282B. */
            RVG0282B.Open(REG_VG0282B);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-CLOSE-ARQUIVOS-SECTION */
        private void R9000_00_CLOSE_ARQUIVOS_SECTION()
        {
            /*" -1466- MOVE '900' TO WNR-EXEC-SQL. */
            _.Move("900", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1466- CLOSE RVG0282B. */
            RVG0282B.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1481- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -1483- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -1485- CLOSE RVG0282B */
            RVG0282B.Close();

            /*" -1485- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1487- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1491- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1491- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}