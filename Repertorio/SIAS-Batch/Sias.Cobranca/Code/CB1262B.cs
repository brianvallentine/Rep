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
using Sias.Cobranca.DB2.CB1262B;

namespace Code
{
    public class CB1262B
    {
        public bool IsCall { get; set; }

        public CB1262B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  COBRANCA                           *      */
        /*"      *   PROGRAMA ...............  CB1262B                            *      */
        /*"      *   ANALISTA / PROGRAMADOR..  CARLOS ALBERTO DE A ALVES          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO ................. -VERIFICA A MOVIMENTACAO NO SIAS    *      */
        /*"      *                             DAS PARCELAS QUE ESTEJAM CADASTRADAS      */
        /*"      *                             NAS TABELAS CB_APOLICE_VIGPROP    E*      */
        /*"      *                             CB_MALA_PARCATRASO PARA ATUALIZACAO*      */
        /*"      *                             DOS CAMPOS DE SITUACAO.            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO .............. -CADMUS 44951             V.01      *      */
        /*"      *                             CLOVIS                             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO .............. -CADMUS 64639             V.02      *      */
        /*"      *                             CLOVIS                             *      */
        /*"V.02  * PROPOSTA DE SOLU��O                                            *      */
        /*"V.02  * EFETUAR ALTERA��O NA REGRA DE COBRAN�A, D�BITO EM CONTA,       *      */
        /*"V.02  * CONFORME OS CRIT�RIOS ABAIXO:                                  *      */
        /*"V.02  * QUANDO � REALIZADA UMA COBRAN�A VIA DEBITO EM CONTA E          *      */
        /*"V.02  * RETORNA COM REJEI��O, AUTOMATICAMENTE O SISTEMA SUSPENDE       *      */
        /*"V.02  * AS DEMAIS PARCELAS.                                            *      */
        /*"V.02  * ALTERA��O:                                                     *      */
        /*"V.02  * CASO O SEGURADO PAGUE ESSA PARCELA ATRASADA PR�XIMA OU         *      */
        /*"V.02  * AP�S O VENCIMENTO DA PARCELA SEGUINTE A VENCER OU J�           *      */
        /*"V.02  * VENCIDA, O SISTEMA DEVE BAIXAR A PARCELA QUE EST� SENDO        *      */
        /*"V.02  * QUITADA E TIRAR A SUSPENS�O DAS DEMAIS ALTERANDO PARA          *      */
        /*"V.02  * PENDENTE, RETORNANDO COM ISSO AO PROCESSO NORMAL DE COBRAN�A.  *      */
        /*"V.02  * MESMO QUE A PARCELA SUSPENSA ESTEJA VENCIDA O SISTEMA DEVER�   *      */
        /*"V.02  * REATIVAR O ENVIO DA COBRAN�A PARA O BANCO. ESTA ALTERA��O      *      */
        /*"V.02  * DEVE SER APLICADA TANTO PARA AS AP�LICES MAPFRE                *      */
        /*"V.02  * QUANTO SUL AM�RICA.                                            *      */
        /*"V.02  *                                                                *      */
        /*"V.02  * ORGAO_EMISSOR  100  = MAPFRE                                   *      */
        /*"V.02  * ORGAO_EMISSOR  110  = SUL AMERICA                              *      */
        /*"V.02  *                                                                *      */
        /*"V.02  * ELABORADO POR: ADRIANA GOMES FERNANDES    �REA: GETEC          *      */
        /*"V.02  * VALIDADO POR: NUBIA QUEIROZ    �REA: GEAUT                     *      */
        /*"V.02  *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELAS                     DCLGEN                    ACESSO   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * SISTEMAS                    SISTEMAS                  INPUT    *      */
        /*"      * PARCELAS                    PARCELAS                  INPUT    *      */
        /*"      * PARCELA_HISTORICO           PARCEHIS                  INPUT    *      */
        /*"      * MOVTO_DEBITOCC_CEF          CBAPOVIG                  INPUT    *      */
        /*"      * CB_APOLICE_VIGPROP          CBMALPAR                  I-O      *      */
        /*"      * CB_MALA_PARCATRASO          MOVDEBCE                  I-O      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  WS-HOST-CURRENT-DATE   PIC  X(010)  VALUE SPACES.*/
        public StringBasis WS_HOST_CURRENT_DATE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01           AREA-DE-WORK.*/
        public CB1262B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new CB1262B_AREA_DE_WORK();
        public class CB1262B_AREA_DE_WORK : VarBasis
        {
            /*"  05         WS-NUM-APOLICE    PIC S9(013)  VALUE +0 COMP-3.*/
            public IntBasis WS_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"  05         WS-NUM-ENDOSSO    PIC S9(009)  VALUE +0 COMP.*/
            public IntBasis WS_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05         WS-NUM-PARCELA    PIC S9(004)  VALUE +0 COMP.*/
            public IntBasis WS_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05         AC-L-PARCEHIS1    PIC  9(007)  VALUE ZEROS.*/
            public IntBasis AC_L_PARCEHIS1 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-L-PARCEHIS2    PIC  9(007)  VALUE ZEROS.*/
            public IntBasis AC_L_PARCEHIS2 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-L-MOVDEBCE     PIC  9(007)  VALUE ZEROS.*/
            public IntBasis AC_L_MOVDEBCE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-U-CBAPOVIG     PIC  9(007)  VALUE ZEROS.*/
            public IntBasis AC_U_CBAPOVIG { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-U-CBMALPAR     PIC  9(007)  VALUE ZEROS.*/
            public IntBasis AC_U_CBMALPAR { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-U-MOVDEBCE     PIC  9(007)  VALUE ZEROS.*/
            public IntBasis AC_U_MOVDEBCE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-U-PARCELAS     PIC  9(007)  VALUE ZEROS.*/
            public IntBasis AC_U_PARCELAS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         WS-FIM-PARCEHIS   PIC  X(001)  VALUE SPACES.*/
            public StringBasis WS_FIM_PARCEHIS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WS-FIM-MOVDEBCE   PIC  X(001)  VALUE SPACES.*/
            public StringBasis WS_FIM_MOVDEBCE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WS-OPERACAO       PIC  9(004)  VALUE ZEROS.*/
            public IntBasis WS_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         FILLER            REDEFINES    WS-OPERACAO.*/
            private _REDEF_CB1262B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_CB1262B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_CB1262B_FILLER_0(); _.Move(WS_OPERACAO, _filler_0); VarBasis.RedefinePassValue(WS_OPERACAO, _filler_0, WS_OPERACAO); _filler_0.ValueChanged += () => { _.Move(_filler_0, WS_OPERACAO); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WS_OPERACAO); }
            }  //Redefines
            public class _REDEF_CB1262B_FILLER_0 : VarBasis
            {
                /*"    10       WS-FAIXA-OPER     PIC  9(002).*/
                public IntBasis WS_FAIXA_OPER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  9(002).*/
                public IntBasis FILLER_1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05        WABEND.*/

                public _REDEF_CB1262B_FILLER_0()
                {
                    WS_FAIXA_OPER.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                }

            }
            public CB1262B_WABEND WABEND { get; set; } = new CB1262B_WABEND();
            public class CB1262B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(010) VALUE           ' CB1262B'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" CB1262B");
                /*"    10      FILLER              PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"01    WS-HORAS.*/
            }
        }
        public CB1262B_WS_HORAS WS_HORAS { get; set; } = new CB1262B_WS_HORAS();
        public class CB1262B_WS_HORAS : VarBasis
        {
            /*"  03  WS-HORA-INI               PIC  X(008).*/
            public StringBasis WS_HORA_INI { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-INI-R REDEFINES WS-HORA-INI.*/
            private _REDEF_CB1262B_WS_HORA_INI_R _ws_hora_ini_r { get; set; }
            public _REDEF_CB1262B_WS_HORA_INI_R WS_HORA_INI_R
            {
                get { _ws_hora_ini_r = new _REDEF_CB1262B_WS_HORA_INI_R(); _.Move(WS_HORA_INI, _ws_hora_ini_r); VarBasis.RedefinePassValue(WS_HORA_INI, _ws_hora_ini_r, WS_HORA_INI); _ws_hora_ini_r.ValueChanged += () => { _.Move(_ws_hora_ini_r, WS_HORA_INI); }; return _ws_hora_ini_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_ini_r, WS_HORA_INI); }
            }  //Redefines
            public class _REDEF_CB1262B_WS_HORA_INI_R : VarBasis
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

                public _REDEF_CB1262B_WS_HORA_INI_R()
                {
                    HI.ValueChanged += OnValueChanged;
                    MI.ValueChanged += OnValueChanged;
                    SI.ValueChanged += OnValueChanged;
                    DCI.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_HORA_FIM { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-FIM-R REDEFINES WS-HORA-FIM.*/
            private _REDEF_CB1262B_WS_HORA_FIM_R _ws_hora_fim_r { get; set; }
            public _REDEF_CB1262B_WS_HORA_FIM_R WS_HORA_FIM_R
            {
                get { _ws_hora_fim_r = new _REDEF_CB1262B_WS_HORA_FIM_R(); _.Move(WS_HORA_FIM, _ws_hora_fim_r); VarBasis.RedefinePassValue(WS_HORA_FIM, _ws_hora_fim_r, WS_HORA_FIM); _ws_hora_fim_r.ValueChanged += () => { _.Move(_ws_hora_fim_r, WS_HORA_FIM); }; return _ws_hora_fim_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_fim_r, WS_HORA_FIM); }
            }  //Redefines
            public class _REDEF_CB1262B_WS_HORA_FIM_R : VarBasis
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

                public _REDEF_CB1262B_WS_HORA_FIM_R()
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
        public CB1262B_TOTAIS_ROT TOTAIS_ROT { get; set; } = new CB1262B_TOTAIS_ROT();
        public class CB1262B_TOTAIS_ROT : VarBasis
        {
            /*"    03  FILLER  OCCURS 50 TIMES.*/
            public ListBasis<CB1262B_FILLER_5> FILLER_5 { get; set; } = new ListBasis<CB1262B_FILLER_5>(50);
            public class CB1262B_FILLER_5 : VarBasis
            {
                /*"        05  STT                       PIC S9(013)V99 COMP-3.*/
                public DoubleBasis STT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                /*"        05  SQT                       PIC S9(015)    COMP-3.*/
                public IntBasis SQT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
                /*"01          LD99-ABEND.*/
            }
        }
        public CB1262B_LD99_ABEND LD99_ABEND { get; set; } = new CB1262B_LD99_ABEND();
        public class CB1262B_LD99_ABEND : VarBasis
        {
            /*"      10    FILLER              PIC  X(050) VALUE           ' REINICIAR JOB NO PROXIMO STEP               '.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @" REINICIAR JOB NO PROXIMO STEP               ");
            /*"      10    FILLER              PIC  X(050) VALUE           ' QUANDO SQLCODE IGUAL (-911) RESTART MESMO STEP '.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @" QUANDO SQLCODE IGUAL (-911) RESTART MESMO STEP ");
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.PARCELAS PARCELAS { get; set; } = new Dclgens.PARCELAS();
        public Dclgens.PARCEHIS PARCEHIS { get; set; } = new Dclgens.PARCEHIS();
        public Dclgens.CBAPOVIG CBAPOVIG { get; set; } = new Dclgens.CBAPOVIG();
        public Dclgens.CBMALPAR CBMALPAR { get; set; } = new Dclgens.CBMALPAR();
        public Dclgens.MOVDEBCE MOVDEBCE { get; set; } = new Dclgens.MOVDEBCE();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public CB1262B_C0PARCEHIS C0PARCEHIS { get; set; } = new CB1262B_C0PARCEHIS();
        public CB1262B_C1PARCEHIS C1PARCEHIS { get; set; } = new CB1262B_C1PARCEHIS();
        public CB1262B_C0MOVDEBCE C0MOVDEBCE { get; set; } = new CB1262B_C0MOVDEBCE();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -202- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -203- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -206- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -209- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -209- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -219- INITIALIZE WS-HORAS TOTAIS-ROT. */
            _.Initialize(
                WS_HORAS
                , TOTAIS_ROT
            );

            /*" -221- PERFORM R0100-00-SELECT-SISTEMAS. */

            R0100_00_SELECT_SISTEMAS_SECTION();

            /*" -226- DISPLAY 'DATA DO SISTEMA (CB) - ' SISTEMAS-DATA-MOV-ABERTO. */
            _.Display($"DATA DO SISTEMA (CB) - {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -227- MOVE SPACES TO WS-FIM-PARCEHIS. */
            _.Move("", AREA_DE_WORK.WS_FIM_PARCEHIS);

            /*" -229- PERFORM R0900-00-DECLARE-PARCEHIS. */

            R0900_00_DECLARE_PARCEHIS_SECTION();

            /*" -231- PERFORM R0910-00-FETCH-PARCEHIS. */

            R0910_00_FETCH_PARCEHIS_SECTION();

            /*" -236- PERFORM R1000-00-PROCESSA-PARCEHIS UNTIL WS-FIM-PARCEHIS = 'S' . */

            while (!(AREA_DE_WORK.WS_FIM_PARCEHIS == "S"))
            {

                R1000_00_PROCESSA_PARCEHIS_SECTION();
            }

            /*" -237- MOVE SPACES TO WS-FIM-PARCEHIS. */
            _.Move("", AREA_DE_WORK.WS_FIM_PARCEHIS);

            /*" -239- PERFORM R1500-00-DECLARE-PARCEHIS. */

            R1500_00_DECLARE_PARCEHIS_SECTION();

            /*" -241- PERFORM R1510-00-FETCH-PARCEHIS. */

            R1510_00_FETCH_PARCEHIS_SECTION();

            /*" -246- PERFORM R1600-00-PROCESSA-PARCEHIS UNTIL WS-FIM-PARCEHIS = 'S' . */

            while (!(AREA_DE_WORK.WS_FIM_PARCEHIS == "S"))
            {

                R1600_00_PROCESSA_PARCEHIS_SECTION();
            }

            /*" -247- DISPLAY '*----------------------------------------*' . */
            _.Display($"*----------------------------------------*");

            /*" -248- DISPLAY '* CB1262B-ATUALIZAR A CB_APOLICE_VIGPROP  ' . */
            _.Display($"* CB1262B-ATUALIZAR A CB_APOLICE_VIGPROP  ");

            /*" -249- DISPLAY '*----------------------------------------*' . */
            _.Display($"*----------------------------------------*");

            /*" -250- DISPLAY '* DOCUMENTOS LIDOS:          ' . */
            _.Display($"* DOCUMENTOS LIDOS:          ");

            /*" -251- DISPLAY '* - PARCELA_HISTORICO(1)= ' AC-L-PARCEHIS1. */
            _.Display($"* - PARCELA_HISTORICO(1)= {AREA_DE_WORK.AC_L_PARCEHIS1}");

            /*" -252- DISPLAY '* - PARCELA_HISTORICO(2)= ' AC-L-PARCEHIS2. */
            _.Display($"* - PARCELA_HISTORICO(2)= {AREA_DE_WORK.AC_L_PARCEHIS2}");

            /*" -253- DISPLAY '* - MOVTO_DEBITOCC_CEF  = ' AC-L-MOVDEBCE. */
            _.Display($"* - MOVTO_DEBITOCC_CEF  = {AREA_DE_WORK.AC_L_MOVDEBCE}");

            /*" -254- DISPLAY '*------------------------------------*' . */
            _.Display($"*------------------------------------*");

            /*" -255- DISPLAY '* UPDATE:' . */
            _.Display($"* UPDATE:");

            /*" -256- DISPLAY '* - CB_APOLICE_VIGPROP  = ' AC-U-CBAPOVIG. */
            _.Display($"* - CB_APOLICE_VIGPROP  = {AREA_DE_WORK.AC_U_CBAPOVIG}");

            /*" -257- DISPLAY '* - CB_MALA_PARCATRASO  = ' AC-U-CBMALPAR. */
            _.Display($"* - CB_MALA_PARCATRASO  = {AREA_DE_WORK.AC_U_CBMALPAR}");

            /*" -258- DISPLAY '* - MOVTO_DEBITOCC_CEF  = ' AC-U-MOVDEBCE. */
            _.Display($"* - MOVTO_DEBITOCC_CEF  = {AREA_DE_WORK.AC_U_MOVDEBCE}");

            /*" -259- DISPLAY '* - PARCELAS            = ' AC-U-PARCELAS. */
            _.Display($"* - PARCELAS            = {AREA_DE_WORK.AC_U_PARCELAS}");

            /*" -260- DISPLAY '*------------------------------------*' . */
            _.Display($"*------------------------------------*");

            /*" -261- DISPLAY '              FIM NORMAL              ' . */
            _.Display($"              FIM NORMAL              ");

            /*" -265- DISPLAY '*------------------------------------*' . */
            _.Display($"*------------------------------------*");

            /*" -266- DISPLAY ' ' . */
            _.Display($" ");

            /*" -266- MOVE ZEROS TO SII. */
            _.Move(0, WS_HORAS.SII);

            /*" -0- FLUXCONTROL_PERFORM R0000_90_MOSTRA_TOTAIS */

            R0000_90_MOSTRA_TOTAIS();

        }

        [StopWatch]
        /*" R0000-90-MOSTRA-TOTAIS */
        private void R0000_90_MOSTRA_TOTAIS(bool isPerform = false)
        {
            /*" -272- ADD 1 TO SII. */
            WS_HORAS.SII.Value = WS_HORAS.SII + 1;

            /*" -273- IF SII < 15 */

            if (WS_HORAS.SII < 15)
            {

                /*" -274- MOVE STT(SII) TO STT-DISP */
                _.Move(TOTAIS_ROT.FILLER_5[WS_HORAS.SII].STT, WS_HORAS.STT_DISP);

                /*" -276- DISPLAY 'PARAGRAFO:' SII ' TOTAL= ' STT-DISP ' QTDE= ' SQT(SII) */

                $"PARAGRAFO:{WS_HORAS.SII} TOTAL= {WS_HORAS.STT_DISP} QTDE= {TOTAIS_ROT.FILLER_5[WS_HORAS.SII]}"
                .Display();

                /*" -277- GO TO R0000-90-MOSTRA-TOTAIS. */
                new Task(() => R0000_90_MOSTRA_TOTAIS()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -279- DISPLAY ' ' . */
            _.Display($" ");

            /*" -279- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -283- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -283- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-SECTION */
        private void R0100_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -296- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -307- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -310- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -311- DISPLAY 'R0100- ERRO SELECT SISTEMAS (CB)' */
                _.Display($"R0100- ERRO SELECT SISTEMAS (CB)");

                /*" -311- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -307- EXEC SQL SELECT DATA_MOV_ABERTO, CURRENT DATE INTO :SISTEMAS-DATA-MOV-ABERTO, :WS-HOST-CURRENT-DATE FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'CB' END-EXEC. */

            var r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.WS_HOST_CURRENT_DATE, WS_HOST_CURRENT_DATE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-PARCEHIS-SECTION */
        private void R0900_00_DECLARE_PARCEHIS_SECTION()
        {
            /*" -325- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -326- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -329- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -356- PERFORM R0900_00_DECLARE_PARCEHIS_DB_DECLARE_1 */

            R0900_00_DECLARE_PARCEHIS_DB_DECLARE_1();

            /*" -358- PERFORM R0900_00_DECLARE_PARCEHIS_DB_OPEN_1 */

            R0900_00_DECLARE_PARCEHIS_DB_OPEN_1();

            /*" -362- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -363- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -364- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -365- ADD SFT TO STT(01) */
            TOTAIS_ROT.FILLER_5[01].STT.Value = TOTAIS_ROT.FILLER_5[01].STT + WS_HORAS.SFT;

            /*" -368- ADD 1 TO SQT(01) */
            TOTAIS_ROT.FILLER_5[01].SQT.Value = TOTAIS_ROT.FILLER_5[01].SQT + 1;

            /*" -369- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -370- DISPLAY 'R0900 - ERRO DECLARE PARCELA_HISTORICO' */
                _.Display($"R0900 - ERRO DECLARE PARCELA_HISTORICO");

                /*" -370- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-PARCEHIS-DB-DECLARE-1 */
        public void R0900_00_DECLARE_PARCEHIS_DB_DECLARE_1()
        {
            /*" -356- EXEC SQL DECLARE C0PARCEHIS CURSOR FOR SELECT A.NUM_APOLICE, A.NUM_ENDOSSO, A.NUM_PARCELA, A.OCORR_HISTORICO, A.COD_OPERACAO, B.NUM_APOLICE, B.NUM_ENDOSSO, B.NUM_PARCELA, C.ORGAO_EMISSOR FROM SEGUROS.PARCELA_HISTORICO A, SEGUROS.CB_APOLICE_VIGPROP B, SEGUROS.APOLICES C WHERE A.DATA_MOVIMENTO = :SISTEMAS-DATA-MOV-ABERTO AND B.NUM_APOLICE = A.NUM_APOLICE AND B.SITUACAO = '0' AND A.COD_OPERACAO < 600 AND A.NUM_APOLICE = C.NUM_APOLICE AND B.NUM_APOLICE = C.NUM_APOLICE ORDER BY A.NUM_APOLICE, A.NUM_ENDOSSO, A.NUM_PARCELA, A.OCORR_HISTORICO DESC END-EXEC. */
            C0PARCEHIS = new CB1262B_C0PARCEHIS(true);
            string GetQuery_C0PARCEHIS()
            {
                var query = @$"SELECT 
							A.NUM_APOLICE
							, 
							A.NUM_ENDOSSO
							, 
							A.NUM_PARCELA
							, 
							A.OCORR_HISTORICO
							, 
							A.COD_OPERACAO
							, 
							B.NUM_APOLICE
							, 
							B.NUM_ENDOSSO
							, 
							B.NUM_PARCELA
							, 
							C.ORGAO_EMISSOR 
							FROM 
							SEGUROS.PARCELA_HISTORICO A
							, 
							SEGUROS.CB_APOLICE_VIGPROP B
							, 
							SEGUROS.APOLICES C 
							WHERE 
							A.DATA_MOVIMENTO = '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.SITUACAO = '0' 
							AND A.COD_OPERACAO < 600 
							AND A.NUM_APOLICE = C.NUM_APOLICE 
							AND B.NUM_APOLICE = C.NUM_APOLICE 
							ORDER BY 
							A.NUM_APOLICE
							, 
							A.NUM_ENDOSSO
							, 
							A.NUM_PARCELA
							, 
							A.OCORR_HISTORICO DESC";

                return query;
            }
            C0PARCEHIS.GetQueryEvent += GetQuery_C0PARCEHIS;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-PARCEHIS-DB-OPEN-1 */
        public void R0900_00_DECLARE_PARCEHIS_DB_OPEN_1()
        {
            /*" -358- EXEC SQL OPEN C0PARCEHIS END-EXEC. */

            C0PARCEHIS.Open();

        }

        [StopWatch]
        /*" R1500-00-DECLARE-PARCEHIS-DB-DECLARE-1 */
        public void R1500_00_DECLARE_PARCEHIS_DB_DECLARE_1()
        {
            /*" -555- EXEC SQL DECLARE C1PARCEHIS CURSOR FOR SELECT A.NUM_APOLICE, A.NUM_ENDOSSO, A.NUM_PARCELA, A.OCORR_HISTORICO, A.COD_OPERACAO, B.DATA_MOVIMENTO, VALUE(B.NUM_TITULO,0) FROM SEGUROS.PARCELA_HISTORICO A, SEGUROS.CB_MALA_PARCATRASO B WHERE A.DATA_MOVIMENTO = :SISTEMAS-DATA-MOV-ABERTO AND A.NUM_APOLICE = B.NUM_APOLICE AND A.NUM_ENDOSSO = B.NUM_ENDOSSO AND A.NUM_PARCELA = B.NUM_PARCELA AND A.COD_OPERACAO < 600 AND B.SITUACAO <> '4' ORDER BY A.NUM_APOLICE, A.NUM_ENDOSSO, A.NUM_PARCELA, A.OCORR_HISTORICO DESC END-EXEC. */
            C1PARCEHIS = new CB1262B_C1PARCEHIS(true);
            string GetQuery_C1PARCEHIS()
            {
                var query = @$"SELECT 
							A.NUM_APOLICE
							, 
							A.NUM_ENDOSSO
							, 
							A.NUM_PARCELA
							, 
							A.OCORR_HISTORICO
							, 
							A.COD_OPERACAO
							, 
							B.DATA_MOVIMENTO
							, 
							VALUE(B.NUM_TITULO
							,0) 
							FROM 
							SEGUROS.PARCELA_HISTORICO A
							, 
							SEGUROS.CB_MALA_PARCATRASO B 
							WHERE 
							A.DATA_MOVIMENTO = '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND A.NUM_APOLICE = B.NUM_APOLICE 
							AND A.NUM_ENDOSSO = B.NUM_ENDOSSO 
							AND A.NUM_PARCELA = B.NUM_PARCELA 
							AND A.COD_OPERACAO < 600 
							AND B.SITUACAO <> '4' 
							ORDER BY 
							A.NUM_APOLICE
							, 
							A.NUM_ENDOSSO
							, 
							A.NUM_PARCELA
							, 
							A.OCORR_HISTORICO DESC";

                return query;
            }
            C1PARCEHIS.GetQueryEvent += GetQuery_C1PARCEHIS;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-PARCEHIS-SECTION */
        private void R0910_00_FETCH_PARCEHIS_SECTION()
        {
            /*" -381- MOVE '091' TO WNR-EXEC-SQL. */
            _.Move("091", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R0910_10_FETCH_PARCEHIS */

            R0910_10_FETCH_PARCEHIS();

        }

        [StopWatch]
        /*" R0910-10-FETCH-PARCEHIS */
        private void R0910_10_FETCH_PARCEHIS(bool isPerform = false)
        {
            /*" -388- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -391- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -402- PERFORM R0910_10_FETCH_PARCEHIS_DB_FETCH_1 */

            R0910_10_FETCH_PARCEHIS_DB_FETCH_1();

            /*" -406- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -407- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -408- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -409- ADD SFT TO STT(02) */
            TOTAIS_ROT.FILLER_5[02].STT.Value = TOTAIS_ROT.FILLER_5[02].STT + WS_HORAS.SFT;

            /*" -412- ADD 1 TO SQT(02) */
            TOTAIS_ROT.FILLER_5[02].SQT.Value = TOTAIS_ROT.FILLER_5[02].SQT + 1;

            /*" -413- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -414- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -415- MOVE 'S' TO WS-FIM-PARCEHIS */
                    _.Move("S", AREA_DE_WORK.WS_FIM_PARCEHIS);

                    /*" -415- PERFORM R0910_10_FETCH_PARCEHIS_DB_CLOSE_1 */

                    R0910_10_FETCH_PARCEHIS_DB_CLOSE_1();

                    /*" -417- GO TO R0910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;

                    /*" -418- ELSE */
                }
                else
                {


                    /*" -419- DISPLAY 'R0910- ERRO FETCH HISTORICO_PARCELAS' */
                    _.Display($"R0910- ERRO FETCH HISTORICO_PARCELAS");

                    /*" -421- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -423- MOVE PARCEHIS-COD-OPERACAO TO WS-OPERACAO. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO, AREA_DE_WORK.WS_OPERACAO);

            /*" -423- ADD 1 TO AC-L-PARCEHIS1. */
            AREA_DE_WORK.AC_L_PARCEHIS1.Value = AREA_DE_WORK.AC_L_PARCEHIS1 + 1;

        }

        [StopWatch]
        /*" R0910-10-FETCH-PARCEHIS-DB-FETCH-1 */
        public void R0910_10_FETCH_PARCEHIS_DB_FETCH_1()
        {
            /*" -402- EXEC SQL FETCH C0PARCEHIS INTO :PARCEHIS-NUM-APOLICE, :PARCEHIS-NUM-ENDOSSO, :PARCEHIS-NUM-PARCELA, :PARCEHIS-OCORR-HISTORICO, :PARCEHIS-COD-OPERACAO, :CBAPOVIG-NUM-APOLICE, :CBAPOVIG-NUM-ENDOSSO, :CBAPOVIG-NUM-PARCELA, :APOLICES-ORGAO-EMISSOR END-EXEC. */

            if (C0PARCEHIS.Fetch())
            {
                _.Move(C0PARCEHIS.PARCEHIS_NUM_APOLICE, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE);
                _.Move(C0PARCEHIS.PARCEHIS_NUM_ENDOSSO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO);
                _.Move(C0PARCEHIS.PARCEHIS_NUM_PARCELA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA);
                _.Move(C0PARCEHIS.PARCEHIS_OCORR_HISTORICO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO);
                _.Move(C0PARCEHIS.PARCEHIS_COD_OPERACAO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO);
                _.Move(C0PARCEHIS.CBAPOVIG_NUM_APOLICE, CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_APOLICE);
                _.Move(C0PARCEHIS.CBAPOVIG_NUM_ENDOSSO, CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_ENDOSSO);
                _.Move(C0PARCEHIS.CBAPOVIG_NUM_PARCELA, CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_PARCELA);
                _.Move(C0PARCEHIS.APOLICES_ORGAO_EMISSOR, APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR);
            }

        }

        [StopWatch]
        /*" R0910-10-FETCH-PARCEHIS-DB-CLOSE-1 */
        public void R0910_10_FETCH_PARCEHIS_DB_CLOSE_1()
        {
            /*" -415- EXEC SQL CLOSE C0PARCEHIS END-EXEC */

            C0PARCEHIS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-PARCEHIS-SECTION */
        private void R1000_00_PROCESSA_PARCEHIS_SECTION()
        {
            /*" -436- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -437- MOVE PARCEHIS-NUM-APOLICE TO WS-NUM-APOLICE. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE, AREA_DE_WORK.WS_NUM_APOLICE);

            /*" -438- MOVE PARCEHIS-NUM-ENDOSSO TO WS-NUM-ENDOSSO. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO, AREA_DE_WORK.WS_NUM_ENDOSSO);

            /*" -440- MOVE PARCEHIS-NUM-PARCELA TO WS-NUM-PARCELA. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA, AREA_DE_WORK.WS_NUM_PARCELA);

            /*" -441- IF WS-FAIXA-OPER NOT = 02 AND 04 */

            if (!AREA_DE_WORK.FILLER_0.WS_FAIXA_OPER.In("02", "04"))
            {

                /*" -447- PERFORM R0910-00-FETCH-PARCEHIS UNTIL WS-FIM-PARCEHIS NOT = SPACES OR PARCEHIS-NUM-APOLICE NOT = WS-NUM-APOLICE OR PARCEHIS-NUM-ENDOSSO NOT = WS-NUM-ENDOSSO OR PARCEHIS-NUM-PARCELA NOT = WS-NUM-PARCELA. */

                while (!(!AREA_DE_WORK.WS_FIM_PARCEHIS.IsEmpty() || PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE != AREA_DE_WORK.WS_NUM_APOLICE || PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO != AREA_DE_WORK.WS_NUM_ENDOSSO || PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA != AREA_DE_WORK.WS_NUM_PARCELA))
                {

                    R0910_00_FETCH_PARCEHIS_SECTION();
                }
            }


            /*" -448- IF WS-FAIXA-OPER = 02 */

            if (AREA_DE_WORK.FILLER_0.WS_FAIXA_OPER == 02)
            {

                /*" -451- IF PARCEHIS-NUM-APOLICE = CBAPOVIG-NUM-APOLICE AND PARCEHIS-NUM-ENDOSSO = CBAPOVIG-NUM-ENDOSSO AND PARCEHIS-NUM-PARCELA = CBAPOVIG-NUM-PARCELA */

                if (PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE == CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_APOLICE && PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO == CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_ENDOSSO && PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA == CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_PARCELA)
                {

                    /*" -452- MOVE '2' TO CBAPOVIG-SITUACAO */
                    _.Move("2", CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_SITUACAO);

                    /*" -453- PERFORM R1100-00-UPDATE-CBAPOVIG */

                    R1100_00_UPDATE_CBAPOVIG_SECTION();

                    /*" -454- ELSE */
                }
                else
                {


                    /*" -455- MOVE '4' TO CBAPOVIG-SITUACAO */
                    _.Move("4", CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_SITUACAO);

                    /*" -459- PERFORM R1100-00-UPDATE-CBAPOVIG. */

                    R1100_00_UPDATE_CBAPOVIG_SECTION();
                }

            }


            /*" -460- IF WS-FAIXA-OPER = 04 */

            if (AREA_DE_WORK.FILLER_0.WS_FAIXA_OPER == 04)
            {

                /*" -461- MOVE '3' TO CBAPOVIG-SITUACAO */
                _.Move("3", CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_SITUACAO);

                /*" -461- PERFORM R1100-00-UPDATE-CBAPOVIG. */

                R1100_00_UPDATE_CBAPOVIG_SECTION();
            }


            /*" -0- FLUXCONTROL_PERFORM R1000_90_FETCH_PARCEHIS */

            R1000_90_FETCH_PARCEHIS();

        }

        [StopWatch]
        /*" R1000-90-FETCH-PARCEHIS */
        private void R1000_90_FETCH_PARCEHIS(bool isPerform = false)
        {
            /*" -468- PERFORM R0910-00-FETCH-PARCEHIS UNTIL WS-FIM-PARCEHIS NOT = SPACES OR PARCEHIS-NUM-APOLICE NOT = WS-NUM-APOLICE. */

            while (!(!AREA_DE_WORK.WS_FIM_PARCEHIS.IsEmpty() || PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE != AREA_DE_WORK.WS_NUM_APOLICE))
            {

                R0910_00_FETCH_PARCEHIS_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-UPDATE-CBAPOVIG-SECTION */
        private void R1100_00_UPDATE_CBAPOVIG_SECTION()
        {
            /*" -482- MOVE '110' TO WNR-EXEC-SQL. */
            _.Move("110", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -483- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -486- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -495- PERFORM R1100_00_UPDATE_CBAPOVIG_DB_UPDATE_1 */

            R1100_00_UPDATE_CBAPOVIG_DB_UPDATE_1();

            /*" -499- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -500- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -501- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -502- ADD SFT TO STT(03) */
            TOTAIS_ROT.FILLER_5[03].STT.Value = TOTAIS_ROT.FILLER_5[03].STT + WS_HORAS.SFT;

            /*" -505- ADD 1 TO SQT(03) */
            TOTAIS_ROT.FILLER_5[03].SQT.Value = TOTAIS_ROT.FILLER_5[03].SQT + 1;

            /*" -506- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -507- DISPLAY 'R1100- ERRO SELECT CB_APOLICE_VIGPROP' */
                _.Display($"R1100- ERRO SELECT CB_APOLICE_VIGPROP");

                /*" -508- DISPLAY 'APOLICE = ' PARCEHIS-NUM-APOLICE */
                _.Display($"APOLICE = {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                /*" -509- DISPLAY 'ENDOSSO = ' PARCEHIS-NUM-ENDOSSO */
                _.Display($"ENDOSSO = {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                /*" -510- DISPLAY 'PARCELA = ' PARCEHIS-NUM-PARCELA */
                _.Display($"PARCELA = {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}");

                /*" -511- DISPLAY 'SITUACAO= ' CBAPOVIG-SITUACAO */
                _.Display($"SITUACAO= {CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_SITUACAO}");

                /*" -513- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -513- ADD 1 TO AC-U-CBAPOVIG. */
            AREA_DE_WORK.AC_U_CBAPOVIG.Value = AREA_DE_WORK.AC_U_CBAPOVIG + 1;

        }

        [StopWatch]
        /*" R1100-00-UPDATE-CBAPOVIG-DB-UPDATE-1 */
        public void R1100_00_UPDATE_CBAPOVIG_DB_UPDATE_1()
        {
            /*" -495- EXEC SQL UPDATE SEGUROS.CB_APOLICE_VIGPROP SET SITUACAO = :CBAPOVIG-SITUACAO, TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_APOLICE = :PARCEHIS-NUM-APOLICE END-EXEC. */

            var r1100_00_UPDATE_CBAPOVIG_DB_UPDATE_1_Update1 = new R1100_00_UPDATE_CBAPOVIG_DB_UPDATE_1_Update1()
            {
                CBAPOVIG_SITUACAO = CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_SITUACAO.ToString(),
                PARCEHIS_NUM_APOLICE = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.ToString(),
            };

            R1100_00_UPDATE_CBAPOVIG_DB_UPDATE_1_Update1.Execute(r1100_00_UPDATE_CBAPOVIG_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-DECLARE-PARCEHIS-SECTION */
        private void R1500_00_DECLARE_PARCEHIS_SECTION()
        {
            /*" -527- MOVE '150' TO WNR-EXEC-SQL. */
            _.Move("150", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -528- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -531- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -555- PERFORM R1500_00_DECLARE_PARCEHIS_DB_DECLARE_1 */

            R1500_00_DECLARE_PARCEHIS_DB_DECLARE_1();

            /*" -557- PERFORM R1500_00_DECLARE_PARCEHIS_DB_OPEN_1 */

            R1500_00_DECLARE_PARCEHIS_DB_OPEN_1();

            /*" -561- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -562- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -563- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -564- ADD SFT TO STT(04) */
            TOTAIS_ROT.FILLER_5[04].STT.Value = TOTAIS_ROT.FILLER_5[04].STT + WS_HORAS.SFT;

            /*" -567- ADD 1 TO SQT(04) */
            TOTAIS_ROT.FILLER_5[04].SQT.Value = TOTAIS_ROT.FILLER_5[04].SQT + 1;

            /*" -568- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -569- DISPLAY 'R1500 - ERRO DECLARE PARCELA_HISTORICO' */
                _.Display($"R1500 - ERRO DECLARE PARCELA_HISTORICO");

                /*" -569- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1500-00-DECLARE-PARCEHIS-DB-OPEN-1 */
        public void R1500_00_DECLARE_PARCEHIS_DB_OPEN_1()
        {
            /*" -557- EXEC SQL OPEN C1PARCEHIS END-EXEC. */

            C1PARCEHIS.Open();

        }

        [StopWatch]
        /*" R2100-00-DECLARE-MOVDEBCE-DB-DECLARE-1 */
        public void R2100_00_DECLARE_MOVDEBCE_DB_DECLARE_1()
        {
            /*" -816- EXEC SQL DECLARE C0MOVDEBCE CURSOR FOR SELECT NUM_APOLICE, NUM_ENDOSSO, NUM_PARCELA, COD_CONVENIO, NSAS, DATA_VENCIMENTO FROM SEGUROS.MOVTO_DEBITOCC_CEF WHERE NUM_APOLICE = :PARCEHIS-NUM-APOLICE AND NUM_ENDOSSO = :PARCEHIS-NUM-ENDOSSO AND NUM_PARCELA > :PARCEHIS-NUM-PARCELA AND SITUACAO_COBRANCA = '6' ORDER BY NUM_APOLICE, NUM_ENDOSSO, DATA_VENCIMENTO, NUM_PARCELA END-EXEC. */
            C0MOVDEBCE = new CB1262B_C0MOVDEBCE(true);
            string GetQuery_C0MOVDEBCE()
            {
                var query = @$"SELECT 
							NUM_APOLICE
							, 
							NUM_ENDOSSO
							, 
							NUM_PARCELA
							, 
							COD_CONVENIO
							, 
							NSAS
							, 
							DATA_VENCIMENTO 
							FROM 
							SEGUROS.MOVTO_DEBITOCC_CEF 
							WHERE 
							NUM_APOLICE = '{PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}' 
							AND NUM_ENDOSSO = '{PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}' 
							AND NUM_PARCELA > '{PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}' 
							AND SITUACAO_COBRANCA = '6' 
							ORDER BY 
							NUM_APOLICE
							, 
							NUM_ENDOSSO
							, 
							DATA_VENCIMENTO
							, 
							NUM_PARCELA";

                return query;
            }
            C0MOVDEBCE.GetQueryEvent += GetQuery_C0MOVDEBCE;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1510-00-FETCH-PARCEHIS-SECTION */
        private void R1510_00_FETCH_PARCEHIS_SECTION()
        {
            /*" -580- MOVE '151' TO WNR-EXEC-SQL. */
            _.Move("151", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R1510_10_FETCH_PARCEHIS */

            R1510_10_FETCH_PARCEHIS();

        }

        [StopWatch]
        /*" R1510-10-FETCH-PARCEHIS */
        private void R1510_10_FETCH_PARCEHIS(bool isPerform = false)
        {
            /*" -587- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -590- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -599- PERFORM R1510_10_FETCH_PARCEHIS_DB_FETCH_1 */

            R1510_10_FETCH_PARCEHIS_DB_FETCH_1();

            /*" -603- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -604- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -605- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -606- ADD SFT TO STT(05) */
            TOTAIS_ROT.FILLER_5[05].STT.Value = TOTAIS_ROT.FILLER_5[05].STT + WS_HORAS.SFT;

            /*" -609- ADD 1 TO SQT(05) */
            TOTAIS_ROT.FILLER_5[05].SQT.Value = TOTAIS_ROT.FILLER_5[05].SQT + 1;

            /*" -610- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -611- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -612- MOVE 'S' TO WS-FIM-PARCEHIS */
                    _.Move("S", AREA_DE_WORK.WS_FIM_PARCEHIS);

                    /*" -612- PERFORM R1510_10_FETCH_PARCEHIS_DB_CLOSE_1 */

                    R1510_10_FETCH_PARCEHIS_DB_CLOSE_1();

                    /*" -614- GO TO R1510-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1510_99_SAIDA*/ //GOTO
                    return;

                    /*" -615- ELSE */
                }
                else
                {


                    /*" -616- DISPLAY 'R1510- ERRO FETCH HISTORICO_PARCELAS' */
                    _.Display($"R1510- ERRO FETCH HISTORICO_PARCELAS");

                    /*" -618- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -620- MOVE PARCEHIS-COD-OPERACAO TO WS-OPERACAO. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO, AREA_DE_WORK.WS_OPERACAO);

            /*" -620- ADD 1 TO AC-L-PARCEHIS2. */
            AREA_DE_WORK.AC_L_PARCEHIS2.Value = AREA_DE_WORK.AC_L_PARCEHIS2 + 1;

        }

        [StopWatch]
        /*" R1510-10-FETCH-PARCEHIS-DB-FETCH-1 */
        public void R1510_10_FETCH_PARCEHIS_DB_FETCH_1()
        {
            /*" -599- EXEC SQL FETCH C1PARCEHIS INTO :PARCEHIS-NUM-APOLICE, :PARCEHIS-NUM-ENDOSSO, :PARCEHIS-NUM-PARCELA, :PARCEHIS-OCORR-HISTORICO, :PARCEHIS-COD-OPERACAO, :CBMALPAR-DATA-MOVIMENTO, :CBMALPAR-NUM-TITULO END-EXEC. */

            if (C1PARCEHIS.Fetch())
            {
                _.Move(C1PARCEHIS.PARCEHIS_NUM_APOLICE, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE);
                _.Move(C1PARCEHIS.PARCEHIS_NUM_ENDOSSO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO);
                _.Move(C1PARCEHIS.PARCEHIS_NUM_PARCELA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA);
                _.Move(C1PARCEHIS.PARCEHIS_OCORR_HISTORICO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO);
                _.Move(C1PARCEHIS.PARCEHIS_COD_OPERACAO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO);
                _.Move(C1PARCEHIS.CBMALPAR_DATA_MOVIMENTO, CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_DATA_MOVIMENTO);
                _.Move(C1PARCEHIS.CBMALPAR_NUM_TITULO, CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_NUM_TITULO);
            }

        }

        [StopWatch]
        /*" R1510-10-FETCH-PARCEHIS-DB-CLOSE-1 */
        public void R1510_10_FETCH_PARCEHIS_DB_CLOSE_1()
        {
            /*" -612- EXEC SQL CLOSE C1PARCEHIS END-EXEC */

            C1PARCEHIS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1510_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-PROCESSA-PARCEHIS-SECTION */
        private void R1600_00_PROCESSA_PARCEHIS_SECTION()
        {
            /*" -633- MOVE '160' TO WNR-EXEC-SQL. */
            _.Move("160", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -634- MOVE PARCEHIS-NUM-APOLICE TO WS-NUM-APOLICE. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE, AREA_DE_WORK.WS_NUM_APOLICE);

            /*" -635- MOVE PARCEHIS-NUM-ENDOSSO TO WS-NUM-ENDOSSO. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO, AREA_DE_WORK.WS_NUM_ENDOSSO);

            /*" -637- MOVE PARCEHIS-NUM-PARCELA TO WS-NUM-PARCELA. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA, AREA_DE_WORK.WS_NUM_PARCELA);

            /*" -638- IF WS-FAIXA-OPER = 02 */

            if (AREA_DE_WORK.FILLER_0.WS_FAIXA_OPER == 02)
            {

                /*" -640- MOVE '2' TO CBMALPAR-SITUACAO */
                _.Move("2", CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_SITUACAO);

                /*" -641- PERFORM R1650-00-UPDATE-CBMALPAR */

                R1650_00_UPDATE_CBMALPAR_SECTION();

                /*" -642- PERFORM R2000-00-REABILITA-PARC-SUSP */

                R2000_00_REABILITA_PARC_SUSP_SECTION();

                /*" -643- ELSE */
            }
            else
            {


                /*" -644- IF WS-FAIXA-OPER = 03 OR 05 */

                if (AREA_DE_WORK.FILLER_0.WS_FAIXA_OPER.In("03", "05"))
                {

                    /*" -645- IF CBMALPAR-NUM-TITULO = ZEROS */

                    if (CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_NUM_TITULO == 00)
                    {

                        /*" -646- MOVE '0' TO CBMALPAR-SITUACAO */
                        _.Move("0", CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_SITUACAO);

                        /*" -647- PERFORM R1700-00-UPDATE-CBMALPAR */

                        R1700_00_UPDATE_CBMALPAR_SECTION();

                        /*" -648- ELSE */
                    }
                    else
                    {


                        /*" -649- MOVE '1' TO CBMALPAR-SITUACAO */
                        _.Move("1", CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_SITUACAO);

                        /*" -650- PERFORM R1700-00-UPDATE-CBMALPAR */

                        R1700_00_UPDATE_CBMALPAR_SECTION();

                        /*" -651- ELSE */
                    }

                }
                else
                {


                    /*" -652- IF WS-FAIXA-OPER = 04 */

                    if (AREA_DE_WORK.FILLER_0.WS_FAIXA_OPER == 04)
                    {

                        /*" -653- MOVE '5' TO CBMALPAR-SITUACAO */
                        _.Move("5", CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_SITUACAO);

                        /*" -653- PERFORM R1700-00-UPDATE-CBMALPAR. */

                        R1700_00_UPDATE_CBMALPAR_SECTION();
                    }

                }

            }


            /*" -0- FLUXCONTROL_PERFORM R1600_90_FETCH_PARCEHIS */

            R1600_90_FETCH_PARCEHIS();

        }

        [StopWatch]
        /*" R1600-90-FETCH-PARCEHIS */
        private void R1600_90_FETCH_PARCEHIS(bool isPerform = false)
        {
            /*" -662- PERFORM R1510-00-FETCH-PARCEHIS UNTIL WS-FIM-PARCEHIS NOT = SPACES OR PARCEHIS-NUM-APOLICE NOT = WS-NUM-APOLICE OR PARCEHIS-NUM-ENDOSSO NOT = WS-NUM-ENDOSSO OR PARCEHIS-NUM-PARCELA NOT = WS-NUM-PARCELA. */

            while (!(!AREA_DE_WORK.WS_FIM_PARCEHIS.IsEmpty() || PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE != AREA_DE_WORK.WS_NUM_APOLICE || PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO != AREA_DE_WORK.WS_NUM_ENDOSSO || PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA != AREA_DE_WORK.WS_NUM_PARCELA))
            {

                R1510_00_FETCH_PARCEHIS_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1650-00-UPDATE-CBMALPAR-SECTION */
        private void R1650_00_UPDATE_CBMALPAR_SECTION()
        {
            /*" -676- MOVE '165' TO WNR-EXEC-SQL. */
            _.Move("165", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -677- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -680- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -690- PERFORM R1650_00_UPDATE_CBMALPAR_DB_UPDATE_1 */

            R1650_00_UPDATE_CBMALPAR_DB_UPDATE_1();

            /*" -694- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -695- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -696- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -697- ADD SFT TO STT(06) */
            TOTAIS_ROT.FILLER_5[06].STT.Value = TOTAIS_ROT.FILLER_5[06].STT + WS_HORAS.SFT;

            /*" -700- ADD 1 TO SQT(06) */
            TOTAIS_ROT.FILLER_5[06].SQT.Value = TOTAIS_ROT.FILLER_5[06].SQT + 1;

            /*" -701- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -702- DISPLAY 'R1650- ERRO SELECT CB_MALA_PARCATRASO' */
                _.Display($"R1650- ERRO SELECT CB_MALA_PARCATRASO");

                /*" -703- DISPLAY 'APOLICE        = ' PARCEHIS-NUM-APOLICE */
                _.Display($"APOLICE        = {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                /*" -704- DISPLAY 'ENDOSSO        = ' PARCEHIS-NUM-ENDOSSO */
                _.Display($"ENDOSSO        = {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                /*" -705- DISPLAY 'PARCELA        = ' PARCEHIS-NUM-PARCELA */
                _.Display($"PARCELA        = {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}");

                /*" -706- DISPLAY 'DATA_MOVIMENTO = ' CBMALPAR-DATA-MOVIMENTO */
                _.Display($"DATA_MOVIMENTO = {CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_DATA_MOVIMENTO}");

                /*" -707- DISPLAY 'SITUACAO       = ' CBMALPAR-SITUACAO */
                _.Display($"SITUACAO       = {CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_SITUACAO}");

                /*" -709- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -709- ADD 1 TO AC-U-CBMALPAR. */
            AREA_DE_WORK.AC_U_CBMALPAR.Value = AREA_DE_WORK.AC_U_CBMALPAR + 1;

        }

        [StopWatch]
        /*" R1650-00-UPDATE-CBMALPAR-DB-UPDATE-1 */
        public void R1650_00_UPDATE_CBMALPAR_DB_UPDATE_1()
        {
            /*" -690- EXEC SQL UPDATE SEGUROS.CB_MALA_PARCATRASO SET SITUACAO = :CBMALPAR-SITUACAO, TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_APOLICE = :PARCEHIS-NUM-APOLICE AND NUM_ENDOSSO = :PARCEHIS-NUM-ENDOSSO AND NUM_PARCELA = :PARCEHIS-NUM-PARCELA END-EXEC. */

            var r1650_00_UPDATE_CBMALPAR_DB_UPDATE_1_Update1 = new R1650_00_UPDATE_CBMALPAR_DB_UPDATE_1_Update1()
            {
                CBMALPAR_SITUACAO = CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_SITUACAO.ToString(),
                PARCEHIS_NUM_APOLICE = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.ToString(),
                PARCEHIS_NUM_ENDOSSO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO.ToString(),
                PARCEHIS_NUM_PARCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA.ToString(),
            };

            R1650_00_UPDATE_CBMALPAR_DB_UPDATE_1_Update1.Execute(r1650_00_UPDATE_CBMALPAR_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1650_99_SAIDA*/

        [StopWatch]
        /*" R1700-00-UPDATE-CBMALPAR-SECTION */
        private void R1700_00_UPDATE_CBMALPAR_SECTION()
        {
            /*" -721- MOVE '170' TO WNR-EXEC-SQL. */
            _.Move("170", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -722- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -725- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -737- PERFORM R1700_00_UPDATE_CBMALPAR_DB_UPDATE_1 */

            R1700_00_UPDATE_CBMALPAR_DB_UPDATE_1();

            /*" -741- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -742- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -743- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -744- ADD SFT TO STT(06) */
            TOTAIS_ROT.FILLER_5[06].STT.Value = TOTAIS_ROT.FILLER_5[06].STT + WS_HORAS.SFT;

            /*" -747- ADD 1 TO SQT(06) */
            TOTAIS_ROT.FILLER_5[06].SQT.Value = TOTAIS_ROT.FILLER_5[06].SQT + 1;

            /*" -748- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -749- DISPLAY 'R1700- ERRO SELECT CB_MALA_PARCATRASO' */
                _.Display($"R1700- ERRO SELECT CB_MALA_PARCATRASO");

                /*" -750- DISPLAY 'APOLICE        = ' PARCEHIS-NUM-APOLICE */
                _.Display($"APOLICE        = {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                /*" -751- DISPLAY 'ENDOSSO        = ' PARCEHIS-NUM-ENDOSSO */
                _.Display($"ENDOSSO        = {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                /*" -752- DISPLAY 'PARCELA        = ' PARCEHIS-NUM-PARCELA */
                _.Display($"PARCELA        = {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}");

                /*" -753- DISPLAY 'DATA_MOVIMENTO = ' CBMALPAR-DATA-MOVIMENTO */
                _.Display($"DATA_MOVIMENTO = {CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_DATA_MOVIMENTO}");

                /*" -754- DISPLAY 'SITUACAO       = ' CBMALPAR-SITUACAO */
                _.Display($"SITUACAO       = {CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_SITUACAO}");

                /*" -756- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -756- ADD 1 TO AC-U-CBMALPAR. */
            AREA_DE_WORK.AC_U_CBMALPAR.Value = AREA_DE_WORK.AC_U_CBMALPAR + 1;

        }

        [StopWatch]
        /*" R1700-00-UPDATE-CBMALPAR-DB-UPDATE-1 */
        public void R1700_00_UPDATE_CBMALPAR_DB_UPDATE_1()
        {
            /*" -737- EXEC SQL UPDATE SEGUROS.CB_MALA_PARCATRASO SET SITUACAO = :CBMALPAR-SITUACAO, TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_APOLICE = :PARCEHIS-NUM-APOLICE AND NUM_ENDOSSO = :PARCEHIS-NUM-ENDOSSO AND NUM_PARCELA = :PARCEHIS-NUM-PARCELA AND DATA_MOVIMENTO = :CBMALPAR-DATA-MOVIMENTO END-EXEC. */

            var r1700_00_UPDATE_CBMALPAR_DB_UPDATE_1_Update1 = new R1700_00_UPDATE_CBMALPAR_DB_UPDATE_1_Update1()
            {
                CBMALPAR_SITUACAO = CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_SITUACAO.ToString(),
                CBMALPAR_DATA_MOVIMENTO = CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_DATA_MOVIMENTO.ToString(),
                PARCEHIS_NUM_APOLICE = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.ToString(),
                PARCEHIS_NUM_ENDOSSO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO.ToString(),
                PARCEHIS_NUM_PARCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA.ToString(),
            };

            R1700_00_UPDATE_CBMALPAR_DB_UPDATE_1_Update1.Execute(r1700_00_UPDATE_CBMALPAR_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-REABILITA-PARC-SUSP-SECTION */
        private void R2000_00_REABILITA_PARC_SUSP_SECTION()
        {
            /*" -769- MOVE '200' TO WNR-EXEC-SQL. */
            _.Move("200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -770- MOVE SPACES TO WS-FIM-MOVDEBCE. */
            _.Move("", AREA_DE_WORK.WS_FIM_MOVDEBCE);

            /*" -772- MOVE '9999-12-31' TO MOVDEBCE-DATA-VENCIMENTO. */
            _.Move("9999-12-31", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO);

            /*" -774- PERFORM R2100-00-DECLARE-MOVDEBCE. */

            R2100_00_DECLARE_MOVDEBCE_SECTION();

            /*" -776- PERFORM R2110-00-FETCH-MOVDEBCE. */

            R2110_00_FETCH_MOVDEBCE_SECTION();

            /*" -777- PERFORM R2200-00-PROCESSA-MOVDEBCE UNTIL WS-FIM-MOVDEBCE NOT = SPACES. */

            while (!(!AREA_DE_WORK.WS_FIM_MOVDEBCE.IsEmpty()))
            {

                R2200_00_PROCESSA_MOVDEBCE_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-DECLARE-MOVDEBCE-SECTION */
        private void R2100_00_DECLARE_MOVDEBCE_SECTION()
        {
            /*" -792- MOVE '210' TO WNR-EXEC-SQL. */
            _.Move("210", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -793- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -796- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -816- PERFORM R2100_00_DECLARE_MOVDEBCE_DB_DECLARE_1 */

            R2100_00_DECLARE_MOVDEBCE_DB_DECLARE_1();

            /*" -818- PERFORM R2100_00_DECLARE_MOVDEBCE_DB_OPEN_1 */

            R2100_00_DECLARE_MOVDEBCE_DB_OPEN_1();

            /*" -822- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -823- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -824- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -825- ADD SFT TO STT(07) */
            TOTAIS_ROT.FILLER_5[07].STT.Value = TOTAIS_ROT.FILLER_5[07].STT + WS_HORAS.SFT;

            /*" -828- ADD 1 TO SQT(07) */
            TOTAIS_ROT.FILLER_5[07].SQT.Value = TOTAIS_ROT.FILLER_5[07].SQT + 1;

            /*" -829- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -830- DISPLAY 'R2100 - ERRO DECLARE MOVTO_DEBITOCC_CEF' */
                _.Display($"R2100 - ERRO DECLARE MOVTO_DEBITOCC_CEF");

                /*" -830- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2100-00-DECLARE-MOVDEBCE-DB-OPEN-1 */
        public void R2100_00_DECLARE_MOVDEBCE_DB_OPEN_1()
        {
            /*" -818- EXEC SQL OPEN C0MOVDEBCE END-EXEC. */

            C0MOVDEBCE.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2110-00-FETCH-MOVDEBCE-SECTION */
        private void R2110_00_FETCH_MOVDEBCE_SECTION()
        {
            /*" -841- MOVE '211' TO WNR-EXEC-SQL. */
            _.Move("211", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R2110_10_FETCH_MOVDEBCE */

            R2110_10_FETCH_MOVDEBCE();

        }

        [StopWatch]
        /*" R2110-10-FETCH-MOVDEBCE */
        private void R2110_10_FETCH_MOVDEBCE(bool isPerform = false)
        {
            /*" -848- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -851- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -859- PERFORM R2110_10_FETCH_MOVDEBCE_DB_FETCH_1 */

            R2110_10_FETCH_MOVDEBCE_DB_FETCH_1();

            /*" -863- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -864- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -865- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -866- ADD SFT TO STT(08) */
            TOTAIS_ROT.FILLER_5[08].STT.Value = TOTAIS_ROT.FILLER_5[08].STT + WS_HORAS.SFT;

            /*" -869- ADD 1 TO SQT(08) */
            TOTAIS_ROT.FILLER_5[08].SQT.Value = TOTAIS_ROT.FILLER_5[08].SQT + 1;

            /*" -870- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -871- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -872- MOVE 'S' TO WS-FIM-MOVDEBCE */
                    _.Move("S", AREA_DE_WORK.WS_FIM_MOVDEBCE);

                    /*" -872- PERFORM R2110_10_FETCH_MOVDEBCE_DB_CLOSE_1 */

                    R2110_10_FETCH_MOVDEBCE_DB_CLOSE_1();

                    /*" -874- GO TO R2110-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2110_99_SAIDA*/ //GOTO
                    return;

                    /*" -875- ELSE */
                }
                else
                {


                    /*" -876- DISPLAY 'R2110- ERRO FETCH MOVTO_DEBITOCC_CEF' */
                    _.Display($"R2110- ERRO FETCH MOVTO_DEBITOCC_CEF");

                    /*" -879- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -882- IF APOLICES-ORGAO-EMISSOR EQUAL 100 OR 110 NEXT SENTENCE */

            if (APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR.In("100", "110"))
            {

                /*" -883- ELSE */
            }
            else
            {


                /*" -885- IF MOVDEBCE-DATA-VENCIMENTO NOT > WS-HOST-CURRENT-DATE */

                if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO <= WS_HOST_CURRENT_DATE)
                {

                    /*" -887- DISPLAY 'APOLICE/ENDOSSO COM PARCELA VENCIDA: ' PARCEHIS-NUM-APOLICE '/' PARCEHIS-NUM-ENDOSSO */

                    $"APOLICE/ENDOSSO COM PARCELA VENCIDA: {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}/{PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}"
                    .Display();

                    /*" -888- MOVE 'S' TO WS-FIM-MOVDEBCE */
                    _.Move("S", AREA_DE_WORK.WS_FIM_MOVDEBCE);

                    /*" -888- PERFORM R2110_10_FETCH_MOVDEBCE_DB_CLOSE_2 */

                    R2110_10_FETCH_MOVDEBCE_DB_CLOSE_2();

                    /*" -891- GO TO R2110-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2110_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -891- ADD 1 TO AC-L-MOVDEBCE. */
            AREA_DE_WORK.AC_L_MOVDEBCE.Value = AREA_DE_WORK.AC_L_MOVDEBCE + 1;

        }

        [StopWatch]
        /*" R2110-10-FETCH-MOVDEBCE-DB-FETCH-1 */
        public void R2110_10_FETCH_MOVDEBCE_DB_FETCH_1()
        {
            /*" -859- EXEC SQL FETCH C0MOVDEBCE INTO :MOVDEBCE-NUM-APOLICE, :MOVDEBCE-NUM-ENDOSSO, :MOVDEBCE-NUM-PARCELA, :MOVDEBCE-COD-CONVENIO, :MOVDEBCE-NSAS, :MOVDEBCE-DATA-VENCIMENTO END-EXEC. */

            if (C0MOVDEBCE.Fetch())
            {
                _.Move(C0MOVDEBCE.MOVDEBCE_NUM_APOLICE, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);
                _.Move(C0MOVDEBCE.MOVDEBCE_NUM_ENDOSSO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);
                _.Move(C0MOVDEBCE.MOVDEBCE_NUM_PARCELA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA);
                _.Move(C0MOVDEBCE.MOVDEBCE_COD_CONVENIO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);
                _.Move(C0MOVDEBCE.MOVDEBCE_NSAS, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS);
                _.Move(C0MOVDEBCE.MOVDEBCE_DATA_VENCIMENTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO);
            }

        }

        [StopWatch]
        /*" R2110-10-FETCH-MOVDEBCE-DB-CLOSE-1 */
        public void R2110_10_FETCH_MOVDEBCE_DB_CLOSE_1()
        {
            /*" -872- EXEC SQL CLOSE C0MOVDEBCE END-EXEC */

            C0MOVDEBCE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2110_99_SAIDA*/

        [StopWatch]
        /*" R2110-10-FETCH-MOVDEBCE-DB-CLOSE-2 */
        public void R2110_10_FETCH_MOVDEBCE_DB_CLOSE_2()
        {
            /*" -888- EXEC SQL CLOSE C0MOVDEBCE END-EXEC */

            C0MOVDEBCE.Close();

        }

        [StopWatch]
        /*" R2200-00-PROCESSA-MOVDEBCE-SECTION */
        private void R2200_00_PROCESSA_MOVDEBCE_SECTION()
        {
            /*" -904- MOVE '220' TO WNR-EXEC-SQL. */
            _.Move("220", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -906- PERFORM R2300-00-UPDATE-MOVDEBCE. */

            R2300_00_UPDATE_MOVDEBCE_SECTION();

            /*" -910- PERFORM R2400-00-UPDATE-PARCELAS. */

            R2400_00_UPDATE_PARCELAS_SECTION();

            /*" -910- PERFORM R2110-00-FETCH-MOVDEBCE. */

            R2110_00_FETCH_MOVDEBCE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-UPDATE-MOVDEBCE-SECTION */
        private void R2300_00_UPDATE_MOVDEBCE_SECTION()
        {
            /*" -924- MOVE '230' TO WNR-EXEC-SQL. */
            _.Move("230", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -925- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -928- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -943- PERFORM R2300_00_UPDATE_MOVDEBCE_DB_UPDATE_1 */

            R2300_00_UPDATE_MOVDEBCE_DB_UPDATE_1();

            /*" -947- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -948- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -949- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -950- ADD SFT TO STT(09) */
            TOTAIS_ROT.FILLER_5[09].STT.Value = TOTAIS_ROT.FILLER_5[09].STT + WS_HORAS.SFT;

            /*" -953- ADD 1 TO SQT(09) */
            TOTAIS_ROT.FILLER_5[09].SQT.Value = TOTAIS_ROT.FILLER_5[09].SQT + 1;

            /*" -954- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -955- DISPLAY 'R2300- ERRO UPDATE MOVTO_DEBITOCC_CEF' */
                _.Display($"R2300- ERRO UPDATE MOVTO_DEBITOCC_CEF");

                /*" -956- DISPLAY 'NUM_APOLICE  ' MOVDEBCE-NUM-APOLICE */
                _.Display($"NUM_APOLICE  {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE}");

                /*" -957- DISPLAY 'NUM_ENDOSSO  ' MOVDEBCE-NUM-ENDOSSO */
                _.Display($"NUM_ENDOSSO  {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO}");

                /*" -958- DISPLAY 'NUM_PARCELA  ' MOVDEBCE-NUM-PARCELA */
                _.Display($"NUM_PARCELA  {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA}");

                /*" -959- DISPLAY 'COD_CONVENIO ' MOVDEBCE-COD-CONVENIO */
                _.Display($"COD_CONVENIO {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO}");

                /*" -960- DISPLAY 'NSAS         ' MOVDEBCE-NSAS */
                _.Display($"NSAS         {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS}");

                /*" -962- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -962- ADD 1 TO AC-U-MOVDEBCE. */
            AREA_DE_WORK.AC_U_MOVDEBCE.Value = AREA_DE_WORK.AC_U_MOVDEBCE + 1;

        }

        [StopWatch]
        /*" R2300-00-UPDATE-MOVDEBCE-DB-UPDATE-1 */
        public void R2300_00_UPDATE_MOVDEBCE_DB_UPDATE_1()
        {
            /*" -943- EXEC SQL UPDATE SEGUROS.MOVTO_DEBITOCC_CEF SET SITUACAO_COBRANCA = ' ' , DATA_MOVIMENTO = :SISTEMAS-DATA-MOV-ABERTO, COD_USUARIO = 'CB1262B' , DATA_RETORNO = NULL, COD_RETORNO_CEF = NULL WHERE NUM_APOLICE = :MOVDEBCE-NUM-APOLICE AND NUM_ENDOSSO = :MOVDEBCE-NUM-ENDOSSO AND NUM_PARCELA = :MOVDEBCE-NUM-PARCELA AND COD_CONVENIO = :MOVDEBCE-COD-CONVENIO AND NSAS = :MOVDEBCE-NSAS END-EXEC. */

            var r2300_00_UPDATE_MOVDEBCE_DB_UPDATE_1_Update1 = new R2300_00_UPDATE_MOVDEBCE_DB_UPDATE_1_Update1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                MOVDEBCE_COD_CONVENIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.ToString(),
                MOVDEBCE_NUM_APOLICE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.ToString(),
                MOVDEBCE_NUM_ENDOSSO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO.ToString(),
                MOVDEBCE_NUM_PARCELA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA.ToString(),
                MOVDEBCE_NSAS = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS.ToString(),
            };

            R2300_00_UPDATE_MOVDEBCE_DB_UPDATE_1_Update1.Execute(r2300_00_UPDATE_MOVDEBCE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-UPDATE-PARCELAS-SECTION */
        private void R2400_00_UPDATE_PARCELAS_SECTION()
        {
            /*" -976- MOVE '240' TO WNR-EXEC-SQL. */
            _.Move("240", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -977- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -980- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -989- PERFORM R2400_00_UPDATE_PARCELAS_DB_UPDATE_1 */

            R2400_00_UPDATE_PARCELAS_DB_UPDATE_1();

            /*" -993- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -994- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -995- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -996- ADD SFT TO STT(10) */
            TOTAIS_ROT.FILLER_5[10].STT.Value = TOTAIS_ROT.FILLER_5[10].STT + WS_HORAS.SFT;

            /*" -999- ADD 1 TO SQT(10) */
            TOTAIS_ROT.FILLER_5[10].SQT.Value = TOTAIS_ROT.FILLER_5[10].SQT + 1;

            /*" -1000- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1001- DISPLAY 'R2400- ERRO UPDATE PARCELAS' */
                _.Display($"R2400- ERRO UPDATE PARCELAS");

                /*" -1002- DISPLAY 'NUM_APOLICE  ' MOVDEBCE-NUM-APOLICE */
                _.Display($"NUM_APOLICE  {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE}");

                /*" -1003- DISPLAY 'NUM_ENDOSSO  ' MOVDEBCE-NUM-ENDOSSO */
                _.Display($"NUM_ENDOSSO  {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO}");

                /*" -1004- DISPLAY 'NUM_PARCELA  ' MOVDEBCE-NUM-PARCELA */
                _.Display($"NUM_PARCELA  {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA}");

                /*" -1006- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1006- ADD 1 TO AC-U-PARCELAS. */
            AREA_DE_WORK.AC_U_PARCELAS.Value = AREA_DE_WORK.AC_U_PARCELAS + 1;

        }

        [StopWatch]
        /*" R2400-00-UPDATE-PARCELAS-DB-UPDATE-1 */
        public void R2400_00_UPDATE_PARCELAS_DB_UPDATE_1()
        {
            /*" -989- EXEC SQL UPDATE SEGUROS.PARCELAS SET SITUACAO_COBRANCA = ' ' WHERE NUM_APOLICE = :MOVDEBCE-NUM-APOLICE AND NUM_ENDOSSO = :MOVDEBCE-NUM-ENDOSSO AND NUM_PARCELA = :MOVDEBCE-NUM-PARCELA END-EXEC. */

            var r2400_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1 = new R2400_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1()
            {
                MOVDEBCE_NUM_APOLICE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.ToString(),
                MOVDEBCE_NUM_ENDOSSO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO.ToString(),
                MOVDEBCE_NUM_PARCELA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA.ToString(),
            };

            R2400_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1.Execute(r2400_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1021- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -1023- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -1026- DISPLAY LD99-ABEND. */
            _.Display(LD99_ABEND);

            /*" -1026- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1028- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -0- FLUXCONTROL_PERFORM R9999_90_MOSTRA_TOTAIS */

            R9999_90_MOSTRA_TOTAIS();

        }

        [StopWatch]
        /*" R9999-90-MOSTRA-TOTAIS */
        private void R9999_90_MOSTRA_TOTAIS(bool isPerform = false)
        {
            /*" -1034- ADD 1 TO SII. */
            WS_HORAS.SII.Value = WS_HORAS.SII + 1;

            /*" -1035- IF SII < 15 */

            if (WS_HORAS.SII < 15)
            {

                /*" -1036- MOVE STT(SII) TO STT-DISP */
                _.Move(TOTAIS_ROT.FILLER_5[WS_HORAS.SII].STT, WS_HORAS.STT_DISP);

                /*" -1038- DISPLAY 'PARAGRAFO:' SII ' TOTAL= ' STT-DISP ' QTDE= ' SQT(SII) */

                $"PARAGRAFO:{WS_HORAS.SII} TOTAL= {WS_HORAS.STT_DISP} QTDE= {TOTAIS_ROT.FILLER_5[WS_HORAS.SII]}"
                .Display();

                /*" -1039- GO TO R9999-90-MOSTRA-TOTAIS. */
                new Task(() => R9999_90_MOSTRA_TOTAIS()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -1042- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1044- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1044- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}