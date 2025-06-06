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
using Sias.Sinistro.DB2.SI0036B;

namespace Code
{
    public class SI0036B
    {
        public bool IsCall { get; set; }

        public SI0036B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-------------------------------------                                  */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................ SINISTRO HABITACIONAL               *      */
        /*"      *   SUBROTINA............... SI0036B                             *      */
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

        public FileBasis _SI0036B1 { get; set; } = new FileBasis(new PIC("X", "200", "X(200)"));

        public FileBasis SI0036B1
        {
            get
            {
                _.Move(REG_SI0036B1, _SI0036B1); VarBasis.RedefinePassValue(REG_SI0036B1, _SI0036B1, REG_SI0036B1); return _SI0036B1;
            }
        }
        /*"01          REG-SI0036B1         PIC  X(200).*/
        public StringBasis REG_SI0036B1 { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01          HOST-DATA-AVISO      PIC  X(010)   VALUE   SPACES.*/
        public StringBasis HOST_DATA_AVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01          WS-COD-USUARIO-ANT   PIC  X(008)   VALUE   SPACES.*/
        public StringBasis WS_COD_USUARIO_ANT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"01          WS-COD-DESTINATARIO-ANT                                 PIC S9(004)   VALUE +0 COMP.*/
        public IntBasis WS_COD_DESTINATARIO_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          WS-COD-FONTE-ANT                                 PIC S9(004)   VALUE +0 COMP.*/
        public IntBasis WS_COD_FONTE_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          WS-NUM-PROTOCOLO-SINI-ANT                                 PIC S9(009)   VALUE +0 COMP.*/
        public IntBasis WS_NUM_PROTOCOLO_SINI_ANT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01          WS-DAC-PROTOCOLO-SINI-ANT                                 PIC  X(001)   VALUE   SPACES.*/
        public StringBasis WS_DAC_PROTOCOLO_SINI_ANT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01          AREA-DE-WORK.*/
        public SI0036B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SI0036B_AREA_DE_WORK();
        public class SI0036B_AREA_DE_WORK : VarBasis
        {
            /*"  05        AC-L-LISTA           PIC  9(006)   VALUE   ZEROS.*/
            public IntBasis AC_L_LISTA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05        AC-I-SI0036B1        PIC  9(006)   VALUE   ZEROS.*/
            public IntBasis AC_I_SI0036B1 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
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
            /*"  05        WS-QUEBRA-PROTOCOLO  PIC  X(001)   VALUE   SPACES.*/
            public StringBasis WS_QUEBRA_PROTOCOLO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05        AC-LINHAS            PIC  9(006)   VALUE   ZEROS.*/
            public IntBasis AC_LINHAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05        AC-PAGINAS           PIC  9(006)   VALUE   ZEROS.*/
            public IntBasis AC_PAGINAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05        DB2-DATA.*/
            public SI0036B_DB2_DATA DB2_DATA { get; set; } = new SI0036B_DB2_DATA();
            public class SI0036B_DB2_DATA : VarBasis
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
            public SI0036B_EDIT_DATA EDIT_DATA { get; set; } = new SI0036B_EDIT_DATA();
            public class SI0036B_EDIT_DATA : VarBasis
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
            public SI0036B_ACC_HORA ACC_HORA { get; set; } = new SI0036B_ACC_HORA();
            public class SI0036B_ACC_HORA : VarBasis
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
            public SI0036B_EDIT_HORA EDIT_HORA { get; set; } = new SI0036B_EDIT_HORA();
            public class SI0036B_EDIT_HORA : VarBasis
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
            public SI0036B_WABEND WABEND { get; set; } = new SI0036B_WABEND();
            public class SI0036B_WABEND : VarBasis
            {
                /*"    10      FILLER               PIC  X(010) VALUE           ' SI0036B'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SI0036B");
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
        public SI0036B_LC00 LC00 { get; set; } = new SI0036B_LC00();
        public class SI0036B_LC00 : VarBasis
        {
            /*"  05        LC00-CANAL           PIC  X(001) VALUE ' '.*/
            public StringBasis LC00_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"  05        FILLER               PIC  X(199) VALUE SPACES.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "199", "X(199)"), @"");
            /*"01          LC01.*/
        }
        public SI0036B_LC01 LC01 { get; set; } = new SI0036B_LC01();
        public class SI0036B_LC01 : VarBasis
        {
            /*"  05        LC01-CANAL           PIC  X(001) VALUE '1'.*/
            public StringBasis LC01_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
            /*"  05        FILLER               PIC  X(075) VALUE 'SI0036B'.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "75", "X(075)"), @"SI0036B");
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
        public SI0036B_LC02 LC02 { get; set; } = new SI0036B_LC02();
        public class SI0036B_LC02 : VarBasis
        {
            /*"  05        LC02-CANAL           PIC  X(001) VALUE ' '.*/
            public StringBasis LC02_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"  05        FILLER               PIC  X(074) VALUE SPACES.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "74", "X(074)"), @"");
            /*"  05        FILLER               PIC  X(028) VALUE                                  'PENDENTE NO ESTIPULANTE ATE '*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @"PENDENTE NO ESTIPULANTE ATE ");
            /*"  05        LC02-DATA-MOV-ABERTO PIC  X(010) VALUE SPACES.*/
            public StringBasis LC02_DATA_MOV_ABERTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05        FILLER               PIC  X(060) VALUE SPACES.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
            /*"  05        FILLER               PIC  X(007) VALUE 'DATA'.*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"DATA");
            /*"  05        LC02-DATA            PIC  X(010) VALUE SPACES.*/
            public StringBasis LC02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"01          LC03.*/
        }
        public SI0036B_LC03 LC03 { get; set; } = new SI0036B_LC03();
        public class SI0036B_LC03 : VarBasis
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
        public SI0036B_LC04 LC04 { get; set; } = new SI0036B_LC04();
        public class SI0036B_LC04 : VarBasis
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
        public SI0036B_LC05 LC05 { get; set; } = new SI0036B_LC05();
        public class SI0036B_LC05 : VarBasis
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
        public SI0036B_LC06 LC06 { get; set; } = new SI0036B_LC06();
        public class SI0036B_LC06 : VarBasis
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
        public SI0036B_LC07 LC07 { get; set; } = new SI0036B_LC07();
        public class SI0036B_LC07 : VarBasis
        {
            /*"  05        LC07-CANAL           PIC  X(001) VALUE ' '.*/
            public StringBasis LC07_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"  05        FILLER               PIC  X(009) VALUE SPACES.*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
            /*"  05        FILLER               PIC  X(013) VALUE ' CONTRATO'.*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" CONTRATO");
            /*"  05        FILLER               PIC  X(017) VALUE                                                  'SINISTRO IRB'*/
            public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"SINISTRO IRB");
            /*"  05        FILLER               PIC  X(045) VALUE                                              'NOME DO SEGURADO'*/
            public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"NOME DO SEGURADO");
            /*"  05        FILLER               PIC  X(008) VALUE 'TIPO'.*/
            public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"TIPO");
            /*"  05        FILLER               PIC  X(015) VALUE                                              'DATA AVISO'.*/
            public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"DATA AVISO");
            /*"  05        FILLER               PIC  X(060) VALUE                                            'DOCUMENTO PENDENTE'*/
            public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"DOCUMENTO PENDENTE");
            /*"  05        FILLER               PIC  X(020) VALUE                                            'ULTIMA SOLICITACAO'*/
            public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"ULTIMA SOLICITACAO");
            /*"01          LD01.*/
        }
        public SI0036B_LD01 LD01 { get; set; } = new SI0036B_LD01();
        public class SI0036B_LD01 : VarBasis
        {
            /*"  05        LD01-CANAL           PIC  X(001) VALUE ' '.*/
            public StringBasis LD01_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"  05        FILLER               PIC  X(003) VALUE SPACES.*/
            public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05        LD01-CHAVE.*/
            public SI0036B_LD01_CHAVE LD01_CHAVE { get; set; } = new SI0036B_LD01_CHAVE();
            public class SI0036B_LD01_CHAVE : VarBasis
            {
                /*"    10      LD01-NUM-CONTRATO    PIC  9.9999.99999999.*/
                public IntBasis LD01_NUM_CONTRATO { get; set; } = new IntBasis(new PIC("9", "13", "9.9999.99999999."));
                /*"    10      FILLER               PIC  X(005) VALUE SPACES.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"    10      LD01-NUM-IRB         PIC  ZZZZZZZZZZ9.*/
                public IntBasis LD01_NUM_IRB { get; set; } = new IntBasis(new PIC("9", "11", "ZZZZZZZZZZ9."));
                /*"    10      FILLER               PIC  X(005) VALUE SPACES.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"    10      LD01-NOME-SEGURADO   PIC  X(040) VALUE SPACES.*/
                public StringBasis LD01_NOME_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    10      FILLER               PIC  X(005) VALUE SPACES.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"    10      LD01-TIPO-SINISTRO   PIC  X(003) VALUE SPACES.*/
                public StringBasis LD01_TIPO_SINISTRO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10      FILLER               PIC  X(005) VALUE SPACES.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"    10      LD01-DATA-AVISO      PIC  X(010) VALUE SPACES.*/
                public StringBasis LD01_DATA_AVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  05        FILLER               PIC  X(005) VALUE SPACES.*/
            }
            public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
            /*"  05        LD01-DESCR-DOCUMENTO PIC  X(060) VALUE SPACES.*/
            public StringBasis LD01_DESCR_DOCUMENTO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
            /*"  05        FILLER               PIC  X(005) VALUE SPACES.*/
            public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
            /*"  05        LD01-DATA-EVENTO     PIC  X(010) VALUE SPACES.*/
            public StringBasis LD01_DATA_EVENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05        FILLER               PIC  X(007) VALUE SPACES.*/
            public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
            /*"01          LD02.*/
        }
        public SI0036B_LD02 LD02 { get; set; } = new SI0036B_LD02();
        public class SI0036B_LD02 : VarBasis
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
        public Dclgens.SISINFAS SISINFAS { get; set; } = new Dclgens.SISINFAS();
        public Dclgens.SIDOCACO SIDOCACO { get; set; } = new Dclgens.SIDOCACO();
        public Dclgens.SIDOCPAR SIDOCPAR { get; set; } = new Dclgens.SIDOCPAR();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.SIMOVSIN SIMOVSIN { get; set; } = new Dclgens.SIMOVSIN();
        public Dclgens.SIANAROD SIANAROD { get; set; } = new Dclgens.SIANAROD();
        public Dclgens.GEDOCTIP GEDOCTIP { get; set; } = new Dclgens.GEDOCTIP();
        public Dclgens.USUARIOS USUARIOS { get; set; } = new Dclgens.USUARIOS();
        public Dclgens.GERECADE GERECADE { get; set; } = new Dclgens.GERECADE();
        public Dclgens.GEDESTIN GEDESTIN { get; set; } = new Dclgens.GEDESTIN();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public SI0036B_LISTA LISTA { get; set; } = new SI0036B_LISTA();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SI0036B1_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SI0036B1.SetFile(SI0036B1_FILE_NAME_P);

                /*" -236- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -236- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -237- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -238- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -238- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -246- OPEN OUTPUT SI0036B1 */
            SI0036B1.Open(REG_SI0036B1);

            /*" -248- PERFORM R0500-00-LE-SISTEMAS */

            R0500_00_LE_SISTEMAS_SECTION();

            /*" -250- PERFORM R0600-00-LE-RELATORIOS */

            R0600_00_LE_RELATORIOS_SECTION();

            /*" -251- IF WFIM-RELATORI EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_RELATORI == "S")
            {

                /*" -252- DISPLAY '******************************************' */
                _.Display($"******************************************");

                /*" -253- DISPLAY '* NAO HOUVE SOLICITACAO PARA O RELATORIO *' */
                _.Display($"* NAO HOUVE SOLICITACAO PARA O RELATORIO *");

                /*" -254- DISPLAY '******************************************' */
                _.Display($"******************************************");

                /*" -255- DISPLAY ' ' */
                _.Display($" ");

                /*" -257- GO TO R0000-90-ENCERRA. */

                R0000_90_ENCERRA(); //GOTO
                return;
            }


            /*" -258- PERFORM R0900-00-DECLARA-LISTA */

            R0900_00_DECLARA_LISTA_SECTION();

            /*" -260- PERFORM R0910-00-LE-LISTA */

            R0910_00_LE_LISTA_SECTION();

            /*" -261- IF WFIM-LISTA EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_LISTA == "S")
            {

                /*" -268- GO TO R0000-90-ENCERRA. */

                R0000_90_ENCERRA(); //GOTO
                return;
            }


            /*" -271- PERFORM R1000-00-PROCESSA UNTIL WFIM-LISTA EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_LISTA == "S"))
            {

                R1000_00_PROCESSA_SECTION();
            }

            /*" -276- PERFORM R0800-00-TOTAL-GERAL */

            R0800_00_TOTAL_GERAL_SECTION();

            /*" -276- PERFORM R0700-00-ALTERA-RELATORIOS. */

            R0700_00_ALTERA_RELATORIOS_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_ENCERRA */

            R0000_90_ENCERRA();

        }

        [StopWatch]
        /*" R0000-90-ENCERRA */
        private void R0000_90_ENCERRA(bool isPerform = false)
        {
            /*" -282- CLOSE SI0036B1 */
            SI0036B1.Close();

            /*" -284- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -285- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -286- DISPLAY '***   SI0036B - FIM NORMAL ***' */
            _.Display($"***   SI0036B - FIM NORMAL ***");

            /*" -287- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -288- DISPLAY 'LIDOS      SIDOCACO  -  ' AC-L-LISTA */
            _.Display($"LIDOS      SIDOCACO  -  {AREA_DE_WORK.AC_L_LISTA}");

            /*" -290- DISPLAY 'IMPRESSOS  SI0036B1  -  ' AC-I-SI0036B1 */
            _.Display($"IMPRESSOS  SI0036B1  -  {AREA_DE_WORK.AC_I_SI0036B1}");

            /*" -290- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0500-00-LE-SISTEMAS-SECTION */
        private void R0500_00_LE_SISTEMAS_SECTION()
        {
            /*" -298- MOVE '050' TO WNR-EXEC-SQL. */
            _.Move("050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -303- PERFORM R0500_00_LE_SISTEMAS_DB_SELECT_1 */

            R0500_00_LE_SISTEMAS_DB_SELECT_1();

            /*" -306- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -307- DISPLAY 'SI0036B - PROBLEMAS NO SELECT SISTEMAS' */
                _.Display($"SI0036B - PROBLEMAS NO SELECT SISTEMAS");

                /*" -307- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0500-00-LE-SISTEMAS-DB-SELECT-1 */
        public void R0500_00_LE_SISTEMAS_DB_SELECT_1()
        {
            /*" -303- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' END-EXEC. */

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
            /*" -317- MOVE '060' TO WNR-EXEC-SQL. */
            _.Move("060", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -325- PERFORM R0600_00_LE_RELATORIOS_DB_SELECT_1 */

            R0600_00_LE_RELATORIOS_DB_SELECT_1();

            /*" -328- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -329- MOVE 'S' TO WFIM-RELATORI */
                _.Move("S", AREA_DE_WORK.WFIM_RELATORI);

                /*" -330- ELSE */
            }
            else
            {


                /*" -331- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -332- DISPLAY 'SI0036B - PROBLEMAS NO SELECT RELATORIOS' */
                    _.Display($"SI0036B - PROBLEMAS NO SELECT RELATORIOS");

                    /*" -332- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0600-00-LE-RELATORIOS-DB-SELECT-1 */
        public void R0600_00_LE_RELATORIOS_DB_SELECT_1()
        {
            /*" -325- EXEC SQL SELECT COD_USUARIO INTO :RELATORI-COD-USUARIO FROM SEGUROS.RELATORIOS WHERE COD_RELATORIO = 'SI0036B' AND IDE_SISTEMA = 'SI' AND DATA_SOLICITACAO = :SISTEMAS-DATA-MOV-ABERTO AND SIT_REGISTRO = '0' END-EXEC. */

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
            /*" -342- MOVE '070' TO WNR-EXEC-SQL. */
            _.Move("070", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -349- PERFORM R0700_00_ALTERA_RELATORIOS_DB_UPDATE_1 */

            R0700_00_ALTERA_RELATORIOS_DB_UPDATE_1();

            /*" -352- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -353- DISPLAY 'SI0036B - PROBLEMAS NO UPDATE RELATORIOS' */
                _.Display($"SI0036B - PROBLEMAS NO UPDATE RELATORIOS");

                /*" -353- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0700-00-ALTERA-RELATORIOS-DB-UPDATE-1 */
        public void R0700_00_ALTERA_RELATORIOS_DB_UPDATE_1()
        {
            /*" -349- EXEC SQL UPDATE SEGUROS.RELATORIOS SET SIT_REGISTRO = '1' WHERE COD_RELATORIO = 'SI0036B' AND IDE_SISTEMA = 'SI' AND DATA_SOLICITACAO = :SISTEMAS-DATA-MOV-ABERTO AND SIT_REGISTRO = '0' END-EXEC. */

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
            /*" -363- MOVE '080' TO WNR-EXEC-SQL. */
            _.Move("080", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -364- IF AC-LINHAS GREATER 55 */

            if (AREA_DE_WORK.AC_LINHAS > 55)
            {

                /*" -366- PERFORM R5000-00-CABECALHO. */

                R5000_00_CABECALHO_SECTION();
            }


            /*" -367- MOVE 'TOTAL GERAL.........' TO LD02-LITERAL */
            _.Move("TOTAL GERAL.........", LD02.LD02_LITERAL);

            /*" -369- MOVE AC-G-SINISTROS TO LD02-TOTAL */
            _.Move(AREA_DE_WORK.AC_G_SINISTROS, LD02.LD02_TOTAL);

            /*" -370- WRITE REG-SI0036B1 FROM LC00 */
            _.Move(LC00.GetMoveValues(), REG_SI0036B1);

            SI0036B1.Write(REG_SI0036B1.GetMoveValues().ToString());

            /*" -371- WRITE REG-SI0036B1 FROM LD02 */
            _.Move(LD02.GetMoveValues(), REG_SI0036B1);

            SI0036B1.Write(REG_SI0036B1.GetMoveValues().ToString());

            /*" -371- ADD 2 TO AC-LINHAS. */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 2;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARA-LISTA-SECTION */
        private void R0900_00_DECLARA_LISTA_SECTION()
        {
            /*" -381- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -447- PERFORM R0900_00_DECLARA_LISTA_DB_DECLARE_1 */

            R0900_00_DECLARA_LISTA_DB_DECLARE_1();

            /*" -449- PERFORM R0900_00_DECLARA_LISTA_DB_OPEN_1 */

            R0900_00_DECLARA_LISTA_DB_OPEN_1();

            /*" -452- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -454- DISPLAY 'SI0036B - PROBLEMAS NO OPEN LISTA ' ' ' SISTEMAS-DATA-MOV-ABERTO */

                $"SI0036B - PROBLEMAS NO OPEN LISTA  {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}"
                .Display();

                /*" -454- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARA-LISTA-DB-DECLARE-1 */
        public void R0900_00_DECLARA_LISTA_DB_DECLARE_1()
        {
            /*" -447- EXEC SQL DECLARE LISTA CURSOR FOR SELECT E.COD_USUARIO, C.COD_TIPO_CARTA, B.COD_FONTE, B.NUM_PROTOCOLO_SINI, B.DAC_PROTOCOLO_SINI, B.DATA_MOVTO_DOCACO, B.COD_DOCUMENTO, A.DESCR_DOCUMENTO, D.NATUREZA_SINISTRO, D.NOME_SEGURADO, D.COD_GIAFI, D.NUM_CONTR_ESTIP, I.COD_DESTINATARIO FROM SEGUROS.GE_DOCUMENTO_TIPO A, SEGUROS.SI_DOCUMENTO_ACOMP B, SEGUROS.SI_DOCUMENTO_PARAM C, SEGUROS.SI_MOVIMENTO_SINI D, SEGUROS.SI_ANALISTA_RODIZI E, SEGUROS.SI_SINISTRO_FASE G, SEGUROS.GE_REL_CARTA_DEST I WHERE B.COD_DOCUMENTO = A.COD_DOCUMENTO AND B.COD_PRODUTO = C.COD_PRODUTO AND B.COD_GRUPO_CAUSA = C.COD_GRUPO_CAUSA AND B.COD_SUBGRUPO_CAUSA = C.COD_SUBGRUPO_CAUSA AND B.COD_DOCUMENTO = C.COD_DOCUMENTO AND B.DATA_INIVIG_DOCPAR = C.DATA_INIVIG_DOCPAR AND B.COD_FONTE = D.COD_FONTE AND B.NUM_PROTOCOLO_SINI = D.NUM_PROTOCOLO_SINI AND B.DAC_PROTOCOLO_SINI = D.DAC_PROTOCOLO_SINI AND B.COD_FONTE = E.COD_FONTE AND B.NUM_PROTOCOLO_SINI = E.NUM_PROTOCOLO_SINI AND B.DAC_PROTOCOLO_SINI = E.DAC_PROTOCOLO_SINI AND B.COD_FONTE = G.COD_FONTE AND B.NUM_PROTOCOLO_SINI = G.NUM_PROTOCOLO_SINI AND B.DAC_PROTOCOLO_SINI = G.DAC_PROTOCOLO_SINI AND G.COD_FASE NOT IN (3, 4) AND G.NUM_OCORR_SINIACO = (SELECT MAX(H.NUM_OCORR_SINIACO) FROM SEGUROS.SI_SINISTRO_FASE H WHERE H.COD_FONTE = G.COD_FONTE AND H.NUM_PROTOCOLO_SINI = G.NUM_PROTOCOLO_SINI AND H.DAC_PROTOCOLO_SINI = G.DAC_PROTOCOLO_SINI AND H.DATA_ABERTURA_SIFA <= :SISTEMAS-DATA-MOV-ABERTO) AND B.NUM_CARTA IS NOT NULL AND B.NUM_CARTA = I.NUM_CARTA AND C.COD_TIPO_CARTA IN (2, 27, 28) AND B.COD_EVENTO IN (2012, 2013) AND B.NUM_OCORR_DOCACO = (SELECT MAX(F.NUM_OCORR_DOCACO) FROM SEGUROS.SI_DOCUMENTO_ACOMP F WHERE F.COD_FONTE = B.COD_FONTE AND F.NUM_PROTOCOLO_SINI = B.NUM_PROTOCOLO_SINI AND F.DAC_PROTOCOLO_SINI = B.DAC_PROTOCOLO_SINI AND F.COD_DOCUMENTO = B.COD_DOCUMENTO AND F.DATA_MOVTO_DOCACO <= :SISTEMAS-DATA-MOV-ABERTO) ORDER BY E.COD_USUARIO, I.COD_DESTINATARIO, C.COD_TIPO_CARTA, B.DATA_MOVTO_DOCACO, B.COD_DOCUMENTO, B.COD_FONTE, B.NUM_PROTOCOLO_SINI END-EXEC. */
            LISTA = new SI0036B_LISTA(true);
            string GetQuery_LISTA()
            {
                var query = @$"SELECT E.COD_USUARIO
							, 
							C.COD_TIPO_CARTA
							, 
							B.COD_FONTE
							, 
							B.NUM_PROTOCOLO_SINI
							, 
							B.DAC_PROTOCOLO_SINI
							, 
							B.DATA_MOVTO_DOCACO
							, 
							B.COD_DOCUMENTO
							, 
							A.DESCR_DOCUMENTO
							, 
							D.NATUREZA_SINISTRO
							, 
							D.NOME_SEGURADO
							, 
							D.COD_GIAFI
							, 
							D.NUM_CONTR_ESTIP
							, 
							I.COD_DESTINATARIO 
							FROM SEGUROS.GE_DOCUMENTO_TIPO A
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
							WHERE B.COD_DOCUMENTO = A.COD_DOCUMENTO 
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
							ORDER BY E.COD_USUARIO
							, 
							I.COD_DESTINATARIO
							, 
							C.COD_TIPO_CARTA
							, 
							B.DATA_MOVTO_DOCACO
							, 
							B.COD_DOCUMENTO
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
            /*" -449- EXEC SQL OPEN LISTA END-EXEC. */

            LISTA.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-LE-LISTA-SECTION */
        private void R0910_00_LE_LISTA_SECTION()
        {
            /*" -464- MOVE '091' TO WNR-EXEC-SQL. */
            _.Move("091", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -478- PERFORM R0910_00_LE_LISTA_DB_FETCH_1 */

            R0910_00_LE_LISTA_DB_FETCH_1();

            /*" -481- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -482- ADD 1 TO AC-L-LISTA */
                AREA_DE_WORK.AC_L_LISTA.Value = AREA_DE_WORK.AC_L_LISTA + 1;

                /*" -483- ELSE */
            }
            else
            {


                /*" -484- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -485- MOVE 'S' TO WFIM-LISTA */
                    _.Move("S", AREA_DE_WORK.WFIM_LISTA);

                    /*" -485- PERFORM R0910_00_LE_LISTA_DB_CLOSE_1 */

                    R0910_00_LE_LISTA_DB_CLOSE_1();

                    /*" -487- ELSE */
                }
                else
                {


                    /*" -489- DISPLAY 'SI0036B - PROBLEMAS NO FETCH LISTA ' ' ' SISTEMAS-DATA-MOV-ABERTO */

                    $"SI0036B - PROBLEMAS NO FETCH LISTA  {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}"
                    .Display();

                    /*" -489- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0910-00-LE-LISTA-DB-FETCH-1 */
        public void R0910_00_LE_LISTA_DB_FETCH_1()
        {
            /*" -478- EXEC SQL FETCH LISTA INTO :SIANAROD-COD-USUARIO, :SIDOCPAR-COD-TIPO-CARTA, :SIDOCACO-COD-FONTE, :SIDOCACO-NUM-PROTOCOLO-SINI, :SIDOCACO-DAC-PROTOCOLO-SINI, :SIDOCACO-DATA-MOVTO-DOCACO, :SIDOCACO-COD-DOCUMENTO, :GEDOCTIP-DESCR-DOCUMENTO, :SIMOVSIN-NATUREZA-SINISTRO, :SIMOVSIN-NOME-SEGURADO, :SIMOVSIN-COD-GIAFI, :SIMOVSIN-NUM-CONTR-ESTIP, :GERECADE-COD-DESTINATARIO END-EXEC. */

            if (LISTA.Fetch())
            {
                _.Move(LISTA.SIANAROD_COD_USUARIO, SIANAROD.DCLSI_ANALISTA_RODIZI.SIANAROD_COD_USUARIO);
                _.Move(LISTA.SIDOCPAR_COD_TIPO_CARTA, SIDOCPAR.DCLSI_DOCUMENTO_PARAM.SIDOCPAR_COD_TIPO_CARTA);
                _.Move(LISTA.SIDOCACO_COD_FONTE, SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_FONTE);
                _.Move(LISTA.SIDOCACO_NUM_PROTOCOLO_SINI, SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_PROTOCOLO_SINI);
                _.Move(LISTA.SIDOCACO_DAC_PROTOCOLO_SINI, SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DAC_PROTOCOLO_SINI);
                _.Move(LISTA.SIDOCACO_DATA_MOVTO_DOCACO, SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DATA_MOVTO_DOCACO);
                _.Move(LISTA.SIDOCACO_COD_DOCUMENTO, SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_DOCUMENTO);
                _.Move(LISTA.GEDOCTIP_DESCR_DOCUMENTO, GEDOCTIP.DCLGE_DOCUMENTO_TIPO.GEDOCTIP_DESCR_DOCUMENTO);
                _.Move(LISTA.SIMOVSIN_NATUREZA_SINISTRO, SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_NATUREZA_SINISTRO);
                _.Move(LISTA.SIMOVSIN_NOME_SEGURADO, SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_NOME_SEGURADO);
                _.Move(LISTA.SIMOVSIN_COD_GIAFI, SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_COD_GIAFI);
                _.Move(LISTA.SIMOVSIN_NUM_CONTR_ESTIP, SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_NUM_CONTR_ESTIP);
                _.Move(LISTA.GERECADE_COD_DESTINATARIO, GERECADE.DCLGE_REL_CARTA_DEST.GERECADE_COD_DESTINATARIO);
            }

        }

        [StopWatch]
        /*" R0910-00-LE-LISTA-DB-CLOSE-1 */
        public void R0910_00_LE_LISTA_DB_CLOSE_1()
        {
            /*" -485- EXEC SQL CLOSE LISTA END-EXEC */

            LISTA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-SECTION */
        private void R1000_00_PROCESSA_SECTION()
        {
            /*" -499- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -501- MOVE 80 TO AC-LINHAS */
            _.Move(80, AREA_DE_WORK.AC_LINHAS);

            /*" -503- PERFORM R1100-00-LE-USUARIOS */

            R1100_00_LE_USUARIOS_SECTION();

            /*" -505- MOVE SIANAROD-COD-USUARIO TO WS-COD-USUARIO-ANT */
            _.Move(SIANAROD.DCLSI_ANALISTA_RODIZI.SIANAROD_COD_USUARIO, WS_COD_USUARIO_ANT);

            /*" -510- PERFORM R2000-00-PROCESSA-ANALISTA UNTIL WFIM-LISTA EQUAL 'S' OR SIANAROD-COD-USUARIO NOT EQUAL WS-COD-USUARIO-ANT */

            while (!(AREA_DE_WORK.WFIM_LISTA == "S" || SIANAROD.DCLSI_ANALISTA_RODIZI.SIANAROD_COD_USUARIO != WS_COD_USUARIO_ANT))
            {

                R2000_00_PROCESSA_ANALISTA_SECTION();
            }

            /*" -510- PERFORM R1900-00-TOTAL-ANALISTA. */

            R1900_00_TOTAL_ANALISTA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-LE-USUARIOS-SECTION */
        private void R1100_00_LE_USUARIOS_SECTION()
        {
            /*" -520- MOVE '110' TO WNR-EXEC-SQL. */
            _.Move("110", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -525- PERFORM R1100_00_LE_USUARIOS_DB_SELECT_1 */

            R1100_00_LE_USUARIOS_DB_SELECT_1();

            /*" -528- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -529- DISPLAY 'SI0036B - PROBLEMAS NO SELECT USUARIOS' */
                _.Display($"SI0036B - PROBLEMAS NO SELECT USUARIOS");

                /*" -533- DISPLAY ' ' SIDOCACO-COD-FONTE ' ' SIDOCACO-NUM-PROTOCOLO-SINI ' ' SIDOCACO-DAC-PROTOCOLO-SINI ' ' SIANAROD-COD-USUARIO */

                $" {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_FONTE} {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_PROTOCOLO_SINI} {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DAC_PROTOCOLO_SINI} {SIANAROD.DCLSI_ANALISTA_RODIZI.SIANAROD_COD_USUARIO}"
                .Display();

                /*" -533- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1100-00-LE-USUARIOS-DB-SELECT-1 */
        public void R1100_00_LE_USUARIOS_DB_SELECT_1()
        {
            /*" -525- EXEC SQL SELECT NOME_USUARIO INTO :USUARIOS-NOME-USUARIO FROM SEGUROS.USUARIOS WHERE COD_USUARIO = :SIANAROD-COD-USUARIO END-EXEC. */

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
            /*" -543- MOVE '190' TO WNR-EXEC-SQL. */
            _.Move("190", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -544- IF AC-LINHAS GREATER 55 */

            if (AREA_DE_WORK.AC_LINHAS > 55)
            {

                /*" -546- PERFORM R5000-00-CABECALHO. */

                R5000_00_CABECALHO_SECTION();
            }


            /*" -547- MOVE 'TOTAL DO ANALISTA...' TO LD02-LITERAL */
            _.Move("TOTAL DO ANALISTA...", LD02.LD02_LITERAL);

            /*" -549- MOVE AC-A-SINISTROS TO LD02-TOTAL */
            _.Move(AREA_DE_WORK.AC_A_SINISTROS, LD02.LD02_TOTAL);

            /*" -550- WRITE REG-SI0036B1 FROM LC00 */
            _.Move(LC00.GetMoveValues(), REG_SI0036B1);

            SI0036B1.Write(REG_SI0036B1.GetMoveValues().ToString());

            /*" -551- WRITE REG-SI0036B1 FROM LD02 */
            _.Move(LD02.GetMoveValues(), REG_SI0036B1);

            SI0036B1.Write(REG_SI0036B1.GetMoveValues().ToString());

            /*" -553- ADD 2 TO AC-LINHAS */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 2;

            /*" -554- ADD AC-A-SINISTROS TO AC-G-SINISTROS */
            AREA_DE_WORK.AC_G_SINISTROS.Value = AREA_DE_WORK.AC_G_SINISTROS + AREA_DE_WORK.AC_A_SINISTROS;

            /*" -554- MOVE ZEROS TO AC-A-SINISTROS. */
            _.Move(0, AREA_DE_WORK.AC_A_SINISTROS);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-PROCESSA-ANALISTA-SECTION */
        private void R2000_00_PROCESSA_ANALISTA_SECTION()
        {
            /*" -564- MOVE '200' TO WNR-EXEC-SQL. */
            _.Move("200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -566- PERFORM R2100-00-LE-GEDESTIN */

            R2100_00_LE_GEDESTIN_SECTION();

            /*" -569- MOVE GERECADE-COD-DESTINATARIO TO WS-COD-DESTINATARIO-ANT */
            _.Move(GERECADE.DCLGE_REL_CARTA_DEST.GERECADE_COD_DESTINATARIO, WS_COD_DESTINATARIO_ANT);

            /*" -570- IF AC-LINHAS GREATER 55 */

            if (AREA_DE_WORK.AC_LINHAS > 55)
            {

                /*" -571- PERFORM R5000-00-CABECALHO */

                R5000_00_CABECALHO_SECTION();

                /*" -572- PERFORM R5100-00-CABECALHO-FILIAL */

                R5100_00_CABECALHO_FILIAL_SECTION();

                /*" -573- ELSE */
            }
            else
            {


                /*" -575- PERFORM R5100-00-CABECALHO-FILIAL. */

                R5100_00_CABECALHO_FILIAL_SECTION();
            }


            /*" -583- PERFORM R3000-00-PROCESSA-FILIAL UNTIL WFIM-LISTA EQUAL 'S' OR SIANAROD-COD-USUARIO NOT EQUAL WS-COD-USUARIO-ANT OR GERECADE-COD-DESTINATARIO NOT EQUAL WS-COD-DESTINATARIO-ANT */

            while (!(AREA_DE_WORK.WFIM_LISTA == "S" || SIANAROD.DCLSI_ANALISTA_RODIZI.SIANAROD_COD_USUARIO != WS_COD_USUARIO_ANT || GERECADE.DCLGE_REL_CARTA_DEST.GERECADE_COD_DESTINATARIO != WS_COD_DESTINATARIO_ANT))
            {

                R3000_00_PROCESSA_FILIAL_SECTION();
            }

            /*" -583- PERFORM R2900-00-TOTAL-FILIAL. */

            R2900_00_TOTAL_FILIAL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-LE-GEDESTIN-SECTION */
        private void R2100_00_LE_GEDESTIN_SECTION()
        {
            /*" -593- MOVE '210' TO WNR-EXEC-SQL. */
            _.Move("210", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -599- PERFORM R2100_00_LE_GEDESTIN_DB_SELECT_1 */

            R2100_00_LE_GEDESTIN_DB_SELECT_1();

            /*" -602- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -603- DISPLAY 'SI0036B - PROBLEMAS NO SELECT GE_DESTINATARIO' */
                _.Display($"SI0036B - PROBLEMAS NO SELECT GE_DESTINATARIO");

                /*" -607- DISPLAY ' ' SIDOCACO-COD-FONTE ' ' SIDOCACO-NUM-PROTOCOLO-SINI ' ' SIDOCACO-DAC-PROTOCOLO-SINI ' ' GERECADE-COD-DESTINATARIO */

                $" {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_FONTE} {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_PROTOCOLO_SINI} {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DAC_PROTOCOLO_SINI} {GERECADE.DCLGE_REL_CARTA_DEST.GERECADE_COD_DESTINATARIO}"
                .Display();

                /*" -607- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2100-00-LE-GEDESTIN-DB-SELECT-1 */
        public void R2100_00_LE_GEDESTIN_DB_SELECT_1()
        {
            /*" -599- EXEC SQL SELECT NOME_DESTINATARIO INTO :GEDESTIN-NOME-DESTINATARIO FROM SEGUROS.GE_DESTINATARIO WHERE COD_DESTINATARIO = :GERECADE-COD-DESTINATARIO END-EXEC. */

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
            /*" -617- MOVE '290' TO WNR-EXEC-SQL. */
            _.Move("290", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -618- IF AC-LINHAS GREATER 55 */

            if (AREA_DE_WORK.AC_LINHAS > 55)
            {

                /*" -620- PERFORM R5000-00-CABECALHO. */

                R5000_00_CABECALHO_SECTION();
            }


            /*" -621- MOVE 'TOTAL DA FILIAL.....' TO LD02-LITERAL */
            _.Move("TOTAL DA FILIAL.....", LD02.LD02_LITERAL);

            /*" -623- MOVE AC-F-SINISTROS TO LD02-TOTAL */
            _.Move(AREA_DE_WORK.AC_F_SINISTROS, LD02.LD02_TOTAL);

            /*" -624- WRITE REG-SI0036B1 FROM LC00 */
            _.Move(LC00.GetMoveValues(), REG_SI0036B1);

            SI0036B1.Write(REG_SI0036B1.GetMoveValues().ToString());

            /*" -625- WRITE REG-SI0036B1 FROM LD02 */
            _.Move(LD02.GetMoveValues(), REG_SI0036B1);

            SI0036B1.Write(REG_SI0036B1.GetMoveValues().ToString());

            /*" -627- ADD 2 TO AC-LINHAS */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 2;

            /*" -628- ADD AC-F-SINISTROS TO AC-A-SINISTROS */
            AREA_DE_WORK.AC_A_SINISTROS.Value = AREA_DE_WORK.AC_A_SINISTROS + AREA_DE_WORK.AC_F_SINISTROS;

            /*" -628- MOVE ZEROS TO AC-F-SINISTROS. */
            _.Move(0, AREA_DE_WORK.AC_F_SINISTROS);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2900_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-PROCESSA-FILIAL-SECTION */
        private void R3000_00_PROCESSA_FILIAL_SECTION()
        {
            /*" -638- MOVE '300' TO WNR-EXEC-SQL. */
            _.Move("300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -639- MOVE SIDOCACO-COD-FONTE TO WS-COD-FONTE-ANT */
            _.Move(SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_FONTE, WS_COD_FONTE_ANT);

            /*" -641- MOVE SIDOCACO-NUM-PROTOCOLO-SINI TO WS-NUM-PROTOCOLO-SINI-ANT */
            _.Move(SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_PROTOCOLO_SINI, WS_NUM_PROTOCOLO_SINI_ANT);

            /*" -644- MOVE SIDOCACO-DAC-PROTOCOLO-SINI TO WS-DAC-PROTOCOLO-SINI-ANT */
            _.Move(SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DAC_PROTOCOLO_SINI, WS_DAC_PROTOCOLO_SINI_ANT);

            /*" -645- MOVE 'S' TO WS-QUEBRA-PROTOCOLO */
            _.Move("S", AREA_DE_WORK.WS_QUEBRA_PROTOCOLO);

            /*" -647- ADD 1 TO AC-F-SINISTROS */
            AREA_DE_WORK.AC_F_SINISTROS.Value = AREA_DE_WORK.AC_F_SINISTROS + 1;

            /*" -649- PERFORM R3100-00-LE-SISINACO */

            R3100_00_LE_SISINACO_SECTION();

            /*" -651- PERFORM R3200-00-LE-SINISMES */

            R3200_00_LE_SINISMES_SECTION();

            /*" -667- PERFORM R4000-00-PROCESSA-PROTOCOLO UNTIL WFIM-LISTA EQUAL 'S' OR SIANAROD-COD-USUARIO NOT EQUAL WS-COD-USUARIO-ANT OR GERECADE-COD-DESTINATARIO NOT EQUAL WS-COD-DESTINATARIO-ANT OR SIDOCACO-COD-FONTE NOT EQUAL WS-COD-FONTE-ANT OR SIDOCACO-NUM-PROTOCOLO-SINI NOT EQUAL WS-NUM-PROTOCOLO-SINI-ANT OR SIDOCACO-DAC-PROTOCOLO-SINI NOT EQUAL WS-DAC-PROTOCOLO-SINI-ANT. */

            while (!(AREA_DE_WORK.WFIM_LISTA == "S" || SIANAROD.DCLSI_ANALISTA_RODIZI.SIANAROD_COD_USUARIO != WS_COD_USUARIO_ANT || GERECADE.DCLGE_REL_CARTA_DEST.GERECADE_COD_DESTINATARIO != WS_COD_DESTINATARIO_ANT || SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_FONTE != WS_COD_FONTE_ANT || SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_PROTOCOLO_SINI != WS_NUM_PROTOCOLO_SINI_ANT || SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DAC_PROTOCOLO_SINI != WS_DAC_PROTOCOLO_SINI_ANT))
            {

                R4000_00_PROCESSA_PROTOCOLO_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-LE-SISINACO-SECTION */
        private void R3100_00_LE_SISINACO_SECTION()
        {
            /*" -677- MOVE '310' TO WNR-EXEC-SQL. */
            _.Move("310", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -687- PERFORM R3100_00_LE_SISINACO_DB_SELECT_1 */

            R3100_00_LE_SISINACO_DB_SELECT_1();

            /*" -690- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -692- MOVE SPACES TO SISINACO-DATA-MOVTO-SINIACO */
                _.Move("", SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DATA_MOVTO_SINIACO);

                /*" -693- ELSE */
            }
            else
            {


                /*" -694- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -695- DISPLAY 'SI0036B - PROBLEMAS NO SELECT SI_SINISTRO_ACOMP' */
                    _.Display($"SI0036B - PROBLEMAS NO SELECT SI_SINISTRO_ACOMP");

                    /*" -698- DISPLAY ' ' SIDOCACO-COD-FONTE ' ' SIDOCACO-NUM-PROTOCOLO-SINI ' ' SIDOCACO-DAC-PROTOCOLO-SINI */

                    $" {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_FONTE} {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_PROTOCOLO_SINI} {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DAC_PROTOCOLO_SINI}"
                    .Display();

                    /*" -698- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R3100-00-LE-SISINACO-DB-SELECT-1 */
        public void R3100_00_LE_SISINACO_DB_SELECT_1()
        {
            /*" -687- EXEC SQL SELECT DATA_MOVTO_SINIACO INTO :SISINACO-DATA-MOVTO-SINIACO FROM SEGUROS.SI_SINISTRO_ACOMP WHERE COD_FONTE = :SIDOCACO-COD-FONTE AND NUM_PROTOCOLO_SINI = :SIDOCACO-NUM-PROTOCOLO-SINI AND DAC_PROTOCOLO_SINI = :SIDOCACO-DAC-PROTOCOLO-SINI AND COD_EVENTO = 1001 END-EXEC. */

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
            /*" -708- MOVE '320' TO WNR-EXEC-SQL. */
            _.Move("320", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -717- PERFORM R3200_00_LE_SINISMES_DB_SELECT_1 */

            R3200_00_LE_SINISMES_DB_SELECT_1();

            /*" -720- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -721- MOVE ZEROS TO SINISMES-NUM-IRB */
                _.Move(0, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_IRB);

                /*" -722- ELSE */
            }
            else
            {


                /*" -723- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -724- DISPLAY 'SI0036B - PROBLEMAS NO SELECT SINISTRO_MESTRE' */
                    _.Display($"SI0036B - PROBLEMAS NO SELECT SINISTRO_MESTRE");

                    /*" -727- DISPLAY ' ' SIDOCACO-COD-FONTE ' ' SIDOCACO-NUM-PROTOCOLO-SINI ' ' SIDOCACO-DAC-PROTOCOLO-SINI */

                    $" {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_FONTE} {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_PROTOCOLO_SINI} {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DAC_PROTOCOLO_SINI}"
                    .Display();

                    /*" -727- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R3200-00-LE-SINISMES-DB-SELECT-1 */
        public void R3200_00_LE_SINISMES_DB_SELECT_1()
        {
            /*" -717- EXEC SQL SELECT NUM_IRB INTO :SINISMES-NUM-IRB FROM SEGUROS.SINISTRO_MESTRE WHERE COD_FONTE = :SIDOCACO-COD-FONTE AND NUM_PROTOCOLO_SINI = :SIDOCACO-NUM-PROTOCOLO-SINI AND DAC_PROTOCOLO_SINI = :SIDOCACO-DAC-PROTOCOLO-SINI END-EXEC. */

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
        /*" R4000-00-PROCESSA-PROTOCOLO-SECTION */
        private void R4000_00_PROCESSA_PROTOCOLO_SECTION()
        {
            /*" -737- MOVE '400' TO WNR-EXEC-SQL. */
            _.Move("400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -738- IF AC-LINHAS GREATER 55 */

            if (AREA_DE_WORK.AC_LINHAS > 55)
            {

                /*" -739- PERFORM R5000-00-CABECALHO */

                R5000_00_CABECALHO_SECTION();

                /*" -740- PERFORM R5100-00-CABECALHO-FILIAL */

                R5100_00_CABECALHO_FILIAL_SECTION();

                /*" -742- MOVE 'S' TO WS-QUEBRA-PROTOCOLO. */
                _.Move("S", AREA_DE_WORK.WS_QUEBRA_PROTOCOLO);
            }


            /*" -743- IF WS-QUEBRA-PROTOCOLO EQUAL 'S' */

            if (AREA_DE_WORK.WS_QUEBRA_PROTOCOLO == "S")
            {

                /*" -750- MOVE 'N' TO WS-QUEBRA-PROTOCOLO */
                _.Move("N", AREA_DE_WORK.WS_QUEBRA_PROTOCOLO);

                /*" -751- MOVE SINISMES-NUM-IRB TO LD01-NUM-IRB */
                _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_IRB, LD01.LD01_CHAVE.LD01_NUM_IRB);

                /*" -753- MOVE SIMOVSIN-NOME-SEGURADO TO LD01-NOME-SEGURADO */
                _.Move(SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_NOME_SEGURADO, LD01.LD01_CHAVE.LD01_NOME_SEGURADO);

                /*" -755- MOVE SIMOVSIN-NUM-CONTR-ESTIP TO LD01-NUM-CONTRATO */
                _.Move(SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_NUM_CONTR_ESTIP, LD01.LD01_CHAVE.LD01_NUM_CONTRATO);

                /*" -757- IF SIMOVSIN-NATUREZA-SINISTRO EQUAL 1 */

                if (SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_NATUREZA_SINISTRO == 1)
                {

                    /*" -758- MOVE 'MIP' TO LD01-TIPO-SINISTRO */
                    _.Move("MIP", LD01.LD01_CHAVE.LD01_TIPO_SINISTRO);

                    /*" -759- ELSE */
                }
                else
                {


                    /*" -760- MOVE 'DFI' TO LD01-TIPO-SINISTRO */
                    _.Move("DFI", LD01.LD01_CHAVE.LD01_TIPO_SINISTRO);

                    /*" -761- END-IF */
                }


                /*" -763- IF SISINACO-DATA-MOVTO-SINIACO EQUAL SPACES */

                if (SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DATA_MOVTO_SINIACO.IsEmpty())
                {

                    /*" -764- MOVE SPACES TO LD01-DATA-AVISO */
                    _.Move("", LD01.LD01_CHAVE.LD01_DATA_AVISO);

                    /*" -765- ELSE */
                }
                else
                {


                    /*" -767- MOVE SISINACO-DATA-MOVTO-SINIACO TO DB2-DATA */
                    _.Move(SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DATA_MOVTO_SINIACO, AREA_DE_WORK.DB2_DATA);

                    /*" -768- MOVE DB2-DIA TO EDIT-DIA */
                    _.Move(AREA_DE_WORK.DB2_DATA.DB2_DIA, AREA_DE_WORK.EDIT_DATA.EDIT_DIA);

                    /*" -769- MOVE DB2-MES TO EDIT-MES */
                    _.Move(AREA_DE_WORK.DB2_DATA.DB2_MES, AREA_DE_WORK.EDIT_DATA.EDIT_MES);

                    /*" -770- MOVE DB2-ANO TO EDIT-ANO */
                    _.Move(AREA_DE_WORK.DB2_DATA.DB2_ANO, AREA_DE_WORK.EDIT_DATA.EDIT_ANO);

                    /*" -771- MOVE EDIT-DATA TO LD01-DATA-AVISO */
                    _.Move(AREA_DE_WORK.EDIT_DATA, LD01.LD01_CHAVE.LD01_DATA_AVISO);

                    /*" -772- END-IF */
                }


                /*" -773- ELSE */
            }
            else
            {


                /*" -775- MOVE SPACES TO LD01-CHAVE. */
                _.Move("", LD01.LD01_CHAVE);
            }


            /*" -778- MOVE GEDOCTIP-DESCR-DOCUMENTO TO LD01-DESCR-DOCUMENTO */
            _.Move(GEDOCTIP.DCLGE_DOCUMENTO_TIPO.GEDOCTIP_DESCR_DOCUMENTO, LD01.LD01_DESCR_DOCUMENTO);

            /*" -780- MOVE SIDOCACO-DATA-MOVTO-DOCACO TO DB2-DATA */
            _.Move(SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DATA_MOVTO_DOCACO, AREA_DE_WORK.DB2_DATA);

            /*" -781- MOVE DB2-DIA TO EDIT-DIA */
            _.Move(AREA_DE_WORK.DB2_DATA.DB2_DIA, AREA_DE_WORK.EDIT_DATA.EDIT_DIA);

            /*" -782- MOVE DB2-MES TO EDIT-MES */
            _.Move(AREA_DE_WORK.DB2_DATA.DB2_MES, AREA_DE_WORK.EDIT_DATA.EDIT_MES);

            /*" -783- MOVE DB2-ANO TO EDIT-ANO */
            _.Move(AREA_DE_WORK.DB2_DATA.DB2_ANO, AREA_DE_WORK.EDIT_DATA.EDIT_ANO);

            /*" -785- MOVE EDIT-DATA TO LD01-DATA-EVENTO */
            _.Move(AREA_DE_WORK.EDIT_DATA, LD01.LD01_DATA_EVENTO);

            /*" -786- WRITE REG-SI0036B1 FROM LD01 */
            _.Move(LD01.GetMoveValues(), REG_SI0036B1);

            SI0036B1.Write(REG_SI0036B1.GetMoveValues().ToString());

            /*" -791- ADD 1 TO AC-LINHAS AC-I-SI0036B1 */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 1;
            AREA_DE_WORK.AC_I_SI0036B1.Value = AREA_DE_WORK.AC_I_SI0036B1 + 1;

            /*" -791- PERFORM R0910-00-LE-LISTA. */

            R0910_00_LE_LISTA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R5000-00-CABECALHO-SECTION */
        private void R5000_00_CABECALHO_SECTION()
        {
            /*" -801- MOVE '500' TO WNR-EXEC-SQL. */
            _.Move("500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -802- ADD 1 TO AC-PAGINAS */
            AREA_DE_WORK.AC_PAGINAS.Value = AREA_DE_WORK.AC_PAGINAS + 1;

            /*" -804- MOVE AC-PAGINAS TO LC01-PAGINA */
            _.Move(AREA_DE_WORK.AC_PAGINAS, LC01.LC01_PAGINA);

            /*" -806- MOVE SISTEMAS-DATA-MOV-ABERTO TO DB2-DATA */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREA_DE_WORK.DB2_DATA);

            /*" -807- MOVE DB2-DIA TO EDIT-DIA */
            _.Move(AREA_DE_WORK.DB2_DATA.DB2_DIA, AREA_DE_WORK.EDIT_DATA.EDIT_DIA);

            /*" -808- MOVE DB2-MES TO EDIT-MES */
            _.Move(AREA_DE_WORK.DB2_DATA.DB2_MES, AREA_DE_WORK.EDIT_DATA.EDIT_MES);

            /*" -809- MOVE DB2-ANO TO EDIT-ANO */
            _.Move(AREA_DE_WORK.DB2_DATA.DB2_ANO, AREA_DE_WORK.EDIT_DATA.EDIT_ANO);

            /*" -812- MOVE EDIT-DATA TO LC02-DATA LC02-DATA-MOV-ABERTO */
            _.Move(AREA_DE_WORK.EDIT_DATA, LC02.LC02_DATA, LC02.LC02_DATA_MOV_ABERTO);

            /*" -813- ACCEPT ACC-HORA FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.ACC_HORA);

            /*" -814- MOVE ACC-HH TO EDIT-HH */
            _.Move(AREA_DE_WORK.ACC_HORA.ACC_HH, AREA_DE_WORK.EDIT_HORA.EDIT_HH);

            /*" -815- MOVE ACC-MM TO EDIT-MM */
            _.Move(AREA_DE_WORK.ACC_HORA.ACC_MM, AREA_DE_WORK.EDIT_HORA.EDIT_MM);

            /*" -816- MOVE ACC-SS TO EDIT-SS */
            _.Move(AREA_DE_WORK.ACC_HORA.ACC_SS, AREA_DE_WORK.EDIT_HORA.EDIT_SS);

            /*" -818- MOVE EDIT-HORA TO LC03-HORA */
            _.Move(AREA_DE_WORK.EDIT_HORA, LC03.LC03_HORA);

            /*" -821- MOVE USUARIOS-NOME-USUARIO TO LC05-ANALISTA */
            _.Move(USUARIOS.DCLUSUARIOS.USUARIOS_NOME_USUARIO, LC05.LC05_ANALISTA);

            /*" -822- WRITE REG-SI0036B1 FROM LC01 */
            _.Move(LC01.GetMoveValues(), REG_SI0036B1);

            SI0036B1.Write(REG_SI0036B1.GetMoveValues().ToString());

            /*" -823- WRITE REG-SI0036B1 FROM LC02 */
            _.Move(LC02.GetMoveValues(), REG_SI0036B1);

            SI0036B1.Write(REG_SI0036B1.GetMoveValues().ToString());

            /*" -824- WRITE REG-SI0036B1 FROM LC03 */
            _.Move(LC03.GetMoveValues(), REG_SI0036B1);

            SI0036B1.Write(REG_SI0036B1.GetMoveValues().ToString());

            /*" -825- WRITE REG-SI0036B1 FROM LC00 */
            _.Move(LC00.GetMoveValues(), REG_SI0036B1);

            SI0036B1.Write(REG_SI0036B1.GetMoveValues().ToString());

            /*" -826- WRITE REG-SI0036B1 FROM LC04 */
            _.Move(LC04.GetMoveValues(), REG_SI0036B1);

            SI0036B1.Write(REG_SI0036B1.GetMoveValues().ToString());

            /*" -827- WRITE REG-SI0036B1 FROM LC05 */
            _.Move(LC05.GetMoveValues(), REG_SI0036B1);

            SI0036B1.Write(REG_SI0036B1.GetMoveValues().ToString());

            /*" -828- WRITE REG-SI0036B1 FROM LC04 */
            _.Move(LC04.GetMoveValues(), REG_SI0036B1);

            SI0036B1.Write(REG_SI0036B1.GetMoveValues().ToString());

            /*" -829- WRITE REG-SI0036B1 FROM LC07 */
            _.Move(LC07.GetMoveValues(), REG_SI0036B1);

            SI0036B1.Write(REG_SI0036B1.GetMoveValues().ToString());

            /*" -830- WRITE REG-SI0036B1 FROM LC04 */
            _.Move(LC04.GetMoveValues(), REG_SI0036B1);

            SI0036B1.Write(REG_SI0036B1.GetMoveValues().ToString());

            /*" -832- WRITE REG-SI0036B1 FROM LC00 */
            _.Move(LC00.GetMoveValues(), REG_SI0036B1);

            SI0036B1.Write(REG_SI0036B1.GetMoveValues().ToString());

            /*" -832- MOVE 10 TO AC-LINHAS. */
            _.Move(10, AREA_DE_WORK.AC_LINHAS);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_99_SAIDA*/

        [StopWatch]
        /*" R5100-00-CABECALHO-FILIAL-SECTION */
        private void R5100_00_CABECALHO_FILIAL_SECTION()
        {
            /*" -842- MOVE '510' TO WNR-EXEC-SQL. */
            _.Move("510", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -845- MOVE GEDESTIN-NOME-DESTINATARIO TO LC06-FILIAL */
            _.Move(GEDESTIN.DCLGE_DESTINATARIO.GEDESTIN_NOME_DESTINATARIO, LC06.LC06_FILIAL);

            /*" -846- WRITE REG-SI0036B1 FROM LC06 */
            _.Move(LC06.GetMoveValues(), REG_SI0036B1);

            SI0036B1.Write(REG_SI0036B1.GetMoveValues().ToString());

            /*" -848- WRITE REG-SI0036B1 FROM LC00 */
            _.Move(LC00.GetMoveValues(), REG_SI0036B1);

            SI0036B1.Write(REG_SI0036B1.GetMoveValues().ToString());

            /*" -848- ADD 2 TO AC-LINHAS. */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 2;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5100_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -858- CLOSE SI0036B1 */
            SI0036B1.Close();

            /*" -859- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -861- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -863- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -863- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -866- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -867- DISPLAY '***   SI0036B - CANCELADO  ***' */
            _.Display($"***   SI0036B - CANCELADO  ***");

            /*" -869- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -869- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}