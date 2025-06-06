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
using Sias.Sinistro.DB2.SI0234B;

namespace Code
{
    public class SI0234B
    {
        public bool IsCall { get; set; }

        public SI0234B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SINISTRO / RESSARCIMENTO           *      */
        /*"      *   PROGRAMA ...............  SI0234B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  HEIDER                             *      */
        /*"      *   PROGRAMADOR ............  HEIDER                             *      */
        /*"      *   DATA CODIFICACAO .......  MARCO / 2009                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO ....... PROGRAMA RESPONSAVEL PELA INTEGRACAO DO       *      */
        /*"      *          DOS PEDIDOS DE EMISSAO DE SEGUNDA VIA DE RECIBO       *      */
        /*"      *          SOLICITADO VIA O RESSARCIMENTOWEB                     *      */
        /*"      *          DOS SINISTROS INDENIZADOS DE CREDITO                  *      */
        /*"      *          COPIA DA APLICACAO 13-12-37 - SI1LA                          */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  Avaliado pelo projeto JV1 em 15/01/2019                       *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _REG_ENT { get; set; } = new FileBasis(new PIC("X", "100", "X(100)"));

        public FileBasis REG_ENT
        {
            get
            {
                _.Move(REGISTRO_ENTRADA, _REG_ENT); VarBasis.RedefinePassValue(REGISTRO_ENTRADA, _REG_ENT, REGISTRO_ENTRADA); return _REG_ENT;
            }
        }
        public FileBasis _REG_RET { get; set; } = new FileBasis(new PIC("X", "100", "X(100)"));

        public FileBasis REG_RET
        {
            get
            {
                _.Move(REGISTRO_ENTRADA_RETORNO, _REG_RET); VarBasis.RedefinePassValue(REGISTRO_ENTRADA_RETORNO, _REG_RET, REGISTRO_ENTRADA_RETORNO); return _REG_RET;
            }
        }
        /*"01  REGISTRO-ENTRADA        PIC X(100).*/
        public StringBasis REGISTRO_ENTRADA { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
        /*"01  REGISTRO-ENTRADA-RETORNO PIC X(100).*/
        public StringBasis REGISTRO_ENTRADA_RETORNO { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  VIND-DTH-PAGAMENTO             PIC S9(04)    COMP   VALUE +0*/
        public IntBasis VIND_DTH_PAGAMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  VIND-SI112-DTC-CANCELA-ACORDO  PIC S9(04)    COMP   VALUE +0*/
        public IntBasis VIND_SI112_DTC_CANCELA_ACORDO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HOST-MAX-OCORHIST-HISTSINI     PIC S9(04)    COMP   VALUE +0*/
        public IntBasis HOST_MAX_OCORHIST_HISTSINI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HOST-COUNT                     PIC S9(04)    COMP   VALUE +0*/
        public IntBasis HOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HOST-COUNT-PARCELAS-INTEGRADAS PIC S9(09)    COMP   VALUE +0*/
        public IntBasis HOST_COUNT_PARCELAS_INTEGRADAS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  HOST-NUM-RESSARC               PIC S9(09)    COMP   VALUE +0*/
        public IntBasis HOST_NUM_RESSARC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  HOST-MAIOR-ACORDO-SINISTRO     PIC S9(09)    COMP   VALUE +0*/
        public IntBasis HOST_MAIOR_ACORDO_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  HOST-DTH-ACORDO                PIC  X(10)          VALUE ' '*/
        public StringBasis HOST_DTH_ACORDO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @" ");
        /*"01  W-REGISTRO-ENTRADA.*/
        public SI0234B_W_REGISTRO_ENTRADA W_REGISTRO_ENTRADA { get; set; } = new SI0234B_W_REGISTRO_ENTRADA();
        public class SI0234B_W_REGISTRO_ENTRADA : VarBasis
        {
            /*"    05 TIPO-REGISTRO-ALFA       PIC X(002)  VALUE SPACES.*/
            public StringBasis TIPO_REGISTRO_ALFA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"    05 FILLER                   PIC X(001)  VALUE SPACES.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05 NUM-APOL-SINISTRO        PIC 9(013)  VALUE ZEROS.*/
            public IntBasis NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"    05 FILLER                   PIC X(001)  VALUE SPACES.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05 MENSAGEM-CRITICA         PIC X(080)  VALUE SPACES.*/
            public StringBasis MENSAGEM_CRITICA { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"");
            /*"    05 FILLER                   PIC X(001)  VALUE SPACES.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"01  AREA-DE-WORK.*/
        }
        public SI0234B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SI0234B_AREA_DE_WORK();
        public class SI0234B_AREA_DE_WORK : VarBasis
        {
            /*"    05 W-EDICAO                      PIC ZZZ.ZZZ.ZZ9.*/
            public IntBasis W_EDICAO { get; set; } = new IntBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9."));
            /*"    05 WFIM-REGISTRO-ENTRADA         PIC X(03) VALUE 'NAO'.*/
            public StringBasis WFIM_REGISTRO_ENTRADA { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    05 W-CHAVE-CRED-COMERCIAL        PIC X(03)    VALUE 'NAO'.*/
            public StringBasis W_CHAVE_CRED_COMERCIAL { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    05 W-CHAVE-MATCON                PIC X(03)    VALUE 'NAO'.*/
            public StringBasis W_CHAVE_MATCON { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    05 W-CHAVE-CRITICA               PIC X(03)    VALUE 'NAO'.*/
            public StringBasis W_CHAVE_CRITICA { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    05 W-DATA-CORRENTE.*/
            public SI0234B_W_DATA_CORRENTE W_DATA_CORRENTE { get; set; } = new SI0234B_W_DATA_CORRENTE();
            public class SI0234B_W_DATA_CORRENTE : VarBasis
            {
                /*"       15 W-DATA-CORRENTE-ANO        PIC 9(04)       VALUE ZEROS*/
                public IntBasis W_DATA_CORRENTE_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"       15 W-DATA-CORRENTE-FILLER-1   PIC X(01)       VALUE ZEROS*/
                public StringBasis W_DATA_CORRENTE_FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"       15 W-DATA-CORRENTE-MES        PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_DATA_CORRENTE_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       15 W-DATA-CORRENTE-FILLER-2   PIC X(01)       VALUE ZEROS*/
                public StringBasis W_DATA_CORRENTE_FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"       15 W-DATA-CORRENTE-DIA        PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_DATA_CORRENTE_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    05 W-HORA-CORRENTE.*/
            }
            public SI0234B_W_HORA_CORRENTE W_HORA_CORRENTE { get; set; } = new SI0234B_W_HORA_CORRENTE();
            public class SI0234B_W_HORA_CORRENTE : VarBasis
            {
                /*"       15 W-HORA-CORRENTE-ANO        PIC 9(04)       VALUE ZEROS*/
                public IntBasis W_HORA_CORRENTE_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"       15 W-HORA-CORRENTE-FILLER-1   PIC X(01)       VALUE ZEROS*/
                public StringBasis W_HORA_CORRENTE_FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"       15 W-HORA-CORRENTE-MES        PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_HORA_CORRENTE_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       15 W-HORA-CORRENTE-FILLER-2   PIC X(01)       VALUE ZEROS*/
                public StringBasis W_HORA_CORRENTE_FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"       15 W-HORA-CORRENTE-DIA        PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_HORA_CORRENTE_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    05 W-HORA-HH-MM-SS.*/
            }
            public SI0234B_W_HORA_HH_MM_SS W_HORA_HH_MM_SS { get; set; } = new SI0234B_W_HORA_HH_MM_SS();
            public class SI0234B_W_HORA_HH_MM_SS : VarBasis
            {
                /*"       15 W-HORA-HH-MM-SS-HH         PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_HORA_HH_MM_SS_HH { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       15 FILLER                     PIC X(01)       VALUE '.'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @".");
                /*"       15 W-HORA-HH-MM-SS-MM         PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_HORA_HH_MM_SS_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       15 FILLER                     PIC X(01)       VALUE '.'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @".");
                /*"       15 W-HORA-HH-MM-SS-SS         PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_HORA_HH_MM_SS_SS { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    05 W-HORA-HHMM.*/
            }
            public SI0234B_W_HORA_HHMM W_HORA_HHMM { get; set; } = new SI0234B_W_HORA_HHMM();
            public class SI0234B_W_HORA_HHMM : VarBasis
            {
                /*"       15 W-HORA-HHMM-HH             PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_HORA_HHMM_HH { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       15 W-HORA-HHMM-MM             PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_HORA_HHMM_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    05 W-DATA-AAAAMMDD.*/
            }
            public SI0234B_W_DATA_AAAAMMDD W_DATA_AAAAMMDD { get; set; } = new SI0234B_W_DATA_AAAAMMDD();
            public class SI0234B_W_DATA_AAAAMMDD : VarBasis
            {
                /*"       10 W-DATA-AAAAMMDD-AAAA       PIC 9(04)       VALUE ZEROS*/
                public IntBasis W_DATA_AAAAMMDD_AAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"       10 W-DATA-AAAAMMDD-MM         PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_DATA_AAAAMMDD_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       10 W-DATA-AAAAMMDD-DD         PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_DATA_AAAAMMDD_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    05 W-DATA-DD-MM-AAAA.*/
            }
            public SI0234B_W_DATA_DD_MM_AAAA W_DATA_DD_MM_AAAA { get; set; } = new SI0234B_W_DATA_DD_MM_AAAA();
            public class SI0234B_W_DATA_DD_MM_AAAA : VarBasis
            {
                /*"       10 W-DATA-DD-MM-AAAA-DD       PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_DATA_DD_MM_AAAA_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       10 W-DATA-DD-MM-AAAA-DD-F1    PIC X(01)       VALUE '/'.*/
                public StringBasis W_DATA_DD_MM_AAAA_DD_F1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"       10 W-DATA-DD-MM-AAAA-MM       PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_DATA_DD_MM_AAAA_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       10 W-DATA-DD-MM-AAAA-DD-F2    PIC X(01)       VALUE '/'.*/
                public StringBasis W_DATA_DD_MM_AAAA_DD_F2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"       10 W-DATA-DD-MM-AAAA-AAAA     PIC 9(04)       VALUE ZEROS*/
                public IntBasis W_DATA_DD_MM_AAAA_AAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"    05 W-DATA-AAAA-MM-DD.*/
            }
            public SI0234B_W_DATA_AAAA_MM_DD W_DATA_AAAA_MM_DD { get; set; } = new SI0234B_W_DATA_AAAA_MM_DD();
            public class SI0234B_W_DATA_AAAA_MM_DD : VarBasis
            {
                /*"       10 W-DATA-AAAA-MM-DD-AAAA     PIC 9(04)       VALUE ZEROS*/
                public IntBasis W_DATA_AAAA_MM_DD_AAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"       10 FILLER                     PIC X(01)       VALUE '-'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       10 W-DATA-AAAA-MM-DD-MM       PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_DATA_AAAA_MM_DD_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       10 FILLER                     PIC X(01)       VALUE '-'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       10 W-DATA-AAAA-MM-DD-DD       PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_DATA_AAAA_MM_DD_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    05 LC01.*/
            }
            public SI0234B_LC01 LC01 { get; set; } = new SI0234B_LC01();
            public class SI0234B_LC01 : VarBasis
            {
                /*"       10 FILLER                     PIC X(80) VALUE        'SI0234B - RELATORIO DE PROCESSAMENTO DE 2 VIA RECIBO'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"SI0234B - RELATORIO DE PROCESSAMENTO DE 2 VIA RECIBO");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    05 LC02.*/
            }
            public SI0234B_LC02 LC02 { get; set; } = new SI0234B_LC02();
            public class SI0234B_LC02 : VarBasis
            {
                /*"       10 FILLER                     PIC X(19)  VALUE          'DATA SISTEMA (SI): '.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "19", "X(19)"), @"DATA SISTEMA (SI): ");
                /*"       10 LC02-DATA-SISTEMA          PIC X(10)   VALUE SPACES.*/
                public StringBasis LC02_DATA_SISTEMA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    05 LC03.*/
            }
            public SI0234B_LC03 LC03 { get; set; } = new SI0234B_LC03();
            public class SI0234B_LC03 : VarBasis
            {
                /*"       10 FILLER                     PIC X(13) VALUE         'SINISTRO     '.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"SINISTRO     ");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(16) VALUE         'MENSAGEM CRITICA'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"MENSAGEM CRITICA");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    05 LD01.*/
            }
            public SI0234B_LD01 LD01 { get; set; } = new SI0234B_LD01();
            public class SI0234B_LD01 : VarBasis
            {
                /*"       10 LD01-SINISTRO              PIC 9(13) VALUE  ZEROS.*/
                public IntBasis LD01_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-MENSAGEM              PIC X(80) VALUE  ZEROS.*/
                public StringBasis LD01_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    05 WABEND.*/
            }
            public SI0234B_WABEND WABEND { get; set; } = new SI0234B_WABEND();
            public class SI0234B_WABEND : VarBasis
            {
                /*"       07 WABEND1.*/
                public SI0234B_WABEND1 WABEND1 { get; set; } = new SI0234B_WABEND1();
                public class SI0234B_WABEND1 : VarBasis
                {
                    /*"       10 FILLER         PIC  X(008)      VALUE          'SI0234B '.*/
                    public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"SI0234B ");
                    /*"       07 WABEND2.*/
                    public SI0234B_WABEND2 WABEND2 { get; set; } = new SI0234B_WABEND2();
                    public class SI0234B_WABEND2 : VarBasis
                    {
                        /*"       10 FILLER         PIC  X(025)      VALUE          '*** ERRO EXEC SQL NUMERO '.*/
                        public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"*** ERRO EXEC SQL NUMERO ");
                        /*"       10 WNR-EXEC-SQL   PIC  X(004)      VALUE   '0000'.*/
                        public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                        /*"       07 WABEND3.*/
                        public SI0234B_WABEND3 WABEND3 { get; set; } = new SI0234B_WABEND3();
                        public class SI0234B_WABEND3 : VarBasis
                        {
                            /*"       10 FILLER         PIC  X(013)      VALUE          ' *** SQLCODE '.*/
                            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                            /*"       10 WSQLCODE       PIC  ZZZZZ999-   VALUE    ZEROS.*/
                            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                            /*"       10 WSQLERRMC      PIC  X(40)      VALUE    SPACES.*/
                            public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                            /*"       10 WSQLCAID     PIC X(8).*/
                            public StringBasis WSQLCAID { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
                            /*"       10 WSQLCABC     PIC S9(9) COMP-4.*/
                            public IntBasis WSQLCABC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
                            /*"       10 WSQLERRP     PIC X(8).*/
                            public StringBasis WSQLERRP { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
                            /*"       10 WSQLWARN.*/
                            public SI0234B_WSQLWARN WSQLWARN { get; set; } = new SI0234B_WSQLWARN();
                            public class SI0234B_WSQLWARN : VarBasis
                            {
                                /*"          15 WSQLWARN0 PIC X.*/
                                public StringBasis WSQLWARN0 { get; set; } = new StringBasis(new PIC("X", "1", "X."), @"");
                                /*"          15 WSQLWARN1 PIC X.*/
                                public StringBasis WSQLWARN1 { get; set; } = new StringBasis(new PIC("X", "1", "X."), @"");
                                /*"          15 WSQLWARN2 PIC X.*/
                                public StringBasis WSQLWARN2 { get; set; } = new StringBasis(new PIC("X", "1", "X."), @"");
                                /*"          15 WSQLWARN3 PIC X.*/
                                public StringBasis WSQLWARN3 { get; set; } = new StringBasis(new PIC("X", "1", "X."), @"");
                                /*"          15 WSQLWARN4 PIC X.*/
                                public StringBasis WSQLWARN4 { get; set; } = new StringBasis(new PIC("X", "1", "X."), @"");
                                /*"          15 WSQLWARN5 PIC X.*/
                                public StringBasis WSQLWARN5 { get; set; } = new StringBasis(new PIC("X", "1", "X."), @"");
                            }
                        }
                    }
                }
            }
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.SINIHAB1 SINIHAB1 { get; set; } = new Dclgens.SINIHAB1();
        public Dclgens.SINCREIN SINCREIN { get; set; } = new Dclgens.SINCREIN();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string REG_ENT_FILE_NAME_P, string REG_RET_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                REG_ENT.SetFile(REG_ENT_FILE_NAME_P);
                REG_RET.SetFile(REG_RET_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM R000-INICIO */

                R000_INICIO();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R000-INICIO */
        private void R000_INICIO(bool isPerform = false)
        {
            /*" -225- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -226- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -227- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -230- OPEN INPUT REG-ENT. */
            REG_ENT.Open(REGISTRO_ENTRADA);

            /*" -232- OPEN OUTPUT REG-RET. */
            REG_RET.Open(REGISTRO_ENTRADA_RETORNO);

            /*" -234- PERFORM R010-LE-SISTEMAS THRU R010-EXIT. */

            R010_LE_SISTEMAS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_EXIT*/


            /*" -235- WRITE REGISTRO-ENTRADA-RETORNO FROM LC01. */
            _.Move(AREA_DE_WORK.LC01.GetMoveValues(), REGISTRO_ENTRADA_RETORNO);

            REG_RET.Write(REGISTRO_ENTRADA_RETORNO.GetMoveValues().ToString());

            /*" -236- WRITE REGISTRO-ENTRADA-RETORNO FROM LC02. */
            _.Move(AREA_DE_WORK.LC02.GetMoveValues(), REGISTRO_ENTRADA_RETORNO);

            REG_RET.Write(REGISTRO_ENTRADA_RETORNO.GetMoveValues().ToString());

            /*" -238- WRITE REGISTRO-ENTRADA-RETORNO FROM LC03. */
            _.Move(AREA_DE_WORK.LC03.GetMoveValues(), REGISTRO_ENTRADA_RETORNO);

            REG_RET.Write(REGISTRO_ENTRADA_RETORNO.GetMoveValues().ToString());

            /*" -239- MOVE 'NAO' TO WFIM-REGISTRO-ENTRADA. */
            _.Move("NAO", AREA_DE_WORK.WFIM_REGISTRO_ENTRADA);

            /*" -241- PERFORM R020-LE-ARQ-ENT THRU R020-EXIT. */

            R020_LE_ARQ_ENT(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R020_EXIT*/


            /*" -242- IF WFIM-REGISTRO-ENTRADA EQUAL 'SIM' */

            if (AREA_DE_WORK.WFIM_REGISTRO_ENTRADA == "SIM")
            {

                /*" -243- DISPLAY '***********************************************' */
                _.Display($"***********************************************");

                /*" -244- DISPLAY '*                                             *' */
                _.Display($"*                                             *");

                /*" -245- DISPLAY '* SI0234B - SEM SOLICITACAO NA DATA DE HOJE   *' */
                _.Display($"* SI0234B - SEM SOLICITACAO NA DATA DE HOJE   *");

                /*" -246- DISPLAY '*                                             *' */
                _.Display($"*                                             *");

                /*" -247- DISPLAY '***********************************************' */
                _.Display($"***********************************************");

                /*" -249- DISPLAY ' ' . */
                _.Display($" ");
            }


            /*" -252- PERFORM R100-PROCESSA-SINISTRO THRU R100-EXIT UNTIL WFIM-REGISTRO-ENTRADA EQUAL 'SIM' . */

            while (!(AREA_DE_WORK.WFIM_REGISTRO_ENTRADA == "SIM"))
            {

                R100_PROCESSA_SINISTRO(true);

                R100_GRAVA_SAIDA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/

            }

            /*" -254- CLOSE REG-ENT REG-RET. */
            REG_ENT.Close();
            REG_RET.Close();

            /*" -255- DISPLAY ' ' . */
            _.Display($" ");

            /*" -256- DISPLAY '*************************************' . */
            _.Display($"*************************************");

            /*" -257- DISPLAY '*                                   *' . */
            _.Display($"*                                   *");

            /*" -258- DISPLAY '*           SI0234B                 *' . */
            _.Display($"*           SI0234B                 *");

            /*" -259- DISPLAY '*                                   *' . */
            _.Display($"*                                   *");

            /*" -260- DISPLAY '*  TERMINO NORMAL DE PROCESSAMENTO  *' . */
            _.Display($"*  TERMINO NORMAL DE PROCESSAMENTO  *");

            /*" -261- DISPLAY '*                                   *' . */
            _.Display($"*                                   *");

            /*" -263- DISPLAY '*************************************' . */
            _.Display($"*************************************");

            /*" -263- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -266- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -266- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R000_FIM*/

        [StopWatch]
        /*" R010-LE-SISTEMAS */
        private void R010_LE_SISTEMAS(bool isPerform = false)
        {
            /*" -274- MOVE '005' TO WNR-EXEC-SQL. */
            _.Move("005", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -279- PERFORM R010_LE_SISTEMAS_DB_SELECT_1 */

            R010_LE_SISTEMAS_DB_SELECT_1();

            /*" -282- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -283- DISPLAY 'SI0234B - SISTEMA SI NAO CADASTRADO' */
                _.Display($"SI0234B - SISTEMA SI NAO CADASTRADO");

                /*" -285- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -286- DISPLAY ' ' . */
            _.Display($" ");

            /*" -287- DISPLAY 'DATA DO SISTEMA DE SINISTRO (SI)' . */
            _.Display($"DATA DO SISTEMA DE SINISTRO (SI)");

            /*" -292- DISPLAY SISTEMAS-DATA-MOV-ABERTO(9:2) ' ' SISTEMAS-DATA-MOV-ABERTO(8:1) ' ' SISTEMAS-DATA-MOV-ABERTO(6:2) ' ' SISTEMAS-DATA-MOV-ABERTO(5:1) ' ' SISTEMAS-DATA-MOV-ABERTO(1:4). */

            $"{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2)} {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(8, 1)} {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2)} {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(5, 1)} {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4)}"
            .Display();

            /*" -294- DISPLAY ' ' . */
            _.Display($" ");

            /*" -295- MOVE SISTEMAS-DATA-MOV-ABERTO(9:2) TO W-DATA-DD-MM-AAAA-DD */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2), AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_DD);

            /*" -296- MOVE SISTEMAS-DATA-MOV-ABERTO(8:1) TO W-DATA-DD-MM-AAAA-DD-F1 */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(8, 1), AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_DD_F1);

            /*" -297- MOVE SISTEMAS-DATA-MOV-ABERTO(6:2) TO W-DATA-DD-MM-AAAA-MM */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2), AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_MM);

            /*" -298- MOVE SISTEMAS-DATA-MOV-ABERTO(5:1) TO W-DATA-DD-MM-AAAA-DD-F2 */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(5, 1), AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_DD_F2);

            /*" -300- MOVE SISTEMAS-DATA-MOV-ABERTO(1:4) TO W-DATA-DD-MM-AAAA-AAAA */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4), AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_AAAA);

            /*" -300- MOVE W-DATA-DD-MM-AAAA TO LC02-DATA-SISTEMA. */
            _.Move(AREA_DE_WORK.W_DATA_DD_MM_AAAA, AREA_DE_WORK.LC02.LC02_DATA_SISTEMA);

        }

        [StopWatch]
        /*" R010-LE-SISTEMAS-DB-SELECT-1 */
        public void R010_LE_SISTEMAS_DB_SELECT_1()
        {
            /*" -279- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' END-EXEC. */

            var r010_LE_SISTEMAS_DB_SELECT_1_Query1 = new R010_LE_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R010_LE_SISTEMAS_DB_SELECT_1_Query1.Execute(r010_LE_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_EXIT*/

        [StopWatch]
        /*" R020-LE-ARQ-ENT */
        private void R020_LE_ARQ_ENT(bool isPerform = false)
        {
            /*" -307- READ REG-ENT AT END */
            try
            {
                REG_ENT.Read(() =>
                {

                    /*" -309- MOVE 'SIM' TO WFIM-REGISTRO-ENTRADA */
                    _.Move("SIM", AREA_DE_WORK.WFIM_REGISTRO_ENTRADA);

                    /*" -310- MOVE 9999999999999 TO LD01-SINISTRO */
                    _.Move(9999999999999, AREA_DE_WORK.LD01.LD01_SINISTRO);

                    /*" -311- MOVE 'FIM DE PROCESSAMENTO' TO LD01-MENSAGEM */
                    _.Move("FIM DE PROCESSAMENTO", AREA_DE_WORK.LD01.LD01_MENSAGEM);

                    /*" -312- WRITE REGISTRO-ENTRADA-RETORNO FROM LD01 */
                    _.Move(AREA_DE_WORK.LD01.GetMoveValues(), REGISTRO_ENTRADA_RETORNO);

                    REG_RET.Write(REGISTRO_ENTRADA_RETORNO.GetMoveValues().ToString());

                    /*" -314- GO TO R020-EXIT. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R020_EXIT*/ //GOTO
                    return;
                });

                _.Move(REG_ENT.Value, REGISTRO_ENTRADA);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -316- MOVE REGISTRO-ENTRADA TO W-REGISTRO-ENTRADA. */
            _.Move(REG_ENT?.Value, W_REGISTRO_ENTRADA);

            /*" -318- IF TIPO-REGISTRO-ALFA EQUAL SPACES OR '99' AND WFIM-REGISTRO-ENTRADA EQUAL 'NAO' */

            if (W_REGISTRO_ENTRADA.TIPO_REGISTRO_ALFA.In(string.Empty, "99") && AREA_DE_WORK.WFIM_REGISTRO_ENTRADA == "NAO")
            {

                /*" -318- GO TO R020-LE-ARQ-ENT. */
                new Task(() => R020_LE_ARQ_ENT()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R020_EXIT*/

        [StopWatch]
        /*" R100-PROCESSA-SINISTRO */
        private void R100_PROCESSA_SINISTRO(bool isPerform = false)
        {
            /*" -326- MOVE NUM-APOL-SINISTRO TO LD01-SINISTRO */
            _.Move(W_REGISTRO_ENTRADA.NUM_APOL_SINISTRO, AREA_DE_WORK.LD01.LD01_SINISTRO);

            /*" -327- IF NUM-APOL-SINISTRO NOT NUMERIC */

            if (!W_REGISTRO_ENTRADA.NUM_APOL_SINISTRO.IsNumeric())
            {

                /*" -329- MOVE 'NUMERO DO SINISTRO NAO NUMERICO' TO LD01-MENSAGEM */
                _.Move("NUMERO DO SINISTRO NAO NUMERICO", AREA_DE_WORK.LD01.LD01_MENSAGEM);

                /*" -331- GO TO R100-GRAVA-SAIDA. */

                R100_GRAVA_SAIDA(); //GOTO
                return;
            }


            /*" -332- INITIALIZE DCLRELATORIOS. */
            _.Initialize(
                RELATORI.DCLRELATORIOS
            );

            /*" -333- MOVE NUM-APOL-SINISTRO TO RELATORI-NUM-SINISTRO */
            _.Move(W_REGISTRO_ENTRADA.NUM_APOL_SINISTRO, RELATORI.DCLRELATORIOS.RELATORI_NUM_SINISTRO);

            /*" -334- MOVE 'SI' TO RELATORI-IDE-SISTEMA. */
            _.Move("SI", RELATORI.DCLRELATORIOS.RELATORI_IDE_SISTEMA);

            /*" -335- MOVE 'SI0234B' TO RELATORI-COD-USUARIO */
            _.Move("SI0234B", RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO);

            /*" -336- MOVE SISTEMAS-DATA-MOV-ABERTO TO RELATORI-DATA-SOLICITACAO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO);

            /*" -339- MOVE '1999-12-31' TO RELATORI-PERI-INICIAL RELATORI-PERI-FINAL RELATORI-DATA-REFERENCIA. */
            _.Move("1999-12-31", RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL, RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL, RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA);

            /*" -341- MOVE '0' TO RELATORI-SIT-REGISTRO. */
            _.Move("0", RELATORI.DCLRELATORIOS.RELATORI_SIT_REGISTRO);

            /*" -342- MOVE 'NAO' TO W-CHAVE-CRITICA */
            _.Move("NAO", AREA_DE_WORK.W_CHAVE_CRITICA);

            /*" -343- PERFORM R120-VALIDA-INDENIZACAO THRU R120-EXIT. */

            R120_VALIDA_INDENIZACAO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


            /*" -344- IF W-CHAVE-CRITICA EQUAL 'SIM' */

            if (AREA_DE_WORK.W_CHAVE_CRITICA == "SIM")
            {

                /*" -346- GO TO R100-GRAVA-SAIDA. */

                R100_GRAVA_SAIDA(); //GOTO
                return;
            }


            /*" -348- MOVE 'NAO' TO W-CHAVE-CRED-COMERCIAL W-CHAVE-MATCON. */
            _.Move("NAO", AREA_DE_WORK.W_CHAVE_CRED_COMERCIAL, AREA_DE_WORK.W_CHAVE_MATCON);

            /*" -350- PERFORM R200-LE-CRED-COMERCIAL THRU R200-EXIT. */

            R200_LE_CRED_COMERCIAL(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R200_EXIT*/


            /*" -351- IF W-CHAVE-CRED-COMERCIAL EQUAL 'SIM' */

            if (AREA_DE_WORK.W_CHAVE_CRED_COMERCIAL == "SIM")
            {

                /*" -353- MOVE 'SI0062B' TO RELATORI-COD-RELATORIO . */
                _.Move("SI0062B", RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO);
            }


            /*" -355- PERFORM R210-LE-MATCON THRU R210-EXIT. */

            R210_LE_MATCON(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R210_EXIT*/


            /*" -356- IF W-CHAVE-MATCON EQUAL 'SIM' */

            if (AREA_DE_WORK.W_CHAVE_MATCON == "SIM")
            {

                /*" -358- MOVE 'SI0061B' TO RELATORI-COD-RELATORIO . */
                _.Move("SI0061B", RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO);
            }


            /*" -360- IF W-CHAVE-CRED-COMERCIAL EQUAL 'SIM' OR W-CHAVE-MATCON EQUAL 'SIM' */

            if (AREA_DE_WORK.W_CHAVE_CRED_COMERCIAL == "SIM" || AREA_DE_WORK.W_CHAVE_MATCON == "SIM")
            {

                /*" -361- PERFORM R300-INSERT-RELATORIOS THRU R300-EXIT */

                R300_INSERT_RELATORIOS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R300_EXIT*/


                /*" -363- MOVE 'SOLICITACAO EFETUADA COM SUCESSO' TO LD01-MENSAGEM */
                _.Move("SOLICITACAO EFETUADA COM SUCESSO", AREA_DE_WORK.LD01.LD01_MENSAGEM);

                /*" -364- ELSE */
            }
            else
            {


                /*" -366- MOVE 'SINISTRO NAO EH CREDITO/NAO ENCONTRADO. SOLICITACAO NAO EFETUADA' TO LD01-MENSAGEM. */
                _.Move("SINISTRO NAO EH CREDITO/NAO ENCONTRADO. SOLICITACAO NAO EFETUADA", AREA_DE_WORK.LD01.LD01_MENSAGEM);
            }


        }

        [StopWatch]
        /*" R100-GRAVA-SAIDA */
        private void R100_GRAVA_SAIDA(bool isPerform = false)
        {
            /*" -372- PERFORM R110-GRAVA-SAIDA THRU R110-EXIT . */

            R110_GRAVA_SAIDA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R110_EXIT*/


            /*" -372- PERFORM R020-LE-ARQ-ENT THRU R020-EXIT. */

            R020_LE_ARQ_ENT(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R020_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/

        [StopWatch]
        /*" R110-GRAVA-SAIDA */
        private void R110_GRAVA_SAIDA(bool isPerform = false)
        {
            /*" -378- WRITE REGISTRO-ENTRADA-RETORNO FROM LD01. */
            _.Move(AREA_DE_WORK.LD01.GetMoveValues(), REGISTRO_ENTRADA_RETORNO);

            REG_RET.Write(REGISTRO_ENTRADA_RETORNO.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R110_EXIT*/

        [StopWatch]
        /*" R120-VALIDA-INDENIZACAO */
        private void R120_VALIDA_INDENIZACAO(bool isPerform = false)
        {
            /*" -386- MOVE NUM-APOL-SINISTRO TO SINISMES-NUM-APOL-SINISTRO. */
            _.Move(W_REGISTRO_ENTRADA.NUM_APOL_SINISTRO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO);

            /*" -388- MOVE '059' TO WNR-EXEC-SQL. */
            _.Move("059", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -393- PERFORM R120_VALIDA_INDENIZACAO_DB_SELECT_1 */

            R120_VALIDA_INDENIZACAO_DB_SELECT_1();

            /*" -396- DISPLAY 'MESTRE SQLCODE = ' SQLCODE */
            _.Display($"MESTRE SQLCODE = {DB.SQLCODE}");

            /*" -397- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -398- DISPLAY 'ERRO SELECT SINISTRO_MESTRE.....................' */
                _.Display($"ERRO SELECT SINISTRO_MESTRE.....................");

                /*" -400- MOVE 'ERRO SELECT SINISTRO_MESTRE' TO LD01-MENSAGEM */
                _.Move("ERRO SELECT SINISTRO_MESTRE", AREA_DE_WORK.LD01.LD01_MENSAGEM);

                /*" -402- GO TO R120-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/ //GOTO
                return;
            }


            /*" -403- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -404- MOVE 'SIM' TO W-CHAVE-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                /*" -406- MOVE 'SINISTRO NAO CADASTRADO' TO LD01-MENSAGEM */
                _.Move("SINISTRO NAO CADASTRADO", AREA_DE_WORK.LD01.LD01_MENSAGEM);

                /*" -408- GO TO R120-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/ //GOTO
                return;
            }


            /*" -409- MOVE NUM-APOL-SINISTRO TO SINISHIS-NUM-APOL-SINISTRO. */
            _.Move(W_REGISTRO_ENTRADA.NUM_APOL_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);

            /*" -411- MOVE 0 TO HOST-COUNT. */
            _.Move(0, HOST_COUNT);

            /*" -418- PERFORM R120_VALIDA_INDENIZACAO_DB_SELECT_2 */

            R120_VALIDA_INDENIZACAO_DB_SELECT_2();

            /*" -421- DISPLAY 'HISTSINI SQLCODE = ' SQLCODE */
            _.Display($"HISTSINI SQLCODE = {DB.SQLCODE}");

            /*" -422- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -423- DISPLAY 'ERRO SELECT SINISTRO_HISTORICO(1)...............' */
                _.Display($"ERRO SELECT SINISTRO_HISTORICO(1)...............");

                /*" -425- MOVE 'ERRO SELECT SINISTRO_HISTORICO(1) ' TO LD01-MENSAGEM */
                _.Move("ERRO SELECT SINISTRO_HISTORICO(1) ", AREA_DE_WORK.LD01.LD01_MENSAGEM);

                /*" -427- GO TO R120-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/ //GOTO
                return;
            }


            /*" -428- IF HOST-COUNT EQUAL 0 */

            if (HOST_COUNT == 0)
            {

                /*" -429- MOVE 'SIM' TO W-CHAVE-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                /*" -431- MOVE 'SINISTRO SEM INDENIZACAO - SEM RECIBO PARA EMISSAO' TO LD01-MENSAGEM */
                _.Move("SINISTRO SEM INDENIZACAO - SEM RECIBO PARA EMISSAO", AREA_DE_WORK.LD01.LD01_MENSAGEM);

                /*" -431- GO TO R120-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/ //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R120-VALIDA-INDENIZACAO-DB-SELECT-1 */
        public void R120_VALIDA_INDENIZACAO_DB_SELECT_1()
        {
            /*" -393- EXEC SQL SELECT NUM_PROTOCOLO_SINI INTO :SINISMES-NUM-PROTOCOLO-SINI FROM SEGUROS.SINISTRO_MESTRE WHERE NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO END-EXEC. */

            var r120_VALIDA_INDENIZACAO_DB_SELECT_1_Query1 = new R120_VALIDA_INDENIZACAO_DB_SELECT_1_Query1()
            {
                SINISMES_NUM_APOL_SINISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R120_VALIDA_INDENIZACAO_DB_SELECT_1_Query1.Execute(r120_VALIDA_INDENIZACAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISMES_NUM_PROTOCOLO_SINI, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_PROTOCOLO_SINI);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/

        [StopWatch]
        /*" R120-VALIDA-INDENIZACAO-DB-SELECT-2 */
        public void R120_VALIDA_INDENIZACAO_DB_SELECT_2()
        {
            /*" -418- EXEC SQL SELECT COUNT(*) INTO :HOST-COUNT FROM SEGUROS.SINISTRO_HISTORICO WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND COD_OPERACAO IN (1001,1002,1003,1004) AND SIT_REGISTRO = '1' END-EXEC. */

            var r120_VALIDA_INDENIZACAO_DB_SELECT_2_Query1 = new R120_VALIDA_INDENIZACAO_DB_SELECT_2_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R120_VALIDA_INDENIZACAO_DB_SELECT_2_Query1.Execute(r120_VALIDA_INDENIZACAO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_COUNT, HOST_COUNT);
            }


        }

        [StopWatch]
        /*" R200-LE-CRED-COMERCIAL */
        private void R200_LE_CRED_COMERCIAL(bool isPerform = false)
        {
            /*" -439- MOVE NUM-APOL-SINISTRO TO SINCREIN-NUM-APOL-SINISTRO. */
            _.Move(W_REGISTRO_ENTRADA.NUM_APOL_SINISTRO, SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_NUM_APOL_SINISTRO);

            /*" -441- MOVE '059' TO WNR-EXEC-SQL. */
            _.Move("059", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -456- PERFORM R200_LE_CRED_COMERCIAL_DB_SELECT_1 */

            R200_LE_CRED_COMERCIAL_DB_SELECT_1();

            /*" -459- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -460- DISPLAY 'ERRO SELECT SINISTRO_CRED_INT...................' */
                _.Display($"ERRO SELECT SINISTRO_CRED_INT...................");

                /*" -463- MOVE 'ERRO SELECT SINISTRO_CRED_INT' TO LD01-MENSAGEM. */
                _.Move("ERRO SELECT SINISTRO_CRED_INT", AREA_DE_WORK.LD01.LD01_MENSAGEM);
            }


            /*" -464- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -464- MOVE 'SIM' TO W-CHAVE-CRED-COMERCIAL. */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRED_COMERCIAL);
            }


        }

        [StopWatch]
        /*" R200-LE-CRED-COMERCIAL-DB-SELECT-1 */
        public void R200_LE_CRED_COMERCIAL_DB_SELECT_1()
        {
            /*" -456- EXEC SQL SELECT COD_SUREG, COD_AGENCIA, COD_OPERACAO, NUM_CONTRATO, CONTRATO_DIGITO, NUM_APOL_SINISTRO INTO :SINCREIN-COD-SUREG, :SINCREIN-COD-AGENCIA, :SINCREIN-COD-OPERACAO, :SINCREIN-NUM-CONTRATO, :SINCREIN-CONTRATO-DIGITO, :SINCREIN-NUM-APOL-SINISTRO FROM SEGUROS.SINISTRO_CRED_INT WHERE NUM_APOL_SINISTRO = :SINCREIN-NUM-APOL-SINISTRO END-EXEC. */

            var r200_LE_CRED_COMERCIAL_DB_SELECT_1_Query1 = new R200_LE_CRED_COMERCIAL_DB_SELECT_1_Query1()
            {
                SINCREIN_NUM_APOL_SINISTRO = SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R200_LE_CRED_COMERCIAL_DB_SELECT_1_Query1.Execute(r200_LE_CRED_COMERCIAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINCREIN_COD_SUREG, SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_SUREG);
                _.Move(executed_1.SINCREIN_COD_AGENCIA, SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_AGENCIA);
                _.Move(executed_1.SINCREIN_COD_OPERACAO, SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO);
                _.Move(executed_1.SINCREIN_NUM_CONTRATO, SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_NUM_CONTRATO);
                _.Move(executed_1.SINCREIN_CONTRATO_DIGITO, SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_CONTRATO_DIGITO);
                _.Move(executed_1.SINCREIN_NUM_APOL_SINISTRO, SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_NUM_APOL_SINISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R200_EXIT*/

        [StopWatch]
        /*" R210-LE-MATCON */
        private void R210_LE_MATCON(bool isPerform = false)
        {
            /*" -472- MOVE NUM-APOL-SINISTRO TO SINIHAB1-NUM-APOL-SINISTRO */
            _.Move(W_REGISTRO_ENTRADA.NUM_APOL_SINISTRO, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_NUM_APOL_SINISTRO);

            /*" -474- MOVE '060' TO WNR-EXEC-SQL. */
            _.Move("060", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -490- PERFORM R210_LE_MATCON_DB_SELECT_1 */

            R210_LE_MATCON_DB_SELECT_1();

            /*" -493- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -494- DISPLAY 'ERRO SELECT SINISTRO_HABIT01....................' */
                _.Display($"ERRO SELECT SINISTRO_HABIT01....................");

                /*" -497- MOVE 'ERRO SELECT SINISTRO_HABIT01' TO LD01-MENSAGEM. */
                _.Move("ERRO SELECT SINISTRO_HABIT01", AREA_DE_WORK.LD01.LD01_MENSAGEM);
            }


            /*" -498- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -498- MOVE 'SIM' TO W-CHAVE-MATCON. */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_MATCON);
            }


        }

        [StopWatch]
        /*" R210-LE-MATCON-DB-SELECT-1 */
        public void R210_LE_MATCON_DB_SELECT_1()
        {
            /*" -490- EXEC SQL SELECT OPERACAO, PONTO_VENDA, NUM_CONTRATO INTO :SINIHAB1-OPERACAO, :SINIHAB1-PONTO-VENDA, :SINIHAB1-NUM-CONTRATO FROM SEGUROS.SINISTRO_HABIT01 WHERE NUM_APOL_SINISTRO = :SINIHAB1-NUM-APOL-SINISTRO AND (NUM_APOL_SINISTRO BETWEEN 0104800000000 AND 0104899999999 OR NUM_APOL_SINISTRO BETWEEN 0106000000000 AND 0106099999999 OR NUM_APOL_SINISTRO BETWEEN 0107000000000 AND 0107099999999) END-EXEC. */

            var r210_LE_MATCON_DB_SELECT_1_Query1 = new R210_LE_MATCON_DB_SELECT_1_Query1()
            {
                SINIHAB1_NUM_APOL_SINISTRO = SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R210_LE_MATCON_DB_SELECT_1_Query1.Execute(r210_LE_MATCON_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINIHAB1_OPERACAO, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_OPERACAO);
                _.Move(executed_1.SINIHAB1_PONTO_VENDA, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_PONTO_VENDA);
                _.Move(executed_1.SINIHAB1_NUM_CONTRATO, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_NUM_CONTRATO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R210_EXIT*/

        [StopWatch]
        /*" R300-INSERT-RELATORIOS */
        private void R300_INSERT_RELATORIOS(bool isPerform = false)
        {
            /*" -506- MOVE '009' TO WNR-EXEC-SQL. */
            _.Move("009", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -587- PERFORM R300_INSERT_RELATORIOS_DB_INSERT_1 */

            R300_INSERT_RELATORIOS_DB_INSERT_1();

            /*" -590- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -591- DISPLAY 'ERRO NO INSERT RELATORIOS...................' */
                _.Display($"ERRO NO INSERT RELATORIOS...................");

                /*" -592- MOVE 'ERRO INSERT NA RELATORIOS. AVISE ANALISTA RESP' TO LD01-MENSAGEM. */
                _.Move("ERRO INSERT NA RELATORIOS. AVISE ANALISTA RESP", AREA_DE_WORK.LD01.LD01_MENSAGEM);
            }


        }

        [StopWatch]
        /*" R300-INSERT-RELATORIOS-DB-INSERT-1 */
        public void R300_INSERT_RELATORIOS_DB_INSERT_1()
        {
            /*" -587- EXEC SQL INSERT INTO SEGUROS.RELATORIOS (COD_USUARIO , DATA_SOLICITACAO , IDE_SISTEMA , COD_RELATORIO , NUM_COPIAS , QUANTIDADE , PERI_INICIAL , PERI_FINAL , DATA_REFERENCIA , MES_REFERENCIA , ANO_REFERENCIA , ORGAO_EMISSOR , COD_FONTE , COD_PRODUTOR , RAMO_EMISSOR , COD_MODALIDADE , COD_CONGENERE , NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , NUM_CERTIFICADO , NUM_TITULO , COD_SUBGRUPO , COD_OPERACAO , COD_PLANO , OCORR_HISTORICO , NUM_APOL_LIDER , ENDOS_LIDER , NUM_PARC_LIDER , NUM_SINISTRO , NUM_SINI_LIDER , NUM_ORDEM , COD_MOEDA , TIPO_CORRECAO , SIT_REGISTRO , IND_PREV_DEFINIT , IND_ANAL_RESUMO , PERI_RENOVACAO , PCT_AUMENTO , TIMESTAMP) VALUES (:RELATORI-COD-USUARIO , :RELATORI-DATA-SOLICITACAO , :RELATORI-IDE-SISTEMA , :RELATORI-COD-RELATORIO , :RELATORI-NUM-COPIAS , :RELATORI-QUANTIDADE , :RELATORI-PERI-INICIAL , :RELATORI-PERI-FINAL , :RELATORI-DATA-REFERENCIA , :RELATORI-MES-REFERENCIA , :RELATORI-ANO-REFERENCIA , :RELATORI-ORGAO-EMISSOR , :RELATORI-COD-FONTE , :RELATORI-COD-PRODUTOR , :RELATORI-RAMO-EMISSOR , :RELATORI-COD-MODALIDADE , :RELATORI-COD-CONGENERE , :RELATORI-NUM-APOLICE , :RELATORI-NUM-ENDOSSO , :RELATORI-NUM-PARCELA , :RELATORI-NUM-CERTIFICADO , :RELATORI-NUM-TITULO , :RELATORI-COD-SUBGRUPO , :RELATORI-COD-OPERACAO , :RELATORI-COD-PLANO , :RELATORI-OCORR-HISTORICO , :RELATORI-NUM-APOL-LIDER , :RELATORI-ENDOS-LIDER , :RELATORI-NUM-PARC-LIDER , :RELATORI-NUM-SINISTRO , :RELATORI-NUM-SINI-LIDER , :RELATORI-NUM-ORDEM , :RELATORI-COD-MOEDA , :RELATORI-TIPO-CORRECAO , :RELATORI-SIT-REGISTRO , :RELATORI-IND-PREV-DEFINIT , :RELATORI-IND-ANAL-RESUMO , :RELATORI-PERI-RENOVACAO , :RELATORI-PCT-AUMENTO , CURRENT TIMESTAMP) END-EXEC. */

            var r300_INSERT_RELATORIOS_DB_INSERT_1_Insert1 = new R300_INSERT_RELATORIOS_DB_INSERT_1_Insert1()
            {
                RELATORI_COD_USUARIO = RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO.ToString(),
                RELATORI_DATA_SOLICITACAO = RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO.ToString(),
                RELATORI_IDE_SISTEMA = RELATORI.DCLRELATORIOS.RELATORI_IDE_SISTEMA.ToString(),
                RELATORI_COD_RELATORIO = RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO.ToString(),
                RELATORI_NUM_COPIAS = RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS.ToString(),
                RELATORI_QUANTIDADE = RELATORI.DCLRELATORIOS.RELATORI_QUANTIDADE.ToString(),
                RELATORI_PERI_INICIAL = RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL.ToString(),
                RELATORI_PERI_FINAL = RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL.ToString(),
                RELATORI_DATA_REFERENCIA = RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA.ToString(),
                RELATORI_MES_REFERENCIA = RELATORI.DCLRELATORIOS.RELATORI_MES_REFERENCIA.ToString(),
                RELATORI_ANO_REFERENCIA = RELATORI.DCLRELATORIOS.RELATORI_ANO_REFERENCIA.ToString(),
                RELATORI_ORGAO_EMISSOR = RELATORI.DCLRELATORIOS.RELATORI_ORGAO_EMISSOR.ToString(),
                RELATORI_COD_FONTE = RELATORI.DCLRELATORIOS.RELATORI_COD_FONTE.ToString(),
                RELATORI_COD_PRODUTOR = RELATORI.DCLRELATORIOS.RELATORI_COD_PRODUTOR.ToString(),
                RELATORI_RAMO_EMISSOR = RELATORI.DCLRELATORIOS.RELATORI_RAMO_EMISSOR.ToString(),
                RELATORI_COD_MODALIDADE = RELATORI.DCLRELATORIOS.RELATORI_COD_MODALIDADE.ToString(),
                RELATORI_COD_CONGENERE = RELATORI.DCLRELATORIOS.RELATORI_COD_CONGENERE.ToString(),
                RELATORI_NUM_APOLICE = RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE.ToString(),
                RELATORI_NUM_ENDOSSO = RELATORI.DCLRELATORIOS.RELATORI_NUM_ENDOSSO.ToString(),
                RELATORI_NUM_PARCELA = RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA.ToString(),
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
                RELATORI_NUM_TITULO = RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO.ToString(),
                RELATORI_COD_SUBGRUPO = RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO.ToString(),
                RELATORI_COD_OPERACAO = RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO.ToString(),
                RELATORI_COD_PLANO = RELATORI.DCLRELATORIOS.RELATORI_COD_PLANO.ToString(),
                RELATORI_OCORR_HISTORICO = RELATORI.DCLRELATORIOS.RELATORI_OCORR_HISTORICO.ToString(),
                RELATORI_NUM_APOL_LIDER = RELATORI.DCLRELATORIOS.RELATORI_NUM_APOL_LIDER.ToString(),
                RELATORI_ENDOS_LIDER = RELATORI.DCLRELATORIOS.RELATORI_ENDOS_LIDER.ToString(),
                RELATORI_NUM_PARC_LIDER = RELATORI.DCLRELATORIOS.RELATORI_NUM_PARC_LIDER.ToString(),
                RELATORI_NUM_SINISTRO = RELATORI.DCLRELATORIOS.RELATORI_NUM_SINISTRO.ToString(),
                RELATORI_NUM_SINI_LIDER = RELATORI.DCLRELATORIOS.RELATORI_NUM_SINI_LIDER.ToString(),
                RELATORI_NUM_ORDEM = RELATORI.DCLRELATORIOS.RELATORI_NUM_ORDEM.ToString(),
                RELATORI_COD_MOEDA = RELATORI.DCLRELATORIOS.RELATORI_COD_MOEDA.ToString(),
                RELATORI_TIPO_CORRECAO = RELATORI.DCLRELATORIOS.RELATORI_TIPO_CORRECAO.ToString(),
                RELATORI_SIT_REGISTRO = RELATORI.DCLRELATORIOS.RELATORI_SIT_REGISTRO.ToString(),
                RELATORI_IND_PREV_DEFINIT = RELATORI.DCLRELATORIOS.RELATORI_IND_PREV_DEFINIT.ToString(),
                RELATORI_IND_ANAL_RESUMO = RELATORI.DCLRELATORIOS.RELATORI_IND_ANAL_RESUMO.ToString(),
                RELATORI_PERI_RENOVACAO = RELATORI.DCLRELATORIOS.RELATORI_PERI_RENOVACAO.ToString(),
                RELATORI_PCT_AUMENTO = RELATORI.DCLRELATORIOS.RELATORI_PCT_AUMENTO.ToString(),
            };

            R300_INSERT_RELATORIOS_DB_INSERT_1_Insert1.Execute(r300_INSERT_RELATORIOS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R300_EXIT*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO */
        private void R9999_00_ROT_ERRO(bool isPerform = false)
        {
            /*" -600- CLOSE REG-ENT REG-RET. */
            REG_ENT.Close();
            REG_RET.Close();

            /*" -601- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLCODE);

            /*" -602- MOVE SQLERRMC TO WSQLERRMC. */
            _.Move(DB.SQLERRMC, AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLERRMC);

            /*" -603- MOVE SQLERRMC TO WSQLERRMC. */
            _.Move(DB.SQLERRMC, AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLERRMC);

            /*" -604- MOVE SQLCAID TO WSQLCAID . */
            _.Move(DB.SQLCAID, AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLCAID);

            /*" -605- MOVE SQLCABC TO WSQLCABC . */
            _.Move(DB.SQLCABC, AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLCABC);

            /*" -606- MOVE SQLCODE TO WSQLCODE . */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLCODE);

            /*" -608- MOVE SQLERRP TO WSQLERRP . */
            _.Move(DB.SQLERRP, AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLERRP);

            /*" -609- MOVE SQLWARN TO WSQLWARN. */
            _.Move(DB.SQLWARN, AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLWARN);

            /*" -610- DISPLAY ' ' */
            _.Display($" ");

            /*" -611- DISPLAY '=====  PROGRAMA ABENDADO  =====' */
            _.Display($"=====  PROGRAMA ABENDADO  =====");

            /*" -612- DISPLAY ' ' */
            _.Display($" ");

            /*" -613- DISPLAY WABEND1. */
            _.Display(AREA_DE_WORK.WABEND.WABEND1);

            /*" -614- DISPLAY WABEND2. */
            _.Display(AREA_DE_WORK.WABEND.WABEND1.WABEND2);

            /*" -615- DISPLAY WABEND3. */
            _.Display(AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3);

            /*" -615- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -616- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -618- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -618- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_EXIT*/

        [StopWatch]
        /*" R10010199-MENSAGEM-LOCK */
        private void R10010199_MENSAGEM_LOCK(bool isPerform = false)
        {
            /*" -626- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLCODE);

            /*" -629- DISPLAY '***********************************************************' UPON CONSOLE WITH NO ADVANCING. */

            $"***********************************************************WITHNOADVANCING"
            .Display();

            /*" -632- DISPLAY '*      -------------       ----------------------         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*      -------------       ----------------------         *WITHNOADVANCING"
            .Display();

            /*" -635- DISPLAY '*      A T E N C A O       S R.   O P E R A D O R         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*      A T E N C A O       S R.   O P E R A D O R         *WITHNOADVANCING"
            .Display();

            /*" -638- DISPLAY '*      -------------       ----------------------         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*      -------------       ----------------------         *WITHNOADVANCING"
            .Display();

            /*" -641- DISPLAY '*                                                         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*                                                         *WITHNOADVANCING"
            .Display();

            /*" -644- DISPLAY '*                   PROGRAMA ABENDADO                     *' UPON CONSOLE WITH NO ADVANCING. */

            $"*                   PROGRAMA ABENDADO                     *WITHNOADVANCING"
            .Display();

            /*" -647- DISPLAY '*                 PROVAVELMENTE POR LOCK                  *' UPON CONSOLE WITH NO ADVANCING. */

            $"*                 PROVAVELMENTE POR LOCK                  *WITHNOADVANCING"
            .Display();

            /*" -650- DISPLAY '*        VERIFIQUE O LOG ANTES DE LIGAR PARA O ANALISTA   *' UPON CONSOLE WITH NO ADVANCING. */

            $"*        VERIFIQUE O LOG ANTES DE LIGAR PARA O ANALISTA   *WITHNOADVANCING"
            .Display();

            /*" -653- DISPLAY '*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *' UPON CONSOLE WITH NO ADVANCING. */

            $"*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *WITHNOADVANCING"
            .Display();

            /*" -656- DISPLAY '*                                                         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*                                                         *WITHNOADVANCING"
            .Display();

            /*" -659- DISPLAY '*  PERMANECENDO O ERRO, CONTACTAR O ANALISTA RESPONSAVEL  *' UPON CONSOLE WITH NO ADVANCING. */

            $"*  PERMANECENDO O ERRO, CONTACTAR O ANALISTA RESPONSAVEL  *WITHNOADVANCING"
            .Display();

            /*" -662- DISPLAY '*                                                         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*                                                         *WITHNOADVANCING"
            .Display();

            /*" -665- DISPLAY '*                                                         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*                                                         *WITHNOADVANCING"
            .Display();

            /*" -668- DISPLAY '*     SQLCODE DO ABEND ....... ' WSQLCODE UPON CONSOLE WITH NO ADVANCING. */

            $"*     SQLCODE DO ABEND ....... {AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLCODE}WITHNOADVANCING"
            .Display();

            /*" -671- DISPLAY '*                                                         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*                                                         *WITHNOADVANCING"
            .Display();

            /*" -677- DISPLAY '***********************************************************' UPON CONSOLE WITH NO ADVANCING. */

            $"***********************************************************WITHNOADVANCING"
            .Display();

            /*" -679- DISPLAY '***********************************************************' */
            _.Display($"***********************************************************");

            /*" -681- DISPLAY '*      -------------       ----------------------         *' */
            _.Display($"*      -------------       ----------------------         *");

            /*" -683- DISPLAY '*      A T E N C A O       S R.   O P E R A D O R         *' */
            _.Display($"*      A T E N C A O       S R.   O P E R A D O R         *");

            /*" -685- DISPLAY '*      -------------       ----------------------         *' */
            _.Display($"*      -------------       ----------------------         *");

            /*" -687- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -689- DISPLAY '*                   PROGRAMA ABENDADO                     *' */
            _.Display($"*                   PROGRAMA ABENDADO                     *");

            /*" -691- DISPLAY '*                 PROVAVELMENTE POR LOCK                  *' */
            _.Display($"*                 PROVAVELMENTE POR LOCK                  *");

            /*" -693- DISPLAY '*        VERIFIQUE O LOG ANTES DE LIGAR PARA O ANALISTA   *' */
            _.Display($"*        VERIFIQUE O LOG ANTES DE LIGAR PARA O ANALISTA   *");

            /*" -695- DISPLAY '*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *' */
            _.Display($"*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *");

            /*" -697- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -699- DISPLAY '*  PERMANECENDO O ERRO, CONTACTAR O ANALISTA RESPONSAVEL  *' */
            _.Display($"*  PERMANECENDO O ERRO, CONTACTAR O ANALISTA RESPONSAVEL  *");

            /*" -701- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -703- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -705- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -707- DISPLAY '*     SQLCODE DO ABEND ....... ' WSQLCODE */
            _.Display($"*     SQLCODE DO ABEND ....... {AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLCODE}");

            /*" -709- DISPLAY '***********************************************************' */
            _.Display($"***********************************************************");

            /*" -709- GO TO R9999-00-ROT-ERRO. */

            R9999_00_ROT_ERRO(); //GOTO
            return;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R10010199_EXIT*/
    }
}