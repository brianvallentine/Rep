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
using Sias.Sinistro.DB2.SI0042B;

namespace Code
{
    public class SI0042B
    {
        public bool IsCall { get; set; }

        public SI0042B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-------------------------------------                                  */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................ SINISTRO                            *      */
        /*"      *   SUBROTINA............... SI0042B                             *      */
        /*"      *   ANALISTA ............... ALEXIS                              *      */
        /*"      *   PROGRAMADOR ............ ALEXIS                              *      */
        /*"      *   DATA CODIFICACAO ....... MAR / 2005                          *      */
        /*"      *   FUNCAO ................. RELATORIO DE SINISTRO PROTOCOLADO   *      */
        /*"      *                            SEM AVISO POR ANALISTA              *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 11/07/08 - BRSEG - CAD.12115 - SAC.237                         *      */
        /*"      *            ELIMINAR CARACTERES ESPECIAIS DE CONTROLE DE IMPRES-*      */
        /*"      *            SAO NOS ARQUIVOS.   -   PROCURE: BR.V01             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        /*"      *-------------------------------------                                  */
        #endregion


        #region VARIABLES

        public FileBasis _SI0042B1 { get; set; } = new FileBasis(new PIC("X", "190", "X(190)"));

        public FileBasis SI0042B1
        {
            get
            {
                _.Move(REG_SI0042B1, _SI0042B1); VarBasis.RedefinePassValue(REG_SI0042B1, _SI0042B1, REG_SI0042B1); return _SI0042B1;
            }
        }
        /*"01          REG-SI0042B1         PIC  X(190).*/
        public StringBasis REG_SI0042B1 { get; set; } = new StringBasis(new PIC("X", "190", "X(190)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01          HOST-DATA-AVISO      PIC  X(010)   VALUE   SPACES.*/
        public StringBasis HOST_DATA_AVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01          WS-COD-USUARIO-ANT   PIC  X(008)   VALUE   SPACES.*/
        public StringBasis WS_COD_USUARIO_ANT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"01          AREA-DE-WORK.*/
        public SI0042B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SI0042B_AREA_DE_WORK();
        public class SI0042B_AREA_DE_WORK : VarBasis
        {
            /*"  05        AC-L-LISTA           PIC  9(006)   VALUE   ZEROS.*/
            public IntBasis AC_L_LISTA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05        AC-I-SI0042B1        PIC  9(006)   VALUE   ZEROS.*/
            public IntBasis AC_I_SI0042B1 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05        AC-A-SINISTROS       PIC  9(006)   VALUE   ZEROS.*/
            public IntBasis AC_A_SINISTROS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05        AC-G-SINISTROS       PIC  9(006)   VALUE   ZEROS.*/
            public IntBasis AC_G_SINISTROS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05        WFIM-LISTA           PIC  X(001)   VALUE   SPACES.*/
            public StringBasis WFIM_LISTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05        WFIM-RELATORI        PIC  X(001)   VALUE   SPACES.*/
            public StringBasis WFIM_RELATORI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05        AC-LINHAS            PIC  9(006)   VALUE   ZEROS.*/
            public IntBasis AC_LINHAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05        AC-PAGINAS           PIC  9(006)   VALUE   ZEROS.*/
            public IntBasis AC_PAGINAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05        DB2-DATA.*/
            public SI0042B_DB2_DATA DB2_DATA { get; set; } = new SI0042B_DB2_DATA();
            public class SI0042B_DB2_DATA : VarBasis
            {
                /*"    10      DB2-ANO              PIC  9(004).*/
                public IntBasis DB2_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      FILLER               PIC  X(001).*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      DB2-MES              PIC  9(002).*/
                public IntBasis DB2_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      FILLER               PIC  X(001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      DB2-DIA              PIC  9(002).*/
                public IntBasis DB2_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05        EDIT-DATA.*/
            }
            public SI0042B_EDIT_DATA EDIT_DATA { get; set; } = new SI0042B_EDIT_DATA();
            public class SI0042B_EDIT_DATA : VarBasis
            {
                /*"    10      EDIT-DIA             PIC  9(002)  VALUE ZEROS.*/
                public IntBasis EDIT_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      FILLER               PIC  X(001)  VALUE '/'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10      EDIT-MES             PIC  9(002)  VALUE ZEROS.*/
                public IntBasis EDIT_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      FILLER               PIC  X(001)  VALUE '/'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10      EDIT-ANO             PIC  9(004)  VALUE ZEROS.*/
                public IntBasis EDIT_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05        ACC-HORA.*/
            }
            public SI0042B_ACC_HORA ACC_HORA { get; set; } = new SI0042B_ACC_HORA();
            public class SI0042B_ACC_HORA : VarBasis
            {
                /*"    10      ACC-HH               PIC  99.*/
                public IntBasis ACC_HH { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                /*"    10      ACC-MM               PIC  99.*/
                public IntBasis ACC_MM { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                /*"    10      ACC-SS               PIC  99.*/
                public IntBasis ACC_SS { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                /*"    10      ACC-CC               PIC  99.*/
                public IntBasis ACC_CC { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                /*"  05        EDIT-HORA.*/
            }
            public SI0042B_EDIT_HORA EDIT_HORA { get; set; } = new SI0042B_EDIT_HORA();
            public class SI0042B_EDIT_HORA : VarBasis
            {
                /*"    10      EDIT-HH              PIC  9(002)  VALUE ZEROS.*/
                public IntBasis EDIT_HH { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      FILLER               PIC  X(001)  VALUE ':'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"    10      EDIT-MM              PIC  9(002)  VALUE ZEROS.*/
                public IntBasis EDIT_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      FILLER               PIC  X(001)  VALUE ':'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"    10      EDIT-SS              PIC  9(002)  VALUE ZEROS.*/
                public IntBasis EDIT_SS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05        WABEND.*/
            }
            public SI0042B_WABEND WABEND { get; set; } = new SI0042B_WABEND();
            public class SI0042B_WABEND : VarBasis
            {
                /*"    10      FILLER               PIC  X(010) VALUE           ' SI0042B'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SI0042B");
                /*"    10      FILLER               PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL         PIC  X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"    10      FILLER               PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE             PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"01          LC00.*/
            }
        }
        public SI0042B_LC00 LC00 { get; set; } = new SI0042B_LC00();
        public class SI0042B_LC00 : VarBasis
        {
            /*"  05        LC00-CANAL           PIC  X(001) VALUE ' '.*/
            public StringBasis LC00_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"  05        FILLER               PIC  X(189) VALUE SPACES.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "189", "X(189)"), @"");
            /*"01          LC01.*/
        }
        public SI0042B_LC01 LC01 { get; set; } = new SI0042B_LC01();
        public class SI0042B_LC01 : VarBasis
        {
            /*"  05        LC01-CANAL           PIC  X(001) VALUE '1'.*/
            public StringBasis LC01_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
            /*"  05        FILLER               PIC  X(075) VALUE 'SI0042B'.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "75", "X(075)"), @"SI0042B");
            /*"  05        FILLER               PIC  X(036) VALUE                          'RELATORIO DE SINISTROS PROTOCOLADOS '*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"RELATORIO DE SINISTROS PROTOCOLADOS ");
            /*"  05        FILLER               PIC  X(061) VALUE                          'SEM AVISO POR ANALISTA'.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "61", "X(061)"), @"SEM AVISO POR ANALISTA");
            /*"  05        FILLER               PIC  X(013) VALUE 'PAGINA'.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"PAGINA");
            /*"  05        LC01-PAGINA          PIC  ZZZ9.*/
            public IntBasis LC01_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
            /*"01          LC02.*/
        }
        public SI0042B_LC02 LC02 { get; set; } = new SI0042B_LC02();
        public class SI0042B_LC02 : VarBasis
        {
            /*"  05        LC02-CANAL           PIC  X(001) VALUE ' '.*/
            public StringBasis LC02_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"  05        FILLER               PIC  X(082) VALUE SPACES.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "82", "X(082)"), @"");
            /*"  05        FILLER               PIC  X(014) VALUE                                                'PENDENCIA ATE '*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"PENDENCIA ATE ");
            /*"  05        LC02-DATA-MOV-ABERTO PIC  X(010) VALUE SPACES.*/
            public StringBasis LC02_DATA_MOV_ABERTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05        FILLER               PIC  X(066) VALUE SPACES.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "66", "X(066)"), @"");
            /*"  05        FILLER               PIC  X(007) VALUE 'DATA'.*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"DATA");
            /*"  05        LC02-DATA            PIC  X(010) VALUE SPACES.*/
            public StringBasis LC02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"01          LC03.*/
        }
        public SI0042B_LC03 LC03 { get; set; } = new SI0042B_LC03();
        public class SI0042B_LC03 : VarBasis
        {
            /*"  05        LC03-CANAL           PIC  X(001) VALUE ' '.*/
            public StringBasis LC03_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"  05        FILLER               PIC  X(172) VALUE SPACES.*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "172", "X(172)"), @"");
            /*"  05        FILLER               PIC  X(009) VALUE 'HORA'.*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"HORA");
            /*"  05        LC03-HORA            PIC  X(008) VALUE SPACES.*/
            public StringBasis LC03_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"01          LC04.*/
        }
        public SI0042B_LC04 LC04 { get; set; } = new SI0042B_LC04();
        public class SI0042B_LC04 : VarBasis
        {
            /*"  05        LC04-CANAL           PIC  X(001) VALUE ' '.*/
            public StringBasis LC04_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"  05        FILLER               PIC  X(001) VALUE '*'.*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
            /*"  05        FILLER               PIC  X(187) VALUE ALL '-'.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "187", "X(187)"), @"ALL");
            /*"  05        FILLER               PIC  X(001) VALUE '*'.*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
            /*"01          LC05.*/
        }
        public SI0042B_LC05 LC05 { get; set; } = new SI0042B_LC05();
        public class SI0042B_LC05 : VarBasis
        {
            /*"  05        LC05-CANAL           PIC  X(001) VALUE ' '.*/
            public StringBasis LC05_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"  05        FILLER               PIC  X(011) VALUE ' ANALISTA:'.*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @" ANALISTA:");
            /*"  05        LC05-ANALISTA        PIC  X(040) VALUE SPACES.*/
            public StringBasis LC05_ANALISTA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"  05        FILLER               PIC  X(138) VALUE SPACES.*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "138", "X(138)"), @"");
            /*"01          LC06.*/
        }
        public SI0042B_LC06 LC06 { get; set; } = new SI0042B_LC06();
        public class SI0042B_LC06 : VarBasis
        {
            /*"  05        LC06-CANAL           PIC  X(001) VALUE ' '.*/
            public StringBasis LC06_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"  05        FILLER               PIC  X(009) VALUE SPACES.*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
            /*"  05        FILLER               PIC  X(017) VALUE 'PROTOCOLO'.*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"PROTOCOLO");
            /*"  05        FILLER               PIC  X(048) VALUE                                              'NOME DO SEGURADO'*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"NOME DO SEGURADO");
            /*"  05        FILLER               PIC  X(012) VALUE 'TIPO'.*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"TIPO");
            /*"  05        FILLER               PIC  X(021) VALUE                                              'DATA PROTOCOLO'.*/
            public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"DATA PROTOCOLO");
            /*"  05        FILLER               PIC  X(044) VALUE SPACES.*/
            public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "44", "X(044)"), @"");
            /*"  05        FILLER               PIC  X(015) VALUE SPACES.*/
            public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
            /*"  05        FILLER               PIC  X(023) VALUE SPACES.*/
            public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"");
            /*"01          LD01.*/
        }
        public SI0042B_LD01 LD01 { get; set; } = new SI0042B_LD01();
        public class SI0042B_LD01 : VarBasis
        {
            /*"  05        LD01-CANAL           PIC  X(001) VALUE ' '.*/
            public StringBasis LD01_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"  05        FILLER               PIC  X(009) VALUE SPACES.*/
            public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
            /*"  05        LD01-NUM-PROTOCOLO   PIC  999999999.*/
            public IntBasis LD01_NUM_PROTOCOLO { get; set; } = new IntBasis(new PIC("9", "9", "999999999."));
            /*"  05        FILLER               PIC  X(001) VALUE '-'.*/
            public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"  05        LD01-DAC-PROTOCOLO   PIC  9.*/
            public IntBasis LD01_DAC_PROTOCOLO { get; set; } = new IntBasis(new PIC("9", "1", "9."));
            /*"  05        FILLER               PIC  X(006) VALUE SPACES.*/
            public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
            /*"  05        LD01-NOME-SEGURADO   PIC  X(040) VALUE SPACES.*/
            public StringBasis LD01_NOME_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"  05        FILLER               PIC  X(008) VALUE SPACES.*/
            public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"  05        LD01-TIPO-SINISTRO   PIC  X(003) VALUE SPACES.*/
            public StringBasis LD01_TIPO_SINISTRO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05        FILLER               PIC  X(009) VALUE SPACES.*/
            public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
            /*"  05        LD01-DATA-PROTOCOLO  PIC  X(010) VALUE SPACES.*/
            public StringBasis LD01_DATA_PROTOCOLO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05        FILLER               PIC  X(011) VALUE SPACES.*/
            public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"");
            /*"  05        FILLER               PIC  X(045) VALUE SPACES.*/
            public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"");
            /*"  05        FILLER               PIC  X(030) VALUE SPACES.*/
            public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
            /*"  05        FILLER               PIC  X(007) VALUE SPACES.*/
            public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
            /*"01          LD02.*/
        }
        public SI0042B_LD02 LD02 { get; set; } = new SI0042B_LD02();
        public class SI0042B_LD02 : VarBasis
        {
            /*"  05        LD02-CANAL           PIC  X(001) VALUE ' '.*/
            public StringBasis LD02_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"  05        FILLER               PIC  X(089) VALUE SPACES.*/
            public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "89", "X(089)"), @"");
            /*"  05        LD02-LITERAL         PIC  X(020) VALUE SPACES.*/
            public StringBasis LD02_LITERAL { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
            /*"  05        FILLER               PIC  X(001) VALUE SPACES.*/
            public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05        LD02-TOTAL           PIC  ZZZZZ9.*/
            public IntBasis LD02_TOTAL { get; set; } = new IntBasis(new PIC("9", "6", "ZZZZZ9."));
            /*"  05        FILLER               PIC  X(073) VALUE SPACES.*/
            public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "73", "X(073)"), @"");
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.SISINACO SISINACO { get; set; } = new Dclgens.SISINACO();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.SIMOVSIN SIMOVSIN { get; set; } = new Dclgens.SIMOVSIN();
        public Dclgens.SIANAROD SIANAROD { get; set; } = new Dclgens.SIANAROD();
        public Dclgens.SISINFAS SISINFAS { get; set; } = new Dclgens.SISINFAS();
        public Dclgens.SIEVETIP SIEVETIP { get; set; } = new Dclgens.SIEVETIP();
        public Dclgens.USUARIOS USUARIOS { get; set; } = new Dclgens.USUARIOS();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public SI0042B_LISTA LISTA { get; set; } = new SI0042B_LISTA();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SI0042B1_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SI0042B1.SetFile(SI0042B1_FILE_NAME_P);

                /*" -208- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -208- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -209- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -210- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -210- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -218- OPEN OUTPUT SI0042B1 */
            SI0042B1.Open(REG_SI0042B1);

            /*" -220- PERFORM R0500-00-LE-SISTEMAS */

            R0500_00_LE_SISTEMAS_SECTION();

            /*" -222- PERFORM R0600-00-LE-RELATORIOS */

            R0600_00_LE_RELATORIOS_SECTION();

            /*" -223- IF WFIM-RELATORI EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_RELATORI == "S")
            {

                /*" -224- DISPLAY '******************************************' */
                _.Display($"******************************************");

                /*" -225- DISPLAY '* NAO HOUVE SOLICITACAO PARA O RELATORIO *' */
                _.Display($"* NAO HOUVE SOLICITACAO PARA O RELATORIO *");

                /*" -226- DISPLAY '******************************************' */
                _.Display($"******************************************");

                /*" -227- DISPLAY ' ' */
                _.Display($" ");

                /*" -229- GO TO R0000-90-ENCERRA. */

                R0000_90_ENCERRA(); //GOTO
                return;
            }


            /*" -230- PERFORM R0900-00-DECLARA-LISTA */

            R0900_00_DECLARA_LISTA_SECTION();

            /*" -232- PERFORM R0910-00-LE-LISTA */

            R0910_00_LE_LISTA_SECTION();

            /*" -233- IF WFIM-LISTA EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_LISTA == "S")
            {

                /*" -240- GO TO R0000-90-ENCERRA. */

                R0000_90_ENCERRA(); //GOTO
                return;
            }


            /*" -243- PERFORM R1000-00-PROCESSA UNTIL WFIM-LISTA EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_LISTA == "S"))
            {

                R1000_00_PROCESSA_SECTION();
            }

            /*" -248- PERFORM R0800-00-TOTAL-GERAL */

            R0800_00_TOTAL_GERAL_SECTION();

            /*" -248- PERFORM R0700-00-ALTERA-RELATORIOS. */

            R0700_00_ALTERA_RELATORIOS_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_ENCERRA */

            R0000_90_ENCERRA();

        }

        [StopWatch]
        /*" R0000-90-ENCERRA */
        private void R0000_90_ENCERRA(bool isPerform = false)
        {
            /*" -254- CLOSE SI0042B1 */
            SI0042B1.Close();

            /*" -256- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -257- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -258- DISPLAY '***   SI0042B - FIM NORMAL ***' */
            _.Display($"***   SI0042B - FIM NORMAL ***");

            /*" -259- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -260- DISPLAY 'LIDOS      SISINACO  -  ' AC-L-LISTA */
            _.Display($"LIDOS      SISINACO  -  {AREA_DE_WORK.AC_L_LISTA}");

            /*" -262- DISPLAY 'IMPRESSOS  SI0042B1  -  ' AC-I-SI0042B1 */
            _.Display($"IMPRESSOS  SI0042B1  -  {AREA_DE_WORK.AC_I_SI0042B1}");

            /*" -262- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0500-00-LE-SISTEMAS-SECTION */
        private void R0500_00_LE_SISTEMAS_SECTION()
        {
            /*" -270- MOVE '050' TO WNR-EXEC-SQL. */
            _.Move("050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -275- PERFORM R0500_00_LE_SISTEMAS_DB_SELECT_1 */

            R0500_00_LE_SISTEMAS_DB_SELECT_1();

            /*" -278- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -279- DISPLAY 'SI0042B - PROBLEMAS NO SELECT SISTEMAS' */
                _.Display($"SI0042B - PROBLEMAS NO SELECT SISTEMAS");

                /*" -279- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0500-00-LE-SISTEMAS-DB-SELECT-1 */
        public void R0500_00_LE_SISTEMAS_DB_SELECT_1()
        {
            /*" -275- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' END-EXEC. */

            var r0500_00_LE_SISTEMAS_DB_SELECT_1_Query1 = new R0500_00_LE_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0500_00_LE_SISTEMAS_DB_SELECT_1_Query1.Execute(r0500_00_LE_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0600-00-LE-RELATORIOS-SECTION */
        private void R0600_00_LE_RELATORIOS_SECTION()
        {
            /*" -289- MOVE '060' TO WNR-EXEC-SQL. */
            _.Move("060", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -297- PERFORM R0600_00_LE_RELATORIOS_DB_SELECT_1 */

            R0600_00_LE_RELATORIOS_DB_SELECT_1();

            /*" -300- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -301- MOVE 'S' TO WFIM-RELATORI */
                _.Move("S", AREA_DE_WORK.WFIM_RELATORI);

                /*" -302- ELSE */
            }
            else
            {


                /*" -303- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -304- DISPLAY 'SI0042B - PROBLEMAS NO SELECT RELATORIOS' */
                    _.Display($"SI0042B - PROBLEMAS NO SELECT RELATORIOS");

                    /*" -304- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0600-00-LE-RELATORIOS-DB-SELECT-1 */
        public void R0600_00_LE_RELATORIOS_DB_SELECT_1()
        {
            /*" -297- EXEC SQL SELECT COD_USUARIO INTO :RELATORI-COD-USUARIO FROM SEGUROS.RELATORIOS WHERE COD_RELATORIO = 'SI0042B' AND IDE_SISTEMA = 'SI' AND DATA_SOLICITACAO = :SISTEMAS-DATA-MOV-ABERTO AND SIT_REGISTRO = '0' END-EXEC. */

            var r0600_00_LE_RELATORIOS_DB_SELECT_1_Query1 = new R0600_00_LE_RELATORIOS_DB_SELECT_1_Query1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
            };

            var executed_1 = R0600_00_LE_RELATORIOS_DB_SELECT_1_Query1.Execute(r0600_00_LE_RELATORIOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RELATORI_COD_USUARIO, RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/

        [StopWatch]
        /*" R0700-00-ALTERA-RELATORIOS-SECTION */
        private void R0700_00_ALTERA_RELATORIOS_SECTION()
        {
            /*" -314- MOVE '070' TO WNR-EXEC-SQL. */
            _.Move("070", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -321- PERFORM R0700_00_ALTERA_RELATORIOS_DB_UPDATE_1 */

            R0700_00_ALTERA_RELATORIOS_DB_UPDATE_1();

            /*" -324- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -325- DISPLAY 'SI0042B - PROBLEMAS NO UPDATE RELATORIOS' */
                _.Display($"SI0042B - PROBLEMAS NO UPDATE RELATORIOS");

                /*" -325- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0700-00-ALTERA-RELATORIOS-DB-UPDATE-1 */
        public void R0700_00_ALTERA_RELATORIOS_DB_UPDATE_1()
        {
            /*" -321- EXEC SQL UPDATE SEGUROS.RELATORIOS SET SIT_REGISTRO = '1' WHERE COD_RELATORIO = 'SI0042B' AND IDE_SISTEMA = 'SI' AND DATA_SOLICITACAO = :SISTEMAS-DATA-MOV-ABERTO AND SIT_REGISTRO = '0' END-EXEC. */

            var r0700_00_ALTERA_RELATORIOS_DB_UPDATE_1_Update1 = new R0700_00_ALTERA_RELATORIOS_DB_UPDATE_1_Update1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
            };

            R0700_00_ALTERA_RELATORIOS_DB_UPDATE_1_Update1.Execute(r0700_00_ALTERA_RELATORIOS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/

        [StopWatch]
        /*" R0800-00-TOTAL-GERAL-SECTION */
        private void R0800_00_TOTAL_GERAL_SECTION()
        {
            /*" -335- MOVE '080' TO WNR-EXEC-SQL. */
            _.Move("080", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -336- IF AC-LINHAS GREATER 55 */

            if (AREA_DE_WORK.AC_LINHAS > 55)
            {

                /*" -338- PERFORM R3000-00-CABECALHO. */

                R3000_00_CABECALHO_SECTION();
            }


            /*" -339- MOVE 'TOTAL DO ANALISTA:  ' TO LD02-LITERAL */
            _.Move("TOTAL DO ANALISTA:  ", LD02.LD02_LITERAL);

            /*" -341- MOVE AC-G-SINISTROS TO LD02-TOTAL */
            _.Move(AREA_DE_WORK.AC_G_SINISTROS, LD02.LD02_TOTAL);

            /*" -342- WRITE REG-SI0042B1 FROM LC00 */
            _.Move(LC00.GetMoveValues(), REG_SI0042B1);

            SI0042B1.Write(REG_SI0042B1.GetMoveValues().ToString());

            /*" -343- WRITE REG-SI0042B1 FROM LD02 */
            _.Move(LD02.GetMoveValues(), REG_SI0042B1);

            SI0042B1.Write(REG_SI0042B1.GetMoveValues().ToString());

            /*" -343- ADD 2 TO AC-LINHAS. */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 2;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARA-LISTA-SECTION */
        private void R0900_00_DECLARA_LISTA_SECTION()
        {
            /*" -353- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -391- PERFORM R0900_00_DECLARA_LISTA_DB_DECLARE_1 */

            R0900_00_DECLARA_LISTA_DB_DECLARE_1();

            /*" -393- PERFORM R0900_00_DECLARA_LISTA_DB_OPEN_1 */

            R0900_00_DECLARA_LISTA_DB_OPEN_1();

            /*" -396- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -398- DISPLAY 'SI0042B - PROBLEMAS NO OPEN LISTA ' ' ' SISTEMAS-DATA-MOV-ABERTO */

                $"SI0042B - PROBLEMAS NO OPEN LISTA  {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}"
                .Display();

                /*" -398- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARA-LISTA-DB-DECLARE-1 */
        public void R0900_00_DECLARA_LISTA_DB_DECLARE_1()
        {
            /*" -391- EXEC SQL DECLARE LISTA CURSOR FOR SELECT C.COD_USUARIO, A.COD_FONTE, A.NUM_PROTOCOLO_SINI, A.DAC_PROTOCOLO_SINI, A.COD_EVENTO, A.DATA_MOVTO_SINIACO, B.NATUREZA_SINISTRO, B.NOME_SEGURADO FROM SEGUROS.SI_SINISTRO_ACOMP A, SEGUROS.SI_MOVIMENTO_SINI B, SEGUROS.SI_ANALISTA_RODIZI C WHERE A.COD_FONTE = B.COD_FONTE AND A.NUM_PROTOCOLO_SINI = B.NUM_PROTOCOLO_SINI AND A.DAC_PROTOCOLO_SINI = B.DAC_PROTOCOLO_SINI AND A.COD_FONTE = C.COD_FONTE AND A.NUM_PROTOCOLO_SINI = C.NUM_PROTOCOLO_SINI AND A.DAC_PROTOCOLO_SINI = C.DAC_PROTOCOLO_SINI AND A.COD_EVENTO = 1000 AND NOT EXISTS ( SELECT E.COD_EVENTO FROM SEGUROS.SI_SINISTRO_ACOMP E WHERE E.COD_FONTE = A.COD_FONTE AND E.NUM_PROTOCOLO_SINI = A.NUM_PROTOCOLO_SINI AND E.DAC_PROTOCOLO_SINI = A.DAC_PROTOCOLO_SINI AND E.COD_EVENTO in(1001, 1200) AND A.NUM_PROTOCOLO_SINI = E.NUM_PROTOCOLO_SINI ) ORDER BY C.COD_USUARIO, A.COD_EVENTO, A.DATA_MOVTO_SINIACO, A.COD_FONTE, A.NUM_PROTOCOLO_SINI END-EXEC. */
            LISTA = new SI0042B_LISTA(false);
            string GetQuery_LISTA()
            {
                var query = @$"SELECT C.COD_USUARIO
							, 
							A.COD_FONTE
							, 
							A.NUM_PROTOCOLO_SINI
							, 
							A.DAC_PROTOCOLO_SINI
							, 
							A.COD_EVENTO
							, 
							A.DATA_MOVTO_SINIACO
							, 
							B.NATUREZA_SINISTRO
							, 
							B.NOME_SEGURADO 
							FROM SEGUROS.SI_SINISTRO_ACOMP A
							, 
							SEGUROS.SI_MOVIMENTO_SINI B
							, 
							SEGUROS.SI_ANALISTA_RODIZI C 
							WHERE A.COD_FONTE = B.COD_FONTE 
							AND A.NUM_PROTOCOLO_SINI = B.NUM_PROTOCOLO_SINI 
							AND A.DAC_PROTOCOLO_SINI = B.DAC_PROTOCOLO_SINI 
							AND A.COD_FONTE = C.COD_FONTE 
							AND A.NUM_PROTOCOLO_SINI = C.NUM_PROTOCOLO_SINI 
							AND A.DAC_PROTOCOLO_SINI = C.DAC_PROTOCOLO_SINI 
							AND A.COD_EVENTO = 1000 
							AND NOT EXISTS 
							( 
							SELECT 
							E.COD_EVENTO 
							FROM SEGUROS.SI_SINISTRO_ACOMP E 
							WHERE E.COD_FONTE = A.COD_FONTE 
							AND E.NUM_PROTOCOLO_SINI = A.NUM_PROTOCOLO_SINI 
							AND E.DAC_PROTOCOLO_SINI = A.DAC_PROTOCOLO_SINI 
							AND E.COD_EVENTO in(1001
							, 1200) 
							AND A.NUM_PROTOCOLO_SINI = E.NUM_PROTOCOLO_SINI 
							) 
							ORDER BY C.COD_USUARIO
							, 
							A.COD_EVENTO
							, 
							A.DATA_MOVTO_SINIACO
							, 
							A.COD_FONTE
							, 
							A.NUM_PROTOCOLO_SINI";

                return query;
            }
            LISTA.GetQueryEvent += GetQuery_LISTA;

        }

        [StopWatch]
        /*" R0900-00-DECLARA-LISTA-DB-OPEN-1 */
        public void R0900_00_DECLARA_LISTA_DB_OPEN_1()
        {
            /*" -393- EXEC SQL OPEN LISTA END-EXEC. */

            LISTA.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-LE-LISTA-SECTION */
        private void R0910_00_LE_LISTA_SECTION()
        {
            /*" -408- MOVE '091' TO WNR-EXEC-SQL. */
            _.Move("091", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -417- PERFORM R0910_00_LE_LISTA_DB_FETCH_1 */

            R0910_00_LE_LISTA_DB_FETCH_1();

            /*" -420- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -421- ADD 1 TO AC-L-LISTA */
                AREA_DE_WORK.AC_L_LISTA.Value = AREA_DE_WORK.AC_L_LISTA + 1;

                /*" -422- ELSE */
            }
            else
            {


                /*" -423- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -424- MOVE 'S' TO WFIM-LISTA */
                    _.Move("S", AREA_DE_WORK.WFIM_LISTA);

                    /*" -424- PERFORM R0910_00_LE_LISTA_DB_CLOSE_1 */

                    R0910_00_LE_LISTA_DB_CLOSE_1();

                    /*" -426- ELSE */
                }
                else
                {


                    /*" -428- DISPLAY 'SI0042B - PROBLEMAS NO FETCH LISTA ' ' ' SISTEMAS-DATA-MOV-ABERTO */

                    $"SI0042B - PROBLEMAS NO FETCH LISTA  {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}"
                    .Display();

                    /*" -428- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0910-00-LE-LISTA-DB-FETCH-1 */
        public void R0910_00_LE_LISTA_DB_FETCH_1()
        {
            /*" -417- EXEC SQL FETCH LISTA INTO :SIANAROD-COD-USUARIO, :SISINACO-COD-FONTE, :SISINACO-NUM-PROTOCOLO-SINI, :SISINACO-DAC-PROTOCOLO-SINI, :SISINACO-COD-EVENTO, :SISINACO-DATA-MOVTO-SINIACO, :SIMOVSIN-NATUREZA-SINISTRO, :SIMOVSIN-NOME-SEGURADO END-EXEC. */

            if (LISTA.Fetch())
            {
                _.Move(LISTA.SIANAROD_COD_USUARIO, SIANAROD.DCLSI_ANALISTA_RODIZI.SIANAROD_COD_USUARIO);
                _.Move(LISTA.SISINACO_COD_FONTE, SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_FONTE);
                _.Move(LISTA.SISINACO_NUM_PROTOCOLO_SINI, SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_PROTOCOLO_SINI);
                _.Move(LISTA.SISINACO_DAC_PROTOCOLO_SINI, SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DAC_PROTOCOLO_SINI);
                _.Move(LISTA.SISINACO_COD_EVENTO, SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_EVENTO);
                _.Move(LISTA.SISINACO_DATA_MOVTO_SINIACO, SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DATA_MOVTO_SINIACO);
                _.Move(LISTA.SIMOVSIN_NATUREZA_SINISTRO, SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_NATUREZA_SINISTRO);
                _.Move(LISTA.SIMOVSIN_NOME_SEGURADO, SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_NOME_SEGURADO);
            }

        }

        [StopWatch]
        /*" R0910-00-LE-LISTA-DB-CLOSE-1 */
        public void R0910_00_LE_LISTA_DB_CLOSE_1()
        {
            /*" -424- EXEC SQL CLOSE LISTA END-EXEC */

            LISTA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-SECTION */
        private void R1000_00_PROCESSA_SECTION()
        {
            /*" -438- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -440- MOVE 80 TO AC-LINHAS */
            _.Move(80, AREA_DE_WORK.AC_LINHAS);

            /*" -442- PERFORM R1100-00-LE-USUARIOS */

            R1100_00_LE_USUARIOS_SECTION();

            /*" -444- MOVE SIANAROD-COD-USUARIO TO WS-COD-USUARIO-ANT */
            _.Move(SIANAROD.DCLSI_ANALISTA_RODIZI.SIANAROD_COD_USUARIO, WS_COD_USUARIO_ANT);

            /*" -449- PERFORM R2000-00-PROCESSA-ANALISTA UNTIL WFIM-LISTA EQUAL 'S' OR SIANAROD-COD-USUARIO NOT EQUAL WS-COD-USUARIO-ANT */

            while (!(AREA_DE_WORK.WFIM_LISTA == "S" || SIANAROD.DCLSI_ANALISTA_RODIZI.SIANAROD_COD_USUARIO != WS_COD_USUARIO_ANT))
            {

                R2000_00_PROCESSA_ANALISTA_SECTION();
            }

            /*" -449- PERFORM R1900-00-TOTAL-ANALISTA. */

            R1900_00_TOTAL_ANALISTA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-LE-USUARIOS-SECTION */
        private void R1100_00_LE_USUARIOS_SECTION()
        {
            /*" -459- MOVE '110' TO WNR-EXEC-SQL. */
            _.Move("110", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -464- PERFORM R1100_00_LE_USUARIOS_DB_SELECT_1 */

            R1100_00_LE_USUARIOS_DB_SELECT_1();

            /*" -467- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -468- DISPLAY 'SI0042B - PROBLEMAS NO SELECT USUARIOS' */
                _.Display($"SI0042B - PROBLEMAS NO SELECT USUARIOS");

                /*" -472- DISPLAY ' ' SISINACO-COD-FONTE ' ' SISINACO-NUM-PROTOCOLO-SINI ' ' SISINACO-DAC-PROTOCOLO-SINI ' ' SIANAROD-COD-USUARIO */

                $" {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_FONTE} {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_PROTOCOLO_SINI} {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DAC_PROTOCOLO_SINI} {SIANAROD.DCLSI_ANALISTA_RODIZI.SIANAROD_COD_USUARIO}"
                .Display();

                /*" -472- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1100-00-LE-USUARIOS-DB-SELECT-1 */
        public void R1100_00_LE_USUARIOS_DB_SELECT_1()
        {
            /*" -464- EXEC SQL SELECT NOME_USUARIO INTO :USUARIOS-NOME-USUARIO FROM SEGUROS.USUARIOS WHERE COD_USUARIO = :SIANAROD-COD-USUARIO END-EXEC. */

            var r1100_00_LE_USUARIOS_DB_SELECT_1_Query1 = new R1100_00_LE_USUARIOS_DB_SELECT_1_Query1()
            {
                SIANAROD_COD_USUARIO = SIANAROD.DCLSI_ANALISTA_RODIZI.SIANAROD_COD_USUARIO.ToString(),
            };

            var executed_1 = R1100_00_LE_USUARIOS_DB_SELECT_1_Query1.Execute(r1100_00_LE_USUARIOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.USUARIOS_NOME_USUARIO, USUARIOS.DCLUSUARIOS.USUARIOS_NOME_USUARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1900-00-TOTAL-ANALISTA-SECTION */
        private void R1900_00_TOTAL_ANALISTA_SECTION()
        {
            /*" -482- MOVE '190' TO WNR-EXEC-SQL. */
            _.Move("190", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -483- IF AC-LINHAS GREATER 55 */

            if (AREA_DE_WORK.AC_LINHAS > 55)
            {

                /*" -485- PERFORM R3000-00-CABECALHO. */

                R3000_00_CABECALHO_SECTION();
            }


            /*" -486- MOVE 'TOTAL DO ANALISTA...' TO LD02-LITERAL */
            _.Move("TOTAL DO ANALISTA...", LD02.LD02_LITERAL);

            /*" -488- MOVE AC-A-SINISTROS TO LD02-TOTAL */
            _.Move(AREA_DE_WORK.AC_A_SINISTROS, LD02.LD02_TOTAL);

            /*" -489- WRITE REG-SI0042B1 FROM LC00 */
            _.Move(LC00.GetMoveValues(), REG_SI0042B1);

            SI0042B1.Write(REG_SI0042B1.GetMoveValues().ToString());

            /*" -490- WRITE REG-SI0042B1 FROM LD02 */
            _.Move(LD02.GetMoveValues(), REG_SI0042B1);

            SI0042B1.Write(REG_SI0042B1.GetMoveValues().ToString());

            /*" -492- ADD 2 TO AC-LINHAS */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 2;

            /*" -493- ADD AC-A-SINISTROS TO AC-G-SINISTROS */
            AREA_DE_WORK.AC_G_SINISTROS.Value = AREA_DE_WORK.AC_G_SINISTROS + AREA_DE_WORK.AC_A_SINISTROS;

            /*" -493- MOVE ZEROS TO AC-A-SINISTROS. */
            _.Move(0, AREA_DE_WORK.AC_A_SINISTROS);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-PROCESSA-ANALISTA-SECTION */
        private void R2000_00_PROCESSA_ANALISTA_SECTION()
        {
            /*" -503- MOVE '200' TO WNR-EXEC-SQL. */
            _.Move("200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -504- IF SISINACO-COD-EVENTO EQUAL 1000 */

            if (SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_EVENTO == 1000)
            {

                /*" -506- MOVE SISINACO-DATA-MOVTO-SINIACO TO HOST-DATA-AVISO */
                _.Move(SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DATA_MOVTO_SINIACO, HOST_DATA_AVISO);

                /*" -507- ELSE */
            }
            else
            {


                /*" -509- PERFORM R2100-00-LE-SISINACO. */

                R2100_00_LE_SISINACO_SECTION();
            }


            /*" -511- PERFORM R2200-00-LE-SIEVETIP */

            R2200_00_LE_SIEVETIP_SECTION();

            /*" -513- MOVE SISINACO-NUM-PROTOCOLO-SINI TO LD01-NUM-PROTOCOLO */
            _.Move(SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_PROTOCOLO_SINI, LD01.LD01_NUM_PROTOCOLO);

            /*" -515- MOVE SISINACO-DAC-PROTOCOLO-SINI TO LD01-DAC-PROTOCOLO */
            _.Move(SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DAC_PROTOCOLO_SINI, LD01.LD01_DAC_PROTOCOLO);

            /*" -518- MOVE SIMOVSIN-NOME-SEGURADO TO LD01-NOME-SEGURADO */
            _.Move(SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_NOME_SEGURADO, LD01.LD01_NOME_SEGURADO);

            /*" -520- IF SIMOVSIN-NATUREZA-SINISTRO EQUAL 1 */

            if (SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_NATUREZA_SINISTRO == 1)
            {

                /*" -521- MOVE 'MIP' TO LD01-TIPO-SINISTRO */
                _.Move("MIP", LD01.LD01_TIPO_SINISTRO);

                /*" -522- ELSE */
            }
            else
            {


                /*" -524- MOVE 'DFI' TO LD01-TIPO-SINISTRO. */
                _.Move("DFI", LD01.LD01_TIPO_SINISTRO);
            }


            /*" -525- MOVE HOST-DATA-AVISO TO DB2-DATA */
            _.Move(HOST_DATA_AVISO, AREA_DE_WORK.DB2_DATA);

            /*" -526- MOVE DB2-DIA TO EDIT-DIA */
            _.Move(AREA_DE_WORK.DB2_DATA.DB2_DIA, AREA_DE_WORK.EDIT_DATA.EDIT_DIA);

            /*" -527- MOVE DB2-MES TO EDIT-MES */
            _.Move(AREA_DE_WORK.DB2_DATA.DB2_MES, AREA_DE_WORK.EDIT_DATA.EDIT_MES);

            /*" -529- MOVE DB2-ANO TO EDIT-ANO */
            _.Move(AREA_DE_WORK.DB2_DATA.DB2_ANO, AREA_DE_WORK.EDIT_DATA.EDIT_ANO);

            /*" -531- MOVE EDIT-DATA TO LD01-DATA-PROTOCOLO. */
            _.Move(AREA_DE_WORK.EDIT_DATA, LD01.LD01_DATA_PROTOCOLO);

            /*" -532- IF AC-LINHAS GREATER 55 */

            if (AREA_DE_WORK.AC_LINHAS > 55)
            {

                /*" -534- PERFORM R3000-00-CABECALHO. */

                R3000_00_CABECALHO_SECTION();
            }


            /*" -535- WRITE REG-SI0042B1 FROM LD01 */
            _.Move(LD01.GetMoveValues(), REG_SI0042B1);

            SI0042B1.Write(REG_SI0042B1.GetMoveValues().ToString());

            /*" -541- ADD 1 TO AC-LINHAS AC-I-SI0042B1 AC-A-SINISTROS */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 1;
            AREA_DE_WORK.AC_I_SI0042B1.Value = AREA_DE_WORK.AC_I_SI0042B1 + 1;
            AREA_DE_WORK.AC_A_SINISTROS.Value = AREA_DE_WORK.AC_A_SINISTROS + 1;

            /*" -541- PERFORM R0910-00-LE-LISTA. */

            R0910_00_LE_LISTA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-LE-SISINACO-SECTION */
        private void R2100_00_LE_SISINACO_SECTION()
        {
            /*" -551- MOVE '210' TO WNR-EXEC-SQL. */
            _.Move("210", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -561- PERFORM R2100_00_LE_SISINACO_DB_SELECT_1 */

            R2100_00_LE_SISINACO_DB_SELECT_1();

            /*" -564- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -565- DISPLAY 'SI0042B - PROBLEMAS NO SELECT SI_SINISTRO_ACOMP' */
                _.Display($"SI0042B - PROBLEMAS NO SELECT SI_SINISTRO_ACOMP");

                /*" -568- DISPLAY ' ' SISINACO-COD-FONTE ' ' SISINACO-NUM-PROTOCOLO-SINI ' ' SISINACO-DAC-PROTOCOLO-SINI */

                $" {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_FONTE} {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_PROTOCOLO_SINI} {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DAC_PROTOCOLO_SINI}"
                .Display();

                /*" -568- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2100-00-LE-SISINACO-DB-SELECT-1 */
        public void R2100_00_LE_SISINACO_DB_SELECT_1()
        {
            /*" -561- EXEC SQL SELECT DATA_MOVTO_SINIACO INTO :HOST-DATA-AVISO FROM SEGUROS.SI_SINISTRO_ACOMP WHERE COD_FONTE = :SISINACO-COD-FONTE AND NUM_PROTOCOLO_SINI = :SISINACO-NUM-PROTOCOLO-SINI AND DAC_PROTOCOLO_SINI = :SISINACO-DAC-PROTOCOLO-SINI AND COD_EVENTO = 1000 END-EXEC. */

            var r2100_00_LE_SISINACO_DB_SELECT_1_Query1 = new R2100_00_LE_SISINACO_DB_SELECT_1_Query1()
            {
                SISINACO_NUM_PROTOCOLO_SINI = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_PROTOCOLO_SINI.ToString(),
                SISINACO_DAC_PROTOCOLO_SINI = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DAC_PROTOCOLO_SINI.ToString(),
                SISINACO_COD_FONTE = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_FONTE.ToString(),
            };

            var executed_1 = R2100_00_LE_SISINACO_DB_SELECT_1_Query1.Execute(r2100_00_LE_SISINACO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_DATA_AVISO, HOST_DATA_AVISO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-LE-SIEVETIP-SECTION */
        private void R2200_00_LE_SIEVETIP_SECTION()
        {
            /*" -578- MOVE '220' TO WNR-EXEC-SQL. */
            _.Move("220", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -583- PERFORM R2200_00_LE_SIEVETIP_DB_SELECT_1 */

            R2200_00_LE_SIEVETIP_DB_SELECT_1();

            /*" -586- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -587- DISPLAY 'SI0042B - PROBLEMAS NO SELECT SI_EVENTO_TIPO' */
                _.Display($"SI0042B - PROBLEMAS NO SELECT SI_EVENTO_TIPO");

                /*" -591- DISPLAY ' ' SISINACO-COD-FONTE ' ' SISINACO-NUM-PROTOCOLO-SINI ' ' SISINACO-DAC-PROTOCOLO-SINI ' ' SISINACO-COD-EVENTO */

                $" {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_FONTE} {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_PROTOCOLO_SINI} {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DAC_PROTOCOLO_SINI} {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_EVENTO}"
                .Display();

                /*" -591- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2200-00-LE-SIEVETIP-DB-SELECT-1 */
        public void R2200_00_LE_SIEVETIP_DB_SELECT_1()
        {
            /*" -583- EXEC SQL SELECT DESCR_EVENTO INTO :SIEVETIP-DESCR-EVENTO FROM SEGUROS.SI_EVENTO_TIPO WHERE COD_EVENTO = :SISINACO-COD-EVENTO END-EXEC. */

            var r2200_00_LE_SIEVETIP_DB_SELECT_1_Query1 = new R2200_00_LE_SIEVETIP_DB_SELECT_1_Query1()
            {
                SISINACO_COD_EVENTO = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_EVENTO.ToString(),
            };

            var executed_1 = R2200_00_LE_SIEVETIP_DB_SELECT_1_Query1.Execute(r2200_00_LE_SIEVETIP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SIEVETIP_DESCR_EVENTO, SIEVETIP.DCLSI_EVENTO_TIPO.SIEVETIP_DESCR_EVENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-CABECALHO-SECTION */
        private void R3000_00_CABECALHO_SECTION()
        {
            /*" -601- MOVE '300' TO WNR-EXEC-SQL. */
            _.Move("300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -602- ADD 1 TO AC-PAGINAS */
            AREA_DE_WORK.AC_PAGINAS.Value = AREA_DE_WORK.AC_PAGINAS + 1;

            /*" -604- MOVE AC-PAGINAS TO LC01-PAGINA */
            _.Move(AREA_DE_WORK.AC_PAGINAS, LC01.LC01_PAGINA);

            /*" -606- MOVE SISTEMAS-DATA-MOV-ABERTO TO DB2-DATA */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREA_DE_WORK.DB2_DATA);

            /*" -607- MOVE DB2-DIA TO EDIT-DIA */
            _.Move(AREA_DE_WORK.DB2_DATA.DB2_DIA, AREA_DE_WORK.EDIT_DATA.EDIT_DIA);

            /*" -608- MOVE DB2-MES TO EDIT-MES */
            _.Move(AREA_DE_WORK.DB2_DATA.DB2_MES, AREA_DE_WORK.EDIT_DATA.EDIT_MES);

            /*" -609- MOVE DB2-ANO TO EDIT-ANO */
            _.Move(AREA_DE_WORK.DB2_DATA.DB2_ANO, AREA_DE_WORK.EDIT_DATA.EDIT_ANO);

            /*" -612- MOVE EDIT-DATA TO LC02-DATA LC02-DATA-MOV-ABERTO */
            _.Move(AREA_DE_WORK.EDIT_DATA, LC02.LC02_DATA, LC02.LC02_DATA_MOV_ABERTO);

            /*" -613- ACCEPT ACC-HORA FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.ACC_HORA);

            /*" -614- MOVE ACC-HH TO EDIT-HH */
            _.Move(AREA_DE_WORK.ACC_HORA.ACC_HH, AREA_DE_WORK.EDIT_HORA.EDIT_HH);

            /*" -615- MOVE ACC-MM TO EDIT-MM */
            _.Move(AREA_DE_WORK.ACC_HORA.ACC_MM, AREA_DE_WORK.EDIT_HORA.EDIT_MM);

            /*" -616- MOVE ACC-SS TO EDIT-SS */
            _.Move(AREA_DE_WORK.ACC_HORA.ACC_SS, AREA_DE_WORK.EDIT_HORA.EDIT_SS);

            /*" -618- MOVE EDIT-HORA TO LC03-HORA */
            _.Move(AREA_DE_WORK.EDIT_HORA, LC03.LC03_HORA);

            /*" -621- MOVE USUARIOS-NOME-USUARIO TO LC05-ANALISTA */
            _.Move(USUARIOS.DCLUSUARIOS.USUARIOS_NOME_USUARIO, LC05.LC05_ANALISTA);

            /*" -622- WRITE REG-SI0042B1 FROM LC01 */
            _.Move(LC01.GetMoveValues(), REG_SI0042B1);

            SI0042B1.Write(REG_SI0042B1.GetMoveValues().ToString());

            /*" -623- WRITE REG-SI0042B1 FROM LC02 */
            _.Move(LC02.GetMoveValues(), REG_SI0042B1);

            SI0042B1.Write(REG_SI0042B1.GetMoveValues().ToString());

            /*" -624- WRITE REG-SI0042B1 FROM LC03 */
            _.Move(LC03.GetMoveValues(), REG_SI0042B1);

            SI0042B1.Write(REG_SI0042B1.GetMoveValues().ToString());

            /*" -625- WRITE REG-SI0042B1 FROM LC00 */
            _.Move(LC00.GetMoveValues(), REG_SI0042B1);

            SI0042B1.Write(REG_SI0042B1.GetMoveValues().ToString());

            /*" -626- WRITE REG-SI0042B1 FROM LC04 */
            _.Move(LC04.GetMoveValues(), REG_SI0042B1);

            SI0042B1.Write(REG_SI0042B1.GetMoveValues().ToString());

            /*" -627- WRITE REG-SI0042B1 FROM LC05 */
            _.Move(LC05.GetMoveValues(), REG_SI0042B1);

            SI0042B1.Write(REG_SI0042B1.GetMoveValues().ToString());

            /*" -628- WRITE REG-SI0042B1 FROM LC04 */
            _.Move(LC04.GetMoveValues(), REG_SI0042B1);

            SI0042B1.Write(REG_SI0042B1.GetMoveValues().ToString());

            /*" -629- WRITE REG-SI0042B1 FROM LC06 */
            _.Move(LC06.GetMoveValues(), REG_SI0042B1);

            SI0042B1.Write(REG_SI0042B1.GetMoveValues().ToString());

            /*" -630- WRITE REG-SI0042B1 FROM LC04 */
            _.Move(LC04.GetMoveValues(), REG_SI0042B1);

            SI0042B1.Write(REG_SI0042B1.GetMoveValues().ToString());

            /*" -632- WRITE REG-SI0042B1 FROM LC00 */
            _.Move(LC00.GetMoveValues(), REG_SI0042B1);

            SI0042B1.Write(REG_SI0042B1.GetMoveValues().ToString());

            /*" -632- MOVE 10 TO AC-LINHAS. */
            _.Move(10, AREA_DE_WORK.AC_LINHAS);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -642- CLOSE SI0042B1 */
            SI0042B1.Close();

            /*" -643- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -645- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -647- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -647- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -650- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -651- DISPLAY '***   SI0042B - CANCELADO  ***' */
            _.Display($"***   SI0042B - CANCELADO  ***");

            /*" -653- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -653- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}