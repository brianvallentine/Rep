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
using Sias.Sinistro.DB2.SI0077B;

namespace Code
{
    public class SI0077B
    {
        public bool IsCall { get; set; }

        public SI0077B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................ SINISTRO                            *      */
        /*"      *   PROGRAMA ............... SI0077B                             *      */
        /*"      *   ANALISTA ............... HEIDER COELHO                       *      */
        /*"      *   PROGRAMADOR ............ HEIDER COELHO                       *      */
        /*"      *   DATA CODIFICACAO ....... AGOSTO / 1997                       *      */
        /*"      *   FUNCAO ................. EMISSAO DA PLANILHA DE CALCULO,     *      */
        /*"      *          REFERENTE AO CALCULO DO VALOR DE INDENIZACAO PARA O   *      */
        /*"      *          HABITACIONAL FORA SFH (FUNCEF - 0106500000001)        *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      * CONVERSAO ANO 2000              CONSEDA4              05/1998  *      */
        /*"      * ALTERADO P/ COLOCAR ANO C/ 4 POSICOES - HAC - 6/11/98          *      */
        /*"      * REVISAO - ANO 2000              CONSEDA4           06/06/1998  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *ALTERADO POR JEFFERSON PARA UTILIZAR AS NOVAS TABELAS DO HABITA-*      */
        /*"      *CIONAL - 05/2000                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * HISTORICO DE VERSOES                                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * NO   VERSAO    DATA       PROGRAMADOR           ALTERACAO      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 1.    1.0    01/08/1997   HEIDER COELHO         CODIFICACAO    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 2.    2.0    08/08/2011   PATRICIA SALES        CADMUS 60091.  *      */
        /*"      *                                                 PROCURE V.02.  *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _SIHAPLAN { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis SIHAPLAN
        {
            get
            {
                _.Move(REG_SIHAPLAN, _SIHAPLAN); VarBasis.RedefinePassValue(REG_SIHAPLAN, _SIHAPLAN, REG_SIHAPLAN); return _SIHAPLAN;
            }
        }
        /*"01                  REG-SIHAPLAN.*/
        public SI0077B_REG_SIHAPLAN REG_SIHAPLAN { get; set; } = new SI0077B_REG_SIHAPLAN();
        public class SI0077B_REG_SIHAPLAN : VarBasis
        {
            /*"      05            LINHA-ARQUIVO      PIC  X(80).*/
            public StringBasis LINHA_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "80", "X(80)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  V0HABIT4-NUM-APOL-SINISTRO  PIC S9(13) VALUE +0 COMP-3.*/
        public IntBasis V0HABIT4_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0HABIT4-NUM-FIAP           PIC S9(09) VALUE +0 COMP-3.*/
        public IntBasis V0HABIT4_NUM_FIAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0HABIT4-DATA-CONTRATO      PIC  X(10).*/
        public StringBasis V0HABIT4_DATA_CONTRATO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0HABIT4-DATA-SINISTRO      PIC  X(10).*/
        public StringBasis V0HABIT4_DATA_SINISTRO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0HABIT4-DATA-INDENIZACAO   PIC  X(10).*/
        public StringBasis V0HABIT4_DATA_INDENIZACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0HABIT4-DATA-SALDO-DEVEDOR PIC  X(10).*/
        public StringBasis V0HABIT4_DATA_SALDO_DEVEDOR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0HABIT4-NOME-SEGURADO      PIC  X(40).*/
        public StringBasis V0HABIT4_NOME_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77  V0HABIT4-PERC-PARTICIPACAO  PIC S9(03)V9(04) VALUE +0 COMP-3*/
        public DoubleBasis V0HABIT4_PERC_PARTICIPACAO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(04)"), 4);
        /*"77  V0HABIT4-DIAS-M             PIC S9(05) VALUE +0 COMP-3.*/
        public IntBasis V0HABIT4_DIAS_M { get; set; } = new IntBasis(new PIC("S9", "5", "S9(05)"));
        /*"77  V0HABIT4-DIAS-N             PIC S9(05) VALUE +0 COMP-3.*/
        public IntBasis V0HABIT4_DIAS_N { get; set; } = new IntBasis(new PIC("S9", "5", "S9(05)"));
        /*"77  V0HABIT4-DIAS-CORRIDOS-D    PIC S9(05) VALUE +0 COMP-3.*/
        public IntBasis V0HABIT4_DIAS_CORRIDOS_D { get; set; } = new IntBasis(new PIC("S9", "5", "S9(05)"));
        /*"77  V0HABIT4-PERC-JUROS         PIC S9(03) VALUE +0 COMP-3.*/
        public IntBasis V0HABIT4_PERC_JUROS { get; set; } = new IntBasis(new PIC("S9", "3", "S9(03)"));
        /*"77  V0HABIT4-VAL-SDO-DEVEDOR    PIC S9(13)V9(02) VALUE +0 COMP-3*/
        public DoubleBasis V0HABIT4_VAL_SDO_DEVEDOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(02)"), 2);
        /*"77  V0HABIT4-VAL-SDO-CORRIGIDO  PIC S9(13)V9(02) VALUE +0 COMP-3*/
        public DoubleBasis V0HABIT4_VAL_SDO_CORRIGIDO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(02)"), 2);
        /*"77  V0HABIT4-VAL-INDENIZACAO    PIC S9(13)V9(02) VALUE +0 COMP-3*/
        public DoubleBasis V0HABIT4_VAL_INDENIZACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(02)"), 2);
        /*"77  V0HABIT4-PRI-INPC           PIC S9(03)V9(04) VALUE +0 COMP-3*/
        public DoubleBasis V0HABIT4_PRI_INPC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(04)"), 4);
        /*"77  V0HABIT4-PRI-INPC-MMAA      PIC  X(07).*/
        public StringBasis V0HABIT4_PRI_INPC_MMAA { get; set; } = new StringBasis(new PIC("X", "7", "X(07)."), @"");
        /*"77  V0HABIT4-ULT-INPC           PIC S9(03)V9(04) VALUE +0 COMP-3*/
        public DoubleBasis V0HABIT4_ULT_INPC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(04)"), 4);
        /*"77  V0HABIT4-ULT-INPC-MMAA      PIC  X(07).*/
        public StringBasis V0HABIT4_ULT_INPC_MMAA { get; set; } = new StringBasis(new PIC("X", "7", "X(07)."), @"");
        /*"77  V0HABIT4-INPC-INDENI        PIC S9(03)V9(04) VALUE +0 COMP-3*/
        public DoubleBasis V0HABIT4_INPC_INDENI { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(04)"), 4);
        /*"77  V0HABIT4-INPC-INDENI-MMAA   PIC  X(07).*/
        public StringBasis V0HABIT4_INPC_INDENI_MMAA { get; set; } = new StringBasis(new PIC("X", "7", "X(07)."), @"");
        /*"77  V0HABIT4-INPC-PRO-RATA      PIC S9(05)V9(08) VALUE +0 COMP-3*/
        public DoubleBasis V0HABIT4_INPC_PRO_RATA { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(05)V9(08)"), 8);
        /*"77  V0HABIT4-TIMESTAMP          PIC  X(26).*/
        public StringBasis V0HABIT4_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"77  V0CLIENTE-COD-CLIENTE       PIC S9(09)       VALUE +0 COMP.*/
        public IntBasis V0CLIENTE_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0CLIENTE-NOME-RAZAO        PIC  X(40).*/
        public StringBasis V0CLIENTE_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77  V0END-COD-CLIENTE           PIC S9(09)       VALUE +0 COMP.*/
        public IntBasis V0END_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0END-ENDER-IMOVEL          PIC X(30).*/
        public StringBasis V0END_ENDER_IMOVEL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"77  V0END-NUM-IMOVEL            PIC X(05).*/
        public StringBasis V0END_NUM_IMOVEL { get; set; } = new StringBasis(new PIC("X", "5", "X(05)."), @"");
        /*"77  V0END-COMPL-IMOVEL          PIC X(15).*/
        public StringBasis V0END_COMPL_IMOVEL { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"77  V0END-BAIRRO-IMOVEL         PIC X(15).*/
        public StringBasis V0END_BAIRRO_IMOVEL { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"77  V0END-CIDADE-IMOVEL         PIC X(22).*/
        public StringBasis V0END_CIDADE_IMOVEL { get; set; } = new StringBasis(new PIC("X", "22", "X(22)."), @"");
        /*"77  V0END-UF-IMOVEL             PIC X(02).*/
        public StringBasis V0END_UF_IMOVEL { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
        /*"77  V0END-CEP-IMOVEL            PIC S9(09)       VALUE +0 COMP.*/
        public IntBasis V0END_CEP_IMOVEL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0MEST-NUM-APOL-SINISTRO    PIC S9(13)       VALUE +0 COMP-3*/
        public IntBasis V0MEST_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0MEST-NUM-APOLICE          PIC S9(13)       VALUE +0 COMP-3*/
        public IntBasis V0MEST_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0MEST-CODCAU               PIC S9(04)       VALUE +0 COMP.*/
        public IntBasis V0MEST_CODCAU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MEST-RAMO                 PIC S9(04)       VALUE +0 COMP.*/
        public IntBasis V0MEST_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MEST-NUMIRB               PIC S9(11)       VALUE +0 COMP-3*/
        public IntBasis V0MEST_NUMIRB { get; set; } = new IntBasis(new PIC("S9", "11", "S9(11)"));
        /*"77  V0MEST-DATORR               PIC  X(10).*/
        public StringBasis V0MEST_DATORR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0CAUSA-DESCAU                PIC X(40).*/
        public StringBasis V0CAUSA_DESCAU { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77  V0SISTEMA-DTMOVABE            PIC X(10).*/
        public StringBasis V0SISTEMA_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0COTACAO-DTINIVIG            PIC X(10).*/
        public StringBasis V0COTACAO_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  W-V0COTACAO-VALCPR          PIC S9(07)V9(8)  VALUE +0 COMP-3*/
        public DoubleBasis W_V0COTACAO_VALCPR { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(07)V9(8)"), 8);
        /*"77  V0RELATORIOS-DATA-REFERENCIA  PIC X(10).*/
        public StringBasis V0RELATORIOS_DATA_REFERENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  W-DATA-SELECAO                PIC X(10).*/
        public StringBasis W_DATA_SELECAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01           AREA-DE-WORK.*/
        public SI0077B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SI0077B_AREA_DE_WORK();
        public class SI0077B_AREA_DE_WORK : VarBasis
        {
            /*"  05  WSL-SQLCODE               PIC  9(009)      VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05  W-CHAVES-FIM-ARQUIVO.*/
            public SI0077B_W_CHAVES_FIM_ARQUIVO W_CHAVES_FIM_ARQUIVO { get; set; } = new SI0077B_W_CHAVES_FIM_ARQUIVO();
            public class SI0077B_W_CHAVES_FIM_ARQUIVO : VarBasis
            {
                /*"      10  WFIM-V0SINIHABIT4        PIC  X(003)      VALUE SPACES*/
                public StringBasis WFIM_V0SINIHABIT4 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"  10  W-PRI-INPC-CHEIO-MMAA.*/
            }
            public SI0077B_W_PRI_INPC_CHEIO_MMAA W_PRI_INPC_CHEIO_MMAA { get; set; } = new SI0077B_W_PRI_INPC_CHEIO_MMAA();
            public class SI0077B_W_PRI_INPC_CHEIO_MMAA : VarBasis
            {
                /*"      15  W-PRI-INPC-CHEIO-MM   PIC  9(02)     VALUE ZEROS.*/
                public IntBasis W_PRI_INPC_CHEIO_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"      15  FILLER                PIC  X(01)     VALUE SPACES.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"      15  W-PRI-INPC-CHEIO-AA   PIC  9(04)     VALUE ZEROS.*/
                public IntBasis W_PRI_INPC_CHEIO_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"  10  W-ULT-INPC-CHEIO-MMAA.*/
            }
            public SI0077B_W_ULT_INPC_CHEIO_MMAA W_ULT_INPC_CHEIO_MMAA { get; set; } = new SI0077B_W_ULT_INPC_CHEIO_MMAA();
            public class SI0077B_W_ULT_INPC_CHEIO_MMAA : VarBasis
            {
                /*"      15  W-ULT-INPC-CHEIO-MM   PIC  9(02)     VALUE ZEROS.*/
                public IntBasis W_ULT_INPC_CHEIO_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"      15  FILLER                PIC  X(01)     VALUE SPACES.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"      15  W-ULT-INPC-CHEIO-AA   PIC  9(04)     VALUE ZEROS.*/
                public IntBasis W_ULT_INPC_CHEIO_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"  10  W-INPC-PRO-RATA-MMAA.*/
            }
            public SI0077B_W_INPC_PRO_RATA_MMAA W_INPC_PRO_RATA_MMAA { get; set; } = new SI0077B_W_INPC_PRO_RATA_MMAA();
            public class SI0077B_W_INPC_PRO_RATA_MMAA : VarBasis
            {
                /*"      15  W-INPC-PRO-RATA-MM    PIC  9(02)     VALUE ZEROS.*/
                public IntBasis W_INPC_PRO_RATA_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"      15  FILLER                PIC  X(01)     VALUE SPACES.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"      15  W-INPC-PRO-RATA-AA    PIC  9(04)     VALUE ZEROS.*/
                public IntBasis W_INPC_PRO_RATA_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"  10  W-DATA-PRI-INPC-CHEIO.*/
            }
            public SI0077B_W_DATA_PRI_INPC_CHEIO W_DATA_PRI_INPC_CHEIO { get; set; } = new SI0077B_W_DATA_PRI_INPC_CHEIO();
            public class SI0077B_W_DATA_PRI_INPC_CHEIO : VarBasis
            {
                /*"      15  W-SSAA-PRI-INPC-CHEIO PIC  9(04).*/
                public IntBasis W_SSAA_PRI_INPC_CHEIO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"      15  W-FILLER-1  REDEFINES  W-SSAA-PRI-INPC-CHEIO.*/
                private _REDEF_SI0077B_W_FILLER_1 _w_filler_1 { get; set; }
                public _REDEF_SI0077B_W_FILLER_1 W_FILLER_1
                {
                    get { _w_filler_1 = new _REDEF_SI0077B_W_FILLER_1(); _.Move(W_SSAA_PRI_INPC_CHEIO, _w_filler_1); VarBasis.RedefinePassValue(W_SSAA_PRI_INPC_CHEIO, _w_filler_1, W_SSAA_PRI_INPC_CHEIO); _w_filler_1.ValueChanged += () => { _.Move(_w_filler_1, W_SSAA_PRI_INPC_CHEIO); }; return _w_filler_1; }
                    set { VarBasis.RedefinePassValue(value, _w_filler_1, W_SSAA_PRI_INPC_CHEIO); }
                }  //Redefines
                public class _REDEF_SI0077B_W_FILLER_1 : VarBasis
                {
                    /*"          20  W-AA-PRI-INPC-CHEIO    PIC  9(04).*/
                    public IntBasis W_AA_PRI_INPC_CHEIO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                    /*"      15  FILLER                PIC  X(01)     VALUE '-'.*/

                    public _REDEF_SI0077B_W_FILLER_1()
                    {
                        W_AA_PRI_INPC_CHEIO.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"      15  W-MM-PRI-INPC-CHEIO   PIC  9(02)     VALUE ZEROS.*/
                public IntBasis W_MM_PRI_INPC_CHEIO { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"      15  FILLER                PIC  X(01)     VALUE '-'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"      15  W-DD-PRI-INPC-CHEIO   PIC  9(02)     VALUE ZEROS.*/
                public IntBasis W_DD_PRI_INPC_CHEIO { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"  10  W-DATA-ULT-INPC-CHEIO.*/
            }
            public SI0077B_W_DATA_ULT_INPC_CHEIO W_DATA_ULT_INPC_CHEIO { get; set; } = new SI0077B_W_DATA_ULT_INPC_CHEIO();
            public class SI0077B_W_DATA_ULT_INPC_CHEIO : VarBasis
            {
                /*"      15  W-SSAA-ULT-INPC-CHEIO PIC  9(04).*/
                public IntBasis W_SSAA_ULT_INPC_CHEIO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"      15  W-FILLER-2  REDEFINES  W-SSAA-ULT-INPC-CHEIO.*/
                private _REDEF_SI0077B_W_FILLER_2 _w_filler_2 { get; set; }
                public _REDEF_SI0077B_W_FILLER_2 W_FILLER_2
                {
                    get { _w_filler_2 = new _REDEF_SI0077B_W_FILLER_2(); _.Move(W_SSAA_ULT_INPC_CHEIO, _w_filler_2); VarBasis.RedefinePassValue(W_SSAA_ULT_INPC_CHEIO, _w_filler_2, W_SSAA_ULT_INPC_CHEIO); _w_filler_2.ValueChanged += () => { _.Move(_w_filler_2, W_SSAA_ULT_INPC_CHEIO); }; return _w_filler_2; }
                    set { VarBasis.RedefinePassValue(value, _w_filler_2, W_SSAA_ULT_INPC_CHEIO); }
                }  //Redefines
                public class _REDEF_SI0077B_W_FILLER_2 : VarBasis
                {
                    /*"          20  W-AA-ULT-INPC-CHEIO    PIC  9(04).*/
                    public IntBasis W_AA_ULT_INPC_CHEIO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                    /*"      15  FILLER                PIC  X(01)     VALUE '-'.*/

                    public _REDEF_SI0077B_W_FILLER_2()
                    {
                        W_AA_ULT_INPC_CHEIO.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"      15  W-MM-ULT-INPC-CHEIO   PIC  9(02)     VALUE ZEROS.*/
                public IntBasis W_MM_ULT_INPC_CHEIO { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"      15  FILLER                PIC  X(01)     VALUE '-'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"      15  W-DD-ULT-INPC-CHEIO   PIC  9(02)     VALUE ZEROS.*/
                public IntBasis W_DD_ULT_INPC_CHEIO { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"  10  W-INDICE                  PIC S9(04)     VALUE +0 COMP.*/
            }
            public IntBasis W_INDICE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  10  W-INDICE-IMPRIME          PIC S9(04)     VALUE +0 COMP.*/
            public IntBasis W_INDICE_IMPRIME { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  10  W-AC-LIDOS                PIC  9(05)     VALUE  0.*/
            public IntBasis W_AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "5", "9(05)"));
            /*"  10  W-ACHOU-V0RELATORIOS      PIC  X(03)     VALUE 'NAO'.*/
            public StringBasis W_ACHOU_V0RELATORIOS { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"  05         WDATA-CABEC.*/
            public SI0077B_WDATA_CABEC WDATA_CABEC { get; set; } = new SI0077B_WDATA_CABEC();
            public class SI0077B_WDATA_CABEC : VarBasis
            {
                /*"    10       WDATA-DD-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDATA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDATA-AA-CABEC    PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05         WHORA-CABEC.*/
            }
            public SI0077B_WHORA_CABEC WHORA_CABEC { get; set; } = new SI0077B_WHORA_CABEC();
            public class SI0077B_WHORA_CABEC : VarBasis
            {
                /*"    10       WHORA-HH-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_HH_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '.'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10       WHORA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '.'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10       WHORA-SS-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_SS_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05   W-DATA-1.*/
            }
            public SI0077B_W_DATA_1 W_DATA_1 { get; set; } = new SI0077B_W_DATA_1();
            public class SI0077B_W_DATA_1 : VarBasis
            {
                /*"    10  W-AA-DATA-1             PIC  9(004)    VALUE ZEROS.*/
                public IntBasis W_AA_DATA_1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10  FILLER                  PIC  X(001)    VALUE SPACES.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10  W-MM-DATA-1             PIC  9(002)    VALUE ZEROS.*/
                public IntBasis W_MM_DATA_1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10  FILLER                  PIC  X(001)    VALUE SPACES.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10  W-DD-DATA-1             PIC  9(002)    VALUE ZEROS.*/
                public IntBasis W_DD_DATA_1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05   W-DATA-2.*/
            }
            public SI0077B_W_DATA_2 W_DATA_2 { get; set; } = new SI0077B_W_DATA_2();
            public class SI0077B_W_DATA_2 : VarBasis
            {
                /*"    10  W-DD-DATA-2             PIC  9(002)    VALUE ZEROS.*/
                public IntBasis W_DD_DATA_2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10  FILLER                  PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10  W-MM-DATA-2             PIC  9(002)    VALUE ZEROS.*/
                public IntBasis W_MM_DATA_2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10  FILLER                  PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10  W-AA-DATA-2             PIC  9(004)    VALUE ZEROS.*/
                public IntBasis W_AA_DATA_2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    05 CA-EF0100S.*/
                public SI0077B_CA_EF0100S CA_EF0100S { get; set; } = new SI0077B_CA_EF0100S();
                public class SI0077B_CA_EF0100S : VarBasis
                {
                    /*"       10 CA-V0HABIT4-NUM-FIAP-EF0100S   PIC S9(09) COMP.*/
                    public IntBasis CA_V0HABIT4_NUM_FIAP_EF0100S { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
                    /*"       10 CA-V0MEST-DATORR-EF0100S       PIC  X(10).*/
                    public StringBasis CA_V0MEST_DATORR_EF0100S { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                    /*"       10 CA-V0END-COD-CLIENTE-EF0100S   PIC S9(09) COMP.*/
                    public IntBasis CA_V0END_COD_CLIENTE_EF0100S { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
                    /*"       10 CA-V0END-ENDER-IMOVEL-EF0100S  PIC  X(30).*/
                    public StringBasis CA_V0END_ENDER_IMOVEL_EF0100S { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
                    /*"       10 CA-V0END-NUM-IMOVEL-EF0100S    PIC  X(05).*/
                    public StringBasis CA_V0END_NUM_IMOVEL_EF0100S { get; set; } = new StringBasis(new PIC("X", "5", "X(05)."), @"");
                    /*"       10 CA-V0END-COMPL-IMOVEL-EF0100S  PIC  X(15).*/
                    public StringBasis CA_V0END_COMPL_IMOVEL_EF0100S { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
                    /*"       10 CA-V0END-BAIRRO-IMOVEL-EF0100S PIC  X(15).*/
                    public StringBasis CA_V0END_BAIRRO_IMOVEL_EF0100S { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
                    /*"       10 CA-V0END-CIDADE-IMOVEL-EF0100S PIC  X(22).*/
                    public StringBasis CA_V0END_CIDADE_IMOVEL_EF0100S { get; set; } = new StringBasis(new PIC("X", "22", "X(22)."), @"");
                    /*"       10 CA-V0END-UF-IMOVEL-EF0100S     PIC  X(02).*/
                    public StringBasis CA_V0END_UF_IMOVEL_EF0100S { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
                    /*"       10 CA-V0END-CEP-IMOVEL-EF0100S    PIC S9(09) COMP.*/
                    public IntBasis CA_V0END_CEP_IMOVEL_EF0100S { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
                    /*"       10 CA-SQLCODE-EF0100S             PIC S9(09) COMP-4.*/
                    public IntBasis CA_SQLCODE_EF0100S { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
                    /*"01  TABELA-DE-INPC.*/
                }
            }
        }
        public SI0077B_TABELA_DE_INPC TABELA_DE_INPC { get; set; } = new SI0077B_TABELA_DE_INPC();
        public class SI0077B_TABELA_DE_INPC : VarBasis
        {
            /*"  03 W-OCORRENCIA-INPC  OCCURS 120  TIMES.*/
            public ListBasis<SI0077B_W_OCORRENCIA_INPC> W_OCORRENCIA_INPC { get; set; } = new ListBasis<SI0077B_W_OCORRENCIA_INPC>(120);
            public class SI0077B_W_OCORRENCIA_INPC : VarBasis
            {
                /*"     05 W-MES-INPC            PIC X(04).*/
                public StringBasis W_MES_INPC { get; set; } = new StringBasis(new PIC("X", "4", "X(04)."), @"");
                /*"     05 W-ANO-INPC            PIC 9(04).*/
                public IntBasis W_ANO_INPC { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"     05 W-VALOR-INPC          PIC 9(03)V9(04).*/
                public DoubleBasis W_VALOR_INPC { get; set; } = new DoubleBasis(new PIC("9", "3", "9(03)V9(04)."), 4);
                /*"01  TABELA-DE-MESES.*/
            }
        }
        public SI0077B_TABELA_DE_MESES TABELA_DE_MESES { get; set; } = new SI0077B_TABELA_DE_MESES();
        public class SI0077B_TABELA_DE_MESES : VarBasis
        {
            /*"  03 WS-MESES.*/
            public SI0077B_WS_MESES WS_MESES { get; set; } = new SI0077B_WS_MESES();
            public class SI0077B_WS_MESES : VarBasis
            {
                /*"     05 FILLER   PIC X(04)  VALUE 'JAN.'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"JAN.");
                /*"     05 FILLER   PIC X(04)  VALUE 'FEV.'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"FEV.");
                /*"     05 FILLER   PIC X(04)  VALUE 'MAR.'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"MAR.");
                /*"     05 FILLER   PIC X(04)  VALUE 'ABR.'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"ABR.");
                /*"     05 FILLER   PIC X(04)  VALUE 'MAI.'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"MAI.");
                /*"     05 FILLER   PIC X(04)  VALUE 'JUN.'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"JUN.");
                /*"     05 FILLER   PIC X(04)  VALUE 'JUL.'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"JUL.");
                /*"     05 FILLER   PIC X(04)  VALUE 'AGO.'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"AGO.");
                /*"     05 FILLER   PIC X(04)  VALUE 'SET.'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"SET.");
                /*"     05 FILLER   PIC X(04)  VALUE 'OUT.'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"OUT.");
                /*"     05 FILLER   PIC X(04)  VALUE 'NOV.'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"NOV.");
                /*"     05 FILLER   PIC X(04)  VALUE 'DEZ.'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"DEZ.");
                /*"  03 FILLER REDEFINES WS-MESES OCCURS 12 TIMES*/
            }
            private ListBasis<_REDEF_SI0077B_FILLER_27> _filler_27 { get; set; }
            public ListBasis<_REDEF_SI0077B_FILLER_27> FILLER_27
            {
                get { _filler_27 = new ListBasis<_REDEF_SI0077B_FILLER_27>(12); _.Move(WS_MESES, _filler_27); VarBasis.RedefinePassValue(WS_MESES, _filler_27, WS_MESES); _filler_27.ValueChanged += () => { _.Move(_filler_27, WS_MESES); }; return _filler_27; }
                set { VarBasis.RedefinePassValue(value, _filler_27, WS_MESES); }
            }  //Redefines
            public class _REDEF_SI0077B_FILLER_27 : VarBasis
            {
                /*"     05 WS-TAB-MES  PIC  X(04).*/
                public StringBasis WS_TAB_MES { get; set; } = new StringBasis(new PIC("X", "4", "X(04)."), @"");
                /*"01  TABELA-DE-MESES-INTEIRO.*/

                public _REDEF_SI0077B_FILLER_27()
                {
                    WS_TAB_MES.ValueChanged += OnValueChanged;
                }

            }
        }
        public SI0077B_TABELA_DE_MESES_INTEIRO TABELA_DE_MESES_INTEIRO { get; set; } = new SI0077B_TABELA_DE_MESES_INTEIRO();
        public class SI0077B_TABELA_DE_MESES_INTEIRO : VarBasis
        {
            /*"  03 WS-MESES-INT.*/
            public SI0077B_WS_MESES_INT WS_MESES_INT { get; set; } = new SI0077B_WS_MESES_INT();
            public class SI0077B_WS_MESES_INT : VarBasis
            {
                /*"     05 FILLER   PIC X(09)  VALUE 'JANEIRO  '.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"JANEIRO  ");
                /*"     05 FILLER   PIC X(09)  VALUE 'FEVEREIRO'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"FEVEREIRO");
                /*"     05 FILLER   PIC X(09)  VALUE 'MARCO    '.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"MARCO    ");
                /*"     05 FILLER   PIC X(09)  VALUE 'ABRIL    '.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"ABRIL    ");
                /*"     05 FILLER   PIC X(09)  VALUE 'MAIO     '.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"MAIO     ");
                /*"     05 FILLER   PIC X(09)  VALUE 'JUNHO    '.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"JUNHO    ");
                /*"     05 FILLER   PIC X(09)  VALUE 'JULHO    '.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"JULHO    ");
                /*"     05 FILLER   PIC X(09)  VALUE 'AGOSTO   '.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"AGOSTO   ");
                /*"     05 FILLER   PIC X(09)  VALUE 'SETEMBRO '.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"SETEMBRO ");
                /*"     05 FILLER   PIC X(09)  VALUE 'OUTUBRO  '.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"OUTUBRO  ");
                /*"     05 FILLER   PIC X(09)  VALUE 'NOVEMBRO '.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"NOVEMBRO ");
                /*"     05 FILLER   PIC X(09)  VALUE 'DEZEMBRO '.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"DEZEMBRO ");
                /*"  03 FILLER REDEFINES WS-MESES-INT OCCURS 12 TIMES.*/
            }
            private ListBasis<_REDEF_SI0077B_FILLER_40> _filler_40 { get; set; }
            public ListBasis<_REDEF_SI0077B_FILLER_40> FILLER_40
            {
                get { _filler_40 = new ListBasis<_REDEF_SI0077B_FILLER_40>(12); _.Move(WS_MESES_INT, _filler_40); VarBasis.RedefinePassValue(WS_MESES_INT, _filler_40, WS_MESES_INT); _filler_40.ValueChanged += () => { _.Move(_filler_40, WS_MESES_INT); }; return _filler_40; }
                set { VarBasis.RedefinePassValue(value, _filler_40, WS_MESES_INT); }
            }  //Redefines
            public class _REDEF_SI0077B_FILLER_40 : VarBasis
            {
                /*"     05 WS-TAB-MES-INT PIC  X(09)*/
                public StringBasis WS_TAB_MES_INT { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"");
                /*"01          WVALOR              PIC  S9(015)V99 COMP-3.*/

                public _REDEF_SI0077B_FILLER_40()
                {
                    WS_TAB_MES_INT.ValueChanged += OnValueChanged;
                }

            }
        }
        public DoubleBasis WVALOR { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
        /*"01          WRESPOSTA           PIC   X(004)   VALUE  SPACES.*/
        public StringBasis WRESPOSTA { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
        /*"01          WAREA-1.*/
        public SI0077B_WAREA_1 WAREA_1 { get; set; } = new SI0077B_WAREA_1();
        public class SI0077B_WAREA_1 : VarBasis
        {
            /*"  03        WTAM-1              PIC   9(003)   VALUE  15.*/
            public IntBasis WTAM_1 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"), 15);
            /*"  03        WLINHA-1            PIC   X(051)   VALUE  SPACES.*/
            public StringBasis WLINHA_1 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"");
            /*"01          WAREA-2.*/
        }
        public SI0077B_WAREA_2 WAREA_2 { get; set; } = new SI0077B_WAREA_2();
        public class SI0077B_WAREA_2 : VarBasis
        {
            /*"  03        WTAM-2              PIC   9(003)   VALUE  80.*/
            public IntBasis WTAM_2 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"), 80);
            /*"  03        WLINHA-2            PIC   X(080)   VALUE  SPACES.*/
            public StringBasis WLINHA_2 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"");
            /*"01          WAREA-3.*/
        }
        public SI0077B_WAREA_3 WAREA_3 { get; set; } = new SI0077B_WAREA_3();
        public class SI0077B_WAREA_3 : VarBasis
        {
            /*"  03        WTAM-3              PIC   9(003)   VALUE  33.*/
            public IntBasis WTAM_3 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"), 33);
            /*"  03        WLINHA-3            PIC   X(078)   VALUE  SPACES.*/
            public StringBasis WLINHA_3 { get; set; } = new StringBasis(new PIC("X", "78", "X(078)"), @"");
            /*"  03            WSQLCODE3           PIC S9(009) COMP.*/
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03        WABEND.*/
            public SI0077B_WABEND WABEND { get; set; } = new SI0077B_WABEND();
            public class SI0077B_WABEND : VarBasis
            {
                /*"    05      FILLER              PIC  X(010) VALUE           ' SI0077B'.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SI0077B");
                /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"    05      FILLER              PIC  X(017) VALUE           ' *** PARAGRAFO = '.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @" *** PARAGRAFO = ");
                /*"    05      PARAGRAFO           PIC  X(030) VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"  03        WABEND2.*/
            }
            public SI0077B_WABEND2 WABEND2 { get; set; } = new SI0077B_WABEND2();
            public class SI0077B_WABEND2 : VarBasis
            {
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"    05      WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE1= '.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE1= ");
                /*"    05      WSQLCODE1           PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE1 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE2= '.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE2= ");
                /*"    05      WSQLCODE2           PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE2 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"  05 LN00.*/
            }
            public SI0077B_LN00 LN00 { get; set; } = new SI0077B_LN00();
            public class SI0077B_LN00 : VarBasis
            {
                /*"    10 FILLER                   PIC X(080) VALUE SPACES.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"");
                /*"  05 LN01.*/
            }
            public SI0077B_LN01 LN01 { get; set; } = new SI0077B_LN01();
            public class SI0077B_LN01 : VarBasis
            {
                /*"    10 FILLER                   PIC X(019) VALUE    'APOLICE FORA DO SFH'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"APOLICE FORA DO SFH");
                /*"    10 FILLER                   PIC X(054) VALUE SPACES.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "54", "X(054)"), @"");
                /*"    10 FILLER                   PIC X(007) VALUE 'SI0077B'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"SI0077B");
                /*"  05 LN02.*/
            }
            public SI0077B_LN02 LN02 { get; set; } = new SI0077B_LN02();
            public class SI0077B_LN02 : VarBasis
            {
                /*"    10 FILLER                   PIC X(080) VALUE    'CALCULO DE INDENIZACAO M.I.P. - FUNCEF'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"CALCULO DE INDENIZACAO M.I.P. - FUNCEF");
                /*"  05 LN03.*/
            }
            public SI0077B_LN03 LN03 { get; set; } = new SI0077B_LN03();
            public class SI0077B_LN03 : VarBasis
            {
                /*"    10 FILLER                   PIC X(020) VALUE    'ESTIPULANTE        :'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"ESTIPULANTE        :");
                /*"    10 FILLER                   PIC X(001) VALUE SPACES.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10 LN03-ESTIPULANTE    PIC X(040) VALUE SPACES.*/
                public StringBasis LN03_ESTIPULANTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    10 FILLER                   PIC X(020) VALUE SPACES.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"  05 LN04.*/
            }
            public SI0077B_LN04 LN04 { get; set; } = new SI0077B_LN04();
            public class SI0077B_LN04 : VarBasis
            {
                /*"    10 FILLER                   PIC X(020) VALUE    'NUMERO DO SINISTRO :'.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"NUMERO DO SINISTRO :");
                /*"    10 FILLER                   PIC X(001) VALUE SPACES.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10 LN04-SINISTRO-SASSE PIC 9(013) VALUE ZEROS.*/
                public IntBasis LN04_SINISTRO_SASSE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
                /*"    10 FILLER                   PIC X(013) VALUE    ' - SASSE  /  '.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" - SASSE  /  ");
                /*"    10 LN04-SINISTRO-IRB   PIC 9(006) VALUE ZEROS.*/
                public IntBasis LN04_SINISTRO_IRB { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
                /*"    10 FILLER                   PIC X(006) VALUE    ' - IRB'.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @" - IRB");
                /*"    10 FILLER                   PIC X(022) VALUE SPACES.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "22", "X(022)"), @"");
                /*"  05 LN05.*/
            }
            public SI0077B_LN05 LN05 { get; set; } = new SI0077B_LN05();
            public class SI0077B_LN05 : VarBasis
            {
                /*"    10 FILLER                   PIC X(020) VALUE    'NUMERO DA FIAP     :'.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"NUMERO DA FIAP     :");
                /*"    10 FILLER                   PIC X(001) VALUE SPACES.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10 LN05-NUM-FIAP       PIC Z(013).*/
                public IntBasis LN05_NUM_FIAP { get; set; } = new IntBasis(new PIC("S9", "13", "Z(013)."));
                /*"    10 FILLER                   PIC X(047) VALUE SPACES.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "47", "X(047)"), @"");
                /*"  05 LN06.*/
            }
            public SI0077B_LN06 LN06 { get; set; } = new SI0077B_LN06();
            public class SI0077B_LN06 : VarBasis
            {
                /*"    10 FILLER                   PIC X(020) VALUE       'NOME DO SEGURADO(A):'.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"NOME DO SEGURADO(A):");
                /*"    10 FILLER                   PIC X(001) VALUE SPACES.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10 LN07-NOME-SEGURADO  PIC X(040) VALUE SPACES.*/
                public StringBasis LN07_NOME_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    10 FILLER                   PIC X(020) VALUE SPACES.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"  05 LN07.*/
            }
            public SI0077B_LN07 LN07 { get; set; } = new SI0077B_LN07();
            public class SI0077B_LN07 : VarBasis
            {
                /*"    10 FILLER                   PIC X(020) VALUE       'ENDERECO DO IMOVEL :'.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"ENDERECO DO IMOVEL :");
                /*"    10 FILLER                   PIC X(001) VALUE SPACES.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10 LN07-ENDER-IMOVEL   PIC X(030) VALUE SPACES.*/
                public StringBasis LN07_ENDER_IMOVEL { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"    10 FILLER                   PIC X(001) VALUE SPACES.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10 LN07-NUM-IMOVEL     PIC X(005) VALUE SPACES.*/
                public StringBasis LN07_NUM_IMOVEL { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"  05 LN08.*/
            }
            public SI0077B_LN08 LN08 { get; set; } = new SI0077B_LN08();
            public class SI0077B_LN08 : VarBasis
            {
                /*"    10 LN08-CIDADE-IMOVEL  PIC X(022) VALUE SPACES.*/
                public StringBasis LN08_CIDADE_IMOVEL { get; set; } = new StringBasis(new PIC("X", "22", "X(022)"), @"");
                /*"    10 FILLER                   PIC X(001) VALUE ' '.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"    10 LN08-UF-IMOVEL      PIC X(002) VALUE SPACES.*/
                public StringBasis LN08_UF_IMOVEL { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"  05 LN09.*/
            }
            public SI0077B_LN09 LN09 { get; set; } = new SI0077B_LN09();
            public class SI0077B_LN09 : VarBasis
            {
                /*"    10 FILLER                   PIC X(020) VALUE    'CAUSA DO SINISTRO  :'.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"CAUSA DO SINISTRO  :");
                /*"    10 FILLER                   PIC X(001) VALUE ' '.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"    10 LN09-DESCRICAO-CAUSA     PIC X(059) VALUE SPACES.*/
                public StringBasis LN09_DESCRICAO_CAUSA { get; set; } = new StringBasis(new PIC("X", "59", "X(059)"), @"");
                /*"  05 LN10.*/
            }
            public SI0077B_LN10 LN10 { get; set; } = new SI0077B_LN10();
            public class SI0077B_LN10 : VarBasis
            {
                /*"    10 FILLER                   PIC X(080) VALUE    'ATUALIZACAO MONETARIA DO SALDO DEVEDOR CONSTANTE NA DATA DA    'ULTIMA PRESTACAO AN-'.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"ATUALIZACAO MONETARIA DO SALDO DEVEDOR CONSTANTE NA DATA DA    ");
                /*"  05 LN11.*/
            }
            public SI0077B_LN11 LN11 { get; set; } = new SI0077B_LN11();
            public class SI0077B_LN11 : VarBasis
            {
                /*"    10 FILLER                   PIC X(080) VALUE    'TERIOR A DATA DE OCORRENCIA DO SINISTRO, ATE A DATA DA INDEN    'IZACAO.             '.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"TERIOR A DATA DE OCORRENCIA DO SINISTRO, ATE A DATA DA INDEN    ");
                /*"  05 LN12.*/
            }
            public SI0077B_LN12 LN12 { get; set; } = new SI0077B_LN12();
            public class SI0077B_LN12 : VarBasis
            {
                /*"    10 FILLER                   PIC X(42) VALUE    'DATA DO SINISTRO (A) ....................:'.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "42", "X(42)"), @"DATA DO SINISTRO (A) ....................:");
                /*"    10 FILLER                   PIC X(01) VALUE SPACES.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"    10 LN12-DATA-SINISTRO       PIC X(10) VALUE SPACES.*/
                public StringBasis LN12_DATA_SINISTRO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"    10 FILLER                   PIC X(27) VALUE SPACES.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "27", "X(27)"), @"");
                /*"  05 LN13.*/
            }
            public SI0077B_LN13 LN13 { get; set; } = new SI0077B_LN13();
            public class SI0077B_LN13 : VarBasis
            {
                /*"    10 FILLER                   PIC X(42) VALUE    'DATA PRESTACAO ANTERIOR AO SINISTRO (B) .:'.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "42", "X(42)"), @"DATA PRESTACAO ANTERIOR AO SINISTRO (B) .:");
                /*"    10 FILLER                   PIC X(01) VALUE SPACES.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"    10 LN13-DATA-SALDO-DEVEDOR  PIC X(10) VALUE SPACES.*/
                public StringBasis LN13_DATA_SALDO_DEVEDOR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"    10 FILLER                   PIC X(27) VALUE SPACES.*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "27", "X(27)"), @"");
                /*"  05 LN14.*/
            }
            public SI0077B_LN14 LN14 { get; set; } = new SI0077B_LN14();
            public class SI0077B_LN14 : VarBasis
            {
                /*"    10 FILLER                   PIC X(42) VALUE    'DATA DE INDENIZACAO (C) .................:'.*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "42", "X(42)"), @"DATA DE INDENIZACAO (C) .................:");
                /*"    10 FILLER                   PIC X(01) VALUE SPACES.*/
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"    10 LN13-DATA-INDENIZACAO    PIC X(10) VALUE SPACES.*/
                public StringBasis LN13_DATA_INDENIZACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"    10 FILLER                   PIC X(27) VALUE SPACES.*/
                public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "27", "X(27)"), @"");
                /*"  05 LN15.*/
            }
            public SI0077B_LN15 LN15 { get; set; } = new SI0077B_LN15();
            public class SI0077B_LN15 : VarBasis
            {
                /*"    10 FILLER                   PIC X(17) VALUE    'SALDO DEVEDOR EM '.*/
                public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @"SALDO DEVEDOR EM ");
                /*"    10 LN15-DATA-SALDO-DEVEDOR  PIC X(10) VALUE SPACES.*/
                public StringBasis LN15_DATA_SALDO_DEVEDOR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"    10 FILLER                   PIC X(15) VALUE    ' (D) .........:'.*/
                public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @" (D) .........:");
                /*"    10 FILLER                   PIC X(01) VALUE SPACES.*/
                public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"    10 LN15-SALDO-DEVEDOR       PIC ZZZ.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LN15_SALDO_DEVEDOR { get; set; } = new DoubleBasis(new PIC("9", "12", "ZZZ.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"    10 FILLER                   PIC X(19) VALUE SPACES.*/
                public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "19", "X(19)"), @"");
                /*"  05 LN16.*/
            }
            public SI0077B_LN16 LN16 { get; set; } = new SI0077B_LN16();
            public class SI0077B_LN16 : VarBasis
            {
                /*"    10 FILLER                   PIC X(42) VALUE    'PERC. PARTICIPACAO ......................:'.*/
                public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "42", "X(42)"), @"PERC. PARTICIPACAO ......................:");
                /*"    10 FILLER                   PIC X(01) VALUE SPACES.*/
                public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"    10 LN16-PERC-PARTICIPACAO   PIC ZZ9,9999.*/
                public DoubleBasis LN16_PERC_PARTICIPACAO { get; set; } = new DoubleBasis(new PIC("9", "3", "ZZ9V9999."), 4);
                /*"    10 FILLER                   PIC X(29) VALUE SPACES.*/
                public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "29", "X(29)"), @"");
                /*"  05 LN17.*/
            }
            public SI0077B_LN17 LN17 { get; set; } = new SI0077B_LN17();
            public class SI0077B_LN17 : VarBasis
            {
                /*"    10 FILLER                   PIC X(66) VALUE    'M - NUMERO DE DIAS UTEIS ENTRE A DATA DA ULTIMA PRESTACAO AN    'TERI-:'.*/
                public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "66", "X(66)"), @"M - NUMERO DE DIAS UTEIS ENTRE A DATA DA ULTIMA PRESTACAO AN    ");
                /*"    10 FILLER                   PIC X(01) VALUE SPACES.*/
                public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"    10 LN17-QTD-DIAS-M          PIC ZZZZ9.*/
                public IntBasis LN17_QTD_DIAS_M { get; set; } = new IntBasis(new PIC("9", "5", "ZZZZ9."));
                /*"    10 FILLER                   PIC X(08) VALUE SPACES.*/
                public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
                /*"  05 LN18.*/
            }
            public SI0077B_LN18 LN18 { get; set; } = new SI0077B_LN18();
            public class SI0077B_LN18 : VarBasis
            {
                /*"    10 FILLER                   PIC X(80) VALUE    '    OR A INDENIZACAO E A PROXIMA.'.*/
                public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"    OR A INDENIZACAO E A PROXIMA.");
                /*"  05 LN19.*/
            }
            public SI0077B_LN19 LN19 { get; set; } = new SI0077B_LN19();
            public class SI0077B_LN19 : VarBasis
            {
                /*"    10 FILLER                   PIC X(66) VALUE    'N - NUMERO DE DIAS UTEIS ENTRE A DATA DA ULTIMA PRESTACAO AN    'TERI-:'.*/
                public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "66", "X(66)"), @"N - NUMERO DE DIAS UTEIS ENTRE A DATA DA ULTIMA PRESTACAO AN    ");
                /*"    10 FILLER                   PIC X(01) VALUE SPACES.*/
                public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"    10 LN17-QTD-DIAS-N          PIC ZZZZ9.*/
                public IntBasis LN17_QTD_DIAS_N { get; set; } = new IntBasis(new PIC("9", "5", "ZZZZ9."));
                /*"    10 FILLER                   PIC X(08) VALUE SPACES.*/
                public StringBasis FILLER_96 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
                /*"  05 LN20.*/
            }
            public SI0077B_LN20 LN20 { get; set; } = new SI0077B_LN20();
            public class SI0077B_LN20 : VarBasis
            {
                /*"    10 FILLER                   PIC X(80) VALUE    '    OR A INDENIZACAO E A DO EFETIVO PAGAMENTO DO SINISTRO.'*/
                public StringBasis FILLER_97 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"    OR A INDENIZACAO E A DO EFETIVO PAGAMENTO DO SINISTRO.");
                /*"  05 LN21.*/
            }
            public SI0077B_LN21 LN21 { get; set; } = new SI0077B_LN21();
            public class SI0077B_LN21 : VarBasis
            {
                /*"    10 FILLER                   PIC X(66) VALUE    'I - NUMERO DE DIAS CORRIDOS ENTRE A DATA DA ULTIMA PRESTACAO    '  AN-:'.*/
                public StringBasis FILLER_98 { get; set; } = new StringBasis(new PIC("X", "66", "X(66)"), @"I - NUMERO DE DIAS CORRIDOS ENTRE A DATA DA ULTIMA PRESTACAO    ");
                /*"    10 FILLER                   PIC X(01) VALUE SPACES.*/
                public StringBasis FILLER_99 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"    10 LN17-QTD-DIAS-D          PIC ZZZZ9.*/
                public IntBasis LN17_QTD_DIAS_D { get; set; } = new IntBasis(new PIC("9", "5", "ZZZZ9."));
                /*"    10 FILLER                   PIC X(08) VALUE SPACES.*/
                public StringBasis FILLER_100 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
                /*"  05 LN22.*/
            }
            public SI0077B_LN22 LN22 { get; set; } = new SI0077B_LN22();
            public class SI0077B_LN22 : VarBasis
            {
                /*"    10 FILLER                   PIC X(80) VALUE    '    TERIOR AO SINISTRO E A DO EFETIVO PAGAMENTO DO SINISTRO*/
                public StringBasis FILLER_101 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"");
                /*"  05 LN23.*/
            }
            public SI0077B_LN23 LN23 { get; set; } = new SI0077B_LN23();
            public class SI0077B_LN23 : VarBasis
            {
                /*"    10 FILLER                   PIC X(80) VALUE    'SALDO CORRIGIDO (E) = '.*/
                public StringBasis FILLER_102 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"SALDO CORRIGIDO (E) = ");
                /*"  05 LN24.*/
            }
            public SI0077B_LN24 LN24 { get; set; } = new SI0077B_LN24();
            public class SI0077B_LN24 : VarBasis
            {
                /*"    10 FILLER                   PIC X(43) VALUE SPACES.*/
                public StringBasis FILLER_103 { get; set; } = new StringBasis(new PIC("X", "43", "X(43)"), @"");
                /*"    10 FILLER                   PIC X(18) VALUE    '(   M/-------- )N'.*/
                public StringBasis FILLER_104 { get; set; } = new StringBasis(new PIC("X", "18", "X(18)"), @"(   M/-------- )N");
                /*"    10 FILLER                   PIC X(19) VALUE SPACES.*/
                public StringBasis FILLER_105 { get; set; } = new StringBasis(new PIC("X", "19", "X(19)"), @"");
                /*"  05 LN25.*/
            }
            public SI0077B_LN25 LN25 { get; set; } = new SI0077B_LN25();
            public class SI0077B_LN25 : VarBasis
            {
                /*"    10 FILLER                   PIC X(06) VALUE    '(D) X '.*/
                public StringBasis FILLER_106 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"(D) X ");
                /*"    10 LN25-PRIMEIRO-INPC-CHEIO PIC Z9,9999.*/
                public DoubleBasis LN25_PRIMEIRO_INPC_CHEIO { get; set; } = new DoubleBasis(new PIC("9", "2", "Z9V9999."), 4);
                /*"    10 FILLER                   PIC X(20) VALUE    ' X .............. X '.*/
                public StringBasis FILLER_107 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @" X .............. X ");
                /*"    10 LN25-ULTIMO-INPC-CHEIO   PIC Z9,9999.*/
                public DoubleBasis LN25_ULTIMO_INPC_CHEIO { get; set; } = new DoubleBasis(new PIC("9", "2", "Z9V9999."), 4);
                /*"    10 FILLER                   PIC X(03) VALUE ' X '.*/
                public StringBasis FILLER_108 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" X ");
                /*"    10 FILLER                   PIC X(07) VALUE    '(\  /  '.*/
                public StringBasis FILLER_109 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"(\  /  ");
                /*"    10 LN25-INPC-PRO-RATA       PIC Z9,9999.*/
                public DoubleBasis LN25_INPC_PRO_RATA { get; set; } = new DoubleBasis(new PIC("9", "2", "Z9V9999."), 4);
                /*"    10 FILLER                   PIC X(02) VALUE ' )'.*/
                public StringBasis FILLER_110 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @" )");
                /*"    10 FILLER                   PIC X(20) VALUE SPACES.*/
                public StringBasis FILLER_111 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"");
                /*"  05 LN26.*/
            }
            public SI0077B_LN26 LN26 { get; set; } = new SI0077B_LN26();
            public class SI0077B_LN26 : VarBasis
            {
                /*"    10 FILLER                   PIC X(07) VALUE SPACES.*/
                public StringBasis FILLER_112 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"");
                /*"    10 LN26-PRI-INPC-CHEIO-MM   PIC X(03) VALUE SPACES.*/
                public StringBasis LN26_PRI_INPC_CHEIO_MM { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
                /*"    10 FILLER                   PIC X(01) VALUE '/'.*/
                public StringBasis FILLER_113 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"    10 LN26-PRI-INPC-CHEIO-AA   PIC X(04) VALUE SPACES.*/
                public StringBasis LN26_PRI_INPC_CHEIO_AA { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
                /*"    10 FILLER                   PIC X(19) VALUE SPACES.*/
                public StringBasis FILLER_114 { get; set; } = new StringBasis(new PIC("X", "19", "X(19)"), @"");
                /*"    10 LN26-ULT-INPC-CHEIO-MM   PIC X(03) VALUE SPACES.*/
                public StringBasis LN26_ULT_INPC_CHEIO_MM { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
                /*"    10 FILLER                   PIC X(01) VALUE '/'.*/
                public StringBasis FILLER_115 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"    10 LN26-ULT-INPC-CHEIO-AA   PIC X(04) VALUE SPACES.*/
                public StringBasis LN26_ULT_INPC_CHEIO_AA { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
                /*"    10 FILLER                   PIC X(01) VALUE SPACES.*/
                public StringBasis FILLER_116 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"    10 FILLER                   PIC X(08) VALUE    '( \/    '.*/
                public StringBasis FILLER_117 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"( \/    ");
                /*"    10 LN26-INPC-PRO-RATA-MM    PIC X(03) VALUE SPACES.*/
                public StringBasis LN26_INPC_PRO_RATA_MM { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
                /*"    10 FILLER                   PIC X(01) VALUE '/'.*/
                public StringBasis FILLER_118 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"    10 LN26-INPC-PRO-RATA-AA    PIC X(02) VALUE SPACES.*/
                public StringBasis LN26_INPC_PRO_RATA_AA { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
                /*"    10 FILLER                   PIC X(22) VALUE    ' )'.*/
                public StringBasis FILLER_119 { get; set; } = new StringBasis(new PIC("X", "22", "X(22)"), @" )");
                /*"  05 LN27.*/
            }
            public SI0077B_LN27 LN27 { get; set; } = new SI0077B_LN27();
            public class SI0077B_LN27 : VarBasis
            {
                /*"    10 FILLER                   PIC X(30) VALUE    'SLD. CORRIGIDO (E) EM (C) ...:'.*/
                public StringBasis FILLER_120 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"SLD. CORRIGIDO (E) EM (C) ...:");
                /*"    10 LN27-SALDO-CORRIGIDO     PIC ZZZ.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LN27_SALDO_CORRIGIDO { get; set; } = new DoubleBasis(new PIC("9", "12", "ZZZ.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"    10 FILLER                   PIC X(32) VALUE SPACES.*/
                public StringBasis FILLER_121 { get; set; } = new StringBasis(new PIC("X", "32", "X(32)"), @"");
                /*"  05 LN28.*/
            }
            public SI0077B_LN28 LN28 { get; set; } = new SI0077B_LN28();
            public class SI0077B_LN28 : VarBasis
            {
                /*"    10 FILLER                   PIC X(30) VALUE    'JUROS ATUALIZADOS (F) .......:'.*/
                public StringBasis FILLER_122 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"JUROS ATUALIZADOS (F) .......:");
                /*"    10 LN28-JUROS               PIC ZZ9,99.*/
                public DoubleBasis LN28_JUROS { get; set; } = new DoubleBasis(new PIC("9", "3", "ZZ9V99."), 2);
                /*"    10 FILLER                   PIC X(44) VALUE ' A.A.'.*/
                public StringBasis FILLER_123 { get; set; } = new StringBasis(new PIC("X", "44", "X(44)"), @" A.A.");
                /*"  05 LN29.*/
            }
            public SI0077B_LN29 LN29 { get; set; } = new SI0077B_LN29();
            public class SI0077B_LN29 : VarBasis
            {
                /*"    10 FILLER                   PIC X(26) VALUE SPACES.*/
                public StringBasis FILLER_124 { get; set; } = new StringBasis(new PIC("X", "26", "X(26)"), @"");
                /*"    10 FILLER                   PIC X(54) VALUE    '(    (   (F)      ))   (PERC. PARTICIPACAO)'.*/
                public StringBasis FILLER_125 { get; set; } = new StringBasis(new PIC("X", "54", "X(54)"), @"(    (   (F)      ))   (PERC. PARTICIPACAO)");
                /*"  05 LN30.*/
            }
            public SI0077B_LN30 LN30 { get; set; } = new SI0077B_LN30();
            public class SI0077B_LN30 : VarBasis
            {
                /*"    10 FILLER                   PIC X(26) VALUE    'VALOR INDENIZACAO = (E) X '.*/
                public StringBasis FILLER_126 { get; set; } = new StringBasis(new PIC("X", "26", "X(26)"), @"VALOR INDENIZACAO = (E) X ");
                /*"    10 FILLER                   PIC X(54) VALUE    '(1 + (  ----- X I )) X (------------------)'.*/
                public StringBasis FILLER_127 { get; set; } = new StringBasis(new PIC("X", "54", "X(54)"), @"(1 + (  ----- X I )) X (------------------)");
                /*"  05 LN31.*/
            }
            public SI0077B_LN31 LN31 { get; set; } = new SI0077B_LN31();
            public class SI0077B_LN31 : VarBasis
            {
                /*"    10 FILLER                   PIC X(26) VALUE SPACES.*/
                public StringBasis FILLER_128 { get; set; } = new StringBasis(new PIC("X", "26", "X(26)"), @"");
                /*"    10 FILLER                   PIC X(54) VALUE    '(    (  36000     ))   (        100       )'.*/
                public StringBasis FILLER_129 { get; set; } = new StringBasis(new PIC("X", "54", "X(54)"), @"(    (  36000     ))   (        100       )");
                /*"  05 LN32.*/
            }
            public SI0077B_LN32 LN32 { get; set; } = new SI0077B_LN32();
            public class SI0077B_LN32 : VarBasis
            {
                /*"    10 FILLER                   PIC X(22) VALUE    'VALOR DA INDENIZACAO: '.*/
                public StringBasis FILLER_130 { get; set; } = new StringBasis(new PIC("X", "22", "X(22)"), @"VALOR DA INDENIZACAO: ");
                /*"    10 LN32-VALOR-INDENIZACAO   PIC ZZZ.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LN32_VALOR_INDENIZACAO { get; set; } = new DoubleBasis(new PIC("9", "12", "ZZZ.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"    10 FILLER                   PIC X(40) VALUE SPACES.*/
                public StringBasis FILLER_131 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"  05 LN33.*/
            }
            public SI0077B_LN33 LN33 { get; set; } = new SI0077B_LN33();
            public class SI0077B_LN33 : VarBasis
            {
                /*"    10 FILLER                   PIC X(80) VALUE    'INPC UTILIZADOS PARA CALCULO:'.*/
                public StringBasis FILLER_132 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"INPC UTILIZADOS PARA CALCULO:");
                /*"  05 LN34.*/
            }
            public SI0077B_LN34 LN34 { get; set; } = new SI0077B_LN34();
            public class SI0077B_LN34 : VarBasis
            {
                /*"    10 FILLER                   PIC X(01) VALUE SPACES.*/
                public StringBasis FILLER_133 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"    10 FILLER                   OCCURS  3  TIMES.*/
                public ListBasis<SI0077B_FILLER_134> FILLER_134 { get; set; } = new ListBasis<SI0077B_FILLER_134>(3);
                public class SI0077B_FILLER_134 : VarBasis
                {
                    /*"       15 LN34-INPC-MM          PIC X(03) VALUE SPACES.*/
                    public StringBasis LN34_INPC_MM { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
                    /*"       15 LN34-FILLER1          PIC X(02) VALUE '  '.*/
                    public StringBasis LN34_FILLER1 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"  ");
                    /*"       15 LN34-INPC-AA          PIC 9(04).*/
                    public IntBasis LN34_INPC_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                    /*"       15 LN34-FILLER2          PIC X(01) VALUE ' '.*/
                    public StringBasis LN34_FILLER2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                    /*"       15 LN34-VALOR-INPC       PIC Z9,9999.*/
                    public DoubleBasis LN34_VALOR_INPC { get; set; } = new DoubleBasis(new PIC("9", "2", "Z9V9999."), 4);
                    /*"       15 FILLER                PIC X(03) VALUE SPACES.*/
                    public StringBasis FILLER_135 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
                    /*"    10 FILLER                   PIC X(20) VALUE SPACES.*/
                }
                public StringBasis FILLER_136 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"");
                /*"  05 LN40.*/
            }
            public SI0077B_LN40 LN40 { get; set; } = new SI0077B_LN40();
            public class SI0077B_LN40 : VarBasis
            {
                /*"    10 FILLER                   PIC X(020) VALUE SPACES.*/
                public StringBasis FILLER_137 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"    10 FILLER                   PIC X(010) VALUE 'BRASILIA, '.*/
                public StringBasis FILLER_138 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"BRASILIA, ");
                /*"    10 LN40-DIA                 PIC 9(002) VALUE ZEROS.*/
                public IntBasis LN40_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10 FILLER                   PIC X(004) VALUE    ' DE '.*/
                public StringBasis FILLER_139 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @" DE ");
                /*"    10 LN40-MES                 PIC X(011) VALUE SPACES.*/
                public StringBasis LN40_MES { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"");
                /*"    10 FILLER                   PIC X(004) VALUE    ' DE '.*/
                public StringBasis FILLER_140 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @" DE ");
                /*"    10 LN40-ANO                 PIC 9(004) VALUE ZEROS.*/
                public IntBasis LN40_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10 FILLER                   PIC X(013) VALUE SPACES.*/
                public StringBasis FILLER_141 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
                /*"  05 LN41.*/
            }
            public SI0077B_LN41 LN41 { get; set; } = new SI0077B_LN41();
            public class SI0077B_LN41 : VarBasis
            {
                /*"    10 FILLER                   PIC X(020) VALUE SPACES.*/
                public StringBasis FILLER_142 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"    10 FILLER                   PIC X(035) VALUE ALL '-'.*/
                public StringBasis FILLER_143 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"ALL");
                /*"    10 FILLER                   PIC X(035) VALUE SPACES.*/
                public StringBasis FILLER_144 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"");
            }
        }


        public SI0077B_V0SINIHABIT4 V0SINIHABIT4 { get; set; } = new SI0077B_V0SINIHABIT4();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SIHAPLAN_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SIHAPLAN.SetFile(SIHAPLAN_FILE_NAME_P);

                /*" -608- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -610- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -612- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -615- PERFORM 010-SELECT-V0RELATORIOS THRU 010-EXIT. */

                M_010_SELECT_V0RELATORIOS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_010_EXIT*/


                /*" -616- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -617- PERFORM 020-SELECT-V0SISTEMA THRU 020-EXIT */

                    M_020_SELECT_V0SISTEMA(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_020_EXIT*/


                    /*" -618- MOVE V0SISTEMA-DTMOVABE TO W-DATA-SELECAO */
                    _.Move(V0SISTEMA_DTMOVABE, W_DATA_SELECAO);

                    /*" -619- ELSE */
                }
                else
                {


                    /*" -620- MOVE V0RELATORIOS-DATA-REFERENCIA TO W-DATA-SELECAO */
                    _.Move(V0RELATORIOS_DATA_REFERENCIA, W_DATA_SELECAO);

                    /*" -622- MOVE 'SIM' TO W-ACHOU-V0RELATORIOS. */
                    _.Move("SIM", AREA_DE_WORK.W_ACHOU_V0RELATORIOS);
                }


                /*" -623- PERFORM 030-DECLARE-V0SINIHABIT4 THRU 030-EXIT */

                M_030_DECLARE_V0SINIHABIT4(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_030_EXIT*/


                /*" -624- MOVE 'NAO' TO WFIM-V0SINIHABIT4. */
                _.Move("NAO", AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.WFIM_V0SINIHABIT4);

                /*" -625- PERFORM 040-FETCH-V0SINIHABIT4 THRU 040-EXIT. */

                M_040_FETCH_V0SINIHABIT4(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_040_EXIT*/


                /*" -626- IF WFIM-V0SINIHABIT4 EQUAL 'SIM' */

                if (AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.WFIM_V0SINIHABIT4 == "SIM")
                {

                    /*" -627- DISPLAY '/////////////////////////////////////////' */
                    _.Display($"/////////////////////////////////////////");

                    /*" -628- DISPLAY '//                                     //' */
                    _.Display($"//                                     //");

                    /*" -629- DISPLAY '//     ==>     SI0077B      <==        //' */
                    _.Display($"//     ==>     SI0077B      <==        //");

                    /*" -630- DISPLAY '//                                     //' */
                    _.Display($"//                                     //");

                    /*" -631- DISPLAY '// ==>  NENHUMA PLANILHA FOI       <== //' */
                    _.Display($"// ==>  NENHUMA PLANILHA FOI       <== //");

                    /*" -632- DISPLAY '// ==>  SELECIONADA PARA IMPRESSAO <== //' */
                    _.Display($"// ==>  SELECIONADA PARA IMPRESSAO <== //");

                    /*" -633- DISPLAY '//                                     //' */
                    _.Display($"//                                     //");

                    /*" -634- DISPLAY '/////////////////////////////////////////' */
                    _.Display($"/////////////////////////////////////////");

                    /*" -635- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -637- DISPLAY 'SELECAO DA V0RELATORIOS (?) = ' W-ACHOU-V0RELATORIOS */
                    _.Display($"SELECAO DA V0RELATORIOS (?) = {AREA_DE_WORK.W_ACHOU_V0RELATORIOS}");

                    /*" -638- DISPLAY 'DATA DE SELECAO = ' W-DATA-SELECAO */
                    _.Display($"DATA DE SELECAO = {W_DATA_SELECAO}");

                    /*" -640- GO TO 9999-00-ENCERRA. */

                    M_9999_00_ENCERRA(); //GOTO
                    return Result;
                }


                /*" -642- OPEN OUTPUT SIHAPLAN. */
                SIHAPLAN.Open(REG_SIHAPLAN);

                /*" -643- MOVE W-DATA-SELECAO TO W-DATA-1. */
                _.Move(W_DATA_SELECAO, AREA_DE_WORK.W_DATA_1);

                /*" -644- MOVE W-DD-DATA-1 TO LN40-DIA. */
                _.Move(AREA_DE_WORK.W_DATA_1.W_DD_DATA_1, WAREA_3.LN40.LN40_DIA);

                /*" -645- MOVE WS-TAB-MES-INT(W-MM-DATA-1) TO LN40-MES. */
                _.Move(TABELA_DE_MESES_INTEIRO.FILLER_40[AREA_DE_WORK.W_DATA_1.W_MM_DATA_1].WS_TAB_MES_INT, WAREA_3.LN40.LN40_MES);

                /*" -647- MOVE W-AA-DATA-1 TO LN40-ANO. */
                _.Move(AREA_DE_WORK.W_DATA_1.W_AA_DATA_1, WAREA_3.LN40.LN40_ANO);

                /*" -650- PERFORM M-100-PROCESSA-V0SINIHABIT4 THRU 100-EXIT UNTIL (WFIM-V0SINIHABIT4 EQUAL 'SIM' ). */

                while (!((AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.WFIM_V0SINIHABIT4 == "SIM")))
                {

                    M_100_PROCESSA_V0SINIHABIT4(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_EXIT*/

                }

                /*" -650- CLOSE SIHAPLAN. */
                SIHAPLAN.Close();

                /*" -650- FLUXCONTROL_PERFORM M-9999-00-ENCERRA */

                M_9999_00_ENCERRA();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" M-9999-00-ENCERRA */
        private void M_9999_00_ENCERRA(bool isPerform = false)
        {
            /*" -655- IF W-ACHOU-V0RELATORIOS EQUAL 'SIM' */

            if (AREA_DE_WORK.W_ACHOU_V0RELATORIOS == "SIM")
            {

                /*" -656- MOVE '001' TO WNR-EXEC-SQL */
                _.Move("001", WAREA_3.WABEND.WNR_EXEC_SQL);

                /*" -660- PERFORM M_9999_00_ENCERRA_DB_DELETE_1 */

                M_9999_00_ENCERRA_DB_DELETE_1();

                /*" -663- DISPLAY '/////////////////////////////////////////' */
                _.Display($"/////////////////////////////////////////");

                /*" -664- DISPLAY '/////////////////////////////////////////' */
                _.Display($"/////////////////////////////////////////");

                /*" -665- DISPLAY '//     ==>     SI0077B      <==        //' */
                _.Display($"//     ==>     SI0077B      <==        //");

                /*" -666- DISPLAY '//     ==>  TERMINO NORMAL  <==        //' */
                _.Display($"//     ==>  TERMINO NORMAL  <==        //");

                /*" -667- DISPLAY '/////////////////////////////////////////' */
                _.Display($"/////////////////////////////////////////");

                /*" -668- DISPLAY '/////////////////////////////////////////' . */
                _.Display($"/////////////////////////////////////////");
            }


            /*" -669- DISPLAY 'TOTAL DE PLANILHAS IMPRESSAS = ' W-AC-LIDOS */
            _.Display($"TOTAL DE PLANILHAS IMPRESSAS = {AREA_DE_WORK.W_AC_LIDOS}");

            /*" -670- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -670- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-9999-00-ENCERRA-DB-DELETE-1 */
        public void M_9999_00_ENCERRA_DB_DELETE_1()
        {
            /*" -660- EXEC SQL DELETE FROM SEGUROS.V0RELATORIOS WHERE CODRELAT = 'SI0077B' AND IDSISTEM = 'SI' END-EXEC. */

            var m_9999_00_ENCERRA_DB_DELETE_1_Delete1 = new M_9999_00_ENCERRA_DB_DELETE_1_Delete1()
            {
            };

            M_9999_00_ENCERRA_DB_DELETE_1_Delete1.Execute(m_9999_00_ENCERRA_DB_DELETE_1_Delete1);

        }

        [StopWatch]
        /*" M-010-SELECT-V0RELATORIOS */
        private void M_010_SELECT_V0RELATORIOS(bool isPerform = false)
        {
            /*" -677- MOVE '002' TO WNR-EXEC-SQL. */
            _.Move("002", WAREA_3.WABEND.WNR_EXEC_SQL);

            /*" -683- PERFORM M_010_SELECT_V0RELATORIOS_DB_SELECT_1 */

            M_010_SELECT_V0RELATORIOS_DB_SELECT_1();

        }

        [StopWatch]
        /*" M-010-SELECT-V0RELATORIOS-DB-SELECT-1 */
        public void M_010_SELECT_V0RELATORIOS_DB_SELECT_1()
        {
            /*" -683- EXEC SQL SELECT DATA_REFERENCIA INTO :V0RELATORIOS-DATA-REFERENCIA FROM SEGUROS.V0RELATORIOS WHERE CODRELAT = 'SI0077B' AND IDSISTEM = 'SI' END-EXEC. */

            var m_010_SELECT_V0RELATORIOS_DB_SELECT_1_Query1 = new M_010_SELECT_V0RELATORIOS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_010_SELECT_V0RELATORIOS_DB_SELECT_1_Query1.Execute(m_010_SELECT_V0RELATORIOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RELATORIOS_DATA_REFERENCIA, V0RELATORIOS_DATA_REFERENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_010_EXIT*/

        [StopWatch]
        /*" M-020-SELECT-V0SISTEMA */
        private void M_020_SELECT_V0SISTEMA(bool isPerform = false)
        {
            /*" -691- MOVE '003' TO WNR-EXEC-SQL. */
            _.Move("003", WAREA_3.WABEND.WNR_EXEC_SQL);

            /*" -696- PERFORM M_020_SELECT_V0SISTEMA_DB_SELECT_1 */

            M_020_SELECT_V0SISTEMA_DB_SELECT_1();

        }

        [StopWatch]
        /*" M-020-SELECT-V0SISTEMA-DB-SELECT-1 */
        public void M_020_SELECT_V0SISTEMA_DB_SELECT_1()
        {
            /*" -696- EXEC SQL SELECT DTMOVABE INTO :V0SISTEMA-DTMOVABE FROM SEGUROS.V0SISTEMA WHERE IDSISTEM = 'SI' END-EXEC. */

            var m_020_SELECT_V0SISTEMA_DB_SELECT_1_Query1 = new M_020_SELECT_V0SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_020_SELECT_V0SISTEMA_DB_SELECT_1_Query1.Execute(m_020_SELECT_V0SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SISTEMA_DTMOVABE, V0SISTEMA_DTMOVABE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_020_EXIT*/

        [StopWatch]
        /*" M-030-DECLARE-V0SINIHABIT4 */
        private void M_030_DECLARE_V0SINIHABIT4(bool isPerform = false)
        {
            /*" -704- MOVE '004' TO WNR-EXEC-SQL. */
            _.Move("004", WAREA_3.WABEND.WNR_EXEC_SQL);

            /*" -731- PERFORM M_030_DECLARE_V0SINIHABIT4_DB_DECLARE_1 */

            M_030_DECLARE_V0SINIHABIT4_DB_DECLARE_1();

            /*" -733- PERFORM M_030_DECLARE_V0SINIHABIT4_DB_OPEN_1 */

            M_030_DECLARE_V0SINIHABIT4_DB_OPEN_1();

            /*" -736- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -737- DISPLAY 'PROBLEMAS OPEN V0SINIHABIT4 ........ ' */
                _.Display($"PROBLEMAS OPEN V0SINIHABIT4 ........ ");

                /*" -737- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-030-DECLARE-V0SINIHABIT4-DB-DECLARE-1 */
        public void M_030_DECLARE_V0SINIHABIT4_DB_DECLARE_1()
        {
            /*" -731- EXEC SQL DECLARE V0SINIHABIT4 CURSOR FOR SELECT NUM_APOL_SINISTRO , NUM_FIAP , DATA_CONTRATO , DATA_SINISTRO , DATA_INDENIZACAO , DATA_SALDO_DEVEDOR, NOME_SEGURADO , PERC_PARTICIPACAO , DIAS_M , DIAS_N , DIAS_CORRIDOS_D , PERC_JUROS , VAL_SDO_DEVEDOR , VAL_SDO_CORRIGIDO , VAL_INDENIZACAO , PRI_INPC , PRI_INPC_MMAA , ULT_INPC , ULT_INPC_MMAA , INPC_INDENI , INPC_INDENI_MMAA , INPC_PRO_RATA , TIMESTAMP FROM SEGUROS.V0SINIHABIT4 WHERE DATE(TIMESTAMP) = :W-DATA-SELECAO ORDER BY NUM_APOL_SINISTRO, TIMESTAMP END-EXEC. */
            V0SINIHABIT4 = new SI0077B_V0SINIHABIT4(true);
            string GetQuery_V0SINIHABIT4()
            {
                var query = @$"SELECT NUM_APOL_SINISTRO
							, 
							NUM_FIAP
							, 
							DATA_CONTRATO
							, 
							DATA_SINISTRO
							, 
							DATA_INDENIZACAO
							, 
							DATA_SALDO_DEVEDOR
							, 
							NOME_SEGURADO
							, 
							PERC_PARTICIPACAO
							, 
							DIAS_M
							, 
							DIAS_N
							, 
							DIAS_CORRIDOS_D
							, 
							PERC_JUROS
							, 
							VAL_SDO_DEVEDOR
							, 
							VAL_SDO_CORRIGIDO
							, 
							VAL_INDENIZACAO
							, 
							PRI_INPC
							, 
							PRI_INPC_MMAA
							, 
							ULT_INPC
							, 
							ULT_INPC_MMAA
							, 
							INPC_INDENI
							, 
							INPC_INDENI_MMAA
							, 
							INPC_PRO_RATA
							, 
							TIMESTAMP 
							FROM SEGUROS.V0SINIHABIT4 
							WHERE DATE(TIMESTAMP) = '{W_DATA_SELECAO}' 
							ORDER BY NUM_APOL_SINISTRO
							, TIMESTAMP";

                return query;
            }
            V0SINIHABIT4.GetQueryEvent += GetQuery_V0SINIHABIT4;

        }

        [StopWatch]
        /*" M-030-DECLARE-V0SINIHABIT4-DB-OPEN-1 */
        public void M_030_DECLARE_V0SINIHABIT4_DB_OPEN_1()
        {
            /*" -733- EXEC SQL OPEN V0SINIHABIT4 END-EXEC. */

            V0SINIHABIT4.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_030_EXIT*/

        [StopWatch]
        /*" M-040-FETCH-V0SINIHABIT4 */
        private void M_040_FETCH_V0SINIHABIT4(bool isPerform = false)
        {
            /*" -745- MOVE '005' TO WNR-EXEC-SQL. */
            _.Move("005", WAREA_3.WABEND.WNR_EXEC_SQL);

            /*" -770- PERFORM M_040_FETCH_V0SINIHABIT4_DB_FETCH_1 */

            M_040_FETCH_V0SINIHABIT4_DB_FETCH_1();

            /*" -773- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -774- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -775- MOVE 'SIM' TO WFIM-V0SINIHABIT4 */
                    _.Move("SIM", AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.WFIM_V0SINIHABIT4);

                    /*" -775- PERFORM M_040_FETCH_V0SINIHABIT4_DB_CLOSE_1 */

                    M_040_FETCH_V0SINIHABIT4_DB_CLOSE_1();

                    /*" -777- ELSE */
                }
                else
                {


                    /*" -778- DISPLAY 'PROBLEMAS NO FETCH DA V0SINIHABIT4 ........' */
                    _.Display($"PROBLEMAS NO FETCH DA V0SINIHABIT4 ........");

                    /*" -780- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;
                }

            }


            /*" -780- ADD 1 TO W-AC-LIDOS. */
            AREA_DE_WORK.W_AC_LIDOS.Value = AREA_DE_WORK.W_AC_LIDOS + 1;

        }

        [StopWatch]
        /*" M-040-FETCH-V0SINIHABIT4-DB-FETCH-1 */
        public void M_040_FETCH_V0SINIHABIT4_DB_FETCH_1()
        {
            /*" -770- EXEC SQL FETCH V0SINIHABIT4 INTO :V0HABIT4-NUM-APOL-SINISTRO , :V0HABIT4-NUM-FIAP , :V0HABIT4-DATA-CONTRATO , :V0HABIT4-DATA-SINISTRO , :V0HABIT4-DATA-INDENIZACAO , :V0HABIT4-DATA-SALDO-DEVEDOR, :V0HABIT4-NOME-SEGURADO , :V0HABIT4-PERC-PARTICIPACAO , :V0HABIT4-DIAS-M , :V0HABIT4-DIAS-N , :V0HABIT4-DIAS-CORRIDOS-D , :V0HABIT4-PERC-JUROS , :V0HABIT4-VAL-SDO-DEVEDOR , :V0HABIT4-VAL-SDO-CORRIGIDO , :V0HABIT4-VAL-INDENIZACAO , :V0HABIT4-PRI-INPC , :V0HABIT4-PRI-INPC-MMAA , :V0HABIT4-ULT-INPC , :V0HABIT4-ULT-INPC-MMAA , :V0HABIT4-INPC-INDENI , :V0HABIT4-INPC-INDENI-MMAA , :V0HABIT4-INPC-PRO-RATA , :V0HABIT4-TIMESTAMP END-EXEC. */

            if (V0SINIHABIT4.Fetch())
            {
                _.Move(V0SINIHABIT4.V0HABIT4_NUM_APOL_SINISTRO, V0HABIT4_NUM_APOL_SINISTRO);
                _.Move(V0SINIHABIT4.V0HABIT4_NUM_FIAP, V0HABIT4_NUM_FIAP);
                _.Move(V0SINIHABIT4.V0HABIT4_DATA_CONTRATO, V0HABIT4_DATA_CONTRATO);
                _.Move(V0SINIHABIT4.V0HABIT4_DATA_SINISTRO, V0HABIT4_DATA_SINISTRO);
                _.Move(V0SINIHABIT4.V0HABIT4_DATA_INDENIZACAO, V0HABIT4_DATA_INDENIZACAO);
                _.Move(V0SINIHABIT4.V0HABIT4_DATA_SALDO_DEVEDOR, V0HABIT4_DATA_SALDO_DEVEDOR);
                _.Move(V0SINIHABIT4.V0HABIT4_NOME_SEGURADO, V0HABIT4_NOME_SEGURADO);
                _.Move(V0SINIHABIT4.V0HABIT4_PERC_PARTICIPACAO, V0HABIT4_PERC_PARTICIPACAO);
                _.Move(V0SINIHABIT4.V0HABIT4_DIAS_M, V0HABIT4_DIAS_M);
                _.Move(V0SINIHABIT4.V0HABIT4_DIAS_N, V0HABIT4_DIAS_N);
                _.Move(V0SINIHABIT4.V0HABIT4_DIAS_CORRIDOS_D, V0HABIT4_DIAS_CORRIDOS_D);
                _.Move(V0SINIHABIT4.V0HABIT4_PERC_JUROS, V0HABIT4_PERC_JUROS);
                _.Move(V0SINIHABIT4.V0HABIT4_VAL_SDO_DEVEDOR, V0HABIT4_VAL_SDO_DEVEDOR);
                _.Move(V0SINIHABIT4.V0HABIT4_VAL_SDO_CORRIGIDO, V0HABIT4_VAL_SDO_CORRIGIDO);
                _.Move(V0SINIHABIT4.V0HABIT4_VAL_INDENIZACAO, V0HABIT4_VAL_INDENIZACAO);
                _.Move(V0SINIHABIT4.V0HABIT4_PRI_INPC, V0HABIT4_PRI_INPC);
                _.Move(V0SINIHABIT4.V0HABIT4_PRI_INPC_MMAA, V0HABIT4_PRI_INPC_MMAA);
                _.Move(V0SINIHABIT4.V0HABIT4_ULT_INPC, V0HABIT4_ULT_INPC);
                _.Move(V0SINIHABIT4.V0HABIT4_ULT_INPC_MMAA, V0HABIT4_ULT_INPC_MMAA);
                _.Move(V0SINIHABIT4.V0HABIT4_INPC_INDENI, V0HABIT4_INPC_INDENI);
                _.Move(V0SINIHABIT4.V0HABIT4_INPC_INDENI_MMAA, V0HABIT4_INPC_INDENI_MMAA);
                _.Move(V0SINIHABIT4.V0HABIT4_INPC_PRO_RATA, V0HABIT4_INPC_PRO_RATA);
                _.Move(V0SINIHABIT4.V0HABIT4_TIMESTAMP, V0HABIT4_TIMESTAMP);
            }

        }

        [StopWatch]
        /*" M-040-FETCH-V0SINIHABIT4-DB-CLOSE-1 */
        public void M_040_FETCH_V0SINIHABIT4_DB_CLOSE_1()
        {
            /*" -775- EXEC SQL CLOSE V0SINIHABIT4 END-EXEC */

            V0SINIHABIT4.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_040_EXIT*/

        [StopWatch]
        /*" M-100-PROCESSA-V0SINIHABIT4 */
        private void M_100_PROCESSA_V0SINIHABIT4(bool isPerform = false)
        {
            /*" -787- MOVE 1 TO W-INDICE. */
            _.Move(1, AREA_DE_WORK.W_INDICE);

            /*" -790- PERFORM 105-ZERA-TABELA-INPC THRU 105-EXIT UNTIL (W-INDICE GREATER 120). */

            while (!((AREA_DE_WORK.W_INDICE > 120)))
            {

                M_105_ZERA_TABELA_INPC(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_105_EXIT*/

            }

            /*" -792- PERFORM 110-SELECT-V0MESTSINI THRU 110-EXIT. */

            M_110_SELECT_V0MESTSINI(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_110_EXIT*/


            /*" -794- PERFORM 115-SELECT-V0SINICAUSA THRU 115-EXIT. */

            M_115_SELECT_V0SINICAUSA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_115_EXIT*/


            /*" -796- PERFORM 120-SELECT-ENDER-HABIT THRU 120-EXIT. */

            M_120_SELECT_ENDER_HABIT(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_120_EXIT*/


            /*" -798- MOVE V0END-COD-CLIENTE TO V0CLIENTE-COD-CLIENTE */
            _.Move(V0END_COD_CLIENTE, V0CLIENTE_COD_CLIENTE);

            /*" -800- PERFORM 140-SELECT-ESTIPULANTE THRU 140-EXIT. */

            M_140_SELECT_ESTIPULANTE(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_140_EXIT*/


            /*" -802- PERFORM 150-SELECIONA-INPC THRU 150-EXIT. */

            M_150_SELECIONA_INPC(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_150_EXIT*/


            /*" -804- PERFORM 300-IMPRIME-PLANILHA THRU 300-EXIT. */

            M_300_IMPRIME_PLANILHA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_300_EXIT*/


            /*" -804- PERFORM 040-FETCH-V0SINIHABIT4 THRU 040-EXIT. */

            M_040_FETCH_V0SINIHABIT4(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_040_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_EXIT*/

        [StopWatch]
        /*" M-105-ZERA-TABELA-INPC */
        private void M_105_ZERA_TABELA_INPC(bool isPerform = false)
        {
            /*" -812- MOVE ZEROS TO W-ANO-INPC(W-INDICE) W-VALOR-INPC(W-INDICE). */
            _.Move(0, TABELA_DE_INPC.W_OCORRENCIA_INPC[AREA_DE_WORK.W_INDICE].W_ANO_INPC, TABELA_DE_INPC.W_OCORRENCIA_INPC[AREA_DE_WORK.W_INDICE].W_VALOR_INPC);

            /*" -813- MOVE SPACES TO W-MES-INPC(W-INDICE). */
            _.Move("", TABELA_DE_INPC.W_OCORRENCIA_INPC[AREA_DE_WORK.W_INDICE].W_MES_INPC);

            /*" -813- ADD 1 TO W-INDICE. */
            AREA_DE_WORK.W_INDICE.Value = AREA_DE_WORK.W_INDICE + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_105_EXIT*/

        [StopWatch]
        /*" M-110-SELECT-V0MESTSINI */
        private void M_110_SELECT_V0MESTSINI(bool isPerform = false)
        {
            /*" -821- MOVE '006' TO WNR-EXEC-SQL. */
            _.Move("006", WAREA_3.WABEND.WNR_EXEC_SQL);

            /*" -834- PERFORM M_110_SELECT_V0MESTSINI_DB_SELECT_1 */

            M_110_SELECT_V0MESTSINI_DB_SELECT_1();

            /*" -837- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -838- DISPLAY 'PROBLEMAS SELECT DA V0MESTSINI ...' */
                _.Display($"PROBLEMAS SELECT DA V0MESTSINI ...");

                /*" -838- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-110-SELECT-V0MESTSINI-DB-SELECT-1 */
        public void M_110_SELECT_V0MESTSINI_DB_SELECT_1()
        {
            /*" -834- EXEC SQL SELECT NUM_APOLICE, CODCAU, RAMO, NUMIRB, DATORR INTO :V0MEST-NUM-APOLICE, :V0MEST-CODCAU, :V0MEST-RAMO, :V0MEST-NUMIRB, :V0MEST-DATORR FROM SEGUROS.V0MESTSINI WHERE NUM_APOL_SINISTRO = :V0HABIT4-NUM-APOL-SINISTRO END-EXEC. */

            var m_110_SELECT_V0MESTSINI_DB_SELECT_1_Query1 = new M_110_SELECT_V0MESTSINI_DB_SELECT_1_Query1()
            {
                V0HABIT4_NUM_APOL_SINISTRO = V0HABIT4_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = M_110_SELECT_V0MESTSINI_DB_SELECT_1_Query1.Execute(m_110_SELECT_V0MESTSINI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0MEST_NUM_APOLICE, V0MEST_NUM_APOLICE);
                _.Move(executed_1.V0MEST_CODCAU, V0MEST_CODCAU);
                _.Move(executed_1.V0MEST_RAMO, V0MEST_RAMO);
                _.Move(executed_1.V0MEST_NUMIRB, V0MEST_NUMIRB);
                _.Move(executed_1.V0MEST_DATORR, V0MEST_DATORR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_110_EXIT*/

        [StopWatch]
        /*" M-115-SELECT-V0SINICAUSA */
        private void M_115_SELECT_V0SINICAUSA(bool isPerform = false)
        {
            /*" -846- MOVE '007' TO WNR-EXEC-SQL. */
            _.Move("007", WAREA_3.WABEND.WNR_EXEC_SQL);

            /*" -852- PERFORM M_115_SELECT_V0SINICAUSA_DB_SELECT_1 */

            M_115_SELECT_V0SINICAUSA_DB_SELECT_1();

            /*" -855- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -856- DISPLAY 'PROBLEMAS SELECT DA V0SINICAUSA...' */
                _.Display($"PROBLEMAS SELECT DA V0SINICAUSA...");

                /*" -856- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-115-SELECT-V0SINICAUSA-DB-SELECT-1 */
        public void M_115_SELECT_V0SINICAUSA_DB_SELECT_1()
        {
            /*" -852- EXEC SQL SELECT DESCAU INTO :V0CAUSA-DESCAU FROM SEGUROS.V0SINICAUSA WHERE RAMO = :V0MEST-RAMO AND CODCAU = :V0MEST-CODCAU END-EXEC. */

            var m_115_SELECT_V0SINICAUSA_DB_SELECT_1_Query1 = new M_115_SELECT_V0SINICAUSA_DB_SELECT_1_Query1()
            {
                V0MEST_CODCAU = V0MEST_CODCAU.ToString(),
                V0MEST_RAMO = V0MEST_RAMO.ToString(),
            };

            var executed_1 = M_115_SELECT_V0SINICAUSA_DB_SELECT_1_Query1.Execute(m_115_SELECT_V0SINICAUSA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CAUSA_DESCAU, V0CAUSA_DESCAU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_115_EXIT*/

        [StopWatch]
        /*" M-120-SELECT-ENDER-HABIT */
        private void M_120_SELECT_ENDER_HABIT(bool isPerform = false)
        {
            /*" -864- INITIALIZE CA-EF0100S. */
            _.Initialize(
                AREA_DE_WORK.W_DATA_2.CA_EF0100S
            );

            /*" -865- MOVE V0HABIT4-NUM-FIAP TO CA-V0HABIT4-NUM-FIAP-EF0100S. */
            _.Move(V0HABIT4_NUM_FIAP, AREA_DE_WORK.W_DATA_2.CA_EF0100S.CA_V0HABIT4_NUM_FIAP_EF0100S);

            /*" -867- MOVE V0MEST-DATORR TO CA-V0MEST-DATORR-EF0100S. */
            _.Move(V0MEST_DATORR, AREA_DE_WORK.W_DATA_2.CA_EF0100S.CA_V0MEST_DATORR_EF0100S);

            /*" -880- CALL 'EF0100S' USING CA-V0HABIT4-NUM-FIAP-EF0100S CA-V0MEST-DATORR-EF0100S CA-V0END-COD-CLIENTE-EF0100S CA-V0END-ENDER-IMOVEL-EF0100S CA-V0END-NUM-IMOVEL-EF0100S CA-V0END-COMPL-IMOVEL-EF0100S CA-V0END-BAIRRO-IMOVEL-EF0100S CA-V0END-CIDADE-IMOVEL-EF0100S CA-V0END-UF-IMOVEL-EF0100S CA-V0END-CEP-IMOVEL-EF0100S CA-SQLCODE-EF0100S. */
            _.Call("EF0100S", AREA_DE_WORK.W_DATA_2.CA_EF0100S);

            /*" -881- IF CA-SQLCODE-EF0100S NOT EQUAL ZEROS */

            if (AREA_DE_WORK.W_DATA_2.CA_EF0100S.CA_SQLCODE_EF0100S != 00)
            {

                /*" -882- IF CA-SQLCODE-EF0100S EQUAL 100 */

                if (AREA_DE_WORK.W_DATA_2.CA_EF0100S.CA_SQLCODE_EF0100S == 100)
                {

                    /*" -883- GO TO 120-EXIT */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_120_EXIT*/ //GOTO
                    return;

                    /*" -884- ELSE */
                }
                else
                {


                    /*" -885- MOVE CA-SQLCODE-EF0100S TO SQLCODE */
                    _.Move(AREA_DE_WORK.W_DATA_2.CA_EF0100S.CA_SQLCODE_EF0100S, DB.SQLCODE);

                    /*" -886- DISPLAY 'PROBLEMAS ACESSO SUBROTINA EF0100S' */
                    _.Display($"PROBLEMAS ACESSO SUBROTINA EF0100S");

                    /*" -887- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;

                    /*" -888- END-IF */
                }


                /*" -890- END-IF. */
            }


            /*" -891- MOVE CA-V0END-COD-CLIENTE-EF0100S TO V0END-COD-CLIENTE. */
            _.Move(AREA_DE_WORK.W_DATA_2.CA_EF0100S.CA_V0END_COD_CLIENTE_EF0100S, V0END_COD_CLIENTE);

            /*" -892- MOVE CA-V0END-ENDER-IMOVEL-EF0100S TO V0END-ENDER-IMOVEL. */
            _.Move(AREA_DE_WORK.W_DATA_2.CA_EF0100S.CA_V0END_ENDER_IMOVEL_EF0100S, V0END_ENDER_IMOVEL);

            /*" -893- MOVE CA-V0END-NUM-IMOVEL-EF0100S TO V0END-NUM-IMOVEL. */
            _.Move(AREA_DE_WORK.W_DATA_2.CA_EF0100S.CA_V0END_NUM_IMOVEL_EF0100S, V0END_NUM_IMOVEL);

            /*" -894- MOVE CA-V0END-COMPL-IMOVEL-EF0100S TO V0END-COMPL-IMOVEL. */
            _.Move(AREA_DE_WORK.W_DATA_2.CA_EF0100S.CA_V0END_COMPL_IMOVEL_EF0100S, V0END_COMPL_IMOVEL);

            /*" -895- MOVE CA-V0END-BAIRRO-IMOVEL-EF0100S TO V0END-BAIRRO-IMOVEL. */
            _.Move(AREA_DE_WORK.W_DATA_2.CA_EF0100S.CA_V0END_BAIRRO_IMOVEL_EF0100S, V0END_BAIRRO_IMOVEL);

            /*" -896- MOVE CA-V0END-CIDADE-IMOVEL-EF0100S TO V0END-CIDADE-IMOVEL. */
            _.Move(AREA_DE_WORK.W_DATA_2.CA_EF0100S.CA_V0END_CIDADE_IMOVEL_EF0100S, V0END_CIDADE_IMOVEL);

            /*" -897- MOVE CA-V0END-UF-IMOVEL-EF0100S TO V0END-UF-IMOVEL. */
            _.Move(AREA_DE_WORK.W_DATA_2.CA_EF0100S.CA_V0END_UF_IMOVEL_EF0100S, V0END_UF_IMOVEL);

            /*" -897- MOVE CA-V0END-CEP-IMOVEL-EF0100S TO V0END-CEP-IMOVEL. */
            _.Move(AREA_DE_WORK.W_DATA_2.CA_EF0100S.CA_V0END_CEP_IMOVEL_EF0100S, V0END_CEP_IMOVEL);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_120_EXIT*/

        [StopWatch]
        /*" M-140-SELECT-ESTIPULANTE */
        private void M_140_SELECT_ESTIPULANTE(bool isPerform = false)
        {
            /*" -905- MOVE '000' TO WNR-EXEC-SQL. */
            _.Move("000", WAREA_3.WABEND.WNR_EXEC_SQL);

            /*" -910- PERFORM M_140_SELECT_ESTIPULANTE_DB_SELECT_1 */

            M_140_SELECT_ESTIPULANTE_DB_SELECT_1();

            /*" -913- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -914- DISPLAY 'PROBLEMAS SELECT DA V0CLIENTE (ESTIPULANTE)...' */
                _.Display($"PROBLEMAS SELECT DA V0CLIENTE (ESTIPULANTE)...");

                /*" -914- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-140-SELECT-ESTIPULANTE-DB-SELECT-1 */
        public void M_140_SELECT_ESTIPULANTE_DB_SELECT_1()
        {
            /*" -910- EXEC SQL SELECT NOME_RAZAO INTO :V0CLIENTE-NOME-RAZAO FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = :V0CLIENTE-COD-CLIENTE END-EXEC. */

            var m_140_SELECT_ESTIPULANTE_DB_SELECT_1_Query1 = new M_140_SELECT_ESTIPULANTE_DB_SELECT_1_Query1()
            {
                V0CLIENTE_COD_CLIENTE = V0CLIENTE_COD_CLIENTE.ToString(),
            };

            var executed_1 = M_140_SELECT_ESTIPULANTE_DB_SELECT_1_Query1.Execute(m_140_SELECT_ESTIPULANTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CLIENTE_NOME_RAZAO, V0CLIENTE_NOME_RAZAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_140_EXIT*/

        [StopWatch]
        /*" M-150-SELECIONA-INPC */
        private void M_150_SELECIONA_INPC(bool isPerform = false)
        {
            /*" -923- MOVE V0HABIT4-PRI-INPC-MMAA TO W-PRI-INPC-CHEIO-MMAA. */
            _.Move(V0HABIT4_PRI_INPC_MMAA, AREA_DE_WORK.W_PRI_INPC_CHEIO_MMAA);

            /*" -924- MOVE W-PRI-INPC-CHEIO-AA TO W-AA-PRI-INPC-CHEIO. */
            _.Move(AREA_DE_WORK.W_PRI_INPC_CHEIO_MMAA.W_PRI_INPC_CHEIO_AA, AREA_DE_WORK.W_DATA_PRI_INPC_CHEIO.W_FILLER_1.W_AA_PRI_INPC_CHEIO);

            /*" -925- MOVE W-PRI-INPC-CHEIO-MM TO W-MM-PRI-INPC-CHEIO. */
            _.Move(AREA_DE_WORK.W_PRI_INPC_CHEIO_MMAA.W_PRI_INPC_CHEIO_MM, AREA_DE_WORK.W_DATA_PRI_INPC_CHEIO.W_MM_PRI_INPC_CHEIO);

            /*" -931- MOVE 20 TO W-DD-PRI-INPC-CHEIO. */
            _.Move(20, AREA_DE_WORK.W_DATA_PRI_INPC_CHEIO.W_DD_PRI_INPC_CHEIO);

            /*" -932- MOVE V0HABIT4-ULT-INPC-MMAA TO W-ULT-INPC-CHEIO-MMAA. */
            _.Move(V0HABIT4_ULT_INPC_MMAA, AREA_DE_WORK.W_ULT_INPC_CHEIO_MMAA);

            /*" -933- MOVE W-ULT-INPC-CHEIO-AA TO W-AA-ULT-INPC-CHEIO. */
            _.Move(AREA_DE_WORK.W_ULT_INPC_CHEIO_MMAA.W_ULT_INPC_CHEIO_AA, AREA_DE_WORK.W_DATA_ULT_INPC_CHEIO.W_FILLER_2.W_AA_ULT_INPC_CHEIO);

            /*" -934- MOVE W-ULT-INPC-CHEIO-MM TO W-MM-ULT-INPC-CHEIO. */
            _.Move(AREA_DE_WORK.W_ULT_INPC_CHEIO_MMAA.W_ULT_INPC_CHEIO_MM, AREA_DE_WORK.W_DATA_ULT_INPC_CHEIO.W_MM_ULT_INPC_CHEIO);

            /*" -938- MOVE 20 TO W-DD-ULT-INPC-CHEIO. */
            _.Move(20, AREA_DE_WORK.W_DATA_ULT_INPC_CHEIO.W_DD_ULT_INPC_CHEIO);

            /*" -939- MOVE 1 TO W-INDICE. */
            _.Move(1, AREA_DE_WORK.W_INDICE);

            /*" -941- PERFORM 153-ACESSA-V0COTACAO THRU 153-EXIT UNTIL (W-DATA-PRI-INPC-CHEIO GREATER W-DATA-ULT-INPC-CHEIO). */

            while (!((AREA_DE_WORK.W_DATA_PRI_INPC_CHEIO > AREA_DE_WORK.W_DATA_ULT_INPC_CHEIO)))
            {

                M_153_ACESSA_V0COTACAO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_153_EXIT*/

            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_150_EXIT*/

        [StopWatch]
        /*" M-153-ACESSA-V0COTACAO */
        private void M_153_ACESSA_V0COTACAO(bool isPerform = false)
        {
            /*" -949- MOVE W-DATA-PRI-INPC-CHEIO TO V0COTACAO-DTINIVIG. */
            _.Move(AREA_DE_WORK.W_DATA_PRI_INPC_CHEIO, V0COTACAO_DTINIVIG);

            /*" -951- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", WAREA_3.WABEND.WNR_EXEC_SQL);

            /*" -958- PERFORM M_153_ACESSA_V0COTACAO_DB_SELECT_1 */

            M_153_ACESSA_V0COTACAO_DB_SELECT_1();

            /*" -961- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -962- MOVE 0 TO W-V0COTACAO-VALCPR */
                _.Move(0, W_V0COTACAO_VALCPR);

                /*" -963- DISPLAY '************************************************' */
                _.Display($"************************************************");

                /*" -964- DISPLAY '* ERRO CONTROLADO. NAO ACHOU COTACAO PARA DATA *' */
                _.Display($"* ERRO CONTROLADO. NAO ACHOU COTACAO PARA DATA *");

                /*" -965- DISPLAY '************************************************' */
                _.Display($"************************************************");

                /*" -966- DISPLAY 'CODUNIMO = 24' */
                _.Display($"CODUNIMO = 24");

                /*" -967- DISPLAY 'DTINIVIG = ' V0COTACAO-DTINIVIG */
                _.Display($"DTINIVIG = {V0COTACAO_DTINIVIG}");

                /*" -968- DISPLAY 'DTTERVIG = ' V0COTACAO-DTINIVIG */
                _.Display($"DTTERVIG = {V0COTACAO_DTINIVIG}");

                /*" -969- DISPLAY 'NUMERO SINISTRO = ' V0HABIT4-NUM-APOL-SINISTRO */
                _.Display($"NUMERO SINISTRO = {V0HABIT4_NUM_APOL_SINISTRO}");

                /*" -970- ELSE */
            }
            else
            {


                /*" -971- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -972- DISPLAY '************************************************' */
                    _.Display($"************************************************");

                    /*" -973- DISPLAY '*     ERRO NO ACESSO A TABELA DE V0COTACAO     *' */
                    _.Display($"*     ERRO NO ACESSO A TABELA DE V0COTACAO     *");

                    /*" -974- DISPLAY '************************************************' */
                    _.Display($"************************************************");

                    /*" -975- DISPLAY 'CODUNIMO = 24' */
                    _.Display($"CODUNIMO = 24");

                    /*" -976- DISPLAY 'DTINIVIG = ' V0COTACAO-DTINIVIG */
                    _.Display($"DTINIVIG = {V0COTACAO_DTINIVIG}");

                    /*" -977- DISPLAY 'DTTERVIG = ' V0COTACAO-DTINIVIG */
                    _.Display($"DTTERVIG = {V0COTACAO_DTINIVIG}");

                    /*" -978- DISPLAY 'NUMERO SINISTRO = ' V0HABIT4-NUM-APOL-SINISTRO */
                    _.Display($"NUMERO SINISTRO = {V0HABIT4_NUM_APOL_SINISTRO}");

                    /*" -980- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;
                }

            }


            /*" -981- MOVE W-V0COTACAO-VALCPR TO W-VALOR-INPC(W-INDICE). */
            _.Move(W_V0COTACAO_VALCPR, TABELA_DE_INPC.W_OCORRENCIA_INPC[AREA_DE_WORK.W_INDICE].W_VALOR_INPC);

            /*" -983- MOVE WS-TAB-MES(W-MM-PRI-INPC-CHEIO) TO W-MES-INPC(W-INDICE). */
            _.Move(TABELA_DE_MESES.FILLER_27[AREA_DE_WORK.W_DATA_PRI_INPC_CHEIO.W_MM_PRI_INPC_CHEIO].WS_TAB_MES, TABELA_DE_INPC.W_OCORRENCIA_INPC[AREA_DE_WORK.W_INDICE].W_MES_INPC);

            /*" -985- MOVE W-AA-PRI-INPC-CHEIO TO W-ANO-INPC(W-INDICE). */
            _.Move(AREA_DE_WORK.W_DATA_PRI_INPC_CHEIO.W_FILLER_1.W_AA_PRI_INPC_CHEIO, TABELA_DE_INPC.W_OCORRENCIA_INPC[AREA_DE_WORK.W_INDICE].W_ANO_INPC);

            /*" -986- ADD 1 TO W-MM-PRI-INPC-CHEIO. */
            AREA_DE_WORK.W_DATA_PRI_INPC_CHEIO.W_MM_PRI_INPC_CHEIO.Value = AREA_DE_WORK.W_DATA_PRI_INPC_CHEIO.W_MM_PRI_INPC_CHEIO + 1;

            /*" -987- IF W-MM-PRI-INPC-CHEIO EQUAL 13 */

            if (AREA_DE_WORK.W_DATA_PRI_INPC_CHEIO.W_MM_PRI_INPC_CHEIO == 13)
            {

                /*" -988- MOVE 1 TO W-MM-PRI-INPC-CHEIO */
                _.Move(1, AREA_DE_WORK.W_DATA_PRI_INPC_CHEIO.W_MM_PRI_INPC_CHEIO);

                /*" -990- ADD 1 TO W-SSAA-PRI-INPC-CHEIO. */
                AREA_DE_WORK.W_DATA_PRI_INPC_CHEIO.W_SSAA_PRI_INPC_CHEIO.Value = AREA_DE_WORK.W_DATA_PRI_INPC_CHEIO.W_SSAA_PRI_INPC_CHEIO + 1;
            }


            /*" -990- ADD 1 TO W-INDICE. */
            AREA_DE_WORK.W_INDICE.Value = AREA_DE_WORK.W_INDICE + 1;

        }

        [StopWatch]
        /*" M-153-ACESSA-V0COTACAO-DB-SELECT-1 */
        public void M_153_ACESSA_V0COTACAO_DB_SELECT_1()
        {
            /*" -958- EXEC SQL SELECT (VALCPR / 100 ) + 1 INTO :W-V0COTACAO-VALCPR FROM SEGUROS.V0COTACAO WHERE CODUNIMO = 24 AND DTINIVIG <= :V0COTACAO-DTINIVIG AND DTTERVIG >= :V0COTACAO-DTINIVIG END-EXEC. */

            var m_153_ACESSA_V0COTACAO_DB_SELECT_1_Query1 = new M_153_ACESSA_V0COTACAO_DB_SELECT_1_Query1()
            {
                V0COTACAO_DTINIVIG = V0COTACAO_DTINIVIG.ToString(),
            };

            var executed_1 = M_153_ACESSA_V0COTACAO_DB_SELECT_1_Query1.Execute(m_153_ACESSA_V0COTACAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.W_V0COTACAO_VALCPR, W_V0COTACAO_VALCPR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_153_EXIT*/

        [StopWatch]
        /*" M-300-IMPRIME-PLANILHA */
        private void M_300_IMPRIME_PLANILHA(bool isPerform = false)
        {
            /*" -997- MOVE V0CLIENTE-NOME-RAZAO TO LN03-ESTIPULANTE */
            _.Move(V0CLIENTE_NOME_RAZAO, WAREA_3.LN03.LN03_ESTIPULANTE);

            /*" -998- MOVE V0HABIT4-NUM-APOL-SINISTRO TO LN04-SINISTRO-SASSE */
            _.Move(V0HABIT4_NUM_APOL_SINISTRO, WAREA_3.LN04.LN04_SINISTRO_SASSE);

            /*" -999- MOVE V0MEST-NUMIRB TO LN04-SINISTRO-IRB */
            _.Move(V0MEST_NUMIRB, WAREA_3.LN04.LN04_SINISTRO_IRB);

            /*" -1000- MOVE V0HABIT4-NUM-FIAP TO LN05-NUM-FIAP */
            _.Move(V0HABIT4_NUM_FIAP, WAREA_3.LN05.LN05_NUM_FIAP);

            /*" -1002- MOVE V0HABIT4-NOME-SEGURADO TO LN07-NOME-SEGURADO */
            _.Move(V0HABIT4_NOME_SEGURADO, WAREA_3.LN06.LN07_NOME_SEGURADO);

            /*" -1003- MOVE V0END-ENDER-IMOVEL TO LN07-ENDER-IMOVEL */
            _.Move(V0END_ENDER_IMOVEL, WAREA_3.LN07.LN07_ENDER_IMOVEL);

            /*" -1004- MOVE V0END-NUM-IMOVEL TO LN07-NUM-IMOVEL */
            _.Move(V0END_NUM_IMOVEL, WAREA_3.LN07.LN07_NUM_IMOVEL);

            /*" -1005- MOVE V0END-CIDADE-IMOVEL TO LN08-CIDADE-IMOVEL */
            _.Move(V0END_CIDADE_IMOVEL, WAREA_3.LN08.LN08_CIDADE_IMOVEL);

            /*" -1007- MOVE V0END-UF-IMOVEL TO LN08-UF-IMOVEL */
            _.Move(V0END_UF_IMOVEL, WAREA_3.LN08.LN08_UF_IMOVEL);

            /*" -1008- MOVE V0CAUSA-DESCAU TO LN09-DESCRICAO-CAUSA */
            _.Move(V0CAUSA_DESCAU, WAREA_3.LN09.LN09_DESCRICAO_CAUSA);

            /*" -1009- MOVE V0HABIT4-DATA-SINISTRO TO W-DATA-1. */
            _.Move(V0HABIT4_DATA_SINISTRO, AREA_DE_WORK.W_DATA_1);

            /*" -1010- MOVE W-AA-DATA-1 TO W-AA-DATA-2. */
            _.Move(AREA_DE_WORK.W_DATA_1.W_AA_DATA_1, AREA_DE_WORK.W_DATA_2.W_AA_DATA_2);

            /*" -1011- MOVE W-MM-DATA-1 TO W-MM-DATA-2. */
            _.Move(AREA_DE_WORK.W_DATA_1.W_MM_DATA_1, AREA_DE_WORK.W_DATA_2.W_MM_DATA_2);

            /*" -1012- MOVE W-DD-DATA-1 TO W-DD-DATA-2. */
            _.Move(AREA_DE_WORK.W_DATA_1.W_DD_DATA_1, AREA_DE_WORK.W_DATA_2.W_DD_DATA_2);

            /*" -1013- MOVE W-DATA-2 TO LN12-DATA-SINISTRO */
            _.Move(AREA_DE_WORK.W_DATA_2, WAREA_3.LN12.LN12_DATA_SINISTRO);

            /*" -1014- MOVE V0HABIT4-DATA-SALDO-DEVEDOR TO W-DATA-1. */
            _.Move(V0HABIT4_DATA_SALDO_DEVEDOR, AREA_DE_WORK.W_DATA_1);

            /*" -1015- MOVE W-AA-DATA-1 TO W-AA-DATA-2. */
            _.Move(AREA_DE_WORK.W_DATA_1.W_AA_DATA_1, AREA_DE_WORK.W_DATA_2.W_AA_DATA_2);

            /*" -1016- MOVE W-MM-DATA-1 TO W-MM-DATA-2. */
            _.Move(AREA_DE_WORK.W_DATA_1.W_MM_DATA_1, AREA_DE_WORK.W_DATA_2.W_MM_DATA_2);

            /*" -1017- MOVE W-DD-DATA-1 TO W-DD-DATA-2. */
            _.Move(AREA_DE_WORK.W_DATA_1.W_DD_DATA_1, AREA_DE_WORK.W_DATA_2.W_DD_DATA_2);

            /*" -1019- MOVE W-DATA-2 TO LN13-DATA-SALDO-DEVEDOR LN15-DATA-SALDO-DEVEDOR */
            _.Move(AREA_DE_WORK.W_DATA_2, WAREA_3.LN13.LN13_DATA_SALDO_DEVEDOR, WAREA_3.LN15.LN15_DATA_SALDO_DEVEDOR);

            /*" -1020- MOVE V0HABIT4-DATA-INDENIZACAO TO W-DATA-1 */
            _.Move(V0HABIT4_DATA_INDENIZACAO, AREA_DE_WORK.W_DATA_1);

            /*" -1021- MOVE W-AA-DATA-1 TO W-AA-DATA-2. */
            _.Move(AREA_DE_WORK.W_DATA_1.W_AA_DATA_1, AREA_DE_WORK.W_DATA_2.W_AA_DATA_2);

            /*" -1022- MOVE W-MM-DATA-1 TO W-MM-DATA-2. */
            _.Move(AREA_DE_WORK.W_DATA_1.W_MM_DATA_1, AREA_DE_WORK.W_DATA_2.W_MM_DATA_2);

            /*" -1023- MOVE W-DD-DATA-1 TO W-DD-DATA-2. */
            _.Move(AREA_DE_WORK.W_DATA_1.W_DD_DATA_1, AREA_DE_WORK.W_DATA_2.W_DD_DATA_2);

            /*" -1024- MOVE W-DATA-2 TO LN13-DATA-INDENIZACAO */
            _.Move(AREA_DE_WORK.W_DATA_2, WAREA_3.LN14.LN13_DATA_INDENIZACAO);

            /*" -1025- MOVE V0HABIT4-VAL-SDO-DEVEDOR TO LN15-SALDO-DEVEDOR */
            _.Move(V0HABIT4_VAL_SDO_DEVEDOR, WAREA_3.LN15.LN15_SALDO_DEVEDOR);

            /*" -1026- MOVE V0HABIT4-PERC-PARTICIPACAO TO LN16-PERC-PARTICIPACAO */
            _.Move(V0HABIT4_PERC_PARTICIPACAO, WAREA_3.LN16.LN16_PERC_PARTICIPACAO);

            /*" -1027- MOVE V0HABIT4-DIAS-M TO LN17-QTD-DIAS-M */
            _.Move(V0HABIT4_DIAS_M, WAREA_3.LN17.LN17_QTD_DIAS_M);

            /*" -1028- MOVE V0HABIT4-DIAS-N TO LN17-QTD-DIAS-N */
            _.Move(V0HABIT4_DIAS_N, WAREA_3.LN19.LN17_QTD_DIAS_N);

            /*" -1029- MOVE V0HABIT4-DIAS-CORRIDOS-D TO LN17-QTD-DIAS-D */
            _.Move(V0HABIT4_DIAS_CORRIDOS_D, WAREA_3.LN21.LN17_QTD_DIAS_D);

            /*" -1030- MOVE V0HABIT4-PRI-INPC TO LN25-PRIMEIRO-INPC-CHEIO */
            _.Move(V0HABIT4_PRI_INPC, WAREA_3.LN25.LN25_PRIMEIRO_INPC_CHEIO);

            /*" -1031- MOVE V0HABIT4-ULT-INPC TO LN25-ULTIMO-INPC-CHEIO */
            _.Move(V0HABIT4_ULT_INPC, WAREA_3.LN25.LN25_ULTIMO_INPC_CHEIO);

            /*" -1033- MOVE V0HABIT4-INPC-INDENI TO LN25-INPC-PRO-RATA */
            _.Move(V0HABIT4_INPC_INDENI, WAREA_3.LN25.LN25_INPC_PRO_RATA);

            /*" -1034- MOVE V0HABIT4-PRI-INPC-MMAA TO W-PRI-INPC-CHEIO-MMAA. */
            _.Move(V0HABIT4_PRI_INPC_MMAA, AREA_DE_WORK.W_PRI_INPC_CHEIO_MMAA);

            /*" -1036- MOVE WS-TAB-MES(W-PRI-INPC-CHEIO-MM) TO LN26-PRI-INPC-CHEIO-MM. */
            _.Move(TABELA_DE_MESES.FILLER_27[AREA_DE_WORK.W_PRI_INPC_CHEIO_MMAA.W_PRI_INPC_CHEIO_MM].WS_TAB_MES, WAREA_3.LN26.LN26_PRI_INPC_CHEIO_MM);

            /*" -1038- MOVE W-PRI-INPC-CHEIO-AA TO LN26-PRI-INPC-CHEIO-AA. */
            _.Move(AREA_DE_WORK.W_PRI_INPC_CHEIO_MMAA.W_PRI_INPC_CHEIO_AA, WAREA_3.LN26.LN26_PRI_INPC_CHEIO_AA);

            /*" -1039- MOVE V0HABIT4-ULT-INPC-MMAA TO W-ULT-INPC-CHEIO-MMAA. */
            _.Move(V0HABIT4_ULT_INPC_MMAA, AREA_DE_WORK.W_ULT_INPC_CHEIO_MMAA);

            /*" -1041- MOVE WS-TAB-MES(W-ULT-INPC-CHEIO-MM) TO LN26-ULT-INPC-CHEIO-MM. */
            _.Move(TABELA_DE_MESES.FILLER_27[AREA_DE_WORK.W_ULT_INPC_CHEIO_MMAA.W_ULT_INPC_CHEIO_MM].WS_TAB_MES, WAREA_3.LN26.LN26_ULT_INPC_CHEIO_MM);

            /*" -1043- MOVE W-ULT-INPC-CHEIO-AA TO LN26-ULT-INPC-CHEIO-AA. */
            _.Move(AREA_DE_WORK.W_ULT_INPC_CHEIO_MMAA.W_ULT_INPC_CHEIO_AA, WAREA_3.LN26.LN26_ULT_INPC_CHEIO_AA);

            /*" -1044- MOVE V0HABIT4-INPC-INDENI-MMAA TO W-INPC-PRO-RATA-MMAA. */
            _.Move(V0HABIT4_INPC_INDENI_MMAA, AREA_DE_WORK.W_INPC_PRO_RATA_MMAA);

            /*" -1046- MOVE WS-TAB-MES(W-INPC-PRO-RATA-MM) TO LN26-INPC-PRO-RATA-MM. */
            _.Move(TABELA_DE_MESES.FILLER_27[AREA_DE_WORK.W_INPC_PRO_RATA_MMAA.W_INPC_PRO_RATA_MM].WS_TAB_MES, WAREA_3.LN26.LN26_INPC_PRO_RATA_MM);

            /*" -1048- MOVE W-INPC-PRO-RATA-AA TO LN26-INPC-PRO-RATA-AA. */
            _.Move(AREA_DE_WORK.W_INPC_PRO_RATA_MMAA.W_INPC_PRO_RATA_AA, WAREA_3.LN26.LN26_INPC_PRO_RATA_AA);

            /*" -1049- MOVE V0HABIT4-VAL-SDO-CORRIGIDO TO LN27-SALDO-CORRIGIDO. */
            _.Move(V0HABIT4_VAL_SDO_CORRIGIDO, WAREA_3.LN27.LN27_SALDO_CORRIGIDO);

            /*" -1050- MOVE V0HABIT4-PERC-JUROS TO LN28-JUROS. */
            _.Move(V0HABIT4_PERC_JUROS, WAREA_3.LN28.LN28_JUROS);

            /*" -1052- MOVE V0HABIT4-VAL-INDENIZACAO TO LN32-VALOR-INDENIZACAO. */
            _.Move(V0HABIT4_VAL_INDENIZACAO, WAREA_3.LN32.LN32_VALOR_INDENIZACAO);

            /*" -1053- WRITE REG-SIHAPLAN FROM LN01 AFTER NEW-PAGE. */
            _.Move(WAREA_3.LN01.GetMoveValues(), REG_SIHAPLAN);

            SIHAPLAN.Write(REG_SIHAPLAN.GetMoveValues().ToString());

            /*" -1054- WRITE REG-SIHAPLAN FROM LN02 AFTER 2. */
            _.Move(WAREA_3.LN02.GetMoveValues(), REG_SIHAPLAN);

            SIHAPLAN.Write(REG_SIHAPLAN.GetMoveValues().ToString());

            /*" -1055- WRITE REG-SIHAPLAN FROM LN03 AFTER 2. */
            _.Move(WAREA_3.LN03.GetMoveValues(), REG_SIHAPLAN);

            SIHAPLAN.Write(REG_SIHAPLAN.GetMoveValues().ToString());

            /*" -1056- WRITE REG-SIHAPLAN FROM LN04 AFTER 2. */
            _.Move(WAREA_3.LN04.GetMoveValues(), REG_SIHAPLAN);

            SIHAPLAN.Write(REG_SIHAPLAN.GetMoveValues().ToString());

            /*" -1057- WRITE REG-SIHAPLAN FROM LN05 AFTER 2. */
            _.Move(WAREA_3.LN05.GetMoveValues(), REG_SIHAPLAN);

            SIHAPLAN.Write(REG_SIHAPLAN.GetMoveValues().ToString());

            /*" -1058- WRITE REG-SIHAPLAN FROM LN06 AFTER 2. */
            _.Move(WAREA_3.LN06.GetMoveValues(), REG_SIHAPLAN);

            SIHAPLAN.Write(REG_SIHAPLAN.GetMoveValues().ToString());

            /*" -1059- WRITE REG-SIHAPLAN FROM LN07 AFTER 1. */
            _.Move(WAREA_3.LN07.GetMoveValues(), REG_SIHAPLAN);

            SIHAPLAN.Write(REG_SIHAPLAN.GetMoveValues().ToString());

            /*" -1060- WRITE REG-SIHAPLAN FROM LN08 AFTER 1. */
            _.Move(WAREA_3.LN08.GetMoveValues(), REG_SIHAPLAN);

            SIHAPLAN.Write(REG_SIHAPLAN.GetMoveValues().ToString());

            /*" -1061- WRITE REG-SIHAPLAN FROM LN09 AFTER 1. */
            _.Move(WAREA_3.LN09.GetMoveValues(), REG_SIHAPLAN);

            SIHAPLAN.Write(REG_SIHAPLAN.GetMoveValues().ToString());

            /*" -1062- WRITE REG-SIHAPLAN FROM LN10 AFTER 2. */
            _.Move(WAREA_3.LN10.GetMoveValues(), REG_SIHAPLAN);

            SIHAPLAN.Write(REG_SIHAPLAN.GetMoveValues().ToString());

            /*" -1063- WRITE REG-SIHAPLAN FROM LN11 AFTER 1. */
            _.Move(WAREA_3.LN11.GetMoveValues(), REG_SIHAPLAN);

            SIHAPLAN.Write(REG_SIHAPLAN.GetMoveValues().ToString());

            /*" -1064- WRITE REG-SIHAPLAN FROM LN12 AFTER 2. */
            _.Move(WAREA_3.LN12.GetMoveValues(), REG_SIHAPLAN);

            SIHAPLAN.Write(REG_SIHAPLAN.GetMoveValues().ToString());

            /*" -1065- WRITE REG-SIHAPLAN FROM LN13 AFTER 1. */
            _.Move(WAREA_3.LN13.GetMoveValues(), REG_SIHAPLAN);

            SIHAPLAN.Write(REG_SIHAPLAN.GetMoveValues().ToString());

            /*" -1066- WRITE REG-SIHAPLAN FROM LN14 AFTER 1. */
            _.Move(WAREA_3.LN14.GetMoveValues(), REG_SIHAPLAN);

            SIHAPLAN.Write(REG_SIHAPLAN.GetMoveValues().ToString());

            /*" -1067- WRITE REG-SIHAPLAN FROM LN15 AFTER 1. */
            _.Move(WAREA_3.LN15.GetMoveValues(), REG_SIHAPLAN);

            SIHAPLAN.Write(REG_SIHAPLAN.GetMoveValues().ToString());

            /*" -1068- WRITE REG-SIHAPLAN FROM LN16 AFTER 1. */
            _.Move(WAREA_3.LN16.GetMoveValues(), REG_SIHAPLAN);

            SIHAPLAN.Write(REG_SIHAPLAN.GetMoveValues().ToString());

            /*" -1069- WRITE REG-SIHAPLAN FROM LN17 AFTER 2. */
            _.Move(WAREA_3.LN17.GetMoveValues(), REG_SIHAPLAN);

            SIHAPLAN.Write(REG_SIHAPLAN.GetMoveValues().ToString());

            /*" -1070- WRITE REG-SIHAPLAN FROM LN18 AFTER 1. */
            _.Move(WAREA_3.LN18.GetMoveValues(), REG_SIHAPLAN);

            SIHAPLAN.Write(REG_SIHAPLAN.GetMoveValues().ToString());

            /*" -1071- WRITE REG-SIHAPLAN FROM LN19 AFTER 1. */
            _.Move(WAREA_3.LN19.GetMoveValues(), REG_SIHAPLAN);

            SIHAPLAN.Write(REG_SIHAPLAN.GetMoveValues().ToString());

            /*" -1072- WRITE REG-SIHAPLAN FROM LN20 AFTER 1. */
            _.Move(WAREA_3.LN20.GetMoveValues(), REG_SIHAPLAN);

            SIHAPLAN.Write(REG_SIHAPLAN.GetMoveValues().ToString());

            /*" -1073- WRITE REG-SIHAPLAN FROM LN21 AFTER 1. */
            _.Move(WAREA_3.LN21.GetMoveValues(), REG_SIHAPLAN);

            SIHAPLAN.Write(REG_SIHAPLAN.GetMoveValues().ToString());

            /*" -1074- WRITE REG-SIHAPLAN FROM LN22 AFTER 1. */
            _.Move(WAREA_3.LN22.GetMoveValues(), REG_SIHAPLAN);

            SIHAPLAN.Write(REG_SIHAPLAN.GetMoveValues().ToString());

            /*" -1075- WRITE REG-SIHAPLAN FROM LN23 AFTER 2. */
            _.Move(WAREA_3.LN23.GetMoveValues(), REG_SIHAPLAN);

            SIHAPLAN.Write(REG_SIHAPLAN.GetMoveValues().ToString());

            /*" -1076- WRITE REG-SIHAPLAN FROM LN24 AFTER 1. */
            _.Move(WAREA_3.LN24.GetMoveValues(), REG_SIHAPLAN);

            SIHAPLAN.Write(REG_SIHAPLAN.GetMoveValues().ToString());

            /*" -1077- WRITE REG-SIHAPLAN FROM LN25 AFTER 1. */
            _.Move(WAREA_3.LN25.GetMoveValues(), REG_SIHAPLAN);

            SIHAPLAN.Write(REG_SIHAPLAN.GetMoveValues().ToString());

            /*" -1078- WRITE REG-SIHAPLAN FROM LN26 AFTER 1. */
            _.Move(WAREA_3.LN26.GetMoveValues(), REG_SIHAPLAN);

            SIHAPLAN.Write(REG_SIHAPLAN.GetMoveValues().ToString());

            /*" -1079- WRITE REG-SIHAPLAN FROM LN27 AFTER 2. */
            _.Move(WAREA_3.LN27.GetMoveValues(), REG_SIHAPLAN);

            SIHAPLAN.Write(REG_SIHAPLAN.GetMoveValues().ToString());

            /*" -1080- WRITE REG-SIHAPLAN FROM LN28 AFTER 1. */
            _.Move(WAREA_3.LN28.GetMoveValues(), REG_SIHAPLAN);

            SIHAPLAN.Write(REG_SIHAPLAN.GetMoveValues().ToString());

            /*" -1081- WRITE REG-SIHAPLAN FROM LN29 AFTER 1. */
            _.Move(WAREA_3.LN29.GetMoveValues(), REG_SIHAPLAN);

            SIHAPLAN.Write(REG_SIHAPLAN.GetMoveValues().ToString());

            /*" -1082- WRITE REG-SIHAPLAN FROM LN30 AFTER 1. */
            _.Move(WAREA_3.LN30.GetMoveValues(), REG_SIHAPLAN);

            SIHAPLAN.Write(REG_SIHAPLAN.GetMoveValues().ToString());

            /*" -1083- WRITE REG-SIHAPLAN FROM LN31 AFTER 1. */
            _.Move(WAREA_3.LN31.GetMoveValues(), REG_SIHAPLAN);

            SIHAPLAN.Write(REG_SIHAPLAN.GetMoveValues().ToString());

            /*" -1084- WRITE REG-SIHAPLAN FROM LN32 AFTER 2. */
            _.Move(WAREA_3.LN32.GetMoveValues(), REG_SIHAPLAN);

            SIHAPLAN.Write(REG_SIHAPLAN.GetMoveValues().ToString());

            /*" -1086- WRITE REG-SIHAPLAN FROM LN33 AFTER 2. */
            _.Move(WAREA_3.LN33.GetMoveValues(), REG_SIHAPLAN);

            SIHAPLAN.Write(REG_SIHAPLAN.GetMoveValues().ToString());

            /*" -1088- MOVE 1 TO W-INDICE. */
            _.Move(1, AREA_DE_WORK.W_INDICE);

            /*" -1092- PERFORM 305-LE-TABELA-INPC THRU 305-EXIT UNTIL (W-INDICE GREATER 120) OR (W-MES-INPC(W-INDICE) EQUAL SPACES). */

            while (!((AREA_DE_WORK.W_INDICE > 120) || (TABELA_DE_INPC.W_OCORRENCIA_INPC[AREA_DE_WORK.W_INDICE].W_MES_INPC == string.Empty)))
            {

                M_305_LE_TABELA_INPC(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_305_EXIT*/

            }

            /*" -1093- WRITE REG-SIHAPLAN FROM LN40 AFTER 2. */
            _.Move(WAREA_3.LN40.GetMoveValues(), REG_SIHAPLAN);

            SIHAPLAN.Write(REG_SIHAPLAN.GetMoveValues().ToString());

            /*" -1093- WRITE REG-SIHAPLAN FROM LN41 AFTER 3. */
            _.Move(WAREA_3.LN41.GetMoveValues(), REG_SIHAPLAN);

            SIHAPLAN.Write(REG_SIHAPLAN.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_300_EXIT*/

        [StopWatch]
        /*" M-305-LE-TABELA-INPC */
        private void M_305_LE_TABELA_INPC(bool isPerform = false)
        {
            /*" -1101- MOVE 1 TO W-INDICE-IMPRIME. */
            _.Move(1, AREA_DE_WORK.W_INDICE_IMPRIME);

            /*" -1103- MOVE SPACES TO LN34. */
            _.Move("", WAREA_3.LN34);

            /*" -1108- PERFORM 310-IMPRIME-INPC THRU 310-EXIT UNTIL (W-INDICE GREATER 120) OR (W-MES-INPC(W-INDICE) EQUAL SPACES) OR (W-INDICE-IMPRIME GREATER 3). */

            while (!((AREA_DE_WORK.W_INDICE > 120) || (TABELA_DE_INPC.W_OCORRENCIA_INPC[AREA_DE_WORK.W_INDICE].W_MES_INPC == string.Empty) || (AREA_DE_WORK.W_INDICE_IMPRIME > 3)))
            {

                M_310_IMPRIME_INPC(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_310_EXIT*/

            }

            /*" -1108- WRITE REG-SIHAPLAN FROM LN34 AFTER 1. */
            _.Move(WAREA_3.LN34.GetMoveValues(), REG_SIHAPLAN);

            SIHAPLAN.Write(REG_SIHAPLAN.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_305_EXIT*/

        [StopWatch]
        /*" M-310-IMPRIME-INPC */
        private void M_310_IMPRIME_INPC(bool isPerform = false)
        {
            /*" -1116- MOVE W-MES-INPC(W-INDICE) TO LN34-INPC-MM(W-INDICE-IMPRIME) */
            _.Move(TABELA_DE_INPC.W_OCORRENCIA_INPC[AREA_DE_WORK.W_INDICE].W_MES_INPC, WAREA_3.LN34.FILLER_134[AREA_DE_WORK.W_INDICE_IMPRIME].LN34_INPC_MM);

            /*" -1118- MOVE W-ANO-INPC(W-INDICE) TO LN34-INPC-AA(W-INDICE-IMPRIME) */
            _.Move(TABELA_DE_INPC.W_OCORRENCIA_INPC[AREA_DE_WORK.W_INDICE].W_ANO_INPC, WAREA_3.LN34.FILLER_134[AREA_DE_WORK.W_INDICE_IMPRIME].LN34_INPC_AA);

            /*" -1120- MOVE W-VALOR-INPC(W-INDICE) TO LN34-VALOR-INPC(W-INDICE-IMPRIME) */
            _.Move(TABELA_DE_INPC.W_OCORRENCIA_INPC[AREA_DE_WORK.W_INDICE].W_VALOR_INPC, WAREA_3.LN34.FILLER_134[AREA_DE_WORK.W_INDICE_IMPRIME].LN34_VALOR_INPC);

            /*" -1122- MOVE './' TO LN34-FILLER1(W-INDICE-IMPRIME). */
            _.Move("./", WAREA_3.LN34.FILLER_134[AREA_DE_WORK.W_INDICE_IMPRIME].LN34_FILLER1);

            /*" -1125- MOVE ' - ' TO LN34-FILLER2(W-INDICE-IMPRIME). */
            _.Move(" - ", WAREA_3.LN34.FILLER_134[AREA_DE_WORK.W_INDICE_IMPRIME].LN34_FILLER2);

            /*" -1125- ADD 1 TO W-INDICE W-INDICE-IMPRIME. */
            AREA_DE_WORK.W_INDICE.Value = AREA_DE_WORK.W_INDICE + 1;
            AREA_DE_WORK.W_INDICE_IMPRIME.Value = AREA_DE_WORK.W_INDICE_IMPRIME + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_310_EXIT*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO */
        private void R9999_00_ROT_ERRO(bool isPerform = false)
        {
            /*" -1136- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1137- DISPLAY ' ' */
                _.Display($" ");

                /*" -1138- DISPLAY '*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*' */
                _.Display($"*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*");

                /*" -1139- DISPLAY '*  TERMINO ANORMAL DO PROGRAMA SI0077B  *' */
                _.Display($"*  TERMINO ANORMAL DO PROGRAMA SI0077B  *");

                /*" -1140- DISPLAY '*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*' */
                _.Display($"*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*");

                /*" -1141- DISPLAY ' ' */
                _.Display($" ");

                /*" -1142- DISPLAY '==> SEQUENCIAL DE ACESSO COM ERRO = ' WNR-EXEC-SQL */
                _.Display($"==> SEQUENCIAL DE ACESSO COM ERRO = {WAREA_3.WABEND.WNR_EXEC_SQL}");

                /*" -1143- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WAREA_3.WABEND2.WSQLCODE);

                /*" -1144- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], WAREA_3.WABEND2.WSQLCODE1);

                /*" -1145- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], WAREA_3.WABEND2.WSQLCODE2);

                /*" -1146- MOVE SQLCODE TO WSQLCODE3 */
                _.Move(DB.SQLCODE, WAREA_3.WSQLCODE3);

                /*" -1147- DISPLAY WABEND */
                _.Display(WAREA_3.WABEND);

                /*" -1149- DISPLAY WABEND2. */
                _.Display(WAREA_3.WABEND2);
            }


            /*" -1149- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1150- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1152- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1153- CLOSE SIHAPLAN. */
            SIHAPLAN.Close();

            /*" -1153- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_EXIT*/
    }
}