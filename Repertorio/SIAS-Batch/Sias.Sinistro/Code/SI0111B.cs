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
using Sias.Sinistro.DB2.SI0111B;

namespace Code
{
    public class SI0111B
    {
        public bool IsCall { get; set; }

        public SI0111B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *///////////////////////////////////////////////////////////////      */
        /*"      *///////////////////////////////////////////////////////////////      */
        /*"      *///////////////////////////////////////////////////////////////      */
        /*"      *   EMISSAO DA RELACAO DE SINISTROS PAGOS NUM CERTO PERIODO   //      */
        /*"      *-------------------------------------------------------------//      */
        /*"      * ANALISTA    - JOSE AGNALDO                                  //      */
        /*"      * PROGRAMADOR - BL                                            //      */
        /*"      * DATA        - 18/05/93                                      //      */
        /*"      * ALTERADO PO PAULINHO EM 11/11/94 PARA IMPRIMIR TOTAL POR    //      */
        /*"      * FAVORECIDO.                                                 //      */
        /*"      *                                                                *      */
        /*"      * CONVERSAO ANO 2000              CONSEDA4              05/1998  *      */
        /*"      *                                                                *      */
        /*"      * REVISAO - ANO 2000              CONSEDA4           06/06/1998  *      */
        /*"      *///////////////////////////////////////////////////////////////      */
        #endregion


        #region VARIABLES

        public FileBasis _SI0111M1 { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis SI0111M1
        {
            get
            {
                _.Move(REG_SI0111M1, _SI0111M1); VarBasis.RedefinePassValue(REG_SI0111M1, _SI0111M1, REG_SI0111M1); return _SI0111M1;
            }
        }
        /*"01  REG-SI0111M1.*/
        public SI0111B_REG_SI0111M1 REG_SI0111M1 { get; set; } = new SI0111B_REG_SI0111M1();
        public class SI0111B_REG_SI0111M1 : VarBasis
        {
            /*"    05  LINHA                  PIC  X(132).*/
            public StringBasis LINHA { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis IND { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"77  V1HISTMEST-NOME            PIC  X(40).*/
        public StringBasis V1HISTMEST_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77  V1HISTMEST-RAMO            PIC S9(04)    COMP.*/
        public IntBasis V1HISTMEST_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1HISTMEST-FONTE           PIC S9(04)    COMP.*/
        public IntBasis V1HISTMEST_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1HISTMEST-NOMFAV          PIC  X(40).*/
        public StringBasis V1HISTMEST_NOMFAV { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77  V1HISTMEST-DATCMD          PIC  X(10).*/
        public StringBasis V1HISTMEST_DATCMD { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1HISTMEST-DATORR          PIC  X(10).*/
        public StringBasis V1HISTMEST_DATORR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1HISTMEST-LIMCRR          PIC  X(10).*/
        public StringBasis V1HISTMEST_LIMCRR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1HISTMEST-ESTADO          PIC  X(02).*/
        public StringBasis V1HISTMEST_ESTADO { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
        /*"77  V1HISTMEST-IDTPSEGU        PIC  X(01).*/
        public StringBasis V1HISTMEST_IDTPSEGU { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V1HISTMEST-CODSUBES        PIC S9(04)    COMP.*/
        public IntBasis V1HISTMEST_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1HISTMEST-MODALIDA        PIC S9(04)    COMP.*/
        public IntBasis V1HISTMEST_MODALIDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1HISTMEST-OCORHIST        PIC S9(04)    COMP.*/
        public IntBasis V1HISTMEST_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1HISTMEST-OPERACAO        PIC S9(04)    COMP.*/
        public IntBasis V1HISTMEST_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1HISTMEST-NRCERTIF        PIC S9(15)    COMP-3.*/
        public IntBasis V1HISTMEST_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77  V1HISTMEST-NUM-APOLICE     PIC S9(13)    COMP-3.*/
        public IntBasis V1HISTMEST_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V1HISTMEST-NUM-SINISTRO    PIC S9(13)    COMP-3.*/
        public IntBasis V1HISTMEST_NUM_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V1HISTMEST-VAL-OPERACAO1   PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V1HISTMEST_VAL_OPERACAO1 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  V1HISTMEST-VAL-OPERACAO2   PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V1HISTMEST_VAL_OPERACAO2 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  V1PARAMRAMO-RAMO-VG        PIC S9(04)    COMP.*/
        public IntBasis V1PARAMRAMO_RAMO_VG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1PARAMRAMO-RAMO-AP        PIC S9(04)    COMP.*/
        public IntBasis V1PARAMRAMO_RAMO_AP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1PARAMRAMO-RAMO-VGAPC     PIC S9(04)    COMP.*/
        public IntBasis V1PARAMRAMO_RAMO_VGAPC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1PARAMRAMO-RAMO-SAUDE     PIC S9(04)    COMP.*/
        public IntBasis V1PARAMRAMO_RAMO_SAUDE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1PARAMRAMO-RAMO-EDUCACAO  PIC S9(04)    COMP.*/
        public IntBasis V1PARAMRAMO_RAMO_EDUCACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1RELATORIOS-DATA1         PIC  X(10).*/
        public StringBasis V1RELATORIOS_DATA1 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1RELATORIOS-DATA2         PIC  X(10).*/
        public StringBasis V1RELATORIOS_DATA2 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1RELATORIOS-APOLICE1      PIC S9(13)       COMP-3.*/
        public IntBasis V1RELATORIOS_APOLICE1 { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V1RELATORIOS-APOLICE2      PIC S9(13)       COMP-3.*/
        public IntBasis V1RELATORIOS_APOLICE2 { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V1HISTSINI-OPERACAO1       PIC S9(04)       COMP.*/
        public IntBasis V1HISTSINI_OPERACAO1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1HISTSINI-OPERACAO2       PIC S9(04)       COMP.*/
        public IntBasis V1HISTSINI_OPERACAO2 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
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
        public SI0111B_FILLER_0 FILLER_0 { get; set; } = new SI0111B_FILLER_0();
        public class SI0111B_FILLER_0 : VarBasis
        {
            /*"    03  LC01.*/
            public SI0111B_LC01 LC01 { get; set; } = new SI0111B_LC01();
            public class SI0111B_LC01 : VarBasis
            {
                /*"        05  FILLER             PIC  X(09) VALUE 'SI0111B.1'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"SI0111B.1");
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
            public SI0111B_LC02 LC02 { get; set; } = new SI0111B_LC02();
            public class SI0111B_LC02 : VarBasis
            {
                /*"        05  FILLER             PIC X(117) VALUE  SPACES.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "117", "X(117)"), @"");
                /*"        05  FILLER             PIC  X(05) VALUE 'DATA'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"DATA");
                /*"        05  LC02-DATA          PIC  X(10) VALUE  SPACES.*/
                public StringBasis LC02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"    03  LC03.*/
            }
            public SI0111B_LC03 LC03 { get; set; } = new SI0111B_LC03();
            public class SI0111B_LC03 : VarBasis
            {
                /*"        05  FILLER             PIC X(117) VALUE  SPACES.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "117", "X(117)"), @"");
                /*"        05  FILLER             PIC  X(07) VALUE 'HORA'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"HORA");
                /*"        05  LC03-HORA          PIC  X(08) VALUE  SPACES.*/
                public StringBasis LC03_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
                /*"    03  LC04.*/
            }
            public SI0111B_LC04 LC04 { get; set; } = new SI0111B_LC04();
            public class SI0111B_LC04 : VarBasis
            {
                /*"        05  FILLER             PIC  X(38) VALUE  SPACES.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "38", "X(38)"), @"");
                /*"        05  FILLER             PIC  X(08) VALUE 'RELACAO'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"RELACAO");
                /*"        05  FILLER             PIC  X(03) VALUE 'DE'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"DE");
                /*"        05  FILLER             PIC  X(10) VALUE 'SINISTROS'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"SINISTROS");
                /*"        05  FILLER             PIC  X(06) VALUE 'PAGOS'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"PAGOS");
                /*"        05  FILLER             PIC  X(03) VALUE 'DE'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"DE");
                /*"        05  LC04-DATA1         PIC  X(11) VALUE  SPACES.*/
                public StringBasis LC04_DATA1 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"");
                /*"        05  FILLER             PIC  X(02) VALUE 'A'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"A");
                /*"        05  LC04-DATA2         PIC  X(10) VALUE  SPACES.*/
                public StringBasis LC04_DATA2 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"    03  LC05.*/
            }
            public SI0111B_LC05 LC05 { get; set; } = new SI0111B_LC05();
            public class SI0111B_LC05 : VarBasis
            {
                /*"        05  FILLER             PIC  X(07) VALUE 'RAMO'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"RAMO");
                /*"        05  LC05-RAMO          PIC  9(03) VALUE  ZEROES.*/
                public IntBasis LC05_RAMO { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
                /*"        05  FILLER             PIC  X(03) VALUE ' - '.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" - ");
                /*"        05  LC05-NOMERAMO      PIC  X(30) VALUE  SPACES.*/
                public StringBasis LC05_NOMERAMO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
                /*"    03  LC06.*/
            }
            public SI0111B_LC06 LC06 { get; set; } = new SI0111B_LC06();
            public class SI0111B_LC06 : VarBasis
            {
                /*"        05  FILLER             PIC  X(07) VALUE 'FONTE'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"FONTE");
                /*"        05  LC06-FONTE         PIC  9(03) VALUE  ZEROES.*/
                public IntBasis LC06_FONTE { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
                /*"        05  FILLER             PIC  X(03) VALUE ' - '.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" - ");
                /*"        05  LC06-NOMEFTE       PIC  X(30) VALUE  SPACES.*/
                public StringBasis LC06_NOMEFTE { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
                /*"    03  LC07.*/
            }
            public SI0111B_LC07 LC07 { get; set; } = new SI0111B_LC07();
            public class SI0111B_LC07 : VarBasis
            {
                /*"        05  FILLER             PIC X(132) VALUE  ALL '-'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
                /*"    03  LC08.*/
            }
            public SI0111B_LC08 LC08 { get; set; } = new SI0111B_LC08();
            public class SI0111B_LC08 : VarBasis
            {
                /*"        05  FILLER             PIC  X(14) VALUE 'SINISTRO'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"SINISTRO");
                /*"        05  FILLER             PIC  X(06) VALUE 'PAGTO'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"PAGTO");
                /*"        05  FILLER             PIC  X(11) VALUE 'SEGURADO /'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"SEGURADO /");
                /*"        05  FILLER             PIC  X(29) VALUE 'FAVORECIDO'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "29", "X(29)"), @"FAVORECIDO");
                /*"        05  FILLER             PIC  X(06) VALUE 'PRACA'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"PRACA");
                /*"        05  FILLER             PIC  X(10) VALUE 'DT AVISO'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"DT AVISO");
                /*"        05  FILLER             PIC  X(10) VALUE 'DT OCOR.'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"DT OCOR.");
                /*"        05  FILLER             PIC  X(13) VALUE 'DT PAGTO'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"DT PAGTO");
                /*"        05  FILLER             PIC  X(23) VALUE 'VALOR LIBERADO'*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"VALOR LIBERADO");
                /*"        05  FILLER             PIC  X(10) VALUE 'VALOR PAGO'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"VALOR PAGO");
                /*"    03  LC09.*/
            }
            public SI0111B_LC09 LC09 { get; set; } = new SI0111B_LC09();
            public class SI0111B_LC09 : VarBasis
            {
                /*"        05  FILLER             PIC  X(33) VALUE  SPACES.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "33", "X(33)"), @"");
                /*"        05  FILLER             PIC  X(10) VALUE 'APOLICE : '.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"APOLICE : ");
                /*"        05  LC09-APOLICE       PIC  9(13).*/
                public IntBasis LC09_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
                /*"        05  FILLER             PIC  X(03) VALUE ' - '.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" - ");
                /*"        05  LC09-NOME-APOLICE  PIC  X(40).*/
                public StringBasis LC09_NOME_APOLICE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"    03  LD01.*/
            }
            public SI0111B_LD01 LD01 { get; set; } = new SI0111B_LD01();
            public class SI0111B_LD01 : VarBasis
            {
                /*"        05  LD01-SINISTRO      PIC  9(13) VALUE  ZEROES.*/
                public IntBasis LD01_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
                /*"        05  FILLER             PIC  X(01) VALUE  SPACE.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  LD01-OPERACAO      PIC  X(05) VALUE  SPACES.*/
                public StringBasis LD01_OPERACAO { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
                /*"        05  FILLER             PIC  X(01) VALUE  SPACE.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  LD01-NOME          PIC  X(38) VALUE  SPACES.*/
                public StringBasis LD01_NOME { get; set; } = new StringBasis(new PIC("X", "38", "X(38)"), @"");
                /*"        05  FILLER             PIC  X(01) VALUE  SPACE.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  LD01-ESTADO        PIC  X(02) VALUE  SPACES.*/
                public StringBasis LD01_ESTADO { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
                /*"        05  FILLER             PIC  X(01) VALUE  SPACES.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  LD01-DATCMD        PIC  X(10) VALUE  SPACES.*/
                public StringBasis LD01_DATCMD { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"        05  FILLER             PIC  X(01) VALUE  SPACES.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  LD01-DATORR        PIC  X(10) VALUE  SPACES.*/
                public StringBasis LD01_DATORR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"        05  FILLER             PIC  X(01) VALUE  SPACES.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  LD01-LIMCRR        PIC  X(10) VALUE  SPACES.*/
                public StringBasis LD01_LIMCRR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"        05  FILLER             PIC  X(01) VALUE  SPACE.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  LD01-VAL-OPERACAO1 PIC  ZZZZZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LD01_VAL_OPERACAO1 { get; set; } = new DoubleBasis(new PIC("9", "13", "ZZZZZZZ.ZZZ.ZZ9V99."), 2);
                /*"        05  FILLER             PIC  X(01) VALUE  SPACE.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  LD01-VAL-OPERACAO2 PIC  ZZZZZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LD01_VAL_OPERACAO2 { get; set; } = new DoubleBasis(new PIC("9", "13", "ZZZZZZZ.ZZZ.ZZ9V99."), 2);
                /*"    03  LD02.*/
            }
            public SI0111B_LD02 LD02 { get; set; } = new SI0111B_LD02();
            public class SI0111B_LD02 : VarBasis
            {
                /*"        05  FILLER             PIC  X(20) VALUE  SPACES.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"");
                /*"        05  LD02-NOMFAV        PIC  X(40) VALUE  SPACES.*/
                public StringBasis LD02_NOMFAV { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"    03  LDPP.*/
            }
            public SI0111B_LDPP LDPP { get; set; } = new SI0111B_LDPP();
            public class SI0111B_LDPP : VarBasis
            {
                /*"        05  FILLER             PIC  X(20) VALUE  SPACES.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"");
                /*"        05  FILLER             PIC  X(06) VALUE 'VALOR'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"VALOR");
                /*"        05  FILLER             PIC  X(06) VALUE 'TOTAL'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"TOTAL");
                /*"        05  FILLER             PIC  X(63) VALUE 'FAVORECIDO'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "63", "X(63)"), @"FAVORECIDO");
                /*"        05  LDPP-TOTFAV1       PIC  ZZZZZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LDPP_TOTFAV1 { get; set; } = new DoubleBasis(new PIC("9", "13", "ZZZZZZZ.ZZZ.ZZ9V99."), 2);
                /*"        05  FILLER             PIC  X(01) VALUE  SPACE.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  LDPP-TOTFAV2       PIC  ZZZZZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LDPP_TOTFAV2 { get; set; } = new DoubleBasis(new PIC("9", "13", "ZZZZZZZ.ZZZ.ZZ9V99."), 2);
                /*"    03  LT01.*/
            }
            public SI0111B_LT01 LT01 { get; set; } = new SI0111B_LT01();
            public class SI0111B_LT01 : VarBasis
            {
                /*"        05  FILLER             PIC  X(20) VALUE  SPACES.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"");
                /*"        05  FILLER             PIC  X(06) VALUE 'VALOR'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"VALOR");
                /*"        05  FILLER             PIC  X(06) VALUE 'TOTAL'.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"TOTAL");
                /*"        05  FILLER             PIC  X(63) VALUE 'FONTE'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "63", "X(63)"), @"FONTE");
                /*"        05  LT01-ACC-FONTE1    PIC  ZZZZZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LT01_ACC_FONTE1 { get; set; } = new DoubleBasis(new PIC("9", "13", "ZZZZZZZ.ZZZ.ZZ9V99."), 2);
                /*"        05  FILLER             PIC  X(01) VALUE  SPACE.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  LT01-ACC-FONTE2    PIC  ZZZZZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LT01_ACC_FONTE2 { get; set; } = new DoubleBasis(new PIC("9", "13", "ZZZZZZZ.ZZZ.ZZ9V99."), 2);
                /*"    03  LT02.*/
            }
            public SI0111B_LT02 LT02 { get; set; } = new SI0111B_LT02();
            public class SI0111B_LT02 : VarBasis
            {
                /*"        05  FILLER             PIC  X(20) VALUE  SPACES.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"");
                /*"        05  FILLER             PIC  X(06) VALUE 'VALOR'.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"VALOR");
                /*"        05  FILLER             PIC  X(06) VALUE 'TOTAL'.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"TOTAL");
                /*"        05  FILLER             PIC  X(63) VALUE 'RAMO'.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "63", "X(63)"), @"RAMO");
                /*"        05  LT02-ACC-RAMO1     PIC  ZZZZZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LT02_ACC_RAMO1 { get; set; } = new DoubleBasis(new PIC("9", "13", "ZZZZZZZ.ZZZ.ZZ9V99."), 2);
                /*"        05  FILLER             PIC  X(01) VALUE  SPACE.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  LT02-ACC-RAMO2     PIC  ZZZZZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LT02_ACC_RAMO2 { get; set; } = new DoubleBasis(new PIC("9", "13", "ZZZZZZZ.ZZZ.ZZ9V99."), 2);
                /*"    03  LT03.*/
            }
            public SI0111B_LT03 LT03 { get; set; } = new SI0111B_LT03();
            public class SI0111B_LT03 : VarBasis
            {
                /*"        05  FILLER             PIC  X(20) VALUE  SPACES.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"");
                /*"        05  FILLER             PIC  X(06) VALUE 'VALOR'.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"VALOR");
                /*"        05  FILLER             PIC  X(06) VALUE 'TOTAL'.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"TOTAL");
                /*"        05  FILLER             PIC  X(63) VALUE 'GERAL'.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "63", "X(63)"), @"GERAL");
                /*"        05  LT03-ACC-GERAL1    PIC  ZZZZZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LT03_ACC_GERAL1 { get; set; } = new DoubleBasis(new PIC("9", "13", "ZZZZZZZ.ZZZ.ZZ9V99."), 2);
                /*"        05  FILLER             PIC  X(01) VALUE  SPACE.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  LT03-ACC-GERAL2    PIC  ZZZZZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LT03_ACC_GERAL2 { get; set; } = new DoubleBasis(new PIC("9", "13", "ZZZZZZZ.ZZZ.ZZ9V99."), 2);
                /*"    03  WDATA.*/
            }
            public SI0111B_WDATA WDATA { get; set; } = new SI0111B_WDATA();
            public class SI0111B_WDATA : VarBasis
            {
                /*"        05  WDATA-AA           PIC  9(04) VALUE  ZEROES.*/
                public IntBasis WDATA_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"        05  FILLER             PIC  X(01) VALUE  SPACES.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  WDATA-MM           PIC  9(02) VALUE  ZEROES.*/
                public IntBasis WDATA_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"        05  FILLER             PIC  X(01) VALUE  SPACES.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  WDATA-DD           PIC  9(02) VALUE  ZEROES.*/
                public IntBasis WDATA_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    03       WDATA-CURR        PIC  X(010)    VALUE SPACES.*/
            }
            public StringBasis WDATA_CURR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    03       FILLER            REDEFINES      WDATA-CURR.*/
            private _REDEF_SI0111B_FILLER_64 _filler_64 { get; set; }
            public _REDEF_SI0111B_FILLER_64 FILLER_64
            {
                get { _filler_64 = new _REDEF_SI0111B_FILLER_64(); _.Move(WDATA_CURR, _filler_64); VarBasis.RedefinePassValue(WDATA_CURR, _filler_64, WDATA_CURR); _filler_64.ValueChanged += () => { _.Move(_filler_64, WDATA_CURR); }; return _filler_64; }
                set { VarBasis.RedefinePassValue(value, _filler_64, WDATA_CURR); }
            }  //Redefines
            public class _REDEF_SI0111B_FILLER_64 : VarBasis
            {
                /*"      05     WDATA-AA-CURR     PIC  9(004).*/
                public IntBasis WDATA_AA_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      05     FILLER            PIC  X(001).*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      05     WDATA-MM-CURR     PIC  9(002).*/
                public IntBasis WDATA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05     FILLER            PIC  X(001).*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      05     WDATA-DD-CURR     PIC  9(002).*/
                public IntBasis WDATA_DD_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03  WHORA-CURR.*/

                public _REDEF_SI0111B_FILLER_64()
                {
                    WDATA_AA_CURR.ValueChanged += OnValueChanged;
                    FILLER_65.ValueChanged += OnValueChanged;
                    WDATA_MM_CURR.ValueChanged += OnValueChanged;
                    FILLER_66.ValueChanged += OnValueChanged;
                    WDATA_DD_CURR.ValueChanged += OnValueChanged;
                }

            }
            public SI0111B_WHORA_CURR WHORA_CURR { get; set; } = new SI0111B_WHORA_CURR();
            public class SI0111B_WHORA_CURR : VarBasis
            {
                /*"        05  WHORA-HH-CURR      PIC  9(02) VALUE  ZEROES.*/
                public IntBasis WHORA_HH_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"        05  WHORA-MM-CURR      PIC  9(02) VALUE  ZEROES.*/
                public IntBasis WHORA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"        05  WHORA-SS-CURR      PIC  9(02) VALUE  ZEROES.*/
                public IntBasis WHORA_SS_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    03  WDATA-CABEC.*/
            }
            public SI0111B_WDATA_CABEC WDATA_CABEC { get; set; } = new SI0111B_WDATA_CABEC();
            public class SI0111B_WDATA_CABEC : VarBasis
            {
                /*"        05  WDATA-DD-CABEC     PIC  9(02) VALUE  ZEROES.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"        05  FILLER             PIC  X(01) VALUE '/'.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"        05  WDATA-MM-CABEC     PIC  9(02) VALUE  ZEROES.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"        05  FILLER             PIC  X(01) VALUE '/'.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"        05  WDATA-AA-CABEC     PIC  9(04) VALUE  ZEROES.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"    03  WHORA-CABEC.*/
            }
            public SI0111B_WHORA_CABEC WHORA_CABEC { get; set; } = new SI0111B_WHORA_CABEC();
            public class SI0111B_WHORA_CABEC : VarBasis
            {
                /*"        05  WHORA-HH-CABEC     PIC  9(02) VALUE  ZEROES.*/
                public IntBasis WHORA_HH_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"        05  FILLER             PIC  X(01) VALUE ':'.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @":");
                /*"        05  WHORA-MM-CABEC     PIC  9(02) VALUE  ZEROES.*/
                public IntBasis WHORA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"        05  FILLER             PIC  X(01) VALUE ':'.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @":");
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
            /*"    03  WS-AUX                 PIC S9(01)    VALUE ZEROS  COMP.*/
            public IntBasis WS_AUX { get; set; } = new IntBasis(new PIC("S9", "1", "S9(01)"));
            /*"    03  W-ACC-RAMO1            PIC S9(13)V99 VALUE ZEROES COMP-3*/
            public DoubleBasis W_ACC_RAMO1 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    03  W-ACC-RAMO2            PIC S9(13)V99 VALUE ZEROES COMP-3*/
            public DoubleBasis W_ACC_RAMO2 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    03  W-ACC-FONTE1           PIC S9(13)V99 VALUE ZEROES COMP-3*/
            public DoubleBasis W_ACC_FONTE1 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    03  W-ACC-FONTE2           PIC S9(13)V99 VALUE ZEROES COMP-3*/
            public DoubleBasis W_ACC_FONTE2 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    03  W-ACC-GERAL1           PIC S9(13)V99 VALUE ZEROES COMP-3*/
            public DoubleBasis W_ACC_GERAL1 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    03  W-ACC-GERAL2           PIC S9(13)V99 VALUE ZEROES COMP-3*/
            public DoubleBasis W_ACC_GERAL2 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    03  NOMFAV-ANT             PIC  X(40) VALUE SPACES.*/
            public StringBasis NOMFAV_ANT { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
            /*"    03  TOTFAV1                PIC S9(13)V99 VALUE +0 COMP-3.*/
            public DoubleBasis TOTFAV1 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    03  TOTFAV2                PIC S9(13)V99 VALUE +0 COMP-3.*/
            public DoubleBasis TOTFAV2 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    03  ENCHE                  PIC 9(01) VALUE 1.*/
            public IntBasis ENCHE { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"), 1);
            /*"    03  TABELA-OPERACAO.*/
            public SI0111B_TABELA_OPERACAO TABELA_OPERACAO { get; set; } = new SI0111B_TABELA_OPERACAO();
            public class SI0111B_TABELA_OPERACAO : VarBasis
            {
                /*"        05  FILLER             PIC  X(05) VALUE 'PARC.'.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"PARC.");
                /*"        05  FILLER             PIC  X(05) VALUE 'FINAL'.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"FINAL");
                /*"        05  FILLER             PIC  X(05) VALUE 'TOTAL'.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"TOTAL");
                /*"        05  FILLER             PIC  X(05) VALUE 'COMPL'.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"COMPL");
                /*"    03  FILLER REDEFINES TABELA-OPERACAO OCCURS 4 INDEXED BY IND*/
            }
            private ListBasis<_REDEF_SI0111B_FILLER_75> _filler_75 { get; set; }
            public ListBasis<_REDEF_SI0111B_FILLER_75> FILLER_75
            {
                get { _filler_75 = new ListBasis<_REDEF_SI0111B_FILLER_75>(4); _.Move(TABELA_OPERACAO, _filler_75); VarBasis.RedefinePassValue(TABELA_OPERACAO, _filler_75, TABELA_OPERACAO); _filler_75.ValueChanged += () => { _.Move(_filler_75, TABELA_OPERACAO); }; return _filler_75; }
                set { VarBasis.RedefinePassValue(value, _filler_75, TABELA_OPERACAO); }
            }  //Redefines
            public class _REDEF_SI0111B_FILLER_75 : VarBasis
            {
                /*"        05  TAB-OPERACAO       PIC  X(05).*/
                public StringBasis TAB_OPERACAO { get; set; } = new StringBasis(new PIC("X", "5", "X(05)."), @"");
                /*"    03  WSQLCODE3              PIC S9(09) VALUE  ZEROES COMP.*/

                public _REDEF_SI0111B_FILLER_75()
                {
                    TAB_OPERACAO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"    03  WABEND.*/
            public SI0111B_WABEND WABEND { get; set; } = new SI0111B_WABEND();
            public class SI0111B_WABEND : VarBasis
            {
                /*"        05  FILLER             PIC  X(01) VALUE  SPACE.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  FILLER             PIC  X(09) VALUE 'SI0111B'.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"SI0111B");
                /*"        05  FILLER             PIC  X(10) VALUE '*** ERRO'.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"*** ERRO");
                /*"        05  FILLER             PIC  X(10) VALUE 'EXEC SQL'.*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"EXEC SQL");
                /*"        05  FILLER             PIC  X(08) VALUE 'NUMERO'.*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"NUMERO");
                /*"        05  WNR-EXEC-SQL       PIC  X(03) VALUE  SPACES.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
                /*"        05  FILLER             PIC  X(01) VALUE  SPACE.*/
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  FILLER             PIC  X(16) VALUE '** PARAGRAFO ='*/
                public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"** PARAGRAFO =");
                /*"        05  PARAGRAFO          PIC  X(30) VALUE  SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
                /*"        05  FILLER             PIC  X(04) VALUE  SPACES.*/
                public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
                /*"        05  FILLER             PIC  X(10) VALUE 'SQLCODE = '.*/
                public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"SQLCODE = ");
                /*"        05  WSQLCODE           PIC  ZZZZZZ999-   VALUE ZEROES.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"        05  FILLER             PIC  X(04) VALUE  SPACES.*/
                public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
                /*"        05  FILLER             PIC  X(10) VALUE 'SQLCODE1= '.*/
                public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"SQLCODE1= ");
                /*"        05  WSQLCODE1          PIC  ZZZZZZ999-   VALUE ZEROES.*/
                public IntBasis WSQLCODE1 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"        05  FILLER             PIC  X(04) VALUE  SPACES.*/
                public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
                /*"        05  FILLER             PIC  X(10) VALUE 'SQLCODE2= '.*/
                public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"SQLCODE2= ");
                /*"        05  WSQLCODE2          PIC  ZZZZZZ999-   VALUE ZEROES.*/
                public IntBasis WSQLCODE2 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"    03  FILLER.*/
            }
            public SI0111B_FILLER_89 FILLER_89 { get; set; } = new SI0111B_FILLER_89();
            public class SI0111B_FILLER_89 : VarBasis
            {
                /*"        05  W-MENSAGEM1        PIC  X(35) VALUE           'SI0111B - SEM MOVIMENTOS NO DIA'.*/
                public StringBasis W_MENSAGEM1 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"SI0111B - SEM MOVIMENTOS NO DIA");
                /*"        05  W-MENSAGEM2        PIC  X(35) VALUE           'SI0111B - EMPRESA NAO ENCONTRADA'.*/
                public StringBasis W_MENSAGEM2 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"SI0111B - EMPRESA NAO ENCONTRADA");
                /*"        05  W-MENSAGEM3        PIC  X(35) VALUE           'SI0111B - SISTEMA NAO ENCONTRADO'.*/
                public StringBasis W_MENSAGEM3 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"SI0111B - SISTEMA NAO ENCONTRADO");
                /*"        05  W-MENSAGEM4        PIC  X(35) VALUE           'SI0111B - PARAMRAMO NAO ENCONTRADO'.*/
                public StringBasis W_MENSAGEM4 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"SI0111B - PARAMRAMO NAO ENCONTRADO");
                /*"        05  W-MENSAGEM5        PIC  X(35) VALUE           'SI0111B - SINISTRO NAO ENCONTRADO'.*/
                public StringBasis W_MENSAGEM5 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"SI0111B - SINISTRO NAO ENCONTRADO");
                /*"        05  W-MENSAGEM6        PIC  X(35) VALUE           'SI0111B - RAMO NAO ENCONTRADO'.*/
                public StringBasis W_MENSAGEM6 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"SI0111B - RAMO NAO ENCONTRADO");
                /*"        05  W-MENSAGEM7        PIC  X(35) VALUE           'SI0111B - CLIENTE NAO ENCONTRADO'.*/
                public StringBasis W_MENSAGEM7 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"SI0111B - CLIENTE NAO ENCONTRADO");
                /*"        05  W-MENSAGEM8        PIC  X(35) VALUE           'SI0111B - FONTE NAO ENCONTRADA'.*/
                public StringBasis W_MENSAGEM8 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"SI0111B - FONTE NAO ENCONTRADA");
                /*"01  LK-LINK.*/
            }
        }
        public SI0111B_LK_LINK LK_LINK { get; set; } = new SI0111B_LK_LINK();
        public class SI0111B_LK_LINK : VarBasis
        {
            /*"    03  LK-RTCODE              PIC S9(04) VALUE  +00000 COMP.*/
            public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"), +00000);
            /*"    03  LK-TAMANHO             PIC S9(04) VALUE  +00040 COMP.*/
            public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"), +00040);
            /*"    03  LK-TITULO              PIC X(132) VALUE  SPACES.*/
            public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
        }


        public SI0111B_RELATORIOS RELATORIOS { get; set; } = new SI0111B_RELATORIOS();
        public SI0111B_HISTMEST HISTMEST { get; set; } = new SI0111B_HISTMEST();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SI0111M1_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SI0111M1.SetFile(SI0111M1_FILE_NAME_P);

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
            /*" -367- MOVE '000-000-PRINCIPAL' TO PARAGRAFO. */
            _.Move("000-000-PRINCIPAL", FILLER_0.WABEND.PARAGRAFO);

            /*" -369- MOVE '000' TO WNR-EXEC-SQL. */
            _.Move("000", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -369- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -370- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -371- EXEC SQL WHENEVER SQLERROR GO TO 999-999-ROT-ERRO END-EXEC. */

            /*" -375- OPEN OUTPUT SI0111M1. */
            SI0111M1.Open(REG_SI0111M1);

            /*" -377- ACCEPT WHORA-CURR FROM TIME. */
            _.Move(_.AcceptDate("TIME"), FILLER_0.WHORA_CURR);

            /*" -378- MOVE WHORA-HH-CURR TO WHORA-HH-CABEC. */
            _.Move(FILLER_0.WHORA_CURR.WHORA_HH_CURR, FILLER_0.WHORA_CABEC.WHORA_HH_CABEC);

            /*" -379- MOVE WHORA-MM-CURR TO WHORA-MM-CABEC. */
            _.Move(FILLER_0.WHORA_CURR.WHORA_MM_CURR, FILLER_0.WHORA_CABEC.WHORA_MM_CABEC);

            /*" -381- MOVE WHORA-SS-CURR TO WHORA-SS-CABEC. */
            _.Move(FILLER_0.WHORA_CURR.WHORA_SS_CURR, FILLER_0.WHORA_CABEC.WHORA_SS_CABEC);

            /*" -383- MOVE WHORA-CABEC TO LC03-HORA. */
            _.Move(FILLER_0.WHORA_CABEC, FILLER_0.LC03.LC03_HORA);

            /*" -384- PERFORM 000-100-SELECT-V1EMPRESA. */

            M_000_100_SELECT_V1EMPRESA_SECTION();

            /*" -385- PERFORM 000-200-SELECT-V1SISTEMA. */

            M_000_200_SELECT_V1SISTEMA_SECTION();

            /*" -386- PERFORM 000-300-DECLARE-RELATORIOS. */

            M_000_300_DECLARE_RELATORIOS_SECTION();

            /*" -388- PERFORM 000-400-FETCH-RELATORIOS. */

            M_000_400_FETCH_RELATORIOS_SECTION();

            /*" -389- IF W-FIM-RELATORIOS EQUAL 'S' */

            if (FILLER_0.W_FIM_RELATORIOS == "S")
            {

                /*" -391- DISPLAY W-MENSAGEM1 */
                _.Display(FILLER_0.FILLER_89.W_MENSAGEM1);

                /*" -393- PERFORM 000-700-FINALIZA. */

                M_000_700_FINALIZA_SECTION();
            }


            /*" -395- PERFORM 000-500-SELECT-V1PARAMRAMO. */

            M_000_500_SELECT_V1PARAMRAMO_SECTION();

            /*" -398- PERFORM 000-600-PROCESSA-RELATORIOS UNTIL W-FIM-RELATORIOS EQUAL 'S' . */

            while (!(FILLER_0.W_FIM_RELATORIOS == "S"))
            {

                M_000_600_PROCESSA_RELATORIOS_SECTION();
            }

            /*" -400- PERFORM 000-800-UPDATE-V1RELATORIOS. */

            M_000_800_UPDATE_V1RELATORIOS_SECTION();

            /*" -400- PERFORM 000-700-FINALIZA. */

            M_000_700_FINALIZA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_000_EXIT*/

        [StopWatch]
        /*" M-000-100-SELECT-V1EMPRESA-SECTION */
        private void M_000_100_SELECT_V1EMPRESA_SECTION()
        {
            /*" -409- MOVE '000-100-SELECT-V1EMPRESA' TO PARAGRAFO. */
            _.Move("000-100-SELECT-V1EMPRESA", FILLER_0.WABEND.PARAGRAFO);

            /*" -413- MOVE '001' TO WNR-EXEC-SQL. */
            _.Move("001", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -423- PERFORM M_000_100_SELECT_V1EMPRESA_DB_SELECT_1 */

            M_000_100_SELECT_V1EMPRESA_DB_SELECT_1();

            /*" -429- MOVE V1EMPRESA-NOME-EMPRESA TO LK-TITULO. */
            _.Move(V1EMPRESA_NOME_EMPRESA, LK_LINK.LK_TITULO);

            /*" -430- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -431- DISPLAY W-MENSAGEM2 */
                _.Display(FILLER_0.FILLER_89.W_MENSAGEM2);

                /*" -433- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -434- CALL 'PROALN01' USING LK-LINK. */
            _.Call("PROALN01", LK_LINK);

            /*" -434- MOVE LK-TITULO TO LC01-NOME-EMPRESA. */
            _.Move(LK_LINK.LK_TITULO, FILLER_0.LC01.LC01_NOME_EMPRESA);

        }

        [StopWatch]
        /*" M-000-100-SELECT-V1EMPRESA-DB-SELECT-1 */
        public void M_000_100_SELECT_V1EMPRESA_DB_SELECT_1()
        {
            /*" -423- EXEC SQL SELECT NOME_EMPRESA INTO :V1EMPRESA-NOME-EMPRESA FROM SEGUROS.V1EMPRESA WHERE COD_EMPRESA = 0 END-EXEC. */

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
            /*" -443- MOVE '000-200-SELECT-V1SISTEMA' TO PARAGRAFO. */
            _.Move("000-200-SELECT-V1SISTEMA", FILLER_0.WABEND.PARAGRAFO);

            /*" -447- MOVE '002' TO WNR-EXEC-SQL. */
            _.Move("002", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -457- PERFORM M_000_200_SELECT_V1SISTEMA_DB_SELECT_1 */

            M_000_200_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -462- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -463- DISPLAY W-MENSAGEM3 */
                _.Display(FILLER_0.FILLER_89.W_MENSAGEM3);

                /*" -465- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -466- MOVE V1SISTEMA-DTCURRENT TO WDATA-CURR */
            _.Move(V1SISTEMA_DTCURRENT, FILLER_0.WDATA_CURR);

            /*" -467- MOVE WDATA-DD-CURR TO WDATA-DD-CABEC. */
            _.Move(FILLER_0.FILLER_64.WDATA_DD_CURR, FILLER_0.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -468- MOVE WDATA-MM-CURR TO WDATA-MM-CABEC. */
            _.Move(FILLER_0.FILLER_64.WDATA_MM_CURR, FILLER_0.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -469- MOVE WDATA-AA-CURR TO WDATA-AA-CABEC. */
            _.Move(FILLER_0.FILLER_64.WDATA_AA_CURR, FILLER_0.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -469- MOVE WDATA-CABEC TO LC02-DATA. */
            _.Move(FILLER_0.WDATA_CABEC, FILLER_0.LC02.LC02_DATA);

        }

        [StopWatch]
        /*" M-000-200-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void M_000_200_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -457- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :V1SISTEMA-DTMOVABE, :V1SISTEMA-DTCURRENT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'SI' END-EXEC. */

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
            /*" -478- MOVE '000-300-DECLARE-RELATORIOS' TO PARAGRAFO. */
            _.Move("000-300-DECLARE-RELATORIOS", FILLER_0.WABEND.PARAGRAFO);

            /*" -482- MOVE '003' TO WNR-EXEC-SQL. */
            _.Move("003", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -496- PERFORM M_000_300_DECLARE_RELATORIOS_DB_DECLARE_1 */

            M_000_300_DECLARE_RELATORIOS_DB_DECLARE_1();

            /*" -500- PERFORM M_000_300_DECLARE_RELATORIOS_DB_OPEN_1 */

            M_000_300_DECLARE_RELATORIOS_DB_OPEN_1();

        }

        [StopWatch]
        /*" M-000-300-DECLARE-RELATORIOS-DB-DECLARE-1 */
        public void M_000_300_DECLARE_RELATORIOS_DB_DECLARE_1()
        {
            /*" -496- EXEC SQL DECLARE RELATORIOS CURSOR FOR SELECT PERI_INICIAL, PERI_FINAL, NUM_APOLICE FROM SEGUROS.V1RELATORIOS WHERE IDSISTEM = 'SI' AND CODRELAT = 'SI0111B' AND DATA_SOLICITACAO = :V1SISTEMA-DTMOVABE END-EXEC. */
            RELATORIOS = new SI0111B_RELATORIOS(true);
            string GetQuery_RELATORIOS()
            {
                var query = @$"SELECT PERI_INICIAL
							, 
							PERI_FINAL
							, 
							NUM_APOLICE 
							FROM SEGUROS.V1RELATORIOS 
							WHERE IDSISTEM = 'SI' AND 
							CODRELAT = 'SI0111B' AND 
							DATA_SOLICITACAO = '{V1SISTEMA_DTMOVABE}'";

                return query;
            }
            RELATORIOS.GetQueryEvent += GetQuery_RELATORIOS;

        }

        [StopWatch]
        /*" M-000-300-DECLARE-RELATORIOS-DB-OPEN-1 */
        public void M_000_300_DECLARE_RELATORIOS_DB_OPEN_1()
        {
            /*" -500- EXEC SQL OPEN RELATORIOS END-EXEC. */

            RELATORIOS.Open();

        }

        [StopWatch]
        /*" M-100-100-DECLARE-HISTMEST-DB-DECLARE-1 */
        public void M_100_100_DECLARE_HISTMEST_DB_DECLARE_1()
        {
            /*" -696- EXEC SQL DECLARE HISTMEST CURSOR FOR SELECT H.NUM_APOL_SINISTRO, H.VAL_OPERACAO, M.NUM_APOLICE, H.OCORHIST, H.OPERACAO, M.IDTPSEGU, M.CODSUBES, M.NRCERTIF, A.MODALIDA, F.ESTADO, H.NOMFAV, H.LIMCRR, M.DATCMD, M.DATORR, M.FONTE, M.RAMO, A.NOME FROM SEGUROS.V1HISTSINI H, SEGUROS.V1MESTSINI M, SEGUROS.V1APOLICE A, SEGUROS.V1FONTE F WHERE H.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO AND M.NUM_APOLICE = A.NUM_APOLICE AND H.FONPAG = F.FONTE AND H.DTMOVTO >= :V1RELATORIOS-DATA1 AND H.DTMOVTO <= :V1RELATORIOS-DATA2 AND H.SITUACAO IN ( '0' , '1' ) AND H.OPERACAO IN (1001, 1002, 1003, 1004, 1009) AND A.NUM_APOLICE >= :V1RELATORIOS-APOLICE1 AND A.NUM_APOLICE <= :V1RELATORIOS-APOLICE2 ORDER BY RAMO, FONTE, MODALIDA, NOMFAV, NUM_APOL_SINISTRO, OPERACAO END-EXEC. */
            HISTMEST = new SI0111B_HISTMEST(true);
            string GetQuery_HISTMEST()
            {
                var query = @$"SELECT H.NUM_APOL_SINISTRO
							, 
							H.VAL_OPERACAO
							, 
							M.NUM_APOLICE
							, 
							H.OCORHIST
							, 
							H.OPERACAO
							, 
							M.IDTPSEGU
							, 
							M.CODSUBES
							, 
							M.NRCERTIF
							, 
							A.MODALIDA
							, 
							F.ESTADO
							, 
							H.NOMFAV
							, 
							H.LIMCRR
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
							SEGUROS.V1FONTE F 
							WHERE H.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO AND 
							M.NUM_APOLICE = A.NUM_APOLICE AND 
							H.FONPAG = F.FONTE AND 
							H.DTMOVTO >= '{V1RELATORIOS_DATA1}' AND 
							H.DTMOVTO <= '{V1RELATORIOS_DATA2}' AND 
							H.SITUACAO IN ( '0'
							, '1' ) AND 
							H.OPERACAO IN 
							(1001
							, 1002
							, 1003
							, 1004
							, 1009) AND 
							A.NUM_APOLICE >= '{V1RELATORIOS_APOLICE1}' AND 
							A.NUM_APOLICE <= '{V1RELATORIOS_APOLICE2}' 
							ORDER BY 
							RAMO
							, FONTE
							, MODALIDA
							, NOMFAV
							, NUM_APOL_SINISTRO
							, 
							OPERACAO";

                return query;
            }
            HISTMEST.GetQueryEvent += GetQuery_HISTMEST;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_300_EXIT*/

        [StopWatch]
        /*" M-000-400-FETCH-RELATORIOS-SECTION */
        private void M_000_400_FETCH_RELATORIOS_SECTION()
        {
            /*" -510- MOVE '000-400-FETCH-RELATORIOS' TO PARAGRAFO. */
            _.Move("000-400-FETCH-RELATORIOS", FILLER_0.WABEND.PARAGRAFO);

            /*" -518- PERFORM M_000_400_FETCH_RELATORIOS_DB_FETCH_1 */

            M_000_400_FETCH_RELATORIOS_DB_FETCH_1();

            /*" -521- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -521- PERFORM M_000_400_FETCH_RELATORIOS_DB_CLOSE_1 */

                M_000_400_FETCH_RELATORIOS_DB_CLOSE_1();

                /*" -523- MOVE 'S' TO W-FIM-RELATORIOS */
                _.Move("S", FILLER_0.W_FIM_RELATORIOS);

                /*" -524- ELSE */
            }
            else
            {


                /*" -526- MOVE 'N' TO W-FIM-HISTMEST */
                _.Move("N", FILLER_0.W_FIM_HISTMEST);

                /*" -527- MOVE V1RELATORIOS-DATA1 TO WDATA */
                _.Move(V1RELATORIOS_DATA1, FILLER_0.WDATA);

                /*" -528- MOVE WDATA-DD TO WDATA-DD-CABEC */
                _.Move(FILLER_0.WDATA.WDATA_DD, FILLER_0.WDATA_CABEC.WDATA_DD_CABEC);

                /*" -529- MOVE WDATA-MM TO WDATA-MM-CABEC */
                _.Move(FILLER_0.WDATA.WDATA_MM, FILLER_0.WDATA_CABEC.WDATA_MM_CABEC);

                /*" -530- MOVE WDATA-AA TO WDATA-AA-CABEC */
                _.Move(FILLER_0.WDATA.WDATA_AA, FILLER_0.WDATA_CABEC.WDATA_AA_CABEC);

                /*" -532- MOVE WDATA-CABEC TO LC04-DATA1 */
                _.Move(FILLER_0.WDATA_CABEC, FILLER_0.LC04.LC04_DATA1);

                /*" -533- MOVE V1RELATORIOS-DATA2 TO WDATA */
                _.Move(V1RELATORIOS_DATA2, FILLER_0.WDATA);

                /*" -534- MOVE WDATA-DD TO WDATA-DD-CABEC */
                _.Move(FILLER_0.WDATA.WDATA_DD, FILLER_0.WDATA_CABEC.WDATA_DD_CABEC);

                /*" -535- MOVE WDATA-MM TO WDATA-MM-CABEC */
                _.Move(FILLER_0.WDATA.WDATA_MM, FILLER_0.WDATA_CABEC.WDATA_MM_CABEC);

                /*" -536- MOVE WDATA-AA TO WDATA-AA-CABEC */
                _.Move(FILLER_0.WDATA.WDATA_AA, FILLER_0.WDATA_CABEC.WDATA_AA_CABEC);

                /*" -538- MOVE WDATA-CABEC TO LC04-DATA2 */
                _.Move(FILLER_0.WDATA_CABEC, FILLER_0.LC04.LC04_DATA2);

                /*" -539- IF V1RELATORIOS-APOLICE1 EQUAL ZEROES */

                if (V1RELATORIOS_APOLICE1 == 00)
                {

                    /*" -540- MOVE 9999999999999 TO V1RELATORIOS-APOLICE2 */
                    _.Move(9999999999999, V1RELATORIOS_APOLICE2);

                    /*" -541- ELSE */
                }
                else
                {


                    /*" -541- MOVE V1RELATORIOS-APOLICE1 TO V1RELATORIOS-APOLICE2. */
                    _.Move(V1RELATORIOS_APOLICE1, V1RELATORIOS_APOLICE2);
                }

            }


        }

        [StopWatch]
        /*" M-000-400-FETCH-RELATORIOS-DB-FETCH-1 */
        public void M_000_400_FETCH_RELATORIOS_DB_FETCH_1()
        {
            /*" -518- EXEC SQL FETCH RELATORIOS INTO :V1RELATORIOS-DATA1, :V1RELATORIOS-DATA2, :V1RELATORIOS-APOLICE1 END-EXEC. */

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
            /*" -521- EXEC SQL CLOSE RELATORIOS END-EXEC */

            RELATORIOS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_400_EXIT*/

        [StopWatch]
        /*" M-000-500-SELECT-V1PARAMRAMO-SECTION */
        private void M_000_500_SELECT_V1PARAMRAMO_SECTION()
        {
            /*" -550- MOVE '000-500-SELECT-V1PARAMRAMO' TO PARAGRAFO. */
            _.Move("000-500-SELECT-V1PARAMRAMO", FILLER_0.WABEND.PARAGRAFO);

            /*" -554- MOVE '004' TO WNR-EXEC-SQL. */
            _.Move("004", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -570- PERFORM M_000_500_SELECT_V1PARAMRAMO_DB_SELECT_1 */

            M_000_500_SELECT_V1PARAMRAMO_DB_SELECT_1();

            /*" -575- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -576- DISPLAY W-MENSAGEM4 */
                _.Display(FILLER_0.FILLER_89.W_MENSAGEM4);

                /*" -576- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-000-500-SELECT-V1PARAMRAMO-DB-SELECT-1 */
        public void M_000_500_SELECT_V1PARAMRAMO_DB_SELECT_1()
        {
            /*" -570- EXEC SQL SELECT RAMO_VG, RAMO_AP, RAMO_VGAPC, RAMO_SAUDE, RAMO_EDUCACAO INTO :V1PARAMRAMO-RAMO-VG, :V1PARAMRAMO-RAMO-AP, :V1PARAMRAMO-RAMO-VGAPC, :V1PARAMRAMO-RAMO-SAUDE, :V1PARAMRAMO-RAMO-EDUCACAO FROM SEGUROS.V1PARAMRAMO END-EXEC. */

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
        /*" M-000-600-PROCESSA-RELATORIOS-SECTION */
        private void M_000_600_PROCESSA_RELATORIOS_SECTION()
        {
            /*" -586- MOVE '000-600-PROCESSA-RELATORIOS' TO PARAGRAFO. */
            _.Move("000-600-PROCESSA-RELATORIOS", FILLER_0.WABEND.PARAGRAFO);

            /*" -587- PERFORM 100-100-DECLARE-HISTMEST. */

            M_100_100_DECLARE_HISTMEST_SECTION();

            /*" -589- PERFORM 100-200-FETCH-HISTMEST. */

            M_100_200_FETCH_HISTMEST_SECTION();

            /*" -590- IF W-FIM-HISTMEST EQUAL 'S' */

            if (FILLER_0.W_FIM_HISTMEST == "S")
            {

                /*" -591- PERFORM 000-400-FETCH-RELATORIOS */

                M_000_400_FETCH_RELATORIOS_SECTION();

                /*" -593- GO TO 000-600-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_600_EXIT*/ //GOTO
                return;
            }


            /*" -596- PERFORM 100-300-PROCESSA-HISTMEST UNTIL W-FIM-HISTMEST EQUAL 'S' . */

            while (!(FILLER_0.W_FIM_HISTMEST == "S"))
            {

                M_100_300_PROCESSA_HISTMEST_SECTION();
            }

            /*" -597- PERFORM 100-400-QUEBRA-GERAL. */

            M_100_400_QUEBRA_GERAL_SECTION();

            /*" -597- PERFORM 000-400-FETCH-RELATORIOS. */

            M_000_400_FETCH_RELATORIOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_600_EXIT*/

        [StopWatch]
        /*" M-000-700-FINALIZA-SECTION */
        private void M_000_700_FINALIZA_SECTION()
        {
            /*" -607- MOVE '000-700-FINALIZA' TO PARAGRAFO. */
            _.Move("000-700-FINALIZA", FILLER_0.WABEND.PARAGRAFO);

            /*" -608- IF W-LIDOS NOT EQUAL ZEROES */

            if (FILLER_0.W_LIDOS != 00)
            {

                /*" -609- DISPLAY 'TOTAL LIDOS EMISSAO       = ' W-LIDOS */
                _.Display($"TOTAL LIDOS EMISSAO       = {FILLER_0.W_LIDOS}");

                /*" -611- DISPLAY 'TOTAL IMPRESSOS EMISSAO   = ' W-IMPRESSOS. */
                _.Display($"TOTAL IMPRESSOS EMISSAO   = {FILLER_0.W_IMPRESSOS}");
            }


            /*" -613- MOVE ZEROES TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -615- DISPLAY 'SI0111B *** FIM NORMAL ***' . */
            _.Display($"SI0111B *** FIM NORMAL ***");

            /*" -617- CLOSE SI0111M1. */
            SI0111M1.Close();

            /*" -617- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_700_EXIT*/

        [StopWatch]
        /*" M-000-800-UPDATE-V1RELATORIOS-SECTION */
        private void M_000_800_UPDATE_V1RELATORIOS_SECTION()
        {
            /*" -626- MOVE '000-800-UPDATE-V1RELATORIOS' TO PARAGRAFO. */
            _.Move("000-800-UPDATE-V1RELATORIOS", FILLER_0.WABEND.PARAGRAFO);

            /*" -630- MOVE '004' TO WNR-EXEC-SQL. */
            _.Move("004", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -638- PERFORM M_000_800_UPDATE_V1RELATORIOS_DB_DELETE_1 */

            M_000_800_UPDATE_V1RELATORIOS_DB_DELETE_1();

        }

        [StopWatch]
        /*" M-000-800-UPDATE-V1RELATORIOS-DB-DELETE-1 */
        public void M_000_800_UPDATE_V1RELATORIOS_DB_DELETE_1()
        {
            /*" -638- EXEC SQL DELETE FROM SEGUROS.V0RELATORIOS WHERE IDSISTEM = 'SI' AND CODRELAT = 'SI0111B' AND DATA_SOLICITACAO = :V1SISTEMA-DTMOVABE END-EXEC. */

            var m_000_800_UPDATE_V1RELATORIOS_DB_DELETE_1_Delete1 = new M_000_800_UPDATE_V1RELATORIOS_DB_DELETE_1_Delete1()
            {
                V1SISTEMA_DTMOVABE = V1SISTEMA_DTMOVABE.ToString(),
            };

            M_000_800_UPDATE_V1RELATORIOS_DB_DELETE_1_Delete1.Execute(m_000_800_UPDATE_V1RELATORIOS_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_800_EXIT*/

        [StopWatch]
        /*" M-100-100-DECLARE-HISTMEST-SECTION */
        private void M_100_100_DECLARE_HISTMEST_SECTION()
        {
            /*" -649- MOVE '100-100-DECLARE-HISTMEST' TO PARAGRAFO. */
            _.Move("100-100-DECLARE-HISTMEST", FILLER_0.WABEND.PARAGRAFO);

            /*" -653- MOVE '005' TO WNR-EXEC-SQL. */
            _.Move("005", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -696- PERFORM M_100_100_DECLARE_HISTMEST_DB_DECLARE_1 */

            M_100_100_DECLARE_HISTMEST_DB_DECLARE_1();

            /*" -700- PERFORM M_100_100_DECLARE_HISTMEST_DB_OPEN_1 */

            M_100_100_DECLARE_HISTMEST_DB_OPEN_1();

        }

        [StopWatch]
        /*" M-100-100-DECLARE-HISTMEST-DB-OPEN-1 */
        public void M_100_100_DECLARE_HISTMEST_DB_OPEN_1()
        {
            /*" -700- EXEC SQL OPEN HISTMEST END-EXEC. */

            HISTMEST.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_100_EXIT*/

        [StopWatch]
        /*" M-100-200-FETCH-HISTMEST-SECTION */
        private void M_100_200_FETCH_HISTMEST_SECTION()
        {
            /*" -710- MOVE '100-200-FETCH-HISTMEST' TO PARAGRAFO. */
            _.Move("100-200-FETCH-HISTMEST", FILLER_0.WABEND.PARAGRAFO);

            /*" -732- PERFORM M_100_200_FETCH_HISTMEST_DB_FETCH_1 */

            M_100_200_FETCH_HISTMEST_DB_FETCH_1();

            /*" -735- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -735- PERFORM M_100_200_FETCH_HISTMEST_DB_CLOSE_1 */

                M_100_200_FETCH_HISTMEST_DB_CLOSE_1();

                /*" -737- MOVE 'S' TO W-FIM-HISTMEST */
                _.Move("S", FILLER_0.W_FIM_HISTMEST);

                /*" -738- ELSE */
            }
            else
            {


                /*" -740- ADD 1 TO W-LIDOS */
                FILLER_0.W_LIDOS.Value = FILLER_0.W_LIDOS + 1;

                /*" -741- MOVE V1HISTMEST-LIMCRR TO WDATA */
                _.Move(V1HISTMEST_LIMCRR, FILLER_0.WDATA);

                /*" -742- MOVE WDATA-DD TO WDATA-DD-CABEC */
                _.Move(FILLER_0.WDATA.WDATA_DD, FILLER_0.WDATA_CABEC.WDATA_DD_CABEC);

                /*" -743- MOVE WDATA-MM TO WDATA-MM-CABEC */
                _.Move(FILLER_0.WDATA.WDATA_MM, FILLER_0.WDATA_CABEC.WDATA_MM_CABEC);

                /*" -744- MOVE WDATA-AA TO WDATA-AA-CABEC */
                _.Move(FILLER_0.WDATA.WDATA_AA, FILLER_0.WDATA_CABEC.WDATA_AA_CABEC);

                /*" -746- MOVE WDATA-CABEC TO LD01-LIMCRR */
                _.Move(FILLER_0.WDATA_CABEC, FILLER_0.LD01.LD01_LIMCRR);

                /*" -747- MOVE V1HISTMEST-DATCMD TO WDATA */
                _.Move(V1HISTMEST_DATCMD, FILLER_0.WDATA);

                /*" -748- MOVE WDATA-DD TO WDATA-DD-CABEC */
                _.Move(FILLER_0.WDATA.WDATA_DD, FILLER_0.WDATA_CABEC.WDATA_DD_CABEC);

                /*" -749- MOVE WDATA-MM TO WDATA-MM-CABEC */
                _.Move(FILLER_0.WDATA.WDATA_MM, FILLER_0.WDATA_CABEC.WDATA_MM_CABEC);

                /*" -750- MOVE WDATA-AA TO WDATA-AA-CABEC */
                _.Move(FILLER_0.WDATA.WDATA_AA, FILLER_0.WDATA_CABEC.WDATA_AA_CABEC);

                /*" -752- MOVE WDATA-CABEC TO LD01-DATCMD */
                _.Move(FILLER_0.WDATA_CABEC, FILLER_0.LD01.LD01_DATCMD);

                /*" -753- MOVE V1HISTMEST-DATORR TO WDATA */
                _.Move(V1HISTMEST_DATORR, FILLER_0.WDATA);

                /*" -754- MOVE WDATA-DD TO WDATA-DD-CABEC */
                _.Move(FILLER_0.WDATA.WDATA_DD, FILLER_0.WDATA_CABEC.WDATA_DD_CABEC);

                /*" -755- MOVE WDATA-MM TO WDATA-MM-CABEC */
                _.Move(FILLER_0.WDATA.WDATA_MM, FILLER_0.WDATA_CABEC.WDATA_MM_CABEC);

                /*" -756- MOVE WDATA-AA TO WDATA-AA-CABEC */
                _.Move(FILLER_0.WDATA.WDATA_AA, FILLER_0.WDATA_CABEC.WDATA_AA_CABEC);

                /*" -758- MOVE WDATA-CABEC TO LD01-DATORR */
                _.Move(FILLER_0.WDATA_CABEC, FILLER_0.LD01.LD01_DATORR);

                /*" -759- MOVE V1HISTMEST-NOMFAV TO LD02-NOMFAV */
                _.Move(V1HISTMEST_NOMFAV, FILLER_0.LD02.LD02_NOMFAV);

                /*" -760- MOVE V1HISTMEST-ESTADO TO LD01-ESTADO */
                _.Move(V1HISTMEST_ESTADO, FILLER_0.LD01.LD01_ESTADO);

                /*" -762- MOVE V1HISTMEST-VAL-OPERACAO2 TO LD01-VAL-OPERACAO2 */
                _.Move(V1HISTMEST_VAL_OPERACAO2, FILLER_0.LD01.LD01_VAL_OPERACAO2);

                /*" -764- PERFORM 200-100-SELECT-V1CLIENTE */

                M_200_100_SELECT_V1CLIENTE_SECTION();

                /*" -765- IF V1HISTMEST-OPERACAO EQUAL 1009 */

                if (V1HISTMEST_OPERACAO == 1009)
                {

                    /*" -766- MOVE 1081 TO V1HISTSINI-OPERACAO1 */
                    _.Move(1081, V1HISTSINI_OPERACAO1);

                    /*" -767- MOVE 1084 TO V1HISTSINI-OPERACAO2 */
                    _.Move(1084, V1HISTSINI_OPERACAO2);

                    /*" -768- PERFORM 200-200-SELECT-V1HISTSINI */

                    M_200_200_SELECT_V1HISTSINI_SECTION();

                    /*" -769- ELSE */
                }
                else
                {


                    /*" -770- COMPUTE V1HISTMEST-OPERACAO = V1HISTMEST-OPERACAO + 80 */
                    V1HISTMEST_OPERACAO.Value = V1HISTMEST_OPERACAO + 80;

                    /*" -771- MOVE V1HISTMEST-OPERACAO TO V1HISTSINI-OPERACAO1 */
                    _.Move(V1HISTMEST_OPERACAO, V1HISTSINI_OPERACAO1);

                    /*" -772- MOVE V1HISTMEST-OPERACAO TO V1HISTSINI-OPERACAO2 */
                    _.Move(V1HISTMEST_OPERACAO, V1HISTSINI_OPERACAO2);

                    /*" -772- PERFORM 200-200-SELECT-V1HISTSINI. */

                    M_200_200_SELECT_V1HISTSINI_SECTION();
                }

            }


        }

        [StopWatch]
        /*" M-100-200-FETCH-HISTMEST-DB-FETCH-1 */
        public void M_100_200_FETCH_HISTMEST_DB_FETCH_1()
        {
            /*" -732- EXEC SQL FETCH HISTMEST INTO :V1HISTMEST-NUM-SINISTRO, :V1HISTMEST-VAL-OPERACAO2, :V1HISTMEST-NUM-APOLICE, :V1HISTMEST-OCORHIST, :V1HISTMEST-OPERACAO, :V1HISTMEST-IDTPSEGU, :V1HISTMEST-CODSUBES, :V1HISTMEST-NRCERTIF, :V1HISTMEST-MODALIDA, :V1HISTMEST-ESTADO, :V1HISTMEST-NOMFAV, :V1HISTMEST-LIMCRR, :V1HISTMEST-DATCMD, :V1HISTMEST-DATORR, :V1HISTMEST-FONTE, :V1HISTMEST-RAMO, :V1HISTMEST-NOME END-EXEC. */

            if (HISTMEST.Fetch())
            {
                _.Move(HISTMEST.V1HISTMEST_NUM_SINISTRO, V1HISTMEST_NUM_SINISTRO);
                _.Move(HISTMEST.V1HISTMEST_VAL_OPERACAO2, V1HISTMEST_VAL_OPERACAO2);
                _.Move(HISTMEST.V1HISTMEST_NUM_APOLICE, V1HISTMEST_NUM_APOLICE);
                _.Move(HISTMEST.V1HISTMEST_OCORHIST, V1HISTMEST_OCORHIST);
                _.Move(HISTMEST.V1HISTMEST_OPERACAO, V1HISTMEST_OPERACAO);
                _.Move(HISTMEST.V1HISTMEST_IDTPSEGU, V1HISTMEST_IDTPSEGU);
                _.Move(HISTMEST.V1HISTMEST_CODSUBES, V1HISTMEST_CODSUBES);
                _.Move(HISTMEST.V1HISTMEST_NRCERTIF, V1HISTMEST_NRCERTIF);
                _.Move(HISTMEST.V1HISTMEST_MODALIDA, V1HISTMEST_MODALIDA);
                _.Move(HISTMEST.V1HISTMEST_ESTADO, V1HISTMEST_ESTADO);
                _.Move(HISTMEST.V1HISTMEST_NOMFAV, V1HISTMEST_NOMFAV);
                _.Move(HISTMEST.V1HISTMEST_LIMCRR, V1HISTMEST_LIMCRR);
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
            /*" -735- EXEC SQL CLOSE HISTMEST END-EXEC */

            HISTMEST.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_200_EXIT*/

        [StopWatch]
        /*" M-100-300-PROCESSA-HISTMEST-SECTION */
        private void M_100_300_PROCESSA_HISTMEST_SECTION()
        {
            /*" -782- MOVE '100-300-PROCESSA-HISTMEST' TO PARAGRAFO. */
            _.Move("100-300-PROCESSA-HISTMEST", FILLER_0.WABEND.PARAGRAFO);

            /*" -783- MOVE V1HISTMEST-RAMO TO LC05-RAMO. */
            _.Move(V1HISTMEST_RAMO, FILLER_0.LC05.LC05_RAMO);

            /*" -785- MOVE V1HISTMEST-MODALIDA TO W-MODALIDA-ANT. */
            _.Move(V1HISTMEST_MODALIDA, FILLER_0.W_MODALIDA_ANT);

            /*" -787- PERFORM 200-300-SELECT-V1RAMO. */

            M_200_300_SELECT_V1RAMO_SECTION();

            /*" -792- PERFORM 200-400-PROCESSA-RAMO UNTIL W-FIM-HISTMEST EQUAL 'S' OR V1HISTMEST-RAMO NOT EQUAL LC05-RAMO OR V1HISTMEST-MODALIDA NOT EQUAL W-MODALIDA-ANT. */

            while (!(FILLER_0.W_FIM_HISTMEST == "S" || V1HISTMEST_RAMO != FILLER_0.LC05.LC05_RAMO || V1HISTMEST_MODALIDA != FILLER_0.W_MODALIDA_ANT))
            {

                M_200_400_PROCESSA_RAMO_SECTION();
            }

            /*" -792- PERFORM 200-500-QUEBRA-RAMO. */

            M_200_500_QUEBRA_RAMO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_300_EXIT*/

        [StopWatch]
        /*" M-100-400-QUEBRA-GERAL-SECTION */
        private void M_100_400_QUEBRA_GERAL_SECTION()
        {
            /*" -802- MOVE '100-400-QUEBRA-GERAL' TO PARAGRAFO. */
            _.Move("100-400-QUEBRA-GERAL", FILLER_0.WABEND.PARAGRAFO);

            /*" -803- MOVE 'TOTAL GERAL' TO LC06-NOMEFTE LC05-NOMERAMO. */
            _.Move("TOTAL GERAL", FILLER_0.LC06.LC06_NOMEFTE, FILLER_0.LC05.LC05_NOMERAMO);

            /*" -805- MOVE 999 TO LC06-FONTE LC05-RAMO. */
            _.Move(999, FILLER_0.LC06.LC06_FONTE, FILLER_0.LC05.LC05_RAMO);

            /*" -807- PERFORM 500-100-IMPRIME-CABECALHO. */

            M_500_100_IMPRIME_CABECALHO_SECTION();

            /*" -808- MOVE W-ACC-GERAL1 TO LT03-ACC-GERAL1. */
            _.Move(FILLER_0.W_ACC_GERAL1, FILLER_0.LT03.LT03_ACC_GERAL1);

            /*" -810- MOVE W-ACC-GERAL2 TO LT03-ACC-GERAL2. */
            _.Move(FILLER_0.W_ACC_GERAL2, FILLER_0.LT03.LT03_ACC_GERAL2);

            /*" -812- WRITE REG-SI0111M1 FROM LT03 AFTER 6. */
            _.Move(FILLER_0.LT03.GetMoveValues(), REG_SI0111M1);

            SI0111M1.Write(REG_SI0111M1.GetMoveValues().ToString());

            /*" -812- MOVE 70 TO W-CONT-LIN. */
            _.Move(70, FILLER_0.W_CONT_LIN);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_400_EXIT*/

        [StopWatch]
        /*" M-200-100-SELECT-V1CLIENTE-SECTION */
        private void M_200_100_SELECT_V1CLIENTE_SECTION()
        {
            /*" -822- MOVE '200-100-SELECT-V1CLIENTE' TO PARAGRAFO. */
            _.Move("200-100-SELECT-V1CLIENTE", FILLER_0.WABEND.PARAGRAFO);

            /*" -823- IF V1HISTMEST-NUM-SINISTRO EQUAL LD01-SINISTRO */

            if (V1HISTMEST_NUM_SINISTRO == FILLER_0.LD01.LD01_SINISTRO)
            {

                /*" -825- GO TO 200-100-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_200_100_EXIT*/ //GOTO
                return;
            }


            /*" -827- MOVE V1HISTMEST-NUM-SINISTRO TO LD01-SINISTRO. */
            _.Move(V1HISTMEST_NUM_SINISTRO, FILLER_0.LD01.LD01_SINISTRO);

            /*" -829- IF V1HISTMEST-IDTPSEGU EQUAL '8' OR V1HISTMEST-IDTPSEGU EQUAL '9' */

            if (V1HISTMEST_IDTPSEGU == "8" || V1HISTMEST_IDTPSEGU == "9")
            {

                /*" -831- MOVE '1' TO V1HISTMEST-IDTPSEGU. */
                _.Move("1", V1HISTMEST_IDTPSEGU);
            }


            /*" -837- IF V1HISTMEST-RAMO EQUAL V1PARAMRAMO-RAMO-VG OR V1HISTMEST-RAMO EQUAL V1PARAMRAMO-RAMO-AP OR V1HISTMEST-RAMO EQUAL V1PARAMRAMO-RAMO-VGAPC OR V1HISTMEST-RAMO EQUAL V1PARAMRAMO-RAMO-SAUDE OR V1HISTMEST-RAMO EQUAL V1PARAMRAMO-RAMO-EDUCACAO */

            if (V1HISTMEST_RAMO == V1PARAMRAMO_RAMO_VG || V1HISTMEST_RAMO == V1PARAMRAMO_RAMO_AP || V1HISTMEST_RAMO == V1PARAMRAMO_RAMO_VGAPC || V1HISTMEST_RAMO == V1PARAMRAMO_RAMO_SAUDE || V1HISTMEST_RAMO == V1PARAMRAMO_RAMO_EDUCACAO)
            {

                /*" -840- IF V1HISTMEST-RAMO NOT EQUAL V1PARAMRAMO-RAMO-AP OR V1HISTMEST-NRCERTIF NOT EQUAL ZEROES OR V1HISTMEST-IDTPSEGU NOT EQUAL SPACES */

                if (V1HISTMEST_RAMO != V1PARAMRAMO_RAMO_AP || V1HISTMEST_NRCERTIF != 00 || !V1HISTMEST_IDTPSEGU.IsEmpty())
                {

                    /*" -841- PERFORM 300-100-SELECT-V1CLIENTE1 */

                    M_300_100_SELECT_V1CLIENTE1_SECTION();

                    /*" -842- ELSE */
                }
                else
                {


                    /*" -843- PERFORM 300-200-SELECT-V1CLIENTE2 */

                    M_300_200_SELECT_V1CLIENTE2_SECTION();

                    /*" -845- ELSE */
                }

            }
            else
            {


                /*" -846- IF V1HISTMEST-RAMO NOT EQUAL 32 */

                if (V1HISTMEST_RAMO != 32)
                {

                    /*" -847- PERFORM 300-200-SELECT-V1CLIENTE2 */

                    M_300_200_SELECT_V1CLIENTE2_SECTION();

                    /*" -848- ELSE */
                }
                else
                {


                    /*" -848- PERFORM 300-300-SELECT-V1CLIENTE3. */

                    M_300_300_SELECT_V1CLIENTE3_SECTION();
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_200_100_EXIT*/

        [StopWatch]
        /*" M-200-200-SELECT-V1HISTSINI-SECTION */
        private void M_200_200_SELECT_V1HISTSINI_SECTION()
        {
            /*" -857- MOVE '200-200-SELECT-V1HISTSINI' TO PARAGRAFO. */
            _.Move("200-200-SELECT-V1HISTSINI", FILLER_0.WABEND.PARAGRAFO);

            /*" -861- MOVE '006' TO WNR-EXEC-SQL. */
            _.Move("006", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -876- PERFORM M_200_200_SELECT_V1HISTSINI_DB_SELECT_1 */

            M_200_200_SELECT_V1HISTSINI_DB_SELECT_1();

            /*" -881- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -886- DISPLAY W-MENSAGEM5 */
                _.Display(FILLER_0.FILLER_89.W_MENSAGEM5);

                /*" -887- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -888- ELSE */
            }
            else
            {


                /*" -890- MOVE V1HISTMEST-VAL-OPERACAO1 TO LD01-VAL-OPERACAO1 */
                _.Move(V1HISTMEST_VAL_OPERACAO1, FILLER_0.LD01.LD01_VAL_OPERACAO1);

                /*" -891- SUBTRACT 1080 FROM V1HISTMEST-OPERACAO. */
                V1HISTMEST_OPERACAO.Value = V1HISTMEST_OPERACAO - 1080;
            }


            /*" -892- SET IND TO V1HISTMEST-OPERACAO. */
            IND.Value = V1HISTMEST_OPERACAO;

            /*" -892- MOVE TAB-OPERACAO(IND) TO LD01-OPERACAO. */
            _.Move(FILLER_0.FILLER_75[IND].TAB_OPERACAO, FILLER_0.LD01.LD01_OPERACAO);

        }

        [StopWatch]
        /*" M-200-200-SELECT-V1HISTSINI-DB-SELECT-1 */
        public void M_200_200_SELECT_V1HISTSINI_DB_SELECT_1()
        {
            /*" -876- EXEC SQL SELECT VAL_OPERACAO, OPERACAO INTO :V1HISTMEST-VAL-OPERACAO1, :V1HISTMEST-OPERACAO FROM SEGUROS.V1HISTSINI WHERE NUM_APOL_SINISTRO = :V1HISTMEST-NUM-SINISTRO AND OCORHIST = :V1HISTMEST-OCORHIST AND OPERACAO >= :V1HISTSINI-OPERACAO1 AND OPERACAO <= :V1HISTSINI-OPERACAO2 END-EXEC. */

            var m_200_200_SELECT_V1HISTSINI_DB_SELECT_1_Query1 = new M_200_200_SELECT_V1HISTSINI_DB_SELECT_1_Query1()
            {
                V1HISTMEST_NUM_SINISTRO = V1HISTMEST_NUM_SINISTRO.ToString(),
                V1HISTSINI_OPERACAO1 = V1HISTSINI_OPERACAO1.ToString(),
                V1HISTSINI_OPERACAO2 = V1HISTSINI_OPERACAO2.ToString(),
                V1HISTMEST_OCORHIST = V1HISTMEST_OCORHIST.ToString(),
            };

            var executed_1 = M_200_200_SELECT_V1HISTSINI_DB_SELECT_1_Query1.Execute(m_200_200_SELECT_V1HISTSINI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1HISTMEST_VAL_OPERACAO1, V1HISTMEST_VAL_OPERACAO1);
                _.Move(executed_1.V1HISTMEST_OPERACAO, V1HISTMEST_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_200_200_EXIT*/

        [StopWatch]
        /*" M-200-300-SELECT-V1RAMO-SECTION */
        private void M_200_300_SELECT_V1RAMO_SECTION()
        {
            /*" -901- MOVE '200-300-SELECT-V1RAMO' TO PARAGRAFO. */
            _.Move("200-300-SELECT-V1RAMO", FILLER_0.WABEND.PARAGRAFO);

            /*" -905- MOVE '007' TO WNR-EXEC-SQL. */
            _.Move("007", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -917- PERFORM M_200_300_SELECT_V1RAMO_DB_SELECT_1 */

            M_200_300_SELECT_V1RAMO_DB_SELECT_1();

            /*" -922- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -923- DISPLAY W-MENSAGEM6 */
                _.Display(FILLER_0.FILLER_89.W_MENSAGEM6);

                /*" -924- DISPLAY 'RAMO  = ' V1HISTMEST-RAMO */
                _.Display($"RAMO  = {V1HISTMEST_RAMO}");

                /*" -926- DISPLAY 'MODA  = ' V1HISTMEST-MODALIDA */
                _.Display($"MODA  = {V1HISTMEST_MODALIDA}");

                /*" -927- MOVE SPACES TO LC05-NOMERAMO */
                _.Move("", FILLER_0.LC05.LC05_NOMERAMO);

                /*" -928- ELSE */
            }
            else
            {


                /*" -928- MOVE V1RAMO-NOMERAMO TO LC05-NOMERAMO. */
                _.Move(V1RAMO_NOMERAMO, FILLER_0.LC05.LC05_NOMERAMO);
            }


        }

        [StopWatch]
        /*" M-200-300-SELECT-V1RAMO-DB-SELECT-1 */
        public void M_200_300_SELECT_V1RAMO_DB_SELECT_1()
        {
            /*" -917- EXEC SQL SELECT NOMERAMO INTO :V1RAMO-NOMERAMO FROM SEGUROS.V1RAMO WHERE RAMO = :V1HISTMEST-RAMO AND MODALIDA = :V1HISTMEST-MODALIDA END-EXEC. */

            var m_200_300_SELECT_V1RAMO_DB_SELECT_1_Query1 = new M_200_300_SELECT_V1RAMO_DB_SELECT_1_Query1()
            {
                V1HISTMEST_MODALIDA = V1HISTMEST_MODALIDA.ToString(),
                V1HISTMEST_RAMO = V1HISTMEST_RAMO.ToString(),
            };

            var executed_1 = M_200_300_SELECT_V1RAMO_DB_SELECT_1_Query1.Execute(m_200_300_SELECT_V1RAMO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1RAMO_NOMERAMO, V1RAMO_NOMERAMO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_200_300_EXIT*/

        [StopWatch]
        /*" M-200-400-PROCESSA-RAMO-SECTION */
        private void M_200_400_PROCESSA_RAMO_SECTION()
        {
            /*" -938- MOVE '200-400-PROCESSA-RAMO' TO PARAGRAFO. */
            _.Move("200-400-PROCESSA-RAMO", FILLER_0.WABEND.PARAGRAFO);

            /*" -940- MOVE V1HISTMEST-FONTE TO LC06-FONTE. */
            _.Move(V1HISTMEST_FONTE, FILLER_0.LC06.LC06_FONTE);

            /*" -942- PERFORM 300-400-SELECT-V1FONTE. */

            M_300_400_SELECT_V1FONTE_SECTION();

            /*" -948- PERFORM 300-500-PROCESSA-FONTE UNTIL W-FIM-HISTMEST EQUAL 'S' OR V1HISTMEST-RAMO NOT EQUAL LC05-RAMO OR V1HISTMEST-FONTE NOT EQUAL LC06-FONTE OR V1HISTMEST-MODALIDA NOT EQUAL W-MODALIDA-ANT. */

            while (!(FILLER_0.W_FIM_HISTMEST == "S" || V1HISTMEST_RAMO != FILLER_0.LC05.LC05_RAMO || V1HISTMEST_FONTE != FILLER_0.LC06.LC06_FONTE || V1HISTMEST_MODALIDA != FILLER_0.W_MODALIDA_ANT))
            {

                M_300_500_PROCESSA_FONTE_SECTION();
            }

            /*" -948- PERFORM 300-600-QUEBRA-FONTE. */

            M_300_600_QUEBRA_FONTE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_200_400_EXIT*/

        [StopWatch]
        /*" M-200-500-QUEBRA-RAMO-SECTION */
        private void M_200_500_QUEBRA_RAMO_SECTION()
        {
            /*" -958- MOVE '200-500-QUEBRA-RAMO' TO PARAGRAFO. */
            _.Move("200-500-QUEBRA-RAMO", FILLER_0.WABEND.PARAGRAFO);

            /*" -959- ADD W-ACC-RAMO1 TO W-ACC-GERAL1. */
            FILLER_0.W_ACC_GERAL1.Value = FILLER_0.W_ACC_GERAL1 + FILLER_0.W_ACC_RAMO1;

            /*" -960- ADD W-ACC-RAMO2 TO W-ACC-GERAL2. */
            FILLER_0.W_ACC_GERAL2.Value = FILLER_0.W_ACC_GERAL2 + FILLER_0.W_ACC_RAMO2;

            /*" -961- MOVE W-ACC-RAMO1 TO LT02-ACC-RAMO1. */
            _.Move(FILLER_0.W_ACC_RAMO1, FILLER_0.LT02.LT02_ACC_RAMO1);

            /*" -962- MOVE W-ACC-RAMO2 TO LT02-ACC-RAMO2. */
            _.Move(FILLER_0.W_ACC_RAMO2, FILLER_0.LT02.LT02_ACC_RAMO2);

            /*" -963- MOVE 00 TO W-ACC-RAMO1. */
            _.Move(00, FILLER_0.W_ACC_RAMO1);

            /*" -964- MOVE 00 TO W-ACC-RAMO2. */
            _.Move(00, FILLER_0.W_ACC_RAMO2);

            /*" -966- MOVE 70 TO W-CONT-LIN. */
            _.Move(70, FILLER_0.W_CONT_LIN);

            /*" -966- WRITE REG-SI0111M1 FROM LT02 AFTER 3. */
            _.Move(FILLER_0.LT02.GetMoveValues(), REG_SI0111M1);

            SI0111M1.Write(REG_SI0111M1.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_200_500_EXIT*/

        [StopWatch]
        /*" M-300-100-SELECT-V1CLIENTE1-SECTION */
        private void M_300_100_SELECT_V1CLIENTE1_SECTION()
        {
            /*" -975- MOVE '300-100-SELECT-V1CLIENTE1' TO PARAGRAFO */
            _.Move("300-100-SELECT-V1CLIENTE1", FILLER_0.WABEND.PARAGRAFO);

            /*" -979- MOVE '008' TO WNR-EXEC-SQL */
            _.Move("008", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -998- PERFORM M_300_100_SELECT_V1CLIENTE1_DB_SELECT_1 */

            M_300_100_SELECT_V1CLIENTE1_DB_SELECT_1();

            /*" -1003- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1009- DISPLAY W-MENSAGEM7 */
                _.Display(FILLER_0.FILLER_89.W_MENSAGEM7);

                /*" -1010- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1011- ELSE */
            }
            else
            {


                /*" -1011- MOVE V1CLIENTE-NOME-RAZAO TO LD01-NOME. */
                _.Move(V1CLIENTE_NOME_RAZAO, FILLER_0.LD01.LD01_NOME);
            }


        }

        [StopWatch]
        /*" M-300-100-SELECT-V1CLIENTE1-DB-SELECT-1 */
        public void M_300_100_SELECT_V1CLIENTE1_DB_SELECT_1()
        {
            /*" -998- EXEC SQL SELECT NOME_RAZAO INTO :V1CLIENTE-NOME-RAZAO FROM SEGUROS.V1CLIENTE WHERE COD_CLIENTE = ( SELECT COD_CLIENTE FROM SEGUROS.V1SEGURAVG WHERE NUM_APOLICE = :V1HISTMEST-NUM-APOLICE AND COD_SUBGRUPO = :V1HISTMEST-CODSUBES AND NUM_CERTIFICADO = :V1HISTMEST-NRCERTIF AND TIPO_SEGURADO = :V1HISTMEST-IDTPSEGU ) END-EXEC */

            var m_300_100_SELECT_V1CLIENTE1_DB_SELECT_1_Query1 = new M_300_100_SELECT_V1CLIENTE1_DB_SELECT_1_Query1()
            {
                V1HISTMEST_NUM_APOLICE = V1HISTMEST_NUM_APOLICE.ToString(),
                V1HISTMEST_CODSUBES = V1HISTMEST_CODSUBES.ToString(),
                V1HISTMEST_NRCERTIF = V1HISTMEST_NRCERTIF.ToString(),
                V1HISTMEST_IDTPSEGU = V1HISTMEST_IDTPSEGU.ToString(),
            };

            var executed_1 = M_300_100_SELECT_V1CLIENTE1_DB_SELECT_1_Query1.Execute(m_300_100_SELECT_V1CLIENTE1_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1CLIENTE_NOME_RAZAO, V1CLIENTE_NOME_RAZAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_300_100_EXIT*/

        [StopWatch]
        /*" M-300-200-SELECT-V1CLIENTE2-SECTION */
        private void M_300_200_SELECT_V1CLIENTE2_SECTION()
        {
            /*" -1020- MOVE '300-200-SELECT-V1CLIENTE2' TO PARAGRAFO */
            _.Move("300-200-SELECT-V1CLIENTE2", FILLER_0.WABEND.PARAGRAFO);

            /*" -1024- MOVE '009' TO WNR-EXEC-SQL */
            _.Move("009", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -1040- PERFORM M_300_200_SELECT_V1CLIENTE2_DB_SELECT_1 */

            M_300_200_SELECT_V1CLIENTE2_DB_SELECT_1();

            /*" -1045- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1046- DISPLAY W-MENSAGEM7 */
                _.Display(FILLER_0.FILLER_89.W_MENSAGEM7);

                /*" -1047- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1048- ELSE */
            }
            else
            {


                /*" -1048- MOVE V1CLIENTE-NOME-RAZAO TO LD01-NOME. */
                _.Move(V1CLIENTE_NOME_RAZAO, FILLER_0.LD01.LD01_NOME);
            }


        }

        [StopWatch]
        /*" M-300-200-SELECT-V1CLIENTE2-DB-SELECT-1 */
        public void M_300_200_SELECT_V1CLIENTE2_DB_SELECT_1()
        {
            /*" -1040- EXEC SQL SELECT NOME_RAZAO INTO :V1CLIENTE-NOME-RAZAO FROM SEGUROS.V1CLIENTE WHERE COD_CLIENTE = ( SELECT COD_CLIENTE FROM SEGUROS.V1SINI_ITEM WHERE NUM_APOL_SINISTRO = :V1HISTMEST-NUM-SINISTRO) END-EXEC */

            var m_300_200_SELECT_V1CLIENTE2_DB_SELECT_1_Query1 = new M_300_200_SELECT_V1CLIENTE2_DB_SELECT_1_Query1()
            {
                V1HISTMEST_NUM_SINISTRO = V1HISTMEST_NUM_SINISTRO.ToString(),
            };

            var executed_1 = M_300_200_SELECT_V1CLIENTE2_DB_SELECT_1_Query1.Execute(m_300_200_SELECT_V1CLIENTE2_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1CLIENTE_NOME_RAZAO, V1CLIENTE_NOME_RAZAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_300_200_EXIT*/

        [StopWatch]
        /*" M-300-300-SELECT-V1CLIENTE3-SECTION */
        private void M_300_300_SELECT_V1CLIENTE3_SECTION()
        {
            /*" -1057- MOVE '300-300-SELECT-V1CLIENTE3' TO PARAGRAFO */
            _.Move("300-300-SELECT-V1CLIENTE3", FILLER_0.WABEND.PARAGRAFO);

            /*" -1061- MOVE '010' TO WNR-EXEC-SQL */
            _.Move("010", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -1077- PERFORM M_300_300_SELECT_V1CLIENTE3_DB_SELECT_1 */

            M_300_300_SELECT_V1CLIENTE3_DB_SELECT_1();

            /*" -1082- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1083- DISPLAY W-MENSAGEM7 */
                _.Display(FILLER_0.FILLER_89.W_MENSAGEM7);

                /*" -1084- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1085- ELSE */
            }
            else
            {


                /*" -1085- MOVE V1CLIENTE-NOME-RAZAO TO LD01-NOME. */
                _.Move(V1CLIENTE_NOME_RAZAO, FILLER_0.LD01.LD01_NOME);
            }


        }

        [StopWatch]
        /*" M-300-300-SELECT-V1CLIENTE3-DB-SELECT-1 */
        public void M_300_300_SELECT_V1CLIENTE3_DB_SELECT_1()
        {
            /*" -1077- EXEC SQL SELECT NOME_RAZAO INTO :V1CLIENTE-NOME-RAZAO FROM SEGUROS.V1CLIENTE WHERE COD_CLIENTE = ( SELECT CODCLIEN FROM SEGUROS.V1APOLICE WHERE NUM_APOLICE = :V1HISTMEST-NUM-APOLICE) END-EXEC */

            var m_300_300_SELECT_V1CLIENTE3_DB_SELECT_1_Query1 = new M_300_300_SELECT_V1CLIENTE3_DB_SELECT_1_Query1()
            {
                V1HISTMEST_NUM_APOLICE = V1HISTMEST_NUM_APOLICE.ToString(),
            };

            var executed_1 = M_300_300_SELECT_V1CLIENTE3_DB_SELECT_1_Query1.Execute(m_300_300_SELECT_V1CLIENTE3_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1CLIENTE_NOME_RAZAO, V1CLIENTE_NOME_RAZAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_300_300_EXIT*/

        [StopWatch]
        /*" M-300-400-SELECT-V1FONTE-SECTION */
        private void M_300_400_SELECT_V1FONTE_SECTION()
        {
            /*" -1094- MOVE '300-400-SELECT-V1FONTE' TO PARAGRAFO. */
            _.Move("300-400-SELECT-V1FONTE", FILLER_0.WABEND.PARAGRAFO);

            /*" -1098- MOVE '011' TO WNR-EXEC-SQL. */
            _.Move("011", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -1108- PERFORM M_300_400_SELECT_V1FONTE_DB_SELECT_1 */

            M_300_400_SELECT_V1FONTE_DB_SELECT_1();

            /*" -1113- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1114- DISPLAY W-MENSAGEM8 */
                _.Display(FILLER_0.FILLER_89.W_MENSAGEM8);

                /*" -1116- DISPLAY 'FONTE = ' V1HISTMEST-FONTE */
                _.Display($"FONTE = {V1HISTMEST_FONTE}");

                /*" -1117- MOVE SPACES TO LC06-NOMEFTE */
                _.Move("", FILLER_0.LC06.LC06_NOMEFTE);

                /*" -1118- ELSE */
            }
            else
            {


                /*" -1118- MOVE V1FONTE-NOMEFTE TO LC06-NOMEFTE. */
                _.Move(V1FONTE_NOMEFTE, FILLER_0.LC06.LC06_NOMEFTE);
            }


        }

        [StopWatch]
        /*" M-300-400-SELECT-V1FONTE-DB-SELECT-1 */
        public void M_300_400_SELECT_V1FONTE_DB_SELECT_1()
        {
            /*" -1108- EXEC SQL SELECT NOMEFTE INTO :V1FONTE-NOMEFTE FROM SEGUROS.V1FONTE WHERE FONTE = :V1HISTMEST-FONTE END-EXEC. */

            var m_300_400_SELECT_V1FONTE_DB_SELECT_1_Query1 = new M_300_400_SELECT_V1FONTE_DB_SELECT_1_Query1()
            {
                V1HISTMEST_FONTE = V1HISTMEST_FONTE.ToString(),
            };

            var executed_1 = M_300_400_SELECT_V1FONTE_DB_SELECT_1_Query1.Execute(m_300_400_SELECT_V1FONTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1FONTE_NOMEFTE, V1FONTE_NOMEFTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_300_400_EXIT*/

        [StopWatch]
        /*" M-300-500-PROCESSA-FONTE-SECTION */
        private void M_300_500_PROCESSA_FONTE_SECTION()
        {
            /*" -1128- MOVE '300-500-PROCESSA-FONTE' TO PARAGRAFO. */
            _.Move("300-500-PROCESSA-FONTE", FILLER_0.WABEND.PARAGRAFO);

            /*" -1129- IF ENCHE EQUAL 1 */

            if (FILLER_0.ENCHE == 1)
            {

                /*" -1130- MOVE V1HISTMEST-NOMFAV TO NOMFAV-ANT */
                _.Move(V1HISTMEST_NOMFAV, FILLER_0.NOMFAV_ANT);

                /*" -1132- MOVE 0 TO ENCHE. */
                _.Move(0, FILLER_0.ENCHE);
            }


            /*" -1133- IF V1HISTMEST-NOMFAV EQUAL NOMFAV-ANT */

            if (V1HISTMEST_NOMFAV == FILLER_0.NOMFAV_ANT)
            {

                /*" -1135- ADD 1 TO WS-AUX. */
                FILLER_0.WS_AUX.Value = FILLER_0.WS_AUX + 1;
            }


            /*" -1136- IF V1HISTMEST-NOMFAV NOT EQUAL NOMFAV-ANT */

            if (V1HISTMEST_NOMFAV != FILLER_0.NOMFAV_ANT)
            {

                /*" -1137- MOVE V1HISTMEST-NOMFAV TO NOMFAV-ANT */
                _.Move(V1HISTMEST_NOMFAV, FILLER_0.NOMFAV_ANT);

                /*" -1138- IF WS-AUX > 1 */

                if (FILLER_0.WS_AUX > 1)
                {

                    /*" -1140- PERFORM 401-100-IMPRIME-TOTNOMFAV */

                    M_401_100_IMPRIME_TOTNOMFAV_SECTION();

                    /*" -1143- MOVE 0 TO WS-AUX. */
                    _.Move(0, FILLER_0.WS_AUX);
                }

            }


            /*" -1144- ADD V1HISTMEST-VAL-OPERACAO2 TO TOTFAV2 */
            FILLER_0.TOTFAV2.Value = FILLER_0.TOTFAV2 + V1HISTMEST_VAL_OPERACAO2;

            /*" -1147- ADD V1HISTMEST-VAL-OPERACAO1 TO TOTFAV1 */
            FILLER_0.TOTFAV1.Value = FILLER_0.TOTFAV1 + V1HISTMEST_VAL_OPERACAO1;

            /*" -1148- PERFORM 400-100-IMPRIME-DETALHE. */

            M_400_100_IMPRIME_DETALHE_SECTION();

            /*" -1148- PERFORM 100-200-FETCH-HISTMEST. */

            M_100_200_FETCH_HISTMEST_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_300_500_EXIT*/

        [StopWatch]
        /*" M-300-600-QUEBRA-FONTE-SECTION */
        private void M_300_600_QUEBRA_FONTE_SECTION()
        {
            /*" -1158- MOVE '300-600-QUEBRA-FONTE' TO PARAGRAFO. */
            _.Move("300-600-QUEBRA-FONTE", FILLER_0.WABEND.PARAGRAFO);

            /*" -1159- ADD W-ACC-FONTE1 TO W-ACC-RAMO1. */
            FILLER_0.W_ACC_RAMO1.Value = FILLER_0.W_ACC_RAMO1 + FILLER_0.W_ACC_FONTE1;

            /*" -1160- ADD W-ACC-FONTE2 TO W-ACC-RAMO2. */
            FILLER_0.W_ACC_RAMO2.Value = FILLER_0.W_ACC_RAMO2 + FILLER_0.W_ACC_FONTE2;

            /*" -1161- MOVE W-ACC-FONTE1 TO LT01-ACC-FONTE1. */
            _.Move(FILLER_0.W_ACC_FONTE1, FILLER_0.LT01.LT01_ACC_FONTE1);

            /*" -1162- MOVE W-ACC-FONTE2 TO LT01-ACC-FONTE2. */
            _.Move(FILLER_0.W_ACC_FONTE2, FILLER_0.LT01.LT01_ACC_FONTE2);

            /*" -1163- MOVE 00 TO W-ACC-FONTE1. */
            _.Move(00, FILLER_0.W_ACC_FONTE1);

            /*" -1165- MOVE 00 TO W-ACC-FONTE2. */
            _.Move(00, FILLER_0.W_ACC_FONTE2);

            /*" -1167- WRITE REG-SI0111M1 FROM LT01 AFTER 3. */
            _.Move(FILLER_0.LT01.GetMoveValues(), REG_SI0111M1);

            SI0111M1.Write(REG_SI0111M1.GetMoveValues().ToString());

            /*" -1168- IF V1HISTMEST-RAMO EQUAL LC05-RAMO */

            if (V1HISTMEST_RAMO == FILLER_0.LC05.LC05_RAMO)
            {

                /*" -1168- MOVE 70 TO W-CONT-LIN. */
                _.Move(70, FILLER_0.W_CONT_LIN);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_300_600_EXIT*/

        [StopWatch]
        /*" M-400-100-IMPRIME-DETALHE-SECTION */
        private void M_400_100_IMPRIME_DETALHE_SECTION()
        {
            /*" -1178- MOVE '400-100-IMPRIME-DETALHE' TO PARAGRAFO. */
            _.Move("400-100-IMPRIME-DETALHE", FILLER_0.WABEND.PARAGRAFO);

            /*" -1179- IF W-CONT-LIN GREATER 57 */

            if (FILLER_0.W_CONT_LIN > 57)
            {

                /*" -1181- PERFORM 500-100-IMPRIME-CABECALHO. */

                M_500_100_IMPRIME_CABECALHO_SECTION();
            }


            /*" -1182- ADD V1HISTMEST-VAL-OPERACAO1 TO W-ACC-FONTE1. */
            FILLER_0.W_ACC_FONTE1.Value = FILLER_0.W_ACC_FONTE1 + V1HISTMEST_VAL_OPERACAO1;

            /*" -1184- ADD V1HISTMEST-VAL-OPERACAO2 TO W-ACC-FONTE2. */
            FILLER_0.W_ACC_FONTE2.Value = FILLER_0.W_ACC_FONTE2 + V1HISTMEST_VAL_OPERACAO2;

            /*" -1185- WRITE REG-SI0111M1 FROM LD01 AFTER 2. */
            _.Move(FILLER_0.LD01.GetMoveValues(), REG_SI0111M1);

            SI0111M1.Write(REG_SI0111M1.GetMoveValues().ToString());

            /*" -1187- WRITE REG-SI0111M1 FROM LD02 AFTER 1. */
            _.Move(FILLER_0.LD02.GetMoveValues(), REG_SI0111M1);

            SI0111M1.Write(REG_SI0111M1.GetMoveValues().ToString());

            /*" -1188- ADD 3 TO W-CONT-LIN. */
            FILLER_0.W_CONT_LIN.Value = FILLER_0.W_CONT_LIN + 3;

            /*" -1188- ADD 1 TO W-IMPRESSOS. */
            FILLER_0.W_IMPRESSOS.Value = FILLER_0.W_IMPRESSOS + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_400_100_EXIT*/

        [StopWatch]
        /*" M-401-100-IMPRIME-TOTNOMFAV-SECTION */
        private void M_401_100_IMPRIME_TOTNOMFAV_SECTION()
        {
            /*" -1198- MOVE '401-100-IMPRIME-DETALHE' TO PARAGRAFO. */
            _.Move("401-100-IMPRIME-DETALHE", FILLER_0.WABEND.PARAGRAFO);

            /*" -1199- IF W-CONT-LIN GREATER 57 */

            if (FILLER_0.W_CONT_LIN > 57)
            {

                /*" -1201- PERFORM 500-100-IMPRIME-CABECALHO. */

                M_500_100_IMPRIME_CABECALHO_SECTION();
            }


            /*" -1202- MOVE TOTFAV1 TO LDPP-TOTFAV1 */
            _.Move(FILLER_0.TOTFAV1, FILLER_0.LDPP.LDPP_TOTFAV1);

            /*" -1204- MOVE TOTFAV2 TO LDPP-TOTFAV2 */
            _.Move(FILLER_0.TOTFAV2, FILLER_0.LDPP.LDPP_TOTFAV2);

            /*" -1206- WRITE REG-SI0111M1 FROM LDPP AFTER 2. */
            _.Move(FILLER_0.LDPP.GetMoveValues(), REG_SI0111M1);

            SI0111M1.Write(REG_SI0111M1.GetMoveValues().ToString());

            /*" -1207- MOVE +0 TO TOTFAV1 */
            _.Move(+0, FILLER_0.TOTFAV1);

            /*" -1209- MOVE +0 TO TOTFAV2 */
            _.Move(+0, FILLER_0.TOTFAV2);

            /*" -1210- ADD 3 TO W-CONT-LIN. */
            FILLER_0.W_CONT_LIN.Value = FILLER_0.W_CONT_LIN + 3;

            /*" -1210- ADD 1 TO W-IMPRESSOS. */
            FILLER_0.W_IMPRESSOS.Value = FILLER_0.W_IMPRESSOS + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_401_100_EXIT*/

        [StopWatch]
        /*" M-500-100-IMPRIME-CABECALHO-SECTION */
        private void M_500_100_IMPRIME_CABECALHO_SECTION()
        {
            /*" -1220- MOVE '500-100-IMPRIME-CABECALHO' TO PARAGRAFO. */
            _.Move("500-100-IMPRIME-CABECALHO", FILLER_0.WABEND.PARAGRAFO);

            /*" -1222- ADD 1 TO W-CONT-PAG. */
            FILLER_0.W_CONT_PAG.Value = FILLER_0.W_CONT_PAG + 1;

            /*" -1224- MOVE W-CONT-PAG TO LC01-PAGINA. */
            _.Move(FILLER_0.W_CONT_PAG, FILLER_0.LC01.LC01_PAGINA);

            /*" -1225- WRITE REG-SI0111M1 FROM LC01 AFTER NEW-PAGE. */
            _.Move(FILLER_0.LC01.GetMoveValues(), REG_SI0111M1);

            SI0111M1.Write(REG_SI0111M1.GetMoveValues().ToString());

            /*" -1226- WRITE REG-SI0111M1 FROM LC02 AFTER 1. */
            _.Move(FILLER_0.LC02.GetMoveValues(), REG_SI0111M1);

            SI0111M1.Write(REG_SI0111M1.GetMoveValues().ToString());

            /*" -1227- WRITE REG-SI0111M1 FROM LC03 AFTER 1. */
            _.Move(FILLER_0.LC03.GetMoveValues(), REG_SI0111M1);

            SI0111M1.Write(REG_SI0111M1.GetMoveValues().ToString());

            /*" -1229- WRITE REG-SI0111M1 FROM LC04 AFTER 1. */
            _.Move(FILLER_0.LC04.GetMoveValues(), REG_SI0111M1);

            SI0111M1.Write(REG_SI0111M1.GetMoveValues().ToString());

            /*" -1230- IF V1RELATORIOS-APOLICE1 EQUAL ZEROES */

            if (V1RELATORIOS_APOLICE1 == 00)
            {

                /*" -1231- WRITE REG-SI0111M1 FROM LC05 AFTER 2 */
                _.Move(FILLER_0.LC05.GetMoveValues(), REG_SI0111M1);

                SI0111M1.Write(REG_SI0111M1.GetMoveValues().ToString());

                /*" -1232- ELSE */
            }
            else
            {


                /*" -1233- MOVE V1RELATORIOS-APOLICE1 TO LC09-APOLICE */
                _.Move(V1RELATORIOS_APOLICE1, FILLER_0.LC09.LC09_APOLICE);

                /*" -1235- MOVE V1HISTMEST-NOME TO LC09-NOME-APOLICE */
                _.Move(V1HISTMEST_NOME, FILLER_0.LC09.LC09_NOME_APOLICE);

                /*" -1236- WRITE REG-SI0111M1 FROM LC09 AFTER 1 */
                _.Move(FILLER_0.LC09.GetMoveValues(), REG_SI0111M1);

                SI0111M1.Write(REG_SI0111M1.GetMoveValues().ToString());

                /*" -1238- WRITE REG-SI0111M1 FROM LC05 AFTER 1. */
                _.Move(FILLER_0.LC05.GetMoveValues(), REG_SI0111M1);

                SI0111M1.Write(REG_SI0111M1.GetMoveValues().ToString());
            }


            /*" -1239- WRITE REG-SI0111M1 FROM LC06 AFTER 1. */
            _.Move(FILLER_0.LC06.GetMoveValues(), REG_SI0111M1);

            SI0111M1.Write(REG_SI0111M1.GetMoveValues().ToString());

            /*" -1240- WRITE REG-SI0111M1 FROM LC07 AFTER 1. */
            _.Move(FILLER_0.LC07.GetMoveValues(), REG_SI0111M1);

            SI0111M1.Write(REG_SI0111M1.GetMoveValues().ToString());

            /*" -1241- WRITE REG-SI0111M1 FROM LC08 AFTER 1. */
            _.Move(FILLER_0.LC08.GetMoveValues(), REG_SI0111M1);

            SI0111M1.Write(REG_SI0111M1.GetMoveValues().ToString());

            /*" -1243- WRITE REG-SI0111M1 FROM LC07 AFTER 1. */
            _.Move(FILLER_0.LC07.GetMoveValues(), REG_SI0111M1);

            SI0111M1.Write(REG_SI0111M1.GetMoveValues().ToString());

            /*" -1243- MOVE 10 TO W-CONT-LIN. */
            _.Move(10, FILLER_0.W_CONT_LIN);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_500_100_EXIT*/

        [StopWatch]
        /*" M-999-999-ROT-ERRO-SECTION */
        private void M_999_999_ROT_ERRO_SECTION()
        {
            /*" -1253- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1254- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], FILLER_0.WABEND.WSQLCODE1);

                /*" -1255- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], FILLER_0.WABEND.WSQLCODE2);

                /*" -1256- MOVE SQLCODE TO WSQLCODE3 */
                _.Move(DB.SQLCODE, FILLER_0.WSQLCODE3);

                /*" -1258- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, FILLER_0.WABEND.WSQLCODE);

                /*" -1260- DISPLAY WABEND. */
                _.Display(FILLER_0.WABEND);
            }


            /*" -1262- CLOSE SI0111M1. */
            SI0111M1.Close();

            /*" -1262- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1263- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1266- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1266- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_999_999_EXIT*/
    }
}