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
using Sias.Cobranca.DB2.CB1264B;

namespace Code
{
    public class CB1264B
    {
        public bool IsCall { get; set; }

        public CB1264B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  COBRANCA                           *      */
        /*"      *   PROGRAMA ...............  CB1264B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA/PROGRAMADOR....  CARLOS ALBERTO DE A ALVES          *      */
        /*"      *   DATA CODIFICACAO .......  MARCO / 2002                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO ................. -CANCELAR APOLICES POR FALTA  DE    *      */
        /*"      *                             PAGAMENTO,                         *      */
        /*"      *                            -CADASTRADAS NA CB_APOLICE_VIGPROP, *      */
        /*"      *                             COM OS CAMPOS SITUACAO=PENDENTE  E *      */
        /*"      *                             DATA_CANCELAMENTO MENOR OU IGUAL A *      */
        /*"      *                             DO DIA (SISTEMA=CB).               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACOES ............. -EM 16/04/2003    VER CL0403        *      */
        /*"      *                             INIBE CANCELAMENTO DO CONVENIO     *      */
        /*"      *                             VERA CRUZ - ORGAO 100              *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERADO EM 03/11/2003, NAO CANCELAR AS APOLICES DOS RAMOS 40 E*      */
        /*"      * IDENTIFICADOR: CAAA2    67                                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERADO EM 07/07/2004 - CARLOS ALBERTO - PROCURAR CA0704      *      */
        /*"      *                          CANCELAR AS APOLICES DO RAMO 67       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO:  21/07/08   WELLINGTON VERAS (POLITEC)                     */
        /*"      *    PROJETO FGV                                                        */
        /*"      *                INIBIR COMANDO DISPLAY    WV0708                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO:  16/11/11   CHICON (COREON)                         *      */
        /*"      *    PROJETO PROJAUTO                                            *      */
        /*"      *    DESPREZAR AS AP�LICES DE AUTOMOVEL DO CONVENIO SULAMERICA   *      */
        /*"      *    PROCURAR POR CO1116                                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO:  22/01/14   DAIRO LOPES                             *      */
        /*"      *    CAD92753 - AJUSTES DE CANCELAMENTO NO ARQUIVO DE ASSISTENCIA*      */
        /*"      *               GRAVAR AU2060B3 PARA CADA APOLICE.     V.07      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO:  19/11/14   DAIRO LOPES                             *      */
        /*"      *   CAD104563 - AJUSTAR CANCELAMENTO AUTO FACIL                  *      */
        /*"      *               RETIRAR REGRA ANTERIOR E VALIDAR DIAS  V.08      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                    DCLGEN                      ACESSO   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * SISTEMAS                  SISTEMAS                    INPUT    *      */
        /*"      * CB_APOLICE_VIGPROP        CBAPOVIG                    I-O             */
        /*"      * SINISTRO_MESTRE           SINISMES                    INPUT    *      */
        /*"      * FOLLOW_UP                 FOLLOUP                     INPUT    *      */
        /*"      * PARCELAS                  PARCELAS                    I-O      *      */
        /*"      * APOLICES                  APOLICES                    INPUT    *      */
        /*"      * ENDOSSOS                  ENDOSSOS                    INPUT    *      */
        /*"      * NUMERO_AES                NUMERAES                    I-O      *      */
        /*"      * PARCELA_HISTORICO         PARCEHIS                    I-O      *      */
        /*"      * MOVTO_DEBITOCC_CEF        MOVDEBCE                    I-O      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      ****************************                                            */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77         WS-HOST-QTD-FOLLOW-UP   PIC S9(09) VALUE +0 COMP.*/
        public IntBasis WS_HOST_QTD_FOLLOW_UP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77         WS-HOST-QTD-SINISTROS   PIC S9(09) VALUE +0 COMP.*/
        public IntBasis WS_HOST_QTD_SINISTROS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77         WS-HOST-QTD-PARCELAS    PIC S9(09) VALUE +0 COMP.*/
        public IntBasis WS_HOST_QTD_PARCELAS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77         WS-CM-PRM-TARIFARIO     PIC S9(13)V99 VALUE +0 COMP-3*/
        public DoubleBasis WS_CM_PRM_TARIFARIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77         WS-CM-VAL-DESCONTO      PIC S9(13)V99 VALUE +0 COMP-3*/
        public DoubleBasis WS_CM_VAL_DESCONTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77         WS-CM-PRM-LIQUIDO       PIC S9(13)V99 VALUE +0 COMP-3*/
        public DoubleBasis WS_CM_PRM_LIQUIDO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77         WS-CM-ADICIONAL-FRACIO  PIC S9(13)V99 VALUE +0 COMP-3*/
        public DoubleBasis WS_CM_ADICIONAL_FRACIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77         WS-CM-VAL-CUSTO-EMISSAO PIC S9(13)V99 VALUE +0 COMP-3*/
        public DoubleBasis WS_CM_VAL_CUSTO_EMISSAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77         WS-CM-VAL-IOCC          PIC S9(13)V99 VALUE +0 COMP-3*/
        public DoubleBasis WS_CM_VAL_IOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77         WS-CM-PRM-TOTAL         PIC S9(13)V99 VALUE +0 COMP-3*/
        public DoubleBasis WS_CM_PRM_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77         VIND-DATA-QUITACAO      PIC S9(04)    VALUE +0 COMP.*/
        public IntBasis VIND_DATA_QUITACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77         VIND-COD-EMPRESA        PIC S9(04)    VALUE +0 COMP.*/
        public IntBasis VIND_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01           AREA-DE-WORK.*/
        public CB1264B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new CB1264B_AREA_DE_WORK();
        public class CB1264B_AREA_DE_WORK : VarBasis
        {
            /*"  05        WS-NUM-APOLICE-ANT    PIC S9(013) VALUE +0 COMP-3.*/
            public IntBasis WS_NUM_APOLICE_ANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"  05        WS-NUM-ENDOSSO-ANT    PIC S9(009) VALUE +0 COMP.*/
            public IntBasis WS_NUM_ENDOSSO_ANT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05        WS-NUM-APOLICE        PIC S9(013) VALUE +0 COMP-3.*/
            public IntBasis WS_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"  05        WS-NUM-ENDOSSO        PIC S9(009) VALUE +0 COMP.*/
            public IntBasis WS_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05        AC-L-CBAPOVIG         PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_L_CBAPOVIG { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05        AC-L-PARCELAS         PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_L_PARCELAS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05        AC-U-CBAPOVIG         PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_U_CBAPOVIG { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05        AC-U-PARCELAS         PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_U_PARCELAS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05        AC-U-ENDOSSOS         PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_U_ENDOSSOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05        AC-P-AU2060B3         PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_P_AU2060B3 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05        AC-P-PARCEHIS         PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_P_PARCEHIS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05        AC-C-PARCEHIS         PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_C_PARCEHIS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05        WS-FIM-CBAPOVIG       PIC  X(001) VALUE SPACES.*/
            public StringBasis WS_FIM_CBAPOVIG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05        WS-FIM-PARCELAS       PIC  X(001) VALUE SPACES.*/
            public StringBasis WS_FIM_PARCELAS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WTIME-DAY         PIC  99.99.99.99.*/
            public IntBasis WTIME_DAY { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
            /*"  05         FILLER            REDEFINES      WTIME-DAY.*/
            private _REDEF_CB1264B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_CB1264B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_CB1264B_FILLER_0(); _.Move(WTIME_DAY, _filler_0); VarBasis.RedefinePassValue(WTIME_DAY, _filler_0, WTIME_DAY); _filler_0.ValueChanged += () => { _.Move(_filler_0, WTIME_DAY); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WTIME_DAY); }
            }  //Redefines
            public class _REDEF_CB1264B_FILLER_0 : VarBasis
            {
                /*"    10       WTIME-DAYR.*/
                public CB1264B_WTIME_DAYR WTIME_DAYR { get; set; } = new CB1264B_WTIME_DAYR();
                public class CB1264B_WTIME_DAYR : VarBasis
                {
                    /*"      15     WTIME-HORA        PIC  X(002).*/
                    public StringBasis WTIME_HORA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"      15     WTIME-2PT1        PIC  X(001).*/
                    public StringBasis WTIME_2PT1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15     WTIME-MINU        PIC  X(002).*/
                    public StringBasis WTIME_MINU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"      15     WTIME-2PT2        PIC  X(001).*/
                    public StringBasis WTIME_2PT2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15     WTIME-SEGU        PIC  X(002).*/
                    public StringBasis WTIME_SEGU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"    10       WTIME-2PT3        PIC  X(001).*/

                    public CB1264B_WTIME_DAYR()
                    {
                        WTIME_HORA.ValueChanged += OnValueChanged;
                        WTIME_2PT1.ValueChanged += OnValueChanged;
                        WTIME_MINU.ValueChanged += OnValueChanged;
                        WTIME_2PT2.ValueChanged += OnValueChanged;
                        WTIME_SEGU.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis WTIME_2PT3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WTIME-CCSG        PIC  X(002).*/
                public StringBasis WTIME_CCSG { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"01  WABEND.*/

                public _REDEF_CB1264B_FILLER_0()
                {
                    WTIME_DAYR.ValueChanged += OnValueChanged;
                    WTIME_2PT3.ValueChanged += OnValueChanged;
                    WTIME_CCSG.ValueChanged += OnValueChanged;
                }

            }
        }
        public CB1264B_WABEND WABEND { get; set; } = new CB1264B_WABEND();
        public class CB1264B_WABEND : VarBasis
        {
            /*"    03 FILLER       PIC X(010) VALUE 'CB1264B '.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"CB1264B ");
            /*"    03 FILLER       PIC X(026) VALUE '*** ERRO EXEC SQL NUMERO '*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"*** ERRO EXEC SQL NUMERO ");
            /*"    03 WNR-EXEC-SQL PIC X(005) VALUE SPACES.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
            /*"    03 FILLER       PIC X(013) VALUE ' *** SQLCODE '.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"    03 WSQLCODE     PIC ZZZZZZ999-.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-."));
            /*"    03 FILLER       PIC X(02)  VALUE '=>'.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"=>");
            /*"    03 FILLER       PIC X(12)  VALUE ' PARAGRAFO '.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @" PARAGRAFO ");
            /*"    03 PARAGRAFO    PIC X(30)  VALUE SPACES.*/
            public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"01    WS-HORAS.*/
        }
        public CB1264B_WS_HORAS WS_HORAS { get; set; } = new CB1264B_WS_HORAS();
        public class CB1264B_WS_HORAS : VarBasis
        {
            /*"  03  WS-HORA-INI               PIC  X(008).*/
            public StringBasis WS_HORA_INI { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-INI-R REDEFINES WS-HORA-INI.*/
            private _REDEF_CB1264B_WS_HORA_INI_R _ws_hora_ini_r { get; set; }
            public _REDEF_CB1264B_WS_HORA_INI_R WS_HORA_INI_R
            {
                get { _ws_hora_ini_r = new _REDEF_CB1264B_WS_HORA_INI_R(); _.Move(WS_HORA_INI, _ws_hora_ini_r); VarBasis.RedefinePassValue(WS_HORA_INI, _ws_hora_ini_r, WS_HORA_INI); _ws_hora_ini_r.ValueChanged += () => { _.Move(_ws_hora_ini_r, WS_HORA_INI); }; return _ws_hora_ini_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_ini_r, WS_HORA_INI); }
            }  //Redefines
            public class _REDEF_CB1264B_WS_HORA_INI_R : VarBasis
            {
                /*"      05  HI                    PIC  9(002).*/
                public IntBasis HI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  MI                    PIC  9(002).*/
                public IntBasis MI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  SI                    PIC  9(002).*/
                public IntBasis SI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  DCI                   PIC  9(002).*/
                public IntBasis DCI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03  WS-HORA-FIM               PIC  X(008).*/

                public _REDEF_CB1264B_WS_HORA_INI_R()
                {
                    HI.ValueChanged += OnValueChanged;
                    MI.ValueChanged += OnValueChanged;
                    SI.ValueChanged += OnValueChanged;
                    DCI.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_HORA_FIM { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-FIM-R REDEFINES WS-HORA-FIM.*/
            private _REDEF_CB1264B_WS_HORA_FIM_R _ws_hora_fim_r { get; set; }
            public _REDEF_CB1264B_WS_HORA_FIM_R WS_HORA_FIM_R
            {
                get { _ws_hora_fim_r = new _REDEF_CB1264B_WS_HORA_FIM_R(); _.Move(WS_HORA_FIM, _ws_hora_fim_r); VarBasis.RedefinePassValue(WS_HORA_FIM, _ws_hora_fim_r, WS_HORA_FIM); _ws_hora_fim_r.ValueChanged += () => { _.Move(_ws_hora_fim_r, WS_HORA_FIM); }; return _ws_hora_fim_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_fim_r, WS_HORA_FIM); }
            }  //Redefines
            public class _REDEF_CB1264B_WS_HORA_FIM_R : VarBasis
            {
                /*"      05  HF                    PIC  9(002).*/
                public IntBasis HF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  MF                    PIC  9(002).*/
                public IntBasis MF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  SF                    PIC  9(002).*/
                public IntBasis SF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  DCF                   PIC  9(002).*/
                public IntBasis DCF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03  SIT                       PIC S9(013)V99 COMP-3.*/

                public _REDEF_CB1264B_WS_HORA_FIM_R()
                {
                    HF.ValueChanged += OnValueChanged;
                    MF.ValueChanged += OnValueChanged;
                    SF.ValueChanged += OnValueChanged;
                    DCF.ValueChanged += OnValueChanged;
                }

            }
            public DoubleBasis SIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  SFT                       PIC S9(013)V99 COMP-3.*/
            public DoubleBasis SFT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  SII                       PIC S9(004)    COMP.*/
            public IntBasis SII { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  STT-DISP                  PIC --.---.---.---.--9,99.*/
            public DoubleBasis STT_DISP { get; set; } = new DoubleBasis(new PIC("9", "14", "--.---.---.---.--9V99."), 2);
            /*"01  TOTAIS-ROT.*/
        }
        public CB1264B_TOTAIS_ROT TOTAIS_ROT { get; set; } = new CB1264B_TOTAIS_ROT();
        public class CB1264B_TOTAIS_ROT : VarBasis
        {
            /*"    03  FILLER  OCCURS 50 TIMES.*/
            public ListBasis<CB1264B_FILLER_6> FILLER_6 { get; set; } = new ListBasis<CB1264B_FILLER_6>(50);
            public class CB1264B_FILLER_6 : VarBasis
            {
                /*"        05  STT                       PIC S9(013)V99 COMP-3.*/
                public DoubleBasis STT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                /*"        05  SQT                       PIC S9(015)    COMP-3.*/
                public IntBasis SQT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            }
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.FOLLOUP FOLLOUP { get; set; } = new Dclgens.FOLLOUP();
        public Dclgens.NUMERAES NUMERAES { get; set; } = new Dclgens.NUMERAES();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.PARCELAS PARCELAS { get; set; } = new Dclgens.PARCELAS();
        public Dclgens.PARCEHIS PARCEHIS { get; set; } = new Dclgens.PARCEHIS();
        public Dclgens.CBAPOVIG CBAPOVIG { get; set; } = new Dclgens.CBAPOVIG();
        public CB1264B_C0CBAPOVIG C0CBAPOVIG { get; set; } = new CB1264B_C0CBAPOVIG();
        public CB1264B_C0PARCELAS C0PARCELAS { get; set; } = new CB1264B_C0PARCELAS();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -223- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", WABEND.WNR_EXEC_SQL);

                /*" -224- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -227- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -230- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -230- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -239- INITIALIZE WS-HORAS TOTAIS-ROT. */
            _.Initialize(
                WS_HORAS
                , TOTAIS_ROT
            );

            /*" -241- PERFORM R0100-00-SELECT-SISTEMAS. */

            R0100_00_SELECT_SISTEMAS_SECTION();

            /*" -243- PERFORM R0500-00-DECLARE-CBAPOVIG. */

            R0500_00_DECLARE_CBAPOVIG_SECTION();

            /*" -245- PERFORM R0510-00-FETCH-CBAPOVIG. */

            R0510_00_FETCH_CBAPOVIG_SECTION();

            /*" -246- IF WS-FIM-CBAPOVIG NOT = SPACES */

            if (!AREA_DE_WORK.WS_FIM_CBAPOVIG.IsEmpty())
            {

                /*" -247- PERFORM R9000-00-ENCERRA-SEM-MOVTO */

                R9000_00_ENCERRA_SEM_MOVTO_SECTION();

                /*" -249- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -252- PERFORM R1000-00-PROCESSA-CBAPOVIG UNTIL WS-FIM-CBAPOVIG NOT = SPACES. */

            while (!(!AREA_DE_WORK.WS_FIM_CBAPOVIG.IsEmpty()))
            {

                R1000_00_PROCESSA_CBAPOVIG_SECTION();
            }

            /*" -253- DISPLAY '************ CB1264B * RESUMO ***********' */
            _.Display($"************ CB1264B * RESUMO ***********");

            /*" -254- DISPLAY '* - DOCUMENTOS LIDOS' . */
            _.Display($"* - DOCUMENTOS LIDOS");

            /*" -255- DISPLAY '*   .CB_APOLICE_VIGPROP = ' AC-L-CBAPOVIG. */
            _.Display($"*   .CB_APOLICE_VIGPROP = {AREA_DE_WORK.AC_L_CBAPOVIG}");

            /*" -256- DISPLAY '*   .PARCELAS           = ' AC-L-PARCELAS. */
            _.Display($"*   .PARCELAS           = {AREA_DE_WORK.AC_L_PARCELAS}");

            /*" -257- DISPLAY '*' . */
            _.Display($"*");

            /*" -258- DISPLAY '* - UPDATE' . */
            _.Display($"* - UPDATE");

            /*" -259- DISPLAY '*   .CB_APOLICE_VIGPROP = ' AC-U-CBAPOVIG. */
            _.Display($"*   .CB_APOLICE_VIGPROP = {AREA_DE_WORK.AC_U_CBAPOVIG}");

            /*" -260- DISPLAY '*   .PARCELAS           = ' AC-U-PARCELAS. */
            _.Display($"*   .PARCELAS           = {AREA_DE_WORK.AC_U_PARCELAS}");

            /*" -261- DISPLAY '*   .ENDOSSOS           = ' AC-U-ENDOSSOS. */
            _.Display($"*   .ENDOSSOS           = {AREA_DE_WORK.AC_U_ENDOSSOS}");

            /*" -262- DISPLAY '*' . */
            _.Display($"*");

            /*" -263- DISPLAY '* - INSERT' . */
            _.Display($"* - INSERT");

            /*" -264- DISPLAY '*   .OPERACAO CANCEL.   = ' AC-P-PARCEHIS. */
            _.Display($"*   .OPERACAO CANCEL.   = {AREA_DE_WORK.AC_P_PARCEHIS}");

            /*" -265- DISPLAY '*   .OPERACAO CM        = ' AC-C-PARCEHIS. */
            _.Display($"*   .OPERACAO CM        = {AREA_DE_WORK.AC_C_PARCEHIS}");

            /*" -266- DISPLAY '* - INSERT AU2060B3' . */
            _.Display($"* - INSERT AU2060B3");

            /*" -267- DISPLAY '*   .AU2060B3 .         = ' AC-P-AU2060B3. */
            _.Display($"*   .AU2060B3 .         = {AREA_DE_WORK.AC_P_AU2060B3}");

            /*" -267- DISPLAY '*****************************************' . */
            _.Display($"*****************************************");

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -273- DISPLAY ' ' . */
            _.Display($" ");

            /*" -273- MOVE ZEROS TO SII. */
            _.Move(0, WS_HORAS.SII);

        }

        [StopWatch]
        /*" M-1100-MOSTRA-TOTAIS */
        private void M_1100_MOSTRA_TOTAIS(bool isPerform = false)
        {
            /*" -276- ADD 1 TO SII. */
            WS_HORAS.SII.Value = WS_HORAS.SII + 1;

            /*" -277- IF SII < 33 */

            if (WS_HORAS.SII < 33)
            {

                /*" -278- MOVE STT(SII) TO STT-DISP */
                _.Move(TOTAIS_ROT.FILLER_6[WS_HORAS.SII].STT, WS_HORAS.STT_DISP);

                /*" -280- DISPLAY 'PARAGRAFO:' SII ' TOTAL= ' STT-DISP ' QTDE= ' SQT(SII) */

                $"PARAGRAFO:{WS_HORAS.SII} TOTAL= {WS_HORAS.STT_DISP} QTDE= {TOTAIS_ROT.FILLER_6[WS_HORAS.SII]}"
                .Display();

                /*" -281- GO TO M-1100-MOSTRA-TOTAIS. */
                new Task(() => M_1100_MOSTRA_TOTAIS()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -284- DISPLAY ' ' . */
            _.Display($" ");

            /*" -286- DISPLAY '*** CB1264B *** TERMINO NORMAL' . */
            _.Display($"*** CB1264B *** TERMINO NORMAL");

            /*" -288- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -288- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-SECTION */
        private void R0100_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -300- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", WABEND.WNR_EXEC_SQL);

            /*" -302- MOVE 'SELECT-SISTEMAS' TO PARAGRAFO. */
            _.Move("SELECT-SISTEMAS", WABEND.PARAGRAFO);

            /*" -311- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -314- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -315- DISPLAY 'R0100- ERRO SELECT SISTEMAS (CB)' */
                _.Display($"R0100- ERRO SELECT SISTEMAS (CB)");

                /*" -315- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -311- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'CB' END-EXEC. */

            var r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-DECLARE-CBAPOVIG-SECTION */
        private void R0500_00_DECLARE_CBAPOVIG_SECTION()
        {
            /*" -327- MOVE '050' TO WNR-EXEC-SQL. */
            _.Move("050", WABEND.WNR_EXEC_SQL);

            /*" -330- MOVE 'DECLARE-CBAPOVIG' TO PARAGRAFO. */
            _.Move("DECLARE-CBAPOVIG", WABEND.PARAGRAFO);

            /*" -331- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -334- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -345- PERFORM R0500_00_DECLARE_CBAPOVIG_DB_DECLARE_1 */

            R0500_00_DECLARE_CBAPOVIG_DB_DECLARE_1();

            /*" -347- PERFORM R0500_00_DECLARE_CBAPOVIG_DB_OPEN_1 */

            R0500_00_DECLARE_CBAPOVIG_DB_OPEN_1();

            /*" -351- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -352- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -353- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -354- ADD SFT TO STT(01) */
            TOTAIS_ROT.FILLER_6[01].STT.Value = TOTAIS_ROT.FILLER_6[01].STT + WS_HORAS.SFT;

            /*" -357- ADD 1 TO SQT(01) */
            TOTAIS_ROT.FILLER_6[01].SQT.Value = TOTAIS_ROT.FILLER_6[01].SQT + 1;

            /*" -358- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -359- DISPLAY 'R0500- ERRO DECLARE CB_APOLICE_VIGPROP' */
                _.Display($"R0500- ERRO DECLARE CB_APOLICE_VIGPROP");

                /*" -359- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0500-00-DECLARE-CBAPOVIG-DB-DECLARE-1 */
        public void R0500_00_DECLARE_CBAPOVIG_DB_DECLARE_1()
        {
            /*" -345- EXEC SQL DECLARE C0CBAPOVIG CURSOR FOR SELECT NUM_APOLICE FROM SEGUROS.CB_APOLICE_VIGPROP WHERE SITUACAO = '0' AND (DATA_CANCELAMENTO + 2 DAYS) <= :SISTEMAS-DATA-MOV-ABERTO ORDER BY NUM_APOLICE END-EXEC. */
            C0CBAPOVIG = new CB1264B_C0CBAPOVIG(true);
            string GetQuery_C0CBAPOVIG()
            {
                var query = @$"SELECT 
							NUM_APOLICE 
							FROM 
							SEGUROS.CB_APOLICE_VIGPROP 
							WHERE 
							SITUACAO = '0' 
							AND (DATA_CANCELAMENTO + 2 DAYS) 
							<= '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							ORDER BY 
							NUM_APOLICE";

                return query;
            }
            C0CBAPOVIG.GetQueryEvent += GetQuery_C0CBAPOVIG;

        }

        [StopWatch]
        /*" R0500-00-DECLARE-CBAPOVIG-DB-OPEN-1 */
        public void R0500_00_DECLARE_CBAPOVIG_DB_OPEN_1()
        {
            /*" -347- EXEC SQL OPEN C0CBAPOVIG END-EXEC. */

            C0CBAPOVIG.Open();

        }

        [StopWatch]
        /*" R2300-00-DECLARE-PARCELAS-DB-DECLARE-1 */
        public void R2300_00_DECLARE_PARCELAS_DB_DECLARE_1()
        {
            /*" -737- EXEC SQL DECLARE C0PARCELAS CURSOR FOR SELECT A.NUM_APOLICE , A.NUM_ENDOSSO, A.NUM_PARCELA, A.DAC_PARCELA, A.HORA_OPERACAO, A.PRM_TARIFARIO, A.VAL_DESCONTO, A.PRM_LIQUIDO, A.ADICIONAL_FRACIO, A.VAL_CUSTO_EMISSAO, A.VAL_IOCC, A.PRM_TOTAL, A.DATA_VENCIMENTO, A.BCO_COBRANCA, A.AGE_COBRANCA, B.OCORR_HISTORICO FROM SEGUROS.PARCELA_HISTORICO A, SEGUROS.PARCELAS B WHERE A.NUM_APOLICE = :CBAPOVIG-NUM-APOLICE AND A.OCORR_HISTORICO= 1 AND B.NUM_APOLICE = A.NUM_APOLICE AND B.NUM_ENDOSSO = A.NUM_ENDOSSO AND B.NUM_PARCELA = A.NUM_PARCELA AND B.SIT_REGISTRO = '0' ORDER BY A.NUM_APOLICE , A.NUM_ENDOSSO , A.NUM_PARCELA END-EXEC. */
            C0PARCELAS = new CB1264B_C0PARCELAS(true);
            string GetQuery_C0PARCELAS()
            {
                var query = @$"SELECT 
							A.NUM_APOLICE
							, 
							A.NUM_ENDOSSO
							, 
							A.NUM_PARCELA
							, 
							A.DAC_PARCELA
							, 
							A.HORA_OPERACAO
							, 
							A.PRM_TARIFARIO
							, 
							A.VAL_DESCONTO
							, 
							A.PRM_LIQUIDO
							, 
							A.ADICIONAL_FRACIO
							, 
							A.VAL_CUSTO_EMISSAO
							, 
							A.VAL_IOCC
							, 
							A.PRM_TOTAL
							, 
							A.DATA_VENCIMENTO
							, 
							A.BCO_COBRANCA
							, 
							A.AGE_COBRANCA
							, 
							B.OCORR_HISTORICO 
							FROM 
							SEGUROS.PARCELA_HISTORICO A
							, 
							SEGUROS.PARCELAS B 
							WHERE 
							A.NUM_APOLICE = '{CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_APOLICE}' 
							AND A.OCORR_HISTORICO= 1 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.NUM_ENDOSSO = A.NUM_ENDOSSO 
							AND B.NUM_PARCELA = A.NUM_PARCELA 
							AND B.SIT_REGISTRO = '0' 
							ORDER BY 
							A.NUM_APOLICE
							, 
							A.NUM_ENDOSSO
							, 
							A.NUM_PARCELA";

                return query;
            }
            C0PARCELAS.GetQueryEvent += GetQuery_C0PARCELAS;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0510-00-FETCH-CBAPOVIG-SECTION */
        private void R0510_00_FETCH_CBAPOVIG_SECTION()
        {
            /*" -371- MOVE '051' TO WNR-EXEC-SQL. */
            _.Move("051", WABEND.WNR_EXEC_SQL);

            /*" -374- MOVE 'FETCH-CBAPOVIG' TO PARAGRAFO. */
            _.Move("FETCH-CBAPOVIG", WABEND.PARAGRAFO);

            /*" -375- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -378- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -381- PERFORM R0510_00_FETCH_CBAPOVIG_DB_FETCH_1 */

            R0510_00_FETCH_CBAPOVIG_DB_FETCH_1();

            /*" -385- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -386- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -387- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -388- ADD SFT TO STT(02) */
            TOTAIS_ROT.FILLER_6[02].STT.Value = TOTAIS_ROT.FILLER_6[02].STT + WS_HORAS.SFT;

            /*" -391- ADD 1 TO SQT(02) */
            TOTAIS_ROT.FILLER_6[02].SQT.Value = TOTAIS_ROT.FILLER_6[02].SQT + 1;

            /*" -392- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -393- IF SQLCODE = 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -394- MOVE 'S' TO WS-FIM-CBAPOVIG */
                    _.Move("S", AREA_DE_WORK.WS_FIM_CBAPOVIG);

                    /*" -394- PERFORM R0510_00_FETCH_CBAPOVIG_DB_CLOSE_1 */

                    R0510_00_FETCH_CBAPOVIG_DB_CLOSE_1();

                    /*" -396- GO TO R0510-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_99_SAIDA*/ //GOTO
                    return;

                    /*" -397- ELSE */
                }
                else
                {


                    /*" -398- DISPLAY 'R0510- ERRO FETCH CB_APOLICE_VIGPROP' */
                    _.Display($"R0510- ERRO FETCH CB_APOLICE_VIGPROP");

                    /*" -400- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -400- ADD 1 TO AC-L-CBAPOVIG. */
            AREA_DE_WORK.AC_L_CBAPOVIG.Value = AREA_DE_WORK.AC_L_CBAPOVIG + 1;

        }

        [StopWatch]
        /*" R0510-00-FETCH-CBAPOVIG-DB-FETCH-1 */
        public void R0510_00_FETCH_CBAPOVIG_DB_FETCH_1()
        {
            /*" -381- EXEC SQL FETCH C0CBAPOVIG INTO :CBAPOVIG-NUM-APOLICE END-EXEC. */

            if (C0CBAPOVIG.Fetch())
            {
                _.Move(C0CBAPOVIG.CBAPOVIG_NUM_APOLICE, CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_APOLICE);
            }

        }

        [StopWatch]
        /*" R0510-00-FETCH-CBAPOVIG-DB-CLOSE-1 */
        public void R0510_00_FETCH_CBAPOVIG_DB_CLOSE_1()
        {
            /*" -394- EXEC SQL CLOSE C0CBAPOVIG END-EXEC */

            C0CBAPOVIG.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-CBAPOVIG-SECTION */
        private void R1000_00_PROCESSA_CBAPOVIG_SECTION()
        {
            /*" -413- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", WABEND.WNR_EXEC_SQL);

            /*" -417- MOVE CBAPOVIG-NUM-APOLICE TO WS-NUM-APOLICE-ANT. */
            _.Move(CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_APOLICE, AREA_DE_WORK.WS_NUM_APOLICE_ANT);

            /*" -419- PERFORM R1200-00-SELECT-FOLLOW-UP. */

            R1200_00_SELECT_FOLLOW_UP_SECTION();

            /*" -420- IF WS-HOST-QTD-FOLLOW-UP > ZEROS */

            if (WS_HOST_QTD_FOLLOW_UP > 00)
            {

                /*" -421- DISPLAY 'APOLICE EM FOLLOW-UP = ' CBAPOVIG-NUM-APOLICE */
                _.Display($"APOLICE EM FOLLOW-UP = {CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_APOLICE}");

                /*" -425- GO TO R1000-90-FETCH-CBAPOVIG. */

                R1000_90_FETCH_CBAPOVIG(); //GOTO
                return;
            }


            /*" -426- PERFORM R1100-00-SELECT-SINISTRO. */

            R1100_00_SELECT_SINISTRO_SECTION();

            /*" -427- IF WS-HOST-QTD-SINISTROS > ZEROS */

            if (WS_HOST_QTD_SINISTROS > 00)
            {

                /*" -429- DISPLAY 'APOLICE COM SINISTRO PENDENTE = ' CBAPOVIG-NUM-APOLICE */
                _.Display($"APOLICE COM SINISTRO PENDENTE = {CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_APOLICE}");

                /*" -431- GO TO R1000-90-FETCH-CBAPOVIG. */

                R1000_90_FETCH_CBAPOVIG(); //GOTO
                return;
            }


            /*" -431- PERFORM R2000-00-CANCELAMENTO. */

            R2000_00_CANCELAMENTO_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R1000_90_FETCH_CBAPOVIG */

            R1000_90_FETCH_CBAPOVIG();

        }

        [StopWatch]
        /*" R1000-90-FETCH-CBAPOVIG */
        private void R1000_90_FETCH_CBAPOVIG(bool isPerform = false)
        {
            /*" -440- PERFORM R0510-00-FETCH-CBAPOVIG. */

            R0510_00_FETCH_CBAPOVIG_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-SELECT-SINISTRO-SECTION */
        private void R1100_00_SELECT_SINISTRO_SECTION()
        {
            /*" -454- MOVE '110' TO WNR-EXEC-SQL. */
            _.Move("110", WABEND.WNR_EXEC_SQL);

            /*" -455- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -458- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -468- PERFORM R1100_00_SELECT_SINISTRO_DB_SELECT_1 */

            R1100_00_SELECT_SINISTRO_DB_SELECT_1();

            /*" -472- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -473- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -474- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -475- ADD SFT TO STT(03) */
            TOTAIS_ROT.FILLER_6[03].STT.Value = TOTAIS_ROT.FILLER_6[03].STT + WS_HORAS.SFT;

            /*" -478- ADD 1 TO SQT(03) */
            TOTAIS_ROT.FILLER_6[03].SQT.Value = TOTAIS_ROT.FILLER_6[03].SQT + 1;

            /*" -479- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -480- DISPLAY 'R1100- ERRO SELECT SINISTRO_MESTRE' */
                _.Display($"R1100- ERRO SELECT SINISTRO_MESTRE");

                /*" -481- DISPLAY 'NUM_APOLICE = ' CBAPOVIG-NUM-APOLICE */
                _.Display($"NUM_APOLICE = {CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_APOLICE}");

                /*" -481- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1100-00-SELECT-SINISTRO-DB-SELECT-1 */
        public void R1100_00_SELECT_SINISTRO_DB_SELECT_1()
        {
            /*" -468- EXEC SQL SELECT VALUE(COUNT(*),+0) INTO :WS-HOST-QTD-SINISTROS FROM SEGUROS.SINISTRO_MESTRE WHERE NUM_APOLICE = :CBAPOVIG-NUM-APOLICE AND SIT_REGISTRO = '0' END-EXEC. */

            var r1100_00_SELECT_SINISTRO_DB_SELECT_1_Query1 = new R1100_00_SELECT_SINISTRO_DB_SELECT_1_Query1()
            {
                CBAPOVIG_NUM_APOLICE = CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1100_00_SELECT_SINISTRO_DB_SELECT_1_Query1.Execute(r1100_00_SELECT_SINISTRO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_HOST_QTD_SINISTROS, WS_HOST_QTD_SINISTROS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SELECT-FOLLOW-UP-SECTION */
        private void R1200_00_SELECT_FOLLOW_UP_SECTION()
        {
            /*" -495- MOVE '120' TO WNR-EXEC-SQL. */
            _.Move("120", WABEND.WNR_EXEC_SQL);

            /*" -496- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -499- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -509- PERFORM R1200_00_SELECT_FOLLOW_UP_DB_SELECT_1 */

            R1200_00_SELECT_FOLLOW_UP_DB_SELECT_1();

            /*" -513- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -514- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -515- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -516- ADD SFT TO STT(04) */
            TOTAIS_ROT.FILLER_6[04].STT.Value = TOTAIS_ROT.FILLER_6[04].STT + WS_HORAS.SFT;

            /*" -519- ADD 1 TO SQT(04) */
            TOTAIS_ROT.FILLER_6[04].SQT.Value = TOTAIS_ROT.FILLER_6[04].SQT + 1;

            /*" -520- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -521- DISPLAY 'R1200-00 ERRO SELECT FOLLOW_UP' */
                _.Display($"R1200-00 ERRO SELECT FOLLOW_UP");

                /*" -522- DISPLAY 'NUM_APOLICE = ' CBAPOVIG-NUM-APOLICE */
                _.Display($"NUM_APOLICE = {CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_APOLICE}");

                /*" -522- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1200-00-SELECT-FOLLOW-UP-DB-SELECT-1 */
        public void R1200_00_SELECT_FOLLOW_UP_DB_SELECT_1()
        {
            /*" -509- EXEC SQL SELECT VALUE(COUNT(*),+0) INTO :WS-HOST-QTD-FOLLOW-UP FROM SEGUROS.FOLLOW_UP WHERE NUM_APOLICE = :CBAPOVIG-NUM-APOLICE AND SIT_REGISTRO = '0' END-EXEC. */

            var r1200_00_SELECT_FOLLOW_UP_DB_SELECT_1_Query1 = new R1200_00_SELECT_FOLLOW_UP_DB_SELECT_1_Query1()
            {
                CBAPOVIG_NUM_APOLICE = CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1200_00_SELECT_FOLLOW_UP_DB_SELECT_1_Query1.Execute(r1200_00_SELECT_FOLLOW_UP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_HOST_QTD_FOLLOW_UP, WS_HOST_QTD_FOLLOW_UP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-CANCELAMENTO-SECTION */
        private void R2000_00_CANCELAMENTO_SECTION()
        {
            /*" -535- MOVE '200' TO WNR-EXEC-SQL. */
            _.Move("200", WABEND.WNR_EXEC_SQL);

            /*" -540- PERFORM R2050-00-SELECT-APOLICES. */

            R2050_00_SELECT_APOLICES_SECTION();

            /*" -542- IF APOLICES-ORGAO-EMISSOR EQUAL 100 OR APOLICES-ORGAO-EMISSOR EQUAL 110 */

            if (APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR == 100 || APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR == 110)
            {

                /*" -545- GO R2000-99-SAIDA. */
            }


            /*" -546- IF APOLICES-RAMO-EMISSOR EQUAL 40 OR 45 OR 75 */

            if (APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR.In("40", "45", "75"))
            {

                /*" -548- GO R2000-99-SAIDA. */
            }


            /*" -549- PERFORM R2100-00-SELECT-NUMERO-AES. */

            R2100_00_SELECT_NUMERO_AES_SECTION();

            /*" -550- ADD 1 TO NUMERAES-ENDOS-CANCELA. */
            NUMERAES.DCLNUMERO_AES.NUMERAES_ENDOS_CANCELA.Value = NUMERAES.DCLNUMERO_AES.NUMERAES_ENDOS_CANCELA + 1;

            /*" -552- PERFORM R2200-00-UPDATE-NUMERO-AES. */

            R2200_00_UPDATE_NUMERO_AES_SECTION();

            /*" -554- PERFORM R2300-00-DECLARE-PARCELAS. */

            R2300_00_DECLARE_PARCELAS_SECTION();

            /*" -556- PERFORM R2310-00-FETCH-PARCELAS. */

            R2310_00_FETCH_PARCELAS_SECTION();

            /*" -559- PERFORM R2500-00-PROCESSA-PARCELAS UNTIL WS-FIM-PARCELAS NOT = SPACES. */

            while (!(!AREA_DE_WORK.WS_FIM_PARCELAS.IsEmpty()))
            {

                R2500_00_PROCESSA_PARCELAS_SECTION();
            }

            /*" -561- PERFORM R5000-00-INCLUI-REGISTRO THRU R5000-99-SAIDA. */

            R5000_00_INCLUI_REGISTRO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_99_SAIDA*/


            /*" -561- PERFORM R3400-00-UPDATE-CBAPOVIG. */

            R3400_00_UPDATE_CBAPOVIG_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2050-00-SELECT-APOLICES-SECTION */
        private void R2050_00_SELECT_APOLICES_SECTION()
        {
            /*" -575- MOVE '205' TO WNR-EXEC-SQL. */
            _.Move("205", WABEND.WNR_EXEC_SQL);

            /*" -576- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -579- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -590- PERFORM R2050_00_SELECT_APOLICES_DB_SELECT_1 */

            R2050_00_SELECT_APOLICES_DB_SELECT_1();

            /*" -594- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -595- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -596- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -597- ADD SFT TO STT(05) */
            TOTAIS_ROT.FILLER_6[05].STT.Value = TOTAIS_ROT.FILLER_6[05].STT + WS_HORAS.SFT;

            /*" -600- ADD 1 TO SQT(05) */
            TOTAIS_ROT.FILLER_6[05].SQT.Value = TOTAIS_ROT.FILLER_6[05].SQT + 1;

            /*" -601- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -602- DISPLAY 'R2050-00 - ERRO SELECT APOLICES' */
                _.Display($"R2050-00 - ERRO SELECT APOLICES");

                /*" -603- DISPLAY 'APOLICE = ' CBAPOVIG-NUM-APOLICE */
                _.Display($"APOLICE = {CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_APOLICE}");

                /*" -603- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2050-00-SELECT-APOLICES-DB-SELECT-1 */
        public void R2050_00_SELECT_APOLICES_DB_SELECT_1()
        {
            /*" -590- EXEC SQL SELECT ORGAO_EMISSOR, RAMO_EMISSOR INTO :APOLICES-ORGAO-EMISSOR, :APOLICES-RAMO-EMISSOR FROM SEGUROS.APOLICES WHERE NUM_APOLICE = :CBAPOVIG-NUM-APOLICE END-EXEC. */

            var r2050_00_SELECT_APOLICES_DB_SELECT_1_Query1 = new R2050_00_SELECT_APOLICES_DB_SELECT_1_Query1()
            {
                CBAPOVIG_NUM_APOLICE = CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_APOLICE.ToString(),
            };

            var executed_1 = R2050_00_SELECT_APOLICES_DB_SELECT_1_Query1.Execute(r2050_00_SELECT_APOLICES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICES_ORGAO_EMISSOR, APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR);
                _.Move(executed_1.APOLICES_RAMO_EMISSOR, APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2050_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-SELECT-NUMERO-AES-SECTION */
        private void R2100_00_SELECT_NUMERO_AES_SECTION()
        {
            /*" -617- MOVE '210' TO WNR-EXEC-SQL. */
            _.Move("210", WABEND.WNR_EXEC_SQL);

            /*" -618- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -621- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -631- PERFORM R2100_00_SELECT_NUMERO_AES_DB_SELECT_1 */

            R2100_00_SELECT_NUMERO_AES_DB_SELECT_1();

            /*" -635- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -636- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -637- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -638- ADD SFT TO STT(06) */
            TOTAIS_ROT.FILLER_6[06].STT.Value = TOTAIS_ROT.FILLER_6[06].STT + WS_HORAS.SFT;

            /*" -641- ADD 1 TO SQT(06) */
            TOTAIS_ROT.FILLER_6[06].SQT.Value = TOTAIS_ROT.FILLER_6[06].SQT + 1;

            /*" -642- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -643- DISPLAY 'R2100- ERRO SELECT NUMERO_AES' */
                _.Display($"R2100- ERRO SELECT NUMERO_AES");

                /*" -644- DISPLAY 'APOLICE = ' CBAPOVIG-NUM-APOLICE */
                _.Display($"APOLICE = {CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_APOLICE}");

                /*" -645- DISPLAY 'ORGAO   = ' APOLICES-ORGAO-EMISSOR */
                _.Display($"ORGAO   = {APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR}");

                /*" -646- DISPLAY 'RAMO    = ' APOLICES-RAMO-EMISSOR */
                _.Display($"RAMO    = {APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR}");

                /*" -646- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2100-00-SELECT-NUMERO-AES-DB-SELECT-1 */
        public void R2100_00_SELECT_NUMERO_AES_DB_SELECT_1()
        {
            /*" -631- EXEC SQL SELECT ENDOS_CANCELA INTO :NUMERAES-ENDOS-CANCELA FROM SEGUROS.NUMERO_AES WHERE ORGAO_EMISSOR = :APOLICES-ORGAO-EMISSOR AND RAMO_EMISSOR = :APOLICES-RAMO-EMISSOR END-EXEC. */

            var r2100_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1 = new R2100_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1()
            {
                APOLICES_ORGAO_EMISSOR = APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR.ToString(),
                APOLICES_RAMO_EMISSOR = APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR.ToString(),
            };

            var executed_1 = R2100_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1.Execute(r2100_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUMERAES_ENDOS_CANCELA, NUMERAES.DCLNUMERO_AES.NUMERAES_ENDOS_CANCELA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-UPDATE-NUMERO-AES-SECTION */
        private void R2200_00_UPDATE_NUMERO_AES_SECTION()
        {
            /*" -660- MOVE '220' TO WNR-EXEC-SQL. */
            _.Move("220", WABEND.WNR_EXEC_SQL);

            /*" -661- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -664- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -672- PERFORM R2200_00_UPDATE_NUMERO_AES_DB_UPDATE_1 */

            R2200_00_UPDATE_NUMERO_AES_DB_UPDATE_1();

            /*" -676- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -677- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -678- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -679- ADD SFT TO STT(07) */
            TOTAIS_ROT.FILLER_6[07].STT.Value = TOTAIS_ROT.FILLER_6[07].STT + WS_HORAS.SFT;

            /*" -682- ADD 1 TO SQT(07) */
            TOTAIS_ROT.FILLER_6[07].SQT.Value = TOTAIS_ROT.FILLER_6[07].SQT + 1;

            /*" -683- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -684- DISPLAY 'R2200- ERRO UPDATE NUMERO_AES' */
                _.Display($"R2200- ERRO UPDATE NUMERO_AES");

                /*" -685- DISPLAY 'APOLICE = ' CBAPOVIG-NUM-APOLICE */
                _.Display($"APOLICE = {CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_APOLICE}");

                /*" -686- DISPLAY 'ORGAO   = ' APOLICES-ORGAO-EMISSOR */
                _.Display($"ORGAO   = {APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR}");

                /*" -687- DISPLAY 'RAMO    = ' APOLICES-RAMO-EMISSOR */
                _.Display($"RAMO    = {APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR}");

                /*" -687- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2200-00-UPDATE-NUMERO-AES-DB-UPDATE-1 */
        public void R2200_00_UPDATE_NUMERO_AES_DB_UPDATE_1()
        {
            /*" -672- EXEC SQL UPDATE SEGUROS.NUMERO_AES SET ENDOS_CANCELA = :NUMERAES-ENDOS-CANCELA, TIMESTAMP = CURRENT TIMESTAMP WHERE ORGAO_EMISSOR = :APOLICES-ORGAO-EMISSOR AND RAMO_EMISSOR = :APOLICES-RAMO-EMISSOR END-EXEC. */

            var r2200_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1 = new R2200_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1()
            {
                NUMERAES_ENDOS_CANCELA = NUMERAES.DCLNUMERO_AES.NUMERAES_ENDOS_CANCELA.ToString(),
                APOLICES_ORGAO_EMISSOR = APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR.ToString(),
                APOLICES_RAMO_EMISSOR = APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR.ToString(),
            };

            R2200_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1.Execute(r2200_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-DECLARE-PARCELAS-SECTION */
        private void R2300_00_DECLARE_PARCELAS_SECTION()
        {
            /*" -701- MOVE '230' TO WNR-EXEC-SQL. */
            _.Move("230", WABEND.WNR_EXEC_SQL);

            /*" -702- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -705- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -737- PERFORM R2300_00_DECLARE_PARCELAS_DB_DECLARE_1 */

            R2300_00_DECLARE_PARCELAS_DB_DECLARE_1();

            /*" -739- PERFORM R2300_00_DECLARE_PARCELAS_DB_OPEN_1 */

            R2300_00_DECLARE_PARCELAS_DB_OPEN_1();

            /*" -743- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -744- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -745- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -746- ADD SFT TO STT(08) */
            TOTAIS_ROT.FILLER_6[08].STT.Value = TOTAIS_ROT.FILLER_6[08].STT + WS_HORAS.SFT;

            /*" -749- ADD 1 TO SQT(08) */
            TOTAIS_ROT.FILLER_6[08].SQT.Value = TOTAIS_ROT.FILLER_6[08].SQT + 1;

            /*" -750- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -751- DISPLAY 'R2300 - ERRO DECLARE PARCELA_HISTORICO/PARCELAS' */
                _.Display($"R2300 - ERRO DECLARE PARCELA_HISTORICO/PARCELAS");

                /*" -752- DISPLAY 'APOLICE = ' CBAPOVIG-NUM-APOLICE */
                _.Display($"APOLICE = {CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_APOLICE}");

                /*" -754- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -754- MOVE SPACES TO WS-FIM-PARCELAS. */
            _.Move("", AREA_DE_WORK.WS_FIM_PARCELAS);

        }

        [StopWatch]
        /*" R2300-00-DECLARE-PARCELAS-DB-OPEN-1 */
        public void R2300_00_DECLARE_PARCELAS_DB_OPEN_1()
        {
            /*" -739- EXEC SQL OPEN C0PARCELAS END-EXEC. */

            C0PARCELAS.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2310-00-FETCH-PARCELAS-SECTION */
        private void R2310_00_FETCH_PARCELAS_SECTION()
        {
            /*" -768- MOVE '231' TO WNR-EXEC-SQL. */
            _.Move("231", WABEND.WNR_EXEC_SQL);

            /*" -769- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -772- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -790- PERFORM R2310_00_FETCH_PARCELAS_DB_FETCH_1 */

            R2310_00_FETCH_PARCELAS_DB_FETCH_1();

            /*" -794- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -795- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -796- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -797- ADD SFT TO STT(09) */
            TOTAIS_ROT.FILLER_6[09].STT.Value = TOTAIS_ROT.FILLER_6[09].STT + WS_HORAS.SFT;

            /*" -800- ADD 1 TO SQT(09) */
            TOTAIS_ROT.FILLER_6[09].SQT.Value = TOTAIS_ROT.FILLER_6[09].SQT + 1;

            /*" -801- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -802- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -803- MOVE 'S' TO WS-FIM-PARCELAS */
                    _.Move("S", AREA_DE_WORK.WS_FIM_PARCELAS);

                    /*" -804- MOVE 9999999999999 TO PARCEHIS-NUM-APOLICE */
                    _.Move(9999999999999, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE);

                    /*" -805- MOVE 999999999 TO PARCEHIS-NUM-ENDOSSO */
                    _.Move(999999999, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO);

                    /*" -805- PERFORM R2310_00_FETCH_PARCELAS_DB_CLOSE_1 */

                    R2310_00_FETCH_PARCELAS_DB_CLOSE_1();

                    /*" -807- GO TO R2310-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2310_99_SAIDA*/ //GOTO
                    return;

                    /*" -808- ELSE */
                }
                else
                {


                    /*" -809- DISPLAY 'R2310 - ERRO FETCH CURSOR C0PARCELAS' */
                    _.Display($"R2310 - ERRO FETCH CURSOR C0PARCELAS");

                    /*" -810- DISPLAY 'APOLICE = ' CBAPOVIG-NUM-APOLICE */
                    _.Display($"APOLICE = {CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_APOLICE}");

                    /*" -810- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2310-00-FETCH-PARCELAS-DB-FETCH-1 */
        public void R2310_00_FETCH_PARCELAS_DB_FETCH_1()
        {
            /*" -790- EXEC SQL FETCH C0PARCELAS INTO :PARCEHIS-NUM-APOLICE , :PARCEHIS-NUM-ENDOSSO, :PARCEHIS-NUM-PARCELA, :PARCEHIS-DAC-PARCELA, :PARCEHIS-HORA-OPERACAO, :PARCEHIS-PRM-TARIFARIO, :PARCEHIS-VAL-DESCONTO, :PARCEHIS-PRM-LIQUIDO, :PARCEHIS-ADICIONAL-FRACIO, :PARCEHIS-VAL-CUSTO-EMISSAO, :PARCEHIS-VAL-IOCC, :PARCEHIS-PRM-TOTAL, :PARCEHIS-DATA-VENCIMENTO, :PARCEHIS-BCO-COBRANCA, :PARCEHIS-AGE-COBRANCA, :PARCELAS-OCORR-HISTORICO END-EXEC. */

            if (C0PARCELAS.Fetch())
            {
                _.Move(C0PARCELAS.PARCEHIS_NUM_APOLICE, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE);
                _.Move(C0PARCELAS.PARCEHIS_NUM_ENDOSSO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO);
                _.Move(C0PARCELAS.PARCEHIS_NUM_PARCELA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA);
                _.Move(C0PARCELAS.PARCEHIS_DAC_PARCELA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DAC_PARCELA);
                _.Move(C0PARCELAS.PARCEHIS_HORA_OPERACAO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_HORA_OPERACAO);
                _.Move(C0PARCELAS.PARCEHIS_PRM_TARIFARIO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TARIFARIO);
                _.Move(C0PARCELAS.PARCEHIS_VAL_DESCONTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_DESCONTO);
                _.Move(C0PARCELAS.PARCEHIS_PRM_LIQUIDO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_LIQUIDO);
                _.Move(C0PARCELAS.PARCEHIS_ADICIONAL_FRACIO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ADICIONAL_FRACIO);
                _.Move(C0PARCELAS.PARCEHIS_VAL_CUSTO_EMISSAO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_CUSTO_EMISSAO);
                _.Move(C0PARCELAS.PARCEHIS_VAL_IOCC, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_IOCC);
                _.Move(C0PARCELAS.PARCEHIS_PRM_TOTAL, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL);
                _.Move(C0PARCELAS.PARCEHIS_DATA_VENCIMENTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO);
                _.Move(C0PARCELAS.PARCEHIS_BCO_COBRANCA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_BCO_COBRANCA);
                _.Move(C0PARCELAS.PARCEHIS_AGE_COBRANCA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_AGE_COBRANCA);
                _.Move(C0PARCELAS.PARCELAS_OCORR_HISTORICO, PARCELAS.DCLPARCELAS.PARCELAS_OCORR_HISTORICO);
            }

        }

        [StopWatch]
        /*" R2310-00-FETCH-PARCELAS-DB-CLOSE-1 */
        public void R2310_00_FETCH_PARCELAS_DB_CLOSE_1()
        {
            /*" -805- EXEC SQL CLOSE C0PARCELAS END-EXEC */

            C0PARCELAS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2310_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-PROCESSA-PARCELAS-SECTION */
        private void R2500_00_PROCESSA_PARCELAS_SECTION()
        {
            /*" -823- MOVE '250' TO WNR-EXEC-SQL. */
            _.Move("250", WABEND.WNR_EXEC_SQL);

            /*" -824- MOVE PARCEHIS-NUM-APOLICE TO WS-NUM-APOLICE. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE, AREA_DE_WORK.WS_NUM_APOLICE);

            /*" -826- MOVE PARCEHIS-NUM-ENDOSSO TO WS-NUM-ENDOSSO. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO, AREA_DE_WORK.WS_NUM_ENDOSSO);

            /*" -831- PERFORM R2600-00-PROCESSA-ENDOSSO UNTIL WS-FIM-PARCELAS NOT = SPACES OR PARCEHIS-NUM-APOLICE NOT = WS-NUM-APOLICE OR PARCEHIS-NUM-ENDOSSO NOT = WS-NUM-ENDOSSO. */

            while (!(!AREA_DE_WORK.WS_FIM_PARCELAS.IsEmpty() || PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE != AREA_DE_WORK.WS_NUM_APOLICE || PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO != AREA_DE_WORK.WS_NUM_ENDOSSO))
            {

                R2600_00_PROCESSA_ENDOSSO_SECTION();
            }

            /*" -832- MOVE WS-NUM-APOLICE TO ENDOSSOS-NUM-APOLICE. */
            _.Move(AREA_DE_WORK.WS_NUM_APOLICE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE);

            /*" -833- MOVE WS-NUM-ENDOSSO TO ENDOSSOS-NUM-ENDOSSO. */
            _.Move(AREA_DE_WORK.WS_NUM_ENDOSSO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);

            /*" -833- PERFORM R3200-00-UPDATE-ENDOSSOS. */

            R3200_00_UPDATE_ENDOSSOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R2600-00-PROCESSA-ENDOSSO-SECTION */
        private void R2600_00_PROCESSA_ENDOSSO_SECTION()
        {
            /*" -846- MOVE '260' TO WNR-EXEC-SQL. */
            _.Move("260", WABEND.WNR_EXEC_SQL);

            /*" -848- PERFORM R2700-00-ACUMULA-CORRECAO. */

            R2700_00_ACUMULA_CORRECAO_SECTION();

            /*" -857- IF WS-CM-PRM-TOTAL EQUAL ZEROS AND WS-CM-PRM-TARIFARIO EQUAL ZEROS AND WS-CM-VAL-DESCONTO EQUAL ZEROS AND WS-CM-PRM-LIQUIDO EQUAL ZEROS AND WS-CM-ADICIONAL-FRACIO EQUAL ZEROS AND WS-CM-VAL-CUSTO-EMISSAO EQUAL ZEROS AND WS-CM-VAL-IOCC EQUAL ZEROS AND WS-CM-PRM-TOTAL EQUAL ZEROS NEXT SENTENCE */

            if (WS_CM_PRM_TOTAL == 00 && WS_CM_PRM_TARIFARIO == 00 && WS_CM_VAL_DESCONTO == 00 && WS_CM_PRM_LIQUIDO == 00 && WS_CM_ADICIONAL_FRACIO == 00 && WS_CM_VAL_CUSTO_EMISSAO == 00 && WS_CM_VAL_IOCC == 00 && WS_CM_PRM_TOTAL == 00)
            {

                /*" -858- ELSE */
            }
            else
            {


                /*" -859- PERFORM R2800-00-MONTA-OP-CORRECAO */

                R2800_00_MONTA_OP_CORRECAO_SECTION();

                /*" -861- PERFORM R3050-00-INSERT-PARCEHIS. */

                R3050_00_INSERT_PARCEHIS_SECTION();
            }


            /*" -863- PERFORM R2900-00-MONTA-OP-CANC. */

            R2900_00_MONTA_OP_CANC_SECTION();

            /*" -865- PERFORM R3000-00-INSERT-PARCEHIS. */

            R3000_00_INSERT_PARCEHIS_SECTION();

            /*" -867- PERFORM R3100-00-UPDATE-PARCELAS. */

            R3100_00_UPDATE_PARCELAS_SECTION();

            /*" -867- PERFORM R2310-00-FETCH-PARCELAS. */

            R2310_00_FETCH_PARCELAS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2600_99_SAIDA*/

        [StopWatch]
        /*" R2700-00-ACUMULA-CORRECAO-SECTION */
        private void R2700_00_ACUMULA_CORRECAO_SECTION()
        {
            /*" -881- MOVE '270' TO WNR-EXEC-SQL. */
            _.Move("270", WABEND.WNR_EXEC_SQL);

            /*" -882- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -885- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -909- PERFORM R2700_00_ACUMULA_CORRECAO_DB_SELECT_1 */

            R2700_00_ACUMULA_CORRECAO_DB_SELECT_1();

            /*" -913- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -914- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -915- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -916- ADD SFT TO STT(10) */
            TOTAIS_ROT.FILLER_6[10].STT.Value = TOTAIS_ROT.FILLER_6[10].STT + WS_HORAS.SFT;

            /*" -919- ADD 1 TO SQT(10) */
            TOTAIS_ROT.FILLER_6[10].SQT.Value = TOTAIS_ROT.FILLER_6[10].SQT + 1;

            /*" -920- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -921- DISPLAY 'R2700- ERRO SELECT SUM CM - PARCELA_HISTORICO' */
                _.Display($"R2700- ERRO SELECT SUM CM - PARCELA_HISTORICO");

                /*" -922- DISPLAY 'APOLICE = ' PARCEHIS-NUM-APOLICE */
                _.Display($"APOLICE = {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                /*" -923- DISPLAY 'ENDOSSO = ' PARCEHIS-NUM-ENDOSSO */
                _.Display($"ENDOSSO = {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                /*" -924- DISPLAY 'PARCELA = ' PARCEHIS-NUM-PARCELA */
                _.Display($"PARCELA = {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}");

                /*" -924- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2700-00-ACUMULA-CORRECAO-DB-SELECT-1 */
        public void R2700_00_ACUMULA_CORRECAO_DB_SELECT_1()
        {
            /*" -909- EXEC SQL SELECT VALUE(SUM(PRM_TARIFARIO),0), VALUE(SUM(VAL_DESCONTO),0), VALUE(SUM(PRM_LIQUIDO),0), VALUE(SUM(ADICIONAL_FRACIO),0), VALUE(SUM(VAL_CUSTO_EMISSAO),0), VALUE(SUM(VAL_IOCC),0), VALUE(SUM(PRM_TOTAL),0) INTO :WS-CM-PRM-TARIFARIO, :WS-CM-VAL-DESCONTO , :WS-CM-PRM-LIQUIDO , :WS-CM-ADICIONAL-FRACIO, :WS-CM-VAL-CUSTO-EMISSAO, :WS-CM-VAL-IOCC, :WS-CM-PRM-TOTAL FROM SEGUROS.PARCELA_HISTORICO WHERE NUM_APOLICE = :PARCEHIS-NUM-APOLICE AND NUM_ENDOSSO = :PARCEHIS-NUM-ENDOSSO AND NUM_PARCELA = :PARCEHIS-NUM-PARCELA AND COD_OPERACAO = 0801 END-EXEC. */

            var r2700_00_ACUMULA_CORRECAO_DB_SELECT_1_Query1 = new R2700_00_ACUMULA_CORRECAO_DB_SELECT_1_Query1()
            {
                PARCEHIS_NUM_APOLICE = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.ToString(),
                PARCEHIS_NUM_ENDOSSO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO.ToString(),
                PARCEHIS_NUM_PARCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA.ToString(),
            };

            var executed_1 = R2700_00_ACUMULA_CORRECAO_DB_SELECT_1_Query1.Execute(r2700_00_ACUMULA_CORRECAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_CM_PRM_TARIFARIO, WS_CM_PRM_TARIFARIO);
                _.Move(executed_1.WS_CM_VAL_DESCONTO, WS_CM_VAL_DESCONTO);
                _.Move(executed_1.WS_CM_PRM_LIQUIDO, WS_CM_PRM_LIQUIDO);
                _.Move(executed_1.WS_CM_ADICIONAL_FRACIO, WS_CM_ADICIONAL_FRACIO);
                _.Move(executed_1.WS_CM_VAL_CUSTO_EMISSAO, WS_CM_VAL_CUSTO_EMISSAO);
                _.Move(executed_1.WS_CM_VAL_IOCC, WS_CM_VAL_IOCC);
                _.Move(executed_1.WS_CM_PRM_TOTAL, WS_CM_PRM_TOTAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2700_99_SAIDA*/

        [StopWatch]
        /*" R2800-00-MONTA-OP-CORRECAO-SECTION */
        private void R2800_00_MONTA_OP_CORRECAO_SECTION()
        {
            /*" -937- MOVE '280' TO WNR-EXEC-SQL. */
            _.Move("280", WABEND.WNR_EXEC_SQL);

            /*" -939- MOVE SISTEMAS-DATA-MOV-ABERTO TO PARCEHIS-DATA-MOVIMENTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO);

            /*" -941- MOVE 0804 TO PARCEHIS-COD-OPERACAO. */
            _.Move(0804, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO);

            /*" -942- ACCEPT WTIME-DAY FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WTIME_DAY);

            /*" -944- MOVE WTIME-DAYR TO PARCEHIS-HORA-OPERACAO. */
            _.Move(AREA_DE_WORK.FILLER_0.WTIME_DAYR, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_HORA_OPERACAO);

            /*" -945- ADD 1 TO PARCELAS-OCORR-HISTORICO. */
            PARCELAS.DCLPARCELAS.PARCELAS_OCORR_HISTORICO.Value = PARCELAS.DCLPARCELAS.PARCELAS_OCORR_HISTORICO + 1;

            /*" -957- MOVE PARCELAS-OCORR-HISTORICO TO PARCEHIS-OCORR-HISTORICO. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_OCORR_HISTORICO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO);

            /*" -959- MOVE 0 TO PARCEHIS-VAL-OPERACAO. */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_OPERACAO);

            /*" -961- MOVE 0 TO PARCEHIS-NUM-AVISO-CREDITO. */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_AVISO_CREDITO);

            /*" -963- MOVE NUMERAES-ENDOS-CANCELA TO PARCEHIS-ENDOS-CANCELA. */
            _.Move(NUMERAES.DCLNUMERO_AES.NUMERAES_ENDOS_CANCELA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ENDOS_CANCELA);

            /*" -964- MOVE '0' TO PARCEHIS-SIT-CONTABIL. */
            _.Move("0", PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_SIT_CONTABIL);

            /*" -965- MOVE 'CB1264B' TO PARCEHIS-COD-USUARIO. */
            _.Move("CB1264B", PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_USUARIO);

            /*" -966- MOVE ZEROS TO PARCEHIS-RENUM-DOCUMENTO. */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_RENUM_DOCUMENTO);

            /*" -967- MOVE -1 TO VIND-DATA-QUITACAO. */
            _.Move(-1, VIND_DATA_QUITACAO);

            /*" -968- MOVE SPACES TO PARCEHIS-DATA-QUITACAO. */
            _.Move("", PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO);

            /*" -970- MOVE ZEROS TO PARCEHIS-COD-EMPRESA. */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_EMPRESA);

            /*" -970- ADD 1 TO AC-C-PARCEHIS. */
            AREA_DE_WORK.AC_C_PARCEHIS.Value = AREA_DE_WORK.AC_C_PARCEHIS + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2800_99_SAIDA*/

        [StopWatch]
        /*" R2900-00-MONTA-OP-CANC-SECTION */
        private void R2900_00_MONTA_OP_CANC_SECTION()
        {
            /*" -983- MOVE '290' TO WNR-EXEC-SQL. */
            _.Move("290", WABEND.WNR_EXEC_SQL);

            /*" -985- MOVE SISTEMAS-DATA-MOV-ABERTO TO PARCEHIS-DATA-MOVIMENTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO);

            /*" -987- MOVE 0401 TO PARCEHIS-COD-OPERACAO. */
            _.Move(0401, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO);

            /*" -988- ACCEPT WTIME-DAY FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WTIME_DAY);

            /*" -990- MOVE WTIME-DAYR TO PARCEHIS-HORA-OPERACAO. */
            _.Move(AREA_DE_WORK.FILLER_0.WTIME_DAYR, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_HORA_OPERACAO);

            /*" -991- ADD 1 TO PARCELAS-OCORR-HISTORICO. */
            PARCELAS.DCLPARCELAS.PARCELAS_OCORR_HISTORICO.Value = PARCELAS.DCLPARCELAS.PARCELAS_OCORR_HISTORICO + 1;

            /*" -993- MOVE PARCELAS-OCORR-HISTORICO TO PARCEHIS-OCORR-HISTORICO. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_OCORR_HISTORICO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO);

            /*" -995- MOVE 0 TO PARCEHIS-VAL-OPERACAO. */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_OPERACAO);

            /*" -997- MOVE ZEROS TO PARCEHIS-NUM-AVISO-CREDITO. */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_AVISO_CREDITO);

            /*" -999- MOVE NUMERAES-ENDOS-CANCELA TO PARCEHIS-ENDOS-CANCELA. */
            _.Move(NUMERAES.DCLNUMERO_AES.NUMERAES_ENDOS_CANCELA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ENDOS_CANCELA);

            /*" -1000- MOVE '0' TO PARCEHIS-SIT-CONTABIL. */
            _.Move("0", PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_SIT_CONTABIL);

            /*" -1001- MOVE 'CB1264B' TO PARCEHIS-COD-USUARIO. */
            _.Move("CB1264B", PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_USUARIO);

            /*" -1002- MOVE ZEROS TO PARCEHIS-RENUM-DOCUMENTO. */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_RENUM_DOCUMENTO);

            /*" -1003- MOVE -1 TO VIND-DATA-QUITACAO. */
            _.Move(-1, VIND_DATA_QUITACAO);

            /*" -1004- MOVE SPACES TO PARCEHIS-DATA-QUITACAO. */
            _.Move("", PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO);

            /*" -1006- MOVE ZEROS TO PARCEHIS-COD-EMPRESA. */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_EMPRESA);

            /*" -1006- ADD 1 TO AC-P-PARCEHIS. */
            AREA_DE_WORK.AC_P_PARCEHIS.Value = AREA_DE_WORK.AC_P_PARCEHIS + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2900_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-INSERT-PARCEHIS-SECTION */
        private void R3000_00_INSERT_PARCEHIS_SECTION()
        {
            /*" -1020- MOVE '300' TO WNR-EXEC-SQL. */
            _.Move("300", WABEND.WNR_EXEC_SQL);

            /*" -1021- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -1024- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -1081- PERFORM R3000_00_INSERT_PARCEHIS_DB_INSERT_1 */

            R3000_00_INSERT_PARCEHIS_DB_INSERT_1();

            /*" -1085- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -1086- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -1087- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -1088- ADD SFT TO STT(11) */
            TOTAIS_ROT.FILLER_6[11].STT.Value = TOTAIS_ROT.FILLER_6[11].STT + WS_HORAS.SFT;

            /*" -1091- ADD 1 TO SQT(11) */
            TOTAIS_ROT.FILLER_6[11].SQT.Value = TOTAIS_ROT.FILLER_6[11].SQT + 1;

            /*" -1092- IF SQLCODE NOT = ZEROS AND -803 */

            if (!DB.SQLCODE.In("00", "-803"))
            {

                /*" -1093- DISPLAY 'R3000- ERRO INSERT PARCELA_HISTORICO' */
                _.Display($"R3000- ERRO INSERT PARCELA_HISTORICO");

                /*" -1094- DISPLAY 'APOLICE = ' PARCEHIS-NUM-APOLICE */
                _.Display($"APOLICE = {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                /*" -1095- DISPLAY 'ENDOSSO = ' PARCEHIS-NUM-ENDOSSO */
                _.Display($"ENDOSSO = {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                /*" -1096- DISPLAY 'PARCELA = ' PARCEHIS-NUM-PARCELA */
                _.Display($"PARCELA = {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}");

                /*" -1096- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3000-00-INSERT-PARCEHIS-DB-INSERT-1 */
        public void R3000_00_INSERT_PARCEHIS_DB_INSERT_1()
        {
            /*" -1081- EXEC SQL INSERT INTO SEGUROS.PARCELA_HISTORICO (NUM_APOLICE , NUM_ENDOSSO, NUM_PARCELA, DAC_PARCELA, DATA_MOVIMENTO, COD_OPERACAO, HORA_OPERACAO, OCORR_HISTORICO, PRM_TARIFARIO, VAL_DESCONTO, PRM_LIQUIDO, ADICIONAL_FRACIO, VAL_CUSTO_EMISSAO, VAL_IOCC, PRM_TOTAL, VAL_OPERACAO, DATA_VENCIMENTO, BCO_COBRANCA, AGE_COBRANCA, NUM_AVISO_CREDITO, ENDOS_CANCELA, SIT_CONTABIL, COD_USUARIO, RENUM_DOCUMENTO, DATA_QUITACAO, COD_EMPRESA, TIMESTAMP) VALUES (:PARCEHIS-NUM-APOLICE , :PARCEHIS-NUM-ENDOSSO, :PARCEHIS-NUM-PARCELA, :PARCEHIS-DAC-PARCELA, :PARCEHIS-DATA-MOVIMENTO, :PARCEHIS-COD-OPERACAO, :PARCEHIS-HORA-OPERACAO, :PARCEHIS-OCORR-HISTORICO, :PARCEHIS-PRM-TARIFARIO, :PARCEHIS-VAL-DESCONTO, :PARCEHIS-PRM-LIQUIDO, :PARCEHIS-ADICIONAL-FRACIO, :PARCEHIS-VAL-CUSTO-EMISSAO, :PARCEHIS-VAL-IOCC, :PARCEHIS-PRM-TOTAL, :PARCEHIS-VAL-OPERACAO, :PARCEHIS-DATA-VENCIMENTO, :PARCEHIS-BCO-COBRANCA, :PARCEHIS-AGE-COBRANCA, :PARCEHIS-NUM-AVISO-CREDITO, :PARCEHIS-ENDOS-CANCELA, :PARCEHIS-SIT-CONTABIL, :PARCEHIS-COD-USUARIO, :PARCEHIS-RENUM-DOCUMENTO, :PARCEHIS-DATA-QUITACAO:VIND-DATA-QUITACAO, :PARCEHIS-COD-EMPRESA, CURRENT TIMESTAMP) END-EXEC. */

            var r3000_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1 = new R3000_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1()
            {
                PARCEHIS_NUM_APOLICE = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.ToString(),
                PARCEHIS_NUM_ENDOSSO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO.ToString(),
                PARCEHIS_NUM_PARCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA.ToString(),
                PARCEHIS_DAC_PARCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DAC_PARCELA.ToString(),
                PARCEHIS_DATA_MOVIMENTO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO.ToString(),
                PARCEHIS_COD_OPERACAO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO.ToString(),
                PARCEHIS_HORA_OPERACAO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_HORA_OPERACAO.ToString(),
                PARCEHIS_OCORR_HISTORICO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO.ToString(),
                PARCEHIS_PRM_TARIFARIO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TARIFARIO.ToString(),
                PARCEHIS_VAL_DESCONTO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_DESCONTO.ToString(),
                PARCEHIS_PRM_LIQUIDO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_LIQUIDO.ToString(),
                PARCEHIS_ADICIONAL_FRACIO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ADICIONAL_FRACIO.ToString(),
                PARCEHIS_VAL_CUSTO_EMISSAO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_CUSTO_EMISSAO.ToString(),
                PARCEHIS_VAL_IOCC = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_IOCC.ToString(),
                PARCEHIS_PRM_TOTAL = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL.ToString(),
                PARCEHIS_VAL_OPERACAO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_OPERACAO.ToString(),
                PARCEHIS_DATA_VENCIMENTO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO.ToString(),
                PARCEHIS_BCO_COBRANCA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_BCO_COBRANCA.ToString(),
                PARCEHIS_AGE_COBRANCA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_AGE_COBRANCA.ToString(),
                PARCEHIS_NUM_AVISO_CREDITO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_AVISO_CREDITO.ToString(),
                PARCEHIS_ENDOS_CANCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ENDOS_CANCELA.ToString(),
                PARCEHIS_SIT_CONTABIL = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_SIT_CONTABIL.ToString(),
                PARCEHIS_COD_USUARIO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_USUARIO.ToString(),
                PARCEHIS_RENUM_DOCUMENTO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_RENUM_DOCUMENTO.ToString(),
                PARCEHIS_DATA_QUITACAO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO.ToString(),
                VIND_DATA_QUITACAO = VIND_DATA_QUITACAO.ToString(),
                PARCEHIS_COD_EMPRESA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_EMPRESA.ToString(),
            };

            R3000_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1.Execute(r3000_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3050-00-INSERT-PARCEHIS-SECTION */
        private void R3050_00_INSERT_PARCEHIS_SECTION()
        {
            /*" -1110- MOVE '305' TO WNR-EXEC-SQL. */
            _.Move("305", WABEND.WNR_EXEC_SQL);

            /*" -1111- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -1114- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -1171- PERFORM R3050_00_INSERT_PARCEHIS_DB_INSERT_1 */

            R3050_00_INSERT_PARCEHIS_DB_INSERT_1();

            /*" -1175- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -1176- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -1177- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -1178- ADD SFT TO STT(11) */
            TOTAIS_ROT.FILLER_6[11].STT.Value = TOTAIS_ROT.FILLER_6[11].STT + WS_HORAS.SFT;

            /*" -1181- ADD 1 TO SQT(11) */
            TOTAIS_ROT.FILLER_6[11].SQT.Value = TOTAIS_ROT.FILLER_6[11].SQT + 1;

            /*" -1182- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1183- DISPLAY 'R3050- ERRO INSERT PARCELA_HISTORICO' */
                _.Display($"R3050- ERRO INSERT PARCELA_HISTORICO");

                /*" -1184- DISPLAY 'APOLICE = ' PARCEHIS-NUM-APOLICE */
                _.Display($"APOLICE = {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                /*" -1185- DISPLAY 'ENDOSSO = ' PARCEHIS-NUM-ENDOSSO */
                _.Display($"ENDOSSO = {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                /*" -1186- DISPLAY 'PARCELA = ' PARCEHIS-NUM-PARCELA */
                _.Display($"PARCELA = {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}");

                /*" -1187- DISPLAY PARCEHIS-DAC-PARCELA */
                _.Display(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DAC_PARCELA);

                /*" -1188- DISPLAY PARCEHIS-DATA-MOVIMENTO */
                _.Display(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO);

                /*" -1189- DISPLAY PARCEHIS-COD-OPERACAO */
                _.Display(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO);

                /*" -1190- DISPLAY PARCEHIS-HORA-OPERACAO */
                _.Display(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_HORA_OPERACAO);

                /*" -1191- DISPLAY PARCEHIS-OCORR-HISTORICO */
                _.Display(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO);

                /*" -1192- DISPLAY WS-CM-PRM-TARIFARIO */
                _.Display(WS_CM_PRM_TARIFARIO);

                /*" -1193- DISPLAY WS-CM-VAL-DESCONTO */
                _.Display(WS_CM_VAL_DESCONTO);

                /*" -1194- DISPLAY WS-CM-PRM-LIQUIDO */
                _.Display(WS_CM_PRM_LIQUIDO);

                /*" -1195- DISPLAY WS-CM-ADICIONAL-FRACIO */
                _.Display(WS_CM_ADICIONAL_FRACIO);

                /*" -1196- DISPLAY WS-CM-VAL-CUSTO-EMISSAO */
                _.Display(WS_CM_VAL_CUSTO_EMISSAO);

                /*" -1197- DISPLAY WS-CM-VAL-IOCC */
                _.Display(WS_CM_VAL_IOCC);

                /*" -1198- DISPLAY WS-CM-PRM-TOTAL */
                _.Display(WS_CM_PRM_TOTAL);

                /*" -1199- DISPLAY PARCEHIS-VAL-OPERACAO */
                _.Display(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_OPERACAO);

                /*" -1200- DISPLAY PARCEHIS-DATA-VENCIMENTO */
                _.Display(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO);

                /*" -1201- DISPLAY PARCEHIS-BCO-COBRANCA */
                _.Display(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_BCO_COBRANCA);

                /*" -1202- DISPLAY PARCEHIS-AGE-COBRANCA */
                _.Display(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_AGE_COBRANCA);

                /*" -1203- DISPLAY PARCEHIS-NUM-AVISO-CREDITO */
                _.Display(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_AVISO_CREDITO);

                /*" -1204- DISPLAY PARCEHIS-ENDOS-CANCELA */
                _.Display(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ENDOS_CANCELA);

                /*" -1205- DISPLAY PARCEHIS-SIT-CONTABIL */
                _.Display(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_SIT_CONTABIL);

                /*" -1206- DISPLAY PARCEHIS-COD-USUARIO */
                _.Display(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_USUARIO);

                /*" -1207- DISPLAY PARCEHIS-RENUM-DOCUMENTO */
                _.Display(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_RENUM_DOCUMENTO);

                /*" -1208- DISPLAY PARCEHIS-DATA-QUITACAO */
                _.Display(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO);

                /*" -1209- DISPLAY VIND-DATA-QUITACAO */
                _.Display(VIND_DATA_QUITACAO);

                /*" -1210- DISPLAY PARCEHIS-COD-EMPRESA */
                _.Display(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_EMPRESA);

                /*" -1210- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3050-00-INSERT-PARCEHIS-DB-INSERT-1 */
        public void R3050_00_INSERT_PARCEHIS_DB_INSERT_1()
        {
            /*" -1171- EXEC SQL INSERT INTO SEGUROS.PARCELA_HISTORICO (NUM_APOLICE , NUM_ENDOSSO, NUM_PARCELA, DAC_PARCELA, DATA_MOVIMENTO, COD_OPERACAO, HORA_OPERACAO, OCORR_HISTORICO, PRM_TARIFARIO, VAL_DESCONTO, PRM_LIQUIDO, ADICIONAL_FRACIO, VAL_CUSTO_EMISSAO, VAL_IOCC, PRM_TOTAL, VAL_OPERACAO, DATA_VENCIMENTO, BCO_COBRANCA, AGE_COBRANCA, NUM_AVISO_CREDITO, ENDOS_CANCELA, SIT_CONTABIL, COD_USUARIO, RENUM_DOCUMENTO, DATA_QUITACAO, COD_EMPRESA, TIMESTAMP) VALUES (:PARCEHIS-NUM-APOLICE , :PARCEHIS-NUM-ENDOSSO, :PARCEHIS-NUM-PARCELA, :PARCEHIS-DAC-PARCELA, :PARCEHIS-DATA-MOVIMENTO, :PARCEHIS-COD-OPERACAO, :PARCEHIS-HORA-OPERACAO, :PARCEHIS-OCORR-HISTORICO, :WS-CM-PRM-TARIFARIO, :WS-CM-VAL-DESCONTO , :WS-CM-PRM-LIQUIDO , :WS-CM-ADICIONAL-FRACIO, :WS-CM-VAL-CUSTO-EMISSAO, :WS-CM-VAL-IOCC, :WS-CM-PRM-TOTAL, :PARCEHIS-VAL-OPERACAO, :PARCEHIS-DATA-VENCIMENTO, :PARCEHIS-BCO-COBRANCA, :PARCEHIS-AGE-COBRANCA, :PARCEHIS-NUM-AVISO-CREDITO, :PARCEHIS-ENDOS-CANCELA, :PARCEHIS-SIT-CONTABIL, :PARCEHIS-COD-USUARIO, :PARCEHIS-RENUM-DOCUMENTO, :PARCEHIS-DATA-QUITACAO:VIND-DATA-QUITACAO, :PARCEHIS-COD-EMPRESA, CURRENT TIMESTAMP) END-EXEC. */

            var r3050_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1 = new R3050_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1()
            {
                PARCEHIS_NUM_APOLICE = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.ToString(),
                PARCEHIS_NUM_ENDOSSO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO.ToString(),
                PARCEHIS_NUM_PARCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA.ToString(),
                PARCEHIS_DAC_PARCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DAC_PARCELA.ToString(),
                PARCEHIS_DATA_MOVIMENTO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO.ToString(),
                PARCEHIS_COD_OPERACAO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO.ToString(),
                PARCEHIS_HORA_OPERACAO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_HORA_OPERACAO.ToString(),
                PARCEHIS_OCORR_HISTORICO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO.ToString(),
                WS_CM_PRM_TARIFARIO = WS_CM_PRM_TARIFARIO.ToString(),
                WS_CM_VAL_DESCONTO = WS_CM_VAL_DESCONTO.ToString(),
                WS_CM_PRM_LIQUIDO = WS_CM_PRM_LIQUIDO.ToString(),
                WS_CM_ADICIONAL_FRACIO = WS_CM_ADICIONAL_FRACIO.ToString(),
                WS_CM_VAL_CUSTO_EMISSAO = WS_CM_VAL_CUSTO_EMISSAO.ToString(),
                WS_CM_VAL_IOCC = WS_CM_VAL_IOCC.ToString(),
                WS_CM_PRM_TOTAL = WS_CM_PRM_TOTAL.ToString(),
                PARCEHIS_VAL_OPERACAO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_OPERACAO.ToString(),
                PARCEHIS_DATA_VENCIMENTO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO.ToString(),
                PARCEHIS_BCO_COBRANCA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_BCO_COBRANCA.ToString(),
                PARCEHIS_AGE_COBRANCA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_AGE_COBRANCA.ToString(),
                PARCEHIS_NUM_AVISO_CREDITO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_AVISO_CREDITO.ToString(),
                PARCEHIS_ENDOS_CANCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ENDOS_CANCELA.ToString(),
                PARCEHIS_SIT_CONTABIL = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_SIT_CONTABIL.ToString(),
                PARCEHIS_COD_USUARIO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_USUARIO.ToString(),
                PARCEHIS_RENUM_DOCUMENTO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_RENUM_DOCUMENTO.ToString(),
                PARCEHIS_DATA_QUITACAO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO.ToString(),
                VIND_DATA_QUITACAO = VIND_DATA_QUITACAO.ToString(),
                PARCEHIS_COD_EMPRESA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_EMPRESA.ToString(),
            };

            R3050_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1.Execute(r3050_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3050_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-UPDATE-PARCELAS-SECTION */
        private void R3100_00_UPDATE_PARCELAS_SECTION()
        {
            /*" -1224- MOVE '310' TO WNR-EXEC-SQL. */
            _.Move("310", WABEND.WNR_EXEC_SQL);

            /*" -1225- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -1228- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -1238- PERFORM R3100_00_UPDATE_PARCELAS_DB_UPDATE_1 */

            R3100_00_UPDATE_PARCELAS_DB_UPDATE_1();

            /*" -1242- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -1243- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -1244- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -1245- ADD SFT TO STT(12) */
            TOTAIS_ROT.FILLER_6[12].STT.Value = TOTAIS_ROT.FILLER_6[12].STT + WS_HORAS.SFT;

            /*" -1248- ADD 1 TO SQT(12) */
            TOTAIS_ROT.FILLER_6[12].SQT.Value = TOTAIS_ROT.FILLER_6[12].SQT + 1;

            /*" -1249- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1250- DISPLAY 'R3100- ERRO UPDATE PARCELAS' */
                _.Display($"R3100- ERRO UPDATE PARCELAS");

                /*" -1251- DISPLAY 'APOLICE = ' PARCEHIS-NUM-APOLICE */
                _.Display($"APOLICE = {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                /*" -1252- DISPLAY 'ENDOSSO = ' PARCEHIS-NUM-ENDOSSO */
                _.Display($"ENDOSSO = {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                /*" -1253- DISPLAY 'PARCELA = ' PARCEHIS-NUM-PARCELA */
                _.Display($"PARCELA = {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}");

                /*" -1255- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1255- ADD 1 TO AC-U-PARCELAS. */
            AREA_DE_WORK.AC_U_PARCELAS.Value = AREA_DE_WORK.AC_U_PARCELAS + 1;

        }

        [StopWatch]
        /*" R3100-00-UPDATE-PARCELAS-DB-UPDATE-1 */
        public void R3100_00_UPDATE_PARCELAS_DB_UPDATE_1()
        {
            /*" -1238- EXEC SQL UPDATE SEGUROS.PARCELAS SET OCORR_HISTORICO = :PARCELAS-OCORR-HISTORICO, SIT_REGISTRO = '2' , TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_APOLICE = :PARCEHIS-NUM-APOLICE AND NUM_ENDOSSO = :PARCEHIS-NUM-ENDOSSO AND NUM_PARCELA = :PARCEHIS-NUM-PARCELA END-EXEC. */

            var r3100_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1 = new R3100_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1()
            {
                PARCELAS_OCORR_HISTORICO = PARCELAS.DCLPARCELAS.PARCELAS_OCORR_HISTORICO.ToString(),
                PARCEHIS_NUM_APOLICE = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.ToString(),
                PARCEHIS_NUM_ENDOSSO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO.ToString(),
                PARCEHIS_NUM_PARCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA.ToString(),
            };

            R3100_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1.Execute(r3100_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R3200-00-UPDATE-ENDOSSOS-SECTION */
        private void R3200_00_UPDATE_ENDOSSOS_SECTION()
        {
            /*" -1268- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -1271- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -1273- MOVE '320' TO WNR-EXEC-SQL. */
            _.Move("320", WABEND.WNR_EXEC_SQL);

            /*" -1281- PERFORM R3200_00_UPDATE_ENDOSSOS_DB_UPDATE_1 */

            R3200_00_UPDATE_ENDOSSOS_DB_UPDATE_1();

            /*" -1285- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -1286- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -1287- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -1288- ADD SFT TO STT(13) */
            TOTAIS_ROT.FILLER_6[13].STT.Value = TOTAIS_ROT.FILLER_6[13].STT + WS_HORAS.SFT;

            /*" -1291- ADD 1 TO SQT(13) */
            TOTAIS_ROT.FILLER_6[13].SQT.Value = TOTAIS_ROT.FILLER_6[13].SQT + 1;

            /*" -1292- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1293- DISPLAY 'R3200- ERRO UPDATE ENDOSSOS' */
                _.Display($"R3200- ERRO UPDATE ENDOSSOS");

                /*" -1294- DISPLAY 'APOLICE = ' ENDOSSOS-NUM-APOLICE */
                _.Display($"APOLICE = {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE}");

                /*" -1295- DISPLAY 'ENDOSSO = ' ENDOSSOS-NUM-ENDOSSO */
                _.Display($"ENDOSSO = {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO}");

                /*" -1297- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1297- ADD +1 TO AC-U-ENDOSSOS. */
            AREA_DE_WORK.AC_U_ENDOSSOS.Value = AREA_DE_WORK.AC_U_ENDOSSOS + +1;

        }

        [StopWatch]
        /*" R3200-00-UPDATE-ENDOSSOS-DB-UPDATE-1 */
        public void R3200_00_UPDATE_ENDOSSOS_DB_UPDATE_1()
        {
            /*" -1281- EXEC SQL UPDATE SEGUROS.ENDOSSOS SET SIT_REGISTRO = '2' , TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE AND NUM_ENDOSSO = :ENDOSSOS-NUM-ENDOSSO END-EXEC. */

            var r3200_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1 = new R3200_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1()
            {
                ENDOSSOS_NUM_APOLICE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.ToString(),
                ENDOSSOS_NUM_ENDOSSO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO.ToString(),
            };

            R3200_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1.Execute(r3200_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/

        [StopWatch]
        /*" R3400-00-UPDATE-CBAPOVIG-SECTION */
        private void R3400_00_UPDATE_CBAPOVIG_SECTION()
        {
            /*" -1311- MOVE '340' TO WNR-EXEC-SQL. */
            _.Move("340", WABEND.WNR_EXEC_SQL);

            /*" -1312- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -1315- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -1323- PERFORM R3400_00_UPDATE_CBAPOVIG_DB_UPDATE_1 */

            R3400_00_UPDATE_CBAPOVIG_DB_UPDATE_1();

            /*" -1327- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -1328- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -1329- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -1330- ADD SFT TO STT(14) */
            TOTAIS_ROT.FILLER_6[14].STT.Value = TOTAIS_ROT.FILLER_6[14].STT + WS_HORAS.SFT;

            /*" -1333- ADD 1 TO SQT(14) */
            TOTAIS_ROT.FILLER_6[14].SQT.Value = TOTAIS_ROT.FILLER_6[14].SQT + 1;

            /*" -1334- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1335- DISPLAY 'R3400- ERRO UPDATE CB_APOLICE_VIGPROP' */
                _.Display($"R3400- ERRO UPDATE CB_APOLICE_VIGPROP");

                /*" -1336- DISPLAY 'APOLICE = ' CBAPOVIG-NUM-APOLICE */
                _.Display($"APOLICE = {CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_APOLICE}");

                /*" -1338- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1338- ADD 1 TO AC-U-CBAPOVIG. */
            AREA_DE_WORK.AC_U_CBAPOVIG.Value = AREA_DE_WORK.AC_U_CBAPOVIG + 1;

        }

        [StopWatch]
        /*" R3400-00-UPDATE-CBAPOVIG-DB-UPDATE-1 */
        public void R3400_00_UPDATE_CBAPOVIG_DB_UPDATE_1()
        {
            /*" -1323- EXEC SQL UPDATE SEGUROS.CB_APOLICE_VIGPROP SET SITUACAO = '1' , DATA_CANCELAMENTO = :SISTEMAS-DATA-MOV-ABERTO WHERE NUM_APOLICE = :CBAPOVIG-NUM-APOLICE END-EXEC. */

            var r3400_00_UPDATE_CBAPOVIG_DB_UPDATE_1_Update1 = new R3400_00_UPDATE_CBAPOVIG_DB_UPDATE_1_Update1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                CBAPOVIG_NUM_APOLICE = CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_APOLICE.ToString(),
            };

            R3400_00_UPDATE_CBAPOVIG_DB_UPDATE_1_Update1.Execute(r3400_00_UPDATE_CBAPOVIG_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3400_99_SAIDA*/

        [StopWatch]
        /*" R5000-00-INCLUI-REGISTRO-SECTION */
        private void R5000_00_INCLUI_REGISTRO_SECTION()
        {
            /*" -1350- MOVE '5000' TO WNR-EXEC-SQL. */
            _.Move("5000", WABEND.WNR_EXEC_SQL);

            /*" -1378- PERFORM R5000_00_INCLUI_REGISTRO_DB_INSERT_1 */

            R5000_00_INCLUI_REGISTRO_DB_INSERT_1();

            /*" -1381- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1382- DISPLAY 'R5000-00 - INCLUI REGISTRO DE EXCLUSAO' */
                _.Display($"R5000-00 - INCLUI REGISTRO DE EXCLUSAO");

                /*" -1383- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -1385- END-IF. */
            }


            /*" -1385- ADD 1 TO AC-P-AU2060B3. */
            AREA_DE_WORK.AC_P_AU2060B3.Value = AREA_DE_WORK.AC_P_AU2060B3 + 1;

        }

        [StopWatch]
        /*" R5000-00-INCLUI-REGISTRO-DB-INSERT-1 */
        public void R5000_00_INCLUI_REGISTRO_DB_INSERT_1()
        {
            /*" -1378- EXEC SQL INSERT INTO SEGUROS.EMISSAO_DIARIA ( COD_RELATORIO , NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , DATA_MOVIMENTO , ORGAO_EMISSOR , RAMO_EMISSOR , COD_FONTE , COD_CONGENERE , COD_CORRETOR , SIT_REGISTRO , COD_EMPRESA , TIMESTAMP) VALUES ( 'AU2060B3' , :CBAPOVIG-NUM-APOLICE , :CBAPOVIG-NUM-ENDOSSO , 0 , :SISTEMAS-DATA-MOV-ABERTO , 0 , :APOLICES-RAMO-EMISSOR , :ENDOSSOS-COD-FONTE , 0 , 0 , 0 , 0 , CURRENT TIMESTAMP) END-EXEC. */

            var r5000_00_INCLUI_REGISTRO_DB_INSERT_1_Insert1 = new R5000_00_INCLUI_REGISTRO_DB_INSERT_1_Insert1()
            {
                CBAPOVIG_NUM_APOLICE = CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_APOLICE.ToString(),
                CBAPOVIG_NUM_ENDOSSO = CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_ENDOSSO.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                APOLICES_RAMO_EMISSOR = APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR.ToString(),
                ENDOSSOS_COD_FONTE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE.ToString(),
            };

            R5000_00_INCLUI_REGISTRO_DB_INSERT_1_Insert1.Execute(r5000_00_INCLUI_REGISTRO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-ENCERRA-SEM-MOVTO-SECTION */
        private void R9000_00_ENCERRA_SEM_MOVTO_SECTION()
        {
            /*" -1396- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -1397- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1398- DISPLAY '*  CB1264B - CANCELAMENTO AUTOMATICO       *' */
            _.Display($"*  CB1264B - CANCELAMENTO AUTOMATICO       *");

            /*" -1399- DISPLAY '*  -------   ------------ ----------       *' */
            _.Display($"*  -------   ------------ ----------       *");

            /*" -1400- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1401- DISPLAY '*   NAO HOUVE MOVIMENTACAO NESTA DATA      *' */
            _.Display($"*   NAO HOUVE MOVIMENTACAO NESTA DATA      *");

            /*" -1402- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1402- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1416- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -1418- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -1418- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1422- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1422- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}