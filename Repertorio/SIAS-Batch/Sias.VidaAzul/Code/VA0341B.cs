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
using Sias.VidaAzul.DB2.VA0341B;

namespace Code
{
    public class VA0341B
    {
        public bool IsCall { get; set; }

        public VA0341B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *  GERA FITA COM LANCAMENTOS DE CREDITO (DEVOLUCAO DE PREMIO POR *      */
        /*"      *           NAO ACEITACAO DO SEGURO)  CONVENIO 6090              *      */
        /*"      *                                                                *      */
        /*"      *                          ALEXANDRE FONSECA      02/10/97       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 08 - DEMANDA 214252                                   *      */
        /*"      *             - REDUCAO DO PRAZO DE DEVOLUCAO DE D+5 PARA D+2.   *      */
        /*"      *             - NAO USAR A CURRENT DATE, POIS O PROCESSAMENTO    *      */
        /*"      *               ESTA OCORRENDO DE MADRUGADA, POR ISSO, A DATA    *      */
        /*"      *               E UM DIA A MAIS QUE A DATA DE MOVIMENTO.         *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/11/2019 - CLAUDETE RADEL                               *      */
        /*"      *                                           PROCURE POR V.08     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 07 - CAD 148793 - EVOLUCAO NO PROCESSO DE RESTITUICAO *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/09/2017 - MARCUS VALERIO                               *      */
        /*"      *                                           PROCURE POR V.07     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 06 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   AJUSTE LAYOUT ARQUIVO MOVIMENTO (MVDP6090 OUTROSBC)          *      */
        /*"      *   EM 20/07/2015 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.06         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 05 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 01/12/2014 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.05         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 04 - CAD 78.822   - OCORRENCIA DE FALHA               *      */
        /*"      *                                                                *      */
        /*"      *   EM 28/01/2013 - CLOVIS                                       *      */
        /*"      *                                           PROCURE POR V.04     *      */
        /*"      *                                                                *      */
        /*"      *-----------------------------------------------------------------      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 03 - CAD 78.726   - OCORRENCIA DE FALHA               *      */
        /*"      *                                                                *      */
        /*"      *   EM 24/01/2013 - CLOVIS                                       *      */
        /*"      *                                           PROCURE POR V.03     *      */
        /*"      *                                                                *      */
        /*"      *-----------------------------------------------------------------      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 02 - CAD 68.048   - AJUSTE PARA LIBERAR PAGAMENTOS    *      */
        /*"      *                                                                *      */
        /*"      *   EM 23/01/2013 - CLOVIS                                       *      */
        /*"      *                                           PROCURE POR V.02     *      */
        /*"      *                                                                *      */
        /*"      *-----------------------------------------------------------------      */
        /*"      * HEIDER COELHO - ABRIL 2012 - PROCURAR V.01                            */
        /*"      *                                                                *      */
        /*"      *   INCLUSAO DO PROJETO REDUCAO DE CHEQUE                        *      */
        /*"      *   OS MOVIMENTOS DE PAGAMENTO QUE FOREM PARA BANCO 104 (CAIXA)  *      */
        /*"      *   CONTINUARAO A SER PROCESSADOS E ENVIADOS NORMALMENTE PELA    *      */
        /*"      *   VERSAO ORIGINAL DO PROGRAMA.                                 *      */
        /*"      *   OS MOVIMENTOS QUE FOREM PARA OUTROS BANCOS (DIFERENTE DE CAIXA      */
        /*"      *   SERAO GERADOS EM ARQUIVO SEPARADO PARA PROCESSAMENTO PELO           */
        /*"      *   PROGRAMA VA1300B.                                                   */
        /*"      *   A T E N C A O: TODOS OS DADOS BANCARIOS SERAO OBTIDOS DA BASE       */
        /*"      *                  DO REDUCAO DE CHEQUE.                                */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      ******************************************************************      */
        /*"      * CONVERSAO ANO 2000              CONSEDA4              05/1998  *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      * ALTERADO EM 22/10/2002                     TERCIO CARVALHO     *      */
        /*"      *                                                                *      */
        /*"      *     PASSA A GERAR LANCAMENTOS PARA QUATRO DIAS UTEIS DA DATA   *      */
        /*"      *     CORRENTE.                                                  *      */
        /*"      *                                            PROCURE POR TL0210  *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      * ALTERADO EM 08/06/00                       MANOEL MESSIAS      *      */
        /*"      *   INCLUIDO NO ARQUIVO DE REMESSA O NUMERO DO CERTIFICADO DO    *      */
        /*"      * SEGURADO (ME-IDENT-CLI) PARA NOSSO CONTROLE.                   *      */
        /*"      *                                            PROCURE POR MM0600  *      */
        /*"      ******************************************************************      */
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
        public FileBasis _OUTROSBC { get; set; } = new FileBasis(new PIC("X", "100", "X(100)"));

        public FileBasis OUTROSBC
        {
            get
            {
                _.Move(MOVIMENTO_OUTROSBC, _OUTROSBC); VarBasis.RedefinePassValue(MOVIMENTO_OUTROSBC, _OUTROSBC, MOVIMENTO_OUTROSBC); return _OUTROSBC;
            }
        }
        /*"01  MOVIMENTO-RECORD    PIC X(150).*/
        public StringBasis MOVIMENTO_RECORD { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");
        /*"01  MOVIMENTO-OUTROSBC  PIC X(100).*/
        public StringBasis MOVIMENTO_OUTROSBC { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  SIST-CURRDATE                    PIC X(10).*/
        public StringBasis SIST_CURRDATE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  SIST-DTCREDITO                   PIC X(10).*/
        public StringBasis SIST_DTCREDITO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PARM-CODCONV                     PIC S9(9)     COMP.*/
        public IntBasis PARM_CODCONV { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01  PARM-NSA                         PIC S9(4)     COMP.*/
        public IntBasis PARM_NSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  PARM-VERSAO                      PIC S9(4)     COMP.*/
        public IntBasis PARM_VERSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  AGECTADEB                        PIC S9(4)     COMP.*/
        public IntBasis AGECTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  OPRCTADEB                        PIC S9(4)     COMP.*/
        public IntBasis OPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  NUMCTADEB                        PIC S9(13)    COMP-3.*/
        public IntBasis NUMCTADEB { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  DIGCTADEB                        PIC S9(4)     COMP.*/
        public IntBasis DIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  COD-BANCO                        PIC S9(4)     COMP.*/
        public IntBasis COD_BANCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VLPRMTOT                         PIC S9(13)V99 COMP-3.*/
        public DoubleBasis VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  NRCERTIF                         PIC S9(15)    COMP-3.*/
        public IntBasis NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  NRPARCEL                         PIC S9(04)    COMP.*/
        public IntBasis NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
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
        /*"01  SQL-MAYBE-NULL3                  PIC S9(4)     COMP.*/
        public IntBasis SQL_MAYBE_NULL3 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  WORK-AREA.*/
        public VA0341B_WORK_AREA WORK_AREA { get; set; } = new VA0341B_WORK_AREA();
        public class VA0341B_WORK_AREA : VarBasis
        {
            /*"    05      DATA-SQL.*/
            public VA0341B_DATA_SQL DATA_SQL { get; set; } = new VA0341B_DATA_SQL();
            public class VA0341B_DATA_SQL : VarBasis
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
            private _REDEF_VA0341B_DATA_AAMMDD _data_aammdd { get; set; }
            public _REDEF_VA0341B_DATA_AAMMDD DATA_AAMMDD
            {
                get { _data_aammdd = new _REDEF_VA0341B_DATA_AAMMDD(); _.Move(DATA_INVERTIDA, _data_aammdd); VarBasis.RedefinePassValue(DATA_INVERTIDA, _data_aammdd, DATA_INVERTIDA); _data_aammdd.ValueChanged += () => { _.Move(_data_aammdd, DATA_INVERTIDA); }; return _data_aammdd; }
                set { VarBasis.RedefinePassValue(value, _data_aammdd, DATA_INVERTIDA); }
            }  //Redefines
            public class _REDEF_VA0341B_DATA_AAMMDD : VarBasis
            {
                /*"      10    ANO                      PIC  9(004).*/
                public IntBasis ANO_0 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10    MES                      PIC  9(002).*/
                public IntBasis MES_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    DIA                      PIC  9(002).*/
                public IntBasis DIA_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05 AC-IND-REDUCAO                PIC  9(009) VALUE ZEROS.*/

                public _REDEF_VA0341B_DATA_AAMMDD()
                {
                    ANO_0.ValueChanged += OnValueChanged;
                    MES_0.ValueChanged += OnValueChanged;
                    DIA_0.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis AC_IND_REDUCAO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05 AC-IND-SEM                    PIC  9(009) VALUE ZEROS.*/
            public IntBasis AC_IND_SEM { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05 AC-LIDOS                      PIC  9(009) VALUE ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05 AC-REGISTROS                  PIC  9(009) VALUE 1.*/
            public IntBasis AC_REGISTROS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"), 1);
            /*"    05 AC-VALOR                      PIC S9(013)V99 VALUE +0.*/
            public DoubleBasis AC_VALOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 W-ACHOU-REDUCAO-CHEQUE        PIC X(03) VALUE 'NAO'.*/
            public StringBasis W_ACHOU_REDUCAO_CHEQUE { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    05 WS-AGENCIA-ANT                PIC S9(004) COMP.*/
            public IntBasis WS_AGENCIA_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05 WS-NSL                        PIC  9(008) VALUE 0.*/
            public IntBasis WS_NSL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05 WS-EOF                        PIC  9(001) VALUE 0.*/
            public IntBasis WS_EOF { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05 WS-DISPLAY-QUANT              PIC  ZZZ.ZZZ.ZZ9.*/
            public IntBasis WS_DISPLAY_QUANT { get; set; } = new IntBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9."));
            /*"    05 WS-DISPLAY-OUTROS-BANCOS      PIC  ZZZ.ZZZ.ZZ9.*/
            public IntBasis WS_DISPLAY_OUTROS_BANCOS { get; set; } = new IntBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9."));
            /*"    05 WS-DISPLAY-VALOR              PIC  ZZZ.ZZZ.ZZ9,99.*/
            public DoubleBasis WS_DISPLAY_VALOR { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99."), 2);
            /*"    05 WS-DISPLAY-NSA                PIC  9(05).*/
            public IntBasis WS_DISPLAY_NSA { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
            /*"    05 W-EM-OUTROS-BANCOS            PIC  9(05).*/
            public IntBasis W_EM_OUTROS_BANCOS { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
            /*"    05 WS-PRM-TOT                    PIC S9(13)V99 COMP-3.*/
            public DoubleBasis WS_PRM_TOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 WS-PRM-DIF                    PIC S9(13)V99 COMP-3.*/
            public DoubleBasis WS_PRM_DIF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 W-NUM-CONTA-NUM8       PIC 9(12).*/
            public IntBasis W_NUM_CONTA_NUM8 { get; set; } = new IntBasis(new PIC("9", "12", "9(12)."));
            /*"    05 W-DV-CONTA-ODS-ALFA    PIC X(02).*/
            public StringBasis W_DV_CONTA_ODS_ALFA { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
            /*"    05 W-DV-CONTA-ODS-NUM  REDEFINES  W-DV-CONTA-ODS-ALFA .*/
            private _REDEF_VA0341B_W_DV_CONTA_ODS_NUM _w_dv_conta_ods_num { get; set; }
            public _REDEF_VA0341B_W_DV_CONTA_ODS_NUM W_DV_CONTA_ODS_NUM
            {
                get { _w_dv_conta_ods_num = new _REDEF_VA0341B_W_DV_CONTA_ODS_NUM(); _.Move(W_DV_CONTA_ODS_ALFA, _w_dv_conta_ods_num); VarBasis.RedefinePassValue(W_DV_CONTA_ODS_ALFA, _w_dv_conta_ods_num, W_DV_CONTA_ODS_ALFA); _w_dv_conta_ods_num.ValueChanged += () => { _.Move(_w_dv_conta_ods_num, W_DV_CONTA_ODS_ALFA); }; return _w_dv_conta_ods_num; }
                set { VarBasis.RedefinePassValue(value, _w_dv_conta_ods_num, W_DV_CONTA_ODS_ALFA); }
            }  //Redefines
            public class _REDEF_VA0341B_W_DV_CONTA_ODS_NUM : VarBasis
            {
                /*"       10 W-DV-CONTA-ODS-NUM-1  PIC 9(01).*/
                public IntBasis W_DV_CONTA_ODS_NUM_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"       10 W-DV-CONTA-ODS-NUM-2  PIC 9(01).*/
                public IntBasis W_DV_CONTA_ODS_NUM_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"    05 W04DTSQL.*/

                public _REDEF_VA0341B_W_DV_CONTA_ODS_NUM()
                {
                    W_DV_CONTA_ODS_NUM_1.ValueChanged += OnValueChanged;
                    W_DV_CONTA_ODS_NUM_2.ValueChanged += OnValueChanged;
                }

            }
            public VA0341B_W04DTSQL W04DTSQL { get; set; } = new VA0341B_W04DTSQL();
            public class VA0341B_W04DTSQL : VarBasis
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
            public VA0341B_PARM_PROSOMU1 PARM_PROSOMU1 { get; set; } = new VA0341B_PARM_PROSOMU1();
            public class VA0341B_PARM_PROSOMU1 : VarBasis
            {
                /*"      10 SU1-DATA1.*/
                public VA0341B_SU1_DATA1 SU1_DATA1 { get; set; } = new VA0341B_SU1_DATA1();
                public class VA0341B_SU1_DATA1 : VarBasis
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
                public VA0341B_SU1_DATA2 SU1_DATA2 { get; set; } = new VA0341B_SU1_DATA2();
                public class VA0341B_SU1_DATA2 : VarBasis
                {
                    /*"        15 SU1-DD2                   PIC 99.*/
                    public IntBasis SU1_DD2 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"        15 SU1-MM2                   PIC 99.*/
                    public IntBasis SU1_MM2 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"        15 SU1-AA2                   PIC 9999.*/
                    public IntBasis SU1_AA2 { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
                    /*"    05      WABEND.*/
                }
            }
            public VA0341B_WABEND WABEND { get; set; } = new VA0341B_WABEND();
            public class VA0341B_WABEND : VarBasis
            {
                /*"      10    FILLER                   PIC  X(010) VALUE            'VA0341B  '.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VA0341B  ");
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
            public VA0341B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new VA0341B_LOCALIZA_ABEND_1();
            public class VA0341B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05      LOCALIZA-ABEND-2.*/
            }
            public VA0341B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new VA0341B_LOCALIZA_ABEND_2();
            public class VA0341B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"01  MOV-HEADER.*/
            }
        }
        public VA0341B_MOV_HEADER MOV_HEADER { get; set; } = new VA0341B_MOV_HEADER();
        public class VA0341B_MOV_HEADER : VarBasis
        {
            /*"    05 MA-COD-REG         PIC X(001) VALUE 'A'.*/
            public StringBasis MA_COD_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"A");
            /*"    05 MA-COD-REMESSA     PIC X(001) VALUE '1'.*/
            public StringBasis MA_COD_REMESSA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
            /*"    05 MA-COD-CONVENIO    PIC X(020) VALUE '6090'.*/
            public StringBasis MA_COD_CONVENIO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"6090");
            /*"    05 MA-NOME-EMPRESA    PIC X(020) VALUE 'SASSE'.*/
            public StringBasis MA_NOME_EMPRESA { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"SASSE");
            /*"    05 MA-COD-BANCO       PIC X(003) VALUE '104'.*/
            public StringBasis MA_COD_BANCO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"104");
            /*"    05 MA-NOME-BANCO      PIC X(020) VALUE 'CEF'.*/
            public StringBasis MA_NOME_BANCO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"CEF");
            /*"    05 MA-DATA-GERACAO    PIC 9(008).*/
            public IntBasis MA_DATA_GERACAO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05 MA-NSA             PIC 9(006).*/
            public IntBasis MA_NSA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05 MA-VERSAO-LAYOUT   PIC 9(002).*/
            public IntBasis MA_VERSAO_LAYOUT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05 MA-SERVICO         PIC X(017) VALUE 'EST VENDA MULTIPR'.*/
            public StringBasis MA_SERVICO { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"EST VENDA MULTIPR");
            /*"    05 MA-RESERVADO       PIC X(044) VALUE SPACES.*/
            public StringBasis MA_RESERVADO { get; set; } = new StringBasis(new PIC("X", "44", "X(044)"), @"");
            /*"    05 MA-PROGRAMA        PIC X(008) VALUE 'VA0341B'.*/
            public StringBasis MA_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VA0341B");
            /*"01  MOV-OUTROS-BANCOS.*/
        }
        public VA0341B_MOV_OUTROS_BANCOS MOV_OUTROS_BANCOS { get; set; } = new VA0341B_MOV_OUTROS_BANCOS();
        public class VA0341B_MOV_OUTROS_BANCOS : VarBasis
        {
            /*"    05 MOV-OUTROBC-NUM-SEQUENCIA     PIC 9(01).*/
            public IntBasis MOV_OUTROBC_NUM_SEQUENCIA { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
            /*"    05 FILLER                        PIC X(01) VALUE '|'.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"|");
            /*"    05 MOV-OUTROBC-COD-BANCO         PIC 9(03).*/
            public IntBasis MOV_OUTROBC_COD_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
            /*"    05 FILLER                        PIC X(01) VALUE '|'.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"|");
            /*"    05 MOV-OUTROBC-NUM-OCORR-MOVTO   PIC 9(09).*/
            public IntBasis MOV_OUTROBC_NUM_OCORR_MOVTO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
            /*"    05 FILLER                        PIC X(01) VALUE '|'.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"|");
            /*"    05 MOV-OUTROBC-NUM-CERTIFICADO   PIC 9(15).*/
            public IntBasis MOV_OUTROBC_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("9", "15", "9(15)."));
            /*"    05 FILLER                        PIC X(01) VALUE '|'.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"|");
            /*"    05 MOV-OUTROBC-NUM-PARCELA       PIC 9(05).*/
            public IntBasis MOV_OUTROBC_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
            /*"    05 FILLER                        PIC X(01) VALUE '|'.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"|");
            /*"    05 MOV-OUTROBC-NUM-TITULO        PIC 9(13).*/
            public IntBasis MOV_OUTROBC_NUM_TITULO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
            /*"    05 FILLER                        PIC X(01) VALUE '|'.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"|");
            /*"    05 MOV-OUTROBC-NUM-PESSOA        PIC 9(09).*/
            public IntBasis MOV_OUTROBC_NUM_PESSOA { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
            /*"    05 FILLER                        PIC X(01) VALUE '|'.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"|");
            /*"    05 MOV-OUTROBC-DATA-VENCIMENTO   PIC X(10).*/
            public StringBasis MOV_OUTROBC_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 FILLER                        PIC X(01) VALUE '|'.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"|");
            /*"    05 MOV-OUTROBC-NSA               PIC 9(06).*/
            public IntBasis MOV_OUTROBC_NSA { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
            /*"    05 FILLER                        PIC X(01) VALUE '|'.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"|");
            /*"01  MOV-LANCAMENTO.*/
        }
        public VA0341B_MOV_LANCAMENTO MOV_LANCAMENTO { get; set; } = new VA0341B_MOV_LANCAMENTO();
        public class VA0341B_MOV_LANCAMENTO : VarBasis
        {
            /*"    05 ME-COD-REG           PIC X(001) VALUE 'E'.*/
            public StringBasis ME_COD_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"E");
            /*"    05 ME-IDENT-CLI-EMPRESA.*/
            public VA0341B_ME_IDENT_CLI_EMPRESA ME_IDENT_CLI_EMPRESA { get; set; } = new VA0341B_ME_IDENT_CLI_EMPRESA();
            public class VA0341B_ME_IDENT_CLI_EMPRESA : VarBasis
            {
                /*"       10 ME-IDENT-CLI      PIC 9(015).*/
                public IntBasis ME_IDENT_CLI { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"       10 ME-IDENT-CLI-R    REDEFINES  ME-IDENT-CLI.*/
                private _REDEF_VA0341B_ME_IDENT_CLI_R _me_ident_cli_r { get; set; }
                public _REDEF_VA0341B_ME_IDENT_CLI_R ME_IDENT_CLI_R
                {
                    get { _me_ident_cli_r = new _REDEF_VA0341B_ME_IDENT_CLI_R(); _.Move(ME_IDENT_CLI, _me_ident_cli_r); VarBasis.RedefinePassValue(ME_IDENT_CLI, _me_ident_cli_r, ME_IDENT_CLI); _me_ident_cli_r.ValueChanged += () => { _.Move(_me_ident_cli_r, ME_IDENT_CLI); }; return _me_ident_cli_r; }
                    set { VarBasis.RedefinePassValue(value, _me_ident_cli_r, ME_IDENT_CLI); }
                }  //Redefines
                public class _REDEF_VA0341B_ME_IDENT_CLI_R : VarBasis
                {
                    /*"          15 FILLER         PIC X(015).*/
                    public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                    /*"       10 ME-NSA-PARM       PIC 9(005) VALUE ZEROS.*/

                    public _REDEF_VA0341B_ME_IDENT_CLI_R()
                    {
                        FILLER_17.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis ME_NSA_PARM { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
                /*"       10 FILLER            PIC X(005) VALUE SPACES.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"    05 ME-AGENCIA           PIC 9(004).*/
            }
            public IntBasis ME_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05 ME-IDENT-CLI-BANCO.*/
            public VA0341B_ME_IDENT_CLI_BANCO ME_IDENT_CLI_BANCO { get; set; } = new VA0341B_ME_IDENT_CLI_BANCO();
            public class VA0341B_ME_IDENT_CLI_BANCO : VarBasis
            {
                /*"       10 ME-OPR-CTA-CORR   PIC 9(004).*/
                public IntBasis ME_OPR_CTA_CORR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10 ME-NUM-CTA-CORR   PIC 9(012).*/
                public IntBasis ME_NUM_CTA_CORR { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"       10 ME-DAC-CTA-CORR   PIC 9(001).*/
                public IntBasis ME_DAC_CTA_CORR { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"       10 FILLER            PIC X(002) VALUE SPACES.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    05 ME-DATA-VENCIMENTO   PIC 9(008).*/
            }
            public IntBasis ME_DATA_VENCIMENTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05 ME-VALOR             PIC 9(13)V99.*/
            public DoubleBasis ME_VALOR { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99."), 2);
            /*"    05 ME-COD-MOEDA         PIC X(002) VALUE '00'.*/
            public StringBasis ME_COD_MOEDA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"00");
            /*"    05 ME-USO-EMPRESA.*/
            public VA0341B_ME_USO_EMPRESA ME_USO_EMPRESA { get; set; } = new VA0341B_ME_USO_EMPRESA();
            public class VA0341B_ME_USO_EMPRESA : VarBasis
            {
                /*"       10 ME-NSA            PIC 9(003).*/
                public IntBasis ME_NSA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       10 ME-NSL            PIC 9(008).*/
                public IntBasis ME_NSL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"       10 FILLER            PIC X(047) VALUE SPACES.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "47", "X(047)"), @"");
                /*"    05 ME-RESERVADO         PIC X(002) VALUE SPACES.*/
            }
            public StringBasis ME_RESERVADO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"    05 ME-NUM-PESSOA        PIC 9(010) VALUE ZEROS.*/
            public IntBasis ME_NUM_PESSOA { get; set; } = new IntBasis(new PIC("9", "10", "9(010)"));
            /*"    05 ME-SEQ-CTA-BANC      PIC 9(005) VALUE ZEROS.*/
            public IntBasis ME_SEQ_CTA_BANC { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    05 ME-COD-MOV           PIC X(001) VALUE '2'.*/
            public StringBasis ME_COD_MOV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
            /*"01  MOV-TRAILLER.*/
        }
        public VA0341B_MOV_TRAILLER MOV_TRAILLER { get; set; } = new VA0341B_MOV_TRAILLER();
        public class VA0341B_MOV_TRAILLER : VarBasis
        {
            /*"    05 MZ-COD-REG         PIC X(001) VALUE 'Z'.*/
            public StringBasis MZ_COD_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"Z");
            /*"    05 MZ-QTDE-REGISTROS  PIC 9(006).*/
            public IntBasis MZ_QTDE_REGISTROS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05 MZ-TOT-DEB-CRUZ    PIC 9(015)V99 VALUE 0.*/
            public DoubleBasis MZ_TOT_DEB_CRUZ { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99"), 2);
            /*"    05 MZ-TOT-VAL-CRUZ    PIC 9(015)V99.*/
            public DoubleBasis MZ_TOT_VAL_CRUZ { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99."), 2);
            /*"    05 MZ-RESERVADO       PIC X(109) VALUE SPACES.*/
            public StringBasis MZ_RESERVADO { get; set; } = new StringBasis(new PIC("X", "109", "X(109)"), @"");
        }


        public Dclgens.COBHISVI COBHISVI { get; set; } = new Dclgens.COBHISVI();
        public Dclgens.OD001 OD001 { get; set; } = new Dclgens.OD001();
        public Dclgens.OD002 OD002 { get; set; } = new Dclgens.OD002();
        public Dclgens.OD003 OD003 { get; set; } = new Dclgens.OD003();
        public Dclgens.OD007 OD007 { get; set; } = new Dclgens.OD007();
        public Dclgens.OD009 OD009 { get; set; } = new Dclgens.OD009();
        public Dclgens.HISLANCT HISLANCT { get; set; } = new Dclgens.HISLANCT();
        public Dclgens.SI175 SI175 { get; set; } = new Dclgens.SI175();
        public Dclgens.GE354 GE354 { get; set; } = new Dclgens.GE354();
        public Dclgens.VG079 VG079 { get; set; } = new Dclgens.VG079();
        public Dclgens.GE368 GE368 { get; set; } = new Dclgens.GE368();
        public VA0341B_RESSARC RESSARC { get; set; } = new VA0341B_RESSARC();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string MOVIMENTO_FILE_NAME_P, string OUTROSBC_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                MOVIMENTO.SetFile(MOVIMENTO_FILE_NAME_P);
                OUTROSBC.SetFile(OUTROSBC_FILE_NAME_P);

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
            /*" -431- MOVE '0001-INICIO               ' TO PARAGRAFO. */
            _.Move("0001-INICIO               ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -432- DISPLAY '--------------------------------' */
            _.Display($"--------------------------------");

            /*" -433- DISPLAY '  PROGRAMA EM EXECUCAO VA0341B  ' */
            _.Display($"  PROGRAMA EM EXECUCAO VA0341B  ");

            /*" -434- DISPLAY '                                ' */
            _.Display($"                                ");

            /*" -435- DISPLAY '  VERSAO V.08        22/11/2019 ' */
            _.Display($"  VERSAO V.08        22/11/2019 ");

            /*" -436- DISPLAY '--------------------------------' . */
            _.Display($"--------------------------------");

            /*" -437- DISPLAY ' ' */
            _.Display($" ");

            /*" -438- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -442- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -445- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -453- MOVE 'SELECT V0SISTEMA' TO COMANDO. */
            _.Move("SELECT V0SISTEMA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -459- PERFORM M_0000_PRINCIPAL_DB_SELECT_1 */

            M_0000_PRINCIPAL_DB_SELECT_1();

            /*" -462- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -464- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -465- MOVE SIST-CURRDATE TO DATA-SQL. */
            _.Move(SIST_CURRDATE, WORK_AREA.DATA_SQL);

            /*" -466- MOVE CORR DATA-SQL TO DATA-AAMMDD. */
            _.MoveCorr(WORK_AREA.DATA_SQL, WORK_AREA.DATA_AAMMDD);

            /*" -468- MOVE DATA-INVERTIDA TO MA-DATA-GERACAO. */
            _.Move(WORK_AREA.DATA_INVERTIDA, MOV_HEADER.MA_DATA_GERACAO);

            /*" -476- DISPLAY '*** VA0341B *** DATA DE GERACAO DA FITA: ' DATA-SQL. */
            _.Display($"*** VA0341B *** DATA DE GERACAO DA FITA: {WORK_AREA.DATA_SQL}");

            /*" -478- MOVE 'SELECT V0CONVSUCOV' TO COMANDO. */
            _.Move("SELECT V0CONVSUCOV", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -487- PERFORM M_0000_PRINCIPAL_DB_SELECT_2 */

            M_0000_PRINCIPAL_DB_SELECT_2();

            /*" -490- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -492- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -494- ADD 1 TO PARM-NSA. */
            PARM_NSA.Value = PARM_NSA + 1;

            /*" -495- MOVE PARM-NSA TO MA-NSA. */
            _.Move(PARM_NSA, MOV_HEADER.MA_NSA);

            /*" -496- MOVE PARM-NSA TO ME-NSA. */
            _.Move(PARM_NSA, MOV_LANCAMENTO.ME_USO_EMPRESA.ME_NSA);

            /*" -502- MOVE PARM-VERSAO TO MA-VERSAO-LAYOUT. */
            _.Move(PARM_VERSAO, MOV_HEADER.MA_VERSAO_LAYOUT);

            /*" -503- MOVE PARM-NSA TO MOV-OUTROBC-NSA */
            _.Move(PARM_NSA, MOV_OUTROS_BANCOS.MOV_OUTROBC_NSA);

            /*" -505- MOVE SIST-CURRDATE TO MOV-OUTROBC-DATA-VENCIMENTO. */
            _.Move(SIST_CURRDATE, MOV_OUTROS_BANCOS.MOV_OUTROBC_DATA_VENCIMENTO);

            /*" -506- MOVE SIST-CURRDATE TO W04DTSQL. */
            _.Move(SIST_CURRDATE, WORK_AREA.W04DTSQL);

            /*" -507- MOVE W04DDSQL TO SU1-DD1. */
            _.Move(WORK_AREA.W04DTSQL.W04DDSQL, WORK_AREA.PARM_PROSOMU1.SU1_DATA1.SU1_DD1);

            /*" -508- MOVE W04MMSQL TO SU1-MM1. */
            _.Move(WORK_AREA.W04DTSQL.W04MMSQL, WORK_AREA.PARM_PROSOMU1.SU1_DATA1.SU1_MM1);

            /*" -509- MOVE W04AASQL TO SU1-AA1. */
            _.Move(WORK_AREA.W04DTSQL.W04AASQL, WORK_AREA.PARM_PROSOMU1.SU1_DATA1.SU1_AA1);

            /*" -512- MOVE ZEROES TO SU1-DATA2. */
            _.Move(0, WORK_AREA.PARM_PROSOMU1.SU1_DATA2);

            /*" -513- PERFORM R0010-SOMA-DIAS THRU R0010-FIM 2 TIMES. */

            R0010_SOMA_DIAS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_FIM*/


            /*" -514- MOVE SU1-DD2 TO W04DDSQL. */
            _.Move(WORK_AREA.PARM_PROSOMU1.SU1_DATA2.SU1_DD2, WORK_AREA.W04DTSQL.W04DDSQL);

            /*" -515- MOVE SU1-MM2 TO W04MMSQL. */
            _.Move(WORK_AREA.PARM_PROSOMU1.SU1_DATA2.SU1_MM2, WORK_AREA.W04DTSQL.W04MMSQL);

            /*" -517- MOVE SU1-AA2 TO W04AASQL. */
            _.Move(WORK_AREA.PARM_PROSOMU1.SU1_DATA2.SU1_AA2, WORK_AREA.W04DTSQL.W04AASQL);

            /*" -519- MOVE W04DTSQL TO SIST-DTCREDITO. */
            _.Move(WORK_AREA.W04DTSQL, SIST_DTCREDITO);

            /*" -520- MOVE SIST-DTCREDITO TO DATA-SQL. */
            _.Move(SIST_DTCREDITO, WORK_AREA.DATA_SQL);

            /*" -521- MOVE CORR DATA-SQL TO DATA-AAMMDD. */
            _.MoveCorr(WORK_AREA.DATA_SQL, WORK_AREA.DATA_AAMMDD);

            /*" -522- MOVE DATA-INVERTIDA TO ME-DATA-VENCIMENTO. */
            _.Move(WORK_AREA.DATA_INVERTIDA, MOV_LANCAMENTO.ME_DATA_VENCIMENTO);

            /*" -525- DISPLAY '*** VA0341B *** DATA DE CREDITO EM CONTA: ' DATA-SQL. */
            _.Display($"*** VA0341B *** DATA DE CREDITO EM CONTA: {WORK_AREA.DATA_SQL}");

            /*" -527- MOVE 0 TO WS-EOF. */
            _.Move(0, WORK_AREA.WS_EOF);

            /*" -528- PERFORM R0100-DECLARE-DEVOLUCAO THRU R0100-EXIT. */

            R0100_DECLARE_DEVOLUCAO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_EXIT*/


            /*" -530- PERFORM R0101-FETCH-DEVOLUCAO THRU R0101-EXIT. */

            R0101_FETCH_DEVOLUCAO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R0101_EXIT*/


            /*" -531- IF WS-EOF EQUAL 1 */

            if (WORK_AREA.WS_EOF == 1)
            {

                /*" -532- DISPLAY '*----------------------------------------------*' */
                _.Display($"*----------------------------------------------*");

                /*" -533- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -534- DISPLAY '*           PROGRAMA VA0341B                   *' */
                _.Display($"*           PROGRAMA VA0341B                   *");

                /*" -535- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -536- DISPLAY '*   NADA SELECIONADO PARA DEVOLUCAO DE PREMIO  *' */
                _.Display($"*   NADA SELECIONADO PARA DEVOLUCAO DE PREMIO  *");

                /*" -537- DISPLAY '*   DO VIDA PELO CONVENIO 6090                 *' */
                _.Display($"*   DO VIDA PELO CONVENIO 6090                 *");

                /*" -538- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -539- DISPLAY '*----------------------------------------------*' */
                _.Display($"*----------------------------------------------*");

                /*" -541- GO TO R00000-FINALIZACAO. */

                R00000_FINALIZACAO(); //GOTO
                return;
            }


            /*" -543- OPEN OUTPUT MOVIMENTO OUTROSBC . */
            MOVIMENTO.Open(MOVIMENTO_RECORD);
            OUTROSBC.Open(MOVIMENTO_OUTROSBC);

            /*" -545- WRITE MOVIMENTO-RECORD FROM MOV-HEADER. */
            _.Move(MOV_HEADER.GetMoveValues(), MOVIMENTO_RECORD);

            MOVIMENTO.Write(MOVIMENTO_RECORD.GetMoveValues().ToString());

            /*" -548- PERFORM R1000-PROCESSA-DEVOLUCAO THRU R1000-FIM UNTIL WS-EOF = 1. */

            while (!(WORK_AREA.WS_EOF == 1))
            {

                R1000_PROCESSA_DEVOLUCAO(true);

                R1000_LE_REGISTRO(true);

                R1000_SEM_REDUCAO_CHEQUE(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_FIM*/

            }

            /*" -554- PERFORM R5000-GRAVA-RELATORIOS THRU R5000-EXIT. */

            R5000_GRAVA_RELATORIOS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_EXIT*/


            /*" -556- PERFORM R9000-FINALIZA THRU R9000-EXIT. */

            R9000_FINALIZA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_EXIT*/


            /*" -558- CLOSE MOVIMENTO OUTROSBC. */
            MOVIMENTO.Close();
            OUTROSBC.Close();

            /*" -558- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SELECT-1 */
        public void M_0000_PRINCIPAL_DB_SELECT_1()
        {
            /*" -459- EXEC SQL SELECT DTMOVABE INTO :SIST-CURRDATE FROM SEGUROS.V0SISTEMA WHERE IDSISTEM= 'VA' END-EXEC. */

            var m_0000_PRINCIPAL_DB_SELECT_1_Query1 = new M_0000_PRINCIPAL_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_0000_PRINCIPAL_DB_SELECT_1_Query1.Execute(m_0000_PRINCIPAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SIST_CURRDATE, SIST_CURRDATE);
            }


        }

        [StopWatch]
        /*" R00000-FINALIZACAO */
        private void R00000_FINALIZACAO(bool isPerform = false)
        {
            /*" -566- DISPLAY '*** VA0341B *** TERMINO NORMAL' . */
            _.Display($"*** VA0341B *** TERMINO NORMAL");

            /*" -567- MOVE 0 TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -567- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SELECT-2 */
        public void M_0000_PRINCIPAL_DB_SELECT_2()
        {
            /*" -487- EXEC SQL SELECT COD_CONVENIO, NSA_CONVENIO, VERSAO_LAYOUT INTO :PARM-CODCONV, :PARM-NSA, :PARM-VERSAO FROM SEGUROS.V0CONVSUCOV WHERE COD_CONVENIO = 6090 END-EXEC. */

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
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R00000_FIM*/

        [StopWatch]
        /*" R0010-SOMA-DIAS */
        private void R0010_SOMA_DIAS(bool isPerform = false)
        {
            /*" -577- MOVE +1 TO SU1-NRDIAS. */
            _.Move(+1, WORK_AREA.PARM_PROSOMU1.SU1_NRDIAS);

            /*" -578- CALL 'PROSOCU1' USING PARM-PROSOMU1. */
            _.Call("PROSOCU1", WORK_AREA.PARM_PROSOMU1);

            /*" -578- MOVE SU1-DATA2 TO SU1-DATA1. */
            _.Move(WORK_AREA.PARM_PROSOMU1.SU1_DATA2, WORK_AREA.PARM_PROSOMU1.SU1_DATA1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_FIM*/

        [StopWatch]
        /*" R0100-DECLARE-DEVOLUCAO */
        private void R0100_DECLARE_DEVOLUCAO(bool isPerform = false)
        {
            /*" -604- PERFORM R0100_DECLARE_DEVOLUCAO_DB_DECLARE_1 */

            R0100_DECLARE_DEVOLUCAO_DB_DECLARE_1();

            /*" -608- MOVE 'OPEN RESSARC    ' TO COMANDO. */
            _.Move("OPEN RESSARC    ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -608- PERFORM R0100_DECLARE_DEVOLUCAO_DB_OPEN_1 */

            R0100_DECLARE_DEVOLUCAO_DB_OPEN_1();

            /*" -611- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -612- DISPLAY 'VA0341B - ERRO OPEN DO DECLARE RESSARC' */
                _.Display($"VA0341B - ERRO OPEN DO DECLARE RESSARC");

                /*" -612- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0100-DECLARE-DEVOLUCAO-DB-DECLARE-1 */
        public void R0100_DECLARE_DEVOLUCAO_DB_DECLARE_1()
        {
            /*" -604- EXEC SQL DECLARE RESSARC CURSOR FOR SELECT AGECTADEB, OPRCTADEB, NUMCTADEB, DIGCTADEB, COD_BANCO, VLPRMTOT, SITUACAO, DTVENCTO, NSAS, NSL, NRCERTIF, NRPARCEL FROM SEGUROS.V0HISTCONTAVA WHERE CODCONV = 6090 AND SITUACAO = '0' AND NUMCTADEB > 0 AND TIPLANC = '2' FOR UPDATE OF SITUACAO, DTVENCTO, NSAS, NSL END-EXEC. */
            RESSARC = new VA0341B_RESSARC(false);
            string GetQuery_RESSARC()
            {
                var query = @$"SELECT AGECTADEB
							, 
							OPRCTADEB
							, 
							NUMCTADEB
							, 
							DIGCTADEB
							, 
							COD_BANCO
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
							, 
							NRCERTIF
							, 
							NRPARCEL 
							FROM SEGUROS.V0HISTCONTAVA 
							WHERE CODCONV = 6090 
							AND SITUACAO = '0' 
							AND NUMCTADEB > 0 
							AND TIPLANC = '2'";

                return query;
            }
            RESSARC.GetQueryEvent += GetQuery_RESSARC;

        }

        [StopWatch]
        /*" R0100-DECLARE-DEVOLUCAO-DB-OPEN-1 */
        public void R0100_DECLARE_DEVOLUCAO_DB_OPEN_1()
        {
            /*" -608- EXEC SQL OPEN RESSARC END-EXEC. */

            RESSARC.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_EXIT*/

        [StopWatch]
        /*" R0101-FETCH-DEVOLUCAO */
        private void R0101_FETCH_DEVOLUCAO(bool isPerform = false)
        {
            /*" -619- MOVE 'R0101-FETCH' TO PARAGRAFO. */
            _.Move("R0101-FETCH", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -621- MOVE 'FETCH RESSARC                     ' TO COMANDO. */
            _.Move("FETCH RESSARC                     ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -637- PERFORM R0101_FETCH_DEVOLUCAO_DB_FETCH_1 */

            R0101_FETCH_DEVOLUCAO_DB_FETCH_1();

            /*" -640- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -641- MOVE 1 TO WS-EOF */
                _.Move(1, WORK_AREA.WS_EOF);

                /*" -641- PERFORM R0101_FETCH_DEVOLUCAO_DB_CLOSE_1 */

                R0101_FETCH_DEVOLUCAO_DB_CLOSE_1();

                /*" -643- ELSE */
            }
            else
            {


                /*" -644- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -645- DISPLAY 'VA0341B - ERRO FETCH DO DECLARE RESSARC' */
                    _.Display($"VA0341B - ERRO FETCH DO DECLARE RESSARC");

                    /*" -646- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -647- ELSE */
                }
                else
                {


                    /*" -648- ADD 1 TO AC-LIDOS */
                    WORK_AREA.AC_LIDOS.Value = WORK_AREA.AC_LIDOS + 1;

                    /*" -649- IF SQL-MAYBE-NULL3 LESS ZEROS */

                    if (SQL_MAYBE_NULL3 < 00)
                    {

                        /*" -649- MOVE ZEROS TO COD-BANCO. */
                        _.Move(0, COD_BANCO);
                    }

                }

            }


        }

        [StopWatch]
        /*" R0101-FETCH-DEVOLUCAO-DB-FETCH-1 */
        public void R0101_FETCH_DEVOLUCAO_DB_FETCH_1()
        {
            /*" -637- EXEC SQL FETCH RESSARC INTO :AGECTADEB, :OPRCTADEB, :NUMCTADEB, :DIGCTADEB, :COD-BANCO:SQL-MAYBE-NULL3, :VLPRMTOT, :SITUACAO, :DTVENCTO, :NSAS:SQL-MAYBE-NULL1, :NSL:SQL-MAYBE-NULL2, :NRCERTIF, :NRPARCEL END-EXEC. */

            if (RESSARC.Fetch())
            {
                _.Move(RESSARC.AGECTADEB, AGECTADEB);
                _.Move(RESSARC.OPRCTADEB, OPRCTADEB);
                _.Move(RESSARC.NUMCTADEB, NUMCTADEB);
                _.Move(RESSARC.DIGCTADEB, DIGCTADEB);
                _.Move(RESSARC.COD_BANCO, COD_BANCO);
                _.Move(RESSARC.SQL_MAYBE_NULL3, SQL_MAYBE_NULL3);
                _.Move(RESSARC.VLPRMTOT, VLPRMTOT);
                _.Move(RESSARC.SITUACAO, SITUACAO);
                _.Move(RESSARC.DTVENCTO, DTVENCTO);
                _.Move(RESSARC.NSAS, NSAS);
                _.Move(RESSARC.SQL_MAYBE_NULL1, SQL_MAYBE_NULL1);
                _.Move(RESSARC.NSL, NSL);
                _.Move(RESSARC.SQL_MAYBE_NULL2, SQL_MAYBE_NULL2);
                _.Move(RESSARC.NRCERTIF, NRCERTIF);
                _.Move(RESSARC.NRPARCEL, NRPARCEL);
            }

        }

        [StopWatch]
        /*" R0101-FETCH-DEVOLUCAO-DB-CLOSE-1 */
        public void R0101_FETCH_DEVOLUCAO_DB_CLOSE_1()
        {
            /*" -641- EXEC SQL CLOSE RESSARC END-EXEC */

            RESSARC.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0101_EXIT*/

        [StopWatch]
        /*" R1000-PROCESSA-DEVOLUCAO */
        private void R1000_PROCESSA_DEVOLUCAO(bool isPerform = false)
        {
            /*" -657- ADD 1 TO WS-NSL. */
            WORK_AREA.WS_NSL.Value = WORK_AREA.WS_NSL + 1;

            /*" -659- MOVE WS-NSL TO NSL FITSAS-NSL */
            _.Move(WORK_AREA.WS_NSL, NSL, FITSAS_NSL);

            /*" -664- MOVE WS-NSL TO ME-NSL. */
            _.Move(WORK_AREA.WS_NSL, MOV_LANCAMENTO.ME_USO_EMPRESA.ME_NSL);

            /*" -665- MOVE 'NAO' TO W-ACHOU-REDUCAO-CHEQUE. */
            _.Move("NAO", WORK_AREA.W_ACHOU_REDUCAO_CHEQUE);

            /*" -675- PERFORM R2000-ACESSA-REDUCAO-CHEQUE THRU R2000-EXIT. */

            R2000_ACESSA_REDUCAO_CHEQUE(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_EXIT*/


            /*" -676- IF W-ACHOU-REDUCAO-CHEQUE EQUAL 'NAO' */

            if (WORK_AREA.W_ACHOU_REDUCAO_CHEQUE == "NAO")
            {

                /*" -677- ADD 1 TO AC-IND-SEM */
                WORK_AREA.AC_IND_SEM.Value = WORK_AREA.AC_IND_SEM + 1;

                /*" -678- PERFORM R3000-GERA-DEVOLUCAO THRU R3000-EXIT */

                R3000_GERA_DEVOLUCAO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_EXIT*/


                /*" -680- GO TO R1000-LE-REGISTRO. */

                R1000_LE_REGISTRO(); //GOTO
                return;
            }


            /*" -682- ADD 1 TO AC-IND-REDUCAO */
            WORK_AREA.AC_IND_REDUCAO.Value = WORK_AREA.AC_IND_REDUCAO + 1;

            /*" -684- IF OD009-COD-BANCO NOT EQUAL 104 */

            if (OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_BANCO != 104)
            {

                /*" -685- IF OD009-COD-BANCO EQUAL 1 */

                if (OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_BANCO == 1)
                {

                    /*" -686- MOVE 1 TO MOV-OUTROBC-NUM-SEQUENCIA */
                    _.Move(1, MOV_OUTROS_BANCOS.MOV_OUTROBC_NUM_SEQUENCIA);

                    /*" -687- ELSE */
                }
                else
                {


                    /*" -688- MOVE 2 TO MOV-OUTROBC-NUM-SEQUENCIA */
                    _.Move(2, MOV_OUTROS_BANCOS.MOV_OUTROBC_NUM_SEQUENCIA);

                    /*" -689- END-IF */
                }


                /*" -690- MOVE OD009-COD-BANCO TO MOV-OUTROBC-COD-BANCO */
                _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_BANCO, MOV_OUTROS_BANCOS.MOV_OUTROBC_COD_BANCO);

                /*" -692- MOVE HISLANCT-NUM-CERTIFICADO TO MOV-OUTROBC-NUM-CERTIFICADO */
                _.Move(HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO, MOV_OUTROS_BANCOS.MOV_OUTROBC_NUM_CERTIFICADO);

                /*" -694- MOVE HISLANCT-NUM-PARCELA TO MOV-OUTROBC-NUM-PARCELA */
                _.Move(HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA, MOV_OUTROS_BANCOS.MOV_OUTROBC_NUM_PARCELA);

                /*" -696- MOVE COBHISVI-NUM-TITULO TO MOV-OUTROBC-NUM-TITULO */
                _.Move(COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO, MOV_OUTROS_BANCOS.MOV_OUTROBC_NUM_TITULO);

                /*" -698- MOVE VG079-NUM-OCORR-MOVTO TO MOV-OUTROBC-NUM-OCORR-MOVTO */
                _.Move(VG079.DCLVG_PESS_PARCELA.VG079_NUM_OCORR_MOVTO, MOV_OUTROS_BANCOS.MOV_OUTROBC_NUM_OCORR_MOVTO);

                /*" -699- MOVE GE368-NUM-PESSOA TO MOV-OUTROBC-NUM-PESSOA */
                _.Move(GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_PESSOA, MOV_OUTROS_BANCOS.MOV_OUTROBC_NUM_PESSOA);

                /*" -700- ADD 1 TO W-EM-OUTROS-BANCOS */
                WORK_AREA.W_EM_OUTROS_BANCOS.Value = WORK_AREA.W_EM_OUTROS_BANCOS + 1;

                /*" -701- WRITE MOVIMENTO-OUTROSBC FROM MOV-OUTROS-BANCOS */
                _.Move(MOV_OUTROS_BANCOS.GetMoveValues(), MOVIMENTO_OUTROSBC);

                OUTROSBC.Write(MOVIMENTO_OUTROSBC.GetMoveValues().ToString());

                /*" -708- GO TO R1000-LE-REGISTRO. */

                R1000_LE_REGISTRO(); //GOTO
                return;
            }


            /*" -710- MOVE OD009-COD-AGENCIA TO ME-AGENCIA. */
            _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_AGENCIA, MOV_LANCAMENTO.ME_AGENCIA);

            /*" -712- MOVE OD009-NUM-OPERACAO-CONTA TO ME-OPR-CTA-CORR. */
            _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_OPERACAO_CONTA, MOV_LANCAMENTO.ME_IDENT_CLI_BANCO.ME_OPR_CTA_CORR);

            /*" -714- MOVE OD009-NUM-PESSOA TO ME-NUM-PESSOA. */
            _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_PESSOA, MOV_LANCAMENTO.ME_NUM_PESSOA);

            /*" -720- MOVE OD009-SEQ-CONTA-BANCARIA TO ME-SEQ-CTA-BANC. */
            _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_SEQ_CONTA_BANCARIA, MOV_LANCAMENTO.ME_SEQ_CTA_BANC);

            /*" -721- MOVE OD009-NUM-CONTA TO W-NUM-CONTA-NUM8 */
            _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_CONTA, WORK_AREA.W_NUM_CONTA_NUM8);

            /*" -732- MOVE W-NUM-CONTA-NUM8 TO ME-NUM-CTA-CORR. */
            _.Move(WORK_AREA.W_NUM_CONTA_NUM8, MOV_LANCAMENTO.ME_IDENT_CLI_BANCO.ME_NUM_CTA_CORR);

            /*" -733- MOVE OD009-NUM-DV-CONTA TO W-DV-CONTA-ODS-ALFA */
            _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_DV_CONTA, WORK_AREA.W_DV_CONTA_ODS_ALFA);

            /*" -734- IF W-DV-CONTA-ODS-NUM-2 IS NUMERIC */

            if (WORK_AREA.W_DV_CONTA_ODS_NUM.W_DV_CONTA_ODS_NUM_2.IsNumeric())
            {

                /*" -735- MOVE W-DV-CONTA-ODS-NUM-2 TO ME-DAC-CTA-CORR */
                _.Move(WORK_AREA.W_DV_CONTA_ODS_NUM.W_DV_CONTA_ODS_NUM_2, MOV_LANCAMENTO.ME_IDENT_CLI_BANCO.ME_DAC_CTA_CORR);

                /*" -736- ELSE */
            }
            else
            {


                /*" -737- IF W-DV-CONTA-ODS-NUM-1 IS NUMERIC */

                if (WORK_AREA.W_DV_CONTA_ODS_NUM.W_DV_CONTA_ODS_NUM_1.IsNumeric())
                {

                    /*" -738- MOVE W-DV-CONTA-ODS-NUM-1 TO ME-DAC-CTA-CORR */
                    _.Move(WORK_AREA.W_DV_CONTA_ODS_NUM.W_DV_CONTA_ODS_NUM_1, MOV_LANCAMENTO.ME_IDENT_CLI_BANCO.ME_DAC_CTA_CORR);

                    /*" -739- ELSE */
                }
                else
                {


                    /*" -745- MOVE 0 TO ME-DAC-CTA-CORR . */
                    _.Move(0, MOV_LANCAMENTO.ME_IDENT_CLI_BANCO.ME_DAC_CTA_CORR);
                }

            }


            /*" -746- MOVE VLPRMTOT TO ME-VALOR. */
            _.Move(VLPRMTOT, MOV_LANCAMENTO.ME_VALOR);

            /*" -747- MOVE SPACES TO ME-IDENT-CLI-EMPRESA. */
            _.Move("", MOV_LANCAMENTO.ME_IDENT_CLI_EMPRESA);

            /*" -749- MOVE NRCERTIF TO ME-IDENT-CLI. */
            _.Move(NRCERTIF, MOV_LANCAMENTO.ME_IDENT_CLI_EMPRESA.ME_IDENT_CLI);

            /*" -751- MOVE PARM-NSA TO ME-NSA-PARM. */
            _.Move(PARM_NSA, MOV_LANCAMENTO.ME_IDENT_CLI_EMPRESA.ME_NSA_PARM);

            /*" -753- WRITE MOVIMENTO-RECORD FROM MOV-LANCAMENTO. */
            _.Move(MOV_LANCAMENTO.GetMoveValues(), MOVIMENTO_RECORD);

            MOVIMENTO.Write(MOVIMENTO_RECORD.GetMoveValues().ToString());

            /*" -754- ADD 1 TO AC-REGISTROS. */
            WORK_AREA.AC_REGISTROS.Value = WORK_AREA.AC_REGISTROS + 1;

            /*" -754- ADD VLPRMTOT TO AC-VALOR. */
            WORK_AREA.AC_VALOR.Value = WORK_AREA.AC_VALOR + VLPRMTOT;

        }

        [StopWatch]
        /*" R1000-LE-REGISTRO */
        private void R1000_LE_REGISTRO(bool isPerform = false)
        {
            /*" -761- MOVE '1000-PROCESSA' TO PARAGRAFO. */
            _.Move("1000-PROCESSA", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -763- MOVE 'UPDATE V0HISTCONTAVA' TO COMANDO. */
            _.Move("UPDATE V0HISTCONTAVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -770- PERFORM R1000_LE_REGISTRO_DB_UPDATE_1 */

            R1000_LE_REGISTRO_DB_UPDATE_1();

            /*" -773- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -773- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1000-LE-REGISTRO-DB-UPDATE-1 */
        public void R1000_LE_REGISTRO_DB_UPDATE_1()
        {
            /*" -770- EXEC SQL UPDATE SEGUROS.V0HISTCONTAVA SET SITUACAO = '3' , DTVENCTO = :SIST-DTCREDITO, NSAS = :PARM-NSA:SQL-NOT-NULL, NSL = :NSL:SQL-NOT-NULL WHERE CURRENT OF RESSARC END-EXEC. */

            var r1000_LE_REGISTRO_DB_UPDATE_1_Update1 = new R1000_LE_REGISTRO_DB_UPDATE_1_Update1(RESSARC)
            {
                PARM_NSA = PARM_NSA.ToString(),
                SQL_NOT_NULL = SQL_NOT_NULL.ToString(),
                NSL = NSL.ToString(),
                SIST_DTCREDITO = SIST_DTCREDITO.ToString(),
            };

            R1000_LE_REGISTRO_DB_UPDATE_1_Update1.Execute(r1000_LE_REGISTRO_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1000-SEM-REDUCAO-CHEQUE */
        private void R1000_SEM_REDUCAO_CHEQUE(bool isPerform = false)
        {
            /*" -779- PERFORM R0101-FETCH-DEVOLUCAO THRU R0101-EXIT. */

            R0101_FETCH_DEVOLUCAO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R0101_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_FIM*/

        [StopWatch]
        /*" R2000-ACESSA-REDUCAO-CHEQUE */
        private void R2000_ACESSA_REDUCAO_CHEQUE(bool isPerform = false)
        {
            /*" -786- MOVE 'R2000-ACESSA-REDUCAO-CHEQUE' TO PARAGRAFO. */
            _.Move("R2000-ACESSA-REDUCAO-CHEQUE", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -787- MOVE 'FETCH REDUCAO DE CHEQUE           ' TO COMANDO. */
            _.Move("FETCH REDUCAO DE CHEQUE           ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -854- PERFORM R2000_ACESSA_REDUCAO_CHEQUE_DB_SELECT_1 */

            R2000_ACESSA_REDUCAO_CHEQUE_DB_SELECT_1();

            /*" -860- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -862- MOVE 'SIM' TO W-ACHOU-REDUCAO-CHEQUE. */
                _.Move("SIM", WORK_AREA.W_ACHOU_REDUCAO_CHEQUE);
            }


            /*" -863- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -865- MOVE 'NAO' TO W-ACHOU-REDUCAO-CHEQUE. */
                _.Move("NAO", WORK_AREA.W_ACHOU_REDUCAO_CHEQUE);
            }


            /*" -866- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -867- DISPLAY 'VA0341B - ERRO FETCH - PESQUISANDO BANCO' */
                _.Display($"VA0341B - ERRO FETCH - PESQUISANDO BANCO");

                /*" -868- DISPLAY 'NUM_CERTIFICADO  = ' NRCERTIF */
                _.Display($"NUM_CERTIFICADO  = {NRCERTIF}");

                /*" -869- DISPLAY 'NUM_PARCELA      = ' NRPARCEL */
                _.Display($"NUM_PARCELA      = {NRPARCEL}");

                /*" -869- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2000-ACESSA-REDUCAO-CHEQUE-DB-SELECT-1 */
        public void R2000_ACESSA_REDUCAO_CHEQUE_DB_SELECT_1()
        {
            /*" -854- EXEC SQL SELECT H.NUM_CERTIFICADO, H.NUM_PARCELA, C.NUM_TITULO, H.PRM_TOTAL, H.SIT_REGISTRO, H.DATA_VENCIMENTO, H.NSAS, H.NSL, H.CODCONV, P.NUM_OCORR_MOVTO, B.NUM_PESSOA, B.SEQ_CONTA_BANCARIA, B.COD_BANCO, B.COD_AGENCIA, B.NUM_CONTA, B.NUM_DV_CONTA, B.NUM_OPERACAO_CONTA, E.NUM_OCORR_MOVTO, E.NUM_PESSOA INTO :HISLANCT-NUM-CERTIFICADO, :HISLANCT-NUM-PARCELA, :COBHISVI-NUM-TITULO, :HISLANCT-PRM-TOTAL, :HISLANCT-SIT-REGISTRO, :HISLANCT-DATA-VENCIMENTO, :HISLANCT-NSAS:SQL-MAYBE-NULL1, :HISLANCT-NSL:SQL-MAYBE-NULL2, :HISLANCT-CODCONV, :VG079-NUM-OCORR-MOVTO, :OD009-NUM-PESSOA, :OD009-SEQ-CONTA-BANCARIA, :OD009-COD-BANCO, :OD009-COD-AGENCIA, :OD009-NUM-CONTA, :OD009-NUM-DV-CONTA, :OD009-NUM-OPERACAO-CONTA, :GE368-NUM-OCORR-MOVTO, :GE368-NUM-PESSOA FROM SEGUROS.HIST_LANC_CTA H, SEGUROS.COBER_HIST_VIDAZUL C, SEGUROS.VG_PESS_PARCELA P, SEGUROS.GE_MOVIMENTO M, SEGUROS.GE_LEG_PESS_EVENTO E, ODS.OD_PESS_CONTA_BANC B WHERE H.NUM_CERTIFICADO = :NRCERTIF AND H.NUM_PARCELA = :NRPARCEL AND H.SIT_REGISTRO = '0' AND H.TIPLANC = '2' AND H.PRM_TOTAL <> 0 AND H.CODCONV = 6090 AND H.NUM_CONTA_DEBITO > 0 AND C.NUM_CERTIFICADO = H.NUM_CERTIFICADO AND C.NUM_PARCELA = H.NUM_PARCELA AND P.NUM_TITULO = C.NUM_TITULO AND P.NUM_CERTIFICADO = H.NUM_CERTIFICADO AND P.NUM_PARCELA = H.NUM_PARCELA AND M.NUM_OCORR_MOVTO = P.NUM_OCORR_MOVTO AND M.IND_EVENTO = 1 AND E.NUM_OCORR_MOVTO = P.NUM_OCORR_MOVTO AND E.IND_ENTIDADE = 3 AND B.NUM_PESSOA = E.NUM_PESSOA AND B.SEQ_CONTA_BANCARIA = E.SEQ_ENTIDADE ORDER BY E.NUM_OCORR_MOVTO DESC FETCH FIRST 1 ROWS ONLY END-EXEC. */

            var r2000_ACESSA_REDUCAO_CHEQUE_DB_SELECT_1_Query1 = new R2000_ACESSA_REDUCAO_CHEQUE_DB_SELECT_1_Query1()
            {
                NRCERTIF = NRCERTIF.ToString(),
                NRPARCEL = NRPARCEL.ToString(),
            };

            var executed_1 = R2000_ACESSA_REDUCAO_CHEQUE_DB_SELECT_1_Query1.Execute(r2000_ACESSA_REDUCAO_CHEQUE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISLANCT_NUM_CERTIFICADO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO);
                _.Move(executed_1.HISLANCT_NUM_PARCELA, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA);
                _.Move(executed_1.COBHISVI_NUM_TITULO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO);
                _.Move(executed_1.HISLANCT_PRM_TOTAL, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_PRM_TOTAL);
                _.Move(executed_1.HISLANCT_SIT_REGISTRO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO);
                _.Move(executed_1.HISLANCT_DATA_VENCIMENTO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_DATA_VENCIMENTO);
                _.Move(executed_1.HISLANCT_NSAS, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NSAS);
                _.Move(executed_1.SQL_MAYBE_NULL1, SQL_MAYBE_NULL1);
                _.Move(executed_1.HISLANCT_NSL, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NSL);
                _.Move(executed_1.SQL_MAYBE_NULL2, SQL_MAYBE_NULL2);
                _.Move(executed_1.HISLANCT_CODCONV, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_CODCONV);
                _.Move(executed_1.VG079_NUM_OCORR_MOVTO, VG079.DCLVG_PESS_PARCELA.VG079_NUM_OCORR_MOVTO);
                _.Move(executed_1.OD009_NUM_PESSOA, OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_PESSOA);
                _.Move(executed_1.OD009_SEQ_CONTA_BANCARIA, OD009.DCLOD_PESS_CONTA_BANC.OD009_SEQ_CONTA_BANCARIA);
                _.Move(executed_1.OD009_COD_BANCO, OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_BANCO);
                _.Move(executed_1.OD009_COD_AGENCIA, OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_AGENCIA);
                _.Move(executed_1.OD009_NUM_CONTA, OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_CONTA);
                _.Move(executed_1.OD009_NUM_DV_CONTA, OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_DV_CONTA);
                _.Move(executed_1.OD009_NUM_OPERACAO_CONTA, OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_OPERACAO_CONTA);
                _.Move(executed_1.GE368_NUM_OCORR_MOVTO, GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_OCORR_MOVTO);
                _.Move(executed_1.GE368_NUM_PESSOA, GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_PESSOA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_EXIT*/

        [StopWatch]
        /*" R3000-GERA-DEVOLUCAO */
        private void R3000_GERA_DEVOLUCAO(bool isPerform = false)
        {
            /*" -878- MOVE 'R3000-GERA-DEVOLUCAO       ' TO PARAGRAFO. */
            _.Move("R3000-GERA-DEVOLUCAO       ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -880- MOVE 'R3000-GERA-DEVOLUCAO              ' TO COMANDO. */
            _.Move("R3000-GERA-DEVOLUCAO              ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -881- MOVE AGECTADEB TO ME-AGENCIA. */
            _.Move(AGECTADEB, MOV_LANCAMENTO.ME_AGENCIA);

            /*" -882- MOVE OPRCTADEB TO ME-OPR-CTA-CORR. */
            _.Move(OPRCTADEB, MOV_LANCAMENTO.ME_IDENT_CLI_BANCO.ME_OPR_CTA_CORR);

            /*" -883- MOVE NUMCTADEB TO ME-NUM-CTA-CORR. */
            _.Move(NUMCTADEB, MOV_LANCAMENTO.ME_IDENT_CLI_BANCO.ME_NUM_CTA_CORR);

            /*" -884- MOVE DIGCTADEB TO ME-DAC-CTA-CORR. */
            _.Move(DIGCTADEB, MOV_LANCAMENTO.ME_IDENT_CLI_BANCO.ME_DAC_CTA_CORR);

            /*" -885- MOVE VLPRMTOT TO ME-VALOR. */
            _.Move(VLPRMTOT, MOV_LANCAMENTO.ME_VALOR);

            /*" -886- MOVE SPACES TO ME-IDENT-CLI-EMPRESA. */
            _.Move("", MOV_LANCAMENTO.ME_IDENT_CLI_EMPRESA);

            /*" -887- MOVE NRCERTIF TO ME-IDENT-CLI. */
            _.Move(NRCERTIF, MOV_LANCAMENTO.ME_IDENT_CLI_EMPRESA.ME_IDENT_CLI);

            /*" -888- MOVE PARM-NSA TO ME-NSA-PARM. */
            _.Move(PARM_NSA, MOV_LANCAMENTO.ME_IDENT_CLI_EMPRESA.ME_NSA_PARM);

            /*" -889- MOVE ZEROS TO ME-NUM-PESSOA. */
            _.Move(0, MOV_LANCAMENTO.ME_NUM_PESSOA);

            /*" -891- MOVE ZEROS TO ME-SEQ-CTA-BANC. */
            _.Move(0, MOV_LANCAMENTO.ME_SEQ_CTA_BANC);

            /*" -893- WRITE MOVIMENTO-RECORD FROM MOV-LANCAMENTO. */
            _.Move(MOV_LANCAMENTO.GetMoveValues(), MOVIMENTO_RECORD);

            MOVIMENTO.Write(MOVIMENTO_RECORD.GetMoveValues().ToString());

            /*" -894- ADD 1 TO AC-REGISTROS. */
            WORK_AREA.AC_REGISTROS.Value = WORK_AREA.AC_REGISTROS + 1;

            /*" -894- ADD VLPRMTOT TO AC-VALOR. */
            WORK_AREA.AC_VALOR.Value = WORK_AREA.AC_VALOR + VLPRMTOT;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_EXIT*/

        [StopWatch]
        /*" R5000-GRAVA-RELATORIOS */
        private void R5000_GRAVA_RELATORIOS(bool isPerform = false)
        {
            /*" -905- MOVE '0075-SOLICITA-RELAT' TO PARAGRAFO. */
            _.Move("0075-SOLICITA-RELAT", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -907- MOVE 'INSERT V0RELATORIOS' TO COMANDO. */
            _.Move("INSERT V0RELATORIOS", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -950- PERFORM R5000_GRAVA_RELATORIOS_DB_INSERT_1 */

            R5000_GRAVA_RELATORIOS_DB_INSERT_1();

            /*" -953- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -954- DISPLAY 'VA0341B - PROBLEMAS NA INCLUSAO VA0473B' */
                _.Display($"VA0341B - PROBLEMAS NA INCLUSAO VA0473B");

                /*" -954- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R5000-GRAVA-RELATORIOS-DB-INSERT-1 */
        public void R5000_GRAVA_RELATORIOS_DB_INSERT_1()
        {
            /*" -950- EXEC SQL INSERT INTO SEGUROS.V0RELATORIOS VALUES ( 'VA0341B' , :SIST-CURRDATE, 'VA' , 'VA0473B' , :PARM-NSA, 0, :SIST-CURRDATE, :SIST-CURRDATE, :SIST-CURRDATE, 0, 0, 0, 0, 0, 0, 0, 0, 97010000889, 0, 0, 0, 0, 0, 0, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '0' , ' ' , ' ' , NULL, 0, 0, CURRENT TIMESTAMP) END-EXEC. */

            var r5000_GRAVA_RELATORIOS_DB_INSERT_1_Insert1 = new R5000_GRAVA_RELATORIOS_DB_INSERT_1_Insert1()
            {
                SIST_CURRDATE = SIST_CURRDATE.ToString(),
                PARM_NSA = PARM_NSA.ToString(),
            };

            R5000_GRAVA_RELATORIOS_DB_INSERT_1_Insert1.Execute(r5000_GRAVA_RELATORIOS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_EXIT*/

        [StopWatch]
        /*" R9000-FINALIZA */
        private void R9000_FINALIZA(bool isPerform = false)
        {
            /*" -964- ADD 1 TO AC-REGISTROS. */
            WORK_AREA.AC_REGISTROS.Value = WORK_AREA.AC_REGISTROS + 1;

            /*" -966- MOVE AC-REGISTROS TO MZ-QTDE-REGISTROS WS-DISPLAY-QUANT. */
            _.Move(WORK_AREA.AC_REGISTROS, MOV_TRAILLER.MZ_QTDE_REGISTROS, WORK_AREA.WS_DISPLAY_QUANT);

            /*" -968- MOVE AC-VALOR TO MZ-TOT-VAL-CRUZ WS-DISPLAY-VALOR. */
            _.Move(WORK_AREA.AC_VALOR, MOV_TRAILLER.MZ_TOT_VAL_CRUZ, WORK_AREA.WS_DISPLAY_VALOR);

            /*" -969- MOVE PARM-NSA TO WS-DISPLAY-NSA. */
            _.Move(PARM_NSA, WORK_AREA.WS_DISPLAY_NSA);

            /*" -971- WRITE MOVIMENTO-RECORD FROM MOV-TRAILLER. */
            _.Move(MOV_TRAILLER.GetMoveValues(), MOVIMENTO_RECORD);

            MOVIMENTO.Write(MOVIMENTO_RECORD.GetMoveValues().ToString());

            /*" -972- DISPLAY '*** VA0341B *** CONVENIO   6090' . */
            _.Display($"*** VA0341B *** CONVENIO   6090");

            /*" -973- DISPLAY '*** VA0341B *** NSA        ' WS-DISPLAY-NSA. */
            _.Display($"*** VA0341B *** NSA        {WORK_AREA.WS_DISPLAY_NSA}");

            /*" -975- DISPLAY '*** VA0341B *** QUANTIDADE CAIXA ' WS-DISPLAY-QUANT. */
            _.Display($"*** VA0341B *** QUANTIDADE CAIXA {WORK_AREA.WS_DISPLAY_QUANT}");

            /*" -976- MOVE W-EM-OUTROS-BANCOS TO WS-DISPLAY-OUTROS-BANCOS. */
            _.Move(WORK_AREA.W_EM_OUTROS_BANCOS, WORK_AREA.WS_DISPLAY_OUTROS_BANCOS);

            /*" -978- DISPLAY '*** VA0341B *** OUTROS BANCOS    ' WS-DISPLAY-OUTROS-BANCOS. */
            _.Display($"*** VA0341B *** OUTROS BANCOS    {WORK_AREA.WS_DISPLAY_OUTROS_BANCOS}");

            /*" -980- DISPLAY '*** VA0341B *** VALOR      ' WS-DISPLAY-VALOR. */
            _.Display($"*** VA0341B *** VALOR      {WORK_AREA.WS_DISPLAY_VALOR}");

            /*" -981- DISPLAY 'REGISTROS LIDOS            ' AC-LIDOS. */
            _.Display($"REGISTROS LIDOS            {WORK_AREA.AC_LIDOS}");

            /*" -982- DISPLAY 'ESTRUTURA REDUCAO CHEQUES  ' AC-IND-REDUCAO. */
            _.Display($"ESTRUTURA REDUCAO CHEQUES  {WORK_AREA.AC_IND_REDUCAO}");

            /*" -984- DISPLAY 'SEM       REDUCAO CHEQUES  ' AC-IND-SEM. */
            _.Display($"SEM       REDUCAO CHEQUES  {WORK_AREA.AC_IND_SEM}");

            /*" -985- MOVE '9000-FINALIZA' TO PARAGRAFO. */
            _.Move("9000-FINALIZA", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -987- MOVE 'UPDATE V0CONVSUCOV' TO COMANDO. */
            _.Move("UPDATE V0CONVSUCOV", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -991- PERFORM R9000_FINALIZA_DB_UPDATE_1 */

            R9000_FINALIZA_DB_UPDATE_1();

            /*" -994- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -996- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -998- MOVE 'INSERT V0FITASASSE' TO COMANDO. */
            _.Move("INSERT V0FITASASSE", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -999- MOVE AC-REGISTROS TO FITSAS-REG. */
            _.Move(WORK_AREA.AC_REGISTROS, FITSAS_REG);

            /*" -1001- MOVE AC-VALOR TO FITSAS-VALOR. */
            _.Move(WORK_AREA.AC_VALOR, FITSAS_VALOR);

            /*" -1021- PERFORM R9000_FINALIZA_DB_INSERT_1 */

            R9000_FINALIZA_DB_INSERT_1();

            /*" -1024- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1025- DISPLAY 'PARM-CODCONV   - ' PARM-CODCONV */
                _.Display($"PARM-CODCONV   - {PARM_CODCONV}");

                /*" -1026- DISPLAY 'PARM-NSA       - ' PARM-NSA */
                _.Display($"PARM-NSA       - {PARM_NSA}");

                /*" -1027- DISPLAY 'SIST-CURRDATE  - ' SIST-CURRDATE */
                _.Display($"SIST-CURRDATE  - {SIST_CURRDATE}");

                /*" -1028- DISPLAY 'SIST-DTCREDITO - ' SIST-DTCREDITO */
                _.Display($"SIST-DTCREDITO - {SIST_DTCREDITO}");

                /*" -1029- DISPLAY 'PARM-VERSAO    - ' PARM-VERSAO */
                _.Display($"PARM-VERSAO    - {PARM_VERSAO}");

                /*" -1030- DISPLAY 'FITSAS-REG     - ' FITSAS-REG */
                _.Display($"FITSAS-REG     - {FITSAS_REG}");

                /*" -1031- DISPLAY 'FITSAS-VALOR   - ' FITSAS-VALOR */
                _.Display($"FITSAS-VALOR   - {FITSAS_VALOR}");

                /*" -1032- DISPLAY 'FITSAS-NSL     - ' FITSAS-NSL */
                _.Display($"FITSAS-NSL     - {FITSAS_NSL}");

                /*" -1032- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R9000-FINALIZA-DB-UPDATE-1 */
        public void R9000_FINALIZA_DB_UPDATE_1()
        {
            /*" -991- EXEC SQL UPDATE SEGUROS.V0CONVSUCOV SET NSA_CONVENIO = :PARM-NSA WHERE COD_CONVENIO = 6090 END-EXEC. */

            var r9000_FINALIZA_DB_UPDATE_1_Update1 = new R9000_FINALIZA_DB_UPDATE_1_Update1()
            {
                PARM_NSA = PARM_NSA.ToString(),
            };

            R9000_FINALIZA_DB_UPDATE_1_Update1.Execute(r9000_FINALIZA_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R9000-FINALIZA-DB-INSERT-1 */
        public void R9000_FINALIZA_DB_INSERT_1()
        {
            /*" -1021- EXEC SQL INSERT INTO SEGUROS.V0FITASASSE VALUES (:PARM-CODCONV, :PARM-NSA, :SIST-CURRDATE, :SIST-DTCREDITO, 'VA0341B' , '3' , 01, :PARM-VERSAO, :FITSAS-REG, 0, :FITSAS-VALOR, :FITSAS-NSL, 0, 0, 0, 0, 0, 0) END-EXEC. */

            var r9000_FINALIZA_DB_INSERT_1_Insert1 = new R9000_FINALIZA_DB_INSERT_1_Insert1()
            {
                PARM_CODCONV = PARM_CODCONV.ToString(),
                PARM_NSA = PARM_NSA.ToString(),
                SIST_CURRDATE = SIST_CURRDATE.ToString(),
                SIST_DTCREDITO = SIST_DTCREDITO.ToString(),
                PARM_VERSAO = PARM_VERSAO.ToString(),
                FITSAS_REG = FITSAS_REG.ToString(),
                FITSAS_VALOR = FITSAS_VALOR.ToString(),
                FITSAS_NSL = FITSAS_NSL.ToString(),
            };

            R9000_FINALIZA_DB_INSERT_1_Insert1.Execute(r9000_FINALIZA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_EXIT*/

        [StopWatch]
        /*" R900000-DISPLAY-REDUCAO-CHEQUE */
        private void R900000_DISPLAY_REDUCAO_CHEQUE(bool isPerform = false)
        {
            /*" -1040- DISPLAY 'HISLANCT-NUM-CERTIFICADO ......... ' HISLANCT-NUM-CERTIFICADO */
            _.Display($"HISLANCT-NUM-CERTIFICADO ......... {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO}");

            /*" -1042- DISPLAY 'HISLANCT-NUM-PARCELA ............. ' HISLANCT-NUM-PARCELA */
            _.Display($"HISLANCT-NUM-PARCELA ............. {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA}");

            /*" -1044- DISPLAY 'COBHISVI-NUM-TITULO .............. ' COBHISVI-NUM-TITULO */
            _.Display($"COBHISVI-NUM-TITULO .............. {COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO}");

            /*" -1046- DISPLAY 'HISLANCT-PRM-TOTAL ............... ' HISLANCT-PRM-TOTAL */
            _.Display($"HISLANCT-PRM-TOTAL ............... {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_PRM_TOTAL}");

            /*" -1048- DISPLAY 'HISLANCT-SIT-REGISTRO ............ ' HISLANCT-SIT-REGISTRO */
            _.Display($"HISLANCT-SIT-REGISTRO ............ {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO}");

            /*" -1050- DISPLAY 'HISLANCT-DATA-VENCIMENTO ......... ' HISLANCT-DATA-VENCIMENTO */
            _.Display($"HISLANCT-DATA-VENCIMENTO ......... {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_DATA_VENCIMENTO}");

            /*" -1052- DISPLAY 'HISLANCT-NSAS .................... ' HISLANCT-NSAS */
            _.Display($"HISLANCT-NSAS .................... {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NSAS}");

            /*" -1054- DISPLAY 'HISLANCT-NSL ..................... ' HISLANCT-NSL */
            _.Display($"HISLANCT-NSL ..................... {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NSL}");

            /*" -1056- DISPLAY 'HISLANCT-CODCONV ................. ' HISLANCT-CODCONV */
            _.Display($"HISLANCT-CODCONV ................. {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_CODCONV}");

            /*" -1058- DISPLAY 'VG079-NUM-OCORR-MOVTO ............ ' VG079-NUM-OCORR-MOVTO */
            _.Display($"VG079-NUM-OCORR-MOVTO ............ {VG079.DCLVG_PESS_PARCELA.VG079_NUM_OCORR_MOVTO}");

            /*" -1060- DISPLAY 'OD009-COD-BANCO .................. ' OD009-COD-BANCO */
            _.Display($"OD009-COD-BANCO .................. {OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_BANCO}");

            /*" -1062- DISPLAY 'OD009-COD-AGENCIA ................ ' OD009-COD-AGENCIA */
            _.Display($"OD009-COD-AGENCIA ................ {OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_AGENCIA}");

            /*" -1064- DISPLAY 'OD009-NUM-CONTA .................. ' OD009-NUM-CONTA */
            _.Display($"OD009-NUM-CONTA .................. {OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_CONTA}");

            /*" -1066- DISPLAY 'OD009-NUM-DV-CONTA ............... ' OD009-NUM-DV-CONTA */
            _.Display($"OD009-NUM-DV-CONTA ............... {OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_DV_CONTA}");

            /*" -1068- DISPLAY 'OD009-NUM-OPERACAO-CONTA ......... ' OD009-NUM-OPERACAO-CONTA */
            _.Display($"OD009-NUM-OPERACAO-CONTA ......... {OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_OPERACAO_CONTA}");

            /*" -1070- DISPLAY 'GE368-NUM-OCORR-MOVTO ............ ' GE368-NUM-OCORR-MOVTO */
            _.Display($"GE368-NUM-OCORR-MOVTO ............ {GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_OCORR_MOVTO}");

            /*" -1071- DISPLAY 'GE368-NUM-PESSOA ................. ' GE368-NUM-PESSOA . */
            _.Display($"GE368-NUM-PESSOA ................. {GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_PESSOA}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R900000_EXIT*/

        [StopWatch]
        /*" M-9999-ERRO */
        private void M_9999_ERRO(bool isPerform = false)
        {
            /*" -1081- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WORK_AREA.WABEND.WSQLCODE);

            /*" -1082- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], WORK_AREA.WABEND.WSQLERRD1);

            /*" -1083- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], WORK_AREA.WABEND.WSQLERRD2);

            /*" -1084- DISPLAY WABEND. */
            _.Display(WORK_AREA.WABEND);

            /*" -1085- DISPLAY LOCALIZA-ABEND-1. */
            _.Display(WORK_AREA.LOCALIZA_ABEND_1);

            /*" -1087- DISPLAY LOCALIZA-ABEND-2. */
            _.Display(WORK_AREA.LOCALIZA_ABEND_2);

            /*" -1087- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1089- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1093- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1093- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}