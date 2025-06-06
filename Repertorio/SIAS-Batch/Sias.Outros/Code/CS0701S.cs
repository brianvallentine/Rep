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
using Sias.Outros.DB2.CS0701S;

namespace Code
{
    public class CS0701S
    {
        public bool IsCall { get; set; }

        public CS0701S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-----------------------------------------------------------------      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  AUTO                               *      */
        /*"      *   PROGRAMA ...............  CS0701S                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  OLIVEIRA                           *      */
        /*"      *   PROGRAMADOR ............  OLIVEIRA                           *      */
        /*"      *   DATA CODIFICACAO .......  DEZ/2019                           *      */
        /*"      *   VERSAO .................  PROCURE WS-VERSAO                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO:                   ATUALIZAR PARAMETROS GERAIS        *      */
        /*"      *                                                                       */
        /*"      *   PARAM                  =  1 - CONGENERE                             */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *   OPERACAO             = '01' INCLUSAO                                */
        /*"      *                        = '02' ALTERACAO                               */
        /*"      *                        = '03' CONSULTA                                */
        /*"      *                        = '04' CONSULTA GERAL                          */
        /*"      *                        = '05' EXCLUSAO                                */
        /*"      *                                                                       */
        /*"      *          IND-TP-PARAMETRO:                                            */
        /*"      *                                                                       */
        /*"      *                = 1 VALOR DECIMAL (2 DECIMAIS)                         */
        /*"      *                = 2 VALOR INTEIRO                                      */
        /*"      *                = 3 VALOR PERCENTUAL (2 DECIMAIS)                      */
        /*"      *                = 4 VALOR TAXA (9 DECIMAIS)                            */
        /*"      *                = 5 DATA                                               */
        /*"      *                = 6 CHAR REDUZIDO   (15 BYTES)                         */
        /*"      *                = 7 CHAR EXTENDIDO  (60 BYTES)                         */
        /*"      *                                                                       */
        /*"      *-----------------------------------------------------------------      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01 WS-IND                         PIC  9(06)    VALUE 0.*/
        public IntBasis WS_IND { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
        /*"01 WS-VALOR                       PIC S9(13)V99 COMP-3.*/
        public DoubleBasis WS_VALOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01 WS-CONTADOR                    PIC S9(04)    COMP VALUE +0.*/
        public IntBasis WS_CONTADOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01 WS-COD-PARAM-INI               PIC S9(04)    COMP VALUE +0.*/
        public IntBasis WS_COD_PARAM_INI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01 WS-COD-PARAM-FIM               PIC S9(04)    COMP VALUE +0.*/
        public IntBasis WS_COD_PARAM_FIM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  WS-DTINIVIG-PROPOSTA               PIC  X(10) VALUE SPACES.*/
        public StringBasis WS_DTINIVIG_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"01  WS-DTINIVIG-PROPOSTA-R REDEFINES  WS-DTINIVIG-PROPOSTA.*/
        private _REDEF_CS0701S_WS_DTINIVIG_PROPOSTA_R _ws_dtinivig_proposta_r { get; set; }
        public _REDEF_CS0701S_WS_DTINIVIG_PROPOSTA_R WS_DTINIVIG_PROPOSTA_R
        {
            get { _ws_dtinivig_proposta_r = new _REDEF_CS0701S_WS_DTINIVIG_PROPOSTA_R(); _.Move(WS_DTINIVIG_PROPOSTA, _ws_dtinivig_proposta_r); VarBasis.RedefinePassValue(WS_DTINIVIG_PROPOSTA, _ws_dtinivig_proposta_r, WS_DTINIVIG_PROPOSTA); _ws_dtinivig_proposta_r.ValueChanged += () => { _.Move(_ws_dtinivig_proposta_r, WS_DTINIVIG_PROPOSTA); }; return _ws_dtinivig_proposta_r; }
            set { VarBasis.RedefinePassValue(value, _ws_dtinivig_proposta_r, WS_DTINIVIG_PROPOSTA); }
        }  //Redefines
        public class _REDEF_CS0701S_WS_DTINIVIG_PROPOSTA_R : VarBasis
        {
            /*"     05 WS-ANO-INI-PROPOSTA            PIC  9(04).*/
            public IntBasis WS_ANO_INI_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"     05 FILLER                         PIC  X(001).*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"     05 WS-MES-INI-PROPOSTA            PIC  9(02).*/
            public IntBasis WS_MES_INI_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"     05 FILLER                         PIC  X(001).*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"     05 WS-DIA-INI-PROPOSTA            PIC  9(02).*/
            public IntBasis WS_DIA_INI_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"01  WS-DTTERVIG-PROPOSTA               PIC  X(10) VALUE SPACES.*/

            public _REDEF_CS0701S_WS_DTINIVIG_PROPOSTA_R()
            {
                WS_ANO_INI_PROPOSTA.ValueChanged += OnValueChanged;
                FILLER_0.ValueChanged += OnValueChanged;
                WS_MES_INI_PROPOSTA.ValueChanged += OnValueChanged;
                FILLER_1.ValueChanged += OnValueChanged;
                WS_DIA_INI_PROPOSTA.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_DTTERVIG_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"01  WS-DTTERVIG-PROPOSTA-R REDEFINES  WS-DTTERVIG-PROPOSTA.*/
        private _REDEF_CS0701S_WS_DTTERVIG_PROPOSTA_R _ws_dttervig_proposta_r { get; set; }
        public _REDEF_CS0701S_WS_DTTERVIG_PROPOSTA_R WS_DTTERVIG_PROPOSTA_R
        {
            get { _ws_dttervig_proposta_r = new _REDEF_CS0701S_WS_DTTERVIG_PROPOSTA_R(); _.Move(WS_DTTERVIG_PROPOSTA, _ws_dttervig_proposta_r); VarBasis.RedefinePassValue(WS_DTTERVIG_PROPOSTA, _ws_dttervig_proposta_r, WS_DTTERVIG_PROPOSTA); _ws_dttervig_proposta_r.ValueChanged += () => { _.Move(_ws_dttervig_proposta_r, WS_DTTERVIG_PROPOSTA); }; return _ws_dttervig_proposta_r; }
            set { VarBasis.RedefinePassValue(value, _ws_dttervig_proposta_r, WS_DTTERVIG_PROPOSTA); }
        }  //Redefines
        public class _REDEF_CS0701S_WS_DTTERVIG_PROPOSTA_R : VarBasis
        {
            /*"     05 WS-ANO-TER-PROPOSTA            PIC  9(04).*/
            public IntBasis WS_ANO_TER_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"     05 FILLER                         PIC  X(001).*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"     05 WS-MES-TER-PROPOSTA            PIC  9(02).*/
            public IntBasis WS_MES_TER_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"     05 FILLER                         PIC  X(001).*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"     05 WS-DIA-TER-PROPOSTA            PIC  9(02).*/
            public IntBasis WS_DIA_TER_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"01  WS-DATA-AUX                        PIC  X(10) VALUE SPACES.*/

            public _REDEF_CS0701S_WS_DTTERVIG_PROPOSTA_R()
            {
                WS_ANO_TER_PROPOSTA.ValueChanged += OnValueChanged;
                FILLER_2.ValueChanged += OnValueChanged;
                WS_MES_TER_PROPOSTA.ValueChanged += OnValueChanged;
                FILLER_3.ValueChanged += OnValueChanged;
                WS_DIA_TER_PROPOSTA.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_DATA_AUX { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"01  WS-VERSAO                          PIC  X(120) VALUE    'CS0701S-VERSAO: V1 - 20012020 - 10:53HS - CAD82475 - PARAMET    'ROS GERAIS    '.*/
        public StringBasis WS_VERSAO { get; set; } = new StringBasis(new PIC("X", "120", "X(120)"), @"CS0701S-VERSAO: V1 - 20012020 - 10:53HS - CAD82475 - PARAMET    ");
        /*"01  WS-DT-ENTRADA.*/
        public CS0701S_WS_DT_ENTRADA WS_DT_ENTRADA { get; set; } = new CS0701S_WS_DT_ENTRADA();
        public class CS0701S_WS_DT_ENTRADA : VarBasis
        {
            /*"     05 WS-AA-DATE                     PIC  9(04).*/
            public IntBasis WS_AA_DATE { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"     05 WS-MM-DATA                     PIC  9(02).*/
            public IntBasis WS_MM_DATA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"     05 WS-DD-DATE                     PIC  9(02).*/
            public IntBasis WS_DD_DATE { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"01  WS-DATE-AUX1.*/
        }
        public CS0701S_WS_DATE_AUX1 WS_DATE_AUX1 { get; set; } = new CS0701S_WS_DATE_AUX1();
        public class CS0701S_WS_DATE_AUX1 : VarBasis
        {
            /*"     05 WS-AA-DATE                     PIC  9(04).*/
            public IntBasis WS_AA_DATE_0 { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"     05 FILLER                         PIC  X(001)  VALUE  '-'.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"     05 WS-MM-DATA                     PIC  9(02).*/
            public IntBasis WS_MM_DATA_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"     05 FILLER                         PIC  X(001)  VALUE  '-'.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"     05 WS-DD-DATE                     PIC  9(02).*/
            public IntBasis WS_DD_DATE_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"01 WS-DATA-ATUAL                 PIC  9(008).*/
        }
        public IntBasis WS_DATA_ATUAL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
        /*"01 WS-DATA-ATUAL-R     REDEFINES WS-DATA-ATUAL.*/
        private _REDEF_CS0701S_WS_DATA_ATUAL_R _ws_data_atual_r { get; set; }
        public _REDEF_CS0701S_WS_DATA_ATUAL_R WS_DATA_ATUAL_R
        {
            get { _ws_data_atual_r = new _REDEF_CS0701S_WS_DATA_ATUAL_R(); _.Move(WS_DATA_ATUAL, _ws_data_atual_r); VarBasis.RedefinePassValue(WS_DATA_ATUAL, _ws_data_atual_r, WS_DATA_ATUAL); _ws_data_atual_r.ValueChanged += () => { _.Move(_ws_data_atual_r, WS_DATA_ATUAL); }; return _ws_data_atual_r; }
            set { VarBasis.RedefinePassValue(value, _ws_data_atual_r, WS_DATA_ATUAL); }
        }  //Redefines
        public class _REDEF_CS0701S_WS_DATA_ATUAL_R : VarBasis
        {
            /*"     05  WS-ANO-8                PIC  9(004).*/
            public IntBasis WS_ANO_8 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"     05  WS-MES-8                PIC  9(002).*/
            public IntBasis WS_MES_8 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"     05  WS-DIA-8                PIC  9(002).*/
            public IntBasis WS_DIA_8 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"01  WS-DATA-ATUAL-DB2.*/

            public _REDEF_CS0701S_WS_DATA_ATUAL_R()
            {
                WS_ANO_8.ValueChanged += OnValueChanged;
                WS_MES_8.ValueChanged += OnValueChanged;
                WS_DIA_8.ValueChanged += OnValueChanged;
            }

        }
        public CS0701S_WS_DATA_ATUAL_DB2 WS_DATA_ATUAL_DB2 { get; set; } = new CS0701S_WS_DATA_ATUAL_DB2();
        public class CS0701S_WS_DATA_ATUAL_DB2 : VarBasis
        {
            /*"     05  WS-ANO-ATU-DB2          PIC  9(004)  VALUE  ZEROS.*/
            public IntBasis WS_ANO_ATU_DB2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"     05  WS-HIF01-ATU            PIC  X(001)  VALUE  '-'.*/
            public StringBasis WS_HIF01_ATU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"     05  WS-MES-ATU-DB2          PIC  9(002)  VALUE  ZEROS.*/
            public IntBasis WS_MES_ATU_DB2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"     05  WS-HIF02-ATU            PIC  X(001)  VALUE  '-'.*/
            public StringBasis WS_HIF02_ATU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"     05  WS-DIA-ATU-DB2          PIC  9(002)  VALUE  ZEROS.*/
            public IntBasis WS_DIA_ATU_DB2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"01  WS-DT-ATUAL-DB2            REDEFINES WS-DATA-ATUAL-DB2                                 PIC  X(010).*/
        }
        private _REDEF_StringBasis _ws_dt_atual_db2 { get; set; }
        public _REDEF_StringBasis WS_DT_ATUAL_DB2
        {
            get { _ws_dt_atual_db2 = new _REDEF_StringBasis(new PIC("X", "010", "X(010).")); ; _.Move(WS_DATA_ATUAL_DB2, _ws_dt_atual_db2); VarBasis.RedefinePassValue(WS_DATA_ATUAL_DB2, _ws_dt_atual_db2, WS_DATA_ATUAL_DB2); _ws_dt_atual_db2.ValueChanged += () => { _.Move(_ws_dt_atual_db2, WS_DATA_ATUAL_DB2); }; return _ws_dt_atual_db2; }
            set { VarBasis.RedefinePassValue(value, _ws_dt_atual_db2, WS_DATA_ATUAL_DB2); }
        }  //Redefines
        /*"01 WABEND.*/
        public CS0701S_WABEND WABEND { get; set; } = new CS0701S_WABEND();
        public class CS0701S_WABEND : VarBasis
        {
            /*"   05 FILLER                      PIC X(08) VALUE 'CS0701S'.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"CS0701S");
            /*"   05 FILLER                      PIC X(25) VALUE      '*** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "25", "X(25)"), @"*** ERRO EXEC SQL NUMERO ");
            /*"   05 WNR-EXEC-SQL                PIC X(04) VALUE SPACES.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
            /*"   05 FILLER                      PIC X(13) VALUE      ' *** SQLCODE '.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @" *** SQLCODE ");
            /*"   05 WSQLCODE                    PIC ZZZZZ999-.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-."));
        }


        public Copies.LBCS0701 LBCS0701 { get; set; } = new Copies.LBCS0701();
        public Dclgens.GE190 GE190 { get; set; } = new Dclgens.GE190();
        public CS0701S_CURGE190 CURGE190 { get; set; } = new CS0701S_CURGE190();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(LBCS0701_CS0701S_AREA_PARAMETROS LBCS0701_CS0701S_AREA_PARAMETROS_P) //PROCEDURE DIVISION USING 
        /*CS0701S_AREA_PARAMETROS*/
        {
            try
            {
                this.LBCS0701.CS0701S_AREA_PARAMETROS = LBCS0701_CS0701S_AREA_PARAMETROS_P;

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LBCS0701.CS0701S_AREA_PARAMETROS, CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -138- INITIALIZE CS0701S-TABELA-SAIDA CS0701S-COD-RETORNO CS0701S-MSG-RETORNO */
            _.Initialize(
                LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_TABELA_SAIDA
                , LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_COD_RETORNO
                , LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_MSG_RETORNO
            );

            /*" -140- PERFORM R0100-00-CRITICAR-PARAMETROS */

            R0100_00_CRITICAR_PARAMETROS_SECTION();

            /*" -142- PERFORM R1000-00-PROCESSA-LEITURA */

            R1000_00_PROCESSA_LEITURA_SECTION();

            /*" -142- PERFORM R0010-00-FINALIZAR. */

            R0010_00_FINALIZAR_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0010-00-FINALIZAR-SECTION */
        private void R0010_00_FINALIZAR_SECTION()
        {
            /*" -152- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-CRITICAR-PARAMETROS-SECTION */
        private void R0100_00_CRITICAR_PARAMETROS_SECTION()
        {
            /*" -175- DISPLAY 'CS0701S-OPE:' CS0701S-OPERACAO ' COD-PARAM:' CS0701S-COD-PARAM ' CLASSE:' CS0701S-CLASSE-PARAM ' TIPO:' CS0701S-TIPO-PARAM ' COD-SIST:' CS0701S-COD-SISTEMA ' PROD:' CS0701S-COD-PRODUTO ' STATUS:' CS0701S-STATUS ' DTINIVIG:' CS0701S-DATA-INIVIGENCIA ' DTTERVIG:' CS0701S-DATA-TERVIGENCIA ' DESC=' CS0701S-DESCRICAO */

            $"CS0701S-OPE:{LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_OPERACAO} COD-PARAM:{LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_COD_PARAM} CLASSE:{LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_CLASSE_PARAM} TIPO:{LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_TIPO_PARAM} COD-SIST:{LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_COD_SISTEMA} PROD:{LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_COD_PRODUTO} STATUS:{LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_STATUS} DTINIVIG:{LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_DATA_INIVIGENCIA} DTTERVIG:{LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_DATA_TERVIGENCIA} DESC={LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_DESCRICAO}"
            .Display();

            /*" -176- IF CS0701S-OPERACAO EQUAL SPACES */

            if (LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_OPERACAO.IsEmpty())
            {

                /*" -178- MOVE 'CS0701S - CODIGO DA OPERACAO INVALIDO' TO CS0701S-MSG-RETORNO */
                _.Move("CS0701S - CODIGO DA OPERACAO INVALIDO", LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_MSG_RETORNO);

                /*" -179- MOVE 1 TO CS0701S-COD-RETORNO */
                _.Move(1, LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_COD_RETORNO);

                /*" -180- DISPLAY CS0701S-MSG-RETORNO */
                _.Display(LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_MSG_RETORNO);

                /*" -181- PERFORM R0010-00-FINALIZAR */

                R0010_00_FINALIZAR_SECTION();

                /*" -189- END-IF */
            }


            /*" -190- IF CS0701S-OPERACAO EQUAL '01' */

            if (LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_OPERACAO == "01")
            {

                /*" -191- IF CS0701S-COD-PARAM > 0 */

                if (LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_COD_PARAM > 0)
                {

                    /*" -193- MOVE 'CS0701S - CODIGO DO PARAMETRO INVALIDO' TO CS0701S-MSG-RETORNO */
                    _.Move("CS0701S - CODIGO DO PARAMETRO INVALIDO", LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_MSG_RETORNO);

                    /*" -194- MOVE 1 TO CS0701S-COD-RETORNO */
                    _.Move(1, LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_COD_RETORNO);

                    /*" -195- DISPLAY CS0701S-MSG-RETORNO */
                    _.Display(LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_MSG_RETORNO);

                    /*" -196- PERFORM R0010-00-FINALIZAR */

                    R0010_00_FINALIZAR_SECTION();

                    /*" -197- END-IF */
                }


                /*" -199- END-IF. */
            }


            /*" -200- IF CS0701S-OPERACAO EQUAL '02' OR '03' OR '04' OR '05' */

            if (LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_OPERACAO.In("02", "03", "04", "05"))
            {

                /*" -201- IF CS0701S-COD-PARAM < 1 OR > 9999 */

                if (LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_COD_PARAM < 1 || LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_COD_PARAM > 9999)
                {

                    /*" -203- MOVE 'CS0701S - CODIGO DO PARAMETRO INVALIDO' TO CS0701S-MSG-RETORNO */
                    _.Move("CS0701S - CODIGO DO PARAMETRO INVALIDO", LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_MSG_RETORNO);

                    /*" -204- MOVE 1 TO CS0701S-COD-RETORNO */
                    _.Move(1, LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_COD_RETORNO);

                    /*" -205- DISPLAY CS0701S-MSG-RETORNO */
                    _.Display(LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_MSG_RETORNO);

                    /*" -206- PERFORM R0010-00-FINALIZAR */

                    R0010_00_FINALIZAR_SECTION();

                    /*" -207- END-IF */
                }


                /*" -210- END-IF. */
            }


            /*" -213- IF CS0701S-DATA-INIVIGENCIA EQUAL SPACES OR CS0701S-DATA-INIVIGENCIA < '1900-12-31' OR CS0701S-DATA-INIVIGENCIA > '2050-12-31' */

            if (LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_DATA_INIVIGENCIA.IsEmpty() || LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_DATA_INIVIGENCIA < "1900-12-31" || LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_DATA_INIVIGENCIA > "2050-12-31")
            {

                /*" -215- MOVE 'CS0701S - DATA INICIO DE VIGENCIA INVALIDA' TO CS0701S-MSG-RETORNO */
                _.Move("CS0701S - DATA INICIO DE VIGENCIA INVALIDA", LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_MSG_RETORNO);

                /*" -216- MOVE 1 TO CS0701S-COD-RETORNO */
                _.Move(1, LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_COD_RETORNO);

                /*" -217- DISPLAY CS0701S-MSG-RETORNO */
                _.Display(LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_MSG_RETORNO);

                /*" -218- PERFORM R0010-00-FINALIZAR */

                R0010_00_FINALIZAR_SECTION();

                /*" -221- END-IF. */
            }


            /*" -223- MOVE CS0701S-DATA-INIVIGENCIA TO WS-DTINIVIG-PROPOSTA */
            _.Move(LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_DATA_INIVIGENCIA, WS_DTINIVIG_PROPOSTA);

            /*" -224- IF CS0701S-OPERACAO EQUAL '4' */

            if (LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_OPERACAO == "4")
            {

                /*" -226- IF CS0701S-TIPO-PARAM < 1 OR CS0701S-TIPO-PARAM > 7 */

                if (LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_TIPO_PARAM < 1 || LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_TIPO_PARAM > 7)
                {

                    /*" -228- MOVE 'CS0701S - TIPO DE PARAMETRO INVALIDO' TO CS0701S-MSG-RETORNO */
                    _.Move("CS0701S - TIPO DE PARAMETRO INVALIDO", LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_MSG_RETORNO);

                    /*" -229- MOVE 1 TO CS0701S-COD-RETORNO */
                    _.Move(1, LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_COD_RETORNO);

                    /*" -230- DISPLAY CS0701S-MSG-RETORNO */
                    _.Display(LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_MSG_RETORNO);

                    /*" -231- PERFORM R0010-00-FINALIZAR */

                    R0010_00_FINALIZAR_SECTION();

                    /*" -232- END-IF */
                }


                /*" -233- END-IF */
            }


            /*" -233- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-LEITURA-SECTION */
        private void R1000_00_PROCESSA_LEITURA_SECTION()
        {
            /*" -242- MOVE 'R1000' TO WNR-EXEC-SQL. */
            _.Move("R1000", WABEND.WNR_EXEC_SQL);

            /*" -243- MOVE CS0701S-COD-PARAM TO GE190-COD-PARAMETRO */
            _.Move(LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_COD_PARAM, GE190.DCLGE_PARAM_APLICACAO.GE190_COD_PARAMETRO);

            /*" -244- MOVE CS0701S-CLASSE-PARAM TO GE190-NOM-CLASSE-PARAM */
            _.Move(LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_CLASSE_PARAM, GE190.DCLGE_PARAM_APLICACAO.GE190_NOM_CLASSE_PARAM);

            /*" -245- MOVE CS0701S-COD-SISTEMA TO GE190-COD-SISTEMA */
            _.Move(LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_COD_SISTEMA, GE190.DCLGE_PARAM_APLICACAO.GE190_COD_SISTEMA);

            /*" -246- MOVE CS0701S-COD-PRODUTO TO GE190-COD-PRODUTO */
            _.Move(LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_COD_PRODUTO, GE190.DCLGE_PARAM_APLICACAO.GE190_COD_PRODUTO);

            /*" -249- MOVE CS0701S-DATA-INIVIGENCIA TO GE190-DTA-INI-VIGENCA WS-DTINIVIG-PROPOSTA */
            _.Move(LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_DATA_INIVIGENCIA, GE190.DCLGE_PARAM_APLICACAO.GE190_DTA_INI_VIGENCA, WS_DTINIVIG_PROPOSTA);

            /*" -250- MOVE '9999-12-31' TO GE190-DTA-FIM-VIGENCIA */
            _.Move("9999-12-31", GE190.DCLGE_PARAM_APLICACAO.GE190_DTA_FIM_VIGENCIA);

            /*" -251- MOVE CS0701S-TIPO-PARAM TO GE190-IND-TP-PARAMETRO */
            _.Move(LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_TIPO_PARAM, GE190.DCLGE_PARAM_APLICACAO.GE190_IND_TP_PARAMETRO);

            /*" -252- MOVE 1 TO GE190-STA-PARAMETRO */
            _.Move(1, GE190.DCLGE_PARAM_APLICACAO.GE190_STA_PARAMETRO);

            /*" -260- MOVE 0 TO WSQLCODE */
            _.Move(0, WABEND.WSQLCODE);

            /*" -261- IF CS0701S-OPERACAO EQUAL '01' */

            if (LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_OPERACAO == "01")
            {

                /*" -262- MOVE 0 TO WS-COD-PARAM-INI */
                _.Move(0, WS_COD_PARAM_INI);

                /*" -263- MOVE 9999 TO WS-COD-PARAM-FIM */
                _.Move(9999, WS_COD_PARAM_FIM);

                /*" -264- PERFORM R1100-00-CONSULTA-GERAL */

                R1100_00_CONSULTA_GERAL_SECTION();

                /*" -266- END-IF */
            }


            /*" -267- IF CS0701S-OPERACAO EQUAL '02' */

            if (LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_OPERACAO == "02")
            {

                /*" -268- MOVE CS0701S-COD-PARAM TO WS-COD-PARAM-INI */
                _.Move(LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_COD_PARAM, WS_COD_PARAM_INI);

                /*" -269- MOVE CS0701S-COD-PARAM TO WS-COD-PARAM-FIM */
                _.Move(LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_COD_PARAM, WS_COD_PARAM_FIM);

                /*" -270- PERFORM R1100-00-CONSULTA-GERAL */

                R1100_00_CONSULTA_GERAL_SECTION();

                /*" -272- END-IF */
            }


            /*" -273- IF CS0701S-OPERACAO EQUAL '03' */

            if (LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_OPERACAO == "03")
            {

                /*" -274- PERFORM R1300-00-INCLUIR-PARAMETRO */

                R1300_00_INCLUIR_PARAMETRO_SECTION();

                /*" -276- END-IF */
            }


            /*" -277- IF CS0701S-OPERACAO EQUAL '04' */

            if (LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_OPERACAO == "04")
            {

                /*" -278- IF CS0701S-TIPO-PARAM EQUAL 1 */

                if (LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_TIPO_PARAM == 1)
                {

                    /*" -279- PERFORM R1400-00-ALTERAR-PARAMETRO-01 */

                    R1400_00_ALTERAR_PARAMETRO_01_SECTION();

                    /*" -280- END-IF */
                }


                /*" -281- END-IF */
            }


            /*" -282- IF CS0701S-OPERACAO EQUAL '05' */

            if (LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_OPERACAO == "05")
            {

                /*" -283- PERFORM R1600-00-EXCLUIR-REG */

                R1600_00_EXCLUIR_REG_SECTION();

                /*" -284- END-IF */
            }


            /*" -284- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-CONSULTA-GERAL-SECTION */
        private void R1100_00_CONSULTA_GERAL_SECTION()
        {
            /*" -294- PERFORM VARYING WS-IND FROM 1 BY 1 UNTIL WS-IND GREATER 200 */

            for (WS_IND.Value = 1; !(WS_IND > 200); WS_IND.Value += 1)
            {

                /*" -301- MOVE 0 TO CS0701S-TB-PRODUTO (WS-IND) CS0701S-TB-PARAM (WS-IND) CS0701S-TB-VALOR-DEC (WS-IND) CS0701S-TB-VALOR-INT (WS-IND) CS0701S-TB-VALOR-PCT (WS-IND) CS0701S-TB-VALOR-TAXA (WS-IND) */
                _.Move(0, LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_TABELA_SAIDA.CS0701S_TAB_SAIDA[WS_IND].CS0701S_TB_PRODUTO, LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_TABELA_SAIDA.CS0701S_TAB_SAIDA[WS_IND].CS0701S_TB_PARAM, LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_TABELA_SAIDA.CS0701S_TAB_SAIDA[WS_IND].CS0701S_TB_VALOR_DEC, LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_TABELA_SAIDA.CS0701S_TAB_SAIDA[WS_IND].CS0701S_TB_VALOR_INT, LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_TABELA_SAIDA.CS0701S_TAB_SAIDA[WS_IND].CS0701S_TB_VALOR_PCT, LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_TABELA_SAIDA.CS0701S_TAB_SAIDA[WS_IND].CS0701S_TB_VALOR_TAXA);

                /*" -309- MOVE SPACES TO CS0701S-TB-DESCRICAO (WS-IND) CS0701S-TB-DTINIVIG (WS-IND) CS0701S-TB-DTTERVIG (WS-IND) CS0701S-TB-CLASSE (WS-IND) CS0701S-TB-SISTEMA (WS-IND) CS0701S-TB-VALOR-DATA (WS-IND) CS0701S-TB-VALOR-CHAR-RED (WS-IND) CS0701S-TB-VALOR-CHAR-EXT (WS-IND) */
                _.Move("", LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_TABELA_SAIDA.CS0701S_TAB_SAIDA[WS_IND].CS0701S_TB_DESCRICAO, LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_TABELA_SAIDA.CS0701S_TAB_SAIDA[WS_IND].CS0701S_TB_DTINIVIG, LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_TABELA_SAIDA.CS0701S_TAB_SAIDA[WS_IND].CS0701S_TB_DTTERVIG, LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_TABELA_SAIDA.CS0701S_TAB_SAIDA[WS_IND].CS0701S_TB_CLASSE, LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_TABELA_SAIDA.CS0701S_TAB_SAIDA[WS_IND].CS0701S_TB_SISTEMA, LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_TABELA_SAIDA.CS0701S_TAB_SAIDA[WS_IND].CS0701S_TB_VALOR_DATA, LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_TABELA_SAIDA.CS0701S_TAB_SAIDA[WS_IND].CS0701S_TB_VALOR_CHAR_RED, LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_TABELA_SAIDA.CS0701S_TAB_SAIDA[WS_IND].CS0701S_TB_VALOR_CHAR_EXT);

                /*" -311- END-PERFORM */
            }

            /*" -313- MOVE 0 TO WS-IND */
            _.Move(0, WS_IND);

            /*" -341- PERFORM R1100_00_CONSULTA_GERAL_DB_DECLARE_1 */

            R1100_00_CONSULTA_GERAL_DB_DECLARE_1();

            /*" -343- PERFORM R1100_00_CONSULTA_GERAL_DB_OPEN_1 */

            R1100_00_CONSULTA_GERAL_DB_OPEN_1();

            /*" -346- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -347- MOVE 1 TO CS0701S-COD-RETORNO */
                _.Move(1, LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_COD_RETORNO);

                /*" -349- MOVE 'CS0701S-ERRO OPEN CURSOR CURGE190' TO CS0701S-MSG-RETORNO */
                _.Move("CS0701S-ERRO OPEN CURSOR CURGE190", LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_MSG_RETORNO);

                /*" -350- DISPLAY CS0701S-MSG-RETORNO */
                _.Display(LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_MSG_RETORNO);

                /*" -351- DISPLAY 'CS0701S-COD-SISTEMA:' GE190-COD-SISTEMA */
                _.Display($"CS0701S-COD-SISTEMA:{GE190.DCLGE_PARAM_APLICACAO.GE190_COD_SISTEMA}");

                /*" -352- DISPLAY 'CS0701S-COD-PARAM:' GE190-COD-PARAMETRO */
                _.Display($"CS0701S-COD-PARAM:{GE190.DCLGE_PARAM_APLICACAO.GE190_COD_PARAMETRO}");

                /*" -353- DISPLAY 'CS0701S-DTINIVIG ' WS-DTINIVIG-PROPOSTA */
                _.Display($"CS0701S-DTINIVIG {WS_DTINIVIG_PROPOSTA}");

                /*" -354- DISPLAY 'CS0701S-PRODUTO ' GE190-COD-PRODUTO */
                _.Display($"CS0701S-PRODUTO {GE190.DCLGE_PARAM_APLICACAO.GE190_COD_PRODUTO}");

                /*" -355- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -355- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R1100_FETCH */

            R1100_FETCH();

        }

        [StopWatch]
        /*" R1100-00-CONSULTA-GERAL-DB-DECLARE-1 */
        public void R1100_00_CONSULTA_GERAL_DB_DECLARE_1()
        {
            /*" -341- EXEC SQL DECLARE CURGE190 CURSOR FOR SELECT VALUE(COD_PARAMETRO,0) ,VALUE(COD_PRODUTO,0) ,VALUE(STA_PARAMETRO,0) ,VALUE(NOM_CLASSE_PARAM, ' ' ) ,VALUE(COD_SISTEMA, ' ' ) ,VALUE(DTA_INI_VIGENCA, '1001-01-01' ) ,VALUE(DTA_FIM_VIGENCIA, '1001-01-01' ) ,VALUE(DES_PARAMETRO, ' ' ) ,VALUE(IND_TP_PARAMETRO,0) ,VALUE(VLR_PARAMETRO,0) ,VALUE(VLR_PARAM_INT,0) ,VALUE(PCT_PARAMETRO,0) ,VALUE(VLR_PARAM_TAXA,0) ,VALUE(DTA_PARAMETRO, '1001-01-01' ) ,VALUE(VLR_PARAM_REDUZIDO, ' ' ) ,VALUE(VLR_PARAM_EXTENDIDO, ' ' ) FROM SEGUROS.GE_PARAM_APLICACAO WHERE NOM_CLASSE_PARAM =:GE190-NOM-CLASSE-PARAM AND COD_SISTEMA =:GE190-COD-SISTEMA AND COD_PRODUTO =:GE190-COD-PRODUTO AND STA_PARAMETRO = 1 AND COD_PARAMETRO BETWEEN :WS-COD-PARAM-INI AND :WS-COD-PARAM-FIM AND :WS-DTINIVIG-PROPOSTA BETWEEN DTA_INI_VIGENCA AND DTA_FIM_VIGENCIA END-EXEC. */
            CURGE190 = new CS0701S_CURGE190(true);
            string GetQuery_CURGE190()
            {
                var query = @$"SELECT VALUE(COD_PARAMETRO
							,0) 
							,VALUE(COD_PRODUTO
							,0) 
							,VALUE(STA_PARAMETRO
							,0) 
							,VALUE(NOM_CLASSE_PARAM
							, ' ' ) 
							,VALUE(COD_SISTEMA
							, ' ' ) 
							,VALUE(DTA_INI_VIGENCA
							, '1001-01-01' ) 
							,VALUE(DTA_FIM_VIGENCIA
							, '1001-01-01' ) 
							,VALUE(DES_PARAMETRO
							, ' ' ) 
							,VALUE(IND_TP_PARAMETRO
							,0) 
							,VALUE(VLR_PARAMETRO
							,0) 
							,VALUE(VLR_PARAM_INT
							,0) 
							,VALUE(PCT_PARAMETRO
							,0) 
							,VALUE(VLR_PARAM_TAXA
							,0) 
							,VALUE(DTA_PARAMETRO
							, '1001-01-01' ) 
							,VALUE(VLR_PARAM_REDUZIDO
							, ' ' ) 
							,VALUE(VLR_PARAM_EXTENDIDO
							, ' ' ) 
							FROM SEGUROS.GE_PARAM_APLICACAO 
							WHERE NOM_CLASSE_PARAM ='{GE190.DCLGE_PARAM_APLICACAO.GE190_NOM_CLASSE_PARAM}' 
							AND COD_SISTEMA ='{GE190.DCLGE_PARAM_APLICACAO.GE190_COD_SISTEMA}' 
							AND COD_PRODUTO ='{GE190.DCLGE_PARAM_APLICACAO.GE190_COD_PRODUTO}' 
							AND STA_PARAMETRO = 1 
							AND COD_PARAMETRO BETWEEN '{WS_COD_PARAM_INI}' 
							AND '{WS_COD_PARAM_FIM}' 
							AND '{WS_DTINIVIG_PROPOSTA}' BETWEEN DTA_INI_VIGENCA 
							AND DTA_FIM_VIGENCIA";

                return query;
            }
            CURGE190.GetQueryEvent += GetQuery_CURGE190;

        }

        [StopWatch]
        /*" R1100-00-CONSULTA-GERAL-DB-OPEN-1 */
        public void R1100_00_CONSULTA_GERAL_DB_OPEN_1()
        {
            /*" -343- EXEC SQL OPEN CURGE190 END-EXEC. */

            CURGE190.Open();

        }

        [StopWatch]
        /*" R1100-FETCH */
        private void R1100_FETCH(bool isPerform = false)
        {
            /*" -377- PERFORM R1100_FETCH_DB_FETCH_1 */

            R1100_FETCH_DB_FETCH_1();

            /*" -380- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -381- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -381- PERFORM R1100_FETCH_DB_CLOSE_1 */

                    R1100_FETCH_DB_CLOSE_1();

                    /*" -383- GO TO R1100-90-FIM */

                    R1100_90_FIM(); //GOTO
                    return;

                    /*" -384- ELSE */
                }
                else
                {


                    /*" -385- MOVE 1 TO CS0701S-COD-RETORNO */
                    _.Move(1, LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_COD_RETORNO);

                    /*" -387- MOVE 'CS0701S-ERRO FETCH CURSOR ' TO CS0701S-MSG-RETORNO */
                    _.Move("CS0701S-ERRO FETCH CURSOR ", LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_MSG_RETORNO);

                    /*" -388- DISPLAY CS0701S-MSG-RETORNO */
                    _.Display(LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_MSG_RETORNO);

                    /*" -389- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -390- END-IF */
                }


                /*" -392- END-IF */
            }


            /*" -393- ADD 1 TO WS-IND */
            WS_IND.Value = WS_IND + 1;

            /*" -394- MOVE GE190-COD-PARAMETRO TO CS0701S-TB-PARAM (WS-IND) */
            _.Move(GE190.DCLGE_PARAM_APLICACAO.GE190_COD_PARAMETRO, LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_TABELA_SAIDA.CS0701S_TAB_SAIDA[WS_IND].CS0701S_TB_PARAM);

            /*" -395- MOVE GE190-COD-PRODUTO TO CS0701S-TB-PRODUTO (WS-IND) */
            _.Move(GE190.DCLGE_PARAM_APLICACAO.GE190_COD_PRODUTO, LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_TABELA_SAIDA.CS0701S_TAB_SAIDA[WS_IND].CS0701S_TB_PRODUTO);

            /*" -396- MOVE GE190-STA-PARAMETRO TO CS0701S-TB-STATUS (WS-IND) */
            _.Move(GE190.DCLGE_PARAM_APLICACAO.GE190_STA_PARAMETRO, LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_TABELA_SAIDA.CS0701S_TAB_SAIDA[WS_IND].CS0701S_TB_STATUS);

            /*" -397- MOVE GE190-NOM-CLASSE-PARAM TO CS0701S-TB-CLASSE (WS-IND) */
            _.Move(GE190.DCLGE_PARAM_APLICACAO.GE190_NOM_CLASSE_PARAM, LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_TABELA_SAIDA.CS0701S_TAB_SAIDA[WS_IND].CS0701S_TB_CLASSE);

            /*" -398- MOVE GE190-COD-SISTEMA TO CS0701S-TB-SISTEMA (WS-IND) */
            _.Move(GE190.DCLGE_PARAM_APLICACAO.GE190_COD_SISTEMA, LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_TABELA_SAIDA.CS0701S_TAB_SAIDA[WS_IND].CS0701S_TB_SISTEMA);

            /*" -399- MOVE GE190-DTA-INI-VIGENCA TO CS0701S-TB-DTINIVIG (WS-IND) */
            _.Move(GE190.DCLGE_PARAM_APLICACAO.GE190_DTA_INI_VIGENCA, LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_TABELA_SAIDA.CS0701S_TAB_SAIDA[WS_IND].CS0701S_TB_DTINIVIG);

            /*" -400- MOVE GE190-DTA-FIM-VIGENCIA TO CS0701S-TB-DTTERVIG (WS-IND) */
            _.Move(GE190.DCLGE_PARAM_APLICACAO.GE190_DTA_FIM_VIGENCIA, LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_TABELA_SAIDA.CS0701S_TAB_SAIDA[WS_IND].CS0701S_TB_DTTERVIG);

            /*" -401- MOVE GE190-DES-PARAMETRO TO CS0701S-TB-DESCRICAO (WS-IND) */
            _.Move(GE190.DCLGE_PARAM_APLICACAO.GE190_DES_PARAMETRO, LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_TABELA_SAIDA.CS0701S_TAB_SAIDA[WS_IND].CS0701S_TB_DESCRICAO);

            /*" -403- MOVE GE190-IND-TP-PARAMETRO TO CS0701S-TB-IND-TP-PARAM (WS-IND) */
            _.Move(GE190.DCLGE_PARAM_APLICACAO.GE190_IND_TP_PARAMETRO, LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_TABELA_SAIDA.CS0701S_TAB_SAIDA[WS_IND].CS0701S_TB_IND_TP_PARAM);

            /*" -404- MOVE GE190-VLR-PARAMETRO TO CS0701S-TB-VALOR-DEC (WS-IND) */
            _.Move(GE190.DCLGE_PARAM_APLICACAO.GE190_VLR_PARAMETRO, LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_TABELA_SAIDA.CS0701S_TAB_SAIDA[WS_IND].CS0701S_TB_VALOR_DEC);

            /*" -405- MOVE GE190-VLR-PARAM-INT TO CS0701S-TB-VALOR-INT (WS-IND) */
            _.Move(GE190.DCLGE_PARAM_APLICACAO.GE190_VLR_PARAM_INT, LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_TABELA_SAIDA.CS0701S_TAB_SAIDA[WS_IND].CS0701S_TB_VALOR_INT);

            /*" -406- MOVE GE190-PCT-PARAMETRO TO CS0701S-TB-VALOR-PCT (WS-IND) */
            _.Move(GE190.DCLGE_PARAM_APLICACAO.GE190_PCT_PARAMETRO, LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_TABELA_SAIDA.CS0701S_TAB_SAIDA[WS_IND].CS0701S_TB_VALOR_PCT);

            /*" -408- MOVE GE190-VLR-PARAM-TAXA TO CS0701S-TB-VALOR-TAXA(WS-IND) */
            _.Move(GE190.DCLGE_PARAM_APLICACAO.GE190_VLR_PARAM_TAXA, LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_TABELA_SAIDA.CS0701S_TAB_SAIDA[WS_IND].CS0701S_TB_VALOR_TAXA);

            /*" -410- MOVE GE190-DTA-PARAMETRO TO CS0701S-TB-VALOR-DATA (WS-IND) */
            _.Move(GE190.DCLGE_PARAM_APLICACAO.GE190_DTA_PARAMETRO, LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_TABELA_SAIDA.CS0701S_TAB_SAIDA[WS_IND].CS0701S_TB_VALOR_DATA);

            /*" -412- MOVE GE190-VLR-PARAM-REDUZIDO TO CS0701S-TB-VALOR-CHAR-RED (WS-IND) */
            _.Move(GE190.DCLGE_PARAM_APLICACAO.GE190_VLR_PARAM_REDUZIDO, LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_TABELA_SAIDA.CS0701S_TAB_SAIDA[WS_IND].CS0701S_TB_VALOR_CHAR_RED);

            /*" -414- MOVE GE190-VLR-PARAM-EXTENDIDO TO CS0701S-TB-VALOR-CHAR-EXT (WS-IND) */
            _.Move(GE190.DCLGE_PARAM_APLICACAO.GE190_VLR_PARAM_EXTENDIDO, LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_TABELA_SAIDA.CS0701S_TAB_SAIDA[WS_IND].CS0701S_TB_VALOR_CHAR_EXT);

            /*" -415- MOVE GE190-VLR-PARAMETRO TO CS0701S-TB-VALOR-DEC (WS-IND) */
            _.Move(GE190.DCLGE_PARAM_APLICACAO.GE190_VLR_PARAMETRO, LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_TABELA_SAIDA.CS0701S_TAB_SAIDA[WS_IND].CS0701S_TB_VALOR_DEC);

            /*" -416- MOVE GE190-VLR-PARAM-INT TO CS0701S-TB-VALOR-INT (WS-IND) */
            _.Move(GE190.DCLGE_PARAM_APLICACAO.GE190_VLR_PARAM_INT, LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_TABELA_SAIDA.CS0701S_TAB_SAIDA[WS_IND].CS0701S_TB_VALOR_INT);

            /*" -417- MOVE GE190-PCT-PARAMETRO TO CS0701S-TB-VALOR-PCT (WS-IND) */
            _.Move(GE190.DCLGE_PARAM_APLICACAO.GE190_PCT_PARAMETRO, LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_TABELA_SAIDA.CS0701S_TAB_SAIDA[WS_IND].CS0701S_TB_VALOR_PCT);

            /*" -425- MOVE GE190-VLR-PARAM-TAXA TO CS0701S-TB-VALOR-TAXA(WS-IND) */
            _.Move(GE190.DCLGE_PARAM_APLICACAO.GE190_VLR_PARAM_TAXA, LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_TABELA_SAIDA.CS0701S_TAB_SAIDA[WS_IND].CS0701S_TB_VALOR_TAXA);

            /*" -425- GO TO R1100-FETCH. */
            new Task(() => R1100_FETCH()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R1100-FETCH-DB-FETCH-1 */
        public void R1100_FETCH_DB_FETCH_1()
        {
            /*" -377- EXEC SQL FETCH CURGE190 INTO :GE190-COD-PARAMETRO ,:GE190-COD-PRODUTO ,:GE190-STA-PARAMETRO ,:GE190-NOM-CLASSE-PARAM ,:GE190-COD-SISTEMA ,:GE190-DTA-INI-VIGENCA ,:GE190-DTA-FIM-VIGENCIA ,:GE190-DES-PARAMETRO ,:GE190-IND-TP-PARAMETRO ,:GE190-VLR-PARAMETRO ,:GE190-VLR-PARAM-INT ,:GE190-PCT-PARAMETRO ,:GE190-VLR-PARAM-TAXA ,:GE190-DTA-PARAMETRO ,:GE190-VLR-PARAM-REDUZIDO ,:GE190-VLR-PARAM-EXTENDIDO END-EXEC */

            if (CURGE190.Fetch())
            {
                _.Move(CURGE190.GE190_COD_PARAMETRO, GE190.DCLGE_PARAM_APLICACAO.GE190_COD_PARAMETRO);
                _.Move(CURGE190.GE190_COD_PRODUTO, GE190.DCLGE_PARAM_APLICACAO.GE190_COD_PRODUTO);
                _.Move(CURGE190.GE190_STA_PARAMETRO, GE190.DCLGE_PARAM_APLICACAO.GE190_STA_PARAMETRO);
                _.Move(CURGE190.GE190_NOM_CLASSE_PARAM, GE190.DCLGE_PARAM_APLICACAO.GE190_NOM_CLASSE_PARAM);
                _.Move(CURGE190.GE190_COD_SISTEMA, GE190.DCLGE_PARAM_APLICACAO.GE190_COD_SISTEMA);
                _.Move(CURGE190.GE190_DTA_INI_VIGENCA, GE190.DCLGE_PARAM_APLICACAO.GE190_DTA_INI_VIGENCA);
                _.Move(CURGE190.GE190_DTA_FIM_VIGENCIA, GE190.DCLGE_PARAM_APLICACAO.GE190_DTA_FIM_VIGENCIA);
                _.Move(CURGE190.GE190_DES_PARAMETRO, GE190.DCLGE_PARAM_APLICACAO.GE190_DES_PARAMETRO);
                _.Move(CURGE190.GE190_IND_TP_PARAMETRO, GE190.DCLGE_PARAM_APLICACAO.GE190_IND_TP_PARAMETRO);
                _.Move(CURGE190.GE190_VLR_PARAMETRO, GE190.DCLGE_PARAM_APLICACAO.GE190_VLR_PARAMETRO);
                _.Move(CURGE190.GE190_VLR_PARAM_INT, GE190.DCLGE_PARAM_APLICACAO.GE190_VLR_PARAM_INT);
                _.Move(CURGE190.GE190_PCT_PARAMETRO, GE190.DCLGE_PARAM_APLICACAO.GE190_PCT_PARAMETRO);
                _.Move(CURGE190.GE190_VLR_PARAM_TAXA, GE190.DCLGE_PARAM_APLICACAO.GE190_VLR_PARAM_TAXA);
                _.Move(CURGE190.GE190_DTA_PARAMETRO, GE190.DCLGE_PARAM_APLICACAO.GE190_DTA_PARAMETRO);
                _.Move(CURGE190.GE190_VLR_PARAM_REDUZIDO, GE190.DCLGE_PARAM_APLICACAO.GE190_VLR_PARAM_REDUZIDO);
                _.Move(CURGE190.GE190_VLR_PARAM_EXTENDIDO, GE190.DCLGE_PARAM_APLICACAO.GE190_VLR_PARAM_EXTENDIDO);
            }

        }

        [StopWatch]
        /*" R1100-FETCH-DB-CLOSE-1 */
        public void R1100_FETCH_DB_CLOSE_1()
        {
            /*" -381- EXEC SQL CLOSE CURGE190 END-EXEC */

            CURGE190.Close();

        }

        [StopWatch]
        /*" R1100-90-FIM */
        private void R1100_90_FIM(bool isPerform = false)
        {
            /*" -429- IF CS0701S-COD-PARAM > 0 */

            if (LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_COD_PARAM > 0)
            {

                /*" -430- IF CS0701S-TB-DTINIVIG(CS0701S-COD-PARAM) <= '1001-01-01' */

                if (LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_TABELA_SAIDA.CS0701S_TAB_SAIDA[LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_COD_PARAM].CS0701S_TB_DTINIVIG <= "1001-01-01")
                {

                    /*" -431- MOVE 1 TO CS0701S-COD-RETORNO */
                    _.Move(1, LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_COD_RETORNO);

                    /*" -433- MOVE 'CS0701S-PARAMETRO NAO ENCONTADO' TO CS0701S-MSG-RETORNO */
                    _.Move("CS0701S-PARAMETRO NAO ENCONTADO", LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_MSG_RETORNO);

                    /*" -434- DISPLAY CS0701S-MSG-RETORNO */
                    _.Display(LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_MSG_RETORNO);

                    /*" -435- END-IF */
                }


                /*" -436- END-IF */
            }


            /*" -436- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-CONSULTA-SECTION */
        private void R1200_00_CONSULTA_SECTION()
        {
            /*" -496- MOVE 'R1200' TO WNR-EXEC-SQL. */
            _.Move("R1200", WABEND.WNR_EXEC_SQL);

            /*" -496- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1210-00-CONSULTA-COUNT-SECTION */
        private void R1210_00_CONSULTA_COUNT_SECTION()
        {
            /*" -504- MOVE 'R1210' TO WNR-EXEC-SQL. */
            _.Move("R1210", WABEND.WNR_EXEC_SQL);

            /*" -524- MOVE 0 TO WS-CONTADOR */
            _.Move(0, WS_CONTADOR);

            /*" -524- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1210_99_SAIDA*/

        [StopWatch]
        /*" R1220-00-SELECT-COUNT-DTINIVIG-SECTION */
        private void R1220_00_SELECT_COUNT_DTINIVIG_SECTION()
        {
            /*" -532- MOVE 'R1220' TO WNR-EXEC-SQL. */
            _.Move("R1220", WABEND.WNR_EXEC_SQL);

            /*" -551- MOVE 0 TO WS-CONTADOR */
            _.Move(0, WS_CONTADOR);

            /*" -551- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1220_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-INCLUIR-PARAMETRO-SECTION */
        private void R1300_00_INCLUIR_PARAMETRO_SECTION()
        {
            /*" -674- MOVE '1300' TO WNR-EXEC-SQL. */
            _.Move("1300", WABEND.WNR_EXEC_SQL);

            /*" -674- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1305-00-INSERT-SECTION */
        private void R1305_00_INSERT_SECTION()
        {
            /*" -760- MOVE '1305' TO WNR-EXEC-SQL. */
            _.Move("1305", WABEND.WNR_EXEC_SQL);

            /*" -760- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1305_99_SAIDA*/

        [StopWatch]
        /*" R1310-00-UPDATE-PARAMETRO-SECTION */
        private void R1310_00_UPDATE_PARAMETRO_SECTION()
        {
            /*" -792- MOVE '1310' TO WNR-EXEC-SQL. */
            _.Move("1310", WABEND.WNR_EXEC_SQL);

            /*" -792- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1310_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-ALTERAR-PARAMETRO-01-SECTION */
        private void R1400_00_ALTERAR_PARAMETRO_01_SECTION()
        {
            /*" -824- MOVE '1400' TO WNR-EXEC-SQL. */
            _.Move("1400", WABEND.WNR_EXEC_SQL);

            /*" -824- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1410-00-ALTERAR-PARAMETRO-02-SECTION */
        private void R1410_00_ALTERAR_PARAMETRO_02_SECTION()
        {
            /*" -855- MOVE '1410' TO WNR-EXEC-SQL. */
            _.Move("1410", WABEND.WNR_EXEC_SQL);

            /*" -855- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1410_99_SAIDA*/

        [StopWatch]
        /*" R1420-00-ALTERAR-PARAMETRO-03-SECTION */
        private void R1420_00_ALTERAR_PARAMETRO_03_SECTION()
        {
            /*" -886- MOVE '1420' TO WNR-EXEC-SQL. */
            _.Move("1420", WABEND.WNR_EXEC_SQL);

            /*" -886- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1420_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-PESQ-DATA-SIST-SECTION */
        private void R1500_00_PESQ_DATA_SIST_SECTION()
        {
            /*" -989- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", WABEND.WNR_EXEC_SQL);

            /*" -989- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-EXCLUIR-REG-SECTION */
        private void R1600_00_EXCLUIR_REG_SECTION()
        {
            /*" -1024- MOVE '1600' TO WNR-EXEC-SQL. */
            _.Move("1600", WABEND.WNR_EXEC_SQL);

            /*" -1024- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1034- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -1036- DISPLAY WABEND */
            _.Display(WABEND);

            /*" -1036- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1038- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1042- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1042- GOBACK. */

            throw new GoBack();

        }
    }
}