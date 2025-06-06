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
using Sias.Sinistro.DB2.SI0032B;

namespace Code
{
    public class SI0032B
    {
        public bool IsCall { get; set; }

        public SI0032B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-------------------------------------                                  */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................ SINISTRO HABITACIONAL               *      */
        /*"      *   SUBROTINA............... SI0032B                             *      */
        /*"      *   ANALISTA ............... PRODEXTER                           *      */
        /*"      *   PROGRAMADOR ............ PRODEXTER                           *      */
        /*"      *   DATA CODIFICACAO ....... ABR / 2003                          *      */
        /*"      *   FUNCAO ................. RELACAO DE DESEMPENHO POR ANALISTA  *      */
        /*"      *                            PENDENCIAS                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 11/07/08 - BRSEG - CAD.12115 - SAC.237                         *      */
        /*"      *            ELIMINAR CARACTERES ESPECIAIS DE CONTROLE DE IMPRES-*      */
        /*"      *            SAO NOS ARQUIVOS.   -   PROCURE: BR.V01             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        /*"      *-------------------------------------                                  */
        #endregion


        #region VARIABLES

        public FileBasis _SI0032B1 { get; set; } = new FileBasis(new PIC("X", "200", "X(200)"));

        public FileBasis SI0032B1
        {
            get
            {
                _.Move(REG_SI0032B1, _SI0032B1); VarBasis.RedefinePassValue(REG_SI0032B1, _SI0032B1, REG_SI0032B1); return _SI0032B1;
            }
        }
        /*"01          REG-SI0032B1         PIC  X(200).*/
        public StringBasis REG_SI0032B1 { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01          HOST-DATA-AVISO      PIC  X(010)   VALUE   SPACES.*/
        public StringBasis HOST_DATA_AVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01          WS-COD-USUARIO-ANT   PIC  X(008)   VALUE   SPACES.*/
        public StringBasis WS_COD_USUARIO_ANT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"01          AREA-DE-WORK.*/
        public SI0032B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SI0032B_AREA_DE_WORK();
        public class SI0032B_AREA_DE_WORK : VarBasis
        {
            /*"  05        AC-L-LISTA           PIC  9(006)   VALUE   ZEROS.*/
            public IntBasis AC_L_LISTA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05        AC-I-SI0032B1        PIC  9(006)   VALUE   ZEROS.*/
            public IntBasis AC_I_SI0032B1 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
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
            public SI0032B_DB2_DATA DB2_DATA { get; set; } = new SI0032B_DB2_DATA();
            public class SI0032B_DB2_DATA : VarBasis
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
            public SI0032B_EDIT_DATA EDIT_DATA { get; set; } = new SI0032B_EDIT_DATA();
            public class SI0032B_EDIT_DATA : VarBasis
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
            public SI0032B_ACC_HORA ACC_HORA { get; set; } = new SI0032B_ACC_HORA();
            public class SI0032B_ACC_HORA : VarBasis
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
            public SI0032B_EDIT_HORA EDIT_HORA { get; set; } = new SI0032B_EDIT_HORA();
            public class SI0032B_EDIT_HORA : VarBasis
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
            public SI0032B_WABEND WABEND { get; set; } = new SI0032B_WABEND();
            public class SI0032B_WABEND : VarBasis
            {
                /*"    10      FILLER               PIC  X(010) VALUE           ' SI0032B'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SI0032B");
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
        public SI0032B_LC00 LC00 { get; set; } = new SI0032B_LC00();
        public class SI0032B_LC00 : VarBasis
        {
            /*"  05        LC00-CANAL           PIC  X(001) VALUE ' '.*/
            public StringBasis LC00_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"  05        FILLER               PIC  X(189) VALUE SPACES.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "189", "X(189)"), @"");
            /*"01          LC01.*/
        }
        public SI0032B_LC01 LC01 { get; set; } = new SI0032B_LC01();
        public class SI0032B_LC01 : VarBasis
        {
            /*"  05        LC01-CANAL           PIC  X(001) VALUE '1'.*/
            public StringBasis LC01_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
            /*"  05        FILLER               PIC  X(075) VALUE 'SI0032B'.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "75", "X(075)"), @"SI0032B");
            /*"  05        FILLER               PIC  X(036) VALUE                          'RELATORIO DE DESEMPENHO POR ANALISTA'*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"RELATORIO DE DESEMPENHO POR ANALISTA");
            /*"  05        FILLER               PIC  X(061) VALUE SPACES.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "61", "X(061)"), @"");
            /*"  05        FILLER               PIC  X(013) VALUE 'PAGINA'.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"PAGINA");
            /*"  05        LC01-PAGINA          PIC  ZZZ9.*/
            public IntBasis LC01_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
            /*"01          LC02.*/
        }
        public SI0032B_LC02 LC02 { get; set; } = new SI0032B_LC02();
        public class SI0032B_LC02 : VarBasis
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
        public SI0032B_LC03 LC03 { get; set; } = new SI0032B_LC03();
        public class SI0032B_LC03 : VarBasis
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
        public SI0032B_LC04 LC04 { get; set; } = new SI0032B_LC04();
        public class SI0032B_LC04 : VarBasis
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
        public SI0032B_LC05 LC05 { get; set; } = new SI0032B_LC05();
        public class SI0032B_LC05 : VarBasis
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
        public SI0032B_LC06 LC06 { get; set; } = new SI0032B_LC06();
        public class SI0032B_LC06 : VarBasis
        {
            /*"  05        LC06-CANAL           PIC  X(001) VALUE ' '.*/
            public StringBasis LC06_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"  05        FILLER               PIC  X(009) VALUE SPACES.*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
            /*"  05        FILLER               PIC  X(017) VALUE 'PROTOCOLO'.*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"PROTOCOLO");
            /*"  05        FILLER               PIC  X(020) VALUE                                                  'SINISTRO IRB'*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"SINISTRO IRB");
            /*"  05        FILLER               PIC  X(048) VALUE                                              'NOME DO SEGURADO'*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"NOME DO SEGURADO");
            /*"  05        FILLER               PIC  X(012) VALUE 'TIPO'.*/
            public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"TIPO");
            /*"  05        FILLER               PIC  X(021) VALUE                                              'DATA AVISO'.*/
            public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"DATA AVISO");
            /*"  05        FILLER               PIC  X(044) VALUE                                              'ULTIMO STATUS'.*/
            public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "44", "X(044)"), @"ULTIMO STATUS");
            /*"  05        FILLER               PIC  X(015) VALUE                                              'DATA STATUS'.*/
            public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"DATA STATUS");
            /*"01          LD01.*/
        }
        public SI0032B_LD01 LD01 { get; set; } = new SI0032B_LD01();
        public class SI0032B_LD01 : VarBasis
        {
            /*"  05        LD01-CANAL           PIC  X(001) VALUE ' '.*/
            public StringBasis LD01_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"  05        FILLER               PIC  X(006) VALUE SPACES.*/
            public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
            /*"  05        LD01-COD-FONTE       PIC  Z99.*/
            public IntBasis LD01_COD_FONTE { get; set; } = new IntBasis(new PIC("9", "3", "Z99."));
            /*"  05        FILLER               PIC  X(001) VALUE SPACES.*/
            public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05        LD01-NUM-PROTOCOLO   PIC  999999999.*/
            public IntBasis LD01_NUM_PROTOCOLO { get; set; } = new IntBasis(new PIC("9", "9", "999999999."));
            /*"  05        FILLER               PIC  X(001) VALUE '-'.*/
            public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"  05        LD01-DAC-PROTOCOLO   PIC  9.*/
            public IntBasis LD01_DAC_PROTOCOLO { get; set; } = new IntBasis(new PIC("9", "1", "9."));
            /*"  05        FILLER               PIC  X(006) VALUE SPACES.*/
            public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
            /*"  05        LD01-NUM-IRB         PIC  ZZZZZZZZZZ9.*/
            public IntBasis LD01_NUM_IRB { get; set; } = new IntBasis(new PIC("9", "11", "ZZZZZZZZZZ9."));
            /*"  05        FILLER               PIC  X(008) VALUE SPACES.*/
            public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"  05        LD01-NOME-SEGURADO   PIC  X(040) VALUE SPACES.*/
            public StringBasis LD01_NOME_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"  05        FILLER               PIC  X(008) VALUE SPACES.*/
            public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"  05        LD01-TIPO-SINISTRO   PIC  X(003) VALUE SPACES.*/
            public StringBasis LD01_TIPO_SINISTRO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05        FILLER               PIC  X(009) VALUE SPACES.*/
            public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
            /*"  05        LD01-DATA-AVISO      PIC  X(010) VALUE SPACES.*/
            public StringBasis LD01_DATA_AVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05        FILLER               PIC  X(011) VALUE SPACES.*/
            public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"");
            /*"  05        LD01-DESCR-EVENTO    PIC  X(040) VALUE SPACES.*/
            public StringBasis LD01_DESCR_EVENTO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"  05        FILLER               PIC  X(005) VALUE SPACES.*/
            public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
            /*"  05        LD01-DATA-EVENTO     PIC  X(010) VALUE SPACES.*/
            public StringBasis LD01_DATA_EVENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05        FILLER               PIC  X(007) VALUE SPACES.*/
            public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
            /*"01          LD02.*/
        }
        public SI0032B_LD02 LD02 { get; set; } = new SI0032B_LD02();
        public class SI0032B_LD02 : VarBasis
        {
            /*"  05        LD02-CANAL           PIC  X(001) VALUE ' '.*/
            public StringBasis LD02_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"  05        FILLER               PIC  X(089) VALUE SPACES.*/
            public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "89", "X(089)"), @"");
            /*"  05        LD02-LITERAL         PIC  X(020) VALUE SPACES.*/
            public StringBasis LD02_LITERAL { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
            /*"  05        FILLER               PIC  X(001) VALUE SPACES.*/
            public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05        LD02-TOTAL           PIC  ZZZZZ9.*/
            public IntBasis LD02_TOTAL { get; set; } = new IntBasis(new PIC("9", "6", "ZZZZZ9."));
            /*"  05        FILLER               PIC  X(073) VALUE SPACES.*/
            public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "73", "X(073)"), @"");
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
        public SI0032B_LISTA LISTA { get; set; } = new SI0032B_LISTA();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SI0032B1_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SI0032B1.SetFile(SI0032B1_FILE_NAME_P);

                /*" -215- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -215- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -216- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -217- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -217- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -225- OPEN OUTPUT SI0032B1 */
            SI0032B1.Open(REG_SI0032B1);

            /*" -227- PERFORM R0500-00-LE-SISTEMAS */

            R0500_00_LE_SISTEMAS_SECTION();

            /*" -229- PERFORM R0600-00-LE-RELATORIOS */

            R0600_00_LE_RELATORIOS_SECTION();

            /*" -230- IF WFIM-RELATORI EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_RELATORI == "S")
            {

                /*" -231- DISPLAY '******************************************' */
                _.Display($"******************************************");

                /*" -232- DISPLAY '* NAO HOUVE SOLICITACAO PARA O RELATORIO *' */
                _.Display($"* NAO HOUVE SOLICITACAO PARA O RELATORIO *");

                /*" -233- DISPLAY '******************************************' */
                _.Display($"******************************************");

                /*" -234- DISPLAY ' ' */
                _.Display($" ");

                /*" -236- GO TO R0000-90-ENCERRA. */

                R0000_90_ENCERRA(); //GOTO
                return;
            }


            /*" -237- PERFORM R0900-00-DECLARA-LISTA */

            R0900_00_DECLARA_LISTA_SECTION();

            /*" -239- PERFORM R0910-00-LE-LISTA */

            R0910_00_LE_LISTA_SECTION();

            /*" -240- IF WFIM-LISTA EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_LISTA == "S")
            {

                /*" -247- GO TO R0000-90-ENCERRA. */

                R0000_90_ENCERRA(); //GOTO
                return;
            }


            /*" -250- PERFORM R1000-00-PROCESSA UNTIL WFIM-LISTA EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_LISTA == "S"))
            {

                R1000_00_PROCESSA_SECTION();
            }

            /*" -255- PERFORM R0800-00-TOTAL-GERAL */

            R0800_00_TOTAL_GERAL_SECTION();

            /*" -255- PERFORM R0700-00-ALTERA-RELATORIOS. */

            R0700_00_ALTERA_RELATORIOS_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_ENCERRA */

            R0000_90_ENCERRA();

        }

        [StopWatch]
        /*" R0000-90-ENCERRA */
        private void R0000_90_ENCERRA(bool isPerform = false)
        {
            /*" -261- CLOSE SI0032B1 */
            SI0032B1.Close();

            /*" -263- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -264- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -265- DISPLAY '***   SI0032B - FIM NORMAL ***' */
            _.Display($"***   SI0032B - FIM NORMAL ***");

            /*" -266- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -267- DISPLAY 'LIDOS      SISINACO  -  ' AC-L-LISTA */
            _.Display($"LIDOS      SISINACO  -  {AREA_DE_WORK.AC_L_LISTA}");

            /*" -269- DISPLAY 'IMPRESSOS  SI0032B1  -  ' AC-I-SI0032B1 */
            _.Display($"IMPRESSOS  SI0032B1  -  {AREA_DE_WORK.AC_I_SI0032B1}");

            /*" -269- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0500-00-LE-SISTEMAS-SECTION */
        private void R0500_00_LE_SISTEMAS_SECTION()
        {
            /*" -277- MOVE '050' TO WNR-EXEC-SQL. */
            _.Move("050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -282- PERFORM R0500_00_LE_SISTEMAS_DB_SELECT_1 */

            R0500_00_LE_SISTEMAS_DB_SELECT_1();

            /*" -285- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -286- DISPLAY 'SI0032B - PROBLEMAS NO SELECT SISTEMAS' */
                _.Display($"SI0032B - PROBLEMAS NO SELECT SISTEMAS");

                /*" -286- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0500-00-LE-SISTEMAS-DB-SELECT-1 */
        public void R0500_00_LE_SISTEMAS_DB_SELECT_1()
        {
            /*" -282- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' END-EXEC. */

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
            /*" -296- MOVE '060' TO WNR-EXEC-SQL. */
            _.Move("060", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -304- PERFORM R0600_00_LE_RELATORIOS_DB_SELECT_1 */

            R0600_00_LE_RELATORIOS_DB_SELECT_1();

            /*" -307- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -308- MOVE 'S' TO WFIM-RELATORI */
                _.Move("S", AREA_DE_WORK.WFIM_RELATORI);

                /*" -309- ELSE */
            }
            else
            {


                /*" -310- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -311- DISPLAY 'SI0032B - PROBLEMAS NO SELECT RELATORIOS' */
                    _.Display($"SI0032B - PROBLEMAS NO SELECT RELATORIOS");

                    /*" -311- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0600-00-LE-RELATORIOS-DB-SELECT-1 */
        public void R0600_00_LE_RELATORIOS_DB_SELECT_1()
        {
            /*" -304- EXEC SQL SELECT COD_USUARIO INTO :RELATORI-COD-USUARIO FROM SEGUROS.RELATORIOS WHERE COD_RELATORIO = 'SI0032B' AND IDE_SISTEMA = 'SI' AND DATA_SOLICITACAO = :SISTEMAS-DATA-MOV-ABERTO AND SIT_REGISTRO = '0' END-EXEC. */

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
            /*" -321- MOVE '070' TO WNR-EXEC-SQL. */
            _.Move("070", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -328- PERFORM R0700_00_ALTERA_RELATORIOS_DB_UPDATE_1 */

            R0700_00_ALTERA_RELATORIOS_DB_UPDATE_1();

            /*" -331- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -332- DISPLAY 'SI0032B - PROBLEMAS NO UPDATE RELATORIOS' */
                _.Display($"SI0032B - PROBLEMAS NO UPDATE RELATORIOS");

                /*" -332- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0700-00-ALTERA-RELATORIOS-DB-UPDATE-1 */
        public void R0700_00_ALTERA_RELATORIOS_DB_UPDATE_1()
        {
            /*" -328- EXEC SQL UPDATE SEGUROS.RELATORIOS SET SIT_REGISTRO = '1' WHERE COD_RELATORIO = 'SI0032B' AND IDE_SISTEMA = 'SI' AND DATA_SOLICITACAO = :SISTEMAS-DATA-MOV-ABERTO AND SIT_REGISTRO = '0' END-EXEC. */

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
            /*" -342- MOVE '080' TO WNR-EXEC-SQL. */
            _.Move("080", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -343- IF AC-LINHAS GREATER 55 */

            if (AREA_DE_WORK.AC_LINHAS > 55)
            {

                /*" -345- PERFORM R3000-00-CABECALHO. */

                R3000_00_CABECALHO_SECTION();
            }


            /*" -346- MOVE 'TOTAL GERAL.........' TO LD02-LITERAL */
            _.Move("TOTAL GERAL.........", LD02.LD02_LITERAL);

            /*" -348- MOVE AC-G-SINISTROS TO LD02-TOTAL */
            _.Move(AREA_DE_WORK.AC_G_SINISTROS, LD02.LD02_TOTAL);

            /*" -349- WRITE REG-SI0032B1 FROM LC00 */
            _.Move(LC00.GetMoveValues(), REG_SI0032B1);

            SI0032B1.Write(REG_SI0032B1.GetMoveValues().ToString());

            /*" -350- WRITE REG-SI0032B1 FROM LD02 */
            _.Move(LD02.GetMoveValues(), REG_SI0032B1);

            SI0032B1.Write(REG_SI0032B1.GetMoveValues().ToString());

            /*" -350- ADD 2 TO AC-LINHAS. */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 2;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARA-LISTA-SECTION */
        private void R0900_00_DECLARA_LISTA_SECTION()
        {
            /*" -360- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -425- PERFORM R0900_00_DECLARA_LISTA_DB_DECLARE_1 */

            R0900_00_DECLARA_LISTA_DB_DECLARE_1();

            /*" -427- PERFORM R0900_00_DECLARA_LISTA_DB_OPEN_1 */

            R0900_00_DECLARA_LISTA_DB_OPEN_1();

            /*" -430- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -432- DISPLAY 'SI0032B - PROBLEMAS NO OPEN LISTA ' ' ' SISTEMAS-DATA-MOV-ABERTO */

                $"SI0032B - PROBLEMAS NO OPEN LISTA  {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}"
                .Display();

                /*" -432- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARA-LISTA-DB-DECLARE-1 */
        public void R0900_00_DECLARA_LISTA_DB_DECLARE_1()
        {
            /*" -425- EXEC SQL DECLARE LISTA CURSOR FOR SELECT C.COD_USUARIO, A.COD_FONTE, A.NUM_PROTOCOLO_SINI, A.DAC_PROTOCOLO_SINI, A.COD_EVENTO, A.DATA_MOVTO_SINIACO, B.NATUREZA_SINISTRO, B.NOME_SEGURADO, D.NUM_IRB FROM SEGUROS.SI_SINISTRO_ACOMP A, SEGUROS.SI_MOVIMENTO_SINI B, SEGUROS.SI_ANALISTA_RODIZI C, SEGUROS.SINISTRO_MESTRE D, SEGUROS.SI_SINISTRO_FASE F WHERE A.COD_FONTE = B.COD_FONTE AND A.NUM_PROTOCOLO_SINI = B.NUM_PROTOCOLO_SINI AND A.DAC_PROTOCOLO_SINI = B.DAC_PROTOCOLO_SINI AND A.COD_FONTE = C.COD_FONTE AND A.NUM_PROTOCOLO_SINI = C.NUM_PROTOCOLO_SINI AND A.DAC_PROTOCOLO_SINI = C.DAC_PROTOCOLO_SINI AND A.COD_FONTE = D.COD_FONTE AND A.NUM_PROTOCOLO_SINI = D.NUM_PROTOCOLO_SINI AND A.DAC_PROTOCOLO_SINI = D.DAC_PROTOCOLO_SINI AND A.COD_FONTE = F.COD_FONTE AND A.NUM_PROTOCOLO_SINI = F.NUM_PROTOCOLO_SINI AND A.DAC_PROTOCOLO_SINI = F.DAC_PROTOCOLO_SINI AND (A.COD_EVENTO IN (1007, 1008, 1202, 1011, 1015, 1019, 1004, 1013, 1021, 1023, 1025, 1197, 1198, 1199, 2001, 1195, 2014, 2023, 2024, 2025, 2026, 2027, 2028, 2029, 2030, 2031, 2032, 2033, 2034, 2035, 2036, 2037, 2038, 2039, 2040, 2041, 2042, 2043, 2044, 2045, 2046, 2047, 2048, 2049, 2002, 2054, 2064) OR (A.COD_EVENTO IN (1000, 1001) AND B.NATUREZA_SINISTRO = 1)) AND A.NUM_OCORR_SINIACO = (SELECT MAX(E.NUM_OCORR_SINIACO) FROM SEGUROS.SI_SINISTRO_ACOMP E WHERE E.COD_FONTE = A.COD_FONTE AND E.NUM_PROTOCOLO_SINI = A.NUM_PROTOCOLO_SINI AND E.DAC_PROTOCOLO_SINI = A.DAC_PROTOCOLO_SINI AND A.DATA_MOVTO_SINIACO <= :SISTEMAS-DATA-MOV-ABERTO) AND F.COD_FASE IN (1, 2) AND F.NUM_OCORR_SINIACO = (SELECT MAX(G.NUM_OCORR_SINIACO) FROM SEGUROS.SI_SINISTRO_FASE G WHERE G.COD_FONTE = F.COD_FONTE AND G.NUM_PROTOCOLO_SINI = F.NUM_PROTOCOLO_SINI AND G.DAC_PROTOCOLO_SINI = F.DAC_PROTOCOLO_SINI) ORDER BY C.COD_USUARIO, A.COD_EVENTO, A.DATA_MOVTO_SINIACO, A.COD_FONTE, A.NUM_PROTOCOLO_SINI END-EXEC. */
            LISTA = new SI0032B_LISTA(true);
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
							, 
							D.NUM_IRB 
							FROM SEGUROS.SI_SINISTRO_ACOMP A
							, 
							SEGUROS.SI_MOVIMENTO_SINI B
							, 
							SEGUROS.SI_ANALISTA_RODIZI C
							, 
							SEGUROS.SINISTRO_MESTRE D
							, 
							SEGUROS.SI_SINISTRO_FASE F 
							WHERE A.COD_FONTE = B.COD_FONTE 
							AND A.NUM_PROTOCOLO_SINI = B.NUM_PROTOCOLO_SINI 
							AND A.DAC_PROTOCOLO_SINI = B.DAC_PROTOCOLO_SINI 
							AND A.COD_FONTE = C.COD_FONTE 
							AND A.NUM_PROTOCOLO_SINI = C.NUM_PROTOCOLO_SINI 
							AND A.DAC_PROTOCOLO_SINI = C.DAC_PROTOCOLO_SINI 
							AND A.COD_FONTE = D.COD_FONTE 
							AND A.NUM_PROTOCOLO_SINI = D.NUM_PROTOCOLO_SINI 
							AND A.DAC_PROTOCOLO_SINI = D.DAC_PROTOCOLO_SINI 
							AND A.COD_FONTE = F.COD_FONTE 
							AND A.NUM_PROTOCOLO_SINI = F.NUM_PROTOCOLO_SINI 
							AND A.DAC_PROTOCOLO_SINI = F.DAC_PROTOCOLO_SINI 
							AND (A.COD_EVENTO IN (1007
							, 1008
							, 1202
							, 
							1011
							, 1015
							, 1019
							, 
							1004
							, 1013
							, 1021
							, 
							1023
							, 1025
							, 1197
							, 
							1198
							, 1199
							, 2001
							, 
							1195
							, 2014
							, 2023
							, 
							2024
							, 2025
							, 2026
							, 
							2027
							, 2028
							, 2029
							, 
							2030
							, 2031
							, 2032
							, 
							2033
							, 2034
							, 2035
							, 
							2036
							, 2037
							, 2038
							, 
							2039
							, 2040
							, 2041
							, 
							2042
							, 2043
							, 2044
							, 
							2045
							, 2046
							, 2047
							, 
							2048
							, 2049
							, 2002
							, 
							2054
							, 2064) 
							OR (A.COD_EVENTO IN (1000
							, 1001) 
							AND B.NATUREZA_SINISTRO = 1)) 
							AND A.NUM_OCORR_SINIACO = 
							(SELECT MAX(E.NUM_OCORR_SINIACO) 
							FROM SEGUROS.SI_SINISTRO_ACOMP E 
							WHERE E.COD_FONTE = A.COD_FONTE 
							AND E.NUM_PROTOCOLO_SINI = A.NUM_PROTOCOLO_SINI 
							AND E.DAC_PROTOCOLO_SINI = A.DAC_PROTOCOLO_SINI 
							AND A.DATA_MOVTO_SINIACO <= 
							'{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}') 
							AND F.COD_FASE IN (1
							, 2) 
							AND F.NUM_OCORR_SINIACO = 
							(SELECT MAX(G.NUM_OCORR_SINIACO) 
							FROM SEGUROS.SI_SINISTRO_FASE G 
							WHERE G.COD_FONTE = F.COD_FONTE 
							AND G.NUM_PROTOCOLO_SINI = F.NUM_PROTOCOLO_SINI 
							AND G.DAC_PROTOCOLO_SINI = F.DAC_PROTOCOLO_SINI) 
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
            /*" -427- EXEC SQL OPEN LISTA END-EXEC. */

            LISTA.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-LE-LISTA-SECTION */
        private void R0910_00_LE_LISTA_SECTION()
        {
            /*" -442- MOVE '091' TO WNR-EXEC-SQL. */
            _.Move("091", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -452- PERFORM R0910_00_LE_LISTA_DB_FETCH_1 */

            R0910_00_LE_LISTA_DB_FETCH_1();

            /*" -455- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -456- ADD 1 TO AC-L-LISTA */
                AREA_DE_WORK.AC_L_LISTA.Value = AREA_DE_WORK.AC_L_LISTA + 1;

                /*" -457- ELSE */
            }
            else
            {


                /*" -458- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -459- MOVE 'S' TO WFIM-LISTA */
                    _.Move("S", AREA_DE_WORK.WFIM_LISTA);

                    /*" -459- PERFORM R0910_00_LE_LISTA_DB_CLOSE_1 */

                    R0910_00_LE_LISTA_DB_CLOSE_1();

                    /*" -461- ELSE */
                }
                else
                {


                    /*" -463- DISPLAY 'SI0032B - PROBLEMAS NO FETCH LISTA ' ' ' SISTEMAS-DATA-MOV-ABERTO */

                    $"SI0032B - PROBLEMAS NO FETCH LISTA  {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}"
                    .Display();

                    /*" -463- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0910-00-LE-LISTA-DB-FETCH-1 */
        public void R0910_00_LE_LISTA_DB_FETCH_1()
        {
            /*" -452- EXEC SQL FETCH LISTA INTO :SIANAROD-COD-USUARIO, :SISINACO-COD-FONTE, :SISINACO-NUM-PROTOCOLO-SINI, :SISINACO-DAC-PROTOCOLO-SINI, :SISINACO-COD-EVENTO, :SISINACO-DATA-MOVTO-SINIACO, :SIMOVSIN-NATUREZA-SINISTRO, :SIMOVSIN-NOME-SEGURADO, :SINISMES-NUM-IRB END-EXEC. */

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
                _.Move(LISTA.SINISMES_NUM_IRB, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_IRB);
            }

        }

        [StopWatch]
        /*" R0910-00-LE-LISTA-DB-CLOSE-1 */
        public void R0910_00_LE_LISTA_DB_CLOSE_1()
        {
            /*" -459- EXEC SQL CLOSE LISTA END-EXEC */

            LISTA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-SECTION */
        private void R1000_00_PROCESSA_SECTION()
        {
            /*" -473- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -475- MOVE 80 TO AC-LINHAS */
            _.Move(80, AREA_DE_WORK.AC_LINHAS);

            /*" -477- PERFORM R1100-00-LE-USUARIOS */

            R1100_00_LE_USUARIOS_SECTION();

            /*" -479- MOVE SIANAROD-COD-USUARIO TO WS-COD-USUARIO-ANT */
            _.Move(SIANAROD.DCLSI_ANALISTA_RODIZI.SIANAROD_COD_USUARIO, WS_COD_USUARIO_ANT);

            /*" -484- PERFORM R2000-00-PROCESSA-ANALISTA UNTIL WFIM-LISTA EQUAL 'S' OR SIANAROD-COD-USUARIO NOT EQUAL WS-COD-USUARIO-ANT */

            while (!(AREA_DE_WORK.WFIM_LISTA == "S" || SIANAROD.DCLSI_ANALISTA_RODIZI.SIANAROD_COD_USUARIO != WS_COD_USUARIO_ANT))
            {

                R2000_00_PROCESSA_ANALISTA_SECTION();
            }

            /*" -484- PERFORM R1900-00-TOTAL-ANALISTA. */

            R1900_00_TOTAL_ANALISTA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-LE-USUARIOS-SECTION */
        private void R1100_00_LE_USUARIOS_SECTION()
        {
            /*" -494- MOVE '110' TO WNR-EXEC-SQL. */
            _.Move("110", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -499- PERFORM R1100_00_LE_USUARIOS_DB_SELECT_1 */

            R1100_00_LE_USUARIOS_DB_SELECT_1();

            /*" -502- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -503- DISPLAY 'SI0032B - PROBLEMAS NO SELECT USUARIOS' */
                _.Display($"SI0032B - PROBLEMAS NO SELECT USUARIOS");

                /*" -507- DISPLAY ' ' SISINACO-COD-FONTE ' ' SISINACO-NUM-PROTOCOLO-SINI ' ' SISINACO-DAC-PROTOCOLO-SINI ' ' SIANAROD-COD-USUARIO */

                $" {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_FONTE} {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_PROTOCOLO_SINI} {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DAC_PROTOCOLO_SINI} {SIANAROD.DCLSI_ANALISTA_RODIZI.SIANAROD_COD_USUARIO}"
                .Display();

                /*" -507- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1100-00-LE-USUARIOS-DB-SELECT-1 */
        public void R1100_00_LE_USUARIOS_DB_SELECT_1()
        {
            /*" -499- EXEC SQL SELECT NOME_USUARIO INTO :USUARIOS-NOME-USUARIO FROM SEGUROS.USUARIOS WHERE COD_USUARIO = :SIANAROD-COD-USUARIO END-EXEC. */

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
            /*" -517- MOVE '190' TO WNR-EXEC-SQL. */
            _.Move("190", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -518- IF AC-LINHAS GREATER 55 */

            if (AREA_DE_WORK.AC_LINHAS > 55)
            {

                /*" -520- PERFORM R3000-00-CABECALHO. */

                R3000_00_CABECALHO_SECTION();
            }


            /*" -521- MOVE 'TOTAL DO ANALISTA...' TO LD02-LITERAL */
            _.Move("TOTAL DO ANALISTA...", LD02.LD02_LITERAL);

            /*" -523- MOVE AC-A-SINISTROS TO LD02-TOTAL */
            _.Move(AREA_DE_WORK.AC_A_SINISTROS, LD02.LD02_TOTAL);

            /*" -524- WRITE REG-SI0032B1 FROM LC00 */
            _.Move(LC00.GetMoveValues(), REG_SI0032B1);

            SI0032B1.Write(REG_SI0032B1.GetMoveValues().ToString());

            /*" -525- WRITE REG-SI0032B1 FROM LD02 */
            _.Move(LD02.GetMoveValues(), REG_SI0032B1);

            SI0032B1.Write(REG_SI0032B1.GetMoveValues().ToString());

            /*" -527- ADD 2 TO AC-LINHAS */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 2;

            /*" -528- ADD AC-A-SINISTROS TO AC-G-SINISTROS */
            AREA_DE_WORK.AC_G_SINISTROS.Value = AREA_DE_WORK.AC_G_SINISTROS + AREA_DE_WORK.AC_A_SINISTROS;

            /*" -528- MOVE ZEROS TO AC-A-SINISTROS. */
            _.Move(0, AREA_DE_WORK.AC_A_SINISTROS);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-PROCESSA-ANALISTA-SECTION */
        private void R2000_00_PROCESSA_ANALISTA_SECTION()
        {
            /*" -538- MOVE '200' TO WNR-EXEC-SQL. */
            _.Move("200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -539- IF SISINACO-COD-EVENTO EQUAL 1001 */

            if (SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_EVENTO == 1001)
            {

                /*" -541- MOVE SISINACO-DATA-MOVTO-SINIACO TO HOST-DATA-AVISO */
                _.Move(SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DATA_MOVTO_SINIACO, HOST_DATA_AVISO);

                /*" -542- ELSE */
            }
            else
            {


                /*" -544- PERFORM R2100-00-LE-SISINACO. */

                R2100_00_LE_SISINACO_SECTION();
            }


            /*" -546- PERFORM R2200-00-LE-SIEVETIP */

            R2200_00_LE_SIEVETIP_SECTION();

            /*" -547- MOVE SISINACO-COD-FONTE TO LD01-COD-FONTE */
            _.Move(SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_FONTE, LD01.LD01_COD_FONTE);

            /*" -549- MOVE SISINACO-NUM-PROTOCOLO-SINI TO LD01-NUM-PROTOCOLO */
            _.Move(SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_PROTOCOLO_SINI, LD01.LD01_NUM_PROTOCOLO);

            /*" -551- MOVE SISINACO-DAC-PROTOCOLO-SINI TO LD01-DAC-PROTOCOLO */
            _.Move(SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DAC_PROTOCOLO_SINI, LD01.LD01_DAC_PROTOCOLO);

            /*" -552- MOVE SINISMES-NUM-IRB TO LD01-NUM-IRB */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_IRB, LD01.LD01_NUM_IRB);

            /*" -555- MOVE SIMOVSIN-NOME-SEGURADO TO LD01-NOME-SEGURADO */
            _.Move(SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_NOME_SEGURADO, LD01.LD01_NOME_SEGURADO);

            /*" -557- IF SIMOVSIN-NATUREZA-SINISTRO EQUAL 1 */

            if (SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_NATUREZA_SINISTRO == 1)
            {

                /*" -558- MOVE 'MIP' TO LD01-TIPO-SINISTRO */
                _.Move("MIP", LD01.LD01_TIPO_SINISTRO);

                /*" -559- ELSE */
            }
            else
            {


                /*" -561- MOVE 'DFI' TO LD01-TIPO-SINISTRO. */
                _.Move("DFI", LD01.LD01_TIPO_SINISTRO);
            }


            /*" -562- MOVE HOST-DATA-AVISO TO DB2-DATA */
            _.Move(HOST_DATA_AVISO, AREA_DE_WORK.DB2_DATA);

            /*" -563- MOVE DB2-DIA TO EDIT-DIA */
            _.Move(AREA_DE_WORK.DB2_DATA.DB2_DIA, AREA_DE_WORK.EDIT_DATA.EDIT_DIA);

            /*" -564- MOVE DB2-MES TO EDIT-MES */
            _.Move(AREA_DE_WORK.DB2_DATA.DB2_MES, AREA_DE_WORK.EDIT_DATA.EDIT_MES);

            /*" -565- MOVE DB2-ANO TO EDIT-ANO */
            _.Move(AREA_DE_WORK.DB2_DATA.DB2_ANO, AREA_DE_WORK.EDIT_DATA.EDIT_ANO);

            /*" -567- MOVE EDIT-DATA TO LD01-DATA-AVISO */
            _.Move(AREA_DE_WORK.EDIT_DATA, LD01.LD01_DATA_AVISO);

            /*" -570- MOVE SIEVETIP-DESCR-EVENTO TO LD01-DESCR-EVENTO */
            _.Move(SIEVETIP.DCLSI_EVENTO_TIPO.SIEVETIP_DESCR_EVENTO, LD01.LD01_DESCR_EVENTO);

            /*" -572- MOVE SISINACO-DATA-MOVTO-SINIACO TO DB2-DATA */
            _.Move(SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DATA_MOVTO_SINIACO, AREA_DE_WORK.DB2_DATA);

            /*" -573- MOVE DB2-DIA TO EDIT-DIA */
            _.Move(AREA_DE_WORK.DB2_DATA.DB2_DIA, AREA_DE_WORK.EDIT_DATA.EDIT_DIA);

            /*" -574- MOVE DB2-MES TO EDIT-MES */
            _.Move(AREA_DE_WORK.DB2_DATA.DB2_MES, AREA_DE_WORK.EDIT_DATA.EDIT_MES);

            /*" -575- MOVE DB2-ANO TO EDIT-ANO */
            _.Move(AREA_DE_WORK.DB2_DATA.DB2_ANO, AREA_DE_WORK.EDIT_DATA.EDIT_ANO);

            /*" -577- MOVE EDIT-DATA TO LD01-DATA-EVENTO */
            _.Move(AREA_DE_WORK.EDIT_DATA, LD01.LD01_DATA_EVENTO);

            /*" -578- IF AC-LINHAS GREATER 55 */

            if (AREA_DE_WORK.AC_LINHAS > 55)
            {

                /*" -580- PERFORM R3000-00-CABECALHO. */

                R3000_00_CABECALHO_SECTION();
            }


            /*" -581- WRITE REG-SI0032B1 FROM LD01 */
            _.Move(LD01.GetMoveValues(), REG_SI0032B1);

            SI0032B1.Write(REG_SI0032B1.GetMoveValues().ToString());

            /*" -587- ADD 1 TO AC-LINHAS AC-I-SI0032B1 AC-A-SINISTROS */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 1;
            AREA_DE_WORK.AC_I_SI0032B1.Value = AREA_DE_WORK.AC_I_SI0032B1 + 1;
            AREA_DE_WORK.AC_A_SINISTROS.Value = AREA_DE_WORK.AC_A_SINISTROS + 1;

            /*" -587- PERFORM R0910-00-LE-LISTA. */

            R0910_00_LE_LISTA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-LE-SISINACO-SECTION */
        private void R2100_00_LE_SISINACO_SECTION()
        {
            /*" -597- MOVE '210' TO WNR-EXEC-SQL. */
            _.Move("210", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -607- PERFORM R2100_00_LE_SISINACO_DB_SELECT_1 */

            R2100_00_LE_SISINACO_DB_SELECT_1();

            /*" -610- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -611- DISPLAY 'SI0032B - PROBLEMAS NO SELECT SI_SINISTRO_ACOMP' */
                _.Display($"SI0032B - PROBLEMAS NO SELECT SI_SINISTRO_ACOMP");

                /*" -614- DISPLAY ' ' SISINACO-COD-FONTE ' ' SISINACO-NUM-PROTOCOLO-SINI ' ' SISINACO-DAC-PROTOCOLO-SINI */

                $" {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_FONTE} {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_PROTOCOLO_SINI} {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DAC_PROTOCOLO_SINI}"
                .Display();

                /*" -614- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2100-00-LE-SISINACO-DB-SELECT-1 */
        public void R2100_00_LE_SISINACO_DB_SELECT_1()
        {
            /*" -607- EXEC SQL SELECT DATA_MOVTO_SINIACO INTO :HOST-DATA-AVISO FROM SEGUROS.SI_SINISTRO_ACOMP WHERE COD_FONTE = :SISINACO-COD-FONTE AND NUM_PROTOCOLO_SINI = :SISINACO-NUM-PROTOCOLO-SINI AND DAC_PROTOCOLO_SINI = :SISINACO-DAC-PROTOCOLO-SINI AND COD_EVENTO = 1001 END-EXEC. */

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
            /*" -624- MOVE '220' TO WNR-EXEC-SQL. */
            _.Move("220", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -629- PERFORM R2200_00_LE_SIEVETIP_DB_SELECT_1 */

            R2200_00_LE_SIEVETIP_DB_SELECT_1();

            /*" -632- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -633- DISPLAY 'SI0032B - PROBLEMAS NO SELECT SI_EVENTO_TIPO' */
                _.Display($"SI0032B - PROBLEMAS NO SELECT SI_EVENTO_TIPO");

                /*" -637- DISPLAY ' ' SISINACO-COD-FONTE ' ' SISINACO-NUM-PROTOCOLO-SINI ' ' SISINACO-DAC-PROTOCOLO-SINI ' ' SISINACO-COD-EVENTO */

                $" {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_FONTE} {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_PROTOCOLO_SINI} {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DAC_PROTOCOLO_SINI} {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_EVENTO}"
                .Display();

                /*" -637- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2200-00-LE-SIEVETIP-DB-SELECT-1 */
        public void R2200_00_LE_SIEVETIP_DB_SELECT_1()
        {
            /*" -629- EXEC SQL SELECT DESCR_EVENTO INTO :SIEVETIP-DESCR-EVENTO FROM SEGUROS.SI_EVENTO_TIPO WHERE COD_EVENTO = :SISINACO-COD-EVENTO END-EXEC. */

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
            /*" -647- MOVE '300' TO WNR-EXEC-SQL. */
            _.Move("300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -648- ADD 1 TO AC-PAGINAS */
            AREA_DE_WORK.AC_PAGINAS.Value = AREA_DE_WORK.AC_PAGINAS + 1;

            /*" -650- MOVE AC-PAGINAS TO LC01-PAGINA */
            _.Move(AREA_DE_WORK.AC_PAGINAS, LC01.LC01_PAGINA);

            /*" -652- MOVE SISTEMAS-DATA-MOV-ABERTO TO DB2-DATA */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREA_DE_WORK.DB2_DATA);

            /*" -653- MOVE DB2-DIA TO EDIT-DIA */
            _.Move(AREA_DE_WORK.DB2_DATA.DB2_DIA, AREA_DE_WORK.EDIT_DATA.EDIT_DIA);

            /*" -654- MOVE DB2-MES TO EDIT-MES */
            _.Move(AREA_DE_WORK.DB2_DATA.DB2_MES, AREA_DE_WORK.EDIT_DATA.EDIT_MES);

            /*" -655- MOVE DB2-ANO TO EDIT-ANO */
            _.Move(AREA_DE_WORK.DB2_DATA.DB2_ANO, AREA_DE_WORK.EDIT_DATA.EDIT_ANO);

            /*" -658- MOVE EDIT-DATA TO LC02-DATA LC02-DATA-MOV-ABERTO */
            _.Move(AREA_DE_WORK.EDIT_DATA, LC02.LC02_DATA, LC02.LC02_DATA_MOV_ABERTO);

            /*" -659- ACCEPT ACC-HORA FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.ACC_HORA);

            /*" -660- MOVE ACC-HH TO EDIT-HH */
            _.Move(AREA_DE_WORK.ACC_HORA.ACC_HH, AREA_DE_WORK.EDIT_HORA.EDIT_HH);

            /*" -661- MOVE ACC-MM TO EDIT-MM */
            _.Move(AREA_DE_WORK.ACC_HORA.ACC_MM, AREA_DE_WORK.EDIT_HORA.EDIT_MM);

            /*" -662- MOVE ACC-SS TO EDIT-SS */
            _.Move(AREA_DE_WORK.ACC_HORA.ACC_SS, AREA_DE_WORK.EDIT_HORA.EDIT_SS);

            /*" -664- MOVE EDIT-HORA TO LC03-HORA */
            _.Move(AREA_DE_WORK.EDIT_HORA, LC03.LC03_HORA);

            /*" -667- MOVE USUARIOS-NOME-USUARIO TO LC05-ANALISTA */
            _.Move(USUARIOS.DCLUSUARIOS.USUARIOS_NOME_USUARIO, LC05.LC05_ANALISTA);

            /*" -668- WRITE REG-SI0032B1 FROM LC01 */
            _.Move(LC01.GetMoveValues(), REG_SI0032B1);

            SI0032B1.Write(REG_SI0032B1.GetMoveValues().ToString());

            /*" -669- WRITE REG-SI0032B1 FROM LC02 */
            _.Move(LC02.GetMoveValues(), REG_SI0032B1);

            SI0032B1.Write(REG_SI0032B1.GetMoveValues().ToString());

            /*" -670- WRITE REG-SI0032B1 FROM LC03 */
            _.Move(LC03.GetMoveValues(), REG_SI0032B1);

            SI0032B1.Write(REG_SI0032B1.GetMoveValues().ToString());

            /*" -671- WRITE REG-SI0032B1 FROM LC00 */
            _.Move(LC00.GetMoveValues(), REG_SI0032B1);

            SI0032B1.Write(REG_SI0032B1.GetMoveValues().ToString());

            /*" -672- WRITE REG-SI0032B1 FROM LC04 */
            _.Move(LC04.GetMoveValues(), REG_SI0032B1);

            SI0032B1.Write(REG_SI0032B1.GetMoveValues().ToString());

            /*" -673- WRITE REG-SI0032B1 FROM LC05 */
            _.Move(LC05.GetMoveValues(), REG_SI0032B1);

            SI0032B1.Write(REG_SI0032B1.GetMoveValues().ToString());

            /*" -674- WRITE REG-SI0032B1 FROM LC04 */
            _.Move(LC04.GetMoveValues(), REG_SI0032B1);

            SI0032B1.Write(REG_SI0032B1.GetMoveValues().ToString());

            /*" -675- WRITE REG-SI0032B1 FROM LC06 */
            _.Move(LC06.GetMoveValues(), REG_SI0032B1);

            SI0032B1.Write(REG_SI0032B1.GetMoveValues().ToString());

            /*" -676- WRITE REG-SI0032B1 FROM LC04 */
            _.Move(LC04.GetMoveValues(), REG_SI0032B1);

            SI0032B1.Write(REG_SI0032B1.GetMoveValues().ToString());

            /*" -678- WRITE REG-SI0032B1 FROM LC00 */
            _.Move(LC00.GetMoveValues(), REG_SI0032B1);

            SI0032B1.Write(REG_SI0032B1.GetMoveValues().ToString());

            /*" -678- MOVE 10 TO AC-LINHAS. */
            _.Move(10, AREA_DE_WORK.AC_LINHAS);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -688- CLOSE SI0032B1 */
            SI0032B1.Close();

            /*" -689- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -691- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -693- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -693- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -696- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -697- DISPLAY '***   SI0032B - CANCELADO  ***' */
            _.Display($"***   SI0032B - CANCELADO  ***");

            /*" -699- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -699- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}