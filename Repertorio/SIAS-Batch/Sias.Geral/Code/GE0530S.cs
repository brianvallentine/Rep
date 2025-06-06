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
using Sias.Geral.DB2.GE0530S;

namespace Code
{
    public class GE0530S
    {
        public bool IsCall { get; set; }

        public GE0530S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-----------------------------------------------------------------      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................:  CORPORATIVO                              */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   PROGRAMA ...............:  GE0530S                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............:  FLAVIO DE LIMA SILVA              *      */
        /*"      *   PROGRAMADOR ............:  FLAVIO DE LIMA SILVA              *      */
        /*"      *   DATA CODIFICACAO .......:  JUNHO/2019.                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................:  CONSULTAR AS PESSOAS POLITICAMENTE*      */
        /*"      *                              EXPOSTAS - PEPS E GRAVAR LOG NA   *      */
        /*"      *                              GE_PESSOA_VALIDA_LOG.             *      */
        /*"      *                                                                *      */
        /*"      *     - PARAMETRO DE ENTRADA:  BOOK LBGE0530                     *      */
        /*"      *                              LK-GE0530-FUNCAO                  *      */
        /*"      *                              LK-GE0530-CPF-CNPJ                *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   N    VERSAO   RESPONSAVEL          DATA        ALTERACAO     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   1      01     FLAVIO DE LIMA    02/07/2019    JAZZ 197.432   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *            E N V I R O N M E N T   D I V I S I O N             *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        /*"77  WS-QT-ENDOSSO                    PIC S9(006) VALUE +0 COMP.*/
        public IntBasis WS_QT_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "6", "S9(006)"));
        /*"77  WS-QT-PROPOSTA                   PIC S9(006) VALUE +0 COMP.*/
        public IntBasis WS_QT_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "6", "S9(006)"));
        /*"77  WS-CONTADOR                      PIC S9(004) VALUE  0 COMP.*/
        public IntBasis WS_CONTADOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-CONT-FETCH                    PIC S9(004) VALUE  0 COMP.*/
        public IntBasis WS_CONT_FETCH { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-GE0531S                       PIC  X(007) VALUE 'GE0531S'*/
        public StringBasis WS_GE0531S { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"GE0531S");

        /*"01  WS-ERRO                          PIC S9(009) COMP VALUE +0.*/
        public IntBasis WS_ERRO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  WS-IND                           PIC S9(009) COMP VALUE +0.*/
        public IntBasis WS_IND { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  WS-IND1                          PIC S9(009) COMP VALUE +0.*/
        public IntBasis WS_IND1 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  WS-DISPLAY                       PIC  X(003) VALUE 'S'.*/
        public StringBasis WS_DISPLAY { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"S");
        /*"01  WS-MENSAGEM                      PIC  X(100) VALUE SPACES.*/
        public StringBasis WS_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "100", "X(100)"), @"");
        /*"01  FIM-PEP-RELAC                    PIC  X(001) VALUE SPACES.*/
        public StringBasis FIM_PEP_RELAC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01  WS-PARAGRAFO                     PIC  X(008) VALUE SPACES.*/
        public StringBasis WS_PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"01  WS-SQLCODE                       PIC  -ZZZ999.*/
        public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "6", "-ZZZ999."));
        /*"01  WNR-EXE                          PIC  X(004) VALUE '0000'.*/
        public StringBasis WNR_EXE { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
        /*"01  WS-GE0530-FUNCAO                 PIC S9(004) VALUE 0 COMP.*/
        public IntBasis WS_GE0530_FUNCAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WABEND.*/
        public GE0530S_WABEND WABEND { get; set; } = new GE0530S_WABEND();
        public class GE0530S_WABEND : VarBasis
        {
            /*"    05  WABEND1                      PIC  X(009)  VALUE                                                      'GE0530S '*/
            public StringBasis WABEND1 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"GE0530S ");
            /*"    05  WABEND2.*/
            public GE0530S_WABEND2 WABEND2 { get; set; } = new GE0530S_WABEND2();
            public class GE0530S_WABEND2 : VarBasis
            {
                /*"        10  FILLER                   PIC  X(025)  VALUE                                     '*** ERRO EXEC SQL NUMERO '*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"*** ERRO EXEC SQL NUMERO ");
                /*"        10  WNR-EXEC-SQL             PIC  X(005)  VALUE SPACES.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"    05  WABEND3.*/
            }
            public GE0530S_WABEND3 WABEND3 { get; set; } = new GE0530S_WABEND3();
            public class GE0530S_WABEND3 : VarBasis
            {
                /*"        10  FILLER                   PIC  X(013)  VALUE                                                 ' *** SQLCODE '*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"        10  WSQLCODE                 PIC  -999.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "3", "-999."));
                /*"01 WS-DATA-DB2.*/
            }
        }
        public GE0530S_WS_DATA_DB2 WS_DATA_DB2 { get; set; } = new GE0530S_WS_DATA_DB2();
        public class GE0530S_WS_DATA_DB2 : VarBasis
        {
            /*"    05  WS-ANO-DB2                   PIC 9(004) VALUE 0.*/
            public IntBasis WS_ANO_DB2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  FILLER-1-DB2                 PIC X(001) VALUE '-'.*/
            public StringBasis FILLER_1_DB2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"    05  WS-MES-DB2                   PIC 9(002) VALUE 0.*/
            public IntBasis WS_MES_DB2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    05  FILLER-2-DB2                 PIC X(001) VALUE '-'.*/
            public StringBasis FILLER_2_DB2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"    05  WS-DIA-DB2                   PIC 9(002) VALUE 0.*/
            public IntBasis WS_DIA_DB2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"01  WS-GE0530-PEPS.*/
        }
        public GE0530S_WS_GE0530_PEPS WS_GE0530_PEPS { get; set; } = new GE0530S_WS_GE0530_PEPS();
        public class GE0530S_WS_GE0530_PEPS : VarBasis
        {
            /*"    05  WS-GE0530-SEQ-PEPS           PIC S9(009) COMP VALUE 0.*/
            public IntBasis WS_GE0530_SEQ_PEPS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    05  WS-GE0530-DTA-INIVIG-PEPS    PIC  X(010) VALUE ' '.*/
            public StringBasis WS_GE0530_DTA_INIVIG_PEPS { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" ");
            /*"    05  WS-GE0530-DTA-FIMVIG-PEPS    PIC  X(010) VALUE ' '.*/
            public StringBasis WS_GE0530_DTA_FIMVIG_PEPS { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" ");
            /*"    05  WS-GE0530-COD-TP-PEPS        PIC S9(004) COMP VALUE 0.*/
            public IntBasis WS_GE0530_COD_TP_PEPS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05  WS-GE0530-COD-PEPS-EXTERNO   PIC S9(009) COMP VALUE 0.*/
            public IntBasis WS_GE0530_COD_PEPS_EXTERNO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    05  WS-GE0530-COD-PEPS-RELAC     PIC S9(009) COMP VALUE 0.*/
            public IntBasis WS_GE0530_COD_PEPS_RELAC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    05  WS-GE0530-NUM-CPF-CNPJ       PIC S9(018) COMP VALUE 0.*/
            public IntBasis WS_GE0530_NUM_CPF_CNPJ { get; set; } = new IntBasis(new PIC("S9", "18", "S9(018)"));
            /*"    05  WS-GE0530-NOM-PEPS           PIC  X(100) VALUE ' '.*/
            public StringBasis WS_GE0530_NOM_PEPS { get; set; } = new StringBasis(new PIC("X", "100", "X(100)"), @" ");
            /*"    05  WS-GE0530-COD-ORGAO-PEPS     PIC  X(005) VALUE ' '.*/
            public StringBasis WS_GE0530_COD_ORGAO_PEPS { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @" ");
            /*"    05  WS-GE0530-NOM-ORGAO-PEPS     PIC  X(150) VALUE ' '.*/
            public StringBasis WS_GE0530_NOM_ORGAO_PEPS { get; set; } = new StringBasis(new PIC("X", "150", "X(150)"), @" ");
            /*"    05  WS-GE0530-COD-CARGO          PIC  X(005) VALUE ' '.*/
            public StringBasis WS_GE0530_COD_CARGO { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @" ");
            /*"    05  WS-GE0530-NOM-CARGO          PIC  X(100) VALUE ' '.*/
            public StringBasis WS_GE0530_NOM_CARGO { get; set; } = new StringBasis(new PIC("X", "100", "X(100)"), @" ");
            /*"    05  WS-GE0530-COD-COAF           PIC  X(005) VALUE ' '.*/
            public StringBasis WS_GE0530_COD_COAF { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @" ");
            /*"    05  WS-GE0530-IND-SEXO           PIC  X(001) VALUE ' '.*/
            public StringBasis WS_GE0530_IND_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"    05  WS-GE0530-NOM-LOGRADOURO     PIC  X(050) VALUE ' '.*/
            public StringBasis WS_GE0530_NOM_LOGRADOURO { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @" ");
            /*"    05  WS-GE0530-DES-LOGRADOURO     PIC  X(005) VALUE ' '.*/
            public StringBasis WS_GE0530_DES_LOGRADOURO { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @" ");
            /*"    05  WS-GE0530-DES-COMPLEMENTO    PIC  X(040) VALUE ' '.*/
            public StringBasis WS_GE0530_DES_COMPLEMENTO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @" ");
            /*"    05  WS-GE0530-NOM-BAIRRO         PIC  X(040) VALUE ' '.*/
            public StringBasis WS_GE0530_NOM_BAIRRO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @" ");
            /*"    05  WS-GE0530-COD-CEP            PIC  X(008) VALUE ' '.*/
            public StringBasis WS_GE0530_COD_CEP { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @" ");
            /*"    05  WS-GE0530-NOM-MUNICIPIO      PIC  X(010) VALUE ' '.*/
            public StringBasis WS_GE0530_NOM_MUNICIPIO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" ");
            /*"    05  WS-GE0530-COD-UF             PIC  X(002) VALUE ' '.*/
            public StringBasis WS_GE0530_COD_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" ");
            /*"    05  WS-GE0530-DTA-NOMEACAO       PIC  X(010) VALUE ' '.*/
            public StringBasis WS_GE0530_DTA_NOMEACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" ");
            /*"    05  WS-GE0530-DTA-EXONERACAO     PIC  X(010) VALUE ' '.*/
            public StringBasis WS_GE0530_DTA_EXONERACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" ");
            /*"    05  WS-GE0530-NOM-MUNICIPIO-ORGAO PIC  X(040) VALUE ' '.*/
            public StringBasis WS_GE0530_NOM_MUNICIPIO_ORGAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @" ");
            /*"    05  WS-GE0530-COD-UF-ORGAO       PIC  X(002) VALUE ' '.*/
            public StringBasis WS_GE0530_COD_UF_ORGAO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" ");
            /*"    05  WS-GE0530-COD-USUARIO        PIC  X(008) VALUE ' '.*/
            public StringBasis WS_GE0530_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @" ");
            /*"    05  WS-GE0530-NOM-PROGRAMA       PIC  X(030) VALUE ' '.*/
            public StringBasis WS_GE0530_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @" ");
            /*"    05  WS-GE0530-DTH-CAD            PIC  X(026) VALUE ' '.*/
            public StringBasis WS_GE0530_DTH_CAD { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" ");
            /*"    05  WS-GE0530-DTH-CAD-RD  REDEFINES WS-GE0530-DTH-CAD.*/
            private _REDEF_GE0530S_WS_GE0530_DTH_CAD_RD _ws_ge0530_dth_cad_rd { get; set; }
            public _REDEF_GE0530S_WS_GE0530_DTH_CAD_RD WS_GE0530_DTH_CAD_RD
            {
                get { _ws_ge0530_dth_cad_rd = new _REDEF_GE0530S_WS_GE0530_DTH_CAD_RD(); _.Move(WS_GE0530_DTH_CAD, _ws_ge0530_dth_cad_rd); VarBasis.RedefinePassValue(WS_GE0530_DTH_CAD, _ws_ge0530_dth_cad_rd, WS_GE0530_DTH_CAD); _ws_ge0530_dth_cad_rd.ValueChanged += () => { _.Move(_ws_ge0530_dth_cad_rd, WS_GE0530_DTH_CAD); }; return _ws_ge0530_dth_cad_rd; }
                set { VarBasis.RedefinePassValue(value, _ws_ge0530_dth_cad_rd, WS_GE0530_DTH_CAD); }
            }  //Redefines
            public class _REDEF_GE0530S_WS_GE0530_DTH_CAD_RD : VarBasis
            {
                /*"        07  WS-GE0530-CAD-AA         PIC  X(004).*/
                public StringBasis WS_GE0530_CAD_AA { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"        07  WS-DT-SEPARADOR-1        PIC  X(001).*/
                public StringBasis WS_DT_SEPARADOR_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  WS-GE0530-CAD-MM         PIC  X(002).*/
                public StringBasis WS_GE0530_CAD_MM { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"        07  WS-DT-SEPARADOR-2        PIC  X(001).*/
                public StringBasis WS_DT_SEPARADOR_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  WS-GE0530-CAD-DD         PIC  X(002).*/
                public StringBasis WS_GE0530_CAD_DD { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"        07  FILLER                   PIC  X(016).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)."), @"");
                /*"01  WS-GDA-COD-PEPS-EXTERNO          PIC S9(009) COMP VALUE 0.*/

                public _REDEF_GE0530S_WS_GE0530_DTH_CAD_RD()
                {
                    WS_GE0530_CAD_AA.ValueChanged += OnValueChanged;
                    WS_DT_SEPARADOR_1.ValueChanged += OnValueChanged;
                    WS_GE0530_CAD_MM.ValueChanged += OnValueChanged;
                    WS_DT_SEPARADOR_2.ValueChanged += OnValueChanged;
                    WS_GE0530_CAD_DD.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                }

            }
        }
        public IntBasis WS_GDA_COD_PEPS_EXTERNO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  WS-GDA-COD-PEPS-RELAC            PIC S9(009) COMP VALUE 0.*/
        public IntBasis WS_GDA_COD_PEPS_RELAC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  WS-GDA-COD-RELACAO-INT           PIC S9(004) COMP VALUE 0.*/
        public IntBasis WS_GDA_COD_RELACAO_INT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WS-TIPO-SISTEMA                   PIC  X(001) VALUE 'N'.*/

        public SelectorBasis WS_TIPO_SISTEMA { get; set; } = new SelectorBasis("001", "N")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88  WS-SIAS-ONLINE                            VALUE 'S'. */
							new SelectorItemBasis("WS_SIAS_ONLINE", "S")
                }
        };

        /*"01  CTL-CURSOR-C001.*/
        public GE0530S_CTL_CURSOR_C001 CTL_CURSOR_C001 { get; set; } = new GE0530S_CTL_CURSOR_C001();
        public class GE0530S_CTL_CURSOR_C001 : VarBasis
        {
            /*"    05  CD-SQL-CURSOR-C001           PIC S9(004) COMP VALUE    0*/

            public SelectorBasis CD_SQL_CURSOR_C001 { get; set; } = new SelectorBasis("004", "0")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 FIM-CURSOR-C001                            VALUE +100 */
							new SelectorItemBasis("FIM_CURSOR_C001", "+100")
                }
            };

            /*"    05  IN-CURSOR-C001-ABTO          PIC  X(001) VALUE 'N'.*/

            public SelectorBasis IN_CURSOR_C001_ABTO { get; set; } = new SelectorBasis("001", "N")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 CURSOR-C001-ABTO                      VALUE 'S'. */
							new SelectorItemBasis("CURSOR_C001_ABTO", "S")
                }
            };

            /*"01  CTL-CURSOR-C002.*/
        }
        public GE0530S_CTL_CURSOR_C002 CTL_CURSOR_C002 { get; set; } = new GE0530S_CTL_CURSOR_C002();
        public class GE0530S_CTL_CURSOR_C002 : VarBasis
        {
            /*"    05  CD-SQL-CURSOR-C002           PIC S9(004) COMP VALUE    0*/

            public SelectorBasis CD_SQL_CURSOR_C002 { get; set; } = new SelectorBasis("004", "0")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 FIM-CURSOR-C002                            VALUE +100 */
							new SelectorItemBasis("FIM_CURSOR_C002", "+100")
                }
            };

            /*"    05  IN-CURSOR-C002-ABTO          PIC  X(001) VALUE 'N'.*/

            public SelectorBasis IN_CURSOR_C002_ABTO { get; set; } = new SelectorBasis("001", "N")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 CURSOR-C002-ABTO                      VALUE 'S'. */
							new SelectorItemBasis("CURSOR_C002_ABTO", "S")
                }
            };

        }


        public Copies.LBGE0531 LBGE0531 { get; set; } = new Copies.LBGE0531();
        public Copies.LBGE0530 LBGE0530 { get; set; } = new Copies.LBGE0530();
        public Dclgens.GE530 GE530 { get; set; } = new Dclgens.GE530();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();

        public GE0530S_C001 C001 { get; set; } = new GE0530S_C001(true);
        string GetQuery_C001()
        {
            var query = @$"SELECT SEQ_PEPS
							,DTA_INIVIG_PEPS
							,DTA_FIMVIG_PEPS
							,COD_TP_PEPS
							,COD_PEPS_EXTERNO
							,COD_PEPS_RELACIONADO
							,NUM_CPF_CNPJ
							,NOM_PEPS
							,COD_ORGAO_PESS_PEPS
							,NOM_ORGAO_PEPS
							,COD_CARGO
							,NOM_CARGO
							,COD_COAF
							,IND_SEXO
							,NOM_LOGRADOURO
							,DES_LOGRADOURO
							,DES_COMPLEMENTO
							,NOM_BAIRRO
							,COD_CEP
							,NOM_MUNICIPIO
							,COD_UF
							,DTA_NOMEACAO
							,DTA_EXONERACAO
							,NOM_MUNICIPIO_ORGAO
							,COD_UF_ORGAO
							,COD_USUARIO
							,NOM_PROGRAMA
							,DTH_CADASTRAMENTO
							FROM SIUS.GE_PEPS_PESSOA_EXPOSTA WHERE COD_PEPS_RELACIONADO = '{WS_GDA_COD_PEPS_EXTERNO}'";

            return query;
        }


        public GE0530S_C002 C002 { get; set; } = new GE0530S_C002(true);
        string GetQuery_C002()
        {
            var query = @$"SELECT SEQ_PEPS
							,DTA_INIVIG_PEPS
							,DTA_FIMVIG_PEPS
							,COD_TP_PEPS
							,COD_PEPS_EXTERNO
							,COD_PEPS_RELACIONADO
							,NUM_CPF_CNPJ
							,NOM_PEPS
							,COD_ORGAO_PESS_PEPS
							,NOM_ORGAO_PEPS
							,COD_CARGO
							,NOM_CARGO
							,COD_COAF
							,IND_SEXO
							,NOM_LOGRADOURO
							,DES_LOGRADOURO
							,DES_COMPLEMENTO
							,NOM_BAIRRO
							,COD_CEP
							,NOM_MUNICIPIO
							,COD_UF
							,DTA_NOMEACAO
							,DTA_EXONERACAO
							,NOM_MUNICIPIO_ORGAO
							,COD_UF_ORGAO
							,COD_USUARIO
							,NOM_PROGRAMA
							,DTH_CADASTRAMENTO
							FROM SIUS.GE_PEPS_PESSOA_EXPOSTA WHERE COD_PEPS_EXTERNO = '{WS_GDA_COD_PEPS_RELAC}'";

            return query;
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(LBGE0530_LK_GE0530 LBGE0530_LK_GE0530_P) //PROCEDURE DIVISION USING 
        /*LK_GE0530*/
        {
            try
            {
                this.LBGE0530.LK_GE0530 = LBGE0530_LK_GE0530_P;
                InitializeGetQuery();

                /*" -254- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -255- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -256- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -260- PERFORM R000-00-INFORMES. */

                R000_00_INFORMES_SECTION();

                /*" -262- PERFORM R1000-00-INICIO. */

                R1000_00_INICIO_SECTION();

                /*" -264- PERFORM R2000-00-PROCESSAR. */

                R2000_00_PROCESSAR_SECTION();

                /*" -264- PERFORM R3000-00-FINALIZAR. */

                R3000_00_FINALIZAR_SECTION();

                /*" -264- FLUXCONTROL_PERFORM R000-00-INFORMES-SECTION */

                R000_00_INFORMES_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LBGE0530.LK_GE0530 };
            return Result;
        }

        public void InitializeGetQuery()
        {
            C001.GetQueryEvent += GetQuery_C001;
            C002.GetQueryEvent += GetQuery_C002;
        }

        [StopWatch]
        /*" R000-00-INFORMES-SECTION */
        private void R000_00_INFORMES_SECTION()
        {
            /*" -272- MOVE 'R000-' TO WNR-EXEC-SQL */
            _.Move("R000-", WABEND.WABEND2.WNR_EXEC_SQL);

            /*" -273- DISPLAY ' ' */
            _.Display($" ");

            /*" -274- DISPLAY '***************************************************' */
            _.Display($"***************************************************");

            /*" -275- DISPLAY 'PROGRAMA GE0530S EM EXECUCAO' */
            _.Display($"PROGRAMA GE0530S EM EXECUCAO");

            /*" -282- DISPLAY 'COMPILADO EM ' FUNCTION WHEN-COMPILED(7:2) '/' FUNCTION WHEN-COMPILED(5:2) '/' FUNCTION WHEN-COMPILED(1:4) ' AS ' FUNCTION WHEN-COMPILED(9:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) ' *' */

            $"COMPILADO EM FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)} AS FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)} *"
            .Display();

            /*" -283- DISPLAY '***************************************************' */
            _.Display($"***************************************************");

            /*" -284- DISPLAY ' ' */
            _.Display($" ");

            /*" -291- DISPLAY '-->INICIOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) '<--' */

            $"-->INICIOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}<--"
            .Display();

            /*" -293- DISPLAY ' ' */
            _.Display($" ");

            /*" -294- MOVE FUNCTION WHEN-COMPILED(7:2) TO WS-DIA-DB2 */
            _.Move(_.WhenCompiled(7, 2), WS_DATA_DB2.WS_DIA_DB2);

            /*" -295- MOVE FUNCTION WHEN-COMPILED(5:2) TO WS-MES-DB2 */
            _.Move(_.WhenCompiled(5, 2), WS_DATA_DB2.WS_MES_DB2);

            /*" -296- MOVE FUNCTION WHEN-COMPILED(1:4) TO WS-ANO-DB2 */
            _.Move(_.WhenCompiled(1, 4), WS_DATA_DB2.WS_ANO_DB2);

            /*" -297- DISPLAY 'DATA DB2:' WS-DATA-DB2 */
            _.Display($"DATA DB2:{WS_DATA_DB2}");

            /*" -297- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R000_99_EXIT*/

        [StopWatch]
        /*" R1000-00-INICIO-SECTION */
        private void R1000_00_INICIO_SECTION()
        {
            /*" -318- MOVE 'R1000-00' TO WNR-EXEC-SQL WS-PARAGRAFO */
            _.Move("R1000-00", WABEND.WABEND2.WNR_EXEC_SQL, WS_PARAGRAFO);

            /*" -319- DISPLAY 'R1000-GE0530S - !!!!!!! INICIO ' */
            _.Display($"R1000-GE0530S - !!!!!!! INICIO ");

            /*" -320- DISPLAY 'LK-GE0530-FUN :' LK-GE0530-FUNCAO */
            _.Display($"LK-GE0530-FUN :{LBGE0530.LK_GE0530.LK_GE0530_FUNCAO}");

            /*" -321- DISPLAY 'NUM-CNPJ      :' LK-GE0530-CPF-CNPJ */
            _.Display($"NUM-CNPJ      :{LBGE0530.LK_GE0530.LK_GE0530_CPF_CNPJ}");

            /*" -322- DISPLAY 'NOM-FANTASIA  :' LK-GE0530-NOME-PESSOA */
            _.Display($"NOM-FANTASIA  :{LBGE0530.LK_GE0530.LK_GE0530_NOME_PESSOA}");

            /*" -323- DISPLAY 'RAMO-EMISSOR  :' LK-GE0530-NUM-RAMO-EMISSOR */
            _.Display($"RAMO-EMISSOR  :{LBGE0530.LK_GE0530.LK_GE0530_NUM_RAMO_EMISSOR}");

            /*" -324- DISPLAY 'COD-PRODUTO   :' LK-GE0530-COD-PRODUTO */
            _.Display($"COD-PRODUTO   :{LBGE0530.LK_GE0530.LK_GE0530_COD_PRODUTO}");

            /*" -325- DISPLAY 'COD-FONTE     :' LK-GE0530-COD-FONTE */
            _.Display($"COD-FONTE     :{LBGE0530.LK_GE0530.LK_GE0530_COD_FONTE}");

            /*" -326- DISPLAY 'PROPOSTA      :' LK-GE0530-NUM-PROPOSTA */
            _.Display($"PROPOSTA      :{LBGE0530.LK_GE0530.LK_GE0530_NUM_PROPOSTA}");

            /*" -327- DISPLAY 'COD-CLIENTE   :' LK-GE0530-NUM-CERTIFIC-EXT */
            _.Display($"COD-CLIENTE   :{LBGE0530.LK_GE0530.LK_GE0530_NUM_CERTIFIC_EXT}");

            /*" -328- DISPLAY 'PROGRAMA      :' LK-GE0530-NOM-PRG-SOLICITA */
            _.Display($"PROGRAMA      :{LBGE0530.LK_GE0530.LK_GE0530_NOM_PRG_SOLICITA}");

            /*" -330- DISPLAY '                     ' */
            _.Display($"                     ");

            /*" -332- PERFORM R1200-00-DATA-SISTEMA */

            R1200_00_DATA_SISTEMA_SECTION();

            /*" -333- EVALUATE LK-GE0530-FUNCAO */
            switch (LBGE0530.LK_GE0530.LK_GE0530_FUNCAO.Value.Trim())
            {

                /*" -334- WHEN  'LT1' */
                case "LT1":

                    /*" -335- WHEN  'LT2' */
                    break;
                case "LT2":

                    /*" -336- PERFORM R1500-00-VALIDA-ENTRADA-LOT */

                    R1500_00_VALIDA_ENTRADA_LOT_SECTION();

                    /*" -337- WHEN OTHER */
                    break;
                default:

                    /*" -338- MOVE 01 TO LK-GE0530-COD-RETORNO */
                    _.Move(01, LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_COD_RETORNO);

                    /*" -340- MOVE 'GE0530S: R1000-CODIGO DE FUNCAO INVALIDO' TO LK-GE0530-MSG-RETORNO */
                    _.Move("GE0530S: R1000-CODIGO DE FUNCAO INVALIDO", LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_MSG_RETORNO);

                    /*" -341- PERFORM R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION();

                    /*" -343- END-EVALUATE */
                    break;
            }


            /*" -343- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-DATA-SISTEMA-SECTION */
        private void R1200_00_DATA_SISTEMA_SECTION()
        {
            /*" -354- MOVE 'R1200-00' TO WS-PARAGRAFO WNR-EXEC-SQL */
            _.Move("R1200-00", WS_PARAGRAFO, WABEND.WABEND2.WNR_EXEC_SQL);

            /*" -360- PERFORM R1200_00_DATA_SISTEMA_DB_SELECT_1 */

            R1200_00_DATA_SISTEMA_DB_SELECT_1();

            /*" -364- MOVE SQLCODE TO WS-SQLCODE */
            _.Move(DB.SQLCODE, WS_SQLCODE);

            /*" -365- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -366- DISPLAY 'PROBLEMAS NO SELECT - SISTEMAS' */
                _.Display($"PROBLEMAS NO SELECT - SISTEMAS");

                /*" -367- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -369- END-IF */
            }


            /*" -370- DISPLAY ' DATA MOVIMENTO ABERTO...:' SISTEMAS-DATA-MOV-ABERTO */
            _.Display($" DATA MOVIMENTO ABERTO...:{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -370- . */

        }

        [StopWatch]
        /*" R1200-00-DATA-SISTEMA-DB-SELECT-1 */
        public void R1200_00_DATA_SISTEMA_DB_SELECT_1()
        {
            /*" -360- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'LT' WITH UR END-EXEC. */

            var r1200_00_DATA_SISTEMA_DB_SELECT_1_Query1 = new R1200_00_DATA_SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R1200_00_DATA_SISTEMA_DB_SELECT_1_Query1.Execute(r1200_00_DATA_SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-VALIDA-ENTRADA-LOT-SECTION */
        private void R1500_00_VALIDA_ENTRADA_LOT_SECTION()
        {
            /*" -382- MOVE 'R1500-00' TO WS-PARAGRAFO WNR-EXEC-SQL */
            _.Move("R1500-00", WS_PARAGRAFO, WABEND.WABEND2.WNR_EXEC_SQL);

            /*" -383- IF LK-GE0530-CPF-CNPJ EQUAL ZEROS */

            if (LBGE0530.LK_GE0530.LK_GE0530_CPF_CNPJ == 00)
            {

                /*" -384- MOVE 02 TO LK-GE0530-COD-RETORNO */
                _.Move(02, LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_COD_RETORNO);

                /*" -386- MOVE 'GE0530S: CPF ou CNPJ - invalido.' TO LK-GE0530-MSG-RETORNO */
                _.Move("GE0530S: CPF ou CNPJ - invalido.", LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_MSG_RETORNO);

                /*" -387- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -389- END-IF */
            }


            /*" -390- IF LK-GE0530-COD-FONTE EQUAL ZEROS */

            if (LBGE0530.LK_GE0530.LK_GE0530_COD_FONTE == 00)
            {

                /*" -391- MOVE 03 TO LK-GE0530-COD-RETORNO */
                _.Move(03, LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_COD_RETORNO);

                /*" -393- MOVE 'GE0530S: Codigo fonte - invalido.' TO LK-GE0530-MSG-RETORNO */
                _.Move("GE0530S: Codigo fonte - invalido.", LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_MSG_RETORNO);

                /*" -394- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -396- END-IF */
            }


            /*" -397- IF LK-GE0530-COD-PRODUTO IS NOT NUMERIC */

            if (!LBGE0530.LK_GE0530.LK_GE0530_COD_PRODUTO.IsNumeric())
            {

                /*" -398- MOVE 04 TO LK-GE0530-COD-RETORNO */
                _.Move(04, LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_COD_RETORNO);

                /*" -400- MOVE 'GE0530S: Codigo do produto - invalido.' TO LK-GE0530-MSG-RETORNO */
                _.Move("GE0530S: Codigo do produto - invalido.", LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_MSG_RETORNO);

                /*" -401- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -403- END-IF */
            }


            /*" -404- IF LK-GE0530-COD-PRODUTO EQUAL ZEROS */

            if (LBGE0530.LK_GE0530.LK_GE0530_COD_PRODUTO == 00)
            {

                /*" -405- MOVE 05 TO LK-GE0530-COD-RETORNO */
                _.Move(05, LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_COD_RETORNO);

                /*" -407- MOVE 'GE0530S: Codigo do produto - zerado.' TO LK-GE0530-MSG-RETORNO */
                _.Move("GE0530S: Codigo do produto - zerado.", LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_MSG_RETORNO);

                /*" -408- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -410- END-IF */
            }


            /*" -411- IF LK-GE0530-NUM-RAMO-EMISSOR IS NOT NUMERIC */

            if (!LBGE0530.LK_GE0530.LK_GE0530_NUM_RAMO_EMISSOR.IsNumeric())
            {

                /*" -412- MOVE 06 TO LK-GE0530-COD-RETORNO */
                _.Move(06, LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_COD_RETORNO);

                /*" -414- MOVE 'GE0530S: Ramo emissor - invalido.' TO LK-GE0530-MSG-RETORNO */
                _.Move("GE0530S: Ramo emissor - invalido.", LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_MSG_RETORNO);

                /*" -415- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -417- END-IF */
            }


            /*" -418- IF LK-GE0530-NUM-RAMO-EMISSOR EQUAL ZEROS */

            if (LBGE0530.LK_GE0530.LK_GE0530_NUM_RAMO_EMISSOR == 00)
            {

                /*" -419- MOVE 07 TO LK-GE0530-COD-RETORNO */
                _.Move(07, LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_COD_RETORNO);

                /*" -421- MOVE 'GE0530S: Ramo emissor - zerado.' TO LK-GE0530-MSG-RETORNO */
                _.Move("GE0530S: Ramo emissor - zerado.", LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_MSG_RETORNO);

                /*" -422- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -424- END-IF */
            }


            /*" -425- IF LK-GE0530-NUM-PROPOSTA EQUAL ZEROS */

            if (LBGE0530.LK_GE0530.LK_GE0530_NUM_PROPOSTA == 00)
            {

                /*" -426- MOVE 08 TO LK-GE0530-COD-RETORNO */
                _.Move(08, LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_COD_RETORNO);

                /*" -428- MOVE 'GE0530S - Proposta invalida.' TO LK-GE0530-MSG-RETORNO */
                _.Move("GE0530S - Proposta invalida.", LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_MSG_RETORNO);

                /*" -429- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -431- END-IF */
            }


            /*" -432- IF LK-GE0530-NUM-CERTIFIC-EXT IS NOT NUMERIC */

            if (!LBGE0530.LK_GE0530.LK_GE0530_NUM_CERTIFIC_EXT.IsNumeric())
            {

                /*" -433- MOVE 09 TO LK-GE0530-COD-RETORNO */
                _.Move(09, LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_COD_RETORNO);

                /*" -435- MOVE 'GE0530S - Codigo cliente - invalido.' TO LK-GE0530-MSG-RETORNO */
                _.Move("GE0530S - Codigo cliente - invalido.", LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_MSG_RETORNO);

                /*" -436- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -438- END-IF */
            }


            /*" -439- IF LK-GE0530-NUM-CERTIFIC-EXT EQUAL ZEROS */

            if (LBGE0530.LK_GE0530.LK_GE0530_NUM_CERTIFIC_EXT == 00)
            {

                /*" -440- MOVE 10 TO LK-GE0530-COD-RETORNO */
                _.Move(10, LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_COD_RETORNO);

                /*" -442- MOVE 'GE0530S - Codigo cliente - zerado.' TO LK-GE0530-MSG-RETORNO */
                _.Move("GE0530S - Codigo cliente - zerado.", LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_MSG_RETORNO);

                /*" -443- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -445- END-IF */
            }


            /*" -445- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-PROCESSAR-SECTION */
        private void R2000_00_PROCESSAR_SECTION()
        {
            /*" -466- MOVE 'R2000-00' TO WNR-EXEC-SQL WS-PARAGRAFO */
            _.Move("R2000-00", WABEND.WABEND2.WNR_EXEC_SQL, WS_PARAGRAFO);

            /*" -467- EVALUATE LK-GE0530-FUNCAO */
            switch (LBGE0530.LK_GE0530.LK_GE0530_FUNCAO.Value.Trim())
            {

                /*" -470- WHEN  'LT1' */
                case "LT1":

                    /*" -471- PERFORM R2100-00-CONSULTAR-PEP */

                    R2100_00_CONSULTAR_PEP_SECTION();

                    /*" -472- WHEN  'LT2' */
                    break;
                case "LT2":

                    /*" -473- PERFORM R2100-00-CONSULTAR-PEP */

                    R2100_00_CONSULTAR_PEP_SECTION();

                    /*" -474- PERFORM R2110-00-GRAVAR-LOG */

                    R2110_00_GRAVAR_LOG_SECTION();

                    /*" -476- END-EVALUATE */
                    break;
            }


            /*" -476- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2110-00-GRAVAR-LOG-SECTION */
        private void R2110_00_GRAVAR_LOG_SECTION()
        {
            /*" -488- MOVE 'R2110-00' TO WNR-EXEC-SQL WS-PARAGRAFO */
            _.Move("R2110-00", WABEND.WABEND2.WNR_EXEC_SQL, WS_PARAGRAFO);

            /*" -489- EVALUATE LK-GE0530-NOM-PRG-SOLICITA */
            switch (LBGE0530.LK_GE0530.LK_GE0530_NOM_PRG_SOLICITA.Value.Trim())
            {

                /*" -490- WHEN 'SI0005B' */
                case "SI0005B":

                    /*" -491- WHEN 'SI6BA' */
                    break;
                case "SI6BA":

                /*" -492- WHEN 'SI6EA' */
                case "SI6EA":

                    /*" -493- MOVE 3 TO WS-GDA-COD-RELACAO-INT */
                    _.Move(3, WS_GDA_COD_RELACAO_INT);

                    /*" -494- WHEN OTHER */
                    break;
                default:

                    /*" -495- MOVE 2 TO WS-GDA-COD-RELACAO-INT */
                    _.Move(2, WS_GDA_COD_RELACAO_INT);

                    /*" -497- END-EVALUATE */
                    break;
            }


            /*" -517- PERFORM R2200-00-GRAVAR-LOG */

            R2200_00_GRAVAR_LOG_SECTION();

            /*" -518- IF WS-GE0530-COD-TP-PEPS EQUAL 110 */

            if (WS_GE0530_PEPS.WS_GE0530_COD_TP_PEPS == 110)
            {

                /*" -519- MOVE WS-GE0530-COD-PEPS-EXTERNO TO WS-GDA-COD-PEPS-EXTERNO */
                _.Move(WS_GE0530_PEPS.WS_GE0530_COD_PEPS_EXTERNO, WS_GDA_COD_PEPS_EXTERNO);

                /*" -520- PERFORM R2300-CONS-RLC-TIT-PEP */

                R2300_CONS_RLC_TIT_PEP_SECTION();

                /*" -521- ELSE */
            }
            else
            {


                /*" -523- IF (WS-GE0530-COD-TP-PEPS EQUAL 140) AND (WS-GE0530-COD-PEPS-RELAC GREATER 0 ) */

                if ((WS_GE0530_PEPS.WS_GE0530_COD_TP_PEPS == 140) && (WS_GE0530_PEPS.WS_GE0530_COD_PEPS_RELAC > 0))
                {

                    /*" -524- MOVE WS-GE0530-COD-PEPS-RELAC TO WS-GDA-COD-PEPS-RELAC */
                    _.Move(WS_GE0530_PEPS.WS_GE0530_COD_PEPS_RELAC, WS_GDA_COD_PEPS_RELAC);

                    /*" -525- PERFORM R2400-CONS-RLC-TIT-PEP */

                    R2400_CONS_RLC_TIT_PEP_SECTION();

                    /*" -526- END-IF */
                }


                /*" -527- END-IF */
            }


            /*" -527- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2110_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-CONSULTAR-PEP-SECTION */
        private void R2100_00_CONSULTAR_PEP_SECTION()
        {
            /*" -537- MOVE 'R2100-00' TO WS-PARAGRAFO WNR-EXEC-SQL */
            _.Move("R2100-00", WS_PARAGRAFO, WABEND.WABEND2.WNR_EXEC_SQL);

            /*" -538- MOVE ZEROS TO GE530-NUM-CPF-CNPJ */
            _.Move(0, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_NUM_CPF_CNPJ);

            /*" -540- MOVE LK-GE0530-CPF-CNPJ TO GE530-NUM-CPF-CNPJ */
            _.Move(LBGE0530.LK_GE0530.LK_GE0530_CPF_CNPJ, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_NUM_CPF_CNPJ);

            /*" -542- DISPLAY 'R2100-00-CONSULTAR-PEP - INICIO' */
            _.Display($"R2100-00-CONSULTAR-PEP - INICIO");

            /*" -605- PERFORM R2100_00_CONSULTAR_PEP_DB_SELECT_1 */

            R2100_00_CONSULTAR_PEP_DB_SELECT_1();

            /*" -608- EVALUATE SQLCODE */
            switch (DB.SQLCODE.Value)
            {

                /*" -609- WHEN +0 */
                case +0:

                    /*" -610- MOVE 'S' TO LK-GE0530-IND-RESTRICAO */
                    _.Move("S", LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_IND_RESTRICAO);

                    /*" -611- DISPLAY 'R2100-ACHEI PEP....' */
                    _.Display($"R2100-ACHEI PEP....");

                    /*" -612- DISPLAY 'VOU GUARDAR DADOS..' */
                    _.Display($"VOU GUARDAR DADOS..");

                    /*" -613- PERFORM R2150-00-GRAVAR-DADOS-PEP */

                    R2150_00_GRAVAR_DADOS_PEP_SECTION();

                    /*" -614- WHEN +100 */
                    break;
                case +100:

                    /*" -615- MOVE 'N' TO LK-GE0530-IND-RESTRICAO */
                    _.Move("N", LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_IND_RESTRICAO);

                    /*" -616- DISPLAY 'R2100-NAO ACHEI PEP........' */
                    _.Display($"R2100-NAO ACHEI PEP........");

                    /*" -617- WHEN OTHER */
                    break;
                default:

                    /*" -618- DISPLAY 'R2100-ERRO DB2 NA CONSULTA PEP....' */
                    _.Display($"R2100-ERRO DB2 NA CONSULTA PEP....");

                    /*" -619- MOVE 15 TO LK-GE0530-COD-RETORNO */
                    _.Move(15, LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_COD_RETORNO);

                    /*" -621- MOVE 'GE0530S-Erro select GE_PEPS_PESSOA_EXPOSTA.' TO LK-GE0530-MSG-RETORNO */
                    _.Move("GE0530S-Erro select GE_PEPS_PESSOA_EXPOSTA.", LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_MSG_RETORNO);

                    /*" -622- PERFORM R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION();

                    /*" -624- END-EVALUATE */
                    break;
            }


            /*" -624- . */

        }

        [StopWatch]
        /*" R2100-00-CONSULTAR-PEP-DB-SELECT-1 */
        public void R2100_00_CONSULTAR_PEP_DB_SELECT_1()
        {
            /*" -605- EXEC SQL SELECT SEQ_PEPS ,DTA_INIVIG_PEPS ,DTA_FIMVIG_PEPS ,COD_TP_PEPS ,COD_PEPS_EXTERNO ,COD_PEPS_RELACIONADO ,NUM_CPF_CNPJ ,NOM_PEPS ,COD_ORGAO_PESS_PEPS ,NOM_ORGAO_PEPS ,COD_CARGO ,NOM_CARGO ,COD_COAF ,IND_SEXO ,NOM_LOGRADOURO ,DES_LOGRADOURO ,DES_COMPLEMENTO ,NOM_BAIRRO ,COD_CEP ,NOM_MUNICIPIO ,COD_UF ,DTA_NOMEACAO ,DTA_EXONERACAO ,NOM_MUNICIPIO_ORGAO ,COD_UF_ORGAO ,COD_USUARIO ,NOM_PROGRAMA ,DTH_CADASTRAMENTO INTO :GE530-SEQ-PEPS ,:GE530-DTA-INIVIG-PEPS ,:GE530-DTA-FIMVIG-PEPS ,:GE530-COD-TP-PEPS ,:GE530-COD-PEPS-EXTERNO ,:GE530-COD-PEPS-RELACIONADO ,:GE530-NUM-CPF-CNPJ ,:GE530-NOM-PEPS ,:GE530-COD-ORGAO-PESS-PEPS ,:GE530-NOM-ORGAO-PEPS ,:GE530-COD-CARGO ,:GE530-NOM-CARGO ,:GE530-COD-COAF ,:GE530-IND-SEXO ,:GE530-NOM-LOGRADOURO ,:GE530-DES-LOGRADOURO ,:GE530-DES-COMPLEMENTO ,:GE530-NOM-BAIRRO ,:GE530-COD-CEP ,:GE530-NOM-MUNICIPIO ,:GE530-COD-UF ,:GE530-DTA-NOMEACAO ,:GE530-DTA-EXONERACAO ,:GE530-NOM-MUNICIPIO-ORGAO ,:GE530-COD-UF-ORGAO ,:GE530-COD-USUARIO ,:GE530-NOM-PROGRAMA ,:GE530-DTH-CADASTRAMENTO FROM SIUS.GE_PEPS_PESSOA_EXPOSTA WHERE NUM_CPF_CNPJ = :GE530-NUM-CPF-CNPJ AND DTA_FIMVIG_PEPS > :SISTEMAS-DATA-MOV-ABERTO ORDER BY DTH_CADASTRAMENTO DESC FETCH FIRST ROWS ONLY WITH UR END-EXEC. */

            var r2100_00_CONSULTAR_PEP_DB_SELECT_1_Query1 = new R2100_00_CONSULTAR_PEP_DB_SELECT_1_Query1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                GE530_NUM_CPF_CNPJ = GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_NUM_CPF_CNPJ.ToString(),
            };

            var executed_1 = R2100_00_CONSULTAR_PEP_DB_SELECT_1_Query1.Execute(r2100_00_CONSULTAR_PEP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE530_SEQ_PEPS, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_SEQ_PEPS);
                _.Move(executed_1.GE530_DTA_INIVIG_PEPS, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_DTA_INIVIG_PEPS);
                _.Move(executed_1.GE530_DTA_FIMVIG_PEPS, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_DTA_FIMVIG_PEPS);
                _.Move(executed_1.GE530_COD_TP_PEPS, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_COD_TP_PEPS);
                _.Move(executed_1.GE530_COD_PEPS_EXTERNO, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_COD_PEPS_EXTERNO);
                _.Move(executed_1.GE530_COD_PEPS_RELACIONADO, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_COD_PEPS_RELACIONADO);
                _.Move(executed_1.GE530_NUM_CPF_CNPJ, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_NUM_CPF_CNPJ);
                _.Move(executed_1.GE530_NOM_PEPS, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_NOM_PEPS);
                _.Move(executed_1.GE530_COD_ORGAO_PESS_PEPS, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_COD_ORGAO_PESS_PEPS);
                _.Move(executed_1.GE530_NOM_ORGAO_PEPS, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_NOM_ORGAO_PEPS);
                _.Move(executed_1.GE530_COD_CARGO, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_COD_CARGO);
                _.Move(executed_1.GE530_NOM_CARGO, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_NOM_CARGO);
                _.Move(executed_1.GE530_COD_COAF, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_COD_COAF);
                _.Move(executed_1.GE530_IND_SEXO, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_IND_SEXO);
                _.Move(executed_1.GE530_NOM_LOGRADOURO, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_NOM_LOGRADOURO);
                _.Move(executed_1.GE530_DES_LOGRADOURO, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_DES_LOGRADOURO);
                _.Move(executed_1.GE530_DES_COMPLEMENTO, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_DES_COMPLEMENTO);
                _.Move(executed_1.GE530_NOM_BAIRRO, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_NOM_BAIRRO);
                _.Move(executed_1.GE530_COD_CEP, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_COD_CEP);
                _.Move(executed_1.GE530_NOM_MUNICIPIO, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_NOM_MUNICIPIO);
                _.Move(executed_1.GE530_COD_UF, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_COD_UF);
                _.Move(executed_1.GE530_DTA_NOMEACAO, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_DTA_NOMEACAO);
                _.Move(executed_1.GE530_DTA_EXONERACAO, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_DTA_EXONERACAO);
                _.Move(executed_1.GE530_NOM_MUNICIPIO_ORGAO, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_NOM_MUNICIPIO_ORGAO);
                _.Move(executed_1.GE530_COD_UF_ORGAO, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_COD_UF_ORGAO);
                _.Move(executed_1.GE530_COD_USUARIO, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_COD_USUARIO);
                _.Move(executed_1.GE530_NOM_PROGRAMA, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_NOM_PROGRAMA);
                _.Move(executed_1.GE530_DTH_CADASTRAMENTO, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_DTH_CADASTRAMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2150-00-GRAVAR-DADOS-PEP-SECTION */
        private void R2150_00_GRAVAR_DADOS_PEP_SECTION()
        {
            /*" -637- MOVE 'R2150-00' TO WS-PARAGRAFO WNR-EXEC-SQL */
            _.Move("R2150-00", WS_PARAGRAFO, WABEND.WABEND2.WNR_EXEC_SQL);

            /*" -639- DISPLAY 'R2150-00-GRAVAR-DADOS-PEP !!!!!!!' */
            _.Display($"R2150-00-GRAVAR-DADOS-PEP !!!!!!!");

            /*" -642- INITIALIZE WS-GE0530-PEPS */
            _.Initialize(
                WS_GE0530_PEPS
            );

            /*" -643- MOVE GE530-SEQ-PEPS TO WS-GE0530-SEQ-PEPS */
            _.Move(GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_SEQ_PEPS, WS_GE0530_PEPS.WS_GE0530_SEQ_PEPS);

            /*" -644- MOVE GE530-DTA-INIVIG-PEPS TO WS-GE0530-DTA-INIVIG-PEPS */
            _.Move(GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_DTA_INIVIG_PEPS, WS_GE0530_PEPS.WS_GE0530_DTA_INIVIG_PEPS);

            /*" -645- MOVE GE530-DTA-FIMVIG-PEPS TO WS-GE0530-DTA-FIMVIG-PEPS */
            _.Move(GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_DTA_FIMVIG_PEPS, WS_GE0530_PEPS.WS_GE0530_DTA_FIMVIG_PEPS);

            /*" -647- MOVE GE530-COD-TP-PEPS TO WS-GE0530-COD-TP-PEPS */
            _.Move(GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_COD_TP_PEPS, WS_GE0530_PEPS.WS_GE0530_COD_TP_PEPS);

            /*" -650- MOVE GE530-COD-PEPS-EXTERNO TO WS-GE0530-COD-PEPS-EXTERNO */
            _.Move(GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_COD_PEPS_EXTERNO, WS_GE0530_PEPS.WS_GE0530_COD_PEPS_EXTERNO);

            /*" -653- MOVE GE530-COD-PEPS-RELACIONADO TO WS-GE0530-COD-PEPS-RELAC */
            _.Move(GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_COD_PEPS_RELACIONADO, WS_GE0530_PEPS.WS_GE0530_COD_PEPS_RELAC);

            /*" -654- MOVE GE530-NUM-CPF-CNPJ TO WS-GE0530-NUM-CPF-CNPJ */
            _.Move(GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_NUM_CPF_CNPJ, WS_GE0530_PEPS.WS_GE0530_NUM_CPF_CNPJ);

            /*" -656- MOVE GE530-NOM-PEPS TO WS-GE0530-NOM-PEPS */
            _.Move(GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_NOM_PEPS, WS_GE0530_PEPS.WS_GE0530_NOM_PEPS);

            /*" -659- MOVE GE530-COD-ORGAO-PESS-PEPS TO WS-GE0530-COD-ORGAO-PEPS */
            _.Move(GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_COD_ORGAO_PESS_PEPS, WS_GE0530_PEPS.WS_GE0530_COD_ORGAO_PEPS);

            /*" -660- MOVE GE530-NOM-ORGAO-PEPS TO WS-GE0530-NOM-ORGAO-PEPS */
            _.Move(GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_NOM_ORGAO_PEPS, WS_GE0530_PEPS.WS_GE0530_NOM_ORGAO_PEPS);

            /*" -661- MOVE GE530-COD-CARGO TO WS-GE0530-COD-CARGO */
            _.Move(GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_COD_CARGO, WS_GE0530_PEPS.WS_GE0530_COD_CARGO);

            /*" -662- MOVE GE530-NOM-CARGO TO WS-GE0530-NOM-CARGO */
            _.Move(GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_NOM_CARGO, WS_GE0530_PEPS.WS_GE0530_NOM_CARGO);

            /*" -663- MOVE GE530-COD-COAF TO WS-GE0530-COD-COAF */
            _.Move(GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_COD_COAF, WS_GE0530_PEPS.WS_GE0530_COD_COAF);

            /*" -664- MOVE GE530-IND-SEXO TO WS-GE0530-IND-SEXO */
            _.Move(GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_IND_SEXO, WS_GE0530_PEPS.WS_GE0530_IND_SEXO);

            /*" -665- MOVE GE530-NOM-LOGRADOURO TO WS-GE0530-NOM-LOGRADOURO */
            _.Move(GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_NOM_LOGRADOURO, WS_GE0530_PEPS.WS_GE0530_NOM_LOGRADOURO);

            /*" -666- MOVE GE530-DES-LOGRADOURO TO WS-GE0530-DES-LOGRADOURO */
            _.Move(GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_DES_LOGRADOURO, WS_GE0530_PEPS.WS_GE0530_DES_LOGRADOURO);

            /*" -667- MOVE GE530-DES-COMPLEMENTO TO WS-GE0530-DES-COMPLEMENTO */
            _.Move(GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_DES_COMPLEMENTO, WS_GE0530_PEPS.WS_GE0530_DES_COMPLEMENTO);

            /*" -668- MOVE GE530-NOM-BAIRRO TO WS-GE0530-NOM-BAIRRO */
            _.Move(GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_NOM_BAIRRO, WS_GE0530_PEPS.WS_GE0530_NOM_BAIRRO);

            /*" -669- MOVE GE530-COD-CEP TO WS-GE0530-COD-CEP */
            _.Move(GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_COD_CEP, WS_GE0530_PEPS.WS_GE0530_COD_CEP);

            /*" -670- MOVE GE530-NOM-MUNICIPIO TO WS-GE0530-NOM-MUNICIPIO */
            _.Move(GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_NOM_MUNICIPIO, WS_GE0530_PEPS.WS_GE0530_NOM_MUNICIPIO);

            /*" -671- MOVE GE530-COD-UF TO WS-GE0530-COD-UF */
            _.Move(GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_COD_UF, WS_GE0530_PEPS.WS_GE0530_COD_UF);

            /*" -672- MOVE GE530-DTA-NOMEACAO TO WS-GE0530-DTA-NOMEACAO */
            _.Move(GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_DTA_NOMEACAO, WS_GE0530_PEPS.WS_GE0530_DTA_NOMEACAO);

            /*" -674- MOVE GE530-DTA-EXONERACAO TO WS-GE0530-DTA-EXONERACAO */
            _.Move(GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_DTA_EXONERACAO, WS_GE0530_PEPS.WS_GE0530_DTA_EXONERACAO);

            /*" -678- MOVE GE530-NOM-MUNICIPIO-ORGAO TO WS-GE0530-NOM-MUNICIPIO-ORGAO LK-GE0530-CIDADE */
            _.Move(GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_NOM_MUNICIPIO_ORGAO, WS_GE0530_PEPS.WS_GE0530_NOM_MUNICIPIO_ORGAO, LBGE0530.LK_GE0530.LK_GE0530_RELATORIOS.LK_GE0530_CIDADE);

            /*" -680- MOVE GE530-COD-UF-ORGAO TO WS-GE0530-COD-UF-ORGAO LK-GE0530-UF */
            _.Move(GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_COD_UF_ORGAO, WS_GE0530_PEPS.WS_GE0530_COD_UF_ORGAO, LBGE0530.LK_GE0530.LK_GE0530_RELATORIOS.LK_GE0530_UF);

            /*" -681- MOVE GE530-COD-USUARIO TO WS-GE0530-COD-USUARIO */
            _.Move(GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_COD_USUARIO, WS_GE0530_PEPS.WS_GE0530_COD_USUARIO);

            /*" -682- MOVE GE530-NOM-PROGRAMA TO WS-GE0530-NOM-PROGRAMA */
            _.Move(GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_NOM_PROGRAMA, WS_GE0530_PEPS.WS_GE0530_NOM_PROGRAMA);

            /*" -683- MOVE GE530-DTH-CADASTRAMENTO TO WS-GE0530-DTH-CAD */
            _.Move(GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_DTH_CADASTRAMENTO, WS_GE0530_PEPS.WS_GE0530_DTH_CAD);

            /*" -686- MOVE '-' TO WS-DT-SEPARADOR-1 WS-DT-SEPARADOR-2 */
            _.Move("-", WS_GE0530_PEPS.WS_GE0530_DTH_CAD_RD.WS_DT_SEPARADOR_1);
            _.Move("-", WS_GE0530_PEPS.WS_GE0530_DTH_CAD_RD.WS_DT_SEPARADOR_2);


            /*" -686- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2150_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-GRAVAR-LOG-SECTION */
        private void R2200_00_GRAVAR_LOG_SECTION()
        {
            /*" -700- MOVE 'R2200-00' TO WS-PARAGRAFO WNR-EXEC-SQL */
            _.Move("R2200-00", WS_PARAGRAFO, WABEND.WABEND2.WNR_EXEC_SQL);

            /*" -702- INITIALIZE LK-GE0531 */
            _.Initialize(
                LBGE0531.LK_GE0531
            );

            /*" -705- DISPLAY 'R2200-00-GRAVAR-LOG..........' */
            _.Display($"R2200-00-GRAVAR-LOG..........");

            /*" -706- MOVE LK-GE0530-CPF-CNPJ TO LK-GE0531-CPF-CNPJ */
            _.Move(LBGE0530.LK_GE0530.LK_GE0530_CPF_CNPJ, LBGE0531.LK_GE0531.LK_GE0531_CPF_CNPJ);

            /*" -707- MOVE LK-GE0530-NOME-PESSOA TO LK-GE0531-NOM-SEGURADO */
            _.Move(LBGE0530.LK_GE0530.LK_GE0530_NOME_PESSOA, LBGE0531.LK_GE0531.LK_GE0531_NOM_SEGURADO);

            /*" -708- MOVE LK-GE0530-NUM-RAMO-EMISSOR TO LK-GE0531-NUM-RAMO-EMISSOR */
            _.Move(LBGE0530.LK_GE0530.LK_GE0530_NUM_RAMO_EMISSOR, LBGE0531.LK_GE0531.LK_GE0531_NUM_RAMO_EMISSOR);

            /*" -709- MOVE LK-GE0530-COD-PRODUTO TO LK-GE0531-COD-PRODUTO */
            _.Move(LBGE0530.LK_GE0530.LK_GE0530_COD_PRODUTO, LBGE0531.LK_GE0531.LK_GE0531_COD_PRODUTO);

            /*" -710- MOVE LK-GE0530-COD-FONTE TO LK-GE0531-COD-FONTE */
            _.Move(LBGE0530.LK_GE0530.LK_GE0530_COD_FONTE, LBGE0531.LK_GE0531.LK_GE0531_COD_FONTE);

            /*" -711- MOVE LK-GE0530-NUM-PROPOSTA TO LK-GE0531-NUM-PROPOSTA */
            _.Move(LBGE0530.LK_GE0530.LK_GE0530_NUM_PROPOSTA, LBGE0531.LK_GE0531.LK_GE0531_NUM_PROPOSTA);

            /*" -712- MOVE LK-GE0530-NUM-CERTIFIC-EXT TO LK-GE0531-NUM-CERTIFIC-EXT */
            _.Move(LBGE0530.LK_GE0530.LK_GE0530_NUM_CERTIFIC_EXT, LBGE0531.LK_GE0531.LK_GE0531_NUM_CERTIFIC_EXT);

            /*" -713- MOVE WS-GE0530-DTH-CAD-RD TO LK-GE0531-DTA-INCLUSAO */
            _.Move(WS_GE0530_PEPS.WS_GE0530_DTH_CAD_RD, LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_DTA_INCLUSAO);

            /*" -714- MOVE LK-GE0530-NUM-APOLICE TO LK-GE0531-NUM-APOLICE */
            _.Move(LBGE0530.LK_GE0530.LK_GE0530_NUM_APOLICE, LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_NUM_APOLICE);

            /*" -715- MOVE LK-GE0530-NUM-ENDOSSO TO LK-GE0531-NUM-ENDOSSO */
            _.Move(LBGE0530.LK_GE0530.LK_GE0530_NUM_ENDOSSO, LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_NUM_ENDOSSO);

            /*" -716- MOVE LK-GE0530-NUM-SINISTRO TO LK-GE0531-NUM-SINISTRO */
            _.Move(LBGE0530.LK_GE0530.LK_GE0530_NUM_SINISTRO, LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_NUM_SINISTRO);

            /*" -717- MOVE LK-GE0530-OCORR-HISTORICO TO LK-GE0531-OCORR-HISTORICO */
            _.Move(LBGE0530.LK_GE0530.LK_GE0530_OCORR_HISTORICO, LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_OCORR_HISTORICO);

            /*" -720- MOVE LK-GE0530-COD-OPER-SINISTRO TO LK-GE0531-COD-OPER-SINISTRO */
            _.Move(LBGE0530.LK_GE0530.LK_GE0530_COD_OPER_SINISTRO, LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_COD_OPER_SINISTRO);

            /*" -721- IF LK-GE0530-IND-RESTRICAO EQUAL 'S' */

            if (LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_IND_RESTRICAO == "S")
            {

                /*" -722- MOVE WS-GE0530-NUM-CPF-CNPJ TO LK-GE0531-CPF-CNPJ */
                _.Move(WS_GE0530_PEPS.WS_GE0530_NUM_CPF_CNPJ, LBGE0531.LK_GE0531.LK_GE0531_CPF_CNPJ);

                /*" -723- MOVE WS-GE0530-NOM-PEPS TO LK-GE0531-NOM-SEGURADO */
                _.Move(WS_GE0530_PEPS.WS_GE0530_NOM_PEPS, LBGE0531.LK_GE0531.LK_GE0531_NOM_SEGURADO);

                /*" -724- MOVE WS-GE0530-COD-CARGO TO LK-GE0531-COD-CARGO */
                _.Move(WS_GE0530_PEPS.WS_GE0530_COD_CARGO, LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_COD_CARGO);

                /*" -725- MOVE WS-GE0530-NOM-CARGO TO LK-GE0531-DES-CARGO */
                _.Move(WS_GE0530_PEPS.WS_GE0530_NOM_CARGO, LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_DES_CARGO);

                /*" -726- MOVE WS-GE0530-NOM-ORGAO-PEPS TO LK-GE0531-NOM-ORGAO */
                _.Move(WS_GE0530_PEPS.WS_GE0530_NOM_ORGAO_PEPS, LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_NOM_ORGAO);

                /*" -727- MOVE WS-GE0530-COD-TP-PEPS TO LK-GE0531-COD-RELACAO-EXT */
                _.Move(WS_GE0530_PEPS.WS_GE0530_COD_TP_PEPS, LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_COD_RELACAO_EXT);

                /*" -729- END-IF */
            }


            /*" -732- MOVE WS-GDA-COD-RELACAO-INT TO LK-GE0531-COD-RELACAO-INT */
            _.Move(WS_GDA_COD_RELACAO_INT, LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_COD_RELACAO_INT);

            /*" -734- IF (WS-GDA-COD-RELACAO-INT EQUAL 2 OR 3 ) AND (LK-GE0530-IND-RESTRICAO EQUAL 'S' ) */

            if ((WS_GDA_COD_RELACAO_INT.In("2", "3")) && (LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_IND_RESTRICAO == "S"))
            {

                /*" -735- MOVE WS-GE0530-NOM-PEPS TO LK-GE0530-NOME-CLIENTE-PEPS */
                _.Move(WS_GE0530_PEPS.WS_GE0530_NOM_PEPS, LBGE0530.LK_GE0530.LK_GE0530_RELATORIOS.LK_GE0530_NOME_CLIENTE_PEPS);

                /*" -738- END-IF */
            }


            /*" -741- MOVE 'F' TO LK-GE0531-IND-TIPO-PESSOA */
            _.Move("F", LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_IND_TIPO_PESSOA);

            /*" -744- MOVE 1 TO LK-GE0531-IND-MOVIMENTO */
            _.Move(1, LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_IND_MOVIMENTO);

            /*" -745- IF LK-GE0530-NOM-PRG-SOLICITA EQUAL 'LT3020B' */

            if (LBGE0530.LK_GE0530.LK_GE0530_NOM_PRG_SOLICITA == "LT3020B")
            {

                /*" -746- MOVE 1 TO LK-GE0531-IND-EVENTO */
                _.Move(1, LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_IND_EVENTO);

                /*" -749- END-IF */
            }


            /*" -750- IF LK-GE0530-NOM-PRG-SOLICITA EQUAL 'LT3025B' */

            if (LBGE0530.LK_GE0530.LK_GE0530_NOM_PRG_SOLICITA == "LT3025B")
            {

                /*" -751- MOVE 2 TO LK-GE0531-IND-EVENTO */
                _.Move(2, LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_IND_EVENTO);

                /*" -754- END-IF */
            }


            /*" -755- IF LK-GE0530-NOM-PRG-SOLICITA EQUAL 'SI0005B' */

            if (LBGE0530.LK_GE0530.LK_GE0530_NOM_PRG_SOLICITA == "SI0005B")
            {

                /*" -756- MOVE 3 TO LK-GE0531-IND-EVENTO */
                _.Move(3, LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_IND_EVENTO);

                /*" -759- END-IF */
            }


            /*" -760- IF LK-GE0530-NOM-PRG-SOLICITA EQUAL 'SI6BA' */

            if (LBGE0530.LK_GE0530.LK_GE0530_NOM_PRG_SOLICITA == "SI6BA")
            {

                /*" -761- MOVE 4 TO LK-GE0531-IND-EVENTO */
                _.Move(4, LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_IND_EVENTO);

                /*" -762- SET WS-SIAS-ONLINE TO TRUE */
                WS_TIPO_SISTEMA["WS_SIAS_ONLINE"] = true;

                /*" -765- END-IF */
            }


            /*" -766- IF LK-GE0530-NOM-PRG-SOLICITA EQUAL 'SI6EA' */

            if (LBGE0530.LK_GE0530.LK_GE0530_NOM_PRG_SOLICITA == "SI6EA")
            {

                /*" -767- MOVE 4 TO LK-GE0531-IND-EVENTO */
                _.Move(4, LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_IND_EVENTO);

                /*" -768- SET WS-SIAS-ONLINE TO TRUE */
                WS_TIPO_SISTEMA["WS_SIAS_ONLINE"] = true;

                /*" -771- END-IF */
            }


            /*" -773- IF LK-GE0530-NOM-PRG-SOLICITA EQUAL 'LT3053B' AND LK-GE0530-TIPO-RELATORIO EQUAL 1 */

            if (LBGE0530.LK_GE0530.LK_GE0530_NOM_PRG_SOLICITA == "LT3053B" && LBGE0530.LK_GE0530.LK_GE0530_RELATORIOS.LK_GE0530_TIPO_RELATORIO == 1)
            {

                /*" -774- MOVE 5 TO LK-GE0531-IND-EVENTO */
                _.Move(5, LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_IND_EVENTO);

                /*" -777- END-IF */
            }


            /*" -779- IF LK-GE0530-NOM-PRG-SOLICITA EQUAL 'LT3053B' AND LK-GE0530-TIPO-RELATORIO EQUAL 2 */

            if (LBGE0530.LK_GE0530.LK_GE0530_NOM_PRG_SOLICITA == "LT3053B" && LBGE0530.LK_GE0530.LK_GE0530_RELATORIOS.LK_GE0530_TIPO_RELATORIO == 2)
            {

                /*" -780- MOVE 6 TO LK-GE0531-IND-EVENTO */
                _.Move(6, LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_IND_EVENTO);

                /*" -785- END-IF */
            }


            /*" -786- IF LK-GE0530-IND-RESTRICAO EQUAL 'N' */

            if (LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_IND_RESTRICAO == "N")
            {

                /*" -787- MOVE 1 TO LK-GE0531-STA-REGISTRO */
                _.Move(1, LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_STA_REGISTRO);

                /*" -789- ELSE */
            }
            else
            {


                /*" -790- IF LK-GE0530-IND-RESTRICAO EQUAL 'S' */

                if (LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_IND_RESTRICAO == "S")
                {

                    /*" -791- MOVE 2 TO LK-GE0531-STA-REGISTRO */
                    _.Move(2, LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_STA_REGISTRO);

                    /*" -792- ELSE */
                }
                else
                {


                    /*" -793- DISPLAY 'R2100-ERRO DB2 NA CONSULTA PEP....' */
                    _.Display($"R2100-ERRO DB2 NA CONSULTA PEP....");

                    /*" -794- MOVE 16 TO LK-GE0530-COD-RETORNO */
                    _.Move(16, LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_COD_RETORNO);

                    /*" -796- MOVE 'GE0530S-Indicador de restricao - invalida.' TO LK-GE0530-MSG-RETORNO */
                    _.Move("GE0530S-Indicador de restricao - invalida.", LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_MSG_RETORNO);

                    /*" -797- PERFORM R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION();

                    /*" -798- END-IF */
                }


                /*" -801- END-IF */
            }


            /*" -805- MOVE 1 TO LK-GE0531-COD-ORIGEM */
            _.Move(1, LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_COD_ORIGEM);

            /*" -806- IF WS-TIPO-SISTEMA EQUAL 'S' */

            if (WS_TIPO_SISTEMA == "S")
            {

                /*" -807- MOVE LK-GE0530-COD-USUARIO TO LK-GE0531-COD-USUARIO */
                _.Move(LBGE0530.LK_GE0530.LK_GE0530_COD_USUARIO, LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_COD_USUARIO);

                /*" -808- ELSE */
            }
            else
            {


                /*" -809- MOVE LK-GE0530-NOM-PRG-SOLICITA TO LK-GE0531-COD-USUARIO */
                _.Move(LBGE0530.LK_GE0530.LK_GE0530_NOM_PRG_SOLICITA, LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_COD_USUARIO);

                /*" -811- END-IF */
            }


            /*" -813- MOVE LK-GE0530-NOM-PRG-SOLICITA TO LK-GE0531-NOM-PROGRAMA */
            _.Move(LBGE0530.LK_GE0530.LK_GE0530_NOM_PRG_SOLICITA, LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_NOM_PROGRAMA);

            /*" -815- DISPLAY 'VOU CHAMAR A GE0531S...' */
            _.Display($"VOU CHAMAR A GE0531S...");

            /*" -817- CALL WS-GE0531S USING LK-GE0531. */
            _.Call(WS_GE0531S, LBGE0531.LK_GE0531);

            /*" -818- IF LK-GE0531-COD-RETORNO NOT EQUAL ZEROS */

            if (LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_COD_RETORNO != 00)
            {

                /*" -819- MOVE 17 TO LK-GE0530-COD-RETORNO */
                _.Move(17, LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_COD_RETORNO);

                /*" -821- MOVE 'ERRO GE0531S - INSERT LOG PEP.' TO LK-GE0530-MSG-RETORNO */
                _.Move("ERRO GE0531S - INSERT LOG PEP.", LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_MSG_RETORNO);

                /*" -822- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -828- END-IF */
            }


            /*" -828- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2300-CONS-RLC-TIT-PEP-SECTION */
        private void R2300_CONS_RLC_TIT_PEP_SECTION()
        {
            /*" -837- PERFORM R2320-ABRR-CURSOR-C001 */

            R2320_ABRR_CURSOR_C001_SECTION();

            /*" -840- PERFORM R2330-LER-PEP-RELAC UNTIL FIM-PEP-RELAC EQUAL 'S' */

            while (!(FIM_PEP_RELAC == "S"))
            {

                R2330_LER_PEP_RELAC_SECTION();
            }

            /*" -842- PERFORM R2340-FECHAR-CURSOR */

            R2340_FECHAR_CURSOR_SECTION();

            /*" -842- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2320-ABRR-CURSOR-C001-SECTION */
        private void R2320_ABRR_CURSOR_C001_SECTION()
        {
            /*" -852- MOVE 'R2320-00' TO WS-PARAGRAFO */
            _.Move("R2320-00", WS_PARAGRAFO);

            /*" -854- PERFORM R2320_ABRR_CURSOR_C001_DB_OPEN_1 */

            R2320_ABRR_CURSOR_C001_DB_OPEN_1();

            /*" -857- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -858- MOVE 18 TO LK-GE0530-COD-RETORNO */
                _.Move(18, LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_COD_RETORNO);

                /*" -860- MOVE 'ERRO GE0530S-ABRIR CURSOR C001' TO LK-GE0530-MSG-RETORNO */
                _.Move("ERRO GE0530S-ABRIR CURSOR C001", LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_MSG_RETORNO);

                /*" -861- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -863- END-IF */
            }


            /*" -864- SET CURSOR-C001-ABTO TO TRUE */
            CTL_CURSOR_C001.IN_CURSOR_C001_ABTO["CURSOR_C001_ABTO"] = true;

            /*" -865- DISPLAY 'CURSOR-C001-ABTO ' IN-CURSOR-C001-ABTO */
            _.Display($"CURSOR-C001-ABTO {CTL_CURSOR_C001.IN_CURSOR_C001_ABTO}");

            /*" -865- . */

        }

        [StopWatch]
        /*" R2320-ABRR-CURSOR-C001-DB-OPEN-1 */
        public void R2320_ABRR_CURSOR_C001_DB_OPEN_1()
        {
            /*" -854- EXEC SQL OPEN C001 END-EXEC */

            C001.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1320_99_SAIDA*/

        [StopWatch]
        /*" R2330-LER-PEP-RELAC-SECTION */
        private void R2330_LER_PEP_RELAC_SECTION()
        {
            /*" -876- MOVE 'R2330-00' TO WS-PARAGRAFO WNR-EXEC-SQL */
            _.Move("R2330-00", WS_PARAGRAFO, WABEND.WABEND2.WNR_EXEC_SQL);

            /*" -878- INITIALIZE DCLGE-PEPS-PESSOA-EXPOSTA */
            _.Initialize(
                GE530.DCLGE_PEPS_PESSOA_EXPOSTA
            );

            /*" -908- PERFORM R2330_LER_PEP_RELAC_DB_FETCH_1 */

            R2330_LER_PEP_RELAC_DB_FETCH_1();

            /*" -915- MOVE SQLCODE TO CD-SQL-CURSOR-C001 */
            _.Move(DB.SQLCODE, CTL_CURSOR_C001.CD_SQL_CURSOR_C001);

            /*" -916- EVALUATE CD-SQL-CURSOR-C001 */
            switch (CTL_CURSOR_C001.CD_SQL_CURSOR_C001)
            {

                /*" -917- WHEN +0 */
                case +0:

                    /*" -918- MOVE 4 TO WS-GDA-COD-RELACAO-INT */
                    _.Move(4, WS_GDA_COD_RELACAO_INT);

                    /*" -919- MOVE 'S' TO LK-GE0530-IND-RESTRICAO */
                    _.Move("S", LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_IND_RESTRICAO);

                    /*" -920- PERFORM R2150-00-GRAVAR-DADOS-PEP */

                    R2150_00_GRAVAR_DADOS_PEP_SECTION();

                    /*" -921- PERFORM R2200-00-GRAVAR-LOG */

                    R2200_00_GRAVAR_LOG_SECTION();

                    /*" -922- WHEN +100 */
                    break;
                case +100:

                    /*" -923- MOVE 'S' TO FIM-PEP-RELAC */
                    _.Move("S", FIM_PEP_RELAC);

                    /*" -924- WHEN OTHER */
                    break;
                default:

                    /*" -925- MOVE 19 TO LK-GE0530-COD-RETORNO */
                    _.Move(19, LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_COD_RETORNO);

                    /*" -927- MOVE 'ERRO GE0530S-FETCH CURSOR C001' TO LK-GE0530-MSG-RETORNO */
                    _.Move("ERRO GE0530S-FETCH CURSOR C001", LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_MSG_RETORNO);

                    /*" -928- PERFORM R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION();

                    /*" -930- END-EVALUATE */
                    break;
            }


            /*" -930- . */

        }

        [StopWatch]
        /*" R2330-LER-PEP-RELAC-DB-FETCH-1 */
        public void R2330_LER_PEP_RELAC_DB_FETCH_1()
        {
            /*" -908- EXEC SQL FETCH C001 INTO :GE530-SEQ-PEPS ,:GE530-DTA-INIVIG-PEPS ,:GE530-DTA-FIMVIG-PEPS ,:GE530-COD-TP-PEPS ,:GE530-COD-PEPS-EXTERNO ,:GE530-COD-PEPS-RELACIONADO ,:GE530-NUM-CPF-CNPJ ,:GE530-NOM-PEPS ,:GE530-COD-ORGAO-PESS-PEPS ,:GE530-NOM-ORGAO-PEPS ,:GE530-COD-CARGO ,:GE530-NOM-CARGO ,:GE530-COD-COAF ,:GE530-IND-SEXO ,:GE530-NOM-LOGRADOURO ,:GE530-DES-LOGRADOURO ,:GE530-DES-COMPLEMENTO ,:GE530-NOM-BAIRRO ,:GE530-COD-CEP ,:GE530-NOM-MUNICIPIO ,:GE530-COD-UF ,:GE530-DTA-NOMEACAO ,:GE530-DTA-EXONERACAO ,:GE530-NOM-MUNICIPIO-ORGAO ,:GE530-COD-UF-ORGAO ,:GE530-COD-USUARIO ,:GE530-NOM-PROGRAMA ,:GE530-DTH-CADASTRAMENTO END-EXEC */

            if (C001.Fetch())
            {
                _.Move(C001.GE530_SEQ_PEPS, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_SEQ_PEPS);
                _.Move(C001.GE530_DTA_INIVIG_PEPS, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_DTA_INIVIG_PEPS);
                _.Move(C001.GE530_DTA_FIMVIG_PEPS, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_DTA_FIMVIG_PEPS);
                _.Move(C001.GE530_COD_TP_PEPS, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_COD_TP_PEPS);
                _.Move(C001.GE530_COD_PEPS_EXTERNO, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_COD_PEPS_EXTERNO);
                _.Move(C001.GE530_COD_PEPS_RELACIONADO, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_COD_PEPS_RELACIONADO);
                _.Move(C001.GE530_NUM_CPF_CNPJ, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_NUM_CPF_CNPJ);
                _.Move(C001.GE530_NOM_PEPS, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_NOM_PEPS);
                _.Move(C001.GE530_COD_ORGAO_PESS_PEPS, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_COD_ORGAO_PESS_PEPS);
                _.Move(C001.GE530_NOM_ORGAO_PEPS, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_NOM_ORGAO_PEPS);
                _.Move(C001.GE530_COD_CARGO, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_COD_CARGO);
                _.Move(C001.GE530_NOM_CARGO, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_NOM_CARGO);
                _.Move(C001.GE530_COD_COAF, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_COD_COAF);
                _.Move(C001.GE530_IND_SEXO, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_IND_SEXO);
                _.Move(C001.GE530_NOM_LOGRADOURO, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_NOM_LOGRADOURO);
                _.Move(C001.GE530_DES_LOGRADOURO, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_DES_LOGRADOURO);
                _.Move(C001.GE530_DES_COMPLEMENTO, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_DES_COMPLEMENTO);
                _.Move(C001.GE530_NOM_BAIRRO, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_NOM_BAIRRO);
                _.Move(C001.GE530_COD_CEP, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_COD_CEP);
                _.Move(C001.GE530_NOM_MUNICIPIO, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_NOM_MUNICIPIO);
                _.Move(C001.GE530_COD_UF, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_COD_UF);
                _.Move(C001.GE530_DTA_NOMEACAO, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_DTA_NOMEACAO);
                _.Move(C001.GE530_DTA_EXONERACAO, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_DTA_EXONERACAO);
                _.Move(C001.GE530_NOM_MUNICIPIO_ORGAO, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_NOM_MUNICIPIO_ORGAO);
                _.Move(C001.GE530_COD_UF_ORGAO, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_COD_UF_ORGAO);
                _.Move(C001.GE530_COD_USUARIO, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_COD_USUARIO);
                _.Move(C001.GE530_NOM_PROGRAMA, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_NOM_PROGRAMA);
                _.Move(C001.GE530_DTH_CADASTRAMENTO, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_DTH_CADASTRAMENTO);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2330_99_SAIDA*/

        [StopWatch]
        /*" R2340-FECHAR-CURSOR-SECTION */
        private void R2340_FECHAR_CURSOR_SECTION()
        {
            /*" -940- PERFORM R2340_FECHAR_CURSOR_DB_CLOSE_1 */

            R2340_FECHAR_CURSOR_DB_CLOSE_1();

            /*" -943- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -944- MOVE 20 TO LK-GE0530-COD-RETORNO */
                _.Move(20, LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_COD_RETORNO);

                /*" -946- MOVE 'ERRO GE0530S-FECHAR CURSOR C001' TO LK-GE0530-MSG-RETORNO */
                _.Move("ERRO GE0530S-FECHAR CURSOR C001", LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_MSG_RETORNO);

                /*" -947- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -949- END-IF */
            }


            /*" -950- MOVE 'N' TO IN-CURSOR-C001-ABTO */
            _.Move("N", CTL_CURSOR_C001.IN_CURSOR_C001_ABTO);

            /*" -951- DISPLAY 'CURSOR-C001-ABTO > ' IN-CURSOR-C001-ABTO */
            _.Display($"CURSOR-C001-ABTO > {CTL_CURSOR_C001.IN_CURSOR_C001_ABTO}");

            /*" -951- . */

        }

        [StopWatch]
        /*" R2340-FECHAR-CURSOR-DB-CLOSE-1 */
        public void R2340_FECHAR_CURSOR_DB_CLOSE_1()
        {
            /*" -940- EXEC SQL CLOSE C001 END-EXEC */

            C001.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2340_99_SAIDA*/

        [StopWatch]
        /*" R2400-CONS-RLC-TIT-PEP-SECTION */
        private void R2400_CONS_RLC_TIT_PEP_SECTION()
        {
            /*" -961- PERFORM R2420-ABRR-CURSOR-C002 */

            R2420_ABRR_CURSOR_C002_SECTION();

            /*" -964- PERFORM R2430-LER-PEP-RELAC UNTIL FIM-PEP-RELAC EQUAL 'S' */

            while (!(FIM_PEP_RELAC == "S"))
            {

                R2430_LER_PEP_RELAC_SECTION();
            }

            /*" -966- PERFORM R2440-FECHAR-CURSOR */

            R2440_FECHAR_CURSOR_SECTION();

            /*" -966- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R2420-ABRR-CURSOR-C002-SECTION */
        private void R2420_ABRR_CURSOR_C002_SECTION()
        {
            /*" -977- MOVE 'R2420-00' TO WS-PARAGRAFO WNR-EXEC-SQL */
            _.Move("R2420-00", WS_PARAGRAFO, WABEND.WABEND2.WNR_EXEC_SQL);

            /*" -979- PERFORM R2420_ABRR_CURSOR_C002_DB_OPEN_1 */

            R2420_ABRR_CURSOR_C002_DB_OPEN_1();

            /*" -982- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -983- MOVE 21 TO LK-GE0530-COD-RETORNO */
                _.Move(21, LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_COD_RETORNO);

                /*" -985- MOVE 'ERRO GE0530S-ABRIR CURSOR C002' TO LK-GE0530-MSG-RETORNO */
                _.Move("ERRO GE0530S-ABRIR CURSOR C002", LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_MSG_RETORNO);

                /*" -986- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -988- END-IF */
            }


            /*" -989- SET CURSOR-C002-ABTO TO TRUE */
            CTL_CURSOR_C002.IN_CURSOR_C002_ABTO["CURSOR_C002_ABTO"] = true;

            /*" -991- DISPLAY 'IN-CURSOR-C002-ABTO ' IN-CURSOR-C002-ABTO */
            _.Display($"IN-CURSOR-C002-ABTO {CTL_CURSOR_C002.IN_CURSOR_C002_ABTO}");

            /*" -991- . */

        }

        [StopWatch]
        /*" R2420-ABRR-CURSOR-C002-DB-OPEN-1 */
        public void R2420_ABRR_CURSOR_C002_DB_OPEN_1()
        {
            /*" -979- EXEC SQL OPEN C002 END-EXEC */

            C002.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2420_99_SAIDA*/

        [StopWatch]
        /*" R2430-LER-PEP-RELAC-SECTION */
        private void R2430_LER_PEP_RELAC_SECTION()
        {
            /*" -1002- MOVE 'R2430-00' TO WS-PARAGRAFO WNR-EXEC-SQL */
            _.Move("R2430-00", WS_PARAGRAFO, WABEND.WABEND2.WNR_EXEC_SQL);

            /*" -1004- INITIALIZE DCLGE-PEPS-PESSOA-EXPOSTA */
            _.Initialize(
                GE530.DCLGE_PEPS_PESSOA_EXPOSTA
            );

            /*" -1034- PERFORM R2430_LER_PEP_RELAC_DB_FETCH_1 */

            R2430_LER_PEP_RELAC_DB_FETCH_1();

            /*" -1042- MOVE SQLCODE TO CD-SQL-CURSOR-C002 */
            _.Move(DB.SQLCODE, CTL_CURSOR_C002.CD_SQL_CURSOR_C002);

            /*" -1043- EVALUATE SQLCODE */
            switch (DB.SQLCODE.Value)
            {

                /*" -1044- WHEN +0 */
                case +0:

                    /*" -1045- MOVE 4 TO WS-GDA-COD-RELACAO-INT */
                    _.Move(4, WS_GDA_COD_RELACAO_INT);

                    /*" -1046- MOVE 'S' TO LK-GE0530-IND-RESTRICAO */
                    _.Move("S", LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_IND_RESTRICAO);

                    /*" -1047- PERFORM R2150-00-GRAVAR-DADOS-PEP */

                    R2150_00_GRAVAR_DADOS_PEP_SECTION();

                    /*" -1048- PERFORM R2200-00-GRAVAR-LOG */

                    R2200_00_GRAVAR_LOG_SECTION();

                    /*" -1049- WHEN +100 */
                    break;
                case +100:

                    /*" -1050- MOVE 'S' TO FIM-PEP-RELAC */
                    _.Move("S", FIM_PEP_RELAC);

                    /*" -1051- WHEN OTHER */
                    break;
                default:

                    /*" -1052- MOVE 22 TO LK-GE0530-COD-RETORNO */
                    _.Move(22, LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_COD_RETORNO);

                    /*" -1054- MOVE 'ERRO GE0530S-FETCH CURSOR C002' TO LK-GE0530-MSG-RETORNO */
                    _.Move("ERRO GE0530S-FETCH CURSOR C002", LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_MSG_RETORNO);

                    /*" -1055- DISPLAY 'IN-CURSOR-C002-ABTO : ' IN-CURSOR-C002-ABTO */
                    _.Display($"IN-CURSOR-C002-ABTO : {CTL_CURSOR_C002.IN_CURSOR_C002_ABTO}");

                    /*" -1056- PERFORM R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION();

                    /*" -1058- END-EVALUATE */
                    break;
            }


            /*" -1058- . */

        }

        [StopWatch]
        /*" R2430-LER-PEP-RELAC-DB-FETCH-1 */
        public void R2430_LER_PEP_RELAC_DB_FETCH_1()
        {
            /*" -1034- EXEC SQL FETCH C002 INTO :GE530-SEQ-PEPS ,:GE530-DTA-INIVIG-PEPS ,:GE530-DTA-FIMVIG-PEPS ,:GE530-COD-TP-PEPS ,:GE530-COD-PEPS-EXTERNO ,:GE530-COD-PEPS-RELACIONADO ,:GE530-NUM-CPF-CNPJ ,:GE530-NOM-PEPS ,:GE530-COD-ORGAO-PESS-PEPS ,:GE530-NOM-ORGAO-PEPS ,:GE530-COD-CARGO ,:GE530-NOM-CARGO ,:GE530-COD-COAF ,:GE530-IND-SEXO ,:GE530-NOM-LOGRADOURO ,:GE530-DES-LOGRADOURO ,:GE530-DES-COMPLEMENTO ,:GE530-NOM-BAIRRO ,:GE530-COD-CEP ,:GE530-NOM-MUNICIPIO ,:GE530-COD-UF ,:GE530-DTA-NOMEACAO ,:GE530-DTA-EXONERACAO ,:GE530-NOM-MUNICIPIO-ORGAO ,:GE530-COD-UF-ORGAO ,:GE530-COD-USUARIO ,:GE530-NOM-PROGRAMA ,:GE530-DTH-CADASTRAMENTO END-EXEC */

            if (C002.Fetch())
            {
                _.Move(C002.GE530_SEQ_PEPS, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_SEQ_PEPS);
                _.Move(C002.GE530_DTA_INIVIG_PEPS, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_DTA_INIVIG_PEPS);
                _.Move(C002.GE530_DTA_FIMVIG_PEPS, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_DTA_FIMVIG_PEPS);
                _.Move(C002.GE530_COD_TP_PEPS, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_COD_TP_PEPS);
                _.Move(C002.GE530_COD_PEPS_EXTERNO, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_COD_PEPS_EXTERNO);
                _.Move(C002.GE530_COD_PEPS_RELACIONADO, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_COD_PEPS_RELACIONADO);
                _.Move(C002.GE530_NUM_CPF_CNPJ, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_NUM_CPF_CNPJ);
                _.Move(C002.GE530_NOM_PEPS, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_NOM_PEPS);
                _.Move(C002.GE530_COD_ORGAO_PESS_PEPS, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_COD_ORGAO_PESS_PEPS);
                _.Move(C002.GE530_NOM_ORGAO_PEPS, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_NOM_ORGAO_PEPS);
                _.Move(C002.GE530_COD_CARGO, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_COD_CARGO);
                _.Move(C002.GE530_NOM_CARGO, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_NOM_CARGO);
                _.Move(C002.GE530_COD_COAF, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_COD_COAF);
                _.Move(C002.GE530_IND_SEXO, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_IND_SEXO);
                _.Move(C002.GE530_NOM_LOGRADOURO, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_NOM_LOGRADOURO);
                _.Move(C002.GE530_DES_LOGRADOURO, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_DES_LOGRADOURO);
                _.Move(C002.GE530_DES_COMPLEMENTO, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_DES_COMPLEMENTO);
                _.Move(C002.GE530_NOM_BAIRRO, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_NOM_BAIRRO);
                _.Move(C002.GE530_COD_CEP, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_COD_CEP);
                _.Move(C002.GE530_NOM_MUNICIPIO, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_NOM_MUNICIPIO);
                _.Move(C002.GE530_COD_UF, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_COD_UF);
                _.Move(C002.GE530_DTA_NOMEACAO, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_DTA_NOMEACAO);
                _.Move(C002.GE530_DTA_EXONERACAO, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_DTA_EXONERACAO);
                _.Move(C002.GE530_NOM_MUNICIPIO_ORGAO, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_NOM_MUNICIPIO_ORGAO);
                _.Move(C002.GE530_COD_UF_ORGAO, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_COD_UF_ORGAO);
                _.Move(C002.GE530_COD_USUARIO, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_COD_USUARIO);
                _.Move(C002.GE530_NOM_PROGRAMA, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_NOM_PROGRAMA);
                _.Move(C002.GE530_DTH_CADASTRAMENTO, GE530.DCLGE_PEPS_PESSOA_EXPOSTA.GE530_DTH_CADASTRAMENTO);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2430_99_SAIDA*/

        [StopWatch]
        /*" R2440-FECHAR-CURSOR-SECTION */
        private void R2440_FECHAR_CURSOR_SECTION()
        {
            /*" -1068- PERFORM R2440_FECHAR_CURSOR_DB_CLOSE_1 */

            R2440_FECHAR_CURSOR_DB_CLOSE_1();

            /*" -1071- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1072- MOVE 23 TO LK-GE0530-COD-RETORNO */
                _.Move(23, LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_COD_RETORNO);

                /*" -1074- MOVE 'ERRO GE0530S-FECHAR CURSOR C002' TO LK-GE0530-MSG-RETORNO */
                _.Move("ERRO GE0530S-FECHAR CURSOR C002", LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_MSG_RETORNO);

                /*" -1075- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -1077- END-IF */
            }


            /*" -1078- MOVE 'N' TO IN-CURSOR-C002-ABTO */
            _.Move("N", CTL_CURSOR_C002.IN_CURSOR_C002_ABTO);

            /*" -1078- . */

        }

        [StopWatch]
        /*" R2440-FECHAR-CURSOR-DB-CLOSE-1 */
        public void R2440_FECHAR_CURSOR_DB_CLOSE_1()
        {
            /*" -1068- EXEC SQL CLOSE C002 END-EXEC */

            C002.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2440_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-FINALIZAR-SECTION */
        private void R3000_00_FINALIZAR_SECTION()
        {
            /*" -1089- MOVE 'R3000-00' TO WS-PARAGRAFO WNR-EXEC-SQL */
            _.Move("R3000-00", WS_PARAGRAFO, WABEND.WABEND2.WNR_EXEC_SQL);

            /*" -1090- MOVE ZEROS TO LK-GE0530-COD-RETORNO. */
            _.Move(0, LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_COD_RETORNO);

            /*" -1092- MOVE SPACES TO LK-GE0530-MSG-RETORNO. */
            _.Move("", LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_MSG_RETORNO);

            /*" -1093- DISPLAY '*-*-*-*-*-*-*-*-*-*-*--*-*-*-*-*-*-*-*-*-*-*' */
            _.Display($"*-*-*-*-*-*-*-*-*-*-*--*-*-*-*-*-*-*-*-*-*-*");

            /*" -1094- DISPLAY '* *          GE0530S - FIM NORMAL        * *' */
            _.Display($"* *          GE0530S - FIM NORMAL        * *");

            /*" -1095- DISPLAY '*-*-*-*-*-*-*-*-*-*-*--*-*-*-*-*-*-*-*-*-*-*' */
            _.Display($"*-*-*-*-*-*-*-*-*-*-*--*-*-*-*-*-*-*-*-*-*-*");

            /*" -1096- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -1097- DISPLAY '* Cliente consultado                       *' */
            _.Display($"* Cliente consultado                       *");

            /*" -1098- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -1099- DISPLAY '*SEQ. REGISTRO - ' LK-GE0530-SEQ-REGISTRO */
            _.Display($"*SEQ. REGISTRO - {LBGE0530.LK_GE0530.LK_GE0530_SEQ_REGISTRO}");

            /*" -1100- DISPLAY '*      CLIENTE - ' WS-GE0530-NOM-PEPS */
            _.Display($"*      CLIENTE - {WS_GE0530_PEPS.WS_GE0530_NOM_PEPS}");

            /*" -1101- DISPLAY '*     CPF-CNPJ - ' LK-GE0530-CPF-CNPJ */
            _.Display($"*     CPF-CNPJ - {LBGE0530.LK_GE0530.LK_GE0530_CPF_CNPJ}");

            /*" -1102- DISPLAY '*  COD-TP-PEPS - ' WS-GE0530-COD-TP-PEPS */
            _.Display($"*  COD-TP-PEPS - {WS_GE0530_PEPS.WS_GE0530_COD_TP_PEPS}");

            /*" -1106- DISPLAY '*-*-*-*-*-*-*-*-*-*-*--*-*-*-*-*-*-*-*-*-*-*' */
            _.Display($"*-*-*-*-*-*-*-*-*-*-*--*-*-*-*-*-*-*-*-*-*-*");

            /*" -1106- . */

            /*" -0- FLUXCONTROL_PERFORM R3000_99_SAIDA */

            R3000_99_SAIDA();

        }

        [StopWatch]
        /*" R3000-99-SAIDA */
        private void R3000_99_SAIDA(bool isPerform = false)
        {
            /*" -1108- GOBACK. */

            throw new GoBack();

        }

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1119- IF IN-CURSOR-C001-ABTO EQUAL 'S' */

            if (CTL_CURSOR_C001.IN_CURSOR_C001_ABTO == "S")
            {

                /*" -1120- PERFORM R2340-FECHAR-CURSOR */

                R2340_FECHAR_CURSOR_SECTION();

                /*" -1122- END-IF */
            }


            /*" -1123- IF IN-CURSOR-C002-ABTO EQUAL 'S' */

            if (CTL_CURSOR_C002.IN_CURSOR_C002_ABTO == "S")
            {

                /*" -1124- PERFORM R2440-FECHAR-CURSOR */

                R2440_FECHAR_CURSOR_SECTION();

                /*" -1126- END-IF */
            }


            /*" -1130- MOVE SQLCODE TO WS-SQLCODE WSQLCODE */
            _.Move(DB.SQLCODE, WS_SQLCODE, WABEND.WABEND3.WSQLCODE);

            /*" -1131- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1132- DISPLAY '*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*' . */
            _.Display($"*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*");

            /*" -1133- DISPLAY '*  TERMINO ANORMAL DO PROGRAMA GE0530S  *' . */
            _.Display($"*  TERMINO ANORMAL DO PROGRAMA GE0530S  *");

            /*" -1134- DISPLAY '*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*' . */
            _.Display($"*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*");

            /*" -1135- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1136- DISPLAY 'PARAGRAFO       = ' WS-PARAGRAFO */
            _.Display($"PARAGRAFO       = {WS_PARAGRAFO}");

            /*" -1137- DISPLAY 'SQLCODE         = ' WS-SQLCODE */
            _.Display($"SQLCODE         = {WS_SQLCODE}");

            /*" -1138- DISPLAY 'SQLCA           = ' SQLCA */
            _.Display($"SQLCA           = {DB.SQLCA}");

            /*" -1139- DISPLAY 'COD-RETORNO     = ' LK-GE0530-COD-RETORNO */
            _.Display($"COD-RETORNO     = {LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_COD_RETORNO}");

            /*" -1140- DISPLAY 'MSG-RETORNO     = ' LK-GE0530-MSG-RETORNO */
            _.Display($"MSG-RETORNO     = {LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_MSG_RETORNO}");

            /*" -1141- DISPLAY 'FUNCAO          = ' LK-GE0530-FUNCAO */
            _.Display($"FUNCAO          = {LBGE0530.LK_GE0530.LK_GE0530_FUNCAO}");

            /*" -1142- DISPLAY 'CODIGO EXTERNO  = ' LK-GE0530-NUM-CERTIFIC-EXT */
            _.Display($"CODIGO EXTERNO  = {LBGE0530.LK_GE0530.LK_GE0530_NUM_CERTIFIC_EXT}");

            /*" -1143- DISPLAY 'CPF-PESSOA      = ' LK-GE0530-CPF-CNPJ */
            _.Display($"CPF-PESSOA      = {LBGE0530.LK_GE0530.LK_GE0530_CPF_CNPJ}");

            /*" -1144- DISPLAY 'NOME SEGURADO   = ' LK-GE0530-NOME-PESSOA */
            _.Display($"NOME SEGURADO   = {LBGE0530.LK_GE0530.LK_GE0530_NOME_PESSOA}");

            /*" -1145- DISPLAY WABEND1. */
            _.Display(WABEND.WABEND1);

            /*" -1146- DISPLAY WABEND2. */
            _.Display(WABEND.WABEND2);

            /*" -1150- DISPLAY WABEND3. */
            _.Display(WABEND.WABEND3);

            /*" -1150- GOBACK. */

            throw new GoBack();

        }
    }
}