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
using Sias.Sinistro.DB2.SI0857B;

namespace Code
{
    public class SI0857B
    {
        public bool IsCall { get; set; }

        public SI0857B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *************************                                               */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   SISTEMA ................ SINISTRO HABITACIONAL               *      */
        /*"      *   PROGRAMA ............... SI0857B                             *      */
        /*"      *   ANALISTA ............... ALEXIS VEAS ITURRIAGA               *      */
        /*"      *   PROGRAMADOR ............ ALEXIS VEAS ITURRIAGA               *      */
        /*"      *   DATA CODIFICACAO ....... OUT / 2003                          *      */
        /*"      *   FUNCAO ................. RELACAO DE PENDENCIA NO ESTIPULANTE *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 002                                                  *      */
        /*"      * MOTIVO  : ERRO SQLCODE -811                                    *      */
        /*"      * CADMUS  : 140865                                               *      */
        /*"      * DATA    : 10/08/2016                                           *      */
        /*"      * NOME    : DIOGO MATHEUS                                        *      */
        /*"      * MARCADOR: V.2                                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 05/03/2007 - ALTERADO POR JEFFERSON                            *      */
        /*"      *              INCLUIDOS OS ARQUIVOS; ARQFUNCE E ARQCONSO, RES-  *      */
        /*"      * PECTIVOS AOS ESTIPULANTES FUNCEF E CONSORCIO, CONFORME SOLICI- *      */
        /*"      * TACAO NA SSI 11790 DO EVANDRO/GEPOI                            *      */
        /*"      ******************************************************************      */
        /*"      *                                                                       */
        /*"      *-------------------------------------                                  */
        #endregion


        #region VARIABLES

        public FileBasis _ARQGEMAN { get; set; } = new FileBasis(new PIC("X", "250", "X(250)"));

        public FileBasis ARQGEMAN
        {
            get
            {
                _.Move(RARQGEMAN, _ARQGEMAN); VarBasis.RedefinePassValue(RARQGEMAN, _ARQGEMAN, RARQGEMAN); return _ARQGEMAN;
            }
        }
        public FileBasis _ARQGEHAB { get; set; } = new FileBasis(new PIC("X", "250", "X(250)"));

        public FileBasis ARQGEHAB
        {
            get
            {
                _.Move(RARQGEHAB, _ARQGEHAB); VarBasis.RedefinePassValue(RARQGEHAB, _ARQGEHAB, RARQGEHAB); return _ARQGEHAB;
            }
        }
        public FileBasis _ARQGILIE { get; set; } = new FileBasis(new PIC("X", "250", "X(250)"));

        public FileBasis ARQGILIE
        {
            get
            {
                _.Move(RARQGILIE, _ARQGILIE); VarBasis.RedefinePassValue(RARQGILIE, _ARQGILIE, RARQGILIE); return _ARQGILIE;
            }
        }
        public FileBasis _ARQFUNCE { get; set; } = new FileBasis(new PIC("X", "250", "X(250)"));

        public FileBasis ARQFUNCE
        {
            get
            {
                _.Move(RARQFUNCE, _ARQFUNCE); VarBasis.RedefinePassValue(RARQFUNCE, _ARQFUNCE, RARQFUNCE); return _ARQFUNCE;
            }
        }
        public FileBasis _ARQCONSO { get; set; } = new FileBasis(new PIC("X", "250", "X(250)"));

        public FileBasis ARQCONSO
        {
            get
            {
                _.Move(RARQCONSO, _ARQCONSO); VarBasis.RedefinePassValue(RARQCONSO, _ARQCONSO, RARQCONSO); return _ARQCONSO;
            }
        }
        public FileBasis _ARQGEPOI { get; set; } = new FileBasis(new PIC("X", "250", "X(250)"));

        public FileBasis ARQGEPOI
        {
            get
            {
                _.Move(RARQGEPOI, _ARQGEPOI); VarBasis.RedefinePassValue(RARQGEPOI, _ARQGEPOI, RARQGEPOI); return _ARQGEPOI;
            }
        }
        /*"01 RARQGEMAN                    PIC X(250).*/
        public StringBasis RARQGEMAN { get; set; } = new StringBasis(new PIC("X", "250", "X(250)."), @"");
        /*"01 RARQGEHAB                    PIC X(250).*/
        public StringBasis RARQGEHAB { get; set; } = new StringBasis(new PIC("X", "250", "X(250)."), @"");
        /*"01 RARQGILIE                    PIC X(250).*/
        public StringBasis RARQGILIE { get; set; } = new StringBasis(new PIC("X", "250", "X(250)."), @"");
        /*"01 RARQFUNCE                    PIC X(250).*/
        public StringBasis RARQFUNCE { get; set; } = new StringBasis(new PIC("X", "250", "X(250)."), @"");
        /*"01 RARQCONSO                    PIC X(250).*/
        public StringBasis RARQCONSO { get; set; } = new StringBasis(new PIC("X", "250", "X(250)."), @"");
        /*"01 RARQGEPOI                    PIC X(250).*/
        public StringBasis RARQGEPOI { get; set; } = new StringBasis(new PIC("X", "250", "X(250)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01 HOST-DATA-AVISO              PIC X(010)    VALUE SPACES.*/
        public StringBasis HOST_DATA_AVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01 WS-COD-USUARIO-ANT           PIC X(008)    VALUE SPACES.*/
        public StringBasis WS_COD_USUARIO_ANT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"01 WS-COD-DESTINATARIO-ANT      PIC S9(004)   VALUE +0 COMP.*/
        public IntBasis WS_COD_DESTINATARIO_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01 WS-COD-FONTE-ANT             PIC S9(004)   VALUE +0 COMP.*/
        public IntBasis WS_COD_FONTE_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01 WS-NUM-PROTOCOLO-SINI-ANT    PIC S9(004)   VALUE +0 COMP.*/
        public IntBasis WS_NUM_PROTOCOLO_SINI_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01 WS-DAC-PROTOCOLO-SINI-ANT    PIC  X(001)   VALUE SPACES.*/
        public StringBasis WS_DAC_PROTOCOLO_SINI_ANT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01 AREA-DE-WORK.*/
        public SI0857B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SI0857B_AREA_DE_WORK();
        public class SI0857B_AREA_DE_WORK : VarBasis
        {
            /*"    03 AC-L-LISTA               PIC 9(006)    VALUE ZEROS.*/
            public IntBasis AC_L_LISTA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 CT-FETCH                 PIC 9(007)    VALUE ZEROS COMP-3*/
            public IntBasis CT_FETCH { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 CT-ARQGEHAB              PIC 9(007)    VALUE ZEROS COMP-3*/
            public IntBasis CT_ARQGEHAB { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 CT-ARQGEMAN              PIC 9(007)    VALUE ZEROS COMP-3*/
            public IntBasis CT_ARQGEMAN { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 CT-ARQGILIE              PIC 9(007)    VALUE ZEROS COMP-3*/
            public IntBasis CT_ARQGILIE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 CT-ARQFUNCE              PIC 9(007)    VALUE ZEROS COMP-3*/
            public IntBasis CT_ARQFUNCE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 CT-ARQCONSO              PIC 9(007)    VALUE ZEROS COMP-3*/
            public IntBasis CT_ARQCONSO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 CT-ARQGEPOI              PIC 9(007)    VALUE ZEROS COMP-3*/
            public IntBasis CT_ARQGEPOI { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-F-SINISTROS           PIC 9(006)    VALUE ZEROS.*/
            public IntBasis AC_F_SINISTROS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-A-SINISTROS           PIC 9(006)    VALUE ZEROS.*/
            public IntBasis AC_A_SINISTROS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-G-SINISTROS           PIC 9(006)    VALUE ZEROS.*/
            public IntBasis AC_G_SINISTROS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 QBAT-DOC-ACOMP           PIC X(005)    VALUE LOW-VALUE.*/
            public StringBasis QBAT_DOC_ACOMP { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
            /*"    03 WS-QUEBRA-PROTOCOLO      PIC X(001)    VALUE SPACES.*/
            public StringBasis WS_QUEBRA_PROTOCOLO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    03 DB2-DATA.*/
            public SI0857B_DB2_DATA DB2_DATA { get; set; } = new SI0857B_DB2_DATA();
            public class SI0857B_DB2_DATA : VarBasis
            {
                /*"       06 DB2-ANO               PIC 9(004).*/
                public IntBasis DB2_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       06 FILLER                PIC X(001).*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       06 DB2-MES               PIC 9(002).*/
                public IntBasis DB2_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       06 FILLER                PIC X(001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       06 DB2-DIA               PIC 9(002).*/
                public IntBasis DB2_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03 EDIT-DATA.*/
            }
            public SI0857B_EDIT_DATA EDIT_DATA { get; set; } = new SI0857B_EDIT_DATA();
            public class SI0857B_EDIT_DATA : VarBasis
            {
                /*"       06 EDIT-DIA              PIC 9(002)    VALUE ZEROS.*/
                public IntBasis EDIT_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"       06 FILLER                PIC X(001)    VALUE '/'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"       06 EDIT-MES              PIC 9(002)    VALUE ZEROS.*/
                public IntBasis EDIT_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"       06 FILLER                PIC X(001)    VALUE '/'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"       06 EDIT-ANO              PIC 9(004)    VALUE ZEROS.*/
                public IntBasis EDIT_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    03 ACC-HORA.*/
            }
            public SI0857B_ACC_HORA ACC_HORA { get; set; } = new SI0857B_ACC_HORA();
            public class SI0857B_ACC_HORA : VarBasis
            {
                /*"       06 ACC-HH                PIC 99.*/
                public IntBasis ACC_HH { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                /*"       06 ACC-MM                PIC 99.*/
                public IntBasis ACC_MM { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                /*"       06 ACC-SS                PIC 99.*/
                public IntBasis ACC_SS { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                /*"       06 ACC-CC                PIC 99.*/
                public IntBasis ACC_CC { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                /*"    03 EDIT-HORA.*/
            }
            public SI0857B_EDIT_HORA EDIT_HORA { get; set; } = new SI0857B_EDIT_HORA();
            public class SI0857B_EDIT_HORA : VarBasis
            {
                /*"       06 EDIT-HH               PIC 9(002)    VALUE ZEROS.*/
                public IntBasis EDIT_HH { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"       06 FILLER                PIC X(001)    VALUE ':'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"       06 EDIT-MM               PIC 9(002)    VALUE ZEROS.*/
                public IntBasis EDIT_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"       06 FILLER                PIC X(001)    VALUE ':'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"       06 EDIT-SS               PIC 9(002)    VALUE ZEROS.*/
                public IntBasis EDIT_SS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    03 WABEND.*/
            }
            public SI0857B_WABEND WABEND { get; set; } = new SI0857B_WABEND();
            public class SI0857B_WABEND : VarBasis
            {
                /*"       06 FILLER                PIC X(010)    VALUE ' SI0857B'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SI0857B");
                /*"       06 FILLER                PIC X(026)    VALUE          ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"       06 WNR-EXEC-SQL          PIC X(003)    VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"       06 FILLER                PIC X(013)    VALUE          ' *** SQLCODE '.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"       06 WSQLCODE              PIC ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"01 RG-HEADER-01.*/
            }
        }
        public SI0857B_RG_HEADER_01 RG_HEADER_01 { get; set; } = new SI0857B_RG_HEADER_01();
        public class SI0857B_RG_HEADER_01 : VarBasis
        {
            /*"    03 FILLER                   PIC X(200)    VALUE       'CAIXA SEGUROS;'.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "200", "X(200)"), @"CAIXA SEGUROS;");
            /*"01 RG-HEADER-02.*/
        }
        public SI0857B_RG_HEADER_02 RG_HEADER_02 { get; set; } = new SI0857B_RG_HEADER_02();
        public class SI0857B_RG_HEADER_02 : VarBasis
        {
            /*"    03 FILLER                   PIC X(200)    VALUE       'SISTEMA DE SINISTRO - HABITACIONAL;'.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "200", "X(200)"), @"SISTEMA DE SINISTRO - HABITACIONAL;");
            /*"01 RG-HEADER-03.*/
        }
        public SI0857B_RG_HEADER_03 RG_HEADER_03 { get; set; } = new SI0857B_RG_HEADER_03();
        public class SI0857B_RG_HEADER_03 : VarBasis
        {
            /*"    03 FILLER                   PIC X(35)     VALUE       'RELACAO DE DOCUMENTOS PENDENTES EM '.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"RELACAO DE DOCUMENTOS PENDENTES EM ");
            /*"    03 RG-DATA-MOVTO-HDR-2      PIC X(10)     VALUE SPACES.*/
            public StringBasis RG_DATA_MOVTO_HDR_2 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    03 FILLER                   PIC X(01)     VALUE ';'.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"01 RG-HEADER-04.*/
        }
        public SI0857B_RG_HEADER_04 RG_HEADER_04 { get; set; } = new SI0857B_RG_HEADER_04();
        public class SI0857B_RG_HEADER_04 : VarBasis
        {
            /*"    03 FILLER                   PIC X(200)    VALUE       'PROGRAMA GERADOR: SI0857B;'.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "200", "X(200)"), @"PROGRAMA GERADOR: SI0857B;");
            /*"01 LC01.*/
        }
        public SI0857B_LC01 LC01 { get; set; } = new SI0857B_LC01();
        public class SI0857B_LC01 : VarBasis
        {
            /*"    03 FILLER                   PIC X(06)     VALUE 'FILIAL'.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"FILIAL");
            /*"    03 FILLER                   PIC X(34)     VALUE SPACES.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"");
            /*"    03 FILLER                   PIC X(01)     VALUE ';'.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                   PIC X(08)     VALUE 'CONTRATO'.*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"CONTRATO");
            /*"    03 FILLER                   PIC X(05)     VALUE SPACES.*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
            /*"    03 FILLER                   PIC X(01)     VALUE ';'.*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                   PIC X(03)     VALUE 'IRB'.*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"IRB");
            /*"    03 FILLER                   PIC X(08)     VALUE SPACES.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    03 FILLER                   PIC X(01)     VALUE ';'.*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                   PIC X(16)     VALUE       'NOME DO SEGURADO'.*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"NOME DO SEGURADO");
            /*"    03 FILLER                   PIC X(24)     VALUE SPACES.*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "24", "X(24)"), @"");
            /*"    03 FILLER                   PIC X(01)     VALUE ';'.*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                   PIC X(04)     VALUE 'TIPO'.*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"TIPO");
            /*"    03 FILLER                   PIC X(01)     VALUE ';'.*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                   PIC X(10)     VALUE       'DATA AVISO'.*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"DATA AVISO");
            /*"    03 FILLER                   PIC X(01)     VALUE ';'.*/
            public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                   PIC X(18)     VALUE       'DOCUMENTO PENDENTE'.*/
            public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "18", "X(18)"), @"DOCUMENTO PENDENTE");
            /*"    03 FILLER                   PIC X(22)     VALUE SPACES.*/
            public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "22", "X(22)"), @"");
            /*"    03 FILLER                   PIC X(01)     VALUE ';'.*/
            public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                   PIC X(10)     VALUE 'ULT.SOLIC.'*/
            public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"ULT.SOLIC.");
            /*"    03 FILLER                   PIC X(01)     VALUE ';'.*/
            public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                   PIC X(09)     VALUE 'NUM.CARTA'.*/
            public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"NUM.CARTA");
            /*"    03 FILLER                   PIC X(01)     VALUE ';'.*/
            public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                   PIC X(11)     VALUE       'COD.PRODUTO'.*/
            public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"COD.PRODUTO");
            /*"    03 FILLER                   PIC X(01)     VALUE ';'.*/
            public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                   PIC X(20)     VALUE       'DESCRICAO DO PRODUTO'.*/
            public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"DESCRICAO DO PRODUTO");
            /*"    03 FILLER                   PIC X(01)     VALUE ';'.*/
            public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                   PIC X(19)     VALUE       'COD. SUBESTIPULANTE'.*/
            public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "19", "X(19)"), @"COD. SUBESTIPULANTE");
            /*"    03 FILLER                   PIC X(01)     VALUE ';'.*/
            public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"01 LD01.*/
        }
        public SI0857B_LD01 LD01 { get; set; } = new SI0857B_LD01();
        public class SI0857B_LD01 : VarBasis
        {
            /*"    03 LD01-FILIAL              PIC X(40)     VALUE SPACES.*/
            public StringBasis LD01_FILIAL { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
            /*"    03 FILLER                   PIC X(01)     VALUE ';'.*/
            public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 LD01-CHAVE.*/
            public SI0857B_LD01_CHAVE LD01_CHAVE { get; set; } = new SI0857B_LD01_CHAVE();
            public class SI0857B_LD01_CHAVE : VarBasis
            {
                /*"       06 LD01-NUM-CONTRATO     PIC 9(13)     VALUE ZEROS.*/
                public IntBasis LD01_NUM_CONTRATO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
                /*"       06 FILLER                PIC X(01)     VALUE ';'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       06 LD01-NUM-IRB          PIC 9(11)     VALUE ZEROS.*/
                public IntBasis LD01_NUM_IRB { get; set; } = new IntBasis(new PIC("9", "11", "9(11)"));
                /*"       06 FILLER                PIC X(01)     VALUE ';'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       06 LD01-NOME-SEGURADO    PIC X(40)     VALUE SPACES.*/
                public StringBasis LD01_NOME_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"       06 FILLER                PIC X(01)     VALUE ';'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       06 LD01-TIPO-SINISTRO    PIC X(04)     VALUE SPACES.*/
                public StringBasis LD01_TIPO_SINISTRO { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
                /*"       06 FILLER                PIC X(01)     VALUE ';'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       06 LD01-DATA-AVISO       PIC X(10)     VALUE SPACES.*/
                public StringBasis LD01_DATA_AVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"       06 FILLER                PIC X(01)     VALUE ';'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-DESCR-DOCUMENTO     PIC X(40)     VALUE SPACES.*/
            }
            public StringBasis LD01_DESCR_DOCUMENTO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
            /*"    03 FILLER                   PIC X(01)     VALUE ';'.*/
            public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 LD01-DATA-EVENTO         PIC X(10)     VALUE SPACES.*/
            public StringBasis LD01_DATA_EVENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    03 FILLER                   PIC X(01)     VALUE ';'.*/
            public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 LD01-NUM-CARTA           PIC 9(09)     VALUE ZEROS.*/
            public IntBasis LD01_NUM_CARTA { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"    03 FILLER                   PIC X(01)     VALUE ';'.*/
            public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 LD01-COD-PRODUTO         PIC 9(04)     VALUE ZEROS.*/
            public IntBasis LD01_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
            /*"    03 FILLER                   PIC X(01)     VALUE ';'.*/
            public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 LD01-DESCR-PRODUTO       PIC X(40)     VALUE SPACES.*/
            public StringBasis LD01_DESCR_PRODUTO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
            /*"    03 FILLER                   PIC X(01)     VALUE ';'.*/
            public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 LD01-COD-SUBESTIPULANTE  PIC 9(04)     VALUE ZEROS.*/
            public IntBasis LD01_COD_SUBESTIPULANTE { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
            /*"    03 FILLER                   PIC X(01)     VALUE ';'.*/
            public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
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
        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();

        public SI0857B_LISTA LISTA { get; set; } = new SI0857B_LISTA(true);
        string GetQuery_LISTA()
        {
            var query = @$"SELECT E.COD_USUARIO
							, C.COD_TIPO_CARTA
							, B.COD_FONTE
							, B.NUM_PROTOCOLO_SINI
							, B.DAC_PROTOCOLO_SINI
							, B.DATA_MOVTO_DOCACO
							, B.COD_DOCUMENTO
							, A.DESCR_DOCUMENTO
							, D.NATUREZA_SINISTRO
							, D.NOME_SEGURADO
							, D.COD_GIAFI
							, D.NUM_CONTR_ESTIP
							, I.COD_DESTINATARIO
							, B.NUM_CARTA
							, D.COD_SUBESTIPULANTE
							FROM SEGUROS.GE_DOCUMENTO_TIPO A
							, SEGUROS.SI_DOCUMENTO_ACOMP B
							, SEGUROS.SI_DOCUMENTO_PARAM C
							, SEGUROS.SI_MOVIMENTO_SINI D
							, SEGUROS.SI_ANALISTA_RODIZI E
							, SEGUROS.SI_SINISTRO_FASE G
							, SEGUROS.GE_REL_CARTA_DEST I WHERE B.COD_DOCUMENTO = A.COD_DOCUMENTO AND B.COD_PRODUTO = C.COD_PRODUTO AND B.COD_GRUPO_CAUSA = C.COD_GRUPO_CAUSA AND B.COD_SUBGRUPO_CAUSA = C.COD_SUBGRUPO_CAUSA AND B.COD_DOCUMENTO = C.COD_DOCUMENTO AND B.DATA_INIVIG_DOCPAR = C.DATA_INIVIG_DOCPAR AND B.COD_FONTE = D.COD_FONTE AND B.NUM_PROTOCOLO_SINI = D.NUM_PROTOCOLO_SINI AND B.DAC_PROTOCOLO_SINI = D.DAC_PROTOCOLO_SINI AND B.COD_FONTE = E.COD_FONTE AND B.NUM_PROTOCOLO_SINI = E.NUM_PROTOCOLO_SINI AND B.DAC_PROTOCOLO_SINI = E.DAC_PROTOCOLO_SINI AND B.COD_FONTE = G.COD_FONTE AND B.NUM_PROTOCOLO_SINI = G.NUM_PROTOCOLO_SINI AND B.DAC_PROTOCOLO_SINI = G.DAC_PROTOCOLO_SINI AND G.COD_FASE NOT IN (3
							, 4) AND G.NUM_OCORR_SINIACO =
							(SELECT  MAX(H.NUM_OCORR_SINIACO)
							FROM SEGUROS.SI_SINISTRO_FASE H WHERE H.COD_FONTE = G.COD_FONTE AND H.NUM_PROTOCOLO_SINI = G.NUM_PROTOCOLO_SINI AND H.DAC_PROTOCOLO_SINI = G.DAC_PROTOCOLO_SINI AND H.DATA_ABERTURA_SIFA <= '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}') AND B.NUM_CARTA IS NOT NULL AND B.NUM_CARTA = I.NUM_CARTA AND I.IND_DEST_PRINC = 'S' AND C.COD_TIPO_CARTA IN (2
							, 27
							, 28) AND B.COD_EVENTO IN (2012
							, 2013) AND B.NUM_OCORR_DOCACO =
							(SELECT  MAX(F.NUM_OCORR_DOCACO)
							FROM SEGUROS.SI_DOCUMENTO_ACOMP F WHERE F.COD_FONTE = B.COD_FONTE AND F.NUM_PROTOCOLO_SINI = B.NUM_PROTOCOLO_SINI AND F.DAC_PROTOCOLO_SINI = B.DAC_PROTOCOLO_SINI AND F.COD_DOCUMENTO = B.COD_DOCUMENTO AND F.DATA_MOVTO_DOCACO <= '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}') ORDER BY I.COD_DESTINATARIO
							, B.COD_FONTE
							, B.NUM_PROTOCOLO_SINI
							, B.DATA_MOVTO_DOCACO
							, C.COD_TIPO_CARTA
							, B.COD_DOCUMENTO";

            return query;
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string ARQGEMAN_FILE_NAME_P, string ARQGEHAB_FILE_NAME_P, string ARQGILIE_FILE_NAME_P, string ARQFUNCE_FILE_NAME_P, string ARQCONSO_FILE_NAME_P, string ARQGEPOI_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                ARQGEMAN.SetFile(ARQGEMAN_FILE_NAME_P);
                ARQGEHAB.SetFile(ARQGEHAB_FILE_NAME_P);
                ARQGILIE.SetFile(ARQGILIE_FILE_NAME_P);
                ARQFUNCE.SetFile(ARQFUNCE_FILE_NAME_P);
                ARQCONSO.SetFile(ARQCONSO_FILE_NAME_P);
                ARQGEPOI.SetFile(ARQGEPOI_FILE_NAME_P);
                InitializeGetQuery();

                /*" -378- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -379- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -380- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -390- DISPLAY 'SI0857B VERSAO 2 - INICIO PROCESSAMENTO EM  ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

                $"SI0857B VERSAO 2 - INICIO PROCESSAMENTO EM  {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
                .Display();

                /*" -395- OPEN OUTPUT ARQGEMAN ARQGEHAB ARQGILIE ARQFUNCE ARQCONSO ARQGEPOI. */
                ARQGEMAN.Open(RARQGEMAN);
                ARQGEHAB.Open(RARQGEHAB);
                ARQGILIE.Open(RARQGILIE);
                ARQFUNCE.Open(RARQFUNCE);
                ARQCONSO.Open(RARQCONSO);
                ARQGEPOI.Open(RARQGEPOI);

                /*" -397- PERFORM R10-LE-DATA-SISTEMAS THRU R10-FIM. */

                R10_LE_DATA_SISTEMAS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R10_FIM*/


                /*" -399- PERFORM R20-GRAVA-HEADER THRU R20-FIM. */

                R20_GRAVA_HEADER(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R20_FIM*/


                /*" -401- PERFORM R30-PRINCIPAL THRU R30-FIM. */

                R30_PRINCIPAL(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R30_FIM*/


                /*" -406- CLOSE ARQGEMAN ARQGEHAB ARQGEPOI ARQFUNCE ARQCONSO ARQGILIE. */
                ARQGEMAN.Close();
                ARQGEHAB.Close();
                ARQGEPOI.Close();
                ARQFUNCE.Close();
                ARQCONSO.Close();
                ARQGILIE.Close();

                /*" -407- DISPLAY '******************************' */
                _.Display($"******************************");

                /*" -408- DISPLAY '***   SI0857B - FIM NORMAL ***' */
                _.Display($"***   SI0857B - FIM NORMAL ***");

                /*" -409- DISPLAY '******************************' */
                _.Display($"******************************");

                /*" -410- DISPLAY 'LIDOS      SIDOCACO  -  ' CT-FETCH. */
                _.Display($"LIDOS      SIDOCACO  -  {AREA_DE_WORK.CT_FETCH}");

                /*" -411- DISPLAY 'GRAVADOS   ARQGEMAN  -  ' CT-ARQGEMAN. */
                _.Display($"GRAVADOS   ARQGEMAN  -  {AREA_DE_WORK.CT_ARQGEMAN}");

                /*" -412- DISPLAY 'GRAVADOS   ARQGEHAB  -  ' CT-ARQGEHAB. */
                _.Display($"GRAVADOS   ARQGEHAB  -  {AREA_DE_WORK.CT_ARQGEHAB}");

                /*" -413- DISPLAY 'GRAVADOS   ARQGILIE  -  ' CT-ARQGILIE. */
                _.Display($"GRAVADOS   ARQGILIE  -  {AREA_DE_WORK.CT_ARQGILIE}");

                /*" -414- DISPLAY 'GRAVADOS   ARQFUNCE  -  ' CT-ARQFUNCE. */
                _.Display($"GRAVADOS   ARQFUNCE  -  {AREA_DE_WORK.CT_ARQFUNCE}");

                /*" -415- DISPLAY 'GRAVADOS   ARQCONSO  -  ' CT-ARQCONSO. */
                _.Display($"GRAVADOS   ARQCONSO  -  {AREA_DE_WORK.CT_ARQCONSO}");

                /*" -417- DISPLAY 'GRAVADOS   ARQGEPOI  -  ' CT-ARQGEPOI. */
                _.Display($"GRAVADOS   ARQGEPOI  -  {AREA_DE_WORK.CT_ARQGEPOI}");

                /*" -417- STOP RUN. */

                throw new GoBack();   // => STOP RUN.

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        public void InitializeGetQuery()
        {
            LISTA.GetQueryEvent += GetQuery_LISTA;
        }

        [StopWatch]
        /*" R10-LE-DATA-SISTEMAS */
        private void R10_LE_DATA_SISTEMAS(bool isPerform = false)
        {
            /*" -427- MOVE '001' TO WNR-EXEC-SQL. */
            _.Move("001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -432- PERFORM R10_LE_DATA_SISTEMAS_DB_SELECT_1 */

            R10_LE_DATA_SISTEMAS_DB_SELECT_1();

            /*" -435- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -436- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -437- DISPLAY 'SI0857B - DATA SISTEMA NAO ENCONTRADA' */
                    _.Display($"SI0857B - DATA SISTEMA NAO ENCONTRADA");

                    /*" -438- ELSE */
                }
                else
                {


                    /*" -439- DISPLAY 'SI0857B - PROBLEMAS NO SELECT SISTEMAS' */
                    _.Display($"SI0857B - PROBLEMAS NO SELECT SISTEMAS");

                    /*" -440- END-IF */
                }


                /*" -441- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -443- END-IF. */
            }


            /*" -444- MOVE SISTEMAS-DATA-MOV-ABERTO TO DB2-DATA. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREA_DE_WORK.DB2_DATA);

            /*" -445- MOVE DB2-DIA TO EDIT-DIA. */
            _.Move(AREA_DE_WORK.DB2_DATA.DB2_DIA, AREA_DE_WORK.EDIT_DATA.EDIT_DIA);

            /*" -446- MOVE DB2-MES TO EDIT-MES. */
            _.Move(AREA_DE_WORK.DB2_DATA.DB2_MES, AREA_DE_WORK.EDIT_DATA.EDIT_MES);

            /*" -447- MOVE DB2-ANO TO EDIT-ANO. */
            _.Move(AREA_DE_WORK.DB2_DATA.DB2_ANO, AREA_DE_WORK.EDIT_DATA.EDIT_ANO);

            /*" -447- MOVE EDIT-DATA TO RG-DATA-MOVTO-HDR-2. */
            _.Move(AREA_DE_WORK.EDIT_DATA, RG_HEADER_03.RG_DATA_MOVTO_HDR_2);

        }

        [StopWatch]
        /*" R10-LE-DATA-SISTEMAS-DB-SELECT-1 */
        public void R10_LE_DATA_SISTEMAS_DB_SELECT_1()
        {
            /*" -432- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' END-EXEC. */

            var r10_LE_DATA_SISTEMAS_DB_SELECT_1_Query1 = new R10_LE_DATA_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R10_LE_DATA_SISTEMAS_DB_SELECT_1_Query1.Execute(r10_LE_DATA_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R10_FIM*/

        [StopWatch]
        /*" R20-GRAVA-HEADER */
        private void R20_GRAVA_HEADER(bool isPerform = false)
        {
            /*" -459- WRITE RARQGEMAN FROM RG-HEADER-01. */
            _.Move(RG_HEADER_01.GetMoveValues(), RARQGEMAN);

            ARQGEMAN.Write(RARQGEMAN.GetMoveValues().ToString());

            /*" -460- WRITE RARQGEMAN FROM RG-HEADER-02. */
            _.Move(RG_HEADER_02.GetMoveValues(), RARQGEMAN);

            ARQGEMAN.Write(RARQGEMAN.GetMoveValues().ToString());

            /*" -461- WRITE RARQGEMAN FROM RG-HEADER-03. */
            _.Move(RG_HEADER_03.GetMoveValues(), RARQGEMAN);

            ARQGEMAN.Write(RARQGEMAN.GetMoveValues().ToString());

            /*" -462- WRITE RARQGEMAN FROM RG-HEADER-04. */
            _.Move(RG_HEADER_04.GetMoveValues(), RARQGEMAN);

            ARQGEMAN.Write(RARQGEMAN.GetMoveValues().ToString());

            /*" -463- WRITE RARQGEMAN FROM LC01. */
            _.Move(LC01.GetMoveValues(), RARQGEMAN);

            ARQGEMAN.Write(RARQGEMAN.GetMoveValues().ToString());

            /*" -464- WRITE RARQGEHAB FROM RG-HEADER-01. */
            _.Move(RG_HEADER_01.GetMoveValues(), RARQGEHAB);

            ARQGEHAB.Write(RARQGEHAB.GetMoveValues().ToString());

            /*" -465- WRITE RARQGEHAB FROM RG-HEADER-02. */
            _.Move(RG_HEADER_02.GetMoveValues(), RARQGEHAB);

            ARQGEHAB.Write(RARQGEHAB.GetMoveValues().ToString());

            /*" -466- WRITE RARQGEHAB FROM RG-HEADER-03. */
            _.Move(RG_HEADER_03.GetMoveValues(), RARQGEHAB);

            ARQGEHAB.Write(RARQGEHAB.GetMoveValues().ToString());

            /*" -467- WRITE RARQGEHAB FROM RG-HEADER-04. */
            _.Move(RG_HEADER_04.GetMoveValues(), RARQGEHAB);

            ARQGEHAB.Write(RARQGEHAB.GetMoveValues().ToString());

            /*" -468- WRITE RARQGEHAB FROM LC01. */
            _.Move(LC01.GetMoveValues(), RARQGEHAB);

            ARQGEHAB.Write(RARQGEHAB.GetMoveValues().ToString());

            /*" -469- WRITE RARQGILIE FROM RG-HEADER-01. */
            _.Move(RG_HEADER_01.GetMoveValues(), RARQGILIE);

            ARQGILIE.Write(RARQGILIE.GetMoveValues().ToString());

            /*" -470- WRITE RARQGILIE FROM RG-HEADER-02. */
            _.Move(RG_HEADER_02.GetMoveValues(), RARQGILIE);

            ARQGILIE.Write(RARQGILIE.GetMoveValues().ToString());

            /*" -471- WRITE RARQGILIE FROM RG-HEADER-03. */
            _.Move(RG_HEADER_03.GetMoveValues(), RARQGILIE);

            ARQGILIE.Write(RARQGILIE.GetMoveValues().ToString());

            /*" -472- WRITE RARQGILIE FROM RG-HEADER-04. */
            _.Move(RG_HEADER_04.GetMoveValues(), RARQGILIE);

            ARQGILIE.Write(RARQGILIE.GetMoveValues().ToString());

            /*" -474- WRITE RARQGILIE FROM LC01. */
            _.Move(LC01.GetMoveValues(), RARQGILIE);

            ARQGILIE.Write(RARQGILIE.GetMoveValues().ToString());

            /*" -475- WRITE RARQFUNCE FROM RG-HEADER-01. */
            _.Move(RG_HEADER_01.GetMoveValues(), RARQFUNCE);

            ARQFUNCE.Write(RARQFUNCE.GetMoveValues().ToString());

            /*" -476- WRITE RARQFUNCE FROM RG-HEADER-02. */
            _.Move(RG_HEADER_02.GetMoveValues(), RARQFUNCE);

            ARQFUNCE.Write(RARQFUNCE.GetMoveValues().ToString());

            /*" -477- WRITE RARQFUNCE FROM RG-HEADER-03. */
            _.Move(RG_HEADER_03.GetMoveValues(), RARQFUNCE);

            ARQFUNCE.Write(RARQFUNCE.GetMoveValues().ToString());

            /*" -478- WRITE RARQFUNCE FROM RG-HEADER-04. */
            _.Move(RG_HEADER_04.GetMoveValues(), RARQFUNCE);

            ARQFUNCE.Write(RARQFUNCE.GetMoveValues().ToString());

            /*" -480- WRITE RARQFUNCE FROM LC01. */
            _.Move(LC01.GetMoveValues(), RARQFUNCE);

            ARQFUNCE.Write(RARQFUNCE.GetMoveValues().ToString());

            /*" -481- WRITE RARQCONSO FROM RG-HEADER-01. */
            _.Move(RG_HEADER_01.GetMoveValues(), RARQCONSO);

            ARQCONSO.Write(RARQCONSO.GetMoveValues().ToString());

            /*" -482- WRITE RARQCONSO FROM RG-HEADER-02. */
            _.Move(RG_HEADER_02.GetMoveValues(), RARQCONSO);

            ARQCONSO.Write(RARQCONSO.GetMoveValues().ToString());

            /*" -483- WRITE RARQCONSO FROM RG-HEADER-03. */
            _.Move(RG_HEADER_03.GetMoveValues(), RARQCONSO);

            ARQCONSO.Write(RARQCONSO.GetMoveValues().ToString());

            /*" -484- WRITE RARQCONSO FROM RG-HEADER-04. */
            _.Move(RG_HEADER_04.GetMoveValues(), RARQCONSO);

            ARQCONSO.Write(RARQCONSO.GetMoveValues().ToString());

            /*" -486- WRITE RARQCONSO FROM LC01. */
            _.Move(LC01.GetMoveValues(), RARQCONSO);

            ARQCONSO.Write(RARQCONSO.GetMoveValues().ToString());

            /*" -487- WRITE RARQGEPOI FROM RG-HEADER-01. */
            _.Move(RG_HEADER_01.GetMoveValues(), RARQGEPOI);

            ARQGEPOI.Write(RARQGEPOI.GetMoveValues().ToString());

            /*" -488- WRITE RARQGEPOI FROM RG-HEADER-02. */
            _.Move(RG_HEADER_02.GetMoveValues(), RARQGEPOI);

            ARQGEPOI.Write(RARQGEPOI.GetMoveValues().ToString());

            /*" -489- WRITE RARQGEPOI FROM RG-HEADER-03. */
            _.Move(RG_HEADER_03.GetMoveValues(), RARQGEPOI);

            ARQGEPOI.Write(RARQGEPOI.GetMoveValues().ToString());

            /*" -490- WRITE RARQGEPOI FROM RG-HEADER-04. */
            _.Move(RG_HEADER_04.GetMoveValues(), RARQGEPOI);

            ARQGEPOI.Write(RARQGEPOI.GetMoveValues().ToString());

            /*" -490- WRITE RARQGEPOI FROM LC01. */
            _.Move(LC01.GetMoveValues(), RARQGEPOI);

            ARQGEPOI.Write(RARQGEPOI.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R20_FIM*/

        [StopWatch]
        /*" R30-PRINCIPAL */
        private void R30_PRINCIPAL(bool isPerform = false)
        {
            /*" -503- PERFORM R300-OPEN-DOC-ACOMP THRU R300-FIM. */

            R300_OPEN_DOC_ACOMP(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R300_FIM*/


            /*" -506- PERFORM R310-LE-DOC-ACOMP THRU R310-FIM UNTIL QBAT-DOC-ACOMP EQUAL HIGH-VALUE. */

            while (!(AREA_DE_WORK.QBAT_DOC_ACOMP.IsHighValues))
            {

                R310_LE_DOC_ACOMP(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R310_FIM*/

            }

            /*" -506- PERFORM R320-CLOSE-DOC-ACOMP THRU R320-FIM. */

            R320_CLOSE_DOC_ACOMP(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R320_FIM*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R30_FIM*/

        [StopWatch]
        /*" R300-OPEN-DOC-ACOMP */
        private void R300_OPEN_DOC_ACOMP(bool isPerform = false)
        {
            /*" -519- MOVE '002' TO WNR-EXEC-SQL. */
            _.Move("002", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -521- PERFORM R300_OPEN_DOC_ACOMP_DB_OPEN_1 */

            R300_OPEN_DOC_ACOMP_DB_OPEN_1();

            /*" -524- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -525- DISPLAY 'SI0857B - ERRO NO OPEN DO CURSOR LISTA ' */
                _.Display($"SI0857B - ERRO NO OPEN DO CURSOR LISTA ");

                /*" -526- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -526- END-IF. */
            }


        }

        [StopWatch]
        /*" R300-OPEN-DOC-ACOMP-DB-OPEN-1 */
        public void R300_OPEN_DOC_ACOMP_DB_OPEN_1()
        {
            /*" -521- EXEC SQL OPEN LISTA END-EXEC. */

            LISTA.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R300_FIM*/

        [StopWatch]
        /*" R310-LE-DOC-ACOMP */
        private void R310_LE_DOC_ACOMP(bool isPerform = false)
        {
            /*" -539- MOVE '003' TO WNR-EXEC-SQL. */
            _.Move("003", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -555- PERFORM R310_LE_DOC_ACOMP_DB_FETCH_1 */

            R310_LE_DOC_ACOMP_DB_FETCH_1();

            /*" -558- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -559- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -560- MOVE HIGH-VALUE TO QBAT-DOC-ACOMP */

                    AREA_DE_WORK.QBAT_DOC_ACOMP.IsHighValues = true;

                    /*" -561- GO TO R310-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R310_FIM*/ //GOTO
                    return;

                    /*" -562- ELSE */
                }
                else
                {


                    /*" -563- DISPLAY 'SI0857B - PROBLEMAS NO FETCH LISTA ' */
                    _.Display($"SI0857B - PROBLEMAS NO FETCH LISTA ");

                    /*" -564- DISPLAY 'FONTE     = ' SIDOCACO-COD-FONTE */
                    _.Display($"FONTE     = {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_FONTE}");

                    /*" -565- DISPLAY 'PROTOCOLO = ' SIDOCACO-NUM-PROTOCOLO-SINI */
                    _.Display($"PROTOCOLO = {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_PROTOCOLO_SINI}");

                    /*" -566- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;

                    /*" -567- END-IF */
                }


                /*" -569- END-IF. */
            }


            /*" -571- ADD 1 TO CT-FETCH. */
            AREA_DE_WORK.CT_FETCH.Value = AREA_DE_WORK.CT_FETCH + 1;

            /*" -571- PERFORM R3100-PROC-DOC-ACOMP THRU R3100-FIM. */

            R3100_PROC_DOC_ACOMP(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_FIM*/


        }

        [StopWatch]
        /*" R310-LE-DOC-ACOMP-DB-FETCH-1 */
        public void R310_LE_DOC_ACOMP_DB_FETCH_1()
        {
            /*" -555- EXEC SQL FETCH LISTA INTO :SIANAROD-COD-USUARIO, :SIDOCPAR-COD-TIPO-CARTA, :SIDOCACO-COD-FONTE, :SIDOCACO-NUM-PROTOCOLO-SINI, :SIDOCACO-DAC-PROTOCOLO-SINI, :SIDOCACO-DATA-MOVTO-DOCACO, :SIDOCACO-COD-DOCUMENTO, :GEDOCTIP-DESCR-DOCUMENTO, :SIMOVSIN-NATUREZA-SINISTRO, :SIMOVSIN-NOME-SEGURADO, :SIMOVSIN-COD-GIAFI, :SIMOVSIN-NUM-CONTR-ESTIP, :GERECADE-COD-DESTINATARIO, :SIDOCACO-NUM-CARTA, :SIMOVSIN-COD-SUBESTIPULANTE END-EXEC. */

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
                _.Move(LISTA.SIDOCACO_NUM_CARTA, SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_CARTA);
                _.Move(LISTA.SIMOVSIN_COD_SUBESTIPULANTE, SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_COD_SUBESTIPULANTE);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R310_FIM*/

        [StopWatch]
        /*" R3100-PROC-DOC-ACOMP */
        private void R3100_PROC_DOC_ACOMP(bool isPerform = false)
        {
            /*" -584- PERFORM R31000-LE-GEDESTIN THRU R31000-FIM. */

            R31000_LE_GEDESTIN(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R31000_FIM*/


            /*" -586- PERFORM R31010-LE-SISINACO THRU R31010-FIM. */

            R31010_LE_SISINACO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R31010_FIM*/


            /*" -588- PERFORM R31020-LE-SINISMES THRU R31020-FIM. */

            R31020_LE_SINISMES(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R31020_FIM*/


            /*" -590- PERFORM R31030-LE-PRODUTO THRU R31030-FIM. */

            R31030_LE_PRODUTO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R31030_FIM*/


            /*" -590- PERFORM R31040-PROCESSA-PROTOCOLO THRU R31040-FIM. */

            R31040_PROCESSA_PROTOCOLO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R31040_FIM*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_FIM*/

        [StopWatch]
        /*" R31000-LE-GEDESTIN */
        private void R31000_LE_GEDESTIN(bool isPerform = false)
        {
            /*" -603- MOVE '004' TO WNR-EXEC-SQL. */
            _.Move("004", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -608- PERFORM R31000_LE_GEDESTIN_DB_SELECT_1 */

            R31000_LE_GEDESTIN_DB_SELECT_1();

            /*" -611- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -612- DISPLAY 'SI0857B - PROBLEMAS NO SELECT GE_DESTINATARIO' */
                _.Display($"SI0857B - PROBLEMAS NO SELECT GE_DESTINATARIO");

                /*" -613- DISPLAY 'FONTE        = ' SIDOCACO-COD-FONTE */
                _.Display($"FONTE        = {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_FONTE}");

                /*" -614- DISPLAY 'PROTOCOLO    = ' SIDOCACO-NUM-PROTOCOLO-SINI */
                _.Display($"PROTOCOLO    = {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_PROTOCOLO_SINI}");

                /*" -615- DISPLAY 'DIGITO       = ' SIDOCACO-DAC-PROTOCOLO-SINI */
                _.Display($"DIGITO       = {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DAC_PROTOCOLO_SINI}");

                /*" -616- DISPLAY 'DESTINATARIO = ' GERECADE-COD-DESTINATARIO */
                _.Display($"DESTINATARIO = {GERECADE.DCLGE_REL_CARTA_DEST.GERECADE_COD_DESTINATARIO}");

                /*" -617- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -617- END-IF. */
            }


        }

        [StopWatch]
        /*" R31000-LE-GEDESTIN-DB-SELECT-1 */
        public void R31000_LE_GEDESTIN_DB_SELECT_1()
        {
            /*" -608- EXEC SQL SELECT NOME_DESTINATARIO INTO :GEDESTIN-NOME-DESTINATARIO FROM SEGUROS.GE_DESTINATARIO WHERE COD_DESTINATARIO = :GERECADE-COD-DESTINATARIO END-EXEC. */

            var r31000_LE_GEDESTIN_DB_SELECT_1_Query1 = new R31000_LE_GEDESTIN_DB_SELECT_1_Query1()
            {
                GERECADE_COD_DESTINATARIO = GERECADE.DCLGE_REL_CARTA_DEST.GERECADE_COD_DESTINATARIO.ToString(),
            };

            var executed_1 = R31000_LE_GEDESTIN_DB_SELECT_1_Query1.Execute(r31000_LE_GEDESTIN_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GEDESTIN_NOME_DESTINATARIO, GEDESTIN.DCLGE_DESTINATARIO.GEDESTIN_NOME_DESTINATARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R31000_FIM*/

        [StopWatch]
        /*" R31010-LE-SISINACO */
        private void R31010_LE_SISINACO(bool isPerform = false)
        {
            /*" -630- MOVE '005' TO WNR-EXEC-SQL. */
            _.Move("005", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -640- PERFORM R31010_LE_SISINACO_DB_SELECT_1 */

            R31010_LE_SISINACO_DB_SELECT_1();

            /*" -643- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -644- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -645- MOVE SPACES TO SISINACO-DATA-MOVTO-SINIACO */
                    _.Move("", SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DATA_MOVTO_SINIACO);

                    /*" -646- ELSE */
                }
                else
                {


                    /*" -647- DISPLAY 'SI0857B - ERRO NO SELECT SI_SINISTRO_ACOMP' */
                    _.Display($"SI0857B - ERRO NO SELECT SI_SINISTRO_ACOMP");

                    /*" -648- DISPLAY 'FONTE        = ' SIDOCACO-COD-FONTE */
                    _.Display($"FONTE        = {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_FONTE}");

                    /*" -649- DISPLAY 'PROTOCOLO    = ' SIDOCACO-NUM-PROTOCOLO-SINI */
                    _.Display($"PROTOCOLO    = {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_PROTOCOLO_SINI}");

                    /*" -650- DISPLAY 'DIGITO       = ' SIDOCACO-DAC-PROTOCOLO-SINI */
                    _.Display($"DIGITO       = {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DAC_PROTOCOLO_SINI}");

                    /*" -651- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;

                    /*" -652- END-IF */
                }


                /*" -652- END-IF. */
            }


        }

        [StopWatch]
        /*" R31010-LE-SISINACO-DB-SELECT-1 */
        public void R31010_LE_SISINACO_DB_SELECT_1()
        {
            /*" -640- EXEC SQL SELECT DATA_MOVTO_SINIACO INTO :SISINACO-DATA-MOVTO-SINIACO FROM SEGUROS.SI_SINISTRO_ACOMP WHERE COD_FONTE = :SIDOCACO-COD-FONTE AND NUM_PROTOCOLO_SINI = :SIDOCACO-NUM-PROTOCOLO-SINI AND DAC_PROTOCOLO_SINI = :SIDOCACO-DAC-PROTOCOLO-SINI AND COD_EVENTO = 1001 ORDER BY DATA_MOVTO_SINIACO DESC FETCH FIRST 1 ROWS ONLY END-EXEC. */

            var r31010_LE_SISINACO_DB_SELECT_1_Query1 = new R31010_LE_SISINACO_DB_SELECT_1_Query1()
            {
                SIDOCACO_NUM_PROTOCOLO_SINI = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_PROTOCOLO_SINI.ToString(),
                SIDOCACO_DAC_PROTOCOLO_SINI = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DAC_PROTOCOLO_SINI.ToString(),
                SIDOCACO_COD_FONTE = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_FONTE.ToString(),
            };

            var executed_1 = R31010_LE_SISINACO_DB_SELECT_1_Query1.Execute(r31010_LE_SISINACO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISINACO_DATA_MOVTO_SINIACO, SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DATA_MOVTO_SINIACO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R31010_FIM*/

        [StopWatch]
        /*" R31020-LE-SINISMES */
        private void R31020_LE_SINISMES(bool isPerform = false)
        {
            /*" -665- MOVE '006' TO WNR-EXEC-SQL. */
            _.Move("006", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -676- PERFORM R31020_LE_SINISMES_DB_SELECT_1 */

            R31020_LE_SINISMES_DB_SELECT_1();

            /*" -679- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -680- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -681- MOVE ZEROS TO SINISMES-NUM-IRB */
                    _.Move(0, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_IRB);

                    /*" -682- ELSE */
                }
                else
                {


                    /*" -683- DISPLAY 'SI0857B - ERRO NO SELECT SINISTRO_MESTRE' */
                    _.Display($"SI0857B - ERRO NO SELECT SINISTRO_MESTRE");

                    /*" -684- DISPLAY 'FONTE        = ' SIDOCACO-COD-FONTE */
                    _.Display($"FONTE        = {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_FONTE}");

                    /*" -685- DISPLAY 'PROTOCOLO    = ' SIDOCACO-NUM-PROTOCOLO-SINI */
                    _.Display($"PROTOCOLO    = {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_PROTOCOLO_SINI}");

                    /*" -686- DISPLAY 'DIGITO       = ' SIDOCACO-DAC-PROTOCOLO-SINI */
                    _.Display($"DIGITO       = {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DAC_PROTOCOLO_SINI}");

                    /*" -687- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;

                    /*" -688- END-IF */
                }


                /*" -688- END-IF. */
            }


        }

        [StopWatch]
        /*" R31020-LE-SINISMES-DB-SELECT-1 */
        public void R31020_LE_SINISMES_DB_SELECT_1()
        {
            /*" -676- EXEC SQL SELECT NUM_IRB, COD_PRODUTO INTO :SINISMES-NUM-IRB, :SINISMES-COD-PRODUTO FROM SEGUROS.SINISTRO_MESTRE WHERE COD_FONTE = :SIDOCACO-COD-FONTE AND NUM_PROTOCOLO_SINI = :SIDOCACO-NUM-PROTOCOLO-SINI AND DAC_PROTOCOLO_SINI = :SIDOCACO-DAC-PROTOCOLO-SINI END-EXEC. */

            var r31020_LE_SINISMES_DB_SELECT_1_Query1 = new R31020_LE_SINISMES_DB_SELECT_1_Query1()
            {
                SIDOCACO_NUM_PROTOCOLO_SINI = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_PROTOCOLO_SINI.ToString(),
                SIDOCACO_DAC_PROTOCOLO_SINI = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DAC_PROTOCOLO_SINI.ToString(),
                SIDOCACO_COD_FONTE = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_FONTE.ToString(),
            };

            var executed_1 = R31020_LE_SINISMES_DB_SELECT_1_Query1.Execute(r31020_LE_SINISMES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISMES_NUM_IRB, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_IRB);
                _.Move(executed_1.SINISMES_COD_PRODUTO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R31020_FIM*/

        [StopWatch]
        /*" R31030-LE-PRODUTO */
        private void R31030_LE_PRODUTO(bool isPerform = false)
        {
            /*" -700- MOVE SINISMES-COD-PRODUTO TO PRODUTO-COD-PRODUTO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO, PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO);

            /*" -702- MOVE '007' TO WNR-EXEC-SQL. */
            _.Move("007", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -709- PERFORM R31030_LE_PRODUTO_DB_SELECT_1 */

            R31030_LE_PRODUTO_DB_SELECT_1();

            /*" -712- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -713- DISPLAY 'SI0857B - PROBLEMAS SELECT PRODUTO' */
                _.Display($"SI0857B - PROBLEMAS SELECT PRODUTO");

                /*" -714- DISPLAY 'COD_PRODUTO = ' PRODUTO-COD-PRODUTO */
                _.Display($"COD_PRODUTO = {PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO}");

                /*" -715- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -715- END-IF. */
            }


        }

        [StopWatch]
        /*" R31030-LE-PRODUTO-DB-SELECT-1 */
        public void R31030_LE_PRODUTO_DB_SELECT_1()
        {
            /*" -709- EXEC SQL SELECT DESCR_PRODUTO INTO :PRODUTO-DESCR-PRODUTO FROM SEGUROS.PRODUTO WHERE COD_PRODUTO = :PRODUTO-COD-PRODUTO END-EXEC. */

            var r31030_LE_PRODUTO_DB_SELECT_1_Query1 = new R31030_LE_PRODUTO_DB_SELECT_1_Query1()
            {
                PRODUTO_COD_PRODUTO = PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO.ToString(),
            };

            var executed_1 = R31030_LE_PRODUTO_DB_SELECT_1_Query1.Execute(r31030_LE_PRODUTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUTO_DESCR_PRODUTO, PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R31030_FIM*/

        [StopWatch]
        /*" R31040-PROCESSA-PROTOCOLO */
        private void R31040_PROCESSA_PROTOCOLO(bool isPerform = false)
        {
            /*" -727- MOVE GEDESTIN-NOME-DESTINATARIO TO LD01-FILIAL. */
            _.Move(GEDESTIN.DCLGE_DESTINATARIO.GEDESTIN_NOME_DESTINATARIO, LD01.LD01_FILIAL);

            /*" -728- MOVE SINISMES-NUM-IRB TO LD01-NUM-IRB. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_IRB, LD01.LD01_CHAVE.LD01_NUM_IRB);

            /*" -729- MOVE SIMOVSIN-NOME-SEGURADO TO LD01-NOME-SEGURADO. */
            _.Move(SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_NOME_SEGURADO, LD01.LD01_CHAVE.LD01_NOME_SEGURADO);

            /*" -730- MOVE SIMOVSIN-NUM-CONTR-ESTIP TO LD01-NUM-CONTRATO. */
            _.Move(SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_NUM_CONTR_ESTIP, LD01.LD01_CHAVE.LD01_NUM_CONTRATO);

            /*" -731- MOVE SIDOCACO-NUM-CARTA TO LD01-NUM-CARTA. */
            _.Move(SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_CARTA, LD01.LD01_NUM_CARTA);

            /*" -732- MOVE SINISMES-COD-PRODUTO TO LD01-COD-PRODUTO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO, LD01.LD01_COD_PRODUTO);

            /*" -733- MOVE PRODUTO-DESCR-PRODUTO TO LD01-DESCR-PRODUTO. */
            _.Move(PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO, LD01.LD01_DESCR_PRODUTO);

            /*" -735- MOVE SIMOVSIN-COD-SUBESTIPULANTE TO LD01-COD-SUBESTIPULANTE. */
            _.Move(SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_COD_SUBESTIPULANTE, LD01.LD01_COD_SUBESTIPULANTE);

            /*" -736- IF SIMOVSIN-NATUREZA-SINISTRO EQUAL 1 */

            if (SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_NATUREZA_SINISTRO == 1)
            {

                /*" -737- MOVE 'MIP' TO LD01-TIPO-SINISTRO */
                _.Move("MIP", LD01.LD01_CHAVE.LD01_TIPO_SINISTRO);

                /*" -738- ELSE */
            }
            else
            {


                /*" -739- MOVE 'DFI' TO LD01-TIPO-SINISTRO */
                _.Move("DFI", LD01.LD01_CHAVE.LD01_TIPO_SINISTRO);

                /*" -741- END-IF. */
            }


            /*" -742- IF SISINACO-DATA-MOVTO-SINIACO EQUAL SPACES */

            if (SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DATA_MOVTO_SINIACO.IsEmpty())
            {

                /*" -743- MOVE SPACES TO LD01-DATA-AVISO */
                _.Move("", LD01.LD01_CHAVE.LD01_DATA_AVISO);

                /*" -744- ELSE */
            }
            else
            {


                /*" -745- MOVE SISINACO-DATA-MOVTO-SINIACO TO DB2-DATA */
                _.Move(SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DATA_MOVTO_SINIACO, AREA_DE_WORK.DB2_DATA);

                /*" -746- MOVE DB2-DIA TO EDIT-DIA */
                _.Move(AREA_DE_WORK.DB2_DATA.DB2_DIA, AREA_DE_WORK.EDIT_DATA.EDIT_DIA);

                /*" -747- MOVE DB2-MES TO EDIT-MES */
                _.Move(AREA_DE_WORK.DB2_DATA.DB2_MES, AREA_DE_WORK.EDIT_DATA.EDIT_MES);

                /*" -748- MOVE DB2-ANO TO EDIT-ANO */
                _.Move(AREA_DE_WORK.DB2_DATA.DB2_ANO, AREA_DE_WORK.EDIT_DATA.EDIT_ANO);

                /*" -749- MOVE EDIT-DATA TO LD01-DATA-AVISO */
                _.Move(AREA_DE_WORK.EDIT_DATA, LD01.LD01_CHAVE.LD01_DATA_AVISO);

                /*" -751- END-IF. */
            }


            /*" -752- MOVE GEDOCTIP-DESCR-DOCUMENTO TO LD01-DESCR-DOCUMENTO. */
            _.Move(GEDOCTIP.DCLGE_DOCUMENTO_TIPO.GEDOCTIP_DESCR_DOCUMENTO, LD01.LD01_DESCR_DOCUMENTO);

            /*" -753- MOVE SIDOCACO-DATA-MOVTO-DOCACO TO DB2-DATA. */
            _.Move(SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DATA_MOVTO_DOCACO, AREA_DE_WORK.DB2_DATA);

            /*" -754- MOVE DB2-DIA TO EDIT-DIA. */
            _.Move(AREA_DE_WORK.DB2_DATA.DB2_DIA, AREA_DE_WORK.EDIT_DATA.EDIT_DIA);

            /*" -755- MOVE DB2-MES TO EDIT-MES. */
            _.Move(AREA_DE_WORK.DB2_DATA.DB2_MES, AREA_DE_WORK.EDIT_DATA.EDIT_MES);

            /*" -756- MOVE DB2-ANO TO EDIT-ANO. */
            _.Move(AREA_DE_WORK.DB2_DATA.DB2_ANO, AREA_DE_WORK.EDIT_DATA.EDIT_ANO);

            /*" -758- MOVE EDIT-DATA TO LD01-DATA-EVENTO. */
            _.Move(AREA_DE_WORK.EDIT_DATA, LD01.LD01_DATA_EVENTO);

            /*" -759- IF SIMOVSIN-COD-SUBESTIPULANTE EQUAL 6220 */

            if (SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_COD_SUBESTIPULANTE == 6220)
            {

                /*" -760- WRITE RARQGILIE FROM LD01 */
                _.Move(LD01.GetMoveValues(), RARQGILIE);

                ARQGILIE.Write(RARQGILIE.GetMoveValues().ToString());

                /*" -761- ADD 1 TO CT-ARQGILIE */
                AREA_DE_WORK.CT_ARQGILIE.Value = AREA_DE_WORK.CT_ARQGILIE + 1;

                /*" -762- ELSE */
            }
            else
            {


                /*" -763- IF SIMOVSIN-COD-SUBESTIPULANTE EQUAL 6204 */

                if (SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_COD_SUBESTIPULANTE == 6204)
                {

                    /*" -764- WRITE RARQGEHAB FROM LD01 */
                    _.Move(LD01.GetMoveValues(), RARQGEHAB);

                    ARQGEHAB.Write(RARQGEHAB.GetMoveValues().ToString());

                    /*" -765- ADD 1 TO CT-ARQGEHAB */
                    AREA_DE_WORK.CT_ARQGEHAB.Value = AREA_DE_WORK.CT_ARQGEHAB + 1;

                    /*" -766- ELSE */
                }
                else
                {


                    /*" -767- IF SIMOVSIN-COD-SUBESTIPULANTE EQUAL 6205 OR 6206 */

                    if (SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_COD_SUBESTIPULANTE.In("6205", "6206"))
                    {

                        /*" -768- WRITE RARQGEMAN FROM LD01 */
                        _.Move(LD01.GetMoveValues(), RARQGEMAN);

                        ARQGEMAN.Write(RARQGEMAN.GetMoveValues().ToString());

                        /*" -769- ADD 1 TO CT-ARQGEMAN */
                        AREA_DE_WORK.CT_ARQGEMAN.Value = AREA_DE_WORK.CT_ARQGEMAN + 1;

                        /*" -770- ELSE */
                    }
                    else
                    {


                        /*" -771- IF SIMOVSIN-COD-SUBESTIPULANTE EQUAL 6251 */

                        if (SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_COD_SUBESTIPULANTE == 6251)
                        {

                            /*" -772- WRITE RARQFUNCE FROM LD01 */
                            _.Move(LD01.GetMoveValues(), RARQFUNCE);

                            ARQFUNCE.Write(RARQFUNCE.GetMoveValues().ToString());

                            /*" -773- ADD 1 TO CT-ARQFUNCE */
                            AREA_DE_WORK.CT_ARQFUNCE.Value = AREA_DE_WORK.CT_ARQFUNCE + 1;

                            /*" -774- ELSE */
                        }
                        else
                        {


                            /*" -775- IF SIMOVSIN-COD-SUBESTIPULANTE EQUAL 5 */

                            if (SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_COD_SUBESTIPULANTE == 5)
                            {

                                /*" -776- WRITE RARQCONSO FROM LD01 */
                                _.Move(LD01.GetMoveValues(), RARQCONSO);

                                ARQCONSO.Write(RARQCONSO.GetMoveValues().ToString());

                                /*" -777- ADD 1 TO CT-ARQCONSO */
                                AREA_DE_WORK.CT_ARQCONSO.Value = AREA_DE_WORK.CT_ARQCONSO + 1;

                                /*" -778- ELSE */
                            }
                            else
                            {


                                /*" -779- WRITE RARQGEPOI FROM LD01 */
                                _.Move(LD01.GetMoveValues(), RARQGEPOI);

                                ARQGEPOI.Write(RARQGEPOI.GetMoveValues().ToString());

                                /*" -780- ADD 1 TO CT-ARQGEPOI */
                                AREA_DE_WORK.CT_ARQGEPOI.Value = AREA_DE_WORK.CT_ARQGEPOI + 1;

                                /*" -781- END-IF */
                            }


                            /*" -782- END-IF */
                        }


                        /*" -783- END-IF */
                    }


                    /*" -784- END-IF */
                }


                /*" -784- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R31040_FIM*/

        [StopWatch]
        /*" R320-CLOSE-DOC-ACOMP */
        private void R320_CLOSE_DOC_ACOMP(bool isPerform = false)
        {
            /*" -797- MOVE '008' TO WNR-EXEC-SQL. */
            _.Move("008", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -799- PERFORM R320_CLOSE_DOC_ACOMP_DB_CLOSE_1 */

            R320_CLOSE_DOC_ACOMP_DB_CLOSE_1();

            /*" -802- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -803- DISPLAY 'SI0857B - ERRO NO CLOSE DO CURSOR LISTA ' */
                _.Display($"SI0857B - ERRO NO CLOSE DO CURSOR LISTA ");

                /*" -804- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -804- END-IF. */
            }


        }

        [StopWatch]
        /*" R320-CLOSE-DOC-ACOMP-DB-CLOSE-1 */
        public void R320_CLOSE_DOC_ACOMP_DB_CLOSE_1()
        {
            /*" -799- EXEC SQL CLOSE LISTA END-EXEC. */

            LISTA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R320_FIM*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO */
        private void R9999_00_ROT_ERRO(bool isPerform = false)
        {
            /*" -820- CLOSE ARQGEMAN ARQGEHAB ARQGILIE ARQFUNCE ARQCONSO ARQGEPOI. */
            ARQGEMAN.Close();
            ARQGEHAB.Close();
            ARQGILIE.Close();
            ARQFUNCE.Close();
            ARQCONSO.Close();
            ARQGEPOI.Close();

            /*" -822- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -824- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -824- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -827- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -828- DISPLAY '***   SI0857B - CANCELADO  ***' */
            _.Display($"***   SI0857B - CANCELADO  ***");

            /*" -830- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -831- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -831- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}