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
using Sias.VidaAzul.DB2.VA1417B;

namespace Code
{
    public class VA1417B
    {
        public bool IsCall { get; set; }

        public VA1417B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                    OBJETIVO DO PROGRAMA                        *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   EMITE RELATORIO DA FATURA DA ESTRUTURA DE COBRANCA MULTI-    *      */
        /*"      * PREMIADO COM FATURAMENTO NO 31 DE CADA MES.                    *      */
        /*"      *    - PRODUTOS CONTEMPLADOS:                                    *      */
        /*"      *        1) APOLICES FENAM                                       *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO 03 - CAD 10.003                                       *      */
        /*"      *                                                                *      */
        /*"      *              - CONVERSAO DO DB2 PARA A VERSAO 10               *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/09/2013 -  CLAUDIO FREITAS                             *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.03    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO   *    DATA    *    AUTOR     *       HISTORICO       *      */
        /*"      *            *            *              *                       *      */
        /*"      *     01     *  12/01/98  *   MESSIAS    *                       *      */
        /*"      ******************************************************************      */
        /*"      * CONVERSAO ANO 2000              CONSEDA4              05/1998  *      */
        /*"      ******************************************************************      */
        /*"      *     02     *  23/11/98  *   MESSIAS    *                       *      */
        /*"      *                                                                *      */
        /*"      *    INIBIDO O UPDATE NA TABELA V0RELATORIOS. ESTE UPDATE SERA   *      */
        /*"      * FEITO PELO PROGRAMA VA0426B.                                   *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      * MELHORIA DE PERFORMANCE         PRODEXTER            AGO/2000  *      */
        /*"      * (PROCURAR POR AL0800)                                          *      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        public FileBasis _RVA1417B { get; set; } = new FileBasis(new PIC("X", "132", "X(132)"));

        public FileBasis RVA1417B
        {
            get
            {
                _.Move(REG_IMPRESSAO, _RVA1417B); VarBasis.RedefinePassValue(REG_IMPRESSAO, _RVA1417B, REG_IMPRESSAO); return _RVA1417B;
            }
        }
        /*"01            REG-IMPRESSAO       PIC X(132).*/
        public StringBasis REG_IMPRESSAO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77            V1SIST-DTMOVABE     PIC  X(10).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V0RELA-DTREFER      PIC  X(10).*/
        public StringBasis V0RELA_DTREFER { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V0PROD-NOMPRODU     PIC  X(30).*/
        public StringBasis V0PROD_NOMPRODU { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"77            V0FONT-NOMEFTE      PIC  X(40).*/
        public StringBasis V0FONT_NOMEFTE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77            V1APOL-NOMEAPOL     PIC  X(40).*/
        public StringBasis V1APOL_NOMEAPOL { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77            V0HCON-APOLICE      PIC S9(13) COMP-3.*/
        public IntBasis V0HCON_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77            V0HCON-CODSUBES     PIC S9(04) COMP.*/
        public IntBasis V0HCON_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0HCON-FONTE        PIC S9(04) COMP.*/
        public IntBasis V0HCON_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0HCON-NRENDOS      PIC S9(09) COMP.*/
        public IntBasis V0HCON_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77            V0HCON-NRPARCEL     PIC S9(04) COMP.*/
        public IntBasis V0HCON_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0HCON-CODOPER      PIC S9(04) COMP.*/
        public IntBasis V0HCON_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0HCON-PRMTOTAL     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0HCON_PRMTOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77            V0HCON-QTD          PIC S9(09)    COMP.*/
        public IntBasis V0HCON_QTD { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  WORK-AREA.*/
        public VA1417B_WORK_AREA WORK_AREA { get; set; } = new VA1417B_WORK_AREA();
        public class VA1417B_WORK_AREA : VarBasis
        {
            /*"    05        DATA-SQL.*/
            public VA1417B_DATA_SQL DATA_SQL { get; set; } = new VA1417B_DATA_SQL();
            public class VA1417B_DATA_SQL : VarBasis
            {
                /*"      10      ANO-SQL             PIC  9(004).*/
                public IntBasis ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10      MES-SQL             PIC  9(002).*/
                public IntBasis MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10      DIA-SQL             PIC  9(002).*/
                public IntBasis DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        WHORA-CURR.*/
            }
            public VA1417B_WHORA_CURR WHORA_CURR { get; set; } = new VA1417B_WHORA_CURR();
            public class VA1417B_WHORA_CURR : VarBasis
            {
                /*"      10      WHORA-HH-CURR       PIC  9(002).*/
                public IntBasis WHORA_HH_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      WHORA-MM-CURR       PIC  9(002).*/
                public IntBasis WHORA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      WHORA-SS-CURR       PIC  9(002).*/
                public IntBasis WHORA_SS_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      WHORA-CC-CURR       PIC  9(002).*/
                public IntBasis WHORA_CC_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        DATA-MAQ.*/
            }
            public VA1417B_DATA_MAQ DATA_MAQ { get; set; } = new VA1417B_DATA_MAQ();
            public class VA1417B_DATA_MAQ : VarBasis
            {
                /*"      10      MES                 PIC  9(002).*/
                public IntBasis MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      DIA                 PIC  9(002).*/
                public IntBasis DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      ANO                 PIC  9(004).*/
                public IntBasis ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05        WIND                PIC  9(002).*/
            }
            public IntBasis WIND { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05        WS-TIME             PIC  X(008).*/
            public StringBasis WS_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05        WS-TIME-R           REDEFINES WS-TIME.*/
            private _REDEF_VA1417B_WS_TIME_R _ws_time_r { get; set; }
            public _REDEF_VA1417B_WS_TIME_R WS_TIME_R
            {
                get { _ws_time_r = new _REDEF_VA1417B_WS_TIME_R(); _.Move(WS_TIME, _ws_time_r); VarBasis.RedefinePassValue(WS_TIME, _ws_time_r, WS_TIME); _ws_time_r.ValueChanged += () => { _.Move(_ws_time_r, WS_TIME); }; return _ws_time_r; }
                set { VarBasis.RedefinePassValue(value, _ws_time_r, WS_TIME); }
            }  //Redefines
            public class _REDEF_VA1417B_WS_TIME_R : VarBasis
            {
                /*"      10      WS-HOR              PIC  9(002).*/
                public IntBasis WS_HOR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      WS-MIN              PIC  9(002).*/
                public IntBasis WS_MIN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      WS-SEG              PIC  9(002).*/
                public IntBasis WS_SEG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  9(002).*/
                public IntBasis FILLER_4 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        WS-DATA.*/

                public _REDEF_VA1417B_WS_TIME_R()
                {
                    WS_HOR.ValueChanged += OnValueChanged;
                    WS_MIN.ValueChanged += OnValueChanged;
                    WS_SEG.ValueChanged += OnValueChanged;
                    FILLER_4.ValueChanged += OnValueChanged;
                }

            }
            public VA1417B_WS_DATA WS_DATA { get; set; } = new VA1417B_WS_DATA();
            public class VA1417B_WS_DATA : VarBasis
            {
                /*"      10      WS-DIA              PIC  9(002).*/
                public IntBasis WS_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      WS-BAR1             PIC  X(001).*/
                public StringBasis WS_BAR1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-MES              PIC  9(002).*/
                public IntBasis WS_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      WS-BAR2             PIC  X(001).*/
                public StringBasis WS_BAR2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-ANO              PIC  9(004).*/
                public IntBasis WS_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05        WS-DTREFER.*/
            }
            public VA1417B_WS_DTREFER WS_DTREFER { get; set; } = new VA1417B_WS_DTREFER();
            public class VA1417B_WS_DTREFER : VarBasis
            {
                /*"      10      WS-AAREFER          PIC  9(004).*/
                public IntBasis WS_AAREFER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-MMREFER          PIC  9(002).*/
                public IntBasis WS_MMREFER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-DDREFER          PIC  9(002).*/
                public IntBasis WS_DDREFER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        WFIM-HCONTABILVA    PIC   X(01)  VALUE  ' '.*/
            }
            public StringBasis WFIM_HCONTABILVA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"    05        WFIM-SISTEMA        PIC   X(01)  VALUE  ' '.*/
            public StringBasis WFIM_SISTEMA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"    05        WFIM-RELATORIO      PIC   X(01)  VALUE  ' '.*/
            public StringBasis WFIM_RELATORIO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"    05        DATA-AUX.*/
            public VA1417B_DATA_AUX DATA_AUX { get; set; } = new VA1417B_DATA_AUX();
            public class VA1417B_DATA_AUX : VarBasis
            {
                /*"      10      DIA-AUX             PIC  9(002).*/
                public IntBasis DIA_AUX { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10      MES-AUX             PIC  9(002).*/
                public IntBasis MES_AUX { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10      ANO-AUX             PIC  9(004).*/
                public IntBasis ANO_AUX { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05        AC-LIDOS            PIC  9(006) VALUE ZEROS.*/
            }
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-LINHA            PIC  9(006) VALUE 90.*/
            public IntBasis AC_LINHA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"), 90);
            /*"    05        AC-PAGINA           PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_PAGINA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-IMPRESSOS        PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_IMPRESSOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        WABEND.*/
            public VA1417B_WABEND WABEND { get; set; } = new VA1417B_WABEND();
            public class VA1417B_WABEND : VarBasis
            {
                /*"      10      FILLER              PIC  X(010) VALUE             ' VA1417B'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VA1417B");
                /*"      10      FILLER              PIC  X(026) VALUE             ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"      10      WNR-EXEC-SQL        PIC  X(004) VALUE '0000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                /*"      10      FILLER              PIC  X(013) VALUE             ' *** SQLCODE '.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"      10      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05        TRACO.*/
            }
            public VA1417B_TRACO TRACO { get; set; } = new VA1417B_TRACO();
            public class VA1417B_TRACO : VarBasis
            {
                /*"      10      FILLER              PIC  X(132) VALUE ALL '-'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
                /*"    05        BRANCO.*/
            }
            public VA1417B_BRANCO BRANCO { get; set; } = new VA1417B_BRANCO();
            public class VA1417B_BRANCO : VarBasis
            {
                /*"      10      FILLER              PIC  X(132) VALUE SPACES.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
                /*"    05        LC01.*/
            }
            public VA1417B_LC01 LC01 { get; set; } = new VA1417B_LC01();
            public class VA1417B_LC01 : VarBasis
            {
                /*"      10      FILLER              PIC  X(008) VALUE 'VA1417B'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VA1417B");
                /*"      10      FILLER              PIC  X(037) VALUE SPACES.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"");
                /*"      10      FILLER              PIC  X(040) VALUE             'SASSE - CIA NACIONAL DE SEGUROS GERAIS'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"SASSE - CIA NACIONAL DE SEGUROS GERAIS");
                /*"      10      FILLER              PIC  X(032) VALUE SPACES.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "32", "X(032)"), @"");
                /*"      10      FILLER              PIC  X(011) VALUE 'PAGINA'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"PAGINA");
                /*"      10      LC01-PAGINA         PIC  Z999.*/
                public IntBasis LC01_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "Z999."));
                /*"    05        LC02.*/
            }
            public VA1417B_LC02 LC02 { get; set; } = new VA1417B_LC02();
            public class VA1417B_LC02 : VarBasis
            {
                /*"      10      FILLER              PIC  X(117) VALUE SPACES.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "117", "X(117)"), @"");
                /*"      10      FILLER              PIC  X(005) VALUE 'DATA '.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"DATA ");
                /*"      10      LC02-DIA            PIC  9(02).*/
                public IntBasis LC02_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"      10      FILLER              PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10      LC02-MES            PIC  9(02).*/
                public IntBasis LC02_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"      10      FILLER              PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10      LC02-ANO            PIC  9(04).*/
                public IntBasis LC02_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"    05        LC03.*/
            }
            public VA1417B_LC03 LC03 { get; set; } = new VA1417B_LC03();
            public class VA1417B_LC03 : VarBasis
            {
                /*"      10      FILLER              PIC  X(037) VALUE SPACES.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"");
                /*"      10      FILLER              PIC  X(042) VALUE             'RELATORIO ANEXO AS FATURAS DAS NOVAS APOLI'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "42", "X(042)"), @"RELATORIO ANEXO AS FATURAS DAS NOVAS APOLI");
                /*"      10      FILLER              PIC  X(031) VALUE             'CES DE VIDA       '.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "31", "X(031)"), @"CES DE VIDA       ");
                /*"      10      FILLER              PIC  X(007) VALUE SPACES.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"      10      FILLER              PIC  X(007) VALUE 'HORA '.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"HORA ");
                /*"      10      LC03-HOR            PIC  9(02).*/
                public IntBasis LC03_HOR { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"      10      FILLER              PIC  X(001) VALUE ':'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"      10      LC03-MIN            PIC  9(02).*/
                public IntBasis LC03_MIN { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"      10      FILLER              PIC  X(001) VALUE ':'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"      10      LC03-SEG            PIC  9(02).*/
                public IntBasis LC03_SEG { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    05        LC03-1.*/
            }
            public VA1417B_LC03_1 LC03_1 { get; set; } = new VA1417B_LC03_1();
            public class VA1417B_LC03_1 : VarBasis
            {
                /*"      10      FILLER              PIC  X(046) VALUE SPACES.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "46", "X(046)"), @"");
                /*"      10      FILLER              PIC  X(013) VALUE             'REFERENCIA :'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"REFERENCIA :");
                /*"      10      LC03-MES-REFER      PIC  X(09).*/
                public StringBasis LC03_MES_REFER { get; set; } = new StringBasis(new PIC("X", "9", "X(09)."), @"");
                /*"      10      FILLER              PIC  X(004) VALUE ' DE '.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @" DE ");
                /*"      10      LC03-ANO-REFER      PIC  9(04).*/
                public IntBasis LC03_ANO_REFER { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"    05        LC03-2.*/
            }
            public VA1417B_LC03_2 LC03_2 { get; set; } = new VA1417B_LC03_2();
            public class VA1417B_LC03_2 : VarBasis
            {
                /*"      10      FILLER              PIC X(10) VALUE 'APOLICE : '.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"APOLICE : ");
                /*"      10      LC03-APOLICE        PIC 9(13) VALUE  ZEROS.*/
                public IntBasis LC03_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
                /*"      10      FILLER              PIC X(03) VALUE ' - '.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" - ");
                /*"      10      LC03-NOMEAPOL       PIC X(40) VALUE  SPACES.*/
                public StringBasis LC03_NOMEAPOL { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"    05        LC04.*/
            }
            public VA1417B_LC04 LC04 { get; set; } = new VA1417B_LC04();
            public class VA1417B_LC04 : VarBasis
            {
                /*"      10      FILLER              PIC X(10) VALUE 'SUBGRUPO: '.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"SUBGRUPO: ");
                /*"      10      FILLER              PIC X(09) VALUE  SPACES.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"");
                /*"      10      LC04-CODSUBES       PIC 9(04) VALUE  ZEROS.*/
                public IntBasis LC04_CODSUBES { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"      10      FILLER              PIC X(03) VALUE ' - '.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" - ");
                /*"      10      LC04-NOMPRODU       PIC X(30) VALUE  SPACES.*/
                public StringBasis LC04_NOMPRODU { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
                /*"    05        LC05.*/
            }
            public VA1417B_LC05 LC05 { get; set; } = new VA1417B_LC05();
            public class VA1417B_LC05 : VarBasis
            {
                /*"      10      FILLER              PIC X(38) VALUE             'FILIAL                                '.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "38", "X(38)"), @"FILIAL                                ");
                /*"      10      FILLER              PIC X(07) VALUE             'ENDOSSO'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"ENDOSSO");
                /*"    05        LC06.*/
            }
            public VA1417B_LC06 LC06 { get; set; } = new VA1417B_LC06();
            public class VA1417B_LC06 : VarBasis
            {
                /*"      10      FILLER              PIC X(26) VALUE SPACES.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "26", "X(26)"), @"");
                /*"      10      FILLER              PIC X(38) VALUE             'VENDAS             DEMAIS             '.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "38", "X(38)"), @"VENDAS             DEMAIS             ");
                /*"      10      FILLER              PIC X(38) VALUE             'CANCELADO          RESTITUIDO         '.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "38", "X(38)"), @"CANCELADO          RESTITUIDO         ");
                /*"      10      FILLER              PIC X(30) VALUE             'FATURADO           PENDENTE   '.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"FATURADO           PENDENTE   ");
                /*"    05        LC07.*/
            }
            public VA1417B_LC07 LC07 { get; set; } = new VA1417B_LC07();
            public class VA1417B_LC07 : VarBasis
            {
                /*"      10      FILLER              PIC X(22) VALUE SPACES.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "22", "X(22)"), @"");
                /*"      10      FILLER              PIC X(38) VALUE             'QTD         VLR    QTD         VLR    '.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "38", "X(38)"), @"QTD         VLR    QTD         VLR    ");
                /*"      10      FILLER              PIC X(38) VALUE             'QTD         VLR    QTD         VLR    '.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "38", "X(38)"), @"QTD         VLR    QTD         VLR    ");
                /*"      10      FILLER              PIC X(34) VALUE             'QTD         VLR    QTD         VLR'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"QTD         VLR    QTD         VLR");
                /*"    05        LD01.*/
            }
            public VA1417B_LD01 LD01 { get; set; } = new VA1417B_LD01();
            public class VA1417B_LD01 : VarBasis
            {
                /*"      10      FILLER              PIC X(02)   VALUE SPACES.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
                /*"      10      LD01-FILIAL         PIC 9(02)   VALUE ZEROS.*/
                public IntBasis LD01_FILIAL { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"      10      FILLER              PIC X(03)   VALUE SPACES.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
                /*"      10      LD01-NOMEFTE        PIC X(30)   VALUE SPACES.*/
                public StringBasis LD01_NOMEFTE { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
                /*"      10      FILLER              PIC X(01)   VALUE SPACES.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"      10      LD01-NRENDOS        PIC ZZZZZZZ.*/
                public StringBasis LD01_NRENDOS { get; set; } = new StringBasis(new PIC("X", "0", "ZZZZZZZ."), @"");
                /*"    05        LD02.*/
            }
            public VA1417B_LD02 LD02 { get; set; } = new VA1417B_LD02();
            public class VA1417B_LD02 : VarBasis
            {
                /*"      10      LD02-TITULO         PIC X(19)   VALUE SPACES.*/
                public StringBasis LD02_TITULO { get; set; } = new StringBasis(new PIC("X", "19", "X(19)"), @"");
                /*"      10      LD02-QTD-VENDA      PIC ZZZZZ9.*/
                public IntBasis LD02_QTD_VENDA { get; set; } = new IntBasis(new PIC("9", "6", "ZZZZZ9."));
                /*"      10      FILLER              PIC X(01)   VALUE SPACES.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"      10      LD02-VLR-VENDA      PIC ZZZZ.ZZ9,99.*/
                public DoubleBasis LD02_VLR_VENDA { get; set; } = new DoubleBasis(new PIC("9", "7", "ZZZZ.ZZ9V99."), 2);
                /*"      10      FILLER              PIC X(01)   VALUE SPACES.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"      10      LD02-QTD-DEMAIS     PIC ZZZZZ9.*/
                public IntBasis LD02_QTD_DEMAIS { get; set; } = new IntBasis(new PIC("9", "6", "ZZZZZ9."));
                /*"      10      FILLER              PIC X(01)   VALUE SPACES.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"      10      LD02-VLR-DEMAIS     PIC ZZZZ.ZZ9,99.*/
                public DoubleBasis LD02_VLR_DEMAIS { get; set; } = new DoubleBasis(new PIC("9", "7", "ZZZZ.ZZ9V99."), 2);
                /*"      10      FILLER              PIC X(01)   VALUE SPACES.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"      10      LD02-QTD-CANC       PIC ZZZZZ9.*/
                public IntBasis LD02_QTD_CANC { get; set; } = new IntBasis(new PIC("9", "6", "ZZZZZ9."));
                /*"      10      FILLER              PIC X(01)   VALUE SPACES.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"      10      LD02-VLR-CANC       PIC ZZZZ.ZZ9,99.*/
                public DoubleBasis LD02_VLR_CANC { get; set; } = new DoubleBasis(new PIC("9", "7", "ZZZZ.ZZ9V99."), 2);
                /*"      10      FILLER              PIC X(01)   VALUE SPACES.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"      10      LD02-QTD-REST       PIC ZZZZZ9.*/
                public IntBasis LD02_QTD_REST { get; set; } = new IntBasis(new PIC("9", "6", "ZZZZZ9."));
                /*"      10      FILLER              PIC X(01)   VALUE SPACES.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"      10      LD02-VLR-REST       PIC ZZZZ.ZZ9,99.*/
                public DoubleBasis LD02_VLR_REST { get; set; } = new DoubleBasis(new PIC("9", "7", "ZZZZ.ZZ9V99."), 2);
                /*"      10      FILLER              PIC X(01)   VALUE SPACES.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"      10      LD02-QTD-FATU       PIC ZZZZZ9.*/
                public IntBasis LD02_QTD_FATU { get; set; } = new IntBasis(new PIC("9", "6", "ZZZZZ9."));
                /*"      10      FILLER              PIC X(01)   VALUE SPACES.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"      10      LD02-VLR-FATU       PIC ZZZZ.ZZ9,99.*/
                public DoubleBasis LD02_VLR_FATU { get; set; } = new DoubleBasis(new PIC("9", "7", "ZZZZ.ZZ9V99."), 2);
                /*"      10      FILLER              PIC X(01)   VALUE SPACES.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"      10      LD02-QTD-PEND       PIC ZZZZZ9.*/
                public IntBasis LD02_QTD_PEND { get; set; } = new IntBasis(new PIC("9", "6", "ZZZZZ9."));
                /*"      10      FILLER              PIC X(01)   VALUE SPACES.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"      10      LD02-VLR-PEND       PIC ZZZZ.ZZ9,99.*/
                public DoubleBasis LD02_VLR_PEND { get; set; } = new DoubleBasis(new PIC("9", "7", "ZZZZ.ZZ9V99."), 2);
                /*"01            TABELA-MESES.*/
            }
        }
        public VA1417B_TABELA_MESES TABELA_MESES { get; set; } = new VA1417B_TABELA_MESES();
        public class VA1417B_TABELA_MESES : VarBasis
        {
            /*"        15    FILLER           PIC  X(009) VALUE '  JANEIRO'.*/
            public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"  JANEIRO");
            /*"        15    FILLER           PIC  X(009) VALUE 'FEVEREIRO'.*/
            public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"FEVEREIRO");
            /*"        15    FILLER           PIC  X(009) VALUE '    MARCO'.*/
            public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    MARCO");
            /*"        15    FILLER           PIC  X(009) VALUE '    ABRIL'.*/
            public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    ABRIL");
            /*"        15    FILLER           PIC  X(009) VALUE '     MAIO'.*/
            public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"     MAIO");
            /*"        15    FILLER           PIC  X(009) VALUE '    JUNHO'.*/
            public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    JUNHO");
            /*"        15    FILLER           PIC  X(009) VALUE '    JULHO'.*/
            public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    JULHO");
            /*"        15    FILLER           PIC  X(009) VALUE '   AGOSTO'.*/
            public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"   AGOSTO");
            /*"        15    FILLER           PIC  X(009) VALUE ' SETEMBRO'.*/
            public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" SETEMBRO");
            /*"        15    FILLER           PIC  X(009) VALUE '  OUTUBRO'.*/
            public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"  OUTUBRO");
            /*"        15    FILLER           PIC  X(009) VALUE ' NOVEMBRO'.*/
            public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" NOVEMBRO");
            /*"        15    FILLER           PIC  X(009) VALUE ' DEZEMBRO'.*/
            public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" DEZEMBRO");
            /*"01            TABELA-MESES-R   REDEFINES              TABELA-MESES.*/
        }
        private _REDEF_VA1417B_TABELA_MESES_R _tabela_meses_r { get; set; }
        public _REDEF_VA1417B_TABELA_MESES_R TABELA_MESES_R
        {
            get { _tabela_meses_r = new _REDEF_VA1417B_TABELA_MESES_R(); _.Move(TABELA_MESES, _tabela_meses_r); VarBasis.RedefinePassValue(TABELA_MESES, _tabela_meses_r, TABELA_MESES); _tabela_meses_r.ValueChanged += () => { _.Move(_tabela_meses_r, TABELA_MESES); }; return _tabela_meses_r; }
            set { VarBasis.RedefinePassValue(value, _tabela_meses_r, TABELA_MESES); }
        }  //Redefines
        public class _REDEF_VA1417B_TABELA_MESES_R : VarBasis
        {
            /*"    05          TAB-MES       OCCURS 12 TIMES                                   PIC  X(009).*/
            public ListBasis<StringBasis, string> TAB_MES { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "9", "X(009)."), 12);
            /*"01            FONTE-ANT            PIC 9(004)  VALUE ZEROS.*/

            public _REDEF_VA1417B_TABELA_MESES_R()
            {
                TAB_MES.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis FONTE_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"01            FONTE-ATU            PIC 9(004)  VALUE ZEROS.*/
        public IntBasis FONTE_ATU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"01            CHAVE-ATU.*/
        public VA1417B_CHAVE_ATU CHAVE_ATU { get; set; } = new VA1417B_CHAVE_ATU();
        public class VA1417B_CHAVE_ATU : VarBasis
        {
            /*"    05          APOLICE-ATU          PIC 9(013)  VALUE ZEROS.*/
            public IntBasis APOLICE_ATU { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"    05          CODSUBES-ATU         PIC 9(004)  VALUE ZEROS.*/
            public IntBasis CODSUBES_ATU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"01            CHAVE-ANT.*/
        }
        public VA1417B_CHAVE_ANT CHAVE_ANT { get; set; } = new VA1417B_CHAVE_ANT();
        public class VA1417B_CHAVE_ANT : VarBasis
        {
            /*"    05          APOLICE-ANT          PIC 9(013)  VALUE ZEROS.*/
            public IntBasis APOLICE_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"    05          CODSUBES-ANT         PIC 9(004)  VALUE ZEROS.*/
            public IntBasis CODSUBES_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"01            TOTAIS-FILIAIS.*/
        }
        public VA1417B_TOTAIS_FILIAIS TOTAIS_FILIAIS { get; set; } = new VA1417B_TOTAIS_FILIAIS();
        public class VA1417B_TOTAIS_FILIAIS : VarBasis
        {
            /*"    05          TOTF-QTD-VENDA       PIC  9(006).*/
            public IntBasis TOTF_QTD_VENDA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05          TOTF-VLR-VENDA       PIC  9(013)V99.*/
            public DoubleBasis TOTF_VLR_VENDA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    05          TOTF-QTD-DEMAIS      PIC  9(006).*/
            public IntBasis TOTF_QTD_DEMAIS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05          TOTF-VLR-DEMAIS      PIC  9(013)V99.*/
            public DoubleBasis TOTF_VLR_DEMAIS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    05          TOTF-QTD-CANC        PIC  9(006).*/
            public IntBasis TOTF_QTD_CANC { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05          TOTF-VLR-CANC        PIC  9(013)V99.*/
            public DoubleBasis TOTF_VLR_CANC { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    05          TOTF-QTD-REST        PIC  9(006).*/
            public IntBasis TOTF_QTD_REST { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05          TOTF-VLR-REST        PIC  9(013)V99.*/
            public DoubleBasis TOTF_VLR_REST { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    05          TOTF-QTD-FATU        PIC  9(006).*/
            public IntBasis TOTF_QTD_FATU { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05          TOTF-VLR-FATU        PIC  9(013)V99.*/
            public DoubleBasis TOTF_VLR_FATU { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    05          TOTF-QTD-PEND        PIC  9(006).*/
            public IntBasis TOTF_QTD_PEND { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05          TOTF-VLR-PEND        PIC  9(013)V99.*/
            public DoubleBasis TOTF_VLR_PEND { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"01            TOTAIS-PRODUTOS.*/
        }
        public VA1417B_TOTAIS_PRODUTOS TOTAIS_PRODUTOS { get; set; } = new VA1417B_TOTAIS_PRODUTOS();
        public class VA1417B_TOTAIS_PRODUTOS : VarBasis
        {
            /*"    05          TOTP-QTD-VENDA       PIC  9(006).*/
            public IntBasis TOTP_QTD_VENDA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05          TOTP-VLR-VENDA       PIC  9(013)V99.*/
            public DoubleBasis TOTP_VLR_VENDA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    05          TOTP-QTD-DEMAIS      PIC  9(006).*/
            public IntBasis TOTP_QTD_DEMAIS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05          TOTP-VLR-DEMAIS      PIC  9(013)V99.*/
            public DoubleBasis TOTP_VLR_DEMAIS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    05          TOTP-QTD-CANC        PIC  9(006).*/
            public IntBasis TOTP_QTD_CANC { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05          TOTP-VLR-CANC        PIC  9(013)V99.*/
            public DoubleBasis TOTP_VLR_CANC { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    05          TOTP-QTD-REST        PIC  9(006).*/
            public IntBasis TOTP_QTD_REST { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05          TOTP-VLR-REST        PIC  9(013)V99.*/
            public DoubleBasis TOTP_VLR_REST { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    05          TOTP-QTD-FATU        PIC  9(006).*/
            public IntBasis TOTP_QTD_FATU { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05          TOTP-VLR-FATU        PIC  9(013)V99.*/
            public DoubleBasis TOTP_VLR_FATU { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    05          TOTP-QTD-PEND        PIC  9(006).*/
            public IntBasis TOTP_QTD_PEND { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05          TOTP-VLR-PEND        PIC  9(013)V99.*/
            public DoubleBasis TOTP_VLR_PEND { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"01            TOTAIS-GERAIS.*/
        }
        public VA1417B_TOTAIS_GERAIS TOTAIS_GERAIS { get; set; } = new VA1417B_TOTAIS_GERAIS();
        public class VA1417B_TOTAIS_GERAIS : VarBasis
        {
            /*"    05          TOTG-QTD-VENDA       PIC  9(006).*/
            public IntBasis TOTG_QTD_VENDA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05          TOTG-VLR-VENDA       PIC  9(013)V99.*/
            public DoubleBasis TOTG_VLR_VENDA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    05          TOTG-QTD-DEMAIS      PIC  9(006).*/
            public IntBasis TOTG_QTD_DEMAIS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05          TOTG-VLR-DEMAIS      PIC  9(013)V99.*/
            public DoubleBasis TOTG_VLR_DEMAIS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    05          TOTG-QTD-CANC        PIC  9(006).*/
            public IntBasis TOTG_QTD_CANC { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05          TOTG-VLR-CANC        PIC  9(013)V99.*/
            public DoubleBasis TOTG_VLR_CANC { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    05          TOTG-QTD-REST        PIC  9(006).*/
            public IntBasis TOTG_QTD_REST { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05          TOTG-VLR-REST        PIC  9(013)V99.*/
            public DoubleBasis TOTG_VLR_REST { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    05          TOTG-QTD-FATU        PIC  9(006).*/
            public IntBasis TOTG_QTD_FATU { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05          TOTG-VLR-FATU        PIC  9(013)V99.*/
            public DoubleBasis TOTG_VLR_FATU { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    05          TOTG-QTD-PEND        PIC  9(006).*/
            public IntBasis TOTG_QTD_PEND { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05          TOTG-VLR-PEND        PIC  9(013)V99.*/
            public DoubleBasis TOTG_VLR_PEND { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
        }


        public VA1417B_CHCONT CHCONT { get; set; } = new VA1417B_CHCONT();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string RVA1417B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                RVA1417B.SetFile(RVA1417B_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM M-0000-PRINCIPAL */

                M_0000_PRINCIPAL();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" M-0000-PRINCIPAL */
        private void M_0000_PRINCIPAL(bool isPerform = false)
        {
            /*" -414- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -417- EXEC SQL WHENEVER SQLERROR GO TO R9999-00-ROT-ERRO END-EXEC. */

            /*" -420- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -430- MOVE ZEROS TO TOTAIS-FILIAIS TOTAIS-PRODUTOS TOTAIS-GERAIS. */
            _.Move(0, TOTAIS_FILIAIS, TOTAIS_PRODUTOS, TOTAIS_GERAIS);

            /*" -432- PERFORM R6000-00-ZERA-DETALHE. */

            R6000_00_ZERA_DETALHE_SECTION();

            /*" -434- PERFORM R0100-00-SELECT-V1SISTEMA. */

            R0100_00_SELECT_V1SISTEMA_SECTION();

            /*" -435- IF WFIM-SISTEMA NOT EQUAL SPACES */

            if (!WORK_AREA.WFIM_SISTEMA.IsEmpty())
            {

                /*" -436- MOVE 9 TO RETURN-CODE */
                _.Move(9, RETURN_CODE);

                /*" -438- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -440- PERFORM R0200-00-SELECT-V0RELATORIOS. */

            R0200_00_SELECT_V0RELATORIOS_SECTION();

            /*" -441- IF WFIM-RELATORIO NOT EQUAL SPACES */

            if (!WORK_AREA.WFIM_RELATORIO.IsEmpty())
            {

                /*" -442- MOVE 9 TO RETURN-CODE */
                _.Move(9, RETURN_CODE);

                /*" -444- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -446- OPEN OUTPUT RVA1417B. */
            RVA1417B.Open(REG_IMPRESSAO);

            /*" -448- PERFORM R0900-00-DECLARE-V0HCONTABILVA. */

            R0900_00_DECLARE_V0HCONTABILVA_SECTION();

            /*" -450- PERFORM R0910-00-FETCH-V0HCONTABILVA. */

            R0910_00_FETCH_V0HCONTABILVA_SECTION();

            /*" -451- IF WFIM-HCONTABILVA EQUAL 'S' */

            if (WORK_AREA.WFIM_HCONTABILVA == "S")
            {

                /*" -452- DISPLAY '***********  VA1417B  *************' */
                _.Display($"***********  VA1417B  *************");

                /*" -453- DISPLAY 'NENHUM REG. SELECIONADO NA V0HISTCONTABILVA' */
                _.Display($"NENHUM REG. SELECIONADO NA V0HISTCONTABILVA");

                /*" -454- MOVE ZEROS TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -455- CLOSE RVA1417B */
                RVA1417B.Close();

                /*" -457- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -460- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-HCONTABILVA EQUAL 'S' . */

            while (!(WORK_AREA.WFIM_HCONTABILVA == "S"))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -461- PERFORM R1200-00-VALOR-FATURADO */

            R1200_00_VALOR_FATURADO_SECTION();

            /*" -462- PERFORM R2000-00-IMPRIME-FILIAL */

            R2000_00_IMPRIME_FILIAL_SECTION();

            /*" -462- PERFORM R2100-00-IMP-TOT-PRODUTO. */

            R2100_00_IMP_TOT_PRODUTO_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -475- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -475- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -478- DISPLAY '*** VA1417B - ' */
            _.Display($"*** VA1417B - ");

            /*" -480- DISPLAY 'LIDOS V0HISTCONTABILVA   ' AC-LIDOS. */
            _.Display($"LIDOS V0HISTCONTABILVA   {WORK_AREA.AC_LIDOS}");

            /*" -482- DISPLAY '*** VA1417B - TERMINO NORMAL ***' */
            _.Display($"*** VA1417B - TERMINO NORMAL ***");

            /*" -483- CLOSE RVA1417B */
            RVA1417B.Close();

            /*" -483- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-SECTION */
        private void R0100_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -496- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -503- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -506- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -507- DISPLAY 'VA1417B - SISTEMA VA NAO ESTA CADASTRADO' */
                _.Display($"VA1417B - SISTEMA VA NAO ESTA CADASTRADO");

                /*" -508- MOVE 'S' TO WFIM-SISTEMA */
                _.Move("S", WORK_AREA.WFIM_SISTEMA);

                /*" -510- GO TO R0100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -512- MOVE V1SIST-DTMOVABE TO DATA-SQL. */
            _.Move(V1SIST_DTMOVABE, WORK_AREA.DATA_SQL);

            /*" -513- MOVE ANO-SQL TO LC02-ANO. */
            _.Move(WORK_AREA.DATA_SQL.ANO_SQL, WORK_AREA.LC02.LC02_ANO);

            /*" -514- MOVE MES-SQL TO LC02-MES. */
            _.Move(WORK_AREA.DATA_SQL.MES_SQL, WORK_AREA.LC02.LC02_MES);

            /*" -516- MOVE DIA-SQL TO LC02-DIA. */
            _.Move(WORK_AREA.DATA_SQL.DIA_SQL, WORK_AREA.LC02.LC02_DIA);

            /*" -517- ACCEPT WHORA-CURR FROM TIME */
            _.Move(_.AcceptDate("TIME"), WORK_AREA.WHORA_CURR);

            /*" -518- MOVE WHORA-HH-CURR TO LC03-HOR */
            _.Move(WORK_AREA.WHORA_CURR.WHORA_HH_CURR, WORK_AREA.LC03.LC03_HOR);

            /*" -519- MOVE WHORA-MM-CURR TO LC03-MIN */
            _.Move(WORK_AREA.WHORA_CURR.WHORA_MM_CURR, WORK_AREA.LC03.LC03_MIN);

            /*" -519- MOVE WHORA-SS-CURR TO LC03-SEG. */
            _.Move(WORK_AREA.WHORA_CURR.WHORA_SS_CURR, WORK_AREA.LC03.LC03_SEG);

        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -503- EXEC SQL SELECT DTMOVABE INTO :V1SIST-DTMOVABE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VA' END-EXEC. */

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
        /*" R0200-00-SELECT-V0RELATORIOS-SECTION */
        private void R0200_00_SELECT_V0RELATORIOS_SECTION()
        {
            /*" -532- MOVE '020' TO WNR-EXEC-SQL. */
            _.Move("020", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -538- PERFORM R0200_00_SELECT_V0RELATORIOS_DB_SELECT_1 */

            R0200_00_SELECT_V0RELATORIOS_DB_SELECT_1();

            /*" -541- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -542- DISPLAY 'VA1417B - REGISTRO NAO ENCONTRADO V0RELATORIOS' */
                _.Display($"VA1417B - REGISTRO NAO ENCONTRADO V0RELATORIOS");

                /*" -543- MOVE 'S' TO WFIM-RELATORIO */
                _.Move("S", WORK_AREA.WFIM_RELATORIO);

                /*" -545- GO TO R0200-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/ //GOTO
                return;
            }


            /*" -547- MOVE V0RELA-DTREFER TO DATA-SQL. */
            _.Move(V0RELA_DTREFER, WORK_AREA.DATA_SQL);

            /*" -548- MOVE ANO-SQL TO LC03-ANO-REFER. */
            _.Move(WORK_AREA.DATA_SQL.ANO_SQL, WORK_AREA.LC03_1.LC03_ANO_REFER);

            /*" -548- MOVE TAB-MES (MES-SQL) TO LC03-MES-REFER. */
            _.Move(TABELA_MESES_R.TAB_MES[WORK_AREA.DATA_SQL.MES_SQL], WORK_AREA.LC03_1.LC03_MES_REFER);

        }

        [StopWatch]
        /*" R0200-00-SELECT-V0RELATORIOS-DB-SELECT-1 */
        public void R0200_00_SELECT_V0RELATORIOS_DB_SELECT_1()
        {
            /*" -538- EXEC SQL SELECT DATA_REFERENCIA INTO :V0RELA-DTREFER FROM SEGUROS.V0RELATORIOS WHERE CODRELAT = 'VA1417B' AND SITUACAO = '1' END-EXEC. */

            var r0200_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1 = new R0200_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0200_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1.Execute(r0200_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RELA_DTREFER, V0RELA_DTREFER);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-V0HCONTABILVA-SECTION */
        private void R0900_00_DECLARE_V0HCONTABILVA_SECTION()
        {
            /*" -561- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -602- PERFORM R0900_00_DECLARE_V0HCONTABILVA_DB_DECLARE_1 */

            R0900_00_DECLARE_V0HCONTABILVA_DB_DECLARE_1();

            /*" -604- PERFORM R0900_00_DECLARE_V0HCONTABILVA_DB_OPEN_1 */

            R0900_00_DECLARE_V0HCONTABILVA_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V0HCONTABILVA-DB-DECLARE-1 */
        public void R0900_00_DECLARE_V0HCONTABILVA_DB_DECLARE_1()
        {
            /*" -602- EXEC SQL DECLARE CHCONT CURSOR FOR SELECT A.NUM_APOLICE , A.CODSUBES , A.FONTE , A.NRENDOS , A.NRPARCEL , A.CODOPER , B.NOMEFTE , C.NOMPRODU , SUM(A.PRMVG + A.PRMAP), COUNT(*) FROM SEGUROS.V0HISTCONTABILVA A, SEGUROS.V0FONTE B, SEGUROS.V0PRODUTOSVG C WHERE A.DTFATUR = :V0RELA-DTREFER AND A.SITUACAO IN ( ' ' , '1' ) AND A.FONTE = B.FONTE AND A.NUM_APOLICE = C.NUM_APOLICE AND A.CODSUBES = C.CODSUBES AND C.DIA_FATURA = 31 AND C.ESTR_COBR = 'MULT' AND C.ORIG_PRODU IN ( 'FENAM' , 'CAAES' , 'VIDAZUL' ) GROUP BY A.NUM_APOLICE, A.CODSUBES , A.FONTE , A.NRENDOS , A.NRPARCEL , A.CODOPER , B.NOMEFTE , C.NOMPRODU ORDER BY A.NUM_APOLICE, A.CODSUBES , A.FONTE , A.NRENDOS , A.NRPARCEL , A.CODOPER , B.NOMEFTE , C.NOMPRODU END-EXEC. */
            CHCONT = new VA1417B_CHCONT(true);
            string GetQuery_CHCONT()
            {
                var query = @$"SELECT 
							A.NUM_APOLICE
							, 
							A.CODSUBES
							, 
							A.FONTE
							, 
							A.NRENDOS
							, 
							A.NRPARCEL
							, 
							A.CODOPER
							, 
							B.NOMEFTE
							, 
							C.NOMPRODU
							, 
							SUM(A.PRMVG + A.PRMAP)
							, 
							COUNT(*) 
							FROM SEGUROS.V0HISTCONTABILVA A
							, 
							SEGUROS.V0FONTE B
							, 
							SEGUROS.V0PRODUTOSVG C 
							WHERE A.DTFATUR = '{V0RELA_DTREFER}' 
							AND A.SITUACAO IN ( ' '
							, '1' ) 
							AND A.FONTE = B.FONTE 
							AND A.NUM_APOLICE = C.NUM_APOLICE 
							AND A.CODSUBES = C.CODSUBES 
							AND C.DIA_FATURA = 31 
							AND C.ESTR_COBR = 'MULT' 
							AND C.ORIG_PRODU IN ( 'FENAM'
							, 'CAAES'
							, 
							'VIDAZUL' ) 
							GROUP BY A.NUM_APOLICE
							, 
							A.CODSUBES
							, 
							A.FONTE
							, 
							A.NRENDOS
							, 
							A.NRPARCEL
							, 
							A.CODOPER
							, 
							B.NOMEFTE
							, 
							C.NOMPRODU 
							ORDER BY A.NUM_APOLICE
							, 
							A.CODSUBES
							, 
							A.FONTE
							, 
							A.NRENDOS
							, 
							A.NRPARCEL
							, 
							A.CODOPER
							, 
							B.NOMEFTE
							, 
							C.NOMPRODU";

                return query;
            }
            CHCONT.GetQueryEvent += GetQuery_CHCONT;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V0HCONTABILVA-DB-OPEN-1 */
        public void R0900_00_DECLARE_V0HCONTABILVA_DB_OPEN_1()
        {
            /*" -604- EXEC SQL OPEN CHCONT END-EXEC. */

            CHCONT.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-V0HCONTABILVA-SECTION */
        private void R0910_00_FETCH_V0HCONTABILVA_SECTION()
        {
            /*" -617- MOVE '091' TO WNR-EXEC-SQL. */
            _.Move("091", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -629- PERFORM R0910_00_FETCH_V0HCONTABILVA_DB_FETCH_1 */

            R0910_00_FETCH_V0HCONTABILVA_DB_FETCH_1();

            /*" -632- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -633- MOVE 'S' TO WFIM-HCONTABILVA */
                _.Move("S", WORK_AREA.WFIM_HCONTABILVA);

                /*" -633- PERFORM R0910_00_FETCH_V0HCONTABILVA_DB_CLOSE_1 */

                R0910_00_FETCH_V0HCONTABILVA_DB_CLOSE_1();

                /*" -636- GO TO R0910-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                return;
            }


            /*" -637- MOVE V0HCON-APOLICE TO APOLICE-ATU. */
            _.Move(V0HCON_APOLICE, CHAVE_ATU.APOLICE_ATU);

            /*" -638- MOVE V0HCON-CODSUBES TO CODSUBES-ATU. */
            _.Move(V0HCON_CODSUBES, CHAVE_ATU.CODSUBES_ATU);

            /*" -640- MOVE V0HCON-FONTE TO FONTE-ATU. */
            _.Move(V0HCON_FONTE, FONTE_ATU);

            /*" -640- ADD 1 TO AC-LIDOS. */
            WORK_AREA.AC_LIDOS.Value = WORK_AREA.AC_LIDOS + 1;

        }

        [StopWatch]
        /*" R0910-00-FETCH-V0HCONTABILVA-DB-FETCH-1 */
        public void R0910_00_FETCH_V0HCONTABILVA_DB_FETCH_1()
        {
            /*" -629- EXEC SQL FETCH CHCONT INTO :V0HCON-APOLICE, :V0HCON-CODSUBES, :V0HCON-FONTE, :V0HCON-NRENDOS, :V0HCON-NRPARCEL, :V0HCON-CODOPER, :V0FONT-NOMEFTE, :V0PROD-NOMPRODU, :V0HCON-PRMTOTAL, :V0HCON-QTD END-EXEC. */

            if (CHCONT.Fetch())
            {
                _.Move(CHCONT.V0HCON_APOLICE, V0HCON_APOLICE);
                _.Move(CHCONT.V0HCON_CODSUBES, V0HCON_CODSUBES);
                _.Move(CHCONT.V0HCON_FONTE, V0HCON_FONTE);
                _.Move(CHCONT.V0HCON_NRENDOS, V0HCON_NRENDOS);
                _.Move(CHCONT.V0HCON_NRPARCEL, V0HCON_NRPARCEL);
                _.Move(CHCONT.V0HCON_CODOPER, V0HCON_CODOPER);
                _.Move(CHCONT.V0FONT_NOMEFTE, V0FONT_NOMEFTE);
                _.Move(CHCONT.V0PROD_NOMPRODU, V0PROD_NOMPRODU);
                _.Move(CHCONT.V0HCON_PRMTOTAL, V0HCON_PRMTOTAL);
                _.Move(CHCONT.V0HCON_QTD, V0HCON_QTD);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-V0HCONTABILVA-DB-CLOSE-1 */
        public void R0910_00_FETCH_V0HCONTABILVA_DB_CLOSE_1()
        {
            /*" -633- EXEC SQL CLOSE CHCONT END-EXEC */

            CHCONT.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -652- IF CHAVE-ANT EQUAL ZEROES */

            if (CHAVE_ANT == 00)
            {

                /*" -653- MOVE V0HCON-APOLICE TO APOLICE-ANT */
                _.Move(V0HCON_APOLICE, CHAVE_ANT.APOLICE_ANT);

                /*" -654- MOVE V0HCON-CODSUBES TO CODSUBES-ANT */
                _.Move(V0HCON_CODSUBES, CHAVE_ANT.CODSUBES_ANT);

                /*" -655- PERFORM R3000-00-SELECT-V1APOLICE */

                R3000_00_SELECT_V1APOLICE_SECTION();

                /*" -657- PERFORM R5000-00-CABECALHOS. */

                R5000_00_CABECALHOS_SECTION();
            }


            /*" -658- IF CHAVE-ANT NOT EQUAL CHAVE-ATU */

            if (CHAVE_ANT != CHAVE_ATU)
            {

                /*" -659- PERFORM R1200-00-VALOR-FATURADO */

                R1200_00_VALOR_FATURADO_SECTION();

                /*" -660- PERFORM R2000-00-IMPRIME-FILIAL */

                R2000_00_IMPRIME_FILIAL_SECTION();

                /*" -662- MOVE V0HCON-FONTE TO FONTE-ANT LD01-FILIAL */
                _.Move(V0HCON_FONTE, FONTE_ANT, WORK_AREA.LD01.LD01_FILIAL);

                /*" -663- MOVE V0FONT-NOMEFTE TO LD01-NOMEFTE */
                _.Move(V0FONT_NOMEFTE, WORK_AREA.LD01.LD01_NOMEFTE);

                /*" -664- MOVE V0HCON-NRENDOS TO LD01-NRENDOS */
                _.Move(V0HCON_NRENDOS, WORK_AREA.LD01.LD01_NRENDOS);

                /*" -665- PERFORM R2100-00-IMP-TOT-PRODUTO */

                R2100_00_IMP_TOT_PRODUTO_SECTION();

                /*" -667- MOVE ZEROS TO TOTAIS-FILIAIS TOTAIS-PRODUTOS */
                _.Move(0, TOTAIS_FILIAIS, TOTAIS_PRODUTOS);

                /*" -668- MOVE V0HCON-APOLICE TO APOLICE-ANT */
                _.Move(V0HCON_APOLICE, CHAVE_ANT.APOLICE_ANT);

                /*" -669- MOVE V0HCON-CODSUBES TO CODSUBES-ANT */
                _.Move(V0HCON_CODSUBES, CHAVE_ANT.CODSUBES_ANT);

                /*" -670- PERFORM R3000-00-SELECT-V1APOLICE */

                R3000_00_SELECT_V1APOLICE_SECTION();

                /*" -672- PERFORM R5000-00-CABECALHOS. */

                R5000_00_CABECALHOS_SECTION();
            }


            /*" -673- IF FONTE-ANT EQUAL ZEROES */

            if (FONTE_ANT == 00)
            {

                /*" -675- MOVE V0HCON-FONTE TO FONTE-ANT LD01-FILIAL */
                _.Move(V0HCON_FONTE, FONTE_ANT, WORK_AREA.LD01.LD01_FILIAL);

                /*" -676- MOVE V0FONT-NOMEFTE TO LD01-NOMEFTE */
                _.Move(V0FONT_NOMEFTE, WORK_AREA.LD01.LD01_NOMEFTE);

                /*" -678- MOVE V0HCON-NRENDOS TO LD01-NRENDOS. */
                _.Move(V0HCON_NRENDOS, WORK_AREA.LD01.LD01_NRENDOS);
            }


            /*" -679- IF FONTE-ANT EQUAL FONTE-ATU */

            if (FONTE_ANT == FONTE_ATU)
            {

                /*" -680- MOVE V0HCON-NRENDOS TO LD01-NRENDOS */
                _.Move(V0HCON_NRENDOS, WORK_AREA.LD01.LD01_NRENDOS);

                /*" -681- PERFORM R1100-00-DEMAIS-VALORES */

                R1100_00_DEMAIS_VALORES_SECTION();

                /*" -682- ELSE */
            }
            else
            {


                /*" -683- PERFORM R1200-00-VALOR-FATURADO */

                R1200_00_VALOR_FATURADO_SECTION();

                /*" -684- PERFORM R2000-00-IMPRIME-FILIAL */

                R2000_00_IMPRIME_FILIAL_SECTION();

                /*" -685- MOVE ZEROS TO TOTAIS-FILIAIS */
                _.Move(0, TOTAIS_FILIAIS);

                /*" -687- MOVE V0HCON-FONTE TO FONTE-ANT LD01-FILIAL */
                _.Move(V0HCON_FONTE, FONTE_ANT, WORK_AREA.LD01.LD01_FILIAL);

                /*" -688- MOVE V0FONT-NOMEFTE TO LD01-NOMEFTE */
                _.Move(V0FONT_NOMEFTE, WORK_AREA.LD01.LD01_NOMEFTE);

                /*" -689- MOVE V0HCON-NRENDOS TO LD01-NRENDOS */
                _.Move(V0HCON_NRENDOS, WORK_AREA.LD01.LD01_NRENDOS);

                /*" -689- PERFORM R1100-00-DEMAIS-VALORES. */

                R1100_00_DEMAIS_VALORES_SECTION();
            }


            /*" -0- FLUXCONTROL_PERFORM R1000_10_NEXT */

            R1000_10_NEXT();

        }

        [StopWatch]
        /*" R1000-10-NEXT */
        private void R1000_10_NEXT(bool isPerform = false)
        {
            /*" -695- PERFORM R0910-00-FETCH-V0HCONTABILVA. */

            R0910_00_FETCH_V0HCONTABILVA_SECTION();

            /*" -696- IF AC-LINHA GREATER 57 */

            if (WORK_AREA.AC_LINHA > 57)
            {

                /*" -696- PERFORM R5000-00-CABECALHOS. */

                R5000_00_CABECALHOS_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-DEMAIS-VALORES-SECTION */
        private void R1100_00_DEMAIS_VALORES_SECTION()
        {
            /*" -709- MOVE '110' TO WNR-EXEC-SQL. */
            _.Move("110", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -712- IF V0HCON-CODOPER > 199 AND V0HCON-CODOPER < 300 AND V0HCON-NRPARCEL EQUAL 1 */

            if (V0HCON_CODOPER > 199 && V0HCON_CODOPER < 300 && V0HCON_NRPARCEL == 1)
            {

                /*" -714- COMPUTE TOTF-QTD-VENDA = TOTF-QTD-VENDA + V0HCON-QTD */
                TOTAIS_FILIAIS.TOTF_QTD_VENDA.Value = TOTAIS_FILIAIS.TOTF_QTD_VENDA + V0HCON_QTD;

                /*" -716- COMPUTE TOTF-VLR-VENDA = TOTF-VLR-VENDA + V0HCON-PRMTOTAL */
                TOTAIS_FILIAIS.TOTF_VLR_VENDA.Value = TOTAIS_FILIAIS.TOTF_VLR_VENDA + V0HCON_PRMTOTAL;

                /*" -718- COMPUTE TOTP-QTD-VENDA = TOTP-QTD-VENDA + V0HCON-QTD */
                TOTAIS_PRODUTOS.TOTP_QTD_VENDA.Value = TOTAIS_PRODUTOS.TOTP_QTD_VENDA + V0HCON_QTD;

                /*" -720- COMPUTE TOTP-VLR-VENDA = TOTP-VLR-VENDA + V0HCON-PRMTOTAL */
                TOTAIS_PRODUTOS.TOTP_VLR_VENDA.Value = TOTAIS_PRODUTOS.TOTP_VLR_VENDA + V0HCON_PRMTOTAL;

                /*" -722- COMPUTE TOTG-QTD-VENDA = TOTG-QTD-VENDA + V0HCON-QTD */
                TOTAIS_GERAIS.TOTG_QTD_VENDA.Value = TOTAIS_GERAIS.TOTG_QTD_VENDA + V0HCON_QTD;

                /*" -724- COMPUTE TOTG-VLR-VENDA = TOTG-VLR-VENDA + V0HCON-PRMTOTAL */
                TOTAIS_GERAIS.TOTG_VLR_VENDA.Value = TOTAIS_GERAIS.TOTG_VLR_VENDA + V0HCON_PRMTOTAL;

                /*" -725- GO TO R1100-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/ //GOTO
                return;

                /*" -726- ELSE */
            }
            else
            {


                /*" -729- IF V0HCON-CODOPER > 199 AND V0HCON-CODOPER < 300 AND V0HCON-NRPARCEL > 1 */

                if (V0HCON_CODOPER > 199 && V0HCON_CODOPER < 300 && V0HCON_NRPARCEL > 1)
                {

                    /*" -731- COMPUTE TOTF-QTD-DEMAIS = TOTF-QTD-DEMAIS + V0HCON-QTD */
                    TOTAIS_FILIAIS.TOTF_QTD_DEMAIS.Value = TOTAIS_FILIAIS.TOTF_QTD_DEMAIS + V0HCON_QTD;

                    /*" -733- COMPUTE TOTF-VLR-DEMAIS = TOTF-VLR-DEMAIS + V0HCON-PRMTOTAL */
                    TOTAIS_FILIAIS.TOTF_VLR_DEMAIS.Value = TOTAIS_FILIAIS.TOTF_VLR_DEMAIS + V0HCON_PRMTOTAL;

                    /*" -735- COMPUTE TOTP-QTD-DEMAIS = TOTP-QTD-DEMAIS + V0HCON-QTD */
                    TOTAIS_PRODUTOS.TOTP_QTD_DEMAIS.Value = TOTAIS_PRODUTOS.TOTP_QTD_DEMAIS + V0HCON_QTD;

                    /*" -737- COMPUTE TOTP-VLR-DEMAIS = TOTP-VLR-DEMAIS + V0HCON-PRMTOTAL */
                    TOTAIS_PRODUTOS.TOTP_VLR_DEMAIS.Value = TOTAIS_PRODUTOS.TOTP_VLR_DEMAIS + V0HCON_PRMTOTAL;

                    /*" -739- COMPUTE TOTG-QTD-DEMAIS = TOTG-QTD-DEMAIS + V0HCON-QTD */
                    TOTAIS_GERAIS.TOTG_QTD_DEMAIS.Value = TOTAIS_GERAIS.TOTG_QTD_DEMAIS + V0HCON_QTD;

                    /*" -741- COMPUTE TOTG-VLR-DEMAIS = TOTG-VLR-DEMAIS + V0HCON-PRMTOTAL */
                    TOTAIS_GERAIS.TOTG_VLR_DEMAIS.Value = TOTAIS_GERAIS.TOTG_VLR_DEMAIS + V0HCON_PRMTOTAL;

                    /*" -743- GO TO R1100-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -745- IF V0HCON-CODOPER > 399 AND V0HCON-CODOPER < 500 */

            if (V0HCON_CODOPER > 399 && V0HCON_CODOPER < 500)
            {

                /*" -747- COMPUTE TOTF-QTD-CANC = TOTF-QTD-CANC + V0HCON-QTD */
                TOTAIS_FILIAIS.TOTF_QTD_CANC.Value = TOTAIS_FILIAIS.TOTF_QTD_CANC + V0HCON_QTD;

                /*" -749- COMPUTE TOTF-VLR-CANC = TOTF-VLR-CANC + V0HCON-PRMTOTAL */
                TOTAIS_FILIAIS.TOTF_VLR_CANC.Value = TOTAIS_FILIAIS.TOTF_VLR_CANC + V0HCON_PRMTOTAL;

                /*" -751- COMPUTE TOTP-QTD-CANC = TOTP-QTD-CANC + V0HCON-QTD */
                TOTAIS_PRODUTOS.TOTP_QTD_CANC.Value = TOTAIS_PRODUTOS.TOTP_QTD_CANC + V0HCON_QTD;

                /*" -753- COMPUTE TOTP-VLR-CANC = TOTP-VLR-CANC + V0HCON-PRMTOTAL */
                TOTAIS_PRODUTOS.TOTP_VLR_CANC.Value = TOTAIS_PRODUTOS.TOTP_VLR_CANC + V0HCON_PRMTOTAL;

                /*" -755- COMPUTE TOTG-QTD-CANC = TOTG-QTD-CANC + V0HCON-QTD */
                TOTAIS_GERAIS.TOTG_QTD_CANC.Value = TOTAIS_GERAIS.TOTG_QTD_CANC + V0HCON_QTD;

                /*" -757- COMPUTE TOTG-VLR-CANC = TOTG-VLR-CANC + V0HCON-PRMTOTAL */
                TOTAIS_GERAIS.TOTG_VLR_CANC.Value = TOTAIS_GERAIS.TOTG_VLR_CANC + V0HCON_PRMTOTAL;

                /*" -759- GO TO R1100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -761- IF V0HCON-CODOPER > 499 AND V0HCON-CODOPER < 600 */

            if (V0HCON_CODOPER > 499 && V0HCON_CODOPER < 600)
            {

                /*" -763- COMPUTE TOTF-QTD-REST = TOTF-QTD-REST + V0HCON-QTD */
                TOTAIS_FILIAIS.TOTF_QTD_REST.Value = TOTAIS_FILIAIS.TOTF_QTD_REST + V0HCON_QTD;

                /*" -765- COMPUTE TOTF-VLR-REST = TOTF-VLR-REST + V0HCON-PRMTOTAL */
                TOTAIS_FILIAIS.TOTF_VLR_REST.Value = TOTAIS_FILIAIS.TOTF_VLR_REST + V0HCON_PRMTOTAL;

                /*" -767- COMPUTE TOTP-QTD-REST = TOTP-QTD-REST + V0HCON-QTD */
                TOTAIS_PRODUTOS.TOTP_QTD_REST.Value = TOTAIS_PRODUTOS.TOTP_QTD_REST + V0HCON_QTD;

                /*" -769- COMPUTE TOTP-VLR-REST = TOTP-VLR-REST + V0HCON-PRMTOTAL */
                TOTAIS_PRODUTOS.TOTP_VLR_REST.Value = TOTAIS_PRODUTOS.TOTP_VLR_REST + V0HCON_PRMTOTAL;

                /*" -771- COMPUTE TOTG-QTD-REST = TOTG-QTD-REST + V0HCON-QTD */
                TOTAIS_GERAIS.TOTG_QTD_REST.Value = TOTAIS_GERAIS.TOTG_QTD_REST + V0HCON_QTD;

                /*" -773- COMPUTE TOTG-VLR-REST = TOTG-VLR-REST + V0HCON-PRMTOTAL */
                TOTAIS_GERAIS.TOTG_VLR_REST.Value = TOTAIS_GERAIS.TOTG_VLR_REST + V0HCON_PRMTOTAL;

                /*" -775- GO TO R1100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -776- IF V0HCON-CODOPER EQUAL 1000 */

            if (V0HCON_CODOPER == 1000)
            {

                /*" -778- COMPUTE TOTF-QTD-PEND = TOTF-QTD-PEND + V0HCON-QTD */
                TOTAIS_FILIAIS.TOTF_QTD_PEND.Value = TOTAIS_FILIAIS.TOTF_QTD_PEND + V0HCON_QTD;

                /*" -780- COMPUTE TOTF-VLR-PEND = TOTF-VLR-PEND + V0HCON-PRMTOTAL */
                TOTAIS_FILIAIS.TOTF_VLR_PEND.Value = TOTAIS_FILIAIS.TOTF_VLR_PEND + V0HCON_PRMTOTAL;

                /*" -782- COMPUTE TOTP-QTD-PEND = TOTP-QTD-PEND + V0HCON-QTD */
                TOTAIS_PRODUTOS.TOTP_QTD_PEND.Value = TOTAIS_PRODUTOS.TOTP_QTD_PEND + V0HCON_QTD;

                /*" -784- COMPUTE TOTP-VLR-PEND = TOTP-VLR-PEND + V0HCON-PRMTOTAL */
                TOTAIS_PRODUTOS.TOTP_VLR_PEND.Value = TOTAIS_PRODUTOS.TOTP_VLR_PEND + V0HCON_PRMTOTAL;

                /*" -786- COMPUTE TOTG-QTD-PEND = TOTG-QTD-PEND + V0HCON-QTD */
                TOTAIS_GERAIS.TOTG_QTD_PEND.Value = TOTAIS_GERAIS.TOTG_QTD_PEND + V0HCON_QTD;

                /*" -787- COMPUTE TOTG-VLR-PEND = TOTG-VLR-PEND + V0HCON-PRMTOTAL. */
                TOTAIS_GERAIS.TOTG_VLR_PEND.Value = TOTAIS_GERAIS.TOTG_VLR_PEND + V0HCON_PRMTOTAL;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-VALOR-FATURADO-SECTION */
        private void R1200_00_VALOR_FATURADO_SECTION()
        {
            /*" -800- MOVE '120' TO WNR-EXEC-SQL. */
            _.Move("120", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -805- COMPUTE TOTF-QTD-FATU = TOTF-QTD-VENDA + TOTF-QTD-DEMAIS - TOTF-QTD-CANC - TOTF-QTD-REST. */
            TOTAIS_FILIAIS.TOTF_QTD_FATU.Value = TOTAIS_FILIAIS.TOTF_QTD_VENDA + TOTAIS_FILIAIS.TOTF_QTD_DEMAIS - TOTAIS_FILIAIS.TOTF_QTD_CANC - TOTAIS_FILIAIS.TOTF_QTD_REST;

            /*" -810- COMPUTE TOTF-VLR-FATU = TOTF-VLR-VENDA + TOTF-VLR-DEMAIS - TOTF-VLR-CANC - TOTF-VLR-REST. */
            TOTAIS_FILIAIS.TOTF_VLR_FATU.Value = TOTAIS_FILIAIS.TOTF_VLR_VENDA + TOTAIS_FILIAIS.TOTF_VLR_DEMAIS - TOTAIS_FILIAIS.TOTF_VLR_CANC - TOTAIS_FILIAIS.TOTF_VLR_REST;

            /*" -815- COMPUTE TOTP-QTD-FATU = TOTP-QTD-VENDA + TOTP-QTD-DEMAIS - TOTP-QTD-CANC - TOTP-QTD-REST. */
            TOTAIS_PRODUTOS.TOTP_QTD_FATU.Value = TOTAIS_PRODUTOS.TOTP_QTD_VENDA + TOTAIS_PRODUTOS.TOTP_QTD_DEMAIS - TOTAIS_PRODUTOS.TOTP_QTD_CANC - TOTAIS_PRODUTOS.TOTP_QTD_REST;

            /*" -820- COMPUTE TOTP-VLR-FATU = TOTP-VLR-VENDA + TOTP-VLR-DEMAIS - TOTP-VLR-CANC - TOTP-VLR-REST. */
            TOTAIS_PRODUTOS.TOTP_VLR_FATU.Value = TOTAIS_PRODUTOS.TOTP_VLR_VENDA + TOTAIS_PRODUTOS.TOTP_VLR_DEMAIS - TOTAIS_PRODUTOS.TOTP_VLR_CANC - TOTAIS_PRODUTOS.TOTP_VLR_REST;

            /*" -823- COMPUTE TOTG-QTD-FATU = TOTG-QTD-FATU + TOTP-QTD-FATU. */
            TOTAIS_GERAIS.TOTG_QTD_FATU.Value = TOTAIS_GERAIS.TOTG_QTD_FATU + TOTAIS_PRODUTOS.TOTP_QTD_FATU;

            /*" -826- COMPUTE TOTG-VLR-FATU = TOTG-VLR-FATU + TOTP-VLR-FATU. */
            TOTAIS_GERAIS.TOTG_VLR_FATU.Value = TOTAIS_GERAIS.TOTG_VLR_FATU + TOTAIS_PRODUTOS.TOTP_VLR_FATU;

            /*" -827- MOVE TOTF-QTD-FATU TO LD02-QTD-FATU. */
            _.Move(TOTAIS_FILIAIS.TOTF_QTD_FATU, WORK_AREA.LD02.LD02_QTD_FATU);

            /*" -827- MOVE TOTF-VLR-FATU TO LD02-VLR-FATU. */
            _.Move(TOTAIS_FILIAIS.TOTF_VLR_FATU, WORK_AREA.LD02.LD02_VLR_FATU);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-IMPRIME-FILIAL-SECTION */
        private void R2000_00_IMPRIME_FILIAL_SECTION()
        {
            /*" -840- MOVE '200' TO WNR-EXEC-SQL. */
            _.Move("200", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -841- WRITE REG-IMPRESSAO FROM LC05. */
            _.Move(WORK_AREA.LC05.GetMoveValues(), REG_IMPRESSAO);

            RVA1417B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -842- WRITE REG-IMPRESSAO FROM LD01. */
            _.Move(WORK_AREA.LD01.GetMoveValues(), REG_IMPRESSAO);

            RVA1417B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -843- WRITE REG-IMPRESSAO FROM BRANCO. */
            _.Move(WORK_AREA.BRANCO.GetMoveValues(), REG_IMPRESSAO);

            RVA1417B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -844- WRITE REG-IMPRESSAO FROM LC06. */
            _.Move(WORK_AREA.LC06.GetMoveValues(), REG_IMPRESSAO);

            RVA1417B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -845- WRITE REG-IMPRESSAO FROM LC07. */
            _.Move(WORK_AREA.LC07.GetMoveValues(), REG_IMPRESSAO);

            RVA1417B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -846- MOVE TOTF-QTD-VENDA TO LD02-QTD-VENDA. */
            _.Move(TOTAIS_FILIAIS.TOTF_QTD_VENDA, WORK_AREA.LD02.LD02_QTD_VENDA);

            /*" -847- MOVE TOTF-VLR-VENDA TO LD02-VLR-VENDA. */
            _.Move(TOTAIS_FILIAIS.TOTF_VLR_VENDA, WORK_AREA.LD02.LD02_VLR_VENDA);

            /*" -848- MOVE TOTF-QTD-DEMAIS TO LD02-QTD-DEMAIS. */
            _.Move(TOTAIS_FILIAIS.TOTF_QTD_DEMAIS, WORK_AREA.LD02.LD02_QTD_DEMAIS);

            /*" -849- MOVE TOTF-VLR-DEMAIS TO LD02-VLR-DEMAIS. */
            _.Move(TOTAIS_FILIAIS.TOTF_VLR_DEMAIS, WORK_AREA.LD02.LD02_VLR_DEMAIS);

            /*" -850- MOVE TOTF-QTD-CANC TO LD02-QTD-CANC. */
            _.Move(TOTAIS_FILIAIS.TOTF_QTD_CANC, WORK_AREA.LD02.LD02_QTD_CANC);

            /*" -851- MOVE TOTF-VLR-CANC TO LD02-VLR-CANC. */
            _.Move(TOTAIS_FILIAIS.TOTF_VLR_CANC, WORK_AREA.LD02.LD02_VLR_CANC);

            /*" -852- MOVE TOTF-QTD-REST TO LD02-QTD-REST. */
            _.Move(TOTAIS_FILIAIS.TOTF_QTD_REST, WORK_AREA.LD02.LD02_QTD_REST);

            /*" -853- MOVE TOTF-VLR-REST TO LD02-VLR-REST. */
            _.Move(TOTAIS_FILIAIS.TOTF_VLR_REST, WORK_AREA.LD02.LD02_VLR_REST);

            /*" -854- MOVE TOTF-QTD-PEND TO LD02-QTD-PEND. */
            _.Move(TOTAIS_FILIAIS.TOTF_QTD_PEND, WORK_AREA.LD02.LD02_QTD_PEND);

            /*" -855- MOVE TOTF-VLR-PEND TO LD02-VLR-PEND. */
            _.Move(TOTAIS_FILIAIS.TOTF_VLR_PEND, WORK_AREA.LD02.LD02_VLR_PEND);

            /*" -856- WRITE REG-IMPRESSAO FROM LD02. */
            _.Move(WORK_AREA.LD02.GetMoveValues(), REG_IMPRESSAO);

            RVA1417B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -857- WRITE REG-IMPRESSAO FROM TRACO. */
            _.Move(WORK_AREA.TRACO.GetMoveValues(), REG_IMPRESSAO);

            RVA1417B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -858- PERFORM R6000-00-ZERA-DETALHE */

            R6000_00_ZERA_DETALHE_SECTION();

            /*" -858- ADD 7 TO AC-LINHA. */
            WORK_AREA.AC_LINHA.Value = WORK_AREA.AC_LINHA + 7;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-IMP-TOT-PRODUTO-SECTION */
        private void R2100_00_IMP_TOT_PRODUTO_SECTION()
        {
            /*" -872- MOVE '210' TO WNR-EXEC-SQL. */
            _.Move("210", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -874- MOVE 'TOTAL PRODUTO' TO LD02-TITULO. */
            _.Move("TOTAL PRODUTO", WORK_AREA.LD02.LD02_TITULO);

            /*" -875- MOVE TOTP-QTD-VENDA TO LD02-QTD-VENDA. */
            _.Move(TOTAIS_PRODUTOS.TOTP_QTD_VENDA, WORK_AREA.LD02.LD02_QTD_VENDA);

            /*" -876- MOVE TOTP-QTD-DEMAIS TO LD02-QTD-DEMAIS. */
            _.Move(TOTAIS_PRODUTOS.TOTP_QTD_DEMAIS, WORK_AREA.LD02.LD02_QTD_DEMAIS);

            /*" -877- MOVE TOTP-QTD-CANC TO LD02-QTD-CANC. */
            _.Move(TOTAIS_PRODUTOS.TOTP_QTD_CANC, WORK_AREA.LD02.LD02_QTD_CANC);

            /*" -878- MOVE TOTP-QTD-REST TO LD02-QTD-REST. */
            _.Move(TOTAIS_PRODUTOS.TOTP_QTD_REST, WORK_AREA.LD02.LD02_QTD_REST);

            /*" -879- MOVE TOTP-QTD-FATU TO LD02-QTD-FATU. */
            _.Move(TOTAIS_PRODUTOS.TOTP_QTD_FATU, WORK_AREA.LD02.LD02_QTD_FATU);

            /*" -881- MOVE TOTP-QTD-PEND TO LD02-QTD-PEND. */
            _.Move(TOTAIS_PRODUTOS.TOTP_QTD_PEND, WORK_AREA.LD02.LD02_QTD_PEND);

            /*" -882- MOVE TOTP-VLR-VENDA TO LD02-VLR-VENDA. */
            _.Move(TOTAIS_PRODUTOS.TOTP_VLR_VENDA, WORK_AREA.LD02.LD02_VLR_VENDA);

            /*" -883- MOVE TOTP-VLR-DEMAIS TO LD02-VLR-DEMAIS. */
            _.Move(TOTAIS_PRODUTOS.TOTP_VLR_DEMAIS, WORK_AREA.LD02.LD02_VLR_DEMAIS);

            /*" -884- MOVE TOTP-VLR-CANC TO LD02-VLR-CANC. */
            _.Move(TOTAIS_PRODUTOS.TOTP_VLR_CANC, WORK_AREA.LD02.LD02_VLR_CANC);

            /*" -885- MOVE TOTP-VLR-REST TO LD02-VLR-REST. */
            _.Move(TOTAIS_PRODUTOS.TOTP_VLR_REST, WORK_AREA.LD02.LD02_VLR_REST);

            /*" -886- MOVE TOTP-VLR-FATU TO LD02-VLR-FATU. */
            _.Move(TOTAIS_PRODUTOS.TOTP_VLR_FATU, WORK_AREA.LD02.LD02_VLR_FATU);

            /*" -888- MOVE TOTP-VLR-PEND TO LD02-VLR-PEND. */
            _.Move(TOTAIS_PRODUTOS.TOTP_VLR_PEND, WORK_AREA.LD02.LD02_VLR_PEND);

            /*" -889- WRITE REG-IMPRESSAO FROM LD02 AFTER 3 */
            _.Move(WORK_AREA.LD02.GetMoveValues(), REG_IMPRESSAO);

            RVA1417B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -890- PERFORM R6000-00-ZERA-DETALHE */

            R6000_00_ZERA_DETALHE_SECTION();

            /*" -890- MOVE 90 TO AC-LINHA. */
            _.Move(90, WORK_AREA.AC_LINHA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-IMP-TOT-GERAL-SECTION */
        private void R2200_00_IMP_TOT_GERAL_SECTION()
        {
            /*" -903- MOVE '220' TO WNR-EXEC-SQL. */
            _.Move("220", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -905- MOVE 'TOTAL GERAL  ' TO LD02-TITULO. */
            _.Move("TOTAL GERAL  ", WORK_AREA.LD02.LD02_TITULO);

            /*" -906- MOVE TOTG-QTD-VENDA TO LD02-QTD-VENDA. */
            _.Move(TOTAIS_GERAIS.TOTG_QTD_VENDA, WORK_AREA.LD02.LD02_QTD_VENDA);

            /*" -907- MOVE TOTG-QTD-DEMAIS TO LD02-QTD-DEMAIS. */
            _.Move(TOTAIS_GERAIS.TOTG_QTD_DEMAIS, WORK_AREA.LD02.LD02_QTD_DEMAIS);

            /*" -908- MOVE TOTG-QTD-CANC TO LD02-QTD-CANC. */
            _.Move(TOTAIS_GERAIS.TOTG_QTD_CANC, WORK_AREA.LD02.LD02_QTD_CANC);

            /*" -909- MOVE TOTG-QTD-REST TO LD02-QTD-REST. */
            _.Move(TOTAIS_GERAIS.TOTG_QTD_REST, WORK_AREA.LD02.LD02_QTD_REST);

            /*" -910- MOVE TOTG-QTD-FATU TO LD02-QTD-FATU. */
            _.Move(TOTAIS_GERAIS.TOTG_QTD_FATU, WORK_AREA.LD02.LD02_QTD_FATU);

            /*" -912- MOVE TOTG-QTD-PEND TO LD02-QTD-PEND. */
            _.Move(TOTAIS_GERAIS.TOTG_QTD_PEND, WORK_AREA.LD02.LD02_QTD_PEND);

            /*" -913- MOVE TOTG-VLR-VENDA TO LD02-VLR-VENDA. */
            _.Move(TOTAIS_GERAIS.TOTG_VLR_VENDA, WORK_AREA.LD02.LD02_VLR_VENDA);

            /*" -914- MOVE TOTG-VLR-DEMAIS TO LD02-VLR-DEMAIS. */
            _.Move(TOTAIS_GERAIS.TOTG_VLR_DEMAIS, WORK_AREA.LD02.LD02_VLR_DEMAIS);

            /*" -915- MOVE TOTG-VLR-CANC TO LD02-VLR-CANC. */
            _.Move(TOTAIS_GERAIS.TOTG_VLR_CANC, WORK_AREA.LD02.LD02_VLR_CANC);

            /*" -916- MOVE TOTG-VLR-REST TO LD02-VLR-REST. */
            _.Move(TOTAIS_GERAIS.TOTG_VLR_REST, WORK_AREA.LD02.LD02_VLR_REST);

            /*" -917- MOVE TOTG-VLR-FATU TO LD02-VLR-FATU. */
            _.Move(TOTAIS_GERAIS.TOTG_VLR_FATU, WORK_AREA.LD02.LD02_VLR_FATU);

            /*" -919- MOVE TOTG-VLR-PEND TO LD02-VLR-PEND. */
            _.Move(TOTAIS_GERAIS.TOTG_VLR_PEND, WORK_AREA.LD02.LD02_VLR_PEND);

            /*" -920- WRITE REG-IMPRESSAO FROM BRANCO. */
            _.Move(WORK_AREA.BRANCO.GetMoveValues(), REG_IMPRESSAO);

            RVA1417B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -920- WRITE REG-IMPRESSAO FROM LD02. */
            _.Move(WORK_AREA.LD02.GetMoveValues(), REG_IMPRESSAO);

            RVA1417B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-SELECT-V1APOLICE-SECTION */
        private void R3000_00_SELECT_V1APOLICE_SECTION()
        {
            /*" -933- MOVE '300' TO WNR-EXEC-SQL. */
            _.Move("300", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -938- PERFORM R3000_00_SELECT_V1APOLICE_DB_SELECT_1 */

            R3000_00_SELECT_V1APOLICE_DB_SELECT_1();

            /*" -941- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -942- DISPLAY 'PROBLEMAS NO SELECT V1APOLICE ' */
                _.Display($"PROBLEMAS NO SELECT V1APOLICE ");

                /*" -942- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3000-00-SELECT-V1APOLICE-DB-SELECT-1 */
        public void R3000_00_SELECT_V1APOLICE_DB_SELECT_1()
        {
            /*" -938- EXEC SQL SELECT NOME INTO :V1APOL-NOMEAPOL FROM SEGUROS.V1APOLICE WHERE NUM_APOLICE = :V0HCON-APOLICE END-EXEC */

            var r3000_00_SELECT_V1APOLICE_DB_SELECT_1_Query1 = new R3000_00_SELECT_V1APOLICE_DB_SELECT_1_Query1()
            {
                V0HCON_APOLICE = V0HCON_APOLICE.ToString(),
            };

            var executed_1 = R3000_00_SELECT_V1APOLICE_DB_SELECT_1_Query1.Execute(r3000_00_SELECT_V1APOLICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1APOL_NOMEAPOL, V1APOL_NOMEAPOL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-UPDATE-RELATORIO-SECTION */
        private void R4000_00_UPDATE_RELATORIO_SECTION()
        {
            /*" -955- MOVE '400' TO WNR-EXEC-SQL. */
            _.Move("400", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -960- PERFORM R4000_00_UPDATE_RELATORIO_DB_UPDATE_1 */

            R4000_00_UPDATE_RELATORIO_DB_UPDATE_1();

            /*" -963- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -964- DISPLAY 'PROBLEMAS NO UPDATE V0RELATORIOS ' */
                _.Display($"PROBLEMAS NO UPDATE V0RELATORIOS ");

                /*" -964- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4000-00-UPDATE-RELATORIO-DB-UPDATE-1 */
        public void R4000_00_UPDATE_RELATORIO_DB_UPDATE_1()
        {
            /*" -960- EXEC SQL UPDATE SEGUROS.V0RELATORIOS SET SITUACAO = '2' WHERE CODRELAT = 'VA1417B' AND SITUACAO = '1' END-EXEC */

            var r4000_00_UPDATE_RELATORIO_DB_UPDATE_1_Update1 = new R4000_00_UPDATE_RELATORIO_DB_UPDATE_1_Update1()
            {
            };

            R4000_00_UPDATE_RELATORIO_DB_UPDATE_1_Update1.Execute(r4000_00_UPDATE_RELATORIO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R5000-00-CABECALHOS-SECTION */
        private void R5000_00_CABECALHOS_SECTION()
        {
            /*" -977- MOVE '500' TO WNR-EXEC-SQL. */
            _.Move("500", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -978- MOVE ZEROS TO AC-LINHA. */
            _.Move(0, WORK_AREA.AC_LINHA);

            /*" -979- ADD 1 TO AC-PAGINA. */
            WORK_AREA.AC_PAGINA.Value = WORK_AREA.AC_PAGINA + 1;

            /*" -980- MOVE AC-PAGINA TO LC01-PAGINA. */
            _.Move(WORK_AREA.AC_PAGINA, WORK_AREA.LC01.LC01_PAGINA);

            /*" -981- WRITE REG-IMPRESSAO FROM LC01 AFTER PAGE. */
            _.Move(WORK_AREA.LC01.GetMoveValues(), REG_IMPRESSAO);

            RVA1417B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -982- WRITE REG-IMPRESSAO FROM LC02. */
            _.Move(WORK_AREA.LC02.GetMoveValues(), REG_IMPRESSAO);

            RVA1417B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -983- WRITE REG-IMPRESSAO FROM LC03. */
            _.Move(WORK_AREA.LC03.GetMoveValues(), REG_IMPRESSAO);

            RVA1417B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -984- WRITE REG-IMPRESSAO FROM BRANCO. */
            _.Move(WORK_AREA.BRANCO.GetMoveValues(), REG_IMPRESSAO);

            RVA1417B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -985- WRITE REG-IMPRESSAO FROM LC03-1. */
            _.Move(WORK_AREA.LC03_1.GetMoveValues(), REG_IMPRESSAO);

            RVA1417B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -986- WRITE REG-IMPRESSAO FROM BRANCO. */
            _.Move(WORK_AREA.BRANCO.GetMoveValues(), REG_IMPRESSAO);

            RVA1417B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -987- WRITE REG-IMPRESSAO FROM TRACO. */
            _.Move(WORK_AREA.TRACO.GetMoveValues(), REG_IMPRESSAO);

            RVA1417B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -988- MOVE V0HCON-APOLICE TO LC03-APOLICE. */
            _.Move(V0HCON_APOLICE, WORK_AREA.LC03_2.LC03_APOLICE);

            /*" -989- MOVE V1APOL-NOMEAPOL TO LC03-NOMEAPOL. */
            _.Move(V1APOL_NOMEAPOL, WORK_AREA.LC03_2.LC03_NOMEAPOL);

            /*" -990- WRITE REG-IMPRESSAO FROM LC03-2. */
            _.Move(WORK_AREA.LC03_2.GetMoveValues(), REG_IMPRESSAO);

            RVA1417B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -991- MOVE V0HCON-CODSUBES TO LC04-CODSUBES. */
            _.Move(V0HCON_CODSUBES, WORK_AREA.LC04.LC04_CODSUBES);

            /*" -992- MOVE V0PROD-NOMPRODU TO LC04-NOMPRODU. */
            _.Move(V0PROD_NOMPRODU, WORK_AREA.LC04.LC04_NOMPRODU);

            /*" -993- WRITE REG-IMPRESSAO FROM LC04. */
            _.Move(WORK_AREA.LC04.GetMoveValues(), REG_IMPRESSAO);

            RVA1417B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -994- WRITE REG-IMPRESSAO FROM TRACO. */
            _.Move(WORK_AREA.TRACO.GetMoveValues(), REG_IMPRESSAO);

            RVA1417B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -995- WRITE REG-IMPRESSAO FROM BRANCO. */
            _.Move(WORK_AREA.BRANCO.GetMoveValues(), REG_IMPRESSAO);

            RVA1417B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -995- MOVE 11 TO AC-LINHA. */
            _.Move(11, WORK_AREA.AC_LINHA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_99_SAIDA*/

        [StopWatch]
        /*" R6000-00-ZERA-DETALHE-SECTION */
        private void R6000_00_ZERA_DETALHE_SECTION()
        {
            /*" -1008- MOVE '600' TO WNR-EXEC-SQL. */
            _.Move("600", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1009- MOVE SPACES TO LD02-TITULO. */
            _.Move("", WORK_AREA.LD02.LD02_TITULO);

            /*" -1020- MOVE ZEROS TO LD02-QTD-VENDA LD02-VLR-VENDA LD02-QTD-DEMAIS LD02-VLR-DEMAIS LD02-QTD-CANC LD02-VLR-CANC LD02-QTD-REST LD02-VLR-REST LD02-QTD-FATU LD02-VLR-FATU LD02-QTD-PEND LD02-VLR-PEND. */
            _.Move(0, WORK_AREA.LD02.LD02_QTD_VENDA, WORK_AREA.LD02.LD02_VLR_VENDA, WORK_AREA.LD02.LD02_QTD_DEMAIS, WORK_AREA.LD02.LD02_VLR_DEMAIS, WORK_AREA.LD02.LD02_QTD_CANC, WORK_AREA.LD02.LD02_VLR_CANC, WORK_AREA.LD02.LD02_QTD_REST, WORK_AREA.LD02.LD02_VLR_REST, WORK_AREA.LD02.LD02_QTD_FATU, WORK_AREA.LD02.LD02_VLR_FATU, WORK_AREA.LD02.LD02_QTD_PEND, WORK_AREA.LD02.LD02_VLR_PEND);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6000_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1034- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WORK_AREA.WABEND.WSQLCODE);

            /*" -1036- DISPLAY WABEND */
            _.Display(WORK_AREA.WABEND);

            /*" -1036- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1038- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1042- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1044- CLOSE RVA1417B */
            RVA1417B.Close();

            /*" -1044- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}