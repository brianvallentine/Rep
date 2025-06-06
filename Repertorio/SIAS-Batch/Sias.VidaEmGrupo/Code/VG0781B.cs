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
using Sias.VidaEmGrupo.DB2.VG0781B;

namespace Code
{
    public class VG0781B
    {
        public bool IsCall { get; set; }

        public VG0781B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-----------------------------------------------------------------      */
        /*"      *-----------------------------------------------------------------      */
        /*"      *-----------------------------------------------------------------      */
        /*"      *   EMISSAO DA RELACAO DE ENDOSSOS PAGOS POR VIGENCIA/SUBGRUPO          */
        /*"      *-----------------------------------------------------------------      */
        /*"      *   ANALISTA    - JOSE AGNALDO                                          */
        /*"      *   PROGRAMADOR - BL                                                    */
        /*"      *   DATA        - 02/09/93                                              */
        /*"      *-----------------------------------------------------------------      */
        /*"      * CONVERSAO PARA O ANO 2000.              MARCEL   29/05/1998.   *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _VG0781M1 { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis VG0781M1
        {
            get
            {
                _.Move(REG_VG0781M1, _VG0781M1); VarBasis.RedefinePassValue(REG_VG0781M1, _VG0781M1, REG_VG0781M1); return _VG0781M1;
            }
        }
        /*"01  REG-VG0781M1.*/
        public VG0781B_REG_VG0781M1 REG_VG0781M1 { get; set; } = new VG0781B_REG_VG0781M1();
        public class VG0781B_REG_VG0781M1 : VarBasis
        {
            /*"    05  LINHA                  PIC  X(132).*/
            public StringBasis LINHA { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  V0ENDOPARC-DTEMIS          PIC  X(10).*/
        public StringBasis V0ENDOPARC_DTEMIS { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0ENDOPARC-DTMOVTO         PIC  X(10).*/
        public StringBasis V0ENDOPARC_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0ENDOPARC-DTINIVIG        PIC  X(10).*/
        public StringBasis V0ENDOPARC_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0ENDOPARC-DTQITBCO        PIC  X(10).*/
        public StringBasis V0ENDOPARC_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0ENDOPARC-NRENDOS         PIC S9(09)       COMP.*/
        public IntBasis V0ENDOPARC_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0ENDOPARC-CODSUBES        PIC S9(04)       COMP.*/
        public IntBasis V0ENDOPARC_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0ENDOPARC-VLPRMLIQ        PIC S9(13)V99    COMP-3.*/
        public DoubleBasis V0ENDOPARC_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  V0ENDOPARC-PCT-COBERTURA   PIC S9(03)V99    COMP-3.*/
        public DoubleBasis V0ENDOPARC_PCT_COBERTURA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V99"), 2);
        /*"77  V1RELATORIOS-DATA1         PIC  X(10).*/
        public StringBasis V1RELATORIOS_DATA1 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1RELATORIOS-DATA2         PIC  X(10).*/
        public StringBasis V1RELATORIOS_DATA2 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1RELATORIOS-APOLICE       PIC S9(13)       COMP-3.*/
        public IntBasis V1RELATORIOS_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V1RELATORIOS-CODSUBES1     PIC S9(04)       COMP.*/
        public IntBasis V1RELATORIOS_CODSUBES1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1RELATORIOS-CODSUBES2     PIC S9(04)       COMP.*/
        public IntBasis V1RELATORIOS_CODSUBES2 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1MOEDA-VLCRUZAD           PIC S9(06)V9(09) COMP-3.*/
        public DoubleBasis V1MOEDA_VLCRUZAD { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(09)"), 9);
        /*"77  V1SIST-DTMOVABE            PIC  X(10).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1SIST-DTCURRENT           PIC  X(10).*/
        public StringBasis V1SIST_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0CLIENTE-NOME-RAZAO       PIC  X(40).*/
        public StringBasis V0CLIENTE_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77  V1EMPRESA-NOME-EMPRESA     PIC  X(40).*/
        public StringBasis V1EMPRESA_NOME_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77  V0APOLICE-ENDOSSO          PIC S9(13)       COMP-3.*/
        public IntBasis V0APOLICE_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0APOLICE-HISTORICO        PIC S9(13)       COMP-3.*/
        public IntBasis V0APOLICE_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0APOLICE-COBERTURA        PIC S9(13)       COMP-3.*/
        public IntBasis V0APOLICE_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0NRENDOS-ENDOSSO         PIC S9(09)       COMP.*/
        public IntBasis V0NRENDOS_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0NRENDOS-HISTORICO       PIC S9(09)       COMP.*/
        public IntBasis V0NRENDOS_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0NRENDOS-COBERTURA       PIC S9(09)       COMP.*/
        public IntBasis V0NRENDOS_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0HISTOR                  PIC S9(04)       COMP.*/
        public IntBasis V0HISTOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0VENCTO                  PIC  X(10).*/
        public StringBasis V0VENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0PARCELA                 PIC S9(04)       COMP.*/
        public IntBasis V0PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0TOTPARCELA              PIC S9(04)       COMP.*/
        public IntBasis V0TOTPARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  FILLER.*/
        public VG0781B_FILLER_0 FILLER_0 { get; set; } = new VG0781B_FILLER_0();
        public class VG0781B_FILLER_0 : VarBasis
        {
            /*"    03  LC01.*/
            public VG0781B_LC01 LC01 { get; set; } = new VG0781B_LC01();
            public class VG0781B_LC01 : VarBasis
            {
                /*"        05  FILLER             PIC  X(09) VALUE 'VG0781B.1'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"VG0781B.1");
                /*"        05  FILLER             PIC  X(34) VALUE  SPACES.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"");
                /*"        05  LC01-NOME-EMPRESA  PIC  X(76) VALUE  SPACES.*/
                public StringBasis LC01_NOME_EMPRESA { get; set; } = new StringBasis(new PIC("X", "76", "X(76)"), @"");
                /*"        05  FILLER             PIC  X(09) VALUE 'PAGINA'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"PAGINA");
                /*"        05  LC01-PAGINA        PIC  ZZZ9.*/
                public IntBasis LC01_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
                /*"    03  LC02.*/
            }
            public VG0781B_LC02 LC02 { get; set; } = new VG0781B_LC02();
            public class VG0781B_LC02 : VarBasis
            {
                /*"        05  FILLER             PIC X(117) VALUE  SPACES.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "117", "X(117)"), @"");
                /*"        05  FILLER             PIC  X(05) VALUE 'DATA'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"DATA");
                /*"        05  LC02-DATA          PIC  X(10) VALUE  SPACES.*/
                public StringBasis LC02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"    03  LC03.*/
            }
            public VG0781B_LC03 LC03 { get; set; } = new VG0781B_LC03();
            public class VG0781B_LC03 : VarBasis
            {
                /*"        05  FILLER             PIC X(117) VALUE  SPACES.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "117", "X(117)"), @"");
                /*"        05  FILLER             PIC  X(07) VALUE 'HORA'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"HORA");
                /*"        05  LC03-HORA          PIC  X(08) VALUE  SPACES.*/
                public StringBasis LC03_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
                /*"    03  LC04.*/
            }
            public VG0781B_LC04 LC04 { get; set; } = new VG0781B_LC04();
            public class VG0781B_LC04 : VarBasis
            {
                /*"        05  FILLER             PIC  X(16) VALUE  SPACES.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"");
                /*"        05  FILLER             PIC  X(08) VALUE 'RELACAO'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"RELACAO");
                /*"        05  FILLER             PIC  X(03) VALUE 'DE'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"DE");
                /*"        05  FILLER             PIC  X(09) VALUE 'ENDOSSOS'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"ENDOSSOS");
                /*"        05  FILLER             PIC  X(06) VALUE 'PAGOS'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"PAGOS");
                /*"        05  FILLER             PIC  X(03) VALUE 'DA'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"DA");
                /*"        05  FILLER             PIC  X(08) VALUE 'APOLICE'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"APOLICE");
                /*"        05  LC04-NOME-RAZAO    PIC  X(41) VALUE  SPACES.*/
                public StringBasis LC04_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "41", "X(41)"), @"");
                /*"        05  FILLER             PIC  X(03) VALUE 'DE'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"DE");
                /*"        05  LC04-DATA1         PIC  X(11) VALUE  SPACES.*/
                public StringBasis LC04_DATA1 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"");
                /*"        05  FILLER             PIC  X(02) VALUE 'A'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"A");
                /*"        05  LC04-DATA2         PIC  X(10) VALUE  SPACES.*/
                public StringBasis LC04_DATA2 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"    03  LC05.*/
            }
            public VG0781B_LC05 LC05 { get; set; } = new VG0781B_LC05();
            public class VG0781B_LC05 : VarBasis
            {
                /*"        05  FILLER             PIC X(132) VALUE  ALL '-'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
                /*"    03  LC06.*/
            }
            public VG0781B_LC06 LC06 { get; set; } = new VG0781B_LC06();
            public class VG0781B_LC06 : VarBasis
            {
                /*"        05  FILLER             PIC  X(12) VALUE 'ANO/MES VIG'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"ANO/MES VIG");
                /*"        05  FILLER             PIC  X(07) VALUE 'SUBEST'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"SUBEST");
                /*"        05  FILLER             PIC  X(10) VALUE 'ENDOSSO'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"ENDOSSO");
                /*"        05  FILLER             PIC  X(17) VALUE 'DT EMISS'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @"DT EMISS");
                /*"        05  FILLER             PIC  X(18) VALUE 'PR LIQ VG'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "18", "X(18)"), @"PR LIQ VG");
                /*"        05  FILLER             PIC  X(19) VALUE 'PR LIQ AP'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "19", "X(19)"), @"PR LIQ AP");
                /*"        05  FILLER             PIC  X(20) VALUE 'QTD TRD VG'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"QTD TRD VG");
                /*"        05  FILLER             PIC  X(11) VALUE 'QTD TRD AP'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"QTD TRD AP");
                /*"        05  FILLER             PIC  X(10) VALUE 'DT QUITAC'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"DT QUITAC");
                /*"        05  FILLER             PIC  X(08) VALUE 'DT BAIXA'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"DT BAIXA");
                /*"    03  LD01.*/
            }
            public VG0781B_LD01 LD01 { get; set; } = new VG0781B_LD01();
            public class VG0781B_LD01 : VarBasis
            {
                /*"        05  FILLER             PIC  X(01) VALUE  SPACE.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  LD01-ANOINIVIG     PIC  X(04) VALUE  SPACES.*/
                public StringBasis LD01_ANOINIVIG { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
                /*"        05  FILLER             PIC  X(03) VALUE  SPACES.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
                /*"        05  LD01-MESINIVIG     PIC  X(02) VALUE  SPACES.*/
                public StringBasis LD01_MESINIVIG { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
                /*"        05  FILLER             PIC  X(03) VALUE  SPACES.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
                /*"        05  LD01-CODSUBES      PIC  9(04) VALUE  ZEROES.*/
                public IntBasis LD01_CODSUBES { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"        05  FILLER             PIC  X(02) VALUE  SPACES.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
                /*"        05  LD01-NRENDOS       PIC  9(09) VALUE  ZEROES.*/
                public IntBasis LD01_NRENDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
                /*"        05  FILLER             PIC  X(01) VALUE  SPACE.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  LD01-DTEMIS        PIC  X(08) VALUE  SPACES.*/
                public StringBasis LD01_DTEMIS { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
                /*"        05  FILLER             PIC  X(01) VALUE  SPACE.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  LD01-VLPRMLIQ1     PIC  ZZZZZZZZZZ.ZZ9,99.*/
                public DoubleBasis LD01_VLPRMLIQ1 { get; set; } = new DoubleBasis(new PIC("9", "13", "ZZZZZZZZZZ.ZZ9V99."), 2);
                /*"        05  FILLER             PIC  X(01) VALUE  SPACE.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  LD01-VLPRMLIQ2     PIC  ZZZZZZZZZZ.ZZ9,99.*/
                public DoubleBasis LD01_VLPRMLIQ2 { get; set; } = new DoubleBasis(new PIC("9", "13", "ZZZZZZZZZZ.ZZ9V99."), 2);
                /*"        05  FILLER             PIC  X(01) VALUE  SPACE.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  LD01-VLPRMLIQ3     PIC  ZZZZZZZZZZ.ZZ9,9999.*/
                public DoubleBasis LD01_VLPRMLIQ3 { get; set; } = new DoubleBasis(new PIC("9", "13", "ZZZZZZZZZZ.ZZ9V9999."), 4);
                /*"        05  FILLER             PIC  X(01) VALUE  SPACE.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  LD01-VLPRMLIQ4     PIC  ZZZZZZZZZZ.ZZ9,9999.*/
                public DoubleBasis LD01_VLPRMLIQ4 { get; set; } = new DoubleBasis(new PIC("9", "13", "ZZZZZZZZZZ.ZZ9V9999."), 4);
                /*"        05  FILLER             PIC  X(02) VALUE  SPACES.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
                /*"        05  LD01-DTQITBCO      PIC  X(08) VALUE  SPACES.*/
                public StringBasis LD01_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
                /*"        05  FILLER             PIC  X(01) VALUE  SPACE.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  LD01-DTMOVTO       PIC  X(08) VALUE  SPACES.*/
                public StringBasis LD01_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
                /*"    03  LT01.*/
            }
            public VG0781B_LT01 LT01 { get; set; } = new VG0781B_LT01();
            public class VG0781B_LT01 : VarBasis
            {
                /*"        05  FILLER             PIC  X(06) VALUE 'VALOR'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"VALOR");
                /*"        05  FILLER             PIC  X(06) VALUE 'TOTAL'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"TOTAL");
                /*"        05  FILLER             PIC  X(26) VALUE 'MES'.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "26", "X(26)"), @"MES");
                /*"        05  LT01-ACC-MES1      PIC  ZZZZZZZZZZ.ZZ9,99.*/
                public DoubleBasis LT01_ACC_MES1 { get; set; } = new DoubleBasis(new PIC("9", "13", "ZZZZZZZZZZ.ZZ9V99."), 2);
                /*"        05  FILLER             PIC  X(01) VALUE  SPACE.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  LT01-ACC-MES2      PIC  ZZZZZZZZZZ.ZZ9,99.*/
                public DoubleBasis LT01_ACC_MES2 { get; set; } = new DoubleBasis(new PIC("9", "13", "ZZZZZZZZZZ.ZZ9V99."), 2);
                /*"        05  FILLER             PIC  X(01) VALUE  SPACE.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  LT01-ACC-MES3      PIC  ZZZZZZZZZZ.ZZ9,9999.*/
                public DoubleBasis LT01_ACC_MES3 { get; set; } = new DoubleBasis(new PIC("9", "13", "ZZZZZZZZZZ.ZZ9V9999."), 4);
                /*"        05  FILLER             PIC  X(01) VALUE  SPACE.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  LT01-ACC-MES4      PIC  ZZZZZZZZZZ.ZZ9,9999.*/
                public DoubleBasis LT01_ACC_MES4 { get; set; } = new DoubleBasis(new PIC("9", "13", "ZZZZZZZZZZ.ZZ9V9999."), 4);
                /*"    03  LT02.*/
            }
            public VG0781B_LT02 LT02 { get; set; } = new VG0781B_LT02();
            public class VG0781B_LT02 : VarBasis
            {
                /*"        05  FILLER             PIC  X(06) VALUE 'VALOR'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"VALOR");
                /*"        05  FILLER             PIC  X(06) VALUE 'TOTAL'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"TOTAL");
                /*"        05  FILLER             PIC  X(26) VALUE 'ANO'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "26", "X(26)"), @"ANO");
                /*"        05  LT02-ACC-ANO1      PIC  ZZZZZZZZZZ.ZZ9,99.*/
                public DoubleBasis LT02_ACC_ANO1 { get; set; } = new DoubleBasis(new PIC("9", "13", "ZZZZZZZZZZ.ZZ9V99."), 2);
                /*"        05  FILLER             PIC  X(01) VALUE  SPACE.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  LT02-ACC-ANO2      PIC  ZZZZZZZZZZ.ZZ9,99.*/
                public DoubleBasis LT02_ACC_ANO2 { get; set; } = new DoubleBasis(new PIC("9", "13", "ZZZZZZZZZZ.ZZ9V99."), 2);
                /*"        05  FILLER             PIC  X(01) VALUE  SPACE.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  LT02-ACC-ANO3      PIC  ZZZZZZZZZZ.ZZ9,9999.*/
                public DoubleBasis LT02_ACC_ANO3 { get; set; } = new DoubleBasis(new PIC("9", "13", "ZZZZZZZZZZ.ZZ9V9999."), 4);
                /*"        05  FILLER             PIC  X(01) VALUE  SPACE.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  LT02-ACC-ANO4      PIC  ZZZZZZZZZZ.ZZ9,9999.*/
                public DoubleBasis LT02_ACC_ANO4 { get; set; } = new DoubleBasis(new PIC("9", "13", "ZZZZZZZZZZ.ZZ9V9999."), 4);
                /*"    03  LT03.*/
            }
            public VG0781B_LT03 LT03 { get; set; } = new VG0781B_LT03();
            public class VG0781B_LT03 : VarBasis
            {
                /*"        05  FILLER             PIC  X(06) VALUE 'VALOR'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"VALOR");
                /*"        05  FILLER             PIC  X(06) VALUE 'TOTAL'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"TOTAL");
                /*"        05  FILLER             PIC  X(26) VALUE 'GERAL'.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "26", "X(26)"), @"GERAL");
                /*"        05  LT03-ACC-GERAL1    PIC  ZZZZZZZZZZ.ZZ9,99.*/
                public DoubleBasis LT03_ACC_GERAL1 { get; set; } = new DoubleBasis(new PIC("9", "13", "ZZZZZZZZZZ.ZZ9V99."), 2);
                /*"        05  FILLER             PIC  X(01) VALUE  SPACE.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  LT03-ACC-GERAL2    PIC  ZZZZZZZZZZ.ZZ9,99.*/
                public DoubleBasis LT03_ACC_GERAL2 { get; set; } = new DoubleBasis(new PIC("9", "13", "ZZZZZZZZZZ.ZZ9V99."), 2);
                /*"        05  FILLER             PIC  X(01) VALUE  SPACE.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  LT03-ACC-GERAL3    PIC  ZZZZZZZZZZ.ZZ9,9999.*/
                public DoubleBasis LT03_ACC_GERAL3 { get; set; } = new DoubleBasis(new PIC("9", "13", "ZZZZZZZZZZ.ZZ9V9999."), 4);
                /*"        05  FILLER             PIC  X(01) VALUE  SPACE.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  LT03-ACC-GERAL4    PIC  ZZZZZZZZZZ.ZZ9,9999.*/
                public DoubleBasis LT03_ACC_GERAL4 { get; set; } = new DoubleBasis(new PIC("9", "13", "ZZZZZZZZZZ.ZZ9V9999."), 4);
                /*"    03  WDATA.*/
            }
            public VG0781B_WDATA WDATA { get; set; } = new VG0781B_WDATA();
            public class VG0781B_WDATA : VarBasis
            {
                /*"        05  WDATA-AA           PIC  9(04) VALUE  ZEROES.*/
                public IntBasis WDATA_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"        05  FILLER             PIC  X(01) VALUE  SPACES.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  WDATA-MM           PIC  9(02) VALUE  ZEROES.*/
                public IntBasis WDATA_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"        05  FILLER             PIC  X(01) VALUE  SPACES.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  WDATA-DD           PIC  9(02) VALUE  ZEROES.*/
                public IntBasis WDATA_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    03      WDATA-CURRENT      PIC  X(010)    VALUE SPACES.*/
            }
            public StringBasis WDATA_CURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    03      FILLER             REDEFINES      WDATA-CURRENT.*/
            private _REDEF_VG0781B_FILLER_59 _filler_59 { get; set; }
            public _REDEF_VG0781B_FILLER_59 FILLER_59
            {
                get { _filler_59 = new _REDEF_VG0781B_FILLER_59(); _.Move(WDATA_CURRENT, _filler_59); VarBasis.RedefinePassValue(WDATA_CURRENT, _filler_59, WDATA_CURRENT); _filler_59.ValueChanged += () => { _.Move(_filler_59, WDATA_CURRENT); }; return _filler_59; }
                set { VarBasis.RedefinePassValue(value, _filler_59, WDATA_CURRENT); }
            }  //Redefines
            public class _REDEF_VG0781B_FILLER_59 : VarBasis
            {
                /*"      05    WDATA-CURR-ANO     PIC  9(004).*/
                public IntBasis WDATA_CURR_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      05    FILLER             PIC  X(001).*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      05    WDATA-CURR-MES     PIC  9(002).*/
                public IntBasis WDATA_CURR_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05    FILLER             PIC  X(001).*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      05    WDATA-CURR-DIA     PIC  9(002).*/
                public IntBasis WDATA_CURR_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03  WDATA1.*/

                public _REDEF_VG0781B_FILLER_59()
                {
                    WDATA_CURR_ANO.ValueChanged += OnValueChanged;
                    FILLER_60.ValueChanged += OnValueChanged;
                    WDATA_CURR_MES.ValueChanged += OnValueChanged;
                    FILLER_61.ValueChanged += OnValueChanged;
                    WDATA_CURR_DIA.ValueChanged += OnValueChanged;
                }

            }
            public VG0781B_WDATA1 WDATA1 { get; set; } = new VG0781B_WDATA1();
            public class VG0781B_WDATA1 : VarBasis
            {
                /*"        05  WDATA-AA1          PIC  X(04) VALUE  SPACES.*/
                public StringBasis WDATA_AA1 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
                /*"        05  FILLER             PIC  X(01) VALUE  SPACES.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  WDATA-MM1          PIC  X(02) VALUE  SPACES.*/
                public StringBasis WDATA_MM1 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
                /*"        05  FILLER             PIC  X(03) VALUE  SPACES.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
                /*"    03  WHORA-CURR.*/
            }
            public VG0781B_WHORA_CURR WHORA_CURR { get; set; } = new VG0781B_WHORA_CURR();
            public class VG0781B_WHORA_CURR : VarBasis
            {
                /*"        05  WHORA-HH-CURR      PIC  9(02) VALUE  ZEROES.*/
                public IntBasis WHORA_HH_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"        05  WHORA-MM-CURR      PIC  9(02) VALUE  ZEROES.*/
                public IntBasis WHORA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"        05  WHORA-SS-CURR      PIC  9(02) VALUE  ZEROES.*/
                public IntBasis WHORA_SS_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    03  WDATA-CABEC.*/
            }
            public VG0781B_WDATA_CABEC WDATA_CABEC { get; set; } = new VG0781B_WDATA_CABEC();
            public class VG0781B_WDATA_CABEC : VarBasis
            {
                /*"        05  WDATA-DD-CABEC     PIC  9(02) VALUE  ZEROES.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"        05  FILLER             PIC  X(01) VALUE '/'.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"        05  WDATA-MM-CABEC     PIC  9(02) VALUE  ZEROES.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"        05  FILLER             PIC  X(01) VALUE '/'.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"        05  WDATA-AA-CABEC     PIC  9(04) VALUE  ZEROES.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"    03  WHORA-CABEC.*/
            }
            public VG0781B_WHORA_CABEC WHORA_CABEC { get; set; } = new VG0781B_WHORA_CABEC();
            public class VG0781B_WHORA_CABEC : VarBasis
            {
                /*"        05  WHORA-HH-CABEC     PIC  9(02) VALUE  ZEROES.*/
                public IntBasis WHORA_HH_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"        05  FILLER             PIC  X(01) VALUE ':'.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @":");
                /*"        05  WHORA-MM-CABEC     PIC  9(02) VALUE  ZEROES.*/
                public IntBasis WHORA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"        05  FILLER             PIC  X(01) VALUE ':'.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @":");
                /*"        05  WHORA-SS-CABEC     PIC  9(02) VALUE  ZEROES.*/
                public IntBasis WHORA_SS_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    03  W-FIM-RELATORIOS       PIC  X(01)       VALUE 'N'.*/
            }
            public StringBasis W_FIM_RELATORIOS { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"N");
            /*"    03  W-FIM-ENDOPARC         PIC  X(01)       VALUE 'N'.*/
            public StringBasis W_FIM_ENDOPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"N");
            /*"    03  W-ANOINIVIG-ANT        PIC  X(04)       VALUE SPACES.*/
            public StringBasis W_ANOINIVIG_ANT { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
            /*"    03  W-MESINIVIG-ANT        PIC  X(02)       VALUE SPACES.*/
            public StringBasis W_MESINIVIG_ANT { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
            /*"    03  W-LIDOS                PIC S9(06)       VALUE +00 COMP.*/
            public IntBasis W_LIDOS { get; set; } = new IntBasis(new PIC("S9", "6", "S9(06)"), +00);
            /*"    03  W-IMPRESSOS            PIC S9(06)       VALUE +00 COMP.*/
            public IntBasis W_IMPRESSOS { get; set; } = new IntBasis(new PIC("S9", "6", "S9(06)"), +00);
            /*"    03  W-CONT-PAG             PIC S9(04)       VALUE +00 COMP.*/
            public IntBasis W_CONT_PAG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"), +00);
            /*"    03  W-CONT-LIN             PIC S9(02)       VALUE +70 COMP.*/
            public IntBasis W_CONT_LIN { get; set; } = new IntBasis(new PIC("S9", "2", "S9(02)"), +70);
            /*"    03  W-VLPRMLIQ1            PIC S9(13)V9(04) VALUE +00 COMP-3*/
            public DoubleBasis W_VLPRMLIQ1 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(04)"), 4, +00);
            /*"    03  W-VLPRMLIQ2            PIC S9(13)V9(04) VALUE +00 COMP-3*/
            public DoubleBasis W_VLPRMLIQ2 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(04)"), 4, +00);
            /*"    03  W-VLPRMLIQ3            PIC S9(13)V9(04) VALUE +00 COMP-3*/
            public DoubleBasis W_VLPRMLIQ3 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(04)"), 4, +00);
            /*"    03  W-VLPRMLIQ4            PIC S9(13)V9(04) VALUE +00 COMP-3*/
            public DoubleBasis W_VLPRMLIQ4 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(04)"), 4, +00);
            /*"    03  W-ACC-MES1             PIC S9(13)V9(04) VALUE +00 COMP-3*/
            public DoubleBasis W_ACC_MES1 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(04)"), 4, +00);
            /*"    03  W-ACC-MES2             PIC S9(13)V9(04) VALUE +00 COMP-3*/
            public DoubleBasis W_ACC_MES2 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(04)"), 4, +00);
            /*"    03  W-ACC-MES3             PIC S9(13)V9(04) VALUE +00 COMP-3*/
            public DoubleBasis W_ACC_MES3 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(04)"), 4, +00);
            /*"    03  W-ACC-MES4             PIC S9(13)V9(04) VALUE +00 COMP-3*/
            public DoubleBasis W_ACC_MES4 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(04)"), 4, +00);
            /*"    03  W-ACC-ANO1             PIC S9(13)V9(04) VALUE +00 COMP-3*/
            public DoubleBasis W_ACC_ANO1 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(04)"), 4, +00);
            /*"    03  W-ACC-ANO2             PIC S9(13)V9(04) VALUE +00 COMP-3*/
            public DoubleBasis W_ACC_ANO2 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(04)"), 4, +00);
            /*"    03  W-ACC-ANO3             PIC S9(13)V9(04) VALUE +00 COMP-3*/
            public DoubleBasis W_ACC_ANO3 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(04)"), 4, +00);
            /*"    03  W-ACC-ANO4             PIC S9(13)V9(04) VALUE +00 COMP-3*/
            public DoubleBasis W_ACC_ANO4 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(04)"), 4, +00);
            /*"    03  W-ACC-GERAL1           PIC S9(13)V9(04) VALUE +00 COMP-3*/
            public DoubleBasis W_ACC_GERAL1 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(04)"), 4, +00);
            /*"    03  W-ACC-GERAL2           PIC S9(13)V9(04) VALUE +00 COMP-3*/
            public DoubleBasis W_ACC_GERAL2 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(04)"), 4, +00);
            /*"    03  W-ACC-GERAL3           PIC S9(13)V9(04) VALUE +00 COMP-3*/
            public DoubleBasis W_ACC_GERAL3 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(04)"), 4, +00);
            /*"    03  W-ACC-GERAL4           PIC S9(13)V9(04) VALUE +00 COMP-3*/
            public DoubleBasis W_ACC_GERAL4 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(04)"), 4, +00);
            /*"    03  W-APOLICE-ERRO         PIC S9(13)       VALUE +00 COMP-3*/
            public IntBasis W_APOLICE_ERRO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"), +00);
            /*"    03  W-ENDOSSO-ERRO         PIC S9(09)       VALUE +00 COMP.*/
            public IntBasis W_ENDOSSO_ERRO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"), +00);
            /*"    03  WSQLCODE3              PIC S9(09) VALUE  ZEROES COMP.*/
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"    03  WABEND.*/
            public VG0781B_WABEND WABEND { get; set; } = new VG0781B_WABEND();
            public class VG0781B_WABEND : VarBasis
            {
                /*"        05  FILLER             PIC  X(01) VALUE  SPACE.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  FILLER             PIC  X(09) VALUE 'VG0781B'.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"VG0781B");
                /*"        05  FILLER             PIC  X(10) VALUE '*** ERRO'.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"*** ERRO");
                /*"        05  FILLER             PIC  X(10) VALUE 'EXEC SQL'.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"EXEC SQL");
                /*"        05  FILLER             PIC  X(08) VALUE 'NUMERO'.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"NUMERO");
                /*"        05  WNR-EXEC-SQL       PIC  X(03) VALUE  SPACES.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
                /*"        05  FILLER             PIC  X(01) VALUE  SPACE.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"        05  FILLER             PIC  X(16) VALUE '** PARAGRAFO ='*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"** PARAGRAFO =");
                /*"        05  PARAGRAFO          PIC  X(30) VALUE  SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
                /*"        05  FILLER             PIC  X(04) VALUE  SPACES.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
                /*"        05  FILLER             PIC  X(10) VALUE 'SQLCODE = '.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"SQLCODE = ");
                /*"        05  WSQLCODE           PIC  ZZZZZZ999-   VALUE ZEROES.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"        05  FILLER             PIC  X(04) VALUE  SPACES.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
                /*"        05  FILLER             PIC  X(10) VALUE 'SQLCODE1= '.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"SQLCODE1= ");
                /*"        05  WSQLCODE1          PIC  ZZZZZZ999-   VALUE ZEROES.*/
                public IntBasis WSQLCODE1 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"        05  FILLER             PIC  X(04) VALUE  SPACES.*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
                /*"        05  FILLER             PIC  X(10) VALUE 'SQLCODE2= '.*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"SQLCODE2= ");
                /*"        05  WSQLCODE2          PIC  ZZZZZZ999-   VALUE ZEROES.*/
                public IntBasis WSQLCODE2 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"    03  FILLER.*/
            }
            public VG0781B_FILLER_81 FILLER_81 { get; set; } = new VG0781B_FILLER_81();
            public class VG0781B_FILLER_81 : VarBasis
            {
                /*"        05  W-MENSAGEM1        PIC  X(35) VALUE           'VG0781B - SEM MOVIMENTOS NO DIA'.*/
                public StringBasis W_MENSAGEM1 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"VG0781B - SEM MOVIMENTOS NO DIA");
                /*"        05  W-MENSAGEM2        PIC  X(35) VALUE           'VG0781B - EMPRESA NAO ENCONTRADA'.*/
                public StringBasis W_MENSAGEM2 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"VG0781B - EMPRESA NAO ENCONTRADA");
                /*"        05  W-MENSAGEM3        PIC  X(35) VALUE           'VG0781B - SISTEMA NAO ENCONTRADO'.*/
                public StringBasis W_MENSAGEM3 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"VG0781B - SISTEMA NAO ENCONTRADO");
                /*"        05  W-MENSAGEM4        PIC  X(35) VALUE           'VG0781B - CLIENTE NAO ENCONTRADO'.*/
                public StringBasis W_MENSAGEM4 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"VG0781B - CLIENTE NAO ENCONTRADO");
                /*"        05  W-MENSAGEM5        PIC  X(35) VALUE           'VG0781B - MOEDA NAO ENCONTRADA'.*/
                public StringBasis W_MENSAGEM5 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"VG0781B - MOEDA NAO ENCONTRADA");
                /*"01  LK-LINK.*/
            }
        }
        public VG0781B_LK_LINK LK_LINK { get; set; } = new VG0781B_LK_LINK();
        public class VG0781B_LK_LINK : VarBasis
        {
            /*"    03  LK-RTCODE              PIC S9(04) VALUE  +00000 COMP.*/
            public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"), +00000);
            /*"    03  LK-TAMANHO             PIC S9(04) VALUE  +00040 COMP.*/
            public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"), +00040);
            /*"    03  LK-TITULO              PIC X(132) VALUE  SPACES.*/
            public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
        }


        public VG0781B_RELATORIOS RELATORIOS { get; set; } = new VG0781B_RELATORIOS();
        public VG0781B_ENDOSSO ENDOSSO { get; set; } = new VG0781B_ENDOSSO();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string VG0781M1_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                VG0781M1.SetFile(VG0781M1_FILE_NAME_P);

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
            /*" -335- MOVE '000-000-PRINCIPAL' TO PARAGRAFO. */
            _.Move("000-000-PRINCIPAL", FILLER_0.WABEND.PARAGRAFO);

            /*" -337- MOVE '000' TO WNR-EXEC-SQL. */
            _.Move("000", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -337- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -338- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -339- EXEC SQL WHENEVER SQLERROR GO TO 999-999-ROT-ERRO END-EXEC. */

            /*" -343- OPEN OUTPUT VG0781M1. */
            VG0781M1.Open(REG_VG0781M1);

            /*" -345- ACCEPT WHORA-CURR FROM TIME. */
            _.Move(_.AcceptDate("TIME"), FILLER_0.WHORA_CURR);

            /*" -346- MOVE WHORA-HH-CURR TO WHORA-HH-CABEC. */
            _.Move(FILLER_0.WHORA_CURR.WHORA_HH_CURR, FILLER_0.WHORA_CABEC.WHORA_HH_CABEC);

            /*" -347- MOVE WHORA-MM-CURR TO WHORA-MM-CABEC. */
            _.Move(FILLER_0.WHORA_CURR.WHORA_MM_CURR, FILLER_0.WHORA_CABEC.WHORA_MM_CABEC);

            /*" -349- MOVE WHORA-SS-CURR TO WHORA-SS-CABEC. */
            _.Move(FILLER_0.WHORA_CURR.WHORA_SS_CURR, FILLER_0.WHORA_CABEC.WHORA_SS_CABEC);

            /*" -351- MOVE WHORA-CABEC TO LC03-HORA. */
            _.Move(FILLER_0.WHORA_CABEC, FILLER_0.LC03.LC03_HORA);

            /*" -352- PERFORM 000-100-SELECT-V1EMPRESA. */

            M_000_100_SELECT_V1EMPRESA_SECTION();

            /*" -354- PERFORM 000-200-SELECT-V1SISTEMA. */

            M_000_200_SELECT_V1SISTEMA_SECTION();

            /*" -355- MOVE V1SIST-DTCURRENT TO WDATA-CURRENT. */
            _.Move(V1SIST_DTCURRENT, FILLER_0.WDATA_CURRENT);

            /*" -356- MOVE WDATA-CURR-DIA TO WDATA-DD-CABEC. */
            _.Move(FILLER_0.FILLER_59.WDATA_CURR_DIA, FILLER_0.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -357- MOVE WDATA-CURR-MES TO WDATA-MM-CABEC. */
            _.Move(FILLER_0.FILLER_59.WDATA_CURR_MES, FILLER_0.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -358- MOVE WDATA-CURR-ANO TO WDATA-AA-CABEC. */
            _.Move(FILLER_0.FILLER_59.WDATA_CURR_ANO, FILLER_0.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -360- MOVE WDATA-CABEC TO LC02-DATA. */
            _.Move(FILLER_0.WDATA_CABEC, FILLER_0.LC02.LC02_DATA);

            /*" -361- PERFORM 000-300-DECLARE-RELATORIOS. */

            M_000_300_DECLARE_RELATORIOS_SECTION();

            /*" -363- PERFORM 000-400-FETCH-RELATORIOS. */

            M_000_400_FETCH_RELATORIOS_SECTION();

            /*" -364- IF W-FIM-RELATORIOS EQUAL 'S' */

            if (FILLER_0.W_FIM_RELATORIOS == "S")
            {

                /*" -365- DISPLAY W-MENSAGEM1 */
                _.Display(FILLER_0.FILLER_81.W_MENSAGEM1);

                /*" -367- PERFORM 000-800-FINALIZA. */

                M_000_800_FINALIZA_SECTION();
            }


            /*" -368- PERFORM 000-500-SELECT-V0CLIENTE. */

            M_000_500_SELECT_V0CLIENTE_SECTION();

            /*" -369- PERFORM 600-100-DECLARA-ENDOSSO */

            M_600_100_DECLARA_ENDOSSO_SECTION();

            /*" -372- PERFORM 000-600-PROCESSA-RELATORIOS UNTIL W-FIM-RELATORIOS EQUAL 'S' . */

            while (!(FILLER_0.W_FIM_RELATORIOS == "S"))
            {

                M_000_600_PROCESSA_RELATORIOS_SECTION();
            }

            /*" -373- PERFORM 000-700-UPDATE-V1RELATORIOS. */

            M_000_700_UPDATE_V1RELATORIOS_SECTION();

            /*" -373- PERFORM 000-800-FINALIZA. */

            M_000_800_FINALIZA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_000_EXIT*/

        [StopWatch]
        /*" M-000-100-SELECT-V1EMPRESA-SECTION */
        private void M_000_100_SELECT_V1EMPRESA_SECTION()
        {
            /*" -382- MOVE '000-100-SELECT-V1EMPRESA' TO PARAGRAFO. */
            _.Move("000-100-SELECT-V1EMPRESA", FILLER_0.WABEND.PARAGRAFO);

            /*" -386- MOVE '001' TO WNR-EXEC-SQL. */
            _.Move("001", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -396- PERFORM M_000_100_SELECT_V1EMPRESA_DB_SELECT_1 */

            M_000_100_SELECT_V1EMPRESA_DB_SELECT_1();

            /*" -402- MOVE V1EMPRESA-NOME-EMPRESA TO LK-TITULO. */
            _.Move(V1EMPRESA_NOME_EMPRESA, LK_LINK.LK_TITULO);

            /*" -403- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -404- DISPLAY W-MENSAGEM2 */
                _.Display(FILLER_0.FILLER_81.W_MENSAGEM2);

                /*" -406- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -407- CALL 'PROALN01' USING LK-LINK. */
            _.Call("PROALN01", LK_LINK);

            /*" -407- MOVE LK-TITULO TO LC01-NOME-EMPRESA. */
            _.Move(LK_LINK.LK_TITULO, FILLER_0.LC01.LC01_NOME_EMPRESA);

        }

        [StopWatch]
        /*" M-000-100-SELECT-V1EMPRESA-DB-SELECT-1 */
        public void M_000_100_SELECT_V1EMPRESA_DB_SELECT_1()
        {
            /*" -396- EXEC SQL SELECT NOME_EMPRESA INTO :V1EMPRESA-NOME-EMPRESA FROM SEGUROS.V1EMPRESA WHERE COD_EMPRESA = 0 END-EXEC. */

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
            /*" -416- MOVE '000-200-SELECT-V1SISTEMA' TO PARAGRAFO. */
            _.Move("000-200-SELECT-V1SISTEMA", FILLER_0.WABEND.PARAGRAFO);

            /*" -420- MOVE '002' TO WNR-EXEC-SQL. */
            _.Move("002", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -425- PERFORM M_000_200_SELECT_V1SISTEMA_DB_SELECT_1 */

            M_000_200_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -430- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -431- DISPLAY W-MENSAGEM3 */
                _.Display(FILLER_0.FILLER_81.W_MENSAGEM3);

                /*" -431- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-000-200-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void M_000_200_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -425- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :V1SIST-DTMOVABE, :V1SIST-DTCURRENT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VG' END-EXEC. */

            var m_000_200_SELECT_V1SISTEMA_DB_SELECT_1_Query1 = new M_000_200_SELECT_V1SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_000_200_SELECT_V1SISTEMA_DB_SELECT_1_Query1.Execute(m_000_200_SELECT_V1SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
                _.Move(executed_1.V1SIST_DTCURRENT, V1SIST_DTCURRENT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_200_EXIT*/

        [StopWatch]
        /*" M-000-300-DECLARE-RELATORIOS-SECTION */
        private void M_000_300_DECLARE_RELATORIOS_SECTION()
        {
            /*" -440- MOVE '000-300-DECLARE-RELATORIOS' TO PARAGRAFO. */
            _.Move("000-300-DECLARE-RELATORIOS", FILLER_0.WABEND.PARAGRAFO);

            /*" -444- MOVE '003' TO WNR-EXEC-SQL. */
            _.Move("003", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -459- PERFORM M_000_300_DECLARE_RELATORIOS_DB_DECLARE_1 */

            M_000_300_DECLARE_RELATORIOS_DB_DECLARE_1();

            /*" -463- PERFORM M_000_300_DECLARE_RELATORIOS_DB_OPEN_1 */

            M_000_300_DECLARE_RELATORIOS_DB_OPEN_1();

        }

        [StopWatch]
        /*" M-000-300-DECLARE-RELATORIOS-DB-DECLARE-1 */
        public void M_000_300_DECLARE_RELATORIOS_DB_DECLARE_1()
        {
            /*" -459- EXEC SQL DECLARE RELATORIOS CURSOR FOR SELECT PERI_INICIAL, PERI_FINAL, NUM_APOLICE, CODSUBES FROM SEGUROS.V1RELATORIOS WHERE IDSISTEM = 'VG' AND CODRELAT = 'VG0781B' AND SITUACAO = '0' END-EXEC. */
            RELATORIOS = new VG0781B_RELATORIOS(false);
            string GetQuery_RELATORIOS()
            {
                var query = @$"SELECT PERI_INICIAL
							, 
							PERI_FINAL
							, 
							NUM_APOLICE
							, 
							CODSUBES 
							FROM SEGUROS.V1RELATORIOS 
							WHERE IDSISTEM = 'VG' AND 
							CODRELAT = 'VG0781B' AND 
							SITUACAO = '0'";

                return query;
            }
            RELATORIOS.GetQueryEvent += GetQuery_RELATORIOS;

        }

        [StopWatch]
        /*" M-000-300-DECLARE-RELATORIOS-DB-OPEN-1 */
        public void M_000_300_DECLARE_RELATORIOS_DB_OPEN_1()
        {
            /*" -463- EXEC SQL OPEN RELATORIOS END-EXEC. */

            RELATORIOS.Open();

        }

        [StopWatch]
        /*" M-600-100-DECLARA-ENDOSSO-DB-DECLARE-1 */
        public void M_600_100_DECLARA_ENDOSSO_DB_DECLARE_1()
        {
            /*" -840- EXEC SQL DECLARE ENDOSSO CURSOR FOR SELECT NUM_APOLICE,DTINIVIG, CODSUBES, NRENDOS, DTEMIS FROM SEGUROS.V0ENDOSSO WHERE NUM_APOLICE = :V1RELATORIOS-APOLICE AND CODSUBES >= :V1RELATORIOS-CODSUBES1 AND CODSUBES <= :V1RELATORIOS-CODSUBES2 AND DTINIVIG >= :V1RELATORIOS-DATA1 AND DTINIVIG <= :V1RELATORIOS-DATA2 AND SITUACAO = '1' AND NRENDOS > 0 ORDER BY 2, 3, 5 END-EXEC. */
            ENDOSSO = new VG0781B_ENDOSSO(true);
            string GetQuery_ENDOSSO()
            {
                var query = @$"SELECT NUM_APOLICE
							,DTINIVIG
							, 
							CODSUBES
							, 
							NRENDOS
							, 
							DTEMIS 
							FROM SEGUROS.V0ENDOSSO 
							WHERE 
							NUM_APOLICE = '{V1RELATORIOS_APOLICE}' AND 
							CODSUBES >= '{V1RELATORIOS_CODSUBES1}' AND 
							CODSUBES <= '{V1RELATORIOS_CODSUBES2}' AND 
							DTINIVIG >= '{V1RELATORIOS_DATA1}' AND 
							DTINIVIG <= '{V1RELATORIOS_DATA2}' AND 
							SITUACAO = '1' AND 
							NRENDOS > 0 
							ORDER BY 2
							, 3
							, 5";

                return query;
            }
            ENDOSSO.GetQueryEvent += GetQuery_ENDOSSO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_300_EXIT*/

        [StopWatch]
        /*" M-000-400-FETCH-RELATORIOS-SECTION */
        private void M_000_400_FETCH_RELATORIOS_SECTION()
        {
            /*" -473- MOVE '000-400-FETCH-RELATORIOS' TO PARAGRAFO. */
            _.Move("000-400-FETCH-RELATORIOS", FILLER_0.WABEND.PARAGRAFO);

            /*" -482- PERFORM M_000_400_FETCH_RELATORIOS_DB_FETCH_1 */

            M_000_400_FETCH_RELATORIOS_DB_FETCH_1();

            /*" -485- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -485- PERFORM M_000_400_FETCH_RELATORIOS_DB_CLOSE_1 */

                M_000_400_FETCH_RELATORIOS_DB_CLOSE_1();

                /*" -487- MOVE 'S' TO W-FIM-RELATORIOS */
                _.Move("S", FILLER_0.W_FIM_RELATORIOS);

                /*" -488- ELSE */
            }
            else
            {


                /*" -490- MOVE 'N' TO W-FIM-ENDOPARC */
                _.Move("N", FILLER_0.W_FIM_ENDOPARC);

                /*" -491- MOVE V1RELATORIOS-DATA1 TO WDATA */
                _.Move(V1RELATORIOS_DATA1, FILLER_0.WDATA);

                /*" -492- MOVE WDATA-DD TO WDATA-DD-CABEC */
                _.Move(FILLER_0.WDATA.WDATA_DD, FILLER_0.WDATA_CABEC.WDATA_DD_CABEC);

                /*" -493- MOVE WDATA-MM TO WDATA-MM-CABEC */
                _.Move(FILLER_0.WDATA.WDATA_MM, FILLER_0.WDATA_CABEC.WDATA_MM_CABEC);

                /*" -494- MOVE WDATA-AA TO WDATA-AA-CABEC */
                _.Move(FILLER_0.WDATA.WDATA_AA, FILLER_0.WDATA_CABEC.WDATA_AA_CABEC);

                /*" -495- MOVE WDATA-CABEC TO LC04-DATA1 */
                _.Move(FILLER_0.WDATA_CABEC, FILLER_0.LC04.LC04_DATA1);

                /*" -496- MOVE V1RELATORIOS-DATA2 TO WDATA */
                _.Move(V1RELATORIOS_DATA2, FILLER_0.WDATA);

                /*" -497- MOVE WDATA-DD TO WDATA-DD-CABEC */
                _.Move(FILLER_0.WDATA.WDATA_DD, FILLER_0.WDATA_CABEC.WDATA_DD_CABEC);

                /*" -498- MOVE WDATA-MM TO WDATA-MM-CABEC */
                _.Move(FILLER_0.WDATA.WDATA_MM, FILLER_0.WDATA_CABEC.WDATA_MM_CABEC);

                /*" -499- MOVE WDATA-AA TO WDATA-AA-CABEC */
                _.Move(FILLER_0.WDATA.WDATA_AA, FILLER_0.WDATA_CABEC.WDATA_AA_CABEC);

                /*" -501- MOVE WDATA-CABEC TO LC04-DATA2 */
                _.Move(FILLER_0.WDATA_CABEC, FILLER_0.LC04.LC04_DATA2);

                /*" -502- IF V1RELATORIOS-CODSUBES1 EQUAL ZEROES */

                if (V1RELATORIOS_CODSUBES1 == 00)
                {

                    /*" -503- MOVE 9999 TO V1RELATORIOS-CODSUBES2 */
                    _.Move(9999, V1RELATORIOS_CODSUBES2);

                    /*" -504- ELSE */
                }
                else
                {


                    /*" -504- MOVE V1RELATORIOS-CODSUBES1 TO V1RELATORIOS-CODSUBES2. */
                    _.Move(V1RELATORIOS_CODSUBES1, V1RELATORIOS_CODSUBES2);
                }

            }


        }

        [StopWatch]
        /*" M-000-400-FETCH-RELATORIOS-DB-FETCH-1 */
        public void M_000_400_FETCH_RELATORIOS_DB_FETCH_1()
        {
            /*" -482- EXEC SQL FETCH RELATORIOS INTO :V1RELATORIOS-DATA1, :V1RELATORIOS-DATA2, :V1RELATORIOS-APOLICE, :V1RELATORIOS-CODSUBES1 END-EXEC. */

            if (RELATORIOS.Fetch())
            {
                _.Move(RELATORIOS.V1RELATORIOS_DATA1, V1RELATORIOS_DATA1);
                _.Move(RELATORIOS.V1RELATORIOS_DATA2, V1RELATORIOS_DATA2);
                _.Move(RELATORIOS.V1RELATORIOS_APOLICE, V1RELATORIOS_APOLICE);
                _.Move(RELATORIOS.V1RELATORIOS_CODSUBES1, V1RELATORIOS_CODSUBES1);
            }

        }

        [StopWatch]
        /*" M-000-400-FETCH-RELATORIOS-DB-CLOSE-1 */
        public void M_000_400_FETCH_RELATORIOS_DB_CLOSE_1()
        {
            /*" -485- EXEC SQL CLOSE RELATORIOS END-EXEC */

            RELATORIOS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_400_EXIT*/

        [StopWatch]
        /*" M-000-500-SELECT-V0CLIENTE-SECTION */
        private void M_000_500_SELECT_V0CLIENTE_SECTION()
        {
            /*" -513- MOVE '000-500-SELECT-V0CLIENTE' TO PARAGRAFO. */
            _.Move("000-500-SELECT-V0CLIENTE", FILLER_0.WABEND.PARAGRAFO);

            /*" -517- MOVE '004' TO WNR-EXEC-SQL. */
            _.Move("004", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -533- PERFORM M_000_500_SELECT_V0CLIENTE_DB_SELECT_1 */

            M_000_500_SELECT_V0CLIENTE_DB_SELECT_1();

            /*" -538- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -539- DISPLAY W-MENSAGEM4 */
                _.Display(FILLER_0.FILLER_81.W_MENSAGEM4);

                /*" -541- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -541- MOVE V0CLIENTE-NOME-RAZAO TO LC04-NOME-RAZAO. */
            _.Move(V0CLIENTE_NOME_RAZAO, FILLER_0.LC04.LC04_NOME_RAZAO);

        }

        [StopWatch]
        /*" M-000-500-SELECT-V0CLIENTE-DB-SELECT-1 */
        public void M_000_500_SELECT_V0CLIENTE_DB_SELECT_1()
        {
            /*" -533- EXEC SQL SELECT NOME_RAZAO INTO :V0CLIENTE-NOME-RAZAO FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = ( SELECT CODCLIEN FROM SEGUROS.V1APOLICE WHERE NUM_APOLICE = :V1RELATORIOS-APOLICE) END-EXEC. */

            var m_000_500_SELECT_V0CLIENTE_DB_SELECT_1_Query1 = new M_000_500_SELECT_V0CLIENTE_DB_SELECT_1_Query1()
            {
                V1RELATORIOS_APOLICE = V1RELATORIOS_APOLICE.ToString(),
            };

            var executed_1 = M_000_500_SELECT_V0CLIENTE_DB_SELECT_1_Query1.Execute(m_000_500_SELECT_V0CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CLIENTE_NOME_RAZAO, V0CLIENTE_NOME_RAZAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_500_EXIT*/

        [StopWatch]
        /*" M-000-600-PROCESSA-RELATORIOS-SECTION */
        private void M_000_600_PROCESSA_RELATORIOS_SECTION()
        {
            /*" -549- MOVE '000-600-PROCESSA-RELATORIOS' TO PARAGRAFO. */
            _.Move("000-600-PROCESSA-RELATORIOS", FILLER_0.WABEND.PARAGRAFO);

            /*" -550- MOVE ' ' TO W-FIM-ENDOPARC. */
            _.Move(" ", FILLER_0.W_FIM_ENDOPARC);

            /*" -551- PERFORM 1500-100-OPEN-ENDOSSO. */

            M_1500_100_OPEN_ENDOSSO_SECTION();

            /*" -552- PERFORM 1300-100-BUSCAR-LINHAS. */

            M_1300_100_BUSCAR_LINHAS_SECTION();

            /*" -553- IF W-FIM-ENDOPARC EQUAL 'S' */

            if (FILLER_0.W_FIM_ENDOPARC == "S")
            {

                /*" -554- PERFORM 1400-100-CLOSE-ENDOSSO */

                M_1400_100_CLOSE_ENDOSSO_SECTION();

                /*" -555- PERFORM 000-400-FETCH-RELATORIOS */

                M_000_400_FETCH_RELATORIOS_SECTION();

                /*" -557- GO TO 000-600-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_600_EXIT*/ //GOTO
                return;
            }


            /*" -558- MOVE WDATA-AA1 TO LD01-ANOINIVIG. */
            _.Move(FILLER_0.WDATA1.WDATA_AA1, FILLER_0.LD01.LD01_ANOINIVIG);

            /*" -560- MOVE WDATA-MM1 TO LD01-MESINIVIG. */
            _.Move(FILLER_0.WDATA1.WDATA_MM1, FILLER_0.LD01.LD01_MESINIVIG);

            /*" -563- PERFORM 100-300-PROCESSA-ENDOPARC UNTIL W-FIM-ENDOPARC EQUAL 'S' . */

            while (!(FILLER_0.W_FIM_ENDOPARC == "S"))
            {

                M_100_300_PROCESSA_ENDOPARC_SECTION();
            }

            /*" -565- PERFORM 100-400-QUEBRA-GERAL. */

            M_100_400_QUEBRA_GERAL_SECTION();

            /*" -566- PERFORM 000-400-FETCH-RELATORIOS. */

            M_000_400_FETCH_RELATORIOS_SECTION();

            /*" -566- PERFORM 1400-100-CLOSE-ENDOSSO. */

            M_1400_100_CLOSE_ENDOSSO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_600_EXIT*/

        [StopWatch]
        /*" M-000-700-UPDATE-V1RELATORIOS-SECTION */
        private void M_000_700_UPDATE_V1RELATORIOS_SECTION()
        {
            /*" -575- MOVE '000-700-UPDATE-V1RELATORIOS' TO PARAGRAFO. */
            _.Move("000-700-UPDATE-V1RELATORIOS", FILLER_0.WABEND.PARAGRAFO);

            /*" -579- MOVE '005' TO WNR-EXEC-SQL. */
            _.Move("005", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -589- PERFORM M_000_700_UPDATE_V1RELATORIOS_DB_UPDATE_1 */

            M_000_700_UPDATE_V1RELATORIOS_DB_UPDATE_1();

            /*" -594- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -594- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-000-700-UPDATE-V1RELATORIOS-DB-UPDATE-1 */
        public void M_000_700_UPDATE_V1RELATORIOS_DB_UPDATE_1()
        {
            /*" -589- EXEC SQL UPDATE SEGUROS.V1RELATORIOS SET SITUACAO = '1' WHERE IDSISTEM = 'VG' AND CODRELAT = 'VG0781B' AND SITUACAO = '0' END-EXEC. */

            var m_000_700_UPDATE_V1RELATORIOS_DB_UPDATE_1_Update1 = new M_000_700_UPDATE_V1RELATORIOS_DB_UPDATE_1_Update1()
            {
            };

            M_000_700_UPDATE_V1RELATORIOS_DB_UPDATE_1_Update1.Execute(m_000_700_UPDATE_V1RELATORIOS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_700_EXIT*/

        [StopWatch]
        /*" M-000-800-FINALIZA-SECTION */
        private void M_000_800_FINALIZA_SECTION()
        {
            /*" -604- MOVE '000-800-FINALIZA' TO PARAGRAFO. */
            _.Move("000-800-FINALIZA", FILLER_0.WABEND.PARAGRAFO);

            /*" -605- IF W-LIDOS NOT EQUAL ZEROES */

            if (FILLER_0.W_LIDOS != 00)
            {

                /*" -606- DISPLAY 'TOTAL LIDOS EMISSAO       = ' W-LIDOS */
                _.Display($"TOTAL LIDOS EMISSAO       = {FILLER_0.W_LIDOS}");

                /*" -608- DISPLAY 'TOTAL IMPRESSOS EMISSAO   = ' W-IMPRESSOS. */
                _.Display($"TOTAL IMPRESSOS EMISSAO   = {FILLER_0.W_IMPRESSOS}");
            }


            /*" -609- MOVE ZEROES TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -611- DISPLAY 'VG0781B *** FIM NORMAL ***' . */
            _.Display($"VG0781B *** FIM NORMAL ***");

            /*" -613- CLOSE VG0781M1. */
            VG0781M1.Close();

            /*" -613- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_800_EXIT*/

        [StopWatch]
        /*" M-100-300-PROCESSA-ENDOPARC-SECTION */
        private void M_100_300_PROCESSA_ENDOPARC_SECTION()
        {
            /*" -623- MOVE '100-300-PROCESSA-ENDOPARC' TO PARAGRAFO. */
            _.Move("100-300-PROCESSA-ENDOPARC", FILLER_0.WABEND.PARAGRAFO);

            /*" -625- MOVE WDATA-AA1 TO W-ANOINIVIG-ANT. */
            _.Move(FILLER_0.WDATA1.WDATA_AA1, FILLER_0.W_ANOINIVIG_ANT);

            /*" -629- PERFORM 200-200-PROCESSA-ANOINIVIG UNTIL W-FIM-ENDOPARC EQUAL 'S' OR WDATA-AA1 NOT EQUAL W-ANOINIVIG-ANT. */

            while (!(FILLER_0.W_FIM_ENDOPARC == "S" || FILLER_0.WDATA1.WDATA_AA1 != FILLER_0.W_ANOINIVIG_ANT))
            {

                M_200_200_PROCESSA_ANOINIVIG_SECTION();
            }

            /*" -629- PERFORM 200-300-QUEBRA-ANOINIVIG. */

            M_200_300_QUEBRA_ANOINIVIG_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_300_EXIT*/

        [StopWatch]
        /*" M-100-400-QUEBRA-GERAL-SECTION */
        private void M_100_400_QUEBRA_GERAL_SECTION()
        {
            /*" -639- MOVE '100-400-QUEBRA-GERAL' TO PARAGRAFO. */
            _.Move("100-400-QUEBRA-GERAL", FILLER_0.WABEND.PARAGRAFO);

            /*" -641- PERFORM 500-100-IMPRIME-CABECALHO. */

            M_500_100_IMPRIME_CABECALHO_SECTION();

            /*" -642- MOVE W-ACC-GERAL1 TO LT03-ACC-GERAL1. */
            _.Move(FILLER_0.W_ACC_GERAL1, FILLER_0.LT03.LT03_ACC_GERAL1);

            /*" -643- MOVE W-ACC-GERAL2 TO LT03-ACC-GERAL2. */
            _.Move(FILLER_0.W_ACC_GERAL2, FILLER_0.LT03.LT03_ACC_GERAL2);

            /*" -644- MOVE W-ACC-GERAL3 TO LT03-ACC-GERAL3. */
            _.Move(FILLER_0.W_ACC_GERAL3, FILLER_0.LT03.LT03_ACC_GERAL3);

            /*" -646- MOVE W-ACC-GERAL4 TO LT03-ACC-GERAL4. */
            _.Move(FILLER_0.W_ACC_GERAL4, FILLER_0.LT03.LT03_ACC_GERAL4);

            /*" -648- WRITE REG-VG0781M1 FROM LT03 AFTER 6. */
            _.Move(FILLER_0.LT03.GetMoveValues(), REG_VG0781M1);

            VG0781M1.Write(REG_VG0781M1.GetMoveValues().ToString());

            /*" -648- MOVE 70 TO W-CONT-LIN. */
            _.Move(70, FILLER_0.W_CONT_LIN);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_400_EXIT*/

        [StopWatch]
        /*" M-200-100-SELECT-V1MOEDA-SECTION */
        private void M_200_100_SELECT_V1MOEDA_SECTION()
        {
            /*" -657- MOVE '200-100-SELECT-V1MOEDA' TO PARAGRAFO. */
            _.Move("200-100-SELECT-V1MOEDA", FILLER_0.WABEND.PARAGRAFO);

            /*" -661- MOVE '007' TO WNR-EXEC-SQL. */
            _.Move("007", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -675- PERFORM M_200_100_SELECT_V1MOEDA_DB_SELECT_1 */

            M_200_100_SELECT_V1MOEDA_DB_SELECT_1();

            /*" -680- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -681- DISPLAY W-MENSAGEM5 */
                _.Display(FILLER_0.FILLER_81.W_MENSAGEM5);

                /*" -681- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-200-100-SELECT-V1MOEDA-DB-SELECT-1 */
        public void M_200_100_SELECT_V1MOEDA_DB_SELECT_1()
        {
            /*" -675- EXEC SQL SELECT VLCRUZAD INTO :V1MOEDA-VLCRUZAD FROM SEGUROS.V1MOEDA WHERE CODUNIMO = 5 AND DTINIVIG <= :V0ENDOPARC-DTQITBCO AND DTTERVIG >= :V0ENDOPARC-DTQITBCO END-EXEC. */

            var m_200_100_SELECT_V1MOEDA_DB_SELECT_1_Query1 = new M_200_100_SELECT_V1MOEDA_DB_SELECT_1_Query1()
            {
                V0ENDOPARC_DTQITBCO = V0ENDOPARC_DTQITBCO.ToString(),
            };

            var executed_1 = M_200_100_SELECT_V1MOEDA_DB_SELECT_1_Query1.Execute(m_200_100_SELECT_V1MOEDA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1MOEDA_VLCRUZAD, V1MOEDA_VLCRUZAD);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_200_100_EXIT*/

        [StopWatch]
        /*" M-200-200-PROCESSA-ANOINIVIG-SECTION */
        private void M_200_200_PROCESSA_ANOINIVIG_SECTION()
        {
            /*" -691- MOVE '200-200-PROCESSA-ANOINIVIG' TO PARAGRAFO. */
            _.Move("200-200-PROCESSA-ANOINIVIG", FILLER_0.WABEND.PARAGRAFO);

            /*" -693- MOVE WDATA-MM1 TO W-MESINIVIG-ANT. */
            _.Move(FILLER_0.WDATA1.WDATA_MM1, FILLER_0.W_MESINIVIG_ANT);

            /*" -698- PERFORM 300-100-PROCESSA-MESINIVIG UNTIL W-FIM-ENDOPARC EQUAL 'S' OR WDATA-AA1 NOT EQUAL W-ANOINIVIG-ANT OR WDATA-MM1 NOT EQUAL W-MESINIVIG-ANT. */

            while (!(FILLER_0.W_FIM_ENDOPARC == "S" || FILLER_0.WDATA1.WDATA_AA1 != FILLER_0.W_ANOINIVIG_ANT || FILLER_0.WDATA1.WDATA_MM1 != FILLER_0.W_MESINIVIG_ANT))
            {

                M_300_100_PROCESSA_MESINIVIG_SECTION();
            }

            /*" -698- PERFORM 300-200-QUEBRA-MESINIVIG. */

            M_300_200_QUEBRA_MESINIVIG_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_200_200_EXIT*/

        [StopWatch]
        /*" M-200-300-QUEBRA-ANOINIVIG-SECTION */
        private void M_200_300_QUEBRA_ANOINIVIG_SECTION()
        {
            /*" -708- MOVE '200-300-QUEBRA-ANOINIVIG' TO PARAGRAFO. */
            _.Move("200-300-QUEBRA-ANOINIVIG", FILLER_0.WABEND.PARAGRAFO);

            /*" -709- ADD W-ACC-ANO1 TO W-ACC-GERAL1. */
            FILLER_0.W_ACC_GERAL1.Value = FILLER_0.W_ACC_GERAL1 + FILLER_0.W_ACC_ANO1;

            /*" -710- ADD W-ACC-ANO2 TO W-ACC-GERAL2. */
            FILLER_0.W_ACC_GERAL2.Value = FILLER_0.W_ACC_GERAL2 + FILLER_0.W_ACC_ANO2;

            /*" -711- ADD W-ACC-ANO3 TO W-ACC-GERAL3. */
            FILLER_0.W_ACC_GERAL3.Value = FILLER_0.W_ACC_GERAL3 + FILLER_0.W_ACC_ANO3;

            /*" -713- ADD W-ACC-ANO4 TO W-ACC-GERAL4. */
            FILLER_0.W_ACC_GERAL4.Value = FILLER_0.W_ACC_GERAL4 + FILLER_0.W_ACC_ANO4;

            /*" -714- MOVE W-ACC-ANO1 TO LT02-ACC-ANO1. */
            _.Move(FILLER_0.W_ACC_ANO1, FILLER_0.LT02.LT02_ACC_ANO1);

            /*" -715- MOVE W-ACC-ANO2 TO LT02-ACC-ANO2. */
            _.Move(FILLER_0.W_ACC_ANO2, FILLER_0.LT02.LT02_ACC_ANO2);

            /*" -716- MOVE W-ACC-ANO3 TO LT02-ACC-ANO3. */
            _.Move(FILLER_0.W_ACC_ANO3, FILLER_0.LT02.LT02_ACC_ANO3);

            /*" -718- MOVE W-ACC-ANO4 TO LT02-ACC-ANO4. */
            _.Move(FILLER_0.W_ACC_ANO4, FILLER_0.LT02.LT02_ACC_ANO4);

            /*" -719- MOVE 00 TO W-ACC-ANO1. */
            _.Move(00, FILLER_0.W_ACC_ANO1);

            /*" -720- MOVE 00 TO W-ACC-ANO2. */
            _.Move(00, FILLER_0.W_ACC_ANO2);

            /*" -721- MOVE 00 TO W-ACC-ANO3. */
            _.Move(00, FILLER_0.W_ACC_ANO3);

            /*" -723- MOVE 00 TO W-ACC-ANO4. */
            _.Move(00, FILLER_0.W_ACC_ANO4);

            /*" -725- MOVE 70 TO W-CONT-LIN. */
            _.Move(70, FILLER_0.W_CONT_LIN);

            /*" -727- WRITE REG-VG0781M1 FROM LT02 AFTER 3. */
            _.Move(FILLER_0.LT02.GetMoveValues(), REG_VG0781M1);

            VG0781M1.Write(REG_VG0781M1.GetMoveValues().ToString());

            /*" -727- MOVE WDATA-AA1 TO LD01-ANOINIVIG. */
            _.Move(FILLER_0.WDATA1.WDATA_AA1, FILLER_0.LD01.LD01_ANOINIVIG);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_200_300_EXIT*/

        [StopWatch]
        /*" M-300-100-PROCESSA-MESINIVIG-SECTION */
        private void M_300_100_PROCESSA_MESINIVIG_SECTION()
        {
            /*" -737- MOVE '300-100-PROCESSA-MESINIVIG' TO PARAGRAFO. */
            _.Move("300-100-PROCESSA-MESINIVIG", FILLER_0.WABEND.PARAGRAFO);

            /*" -738- PERFORM 400-100-IMPRIME-DETALHE. */

            M_400_100_IMPRIME_DETALHE_SECTION();

            /*" -739- MOVE ' ' TO W-FIM-ENDOPARC. */
            _.Move(" ", FILLER_0.W_FIM_ENDOPARC);

            /*" -739- PERFORM 1300-100-BUSCAR-LINHAS. */

            M_1300_100_BUSCAR_LINHAS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_300_100_EXIT*/

        [StopWatch]
        /*" M-300-200-QUEBRA-MESINIVIG-SECTION */
        private void M_300_200_QUEBRA_MESINIVIG_SECTION()
        {
            /*" -748- MOVE '300-200-QUEBRA-MESINIVIG' TO PARAGRAFO. */
            _.Move("300-200-QUEBRA-MESINIVIG", FILLER_0.WABEND.PARAGRAFO);

            /*" -749- ADD W-ACC-MES1 TO W-ACC-ANO1. */
            FILLER_0.W_ACC_ANO1.Value = FILLER_0.W_ACC_ANO1 + FILLER_0.W_ACC_MES1;

            /*" -750- ADD W-ACC-MES2 TO W-ACC-ANO2. */
            FILLER_0.W_ACC_ANO2.Value = FILLER_0.W_ACC_ANO2 + FILLER_0.W_ACC_MES2;

            /*" -751- ADD W-ACC-MES3 TO W-ACC-ANO3. */
            FILLER_0.W_ACC_ANO3.Value = FILLER_0.W_ACC_ANO3 + FILLER_0.W_ACC_MES3;

            /*" -753- ADD W-ACC-MES4 TO W-ACC-ANO4. */
            FILLER_0.W_ACC_ANO4.Value = FILLER_0.W_ACC_ANO4 + FILLER_0.W_ACC_MES4;

            /*" -754- MOVE W-ACC-MES1 TO LT01-ACC-MES1. */
            _.Move(FILLER_0.W_ACC_MES1, FILLER_0.LT01.LT01_ACC_MES1);

            /*" -755- MOVE W-ACC-MES2 TO LT01-ACC-MES2. */
            _.Move(FILLER_0.W_ACC_MES2, FILLER_0.LT01.LT01_ACC_MES2);

            /*" -756- MOVE W-ACC-MES3 TO LT01-ACC-MES3. */
            _.Move(FILLER_0.W_ACC_MES3, FILLER_0.LT01.LT01_ACC_MES3);

            /*" -758- MOVE W-ACC-MES4 TO LT01-ACC-MES4. */
            _.Move(FILLER_0.W_ACC_MES4, FILLER_0.LT01.LT01_ACC_MES4);

            /*" -759- MOVE 00 TO W-ACC-MES1. */
            _.Move(00, FILLER_0.W_ACC_MES1);

            /*" -760- MOVE 00 TO W-ACC-MES2. */
            _.Move(00, FILLER_0.W_ACC_MES2);

            /*" -761- MOVE 00 TO W-ACC-MES3. */
            _.Move(00, FILLER_0.W_ACC_MES3);

            /*" -763- MOVE 00 TO W-ACC-MES4. */
            _.Move(00, FILLER_0.W_ACC_MES4);

            /*" -765- WRITE REG-VG0781M1 FROM LT01 AFTER 3. */
            _.Move(FILLER_0.LT01.GetMoveValues(), REG_VG0781M1);

            VG0781M1.Write(REG_VG0781M1.GetMoveValues().ToString());

            /*" -767- ADD 3 TO W-CONT-LIN. */
            FILLER_0.W_CONT_LIN.Value = FILLER_0.W_CONT_LIN + 3;

            /*" -767- MOVE WDATA-MM1 TO LD01-MESINIVIG. */
            _.Move(FILLER_0.WDATA1.WDATA_MM1, FILLER_0.LD01.LD01_MESINIVIG);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_300_200_EXIT*/

        [StopWatch]
        /*" M-400-100-IMPRIME-DETALHE-SECTION */
        private void M_400_100_IMPRIME_DETALHE_SECTION()
        {
            /*" -777- MOVE '400-100-IMPRIME-DETALHE' TO PARAGRAFO. */
            _.Move("400-100-IMPRIME-DETALHE", FILLER_0.WABEND.PARAGRAFO);

            /*" -778- IF W-CONT-LIN GREATER 55 */

            if (FILLER_0.W_CONT_LIN > 55)
            {

                /*" -780- PERFORM 500-100-IMPRIME-CABECALHO. */

                M_500_100_IMPRIME_CABECALHO_SECTION();
            }


            /*" -782- WRITE REG-VG0781M1 FROM LD01 AFTER 2. */
            _.Move(FILLER_0.LD01.GetMoveValues(), REG_VG0781M1);

            VG0781M1.Write(REG_VG0781M1.GetMoveValues().ToString());

            /*" -783- MOVE SPACES TO LD01-ANOINIVIG. */
            _.Move("", FILLER_0.LD01.LD01_ANOINIVIG);

            /*" -785- MOVE SPACES TO LD01-MESINIVIG. */
            _.Move("", FILLER_0.LD01.LD01_MESINIVIG);

            /*" -786- ADD W-VLPRMLIQ1 TO W-ACC-MES1. */
            FILLER_0.W_ACC_MES1.Value = FILLER_0.W_ACC_MES1 + FILLER_0.W_VLPRMLIQ1;

            /*" -787- ADD W-VLPRMLIQ2 TO W-ACC-MES2. */
            FILLER_0.W_ACC_MES2.Value = FILLER_0.W_ACC_MES2 + FILLER_0.W_VLPRMLIQ2;

            /*" -788- ADD W-VLPRMLIQ3 TO W-ACC-MES3. */
            FILLER_0.W_ACC_MES3.Value = FILLER_0.W_ACC_MES3 + FILLER_0.W_VLPRMLIQ3;

            /*" -790- ADD W-VLPRMLIQ4 TO W-ACC-MES4. */
            FILLER_0.W_ACC_MES4.Value = FILLER_0.W_ACC_MES4 + FILLER_0.W_VLPRMLIQ4;

            /*" -791- ADD 2 TO W-CONT-LIN. */
            FILLER_0.W_CONT_LIN.Value = FILLER_0.W_CONT_LIN + 2;

            /*" -791- ADD 1 TO W-IMPRESSOS. */
            FILLER_0.W_IMPRESSOS.Value = FILLER_0.W_IMPRESSOS + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_400_100_EXIT*/

        [StopWatch]
        /*" M-500-100-IMPRIME-CABECALHO-SECTION */
        private void M_500_100_IMPRIME_CABECALHO_SECTION()
        {
            /*" -801- MOVE '500-100-IMPRIME-CABECALHO' TO PARAGRAFO. */
            _.Move("500-100-IMPRIME-CABECALHO", FILLER_0.WABEND.PARAGRAFO);

            /*" -803- ADD 1 TO W-CONT-PAG. */
            FILLER_0.W_CONT_PAG.Value = FILLER_0.W_CONT_PAG + 1;

            /*" -805- MOVE W-CONT-PAG TO LC01-PAGINA. */
            _.Move(FILLER_0.W_CONT_PAG, FILLER_0.LC01.LC01_PAGINA);

            /*" -806- WRITE REG-VG0781M1 FROM LC01 AFTER NEW-PAGE. */
            _.Move(FILLER_0.LC01.GetMoveValues(), REG_VG0781M1);

            VG0781M1.Write(REG_VG0781M1.GetMoveValues().ToString());

            /*" -807- WRITE REG-VG0781M1 FROM LC02 AFTER 1. */
            _.Move(FILLER_0.LC02.GetMoveValues(), REG_VG0781M1);

            VG0781M1.Write(REG_VG0781M1.GetMoveValues().ToString());

            /*" -808- WRITE REG-VG0781M1 FROM LC03 AFTER 1. */
            _.Move(FILLER_0.LC03.GetMoveValues(), REG_VG0781M1);

            VG0781M1.Write(REG_VG0781M1.GetMoveValues().ToString());

            /*" -809- WRITE REG-VG0781M1 FROM LC04 AFTER 1. */
            _.Move(FILLER_0.LC04.GetMoveValues(), REG_VG0781M1);

            VG0781M1.Write(REG_VG0781M1.GetMoveValues().ToString());

            /*" -810- WRITE REG-VG0781M1 FROM LC05 AFTER 1. */
            _.Move(FILLER_0.LC05.GetMoveValues(), REG_VG0781M1);

            VG0781M1.Write(REG_VG0781M1.GetMoveValues().ToString());

            /*" -811- WRITE REG-VG0781M1 FROM LC06 AFTER 1. */
            _.Move(FILLER_0.LC06.GetMoveValues(), REG_VG0781M1);

            VG0781M1.Write(REG_VG0781M1.GetMoveValues().ToString());

            /*" -813- WRITE REG-VG0781M1 FROM LC05 AFTER 1. */
            _.Move(FILLER_0.LC05.GetMoveValues(), REG_VG0781M1);

            VG0781M1.Write(REG_VG0781M1.GetMoveValues().ToString());

            /*" -813- MOVE 7 TO W-CONT-LIN. */
            _.Move(7, FILLER_0.W_CONT_LIN);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_500_100_EXIT*/

        [StopWatch]
        /*" M-600-100-DECLARA-ENDOSSO-SECTION */
        private void M_600_100_DECLARA_ENDOSSO_SECTION()
        {
            /*" -822- MOVE '600-100-DECLARA-ENDOSSO ' TO PARAGRAFO. */
            _.Move("600-100-DECLARA-ENDOSSO ", FILLER_0.WABEND.PARAGRAFO);

            /*" -824- MOVE '006' TO WNR-EXEC-SQL. */
            _.Move("006", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -840- PERFORM M_600_100_DECLARA_ENDOSSO_DB_DECLARE_1 */

            M_600_100_DECLARA_ENDOSSO_DB_DECLARE_1();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_600_100_EXIT*/

        [StopWatch]
        /*" M-700-100-FETCH-ENDOSSO-SECTION */
        private void M_700_100_FETCH_ENDOSSO_SECTION()
        {
            /*" -846- MOVE '700-100-FETCH-ENDOSSO ' TO PARAGRAFO. */
            _.Move("700-100-FETCH-ENDOSSO ", FILLER_0.WABEND.PARAGRAFO);

            /*" -853- PERFORM M_700_100_FETCH_ENDOSSO_DB_FETCH_1 */

            M_700_100_FETCH_ENDOSSO_DB_FETCH_1();

        }

        [StopWatch]
        /*" M-700-100-FETCH-ENDOSSO-DB-FETCH-1 */
        public void M_700_100_FETCH_ENDOSSO_DB_FETCH_1()
        {
            /*" -853- EXEC SQL FETCH ENDOSSO INTO :V0APOLICE-ENDOSSO, :V0ENDOPARC-DTINIVIG, :V0ENDOPARC-CODSUBES, :V0ENDOPARC-NRENDOS, :V0ENDOPARC-DTEMIS END-EXEC. */

            if (ENDOSSO.Fetch())
            {
                _.Move(ENDOSSO.V0APOLICE_ENDOSSO, V0APOLICE_ENDOSSO);
                _.Move(ENDOSSO.V0ENDOPARC_DTINIVIG, V0ENDOPARC_DTINIVIG);
                _.Move(ENDOSSO.V0ENDOPARC_CODSUBES, V0ENDOPARC_CODSUBES);
                _.Move(ENDOSSO.V0ENDOPARC_NRENDOS, V0ENDOPARC_NRENDOS);
                _.Move(ENDOSSO.V0ENDOPARC_DTEMIS, V0ENDOPARC_DTEMIS);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_700_100_EXIT*/

        [StopWatch]
        /*" M-800-100-BUSCA-HISTORICO-SECTION */
        private void M_800_100_BUSCA_HISTORICO_SECTION()
        {
            /*" -859- MOVE '800-100-BUSCA-HISTORICO' TO PARAGRAFO. */
            _.Move("800-100-BUSCA-HISTORICO", FILLER_0.WABEND.PARAGRAFO);

            /*" -861- MOVE '008' TO WNR-EXEC-SQL. */
            _.Move("008", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -876- PERFORM M_800_100_BUSCA_HISTORICO_DB_SELECT_1 */

            M_800_100_BUSCA_HISTORICO_DB_SELECT_1();

        }

        [StopWatch]
        /*" M-800-100-BUSCA-HISTORICO-DB-SELECT-1 */
        public void M_800_100_BUSCA_HISTORICO_DB_SELECT_1()
        {
            /*" -876- EXEC SQL SELECT VALUE(MAX(VLPRMLIQ), 0), VALUE(MAX(DTQITBCO), DATE( ' ' )), VALUE(MAX(DTMOVTO), DATE( ' ' )) INTO :V0ENDOPARC-VLPRMLIQ, :V0ENDOPARC-DTQITBCO, :V0ENDOPARC-DTMOVTO FROM SEGUROS.V0HISTOPARC WHERE NUM_APOLICE = :V1RELATORIOS-APOLICE AND NRENDOS = :V0ENDOPARC-NRENDOS AND OPERACAO >= 200 AND OPERACAO <= 299 END-EXEC. */

            var m_800_100_BUSCA_HISTORICO_DB_SELECT_1_Query1 = new M_800_100_BUSCA_HISTORICO_DB_SELECT_1_Query1()
            {
                V1RELATORIOS_APOLICE = V1RELATORIOS_APOLICE.ToString(),
                V0ENDOPARC_NRENDOS = V0ENDOPARC_NRENDOS.ToString(),
            };

            var executed_1 = M_800_100_BUSCA_HISTORICO_DB_SELECT_1_Query1.Execute(m_800_100_BUSCA_HISTORICO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ENDOPARC_VLPRMLIQ, V0ENDOPARC_VLPRMLIQ);
                _.Move(executed_1.V0ENDOPARC_DTQITBCO, V0ENDOPARC_DTQITBCO);
                _.Move(executed_1.V0ENDOPARC_DTMOVTO, V0ENDOPARC_DTMOVTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_800_100_EXIT*/

        [StopWatch]
        /*" M-1000-100-BUSCA-COBERTURA-SECTION */
        private void M_1000_100_BUSCA_COBERTURA_SECTION()
        {
            /*" -884- MOVE '1000-100-BUSCA-COBERTURA' TO PARAGRAFO. */
            _.Move("1000-100-BUSCA-COBERTURA", FILLER_0.WABEND.PARAGRAFO);

            /*" -886- MOVE '009' TO WNR-EXEC-SQL. */
            _.Move("009", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -899- PERFORM M_1000_100_BUSCA_COBERTURA_DB_SELECT_1 */

            M_1000_100_BUSCA_COBERTURA_DB_SELECT_1();

        }

        [StopWatch]
        /*" M-1000-100-BUSCA-COBERTURA-DB-SELECT-1 */
        public void M_1000_100_BUSCA_COBERTURA_DB_SELECT_1()
        {
            /*" -899- EXEC SQL SELECT PCT_COBERTURA INTO :V0ENDOPARC-PCT-COBERTURA FROM SEGUROS.V0COBERAPOL WHERE NUM_APOLICE = :V1RELATORIOS-APOLICE AND NRENDOS = :V0ENDOPARC-NRENDOS AND NUM_ITEM = 0 AND RAMOFR = 93 END-EXEC. */

            var m_1000_100_BUSCA_COBERTURA_DB_SELECT_1_Query1 = new M_1000_100_BUSCA_COBERTURA_DB_SELECT_1_Query1()
            {
                V1RELATORIOS_APOLICE = V1RELATORIOS_APOLICE.ToString(),
                V0ENDOPARC_NRENDOS = V0ENDOPARC_NRENDOS.ToString(),
            };

            var executed_1 = M_1000_100_BUSCA_COBERTURA_DB_SELECT_1_Query1.Execute(m_1000_100_BUSCA_COBERTURA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ENDOPARC_PCT_COBERTURA, V0ENDOPARC_PCT_COBERTURA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1000_100_EXIT*/

        [StopWatch]
        /*" M-1100-100-FIM-SELECAO-SECTION */
        private void M_1100_100_FIM_SELECAO_SECTION()
        {
            /*" -905- MOVE '1100-100-FIM-SELECAO  ' TO PARAGRAFO. */
            _.Move("1100-100-FIM-SELECAO  ", FILLER_0.WABEND.PARAGRAFO);

            /*" -906- ADD 1 TO W-LIDOS */
            FILLER_0.W_LIDOS.Value = FILLER_0.W_LIDOS + 1;

            /*" -907- MOVE V0ENDOPARC-DTEMIS TO WDATA */
            _.Move(V0ENDOPARC_DTEMIS, FILLER_0.WDATA);

            /*" -908- MOVE WDATA-DD TO WDATA-DD-CABEC */
            _.Move(FILLER_0.WDATA.WDATA_DD, FILLER_0.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -909- MOVE WDATA-MM TO WDATA-MM-CABEC */
            _.Move(FILLER_0.WDATA.WDATA_MM, FILLER_0.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -910- MOVE WDATA-AA TO WDATA-AA-CABEC */
            _.Move(FILLER_0.WDATA.WDATA_AA, FILLER_0.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -911- MOVE WDATA-CABEC TO LD01-DTEMIS */
            _.Move(FILLER_0.WDATA_CABEC, FILLER_0.LD01.LD01_DTEMIS);

            /*" -912- MOVE V0ENDOPARC-DTQITBCO TO WDATA */
            _.Move(V0ENDOPARC_DTQITBCO, FILLER_0.WDATA);

            /*" -913- MOVE WDATA-DD TO WDATA-DD-CABEC */
            _.Move(FILLER_0.WDATA.WDATA_DD, FILLER_0.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -914- MOVE WDATA-MM TO WDATA-MM-CABEC */
            _.Move(FILLER_0.WDATA.WDATA_MM, FILLER_0.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -915- MOVE WDATA-AA TO WDATA-AA-CABEC */
            _.Move(FILLER_0.WDATA.WDATA_AA, FILLER_0.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -916- MOVE WDATA-CABEC TO LD01-DTQITBCO */
            _.Move(FILLER_0.WDATA_CABEC, FILLER_0.LD01.LD01_DTQITBCO);

            /*" -917- MOVE V0ENDOPARC-DTMOVTO TO WDATA */
            _.Move(V0ENDOPARC_DTMOVTO, FILLER_0.WDATA);

            /*" -918- MOVE WDATA-DD TO WDATA-DD-CABEC */
            _.Move(FILLER_0.WDATA.WDATA_DD, FILLER_0.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -919- MOVE WDATA-MM TO WDATA-MM-CABEC */
            _.Move(FILLER_0.WDATA.WDATA_MM, FILLER_0.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -920- MOVE WDATA-AA TO WDATA-AA-CABEC */
            _.Move(FILLER_0.WDATA.WDATA_AA, FILLER_0.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -921- MOVE WDATA-CABEC TO LD01-DTMOVTO */
            _.Move(FILLER_0.WDATA_CABEC, FILLER_0.LD01.LD01_DTMOVTO);

            /*" -922- MOVE V0ENDOPARC-DTINIVIG TO WDATA1 */
            _.Move(V0ENDOPARC_DTINIVIG, FILLER_0.WDATA1);

            /*" -923- MOVE V0ENDOPARC-CODSUBES TO LD01-CODSUBES */
            _.Move(V0ENDOPARC_CODSUBES, FILLER_0.LD01.LD01_CODSUBES);

            /*" -925- MOVE V0ENDOPARC-NRENDOS TO LD01-NRENDOS */
            _.Move(V0ENDOPARC_NRENDOS, FILLER_0.LD01.LD01_NRENDOS);

            /*" -927- PERFORM 200-100-SELECT-V1MOEDA */

            M_200_100_SELECT_V1MOEDA_SECTION();

            /*" -932- COMPUTE W-VLPRMLIQ1 = V0ENDOPARC-VLPRMLIQ * V0ENDOPARC-PCT-COBERTURA / 100 */
            FILLER_0.W_VLPRMLIQ1.Value = V0ENDOPARC_VLPRMLIQ * V0ENDOPARC_PCT_COBERTURA / 100f;

            /*" -936- COMPUTE W-VLPRMLIQ2 = V0ENDOPARC-VLPRMLIQ - W-VLPRMLIQ1 */
            FILLER_0.W_VLPRMLIQ2.Value = V0ENDOPARC_VLPRMLIQ - FILLER_0.W_VLPRMLIQ1;

            /*" -940- COMPUTE W-VLPRMLIQ3 = W-VLPRMLIQ1 / V1MOEDA-VLCRUZAD */
            FILLER_0.W_VLPRMLIQ3.Value = FILLER_0.W_VLPRMLIQ1 / V1MOEDA_VLCRUZAD;

            /*" -944- COMPUTE W-VLPRMLIQ4 = W-VLPRMLIQ2 / V1MOEDA-VLCRUZAD */
            FILLER_0.W_VLPRMLIQ4.Value = FILLER_0.W_VLPRMLIQ2 / V1MOEDA_VLCRUZAD;

            /*" -945- MOVE W-VLPRMLIQ1 TO LD01-VLPRMLIQ1 */
            _.Move(FILLER_0.W_VLPRMLIQ1, FILLER_0.LD01.LD01_VLPRMLIQ1);

            /*" -946- MOVE W-VLPRMLIQ2 TO LD01-VLPRMLIQ2 */
            _.Move(FILLER_0.W_VLPRMLIQ2, FILLER_0.LD01.LD01_VLPRMLIQ2);

            /*" -947- MOVE W-VLPRMLIQ3 TO LD01-VLPRMLIQ3 */
            _.Move(FILLER_0.W_VLPRMLIQ3, FILLER_0.LD01.LD01_VLPRMLIQ3);

            /*" -947- MOVE W-VLPRMLIQ4 TO LD01-VLPRMLIQ4. */
            _.Move(FILLER_0.W_VLPRMLIQ4, FILLER_0.LD01.LD01_VLPRMLIQ4);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1100_100_EXIT*/

        [StopWatch]
        /*" M-1300-100-BUSCAR-LINHAS-SECTION */
        private void M_1300_100_BUSCAR_LINHAS_SECTION()
        {
            /*" -954- MOVE '1300-100-BUSCAR-LINHAS' TO PARAGRAFO. */
            _.Move("1300-100-BUSCAR-LINHAS", FILLER_0.WABEND.PARAGRAFO);

            /*" -955- MOVE 'N' TO W-FIM-ENDOPARC. */
            _.Move("N", FILLER_0.W_FIM_ENDOPARC);

            /*" -956- PERFORM 700-100-FETCH-ENDOSSO */

            M_700_100_FETCH_ENDOSSO_SECTION();

            /*" -957- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -958- MOVE 'S' TO W-FIM-ENDOPARC */
                _.Move("S", FILLER_0.W_FIM_ENDOPARC);

                /*" -959- ELSE */
            }
            else
            {


                /*" -960- PERFORM 800-100-BUSCA-HISTORICO */

                M_800_100_BUSCA_HISTORICO_SECTION();

                /*" -961- IF V0ENDOPARC-VLPRMLIQ = 0 */

                if (V0ENDOPARC_VLPRMLIQ == 0)
                {

                    /*" -962- DISPLAY 'FIM ANORMAL DO PROGRAMA' */
                    _.Display($"FIM ANORMAL DO PROGRAMA");

                    /*" -963- DISPLAY ' EXISTE ENDOSSO PAGO SEM HISTORICO' */
                    _.Display($" EXISTE ENDOSSO PAGO SEM HISTORICO");

                    /*" -964- PERFORM 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO_SECTION();

                    /*" -965- ELSE */
                }
                else
                {


                    /*" -966- PERFORM 1000-100-BUSCA-COBERTURA */

                    M_1000_100_BUSCA_COBERTURA_SECTION();

                    /*" -967- IF SQLCODE = 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -968- DISPLAY 'FIM ANORMAL DO PROGRAMA' */
                        _.Display($"FIM ANORMAL DO PROGRAMA");

                        /*" -969- DISPLAY ' EXISTE ENDOSSO PAGO SEM OPCAO COBERT' */
                        _.Display($" EXISTE ENDOSSO PAGO SEM OPCAO COBERT");

                        /*" -970- PERFORM 999-999-ROT-ERRO */

                        M_999_999_ROT_ERRO_SECTION();

                        /*" -971- ELSE */
                    }
                    else
                    {


                        /*" -971- PERFORM 1100-100-FIM-SELECAO. */

                        M_1100_100_FIM_SELECAO_SECTION();
                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1300_100_EXIT*/

        [StopWatch]
        /*" M-1400-100-CLOSE-ENDOSSO-SECTION */
        private void M_1400_100_CLOSE_ENDOSSO_SECTION()
        {
            /*" -976- MOVE '1400-100-CLOSE-ENDOSS' TO PARAGRAFO. */
            _.Move("1400-100-CLOSE-ENDOSS", FILLER_0.WABEND.PARAGRAFO);

            /*" -976- PERFORM M_1400_100_CLOSE_ENDOSSO_DB_CLOSE_1 */

            M_1400_100_CLOSE_ENDOSSO_DB_CLOSE_1();

        }

        [StopWatch]
        /*" M-1400-100-CLOSE-ENDOSSO-DB-CLOSE-1 */
        public void M_1400_100_CLOSE_ENDOSSO_DB_CLOSE_1()
        {
            /*" -976- EXEC SQL CLOSE ENDOSSO END-EXEC. */

            ENDOSSO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1400_100_EXIT*/

        [StopWatch]
        /*" M-1500-100-OPEN-ENDOSSO-SECTION */
        private void M_1500_100_OPEN_ENDOSSO_SECTION()
        {
            /*" -980- MOVE '1500-100-OPEN-ENDOSSO ' TO PARAGRAFO. */
            _.Move("1500-100-OPEN-ENDOSSO ", FILLER_0.WABEND.PARAGRAFO);

            /*" -980- PERFORM M_1500_100_OPEN_ENDOSSO_DB_OPEN_1 */

            M_1500_100_OPEN_ENDOSSO_DB_OPEN_1();

        }

        [StopWatch]
        /*" M-1500-100-OPEN-ENDOSSO-DB-OPEN-1 */
        public void M_1500_100_OPEN_ENDOSSO_DB_OPEN_1()
        {
            /*" -980- EXEC SQL OPEN ENDOSSO END-EXEC. */

            ENDOSSO.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1500_100_EXIT*/

        [StopWatch]
        /*" M-999-999-ROT-ERRO-SECTION */
        private void M_999_999_ROT_ERRO_SECTION()
        {
            /*" -987- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -988- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], FILLER_0.WABEND.WSQLCODE1);

                /*" -989- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], FILLER_0.WABEND.WSQLCODE2);

                /*" -990- MOVE SQLCODE TO WSQLCODE3 */
                _.Move(DB.SQLCODE, FILLER_0.WSQLCODE3);

                /*" -992- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, FILLER_0.WABEND.WSQLCODE);

                /*" -994- DISPLAY WABEND. */
                _.Display(FILLER_0.WABEND);
            }


            /*" -995- CLOSE VG0781M1. */
            VG0781M1.Close();

            /*" -996- DISPLAY 'ENDS-' V0ENDOPARC-NRENDOS. */
            _.Display($"ENDS-{V0ENDOPARC_NRENDOS}");

            /*" -999- DISPLAY 'APOL-' V0APOLICE-ENDOSSO */
            _.Display($"APOL-{V0APOLICE_ENDOSSO}");

            /*" -999- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1000- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1003- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1003- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_999_999_EXIT*/
    }
}