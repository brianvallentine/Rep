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
using Sias.Sinistro.DB2.SI5039B;

namespace Code
{
    public class SI5039B
    {
        public bool IsCall { get; set; }

        public SI5039B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *************************                                               */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   SISTEMA ................ SINISTRO                            *      */
        /*"      *   PROGRAMA ............... SI5039B                             *      */
        /*"      *   ANALISTA ............... ALEXIS VEAS ITURRIAGA               *      */
        /*"      *   PROGRAMADOR ............ ALEXIS VEAS ITURRIAGA               *      */
        /*"      *   DATA CODIFICACAO ....... DEZ / 2005                          *      */
        /*"      *   FUNCAO ................. VERIFICACAO DE VALORES NEGATIVOS    *      */
        /*"      *                            NA SINISTRO HISTORICO ASSIM COMO    *      */
        /*"      *                            PAGAMENTOS PENDENCIAS.              *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *                                                                       */
        /*"      *-------------------------------------                                  */
        #endregion


        #region VARIABLES

        public FileBasis _ARQNEGAV { get; set; } = new FileBasis(new PIC("X", "200", "X(200)"));

        public FileBasis ARQNEGAV
        {
            get
            {
                _.Move(RARQNEGAV, _ARQNEGAV); VarBasis.RedefinePassValue(RARQNEGAV, _ARQNEGAV, RARQNEGAV); return _ARQNEGAV;
            }
        }
        /*"01 RARQNEGAV                    PIC X(200).*/
        public StringBasis RARQNEGAV { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01 AREA-DE-WORK.*/
        public SI5039B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SI5039B_AREA_DE_WORK();
        public class SI5039B_AREA_DE_WORK : VarBasis
        {
            /*"    03 NL-COD-PROGRAMA          PIC S9(04)    VALUE ZEROS COMP.*/
            public IntBasis NL_COD_PROGRAMA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    03 CT-FETCH                 PIC 9(007)    VALUE ZEROS COMP-3*/
            public IntBasis CT_FETCH { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 CT-ARQNEGAV              PIC 9(007)    VALUE ZEROS COMP-3*/
            public IntBasis CT_ARQNEGAV { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 CT-SINISTROS             PIC 9(006)    VALUE ZEROS COMP-3*/
            public IntBasis CT_SINISTROS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 CA-VALOR-PENDENTE        PIC S9(13)V99 VALUE ZEROS COMP-3*/
            public DoubleBasis CA_VALOR_PENDENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    03 QBAT-CR-HISTORICO        PIC X(005)    VALUE LOW-VALUE.*/
            public StringBasis QBAT_CR_HISTORICO { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
            /*"    03 DB2-DATA.*/
            public SI5039B_DB2_DATA DB2_DATA { get; set; } = new SI5039B_DB2_DATA();
            public class SI5039B_DB2_DATA : VarBasis
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
            public SI5039B_EDIT_DATA EDIT_DATA { get; set; } = new SI5039B_EDIT_DATA();
            public class SI5039B_EDIT_DATA : VarBasis
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
                /*"    03 AT-SINISTRO              PIC X(13)     VALUE LOW-VALUE.*/
            }
            public StringBasis AT_SINISTRO { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"");
            /*"    03 FILLER REDEFINES AT-SINISTRO.*/
            private _REDEF_SI5039B_FILLER_4 _filler_4 { get; set; }
            public _REDEF_SI5039B_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_SI5039B_FILLER_4(); _.Move(AT_SINISTRO, _filler_4); VarBasis.RedefinePassValue(AT_SINISTRO, _filler_4, AT_SINISTRO); _filler_4.ValueChanged += () => { _.Move(_filler_4, AT_SINISTRO); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, AT_SINISTRO); }
            }  //Redefines
            public class _REDEF_SI5039B_FILLER_4 : VarBasis
            {
                /*"       06 AT-NUM-APOL-SINISTRO  PIC 9(13).*/
                public IntBasis AT_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
                /*"    03 AN-SINISTRO              PIC X(13)     VALUE LOW-VALUE.*/

                public _REDEF_SI5039B_FILLER_4()
                {
                    AT_NUM_APOL_SINISTRO.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis AN_SINISTRO { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"");
            /*"    03 FILLER REDEFINES AN-SINISTRO.*/
            private _REDEF_SI5039B_FILLER_5 _filler_5 { get; set; }
            public _REDEF_SI5039B_FILLER_5 FILLER_5
            {
                get { _filler_5 = new _REDEF_SI5039B_FILLER_5(); _.Move(AN_SINISTRO, _filler_5); VarBasis.RedefinePassValue(AN_SINISTRO, _filler_5, AN_SINISTRO); _filler_5.ValueChanged += () => { _.Move(_filler_5, AN_SINISTRO); }; return _filler_5; }
                set { VarBasis.RedefinePassValue(value, _filler_5, AN_SINISTRO); }
            }  //Redefines
            public class _REDEF_SI5039B_FILLER_5 : VarBasis
            {
                /*"       06 AN-NUM-APOL-SINISTRO  PIC 9(13).*/
                public IntBasis AN_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
                /*"    03 WABEND.*/

                public _REDEF_SI5039B_FILLER_5()
                {
                    AN_NUM_APOL_SINISTRO.ValueChanged += OnValueChanged;
                }

            }
            public SI5039B_WABEND WABEND { get; set; } = new SI5039B_WABEND();
            public class SI5039B_WABEND : VarBasis
            {
                /*"       06 FILLER                PIC X(010)    VALUE ' SI5039B'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SI5039B");
                /*"       06 FILLER                PIC X(026)    VALUE          ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"       06 WNR-EXEC-SQL          PIC X(003)    VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"       06 FILLER                PIC X(013)    VALUE          ' *** SQLCODE '.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"       06 WSQLCODE              PIC ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"01 LC-ARQNEGAV-01.*/
            }
        }
        public SI5039B_LC_ARQNEGAV_01 LC_ARQNEGAV_01 { get; set; } = new SI5039B_LC_ARQNEGAV_01();
        public class SI5039B_LC_ARQNEGAV_01 : VarBasis
        {
            /*"    03 FILLER                   PIC X(08)     VALUE 'SI5039B'.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"SI5039B");
            /*"    03 FILLER                   PIC X(01)     VALUE SPACES.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"    03 FILLER                   PIC X(48)     VALUE       'ARQUIVO DE LANCAMENTOS E PENDENCIAS NEGATIVAS   '.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "48", "X(48)"), @"ARQUIVO DE LANCAMENTOS E PENDENCIAS NEGATIVAS   ");
            /*"    03 FILLER                   PIC X(01)     VALUE ';'.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"01 LC-ARQNEGAV-02.*/
        }
        public SI5039B_LC_ARQNEGAV_02 LC_ARQNEGAV_02 { get; set; } = new SI5039B_LC_ARQNEGAV_02();
        public class SI5039B_LC_ARQNEGAV_02 : VarBasis
        {
            /*"    03 FILLER                   PIC X(27)     VALUE       'DATA DO MOVIMENTO ABERTO = '.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "27", "X(27)"), @"DATA DO MOVIMENTO ABERTO = ");
            /*"    03 LC-DATA-PROC-02          PIC X(10).*/
            public StringBasis LC_DATA_PROC_02 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    03 FILLER                   PIC X(01)     VALUE ';'.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"01 LC-ARQNEGAV-03.*/
        }
        public SI5039B_LC_ARQNEGAV_03 LC_ARQNEGAV_03 { get; set; } = new SI5039B_LC_ARQNEGAV_03();
        public class SI5039B_LC_ARQNEGAV_03 : VarBasis
        {
            /*"    03 FILLER                   PIC X(08)     VALUE 'SINISTRO'.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"SINISTRO");
            /*"    03 FILLER                   PIC X(01)     VALUE ';'.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                   PIC X(09)     VALUE 'COD.OPER.'.*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"COD.OPER.");
            /*"    03 FILLER                   PIC X(01)     VALUE ';'.*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                   PIC X(09)     VALUE 'OCORHIST.'.*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"OCORHIST.");
            /*"    03 FILLER                   PIC X(01)     VALUE ';'.*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                   PIC X(14)     VALUE       'DATA MOVIMENTO'.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"DATA MOVIMENTO");
            /*"    03 FILLER                   PIC X(01)     VALUE ';'.*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                   PIC X(08)     VALUE 'PROGRAMA'.*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"PROGRAMA");
            /*"    03 FILLER                   PIC X(01)     VALUE ';'.*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                   PIC X(07)     VALUE 'USUARIO'.*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"USUARIO");
            /*"    03 FILLER                   PIC X(01)     VALUE ';'.*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                   PIC X(17)     VALUE       'VALOR DA OPERACAO'.*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @"VALOR DA OPERACAO");
            /*"    03 FILLER                   PIC X(01)     VALUE ';'.*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                   PIC X(14)     VALUE       'VALOR PENDENTE'.*/
            public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"VALOR PENDENTE");
            /*"    03 FILLER                   PIC X(01)     VALUE ';'.*/
            public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                   PIC X(17)     VALUE       'PENDENTE SEGUROS '.*/
            public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @"PENDENTE SEGUROS ");
            /*"    03 FILLER                   PIC X(01)     VALUE ';'.*/
            public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                   PIC X(17)     VALUE       'PENDENTE JUDICIAL'.*/
            public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @"PENDENTE JUDICIAL");
            /*"    03 FILLER                   PIC X(01)     VALUE ';'.*/
            public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                   PIC X(20)     VALUE       'PENDENTE SUCUMBENCIA'.*/
            public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"PENDENTE SUCUMBENCIA");
            /*"    03 FILLER                   PIC X(01)     VALUE ';'.*/
            public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                   PIC X(17)     VALUE       'PENDENTE SALVADOS'.*/
            public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @"PENDENTE SALVADOS");
            /*"    03 FILLER                   PIC X(01)     VALUE ';'.*/
            public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                   PIC X(06)     VALUE 'MOTIVO'.*/
            public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"MOTIVO");
            /*"    03 FILLER                   PIC X(01)     VALUE ';'.*/
            public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"01 LD-ARQNEGAV-01.*/
        }
        public SI5039B_LD_ARQNEGAV_01 LD_ARQNEGAV_01 { get; set; } = new SI5039B_LD_ARQNEGAV_01();
        public class SI5039B_LD_ARQNEGAV_01 : VarBasis
        {
            /*"    03 LD-SINISTRO-01           PIC 9(13).*/
            public IntBasis LD_SINISTRO_01 { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
            /*"    03 FILLER                   PIC X(01)     VALUE ';'.*/
            public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 LD-COD-OPERACAO-01       PIC 9(04).*/
            public IntBasis LD_COD_OPERACAO_01 { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    03 FILLER                   PIC X(01)     VALUE ';'.*/
            public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 LD-OCORR-HISTORICO-01    PIC 9(04).*/
            public IntBasis LD_OCORR_HISTORICO_01 { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    03 FILLER                   PIC X(01)     VALUE ';'.*/
            public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 LD-DATA-MOVIMENTO-01     PIC X(10).*/
            public StringBasis LD_DATA_MOVIMENTO_01 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    03 FILLER                   PIC X(01)     VALUE ';'.*/
            public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 LD-NOME-PROGRAMA-01      PIC X(08).*/
            public StringBasis LD_NOME_PROGRAMA_01 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
            /*"    03 FILLER                   PIC X(01)     VALUE ';'.*/
            public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 LD-COD-USUARIO-01        PIC X(08).*/
            public StringBasis LD_COD_USUARIO_01 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
            /*"    03 FILLER                   PIC X(01)     VALUE ';'.*/
            public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 LD-VALOR-OPERACAO-01     PIC -.---.---.---.---,99.*/
            public DoubleBasis LD_VALOR_OPERACAO_01 { get; set; } = new DoubleBasis(new PIC("9", "0", "-.---.---.---.---V99."), 0);
            /*"    03 FILLER                   PIC X(01)     VALUE ';'.*/
            public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 LD-VALOR-PENDENTE-01     PIC -.---.---.---.--9,99.*/
            public DoubleBasis LD_VALOR_PENDENTE_01 { get; set; } = new DoubleBasis(new PIC("9", "13", "-.---.---.---.--9V99."), 2);
            /*"    03 FILLER                   PIC X(01)     VALUE ';'.*/
            public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 LD-PENDENTE-SEG-01       PIC -.---.---.---.--9,99.*/
            public DoubleBasis LD_PENDENTE_SEG_01 { get; set; } = new DoubleBasis(new PIC("9", "13", "-.---.---.---.--9V99."), 2);
            /*"    03 FILLER                   PIC X(01)     VALUE ';'.*/
            public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 LD-PENDENTE-JUD-01       PIC -.---.---.---.--9,99.*/
            public DoubleBasis LD_PENDENTE_JUD_01 { get; set; } = new DoubleBasis(new PIC("9", "13", "-.---.---.---.--9V99."), 2);
            /*"    03 FILLER                   PIC X(01)     VALUE ';'.*/
            public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 LD-PENDENTE-SUC-01       PIC -.---.---.---.--9,99.*/
            public DoubleBasis LD_PENDENTE_SUC_01 { get; set; } = new DoubleBasis(new PIC("9", "13", "-.---.---.---.--9V99."), 2);
            /*"    03 FILLER                   PIC X(01)     VALUE ';'.*/
            public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 LD-PENDENTE-SAL-01       PIC -.---.---.---.--9,99.*/
            public DoubleBasis LD_PENDENTE_SAL_01 { get; set; } = new DoubleBasis(new PIC("9", "13", "-.---.---.---.--9V99."), 2);
            /*"    03 FILLER                   PIC X(01)     VALUE ';'.*/
            public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 LD-MOTIVO-01             PIC X(20).*/
            public StringBasis LD_MOTIVO_01 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
            /*"    03 FILLER                   PIC X(01)     VALUE ';'.*/
            public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"01 LT-ARQNEGAV-01.*/
        }
        public SI5039B_LT_ARQNEGAV_01 LT_ARQNEGAV_01 { get; set; } = new SI5039B_LT_ARQNEGAV_01();
        public class SI5039B_LT_ARQNEGAV_01 : VarBasis
        {
            /*"    03 FILLER                   PIC X(50)     VALUE       '*** NAO HA LANCAMENTOS OU PENDENCIAS NEGATIVAS ***'.*/
            public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "50", "X(50)"), @"*** NAO HA LANCAMENTOS OU PENDENCIAS NEGATIVAS ***");
            /*"    03 FILLER                   PIC X(01)     VALUE ';'.*/
            public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
        }


        public Copies.LBSI1001 LBSI1001 { get; set; } = new Copies.LBSI1001();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();

        public SI5039B_CR_HISTORICO CR_HISTORICO { get; set; } = new SI5039B_CR_HISTORICO(true);
        string GetQuery_CR_HISTORICO()
        {
            var query = @$"SELECT H.NUM_APOL_SINISTRO
							, H.DATA_MOVIMENTO
							, H.VAL_OPERACAO
							, H.COD_OPERACAO
							, H.OCORR_HISTORICO
							, H.NOM_PROGRAMA
							, H.COD_USUARIO
							FROM SEGUROS.SINISTRO_HISTORICO H WHERE H.DATA_MOVIMENTO = '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' ORDER BY H.NUM_APOL_SINISTRO";

            return query;
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string ARQNEGAV_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                ARQNEGAV.SetFile(ARQNEGAV_FILE_NAME_P);
                InitializeGetQuery();

                /*" -216- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -217- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -218- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -222- OPEN OUTPUT ARQNEGAV. */
                ARQNEGAV.Open(RARQNEGAV);

                /*" -224- PERFORM R10-LE-DATA-SISTEMAS THRU R10-FIM. */

                R10_LE_DATA_SISTEMAS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R10_FIM*/


                /*" -226- PERFORM R20-PRINCIPAL THRU R20-FIM. */

                R20_PRINCIPAL(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R20_FIM*/


                /*" -228- CLOSE ARQNEGAV. */
                ARQNEGAV.Close();

                /*" -229- DISPLAY 'LIDOS      PAR_SIVAT -  ' CT-FETCH. */
                _.Display($"LIDOS      PAR_SIVAT -  {AREA_DE_WORK.CT_FETCH}");

                /*" -230- DISPLAY 'GRAVADOS   ARQNEGAV  -  ' CT-ARQNEGAV. */
                _.Display($"GRAVADOS   ARQNEGAV  -  {AREA_DE_WORK.CT_ARQNEGAV}");

                /*" -231- DISPLAY '******************************' . */
                _.Display($"******************************");

                /*" -232- DISPLAY '***   SI5039B - FIM NORMAL ***' . */
                _.Display($"***   SI5039B - FIM NORMAL ***");

                /*" -234- DISPLAY '******************************' . */
                _.Display($"******************************");

                /*" -235- IF CT-ARQNEGAV GREATER ZEROS */

                if (AREA_DE_WORK.CT_ARQNEGAV > 00)
                {

                    /*" -236- DISPLAY '*** SI5039B - ARQUIVO DE NEGATIVOS GERADO ***' */
                    _.Display($"*** SI5039B - ARQUIVO DE NEGATIVOS GERADO ***");

                    /*" -237- DISPLAY '*** SI5039B - AVISAR OS ANALISTAS DO SINISTRO *' */
                    _.Display($"*** SI5039B - AVISAR OS ANALISTAS DO SINISTRO *");

                    /*" -238- DISPLAY '*** SI5039B - CONTINUAR NO PROXIMO STEP DA PROC' */
                    _.Display($"*** SI5039B - CONTINUAR NO PROXIMO STEP DA PROC");

                    /*" -239- MOVE 99 TO RETURN-CODE */
                    _.Move(99, RETURN_CODE);

                    /*" -241- END-IF. */
                }


                /*" -241- STOP RUN. */

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
            CR_HISTORICO.GetQueryEvent += GetQuery_CR_HISTORICO;
        }

        [StopWatch]
        /*" R10-LE-DATA-SISTEMAS */
        private void R10_LE_DATA_SISTEMAS(bool isPerform = false)
        {
            /*" -251- MOVE '001' TO WNR-EXEC-SQL. */
            _.Move("001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -258- PERFORM R10_LE_DATA_SISTEMAS_DB_SELECT_1 */

            R10_LE_DATA_SISTEMAS_DB_SELECT_1();

            /*" -261- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -262- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -263- DISPLAY 'SI5039B - DATA NA SISTEMAS NAO ENCONTRADA' */
                    _.Display($"SI5039B - DATA NA SISTEMAS NAO ENCONTRADA");

                    /*" -264- ELSE */
                }
                else
                {


                    /*" -265- DISPLAY 'SI5039B - PROBLEMAS NO SELECT SISTEMAS' */
                    _.Display($"SI5039B - PROBLEMAS NO SELECT SISTEMAS");

                    /*" -266- END-IF */
                }


                /*" -267- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -269- END-IF. */
            }


            /*" -270- MOVE SISTEMAS-DATA-MOV-ABERTO TO DB2-DATA. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREA_DE_WORK.DB2_DATA);

            /*" -271- MOVE DB2-ANO TO EDIT-ANO. */
            _.Move(AREA_DE_WORK.DB2_DATA.DB2_ANO, AREA_DE_WORK.EDIT_DATA.EDIT_ANO);

            /*" -272- MOVE DB2-MES TO EDIT-MES. */
            _.Move(AREA_DE_WORK.DB2_DATA.DB2_MES, AREA_DE_WORK.EDIT_DATA.EDIT_MES);

            /*" -273- MOVE DB2-DIA TO EDIT-DIA. */
            _.Move(AREA_DE_WORK.DB2_DATA.DB2_DIA, AREA_DE_WORK.EDIT_DATA.EDIT_DIA);

            /*" -275- MOVE EDIT-DATA TO LC-DATA-PROC-02. */
            _.Move(AREA_DE_WORK.EDIT_DATA, LC_ARQNEGAV_02.LC_DATA_PROC_02);

            /*" -276- WRITE RARQNEGAV FROM LC-ARQNEGAV-01. */
            _.Move(LC_ARQNEGAV_01.GetMoveValues(), RARQNEGAV);

            ARQNEGAV.Write(RARQNEGAV.GetMoveValues().ToString());

            /*" -277- WRITE RARQNEGAV FROM LC-ARQNEGAV-02. */
            _.Move(LC_ARQNEGAV_02.GetMoveValues(), RARQNEGAV);

            ARQNEGAV.Write(RARQNEGAV.GetMoveValues().ToString());

            /*" -277- WRITE RARQNEGAV FROM LC-ARQNEGAV-03. */
            _.Move(LC_ARQNEGAV_03.GetMoveValues(), RARQNEGAV);

            ARQNEGAV.Write(RARQNEGAV.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" R10-LE-DATA-SISTEMAS-DB-SELECT-1 */
        public void R10_LE_DATA_SISTEMAS_DB_SELECT_1()
        {
            /*" -258- EXEC SQL SELECT DATA_MOV_ABERTO, DATULT_PROCESSAMEN INTO :SISTEMAS-DATA-MOV-ABERTO, :SISTEMAS-DATULT-PROCESSAMEN FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' END-EXEC. */

            var r10_LE_DATA_SISTEMAS_DB_SELECT_1_Query1 = new R10_LE_DATA_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R10_LE_DATA_SISTEMAS_DB_SELECT_1_Query1.Execute(r10_LE_DATA_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.SISTEMAS_DATULT_PROCESSAMEN, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATULT_PROCESSAMEN);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R10_FIM*/

        [StopWatch]
        /*" R20-PRINCIPAL */
        private void R20_PRINCIPAL(bool isPerform = false)
        {
            /*" -290- PERFORM R200-OPEN-CR-HISTORICO THRU R200-FIM. */

            R200_OPEN_CR_HISTORICO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R200_FIM*/


            /*" -293- PERFORM R210-LE-CR-HISTORICO THRU R210-FIM UNTIL QBAT-CR-HISTORICO EQUAL HIGH-VALUE. */

            while (!(AREA_DE_WORK.QBAT_CR_HISTORICO.IsHighValues))
            {

                R210_LE_CR_HISTORICO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R210_FIM*/

            }

            /*" -295- PERFORM R220-CLOSE-CR-HISTORICO THRU R220-FIM. */

            R220_CLOSE_CR_HISTORICO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R220_FIM*/


            /*" -296- IF CT-ARQNEGAV EQUAL ZEROS */

            if (AREA_DE_WORK.CT_ARQNEGAV == 00)
            {

                /*" -297- WRITE RARQNEGAV FROM LT-ARQNEGAV-01 */
                _.Move(LT_ARQNEGAV_01.GetMoveValues(), RARQNEGAV);

                ARQNEGAV.Write(RARQNEGAV.GetMoveValues().ToString());

                /*" -297- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R20_FIM*/

        [StopWatch]
        /*" R200-OPEN-CR-HISTORICO */
        private void R200_OPEN_CR_HISTORICO(bool isPerform = false)
        {
            /*" -310- MOVE '002' TO WNR-EXEC-SQL. */
            _.Move("002", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -312- PERFORM R200_OPEN_CR_HISTORICO_DB_OPEN_1 */

            R200_OPEN_CR_HISTORICO_DB_OPEN_1();

            /*" -315- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -316- DISPLAY 'SI5039B - ERRO NO OPEN DO CURSOR CR_HISTORICO' */
                _.Display($"SI5039B - ERRO NO OPEN DO CURSOR CR_HISTORICO");

                /*" -317- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -317- END-IF. */
            }


        }

        [StopWatch]
        /*" R200-OPEN-CR-HISTORICO-DB-OPEN-1 */
        public void R200_OPEN_CR_HISTORICO_DB_OPEN_1()
        {
            /*" -312- EXEC SQL OPEN CR_HISTORICO END-EXEC. */

            CR_HISTORICO.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R200_FIM*/

        [StopWatch]
        /*" R210-LE-CR-HISTORICO */
        private void R210_LE_CR_HISTORICO(bool isPerform = false)
        {
            /*" -329- MOVE '003' TO WNR-EXEC-SQL. */
            _.Move("003", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -330- MOVE AT-SINISTRO TO AN-SINISTRO. */
            _.Move(AREA_DE_WORK.AT_SINISTRO, AREA_DE_WORK.AN_SINISTRO);

            /*" -331- MOVE ZEROS TO CA-VALOR-PENDENTE. */
            _.Move(0, AREA_DE_WORK.CA_VALOR_PENDENTE);

            /*" -332- MOVE ZEROS TO LD-PENDENTE-SEG-01. */
            _.Move(0, LD_ARQNEGAV_01.LD_PENDENTE_SEG_01);

            /*" -333- MOVE ZEROS TO LD-PENDENTE-JUD-01. */
            _.Move(0, LD_ARQNEGAV_01.LD_PENDENTE_JUD_01);

            /*" -334- MOVE ZEROS TO LD-PENDENTE-SUC-01. */
            _.Move(0, LD_ARQNEGAV_01.LD_PENDENTE_SUC_01);

            /*" -336- MOVE ZEROS TO LD-PENDENTE-SAL-01. */
            _.Move(0, LD_ARQNEGAV_01.LD_PENDENTE_SAL_01);

            /*" -344- PERFORM R210_LE_CR_HISTORICO_DB_FETCH_1 */

            R210_LE_CR_HISTORICO_DB_FETCH_1();

            /*" -347- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -348- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -349- MOVE HIGH-VALUE TO QBAT-CR-HISTORICO */

                    AREA_DE_WORK.QBAT_CR_HISTORICO.IsHighValues = true;

                    /*" -350- GO TO R210-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R210_FIM*/ //GOTO
                    return;

                    /*" -351- ELSE */
                }
                else
                {


                    /*" -352- DISPLAY 'SI5039B - PROBLEMAS NO FETCH CR_HISTORICO' */
                    _.Display($"SI5039B - PROBLEMAS NO FETCH CR_HISTORICO");

                    /*" -353- DISPLAY 'SINISTRO  = ' SINISHIS-NUM-APOL-SINISTRO */
                    _.Display($"SINISTRO  = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                    /*" -354- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;

                    /*" -355- END-IF */
                }


                /*" -357- END-IF. */
            }


            /*" -359- MOVE SINISHIS-NUM-APOL-SINISTRO TO AT-NUM-APOL-SINISTRO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, AREA_DE_WORK.FILLER_4.AT_NUM_APOL_SINISTRO);

            /*" -360- IF AN-SINISTRO NOT EQUAL AT-SINISTRO */

            if (AREA_DE_WORK.AN_SINISTRO != AREA_DE_WORK.AT_SINISTRO)
            {

                /*" -361- IF AN-SINISTRO EQUAL LOW-VALUE */

                if (AREA_DE_WORK.AN_SINISTRO == "")
                {

                    /*" -362- MOVE AT-SINISTRO TO AN-SINISTRO */
                    _.Move(AREA_DE_WORK.AT_SINISTRO, AREA_DE_WORK.AN_SINISTRO);

                    /*" -363- ELSE */
                }
                else
                {


                    /*" -364- PERFORM R2110-BUSCA-PENDENTE THRU R2110-FIM */

                    R2110_BUSCA_PENDENTE(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2110_FIM*/


                    /*" -365- IF CA-VALOR-PENDENTE LESS ZEROS */

                    if (AREA_DE_WORK.CA_VALOR_PENDENTE < 00)
                    {

                        /*" -366- PERFORM R2100-GRAVA-ARQNEGAV THRU R2100-FIM */

                        R2100_GRAVA_ARQNEGAV(true);
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_FIM*/


                        /*" -367- END-IF */
                    }


                    /*" -368- END-IF */
                }


                /*" -370- END-IF. */
            }


            /*" -371- IF NL-COD-PROGRAMA EQUAL -1 */

            if (AREA_DE_WORK.NL_COD_PROGRAMA == -1)
            {

                /*" -372- MOVE SPACES TO SINISHIS-NOM-PROGRAMA */
                _.Move("", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOM_PROGRAMA);

                /*" -374- END-IF. */
            }


            /*" -376- ADD 1 TO CT-FETCH. */
            AREA_DE_WORK.CT_FETCH.Value = AREA_DE_WORK.CT_FETCH + 1;

            /*" -377- IF SINISHIS-COD-OPERACAO EQUAL 1073 OR 1173 OR 1030 OR 1040 */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.In("1073", "1173", "1030", "1040"))
            {

                /*" -378- GO TO R210-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R210_FIM*/ //GOTO
                return;

                /*" -380- END-IF. */
            }


            /*" -381- IF SINISHIS-VAL-OPERACAO LESS ZEROS */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO < 00)
            {

                /*" -382- PERFORM R2100-GRAVA-ARQNEGAV THRU R2100-FIM */

                R2100_GRAVA_ARQNEGAV(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_FIM*/


                /*" -382- END-IF. */
            }


        }

        [StopWatch]
        /*" R210-LE-CR-HISTORICO-DB-FETCH-1 */
        public void R210_LE_CR_HISTORICO_DB_FETCH_1()
        {
            /*" -344- EXEC SQL FETCH CR_HISTORICO INTO :SINISHIS-NUM-APOL-SINISTRO, :SINISHIS-DATA-MOVIMENTO, :SINISHIS-VAL-OPERACAO, :SINISHIS-COD-OPERACAO, :SINISHIS-OCORR-HISTORICO, :SINISHIS-NOM-PROGRAMA:NL-COD-PROGRAMA, :SINISHIS-COD-USUARIO END-EXEC. */

            if (CR_HISTORICO.Fetch())
            {
                _.Move(CR_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);
                _.Move(CR_HISTORICO.SINISHIS_DATA_MOVIMENTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO);
                _.Move(CR_HISTORICO.SINISHIS_VAL_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);
                _.Move(CR_HISTORICO.SINISHIS_COD_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);
                _.Move(CR_HISTORICO.SINISHIS_OCORR_HISTORICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO);
                _.Move(CR_HISTORICO.SINISHIS_NOM_PROGRAMA, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOM_PROGRAMA);
                _.Move(CR_HISTORICO.NL_COD_PROGRAMA, AREA_DE_WORK.NL_COD_PROGRAMA);
                _.Move(CR_HISTORICO.SINISHIS_COD_USUARIO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_USUARIO);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R210_FIM*/

        [StopWatch]
        /*" R2100-GRAVA-ARQNEGAV */
        private void R2100_GRAVA_ARQNEGAV(bool isPerform = false)
        {
            /*" -395- ADD 1 TO CT-ARQNEGAV. */
            AREA_DE_WORK.CT_ARQNEGAV.Value = AREA_DE_WORK.CT_ARQNEGAV + 1;

            /*" -396- IF CA-VALOR-PENDENTE LESS ZEROS */

            if (AREA_DE_WORK.CA_VALOR_PENDENTE < 00)
            {

                /*" -397- MOVE AN-NUM-APOL-SINISTRO TO LD-SINISTRO-01 */
                _.Move(AREA_DE_WORK.FILLER_5.AN_NUM_APOL_SINISTRO, LD_ARQNEGAV_01.LD_SINISTRO_01);

                /*" -398- MOVE 'PENDENTE NEGATIVO' TO LD-MOTIVO-01 */
                _.Move("PENDENTE NEGATIVO", LD_ARQNEGAV_01.LD_MOTIVO_01);

                /*" -399- MOVE ZEROS TO LD-COD-OPERACAO-01 */
                _.Move(0, LD_ARQNEGAV_01.LD_COD_OPERACAO_01);

                /*" -400- MOVE SPACES TO LD-NOME-PROGRAMA-01 */
                _.Move("", LD_ARQNEGAV_01.LD_NOME_PROGRAMA_01);

                /*" -401- MOVE SPACES TO LD-COD-USUARIO-01 */
                _.Move("", LD_ARQNEGAV_01.LD_COD_USUARIO_01);

                /*" -402- MOVE SPACES TO LD-DATA-MOVIMENTO-01 */
                _.Move("", LD_ARQNEGAV_01.LD_DATA_MOVIMENTO_01);

                /*" -403- MOVE ZEROS TO LD-OCORR-HISTORICO-01 */
                _.Move(0, LD_ARQNEGAV_01.LD_OCORR_HISTORICO_01);

                /*" -404- MOVE ZEROS TO LD-VALOR-OPERACAO-01 */
                _.Move(0, LD_ARQNEGAV_01.LD_VALOR_OPERACAO_01);

                /*" -405- MOVE CA-VALOR-PENDENTE TO LD-VALOR-PENDENTE-01 */
                _.Move(AREA_DE_WORK.CA_VALOR_PENDENTE, LD_ARQNEGAV_01.LD_VALOR_PENDENTE_01);

                /*" -406- ELSE */
            }
            else
            {


                /*" -407- MOVE SINISHIS-VAL-OPERACAO TO LD-VALOR-OPERACAO-01 */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, LD_ARQNEGAV_01.LD_VALOR_OPERACAO_01);

                /*" -408- MOVE SINISHIS-COD-OPERACAO TO LD-COD-OPERACAO-01 */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO, LD_ARQNEGAV_01.LD_COD_OPERACAO_01);

                /*" -409- MOVE SINISHIS-NOM-PROGRAMA TO LD-NOME-PROGRAMA-01 */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOM_PROGRAMA, LD_ARQNEGAV_01.LD_NOME_PROGRAMA_01);

                /*" -410- MOVE SINISHIS-COD-USUARIO TO LD-COD-USUARIO-01 */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_USUARIO, LD_ARQNEGAV_01.LD_COD_USUARIO_01);

                /*" -411- MOVE SINISHIS-OCORR-HISTORICO TO LD-OCORR-HISTORICO-01 */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO, LD_ARQNEGAV_01.LD_OCORR_HISTORICO_01);

                /*" -412- MOVE SINISHIS-DATA-MOVIMENTO TO LD-DATA-MOVIMENTO-01 */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO, LD_ARQNEGAV_01.LD_DATA_MOVIMENTO_01);

                /*" -413- MOVE 'OPERACAO NEGATIVA' TO LD-MOTIVO-01 */
                _.Move("OPERACAO NEGATIVA", LD_ARQNEGAV_01.LD_MOTIVO_01);

                /*" -414- MOVE AT-NUM-APOL-SINISTRO TO LD-SINISTRO-01 */
                _.Move(AREA_DE_WORK.FILLER_4.AT_NUM_APOL_SINISTRO, LD_ARQNEGAV_01.LD_SINISTRO_01);

                /*" -415- MOVE ZEROS TO LD-VALOR-PENDENTE-01 */
                _.Move(0, LD_ARQNEGAV_01.LD_VALOR_PENDENTE_01);

                /*" -417- END-IF. */
            }


            /*" -417- WRITE RARQNEGAV FROM LD-ARQNEGAV-01. */
            _.Move(LD_ARQNEGAV_01.GetMoveValues(), RARQNEGAV);

            ARQNEGAV.Write(RARQNEGAV.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_FIM*/

        [StopWatch]
        /*" R2110-BUSCA-PENDENTE */
        private void R2110_BUSCA_PENDENTE(bool isPerform = false)
        {
            /*" -430- INITIALIZE SI1001S-PARAMETROS. */
            _.Initialize(
                LBSI1001.SI1001S_PARAMETROS
            );

            /*" -431- MOVE AN-NUM-APOL-SINISTRO TO SI1001S-NUM-APOL-SINISTRO. */
            _.Move(AREA_DE_WORK.FILLER_5.AN_NUM_APOL_SINISTRO, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO);

            /*" -433- MOVE SISTEMAS-DATA-MOV-ABERTO TO SI1001S-DATA-FIM. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_DATA_FIM);

            /*" -435- CALL 'SI1017S' USING SI1001S-PARAMETROS. */
            _.Call("SI1017S", LBSI1001.SI1001S_PARAMETROS);

            /*" -436- IF SI1001S-ERRO-MENSAGEM NOT EQUAL SPACES */

            if (!LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM.IsEmpty())
            {

                /*" -437- DISPLAY 'SI5039B - PROBLEMAS NO CALL SUBROTINA SI1017S' */
                _.Display($"SI5039B - PROBLEMAS NO CALL SUBROTINA SI1017S");

                /*" -438- DISPLAY 'SINISTRO......= ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO......= {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -439- DISPLAY 'DATA SISTEMAS = ' SISTEMAS-DATA-MOV-ABERTO */
                _.Display($"DATA SISTEMAS = {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

                /*" -440- DISPLAY 'SQLCODE...... = ' SI1001S-ERRO-SQLCODE */
                _.Display($"SQLCODE...... = {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_SQLCODE}");

                /*" -441- DISPLAY SI1001S-ERRO-MENSAGEM */
                _.Display(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM);

                /*" -442- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -444- END-IF. */
            }


            /*" -446- MOVE SI1001S-VALOR-CALCULADO TO CA-VALOR-PENDENTE. */
            _.Move(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_VALOR_CALCULADO, AREA_DE_WORK.CA_VALOR_PENDENTE);

            /*" -447- IF CA-VALOR-PENDENTE NOT LESS ZEROS */

            if (AREA_DE_WORK.CA_VALOR_PENDENTE >= 00)
            {

                /*" -448- GO TO R2110-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2110_FIM*/ //GOTO
                return;

                /*" -450- END-IF. */
            }


            /*" -452- INITIALIZE SI1001S-PARAMETROS. */
            _.Initialize(
                LBSI1001.SI1001S_PARAMETROS
            );

            /*" -453- MOVE AN-NUM-APOL-SINISTRO TO SI1001S-NUM-APOL-SINISTRO. */
            _.Move(AREA_DE_WORK.FILLER_5.AN_NUM_APOL_SINISTRO, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO);

            /*" -455- MOVE SISTEMAS-DATA-MOV-ABERTO TO SI1001S-DATA-FIM. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_DATA_FIM);

            /*" -457- CALL 'SI1001S' USING SI1001S-PARAMETROS. */
            _.Call("SI1001S", LBSI1001.SI1001S_PARAMETROS);

            /*" -458- IF SI1001S-ERRO-MENSAGEM NOT EQUAL SPACES */

            if (!LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM.IsEmpty())
            {

                /*" -459- DISPLAY 'SI5039B - PROBLEMAS NO CALL SUBROTINA SI1001S' */
                _.Display($"SI5039B - PROBLEMAS NO CALL SUBROTINA SI1001S");

                /*" -460- DISPLAY 'SINISTRO......= ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO......= {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -461- DISPLAY 'DATA SISTEMAS = ' SISTEMAS-DATA-MOV-ABERTO */
                _.Display($"DATA SISTEMAS = {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

                /*" -462- DISPLAY 'SQLCODE...... = ' SI1001S-ERRO-SQLCODE */
                _.Display($"SQLCODE...... = {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_SQLCODE}");

                /*" -463- DISPLAY SI1001S-ERRO-MENSAGEM */
                _.Display(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM);

                /*" -464- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -466- END-IF. */
            }


            /*" -467- IF SI1001S-VALOR-CALCULADO LESS ZEROS */

            if (LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_VALOR_CALCULADO < 00)
            {

                /*" -468- MOVE SI1001S-VALOR-CALCULADO TO LD-PENDENTE-SEG-01 */
                _.Move(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_VALOR_CALCULADO, LD_ARQNEGAV_01.LD_PENDENTE_SEG_01);

                /*" -470- END-IF. */
            }


            /*" -472- INITIALIZE SI1001S-PARAMETROS. */
            _.Initialize(
                LBSI1001.SI1001S_PARAMETROS
            );

            /*" -473- MOVE AN-NUM-APOL-SINISTRO TO SI1001S-NUM-APOL-SINISTRO. */
            _.Move(AREA_DE_WORK.FILLER_5.AN_NUM_APOL_SINISTRO, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO);

            /*" -475- MOVE SISTEMAS-DATA-MOV-ABERTO TO SI1001S-DATA-FIM. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_DATA_FIM);

            /*" -477- CALL 'SI1007S' USING SI1001S-PARAMETROS. */
            _.Call("SI1007S", LBSI1001.SI1001S_PARAMETROS);

            /*" -478- IF SI1001S-ERRO-MENSAGEM NOT EQUAL SPACES */

            if (!LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM.IsEmpty())
            {

                /*" -479- DISPLAY 'SI5039B - PROBLEMAS NO CALL SUBROTINA SI1007S' */
                _.Display($"SI5039B - PROBLEMAS NO CALL SUBROTINA SI1007S");

                /*" -480- DISPLAY 'SINISTRO......= ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO......= {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -481- DISPLAY 'DATA SISTEMAS = ' SISTEMAS-DATA-MOV-ABERTO */
                _.Display($"DATA SISTEMAS = {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

                /*" -482- DISPLAY 'SQLCODE...... = ' SI1001S-ERRO-SQLCODE */
                _.Display($"SQLCODE...... = {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_SQLCODE}");

                /*" -483- DISPLAY SI1001S-ERRO-MENSAGEM */
                _.Display(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM);

                /*" -484- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -486- END-IF. */
            }


            /*" -487- IF SI1001S-VALOR-CALCULADO LESS ZEROS */

            if (LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_VALOR_CALCULADO < 00)
            {

                /*" -488- MOVE SI1001S-VALOR-CALCULADO TO LD-PENDENTE-JUD-01 */
                _.Move(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_VALOR_CALCULADO, LD_ARQNEGAV_01.LD_PENDENTE_JUD_01);

                /*" -490- END-IF. */
            }


            /*" -492- INITIALIZE SI1001S-PARAMETROS. */
            _.Initialize(
                LBSI1001.SI1001S_PARAMETROS
            );

            /*" -493- MOVE AN-NUM-APOL-SINISTRO TO SI1001S-NUM-APOL-SINISTRO. */
            _.Move(AREA_DE_WORK.FILLER_5.AN_NUM_APOL_SINISTRO, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO);

            /*" -495- MOVE SISTEMAS-DATA-MOV-ABERTO TO SI1001S-DATA-FIM. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_DATA_FIM);

            /*" -497- CALL 'SI1011S' USING SI1001S-PARAMETROS. */
            _.Call("SI1011S", LBSI1001.SI1001S_PARAMETROS);

            /*" -498- IF SI1001S-ERRO-MENSAGEM NOT EQUAL SPACES */

            if (!LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM.IsEmpty())
            {

                /*" -499- DISPLAY 'SI5039B - PROBLEMAS NO CALL SUBROTINA SI1011S' */
                _.Display($"SI5039B - PROBLEMAS NO CALL SUBROTINA SI1011S");

                /*" -500- DISPLAY 'SINISTRO......= ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO......= {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -501- DISPLAY 'DATA SISTEMAS = ' SISTEMAS-DATA-MOV-ABERTO */
                _.Display($"DATA SISTEMAS = {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

                /*" -502- DISPLAY 'SQLCODE...... = ' SI1001S-ERRO-SQLCODE */
                _.Display($"SQLCODE...... = {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_SQLCODE}");

                /*" -503- DISPLAY SI1001S-ERRO-MENSAGEM */
                _.Display(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM);

                /*" -504- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -506- END-IF. */
            }


            /*" -507- IF SI1001S-VALOR-CALCULADO LESS ZEROS */

            if (LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_VALOR_CALCULADO < 00)
            {

                /*" -508- MOVE SI1001S-VALOR-CALCULADO TO LD-PENDENTE-SUC-01 */
                _.Move(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_VALOR_CALCULADO, LD_ARQNEGAV_01.LD_PENDENTE_SUC_01);

                /*" -510- END-IF. */
            }


            /*" -512- INITIALIZE SI1001S-PARAMETROS. */
            _.Initialize(
                LBSI1001.SI1001S_PARAMETROS
            );

            /*" -513- MOVE AN-NUM-APOL-SINISTRO TO SI1001S-NUM-APOL-SINISTRO. */
            _.Move(AREA_DE_WORK.FILLER_5.AN_NUM_APOL_SINISTRO, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO);

            /*" -515- MOVE SISTEMAS-DATA-MOV-ABERTO TO SI1001S-DATA-FIM. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_DATA_FIM);

            /*" -517- CALL 'SI1032S' USING SI1001S-PARAMETROS. */
            _.Call("SI1032S", LBSI1001.SI1001S_PARAMETROS);

            /*" -518- IF SI1001S-ERRO-MENSAGEM NOT EQUAL SPACES */

            if (!LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM.IsEmpty())
            {

                /*" -519- DISPLAY 'SI5039B - PROBLEMAS NO CALL SUBROTINA SI1032S' */
                _.Display($"SI5039B - PROBLEMAS NO CALL SUBROTINA SI1032S");

                /*" -520- DISPLAY 'SINISTRO......= ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO......= {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -521- DISPLAY 'DATA SISTEMAS = ' SISTEMAS-DATA-MOV-ABERTO */
                _.Display($"DATA SISTEMAS = {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

                /*" -522- DISPLAY 'SQLCODE...... = ' SI1001S-ERRO-SQLCODE */
                _.Display($"SQLCODE...... = {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_SQLCODE}");

                /*" -523- DISPLAY SI1001S-ERRO-MENSAGEM */
                _.Display(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM);

                /*" -524- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -526- END-IF. */
            }


            /*" -527- IF SI1001S-VALOR-CALCULADO LESS ZEROS */

            if (LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_VALOR_CALCULADO < 00)
            {

                /*" -528- MOVE SI1001S-VALOR-CALCULADO TO LD-PENDENTE-SAL-01 */
                _.Move(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_VALOR_CALCULADO, LD_ARQNEGAV_01.LD_PENDENTE_SAL_01);

                /*" -528- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2110_FIM*/

        [StopWatch]
        /*" R220-CLOSE-CR-HISTORICO */
        private void R220_CLOSE_CR_HISTORICO(bool isPerform = false)
        {
            /*" -541- MOVE '007' TO WNR-EXEC-SQL. */
            _.Move("007", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -543- PERFORM R220_CLOSE_CR_HISTORICO_DB_CLOSE_1 */

            R220_CLOSE_CR_HISTORICO_DB_CLOSE_1();

            /*" -546- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -547- DISPLAY 'SI5039B - ERRO NO CLOSE DO CURSOR CR_HISTORICO' */
                _.Display($"SI5039B - ERRO NO CLOSE DO CURSOR CR_HISTORICO");

                /*" -548- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -548- END-IF. */
            }


        }

        [StopWatch]
        /*" R220-CLOSE-CR-HISTORICO-DB-CLOSE-1 */
        public void R220_CLOSE_CR_HISTORICO_DB_CLOSE_1()
        {
            /*" -543- EXEC SQL CLOSE CR_HISTORICO END-EXEC. */

            CR_HISTORICO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R220_FIM*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO */
        private void R9999_00_ROT_ERRO(bool isPerform = false)
        {
            /*" -561- CLOSE ARQNEGAV. */
            ARQNEGAV.Close();

            /*" -563- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -565- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -565- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -568- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -569- DISPLAY '***   SI5039B - CANCELADO  ***' */
            _.Display($"***   SI5039B - CANCELADO  ***");

            /*" -571- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -573- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -573- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}