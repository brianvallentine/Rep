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
using Sias.Sinistro.DB2.SI0103B;

namespace Code
{
    public class SI0103B
    {
        public bool IsCall { get; set; }

        public SI0103B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *REMARKS.                                                               */
        /*"      *///////////////////////////////////////////////////////////////      */
        /*"      * RELACAO DE SINISTROS AVISADOS NO PERIODO INFORMADO, QUE     //      */
        /*"      * AINDA ESTEJAM PENDENTES NA DATA DE HOJE.                    //      */
        /*"      * SOLICITADO PELA OPCAO: 13 - 12 - 06                         //      */
        /*"      *-------------------------------------------------------------//      */
        /*"      * ANALISTA    - JOSE AGNALDO                                  //      */
        /*"      * PROGRAMADOR - BL                                            //      */
        /*"      * DATA        - 18/05/93                                      //      */
        /*"      *                                                                *      */
        /*"      * CONVERSAO ANO 2000              CONSEDA4              05/1998  *      */
        /*"      *///////////////////////////////////////////////////////////////      */
        /*"      * 20/04/2005 - PRODEXTER                                                */
        /*"      *   SUBSTITUICAO DOS CALCULOS DE VALORES ATRAVES DE ACESSO A            */
        /*"      *   SINISTRO_HISTORICO PELA CHAMADAS AS SUB-ROTINAS DE CALCULO          */
        /*"      *///////////////////////////////////////////////////////////////      */
        #endregion


        #region VARIABLES

        public FileBasis _SI0103M1 { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis SI0103M1
        {
            get
            {
                _.Move(REG_SI0103M1, _SI0103M1); VarBasis.RedefinePassValue(REG_SI0103M1, _SI0103M1, REG_SI0103M1); return _SI0103M1;
            }
        }
        /*"01  REG-SI0103M1.*/
        public SI0103B_REG_SI0103M1 REG_SI0103M1 { get; set; } = new SI0103B_REG_SI0103M1();
        public class SI0103B_REG_SI0103M1 : VarBasis
        {
            /*"    05  LINHA                  PIC  X(132).*/
            public StringBasis LINHA { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  V1HISTMEST-NOME            PIC  X(40).*/
        public StringBasis V1HISTMEST_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77  V1HISTMEST-RAMO            PIC S9(04)       COMP.*/
        public IntBasis V1HISTMEST_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1HISTMEST-FONTE           PIC S9(04)       COMP.*/
        public IntBasis V1HISTMEST_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1HISTMEST-PCTRES          PIC S9(04)V9(05) COMP-3.*/
        public DoubleBasis V1HISTMEST_PCTRES { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(04)V9(05)"), 5);
        /*"77  V1HISTMEST-DATORR          PIC  X(10).*/
        public StringBasis V1HISTMEST_DATORR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1HISTMEST-DTMOVTO         PIC  X(10).*/
        public StringBasis V1HISTMEST_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1HISTMEST-IDTPSEGU        PIC  X(01).*/
        public StringBasis V1HISTMEST_IDTPSEGU { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V1HISTMEST-COD-MOEDA-SINI  PIC S9(04)       COMP.*/
        public IntBasis V1HISTMEST_COD_MOEDA_SINI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1HISTMEST-MODALIDA        PIC S9(04)       COMP.*/
        public IntBasis V1HISTMEST_MODALIDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1HISTMEST-CODSUBES        PIC S9(04)       COMP.*/
        public IntBasis V1HISTMEST_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1HISTMEST-PCPARTIC        PIC S9(04)V9(05) COMP-3.*/
        public DoubleBasis V1HISTMEST_PCPARTIC { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(04)V9(05)"), 5);
        /*"77  V1HISTMEST-NRCERTIF        PIC S9(15)       COMP-3.*/
        public IntBasis V1HISTMEST_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77  V1HISTMEST-NUM-APOLICE     PIC S9(13)       COMP-3.*/
        public IntBasis V1HISTMEST_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V1HISTMEST-NUM-SINISTRO    PIC S9(13)       COMP-3.*/
        public IntBasis V1HISTMEST_NUM_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0MOEDA-SIGLUNIM           PIC  X(06).*/
        public StringBasis V0MOEDA_SIGLUNIM { get; set; } = new StringBasis(new PIC("X", "6", "X(06)."), @"");
        /*"77  V1HISTSINI-NUM-SINISTRO    PIC S9(13)       COMP-3.*/
        public IntBasis V1HISTSINI_NUM_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V1HISTSINI-OPERACAO        PIC S9(04)       VALUE +0 COMP.*/
        public IntBasis V1HISTSINI_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1HISTSINI-VAL-OPERACAO    PIC S9(13)V9(02) VALUE +0 COMP-3.*/
        public DoubleBasis V1HISTSINI_VAL_OPERACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(02)"), 2);
        /*"77  V1PARAMRAMO-RAMO-VG        PIC S9(04)       COMP.*/
        public IntBasis V1PARAMRAMO_RAMO_VG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1PARAMRAMO-RAMO-AP        PIC S9(04)       COMP.*/
        public IntBasis V1PARAMRAMO_RAMO_AP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1PARAMRAMO-RAMO-VGAPC     PIC S9(04)       COMP.*/
        public IntBasis V1PARAMRAMO_RAMO_VGAPC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1PARAMRAMO-RAMO-SAUDE     PIC S9(04)       COMP.*/
        public IntBasis V1PARAMRAMO_RAMO_SAUDE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1PARAMRAMO-RAMO-EDUCACAO  PIC S9(04)       COMP.*/
        public IntBasis V1PARAMRAMO_RAMO_EDUCACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1RELATORIOS-CODUSU        PIC  X(08).*/
        public StringBasis V1RELATORIOS_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
        /*"77  V1RELATORIOS-DATA1         PIC  X(10).*/
        public StringBasis V1RELATORIOS_DATA1 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1RELATORIOS-DATA2         PIC  X(10).*/
        public StringBasis V1RELATORIOS_DATA2 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1RELATORIOS-APOLICE1      PIC S9(13)       COMP-3.*/
        public IntBasis V1RELATORIOS_APOLICE1 { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V1RELATORIOS-APOLICE2      PIC S9(13)       COMP-3.*/
        public IntBasis V1RELATORIOS_APOLICE2 { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V1RELATORIOS-RAMO1         PIC S9(04)       COMP.*/
        public IntBasis V1RELATORIOS_RAMO1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1RELATORIOS-RAMO2         PIC S9(04)       COMP.*/
        public IntBasis V1RELATORIOS_RAMO2 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1RAMO-NOMERAMO            PIC  X(30).*/
        public StringBasis V1RAMO_NOMERAMO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"77  V1FONTE-NOMEFTE            PIC  X(30).*/
        public StringBasis V1FONTE_NOMEFTE { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"77  V1SISTEMA-DTMOVABE         PIC  X(10).*/
        public StringBasis V1SISTEMA_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1SISTEMA-DTCURRENT        PIC  X(10).*/
        public StringBasis V1SISTEMA_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1CLIENTE-NOME-RAZAO       PIC  X(40).*/
        public StringBasis V1CLIENTE_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77  V1EMPRESA-NOME-EMPRESA     PIC  X(40).*/
        public StringBasis V1EMPRESA_NOME_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"01  FILLER.*/
        public SI0103B_FILLER_0 FILLER_0 { get; set; } = new SI0103B_FILLER_0();
        public class SI0103B_FILLER_0 : VarBasis
        {
            /*"    03  LC01.*/
            public SI0103B_LC01 LC01 { get; set; } = new SI0103B_LC01();
            public class SI0103B_LC01 : VarBasis
            {
                /*"        05  FILLER             PIC  X(09) VALUE 'SI0103B.1'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"SI0103B.1");
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
            public SI0103B_LC02 LC02 { get; set; } = new SI0103B_LC02();
            public class SI0103B_LC02 : VarBasis
            {
                /*"        05  FILLER             PIC X(117) VALUE  SPACES.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "117", "X(117)"), @"");
                /*"        05  FILLER             PIC  X(05) VALUE 'DATA'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"DATA");
                /*"        05  LC02-DATA          PIC  X(10) VALUE  SPACES.*/
                public StringBasis LC02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"    03  LC03.*/
            }
            public SI0103B_LC03 LC03 { get; set; } = new SI0103B_LC03();
            public class SI0103B_LC03 : VarBasis
            {
                /*"        05  FILLER             PIC X(117) VALUE  SPACES.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "117", "X(117)"), @"");
                /*"        05  FILLER             PIC  X(07) VALUE 'HORA'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"HORA");
                /*"        05  LC03-HORA          PIC  X(08) VALUE  SPACES.*/
                public StringBasis LC03_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
                /*"    03  LC04.*/
            }
            public SI0103B_LC04 LC04 { get; set; } = new SI0103B_LC04();
            public class SI0103B_LC04 : VarBasis
            {
                /*"        05  FILLER             PIC  X(36) VALUE  SPACES.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "36", "X(36)"), @"");
                /*"        05  FILLER             PIC  X(33) VALUE        'SINISTROS AVISADOS NO PERIODO DE '.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "33", "X(33)"), @"SINISTROS AVISADOS NO PERIODO DE ");
                /*"        05  LC04-DATA1         PIC  X(10) VALUE  SPACES.*/
                public StringBasis LC04_DATA1 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"        05  FILLER             PIC  X(03) VALUE ' A '.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" A ");
                /*"        05  LC04-DATA2         PIC  X(10) VALUE  SPACES.*/
                public StringBasis LC04_DATA2 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"        05  FILLER             PIC  X(34) VALUE        ' E AINDA PENDENTES NA DATA DE HOJE'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @" E AINDA PENDENTES NA DATA DE HOJE");
                /*"    03  LC05.*/
            }
            public SI0103B_LC05 LC05 { get; set; } = new SI0103B_LC05();
            public class SI0103B_LC05 : VarBasis
            {
                /*"        05  FILLER             PIC  X(07) VALUE 'RAMO'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"RAMO");
                /*"        05  LC05-RAMO          PIC  9(03) VALUE  ZEROES.*/
                public IntBasis LC05_RAMO { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
                /*"        05  FILLER             PIC  X(03) VALUE ' - '.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" - ");
                /*"        05  LC05-NOMERAMO      PIC  X(30) VALUE  SPACES.*/
                public StringBasis LC05_NOMERAMO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
                /*"    03  LC06.*/
            }
            public SI0103B_LC06 LC06 { get; set; } = new SI0103B_LC06();
            public class SI0103B_LC06 : VarBasis
            {
                /*"        05  FILLER             PIC  X(07) VALUE 'FONTE'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"FONTE");
                /*"        05  LC06-FONTE         PIC  9(03) VALUE  ZEROES.*/
                public IntBasis LC06_FONTE { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
                /*"        05  FILLER             PIC  X(03) VALUE ' - '.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" - ");
                /*"        05  LC06-NOMEFTE       PIC  X(30) VALUE  SPACES.*/
                public StringBasis LC06_NOMEFTE { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
                /*"    03  LC07.*/
            }
            public SI0103B_LC07 LC07 { get; set; } = new SI0103B_LC07();
            public class SI0103B_LC07 : VarBasis
            {
                /*"        05  FILLER             PIC X(132) VALUE  ALL '-'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
                /*"    03  LC08.*/
            }
            public SI0103B_LC08 LC08 { get; set; } = new SI0103B_LC08();
            public class SI0103B_LC08 : VarBasis
            {
                /*"        05  FILLER             PIC  X(17) VALUE 'SINISTRO'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @"SINISTRO");
                /*"        05  FILLER             PIC  X(13) VALUE 'OCORRENCIA'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"OCORRENCIA");
                /*"        05  FILLER             PIC  X(10) VALUE 'AVISO'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"AVISO");
                /*"        05  FILLER             PIC  X(22) VALUE 'SEGURADO'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "22", "X(22)"), @"SEGURADO");
                /*"        05  FILLER             PIC  X(10) VALUE 'SUB-GRUPO'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"SUB-GRUPO");
                /*"        05  FILLER             PIC  X(15) VALUE 'MOEDA'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"MOEDA");
                /*"        05  FILLER             PIC  X(19) VALUE 'LIDERANCA'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "19", "X(19)"), @"LIDERANCA");
                /*"        05  FILLER             PIC  X(19) VALUE 'COSSEGURO'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "19", "X(19)"), @"COSSEGURO");
                /*"        05  FILLER             PIC  X(09) VALUE 'RESSEGURO'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"RESSEGURO");
                /*"    03  LC09.*/
            }
            public SI0103B_LC09 LC09 { get; set; } = new SI0103B_LC09();
            public class SI0103B_LC09 : VarBasis
            {
                /*"        05  FILLER             PIC  X(33) VALUE  SPACES.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "33", "X(33)"), @"");
                /*"        05  FILLER             PIC  X(08) VALUE 'APOLICE'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"APOLICE");
                /*"        05  FILLER             PIC  X(02) VALUE ':'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @":");
                /*"        05  LC09-APOLICE       PIC  9(13) VALUE  ZEROES.*/
                public IntBasis LC09_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
                /*"        05  FILLER             PIC  X(01) VALUE  SPACES.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  FILLER             PIC  X(02) VALUE '-'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"-");
                /*"        05  LC09-NOME-APOLICE  PIC  X(40) VALUE  SPACES.*/
                public StringBasis LC09_NOME_APOLICE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"    03  LD01.*/
            }
            public SI0103B_LD01 LD01 { get; set; } = new SI0103B_LD01();
            public class SI0103B_LD01 : VarBasis
            {
                /*"        05  LD01-SINISTRO      PIC  9(13) VALUE  ZEROES.*/
                public IntBasis LD01_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
                /*"        05  FILLER             PIC  X(01) VALUE  SPACE.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  LD01-DATORR        PIC  X(10) VALUE  SPACES.*/
                public StringBasis LD01_DATORR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"        05  FILLER             PIC  X(01) VALUE  SPACE.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  LD01-DTMOVTO       PIC  X(10) VALUE  SPACES.*/
                public StringBasis LD01_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"        05  FILLER             PIC  X(01) VALUE  SPACE.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  LD01-NOME          PIC  X(30) VALUE  SPACES.*/
                public StringBasis LD01_NOME { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
                /*"        05  FILLER             PIC  X(01) VALUE  SPACE.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  LD01-CODSUBES      PIC  9(04) VALUE  ZEROES.*/
                public IntBasis LD01_CODSUBES { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"        05  FILLER             PIC  X(01) VALUE  SPACE.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  LD01-SIGLUNIM      PIC  X(06) VALUE  SPACES.*/
                public StringBasis LD01_SIGLUNIM { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"");
                /*"        05  LD01-LIDER         PIC  ZZZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LD01_LIDER { get; set; } = new DoubleBasis(new PIC("9", "11", "ZZZZZ.ZZZ.ZZ9V99."), 2);
                /*"        05  FILLER             PIC  X(01) VALUE  SPACE.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  LD01-COSSEGURO     PIC  ZZZZZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LD01_COSSEGURO { get; set; } = new DoubleBasis(new PIC("9", "13", "ZZZZZZZ.ZZZ.ZZ9V99."), 2);
                /*"        05  FILLER             PIC  X(01) VALUE  SPACE.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  LD01-RESSEGURO     PIC  ZZZZZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LD01_RESSEGURO { get; set; } = new DoubleBasis(new PIC("9", "13", "ZZZZZZZ.ZZZ.ZZ9V99."), 2);
                /*"    03  LT01.*/
            }
            public SI0103B_LT01 LT01 { get; set; } = new SI0103B_LT01();
            public class SI0103B_LT01 : VarBasis
            {
                /*"        05  FILLER             PIC  X(05) VALUE 'QTDE'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"QTDE");
                /*"        05  FILLER             PIC  X(10) VALUE 'SINISTROS'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"SINISTROS");
                /*"        05  FILLER             PIC  X(05) VALUE 'FONTE'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"FONTE");
                /*"        05  LT01-ACC-FONTE     PIC  ZZZ.ZZ9.*/
                public IntBasis LT01_ACC_FONTE { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.ZZ9."));
                /*"        05  FILLER             PIC  X(05) VALUE  SPACES.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
                /*"        05  FILLER             PIC  X(06) VALUE 'VALOR'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"VALOR");
                /*"        05  FILLER             PIC  X(06) VALUE 'TOTAL'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"TOTAL");
                /*"        05  FILLER             PIC  X(32) VALUE 'FONTE'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "32", "X(32)"), @"FONTE");
                /*"        05  LT01-ACC-FONTE1    PIC  ZZZZZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LT01_ACC_FONTE1 { get; set; } = new DoubleBasis(new PIC("9", "13", "ZZZZZZZ.ZZZ.ZZ9V99."), 2);
                /*"        05  FILLER             PIC  X(01) VALUE  SPACE.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  LT01-ACC-FONTE2    PIC  ZZZZZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LT01_ACC_FONTE2 { get; set; } = new DoubleBasis(new PIC("9", "13", "ZZZZZZZ.ZZZ.ZZ9V99."), 2);
                /*"        05  FILLER             PIC  X(01) VALUE  SPACE.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  LT01-ACC-FONTE3    PIC  ZZZZZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LT01_ACC_FONTE3 { get; set; } = new DoubleBasis(new PIC("9", "13", "ZZZZZZZ.ZZZ.ZZ9V99."), 2);
                /*"    03  LT02.*/
            }
            public SI0103B_LT02 LT02 { get; set; } = new SI0103B_LT02();
            public class SI0103B_LT02 : VarBasis
            {
                /*"        05  FILLER             PIC  X(05) VALUE 'QTDE'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"QTDE");
                /*"        05  FILLER             PIC  X(10) VALUE 'SINISTROS'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"SINISTROS");
                /*"        05  FILLER             PIC  X(05) VALUE 'RAMO'.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"RAMO");
                /*"        05  LT02-ACC-RAMO      PIC  ZZZ.ZZ9.*/
                public IntBasis LT02_ACC_RAMO { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.ZZ9."));
                /*"        05  FILLER             PIC  X(05) VALUE  SPACES.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
                /*"        05  FILLER             PIC  X(06) VALUE 'VALOR'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"VALOR");
                /*"        05  FILLER             PIC  X(06) VALUE 'TOTAL'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"TOTAL");
                /*"        05  FILLER             PIC  X(32) VALUE 'RAMO'.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "32", "X(32)"), @"RAMO");
                /*"        05  LT02-ACC-RAMO1     PIC  ZZZZZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LT02_ACC_RAMO1 { get; set; } = new DoubleBasis(new PIC("9", "13", "ZZZZZZZ.ZZZ.ZZ9V99."), 2);
                /*"        05  FILLER             PIC  X(01) VALUE  SPACE.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  LT02-ACC-RAMO2     PIC  ZZZZZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LT02_ACC_RAMO2 { get; set; } = new DoubleBasis(new PIC("9", "13", "ZZZZZZZ.ZZZ.ZZ9V99."), 2);
                /*"        05  FILLER             PIC  X(01) VALUE  SPACE.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  LT02-ACC-RAMO3     PIC  ZZZZZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LT02_ACC_RAMO3 { get; set; } = new DoubleBasis(new PIC("9", "13", "ZZZZZZZ.ZZZ.ZZ9V99."), 2);
                /*"    03  LT03.*/
            }
            public SI0103B_LT03 LT03 { get; set; } = new SI0103B_LT03();
            public class SI0103B_LT03 : VarBasis
            {
                /*"        05  FILLER             PIC  X(05) VALUE 'QTDE'.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"QTDE");
                /*"        05  FILLER             PIC  X(10) VALUE 'SINISTROS'.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"SINISTROS");
                /*"        05  FILLER             PIC  X(05) VALUE 'GERAL'.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"GERAL");
                /*"        05  LT03-ACC-GERAL     PIC  ZZZ.ZZ9.*/
                public IntBasis LT03_ACC_GERAL { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.ZZ9."));
                /*"        05  FILLER             PIC  X(05) VALUE  SPACES.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
                /*"        05  FILLER             PIC  X(06) VALUE 'VALOR'.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"VALOR");
                /*"        05  FILLER             PIC  X(06) VALUE 'TOTAL'.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"TOTAL");
                /*"        05  FILLER             PIC  X(32) VALUE 'GERAL'.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "32", "X(32)"), @"GERAL");
                /*"        05  LT03-ACC-GERAL1    PIC  ZZZZZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LT03_ACC_GERAL1 { get; set; } = new DoubleBasis(new PIC("9", "13", "ZZZZZZZ.ZZZ.ZZ9V99."), 2);
                /*"        05  FILLER             PIC  X(01) VALUE  SPACE.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  LT03-ACC-GERAL2    PIC  ZZZZZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LT03_ACC_GERAL2 { get; set; } = new DoubleBasis(new PIC("9", "13", "ZZZZZZZ.ZZZ.ZZ9V99."), 2);
                /*"        05  FILLER             PIC  X(01) VALUE  SPACE.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  LT03-ACC-GERAL3    PIC  ZZZZZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LT03_ACC_GERAL3 { get; set; } = new DoubleBasis(new PIC("9", "13", "ZZZZZZZ.ZZZ.ZZ9V99."), 2);
                /*"    03  WDATA.*/
            }
            public SI0103B_WDATA WDATA { get; set; } = new SI0103B_WDATA();
            public class SI0103B_WDATA : VarBasis
            {
                /*"        05  WDATA-AA           PIC  9(04) VALUE  ZEROES.*/
                public IntBasis WDATA_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"        05  FILLER             PIC  X(01) VALUE  SPACES.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  WDATA-MM           PIC  9(02) VALUE  ZEROES.*/
                public IntBasis WDATA_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"        05  FILLER             PIC  X(01) VALUE  SPACES.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  WDATA-DD           PIC  9(02) VALUE  ZEROES.*/
                public IntBasis WDATA_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    03       WDATA-CURR        PIC  X(010)    VALUE SPACES.*/
            }
            public StringBasis WDATA_CURR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    03       FILLER            REDEFINES      WDATA-CURR.*/
            private _REDEF_SI0103B_FILLER_67 _filler_67 { get; set; }
            public _REDEF_SI0103B_FILLER_67 FILLER_67
            {
                get { _filler_67 = new _REDEF_SI0103B_FILLER_67(); _.Move(WDATA_CURR, _filler_67); VarBasis.RedefinePassValue(WDATA_CURR, _filler_67, WDATA_CURR); _filler_67.ValueChanged += () => { _.Move(_filler_67, WDATA_CURR); }; return _filler_67; }
                set { VarBasis.RedefinePassValue(value, _filler_67, WDATA_CURR); }
            }  //Redefines
            public class _REDEF_SI0103B_FILLER_67 : VarBasis
            {
                /*"      05     WDATA-AA-CURR     PIC  9(004).*/
                public IntBasis WDATA_AA_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      05     FILLER            PIC  X(001).*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      05     WDATA-MM-CURR     PIC  9(002).*/
                public IntBasis WDATA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05     FILLER            PIC  X(001).*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      05     WDATA-DD-CURR     PIC  9(002).*/
                public IntBasis WDATA_DD_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03  WHORA-CURR.*/

                public _REDEF_SI0103B_FILLER_67()
                {
                    WDATA_AA_CURR.ValueChanged += OnValueChanged;
                    FILLER_68.ValueChanged += OnValueChanged;
                    WDATA_MM_CURR.ValueChanged += OnValueChanged;
                    FILLER_69.ValueChanged += OnValueChanged;
                    WDATA_DD_CURR.ValueChanged += OnValueChanged;
                }

            }
            public SI0103B_WHORA_CURR WHORA_CURR { get; set; } = new SI0103B_WHORA_CURR();
            public class SI0103B_WHORA_CURR : VarBasis
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
            public SI0103B_WDATA_CABEC WDATA_CABEC { get; set; } = new SI0103B_WDATA_CABEC();
            public class SI0103B_WDATA_CABEC : VarBasis
            {
                /*"        05  WDATA-DD-CABEC     PIC  9(02) VALUE  ZEROES.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"        05  FILLER             PIC  X(01) VALUE '/'.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"        05  WDATA-MM-CABEC     PIC  9(02) VALUE  ZEROES.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"        05  FILLER             PIC  X(01) VALUE '/'.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"        05  WDATA-AA-CABEC     PIC  9(04) VALUE  ZEROES.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"    03  WHORA-CABEC.*/
            }
            public SI0103B_WHORA_CABEC WHORA_CABEC { get; set; } = new SI0103B_WHORA_CABEC();
            public class SI0103B_WHORA_CABEC : VarBasis
            {
                /*"        05  WHORA-HH-CABEC     PIC  9(02) VALUE  ZEROES.*/
                public IntBasis WHORA_HH_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"        05  FILLER             PIC  X(01) VALUE ':'.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @":");
                /*"        05  WHORA-MM-CABEC     PIC  9(02) VALUE  ZEROES.*/
                public IntBasis WHORA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"        05  FILLER             PIC  X(01) VALUE ':'.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @":");
                /*"        05  WHORA-SS-CABEC     PIC  9(02) VALUE  ZEROES.*/
                public IntBasis WHORA_SS_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    03  W-FIM-RELATORIOS       PIC  X(03)    VALUE 'NAO'.*/
            }
            public StringBasis W_FIM_RELATORIOS { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    03  W-FIM-HISTMEST         PIC  X(03)    VALUE 'NAO'.*/
            public StringBasis W_FIM_HISTMEST { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    03  W-FIM-HISTSINI         PIC  X(03)    VALUE 'NAO'.*/
            public StringBasis W_FIM_HISTSINI { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    03  W-CHAVE-ABRIU-RELAT    PIC  X(03)    VALUE 'NAO'.*/
            public StringBasis W_CHAVE_ABRIU_RELAT { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
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
            /*"    03  W-ACC-RAMO             PIC S9(06)    VALUE ZEROES COMP.*/
            public IntBasis W_ACC_RAMO { get; set; } = new IntBasis(new PIC("S9", "6", "S9(06)"));
            /*"    03  W-ACC-FONTE            PIC S9(06)    VALUE ZEROES COMP.*/
            public IntBasis W_ACC_FONTE { get; set; } = new IntBasis(new PIC("S9", "6", "S9(06)"));
            /*"    03  W-ACC-GERAL            PIC S9(06)    VALUE ZEROES COMP.*/
            public IntBasis W_ACC_GERAL { get; set; } = new IntBasis(new PIC("S9", "6", "S9(06)"));
            /*"    03  W-ACUM-PENDENTE        PIC S9(13)V99 VALUE ZEROES COMP-3*/
            public DoubleBasis W_ACUM_PENDENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    03  W-LIDER                PIC S9(13)V99 VALUE ZEROES COMP-3*/
            public DoubleBasis W_LIDER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    03  W-COSSEGURO            PIC S9(13)V99 VALUE ZEROES COMP-3*/
            public DoubleBasis W_COSSEGURO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    03  W-RESSEGURO            PIC S9(13)V99 VALUE ZEROES COMP-3*/
            public DoubleBasis W_RESSEGURO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    03  W-ACC-RAMO1            PIC S9(13)V99 VALUE ZEROES COMP-3*/
            public DoubleBasis W_ACC_RAMO1 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    03  W-ACC-RAMO2            PIC S9(13)V99 VALUE ZEROES COMP-3*/
            public DoubleBasis W_ACC_RAMO2 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    03  W-ACC-RAMO3            PIC S9(13)V99 VALUE ZEROES COMP-3*/
            public DoubleBasis W_ACC_RAMO3 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    03  W-ACC-FONTE1           PIC S9(13)V99 VALUE ZEROES COMP-3*/
            public DoubleBasis W_ACC_FONTE1 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    03  W-ACC-FONTE2           PIC S9(13)V99 VALUE ZEROES COMP-3*/
            public DoubleBasis W_ACC_FONTE2 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    03  W-ACC-FONTE3           PIC S9(13)V99 VALUE ZEROES COMP-3*/
            public DoubleBasis W_ACC_FONTE3 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    03  W-ACC-GERAL1           PIC S9(13)V99 VALUE ZEROES COMP-3*/
            public DoubleBasis W_ACC_GERAL1 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    03  W-ACC-GERAL2           PIC S9(13)V99 VALUE ZEROES COMP-3*/
            public DoubleBasis W_ACC_GERAL2 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    03  W-ACC-GERAL3           PIC S9(13)V99 VALUE ZEROES COMP-3*/
            public DoubleBasis W_ACC_GERAL3 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    03  WSQLCODE3              PIC S9(09) VALUE  ZEROES COMP.*/
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"    03  WABEND.*/
            public SI0103B_WABEND WABEND { get; set; } = new SI0103B_WABEND();
            public class SI0103B_WABEND : VarBasis
            {
                /*"        05  FILLER             PIC  X(01) VALUE  SPACE.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  FILLER             PIC  X(09) VALUE 'SI0103B'.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"SI0103B");
                /*"        05  FILLER             PIC  X(10) VALUE '*** ERRO'.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"*** ERRO");
                /*"        05  FILLER             PIC  X(10) VALUE 'EXEC SQL'.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"EXEC SQL");
                /*"        05  FILLER             PIC  X(08) VALUE 'NUMERO'.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"NUMERO");
                /*"        05  WNR-EXEC-SQL       PIC  X(03) VALUE  SPACES.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
                /*"        05  FILLER             PIC  X(01) VALUE  SPACE.*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  FILLER             PIC  X(16) VALUE '** PARAGRAFO ='*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"** PARAGRAFO =");
                /*"        05  PARAGRAFO          PIC  X(30) VALUE  SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
                /*"        05  FILLER             PIC  X(04) VALUE  SPACES.*/
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
                /*"        05  FILLER             PIC  X(10) VALUE 'SQLCODE = '.*/
                public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"SQLCODE = ");
                /*"        05  WSQLCODE           PIC  ZZZZZZ999-   VALUE ZEROES.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"        05  FILLER             PIC  X(04) VALUE  SPACES.*/
                public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
                /*"        05  FILLER             PIC  X(10) VALUE 'SQLCODE1= '.*/
                public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"SQLCODE1= ");
                /*"        05  WSQLCODE1          PIC  ZZZZZZ999-   VALUE ZEROES.*/
                public IntBasis WSQLCODE1 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"        05  FILLER             PIC  X(04) VALUE  SPACES.*/
                public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
                /*"        05  FILLER             PIC  X(10) VALUE 'SQLCODE2= '.*/
                public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"SQLCODE2= ");
                /*"        05  WSQLCODE2          PIC  ZZZZZZ999-   VALUE ZEROES.*/
                public IntBasis WSQLCODE2 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"    03  FILLER.*/
            }
            public SI0103B_FILLER_87 FILLER_87 { get; set; } = new SI0103B_FILLER_87();
            public class SI0103B_FILLER_87 : VarBasis
            {
                /*"        05  W-MENSAGEM1        PIC  X(35) VALUE           'SI0103B - SEM MOVIMENTOS NO DIA'.*/
                public StringBasis W_MENSAGEM1 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"SI0103B - SEM MOVIMENTOS NO DIA");
                /*"        05  W-MENSAGEM2        PIC  X(35) VALUE           'SI0103B - EMPRESA NAO ENCONTRADA'.*/
                public StringBasis W_MENSAGEM2 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"SI0103B - EMPRESA NAO ENCONTRADA");
                /*"        05  W-MENSAGEM3        PIC  X(35) VALUE           'SI0103B - SISTEMA NAO ENCONTRADO'.*/
                public StringBasis W_MENSAGEM3 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"SI0103B - SISTEMA NAO ENCONTRADO");
                /*"        05  W-MENSAGEM4        PIC  X(35) VALUE           'SI0103B - PARAMRAMO NAO ENCONTRADO'.*/
                public StringBasis W_MENSAGEM4 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"SI0103B - PARAMRAMO NAO ENCONTRADO");
                /*"        05  W-MENSAGEM5        PIC  X(35) VALUE           'SI0103B - RAMO NAO ENCONTRADO'.*/
                public StringBasis W_MENSAGEM5 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"SI0103B - RAMO NAO ENCONTRADO");
                /*"        05  W-MENSAGEM6        PIC  X(35) VALUE           'SI0103B - FONTE NAO ENCONTRADA'.*/
                public StringBasis W_MENSAGEM6 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"SI0103B - FONTE NAO ENCONTRADA");
                /*"        05  W-MENSAGEM7        PIC  X(35) VALUE           'SI0103B - CLIENTE NAO ENCONTRADO'.*/
                public StringBasis W_MENSAGEM7 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"SI0103B - CLIENTE NAO ENCONTRADO");
                /*"01  LK-LINK.*/
            }
        }
        public SI0103B_LK_LINK LK_LINK { get; set; } = new SI0103B_LK_LINK();
        public class SI0103B_LK_LINK : VarBasis
        {
            /*"    03  LK-RTCODE              PIC S9(04) VALUE  +00000 COMP.*/
            public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"), +00000);
            /*"    03  LK-TAMANHO             PIC S9(04) VALUE  +00040 COMP.*/
            public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"), +00040);
            /*"    03  LK-TITULO              PIC X(132) VALUE  SPACES.*/
            public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
        }


        public Copies.LBSI1001 LBSI1001 { get; set; } = new Copies.LBSI1001();
        public SI0103B_RELATORIOS RELATORIOS { get; set; } = new SI0103B_RELATORIOS();
        public SI0103B_HISTMEST HISTMEST { get; set; } = new SI0103B_HISTMEST();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SI0103M1_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SI0103M1.SetFile(SI0103M1_FILE_NAME_P);

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
            /*" -376- MOVE '000-000-PRINCIPAL' TO PARAGRAFO. */
            _.Move("000-000-PRINCIPAL", FILLER_0.WABEND.PARAGRAFO);

            /*" -379- MOVE '000' TO WNR-EXEC-SQL. */
            _.Move("000", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -379- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -381- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -383- EXEC SQL WHENEVER SQLERROR GO TO 999-999-ROT-ERRO END-EXEC. */

            /*" -387- ACCEPT WHORA-CURR FROM TIME. */
            _.Move(_.AcceptDate("TIME"), FILLER_0.WHORA_CURR);

            /*" -388- MOVE WHORA-HH-CURR TO WHORA-HH-CABEC. */
            _.Move(FILLER_0.WHORA_CURR.WHORA_HH_CURR, FILLER_0.WHORA_CABEC.WHORA_HH_CABEC);

            /*" -389- MOVE WHORA-MM-CURR TO WHORA-MM-CABEC. */
            _.Move(FILLER_0.WHORA_CURR.WHORA_MM_CURR, FILLER_0.WHORA_CABEC.WHORA_MM_CABEC);

            /*" -390- MOVE WHORA-SS-CURR TO WHORA-SS-CABEC. */
            _.Move(FILLER_0.WHORA_CURR.WHORA_SS_CURR, FILLER_0.WHORA_CABEC.WHORA_SS_CABEC);

            /*" -392- MOVE WHORA-CABEC TO LC03-HORA. */
            _.Move(FILLER_0.WHORA_CABEC, FILLER_0.LC03.LC03_HORA);

            /*" -394- PERFORM 000-200-SELECT-V1SISTEMA. */

            M_000_200_SELECT_V1SISTEMA_SECTION();

            /*" -395- MOVE V1SISTEMA-DTCURRENT TO WDATA-CURR */
            _.Move(V1SISTEMA_DTCURRENT, FILLER_0.WDATA_CURR);

            /*" -396- MOVE WDATA-DD-CURR TO WDATA-DD-CABEC. */
            _.Move(FILLER_0.FILLER_67.WDATA_DD_CURR, FILLER_0.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -397- MOVE WDATA-MM-CURR TO WDATA-MM-CABEC. */
            _.Move(FILLER_0.FILLER_67.WDATA_MM_CURR, FILLER_0.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -398- MOVE WDATA-AA-CURR TO WDATA-AA-CABEC. */
            _.Move(FILLER_0.FILLER_67.WDATA_AA_CURR, FILLER_0.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -400- MOVE WDATA-CABEC TO LC02-DATA. */
            _.Move(FILLER_0.WDATA_CABEC, FILLER_0.LC02.LC02_DATA);

            /*" -401- PERFORM 000-300-DECLARE-RELATORIOS. */

            M_000_300_DECLARE_RELATORIOS_SECTION();

            /*" -402- MOVE 'NAO' TO W-FIM-RELATORIOS. */
            _.Move("NAO", FILLER_0.W_FIM_RELATORIOS);

            /*" -404- PERFORM 000-400-FETCH-RELATORIOS. */

            M_000_400_FETCH_RELATORIOS_SECTION();

            /*" -405- IF W-FIM-RELATORIOS EQUAL 'SIM' */

            if (FILLER_0.W_FIM_RELATORIOS == "SIM")
            {

                /*" -406- DISPLAY '///////////////////////////////////////////////' */
                _.Display($"///////////////////////////////////////////////");

                /*" -407- DISPLAY '//                                           //' */
                _.Display($"//                                           //");

                /*" -408- DISPLAY '//     PROGRAMA =>  SI0103B                  //' */
                _.Display($"//     PROGRAMA =>  SI0103B                  //");

                /*" -409- DISPLAY '//                                           //' */
                _.Display($"//                                           //");

                /*" -410- DISPLAY '//  ==> NAO HOUVE SOLICITACAO DO USUARIO <== //' */
                _.Display($"//  ==> NAO HOUVE SOLICITACAO DO USUARIO <== //");

                /*" -411- DISPLAY '//                                           //' */
                _.Display($"//                                           //");

                /*" -412- DISPLAY '///////////////////////////////////////////////' */
                _.Display($"///////////////////////////////////////////////");

                /*" -414- GO TO 000-800-FINALIZA. */

                M_000_800_FINALIZA_SECTION(); //GOTO
                return;
            }


            /*" -416- OPEN OUTPUT SI0103M1. */
            SI0103M1.Open(REG_SI0103M1);

            /*" -418- MOVE 'SIM' TO W-CHAVE-ABRIU-RELAT. */
            _.Move("SIM", FILLER_0.W_CHAVE_ABRIU_RELAT);

            /*" -419- PERFORM 000-100-SELECT-V1EMPRESA. */

            M_000_100_SELECT_V1EMPRESA_SECTION();

            /*" -421- PERFORM 000-500-SELECT-V1PARAMRAMO. */

            M_000_500_SELECT_V1PARAMRAMO_SECTION();

            /*" -424- PERFORM 000-600-PROCESSA-RELATORIOS UNTIL W-FIM-RELATORIOS EQUAL 'SIM' . */

            while (!(FILLER_0.W_FIM_RELATORIOS == "SIM"))
            {

                M_000_600_PROCESSA_RELATORIOS_SECTION();
            }

            /*" -425- PERFORM 000-700-DELETE-V1RELATORIOS. */

            M_000_700_DELETE_V1RELATORIOS_SECTION();

            /*" -425- PERFORM 000-800-FINALIZA. */

            M_000_800_FINALIZA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_000_EXIT*/

        [StopWatch]
        /*" M-000-600-PROCESSA-RELATORIOS-SECTION */
        private void M_000_600_PROCESSA_RELATORIOS_SECTION()
        {
            /*" -435- MOVE '000-600-PROCESSA-RELATORIOS' TO PARAGRAFO. */
            _.Move("000-600-PROCESSA-RELATORIOS", FILLER_0.WABEND.PARAGRAFO);

            /*" -436- PERFORM 100-100-DECLARE-HISTMEST. */

            M_100_100_DECLARE_HISTMEST_SECTION();

            /*" -437- MOVE 'NAO' TO W-FIM-HISTMEST */
            _.Move("NAO", FILLER_0.W_FIM_HISTMEST);

            /*" -439- PERFORM 100-200-FETCH-HISTMEST. */

            M_100_200_FETCH_HISTMEST_SECTION();

            /*" -440- IF W-FIM-HISTMEST EQUAL 'SIM' */

            if (FILLER_0.W_FIM_HISTMEST == "SIM")
            {

                /*" -441- DISPLAY '////////////////////////////////////////////////' */
                _.Display($"////////////////////////////////////////////////");

                /*" -442- DISPLAY '//                                            //' */
                _.Display($"//                                            //");

                /*" -443- DISPLAY '//    NADA SELECIONADO PARA A SOLICITACAO     //' */
                _.Display($"//    NADA SELECIONADO PARA A SOLICITACAO     //");

                /*" -444- DISPLAY '//                                            //' */
                _.Display($"//                                            //");

                /*" -445- DISPLAY '////////////////////////////////////////////////' */
                _.Display($"////////////////////////////////////////////////");

                /*" -446- PERFORM 000-400-FETCH-RELATORIOS */

                M_000_400_FETCH_RELATORIOS_SECTION();

                /*" -448- GO TO 000-600-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_600_EXIT*/ //GOTO
                return;
            }


            /*" -451- PERFORM 100-300-PROCESSA-HISTMEST UNTIL W-FIM-HISTMEST EQUAL 'SIM' . */

            while (!(FILLER_0.W_FIM_HISTMEST == "SIM"))
            {

                M_100_300_PROCESSA_HISTMEST_SECTION();
            }

            /*" -452- PERFORM 100-400-QUEBRA-GERAL. */

            M_100_400_QUEBRA_GERAL_SECTION();

            /*" -452- PERFORM 000-400-FETCH-RELATORIOS. */

            M_000_400_FETCH_RELATORIOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_600_EXIT*/

        [StopWatch]
        /*" M-100-300-PROCESSA-HISTMEST-SECTION */
        private void M_100_300_PROCESSA_HISTMEST_SECTION()
        {
            /*" -462- MOVE '100-300-PROCESSA-HISTMEST' TO PARAGRAFO. */
            _.Move("100-300-PROCESSA-HISTMEST", FILLER_0.WABEND.PARAGRAFO);

            /*" -464- PERFORM 000-000-ACESSA-MOEDA. */

            M_000_000_ACESSA_MOEDA_SECTION();

            /*" -465- MOVE V1HISTMEST-RAMO TO LC05-RAMO. */
            _.Move(V1HISTMEST_RAMO, FILLER_0.LC05.LC05_RAMO);

            /*" -467- MOVE V1HISTMEST-MODALIDA TO W-MODALIDA-ANT. */
            _.Move(V1HISTMEST_MODALIDA, FILLER_0.W_MODALIDA_ANT);

            /*" -469- PERFORM 200-100-SELECT-V1RAMO. */

            M_200_100_SELECT_V1RAMO_SECTION();

            /*" -474- PERFORM 200-200-PROCESSA-RAMO UNTIL (W-FIM-HISTMEST EQUAL 'SIM' ) OR (V1HISTMEST-RAMO NOT EQUAL LC05-RAMO) OR (V1HISTMEST-MODALIDA NOT EQUAL W-MODALIDA-ANT). */

            while (!((FILLER_0.W_FIM_HISTMEST == "SIM") || (V1HISTMEST_RAMO != FILLER_0.LC05.LC05_RAMO) || (V1HISTMEST_MODALIDA != FILLER_0.W_MODALIDA_ANT)))
            {

                M_200_200_PROCESSA_RAMO_SECTION();
            }

            /*" -474- PERFORM 200-300-QUEBRA-RAMO. */

            M_200_300_QUEBRA_RAMO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_300_EXIT*/

        [StopWatch]
        /*" M-200-200-PROCESSA-RAMO-SECTION */
        private void M_200_200_PROCESSA_RAMO_SECTION()
        {
            /*" -484- MOVE '200-200-PROCESSA-RAMO' TO PARAGRAFO. */
            _.Move("200-200-PROCESSA-RAMO", FILLER_0.WABEND.PARAGRAFO);

            /*" -486- MOVE V1HISTMEST-FONTE TO LC06-FONTE. */
            _.Move(V1HISTMEST_FONTE, FILLER_0.LC06.LC06_FONTE);

            /*" -488- PERFORM 300-100-SELECT-V1FONTE. */

            M_300_100_SELECT_V1FONTE_SECTION();

            /*" -494- PERFORM 300-200-PROCESSA-FONTE UNTIL (W-FIM-HISTMEST EQUAL 'SIM' ) OR (V1HISTMEST-RAMO NOT EQUAL LC05-RAMO) OR (V1HISTMEST-MODALIDA NOT EQUAL W-MODALIDA-ANT) OR (V1HISTMEST-FONTE NOT EQUAL LC06-FONTE). */

            while (!((FILLER_0.W_FIM_HISTMEST == "SIM") || (V1HISTMEST_RAMO != FILLER_0.LC05.LC05_RAMO) || (V1HISTMEST_MODALIDA != FILLER_0.W_MODALIDA_ANT) || (V1HISTMEST_FONTE != FILLER_0.LC06.LC06_FONTE)))
            {

                M_300_200_PROCESSA_FONTE_SECTION();
            }

            /*" -494- PERFORM 300-300-QUEBRA-FONTE. */

            M_300_300_QUEBRA_FONTE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_200_200_EXIT*/

        [StopWatch]
        /*" M-300-200-PROCESSA-FONTE-SECTION */
        private void M_300_200_PROCESSA_FONTE_SECTION()
        {
            /*" -504- MOVE '300-200-PROCESSA-FONTE' TO PARAGRAFO. */
            _.Move("300-200-PROCESSA-FONTE", FILLER_0.WABEND.PARAGRAFO);

            /*" -505- IF V1HISTMEST-NUM-SINISTRO NOT EQUAL LD01-SINISTRO */

            if (V1HISTMEST_NUM_SINISTRO != FILLER_0.LD01.LD01_SINISTRO)
            {

                /*" -506- MOVE V1HISTMEST-NUM-SINISTRO TO LD01-SINISTRO */
                _.Move(V1HISTMEST_NUM_SINISTRO, FILLER_0.LD01.LD01_SINISTRO);

                /*" -508- PERFORM 400-100-SELECT-V1CLIENTE. */

                M_400_100_SELECT_V1CLIENTE_SECTION();
            }


            /*" -510- MOVE ZEROS TO W-ACUM-PENDENTE. */
            _.Move(0, FILLER_0.W_ACUM_PENDENTE);

            /*" -512- PERFORM 300-500-CALCULA-VLR-PENDENTE. */

            M_300_500_CALCULA_VLR_PENDENTE_SECTION();

            /*" -513- IF W-ACUM-PENDENTE NOT EQUAL ZERO */

            if (FILLER_0.W_ACUM_PENDENTE != 00)
            {

                /*" -516- COMPUTE W-LIDER = (W-ACUM-PENDENTE * V1HISTMEST-PCPARTIC) / 100 */
                FILLER_0.W_LIDER.Value = (FILLER_0.W_ACUM_PENDENTE * V1HISTMEST_PCPARTIC) / 100f;

                /*" -519- COMPUTE W-RESSEGURO = (W-LIDER * V1HISTMEST-PCTRES) / 100 */
                FILLER_0.W_RESSEGURO.Value = (FILLER_0.W_LIDER * V1HISTMEST_PCTRES) / 100f;

                /*" -521- COMPUTE W-COSSEGURO = (W-ACUM-PENDENTE - W-LIDER) */
                FILLER_0.W_COSSEGURO.Value = (FILLER_0.W_ACUM_PENDENTE - FILLER_0.W_LIDER);

                /*" -523- COMPUTE W-LIDER = W-LIDER - W-RESSEGURO */
                FILLER_0.W_LIDER.Value = FILLER_0.W_LIDER - FILLER_0.W_RESSEGURO;

                /*" -524- MOVE W-LIDER TO LD01-LIDER */
                _.Move(FILLER_0.W_LIDER, FILLER_0.LD01.LD01_LIDER);

                /*" -525- MOVE W-COSSEGURO TO LD01-COSSEGURO */
                _.Move(FILLER_0.W_COSSEGURO, FILLER_0.LD01.LD01_COSSEGURO);

                /*" -527- MOVE W-RESSEGURO TO LD01-RESSEGURO */
                _.Move(FILLER_0.W_RESSEGURO, FILLER_0.LD01.LD01_RESSEGURO);

                /*" -529- PERFORM 400-200-IMPRIME-DETALHE. */

                M_400_200_IMPRIME_DETALHE_SECTION();
            }


            /*" -529- PERFORM 100-200-FETCH-HISTMEST. */

            M_100_200_FETCH_HISTMEST_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_300_200_EXIT*/

        [StopWatch]
        /*" M-400-200-IMPRIME-DETALHE-SECTION */
        private void M_400_200_IMPRIME_DETALHE_SECTION()
        {
            /*" -540- MOVE '400-200-IMPRIME-DETALHE' TO PARAGRAFO. */
            _.Move("400-200-IMPRIME-DETALHE", FILLER_0.WABEND.PARAGRAFO);

            /*" -541- IF W-CONT-LIN GREATER 59 */

            if (FILLER_0.W_CONT_LIN > 59)
            {

                /*" -543- PERFORM 500-400-IMPRIME-CABECALHO. */

                M_500_400_IMPRIME_CABECALHO_SECTION();
            }


            /*" -544- ADD 1 TO W-ACC-FONTE. */
            FILLER_0.W_ACC_FONTE.Value = FILLER_0.W_ACC_FONTE + 1;

            /*" -545- ADD W-LIDER TO W-ACC-FONTE1. */
            FILLER_0.W_ACC_FONTE1.Value = FILLER_0.W_ACC_FONTE1 + FILLER_0.W_LIDER;

            /*" -546- ADD W-COSSEGURO TO W-ACC-FONTE2. */
            FILLER_0.W_ACC_FONTE2.Value = FILLER_0.W_ACC_FONTE2 + FILLER_0.W_COSSEGURO;

            /*" -548- ADD W-RESSEGURO TO W-ACC-FONTE3. */
            FILLER_0.W_ACC_FONTE3.Value = FILLER_0.W_ACC_FONTE3 + FILLER_0.W_RESSEGURO;

            /*" -550- WRITE REG-SI0103M1 FROM LD01 AFTER 2. */
            _.Move(FILLER_0.LD01.GetMoveValues(), REG_SI0103M1);

            SI0103M1.Write(REG_SI0103M1.GetMoveValues().ToString());

            /*" -551- ADD 2 TO W-CONT-LIN. */
            FILLER_0.W_CONT_LIN.Value = FILLER_0.W_CONT_LIN + 2;

            /*" -551- ADD 1 TO W-IMPRESSOS. */
            FILLER_0.W_IMPRESSOS.Value = FILLER_0.W_IMPRESSOS + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_400_200_EXIT*/

        [StopWatch]
        /*" M-200-300-QUEBRA-RAMO-SECTION */
        private void M_200_300_QUEBRA_RAMO_SECTION()
        {
            /*" -561- MOVE '200-300-QUEBRA-RAMO' TO PARAGRAFO. */
            _.Move("200-300-QUEBRA-RAMO", FILLER_0.WABEND.PARAGRAFO);

            /*" -562- ADD W-ACC-RAMO TO W-ACC-GERAL. */
            FILLER_0.W_ACC_GERAL.Value = FILLER_0.W_ACC_GERAL + FILLER_0.W_ACC_RAMO;

            /*" -563- ADD W-ACC-RAMO1 TO W-ACC-GERAL1. */
            FILLER_0.W_ACC_GERAL1.Value = FILLER_0.W_ACC_GERAL1 + FILLER_0.W_ACC_RAMO1;

            /*" -564- ADD W-ACC-RAMO2 TO W-ACC-GERAL2. */
            FILLER_0.W_ACC_GERAL2.Value = FILLER_0.W_ACC_GERAL2 + FILLER_0.W_ACC_RAMO2;

            /*" -565- ADD W-ACC-RAMO3 TO W-ACC-GERAL3. */
            FILLER_0.W_ACC_GERAL3.Value = FILLER_0.W_ACC_GERAL3 + FILLER_0.W_ACC_RAMO3;

            /*" -566- MOVE W-ACC-RAMO TO LT02-ACC-RAMO. */
            _.Move(FILLER_0.W_ACC_RAMO, FILLER_0.LT02.LT02_ACC_RAMO);

            /*" -567- MOVE W-ACC-RAMO1 TO LT02-ACC-RAMO1. */
            _.Move(FILLER_0.W_ACC_RAMO1, FILLER_0.LT02.LT02_ACC_RAMO1);

            /*" -568- MOVE W-ACC-RAMO2 TO LT02-ACC-RAMO2. */
            _.Move(FILLER_0.W_ACC_RAMO2, FILLER_0.LT02.LT02_ACC_RAMO2);

            /*" -569- MOVE W-ACC-RAMO3 TO LT02-ACC-RAMO3. */
            _.Move(FILLER_0.W_ACC_RAMO3, FILLER_0.LT02.LT02_ACC_RAMO3);

            /*" -570- MOVE 00 TO W-ACC-RAMO. */
            _.Move(00, FILLER_0.W_ACC_RAMO);

            /*" -571- MOVE 00 TO W-ACC-RAMO1. */
            _.Move(00, FILLER_0.W_ACC_RAMO1);

            /*" -572- MOVE 00 TO W-ACC-RAMO2. */
            _.Move(00, FILLER_0.W_ACC_RAMO2);

            /*" -573- MOVE 00 TO W-ACC-RAMO3. */
            _.Move(00, FILLER_0.W_ACC_RAMO3);

            /*" -575- MOVE 70 TO W-CONT-LIN. */
            _.Move(70, FILLER_0.W_CONT_LIN);

            /*" -575- WRITE REG-SI0103M1 FROM LT02 AFTER 3. */
            _.Move(FILLER_0.LT02.GetMoveValues(), REG_SI0103M1);

            SI0103M1.Write(REG_SI0103M1.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_200_300_EXIT*/

        [StopWatch]
        /*" M-300-300-QUEBRA-FONTE-SECTION */
        private void M_300_300_QUEBRA_FONTE_SECTION()
        {
            /*" -585- MOVE '300-300-QUEBRA-FONTE' TO PARAGRAFO. */
            _.Move("300-300-QUEBRA-FONTE", FILLER_0.WABEND.PARAGRAFO);

            /*" -586- ADD W-ACC-FONTE TO W-ACC-RAMO. */
            FILLER_0.W_ACC_RAMO.Value = FILLER_0.W_ACC_RAMO + FILLER_0.W_ACC_FONTE;

            /*" -587- ADD W-ACC-FONTE1 TO W-ACC-RAMO1. */
            FILLER_0.W_ACC_RAMO1.Value = FILLER_0.W_ACC_RAMO1 + FILLER_0.W_ACC_FONTE1;

            /*" -588- ADD W-ACC-FONTE2 TO W-ACC-RAMO2. */
            FILLER_0.W_ACC_RAMO2.Value = FILLER_0.W_ACC_RAMO2 + FILLER_0.W_ACC_FONTE2;

            /*" -589- ADD W-ACC-FONTE3 TO W-ACC-RAMO3. */
            FILLER_0.W_ACC_RAMO3.Value = FILLER_0.W_ACC_RAMO3 + FILLER_0.W_ACC_FONTE3;

            /*" -590- MOVE W-ACC-FONTE TO LT01-ACC-FONTE. */
            _.Move(FILLER_0.W_ACC_FONTE, FILLER_0.LT01.LT01_ACC_FONTE);

            /*" -591- MOVE W-ACC-FONTE1 TO LT01-ACC-FONTE1. */
            _.Move(FILLER_0.W_ACC_FONTE1, FILLER_0.LT01.LT01_ACC_FONTE1);

            /*" -592- MOVE W-ACC-FONTE2 TO LT01-ACC-FONTE2. */
            _.Move(FILLER_0.W_ACC_FONTE2, FILLER_0.LT01.LT01_ACC_FONTE2);

            /*" -593- MOVE W-ACC-FONTE3 TO LT01-ACC-FONTE3. */
            _.Move(FILLER_0.W_ACC_FONTE3, FILLER_0.LT01.LT01_ACC_FONTE3);

            /*" -594- MOVE 00 TO W-ACC-FONTE. */
            _.Move(00, FILLER_0.W_ACC_FONTE);

            /*" -595- MOVE 00 TO W-ACC-FONTE1. */
            _.Move(00, FILLER_0.W_ACC_FONTE1);

            /*" -596- MOVE 00 TO W-ACC-FONTE2. */
            _.Move(00, FILLER_0.W_ACC_FONTE2);

            /*" -598- MOVE 00 TO W-ACC-FONTE3. */
            _.Move(00, FILLER_0.W_ACC_FONTE3);

            /*" -600- WRITE REG-SI0103M1 FROM LT01 AFTER 3. */
            _.Move(FILLER_0.LT01.GetMoveValues(), REG_SI0103M1);

            SI0103M1.Write(REG_SI0103M1.GetMoveValues().ToString());

            /*" -601- IF V1HISTMEST-RAMO EQUAL LC05-RAMO */

            if (V1HISTMEST_RAMO == FILLER_0.LC05.LC05_RAMO)
            {

                /*" -601- MOVE 70 TO W-CONT-LIN. */
                _.Move(70, FILLER_0.W_CONT_LIN);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_300_300_EXIT*/

        [StopWatch]
        /*" M-100-400-QUEBRA-GERAL-SECTION */
        private void M_100_400_QUEBRA_GERAL_SECTION()
        {
            /*" -611- MOVE '100-400-QUEBRA-GERAL' TO PARAGRAFO. */
            _.Move("100-400-QUEBRA-GERAL", FILLER_0.WABEND.PARAGRAFO);

            /*" -612- MOVE 'TOTAL GERAL' TO LC06-NOMEFTE LC05-NOMERAMO. */
            _.Move("TOTAL GERAL", FILLER_0.LC06.LC06_NOMEFTE, FILLER_0.LC05.LC05_NOMERAMO);

            /*" -614- MOVE 999 TO LC06-FONTE LC05-RAMO. */
            _.Move(999, FILLER_0.LC06.LC06_FONTE, FILLER_0.LC05.LC05_RAMO);

            /*" -616- PERFORM 500-400-IMPRIME-CABECALHO. */

            M_500_400_IMPRIME_CABECALHO_SECTION();

            /*" -617- MOVE W-ACC-GERAL TO LT03-ACC-GERAL. */
            _.Move(FILLER_0.W_ACC_GERAL, FILLER_0.LT03.LT03_ACC_GERAL);

            /*" -618- MOVE W-ACC-GERAL1 TO LT03-ACC-GERAL1. */
            _.Move(FILLER_0.W_ACC_GERAL1, FILLER_0.LT03.LT03_ACC_GERAL1);

            /*" -619- MOVE W-ACC-GERAL2 TO LT03-ACC-GERAL2. */
            _.Move(FILLER_0.W_ACC_GERAL2, FILLER_0.LT03.LT03_ACC_GERAL2);

            /*" -621- MOVE W-ACC-GERAL3 TO LT03-ACC-GERAL3. */
            _.Move(FILLER_0.W_ACC_GERAL3, FILLER_0.LT03.LT03_ACC_GERAL3);

            /*" -623- WRITE REG-SI0103M1 FROM LT03 AFTER 6. */
            _.Move(FILLER_0.LT03.GetMoveValues(), REG_SI0103M1);

            SI0103M1.Write(REG_SI0103M1.GetMoveValues().ToString());

            /*" -624- MOVE 00 TO W-CONT-PAG. */
            _.Move(00, FILLER_0.W_CONT_PAG);

            /*" -626- MOVE 70 TO W-CONT-LIN. */
            _.Move(70, FILLER_0.W_CONT_LIN);

            /*" -627- MOVE 00 TO W-ACC-GERAL. */
            _.Move(00, FILLER_0.W_ACC_GERAL);

            /*" -628- MOVE 00 TO W-ACC-GERAL1. */
            _.Move(00, FILLER_0.W_ACC_GERAL1);

            /*" -629- MOVE 00 TO W-ACC-GERAL2. */
            _.Move(00, FILLER_0.W_ACC_GERAL2);

            /*" -629- MOVE 00 TO W-ACC-GERAL3. */
            _.Move(00, FILLER_0.W_ACC_GERAL3);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_400_EXIT*/

        [StopWatch]
        /*" M-300-500-CALCULA-VLR-PENDENTE-SECTION */
        private void M_300_500_CALCULA_VLR_PENDENTE_SECTION()
        {
            /*" -638- MOVE '300-500-CALCULA-VLR-PENDENTE' TO PARAGRAFO. */
            _.Move("300-500-CALCULA-VLR-PENDENTE", FILLER_0.WABEND.PARAGRAFO);

            /*" -643- MOVE '001' TO WNR-EXEC-SQL. */
            _.Move("001", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -645- INITIALIZE SI1001S-PARAMETROS. */
            _.Initialize(
                LBSI1001.SI1001S_PARAMETROS
            );

            /*" -647- MOVE V1HISTMEST-NUM-SINISTRO TO SI1001S-NUM-APOL-SINISTRO */
            _.Move(V1HISTMEST_NUM_SINISTRO, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO);

            /*" -649- CALL 'SI1001S' USING SI1001S-PARAMETROS */
            _.Call("SI1001S", LBSI1001.SI1001S_PARAMETROS);

            /*" -650- IF SI1001S-ERRO-MENSAGEM NOT EQUAL SPACES */

            if (!LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM.IsEmpty())
            {

                /*" -652- DISPLAY 'PROBLEMA CALL SI1001S ' ' ' SI1001S-NUM-APOL-SINISTRO */

                $"PROBLEMA CALL SI1001S  {LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO}"
                .Display();

                /*" -653- DISPLAY 'SQLCODE = ' SI1001S-ERRO-SQLCODE */
                _.Display($"SQLCODE = {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_SQLCODE}");

                /*" -654- DISPLAY SI1001S-ERRO-MENSAGEM */
                _.Display(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM);

                /*" -655- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -656- ELSE */
            }
            else
            {


                /*" -659- MOVE SI1001S-VALOR-CALCULADO TO V1HISTSINI-VAL-OPERACAO. */
                _.Move(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_VALOR_CALCULADO, V1HISTSINI_VAL_OPERACAO);
            }


            /*" -659- MOVE V1HISTSINI-VAL-OPERACAO TO W-ACUM-PENDENTE. */
            _.Move(V1HISTSINI_VAL_OPERACAO, FILLER_0.W_ACUM_PENDENTE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_300_500_EXIT*/

        [StopWatch]
        /*" M-400-100-SELECT-V1CLIENTE-SECTION */
        private void M_400_100_SELECT_V1CLIENTE_SECTION()
        {
            /*" -670- IF V1HISTMEST-IDTPSEGU EQUAL '8' OR V1HISTMEST-IDTPSEGU EQUAL '9' */

            if (V1HISTMEST_IDTPSEGU == "8" || V1HISTMEST_IDTPSEGU == "9")
            {

                /*" -672- MOVE '1' TO V1HISTMEST-IDTPSEGU. */
                _.Move("1", V1HISTMEST_IDTPSEGU);
            }


            /*" -678- IF V1HISTMEST-RAMO EQUAL V1PARAMRAMO-RAMO-VG OR V1HISTMEST-RAMO EQUAL V1PARAMRAMO-RAMO-AP OR V1HISTMEST-RAMO EQUAL V1PARAMRAMO-RAMO-VGAPC OR V1HISTMEST-RAMO EQUAL V1PARAMRAMO-RAMO-SAUDE OR V1HISTMEST-RAMO EQUAL V1PARAMRAMO-RAMO-EDUCACAO */

            if (V1HISTMEST_RAMO == V1PARAMRAMO_RAMO_VG || V1HISTMEST_RAMO == V1PARAMRAMO_RAMO_AP || V1HISTMEST_RAMO == V1PARAMRAMO_RAMO_VGAPC || V1HISTMEST_RAMO == V1PARAMRAMO_RAMO_SAUDE || V1HISTMEST_RAMO == V1PARAMRAMO_RAMO_EDUCACAO)
            {

                /*" -681- IF V1HISTMEST-RAMO NOT EQUAL V1PARAMRAMO-RAMO-AP OR V1HISTMEST-NRCERTIF NOT EQUAL ZEROES OR V1HISTMEST-IDTPSEGU NOT EQUAL SPACES */

                if (V1HISTMEST_RAMO != V1PARAMRAMO_RAMO_AP || V1HISTMEST_NRCERTIF != 00 || !V1HISTMEST_IDTPSEGU.IsEmpty())
                {

                    /*" -682- PERFORM 500-100-SELECT-V1CLIENTE1 */

                    M_500_100_SELECT_V1CLIENTE1_SECTION();

                    /*" -683- ELSE */
                }
                else
                {


                    /*" -684- PERFORM 500-200-SELECT-V1CLIENTE2 */

                    M_500_200_SELECT_V1CLIENTE2_SECTION();

                    /*" -686- ELSE */
                }

            }
            else
            {


                /*" -687- IF V1HISTMEST-RAMO NOT EQUAL 32 */

                if (V1HISTMEST_RAMO != 32)
                {

                    /*" -688- PERFORM 500-200-SELECT-V1CLIENTE2 */

                    M_500_200_SELECT_V1CLIENTE2_SECTION();

                    /*" -689- ELSE */
                }
                else
                {


                    /*" -689- PERFORM 500-300-SELECT-V1CLIENTE3. */

                    M_500_300_SELECT_V1CLIENTE3_SECTION();
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_400_100_EXIT*/

        [StopWatch]
        /*" M-500-100-SELECT-V1CLIENTE1-SECTION */
        private void M_500_100_SELECT_V1CLIENTE1_SECTION()
        {
            /*" -697- MOVE '500-100-SELECT-V1CLIENTE1' TO PARAGRAFO */
            _.Move("500-100-SELECT-V1CLIENTE1", FILLER_0.WABEND.PARAGRAFO);

            /*" -700- MOVE '004' TO WNR-EXEC-SQL */
            _.Move("004", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -714- PERFORM M_500_100_SELECT_V1CLIENTE1_DB_SELECT_1 */

            M_500_100_SELECT_V1CLIENTE1_DB_SELECT_1();

            /*" -720- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -721- DISPLAY W-MENSAGEM7 */
                _.Display(FILLER_0.FILLER_87.W_MENSAGEM7);

                /*" -722- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -723- ELSE */
            }
            else
            {


                /*" -723- MOVE V1CLIENTE-NOME-RAZAO TO LD01-NOME. */
                _.Move(V1CLIENTE_NOME_RAZAO, FILLER_0.LD01.LD01_NOME);
            }


        }

        [StopWatch]
        /*" M-500-100-SELECT-V1CLIENTE1-DB-SELECT-1 */
        public void M_500_100_SELECT_V1CLIENTE1_DB_SELECT_1()
        {
            /*" -714- EXEC SQL SELECT NOME_RAZAO INTO :V1CLIENTE-NOME-RAZAO FROM SEGUROS.V1CLIENTE WHERE COD_CLIENTE = ( SELECT COD_CLIENTE FROM SEGUROS.V1SEGURAVG WHERE NUM_APOLICE = :V1HISTMEST-NUM-APOLICE AND COD_SUBGRUPO = :V1HISTMEST-CODSUBES AND NUM_CERTIFICADO = :V1HISTMEST-NRCERTIF AND TIPO_SEGURADO = :V1HISTMEST-IDTPSEGU ) END-EXEC */

            var m_500_100_SELECT_V1CLIENTE1_DB_SELECT_1_Query1 = new M_500_100_SELECT_V1CLIENTE1_DB_SELECT_1_Query1()
            {
                V1HISTMEST_NUM_APOLICE = V1HISTMEST_NUM_APOLICE.ToString(),
                V1HISTMEST_CODSUBES = V1HISTMEST_CODSUBES.ToString(),
                V1HISTMEST_NRCERTIF = V1HISTMEST_NRCERTIF.ToString(),
                V1HISTMEST_IDTPSEGU = V1HISTMEST_IDTPSEGU.ToString(),
            };

            var executed_1 = M_500_100_SELECT_V1CLIENTE1_DB_SELECT_1_Query1.Execute(m_500_100_SELECT_V1CLIENTE1_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1CLIENTE_NOME_RAZAO, V1CLIENTE_NOME_RAZAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_500_100_EXIT*/

        [StopWatch]
        /*" M-500-200-SELECT-V1CLIENTE2-SECTION */
        private void M_500_200_SELECT_V1CLIENTE2_SECTION()
        {
            /*" -732- MOVE '500-200-SELECT-V1CLIENTE2' TO PARAGRAFO */
            _.Move("500-200-SELECT-V1CLIENTE2", FILLER_0.WABEND.PARAGRAFO);

            /*" -735- MOVE '005' TO WNR-EXEC-SQL */
            _.Move("005", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -746- PERFORM M_500_200_SELECT_V1CLIENTE2_DB_SELECT_1 */

            M_500_200_SELECT_V1CLIENTE2_DB_SELECT_1();

            /*" -752- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -753- DISPLAY W-MENSAGEM7 */
                _.Display(FILLER_0.FILLER_87.W_MENSAGEM7);

                /*" -754- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -755- ELSE */
            }
            else
            {


                /*" -755- MOVE V1CLIENTE-NOME-RAZAO TO LD01-NOME. */
                _.Move(V1CLIENTE_NOME_RAZAO, FILLER_0.LD01.LD01_NOME);
            }


        }

        [StopWatch]
        /*" M-500-200-SELECT-V1CLIENTE2-DB-SELECT-1 */
        public void M_500_200_SELECT_V1CLIENTE2_DB_SELECT_1()
        {
            /*" -746- EXEC SQL SELECT NOME_RAZAO INTO :V1CLIENTE-NOME-RAZAO FROM SEGUROS.V1CLIENTE WHERE COD_CLIENTE = ( SELECT COD_CLIENTE FROM SEGUROS.V1SINI_ITEM WHERE NUM_APOL_SINISTRO = :V1HISTMEST-NUM-SINISTRO ) END-EXEC */

            var m_500_200_SELECT_V1CLIENTE2_DB_SELECT_1_Query1 = new M_500_200_SELECT_V1CLIENTE2_DB_SELECT_1_Query1()
            {
                V1HISTMEST_NUM_SINISTRO = V1HISTMEST_NUM_SINISTRO.ToString(),
            };

            var executed_1 = M_500_200_SELECT_V1CLIENTE2_DB_SELECT_1_Query1.Execute(m_500_200_SELECT_V1CLIENTE2_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1CLIENTE_NOME_RAZAO, V1CLIENTE_NOME_RAZAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_500_200_EXIT*/

        [StopWatch]
        /*" M-500-300-SELECT-V1CLIENTE3-SECTION */
        private void M_500_300_SELECT_V1CLIENTE3_SECTION()
        {
            /*" -764- MOVE '500-300-SELECT-V1CLIENTE3' TO PARAGRAFO */
            _.Move("500-300-SELECT-V1CLIENTE3", FILLER_0.WABEND.PARAGRAFO);

            /*" -767- MOVE '006' TO WNR-EXEC-SQL */
            _.Move("006", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -777- PERFORM M_500_300_SELECT_V1CLIENTE3_DB_SELECT_1 */

            M_500_300_SELECT_V1CLIENTE3_DB_SELECT_1();

            /*" -783- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -784- DISPLAY W-MENSAGEM7 */
                _.Display(FILLER_0.FILLER_87.W_MENSAGEM7);

                /*" -785- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -786- ELSE */
            }
            else
            {


                /*" -786- MOVE V1CLIENTE-NOME-RAZAO TO LD01-NOME. */
                _.Move(V1CLIENTE_NOME_RAZAO, FILLER_0.LD01.LD01_NOME);
            }


        }

        [StopWatch]
        /*" M-500-300-SELECT-V1CLIENTE3-DB-SELECT-1 */
        public void M_500_300_SELECT_V1CLIENTE3_DB_SELECT_1()
        {
            /*" -777- EXEC SQL SELECT NOME_RAZAO INTO :V1CLIENTE-NOME-RAZAO FROM SEGUROS.V1CLIENTE WHERE COD_CLIENTE = ( SELECT CODCLIEN FROM SEGUROS.V1APOLICE WHERE NUM_APOLICE = :V1HISTMEST-NUM-APOLICE ) END-EXEC */

            var m_500_300_SELECT_V1CLIENTE3_DB_SELECT_1_Query1 = new M_500_300_SELECT_V1CLIENTE3_DB_SELECT_1_Query1()
            {
                V1HISTMEST_NUM_APOLICE = V1HISTMEST_NUM_APOLICE.ToString(),
            };

            var executed_1 = M_500_300_SELECT_V1CLIENTE3_DB_SELECT_1_Query1.Execute(m_500_300_SELECT_V1CLIENTE3_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1CLIENTE_NOME_RAZAO, V1CLIENTE_NOME_RAZAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_500_300_EXIT*/

        [StopWatch]
        /*" M-300-100-SELECT-V1FONTE-SECTION */
        private void M_300_100_SELECT_V1FONTE_SECTION()
        {
            /*" -795- MOVE '300-100-SELECT-V1FONTE' TO PARAGRAFO. */
            _.Move("300-100-SELECT-V1FONTE", FILLER_0.WABEND.PARAGRAFO);

            /*" -798- MOVE '007' TO WNR-EXEC-SQL. */
            _.Move("007", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -803- PERFORM M_300_100_SELECT_V1FONTE_DB_SELECT_1 */

            M_300_100_SELECT_V1FONTE_DB_SELECT_1();

            /*" -806- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -807- DISPLAY W-MENSAGEM6 */
                _.Display(FILLER_0.FILLER_87.W_MENSAGEM6);

                /*" -809- DISPLAY 'FONTE = ' V1HISTMEST-FONTE */
                _.Display($"FONTE = {V1HISTMEST_FONTE}");

                /*" -810- MOVE SPACES TO LC06-NOMEFTE */
                _.Move("", FILLER_0.LC06.LC06_NOMEFTE);

                /*" -811- ELSE */
            }
            else
            {


                /*" -811- MOVE V1FONTE-NOMEFTE TO LC06-NOMEFTE. */
                _.Move(V1FONTE_NOMEFTE, FILLER_0.LC06.LC06_NOMEFTE);
            }


        }

        [StopWatch]
        /*" M-300-100-SELECT-V1FONTE-DB-SELECT-1 */
        public void M_300_100_SELECT_V1FONTE_DB_SELECT_1()
        {
            /*" -803- EXEC SQL SELECT NOMEFTE INTO :V1FONTE-NOMEFTE FROM SEGUROS.V1FONTE WHERE FONTE = :V1HISTMEST-FONTE END-EXEC. */

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
        /*" M-500-400-IMPRIME-CABECALHO-SECTION */
        private void M_500_400_IMPRIME_CABECALHO_SECTION()
        {
            /*" -821- MOVE '500-400-IMPRIME-CABECALHO' TO PARAGRAFO. */
            _.Move("500-400-IMPRIME-CABECALHO", FILLER_0.WABEND.PARAGRAFO);

            /*" -823- ADD 1 TO W-CONT-PAG. */
            FILLER_0.W_CONT_PAG.Value = FILLER_0.W_CONT_PAG + 1;

            /*" -825- MOVE W-CONT-PAG TO LC01-PAGINA. */
            _.Move(FILLER_0.W_CONT_PAG, FILLER_0.LC01.LC01_PAGINA);

            /*" -826- WRITE REG-SI0103M1 FROM LC01 AFTER NEW-PAGE. */
            _.Move(FILLER_0.LC01.GetMoveValues(), REG_SI0103M1);

            SI0103M1.Write(REG_SI0103M1.GetMoveValues().ToString());

            /*" -827- WRITE REG-SI0103M1 FROM LC02 AFTER 1. */
            _.Move(FILLER_0.LC02.GetMoveValues(), REG_SI0103M1);

            SI0103M1.Write(REG_SI0103M1.GetMoveValues().ToString());

            /*" -828- WRITE REG-SI0103M1 FROM LC03 AFTER 1. */
            _.Move(FILLER_0.LC03.GetMoveValues(), REG_SI0103M1);

            SI0103M1.Write(REG_SI0103M1.GetMoveValues().ToString());

            /*" -830- WRITE REG-SI0103M1 FROM LC04 AFTER 1. */
            _.Move(FILLER_0.LC04.GetMoveValues(), REG_SI0103M1);

            SI0103M1.Write(REG_SI0103M1.GetMoveValues().ToString());

            /*" -831- IF V1RELATORIOS-APOLICE1 EQUAL ZEROES */

            if (V1RELATORIOS_APOLICE1 == 00)
            {

                /*" -832- WRITE REG-SI0103M1 FROM LC05 AFTER 2 */
                _.Move(FILLER_0.LC05.GetMoveValues(), REG_SI0103M1);

                SI0103M1.Write(REG_SI0103M1.GetMoveValues().ToString());

                /*" -833- ELSE */
            }
            else
            {


                /*" -834- MOVE V1RELATORIOS-APOLICE1 TO LC09-APOLICE */
                _.Move(V1RELATORIOS_APOLICE1, FILLER_0.LC09.LC09_APOLICE);

                /*" -836- MOVE V1HISTMEST-NOME TO LC09-NOME-APOLICE */
                _.Move(V1HISTMEST_NOME, FILLER_0.LC09.LC09_NOME_APOLICE);

                /*" -837- WRITE REG-SI0103M1 FROM LC09 AFTER 1 */
                _.Move(FILLER_0.LC09.GetMoveValues(), REG_SI0103M1);

                SI0103M1.Write(REG_SI0103M1.GetMoveValues().ToString());

                /*" -839- WRITE REG-SI0103M1 FROM LC05 AFTER 1. */
                _.Move(FILLER_0.LC05.GetMoveValues(), REG_SI0103M1);

                SI0103M1.Write(REG_SI0103M1.GetMoveValues().ToString());
            }


            /*" -840- WRITE REG-SI0103M1 FROM LC06 AFTER 1. */
            _.Move(FILLER_0.LC06.GetMoveValues(), REG_SI0103M1);

            SI0103M1.Write(REG_SI0103M1.GetMoveValues().ToString());

            /*" -841- WRITE REG-SI0103M1 FROM LC07 AFTER 1. */
            _.Move(FILLER_0.LC07.GetMoveValues(), REG_SI0103M1);

            SI0103M1.Write(REG_SI0103M1.GetMoveValues().ToString());

            /*" -842- WRITE REG-SI0103M1 FROM LC08 AFTER 1. */
            _.Move(FILLER_0.LC08.GetMoveValues(), REG_SI0103M1);

            SI0103M1.Write(REG_SI0103M1.GetMoveValues().ToString());

            /*" -844- WRITE REG-SI0103M1 FROM LC07 AFTER 1. */
            _.Move(FILLER_0.LC07.GetMoveValues(), REG_SI0103M1);

            SI0103M1.Write(REG_SI0103M1.GetMoveValues().ToString());

            /*" -844- MOVE 10 TO W-CONT-LIN. */
            _.Move(10, FILLER_0.W_CONT_LIN);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_500_400_EXIT*/

        [StopWatch]
        /*" M-000-100-SELECT-V1EMPRESA-SECTION */
        private void M_000_100_SELECT_V1EMPRESA_SECTION()
        {
            /*" -853- MOVE '000-100-SELECT-V1EMPRESA' TO PARAGRAFO. */
            _.Move("000-100-SELECT-V1EMPRESA", FILLER_0.WABEND.PARAGRAFO);

            /*" -856- MOVE '008' TO WNR-EXEC-SQL. */
            _.Move("008", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -861- PERFORM M_000_100_SELECT_V1EMPRESA_DB_SELECT_1 */

            M_000_100_SELECT_V1EMPRESA_DB_SELECT_1();

            /*" -866- MOVE V1EMPRESA-NOME-EMPRESA TO LK-TITULO. */
            _.Move(V1EMPRESA_NOME_EMPRESA, LK_LINK.LK_TITULO);

            /*" -867- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -868- DISPLAY W-MENSAGEM2 */
                _.Display(FILLER_0.FILLER_87.W_MENSAGEM2);

                /*" -868- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-000-100-SELECT-V1EMPRESA-DB-SELECT-1 */
        public void M_000_100_SELECT_V1EMPRESA_DB_SELECT_1()
        {
            /*" -861- EXEC SQL SELECT NOME_EMPRESA INTO :V1EMPRESA-NOME-EMPRESA FROM SEGUROS.V1EMPRESA WHERE COD_EMPRESA = 0 END-EXEC. */

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
            /*" -877- MOVE '000-200-SELECT-V1SISTEMA' TO PARAGRAFO. */
            _.Move("000-200-SELECT-V1SISTEMA", FILLER_0.WABEND.PARAGRAFO);

            /*" -880- MOVE '009' TO WNR-EXEC-SQL. */
            _.Move("009", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -885- PERFORM M_000_200_SELECT_V1SISTEMA_DB_SELECT_1 */

            M_000_200_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -888- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -889- DISPLAY W-MENSAGEM3 */
                _.Display(FILLER_0.FILLER_87.W_MENSAGEM3);

                /*" -889- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-000-200-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void M_000_200_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -885- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :V1SISTEMA-DTMOVABE, :V1SISTEMA-DTCURRENT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'SI' END-EXEC. */

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
            /*" -898- MOVE '000-300-DECLARE-RELATORIOS' TO PARAGRAFO. */
            _.Move("000-300-DECLARE-RELATORIOS", FILLER_0.WABEND.PARAGRAFO);

            /*" -901- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -917- PERFORM M_000_300_DECLARE_RELATORIOS_DB_DECLARE_1 */

            M_000_300_DECLARE_RELATORIOS_DB_DECLARE_1();

            /*" -920- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -922- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -922- PERFORM M_000_300_DECLARE_RELATORIOS_DB_OPEN_1 */

            M_000_300_DECLARE_RELATORIOS_DB_OPEN_1();

            /*" -924- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -924- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-000-300-DECLARE-RELATORIOS-DB-DECLARE-1 */
        public void M_000_300_DECLARE_RELATORIOS_DB_DECLARE_1()
        {
            /*" -917- EXEC SQL DECLARE RELATORIOS CURSOR FOR SELECT CODUSU, PERI_INICIAL, PERI_FINAL, NUM_APOLICE, RAMO FROM SEGUROS.V1RELATORIOS WHERE IDSISTEM = 'SI' AND CODRELAT = 'SI0103B' AND DATA_SOLICITACAO = :V1SISTEMA-DTMOVABE END-EXEC. */
            RELATORIOS = new SI0103B_RELATORIOS(true);
            string GetQuery_RELATORIOS()
            {
                var query = @$"SELECT CODUSU
							, 
							PERI_INICIAL
							, 
							PERI_FINAL
							, 
							NUM_APOLICE
							, 
							RAMO 
							FROM SEGUROS.V1RELATORIOS 
							WHERE IDSISTEM = 'SI' AND 
							CODRELAT = 'SI0103B' AND 
							DATA_SOLICITACAO = '{V1SISTEMA_DTMOVABE}'";

                return query;
            }
            RELATORIOS.GetQueryEvent += GetQuery_RELATORIOS;

        }

        [StopWatch]
        /*" M-000-300-DECLARE-RELATORIOS-DB-OPEN-1 */
        public void M_000_300_DECLARE_RELATORIOS_DB_OPEN_1()
        {
            /*" -922- EXEC SQL OPEN RELATORIOS END-EXEC. */

            RELATORIOS.Open();

        }

        [StopWatch]
        /*" M-100-100-DECLARE-HISTMEST-DB-DECLARE-1 */
        public void M_100_100_DECLARE_HISTMEST_DB_DECLARE_1()
        {
            /*" -1088- EXEC SQL DECLARE HISTMEST CURSOR FOR SELECT M.NUM_APOLICE, M.NUM_APOL_SINISTRO, M.CODSUBES, M.NRCERTIF, M.IDTPSEGU, M.PCPARTIC, M.DATORR, M.PCTRES, M.FONTE, M.RAMO, M.COD_MOEDA_SINI, H.DTMOVTO FROM SEGUROS.V1HISTSINI H, SEGUROS.V1MESTSINI M WHERE M.NUM_APOLICE BETWEEN :V1RELATORIOS-APOLICE1 AND :V1RELATORIOS-APOLICE2 AND M.RAMO BETWEEN :V1RELATORIOS-RAMO1 AND :V1RELATORIOS-RAMO2 AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND H.OPERACAO = 101 AND H.DTMOVTO BETWEEN :V1RELATORIOS-DATA1 AND :V1RELATORIOS-DATA2 ORDER BY RAMO, FONTE, NUM_APOL_SINISTRO END-EXEC. */
            HISTMEST = new SI0103B_HISTMEST(true);
            string GetQuery_HISTMEST()
            {
                var query = @$"SELECT M.NUM_APOLICE
							, 
							M.NUM_APOL_SINISTRO
							, 
							M.CODSUBES
							, 
							M.NRCERTIF
							, 
							M.IDTPSEGU
							, 
							M.PCPARTIC
							, 
							M.DATORR
							, 
							M.PCTRES
							, 
							M.FONTE
							, 
							M.RAMO
							, 
							M.COD_MOEDA_SINI
							, 
							H.DTMOVTO 
							FROM SEGUROS.V1HISTSINI H
							, 
							SEGUROS.V1MESTSINI M 
							WHERE M.NUM_APOLICE BETWEEN 
							'{V1RELATORIOS_APOLICE1}' 
							AND '{V1RELATORIOS_APOLICE2}' 
							AND M.RAMO BETWEEN 
							'{V1RELATORIOS_RAMO1}' 
							AND '{V1RELATORIOS_RAMO2}' 
							AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND H.OPERACAO = 101 
							AND H.DTMOVTO BETWEEN 
							'{V1RELATORIOS_DATA1}' 
							AND '{V1RELATORIOS_DATA2}' 
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
            /*" -933- MOVE '000-400-FETCH-RELATORIOS' TO PARAGRAFO. */
            _.Move("000-400-FETCH-RELATORIOS", FILLER_0.WABEND.PARAGRAFO);

            /*" -935- MOVE '011' TO WNR-EXEC-SQL. */
            _.Move("011", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -942- PERFORM M_000_400_FETCH_RELATORIOS_DB_FETCH_1 */

            M_000_400_FETCH_RELATORIOS_DB_FETCH_1();

            /*" -946- IF (SQLCODE NOT EQUAL 100) AND (SQLCODE NOT EQUAL ZERO) */

            if ((DB.SQLCODE != 100) && (DB.SQLCODE != 00))
            {

                /*" -948- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -949- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -950- MOVE 'SIM' TO W-FIM-RELATORIOS */
                _.Move("SIM", FILLER_0.W_FIM_RELATORIOS);

                /*" -950- PERFORM M_000_400_FETCH_RELATORIOS_DB_CLOSE_1 */

                M_000_400_FETCH_RELATORIOS_DB_CLOSE_1();

                /*" -952- IF SQLCODE NOT EQUAL ZERO */

                if (DB.SQLCODE != 00)
                {

                    /*" -953- MOVE '000-400-CLOSE-RELATORIOS' TO PARAGRAFO */
                    _.Move("000-400-CLOSE-RELATORIOS", FILLER_0.WABEND.PARAGRAFO);

                    /*" -954- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -955- ELSE */
                }
                else
                {


                    /*" -957- GO TO 000-400-EXIT. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_400_EXIT*/ //GOTO
                    return;
                }

            }


            /*" -958- IF SQLCODE EQUAL ZERO */

            if (DB.SQLCODE == 00)
            {

                /*" -959- DISPLAY '/-********************************************-/' */
                _.Display($"/********************************************/");

                /*" -960- DISPLAY '/-*    PARAMETROS SOLICITADOS PELO USUARIO   *-/' */
                _.Display($"/*    PARAMETROS SOLICITADOS PELO USUARIO   */");

                /*" -961- DISPLAY '/-********************************************-/' */
                _.Display($"/********************************************/");

                /*" -962- DISPLAY 'USUARIO                = ' V1RELATORIOS-CODUSU */
                _.Display($"USUARIO                = {V1RELATORIOS_CODUSU}");

                /*" -963- DISPLAY 'PERIODO INICIAL        = ' V1RELATORIOS-DATA1 */
                _.Display($"PERIODO INICIAL        = {V1RELATORIOS_DATA1}");

                /*" -964- DISPLAY 'PERIODO FINAL          = ' V1RELATORIOS-DATA2 */
                _.Display($"PERIODO FINAL          = {V1RELATORIOS_DATA2}");

                /*" -965- DISPLAY 'APOLICE                = ' V1RELATORIOS-APOLICE1 */
                _.Display($"APOLICE                = {V1RELATORIOS_APOLICE1}");

                /*" -967- DISPLAY 'RAMO                   = ' V1RELATORIOS-RAMO1 . */
                _.Display($"RAMO                   = {V1RELATORIOS_RAMO1}");
            }


            /*" -968- MOVE V1RELATORIOS-DATA1 TO WDATA . */
            _.Move(V1RELATORIOS_DATA1, FILLER_0.WDATA);

            /*" -969- MOVE WDATA-DD TO WDATA-DD-CABEC . */
            _.Move(FILLER_0.WDATA.WDATA_DD, FILLER_0.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -970- MOVE WDATA-MM TO WDATA-MM-CABEC . */
            _.Move(FILLER_0.WDATA.WDATA_MM, FILLER_0.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -971- MOVE WDATA-AA TO WDATA-AA-CABEC . */
            _.Move(FILLER_0.WDATA.WDATA_AA, FILLER_0.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -972- MOVE WDATA-CABEC TO LC04-DATA1 . */
            _.Move(FILLER_0.WDATA_CABEC, FILLER_0.LC04.LC04_DATA1);

            /*" -973- MOVE V1RELATORIOS-DATA2 TO WDATA . */
            _.Move(V1RELATORIOS_DATA2, FILLER_0.WDATA);

            /*" -974- MOVE WDATA-DD TO WDATA-DD-CABEC . */
            _.Move(FILLER_0.WDATA.WDATA_DD, FILLER_0.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -975- MOVE WDATA-MM TO WDATA-MM-CABEC . */
            _.Move(FILLER_0.WDATA.WDATA_MM, FILLER_0.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -976- MOVE WDATA-AA TO WDATA-AA-CABEC . */
            _.Move(FILLER_0.WDATA.WDATA_AA, FILLER_0.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -978- MOVE WDATA-CABEC TO LC04-DATA2 . */
            _.Move(FILLER_0.WDATA_CABEC, FILLER_0.LC04.LC04_DATA2);

            /*" -979- IF V1RELATORIOS-APOLICE1 EQUAL ZEROES */

            if (V1RELATORIOS_APOLICE1 == 00)
            {

                /*" -980- MOVE 9999999999999 TO V1RELATORIOS-APOLICE2 */
                _.Move(9999999999999, V1RELATORIOS_APOLICE2);

                /*" -981- ELSE */
            }
            else
            {


                /*" -983- MOVE V1RELATORIOS-APOLICE1 TO V1RELATORIOS-APOLICE2. */
                _.Move(V1RELATORIOS_APOLICE1, V1RELATORIOS_APOLICE2);
            }


            /*" -984- IF V1RELATORIOS-RAMO1 EQUAL ZEROES */

            if (V1RELATORIOS_RAMO1 == 00)
            {

                /*" -985- MOVE 99 TO V1RELATORIOS-RAMO2 */
                _.Move(99, V1RELATORIOS_RAMO2);

                /*" -986- ELSE */
            }
            else
            {


                /*" -986- MOVE V1RELATORIOS-RAMO1 TO V1RELATORIOS-RAMO2. */
                _.Move(V1RELATORIOS_RAMO1, V1RELATORIOS_RAMO2);
            }


        }

        [StopWatch]
        /*" M-000-400-FETCH-RELATORIOS-DB-FETCH-1 */
        public void M_000_400_FETCH_RELATORIOS_DB_FETCH_1()
        {
            /*" -942- EXEC SQL FETCH RELATORIOS INTO :V1RELATORIOS-CODUSU, :V1RELATORIOS-DATA1, :V1RELATORIOS-DATA2, :V1RELATORIOS-APOLICE1, :V1RELATORIOS-RAMO1 END-EXEC. */

            if (RELATORIOS.Fetch())
            {
                _.Move(RELATORIOS.V1RELATORIOS_CODUSU, V1RELATORIOS_CODUSU);
                _.Move(RELATORIOS.V1RELATORIOS_DATA1, V1RELATORIOS_DATA1);
                _.Move(RELATORIOS.V1RELATORIOS_DATA2, V1RELATORIOS_DATA2);
                _.Move(RELATORIOS.V1RELATORIOS_APOLICE1, V1RELATORIOS_APOLICE1);
                _.Move(RELATORIOS.V1RELATORIOS_RAMO1, V1RELATORIOS_RAMO1);
            }

        }

        [StopWatch]
        /*" M-000-400-FETCH-RELATORIOS-DB-CLOSE-1 */
        public void M_000_400_FETCH_RELATORIOS_DB_CLOSE_1()
        {
            /*" -950- EXEC SQL CLOSE RELATORIOS END-EXEC */

            RELATORIOS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_400_EXIT*/

        [StopWatch]
        /*" M-000-500-SELECT-V1PARAMRAMO-SECTION */
        private void M_000_500_SELECT_V1PARAMRAMO_SECTION()
        {
            /*" -995- MOVE '000-500-SELECT-V1PARAMRAMO' TO PARAGRAFO. */
            _.Move("000-500-SELECT-V1PARAMRAMO", FILLER_0.WABEND.PARAGRAFO);

            /*" -998- MOVE '012' TO WNR-EXEC-SQL. */
            _.Move("012", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -1014- PERFORM M_000_500_SELECT_V1PARAMRAMO_DB_SELECT_1 */

            M_000_500_SELECT_V1PARAMRAMO_DB_SELECT_1();

            /*" -1016- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1017- DISPLAY W-MENSAGEM4 */
                _.Display(FILLER_0.FILLER_87.W_MENSAGEM4);

                /*" -1017- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-000-500-SELECT-V1PARAMRAMO-DB-SELECT-1 */
        public void M_000_500_SELECT_V1PARAMRAMO_DB_SELECT_1()
        {
            /*" -1014- EXEC SQL SELECT RAMO_VG, RAMO_AP, RAMO_VGAPC, RAMO_SAUDE, RAMO_EDUCACAO INTO :V1PARAMRAMO-RAMO-VG, :V1PARAMRAMO-RAMO-AP, :V1PARAMRAMO-RAMO-VGAPC, :V1PARAMRAMO-RAMO-SAUDE, :V1PARAMRAMO-RAMO-EDUCACAO FROM SEGUROS.V1PARAMRAMO END-EXEC. */

            var m_000_500_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1 = new M_000_500_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_000_500_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1.Execute(m_000_500_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1PARAMRAMO_RAMO_VG, V1PARAMRAMO_RAMO_VG);
                _.Move(executed_1.V1PARAMRAMO_RAMO_AP, V1PARAMRAMO_RAMO_AP);
                _.Move(executed_1.V1PARAMRAMO_RAMO_VGAPC, V1PARAMRAMO_RAMO_VGAPC);
                _.Move(executed_1.V1PARAMRAMO_RAMO_SAUDE, V1PARAMRAMO_RAMO_SAUDE);
                _.Move(executed_1.V1PARAMRAMO_RAMO_EDUCACAO, V1PARAMRAMO_RAMO_EDUCACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_500_EXIT*/

        [StopWatch]
        /*" M-200-100-SELECT-V1RAMO-SECTION */
        private void M_200_100_SELECT_V1RAMO_SECTION()
        {
            /*" -1026- MOVE '200-100-SELECT-V1RAMO' TO PARAGRAFO. */
            _.Move("200-100-SELECT-V1RAMO", FILLER_0.WABEND.PARAGRAFO);

            /*" -1029- MOVE '013' TO WNR-EXEC-SQL. */
            _.Move("013", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -1036- PERFORM M_200_100_SELECT_V1RAMO_DB_SELECT_1 */

            M_200_100_SELECT_V1RAMO_DB_SELECT_1();

            /*" -1038- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1039- DISPLAY W-MENSAGEM5 */
                _.Display(FILLER_0.FILLER_87.W_MENSAGEM5);

                /*" -1040- DISPLAY 'RAMO  = ' V1HISTMEST-RAMO */
                _.Display($"RAMO  = {V1HISTMEST_RAMO}");

                /*" -1042- DISPLAY 'MODA  = ' V1HISTMEST-MODALIDA */
                _.Display($"MODA  = {V1HISTMEST_MODALIDA}");

                /*" -1043- MOVE SPACES TO LC05-NOMERAMO */
                _.Move("", FILLER_0.LC05.LC05_NOMERAMO);

                /*" -1044- ELSE */
            }
            else
            {


                /*" -1044- MOVE V1RAMO-NOMERAMO TO LC05-NOMERAMO. */
                _.Move(V1RAMO_NOMERAMO, FILLER_0.LC05.LC05_NOMERAMO);
            }


        }

        [StopWatch]
        /*" M-200-100-SELECT-V1RAMO-DB-SELECT-1 */
        public void M_200_100_SELECT_V1RAMO_DB_SELECT_1()
        {
            /*" -1036- EXEC SQL SELECT NOMERAMO INTO :V1RAMO-NOMERAMO FROM SEGUROS.V1RAMO WHERE RAMO = :V1HISTMEST-RAMO AND MODALIDA = :V1HISTMEST-MODALIDA END-EXEC. */

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
        /*" M-100-100-DECLARE-HISTMEST-SECTION */
        private void M_100_100_DECLARE_HISTMEST_SECTION()
        {
            /*" -1053- MOVE '100-100-DECLARE-HISTMEST-1' TO PARAGRAFO. */
            _.Move("100-100-DECLARE-HISTMEST-1", FILLER_0.WABEND.PARAGRAFO);

            /*" -1056- MOVE '014' TO WNR-EXEC-SQL. */
            _.Move("014", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -1088- PERFORM M_100_100_DECLARE_HISTMEST_DB_DECLARE_1 */

            M_100_100_DECLARE_HISTMEST_DB_DECLARE_1();

            /*" -1090- PERFORM M_100_100_DECLARE_HISTMEST_DB_OPEN_1 */

            M_100_100_DECLARE_HISTMEST_DB_OPEN_1();

            /*" -1093- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -1093- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-100-100-DECLARE-HISTMEST-DB-OPEN-1 */
        public void M_100_100_DECLARE_HISTMEST_DB_OPEN_1()
        {
            /*" -1090- EXEC SQL OPEN HISTMEST END-EXEC. */

            HISTMEST.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_100_EXIT*/

        [StopWatch]
        /*" M-100-200-FETCH-HISTMEST-SECTION */
        private void M_100_200_FETCH_HISTMEST_SECTION()
        {
            /*" -1102- MOVE '100-200-FETCH-HISTMEST' TO PARAGRAFO. */
            _.Move("100-200-FETCH-HISTMEST", FILLER_0.WABEND.PARAGRAFO);

            /*" -1104- MOVE '015' TO WNR-EXEC-SQL. */
            _.Move("015", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -1119- PERFORM M_100_200_FETCH_HISTMEST_DB_FETCH_1 */

            M_100_200_FETCH_HISTMEST_DB_FETCH_1();

            /*" -1123- IF (SQLCODE NOT EQUAL ZERO) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -1125- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1126- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1127- MOVE 'SIM' TO W-FIM-HISTMEST */
                _.Move("SIM", FILLER_0.W_FIM_HISTMEST);

                /*" -1127- PERFORM M_100_200_FETCH_HISTMEST_DB_CLOSE_1 */

                M_100_200_FETCH_HISTMEST_DB_CLOSE_1();

                /*" -1129- IF SQLCODE NOT EQUAL ZERO */

                if (DB.SQLCODE != 00)
                {

                    /*" -1131- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1132- ADD 1 TO W-LIDOS . */
            FILLER_0.W_LIDOS.Value = FILLER_0.W_LIDOS + 1;

            /*" -1133- MOVE V1HISTMEST-DATORR TO WDATA . */
            _.Move(V1HISTMEST_DATORR, FILLER_0.WDATA);

            /*" -1134- MOVE WDATA-DD TO WDATA-DD-CABEC. */
            _.Move(FILLER_0.WDATA.WDATA_DD, FILLER_0.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -1135- MOVE WDATA-MM TO WDATA-MM-CABEC. */
            _.Move(FILLER_0.WDATA.WDATA_MM, FILLER_0.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -1136- MOVE WDATA-AA TO WDATA-AA-CABEC. */
            _.Move(FILLER_0.WDATA.WDATA_AA, FILLER_0.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -1137- MOVE WDATA-CABEC TO LD01-DATORR . */
            _.Move(FILLER_0.WDATA_CABEC, FILLER_0.LD01.LD01_DATORR);

            /*" -1138- MOVE V1HISTMEST-DTMOVTO TO WDATA . */
            _.Move(V1HISTMEST_DTMOVTO, FILLER_0.WDATA);

            /*" -1139- MOVE WDATA-DD TO WDATA-DD-CABEC. */
            _.Move(FILLER_0.WDATA.WDATA_DD, FILLER_0.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -1140- MOVE WDATA-MM TO WDATA-MM-CABEC. */
            _.Move(FILLER_0.WDATA.WDATA_MM, FILLER_0.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -1141- MOVE WDATA-AA TO WDATA-AA-CABEC. */
            _.Move(FILLER_0.WDATA.WDATA_AA, FILLER_0.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -1142- MOVE WDATA-CABEC TO LD01-DTMOVTO . */
            _.Move(FILLER_0.WDATA_CABEC, FILLER_0.LD01.LD01_DTMOVTO);

            /*" -1142- MOVE V1HISTMEST-CODSUBES TO LD01-CODSUBES . */
            _.Move(V1HISTMEST_CODSUBES, FILLER_0.LD01.LD01_CODSUBES);

        }

        [StopWatch]
        /*" M-100-200-FETCH-HISTMEST-DB-FETCH-1 */
        public void M_100_200_FETCH_HISTMEST_DB_FETCH_1()
        {
            /*" -1119- EXEC SQL FETCH HISTMEST INTO :V1HISTMEST-NUM-APOLICE, :V1HISTMEST-NUM-SINISTRO, :V1HISTMEST-CODSUBES, :V1HISTMEST-NRCERTIF, :V1HISTMEST-IDTPSEGU, :V1HISTMEST-PCPARTIC, :V1HISTMEST-DATORR, :V1HISTMEST-PCTRES, :V1HISTMEST-FONTE, :V1HISTMEST-RAMO, :V1HISTMEST-COD-MOEDA-SINI, :V1HISTMEST-DTMOVTO END-EXEC. */

            if (HISTMEST.Fetch())
            {
                _.Move(HISTMEST.V1HISTMEST_NUM_APOLICE, V1HISTMEST_NUM_APOLICE);
                _.Move(HISTMEST.V1HISTMEST_NUM_SINISTRO, V1HISTMEST_NUM_SINISTRO);
                _.Move(HISTMEST.V1HISTMEST_CODSUBES, V1HISTMEST_CODSUBES);
                _.Move(HISTMEST.V1HISTMEST_NRCERTIF, V1HISTMEST_NRCERTIF);
                _.Move(HISTMEST.V1HISTMEST_IDTPSEGU, V1HISTMEST_IDTPSEGU);
                _.Move(HISTMEST.V1HISTMEST_PCPARTIC, V1HISTMEST_PCPARTIC);
                _.Move(HISTMEST.V1HISTMEST_DATORR, V1HISTMEST_DATORR);
                _.Move(HISTMEST.V1HISTMEST_PCTRES, V1HISTMEST_PCTRES);
                _.Move(HISTMEST.V1HISTMEST_FONTE, V1HISTMEST_FONTE);
                _.Move(HISTMEST.V1HISTMEST_RAMO, V1HISTMEST_RAMO);
                _.Move(HISTMEST.V1HISTMEST_COD_MOEDA_SINI, V1HISTMEST_COD_MOEDA_SINI);
                _.Move(HISTMEST.V1HISTMEST_DTMOVTO, V1HISTMEST_DTMOVTO);
            }

        }

        [StopWatch]
        /*" M-100-200-FETCH-HISTMEST-DB-CLOSE-1 */
        public void M_100_200_FETCH_HISTMEST_DB_CLOSE_1()
        {
            /*" -1127- EXEC SQL CLOSE HISTMEST END-EXEC */

            HISTMEST.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_200_EXIT*/

        [StopWatch]
        /*" M-000-000-ACESSA-MOEDA-SECTION */
        private void M_000_000_ACESSA_MOEDA_SECTION()
        {
            /*" -1151- MOVE '000-000-ACESSA-V0MOEDA' TO PARAGRAFO. */
            _.Move("000-000-ACESSA-V0MOEDA", FILLER_0.WABEND.PARAGRAFO);

            /*" -1154- MOVE '017' TO WNR-EXEC-SQL. */
            _.Move("017", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -1160- PERFORM M_000_000_ACESSA_MOEDA_DB_SELECT_1 */

            M_000_000_ACESSA_MOEDA_DB_SELECT_1();

            /*" -1162- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1163- MOVE ALL '?' TO LD01-SIGLUNIM */
                _.MoveAll("?", FILLER_0.LD01.LD01_SIGLUNIM);

                /*" -1164- ELSE */
            }
            else
            {


                /*" -1164- MOVE V0MOEDA-SIGLUNIM TO LD01-SIGLUNIM. */
                _.Move(V0MOEDA_SIGLUNIM, FILLER_0.LD01.LD01_SIGLUNIM);
            }


        }

        [StopWatch]
        /*" M-000-000-ACESSA-MOEDA-DB-SELECT-1 */
        public void M_000_000_ACESSA_MOEDA_DB_SELECT_1()
        {
            /*" -1160- EXEC SQL SELECT NOMEUNIM INTO :V0MOEDA-SIGLUNIM FROM SEGUROS.V0MOEDA WHERE CODUNIMO = :V1HISTMEST-COD-MOEDA-SINI END-EXEC. */

            var m_000_000_ACESSA_MOEDA_DB_SELECT_1_Query1 = new M_000_000_ACESSA_MOEDA_DB_SELECT_1_Query1()
            {
                V1HISTMEST_COD_MOEDA_SINI = V1HISTMEST_COD_MOEDA_SINI.ToString(),
            };

            var executed_1 = M_000_000_ACESSA_MOEDA_DB_SELECT_1_Query1.Execute(m_000_000_ACESSA_MOEDA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0MOEDA_SIGLUNIM, V0MOEDA_SIGLUNIM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_999_ACESSA_MOEDA*/

        [StopWatch]
        /*" M-000-700-DELETE-V1RELATORIOS-SECTION */
        private void M_000_700_DELETE_V1RELATORIOS_SECTION()
        {
            /*" -1173- MOVE '000-700-DELETE-V1RELATORIOS' TO PARAGRAFO. */
            _.Move("000-700-DELETE-V1RELATORIOS", FILLER_0.WABEND.PARAGRAFO);

            /*" -1176- MOVE '016' TO WNR-EXEC-SQL. */
            _.Move("016", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -1183- PERFORM M_000_700_DELETE_V1RELATORIOS_DB_DELETE_1 */

            M_000_700_DELETE_V1RELATORIOS_DB_DELETE_1();

            /*" -1185- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1185- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-000-700-DELETE-V1RELATORIOS-DB-DELETE-1 */
        public void M_000_700_DELETE_V1RELATORIOS_DB_DELETE_1()
        {
            /*" -1183- EXEC SQL DELETE FROM SEGUROS.V0RELATORIOS WHERE IDSISTEM = 'SI' AND CODRELAT = 'SI0103B' AND DATA_SOLICITACAO = :V1SISTEMA-DTMOVABE END-EXEC. */

            var m_000_700_DELETE_V1RELATORIOS_DB_DELETE_1_Delete1 = new M_000_700_DELETE_V1RELATORIOS_DB_DELETE_1_Delete1()
            {
                V1SISTEMA_DTMOVABE = V1SISTEMA_DTMOVABE.ToString(),
            };

            M_000_700_DELETE_V1RELATORIOS_DB_DELETE_1_Delete1.Execute(m_000_700_DELETE_V1RELATORIOS_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_700_EXIT*/

        [StopWatch]
        /*" M-000-800-FINALIZA-SECTION */
        private void M_000_800_FINALIZA_SECTION()
        {
            /*" -1195- MOVE '000-800-FINALIZA' TO PARAGRAFO. */
            _.Move("000-800-FINALIZA", FILLER_0.WABEND.PARAGRAFO);

            /*" -1196- DISPLAY '////////////////////////////////////////////////' */
            _.Display($"////////////////////////////////////////////////");

            /*" -1197- DISPLAY '//                                            //' */
            _.Display($"//                                            //");

            /*" -1198- DISPLAY '//      ==> TERMINO NORMAL <==                //' */
            _.Display($"//      ==> TERMINO NORMAL <==                //");

            /*" -1199- DISPLAY '//                                            //' */
            _.Display($"//                                            //");

            /*" -1200- DISPLAY '//      PROGRAMA =>  SI0103B                  //' */
            _.Display($"//      PROGRAMA =>  SI0103B                  //");

            /*" -1201- DISPLAY '//                                            //' */
            _.Display($"//                                            //");

            /*" -1203- DISPLAY '////////////////////////////////////////////////' . */
            _.Display($"////////////////////////////////////////////////");

            /*" -1205- MOVE ZEROES TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -1206- IF W-CHAVE-ABRIU-RELAT EQUAL 'SIM' */

            if (FILLER_0.W_CHAVE_ABRIU_RELAT == "SIM")
            {

                /*" -1208- CLOSE SI0103M1. */
                SI0103M1.Close();
            }


            /*" -1208- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_800_EXIT*/

        [StopWatch]
        /*" M-999-999-ROT-ERRO-SECTION */
        private void M_999_999_ROT_ERRO_SECTION()
        {
            /*" -1218- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1219- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], FILLER_0.WABEND.WSQLCODE1);

                /*" -1220- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], FILLER_0.WABEND.WSQLCODE2);

                /*" -1221- MOVE SQLCODE TO WSQLCODE3 */
                _.Move(DB.SQLCODE, FILLER_0.WSQLCODE3);

                /*" -1223- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, FILLER_0.WABEND.WSQLCODE);

                /*" -1225- DISPLAY WABEND. */
                _.Display(FILLER_0.WABEND);
            }


            /*" -1226- IF W-CHAVE-ABRIU-RELAT EQUAL 'SIM' */

            if (FILLER_0.W_CHAVE_ABRIU_RELAT == "SIM")
            {

                /*" -1229- CLOSE SI0103M1. */
                SI0103M1.Close();
            }


            /*" -1229- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1231- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1233- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1233- GOBACK. */

            throw new GoBack();

        }
    }
}