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
using Sias.Sinistro.DB2.SI0836B;

namespace Code
{
    public class SI0836B
    {
        public bool IsCall { get; set; }

        public SI0836B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *REMARKS.                                                               */
        /*"      *///////////////////////////////////////////////////////////////      */
        /*"      *   RELACAO DE PAGAMENTOS LIBERADOS NO DIA PARA AZULCAR       //      */
        /*"      *-------------------------------------------------------------//      */
        /*"      * ANALISTA    - HEIDER COELHO                                 //      */
        /*"      * PROGRAMADOR - HEIDER COELHO                                 //      */
        /*"      * DATA        - SET. / 97                                     //      */
        /*"      *                                                                *      */
        /*"      * CONVERSAO ANO 2000              CONSEDA4              05/1998  *      */
        /*"      *                                                                *      */
        /*"      * REVISAO - ANO 2000              CONSEDA4           06/06/1998  *      */
        /*"      *///////////////////////////////////////////////////////////////      */
        #endregion


        #region VARIABLES

        public FileBasis _SI0836M1 { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis SI0836M1
        {
            get
            {
                _.Move(REG_SI0836M1, _SI0836M1); VarBasis.RedefinePassValue(REG_SI0836M1, _SI0836M1, REG_SI0836M1); return _SI0836M1;
            }
        }
        /*"01  REG-SI0836M1.*/
        public SI0836B_REG_SI0836M1 REG_SI0836M1 { get; set; } = new SI0836B_REG_SI0836M1();
        public class SI0836B_REG_SI0836M1 : VarBasis
        {
            /*"    05  LINHA                  PIC  X(132).*/
            public StringBasis LINHA { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  V0HISTMEST-FONTE                 PIC S9(04) VALUE +0 COMP.*/
        public IntBasis V0HISTMEST_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0HISTMEST-PROTSINI              PIC S9(09) VALUE +0 COMP.*/
        public IntBasis V0HISTMEST_PROTSINI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0HISTMEST-DAC                   PIC  X(01).*/
        public StringBasis V0HISTMEST_DAC { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V0HISTMEST-RAMO                  PIC S9(04)          COMP.*/
        public IntBasis V0HISTMEST_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0HISTMEST-NOMFAV                PIC  X(40).*/
        public StringBasis V0HISTMEST_NOMFAV { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77  V0HISTMEST-OPERACAO              PIC S9(04)          COMP.*/
        public IntBasis V0HISTMEST_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0HISTMEST-NUM-APOLICE           PIC S9(13)          COMP-3.*/
        public IntBasis V0HISTMEST_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0HISTMEST-NUM-APOL-SINISTRO     PIC S9(13)          COMP-3.*/
        public IntBasis V0HISTMEST_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0HISTMEST-VAL-OPERACAO          PIC S9(13)V99       COMP-3.*/
        public DoubleBasis V0HISTMEST_VAL_OPERACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  V0SINIAUTO1-NUM-ITEM             PIC S9(09) VALUE +0 COMP.*/
        public IntBasis V0SINIAUTO1_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0APOLICE-CODCLIEN              PIC S9(09) VALUE +0 COMP.*/
        public IntBasis V0APOLICE_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0AUTOAPOL-DTTERVIG              PIC X(10).*/
        public StringBasis V0AUTOAPOL_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0RELATORIOS-DATA-REFERENCIA     PIC X(10).*/
        public StringBasis V0RELATORIOS_DATA_REFERENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1SISTEMA-DTMOVABE         PIC  X(10).*/
        public StringBasis V1SISTEMA_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1SISTEMA-DTCURRENT        PIC  X(10).*/
        public StringBasis V1SISTEMA_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0CLIENTE-NOME-RAZAO       PIC  X(40).*/
        public StringBasis V0CLIENTE_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"01  FILLER.*/
        public SI0836B_FILLER_0 FILLER_0 { get; set; } = new SI0836B_FILLER_0();
        public class SI0836B_FILLER_0 : VarBasis
        {
            /*"    03  LC01.*/
            public SI0836B_LC01 LC01 { get; set; } = new SI0836B_LC01();
            public class SI0836B_LC01 : VarBasis
            {
                /*"        05  FILLER             PIC  X(09) VALUE 'SI0836B.1'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"SI0836B.1");
                /*"        05  FILLER             PIC  X(34) VALUE  SPACES.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"");
                /*"        05  LC01-NOME-EMPRESA  PIC  X(74) VALUE    'SASSE - COMPANHIA NACIONAL DE SEGUROS GERAIS'.*/
                public StringBasis LC01_NOME_EMPRESA { get; set; } = new StringBasis(new PIC("X", "74", "X(74)"), @"SASSE - COMPANHIA NACIONAL DE SEGUROS GERAIS");
                /*"        05  FILLER             PIC  X(11) VALUE 'PAGINA'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"PAGINA");
                /*"        05  LC01-PAGINA        PIC  ZZZ9.*/
                public IntBasis LC01_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
                /*"    03  LC02.*/
            }
            public SI0836B_LC02 LC02 { get; set; } = new SI0836B_LC02();
            public class SI0836B_LC02 : VarBasis
            {
                /*"        05  FILLER             PIC X(117) VALUE  SPACES.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "117", "X(117)"), @"");
                /*"        05  FILLER             PIC  X(05) VALUE 'DATA'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"DATA");
                /*"        05  LC02-DATA          PIC  X(10) VALUE  SPACES.*/
                public StringBasis LC02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"    03 LC04.*/
            }
            public SI0836B_LC04 LC04 { get; set; } = new SI0836B_LC04();
            public class SI0836B_LC04 : VarBasis
            {
                /*"       05 FILLER               PIC X(34)           VALUE SPACES.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"");
                /*"       05 FILLER               PIC X(47)           VALUE    'RELACAO DE PAGAMENTOS/CHEQUES LIBERADOS PARA - '.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "47", "X(47)"), @"RELACAO DE PAGAMENTOS/CHEQUES LIBERADOS PARA - ");
                /*"       05 LC04-DD-PAGTO        PIC  9(02)          VALUE ZEROS.*/
                public IntBasis LC04_DD_PAGTO { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       05 FILLER               PIC  X(01)          VALUE '/'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"       05 LC04-MM-PAGTO        PIC  9(02)          VALUE ZEROS.*/
                public IntBasis LC04_MM_PAGTO { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       05 FILLER               PIC  X(01)          VALUE '/'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"       05 LC04-AA-PAGTO        PIC  9(04)          VALUE ZEROS.*/
                public IntBasis LC04_AA_PAGTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"       05 FILLER               PIC  X(08)          VALUE    '-AZULCAR'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"-AZULCAR");
                /*"       05 FILLER               PIC  X(18)          VALUE SPACES.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "18", "X(18)"), @"");
                /*"       05   FILLER             PIC  X(07) VALUE 'HORA'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"HORA");
                /*"       05   LC04-HORA          PIC  X(08) VALUE  SPACES.*/
                public StringBasis LC04_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
                /*"    03  LC05.*/
            }
            public SI0836B_LC05 LC05 { get; set; } = new SI0836B_LC05();
            public class SI0836B_LC05 : VarBasis
            {
                /*"        05  FILLER             PIC X(132) VALUE  ALL '-'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
                /*"    03  LC06.*/
            }
            public SI0836B_LC06 LC06 { get; set; } = new SI0836B_LC06();
            public class SI0836B_LC06 : VarBasis
            {
                /*"        05 FILLER             PIC  X(14) VALUE SPACES.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"");
                /*"        05 FILLER             PIC  X(05) VALUE 'FONTE'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"FONTE");
                /*"        05 FILLER             PIC  X(01) VALUE SPACES.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05 FILLER             PIC  X(05) VALUE 'PROT.'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"PROT.");
                /*"        05 FILLER             PIC  X(01) VALUE SPACES.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05 FILLER             PIC  X(03) VALUE 'DAC'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"DAC");
                /*"        05 FILLER             PIC  X(04) VALUE SPACES.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
                /*"        05 FILLER             PIC  X(08) VALUE 'SINISTRO'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"SINISTRO");
                /*"        05 FILLER             PIC  X(06) VALUE SPACES.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"");
                /*"        05 FILLER             PIC  X(07) VALUE 'APOLICE'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"APOLICE");
                /*"        05 FILLER             PIC  X(04) VALUE SPACES.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
                /*"        05 FILLER             PIC  X(19) VALUE        'SEGURADO/FAVORECIDO'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "19", "X(19)"), @"SEGURADO/FAVORECIDO");
                /*"        05 FILLER             PIC  X(35) VALUE SPACES.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"");
                /*"        05 FILLER             PIC  X(05) VALUE 'VALOR'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"VALOR");
                /*"        05 FILLER             PIC  X(16) VALUE SPACES.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"");
                /*"    03  LD01.*/
            }
            public SI0836B_LD01 LD01 { get; set; } = new SI0836B_LD01();
            public class SI0836B_LD01 : VarBasis
            {
                /*"        05  FILLER             PIC  X(15) VALUE  SPACES.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"");
                /*"        05  LD01-FONTE         PIC  9(03) VALUE  ZEROS.*/
                public IntBasis LD01_FONTE { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
                /*"        05  FILLER             PIC  X(02) VALUE  SPACES.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
                /*"        05  LD01-PROTSINI      PIC  ZZZZZ.*/
                public StringBasis LD01_PROTSINI { get; set; } = new StringBasis(new PIC("X", "0", "ZZZZZ."), @"");
                /*"        05  FILLER             PIC  X(02) VALUE  SPACES.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
                /*"        05  LD01-DAC           PIC  9(01) VALUE  ZEROS.*/
                public IntBasis LD01_DAC { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
                /*"        05  FILLER             PIC  X(02) VALUE  SPACES.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
                /*"        05  LD01-NUM-SINISTRO  PIC  9(13) VALUE  ZEROS.*/
                public IntBasis LD01_NUM_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
                /*"        05  FILLER             PIC  X(01) VALUE  SPACE.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  LD01-NUM-APOLICE   PIC  9(13) VALUE  ZEROS.*/
                public IntBasis LD01_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
                /*"        05  FILLER             PIC  X(01) VALUE  SPACE.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  LD01-SEGURADO      PIC  X(40) VALUE  SPACES.*/
                public StringBasis LD01_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"        05  FILLER             PIC  X(34) VALUE  SPACES.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"");
                /*"    03  LD02.*/
            }
            public SI0836B_LD02 LD02 { get; set; } = new SI0836B_LD02();
            public class SI0836B_LD02 : VarBasis
            {
                /*"        05  FILLER             PIC  X(58) VALUE  SPACES.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "58", "X(58)"), @"");
                /*"        05  LD01-FAVORECIDO    PIC  X(40) VALUE  SPACES.*/
                public StringBasis LD01_FAVORECIDO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"        05  FILLER             PIC  X(01) VALUE  SPACES.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  LD02-VAL-OPERACAO  PIC  ZZZZZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LD02_VAL_OPERACAO { get; set; } = new DoubleBasis(new PIC("9", "13", "ZZZZZZZ.ZZZ.ZZ9V99."), 2);
                /*"        05  FILLER             PIC  X(16) VALUE  SPACES.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"");
                /*"    03  LD99.*/
            }
            public SI0836B_LD99 LD99 { get; set; } = new SI0836B_LD99();
            public class SI0836B_LD99 : VarBasis
            {
                /*"        05  FILLER             PIC  X(31) VALUE  SPACES.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "31", "X(31)"), @"");
                /*"        05  FILLER             PIC  X(69) VALUE        '****  NAO HOUVE LIBERACAO PARA PAGAMENTO/CHEQUE NA DATA        'DE HOJE  ****'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "69", "X(69)"), @"****  NAO HOUVE LIBERACAO PARA PAGAMENTO/CHEQUE NA DATA        ");
                /*"        05  FILLER             PIC  X(32) VALUE  SPACES.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "32", "X(32)"), @"");
                /*"    03  WDATA.*/
            }
            public SI0836B_WDATA WDATA { get; set; } = new SI0836B_WDATA();
            public class SI0836B_WDATA : VarBasis
            {
                /*"        05  WDATA-AA           PIC  9(04) VALUE  ZEROES.*/
                public IntBasis WDATA_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"        05  FILLER             PIC  X(01) VALUE  SPACES.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  WDATA-MM           PIC  9(02) VALUE  ZEROES.*/
                public IntBasis WDATA_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"        05  FILLER             PIC  X(01) VALUE  SPACES.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  WDATA-DD           PIC  9(02) VALUE  ZEROES.*/
                public IntBasis WDATA_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    03       WDATA-CURR        PIC  X(010)    VALUE SPACES.*/
            }
            public StringBasis WDATA_CURR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    03       FILLER            REDEFINES      WDATA-CURR.*/
            private _REDEF_SI0836B_FILLER_44 _filler_44 { get; set; }
            public _REDEF_SI0836B_FILLER_44 FILLER_44
            {
                get { _filler_44 = new _REDEF_SI0836B_FILLER_44(); _.Move(WDATA_CURR, _filler_44); VarBasis.RedefinePassValue(WDATA_CURR, _filler_44, WDATA_CURR); _filler_44.ValueChanged += () => { _.Move(_filler_44, WDATA_CURR); }; return _filler_44; }
                set { VarBasis.RedefinePassValue(value, _filler_44, WDATA_CURR); }
            }  //Redefines
            public class _REDEF_SI0836B_FILLER_44 : VarBasis
            {
                /*"      05     WDATA-AA-CURR     PIC  9(004).*/
                public IntBasis WDATA_AA_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      05     FILLER            PIC  X(001).*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      05     WDATA-MM-CURR     PIC  9(002).*/
                public IntBasis WDATA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05     FILLER            PIC  X(001).*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      05     WDATA-DD-CURR     PIC  9(002).*/
                public IntBasis WDATA_DD_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03  WHORA-CURR.*/

                public _REDEF_SI0836B_FILLER_44()
                {
                    WDATA_AA_CURR.ValueChanged += OnValueChanged;
                    FILLER_45.ValueChanged += OnValueChanged;
                    WDATA_MM_CURR.ValueChanged += OnValueChanged;
                    FILLER_46.ValueChanged += OnValueChanged;
                    WDATA_DD_CURR.ValueChanged += OnValueChanged;
                }

            }
            public SI0836B_WHORA_CURR WHORA_CURR { get; set; } = new SI0836B_WHORA_CURR();
            public class SI0836B_WHORA_CURR : VarBasis
            {
                /*"        05  WHORA-HH-CURR      PIC  9(02) VALUE  ZEROES.*/
                public IntBasis WHORA_HH_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"        05  WHORA-MM-CURR      PIC  9(02) VALUE  ZEROES.*/
                public IntBasis WHORA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"        05  WHORA-SS-CURR      PIC  9(02) VALUE  ZEROES.*/
                public IntBasis WHORA_SS_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"        05  WHORA-CC-CURR      PIC  9(02) VALUE  ZEROES.*/
                public IntBasis WHORA_CC_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    03  WDATA-CABEC.*/
            }
            public SI0836B_WDATA_CABEC WDATA_CABEC { get; set; } = new SI0836B_WDATA_CABEC();
            public class SI0836B_WDATA_CABEC : VarBasis
            {
                /*"        05  WDATA-DD-CABEC     PIC  9(02) VALUE  ZEROES.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"        05  FILLER             PIC  X(01) VALUE '/'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"        05  WDATA-MM-CABEC     PIC  9(02) VALUE  ZEROES.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"        05  FILLER             PIC  X(01) VALUE '/'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"        05  WDATA-AA-CABEC     PIC  9(04) VALUE  ZEROES.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"    03  WHORA-CABEC.*/
            }
            public SI0836B_WHORA_CABEC WHORA_CABEC { get; set; } = new SI0836B_WHORA_CABEC();
            public class SI0836B_WHORA_CABEC : VarBasis
            {
                /*"        05  WHORA-HH-CABEC     PIC  9(02) VALUE  ZEROES.*/
                public IntBasis WHORA_HH_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"        05  FILLER             PIC  X(01) VALUE ':'.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @":");
                /*"        05  WHORA-MM-CABEC     PIC  9(02) VALUE  ZEROES.*/
                public IntBasis WHORA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"        05  FILLER             PIC  X(01) VALUE ':'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @":");
                /*"        05  WHORA-SS-CABEC     PIC  9(02) VALUE  ZEROES.*/
                public IntBasis WHORA_SS_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    03  W-NUM-APOL-SINISTRO-ANT  PIC S9(13) VALUE +0 COMP-3.*/
            }
            public IntBasis W_NUM_APOL_SINISTRO_ANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
            /*"    03  W-FIM-HISTMEST         PIC  X(03)    VALUE 'NAO'.*/
            public StringBasis W_FIM_HISTMEST { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    03  W-CONT-PAGINA          PIC S9(04)    VALUE +0     COMP.*/
            public IntBasis W_CONT_PAGINA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    03  W-CONT-LINHA           PIC S9(02)    VALUE +0     COMP.*/
            public IntBasis W_CONT_LINHA { get; set; } = new IntBasis(new PIC("S9", "2", "S9(02)"));
            /*"    03  W-CONT-LIDOS           PIC S9(02)    VALUE +0     COMP.*/
            public IntBasis W_CONT_LIDOS { get; set; } = new IntBasis(new PIC("S9", "2", "S9(02)"));
            /*"    03  WSQLCODE3              PIC S9(09) VALUE  ZEROES COMP.*/
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"    03  WABEND.*/
            public SI0836B_WABEND WABEND { get; set; } = new SI0836B_WABEND();
            public class SI0836B_WABEND : VarBasis
            {
                /*"        05  FILLER             PIC  X(01) VALUE  SPACE.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  FILLER             PIC  X(09) VALUE 'SI0836B'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"SI0836B");
                /*"        05  FILLER             PIC  X(10) VALUE '*** ERRO'.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"*** ERRO");
                /*"        05  FILLER             PIC  X(10) VALUE 'EXEC SQL'.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"EXEC SQL");
                /*"        05  FILLER             PIC  X(08) VALUE 'NUMERO'.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"NUMERO");
                /*"        05  WNR-EXEC-SQL       PIC  X(03) VALUE  SPACES.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
                /*"        05  FILLER             PIC  X(01) VALUE  SPACE.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  FILLER             PIC  X(16) VALUE '** PARAGRAFO ='*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"** PARAGRAFO =");
                /*"        05  PARAGRAFO          PIC  X(30) VALUE  SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
                /*"        05  FILLER             PIC  X(04) VALUE  SPACES.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
                /*"    03  WABEND2.*/
            }
            public SI0836B_WABEND2 WABEND2 { get; set; } = new SI0836B_WABEND2();
            public class SI0836B_WABEND2 : VarBasis
            {
                /*"        05  FILLER             PIC  X(10) VALUE 'SQLCODE = '.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"SQLCODE = ");
                /*"        05  WSQLCODE           PIC  ZZZZZZ999-   VALUE ZEROES.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"        05  FILLER             PIC  X(04) VALUE  SPACES.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
                /*"        05  FILLER             PIC  X(10) VALUE 'SQLCODE1= '.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"SQLCODE1= ");
                /*"        05  WSQLCODE1          PIC  ZZZZZZ999-   VALUE ZEROES.*/
                public IntBasis WSQLCODE1 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"        05  FILLER             PIC  X(04) VALUE  SPACES.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
                /*"        05  FILLER             PIC  X(10) VALUE 'SQLCODE2= '.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"SQLCODE2= ");
                /*"        05  WSQLCODE2          PIC  ZZZZZZ999-   VALUE ZEROES.*/
                public IntBasis WSQLCODE2 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            }
        }


        public SI0836B_HISTMEST HISTMEST { get; set; } = new SI0836B_HISTMEST();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SI0836M1_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SI0836M1.SetFile(SI0836M1_FILE_NAME_P);

                /*" -243- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -244- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -245- EXEC SQL WHENEVER SQLERROR GO TO 999-999-ROT-ERRO END-EXEC. */

                /*" -248- MOVE 1 TO W-CONT-PAGINA. */
                _.Move(1, FILLER_0.W_CONT_PAGINA);

                /*" -250- MOVE 80 TO W-CONT-LINHA. */
                _.Move(80, FILLER_0.W_CONT_LINHA);

                /*" -252- OPEN OUTPUT SI0836M1. */
                SI0836M1.Open(REG_SI0836M1);

                /*" -253- MOVE '000' TO WNR-EXEC-SQL. */
                _.Move("000", FILLER_0.WABEND.WNR_EXEC_SQL);

                /*" -259- PERFORM Execute_DB_SELECT_1 */

                Execute_DB_SELECT_1();

                /*" -262- IF SQLCODE EQUAL 0 */

                if (DB.SQLCODE == 0)
                {

                    /*" -263- MOVE V0RELATORIOS-DATA-REFERENCIA TO V1SISTEMA-DTMOVABE */
                    _.Move(V0RELATORIOS_DATA_REFERENCIA, V1SISTEMA_DTMOVABE);

                    /*" -264- MOVE '000' TO WNR-EXEC-SQL */
                    _.Move("000", FILLER_0.WABEND.WNR_EXEC_SQL);

                    /*" -269- PERFORM Execute_DB_DELETE_1 */

                    Execute_DB_DELETE_1();

                    /*" -271- ELSE */
                }
                else
                {


                    /*" -272- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -274- PERFORM 005-SELECT-V1SISTEMA THRU 005-EXIT. */

                        M_005_SELECT_V1SISTEMA(true);
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_005_EXIT*/

                    }

                }


                /*" -275- MOVE 'NAO' TO W-FIM-HISTMEST. */
                _.Move("NAO", FILLER_0.W_FIM_HISTMEST);

                /*" -276- PERFORM 010-DECLARE-HISTMEST THRU 010-EXIT. */

                M_010_DECLARE_HISTMEST(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_010_EXIT*/


                /*" -278- PERFORM 020-FETCH-HISTMEST THRU 020-EXIT. */

                M_020_FETCH_HISTMEST(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_020_EXIT*/


                /*" -279- IF W-FIM-HISTMEST EQUAL 'SIM' */

                if (FILLER_0.W_FIM_HISTMEST == "SIM")
                {

                    /*" -280- PERFORM 800-ROTINA-CABECALHO THRU 800-EXIT */

                    M_800_ROTINA_CABECALHO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_800_EXIT*/


                    /*" -281- PERFORM M-810-IMPRIME-SEM-MOVIMENTO THRU 810-EXIT */

                    M_810_IMPRIME_SEM_MOVIMENTO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_810_EXIT*/


                    /*" -283- GO TO 900-FINALIZA. */

                    M_900_FINALIZA(); //GOTO
                    return Result;
                }


                /*" -284- PERFORM 030-PROCESSA-HISTMEST THRU 030-EXIT UNTIL (W-FIM-HISTMEST EQUAL 'SIM' ). */

                while (!((FILLER_0.W_FIM_HISTMEST == "SIM")))
                {

                    M_030_PROCESSA_HISTMEST(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_030_EXIT*/

                }

                /*" -284- FLUXCONTROL_PERFORM Execute-DB-SELECT-1 */

                Execute_DB_SELECT_1();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" Execute-DB-SELECT-1 */
        public void Execute_DB_SELECT_1()
        {
            /*" -259- EXEC SQL SELECT DATA_REFERENCIA INTO :V0RELATORIOS-DATA-REFERENCIA FROM SEGUROS.V0RELATORIOS WHERE IDSISTEM = 'SI' AND CODRELAT = 'SI0836B' END-EXEC. */

            var execute_DB_SELECT_1_Query1 = new Execute_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = Execute_DB_SELECT_1_Query1.Execute(execute_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RELATORIOS_DATA_REFERENCIA, V0RELATORIOS_DATA_REFERENCIA);
            }


        }

        [StopWatch]
        /*" Execute-DB-DELETE-1 */
        public void Execute_DB_DELETE_1()
        {
            /*" -269- EXEC SQL DELETE FROM SEGUROS.V0RELATORIOS WHERE IDSISTEM = 'SI' AND CODRELAT = 'SI0836B' END-EXEC */

            var execute_DB_DELETE_1_Delete1 = new Execute_DB_DELETE_1_Delete1()
            {
            };

            Execute_DB_DELETE_1_Delete1.Execute(execute_DB_DELETE_1_Delete1);

        }

        [StopWatch]
        /*" M-900-FINALIZA */
        private void M_900_FINALIZA(bool isPerform = false)
        {
            /*" -288- DISPLAY '****************************************' */
            _.Display($"****************************************");

            /*" -289- DISPLAY '*            PROGRAMA SI0836B          *' */
            _.Display($"*            PROGRAMA SI0836B          *");

            /*" -290- DISPLAY '*               FIM NORMAL             *' */
            _.Display($"*               FIM NORMAL             *");

            /*" -291- DISPLAY '****************************************' */
            _.Display($"****************************************");

            /*" -293- DISPLAY 'QTD. REG. LIDOS = ' W-CONT-LIDOS */
            _.Display($"QTD. REG. LIDOS = {FILLER_0.W_CONT_LIDOS}");

            /*" -295- CLOSE SI0836M1. */
            SI0836M1.Close();

            /*" -295- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-005-SELECT-V1SISTEMA */
        private void M_005_SELECT_V1SISTEMA(bool isPerform = false)
        {
            /*" -301- MOVE '001' TO WNR-EXEC-SQL. */
            _.Move("001", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -306- PERFORM M_005_SELECT_V1SISTEMA_DB_SELECT_1 */

            M_005_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -309- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -309- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-005-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void M_005_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -306- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :V1SISTEMA-DTMOVABE, :V1SISTEMA-DTCURRENT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'SI' END-EXEC. */

            var m_005_SELECT_V1SISTEMA_DB_SELECT_1_Query1 = new M_005_SELECT_V1SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_005_SELECT_V1SISTEMA_DB_SELECT_1_Query1.Execute(m_005_SELECT_V1SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SISTEMA_DTMOVABE, V1SISTEMA_DTMOVABE);
                _.Move(executed_1.V1SISTEMA_DTCURRENT, V1SISTEMA_DTCURRENT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_005_EXIT*/

        [StopWatch]
        /*" M-010-DECLARE-HISTMEST */
        private void M_010_DECLARE_HISTMEST(bool isPerform = false)
        {
            /*" -317- MOVE '002' TO WNR-EXEC-SQL. */
            _.Move("002", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -338- PERFORM M_010_DECLARE_HISTMEST_DB_DECLARE_1 */

            M_010_DECLARE_HISTMEST_DB_DECLARE_1();

            /*" -340- PERFORM M_010_DECLARE_HISTMEST_DB_OPEN_1 */

            M_010_DECLARE_HISTMEST_DB_OPEN_1();

        }

        [StopWatch]
        /*" M-010-DECLARE-HISTMEST-DB-DECLARE-1 */
        public void M_010_DECLARE_HISTMEST_DB_DECLARE_1()
        {
            /*" -338- EXEC SQL DECLARE HISTMEST CURSOR FOR SELECT M.FONTE, M.PROTSINI, M.DAC, H.NUM_APOL_SINISTRO, M.NUM_APOLICE, H.OPERACAO, H.VAL_OPERACAO, H.NOMFAV FROM SEGUROS.V0HISTSINI H, SEGUROS.V0MESTSINI M WHERE M.RAMO IN (31, 53, 81) AND M.NUM_APOLICE BETWEEN 0103100000000 AND 0103199999999 AND H.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO AND H.DTMOVTO = :V1SISTEMA-DTMOVABE AND H.SITUACAO <> '2' AND H.OPERACAO IN (1001, 1002, 1003, 1004, 1009, 2010, 3010) ORDER BY M.FONTE, H.NUM_APOL_SINISTRO END-EXEC. */
            HISTMEST = new SI0836B_HISTMEST(true);
            string GetQuery_HISTMEST()
            {
                var query = @$"SELECT M.FONTE
							, 
							M.PROTSINI
							, 
							M.DAC
							, 
							H.NUM_APOL_SINISTRO
							, 
							M.NUM_APOLICE
							, 
							H.OPERACAO
							, 
							H.VAL_OPERACAO
							, 
							H.NOMFAV 
							FROM SEGUROS.V0HISTSINI H
							, 
							SEGUROS.V0MESTSINI M 
							WHERE M.RAMO IN (31
							, 53
							, 81) 
							AND M.NUM_APOLICE BETWEEN 0103100000000 
							AND 0103199999999 
							AND H.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO 
							AND H.DTMOVTO = '{V1SISTEMA_DTMOVABE}' 
							AND H.SITUACAO <> '2' 
							AND H.OPERACAO IN (1001
							, 1002
							, 1003
							, 1004
							, 1009
							, 
							2010
							, 3010) 
							ORDER BY M.FONTE
							, H.NUM_APOL_SINISTRO";

                return query;
            }
            HISTMEST.GetQueryEvent += GetQuery_HISTMEST;

        }

        [StopWatch]
        /*" M-010-DECLARE-HISTMEST-DB-OPEN-1 */
        public void M_010_DECLARE_HISTMEST_DB_OPEN_1()
        {
            /*" -340- EXEC SQL OPEN HISTMEST END-EXEC. */

            HISTMEST.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_010_EXIT*/

        [StopWatch]
        /*" M-020-FETCH-HISTMEST */
        private void M_020_FETCH_HISTMEST(bool isPerform = false)
        {
            /*" -348- MOVE '003' TO WNR-EXEC-SQL. */
            _.Move("003", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -357- PERFORM M_020_FETCH_HISTMEST_DB_FETCH_1 */

            M_020_FETCH_HISTMEST_DB_FETCH_1();

            /*" -360- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -361- MOVE 'SIM' TO W-FIM-HISTMEST */
                _.Move("SIM", FILLER_0.W_FIM_HISTMEST);

                /*" -361- PERFORM M_020_FETCH_HISTMEST_DB_CLOSE_1 */

                M_020_FETCH_HISTMEST_DB_CLOSE_1();

                /*" -363- ELSE */
            }
            else
            {


                /*" -363- ADD 1 TO W-CONT-LIDOS. */
                FILLER_0.W_CONT_LIDOS.Value = FILLER_0.W_CONT_LIDOS + 1;
            }


        }

        [StopWatch]
        /*" M-020-FETCH-HISTMEST-DB-FETCH-1 */
        public void M_020_FETCH_HISTMEST_DB_FETCH_1()
        {
            /*" -357- EXEC SQL FETCH HISTMEST INTO :V0HISTMEST-FONTE, :V0HISTMEST-PROTSINI, :V0HISTMEST-DAC, :V0HISTMEST-NUM-APOL-SINISTRO, :V0HISTMEST-NUM-APOLICE, :V0HISTMEST-OPERACAO, :V0HISTMEST-VAL-OPERACAO, :V0HISTMEST-NOMFAV END-EXEC. */

            if (HISTMEST.Fetch())
            {
                _.Move(HISTMEST.V0HISTMEST_FONTE, V0HISTMEST_FONTE);
                _.Move(HISTMEST.V0HISTMEST_PROTSINI, V0HISTMEST_PROTSINI);
                _.Move(HISTMEST.V0HISTMEST_DAC, V0HISTMEST_DAC);
                _.Move(HISTMEST.V0HISTMEST_NUM_APOL_SINISTRO, V0HISTMEST_NUM_APOL_SINISTRO);
                _.Move(HISTMEST.V0HISTMEST_NUM_APOLICE, V0HISTMEST_NUM_APOLICE);
                _.Move(HISTMEST.V0HISTMEST_OPERACAO, V0HISTMEST_OPERACAO);
                _.Move(HISTMEST.V0HISTMEST_VAL_OPERACAO, V0HISTMEST_VAL_OPERACAO);
                _.Move(HISTMEST.V0HISTMEST_NOMFAV, V0HISTMEST_NOMFAV);
            }

        }

        [StopWatch]
        /*" M-020-FETCH-HISTMEST-DB-CLOSE-1 */
        public void M_020_FETCH_HISTMEST_DB_CLOSE_1()
        {
            /*" -361- EXEC SQL CLOSE HISTMEST END-EXEC */

            HISTMEST.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_020_EXIT*/

        [StopWatch]
        /*" M-030-PROCESSA-HISTMEST */
        private void M_030_PROCESSA_HISTMEST(bool isPerform = false)
        {
            /*" -370- IF W-CONT-LINHA GREATER 60 */

            if (FILLER_0.W_CONT_LINHA > 60)
            {

                /*" -372- PERFORM 800-ROTINA-CABECALHO THRU 800-EXIT. */

                M_800_ROTINA_CABECALHO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_800_EXIT*/

            }


            /*" -374- PERFORM 100-IMPRIME-DETALHE THRU 100-EXIT. */

            M_100_IMPRIME_DETALHE(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_EXIT*/


            /*" -374- PERFORM 020-FETCH-HISTMEST THRU 020-EXIT. */

            M_020_FETCH_HISTMEST(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_020_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_030_EXIT*/

        [StopWatch]
        /*" M-100-IMPRIME-DETALHE */
        private void M_100_IMPRIME_DETALHE(bool isPerform = false)
        {
            /*" -382- MOVE '004' TO WNR-EXEC-SQL. */
            _.Move("004", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -387- PERFORM M_100_IMPRIME_DETALHE_DB_SELECT_1 */

            M_100_IMPRIME_DETALHE_DB_SELECT_1();

            /*" -390- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -391- DISPLAY 'SINISTRO NUM. = ' V0HISTMEST-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO NUM. = {V0HISTMEST_NUM_APOL_SINISTRO}");

                /*" -393- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -395- MOVE '005' TO WNR-EXEC-SQL. */
            _.Move("005", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -400- PERFORM M_100_IMPRIME_DETALHE_DB_SELECT_2 */

            M_100_IMPRIME_DETALHE_DB_SELECT_2();

            /*" -403- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -404- DISPLAY 'SINISTRO NUM. = ' V0HISTMEST-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO NUM. = {V0HISTMEST_NUM_APOL_SINISTRO}");

                /*" -405- DISPLAY 'NUM_APOLICE   = ' V0HISTMEST-NUM-APOLICE */
                _.Display($"NUM_APOLICE   = {V0HISTMEST_NUM_APOLICE}");

                /*" -406- DISPLAY 'NUM. ITEM     = ' V0SINIAUTO1-NUM-ITEM */
                _.Display($"NUM. ITEM     = {V0SINIAUTO1_NUM_ITEM}");

                /*" -408- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -410- MOVE '006' TO WNR-EXEC-SQL. */
            _.Move("006", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -415- PERFORM M_100_IMPRIME_DETALHE_DB_SELECT_3 */

            M_100_IMPRIME_DETALHE_DB_SELECT_3();

            /*" -418- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -419- DISPLAY 'COD. CLIENTE = ' V0APOLICE-CODCLIEN */
                _.Display($"COD. CLIENTE = {V0APOLICE_CODCLIEN}");

                /*" -421- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -422- MOVE V0HISTMEST-FONTE TO LD01-FONTE. */
            _.Move(V0HISTMEST_FONTE, FILLER_0.LD01.LD01_FONTE);

            /*" -423- MOVE V0HISTMEST-PROTSINI TO LD01-PROTSINI. */
            _.Move(V0HISTMEST_PROTSINI, FILLER_0.LD01.LD01_PROTSINI);

            /*" -424- MOVE V0HISTMEST-DAC TO LD01-DAC. */
            _.Move(V0HISTMEST_DAC, FILLER_0.LD01.LD01_DAC);

            /*" -425- MOVE V0HISTMEST-NUM-APOL-SINISTRO TO LD01-NUM-SINISTRO. */
            _.Move(V0HISTMEST_NUM_APOL_SINISTRO, FILLER_0.LD01.LD01_NUM_SINISTRO);

            /*" -426- MOVE V0HISTMEST-NUM-APOLICE TO LD01-NUM-APOLICE. */
            _.Move(V0HISTMEST_NUM_APOLICE, FILLER_0.LD01.LD01_NUM_APOLICE);

            /*" -427- MOVE V0CLIENTE-NOME-RAZAO TO LD01-SEGURADO. */
            _.Move(V0CLIENTE_NOME_RAZAO, FILLER_0.LD01.LD01_SEGURADO);

            /*" -428- MOVE V0HISTMEST-VAL-OPERACAO TO LD02-VAL-OPERACAO. */
            _.Move(V0HISTMEST_VAL_OPERACAO, FILLER_0.LD02.LD02_VAL_OPERACAO);

            /*" -430- MOVE V0HISTMEST-NOMFAV TO LD01-FAVORECIDO. */
            _.Move(V0HISTMEST_NOMFAV, FILLER_0.LD02.LD01_FAVORECIDO);

            /*" -432- IF V0HISTMEST-NUM-APOL-SINISTRO NOT EQUAL W-NUM-APOL-SINISTRO-ANT */

            if (V0HISTMEST_NUM_APOL_SINISTRO != FILLER_0.W_NUM_APOL_SINISTRO_ANT)
            {

                /*" -433- WRITE REG-SI0836M1 FROM LD01 AFTER 2 */
                _.Move(FILLER_0.LD01.GetMoveValues(), REG_SI0836M1);

                SI0836M1.Write(REG_SI0836M1.GetMoveValues().ToString());

                /*" -435- MOVE V0HISTMEST-NUM-APOL-SINISTRO TO W-NUM-APOL-SINISTRO-ANT */
                _.Move(V0HISTMEST_NUM_APOL_SINISTRO, FILLER_0.W_NUM_APOL_SINISTRO_ANT);

                /*" -437- ADD 2 TO W-CONT-LINHA. */
                FILLER_0.W_CONT_LINHA.Value = FILLER_0.W_CONT_LINHA + 2;
            }


            /*" -438- WRITE REG-SI0836M1 FROM LD02 AFTER 1. */
            _.Move(FILLER_0.LD02.GetMoveValues(), REG_SI0836M1);

            SI0836M1.Write(REG_SI0836M1.GetMoveValues().ToString());

            /*" -438- ADD 1 TO W-CONT-LINHA. */
            FILLER_0.W_CONT_LINHA.Value = FILLER_0.W_CONT_LINHA + 1;

        }

        [StopWatch]
        /*" M-100-IMPRIME-DETALHE-DB-SELECT-1 */
        public void M_100_IMPRIME_DETALHE_DB_SELECT_1()
        {
            /*" -387- EXEC SQL SELECT NUM_ITEM INTO :V0SINIAUTO1-NUM-ITEM FROM SEGUROS.V0SINISTRO_AUTO1 WHERE NUM_APOL_SINISTRO = :V0HISTMEST-NUM-APOL-SINISTRO END-EXEC. */

            var m_100_IMPRIME_DETALHE_DB_SELECT_1_Query1 = new M_100_IMPRIME_DETALHE_DB_SELECT_1_Query1()
            {
                V0HISTMEST_NUM_APOL_SINISTRO = V0HISTMEST_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = M_100_IMPRIME_DETALHE_DB_SELECT_1_Query1.Execute(m_100_IMPRIME_DETALHE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SINIAUTO1_NUM_ITEM, V0SINIAUTO1_NUM_ITEM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_EXIT*/

        [StopWatch]
        /*" M-100-IMPRIME-DETALHE-DB-SELECT-2 */
        public void M_100_IMPRIME_DETALHE_DB_SELECT_2()
        {
            /*" -400- EXEC SQL SELECT CODCLIEN INTO :V0APOLICE-CODCLIEN FROM SEGUROS.V0APOLICE WHERE NUM_APOLICE = :V0HISTMEST-NUM-APOLICE END-EXEC. */

            var m_100_IMPRIME_DETALHE_DB_SELECT_2_Query1 = new M_100_IMPRIME_DETALHE_DB_SELECT_2_Query1()
            {
                V0HISTMEST_NUM_APOLICE = V0HISTMEST_NUM_APOLICE.ToString(),
            };

            var executed_1 = M_100_IMPRIME_DETALHE_DB_SELECT_2_Query1.Execute(m_100_IMPRIME_DETALHE_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0APOLICE_CODCLIEN, V0APOLICE_CODCLIEN);
            }


        }

        [StopWatch]
        /*" M-800-ROTINA-CABECALHO */
        private void M_800_ROTINA_CABECALHO(bool isPerform = false)
        {
            /*" -445- ACCEPT WHORA-CURR FROM TIME. */
            _.Move(_.AcceptDate("TIME"), FILLER_0.WHORA_CURR);

            /*" -446- MOVE WHORA-HH-CURR TO WHORA-HH-CABEC. */
            _.Move(FILLER_0.WHORA_CURR.WHORA_HH_CURR, FILLER_0.WHORA_CABEC.WHORA_HH_CABEC);

            /*" -447- MOVE WHORA-MM-CURR TO WHORA-MM-CABEC. */
            _.Move(FILLER_0.WHORA_CURR.WHORA_MM_CURR, FILLER_0.WHORA_CABEC.WHORA_MM_CABEC);

            /*" -448- MOVE WHORA-SS-CURR TO WHORA-SS-CABEC. */
            _.Move(FILLER_0.WHORA_CURR.WHORA_SS_CURR, FILLER_0.WHORA_CABEC.WHORA_SS_CABEC);

            /*" -450- MOVE WHORA-CABEC TO LC04-HORA. */
            _.Move(FILLER_0.WHORA_CABEC, FILLER_0.LC04.LC04_HORA);

            /*" -451- MOVE V1SISTEMA-DTMOVABE TO WDATA. */
            _.Move(V1SISTEMA_DTMOVABE, FILLER_0.WDATA);

            /*" -452- MOVE WDATA-DD TO LC04-DD-PAGTO. */
            _.Move(FILLER_0.WDATA.WDATA_DD, FILLER_0.LC04.LC04_DD_PAGTO);

            /*" -453- MOVE WDATA-MM TO LC04-MM-PAGTO. */
            _.Move(FILLER_0.WDATA.WDATA_MM, FILLER_0.LC04.LC04_MM_PAGTO);

            /*" -455- MOVE WDATA-AA TO LC04-AA-PAGTO. */
            _.Move(FILLER_0.WDATA.WDATA_AA, FILLER_0.LC04.LC04_AA_PAGTO);

            /*" -456- MOVE V1SISTEMA-DTCURRENT TO WDATA-CURR */
            _.Move(V1SISTEMA_DTCURRENT, FILLER_0.WDATA_CURR);

            /*" -457- MOVE WDATA-DD-CURR TO WDATA-DD-CABEC. */
            _.Move(FILLER_0.FILLER_44.WDATA_DD_CURR, FILLER_0.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -458- MOVE WDATA-MM-CURR TO WDATA-MM-CABEC. */
            _.Move(FILLER_0.FILLER_44.WDATA_MM_CURR, FILLER_0.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -459- MOVE WDATA-AA-CURR TO WDATA-AA-CABEC. */
            _.Move(FILLER_0.FILLER_44.WDATA_AA_CURR, FILLER_0.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -460- MOVE WDATA-CABEC TO LC02-DATA. */
            _.Move(FILLER_0.WDATA_CABEC, FILLER_0.LC02.LC02_DATA);

            /*" -462- MOVE W-CONT-PAGINA TO LC01-PAGINA. */
            _.Move(FILLER_0.W_CONT_PAGINA, FILLER_0.LC01.LC01_PAGINA);

            /*" -463- WRITE REG-SI0836M1 FROM LC01 AFTER NEW-PAGE. */
            _.Move(FILLER_0.LC01.GetMoveValues(), REG_SI0836M1);

            SI0836M1.Write(REG_SI0836M1.GetMoveValues().ToString());

            /*" -464- WRITE REG-SI0836M1 FROM LC02 AFTER 1. */
            _.Move(FILLER_0.LC02.GetMoveValues(), REG_SI0836M1);

            SI0836M1.Write(REG_SI0836M1.GetMoveValues().ToString());

            /*" -465- WRITE REG-SI0836M1 FROM LC04 AFTER 1. */
            _.Move(FILLER_0.LC04.GetMoveValues(), REG_SI0836M1);

            SI0836M1.Write(REG_SI0836M1.GetMoveValues().ToString());

            /*" -466- WRITE REG-SI0836M1 FROM LC05 AFTER 1. */
            _.Move(FILLER_0.LC05.GetMoveValues(), REG_SI0836M1);

            SI0836M1.Write(REG_SI0836M1.GetMoveValues().ToString());

            /*" -467- WRITE REG-SI0836M1 FROM LC06 AFTER 1. */
            _.Move(FILLER_0.LC06.GetMoveValues(), REG_SI0836M1);

            SI0836M1.Write(REG_SI0836M1.GetMoveValues().ToString());

            /*" -469- WRITE REG-SI0836M1 FROM LC05 AFTER 1. */
            _.Move(FILLER_0.LC05.GetMoveValues(), REG_SI0836M1);

            SI0836M1.Write(REG_SI0836M1.GetMoveValues().ToString());

            /*" -470- ADD 1 TO W-CONT-PAGINA. */
            FILLER_0.W_CONT_PAGINA.Value = FILLER_0.W_CONT_PAGINA + 1;

            /*" -470- MOVE 7 TO W-CONT-LINHA. */
            _.Move(7, FILLER_0.W_CONT_LINHA);

        }

        [StopWatch]
        /*" M-100-IMPRIME-DETALHE-DB-SELECT-3 */
        public void M_100_IMPRIME_DETALHE_DB_SELECT_3()
        {
            /*" -415- EXEC SQL SELECT NOME_RAZAO INTO :V0CLIENTE-NOME-RAZAO FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = :V0APOLICE-CODCLIEN END-EXEC. */

            var m_100_IMPRIME_DETALHE_DB_SELECT_3_Query1 = new M_100_IMPRIME_DETALHE_DB_SELECT_3_Query1()
            {
                V0APOLICE_CODCLIEN = V0APOLICE_CODCLIEN.ToString(),
            };

            var executed_1 = M_100_IMPRIME_DETALHE_DB_SELECT_3_Query1.Execute(m_100_IMPRIME_DETALHE_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CLIENTE_NOME_RAZAO, V0CLIENTE_NOME_RAZAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_800_EXIT*/

        [StopWatch]
        /*" M-810-IMPRIME-SEM-MOVIMENTO */
        private void M_810_IMPRIME_SEM_MOVIMENTO(bool isPerform = false)
        {
            /*" -476- WRITE REG-SI0836M1 FROM LD99 AFTER 5. */
            _.Move(FILLER_0.LD99.GetMoveValues(), REG_SI0836M1);

            SI0836M1.Write(REG_SI0836M1.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_810_EXIT*/

        [StopWatch]
        /*" M-999-999-ROT-ERRO */
        private void M_999_999_ROT_ERRO(bool isPerform = false)
        {
            /*" -483- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -484- DISPLAY ' ' */
                _.Display($" ");

                /*" -485- DISPLAY '*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*' */
                _.Display($"*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*");

                /*" -486- DISPLAY '*  TERMINO ANORMAL DO PROGRAMA SI0836B  *' */
                _.Display($"*  TERMINO ANORMAL DO PROGRAMA SI0836B  *");

                /*" -487- DISPLAY '*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*' */
                _.Display($"*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*");

                /*" -488- DISPLAY ' ' */
                _.Display($" ");

                /*" -489- DISPLAY '==> SEQUENCIAL DE ACESSO COM ERRO = ' WNR-EXEC-SQL */
                _.Display($"==> SEQUENCIAL DE ACESSO COM ERRO = {FILLER_0.WABEND.WNR_EXEC_SQL}");

                /*" -490- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, FILLER_0.WABEND2.WSQLCODE);

                /*" -491- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], FILLER_0.WABEND2.WSQLCODE1);

                /*" -492- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], FILLER_0.WABEND2.WSQLCODE2);

                /*" -493- MOVE SQLCODE TO WSQLCODE3 */
                _.Move(DB.SQLCODE, FILLER_0.WSQLCODE3);

                /*" -494- DISPLAY WABEND */
                _.Display(FILLER_0.WABEND);

                /*" -496- DISPLAY WABEND2. */
                _.Display(FILLER_0.WABEND2);
            }


            /*" -496- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -497- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -499- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -500- CLOSE SI0836M1. */
            SI0836M1.Close();

            /*" -500- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_999_999_EXIT*/
    }
}