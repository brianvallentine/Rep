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
using Sias.FederalVida.DB2.VF0408B;

namespace Code
{
    public class VF0408B
    {
        public bool IsCall { get; set; }

        public VF0408B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                    OBJETIVO DO PROGRAMA                        *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO 02 - CAD 10.003                                       *      */
        /*"      *                                                                *      */
        /*"      *              - CONVERSAO DO DB2 PARA A VERSAO 10               *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/09/2013 -  CLAUDIO FREITAS                             *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.02    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *    EMITE O RELATORIO DE CANCELAMENTOS POR FALTA DE PAGAMENTO.  *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO   *    DATA    *    AUTOR     *       HISTORICO       *      */
        /*"      *            *            *              *                       *      */
        /*"      *     01     * 02/05/2000 *   FREDERICO  *                       *      */
        /*"      *            *            *              *                       *      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        public FileBasis _RVF0408B { get; set; } = new FileBasis(new PIC("X", "132", "X(132)"));

        public FileBasis RVF0408B
        {
            get
            {
                _.Move(REG_IMPRESSAO, _RVF0408B); VarBasis.RedefinePassValue(REG_IMPRESSAO, _RVF0408B, REG_IMPRESSAO); return _RVF0408B;
            }
        }
        public SortBasis<VF0408B_REG_SVF0408B> SVF0408B { get; set; } = new SortBasis<VF0408B_REG_SVF0408B>(new VF0408B_REG_SVF0408B());
        /*"01            REG-SVF0408B.*/
        public VF0408B_REG_SVF0408B REG_SVF0408B { get; set; } = new VF0408B_REG_SVF0408B();
        public class VF0408B_REG_SVF0408B : VarBasis
        {
            /*"  05          S-CODPDT            PIC S9(009)    COMP.*/
            public IntBasis S_CODPDT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05          S-NRCERTIF          PIC S9(015)    COMP-3.*/
            public IntBasis S_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            /*"  05          S-NOMPDT            PIC  X(040).*/
            public StringBasis S_NOMPDT { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  05          S-ENDPDT            PIC  X(040).*/
            public StringBasis S_ENDPDT { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  05          S-BAIPDT            PIC  X(020).*/
            public StringBasis S_BAIPDT { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05          S-CIDPDT            PIC  X(020).*/
            public StringBasis S_CIDPDT { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05          S-UFPDT             PIC  X(002).*/
            public StringBasis S_UFPDT { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05          S-CEPPDT            PIC  9(008).*/
            public IntBasis S_CEPPDT { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05          S-NOMSEG            PIC  X(040).*/
            public StringBasis S_NOMSEG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  05          S-ENDSEG            PIC  X(040).*/
            public StringBasis S_ENDSEG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  05          S-BAISEG            PIC  X(020).*/
            public StringBasis S_BAISEG { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05          S-CIDSEG            PIC  X(020).*/
            public StringBasis S_CIDSEG { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05          S-UFSEG             PIC  X(002).*/
            public StringBasis S_UFSEG { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05          S-CEPSEG            PIC  9(008).*/
            public IntBasis S_CEPSEG { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05          S-DTQITBCO          PIC  X(010).*/
            public StringBasis S_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05          S-DTMOVTO           PIC  X(010).*/
            public StringBasis S_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"01            REG-IMPRESSAO       PIC X(132).*/
        }
        public StringBasis REG_IMPRESSAO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis SORT_RETURN { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis SORT_FILE_SIZE { get; set; } = new IntBasis(new PIC("S9", "08", "S9(08)"));
        /*"77            V1SIST-DTHOJE       PIC  X(10).*/
        public StringBasis V1SIST_DTHOJE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V1SIST-DTMOVABE     PIC  X(10).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V1SIST-DTATRASO     PIC  X(10).*/
        public StringBasis V1SIST_DTATRASO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V0RELA-SITUACAO     PIC  X(01).*/
        public StringBasis V0RELA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77            V0PRDR-CODPDT       PIC S9(09) COMP.*/
        public IntBasis V0PRDR_CODPDT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77            V0PRDR-NOMPDT       PIC  X(40).*/
        public StringBasis V0PRDR_NOMPDT { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77            V0PRDR-ENDERECO     PIC  X(40).*/
        public StringBasis V0PRDR_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77            V0PRDR-BAIRRO       PIC  X(20).*/
        public StringBasis V0PRDR_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"77            V0PRDR-CIDADE       PIC  X(20).*/
        public StringBasis V0PRDR_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"77            V0PRDR-ESTADO       PIC  X(02).*/
        public StringBasis V0PRDR_ESTADO { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
        /*"77            V0PRDR-CEP          PIC S9(09) COMP.*/
        public IntBasis V0PRDR_CEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77            V0ENDE-ENDERECO     PIC  X(40).*/
        public StringBasis V0ENDE_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77            V0ENDE-BAIRRO       PIC  X(20).*/
        public StringBasis V0ENDE_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"77            V0ENDE-CIDADE       PIC  X(20).*/
        public StringBasis V0ENDE_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"77            V0ENDE-SIGLA-UF     PIC  X(02).*/
        public StringBasis V0ENDE_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
        /*"77            V0ENDE-CEP          PIC S9(09) COMP.*/
        public IntBasis V0ENDE_CEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77            V0CLIE-NOME-RAZAO   PIC  X(40).*/
        public StringBasis V0CLIE_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77            V0PRVA-NRCERTIF     PIC S9(15) COMP-3.*/
        public IntBasis V0PRVA_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77            V0PRVA-DTQITBCO     PIC  X(10).*/
        public StringBasis V0PRVA_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V0PRVA-SITUACAO     PIC  X(01).*/
        public StringBasis V0PRVA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77            V0HSEG-DTMOVTO      PIC  X(10).*/
        public StringBasis V0HSEG_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  WORK-AREA.*/
        public VF0408B_WORK_AREA WORK_AREA { get; set; } = new VF0408B_WORK_AREA();
        public class VF0408B_WORK_AREA : VarBasis
        {
            /*"    05        CODPDT-ANT          PIC S9(009) COMP.*/
            public IntBasis CODPDT_ANT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    05        DATA-SQL.*/
            public VF0408B_DATA_SQL DATA_SQL { get; set; } = new VF0408B_DATA_SQL();
            public class VF0408B_DATA_SQL : VarBasis
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
                /*"    05        DATA-SQL-REL.*/
            }
            public VF0408B_DATA_SQL_REL DATA_SQL_REL { get; set; } = new VF0408B_DATA_SQL_REL();
            public class VF0408B_DATA_SQL_REL : VarBasis
            {
                /*"      10      DIA-SQL-REL         PIC  9(002).*/
                public IntBasis DIA_SQL_REL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10      MES-SQL-REL         PIC  9(002).*/
                public IntBasis MES_SQL_REL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10      ANO-SQL-REL         PIC  9(004).*/
                public IntBasis ANO_SQL_REL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05        WS-DATA             PIC  9(008).*/
            }
            public IntBasis WS_DATA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05        WS-DATA-R           REDEFINES              WS-DATA.*/
            private _REDEF_VF0408B_WS_DATA_R _ws_data_r { get; set; }
            public _REDEF_VF0408B_WS_DATA_R WS_DATA_R
            {
                get { _ws_data_r = new _REDEF_VF0408B_WS_DATA_R(); _.Move(WS_DATA, _ws_data_r); VarBasis.RedefinePassValue(WS_DATA, _ws_data_r, WS_DATA); _ws_data_r.ValueChanged += () => { _.Move(_ws_data_r, WS_DATA); }; return _ws_data_r; }
                set { VarBasis.RedefinePassValue(value, _ws_data_r, WS_DATA); }
            }  //Redefines
            public class _REDEF_VF0408B_WS_DATA_R : VarBasis
            {
                /*"      10      WS-DIA              PIC  9(002).*/
                public IntBasis WS_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      WS-MES              PIC  9(002).*/
                public IntBasis WS_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      WS-ANO              PIC  9(004).*/
                public IntBasis WS_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05        WS-TIME             PIC  X(008).*/

                public _REDEF_VF0408B_WS_DATA_R()
                {
                    WS_DIA.ValueChanged += OnValueChanged;
                    WS_MES.ValueChanged += OnValueChanged;
                    WS_ANO.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05        WS-TIME-R           REDEFINES WS-TIME.*/
            private _REDEF_VF0408B_WS_TIME_R _ws_time_r { get; set; }
            public _REDEF_VF0408B_WS_TIME_R WS_TIME_R
            {
                get { _ws_time_r = new _REDEF_VF0408B_WS_TIME_R(); _.Move(WS_TIME, _ws_time_r); VarBasis.RedefinePassValue(WS_TIME, _ws_time_r, WS_TIME); _ws_time_r.ValueChanged += () => { _.Move(_ws_time_r, WS_TIME); }; return _ws_time_r; }
                set { VarBasis.RedefinePassValue(value, _ws_time_r, WS_TIME); }
            }  //Redefines
            public class _REDEF_VF0408B_WS_TIME_R : VarBasis
            {
                /*"      10      WS-HOR              PIC  9(002).*/
                public IntBasis WS_HOR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      WS-MIN              PIC  9(002).*/
                public IntBasis WS_MIN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      WS-SEG              PIC  9(002).*/
                public IntBasis WS_SEG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  9(002).*/
                public IntBasis FILLER_4 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        WFIM-V0PROPOSTAVF   PIC   X(01)  VALUE  ' '.*/

                public _REDEF_VF0408B_WS_TIME_R()
                {
                    WS_HOR.ValueChanged += OnValueChanged;
                    WS_MIN.ValueChanged += OnValueChanged;
                    WS_SEG.ValueChanged += OnValueChanged;
                    FILLER_4.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WFIM_V0PROPOSTAVF { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"    05        WFIM-V0RELATORIOS   PIC   X(01)  VALUE  ' '.*/
            public StringBasis WFIM_V0RELATORIOS { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"    05        WFIM-SORT           PIC   X(01)  VALUE  ' '.*/
            public StringBasis WFIM_SORT { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"    05        AC-LIDOS            PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-LINHA            PIC  9(006) VALUE 90.*/
            public IntBasis AC_LINHA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"), 90);
            /*"    05        AC-PAGINA           PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_PAGINA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-VIDAS-P          PIC  9(006)    VALUE ZEROS.*/
            public IntBasis AC_VIDAS_P { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        WABEND.*/
            public VF0408B_WABEND WABEND { get; set; } = new VF0408B_WABEND();
            public class VF0408B_WABEND : VarBasis
            {
                /*"      10      FILLER              PIC  X(010) VALUE           ' VF0408B'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VF0408B");
                /*"      10      FILLER              PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"      10      WNR-EXEC-SQL        PIC  X(004) VALUE '0000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                /*"      10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"      10      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05        LC01.*/
            }
            public VF0408B_LC01 LC01 { get; set; } = new VF0408B_LC01();
            public class VF0408B_LC01 : VarBasis
            {
                /*"      10      FILLER              PIC  X(008) VALUE 'VF0408B'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VF0408B");
                /*"      10      FILLER              PIC  X(037) VALUE SPACES.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"");
                /*"      10      FILLER              PIC  X(040) VALUE             'SASSE - CIA NACIONAL DE SEGUROS GERAIS'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"SASSE - CIA NACIONAL DE SEGUROS GERAIS");
                /*"      10      FILLER              PIC  X(030) VALUE SPACES.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"      10      FILLER              PIC  X(013) VALUE 'PAGINA'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"PAGINA");
                /*"      10      LC01-PAGINA         PIC  Z999.*/
                public IntBasis LC01_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "Z999."));
                /*"    05        LC02.*/
            }
            public VF0408B_LC02 LC02 { get; set; } = new VF0408B_LC02();
            public class VF0408B_LC02 : VarBasis
            {
                /*"      10      FILLER              PIC  X(115) VALUE SPACES.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "115", "X(115)"), @"");
                /*"      10      FILLER              PIC  X(007) VALUE 'DATA '.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"DATA ");
                /*"      10      LC02-DIA            PIC  9(02).*/
                public IntBasis LC02_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"      10      FILLER              PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10      LC02-MES            PIC  9(02).*/
                public IntBasis LC02_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"      10      FILLER              PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10      LC02-ANO            PIC  9(04).*/
                public IntBasis LC02_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"    05        LC03.*/
            }
            public VF0408B_LC03 LC03 { get; set; } = new VF0408B_LC03();
            public class VF0408B_LC03 : VarBasis
            {
                /*"      10      FILLER              PIC  X(004) VALUE             'MES '.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"MES ");
                /*"      10      LC03-MES            PIC  9(002).*/
                public IntBasis LC03_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10      LC03-ANO            PIC  9(004).*/
                public IntBasis LC03_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      FILLER              PIC  X(035) VALUE SPACES.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"");
                /*"      10      FILLER              PIC  X(036) VALUE             'CANCELAMENTOS POR FALTA DE PAGAMENTO'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"CANCELAMENTOS POR FALTA DE PAGAMENTO");
                /*"      10      FILLER              PIC  X(033) VALUE SPACES.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "33", "X(033)"), @"");
                /*"      10      FILLER              PIC  X(009) VALUE 'HORA '.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"HORA ");
                /*"      10      LC03-HOR            PIC  9(002).*/
                public IntBasis LC03_HOR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001) VALUE ':'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"      10      LC03-MIN            PIC  9(002).*/
                public IntBasis LC03_MIN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001) VALUE ':'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"      10      LC03-SEG            PIC  9(002).*/
                public IntBasis LC03_SEG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        LC04.*/
            }
            public VF0408B_LC04 LC04 { get; set; } = new VF0408B_LC04();
            public class VF0408B_LC04 : VarBasis
            {
                /*"      10      FILLER              PIC X(012) VALUE             'PRODUTOR    '.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PRODUTOR    ");
                /*"      10      LC04-CODPDT         PIC ZZZZZZZZ9.*/
                public IntBasis LC04_CODPDT { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZZZZ9."));
                /*"      10      FILLER              PIC X(003) VALUE ' - '.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" - ");
                /*"      10      LC04-NOMPDT         PIC X(040).*/
                public StringBasis LC04_NOMPDT { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    05        LC05.*/
            }
            public VF0408B_LC05 LC05 { get; set; } = new VF0408B_LC05();
            public class VF0408B_LC05 : VarBasis
            {
                /*"      10      FILLER              PIC X(024) VALUE              SPACES.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"");
                /*"      10      LC05-ENDPDT         PIC X(040).*/
                public StringBasis LC05_ENDPDT { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"      10      FILLER              PIC X(003) VALUE ' - '.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" - ");
                /*"      10      LC05-BAIPDT         PIC X(020).*/
                public StringBasis LC05_BAIPDT { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"      10      FILLER              PIC X(003) VALUE ' - '.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" - ");
                /*"      10      LC05-CIDPDT         PIC X(020).*/
                public StringBasis LC05_CIDPDT { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"      10      FILLER              PIC X(003) VALUE ' - '.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" - ");
                /*"      10      LC05-UFPDT          PIC X(002).*/
                public StringBasis LC05_UFPDT { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"      10      FILLER              PIC X(003) VALUE ' - '.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" - ");
                /*"      10      LC05-CEPPDT         PIC 99999.999.*/
                public IntBasis LC05_CEPPDT { get; set; } = new IntBasis(new PIC("9", "8", "99999.999."));
                /*"    05        LC06.*/
            }
            public VF0408B_LC06 LC06 { get; set; } = new VF0408B_LC06();
            public class VF0408B_LC06 : VarBasis
            {
                /*"      10      FILLER              PIC X(040) VALUE      'SEGURADO     '.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"SEGURADO     ");
                /*"      10      FILLER              PIC X(020) VALUE SPACES.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"      10      FILLER              PIC X(020) VALUE      'DATA INGRESSO '.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"DATA INGRESSO ");
                /*"      10      FILLER              PIC X(003) VALUE SPACES.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"      10      FILLER              PIC X(020) VALUE      'DATA CANCELAMENTO '.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"DATA CANCELAMENTO ");
                /*"    05        LC07.*/
            }
            public VF0408B_LC07 LC07 { get; set; } = new VF0408B_LC07();
            public class VF0408B_LC07 : VarBasis
            {
                /*"      10      FILLER              PIC X(017)  VALUE SPACES.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"");
                /*"      10      FILLER              PIC X(040)  VALUE      'ENDERECO '.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"ENDERECO ");
                /*"      10      FILLER              PIC X(003)  VALUE SPACES.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"      10      FILLER              PIC X(020)  VALUE      'BAIRRO '.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"BAIRRO ");
                /*"      10      FILLER              PIC X(003)  VALUE SPACES.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"      10      FILLER              PIC X(020)  VALUE      'CIDADE '.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"CIDADE ");
                /*"      10      FILLER              PIC X(003)  VALUE SPACES.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"      10      FILLER              PIC X(002)  VALUE      'UF'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"UF");
                /*"      10      FILLER              PIC X(004)  VALUE SPACES.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"      10      FILLER              PIC X(009)  VALUE      'CEP '.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"CEP ");
                /*"    05        LD01.*/
            }
            public VF0408B_LD01 LD01 { get; set; } = new VF0408B_LD01();
            public class VF0408B_LD01 : VarBasis
            {
                /*"      10      LD01-NRCERTIF       PIC ZZZZZZZZZZZZZZZ.*/
                public StringBasis LD01_NRCERTIF { get; set; } = new StringBasis(new PIC("X", "0", "ZZZZZZZZZZZZZZZ."), @"");
                /*"      10      FILLER              PIC X(002)  VALUE SPACES.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"      10      LD01-NOMSEG         PIC X(040).*/
                public StringBasis LD01_NOMSEG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"      10      FILLER              PIC X(005)  VALUE SPACES.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"      10      LD01-DTQITBCO       PIC X(010).*/
                public StringBasis LD01_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"      10      FILLER              PIC X(015)  VALUE SPACES.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"      10      LD01-DTMOVTO        PIC X(010).*/
                public StringBasis LD01_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    05        LD02.*/
            }
            public VF0408B_LD02 LD02 { get; set; } = new VF0408B_LD02();
            public class VF0408B_LD02 : VarBasis
            {
                /*"      10      FILLER              PIC X(017)  VALUE SPACES.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"");
                /*"      10      LD02-ENDERECO       PIC X(040).*/
                public StringBasis LD02_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"      10      FILLER              PIC X(003)  VALUE SPACES.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"      10      LD02-BAIRRO         PIC X(020).*/
                public StringBasis LD02_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"      10      FILLER              PIC X(003)  VALUE SPACES.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"      10      LD02-CIDADE         PIC X(020).*/
                public StringBasis LD02_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"      10      FILLER              PIC X(003)  VALUE SPACES.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"      10      LD02-SIGLA-UF       PIC X(002).*/
                public StringBasis LD02_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"      10      FILLER              PIC X(004)  VALUE SPACES.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"      10      LD02-CEP            PIC  99999.999.*/
                public IntBasis LD02_CEP { get; set; } = new IntBasis(new PIC("9", "8", "99999.999."));
                /*"    05        LT01.*/
            }
            public VF0408B_LT01 LT01 { get; set; } = new VF0408B_LT01();
            public class VF0408B_LT01 : VarBasis
            {
                /*"      10      LT01-NOME           PIC X(040).*/
                public StringBasis LT01_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"      10      FILLER              PIC X(010)  VALUE SPACES.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"      10      LT01-VIDAS          PIC ZZZ.ZZ9.*/
                public IntBasis LT01_VIDAS { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.ZZ9."));
            }
        }


        public VF0408B_CPROPVF CPROPVF { get; set; } = new VF0408B_CPROPVF();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string RVF0408B_FILE_NAME_P, string SVF0408B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                RVF0408B.SetFile(RVF0408B_FILE_NAME_P);
                SVF0408B.SetFile(SVF0408B_FILE_NAME_P);

                /*" -325- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -328- EXEC SQL WHENEVER SQLERROR GO TO R9999-00-ROT-ERRO END-EXEC. */

                /*" -331- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -331- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -339- PERFORM R0010-00-SELECT-V1SISTEMA. */

            R0010_00_SELECT_V1SISTEMA_SECTION();

            /*" -341- PERFORM R0005-00-SELECT-V0RELATORIOS. */

            R0005_00_SELECT_V0RELATORIOS_SECTION();

            /*" -342- IF WFIM-V0RELATORIOS EQUAL 'S' */

            if (WORK_AREA.WFIM_V0RELATORIOS == "S")
            {

                /*" -343- PERFORM R9700-00-SEM-SOLICITACAO */

                R9700_00_SEM_SOLICITACAO_SECTION();

                /*" -344- GO TO R0000-90-FINALIZA */

                R0000_90_FINALIZA(); //GOTO
                return;

                /*" -346- END-IF. */
            }


            /*" -348- MOVE +200000 TO SORT-FILE-SIZE. */
            _.Move(+200000, SORT_FILE_SIZE);

            /*" -352- SORT SVF0408B ON ASCENDING KEY S-CODPDT S-NOMSEG INPUT PROCEDURE R1000-00-SELECIONA THRU R1000-99-SAIDA OUTPUT PROCEDURE R2000-00-IMPRIME THRU R2000-99-SAIDA. */
            SORT_RETURN.Value = SVF0408B.Sort("S-CODPDT,S-NOMSEG", () => R1000_00_SELECIONA_SECTION(), () => R2000_00_IMPRIME_SECTION());

            /*" -356- IF SORT-RETURN NOT EQUAL ZEROS AND WFIM-SORT EQUAL ' ' */

            if (SORT_RETURN != 00 && WORK_AREA.WFIM_SORT == " ")
            {

                /*" -357- DISPLAY '*** VF0408B *** PROBLEMAS NO SORT ' */
                _.Display($"*** VF0408B *** PROBLEMAS NO SORT ");

                /*" -358- DISPLAY '*** VF0408B *** SORT-RETURN = ' SORT-RETURN */
                _.Display($"*** VF0408B *** SORT-RETURN = {SORT_RETURN}");

                /*" -360- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -360- PERFORM R0020-00-UPDATE-V0RELATORIOS. */

            R0020_00_UPDATE_V0RELATORIOS_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -364- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -367- DISPLAY '*** VF0408B LIDOS              ' AC-LIDOS. */
            _.Display($"*** VF0408B LIDOS              {WORK_AREA.AC_LIDOS}");

            /*" -369- DISPLAY ' ' . */
            _.Display($" ");

            /*" -371- DISPLAY '*** VF0408B - TERMINO NORMAL' . */
            _.Display($"*** VF0408B - TERMINO NORMAL");

            /*" -373- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -373- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -387- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WORK_AREA.WABEND.WSQLCODE);

            /*" -389- DISPLAY WABEND */
            _.Display(WORK_AREA.WABEND);

            /*" -389- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -391- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -395- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -395- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0005-00-SELECT-V0RELATORIOS-SECTION */
        private void R0005_00_SELECT_V0RELATORIOS_SECTION()
        {
            /*" -406- MOVE '005' TO WNR-EXEC-SQL. */
            _.Move("005", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -412- PERFORM R0005_00_SELECT_V0RELATORIOS_DB_SELECT_1 */

            R0005_00_SELECT_V0RELATORIOS_DB_SELECT_1();

            /*" -415- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -415- MOVE 'S' TO WFIM-V0RELATORIOS. */
                _.Move("S", WORK_AREA.WFIM_V0RELATORIOS);
            }


        }

        [StopWatch]
        /*" R0005-00-SELECT-V0RELATORIOS-DB-SELECT-1 */
        public void R0005_00_SELECT_V0RELATORIOS_DB_SELECT_1()
        {
            /*" -412- EXEC SQL SELECT SITUACAO INTO :V0RELA-SITUACAO FROM SEGUROS.V0RELATORIOS WHERE CODRELAT = 'VF0408B' AND SITUACAO = '0' END-EXEC. */

            var r0005_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1 = new R0005_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0005_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1.Execute(r0005_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RELA_SITUACAO, V0RELA_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0005_99_SAIDA*/

        [StopWatch]
        /*" R0010-00-SELECT-V1SISTEMA-SECTION */
        private void R0010_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -428- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -437- PERFORM R0010_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0010_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -440- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -441- DISPLAY 'VF0408B - SISTEMA VF NAO ESTA CADASTRADO' */
                _.Display($"VF0408B - SISTEMA VF NAO ESTA CADASTRADO");

                /*" -443- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -444- MOVE V1SIST-DTHOJE TO DATA-SQL. */
            _.Move(V1SIST_DTHOJE, WORK_AREA.DATA_SQL);

            /*" -445- MOVE ANO-SQL TO LC02-ANO. */
            _.Move(WORK_AREA.DATA_SQL.ANO_SQL, WORK_AREA.LC02.LC02_ANO);

            /*" -446- MOVE MES-SQL TO LC02-MES. */
            _.Move(WORK_AREA.DATA_SQL.MES_SQL, WORK_AREA.LC02.LC02_MES);

            /*" -448- MOVE DIA-SQL TO LC02-DIA. */
            _.Move(WORK_AREA.DATA_SQL.DIA_SQL, WORK_AREA.LC02.LC02_DIA);

            /*" -449- ACCEPT WS-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WORK_AREA.WS_TIME);

            /*" -450- MOVE WS-HOR TO LC03-HOR. */
            _.Move(WORK_AREA.WS_TIME_R.WS_HOR, WORK_AREA.LC03.LC03_HOR);

            /*" -451- MOVE WS-MIN TO LC03-MIN. */
            _.Move(WORK_AREA.WS_TIME_R.WS_MIN, WORK_AREA.LC03.LC03_MIN);

            /*" -453- MOVE WS-SEG TO LC03-SEG. */
            _.Move(WORK_AREA.WS_TIME_R.WS_SEG, WORK_AREA.LC03.LC03_SEG);

            /*" -454- MOVE V1SIST-DTMOVABE TO DATA-SQL. */
            _.Move(V1SIST_DTMOVABE, WORK_AREA.DATA_SQL);

            /*" -455- MOVE ANO-SQL TO LC03-ANO. */
            _.Move(WORK_AREA.DATA_SQL.ANO_SQL, WORK_AREA.LC03.LC03_ANO);

            /*" -455- MOVE MES-SQL TO LC03-MES. */
            _.Move(WORK_AREA.DATA_SQL.MES_SQL, WORK_AREA.LC03.LC03_MES);

        }

        [StopWatch]
        /*" R0010-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0010_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -437- EXEC SQL SELECT DTMOVABE, DTMOVABE - 5 DAYS, CURRENT DATE INTO :V1SIST-DTMOVABE, :V1SIST-DTATRASO, :V1SIST-DTHOJE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VF' END-EXEC. */

            var r0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 = new R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1.Execute(r0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
                _.Move(executed_1.V1SIST_DTATRASO, V1SIST_DTATRASO);
                _.Move(executed_1.V1SIST_DTHOJE, V1SIST_DTHOJE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_99_SAIDA*/

        [StopWatch]
        /*" R0020-00-UPDATE-V0RELATORIOS-SECTION */
        private void R0020_00_UPDATE_V0RELATORIOS_SECTION()
        {
            /*" -468- MOVE '020' TO WNR-EXEC-SQL. */
            _.Move("020", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -473- PERFORM R0020_00_UPDATE_V0RELATORIOS_DB_UPDATE_1 */

            R0020_00_UPDATE_V0RELATORIOS_DB_UPDATE_1();

            /*" -476- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -476- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0020-00-UPDATE-V0RELATORIOS-DB-UPDATE-1 */
        public void R0020_00_UPDATE_V0RELATORIOS_DB_UPDATE_1()
        {
            /*" -473- EXEC SQL UPDATE SEGUROS.V0RELATORIOS SET SITUACAO = '1' WHERE CODRELAT = 'VF0408B' AND SITUACAO = '0' END-EXEC. */

            var r0020_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1 = new R0020_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1()
            {
            };

            R0020_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1.Execute(r0020_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-SELECIONA-SECTION */
        private void R1000_00_SELECIONA_SECTION()
        {
            /*" -489- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -543- PERFORM R1000_00_SELECIONA_DB_DECLARE_1 */

            R1000_00_SELECIONA_DB_DECLARE_1();

            /*" -545- PERFORM R1000_00_SELECIONA_DB_OPEN_1 */

            R1000_00_SELECIONA_DB_OPEN_1();

            /*" -549- PERFORM R1900-00-FETCH-V0PROPOSTAVF. */

            R1900_00_FETCH_V0PROPOSTAVF_SECTION();

            /*" -550- IF WFIM-V0PROPOSTAVF EQUAL 'S' */

            if (WORK_AREA.WFIM_V0PROPOSTAVF == "S")
            {

                /*" -551- MOVE SPACES TO REG-SVF0408B */
                _.Move("", REG_SVF0408B);

                /*" -552- RELEASE REG-SVF0408B */
                SVF0408B.Release(REG_SVF0408B);

                /*" -555- GO TO R1000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -556- PERFORM R1100-00-MONTA-SORT UNTIL WFIM-V0PROPOSTAVF EQUAL 'S' . */

            while (!(WORK_AREA.WFIM_V0PROPOSTAVF == "S"))
            {

                R1100_00_MONTA_SORT_SECTION();
            }

        }

        [StopWatch]
        /*" R1000-00-SELECIONA-DB-DECLARE-1 */
        public void R1000_00_SELECIONA_DB_DECLARE_1()
        {
            /*" -543- EXEC SQL DECLARE CPROPVF CURSOR FOR SELECT DISTINCT A.NRCERTIF, A.CODPDT, C.NOMPDT, C.ENDERECO, C.BAIRRO, C.CIDADE, C.ESTADO, C.CEP, B.DTQITBCO, D.NOME_RAZAO, E.ENDERECO, E.BAIRRO, E.CIDADE, E.SIGLA_UF, E.CEP, F.DATA_MOVIMENTO FROM SEGUROS.V0PLANCOMISVF A, SEGUROS.V0PROPOSTAVA B, SEGUROS.V0PRODUTOR C, SEGUROS.V0CLIENTE D, SEGUROS.V0ENDERECOS E, SEGUROS.V0HISTSEGVG F, SEGUROS.V0SEGURAVG G WHERE A.NRCERTIF = B.NRCERTIF AND B.SITUACAO = '4' AND A.CODPDT = C.CODPDT AND B.CODCLIEN = D.COD_CLIENTE AND B.CODCLIEN = E.COD_CLIENTE AND E.OCORR_ENDERECO = 01 AND A.NRCERTIF = G.NUM_CERTIFICADO AND G.TIPO_SEGURADO = '1' AND G.NUM_APOLICE = F.NUM_APOLICE AND G.NUM_ITEM = F.NUM_ITEM AND G.OCORR_HISTORICO = F.OCORR_HISTORICO AND F.COD_OPERACAO = 403 ORDER BY A.NRCERTIF, A.CODPDT, C.NOMPDT, C.ENDERECO, C.BAIRRO, C.CIDADE, C.ESTADO, C.CEP, B.DTQITBCO, D.NOME_RAZAO, E.ENDERECO, E.BAIRRO, E.CIDADE, E.SIGLA_UF, E.CEP, F.DATA_MOVIMENTO END-EXEC. */
            CPROPVF = new VF0408B_CPROPVF(false);
            string GetQuery_CPROPVF()
            {
                var query = @$"SELECT DISTINCT 
							A.NRCERTIF
							, 
							A.CODPDT
							, 
							C.NOMPDT
							, 
							C.ENDERECO
							, 
							C.BAIRRO
							, 
							C.CIDADE
							, 
							C.ESTADO
							, 
							C.CEP
							, 
							B.DTQITBCO
							, 
							D.NOME_RAZAO
							, 
							E.ENDERECO
							, 
							E.BAIRRO
							, 
							E.CIDADE
							, 
							E.SIGLA_UF
							, 
							E.CEP
							, 
							F.DATA_MOVIMENTO 
							FROM SEGUROS.V0PLANCOMISVF A
							, 
							SEGUROS.V0PROPOSTAVA B
							, 
							SEGUROS.V0PRODUTOR C
							, 
							SEGUROS.V0CLIENTE D
							, 
							SEGUROS.V0ENDERECOS E
							, 
							SEGUROS.V0HISTSEGVG F
							, 
							SEGUROS.V0SEGURAVG G 
							WHERE A.NRCERTIF = B.NRCERTIF 
							AND B.SITUACAO = '4' 
							AND A.CODPDT = C.CODPDT 
							AND B.CODCLIEN = D.COD_CLIENTE 
							AND B.CODCLIEN = E.COD_CLIENTE 
							AND E.OCORR_ENDERECO = 01 
							AND A.NRCERTIF = G.NUM_CERTIFICADO 
							AND G.TIPO_SEGURADO = '1' 
							AND G.NUM_APOLICE = F.NUM_APOLICE 
							AND G.NUM_ITEM = F.NUM_ITEM 
							AND G.OCORR_HISTORICO = F.OCORR_HISTORICO 
							AND F.COD_OPERACAO = 403 
							ORDER BY A.NRCERTIF
							, 
							A.CODPDT
							, 
							C.NOMPDT
							, 
							C.ENDERECO
							, 
							C.BAIRRO
							, 
							C.CIDADE
							, 
							C.ESTADO
							, 
							C.CEP
							, 
							B.DTQITBCO
							, 
							D.NOME_RAZAO
							, 
							E.ENDERECO
							, 
							E.BAIRRO
							, 
							E.CIDADE
							, 
							E.SIGLA_UF
							, 
							E.CEP
							, 
							F.DATA_MOVIMENTO";

                return query;
            }
            CPROPVF.GetQueryEvent += GetQuery_CPROPVF;

        }

        [StopWatch]
        /*" R1000-00-SELECIONA-DB-OPEN-1 */
        public void R1000_00_SELECIONA_DB_OPEN_1()
        {
            /*" -545- EXEC SQL OPEN CPROPVF END-EXEC. */

            CPROPVF.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-MONTA-SORT-SECTION */
        private void R1100_00_MONTA_SORT_SECTION()
        {
            /*" -568- MOVE V0PRVA-NRCERTIF TO S-NRCERTIF. */
            _.Move(V0PRVA_NRCERTIF, REG_SVF0408B.S_NRCERTIF);

            /*" -569- MOVE V0PRDR-CODPDT TO S-CODPDT. */
            _.Move(V0PRDR_CODPDT, REG_SVF0408B.S_CODPDT);

            /*" -570- MOVE V0PRDR-NOMPDT TO S-NOMPDT. */
            _.Move(V0PRDR_NOMPDT, REG_SVF0408B.S_NOMPDT);

            /*" -571- MOVE V0PRDR-ENDERECO TO S-ENDPDT. */
            _.Move(V0PRDR_ENDERECO, REG_SVF0408B.S_ENDPDT);

            /*" -572- MOVE V0PRDR-BAIRRO TO S-BAIPDT. */
            _.Move(V0PRDR_BAIRRO, REG_SVF0408B.S_BAIPDT);

            /*" -573- MOVE V0PRDR-CIDADE TO S-CIDPDT. */
            _.Move(V0PRDR_CIDADE, REG_SVF0408B.S_CIDPDT);

            /*" -574- MOVE V0PRDR-ESTADO TO S-UFPDT. */
            _.Move(V0PRDR_ESTADO, REG_SVF0408B.S_UFPDT);

            /*" -575- MOVE V0PRDR-CEP TO S-CEPPDT. */
            _.Move(V0PRDR_CEP, REG_SVF0408B.S_CEPPDT);

            /*" -576- MOVE V0PRVA-DTQITBCO TO S-DTQITBCO. */
            _.Move(V0PRVA_DTQITBCO, REG_SVF0408B.S_DTQITBCO);

            /*" -577- MOVE V0CLIE-NOME-RAZAO TO S-NOMSEG. */
            _.Move(V0CLIE_NOME_RAZAO, REG_SVF0408B.S_NOMSEG);

            /*" -578- MOVE V0ENDE-ENDERECO TO S-ENDSEG. */
            _.Move(V0ENDE_ENDERECO, REG_SVF0408B.S_ENDSEG);

            /*" -579- MOVE V0ENDE-BAIRRO TO S-BAISEG. */
            _.Move(V0ENDE_BAIRRO, REG_SVF0408B.S_BAISEG);

            /*" -580- MOVE V0ENDE-CIDADE TO S-CIDSEG. */
            _.Move(V0ENDE_CIDADE, REG_SVF0408B.S_CIDSEG);

            /*" -581- MOVE V0ENDE-SIGLA-UF TO S-UFSEG. */
            _.Move(V0ENDE_SIGLA_UF, REG_SVF0408B.S_UFSEG);

            /*" -582- MOVE V0ENDE-CEP TO S-CEPSEG. */
            _.Move(V0ENDE_CEP, REG_SVF0408B.S_CEPSEG);

            /*" -584- MOVE V0HSEG-DTMOVTO TO S-DTMOVTO. */
            _.Move(V0HSEG_DTMOVTO, REG_SVF0408B.S_DTMOVTO);

            /*" -584- RELEASE REG-SVF0408B. */
            SVF0408B.Release(REG_SVF0408B);

            /*" -0- FLUXCONTROL_PERFORM R1100_00_NEXT */

            R1100_00_NEXT();

        }

        [StopWatch]
        /*" R1100-00-NEXT */
        private void R1100_00_NEXT(bool isPerform = false)
        {
            /*" -588- PERFORM R1900-00-FETCH-V0PROPOSTAVF. */

            R1900_00_FETCH_V0PROPOSTAVF_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1900-00-FETCH-V0PROPOSTAVF-SECTION */
        private void R1900_00_FETCH_V0PROPOSTAVF_SECTION()
        {
            /*" -601- MOVE '190' TO WNR-EXEC-SQL. */
            _.Move("190", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -619- PERFORM R1900_00_FETCH_V0PROPOSTAVF_DB_FETCH_1 */

            R1900_00_FETCH_V0PROPOSTAVF_DB_FETCH_1();

            /*" -622- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -623- MOVE 'S' TO WFIM-V0PROPOSTAVF */
                _.Move("S", WORK_AREA.WFIM_V0PROPOSTAVF);

                /*" -623- PERFORM R1900_00_FETCH_V0PROPOSTAVF_DB_CLOSE_1 */

                R1900_00_FETCH_V0PROPOSTAVF_DB_CLOSE_1();

                /*" -626- GO TO R1900-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/ //GOTO
                return;
            }


            /*" -626- ADD 1 TO AC-LIDOS. */
            WORK_AREA.AC_LIDOS.Value = WORK_AREA.AC_LIDOS + 1;

        }

        [StopWatch]
        /*" R1900-00-FETCH-V0PROPOSTAVF-DB-FETCH-1 */
        public void R1900_00_FETCH_V0PROPOSTAVF_DB_FETCH_1()
        {
            /*" -619- EXEC SQL FETCH CPROPVF INTO :V0PRVA-NRCERTIF, :V0PRDR-CODPDT, :V0PRDR-NOMPDT, :V0PRDR-ENDERECO, :V0PRDR-BAIRRO, :V0PRDR-CIDADE, :V0PRDR-ESTADO, :V0PRDR-CEP, :V0PRVA-DTQITBCO, :V0CLIE-NOME-RAZAO, :V0ENDE-ENDERECO, :V0ENDE-BAIRRO, :V0ENDE-CIDADE, :V0ENDE-SIGLA-UF, :V0ENDE-CEP, :V0HSEG-DTMOVTO END-EXEC. */

            if (CPROPVF.Fetch())
            {
                _.Move(CPROPVF.V0PRVA_NRCERTIF, V0PRVA_NRCERTIF);
                _.Move(CPROPVF.V0PRDR_CODPDT, V0PRDR_CODPDT);
                _.Move(CPROPVF.V0PRDR_NOMPDT, V0PRDR_NOMPDT);
                _.Move(CPROPVF.V0PRDR_ENDERECO, V0PRDR_ENDERECO);
                _.Move(CPROPVF.V0PRDR_BAIRRO, V0PRDR_BAIRRO);
                _.Move(CPROPVF.V0PRDR_CIDADE, V0PRDR_CIDADE);
                _.Move(CPROPVF.V0PRDR_ESTADO, V0PRDR_ESTADO);
                _.Move(CPROPVF.V0PRDR_CEP, V0PRDR_CEP);
                _.Move(CPROPVF.V0PRVA_DTQITBCO, V0PRVA_DTQITBCO);
                _.Move(CPROPVF.V0CLIE_NOME_RAZAO, V0CLIE_NOME_RAZAO);
                _.Move(CPROPVF.V0ENDE_ENDERECO, V0ENDE_ENDERECO);
                _.Move(CPROPVF.V0ENDE_BAIRRO, V0ENDE_BAIRRO);
                _.Move(CPROPVF.V0ENDE_CIDADE, V0ENDE_CIDADE);
                _.Move(CPROPVF.V0ENDE_SIGLA_UF, V0ENDE_SIGLA_UF);
                _.Move(CPROPVF.V0ENDE_CEP, V0ENDE_CEP);
                _.Move(CPROPVF.V0HSEG_DTMOVTO, V0HSEG_DTMOVTO);
            }

        }

        [StopWatch]
        /*" R1900-00-FETCH-V0PROPOSTAVF-DB-CLOSE-1 */
        public void R1900_00_FETCH_V0PROPOSTAVF_DB_CLOSE_1()
        {
            /*" -623- EXEC SQL CLOSE CPROPVF END-EXEC */

            CPROPVF.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-IMPRIME-SECTION */
        private void R2000_00_IMPRIME_SECTION()
        {
            /*" -643- MOVE '200' TO WNR-EXEC-SQL. */
            _.Move("200", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -645- RETURN SVF0408B AT END */
            try
            {
                SVF0408B.Return(REG_SVF0408B, () =>
                {

                    /*" -647- MOVE 'S' TO WFIM-SORT. */
                    _.Move("S", WORK_AREA.WFIM_SORT);

                });
            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -648- IF WFIM-SORT EQUAL 'S' */

            if (WORK_AREA.WFIM_SORT == "S")
            {

                /*" -649- PERFORM R9800-00-SEM-REGISTROS */

                R9800_00_SEM_REGISTROS_SECTION();

                /*" -651- GO TO R2000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -652- IF REG-SVF0408B EQUAL SPACES */

            if (REG_SVF0408B.IsEmpty())
            {

                /*" -653- PERFORM R9800-00-SEM-REGISTROS */

                R9800_00_SEM_REGISTROS_SECTION();

                /*" -655- GO TO R2000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -657- OPEN OUTPUT RVF0408B. */
            RVF0408B.Open(REG_IMPRESSAO);

            /*" -659- MOVE S-CODPDT TO CODPDT-ANT. */
            _.Move(REG_SVF0408B.S_CODPDT, WORK_AREA.CODPDT_ANT);

            /*" -662- PERFORM R2100-00-IMPRIME-PRODUTOR UNTIL WFIM-SORT EQUAL 'S' . */

            while (!(WORK_AREA.WFIM_SORT == "S"))
            {

                R2100_00_IMPRIME_PRODUTOR_SECTION();
            }

            /*" -662- CLOSE RVF0408B. */
            RVF0408B.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R9800-00-SEM-REGISTROS-SECTION */
        private void R9800_00_SEM_REGISTROS_SECTION()
        {
            /*" -676- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -677- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -678- DISPLAY '*   VF0408B - EMITE RELATORIO DE VENDAS    *' */
            _.Display($"*   VF0408B - EMITE RELATORIO DE VENDAS    *");

            /*" -679- DISPLAY '*   -------   ----- --------- -- ------    *' */
            _.Display($"*   -------   ----- --------- -- ------    *");

            /*" -680- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -681- DISPLAY '*             NENHUM MOVIMENTO ENCONTRADO, *' */
            _.Display($"*             NENHUM MOVIMENTO ENCONTRADO, *");

            /*" -682- DISPLAY '*             RELATORIO NAO FOI PRODUZIDO  *' */
            _.Display($"*             RELATORIO NAO FOI PRODUZIDO  *");

            /*" -683- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -683- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9800_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-IMPRIME-PRODUTOR-SECTION */
        private void R2100_00_IMPRIME_PRODUTOR_SECTION()
        {
            /*" -698- ADD 3 TO AC-LINHA. */
            WORK_AREA.AC_LINHA.Value = WORK_AREA.AC_LINHA + 3;

            /*" -699- IF S-CODPDT NOT EQUAL CODPDT-ANT */

            if (REG_SVF0408B.S_CODPDT != WORK_AREA.CODPDT_ANT)
            {

                /*" -700- MOVE S-CODPDT TO CODPDT-ANT */
                _.Move(REG_SVF0408B.S_CODPDT, WORK_AREA.CODPDT_ANT);

                /*" -702- MOVE 90 TO AC-LINHA. */
                _.Move(90, WORK_AREA.AC_LINHA);
            }


            /*" -703- IF AC-LINHA > 64 */

            if (WORK_AREA.AC_LINHA > 64)
            {

                /*" -704- ADD 1 TO AC-PAGINA */
                WORK_AREA.AC_PAGINA.Value = WORK_AREA.AC_PAGINA + 1;

                /*" -705- MOVE AC-PAGINA TO LC01-PAGINA */
                _.Move(WORK_AREA.AC_PAGINA, WORK_AREA.LC01.LC01_PAGINA);

                /*" -706- WRITE REG-IMPRESSAO FROM LC01 AFTER SALTA-PAGINA */
                _.Move(WORK_AREA.LC01.GetMoveValues(), REG_IMPRESSAO);

                RVF0408B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

                /*" -707- WRITE REG-IMPRESSAO FROM LC02 AFTER 1 */
                _.Move(WORK_AREA.LC02.GetMoveValues(), REG_IMPRESSAO);

                RVF0408B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

                /*" -708- WRITE REG-IMPRESSAO FROM LC03 AFTER 1 */
                _.Move(WORK_AREA.LC03.GetMoveValues(), REG_IMPRESSAO);

                RVF0408B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

                /*" -709- MOVE S-CODPDT TO LC04-CODPDT */
                _.Move(REG_SVF0408B.S_CODPDT, WORK_AREA.LC04.LC04_CODPDT);

                /*" -710- MOVE S-NOMPDT TO LC04-NOMPDT */
                _.Move(REG_SVF0408B.S_NOMPDT, WORK_AREA.LC04.LC04_NOMPDT);

                /*" -711- WRITE REG-IMPRESSAO FROM LC04 AFTER 2 */
                _.Move(WORK_AREA.LC04.GetMoveValues(), REG_IMPRESSAO);

                RVF0408B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

                /*" -712- MOVE S-ENDPDT TO LC05-ENDPDT */
                _.Move(REG_SVF0408B.S_ENDPDT, WORK_AREA.LC05.LC05_ENDPDT);

                /*" -713- MOVE S-BAIPDT TO LC05-BAIPDT */
                _.Move(REG_SVF0408B.S_BAIPDT, WORK_AREA.LC05.LC05_BAIPDT);

                /*" -714- MOVE S-CIDPDT TO LC05-CIDPDT */
                _.Move(REG_SVF0408B.S_CIDPDT, WORK_AREA.LC05.LC05_CIDPDT);

                /*" -715- MOVE S-UFPDT TO LC05-UFPDT */
                _.Move(REG_SVF0408B.S_UFPDT, WORK_AREA.LC05.LC05_UFPDT);

                /*" -716- MOVE S-CEPPDT TO LC05-CEPPDT */
                _.Move(REG_SVF0408B.S_CEPPDT, WORK_AREA.LC05.LC05_CEPPDT);

                /*" -717- WRITE REG-IMPRESSAO FROM LC05 AFTER 1 */
                _.Move(WORK_AREA.LC05.GetMoveValues(), REG_IMPRESSAO);

                RVF0408B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

                /*" -718- WRITE REG-IMPRESSAO FROM LC06 AFTER 2 */
                _.Move(WORK_AREA.LC06.GetMoveValues(), REG_IMPRESSAO);

                RVF0408B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

                /*" -719- WRITE REG-IMPRESSAO FROM LC07 AFTER 1 */
                _.Move(WORK_AREA.LC07.GetMoveValues(), REG_IMPRESSAO);

                RVF0408B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

                /*" -721- MOVE 12 TO AC-LINHA. */
                _.Move(12, WORK_AREA.AC_LINHA);
            }


            /*" -722- MOVE S-NRCERTIF TO LD01-NRCERTIF. */
            _.Move(REG_SVF0408B.S_NRCERTIF, WORK_AREA.LD01.LD01_NRCERTIF);

            /*" -723- MOVE S-NOMSEG TO LD01-NOMSEG. */
            _.Move(REG_SVF0408B.S_NOMSEG, WORK_AREA.LD01.LD01_NOMSEG);

            /*" -724- MOVE S-DTQITBCO TO DATA-SQL. */
            _.Move(REG_SVF0408B.S_DTQITBCO, WORK_AREA.DATA_SQL);

            /*" -725- MOVE ANO-SQL TO ANO-SQL-REL. */
            _.Move(WORK_AREA.DATA_SQL.ANO_SQL, WORK_AREA.DATA_SQL_REL.ANO_SQL_REL);

            /*" -726- MOVE MES-SQL TO MES-SQL-REL. */
            _.Move(WORK_AREA.DATA_SQL.MES_SQL, WORK_AREA.DATA_SQL_REL.MES_SQL_REL);

            /*" -727- MOVE DIA-SQL TO DIA-SQL-REL. */
            _.Move(WORK_AREA.DATA_SQL.DIA_SQL, WORK_AREA.DATA_SQL_REL.DIA_SQL_REL);

            /*" -728- MOVE DATA-SQL-REL TO LD01-DTQITBCO. */
            _.Move(WORK_AREA.DATA_SQL_REL, WORK_AREA.LD01.LD01_DTQITBCO);

            /*" -729- MOVE S-DTMOVTO TO DATA-SQL. */
            _.Move(REG_SVF0408B.S_DTMOVTO, WORK_AREA.DATA_SQL);

            /*" -730- MOVE ANO-SQL TO ANO-SQL-REL. */
            _.Move(WORK_AREA.DATA_SQL.ANO_SQL, WORK_AREA.DATA_SQL_REL.ANO_SQL_REL);

            /*" -731- MOVE MES-SQL TO MES-SQL-REL. */
            _.Move(WORK_AREA.DATA_SQL.MES_SQL, WORK_AREA.DATA_SQL_REL.MES_SQL_REL);

            /*" -732- MOVE DIA-SQL TO DIA-SQL-REL. */
            _.Move(WORK_AREA.DATA_SQL.DIA_SQL, WORK_AREA.DATA_SQL_REL.DIA_SQL_REL);

            /*" -733- MOVE DATA-SQL-REL TO LD01-DTMOVTO. */
            _.Move(WORK_AREA.DATA_SQL_REL, WORK_AREA.LD01.LD01_DTMOVTO);

            /*" -734- WRITE REG-IMPRESSAO FROM LD01 AFTER 2. */
            _.Move(WORK_AREA.LD01.GetMoveValues(), REG_IMPRESSAO);

            RVF0408B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -735- MOVE S-ENDSEG TO LD02-ENDERECO. */
            _.Move(REG_SVF0408B.S_ENDSEG, WORK_AREA.LD02.LD02_ENDERECO);

            /*" -736- MOVE S-BAISEG TO LD02-BAIRRO. */
            _.Move(REG_SVF0408B.S_BAISEG, WORK_AREA.LD02.LD02_BAIRRO);

            /*" -737- MOVE S-CIDSEG TO LD02-CIDADE. */
            _.Move(REG_SVF0408B.S_CIDSEG, WORK_AREA.LD02.LD02_CIDADE);

            /*" -738- MOVE S-UFSEG TO LD02-SIGLA-UF. */
            _.Move(REG_SVF0408B.S_UFSEG, WORK_AREA.LD02.LD02_SIGLA_UF);

            /*" -739- MOVE S-CEPSEG TO LD02-CEP. */
            _.Move(REG_SVF0408B.S_CEPSEG, WORK_AREA.LD02.LD02_CEP);

            /*" -739- WRITE REG-IMPRESSAO FROM LD02 AFTER 1. */
            _.Move(WORK_AREA.LD02.GetMoveValues(), REG_IMPRESSAO);

            RVF0408B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -0- FLUXCONTROL_PERFORM R2100_90_NEXT */

            R2100_90_NEXT();

        }

        [StopWatch]
        /*" R2100-90-NEXT */
        private void R2100_90_NEXT(bool isPerform = false)
        {
            /*" -744- RETURN SVF0408B AT END */
            try
            {
                SVF0408B.Return(REG_SVF0408B, () =>
                {

                    /*" -744- MOVE 'S' TO WFIM-SORT. */
                    _.Move("S", WORK_AREA.WFIM_SORT);

                });
            }
            catch (GoToException ex)
            {
                return;
            }
        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R9700-00-SEM-SOLICITACAO-SECTION */
        private void R9700_00_SEM_SOLICITACAO_SECTION()
        {
            /*" -756- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -757- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -758- DISPLAY '*   VF0408B - EMITE RELATORIO DE VENDAS    *' */
            _.Display($"*   VF0408B - EMITE RELATORIO DE VENDAS    *");

            /*" -759- DISPLAY '*   -------   ----- --------- -- ------    *' */
            _.Display($"*   -------   ----- --------- -- ------    *");

            /*" -760- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -761- DISPLAY '*             NAO HOUVE SOLICITACAO        *' */
            _.Display($"*             NAO HOUVE SOLICITACAO        *");

            /*" -762- DISPLAY '*             RELATORIO NAO FOI PRODUZIDO  *' */
            _.Display($"*             RELATORIO NAO FOI PRODUZIDO  *");

            /*" -763- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -763- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9700_99_SAIDA*/
    }
}