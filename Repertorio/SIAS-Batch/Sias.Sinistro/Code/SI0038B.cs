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
using Sias.Sinistro.DB2.SI0038B;

namespace Code
{
    public class SI0038B
    {
        public bool IsCall { get; set; }

        public SI0038B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-------------------------------------                                  */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................ SINISTRO HABITACIONAL               *      */
        /*"      *   SUBROTINA............... SI0038B                             *      */
        /*"      *   ANALISTA ............... PRODEXTER                           *      */
        /*"      *   PROGRAMADOR ............ PRODEXTER                           *      */
        /*"      *   DATA CODIFICACAO ....... ABR / 2003                          *      */
        /*"      *   FUNCAO ................. RELACAO DE PENDENCIA DE PARECER     *      */
        /*"      *                            JURIDICO                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 11/07/08 - BRSEG - CAD.12115 - SAC.237                         *      */
        /*"      *            ELIMINAR CARACTERES ESPECIAIS DE CONTROLE DE IMPRES-*      */
        /*"      *            SAO NOS ARQUIVOS.   -   PROCURE: BR.V01             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        /*"      *-------------------------------------                                  */
        #endregion


        #region VARIABLES

        public FileBasis _SI0038B1 { get; set; } = new FileBasis(new PIC("X", "200", "X(200)"));

        public FileBasis SI0038B1
        {
            get
            {
                _.Move(REG_SI0038B1, _SI0038B1); VarBasis.RedefinePassValue(REG_SI0038B1, _SI0038B1, REG_SI0038B1); return _SI0038B1;
            }
        }
        /*"01          REG-SI0038B1         PIC  X(200).*/
        public StringBasis REG_SI0038B1 { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01          HOST-DATA-AVISO      PIC  X(010)   VALUE   SPACES.*/
        public StringBasis HOST_DATA_AVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01          WS-COD-USUARIO-ANT   PIC  X(008)   VALUE   SPACES.*/
        public StringBasis WS_COD_USUARIO_ANT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"01          WS-COD-DESTINATARIO-ANT                                 PIC S9(004)   VALUE +0 COMP.*/
        public IntBasis WS_COD_DESTINATARIO_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          AREA-DE-WORK.*/
        public SI0038B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SI0038B_AREA_DE_WORK();
        public class SI0038B_AREA_DE_WORK : VarBasis
        {
            /*"  05        AC-L-LISTA           PIC  9(006)   VALUE   ZEROS.*/
            public IntBasis AC_L_LISTA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05        AC-I-SI0038B1        PIC  9(006)   VALUE   ZEROS.*/
            public IntBasis AC_I_SI0038B1 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05        AC-F-SINISTROS       PIC  9(006)   VALUE   ZEROS.*/
            public IntBasis AC_F_SINISTROS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
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
            public SI0038B_DB2_DATA DB2_DATA { get; set; } = new SI0038B_DB2_DATA();
            public class SI0038B_DB2_DATA : VarBasis
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
            public SI0038B_EDIT_DATA EDIT_DATA { get; set; } = new SI0038B_EDIT_DATA();
            public class SI0038B_EDIT_DATA : VarBasis
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
            public SI0038B_ACC_HORA ACC_HORA { get; set; } = new SI0038B_ACC_HORA();
            public class SI0038B_ACC_HORA : VarBasis
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
            public SI0038B_EDIT_HORA EDIT_HORA { get; set; } = new SI0038B_EDIT_HORA();
            public class SI0038B_EDIT_HORA : VarBasis
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
            public SI0038B_WABEND WABEND { get; set; } = new SI0038B_WABEND();
            public class SI0038B_WABEND : VarBasis
            {
                /*"    10      FILLER               PIC  X(010) VALUE           ' SI0038B'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SI0038B");
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
        public SI0038B_LC00 LC00 { get; set; } = new SI0038B_LC00();
        public class SI0038B_LC00 : VarBasis
        {
            /*"  05        LC00-CANAL           PIC  X(001) VALUE ' '.*/
            public StringBasis LC00_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"  05        FILLER               PIC  X(199) VALUE SPACES.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "199", "X(199)"), @"");
            /*"01          LC01.*/
        }
        public SI0038B_LC01 LC01 { get; set; } = new SI0038B_LC01();
        public class SI0038B_LC01 : VarBasis
        {
            /*"  05        LC01-CANAL           PIC  X(001) VALUE '1'.*/
            public StringBasis LC01_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
            /*"  05        FILLER               PIC  X(075) VALUE 'SI0038B'.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "75", "X(075)"), @"SI0038B");
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
        public SI0038B_LC02 LC02 { get; set; } = new SI0038B_LC02();
        public class SI0038B_LC02 : VarBasis
        {
            /*"  05        LC02-CANAL           PIC  X(001) VALUE ' '.*/
            public StringBasis LC02_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"  05        FILLER               PIC  X(074) VALUE SPACES.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "74", "X(074)"), @"");
            /*"  05        FILLER               PIC  X(030) VALUE                            'PENDENTE PARECER JURIDICO ATE '.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"PENDENTE PARECER JURIDICO ATE ");
            /*"  05        LC02-DATA-MOV-ABERTO PIC  X(010) VALUE SPACES.*/
            public StringBasis LC02_DATA_MOV_ABERTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05        FILLER               PIC  X(058) VALUE SPACES.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "58", "X(058)"), @"");
            /*"  05        FILLER               PIC  X(007) VALUE 'DATA'.*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"DATA");
            /*"  05        LC02-DATA            PIC  X(010) VALUE SPACES.*/
            public StringBasis LC02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"01          LC03.*/
        }
        public SI0038B_LC03 LC03 { get; set; } = new SI0038B_LC03();
        public class SI0038B_LC03 : VarBasis
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
        public SI0038B_LC04 LC04 { get; set; } = new SI0038B_LC04();
        public class SI0038B_LC04 : VarBasis
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
        public SI0038B_LC05 LC05 { get; set; } = new SI0038B_LC05();
        public class SI0038B_LC05 : VarBasis
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
        public SI0038B_LC06 LC06 { get; set; } = new SI0038B_LC06();
        public class SI0038B_LC06 : VarBasis
        {
            /*"  05        LC06-CANAL           PIC  X(001) VALUE ' '.*/
            public StringBasis LC06_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"  05        FILLER               PIC  X(011) VALUE ' FILIAL  :'.*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @" FILIAL  :");
            /*"  05        LC06-FILIAL          PIC  X(040) VALUE SPACES.*/
            public StringBasis LC06_FILIAL { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"  05        FILLER               PIC  X(138) VALUE SPACES.*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "138", "X(138)"), @"");
            /*"01          LC07.*/
        }
        public SI0038B_LC07 LC07 { get; set; } = new SI0038B_LC07();
        public class SI0038B_LC07 : VarBasis
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
        public SI0038B_LD01 LD01 { get; set; } = new SI0038B_LD01();
        public class SI0038B_LD01 : VarBasis
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
        public SI0038B_LD02 LD02 { get; set; } = new SI0038B_LD02();
        public class SI0038B_LD02 : VarBasis
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
        public SI0038B_LISTA LISTA { get; set; } = new SI0038B_LISTA();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SI0038B1_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SI0038B1.SetFile(SI0038B1_FILE_NAME_P);

                /*" -228- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -228- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -229- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -230- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -230- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -238- OPEN OUTPUT SI0038B1 */
            SI0038B1.Open(REG_SI0038B1);

            /*" -240- PERFORM R0500-00-LE-SISTEMAS */

            R0500_00_LE_SISTEMAS_SECTION();

            /*" -242- PERFORM R0600-00-LE-RELATORIOS */

            R0600_00_LE_RELATORIOS_SECTION();

            /*" -243- IF WFIM-RELATORI EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_RELATORI == "S")
            {

                /*" -244- DISPLAY '******************************************' */
                _.Display($"******************************************");

                /*" -245- DISPLAY '* NAO HOUVE SOLICITACAO PARA O RELATORIO *' */
                _.Display($"* NAO HOUVE SOLICITACAO PARA O RELATORIO *");

                /*" -246- DISPLAY '******************************************' */
                _.Display($"******************************************");

                /*" -247- DISPLAY ' ' */
                _.Display($" ");

                /*" -249- GO TO R0000-90-ENCERRA. */

                R0000_90_ENCERRA(); //GOTO
                return;
            }


            /*" -250- PERFORM R0900-00-DECLARA-LISTA */

            R0900_00_DECLARA_LISTA_SECTION();

            /*" -252- PERFORM R0910-00-LE-LISTA */

            R0910_00_LE_LISTA_SECTION();

            /*" -253- IF WFIM-LISTA EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_LISTA == "S")
            {

                /*" -260- GO TO R0000-90-ENCERRA. */

                R0000_90_ENCERRA(); //GOTO
                return;
            }


            /*" -263- PERFORM R1000-00-PROCESSA UNTIL WFIM-LISTA EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_LISTA == "S"))
            {

                R1000_00_PROCESSA_SECTION();
            }

            /*" -268- PERFORM R0800-00-TOTAL-GERAL */

            R0800_00_TOTAL_GERAL_SECTION();

            /*" -268- PERFORM R0700-00-ALTERA-RELATORIOS. */

            R0700_00_ALTERA_RELATORIOS_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_ENCERRA */

            R0000_90_ENCERRA();

        }

        [StopWatch]
        /*" R0000-90-ENCERRA */
        private void R0000_90_ENCERRA(bool isPerform = false)
        {
            /*" -274- CLOSE SI0038B1 */
            SI0038B1.Close();

            /*" -276- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -277- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -278- DISPLAY '***   SI0038B - FIM NORMAL ***' */
            _.Display($"***   SI0038B - FIM NORMAL ***");

            /*" -279- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -280- DISPLAY 'LIDOS      SIDOCACO  -  ' AC-L-LISTA */
            _.Display($"LIDOS      SIDOCACO  -  {AREA_DE_WORK.AC_L_LISTA}");

            /*" -282- DISPLAY 'IMPRESSOS  SI0038B1  -  ' AC-I-SI0038B1 */
            _.Display($"IMPRESSOS  SI0038B1  -  {AREA_DE_WORK.AC_I_SI0038B1}");

            /*" -282- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0500-00-LE-SISTEMAS-SECTION */
        private void R0500_00_LE_SISTEMAS_SECTION()
        {
            /*" -290- MOVE '050' TO WNR-EXEC-SQL. */
            _.Move("050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -295- PERFORM R0500_00_LE_SISTEMAS_DB_SELECT_1 */

            R0500_00_LE_SISTEMAS_DB_SELECT_1();

            /*" -298- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -299- DISPLAY 'SI0038B - PROBLEMAS NO SELECT SISTEMAS' */
                _.Display($"SI0038B - PROBLEMAS NO SELECT SISTEMAS");

                /*" -299- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0500-00-LE-SISTEMAS-DB-SELECT-1 */
        public void R0500_00_LE_SISTEMAS_DB_SELECT_1()
        {
            /*" -295- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' END-EXEC. */

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
            /*" -309- MOVE '060' TO WNR-EXEC-SQL. */
            _.Move("060", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -317- PERFORM R0600_00_LE_RELATORIOS_DB_SELECT_1 */

            R0600_00_LE_RELATORIOS_DB_SELECT_1();

            /*" -320- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -321- MOVE 'S' TO WFIM-RELATORI */
                _.Move("S", AREA_DE_WORK.WFIM_RELATORI);

                /*" -322- ELSE */
            }
            else
            {


                /*" -323- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -324- DISPLAY 'SI0038B - PROBLEMAS NO SELECT RELATORIOS' */
                    _.Display($"SI0038B - PROBLEMAS NO SELECT RELATORIOS");

                    /*" -324- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0600-00-LE-RELATORIOS-DB-SELECT-1 */
        public void R0600_00_LE_RELATORIOS_DB_SELECT_1()
        {
            /*" -317- EXEC SQL SELECT COD_USUARIO INTO :RELATORI-COD-USUARIO FROM SEGUROS.RELATORIOS WHERE COD_RELATORIO = 'SI0038B' AND IDE_SISTEMA = 'SI' AND DATA_SOLICITACAO = :SISTEMAS-DATA-MOV-ABERTO AND SIT_REGISTRO = '0' END-EXEC. */

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
            /*" -334- MOVE '070' TO WNR-EXEC-SQL. */
            _.Move("070", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -341- PERFORM R0700_00_ALTERA_RELATORIOS_DB_UPDATE_1 */

            R0700_00_ALTERA_RELATORIOS_DB_UPDATE_1();

            /*" -344- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -345- DISPLAY 'SI0038B - PROBLEMAS NO UPDATE RELATORIOS' */
                _.Display($"SI0038B - PROBLEMAS NO UPDATE RELATORIOS");

                /*" -345- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0700-00-ALTERA-RELATORIOS-DB-UPDATE-1 */
        public void R0700_00_ALTERA_RELATORIOS_DB_UPDATE_1()
        {
            /*" -341- EXEC SQL UPDATE SEGUROS.RELATORIOS SET SIT_REGISTRO = '1' WHERE COD_RELATORIO = 'SI0038B' AND IDE_SISTEMA = 'SI' AND DATA_SOLICITACAO = :SISTEMAS-DATA-MOV-ABERTO AND SIT_REGISTRO = '0' END-EXEC. */

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
            /*" -355- MOVE '080' TO WNR-EXEC-SQL. */
            _.Move("080", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -356- IF AC-LINHAS GREATER 55 */

            if (AREA_DE_WORK.AC_LINHAS > 55)
            {

                /*" -358- PERFORM R4000-00-CABECALHO. */

                R4000_00_CABECALHO_SECTION();
            }


            /*" -359- MOVE 'TOTAL GERAL.........' TO LD02-LITERAL */
            _.Move("TOTAL GERAL.........", LD02.LD02_LITERAL);

            /*" -361- MOVE AC-G-SINISTROS TO LD02-TOTAL */
            _.Move(AREA_DE_WORK.AC_G_SINISTROS, LD02.LD02_TOTAL);

            /*" -362- WRITE REG-SI0038B1 FROM LC00 */
            _.Move(LC00.GetMoveValues(), REG_SI0038B1);

            SI0038B1.Write(REG_SI0038B1.GetMoveValues().ToString());

            /*" -363- WRITE REG-SI0038B1 FROM LD02 */
            _.Move(LD02.GetMoveValues(), REG_SI0038B1);

            SI0038B1.Write(REG_SI0038B1.GetMoveValues().ToString());

            /*" -363- ADD 2 TO AC-LINHAS. */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 2;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARA-LISTA-SECTION */
        private void R0900_00_DECLARA_LISTA_SECTION()
        {
            /*" -373- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -448- PERFORM R0900_00_DECLARA_LISTA_DB_DECLARE_1 */

            R0900_00_DECLARA_LISTA_DB_DECLARE_1();

            /*" -450- PERFORM R0900_00_DECLARA_LISTA_DB_OPEN_1 */

            R0900_00_DECLARA_LISTA_DB_OPEN_1();

            /*" -453- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -455- DISPLAY 'SI0038B - PROBLEMAS NO OPEN LISTA ' ' ' SISTEMAS-DATA-MOV-ABERTO */

                $"SI0038B - PROBLEMAS NO OPEN LISTA  {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}"
                .Display();

                /*" -455- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARA-LISTA-DB-DECLARE-1 */
        public void R0900_00_DECLARA_LISTA_DB_DECLARE_1()
        {
            /*" -448- EXEC SQL DECLARE LISTA CURSOR FOR SELECT E.COD_USUARIO, C.COD_TIPO_CARTA, A.DESCR_EVENTO, B.COD_FONTE, B.NUM_PROTOCOLO_SINI, B.DAC_PROTOCOLO_SINI, B.DATA_MOVTO_DOCACO, D.NATUREZA_SINISTRO, D.NOME_SEGURADO, D.COD_GIAFI, I.COD_DESTINATARIO FROM SEGUROS.SI_EVENTO_TIPO A, SEGUROS.SI_DOCUMENTO_ACOMP B, SEGUROS.SI_DOCUMENTO_PARAM C, SEGUROS.SI_MOVIMENTO_SINI D, SEGUROS.SI_ANALISTA_RODIZI E, SEGUROS.SI_SINISTRO_FASE G, SEGUROS.GE_REL_CARTA_DEST I WHERE C.COD_TIPO_CARTA = A.COD_TIPO_CARTA AND B.COD_PRODUTO = C.COD_PRODUTO AND B.COD_GRUPO_CAUSA = C.COD_GRUPO_CAUSA AND B.COD_SUBGRUPO_CAUSA = C.COD_SUBGRUPO_CAUSA AND B.COD_DOCUMENTO = C.COD_DOCUMENTO AND B.DATA_INIVIG_DOCPAR = C.DATA_INIVIG_DOCPAR AND B.COD_FONTE = D.COD_FONTE AND B.NUM_PROTOCOLO_SINI = D.NUM_PROTOCOLO_SINI AND B.DAC_PROTOCOLO_SINI = D.DAC_PROTOCOLO_SINI AND B.COD_FONTE = E.COD_FONTE AND B.NUM_PROTOCOLO_SINI = E.NUM_PROTOCOLO_SINI AND B.DAC_PROTOCOLO_SINI = E.DAC_PROTOCOLO_SINI AND B.COD_FONTE = G.COD_FONTE AND B.NUM_PROTOCOLO_SINI = G.NUM_PROTOCOLO_SINI AND B.DAC_PROTOCOLO_SINI = G.DAC_PROTOCOLO_SINI AND G.COD_FASE NOT IN (3, 4) AND G.NUM_OCORR_SINIACO = (SELECT MAX(H.NUM_OCORR_SINIACO) FROM SEGUROS.SI_SINISTRO_FASE H WHERE H.COD_FONTE = G.COD_FONTE AND H.NUM_PROTOCOLO_SINI = G.NUM_PROTOCOLO_SINI AND H.DAC_PROTOCOLO_SINI = G.DAC_PROTOCOLO_SINI AND H.DATA_ABERTURA_SIFA <= :SISTEMAS-DATA-MOV-ABERTO) AND B.NUM_CARTA IS NOT NULL AND B.NUM_CARTA = I.NUM_CARTA AND C.COD_TIPO_CARTA = 30 AND B.COD_DOCUMENTO = 40 AND B.COD_EVENTO IN (2012, 2013) AND B.NUM_OCORR_DOCACO = (SELECT MAX(F.NUM_OCORR_DOCACO) FROM SEGUROS.SI_DOCUMENTO_ACOMP F WHERE F.COD_FONTE = B.COD_FONTE AND F.NUM_PROTOCOLO_SINI = B.NUM_PROTOCOLO_SINI AND F.DAC_PROTOCOLO_SINI = B.DAC_PROTOCOLO_SINI AND F.COD_DOCUMENTO = B.COD_DOCUMENTO AND F.DATA_MOVTO_DOCACO <= :SISTEMAS-DATA-MOV-ABERTO) GROUP BY E.COD_USUARIO, C.COD_TIPO_CARTA, A.DESCR_EVENTO, B.COD_FONTE, B.NUM_PROTOCOLO_SINI, B.DAC_PROTOCOLO_SINI, B.DATA_MOVTO_DOCACO, D.NATUREZA_SINISTRO, D.NOME_SEGURADO, D.COD_GIAFI, I.COD_DESTINATARIO ORDER BY E.COD_USUARIO, I.COD_DESTINATARIO, C.COD_TIPO_CARTA, B.DATA_MOVTO_DOCACO, B.COD_FONTE, B.NUM_PROTOCOLO_SINI END-EXEC. */
            LISTA = new SI0038B_LISTA(true);
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
							AND C.COD_TIPO_CARTA = 30 
							AND B.COD_DOCUMENTO = 40 
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
							ORDER BY E.COD_USUARIO
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
            /*" -450- EXEC SQL OPEN LISTA END-EXEC. */

            LISTA.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-LE-LISTA-SECTION */
        private void R0910_00_LE_LISTA_SECTION()
        {
            /*" -465- MOVE '091' TO WNR-EXEC-SQL. */
            _.Move("091", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -477- PERFORM R0910_00_LE_LISTA_DB_FETCH_1 */

            R0910_00_LE_LISTA_DB_FETCH_1();

            /*" -480- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -481- ADD 1 TO AC-L-LISTA */
                AREA_DE_WORK.AC_L_LISTA.Value = AREA_DE_WORK.AC_L_LISTA + 1;

                /*" -482- ELSE */
            }
            else
            {


                /*" -483- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -484- MOVE 'S' TO WFIM-LISTA */
                    _.Move("S", AREA_DE_WORK.WFIM_LISTA);

                    /*" -484- PERFORM R0910_00_LE_LISTA_DB_CLOSE_1 */

                    R0910_00_LE_LISTA_DB_CLOSE_1();

                    /*" -486- ELSE */
                }
                else
                {


                    /*" -488- DISPLAY 'SI0038B - PROBLEMAS NO FETCH LISTA ' ' ' SISTEMAS-DATA-MOV-ABERTO */

                    $"SI0038B - PROBLEMAS NO FETCH LISTA  {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}"
                    .Display();

                    /*" -488- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0910-00-LE-LISTA-DB-FETCH-1 */
        public void R0910_00_LE_LISTA_DB_FETCH_1()
        {
            /*" -477- EXEC SQL FETCH LISTA INTO :SIANAROD-COD-USUARIO, :SIDOCPAR-COD-TIPO-CARTA, :SIEVETIP-DESCR-EVENTO, :SIDOCACO-COD-FONTE, :SIDOCACO-NUM-PROTOCOLO-SINI, :SIDOCACO-DAC-PROTOCOLO-SINI, :SIDOCACO-DATA-MOVTO-DOCACO, :SIMOVSIN-NATUREZA-SINISTRO, :SIMOVSIN-NOME-SEGURADO, :SIMOVSIN-COD-GIAFI, :GERECADE-COD-DESTINATARIO END-EXEC. */

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
            /*" -484- EXEC SQL CLOSE LISTA END-EXEC */

            LISTA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-SECTION */
        private void R1000_00_PROCESSA_SECTION()
        {
            /*" -498- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -500- MOVE 80 TO AC-LINHAS */
            _.Move(80, AREA_DE_WORK.AC_LINHAS);

            /*" -502- PERFORM R1100-00-LE-USUARIOS */

            R1100_00_LE_USUARIOS_SECTION();

            /*" -504- MOVE SIANAROD-COD-USUARIO TO WS-COD-USUARIO-ANT */
            _.Move(SIANAROD.DCLSI_ANALISTA_RODIZI.SIANAROD_COD_USUARIO, WS_COD_USUARIO_ANT);

            /*" -509- PERFORM R2000-00-PROCESSA-ANALISTA UNTIL WFIM-LISTA EQUAL 'S' OR SIANAROD-COD-USUARIO NOT EQUAL WS-COD-USUARIO-ANT */

            while (!(AREA_DE_WORK.WFIM_LISTA == "S" || SIANAROD.DCLSI_ANALISTA_RODIZI.SIANAROD_COD_USUARIO != WS_COD_USUARIO_ANT))
            {

                R2000_00_PROCESSA_ANALISTA_SECTION();
            }

            /*" -509- PERFORM R1900-00-TOTAL-ANALISTA. */

            R1900_00_TOTAL_ANALISTA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-LE-USUARIOS-SECTION */
        private void R1100_00_LE_USUARIOS_SECTION()
        {
            /*" -519- MOVE '110' TO WNR-EXEC-SQL. */
            _.Move("110", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -524- PERFORM R1100_00_LE_USUARIOS_DB_SELECT_1 */

            R1100_00_LE_USUARIOS_DB_SELECT_1();

            /*" -527- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -528- DISPLAY 'SI0038B - PROBLEMAS NO SELECT USUARIOS' */
                _.Display($"SI0038B - PROBLEMAS NO SELECT USUARIOS");

                /*" -532- DISPLAY ' ' SIDOCACO-COD-FONTE ' ' SIDOCACO-NUM-PROTOCOLO-SINI ' ' SIDOCACO-DAC-PROTOCOLO-SINI ' ' SIANAROD-COD-USUARIO */

                $" {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_FONTE} {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_PROTOCOLO_SINI} {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DAC_PROTOCOLO_SINI} {SIANAROD.DCLSI_ANALISTA_RODIZI.SIANAROD_COD_USUARIO}"
                .Display();

                /*" -532- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1100-00-LE-USUARIOS-DB-SELECT-1 */
        public void R1100_00_LE_USUARIOS_DB_SELECT_1()
        {
            /*" -524- EXEC SQL SELECT NOME_USUARIO INTO :USUARIOS-NOME-USUARIO FROM SEGUROS.USUARIOS WHERE COD_USUARIO = :SIANAROD-COD-USUARIO END-EXEC. */

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
            /*" -542- MOVE '190' TO WNR-EXEC-SQL. */
            _.Move("190", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -543- IF AC-LINHAS GREATER 55 */

            if (AREA_DE_WORK.AC_LINHAS > 55)
            {

                /*" -545- PERFORM R4000-00-CABECALHO. */

                R4000_00_CABECALHO_SECTION();
            }


            /*" -546- MOVE 'TOTAL DO ANALISTA...' TO LD02-LITERAL */
            _.Move("TOTAL DO ANALISTA...", LD02.LD02_LITERAL);

            /*" -548- MOVE AC-A-SINISTROS TO LD02-TOTAL */
            _.Move(AREA_DE_WORK.AC_A_SINISTROS, LD02.LD02_TOTAL);

            /*" -549- WRITE REG-SI0038B1 FROM LC00 */
            _.Move(LC00.GetMoveValues(), REG_SI0038B1);

            SI0038B1.Write(REG_SI0038B1.GetMoveValues().ToString());

            /*" -550- WRITE REG-SI0038B1 FROM LD02 */
            _.Move(LD02.GetMoveValues(), REG_SI0038B1);

            SI0038B1.Write(REG_SI0038B1.GetMoveValues().ToString());

            /*" -552- ADD 2 TO AC-LINHAS */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 2;

            /*" -553- ADD AC-A-SINISTROS TO AC-G-SINISTROS */
            AREA_DE_WORK.AC_G_SINISTROS.Value = AREA_DE_WORK.AC_G_SINISTROS + AREA_DE_WORK.AC_A_SINISTROS;

            /*" -553- MOVE ZEROS TO AC-A-SINISTROS. */
            _.Move(0, AREA_DE_WORK.AC_A_SINISTROS);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-PROCESSA-ANALISTA-SECTION */
        private void R2000_00_PROCESSA_ANALISTA_SECTION()
        {
            /*" -563- MOVE '200' TO WNR-EXEC-SQL. */
            _.Move("200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -565- PERFORM R2100-00-LE-GEDESTIN */

            R2100_00_LE_GEDESTIN_SECTION();

            /*" -568- MOVE GERECADE-COD-DESTINATARIO TO WS-COD-DESTINATARIO-ANT */
            _.Move(GERECADE.DCLGE_REL_CARTA_DEST.GERECADE_COD_DESTINATARIO, WS_COD_DESTINATARIO_ANT);

            /*" -569- IF AC-LINHAS GREATER 55 */

            if (AREA_DE_WORK.AC_LINHAS > 55)
            {

                /*" -570- PERFORM R4000-00-CABECALHO */

                R4000_00_CABECALHO_SECTION();

                /*" -571- PERFORM R4100-00-CABECALHO-FILIAL */

                R4100_00_CABECALHO_FILIAL_SECTION();

                /*" -572- ELSE */
            }
            else
            {


                /*" -574- PERFORM R4100-00-CABECALHO-FILIAL. */

                R4100_00_CABECALHO_FILIAL_SECTION();
            }


            /*" -582- PERFORM R3000-00-PROCESSA-FILIAL UNTIL WFIM-LISTA EQUAL 'S' OR SIANAROD-COD-USUARIO NOT EQUAL WS-COD-USUARIO-ANT OR GERECADE-COD-DESTINATARIO NOT EQUAL WS-COD-DESTINATARIO-ANT */

            while (!(AREA_DE_WORK.WFIM_LISTA == "S" || SIANAROD.DCLSI_ANALISTA_RODIZI.SIANAROD_COD_USUARIO != WS_COD_USUARIO_ANT || GERECADE.DCLGE_REL_CARTA_DEST.GERECADE_COD_DESTINATARIO != WS_COD_DESTINATARIO_ANT))
            {

                R3000_00_PROCESSA_FILIAL_SECTION();
            }

            /*" -582- PERFORM R2900-00-TOTAL-FILIAL. */

            R2900_00_TOTAL_FILIAL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-LE-GEDESTIN-SECTION */
        private void R2100_00_LE_GEDESTIN_SECTION()
        {
            /*" -592- MOVE '210' TO WNR-EXEC-SQL. */
            _.Move("210", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -598- PERFORM R2100_00_LE_GEDESTIN_DB_SELECT_1 */

            R2100_00_LE_GEDESTIN_DB_SELECT_1();

            /*" -601- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -602- DISPLAY 'SI0038B - PROBLEMAS NO SELECT GE_DESTINATARIO' */
                _.Display($"SI0038B - PROBLEMAS NO SELECT GE_DESTINATARIO");

                /*" -606- DISPLAY ' ' SIDOCACO-COD-FONTE ' ' SIDOCACO-NUM-PROTOCOLO-SINI ' ' SIDOCACO-DAC-PROTOCOLO-SINI ' ' GERECADE-COD-DESTINATARIO */

                $" {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_FONTE} {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_PROTOCOLO_SINI} {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DAC_PROTOCOLO_SINI} {GERECADE.DCLGE_REL_CARTA_DEST.GERECADE_COD_DESTINATARIO}"
                .Display();

                /*" -606- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2100-00-LE-GEDESTIN-DB-SELECT-1 */
        public void R2100_00_LE_GEDESTIN_DB_SELECT_1()
        {
            /*" -598- EXEC SQL SELECT NOME_DESTINATARIO INTO :GEDESTIN-NOME-DESTINATARIO FROM SEGUROS.GE_DESTINATARIO WHERE COD_DESTINATARIO = :GERECADE-COD-DESTINATARIO END-EXEC. */

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
        /*" R2900-00-TOTAL-FILIAL-SECTION */
        private void R2900_00_TOTAL_FILIAL_SECTION()
        {
            /*" -616- MOVE '290' TO WNR-EXEC-SQL. */
            _.Move("290", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -617- IF AC-LINHAS GREATER 55 */

            if (AREA_DE_WORK.AC_LINHAS > 55)
            {

                /*" -619- PERFORM R4000-00-CABECALHO. */

                R4000_00_CABECALHO_SECTION();
            }


            /*" -620- MOVE 'TOTAL DA FILIAL.....' TO LD02-LITERAL */
            _.Move("TOTAL DA FILIAL.....", LD02.LD02_LITERAL);

            /*" -622- MOVE AC-F-SINISTROS TO LD02-TOTAL */
            _.Move(AREA_DE_WORK.AC_F_SINISTROS, LD02.LD02_TOTAL);

            /*" -623- WRITE REG-SI0038B1 FROM LC00 */
            _.Move(LC00.GetMoveValues(), REG_SI0038B1);

            SI0038B1.Write(REG_SI0038B1.GetMoveValues().ToString());

            /*" -624- WRITE REG-SI0038B1 FROM LD02 */
            _.Move(LD02.GetMoveValues(), REG_SI0038B1);

            SI0038B1.Write(REG_SI0038B1.GetMoveValues().ToString());

            /*" -626- ADD 2 TO AC-LINHAS */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 2;

            /*" -627- ADD AC-F-SINISTROS TO AC-A-SINISTROS */
            AREA_DE_WORK.AC_A_SINISTROS.Value = AREA_DE_WORK.AC_A_SINISTROS + AREA_DE_WORK.AC_F_SINISTROS;

            /*" -627- MOVE ZEROS TO AC-F-SINISTROS. */
            _.Move(0, AREA_DE_WORK.AC_F_SINISTROS);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2900_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-PROCESSA-FILIAL-SECTION */
        private void R3000_00_PROCESSA_FILIAL_SECTION()
        {
            /*" -637- MOVE '300' TO WNR-EXEC-SQL. */
            _.Move("300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -638- PERFORM R3100-00-LE-SISINACO */

            R3100_00_LE_SISINACO_SECTION();

            /*" -640- PERFORM R3200-00-LE-SINISMES */

            R3200_00_LE_SINISMES_SECTION();

            /*" -641- MOVE SIDOCACO-COD-FONTE TO LD01-COD-FONTE */
            _.Move(SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_FONTE, LD01.LD01_COD_FONTE);

            /*" -643- MOVE SIDOCACO-NUM-PROTOCOLO-SINI TO LD01-NUM-PROTOCOLO */
            _.Move(SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_PROTOCOLO_SINI, LD01.LD01_NUM_PROTOCOLO);

            /*" -645- MOVE SIDOCACO-DAC-PROTOCOLO-SINI TO LD01-DAC-PROTOCOLO */
            _.Move(SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DAC_PROTOCOLO_SINI, LD01.LD01_DAC_PROTOCOLO);

            /*" -646- MOVE SINISMES-NUM-IRB TO LD01-NUM-IRB */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_IRB, LD01.LD01_NUM_IRB);

            /*" -649- MOVE SIMOVSIN-NOME-SEGURADO TO LD01-NOME-SEGURADO */
            _.Move(SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_NOME_SEGURADO, LD01.LD01_NOME_SEGURADO);

            /*" -651- IF SIMOVSIN-NATUREZA-SINISTRO EQUAL 1 */

            if (SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_NATUREZA_SINISTRO == 1)
            {

                /*" -652- MOVE 'MIP' TO LD01-TIPO-SINISTRO */
                _.Move("MIP", LD01.LD01_TIPO_SINISTRO);

                /*" -653- ELSE */
            }
            else
            {


                /*" -655- MOVE 'DFI' TO LD01-TIPO-SINISTRO. */
                _.Move("DFI", LD01.LD01_TIPO_SINISTRO);
            }


            /*" -657- IF SISINACO-DATA-MOVTO-SINIACO EQUAL SPACES */

            if (SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DATA_MOVTO_SINIACO.IsEmpty())
            {

                /*" -658- MOVE SPACES TO LD01-DATA-AVISO */
                _.Move("", LD01.LD01_DATA_AVISO);

                /*" -659- ELSE */
            }
            else
            {


                /*" -661- MOVE SISINACO-DATA-MOVTO-SINIACO TO DB2-DATA */
                _.Move(SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DATA_MOVTO_SINIACO, AREA_DE_WORK.DB2_DATA);

                /*" -662- MOVE DB2-DIA TO EDIT-DIA */
                _.Move(AREA_DE_WORK.DB2_DATA.DB2_DIA, AREA_DE_WORK.EDIT_DATA.EDIT_DIA);

                /*" -663- MOVE DB2-MES TO EDIT-MES */
                _.Move(AREA_DE_WORK.DB2_DATA.DB2_MES, AREA_DE_WORK.EDIT_DATA.EDIT_MES);

                /*" -664- MOVE DB2-ANO TO EDIT-ANO */
                _.Move(AREA_DE_WORK.DB2_DATA.DB2_ANO, AREA_DE_WORK.EDIT_DATA.EDIT_ANO);

                /*" -666- MOVE EDIT-DATA TO LD01-DATA-AVISO. */
                _.Move(AREA_DE_WORK.EDIT_DATA, LD01.LD01_DATA_AVISO);
            }


            /*" -669- MOVE SIEVETIP-DESCR-EVENTO TO LD01-DESCR-EVENTO */
            _.Move(SIEVETIP.DCLSI_EVENTO_TIPO.SIEVETIP_DESCR_EVENTO, LD01.LD01_DESCR_EVENTO);

            /*" -671- MOVE SIDOCACO-DATA-MOVTO-DOCACO TO DB2-DATA */
            _.Move(SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DATA_MOVTO_DOCACO, AREA_DE_WORK.DB2_DATA);

            /*" -672- MOVE DB2-DIA TO EDIT-DIA */
            _.Move(AREA_DE_WORK.DB2_DATA.DB2_DIA, AREA_DE_WORK.EDIT_DATA.EDIT_DIA);

            /*" -673- MOVE DB2-MES TO EDIT-MES */
            _.Move(AREA_DE_WORK.DB2_DATA.DB2_MES, AREA_DE_WORK.EDIT_DATA.EDIT_MES);

            /*" -674- MOVE DB2-ANO TO EDIT-ANO */
            _.Move(AREA_DE_WORK.DB2_DATA.DB2_ANO, AREA_DE_WORK.EDIT_DATA.EDIT_ANO);

            /*" -676- MOVE EDIT-DATA TO LD01-DATA-EVENTO */
            _.Move(AREA_DE_WORK.EDIT_DATA, LD01.LD01_DATA_EVENTO);

            /*" -677- IF AC-LINHAS GREATER 55 */

            if (AREA_DE_WORK.AC_LINHAS > 55)
            {

                /*" -678- PERFORM R4000-00-CABECALHO */

                R4000_00_CABECALHO_SECTION();

                /*" -680- PERFORM R4100-00-CABECALHO-FILIAL. */

                R4100_00_CABECALHO_FILIAL_SECTION();
            }


            /*" -681- WRITE REG-SI0038B1 FROM LD01 */
            _.Move(LD01.GetMoveValues(), REG_SI0038B1);

            SI0038B1.Write(REG_SI0038B1.GetMoveValues().ToString());

            /*" -687- ADD 1 TO AC-LINHAS AC-I-SI0038B1 AC-F-SINISTROS */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 1;
            AREA_DE_WORK.AC_I_SI0038B1.Value = AREA_DE_WORK.AC_I_SI0038B1 + 1;
            AREA_DE_WORK.AC_F_SINISTROS.Value = AREA_DE_WORK.AC_F_SINISTROS + 1;

            /*" -687- PERFORM R0910-00-LE-LISTA. */

            R0910_00_LE_LISTA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-LE-SISINACO-SECTION */
        private void R3100_00_LE_SISINACO_SECTION()
        {
            /*" -697- MOVE '310' TO WNR-EXEC-SQL. */
            _.Move("310", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -707- PERFORM R3100_00_LE_SISINACO_DB_SELECT_1 */

            R3100_00_LE_SISINACO_DB_SELECT_1();

            /*" -710- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -712- MOVE SPACES TO SISINACO-DATA-MOVTO-SINIACO */
                _.Move("", SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DATA_MOVTO_SINIACO);

                /*" -713- ELSE */
            }
            else
            {


                /*" -714- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -715- DISPLAY 'SI0038B - PROBLEMAS NO SELECT SI_SINISTRO_ACOMP' */
                    _.Display($"SI0038B - PROBLEMAS NO SELECT SI_SINISTRO_ACOMP");

                    /*" -718- DISPLAY ' ' SIDOCACO-COD-FONTE ' ' SIDOCACO-NUM-PROTOCOLO-SINI ' ' SIDOCACO-DAC-PROTOCOLO-SINI */

                    $" {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_FONTE} {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_PROTOCOLO_SINI} {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DAC_PROTOCOLO_SINI}"
                    .Display();

                    /*" -718- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R3100-00-LE-SISINACO-DB-SELECT-1 */
        public void R3100_00_LE_SISINACO_DB_SELECT_1()
        {
            /*" -707- EXEC SQL SELECT DATA_MOVTO_SINIACO INTO :SISINACO-DATA-MOVTO-SINIACO FROM SEGUROS.SI_SINISTRO_ACOMP WHERE COD_FONTE = :SIDOCACO-COD-FONTE AND NUM_PROTOCOLO_SINI = :SIDOCACO-NUM-PROTOCOLO-SINI AND DAC_PROTOCOLO_SINI = :SIDOCACO-DAC-PROTOCOLO-SINI AND COD_EVENTO = 1001 END-EXEC. */

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
            /*" -728- MOVE '320' TO WNR-EXEC-SQL. */
            _.Move("320", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -737- PERFORM R3200_00_LE_SINISMES_DB_SELECT_1 */

            R3200_00_LE_SINISMES_DB_SELECT_1();

            /*" -740- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -741- MOVE ZEROS TO SINISMES-NUM-IRB */
                _.Move(0, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_IRB);

                /*" -742- ELSE */
            }
            else
            {


                /*" -743- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -744- DISPLAY 'SI0038B - PROBLEMAS NO SELECT SINISTRO_MESTRE' */
                    _.Display($"SI0038B - PROBLEMAS NO SELECT SINISTRO_MESTRE");

                    /*" -747- DISPLAY ' ' SIDOCACO-COD-FONTE ' ' SIDOCACO-NUM-PROTOCOLO-SINI ' ' SIDOCACO-DAC-PROTOCOLO-SINI */

                    $" {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_FONTE} {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_PROTOCOLO_SINI} {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DAC_PROTOCOLO_SINI}"
                    .Display();

                    /*" -747- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R3200-00-LE-SINISMES-DB-SELECT-1 */
        public void R3200_00_LE_SINISMES_DB_SELECT_1()
        {
            /*" -737- EXEC SQL SELECT NUM_IRB INTO :SINISMES-NUM-IRB FROM SEGUROS.SINISTRO_MESTRE WHERE COD_FONTE = :SIDOCACO-COD-FONTE AND NUM_PROTOCOLO_SINI = :SIDOCACO-NUM-PROTOCOLO-SINI AND DAC_PROTOCOLO_SINI = :SIDOCACO-DAC-PROTOCOLO-SINI END-EXEC. */

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
        /*" R4000-00-CABECALHO-SECTION */
        private void R4000_00_CABECALHO_SECTION()
        {
            /*" -757- MOVE '400' TO WNR-EXEC-SQL. */
            _.Move("400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -758- ADD 1 TO AC-PAGINAS */
            AREA_DE_WORK.AC_PAGINAS.Value = AREA_DE_WORK.AC_PAGINAS + 1;

            /*" -760- MOVE AC-PAGINAS TO LC01-PAGINA */
            _.Move(AREA_DE_WORK.AC_PAGINAS, LC01.LC01_PAGINA);

            /*" -762- MOVE SISTEMAS-DATA-MOV-ABERTO TO DB2-DATA */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREA_DE_WORK.DB2_DATA);

            /*" -763- MOVE DB2-DIA TO EDIT-DIA */
            _.Move(AREA_DE_WORK.DB2_DATA.DB2_DIA, AREA_DE_WORK.EDIT_DATA.EDIT_DIA);

            /*" -764- MOVE DB2-MES TO EDIT-MES */
            _.Move(AREA_DE_WORK.DB2_DATA.DB2_MES, AREA_DE_WORK.EDIT_DATA.EDIT_MES);

            /*" -765- MOVE DB2-ANO TO EDIT-ANO */
            _.Move(AREA_DE_WORK.DB2_DATA.DB2_ANO, AREA_DE_WORK.EDIT_DATA.EDIT_ANO);

            /*" -768- MOVE EDIT-DATA TO LC02-DATA LC02-DATA-MOV-ABERTO */
            _.Move(AREA_DE_WORK.EDIT_DATA, LC02.LC02_DATA, LC02.LC02_DATA_MOV_ABERTO);

            /*" -769- ACCEPT ACC-HORA FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.ACC_HORA);

            /*" -770- MOVE ACC-HH TO EDIT-HH */
            _.Move(AREA_DE_WORK.ACC_HORA.ACC_HH, AREA_DE_WORK.EDIT_HORA.EDIT_HH);

            /*" -771- MOVE ACC-MM TO EDIT-MM */
            _.Move(AREA_DE_WORK.ACC_HORA.ACC_MM, AREA_DE_WORK.EDIT_HORA.EDIT_MM);

            /*" -772- MOVE ACC-SS TO EDIT-SS */
            _.Move(AREA_DE_WORK.ACC_HORA.ACC_SS, AREA_DE_WORK.EDIT_HORA.EDIT_SS);

            /*" -774- MOVE EDIT-HORA TO LC03-HORA */
            _.Move(AREA_DE_WORK.EDIT_HORA, LC03.LC03_HORA);

            /*" -777- MOVE USUARIOS-NOME-USUARIO TO LC05-ANALISTA */
            _.Move(USUARIOS.DCLUSUARIOS.USUARIOS_NOME_USUARIO, LC05.LC05_ANALISTA);

            /*" -778- WRITE REG-SI0038B1 FROM LC01 */
            _.Move(LC01.GetMoveValues(), REG_SI0038B1);

            SI0038B1.Write(REG_SI0038B1.GetMoveValues().ToString());

            /*" -779- WRITE REG-SI0038B1 FROM LC02 */
            _.Move(LC02.GetMoveValues(), REG_SI0038B1);

            SI0038B1.Write(REG_SI0038B1.GetMoveValues().ToString());

            /*" -780- WRITE REG-SI0038B1 FROM LC03 */
            _.Move(LC03.GetMoveValues(), REG_SI0038B1);

            SI0038B1.Write(REG_SI0038B1.GetMoveValues().ToString());

            /*" -781- WRITE REG-SI0038B1 FROM LC00 */
            _.Move(LC00.GetMoveValues(), REG_SI0038B1);

            SI0038B1.Write(REG_SI0038B1.GetMoveValues().ToString());

            /*" -782- WRITE REG-SI0038B1 FROM LC04 */
            _.Move(LC04.GetMoveValues(), REG_SI0038B1);

            SI0038B1.Write(REG_SI0038B1.GetMoveValues().ToString());

            /*" -783- WRITE REG-SI0038B1 FROM LC05 */
            _.Move(LC05.GetMoveValues(), REG_SI0038B1);

            SI0038B1.Write(REG_SI0038B1.GetMoveValues().ToString());

            /*" -784- WRITE REG-SI0038B1 FROM LC04 */
            _.Move(LC04.GetMoveValues(), REG_SI0038B1);

            SI0038B1.Write(REG_SI0038B1.GetMoveValues().ToString());

            /*" -785- WRITE REG-SI0038B1 FROM LC07 */
            _.Move(LC07.GetMoveValues(), REG_SI0038B1);

            SI0038B1.Write(REG_SI0038B1.GetMoveValues().ToString());

            /*" -786- WRITE REG-SI0038B1 FROM LC04 */
            _.Move(LC04.GetMoveValues(), REG_SI0038B1);

            SI0038B1.Write(REG_SI0038B1.GetMoveValues().ToString());

            /*" -788- WRITE REG-SI0038B1 FROM LC00 */
            _.Move(LC00.GetMoveValues(), REG_SI0038B1);

            SI0038B1.Write(REG_SI0038B1.GetMoveValues().ToString());

            /*" -788- MOVE 10 TO AC-LINHAS. */
            _.Move(10, AREA_DE_WORK.AC_LINHAS);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R4100-00-CABECALHO-FILIAL-SECTION */
        private void R4100_00_CABECALHO_FILIAL_SECTION()
        {
            /*" -798- MOVE '410' TO WNR-EXEC-SQL. */
            _.Move("410", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -801- MOVE GEDESTIN-NOME-DESTINATARIO TO LC06-FILIAL */
            _.Move(GEDESTIN.DCLGE_DESTINATARIO.GEDESTIN_NOME_DESTINATARIO, LC06.LC06_FILIAL);

            /*" -802- WRITE REG-SI0038B1 FROM LC06 */
            _.Move(LC06.GetMoveValues(), REG_SI0038B1);

            SI0038B1.Write(REG_SI0038B1.GetMoveValues().ToString());

            /*" -804- WRITE REG-SI0038B1 FROM LC00 */
            _.Move(LC00.GetMoveValues(), REG_SI0038B1);

            SI0038B1.Write(REG_SI0038B1.GetMoveValues().ToString());

            /*" -804- ADD 2 TO AC-LINHAS. */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 2;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4100_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -814- CLOSE SI0038B1 */
            SI0038B1.Close();

            /*" -815- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -817- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -819- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -819- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -822- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -823- DISPLAY '***   SI0038B - CANCELADO  ***' */
            _.Display($"***   SI0038B - CANCELADO  ***");

            /*" -825- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -825- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}