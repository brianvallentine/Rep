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
using Sias.Sinistro.DB2.SI0033B;

namespace Code
{
    public class SI0033B
    {
        public bool IsCall { get; set; }

        public SI0033B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-------------------------------------                                  */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................ SINISTRO HABITACIONAL               *      */
        /*"      *   SUBROTINA............... SI0033B                             *      */
        /*"      *   ANALISTA ............... PRODEXTER                           *      */
        /*"      *   PROGRAMADOR ............ PRODEXTER                           *      */
        /*"      *   DATA CODIFICACAO ....... ABR / 2003                          *      */
        /*"      *   FUNCAO ................. RELACAO DE PENDENCIA NO ESTIPULANTE *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 11/07/08 - BRSEG - CAD.12115 - SAC.237                         *      */
        /*"      *            ELIMINAR CARACTERES ESPECIAIS DE CONTROLE DE IMPRES-*      */
        /*"      *            SAO NOS ARQUIVOS.   -   PROCURE: BR.V01             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        /*"      *-------------------------------------                                  */
        #endregion


        #region VARIABLES

        public FileBasis _SI0033B1 { get; set; } = new FileBasis(new PIC("X", "200", "X(200)"));

        public FileBasis SI0033B1
        {
            get
            {
                _.Move(REG_SI0033B1, _SI0033B1); VarBasis.RedefinePassValue(REG_SI0033B1, _SI0033B1, REG_SI0033B1); return _SI0033B1;
            }
        }
        /*"01          REG-SI0033B1         PIC  X(200).*/
        public StringBasis REG_SI0033B1 { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01          HOST-DATA-AVISO      PIC  X(010)   VALUE   SPACES.*/
        public StringBasis HOST_DATA_AVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01          HOST-COUNT           PIC S9(004)   VALUE +0 COMP.*/
        public IntBasis HOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          WS-COD-USUARIO-ANT   PIC  X(008)   VALUE   SPACES.*/
        public StringBasis WS_COD_USUARIO_ANT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"01          WS-COD-DESTINATARIO-ANT                                 PIC S9(004)   VALUE +0 COMP.*/
        public IntBasis WS_COD_DESTINATARIO_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          WS-COD-SUBESTIPULANTE-ANT                                 PIC S9(009)   VALUE +0 COMP.*/
        public IntBasis WS_COD_SUBESTIPULANTE_ANT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01          WS-NATUREZA-SINISTRO-ANT                                 PIC S9(004)   VALUE +0 COMP.*/
        public IntBasis WS_NATUREZA_SINISTRO_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          AREA-DE-WORK.*/
        public SI0033B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SI0033B_AREA_DE_WORK();
        public class SI0033B_AREA_DE_WORK : VarBasis
        {
            /*"  05        AC-L-LISTA           PIC  9(006)   VALUE   ZEROS.*/
            public IntBasis AC_L_LISTA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05        AC-I-SI0033B1        PIC  9(006)   VALUE   ZEROS.*/
            public IntBasis AC_I_SI0033B1 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05        AC-F-SINISTROS       PIC  9(006)   VALUE   ZEROS.*/
            public IntBasis AC_F_SINISTROS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05        AC-A-SINISTROS       PIC  9(006)   VALUE   ZEROS.*/
            public IntBasis AC_A_SINISTROS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05        AC-N-SINISTROS       PIC  9(006)   VALUE   ZEROS.*/
            public IntBasis AC_N_SINISTROS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05        AC-S-SINISTROS       PIC  9(006)   VALUE   ZEROS.*/
            public IntBasis AC_S_SINISTROS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
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
            public SI0033B_DB2_DATA DB2_DATA { get; set; } = new SI0033B_DB2_DATA();
            public class SI0033B_DB2_DATA : VarBasis
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
            public SI0033B_EDIT_DATA EDIT_DATA { get; set; } = new SI0033B_EDIT_DATA();
            public class SI0033B_EDIT_DATA : VarBasis
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
            public SI0033B_ACC_HORA ACC_HORA { get; set; } = new SI0033B_ACC_HORA();
            public class SI0033B_ACC_HORA : VarBasis
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
            public SI0033B_EDIT_HORA EDIT_HORA { get; set; } = new SI0033B_EDIT_HORA();
            public class SI0033B_EDIT_HORA : VarBasis
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
            public SI0033B_WABEND WABEND { get; set; } = new SI0033B_WABEND();
            public class SI0033B_WABEND : VarBasis
            {
                /*"    10      FILLER               PIC  X(010) VALUE           ' SI0033B'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SI0033B");
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
        public SI0033B_LC00 LC00 { get; set; } = new SI0033B_LC00();
        public class SI0033B_LC00 : VarBasis
        {
            /*"  05        LC00-CANAL           PIC  X(001) VALUE ' '.*/
            public StringBasis LC00_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"  05        FILLER               PIC  X(194) VALUE SPACES.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "194", "X(194)"), @"");
            /*"01          LC01.*/
        }
        public SI0033B_LC01 LC01 { get; set; } = new SI0033B_LC01();
        public class SI0033B_LC01 : VarBasis
        {
            /*"  05        LC01-CANAL           PIC  X(001) VALUE '1'.*/
            public StringBasis LC01_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
            /*"  05        FILLER               PIC  X(077) VALUE 'SI0033B'.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "77", "X(077)"), @"SI0033B");
            /*"  05        FILLER               PIC  X(036) VALUE                          'RELATORIO DE PENDENCIAS POR ANALISTA'*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"RELATORIO DE PENDENCIAS POR ANALISTA");
            /*"  05        FILLER               PIC  X(064) VALUE SPACES.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "64", "X(064)"), @"");
            /*"  05        FILLER               PIC  X(013) VALUE 'PAGINA'.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"PAGINA");
            /*"  05        LC01-PAGINA          PIC  ZZZ9.*/
            public IntBasis LC01_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
            /*"01          LC02.*/
        }
        public SI0033B_LC02 LC02 { get; set; } = new SI0033B_LC02();
        public class SI0033B_LC02 : VarBasis
        {
            /*"  05        LC02-CANAL           PIC  X(001) VALUE ' '.*/
            public StringBasis LC02_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"  05        FILLER               PIC  X(076) VALUE SPACES.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "76", "X(076)"), @"");
            /*"  05        FILLER               PIC  X(028) VALUE                                  'PENDENTE NO ESTIPULANTE ATE '*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @"PENDENTE NO ESTIPULANTE ATE ");
            /*"  05        LC02-DATA-MOV-ABERTO PIC  X(010) VALUE SPACES.*/
            public StringBasis LC02_DATA_MOV_ABERTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05        FILLER               PIC  X(063) VALUE SPACES.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "63", "X(063)"), @"");
            /*"  05        FILLER               PIC  X(007) VALUE 'DATA'.*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"DATA");
            /*"  05        LC02-DATA            PIC  X(010) VALUE SPACES.*/
            public StringBasis LC02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"01          LC03.*/
        }
        public SI0033B_LC03 LC03 { get; set; } = new SI0033B_LC03();
        public class SI0033B_LC03 : VarBasis
        {
            /*"  05        LC03-CANAL           PIC  X(001) VALUE ' '.*/
            public StringBasis LC03_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"  05        FILLER               PIC  X(177) VALUE SPACES.*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "177", "X(177)"), @"");
            /*"  05        FILLER               PIC  X(009) VALUE 'HORA'.*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"HORA");
            /*"  05        LC03-HORA            PIC  X(008) VALUE SPACES.*/
            public StringBasis LC03_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"01          LC04.*/
        }
        public SI0033B_LC04 LC04 { get; set; } = new SI0033B_LC04();
        public class SI0033B_LC04 : VarBasis
        {
            /*"  05        LC04-CANAL           PIC  X(001) VALUE ' '.*/
            public StringBasis LC04_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"  05        FILLER               PIC  X(001) VALUE '*'.*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
            /*"  05        FILLER               PIC  X(192) VALUE ALL '-'.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "192", "X(192)"), @"ALL");
            /*"  05        FILLER               PIC  X(001) VALUE '*'.*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
            /*"01          LC05.*/
        }
        public SI0033B_LC05 LC05 { get; set; } = new SI0033B_LC05();
        public class SI0033B_LC05 : VarBasis
        {
            /*"  05        LC05-CANAL           PIC  X(001) VALUE ' '.*/
            public StringBasis LC05_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"  05        FILLER               PIC  X(011) VALUE ' SUBESTIP:'.*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @" SUBESTIP:");
            /*"  05        LC05-COD-SUBESTIP    PIC  ZZZZZZZZ9.*/
            public IntBasis LC05_COD_SUBESTIP { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZZZZ9."));
            /*"  05        FILLER               PIC  X(001) VALUE SPACES.*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05        LC05-NOME-RAZAO      PIC  X(040) VALUE SPACES.*/
            public StringBasis LC05_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"  05        FILLER               PIC  X(133) VALUE SPACES.*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "133", "X(133)"), @"");
            /*"01          LC06.*/
        }
        public SI0033B_LC06 LC06 { get; set; } = new SI0033B_LC06();
        public class SI0033B_LC06 : VarBasis
        {
            /*"  05        LC06-CANAL           PIC  X(001) VALUE ' '.*/
            public StringBasis LC06_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"  05        FILLER               PIC  X(011) VALUE ' ANALISTA:'.*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @" ANALISTA:");
            /*"  05        LC06-ANALISTA        PIC  X(040) VALUE SPACES.*/
            public StringBasis LC06_ANALISTA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"  05        FILLER               PIC  X(143) VALUE SPACES.*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "143", "X(143)"), @"");
            /*"01          LC07.*/
        }
        public SI0033B_LC07 LC07 { get; set; } = new SI0033B_LC07();
        public class SI0033B_LC07 : VarBasis
        {
            /*"  05        LC07-CANAL           PIC  X(001) VALUE ' '.*/
            public StringBasis LC07_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"  05        FILLER               PIC  X(011) VALUE ' FILIAL  :'.*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @" FILIAL  :");
            /*"  05        LC07-FILIAL          PIC  X(040) VALUE SPACES.*/
            public StringBasis LC07_FILIAL { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"  05        FILLER               PIC  X(143) VALUE SPACES.*/
            public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "143", "X(143)"), @"");
            /*"01          LC08.*/
        }
        public SI0033B_LC08 LC08 { get; set; } = new SI0033B_LC08();
        public class SI0033B_LC08 : VarBasis
        {
            /*"  05        LC08-CANAL           PIC  X(001) VALUE ' '.*/
            public StringBasis LC08_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"  05        FILLER               PIC  X(009) VALUE SPACES.*/
            public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
            /*"  05        FILLER               PIC  X(017) VALUE 'PROTOCOLO'.*/
            public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"PROTOCOLO");
            /*"  05        FILLER               PIC  X(020) VALUE                                                  'SINISTRO IRB'*/
            public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"SINISTRO IRB");
            /*"  05        FILLER               PIC  X(048) VALUE                                              'NOME DO SEGURADO'*/
            public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"NOME DO SEGURADO");
            /*"  05        FILLER               PIC  X(012) VALUE 'TIPO'.*/
            public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"TIPO");
            /*"  05        FILLER               PIC  X(021) VALUE                                              'DATA AVISO'.*/
            public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"DATA AVISO");
            /*"  05        FILLER               PIC  X(044) VALUE                                              'ULTIMO STATUS'.*/
            public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "44", "X(044)"), @"ULTIMO STATUS");
            /*"  05        FILLER               PIC  X(015) VALUE                                              'DATA STATUS'.*/
            public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"DATA STATUS");
            /*"  05        FILLER               PIC  X(008) VALUE 'DIAS'.*/
            public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"DIAS");
            /*"01          LD01.*/
        }
        public SI0033B_LD01 LD01 { get; set; } = new SI0033B_LD01();
        public class SI0033B_LD01 : VarBasis
        {
            /*"  05        LD01-CANAL           PIC  X(001) VALUE ' '.*/
            public StringBasis LD01_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"  05        FILLER               PIC  X(006) VALUE SPACES.*/
            public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
            /*"  05        LD01-COD-FONTE       PIC  Z99.*/
            public IntBasis LD01_COD_FONTE { get; set; } = new IntBasis(new PIC("9", "3", "Z99."));
            /*"  05        FILLER               PIC  X(001) VALUE SPACES.*/
            public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05        LD01-NUM-PROTOCOLO   PIC  ZZZZZZZZ9.*/
            public IntBasis LD01_NUM_PROTOCOLO { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZZZZ9."));
            /*"  05        FILLER               PIC  X(001) VALUE '-'.*/
            public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"  05        LD01-DAC-PROTOCOLO   PIC  9.*/
            public IntBasis LD01_DAC_PROTOCOLO { get; set; } = new IntBasis(new PIC("9", "1", "9."));
            /*"  05        FILLER               PIC  X(006) VALUE SPACES.*/
            public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
            /*"  05        LD01-NUM-IRB         PIC  ZZZZZZZZZZ9.*/
            public IntBasis LD01_NUM_IRB { get; set; } = new IntBasis(new PIC("9", "11", "ZZZZZZZZZZ9."));
            /*"  05        FILLER               PIC  X(008) VALUE SPACES.*/
            public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"  05        LD01-NOME-SEGURADO   PIC  X(040) VALUE SPACES.*/
            public StringBasis LD01_NOME_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"  05        FILLER               PIC  X(008) VALUE SPACES.*/
            public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"  05        LD01-TIPO-SINISTRO   PIC  X(003) VALUE SPACES.*/
            public StringBasis LD01_TIPO_SINISTRO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05        FILLER               PIC  X(009) VALUE SPACES.*/
            public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
            /*"  05        LD01-DATA-AVISO      PIC  X(010) VALUE SPACES.*/
            public StringBasis LD01_DATA_AVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05        FILLER               PIC  X(011) VALUE SPACES.*/
            public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"");
            /*"  05        LD01-DESCR-EVENTO    PIC  X(040) VALUE SPACES.*/
            public StringBasis LD01_DESCR_EVENTO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"  05        FILLER               PIC  X(005) VALUE SPACES.*/
            public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
            /*"  05        LD01-DATA-EVENTO     PIC  X(010) VALUE SPACES.*/
            public StringBasis LD01_DATA_EVENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05        FILLER               PIC  X(004) VALUE SPACES.*/
            public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
            /*"  05        LD01-QTD-DIAS        PIC  ZZZ9.*/
            public IntBasis LD01_QTD_DIAS { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
            /*"  05        FILLER               PIC  X(004) VALUE SPACES.*/
            public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
            /*"01          LD02.*/
        }
        public SI0033B_LD02 LD02 { get; set; } = new SI0033B_LD02();
        public class SI0033B_LD02 : VarBasis
        {
            /*"  05        LD02-CANAL           PIC  X(001) VALUE ' '.*/
            public StringBasis LD02_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"  05        FILLER               PIC  X(089) VALUE SPACES.*/
            public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "89", "X(089)"), @"");
            /*"  05        LD02-LITERAL         PIC  X(020) VALUE SPACES.*/
            public StringBasis LD02_LITERAL { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
            /*"  05        FILLER               PIC  X(001) VALUE SPACES.*/
            public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05        LD02-TOTAL           PIC  ZZZZZ9.*/
            public IntBasis LD02_TOTAL { get; set; } = new IntBasis(new PIC("9", "6", "ZZZZZ9."));
            /*"  05        FILLER               PIC  X(078) VALUE SPACES.*/
            public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "78", "X(078)"), @"");
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
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public SI0033B_LISTA LISTA { get; set; } = new SI0033B_LISTA();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SI0033B1_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SI0033B1.SetFile(SI0033B1_FILE_NAME_P);

                /*" -247- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -247- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -248- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -249- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -249- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -257- OPEN OUTPUT SI0033B1 */
            SI0033B1.Open(REG_SI0033B1);

            /*" -259- PERFORM R0500-00-LE-SISTEMAS */

            R0500_00_LE_SISTEMAS_SECTION();

            /*" -261- PERFORM R0600-00-LE-RELATORIOS */

            R0600_00_LE_RELATORIOS_SECTION();

            /*" -262- IF WFIM-RELATORI EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_RELATORI == "S")
            {

                /*" -263- DISPLAY '******************************************' */
                _.Display($"******************************************");

                /*" -264- DISPLAY '* NAO HOUVE SOLICITACAO PARA O RELATORIO *' */
                _.Display($"* NAO HOUVE SOLICITACAO PARA O RELATORIO *");

                /*" -265- DISPLAY '******************************************' */
                _.Display($"******************************************");

                /*" -266- DISPLAY ' ' */
                _.Display($" ");

                /*" -268- GO TO R0000-90-ENCERRA. */

                R0000_90_ENCERRA(); //GOTO
                return;
            }


            /*" -269- PERFORM R0900-00-DECLARA-LISTA */

            R0900_00_DECLARA_LISTA_SECTION();

            /*" -271- PERFORM R0910-00-LE-LISTA */

            R0910_00_LE_LISTA_SECTION();

            /*" -272- IF WFIM-LISTA EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_LISTA == "S")
            {

                /*" -279- GO TO R0000-90-ENCERRA. */

                R0000_90_ENCERRA(); //GOTO
                return;
            }


            /*" -282- PERFORM R1000-00-PROCESSA UNTIL WFIM-LISTA EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_LISTA == "S"))
            {

                R1000_00_PROCESSA_SECTION();
            }

            /*" -287- PERFORM R0800-00-TOTAL-GERAL */

            R0800_00_TOTAL_GERAL_SECTION();

            /*" -287- PERFORM R0700-00-ALTERA-RELATORIOS. */

            R0700_00_ALTERA_RELATORIOS_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_ENCERRA */

            R0000_90_ENCERRA();

        }

        [StopWatch]
        /*" R0000-90-ENCERRA */
        private void R0000_90_ENCERRA(bool isPerform = false)
        {
            /*" -293- CLOSE SI0033B1 */
            SI0033B1.Close();

            /*" -295- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -296- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -297- DISPLAY '***   SI0033B - FIM NORMAL ***' */
            _.Display($"***   SI0033B - FIM NORMAL ***");

            /*" -298- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -299- DISPLAY 'LIDOS      SIDOCACO  -  ' AC-L-LISTA */
            _.Display($"LIDOS      SIDOCACO  -  {AREA_DE_WORK.AC_L_LISTA}");

            /*" -301- DISPLAY 'IMPRESSOS  SI0033B1  -  ' AC-I-SI0033B1 */
            _.Display($"IMPRESSOS  SI0033B1  -  {AREA_DE_WORK.AC_I_SI0033B1}");

            /*" -301- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0500-00-LE-SISTEMAS-SECTION */
        private void R0500_00_LE_SISTEMAS_SECTION()
        {
            /*" -309- MOVE '050' TO WNR-EXEC-SQL. */
            _.Move("050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -314- PERFORM R0500_00_LE_SISTEMAS_DB_SELECT_1 */

            R0500_00_LE_SISTEMAS_DB_SELECT_1();

            /*" -317- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -318- DISPLAY 'SI0033B - PROBLEMAS NO SELECT SISTEMAS' */
                _.Display($"SI0033B - PROBLEMAS NO SELECT SISTEMAS");

                /*" -318- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0500-00-LE-SISTEMAS-DB-SELECT-1 */
        public void R0500_00_LE_SISTEMAS_DB_SELECT_1()
        {
            /*" -314- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' END-EXEC. */

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
            /*" -328- MOVE '060' TO WNR-EXEC-SQL. */
            _.Move("060", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -336- PERFORM R0600_00_LE_RELATORIOS_DB_SELECT_1 */

            R0600_00_LE_RELATORIOS_DB_SELECT_1();

            /*" -339- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -340- MOVE 'S' TO WFIM-RELATORI */
                _.Move("S", AREA_DE_WORK.WFIM_RELATORI);

                /*" -341- ELSE */
            }
            else
            {


                /*" -342- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -343- DISPLAY 'SI0033B - PROBLEMAS NO SELECT RELATORIOS' */
                    _.Display($"SI0033B - PROBLEMAS NO SELECT RELATORIOS");

                    /*" -343- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0600-00-LE-RELATORIOS-DB-SELECT-1 */
        public void R0600_00_LE_RELATORIOS_DB_SELECT_1()
        {
            /*" -336- EXEC SQL SELECT COD_USUARIO INTO :RELATORI-COD-USUARIO FROM SEGUROS.RELATORIOS WHERE COD_RELATORIO = 'SI0033B' AND IDE_SISTEMA = 'SI' AND DATA_SOLICITACAO = :SISTEMAS-DATA-MOV-ABERTO AND SIT_REGISTRO = '0' END-EXEC. */

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
            /*" -353- MOVE '070' TO WNR-EXEC-SQL. */
            _.Move("070", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -360- PERFORM R0700_00_ALTERA_RELATORIOS_DB_UPDATE_1 */

            R0700_00_ALTERA_RELATORIOS_DB_UPDATE_1();

            /*" -363- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -364- DISPLAY 'SI0033B - PROBLEMAS NO UPDATE RELATORIOS' */
                _.Display($"SI0033B - PROBLEMAS NO UPDATE RELATORIOS");

                /*" -364- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0700-00-ALTERA-RELATORIOS-DB-UPDATE-1 */
        public void R0700_00_ALTERA_RELATORIOS_DB_UPDATE_1()
        {
            /*" -360- EXEC SQL UPDATE SEGUROS.RELATORIOS SET SIT_REGISTRO = '1' WHERE COD_RELATORIO = 'SI0033B' AND IDE_SISTEMA = 'SI' AND DATA_SOLICITACAO = :SISTEMAS-DATA-MOV-ABERTO AND SIT_REGISTRO = '0' END-EXEC. */

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
            /*" -374- MOVE '080' TO WNR-EXEC-SQL. */
            _.Move("080", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -375- IF AC-LINHAS GREATER 55 */

            if (AREA_DE_WORK.AC_LINHAS > 55)
            {

                /*" -377- PERFORM R6000-00-CABECALHO. */

                R6000_00_CABECALHO_SECTION();
            }


            /*" -378- MOVE 'TOTAL GERAL.........' TO LD02-LITERAL */
            _.Move("TOTAL GERAL.........", LD02.LD02_LITERAL);

            /*" -380- MOVE AC-G-SINISTROS TO LD02-TOTAL */
            _.Move(AREA_DE_WORK.AC_G_SINISTROS, LD02.LD02_TOTAL);

            /*" -381- WRITE REG-SI0033B1 FROM LC00 */
            _.Move(LC00.GetMoveValues(), REG_SI0033B1);

            SI0033B1.Write(REG_SI0033B1.GetMoveValues().ToString());

            /*" -382- WRITE REG-SI0033B1 FROM LD02 */
            _.Move(LD02.GetMoveValues(), REG_SI0033B1);

            SI0033B1.Write(REG_SI0033B1.GetMoveValues().ToString());

            /*" -382- ADD 2 TO AC-LINHAS. */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 2;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARA-LISTA-SECTION */
        private void R0900_00_DECLARA_LISTA_SECTION()
        {
            /*" -392- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -479- PERFORM R0900_00_DECLARA_LISTA_DB_DECLARE_1 */

            R0900_00_DECLARA_LISTA_DB_DECLARE_1();

            /*" -481- PERFORM R0900_00_DECLARA_LISTA_DB_OPEN_1 */

            R0900_00_DECLARA_LISTA_DB_OPEN_1();

            /*" -484- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -486- DISPLAY 'SI0033B - PROBLEMAS NO OPEN LISTA ' ' ' SISTEMAS-DATA-MOV-ABERTO */

                $"SI0033B - PROBLEMAS NO OPEN LISTA  {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}"
                .Display();

                /*" -486- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARA-LISTA-DB-DECLARE-1 */
        public void R0900_00_DECLARA_LISTA_DB_DECLARE_1()
        {
            /*" -479- EXEC SQL DECLARE LISTA CURSOR FOR SELECT E.COD_USUARIO, C.COD_TIPO_CARTA, A.DESCR_EVENTO, B.COD_FONTE, B.NUM_PROTOCOLO_SINI, B.DAC_PROTOCOLO_SINI, B.DATA_MOVTO_DOCACO, D.COD_SUBESTIPULANTE, D.NATUREZA_SINISTRO, D.NOME_SEGURADO, D.COD_GIAFI, I.COD_DESTINATARIO FROM SEGUROS.SI_EVENTO_TIPO A, SEGUROS.SI_DOCUMENTO_ACOMP B, SEGUROS.SI_DOCUMENTO_PARAM C, SEGUROS.SI_MOVIMENTO_SINI D, SEGUROS.SI_ANALISTA_RODIZI E, SEGUROS.SI_SINISTRO_FASE G, SEGUROS.GE_REL_CARTA_DEST I WHERE C.COD_TIPO_CARTA = A.COD_TIPO_CARTA AND B.COD_PRODUTO = C.COD_PRODUTO AND B.COD_GRUPO_CAUSA = C.COD_GRUPO_CAUSA AND B.COD_SUBGRUPO_CAUSA = C.COD_SUBGRUPO_CAUSA AND B.COD_DOCUMENTO = C.COD_DOCUMENTO AND B.DATA_INIVIG_DOCPAR = C.DATA_INIVIG_DOCPAR AND B.COD_FONTE = D.COD_FONTE AND B.NUM_PROTOCOLO_SINI = D.NUM_PROTOCOLO_SINI AND B.DAC_PROTOCOLO_SINI = D.DAC_PROTOCOLO_SINI AND B.COD_FONTE = E.COD_FONTE AND B.NUM_PROTOCOLO_SINI = E.NUM_PROTOCOLO_SINI AND B.DAC_PROTOCOLO_SINI = E.DAC_PROTOCOLO_SINI AND B.COD_FONTE = G.COD_FONTE AND B.NUM_PROTOCOLO_SINI = G.NUM_PROTOCOLO_SINI AND B.DAC_PROTOCOLO_SINI = G.DAC_PROTOCOLO_SINI AND G.COD_FASE NOT IN (3, 4) AND G.NUM_OCORR_SINIACO = (SELECT MAX(H.NUM_OCORR_SINIACO) FROM SEGUROS.SI_SINISTRO_FASE H WHERE H.COD_FONTE = G.COD_FONTE AND H.NUM_PROTOCOLO_SINI = G.NUM_PROTOCOLO_SINI AND H.DAC_PROTOCOLO_SINI = G.DAC_PROTOCOLO_SINI AND H.DATA_ABERTURA_SIFA <= :SISTEMAS-DATA-MOV-ABERTO) AND B.NUM_CARTA IS NOT NULL AND B.NUM_CARTA = I.NUM_CARTA AND C.COD_TIPO_CARTA IN (2, 27, 28) AND B.COD_EVENTO IN (2012, 2013) AND B.NUM_OCORR_DOCACO = (SELECT MAX(F.NUM_OCORR_DOCACO) FROM SEGUROS.SI_DOCUMENTO_ACOMP F WHERE F.COD_FONTE = B.COD_FONTE AND F.NUM_PROTOCOLO_SINI = B.NUM_PROTOCOLO_SINI AND F.DAC_PROTOCOLO_SINI = B.DAC_PROTOCOLO_SINI AND F.COD_DOCUMENTO = B.COD_DOCUMENTO AND F.DATA_MOVTO_DOCACO <= :SISTEMAS-DATA-MOV-ABERTO) AND NOT EXISTS (SELECT (X.NUM_OCORR_DOCACO) FROM SEGUROS.SI_DOCUMENTO_ACOMP X WHERE X.COD_FONTE = B.COD_FONTE AND X.NUM_PROTOCOLO_SINI = B.NUM_PROTOCOLO_SINI AND X.DAC_PROTOCOLO_SINI = B.DAC_PROTOCOLO_SINI AND X.COD_DOCUMENTO = B.COD_DOCUMENTO AND X.DATA_INIVIG_DOCPAR = B.DATA_INIVIG_DOCPAR AND X.COD_EVENTO IN (2010, 2011)) GROUP BY E.COD_USUARIO, C.COD_TIPO_CARTA, A.DESCR_EVENTO, B.COD_FONTE, B.NUM_PROTOCOLO_SINI, B.DAC_PROTOCOLO_SINI, B.DATA_MOVTO_DOCACO, D.COD_SUBESTIPULANTE, D.NATUREZA_SINISTRO, D.NOME_SEGURADO, D.COD_GIAFI, I.COD_DESTINATARIO ORDER BY D.COD_SUBESTIPULANTE, D.NATUREZA_SINISTRO, E.COD_USUARIO, I.COD_DESTINATARIO, C.COD_TIPO_CARTA, B.DATA_MOVTO_DOCACO, B.COD_FONTE, B.NUM_PROTOCOLO_SINI END-EXEC. */
            LISTA = new SI0033B_LISTA(true);
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
							D.COD_SUBESTIPULANTE
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
							AND C.COD_TIPO_CARTA IN (2
							, 27
							, 28) 
							AND B.COD_EVENTO IN (2012
							, 2013) 
							AND B.NUM_OCORR_DOCACO = 
							(SELECT MAX(F.NUM_OCORR_DOCACO) 
							FROM SEGUROS.SI_DOCUMENTO_ACOMP F 
							WHERE F.COD_FONTE = B.COD_FONTE 
							AND F.NUM_PROTOCOLO_SINI = B.NUM_PROTOCOLO_SINI 
							AND F.DAC_PROTOCOLO_SINI = B.DAC_PROTOCOLO_SINI 
							AND F.COD_DOCUMENTO = B.COD_DOCUMENTO 
							AND F.DATA_MOVTO_DOCACO <= 
							'{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}') 
							AND NOT EXISTS 
							(SELECT (X.NUM_OCORR_DOCACO) 
							FROM SEGUROS.SI_DOCUMENTO_ACOMP X 
							WHERE X.COD_FONTE = B.COD_FONTE 
							AND X.NUM_PROTOCOLO_SINI = B.NUM_PROTOCOLO_SINI 
							AND X.DAC_PROTOCOLO_SINI = B.DAC_PROTOCOLO_SINI 
							AND X.COD_DOCUMENTO = B.COD_DOCUMENTO 
							AND X.DATA_INIVIG_DOCPAR = B.DATA_INIVIG_DOCPAR 
							AND X.COD_EVENTO IN (2010
							, 2011)) 
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
							D.COD_SUBESTIPULANTE
							, 
							D.NATUREZA_SINISTRO
							, 
							D.NOME_SEGURADO
							, 
							D.COD_GIAFI
							, 
							I.COD_DESTINATARIO 
							ORDER BY D.COD_SUBESTIPULANTE
							, 
							D.NATUREZA_SINISTRO
							, 
							E.COD_USUARIO
							, 
							I.COD_DESTINATARIO
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
            /*" -481- EXEC SQL OPEN LISTA END-EXEC. */

            LISTA.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-LE-LISTA-SECTION */
        private void R0910_00_LE_LISTA_SECTION()
        {
            /*" -496- MOVE '091' TO WNR-EXEC-SQL. */
            _.Move("091", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -509- PERFORM R0910_00_LE_LISTA_DB_FETCH_1 */

            R0910_00_LE_LISTA_DB_FETCH_1();

            /*" -512- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -513- ADD 1 TO AC-L-LISTA */
                AREA_DE_WORK.AC_L_LISTA.Value = AREA_DE_WORK.AC_L_LISTA + 1;

                /*" -514- ELSE */
            }
            else
            {


                /*" -515- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -516- MOVE 'S' TO WFIM-LISTA */
                    _.Move("S", AREA_DE_WORK.WFIM_LISTA);

                    /*" -516- PERFORM R0910_00_LE_LISTA_DB_CLOSE_1 */

                    R0910_00_LE_LISTA_DB_CLOSE_1();

                    /*" -518- ELSE */
                }
                else
                {


                    /*" -520- DISPLAY 'SI0033B - PROBLEMAS NO FETCH LISTA ' ' ' SISTEMAS-DATA-MOV-ABERTO */

                    $"SI0033B - PROBLEMAS NO FETCH LISTA  {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}"
                    .Display();

                    /*" -520- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0910-00-LE-LISTA-DB-FETCH-1 */
        public void R0910_00_LE_LISTA_DB_FETCH_1()
        {
            /*" -509- EXEC SQL FETCH LISTA INTO :SIANAROD-COD-USUARIO, :SIDOCPAR-COD-TIPO-CARTA, :SIEVETIP-DESCR-EVENTO, :SIDOCACO-COD-FONTE, :SIDOCACO-NUM-PROTOCOLO-SINI, :SIDOCACO-DAC-PROTOCOLO-SINI, :SIDOCACO-DATA-MOVTO-DOCACO, :SIMOVSIN-COD-SUBESTIPULANTE, :SIMOVSIN-NATUREZA-SINISTRO, :SIMOVSIN-NOME-SEGURADO, :SIMOVSIN-COD-GIAFI, :GERECADE-COD-DESTINATARIO END-EXEC. */

            if (LISTA.Fetch())
            {
                _.Move(LISTA.SIANAROD_COD_USUARIO, SIANAROD.DCLSI_ANALISTA_RODIZI.SIANAROD_COD_USUARIO);
                _.Move(LISTA.SIDOCPAR_COD_TIPO_CARTA, SIDOCPAR.DCLSI_DOCUMENTO_PARAM.SIDOCPAR_COD_TIPO_CARTA);
                _.Move(LISTA.SIEVETIP_DESCR_EVENTO, SIEVETIP.DCLSI_EVENTO_TIPO.SIEVETIP_DESCR_EVENTO);
                _.Move(LISTA.SIDOCACO_COD_FONTE, SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_FONTE);
                _.Move(LISTA.SIDOCACO_NUM_PROTOCOLO_SINI, SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_PROTOCOLO_SINI);
                _.Move(LISTA.SIDOCACO_DAC_PROTOCOLO_SINI, SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DAC_PROTOCOLO_SINI);
                _.Move(LISTA.SIDOCACO_DATA_MOVTO_DOCACO, SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DATA_MOVTO_DOCACO);
                _.Move(LISTA.SIMOVSIN_COD_SUBESTIPULANTE, SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_COD_SUBESTIPULANTE);
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
            /*" -516- EXEC SQL CLOSE LISTA END-EXEC */

            LISTA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-SECTION */
        private void R1000_00_PROCESSA_SECTION()
        {
            /*" -530- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -532- PERFORM R1100-00-LE-CLIENTES */

            R1100_00_LE_CLIENTES_SECTION();

            /*" -536- MOVE SIMOVSIN-COD-SUBESTIPULANTE TO WS-COD-SUBESTIPULANTE-ANT */
            _.Move(SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_COD_SUBESTIPULANTE, WS_COD_SUBESTIPULANTE_ANT);

            /*" -542- PERFORM R2000-00-PROCESSA-SUBESTIP UNTIL WFIM-LISTA EQUAL 'S' OR SIMOVSIN-COD-SUBESTIPULANTE NOT EQUAL WS-COD-SUBESTIPULANTE-ANT */

            while (!(AREA_DE_WORK.WFIM_LISTA == "S" || SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_COD_SUBESTIPULANTE != WS_COD_SUBESTIPULANTE_ANT))
            {

                R2000_00_PROCESSA_SUBESTIP_SECTION();
            }

            /*" -542- PERFORM R1900-00-TOTAL-SUBESTIP. */

            R1900_00_TOTAL_SUBESTIP_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-LE-CLIENTES-SECTION */
        private void R1100_00_LE_CLIENTES_SECTION()
        {
            /*" -552- MOVE '110' TO WNR-EXEC-SQL. */
            _.Move("110", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -558- PERFORM R1100_00_LE_CLIENTES_DB_SELECT_1 */

            R1100_00_LE_CLIENTES_DB_SELECT_1();

            /*" -561- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -562- DISPLAY 'SI0033B - PROBLEMAS NO SELECT CLIENTES' */
                _.Display($"SI0033B - PROBLEMAS NO SELECT CLIENTES");

                /*" -566- DISPLAY ' ' SIDOCACO-COD-FONTE ' ' SIDOCACO-NUM-PROTOCOLO-SINI ' ' SIDOCACO-DAC-PROTOCOLO-SINI ' ' SIMOVSIN-COD-SUBESTIPULANTE */

                $" {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_FONTE} {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_PROTOCOLO_SINI} {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DAC_PROTOCOLO_SINI} {SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_COD_SUBESTIPULANTE}"
                .Display();

                /*" -566- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1100-00-LE-CLIENTES-DB-SELECT-1 */
        public void R1100_00_LE_CLIENTES_DB_SELECT_1()
        {
            /*" -558- EXEC SQL SELECT NOME_RAZAO INTO :CLIENTES-NOME-RAZAO FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :SIMOVSIN-COD-SUBESTIPULANTE END-EXEC. */

            var r1100_00_LE_CLIENTES_DB_SELECT_1_Query1 = new R1100_00_LE_CLIENTES_DB_SELECT_1_Query1()
            {
                SIMOVSIN_COD_SUBESTIPULANTE = SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_COD_SUBESTIPULANTE.ToString(),
            };

            var executed_1 = R1100_00_LE_CLIENTES_DB_SELECT_1_Query1.Execute(r1100_00_LE_CLIENTES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1900-00-TOTAL-SUBESTIP-SECTION */
        private void R1900_00_TOTAL_SUBESTIP_SECTION()
        {
            /*" -576- MOVE '190' TO WNR-EXEC-SQL. */
            _.Move("190", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -577- IF AC-LINHAS GREATER 55 */

            if (AREA_DE_WORK.AC_LINHAS > 55)
            {

                /*" -579- PERFORM R6000-00-CABECALHO. */

                R6000_00_CABECALHO_SECTION();
            }


            /*" -580- MOVE 'TOTAL DO SUBESTIP...' TO LD02-LITERAL */
            _.Move("TOTAL DO SUBESTIP...", LD02.LD02_LITERAL);

            /*" -582- MOVE AC-S-SINISTROS TO LD02-TOTAL */
            _.Move(AREA_DE_WORK.AC_S_SINISTROS, LD02.LD02_TOTAL);

            /*" -583- WRITE REG-SI0033B1 FROM LC00 */
            _.Move(LC00.GetMoveValues(), REG_SI0033B1);

            SI0033B1.Write(REG_SI0033B1.GetMoveValues().ToString());

            /*" -584- WRITE REG-SI0033B1 FROM LD02 */
            _.Move(LD02.GetMoveValues(), REG_SI0033B1);

            SI0033B1.Write(REG_SI0033B1.GetMoveValues().ToString());

            /*" -586- ADD 2 TO AC-LINHAS */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 2;

            /*" -587- ADD AC-S-SINISTROS TO AC-G-SINISTROS */
            AREA_DE_WORK.AC_G_SINISTROS.Value = AREA_DE_WORK.AC_G_SINISTROS + AREA_DE_WORK.AC_S_SINISTROS;

            /*" -587- MOVE ZEROS TO AC-S-SINISTROS. */
            _.Move(0, AREA_DE_WORK.AC_S_SINISTROS);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-PROCESSA-SUBESTIP-SECTION */
        private void R2000_00_PROCESSA_SUBESTIP_SECTION()
        {
            /*" -597- MOVE '200' TO WNR-EXEC-SQL. */
            _.Move("200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -601- MOVE SIMOVSIN-NATUREZA-SINISTRO TO WS-NATUREZA-SINISTRO-ANT */
            _.Move(SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_NATUREZA_SINISTRO, WS_NATUREZA_SINISTRO_ANT);

            /*" -610- PERFORM R3000-00-PROCESSA-NATUREZA UNTIL WFIM-LISTA EQUAL 'S' OR SIMOVSIN-COD-SUBESTIPULANTE NOT EQUAL WS-COD-SUBESTIPULANTE-ANT OR SIMOVSIN-NATUREZA-SINISTRO NOT EQUAL WS-NATUREZA-SINISTRO-ANT */

            while (!(AREA_DE_WORK.WFIM_LISTA == "S" || SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_COD_SUBESTIPULANTE != WS_COD_SUBESTIPULANTE_ANT || SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_NATUREZA_SINISTRO != WS_NATUREZA_SINISTRO_ANT))
            {

                R3000_00_PROCESSA_NATUREZA_SECTION();
            }

            /*" -610- PERFORM R2900-00-TOTAL-NATUREZA. */

            R2900_00_TOTAL_NATUREZA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2900-00-TOTAL-NATUREZA-SECTION */
        private void R2900_00_TOTAL_NATUREZA_SECTION()
        {
            /*" -620- MOVE '290' TO WNR-EXEC-SQL. */
            _.Move("290", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -621- IF AC-LINHAS GREATER 55 */

            if (AREA_DE_WORK.AC_LINHAS > 55)
            {

                /*" -623- PERFORM R6000-00-CABECALHO. */

                R6000_00_CABECALHO_SECTION();
            }


            /*" -624- MOVE 'TOTAL DA NATUREZA...' TO LD02-LITERAL */
            _.Move("TOTAL DA NATUREZA...", LD02.LD02_LITERAL);

            /*" -626- MOVE AC-N-SINISTROS TO LD02-TOTAL */
            _.Move(AREA_DE_WORK.AC_N_SINISTROS, LD02.LD02_TOTAL);

            /*" -627- WRITE REG-SI0033B1 FROM LC00 */
            _.Move(LC00.GetMoveValues(), REG_SI0033B1);

            SI0033B1.Write(REG_SI0033B1.GetMoveValues().ToString());

            /*" -628- WRITE REG-SI0033B1 FROM LD02 */
            _.Move(LD02.GetMoveValues(), REG_SI0033B1);

            SI0033B1.Write(REG_SI0033B1.GetMoveValues().ToString());

            /*" -630- ADD 2 TO AC-LINHAS */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 2;

            /*" -631- ADD AC-N-SINISTROS TO AC-S-SINISTROS */
            AREA_DE_WORK.AC_S_SINISTROS.Value = AREA_DE_WORK.AC_S_SINISTROS + AREA_DE_WORK.AC_N_SINISTROS;

            /*" -631- MOVE ZEROS TO AC-N-SINISTROS. */
            _.Move(0, AREA_DE_WORK.AC_N_SINISTROS);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2900_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-PROCESSA-NATUREZA-SECTION */
        private void R3000_00_PROCESSA_NATUREZA_SECTION()
        {
            /*" -641- MOVE '300' TO WNR-EXEC-SQL. */
            _.Move("300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -643- MOVE 80 TO AC-LINHAS */
            _.Move(80, AREA_DE_WORK.AC_LINHAS);

            /*" -645- PERFORM R3100-00-LE-USUARIOS */

            R3100_00_LE_USUARIOS_SECTION();

            /*" -647- MOVE SIANAROD-COD-USUARIO TO WS-COD-USUARIO-ANT */
            _.Move(SIANAROD.DCLSI_ANALISTA_RODIZI.SIANAROD_COD_USUARIO, WS_COD_USUARIO_ANT);

            /*" -658- PERFORM R4000-00-PROCESSA-ANALISTA UNTIL WFIM-LISTA EQUAL 'S' OR SIMOVSIN-COD-SUBESTIPULANTE NOT EQUAL WS-COD-SUBESTIPULANTE-ANT OR SIMOVSIN-NATUREZA-SINISTRO NOT EQUAL WS-NATUREZA-SINISTRO-ANT OR SIANAROD-COD-USUARIO NOT EQUAL WS-COD-USUARIO-ANT */

            while (!(AREA_DE_WORK.WFIM_LISTA == "S" || SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_COD_SUBESTIPULANTE != WS_COD_SUBESTIPULANTE_ANT || SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_NATUREZA_SINISTRO != WS_NATUREZA_SINISTRO_ANT || SIANAROD.DCLSI_ANALISTA_RODIZI.SIANAROD_COD_USUARIO != WS_COD_USUARIO_ANT))
            {

                R4000_00_PROCESSA_ANALISTA_SECTION();
            }

            /*" -658- PERFORM R3900-00-TOTAL-ANALISTA. */

            R3900_00_TOTAL_ANALISTA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-LE-USUARIOS-SECTION */
        private void R3100_00_LE_USUARIOS_SECTION()
        {
            /*" -668- MOVE '310' TO WNR-EXEC-SQL. */
            _.Move("310", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -673- PERFORM R3100_00_LE_USUARIOS_DB_SELECT_1 */

            R3100_00_LE_USUARIOS_DB_SELECT_1();

            /*" -676- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -677- DISPLAY 'SI0033B - PROBLEMAS NO SELECT USUARIOS' */
                _.Display($"SI0033B - PROBLEMAS NO SELECT USUARIOS");

                /*" -681- DISPLAY ' ' SIDOCACO-COD-FONTE ' ' SIDOCACO-NUM-PROTOCOLO-SINI ' ' SIDOCACO-DAC-PROTOCOLO-SINI ' ' SIANAROD-COD-USUARIO */

                $" {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_FONTE} {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_PROTOCOLO_SINI} {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DAC_PROTOCOLO_SINI} {SIANAROD.DCLSI_ANALISTA_RODIZI.SIANAROD_COD_USUARIO}"
                .Display();

                /*" -681- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3100-00-LE-USUARIOS-DB-SELECT-1 */
        public void R3100_00_LE_USUARIOS_DB_SELECT_1()
        {
            /*" -673- EXEC SQL SELECT NOME_USUARIO INTO :USUARIOS-NOME-USUARIO FROM SEGUROS.USUARIOS WHERE COD_USUARIO = :SIANAROD-COD-USUARIO END-EXEC. */

            var r3100_00_LE_USUARIOS_DB_SELECT_1_Query1 = new R3100_00_LE_USUARIOS_DB_SELECT_1_Query1()
            {
                SIANAROD_COD_USUARIO = SIANAROD.DCLSI_ANALISTA_RODIZI.SIANAROD_COD_USUARIO.ToString(),
            };

            var executed_1 = R3100_00_LE_USUARIOS_DB_SELECT_1_Query1.Execute(r3100_00_LE_USUARIOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.USUARIOS_NOME_USUARIO, USUARIOS.DCLUSUARIOS.USUARIOS_NOME_USUARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R3900-00-TOTAL-ANALISTA-SECTION */
        private void R3900_00_TOTAL_ANALISTA_SECTION()
        {
            /*" -691- MOVE '390' TO WNR-EXEC-SQL. */
            _.Move("390", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -692- IF AC-LINHAS GREATER 55 */

            if (AREA_DE_WORK.AC_LINHAS > 55)
            {

                /*" -694- PERFORM R6000-00-CABECALHO. */

                R6000_00_CABECALHO_SECTION();
            }


            /*" -695- MOVE 'TOTAL DO ANALISTA...' TO LD02-LITERAL */
            _.Move("TOTAL DO ANALISTA...", LD02.LD02_LITERAL);

            /*" -697- MOVE AC-A-SINISTROS TO LD02-TOTAL */
            _.Move(AREA_DE_WORK.AC_A_SINISTROS, LD02.LD02_TOTAL);

            /*" -698- WRITE REG-SI0033B1 FROM LC00 */
            _.Move(LC00.GetMoveValues(), REG_SI0033B1);

            SI0033B1.Write(REG_SI0033B1.GetMoveValues().ToString());

            /*" -699- WRITE REG-SI0033B1 FROM LD02 */
            _.Move(LD02.GetMoveValues(), REG_SI0033B1);

            SI0033B1.Write(REG_SI0033B1.GetMoveValues().ToString());

            /*" -701- ADD 2 TO AC-LINHAS */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 2;

            /*" -702- ADD AC-A-SINISTROS TO AC-N-SINISTROS */
            AREA_DE_WORK.AC_N_SINISTROS.Value = AREA_DE_WORK.AC_N_SINISTROS + AREA_DE_WORK.AC_A_SINISTROS;

            /*" -702- MOVE ZEROS TO AC-A-SINISTROS. */
            _.Move(0, AREA_DE_WORK.AC_A_SINISTROS);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3900_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-PROCESSA-ANALISTA-SECTION */
        private void R4000_00_PROCESSA_ANALISTA_SECTION()
        {
            /*" -712- MOVE '400' TO WNR-EXEC-SQL. */
            _.Move("400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -714- PERFORM R4100-00-LE-GEDESTIN */

            R4100_00_LE_GEDESTIN_SECTION();

            /*" -717- MOVE GERECADE-COD-DESTINATARIO TO WS-COD-DESTINATARIO-ANT */
            _.Move(GERECADE.DCLGE_REL_CARTA_DEST.GERECADE_COD_DESTINATARIO, WS_COD_DESTINATARIO_ANT);

            /*" -718- IF AC-LINHAS GREATER 55 */

            if (AREA_DE_WORK.AC_LINHAS > 55)
            {

                /*" -719- PERFORM R6000-00-CABECALHO */

                R6000_00_CABECALHO_SECTION();

                /*" -720- PERFORM R6100-00-CABECALHO-FILIAL */

                R6100_00_CABECALHO_FILIAL_SECTION();

                /*" -721- ELSE */
            }
            else
            {


                /*" -723- PERFORM R6100-00-CABECALHO-FILIAL. */

                R6100_00_CABECALHO_FILIAL_SECTION();
            }


            /*" -738- PERFORM R5000-00-PROCESSA-FILIAL UNTIL WFIM-LISTA EQUAL 'S' OR SIMOVSIN-COD-SUBESTIPULANTE NOT EQUAL WS-COD-SUBESTIPULANTE-ANT OR SIMOVSIN-NATUREZA-SINISTRO NOT EQUAL WS-NATUREZA-SINISTRO-ANT OR SIANAROD-COD-USUARIO NOT EQUAL WS-COD-USUARIO-ANT OR GERECADE-COD-DESTINATARIO NOT EQUAL WS-COD-DESTINATARIO-ANT */

            while (!(AREA_DE_WORK.WFIM_LISTA == "S" || SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_COD_SUBESTIPULANTE != WS_COD_SUBESTIPULANTE_ANT || SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_NATUREZA_SINISTRO != WS_NATUREZA_SINISTRO_ANT || SIANAROD.DCLSI_ANALISTA_RODIZI.SIANAROD_COD_USUARIO != WS_COD_USUARIO_ANT || GERECADE.DCLGE_REL_CARTA_DEST.GERECADE_COD_DESTINATARIO != WS_COD_DESTINATARIO_ANT))
            {

                R5000_00_PROCESSA_FILIAL_SECTION();
            }

            /*" -738- PERFORM R4900-00-TOTAL-FILIAL. */

            R4900_00_TOTAL_FILIAL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R4100-00-LE-GEDESTIN-SECTION */
        private void R4100_00_LE_GEDESTIN_SECTION()
        {
            /*" -748- MOVE '410' TO WNR-EXEC-SQL. */
            _.Move("410", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -754- PERFORM R4100_00_LE_GEDESTIN_DB_SELECT_1 */

            R4100_00_LE_GEDESTIN_DB_SELECT_1();

            /*" -757- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -758- DISPLAY 'SI0033B - PROBLEMAS NO SELECT GE_DESTINATARIO' */
                _.Display($"SI0033B - PROBLEMAS NO SELECT GE_DESTINATARIO");

                /*" -762- DISPLAY ' ' SIDOCACO-COD-FONTE ' ' SIDOCACO-NUM-PROTOCOLO-SINI ' ' SIDOCACO-DAC-PROTOCOLO-SINI ' ' GERECADE-COD-DESTINATARIO */

                $" {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_FONTE} {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_PROTOCOLO_SINI} {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DAC_PROTOCOLO_SINI} {GERECADE.DCLGE_REL_CARTA_DEST.GERECADE_COD_DESTINATARIO}"
                .Display();

                /*" -762- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4100-00-LE-GEDESTIN-DB-SELECT-1 */
        public void R4100_00_LE_GEDESTIN_DB_SELECT_1()
        {
            /*" -754- EXEC SQL SELECT NOME_DESTINATARIO INTO :GEDESTIN-NOME-DESTINATARIO FROM SEGUROS.GE_DESTINATARIO WHERE COD_DESTINATARIO = :GERECADE-COD-DESTINATARIO END-EXEC. */

            var r4100_00_LE_GEDESTIN_DB_SELECT_1_Query1 = new R4100_00_LE_GEDESTIN_DB_SELECT_1_Query1()
            {
                GERECADE_COD_DESTINATARIO = GERECADE.DCLGE_REL_CARTA_DEST.GERECADE_COD_DESTINATARIO.ToString(),
            };

            var executed_1 = R4100_00_LE_GEDESTIN_DB_SELECT_1_Query1.Execute(r4100_00_LE_GEDESTIN_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GEDESTIN_NOME_DESTINATARIO, GEDESTIN.DCLGE_DESTINATARIO.GEDESTIN_NOME_DESTINATARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4100_99_SAIDA*/

        [StopWatch]
        /*" R4900-00-TOTAL-FILIAL-SECTION */
        private void R4900_00_TOTAL_FILIAL_SECTION()
        {
            /*" -772- MOVE '490' TO WNR-EXEC-SQL. */
            _.Move("490", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -773- IF AC-LINHAS GREATER 55 */

            if (AREA_DE_WORK.AC_LINHAS > 55)
            {

                /*" -775- PERFORM R6000-00-CABECALHO. */

                R6000_00_CABECALHO_SECTION();
            }


            /*" -776- MOVE 'TOTAL DA FILIAL.....' TO LD02-LITERAL */
            _.Move("TOTAL DA FILIAL.....", LD02.LD02_LITERAL);

            /*" -778- MOVE AC-F-SINISTROS TO LD02-TOTAL */
            _.Move(AREA_DE_WORK.AC_F_SINISTROS, LD02.LD02_TOTAL);

            /*" -779- WRITE REG-SI0033B1 FROM LC00 */
            _.Move(LC00.GetMoveValues(), REG_SI0033B1);

            SI0033B1.Write(REG_SI0033B1.GetMoveValues().ToString());

            /*" -780- WRITE REG-SI0033B1 FROM LD02 */
            _.Move(LD02.GetMoveValues(), REG_SI0033B1);

            SI0033B1.Write(REG_SI0033B1.GetMoveValues().ToString());

            /*" -782- ADD 2 TO AC-LINHAS */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 2;

            /*" -783- ADD AC-F-SINISTROS TO AC-A-SINISTROS */
            AREA_DE_WORK.AC_A_SINISTROS.Value = AREA_DE_WORK.AC_A_SINISTROS + AREA_DE_WORK.AC_F_SINISTROS;

            /*" -783- MOVE ZEROS TO AC-F-SINISTROS. */
            _.Move(0, AREA_DE_WORK.AC_F_SINISTROS);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4900_99_SAIDA*/

        [StopWatch]
        /*" R5000-00-PROCESSA-FILIAL-SECTION */
        private void R5000_00_PROCESSA_FILIAL_SECTION()
        {
            /*" -793- MOVE '500' TO WNR-EXEC-SQL. */
            _.Move("500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -794- PERFORM R5100-00-LE-SISINACO */

            R5100_00_LE_SISINACO_SECTION();

            /*" -796- PERFORM R5200-00-LE-SINISMES */

            R5200_00_LE_SINISMES_SECTION();

            /*" -797- MOVE SIDOCACO-COD-FONTE TO LD01-COD-FONTE */
            _.Move(SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_FONTE, LD01.LD01_COD_FONTE);

            /*" -799- MOVE SIDOCACO-NUM-PROTOCOLO-SINI TO LD01-NUM-PROTOCOLO */
            _.Move(SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_PROTOCOLO_SINI, LD01.LD01_NUM_PROTOCOLO);

            /*" -801- MOVE SIDOCACO-DAC-PROTOCOLO-SINI TO LD01-DAC-PROTOCOLO */
            _.Move(SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DAC_PROTOCOLO_SINI, LD01.LD01_DAC_PROTOCOLO);

            /*" -802- MOVE SINISMES-NUM-IRB TO LD01-NUM-IRB */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_IRB, LD01.LD01_NUM_IRB);

            /*" -805- MOVE SIMOVSIN-NOME-SEGURADO TO LD01-NOME-SEGURADO */
            _.Move(SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_NOME_SEGURADO, LD01.LD01_NOME_SEGURADO);

            /*" -807- IF SIMOVSIN-NATUREZA-SINISTRO EQUAL 1 */

            if (SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_NATUREZA_SINISTRO == 1)
            {

                /*" -808- MOVE 'MIP' TO LD01-TIPO-SINISTRO */
                _.Move("MIP", LD01.LD01_TIPO_SINISTRO);

                /*" -809- ELSE */
            }
            else
            {


                /*" -811- MOVE 'DFI' TO LD01-TIPO-SINISTRO. */
                _.Move("DFI", LD01.LD01_TIPO_SINISTRO);
            }


            /*" -813- IF SISINACO-DATA-MOVTO-SINIACO EQUAL SPACES */

            if (SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DATA_MOVTO_SINIACO.IsEmpty())
            {

                /*" -814- MOVE SPACES TO LD01-DATA-AVISO */
                _.Move("", LD01.LD01_DATA_AVISO);

                /*" -815- ELSE */
            }
            else
            {


                /*" -817- MOVE SISINACO-DATA-MOVTO-SINIACO TO DB2-DATA */
                _.Move(SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DATA_MOVTO_SINIACO, AREA_DE_WORK.DB2_DATA);

                /*" -818- MOVE DB2-DIA TO EDIT-DIA */
                _.Move(AREA_DE_WORK.DB2_DATA.DB2_DIA, AREA_DE_WORK.EDIT_DATA.EDIT_DIA);

                /*" -819- MOVE DB2-MES TO EDIT-MES */
                _.Move(AREA_DE_WORK.DB2_DATA.DB2_MES, AREA_DE_WORK.EDIT_DATA.EDIT_MES);

                /*" -820- MOVE DB2-ANO TO EDIT-ANO */
                _.Move(AREA_DE_WORK.DB2_DATA.DB2_ANO, AREA_DE_WORK.EDIT_DATA.EDIT_ANO);

                /*" -822- MOVE EDIT-DATA TO LD01-DATA-AVISO. */
                _.Move(AREA_DE_WORK.EDIT_DATA, LD01.LD01_DATA_AVISO);
            }


            /*" -825- MOVE SIEVETIP-DESCR-EVENTO TO LD01-DESCR-EVENTO */
            _.Move(SIEVETIP.DCLSI_EVENTO_TIPO.SIEVETIP_DESCR_EVENTO, LD01.LD01_DESCR_EVENTO);

            /*" -827- PERFORM R5300-00-LE-SIDOCACO */

            R5300_00_LE_SIDOCACO_SECTION();

            /*" -829- PERFORM R5400-00-OBTEM-DIAS-DECORRIDOS */

            R5400_00_OBTEM_DIAS_DECORRIDOS_SECTION();

            /*" -831- MOVE SIDOCACO-DATA-MOVTO-DOCACO TO DB2-DATA */
            _.Move(SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DATA_MOVTO_DOCACO, AREA_DE_WORK.DB2_DATA);

            /*" -832- MOVE DB2-DIA TO EDIT-DIA */
            _.Move(AREA_DE_WORK.DB2_DATA.DB2_DIA, AREA_DE_WORK.EDIT_DATA.EDIT_DIA);

            /*" -833- MOVE DB2-MES TO EDIT-MES */
            _.Move(AREA_DE_WORK.DB2_DATA.DB2_MES, AREA_DE_WORK.EDIT_DATA.EDIT_MES);

            /*" -834- MOVE DB2-ANO TO EDIT-ANO */
            _.Move(AREA_DE_WORK.DB2_DATA.DB2_ANO, AREA_DE_WORK.EDIT_DATA.EDIT_ANO);

            /*" -836- MOVE EDIT-DATA TO LD01-DATA-EVENTO */
            _.Move(AREA_DE_WORK.EDIT_DATA, LD01.LD01_DATA_EVENTO);

            /*" -838- MOVE HOST-COUNT TO LD01-QTD-DIAS */
            _.Move(HOST_COUNT, LD01.LD01_QTD_DIAS);

            /*" -839- IF AC-LINHAS GREATER 55 */

            if (AREA_DE_WORK.AC_LINHAS > 55)
            {

                /*" -840- PERFORM R6000-00-CABECALHO */

                R6000_00_CABECALHO_SECTION();

                /*" -842- PERFORM R6100-00-CABECALHO-FILIAL. */

                R6100_00_CABECALHO_FILIAL_SECTION();
            }


            /*" -843- WRITE REG-SI0033B1 FROM LD01 */
            _.Move(LD01.GetMoveValues(), REG_SI0033B1);

            SI0033B1.Write(REG_SI0033B1.GetMoveValues().ToString());

            /*" -849- ADD 1 TO AC-LINHAS AC-I-SI0033B1 AC-F-SINISTROS */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 1;
            AREA_DE_WORK.AC_I_SI0033B1.Value = AREA_DE_WORK.AC_I_SI0033B1 + 1;
            AREA_DE_WORK.AC_F_SINISTROS.Value = AREA_DE_WORK.AC_F_SINISTROS + 1;

            /*" -849- PERFORM R0910-00-LE-LISTA. */

            R0910_00_LE_LISTA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_99_SAIDA*/

        [StopWatch]
        /*" R5100-00-LE-SISINACO-SECTION */
        private void R5100_00_LE_SISINACO_SECTION()
        {
            /*" -859- MOVE '510' TO WNR-EXEC-SQL. */
            _.Move("510", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -869- PERFORM R5100_00_LE_SISINACO_DB_SELECT_1 */

            R5100_00_LE_SISINACO_DB_SELECT_1();

            /*" -872- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -874- MOVE SPACES TO SISINACO-DATA-MOVTO-SINIACO */
                _.Move("", SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DATA_MOVTO_SINIACO);

                /*" -875- ELSE */
            }
            else
            {


                /*" -876- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -877- DISPLAY 'SI0033B - PROBLEMAS NO SELECT SI_SINISTRO_ACOMP' */
                    _.Display($"SI0033B - PROBLEMAS NO SELECT SI_SINISTRO_ACOMP");

                    /*" -880- DISPLAY ' ' SIDOCACO-COD-FONTE ' ' SIDOCACO-NUM-PROTOCOLO-SINI ' ' SIDOCACO-DAC-PROTOCOLO-SINI */

                    $" {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_FONTE} {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_PROTOCOLO_SINI} {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DAC_PROTOCOLO_SINI}"
                    .Display();

                    /*" -880- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R5100-00-LE-SISINACO-DB-SELECT-1 */
        public void R5100_00_LE_SISINACO_DB_SELECT_1()
        {
            /*" -869- EXEC SQL SELECT DATA_MOVTO_SINIACO INTO :SISINACO-DATA-MOVTO-SINIACO FROM SEGUROS.SI_SINISTRO_ACOMP WHERE COD_FONTE = :SIDOCACO-COD-FONTE AND NUM_PROTOCOLO_SINI = :SIDOCACO-NUM-PROTOCOLO-SINI AND DAC_PROTOCOLO_SINI = :SIDOCACO-DAC-PROTOCOLO-SINI AND COD_EVENTO = 1001 END-EXEC. */

            var r5100_00_LE_SISINACO_DB_SELECT_1_Query1 = new R5100_00_LE_SISINACO_DB_SELECT_1_Query1()
            {
                SIDOCACO_NUM_PROTOCOLO_SINI = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_PROTOCOLO_SINI.ToString(),
                SIDOCACO_DAC_PROTOCOLO_SINI = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DAC_PROTOCOLO_SINI.ToString(),
                SIDOCACO_COD_FONTE = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_FONTE.ToString(),
            };

            var executed_1 = R5100_00_LE_SISINACO_DB_SELECT_1_Query1.Execute(r5100_00_LE_SISINACO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISINACO_DATA_MOVTO_SINIACO, SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DATA_MOVTO_SINIACO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5100_99_SAIDA*/

        [StopWatch]
        /*" R5200-00-LE-SINISMES-SECTION */
        private void R5200_00_LE_SINISMES_SECTION()
        {
            /*" -890- MOVE '520' TO WNR-EXEC-SQL. */
            _.Move("520", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -899- PERFORM R5200_00_LE_SINISMES_DB_SELECT_1 */

            R5200_00_LE_SINISMES_DB_SELECT_1();

            /*" -902- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -903- MOVE ZEROS TO SINISMES-NUM-IRB */
                _.Move(0, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_IRB);

                /*" -904- ELSE */
            }
            else
            {


                /*" -905- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -906- DISPLAY 'SI0033B - PROBLEMAS NO SELECT SINISTRO_MESTRE' */
                    _.Display($"SI0033B - PROBLEMAS NO SELECT SINISTRO_MESTRE");

                    /*" -909- DISPLAY ' ' SIDOCACO-COD-FONTE ' ' SIDOCACO-NUM-PROTOCOLO-SINI ' ' SIDOCACO-DAC-PROTOCOLO-SINI */

                    $" {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_FONTE} {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_PROTOCOLO_SINI} {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DAC_PROTOCOLO_SINI}"
                    .Display();

                    /*" -909- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R5200-00-LE-SINISMES-DB-SELECT-1 */
        public void R5200_00_LE_SINISMES_DB_SELECT_1()
        {
            /*" -899- EXEC SQL SELECT NUM_IRB INTO :SINISMES-NUM-IRB FROM SEGUROS.SINISTRO_MESTRE WHERE COD_FONTE = :SIDOCACO-COD-FONTE AND NUM_PROTOCOLO_SINI = :SIDOCACO-NUM-PROTOCOLO-SINI AND DAC_PROTOCOLO_SINI = :SIDOCACO-DAC-PROTOCOLO-SINI END-EXEC. */

            var r5200_00_LE_SINISMES_DB_SELECT_1_Query1 = new R5200_00_LE_SINISMES_DB_SELECT_1_Query1()
            {
                SIDOCACO_NUM_PROTOCOLO_SINI = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_PROTOCOLO_SINI.ToString(),
                SIDOCACO_DAC_PROTOCOLO_SINI = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DAC_PROTOCOLO_SINI.ToString(),
                SIDOCACO_COD_FONTE = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_FONTE.ToString(),
            };

            var executed_1 = R5200_00_LE_SINISMES_DB_SELECT_1_Query1.Execute(r5200_00_LE_SINISMES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISMES_NUM_IRB, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_IRB);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5200_99_SAIDA*/

        [StopWatch]
        /*" R5300-00-LE-SIDOCACO-SECTION */
        private void R5300_00_LE_SIDOCACO_SECTION()
        {
            /*" -919- MOVE '530' TO WNR-EXEC-SQL. */
            _.Move("530", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -969- PERFORM R5300_00_LE_SIDOCACO_DB_SELECT_1 */

            R5300_00_LE_SIDOCACO_DB_SELECT_1();

            /*" -972- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -973- DISPLAY 'SI0033B - PROBLEMAS NO SELECT SI_DOCUMENTO_ACOMP' */
                _.Display($"SI0033B - PROBLEMAS NO SELECT SI_DOCUMENTO_ACOMP");

                /*" -976- DISPLAY ' ' SIDOCACO-COD-FONTE ' ' SIDOCACO-NUM-PROTOCOLO-SINI ' ' SIDOCACO-DAC-PROTOCOLO-SINI */

                $" {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_FONTE} {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_PROTOCOLO_SINI} {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DAC_PROTOCOLO_SINI}"
                .Display();

                /*" -976- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R5300-00-LE-SIDOCACO-DB-SELECT-1 */
        public void R5300_00_LE_SIDOCACO_DB_SELECT_1()
        {
            /*" -969- EXEC SQL SELECT MIN(A.DATA_MOVTO_DOCACO) INTO :SIDOCACO-DATA-MOVTO-DOCACO FROM SEGUROS.SI_DOCUMENTO_ACOMP A, SEGUROS.SI_DOCUMENTO_PARAM B WHERE A.COD_FONTE = :SIDOCACO-COD-FONTE AND A.NUM_PROTOCOLO_SINI = :SIDOCACO-NUM-PROTOCOLO-SINI AND A.DAC_PROTOCOLO_SINI = :SIDOCACO-DAC-PROTOCOLO-SINI AND B.COD_TIPO_CARTA = :SIDOCPAR-COD-TIPO-CARTA AND A.COD_PRODUTO = B.COD_PRODUTO AND A.COD_GRUPO_CAUSA = B.COD_GRUPO_CAUSA AND A.COD_SUBGRUPO_CAUSA = B.COD_SUBGRUPO_CAUSA AND A.COD_DOCUMENTO = B.COD_DOCUMENTO AND A.DATA_INIVIG_DOCPAR = B.DATA_INIVIG_DOCPAR AND B.OPCAO_DOCUMENTO IN ( '1' , '3' ) AND A.NUM_OCORR_DOCACO = (SELECT MIN(C.NUM_OCORR_DOCACO) FROM SEGUROS.SI_DOCUMENTO_ACOMP C WHERE C.COD_FONTE = A.COD_FONTE AND C.NUM_PROTOCOLO_SINI = A.NUM_PROTOCOLO_SINI AND C.DAC_PROTOCOLO_SINI = A.DAC_PROTOCOLO_SINI AND C.COD_DOCUMENTO = A.COD_DOCUMENTO AND C.COD_EVENTO IN (2012, 2013)) AND EXISTS (SELECT * FROM SEGUROS.SI_DOCUMENTO_ACOMP D, SEGUROS.SI_DOCUMENTO_PARAM E WHERE E.COD_TIPO_CARTA = B.COD_TIPO_CARTA AND E.OPCAO_DOCUMENTO = B.OPCAO_DOCUMENTO AND D.COD_PRODUTO = E.COD_PRODUTO AND D.COD_GRUPO_CAUSA = E.COD_GRUPO_CAUSA AND D.COD_SUBGRUPO_CAUSA = E.COD_SUBGRUPO_CAUSA AND D.COD_DOCUMENTO = E.COD_DOCUMENTO AND D.DATA_INIVIG_DOCPAR = E.DATA_INIVIG_DOCPAR AND D.COD_FONTE = A.COD_FONTE AND D.NUM_PROTOCOLO_SINI = A.NUM_PROTOCOLO_SINI AND D.DAC_PROTOCOLO_SINI = A.DAC_PROTOCOLO_SINI AND D.COD_DOCUMENTO = A.COD_DOCUMENTO AND D.COD_EVENTO IN (2012, 2013) AND D.NUM_OCORR_DOCACO = (SELECT MAX(E.NUM_OCORR_DOCACO) FROM SEGUROS.SI_DOCUMENTO_ACOMP E WHERE E.COD_FONTE = D.COD_FONTE AND E.NUM_PROTOCOLO_SINI = D.NUM_PROTOCOLO_SINI AND E.DAC_PROTOCOLO_SINI = D.DAC_PROTOCOLO_SINI AND E.COD_DOCUMENTO = D.COD_DOCUMENTO AND D.DATA_INIVIG_DOCPAR = E.DATA_INIVIG_DOCPAR)) END-EXEC. */

            var r5300_00_LE_SIDOCACO_DB_SELECT_1_Query1 = new R5300_00_LE_SIDOCACO_DB_SELECT_1_Query1()
            {
                SIDOCACO_NUM_PROTOCOLO_SINI = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_PROTOCOLO_SINI.ToString(),
                SIDOCACO_DAC_PROTOCOLO_SINI = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DAC_PROTOCOLO_SINI.ToString(),
                SIDOCPAR_COD_TIPO_CARTA = SIDOCPAR.DCLSI_DOCUMENTO_PARAM.SIDOCPAR_COD_TIPO_CARTA.ToString(),
                SIDOCACO_COD_FONTE = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_FONTE.ToString(),
            };

            var executed_1 = R5300_00_LE_SIDOCACO_DB_SELECT_1_Query1.Execute(r5300_00_LE_SIDOCACO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SIDOCACO_DATA_MOVTO_DOCACO, SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DATA_MOVTO_DOCACO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5300_99_SAIDA*/

        [StopWatch]
        /*" R5400-00-OBTEM-DIAS-DECORRIDOS-SECTION */
        private void R5400_00_OBTEM_DIAS_DECORRIDOS_SECTION()
        {
            /*" -988- MOVE '540' TO WNR-EXEC-SQL. */
            _.Move("540", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -995- PERFORM R5400_00_OBTEM_DIAS_DECORRIDOS_DB_SELECT_1 */

            R5400_00_OBTEM_DIAS_DECORRIDOS_DB_SELECT_1();

            /*" -998- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -999- DISPLAY 'SI0033B - PROBLEMAS NO SELECT CALENDARIO' */
                _.Display($"SI0033B - PROBLEMAS NO SELECT CALENDARIO");

                /*" -1002- DISPLAY ' ' SIDOCACO-COD-FONTE ' ' SIDOCACO-NUM-PROTOCOLO-SINI ' ' SIDOCACO-DAC-PROTOCOLO-SINI */

                $" {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_FONTE} {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_PROTOCOLO_SINI} {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DAC_PROTOCOLO_SINI}"
                .Display();

                /*" -1004- DISPLAY ' ' SIDOCACO-DATA-MOVTO-DOCACO ' ' SISTEMAS-DATA-MOV-ABERTO */

                $" {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DATA_MOVTO_DOCACO} {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}"
                .Display();

                /*" -1004- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R5400-00-OBTEM-DIAS-DECORRIDOS-DB-SELECT-1 */
        public void R5400_00_OBTEM_DIAS_DECORRIDOS_DB_SELECT_1()
        {
            /*" -995- EXEC SQL SELECT COUNT(*) INTO :HOST-COUNT FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO >= :SIDOCACO-DATA-MOVTO-DOCACO AND DATA_CALENDARIO <= :SISTEMAS-DATA-MOV-ABERTO END-EXEC. */

            var r5400_00_OBTEM_DIAS_DECORRIDOS_DB_SELECT_1_Query1 = new R5400_00_OBTEM_DIAS_DECORRIDOS_DB_SELECT_1_Query1()
            {
                SIDOCACO_DATA_MOVTO_DOCACO = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DATA_MOVTO_DOCACO.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
            };

            var executed_1 = R5400_00_OBTEM_DIAS_DECORRIDOS_DB_SELECT_1_Query1.Execute(r5400_00_OBTEM_DIAS_DECORRIDOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_COUNT, HOST_COUNT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5400_99_SAIDA*/

        [StopWatch]
        /*" R6000-00-CABECALHO-SECTION */
        private void R6000_00_CABECALHO_SECTION()
        {
            /*" -1014- MOVE '600' TO WNR-EXEC-SQL. */
            _.Move("600", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1015- ADD 1 TO AC-PAGINAS */
            AREA_DE_WORK.AC_PAGINAS.Value = AREA_DE_WORK.AC_PAGINAS + 1;

            /*" -1017- MOVE AC-PAGINAS TO LC01-PAGINA */
            _.Move(AREA_DE_WORK.AC_PAGINAS, LC01.LC01_PAGINA);

            /*" -1019- MOVE SISTEMAS-DATA-MOV-ABERTO TO DB2-DATA */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREA_DE_WORK.DB2_DATA);

            /*" -1020- MOVE DB2-DIA TO EDIT-DIA */
            _.Move(AREA_DE_WORK.DB2_DATA.DB2_DIA, AREA_DE_WORK.EDIT_DATA.EDIT_DIA);

            /*" -1021- MOVE DB2-MES TO EDIT-MES */
            _.Move(AREA_DE_WORK.DB2_DATA.DB2_MES, AREA_DE_WORK.EDIT_DATA.EDIT_MES);

            /*" -1022- MOVE DB2-ANO TO EDIT-ANO */
            _.Move(AREA_DE_WORK.DB2_DATA.DB2_ANO, AREA_DE_WORK.EDIT_DATA.EDIT_ANO);

            /*" -1025- MOVE EDIT-DATA TO LC02-DATA LC02-DATA-MOV-ABERTO */
            _.Move(AREA_DE_WORK.EDIT_DATA, LC02.LC02_DATA, LC02.LC02_DATA_MOV_ABERTO);

            /*" -1026- ACCEPT ACC-HORA FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.ACC_HORA);

            /*" -1027- MOVE ACC-HH TO EDIT-HH */
            _.Move(AREA_DE_WORK.ACC_HORA.ACC_HH, AREA_DE_WORK.EDIT_HORA.EDIT_HH);

            /*" -1028- MOVE ACC-MM TO EDIT-MM */
            _.Move(AREA_DE_WORK.ACC_HORA.ACC_MM, AREA_DE_WORK.EDIT_HORA.EDIT_MM);

            /*" -1029- MOVE ACC-SS TO EDIT-SS */
            _.Move(AREA_DE_WORK.ACC_HORA.ACC_SS, AREA_DE_WORK.EDIT_HORA.EDIT_SS);

            /*" -1031- MOVE EDIT-HORA TO LC03-HORA */
            _.Move(AREA_DE_WORK.EDIT_HORA, LC03.LC03_HORA);

            /*" -1033- MOVE WS-COD-SUBESTIPULANTE-ANT TO LC05-COD-SUBESTIP */
            _.Move(WS_COD_SUBESTIPULANTE_ANT, LC05.LC05_COD_SUBESTIP);

            /*" -1035- MOVE CLIENTES-NOME-RAZAO TO LC05-NOME-RAZAO */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, LC05.LC05_NOME_RAZAO);

            /*" -1038- MOVE USUARIOS-NOME-USUARIO TO LC06-ANALISTA */
            _.Move(USUARIOS.DCLUSUARIOS.USUARIOS_NOME_USUARIO, LC06.LC06_ANALISTA);

            /*" -1039- WRITE REG-SI0033B1 FROM LC01 */
            _.Move(LC01.GetMoveValues(), REG_SI0033B1);

            SI0033B1.Write(REG_SI0033B1.GetMoveValues().ToString());

            /*" -1040- WRITE REG-SI0033B1 FROM LC02 */
            _.Move(LC02.GetMoveValues(), REG_SI0033B1);

            SI0033B1.Write(REG_SI0033B1.GetMoveValues().ToString());

            /*" -1041- WRITE REG-SI0033B1 FROM LC03 */
            _.Move(LC03.GetMoveValues(), REG_SI0033B1);

            SI0033B1.Write(REG_SI0033B1.GetMoveValues().ToString());

            /*" -1042- WRITE REG-SI0033B1 FROM LC00 */
            _.Move(LC00.GetMoveValues(), REG_SI0033B1);

            SI0033B1.Write(REG_SI0033B1.GetMoveValues().ToString());

            /*" -1043- WRITE REG-SI0033B1 FROM LC04 */
            _.Move(LC04.GetMoveValues(), REG_SI0033B1);

            SI0033B1.Write(REG_SI0033B1.GetMoveValues().ToString());

            /*" -1044- WRITE REG-SI0033B1 FROM LC05 */
            _.Move(LC05.GetMoveValues(), REG_SI0033B1);

            SI0033B1.Write(REG_SI0033B1.GetMoveValues().ToString());

            /*" -1045- WRITE REG-SI0033B1 FROM LC06 */
            _.Move(LC06.GetMoveValues(), REG_SI0033B1);

            SI0033B1.Write(REG_SI0033B1.GetMoveValues().ToString());

            /*" -1046- WRITE REG-SI0033B1 FROM LC04 */
            _.Move(LC04.GetMoveValues(), REG_SI0033B1);

            SI0033B1.Write(REG_SI0033B1.GetMoveValues().ToString());

            /*" -1047- WRITE REG-SI0033B1 FROM LC08 */
            _.Move(LC08.GetMoveValues(), REG_SI0033B1);

            SI0033B1.Write(REG_SI0033B1.GetMoveValues().ToString());

            /*" -1048- WRITE REG-SI0033B1 FROM LC04 */
            _.Move(LC04.GetMoveValues(), REG_SI0033B1);

            SI0033B1.Write(REG_SI0033B1.GetMoveValues().ToString());

            /*" -1050- WRITE REG-SI0033B1 FROM LC00 */
            _.Move(LC00.GetMoveValues(), REG_SI0033B1);

            SI0033B1.Write(REG_SI0033B1.GetMoveValues().ToString());

            /*" -1050- MOVE 10 TO AC-LINHAS. */
            _.Move(10, AREA_DE_WORK.AC_LINHAS);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6000_99_SAIDA*/

        [StopWatch]
        /*" R6100-00-CABECALHO-FILIAL-SECTION */
        private void R6100_00_CABECALHO_FILIAL_SECTION()
        {
            /*" -1060- MOVE '610' TO WNR-EXEC-SQL. */
            _.Move("610", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1063- MOVE GEDESTIN-NOME-DESTINATARIO TO LC07-FILIAL */
            _.Move(GEDESTIN.DCLGE_DESTINATARIO.GEDESTIN_NOME_DESTINATARIO, LC07.LC07_FILIAL);

            /*" -1064- WRITE REG-SI0033B1 FROM LC07 */
            _.Move(LC07.GetMoveValues(), REG_SI0033B1);

            SI0033B1.Write(REG_SI0033B1.GetMoveValues().ToString());

            /*" -1066- WRITE REG-SI0033B1 FROM LC00 */
            _.Move(LC00.GetMoveValues(), REG_SI0033B1);

            SI0033B1.Write(REG_SI0033B1.GetMoveValues().ToString());

            /*" -1066- ADD 2 TO AC-LINHAS. */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 2;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6100_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1076- CLOSE SI0033B1 */
            SI0033B1.Close();

            /*" -1078- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -1080- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -1080- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1083- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -1084- DISPLAY '***   SI0033B - CANCELADO  ***' */
            _.Display($"***   SI0033B - CANCELADO  ***");

            /*" -1086- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -1087- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1087- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}