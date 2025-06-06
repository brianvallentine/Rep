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
using Sias.Outros.DB2.FN0303B;

namespace Code
{
    public class FN0303B
    {
        public bool IsCall { get; set; }

        public FN0303B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *  GERA MOVIMENTO DIARIO DE COBRANCA DA APOLICE:                 *      */
        /*"      *                                                                *      */
        /*"      *              1) EXCLUSIVO                                      *      */
        /*"      *              2) CONSTRUTIVA                                    *      */
        /*"      *              3) VIDA DA GENTE                                  *      */
        /*"      *              4) MULTIPREMIADO SUPER                            *      */
        /*"      *              5) SENIOR                                         *      */
        /*"      *                                                                *      */
        /*"      *  A PARTIR DE MARCO DE 2004 GERA PARCELAS TAMBEM PARA OS        *      */
        /*"      *  PRODUTOS VIDA DA GENTE, MULTIPREMIADO SUPER E SENIOR.         *      */
        /*"      *                                       (PROCURE TL0403)         *      */
        /*"JV108 *----------------------------------------------------------------*      */
        /*"JV108 *VERSAO 08: JV1 DEMANDA 259990 - KINKAS 10/09/2020               *      */
        /*"JV108 *           INCLUI/EXCLUI APOLICES E PRODUTOS JV1                *      */
        /*"JV108 *           - PROCURAR POR JV108                                 *      */
        /*"JV108 *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 07 - HIST 188.246                                     *      */
        /*"      *             - PREPARAR PROGRAMA PARA PROCESSAMENTO DA JV1      *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/01/2019 - HUSNI ALI HUSNI                              *      */
        /*"      *                                       PROCURE POR JV101        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 06             ALTERACOES NOS REGISTROS TIPO 3 E TIPO A *      */
        /*"      * ATENDE CADMUS 97713   CAMPOS :  OPERACAO E NUMERO DE CONTA     *      */
        /*"      *                                                                *      */
        /*"      * PROCURE NSGD          REGINALDO SILVA                          *      */
        /*"      *                       10/10/2014                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 05     PROCURE POR V.05                                 *      */
        /*"      * ALTERACAO:  11/11/2013 REGINALDO SILVA                         *      */
        /*"      *    AJUSTAR O SELECT NA BUSCA DOS CORRETORES DA FENAE.          *      */
        /*"      *    CADMUS       ============================>  88764           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 04                                                      *      */
        /*"      * ALTERACAO:  12/06/2012 REGINALDO SILVA                         *      */
        /*"      *    ACRESCENTAR NO REGISTRO DE SAIDA O CAMPO DE NUM-ENDOSSO     *      */
        /*"      *    QUE ESTA NA TABELA HIST_CON_PARCELVA                        *      */
        /*"      *    CADMUS       ============================>  70789           *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * ALTERACAO:  06/04/2011 SERGIO LORETO                           *      */
        /*"      *    COLOCAR CLAUSULA WITH UR NOS COMANDOS SELECT                *      */
        /*"      *    PROCURAR POR ============================> C54479           *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * ATENDE SSI 23.047                                              *      */
        /*"      *               TRATAMENTO PARA O PROGRAMA NAO PEGAR MAIS A      *      */
        /*"      *               APOLICE  93605000853                             *      */
        /*"      * EM 15/04/2009 - CESAR DALAZUANA (FAST COMPUTER)                *      */
        /*"      *                                           PROCURE POR V.03     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        public FileBasis _MOVIMENTO { get; set; } = new FileBasis(new PIC("X", "111", "X(111)"));

        public FileBasis MOVIMENTO
        {
            get
            {
                _.Move(MOVIMENTO_RECORD, _MOVIMENTO); VarBasis.RedefinePassValue(MOVIMENTO_RECORD, _MOVIMENTO, MOVIMENTO_RECORD); return _MOVIMENTO;
            }
        }
        /*"01  MOVIMENTO-RECORD    PIC X(111).*/
        public StringBasis MOVIMENTO_RECORD { get; set; } = new StringBasis(new PIC("X", "111", "X(111)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  DATA-QUITACAO                    PIC X(10).*/
        public StringBasis DATA_QUITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  SIST-DTMOVABE                    PIC X(10).*/
        public StringBasis SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  SIST-DTMOVABE-T1                 PIC X(26).*/
        public StringBasis SIST_DTMOVABE_T1 { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"01  SIST-DTMOVABE-T2                 PIC X(26).*/
        public StringBasis SIST_DTMOVABE_T2 { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"01  SIST-CURRDATE                    PIC X(10).*/
        public StringBasis SIST_CURRDATE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  SIST-DTMAXDEB                    PIC X(10).*/
        public StringBasis SIST_DTMAXDEB { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  SIST-DTMINDEB                    PIC X(10).*/
        public StringBasis SIST_DTMINDEB { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0PROP-SITUACAO                  PIC X(01).*/
        public StringBasis V0PROP_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  APOLCORR-CODCORR                 PIC S9(9) USAGE COMP.*/
        public IntBasis APOLCORR_CODCORR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01  PARM-CODCONV                     PIC S9(9)     COMP.*/
        public IntBasis PARM_CODCONV { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01  PARM-NSA                         PIC S9(4)     COMP.*/
        public IntBasis PARM_NSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  PARM-VERSAO                      PIC S9(4)     COMP.*/
        public IntBasis PARM_VERSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  NRAPOLICE-CODSUBES.*/
        public FN0303B_NRAPOLICE_CODSUBES NRAPOLICE_CODSUBES { get; set; } = new FN0303B_NRAPOLICE_CODSUBES();
        public class FN0303B_NRAPOLICE_CODSUBES : VarBasis
        {
            /*"  03  NRAPOLICE                      PIC S9(13)    COMP-3.*/
            public IntBasis NRAPOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
            /*"  03  CODSUBES                       PIC S9(04)    COMP.*/
            public IntBasis CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"01  NRAPOLICE-CODSUBES-ANT.*/
        }
        public FN0303B_NRAPOLICE_CODSUBES_ANT NRAPOLICE_CODSUBES_ANT { get; set; } = new FN0303B_NRAPOLICE_CODSUBES_ANT();
        public class FN0303B_NRAPOLICE_CODSUBES_ANT : VarBasis
        {
            /*"  03  NRAPOLICE-ANT                  PIC S9(13)    COMP-3.*/
            public IntBasis NRAPOLICE_ANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
            /*"  03  CODSUBES-ANT                   PIC S9(04)    COMP.*/
            public IntBasis CODSUBES_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"01  NRCERTIF                         PIC S9(15)    COMP-3.*/
        }
        public IntBasis NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  NRPARCEL                         PIC S9(4)     COMP.*/
        public IntBasis NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  AGECTADEB                        PIC S9(4)     COMP.*/
        public IntBasis AGECTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  OPRCTADEB                        PIC S9(4)     COMP.*/
        public IntBasis OPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  NUMCTADEB                        PIC S9(15)V   COMP-3.*/
        public DoubleBasis NUMCTADEB { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"01  OCORHIST                         PIC S9(4)     COMP.*/
        public IntBasis OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  CODRET                           PIC S9(4)     COMP.*/
        public IntBasis CODRET { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-CODRET                      PIC S9(4)     COMP.*/
        public IntBasis VIND_CODRET { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-AGECTADEB                   PIC S9(4)     COMP.*/
        public IntBasis VIND_AGECTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-OPRCTADEB                   PIC S9(4)     COMP.*/
        public IntBasis VIND_OPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-NUMCTADEB                   PIC S9(04)    COMP.*/
        public IntBasis VIND_NUMCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-DIGCTADEB                   PIC S9(4)     COMP.*/
        public IntBasis VIND_DIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  DIGCTADEB                        PIC S9(4)     COMP.*/
        public IntBasis DIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VLPRMTOT                         PIC S9(13)V99 COMP-3.*/
        public DoubleBasis VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  OPCAOPAG                         PIC X(1).*/
        public StringBasis OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  SITUACAO-PROP                    PIC X(1).*/
        public StringBasis SITUACAO_PROP { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  SITUACAO-COBR                    PIC X(1).*/
        public StringBasis SITUACAO_COBR { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  SITUACAO-LANC                    PIC X(1).*/
        public StringBasis SITUACAO_LANC { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  DTVENCTO                         PIC X(10).*/
        public StringBasis DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  NUM-ENDOSSO                      PIC S9(9)     COMP-3.*/
        public IntBasis NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01  DTVENCTO-PARCELA                 PIC X(10).*/
        public StringBasis DTVENCTO_PARCELA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
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
        public FN0303B_WORK_AREA WORK_AREA { get; set; } = new FN0303B_WORK_AREA();
        public class FN0303B_WORK_AREA : VarBasis
        {
            /*"    05      DATA-SQL.*/
            public FN0303B_DATA_SQL DATA_SQL { get; set; } = new FN0303B_DATA_SQL();
            public class FN0303B_DATA_SQL : VarBasis
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
            private _REDEF_FN0303B_DATA_AAMMDD _data_aammdd { get; set; }
            public _REDEF_FN0303B_DATA_AAMMDD DATA_AAMMDD
            {
                get { _data_aammdd = new _REDEF_FN0303B_DATA_AAMMDD(); _.Move(DATA_INVERTIDA, _data_aammdd); VarBasis.RedefinePassValue(DATA_INVERTIDA, _data_aammdd, DATA_INVERTIDA); _data_aammdd.ValueChanged += () => { _.Move(_data_aammdd, DATA_INVERTIDA); }; return _data_aammdd; }
                set { VarBasis.RedefinePassValue(value, _data_aammdd, DATA_INVERTIDA); }
            }  //Redefines
            public class _REDEF_FN0303B_DATA_AAMMDD : VarBasis
            {
                /*"      10    ANO                      PIC  9(004).*/
                public IntBasis ANO_0 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10    MES                      PIC  9(002).*/
                public IntBasis MES_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    DIA                      PIC  9(002).*/
                public IntBasis DIA_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05 W04DTSQL.*/

                public _REDEF_FN0303B_DATA_AAMMDD()
                {
                    ANO_0.ValueChanged += OnValueChanged;
                    MES_0.ValueChanged += OnValueChanged;
                    DIA_0.ValueChanged += OnValueChanged;
                }

            }
            public FN0303B_W04DTSQL W04DTSQL { get; set; } = new FN0303B_W04DTSQL();
            public class FN0303B_W04DTSQL : VarBasis
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
            public FN0303B_PARM_PROSOMU1 PARM_PROSOMU1 { get; set; } = new FN0303B_PARM_PROSOMU1();
            public class FN0303B_PARM_PROSOMU1 : VarBasis
            {
                /*"      10 SU1-DATA1.*/
                public FN0303B_SU1_DATA1 SU1_DATA1 { get; set; } = new FN0303B_SU1_DATA1();
                public class FN0303B_SU1_DATA1 : VarBasis
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
                public FN0303B_SU1_DATA2 SU1_DATA2 { get; set; } = new FN0303B_SU1_DATA2();
                public class FN0303B_SU1_DATA2 : VarBasis
                {
                    /*"        15 SU1-DD2                   PIC 99.*/
                    public IntBasis SU1_DD2 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"        15 SU1-MM2                   PIC 99.*/
                    public IntBasis SU1_MM2 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"        15 SU1-AA2                   PIC 9999.*/
                    public IntBasis SU1_AA2 { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
                    /*"    05 AC-REGISTROS                  PIC  9(009)    VALUE ZEROS.*/
                }
            }
            public IntBasis AC_REGISTROS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05 AC-VALOR                      PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis AC_VALOR { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05 WS-AGENCIA-ANT                PIC S9(004) COMP.*/
            public IntBasis WS_AGENCIA_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05 WS-NSL                        PIC  9(008) VALUE 0.*/
            public IntBasis WS_NSL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05 WTEM-HISTCONTA                PIC  X(001) VALUE SPACES.*/
            public StringBasis WTEM_HISTCONTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
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
            /*"    05 WS-VERIF-FENAE                PIC  X(001) VALUE SPACES.*/
            public StringBasis WS_VERIF_FENAE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05      WABEND.*/
            public FN0303B_WABEND WABEND { get; set; } = new FN0303B_WABEND();
            public class FN0303B_WABEND : VarBasis
            {
                /*"      10    FILLER                   PIC  X(010) VALUE            'FN0303B  '.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"FN0303B  ");
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
            public FN0303B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new FN0303B_LOCALIZA_ABEND_1();
            public class FN0303B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05      LOCALIZA-ABEND-2.*/
            }
            public FN0303B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new FN0303B_LOCALIZA_ABEND_2();
            public class FN0303B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"01  MOV-LANCAMENTO.*/
            }
        }
        public FN0303B_MOV_LANCAMENTO MOV_LANCAMENTO { get; set; } = new FN0303B_MOV_LANCAMENTO();
        public class FN0303B_MOV_LANCAMENTO : VarBasis
        {
            /*"    05 MOV-NUM-APOLICE           PIC 9(013).*/
            public IntBasis MOV_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"    05 MOV-COD-SUBGRUPO          PIC 9(004).*/
            public IntBasis MOV_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05 MOV-NUM-CERTIFICADO       PIC 9(015).*/
            public IntBasis MOV_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05 MOV-NUM-PARCELA           PIC 9(004).*/
            public IntBasis MOV_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05 MOV-OPCAOPAG              PIC X(001).*/
            public StringBasis MOV_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05 MOV-AGECTADEB             PIC 9(004).*/
            public IntBasis MOV_AGECTADEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05 MOV-OPRCTADEB             PIC 9(004).*/
            public IntBasis MOV_OPRCTADEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05 MOV-NUMCTADEB             PIC 9(012).*/
            public IntBasis MOV_NUMCTADEB { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
            /*"    05 MOV-DIGCTADEB             PIC 9(001).*/
            public IntBasis MOV_DIGCTADEB { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05 MOV-DATA-VENCIMENTO.*/
            public FN0303B_MOV_DATA_VENCIMENTO MOV_DATA_VENCIMENTO { get; set; } = new FN0303B_MOV_DATA_VENCIMENTO();
            public class FN0303B_MOV_DATA_VENCIMENTO : VarBasis
            {
                /*"     10 MOV-ANO-VENCIMENTO       PIC 9(004).*/
                public IntBasis MOV_ANO_VENCIMENTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"     10 MOV-MES-VENCIMENTO       PIC 9(002).*/
                public IntBasis MOV_MES_VENCIMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"     10 MOV-DIA-VENCIMENTO       PIC 9(002).*/
                public IntBasis MOV_DIA_VENCIMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05 MOV-DATA-COBRANCA.*/
            }
            public FN0303B_MOV_DATA_COBRANCA MOV_DATA_COBRANCA { get; set; } = new FN0303B_MOV_DATA_COBRANCA();
            public class FN0303B_MOV_DATA_COBRANCA : VarBasis
            {
                /*"     10 MOV-ANO-COBRANCA         PIC 9(004).*/
                public IntBasis MOV_ANO_COBRANCA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"     10 MOV-MES-COBRANCA         PIC 9(002).*/
                public IntBasis MOV_MES_COBRANCA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"     10 MOV-DIA-COBRANCA         PIC 9(002).*/
                public IntBasis MOV_DIA_COBRANCA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05 MOV-DATA-QUITACAO.*/
            }
            public FN0303B_MOV_DATA_QUITACAO MOV_DATA_QUITACAO { get; set; } = new FN0303B_MOV_DATA_QUITACAO();
            public class FN0303B_MOV_DATA_QUITACAO : VarBasis
            {
                /*"     10 MOV-ANO-QUITACAO         PIC 9(004).*/
                public IntBasis MOV_ANO_QUITACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"     10 MOV-MES-QUITACAO         PIC 9(002).*/
                public IntBasis MOV_MES_QUITACAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"     10 MOV-DIA-QUITACAO         PIC 9(002).*/
                public IntBasis MOV_DIA_QUITACAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05 MOV-VAL-PREMIO            PIC 9(13)V99.*/
            }
            public DoubleBasis MOV_VAL_PREMIO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99."), 2);
            /*"    05 MOV-COD-RETORNO           PIC X(02).*/
            public StringBasis MOV_COD_RETORNO { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
            /*"    05 MOV-COD-RETORNO-9         REDEFINES       MOV-COD-RETORNO           PIC 9(02).*/
            private _REDEF_IntBasis _mov_cod_retorno_9 { get; set; }
            public _REDEF_IntBasis MOV_COD_RETORNO_9
            {
                get { _mov_cod_retorno_9 = new _REDEF_IntBasis(new PIC("9", "02", "9(02).")); ; _.Move(MOV_COD_RETORNO, _mov_cod_retorno_9); VarBasis.RedefinePassValue(MOV_COD_RETORNO, _mov_cod_retorno_9, MOV_COD_RETORNO); _mov_cod_retorno_9.ValueChanged += () => { _.Move(_mov_cod_retorno_9, MOV_COD_RETORNO); }; return _mov_cod_retorno_9; }
                set { VarBasis.RedefinePassValue(value, _mov_cod_retorno_9, MOV_COD_RETORNO); }
            }  //Redefines
            /*"    05 MOV-SITUACAO-PROP         PIC X(01).*/
            public StringBasis MOV_SITUACAO_PROP { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 MOV-SITUACAO-LANC         PIC X(01).*/
            public StringBasis MOV_SITUACAO_LANC { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 MOV-SITUACAO-COBR         PIC X(01).*/
            public StringBasis MOV_SITUACAO_COBR { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 MOV-NUM-ENDOSSO           PIC 9(09).*/
            public IntBasis MOV_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
            /*"01         WREG-TRAILLER    VALUE ALL '0'.*/
        }
        public FN0303B_WREG_TRAILLER WREG_TRAILLER { get; set; } = new FN0303B_WREG_TRAILLER();
        public class FN0303B_WREG_TRAILLER : VarBasis
        {
            /*"  05       FTRL-PROGRAMA         PIC  X(006).*/
            public StringBasis FTRL_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
            /*"  05       FTRL-TIPOREG          PIC  X(008).*/
            public StringBasis FTRL_TIPOREG { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  05       FTRL-DTMOVABE         PIC  X(010).*/
            public StringBasis FTRL_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05       FTRL-QTDREG           PIC  9(009).*/
            public IntBasis FTRL_QTDREG { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05       FILLER                PIC  X(056).*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "56", "X(056)."), @"");
            /*"01  WS-TIMESTAMP-LIMITE.*/
        }
        public FN0303B_WS_TIMESTAMP_LIMITE WS_TIMESTAMP_LIMITE { get; set; } = new FN0303B_WS_TIMESTAMP_LIMITE();
        public class FN0303B_WS_TIMESTAMP_LIMITE : VarBasis
        {
            /*"  03 WS-DT-TIMESTAMP-L   PIC X(010)          VALUE ZEROS.*/
            public StringBasis WS_DT_TIMESTAMP_L { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03 FILLER              PIC X(001)          VALUE '-'.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"  03 WS-HH-TIMESTAMP-L   PIC 9(002)          VALUE ZEROS.*/
            public IntBasis WS_HH_TIMESTAMP_L { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  03 FILLER              PIC X(001)          VALUE '.'.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
            /*"  03 WS-MM-TIMESTAMP-L   PIC 9(002)          VALUE ZEROS.*/
            public IntBasis WS_MM_TIMESTAMP_L { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  03 FILLER              PIC X(001)          VALUE '.'.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
            /*"  03 WS-SS-TIMESTAMP-L   PIC 9(002)          VALUE ZEROS.*/
            public IntBasis WS_SS_TIMESTAMP_L { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  03 FILLER              PIC X(001)          VALUE '.'.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
            /*"  03 WS-MS-TIMESTAMP-L   PIC 9(006)          VALUE ZEROS.*/
            public IntBasis WS_MS_TIMESTAMP_L { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        }


        public FN0303B_DEBITO DEBITO { get; set; } = new FN0303B_DEBITO();
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
            /*" -311- MOVE '0001-INICIO               ' TO PARAGRAFO. */
            _.Move("0001-INICIO               ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -312- DISPLAY ' ' */
            _.Display($" ");

            /*" -314- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -316- DISPLAY 'PROGRAMA FN0303B - ' 'GERA MOVIMENTO DIARIO DE COBRANCA DA APOLICE' */
            _.Display($"PROGRAMA FN0303B - GERA MOVIMENTO DIARIO DE COBRANCA DA APOLICE");

            /*" -323- DISPLAY 'VERSAO V.08 - DEMANDA 259990 - ' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) '-' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) */

            $"VERSAO V.08 - DEMANDA 259990 - FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)}-FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}"
            .Display();

            /*" -325- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -327- DISPLAY ' ' */
            _.Display($" ");

            /*" -340- DISPLAY 'FN0303B - INICIO  EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"FN0303B - INICIO  EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -342- MOVE 'SELECT V0SISTEMA' TO COMANDO. */
            _.Move("SELECT V0SISTEMA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -352- PERFORM M_0000_PRINCIPAL_DB_SELECT_1 */

            M_0000_PRINCIPAL_DB_SELECT_1();

            /*" -355- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -357- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -358- MOVE 'FN0303' TO FTRL-PROGRAMA. */
            _.Move("FN0303", WREG_TRAILLER.FTRL_PROGRAMA);

            /*" -360- MOVE 'TRAILLER' TO FTRL-TIPOREG. */
            _.Move("TRAILLER", WREG_TRAILLER.FTRL_TIPOREG);

            /*" -363- MOVE SIST-DTMOVABE TO FTRL-DTMOVABE WS-DT-TIMESTAMP-L */
            _.Move(SIST_DTMOVABE, WREG_TRAILLER.FTRL_DTMOVABE, WS_TIMESTAMP_LIMITE.WS_DT_TIMESTAMP_L);

            /*" -365- MOVE WS-TIMESTAMP-LIMITE TO SIST-DTMOVABE-T1 */
            _.Move(WS_TIMESTAMP_LIMITE, SIST_DTMOVABE_T1);

            /*" -367- MOVE 24 TO WS-HH-TIMESTAMP-L */
            _.Move(24, WS_TIMESTAMP_LIMITE.WS_HH_TIMESTAMP_L);

            /*" -369- MOVE WS-TIMESTAMP-LIMITE TO SIST-DTMOVABE-T2. */
            _.Move(WS_TIMESTAMP_LIMITE, SIST_DTMOVABE_T2);

            /*" -370- MOVE SIST-CURRDATE TO DATA-SQL. */
            _.Move(SIST_CURRDATE, WORK_AREA.DATA_SQL);

            /*" -372- MOVE CORR DATA-SQL TO DATA-AAMMDD. */
            _.MoveCorr(WORK_AREA.DATA_SQL, WORK_AREA.DATA_AAMMDD);

            /*" -375- MOVE ZEROS TO NRAPOLICE-ANT CODSUBES-ANT. */
            _.Move(0, NRAPOLICE_CODSUBES_ANT.NRAPOLICE_ANT, NRAPOLICE_CODSUBES_ANT.CODSUBES_ANT);

            /*" -376- DISPLAY '*' . */
            _.Display($"*");

            /*" -378- DISPLAY '*  DATA T1 - TIMESTAMP..: ' SIST-DTMOVABE-T1. */
            _.Display($"*  DATA T1 - TIMESTAMP..: {SIST_DTMOVABE_T1}");

            /*" -390- DISPLAY '*  DATA DE GERACAO......: ' DATA-SQL. */
            _.Display($"*  DATA DE GERACAO......: {WORK_AREA.DATA_SQL}");

            /*" -712- PERFORM M_0000_PRINCIPAL_DB_DECLARE_1 */

            M_0000_PRINCIPAL_DB_DECLARE_1();

            /*" -715- MOVE 'OPEN DEBITO    ' TO COMANDO. */
            _.Move("OPEN DEBITO    ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -715- PERFORM M_0000_PRINCIPAL_DB_OPEN_1 */

            M_0000_PRINCIPAL_DB_OPEN_1();

            /*" -719- PERFORM 0910-FETCH THRU 0910-FIM. */

            M_0910_FETCH(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0910_FIM*/


            /*" -720- IF WS-EOF = 1 */

            if (WORK_AREA.WS_EOF == 1)
            {

                /*" -721- DISPLAY '*   FN0303B  ** CONVENIO 6088' */
                _.Display($"*   FN0303B  ** CONVENIO 6088");

                /*" -722- DISPLAY '*   FN0303B  ** NAO HA DEBITOS A PROCESSAR' */
                _.Display($"*   FN0303B  ** NAO HA DEBITOS A PROCESSAR");

                /*" -724- DISPLAY '*   FN0303B  ** TERMINO NORMAL' */
                _.Display($"*   FN0303B  ** TERMINO NORMAL");

                /*" -724- EXEC SQL ROLLBACK WORK END-EXEC */

                DatabaseConnection.Instance.RollbackTransaction();

                /*" -726- MOVE 0 TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -728- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -730- OPEN OUTPUT MOVIMENTO. */
            MOVIMENTO.Open(MOVIMENTO_RECORD);

            /*" -737- PERFORM 1000-PROCESSA-DEBITO THRU 1000-FIM UNTIL WS-EOF = 1. */

            while (!(WORK_AREA.WS_EOF == 1))
            {

                M_1000_PROCESSA_DEBITO(true);

                M_1000_NEXT(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1000_FIM*/

            }

            /*" -739- PERFORM 9000-FINALIZA THRU 9000-FIM. */

            M_9000_FINALIZA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9000_FIM*/


            /*" -739- PERFORM M_0000_PRINCIPAL_DB_CLOSE_1 */

            M_0000_PRINCIPAL_DB_CLOSE_1();

            /*" -744- CLOSE MOVIMENTO. */
            MOVIMENTO.Close();

            /*" -744- EXEC SQL ROLLBACK WORK END-EXEC */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -748- DISPLAY '*   FN0303B  **  TERMINO NORMAL' . */
            _.Display($"*   FN0303B  **  TERMINO NORMAL");

            /*" -749- MOVE 0 TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -749- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SELECT-1 */
        public void M_0000_PRINCIPAL_DB_SELECT_1()
        {
            /*" -352- EXEC SQL SELECT DTMOVABE , CURRENT DATE, CURRENT DATE + 1 DAY INTO :SIST-DTMOVABE, :SIST-CURRDATE, :SIST-DTMINDEB FROM SEGUROS.V0SISTEMA WHERE IDSISTEM = 'VA' WITH UR END-EXEC. */

            var m_0000_PRINCIPAL_DB_SELECT_1_Query1 = new M_0000_PRINCIPAL_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_0000_PRINCIPAL_DB_SELECT_1_Query1.Execute(m_0000_PRINCIPAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SIST_DTMOVABE, SIST_DTMOVABE);
                _.Move(executed_1.SIST_CURRDATE, SIST_CURRDATE);
                _.Move(executed_1.SIST_DTMINDEB, SIST_DTMINDEB);
            }


        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-DECLARE-1 */
        public void M_0000_PRINCIPAL_DB_DECLARE_1()
        {
            /*" -712- EXEC SQL DECLARE DEBITO CURSOR FOR SELECT A.NUM_APOLICE, A.CODSUBES, A.SITUACAO, A.NRCERTIF, D.NRPARCEL, B.AGECTADEB, B.OPRCTADEB, B.NUMCTADEB, B.DIGCTADEB, B.OPCAOPAG, C.OCORHIST, D.VLPRMTOT, D.SITUACAO, D.DTVENCTO FROM SEGUROS.V0PROPOSTAVA A, SEGUROS.V0OPCAOPAGVA B, SEGUROS.V0PARCELVA C, SEGUROS.V0HISTCOBVA D WHERE A.NUM_APOLICE IN ( 109300000550, 109300000550 ) AND A.SITUACAO = '3' AND B.NRCERTIF = A.NRCERTIF AND B.DTTERVIG = '9999-12-31' AND C.NRCERTIF = A.NRCERTIF AND C.TIMESTAMP >= :SIST-DTMOVABE-T1 AND D.NRCERTIF = C.NRCERTIF AND D.NRPARCEL = C.NRPARCEL UNION SELECT A.NUM_APOLICE, A.CODSUBES, A.SITUACAO, A.NRCERTIF, D.NRPARCEL, B.AGECTADEB, B.OPRCTADEB, B.NUMCTADEB, B.DIGCTADEB, B.OPCAOPAG, C.OCORHIST, D.VLPRMTOT, D.SITUACAO, D.DTVENCTO FROM SEGUROS.V0PROPOSTAVA A, SEGUROS.V0OPCAOPAGVA B, SEGUROS.V0PARCELVA C, SEGUROS.V0HISTCOBVA D WHERE A.NUM_APOLICE IN ( 109300000550, 109300000550 ) AND A.SITUACAO = '6' AND B.NRCERTIF = A.NRCERTIF AND B.DTTERVIG = '9999-12-31' AND C.NRCERTIF = A.NRCERTIF AND C.TIMESTAMP >= :SIST-DTMOVABE-T1 AND D.NRCERTIF = C.NRCERTIF AND D.NRPARCEL = C.NRPARCEL UNION SELECT A.NUM_APOLICE, A.CODSUBES, A.SITUACAO, A.NRCERTIF, D.NRPARCEL, B.AGECTADEB, B.OPRCTADEB, B.NUMCTADEB, B.DIGCTADEB, B.OPCAOPAG, C.OCORHIST, D.VLPRMTOT, D.SITUACAO, D.DTVENCTO FROM SEGUROS.V0PROPOSTAVA A, SEGUROS.V0OPCAOPAGVA B, SEGUROS.V0PARCELVA C, SEGUROS.V0HISTCOBVA D WHERE A.NUM_APOLICE IN ( 109300000559, 3009300000559 ) AND A.SITUACAO = '3' AND B.NRCERTIF = A.NRCERTIF AND B.DTTERVIG = '9999-12-31' AND C.NRCERTIF = A.NRCERTIF AND C.TIMESTAMP >= :SIST-DTMOVABE-T1 AND D.NRCERTIF = C.NRCERTIF AND D.NRPARCEL = C.NRPARCEL UNION SELECT A.NUM_APOLICE, A.CODSUBES, A.SITUACAO, A.NRCERTIF, D.NRPARCEL, B.AGECTADEB, B.OPRCTADEB, B.NUMCTADEB, B.DIGCTADEB, B.OPCAOPAG, C.OCORHIST, D.VLPRMTOT, D.SITUACAO, D.DTVENCTO FROM SEGUROS.V0PROPOSTAVA A, SEGUROS.V0OPCAOPAGVA B, SEGUROS.V0PARCELVA C, SEGUROS.V0HISTCOBVA D WHERE A.NUM_APOLICE IN ( 109300000559, 3009300000559 ) AND A.SITUACAO = '6' AND B.NRCERTIF = A.NRCERTIF AND B.DTTERVIG = '9999-12-31' AND C.NRCERTIF = A.NRCERTIF AND C.TIMESTAMP >= :SIST-DTMOVABE-T1 AND D.NRCERTIF = C.NRCERTIF AND D.NRPARCEL = C.NRPARCEL UNION SELECT A.NUM_APOLICE, A.CODSUBES, A.SITUACAO, A.NRCERTIF, D.NRPARCEL, B.AGECTADEB, B.OPRCTADEB, B.NUMCTADEB, B.DIGCTADEB, B.OPCAOPAG, C.OCORHIST, D.VLPRMTOT, D.SITUACAO, D.DTVENCTO FROM SEGUROS.V0PROPOSTAVA A, SEGUROS.V0OPCAOPAGVA B, SEGUROS.V0PARCELVA C, SEGUROS.V0HISTCOBVA D WHERE A.NUM_APOLICE = 109300000598 AND A.SITUACAO = '3' AND B.NRCERTIF = A.NRCERTIF AND B.DTTERVIG = '9999-12-31' AND C.NRCERTIF = A.NRCERTIF AND C.TIMESTAMP >= :SIST-DTMOVABE-T1 AND D.NRCERTIF = C.NRCERTIF AND D.NRPARCEL = C.NRPARCEL UNION SELECT A.NUM_APOLICE, A.CODSUBES, A.SITUACAO, A.NRCERTIF, D.NRPARCEL, B.AGECTADEB, B.OPRCTADEB, B.NUMCTADEB, B.DIGCTADEB, B.OPCAOPAG, C.OCORHIST, D.VLPRMTOT, D.SITUACAO, D.DTVENCTO FROM SEGUROS.V0PROPOSTAVA A, SEGUROS.V0OPCAOPAGVA B, SEGUROS.V0PARCELVA C, SEGUROS.V0HISTCOBVA D WHERE A.NUM_APOLICE = 109300000598 AND A.SITUACAO = '6' AND B.NRCERTIF = A.NRCERTIF AND B.DTTERVIG = '9999-12-31' AND C.NRCERTIF = A.NRCERTIF AND C.TIMESTAMP >= :SIST-DTMOVABE-T1 AND D.NRCERTIF = C.NRCERTIF AND D.NRPARCEL = C.NRPARCEL UNION SELECT A.NUM_APOLICE, A.CODSUBES, A.SITUACAO, A.NRCERTIF, D.NRPARCEL, B.AGECTADEB, B.OPRCTADEB, B.NUMCTADEB, B.DIGCTADEB, B.OPCAOPAG, C.OCORHIST, D.VLPRMTOT, D.SITUACAO, D.DTVENCTO FROM SEGUROS.V0PROPOSTAVA A, SEGUROS.V0OPCAOPAGVA B, SEGUROS.V0PARCELVA C, SEGUROS.V0HISTCOBVA D WHERE A.NUM_APOLICE = 109700000033 AND A.SITUACAO = '3' AND B.NRCERTIF = A.NRCERTIF AND B.DTTERVIG = '9999-12-31' AND C.NRCERTIF = A.NRCERTIF AND C.TIMESTAMP >= :SIST-DTMOVABE-T1 AND D.NRCERTIF = C.NRCERTIF AND D.NRPARCEL = C.NRPARCEL UNION SELECT A.NUM_APOLICE, A.CODSUBES, A.SITUACAO, A.NRCERTIF, D.NRPARCEL, B.AGECTADEB, B.OPRCTADEB, B.NUMCTADEB, B.DIGCTADEB, B.OPCAOPAG, C.OCORHIST, D.VLPRMTOT, D.SITUACAO, D.DTVENCTO FROM SEGUROS.V0PROPOSTAVA A, SEGUROS.V0OPCAOPAGVA B, SEGUROS.V0PARCELVA C, SEGUROS.V0HISTCOBVA D WHERE A.NUM_APOLICE = 109700000033 AND A.SITUACAO = '6' AND B.NRCERTIF = A.NRCERTIF AND B.DTTERVIG = '9999-12-31' AND C.NRCERTIF = A.NRCERTIF AND C.TIMESTAMP >= :SIST-DTMOVABE-T1 AND D.NRCERTIF = C.NRCERTIF AND D.NRPARCEL = C.NRPARCEL UNION SELECT A.NUM_APOLICE, A.CODSUBES, A.SITUACAO, A.NRCERTIF, D.NRPARCEL, B.AGECTADEB, B.OPRCTADEB, B.NUMCTADEB, B.DIGCTADEB, B.OPCAOPAG, C.OCORHIST, D.VLPRMTOT, D.SITUACAO, D.DTVENCTO FROM SEGUROS.V0PROPOSTAVA A, SEGUROS.V0OPCAOPAGVA B, SEGUROS.V0PARCELVA C, SEGUROS.V0HISTCOBVA D WHERE A.NUM_APOLICE = 97010000889 AND A.CODSUBES = 1950 AND A.SITUACAO = '3' AND B.NRCERTIF = A.NRCERTIF AND B.DTTERVIG = '9999-12-31' AND C.NRCERTIF = A.NRCERTIF AND C.TIMESTAMP >= :SIST-DTMOVABE-T1 AND D.NRCERTIF = C.NRCERTIF AND D.NRPARCEL = C.NRPARCEL UNION SELECT A.NUM_APOLICE, A.CODSUBES, A.SITUACAO, A.NRCERTIF, D.NRPARCEL, B.AGECTADEB, B.OPRCTADEB, B.NUMCTADEB, B.DIGCTADEB, B.OPCAOPAG, C.OCORHIST, D.VLPRMTOT, D.SITUACAO, D.DTVENCTO FROM SEGUROS.V0PROPOSTAVA A, SEGUROS.V0OPCAOPAGVA B, SEGUROS.V0PARCELVA C, SEGUROS.V0HISTCOBVA D WHERE A.NUM_APOLICE = 97010000889 AND A.CODSUBES = 1950 AND A.SITUACAO = '6' AND B.NRCERTIF = A.NRCERTIF AND B.DTTERVIG = '9999-12-31' AND C.NRCERTIF = A.NRCERTIF AND C.TIMESTAMP >= :SIST-DTMOVABE-T1 AND D.NRCERTIF = C.NRCERTIF AND D.NRPARCEL = C.NRPARCEL ORDER BY 1 , 2 , 4 , 5 WITH UR END-EXEC. */
            DEBITO = new FN0303B_DEBITO(true);
            string GetQuery_DEBITO()
            {
                var query = @$"SELECT A.NUM_APOLICE
							, 
							A.CODSUBES
							, 
							A.SITUACAO
							, 
							A.NRCERTIF
							, 
							D.NRPARCEL
							, 
							B.AGECTADEB
							, 
							B.OPRCTADEB
							, 
							B.NUMCTADEB
							, 
							B.DIGCTADEB
							, 
							B.OPCAOPAG
							, 
							C.OCORHIST
							, 
							D.VLPRMTOT
							, 
							D.SITUACAO
							, 
							D.DTVENCTO 
							FROM SEGUROS.V0PROPOSTAVA A
							, 
							SEGUROS.V0OPCAOPAGVA B
							, 
							SEGUROS.V0PARCELVA C
							, 
							SEGUROS.V0HISTCOBVA D 
							WHERE A.NUM_APOLICE IN ( 109300000550
							, 109300000550 ) 
							AND A.SITUACAO = '3' 
							AND B.NRCERTIF = A.NRCERTIF 
							AND B.DTTERVIG = '9999-12-31' 
							AND C.NRCERTIF = A.NRCERTIF 
							AND C.TIMESTAMP >= 
							'{SIST_DTMOVABE_T1}' 
							AND D.NRCERTIF = C.NRCERTIF 
							AND D.NRPARCEL = C.NRPARCEL 
							UNION 
							SELECT A.NUM_APOLICE
							, 
							A.CODSUBES
							, 
							A.SITUACAO
							, 
							A.NRCERTIF
							, 
							D.NRPARCEL
							, 
							B.AGECTADEB
							, 
							B.OPRCTADEB
							, 
							B.NUMCTADEB
							, 
							B.DIGCTADEB
							, 
							B.OPCAOPAG
							, 
							C.OCORHIST
							, 
							D.VLPRMTOT
							, 
							D.SITUACAO
							, 
							D.DTVENCTO 
							FROM SEGUROS.V0PROPOSTAVA A
							, 
							SEGUROS.V0OPCAOPAGVA B
							, 
							SEGUROS.V0PARCELVA C
							, 
							SEGUROS.V0HISTCOBVA D 
							WHERE A.NUM_APOLICE IN ( 109300000550
							, 109300000550 ) 
							AND A.SITUACAO = '6' 
							AND B.NRCERTIF = A.NRCERTIF 
							AND B.DTTERVIG = '9999-12-31' 
							AND C.NRCERTIF = A.NRCERTIF 
							AND C.TIMESTAMP >= 
							'{SIST_DTMOVABE_T1}' 
							AND D.NRCERTIF = C.NRCERTIF 
							AND D.NRPARCEL = C.NRPARCEL 
							UNION 
							SELECT A.NUM_APOLICE
							, 
							A.CODSUBES
							, 
							A.SITUACAO
							, 
							A.NRCERTIF
							, 
							D.NRPARCEL
							, 
							B.AGECTADEB
							, 
							B.OPRCTADEB
							, 
							B.NUMCTADEB
							, 
							B.DIGCTADEB
							, 
							B.OPCAOPAG
							, 
							C.OCORHIST
							, 
							D.VLPRMTOT
							, 
							D.SITUACAO
							, 
							D.DTVENCTO 
							FROM SEGUROS.V0PROPOSTAVA A
							, 
							SEGUROS.V0OPCAOPAGVA B
							, 
							SEGUROS.V0PARCELVA C
							, 
							SEGUROS.V0HISTCOBVA D 
							WHERE A.NUM_APOLICE IN ( 109300000559
							, 3009300000559 ) 
							AND A.SITUACAO = '3' 
							AND B.NRCERTIF = A.NRCERTIF 
							AND B.DTTERVIG = '9999-12-31' 
							AND C.NRCERTIF = A.NRCERTIF 
							AND C.TIMESTAMP >= 
							'{SIST_DTMOVABE_T1}' 
							AND D.NRCERTIF = C.NRCERTIF 
							AND D.NRPARCEL = C.NRPARCEL 
							UNION 
							SELECT A.NUM_APOLICE
							, 
							A.CODSUBES
							, 
							A.SITUACAO
							, 
							A.NRCERTIF
							, 
							D.NRPARCEL
							, 
							B.AGECTADEB
							, 
							B.OPRCTADEB
							, 
							B.NUMCTADEB
							, 
							B.DIGCTADEB
							, 
							B.OPCAOPAG
							, 
							C.OCORHIST
							, 
							D.VLPRMTOT
							, 
							D.SITUACAO
							, 
							D.DTVENCTO 
							FROM SEGUROS.V0PROPOSTAVA A
							, 
							SEGUROS.V0OPCAOPAGVA B
							, 
							SEGUROS.V0PARCELVA C
							, 
							SEGUROS.V0HISTCOBVA D 
							WHERE A.NUM_APOLICE IN ( 109300000559
							, 3009300000559 ) 
							AND A.SITUACAO = '6' 
							AND B.NRCERTIF = A.NRCERTIF 
							AND B.DTTERVIG = '9999-12-31' 
							AND C.NRCERTIF = A.NRCERTIF 
							AND C.TIMESTAMP >= 
							'{SIST_DTMOVABE_T1}' 
							AND D.NRCERTIF = C.NRCERTIF 
							AND D.NRPARCEL = C.NRPARCEL 
							UNION 
							SELECT A.NUM_APOLICE
							, 
							A.CODSUBES
							, 
							A.SITUACAO
							, 
							A.NRCERTIF
							, 
							D.NRPARCEL
							, 
							B.AGECTADEB
							, 
							B.OPRCTADEB
							, 
							B.NUMCTADEB
							, 
							B.DIGCTADEB
							, 
							B.OPCAOPAG
							, 
							C.OCORHIST
							, 
							D.VLPRMTOT
							, 
							D.SITUACAO
							, 
							D.DTVENCTO 
							FROM SEGUROS.V0PROPOSTAVA A
							, 
							SEGUROS.V0OPCAOPAGVA B
							, 
							SEGUROS.V0PARCELVA C
							, 
							SEGUROS.V0HISTCOBVA D 
							WHERE A.NUM_APOLICE = 109300000598 
							AND A.SITUACAO = '3' 
							AND B.NRCERTIF = A.NRCERTIF 
							AND B.DTTERVIG = '9999-12-31' 
							AND C.NRCERTIF = A.NRCERTIF 
							AND C.TIMESTAMP >= 
							'{SIST_DTMOVABE_T1}' 
							AND D.NRCERTIF = C.NRCERTIF 
							AND D.NRPARCEL = C.NRPARCEL 
							UNION 
							SELECT A.NUM_APOLICE
							, 
							A.CODSUBES
							, 
							A.SITUACAO
							, 
							A.NRCERTIF
							, 
							D.NRPARCEL
							, 
							B.AGECTADEB
							, 
							B.OPRCTADEB
							, 
							B.NUMCTADEB
							, 
							B.DIGCTADEB
							, 
							B.OPCAOPAG
							, 
							C.OCORHIST
							, 
							D.VLPRMTOT
							, 
							D.SITUACAO
							, 
							D.DTVENCTO 
							FROM SEGUROS.V0PROPOSTAVA A
							, 
							SEGUROS.V0OPCAOPAGVA B
							, 
							SEGUROS.V0PARCELVA C
							, 
							SEGUROS.V0HISTCOBVA D 
							WHERE A.NUM_APOLICE = 109300000598 
							AND A.SITUACAO = '6' 
							AND B.NRCERTIF = A.NRCERTIF 
							AND B.DTTERVIG = '9999-12-31' 
							AND C.NRCERTIF = A.NRCERTIF 
							AND C.TIMESTAMP >= 
							'{SIST_DTMOVABE_T1}' 
							AND D.NRCERTIF = C.NRCERTIF 
							AND D.NRPARCEL = C.NRPARCEL 
							UNION 
							SELECT A.NUM_APOLICE
							, 
							A.CODSUBES
							, 
							A.SITUACAO
							, 
							A.NRCERTIF
							, 
							D.NRPARCEL
							, 
							B.AGECTADEB
							, 
							B.OPRCTADEB
							, 
							B.NUMCTADEB
							, 
							B.DIGCTADEB
							, 
							B.OPCAOPAG
							, 
							C.OCORHIST
							, 
							D.VLPRMTOT
							, 
							D.SITUACAO
							, 
							D.DTVENCTO 
							FROM SEGUROS.V0PROPOSTAVA A
							, 
							SEGUROS.V0OPCAOPAGVA B
							, 
							SEGUROS.V0PARCELVA C
							, 
							SEGUROS.V0HISTCOBVA D 
							WHERE A.NUM_APOLICE = 109700000033 
							AND A.SITUACAO = '3' 
							AND B.NRCERTIF = A.NRCERTIF 
							AND B.DTTERVIG = '9999-12-31' 
							AND C.NRCERTIF = A.NRCERTIF 
							AND C.TIMESTAMP >= 
							'{SIST_DTMOVABE_T1}' 
							AND D.NRCERTIF = C.NRCERTIF 
							AND D.NRPARCEL = C.NRPARCEL 
							UNION 
							SELECT A.NUM_APOLICE
							, 
							A.CODSUBES
							, 
							A.SITUACAO
							, 
							A.NRCERTIF
							, 
							D.NRPARCEL
							, 
							B.AGECTADEB
							, 
							B.OPRCTADEB
							, 
							B.NUMCTADEB
							, 
							B.DIGCTADEB
							, 
							B.OPCAOPAG
							, 
							C.OCORHIST
							, 
							D.VLPRMTOT
							, 
							D.SITUACAO
							, 
							D.DTVENCTO 
							FROM SEGUROS.V0PROPOSTAVA A
							, 
							SEGUROS.V0OPCAOPAGVA B
							, 
							SEGUROS.V0PARCELVA C
							, 
							SEGUROS.V0HISTCOBVA D 
							WHERE A.NUM_APOLICE = 109700000033 
							AND A.SITUACAO = '6' 
							AND B.NRCERTIF = A.NRCERTIF 
							AND B.DTTERVIG = '9999-12-31' 
							AND C.NRCERTIF = A.NRCERTIF 
							AND C.TIMESTAMP >= 
							'{SIST_DTMOVABE_T1}' 
							AND D.NRCERTIF = C.NRCERTIF 
							AND D.NRPARCEL = C.NRPARCEL 
							UNION 
							SELECT A.NUM_APOLICE
							, 
							A.CODSUBES
							, 
							A.SITUACAO
							, 
							A.NRCERTIF
							, 
							D.NRPARCEL
							, 
							B.AGECTADEB
							, 
							B.OPRCTADEB
							, 
							B.NUMCTADEB
							, 
							B.DIGCTADEB
							, 
							B.OPCAOPAG
							, 
							C.OCORHIST
							, 
							D.VLPRMTOT
							, 
							D.SITUACAO
							, 
							D.DTVENCTO 
							FROM SEGUROS.V0PROPOSTAVA A
							, 
							SEGUROS.V0OPCAOPAGVA B
							, 
							SEGUROS.V0PARCELVA C
							, 
							SEGUROS.V0HISTCOBVA D 
							WHERE A.NUM_APOLICE = 97010000889 
							AND A.CODSUBES = 1950 
							AND A.SITUACAO = '3' 
							AND B.NRCERTIF = A.NRCERTIF 
							AND B.DTTERVIG = '9999-12-31' 
							AND C.NRCERTIF = A.NRCERTIF 
							AND C.TIMESTAMP >= 
							'{SIST_DTMOVABE_T1}' 
							AND D.NRCERTIF = C.NRCERTIF 
							AND D.NRPARCEL = C.NRPARCEL 
							UNION 
							SELECT A.NUM_APOLICE
							, 
							A.CODSUBES
							, 
							A.SITUACAO
							, 
							A.NRCERTIF
							, 
							D.NRPARCEL
							, 
							B.AGECTADEB
							, 
							B.OPRCTADEB
							, 
							B.NUMCTADEB
							, 
							B.DIGCTADEB
							, 
							B.OPCAOPAG
							, 
							C.OCORHIST
							, 
							D.VLPRMTOT
							, 
							D.SITUACAO
							, 
							D.DTVENCTO 
							FROM SEGUROS.V0PROPOSTAVA A
							, 
							SEGUROS.V0OPCAOPAGVA B
							, 
							SEGUROS.V0PARCELVA C
							, 
							SEGUROS.V0HISTCOBVA D 
							WHERE A.NUM_APOLICE = 97010000889 
							AND A.CODSUBES = 1950 
							AND A.SITUACAO = '6' 
							AND B.NRCERTIF = A.NRCERTIF 
							AND B.DTTERVIG = '9999-12-31' 
							AND C.NRCERTIF = A.NRCERTIF 
							AND C.TIMESTAMP >= 
							'{SIST_DTMOVABE_T1}' 
							AND D.NRCERTIF = C.NRCERTIF 
							AND D.NRPARCEL = C.NRPARCEL 
							ORDER BY 1
							, 
							2
							, 
							4
							, 
							5";

                return query;
            }
            DEBITO.GetQueryEvent += GetQuery_DEBITO;

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-OPEN-1 */
        public void M_0000_PRINCIPAL_DB_OPEN_1()
        {
            /*" -715- EXEC SQL OPEN DEBITO END-EXEC. */

            DEBITO.Open();

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-CLOSE-1 */
        public void M_0000_PRINCIPAL_DB_CLOSE_1()
        {
            /*" -739- EXEC SQL CLOSE DEBITO END-EXEC. */

            DEBITO.Close();

        }

        [StopWatch]
        /*" M-0910-FETCH */
        private void M_0910_FETCH(bool isPerform = false)
        {
            /*" -758- MOVE '0910-FETCH' TO PARAGRAFO. */
            _.Move("0910-FETCH", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -760- MOVE 'FETCH DEBITO                     ' TO COMANDO. */
            _.Move("FETCH DEBITO                     ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -776- PERFORM M_0910_FETCH_DB_FETCH_1 */

            M_0910_FETCH_DB_FETCH_1();

            /*" -779- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -780- MOVE 1 TO WS-EOF */
                _.Move(1, WORK_AREA.WS_EOF);

                /*" -782- GO TO 0910-FIM. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0910_FIM*/ //GOTO
                return;
            }


            /*" -783- IF VIND-AGECTADEB LESS ZEROS */

            if (VIND_AGECTADEB < 00)
            {

                /*" -788- MOVE ZEROS TO AGECTADEB OPRCTADEB NUMCTADEB DIGCTADEB. */
                _.Move(0, AGECTADEB, OPRCTADEB, NUMCTADEB, DIGCTADEB);
            }


            /*" -789- IF SITUACAO-COBR EQUAL ' ' */

            if (SITUACAO_COBR == " ")
            {

                /*" -789- MOVE '0' TO SITUACAO-COBR. */
                _.Move("0", SITUACAO_COBR);
            }


        }

        [StopWatch]
        /*" M-0910-FETCH-DB-FETCH-1 */
        public void M_0910_FETCH_DB_FETCH_1()
        {
            /*" -776- EXEC SQL FETCH DEBITO INTO :NRAPOLICE, :CODSUBES, :SITUACAO-PROP, :NRCERTIF, :NRPARCEL, :AGECTADEB:VIND-AGECTADEB, :OPRCTADEB:VIND-OPRCTADEB, :NUMCTADEB:VIND-NUMCTADEB, :DIGCTADEB:VIND-DIGCTADEB, :OPCAOPAG, :OCORHIST, :VLPRMTOT, :SITUACAO-COBR, :DTVENCTO END-EXEC. */

            if (DEBITO.Fetch())
            {
                _.Move(DEBITO.NRAPOLICE, NRAPOLICE_CODSUBES.NRAPOLICE);
                _.Move(DEBITO.CODSUBES, NRAPOLICE_CODSUBES.CODSUBES);
                _.Move(DEBITO.SITUACAO_PROP, SITUACAO_PROP);
                _.Move(DEBITO.NRCERTIF, NRCERTIF);
                _.Move(DEBITO.NRPARCEL, NRPARCEL);
                _.Move(DEBITO.AGECTADEB, AGECTADEB);
                _.Move(DEBITO.VIND_AGECTADEB, VIND_AGECTADEB);
                _.Move(DEBITO.OPRCTADEB, OPRCTADEB);
                _.Move(DEBITO.VIND_OPRCTADEB, VIND_OPRCTADEB);
                _.Move(DEBITO.NUMCTADEB, NUMCTADEB);
                _.Move(DEBITO.VIND_NUMCTADEB, VIND_NUMCTADEB);
                _.Move(DEBITO.DIGCTADEB, DIGCTADEB);
                _.Move(DEBITO.VIND_DIGCTADEB, VIND_DIGCTADEB);
                _.Move(DEBITO.OPCAOPAG, OPCAOPAG);
                _.Move(DEBITO.OCORHIST, OCORHIST);
                _.Move(DEBITO.VLPRMTOT, VLPRMTOT);
                _.Move(DEBITO.SITUACAO_COBR, SITUACAO_COBR);
                _.Move(DEBITO.DTVENCTO, DTVENCTO);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0910_FIM*/

        [StopWatch]
        /*" M-1000-PROCESSA-DEBITO */
        private void M_1000_PROCESSA_DEBITO(bool isPerform = false)
        {
            /*" -802- IF (NRAPOLICE-CODSUBES-ANT) NOT EQUAL (NRAPOLICE-CODSUBES) */

            if ((NRAPOLICE_CODSUBES_ANT) != NRAPOLICE_CODSUBES)
            {

                /*" -803- PERFORM M-1005-VERIFICA-CORRET-FENAE */

                M_1005_VERIFICA_CORRET_FENAE(true);

                /*" -804- MOVE NRAPOLICE TO NRAPOLICE-ANT */
                _.Move(NRAPOLICE_CODSUBES.NRAPOLICE, NRAPOLICE_CODSUBES_ANT.NRAPOLICE_ANT);

                /*" -805- MOVE CODSUBES TO CODSUBES-ANT */
                _.Move(NRAPOLICE_CODSUBES.CODSUBES, NRAPOLICE_CODSUBES_ANT.CODSUBES_ANT);

                /*" -807- END-IF. */
            }


            /*" -808- IF WS-VERIF-FENAE EQUAL '0' */

            if (WORK_AREA.WS_VERIF_FENAE == "0")
            {

                /*" -810- GO TO 1000-NEXT. */

                M_1000_NEXT(); //GOTO
                return;
            }


            /*" -812- PERFORM 1010-SELECT-HISTCONTA THRU 1010-FIM. */

            M_1010_SELECT_HISTCONTA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1010_FIM*/


            /*" -814- PERFORM 1020-SELECT-HISTCONTABIL THRU 1020-FIM. */

            M_1020_SELECT_HISTCONTABIL(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1020_FIM*/


            /*" -815- IF DATA-QUITACAO = '1900-01-01' */

            if (DATA_QUITACAO == "1900-01-01")
            {

                /*" -816- MOVE SPACES TO MOV-DATA-QUITACAO */
                _.Move("", MOV_LANCAMENTO.MOV_DATA_QUITACAO);

                /*" -817- ELSE */
            }
            else
            {


                /*" -818- MOVE DATA-QUITACAO (1:4) TO MOV-ANO-QUITACAO */
                _.Move(DATA_QUITACAO.Substring(1, 4), MOV_LANCAMENTO.MOV_DATA_QUITACAO.MOV_ANO_QUITACAO);

                /*" -819- MOVE DATA-QUITACAO (6:2) TO MOV-MES-QUITACAO */
                _.Move(DATA_QUITACAO.Substring(6, 2), MOV_LANCAMENTO.MOV_DATA_QUITACAO.MOV_MES_QUITACAO);

                /*" -821- MOVE DATA-QUITACAO (9:2) TO MOV-DIA-QUITACAO. */
                _.Move(DATA_QUITACAO.Substring(9, 2), MOV_LANCAMENTO.MOV_DATA_QUITACAO.MOV_DIA_QUITACAO);
            }


            /*" -822- IF DTVENCTO-PARCELA = '1900-01-01' */

            if (DTVENCTO_PARCELA == "1900-01-01")
            {

                /*" -823- MOVE SPACES TO MOV-DATA-VENCIMENTO */
                _.Move("", MOV_LANCAMENTO.MOV_DATA_VENCIMENTO);

                /*" -824- ELSE */
            }
            else
            {


                /*" -825- MOVE DTVENCTO-PARCELA (1:4) TO MOV-ANO-VENCIMENTO */
                _.Move(DTVENCTO_PARCELA.Substring(1, 4), MOV_LANCAMENTO.MOV_DATA_VENCIMENTO.MOV_ANO_VENCIMENTO);

                /*" -826- MOVE DTVENCTO-PARCELA (6:2) TO MOV-MES-VENCIMENTO */
                _.Move(DTVENCTO_PARCELA.Substring(6, 2), MOV_LANCAMENTO.MOV_DATA_VENCIMENTO.MOV_MES_VENCIMENTO);

                /*" -828- MOVE DTVENCTO-PARCELA (9:2) TO MOV-DIA-VENCIMENTO. */
                _.Move(DTVENCTO_PARCELA.Substring(9, 2), MOV_LANCAMENTO.MOV_DATA_VENCIMENTO.MOV_DIA_VENCIMENTO);
            }


            /*" -829- MOVE NRAPOLICE TO MOV-NUM-APOLICE. */
            _.Move(NRAPOLICE_CODSUBES.NRAPOLICE, MOV_LANCAMENTO.MOV_NUM_APOLICE);

            /*" -830- MOVE CODSUBES TO MOV-COD-SUBGRUPO. */
            _.Move(NRAPOLICE_CODSUBES.CODSUBES, MOV_LANCAMENTO.MOV_COD_SUBGRUPO);

            /*" -831- MOVE NRCERTIF TO MOV-NUM-CERTIFICADO. */
            _.Move(NRCERTIF, MOV_LANCAMENTO.MOV_NUM_CERTIFICADO);

            /*" -832- MOVE NRPARCEL TO MOV-NUM-PARCELA. */
            _.Move(NRPARCEL, MOV_LANCAMENTO.MOV_NUM_PARCELA);

            /*" -833- MOVE AGECTADEB TO MOV-AGECTADEB. */
            _.Move(AGECTADEB, MOV_LANCAMENTO.MOV_AGECTADEB);

            /*" -834- MOVE OPCAOPAG TO MOV-OPCAOPAG. */
            _.Move(OPCAOPAG, MOV_LANCAMENTO.MOV_OPCAOPAG);

            /*" -835- MOVE OPRCTADEB TO MOV-OPRCTADEB. */
            _.Move(OPRCTADEB, MOV_LANCAMENTO.MOV_OPRCTADEB);

            /*" -836- MOVE NUMCTADEB TO MOV-NUMCTADEB. */
            _.Move(NUMCTADEB, MOV_LANCAMENTO.MOV_NUMCTADEB);

            /*" -837- MOVE DIGCTADEB TO MOV-DIGCTADEB. */
            _.Move(DIGCTADEB, MOV_LANCAMENTO.MOV_DIGCTADEB);

            /*" -838- MOVE DTVENCTO (1:4) TO MOV-ANO-COBRANCA. */
            _.Move(DTVENCTO.Substring(1, 4), MOV_LANCAMENTO.MOV_DATA_COBRANCA.MOV_ANO_COBRANCA);

            /*" -839- MOVE DTVENCTO (6:2) TO MOV-MES-COBRANCA. */
            _.Move(DTVENCTO.Substring(6, 2), MOV_LANCAMENTO.MOV_DATA_COBRANCA.MOV_MES_COBRANCA);

            /*" -840- MOVE DTVENCTO (9:2) TO MOV-DIA-COBRANCA. */
            _.Move(DTVENCTO.Substring(9, 2), MOV_LANCAMENTO.MOV_DATA_COBRANCA.MOV_DIA_COBRANCA);

            /*" -841- MOVE VLPRMTOT TO MOV-VAL-PREMIO. */
            _.Move(VLPRMTOT, MOV_LANCAMENTO.MOV_VAL_PREMIO);

            /*" -843- MOVE NUM-ENDOSSO TO MOV-NUM-ENDOSSO. */
            _.Move(NUM_ENDOSSO, MOV_LANCAMENTO.MOV_NUM_ENDOSSO);

            /*" -844- IF WTEM-HISTCONTA EQUAL 'N' */

            if (WORK_AREA.WTEM_HISTCONTA == "N")
            {

                /*" -846- MOVE SPACES TO MOV-COD-RETORNO MOV-SITUACAO-LANC */
                _.Move("", MOV_LANCAMENTO.MOV_COD_RETORNO, MOV_LANCAMENTO.MOV_SITUACAO_LANC);

                /*" -847- ELSE */
            }
            else
            {


                /*" -848- MOVE CODRET TO MOV-COD-RETORNO-9 */
                _.Move(CODRET, MOV_LANCAMENTO.MOV_COD_RETORNO_9);

                /*" -850- MOVE SITUACAO-LANC TO MOV-SITUACAO-LANC. */
                _.Move(SITUACAO_LANC, MOV_LANCAMENTO.MOV_SITUACAO_LANC);
            }


            /*" -851- MOVE SITUACAO-PROP TO MOV-SITUACAO-PROP. */
            _.Move(SITUACAO_PROP, MOV_LANCAMENTO.MOV_SITUACAO_PROP);

            /*" -853- MOVE SITUACAO-COBR TO MOV-SITUACAO-COBR. */
            _.Move(SITUACAO_COBR, MOV_LANCAMENTO.MOV_SITUACAO_COBR);

            /*" -855- WRITE MOVIMENTO-RECORD FROM MOV-LANCAMENTO. */
            _.Move(MOV_LANCAMENTO.GetMoveValues(), MOVIMENTO_RECORD);

            MOVIMENTO.Write(MOVIMENTO_RECORD.GetMoveValues().ToString());

            /*" -856- ADD 1 TO AC-REGISTROS. */
            WORK_AREA.AC_REGISTROS.Value = WORK_AREA.AC_REGISTROS + 1;

            /*" -856- ADD VLPRMTOT TO AC-VALOR. */
            WORK_AREA.AC_VALOR.Value = WORK_AREA.AC_VALOR + VLPRMTOT;

        }

        [StopWatch]
        /*" M-1000-NEXT */
        private void M_1000_NEXT(bool isPerform = false)
        {
            /*" -860- PERFORM 0910-FETCH THRU 0910-FIM. */

            M_0910_FETCH(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0910_FIM*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1000_FIM*/

        [StopWatch]
        /*" M-1005-VERIFICA-CORRET-FENAE */
        private void M_1005_VERIFICA_CORRET_FENAE(bool isPerform = false)
        {
            /*" -867- MOVE '1005-VERIFICA-CORRET-FENAE' TO PARAGRAFO. */
            _.Move("1005-VERIFICA-CORRET-FENAE", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -869- MOVE 'SELECT V1PRODUTOR                ' TO COMANDO. */
            _.Move("SELECT V1PRODUTOR                ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -878- DISPLAY '*  FN0303B - INICIO - VERIFICA CORRETOR FENAE ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"*  FN0303B - INICIO - VERIFICA CORRETOR FENAE {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -890- PERFORM M_1005_VERIFICA_CORRET_FENAE_DB_SELECT_1 */

            M_1005_VERIFICA_CORRET_FENAE_DB_SELECT_1();

            /*" -895- DISPLAY '*  FN0303B - APOLICE ' NRAPOLICE '  CODSUBES ' CODSUBES '  COD CORR ' APOLCORR-CODCORR */

            $"*  FN0303B - APOLICE {NRAPOLICE_CODSUBES.NRAPOLICE}  CODSUBES {NRAPOLICE_CODSUBES.CODSUBES}  COD CORR {APOLCORR_CODCORR}"
            .Display();

            /*" -904- DISPLAY '*  FN0303B - TERMINO - VERIFICA CORRETOR FENAE ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"*  FN0303B - TERMINO - VERIFICA CORRETOR FENAE {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -905- IF SQLCODE EQUAL ZEROS OR 811 OR -811 */

            if (DB.SQLCODE.In("00", "811", "-811"))
            {

                /*" -906- MOVE '1' TO WS-VERIF-FENAE */
                _.Move("1", WORK_AREA.WS_VERIF_FENAE);

                /*" -907- ELSE */
            }
            else
            {


                /*" -908- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -909- MOVE '0' TO WS-VERIF-FENAE */
                    _.Move("0", WORK_AREA.WS_VERIF_FENAE);

                    /*" -910- ELSE */
                }
                else
                {


                    /*" -911- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -912- END-IF */
                }


                /*" -913- END-IF. */
            }


        }

        [StopWatch]
        /*" M-1005-VERIFICA-CORRET-FENAE-DB-SELECT-1 */
        public void M_1005_VERIFICA_CORRET_FENAE_DB_SELECT_1()
        {
            /*" -890- EXEC SQL SELECT A.CODCORR INTO :APOLCORR-CODCORR FROM SEGUROS.V1APOLCORRET A, SEGUROS.V1PRODUTOR B WHERE A.NUM_APOLICE = :NRAPOLICE AND A.CODSUBES = :CODSUBES AND A.CODCORR = B.CODPDT AND B.CGCCPF IN (42278473000103, 29552064000187) WITH UR END-EXEC */

            var m_1005_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1 = new M_1005_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1()
            {
                NRAPOLICE = NRAPOLICE_CODSUBES.NRAPOLICE.ToString(),
                CODSUBES = NRAPOLICE_CODSUBES.CODSUBES.ToString(),
            };

            var executed_1 = M_1005_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1.Execute(m_1005_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLCORR_CODCORR, APOLCORR_CODCORR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1005_FIM*/

        [StopWatch]
        /*" M-1010-SELECT-HISTCONTA */
        private void M_1010_SELECT_HISTCONTA(bool isPerform = false)
        {
            /*" -920- MOVE 'S' TO WTEM-HISTCONTA. */
            _.Move("S", WORK_AREA.WTEM_HISTCONTA);

            /*" -930- PERFORM M_1010_SELECT_HISTCONTA_DB_SELECT_1 */

            M_1010_SELECT_HISTCONTA_DB_SELECT_1();

            /*" -933- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -933- MOVE 'N' TO WTEM-HISTCONTA. */
                _.Move("N", WORK_AREA.WTEM_HISTCONTA);
            }


        }

        [StopWatch]
        /*" M-1010-SELECT-HISTCONTA-DB-SELECT-1 */
        public void M_1010_SELECT_HISTCONTA_DB_SELECT_1()
        {
            /*" -930- EXEC SQL SELECT SITUACAO, CODRET INTO :SITUACAO-LANC, :CODRET:VIND-CODRET FROM SEGUROS.V0HISTCONTAVA WHERE NRCERTIF = :NRCERTIF AND NRPARCEL = :NRPARCEL AND OCORRHISTCTA = :OCORHIST WITH UR END-EXEC. */

            var m_1010_SELECT_HISTCONTA_DB_SELECT_1_Query1 = new M_1010_SELECT_HISTCONTA_DB_SELECT_1_Query1()
            {
                NRCERTIF = NRCERTIF.ToString(),
                NRPARCEL = NRPARCEL.ToString(),
                OCORHIST = OCORHIST.ToString(),
            };

            var executed_1 = M_1010_SELECT_HISTCONTA_DB_SELECT_1_Query1.Execute(m_1010_SELECT_HISTCONTA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SITUACAO_LANC, SITUACAO_LANC);
                _.Move(executed_1.CODRET, CODRET);
                _.Move(executed_1.VIND_CODRET, VIND_CODRET);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1010_FIM*/

        [StopWatch]
        /*" M-1020-SELECT-HISTCONTABIL */
        private void M_1020_SELECT_HISTCONTABIL(bool isPerform = false)
        {
            /*" -949- PERFORM M_1020_SELECT_HISTCONTABIL_DB_SELECT_1 */

            M_1020_SELECT_HISTCONTABIL_DB_SELECT_1();

            /*" -952- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -955- MOVE '1900-01-01' TO DATA-QUITACAO. */
                _.Move("1900-01-01", DATA_QUITACAO);
            }


            /*" -966- PERFORM M_1020_SELECT_HISTCONTABIL_DB_SELECT_2 */

            M_1020_SELECT_HISTCONTABIL_DB_SELECT_2();

            /*" -969- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -970- MOVE '1900-01-01' TO DTVENCTO-PARCELA */
                _.Move("1900-01-01", DTVENCTO_PARCELA);

                /*" -970- MOVE ZEROS TO NUM-ENDOSSO. */
                _.Move(0, NUM_ENDOSSO);
            }


        }

        [StopWatch]
        /*" M-1020-SELECT-HISTCONTABIL-DB-SELECT-1 */
        public void M_1020_SELECT_HISTCONTABIL_DB_SELECT_1()
        {
            /*" -949- EXEC SQL SELECT VALUE(MAX(DTMOVTO),DATE( '1900-01-01' )) INTO :DATA-QUITACAO FROM SEGUROS.V0HISTCONTABILVA WHERE NRCERTIF = :NRCERTIF AND NRPARCEL = :NRPARCEL AND CODOPER BETWEEN 200 AND 299 WITH UR END-EXEC. */

            var m_1020_SELECT_HISTCONTABIL_DB_SELECT_1_Query1 = new M_1020_SELECT_HISTCONTABIL_DB_SELECT_1_Query1()
            {
                NRCERTIF = NRCERTIF.ToString(),
                NRPARCEL = NRPARCEL.ToString(),
            };

            var executed_1 = M_1020_SELECT_HISTCONTABIL_DB_SELECT_1_Query1.Execute(m_1020_SELECT_HISTCONTABIL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.DATA_QUITACAO, DATA_QUITACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1020_FIM*/

        [StopWatch]
        /*" M-1020-SELECT-HISTCONTABIL-DB-SELECT-2 */
        public void M_1020_SELECT_HISTCONTABIL_DB_SELECT_2()
        {
            /*" -966- EXEC SQL SELECT DATA_MOVIMENTO, NUM_ENDOSSO INTO :DTVENCTO-PARCELA, :NUM-ENDOSSO FROM SEGUROS.HIST_CONT_PARCELVA WHERE NUM_APOLICE = :NRAPOLICE AND NUM_CERTIFICADO = :NRCERTIF AND NUM_PARCELA = :NRPARCEL WITH UR END-EXEC. */

            var m_1020_SELECT_HISTCONTABIL_DB_SELECT_2_Query1 = new M_1020_SELECT_HISTCONTABIL_DB_SELECT_2_Query1()
            {
                NRAPOLICE = NRAPOLICE_CODSUBES.NRAPOLICE.ToString(),
                NRCERTIF = NRCERTIF.ToString(),
                NRPARCEL = NRPARCEL.ToString(),
            };

            var executed_1 = M_1020_SELECT_HISTCONTABIL_DB_SELECT_2_Query1.Execute(m_1020_SELECT_HISTCONTABIL_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.DTVENCTO_PARCELA, DTVENCTO_PARCELA);
                _.Move(executed_1.NUM_ENDOSSO, NUM_ENDOSSO);
            }


        }

        [StopWatch]
        /*" M-9000-FINALIZA */
        private void M_9000_FINALIZA(bool isPerform = false)
        {
            /*" -981- MOVE AC-REGISTROS TO FTRL-QTDREG. */
            _.Move(WORK_AREA.AC_REGISTROS, WREG_TRAILLER.FTRL_QTDREG);

            /*" -983- WRITE MOVIMENTO-RECORD FROM WREG-TRAILLER. */
            _.Move(WREG_TRAILLER.GetMoveValues(), MOVIMENTO_RECORD);

            MOVIMENTO.Write(MOVIMENTO_RECORD.GetMoveValues().ToString());

            /*" -984- DISPLAY '*' . */
            _.Display($"*");

            /*" -985- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -986- DISPLAY '*' . */
            _.Display($"*");

            /*" -987- DISPLAY '*  FN0303B ** PARCELAS GERADAS                  ' . */
            _.Display($"*  FN0303B ** PARCELAS GERADAS                  ");

            /*" -988- DISPLAY '*  FN0303B ** DATA       ' SIST-DTMOVABE. */
            _.Display($"*  FN0303B ** DATA       {SIST_DTMOVABE}");

            /*" -989- DISPLAY '*  FN0303B ** QUANTIDADE ' AC-REGISTROS. */
            _.Display($"*  FN0303B ** QUANTIDADE {WORK_AREA.AC_REGISTROS}");

            /*" -990- DISPLAY '*  FN0303B ** VALOR      ' AC-VALOR. */
            _.Display($"*  FN0303B ** VALOR      {WORK_AREA.AC_VALOR}");

            /*" -991- DISPLAY '*' . */
            _.Display($"*");

            /*" -991- DISPLAY '************************************************' . */
            _.Display($"************************************************");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9000_FIM*/

        [StopWatch]
        /*" M-9999-ERRO */
        private void M_9999_ERRO(bool isPerform = false)
        {
            /*" -1002- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WORK_AREA.WABEND.WSQLCODE);

            /*" -1003- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], WORK_AREA.WABEND.WSQLERRD1);

            /*" -1004- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], WORK_AREA.WABEND.WSQLERRD2);

            /*" -1005- DISPLAY WABEND. */
            _.Display(WORK_AREA.WABEND);

            /*" -1006- DISPLAY LOCALIZA-ABEND-1. */
            _.Display(WORK_AREA.LOCALIZA_ABEND_1);

            /*" -1008- DISPLAY LOCALIZA-ABEND-2. */
            _.Display(WORK_AREA.LOCALIZA_ABEND_2);

            /*" -1008- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1009- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1012- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1012- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}