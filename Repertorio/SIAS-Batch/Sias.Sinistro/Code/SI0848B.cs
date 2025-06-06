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
using Sias.Sinistro.DB2.SI0848B;

namespace Code
{
    public class SI0848B
    {
        public bool IsCall { get; set; }

        public SI0848B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SINISTRO                           *      */
        /*"      *   PROGRAMA ...............  SI0848B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA/PROGRAMADOR....  HEIDER COELHO                      *      */
        /*"      *   DATA CODIFICACAO .......  JUNHO 1997                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO ................. GERACAO DO ARQUIVO CONTENDO OS      *      */
        /*"      *          PAGAMENTOS EFETUADOS PARA A CARTEIRA DE CREDITO       *      */
        /*"      *          HABITACIONAL, PRODUTOS:                                      */
        /*"      *          4801 - CRED. CASA / CRED. MAQ.                               */
        /*"      *          6803 - CARTA CREDITO                                         */
        /*"      *          6804 - PCI                                                   */
        /*"      *          6805 - SFH LIVRE                                             */
        /*"      *                                                                       */
        /*"      *          SOLICITADO NO SIAS: 13 - 12 - 26                             */
        /*"      *          E INFORMADO PELO USUARIO O PERIODO DESEJADO                  */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _ARQSAIDA { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis ARQSAIDA
        {
            get
            {
                _.Move(REG_ARQSAIDA, _ARQSAIDA); VarBasis.RedefinePassValue(REG_ARQSAIDA, _ARQSAIDA, REG_ARQSAIDA); return _ARQSAIDA;
            }
        }
        /*"01  REG-ARQSAIDA.*/
        public SI0848B_REG_ARQSAIDA REG_ARQSAIDA { get; set; } = new SI0848B_REG_ARQSAIDA();
        public class SI0848B_REG_ARQSAIDA : VarBasis
        {
            /*"    05 REGISTRO-SAIDA     PIC X(202).*/
            public StringBasis REGISTRO_SAIDA { get; set; } = new StringBasis(new PIC("X", "202", "X(202)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  V0SIST-DTMOVABE                PIC  X(10).*/
        public StringBasis V0SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0ENDOSSO-FONTE                PIC S9(04) VALUE +0 COMP.*/
        public IntBasis V0ENDOSSO_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RELAT-ANO-REFERENCIA         PIC S9(04) VALUE +0 COMP.*/
        public IntBasis V0RELAT_ANO_REFERENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RELAT-MES-REFERENCIA         PIC S9(04) VALUE +0 COMP.*/
        public IntBasis V0RELAT_MES_REFERENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RELAT-PERI-INICIAL           PIC  X(10).*/
        public StringBasis V0RELAT_PERI_INICIAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0RELAT-PERI-FINAL             PIC  X(10).*/
        public StringBasis V0RELAT_PERI_FINAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0SINI-HABIT01-NUM-SINISTRO       PIC S9(13) COMP-3 VALUE +0*/
        public IntBasis V0SINI_HABIT01_NUM_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0SINI-HABIT01-COD-PRODUTO        PIC S9(04) COMP   VALUE +0*/
        public IntBasis V0SINI_HABIT01_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0SINI-HABIT01-COD-CLIENTE        PIC S9(09) COMP   VALUE +0*/
        public IntBasis V0SINI_HABIT01_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0SINI-HABIT01-NUM-APOLICE        PIC S9(13) COMP   VALUE +0*/
        public IntBasis V0SINI_HABIT01_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0SINI-HABIT01-OPERACAO           PIC S9(04) COMP   VALUE +0*/
        public IntBasis V0SINI_HABIT01_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0SINI-HABIT01-PONTO-VENDA        PIC S9(04) COMP   VALUE +0*/
        public IntBasis V0SINI_HABIT01_PONTO_VENDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0SINI-HABIT01-NUM-CONTRATO       PIC S9(09) COMP   VALUE +0*/
        public IntBasis V0SINI_HABIT01_NUM_CONTRATO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0SINI-HABIT01-SITUACAO           PIC  X(01).*/
        public StringBasis V0SINI_HABIT01_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V0SINI-HABIT01-COD-COBERTURA      PIC S9(04) COMP   VALUE +0*/
        public IntBasis V0SINI_HABIT01_COD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0SINI-HABIT01-CGCCPF             PIC S9(15) COMP-3 VALUE +0*/
        public IntBasis V0SINI_HABIT01_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77  V0SINI-HABIT01-NOME-SEGURADO      PIC  X(40).*/
        public StringBasis V0SINI_HABIT01_NOME_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77  V0MEST-COD-EMPRESA          PIC S9(09) VALUE +0 COMP.*/
        public IntBasis V0MEST_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0MEST-TIPREG               PIC  X(01).*/
        public StringBasis V0MEST_TIPREG { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V0MEST-FONTE                PIC S9(04) VALUE +0 COMP.*/
        public IntBasis V0MEST_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MEST-PROTSINI             PIC S9(09) VALUE +0 COMP.*/
        public IntBasis V0MEST_PROTSINI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0MEST-DAC                  PIC  X(01).*/
        public StringBasis V0MEST_DAC { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V0MEST-NUM-APOL-SINISTRO    PIC S9(13) VALUE +0 COMP-3.*/
        public IntBasis V0MEST_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0MEST-NUM-APOLICE          PIC S9(13) VALUE +0 COMP-3.*/
        public IntBasis V0MEST_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0MEST-NRENDOS              PIC S9(09) VALUE +0 COMP.*/
        public IntBasis V0MEST_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0MEST-CODSUBES             PIC S9(04) VALUE +0 COMP.*/
        public IntBasis V0MEST_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MEST-NRCERTIF             PIC S9(15) VALUE +0 COMP-3.*/
        public IntBasis V0MEST_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77  V0MEST-DIGCERT              PIC  X(01).*/
        public StringBasis V0MEST_DIGCERT { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V0MEST-IDTPSEGU             PIC  X(01).*/
        public StringBasis V0MEST_IDTPSEGU { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V0MEST-NREMBARQ             PIC S9(09) VALUE +0 COMP.*/
        public IntBasis V0MEST_NREMBARQ { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0MEST-REFEMBQ              PIC S9(04) VALUE +0 COMP.*/
        public IntBasis V0MEST_REFEMBQ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MEST-OCORHIST             PIC S9(04) VALUE +0 COMP.*/
        public IntBasis V0MEST_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MEST-CODLIDER             PIC S9(04) VALUE +0 COMP.*/
        public IntBasis V0MEST_CODLIDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MEST-SINLID               PIC  X(15).*/
        public StringBasis V0MEST_SINLID { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"77  V0MEST-DATCMD               PIC  X(10).*/
        public StringBasis V0MEST_DATCMD { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0MEST-DATORR               PIC  X(10).*/
        public StringBasis V0MEST_DATORR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0MEST-DATTEC               PIC  X(10).*/
        public StringBasis V0MEST_DATTEC { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0MEST-CODCAU               PIC S9(04) VALUE +0 COMP.*/
        public IntBasis V0MEST_CODCAU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MEST-NUMIRB               PIC S9(11) VALUE +0 COMP-3.*/
        public IntBasis V0MEST_NUMIRB { get; set; } = new IntBasis(new PIC("S9", "11", "S9(11)"));
        /*"77  V0MEST-AVIIRB               PIC  X(10).*/
        public StringBasis V0MEST_AVIIRB { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0MEST-COD-MOEDA-SINI       PIC S9(04) VALUE +0 COMP.*/
        public IntBasis V0MEST_COD_MOEDA_SINI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MEST-SDOPAGBT             PIC S9(13)V9(5) VALUE +0 COMP-3.*/
        public DoubleBasis V0MEST_SDOPAGBT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(5)"), 5);
        /*"77  V0MEST-TOTPAGBT             PIC S9(13)V9(5) VALUE +0 COMP-3.*/
        public DoubleBasis V0MEST_TOTPAGBT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(5)"), 5);
        /*"77  V0MEST-SDORCPBT             PIC S9(13)V9(5) VALUE +0 COMP-3.*/
        public DoubleBasis V0MEST_SDORCPBT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(5)"), 5);
        /*"77  V0MEST-TOTRCPBT             PIC S9(13)V9(5) VALUE +0 COMP-3.*/
        public DoubleBasis V0MEST_TOTRCPBT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(5)"), 5);
        /*"77  V0MEST-SDORSABT             PIC S9(13)V9(5) VALUE +0 COMP-3.*/
        public DoubleBasis V0MEST_SDORSABT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(5)"), 5);
        /*"77  V0MEST-TOTRSDBT             PIC S9(13)V9(5) VALUE +0 COMP-3.*/
        public DoubleBasis V0MEST_TOTRSDBT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(5)"), 5);
        /*"77  V0MEST-TOTDSABT             PIC S9(13)V9(5) VALUE +0 COMP-3.*/
        public DoubleBasis V0MEST_TOTDSABT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(5)"), 5);
        /*"77  V0MEST-TOTHONBT             PIC S9(13)V9(5) VALUE +0 COMP-3.*/
        public DoubleBasis V0MEST_TOTHONBT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(5)"), 5);
        /*"77  V0MEST-SDOADTBT             PIC S9(13)V9(5) VALUE +0 COMP-3.*/
        public DoubleBasis V0MEST_SDOADTBT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(5)"), 5);
        /*"77  V0MEST-ADTRCPBT             PIC S9(13)V9(5) VALUE +0 COMP-3.*/
        public DoubleBasis V0MEST_ADTRCPBT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(5)"), 5);
        /*"77  V0MEST-VALSEGBT             PIC S9(13)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0MEST_VALSEGBT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  V0MEST-PCPARTIC             PIC S9(09)V9(5) VALUE +0 COMP-3.*/
        public DoubleBasis V0MEST_PCPARTIC { get; set; } = new DoubleBasis(new PIC("S9", "9", "S9(09)V9(5)"), 5);
        /*"77  V0MEST-PCTRES               PIC S9(09)V9(5) VALUE +0 COMP-3.*/
        public DoubleBasis V0MEST_PCTRES { get; set; } = new DoubleBasis(new PIC("S9", "9", "S9(09)V9(5)"), 5);
        /*"77  V0MEST-APVALD               PIC S9(09) VALUE +0 COMP.*/
        public IntBasis V0MEST_APVALD { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0MEST-INDSVD               PIC  X(01).*/
        public StringBasis V0MEST_INDSVD { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V0MEST-PAGITG               PIC  X(01).*/
        public StringBasis V0MEST_PAGITG { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V0MEST-MOVPCSAT             PIC S9(09) VALUE +0 COMP.*/
        public IntBasis V0MEST_MOVPCSAT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0MEST-MOVPCSAN             PIC S9(09) VALUE +0 COMP.*/
        public IntBasis V0MEST_MOVPCSAN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0MEST-DTULTMOV             PIC  X(10).*/
        public StringBasis V0MEST_DTULTMOV { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0MEST-SITUACAO             PIC  X(01).*/
        public StringBasis V0MEST_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V0MEST-TIMESTAMP            PIC  X(26).*/
        public StringBasis V0MEST_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"77  V0MEST-BCO-OP               PIC S9(04) VALUE +0 COMP.*/
        public IntBasis V0MEST_BCO_OP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MEST-AGE-OP               PIC S9(04) VALUE +0 COMP.*/
        public IntBasis V0MEST_AGE_OP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MEST-TIPO-PAGAMENTO       PIC  X(01).*/
        public StringBasis V0MEST_TIPO_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V0MEST-RAMO                 PIC S9(04) VALUE +0 COMP.*/
        public IntBasis V0MEST_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MEST-NRORDEM              PIC S9(09) VALUE +0 COMP.*/
        public IntBasis V0MEST_NRORDEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0MEST-CODPRODU             PIC S9(04) VALUE +0 COMP.*/
        public IntBasis V0MEST_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0HIST-DTMOVTO                 PIC  X(10).*/
        public StringBasis V0HIST_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0HIST-VAL-OPERACAO            PIC S9(15)V99 VALUE +0 COMP-3*/
        public DoubleBasis V0HIST_VAL_OPERACAO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V99"), 2);
        /*"01          AREA-DE-WORK.*/
        public SI0848B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SI0848B_AREA_DE_WORK();
        public class SI0848B_AREA_DE_WORK : VarBasis
        {
            /*"  05 WFIM-V0SINISTROS           PIC  X(003)    VALUE 'NAO'.*/
            public StringBasis WFIM_V0SINISTROS { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"  05 W-DATA-AAAA-MM-DD.*/
            public SI0848B_W_DATA_AAAA_MM_DD W_DATA_AAAA_MM_DD { get; set; } = new SI0848B_W_DATA_AAAA_MM_DD();
            public class SI0848B_W_DATA_AAAA_MM_DD : VarBasis
            {
                /*"     10 W-DATA-AAAA-MM-DD-AAAA  PIC  9(04)  VALUE 0.*/
                public IntBasis W_DATA_AAAA_MM_DD_AAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"     10 FILLER                  PIC  X(01)  VALUE '/'.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"     10 W-DATA-AAAA-MM-DD-MM    PIC  9(02)  VALUE 0.*/
                public IntBasis W_DATA_AAAA_MM_DD_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"     10 FILLER                  PIC  X(01)  VALUE '/'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"     10 W-DATA-AAAA-MM-DD-DD    PIC  9(02)  VALUE 0.*/
                public IntBasis W_DATA_AAAA_MM_DD_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"  05 W-DATA-DD-MM-AAAA.*/
            }
            public SI0848B_W_DATA_DD_MM_AAAA W_DATA_DD_MM_AAAA { get; set; } = new SI0848B_W_DATA_DD_MM_AAAA();
            public class SI0848B_W_DATA_DD_MM_AAAA : VarBasis
            {
                /*"     10 W-DATA-DD-MM-AAAA-DD    PIC  9(02)  VALUE 0.*/
                public IntBasis W_DATA_DD_MM_AAAA_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"     10 FILLER                  PIC  X(01)  VALUE '/'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"     10 W-DATA-DD-MM-AAAA-MM    PIC  9(02)  VALUE 0.*/
                public IntBasis W_DATA_DD_MM_AAAA_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"     10 FILLER                  PIC  X(01)  VALUE '/'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"     10 W-DATA-DD-MM-AAAA-AAAA  PIC  9(04)  VALUE 0.*/
                public IntBasis W_DATA_DD_MM_AAAA_AAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"  05        WABEND.*/
            }
            public SI0848B_WABEND WABEND { get; set; } = new SI0848B_WABEND();
            public class SI0848B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(010) VALUE ' SI0848B'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SI0848B");
                /*"    10      FILLER              PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"    10      FILLER              PIC  X(013) VALUE ' *** SQLCODE'*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE");
                /*"    10      WSQLCODE            PIC -------999 VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "-------999"));
                /*"01  W-REG0A.*/
            }
        }
        public SI0848B_W_REG0A W_REG0A { get; set; } = new SI0848B_W_REG0A();
        public class SI0848B_W_REG0A : VarBasis
        {
            /*"    05 FILLER                   PIC X(40) VALUE       'PAGOS CREDITO HABITACIONAL'.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"PAGOS CREDITO HABITACIONAL");
            /*"    05 FILLER                   PIC X(03) VALUE ' ; '.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ; ");
            /*"01  W-REG0B.*/
        }
        public SI0848B_W_REG0B W_REG0B { get; set; } = new SI0848B_W_REG0B();
        public class SI0848B_W_REG0B : VarBasis
        {
            /*"    05 FILLER                   PIC X(10) VALUE 'GERADO EM '.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"GERADO EM ");
            /*"    05 REG0-DTMOVABE            PIC X(10) VALUE ' '.*/
            public StringBasis REG0_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @" ");
            /*"    05 FILLER                   PIC X(20) VALUE ' '.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @" ");
            /*"    05 FILLER                   PIC X(03) VALUE ' ; '.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ; ");
            /*"01  W-REG0C.*/
        }
        public SI0848B_W_REG0C W_REG0C { get; set; } = new SI0848B_W_REG0C();
        public class SI0848B_W_REG0C : VarBasis
        {
            /*"    05 FILLER                   PIC X(18) VALUE       'DATAS SOLICITADAS '.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "18", "X(18)"), @"DATAS SOLICITADAS ");
            /*"    05 REG0-DATA-INICIAL        PIC X(10) VALUE ' '.*/
            public StringBasis REG0_DATA_INICIAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @" ");
            /*"    05 FILLER                   PIC X(03) VALUE ' A '.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" A ");
            /*"    05 REG0-DATA-FINAL          PIC X(10) VALUE ' '.*/
            public StringBasis REG0_DATA_FINAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @" ");
            /*"    05 FILLER                   PIC X(02) VALUE '; '.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"; ");
            /*"01  W-REG1.*/
        }
        public SI0848B_W_REG1 W_REG1 { get; set; } = new SI0848B_W_REG1();
        public class SI0848B_W_REG1 : VarBasis
        {
            /*"    05 FILLER                   PIC X(40) VALUE 'SEGURADO'.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"SEGURADO");
            /*"    05 FILLER                   PIC X(03) VALUE ' ; '.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ; ");
            /*"    05 FILLER                   PIC X(13) VALUE 'SINISTRO'.*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"SINISTRO");
            /*"    05 FILLER                   PIC X(03) VALUE ' ; '.*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ; ");
            /*"    05 FILLER                   PIC X(13) VALUE 'APOLICE'.*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"APOLICE");
            /*"    05 FILLER                   PIC X(03) VALUE ' ; '.*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ; ");
            /*"    05 FILLER                   PIC X(16) VALUE       '     INDENIZACAO'.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"     INDENIZACAO");
            /*"    05 FILLER                   PIC X(03) VALUE ' ; '.*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ; ");
            /*"    05 FILLER                   PIC X(10) VALUE 'DATA PAGTO'.*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"DATA PAGTO");
            /*"    05 FILLER                   PIC X(03) VALUE ' ; '.*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ; ");
            /*"    05 FILLER                   PIC X(23) VALUE 'PRODUTO'.*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"PRODUTO");
            /*"    05 FILLER                   PIC X(03) VALUE ' ; '.*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ; ");
            /*"    05 FILLER                   PIC X(08) VALUE 'OPERACAO'.*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"OPERACAO");
            /*"    05 FILLER                   PIC X(03) VALUE ' ; '.*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ; ");
            /*"    05 FILLER                   PIC X(11) VALUE 'PONTO VENDA'.*/
            public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"PONTO VENDA");
            /*"    05 FILLER                   PIC X(03) VALUE ' ; '.*/
            public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ; ");
            /*"    05 FILLER                   PIC X(08) VALUE 'CONTRATO'.*/
            public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"CONTRATO");
            /*"    05 FILLER                   PIC X(03) VALUE ' ; '.*/
            public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ; ");
            /*"    05 FILLER                   PIC X(13) VALUE 'TIPO SINISTRO'.*/
            public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"TIPO SINISTRO");
            /*"    05 FILLER                   PIC X(03) VALUE ' ; '.*/
            public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ; ");
            /*"    05 FILLER                   PIC X(15) VALUE 'CGC'.*/
            public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"CGC");
            /*"    05 FILLER                   PIC X(03) VALUE ' ; '.*/
            public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ; ");
            /*"01  W-REG2.*/
        }
        public SI0848B_W_REG2 W_REG2 { get; set; } = new SI0848B_W_REG2();
        public class SI0848B_W_REG2 : VarBasis
        {
            /*"    05 REG2-NOME-SEGURADO       PIC X(40) VALUE ' '.*/
            public StringBasis REG2_NOME_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @" ");
            /*"    05 FILLER                   PIC X(03) VALUE ' ; '.*/
            public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ; ");
            /*"    05 REG2-NUM-APOL-SINISTRO   PIC X(13) VALUE ' '.*/
            public StringBasis REG2_NUM_APOL_SINISTRO { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @" ");
            /*"    05 FILLER                   PIC X(03) VALUE ' ; '.*/
            public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ; ");
            /*"    05 REG2-NUM-APOLICE         PIC X(13) VALUE ' '.*/
            public StringBasis REG2_NUM_APOLICE { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @" ");
            /*"    05 FILLER                   PIC X(03) VALUE ' ; '.*/
            public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ; ");
            /*"    05 REG2-VAL-OPERACAO        PIC ZZZZZZZZZZZZ9,99.*/
            public DoubleBasis REG2_VAL_OPERACAO { get; set; } = new DoubleBasis(new PIC("9", "13", "ZZZZZZZZZZZZ9V99."), 2);
            /*"    05 FILLER                   PIC X(03) VALUE ' ; '.*/
            public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ; ");
            /*"    05 REG2-DTMOVTO             PIC X(10) VALUE ' '.*/
            public StringBasis REG2_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @" ");
            /*"    05 FILLER                   PIC X(03) VALUE ' ; '.*/
            public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ; ");
            /*"    05 REG2-CODPRODU            PIC X(23) VALUE ' '.*/
            public StringBasis REG2_CODPRODU { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @" ");
            /*"    05 FILLER                   PIC X(03) VALUE ' ; '.*/
            public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ; ");
            /*"    05 REG2-OPERACAO            PIC ZZZZZZZ9.*/
            public IntBasis REG2_OPERACAO { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZZZZ9."));
            /*"    05 FILLER                   PIC X(03) VALUE ' ; '.*/
            public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ; ");
            /*"    05 REG2-PONTO-VENDA         PIC ZZZZZZZZZZ9.*/
            public IntBasis REG2_PONTO_VENDA { get; set; } = new IntBasis(new PIC("9", "11", "ZZZZZZZZZZ9."));
            /*"    05 FILLER                   PIC X(03) VALUE ' ; '.*/
            public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ; ");
            /*"    05 REG2-NUM-CONTRATO        PIC ZZZZZZZ9.*/
            public IntBasis REG2_NUM_CONTRATO { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZZZZ9."));
            /*"    05 FILLER                   PIC X(03) VALUE ' ; '.*/
            public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ; ");
            /*"    05 REG2-COD-COBERTURA       PIC X(13) VALUE SPACES.*/
            public StringBasis REG2_COD_COBERTURA { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"");
            /*"    05 FILLER                   PIC X(03) VALUE ' ; '.*/
            public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ; ");
            /*"    05 REG2-CGCCPF              PIC ZZZZZZZZZZZZZZ9.*/
            public IntBasis REG2_CGCCPF { get; set; } = new IntBasis(new PIC("9", "15", "ZZZZZZZZZZZZZZ9."));
            /*"    05 FILLER                   PIC X(03) VALUE ' ; '.*/
            public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ; ");
        }


        public SI0848B_V0SINISTROS V0SINISTROS { get; set; } = new SI0848B_V0SINISTROS();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string ARQSAIDA_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                ARQSAIDA.SetFile(ARQSAIDA_FILE_NAME_P);

                /*" -265- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -267- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -269- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -273- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -278- PERFORM Execute_DB_SELECT_1 */

                Execute_DB_SELECT_1();

                /*" -281- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -283- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO(); //GOTO
                    return Result;
                }


                /*" -285- MOVE '002' TO WNR-EXEC-SQL. */
                _.Move("002", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -298- PERFORM Execute_DB_SELECT_2 */

                Execute_DB_SELECT_2();

                /*" -301- IF SQLCODE EQUAL -811 */

                if (DB.SQLCODE == -811)
                {

                    /*" -302- DISPLAY '**********************************************' */
                    _.Display($"**********************************************");

                    /*" -303- DISPLAY '*                                            *' */
                    _.Display($"*                                            *");

                    /*" -304- DISPLAY '* FORAM ENCONTRADAS VARIAS SOLICITACOES NA   *' */
                    _.Display($"* FORAM ENCONTRADAS VARIAS SOLICITACOES NA   *");

                    /*" -305- DISPLAY '* V0RELATORIOS PARA EXECUCAO DO PROGRAMA DE  *' */
                    _.Display($"* V0RELATORIOS PARA EXECUCAO DO PROGRAMA DE  *");

                    /*" -306- DISPLAY '* SINISTRALIDADE DO AZULCAR (SI0848B)        *' */
                    _.Display($"* SINISTRALIDADE DO AZULCAR (SI0848B)        *");

                    /*" -307- DISPLAY '*                                            *' */
                    _.Display($"*                                            *");

                    /*" -308- DISPLAY '*   TERMINO ==> A N O R M A L <==            *' */
                    _.Display($"*   TERMINO ==> A N O R M A L <==            *");

                    /*" -309- DISPLAY '*                                            *' */
                    _.Display($"*                                            *");

                    /*" -310- DISPLAY '**********************************************' */
                    _.Display($"**********************************************");

                    /*" -312- GO TO R0000-90-FINALIZACAO-2. */

                    R0000_90_FINALIZACAO_2(); //GOTO
                    return Result;
                }


                /*" -313- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -314- DISPLAY '**********************************************' */
                    _.Display($"**********************************************");

                    /*" -315- DISPLAY '*                                            *' */
                    _.Display($"*                                            *");

                    /*" -316- DISPLAY '* NAO FOI ENCONTRADA SOLICITACAO NA          *' */
                    _.Display($"* NAO FOI ENCONTRADA SOLICITACAO NA          *");

                    /*" -317- DISPLAY '* V0RELATORIOS PARA EXECUCAO DO PROGRAMA DE  *' */
                    _.Display($"* V0RELATORIOS PARA EXECUCAO DO PROGRAMA DE  *");

                    /*" -318- DISPLAY '* SINISTRALIDADE DO AZULCAR (SI0848B)        *' */
                    _.Display($"* SINISTRALIDADE DO AZULCAR (SI0848B)        *");

                    /*" -319- DISPLAY '*                                            *' */
                    _.Display($"*                                            *");

                    /*" -320- DISPLAY '*   TERMINO ==> A N O R M A L <==            *' */
                    _.Display($"*   TERMINO ==> A N O R M A L <==            *");

                    /*" -321- DISPLAY '*                                            *' */
                    _.Display($"*                                            *");

                    /*" -322- DISPLAY '**********************************************' */
                    _.Display($"**********************************************");

                    /*" -324- GO TO R0000-90-FINALIZACAO-2. */

                    R0000_90_FINALIZACAO_2(); //GOTO
                    return Result;
                }


                /*" -325- IF SQLCODE NOT EQUAL ZERO */

                if (DB.SQLCODE != 00)
                {

                    /*" -327- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO(); //GOTO
                    return Result;
                }


                /*" -329- PERFORM M-100-DECLARE-V0SINISTROS THRU 100-EXIT. */

                M_100_DECLARE_V0SINISTROS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_EXIT*/


                /*" -330- MOVE 'NAO' TO WFIM-V0SINISTROS. */
                _.Move("NAO", AREA_DE_WORK.WFIM_V0SINISTROS);

                /*" -332- PERFORM 110-FETCH-V0SINISTROS THRU 110-EXIT. */

                M_110_FETCH_V0SINISTROS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_110_EXIT*/


                /*" -334- OPEN OUTPUT ARQSAIDA. */
                ARQSAIDA.Open(REG_ARQSAIDA);

                /*" -335- MOVE V0SIST-DTMOVABE TO W-DATA-AAAA-MM-DD. */
                _.Move(V0SIST_DTMOVABE, AREA_DE_WORK.W_DATA_AAAA_MM_DD);

                /*" -336- MOVE W-DATA-AAAA-MM-DD-AAAA TO W-DATA-DD-MM-AAAA-AAAA. */
                _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_AAAA, AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_AAAA);

                /*" -337- MOVE W-DATA-AAAA-MM-DD-MM TO W-DATA-DD-MM-AAAA-MM . */
                _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_MM, AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_MM);

                /*" -338- MOVE W-DATA-AAAA-MM-DD-DD TO W-DATA-DD-MM-AAAA-DD . */
                _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_DD, AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_DD);

                /*" -340- MOVE W-DATA-DD-MM-AAAA TO REG0-DTMOVABE. */
                _.Move(AREA_DE_WORK.W_DATA_DD_MM_AAAA, W_REG0B.REG0_DTMOVABE);

                /*" -341- MOVE V0RELAT-PERI-INICIAL TO W-DATA-AAAA-MM-DD. */
                _.Move(V0RELAT_PERI_INICIAL, AREA_DE_WORK.W_DATA_AAAA_MM_DD);

                /*" -342- MOVE W-DATA-AAAA-MM-DD-AAAA TO W-DATA-DD-MM-AAAA-AAAA. */
                _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_AAAA, AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_AAAA);

                /*" -343- MOVE W-DATA-AAAA-MM-DD-MM TO W-DATA-DD-MM-AAAA-MM . */
                _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_MM, AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_MM);

                /*" -344- MOVE W-DATA-AAAA-MM-DD-DD TO W-DATA-DD-MM-AAAA-DD . */
                _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_DD, AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_DD);

                /*" -346- MOVE W-DATA-DD-MM-AAAA TO REG0-DATA-INICIAL. */
                _.Move(AREA_DE_WORK.W_DATA_DD_MM_AAAA, W_REG0C.REG0_DATA_INICIAL);

                /*" -347- MOVE V0RELAT-PERI-FINAL TO W-DATA-AAAA-MM-DD. */
                _.Move(V0RELAT_PERI_FINAL, AREA_DE_WORK.W_DATA_AAAA_MM_DD);

                /*" -348- MOVE W-DATA-AAAA-MM-DD-AAAA TO W-DATA-DD-MM-AAAA-AAAA. */
                _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_AAAA, AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_AAAA);

                /*" -349- MOVE W-DATA-AAAA-MM-DD-MM TO W-DATA-DD-MM-AAAA-MM . */
                _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_MM, AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_MM);

                /*" -350- MOVE W-DATA-AAAA-MM-DD-DD TO W-DATA-DD-MM-AAAA-DD . */
                _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_DD, AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_DD);

                /*" -352- MOVE W-DATA-DD-MM-AAAA TO REG0-DATA-FINAL. */
                _.Move(AREA_DE_WORK.W_DATA_DD_MM_AAAA, W_REG0C.REG0_DATA_FINAL);

                /*" -353- WRITE REG-ARQSAIDA FROM W-REG0A. */
                _.Move(W_REG0A.GetMoveValues(), REG_ARQSAIDA);

                ARQSAIDA.Write(REG_ARQSAIDA.GetMoveValues().ToString());

                /*" -354- WRITE REG-ARQSAIDA FROM W-REG0B. */
                _.Move(W_REG0B.GetMoveValues(), REG_ARQSAIDA);

                ARQSAIDA.Write(REG_ARQSAIDA.GetMoveValues().ToString());

                /*" -355- WRITE REG-ARQSAIDA FROM W-REG0C. */
                _.Move(W_REG0C.GetMoveValues(), REG_ARQSAIDA);

                ARQSAIDA.Write(REG_ARQSAIDA.GetMoveValues().ToString());

                /*" -357- WRITE REG-ARQSAIDA FROM W-REG1. */
                _.Move(W_REG1.GetMoveValues(), REG_ARQSAIDA);

                ARQSAIDA.Write(REG_ARQSAIDA.GetMoveValues().ToString());

                /*" -358- IF WFIM-V0SINISTROS EQUAL 'SIM' */

                if (AREA_DE_WORK.WFIM_V0SINISTROS == "SIM")
                {

                    /*" -360- MOVE 'NADA SELEC. NAS DATAS INFORMADAS' TO REG2-NOME-SEGURADO */
                    _.Move("NADA SELEC. NAS DATAS INFORMADAS", W_REG2.REG2_NOME_SEGURADO);

                    /*" -361- WRITE REG-ARQSAIDA FROM W-REG2 */
                    _.Move(W_REG2.GetMoveValues(), REG_ARQSAIDA);

                    ARQSAIDA.Write(REG_ARQSAIDA.GetMoveValues().ToString());

                    /*" -362- DISPLAY '**********************************************' */
                    _.Display($"**********************************************");

                    /*" -363- DISPLAY '*                                            *' */
                    _.Display($"*                                            *");

                    /*" -364- DISPLAY '* NADA SELECIONADO PARA GERACAO DO ARQUIVO   *' */
                    _.Display($"* NADA SELECIONADO PARA GERACAO DO ARQUIVO   *");

                    /*" -365- DISPLAY '* SINISTROS PAGOS DE CREDITO HABITACIONAL    *' */
                    _.Display($"* SINISTROS PAGOS DE CREDITO HABITACIONAL    *");

                    /*" -366- DISPLAY '*                                            *' */
                    _.Display($"*                                            *");

                    /*" -367- DISPLAY '**********************************************' */
                    _.Display($"**********************************************");

                    /*" -369- GO TO R0000-90-FINALIZACAO-1. */

                    R0000_90_FINALIZACAO_1(); //GOTO
                    return Result;
                }


                /*" -370- PERFORM 200-PROCESSA-PAGAMENTOS THRU 200-EXIT UNTIL WFIM-V0SINISTROS EQUAL 'SIM' . */

                while (!(AREA_DE_WORK.WFIM_V0SINISTROS == "SIM"))
                {

                    M_200_PROCESSA_PAGAMENTOS(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_200_EXIT*/

                }

                /*" -370- FLUXCONTROL_PERFORM Execute-DB-SELECT-1 */

                Execute_DB_SELECT_1();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" Execute-DB-SELECT-1 */
        public void Execute_DB_SELECT_1()
        {
            /*" -278- EXEC SQL SELECT DTMOVABE INTO :V0SIST-DTMOVABE FROM SEGUROS.V0SISTEMA WHERE IDSISTEM = 'SI' END-EXEC. */

            var execute_DB_SELECT_1_Query1 = new Execute_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = Execute_DB_SELECT_1_Query1.Execute(execute_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SIST_DTMOVABE, V0SIST_DTMOVABE);
            }


        }

        [StopWatch]
        /*" R0000-90-FINALIZACAO-1 */
        private void R0000_90_FINALIZACAO_1(bool isPerform = false)
        {
            /*" -376- CLOSE ARQSAIDA. */
            ARQSAIDA.Close();

        }

        [StopWatch]
        /*" Execute-DB-SELECT-2 */
        public void Execute_DB_SELECT_2()
        {
            /*" -298- EXEC SQL SELECT MES_REFERENCIA, ANO_REFERENCIA, PERI_INICIAL , PERI_FINAL INTO :V0RELAT-MES-REFERENCIA, :V0RELAT-ANO-REFERENCIA, :V0RELAT-PERI-INICIAL , :V0RELAT-PERI-FINAL FROM SEGUROS.V0RELATORIOS WHERE IDSISTEM = 'SI' AND DATA_SOLICITACAO = :V0SIST-DTMOVABE AND CODRELAT = 'SI0848B' END-EXEC. */

            var execute_DB_SELECT_2_Query1 = new Execute_DB_SELECT_2_Query1()
            {
                V0SIST_DTMOVABE = V0SIST_DTMOVABE.ToString(),
            };

            var executed_1 = Execute_DB_SELECT_2_Query1.Execute(execute_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RELAT_MES_REFERENCIA, V0RELAT_MES_REFERENCIA);
                _.Move(executed_1.V0RELAT_ANO_REFERENCIA, V0RELAT_ANO_REFERENCIA);
                _.Move(executed_1.V0RELAT_PERI_INICIAL, V0RELAT_PERI_INICIAL);
                _.Move(executed_1.V0RELAT_PERI_FINAL, V0RELAT_PERI_FINAL);
            }


        }

        [StopWatch]
        /*" R0000-90-FINALIZACAO-2 */
        private void R0000_90_FINALIZACAO_2(bool isPerform = false)
        {
            /*" -385- MOVE '003' TO WNR-EXEC-SQL. */
            _.Move("003", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -390- PERFORM R0000_90_FINALIZACAO_2_DB_DELETE_1 */

            R0000_90_FINALIZACAO_2_DB_DELETE_1();

            /*" -394- IF (SQLCODE NOT EQUAL ZEROS) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -396- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -397- DISPLAY '**********************************************' */
            _.Display($"**********************************************");

            /*" -398- DISPLAY '*                                            *' */
            _.Display($"*                                            *");

            /*" -399- DISPLAY '*                PROGRAMA                    *' */
            _.Display($"*                PROGRAMA                    *");

            /*" -400- DISPLAY '*                                            *' */
            _.Display($"*                                            *");

            /*" -401- DISPLAY '*            ==> SI0848B <==                 *' */
            _.Display($"*            ==> SI0848B <==                 *");

            /*" -402- DISPLAY '*                                            *' */
            _.Display($"*                                            *");

            /*" -403- DISPLAY '*   TERMINO  ==> N O R M A L <==             *' */
            _.Display($"*   TERMINO  ==> N O R M A L <==             *");

            /*" -404- DISPLAY '*                                            *' */
            _.Display($"*                                            *");

            /*" -406- DISPLAY '**********************************************' . */
            _.Display($"**********************************************");

            /*" -406- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -410- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -410- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0000-90-FINALIZACAO-2-DB-DELETE-1 */
        public void R0000_90_FINALIZACAO_2_DB_DELETE_1()
        {
            /*" -390- EXEC SQL DELETE FROM SEGUROS.V0RELATORIOS WHERE IDSISTEM = 'SI' AND DATA_SOLICITACAO = :V0SIST-DTMOVABE AND CODRELAT = 'SI0848B' END-EXEC. */

            var r0000_90_FINALIZACAO_2_DB_DELETE_1_Delete1 = new R0000_90_FINALIZACAO_2_DB_DELETE_1_Delete1()
            {
                V0SIST_DTMOVABE = V0SIST_DTMOVABE.ToString(),
            };

            R0000_90_FINALIZACAO_2_DB_DELETE_1_Delete1.Execute(r0000_90_FINALIZACAO_2_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" M-100-DECLARE-V0SINISTROS */
        private void M_100_DECLARE_V0SINISTROS(bool isPerform = false)
        {
            /*" -418- MOVE '004' TO WNR-EXEC-SQL. */
            _.Move("004", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -442- PERFORM M_100_DECLARE_V0SINISTROS_DB_DECLARE_1 */

            M_100_DECLARE_V0SINISTROS_DB_DECLARE_1();

            /*" -444- PERFORM M_100_DECLARE_V0SINISTROS_DB_OPEN_1 */

            M_100_DECLARE_V0SINISTROS_DB_OPEN_1();

            /*" -447- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -448- DISPLAY 'ERRO NO OPEN V0SINISTROS.......' */
                _.Display($"ERRO NO OPEN V0SINISTROS.......");

                /*" -448- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-100-DECLARE-V0SINISTROS-DB-DECLARE-1 */
        public void M_100_DECLARE_V0SINISTROS_DB_DECLARE_1()
        {
            /*" -442- EXEC SQL DECLARE V0SINISTROS CURSOR FOR SELECT A.NOME_SEGURADO , M.NUM_APOL_SINISTRO, M.NUM_APOLICE , H.VAL_OPERACAO , H.DTMOVTO , M.CODPRODU , A.OPERACAO , A.PONTO_VENDA , A.NUM_CONTRATO , A.COD_COBERTURA , A.CGCCPF FROM SEGUROS.V0MESTSINI M, SEGUROS.V0HISTSINI H, SEGUROS.V0SINISTRO_HABIT01 A WHERE M.CODPRODU IN ( 4801, 6803, 6804, 6805) AND M.SITUACAO <> '2' AND H.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO AND H.OPERACAO IN (1001,1002,1003,1004,1009) AND H.SITUACAO <> '2' AND H.DTMOVTO BETWEEN :V0RELAT-PERI-INICIAL AND :V0RELAT-PERI-FINAL AND A.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO ORDER BY H.DTMOVTO END-EXEC. */
            V0SINISTROS = new SI0848B_V0SINISTROS(true);
            string GetQuery_V0SINISTROS()
            {
                var query = @$"SELECT A.NOME_SEGURADO
							, 
							M.NUM_APOL_SINISTRO
							, 
							M.NUM_APOLICE
							, 
							H.VAL_OPERACAO
							, 
							H.DTMOVTO
							, 
							M.CODPRODU
							, 
							A.OPERACAO
							, 
							A.PONTO_VENDA
							, 
							A.NUM_CONTRATO
							, 
							A.COD_COBERTURA
							, 
							A.CGCCPF 
							FROM SEGUROS.V0MESTSINI M
							, 
							SEGUROS.V0HISTSINI H
							, 
							SEGUROS.V0SINISTRO_HABIT01 A 
							WHERE M.CODPRODU IN ( 4801
							, 6803
							, 6804
							, 6805) 
							AND M.SITUACAO <> '2' 
							AND H.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO 
							AND H.OPERACAO IN (1001
							,1002
							,1003
							,1004
							,1009) 
							AND H.SITUACAO <> '2' 
							AND H.DTMOVTO BETWEEN '{V0RELAT_PERI_INICIAL}' 
							AND '{V0RELAT_PERI_FINAL}' 
							AND A.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO 
							ORDER BY H.DTMOVTO";

                return query;
            }
            V0SINISTROS.GetQueryEvent += GetQuery_V0SINISTROS;

        }

        [StopWatch]
        /*" M-100-DECLARE-V0SINISTROS-DB-OPEN-1 */
        public void M_100_DECLARE_V0SINISTROS_DB_OPEN_1()
        {
            /*" -444- EXEC SQL OPEN V0SINISTROS END-EXEC. */

            V0SINISTROS.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_EXIT*/

        [StopWatch]
        /*" M-110-FETCH-V0SINISTROS */
        private void M_110_FETCH_V0SINISTROS(bool isPerform = false)
        {
            /*" -456- MOVE '005' TO WNR-EXEC-SQL. */
            _.Move("005", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -468- PERFORM M_110_FETCH_V0SINISTROS_DB_FETCH_1 */

            M_110_FETCH_V0SINISTROS_DB_FETCH_1();

            /*" -471- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -472- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -473- MOVE 'SIM' TO WFIM-V0SINISTROS */
                    _.Move("SIM", AREA_DE_WORK.WFIM_V0SINISTROS);

                    /*" -473- PERFORM M_110_FETCH_V0SINISTROS_DB_CLOSE_1 */

                    M_110_FETCH_V0SINISTROS_DB_CLOSE_1();

                    /*" -474- EXEC SQL COMMIT END-EXEC */

                    DatabaseConnection.Instance.CommitTransaction();

                    /*" -476- ELSE */
                }
                else
                {


                    /*" -477- DISPLAY 'ERRO NO FETCH DA V0SINISTROS.........' */
                    _.Display($"ERRO NO FETCH DA V0SINISTROS.........");

                    /*" -477- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-110-FETCH-V0SINISTROS-DB-FETCH-1 */
        public void M_110_FETCH_V0SINISTROS_DB_FETCH_1()
        {
            /*" -468- EXEC SQL FETCH V0SINISTROS INTO :V0SINI-HABIT01-NOME-SEGURADO , :V0MEST-NUM-APOL-SINISTRO, :V0MEST-NUM-APOLICE , :V0HIST-VAL-OPERACAO , :V0HIST-DTMOVTO , :V0MEST-CODPRODU , :V0SINI-HABIT01-OPERACAO , :V0SINI-HABIT01-PONTO-VENDA , :V0SINI-HABIT01-NUM-CONTRATO, :V0SINI-HABIT01-COD-COBERTURA , :V0SINI-HABIT01-CGCCPF END-EXEC. */

            if (V0SINISTROS.Fetch())
            {
                _.Move(V0SINISTROS.V0SINI_HABIT01_NOME_SEGURADO, V0SINI_HABIT01_NOME_SEGURADO);
                _.Move(V0SINISTROS.V0MEST_NUM_APOL_SINISTRO, V0MEST_NUM_APOL_SINISTRO);
                _.Move(V0SINISTROS.V0MEST_NUM_APOLICE, V0MEST_NUM_APOLICE);
                _.Move(V0SINISTROS.V0HIST_VAL_OPERACAO, V0HIST_VAL_OPERACAO);
                _.Move(V0SINISTROS.V0HIST_DTMOVTO, V0HIST_DTMOVTO);
                _.Move(V0SINISTROS.V0MEST_CODPRODU, V0MEST_CODPRODU);
                _.Move(V0SINISTROS.V0SINI_HABIT01_OPERACAO, V0SINI_HABIT01_OPERACAO);
                _.Move(V0SINISTROS.V0SINI_HABIT01_PONTO_VENDA, V0SINI_HABIT01_PONTO_VENDA);
                _.Move(V0SINISTROS.V0SINI_HABIT01_NUM_CONTRATO, V0SINI_HABIT01_NUM_CONTRATO);
                _.Move(V0SINISTROS.V0SINI_HABIT01_COD_COBERTURA, V0SINI_HABIT01_COD_COBERTURA);
                _.Move(V0SINISTROS.V0SINI_HABIT01_CGCCPF, V0SINI_HABIT01_CGCCPF);
            }

        }

        [StopWatch]
        /*" M-110-FETCH-V0SINISTROS-DB-CLOSE-1 */
        public void M_110_FETCH_V0SINISTROS_DB_CLOSE_1()
        {
            /*" -473- EXEC SQL CLOSE V0SINISTROS END-EXEC */

            V0SINISTROS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_110_EXIT*/

        [StopWatch]
        /*" M-200-PROCESSA-PAGAMENTOS */
        private void M_200_PROCESSA_PAGAMENTOS(bool isPerform = false)
        {
            /*" -484- MOVE V0SINI-HABIT01-NOME-SEGURADO TO REG2-NOME-SEGURADO. */
            _.Move(V0SINI_HABIT01_NOME_SEGURADO, W_REG2.REG2_NOME_SEGURADO);

            /*" -485- MOVE V0MEST-NUM-APOL-SINISTRO TO REG2-NUM-APOL-SINISTRO. */
            _.Move(V0MEST_NUM_APOL_SINISTRO, W_REG2.REG2_NUM_APOL_SINISTRO);

            /*" -486- MOVE V0MEST-NUM-APOLICE TO REG2-NUM-APOLICE. */
            _.Move(V0MEST_NUM_APOLICE, W_REG2.REG2_NUM_APOLICE);

            /*" -488- MOVE V0HIST-VAL-OPERACAO TO REG2-VAL-OPERACAO. */
            _.Move(V0HIST_VAL_OPERACAO, W_REG2.REG2_VAL_OPERACAO);

            /*" -489- MOVE V0HIST-DTMOVTO TO W-DATA-AAAA-MM-DD. */
            _.Move(V0HIST_DTMOVTO, AREA_DE_WORK.W_DATA_AAAA_MM_DD);

            /*" -490- MOVE W-DATA-AAAA-MM-DD-AAAA TO W-DATA-DD-MM-AAAA-AAAA. */
            _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_AAAA, AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_AAAA);

            /*" -491- MOVE W-DATA-AAAA-MM-DD-MM TO W-DATA-DD-MM-AAAA-MM. */
            _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_MM, AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_MM);

            /*" -492- MOVE W-DATA-AAAA-MM-DD-DD TO W-DATA-DD-MM-AAAA-DD. */
            _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_DD, AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_DD);

            /*" -494- MOVE W-DATA-DD-MM-AAAA TO REG2-DTMOVTO. */
            _.Move(AREA_DE_WORK.W_DATA_DD_MM_AAAA, W_REG2.REG2_DTMOVTO);

            /*" -495- IF V0MEST-CODPRODU EQUAL 4801 */

            if (V0MEST_CODPRODU == 4801)
            {

                /*" -496- MOVE 'CRED. CASA / CRED. MAQ.' TO REG2-CODPRODU */
                _.Move("CRED. CASA / CRED. MAQ.", W_REG2.REG2_CODPRODU);

                /*" -497- ELSE */
            }
            else
            {


                /*" -498- IF V0MEST-CODPRODU EQUAL 6803 */

                if (V0MEST_CODPRODU == 6803)
                {

                    /*" -499- MOVE 'CARTA DE CREDITO       ' TO REG2-CODPRODU */
                    _.Move("CARTA DE CREDITO       ", W_REG2.REG2_CODPRODU);

                    /*" -500- ELSE */
                }
                else
                {


                    /*" -501- IF V0MEST-CODPRODU EQUAL 6804 */

                    if (V0MEST_CODPRODU == 6804)
                    {

                        /*" -502- MOVE 'P.C.I.                 ' TO REG2-CODPRODU */
                        _.Move("P.C.I.                 ", W_REG2.REG2_CODPRODU);

                        /*" -503- ELSE */
                    }
                    else
                    {


                        /*" -504- IF V0MEST-CODPRODU EQUAL 6805 */

                        if (V0MEST_CODPRODU == 6805)
                        {

                            /*" -506- MOVE 'SFH LIVRE              ' TO REG2-CODPRODU. */
                            _.Move("SFH LIVRE              ", W_REG2.REG2_CODPRODU);
                        }

                    }

                }

            }


            /*" -507- MOVE V0SINI-HABIT01-OPERACAO TO REG2-OPERACAO. */
            _.Move(V0SINI_HABIT01_OPERACAO, W_REG2.REG2_OPERACAO);

            /*" -508- MOVE V0SINI-HABIT01-PONTO-VENDA TO REG2-PONTO-VENDA. */
            _.Move(V0SINI_HABIT01_PONTO_VENDA, W_REG2.REG2_PONTO_VENDA);

            /*" -510- MOVE V0SINI-HABIT01-NUM-CONTRATO TO REG2-NUM-CONTRATO. */
            _.Move(V0SINI_HABIT01_NUM_CONTRATO, W_REG2.REG2_NUM_CONTRATO);

            /*" -511- IF V0SINI-HABIT01-COD-COBERTURA EQUAL 1 */

            if (V0SINI_HABIT01_COD_COBERTURA == 1)
            {

                /*" -512- MOVE 'M.I.P.' TO REG2-COD-COBERTURA */
                _.Move("M.I.P.", W_REG2.REG2_COD_COBERTURA);

                /*" -513- ELSE */
            }
            else
            {


                /*" -514- IF V0SINI-HABIT01-COD-COBERTURA EQUAL 2 */

                if (V0SINI_HABIT01_COD_COBERTURA == 2)
                {

                    /*" -515- MOVE 'D.F.I.' TO REG2-COD-COBERTURA */
                    _.Move("D.F.I.", W_REG2.REG2_COD_COBERTURA);

                    /*" -516- ELSE */
                }
                else
                {


                    /*" -517- IF V0SINI-HABIT01-COD-COBERTURA EQUAL 3 */

                    if (V0SINI_HABIT01_COD_COBERTURA == 3)
                    {

                        /*" -519- MOVE 'INADIPLENCIA' TO REG2-COD-COBERTURA. */
                        _.Move("INADIPLENCIA", W_REG2.REG2_COD_COBERTURA);
                    }

                }

            }


            /*" -521- MOVE V0SINI-HABIT01-CGCCPF TO REG2-CGCCPF. */
            _.Move(V0SINI_HABIT01_CGCCPF, W_REG2.REG2_CGCCPF);

            /*" -523- WRITE REG-ARQSAIDA FROM W-REG2. */
            _.Move(W_REG2.GetMoveValues(), REG_ARQSAIDA);

            ARQSAIDA.Write(REG_ARQSAIDA.GetMoveValues().ToString());

            /*" -523- PERFORM 110-FETCH-V0SINISTROS THRU 110-EXIT. */

            M_110_FETCH_V0SINISTROS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_110_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_200_EXIT*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO */
        private void R9999_00_ROT_ERRO(bool isPerform = false)
        {
            /*" -535- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -537- DISPLAY WABEND. */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -537- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -541- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -541- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}