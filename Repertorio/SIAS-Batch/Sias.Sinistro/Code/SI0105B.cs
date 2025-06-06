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
using Sias.Sinistro.DB2.SI0105B;

namespace Code
{
    public class SI0105B
    {
        public bool IsCall { get; set; }

        public SI0105B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *///////////////////////////////////////////////////////////////      */
        /*"      *///////////////////////////////////////////////////////////////      */
        /*"      *-----------------------------------------------------------*           */
        /*" ====>* MIGRACAO P/ COBOL II - FASE 1 - ITEM 3.2.A -> OK - ADRIANA            */
        /*"      *-----------------------------------------------------------*           */
        /*"      *REMARKS.                                                               */
        /*"      *///////////////////////////////////////////////////////////////      */
        /*"      *       EMISSAO DA RELACAO DE SINISTROS AVISADOS EM UM        //      */
        /*"      *     DETERMINADO PERIODO E NAO LIBERADOS PARA PAGAMENTO      //      */
        /*"      *-------------------------------------------------------------//      */
        /*"      * ANALISTA    - JOSE AGNALDO                                  //      */
        /*"      * PROGRAMADOR - BL                                            //      */
        /*"      * DATA        - 18/05/93                                      //      */
        /*"      *                                                                *      */
        /*"      * CONVERSAO ANO 2000              CONSEDA4              05/1998  *      */
        /*"      *                                                                *      */
        /*"      * REVISAO - ANO 2000              CONSEDA4           06/06/1998  *      */
        /*"      *///////////////////////////////////////////////////////////////      */
        #endregion


        #region VARIABLES

        public FileBasis _SI0105M1 { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis SI0105M1
        {
            get
            {
                _.Move(REG_SI0105M1, _SI0105M1); VarBasis.RedefinePassValue(REG_SI0105M1, _SI0105M1, REG_SI0105M1); return _SI0105M1;
            }
        }
        /*"01  REG-SI0105M1.*/
        public SI0105B_REG_SI0105M1 REG_SI0105M1 { get; set; } = new SI0105B_REG_SI0105M1();
        public class SI0105B_REG_SI0105M1 : VarBasis
        {
            /*"    05  LINHA                  PIC  X(132).*/
            public StringBasis LINHA { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  V1HISTMEST-RAMO            PIC S9(04)       COMP.*/
        public IntBasis V1HISTMEST_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1HISTMEST-FONTE           PIC S9(04)       COMP.*/
        public IntBasis V1HISTMEST_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1HISTMEST-DATCMD          PIC  X(10).*/
        public StringBasis V1HISTMEST_DATCMD { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1HISTMEST-DATORR          PIC  X(10).*/
        public StringBasis V1HISTMEST_DATORR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1HISTMEST-SIGLUNIM        PIC  X(06).*/
        public StringBasis V1HISTMEST_SIGLUNIM { get; set; } = new StringBasis(new PIC("X", "6", "X(06)."), @"");
        /*"77  V1HISTMEST-MODALIDA        PIC S9(04)       COMP.*/
        public IntBasis V1HISTMEST_MODALIDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1HISTMEST-VLCRUZAD        PIC S9(06)V9(09) COMP-3.*/
        public DoubleBasis V1HISTMEST_VLCRUZAD { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(09)"), 9);
        /*"77  V1HISTMEST-NUM-SINISTRO    PIC S9(13)       COMP-3.*/
        public IntBasis V1HISTMEST_NUM_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V1HISTMEST-VAL-OPERACAO    PIC S9(13)V99    COMP-3.*/
        public DoubleBasis V1HISTMEST_VAL_OPERACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  V1HISTMEST-NOME            PIC  X(40).*/
        public StringBasis V1HISTMEST_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77  V1RELATORIOS-DATA1         PIC  X(10).*/
        public StringBasis V1RELATORIOS_DATA1 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1RELATORIOS-DATA2         PIC  X(10).*/
        public StringBasis V1RELATORIOS_DATA2 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1RELATORIOS-APOLICE1      PIC S9(13)       COMP-3.*/
        public IntBasis V1RELATORIOS_APOLICE1 { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V1RELATORIOS-APOLICE2      PIC S9(13)       COMP-3.*/
        public IntBasis V1RELATORIOS_APOLICE2 { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V1RAMO-NOMERAMO            PIC  X(30).*/
        public StringBasis V1RAMO_NOMERAMO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"77  V1FONTE-NOMEFTE            PIC  X(30).*/
        public StringBasis V1FONTE_NOMEFTE { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"77  V1SISTEMA-DTMOVABE         PIC  X(10).*/
        public StringBasis V1SISTEMA_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1SISTEMA-DTCURRENT        PIC  X(10).*/
        public StringBasis V1SISTEMA_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1EMPRESA-NOME-EMPRESA     PIC  X(40).*/
        public StringBasis V1EMPRESA_NOME_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"01  FILLER.*/
        public SI0105B_FILLER_0 FILLER_0 { get; set; } = new SI0105B_FILLER_0();
        public class SI0105B_FILLER_0 : VarBasis
        {
            /*"    03  LC01.*/
            public SI0105B_LC01 LC01 { get; set; } = new SI0105B_LC01();
            public class SI0105B_LC01 : VarBasis
            {
                /*"        05  FILLER             PIC  X(09) VALUE 'SI0105B.1'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"SI0105B.1");
                /*"        05  FILLER             PIC  X(34) VALUE  SPACES.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"");
                /*"        05  LC01-NOME-EMPRESA  PIC  X(74) VALUE  SPACES.*/
                public StringBasis LC01_NOME_EMPRESA { get; set; } = new StringBasis(new PIC("X", "74", "X(74)"), @"");
                /*"        05  FILLER             PIC  X(11) VALUE 'PAGINA'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"PAGINA");
                /*"        05  LC01-PAGINA        PIC  ZZZ9.*/
                public IntBasis LC01_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
                /*"    03  LC02.*/
            }
            public SI0105B_LC02 LC02 { get; set; } = new SI0105B_LC02();
            public class SI0105B_LC02 : VarBasis
            {
                /*"        05  FILLER             PIC X(117) VALUE  SPACES.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "117", "X(117)"), @"");
                /*"        05  FILLER             PIC  X(05) VALUE 'DATA'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"DATA");
                /*"        05  LC02-DATA          PIC  X(10) VALUE  SPACES.*/
                public StringBasis LC02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"    03  LC03.*/
            }
            public SI0105B_LC03 LC03 { get; set; } = new SI0105B_LC03();
            public class SI0105B_LC03 : VarBasis
            {
                /*"        05  FILLER             PIC X(117) VALUE  SPACES.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "117", "X(117)"), @"");
                /*"        05  FILLER             PIC  X(07) VALUE 'HORA'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"HORA");
                /*"        05  LC03-HORA          PIC  X(08) VALUE  SPACES.*/
                public StringBasis LC03_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
                /*"    03  LC04.*/
            }
            public SI0105B_LC04 LC04 { get; set; } = new SI0105B_LC04();
            public class SI0105B_LC04 : VarBasis
            {
                /*"        05  FILLER             PIC  X(23) VALUE  SPACES.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
                /*"        05  FILLER             PIC  X(08) VALUE 'RELACAO'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"RELACAO");
                /*"        05  FILLER             PIC  X(03) VALUE 'DE'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"DE");
                /*"        05  FILLER             PIC  X(10) VALUE 'SINISTROS'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"SINISTROS");
                /*"        05  FILLER             PIC  X(09) VALUE 'AVISADOS'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"AVISADOS");
                /*"        05  FILLER             PIC  X(02) VALUE 'E'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"E");
                /*"        05  FILLER             PIC  X(04) VALUE 'NAO'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"NAO");
                /*"        05  FILLER             PIC  X(10) VALUE 'LIBERADOS'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"LIBERADOS");
                /*"        05  FILLER             PIC  X(03) VALUE 'NO'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NO");
                /*"        05  FILLER             PIC  X(08) VALUE 'PERIODO'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"PERIODO");
                /*"        05  FILLER             PIC  X(03) VALUE 'DE'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"DE");
                /*"        05  LC04-DATA1         PIC  X(11) VALUE  SPACES.*/
                public StringBasis LC04_DATA1 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"");
                /*"        05  FILLER             PIC  X(04) VALUE 'ATE'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"ATE");
                /*"        05  LC04-DATA2         PIC  X(10) VALUE  SPACES.*/
                public StringBasis LC04_DATA2 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"    03  LC05.*/
            }
            public SI0105B_LC05 LC05 { get; set; } = new SI0105B_LC05();
            public class SI0105B_LC05 : VarBasis
            {
                /*"        05  FILLER             PIC  X(07) VALUE 'RAMO'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"RAMO");
                /*"        05  LC05-RAMO          PIC  9(03) VALUE  ZEROES.*/
                public IntBasis LC05_RAMO { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
                /*"        05  FILLER             PIC  X(03) VALUE ' - '.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" - ");
                /*"        05  LC05-NOMERAMO      PIC  X(30) VALUE  SPACES.*/
                public StringBasis LC05_NOMERAMO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
                /*"    03  LC06.*/
            }
            public SI0105B_LC06 LC06 { get; set; } = new SI0105B_LC06();
            public class SI0105B_LC06 : VarBasis
            {
                /*"        05  FILLER             PIC  X(07) VALUE 'FONTE'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"FONTE");
                /*"        05  LC06-FONTE         PIC  9(03) VALUE  ZEROES.*/
                public IntBasis LC06_FONTE { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
                /*"        05  FILLER             PIC  X(03) VALUE ' - '.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" - ");
                /*"        05  LC06-NOMEFTE       PIC  X(30) VALUE  SPACES.*/
                public StringBasis LC06_NOMEFTE { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
                /*"    03  LC07.*/
            }
            public SI0105B_LC07 LC07 { get; set; } = new SI0105B_LC07();
            public class SI0105B_LC07 : VarBasis
            {
                /*"        05  FILLER             PIC X(132) VALUE  ALL '-'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
                /*"    03  LC08.*/
            }
            public SI0105B_LC08 LC08 { get; set; } = new SI0105B_LC08();
            public class SI0105B_LC08 : VarBasis
            {
                /*"        05  FILLER             PIC  X(06) VALUE  SPACES.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"");
                /*"        05  FILLER             PIC  X(20) VALUE 'SINISTRO'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"SINISTRO");
                /*"        05  FILLER             PIC  X(05) VALUE 'DATA'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"DATA");
                /*"        05  FILLER             PIC  X(11) VALUE 'AVISO'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"AVISO");
                /*"        05  FILLER             PIC  X(05) VALUE 'DATA'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"DATA");
                /*"        05  FILLER             PIC  X(30) VALUE 'OCORRENCIA'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"OCORRENCIA");
                /*"        05  FILLER             PIC  X(06) VALUE 'VALOR'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"VALOR");
                /*"        05  FILLER             PIC  X(13) VALUE 'AVISADO'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"AVISADO");
                /*"        05  FILLER             PIC  X(24) VALUE 'MOEDA'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "24", "X(24)"), @"MOEDA");
                /*"        05  FILLER             PIC  X(12) VALUE 'QUANTIDADE'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"QUANTIDADE");
                /*"    03  LC09.*/
            }
            public SI0105B_LC09 LC09 { get; set; } = new SI0105B_LC09();
            public class SI0105B_LC09 : VarBasis
            {
                /*"        05  FILLER             PIC  X(33) VALUE  SPACES.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "33", "X(33)"), @"");
                /*"        05  FILLER             PIC  X(10) VALUE 'APOLICE : '.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"APOLICE : ");
                /*"        05  LC09-APOLICE       PIC  9(13).*/
                public IntBasis LC09_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
                /*"        05  FILLER             PIC  X(03) VALUE ' - '.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" - ");
                /*"        05  LC09-NOME-APOL     PIC  X(40).*/
                public StringBasis LC09_NOME_APOL { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"    03  LD01.*/
            }
            public SI0105B_LD01 LD01 { get; set; } = new SI0105B_LD01();
            public class SI0105B_LD01 : VarBasis
            {
                /*"        05  FILLER             PIC  X(04) VALUE  SPACES.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
                /*"        05  LD01-SINISTRO      PIC  9(13) VALUE  ZEROES.*/
                public IntBasis LD01_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
                /*"        05  FILLER             PIC  X(09) VALUE  SPACES.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"");
                /*"        05  LD01-DATCMD        PIC  X(10) VALUE  SPACES.*/
                public StringBasis LD01_DATCMD { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"        05  FILLER             PIC  X(08) VALUE  SPACES.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
                /*"        05  LD01-DATORR        PIC  X(10) VALUE  SPACES.*/
                public StringBasis LD01_DATORR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"        05  FILLER             PIC  X(16) VALUE  SPACES.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"");
                /*"        05  LD01-VAL-OPERACAO  PIC  Z.ZZZ.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LD01_VAL_OPERACAO { get; set; } = new DoubleBasis(new PIC("9", "13", "Z.ZZZ.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"        05  FILLER             PIC  X(06) VALUE  SPACES.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"");
                /*"        05  LD01-SIGLUNIM      PIC  X(06) VALUE  SPACES.*/
                public StringBasis LD01_SIGLUNIM { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"");
                /*"        05  FILLER             PIC  X(05) VALUE  SPACES.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
                /*"        05  LD01-VAL-OPERACAO1 PIC  Z.ZZZ.ZZZ.ZZZ.ZZ9,99999.*/
                public DoubleBasis LD01_VAL_OPERACAO1 { get; set; } = new DoubleBasis(new PIC("9", "13", "Z.ZZZ.ZZZ.ZZZ.ZZ9V99999."), 5);
                /*"    03  LT01.*/
            }
            public SI0105B_LT01 LT01 { get; set; } = new SI0105B_LT01();
            public class SI0105B_LT01 : VarBasis
            {
                /*"        05  FILLER             PIC  X(45) VALUE  SPACES.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "45", "X(45)"), @"");
                /*"        05  FILLER             PIC  X(06) VALUE 'VALOR'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"VALOR");
                /*"        05  FILLER             PIC  X(06) VALUE 'TOTAL'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"TOTAL");
                /*"        05  FILLER             PIC  X(09) VALUE 'FONTE'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"FONTE");
                /*"        05  LT01-ACC-FONTE     PIC  Z.ZZZ.ZZZ.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LT01_ACC_FONTE { get; set; } = new DoubleBasis(new PIC("9", "16", "Z.ZZZ.ZZZ.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"        05  FILLER             PIC  X(17) VALUE  SPACES.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @"");
                /*"        05  LT01-ACC-FONTE1    PIC  Z.ZZZ.ZZZ.ZZZ.ZZ9,99999.*/
                public DoubleBasis LT01_ACC_FONTE1 { get; set; } = new DoubleBasis(new PIC("9", "13", "Z.ZZZ.ZZZ.ZZZ.ZZ9V99999."), 5);
                /*"    03  LT02.*/
            }
            public SI0105B_LT02 LT02 { get; set; } = new SI0105B_LT02();
            public class SI0105B_LT02 : VarBasis
            {
                /*"        05  FILLER             PIC  X(45) VALUE  SPACES.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "45", "X(45)"), @"");
                /*"        05  FILLER             PIC  X(06) VALUE 'VALOR'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"VALOR");
                /*"        05  FILLER             PIC  X(06) VALUE 'TOTAL'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"TOTAL");
                /*"        05  FILLER             PIC  X(09) VALUE 'RAMO'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"RAMO");
                /*"        05  LT02-ACC-RAMO      PIC  Z.ZZZ.ZZZ.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LT02_ACC_RAMO { get; set; } = new DoubleBasis(new PIC("9", "16", "Z.ZZZ.ZZZ.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"        05  FILLER             PIC  X(17) VALUE  SPACES.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @"");
                /*"        05  LT02-ACC-RAMO1     PIC  Z.ZZZ.ZZZ.ZZZ.ZZ9,99999.*/
                public DoubleBasis LT02_ACC_RAMO1 { get; set; } = new DoubleBasis(new PIC("9", "13", "Z.ZZZ.ZZZ.ZZZ.ZZ9V99999."), 5);
                /*"    03  LT03.*/
            }
            public SI0105B_LT03 LT03 { get; set; } = new SI0105B_LT03();
            public class SI0105B_LT03 : VarBasis
            {
                /*"        05  FILLER             PIC  X(45) VALUE  SPACES.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "45", "X(45)"), @"");
                /*"        05  FILLER             PIC  X(06) VALUE 'VALOR'.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"VALOR");
                /*"        05  FILLER             PIC  X(06) VALUE 'TOTAL'.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"TOTAL");
                /*"        05  FILLER             PIC  X(09) VALUE 'GERAL'.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"GERAL");
                /*"        05  LT03-ACC-GERAL     PIC  Z.ZZZ.ZZZ.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LT03_ACC_GERAL { get; set; } = new DoubleBasis(new PIC("9", "16", "Z.ZZZ.ZZZ.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"        05  FILLER             PIC  X(17) VALUE  SPACES.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @"");
                /*"        05  LT03-ACC-GERAL1    PIC  Z.ZZZ.ZZZ.ZZZ.ZZ9,99999.*/
                public DoubleBasis LT03_ACC_GERAL1 { get; set; } = new DoubleBasis(new PIC("9", "13", "Z.ZZZ.ZZZ.ZZZ.ZZ9V99999."), 5);
                /*"    03  WDATA.*/
            }
            public SI0105B_WDATA WDATA { get; set; } = new SI0105B_WDATA();
            public class SI0105B_WDATA : VarBasis
            {
                /*"        05  WDATA-AA           PIC  9(04) VALUE  ZEROES.*/
                public IntBasis WDATA_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"        05  FILLER             PIC  X(01) VALUE  SPACES.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  WDATA-MM           PIC  9(02) VALUE  ZEROES.*/
                public IntBasis WDATA_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"        05  FILLER             PIC  X(01) VALUE  SPACES.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  WDATA-DD           PIC  9(02) VALUE  ZEROES.*/
                public IntBasis WDATA_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    03  WDATA-CURR.*/
            }
            public SI0105B_WDATA_CURR WDATA_CURR { get; set; } = new SI0105B_WDATA_CURR();
            public class SI0105B_WDATA_CURR : VarBasis
            {
                /*"        05  WDATA-AA-CURR      PIC  9(04) VALUE  ZEROES.*/
                public IntBasis WDATA_AA_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"        05  FILLER             PIC  X(01) VALUE  SPACES.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  WDATA-MM-CURR      PIC  9(02) VALUE  ZEROES.*/
                public IntBasis WDATA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"        05  FILLER             PIC  X(01) VALUE  SPACES.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  WDATA-DD-CURR      PIC  9(02) VALUE  ZEROES.*/
                public IntBasis WDATA_DD_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    03  WHORA-CURR.*/
            }
            public SI0105B_WHORA_CURR WHORA_CURR { get; set; } = new SI0105B_WHORA_CURR();
            public class SI0105B_WHORA_CURR : VarBasis
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
            public SI0105B_WDATA_CABEC WDATA_CABEC { get; set; } = new SI0105B_WDATA_CABEC();
            public class SI0105B_WDATA_CABEC : VarBasis
            {
                /*"        05  WDATA-DD-CABEC     PIC  9(02) VALUE  ZEROES.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"        05  FILLER             PIC  X(01) VALUE '/'.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"        05  WDATA-MM-CABEC     PIC  9(02) VALUE  ZEROES.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"        05  FILLER             PIC  X(01) VALUE '/'.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"        05  WDATA-AA-CABEC     PIC  9(04) VALUE  ZEROES.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"    03  WHORA-CABEC.*/
            }
            public SI0105B_WHORA_CABEC WHORA_CABEC { get; set; } = new SI0105B_WHORA_CABEC();
            public class SI0105B_WHORA_CABEC : VarBasis
            {
                /*"        05  WHORA-HH-CABEC     PIC  9(02) VALUE  ZEROES.*/
                public IntBasis WHORA_HH_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"        05  FILLER             PIC  X(01) VALUE ':'.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @":");
                /*"        05  WHORA-MM-CABEC     PIC  9(02) VALUE  ZEROES.*/
                public IntBasis WHORA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"        05  FILLER             PIC  X(01) VALUE ':'.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @":");
                /*"        05  WHORA-SS-CABEC     PIC  9(02) VALUE  ZEROES.*/
                public IntBasis WHORA_SS_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    03  W-FIM-RELATORIOS       PIC  X(01)    VALUE 'N'.*/
            }
            public StringBasis W_FIM_RELATORIOS { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"N");
            /*"    03  W-FIM-HISTMEST         PIC  X(01)    VALUE 'N'.*/
            public StringBasis W_FIM_HISTMEST { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"N");
            /*"    03  W-MODALIDA-ANT         PIC S9(04)    VALUE ZEROES COMP.*/
            public IntBasis W_MODALIDA_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    03  W-LIDOS                PIC S9(06)    VALUE ZEROES COMP.*/
            public IntBasis W_LIDOS { get; set; } = new IntBasis(new PIC("S9", "6", "S9(06)"));
            /*"    03  W-IMPRESSOS            PIC S9(06)    VALUE ZEROES COMP.*/
            public IntBasis W_IMPRESSOS { get; set; } = new IntBasis(new PIC("S9", "6", "S9(06)"));
            /*"    03  W-CONT-PAG             PIC S9(04)    VALUE +00000 COMP.*/
            public IntBasis W_CONT_PAG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"), +00000);
            /*"    03  W-CONT-LIN             PIC S9(02)    VALUE +00070 COMP.*/
            public IntBasis W_CONT_LIN { get; set; } = new IntBasis(new PIC("S9", "2", "S9(02)"), +00070);
            /*"    03  W-ACC-RAMO             PIC S9(16)V99 VALUE ZEROES COMP-3*/
            public DoubleBasis W_ACC_RAMO { get; set; } = new DoubleBasis(new PIC("S9", "16", "S9(16)V99"), 2);
            /*"    03  W-ACC-FONTE            PIC S9(16)V99 VALUE ZEROES COMP-3*/
            public DoubleBasis W_ACC_FONTE { get; set; } = new DoubleBasis(new PIC("S9", "16", "S9(16)V99"), 2);
            /*"    03  W-ACC-GERAL            PIC S9(16)V99 VALUE ZEROES COMP-3*/
            public DoubleBasis W_ACC_GERAL { get; set; } = new DoubleBasis(new PIC("S9", "16", "S9(16)V99"), 2);
            /*"    03  W-ACC-RAMO1            PIC S9(13)V9(5) VALUE +000 COMP-3*/
            public DoubleBasis W_ACC_RAMO1 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(5)"), 5, +000);
            /*"    03  W-ACC-FONTE1           PIC S9(13)V9(5) VALUE +000 COMP-3*/
            public DoubleBasis W_ACC_FONTE1 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(5)"), 5, +000);
            /*"    03  W-ACC-GERAL1           PIC S9(13)V9(5) VALUE +000 COMP-3*/
            public DoubleBasis W_ACC_GERAL1 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(5)"), 5, +000);
            /*"    03  W-VAL-OPERACAO1        PIC S9(13)V9(5) VALUE +000 COMP-3*/
            public DoubleBasis W_VAL_OPERACAO1 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(5)"), 5, +000);
            /*"    03  WSQLCODE3              PIC S9(09) VALUE  ZEROES COMP.*/
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"    03  WABEND.*/
            public SI0105B_WABEND WABEND { get; set; } = new SI0105B_WABEND();
            public class SI0105B_WABEND : VarBasis
            {
                /*"        05  FILLER             PIC  X(01) VALUE  SPACE.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  FILLER             PIC  X(09) VALUE 'SI0105B'.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"SI0105B");
                /*"        05  FILLER             PIC  X(10) VALUE '*** ERRO'.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"*** ERRO");
                /*"        05  FILLER             PIC  X(10) VALUE 'EXEC SQL'.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"EXEC SQL");
                /*"        05  FILLER             PIC  X(08) VALUE 'NUMERO'.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"NUMERO");
                /*"        05  WNR-EXEC-SQL       PIC  X(03) VALUE  SPACES.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
                /*"        05  FILLER             PIC  X(01) VALUE  SPACE.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  FILLER             PIC  X(16) VALUE '** PARAGRAFO ='*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"** PARAGRAFO =");
                /*"        05  PARAGRAFO          PIC  X(30) VALUE  SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
                /*"        05  FILLER             PIC  X(04) VALUE  SPACES.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
                /*"        05  FILLER             PIC  X(10) VALUE 'SQLCODE = '.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"SQLCODE = ");
                /*"        05  WSQLCODE           PIC  ZZZZZZ999-   VALUE ZEROES.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"        05  FILLER             PIC  X(04) VALUE  SPACES.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
                /*"        05  FILLER             PIC  X(10) VALUE 'SQLCODE1= '.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"SQLCODE1= ");
                /*"        05  WSQLCODE1          PIC  ZZZZZZ999-   VALUE ZEROES.*/
                public IntBasis WSQLCODE1 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"        05  FILLER             PIC  X(04) VALUE  SPACES.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
                /*"        05  FILLER             PIC  X(10) VALUE 'SQLCODE2= '.*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"SQLCODE2= ");
                /*"        05  WSQLCODE2          PIC  ZZZZZZ999-   VALUE ZEROES.*/
                public IntBasis WSQLCODE2 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"    03  FILLER.*/
            }
            public SI0105B_FILLER_80 FILLER_80 { get; set; } = new SI0105B_FILLER_80();
            public class SI0105B_FILLER_80 : VarBasis
            {
                /*"        05  W-MENSAGEM1        PIC  X(35) VALUE           'SI0105B - SEM MOVIMENTOS NO DIA'.*/
                public StringBasis W_MENSAGEM1 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"SI0105B - SEM MOVIMENTOS NO DIA");
                /*"        05  W-MENSAGEM2        PIC  X(35) VALUE           'SI0105B - EMPRESA NAO ENCONTRADA'.*/
                public StringBasis W_MENSAGEM2 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"SI0105B - EMPRESA NAO ENCONTRADA");
                /*"        05  W-MENSAGEM3        PIC  X(35) VALUE           'SI0105B - SISTEMA NAO ENCONTRADO'.*/
                public StringBasis W_MENSAGEM3 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"SI0105B - SISTEMA NAO ENCONTRADO");
                /*"        05  W-MENSAGEM4        PIC  X(35) VALUE           'SI0105B - RAMO NAO ENCONTRADO'.*/
                public StringBasis W_MENSAGEM4 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"SI0105B - RAMO NAO ENCONTRADO");
                /*"        05  W-MENSAGEM5        PIC  X(35) VALUE           'SI0105B - FONTE NAO ENCONTRADA'.*/
                public StringBasis W_MENSAGEM5 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"SI0105B - FONTE NAO ENCONTRADA");
                /*"01  LK-LINK.*/
            }
        }
        public SI0105B_LK_LINK LK_LINK { get; set; } = new SI0105B_LK_LINK();
        public class SI0105B_LK_LINK : VarBasis
        {
            /*"    03  LK-RTCODE              PIC S9(04) VALUE  +00000 COMP.*/
            public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"), +00000);
            /*"    03  LK-TAMANHO             PIC S9(04) VALUE  +00040 COMP.*/
            public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"), +00040);
            /*"    03  LK-TITULO              PIC X(132) VALUE  SPACES.*/
            public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
        }


        public SI0105B_RELATORIOS RELATORIOS { get; set; } = new SI0105B_RELATORIOS();
        public SI0105B_HISTMEST HISTMEST { get; set; } = new SI0105B_HISTMEST();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SI0105M1_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SI0105M1.SetFile(SI0105M1_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM M-000-000-PRINCIPAL-SECTION */

                M_000_000_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" M-000-000-PRINCIPAL-SECTION */
        private void M_000_000_PRINCIPAL_SECTION()
        {
            /*" -316- MOVE '000-000-PRINCIPAL' TO PARAGRAFO. */
            _.Move("000-000-PRINCIPAL", FILLER_0.WABEND.PARAGRAFO);

            /*" -318- MOVE '000' TO WNR-EXEC-SQL. */
            _.Move("000", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -318- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -319- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -320- EXEC SQL WHENEVER SQLERROR GO TO 999-999-ROT-ERRO END-EXEC. */

            /*" -324- OPEN OUTPUT SI0105M1. */
            SI0105M1.Open(REG_SI0105M1);

            /*" -326- ACCEPT WHORA-CURR FROM TIME. */
            _.Move(_.AcceptDate("TIME"), FILLER_0.WHORA_CURR);

            /*" -327- MOVE WHORA-HH-CURR TO WHORA-HH-CABEC. */
            _.Move(FILLER_0.WHORA_CURR.WHORA_HH_CURR, FILLER_0.WHORA_CABEC.WHORA_HH_CABEC);

            /*" -328- MOVE WHORA-MM-CURR TO WHORA-MM-CABEC. */
            _.Move(FILLER_0.WHORA_CURR.WHORA_MM_CURR, FILLER_0.WHORA_CABEC.WHORA_MM_CABEC);

            /*" -329- MOVE WHORA-SS-CURR TO WHORA-SS-CABEC. */
            _.Move(FILLER_0.WHORA_CURR.WHORA_SS_CURR, FILLER_0.WHORA_CABEC.WHORA_SS_CABEC);

            /*" -331- MOVE WHORA-CABEC TO LC03-HORA. */
            _.Move(FILLER_0.WHORA_CABEC, FILLER_0.LC03.LC03_HORA);

            /*" -333- PERFORM 000-200-SELECT-V1SISTEMA. */

            M_000_200_SELECT_V1SISTEMA_SECTION();

            /*" -334- MOVE V1SISTEMA-DTCURRENT TO WDATA-CURR */
            _.Move(V1SISTEMA_DTCURRENT, FILLER_0.WDATA_CURR);

            /*" -335- MOVE WDATA-DD-CURR TO WDATA-DD-CABEC. */
            _.Move(FILLER_0.WDATA_CURR.WDATA_DD_CURR, FILLER_0.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -336- MOVE WDATA-MM-CURR TO WDATA-MM-CABEC. */
            _.Move(FILLER_0.WDATA_CURR.WDATA_MM_CURR, FILLER_0.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -337- MOVE WDATA-AA-CURR TO WDATA-AA-CABEC. */
            _.Move(FILLER_0.WDATA_CURR.WDATA_AA_CURR, FILLER_0.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -339- MOVE WDATA-CABEC TO LC02-DATA. */
            _.Move(FILLER_0.WDATA_CABEC, FILLER_0.LC02.LC02_DATA);

            /*" -340- PERFORM 000-100-SELECT-V1EMPRESA. */

            M_000_100_SELECT_V1EMPRESA_SECTION();

            /*" -341- PERFORM 000-300-DECLARE-RELATORIOS. */

            M_000_300_DECLARE_RELATORIOS_SECTION();

            /*" -343- PERFORM 000-400-FETCH-RELATORIOS. */

            M_000_400_FETCH_RELATORIOS_SECTION();

            /*" -344- IF W-FIM-RELATORIOS EQUAL 'S' */

            if (FILLER_0.W_FIM_RELATORIOS == "S")
            {

                /*" -345- DISPLAY W-MENSAGEM1 */
                _.Display(FILLER_0.FILLER_80.W_MENSAGEM1);

                /*" -347- PERFORM 000-700-FINALIZA. */

                M_000_700_FINALIZA_SECTION();
            }


            /*" -350- PERFORM 000-500-PROCESSA-RELATORIOS UNTIL W-FIM-RELATORIOS EQUAL 'S' . */

            while (!(FILLER_0.W_FIM_RELATORIOS == "S"))
            {

                M_000_500_PROCESSA_RELATORIOS_SECTION();
            }

            /*" -351- PERFORM 000-600-UPDATE-V1RELATORIOS. */

            M_000_600_UPDATE_V1RELATORIOS_SECTION();

            /*" -351- PERFORM 000-700-FINALIZA. */

            M_000_700_FINALIZA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_000_EXIT*/

        [StopWatch]
        /*" M-000-100-SELECT-V1EMPRESA-SECTION */
        private void M_000_100_SELECT_V1EMPRESA_SECTION()
        {
            /*" -360- MOVE '000-100-SELECT-V1EMPRESA' TO PARAGRAFO. */
            _.Move("000-100-SELECT-V1EMPRESA", FILLER_0.WABEND.PARAGRAFO);

            /*" -364- MOVE '001' TO WNR-EXEC-SQL. */
            _.Move("001", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -374- PERFORM M_000_100_SELECT_V1EMPRESA_DB_SELECT_1 */

            M_000_100_SELECT_V1EMPRESA_DB_SELECT_1();

            /*" -380- MOVE V1EMPRESA-NOME-EMPRESA TO LK-TITULO. */
            _.Move(V1EMPRESA_NOME_EMPRESA, LK_LINK.LK_TITULO);

            /*" -381- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -382- DISPLAY W-MENSAGEM2 */
                _.Display(FILLER_0.FILLER_80.W_MENSAGEM2);

                /*" -384- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -385- CALL 'PROALN01' USING LK-LINK. */
            _.Call("PROALN01", LK_LINK);

            /*" -385- MOVE LK-TITULO TO LC01-NOME-EMPRESA. */
            _.Move(LK_LINK.LK_TITULO, FILLER_0.LC01.LC01_NOME_EMPRESA);

        }

        [StopWatch]
        /*" M-000-100-SELECT-V1EMPRESA-DB-SELECT-1 */
        public void M_000_100_SELECT_V1EMPRESA_DB_SELECT_1()
        {
            /*" -374- EXEC SQL SELECT NOME_EMPRESA INTO :V1EMPRESA-NOME-EMPRESA FROM SEGUROS.V1EMPRESA WHERE COD_EMPRESA = 0 END-EXEC. */

            var m_000_100_SELECT_V1EMPRESA_DB_SELECT_1_Query1 = new M_000_100_SELECT_V1EMPRESA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_000_100_SELECT_V1EMPRESA_DB_SELECT_1_Query1.Execute(m_000_100_SELECT_V1EMPRESA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1EMPRESA_NOME_EMPRESA, V1EMPRESA_NOME_EMPRESA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_100_EXIT*/

        [StopWatch]
        /*" M-000-200-SELECT-V1SISTEMA-SECTION */
        private void M_000_200_SELECT_V1SISTEMA_SECTION()
        {
            /*" -394- MOVE '000-200-SELECT-V1SISTEMA' TO PARAGRAFO. */
            _.Move("000-200-SELECT-V1SISTEMA", FILLER_0.WABEND.PARAGRAFO);

            /*" -398- MOVE '002' TO WNR-EXEC-SQL. */
            _.Move("002", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -408- PERFORM M_000_200_SELECT_V1SISTEMA_DB_SELECT_1 */

            M_000_200_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -413- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -414- DISPLAY W-MENSAGEM3 */
                _.Display(FILLER_0.FILLER_80.W_MENSAGEM3);

                /*" -414- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-000-200-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void M_000_200_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -408- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :V1SISTEMA-DTMOVABE, :V1SISTEMA-DTCURRENT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'SI' END-EXEC. */

            var m_000_200_SELECT_V1SISTEMA_DB_SELECT_1_Query1 = new M_000_200_SELECT_V1SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_000_200_SELECT_V1SISTEMA_DB_SELECT_1_Query1.Execute(m_000_200_SELECT_V1SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SISTEMA_DTMOVABE, V1SISTEMA_DTMOVABE);
                _.Move(executed_1.V1SISTEMA_DTCURRENT, V1SISTEMA_DTCURRENT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_200_EXIT*/

        [StopWatch]
        /*" M-000-300-DECLARE-RELATORIOS-SECTION */
        private void M_000_300_DECLARE_RELATORIOS_SECTION()
        {
            /*" -423- MOVE '000-300-DECLARE-RELATORIOS' TO PARAGRAFO. */
            _.Move("000-300-DECLARE-RELATORIOS", FILLER_0.WABEND.PARAGRAFO);

            /*" -427- MOVE '003' TO WNR-EXEC-SQL. */
            _.Move("003", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -441- PERFORM M_000_300_DECLARE_RELATORIOS_DB_DECLARE_1 */

            M_000_300_DECLARE_RELATORIOS_DB_DECLARE_1();

            /*" -445- PERFORM M_000_300_DECLARE_RELATORIOS_DB_OPEN_1 */

            M_000_300_DECLARE_RELATORIOS_DB_OPEN_1();

        }

        [StopWatch]
        /*" M-000-300-DECLARE-RELATORIOS-DB-DECLARE-1 */
        public void M_000_300_DECLARE_RELATORIOS_DB_DECLARE_1()
        {
            /*" -441- EXEC SQL DECLARE RELATORIOS CURSOR FOR SELECT PERI_INICIAL, PERI_FINAL, NUM_APOLICE FROM SEGUROS.V1RELATORIOS WHERE IDSISTEM = 'SI' AND CODRELAT = 'SI0105B' AND DATA_SOLICITACAO = :V1SISTEMA-DTMOVABE END-EXEC. */
            RELATORIOS = new SI0105B_RELATORIOS(true);
            string GetQuery_RELATORIOS()
            {
                var query = @$"SELECT PERI_INICIAL
							, 
							PERI_FINAL
							, 
							NUM_APOLICE 
							FROM SEGUROS.V1RELATORIOS 
							WHERE IDSISTEM = 'SI' AND 
							CODRELAT = 'SI0105B' AND 
							DATA_SOLICITACAO = '{V1SISTEMA_DTMOVABE}'";

                return query;
            }
            RELATORIOS.GetQueryEvent += GetQuery_RELATORIOS;

        }

        [StopWatch]
        /*" M-000-300-DECLARE-RELATORIOS-DB-OPEN-1 */
        public void M_000_300_DECLARE_RELATORIOS_DB_OPEN_1()
        {
            /*" -445- EXEC SQL OPEN RELATORIOS END-EXEC. */

            RELATORIOS.Open();

        }

        [StopWatch]
        /*" M-100-100-DECLARE-HISTMEST-DB-DECLARE-1 */
        public void M_100_100_DECLARE_HISTMEST_DB_DECLARE_1()
        {
            /*" -612- EXEC SQL DECLARE HISTMEST CURSOR FOR SELECT H.NUM_APOL_SINISTRO, H.VAL_OPERACAO, A.MODALIDA, O.SIGLUNIM, O.VLCRUZAD, M.DATCMD, M.DATORR, M.FONTE, M.RAMO, A.NOME FROM SEGUROS.V1HISTSINI H, SEGUROS.V1MESTSINI M, SEGUROS.V1APOLICE A, SEGUROS.V1MOEDA O WHERE H.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO AND H.DTMOVTO >= :V1RELATORIOS-DATA1 AND H.DTMOVTO <= :V1RELATORIOS-DATA2 AND H.OPERACAO = 101 AND M.TOTPAGBT = 0 AND M.NUM_APOLICE = A.NUM_APOLICE AND M.COD_MOEDA_SINI = O.CODUNIMO AND O.DTINIVIG <= M.DATCMD AND O.DTTERVIG >= M.DATCMD AND A.NUM_APOLICE >= :V1RELATORIOS-APOLICE1 AND A.NUM_APOLICE <= :V1RELATORIOS-APOLICE2 AND NOT EXISTS ( SELECT NUM_APOL_SINISTRO FROM SEGUROS.V1HISTSINI X WHERE X.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND ((X.OPERACAO >= 1081 AND X.OPERACAO <= 1084) OR X.OPERACAO = 9081) AND X.SITUACAO = '0' ) ORDER BY RAMO, FONTE, NUM_APOL_SINISTRO END-EXEC. */
            HISTMEST = new SI0105B_HISTMEST(true);
            string GetQuery_HISTMEST()
            {
                var query = @$"SELECT H.NUM_APOL_SINISTRO
							, 
							H.VAL_OPERACAO
							, 
							A.MODALIDA
							, 
							O.SIGLUNIM
							, 
							O.VLCRUZAD
							, 
							M.DATCMD
							, 
							M.DATORR
							, 
							M.FONTE
							, 
							M.RAMO
							, 
							A.NOME 
							FROM SEGUROS.V1HISTSINI H
							, 
							SEGUROS.V1MESTSINI M
							, 
							SEGUROS.V1APOLICE A
							, 
							SEGUROS.V1MOEDA O 
							WHERE H.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO AND 
							H.DTMOVTO >= '{V1RELATORIOS_DATA1}' AND 
							H.DTMOVTO <= '{V1RELATORIOS_DATA2}' AND 
							H.OPERACAO = 101 AND 
							M.TOTPAGBT = 0 AND 
							M.NUM_APOLICE = A.NUM_APOLICE AND 
							M.COD_MOEDA_SINI = O.CODUNIMO AND 
							O.DTINIVIG <= M.DATCMD AND 
							O.DTTERVIG >= M.DATCMD AND 
							A.NUM_APOLICE >= '{V1RELATORIOS_APOLICE1}' AND 
							A.NUM_APOLICE <= '{V1RELATORIOS_APOLICE2}' AND 
							NOT EXISTS ( 
							SELECT NUM_APOL_SINISTRO 
							FROM SEGUROS.V1HISTSINI X 
							WHERE X.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND 
							((X.OPERACAO >= 1081 AND 
							X.OPERACAO <= 1084) OR 
							X.OPERACAO = 9081) AND 
							X.SITUACAO = '0' ) 
							ORDER BY RAMO
							, FONTE
							, NUM_APOL_SINISTRO";

                return query;
            }
            HISTMEST.GetQueryEvent += GetQuery_HISTMEST;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_300_EXIT*/

        [StopWatch]
        /*" M-000-400-FETCH-RELATORIOS-SECTION */
        private void M_000_400_FETCH_RELATORIOS_SECTION()
        {
            /*" -455- MOVE '000-400-FETCH-RELATORIOS' TO PARAGRAFO. */
            _.Move("000-400-FETCH-RELATORIOS", FILLER_0.WABEND.PARAGRAFO);

            /*" -463- PERFORM M_000_400_FETCH_RELATORIOS_DB_FETCH_1 */

            M_000_400_FETCH_RELATORIOS_DB_FETCH_1();

            /*" -466- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -466- PERFORM M_000_400_FETCH_RELATORIOS_DB_CLOSE_1 */

                M_000_400_FETCH_RELATORIOS_DB_CLOSE_1();

                /*" -468- MOVE 'S' TO W-FIM-RELATORIOS */
                _.Move("S", FILLER_0.W_FIM_RELATORIOS);

                /*" -469- ELSE */
            }
            else
            {


                /*" -471- MOVE 'N' TO W-FIM-HISTMEST */
                _.Move("N", FILLER_0.W_FIM_HISTMEST);

                /*" -472- MOVE V1RELATORIOS-DATA1 TO WDATA */
                _.Move(V1RELATORIOS_DATA1, FILLER_0.WDATA);

                /*" -473- MOVE WDATA-DD TO WDATA-DD-CABEC */
                _.Move(FILLER_0.WDATA.WDATA_DD, FILLER_0.WDATA_CABEC.WDATA_DD_CABEC);

                /*" -474- MOVE WDATA-MM TO WDATA-MM-CABEC */
                _.Move(FILLER_0.WDATA.WDATA_MM, FILLER_0.WDATA_CABEC.WDATA_MM_CABEC);

                /*" -475- MOVE WDATA-AA TO WDATA-AA-CABEC */
                _.Move(FILLER_0.WDATA.WDATA_AA, FILLER_0.WDATA_CABEC.WDATA_AA_CABEC);

                /*" -476- MOVE WDATA-CABEC TO LC04-DATA1 */
                _.Move(FILLER_0.WDATA_CABEC, FILLER_0.LC04.LC04_DATA1);

                /*" -477- MOVE V1RELATORIOS-DATA2 TO WDATA */
                _.Move(V1RELATORIOS_DATA2, FILLER_0.WDATA);

                /*" -478- MOVE WDATA-DD TO WDATA-DD-CABEC */
                _.Move(FILLER_0.WDATA.WDATA_DD, FILLER_0.WDATA_CABEC.WDATA_DD_CABEC);

                /*" -479- MOVE WDATA-MM TO WDATA-MM-CABEC */
                _.Move(FILLER_0.WDATA.WDATA_MM, FILLER_0.WDATA_CABEC.WDATA_MM_CABEC);

                /*" -480- MOVE WDATA-AA TO WDATA-AA-CABEC */
                _.Move(FILLER_0.WDATA.WDATA_AA, FILLER_0.WDATA_CABEC.WDATA_AA_CABEC);

                /*" -482- MOVE WDATA-CABEC TO LC04-DATA2 */
                _.Move(FILLER_0.WDATA_CABEC, FILLER_0.LC04.LC04_DATA2);

                /*" -483- IF V1RELATORIOS-APOLICE1 EQUAL ZEROES */

                if (V1RELATORIOS_APOLICE1 == 00)
                {

                    /*" -484- MOVE 9999999999999 TO V1RELATORIOS-APOLICE2 */
                    _.Move(9999999999999, V1RELATORIOS_APOLICE2);

                    /*" -485- ELSE */
                }
                else
                {


                    /*" -485- MOVE V1RELATORIOS-APOLICE1 TO V1RELATORIOS-APOLICE2. */
                    _.Move(V1RELATORIOS_APOLICE1, V1RELATORIOS_APOLICE2);
                }

            }


        }

        [StopWatch]
        /*" M-000-400-FETCH-RELATORIOS-DB-FETCH-1 */
        public void M_000_400_FETCH_RELATORIOS_DB_FETCH_1()
        {
            /*" -463- EXEC SQL FETCH RELATORIOS INTO :V1RELATORIOS-DATA1, :V1RELATORIOS-DATA2, :V1RELATORIOS-APOLICE1 END-EXEC. */

            if (RELATORIOS.Fetch())
            {
                _.Move(RELATORIOS.V1RELATORIOS_DATA1, V1RELATORIOS_DATA1);
                _.Move(RELATORIOS.V1RELATORIOS_DATA2, V1RELATORIOS_DATA2);
                _.Move(RELATORIOS.V1RELATORIOS_APOLICE1, V1RELATORIOS_APOLICE1);
            }

        }

        [StopWatch]
        /*" M-000-400-FETCH-RELATORIOS-DB-CLOSE-1 */
        public void M_000_400_FETCH_RELATORIOS_DB_CLOSE_1()
        {
            /*" -466- EXEC SQL CLOSE RELATORIOS END-EXEC */

            RELATORIOS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_400_EXIT*/

        [StopWatch]
        /*" M-000-500-PROCESSA-RELATORIOS-SECTION */
        private void M_000_500_PROCESSA_RELATORIOS_SECTION()
        {
            /*" -495- MOVE '000-500-PROCESSA-RELATORIOS' TO PARAGRAFO. */
            _.Move("000-500-PROCESSA-RELATORIOS", FILLER_0.WABEND.PARAGRAFO);

            /*" -496- PERFORM 100-100-DECLARE-HISTMEST. */

            M_100_100_DECLARE_HISTMEST_SECTION();

            /*" -498- PERFORM 100-200-FETCH-HISTMEST. */

            M_100_200_FETCH_HISTMEST_SECTION();

            /*" -499- IF W-FIM-HISTMEST EQUAL 'S' */

            if (FILLER_0.W_FIM_HISTMEST == "S")
            {

                /*" -500- PERFORM 000-400-FETCH-RELATORIOS */

                M_000_400_FETCH_RELATORIOS_SECTION();

                /*" -502- GO TO 000-500-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_500_EXIT*/ //GOTO
                return;
            }


            /*" -505- PERFORM 100-300-PROCESSA-HISTMEST UNTIL W-FIM-HISTMEST EQUAL 'S' . */

            while (!(FILLER_0.W_FIM_HISTMEST == "S"))
            {

                M_100_300_PROCESSA_HISTMEST_SECTION();
            }

            /*" -506- PERFORM 100-400-QUEBRA-GERAL. */

            M_100_400_QUEBRA_GERAL_SECTION();

            /*" -506- PERFORM 000-400-FETCH-RELATORIOS. */

            M_000_400_FETCH_RELATORIOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_500_EXIT*/

        [StopWatch]
        /*" M-000-600-UPDATE-V1RELATORIOS-SECTION */
        private void M_000_600_UPDATE_V1RELATORIOS_SECTION()
        {
            /*" -515- MOVE '000-600-UPDATE-V1RELATORIOS' TO PARAGRAFO. */
            _.Move("000-600-UPDATE-V1RELATORIOS", FILLER_0.WABEND.PARAGRAFO);

            /*" -519- MOVE '004' TO WNR-EXEC-SQL. */
            _.Move("004", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -527- PERFORM M_000_600_UPDATE_V1RELATORIOS_DB_DELETE_1 */

            M_000_600_UPDATE_V1RELATORIOS_DB_DELETE_1();

            /*" -532- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -532- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-000-600-UPDATE-V1RELATORIOS-DB-DELETE-1 */
        public void M_000_600_UPDATE_V1RELATORIOS_DB_DELETE_1()
        {
            /*" -527- EXEC SQL DELETE FROM SEGUROS.V0RELATORIOS WHERE IDSISTEM = 'SI' AND CODRELAT = 'SI0105B' AND DATA_SOLICITACAO = :V1SISTEMA-DTMOVABE END-EXEC. */

            var m_000_600_UPDATE_V1RELATORIOS_DB_DELETE_1_Delete1 = new M_000_600_UPDATE_V1RELATORIOS_DB_DELETE_1_Delete1()
            {
                V1SISTEMA_DTMOVABE = V1SISTEMA_DTMOVABE.ToString(),
            };

            M_000_600_UPDATE_V1RELATORIOS_DB_DELETE_1_Delete1.Execute(m_000_600_UPDATE_V1RELATORIOS_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_600_EXIT*/

        [StopWatch]
        /*" M-000-700-FINALIZA-SECTION */
        private void M_000_700_FINALIZA_SECTION()
        {
            /*" -542- MOVE '000-700-FINALIZA' TO PARAGRAFO. */
            _.Move("000-700-FINALIZA", FILLER_0.WABEND.PARAGRAFO);

            /*" -543- IF W-LIDOS NOT EQUAL ZEROES */

            if (FILLER_0.W_LIDOS != 00)
            {

                /*" -544- DISPLAY 'TOTAL LIDOS EMISSAO       = ' W-LIDOS */
                _.Display($"TOTAL LIDOS EMISSAO       = {FILLER_0.W_LIDOS}");

                /*" -546- DISPLAY 'TOTAL IMPRESSOS EMISSAO   = ' W-IMPRESSOS. */
                _.Display($"TOTAL IMPRESSOS EMISSAO   = {FILLER_0.W_IMPRESSOS}");
            }


            /*" -548- MOVE ZEROES TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -550- DISPLAY 'SI0105B *** FIM NORMAL ***' . */
            _.Display($"SI0105B *** FIM NORMAL ***");

            /*" -552- CLOSE SI0105M1. */
            SI0105M1.Close();

            /*" -552- GOBACK. */

            throw new GoBack();

        }

        [StopWatch]
        /*" M-100-100-DECLARE-HISTMEST-SECTION */
        private void M_100_100_DECLARE_HISTMEST_SECTION()
        {
            /*" -559- MOVE '100-100-DECLARE-HISTMEST' TO PARAGRAFO. */
            _.Move("100-100-DECLARE-HISTMEST", FILLER_0.WABEND.PARAGRAFO);

            /*" -563- MOVE '005' TO WNR-EXEC-SQL. */
            _.Move("005", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -612- PERFORM M_100_100_DECLARE_HISTMEST_DB_DECLARE_1 */

            M_100_100_DECLARE_HISTMEST_DB_DECLARE_1();

            /*" -616- PERFORM M_100_100_DECLARE_HISTMEST_DB_OPEN_1 */

            M_100_100_DECLARE_HISTMEST_DB_OPEN_1();

        }

        [StopWatch]
        /*" M-100-100-DECLARE-HISTMEST-DB-OPEN-1 */
        public void M_100_100_DECLARE_HISTMEST_DB_OPEN_1()
        {
            /*" -616- EXEC SQL OPEN HISTMEST END-EXEC. */

            HISTMEST.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_100_EXIT*/

        [StopWatch]
        /*" M-100-200-FETCH-HISTMEST-SECTION */
        private void M_100_200_FETCH_HISTMEST_SECTION()
        {
            /*" -626- MOVE '100-200-FETCH-HISTMEST' TO PARAGRAFO. */
            _.Move("100-200-FETCH-HISTMEST", FILLER_0.WABEND.PARAGRAFO);

            /*" -641- PERFORM M_100_200_FETCH_HISTMEST_DB_FETCH_1 */

            M_100_200_FETCH_HISTMEST_DB_FETCH_1();

            /*" -644- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -644- PERFORM M_100_200_FETCH_HISTMEST_DB_CLOSE_1 */

                M_100_200_FETCH_HISTMEST_DB_CLOSE_1();

                /*" -646- MOVE 'S' TO W-FIM-HISTMEST */
                _.Move("S", FILLER_0.W_FIM_HISTMEST);

                /*" -647- ELSE */
            }
            else
            {


                /*" -648- ADD 1 TO W-LIDOS */
                FILLER_0.W_LIDOS.Value = FILLER_0.W_LIDOS + 1;

                /*" -649- MOVE V1HISTMEST-NUM-SINISTRO TO LD01-SINISTRO */
                _.Move(V1HISTMEST_NUM_SINISTRO, FILLER_0.LD01.LD01_SINISTRO);

                /*" -650- MOVE V1HISTMEST-DATCMD TO WDATA */
                _.Move(V1HISTMEST_DATCMD, FILLER_0.WDATA);

                /*" -651- MOVE WDATA-DD TO WDATA-DD-CABEC */
                _.Move(FILLER_0.WDATA.WDATA_DD, FILLER_0.WDATA_CABEC.WDATA_DD_CABEC);

                /*" -652- MOVE WDATA-MM TO WDATA-MM-CABEC */
                _.Move(FILLER_0.WDATA.WDATA_MM, FILLER_0.WDATA_CABEC.WDATA_MM_CABEC);

                /*" -653- MOVE WDATA-AA TO WDATA-AA-CABEC */
                _.Move(FILLER_0.WDATA.WDATA_AA, FILLER_0.WDATA_CABEC.WDATA_AA_CABEC);

                /*" -654- MOVE WDATA-CABEC TO LD01-DATCMD */
                _.Move(FILLER_0.WDATA_CABEC, FILLER_0.LD01.LD01_DATCMD);

                /*" -655- MOVE V1HISTMEST-DATORR TO WDATA */
                _.Move(V1HISTMEST_DATORR, FILLER_0.WDATA);

                /*" -656- MOVE WDATA-DD TO WDATA-DD-CABEC */
                _.Move(FILLER_0.WDATA.WDATA_DD, FILLER_0.WDATA_CABEC.WDATA_DD_CABEC);

                /*" -657- MOVE WDATA-MM TO WDATA-MM-CABEC */
                _.Move(FILLER_0.WDATA.WDATA_MM, FILLER_0.WDATA_CABEC.WDATA_MM_CABEC);

                /*" -658- MOVE WDATA-AA TO WDATA-AA-CABEC */
                _.Move(FILLER_0.WDATA.WDATA_AA, FILLER_0.WDATA_CABEC.WDATA_AA_CABEC);

                /*" -659- MOVE WDATA-CABEC TO LD01-DATORR */
                _.Move(FILLER_0.WDATA_CABEC, FILLER_0.LD01.LD01_DATORR);

                /*" -660- MOVE V1HISTMEST-VAL-OPERACAO TO LD01-VAL-OPERACAO */
                _.Move(V1HISTMEST_VAL_OPERACAO, FILLER_0.LD01.LD01_VAL_OPERACAO);

                /*" -662- MOVE V1HISTMEST-SIGLUNIM TO LD01-SIGLUNIM */
                _.Move(V1HISTMEST_SIGLUNIM, FILLER_0.LD01.LD01_SIGLUNIM);

                /*" -665- COMPUTE W-VAL-OPERACAO1 = V1HISTMEST-VAL-OPERACAO / V1HISTMEST-VLCRUZAD */
                FILLER_0.W_VAL_OPERACAO1.Value = V1HISTMEST_VAL_OPERACAO / V1HISTMEST_VLCRUZAD;

                /*" -665- MOVE W-VAL-OPERACAO1 TO LD01-VAL-OPERACAO1. */
                _.Move(FILLER_0.W_VAL_OPERACAO1, FILLER_0.LD01.LD01_VAL_OPERACAO1);
            }


        }

        [StopWatch]
        /*" M-100-200-FETCH-HISTMEST-DB-FETCH-1 */
        public void M_100_200_FETCH_HISTMEST_DB_FETCH_1()
        {
            /*" -641- EXEC SQL FETCH HISTMEST INTO :V1HISTMEST-NUM-SINISTRO, :V1HISTMEST-VAL-OPERACAO, :V1HISTMEST-MODALIDA, :V1HISTMEST-SIGLUNIM, :V1HISTMEST-VLCRUZAD, :V1HISTMEST-DATCMD, :V1HISTMEST-DATORR, :V1HISTMEST-FONTE, :V1HISTMEST-RAMO, :V1HISTMEST-NOME END-EXEC. */

            if (HISTMEST.Fetch())
            {
                _.Move(HISTMEST.V1HISTMEST_NUM_SINISTRO, V1HISTMEST_NUM_SINISTRO);
                _.Move(HISTMEST.V1HISTMEST_VAL_OPERACAO, V1HISTMEST_VAL_OPERACAO);
                _.Move(HISTMEST.V1HISTMEST_MODALIDA, V1HISTMEST_MODALIDA);
                _.Move(HISTMEST.V1HISTMEST_SIGLUNIM, V1HISTMEST_SIGLUNIM);
                _.Move(HISTMEST.V1HISTMEST_VLCRUZAD, V1HISTMEST_VLCRUZAD);
                _.Move(HISTMEST.V1HISTMEST_DATCMD, V1HISTMEST_DATCMD);
                _.Move(HISTMEST.V1HISTMEST_DATORR, V1HISTMEST_DATORR);
                _.Move(HISTMEST.V1HISTMEST_FONTE, V1HISTMEST_FONTE);
                _.Move(HISTMEST.V1HISTMEST_RAMO, V1HISTMEST_RAMO);
                _.Move(HISTMEST.V1HISTMEST_NOME, V1HISTMEST_NOME);
            }

        }

        [StopWatch]
        /*" M-100-200-FETCH-HISTMEST-DB-CLOSE-1 */
        public void M_100_200_FETCH_HISTMEST_DB_CLOSE_1()
        {
            /*" -644- EXEC SQL CLOSE HISTMEST END-EXEC */

            HISTMEST.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_200_EXIT*/

        [StopWatch]
        /*" M-100-300-PROCESSA-HISTMEST-SECTION */
        private void M_100_300_PROCESSA_HISTMEST_SECTION()
        {
            /*" -675- MOVE '100-300-PROCESSA-HISTMEST' TO PARAGRAFO. */
            _.Move("100-300-PROCESSA-HISTMEST", FILLER_0.WABEND.PARAGRAFO);

            /*" -676- MOVE V1HISTMEST-RAMO TO LC05-RAMO. */
            _.Move(V1HISTMEST_RAMO, FILLER_0.LC05.LC05_RAMO);

            /*" -678- MOVE V1HISTMEST-MODALIDA TO W-MODALIDA-ANT. */
            _.Move(V1HISTMEST_MODALIDA, FILLER_0.W_MODALIDA_ANT);

            /*" -680- PERFORM 200-100-SELECT-V1RAMO. */

            M_200_100_SELECT_V1RAMO_SECTION();

            /*" -685- PERFORM 200-200-PROCESSA-RAMO UNTIL W-FIM-HISTMEST EQUAL 'S' OR V1HISTMEST-RAMO NOT EQUAL LC05-RAMO OR V1HISTMEST-MODALIDA NOT EQUAL W-MODALIDA-ANT. */

            while (!(FILLER_0.W_FIM_HISTMEST == "S" || V1HISTMEST_RAMO != FILLER_0.LC05.LC05_RAMO || V1HISTMEST_MODALIDA != FILLER_0.W_MODALIDA_ANT))
            {

                M_200_200_PROCESSA_RAMO_SECTION();
            }

            /*" -685- PERFORM 200-300-QUEBRA-RAMO. */

            M_200_300_QUEBRA_RAMO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_300_EXIT*/

        [StopWatch]
        /*" M-100-400-QUEBRA-GERAL-SECTION */
        private void M_100_400_QUEBRA_GERAL_SECTION()
        {
            /*" -695- MOVE '100-400-QUEBRA-GERAL' TO PARAGRAFO. */
            _.Move("100-400-QUEBRA-GERAL", FILLER_0.WABEND.PARAGRAFO);

            /*" -696- MOVE 'TOTAL GERAL' TO LC06-NOMEFTE LC05-NOMERAMO. */
            _.Move("TOTAL GERAL", FILLER_0.LC06.LC06_NOMEFTE, FILLER_0.LC05.LC05_NOMERAMO);

            /*" -698- MOVE 999 TO LC06-FONTE LC05-RAMO. */
            _.Move(999, FILLER_0.LC06.LC06_FONTE, FILLER_0.LC05.LC05_RAMO);

            /*" -700- PERFORM 500-100-IMPRIME-CABECALHO. */

            M_500_100_IMPRIME_CABECALHO_SECTION();

            /*" -701- MOVE W-ACC-GERAL TO LT03-ACC-GERAL. */
            _.Move(FILLER_0.W_ACC_GERAL, FILLER_0.LT03.LT03_ACC_GERAL);

            /*" -703- MOVE W-ACC-GERAL1 TO LT03-ACC-GERAL1. */
            _.Move(FILLER_0.W_ACC_GERAL1, FILLER_0.LT03.LT03_ACC_GERAL1);

            /*" -705- WRITE REG-SI0105M1 FROM LT03 AFTER 6. */
            _.Move(FILLER_0.LT03.GetMoveValues(), REG_SI0105M1);

            SI0105M1.Write(REG_SI0105M1.GetMoveValues().ToString());

            /*" -706- MOVE 00 TO W-CONT-PAG. */
            _.Move(00, FILLER_0.W_CONT_PAG);

            /*" -707- MOVE 70 TO W-CONT-LIN. */
            _.Move(70, FILLER_0.W_CONT_LIN);

            /*" -708- MOVE 00 TO W-ACC-GERAL. */
            _.Move(00, FILLER_0.W_ACC_GERAL);

            /*" -708- MOVE 00 TO W-ACC-GERAL1. */
            _.Move(00, FILLER_0.W_ACC_GERAL1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_400_EXIT*/

        [StopWatch]
        /*" M-200-100-SELECT-V1RAMO-SECTION */
        private void M_200_100_SELECT_V1RAMO_SECTION()
        {
            /*" -717- MOVE '200-100-SELECT-V1RAMO' TO PARAGRAFO. */
            _.Move("200-100-SELECT-V1RAMO", FILLER_0.WABEND.PARAGRAFO);

            /*" -721- MOVE '006' TO WNR-EXEC-SQL. */
            _.Move("006", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -733- PERFORM M_200_100_SELECT_V1RAMO_DB_SELECT_1 */

            M_200_100_SELECT_V1RAMO_DB_SELECT_1();

            /*" -738- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -739- DISPLAY W-MENSAGEM4 */
                _.Display(FILLER_0.FILLER_80.W_MENSAGEM4);

                /*" -740- DISPLAY 'RAMO  = ' V1HISTMEST-RAMO */
                _.Display($"RAMO  = {V1HISTMEST_RAMO}");

                /*" -742- DISPLAY 'MODA  = ' V1HISTMEST-MODALIDA */
                _.Display($"MODA  = {V1HISTMEST_MODALIDA}");

                /*" -743- MOVE SPACES TO LC05-NOMERAMO */
                _.Move("", FILLER_0.LC05.LC05_NOMERAMO);

                /*" -744- ELSE */
            }
            else
            {


                /*" -744- MOVE V1RAMO-NOMERAMO TO LC05-NOMERAMO. */
                _.Move(V1RAMO_NOMERAMO, FILLER_0.LC05.LC05_NOMERAMO);
            }


        }

        [StopWatch]
        /*" M-200-100-SELECT-V1RAMO-DB-SELECT-1 */
        public void M_200_100_SELECT_V1RAMO_DB_SELECT_1()
        {
            /*" -733- EXEC SQL SELECT NOMERAMO INTO :V1RAMO-NOMERAMO FROM SEGUROS.V1RAMO WHERE RAMO = :V1HISTMEST-RAMO AND MODALIDA = :V1HISTMEST-MODALIDA END-EXEC. */

            var m_200_100_SELECT_V1RAMO_DB_SELECT_1_Query1 = new M_200_100_SELECT_V1RAMO_DB_SELECT_1_Query1()
            {
                V1HISTMEST_MODALIDA = V1HISTMEST_MODALIDA.ToString(),
                V1HISTMEST_RAMO = V1HISTMEST_RAMO.ToString(),
            };

            var executed_1 = M_200_100_SELECT_V1RAMO_DB_SELECT_1_Query1.Execute(m_200_100_SELECT_V1RAMO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1RAMO_NOMERAMO, V1RAMO_NOMERAMO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_200_100_EXIT*/

        [StopWatch]
        /*" M-200-200-PROCESSA-RAMO-SECTION */
        private void M_200_200_PROCESSA_RAMO_SECTION()
        {
            /*" -754- MOVE '200-200-PROCESSA-RAMO' TO PARAGRAFO. */
            _.Move("200-200-PROCESSA-RAMO", FILLER_0.WABEND.PARAGRAFO);

            /*" -756- MOVE V1HISTMEST-FONTE TO LC06-FONTE. */
            _.Move(V1HISTMEST_FONTE, FILLER_0.LC06.LC06_FONTE);

            /*" -758- PERFORM 300-100-SELECT-V1FONTE. */

            M_300_100_SELECT_V1FONTE_SECTION();

            /*" -764- PERFORM 300-200-PROCESSA-FONTE UNTIL W-FIM-HISTMEST EQUAL 'S' OR V1HISTMEST-RAMO NOT EQUAL LC05-RAMO OR V1HISTMEST-FONTE NOT EQUAL LC06-FONTE OR V1HISTMEST-MODALIDA NOT EQUAL W-MODALIDA-ANT. */

            while (!(FILLER_0.W_FIM_HISTMEST == "S" || V1HISTMEST_RAMO != FILLER_0.LC05.LC05_RAMO || V1HISTMEST_FONTE != FILLER_0.LC06.LC06_FONTE || V1HISTMEST_MODALIDA != FILLER_0.W_MODALIDA_ANT))
            {

                M_300_200_PROCESSA_FONTE_SECTION();
            }

            /*" -764- PERFORM 300-300-QUEBRA-FONTE. */

            M_300_300_QUEBRA_FONTE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_200_200_EXIT*/

        [StopWatch]
        /*" M-200-300-QUEBRA-RAMO-SECTION */
        private void M_200_300_QUEBRA_RAMO_SECTION()
        {
            /*" -774- MOVE '200-300-QUEBRA-RAMO' TO PARAGRAFO. */
            _.Move("200-300-QUEBRA-RAMO", FILLER_0.WABEND.PARAGRAFO);

            /*" -775- ADD W-ACC-RAMO TO W-ACC-GERAL. */
            FILLER_0.W_ACC_GERAL.Value = FILLER_0.W_ACC_GERAL + FILLER_0.W_ACC_RAMO;

            /*" -776- ADD W-ACC-RAMO1 TO W-ACC-GERAL1. */
            FILLER_0.W_ACC_GERAL1.Value = FILLER_0.W_ACC_GERAL1 + FILLER_0.W_ACC_RAMO1;

            /*" -777- MOVE W-ACC-RAMO TO LT02-ACC-RAMO. */
            _.Move(FILLER_0.W_ACC_RAMO, FILLER_0.LT02.LT02_ACC_RAMO);

            /*" -778- MOVE W-ACC-RAMO1 TO LT02-ACC-RAMO1. */
            _.Move(FILLER_0.W_ACC_RAMO1, FILLER_0.LT02.LT02_ACC_RAMO1);

            /*" -779- MOVE 00 TO W-ACC-RAMO. */
            _.Move(00, FILLER_0.W_ACC_RAMO);

            /*" -780- MOVE 00 TO W-ACC-RAMO1. */
            _.Move(00, FILLER_0.W_ACC_RAMO1);

            /*" -782- MOVE 70 TO W-CONT-LIN. */
            _.Move(70, FILLER_0.W_CONT_LIN);

            /*" -782- WRITE REG-SI0105M1 FROM LT02 AFTER 3. */
            _.Move(FILLER_0.LT02.GetMoveValues(), REG_SI0105M1);

            SI0105M1.Write(REG_SI0105M1.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_200_300_EXIT*/

        [StopWatch]
        /*" M-300-100-SELECT-V1FONTE-SECTION */
        private void M_300_100_SELECT_V1FONTE_SECTION()
        {
            /*" -791- MOVE '300-100-SELECT-V1FONTE' TO PARAGRAFO. */
            _.Move("300-100-SELECT-V1FONTE", FILLER_0.WABEND.PARAGRAFO);

            /*" -795- MOVE '007' TO WNR-EXEC-SQL. */
            _.Move("007", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -805- PERFORM M_300_100_SELECT_V1FONTE_DB_SELECT_1 */

            M_300_100_SELECT_V1FONTE_DB_SELECT_1();

            /*" -810- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -811- DISPLAY W-MENSAGEM5 */
                _.Display(FILLER_0.FILLER_80.W_MENSAGEM5);

                /*" -813- DISPLAY 'FONTE = ' V1HISTMEST-FONTE */
                _.Display($"FONTE = {V1HISTMEST_FONTE}");

                /*" -814- MOVE SPACES TO LC06-NOMEFTE */
                _.Move("", FILLER_0.LC06.LC06_NOMEFTE);

                /*" -815- ELSE */
            }
            else
            {


                /*" -815- MOVE V1FONTE-NOMEFTE TO LC06-NOMEFTE. */
                _.Move(V1FONTE_NOMEFTE, FILLER_0.LC06.LC06_NOMEFTE);
            }


        }

        [StopWatch]
        /*" M-300-100-SELECT-V1FONTE-DB-SELECT-1 */
        public void M_300_100_SELECT_V1FONTE_DB_SELECT_1()
        {
            /*" -805- EXEC SQL SELECT NOMEFTE INTO :V1FONTE-NOMEFTE FROM SEGUROS.V1FONTE WHERE FONTE = :V1HISTMEST-FONTE END-EXEC. */

            var m_300_100_SELECT_V1FONTE_DB_SELECT_1_Query1 = new M_300_100_SELECT_V1FONTE_DB_SELECT_1_Query1()
            {
                V1HISTMEST_FONTE = V1HISTMEST_FONTE.ToString(),
            };

            var executed_1 = M_300_100_SELECT_V1FONTE_DB_SELECT_1_Query1.Execute(m_300_100_SELECT_V1FONTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1FONTE_NOMEFTE, V1FONTE_NOMEFTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_300_100_EXIT*/

        [StopWatch]
        /*" M-300-200-PROCESSA-FONTE-SECTION */
        private void M_300_200_PROCESSA_FONTE_SECTION()
        {
            /*" -825- MOVE '300-200-PROCESSA-FONTE' TO PARAGRAFO. */
            _.Move("300-200-PROCESSA-FONTE", FILLER_0.WABEND.PARAGRAFO);

            /*" -826- PERFORM 400-100-IMPRIME-DETALHE. */

            M_400_100_IMPRIME_DETALHE_SECTION();

            /*" -826- PERFORM 100-200-FETCH-HISTMEST. */

            M_100_200_FETCH_HISTMEST_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_300_200_EXIT*/

        [StopWatch]
        /*" M-300-300-QUEBRA-FONTE-SECTION */
        private void M_300_300_QUEBRA_FONTE_SECTION()
        {
            /*" -836- MOVE '300-300-QUEBRA-FONTE' TO PARAGRAFO. */
            _.Move("300-300-QUEBRA-FONTE", FILLER_0.WABEND.PARAGRAFO);

            /*" -837- ADD W-ACC-FONTE TO W-ACC-RAMO. */
            FILLER_0.W_ACC_RAMO.Value = FILLER_0.W_ACC_RAMO + FILLER_0.W_ACC_FONTE;

            /*" -838- ADD W-ACC-FONTE1 TO W-ACC-RAMO1. */
            FILLER_0.W_ACC_RAMO1.Value = FILLER_0.W_ACC_RAMO1 + FILLER_0.W_ACC_FONTE1;

            /*" -839- MOVE W-ACC-FONTE TO LT01-ACC-FONTE. */
            _.Move(FILLER_0.W_ACC_FONTE, FILLER_0.LT01.LT01_ACC_FONTE);

            /*" -840- MOVE W-ACC-FONTE1 TO LT01-ACC-FONTE1. */
            _.Move(FILLER_0.W_ACC_FONTE1, FILLER_0.LT01.LT01_ACC_FONTE1);

            /*" -841- MOVE 00 TO W-ACC-FONTE. */
            _.Move(00, FILLER_0.W_ACC_FONTE);

            /*" -843- MOVE 00 TO W-ACC-FONTE1. */
            _.Move(00, FILLER_0.W_ACC_FONTE1);

            /*" -845- WRITE REG-SI0105M1 FROM LT01 AFTER 3. */
            _.Move(FILLER_0.LT01.GetMoveValues(), REG_SI0105M1);

            SI0105M1.Write(REG_SI0105M1.GetMoveValues().ToString());

            /*" -846- IF V1HISTMEST-RAMO EQUAL LC05-RAMO */

            if (V1HISTMEST_RAMO == FILLER_0.LC05.LC05_RAMO)
            {

                /*" -846- MOVE 70 TO W-CONT-LIN. */
                _.Move(70, FILLER_0.W_CONT_LIN);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_300_300_EXIT*/

        [StopWatch]
        /*" M-400-100-IMPRIME-DETALHE-SECTION */
        private void M_400_100_IMPRIME_DETALHE_SECTION()
        {
            /*" -856- MOVE '400-100-IMPRIME-DETALHE' TO PARAGRAFO. */
            _.Move("400-100-IMPRIME-DETALHE", FILLER_0.WABEND.PARAGRAFO);

            /*" -857- IF W-CONT-LIN GREATER 59 */

            if (FILLER_0.W_CONT_LIN > 59)
            {

                /*" -859- PERFORM 500-100-IMPRIME-CABECALHO. */

                M_500_100_IMPRIME_CABECALHO_SECTION();
            }


            /*" -860- ADD V1HISTMEST-VAL-OPERACAO TO W-ACC-FONTE. */
            FILLER_0.W_ACC_FONTE.Value = FILLER_0.W_ACC_FONTE + V1HISTMEST_VAL_OPERACAO;

            /*" -862- ADD W-VAL-OPERACAO1 TO W-ACC-FONTE1. */
            FILLER_0.W_ACC_FONTE1.Value = FILLER_0.W_ACC_FONTE1 + FILLER_0.W_VAL_OPERACAO1;

            /*" -864- WRITE REG-SI0105M1 FROM LD01 AFTER 2. */
            _.Move(FILLER_0.LD01.GetMoveValues(), REG_SI0105M1);

            SI0105M1.Write(REG_SI0105M1.GetMoveValues().ToString());

            /*" -865- ADD 2 TO W-CONT-LIN. */
            FILLER_0.W_CONT_LIN.Value = FILLER_0.W_CONT_LIN + 2;

            /*" -865- ADD 1 TO W-IMPRESSOS. */
            FILLER_0.W_IMPRESSOS.Value = FILLER_0.W_IMPRESSOS + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_400_100_EXIT*/

        [StopWatch]
        /*" M-500-100-IMPRIME-CABECALHO-SECTION */
        private void M_500_100_IMPRIME_CABECALHO_SECTION()
        {
            /*" -875- MOVE '500-100-IMPRIME-CABECALHO' TO PARAGRAFO. */
            _.Move("500-100-IMPRIME-CABECALHO", FILLER_0.WABEND.PARAGRAFO);

            /*" -877- ADD 1 TO W-CONT-PAG. */
            FILLER_0.W_CONT_PAG.Value = FILLER_0.W_CONT_PAG + 1;

            /*" -879- MOVE W-CONT-PAG TO LC01-PAGINA. */
            _.Move(FILLER_0.W_CONT_PAG, FILLER_0.LC01.LC01_PAGINA);

            /*" -880- WRITE REG-SI0105M1 FROM LC01 AFTER NEW-PAGE. */
            _.Move(FILLER_0.LC01.GetMoveValues(), REG_SI0105M1);

            SI0105M1.Write(REG_SI0105M1.GetMoveValues().ToString());

            /*" -881- WRITE REG-SI0105M1 FROM LC02 AFTER 1. */
            _.Move(FILLER_0.LC02.GetMoveValues(), REG_SI0105M1);

            SI0105M1.Write(REG_SI0105M1.GetMoveValues().ToString());

            /*" -882- WRITE REG-SI0105M1 FROM LC03 AFTER 1. */
            _.Move(FILLER_0.LC03.GetMoveValues(), REG_SI0105M1);

            SI0105M1.Write(REG_SI0105M1.GetMoveValues().ToString());

            /*" -884- WRITE REG-SI0105M1 FROM LC04 AFTER 1. */
            _.Move(FILLER_0.LC04.GetMoveValues(), REG_SI0105M1);

            SI0105M1.Write(REG_SI0105M1.GetMoveValues().ToString());

            /*" -885- IF V1RELATORIOS-APOLICE1 EQUAL ZEROES */

            if (V1RELATORIOS_APOLICE1 == 00)
            {

                /*" -886- WRITE REG-SI0105M1 FROM LC05 AFTER 2 */
                _.Move(FILLER_0.LC05.GetMoveValues(), REG_SI0105M1);

                SI0105M1.Write(REG_SI0105M1.GetMoveValues().ToString());

                /*" -887- ELSE */
            }
            else
            {


                /*" -888- MOVE V1RELATORIOS-APOLICE1 TO LC09-APOLICE */
                _.Move(V1RELATORIOS_APOLICE1, FILLER_0.LC09.LC09_APOLICE);

                /*" -889- MOVE V1HISTMEST-NOME TO LC09-NOME-APOL */
                _.Move(V1HISTMEST_NOME, FILLER_0.LC09.LC09_NOME_APOL);

                /*" -890- WRITE REG-SI0105M1 FROM LC09 AFTER 1 */
                _.Move(FILLER_0.LC09.GetMoveValues(), REG_SI0105M1);

                SI0105M1.Write(REG_SI0105M1.GetMoveValues().ToString());

                /*" -892- WRITE REG-SI0105M1 FROM LC05 AFTER 1. */
                _.Move(FILLER_0.LC05.GetMoveValues(), REG_SI0105M1);

                SI0105M1.Write(REG_SI0105M1.GetMoveValues().ToString());
            }


            /*" -893- WRITE REG-SI0105M1 FROM LC06 AFTER 1. */
            _.Move(FILLER_0.LC06.GetMoveValues(), REG_SI0105M1);

            SI0105M1.Write(REG_SI0105M1.GetMoveValues().ToString());

            /*" -894- WRITE REG-SI0105M1 FROM LC07 AFTER 1. */
            _.Move(FILLER_0.LC07.GetMoveValues(), REG_SI0105M1);

            SI0105M1.Write(REG_SI0105M1.GetMoveValues().ToString());

            /*" -895- WRITE REG-SI0105M1 FROM LC08 AFTER 1. */
            _.Move(FILLER_0.LC08.GetMoveValues(), REG_SI0105M1);

            SI0105M1.Write(REG_SI0105M1.GetMoveValues().ToString());

            /*" -897- WRITE REG-SI0105M1 FROM LC07 AFTER 1. */
            _.Move(FILLER_0.LC07.GetMoveValues(), REG_SI0105M1);

            SI0105M1.Write(REG_SI0105M1.GetMoveValues().ToString());

            /*" -897- MOVE 10 TO W-CONT-LIN. */
            _.Move(10, FILLER_0.W_CONT_LIN);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_500_100_EXIT*/

        [StopWatch]
        /*" M-999-999-ROT-ERRO-SECTION */
        private void M_999_999_ROT_ERRO_SECTION()
        {
            /*" -907- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -908- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], FILLER_0.WABEND.WSQLCODE1);

                /*" -909- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], FILLER_0.WABEND.WSQLCODE2);

                /*" -910- MOVE SQLCODE TO WSQLCODE3 */
                _.Move(DB.SQLCODE, FILLER_0.WSQLCODE3);

                /*" -912- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, FILLER_0.WABEND.WSQLCODE);

                /*" -914- DISPLAY WABEND. */
                _.Display(FILLER_0.WABEND);
            }


            /*" -916- CLOSE SI0105M1. */
            SI0105M1.Close();

            /*" -916- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -917- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -920- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -920- GOBACK. */

            throw new GoBack();

        }
    }
}