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
using Sias.Outros.DB2.SPBVG011;

namespace Code
{
    public class SPBVG011
    {
        public bool IsCall { get; set; }

        public SPBVG011()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      * SISTEMA.........: SIAS                                         *      */
        /*"      * MODULO..........: VIDA                                         *      */
        /*"      * PROGRAMA........: SPBVG011                                     *      */
        /*"      * ANALISTA........: ELIERMES OLIVEIRA.                           *      */
        /*"      * DATA............: 17/02/2022                                   *      */
        /*"      * DEMANDA.........: 455132     TAREFA..........: 460644          *      */
        /*"      ******************************************************************      */
        /*"      * OBJETIVO........: REALIZAR CALCULO DE JUROS COM BASE NOS DADOS *      */
        /*"      *                   DE ENTRADA CONFORME CIRCULAR SUSEP 668       *      */
        /*"      *==> TIPO DE ACAO                                                *      */
        /*"      *    (01) CALCULAR O VALOR DE JUROS COM BASE NOS VALORES DE      *      */
        /*"      *                    ENTRADA                                     *      */
        /*"      *    (02) CALCULAR O VALOR DE MULTA COM BASE NOS VALORES DE      *      */
        /*"      *                    ENTRADA                                     *      */
        /*"      *    (03) CALCULAR O VALOR DE JUROS E MULTA COM BASE NOS VALORES *      */
        /*"      *                    DE ENTRADA                                  *      */
        /*"      ******************************************************************      */
        /*"      * VERSAO     DATA     RESPONSAVEL       ALTERACAO                *      */
        /*"      ******************************************************************      */
        /*"V.06  *  VERSAO 06  - INCIDENTE 575910                                 *      */
        /*"      *             - CORRECAO CALCULO DE DATA ANO BISSEXTO            *      */
        /*"      *                                                                *      */
        /*"      *  EM 06/03/2024 - CANETTA               PROCURE POR V.06        *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"V.05  *  VERSAO 05  - DEMANDA 482948                                   *      */
        /*"      *             - ALTERACAO NA REGRA PARA CALCULO VALOR A SE       *      */
        /*"      *               RESTITUICAO.                                     *      */
        /*"      *                                                                *      */
        /*"      *  EM 05/04/2023 - THIAGO BLAIER                                 *      */
        /*"      *                                        PROCURE POR V.05        *      */
        /*"      ******************************************************************      */
        /*"V.04  *  VERSAO 04  - DEMANDA 478584                                  *       */
        /*"      *             - CONSISTIR DATA DECLINIO                          *      */
        /*"      *                                                                *      */
        /*"      *  EM 05/04/2023 - TERCIO CARVALHO                               *      */
        /*"      *                                        PROCURE POR V.04        *      */
        /*"      ******************************************************************      */
        /*"V.03  *  VERSAO 03  - DEMANDA 478584                                  *       */
        /*"      *             - APLICAR JUROS PRORATA DIE                        *      */
        /*"      *                                                                *      */
        /*"      *  EM 17/03/2023 - TERCIO CARVALHO                               *      */
        /*"      *                                        PROCURE POR V.03        *      */
        /*"      ******************************************************************      */
        /*"V.02  *  VERSAO 02  - DEMANDA 402982                                   *      */
        /*"      *             - CORRIGIR CALCULO QUANDO DATA-FIM < DATA-INICIO   *      */
        /*"      *                                                                *      */
        /*"      *  EM 07/03/2023 - ELIERMES OLIVEIRA                             *      */
        /*"      *                                        PROCURE POR V.02        *      */
        /*"      ******************************************************************      */
        /*"      * V.001   12/01/2023  ELIERMES OLIVEIRA CRIACAO DO PROGRAMA      *      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis IXB5 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"01    WORK.*/
        public SPBVG011_WORK WORK { get; set; } = new SPBVG011_WORK();
        public class SPBVG011_WORK : VarBasis
        {
            /*"  05  WS-PROGRAMA                    PIC  X(008) VALUE SPACES.*/
            public StringBasis WS_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"  05  WS-DATA-MAIOR                  PIC  X(010) VALUE SPACES.*/
            public StringBasis WS_DATA_MAIOR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05  WS-DATA-MENOR                  PIC  X(010) VALUE SPACES.*/
            public StringBasis WS_DATA_MENOR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05  WS-QTD-DIAS                    PIC S9(009) COMP VALUE 0.*/
            public IntBasis WS_QTD_DIAS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05  WS-QTD-MESES                   PIC S9(009) COMP VALUE 0.*/
            public IntBasis WS_QTD_MESES { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05  WS-CONTADORES.*/
            public SPBVG011_WS_CONTADORES WS_CONTADORES { get; set; } = new SPBVG011_WS_CONTADORES();
            public class SPBVG011_WS_CONTADORES : VarBasis
            {
                /*"   10 WS-I                           PIC S9(004) COMP VALUE 0.*/
                public IntBasis WS_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"  05  WS-DATAS.*/
            }
            public SPBVG011_WS_DATAS WS_DATAS { get; set; } = new SPBVG011_WS_DATAS();
            public class SPBVG011_WS_DATAS : VarBasis
            {
                /*"   10 WS-C-DATE-CURRENT              PIC  X(014) VALUE SPACES.*/
                public StringBasis WS_C_DATE_CURRENT { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
                /*"   10 WS-C-DATE-COMPILED             PIC  X(014) VALUE SPACES.*/
                public StringBasis WS_C_DATE_COMPILED { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
                /*"  05  WS-EDIT.*/
            }
            public SPBVG011_WS_EDIT WS_EDIT { get; set; } = new SPBVG011_WS_EDIT();
            public class SPBVG011_WS_EDIT : VarBasis
            {
                /*"   10 WS-SMALLINT                    PIC ZZ.ZZ9- OCCURS 5 TIMES.*/
                public ListBasis<IntBasis, Int64> WS_SMALLINT { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "6", "ZZ.ZZ9-"), 5);
                /*"   10 WS-INTEGER                     PIC Z.ZZZ.ZZZ.ZZ9-                                                 OCCURS 5 TIMES.*/
                public ListBasis<IntBasis, Int64> WS_INTEGER { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "11", "Z.ZZZ.ZZZ.ZZ9-"), 5);
                /*"   10 WS-BIGINT                      PIC 99999999999999                                                 OCCURS 5 TIMES.*/
                public ListBasis<IntBasis, Int64> WS_BIGINT { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "14", "99999999999999"), 5);
                /*"   10 WS-DECIMAL                     PIC ZZZZZZZZZZ9,999999                                                 OCCURS 10 TIMES*/
                public ListBasis<DoubleBasis, double> WS_DECIMAL { get; set; } = new ListBasis<DoubleBasis, double>(new PIC("9", "11", "ZZZZZZZZZZ9V999999"), 10);
                /*"   10 WS-TAXA                        PIC 9,99999-                                                 OCCURS 5 TIMES.*/
                public ListBasis<DoubleBasis, double> WS_TAXA { get; set; } = new ListBasis<DoubleBasis, double>(new PIC("9", "1", "9V99999-"), 5);
                /*"  05  WS-ERRO.*/
            }
            public SPBVG011_WS_ERRO WS_ERRO { get; set; } = new SPBVG011_WS_ERRO();
            public class SPBVG011_WS_ERRO : VarBasis
            {
                /*"   10 WS-SECTION                     PIC  X(005) VALUE SPACES.*/
                public StringBasis WS_SECTION { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"   10 WS-SQLCODE                     PIC  ZZZZ9-.*/
                public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "6", "ZZZZ9-."));
                /*"   10 WS-SQLERRMC                    PIC  X(076) VALUE SPACES.*/
                public StringBasis WS_SQLERRMC { get; set; } = new StringBasis(new PIC("X", "76", "X(076)"), @"");
                /*"   10 WS-MENSAGEM                    PIC  X(255) VALUE SPACES.*/
                public StringBasis WS_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "255", "X(255)"), @"");
                /*"   10 WS-TABELA                      PIC  X(050) VALUE SPACES.*/
                public StringBasis WS_TABELA { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
                /*"   10 WS-IND-ERRO                    PIC  9(001) VALUE 0.*/
                public IntBasis WS_IND_ERRO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
                /*"  05  WS-OPC-PAGTO        PIC  X(001) VALUE 'S'.*/
            }
            public StringBasis WS_OPC_PAGTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"S");
            /*"  05  WULTDIA             PIC  9(002) VALUE 30.*/
            public IntBasis WULTDIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 30);
            /*"  05  WDIAS-AUX           PIC  9(004) VALUE ZEROES.*/
            public IntBasis WDIAS_AUX { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05  WDIAS-PRORATA       PIC  9(004) VALUE ZEROES.*/
            public IntBasis WDIAS_PRORATA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05  WDIAS-TOTAL         PIC  9(004) VALUE ZEROES.*/
            public IntBasis WDIAS_TOTAL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05  WINI-MES            PIC  9(002) VALUE ZEROES.*/
            public IntBasis WINI_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05  WSNOVO-DIAS         PIC  S9(009) COMP VALUE ZEROES.*/
            public IntBasis WSNOVO_DIAS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05 W0CODTSQLINI.*/
            public SPBVG011_W0CODTSQLINI W0CODTSQLINI { get; set; } = new SPBVG011_W0CODTSQLINI();
            public class SPBVG011_W0CODTSQLINI : VarBasis
            {
                /*"    10 WCOAASQLINI             PIC 9(004).*/
                public IntBasis WCOAASQLINI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10 WCOT1SQLINI             PIC X(001).*/
                public StringBasis WCOT1SQLINI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10 WCOMMSQLINI             PIC 9(002).*/
                public IntBasis WCOMMSQLINI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10 WCOT2SQLINI             PIC X(001).*/
                public StringBasis WCOT2SQLINI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10 WCODDSQLINI             PIC 9(002).*/
                public IntBasis WCODDSQLINI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05 W0CODTSQLFIM.*/
            }
            public SPBVG011_W0CODTSQLFIM W0CODTSQLFIM { get; set; } = new SPBVG011_W0CODTSQLFIM();
            public class SPBVG011_W0CODTSQLFIM : VarBasis
            {
                /*"    10 WCOAASQLFIM             PIC 9(004).*/
                public IntBasis WCOAASQLFIM { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10 WCOT1SQLFIM             PIC X(001).*/
                public StringBasis WCOT1SQLFIM { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10 WCOMMSQLFIM             PIC 9(002).*/
                public IntBasis WCOMMSQLFIM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10 WCOT2SQLFIM             PIC X(001).*/
                public StringBasis WCOT2SQLFIM { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10 WCODDSQLFIM             PIC 9(002).*/
                public IntBasis WCODDSQLFIM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05 W04DTSQL.*/
            }
            public SPBVG011_W04DTSQL W04DTSQL { get; set; } = new SPBVG011_W04DTSQL();
            public class SPBVG011_W04DTSQL : VarBasis
            {
                /*"    10 W04AASQL                PIC 9(004).*/
                public IntBasis W04AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10 W04T1SQL                PIC X(001).*/
                public StringBasis W04T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10 W04MMSQL                PIC 9(002).*/
                public IntBasis W04MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10 W04T2SQL                PIC X(001).*/
                public StringBasis W04T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10 W04DDSQL                PIC 9(002).*/
                public IntBasis W04DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05 WS-DATA-AUX               PIC X(010).*/
            }
            public StringBasis WS_DATA_AUX { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05 WHOST-DATA-CRED           PIC  X(10).*/
            public StringBasis WHOST_DATA_CRED { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"  05 PARM-PROSOMU1.*/
            public SPBVG011_PARM_PROSOMU1 PARM_PROSOMU1 { get; set; } = new SPBVG011_PARM_PROSOMU1();
            public class SPBVG011_PARM_PROSOMU1 : VarBasis
            {
                /*"     10 SU1-DATA1.*/
                public SPBVG011_SU1_DATA1 SU1_DATA1 { get; set; } = new SPBVG011_SU1_DATA1();
                public class SPBVG011_SU1_DATA1 : VarBasis
                {
                    /*"        15 SU1-DD1             PIC 99.*/
                    public IntBasis SU1_DD1 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"        15 SU1-MM1             PIC 99.*/
                    public IntBasis SU1_MM1 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"        15 SU1-AA1             PIC 9999.*/
                    public IntBasis SU1_AA1 { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
                    /*"     10 SU1-NRDIAS             PIC S9(5) COMP-3.*/
                }
                public IntBasis SU1_NRDIAS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(5)"));
                /*"     10 SU1-DATA2.*/
                public SPBVG011_SU1_DATA2 SU1_DATA2 { get; set; } = new SPBVG011_SU1_DATA2();
                public class SPBVG011_SU1_DATA2 : VarBasis
                {
                    /*"        15 SU1-DD2             PIC 99.*/
                    public IntBasis SU1_DD2 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"        15 SU1-MM2             PIC 99.*/
                    public IntBasis SU1_MM2 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"        15 SU1-AA2             PIC 9999.*/
                    public IntBasis SU1_AA2 { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
                    /*"  05 DATA-SQL.*/
                }
            }
            public SPBVG011_DATA_SQL DATA_SQL { get; set; } = new SPBVG011_DATA_SQL();
            public class SPBVG011_DATA_SQL : VarBasis
            {
                /*"     10 ANO-SQL                PIC  9(004).*/
                public IntBasis ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"     10 FILLER                 PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"     10 MES-SQL                PIC  9(002).*/
                public IntBasis MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"     10 FILLER                 PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"     10 DIA-SQL                PIC  9(002).*/
                public IntBasis DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05  WS-DT-SEARCH.*/
            }
            public SPBVG011_WS_DT_SEARCH WS_DT_SEARCH { get; set; } = new SPBVG011_WS_DT_SEARCH();
            public class SPBVG011_WS_DT_SEARCH : VarBasis
            {
                /*"     10 WS-MMAA-SEARCH.*/
                public SPBVG011_WS_MMAA_SEARCH WS_MMAA_SEARCH { get; set; } = new SPBVG011_WS_MMAA_SEARCH();
                public class SPBVG011_WS_MMAA_SEARCH : VarBasis
                {
                    /*"        15 WS-ANO-SEARCH       PIC  9(004).*/
                    public IntBasis WS_ANO_SEARCH { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"        15 WS-MES-SEARCH       PIC  9(002).*/
                    public IntBasis WS_MES_SEARCH { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"  05  WDATA-INI.*/
                }
            }
            public SPBVG011_WDATA_INI WDATA_INI { get; set; } = new SPBVG011_WDATA_INI();
            public class SPBVG011_WDATA_INI : VarBasis
            {
                /*"    10 WANO-INI                PIC  9(004) VALUE ZEROES.*/
                public IntBasis WANO_INI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10 FILLER                  PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10 WMES-INI                PIC  9(002) VALUE ZEROES.*/
                public IntBasis WMES_INI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10 FILLER                  PIC  X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10 WDIA-INI                PIC  9(002) VALUE ZEROES.*/
                public IntBasis WDIA_INI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05  WDATA-CONSULTA           PIC  X(010).*/
            }
            public StringBasis WDATA_CONSULTA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05  WDATA-REDEF REDEFINES WDATA-CONSULTA.*/
            private _REDEF_SPBVG011_WDATA_REDEF _wdata_redef { get; set; }
            public _REDEF_SPBVG011_WDATA_REDEF WDATA_REDEF
            {
                get { _wdata_redef = new _REDEF_SPBVG011_WDATA_REDEF(); _.Move(WDATA_CONSULTA, _wdata_redef); VarBasis.RedefinePassValue(WDATA_CONSULTA, _wdata_redef, WDATA_CONSULTA); _wdata_redef.ValueChanged += () => { _.Move(_wdata_redef, WDATA_CONSULTA); }; return _wdata_redef; }
                set { VarBasis.RedefinePassValue(value, _wdata_redef, WDATA_CONSULTA); }
            }  //Redefines
            public class _REDEF_SPBVG011_WDATA_REDEF : VarBasis
            {
                /*"    10 WANO-CONSULTA           PIC  9(004).*/
                public IntBasis WANO_CONSULTA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10 FILLER                  PIC  X(001).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10 WMES-CONSULTA           PIC  9(002).*/
                public IntBasis WMES_CONSULTA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10 FILLER                  PIC  X(001).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10 WDIA-CONSULTA           PIC  9(002).*/
                public IntBasis WDIA_CONSULTA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05  WANO-BISSEXTO            PIC  9(004) VALUE ZEROS.*/

                public _REDEF_SPBVG011_WDATA_REDEF()
                {
                    WANO_CONSULTA.ValueChanged += OnValueChanged;
                    FILLER_4.ValueChanged += OnValueChanged;
                    WMES_CONSULTA.ValueChanged += OnValueChanged;
                    FILLER_5.ValueChanged += OnValueChanged;
                    WDIA_CONSULTA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WANO_BISSEXTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05  IND1                     PIC  9(003) VALUE ZEROS.*/
            public IntBasis IND1 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  05  WS-QTD-COTACAO           PIC  9(003) VALUE ZEROS.*/
            public IntBasis WS_QTD_COTACAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  05  IND2                     PIC  9(003) VALUE ZEROS.*/
            public IntBasis IND2 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  05  IND4                     PIC  9(003) VALUE ZEROS.*/
            public IntBasis IND4 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  05  MOEDA                    PIC  9(003) VALUE ZEROS.*/
            public IntBasis MOEDA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  05  AA-ATU                   PIC  9(004) VALUE ZEROS.*/
            public IntBasis AA_ATU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05  AA-INI                   PIC  9(004) VALUE ZEROS.*/
            public IntBasis AA_INI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05  MM-INI                   PIC  9(004) VALUE ZEROS.*/
            public IntBasis MM_INI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05  AA-MOE                   PIC  9(004) VALUE ZEROS.*/
            public IntBasis AA_MOE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05  WS-IGPM-ACUM             PIC S9(6)V9(9) VALUE ZEROS                                           COMP-3.*/
            public DoubleBasis WS_IGPM_ACUM { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(6)V9(9)"), 9);
            /*"  05  WJUROS-PC-PRO            PIC S9(6)V9(9) VALUE ZEROS                                           COMP-3.*/
            public DoubleBasis WJUROS_PC_PRO { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(6)V9(9)"), 9);
            /*"  05  WS-VL-INDICE             PIC S9(6)V9(9) VALUE ZEROS                                           COMP-3.*/
            public DoubleBasis WS_VL_INDICE { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(6)V9(9)"), 9);
            /*"  05  IND-ACHOU                PIC  X(01) VALUE SPACE.*/
            public StringBasis IND_ACHOU { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"  05  WS-QTD-SEARCH            PIC  9(002) VALUE ZEROS.*/
            public IntBasis WS_QTD_SEARCH { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05  WMOEDA-ANT               PIC  9(004) VALUE ZEROS.*/
            public IntBasis WMOEDA_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05  WVAL-VENDA               PIC S9(006)V9(09) COMP-3.*/
            public DoubleBasis WVAL_VENDA { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(09)"), 9);
            /*"  05  WPRM-TOTAL               PIC S9(13)V99 VALUE ZEROS                                            COMP-3.*/
            public DoubleBasis WPRM_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05  WPRM-VG                  PIC S9(13)V99 VALUE ZEROS                                             COMP-3.*/
            public DoubleBasis WPRM_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05  WPRM-AP                  PIC S9(13)V99 VALUE ZEROS                                             COMP-3.*/
            public DoubleBasis WPRM_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05  WJUROS                   PIC S9(13)V99 VALUE ZEROS                                        COMP-3.*/
            public DoubleBasis WJUROS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05  WJUROS-VL-PRO            PIC S9(13)V99 VALUE ZEROS                                        COMP-3.*/
            public DoubleBasis WJUROS_VL_PRO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05  APOLICE-ATU              PIC  9(15) VALUE ZEROES.*/
            public IntBasis APOLICE_ATU { get; set; } = new IntBasis(new PIC("9", "15", "9(15)"));
            /*"  05  SUBGRUPO-ATU             PIC  9(04) VALUE ZEROES.*/
            public IntBasis SUBGRUPO_ATU { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
            /*"  05  APOLICE-ANT              PIC  9(15) VALUE ZEROES.*/
            public IntBasis APOLICE_ANT { get; set; } = new IntBasis(new PIC("9", "15", "9(15)"));
            /*"  05  SUBGRUPO-ANT             PIC  9(04) VALUE ZEROES.*/
            public IntBasis SUBGRUPO_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
            /*"  05  WS-RETORNO-SAP           PIC  X(01) VALUE SPACE.*/

            public SelectorBasis WS_RETORNO_SAP { get; set; } = new SelectorBasis("01", "SPACE")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88  WS-SIM-RETORNOU-SAP            VALUE 'S'. */
							new SelectorItemBasis("WS_SIM_RETORNOU_SAP", "S"),
							/*" 88  WS-NAO-RETORNOU-SAP            VALUE 'N'. */
							new SelectorItemBasis("WS_NAO_RETORNOU_SAP", "N")
                }
            };

            /*"  05      DATA-INI-ANT.*/
            public SPBVG011_DATA_INI_ANT DATA_INI_ANT { get; set; } = new SPBVG011_DATA_INI_ANT();
            public class SPBVG011_DATA_INI_ANT : VarBasis
            {
                /*"    10    ANO-INI-ANT          PIC  9(004).*/
                public IntBasis ANO_INI_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    FILLER               PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10    MES-INI-ANT          PIC  9(002).*/
                public IntBasis MES_INI_ANT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    FILLER               PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10    DIA-INI-ANT          PIC  9(002).*/
                public IntBasis DIA_INI_ANT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      DATA-INI-R  REDEFINES DATA-INI-ANT.*/
            }
            private _REDEF_SPBVG011_DATA_INI_R _data_ini_r { get; set; }
            public _REDEF_SPBVG011_DATA_INI_R DATA_INI_R
            {
                get { _data_ini_r = new _REDEF_SPBVG011_DATA_INI_R(); _.Move(DATA_INI_ANT, _data_ini_r); VarBasis.RedefinePassValue(DATA_INI_ANT, _data_ini_r, DATA_INI_ANT); _data_ini_r.ValueChanged += () => { _.Move(_data_ini_r, DATA_INI_ANT); }; return _data_ini_r; }
                set { VarBasis.RedefinePassValue(value, _data_ini_r, DATA_INI_ANT); }
            }  //Redefines
            public class _REDEF_SPBVG011_DATA_INI_R : VarBasis
            {
                /*"    10    AAMM-INI-ANT         PIC  X(007).*/
                public StringBasis AAMM_INI_ANT { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
                /*"    10    REST-INI-ANT         PIC  X(003).*/
                public StringBasis REST_INI_ANT { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"  05      DATA-DEC.*/

                public _REDEF_SPBVG011_DATA_INI_R()
                {
                    AAMM_INI_ANT.ValueChanged += OnValueChanged;
                    REST_INI_ANT.ValueChanged += OnValueChanged;
                }

            }
            public SPBVG011_DATA_DEC DATA_DEC { get; set; } = new SPBVG011_DATA_DEC();
            public class SPBVG011_DATA_DEC : VarBasis
            {
                /*"    10    ANO-DEC              PIC  9(004).*/
                public IntBasis ANO_DEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    FILLER               PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10    MES-DEC              PIC  9(002).*/
                public IntBasis MES_DEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    FILLER               PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10    DIA-DEC              PIC  9(002).*/
                public IntBasis DIA_DEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      DATA-INI-R  REDEFINES DATA-DEC.*/
            }
            private _REDEF_SPBVG011_DATA_INI_R_0 _data_ini_r_0 { get; set; }
            public _REDEF_SPBVG011_DATA_INI_R_0 DATA_INI_R_0
            {
                get { _data_ini_r_0 = new _REDEF_SPBVG011_DATA_INI_R_0(); _.Move(DATA_DEC, _data_ini_r_0); VarBasis.RedefinePassValue(DATA_DEC, _data_ini_r_0, DATA_DEC); _data_ini_r_0.ValueChanged += () => { _.Move(_data_ini_r_0, DATA_DEC); }; return _data_ini_r_0; }
                set { VarBasis.RedefinePassValue(value, _data_ini_r_0, DATA_DEC); }
            }  //Redefines
            public class _REDEF_SPBVG011_DATA_INI_R_0 : VarBasis
            {
                /*"    10    AAMM-DEC             PIC  X(007).*/
                public StringBasis AAMM_DEC { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
                /*"    10    REST-DEC             PIC  X(003).*/
                public StringBasis REST_DEC { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"  05      DATA-INI.*/

                public _REDEF_SPBVG011_DATA_INI_R_0()
                {
                    AAMM_DEC.ValueChanged += OnValueChanged;
                    REST_DEC.ValueChanged += OnValueChanged;
                }

            }
            public SPBVG011_DATA_INI DATA_INI { get; set; } = new SPBVG011_DATA_INI();
            public class SPBVG011_DATA_INI : VarBasis
            {
                /*"    10    ANO-INI              PIC  9(004).*/
                public IntBasis ANO_INI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    FILLER               PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10    MES-INI              PIC  9(002).*/
                public IntBasis MES_INI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    FILLER               PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10    DIA-INI              PIC  9(002).*/
                public IntBasis DIA_INI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      DATA-INI-R  REDEFINES DATA-INI.*/
            }
            private _REDEF_SPBVG011_DATA_INI_R_1 _data_ini_r_1 { get; set; }
            public _REDEF_SPBVG011_DATA_INI_R_1 DATA_INI_R_1
            {
                get { _data_ini_r_1 = new _REDEF_SPBVG011_DATA_INI_R_1(); _.Move(DATA_INI, _data_ini_r_1); VarBasis.RedefinePassValue(DATA_INI, _data_ini_r_1, DATA_INI); _data_ini_r_1.ValueChanged += () => { _.Move(_data_ini_r_1, DATA_INI); }; return _data_ini_r_1; }
                set { VarBasis.RedefinePassValue(value, _data_ini_r_1, DATA_INI); }
            }  //Redefines
            public class _REDEF_SPBVG011_DATA_INI_R_1 : VarBasis
            {
                /*"    10    AAMM-INI             PIC  X(007).*/
                public StringBasis AAMM_INI { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
                /*"    10    REST-INI             PIC  X(003).*/
                public StringBasis REST_INI { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"  05      DATA-FIM.*/

                public _REDEF_SPBVG011_DATA_INI_R_1()
                {
                    AAMM_INI.ValueChanged += OnValueChanged;
                    REST_INI.ValueChanged += OnValueChanged;
                }

            }
            public SPBVG011_DATA_FIM DATA_FIM { get; set; } = new SPBVG011_DATA_FIM();
            public class SPBVG011_DATA_FIM : VarBasis
            {
                /*"    10    ANO-FIM              PIC  9(004).*/
                public IntBasis ANO_FIM { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    FILLER               PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10    MES-FIM              PIC  9(002).*/
                public IntBasis MES_FIM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    FILLER               PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10    DIA-FIM              PIC  9(002).*/
                public IntBasis DIA_FIM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      DATA-FIM-R  REDEFINES DATA-FIM.*/
            }
            private _REDEF_SPBVG011_DATA_FIM_R _data_fim_r { get; set; }
            public _REDEF_SPBVG011_DATA_FIM_R DATA_FIM_R
            {
                get { _data_fim_r = new _REDEF_SPBVG011_DATA_FIM_R(); _.Move(DATA_FIM, _data_fim_r); VarBasis.RedefinePassValue(DATA_FIM, _data_fim_r, DATA_FIM); _data_fim_r.ValueChanged += () => { _.Move(_data_fim_r, DATA_FIM); }; return _data_fim_r; }
                set { VarBasis.RedefinePassValue(value, _data_fim_r, DATA_FIM); }
            }  //Redefines
            public class _REDEF_SPBVG011_DATA_FIM_R : VarBasis
            {
                /*"    10    AAMM-FIM             PIC  X(007).*/
                public StringBasis AAMM_FIM { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
                /*"    10    REST-FIM             PIC  X(003).*/
                public StringBasis REST_FIM { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"  05 TABELA-IGPM          OCCURS 500 TIMES                         INDEXED BY  IXB5.*/

                public _REDEF_SPBVG011_DATA_FIM_R()
                {
                    AAMM_FIM.ValueChanged += OnValueChanged;
                    REST_FIM.ValueChanged += OnValueChanged;
                }

            }
            public ListBasis<SPBVG011_TABELA_IGPM> TABELA_IGPM { get; set; } = new ListBasis<SPBVG011_TABELA_IGPM>(500);
            public class SPBVG011_TABELA_IGPM : VarBasis
            {
                /*"    10 TB-DATA-IGPM          PIC  9(006).*/
                public IntBasis TB_DATA_IGPM { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10 TB-DATA-IGPM-R REDEFINES TB-DATA-IGPM.*/
                private _REDEF_SPBVG011_TB_DATA_IGPM_R _tb_data_igpm_r { get; set; }
                public _REDEF_SPBVG011_TB_DATA_IGPM_R TB_DATA_IGPM_R
                {
                    get { _tb_data_igpm_r = new _REDEF_SPBVG011_TB_DATA_IGPM_R(); _.Move(TB_DATA_IGPM, _tb_data_igpm_r); VarBasis.RedefinePassValue(TB_DATA_IGPM, _tb_data_igpm_r, TB_DATA_IGPM); _tb_data_igpm_r.ValueChanged += () => { _.Move(_tb_data_igpm_r, TB_DATA_IGPM); }; return _tb_data_igpm_r; }
                    set { VarBasis.RedefinePassValue(value, _tb_data_igpm_r, TB_DATA_IGPM); }
                }  //Redefines
                public class _REDEF_SPBVG011_TB_DATA_IGPM_R : VarBasis
                {
                    /*"       15 TB-ANO-IGPM        PIC  9(004).*/
                    public IntBasis TB_ANO_IGPM { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"       15 TB-MES-IGPM        PIC  9(002).*/
                    public IntBasis TB_MES_IGPM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    10 TB-VAL-IGPM           PIC S9(006)V9(9)  COMP-3.*/

                    public _REDEF_SPBVG011_TB_DATA_IGPM_R()
                    {
                        TB_ANO_IGPM.ValueChanged += OnValueChanged;
                        TB_MES_IGPM.ValueChanged += OnValueChanged;
                    }

                }
                public DoubleBasis TB_VAL_IGPM { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
                /*"01  DT-INI                    PIC X(10).*/
            }
        }
        public StringBasis DT_INI { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  DT-FIM                    PIC X(10).*/
        public StringBasis DT_FIM { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  WSXB5                     PIC 9(03).*/
        public IntBasis WSXB5 { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
        /*"01  TABELA-ULTIMOS-DIAS.*/
        public SPBVG011_TABELA_ULTIMOS_DIAS TABELA_ULTIMOS_DIAS { get; set; } = new SPBVG011_TABELA_ULTIMOS_DIAS();
        public class SPBVG011_TABELA_ULTIMOS_DIAS : VarBasis
        {
            /*"  10 FILLER                          PIC  X(024)                                VALUE '312831303130313130313031'*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"312831303130313130313031");
            /*"01 TB-ULTIMOS-DIAS    REDEFINES            TABELA-ULTIMOS-DIAS.*/
        }
        private _REDEF_SPBVG011_TB_ULTIMOS_DIAS _tb_ultimos_dias { get; set; }
        public _REDEF_SPBVG011_TB_ULTIMOS_DIAS TB_ULTIMOS_DIAS
        {
            get { _tb_ultimos_dias = new _REDEF_SPBVG011_TB_ULTIMOS_DIAS(); _.Move(TABELA_ULTIMOS_DIAS, _tb_ultimos_dias); VarBasis.RedefinePassValue(TABELA_ULTIMOS_DIAS, _tb_ultimos_dias, TABELA_ULTIMOS_DIAS); _tb_ultimos_dias.ValueChanged += () => { _.Move(_tb_ultimos_dias, TABELA_ULTIMOS_DIAS); }; return _tb_ultimos_dias; }
            set { VarBasis.RedefinePassValue(value, _tb_ultimos_dias, TABELA_ULTIMOS_DIAS); }
        }  //Redefines
        public class _REDEF_SPBVG011_TB_ULTIMOS_DIAS : VarBasis
        {
            /*"  10  TB-DIA-MESES        OCCURS 12.*/
            public ListBasis<SPBVG011_TB_DIA_MESES> TB_DIA_MESES { get; set; } = new ListBasis<SPBVG011_TB_DIA_MESES>(12);
            public class SPBVG011_TB_DIA_MESES : VarBasis
            {
                /*"    15 TB-ULT-DIA              PIC 9(002).*/
                public IntBasis TB_ULT_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));

                public SPBVG011_TB_DIA_MESES()
                {
                    TB_ULT_DIA.ValueChanged += OnValueChanged;
                }

            }

            public _REDEF_SPBVG011_TB_ULTIMOS_DIAS()
            {
                TB_DIA_MESES.ValueChanged += OnValueChanged;
            }

        }


        public Copies.SPVG011W SPVG011W { get; set; } = new Copies.SPVG011W();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.MOEDACOT MOEDACOT { get; set; } = new Dclgens.MOEDACOT();
        public Dclgens.VG077 VG077 { get; set; } = new Dclgens.VG077();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.GE252 GE252 { get; set; } = new Dclgens.GE252();

        public SPBVG011_TCOTAC TCOTAC { get; set; } = new SPBVG011_TCOTAC(true);
        string GetQuery_TCOTAC()
        {
            var query = @$"SELECT DATA_INIVIGENCIA
							, VAL_VENDA
							FROM SEGUROS.MOEDAS_COTACAO WHERE COD_MOEDA = '{MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_COD_MOEDA}' AND DATA_INIVIGENCIA >= '{WORK.WDATA_CONSULTA}' ORDER BY DATA_INIVIGENCIA";

            return query;
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(SPVG011W SPVG011W_P) //PROCEDURE DIVISION USING 
        /*PROCEDURE DIVISION
        LK_VG011_E_TRACE
        LK_VG011_E_COD_USUARIO
        LK_VG011_E_NOM_PROGRAMA
        LK_VG011_E_TIPO_ACAO
        LK_VG011_E_COD_PRODUTO
        LK_VG011_E_DTA_INI_CALCULO
        LK_VG011_E_DTA_FIM_CALCULO
        LK_VG011_E_DTA_DECLINIO
        LK_VG011_E_VL_ORIGINAL
        LK_VG011_E_NUM_APOLICE
        LK_VG011_E_COD_SUBGRUPO
        LK_VG011_E_QTD_DIA_PGMNTO
        LK_VG011_S_COD_MOEDA
        LK_VG011_S_PC_INDICE
        LK_VG011_S_VL_JUROS
        LK_VG011_S_VL_MULTA
        LK_VG011_S_VL_CORRIGIDO
        LK_VG011_S_DTA_FIM_PGMNTO
        LK_VG011_IND_ERRO
        LK_VG011_MSG_ERRO
        LK_VG011_NOM_TABELA
        LK_VG011_SQLCODE
        LK_VG011_SQLERRMC*/
        {
            try
            {
                this.SPVG011W = SPVG011W_P;
                InitializeGetQuery();

                /*" -0- FLUXCONTROL_PERFORM P0000-INICIALIZAR-SECTION */

                P0000_INICIALIZAR_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { SPVG011W };
            return Result;
        }

        public void InitializeGetQuery()
        {
            TCOTAC.GetQueryEvent += GetQuery_TCOTAC;
        }

        [StopWatch]
        /*" P0000-INICIALIZAR-SECTION */
        private void P0000_INICIALIZAR_SECTION()
        {
            /*" -372- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -373- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -374- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -377- MOVE FUNCTION CURRENT-DATE(1:14) TO WS-C-DATE-CURRENT. */
            _.Move(_.CurrentDate(0, 14), WORK.WS_DATAS.WS_C_DATE_CURRENT);

            /*" -379- MOVE FUNCTION WHEN-COMPILED TO WS-C-DATE-COMPILED. */
            _.Move(_.WhenCompiled(), WORK.WS_DATAS.WS_C_DATE_COMPILED);

            /*" -386- INITIALIZE LK-VG011-IND-ERRO LK-VG011-MSG-ERRO LK-VG011-NOM-TABELA LK-VG011-SQLCODE LK-VG011-SQLERRMC WS-ERRO LK-VG011-S-COD-MOEDA LK-VG011-S-PC-INDICE LK-VG011-S-VL-MULTA LK-VG011-S-VL-JUROS LK-VG011-S-VL-CORRIGIDO */
            _.Initialize(
                SPVG011W.LK_VG011_IND_ERRO
                , SPVG011W.LK_VG011_MSG_ERRO
                , SPVG011W.LK_VG011_NOM_TABELA
                , SPVG011W.LK_VG011_SQLCODE
                , SPVG011W.LK_VG011_SQLERRMC
                , WORK.WS_ERRO
                , SPVG011W.LK_VG011_S_COD_MOEDA
                , SPVG011W.LK_VG011_S_PC_INDICE
                , SPVG011W.LK_VG011_S_VL_MULTA
                , SPVG011W.LK_VG011_S_VL_JUROS
                , SPVG011W.LK_VG011_S_VL_CORRIGIDO
            );

            /*" -389- MOVE '0001-01-01' TO LK-VG011-S-DTA-FIM-PGMNTO DATA-INI-ANT */
            _.Move("0001-01-01", SPVG011W.LK_VG011_S_DTA_FIM_PGMNTO, WORK.DATA_INI_ANT);

            /*" -390- IF NOT ( LK-VG011-E-TRACE = 'S' OR = 'N' ) */

            if (!(SPVG011W.LK_VG011_E_TRACE.In("S", "N")))
            {

                /*" -391- MOVE 'N' TO LK-VG011-E-TRACE */
                _.Move("N", SPVG011W.LK_VG011_E_TRACE);

                /*" -393- END-IF */
            }


            /*" -395- PERFORM P0050-VERIFICAR-SISTEMA */

            P0050_VERIFICAR_SISTEMA_SECTION();

            /*" -396- IF LK-VG011-E-TRACE = 'S' */

            if (SPVG011W.LK_VG011_E_TRACE == "S")
            {

                /*" -397- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -398- DISPLAY '*            S P B V G 0 1 1                 *' */
                _.Display($"*            S P B V G 0 1 1                 *");

                /*" -399- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -406- DISPLAY '* DATA COMPILACAO..: ' WS-C-DATE-COMPILED(7:2) '/' WS-C-DATE-COMPILED(5:2) '/' WS-C-DATE-COMPILED(1:4) '-' WS-C-DATE-COMPILED(9:2) ':' WS-C-DATE-COMPILED(11:2) ':' WS-C-DATE-COMPILED(13:2) */

                $"* DATA COMPILACAO..: {WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(7, 2)}/{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(5, 2)}/{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(1, 4)}-{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(9, 2)}:{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(11, 2)}:{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(13, 2)}"
                .Display();

                /*" -413- DISPLAY '* DATA EXECUCAO....: ' WS-C-DATE-CURRENT(7:2) '/' WS-C-DATE-CURRENT(5:2) '/' WS-C-DATE-CURRENT(1:4) '-' WS-C-DATE-CURRENT(9:2) ':' WS-C-DATE-CURRENT(11:2) ':' WS-C-DATE-CURRENT(13:2) */

                $"* DATA EXECUCAO....: {WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(7, 2)}/{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(5, 2)}/{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(1, 4)}-{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(9, 2)}:{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(11, 2)}:{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(13, 2)}"
                .Display();

                /*" -418- DISPLAY '* DATA SISTEMA.....: ' SISTEMAS-DATA-MOV-ABERTO(9:2) '/' SISTEMAS-DATA-MOV-ABERTO(6:2) '/' SISTEMAS-DATA-MOV-ABERTO(1:4) */

                $"* DATA SISTEMA.....: {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2)}/{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2)}/{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4)}"
                .Display();

                /*" -419- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -420- DISPLAY '*             DADOS DE ENTRADA               *' */
                _.Display($"*             DADOS DE ENTRADA               *");

                /*" -421- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -422- DISPLAY '* TRACE............: ' LK-VG011-E-TRACE */
                _.Display($"* TRACE............: {SPVG011W.LK_VG011_E_TRACE}");

                /*" -423- DISPLAY '* COD-USUARIO......: ' LK-VG011-E-COD-USUARIO */
                _.Display($"* COD-USUARIO......: {SPVG011W.LK_VG011_E_COD_USUARIO}");

                /*" -424- DISPLAY '* NOM-PROGRAMA.....: ' LK-VG011-E-NOM-PROGRAMA */
                _.Display($"* NOM-PROGRAMA.....: {SPVG011W.LK_VG011_E_NOM_PROGRAMA}");

                /*" -425- MOVE LK-VG011-E-TIPO-ACAO TO WS-SMALLINT(01) */
                _.Move(SPVG011W.LK_VG011_E_TIPO_ACAO, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -426- DISPLAY '* TIPO-ACAO........: ' WS-SMALLINT(01) */
                _.Display($"* TIPO-ACAO........: {WORK.WS_EDIT.WS_SMALLINT[1]}");

                /*" -427- MOVE LK-VG011-E-COD-PRODUTO TO WS-SMALLINT(02) */
                _.Move(SPVG011W.LK_VG011_E_COD_PRODUTO, WORK.WS_EDIT.WS_SMALLINT[02]);

                /*" -428- DISPLAY '* COD-PRODUTO......: ' WS-SMALLINT(02) */
                _.Display($"* COD-PRODUTO......: {WORK.WS_EDIT.WS_SMALLINT[2]}");

                /*" -429- DISPLAY '* DTA-INI-CALCULO..: ' LK-VG011-E-DTA-INI-CALCULO */
                _.Display($"* DTA-INI-CALCULO..: {SPVG011W.LK_VG011_E_DTA_INI_CALCULO}");

                /*" -430- DISPLAY '* DTA-FIM-CALCULO..: ' LK-VG011-E-DTA-FIM-CALCULO */
                _.Display($"* DTA-FIM-CALCULO..: {SPVG011W.LK_VG011_E_DTA_FIM_CALCULO}");

                /*" -431- DISPLAY '* DTA-DECLINIO ....: ' LK-VG011-E-DTA-DECLINIO */
                _.Display($"* DTA-DECLINIO ....: {SPVG011W.LK_VG011_E_DTA_DECLINIO}");

                /*" -432- MOVE LK-VG011-E-NUM-APOLICE TO WS-BIGINT (01) */
                _.Move(SPVG011W.LK_VG011_E_NUM_APOLICE, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -433- DISPLAY '* NUM-APOLICE......: ' WS-BIGINT (01) */
                _.Display($"* NUM-APOLICE......: {WORK.WS_EDIT.WS_BIGINT[1]}");

                /*" -434- MOVE LK-VG011-E-COD-SUBGRUPO TO WS-SMALLINT(03) */
                _.Move(SPVG011W.LK_VG011_E_COD_SUBGRUPO, WORK.WS_EDIT.WS_SMALLINT[03]);

                /*" -435- DISPLAY '* COD-SUBGRUPO.....: ' WS-SMALLINT(03) */
                _.Display($"* COD-SUBGRUPO.....: {WORK.WS_EDIT.WS_SMALLINT[3]}");

                /*" -436- MOVE LK-VG011-E-VL-ORIGINAL TO WS-DECIMAL (01) */
                _.Move(SPVG011W.LK_VG011_E_VL_ORIGINAL, WORK.WS_EDIT.WS_DECIMAL[01]);

                /*" -437- DISPLAY '* VL-ORIGINAL......: ' WS-DECIMAL (01) */
                _.Display($"* VL-ORIGINAL......: {WORK.WS_EDIT.WS_DECIMAL[1]}");

                /*" -438- MOVE LK-VG011-E-QTD-DIA-PGMNTO TO WS-SMALLINT(04) */
                _.Move(SPVG011W.LK_VG011_E_QTD_DIA_PGMNTO, WORK.WS_EDIT.WS_SMALLINT[04]);

                /*" -439- DISPLAY '* QTD-DIA-PGMNTO...: ' WS-SMALLINT(04) */
                _.Display($"* QTD-DIA-PGMNTO...: {WORK.WS_EDIT.WS_SMALLINT[4]}");

                /*" -440- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -442- END-IF */
            }


            /*" -442- PERFORM P0005-PROCESSAR. */

            P0005_PROCESSAR_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0000_99_EXIT*/

        [StopWatch]
        /*" P0005-PROCESSAR-SECTION */
        private void P0005_PROCESSAR_SECTION()
        {
            /*" -453- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0005_00_START */

            P0005_00_START();

        }

        [StopWatch]
        /*" P0005-00-START */
        private void P0005_00_START(bool isPerform = false)
        {
            /*" -455- MOVE 'P0005' TO WS-SECTION. */
            _.Move("P0005", WORK.WS_ERRO.WS_SECTION);

            /*" -455- PERFORM P0005-05-INICIO. */

            P0005_05_INICIO(true);

        }

        [StopWatch]
        /*" P0005-05-INICIO */
        private void P0005_05_INICIO(bool isPerform = false)
        {
            /*" -461- PERFORM P0100-VALIDAR-LINKAGE. */

            P0100_VALIDAR_LINKAGE_SECTION();

            /*" -462-  EVALUATE TRUE  */

            /*" -463-  WHEN LK-VG011-E-TIPO-ACAO     = 01  */

            /*" -463- IF LK-VG011-E-TIPO-ACAO     = 01 */

            if (SPVG011W.LK_VG011_E_TIPO_ACAO == 01)
            {

                /*" -464-  WHEN LK-VG011-E-TIPO-ACAO     = 02  */

                /*" -464- ELSE IF LK-VG011-E-TIPO-ACAO     = 02 */
            }
            else

            if (SPVG011W.LK_VG011_E_TIPO_ACAO == 02)
            {

                /*" -466-  WHEN LK-VG011-E-TIPO-ACAO     = 03  */

                /*" -466- ELSE IF LK-VG011-E-TIPO-ACAO     = 03 */
            }
            else

            if (SPVG011W.LK_VG011_E_TIPO_ACAO == 03)
            {

                /*" -467- PERFORM P0302-TRATAR-TIPO-ACAO-01 */

                P0302_TRATAR_TIPO_ACAO_01_SECTION();

                /*" -468-  WHEN OTHER  */

                /*" -468- ELSE */
            }
            else
            {


                /*" -469- MOVE 'P0005' TO WS-SECTION */
                _.Move("P0005", WORK.WS_ERRO.WS_SECTION);

                /*" -470- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -471- MOVE LK-VG011-E-TIPO-ACAO TO WS-SMALLINT(01) */
                _.Move(SPVG011W.LK_VG011_E_TIPO_ACAO, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -475- STRING WS-SECTION ' - TIPO DE ACAO INFORMADA INVALIDA.' '<TIPO_ACAO=' WS-SMALLINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl1 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl1 += " - TIPO DE ACAO INFORMADA INVALIDA.";
                spl1 += "<TIPO_ACAO=";
                var spl2 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl2 += ">";
                var results3 = spl1 + spl2;
                _.Move(results3, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -476- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -477- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -478- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -480-  END-EVALUATE  */

                /*" -480- END-IF */
            }


            /*" -480- PERFORM P0010-FINALIZAR. */

            P0010_FINALIZAR_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0005_99_EXIT*/

        [StopWatch]
        /*" P0010-FINALIZAR-SECTION */
        private void P0010_FINALIZAR_SECTION()
        {
            /*" -491- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0010_00_START */

            P0010_00_START();

        }

        [StopWatch]
        /*" P0010-00-START */
        private void P0010_00_START(bool isPerform = false)
        {
            /*" -493- MOVE 'P0010' TO WS-SECTION. */
            _.Move("P0010", WORK.WS_ERRO.WS_SECTION);

            /*" -493- PERFORM P0010-05-INICIO. */

            P0010_05_INICIO(true);

        }

        [StopWatch]
        /*" P0010-05-INICIO */
        private void P0010_05_INICIO(bool isPerform = false)
        {
            /*" -498- MOVE 0 TO WS-IND-ERRO */
            _.Move(0, WORK.WS_ERRO.WS_IND_ERRO);

            /*" -500- STRING 'OPERACAO SOLICITADA REALIZADA COM SUCESSO.' DELIMITED BY SIZE INTO WS-MENSAGEM */
            #region STRING
            var spl3 = "OPERACAO SOLICITADA REALIZADA COM SUCESSO.";
            _.Move(spl3, WORK.WS_ERRO.WS_MENSAGEM);
            #endregion

            /*" -501- MOVE WS-MENSAGEM TO LK-VG011-MSG-ERRO */
            _.Move(WORK.WS_ERRO.WS_MENSAGEM, SPVG011W.LK_VG011_MSG_ERRO);

            /*" -502- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
            _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

            /*" -504- MOVE 0 TO WS-SQLCODE */
            _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

            /*" -504- PERFORM P0010-99-EXIT. */

            P0010_99_EXIT(true);

        }

        [StopWatch]
        /*" P0010-99-EXIT */
        private void P0010_99_EXIT(bool isPerform = false)
        {
            /*" -507- GOBACK. */

            throw new GoBack();

        }

        [StopWatch]
        /*" P0050-VERIFICAR-SISTEMA-SECTION */
        private void P0050_VERIFICAR_SISTEMA_SECTION()
        {
            /*" -515- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0050_00_START */

            P0050_00_START();

        }

        [StopWatch]
        /*" P0050-00-START */
        private void P0050_00_START(bool isPerform = false)
        {
            /*" -518- MOVE 'P0050' TO WS-SECTION. */
            _.Move("P0050", WORK.WS_ERRO.WS_SECTION);

            /*" -518- PERFORM P0050-05-INICIO. */

            P0050_05_INICIO(true);

        }

        [StopWatch]
        /*" P0050-05-INICIO */
        private void P0050_05_INICIO(bool isPerform = false)
        {
            /*" -528- PERFORM P0050_05_INICIO_DB_SELECT_1 */

            P0050_05_INICIO_DB_SELECT_1();

            /*" -531- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -532- MOVE 'P0050' TO WS-SECTION */
                _.Move("P0050", WORK.WS_ERRO.WS_SECTION);

                /*" -533- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -537- STRING WS-SECTION ' - ERRO NO SELECT NA SEGUROS.SISTEMA.' '<SISTEMA=VG>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl4 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl4 += " - ERRO NO SELECT NA SEGUROS.SISTEMA.";
                spl4 += "<SISTEMA=VG>";
                _.Move(spl4, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -538- MOVE 'SEGUROS.SISTEMA' TO WS-TABELA */
                _.Move("SEGUROS.SISTEMA", WORK.WS_ERRO.WS_TABELA);

                /*" -539- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -540- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -541- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -543- END-IF */
            }


            /*" -544- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -545- MOVE 'P0050' TO WS-SECTION */
                _.Move("P0050", WORK.WS_ERRO.WS_SECTION);

                /*" -546- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -550- STRING WS-SECTION ' - REGISTRO DE CONTROLE SISTEMA NAO CADASTRADO.' '<SISTEMA=VG>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl5 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl5 += " - REGISTRO DE CONTROLE SISTEMA NAO CADASTRADO.";
                spl5 += "<SISTEMA=VG>";
                _.Move(spl5, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -551- MOVE 'SEGUROS.SISTEMA' TO WS-TABELA */
                _.Move("SEGUROS.SISTEMA", WORK.WS_ERRO.WS_TABELA);

                /*" -552- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -553- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -554- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -554- END-IF. */
            }


        }

        [StopWatch]
        /*" P0050-05-INICIO-DB-SELECT-1 */
        public void P0050_05_INICIO_DB_SELECT_1()
        {
            /*" -528- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VG' WITH UR END-EXEC. */

            var p0050_05_INICIO_DB_SELECT_1_Query1 = new P0050_05_INICIO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = P0050_05_INICIO_DB_SELECT_1_Query1.Execute(p0050_05_INICIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0050_EXIT*/

        [StopWatch]
        /*" P0100-VALIDAR-LINKAGE-SECTION */
        private void P0100_VALIDAR_LINKAGE_SECTION()
        {
            /*" -565- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0100_00_START */

            P0100_00_START();

        }

        [StopWatch]
        /*" P0100-00-START */
        private void P0100_00_START(bool isPerform = false)
        {
            /*" -567- MOVE 'P0100' TO WS-SECTION. */
            _.Move("P0100", WORK.WS_ERRO.WS_SECTION);

            /*" -567- PERFORM P0100-05-INICIO. */

            P0100_05_INICIO(true);

        }

        [StopWatch]
        /*" P0100-05-INICIO */
        private void P0100_05_INICIO(bool isPerform = false)
        {
            /*" -572- IF LK-VG011-E-COD-USUARIO = SPACES */

            if (SPVG011W.LK_VG011_E_COD_USUARIO.IsEmpty())
            {

                /*" -573- MOVE 'P0100' TO WS-SECTION */
                _.Move("P0100", WORK.WS_ERRO.WS_SECTION);

                /*" -574- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -578- STRING WS-SECTION ' - CODIGO DO USUARIO NAO INFORMADO.' '<COD_USUARIO=' LK-VG011-E-COD-USUARIO '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl6 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl6 += " - CODIGO DO USUARIO NAO INFORMADO.";
                spl6 += "<COD_USUARIO=";
                var spl7 = SPVG011W.LK_VG011_E_COD_USUARIO.GetMoveValues();
                spl7 += ">";
                var results8 = spl6 + spl7;
                _.Move(results8, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -579- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -580- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -581- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -583- END-IF */
            }


            /*" -584- IF LK-VG011-E-NOM-PROGRAMA = SPACES */

            if (SPVG011W.LK_VG011_E_NOM_PROGRAMA.IsEmpty())
            {

                /*" -585- MOVE 'P0100' TO WS-SECTION */
                _.Move("P0100", WORK.WS_ERRO.WS_SECTION);

                /*" -586- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -590- STRING WS-SECTION ' - NOME DO PROGRAMA NAO INFORMADO.' '<NOM_PROGRAMA=' LK-VG011-E-NOM-PROGRAMA '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl8 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl8 += " - NOME DO PROGRAMA NAO INFORMADO.";
                spl8 += "<NOM_PROGRAMA=";
                var spl9 = SPVG011W.LK_VG011_E_NOM_PROGRAMA.GetMoveValues();
                spl9 += ">";
                var results10 = spl8 + spl9;
                _.Move(results10, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -591- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -592- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -593- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -595- END-IF */
            }


            /*" -596- IF LK-VG011-E-TIPO-ACAO NOT EQUAL 01 AND 02 AND 03 */

            if (!SPVG011W.LK_VG011_E_TIPO_ACAO.In("01", "02", "03"))
            {

                /*" -597- MOVE 'P0100' TO WS-SECTION */
                _.Move("P0100", WORK.WS_ERRO.WS_SECTION);

                /*" -598- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -599- MOVE LK-VG011-E-TIPO-ACAO TO WS-SMALLINT(01) */
                _.Move(SPVG011W.LK_VG011_E_TIPO_ACAO, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -603- STRING WS-SECTION ' - TIPO DE ACAO INFORMADA INVALIDA.' '<TIPO_ACAO=' WS-SMALLINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl10 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl10 += " - TIPO DE ACAO INFORMADA INVALIDA.";
                spl10 += "<TIPO_ACAO=";
                var spl11 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl11 += ">";
                var results12 = spl10 + spl11;
                _.Move(results12, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -604- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -605- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -606- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -607- ELSE */
            }
            else
            {


                /*" -608- MOVE 1 TO LK-VG011-E-TIPO-ACAO */
                _.Move(1, SPVG011W.LK_VG011_E_TIPO_ACAO);

                /*" -610- END-IF */
            }


            /*" -612- IF LK-VG011-E-COD-PRODUTO EQUAL ZEROS AND LK-VG011-E-NUM-APOLICE EQUAL ZEROS */

            if (SPVG011W.LK_VG011_E_COD_PRODUTO == 00 && SPVG011W.LK_VG011_E_NUM_APOLICE == 00)
            {

                /*" -613- MOVE 'P0100' TO WS-SECTION */
                _.Move("P0100", WORK.WS_ERRO.WS_SECTION);

                /*" -614- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -615- MOVE LK-VG011-E-COD-PRODUTO TO WS-INTEGER (01) */
                _.Move(SPVG011W.LK_VG011_E_COD_PRODUTO, WORK.WS_EDIT.WS_INTEGER[01]);

                /*" -616- MOVE LK-VG011-E-NUM-APOLICE TO WS-INTEGER (02) */
                _.Move(SPVG011W.LK_VG011_E_NUM_APOLICE, WORK.WS_EDIT.WS_INTEGER[02]);

                /*" -622- STRING WS-SECTION ' - COD PRODUTO E APOLICE NAO INFORMADO.' '<COD_PRODUTO=' WS-INTEGER (01) '<COD_APOLICE=' WS-INTEGER (02) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl12 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl12 += " - COD PRODUTO E APOLICE NAO INFORMADO.";
                spl12 += "<COD_PRODUTO=";
                var spl13 = WORK.WS_EDIT.WS_INTEGER[01].GetMoveValues();
                spl13 += "<COD_APOLICE=";
                var spl14 = WORK.WS_EDIT.WS_INTEGER[02].GetMoveValues();
                spl14 += ">";
                var results15 = spl12 + spl13 + spl14;
                _.Move(results15, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -623- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -624- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -625- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -627- END-IF */
            }


            /*" -628- IF LK-VG011-E-DTA-INI-CALCULO NOT EQUAL '0001-01-01' */

            if (SPVG011W.LK_VG011_E_DTA_INI_CALCULO != "0001-01-01")
            {

                /*" -629- MOVE LK-VG011-E-DTA-INI-CALCULO TO WS-DATA-MAIOR */
                _.Move(SPVG011W.LK_VG011_E_DTA_INI_CALCULO, WORK.WS_DATA_MAIOR);

                /*" -631- MOVE SISTEMAS-DATA-MOV-ABERTO TO WS-DATA-MENOR */
                _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WORK.WS_DATA_MENOR);

                /*" -633- PERFORM P0103-VALIDAR-DATA-PARAM */

                P0103_VALIDAR_DATA_PARAM_SECTION();

                /*" -634- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -635- MOVE 'P0100' TO WS-SECTION */
                    _.Move("P0100", WORK.WS_ERRO.WS_SECTION);

                    /*" -636- MOVE 1 TO WS-IND-ERRO */
                    _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                    /*" -641- STRING WS-SECTION ' - DATA DE INICIO CALCULO INVALIDA.' '<DTA-INI-CALCULO=' LK-VG011-E-DTA-INI-CALCULO '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                    #region STRING
                    var spl15 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                    spl15 += " - DATA DE INICIO CALCULO INVALIDA.";
                    spl15 += "<DTA-INI-CALCULO=";
                    var spl16 = SPVG011W.LK_VG011_E_DTA_INI_CALCULO.GetMoveValues();
                    spl16 += ">";
                    var results17 = spl15 + spl16;
                    _.Move(results17, WORK.WS_ERRO.WS_MENSAGEM);
                    #endregion

                    /*" -643- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                    _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                    /*" -644- MOVE 0 TO WS-SQLCODE */
                    _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                    /*" -645- GO TO P9999-ERRO */

                    P9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -646- END-IF */
                }


                /*" -647- ELSE */
            }
            else
            {


                /*" -652- STRING WS-SECTION ' - DATA DE INICIO CALCULO NAO INFORMADA.' '<DTA-INI-CALCULO=' LK-VG011-E-DTA-INI-CALCULO '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl17 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl17 += " - DATA DE INICIO CALCULO NAO INFORMADA.";
                spl17 += "<DTA-INI-CALCULO=";
                var spl18 = SPVG011W.LK_VG011_E_DTA_INI_CALCULO.GetMoveValues();
                spl18 += ">";
                var results19 = spl17 + spl18;
                _.Move(results19, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -654- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -655- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -656- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -657- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -659- END-IF */
            }


            /*" -660- IF LK-VG011-E-DTA-FIM-CALCULO NOT EQUAL SPACES */

            if (!SPVG011W.LK_VG011_E_DTA_FIM_CALCULO.IsEmpty())
            {

                /*" -661- MOVE LK-VG011-E-DTA-FIM-CALCULO TO WS-DATA-MAIOR */
                _.Move(SPVG011W.LK_VG011_E_DTA_FIM_CALCULO, WORK.WS_DATA_MAIOR);

                /*" -663- MOVE SISTEMAS-DATA-MOV-ABERTO TO WS-DATA-MENOR */
                _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WORK.WS_DATA_MENOR);

                /*" -665- PERFORM P0103-VALIDAR-DATA-PARAM */

                P0103_VALIDAR_DATA_PARAM_SECTION();

                /*" -666- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -667- MOVE 'P0100' TO WS-SECTION */
                    _.Move("P0100", WORK.WS_ERRO.WS_SECTION);

                    /*" -668- MOVE 1 TO WS-IND-ERRO */
                    _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                    /*" -673- STRING WS-SECTION ' - DATA DE FIM CALCULO INVALIDA.' '<DTA-FIM-CALCULO=' LK-VG011-E-DTA-FIM-CALCULO '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                    #region STRING
                    var spl19 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                    spl19 += " - DATA DE FIM CALCULO INVALIDA.";
                    spl19 += "<DTA-FIM-CALCULO=";
                    var spl20 = SPVG011W.LK_VG011_E_DTA_FIM_CALCULO.GetMoveValues();
                    spl20 += ">";
                    var results21 = spl19 + spl20;
                    _.Move(results21, WORK.WS_ERRO.WS_MENSAGEM);
                    #endregion

                    /*" -675- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                    _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                    /*" -676- MOVE 0 TO WS-SQLCODE */
                    _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                    /*" -677- GO TO P9999-ERRO */

                    P9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -678- END-IF */
                }


                /*" -679- ELSE */
            }
            else
            {


                /*" -684- STRING WS-SECTION ' - DATA DE FIM CALCULO NAO INFORMADA.' '<DTA-FIM-CALCULO=' LK-VG011-E-DTA-FIM-CALCULO '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl21 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl21 += " - DATA DE FIM CALCULO NAO INFORMADA.";
                spl21 += "<DTA-FIM-CALCULO=";
                var spl22 = SPVG011W.LK_VG011_E_DTA_FIM_CALCULO.GetMoveValues();
                spl22 += ">";
                var results23 = spl21 + spl22;
                _.Move(results23, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -686- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -687- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -688- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -689- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -691- END-IF */
            }


            /*" -692- MOVE LK-VG011-E-DTA-FIM-CALCULO TO WS-DATA-MAIOR */
            _.Move(SPVG011W.LK_VG011_E_DTA_FIM_CALCULO, WORK.WS_DATA_MAIOR);

            /*" -694- MOVE LK-VG011-E-DTA-INI-CALCULO TO WS-DATA-MENOR */
            _.Move(SPVG011W.LK_VG011_E_DTA_INI_CALCULO, WORK.WS_DATA_MENOR);

            /*" -696- PERFORM P0103-VALIDAR-DATA-PARAM */

            P0103_VALIDAR_DATA_PARAM_SECTION();

            /*" -697- IF WS-QTD-DIAS < ZEROS */

            if (WORK.WS_QTD_DIAS < 00)
            {

                /*" -698- MOVE 'P0100' TO WS-SECTION */
                _.Move("P0100", WORK.WS_ERRO.WS_SECTION);

                /*" -699- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -705- STRING WS-SECTION ' - DATA FIM CALCULO MENOR QUE DATA INICIO CALCULO.' '<DTA-INI-CALCULO=' LK-VG011-E-DTA-INI-CALCULO '<DTA-FIM-CALCULO=' LK-VG011-E-DTA-FIM-CALCULO '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl23 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl23 += " - DATA FIM CALCULO MENOR QUE DATA INICIO CALCULO.";
                spl23 += "<DTA-INI-CALCULO=";
                var spl24 = SPVG011W.LK_VG011_E_DTA_INI_CALCULO.GetMoveValues();
                spl24 += "<DTA-FIM-CALCULO=";
                var spl25 = SPVG011W.LK_VG011_E_DTA_FIM_CALCULO.GetMoveValues();
                spl25 += ">";
                var results26 = spl23 + spl24 + spl25;
                _.Move(results26, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -707- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -708- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -709- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -711- END-IF */
            }


            /*" -712- IF LK-VG011-E-DTA-DECLINIO(1:4) NOT EQUAL SPACES */

            if (SPVG011W.LK_VG011_E_DTA_DECLINIO.Substring(1, 4) != string.Empty)
            {

                /*" -713- MOVE LK-VG011-E-DTA-DECLINIO TO WS-DATA-MAIOR */
                _.Move(SPVG011W.LK_VG011_E_DTA_DECLINIO, WORK.WS_DATA_MAIOR);

                /*" -715- MOVE SISTEMAS-DATA-MOV-ABERTO TO WS-DATA-MENOR */
                _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WORK.WS_DATA_MENOR);

                /*" -717- PERFORM P0103-VALIDAR-DATA-PARAM */

                P0103_VALIDAR_DATA_PARAM_SECTION();

                /*" -718- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -719- MOVE 'P0100' TO WS-SECTION */
                    _.Move("P0100", WORK.WS_ERRO.WS_SECTION);

                    /*" -720- MOVE 1 TO WS-IND-ERRO */
                    _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                    /*" -725- STRING WS-SECTION ' - DATA DE DECLINIO INVALIDA.' '<DTA-FIM-CALCULO=' LK-VG011-E-DTA-FIM-CALCULO '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                    #region STRING
                    var spl26 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                    spl26 += " - DATA DE DECLINIO INVALIDA.";
                    spl26 += "<DTA-FIM-CALCULO=";
                    var spl27 = SPVG011W.LK_VG011_E_DTA_FIM_CALCULO.GetMoveValues();
                    spl27 += ">";
                    var results28 = spl26 + spl27;
                    _.Move(results28, WORK.WS_ERRO.WS_MENSAGEM);
                    #endregion

                    /*" -727- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                    _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                    /*" -728- MOVE 0 TO WS-SQLCODE */
                    _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                    /*" -729- GO TO P9999-ERRO */

                    P9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -730- END-IF */
                }


                /*" -731- ELSE */
            }
            else
            {


                /*" -736- STRING WS-SECTION ' - DATA DECLINIO NAO INFORMADA.' '<DTA-FIM-CALCULO=' LK-VG011-E-DTA-DECLINIO '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl28 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl28 += " - DATA DECLINIO NAO INFORMADA.";
                spl28 += "<DTA-FIM-CALCULO=";
                var spl29 = SPVG011W.LK_VG011_E_DTA_DECLINIO.GetMoveValues();
                spl29 += ">";
                var results30 = spl28 + spl29;
                _.Move(results30, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -738- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -739- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -740- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -741- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -743- END-IF */
            }


            /*" -744- IF LK-VG011-E-DTA-DECLINIO NOT EQUAL '0001-01-01' */

            if (SPVG011W.LK_VG011_E_DTA_DECLINIO != "0001-01-01")
            {

                /*" -745- MOVE LK-VG011-E-DTA-DECLINIO TO WS-DATA-MAIOR */
                _.Move(SPVG011W.LK_VG011_E_DTA_DECLINIO, WORK.WS_DATA_MAIOR);

                /*" -747- MOVE SISTEMAS-DATA-MOV-ABERTO TO WS-DATA-MENOR */
                _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WORK.WS_DATA_MENOR);

                /*" -749- PERFORM P0103-VALIDAR-DATA-PARAM */

                P0103_VALIDAR_DATA_PARAM_SECTION();

                /*" -750- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -751- MOVE 'P0100' TO WS-SECTION */
                    _.Move("P0100", WORK.WS_ERRO.WS_SECTION);

                    /*" -752- MOVE 1 TO WS-IND-ERRO */
                    _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                    /*" -757- STRING WS-SECTION ' - DATA DE DECLINIO INVALIDA.' '<DTA-FIM-CALCULO=' LK-VG011-E-DTA-FIM-CALCULO '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                    #region STRING
                    var spl30 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                    spl30 += " - DATA DE DECLINIO INVALIDA.";
                    spl30 += "<DTA-FIM-CALCULO=";
                    var spl31 = SPVG011W.LK_VG011_E_DTA_FIM_CALCULO.GetMoveValues();
                    spl31 += ">";
                    var results32 = spl30 + spl31;
                    _.Move(results32, WORK.WS_ERRO.WS_MENSAGEM);
                    #endregion

                    /*" -759- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                    _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                    /*" -760- MOVE 0 TO WS-SQLCODE */
                    _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                    /*" -761- GO TO P9999-ERRO */

                    P9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -762- END-IF */
                }


                /*" -764- END-IF */
            }


            /*" -765- MOVE LK-VG011-E-DTA-FIM-CALCULO TO WS-DATA-MAIOR */
            _.Move(SPVG011W.LK_VG011_E_DTA_FIM_CALCULO, WORK.WS_DATA_MAIOR);

            /*" -767- MOVE LK-VG011-E-DTA-INI-CALCULO TO WS-DATA-MENOR */
            _.Move(SPVG011W.LK_VG011_E_DTA_INI_CALCULO, WORK.WS_DATA_MENOR);

            /*" -769- PERFORM P0103-VALIDAR-DATA-PARAM */

            P0103_VALIDAR_DATA_PARAM_SECTION();

            /*" -770- IF WS-QTD-DIAS < ZEROS */

            if (WORK.WS_QTD_DIAS < 00)
            {

                /*" -771- MOVE 'P0100' TO WS-SECTION */
                _.Move("P0100", WORK.WS_ERRO.WS_SECTION);

                /*" -772- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -778- STRING WS-SECTION ' - DATA FIM CALCULO MENOR QUE DATA INICIO CALCULO.' '<DTA-INI-CALCULO=' LK-VG011-E-DTA-INI-CALCULO '<DTA-FIM-CALCULO=' LK-VG011-E-DTA-FIM-CALCULO '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl32 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl32 += " - DATA FIM CALCULO MENOR QUE DATA INICIO CALCULO.";
                spl32 += "<DTA-INI-CALCULO=";
                var spl33 = SPVG011W.LK_VG011_E_DTA_INI_CALCULO.GetMoveValues();
                spl33 += "<DTA-FIM-CALCULO=";
                var spl34 = SPVG011W.LK_VG011_E_DTA_FIM_CALCULO.GetMoveValues();
                spl34 += ">";
                var results35 = spl32 + spl33 + spl34;
                _.Move(results35, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -780- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -781- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -782- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -784- END-IF */
            }


            /*" -786- IF LK-VG011-E-VL-ORIGINAL EQUAL ZEROS OR LK-VG011-E-VL-ORIGINAL < ZEROS */

            if (SPVG011W.LK_VG011_E_VL_ORIGINAL == 00 || SPVG011W.LK_VG011_E_VL_ORIGINAL < 00)
            {

                /*" -787- MOVE 'P0100' TO WS-SECTION */
                _.Move("P0100", WORK.WS_ERRO.WS_SECTION);

                /*" -788- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -789- MOVE LK-VG011-E-VL-ORIGINAL TO WS-DECIMAL (01) */
                _.Move(SPVG011W.LK_VG011_E_VL_ORIGINAL, WORK.WS_EDIT.WS_DECIMAL[01]);

                /*" -793- STRING WS-SECTION ' - VALOR ORIGINAL PARA CALCULO NAO EH VALIDO.' '<VL-ORIGINAL=' WS-DECIMAL (01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl35 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl35 += " - VALOR ORIGINAL PARA CALCULO NAO EH VALIDO.";
                spl35 += "<VL-ORIGINAL=";
                var spl36 = WORK.WS_EDIT.WS_DECIMAL[01].GetMoveValues();
                spl36 += ">";
                var results37 = spl35 + spl36;
                _.Move(results37, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -795- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -796- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -797- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -799- END-IF */
            }


            /*" -801- IF LK-VG011-E-QTD-DIA-PGMNTO > 10 OR LK-VG011-E-QTD-DIA-PGMNTO < ZEROS */

            if (SPVG011W.LK_VG011_E_QTD_DIA_PGMNTO > 10 || SPVG011W.LK_VG011_E_QTD_DIA_PGMNTO < 00)
            {

                /*" -802- MOVE 'P0100' TO WS-SECTION */
                _.Move("P0100", WORK.WS_ERRO.WS_SECTION);

                /*" -803- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -804- MOVE LK-VG011-E-QTD-DIA-PGMNTO TO WS-SMALLINT (01) */
                _.Move(SPVG011W.LK_VG011_E_QTD_DIA_PGMNTO, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -808- STRING WS-SECTION ' - QUANTIDADE DE DIAS PARA PAGAMENTO NAO EH INVALIDO.' '<QTD-DIAS-PAGAMENTO=' WS-SMALLINT (01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl37 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl37 += " - QUANTIDADE DE DIAS PARA PAGAMENTO NAO EH INVALIDO.";
                spl37 += "<QTD-DIAS-PAGAMENTO=";
                var spl38 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl38 += ">";
                var results39 = spl37 + spl38;
                _.Move(results39, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -810- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -811- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -812- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -813- END-IF */
            }


            /*" -813- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0100_99_EXIT*/

        [StopWatch]
        /*" P0103-VALIDAR-DATA-PARAM-SECTION */
        private void P0103_VALIDAR_DATA_PARAM_SECTION()
        {
            /*" -824- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0103_00_START */

            P0103_00_START();

        }

        [StopWatch]
        /*" P0103-00-START */
        private void P0103_00_START(bool isPerform = false)
        {
            /*" -827- MOVE 'P0103' TO WS-SECTION */
            _.Move("P0103", WORK.WS_ERRO.WS_SECTION);

            /*" -828- MOVE ZEROS TO WS-QTD-DIAS */
            _.Move(0, WORK.WS_QTD_DIAS);

            /*" -828- PERFORM P0103-10-INICIO. */

            P0103_10_INICIO(true);

        }

        [StopWatch]
        /*" P0103-10-INICIO */
        private void P0103_10_INICIO(bool isPerform = false)
        {
            /*" -839- PERFORM P0103_10_INICIO_DB_SELECT_1 */

            P0103_10_INICIO_DB_SELECT_1();

            /*" -842- IF NOT ( SQLCODE = 0 OR = -180 ) */

            if (!(DB.SQLCODE.In("0", "-180")))
            {

                /*" -843- MOVE 'P0103' TO WS-SECTION */
                _.Move("P0103", WORK.WS_ERRO.WS_SECTION);

                /*" -844- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -850- STRING WS-SECTION ' - ERRO NO CALCULO DE DATA.' '<WS-DATA-MAIOR=' WS-DATA-MAIOR '<WS-DATA-MENOR=' WS-DATA-MENOR '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl39 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl39 += " - ERRO NO CALCULO DE DATA.";
                spl39 += "<WS-DATA-MAIOR=";
                var spl40 = WORK.WS_DATA_MAIOR.GetMoveValues();
                spl40 += "<WS-DATA-MENOR=";
                var spl41 = WORK.WS_DATA_MENOR.GetMoveValues();
                spl41 += ">";
                var results42 = spl39 + spl40 + spl41;
                _.Move(results42, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -851- MOVE 'SYSIBM.SYSDUMMY1' TO WS-TABELA */
                _.Move("SYSIBM.SYSDUMMY1", WORK.WS_ERRO.WS_TABELA);

                /*" -852- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -853- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -854- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -855- END-IF */
            }


            /*" -855- . */

        }

        [StopWatch]
        /*" P0103-10-INICIO-DB-SELECT-1 */
        public void P0103_10_INICIO_DB_SELECT_1()
        {
            /*" -839- EXEC SQL SELECT DATE(:WS-DATA-MAIOR) - DATE(:WS-DATA-MENOR) INTO :WS-QTD-DIAS FROM SYSIBM.SYSDUMMY1 WITH UR END-EXEC. */

            /*-- linha suprimida por comandos abaixo EXEC SQL
            /*--SELECT DATE(:WS-DATA-MAIOR) -
            /*--DATE(:WS-DATA-MENOR)
            /*--INTO :WS-QTD-DIAS
            /*--FROM SYSIBM.SYSDUMMY1
            /*--WITH UR
            /*--END-EXEC.
            /*-- */

            _.Move(WORK.WS_DATA_MAIOR.ToDateTime().ToString(_.CurrentDateFormat), WORK.WS_QTD_DIAS);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0103_99_EXIT*/

        [StopWatch]
        /*" P0302-TRATAR-TIPO-ACAO-01-SECTION */
        private void P0302_TRATAR_TIPO_ACAO_01_SECTION()
        {
            /*" -866- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0302_00_START */

            P0302_00_START();

        }

        [StopWatch]
        /*" P0302-00-START */
        private void P0302_00_START(bool isPerform = false)
        {
            /*" -869- MOVE 'P0302' TO WS-SECTION */
            _.Move("P0302", WORK.WS_ERRO.WS_SECTION);

            /*" -870- MOVE 1 TO WS-IGPM-ACUM */
            _.Move(1, WORK.WS_IGPM_ACUM);

            /*" -877- MOVE ZEROS TO WDIAS-TOTAL WDIAS-PRORATA WDIAS-AUX WJUROS-PC-PRO WJUROS-VL-PRO WS-QTD-MESES ANO-INI-ANT */
            _.Move(0, WORK.WDIAS_TOTAL, WORK.WDIAS_PRORATA, WORK.WDIAS_AUX, WORK.WJUROS_PC_PRO, WORK.WJUROS_VL_PRO, WORK.WS_QTD_MESES, WORK.DATA_INI_ANT.ANO_INI_ANT);

            /*" -877- PERFORM P0302-05-INICIO. */

            P0302_05_INICIO(true);

        }

        [StopWatch]
        /*" P0302-05-INICIO */
        private void P0302_05_INICIO(bool isPerform = false)
        {
            /*" -887- MOVE LK-VG011-E-DTA-INI-CALCULO TO DATA-INI WDATA-INI WDATA-CONSULTA LK-VG011-S-DTA-FIM-PGMNTO W0CODTSQLINI */
            _.Move(SPVG011W.LK_VG011_E_DTA_INI_CALCULO, WORK.DATA_INI, WORK.WDATA_INI, WORK.WDATA_CONSULTA, SPVG011W.LK_VG011_S_DTA_FIM_PGMNTO, WORK.W0CODTSQLINI);

            /*" -889- MOVE LK-VG011-E-DTA-FIM-CALCULO TO W0CODTSQLFIM */
            _.Move(SPVG011W.LK_VG011_E_DTA_FIM_CALCULO, WORK.W0CODTSQLFIM);

            /*" -890- IF LK-VG011-E-QTD-DIA-PGMNTO > ZEROS */

            if (SPVG011W.LK_VG011_E_QTD_DIA_PGMNTO > 00)
            {

                /*" -891- MOVE LK-VG011-E-DTA-FIM-CALCULO TO W04DTSQL */
                _.Move(SPVG011W.LK_VG011_E_DTA_FIM_CALCULO, WORK.W04DTSQL);

                /*" -892- MOVE W04DDSQL TO SU1-DD1 */
                _.Move(WORK.W04DTSQL.W04DDSQL, WORK.PARM_PROSOMU1.SU1_DATA1.SU1_DD1);

                /*" -893- MOVE W04MMSQL TO SU1-MM1 */
                _.Move(WORK.W04DTSQL.W04MMSQL, WORK.PARM_PROSOMU1.SU1_DATA1.SU1_MM1);

                /*" -894- MOVE W04AASQL TO SU1-AA1 */
                _.Move(WORK.W04DTSQL.W04AASQL, WORK.PARM_PROSOMU1.SU1_DATA1.SU1_AA1);

                /*" -896- MOVE ZEROES TO SU1-DATA2 */
                _.Move(0, WORK.PARM_PROSOMU1.SU1_DATA2);

                /*" -899- PERFORM P0303-SOMAR-DIAS-UTEIS THRU P0303-99-EXIT LK-VG011-E-QTD-DIA-PGMNTO TIMES */

                P0303_SOMAR_DIAS_UTEIS_SECTION();

                P0303_00_START(true);

                P0303_05_INICIO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P0303_99_EXIT*/


                /*" -900- MOVE SU1-DD2 TO W04DDSQL */
                _.Move(WORK.PARM_PROSOMU1.SU1_DATA2.SU1_DD2, WORK.W04DTSQL.W04DDSQL);

                /*" -901- MOVE SU1-MM2 TO W04MMSQL */
                _.Move(WORK.PARM_PROSOMU1.SU1_DATA2.SU1_MM2, WORK.W04DTSQL.W04MMSQL);

                /*" -903- MOVE SU1-AA2 TO W04AASQL */
                _.Move(WORK.PARM_PROSOMU1.SU1_DATA2.SU1_AA2, WORK.W04DTSQL.W04AASQL);

                /*" -904- MOVE W04DTSQL TO DATA-SQL */
                _.Move(WORK.W04DTSQL, WORK.DATA_SQL);

                /*" -906- MOVE DATA-SQL TO WHOST-DATA-CRED */
                _.Move(WORK.DATA_SQL, WORK.WHOST_DATA_CRED);

                /*" -907- MOVE WHOST-DATA-CRED TO DATA-FIM */
                _.Move(WORK.WHOST_DATA_CRED, WORK.DATA_FIM);

                /*" -908- ELSE */
            }
            else
            {


                /*" -909- MOVE LK-VG011-E-DTA-FIM-CALCULO TO DATA-FIM */
                _.Move(SPVG011W.LK_VG011_E_DTA_FIM_CALCULO, WORK.DATA_FIM);

                /*" -910- MOVE LK-VG011-E-VL-ORIGINAL TO LK-VG011-S-VL-CORRIGIDO */
                _.Move(SPVG011W.LK_VG011_E_VL_ORIGINAL, SPVG011W.LK_VG011_S_VL_CORRIGIDO);

                /*" -913- END-IF */
            }


            /*" -914- IF LK-VG011-E-NUM-APOLICE > ZEROS */

            if (SPVG011W.LK_VG011_E_NUM_APOLICE > 00)
            {

                /*" -915- PERFORM P3021-CONS-VGINDICE */

                P3021_CONS_VGINDICE_SECTION();

                /*" -916- ELSE */
            }
            else
            {


                /*" -917- PERFORM P3022-CONS-PRODUTO-MOEDA */

                P3022_CONS_PRODUTO_MOEDA_SECTION();

                /*" -919- END-IF */
            }


            /*" -920- MOVE DATA-INI TO DT-INI */
            _.Move(WORK.DATA_INI, DT_INI);

            /*" -922- MOVE DATA-FIM TO DT-FIM */
            _.Move(WORK.DATA_FIM, DT_FIM);

            /*" -928- PERFORM P0302_05_INICIO_DB_SELECT_1 */

            P0302_05_INICIO_DB_SELECT_1();

            /*" -931- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -932- DISPLAY 'DATA-INI-CALC    >> ' DATA-INI */
            _.Display($"DATA-INI-CALC    >> {WORK.DATA_INI}");

            /*" -933- DISPLAY 'DATA-FIM-CALC    >> ' DATA-FIM */
            _.Display($"DATA-FIM-CALC    >> {WORK.DATA_FIM}");

            /*" -934- DISPLAY 'DATA-DECLINIO    >> ' DATA-DEC */
            _.Display($"DATA-DECLINIO    >> {WORK.DATA_DEC}");

            /*" -935- IF MOEDA EQUAL 23 */

            if (WORK.MOEDA == 23)
            {

                /*" -936- DISPLAY 'INDICE UTILIZADO >>   IGPM' */
                _.Display($"INDICE UTILIZADO >>   IGPM");

                /*" -937- ELSE */
            }
            else
            {


                /*" -938- DISPLAY 'INDICE UTILIZADO >>   IPCA' */
                _.Display($"INDICE UTILIZADO >>   IPCA");

                /*" -940- END-IF */
            }


            /*" -942- MOVE ZEROS TO WSXB5 */
            _.Move(0, WSXB5);

            /*" -944- PERFORM P8020-INICIALIZA-TABELA 500 TIMES. */

            for (int i = 0; i < 500; i++)
            {

                P8020_INICIALIZA_TABELA_SECTION();

            }

            /*" -947- PERFORM P8010-CARREGAR-TAB-INDICE */

            P8010_CARREGAR_TAB_INDICE_SECTION();

            /*" -948- IF DATA-FIM > DATA-INI */

            if (WORK.DATA_FIM > WORK.DATA_INI)
            {

                /*" -949- DISPLAY '------------------------------------------------' */
                _.Display($"------------------------------------------------");

                /*" -950- DISPLAY '-------------- ACUMULAR INDICE -----------------' */
                _.Display($"-------------- ACUMULAR INDICE -----------------");

                /*" -953- PERFORM P0310-CALCULAR-IND-ACUM UNTIL DATA-INI(1:7) > DATA-FIM(1:7) */

                while (!(WORK.DATA_INI.Substring(1, 7) > WORK.DATA_FIM.Substring(1, 7)))
                {

                    P0310_CALCULAR_IND_ACUM_SECTION();
                }

                /*" -954- DISPLAY '------------------------------------------------' */
                _.Display($"------------------------------------------------");

                /*" -956- DISPLAY '---------- FIM DO ACUMULO DE INDICE ------------' */
                _.Display($"---------- FIM DO ACUMULO DE INDICE ------------");

                /*" -960- MOVE WS-IGPM-ACUM TO WS-TAXA(01) */
                _.Move(WORK.WS_IGPM_ACUM, WORK.WS_EDIT.WS_TAXA[01]);

                /*" -962- COMPUTE WS-IGPM-ACUM = WS-IGPM-ACUM - 1 */
                WORK.WS_IGPM_ACUM.Value = WORK.WS_IGPM_ACUM - 1;

                /*" -964- MOVE WS-IGPM-ACUM TO WS-TAXA(02) */
                _.Move(WORK.WS_IGPM_ACUM, WORK.WS_EDIT.WS_TAXA[02]);

                /*" -965- IF WDIAS-TOTAL > ZEROS */

                if (WORK.WDIAS_TOTAL > 00)
                {

                    /*" -967- COMPUTE WS-IGPM-ACUM = (WS-IGPM-ACUM / WDIAS-TOTAL) * WDIAS-PRORATA */
                    WORK.WS_IGPM_ACUM.Value = (WORK.WS_IGPM_ACUM / WORK.WDIAS_TOTAL) * WORK.WDIAS_PRORATA;

                    /*" -968- ELSE */
                }
                else
                {


                    /*" -969- MOVE ZEROS TO WS-IGPM-ACUM */
                    _.Move(0, WORK.WS_IGPM_ACUM);

                    /*" -971- END-IF */
                }


                /*" -973- MOVE WS-IGPM-ACUM TO WS-TAXA(03) */
                _.Move(WORK.WS_IGPM_ACUM, WORK.WS_EDIT.WS_TAXA[03]);

                /*" -974- DISPLAY '------------------------------------------------' */
                _.Display($"------------------------------------------------");

                /*" -975- DISPLAY 'DIAS-PRORATA      >> ' WDIAS-PRORATA */
                _.Display($"DIAS-PRORATA      >> {WORK.WDIAS_PRORATA}");

                /*" -976- DISPLAY 'DIAS-TOTAL        >> ' WDIAS-TOTAL */
                _.Display($"DIAS-TOTAL        >> {WORK.WDIAS_TOTAL}");

                /*" -977- DISPLAY 'IGPM-ACUM TOTAL   >> ' WS-TAXA(01) */
                _.Display($"IGPM-ACUM TOTAL   >> {WORK.WS_EDIT.WS_TAXA[1]}");

                /*" -978- DISPLAY 'IGPM-ACUM -1      >> ' WS-TAXA(02) */
                _.Display($"IGPM-ACUM -1      >> {WORK.WS_EDIT.WS_TAXA[2]}");

                /*" -980- DISPLAY 'IGPM-ACUM PRORATA >> ' WS-TAXA(03) */
                _.Display($"IGPM-ACUM PRORATA >> {WORK.WS_EDIT.WS_TAXA[3]}");

                /*" -981- IF WS-IGPM-ACUM < ZEROS */

                if (WORK.WS_IGPM_ACUM < 00)
                {

                    /*" -982- MOVE 0 TO WS-IGPM-ACUM */
                    _.Move(0, WORK.WS_IGPM_ACUM);

                    /*" -984- END-IF */
                }


                /*" -987- COMPUTE WJUROS ROUNDED = LK-VG011-E-VL-ORIGINAL * WS-IGPM-ACUM */
                WORK.WJUROS.Value = SPVG011W.LK_VG011_E_VL_ORIGINAL * WORK.WS_IGPM_ACUM;

                /*" -990- COMPUTE LK-VG011-S-VL-CORRIGIDO = (LK-VG011-E-VL-ORIGINAL + WJUROS) */
                SPVG011W.LK_VG011_S_VL_CORRIGIDO.Value = (SPVG011W.LK_VG011_E_VL_ORIGINAL + WORK.WJUROS);

                /*" -991- MOVE WJUROS TO LK-VG011-S-VL-JUROS */
                _.Move(WORK.WJUROS, SPVG011W.LK_VG011_S_VL_JUROS);

                /*" -992- MOVE MOEDA TO LK-VG011-S-COD-MOEDA */
                _.Move(WORK.MOEDA, SPVG011W.LK_VG011_S_COD_MOEDA);

                /*" -993- MOVE WS-IGPM-ACUM TO LK-VG011-S-PC-INDICE */
                _.Move(WORK.WS_IGPM_ACUM, SPVG011W.LK_VG011_S_PC_INDICE);

                /*" -994- ELSE */
            }
            else
            {


                /*" -995- DISPLAY 'DATA INICIO <= DATA FIM DE CALCULO' */
                _.Display($"DATA INICIO <= DATA FIM DE CALCULO");

                /*" -996- MOVE MOEDA TO LK-VG011-S-COD-MOEDA */
                _.Move(WORK.MOEDA, SPVG011W.LK_VG011_S_COD_MOEDA);

                /*" -997- MOVE LK-VG011-E-VL-ORIGINAL TO LK-VG011-S-VL-CORRIGIDO */
                _.Move(SPVG011W.LK_VG011_E_VL_ORIGINAL, SPVG011W.LK_VG011_S_VL_CORRIGIDO);

                /*" -999- END-IF */
            }


            /*" -1000- MOVE LK-VG011-S-PC-INDICE TO WS-DECIMAL(01) */
            _.Move(SPVG011W.LK_VG011_S_PC_INDICE, WORK.WS_EDIT.WS_DECIMAL[01]);

            /*" -1001- MOVE LK-VG011-S-VL-JUROS TO WS-DECIMAL(02) */
            _.Move(SPVG011W.LK_VG011_S_VL_JUROS, WORK.WS_EDIT.WS_DECIMAL[02]);

            /*" -1002- MOVE LK-VG011-S-VL-MULTA TO WS-DECIMAL(03) */
            _.Move(SPVG011W.LK_VG011_S_VL_MULTA, WORK.WS_EDIT.WS_DECIMAL[03]);

            /*" -1003- MOVE LK-VG011-E-VL-ORIGINAL TO WS-DECIMAL(04) */
            _.Move(SPVG011W.LK_VG011_E_VL_ORIGINAL, WORK.WS_EDIT.WS_DECIMAL[04]);

            /*" -1005- MOVE LK-VG011-S-VL-CORRIGIDO TO WS-DECIMAL(05) */
            _.Move(SPVG011W.LK_VG011_S_VL_CORRIGIDO, WORK.WS_EDIT.WS_DECIMAL[05]);

            /*" -1006- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -1007- DISPLAY '----------- SAIDA DO PROCESSAMENTO - CORRECAO --' */
            _.Display($"----------- SAIDA DO PROCESSAMENTO - CORRECAO --");

            /*" -1008- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -1009- DISPLAY 'VG11-COD-MOEDA    >> ' LK-VG011-S-COD-MOEDA */
            _.Display($"VG11-COD-MOEDA    >> {SPVG011W.LK_VG011_S_COD_MOEDA}");

            /*" -1010- DISPLAY 'VG11-PC-INDICE    >> ' WS-DECIMAL(01) */
            _.Display($"VG11-PC-INDICE    >> {WORK.WS_EDIT.WS_DECIMAL[1]}");

            /*" -1011- DISPLAY 'VG11-VL-JUROS     >> ' WS-DECIMAL(02) */
            _.Display($"VG11-VL-JUROS     >> {WORK.WS_EDIT.WS_DECIMAL[2]}");

            /*" -1012- DISPLAY 'VG11-VL-MULTA     >> ' WS-DECIMAL(03) */
            _.Display($"VG11-VL-MULTA     >> {WORK.WS_EDIT.WS_DECIMAL[3]}");

            /*" -1013- DISPLAY 'VG11-VL-ORIGINAL  >> ' WS-DECIMAL(04) */
            _.Display($"VG11-VL-ORIGINAL  >> {WORK.WS_EDIT.WS_DECIMAL[4]}");

            /*" -1014- DISPLAY 'VG11-VL-CORRIGIDO >> ' WS-DECIMAL(05) */
            _.Display($"VG11-VL-CORRIGIDO >> {WORK.WS_EDIT.WS_DECIMAL[5]}");

            /*" -1016- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -1017- IF LK-VG011-E-DTA-DECLINIO NOT EQUAL '0001-01-01' */

            if (SPVG011W.LK_VG011_E_DTA_DECLINIO != "0001-01-01")
            {

                /*" -1019- MOVE ZEROS TO WDIAS-PRORATA WDIAS-TOTAL */
                _.Move(0, WORK.WDIAS_PRORATA, WORK.WDIAS_TOTAL);

                /*" -1022- MOVE LK-VG011-E-DTA-DECLINIO TO DATA-INI WDATA-INI WDATA-CONSULTA */
                _.Move(SPVG011W.LK_VG011_E_DTA_DECLINIO, WORK.DATA_INI, WORK.WDATA_INI, WORK.WDATA_CONSULTA);

                /*" -1025- PERFORM P0330-CALCULAR-MESES UNTIL DATA-INI(1:7) > DATA-FIM(1:7) */

                while (!(WORK.DATA_INI.Substring(1, 7) > WORK.DATA_FIM.Substring(1, 7)))
                {

                    P0330_CALCULAR_MESES_SECTION();
                }

                /*" -1027- MULTIPLY GE252-PCT-JUROS BY WS-QTD-MESES GIVING WJUROS-PC-PRO */
                _.Multiply(GE252.DCLGE_PRODUTO_MOEDA.GE252_PCT_JUROS, WORK.WS_QTD_MESES, WORK.WJUROS_PC_PRO);

                /*" -1028- IF WDIAS-TOTAL > 0 */

                if (WORK.WDIAS_TOTAL > 0)
                {

                    /*" -1030- DIVIDE WJUROS-PC-PRO BY WDIAS-TOTAL GIVING WJUROS-PC-PRO */
                    _.Divide(WORK.WJUROS_PC_PRO, WORK.WDIAS_TOTAL, WORK.WJUROS_PC_PRO);

                    /*" -1031- ELSE */
                }
                else
                {


                    /*" -1033- MOVE ZEROS TO WJUROS-PC-PRO */
                    _.Move(0, WORK.WJUROS_PC_PRO);

                    /*" -1034- END-IF */
                }


                /*" -1035- IF WDIAS-PRORATA > 0 */

                if (WORK.WDIAS_PRORATA > 0)
                {

                    /*" -1037- MULTIPLY WJUROS-PC-PRO BY WDIAS-PRORATA GIVING WJUROS-PC-PRO */
                    _.Multiply(WORK.WJUROS_PC_PRO, WORK.WDIAS_PRORATA, WORK.WJUROS_PC_PRO);

                    /*" -1038- ELSE */
                }
                else
                {


                    /*" -1040- MOVE ZEROS TO WJUROS-PC-PRO */
                    _.Move(0, WORK.WJUROS_PC_PRO);

                    /*" -1041- END-IF */
                }


                /*" -1043- DIVIDE WJUROS-PC-PRO BY 100 GIVING WJUROS-PC-PRO */
                _.Divide(WORK.WJUROS_PC_PRO, 100, WORK.WJUROS_PC_PRO);

                /*" -1045- MULTIPLY LK-VG011-E-VL-ORIGINAL BY WJUROS-PC-PRO GIVING WJUROS-VL-PRO */
                _.Multiply(SPVG011W.LK_VG011_E_VL_ORIGINAL, WORK.WJUROS_PC_PRO, WORK.WJUROS_VL_PRO);

                /*" -1047- ADD WJUROS-VL-PRO TO LK-VG011-S-VL-CORRIGIDO LK-VG011-S-VL-JUROS */
                SPVG011W.LK_VG011_S_VL_CORRIGIDO.Value = SPVG011W.LK_VG011_S_VL_CORRIGIDO + WORK.WJUROS_VL_PRO;
                SPVG011W.LK_VG011_S_VL_JUROS.Value = SPVG011W.LK_VG011_S_VL_JUROS + WORK.WJUROS_VL_PRO;

                /*" -1048- MOVE GE252-PCT-JUROS TO WS-DECIMAL(06) */
                _.Move(GE252.DCLGE_PRODUTO_MOEDA.GE252_PCT_JUROS, WORK.WS_EDIT.WS_DECIMAL[06]);

                /*" -1049- MOVE WJUROS-PC-PRO TO WS-DECIMAL(07) */
                _.Move(WORK.WJUROS_PC_PRO, WORK.WS_EDIT.WS_DECIMAL[07]);

                /*" -1050- MOVE WJUROS-VL-PRO TO WS-DECIMAL(08) */
                _.Move(WORK.WJUROS_VL_PRO, WORK.WS_EDIT.WS_DECIMAL[08]);

                /*" -1051- MOVE WS-QTD-MESES TO WS-DECIMAL(10) */
                _.Move(WORK.WS_QTD_MESES, WORK.WS_EDIT.WS_DECIMAL[10]);

                /*" -1052- MOVE LK-VG011-S-VL-CORRIGIDO TO WS-DECIMAL(09) */
                _.Move(SPVG011W.LK_VG011_S_VL_CORRIGIDO, WORK.WS_EDIT.WS_DECIMAL[09]);

                /*" -1053- DISPLAY '---------------------------------------------' */
                _.Display($"---------------------------------------------");

                /*" -1054- DISPLAY '--- SAIDA DO PROCESSAMENTO - JUROS PRORATA --' */
                _.Display($"--- SAIDA DO PROCESSAMENTO - JUROS PRORATA --");

                /*" -1055- DISPLAY '---------------------------------------------' */
                _.Display($"---------------------------------------------");

                /*" -1056- DISPLAY 'INDICE JUROS      >> ' WS-DECIMAL(06) */
                _.Display($"INDICE JUROS      >> {WORK.WS_EDIT.WS_DECIMAL[6]}");

                /*" -1057- DISPLAY 'QTD-MESES         >> ' WS-DECIMAL(10) */
                _.Display($"QTD-MESES         >> {WORK.WS_EDIT.WS_DECIMAL[10]}");

                /*" -1058- DISPLAY 'DIAS-TOTAL        >> ' WDIAS-TOTAL */
                _.Display($"DIAS-TOTAL        >> {WORK.WDIAS_TOTAL}");

                /*" -1059- DISPLAY 'DIAS-PRORATA      >> ' WDIAS-PRORATA */
                _.Display($"DIAS-PRORATA      >> {WORK.WDIAS_PRORATA}");

                /*" -1060- DISPLAY 'VG11-PC-JUROS     >> ' WS-DECIMAL(07) */
                _.Display($"VG11-PC-JUROS     >> {WORK.WS_EDIT.WS_DECIMAL[7]}");

                /*" -1061- DISPLAY 'VG11-VL-ORIGINAL  >> ' WS-DECIMAL(04) */
                _.Display($"VG11-VL-ORIGINAL  >> {WORK.WS_EDIT.WS_DECIMAL[4]}");

                /*" -1062- DISPLAY 'VG11-VL-CORRIGIDO >> ' WS-DECIMAL(05) */
                _.Display($"VG11-VL-CORRIGIDO >> {WORK.WS_EDIT.WS_DECIMAL[5]}");

                /*" -1063- DISPLAY 'VG11-VL-JUROS     >> ' WS-DECIMAL(08) */
                _.Display($"VG11-VL-JUROS     >> {WORK.WS_EDIT.WS_DECIMAL[8]}");

                /*" -1064- DISPLAY 'VG11-VL-CORRIG-J  >> ' WS-DECIMAL(09) */
                _.Display($"VG11-VL-CORRIG-J  >> {WORK.WS_EDIT.WS_DECIMAL[9]}");

                /*" -1065- DISPLAY '---------------------------------------------' */
                _.Display($"---------------------------------------------");

                /*" -1066- END-IF */
            }


            /*" -1066- . */

        }

        [StopWatch]
        /*" P0302-05-INICIO-DB-SELECT-1 */
        public void P0302_05_INICIO_DB_SELECT_1()
        {
            /*" -928- EXEC SQL SELECT DAYS (:DT-FIM) - DAYS (:DT-INI) INTO :WSNOVO-DIAS FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VA' END-EXEC */

            var p0302_05_INICIO_DB_SELECT_1_Query1 = new P0302_05_INICIO_DB_SELECT_1_Query1()
            {
                DT_FIM = DT_FIM.ToString(),
                DT_INI = DT_INI.ToString(),
            };

            var executed_1 = P0302_05_INICIO_DB_SELECT_1_Query1.Execute(p0302_05_INICIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WSNOVO_DIAS, WORK.WSNOVO_DIAS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0302_99_EXIT*/

        [StopWatch]
        /*" P0303-SOMAR-DIAS-UTEIS-SECTION */
        private void P0303_SOMAR_DIAS_UTEIS_SECTION()
        {
            /*" -1076- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0303_00_START */

            P0303_00_START();

        }

        [StopWatch]
        /*" P0303-00-START */
        private void P0303_00_START(bool isPerform = false)
        {
            /*" -1078- MOVE 'P0303' TO WS-SECTION */
            _.Move("P0303", WORK.WS_ERRO.WS_SECTION);

            /*" -1079- DISPLAY WS-SECTION */
            _.Display(WORK.WS_ERRO.WS_SECTION);

            /*" -1079- . */

        }

        [StopWatch]
        /*" P0303-05-INICIO */
        private void P0303_05_INICIO(bool isPerform = false)
        {
            /*" -1086- MOVE +1 TO SU1-NRDIAS */
            _.Move(+1, WORK.PARM_PROSOMU1.SU1_NRDIAS);

            /*" -1089- CALL 'PROSOCU1' USING PARM-PROSOMU1 */
            _.Call("PROSOCU1", WORK.PARM_PROSOMU1);

            /*" -1090- MOVE SU1-DATA2 TO SU1-DATA1 */
            _.Move(WORK.PARM_PROSOMU1.SU1_DATA2, WORK.PARM_PROSOMU1.SU1_DATA1);

            /*" -1090- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0303_99_EXIT*/

        [StopWatch]
        /*" P0310-CALCULAR-IND-ACUM-SECTION */
        private void P0310_CALCULAR_IND_ACUM_SECTION()
        {
            /*" -1100- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0310_00_START */

            P0310_00_START();

        }

        [StopWatch]
        /*" P0310-00-START */
        private void P0310_00_START(bool isPerform = false)
        {
            /*" -1103- MOVE 'P0310' TO WS-SECTION */
            _.Move("P0310", WORK.WS_ERRO.WS_SECTION);

            /*" -1104- MOVE ZEROS TO WDIAS-AUX */
            _.Move(0, WORK.WDIAS_AUX);

            /*" -1104- PERFORM P0310-05-INICIO. */

            P0310_05_INICIO(true);

        }

        [StopWatch]
        /*" P0310-05-INICIO */
        private void P0310_05_INICIO(bool isPerform = false)
        {
            /*" -1111- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -1150- COMPUTE WDIAS-TOTAL = TB-ULT-DIA(MES-INI) + WDIAS-TOTAL */
            WORK.WDIAS_TOTAL.Value = TB_ULTIMOS_DIAS.TB_DIA_MESES[WORK.DATA_INI.MES_INI].TB_ULT_DIA.Value + WORK.WDIAS_TOTAL;

            /*" -1152- MOVE WSNOVO-DIAS TO WDIAS-PRORATA */
            _.Move(WORK.WSNOVO_DIAS, WORK.WDIAS_PRORATA);

            /*" -1154- PERFORM P0311-SEARCH-INDICE */

            P0311_SEARCH_INDICE_SECTION();

            /*" -1156- MOVE WS-VL-INDICE TO WS-TAXA(01) */
            _.Move(WORK.WS_VL_INDICE, WORK.WS_EDIT.WS_TAXA[01]);

            /*" -1157- IF WS-VL-INDICE < ZEROS */

            if (WORK.WS_VL_INDICE < 00)
            {

                /*" -1158- MOVE ZEROS TO WS-VL-INDICE */
                _.Move(0, WORK.WS_VL_INDICE);

                /*" -1159- ELSE */
            }
            else
            {


                /*" -1160- COMPUTE WS-VL-INDICE = WS-VL-INDICE / 100 */
                WORK.WS_VL_INDICE.Value = WORK.WS_VL_INDICE / 100f;

                /*" -1162- END-IF */
            }


            /*" -1163- IF WS-VL-INDICE < 1 */

            if (WORK.WS_VL_INDICE < 1)
            {

                /*" -1164- COMPUTE WS-VL-INDICE = WS-VL-INDICE + 1 */
                WORK.WS_VL_INDICE.Value = WORK.WS_VL_INDICE + 1;

                /*" -1166- END-IF */
            }


            /*" -1168- MOVE WS-VL-INDICE TO WS-TAXA(02) */
            _.Move(WORK.WS_VL_INDICE, WORK.WS_EDIT.WS_TAXA[02]);

            /*" -1169- COMPUTE WS-IGPM-ACUM = WS-IGPM-ACUM * WS-VL-INDICE */
            WORK.WS_IGPM_ACUM.Value = WORK.WS_IGPM_ACUM * WORK.WS_VL_INDICE;

            /*" -1171- MOVE WS-IGPM-ACUM TO WS-TAXA(03) */
            _.Move(WORK.WS_IGPM_ACUM, WORK.WS_EDIT.WS_TAXA[03]);

            /*" -1172- DISPLAY 'VL-IND-TAB   >>> ' WS-TAXA(01) */
            _.Display($"VL-IND-TAB   >>> {WORK.WS_EDIT.WS_TAXA[1]}");

            /*" -1173- DISPLAY 'VL-INDICE    >>> ' WS-TAXA(02) */
            _.Display($"VL-INDICE    >>> {WORK.WS_EDIT.WS_TAXA[2]}");

            /*" -1174- DISPLAY 'IGPM-ACUM    >>> ' WS-TAXA(03) */
            _.Display($"IGPM-ACUM    >>> {WORK.WS_EDIT.WS_TAXA[3]}");

            /*" -1175- DISPLAY 'DIAS-TOTAL   >>> ' WDIAS-TOTAL */
            _.Display($"DIAS-TOTAL   >>> {WORK.WDIAS_TOTAL}");

            /*" -1176- DISPLAY 'DIAS-PRORATA >>> ' WDIAS-PRORATA */
            _.Display($"DIAS-PRORATA >>> {WORK.WDIAS_PRORATA}");

            /*" -1176- PERFORM P0310-10-PULAR. */

            P0310_10_PULAR(true);

        }

        [StopWatch]
        /*" P0310-10-PULAR */
        private void P0310_10_PULAR(bool isPerform = false)
        {
            /*" -1182- COMPUTE MES-INI = (MES-INI + 1). */
            WORK.DATA_INI.MES_INI.Value = (WORK.DATA_INI.MES_INI + 1);

            /*" -1183- IF MES-INI EQUAL 13 */

            if (WORK.DATA_INI.MES_INI == 13)
            {

                /*" -1184- MOVE 01 TO MES-INI */
                _.Move(01, WORK.DATA_INI.MES_INI);

                /*" -1185- COMPUTE ANO-INI = (ANO-INI + 1) */
                WORK.DATA_INI.ANO_INI.Value = (WORK.DATA_INI.ANO_INI + 1);

                /*" -1186- END-IF */
            }


            /*" -1186- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0310_99_EXIT*/

        [StopWatch]
        /*" P0311-SEARCH-INDICE-SECTION */
        private void P0311_SEARCH_INDICE_SECTION()
        {
            /*" -1197- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P3011_00_START */

            P3011_00_START();

        }

        [StopWatch]
        /*" P3011-00-START */
        private void P3011_00_START(bool isPerform = false)
        {
            /*" -1200- MOVE 'P3011' TO WS-SECTION */
            _.Move("P3011", WORK.WS_ERRO.WS_SECTION);

            /*" -1201- COMPUTE WS-MES-SEARCH = MES-INI - 1 */
            WORK.WS_DT_SEARCH.WS_MMAA_SEARCH.WS_MES_SEARCH.Value = WORK.DATA_INI.MES_INI - 1;

            /*" -1203- MOVE ANO-INI TO WS-ANO-SEARCH */
            _.Move(WORK.DATA_INI.ANO_INI, WORK.WS_DT_SEARCH.WS_MMAA_SEARCH.WS_ANO_SEARCH);

            /*" -1204- IF WS-MES-SEARCH < 1 */

            if (WORK.WS_DT_SEARCH.WS_MMAA_SEARCH.WS_MES_SEARCH < 1)
            {

                /*" -1205- MOVE 12 TO WS-MES-SEARCH */
                _.Move(12, WORK.WS_DT_SEARCH.WS_MMAA_SEARCH.WS_MES_SEARCH);

                /*" -1206- COMPUTE WS-ANO-SEARCH = WS-ANO-SEARCH - 1 */
                WORK.WS_DT_SEARCH.WS_MMAA_SEARCH.WS_ANO_SEARCH.Value = WORK.WS_DT_SEARCH.WS_MMAA_SEARCH.WS_ANO_SEARCH - 1;

                /*" -1208- END-IF */
            }


            /*" -1209- MOVE ZEROS TO WS-QTD-SEARCH */
            _.Move(0, WORK.WS_QTD_SEARCH);

            /*" -1210- MOVE ZEROS TO WS-VL-INDICE */
            _.Move(0, WORK.WS_VL_INDICE);

            /*" -1210- . */

        }

        [StopWatch]
        /*" P3011-05-INICIO */
        private void P3011_05_INICIO(bool isPerform = false)
        {
            /*" -1217- SET IXB5 TO +1 */
            IXB5.Value = +1;

            /*" -1219- SEARCH TABELA-IGPM AT END */
            void SearchAtEnd0()
            {

                /*" -1220- MOVE 'N' TO IND-ACHOU */
                _.Move("N", WORK.IND_ACHOU);

                /*" -1221- WHEN TB-DATA-IGPM(IXB5) = WS-MMAA-SEARCH */
            };

            var mustSearchAtEnd0 = true;
            for (; IXB5 < WORK.TABELA_IGPM.Items.Count; IXB5.Value++)
            {

                if (WORK.TABELA_IGPM[IXB5].TB_DATA_IGPM == WORK.WS_DT_SEARCH.WS_MMAA_SEARCH)
                {

                    mustSearchAtEnd0 = false;

                    /*" -1222- MOVE 'S' TO IND-ACHOU */
                    _.Move("S", WORK.IND_ACHOU);

                    /*" -1223- MOVE TB-VAL-IGPM(IXB5) TO WS-VL-INDICE */
                    _.Move(WORK.TABELA_IGPM[IXB5].TB_VAL_IGPM, WORK.WS_VL_INDICE);

                    /*" -1223- END-SEARCH. */
                    break;
                }
            }

            if (mustSearchAtEnd0)
                SearchAtEnd0();

            /*" -1226- IF IND-ACHOU EQUAL 'N' */

            if (WORK.IND_ACHOU == "N")
            {

                /*" -1228- ADD 1 TO WS-QTD-SEARCH */
                WORK.WS_QTD_SEARCH.Value = WORK.WS_QTD_SEARCH + 1;

                /*" -1229- IF W0CODTSQLINI(1:7) EQUAL W0CODTSQLFIM(1:7) */

                if (WORK.W0CODTSQLINI.Substring(1, 7) == WORK.W0CODTSQLFIM.Substring(1, 7))
                {

                    /*" -1230- IF WS-QTD-SEARCH < 6 */

                    if (WORK.WS_QTD_SEARCH < 6)
                    {

                        /*" -1231- COMPUTE WS-MES-SEARCH = WS-MES-SEARCH - 1 */
                        WORK.WS_DT_SEARCH.WS_MMAA_SEARCH.WS_MES_SEARCH.Value = WORK.WS_DT_SEARCH.WS_MMAA_SEARCH.WS_MES_SEARCH - 1;

                        /*" -1232- IF WS-MES-SEARCH < 1 */

                        if (WORK.WS_DT_SEARCH.WS_MMAA_SEARCH.WS_MES_SEARCH < 1)
                        {

                            /*" -1233- MOVE 12 TO WS-MES-SEARCH */
                            _.Move(12, WORK.WS_DT_SEARCH.WS_MMAA_SEARCH.WS_MES_SEARCH);

                            /*" -1234- COMPUTE WS-ANO-SEARCH = WS-ANO-SEARCH - 1 */
                            WORK.WS_DT_SEARCH.WS_MMAA_SEARCH.WS_ANO_SEARCH.Value = WORK.WS_DT_SEARCH.WS_MMAA_SEARCH.WS_ANO_SEARCH - 1;

                            /*" -1235- END-IF */
                        }


                        /*" -1236- GO TO P3011-05-INICIO */
                        new Task(() => P3011_05_INICIO()).RunSynchronously(); //GOTO
                        return;//Recursividade detectada, cuidado...

                        /*" -1237- ELSE */
                    }
                    else
                    {


                        /*" -1238- MOVE 'P8010' TO WS-SECTION */
                        _.Move("P8010", WORK.WS_ERRO.WS_SECTION);

                        /*" -1239- MOVE 1 TO WS-IND-ERRO */
                        _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                        /*" -1240- MOVE MOEDACOT-COD-MOEDA TO WS-SMALLINT(01) */
                        _.Move(MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_COD_MOEDA, WORK.WS_EDIT.WS_SMALLINT[01]);

                        /*" -1241- MOVE WS-MES-SEARCH TO WS-SMALLINT(02) */
                        _.Move(WORK.WS_DT_SEARCH.WS_MMAA_SEARCH.WS_MES_SEARCH, WORK.WS_EDIT.WS_SMALLINT[02]);

                        /*" -1242- MOVE WS-ANO-SEARCH TO WS-SMALLINT(03) */
                        _.Move(WORK.WS_DT_SEARCH.WS_MMAA_SEARCH.WS_ANO_SEARCH, WORK.WS_EDIT.WS_SMALLINT[03]);

                        /*" -1249- STRING WS-SECTION ' - NAO EXISTE CONTACAO PARA MOEDA: ' 'ENVIAR E-MAIL P/ PEDIR CADASTRO DE COTACAO.' '<COD-MOEDA=' WS-SMALLINT(01) '>' '<MES-CONSULTA=' WS-SMALLINT(02) '>' '<ANO-CONSULTA=' WS-SMALLINT(03) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                        #region STRING
                        var spl42 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                        spl42 += " - NAO EXISTE CONTACAO PARA MOEDA: ";
                        spl42 += "ENVIAR E-MAIL P/ PEDIR CADASTRO DE COTACAO.";
                        spl42 += "<COD-MOEDA=";
                        var spl43 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                        spl43 += ">";
                        spl43 += "<MES-CONSULTA=";
                        var spl44 = WORK.WS_EDIT.WS_SMALLINT[02].GetMoveValues();
                        spl44 += ">";
                        spl44 += "<ANO-CONSULTA=";
                        var spl45 = WORK.WS_EDIT.WS_SMALLINT[03].GetMoveValues();
                        spl45 += ">";
                        var results46 = spl42 + spl43 + spl44 + spl45;
                        _.Move(results46, WORK.WS_ERRO.WS_MENSAGEM);
                        #endregion

                        /*" -1250- MOVE 'SEGUROS.MOEDAS_COTACAO' TO WS-TABELA */
                        _.Move("SEGUROS.MOEDAS_COTACAO", WORK.WS_ERRO.WS_TABELA);

                        /*" -1251- MOVE SQLCODE TO WS-SQLCODE */
                        _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                        /*" -1252- MOVE SQLERRMC TO WS-SQLERRMC */
                        _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                        /*" -1253- GO TO P9999-ERRO */

                        P9999_ERRO_SECTION(); //GOTO
                        return;

                        /*" -1254- END-IF */
                    }


                    /*" -1255- END-IF */
                }


                /*" -1256- END-IF */
            }


            /*" -1256- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P3011_99_EXIT*/

        [StopWatch]
        /*" P3021-CONS-VGINDICE-SECTION */
        private void P3021_CONS_VGINDICE_SECTION()
        {
            /*" -1266- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P3021_00_START */

            P3021_00_START();

        }

        [StopWatch]
        /*" P3021-00-START */
        private void P3021_00_START(bool isPerform = false)
        {
            /*" -1269- MOVE 'P3021' TO WS-SECTION */
            _.Move("P3021", WORK.WS_ERRO.WS_SECTION);

            /*" -1270- MOVE LK-VG011-E-NUM-APOLICE TO RELATORI-NUM-APOLICE */
            _.Move(SPVG011W.LK_VG011_E_NUM_APOLICE, RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE);

            /*" -1271- MOVE LK-VG011-E-COD-SUBGRUPO TO RELATORI-COD-SUBGRUPO */
            _.Move(SPVG011W.LK_VG011_E_COD_SUBGRUPO, RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO);

            /*" -1271- PERFORM P3021-05-INICIO. */

            P3021_05_INICIO(true);

        }

        [StopWatch]
        /*" P3021-05-INICIO */
        private void P3021_05_INICIO(bool isPerform = false)
        {
            /*" -1284- PERFORM P3021_05_INICIO_DB_SELECT_1 */

            P3021_05_INICIO_DB_SELECT_1();

            /*" -1287- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -1288- MOVE 'P3021' TO WS-SECTION */
                _.Move("P3021", WORK.WS_ERRO.WS_SECTION);

                /*" -1289- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -1290- MOVE RELATORI-NUM-APOLICE TO WS-INTEGER(01) */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE, WORK.WS_EDIT.WS_INTEGER[01]);

                /*" -1291- MOVE RELATORI-COD-SUBGRUPO TO WS-INTEGER(02) */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO, WORK.WS_EDIT.WS_INTEGER[02]);

                /*" -1296- STRING WS-SECTION ' - ERRO NO SELECT SEGUROS.VG_INDICES.' '<NUM-APOLICE=' WS-INTEGER(01) '>' '<COD-SUBGRUPO=' WS-INTEGER(02) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl46 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl46 += " - ERRO NO SELECT SEGUROS.VG_INDICES.";
                spl46 += "<NUM-APOLICE=";
                var spl47 = WORK.WS_EDIT.WS_INTEGER[01].GetMoveValues();
                spl47 += ">";
                spl47 += "<COD-SUBGRUPO=";
                var spl48 = WORK.WS_EDIT.WS_INTEGER[02].GetMoveValues();
                spl48 += ">";
                var results49 = spl46 + spl47 + spl48;
                _.Move(results49, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -1297- MOVE 'SEGUROS.VG_INDICES' TO WS-TABELA */
                _.Move("SEGUROS.VG_INDICES", WORK.WS_ERRO.WS_TABELA);

                /*" -1298- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -1299- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -1300- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1302- END-IF */
            }


            /*" -1303- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1304- MOVE 'P3021' TO WS-SECTION */
                _.Move("P3021", WORK.WS_ERRO.WS_SECTION);

                /*" -1305- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -1306- MOVE RELATORI-NUM-APOLICE TO WS-INTEGER(01) */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE, WORK.WS_EDIT.WS_INTEGER[01]);

                /*" -1307- MOVE RELATORI-COD-SUBGRUPO TO WS-INTEGER(02) */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO, WORK.WS_EDIT.WS_INTEGER[02]);

                /*" -1312- STRING WS-SECTION ' - APOLICE/SUBGRUPO COM INDICE NAO CADASTRADO.' '<NUM-APOLICE=' WS-INTEGER(01) '>' '<COD-SUBGRUPO=' WS-INTEGER(02) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl49 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl49 += " - APOLICE/SUBGRUPO COM INDICE NAO CADASTRADO.";
                spl49 += "<NUM-APOLICE=";
                var spl50 = WORK.WS_EDIT.WS_INTEGER[01].GetMoveValues();
                spl50 += ">";
                spl50 += "<COD-SUBGRUPO=";
                var spl51 = WORK.WS_EDIT.WS_INTEGER[02].GetMoveValues();
                spl51 += ">";
                var results52 = spl49 + spl50 + spl51;
                _.Move(results52, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -1313- MOVE 'SEGUROS.VG_INDICES' TO WS-TABELA */
                _.Move("SEGUROS.VG_INDICES", WORK.WS_ERRO.WS_TABELA);

                /*" -1314- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -1315- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -1316- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1318- END-IF */
            }


            /*" -1319- MOVE VG077-COD-MOEDA TO MOEDA */
            _.Move(VG077.DCLVG_INDICES.VG077_COD_MOEDA, WORK.MOEDA);

            /*" -1319- . */

        }

        [StopWatch]
        /*" P3021-05-INICIO-DB-SELECT-1 */
        public void P3021_05_INICIO_DB_SELECT_1()
        {
            /*" -1284- EXEC SQL SELECT COD_MOEDA INTO :VG077-COD-MOEDA FROM SEGUROS.VG_INDICES WHERE NUM_APOLICE = :RELATORI-NUM-APOLICE AND COD_SUBGRUPO = :RELATORI-COD-SUBGRUPO AND DTH_TERVIGENCIA = '9999-12-31' WITH UR END-EXEC */

            var p3021_05_INICIO_DB_SELECT_1_Query1 = new P3021_05_INICIO_DB_SELECT_1_Query1()
            {
                RELATORI_COD_SUBGRUPO = RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO.ToString(),
                RELATORI_NUM_APOLICE = RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE.ToString(),
            };

            var executed_1 = P3021_05_INICIO_DB_SELECT_1_Query1.Execute(p3021_05_INICIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VG077_COD_MOEDA, VG077.DCLVG_INDICES.VG077_COD_MOEDA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P3021_99_EXIT*/

        [StopWatch]
        /*" P3022-CONS-PRODUTO-MOEDA-SECTION */
        private void P3022_CONS_PRODUTO_MOEDA_SECTION()
        {
            /*" -1329- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P3022_00_START */

            P3022_00_START();

        }

        [StopWatch]
        /*" P3022-00-START */
        private void P3022_00_START(bool isPerform = false)
        {
            /*" -1332- MOVE 'P3022' TO WS-SECTION */
            _.Move("P3022", WORK.WS_ERRO.WS_SECTION);

            /*" -1333- MOVE LK-VG011-E-COD-PRODUTO TO GE252-COD-PRODUTO */
            _.Move(SPVG011W.LK_VG011_E_COD_PRODUTO, GE252.DCLGE_PRODUTO_MOEDA.GE252_COD_PRODUTO);

            /*" -1333- PERFORM P3022-05-INICIO. */

            P3022_05_INICIO(true);

        }

        [StopWatch]
        /*" P3022-05-INICIO */
        private void P3022_05_INICIO(bool isPerform = false)
        {
            /*" -1346- PERFORM P3022_05_INICIO_DB_SELECT_1 */

            P3022_05_INICIO_DB_SELECT_1();

            /*" -1349- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -1350- MOVE 'P3022' TO WS-SECTION */
                _.Move("P3022", WORK.WS_ERRO.WS_SECTION);

                /*" -1351- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -1352- MOVE GE252-COD-PRODUTO TO WS-INTEGER(01) */
                _.Move(GE252.DCLGE_PRODUTO_MOEDA.GE252_COD_PRODUTO, WORK.WS_EDIT.WS_INTEGER[01]);

                /*" -1356- STRING WS-SECTION ' - ERRO NO SELECT SEGUROS.GE_PRODUTO_MOEDA.' '<COD-PRODUTO=' WS-INTEGER(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl52 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl52 += " - ERRO NO SELECT SEGUROS.GE_PRODUTO_MOEDA.";
                spl52 += "<COD-PRODUTO=";
                var spl53 = WORK.WS_EDIT.WS_INTEGER[01].GetMoveValues();
                spl53 += ">";
                var results54 = spl52 + spl53;
                _.Move(results54, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -1357- MOVE 'SEGUROS.GE_PRODUTO_MOEDA' TO WS-TABELA */
                _.Move("SEGUROS.GE_PRODUTO_MOEDA", WORK.WS_ERRO.WS_TABELA);

                /*" -1358- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -1359- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -1360- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1362- END-IF */
            }


            /*" -1363- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1364- MOVE 'P3022' TO WS-SECTION */
                _.Move("P3022", WORK.WS_ERRO.WS_SECTION);

                /*" -1365- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -1366- MOVE GE252-COD-PRODUTO TO WS-INTEGER(01) */
                _.Move(GE252.DCLGE_PRODUTO_MOEDA.GE252_COD_PRODUTO, WORK.WS_EDIT.WS_INTEGER[01]);

                /*" -1370- STRING WS-SECTION ' - INDICE NAO CADASTRADO PARA O PRODUTO' '<COD-PRODUTO=' WS-INTEGER(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl54 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl54 += " - INDICE NAO CADASTRADO PARA O PRODUTO";
                spl54 += "<COD-PRODUTO=";
                var spl55 = WORK.WS_EDIT.WS_INTEGER[01].GetMoveValues();
                spl55 += ">";
                var results56 = spl54 + spl55;
                _.Move(results56, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -1371- MOVE 'SEGUROS.GE_PRODUTO_MOEDA' TO WS-TABELA */
                _.Move("SEGUROS.GE_PRODUTO_MOEDA", WORK.WS_ERRO.WS_TABELA);

                /*" -1372- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -1373- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -1374- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1376- END-IF */
            }


            /*" -1377- MOVE GE252-COD-MOEDA TO MOEDA */
            _.Move(GE252.DCLGE_PRODUTO_MOEDA.GE252_COD_MOEDA, WORK.MOEDA);

            /*" -1377- . */

        }

        [StopWatch]
        /*" P3022-05-INICIO-DB-SELECT-1 */
        public void P3022_05_INICIO_DB_SELECT_1()
        {
            /*" -1346- EXEC SQL SELECT COD_MOEDA , PCT_JUROS INTO :GE252-COD-MOEDA , :GE252-PCT-JUROS FROM SEGUROS.GE_PRODUTO_MOEDA WHERE COD_PRODUTO = :GE252-COD-PRODUTO AND DTA_FIM_VIGENCIA = '9999-12-31' WITH UR END-EXEC */

            var p3022_05_INICIO_DB_SELECT_1_Query1 = new P3022_05_INICIO_DB_SELECT_1_Query1()
            {
                GE252_COD_PRODUTO = GE252.DCLGE_PRODUTO_MOEDA.GE252_COD_PRODUTO.ToString(),
            };

            var executed_1 = P3022_05_INICIO_DB_SELECT_1_Query1.Execute(p3022_05_INICIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE252_COD_MOEDA, GE252.DCLGE_PRODUTO_MOEDA.GE252_COD_MOEDA);
                _.Move(executed_1.GE252_PCT_JUROS, GE252.DCLGE_PRODUTO_MOEDA.GE252_PCT_JUROS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P3022_99_EXIT*/

        [StopWatch]
        /*" P0330-CALCULAR-MESES-SECTION */
        private void P0330_CALCULAR_MESES_SECTION()
        {
            /*" -1387- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0330_00_START */

            P0330_00_START();

        }

        [StopWatch]
        /*" P0330-00-START */
        private void P0330_00_START(bool isPerform = false)
        {
            /*" -1390- MOVE 'P0330' TO WS-SECTION */
            _.Move("P0330", WORK.WS_ERRO.WS_SECTION);

            /*" -1391- MOVE ZEROS TO WDIAS-AUX */
            _.Move(0, WORK.WDIAS_AUX);

            /*" -1391- PERFORM P0330-05-INICIO. */

            P0330_05_INICIO(true);

        }

        [StopWatch]
        /*" P0330-05-INICIO */
        private void P0330_05_INICIO(bool isPerform = false)
        {
            /*" -1398- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -1400- COMPUTE WDIAS-TOTAL = TB-ULT-DIA(MES-INI) + WDIAS-TOTAL */
            WORK.WDIAS_TOTAL.Value = TB_ULTIMOS_DIAS.TB_DIA_MESES[WORK.DATA_INI.MES_INI].TB_ULT_DIA.Value + WORK.WDIAS_TOTAL;

            /*" -1401- IF DATA-INI(1:7) EQUAL WDATA-INI(1:7) */

            if (WORK.DATA_INI.Substring(1, 7) == WORK.WDATA_INI.Substring(1, 7))
            {

                /*" -1402- IF DATA-INI(1:7) EQUAL DATA-FIM(1:7) */

                if (WORK.DATA_INI.Substring(1, 7) == WORK.DATA_FIM.Substring(1, 7))
                {

                    /*" -1403- COMPUTE WDIAS-AUX = (DIA-FIM - DIA-INI) + 1 */
                    WORK.WDIAS_AUX.Value = (WORK.DATA_FIM.DIA_FIM - WORK.DATA_INI.DIA_INI) + 1;

                    /*" -1405- DISPLAY '1I - ' DATA-INI(1:7) ' - QTD-DIAS >> ' WDIAS-AUX */

                    $"1I - DATA-INI(1:7) - QTD-DIAS >> {WORK.WDIAS_AUX}"
                    .Display();

                    /*" -1406- ELSE */
                }
                else
                {


                    /*" -1407- IF DIA-INI > 01 */

                    if (WORK.DATA_INI.DIA_INI > 01)
                    {

                        /*" -1409- COMPUTE WDIAS-AUX = (TB-ULT-DIA(MES-INI) - DIA-INI) */
                        WORK.WDIAS_AUX.Value = (TB_ULTIMOS_DIAS.TB_DIA_MESES[WORK.DATA_INI.MES_INI].TB_ULT_DIA.Value - WORK.DATA_INI.DIA_INI);

                        /*" -1410- ELSE */
                    }
                    else
                    {


                        /*" -1411- MOVE TB-ULT-DIA(MES-INI) TO WDIAS-AUX */
                        _.Move(TB_ULTIMOS_DIAS.TB_DIA_MESES[WORK.DATA_INI.MES_INI].TB_ULT_DIA, WORK.WDIAS_AUX);

                        /*" -1413- END-IF */
                    }


                    /*" -1415- DISPLAY '1E - ' DATA-INI(1:7) ' - QTD-DIAS >> ' WDIAS-AUX */

                    $"1E - DATA-INI(1:7) - QTD-DIAS >> {WORK.WDIAS_AUX}"
                    .Display();

                    /*" -1416- END-IF */
                }


                /*" -1417- ELSE */
            }
            else
            {


                /*" -1418- IF DATA-INI(1:7) EQUAL DATA-FIM(1:7) */

                if (WORK.DATA_INI.Substring(1, 7) == WORK.DATA_FIM.Substring(1, 7))
                {

                    /*" -1419- IF DIA-FIM < TB-ULT-DIA(MES-FIM) */

                    if (WORK.DATA_FIM.DIA_FIM < TB_ULTIMOS_DIAS.TB_DIA_MESES[WORK.DATA_FIM.MES_FIM].TB_ULT_DIA)
                    {

                        /*" -1420- MOVE DIA-FIM TO WDIAS-AUX */
                        _.Move(WORK.DATA_FIM.DIA_FIM, WORK.WDIAS_AUX);

                        /*" -1421- ELSE */
                    }
                    else
                    {


                        /*" -1422- MOVE TB-ULT-DIA(MES-INI) TO WDIAS-AUX */
                        _.Move(TB_ULTIMOS_DIAS.TB_DIA_MESES[WORK.DATA_INI.MES_INI].TB_ULT_DIA, WORK.WDIAS_AUX);

                        /*" -1423- END-IF */
                    }


                    /*" -1425- DISPLAY '2I - ' DATA-INI(1:7) ' - QTD-DIAS >> ' WDIAS-AUX */

                    $"2I - DATA-INI(1:7) - QTD-DIAS >> {WORK.WDIAS_AUX}"
                    .Display();

                    /*" -1426- ELSE */
                }
                else
                {


                    /*" -1427- MOVE TB-ULT-DIA(MES-INI) TO WDIAS-AUX */
                    _.Move(TB_ULTIMOS_DIAS.TB_DIA_MESES[WORK.DATA_INI.MES_INI].TB_ULT_DIA, WORK.WDIAS_AUX);

                    /*" -1429- DISPLAY '2E - ' DATA-INI(1:7) ' - QTD-DIAS >> ' WDIAS-AUX */

                    $"2E - DATA-INI(1:7) - QTD-DIAS >> {WORK.WDIAS_AUX}"
                    .Display();

                    /*" -1430- END-IF */
                }


                /*" -1432- END-IF */
            }


            /*" -1433- COMPUTE WDIAS-PRORATA = WDIAS-AUX + WDIAS-PRORATA */
            WORK.WDIAS_PRORATA.Value = WORK.WDIAS_AUX + WORK.WDIAS_PRORATA;

            /*" -1433- PERFORM P0330-10-PULAR. */

            P0330_10_PULAR(true);

        }

        [StopWatch]
        /*" P0330-10-PULAR */
        private void P0330_10_PULAR(bool isPerform = false)
        {
            /*" -1438- IF DATA-INI(1:7) NOT EQUAL DATA-INI-ANT(1:7) */

            if (WORK.DATA_INI.Substring(1, 7) != WORK.DATA_INI_ANT.Substring(1, 7))
            {

                /*" -1439- MOVE DATA-INI TO DATA-INI-ANT */
                _.Move(WORK.DATA_INI, WORK.DATA_INI_ANT);

                /*" -1440- ADD 1 TO WS-QTD-MESES */
                WORK.WS_QTD_MESES.Value = WORK.WS_QTD_MESES + 1;

                /*" -1442- END-IF */
            }


            /*" -1444- COMPUTE MES-INI = (MES-INI + 1). */
            WORK.DATA_INI.MES_INI.Value = (WORK.DATA_INI.MES_INI + 1);

            /*" -1445- IF MES-INI EQUAL 13 */

            if (WORK.DATA_INI.MES_INI == 13)
            {

                /*" -1446- MOVE 01 TO MES-INI */
                _.Move(01, WORK.DATA_INI.MES_INI);

                /*" -1447- COMPUTE ANO-INI = (ANO-INI + 1) */
                WORK.DATA_INI.ANO_INI.Value = (WORK.DATA_INI.ANO_INI + 1);

                /*" -1448- END-IF */
            }


            /*" -1448- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0330_99_EXIT*/

        [StopWatch]
        /*" P8000-OPEN-TCOTAC-SECTION */
        private void P8000_OPEN_TCOTAC_SECTION()
        {
            /*" -1459- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P8000_00_START */

            P8000_00_START();

        }

        [StopWatch]
        /*" P8000-00-START */
        private void P8000_00_START(bool isPerform = false)
        {
            /*" -1462- MOVE 'P8000' TO WS-SECTION */
            _.Move("P8000", WORK.WS_ERRO.WS_SECTION);

            /*" -1462- PERFORM P8000-05-INICIO. */

            P8000_05_INICIO(true);

        }

        [StopWatch]
        /*" P8000-05-INICIO */
        private void P8000_05_INICIO(bool isPerform = false)
        {
            /*" -1468- PERFORM P8000_05_INICIO_DB_OPEN_1 */

            P8000_05_INICIO_DB_OPEN_1();

            /*" -1472- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -1473- MOVE 'P8000' TO WS-SECTION */
                _.Move("P8000", WORK.WS_ERRO.WS_SECTION);

                /*" -1474- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -1475- MOVE MOEDACOT-COD-MOEDA TO WS-SMALLINT(01) */
                _.Move(MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_COD_MOEDA, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -1476- MOVE WDATA-CONSULTA TO WS-SMALLINT(02) */
                _.Move(WORK.WDATA_CONSULTA, WORK.WS_EDIT.WS_SMALLINT[02]);

                /*" -1481- STRING WS-SECTION ' - ERRO NO OPEN CURSOR TCOTAC.' '<COD-MOEDA  =' WS-SMALLINT(01) '>' '<DT CONSULTA=' WS-SMALLINT(02) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl56 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl56 += " - ERRO NO OPEN CURSOR TCOTAC.";
                spl56 += "<COD-MOEDA =";
                var spl57 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl57 += ">";
                spl57 += "<DT CONSULTA=";
                var spl58 = WORK.WS_EDIT.WS_SMALLINT[02].GetMoveValues();
                spl58 += ">";
                var results59 = spl56 + spl57 + spl58;
                _.Move(results59, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -1482- MOVE 'SEGUROS.MOEDAS_COTACAO' TO WS-TABELA */
                _.Move("SEGUROS.MOEDAS_COTACAO", WORK.WS_ERRO.WS_TABELA);

                /*" -1483- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -1484- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -1485- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1486- END-IF */
            }


            /*" -1486- . */

        }

        [StopWatch]
        /*" P8000-05-INICIO-DB-OPEN-1 */
        public void P8000_05_INICIO_DB_OPEN_1()
        {
            /*" -1468- EXEC SQL OPEN TCOTAC END-EXEC. */

            TCOTAC.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P8000_99_EXIT*/

        [StopWatch]
        /*" P8001-CLOSE-TCOTAC-SECTION */
        private void P8001_CLOSE_TCOTAC_SECTION()
        {
            /*" -1496- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P8001_00_START */

            P8001_00_START();

        }

        [StopWatch]
        /*" P8001-00-START */
        private void P8001_00_START(bool isPerform = false)
        {
            /*" -1499- MOVE 'P8001' TO WS-SECTION. */
            _.Move("P8001", WORK.WS_ERRO.WS_SECTION);

            /*" -1499- PERFORM P8001-05-INICIO. */

            P8001_05_INICIO(true);

        }

        [StopWatch]
        /*" P8001-05-INICIO */
        private void P8001_05_INICIO(bool isPerform = false)
        {
            /*" -1503- PERFORM P8001_05_INICIO_DB_CLOSE_1 */

            P8001_05_INICIO_DB_CLOSE_1();

            /*" -1505- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -1506- MOVE 'P8001' TO WS-SECTION */
                _.Move("P8001", WORK.WS_ERRO.WS_SECTION);

                /*" -1507- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -1508- MOVE MOEDACOT-COD-MOEDA TO WS-SMALLINT(01) */
                _.Move(MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_COD_MOEDA, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -1512- STRING WS-SECTION ' - ERRO NO CLOSE CURSOR TCOTAC.' '<COD-MOEDA=' WS-SMALLINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl59 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl59 += " - ERRO NO CLOSE CURSOR TCOTAC.";
                spl59 += "<COD-MOEDA=";
                var spl60 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl60 += ">";
                var results61 = spl59 + spl60;
                _.Move(results61, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -1513- MOVE 'SEGUROS.MOEDAS_COTACAO' TO WS-TABELA */
                _.Move("SEGUROS.MOEDAS_COTACAO", WORK.WS_ERRO.WS_TABELA);

                /*" -1514- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -1515- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -1516- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1517- END-IF */
            }


            /*" -1517- . */

        }

        [StopWatch]
        /*" P8001-05-INICIO-DB-CLOSE-1 */
        public void P8001_05_INICIO_DB_CLOSE_1()
        {
            /*" -1503- EXEC SQL CLOSE TCOTAC END-EXEC. */

            TCOTAC.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P8001_99_EXIT*/

        [StopWatch]
        /*" P8010-CARREGAR-TAB-INDICE-SECTION */
        private void P8010_CARREGAR_TAB_INDICE_SECTION()
        {
            /*" -1527- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P8010_00_START */

            P8010_00_START();

        }

        [StopWatch]
        /*" P8010-00-START */
        private void P8010_00_START(bool isPerform = false)
        {
            /*" -1530- MOVE 'P8010' TO WS-SECTION */
            _.Move("P8010", WORK.WS_ERRO.WS_SECTION);

            /*" -1532- SUBTRACT 1 FROM WANO-CONSULTA */
            WORK.WDATA_REDEF.WANO_CONSULTA.Value = WORK.WDATA_REDEF.WANO_CONSULTA - 1;

            /*" -1533- IF WMES-CONSULTA EQUAL 02 */

            if (WORK.WDATA_REDEF.WMES_CONSULTA == 02)
            {

                /*" -1534- IF WDIA-CONSULTA GREATER 27 */

                if (WORK.WDATA_REDEF.WDIA_CONSULTA > 27)
                {

                    /*" -1535- COMPUTE WANO-BISSEXTO = WANO-CONSULTA / 4 */
                    WORK.WANO_BISSEXTO.Value = WORK.WDATA_REDEF.WANO_CONSULTA / 4;

                    /*" -1536- COMPUTE WANO-BISSEXTO = WANO-BISSEXTO * 4 */
                    WORK.WANO_BISSEXTO.Value = WORK.WANO_BISSEXTO * 4;

                    /*" -1537- IF WANO-BISSEXTO EQUAL WANO-CONSULTA */

                    if (WORK.WANO_BISSEXTO == WORK.WDATA_REDEF.WANO_CONSULTA)
                    {

                        /*" -1538- MOVE 29 TO WDIA-CONSULTA */
                        _.Move(29, WORK.WDATA_REDEF.WDIA_CONSULTA);

                        /*" -1539- ELSE */
                    }
                    else
                    {


                        /*" -1540- MOVE 28 TO WDIA-CONSULTA */
                        _.Move(28, WORK.WDATA_REDEF.WDIA_CONSULTA);

                        /*" -1541- END-IF */
                    }


                    /*" -1542- END-IF */
                }


                /*" -1544- END-IF */
            }


            /*" -1547- INITIALIZE MOEDACOT-DATA-INIVIGENCIA MOEDACOT-VAL-VENDA */
            _.Initialize(
                MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_DATA_INIVIGENCIA
                , MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_VENDA
            );

            /*" -1548- MOVE MOEDA TO MOEDACOT-COD-MOEDA */
            _.Move(WORK.MOEDA, MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_COD_MOEDA);

            /*" -1549- MOVE ZEROS TO IND1 */
            _.Move(0, WORK.IND1);

            /*" -1551- SET IXB5 TO +1 */
            IXB5.Value = +1;

            /*" -1552- PERFORM P8000-OPEN-TCOTAC */

            P8000_OPEN_TCOTAC_SECTION();

            /*" -1552- . */

        }

        [StopWatch]
        /*" P8010-05-INICIO */
        private void P8010_05_INICIO(bool isPerform = false)
        {
            /*" -1560- PERFORM P8010_05_INICIO_DB_FETCH_1 */

            P8010_05_INICIO_DB_FETCH_1();

            /*" -1563- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -1564- MOVE 'P8010' TO WS-SECTION */
                _.Move("P8010", WORK.WS_ERRO.WS_SECTION);

                /*" -1565- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -1566- MOVE MOEDACOT-COD-MOEDA TO WS-SMALLINT(01) */
                _.Move(MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_COD_MOEDA, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -1571- STRING WS-SECTION ' - ERRO NO FETCH CURSOR TCOTAC.' '<COD-MOEDA=' WS-SMALLINT(01) '>' '<DTA-INI-CALCULO=' WDATA-CONSULTA '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl61 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl61 += " - ERRO NO FETCH CURSOR TCOTAC.";
                spl61 += "<COD-MOEDA=";
                var spl62 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl62 += ">";
                spl62 += "<DTA-INI-CALCULO=";
                var spl63 = WORK.WDATA_CONSULTA.GetMoveValues();
                spl63 += ">";
                var results64 = spl61 + spl62 + spl63;
                _.Move(results64, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -1572- MOVE 'SEGUROS.MOEDAS_COTACAO' TO WS-TABELA */
                _.Move("SEGUROS.MOEDAS_COTACAO", WORK.WS_ERRO.WS_TABELA);

                /*" -1573- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -1574- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -1575- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1577- END-IF */
            }


            /*" -1578- IF SQLCODE EQUAL +100 */

            if (DB.SQLCODE == +100)
            {

                /*" -1580- PERFORM P8001-CLOSE-TCOTAC */

                P8001_CLOSE_TCOTAC_SECTION();

                /*" -1581- IF IXB5 > ZEROS */

                if (IXB5 > 00)
                {

                    /*" -1582- GO TO P8010-99-EXIT */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: P8010_99_EXIT*/ //GOTO
                    return;

                    /*" -1583- ELSE */
                }
                else
                {


                    /*" -1584- MOVE 'P8010' TO WS-SECTION */
                    _.Move("P8010", WORK.WS_ERRO.WS_SECTION);

                    /*" -1585- MOVE 1 TO WS-IND-ERRO */
                    _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                    /*" -1586- MOVE MOEDACOT-COD-MOEDA TO WS-SMALLINT(01) */
                    _.Move(MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_COD_MOEDA, WORK.WS_EDIT.WS_SMALLINT[01]);

                    /*" -1592- STRING WS-SECTION ' - NAO EXISTE CONTACAO PARA MOEDA: ' 'ENVIAR E-MAIL P/ PEDIR CADASTRO DE COTACAO.' '<COD-MOEDA=' WS-SMALLINT(01) '>' '<DTA-INI-CALCULO=' WDATA-CONSULTA '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                    #region STRING
                    var spl64 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                    spl64 += " - NAO EXISTE CONTACAO PARA MOEDA: ";
                    spl64 += "ENVIAR E-MAIL P/ PEDIR CADASTRO DE COTACAO.";
                    spl64 += "<COD-MOEDA=";
                    var spl65 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                    spl65 += ">";
                    spl65 += "<DTA-INI-CALCULO=";
                    var spl66 = WORK.WDATA_CONSULTA.GetMoveValues();
                    spl66 += ">";
                    var results67 = spl64 + spl65 + spl66;
                    _.Move(results67, WORK.WS_ERRO.WS_MENSAGEM);
                    #endregion

                    /*" -1593- MOVE 'SEGUROS.MOEDAS_COTACAO' TO WS-TABELA */
                    _.Move("SEGUROS.MOEDAS_COTACAO", WORK.WS_ERRO.WS_TABELA);

                    /*" -1594- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                    /*" -1595- MOVE SQLERRMC TO WS-SQLERRMC */
                    _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                    /*" -1596- GO TO P9999-ERRO */

                    P9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1597- END-IF */
                }


                /*" -1599- END-IF */
            }


            /*" -1600- MOVE MOEDACOT-COD-MOEDA TO MOEDA */
            _.Move(MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_COD_MOEDA, WORK.MOEDA);

            /*" -1602- MOVE MOEDACOT-VAL-VENDA TO WVAL-VENDA */
            _.Move(MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_VENDA, WORK.WVAL_VENDA);

            /*" -1604- ADD 1 TO WS-QTD-COTACAO */
            WORK.WS_QTD_COTACAO.Value = WORK.WS_QTD_COTACAO + 1;

            /*" -1605- IF IXB5 > 499 */

            if (IXB5 > 499)
            {

                /*" -1606- MOVE 'P8010' TO WS-SECTION */
                _.Move("P8010", WORK.WS_ERRO.WS_SECTION);

                /*" -1607- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -1608- MOVE MOEDACOT-COD-MOEDA TO WS-SMALLINT(01) */
                _.Move(MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_COD_MOEDA, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -1613- STRING WS-SECTION ' - ESTOURO DA TABELA DE IGPM/IPCA.' '<COD-MOEDA=' WS-SMALLINT(01) '>' '<DTA-INI-CALCULO=' WDATA-CONSULTA '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl67 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl67 += " - ESTOURO DA TABELA DE IGPM/IPCA.";
                spl67 += "<COD-MOEDA=";
                var spl68 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl68 += ">";
                spl68 += "<DTA-INI-CALCULO=";
                var spl69 = WORK.WDATA_CONSULTA.GetMoveValues();
                spl69 += ">";
                var results70 = spl67 + spl68 + spl69;
                _.Move(results70, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -1614- MOVE 'SEGUROS.MOEDAS_COTACAO' TO WS-TABELA */
                _.Move("SEGUROS.MOEDAS_COTACAO", WORK.WS_ERRO.WS_TABELA);

                /*" -1615- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -1616- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -1617- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1619- END-IF */
            }


            /*" -1620- MOVE MOEDACOT-DATA-INIVIGENCIA(6:2) TO TB-MES-IGPM(IXB5) */
            _.Move(MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_DATA_INIVIGENCIA.Substring(6, 2), WORK.TABELA_IGPM[IXB5].TB_DATA_IGPM_R.TB_MES_IGPM);

            /*" -1621- MOVE MOEDACOT-DATA-INIVIGENCIA(1:4) TO TB-ANO-IGPM(IXB5) */
            _.Move(MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_DATA_INIVIGENCIA.Substring(1, 4), WORK.TABELA_IGPM[IXB5].TB_DATA_IGPM_R.TB_ANO_IGPM);

            /*" -1623- MOVE MOEDACOT-VAL-VENDA TO TB-VAL-IGPM(IXB5) */
            _.Move(MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_VENDA, WORK.TABELA_IGPM[IXB5].TB_VAL_IGPM);

            /*" -1625- SET IXB5 UP BY +1 */
            IXB5.Value += +1;

            /*" -1626- GO TO P8010-05-INICIO */
            new Task(() => P8010_05_INICIO()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

            /*" -1626- . */

        }

        [StopWatch]
        /*" P8010-05-INICIO-DB-FETCH-1 */
        public void P8010_05_INICIO_DB_FETCH_1()
        {
            /*" -1560- EXEC SQL FETCH TCOTAC INTO :MOEDACOT-DATA-INIVIGENCIA, :MOEDACOT-VAL-VENDA END-EXEC. */

            if (TCOTAC.Fetch())
            {
                _.Move(TCOTAC.MOEDACOT_DATA_INIVIGENCIA, MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_DATA_INIVIGENCIA);
                _.Move(TCOTAC.MOEDACOT_VAL_VENDA, MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_VENDA);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P8010_99_EXIT*/

        [StopWatch]
        /*" P8020-INICIALIZA-TABELA-SECTION */
        private void P8020_INICIALIZA_TABELA_SECTION()
        {
            /*" -1636- ADD 1 TO WSXB5 */
            WSXB5.Value = WSXB5 + 1;

            /*" -1637- MOVE ZEROS TO TB-DATA-IGPM(WSXB5) TB-VAL-IGPM(WSXB5). */
            _.Move(0, WORK.TABELA_IGPM[WSXB5].TB_DATA_IGPM, WORK.TABELA_IGPM[WSXB5].TB_VAL_IGPM);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P80200_EXIT*/

        [StopWatch]
        /*" P9999-ERRO-SECTION */
        private void P9999_ERRO_SECTION()
        {
            /*" -1648- IF LK-VG011-E-TRACE = 'S' */

            if (SPVG011W.LK_VG011_E_TRACE == "S")
            {

                /*" -1649- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -1650- DISPLAY '*         E R R O    S P B V G 0 1 1         *' */
                _.Display($"*         E R R O    S P B V G 0 1 1         *");

                /*" -1651- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -1652- DISPLAY '* SECTION..........: ' WS-SECTION */
                _.Display($"* SECTION..........: {WORK.WS_ERRO.WS_SECTION}");

                /*" -1653- DISPLAY '* IND ERRO.........: ' WS-IND-ERRO */
                _.Display($"* IND ERRO.........: {WORK.WS_ERRO.WS_IND_ERRO}");

                /*" -1654- DISPLAY '* TABELA...........: ' WS-TABELA */
                _.Display($"* TABELA...........: {WORK.WS_ERRO.WS_TABELA}");

                /*" -1655- DISPLAY '* MENSAGEM.........: ' WS-MENSAGEM */
                _.Display($"* MENSAGEM.........: {WORK.WS_ERRO.WS_MENSAGEM}");

                /*" -1656- DISPLAY '* SQLCODE..........: ' WS-SQLCODE */
                _.Display($"* SQLCODE..........: {WORK.WS_ERRO.WS_SQLCODE}");

                /*" -1657- DISPLAY '* SQLERRMC.........: ' WS-SQLERRMC */
                _.Display($"* SQLERRMC.........: {WORK.WS_ERRO.WS_SQLERRMC}");

                /*" -1658- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -1660- END-IF */
            }


            /*" -1661- MOVE WS-IND-ERRO TO LK-VG011-IND-ERRO */
            _.Move(WORK.WS_ERRO.WS_IND_ERRO, SPVG011W.LK_VG011_IND_ERRO);

            /*" -1662- MOVE WS-MENSAGEM TO LK-VG011-MSG-ERRO */
            _.Move(WORK.WS_ERRO.WS_MENSAGEM, SPVG011W.LK_VG011_MSG_ERRO);

            /*" -1663- MOVE WS-TABELA TO LK-VG011-NOM-TABELA */
            _.Move(WORK.WS_ERRO.WS_TABELA, SPVG011W.LK_VG011_NOM_TABELA);

            /*" -1664- MOVE WS-SQLCODE TO LK-VG011-SQLCODE */
            _.Move(WORK.WS_ERRO.WS_SQLCODE, SPVG011W.LK_VG011_SQLCODE);

            /*" -1666- MOVE WS-SQLERRMC TO LK-VG011-SQLERRMC */
            _.Move(WORK.WS_ERRO.WS_SQLERRMC, SPVG011W.LK_VG011_SQLERRMC);

            /*" -1666- . */

            /*" -0- FLUXCONTROL_PERFORM P9999_99_EXIT */

            P9999_99_EXIT();

        }

        [StopWatch]
        /*" P9999-99-EXIT */
        private void P9999_99_EXIT(bool isPerform = false)
        {
            /*" -1669- GOBACK. */

            throw new GoBack();

        }
    }
}