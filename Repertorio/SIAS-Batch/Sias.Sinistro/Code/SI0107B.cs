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
using Sias.Sinistro.DB2.SI0107B;

namespace Code
{
    public class SI0107B
    {
        public bool IsCall { get; set; }

        public SI0107B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-----------------------------------------------------------*           */
        /*" ====>* MIGRACAO P/ COBOL II - FASE 1 - ITEM 3.2.A -> OK - ADRIANA            */
        /*"      *-----------------------------------------------------------*           */
        /*"      *REMARKS.                                                               */
        /*"      *///////////////////////////////////////////////////////////////      */
        /*"      * SISTEMA              =    SINISTRO.                         //      */
        /*"      * PROGRAMA             =    SI0107B.                          //      */
        /*"      *                                                             //      */
        /*"      * OBJETIVO             =    EMISSAO DE RELATORIO DE PRESTACAO //      */
        /*"      *                           DE SERVICOS ACUMULADO POR PRODU-  //      */
        /*"      *                           TOR.                              //      */
        /*"      * ANALISTA/PROGRAMADOR =    PROCAS/PROCAS.                    //      */
        /*"      *                           MARCO/92   -   FREDERICO          //      */
        /*"      * DATA                 =    16/07/91.                         //      */
        /*"      *                                                                *      */
        /*"      * CONVERSAO ANO 2000              CONSEDA4              05/1998  *      */
        /*"      *                                                                *      */
        /*"      * REVISAO - ANO 2000              CONSEDA4           06/06/1998  *      */
        /*"      *///////////////////////////////////////////////////////////////      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _IMPRESSAO { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis IMPRESSAO
        {
            get
            {
                _.Move(REGIMP, _IMPRESSAO); VarBasis.RedefinePassValue(REGIMP, _IMPRESSAO, REGIMP); return _IMPRESSAO;
            }
        }
        /*"01                  REGIMP.*/
        public SI0107B_REGIMP REGIMP { get; set; } = new SI0107B_REGIMP();
        public class SI0107B_REGIMP : VarBasis
        {
            /*"  05                FILLER          PIC X(132).*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77          V1EMPRESA-COD-EMP      PIC S9(004)       COMP.*/
        public IntBasis V1EMPRESA_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1EMPRESA-NOM-EMP      PIC  X(040).*/
        public StringBasis V1EMPRESA_NOM_EMP { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77        HOST-CODPDT            PIC  S9(009)     COMP.*/
        public IntBasis HOST_CODPDT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77        TRELSIN-IDSISTEM       PIC X(002).*/
        public StringBasis TRELSIN_IDSISTEM { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"77        TRELSIN-CODRELAT       PIC X(002).*/
        public StringBasis TRELSIN_CODRELAT { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"77        TRELSIN-SITUACAO       PIC X(001).*/
        public StringBasis TRELSIN_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77        TRELSIN-DTINIVIG       PIC X(010).*/
        public StringBasis TRELSIN_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77        TRELSIN-DTTERVIG       PIC X(010).*/
        public StringBasis TRELSIN_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77        RENDIMEN-CODPDT        PIC  S9(009)     COMP.*/
        public IntBasis RENDIMEN_CODPDT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77        RENDIMEN-VALRDT        PIC  S9(013)V99  COMP-3.*/
        public DoubleBasis RENDIMEN_VALRDT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        IMPOST-CODPDT          PIC  S9(009)     COMP.*/
        public IntBasis IMPOST_CODPDT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77        IMPOST-VLIMPOST        PIC  S9(013)V99  COMP-3.*/
        public DoubleBasis IMPOST_VLIMPOST { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        TCLIFOR-NOME           PIC   X(040).*/
        public StringBasis TCLIFOR_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77        TSISTEMA-DTMOVABE      PIC    X(010).*/
        public StringBasis TSISTEMA_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77        TSISTEMA-DTCURRENT     PIC    X(010).*/
        public StringBasis TSISTEMA_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"03       WORK.*/
        public SI0107B_WORK WORK { get; set; } = new SI0107B_WORK();
        public class SI0107B_WORK : VarBasis
        {
            /*"  05     WFIM-TRELSIN             PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_TRELSIN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05     WFIM-JOIN                PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_JOIN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05     WCODPDT-ANT              PIC  9(004)    VALUE ZEROS.*/
            public IntBasis WCODPDT_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05     WCT-LINHA                PIC  9(004)    VALUE 90.*/
            public IntBasis WCT_LINHA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"), 90);
            /*"  05     WCT-FOLHA                PIC  9(004)    VALUE ZEROS.*/
            public IntBasis WCT_FOLHA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05     WCT-LIDOS-TRELSIN        PIC  9(004)    VALUE ZEROS.*/
            public IntBasis WCT_LIDOS_TRELSIN { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05     WCT-LIDOS-JOIN           PIC  9(004)    VALUE ZEROS.*/
            public IntBasis WCT_LIDOS_JOIN { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05     WAC-VALRDT               PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis WAC_VALRDT { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05     WAC-VLIMPOST             PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis WAC_VLIMPOST { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05     WAC-VALRDT-TOTAL         PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis WAC_VALRDT_TOTAL { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05     WAC-VLIMPOST-TOTAL       PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis WAC_VLIMPOST_TOTAL { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"03       WDTINIVIG.*/
        }
        public SI0107B_WDTINIVIG WDTINIVIG { get; set; } = new SI0107B_WDTINIVIG();
        public class SI0107B_WDTINIVIG : VarBasis
        {
            /*"  05     ANO-I                   PIC 9(004).*/
            public IntBasis ANO_I { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05     FILLER                  PIC X(001) VALUE '-'.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"  05     MES-I                   PIC 9(002).*/
            public IntBasis MES_I { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05     FILLER                  PIC X(001) VALUE '-'.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"  05     DIA-I                   PIC 9(002).*/
            public IntBasis DIA_I { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"03       WDTINIVIG-R  REDEFINES WDTINIVIG   PIC X(010).*/
        }
        private _REDEF_StringBasis _wdtinivig_r { get; set; }
        public _REDEF_StringBasis WDTINIVIG_R
        {
            get { _wdtinivig_r = new _REDEF_StringBasis(new PIC("X", "010", "X(010).")); ; _.Move(WDTINIVIG, _wdtinivig_r); VarBasis.RedefinePassValue(WDTINIVIG, _wdtinivig_r, WDTINIVIG); _wdtinivig_r.ValueChanged += () => { _.Move(_wdtinivig_r, WDTINIVIG); }; return _wdtinivig_r; }
            set { VarBasis.RedefinePassValue(value, _wdtinivig_r, WDTINIVIG); }
        }  //Redefines
        /*"03       WDTTERVIG.*/
        public SI0107B_WDTTERVIG WDTTERVIG { get; set; } = new SI0107B_WDTTERVIG();
        public class SI0107B_WDTTERVIG : VarBasis
        {
            /*"  05     ANO-F                   PIC 9(004).*/
            public IntBasis ANO_F { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05     FILLER                  PIC X(001) VALUE '-'.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"  05     MES-F                   PIC 9(002).*/
            public IntBasis MES_F { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05     FILLER                  PIC X(001) VALUE '-'.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"  05     DIA-F                   PIC 9(002).*/
            public IntBasis DIA_F { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"03       WDTTERVIG-R  REDEFINES WDTTERVIG   PIC X(010).*/
        }
        private _REDEF_StringBasis _wdttervig_r { get; set; }
        public _REDEF_StringBasis WDTTERVIG_R
        {
            get { _wdttervig_r = new _REDEF_StringBasis(new PIC("X", "010", "X(010).")); ; _.Move(WDTTERVIG, _wdttervig_r); VarBasis.RedefinePassValue(WDTTERVIG, _wdttervig_r, WDTTERVIG); _wdttervig_r.ValueChanged += () => { _.Move(_wdttervig_r, WDTTERVIG); }; return _wdttervig_r; }
            set { VarBasis.RedefinePassValue(value, _wdttervig_r, WDTTERVIG); }
        }  //Redefines
        /*"03      WABEND.*/
        public SI0107B_WABEND WABEND { get; set; } = new SI0107B_WABEND();
        public class SI0107B_WABEND : VarBasis
        {
            /*"  05    FILLER            PIC X(010) VALUE        'SI0107B  '.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"SI0107B  ");
            /*"  05    PARAGRAFO         PIC X(030) VALUE SPACES.*/
            public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
            /*"  05    FILLER            PIC X(028) VALUE        '*** ERRO EXEC SQL  NUMERO   '.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @"*** ERRO EXEC SQL  NUMERO   ");
            /*"  05    WNR-EXEC-SQL      PIC X(003) VALUE '000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
            /*"  05    FILLER            PIC X(014) VALUE        '   SQLCODE =  '.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLCODE =  ");
            /*"  05    WSQLCODE          PIC ZZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            /*"  03            WDATA-CURR.*/
            public SI0107B_WDATA_CURR WDATA_CURR { get; set; } = new SI0107B_WDATA_CURR();
            public class SI0107B_WDATA_CURR : VarBasis
            {
                /*"    05          WDATA-AA-CURR       PIC  9(004) VALUE ZEROS.*/
                public IntBasis WDATA_AA_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    05          FILLER              PIC  X(001) VALUE  SPACES.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          WDATA-MM-CURR       PIC  9(002) VALUE ZEROS.*/
                public IntBasis WDATA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          FILLER              PIC  X(001) VALUE  SPACES.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          WDATA-DD-CURR       PIC  9(002) VALUE ZEROS.*/
                public IntBasis WDATA_DD_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  03            WHORA-CURR.*/
            }
            public SI0107B_WHORA_CURR WHORA_CURR { get; set; } = new SI0107B_WHORA_CURR();
            public class SI0107B_WHORA_CURR : VarBasis
            {
                /*"    05          WHORA-HH-CURR       PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_HH_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          WHORA-MM-CURR       PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          WHORA-SS-CURR       PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_SS_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          WHORA-CC-CURR       PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_CC_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  03            WDATA-CABEC.*/
            }
            public SI0107B_WDATA_CABEC WDATA_CABEC { get; set; } = new SI0107B_WDATA_CABEC();
            public class SI0107B_WDATA_CABEC : VarBasis
            {
                /*"    05          WDATA-DD-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          FILLER              PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05          WDATA-MM-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          FILLER              PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05          WDATA-AA-CABEC      PIC  9(004) VALUE ZEROS.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  03            WHORA-CABEC.*/
            }
            public SI0107B_WHORA_CABEC WHORA_CABEC { get; set; } = new SI0107B_WHORA_CABEC();
            public class SI0107B_WHORA_CABEC : VarBasis
            {
                /*"    05          WHORA-HH-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_HH_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          FILLER              PIC  X(001) VALUE ':'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"    05          WHORA-MM-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          FILLER              PIC  X(001) VALUE ':'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"    05          WHORA-SS-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_SS_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  03           LC01.*/
            }
            public SI0107B_LC01 LC01 { get; set; } = new SI0107B_LC01();
            public class SI0107B_LC01 : VarBasis
            {
                /*"    05         LC01-RELATORIO      PIC  X(009) VALUE 'SI0107B.1'*/
                public StringBasis LC01_RELATORIO { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"SI0107B.1");
                /*"    05         FILLER              PIC  X(034) VALUE  SPACES.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"");
                /*"    05         LC01-EMPRESA        PIC  X(040) VALUE  SPACES.*/
                public StringBasis LC01_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05         FILLER              PIC  X(034) VALUE  SPACES.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"");
                /*"    05         FILLER              PIC  X(011) VALUE 'PAGINA'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"PAGINA");
                /*"    05         LC01-FOLHA          PIC  ZZZ9.*/
                public IntBasis LC01_FOLHA { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
                /*"  03            LC02.*/
            }
            public SI0107B_LC02 LC02 { get; set; } = new SI0107B_LC02();
            public class SI0107B_LC02 : VarBasis
            {
                /*"    05          FILLER              PIC  X(117) VALUE  SPACES.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "117", "X(117)"), @"");
                /*"    05          FILLER              PIC  X(007) VALUE 'DATA'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"DATA");
                /*"    05          LC02-DATA           PIC  X(008) VALUE  SPACES.*/
                public StringBasis LC02_DATA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"01      LC03.*/
            }
        }
        public SI0107B_LC03 LC03 { get; set; } = new SI0107B_LC03();
        public class SI0107B_LC03 : VarBasis
        {
            /*"  05    FILLER            PIC  X(025) VALUE SPACES.*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
            /*"  05    FILLER            PIC  X(052) VALUE        'RESUMO DE PRESTACAO DE SERVICOS PAGOS NO PERIODO DE '.*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "52", "X(052)"), @"RESUMO DE PRESTACAO DE SERVICOS PAGOS NO PERIODO DE ");
            /*"  05    FILLER            PIC  X(001) VALUE SPACES.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05    LC03-DIA-I        PIC  9(002) VALUE ZEROS.*/
            public IntBasis LC03_DIA_I { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05    FILLER            PIC  X(001) VALUE '/'.*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
            /*"  05    LC03-MES-I        PIC  9(002) VALUE ZEROS.*/
            public IntBasis LC03_MES_I { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05    FILLER            PIC  X(001) VALUE '/'.*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
            /*"  05    LC03-ANO-I        PIC  9(004) VALUE ZEROS.*/
            public IntBasis LC03_ANO_I { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05    FILLER            PIC  X(003) VALUE ' A '.*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" A ");
            /*"  05    LC03-DIA-F        PIC  9(002) VALUE ZEROS.*/
            public IntBasis LC03_DIA_F { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05    FILLER            PIC  X(001) VALUE '/'.*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
            /*"  05    LC03-MES-F        PIC  9(002) VALUE ZEROS.*/
            public IntBasis LC03_MES_F { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05    FILLER            PIC  X(001) VALUE '/'.*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
            /*"  05    LC03-ANO-F        PIC  9(004) VALUE ZEROS.*/
            public IntBasis LC03_ANO_F { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05    FILLER            PIC  X(032) VALUE  SPACES.*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "32", "X(032)"), @"");
            /*"01      LC04.*/
        }
        public SI0107B_LC04 LC04 { get; set; } = new SI0107B_LC04();
        public class SI0107B_LC04 : VarBasis
        {
            /*"  05    FILLER            PIC  X(132) VALUE ALL '-'.*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
            /*"01      LC05.*/
        }
        public SI0107B_LC05 LC05 { get; set; } = new SI0107B_LC05();
        public class SI0107B_LC05 : VarBasis
        {
            /*"  05    FILLER        PIC  X(004) VALUE  SPACES.*/
            public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
            /*"  05    FILLER        PIC  X(084) VALUE 'PRESTADOR DE SERVICOS'.*/
            public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "84", "X(084)"), @"PRESTADOR DE SERVICOS");
            /*"  05    FILLER        PIC  X(039) VALUE 'SERVICOS PAGOS'.*/
            public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "39", "X(039)"), @"SERVICOS PAGOS");
            /*"  05    FILLER        PIC  X(005) VALUE 'I.R.'.*/
            public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"I.R.");
            /*"01            LC06.*/
        }
        public SI0107B_LC06 LC06 { get; set; } = new SI0107B_LC06();
        public class SI0107B_LC06 : VarBasis
        {
            /*"  05    FILLER        PIC  X(117) VALUE SPACES.*/
            public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "117", "X(117)"), @"");
            /*"  05    FILLER        PIC  X(007) VALUE 'HORA'.*/
            public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"HORA");
            /*"  05    LC06-HORA     PIC  X(008) VALUE  SPACES.*/
            public StringBasis LC06_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"01      LD01.*/
        }
        public SI0107B_LD01 LD01 { get; set; } = new SI0107B_LD01();
        public class SI0107B_LD01 : VarBasis
        {
            /*"  05    FILLER                    PIC X(003) VALUE SPACES.*/
            public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05    LD01-CODIGO               PIC 9(003) VALUE ZEROS.*/
            public IntBasis LD01_CODIGO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  05    FILLER                    PIC X(003) VALUE ' - '.*/
            public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" - ");
            /*"  05    LD01-NOME-PRODUTOR        PIC X(040) VALUE SPACES.*/
            public StringBasis LD01_NOME_PRODUTOR { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"  05    FILLER                    PIC X(035) VALUE SPACES.*/
            public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"");
            /*"  05    LD01-SERVICOS-PAGOS       PIC ZZZ.ZZZ.ZZZ.ZZ9,99.*/
            public DoubleBasis LD01_SERVICOS_PAGOS { get; set; } = new DoubleBasis(new PIC("9", "12", "ZZZ.ZZZ.ZZZ.ZZ9V99."), 2);
            /*"  05    FILLER                    PIC X(012) VALUE SPACES.*/
            public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"");
            /*"  05    LD01-IR                   PIC ZZZ.ZZZ.ZZZ.ZZ9,99.*/
            public DoubleBasis LD01_IR { get; set; } = new DoubleBasis(new PIC("9", "12", "ZZZ.ZZZ.ZZZ.ZZ9V99."), 2);
            /*"  05    FILLER                    PIC X(001) VALUE SPACES.*/
            public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"01      LT01.*/
        }
        public SI0107B_LT01 LT01 { get; set; } = new SI0107B_LT01();
        public class SI0107B_LT01 : VarBasis
        {
            /*"  05    FILLER                    PIC X(050) VALUE SPACES.*/
            public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
            /*"  05    FILLER                    PIC X(030) VALUE               'T O T A L . . . . . . . . . .'.*/
            public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"T O T A L . . . . . . . . . .");
            /*"  05    FILLER                    PIC X(004) VALUE SPACES.*/
            public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
            /*"  05    LT01-SERVICOS-PAGOS       PIC ZZZ.ZZZ.ZZZ.ZZ9,99.*/
            public DoubleBasis LT01_SERVICOS_PAGOS { get; set; } = new DoubleBasis(new PIC("9", "12", "ZZZ.ZZZ.ZZZ.ZZ9V99."), 2);
            /*"  05    FILLER                    PIC X(012) VALUE SPACES.*/
            public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"");
            /*"  05    LT01-IR                   PIC ZZZ.ZZZ.ZZZ.ZZ9,99.*/
            public DoubleBasis LT01_IR { get; set; } = new DoubleBasis(new PIC("9", "12", "ZZZ.ZZZ.ZZZ.ZZ9V99."), 2);
            /*"01          LK-LINK.*/
        }
        public SI0107B_LK_LINK LK_LINK { get; set; } = new SI0107B_LK_LINK();
        public class SI0107B_LK_LINK : VarBasis
        {
            /*"  03        LK-RTCODE           PIC  S9(004)   VALUE +0   COMP.*/
            public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03        LK-TAMANHO          PIC  S9(004)   VALUE +40  COMP.*/
            public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
            /*"  03        LK-TITULO           PIC   X(132)   VALUE  SPACES.*/
            public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
        }


        public SI0107B_V1RELATSINI V1RELATSINI { get; set; } = new SI0107B_V1RELATSINI();
        public SI0107B_RENDIMP RENDIMP { get; set; } = new SI0107B_RENDIMP();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string IMPRESSAO_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                IMPRESSAO.SetFile(IMPRESSAO_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM M-000-000-INICIO-SECTION */

                M_000_000_INICIO_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" M-000-000-INICIO-SECTION */
        private void M_000_000_INICIO_SECTION()
        {
            /*" -251- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -254- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -257- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -261- OPEN OUTPUT IMPRESSAO. */
            IMPRESSAO.Open(REGIMP);

            /*" -263- PERFORM 010-000-LER-TSISTEMA */

            M_010_000_LER_TSISTEMA_SECTION();

            /*" -265- PERFORM 015-000-CABECALHOS */

            M_015_000_CABECALHOS_SECTION();

            /*" -266- PERFORM 020-000-DECLARE-TRELSIN */

            M_020_000_DECLARE_TRELSIN_SECTION();

            /*" -268- PERFORM 040-000-FETCH-TRELSIN */

            M_040_000_FETCH_TRELSIN_SECTION();

            /*" -269- IF WFIM-TRELSIN EQUAL 'S' */

            if (WORK.WFIM_TRELSIN == "S")
            {

                /*" -270- DISPLAY 'NAO HOUVE PEDIDO NA TRELSIN' */
                _.Display($"NAO HOUVE PEDIDO NA TRELSIN");

                /*" -271- PERFORM 110-000-FINALIZA */

                M_110_000_FINALIZA_SECTION();

                /*" -273- GO TO 000-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_999_EXIT*/ //GOTO
                return;
            }


            /*" -274- PERFORM 030-000-PRINCIPAL UNTIL WFIM-TRELSIN EQUAL 'S' */

            while (!(WORK.WFIM_TRELSIN == "S"))
            {

                M_030_000_PRINCIPAL_SECTION();
            }

            /*" -276- PERFORM 070-000-IMPRESSAO */

            M_070_000_IMPRESSAO_SECTION();

            /*" -277- IF WCT-FOLHA EQUAL 1 */

            if (WORK.WCT_FOLHA == 1)
            {

                /*" -278- MOVE WAC-VALRDT-TOTAL TO LT01-SERVICOS-PAGOS */
                _.Move(WORK.WAC_VALRDT_TOTAL, LT01.LT01_SERVICOS_PAGOS);

                /*" -279- MOVE WAC-VLIMPOST-TOTAL TO LT01-IR */
                _.Move(WORK.WAC_VLIMPOST_TOTAL, LT01.LT01_IR);

                /*" -282- WRITE REGIMP FROM LT01 AFTER 2. */
                _.Move(LT01.GetMoveValues(), REGIMP);

                IMPRESSAO.Write(REGIMP.GetMoveValues().ToString());
            }


            /*" -283- PERFORM 100-000-ATUALIZA-TRELSIN */

            M_100_000_ATUALIZA_TRELSIN_SECTION();

            /*" -285- PERFORM 110-000-FINALIZA. */

            M_110_000_FINALIZA_SECTION();

            /*" -285- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_999_EXIT*/

        [StopWatch]
        /*" M-010-000-LER-TSISTEMA-SECTION */
        private void M_010_000_LER_TSISTEMA_SECTION()
        {
            /*" -298- MOVE '010' TO WNR-EXEC-SQL */
            _.Move("010", WABEND.WNR_EXEC_SQL);

            /*" -301- MOVE '010-000-LER-TSISTEMA' TO PARAGRAFO */
            _.Move("010-000-LER-TSISTEMA", WABEND.PARAGRAFO);

            /*" -311- PERFORM M_010_000_LER_TSISTEMA_DB_SELECT_1 */

            M_010_000_LER_TSISTEMA_DB_SELECT_1();

            /*" -314- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -315- DISPLAY 'REGISTRO NAO ENCONTRADO NA TSISTEMA' */
                _.Display($"REGISTRO NAO ENCONTRADO NA TSISTEMA");

                /*" -315- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-010-000-LER-TSISTEMA-DB-SELECT-1 */
        public void M_010_000_LER_TSISTEMA_DB_SELECT_1()
        {
            /*" -311- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :TSISTEMA-DTMOVABE, :TSISTEMA-DTCURRENT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'SI' END-EXEC. */

            var m_010_000_LER_TSISTEMA_DB_SELECT_1_Query1 = new M_010_000_LER_TSISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_010_000_LER_TSISTEMA_DB_SELECT_1_Query1.Execute(m_010_000_LER_TSISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.TSISTEMA_DTMOVABE, TSISTEMA_DTMOVABE);
                _.Move(executed_1.TSISTEMA_DTCURRENT, TSISTEMA_DTCURRENT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_010_999_EXIT*/

        [StopWatch]
        /*" M-015-000-CABECALHOS-SECTION */
        private void M_015_000_CABECALHOS_SECTION()
        {
            /*" -327- ACCEPT WHORA-CURR FROM TIME */
            _.Move(_.AcceptDate("TIME"), WABEND.WHORA_CURR);

            /*" -328- MOVE WHORA-HH-CURR TO WHORA-HH-CABEC */
            _.Move(WABEND.WHORA_CURR.WHORA_HH_CURR, WABEND.WHORA_CABEC.WHORA_HH_CABEC);

            /*" -329- MOVE WHORA-MM-CURR TO WHORA-MM-CABEC */
            _.Move(WABEND.WHORA_CURR.WHORA_MM_CURR, WABEND.WHORA_CABEC.WHORA_MM_CABEC);

            /*" -330- MOVE WHORA-SS-CURR TO WHORA-SS-CABEC */
            _.Move(WABEND.WHORA_CURR.WHORA_SS_CURR, WABEND.WHORA_CABEC.WHORA_SS_CABEC);

            /*" -332- MOVE WHORA-CABEC TO LC06-HORA */
            _.Move(WABEND.WHORA_CABEC, LC06.LC06_HORA);

            /*" -333- MOVE TSISTEMA-DTCURRENT TO WDATA-CURR */
            _.Move(TSISTEMA_DTCURRENT, WABEND.WDATA_CURR);

            /*" -334- MOVE WDATA-DD-CURR TO WDATA-DD-CABEC */
            _.Move(WABEND.WDATA_CURR.WDATA_DD_CURR, WABEND.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -335- MOVE WDATA-MM-CURR TO WDATA-MM-CABEC */
            _.Move(WABEND.WDATA_CURR.WDATA_MM_CURR, WABEND.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -336- MOVE WDATA-AA-CURR TO WDATA-AA-CABEC */
            _.Move(WABEND.WDATA_CURR.WDATA_AA_CURR, WABEND.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -338- MOVE WDATA-CABEC TO LC02-DATA */
            _.Move(WABEND.WDATA_CABEC, WABEND.LC02.LC02_DATA);

            /*" -342- PERFORM M_015_000_CABECALHOS_DB_SELECT_1 */

            M_015_000_CABECALHOS_DB_SELECT_1();

            /*" -345- MOVE V1EMPRESA-NOM-EMP TO LK-TITULO */
            _.Move(V1EMPRESA_NOM_EMP, LK_LINK.LK_TITULO);

            /*" -347- CALL 'PROALN01' USING LK-LINK */
            _.Call("PROALN01", LK_LINK);

            /*" -348- IF LK-RTCODE EQUAL ZEROS */

            if (LK_LINK.LK_RTCODE == 00)
            {

                /*" -349- MOVE LK-TITULO TO LC01-EMPRESA */
                _.Move(LK_LINK.LK_TITULO, WABEND.LC01.LC01_EMPRESA);

                /*" -350- ELSE */
            }
            else
            {


                /*" -351- DISPLAY 'PROBLEMA CALL V1EMPRESA' */
                _.Display($"PROBLEMA CALL V1EMPRESA");

                /*" -351- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


        }

        [StopWatch]
        /*" M-015-000-CABECALHOS-DB-SELECT-1 */
        public void M_015_000_CABECALHOS_DB_SELECT_1()
        {
            /*" -342- EXEC SQL SELECT NOME_EMPRESA INTO :V1EMPRESA-NOM-EMP FROM SEGUROS.V1EMPRESA WHERE COD_EMPRESA = 0 END-EXEC. */

            var m_015_000_CABECALHOS_DB_SELECT_1_Query1 = new M_015_000_CABECALHOS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_015_000_CABECALHOS_DB_SELECT_1_Query1.Execute(m_015_000_CABECALHOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1EMPRESA_NOM_EMP, V1EMPRESA_NOM_EMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_015_999_EXIT*/

        [StopWatch]
        /*" M-020-000-DECLARE-TRELSIN-SECTION */
        private void M_020_000_DECLARE_TRELSIN_SECTION()
        {
            /*" -365- MOVE '020' TO WNR-EXEC-SQL */
            _.Move("020", WABEND.WNR_EXEC_SQL);

            /*" -368- MOVE '020-000-DECLARE-TRELSIN' TO PARAGRAFO */
            _.Move("020-000-DECLARE-TRELSIN", WABEND.PARAGRAFO);

            /*" -382- PERFORM M_020_000_DECLARE_TRELSIN_DB_DECLARE_1 */

            M_020_000_DECLARE_TRELSIN_DB_DECLARE_1();

            /*" -384- PERFORM M_020_000_DECLARE_TRELSIN_DB_OPEN_1 */

            M_020_000_DECLARE_TRELSIN_DB_OPEN_1();

            /*" -387- MOVE 90 TO WCT-LINHA */
            _.Move(90, WORK.WCT_LINHA);

            /*" -387- MOVE ZEROS TO WCT-FOLHA. */
            _.Move(0, WORK.WCT_FOLHA);

        }

        [StopWatch]
        /*" M-020-000-DECLARE-TRELSIN-DB-DECLARE-1 */
        public void M_020_000_DECLARE_TRELSIN_DB_DECLARE_1()
        {
            /*" -382- EXEC SQL DECLARE V1RELATSINI CURSOR FOR SELECT PERI_INICIAL, PERI_FINAL FROM SEGUROS.V1RELATORIOS WHERE IDSISTEM = 'SI' AND CODRELAT = 'SI0107B1' AND DATA_SOLICITACAO = :TSISTEMA-DTMOVABE AND SITUACAO = ' ' END-EXEC. */
            V1RELATSINI = new SI0107B_V1RELATSINI(true);
            string GetQuery_V1RELATSINI()
            {
                var query = @$"SELECT 
							PERI_INICIAL
							, 
							PERI_FINAL 
							FROM SEGUROS.V1RELATORIOS 
							WHERE 
							IDSISTEM = 'SI' 
							AND CODRELAT = 'SI0107B1' 
							AND DATA_SOLICITACAO = '{TSISTEMA_DTMOVABE}' 
							AND SITUACAO = ' '";

                return query;
            }
            V1RELATSINI.GetQueryEvent += GetQuery_V1RELATSINI;

        }

        [StopWatch]
        /*" M-020-000-DECLARE-TRELSIN-DB-OPEN-1 */
        public void M_020_000_DECLARE_TRELSIN_DB_OPEN_1()
        {
            /*" -384- EXEC SQL OPEN V1RELATSINI END-EXEC. */

            V1RELATSINI.Open();

        }

        [StopWatch]
        /*" M-050-000-DECLARE-JOIN-DB-DECLARE-1 */
        public void M_050_000_DECLARE_JOIN_DB_DECLARE_1()
        {
            /*" -493- EXEC SQL DECLARE RENDIMP CURSOR FOR SELECT R.CODPDT, R.VALRDT, I.VLIMPOST FROM SEGUROS.V1RENDIMENTO R, SEGUROS.V1IMPOSTOS I WHERE R.IDECBT = 1 AND R.IDECBT = I.IDECBT AND R.DATRDT >= :TRELSIN-DTINIVIG AND R.DATRDT <= :TRELSIN-DTTERVIG AND R.CODSVI = I.CODSVI AND R.NUMREC = I.NUMREC ORDER BY R.CODPDT END-EXEC. */
            RENDIMP = new SI0107B_RENDIMP(true);
            string GetQuery_RENDIMP()
            {
                var query = @$"SELECT 
							R.CODPDT
							, 
							R.VALRDT
							, 
							I.VLIMPOST 
							FROM SEGUROS.V1RENDIMENTO R
							, 
							SEGUROS.V1IMPOSTOS I 
							WHERE 
							R.IDECBT = 1 
							AND R.IDECBT = I.IDECBT 
							AND R.DATRDT >= '{TRELSIN_DTINIVIG}' 
							AND R.DATRDT <= '{TRELSIN_DTTERVIG}' 
							AND R.CODSVI = I.CODSVI 
							AND R.NUMREC = I.NUMREC 
							ORDER BY R.CODPDT";

                return query;
            }
            RENDIMP.GetQueryEvent += GetQuery_RENDIMP;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_020_999_EXIT*/

        [StopWatch]
        /*" M-030-000-PRINCIPAL-SECTION */
        private void M_030_000_PRINCIPAL_SECTION()
        {
            /*" -400- MOVE '030' TO WNR-EXEC-SQL */
            _.Move("030", WABEND.WNR_EXEC_SQL);

            /*" -403- MOVE '030-PRINCIPAL' TO PARAGRAFO */
            _.Move("030-PRINCIPAL", WABEND.PARAGRAFO);

            /*" -404- MOVE TRELSIN-DTINIVIG TO WDTINIVIG-R */
            _.Move(TRELSIN_DTINIVIG, WDTINIVIG_R);

            /*" -405- MOVE DIA-I TO LC03-DIA-I */
            _.Move(WDTINIVIG.DIA_I, LC03.LC03_DIA_I);

            /*" -406- MOVE MES-I TO LC03-MES-I */
            _.Move(WDTINIVIG.MES_I, LC03.LC03_MES_I);

            /*" -408- MOVE ANO-I TO LC03-ANO-I */
            _.Move(WDTINIVIG.ANO_I, LC03.LC03_ANO_I);

            /*" -409- MOVE TRELSIN-DTTERVIG TO WDTTERVIG-R */
            _.Move(TRELSIN_DTTERVIG, WDTTERVIG_R);

            /*" -410- MOVE DIA-F TO LC03-DIA-F */
            _.Move(WDTTERVIG.DIA_F, LC03.LC03_DIA_F);

            /*" -411- MOVE MES-F TO LC03-MES-F */
            _.Move(WDTTERVIG.MES_F, LC03.LC03_MES_F);

            /*" -413- MOVE ANO-F TO LC03-ANO-F */
            _.Move(WDTTERVIG.ANO_F, LC03.LC03_ANO_F);

            /*" -415- PERFORM 050-000-DECLARE-JOIN */

            M_050_000_DECLARE_JOIN_SECTION();

            /*" -417- PERFORM 061-000-LEITURA-JOIN */

            M_061_000_LEITURA_JOIN_SECTION();

            /*" -420- MOVE RENDIMEN-CODPDT TO LD01-CODIGO WCODPDT-ANT */
            _.Move(RENDIMEN_CODPDT, LD01.LD01_CODIGO, WORK.WCODPDT_ANT);

            /*" -423- PERFORM 060-000-PRINCIPAL-JOIN UNTIL WFIM-JOIN EQUAL 'S' */

            while (!(WORK.WFIM_JOIN == "S"))
            {

                M_060_000_PRINCIPAL_JOIN_SECTION();
            }

            /*" -423- PERFORM 040-000-FETCH-TRELSIN. */

            M_040_000_FETCH_TRELSIN_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_030_999_EXIT*/

        [StopWatch]
        /*" M-040-000-FETCH-TRELSIN-SECTION */
        private void M_040_000_FETCH_TRELSIN_SECTION()
        {
            /*" -436- MOVE '040' TO WNR-EXEC-SQL */
            _.Move("040", WABEND.WNR_EXEC_SQL);

            /*" -439- MOVE '040-FETCH-TRELSIN' TO PARAGRAFO */
            _.Move("040-FETCH-TRELSIN", WABEND.PARAGRAFO);

            /*" -444- PERFORM M_040_000_FETCH_TRELSIN_DB_FETCH_1 */

            M_040_000_FETCH_TRELSIN_DB_FETCH_1();

            /*" -448- IF SQLCODE NOT EQUAL 0 AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 0 && DB.SQLCODE != 100)
            {

                /*" -450- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -451- ELSE */
            }
            else
            {


                /*" -452- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -453- MOVE 'S' TO WFIM-TRELSIN */
                    _.Move("S", WORK.WFIM_TRELSIN);

                    /*" -453- PERFORM M_040_000_FETCH_TRELSIN_DB_CLOSE_1 */

                    M_040_000_FETCH_TRELSIN_DB_CLOSE_1();

                    /*" -456- GO TO 040-999-EXIT */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_040_999_EXIT*/ //GOTO
                    return;

                    /*" -457- ELSE */
                }
                else
                {


                    /*" -457- ADD 1 TO WCT-LIDOS-TRELSIN. */
                    WORK.WCT_LIDOS_TRELSIN.Value = WORK.WCT_LIDOS_TRELSIN + 1;
                }

            }


        }

        [StopWatch]
        /*" M-040-000-FETCH-TRELSIN-DB-FETCH-1 */
        public void M_040_000_FETCH_TRELSIN_DB_FETCH_1()
        {
            /*" -444- EXEC SQL FETCH V1RELATSINI INTO :TRELSIN-DTINIVIG , :TRELSIN-DTTERVIG END-EXEC. */

            if (V1RELATSINI.Fetch())
            {
                _.Move(V1RELATSINI.TRELSIN_DTINIVIG, TRELSIN_DTINIVIG);
                _.Move(V1RELATSINI.TRELSIN_DTTERVIG, TRELSIN_DTTERVIG);
            }

        }

        [StopWatch]
        /*" M-040-000-FETCH-TRELSIN-DB-CLOSE-1 */
        public void M_040_000_FETCH_TRELSIN_DB_CLOSE_1()
        {
            /*" -453- EXEC SQL CLOSE V1RELATSINI END-EXEC */

            V1RELATSINI.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_040_999_EXIT*/

        [StopWatch]
        /*" M-050-000-DECLARE-JOIN-SECTION */
        private void M_050_000_DECLARE_JOIN_SECTION()
        {
            /*" -470- MOVE '050' TO WNR-EXEC-SQL */
            _.Move("050", WABEND.WNR_EXEC_SQL);

            /*" -473- MOVE '050-000-DECLARE-JOIN' TO PARAGRAFO */
            _.Move("050-000-DECLARE-JOIN", WABEND.PARAGRAFO);

            /*" -493- PERFORM M_050_000_DECLARE_JOIN_DB_DECLARE_1 */

            M_050_000_DECLARE_JOIN_DB_DECLARE_1();

            /*" -495- PERFORM M_050_000_DECLARE_JOIN_DB_OPEN_1 */

            M_050_000_DECLARE_JOIN_DB_OPEN_1();

        }

        [StopWatch]
        /*" M-050-000-DECLARE-JOIN-DB-OPEN-1 */
        public void M_050_000_DECLARE_JOIN_DB_OPEN_1()
        {
            /*" -495- EXEC SQL OPEN RENDIMP END-EXEC. */

            RENDIMP.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_050_999_EXIT*/

        [StopWatch]
        /*" M-060-000-PRINCIPAL-JOIN-SECTION */
        private void M_060_000_PRINCIPAL_JOIN_SECTION()
        {
            /*" -508- MOVE '060' TO WNR-EXEC-SQL */
            _.Move("060", WABEND.WNR_EXEC_SQL);

            /*" -511- MOVE '060-PRINCIPAL-JOIN' TO PARAGRAFO */
            _.Move("060-PRINCIPAL-JOIN", WABEND.PARAGRAFO);

            /*" -515- PERFORM 062-000-SUMARIZAR UNTIL RENDIMEN-CODPDT NOT EQUAL WCODPDT-ANT OR WFIM-JOIN EQUAL 'S' */

            while (!(RENDIMEN_CODPDT != WORK.WCODPDT_ANT || WORK.WFIM_JOIN == "S"))
            {

                M_062_000_SUMARIZAR_SECTION();
            }

            /*" -517- PERFORM 070-000-IMPRESSAO. */

            M_070_000_IMPRESSAO_SECTION();

            /*" -518- MOVE RENDIMEN-CODPDT TO LD01-CODIGO WCODPDT-ANT. */
            _.Move(RENDIMEN_CODPDT, LD01.LD01_CODIGO, WORK.WCODPDT_ANT);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_060_999_EXIT*/

        [StopWatch]
        /*" M-062-000-SUMARIZAR-SECTION */
        private void M_062_000_SUMARIZAR_SECTION()
        {
            /*" -531- MOVE '062' TO WNR-EXEC-SQL */
            _.Move("062", WABEND.WNR_EXEC_SQL);

            /*" -534- MOVE '062-000-SUMARIZAR' TO PARAGRAFO */
            _.Move("062-000-SUMARIZAR", WABEND.PARAGRAFO);

            /*" -535- IF RENDIMEN-VALRDT IS NUMERIC */

            if (RENDIMEN_VALRDT.IsNumeric())
            {

                /*" -537- ADD RENDIMEN-VALRDT TO WAC-VALRDT. */
                WORK.WAC_VALRDT.Value = WORK.WAC_VALRDT + RENDIMEN_VALRDT;
            }


            /*" -538- IF IMPOST-VLIMPOST IS NUMERIC */

            if (IMPOST_VLIMPOST.IsNumeric())
            {

                /*" -540- ADD IMPOST-VLIMPOST TO WAC-VLIMPOST. */
                WORK.WAC_VLIMPOST.Value = WORK.WAC_VLIMPOST + IMPOST_VLIMPOST;
            }


            /*" -540- PERFORM 061-000-LEITURA-JOIN. */

            M_061_000_LEITURA_JOIN_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_062_999_EXIT*/

        [StopWatch]
        /*" M-061-000-LEITURA-JOIN-SECTION */
        private void M_061_000_LEITURA_JOIN_SECTION()
        {
            /*" -552- MOVE '061' TO WNR-EXEC-SQL */
            _.Move("061", WABEND.WNR_EXEC_SQL);

            /*" -555- MOVE '061-000-LEITURA-JOIN' TO PARAGRAFO */
            _.Move("061-000-LEITURA-JOIN", WABEND.PARAGRAFO);

            /*" -559- PERFORM M_061_000_LEITURA_JOIN_DB_FETCH_1 */

            M_061_000_LEITURA_JOIN_DB_FETCH_1();

            /*" -563- IF SQLCODE NOT EQUAL 0 AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 0 && DB.SQLCODE != 100)
            {

                /*" -565- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -566- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -567- MOVE 'S' TO WFIM-JOIN */
                _.Move("S", WORK.WFIM_JOIN);

                /*" -567- PERFORM M_061_000_LEITURA_JOIN_DB_CLOSE_1 */

                M_061_000_LEITURA_JOIN_DB_CLOSE_1();

                /*" -570- GO TO 061-999-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_061_999_EXIT*/ //GOTO
                return;

                /*" -571- ELSE */
            }
            else
            {


                /*" -571- ADD 1 TO WCT-LIDOS-JOIN. */
                WORK.WCT_LIDOS_JOIN.Value = WORK.WCT_LIDOS_JOIN + 1;
            }


        }

        [StopWatch]
        /*" M-061-000-LEITURA-JOIN-DB-FETCH-1 */
        public void M_061_000_LEITURA_JOIN_DB_FETCH_1()
        {
            /*" -559- EXEC SQL FETCH RENDIMP INTO :RENDIMEN-CODPDT, :RENDIMEN-VALRDT, :IMPOST-VLIMPOST END-EXEC. */

            if (RENDIMP.Fetch())
            {
                _.Move(RENDIMP.RENDIMEN_CODPDT, RENDIMEN_CODPDT);
                _.Move(RENDIMP.RENDIMEN_VALRDT, RENDIMEN_VALRDT);
                _.Move(RENDIMP.IMPOST_VLIMPOST, IMPOST_VLIMPOST);
            }

        }

        [StopWatch]
        /*" M-061-000-LEITURA-JOIN-DB-CLOSE-1 */
        public void M_061_000_LEITURA_JOIN_DB_CLOSE_1()
        {
            /*" -567- EXEC SQL CLOSE RENDIMP END-EXEC */

            RENDIMP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_061_999_EXIT*/

        [StopWatch]
        /*" M-070-000-IMPRESSAO-SECTION */
        private void M_070_000_IMPRESSAO_SECTION()
        {
            /*" -584- MOVE '070' TO WNR-EXEC-SQL */
            _.Move("070", WABEND.WNR_EXEC_SQL);

            /*" -587- MOVE '070-000-IMPRESSAO' TO PARAGRAFO */
            _.Move("070-000-IMPRESSAO", WABEND.PARAGRAFO);

            /*" -589- MOVE WCODPDT-ANT TO HOST-CODPDT */
            _.Move(WORK.WCODPDT_ANT, HOST_CODPDT);

            /*" -590- IF WFIM-TRELSIN NOT EQUAL 'S' */

            if (WORK.WFIM_TRELSIN != "S")
            {

                /*" -592- PERFORM 080-000-LER-TCLIFOR. */

                M_080_000_LER_TCLIFOR_SECTION();
            }


            /*" -593- IF WCT-LINHA GREATER 60 */

            if (WORK.WCT_LINHA > 60)
            {

                /*" -594- PERFORM 090-000-CABECALHO */

                M_090_000_CABECALHO_SECTION();

                /*" -595- MOVE WAC-VALRDT TO LD01-SERVICOS-PAGOS */
                _.Move(WORK.WAC_VALRDT, LD01.LD01_SERVICOS_PAGOS);

                /*" -596- MOVE WAC-VLIMPOST TO LD01-IR */
                _.Move(WORK.WAC_VLIMPOST, LD01.LD01_IR);

                /*" -598- WRITE REGIMP FROM LD01 AFTER 2 */
                _.Move(LD01.GetMoveValues(), REGIMP);

                IMPRESSAO.Write(REGIMP.GetMoveValues().ToString());

                /*" -599- ADD 2 TO WCT-LINHA */
                WORK.WCT_LINHA.Value = WORK.WCT_LINHA + 2;

                /*" -600- ADD WAC-VALRDT TO WAC-VALRDT-TOTAL */
                WORK.WAC_VALRDT_TOTAL.Value = WORK.WAC_VALRDT_TOTAL + WORK.WAC_VALRDT;

                /*" -601- ADD WAC-VLIMPOST TO WAC-VLIMPOST-TOTAL */
                WORK.WAC_VLIMPOST_TOTAL.Value = WORK.WAC_VLIMPOST_TOTAL + WORK.WAC_VLIMPOST;

                /*" -602- MOVE ZEROS TO WAC-VALRDT */
                _.Move(0, WORK.WAC_VALRDT);

                /*" -604- MOVE ZEROS TO WAC-VLIMPOST */
                _.Move(0, WORK.WAC_VLIMPOST);

                /*" -605- ELSE */
            }
            else
            {


                /*" -606- MOVE WAC-VALRDT TO LD01-SERVICOS-PAGOS */
                _.Move(WORK.WAC_VALRDT, LD01.LD01_SERVICOS_PAGOS);

                /*" -607- MOVE WAC-VLIMPOST TO LD01-IR */
                _.Move(WORK.WAC_VLIMPOST, LD01.LD01_IR);

                /*" -609- WRITE REGIMP FROM LD01 AFTER 2 */
                _.Move(LD01.GetMoveValues(), REGIMP);

                IMPRESSAO.Write(REGIMP.GetMoveValues().ToString());

                /*" -610- ADD 2 TO WCT-LINHA */
                WORK.WCT_LINHA.Value = WORK.WCT_LINHA + 2;

                /*" -611- ADD WAC-VALRDT TO WAC-VALRDT-TOTAL */
                WORK.WAC_VALRDT_TOTAL.Value = WORK.WAC_VALRDT_TOTAL + WORK.WAC_VALRDT;

                /*" -612- ADD WAC-VLIMPOST TO WAC-VLIMPOST-TOTAL */
                WORK.WAC_VLIMPOST_TOTAL.Value = WORK.WAC_VLIMPOST_TOTAL + WORK.WAC_VLIMPOST;

                /*" -613- MOVE ZEROS TO WAC-VALRDT */
                _.Move(0, WORK.WAC_VALRDT);

                /*" -615- MOVE ZEROS TO WAC-VLIMPOST. */
                _.Move(0, WORK.WAC_VLIMPOST);
            }


            /*" -616- IF WCT-LINHA GREATER 25 */

            if (WORK.WCT_LINHA > 25)
            {

                /*" -617- MOVE WAC-VALRDT-TOTAL TO LT01-SERVICOS-PAGOS */
                _.Move(WORK.WAC_VALRDT_TOTAL, LT01.LT01_SERVICOS_PAGOS);

                /*" -618- MOVE WAC-VLIMPOST-TOTAL TO LT01-IR */
                _.Move(WORK.WAC_VLIMPOST_TOTAL, LT01.LT01_IR);

                /*" -620- WRITE REGIMP FROM LT01 AFTER 2 */
                _.Move(LT01.GetMoveValues(), REGIMP);

                IMPRESSAO.Write(REGIMP.GetMoveValues().ToString());

                /*" -621- MOVE ZEROS TO WAC-VALRDT-TOTAL */
                _.Move(0, WORK.WAC_VALRDT_TOTAL);

                /*" -622- MOVE ZEROS TO WAC-VLIMPOST-TOTAL */
                _.Move(0, WORK.WAC_VLIMPOST_TOTAL);

                /*" -622- MOVE 90 TO WCT-LINHA. */
                _.Move(90, WORK.WCT_LINHA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_070_999_EXIT*/

        [StopWatch]
        /*" M-080-000-LER-TCLIFOR-SECTION */
        private void M_080_000_LER_TCLIFOR_SECTION()
        {
            /*" -635- MOVE '080' TO WNR-EXEC-SQL */
            _.Move("080", WABEND.WNR_EXEC_SQL);

            /*" -638- MOVE '080-000-LER-TCLIFOR' TO PARAGRAFO */
            _.Move("080-000-LER-TCLIFOR", WABEND.PARAGRAFO);

            /*" -640- MOVE WCODPDT-ANT TO HOST-CODPDT */
            _.Move(WORK.WCODPDT_ANT, HOST_CODPDT);

            /*" -650- PERFORM M_080_000_LER_TCLIFOR_DB_SELECT_1 */

            M_080_000_LER_TCLIFOR_DB_SELECT_1();

            /*" -654- IF SQLCODE NOT EQUAL 0 AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 0 && DB.SQLCODE != 100)
            {

                /*" -656- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -657- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -659- DISPLAY 'REGISTRO NAO ENCONTRADO NA V1FORNECEDOR' RENDIMEN-CODPDT */
                _.Display($"REGISTRO NAO ENCONTRADO NA V1FORNECEDOR{RENDIMEN_CODPDT}");

                /*" -660- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -661- ELSE */
            }
            else
            {


                /*" -661- MOVE TCLIFOR-NOME TO LD01-NOME-PRODUTOR. */
                _.Move(TCLIFOR_NOME, LD01.LD01_NOME_PRODUTOR);
            }


        }

        [StopWatch]
        /*" M-080-000-LER-TCLIFOR-DB-SELECT-1 */
        public void M_080_000_LER_TCLIFOR_DB_SELECT_1()
        {
            /*" -650- EXEC SQL SELECT NOME INTO :TCLIFOR-NOME FROM SEGUROS.V1FORNECEDOR WHERE CLIFOR = :HOST-CODPDT END-EXEC. */

            var m_080_000_LER_TCLIFOR_DB_SELECT_1_Query1 = new M_080_000_LER_TCLIFOR_DB_SELECT_1_Query1()
            {
                HOST_CODPDT = HOST_CODPDT.ToString(),
            };

            var executed_1 = M_080_000_LER_TCLIFOR_DB_SELECT_1_Query1.Execute(m_080_000_LER_TCLIFOR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.TCLIFOR_NOME, TCLIFOR_NOME);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_080_999_EXIT*/

        [StopWatch]
        /*" M-090-000-CABECALHO-SECTION */
        private void M_090_000_CABECALHO_SECTION()
        {
            /*" -674- MOVE '090' TO WNR-EXEC-SQL */
            _.Move("090", WABEND.WNR_EXEC_SQL);

            /*" -677- MOVE '090-000-CABECALHO' TO PARAGRAFO */
            _.Move("090-000-CABECALHO", WABEND.PARAGRAFO);

            /*" -678- MOVE ZEROS TO WCT-LINHA */
            _.Move(0, WORK.WCT_LINHA);

            /*" -679- ADD 1 TO WCT-FOLHA */
            WORK.WCT_FOLHA.Value = WORK.WCT_FOLHA + 1;

            /*" -680- MOVE WCT-FOLHA TO LC01-FOLHA */
            _.Move(WORK.WCT_FOLHA, WABEND.LC01.LC01_FOLHA);

            /*" -682- WRITE REGIMP FROM LC01 AFTER NEW-PAGE. */
            _.Move(WABEND.LC01.GetMoveValues(), REGIMP);

            IMPRESSAO.Write(REGIMP.GetMoveValues().ToString());

            /*" -683- WRITE REGIMP FROM LC02 */
            _.Move(WABEND.LC02.GetMoveValues(), REGIMP);

            IMPRESSAO.Write(REGIMP.GetMoveValues().ToString());

            /*" -685- WRITE REGIMP FROM LC06 AFTER 2 */
            _.Move(LC06.GetMoveValues(), REGIMP);

            IMPRESSAO.Write(REGIMP.GetMoveValues().ToString());

            /*" -687- WRITE REGIMP FROM LC03 AFTER 2 */
            _.Move(LC03.GetMoveValues(), REGIMP);

            IMPRESSAO.Write(REGIMP.GetMoveValues().ToString());

            /*" -689- WRITE REGIMP FROM LC04 AFTER 1 */
            _.Move(LC04.GetMoveValues(), REGIMP);

            IMPRESSAO.Write(REGIMP.GetMoveValues().ToString());

            /*" -691- WRITE REGIMP FROM LC05 AFTER 1 */
            _.Move(LC05.GetMoveValues(), REGIMP);

            IMPRESSAO.Write(REGIMP.GetMoveValues().ToString());

            /*" -692- WRITE REGIMP FROM LC04 AFTER 1. */
            _.Move(LC04.GetMoveValues(), REGIMP);

            IMPRESSAO.Write(REGIMP.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_090_999_EXIT*/

        [StopWatch]
        /*" M-100-000-ATUALIZA-TRELSIN-SECTION */
        private void M_100_000_ATUALIZA_TRELSIN_SECTION()
        {
            /*" -705- MOVE '100' TO WNR-EXEC-SQL */
            _.Move("100", WABEND.WNR_EXEC_SQL);

            /*" -708- MOVE '100-000-ATUALIZA-TRELSIN' TO PARAGRAFO */
            _.Move("100-000-ATUALIZA-TRELSIN", WABEND.PARAGRAFO);

            /*" -716- PERFORM M_100_000_ATUALIZA_TRELSIN_DB_DELETE_1 */

            M_100_000_ATUALIZA_TRELSIN_DB_DELETE_1();

        }

        [StopWatch]
        /*" M-100-000-ATUALIZA-TRELSIN-DB-DELETE-1 */
        public void M_100_000_ATUALIZA_TRELSIN_DB_DELETE_1()
        {
            /*" -716- EXEC SQL DELETE FROM SEGUROS.V0RELATORIOS WHERE IDSISTEM = 'SI' AND CODRELAT = 'SI0107B' AND SITUACAO = ' ' AND DATA_SOLICITACAO = :TSISTEMA-DTMOVABE END-EXEC. */

            var m_100_000_ATUALIZA_TRELSIN_DB_DELETE_1_Delete1 = new M_100_000_ATUALIZA_TRELSIN_DB_DELETE_1_Delete1()
            {
                TSISTEMA_DTMOVABE = TSISTEMA_DTMOVABE.ToString(),
            };

            M_100_000_ATUALIZA_TRELSIN_DB_DELETE_1_Delete1.Execute(m_100_000_ATUALIZA_TRELSIN_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_999_EXIT*/

        [StopWatch]
        /*" M-110-000-FINALIZA-SECTION */
        private void M_110_000_FINALIZA_SECTION()
        {
            /*" -729- MOVE '110' TO WNR-EXEC-SQL */
            _.Move("110", WABEND.WNR_EXEC_SQL);

            /*" -732- MOVE '110-000-FINALIZA' TO PARAGRAFO */
            _.Move("110-000-FINALIZA", WABEND.PARAGRAFO);

            /*" -732- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -736- CLOSE IMPRESSAO. */
            IMPRESSAO.Close();

            /*" -738- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -740- DISPLAY 'SI0107B ***** FIM NORMAL *****' */
            _.Display($"SI0107B ***** FIM NORMAL *****");

            /*" -742- DISPLAY 'TOTAL DE LIDOS TRELSIN ' WCT-LIDOS-TRELSIN */
            _.Display($"TOTAL DE LIDOS TRELSIN {WORK.WCT_LIDOS_TRELSIN}");

            /*" -744- DISPLAY 'TOTAL DE LIDOS JOIN    ' WCT-LIDOS-JOIN. */
            _.Display($"TOTAL DE LIDOS JOIN    {WORK.WCT_LIDOS_JOIN}");

            /*" -744- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_110_999_EXIT*/

        [StopWatch]
        /*" M-999-999-ROT-ERRO-SECTION */
        private void M_999_999_ROT_ERRO_SECTION()
        {
            /*" -757- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -758- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.WSQLCODE);

                /*" -760- DISPLAY WABEND */
                _.Display(WABEND);

                /*" -762- ELSE */
            }
            else
            {


                /*" -762- EXEC SQL COMMIT WORK END-EXEC. */

                DatabaseConnection.Instance.CommitTransaction();
            }


            /*" -764- GOBACK. */

            throw new GoBack();

        }
    }
}