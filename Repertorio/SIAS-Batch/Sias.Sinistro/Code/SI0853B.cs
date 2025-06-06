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
using Sias.Sinistro.DB2.SI0853B;

namespace Code
{
    public class SI0853B
    {
        public bool IsCall { get; set; }

        public SI0853B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SINSITROS                          *      */
        /*"      *   PROGRAMA ...............  SI0853B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  RILDO SICO A. DE SOUZA             *      */
        /*"      *   PROGRAMADOR ............  RILDO SICO A. DE SOUZA             *      */
        /*"      *   CRIACAO ................  02/02/2001.                        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO ..... GERA ARQUIVOS DE PERDA TOTAL, PARA SALVADO.     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.02  *    24/09/2008 - CADMUS 168975 - LISIANE BRAGANCA SOARES        *      */
        /*"      *                 MUDANCA NA PLACA DO VEICULO                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *    03/03/2001 - ENRICO (PRODEXTER) - PROCURAR EB0303           *      */
        /*"      *                 INCLUSAO DA VERSAO NO ACESSO DA TABELA         *      */
        /*"      *                 V1DESCRVEI                                     *      */
        /*"      *----------------------------------------------------------------       */
        #endregion


        #region VARIABLES

        public FileBasis _NOVAPT { get; set; } = new FileBasis(new PIC("X", "288", "X(288)"));

        public FileBasis NOVAPT
        {
            get
            {
                _.Move(REG_NOVAPT, _NOVAPT); VarBasis.RedefinePassValue(REG_NOVAPT, _NOVAPT, REG_NOVAPT); return _NOVAPT;
            }
        }
        public FileBasis _PPPT { get; set; } = new FileBasis(new PIC("X", "288", "X(288)"));

        public FileBasis PPPT
        {
            get
            {
                _.Move(REG_PPPT, _PPPT); VarBasis.RedefinePassValue(REG_PPPT, _PPPT, REG_PPPT); return _PPPT;
            }
        }
        public FileBasis _PTPP { get; set; } = new FileBasis(new PIC("X", "288", "X(288)"));

        public FileBasis PTPP
        {
            get
            {
                _.Move(REG_PTPP, _PTPP); VarBasis.RedefinePassValue(REG_PTPP, _PTPP, REG_PTPP); return _PTPP;
            }
        }
        public FileBasis _PTPT { get; set; } = new FileBasis(new PIC("X", "288", "X(288)"));

        public FileBasis PTPT
        {
            get
            {
                _.Move(REG_PTPT, _PTPT); VarBasis.RedefinePassValue(REG_PTPT, _PTPT, REG_PTPT); return _PTPT;
            }
        }
        /*"01  REG-NOVAPT                  PIC X(288).*/
        public StringBasis REG_NOVAPT { get; set; } = new StringBasis(new PIC("X", "288", "X(288)."), @"");
        /*"01  REG-PPPT                    PIC X(288).*/
        public StringBasis REG_PPPT { get; set; } = new StringBasis(new PIC("X", "288", "X(288)."), @"");
        /*"01  REG-PTPP                    PIC X(288).*/
        public StringBasis REG_PTPP { get; set; } = new StringBasis(new PIC("X", "288", "X(288)."), @"");
        /*"01  REG-PTPT                    PIC X(288).*/
        public StringBasis REG_PTPT { get; set; } = new StringBasis(new PIC("X", "288", "X(288)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  AREA-DE-WORK.*/
        public SI0853B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SI0853B_AREA_DE_WORK();
        public class SI0853B_AREA_DE_WORK : VarBasis
        {
            /*"   05 WSL-SQLCODE                    PIC  9(009) VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"   05 WRESTO                         PIC S9(003) VALUE +0 COMP-3*/
            public IntBasis WRESTO { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
            /*"   05 AC-COUNT                       PIC S9(004) VALUE +0 COMP-3*/
            public IntBasis AC_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  W-INICIO-WORK.*/
        }
        public SI0853B_W_INICIO_WORK W_INICIO_WORK { get; set; } = new SI0853B_W_INICIO_WORK();
        public class SI0853B_W_INICIO_WORK : VarBasis
        {
            /*"    03 W-DT-DMA                       PIC X(010) VALUE SPACES.*/
            public StringBasis W_DT_DMA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    03 W-TOTAL-PPPT                   PIC 9(006) VALUE ZEROS.*/
            public IntBasis W_TOTAL_PPPT { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 W-TOTAL-PTPP                   PIC 9(006) VALUE ZEROS.*/
            public IntBasis W_TOTAL_PTPP { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 W-TOTAL-PTPT                   PIC 9(006) VALUE ZEROS.*/
            public IntBasis W_TOTAL_PTPT { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 W-PERDA-TOTAL                  PIC 9(002).*/

            public SelectorBasis W_PERDA_TOTAL { get; set; } = new SelectorBasis("002")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 B-PERDA-TOTAL  VALUE 10 11 12 13 14 15 16 17 18 20. */
							new SelectorItemBasis("B_PERDA_TOTAL", "10 11 12 13 14 15 16 17 18 20")
                }
            };

            /*"    03 W-FIM-NOVAPT                   PIC X(003).*/

            public SelectorBasis W_FIM_NOVAPT { get; set; } = new SelectorBasis("003")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 B-FIM-NOVAPT               VALUE 'SIM'. */
							new SelectorItemBasis("B_FIM_NOVAPT", "SIM"),
							/*" 88 B-FIM-NOVAPT-N             VALUE 'NAO'. */
							new SelectorItemBasis("B_FIM_NOVAPT_N", "NAO")
                }
            };

            /*"    03 W-FIM-PPPT                    PIC X(003).*/

            public SelectorBasis W_FIM_PPPT { get; set; } = new SelectorBasis("003")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 B-FIM-PPPT                 VALUE 'SIM'. */
							new SelectorItemBasis("B_FIM_PPPT", "SIM"),
							/*" 88 B-FIM-PPPT-N               VALUE 'NAO'. */
							new SelectorItemBasis("B_FIM_PPPT_N", "NAO")
                }
            };

            /*"    03 W-FIM-PTPP                    PIC X(003).*/

            public SelectorBasis W_FIM_PTPP { get; set; } = new SelectorBasis("003")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 B-FIM-PTPP                 VALUE 'SIM'. */
							new SelectorItemBasis("B_FIM_PTPP", "SIM"),
							/*" 88 B-FIM-PTPP-N               VALUE 'NAO'. */
							new SelectorItemBasis("B_FIM_PTPP_N", "NAO")
                }
            };

            /*"    03 W-TAB-VAZIA                   PIC X(003).*/

            public SelectorBasis W_TAB_VAZIA { get; set; } = new SelectorBasis("003")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 B-TAB-VAZIA                VALUE 'SIM'. */
							new SelectorItemBasis("B_TAB_VAZIA", "SIM"),
							/*" 88 B-TAB-VAZIA-N              VALUE 'NAO'. */
							new SelectorItemBasis("B_TAB_VAZIA_N", "NAO")
                }
            };

            /*"01  FILLER.*/
        }
        public SI0853B_FILLER_0 FILLER_0 { get; set; } = new SI0853B_FILLER_0();
        public class SI0853B_FILLER_0 : VarBasis
        {
            /*"    05 WABEND.*/
            public SI0853B_WABEND WABEND { get; set; } = new SI0853B_WABEND();
            public class SI0853B_WABEND : VarBasis
            {
                /*"       10 FILLER                     PIC  X(009) VALUE          'SI0853B '.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"SI0853B ");
                /*"       10 FILLER                     PIC  X(035) VALUE          ' *** ERRO OCORRIDO NO PARAGRAFO NR '.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @" *** ERRO OCORRIDO NO PARAGRAFO NR ");
                /*"       10 WNR-EXEC-SQL               PIC  X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"       10 FILLER                     PIC  X(013) VALUE          ' *** SQLCODE '.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"       10 WSQLCODE                   PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"01  CAB01.*/
            }
        }
        public SI0853B_CAB01 CAB01 { get; set; } = new SI0853B_CAB01();
        public class SI0853B_CAB01 : VarBasis
        {
            /*"    03 C-NUM-APOLICE             PIC  X(013) VALUE       'APOLICE'.*/
            public StringBasis C_NUM_APOLICE { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"APOLICE");
            /*"    03 FILLER                    PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 C-NOME-RAZAO              PIC  X(040) VALUE       'SEGURADO/TERCEIRO'.*/
            public StringBasis C_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"SEGURADO/TERCEIRO");
            /*"    03 FILLER                    PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 C-TIPO-PESSOA             PIC  X(002) VALUE       'TP'.*/
            public StringBasis C_TIPO_PESSOA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"TP");
            /*"    03 FILLER                    PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 C-CGCCPF                  PIC  X(014) VALUE       'CPF/CNPJ'.*/
            public StringBasis C_CGCCPF { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"CPF/CNPJ");
            /*"    03 FILLER                    PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 C-NUM-SINISTRO            PIC  X(013) VALUE       'SINISTRO'.*/
            public StringBasis C_NUM_SINISTRO { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"SINISTRO");
            /*"    03 FILLER                    PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 C-DATORR                  PIC  X(010) VALUE       'DT.OCORRE.'.*/
            public StringBasis C_DATORR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DT.OCORRE.");
            /*"    03 FILLER                    PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 C-COD-CAUSA               PIC  X(005) VALUE       'CAUSA'.*/
            public StringBasis C_COD_CAUSA { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"CAUSA");
            /*"    03 FILLER                    PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 C-DESC-CAUSA              PIC  X(040) VALUE       'DESCRICAO CAUSA'.*/
            public StringBasis C_DESC_CAUSA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"DESCRICAO CAUSA");
            /*"    03 FILLER                    PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 C-DTMOVTO                 PIC  X(010) VALUE       'DT.MOVTO'.*/
            public StringBasis C_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DT.MOVTO");
            /*"    03 FILLER                    PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 C-ITEM                    PIC  X(004) VALUE       'ITEM'.*/
            public StringBasis C_ITEM { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"ITEM");
            /*"    03 FILLER                    PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 C-ANOVEICL                PIC  X(004) VALUE       'FAB.'.*/
            public StringBasis C_ANOVEICL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"FAB.");
            /*"    03 FILLER                    PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 C-ANOMOD                  PIC  X(004) VALUE       'MOD.'.*/
            public StringBasis C_ANOMOD { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"MOD.");
            /*"    03 FILLER                    PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 C-PLACAUF                 PIC  X(002) VALUE       'UF'.*/
            public StringBasis C_PLACAUF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"UF");
            /*"    03 FILLER                    PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 C-PLACALET                PIC  X(008) VALUE       'PLACA LT'.*/
            public StringBasis C_PLACALET { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"PLACA LT");
            /*"    03 FILLER                    PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 C-PLACANR                 PIC  X(008) VALUE       'PLACA NR'.*/
            public StringBasis C_PLACANR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"PLACA NR");
            /*"    03 FILLER                    PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 C-CHASSIS                 PIC  X(020) VALUE       'CHASSIS'.*/
            public StringBasis C_CHASSIS { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"CHASSIS");
            /*"    03 FILLER                    PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 C-COD-VEICULO             PIC  X(009) VALUE       'COD.VEIC.'.*/
            public StringBasis C_COD_VEICULO { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"COD.VEIC.");
            /*"    03 FILLER                    PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 C-DESCVEIC                PIC  X(040) VALUE       'VEICULO'.*/
            public StringBasis C_DESCVEIC { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"VEICULO");
            /*"    03 FILLER                    PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 C-FONTE-EMISSAO           PIC  X(010) VALUE       'FONTE EMI.'.*/
            public StringBasis C_FONTE_EMISSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"FONTE EMI.");
            /*"    03 FILLER                    PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 C-FONTE-SINISTRO          PIC  X(010) VALUE       'FONTE SIN.'.*/
            public StringBasis C_FONTE_SINISTRO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"FONTE SIN.");
            /*"    03 FILLER                    PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"01  CAB02.*/
        }
        public SI0853B_CAB02 CAB02 { get; set; } = new SI0853B_CAB02();
        public class SI0853B_CAB02 : VarBasis
        {
            /*"    03 FILLER                    PIC  X(042) VALUE       'SINISTROS COM NOVA(S) PERDA(S) TOTA(L/IS)'.*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "42", "X(042)"), @"SINISTROS COM NOVA(S) PERDA(S) TOTA(L/IS)");
            /*"    03 CAB02-DATA-MOVIMENTO      PIC  X(010) VALUE SPACES.*/
            public StringBasis CAB02_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"01  CAB03.*/
        }
        public SI0853B_CAB03 CAB03 { get; set; } = new SI0853B_CAB03();
        public class SI0853B_CAB03 : VarBasis
        {
            /*"    03 FILLER                    PIC  X(042) VALUE       'SINISTROS QUE PASSARAM DE PP PARA PT'.*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "42", "X(042)"), @"SINISTROS QUE PASSARAM DE PP PARA PT");
            /*"    03 CAB03-DATA-MOVIMENTO      PIC  X(010) VALUE SPACES.*/
            public StringBasis CAB03_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"01  CAB04.*/
        }
        public SI0853B_CAB04 CAB04 { get; set; } = new SI0853B_CAB04();
        public class SI0853B_CAB04 : VarBasis
        {
            /*"    03 FILLER                    PIC  X(042) VALUE       'SINISTROS QUE PASSARAM DE PT PARA PP'.*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "42", "X(042)"), @"SINISTROS QUE PASSARAM DE PT PARA PP");
            /*"    03 CAB04-DATA-MOVIMENTO      PIC  X(010) VALUE SPACES.*/
            public StringBasis CAB04_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"01  CAB05.*/
        }
        public SI0853B_CAB05 CAB05 { get; set; } = new SI0853B_CAB05();
        public class SI0853B_CAB05 : VarBasis
        {
            /*"    03 FILLER                    PIC  X(042) VALUE       'SINISTROS QUE PASSARAM DE PT PARA PT'.*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "42", "X(042)"), @"SINISTROS QUE PASSARAM DE PT PARA PT");
            /*"    03 CAB05-DATA-MOVIMENTO      PIC  X(010) VALUE SPACES.*/
            public StringBasis CAB05_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"01  LD01.*/
        }
        public SI0853B_LD01 LD01 { get; set; } = new SI0853B_LD01();
        public class SI0853B_LD01 : VarBasis
        {
            /*"    03 W-NUM-APOLICE             PIC  9(013) VALUE ZEROS.*/
            public IntBasis W_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"    03 FILLER                    PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 W-NOME-RAZAO              PIC  X(040) VALUE SPACES.*/
            public StringBasis W_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"    03 FILLER                    PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 W-TIPO-PESSOA             PIC  X(002) VALUE SPACES.*/
            public StringBasis W_TIPO_PESSOA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"    03 FILLER                    PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 W-CGCCPF                  PIC  9(014) VALUE ZEROS.*/
            public IntBasis W_CGCCPF { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"    03 FILLER                    PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 W-NUM-SINISTRO            PIC  9(013) VALUE ZEROS.*/
            public IntBasis W_NUM_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"    03 FILLER                    PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 W-DATORR                  PIC  X(010) VALUE SPACES.*/
            public StringBasis W_DATORR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    03 FILLER                    PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 W-COD-CAUSA               PIC  9(005) VALUE ZEROS.*/
            public IntBasis W_COD_CAUSA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    03 FILLER                    PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 W-DESC-CAUSA              PIC  X(040) VALUE SPACES.*/
            public StringBasis W_DESC_CAUSA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"    03 FILLER                    PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 W-DTMOVTO                 PIC  X(010) VALUE SPACES.*/
            public StringBasis W_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    03 FILLER                    PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 W-ITEM                    PIC  9(004) VALUE ZEROS.*/
            public IntBasis W_ITEM { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    03 FILLER                    PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 W-ANOVEICL                PIC  9(004) VALUE ZEROS.*/
            public IntBasis W_ANOVEICL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    03 FILLER                    PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 W-ANOMOD                  PIC  9(004) VALUE ZEROS.*/
            public IntBasis W_ANOMOD { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    03 FILLER                    PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 W-PLACAUF                 PIC  X(002) VALUE SPACES.*/
            public StringBasis W_PLACAUF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"    03 FILLER                    PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 W-PLACALET                PIC  X(003) VALUE SPACES.*/
            public StringBasis W_PLACALET { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    03 FILLER                    PIC  X(005) VALUE SPACES.*/
            public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
            /*"    03 FILLER                    PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 W-PLACANR                 PIC  X(004) VALUE SPACES.*/
            public StringBasis W_PLACANR { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
            /*"    03 FILLER                    PIC  X(004) VALUE SPACES.*/
            public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
            /*"    03 FILLER                    PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 W-CHASSIS                 PIC  X(020) VALUE SPACES.*/
            public StringBasis W_CHASSIS { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
            /*"    03 FILLER                    PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 W-COD-VEICULO             PIC  9(009) VALUE ZEROS.*/
            public IntBasis W_COD_VEICULO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03 FILLER                    PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 W-DESCVEIC                PIC  X(040) VALUE SPACES.*/
            public StringBasis W_DESCVEIC { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"    03 FILLER                    PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 W-FONTE-EMISSAO           PIC  9(002) VALUE ZEROS.*/
            public IntBasis W_FONTE_EMISSAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    03 FILLER                    PIC  X(008) VALUE SPACES.*/
            public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"    03 FILLER                    PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 W-FONTE-SINISTRO          PIC  9(002) VALUE ZEROS.*/
            public IntBasis W_FONTE_SINISTRO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    03 FILLER                    PIC  X(008) VALUE SPACES.*/
            public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"    03 FILLER                    PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"01  LD02.*/
        }
        public SI0853B_LD02 LD02 { get; set; } = new SI0853B_LD02();
        public class SI0853B_LD02 : VarBasis
        {
            /*"    03 FILLER                    PIC  X(288) VALUE SPACES.*/
            public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "288", "X(288)"), @"");
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.APOLIAUT APOLIAUT { get; set; } = new Dclgens.APOLIAUT();
        public Dclgens.SINISCAU SINISCAU { get; set; } = new Dclgens.SINISCAU();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.VEICUDES VEICUDES { get; set; } = new Dclgens.VEICUDES();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.SINISAUT SINISAUT { get; set; } = new Dclgens.SINISAUT();
        public Dclgens.SINIMPSE SINIMPSE { get; set; } = new Dclgens.SINIMPSE();
        public SI0853B_CNOVAPT CNOVAPT { get; set; } = new SI0853B_CNOVAPT();
        public SI0853B_CPPPT CPPPT { get; set; } = new SI0853B_CPPPT();
        public SI0853B_CPTPP CPTPP { get; set; } = new SI0853B_CPTPP();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string NOVAPT_FILE_NAME_P, string PPPT_FILE_NAME_P, string PTPP_FILE_NAME_P, string PTPT_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                NOVAPT.SetFile(NOVAPT_FILE_NAME_P);
                PPPT.SetFile(PPPT_FILE_NAME_P);
                PTPP.SetFile(PTPP_FILE_NAME_P);
                PTPT.SetFile(PTPT_FILE_NAME_P);

                /*" -283- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC */

                /*" -284- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC */

                /*" -285- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC */

                /*" -290- OPEN OUTPUT NOVAPT */
                NOVAPT.Open(REG_NOVAPT);

                /*" -291- OPEN OUTPUT PPPT */
                PPPT.Open(REG_PPPT);

                /*" -292- OPEN OUTPUT PTPP */
                PTPP.Open(REG_PTPP);

                /*" -294- OPEN OUTPUT PTPT */
                PTPT.Open(REG_PTPT);

                /*" -296- MOVE '001' TO WNR-EXEC-SQL */
                _.Move("001", FILLER_0.WABEND.WNR_EXEC_SQL);

                /*" -298- PERFORM R0010-SELECT-SISTEMA */

                R0010_SELECT_SISTEMA(true);

                /*" -299- MOVE W-DT-DMA TO CAB02-DATA-MOVIMENTO */
                _.Move(W_INICIO_WORK.W_DT_DMA, CAB02.CAB02_DATA_MOVIMENTO);

                /*" -300- WRITE REG-NOVAPT FROM CAB02 */
                _.Move(CAB02.GetMoveValues(), REG_NOVAPT);

                NOVAPT.Write(REG_NOVAPT.GetMoveValues().ToString());

                /*" -302- WRITE REG-NOVAPT FROM CAB01 */
                _.Move(CAB01.GetMoveValues(), REG_NOVAPT);

                NOVAPT.Write(REG_NOVAPT.GetMoveValues().ToString());

                /*" -303- MOVE W-DT-DMA TO CAB03-DATA-MOVIMENTO */
                _.Move(W_INICIO_WORK.W_DT_DMA, CAB03.CAB03_DATA_MOVIMENTO);

                /*" -304- WRITE REG-PPPT FROM CAB03 */
                _.Move(CAB03.GetMoveValues(), REG_PPPT);

                PPPT.Write(REG_PPPT.GetMoveValues().ToString());

                /*" -306- WRITE REG-PPPT FROM CAB01 */
                _.Move(CAB01.GetMoveValues(), REG_PPPT);

                PPPT.Write(REG_PPPT.GetMoveValues().ToString());

                /*" -307- MOVE W-DT-DMA TO CAB04-DATA-MOVIMENTO */
                _.Move(W_INICIO_WORK.W_DT_DMA, CAB04.CAB04_DATA_MOVIMENTO);

                /*" -308- WRITE REG-PTPP FROM CAB04 */
                _.Move(CAB04.GetMoveValues(), REG_PTPP);

                PTPP.Write(REG_PTPP.GetMoveValues().ToString());

                /*" -310- WRITE REG-PTPP FROM CAB01 */
                _.Move(CAB01.GetMoveValues(), REG_PTPP);

                PTPP.Write(REG_PTPP.GetMoveValues().ToString());

                /*" -311- MOVE W-DT-DMA TO CAB05-DATA-MOVIMENTO */
                _.Move(W_INICIO_WORK.W_DT_DMA, CAB05.CAB05_DATA_MOVIMENTO);

                /*" -312- WRITE REG-PTPT FROM CAB05 */
                _.Move(CAB05.GetMoveValues(), REG_PTPT);

                PTPT.Write(REG_PTPT.GetMoveValues().ToString());

                /*" -314- WRITE REG-PTPT FROM CAB01 */
                _.Move(CAB01.GetMoveValues(), REG_PTPT);

                PTPT.Write(REG_PTPT.GetMoveValues().ToString());

                /*" -316- PERFORM R0020-DECLARE-SINISTROS-NOVAPT */

                R0020_DECLARE_SINISTROS_NOVAPT(true);

                /*" -317- SET B-FIM-NOVAPT-N TO TRUE */
                W_INICIO_WORK.W_FIM_NOVAPT["B_FIM_NOVAPT_N"] = true;

                /*" -319- PERFORM R0030-FETCH-SINISTROS-NOVAPT */

                R0030_FETCH_SINISTROS_NOVAPT(true);

                /*" -320- IF B-FIM-NOVAPT */

                if (W_INICIO_WORK.W_FIM_NOVAPT["B_FIM_NOVAPT"])
                {

                    /*" -321- DISPLAY '***********************************************' */
                    _.Display($"***********************************************");

                    /*" -322- DISPLAY '*  NAO EXISTE NOVA PT                         *' */
                    _.Display($"*  NAO EXISTE NOVA PT                         *");

                    /*" -323- DISPLAY '***********************************************' */
                    _.Display($"***********************************************");

                    /*" -324- MOVE 'NAO HOUVE NOVOS REGISTROS DE PERDA TOTAL' TO LD02 */
                    _.Move("NAO HOUVE NOVOS REGISTROS DE PERDA TOTAL", LD02);

                    /*" -325- WRITE REG-NOVAPT FROM LD02 */
                    _.Move(LD02.GetMoveValues(), REG_NOVAPT);

                    NOVAPT.Write(REG_NOVAPT.GetMoveValues().ToString());

                    /*" -327- END-IF */
                }


                /*" -331- PERFORM R0100-PROCESSA-NOVAPT UNTIL B-FIM-NOVAPT */

                while (!(W_INICIO_WORK.W_FIM_NOVAPT["B_FIM_NOVAPT"]))
                {

                    R0100_PROCESSA_NOVAPT(true);
                }

                /*" -333- PERFORM R0040-DECLARE-SINISTROS-PPPT */

                R0040_DECLARE_SINISTROS_PPPT(true);

                /*" -334- SET B-FIM-PPPT-N TO TRUE */
                W_INICIO_WORK.W_FIM_PPPT["B_FIM_PPPT_N"] = true;

                /*" -335- SET B-TAB-VAZIA-N TO TRUE */
                W_INICIO_WORK.W_TAB_VAZIA["B_TAB_VAZIA_N"] = true;

                /*" -337- PERFORM R0050-FETCH-SINISTROS-PPPT */

                R0050_FETCH_SINISTROS_PPPT(true);

                /*" -338- IF B-FIM-PPPT */

                if (W_INICIO_WORK.W_FIM_PPPT["B_FIM_PPPT"])
                {

                    /*" -339- DISPLAY '***********************************************' */
                    _.Display($"***********************************************");

                    /*" -340- DISPLAY '*  NAO EXISTE SINISTRO ALTERADO DE PP PARA PT *' */
                    _.Display($"*  NAO EXISTE SINISTRO ALTERADO DE PP PARA PT *");

                    /*" -341- DISPLAY '*  NAO EXISTE SINISTRO ALTERADO DE PT PARA PT *' */
                    _.Display($"*  NAO EXISTE SINISTRO ALTERADO DE PT PARA PT *");

                    /*" -342- DISPLAY '***********************************************' */
                    _.Display($"***********************************************");

                    /*" -343- MOVE 'NAO HOUVE SINISTROS ALTERADO DE PP PARA PT' TO LD02 */
                    _.Move("NAO HOUVE SINISTROS ALTERADO DE PP PARA PT", LD02);

                    /*" -344- WRITE REG-PPPT FROM LD02 */
                    _.Move(LD02.GetMoveValues(), REG_PPPT);

                    PPPT.Write(REG_PPPT.GetMoveValues().ToString());

                    /*" -345- MOVE 'NAO HOUVE SINISTROS ALTERADO DE PT PARA PT' TO LD02 */
                    _.Move("NAO HOUVE SINISTROS ALTERADO DE PT PARA PT", LD02);

                    /*" -346- WRITE REG-PTPT FROM LD02 */
                    _.Move(LD02.GetMoveValues(), REG_PTPT);

                    PTPT.Write(REG_PTPT.GetMoveValues().ToString());

                    /*" -347- SET B-TAB-VAZIA TO TRUE */
                    W_INICIO_WORK.W_TAB_VAZIA["B_TAB_VAZIA"] = true;

                    /*" -349- END-IF */
                }


                /*" -351- PERFORM R0200-PROCESSA-PPPT UNTIL B-FIM-PPPT */

                while (!(W_INICIO_WORK.W_FIM_PPPT["B_FIM_PPPT"]))
                {

                    R0200_PROCESSA_PPPT(true);
                }

                /*" -352- IF B-TAB-VAZIA-N AND W-TOTAL-PPPT EQUAL ZEROS */

                if (W_INICIO_WORK.W_TAB_VAZIA["B_TAB_VAZIA_N"] && W_INICIO_WORK.W_TOTAL_PPPT == 00)
                {

                    /*" -353- DISPLAY '***********************************************' */
                    _.Display($"***********************************************");

                    /*" -354- DISPLAY '*  NAO EXISTE SINISTRO ALTERADO DE PP PARA PT *' */
                    _.Display($"*  NAO EXISTE SINISTRO ALTERADO DE PP PARA PT *");

                    /*" -355- DISPLAY '***********************************************' */
                    _.Display($"***********************************************");

                    /*" -356- MOVE 'NAO HOUVE SINISTROS ALTERADO DE PP PARA PT' TO LD02 */
                    _.Move("NAO HOUVE SINISTROS ALTERADO DE PP PARA PT", LD02);

                    /*" -357- WRITE REG-PPPT FROM LD02 */
                    _.Move(LD02.GetMoveValues(), REG_PPPT);

                    PPPT.Write(REG_PPPT.GetMoveValues().ToString());

                    /*" -359- END-IF */
                }


                /*" -360- IF B-TAB-VAZIA-N AND W-TOTAL-PTPT EQUAL ZEROS */

                if (W_INICIO_WORK.W_TAB_VAZIA["B_TAB_VAZIA_N"] && W_INICIO_WORK.W_TOTAL_PTPT == 00)
                {

                    /*" -361- DISPLAY '***********************************************' */
                    _.Display($"***********************************************");

                    /*" -362- DISPLAY '*  NAO EXISTE SINISTRO ALTERADO DE PT PARA PT *' */
                    _.Display($"*  NAO EXISTE SINISTRO ALTERADO DE PT PARA PT *");

                    /*" -363- DISPLAY '***********************************************' */
                    _.Display($"***********************************************");

                    /*" -364- MOVE 'NAO HOUVE SINISTROS ALTERADO DE PT PARA PT' TO LD02 */
                    _.Move("NAO HOUVE SINISTROS ALTERADO DE PT PARA PT", LD02);

                    /*" -365- WRITE REG-PTPT FROM LD02 */
                    _.Move(LD02.GetMoveValues(), REG_PTPT);

                    PTPT.Write(REG_PTPT.GetMoveValues().ToString());

                    /*" -369- END-IF */
                }


                /*" -371- PERFORM R0060-DECLARE-SINISTROS-PTPP */

                R0060_DECLARE_SINISTROS_PTPP(true);

                /*" -372- SET B-FIM-PTPP-N TO TRUE */
                W_INICIO_WORK.W_FIM_PTPP["B_FIM_PTPP_N"] = true;

                /*" -373- SET B-TAB-VAZIA-N TO TRUE */
                W_INICIO_WORK.W_TAB_VAZIA["B_TAB_VAZIA_N"] = true;

                /*" -375- PERFORM R0070-FETCH-SINISTROS-PTPP */

                R0070_FETCH_SINISTROS_PTPP(true);

                /*" -376- IF B-FIM-PTPP */

                if (W_INICIO_WORK.W_FIM_PTPP["B_FIM_PTPP"])
                {

                    /*" -377- DISPLAY '***********************************************' */
                    _.Display($"***********************************************");

                    /*" -378- DISPLAY '*  NAO EXISTE SINISTRO ALTERADO DE PT PARA PP *' */
                    _.Display($"*  NAO EXISTE SINISTRO ALTERADO DE PT PARA PP *");

                    /*" -379- DISPLAY '***********************************************' */
                    _.Display($"***********************************************");

                    /*" -380- MOVE 'NAO HOUVE SINISTROS ALTERADO DE PT PARA PP' TO LD02 */
                    _.Move("NAO HOUVE SINISTROS ALTERADO DE PT PARA PP", LD02);

                    /*" -381- WRITE REG-PTPP FROM LD02 */
                    _.Move(LD02.GetMoveValues(), REG_PTPP);

                    PTPP.Write(REG_PTPP.GetMoveValues().ToString());

                    /*" -382- SET B-TAB-VAZIA TO TRUE */
                    W_INICIO_WORK.W_TAB_VAZIA["B_TAB_VAZIA"] = true;

                    /*" -384- END-IF */
                }


                /*" -386- PERFORM R0300-PROCESSA-PTPP UNTIL B-FIM-PTPP */

                while (!(W_INICIO_WORK.W_FIM_PTPP["B_FIM_PTPP"]))
                {

                    R0300_PROCESSA_PTPP(true);
                }

                /*" -387- IF B-TAB-VAZIA-N AND W-TOTAL-PTPP EQUAL ZEROS */

                if (W_INICIO_WORK.W_TAB_VAZIA["B_TAB_VAZIA_N"] && W_INICIO_WORK.W_TOTAL_PTPP == 00)
                {

                    /*" -388- DISPLAY '***********************************************' */
                    _.Display($"***********************************************");

                    /*" -389- DISPLAY '*  NAO EXISTE SINISTRO ALTERADO DE PT PARA PP *' */
                    _.Display($"*  NAO EXISTE SINISTRO ALTERADO DE PT PARA PP *");

                    /*" -390- DISPLAY '***********************************************' */
                    _.Display($"***********************************************");

                    /*" -391- MOVE 'NAO HOUVE SINISTROS ALTERADO DE PP PARA PT' TO LD02 */
                    _.Move("NAO HOUVE SINISTROS ALTERADO DE PP PARA PT", LD02);

                    /*" -392- WRITE REG-PTPP FROM LD02 */
                    _.Move(LD02.GetMoveValues(), REG_PTPP);

                    PTPP.Write(REG_PTPP.GetMoveValues().ToString());

                    /*" -394- END-IF */
                }


                /*" -395- DISPLAY '************************************' */
                _.Display($"************************************");

                /*" -396- DISPLAY '*                                  *' */
                _.Display($"*                                  *");

                /*" -397- DISPLAY '*            SI0853B               *' */
                _.Display($"*            SI0853B               *");

                /*" -398- DISPLAY '*                                  *' */
                _.Display($"*                                  *");

                /*" -399- DISPLAY '*   TERMINO NORMAL DO PROGRAMA     *' */
                _.Display($"*   TERMINO NORMAL DO PROGRAMA     *");

                /*" -399- DISPLAY '************************************' . */
                _.Display($"************************************");

                /*" -399- FLUXCONTROL_PERFORM M-000-TERMINA */

                M_000_TERMINA();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" M-000-TERMINA */
        private void M_000_TERMINA(bool isPerform = false)
        {
            /*" -404- CLOSE NOVAPT */
            NOVAPT.Close();

            /*" -405- CLOSE PPPT */
            PPPT.Close();

            /*" -406- CLOSE PTPP */
            PTPP.Close();

            /*" -408- CLOSE PTPT */
            PTPT.Close();

            /*" -410- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -410- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0010-SELECT-SISTEMA */
        private void R0010_SELECT_SISTEMA(bool isPerform = false)
        {
            /*" -417- MOVE '003' TO WNR-EXEC-SQL */
            _.Move("003", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -423- PERFORM R0010_SELECT_SISTEMA_DB_SELECT_1 */

            R0010_SELECT_SISTEMA_DB_SELECT_1();

            /*" -426- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -427- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -428- DISPLAY 'ERRO NO ACESSO - SISTEMA .......' */
                _.Display($"ERRO NO ACESSO - SISTEMA .......");

                /*" -429- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -430- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -432- END-IF */
            }


            /*" -434- DISPLAY 'DATA DO MOVIMENTO ' SISTEMAS-DATA-MOV-ABERTO */
            _.Display($"DATA DO MOVIMENTO {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -435- MOVE SISTEMAS-DATA-MOV-ABERTO(09:02) TO W-DT-DMA(01:02) */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2), W_INICIO_WORK.W_DT_DMA, 1, 2);

            /*" -436- MOVE '/' TO W-DT-DMA(03:01) */
            _.MoveAtPosition("/", W_INICIO_WORK.W_DT_DMA, 3, 1);

            /*" -437- MOVE SISTEMAS-DATA-MOV-ABERTO(06:02) TO W-DT-DMA(04:02) */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2), W_INICIO_WORK.W_DT_DMA, 4, 2);

            /*" -438- MOVE '/' TO W-DT-DMA(06:01) */
            _.MoveAtPosition("/", W_INICIO_WORK.W_DT_DMA, 6, 1);

            /*" -438- MOVE SISTEMAS-DATA-MOV-ABERTO(01:04) TO W-DT-DMA(07:04). */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4), W_INICIO_WORK.W_DT_DMA, 7, 4);

        }

        [StopWatch]
        /*" R0010-SELECT-SISTEMA-DB-SELECT-1 */
        public void R0010_SELECT_SISTEMA_DB_SELECT_1()
        {
            /*" -423- EXEC SQL SELECT DATA_MOV_ABERTO, DATULT_PROCESSAMEN INTO :SISTEMAS-DATA-MOV-ABERTO, :SISTEMAS-DATULT-PROCESSAMEN FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' END-EXEC */

            var r0010_SELECT_SISTEMA_DB_SELECT_1_Query1 = new R0010_SELECT_SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0010_SELECT_SISTEMA_DB_SELECT_1_Query1.Execute(r0010_SELECT_SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.SISTEMAS_DATULT_PROCESSAMEN, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATULT_PROCESSAMEN);
            }


        }

        [StopWatch]
        /*" R0020-DECLARE-SINISTROS-NOVAPT */
        private void R0020_DECLARE_SINISTROS_NOVAPT(bool isPerform = false)
        {
            /*" -446- MOVE '003' TO WNR-EXEC-SQL */
            _.Move("003", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -483- PERFORM R0020_DECLARE_SINISTROS_NOVAPT_DB_DECLARE_1 */

            R0020_DECLARE_SINISTROS_NOVAPT_DB_DECLARE_1();

            /*" -485- PERFORM R0020_DECLARE_SINISTROS_NOVAPT_DB_OPEN_1 */

            R0020_DECLARE_SINISTROS_NOVAPT_DB_OPEN_1();

            /*" -488- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -489- DISPLAY '//////////////////////////////////////' */
                _.Display($"//////////////////////////////////////");

                /*" -490- DISPLAY 'ERRO NO OPEN DO CNOVAPT ..............' */
                _.Display($"ERRO NO OPEN DO CNOVAPT ..............");

                /*" -491- DISPLAY 'DATA MOVIMENTO : ' SISTEMAS-DATA-MOV-ABERTO */
                _.Display($"DATA MOVIMENTO : {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

                /*" -492- DISPLAY '//////////////////////////////////////' */
                _.Display($"//////////////////////////////////////");

                /*" -493- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -493- END-IF. */
            }


        }

        [StopWatch]
        /*" R0020-DECLARE-SINISTROS-NOVAPT-DB-DECLARE-1 */
        public void R0020_DECLARE_SINISTROS_NOVAPT_DB_DECLARE_1()
        {
            /*" -483- EXEC SQL DECLARE CNOVAPT CURSOR FOR SELECT M.NUM_APOLICE, M.NUM_APOL_SINISTRO, M.COD_FONTE, H.DATA_MOVIMENTO, M.COD_CAUSA, SC.DESCR_CAUSA, M.DATA_OCORRENCIA, M.DATA_COMUNICADO, A.NUM_ITEM, A.ANO_FABRICACAO, A.ANO_MODELO, A.PLACA_UF, A.PLACA_LETRA, A.PLACA_NUMERO, A.NUM_CHASSIS, A.COD_CLIENTE, A.COD_VEICULO, A.COD_FABRICANTE, A.NUM_PRM_RESSEGURO FROM SEGUROS.SINISTRO_HISTORICO H, SEGUROS.SINISTRO_MESTRE M, SEGUROS.SINISTRO_CAUSA SC, SEGUROS.APOLICE_AUTO A, SEGUROS.SINISTRO_AUTO1 SA WHERE M.RAMO IN (31,53) AND M.COD_CAUSA IN (10,11,12,13,14,15,16,17,18,20) AND M.RAMO = SC.RAMO_EMISSOR AND M.COD_CAUSA = SC.COD_CAUSA AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND H.COD_OPERACAO = 101 AND H.DATA_MOVIMENTO = :SISTEMAS-DATA-MOV-ABERTO AND H.SIT_REGISTRO <> '2' AND M.NUM_APOL_SINISTRO = SA.NUM_APOL_SINISTRO AND M.NUM_APOLICE = A.NUM_APOLICE AND SA.NUM_ITEM = A.NUM_ITEM AND M.NUM_ENDOSSO = A.NUM_ENDOSSO END-EXEC */
            CNOVAPT = new SI0853B_CNOVAPT(true);
            string GetQuery_CNOVAPT()
            {
                var query = @$"SELECT M.NUM_APOLICE
							, 
							M.NUM_APOL_SINISTRO
							, 
							M.COD_FONTE
							, 
							H.DATA_MOVIMENTO
							, 
							M.COD_CAUSA
							, 
							SC.DESCR_CAUSA
							, 
							M.DATA_OCORRENCIA
							, 
							M.DATA_COMUNICADO
							, 
							A.NUM_ITEM
							, 
							A.ANO_FABRICACAO
							, 
							A.ANO_MODELO
							, 
							A.PLACA_UF
							, 
							A.PLACA_LETRA
							, 
							A.PLACA_NUMERO
							, 
							A.NUM_CHASSIS
							, 
							A.COD_CLIENTE
							, 
							A.COD_VEICULO
							, 
							A.COD_FABRICANTE
							, 
							A.NUM_PRM_RESSEGURO 
							FROM SEGUROS.SINISTRO_HISTORICO H
							, 
							SEGUROS.SINISTRO_MESTRE M
							, 
							SEGUROS.SINISTRO_CAUSA SC
							, 
							SEGUROS.APOLICE_AUTO A
							, 
							SEGUROS.SINISTRO_AUTO1 SA 
							WHERE M.RAMO IN (31
							,53) 
							AND M.COD_CAUSA IN (10
							,11
							,12
							,13
							,14
							,15
							,16
							,17
							,18
							,20) 
							AND M.RAMO = SC.RAMO_EMISSOR 
							AND M.COD_CAUSA = SC.COD_CAUSA 
							AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND H.COD_OPERACAO = 101 
							AND H.DATA_MOVIMENTO = '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND H.SIT_REGISTRO <> '2' 
							AND M.NUM_APOL_SINISTRO = SA.NUM_APOL_SINISTRO 
							AND M.NUM_APOLICE = A.NUM_APOLICE 
							AND SA.NUM_ITEM = A.NUM_ITEM 
							AND M.NUM_ENDOSSO = A.NUM_ENDOSSO";

                return query;
            }
            CNOVAPT.GetQueryEvent += GetQuery_CNOVAPT;

        }

        [StopWatch]
        /*" R0020-DECLARE-SINISTROS-NOVAPT-DB-OPEN-1 */
        public void R0020_DECLARE_SINISTROS_NOVAPT_DB_OPEN_1()
        {
            /*" -485- EXEC SQL OPEN CNOVAPT END-EXEC */

            CNOVAPT.Open();

        }

        [StopWatch]
        /*" R0040-DECLARE-SINISTROS-PPPT-DB-DECLARE-1 */
        public void R0040_DECLARE_SINISTROS_PPPT_DB_DECLARE_1()
        {
            /*" -580- EXEC SQL DECLARE CPPPT CURSOR FOR SELECT M.NUM_APOLICE, M.NUM_APOL_SINISTRO, M.COD_FONTE, H.DATA_MOVIMENTO, M.COD_CAUSA, SC.DESCR_CAUSA, M.DATA_OCORRENCIA, M.DATA_COMUNICADO, A.NUM_ITEM, A.ANO_FABRICACAO, A.ANO_MODELO, A.PLACA_UF, A.PLACA_LETRA, A.PLACA_NUMERO, A.NUM_CHASSIS, A.COD_CLIENTE, A.COD_VEICULO, A.COD_FABRICANTE, A.NUM_PRM_RESSEGURO FROM SEGUROS.SINISTRO_HISTORICO H, SEGUROS.SINISTRO_MESTRE M, SEGUROS.SINISTRO_CAUSA SC, SEGUROS.APOLICE_AUTO A, SEGUROS.SINISTRO_AUTO1 SA, SEGUROS.SINISTRO_IMP_SEG SI WHERE M.RAMO IN (31,53) AND M.NUM_APOL_SINISTRO = SI.NUM_APOL_SINISTRO AND SI.SIT_REGISTRO <> '2' AND SI.DATA_MOVIMENTO = :SISTEMAS-DATA-MOV-ABERTO AND SI.DATA_MOVIMENTO <> H.DATA_MOVIMENTO AND M.COD_CAUSA IN (10,11,12,13,14,15,16,17,18,20) AND M.RAMO = SC.RAMO_EMISSOR AND M.COD_CAUSA = SC.COD_CAUSA AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND H.COD_OPERACAO = 101 AND H.SIT_REGISTRO <> '2' AND M.NUM_APOL_SINISTRO = SA.NUM_APOL_SINISTRO AND M.NUM_APOLICE = A.NUM_APOLICE AND SA.NUM_ITEM = A.NUM_ITEM AND M.NUM_ENDOSSO = A.NUM_ENDOSSO END-EXEC */
            CPPPT = new SI0853B_CPPPT(true);
            string GetQuery_CPPPT()
            {
                var query = @$"SELECT M.NUM_APOLICE
							, 
							M.NUM_APOL_SINISTRO
							, 
							M.COD_FONTE
							, 
							H.DATA_MOVIMENTO
							, 
							M.COD_CAUSA
							, 
							SC.DESCR_CAUSA
							, 
							M.DATA_OCORRENCIA
							, 
							M.DATA_COMUNICADO
							, 
							A.NUM_ITEM
							, 
							A.ANO_FABRICACAO
							, 
							A.ANO_MODELO
							, 
							A.PLACA_UF
							, 
							A.PLACA_LETRA
							, 
							A.PLACA_NUMERO
							, 
							A.NUM_CHASSIS
							, 
							A.COD_CLIENTE
							, 
							A.COD_VEICULO
							, 
							A.COD_FABRICANTE
							, 
							A.NUM_PRM_RESSEGURO 
							FROM SEGUROS.SINISTRO_HISTORICO H
							, 
							SEGUROS.SINISTRO_MESTRE M
							, 
							SEGUROS.SINISTRO_CAUSA SC
							, 
							SEGUROS.APOLICE_AUTO A
							, 
							SEGUROS.SINISTRO_AUTO1 SA
							, 
							SEGUROS.SINISTRO_IMP_SEG SI 
							WHERE M.RAMO IN (31
							,53) 
							AND M.NUM_APOL_SINISTRO = SI.NUM_APOL_SINISTRO 
							AND SI.SIT_REGISTRO <> '2' 
							AND SI.DATA_MOVIMENTO = '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND SI.DATA_MOVIMENTO <> H.DATA_MOVIMENTO 
							AND M.COD_CAUSA IN (10
							,11
							,12
							,13
							,14
							,15
							,16
							,17
							,18
							,20) 
							AND M.RAMO = SC.RAMO_EMISSOR 
							AND M.COD_CAUSA = SC.COD_CAUSA 
							AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND H.COD_OPERACAO = 101 
							AND H.SIT_REGISTRO <> '2' 
							AND M.NUM_APOL_SINISTRO = SA.NUM_APOL_SINISTRO 
							AND M.NUM_APOLICE = A.NUM_APOLICE 
							AND SA.NUM_ITEM = A.NUM_ITEM 
							AND M.NUM_ENDOSSO = A.NUM_ENDOSSO";

                return query;
            }
            CPPPT.GetQueryEvent += GetQuery_CPPPT;

        }

        [StopWatch]
        /*" R0030-FETCH-SINISTROS-NOVAPT */
        private void R0030_FETCH_SINISTROS_NOVAPT(bool isPerform = false)
        {
            /*" -500- MOVE '004' TO WNR-EXEC-SQL */
            _.Move("004", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -520- PERFORM R0030_FETCH_SINISTROS_NOVAPT_DB_FETCH_1 */

            R0030_FETCH_SINISTROS_NOVAPT_DB_FETCH_1();

            /*" -523- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -524- SET B-FIM-NOVAPT TO TRUE */
                W_INICIO_WORK.W_FIM_NOVAPT["B_FIM_NOVAPT"] = true;

                /*" -524- PERFORM R0030_FETCH_SINISTROS_NOVAPT_DB_CLOSE_1 */

                R0030_FETCH_SINISTROS_NOVAPT_DB_CLOSE_1();

                /*" -527- END-IF */
            }


            /*" -528- IF (SQLCODE NOT EQUAL 100) AND (SQLCODE NOT EQUAL 0) */

            if ((DB.SQLCODE != 100) && (DB.SQLCODE != 0))
            {

                /*" -529- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -530- DISPLAY 'ERRO FETCH CNOVAPT .............' */
                _.Display($"ERRO FETCH CNOVAPT .............");

                /*" -531- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -532- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -532- END-IF. */
            }


        }

        [StopWatch]
        /*" R0030-FETCH-SINISTROS-NOVAPT-DB-FETCH-1 */
        public void R0030_FETCH_SINISTROS_NOVAPT_DB_FETCH_1()
        {
            /*" -520- EXEC SQL FETCH CNOVAPT INTO :SINISMES-NUM-APOLICE, :SINISMES-NUM-APOL-SINISTRO, :SINISMES-COD-FONTE, :SINISHIS-DATA-MOVIMENTO, :SINISMES-COD-CAUSA, :SINISCAU-DESCR-CAUSA, :SINISMES-DATA-OCORRENCIA, :SINISMES-DATA-COMUNICADO, :APOLIAUT-NUM-ITEM, :APOLIAUT-ANO-FABRICACAO, :APOLIAUT-ANO-MODELO, :APOLIAUT-PLACA-UF, :APOLIAUT-PLACA-LETRA, :APOLIAUT-PLACA-NUMERO, :APOLIAUT-NUM-CHASSIS, :APOLIAUT-COD-CLIENTE, :APOLIAUT-COD-VEICULO, :APOLIAUT-COD-FABRICANTE, :APOLIAUT-NUM-PRM-RESSEGURO END-EXEC */

            if (CNOVAPT.Fetch())
            {
                _.Move(CNOVAPT.SINISMES_NUM_APOLICE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE);
                _.Move(CNOVAPT.SINISMES_NUM_APOL_SINISTRO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO);
                _.Move(CNOVAPT.SINISMES_COD_FONTE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE);
                _.Move(CNOVAPT.SINISHIS_DATA_MOVIMENTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO);
                _.Move(CNOVAPT.SINISMES_COD_CAUSA, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA);
                _.Move(CNOVAPT.SINISCAU_DESCR_CAUSA, SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_DESCR_CAUSA);
                _.Move(CNOVAPT.SINISMES_DATA_OCORRENCIA, SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_OCORRENCIA);
                _.Move(CNOVAPT.SINISMES_DATA_COMUNICADO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_COMUNICADO);
                _.Move(CNOVAPT.APOLIAUT_NUM_ITEM, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_ITEM);
                _.Move(CNOVAPT.APOLIAUT_ANO_FABRICACAO, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_ANO_FABRICACAO);
                _.Move(CNOVAPT.APOLIAUT_ANO_MODELO, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_ANO_MODELO);
                _.Move(CNOVAPT.APOLIAUT_PLACA_UF, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_PLACA_UF);
                _.Move(CNOVAPT.APOLIAUT_PLACA_LETRA, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_PLACA_LETRA);
                _.Move(CNOVAPT.APOLIAUT_PLACA_NUMERO, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_PLACA_NUMERO);
                _.Move(CNOVAPT.APOLIAUT_NUM_CHASSIS, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_CHASSIS);
                _.Move(CNOVAPT.APOLIAUT_COD_CLIENTE, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_COD_CLIENTE);
                _.Move(CNOVAPT.APOLIAUT_COD_VEICULO, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_COD_VEICULO);
                _.Move(CNOVAPT.APOLIAUT_COD_FABRICANTE, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_COD_FABRICANTE);
                _.Move(CNOVAPT.APOLIAUT_NUM_PRM_RESSEGURO, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_PRM_RESSEGURO);
            }

        }

        [StopWatch]
        /*" R0030-FETCH-SINISTROS-NOVAPT-DB-CLOSE-1 */
        public void R0030_FETCH_SINISTROS_NOVAPT_DB_CLOSE_1()
        {
            /*" -524- EXEC SQL CLOSE CNOVAPT END-EXEC */

            CNOVAPT.Close();

        }

        [StopWatch]
        /*" R0040-DECLARE-SINISTROS-PPPT */
        private void R0040_DECLARE_SINISTROS_PPPT(bool isPerform = false)
        {
            /*" -539- MOVE '003' TO WNR-EXEC-SQL */
            _.Move("003", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -580- PERFORM R0040_DECLARE_SINISTROS_PPPT_DB_DECLARE_1 */

            R0040_DECLARE_SINISTROS_PPPT_DB_DECLARE_1();

            /*" -582- PERFORM R0040_DECLARE_SINISTROS_PPPT_DB_OPEN_1 */

            R0040_DECLARE_SINISTROS_PPPT_DB_OPEN_1();

            /*" -585- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -586- DISPLAY '//////////////////////////////////////' */
                _.Display($"//////////////////////////////////////");

                /*" -587- DISPLAY 'ERRO NO OPEN DO CPPPT ..............' */
                _.Display($"ERRO NO OPEN DO CPPPT ..............");

                /*" -588- DISPLAY 'DATA MOVIMENTO : ' SISTEMAS-DATA-MOV-ABERTO */
                _.Display($"DATA MOVIMENTO : {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

                /*" -589- DISPLAY '//////////////////////////////////////' */
                _.Display($"//////////////////////////////////////");

                /*" -590- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -590- END-IF. */
            }


        }

        [StopWatch]
        /*" R0040-DECLARE-SINISTROS-PPPT-DB-OPEN-1 */
        public void R0040_DECLARE_SINISTROS_PPPT_DB_OPEN_1()
        {
            /*" -582- EXEC SQL OPEN CPPPT END-EXEC */

            CPPPT.Open();

        }

        [StopWatch]
        /*" R0060-DECLARE-SINISTROS-PTPP-DB-DECLARE-1 */
        public void R0060_DECLARE_SINISTROS_PTPP_DB_DECLARE_1()
        {
            /*" -677- EXEC SQL DECLARE CPTPP CURSOR FOR SELECT M.NUM_APOLICE, M.NUM_APOL_SINISTRO, M.COD_FONTE, H.DATA_MOVIMENTO, M.COD_CAUSA, SC.DESCR_CAUSA, M.DATA_OCORRENCIA, M.DATA_COMUNICADO, A.NUM_ITEM, A.ANO_FABRICACAO, A.ANO_MODELO, A.PLACA_UF, A.PLACA_LETRA, A.PLACA_NUMERO, A.NUM_CHASSIS, A.COD_CLIENTE, A.COD_VEICULO, A.COD_FABRICANTE, A.NUM_PRM_RESSEGURO FROM SEGUROS.SINISTRO_HISTORICO H, SEGUROS.SINISTRO_MESTRE M, SEGUROS.SINISTRO_CAUSA SC, SEGUROS.APOLICE_AUTO A, SEGUROS.SINISTRO_AUTO1 SA, SEGUROS.SINISTRO_IMP_SEG SI WHERE M.RAMO IN (31,53) AND M.NUM_APOL_SINISTRO = SI.NUM_APOL_SINISTRO AND SI.SIT_REGISTRO <> '2' AND SI.DATA_MOVIMENTO = :SISTEMAS-DATA-MOV-ABERTO AND SI.DATA_MOVIMENTO <> H.DATA_MOVIMENTO AND M.COD_CAUSA NOT IN (10,11,12,13,14,15,16,17,18,20) AND M.RAMO = SC.RAMO_EMISSOR AND M.COD_CAUSA = SC.COD_CAUSA AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND H.COD_OPERACAO = 101 AND H.SIT_REGISTRO <> '2' AND M.NUM_APOL_SINISTRO = SA.NUM_APOL_SINISTRO AND M.NUM_APOLICE = A.NUM_APOLICE AND SA.NUM_ITEM = A.NUM_ITEM AND M.NUM_ENDOSSO = A.NUM_ENDOSSO END-EXEC */
            CPTPP = new SI0853B_CPTPP(true);
            string GetQuery_CPTPP()
            {
                var query = @$"SELECT M.NUM_APOLICE
							, 
							M.NUM_APOL_SINISTRO
							, 
							M.COD_FONTE
							, 
							H.DATA_MOVIMENTO
							, 
							M.COD_CAUSA
							, 
							SC.DESCR_CAUSA
							, 
							M.DATA_OCORRENCIA
							, 
							M.DATA_COMUNICADO
							, 
							A.NUM_ITEM
							, 
							A.ANO_FABRICACAO
							, 
							A.ANO_MODELO
							, 
							A.PLACA_UF
							, 
							A.PLACA_LETRA
							, 
							A.PLACA_NUMERO
							, 
							A.NUM_CHASSIS
							, 
							A.COD_CLIENTE
							, 
							A.COD_VEICULO
							, 
							A.COD_FABRICANTE
							, 
							A.NUM_PRM_RESSEGURO 
							FROM SEGUROS.SINISTRO_HISTORICO H
							, 
							SEGUROS.SINISTRO_MESTRE M
							, 
							SEGUROS.SINISTRO_CAUSA SC
							, 
							SEGUROS.APOLICE_AUTO A
							, 
							SEGUROS.SINISTRO_AUTO1 SA
							, 
							SEGUROS.SINISTRO_IMP_SEG SI 
							WHERE M.RAMO IN (31
							,53) 
							AND M.NUM_APOL_SINISTRO = SI.NUM_APOL_SINISTRO 
							AND SI.SIT_REGISTRO <> '2' 
							AND SI.DATA_MOVIMENTO = '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND SI.DATA_MOVIMENTO <> H.DATA_MOVIMENTO 
							AND M.COD_CAUSA NOT IN (10
							,11
							,12
							,13
							,14
							,15
							,16
							,17
							,18
							,20) 
							AND M.RAMO = SC.RAMO_EMISSOR 
							AND M.COD_CAUSA = SC.COD_CAUSA 
							AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND H.COD_OPERACAO = 101 
							AND H.SIT_REGISTRO <> '2' 
							AND M.NUM_APOL_SINISTRO = SA.NUM_APOL_SINISTRO 
							AND M.NUM_APOLICE = A.NUM_APOLICE 
							AND SA.NUM_ITEM = A.NUM_ITEM 
							AND M.NUM_ENDOSSO = A.NUM_ENDOSSO";

                return query;
            }
            CPTPP.GetQueryEvent += GetQuery_CPTPP;

        }

        [StopWatch]
        /*" R0050-FETCH-SINISTROS-PPPT */
        private void R0050_FETCH_SINISTROS_PPPT(bool isPerform = false)
        {
            /*" -597- MOVE '004' TO WNR-EXEC-SQL */
            _.Move("004", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -617- PERFORM R0050_FETCH_SINISTROS_PPPT_DB_FETCH_1 */

            R0050_FETCH_SINISTROS_PPPT_DB_FETCH_1();

            /*" -620- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -621- SET B-FIM-PPPT TO TRUE */
                W_INICIO_WORK.W_FIM_PPPT["B_FIM_PPPT"] = true;

                /*" -621- PERFORM R0050_FETCH_SINISTROS_PPPT_DB_CLOSE_1 */

                R0050_FETCH_SINISTROS_PPPT_DB_CLOSE_1();

                /*" -624- END-IF */
            }


            /*" -625- IF (SQLCODE NOT EQUAL 100) AND (SQLCODE NOT EQUAL 0) */

            if ((DB.SQLCODE != 100) && (DB.SQLCODE != 0))
            {

                /*" -626- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -627- DISPLAY 'ERRO FETCH CPPPT ...............' */
                _.Display($"ERRO FETCH CPPPT ...............");

                /*" -628- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -629- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -629- END-IF. */
            }


        }

        [StopWatch]
        /*" R0050-FETCH-SINISTROS-PPPT-DB-FETCH-1 */
        public void R0050_FETCH_SINISTROS_PPPT_DB_FETCH_1()
        {
            /*" -617- EXEC SQL FETCH CPPPT INTO :SINISMES-NUM-APOLICE, :SINISMES-NUM-APOL-SINISTRO, :SINISMES-COD-FONTE, :SINISHIS-DATA-MOVIMENTO, :SINISMES-COD-CAUSA, :SINISCAU-DESCR-CAUSA, :SINISMES-DATA-OCORRENCIA, :SINISMES-DATA-COMUNICADO, :APOLIAUT-NUM-ITEM, :APOLIAUT-ANO-FABRICACAO, :APOLIAUT-ANO-MODELO, :APOLIAUT-PLACA-UF, :APOLIAUT-PLACA-LETRA, :APOLIAUT-PLACA-NUMERO, :APOLIAUT-NUM-CHASSIS, :APOLIAUT-COD-CLIENTE, :APOLIAUT-COD-VEICULO, :APOLIAUT-COD-FABRICANTE, :APOLIAUT-NUM-PRM-RESSEGURO END-EXEC */

            if (CPPPT.Fetch())
            {
                _.Move(CPPPT.SINISMES_NUM_APOLICE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE);
                _.Move(CPPPT.SINISMES_NUM_APOL_SINISTRO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO);
                _.Move(CPPPT.SINISMES_COD_FONTE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE);
                _.Move(CPPPT.SINISHIS_DATA_MOVIMENTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO);
                _.Move(CPPPT.SINISMES_COD_CAUSA, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA);
                _.Move(CPPPT.SINISCAU_DESCR_CAUSA, SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_DESCR_CAUSA);
                _.Move(CPPPT.SINISMES_DATA_OCORRENCIA, SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_OCORRENCIA);
                _.Move(CPPPT.SINISMES_DATA_COMUNICADO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_COMUNICADO);
                _.Move(CPPPT.APOLIAUT_NUM_ITEM, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_ITEM);
                _.Move(CPPPT.APOLIAUT_ANO_FABRICACAO, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_ANO_FABRICACAO);
                _.Move(CPPPT.APOLIAUT_ANO_MODELO, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_ANO_MODELO);
                _.Move(CPPPT.APOLIAUT_PLACA_UF, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_PLACA_UF);
                _.Move(CPPPT.APOLIAUT_PLACA_LETRA, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_PLACA_LETRA);
                _.Move(CPPPT.APOLIAUT_PLACA_NUMERO, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_PLACA_NUMERO);
                _.Move(CPPPT.APOLIAUT_NUM_CHASSIS, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_CHASSIS);
                _.Move(CPPPT.APOLIAUT_COD_CLIENTE, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_COD_CLIENTE);
                _.Move(CPPPT.APOLIAUT_COD_VEICULO, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_COD_VEICULO);
                _.Move(CPPPT.APOLIAUT_COD_FABRICANTE, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_COD_FABRICANTE);
                _.Move(CPPPT.APOLIAUT_NUM_PRM_RESSEGURO, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_PRM_RESSEGURO);
            }

        }

        [StopWatch]
        /*" R0050-FETCH-SINISTROS-PPPT-DB-CLOSE-1 */
        public void R0050_FETCH_SINISTROS_PPPT_DB_CLOSE_1()
        {
            /*" -621- EXEC SQL CLOSE CPPPT END-EXEC */

            CPPPT.Close();

        }

        [StopWatch]
        /*" R0060-DECLARE-SINISTROS-PTPP */
        private void R0060_DECLARE_SINISTROS_PTPP(bool isPerform = false)
        {
            /*" -636- MOVE '003' TO WNR-EXEC-SQL */
            _.Move("003", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -677- PERFORM R0060_DECLARE_SINISTROS_PTPP_DB_DECLARE_1 */

            R0060_DECLARE_SINISTROS_PTPP_DB_DECLARE_1();

            /*" -679- PERFORM R0060_DECLARE_SINISTROS_PTPP_DB_OPEN_1 */

            R0060_DECLARE_SINISTROS_PTPP_DB_OPEN_1();

            /*" -682- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -683- DISPLAY '//////////////////////////////////////' */
                _.Display($"//////////////////////////////////////");

                /*" -684- DISPLAY 'ERRO NO OPEN DO CPTPP ..............' */
                _.Display($"ERRO NO OPEN DO CPTPP ..............");

                /*" -685- DISPLAY 'DATA MOVIMENTO : ' SISTEMAS-DATA-MOV-ABERTO */
                _.Display($"DATA MOVIMENTO : {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

                /*" -686- DISPLAY '//////////////////////////////////////' */
                _.Display($"//////////////////////////////////////");

                /*" -687- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -687- END-IF. */
            }


        }

        [StopWatch]
        /*" R0060-DECLARE-SINISTROS-PTPP-DB-OPEN-1 */
        public void R0060_DECLARE_SINISTROS_PTPP_DB_OPEN_1()
        {
            /*" -679- EXEC SQL OPEN CPTPP END-EXEC */

            CPTPP.Open();

        }

        [StopWatch]
        /*" R0070-FETCH-SINISTROS-PTPP */
        private void R0070_FETCH_SINISTROS_PTPP(bool isPerform = false)
        {
            /*" -694- MOVE '004' TO WNR-EXEC-SQL */
            _.Move("004", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -714- PERFORM R0070_FETCH_SINISTROS_PTPP_DB_FETCH_1 */

            R0070_FETCH_SINISTROS_PTPP_DB_FETCH_1();

            /*" -717- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -718- SET B-FIM-PTPP TO TRUE */
                W_INICIO_WORK.W_FIM_PTPP["B_FIM_PTPP"] = true;

                /*" -718- PERFORM R0070_FETCH_SINISTROS_PTPP_DB_CLOSE_1 */

                R0070_FETCH_SINISTROS_PTPP_DB_CLOSE_1();

                /*" -721- END-IF */
            }


            /*" -722- IF (SQLCODE NOT EQUAL 100) AND (SQLCODE NOT EQUAL 0) */

            if ((DB.SQLCODE != 100) && (DB.SQLCODE != 0))
            {

                /*" -723- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -724- DISPLAY 'ERRO FETCH CPTPP ...............' */
                _.Display($"ERRO FETCH CPTPP ...............");

                /*" -725- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -726- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -726- END-IF. */
            }


        }

        [StopWatch]
        /*" R0070-FETCH-SINISTROS-PTPP-DB-FETCH-1 */
        public void R0070_FETCH_SINISTROS_PTPP_DB_FETCH_1()
        {
            /*" -714- EXEC SQL FETCH CPTPP INTO :SINISMES-NUM-APOLICE, :SINISMES-NUM-APOL-SINISTRO, :SINISMES-COD-FONTE, :SINISHIS-DATA-MOVIMENTO, :SINISMES-COD-CAUSA, :SINISCAU-DESCR-CAUSA, :SINISMES-DATA-OCORRENCIA, :SINISMES-DATA-COMUNICADO, :APOLIAUT-NUM-ITEM, :APOLIAUT-ANO-FABRICACAO, :APOLIAUT-ANO-MODELO, :APOLIAUT-PLACA-UF, :APOLIAUT-PLACA-LETRA, :APOLIAUT-PLACA-NUMERO, :APOLIAUT-NUM-CHASSIS, :APOLIAUT-COD-CLIENTE, :APOLIAUT-COD-VEICULO, :APOLIAUT-COD-FABRICANTE, :APOLIAUT-NUM-PRM-RESSEGURO END-EXEC */

            if (CPTPP.Fetch())
            {
                _.Move(CPTPP.SINISMES_NUM_APOLICE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE);
                _.Move(CPTPP.SINISMES_NUM_APOL_SINISTRO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO);
                _.Move(CPTPP.SINISMES_COD_FONTE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE);
                _.Move(CPTPP.SINISHIS_DATA_MOVIMENTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO);
                _.Move(CPTPP.SINISMES_COD_CAUSA, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA);
                _.Move(CPTPP.SINISCAU_DESCR_CAUSA, SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_DESCR_CAUSA);
                _.Move(CPTPP.SINISMES_DATA_OCORRENCIA, SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_OCORRENCIA);
                _.Move(CPTPP.SINISMES_DATA_COMUNICADO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_COMUNICADO);
                _.Move(CPTPP.APOLIAUT_NUM_ITEM, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_ITEM);
                _.Move(CPTPP.APOLIAUT_ANO_FABRICACAO, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_ANO_FABRICACAO);
                _.Move(CPTPP.APOLIAUT_ANO_MODELO, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_ANO_MODELO);
                _.Move(CPTPP.APOLIAUT_PLACA_UF, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_PLACA_UF);
                _.Move(CPTPP.APOLIAUT_PLACA_LETRA, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_PLACA_LETRA);
                _.Move(CPTPP.APOLIAUT_PLACA_NUMERO, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_PLACA_NUMERO);
                _.Move(CPTPP.APOLIAUT_NUM_CHASSIS, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_CHASSIS);
                _.Move(CPTPP.APOLIAUT_COD_CLIENTE, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_COD_CLIENTE);
                _.Move(CPTPP.APOLIAUT_COD_VEICULO, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_COD_VEICULO);
                _.Move(CPTPP.APOLIAUT_COD_FABRICANTE, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_COD_FABRICANTE);
                _.Move(CPTPP.APOLIAUT_NUM_PRM_RESSEGURO, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_PRM_RESSEGURO);
            }

        }

        [StopWatch]
        /*" R0070-FETCH-SINISTROS-PTPP-DB-CLOSE-1 */
        public void R0070_FETCH_SINISTROS_PTPP_DB_CLOSE_1()
        {
            /*" -718- EXEC SQL CLOSE CPTPP END-EXEC */

            CPTPP.Close();

        }

        [StopWatch]
        /*" R0100-PROCESSA-NOVAPT */
        private void R0100_PROCESSA_NOVAPT(bool isPerform = false)
        {
            /*" -734- DISPLAY 'LENDO CURSOR NOVAPT ' SINISMES-NUM-APOLICE ' SINISTRO ' SINISMES-NUM-APOL-SINISTRO */

            $"LENDO CURSOR NOVAPT {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE} SINISTRO {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}"
            .Display();

            /*" -736- PERFORM R0900-ATRIBUI-IMPRESSAO */

            R0900_ATRIBUI_IMPRESSAO(true);

            /*" -738- WRITE REG-NOVAPT FROM LD01 */
            _.Move(LD01.GetMoveValues(), REG_NOVAPT);

            NOVAPT.Write(REG_NOVAPT.GetMoveValues().ToString());

            /*" -738- PERFORM R0030-FETCH-SINISTROS-NOVAPT. */

            R0030_FETCH_SINISTROS_NOVAPT(true);

        }

        [StopWatch]
        /*" R0200-PROCESSA-PPPT */
        private void R0200_PROCESSA_PPPT(bool isPerform = false)
        {
            /*" -749- DISPLAY 'LENDO CURSOR PPPT ' SINISMES-NUM-APOLICE ' SINISTRO ' SINISMES-NUM-APOL-SINISTRO ' CAUSA ' SINISMES-COD-CAUSA '-' SINISCAU-DESCR-CAUSA */

            $"LENDO CURSOR PPPT {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE} SINISTRO {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO} CAUSA {SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA}-{SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_DESCR_CAUSA}"
            .Display();

            /*" -753- PERFORM R2000-CAUSA-ANTERIOR THRU R2000-99-EXIT */

            R2000_CAUSA_ANTERIOR(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_EXIT*/


            /*" -754- IF SINIMPSE-COD-CAUSA NOT EQUAL SINISMES-COD-CAUSA */

            if (SINIMPSE.DCLSINISTRO_IMP_SEG.SINIMPSE_COD_CAUSA != SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA)
            {

                /*" -758- PERFORM R0900-ATRIBUI-IMPRESSAO */

                R0900_ATRIBUI_IMPRESSAO(true);

                /*" -760- MOVE SINIMPSE-COD-CAUSA TO W-PERDA-TOTAL */
                _.Move(SINIMPSE.DCLSINISTRO_IMP_SEG.SINIMPSE_COD_CAUSA, W_INICIO_WORK.W_PERDA_TOTAL);

                /*" -761- IF B-PERDA-TOTAL */

                if (W_INICIO_WORK.W_PERDA_TOTAL["B_PERDA_TOTAL"])
                {

                    /*" -762- ADD 1 TO W-TOTAL-PTPT */
                    W_INICIO_WORK.W_TOTAL_PTPT.Value = W_INICIO_WORK.W_TOTAL_PTPT + 1;

                    /*" -763- WRITE REG-PTPT FROM LD01 */
                    _.Move(LD01.GetMoveValues(), REG_PTPT);

                    PTPT.Write(REG_PTPT.GetMoveValues().ToString());

                    /*" -764- ELSE */
                }
                else
                {


                    /*" -765- ADD 1 TO W-TOTAL-PPPT */
                    W_INICIO_WORK.W_TOTAL_PPPT.Value = W_INICIO_WORK.W_TOTAL_PPPT + 1;

                    /*" -766- WRITE REG-PPPT FROM LD01 */
                    _.Move(LD01.GetMoveValues(), REG_PPPT);

                    PPPT.Write(REG_PPPT.GetMoveValues().ToString());

                    /*" -767- END-IF */
                }


                /*" -769- END-IF */
            }


            /*" -769- PERFORM R0050-FETCH-SINISTROS-PPPT. */

            R0050_FETCH_SINISTROS_PPPT(true);

        }

        [StopWatch]
        /*" R0300-PROCESSA-PTPP */
        private void R0300_PROCESSA_PTPP(bool isPerform = false)
        {
            /*" -777- DISPLAY 'LENDO CURSOR PTPP ' SINISMES-NUM-APOLICE ' SINISTRO ' SINISMES-NUM-APOL-SINISTRO */

            $"LENDO CURSOR PTPP {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE} SINISTRO {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}"
            .Display();

            /*" -781- PERFORM R2000-CAUSA-ANTERIOR THRU R2000-99-EXIT */

            R2000_CAUSA_ANTERIOR(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_EXIT*/


            /*" -782- MOVE SINIMPSE-COD-CAUSA TO W-PERDA-TOTAL */
            _.Move(SINIMPSE.DCLSINISTRO_IMP_SEG.SINIMPSE_COD_CAUSA, W_INICIO_WORK.W_PERDA_TOTAL);

            /*" -783- IF B-PERDA-TOTAL */

            if (W_INICIO_WORK.W_PERDA_TOTAL["B_PERDA_TOTAL"])
            {

                /*" -784- PERFORM R0900-ATRIBUI-IMPRESSAO */

                R0900_ATRIBUI_IMPRESSAO(true);

                /*" -785- ADD 1 TO W-TOTAL-PTPP */
                W_INICIO_WORK.W_TOTAL_PTPP.Value = W_INICIO_WORK.W_TOTAL_PTPP + 1;

                /*" -786- WRITE REG-PTPP FROM LD01 */
                _.Move(LD01.GetMoveValues(), REG_PTPP);

                PTPP.Write(REG_PTPP.GetMoveValues().ToString());

                /*" -788- END-IF */
            }


            /*" -788- PERFORM R0070-FETCH-SINISTROS-PTPP. */

            R0070_FETCH_SINISTROS_PTPP(true);

        }

        [StopWatch]
        /*" R0900-ATRIBUI-IMPRESSAO */
        private void R0900_ATRIBUI_IMPRESSAO(bool isPerform = false)
        {
            /*" -795- PERFORM R1000-SELECT-CLIENTE */

            R1000_SELECT_CLIENTE(true);

            /*" -797- PERFORM R1100-SELECT-VEICULO */

            R1100_SELECT_VEICULO(true);

            /*" -798- MOVE SINISMES-NUM-APOLICE TO ENDOSSOS-NUM-APOLICE */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE);

            /*" -800- MOVE 0 TO ENDOSSOS-NUM-ENDOSSO */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);

            /*" -802- PERFORM R1200-SELECT-ENDOSSO */

            R1200_SELECT_ENDOSSO(true);

            /*" -803- MOVE SINISMES-NUM-APOLICE TO W-NUM-APOLICE */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE, LD01.W_NUM_APOLICE);

            /*" -804- MOVE CLIENTES-NOME-RAZAO TO W-NOME-RAZAO */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, LD01.W_NOME_RAZAO);

            /*" -805- MOVE CLIENTES-TIPO-PESSOA TO W-TIPO-PESSOA */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA, LD01.W_TIPO_PESSOA);

            /*" -806- MOVE CLIENTES-CGCCPF TO W-CGCCPF */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, LD01.W_CGCCPF);

            /*" -808- MOVE SINISMES-NUM-APOL-SINISTRO TO W-NUM-SINISTRO */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO, LD01.W_NUM_SINISTRO);

            /*" -809- MOVE SINISMES-DATA-OCORRENCIA(09:02) TO W-DATORR(01:02) */
            _.MoveAtPosition(SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_OCORRENCIA.Substring(9, 2), LD01.W_DATORR, 1, 2);

            /*" -810- MOVE '/' TO W-DATORR(03:01) */
            _.MoveAtPosition("/", LD01.W_DATORR, 3, 1);

            /*" -811- MOVE SINISMES-DATA-OCORRENCIA(06:02) TO W-DATORR(04:02) */
            _.MoveAtPosition(SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_OCORRENCIA.Substring(6, 2), LD01.W_DATORR, 4, 2);

            /*" -812- MOVE '/' TO W-DATORR(06:01) */
            _.MoveAtPosition("/", LD01.W_DATORR, 6, 1);

            /*" -814- MOVE SINISMES-DATA-OCORRENCIA(01:04) TO W-DATORR(07:04) */
            _.MoveAtPosition(SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_OCORRENCIA.Substring(1, 4), LD01.W_DATORR, 7, 4);

            /*" -815- MOVE SINISMES-COD-CAUSA TO W-COD-CAUSA */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA, LD01.W_COD_CAUSA);

            /*" -817- MOVE SINISCAU-DESCR-CAUSA TO W-DESC-CAUSA */
            _.Move(SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_DESCR_CAUSA, LD01.W_DESC_CAUSA);

            /*" -818- MOVE SINISHIS-DATA-MOVIMENTO(09:02) TO W-DTMOVTO(01:02) */
            _.MoveAtPosition(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO.Substring(9, 2), LD01.W_DTMOVTO, 1, 2);

            /*" -819- MOVE '/' TO W-DTMOVTO(03:01) */
            _.MoveAtPosition("/", LD01.W_DTMOVTO, 3, 1);

            /*" -820- MOVE SINISHIS-DATA-MOVIMENTO(06:02) TO W-DTMOVTO(04:02) */
            _.MoveAtPosition(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO.Substring(6, 2), LD01.W_DTMOVTO, 4, 2);

            /*" -821- MOVE '/' TO W-DTMOVTO(06:01) */
            _.MoveAtPosition("/", LD01.W_DTMOVTO, 6, 1);

            /*" -823- MOVE SINISHIS-DATA-MOVIMENTO(01:04) TO W-DTMOVTO(07:04) */
            _.MoveAtPosition(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO.Substring(1, 4), LD01.W_DTMOVTO, 7, 4);

            /*" -824- MOVE APOLIAUT-NUM-ITEM TO W-ITEM */
            _.Move(APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_ITEM, LD01.W_ITEM);

            /*" -825- MOVE APOLIAUT-ANO-FABRICACAO TO W-ANOVEICL */
            _.Move(APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_ANO_FABRICACAO, LD01.W_ANOVEICL);

            /*" -826- MOVE APOLIAUT-ANO-MODELO TO W-ANOMOD */
            _.Move(APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_ANO_MODELO, LD01.W_ANOMOD);

            /*" -827- MOVE APOLIAUT-PLACA-UF TO W-PLACAUF */
            _.Move(APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_PLACA_UF, LD01.W_PLACAUF);

            /*" -828- MOVE APOLIAUT-PLACA-LETRA TO W-PLACALET */
            _.Move(APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_PLACA_LETRA, LD01.W_PLACALET);

            /*" -830- MOVE APOLIAUT-PLACA-NUMERO TO W-PLACANR */
            _.Move(APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_PLACA_NUMERO, LD01.W_PLACANR);

            /*" -831- IF W-PLACANR = '0000' */

            if (LD01.W_PLACANR == "0000")
            {

                /*" -832- MOVE SPACES TO W-PLACANR */
                _.Move("", LD01.W_PLACANR);

                /*" -834- END-IF */
            }


            /*" -835- MOVE APOLIAUT-NUM-CHASSIS TO W-CHASSIS */
            _.Move(APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_CHASSIS, LD01.W_CHASSIS);

            /*" -836- MOVE APOLIAUT-COD-VEICULO TO W-COD-VEICULO */
            _.Move(APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_COD_VEICULO, LD01.W_COD_VEICULO);

            /*" -837- MOVE VEICUDES-DESCR-VEICULO TO W-DESCVEIC */
            _.Move(VEICUDES.DCLVEICULOS_DESCRICAO.VEICUDES_DESCR_VEICULO, LD01.W_DESCVEIC);

            /*" -838- MOVE ENDOSSOS-COD-FONTE TO W-FONTE-EMISSAO */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE, LD01.W_FONTE_EMISSAO);

            /*" -838- MOVE SINISMES-COD-FONTE TO W-FONTE-SINISTRO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE, LD01.W_FONTE_SINISTRO);

        }

        [StopWatch]
        /*" R1000-SELECT-CLIENTE */
        private void R1000_SELECT_CLIENTE(bool isPerform = false)
        {
            /*" -845- MOVE '1800' TO WNR-EXEC-SQL */
            _.Move("1800", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -854- PERFORM R1000_SELECT_CLIENTE_DB_SELECT_1 */

            R1000_SELECT_CLIENTE_DB_SELECT_1();

            /*" -857- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -858- DISPLAY '//////////////////////////////////////' */
                _.Display($"//////////////////////////////////////");

                /*" -859- DISPLAY 'R1000 ERRO NO SELECT-CLIENTE' */
                _.Display($"R1000 ERRO NO SELECT-CLIENTE");

                /*" -860- MOVE SQLCODE TO WSL-SQLCODE */
                _.Move(DB.SQLCODE, AREA_DE_WORK.WSL_SQLCODE);

                /*" -861- DISPLAY 'SQLCODE........' WSL-SQLCODE */
                _.Display($"SQLCODE........{AREA_DE_WORK.WSL_SQLCODE}");

                /*" -862- DISPLAY 'COD_CLIENTE ...' APOLIAUT-COD-CLIENTE */
                _.Display($"COD_CLIENTE ...{APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_COD_CLIENTE}");

                /*" -863- DISPLAY '//////////////////////////////////////' */
                _.Display($"//////////////////////////////////////");

                /*" -864- MOVE 'INDEFINIDO' TO CLIENTES-NOME-RAZAO */
                _.Move("INDEFINIDO", CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);

                /*" -865- MOVE SPACES TO CLIENTES-TIPO-PESSOA */
                _.Move("", CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA);

                /*" -866- MOVE ZEROS TO CLIENTES-CGCCPF */
                _.Move(0, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);

                /*" -866- END-IF. */
            }


        }

        [StopWatch]
        /*" R1000-SELECT-CLIENTE-DB-SELECT-1 */
        public void R1000_SELECT_CLIENTE_DB_SELECT_1()
        {
            /*" -854- EXEC SQL SELECT C.NOME_RAZAO, C.TIPO_PESSOA, C.CGCCPF INTO :CLIENTES-NOME-RAZAO, :CLIENTES-TIPO-PESSOA, :CLIENTES-CGCCPF FROM SEGUROS.CLIENTES C WHERE C.COD_CLIENTE = :APOLIAUT-COD-CLIENTE END-EXEC */

            var r1000_SELECT_CLIENTE_DB_SELECT_1_Query1 = new R1000_SELECT_CLIENTE_DB_SELECT_1_Query1()
            {
                APOLIAUT_COD_CLIENTE = APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_COD_CLIENTE.ToString(),
            };

            var executed_1 = R1000_SELECT_CLIENTE_DB_SELECT_1_Query1.Execute(r1000_SELECT_CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(executed_1.CLIENTES_TIPO_PESSOA, CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA);
                _.Move(executed_1.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
            }


        }

        [StopWatch]
        /*" R1100-SELECT-VEICULO */
        private void R1100_SELECT_VEICULO(bool isPerform = false)
        {
            /*" -873- MOVE '1800' TO WNR-EXEC-SQL */
            _.Move("1800", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -874- IF APOLIAUT-NUM-PRM-RESSEGURO LESS 203 */

            if (APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_PRM_RESSEGURO < 203)
            {

                /*" -875- MOVE ZEROS TO VEICUDES-VERSAO */
                _.Move(0, VEICUDES.DCLVEICULOS_DESCRICAO.VEICUDES_VERSAO);

                /*" -876- ELSE */
            }
            else
            {


                /*" -878- MOVE APOLIAUT-NUM-PRM-RESSEGURO TO VEICUDES-VERSAO. */
                _.Move(APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_PRM_RESSEGURO, VEICUDES.DCLVEICULOS_DESCRICAO.VEICUDES_VERSAO);
            }


            /*" -885- PERFORM R1100_SELECT_VEICULO_DB_SELECT_1 */

            R1100_SELECT_VEICULO_DB_SELECT_1();

            /*" -888- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -889- DISPLAY '//////////////////////////////////////' */
                _.Display($"//////////////////////////////////////");

                /*" -890- DISPLAY 'R1100 ERRO NO SELECT-VEICULO' */
                _.Display($"R1100 ERRO NO SELECT-VEICULO");

                /*" -891- MOVE SQLCODE TO WSL-SQLCODE */
                _.Move(DB.SQLCODE, AREA_DE_WORK.WSL_SQLCODE);

                /*" -892- DISPLAY 'SQLCODE........' WSL-SQLCODE */
                _.Display($"SQLCODE........{AREA_DE_WORK.WSL_SQLCODE}");

                /*" -893- DISPLAY 'VERSAO.........' VEICUDES-VERSAO */
                _.Display($"VERSAO.........{VEICUDES.DCLVEICULOS_DESCRICAO.VEICUDES_VERSAO}");

                /*" -894- DISPLAY 'COD_VEICULO....' APOLIAUT-COD-VEICULO */
                _.Display($"COD_VEICULO....{APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_COD_VEICULO}");

                /*" -895- DISPLAY 'COD_FABRICANTE.' APOLIAUT-COD-FABRICANTE */
                _.Display($"COD_FABRICANTE.{APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_COD_FABRICANTE}");

                /*" -896- DISPLAY '//////////////////////////////////////' */
                _.Display($"//////////////////////////////////////");

                /*" -897- IF SQLCODE EQUAL -811 */

                if (DB.SQLCODE == -811)
                {

                    /*" -898- MOVE 'VEICULO INDEFINIDO' TO VEICUDES-DESCR-VEICULO */
                    _.Move("VEICULO INDEFINIDO", VEICUDES.DCLVEICULOS_DESCRICAO.VEICUDES_DESCR_VEICULO);

                    /*" -899- ELSE */
                }
                else
                {


                    /*" -900- MOVE SPACES TO VEICUDES-DESCR-VEICULO */
                    _.Move("", VEICUDES.DCLVEICULOS_DESCRICAO.VEICUDES_DESCR_VEICULO);

                    /*" -901- END-IF */
                }


                /*" -901- END-IF. */
            }


        }

        [StopWatch]
        /*" R1100-SELECT-VEICULO-DB-SELECT-1 */
        public void R1100_SELECT_VEICULO_DB_SELECT_1()
        {
            /*" -885- EXEC SQL SELECT DESCR_VEICULO INTO :VEICUDES-DESCR-VEICULO FROM SEGUROS.VEICULOS_DESCRICAO WHERE VERSAO = :VEICUDES-VERSAO AND COD_FABRICANTE = :APOLIAUT-COD-FABRICANTE AND COD_VEICULO = :APOLIAUT-COD-VEICULO END-EXEC */

            var r1100_SELECT_VEICULO_DB_SELECT_1_Query1 = new R1100_SELECT_VEICULO_DB_SELECT_1_Query1()
            {
                APOLIAUT_COD_FABRICANTE = APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_COD_FABRICANTE.ToString(),
                APOLIAUT_COD_VEICULO = APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_COD_VEICULO.ToString(),
                VEICUDES_VERSAO = VEICUDES.DCLVEICULOS_DESCRICAO.VEICUDES_VERSAO.ToString(),
            };

            var executed_1 = R1100_SELECT_VEICULO_DB_SELECT_1_Query1.Execute(r1100_SELECT_VEICULO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VEICUDES_DESCR_VEICULO, VEICUDES.DCLVEICULOS_DESCRICAO.VEICUDES_DESCR_VEICULO);
            }


        }

        [StopWatch]
        /*" R1200-SELECT-ENDOSSO */
        private void R1200_SELECT_ENDOSSO(bool isPerform = false)
        {
            /*" -908- MOVE '1800' TO WNR-EXEC-SQL. */
            _.Move("1800", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -914- PERFORM R1200_SELECT_ENDOSSO_DB_SELECT_1 */

            R1200_SELECT_ENDOSSO_DB_SELECT_1();

            /*" -917- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -918- DISPLAY '//////////////////////////////////////' */
                _.Display($"//////////////////////////////////////");

                /*" -919- DISPLAY 'R1200 - ERRO NO SELECT-ENDOSSO' */
                _.Display($"R1200 - ERRO NO SELECT-ENDOSSO");

                /*" -920- MOVE SQLCODE TO WSL-SQLCODE */
                _.Move(DB.SQLCODE, AREA_DE_WORK.WSL_SQLCODE);

                /*" -921- DISPLAY 'SQLCODE........' WSL-SQLCODE */
                _.Display($"SQLCODE........{AREA_DE_WORK.WSL_SQLCODE}");

                /*" -922- DISPLAY 'NUM_APOLICE  = ' ENDOSSOS-NUM-APOLICE */
                _.Display($"NUM_APOLICE  = {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE}");

                /*" -923- DISPLAY 'NUM_ENDOSSO  = ' ENDOSSOS-NUM-ENDOSSO */
                _.Display($"NUM_ENDOSSO  = {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO}");

                /*" -924- DISPLAY '//////////////////////////////////////' */
                _.Display($"//////////////////////////////////////");

                /*" -925- MOVE ZEROS TO ENDOSSOS-COD-FONTE */
                _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE);

                /*" -925- END-IF. */
            }


        }

        [StopWatch]
        /*" R1200-SELECT-ENDOSSO-DB-SELECT-1 */
        public void R1200_SELECT_ENDOSSO_DB_SELECT_1()
        {
            /*" -914- EXEC SQL SELECT COD_FONTE INTO :ENDOSSOS-COD-FONTE FROM SEGUROS.ENDOSSOS WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE AND NUM_ENDOSSO = :ENDOSSOS-NUM-ENDOSSO END-EXEC */

            var r1200_SELECT_ENDOSSO_DB_SELECT_1_Query1 = new R1200_SELECT_ENDOSSO_DB_SELECT_1_Query1()
            {
                ENDOSSOS_NUM_APOLICE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.ToString(),
                ENDOSSOS_NUM_ENDOSSO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = R1200_SELECT_ENDOSSO_DB_SELECT_1_Query1.Execute(r1200_SELECT_ENDOSSO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDOSSOS_COD_FONTE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE);
            }


        }

        [StopWatch]
        /*" R2000-CAUSA-ANTERIOR */
        private void R2000_CAUSA_ANTERIOR(bool isPerform = false)
        {
            /*" -932- MOVE '1800' TO WNR-EXEC-SQL. */
            _.Move("1800", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -938- PERFORM R2000_CAUSA_ANTERIOR_DB_SELECT_1 */

            R2000_CAUSA_ANTERIOR_DB_SELECT_1();

            /*" -941- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -942- DISPLAY '//////////////////////////////////////' */
                _.Display($"//////////////////////////////////////");

                /*" -943- DISPLAY 'R2000 - ERRO NO MAX(OCORR_HISTORICO)' */
                _.Display($"R2000 - ERRO NO MAX(OCORR_HISTORICO)");

                /*" -944- MOVE SQLCODE TO WSL-SQLCODE */
                _.Move(DB.SQLCODE, AREA_DE_WORK.WSL_SQLCODE);

                /*" -945- DISPLAY 'SQLCODE........' WSL-SQLCODE */
                _.Display($"SQLCODE........{AREA_DE_WORK.WSL_SQLCODE}");

                /*" -946- DISPLAY 'SINISTRO     = ' SINISMES-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO     = {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}");

                /*" -947- DISPLAY '//////////////////////////////////////' */
                _.Display($"//////////////////////////////////////");

                /*" -948- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -950- END-IF */
            }


            /*" -951- IF SINIMPSE-OCORR-HISTORICO EQUAL ZEROS */

            if (SINIMPSE.DCLSINISTRO_IMP_SEG.SINIMPSE_OCORR_HISTORICO == 00)
            {

                /*" -952- GO TO R2000-99-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_EXIT*/ //GOTO
                return;

                /*" -954- END-IF */
            }


            /*" -956- MOVE '1800' TO WNR-EXEC-SQL. */
            _.Move("1800", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -962- PERFORM R2000_CAUSA_ANTERIOR_DB_SELECT_2 */

            R2000_CAUSA_ANTERIOR_DB_SELECT_2();

            /*" -965- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -966- DISPLAY '//////////////////////////////////////' */
                _.Display($"//////////////////////////////////////");

                /*" -967- DISPLAY 'R2000 - ERRO NO SELECT CAUSA        ' */
                _.Display($"R2000 - ERRO NO SELECT CAUSA        ");

                /*" -968- MOVE SQLCODE TO WSL-SQLCODE */
                _.Move(DB.SQLCODE, AREA_DE_WORK.WSL_SQLCODE);

                /*" -969- DISPLAY 'SQLCODE........' WSL-SQLCODE */
                _.Display($"SQLCODE........{AREA_DE_WORK.WSL_SQLCODE}");

                /*" -970- DISPLAY 'SINISTRO     = ' SINISMES-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO     = {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}");

                /*" -971- DISPLAY 'OCORRENCIA   = ' SINIMPSE-OCORR-HISTORICO */
                _.Display($"OCORRENCIA   = {SINIMPSE.DCLSINISTRO_IMP_SEG.SINIMPSE_OCORR_HISTORICO}");

                /*" -972- DISPLAY '//////////////////////////////////////' */
                _.Display($"//////////////////////////////////////");

                /*" -973- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -973- END-IF. */
            }


        }

        [StopWatch]
        /*" R2000-CAUSA-ANTERIOR-DB-SELECT-1 */
        public void R2000_CAUSA_ANTERIOR_DB_SELECT_1()
        {
            /*" -938- EXEC SQL SELECT VALUE(MAX(OCORR_HISTORICO),0) INTO :SINIMPSE-OCORR-HISTORICO FROM SEGUROS.SINISTRO_IMP_SEG WHERE NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO AND SIT_REGISTRO = '2' END-EXEC */

            var r2000_CAUSA_ANTERIOR_DB_SELECT_1_Query1 = new R2000_CAUSA_ANTERIOR_DB_SELECT_1_Query1()
            {
                SINISMES_NUM_APOL_SINISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R2000_CAUSA_ANTERIOR_DB_SELECT_1_Query1.Execute(r2000_CAUSA_ANTERIOR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINIMPSE_OCORR_HISTORICO, SINIMPSE.DCLSINISTRO_IMP_SEG.SINIMPSE_OCORR_HISTORICO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_EXIT*/

        [StopWatch]
        /*" R2000-CAUSA-ANTERIOR-DB-SELECT-2 */
        public void R2000_CAUSA_ANTERIOR_DB_SELECT_2()
        {
            /*" -962- EXEC SQL SELECT COD_CAUSA INTO :SINIMPSE-COD-CAUSA FROM SEGUROS.SINISTRO_IMP_SEG WHERE NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO AND OCORR_HISTORICO = :SINIMPSE-OCORR-HISTORICO END-EXEC */

            var r2000_CAUSA_ANTERIOR_DB_SELECT_2_Query1 = new R2000_CAUSA_ANTERIOR_DB_SELECT_2_Query1()
            {
                SINISMES_NUM_APOL_SINISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.ToString(),
                SINIMPSE_OCORR_HISTORICO = SINIMPSE.DCLSINISTRO_IMP_SEG.SINIMPSE_OCORR_HISTORICO.ToString(),
            };

            var executed_1 = R2000_CAUSA_ANTERIOR_DB_SELECT_2_Query1.Execute(r2000_CAUSA_ANTERIOR_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINIMPSE_COD_CAUSA, SINIMPSE.DCLSINISTRO_IMP_SEG.SINIMPSE_COD_CAUSA);
            }


        }

        [StopWatch]
        /*" R9999-00-ROT-ERRO */
        private void R9999_00_ROT_ERRO(bool isPerform = false)
        {
            /*" -988- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, FILLER_0.WABEND.WSQLCODE);

            /*" -989- CLOSE NOVAPT */
            NOVAPT.Close();

            /*" -990- CLOSE PPPT */
            PPPT.Close();

            /*" -991- CLOSE PTPP */
            PTPP.Close();

            /*" -993- CLOSE PTPT */
            PTPT.Close();

            /*" -995- DISPLAY WABEND */
            _.Display(FILLER_0.WABEND);

            /*" -995- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC */

            /*" -997- EXEC SQL ROLLBACK WORK END-EXEC */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1001- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1004- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}