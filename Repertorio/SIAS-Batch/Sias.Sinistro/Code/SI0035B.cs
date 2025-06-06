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
using Sias.Sinistro.DB2.SI0035B;

namespace Code
{
    public class SI0035B
    {
        public bool IsCall { get; set; }

        public SI0035B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-------------------------------------                                  */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................ SINISTRO HABITACIONAL               *      */
        /*"      *   SUBROTINA............... SI0035B                             *      */
        /*"      *   ANALISTA ............... PRODEXTER                           *      */
        /*"      *   PROGRAMADOR ............ PRODEXTER                           *      */
        /*"      *   DATA CODIFICACAO ....... ABR / 2003                          *      */
        /*"      *   FUNCAO ................. RELACAO DE PENDENCIA NA PRESTADORA  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 11/07/08 - BRSEG - CAD.12115 - SAC.237                         *      */
        /*"      *            ELIMINAR CARACTERES ESPECIAIS DE CONTROLE DE IMPRES-*      */
        /*"      *            SAO NOS ARQUIVOS.   -   PROCURE: BR.V01             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        /*"      *-------------------------------------                                  */
        #endregion


        #region VARIABLES

        public FileBasis _SI0035B1 { get; set; } = new FileBasis(new PIC("X", "200", "X(200)"));

        public FileBasis SI0035B1
        {
            get
            {
                _.Move(REG_SI0035B1, _SI0035B1); VarBasis.RedefinePassValue(REG_SI0035B1, _SI0035B1, REG_SI0035B1); return _SI0035B1;
            }
        }
        /*"01          REG-SI0035B1         PIC  X(200).*/
        public StringBasis REG_SI0035B1 { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01          HOST-COUNT           PIC S9(004)   VALUE +0 COMP.*/
        public IntBasis HOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          HOST-DATA-AVISO      PIC  X(010)   VALUE   SPACES.*/
        public StringBasis HOST_DATA_AVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01          WS-COD-USUARIO-ANT   PIC  X(008)   VALUE   SPACES.*/
        public StringBasis WS_COD_USUARIO_ANT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"01          WS-COD-DESTINATARIO-ANT                                 PIC S9(004)   VALUE +0 COMP.*/
        public IntBasis WS_COD_DESTINATARIO_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          AREA-DE-WORK.*/
        public SI0035B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SI0035B_AREA_DE_WORK();
        public class SI0035B_AREA_DE_WORK : VarBasis
        {
            /*"  05        AC-L-LISTA           PIC  9(006)   VALUE   ZEROS.*/
            public IntBasis AC_L_LISTA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05        AC-I-SI0035B1        PIC  9(006)   VALUE   ZEROS.*/
            public IntBasis AC_I_SI0035B1 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05        AC-P-SINISTROS       PIC  9(006)   VALUE   ZEROS.*/
            public IntBasis AC_P_SINISTROS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
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
            public SI0035B_DB2_DATA DB2_DATA { get; set; } = new SI0035B_DB2_DATA();
            public class SI0035B_DB2_DATA : VarBasis
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
            public SI0035B_EDIT_DATA EDIT_DATA { get; set; } = new SI0035B_EDIT_DATA();
            public class SI0035B_EDIT_DATA : VarBasis
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
            public SI0035B_ACC_HORA ACC_HORA { get; set; } = new SI0035B_ACC_HORA();
            public class SI0035B_ACC_HORA : VarBasis
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
            public SI0035B_EDIT_HORA EDIT_HORA { get; set; } = new SI0035B_EDIT_HORA();
            public class SI0035B_EDIT_HORA : VarBasis
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
            public SI0035B_WABEND WABEND { get; set; } = new SI0035B_WABEND();
            public class SI0035B_WABEND : VarBasis
            {
                /*"    10      FILLER               PIC  X(010) VALUE           ' SI0035B'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SI0035B");
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
        public SI0035B_LC00 LC00 { get; set; } = new SI0035B_LC00();
        public class SI0035B_LC00 : VarBasis
        {
            /*"  05        LC00-CANAL           PIC  X(001) VALUE ' '.*/
            public StringBasis LC00_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"  05        FILLER               PIC  X(189) VALUE SPACES.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "189", "X(189)"), @"");
            /*"01          LC01.*/
        }
        public SI0035B_LC01 LC01 { get; set; } = new SI0035B_LC01();
        public class SI0035B_LC01 : VarBasis
        {
            /*"  05        LC01-CANAL           PIC  X(001) VALUE '1'.*/
            public StringBasis LC01_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
            /*"  05        FILLER               PIC  X(075) VALUE 'SI0035B'.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "75", "X(075)"), @"SI0035B");
            /*"  05        FILLER               PIC  X(036) VALUE                          'RELATORIO DE PENDENCIAS POR ANALISTA'*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"RELATORIO DE PENDENCIAS POR ANALISTA");
            /*"  05        FILLER               PIC  X(061) VALUE SPACES.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "61", "X(061)"), @"");
            /*"  05        FILLER               PIC  X(013) VALUE 'PAGINA'.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"PAGINA");
            /*"  05        LC01-PAGINA          PIC  ZZZ9.*/
            public IntBasis LC01_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
            /*"01          LC02.*/
        }
        public SI0035B_LC02 LC02 { get; set; } = new SI0035B_LC02();
        public class SI0035B_LC02 : VarBasis
        {
            /*"  05        LC02-CANAL           PIC  X(001) VALUE ' '.*/
            public StringBasis LC02_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"  05        FILLER               PIC  X(074) VALUE SPACES.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "74", "X(074)"), @"");
            /*"  05        FILLER               PIC  X(027) VALUE                                   'PENDENTE NA PRESTADORA ATE '*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "27", "X(027)"), @"PENDENTE NA PRESTADORA ATE ");
            /*"  05        LC02-DATA-MOV-ABERTO PIC  X(010) VALUE SPACES.*/
            public StringBasis LC02_DATA_MOV_ABERTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05        FILLER               PIC  X(061) VALUE SPACES.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "61", "X(061)"), @"");
            /*"  05        FILLER               PIC  X(007) VALUE 'DATA'.*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"DATA");
            /*"  05        LC02-DATA            PIC  X(010) VALUE SPACES.*/
            public StringBasis LC02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"01          LC03.*/
        }
        public SI0035B_LC03 LC03 { get; set; } = new SI0035B_LC03();
        public class SI0035B_LC03 : VarBasis
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
        public SI0035B_LC04 LC04 { get; set; } = new SI0035B_LC04();
        public class SI0035B_LC04 : VarBasis
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
        public SI0035B_LC05 LC05 { get; set; } = new SI0035B_LC05();
        public class SI0035B_LC05 : VarBasis
        {
            /*"  05        LC05-CANAL           PIC  X(001) VALUE ' '.*/
            public StringBasis LC05_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"  05        FILLER               PIC  X(012) VALUE ' ANALISTA :'*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @" ANALISTA :");
            /*"  05        LC05-ANALISTA        PIC  X(040) VALUE SPACES.*/
            public StringBasis LC05_ANALISTA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"  05        FILLER               PIC  X(138) VALUE SPACES.*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "138", "X(138)"), @"");
            /*"01          LC06.*/
        }
        public SI0035B_LC06 LC06 { get; set; } = new SI0035B_LC06();
        public class SI0035B_LC06 : VarBasis
        {
            /*"  05        LC06-CANAL           PIC  X(001) VALUE ' '.*/
            public StringBasis LC06_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"  05        FILLER               PIC  X(012) VALUE ' PRESTADOR:'*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @" PRESTADOR:");
            /*"  05        LC06-PRESTADOR       PIC  X(040) VALUE SPACES.*/
            public StringBasis LC06_PRESTADOR { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"  05        FILLER               PIC  X(138) VALUE SPACES.*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "138", "X(138)"), @"");
            /*"01          LC07.*/
        }
        public SI0035B_LC07 LC07 { get; set; } = new SI0035B_LC07();
        public class SI0035B_LC07 : VarBasis
        {
            /*"  05        LC07-CANAL           PIC  X(001) VALUE ' '.*/
            public StringBasis LC07_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"  05        FILLER               PIC  X(009) VALUE SPACES.*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
            /*"  05        FILLER               PIC  X(017) VALUE 'PROTOCOLO'.*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"PROTOCOLO");
            /*"  05        FILLER               PIC  X(020) VALUE                                                  'SINISTRO IRB'*/
            public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"SINISTRO IRB");
            /*"  05        FILLER               PIC  X(048) VALUE                                              'NOME DO SEGURADO'*/
            public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"NOME DO SEGURADO");
            /*"  05        FILLER               PIC  X(012) VALUE 'TIPO'.*/
            public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"TIPO");
            /*"  05        FILLER               PIC  X(021) VALUE                                              'DATA AVISO'.*/
            public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"DATA AVISO");
            /*"  05        FILLER               PIC  X(044) VALUE                                              'ULTIMO STATUS'.*/
            public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "44", "X(044)"), @"ULTIMO STATUS");
            /*"  05        FILLER               PIC  X(015) VALUE                                              'DATA STATUS'.*/
            public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"DATA STATUS");
            /*"01          LD01.*/
        }
        public SI0035B_LD01 LD01 { get; set; } = new SI0035B_LD01();
        public class SI0035B_LD01 : VarBasis
        {
            /*"  05        LD01-CANAL           PIC  X(001) VALUE ' '.*/
            public StringBasis LD01_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"  05        FILLER               PIC  X(006) VALUE SPACES.*/
            public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
            /*"  05        LD01-COD-FONTE       PIC  Z99.*/
            public IntBasis LD01_COD_FONTE { get; set; } = new IntBasis(new PIC("9", "3", "Z99."));
            /*"  05        FILLER               PIC  X(001) VALUE SPACES.*/
            public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05        LD01-NUM-PROTOCOLO   PIC  999999999.*/
            public IntBasis LD01_NUM_PROTOCOLO { get; set; } = new IntBasis(new PIC("9", "9", "999999999."));
            /*"  05        FILLER               PIC  X(001) VALUE '-'.*/
            public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"  05        LD01-DAC-PROTOCOLO   PIC  9.*/
            public IntBasis LD01_DAC_PROTOCOLO { get; set; } = new IntBasis(new PIC("9", "1", "9."));
            /*"  05        FILLER               PIC  X(006) VALUE SPACES.*/
            public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
            /*"  05        LD01-NUM-IRB         PIC  ZZZZZZZZZZ9.*/
            public IntBasis LD01_NUM_IRB { get; set; } = new IntBasis(new PIC("9", "11", "ZZZZZZZZZZ9."));
            /*"  05        FILLER               PIC  X(008) VALUE SPACES.*/
            public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"  05        LD01-NOME-SEGURADO   PIC  X(040) VALUE SPACES.*/
            public StringBasis LD01_NOME_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"  05        FILLER               PIC  X(008) VALUE SPACES.*/
            public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"  05        LD01-TIPO-SINISTRO   PIC  X(003) VALUE SPACES.*/
            public StringBasis LD01_TIPO_SINISTRO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05        FILLER               PIC  X(009) VALUE SPACES.*/
            public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
            /*"  05        LD01-DATA-AVISO      PIC  X(010) VALUE SPACES.*/
            public StringBasis LD01_DATA_AVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05        FILLER               PIC  X(011) VALUE SPACES.*/
            public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"");
            /*"  05        LD01-DESCR-EVENTO    PIC  X(040) VALUE SPACES.*/
            public StringBasis LD01_DESCR_EVENTO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"  05        FILLER               PIC  X(005) VALUE SPACES.*/
            public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
            /*"  05        LD01-DATA-EVENTO     PIC  X(010) VALUE SPACES.*/
            public StringBasis LD01_DATA_EVENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05        FILLER               PIC  X(007) VALUE SPACES.*/
            public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
            /*"01          LD02.*/
        }
        public SI0035B_LD02 LD02 { get; set; } = new SI0035B_LD02();
        public class SI0035B_LD02 : VarBasis
        {
            /*"  05        LD02-CANAL           PIC  X(001) VALUE ' '.*/
            public StringBasis LD02_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"  05        FILLER               PIC  X(089) VALUE SPACES.*/
            public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "89", "X(089)"), @"");
            /*"  05        LD02-LITERAL         PIC  X(020) VALUE SPACES.*/
            public StringBasis LD02_LITERAL { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
            /*"  05        FILLER               PIC  X(001) VALUE SPACES.*/
            public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05        LD02-TOTAL           PIC  ZZZZZ9.*/
            public IntBasis LD02_TOTAL { get; set; } = new IntBasis(new PIC("9", "6", "ZZZZZ9."));
            /*"  05        FILLER               PIC  X(073) VALUE SPACES.*/
            public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "73", "X(073)"), @"");
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.SISINACO SISINACO { get; set; } = new Dclgens.SISINACO();
        public Dclgens.SISINFAS SISINFAS { get; set; } = new Dclgens.SISINFAS();
        public Dclgens.SIDOCACO SIDOCACO { get; set; } = new Dclgens.SIDOCACO();
        public Dclgens.SIDOCPAR SIDOCPAR { get; set; } = new Dclgens.SIDOCPAR();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.SIMOVSIN SIMOVSIN { get; set; } = new Dclgens.SIMOVSIN();
        public Dclgens.SIANAROD SIANAROD { get; set; } = new Dclgens.SIANAROD();
        public Dclgens.SIEVETIP SIEVETIP { get; set; } = new Dclgens.SIEVETIP();
        public Dclgens.USUARIOS USUARIOS { get; set; } = new Dclgens.USUARIOS();
        public Dclgens.GERECADE GERECADE { get; set; } = new Dclgens.GERECADE();
        public Dclgens.GEDESTIN GEDESTIN { get; set; } = new Dclgens.GEDESTIN();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.CALENDAR CALENDAR { get; set; } = new Dclgens.CALENDAR();
        public SI0035B_LISTA LISTA { get; set; } = new SI0035B_LISTA();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SI0035B1_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SI0035B1.SetFile(SI0035B1_FILE_NAME_P);

                /*" -229- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -229- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -230- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -231- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -231- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -239- OPEN OUTPUT SI0035B1 */
            SI0035B1.Open(REG_SI0035B1);

            /*" -241- PERFORM R0500-00-LE-SISTEMAS */

            R0500_00_LE_SISTEMAS_SECTION();

            /*" -243- PERFORM R0600-00-LE-RELATORIOS */

            R0600_00_LE_RELATORIOS_SECTION();

            /*" -244- IF WFIM-RELATORI EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_RELATORI == "S")
            {

                /*" -245- DISPLAY '******************************************' */
                _.Display($"******************************************");

                /*" -246- DISPLAY '* NAO HOUVE SOLICITACAO PARA O RELATORIO *' */
                _.Display($"* NAO HOUVE SOLICITACAO PARA O RELATORIO *");

                /*" -247- DISPLAY '******************************************' */
                _.Display($"******************************************");

                /*" -248- DISPLAY ' ' */
                _.Display($" ");

                /*" -250- GO TO R0000-90-ENCERRA. */

                R0000_90_ENCERRA(); //GOTO
                return;
            }


            /*" -251- PERFORM R0900-00-DECLARA-LISTA */

            R0900_00_DECLARA_LISTA_SECTION();

            /*" -253- PERFORM R0910-00-LE-LISTA */

            R0910_00_LE_LISTA_SECTION();

            /*" -254- IF WFIM-LISTA EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_LISTA == "S")
            {

                /*" -261- GO TO R0000-90-ENCERRA. */

                R0000_90_ENCERRA(); //GOTO
                return;
            }


            /*" -264- PERFORM R1000-00-PROCESSA UNTIL WFIM-LISTA EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_LISTA == "S"))
            {

                R1000_00_PROCESSA_SECTION();
            }

            /*" -265- IF AC-G-SINISTROS NOT EQUAL ZEROS */

            if (AREA_DE_WORK.AC_G_SINISTROS != 00)
            {

                /*" -270- PERFORM R0800-00-TOTAL-GERAL. */

                R0800_00_TOTAL_GERAL_SECTION();
            }


            /*" -270- PERFORM R0700-00-ALTERA-RELATORIOS. */

            R0700_00_ALTERA_RELATORIOS_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_ENCERRA */

            R0000_90_ENCERRA();

        }

        [StopWatch]
        /*" R0000-90-ENCERRA */
        private void R0000_90_ENCERRA(bool isPerform = false)
        {
            /*" -276- CLOSE SI0035B1 */
            SI0035B1.Close();

            /*" -278- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -279- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -280- DISPLAY '***   SI0035B - FIM NORMAL ***' */
            _.Display($"***   SI0035B - FIM NORMAL ***");

            /*" -281- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -282- DISPLAY 'LIDOS      SIDOCACO  -  ' AC-L-LISTA */
            _.Display($"LIDOS      SIDOCACO  -  {AREA_DE_WORK.AC_L_LISTA}");

            /*" -284- DISPLAY 'IMPRESSOS  SI0035B1  -  ' AC-I-SI0035B1 */
            _.Display($"IMPRESSOS  SI0035B1  -  {AREA_DE_WORK.AC_I_SI0035B1}");

            /*" -284- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0500-00-LE-SISTEMAS-SECTION */
        private void R0500_00_LE_SISTEMAS_SECTION()
        {
            /*" -292- MOVE '050' TO WNR-EXEC-SQL. */
            _.Move("050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -297- PERFORM R0500_00_LE_SISTEMAS_DB_SELECT_1 */

            R0500_00_LE_SISTEMAS_DB_SELECT_1();

            /*" -300- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -301- DISPLAY 'SI0035B - PROBLEMAS NO SELECT SISTEMAS' */
                _.Display($"SI0035B - PROBLEMAS NO SELECT SISTEMAS");

                /*" -301- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0500-00-LE-SISTEMAS-DB-SELECT-1 */
        public void R0500_00_LE_SISTEMAS_DB_SELECT_1()
        {
            /*" -297- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' END-EXEC. */

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
            /*" -311- MOVE '060' TO WNR-EXEC-SQL. */
            _.Move("060", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -319- PERFORM R0600_00_LE_RELATORIOS_DB_SELECT_1 */

            R0600_00_LE_RELATORIOS_DB_SELECT_1();

            /*" -322- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -323- MOVE 'S' TO WFIM-RELATORI */
                _.Move("S", AREA_DE_WORK.WFIM_RELATORI);

                /*" -324- ELSE */
            }
            else
            {


                /*" -325- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -326- DISPLAY 'SI0035B - PROBLEMAS NO SELECT RELATORIOS' */
                    _.Display($"SI0035B - PROBLEMAS NO SELECT RELATORIOS");

                    /*" -326- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0600-00-LE-RELATORIOS-DB-SELECT-1 */
        public void R0600_00_LE_RELATORIOS_DB_SELECT_1()
        {
            /*" -319- EXEC SQL SELECT COD_USUARIO INTO :RELATORI-COD-USUARIO FROM SEGUROS.RELATORIOS WHERE COD_RELATORIO = 'SI0035B' AND IDE_SISTEMA = 'SI' AND DATA_SOLICITACAO = :SISTEMAS-DATA-MOV-ABERTO AND SIT_REGISTRO = '0' END-EXEC. */

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
            /*" -336- MOVE '070' TO WNR-EXEC-SQL. */
            _.Move("070", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -343- PERFORM R0700_00_ALTERA_RELATORIOS_DB_UPDATE_1 */

            R0700_00_ALTERA_RELATORIOS_DB_UPDATE_1();

            /*" -346- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -347- DISPLAY 'SI0035B - PROBLEMAS NO UPDATE RELATORIOS' */
                _.Display($"SI0035B - PROBLEMAS NO UPDATE RELATORIOS");

                /*" -347- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0700-00-ALTERA-RELATORIOS-DB-UPDATE-1 */
        public void R0700_00_ALTERA_RELATORIOS_DB_UPDATE_1()
        {
            /*" -343- EXEC SQL UPDATE SEGUROS.RELATORIOS SET SIT_REGISTRO = '1' WHERE COD_RELATORIO = 'SI0035B' AND IDE_SISTEMA = 'SI' AND DATA_SOLICITACAO = :SISTEMAS-DATA-MOV-ABERTO AND SIT_REGISTRO = '0' END-EXEC. */

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
            /*" -357- MOVE '080' TO WNR-EXEC-SQL. */
            _.Move("080", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -358- IF AC-LINHAS GREATER 55 */

            if (AREA_DE_WORK.AC_LINHAS > 55)
            {

                /*" -360- PERFORM R4000-00-CABECALHO. */

                R4000_00_CABECALHO_SECTION();
            }


            /*" -361- MOVE 'TOTAL GERAL.........' TO LD02-LITERAL */
            _.Move("TOTAL GERAL.........", LD02.LD02_LITERAL);

            /*" -363- MOVE AC-G-SINISTROS TO LD02-TOTAL */
            _.Move(AREA_DE_WORK.AC_G_SINISTROS, LD02.LD02_TOTAL);

            /*" -364- WRITE REG-SI0035B1 FROM LC00 */
            _.Move(LC00.GetMoveValues(), REG_SI0035B1);

            SI0035B1.Write(REG_SI0035B1.GetMoveValues().ToString());

            /*" -365- WRITE REG-SI0035B1 FROM LD02 */
            _.Move(LD02.GetMoveValues(), REG_SI0035B1);

            SI0035B1.Write(REG_SI0035B1.GetMoveValues().ToString());

            /*" -365- ADD 2 TO AC-LINHAS. */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 2;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARA-LISTA-SECTION */
        private void R0900_00_DECLARA_LISTA_SECTION()
        {
            /*" -375- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -487- PERFORM R0900_00_DECLARA_LISTA_DB_DECLARE_1 */

            R0900_00_DECLARA_LISTA_DB_DECLARE_1();

            /*" -489- PERFORM R0900_00_DECLARA_LISTA_DB_OPEN_1 */

            R0900_00_DECLARA_LISTA_DB_OPEN_1();

            /*" -492- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -494- DISPLAY 'SI0035B - PROBLEMAS NO OPEN LISTA ' ' ' SISTEMAS-DATA-MOV-ABERTO */

                $"SI0035B - PROBLEMAS NO OPEN LISTA  {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}"
                .Display();

                /*" -494- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARA-LISTA-DB-DECLARE-1 */
        public void R0900_00_DECLARA_LISTA_DB_DECLARE_1()
        {
            /*" -487- EXEC SQL DECLARE LISTA CURSOR FOR SELECT E.COD_USUARIO, C.COD_TIPO_CARTA, A.DESCR_EVENTO, B.COD_FONTE, B.NUM_PROTOCOLO_SINI, B.DAC_PROTOCOLO_SINI, B.DATA_MOVTO_DOCACO, D.NATUREZA_SINISTRO, D.NOME_SEGURADO, D.COD_GIAFI, I.COD_DESTINATARIO FROM SEGUROS.SI_EVENTO_TIPO A, SEGUROS.SI_DOCUMENTO_ACOMP B, SEGUROS.SI_DOCUMENTO_PARAM C, SEGUROS.SI_MOVIMENTO_SINI D, SEGUROS.SI_ANALISTA_RODIZI E, SEGUROS.SI_SINISTRO_FASE G, SEGUROS.GE_REL_CARTA_DEST I WHERE C.COD_TIPO_CARTA = A.COD_TIPO_CARTA AND B.COD_PRODUTO = C.COD_PRODUTO AND B.COD_GRUPO_CAUSA = C.COD_GRUPO_CAUSA AND B.COD_SUBGRUPO_CAUSA = C.COD_SUBGRUPO_CAUSA AND B.COD_DOCUMENTO = C.COD_DOCUMENTO AND B.DATA_INIVIG_DOCPAR = C.DATA_INIVIG_DOCPAR AND B.COD_FONTE = D.COD_FONTE AND B.NUM_PROTOCOLO_SINI = D.NUM_PROTOCOLO_SINI AND B.DAC_PROTOCOLO_SINI = D.DAC_PROTOCOLO_SINI AND B.COD_FONTE = E.COD_FONTE AND B.NUM_PROTOCOLO_SINI = E.NUM_PROTOCOLO_SINI AND B.DAC_PROTOCOLO_SINI = E.DAC_PROTOCOLO_SINI AND B.COD_FONTE = G.COD_FONTE AND B.NUM_PROTOCOLO_SINI = G.NUM_PROTOCOLO_SINI AND B.DAC_PROTOCOLO_SINI = G.DAC_PROTOCOLO_SINI AND G.COD_FASE NOT IN (3, 4) AND G.NUM_OCORR_SINIACO = (SELECT MAX(H.NUM_OCORR_SINIACO) FROM SEGUROS.SI_SINISTRO_FASE H WHERE H.COD_FONTE = G.COD_FONTE AND H.NUM_PROTOCOLO_SINI = G.NUM_PROTOCOLO_SINI AND H.DAC_PROTOCOLO_SINI = G.DAC_PROTOCOLO_SINI AND H.DATA_ABERTURA_SIFA <= :SISTEMAS-DATA-MOV-ABERTO) AND B.NUM_CARTA IS NOT NULL AND B.NUM_CARTA = I.NUM_CARTA AND C.COD_TIPO_CARTA IN (3, 10) AND B.COD_EVENTO IN (2012, 2013, 2051) AND B.NUM_OCORR_DOCACO = (SELECT MIN(F.NUM_OCORR_DOCACO) FROM SEGUROS.SI_DOCUMENTO_ACOMP F WHERE F.COD_FONTE = B.COD_FONTE AND F.NUM_PROTOCOLO_SINI = B.NUM_PROTOCOLO_SINI AND F.DAC_PROTOCOLO_SINI = B.DAC_PROTOCOLO_SINI AND F.COD_DOCUMENTO = B.COD_DOCUMENTO AND F.DATA_MOVTO_DOCACO <= :SISTEMAS-DATA-MOV-ABERTO) AND NOT EXISTS (SELECT X.NUM_OCORR_SINIACO FROM SEGUROS.SI_SINISTRO_ACOMP X WHERE X.COD_FONTE = B.COD_FONTE AND X.NUM_PROTOCOLO_SINI = B.NUM_PROTOCOLO_SINI AND X.DAC_PROTOCOLO_SINI = B.DAC_PROTOCOLO_SINI AND X.COD_EVENTO = 2050 AND X.NUM_OCORR_SINIACO = (SELECT MAX(Y.NUM_OCORR_SINIACO) FROM SEGUROS.SI_SINISTRO_ACOMP Y WHERE Y.COD_FONTE = X.COD_FONTE AND Y.NUM_PROTOCOLO_SINI = X.NUM_PROTOCOLO_SINI AND Y.DAC_PROTOCOLO_SINI = X.DAC_PROTOCOLO_SINI AND Y.DATA_MOVTO_SINIACO >= B.DATA_MOVTO_DOCACO AND Y.DATA_MOVTO_SINIACO <= :SISTEMAS-DATA-MOV-ABERTO AND Y.COD_EVENTO IN (2050, 2051))) AND NOT EXISTS (SELECT Z.COD_DOCUMENTO FROM SEGUROS.SI_DOCUMENTO_ACOMP Z WHERE Z.COD_FONTE = B.COD_FONTE AND Z.NUM_PROTOCOLO_SINI = B.NUM_PROTOCOLO_SINI AND Z.DAC_PROTOCOLO_SINI = B.DAC_PROTOCOLO_SINI AND Z.COD_DOCUMENTO = B.COD_DOCUMENTO AND Z.COD_EVENTO IN (2010, 2011) AND Z.NUM_OCORR_DOCACO = (SELECT MAX(W.NUM_OCORR_DOCACO) FROM SEGUROS.SI_DOCUMENTO_ACOMP W WHERE W.COD_FONTE = Z.COD_FONTE AND W.NUM_PROTOCOLO_SINI = Z.NUM_PROTOCOLO_SINI AND W.DAC_PROTOCOLO_SINI = Z.DAC_PROTOCOLO_SINI AND W.COD_DOCUMENTO = Z.COD_DOCUMENTO AND W.DATA_MOVTO_DOCACO <= :SISTEMAS-DATA-MOV-ABERTO)) GROUP BY E.COD_USUARIO, C.COD_TIPO_CARTA, A.DESCR_EVENTO, B.COD_FONTE, B.NUM_PROTOCOLO_SINI, B.DAC_PROTOCOLO_SINI, B.DATA_MOVTO_DOCACO, D.NATUREZA_SINISTRO, D.NOME_SEGURADO, D.COD_GIAFI, I.COD_DESTINATARIO ORDER BY I.COD_DESTINATARIO, C.COD_TIPO_CARTA, B.DATA_MOVTO_DOCACO, B.COD_FONTE, B.NUM_PROTOCOLO_SINI END-EXEC. */
            LISTA = new SI0035B_LISTA(true);
            string GetQuery_LISTA()
            {
                var query = @$"SELECT E.COD_USUARIO
							, 
							C.COD_TIPO_CARTA
							, 
							A.DESCR_EVENTO
							, 
							B.COD_FONTE
							, 
							B.NUM_PROTOCOLO_SINI
							, 
							B.DAC_PROTOCOLO_SINI
							, 
							B.DATA_MOVTO_DOCACO
							, 
							D.NATUREZA_SINISTRO
							, 
							D.NOME_SEGURADO
							, 
							D.COD_GIAFI
							, 
							I.COD_DESTINATARIO 
							FROM SEGUROS.SI_EVENTO_TIPO A
							, 
							SEGUROS.SI_DOCUMENTO_ACOMP B
							, 
							SEGUROS.SI_DOCUMENTO_PARAM C
							, 
							SEGUROS.SI_MOVIMENTO_SINI D
							, 
							SEGUROS.SI_ANALISTA_RODIZI E
							, 
							SEGUROS.SI_SINISTRO_FASE G
							, 
							SEGUROS.GE_REL_CARTA_DEST I 
							WHERE C.COD_TIPO_CARTA = A.COD_TIPO_CARTA 
							AND B.COD_PRODUTO = C.COD_PRODUTO 
							AND B.COD_GRUPO_CAUSA = C.COD_GRUPO_CAUSA 
							AND B.COD_SUBGRUPO_CAUSA = C.COD_SUBGRUPO_CAUSA 
							AND B.COD_DOCUMENTO = C.COD_DOCUMENTO 
							AND B.DATA_INIVIG_DOCPAR = C.DATA_INIVIG_DOCPAR 
							AND B.COD_FONTE = D.COD_FONTE 
							AND B.NUM_PROTOCOLO_SINI = D.NUM_PROTOCOLO_SINI 
							AND B.DAC_PROTOCOLO_SINI = D.DAC_PROTOCOLO_SINI 
							AND B.COD_FONTE = E.COD_FONTE 
							AND B.NUM_PROTOCOLO_SINI = E.NUM_PROTOCOLO_SINI 
							AND B.DAC_PROTOCOLO_SINI = E.DAC_PROTOCOLO_SINI 
							AND B.COD_FONTE = G.COD_FONTE 
							AND B.NUM_PROTOCOLO_SINI = G.NUM_PROTOCOLO_SINI 
							AND B.DAC_PROTOCOLO_SINI = G.DAC_PROTOCOLO_SINI 
							AND G.COD_FASE NOT IN (3
							, 4) 
							AND G.NUM_OCORR_SINIACO = 
							(SELECT MAX(H.NUM_OCORR_SINIACO) 
							FROM SEGUROS.SI_SINISTRO_FASE H 
							WHERE H.COD_FONTE = G.COD_FONTE 
							AND H.NUM_PROTOCOLO_SINI = G.NUM_PROTOCOLO_SINI 
							AND H.DAC_PROTOCOLO_SINI = G.DAC_PROTOCOLO_SINI 
							AND H.DATA_ABERTURA_SIFA <= 
							'{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}') 
							AND B.NUM_CARTA IS NOT NULL 
							AND B.NUM_CARTA = I.NUM_CARTA 
							AND C.COD_TIPO_CARTA IN (3
							, 10) 
							AND B.COD_EVENTO IN (2012
							, 2013
							, 2051) 
							AND B.NUM_OCORR_DOCACO = 
							(SELECT MIN(F.NUM_OCORR_DOCACO) 
							FROM SEGUROS.SI_DOCUMENTO_ACOMP F 
							WHERE F.COD_FONTE = B.COD_FONTE 
							AND F.NUM_PROTOCOLO_SINI = B.NUM_PROTOCOLO_SINI 
							AND F.DAC_PROTOCOLO_SINI = B.DAC_PROTOCOLO_SINI 
							AND F.COD_DOCUMENTO = B.COD_DOCUMENTO 
							AND F.DATA_MOVTO_DOCACO <= 
							'{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}') 
							AND NOT EXISTS 
							(SELECT X.NUM_OCORR_SINIACO 
							FROM SEGUROS.SI_SINISTRO_ACOMP X 
							WHERE X.COD_FONTE = B.COD_FONTE 
							AND X.NUM_PROTOCOLO_SINI = B.NUM_PROTOCOLO_SINI 
							AND X.DAC_PROTOCOLO_SINI = B.DAC_PROTOCOLO_SINI 
							AND X.COD_EVENTO = 2050 
							AND X.NUM_OCORR_SINIACO = 
							(SELECT MAX(Y.NUM_OCORR_SINIACO) 
							FROM SEGUROS.SI_SINISTRO_ACOMP Y 
							WHERE Y.COD_FONTE = X.COD_FONTE 
							AND Y.NUM_PROTOCOLO_SINI = X.NUM_PROTOCOLO_SINI 
							AND Y.DAC_PROTOCOLO_SINI = X.DAC_PROTOCOLO_SINI 
							AND Y.DATA_MOVTO_SINIACO >= B.DATA_MOVTO_DOCACO 
							AND Y.DATA_MOVTO_SINIACO <= 
							'{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND Y.COD_EVENTO IN (2050
							, 2051))) 
							AND NOT EXISTS 
							(SELECT Z.COD_DOCUMENTO 
							FROM SEGUROS.SI_DOCUMENTO_ACOMP Z 
							WHERE Z.COD_FONTE = B.COD_FONTE 
							AND Z.NUM_PROTOCOLO_SINI = B.NUM_PROTOCOLO_SINI 
							AND Z.DAC_PROTOCOLO_SINI = B.DAC_PROTOCOLO_SINI 
							AND Z.COD_DOCUMENTO = B.COD_DOCUMENTO 
							AND Z.COD_EVENTO IN (2010
							, 2011) 
							AND Z.NUM_OCORR_DOCACO = 
							(SELECT MAX(W.NUM_OCORR_DOCACO) 
							FROM SEGUROS.SI_DOCUMENTO_ACOMP W 
							WHERE W.COD_FONTE = Z.COD_FONTE 
							AND W.NUM_PROTOCOLO_SINI = Z.NUM_PROTOCOLO_SINI 
							AND W.DAC_PROTOCOLO_SINI = Z.DAC_PROTOCOLO_SINI 
							AND W.COD_DOCUMENTO = Z.COD_DOCUMENTO 
							AND W.DATA_MOVTO_DOCACO <= 
							'{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}')) 
							GROUP BY E.COD_USUARIO
							, 
							C.COD_TIPO_CARTA
							, 
							A.DESCR_EVENTO
							, 
							B.COD_FONTE
							, 
							B.NUM_PROTOCOLO_SINI
							, 
							B.DAC_PROTOCOLO_SINI
							, 
							B.DATA_MOVTO_DOCACO
							, 
							D.NATUREZA_SINISTRO
							, 
							D.NOME_SEGURADO
							, 
							D.COD_GIAFI
							, 
							I.COD_DESTINATARIO 
							ORDER BY I.COD_DESTINATARIO
							, 
							C.COD_TIPO_CARTA
							, 
							B.DATA_MOVTO_DOCACO
							, 
							B.COD_FONTE
							, 
							B.NUM_PROTOCOLO_SINI";

                return query;
            }
            LISTA.GetQueryEvent += GetQuery_LISTA;

        }

        [StopWatch]
        /*" R0900-00-DECLARA-LISTA-DB-OPEN-1 */
        public void R0900_00_DECLARA_LISTA_DB_OPEN_1()
        {
            /*" -489- EXEC SQL OPEN LISTA END-EXEC. */

            LISTA.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-LE-LISTA-SECTION */
        private void R0910_00_LE_LISTA_SECTION()
        {
            /*" -504- MOVE '091' TO WNR-EXEC-SQL. */
            _.Move("091", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -516- PERFORM R0910_00_LE_LISTA_DB_FETCH_1 */

            R0910_00_LE_LISTA_DB_FETCH_1();

            /*" -519- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -520- ADD 1 TO AC-L-LISTA */
                AREA_DE_WORK.AC_L_LISTA.Value = AREA_DE_WORK.AC_L_LISTA + 1;

                /*" -521- ELSE */
            }
            else
            {


                /*" -522- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -523- MOVE 'S' TO WFIM-LISTA */
                    _.Move("S", AREA_DE_WORK.WFIM_LISTA);

                    /*" -523- PERFORM R0910_00_LE_LISTA_DB_CLOSE_1 */

                    R0910_00_LE_LISTA_DB_CLOSE_1();

                    /*" -525- ELSE */
                }
                else
                {


                    /*" -527- DISPLAY 'SI0035B - PROBLEMAS NO FETCH LISTA ' ' ' SISTEMAS-DATA-MOV-ABERTO */

                    $"SI0035B - PROBLEMAS NO FETCH LISTA  {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}"
                    .Display();

                    /*" -527- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0910-00-LE-LISTA-DB-FETCH-1 */
        public void R0910_00_LE_LISTA_DB_FETCH_1()
        {
            /*" -516- EXEC SQL FETCH LISTA INTO :SIANAROD-COD-USUARIO, :SIDOCPAR-COD-TIPO-CARTA, :SIEVETIP-DESCR-EVENTO, :SIDOCACO-COD-FONTE, :SIDOCACO-NUM-PROTOCOLO-SINI, :SIDOCACO-DAC-PROTOCOLO-SINI, :SIDOCACO-DATA-MOVTO-DOCACO, :SIMOVSIN-NATUREZA-SINISTRO, :SIMOVSIN-NOME-SEGURADO, :SIMOVSIN-COD-GIAFI, :GERECADE-COD-DESTINATARIO END-EXEC. */

            if (LISTA.Fetch())
            {
                _.Move(LISTA.SIANAROD_COD_USUARIO, SIANAROD.DCLSI_ANALISTA_RODIZI.SIANAROD_COD_USUARIO);
                _.Move(LISTA.SIDOCPAR_COD_TIPO_CARTA, SIDOCPAR.DCLSI_DOCUMENTO_PARAM.SIDOCPAR_COD_TIPO_CARTA);
                _.Move(LISTA.SIEVETIP_DESCR_EVENTO, SIEVETIP.DCLSI_EVENTO_TIPO.SIEVETIP_DESCR_EVENTO);
                _.Move(LISTA.SIDOCACO_COD_FONTE, SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_FONTE);
                _.Move(LISTA.SIDOCACO_NUM_PROTOCOLO_SINI, SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_PROTOCOLO_SINI);
                _.Move(LISTA.SIDOCACO_DAC_PROTOCOLO_SINI, SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DAC_PROTOCOLO_SINI);
                _.Move(LISTA.SIDOCACO_DATA_MOVTO_DOCACO, SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DATA_MOVTO_DOCACO);
                _.Move(LISTA.SIMOVSIN_NATUREZA_SINISTRO, SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_NATUREZA_SINISTRO);
                _.Move(LISTA.SIMOVSIN_NOME_SEGURADO, SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_NOME_SEGURADO);
                _.Move(LISTA.SIMOVSIN_COD_GIAFI, SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_COD_GIAFI);
                _.Move(LISTA.GERECADE_COD_DESTINATARIO, GERECADE.DCLGE_REL_CARTA_DEST.GERECADE_COD_DESTINATARIO);
            }

        }

        [StopWatch]
        /*" R0910-00-LE-LISTA-DB-CLOSE-1 */
        public void R0910_00_LE_LISTA_DB_CLOSE_1()
        {
            /*" -523- EXEC SQL CLOSE LISTA END-EXEC */

            LISTA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-SECTION */
        private void R1000_00_PROCESSA_SECTION()
        {
            /*" -543- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -543- PERFORM R2000-00-PROCESSA-ANALISTA. */

            R2000_00_PROCESSA_ANALISTA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-LE-USUARIOS-SECTION */
        private void R1100_00_LE_USUARIOS_SECTION()
        {
            /*" -559- MOVE '110' TO WNR-EXEC-SQL. */
            _.Move("110", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -564- PERFORM R1100_00_LE_USUARIOS_DB_SELECT_1 */

            R1100_00_LE_USUARIOS_DB_SELECT_1();

            /*" -567- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -568- DISPLAY 'SI0035B - PROBLEMAS NO SELECT USUARIOS' */
                _.Display($"SI0035B - PROBLEMAS NO SELECT USUARIOS");

                /*" -572- DISPLAY ' ' SIDOCACO-COD-FONTE ' ' SIDOCACO-NUM-PROTOCOLO-SINI ' ' SIDOCACO-DAC-PROTOCOLO-SINI ' ' SIANAROD-COD-USUARIO */

                $" {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_FONTE} {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_PROTOCOLO_SINI} {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DAC_PROTOCOLO_SINI} {SIANAROD.DCLSI_ANALISTA_RODIZI.SIANAROD_COD_USUARIO}"
                .Display();

                /*" -572- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1100-00-LE-USUARIOS-DB-SELECT-1 */
        public void R1100_00_LE_USUARIOS_DB_SELECT_1()
        {
            /*" -564- EXEC SQL SELECT NOME_USUARIO INTO :USUARIOS-NOME-USUARIO FROM SEGUROS.USUARIOS WHERE COD_USUARIO = :SIANAROD-COD-USUARIO END-EXEC. */

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
            /*" -582- MOVE '190' TO WNR-EXEC-SQL. */
            _.Move("190", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -583- IF AC-LINHAS GREATER 55 */

            if (AREA_DE_WORK.AC_LINHAS > 55)
            {

                /*" -585- PERFORM R4000-00-CABECALHO. */

                R4000_00_CABECALHO_SECTION();
            }


            /*" -586- MOVE 'TOTAL DO ANALISTA...' TO LD02-LITERAL */
            _.Move("TOTAL DO ANALISTA...", LD02.LD02_LITERAL);

            /*" -588- MOVE AC-A-SINISTROS TO LD02-TOTAL */
            _.Move(AREA_DE_WORK.AC_A_SINISTROS, LD02.LD02_TOTAL);

            /*" -589- WRITE REG-SI0035B1 FROM LC00 */
            _.Move(LC00.GetMoveValues(), REG_SI0035B1);

            SI0035B1.Write(REG_SI0035B1.GetMoveValues().ToString());

            /*" -590- WRITE REG-SI0035B1 FROM LD02 */
            _.Move(LD02.GetMoveValues(), REG_SI0035B1);

            SI0035B1.Write(REG_SI0035B1.GetMoveValues().ToString());

            /*" -592- ADD 2 TO AC-LINHAS */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 2;

            /*" -593- ADD AC-A-SINISTROS TO AC-G-SINISTROS */
            AREA_DE_WORK.AC_G_SINISTROS.Value = AREA_DE_WORK.AC_G_SINISTROS + AREA_DE_WORK.AC_A_SINISTROS;

            /*" -593- MOVE ZEROS TO AC-A-SINISTROS. */
            _.Move(0, AREA_DE_WORK.AC_A_SINISTROS);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-PROCESSA-ANALISTA-SECTION */
        private void R2000_00_PROCESSA_ANALISTA_SECTION()
        {
            /*" -603- MOVE '200' TO WNR-EXEC-SQL. */
            _.Move("200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -605- MOVE 80 TO AC-LINHAS */
            _.Move(80, AREA_DE_WORK.AC_LINHAS);

            /*" -607- PERFORM R2100-00-LE-GEDESTIN */

            R2100_00_LE_GEDESTIN_SECTION();

            /*" -616- MOVE GERECADE-COD-DESTINATARIO TO WS-COD-DESTINATARIO-ANT */
            _.Move(GERECADE.DCLGE_REL_CARTA_DEST.GERECADE_COD_DESTINATARIO, WS_COD_DESTINATARIO_ANT);

            /*" -624- PERFORM R3000-00-PROCESSA-PRESTADOR UNTIL WFIM-LISTA EQUAL 'S' OR GERECADE-COD-DESTINATARIO NOT EQUAL WS-COD-DESTINATARIO-ANT */

            while (!(AREA_DE_WORK.WFIM_LISTA == "S" || GERECADE.DCLGE_REL_CARTA_DEST.GERECADE_COD_DESTINATARIO != WS_COD_DESTINATARIO_ANT))
            {

                R3000_00_PROCESSA_PRESTADOR_SECTION();
            }

            /*" -625- IF AC-P-SINISTROS NOT EQUAL ZEROS */

            if (AREA_DE_WORK.AC_P_SINISTROS != 00)
            {

                /*" -625- PERFORM R2900-00-TOTAL-PRESTADOR. */

                R2900_00_TOTAL_PRESTADOR_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-LE-GEDESTIN-SECTION */
        private void R2100_00_LE_GEDESTIN_SECTION()
        {
            /*" -635- MOVE '210' TO WNR-EXEC-SQL. */
            _.Move("210", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -641- PERFORM R2100_00_LE_GEDESTIN_DB_SELECT_1 */

            R2100_00_LE_GEDESTIN_DB_SELECT_1();

            /*" -644- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -645- DISPLAY 'SI0035B - PROBLEMAS NO SELECT GE_DESTINATARIO' */
                _.Display($"SI0035B - PROBLEMAS NO SELECT GE_DESTINATARIO");

                /*" -649- DISPLAY ' ' SIDOCACO-COD-FONTE ' ' SIDOCACO-NUM-PROTOCOLO-SINI ' ' SIDOCACO-DAC-PROTOCOLO-SINI ' ' GERECADE-COD-DESTINATARIO */

                $" {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_FONTE} {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_PROTOCOLO_SINI} {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DAC_PROTOCOLO_SINI} {GERECADE.DCLGE_REL_CARTA_DEST.GERECADE_COD_DESTINATARIO}"
                .Display();

                /*" -649- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2100-00-LE-GEDESTIN-DB-SELECT-1 */
        public void R2100_00_LE_GEDESTIN_DB_SELECT_1()
        {
            /*" -641- EXEC SQL SELECT NOME_DESTINATARIO INTO :GEDESTIN-NOME-DESTINATARIO FROM SEGUROS.GE_DESTINATARIO WHERE COD_DESTINATARIO = :GERECADE-COD-DESTINATARIO END-EXEC. */

            var r2100_00_LE_GEDESTIN_DB_SELECT_1_Query1 = new R2100_00_LE_GEDESTIN_DB_SELECT_1_Query1()
            {
                GERECADE_COD_DESTINATARIO = GERECADE.DCLGE_REL_CARTA_DEST.GERECADE_COD_DESTINATARIO.ToString(),
            };

            var executed_1 = R2100_00_LE_GEDESTIN_DB_SELECT_1_Query1.Execute(r2100_00_LE_GEDESTIN_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GEDESTIN_NOME_DESTINATARIO, GEDESTIN.DCLGE_DESTINATARIO.GEDESTIN_NOME_DESTINATARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2900-00-TOTAL-PRESTADOR-SECTION */
        private void R2900_00_TOTAL_PRESTADOR_SECTION()
        {
            /*" -659- MOVE '290' TO WNR-EXEC-SQL. */
            _.Move("290", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -660- IF AC-LINHAS GREATER 55 */

            if (AREA_DE_WORK.AC_LINHAS > 55)
            {

                /*" -662- PERFORM R4000-00-CABECALHO. */

                R4000_00_CABECALHO_SECTION();
            }


            /*" -663- MOVE 'TOTAL DO PRESTADOR..' TO LD02-LITERAL */
            _.Move("TOTAL DO PRESTADOR..", LD02.LD02_LITERAL);

            /*" -665- MOVE AC-P-SINISTROS TO LD02-TOTAL */
            _.Move(AREA_DE_WORK.AC_P_SINISTROS, LD02.LD02_TOTAL);

            /*" -666- WRITE REG-SI0035B1 FROM LC00 */
            _.Move(LC00.GetMoveValues(), REG_SI0035B1);

            SI0035B1.Write(REG_SI0035B1.GetMoveValues().ToString());

            /*" -667- WRITE REG-SI0035B1 FROM LD02 */
            _.Move(LD02.GetMoveValues(), REG_SI0035B1);

            SI0035B1.Write(REG_SI0035B1.GetMoveValues().ToString());

            /*" -670- ADD 2 TO AC-LINHAS */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 2;

            /*" -671- ADD AC-P-SINISTROS TO AC-G-SINISTROS */
            AREA_DE_WORK.AC_G_SINISTROS.Value = AREA_DE_WORK.AC_G_SINISTROS + AREA_DE_WORK.AC_P_SINISTROS;

            /*" -671- MOVE ZEROS TO AC-P-SINISTROS. */
            _.Move(0, AREA_DE_WORK.AC_P_SINISTROS);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2900_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-PROCESSA-PRESTADOR-SECTION */
        private void R3000_00_PROCESSA_PRESTADOR_SECTION()
        {
            /*" -681- MOVE '300' TO WNR-EXEC-SQL. */
            _.Move("300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -682- MOVE ZEROS TO HOST-COUNT */
            _.Move(0, HOST_COUNT);

            /*" -684- PERFORM R3300-00-OBTEM-DIAS-DECORRIDOS */

            R3300_00_OBTEM_DIAS_DECORRIDOS_SECTION();

            /*" -685- IF HOST-COUNT NOT GREATER 15 */

            if (HOST_COUNT <= 15)
            {

                /*" -687- GO TO R3000-10-LER. */

                R3000_10_LER(); //GOTO
                return;
            }


            /*" -688- PERFORM R3100-00-LE-SISINACO */

            R3100_00_LE_SISINACO_SECTION();

            /*" -690- PERFORM R3200-00-LE-SINISMES */

            R3200_00_LE_SINISMES_SECTION();

            /*" -691- MOVE SIDOCACO-COD-FONTE TO LD01-COD-FONTE */
            _.Move(SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_FONTE, LD01.LD01_COD_FONTE);

            /*" -693- MOVE SIDOCACO-NUM-PROTOCOLO-SINI TO LD01-NUM-PROTOCOLO */
            _.Move(SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_PROTOCOLO_SINI, LD01.LD01_NUM_PROTOCOLO);

            /*" -695- MOVE SIDOCACO-DAC-PROTOCOLO-SINI TO LD01-DAC-PROTOCOLO */
            _.Move(SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DAC_PROTOCOLO_SINI, LD01.LD01_DAC_PROTOCOLO);

            /*" -696- MOVE SINISMES-NUM-IRB TO LD01-NUM-IRB */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_IRB, LD01.LD01_NUM_IRB);

            /*" -699- MOVE SIMOVSIN-NOME-SEGURADO TO LD01-NOME-SEGURADO */
            _.Move(SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_NOME_SEGURADO, LD01.LD01_NOME_SEGURADO);

            /*" -701- IF SIMOVSIN-NATUREZA-SINISTRO EQUAL 1 */

            if (SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_NATUREZA_SINISTRO == 1)
            {

                /*" -702- MOVE 'MIP' TO LD01-TIPO-SINISTRO */
                _.Move("MIP", LD01.LD01_TIPO_SINISTRO);

                /*" -703- ELSE */
            }
            else
            {


                /*" -705- MOVE 'DFI' TO LD01-TIPO-SINISTRO. */
                _.Move("DFI", LD01.LD01_TIPO_SINISTRO);
            }


            /*" -707- IF SISINACO-DATA-MOVTO-SINIACO EQUAL SPACES */

            if (SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DATA_MOVTO_SINIACO.IsEmpty())
            {

                /*" -708- MOVE SPACES TO LD01-DATA-AVISO */
                _.Move("", LD01.LD01_DATA_AVISO);

                /*" -709- ELSE */
            }
            else
            {


                /*" -711- MOVE SISINACO-DATA-MOVTO-SINIACO TO DB2-DATA */
                _.Move(SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DATA_MOVTO_SINIACO, AREA_DE_WORK.DB2_DATA);

                /*" -712- MOVE DB2-DIA TO EDIT-DIA */
                _.Move(AREA_DE_WORK.DB2_DATA.DB2_DIA, AREA_DE_WORK.EDIT_DATA.EDIT_DIA);

                /*" -713- MOVE DB2-MES TO EDIT-MES */
                _.Move(AREA_DE_WORK.DB2_DATA.DB2_MES, AREA_DE_WORK.EDIT_DATA.EDIT_MES);

                /*" -714- MOVE DB2-ANO TO EDIT-ANO */
                _.Move(AREA_DE_WORK.DB2_DATA.DB2_ANO, AREA_DE_WORK.EDIT_DATA.EDIT_ANO);

                /*" -716- MOVE EDIT-DATA TO LD01-DATA-AVISO. */
                _.Move(AREA_DE_WORK.EDIT_DATA, LD01.LD01_DATA_AVISO);
            }


            /*" -719- MOVE SIEVETIP-DESCR-EVENTO TO LD01-DESCR-EVENTO */
            _.Move(SIEVETIP.DCLSI_EVENTO_TIPO.SIEVETIP_DESCR_EVENTO, LD01.LD01_DESCR_EVENTO);

            /*" -721- MOVE SIDOCACO-DATA-MOVTO-DOCACO TO DB2-DATA */
            _.Move(SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DATA_MOVTO_DOCACO, AREA_DE_WORK.DB2_DATA);

            /*" -722- MOVE DB2-DIA TO EDIT-DIA */
            _.Move(AREA_DE_WORK.DB2_DATA.DB2_DIA, AREA_DE_WORK.EDIT_DATA.EDIT_DIA);

            /*" -723- MOVE DB2-MES TO EDIT-MES */
            _.Move(AREA_DE_WORK.DB2_DATA.DB2_MES, AREA_DE_WORK.EDIT_DATA.EDIT_MES);

            /*" -724- MOVE DB2-ANO TO EDIT-ANO */
            _.Move(AREA_DE_WORK.DB2_DATA.DB2_ANO, AREA_DE_WORK.EDIT_DATA.EDIT_ANO);

            /*" -726- MOVE EDIT-DATA TO LD01-DATA-EVENTO */
            _.Move(AREA_DE_WORK.EDIT_DATA, LD01.LD01_DATA_EVENTO);

            /*" -727- IF AC-LINHAS GREATER 55 */

            if (AREA_DE_WORK.AC_LINHAS > 55)
            {

                /*" -730- PERFORM R4000-00-CABECALHO. */

                R4000_00_CABECALHO_SECTION();
            }


            /*" -731- WRITE REG-SI0035B1 FROM LD01 */
            _.Move(LD01.GetMoveValues(), REG_SI0035B1);

            SI0035B1.Write(REG_SI0035B1.GetMoveValues().ToString());

            /*" -733- ADD 1 TO AC-LINHAS AC-I-SI0035B1 AC-P-SINISTROS. */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 1;
            AREA_DE_WORK.AC_I_SI0035B1.Value = AREA_DE_WORK.AC_I_SI0035B1 + 1;
            AREA_DE_WORK.AC_P_SINISTROS.Value = AREA_DE_WORK.AC_P_SINISTROS + 1;

            /*" -0- FLUXCONTROL_PERFORM R3000_10_LER */

            R3000_10_LER();

        }

        [StopWatch]
        /*" R3000-10-LER */
        private void R3000_10_LER(bool isPerform = false)
        {
            /*" -739- PERFORM R0910-00-LE-LISTA. */

            R0910_00_LE_LISTA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-LE-SISINACO-SECTION */
        private void R3100_00_LE_SISINACO_SECTION()
        {
            /*" -749- MOVE '310' TO WNR-EXEC-SQL. */
            _.Move("310", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -759- PERFORM R3100_00_LE_SISINACO_DB_SELECT_1 */

            R3100_00_LE_SISINACO_DB_SELECT_1();

            /*" -762- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -764- MOVE SPACES TO SISINACO-DATA-MOVTO-SINIACO */
                _.Move("", SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DATA_MOVTO_SINIACO);

                /*" -765- ELSE */
            }
            else
            {


                /*" -766- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -767- DISPLAY 'SI0035B - PROBLEMAS NO SELECT SI_SINISTRO_ACOMP' */
                    _.Display($"SI0035B - PROBLEMAS NO SELECT SI_SINISTRO_ACOMP");

                    /*" -770- DISPLAY ' ' SIDOCACO-COD-FONTE ' ' SIDOCACO-NUM-PROTOCOLO-SINI ' ' SIDOCACO-DAC-PROTOCOLO-SINI */

                    $" {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_FONTE} {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_PROTOCOLO_SINI} {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DAC_PROTOCOLO_SINI}"
                    .Display();

                    /*" -770- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R3100-00-LE-SISINACO-DB-SELECT-1 */
        public void R3100_00_LE_SISINACO_DB_SELECT_1()
        {
            /*" -759- EXEC SQL SELECT DATA_MOVTO_SINIACO INTO :SISINACO-DATA-MOVTO-SINIACO FROM SEGUROS.SI_SINISTRO_ACOMP WHERE COD_FONTE = :SIDOCACO-COD-FONTE AND NUM_PROTOCOLO_SINI = :SIDOCACO-NUM-PROTOCOLO-SINI AND DAC_PROTOCOLO_SINI = :SIDOCACO-DAC-PROTOCOLO-SINI AND COD_EVENTO = 1001 END-EXEC. */

            var r3100_00_LE_SISINACO_DB_SELECT_1_Query1 = new R3100_00_LE_SISINACO_DB_SELECT_1_Query1()
            {
                SIDOCACO_NUM_PROTOCOLO_SINI = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_PROTOCOLO_SINI.ToString(),
                SIDOCACO_DAC_PROTOCOLO_SINI = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DAC_PROTOCOLO_SINI.ToString(),
                SIDOCACO_COD_FONTE = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_FONTE.ToString(),
            };

            var executed_1 = R3100_00_LE_SISINACO_DB_SELECT_1_Query1.Execute(r3100_00_LE_SISINACO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISINACO_DATA_MOVTO_SINIACO, SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DATA_MOVTO_SINIACO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R3200-00-LE-SINISMES-SECTION */
        private void R3200_00_LE_SINISMES_SECTION()
        {
            /*" -780- MOVE '320' TO WNR-EXEC-SQL. */
            _.Move("320", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -789- PERFORM R3200_00_LE_SINISMES_DB_SELECT_1 */

            R3200_00_LE_SINISMES_DB_SELECT_1();

            /*" -792- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -793- MOVE ZEROS TO SINISMES-NUM-IRB */
                _.Move(0, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_IRB);

                /*" -794- ELSE */
            }
            else
            {


                /*" -795- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -796- DISPLAY 'SI0035B - PROBLEMAS NO SELECT SINISTRO_MESTRE' */
                    _.Display($"SI0035B - PROBLEMAS NO SELECT SINISTRO_MESTRE");

                    /*" -799- DISPLAY ' ' SIDOCACO-COD-FONTE ' ' SIDOCACO-NUM-PROTOCOLO-SINI ' ' SIDOCACO-DAC-PROTOCOLO-SINI */

                    $" {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_FONTE} {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_PROTOCOLO_SINI} {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DAC_PROTOCOLO_SINI}"
                    .Display();

                    /*" -799- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R3200-00-LE-SINISMES-DB-SELECT-1 */
        public void R3200_00_LE_SINISMES_DB_SELECT_1()
        {
            /*" -789- EXEC SQL SELECT NUM_IRB INTO :SINISMES-NUM-IRB FROM SEGUROS.SINISTRO_MESTRE WHERE COD_FONTE = :SIDOCACO-COD-FONTE AND NUM_PROTOCOLO_SINI = :SIDOCACO-NUM-PROTOCOLO-SINI AND DAC_PROTOCOLO_SINI = :SIDOCACO-DAC-PROTOCOLO-SINI END-EXEC. */

            var r3200_00_LE_SINISMES_DB_SELECT_1_Query1 = new R3200_00_LE_SINISMES_DB_SELECT_1_Query1()
            {
                SIDOCACO_NUM_PROTOCOLO_SINI = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_PROTOCOLO_SINI.ToString(),
                SIDOCACO_DAC_PROTOCOLO_SINI = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DAC_PROTOCOLO_SINI.ToString(),
                SIDOCACO_COD_FONTE = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_FONTE.ToString(),
            };

            var executed_1 = R3200_00_LE_SINISMES_DB_SELECT_1_Query1.Execute(r3200_00_LE_SINISMES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISMES_NUM_IRB, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_IRB);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/

        [StopWatch]
        /*" R3300-00-OBTEM-DIAS-DECORRIDOS-SECTION */
        private void R3300_00_OBTEM_DIAS_DECORRIDOS_SECTION()
        {
            /*" -811- MOVE '330' TO WNR-EXEC-SQL. */
            _.Move("330", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -817- PERFORM R3300_00_OBTEM_DIAS_DECORRIDOS_DB_SELECT_1 */

            R3300_00_OBTEM_DIAS_DECORRIDOS_DB_SELECT_1();

            /*" -820- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -821- DISPLAY 'SI0035B - PROBLEMAS NO SELECT CALENDARIO' */
                _.Display($"SI0035B - PROBLEMAS NO SELECT CALENDARIO");

                /*" -824- DISPLAY ' ' SIDOCACO-COD-FONTE ' ' SIDOCACO-NUM-PROTOCOLO-SINI ' ' SIDOCACO-DAC-PROTOCOLO-SINI */

                $" {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_FONTE} {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_PROTOCOLO_SINI} {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DAC_PROTOCOLO_SINI}"
                .Display();

                /*" -824- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3300-00-OBTEM-DIAS-DECORRIDOS-DB-SELECT-1 */
        public void R3300_00_OBTEM_DIAS_DECORRIDOS_DB_SELECT_1()
        {
            /*" -817- EXEC SQL SELECT COUNT(*) INTO :HOST-COUNT FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO >= :SIDOCACO-DATA-MOVTO-DOCACO AND DATA_CALENDARIO <= :SISTEMAS-DATA-MOV-ABERTO END-EXEC. */

            var r3300_00_OBTEM_DIAS_DECORRIDOS_DB_SELECT_1_Query1 = new R3300_00_OBTEM_DIAS_DECORRIDOS_DB_SELECT_1_Query1()
            {
                SIDOCACO_DATA_MOVTO_DOCACO = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DATA_MOVTO_DOCACO.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
            };

            var executed_1 = R3300_00_OBTEM_DIAS_DECORRIDOS_DB_SELECT_1_Query1.Execute(r3300_00_OBTEM_DIAS_DECORRIDOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_COUNT, HOST_COUNT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-CABECALHO-SECTION */
        private void R4000_00_CABECALHO_SECTION()
        {
            /*" -834- MOVE '400' TO WNR-EXEC-SQL. */
            _.Move("400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -835- ADD 1 TO AC-PAGINAS */
            AREA_DE_WORK.AC_PAGINAS.Value = AREA_DE_WORK.AC_PAGINAS + 1;

            /*" -837- MOVE AC-PAGINAS TO LC01-PAGINA */
            _.Move(AREA_DE_WORK.AC_PAGINAS, LC01.LC01_PAGINA);

            /*" -839- MOVE SISTEMAS-DATA-MOV-ABERTO TO DB2-DATA */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREA_DE_WORK.DB2_DATA);

            /*" -840- MOVE DB2-DIA TO EDIT-DIA */
            _.Move(AREA_DE_WORK.DB2_DATA.DB2_DIA, AREA_DE_WORK.EDIT_DATA.EDIT_DIA);

            /*" -841- MOVE DB2-MES TO EDIT-MES */
            _.Move(AREA_DE_WORK.DB2_DATA.DB2_MES, AREA_DE_WORK.EDIT_DATA.EDIT_MES);

            /*" -842- MOVE DB2-ANO TO EDIT-ANO */
            _.Move(AREA_DE_WORK.DB2_DATA.DB2_ANO, AREA_DE_WORK.EDIT_DATA.EDIT_ANO);

            /*" -845- MOVE EDIT-DATA TO LC02-DATA LC02-DATA-MOV-ABERTO */
            _.Move(AREA_DE_WORK.EDIT_DATA, LC02.LC02_DATA, LC02.LC02_DATA_MOV_ABERTO);

            /*" -846- ACCEPT ACC-HORA FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.ACC_HORA);

            /*" -847- MOVE ACC-HH TO EDIT-HH */
            _.Move(AREA_DE_WORK.ACC_HORA.ACC_HH, AREA_DE_WORK.EDIT_HORA.EDIT_HH);

            /*" -848- MOVE ACC-MM TO EDIT-MM */
            _.Move(AREA_DE_WORK.ACC_HORA.ACC_MM, AREA_DE_WORK.EDIT_HORA.EDIT_MM);

            /*" -849- MOVE ACC-SS TO EDIT-SS */
            _.Move(AREA_DE_WORK.ACC_HORA.ACC_SS, AREA_DE_WORK.EDIT_HORA.EDIT_SS);

            /*" -854- MOVE EDIT-HORA TO LC03-HORA */
            _.Move(AREA_DE_WORK.EDIT_HORA, LC03.LC03_HORA);

            /*" -857- MOVE GEDESTIN-NOME-DESTINATARIO TO LC06-PRESTADOR */
            _.Move(GEDESTIN.DCLGE_DESTINATARIO.GEDESTIN_NOME_DESTINATARIO, LC06.LC06_PRESTADOR);

            /*" -858- WRITE REG-SI0035B1 FROM LC01 */
            _.Move(LC01.GetMoveValues(), REG_SI0035B1);

            SI0035B1.Write(REG_SI0035B1.GetMoveValues().ToString());

            /*" -859- WRITE REG-SI0035B1 FROM LC02 */
            _.Move(LC02.GetMoveValues(), REG_SI0035B1);

            SI0035B1.Write(REG_SI0035B1.GetMoveValues().ToString());

            /*" -860- WRITE REG-SI0035B1 FROM LC03 */
            _.Move(LC03.GetMoveValues(), REG_SI0035B1);

            SI0035B1.Write(REG_SI0035B1.GetMoveValues().ToString());

            /*" -861- WRITE REG-SI0035B1 FROM LC00 */
            _.Move(LC00.GetMoveValues(), REG_SI0035B1);

            SI0035B1.Write(REG_SI0035B1.GetMoveValues().ToString());

            /*" -863- WRITE REG-SI0035B1 FROM LC04 */
            _.Move(LC04.GetMoveValues(), REG_SI0035B1);

            SI0035B1.Write(REG_SI0035B1.GetMoveValues().ToString());

            /*" -864- WRITE REG-SI0035B1 FROM LC06 */
            _.Move(LC06.GetMoveValues(), REG_SI0035B1);

            SI0035B1.Write(REG_SI0035B1.GetMoveValues().ToString());

            /*" -865- WRITE REG-SI0035B1 FROM LC04 */
            _.Move(LC04.GetMoveValues(), REG_SI0035B1);

            SI0035B1.Write(REG_SI0035B1.GetMoveValues().ToString());

            /*" -866- WRITE REG-SI0035B1 FROM LC07 */
            _.Move(LC07.GetMoveValues(), REG_SI0035B1);

            SI0035B1.Write(REG_SI0035B1.GetMoveValues().ToString());

            /*" -867- WRITE REG-SI0035B1 FROM LC04 */
            _.Move(LC04.GetMoveValues(), REG_SI0035B1);

            SI0035B1.Write(REG_SI0035B1.GetMoveValues().ToString());

            /*" -869- WRITE REG-SI0035B1 FROM LC00 */
            _.Move(LC00.GetMoveValues(), REG_SI0035B1);

            SI0035B1.Write(REG_SI0035B1.GetMoveValues().ToString());

            /*" -869- MOVE 10 TO AC-LINHAS. */
            _.Move(10, AREA_DE_WORK.AC_LINHAS);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R4100-00-CABECALHO-PRESTADOR-SECTION */
        private void R4100_00_CABECALHO_PRESTADOR_SECTION()
        {
            /*" -879- MOVE '410' TO WNR-EXEC-SQL. */
            _.Move("410", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -882- MOVE GEDESTIN-NOME-DESTINATARIO TO LC06-PRESTADOR */
            _.Move(GEDESTIN.DCLGE_DESTINATARIO.GEDESTIN_NOME_DESTINATARIO, LC06.LC06_PRESTADOR);

            /*" -883- WRITE REG-SI0035B1 FROM LC06 */
            _.Move(LC06.GetMoveValues(), REG_SI0035B1);

            SI0035B1.Write(REG_SI0035B1.GetMoveValues().ToString());

            /*" -885- WRITE REG-SI0035B1 FROM LC00 */
            _.Move(LC00.GetMoveValues(), REG_SI0035B1);

            SI0035B1.Write(REG_SI0035B1.GetMoveValues().ToString());

            /*" -885- ADD 2 TO AC-LINHAS. */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 2;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4100_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -895- CLOSE SI0035B1 */
            SI0035B1.Close();

            /*" -896- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -898- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -900- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -900- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -903- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -904- DISPLAY '***   SI0035B - CANCELADO  ***' */
            _.Display($"***   SI0035B - CANCELADO  ***");

            /*" -906- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -906- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}