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
using Sias.VidaAzul.DB2.VA0344B;

namespace Code
{
    public class VA0344B
    {
        public bool IsCall { get; set; }

        public VA0344B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *  GERA FITA COM LANCAMENTOS DE ESTORNO/DEBITO EM CONTA DO SEGURO*      */
        /*"      *                 CONVENIO 6088 MULTIPREMIADO                    *      */
        /*"      *                                                                *      */
        /*"      *                          TERCIO CARVALHO        16/04/99       *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *  ALTERACAO 01 - 21/12/99 MANOEL MESSIAS (MM1221)               *      */
        /*"      *                                                                *      */
        /*"      *     OS CAMPOS NSAS E NSL DA V0HISTCONTAVA DEVEM SER OS MESMOS  *      */
        /*"      *  QUE FORAM ENVIADOS NO LANCAMENTO DO DEBITO.                   *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 02 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   AJUSTE LAYOUT ARQUIVO MOVIMENTO (MVES6088)                   *      */
        /*"      *   EM 20/07/2015 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.02         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 16/11/2014 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.01         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"1     ******************************************************************      */
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
        /*"01  V0PROP-SITUACAO                  PIC X(01).*/
        public StringBasis V0PROP_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
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
        public VA0344B_WORK_AREA WORK_AREA { get; set; } = new VA0344B_WORK_AREA();
        public class VA0344B_WORK_AREA : VarBasis
        {
            /*"    05      DATA-SQL.*/
            public VA0344B_DATA_SQL DATA_SQL { get; set; } = new VA0344B_DATA_SQL();
            public class VA0344B_DATA_SQL : VarBasis
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
            private _REDEF_VA0344B_DATA_AAMMDD _data_aammdd { get; set; }
            public _REDEF_VA0344B_DATA_AAMMDD DATA_AAMMDD
            {
                get { _data_aammdd = new _REDEF_VA0344B_DATA_AAMMDD(); _.Move(DATA_INVERTIDA, _data_aammdd); VarBasis.RedefinePassValue(DATA_INVERTIDA, _data_aammdd, DATA_INVERTIDA); _data_aammdd.ValueChanged += () => { _.Move(_data_aammdd, DATA_INVERTIDA); }; return _data_aammdd; }
                set { VarBasis.RedefinePassValue(value, _data_aammdd, DATA_INVERTIDA); }
            }  //Redefines
            public class _REDEF_VA0344B_DATA_AAMMDD : VarBasis
            {
                /*"      10    ANO                      PIC  9(004).*/
                public IntBasis ANO_0 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10    MES                      PIC  9(002).*/
                public IntBasis MES_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    DIA                      PIC  9(002).*/
                public IntBasis DIA_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05 W04DTSQL.*/

                public _REDEF_VA0344B_DATA_AAMMDD()
                {
                    ANO_0.ValueChanged += OnValueChanged;
                    MES_0.ValueChanged += OnValueChanged;
                    DIA_0.ValueChanged += OnValueChanged;
                }

            }
            public VA0344B_W04DTSQL W04DTSQL { get; set; } = new VA0344B_W04DTSQL();
            public class VA0344B_W04DTSQL : VarBasis
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
            public VA0344B_PARM_PROSOMU1 PARM_PROSOMU1 { get; set; } = new VA0344B_PARM_PROSOMU1();
            public class VA0344B_PARM_PROSOMU1 : VarBasis
            {
                /*"      10 SU1-DATA1.*/
                public VA0344B_SU1_DATA1 SU1_DATA1 { get; set; } = new VA0344B_SU1_DATA1();
                public class VA0344B_SU1_DATA1 : VarBasis
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
                public VA0344B_SU1_DATA2 SU1_DATA2 { get; set; } = new VA0344B_SU1_DATA2();
                public class VA0344B_SU1_DATA2 : VarBasis
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
            public VA0344B_WABEND WABEND { get; set; } = new VA0344B_WABEND();
            public class VA0344B_WABEND : VarBasis
            {
                /*"      10    FILLER                   PIC  X(010) VALUE            'VA0344B  '.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VA0344B  ");
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
            public VA0344B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new VA0344B_LOCALIZA_ABEND_1();
            public class VA0344B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05      LOCALIZA-ABEND-2.*/
            }
            public VA0344B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new VA0344B_LOCALIZA_ABEND_2();
            public class VA0344B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"01  MOV-HEADER.*/
            }
        }
        public VA0344B_MOV_HEADER MOV_HEADER { get; set; } = new VA0344B_MOV_HEADER();
        public class VA0344B_MOV_HEADER : VarBasis
        {
            /*"    05 MA-COD-REG         PIC X(001) VALUE 'A'.*/
            public StringBasis MA_COD_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"A");
            /*"    05 MA-COD-REMESSA     PIC X(001) VALUE '1'.*/
            public StringBasis MA_COD_REMESSA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
            /*"    05 MA-COD-CONVENIO    PIC X(020) VALUE '6088'.*/
            public StringBasis MA_COD_CONVENIO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"6088");
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
            /*"    05 MA-SERVICO         PIC X(017) VALUE 'DEB SEGURO MULTIP'.*/
            public StringBasis MA_SERVICO { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"DEB SEGURO MULTIP");
            /*"    05 MA-RESERVADO       PIC X(052) VALUE SPACES.*/
            public StringBasis MA_RESERVADO { get; set; } = new StringBasis(new PIC("X", "52", "X(052)"), @"");
            /*"01  MOV-LANCAMENTO.*/
        }
        public VA0344B_MOV_LANCAMENTO MOV_LANCAMENTO { get; set; } = new VA0344B_MOV_LANCAMENTO();
        public class VA0344B_MOV_LANCAMENTO : VarBasis
        {
            /*"    05 MF-COD-REG           PIC X(001) VALUE 'E'.*/
            public StringBasis MF_COD_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"E");
            /*"    05 MF-IDENT-CLI-EMPRESA.*/
            public VA0344B_MF_IDENT_CLI_EMPRESA MF_IDENT_CLI_EMPRESA { get; set; } = new VA0344B_MF_IDENT_CLI_EMPRESA();
            public class VA0344B_MF_IDENT_CLI_EMPRESA : VarBasis
            {
                /*"       10 MF-IDENT-CLI      PIC 9(015).*/
                public IntBasis MF_IDENT_CLI { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"       10 MF-IDENT-CLI-R    REDEFINES  MF-IDENT-CLI.*/
                private _REDEF_VA0344B_MF_IDENT_CLI_R _mf_ident_cli_r { get; set; }
                public _REDEF_VA0344B_MF_IDENT_CLI_R MF_IDENT_CLI_R
                {
                    get { _mf_ident_cli_r = new _REDEF_VA0344B_MF_IDENT_CLI_R(); _.Move(MF_IDENT_CLI, _mf_ident_cli_r); VarBasis.RedefinePassValue(MF_IDENT_CLI, _mf_ident_cli_r, MF_IDENT_CLI); _mf_ident_cli_r.ValueChanged += () => { _.Move(_mf_ident_cli_r, MF_IDENT_CLI); }; return _mf_ident_cli_r; }
                    set { VarBasis.RedefinePassValue(value, _mf_ident_cli_r, MF_IDENT_CLI); }
                }  //Redefines
                public class _REDEF_VA0344B_MF_IDENT_CLI_R : VarBasis
                {
                    /*"          15 FILLER         PIC X(015).*/
                    public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                    /*"       10 MF-NSA-PARM       PIC 9(005) VALUE ZEROS.*/

                    public _REDEF_VA0344B_MF_IDENT_CLI_R()
                    {
                        FILLER_8.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis MF_NSA_PARM { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
                /*"       10 FILLER            PIC X(005) VALUE SPACES.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"    05 MF-AGENCIA           PIC 9(004).*/
            }
            public IntBasis MF_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05 MF-IDENT-CLI-BANCO.*/
            public VA0344B_MF_IDENT_CLI_BANCO MF_IDENT_CLI_BANCO { get; set; } = new VA0344B_MF_IDENT_CLI_BANCO();
            public class VA0344B_MF_IDENT_CLI_BANCO : VarBasis
            {
                /*"       10 MF-OPR-CTA-CORR   PIC 9(004).*/
                public IntBasis MF_OPR_CTA_CORR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10 MF-NUM-CTA-CORR   PIC 9(012).*/
                public IntBasis MF_NUM_CTA_CORR { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"       10 MF-DAC-CTA-CORR   PIC 9(001).*/
                public IntBasis MF_DAC_CTA_CORR { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"       10 FILLER            PIC X(002) VALUE SPACES.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    05 MF-DATA-VENCIMENTO   PIC 9(008).*/
            }
            public IntBasis MF_DATA_VENCIMENTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05 MF-VALOR             PIC 9(13)V99.*/
            public DoubleBasis MF_VALOR { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99."), 2);
            /*"    05 MF-COD-MOEDA         PIC X(002) VALUE '00'.*/
            public StringBasis MF_COD_MOEDA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"00");
            /*"    05 MF-USO-EMPRESA.*/
            public VA0344B_MF_USO_EMPRESA MF_USO_EMPRESA { get; set; } = new VA0344B_MF_USO_EMPRESA();
            public class VA0344B_MF_USO_EMPRESA : VarBasis
            {
                /*"       10 MF-NSA            PIC 9(003).*/
                public IntBasis MF_NSA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       10 MF-NSL            PIC 9(008).*/
                public IntBasis MF_NSL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"       10 FILLER            PIC X(047) VALUE SPACES.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "47", "X(047)"), @"");
                /*"    05 MF-RESERVADO         PIC X(017) VALUE SPACES.*/
            }
            public StringBasis MF_RESERVADO { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"");
            /*"    05 MF-COD-MOV           PIC X(001) VALUE '1'.*/
            public StringBasis MF_COD_MOV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
            /*"01  MOV-TRAILLER.*/
        }
        public VA0344B_MOV_TRAILLER MOV_TRAILLER { get; set; } = new VA0344B_MOV_TRAILLER();
        public class VA0344B_MOV_TRAILLER : VarBasis
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


        public VA0344B_DEBITO DEBITO { get; set; } = new VA0344B_DEBITO();
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
            /*" -277- MOVE '0001-INICIO               ' TO PARAGRAFO. */
            _.Move("0001-INICIO               ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -278- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -281- EXEC SQL WHENEVER SQLERROR GO TO 9999-ERRO END-EXEC. */

            /*" -284- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -287- DISPLAY '---------------------------------------' */
            _.Display($"---------------------------------------");

            /*" -288- DISPLAY '     PROGRAMA EM EXECUCAO VA0344B      ' */
            _.Display($"     PROGRAMA EM EXECUCAO VA0344B      ");

            /*" -289- DISPLAY '                                       ' */
            _.Display($"                                       ");

            /*" -291- DISPLAY 'VERSAO V.02 NSGD - 20/07/2015 ' */
            _.Display($"VERSAO V.02 NSGD - 20/07/2015 ");

            /*" -297- DISPLAY '---------------------------------------' */
            _.Display($"---------------------------------------");

            /*" -299- MOVE 'SELECT V0SISTEMA' TO COMANDO. */
            _.Move("SELECT V0SISTEMA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -306- PERFORM M_0000_PRINCIPAL_DB_SELECT_1 */

            M_0000_PRINCIPAL_DB_SELECT_1();

            /*" -309- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -311- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -312- MOVE SIST-CURRDATE TO DATA-SQL. */
            _.Move(SIST_CURRDATE, WORK_AREA.DATA_SQL);

            /*" -313- MOVE CORR DATA-SQL TO DATA-AAMMDD. */
            _.MoveCorr(WORK_AREA.DATA_SQL, WORK_AREA.DATA_AAMMDD);

            /*" -315- MOVE DATA-INVERTIDA TO MA-DATA-GERACAO. */
            _.Move(WORK_AREA.DATA_INVERTIDA, MOV_HEADER.MA_DATA_GERACAO);

            /*" -323- DISPLAY '*** VA0344B *** DATA DE GERACAO DA FITA: ' DATA-SQL. */
            _.Display($"*** VA0344B *** DATA DE GERACAO DA FITA: {WORK_AREA.DATA_SQL}");

            /*" -325- MOVE 'SELECT V0CONVSUCOV' TO COMANDO. */
            _.Move("SELECT V0CONVSUCOV", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -334- PERFORM M_0000_PRINCIPAL_DB_SELECT_2 */

            M_0000_PRINCIPAL_DB_SELECT_2();

            /*" -337- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -339- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -341- ADD 1 TO PARM-NSA. */
            PARM_NSA.Value = PARM_NSA + 1;

            /*" -342- MOVE PARM-NSA TO MA-NSA. */
            _.Move(PARM_NSA, MOV_HEADER.MA_NSA);

            /*" -347- MOVE PARM-VERSAO TO MA-VERSAO-LAYOUT. */
            _.Move(PARM_VERSAO, MOV_HEADER.MA_VERSAO_LAYOUT);

            /*" -348- MOVE SIST-CURRDATE TO W04DTSQL. */
            _.Move(SIST_CURRDATE, WORK_AREA.W04DTSQL);

            /*" -349- MOVE W04DDSQL TO SU1-DD1. */
            _.Move(WORK_AREA.W04DTSQL.W04DDSQL, WORK_AREA.PARM_PROSOMU1.SU1_DATA1.SU1_DD1);

            /*" -350- MOVE W04MMSQL TO SU1-MM1. */
            _.Move(WORK_AREA.W04DTSQL.W04MMSQL, WORK_AREA.PARM_PROSOMU1.SU1_DATA1.SU1_MM1);

            /*" -351- MOVE W04AASQL TO SU1-AA1. */
            _.Move(WORK_AREA.W04DTSQL.W04AASQL, WORK_AREA.PARM_PROSOMU1.SU1_DATA1.SU1_AA1);

            /*" -352- MOVE ZEROES TO SU1-DATA2. */
            _.Move(0, WORK_AREA.PARM_PROSOMU1.SU1_DATA2);

            /*" -353- PERFORM 0010-SOMA-DIAS THRU 0010-FIM 6 TIMES. */

            M_0010_SOMA_DIAS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0010_FIM*/


            /*" -354- MOVE SU1-DD2 TO W04DDSQL. */
            _.Move(WORK_AREA.PARM_PROSOMU1.SU1_DATA2.SU1_DD2, WORK_AREA.W04DTSQL.W04DDSQL);

            /*" -355- MOVE SU1-MM2 TO W04MMSQL. */
            _.Move(WORK_AREA.PARM_PROSOMU1.SU1_DATA2.SU1_MM2, WORK_AREA.W04DTSQL.W04MMSQL);

            /*" -357- MOVE SU1-AA2 TO W04AASQL. */
            _.Move(WORK_AREA.PARM_PROSOMU1.SU1_DATA2.SU1_AA2, WORK_AREA.W04DTSQL.W04AASQL);

            /*" -359- MOVE W04DTSQL TO SIST-DTMAXDEB. */
            _.Move(WORK_AREA.W04DTSQL, SIST_DTMAXDEB);

            /*" -360- MOVE SIST-DTMAXDEB TO DATA-SQL. */
            _.Move(SIST_DTMAXDEB, WORK_AREA.DATA_SQL);

            /*" -361- MOVE CORR DATA-SQL TO DATA-AAMMDD. */
            _.MoveCorr(WORK_AREA.DATA_SQL, WORK_AREA.DATA_AAMMDD);

            /*" -362- MOVE DATA-INVERTIDA TO MF-DATA-VENCIMENTO. */
            _.Move(WORK_AREA.DATA_INVERTIDA, MOV_LANCAMENTO.MF_DATA_VENCIMENTO);

            /*" -369- DISPLAY '*** VA0344B *** DATA MAXIMA DE DEBITO EM CONTA: ' DATA-SQL. */
            _.Display($"*** VA0344B *** DATA MAXIMA DE DEBITO EM CONTA: {WORK_AREA.DATA_SQL}");

            /*" -389- PERFORM M_0000_PRINCIPAL_DB_DECLARE_1 */

            M_0000_PRINCIPAL_DB_DECLARE_1();

            /*" -392- MOVE 'OPEN DEBITO    ' TO COMANDO. */
            _.Move("OPEN DEBITO    ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -392- PERFORM M_0000_PRINCIPAL_DB_OPEN_1 */

            M_0000_PRINCIPAL_DB_OPEN_1();

            /*" -396- PERFORM 1010-FETCH THRU 1010-FIM. */

            M_1010_FETCH(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1010_FIM*/


            /*" -397- IF WS-EOF = 1 */

            if (WORK_AREA.WS_EOF == 1)
            {

                /*" -398- DISPLAY '*** VA0344B *** CONVENIO 6088' */
                _.Display($"*** VA0344B *** CONVENIO 6088");

                /*" -399- DISPLAY '*** VA0344B *** NAO HA DEBITOS A PROCESSAR' */
                _.Display($"*** VA0344B *** NAO HA DEBITOS A PROCESSAR");

                /*" -400- DISPLAY '*** VA0344B *** TERMINO NORMAL' */
                _.Display($"*** VA0344B *** TERMINO NORMAL");

                /*" -400- EXEC SQL COMMIT WORK END-EXEC */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -402- MOVE 0 TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -404- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -405- OPEN OUTPUT MOVIMENTO. */
            MOVIMENTO.Open(MOVIMENTO_RECORD);

            /*" -407- WRITE MOVIMENTO-RECORD FROM MOV-HEADER. */
            _.Move(MOV_HEADER.GetMoveValues(), MOVIMENTO_RECORD);

            MOVIMENTO.Write(MOVIMENTO_RECORD.GetMoveValues().ToString());

            /*" -414- PERFORM M-1000-PROCESSA-DEBITO THRU 1000-FIM UNTIL WS-EOF = 1. */

            while (!(WORK_AREA.WS_EOF == 1))
            {

                M_1000_PROCESSA_DEBITO(true);

                M_1000_NEXT(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1000_FIM*/

            }

            /*" -415- MOVE '0075-SOLICITA-RELAT' TO PARAGRAFO. */
            _.Move("0075-SOLICITA-RELAT", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -417- MOVE 'INSERT V0RELATORIOS' TO COMANDO. */
            _.Move("INSERT V0RELATORIOS", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -460- PERFORM M_0000_PRINCIPAL_DB_INSERT_1 */

            M_0000_PRINCIPAL_DB_INSERT_1();

            /*" -463- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -464- DISPLAY 'VA0344B - PROBLEMAS NA INCLUSAO VA0473B' */
                _.Display($"VA0344B - PROBLEMAS NA INCLUSAO VA0473B");

                /*" -470- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -472- PERFORM 9000-FINALIZA THRU 9000-FIM. */

            M_9000_FINALIZA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9000_FIM*/


            /*" -472- PERFORM M_0000_PRINCIPAL_DB_CLOSE_1 */

            M_0000_PRINCIPAL_DB_CLOSE_1();

            /*" -476- CLOSE MOVIMENTO. */
            MOVIMENTO.Close();

            /*" -476- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -480- DISPLAY '*** VA0344B *** TERMINO NORMAL' . */
            _.Display($"*** VA0344B *** TERMINO NORMAL");

            /*" -481- MOVE 0 TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -481- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SELECT-1 */
        public void M_0000_PRINCIPAL_DB_SELECT_1()
        {
            /*" -306- EXEC SQL SELECT CURRENT DATE, CURRENT DATE + 1 DAY INTO :SIST-CURRDATE, :SIST-DTMINDEB FROM SEGUROS.V0SISTEMA WHERE IDSISTEM= 'VA' END-EXEC. */

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
            /*" -490- MOVE +1 TO SU1-NRDIAS. */
            _.Move(+1, WORK_AREA.PARM_PROSOMU1.SU1_NRDIAS);

            /*" -491- CALL 'PROSOCU1' USING PARM-PROSOMU1. */
            _.Call("PROSOCU1", WORK_AREA.PARM_PROSOMU1);

            /*" -491- MOVE SU1-DATA2 TO SU1-DATA1. */
            _.Move(WORK_AREA.PARM_PROSOMU1.SU1_DATA2, WORK_AREA.PARM_PROSOMU1.SU1_DATA1);

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-DECLARE-1 */
        public void M_0000_PRINCIPAL_DB_DECLARE_1()
        {
            /*" -389- EXEC SQL DECLARE DEBITO CURSOR FOR SELECT NRCERTIF, NRPARCEL, AGECTADEB, OPRCTADEB, NUMCTADEB, DIGCTADEB, VLPRMTOT, SITUACAO, DTVENCTO, NSAS, NSL FROM SEGUROS.V0HISTCONTAVA WHERE CODCONV = 6088 AND SITUACAO = '0' AND NUMCTADEB > 0 AND TIPLANC = '4' FOR UPDATE OF SITUACAO, NSAS END-EXEC. */
            DEBITO = new VA0344B_DEBITO(false);
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
							WHERE CODCONV = 6088 
							AND SITUACAO = '0' 
							AND NUMCTADEB > 0 
							AND TIPLANC = '4'";

                return query;
            }
            DEBITO.GetQueryEvent += GetQuery_DEBITO;

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-OPEN-1 */
        public void M_0000_PRINCIPAL_DB_OPEN_1()
        {
            /*" -392- EXEC SQL OPEN DEBITO END-EXEC. */

            DEBITO.Open();

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-INSERT-1 */
        public void M_0000_PRINCIPAL_DB_INSERT_1()
        {
            /*" -460- EXEC SQL INSERT INTO SEGUROS.V0RELATORIOS VALUES ( 'VA0344B' , :SIST-CURRDATE, 'VA' , 'VA0473B' , :PARM-NSA, 0, :SIST-CURRDATE, :SIST-CURRDATE, :SIST-CURRDATE, 0, 0, 0, 0, 0, 0, 0, 0, 97010000889, 0, 0, 0, 0, 0, 0, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '0' , ' ' , ' ' , NULL, 0, 0, CURRENT TIMESTAMP) END-EXEC. */

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
            /*" -472- EXEC SQL CLOSE DEBITO END-EXEC. */

            DEBITO.Close();

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SELECT-2 */
        public void M_0000_PRINCIPAL_DB_SELECT_2()
        {
            /*" -334- EXEC SQL SELECT COD_CONVENIO, NSA_CONVENIO, VERSAO_LAYOUT INTO :PARM-CODCONV, :PARM-NSA, :PARM-VERSAO FROM SEGUROS.V0CONVSUCOV WHERE COD_CONVENIO = 6088 END-EXEC. */

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
            /*" -508- MOVE NSL TO FITSAS-NSL MF-NSL. */
            _.Move(NSL, FITSAS_NSL, MOV_LANCAMENTO.MF_USO_EMPRESA.MF_NSL);

            /*" -510- MOVE NSAS TO MF-NSA. */
            _.Move(NSAS, MOV_LANCAMENTO.MF_USO_EMPRESA.MF_NSA);

            /*" -512- MOVE NRCERTIF TO MF-IDENT-CLI. */
            _.Move(NRCERTIF, MOV_LANCAMENTO.MF_IDENT_CLI_EMPRESA.MF_IDENT_CLI);

            /*" -513- MOVE AGECTADEB TO MF-AGENCIA. */
            _.Move(AGECTADEB, MOV_LANCAMENTO.MF_AGENCIA);

            /*" -514- MOVE OPRCTADEB TO MF-OPR-CTA-CORR. */
            _.Move(OPRCTADEB, MOV_LANCAMENTO.MF_IDENT_CLI_BANCO.MF_OPR_CTA_CORR);

            /*" -515- MOVE NUMCTADEB TO MF-NUM-CTA-CORR. */
            _.Move(NUMCTADEB, MOV_LANCAMENTO.MF_IDENT_CLI_BANCO.MF_NUM_CTA_CORR);

            /*" -516- MOVE DIGCTADEB TO MF-DAC-CTA-CORR. */
            _.Move(DIGCTADEB, MOV_LANCAMENTO.MF_IDENT_CLI_BANCO.MF_DAC_CTA_CORR);

            /*" -518- MOVE VLPRMTOT TO MF-VALOR. */
            _.Move(VLPRMTOT, MOV_LANCAMENTO.MF_VALOR);

            /*" -519- MOVE DTVENCTO TO DATA-SQL. */
            _.Move(DTVENCTO, WORK_AREA.DATA_SQL);

            /*" -520- MOVE CORR DATA-SQL TO DATA-AAMMDD. */
            _.MoveCorr(WORK_AREA.DATA_SQL, WORK_AREA.DATA_AAMMDD);

            /*" -522- MOVE DATA-INVERTIDA TO MF-DATA-VENCIMENTO. */
            _.Move(WORK_AREA.DATA_INVERTIDA, MOV_LANCAMENTO.MF_DATA_VENCIMENTO);

            /*" -524- MOVE PARM-NSA TO MF-NSA-PARM. */
            _.Move(PARM_NSA, MOV_LANCAMENTO.MF_IDENT_CLI_EMPRESA.MF_NSA_PARM);

            /*" -526- WRITE MOVIMENTO-RECORD FROM MOV-LANCAMENTO. */
            _.Move(MOV_LANCAMENTO.GetMoveValues(), MOVIMENTO_RECORD);

            MOVIMENTO.Write(MOVIMENTO_RECORD.GetMoveValues().ToString());

            /*" -527- ADD 1 TO AC-REGISTROS. */
            WORK_AREA.AC_REGISTROS.Value = WORK_AREA.AC_REGISTROS + 1;

            /*" -529- ADD VLPRMTOT TO AC-VALOR. */
            WORK_AREA.AC_VALOR.Value = WORK_AREA.AC_VALOR + VLPRMTOT;

            /*" -531- MOVE '1000-PROCESSA' TO PARAGRAFO. */
            _.Move("1000-PROCESSA", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -533- MOVE 'UPDATE V0HISTCONTAVA' TO COMANDO. */
            _.Move("UPDATE V0HISTCONTAVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -539- PERFORM M_1000_PROCESSA_DEBITO_DB_UPDATE_1 */

            M_1000_PROCESSA_DEBITO_DB_UPDATE_1();

            /*" -542- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -542- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-1000-PROCESSA-DEBITO-DB-UPDATE-1 */
        public void M_1000_PROCESSA_DEBITO_DB_UPDATE_1()
        {
            /*" -539- EXEC SQL UPDATE SEGUROS.V0HISTCONTAVA SET SITUACAO = '3' , NSAS = :PARM-NSA:SQL-NOT-NULL WHERE CURRENT OF DEBITO END-EXEC. */

            var m_1000_PROCESSA_DEBITO_DB_UPDATE_1_Update1 = new M_1000_PROCESSA_DEBITO_DB_UPDATE_1_Update1(DEBITO)
            {
                PARM_NSA = PARM_NSA.ToString(),
                SQL_NOT_NULL = SQL_NOT_NULL.ToString(),
            };

            M_1000_PROCESSA_DEBITO_DB_UPDATE_1_Update1.Execute(m_1000_PROCESSA_DEBITO_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-1000-NEXT */
        private void M_1000_NEXT(bool isPerform = false)
        {
            /*" -546- PERFORM 1010-FETCH THRU 1010-FIM. */

            M_1010_FETCH(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1010_FIM*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1000_FIM*/

        [StopWatch]
        /*" M-1010-FETCH */
        private void M_1010_FETCH(bool isPerform = false)
        {
            /*" -557- MOVE '1010-FETCH' TO PARAGRAFO. */
            _.Move("1010-FETCH", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -559- MOVE 'FETCH DEBITO                     ' TO COMANDO. */
            _.Move("FETCH DEBITO                     ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -572- PERFORM M_1010_FETCH_DB_FETCH_1 */

            M_1010_FETCH_DB_FETCH_1();

            /*" -575- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -575- MOVE 1 TO WS-EOF. */
                _.Move(1, WORK_AREA.WS_EOF);
            }


        }

        [StopWatch]
        /*" M-1010-FETCH-DB-FETCH-1 */
        public void M_1010_FETCH_DB_FETCH_1()
        {
            /*" -572- EXEC SQL FETCH DEBITO INTO :NRCERTIF, :NRPARCEL, :AGECTADEB, :OPRCTADEB, :NUMCTADEB, :DIGCTADEB, :VLPRMTOT, :SITUACAO, :DTVENCTO, :NSAS:SQL-MAYBE-NULL1, :NSL:SQL-MAYBE-NULL2 END-EXEC. */

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
            /*" -585- ADD 1 TO AC-REGISTROS. */
            WORK_AREA.AC_REGISTROS.Value = WORK_AREA.AC_REGISTROS + 1;

            /*" -587- MOVE AC-REGISTROS TO MZ-QTDE-REGISTROS WS-DISPLAY-QUANT. */
            _.Move(WORK_AREA.AC_REGISTROS, MOV_TRAILLER.MZ_QTDE_REGISTROS, WORK_AREA.WS_DISPLAY_QUANT);

            /*" -589- MOVE AC-VALOR TO MZ-TOT-DEB-CRUZ WS-DISPLAY-VALOR. */
            _.Move(WORK_AREA.AC_VALOR, MOV_TRAILLER.MZ_TOT_DEB_CRUZ, WORK_AREA.WS_DISPLAY_VALOR);

            /*" -590- MOVE PARM-NSA TO WS-DISPLAY-NSA. */
            _.Move(PARM_NSA, WORK_AREA.WS_DISPLAY_NSA);

            /*" -592- WRITE MOVIMENTO-RECORD FROM MOV-TRAILLER. */
            _.Move(MOV_TRAILLER.GetMoveValues(), MOVIMENTO_RECORD);

            MOVIMENTO.Write(MOVIMENTO_RECORD.GetMoveValues().ToString());

            /*" -593- DISPLAY '*** VA0344B *** CONVENIO   6088' . */
            _.Display($"*** VA0344B *** CONVENIO   6088");

            /*" -594- DISPLAY '*** VA0344B *** NSA        ' WS-DISPLAY-NSA. */
            _.Display($"*** VA0344B *** NSA        {WORK_AREA.WS_DISPLAY_NSA}");

            /*" -595- DISPLAY '*** VA0344B *** QUANTIDADE ' WS-DISPLAY-QUANT. */
            _.Display($"*** VA0344B *** QUANTIDADE {WORK_AREA.WS_DISPLAY_QUANT}");

            /*" -597- DISPLAY '*** VA0344B *** VALOR      ' WS-DISPLAY-VALOR. */
            _.Display($"*** VA0344B *** VALOR      {WORK_AREA.WS_DISPLAY_VALOR}");

            /*" -598- MOVE '9000-FINALIZA' TO PARAGRAFO. */
            _.Move("9000-FINALIZA", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -600- MOVE 'UPDATE V0CONVSUCOV' TO COMANDO. */
            _.Move("UPDATE V0CONVSUCOV", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -604- PERFORM M_9000_FINALIZA_DB_UPDATE_1 */

            M_9000_FINALIZA_DB_UPDATE_1();

            /*" -607- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -609- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -611- MOVE 'INSERT V0FITASASSE' TO COMANDO. */
            _.Move("INSERT V0FITASASSE", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -612- MOVE AC-REGISTROS TO FITSAS-REG. */
            _.Move(WORK_AREA.AC_REGISTROS, FITSAS_REG);

            /*" -614- MOVE AC-VALOR TO FITSAS-VALOR. */
            _.Move(WORK_AREA.AC_VALOR, FITSAS_VALOR);

            /*" -634- PERFORM M_9000_FINALIZA_DB_INSERT_1 */

            M_9000_FINALIZA_DB_INSERT_1();

            /*" -637- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -637- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-9000-FINALIZA-DB-UPDATE-1 */
        public void M_9000_FINALIZA_DB_UPDATE_1()
        {
            /*" -604- EXEC SQL UPDATE SEGUROS.V0CONVSUCOV SET NSA_CONVENIO = :PARM-NSA WHERE COD_CONVENIO = 6088 END-EXEC. */

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
            /*" -634- EXEC SQL INSERT INTO SEGUROS.V0FITASASSE VALUES (:PARM-CODCONV, :PARM-NSA, :SIST-CURRDATE, :SIST-DTMAXDEB, 'VA0344B' , '1' , 01, :PARM-VERSAO, :FITSAS-REG, :FITSAS-VALOR, 0, :FITSAS-NSL, 0, 0, 0, 0, 0, 0) END-EXEC. */

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
            /*" -648- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WORK_AREA.WABEND.WSQLCODE);

            /*" -649- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], WORK_AREA.WABEND.WSQLERRD1);

            /*" -650- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], WORK_AREA.WABEND.WSQLERRD2);

            /*" -651- DISPLAY WABEND. */
            _.Display(WORK_AREA.WABEND);

            /*" -652- DISPLAY LOCALIZA-ABEND-1. */
            _.Display(WORK_AREA.LOCALIZA_ABEND_1);

            /*" -654- DISPLAY LOCALIZA-ABEND-2. */
            _.Display(WORK_AREA.LOCALIZA_ABEND_2);

            /*" -654- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -656- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -660- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -660- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}