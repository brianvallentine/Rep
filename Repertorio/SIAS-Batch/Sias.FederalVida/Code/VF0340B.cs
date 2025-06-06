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
using Sias.FederalVida.DB2.VF0340B;

namespace Code
{
    public class VF0340B
    {
        public bool IsCall { get; set; }

        public VF0340B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *  GERA FITA COM LANCAMENTOS DE DEBITO EM CONTA DO SEGURO        *      */
        /*"      *                 CONVENIO 6131 FEDERAL VIDA                     *      */
        /*"      *                                                                *      */
        /*"      *     PROGRAMA JA ADAPTADO PARA O LAYOUT CEF ANO 2000.           *      */
        /*"      *                                                                *      */
        /*"      *                          ALEXANDRE FONSECA      29/09/98       *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO 01 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 19/11/2014 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.01         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        public FileBasis _MOVIMENTO { get; set; } = new FileBasis(new PIC("X", "150", "X(150)"));

        public FileBasis MOVIMENTO
        {
            get
            {
                _.Move(MOVIMENTO_RECORD, _MOVIMENTO); VarBasis.RedefinePassValue(MOVIMENTO_RECORD, _MOVIMENTO, MOVIMENTO_RECORD); return _MOVIMENTO;
            }
        }
        /*"01  MOVIMENTO-RECORD    PIC X(150).*/
        public StringBasis MOVIMENTO_RECORD { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  SIST-CURRDATE                    PIC X(10).*/
        public StringBasis SIST_CURRDATE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  SIST-DTMAXDEB                    PIC X(10).*/
        public StringBasis SIST_DTMAXDEB { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  SIST-DTMINDEB                    PIC X(10).*/
        public StringBasis SIST_DTMINDEB { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PARM-CODCONV                     PIC S9(9)     COMP.*/
        public IntBasis PARM_CODCONV { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01  PARM-NSA                         PIC S9(4)     COMP.*/
        public IntBasis PARM_NSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  PARM-VERSAO                      PIC S9(4)     COMP.*/
        public IntBasis PARM_VERSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  NRCERTIF                         PIC S9(15)    COMP-3.*/
        public IntBasis NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  NRPARCEL                         PIC S9(4)     COMP.*/
        public IntBasis NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  AGECTADEB                        PIC S9(4)     COMP.*/
        public IntBasis AGECTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  OPRCTADEB                        PIC S9(4)     COMP.*/
        public IntBasis OPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  NUMCTADEB                        PIC S9(13)    COMP-3.*/
        public IntBasis NUMCTADEB { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  DIGCTADEB                        PIC S9(4)     COMP.*/
        public IntBasis DIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VLPRMTOT                         PIC S9(13)V99 COMP-3.*/
        public DoubleBasis VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  SITUACAO                         PIC X(1).*/
        public StringBasis SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  V0PROP-SITUACAO                  PIC X(1).*/
        public StringBasis V0PROP_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  V0PARC-SITUACAO                  PIC X(1).*/
        public StringBasis V0PARC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  DTVENCTO                         PIC X(10).*/
        public StringBasis DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  NSAS                             PIC S9(4)     COMP.*/
        public IntBasis NSAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  NSL                              PIC S9(9)     COMP.*/
        public IntBasis NSL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01  FITSAS-NSL                       PIC S9(9)     COMP.*/
        public IntBasis FITSAS_NSL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01  FITSAS-REG                       PIC S9(9)     COMP.*/
        public IntBasis FITSAS_REG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01  FITSAS-VALOR                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis FITSAS_VALOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  SQL-NOT-NULL                     PIC S9(4) COMP VALUE +1.*/
        public IntBasis SQL_NOT_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"), +1);
        /*"01  SQL-MAYBE-NULL                   PIC S9(4)     COMP.*/
        public IntBasis SQL_MAYBE_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  SQL-MAYBE-NULL1                  PIC S9(4)     COMP.*/
        public IntBasis SQL_MAYBE_NULL1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  SQL-MAYBE-NULL2                  PIC S9(4)     COMP.*/
        public IntBasis SQL_MAYBE_NULL2 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  WORK-AREA.*/
        public VF0340B_WORK_AREA WORK_AREA { get; set; } = new VF0340B_WORK_AREA();
        public class VF0340B_WORK_AREA : VarBasis
        {
            /*"    05      DATA-SQL.*/
            public VF0340B_DATA_SQL DATA_SQL { get; set; } = new VF0340B_DATA_SQL();
            public class VF0340B_DATA_SQL : VarBasis
            {
                /*"      10    ANO                      PIC  9(004).*/
                public IntBasis ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10    T1                       PIC  X(001).*/
                public StringBasis T1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10    MES                      PIC  9(002).*/
                public IntBasis MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    T2                       PIC  X(001).*/
                public StringBasis T2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10    DIA                      PIC  9(002).*/
                public IntBasis DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05      DATA-INVERTIDA           PIC  9(008).*/
            }
            public IntBasis DATA_INVERTIDA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05      DATA-AAMMDD REDEFINES DATA-INVERTIDA.*/
            private _REDEF_VF0340B_DATA_AAMMDD _data_aammdd { get; set; }
            public _REDEF_VF0340B_DATA_AAMMDD DATA_AAMMDD
            {
                get { _data_aammdd = new _REDEF_VF0340B_DATA_AAMMDD(); _.Move(DATA_INVERTIDA, _data_aammdd); VarBasis.RedefinePassValue(DATA_INVERTIDA, _data_aammdd, DATA_INVERTIDA); _data_aammdd.ValueChanged += () => { _.Move(_data_aammdd, DATA_INVERTIDA); }; return _data_aammdd; }
                set { VarBasis.RedefinePassValue(value, _data_aammdd, DATA_INVERTIDA); }
            }  //Redefines
            public class _REDEF_VF0340B_DATA_AAMMDD : VarBasis
            {
                /*"      10    ANO                      PIC  9(004).*/
                public IntBasis ANO_0 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10    MES                      PIC  9(002).*/
                public IntBasis MES_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    DIA                      PIC  9(002).*/
                public IntBasis DIA_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05 W04DTSQL.*/

                public _REDEF_VF0340B_DATA_AAMMDD()
                {
                    ANO_0.ValueChanged += OnValueChanged;
                    MES_0.ValueChanged += OnValueChanged;
                    DIA_0.ValueChanged += OnValueChanged;
                }

            }
            public VF0340B_W04DTSQL W04DTSQL { get; set; } = new VF0340B_W04DTSQL();
            public class VF0340B_W04DTSQL : VarBasis
            {
                /*"       10  W04AASQL                  PIC 9(004).*/
                public IntBasis W04AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10  W04T1SQL                  PIC X(001).*/
                public StringBasis W04T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  W04MMSQL                  PIC 9(002).*/
                public IntBasis W04MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10  W04T2SQL                  PIC X(001).*/
                public StringBasis W04T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  W04DDSQL                  PIC 9(002).*/
                public IntBasis W04DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05 PARM-PROSOMU1.*/
            }
            public VF0340B_PARM_PROSOMU1 PARM_PROSOMU1 { get; set; } = new VF0340B_PARM_PROSOMU1();
            public class VF0340B_PARM_PROSOMU1 : VarBasis
            {
                /*"      10 SU1-DATA1.*/
                public VF0340B_SU1_DATA1 SU1_DATA1 { get; set; } = new VF0340B_SU1_DATA1();
                public class VF0340B_SU1_DATA1 : VarBasis
                {
                    /*"        15 SU1-DD1                   PIC 99.*/
                    public IntBasis SU1_DD1 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"        15 SU1-MM1                   PIC 99.*/
                    public IntBasis SU1_MM1 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"        15 SU1-AA1                   PIC 9999.*/
                    public IntBasis SU1_AA1 { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
                    /*"      10 SU1-NRDIAS                  PIC S9(5) COMP-3.*/
                }
                public IntBasis SU1_NRDIAS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(5)"));
                /*"      10 SU1-DATA2.*/
                public VF0340B_SU1_DATA2 SU1_DATA2 { get; set; } = new VF0340B_SU1_DATA2();
                public class VF0340B_SU1_DATA2 : VarBasis
                {
                    /*"        15 SU1-DD2                   PIC 99.*/
                    public IntBasis SU1_DD2 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"        15 SU1-MM2                   PIC 99.*/
                    public IntBasis SU1_MM2 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"        15 SU1-AA2                   PIC 9999.*/
                    public IntBasis SU1_AA2 { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
                    /*"    05 AC-REGISTROS                  PIC  9(009) VALUE 1.*/
                }
            }
            public IntBasis AC_REGISTROS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"), 1);
            /*"    05 AC-VALOR                      PIC S9(013)V99 VALUE +0.*/
            public DoubleBasis AC_VALOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 WS-AGENCIA-ANT                PIC S9(004) COMP.*/
            public IntBasis WS_AGENCIA_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05 WS-NSL                        PIC  9(008) VALUE 0.*/
            public IntBasis WS_NSL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05 WS-EOF                        PIC  9(001) VALUE 0.*/
            public IntBasis WS_EOF { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05 WS-DISPLAY-QUANT              PIC  ZZZ.ZZZ.ZZ9.*/
            public IntBasis WS_DISPLAY_QUANT { get; set; } = new IntBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9."));
            /*"    05 WS-DISPLAY-VALOR              PIC  ZZZ.ZZZ.ZZ9,99.*/
            public DoubleBasis WS_DISPLAY_VALOR { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99."), 2);
            /*"    05 WS-DISPLAY-NSA                PIC  9(05).*/
            public IntBasis WS_DISPLAY_NSA { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
            /*"    05 WS-PRM-TOT                    PIC S9(13)V99 COMP-3.*/
            public DoubleBasis WS_PRM_TOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 WS-PRM-DIF                    PIC S9(13)V99 COMP-3.*/
            public DoubleBasis WS_PRM_DIF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05      WABEND.*/
            public VF0340B_WABEND WABEND { get; set; } = new VF0340B_WABEND();
            public class VF0340B_WABEND : VarBasis
            {
                /*"      10    FILLER                   PIC  X(010) VALUE            'VF0340B  '.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VF0340B  ");
                /*"      10    FILLER                   PIC  X(028) VALUE            ' *** ERRO  EXEC SQL ***'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL ***");
                /*"      10    FILLER                   PIC  X(014) VALUE            '    SQLCODE = '.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"      10    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD1 = '.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"      10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"      10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05      LOCALIZA-ABEND-1.*/
            }
            public VF0340B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new VF0340B_LOCALIZA_ABEND_1();
            public class VF0340B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05      LOCALIZA-ABEND-2.*/
            }
            public VF0340B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new VF0340B_LOCALIZA_ABEND_2();
            public class VF0340B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"01  MOV-HEADER.*/
            }
        }
        public VF0340B_MOV_HEADER MOV_HEADER { get; set; } = new VF0340B_MOV_HEADER();
        public class VF0340B_MOV_HEADER : VarBasis
        {
            /*"    05 MA-COD-REG         PIC X(001) VALUE 'A'.*/
            public StringBasis MA_COD_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"A");
            /*"    05 MA-COD-REMESSA     PIC X(001) VALUE '1'.*/
            public StringBasis MA_COD_REMESSA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
            /*"    05 MA-COD-CONVENIO    PIC X(020) VALUE '6131'.*/
            public StringBasis MA_COD_CONVENIO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"6131");
            /*"    05 MA-NOMF-EMPRESA    PIC X(020) VALUE 'SASSE'.*/
            public StringBasis MA_NOMF_EMPRESA { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"SASSE");
            /*"    05 MA-COD-BANCO       PIC X(003) VALUE '104'.*/
            public StringBasis MA_COD_BANCO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"104");
            /*"    05 MA-NOMF-BANCO      PIC X(020) VALUE 'CEF'.*/
            public StringBasis MA_NOMF_BANCO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"CEF");
            /*"    05 MA-DATA-GERACAO    PIC 9(008).*/
            public IntBasis MA_DATA_GERACAO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05 MA-NSA             PIC 9(006).*/
            public IntBasis MA_NSA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05 MA-VERSAO-LAYOUT   PIC 9(002).*/
            public IntBasis MA_VERSAO_LAYOUT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05 MA-SERVICO         PIC X(017) VALUE 'DEB SEG FED PLUS '.*/
            public StringBasis MA_SERVICO { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"DEB SEG FED PLUS ");
            /*"    05 MA-RESERVADO       PIC X(052) VALUE SPACES.*/
            public StringBasis MA_RESERVADO { get; set; } = new StringBasis(new PIC("X", "52", "X(052)"), @"");
            /*"01  MOV-LANCAMENTO.*/
        }
        public VF0340B_MOV_LANCAMENTO MOV_LANCAMENTO { get; set; } = new VF0340B_MOV_LANCAMENTO();
        public class VF0340B_MOV_LANCAMENTO : VarBasis
        {
            /*"    05 MF-COD-REG           PIC X(001) VALUE 'E'.*/
            public StringBasis MF_COD_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"E");
            /*"    05 MF-IDENT-CLI-CERTIF  PIC 9(15) VALUE ZEROS.*/
            public IntBasis MF_IDENT_CLI_CERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(15)"));
            /*"    05 MF-IDENT-CLI-NSAS    PIC 9(05) VALUE ZEROS.*/
            public IntBasis MF_IDENT_CLI_NSAS { get; set; } = new IntBasis(new PIC("9", "5", "9(05)"));
            /*"    05 FILLER               PIC X(05) VALUE SPACES.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
            /*"    05 MF-AGENCIA           PIC 9(004).*/
            public IntBasis MF_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05 MF-IDENT-CLI-BANCO.*/
            public VF0340B_MF_IDENT_CLI_BANCO MF_IDENT_CLI_BANCO { get; set; } = new VF0340B_MF_IDENT_CLI_BANCO();
            public class VF0340B_MF_IDENT_CLI_BANCO : VarBasis
            {
                /*"       10 MF-OPR-CTA-CORR   PIC 9(004).*/
                public IntBasis MF_OPR_CTA_CORR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10 MF-NUM-CTA-CORR   PIC 9(012).*/
                public IntBasis MF_NUM_CTA_CORR { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"       10 MF-DAC-CTA-CORR   PIC 9(001).*/
                public IntBasis MF_DAC_CTA_CORR { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"       10 FILLER            PIC X(002) VALUE SPACES.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    05 MF-DATA-VENCIMENTO   PIC 9(008).*/
            }
            public IntBasis MF_DATA_VENCIMENTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05 MF-VALOR             PIC 9(13)V99.*/
            public DoubleBasis MF_VALOR { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99."), 2);
            /*"    05 MF-COD-MOEDA         PIC X(002) VALUE '00'.*/
            public StringBasis MF_COD_MOEDA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"00");
            /*"    05 MF-USO-EMPRESA.*/
            public VF0340B_MF_USO_EMPRESA MF_USO_EMPRESA { get; set; } = new VF0340B_MF_USO_EMPRESA();
            public class VF0340B_MF_USO_EMPRESA : VarBasis
            {
                /*"       10 MF-NSA            PIC 9(003).*/
                public IntBasis MF_NSA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       10 MF-NSL            PIC 9(008).*/
                public IntBasis MF_NSL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"       10 FILLER            PIC X(047) VALUE SPACES.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "47", "X(047)"), @"");
                /*"    05 MF-RESERVADO         PIC X(017) VALUE SPACES.*/
            }
            public StringBasis MF_RESERVADO { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"");
            /*"    05 MF-COD-MOV           PIC X(001) VALUE '0'.*/
            public StringBasis MF_COD_MOV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"0");
            /*"01  MOV-TRAILLER.*/
        }
        public VF0340B_MOV_TRAILLER MOV_TRAILLER { get; set; } = new VF0340B_MOV_TRAILLER();
        public class VF0340B_MOV_TRAILLER : VarBasis
        {
            /*"    05 MZ-COD-REG         PIC X(001) VALUE 'Z'.*/
            public StringBasis MZ_COD_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"Z");
            /*"    05 MZ-QTDE-REGISTROS  PIC 9(006).*/
            public IntBasis MZ_QTDE_REGISTROS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05 MZ-TOT-DEB-CRUZ    PIC 9(015)V99 VALUE 0.*/
            public DoubleBasis MZ_TOT_DEB_CRUZ { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99"), 2);
            /*"    05 MZ-TOT-VAL-CRUZ    PIC 9(015)V99 VALUE 0.*/
            public DoubleBasis MZ_TOT_VAL_CRUZ { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99"), 2);
            /*"    05 MZ-RESERVADO       PIC X(109) VALUE SPACES.*/
            public StringBasis MZ_RESERVADO { get; set; } = new StringBasis(new PIC("X", "109", "X(109)"), @"");
        }


        public VF0340B_DEBITO DEBITO { get; set; } = new VF0340B_DEBITO();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string MOVIMENTO_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                MOVIMENTO.SetFile(MOVIMENTO_FILE_NAME_P);

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
            /*" -257- MOVE '0001-INICIO               ' TO PARAGRAFO. */
            _.Move("0001-INICIO               ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -258- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -261- EXEC SQL WHENEVER SQLERROR GO TO 9999-ERRO END-EXEC. */

            /*" -264- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -272- MOVE 'SELECT V0SISTEMA' TO COMANDO. */
            _.Move("SELECT V0SISTEMA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -279- PERFORM M_0000_PRINCIPAL_DB_SELECT_1 */

            M_0000_PRINCIPAL_DB_SELECT_1();

            /*" -282- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -285- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -286- MOVE SIST-CURRDATE TO DATA-SQL. */
            _.Move(SIST_CURRDATE, WORK_AREA.DATA_SQL);

            /*" -287- MOVE CORR DATA-SQL TO DATA-AAMMDD. */
            _.MoveCorr(WORK_AREA.DATA_SQL, WORK_AREA.DATA_AAMMDD);

            /*" -289- MOVE DATA-INVERTIDA TO MA-DATA-GERACAO. */
            _.Move(WORK_AREA.DATA_INVERTIDA, MOV_HEADER.MA_DATA_GERACAO);

            /*" -297- DISPLAY '*** VF0340B *** DATA DE GERACAO DA FITA: ' DATA-SQL. */
            _.Display($"*** VF0340B *** DATA DE GERACAO DA FITA: {WORK_AREA.DATA_SQL}");

            /*" -299- MOVE 'SELECT V0CONVSUCOV' TO COMANDO. */
            _.Move("SELECT V0CONVSUCOV", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -308- PERFORM M_0000_PRINCIPAL_DB_SELECT_2 */

            M_0000_PRINCIPAL_DB_SELECT_2();

            /*" -311- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -313- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -314- ADD 1 TO PARM-NSA. */
            PARM_NSA.Value = PARM_NSA + 1;

            /*" -315- MOVE PARM-NSA TO MA-NSA. */
            _.Move(PARM_NSA, MOV_HEADER.MA_NSA);

            /*" -316- MOVE PARM-NSA TO MF-NSA. */
            _.Move(PARM_NSA, MOV_LANCAMENTO.MF_USO_EMPRESA.MF_NSA);

            /*" -321- MOVE PARM-VERSAO TO MA-VERSAO-LAYOUT. */
            _.Move(PARM_VERSAO, MOV_HEADER.MA_VERSAO_LAYOUT);

            /*" -322- MOVE SIST-CURRDATE TO W04DTSQL. */
            _.Move(SIST_CURRDATE, WORK_AREA.W04DTSQL);

            /*" -323- MOVE W04DDSQL TO SU1-DD1. */
            _.Move(WORK_AREA.W04DTSQL.W04DDSQL, WORK_AREA.PARM_PROSOMU1.SU1_DATA1.SU1_DD1);

            /*" -324- MOVE W04MMSQL TO SU1-MM1. */
            _.Move(WORK_AREA.W04DTSQL.W04MMSQL, WORK_AREA.PARM_PROSOMU1.SU1_DATA1.SU1_MM1);

            /*" -325- MOVE W04AASQL TO SU1-AA1. */
            _.Move(WORK_AREA.W04DTSQL.W04AASQL, WORK_AREA.PARM_PROSOMU1.SU1_DATA1.SU1_AA1);

            /*" -326- MOVE ZEROES TO SU1-DATA2. */
            _.Move(0, WORK_AREA.PARM_PROSOMU1.SU1_DATA2);

            /*" -327- PERFORM 0010-SOMA-DIAS THRU 0010-FIM 6 TIMES. */

            M_0010_SOMA_DIAS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0010_FIM*/


            /*" -328- MOVE SU1-DD2 TO W04DDSQL. */
            _.Move(WORK_AREA.PARM_PROSOMU1.SU1_DATA2.SU1_DD2, WORK_AREA.W04DTSQL.W04DDSQL);

            /*" -329- MOVE SU1-MM2 TO W04MMSQL. */
            _.Move(WORK_AREA.PARM_PROSOMU1.SU1_DATA2.SU1_MM2, WORK_AREA.W04DTSQL.W04MMSQL);

            /*" -331- MOVE SU1-AA2 TO W04AASQL. */
            _.Move(WORK_AREA.PARM_PROSOMU1.SU1_DATA2.SU1_AA2, WORK_AREA.W04DTSQL.W04AASQL);

            /*" -336- MOVE W04DTSQL TO SIST-DTMINDEB. */
            _.Move(WORK_AREA.W04DTSQL, SIST_DTMINDEB);

            /*" -337- MOVE SIST-CURRDATE TO W04DTSQL. */
            _.Move(SIST_CURRDATE, WORK_AREA.W04DTSQL);

            /*" -338- MOVE W04DDSQL TO SU1-DD1. */
            _.Move(WORK_AREA.W04DTSQL.W04DDSQL, WORK_AREA.PARM_PROSOMU1.SU1_DATA1.SU1_DD1);

            /*" -339- MOVE W04MMSQL TO SU1-MM1. */
            _.Move(WORK_AREA.W04DTSQL.W04MMSQL, WORK_AREA.PARM_PROSOMU1.SU1_DATA1.SU1_MM1);

            /*" -340- MOVE W04AASQL TO SU1-AA1. */
            _.Move(WORK_AREA.W04DTSQL.W04AASQL, WORK_AREA.PARM_PROSOMU1.SU1_DATA1.SU1_AA1);

            /*" -341- MOVE ZEROES TO SU1-DATA2. */
            _.Move(0, WORK_AREA.PARM_PROSOMU1.SU1_DATA2);

            /*" -342- PERFORM 0010-SOMA-DIAS THRU 0010-FIM 6 TIMES. */

            M_0010_SOMA_DIAS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0010_FIM*/


            /*" -343- MOVE SU1-DD2 TO W04DDSQL. */
            _.Move(WORK_AREA.PARM_PROSOMU1.SU1_DATA2.SU1_DD2, WORK_AREA.W04DTSQL.W04DDSQL);

            /*" -344- MOVE SU1-MM2 TO W04MMSQL. */
            _.Move(WORK_AREA.PARM_PROSOMU1.SU1_DATA2.SU1_MM2, WORK_AREA.W04DTSQL.W04MMSQL);

            /*" -346- MOVE SU1-AA2 TO W04AASQL. */
            _.Move(WORK_AREA.PARM_PROSOMU1.SU1_DATA2.SU1_AA2, WORK_AREA.W04DTSQL.W04AASQL);

            /*" -348- MOVE W04DTSQL TO SIST-DTMAXDEB. */
            _.Move(WORK_AREA.W04DTSQL, SIST_DTMAXDEB);

            /*" -349- MOVE SIST-DTMAXDEB TO DATA-SQL. */
            _.Move(SIST_DTMAXDEB, WORK_AREA.DATA_SQL);

            /*" -350- MOVE CORR DATA-SQL TO DATA-AAMMDD. */
            _.MoveCorr(WORK_AREA.DATA_SQL, WORK_AREA.DATA_AAMMDD);

            /*" -351- MOVE DATA-INVERTIDA TO MF-DATA-VENCIMENTO. */
            _.Move(WORK_AREA.DATA_INVERTIDA, MOV_LANCAMENTO.MF_DATA_VENCIMENTO);

            /*" -358- DISPLAY '*** VF0340B *** DATA MAXIMA DE DEBITO EM CONTA: ' DATA-SQL. */
            _.Display($"*** VF0340B *** DATA MAXIMA DE DEBITO EM CONTA: {WORK_AREA.DATA_SQL}");

            /*" -377- PERFORM M_0000_PRINCIPAL_DB_DECLARE_1 */

            M_0000_PRINCIPAL_DB_DECLARE_1();

            /*" -380- MOVE 'OPEN DEBITO    ' TO COMANDO. */
            _.Move("OPEN DEBITO    ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -380- PERFORM M_0000_PRINCIPAL_DB_OPEN_1 */

            M_0000_PRINCIPAL_DB_OPEN_1();

            /*" -384- PERFORM 1010-FETCH THRU 1010-FIM. */

            M_1010_FETCH(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1010_FIM*/


            /*" -385- IF WS-EOF = 1 */

            if (WORK_AREA.WS_EOF == 1)
            {

                /*" -386- DISPLAY '*** VF0340B *** CONVENIO 6131' */
                _.Display($"*** VF0340B *** CONVENIO 6131");

                /*" -387- DISPLAY '*** VF0340B *** NAO HA DEBITOS A PROCESSAR' */
                _.Display($"*** VF0340B *** NAO HA DEBITOS A PROCESSAR");

                /*" -388- DISPLAY '*** VF0340B *** TERMINO NORMAL' */
                _.Display($"*** VF0340B *** TERMINO NORMAL");

                /*" -388- EXEC SQL COMMIT WORK END-EXEC */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -390- MOVE 0 TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -392- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -393- OPEN OUTPUT MOVIMENTO. */
            MOVIMENTO.Open(MOVIMENTO_RECORD);

            /*" -395- WRITE MOVIMENTO-RECORD FROM MOV-HEADER. */
            _.Move(MOV_HEADER.GetMoveValues(), MOVIMENTO_RECORD);

            MOVIMENTO.Write(MOVIMENTO_RECORD.GetMoveValues().ToString());

            /*" -402- PERFORM M-1000-PROCESSA-DEBITO THRU 1000-FIM UNTIL WS-EOF = 1. */

            while (!(WORK_AREA.WS_EOF == 1))
            {

                M_1000_PROCESSA_DEBITO(true);

                M_1000_NEXT(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1000_FIM*/

            }

            /*" -403- MOVE '0075-SOLICITA-RELAT' TO PARAGRAFO. */
            _.Move("0075-SOLICITA-RELAT", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -405- MOVE 'INSERT V0RELATORIOS' TO COMANDO. */
            _.Move("INSERT V0RELATORIOS", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -448- PERFORM M_0000_PRINCIPAL_DB_INSERT_1 */

            M_0000_PRINCIPAL_DB_INSERT_1();

            /*" -451- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -452- DISPLAY 'VF0340B - PROBLEMAS NA INCLUSAO VA0473B' */
                _.Display($"VF0340B - PROBLEMAS NA INCLUSAO VA0473B");

                /*" -458- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -460- PERFORM 9000-FINALIZA THRU 9000-FIM. */

            M_9000_FINALIZA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9000_FIM*/


            /*" -460- PERFORM M_0000_PRINCIPAL_DB_CLOSE_1 */

            M_0000_PRINCIPAL_DB_CLOSE_1();

            /*" -464- CLOSE MOVIMENTO. */
            MOVIMENTO.Close();

            /*" -464- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -468- DISPLAY '*** VF0340B *** TERMINO NORMAL' . */
            _.Display($"*** VF0340B *** TERMINO NORMAL");

            /*" -469- MOVE 0 TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -469- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SELECT-1 */
        public void M_0000_PRINCIPAL_DB_SELECT_1()
        {
            /*" -279- EXEC SQL SELECT CURRENT DATE, CURRENT DATE + 1 DAY INTO :SIST-CURRDATE, :SIST-DTMINDEB FROM SEGUROS.V0SISTEMA WHERE IDSISTEM= 'VF' END-EXEC. */

            var m_0000_PRINCIPAL_DB_SELECT_1_Query1 = new M_0000_PRINCIPAL_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_0000_PRINCIPAL_DB_SELECT_1_Query1.Execute(m_0000_PRINCIPAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SIST_CURRDATE, SIST_CURRDATE);
                _.Move(executed_1.SIST_DTMINDEB, SIST_DTMINDEB);
            }


        }

        [StopWatch]
        /*" M-0010-SOMA-DIAS */
        private void M_0010_SOMA_DIAS(bool isPerform = false)
        {
            /*" -478- MOVE +1 TO SU1-NRDIAS. */
            _.Move(+1, WORK_AREA.PARM_PROSOMU1.SU1_NRDIAS);

            /*" -479- CALL 'PROSOCU1' USING PARM-PROSOMU1. */
            _.Call("PROSOCU1", WORK_AREA.PARM_PROSOMU1);

            /*" -479- MOVE SU1-DATA2 TO SU1-DATA1. */
            _.Move(WORK_AREA.PARM_PROSOMU1.SU1_DATA2, WORK_AREA.PARM_PROSOMU1.SU1_DATA1);

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-DECLARE-1 */
        public void M_0000_PRINCIPAL_DB_DECLARE_1()
        {
            /*" -377- EXEC SQL DECLARE DEBITO CURSOR FOR SELECT NRCERTIF, NRPARCEL, AGECTADEB, OPRCTADEB, NUMCTADEB, DIGCTADEB, VLPRMTOT, SITUACAO, DTVENCTO, NSAS, NSL FROM SEGUROS.V0HISTCONTAVA WHERE CODCONV = 6131 AND SITUACAO = '0' AND TIPLANC = '1' AND DTVENCTO <= :SIST-DTMAXDEB FOR UPDATE OF SITUACAO, DTVENCTO, NSAS, NSL END-EXEC. */
            DEBITO = new VF0340B_DEBITO(true);
            string GetQuery_DEBITO()
            {
                var query = @$"SELECT NRCERTIF
							, 
							NRPARCEL
							, 
							AGECTADEB
							, 
							OPRCTADEB
							, 
							NUMCTADEB
							, 
							DIGCTADEB
							, 
							VLPRMTOT
							, 
							SITUACAO
							, 
							DTVENCTO
							, 
							NSAS
							, 
							NSL 
							FROM SEGUROS.V0HISTCONTAVA 
							WHERE CODCONV = 6131 
							AND SITUACAO = '0' 
							AND TIPLANC = '1' 
							AND DTVENCTO <= '{SIST_DTMAXDEB}'";

                return query;
            }
            DEBITO.GetQueryEvent += GetQuery_DEBITO;

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-OPEN-1 */
        public void M_0000_PRINCIPAL_DB_OPEN_1()
        {
            /*" -380- EXEC SQL OPEN DEBITO END-EXEC. */

            DEBITO.Open();

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-INSERT-1 */
        public void M_0000_PRINCIPAL_DB_INSERT_1()
        {
            /*" -448- EXEC SQL INSERT INTO SEGUROS.V0RELATORIOS VALUES ( 'VF0340B' , :SIST-CURRDATE, 'VA' , 'VA0473B' , :PARM-NSA, 0, :SIST-CURRDATE, :SIST-CURRDATE, :SIST-CURRDATE, 0, 0, 0, 0, 0, 0, 0, 0, 0109700000028, 0, 0, 0, 0, 0, 0, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '0' , ' ' , ' ' , NULL, 0, 0, CURRENT TIMESTAMP) END-EXEC. */

            var m_0000_PRINCIPAL_DB_INSERT_1_Insert1 = new M_0000_PRINCIPAL_DB_INSERT_1_Insert1()
            {
                SIST_CURRDATE = SIST_CURRDATE.ToString(),
                PARM_NSA = PARM_NSA.ToString(),
            };

            M_0000_PRINCIPAL_DB_INSERT_1_Insert1.Execute(m_0000_PRINCIPAL_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-CLOSE-1 */
        public void M_0000_PRINCIPAL_DB_CLOSE_1()
        {
            /*" -460- EXEC SQL CLOSE DEBITO END-EXEC. */

            DEBITO.Close();

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SELECT-2 */
        public void M_0000_PRINCIPAL_DB_SELECT_2()
        {
            /*" -308- EXEC SQL SELECT COD_CONVENIO, NSA_CONVENIO, VERSAO_LAYOUT INTO :PARM-CODCONV, :PARM-NSA, :PARM-VERSAO FROM SEGUROS.V0CONVSUCOV WHERE COD_CONVENIO = 6131 END-EXEC. */

            var m_0000_PRINCIPAL_DB_SELECT_2_Query1 = new M_0000_PRINCIPAL_DB_SELECT_2_Query1()
            {
            };

            var executed_1 = M_0000_PRINCIPAL_DB_SELECT_2_Query1.Execute(m_0000_PRINCIPAL_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARM_CODCONV, PARM_CODCONV);
                _.Move(executed_1.PARM_NSA, PARM_NSA);
                _.Move(executed_1.PARM_VERSAO, PARM_VERSAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0010_FIM*/

        [StopWatch]
        /*" M-1000-PROCESSA-DEBITO */
        private void M_1000_PROCESSA_DEBITO(bool isPerform = false)
        {
            /*" -489- MOVE '1000-PROCESSA-DEB' TO PARAGRAFO. */
            _.Move("1000-PROCESSA-DEB", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -491- MOVE 'SELECT V0PROPOSTAVA' TO COMANDO. */
            _.Move("SELECT V0PROPOSTAVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -496- PERFORM M_1000_PROCESSA_DEBITO_DB_SELECT_1 */

            M_1000_PROCESSA_DEBITO_DB_SELECT_1();

            /*" -498- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -500- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -502- IF V0PROP-SITUACAO EQUAL '3' OR '6' OR '8' NEXT SENTENCE */

            if (V0PROP_SITUACAO.In("3", "6", "8"))
            {

                /*" -503- ELSE */
            }
            else
            {


                /*" -505- GO TO 1000-NEXT. */

                M_1000_NEXT(); //GOTO
                return;
            }


            /*" -507- MOVE 'SELECT V0PARCELVA  ' TO COMANDO. */
            _.Move("SELECT V0PARCELVA  ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -513- PERFORM M_1000_PROCESSA_DEBITO_DB_SELECT_2 */

            M_1000_PROCESSA_DEBITO_DB_SELECT_2();

            /*" -516- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -518- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -520- IF V0PARC-SITUACAO EQUAL ' ' OR '0' NEXT SENTENCE */

            if (V0PARC_SITUACAO.In(" ", "0"))
            {

                /*" -521- ELSE */
            }
            else
            {


                /*" -522- MOVE 'UPDATE 1 V0HISTCONTAVA  ' TO COMANDO */
                _.Move("UPDATE 1 V0HISTCONTAVA  ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

                /*" -526- PERFORM M_1000_PROCESSA_DEBITO_DB_UPDATE_1 */

                M_1000_PROCESSA_DEBITO_DB_UPDATE_1();

                /*" -528- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -529- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -530- ELSE */
                }
                else
                {


                    /*" -532- GO TO 1000-NEXT. */

                    M_1000_NEXT(); //GOTO
                    return;
                }

            }


            /*" -533- ADD 1 TO WS-NSL. */
            WORK_AREA.WS_NSL.Value = WORK_AREA.WS_NSL + 1;

            /*" -535- MOVE WS-NSL TO NSL FITSAS-NSL */
            _.Move(WORK_AREA.WS_NSL, NSL, FITSAS_NSL);

            /*" -537- MOVE WS-NSL TO MF-NSL. */
            _.Move(WORK_AREA.WS_NSL, MOV_LANCAMENTO.MF_USO_EMPRESA.MF_NSL);

            /*" -538- MOVE AGECTADEB TO MF-AGENCIA. */
            _.Move(AGECTADEB, MOV_LANCAMENTO.MF_AGENCIA);

            /*" -539- MOVE OPRCTADEB TO MF-OPR-CTA-CORR. */
            _.Move(OPRCTADEB, MOV_LANCAMENTO.MF_IDENT_CLI_BANCO.MF_OPR_CTA_CORR);

            /*" -540- MOVE NUMCTADEB TO MF-NUM-CTA-CORR. */
            _.Move(NUMCTADEB, MOV_LANCAMENTO.MF_IDENT_CLI_BANCO.MF_NUM_CTA_CORR);

            /*" -541- MOVE DIGCTADEB TO MF-DAC-CTA-CORR. */
            _.Move(DIGCTADEB, MOV_LANCAMENTO.MF_IDENT_CLI_BANCO.MF_DAC_CTA_CORR);

            /*" -543- MOVE VLPRMTOT TO MF-VALOR. */
            _.Move(VLPRMTOT, MOV_LANCAMENTO.MF_VALOR);

            /*" -544- IF DTVENCTO LESS SIST-DTMINDEB */

            if (DTVENCTO < SIST_DTMINDEB)
            {

                /*" -546- MOVE SIST-DTMINDEB TO DTVENCTO. */
                _.Move(SIST_DTMINDEB, DTVENCTO);
            }


            /*" -547- MOVE DTVENCTO TO DATA-SQL. */
            _.Move(DTVENCTO, WORK_AREA.DATA_SQL);

            /*" -548- MOVE CORR DATA-SQL TO DATA-AAMMDD. */
            _.MoveCorr(WORK_AREA.DATA_SQL, WORK_AREA.DATA_AAMMDD);

            /*" -549- MOVE DATA-INVERTIDA TO MF-DATA-VENCIMENTO. */
            _.Move(WORK_AREA.DATA_INVERTIDA, MOV_LANCAMENTO.MF_DATA_VENCIMENTO);

            /*" -550- MOVE NRCERTIF TO MF-IDENT-CLI-CERTIF. */
            _.Move(NRCERTIF, MOV_LANCAMENTO.MF_IDENT_CLI_CERTIF);

            /*" -552- MOVE PARM-NSA TO MF-IDENT-CLI-NSAS. */
            _.Move(PARM_NSA, MOV_LANCAMENTO.MF_IDENT_CLI_NSAS);

            /*" -554- WRITE MOVIMENTO-RECORD FROM MOV-LANCAMENTO. */
            _.Move(MOV_LANCAMENTO.GetMoveValues(), MOVIMENTO_RECORD);

            MOVIMENTO.Write(MOVIMENTO_RECORD.GetMoveValues().ToString());

            /*" -555- ADD 1 TO AC-REGISTROS. */
            WORK_AREA.AC_REGISTROS.Value = WORK_AREA.AC_REGISTROS + 1;

            /*" -557- ADD VLPRMTOT TO AC-VALOR. */
            WORK_AREA.AC_VALOR.Value = WORK_AREA.AC_VALOR + VLPRMTOT;

            /*" -559- MOVE 'UPDATE V0HISTCONTAVA' TO COMANDO. */
            _.Move("UPDATE V0HISTCONTAVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -566- PERFORM M_1000_PROCESSA_DEBITO_DB_UPDATE_2 */

            M_1000_PROCESSA_DEBITO_DB_UPDATE_2();

            /*" -569- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -569- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-1000-PROCESSA-DEBITO-DB-SELECT-1 */
        public void M_1000_PROCESSA_DEBITO_DB_SELECT_1()
        {
            /*" -496- EXEC SQL SELECT SITUACAO INTO :V0PROP-SITUACAO FROM SEGUROS.V0PROPOSTAVA WHERE NRCERTIF = :NRCERTIF END-EXEC. */

            var m_1000_PROCESSA_DEBITO_DB_SELECT_1_Query1 = new M_1000_PROCESSA_DEBITO_DB_SELECT_1_Query1()
            {
                NRCERTIF = NRCERTIF.ToString(),
            };

            var executed_1 = M_1000_PROCESSA_DEBITO_DB_SELECT_1_Query1.Execute(m_1000_PROCESSA_DEBITO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PROP_SITUACAO, V0PROP_SITUACAO);
            }


        }

        [StopWatch]
        /*" M-1000-NEXT */
        private void M_1000_NEXT(bool isPerform = false)
        {
            /*" -573- PERFORM 1010-FETCH THRU 1010-FIM. */

            M_1010_FETCH(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1010_FIM*/


        }

        [StopWatch]
        /*" M-1000-PROCESSA-DEBITO-DB-UPDATE-1 */
        public void M_1000_PROCESSA_DEBITO_DB_UPDATE_1()
        {
            /*" -526- EXEC SQL UPDATE SEGUROS.V0HISTCONTAVA SET SITUACAO = '2' WHERE CURRENT OF DEBITO END-EXEC */

            var m_1000_PROCESSA_DEBITO_DB_UPDATE_1_Update1 = new M_1000_PROCESSA_DEBITO_DB_UPDATE_1_Update1(DEBITO)
            {
                SIST_DTMAXDEB = SIST_DTMAXDEB.ToString(),
            };

            M_1000_PROCESSA_DEBITO_DB_UPDATE_1_Update1.Execute(m_1000_PROCESSA_DEBITO_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-1000-PROCESSA-DEBITO-DB-SELECT-2 */
        public void M_1000_PROCESSA_DEBITO_DB_SELECT_2()
        {
            /*" -513- EXEC SQL SELECT SITUACAO INTO :V0PARC-SITUACAO FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :NRCERTIF AND NRPARCEL = :NRPARCEL END-EXEC. */

            var m_1000_PROCESSA_DEBITO_DB_SELECT_2_Query1 = new M_1000_PROCESSA_DEBITO_DB_SELECT_2_Query1()
            {
                NRCERTIF = NRCERTIF.ToString(),
                NRPARCEL = NRPARCEL.ToString(),
            };

            var executed_1 = M_1000_PROCESSA_DEBITO_DB_SELECT_2_Query1.Execute(m_1000_PROCESSA_DEBITO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PARC_SITUACAO, V0PARC_SITUACAO);
            }


        }

        [StopWatch]
        /*" M-1000-PROCESSA-DEBITO-DB-UPDATE-2 */
        public void M_1000_PROCESSA_DEBITO_DB_UPDATE_2()
        {
            /*" -566- EXEC SQL UPDATE SEGUROS.V0HISTCONTAVA SET SITUACAO = '3' , DTVENCTO = :DTVENCTO, NSAS = :PARM-NSA:SQL-NOT-NULL, NSL = :NSL:SQL-NOT-NULL WHERE CURRENT OF DEBITO END-EXEC. */

            var m_1000_PROCESSA_DEBITO_DB_UPDATE_2_Update1 = new M_1000_PROCESSA_DEBITO_DB_UPDATE_2_Update1(DEBITO)
            {
                PARM_NSA = PARM_NSA.ToString(),
                SQL_NOT_NULL = SQL_NOT_NULL.ToString(),
                NSL = NSL.ToString(),
                DTVENCTO = DTVENCTO.ToString(),
                SIST_DTMAXDEB = SIST_DTMAXDEB.ToString(),
            };

            M_1000_PROCESSA_DEBITO_DB_UPDATE_2_Update1.Execute(m_1000_PROCESSA_DEBITO_DB_UPDATE_2_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1000_FIM*/

        [StopWatch]
        /*" M-1010-FETCH */
        private void M_1010_FETCH(bool isPerform = false)
        {
            /*" -584- MOVE '1010-FETCH' TO PARAGRAFO. */
            _.Move("1010-FETCH", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -586- MOVE 'FETCH DEBITO                     ' TO COMANDO. */
            _.Move("FETCH DEBITO                     ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -599- PERFORM M_1010_FETCH_DB_FETCH_1 */

            M_1010_FETCH_DB_FETCH_1();

            /*" -602- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -602- MOVE 1 TO WS-EOF. */
                _.Move(1, WORK_AREA.WS_EOF);
            }


        }

        [StopWatch]
        /*" M-1010-FETCH-DB-FETCH-1 */
        public void M_1010_FETCH_DB_FETCH_1()
        {
            /*" -599- EXEC SQL FETCH DEBITO INTO :NRCERTIF, :NRPARCEL, :AGECTADEB, :OPRCTADEB, :NUMCTADEB, :DIGCTADEB, :VLPRMTOT, :SITUACAO, :DTVENCTO, :NSAS:SQL-MAYBE-NULL1, :NSL:SQL-MAYBE-NULL2 END-EXEC. */

            if (DEBITO.Fetch())
            {
                _.Move(DEBITO.NRCERTIF, NRCERTIF);
                _.Move(DEBITO.NRPARCEL, NRPARCEL);
                _.Move(DEBITO.AGECTADEB, AGECTADEB);
                _.Move(DEBITO.OPRCTADEB, OPRCTADEB);
                _.Move(DEBITO.NUMCTADEB, NUMCTADEB);
                _.Move(DEBITO.DIGCTADEB, DIGCTADEB);
                _.Move(DEBITO.VLPRMTOT, VLPRMTOT);
                _.Move(DEBITO.SITUACAO, SITUACAO);
                _.Move(DEBITO.DTVENCTO, DTVENCTO);
                _.Move(DEBITO.NSAS, NSAS);
                _.Move(DEBITO.SQL_MAYBE_NULL1, SQL_MAYBE_NULL1);
                _.Move(DEBITO.NSL, NSL);
                _.Move(DEBITO.SQL_MAYBE_NULL2, SQL_MAYBE_NULL2);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1010_FIM*/

        [StopWatch]
        /*" M-9000-FINALIZA */
        private void M_9000_FINALIZA(bool isPerform = false)
        {
            /*" -612- ADD 1 TO AC-REGISTROS. */
            WORK_AREA.AC_REGISTROS.Value = WORK_AREA.AC_REGISTROS + 1;

            /*" -614- MOVE AC-REGISTROS TO MZ-QTDE-REGISTROS WS-DISPLAY-QUANT. */
            _.Move(WORK_AREA.AC_REGISTROS, MOV_TRAILLER.MZ_QTDE_REGISTROS, WORK_AREA.WS_DISPLAY_QUANT);

            /*" -616- MOVE AC-VALOR TO MZ-TOT-DEB-CRUZ WS-DISPLAY-VALOR. */
            _.Move(WORK_AREA.AC_VALOR, MOV_TRAILLER.MZ_TOT_DEB_CRUZ, WORK_AREA.WS_DISPLAY_VALOR);

            /*" -617- MOVE PARM-NSA TO WS-DISPLAY-NSA. */
            _.Move(PARM_NSA, WORK_AREA.WS_DISPLAY_NSA);

            /*" -619- WRITE MOVIMENTO-RECORD FROM MOV-TRAILLER. */
            _.Move(MOV_TRAILLER.GetMoveValues(), MOVIMENTO_RECORD);

            MOVIMENTO.Write(MOVIMENTO_RECORD.GetMoveValues().ToString());

            /*" -620- DISPLAY '*** VF0340B *** CONVENIO   6131' . */
            _.Display($"*** VF0340B *** CONVENIO   6131");

            /*" -621- DISPLAY '*** VF0340B *** NSA        ' WS-DISPLAY-NSA. */
            _.Display($"*** VF0340B *** NSA        {WORK_AREA.WS_DISPLAY_NSA}");

            /*" -622- DISPLAY '*** VF0340B *** QUANTIDADE ' WS-DISPLAY-QUANT. */
            _.Display($"*** VF0340B *** QUANTIDADE {WORK_AREA.WS_DISPLAY_QUANT}");

            /*" -624- DISPLAY '*** VF0340B *** VALOR      ' WS-DISPLAY-VALOR. */
            _.Display($"*** VF0340B *** VALOR      {WORK_AREA.WS_DISPLAY_VALOR}");

            /*" -625- MOVE '9000-FINALIZA' TO PARAGRAFO. */
            _.Move("9000-FINALIZA", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -627- MOVE 'UPDATE V0CONVSUCOV' TO COMANDO. */
            _.Move("UPDATE V0CONVSUCOV", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -631- PERFORM M_9000_FINALIZA_DB_UPDATE_1 */

            M_9000_FINALIZA_DB_UPDATE_1();

            /*" -634- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -636- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -638- MOVE 'INSERT V0FITASASSE' TO COMANDO. */
            _.Move("INSERT V0FITASASSE", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -639- MOVE AC-REGISTROS TO FITSAS-REG. */
            _.Move(WORK_AREA.AC_REGISTROS, FITSAS_REG);

            /*" -641- MOVE AC-VALOR TO FITSAS-VALOR. */
            _.Move(WORK_AREA.AC_VALOR, FITSAS_VALOR);

            /*" -661- PERFORM M_9000_FINALIZA_DB_INSERT_1 */

            M_9000_FINALIZA_DB_INSERT_1();

            /*" -664- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -664- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-9000-FINALIZA-DB-UPDATE-1 */
        public void M_9000_FINALIZA_DB_UPDATE_1()
        {
            /*" -631- EXEC SQL UPDATE SEGUROS.V0CONVSUCOV SET NSA_CONVENIO = :PARM-NSA WHERE COD_CONVENIO = 6131 END-EXEC. */

            var m_9000_FINALIZA_DB_UPDATE_1_Update1 = new M_9000_FINALIZA_DB_UPDATE_1_Update1()
            {
                PARM_NSA = PARM_NSA.ToString(),
            };

            M_9000_FINALIZA_DB_UPDATE_1_Update1.Execute(m_9000_FINALIZA_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-9000-FINALIZA-DB-INSERT-1 */
        public void M_9000_FINALIZA_DB_INSERT_1()
        {
            /*" -661- EXEC SQL INSERT INTO SEGUROS.V0FITASASSE VALUES (:PARM-CODCONV, :PARM-NSA, :SIST-CURRDATE, :SIST-DTMAXDEB, 'VF0340B' , '1' , 01, :PARM-VERSAO, :FITSAS-REG, :FITSAS-VALOR, 0, :FITSAS-NSL, 0, 0, 0, 0, 0, 0) END-EXEC. */

            var m_9000_FINALIZA_DB_INSERT_1_Insert1 = new M_9000_FINALIZA_DB_INSERT_1_Insert1()
            {
                PARM_CODCONV = PARM_CODCONV.ToString(),
                PARM_NSA = PARM_NSA.ToString(),
                SIST_CURRDATE = SIST_CURRDATE.ToString(),
                SIST_DTMAXDEB = SIST_DTMAXDEB.ToString(),
                PARM_VERSAO = PARM_VERSAO.ToString(),
                FITSAS_REG = FITSAS_REG.ToString(),
                FITSAS_VALOR = FITSAS_VALOR.ToString(),
                FITSAS_NSL = FITSAS_NSL.ToString(),
            };

            M_9000_FINALIZA_DB_INSERT_1_Insert1.Execute(m_9000_FINALIZA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9000_FIM*/

        [StopWatch]
        /*" M-9999-ERRO */
        private void M_9999_ERRO(bool isPerform = false)
        {
            /*" -675- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WORK_AREA.WABEND.WSQLCODE);

            /*" -676- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], WORK_AREA.WABEND.WSQLERRD1);

            /*" -677- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], WORK_AREA.WABEND.WSQLERRD2);

            /*" -678- DISPLAY WABEND. */
            _.Display(WORK_AREA.WABEND);

            /*" -679- DISPLAY LOCALIZA-ABEND-1. */
            _.Display(WORK_AREA.LOCALIZA_ABEND_1);

            /*" -681- DISPLAY LOCALIZA-ABEND-2. */
            _.Display(WORK_AREA.LOCALIZA_ABEND_2);

            /*" -681- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -683- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -687- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -687- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}