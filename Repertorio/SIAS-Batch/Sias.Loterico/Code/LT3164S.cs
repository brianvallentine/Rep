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
using Sias.Loterico.DB2.LT3164S;

namespace Code
{
    public class LT3164S
    {
        public bool IsCall { get; set; }

        public LT3164S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-----------------------------------------------------------------      */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  LOTERICOS                          *      */
        /*"      *   PROGRAMA ...............  LT3164S                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  OLIVEIRA                           *      */
        /*"      *   PROGRAMADOR ............  OLIVEIRA                           *      */
        /*"      *   DATA CODIFICACAO .......  OUT/2018                           *      */
        /*"      *   VERSAO .................  V.01                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO:                   GRAVAR 1 REGISTRO NA TABELA        *      */
        /*"      *                             LT_SOLICITA_PARAM                  *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  WSQLERRMC                          PIC S9(13)  COMP.*/
        public IntBasis WSQLERRMC { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  AC-I-LTSOLPAR                      PIC  9(06).*/
        public IntBasis AC_I_LTSOLPAR { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
        /*"01  WS-VERSAO                          PIC  X(120) VALUE    'LT3164S-VERSAO: 1.0 - 02102018-17:50HS -'.*/
        public StringBasis WS_VERSAO { get; set; } = new StringBasis(new PIC("X", "120", "X(120)"), @"LT3164S-VERSAO: 1.0 - 02102018-17:50HS -");
        /*"01 WS-DATA-ATUAL                 PIC  9(008).*/
        public IntBasis WS_DATA_ATUAL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
        /*"01 WS-DATA-ATUAL-R     REDEFINES WS-DATA-ATUAL.*/
        private _REDEF_LT3164S_WS_DATA_ATUAL_R _ws_data_atual_r { get; set; }
        public _REDEF_LT3164S_WS_DATA_ATUAL_R WS_DATA_ATUAL_R
        {
            get { _ws_data_atual_r = new _REDEF_LT3164S_WS_DATA_ATUAL_R(); _.Move(WS_DATA_ATUAL, _ws_data_atual_r); VarBasis.RedefinePassValue(WS_DATA_ATUAL, _ws_data_atual_r, WS_DATA_ATUAL); _ws_data_atual_r.ValueChanged += () => { _.Move(_ws_data_atual_r, WS_DATA_ATUAL); }; return _ws_data_atual_r; }
            set { VarBasis.RedefinePassValue(value, _ws_data_atual_r, WS_DATA_ATUAL); }
        }  //Redefines
        public class _REDEF_LT3164S_WS_DATA_ATUAL_R : VarBasis
        {
            /*"     05  WS-ANO-8                PIC  9(004).*/
            public IntBasis WS_ANO_8 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"     05  WS-MES-8                PIC  9(002).*/
            public IntBasis WS_MES_8 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"     05  WS-DIA-8                PIC  9(002).*/
            public IntBasis WS_DIA_8 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"01  WS-DATA-ATUAL-DB2.*/

            public _REDEF_LT3164S_WS_DATA_ATUAL_R()
            {
                WS_ANO_8.ValueChanged += OnValueChanged;
                WS_MES_8.ValueChanged += OnValueChanged;
                WS_DIA_8.ValueChanged += OnValueChanged;
            }

        }
        public LT3164S_WS_DATA_ATUAL_DB2 WS_DATA_ATUAL_DB2 { get; set; } = new LT3164S_WS_DATA_ATUAL_DB2();
        public class LT3164S_WS_DATA_ATUAL_DB2 : VarBasis
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
        /*"01       WABEND.*/
        public LT3164S_WABEND WABEND { get; set; } = new LT3164S_WABEND();
        public class LT3164S_WABEND : VarBasis
        {
            /*"  05     FILLER                        PIC  X(008)  VALUE                                                      'LT3164S '*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"LT3164S ");
            /*"  05     FILLER                        PIC  X(025)  VALUE                                     '*** ERRO EXEC SQL NUMERO '*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"*** ERRO EXEC SQL NUMERO ");
            /*"  05     WNR-EXEC-SQL                  PIC  X(004)  VALUE SPACES*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
            /*"  05     FILLER                        PIC  X(013)  VALUE                                                 ' *** SQLCODE '*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"  05     WSQLCODE                      PIC  ZZZZZ999-.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-."));
        }


        public Copies.LBLT3164 LBLT3164 { get; set; } = new Copies.LBLT3164();
        public Dclgens.LTSOLPAR LTSOLPAR { get; set; } = new Dclgens.LTSOLPAR();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(LBLT3164_LT3164S_AREA_PARAMETROS LBLT3164_LT3164S_AREA_PARAMETROS_P) //PROCEDURE DIVISION USING 
        /*LT3164S_AREA_PARAMETROS*/
        {
            try
            {
                this.LBLT3164.LT3164S_AREA_PARAMETROS = LBLT3164_LT3164S_AREA_PARAMETROS_P;

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LBLT3164.LT3164S_AREA_PARAMETROS, CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -91- PERFORM R0100-00-CRITICAR-PARAMETROS */

            R0100_00_CRITICAR_PARAMETROS_SECTION();

            /*" -93- PERFORM R1000-00-PROCESSAR */

            R1000_00_PROCESSAR_SECTION();

            /*" -94- PERFORM R0010-00-FINALIZAR */

            R0010_00_FINALIZAR_SECTION();

            /*" -94- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0010-00-FINALIZAR-SECTION */
        private void R0010_00_FINALIZAR_SECTION()
        {
            /*" -102- GOBACK */

            throw new GoBack();

            /*" -102- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-CRITICAR-PARAMETROS-SECTION */
        private void R0100_00_CRITICAR_PARAMETROS_SECTION()
        {
            /*" -113- INITIALIZE LT3164S-COD-RETORNO LT3164S-MSG-RETORNO */
            _.Initialize(
                LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_COD_RETORNO
                , LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_MSG_RETORNO
            );

            /*" -114- MOVE FUNCTION CURRENT-DATE(1:8) TO WS-DATA-ATUAL. */
            _.Move(_.CurrentDate(0, 8), WS_DATA_ATUAL);

            /*" -115- MOVE WS-ANO-8 TO WS-ANO-ATU-DB2. */
            _.Move(WS_DATA_ATUAL_R.WS_ANO_8, WS_DATA_ATUAL_DB2.WS_ANO_ATU_DB2);

            /*" -116- MOVE WS-MES-8 TO WS-MES-ATU-DB2. */
            _.Move(WS_DATA_ATUAL_R.WS_MES_8, WS_DATA_ATUAL_DB2.WS_MES_ATU_DB2);

            /*" -118- MOVE WS-DIA-8 TO WS-DIA-ATU-DB2. */
            _.Move(WS_DATA_ATUAL_R.WS_DIA_8, WS_DATA_ATUAL_DB2.WS_DIA_ATU_DB2);

            /*" -119- IF LT3164S-COD-PROGRAMA EQUAL SPACES */

            if (LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_COD_PROGRAMA.IsEmpty())
            {

                /*" -121- MOVE 'LT3164S - CODIGO DO PROGRAMA INVALIDO' TO LT3164S-MSG-RETORNO */
                _.Move("LT3164S - CODIGO DO PROGRAMA INVALIDO", LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_MSG_RETORNO);

                /*" -122- MOVE 100 TO LT3164S-COD-RETORNO */
                _.Move(100, LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_COD_RETORNO);

                /*" -124- DISPLAY ' MSG-RETORNO=' LT3164S-MSG-RETORNO ' COD-RETORNO=' LT3164S-COD-RETORNO */

                $" MSG-RETORNO={LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_MSG_RETORNO} COD-RETORNO={LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_COD_RETORNO}"
                .Display();

                /*" -125- PERFORM R0010-00-FINALIZAR */

                R0010_00_FINALIZAR_SECTION();

                /*" -126- END-IF */
            }


            /*" -126- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSAR-SECTION */
        private void R1000_00_PROCESSAR_SECTION()
        {
            /*" -137- MOVE 'R1000' TO WNR-EXEC-SQL. */
            _.Move("R1000", WABEND.WNR_EXEC_SQL);

            /*" -139- INITIALIZE DCLLT-SOLICITA-PARAM. */
            _.Initialize(
                LTSOLPAR.DCLLT_SOLICITA_PARAM
            );

            /*" -140- MOVE LT3164S-COD-PRODUTO TO LTSOLPAR-COD-PRODUTO */
            _.Move(LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_COD_PRODUTO, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO);

            /*" -141- MOVE LT3164S-COD-CLIENTE TO LTSOLPAR-COD-CLIENTE */
            _.Move(LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_COD_CLIENTE, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_CLIENTE);

            /*" -142- MOVE LT3164S-COD-PROGRAMA TO LTSOLPAR-COD-PROGRAMA */
            _.Move(LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_COD_PROGRAMA, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA);

            /*" -143- MOVE LT3164S-TIPO-SOLICITACAO TO LTSOLPAR-TIPO-SOLICITACAO */
            _.Move(LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_TIPO_SOLICITACAO, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_TIPO_SOLICITACAO);

            /*" -144- MOVE LT3164S-COD-USUARIO TO LTSOLPAR-COD-USUARIO */
            _.Move(LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_COD_USUARIO, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_USUARIO);

            /*" -145- MOVE WS-DATA-ATUAL-DB2 TO LTSOLPAR-DATA-PREV-PROC */
            _.Move(WS_DATA_ATUAL_DB2, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_PREV_PROC);

            /*" -146- MOVE WS-DATA-ATUAL-DB2 TO LTSOLPAR-DATA-SOLICITACAO */
            _.Move(WS_DATA_ATUAL_DB2, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO);

            /*" -147- MOVE LT3164S-SIT-SOLICITACAO TO LTSOLPAR-SIT-SOLICITACAO */
            _.Move(LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_SIT_SOLICITACAO, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO);

            /*" -148- MOVE LT3164S-PARAM-DATE01 TO LTSOLPAR-PARAM-DATE01 */
            _.Move(LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_PARAM_DATE01, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01);

            /*" -149- MOVE LT3164S-PARAM-DATE02 TO LTSOLPAR-PARAM-DATE02 */
            _.Move(LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_PARAM_DATE02, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE02);

            /*" -150- MOVE LT3164S-PARAM-DATE03 TO LTSOLPAR-PARAM-DATE03 */
            _.Move(LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_PARAM_DATE03, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03);

            /*" -151- MOVE LT3164S-PARAM-SMINT01 TO LTSOLPAR-PARAM-SMINT01 */
            _.Move(LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_PARAM_SMINT01, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01);

            /*" -152- MOVE LT3164S-PARAM-SMINT02 TO LTSOLPAR-PARAM-SMINT02 */
            _.Move(LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_PARAM_SMINT02, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT02);

            /*" -153- MOVE LT3164S-PARAM-SMINT03 TO LTSOLPAR-PARAM-SMINT03 */
            _.Move(LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_PARAM_SMINT03, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT03);

            /*" -154- MOVE LT3164S-PARAM-INTG01 TO LTSOLPAR-PARAM-INTG01 */
            _.Move(LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_PARAM_INTG01, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01);

            /*" -155- MOVE LT3164S-PARAM-INTG02 TO LTSOLPAR-PARAM-INTG02 */
            _.Move(LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_PARAM_INTG02, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG02);

            /*" -156- MOVE LT3164S-PARAM-INTG03 TO LTSOLPAR-PARAM-INTG03 */
            _.Move(LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_PARAM_INTG03, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG03);

            /*" -157- MOVE LT3164S-NUM-APOLICE TO LTSOLPAR-PARAM-DEC01 */
            _.Move(LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_NUM_APOLICE, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC01);

            /*" -158- MOVE 0 TO LTSOLPAR-PARAM-DEC02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC02);

            /*" -159- MOVE 0 TO LTSOLPAR-PARAM-DEC03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC03);

            /*" -160- MOVE 0 TO LTSOLPAR-PARAM-FLOAT01 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT01);

            /*" -161- MOVE 0 TO LTSOLPAR-PARAM-FLOAT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT02);

            /*" -162- MOVE LT3164S-PARAM-CHAR01 TO LTSOLPAR-PARAM-CHAR01 */
            _.Move(LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_PARAM_CHAR01, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR01);

            /*" -163- MOVE LT3164S-PARAM-CHAR02 TO LTSOLPAR-PARAM-CHAR02 */
            _.Move(LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_PARAM_CHAR02, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR02);

            /*" -164- MOVE LT3164S-PARAM-CHAR03 TO LTSOLPAR-PARAM-CHAR03 */
            _.Move(LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_PARAM_CHAR03, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR03);

            /*" -165- MOVE LT3164S-PARAM-CHAR04 TO LTSOLPAR-PARAM-CHAR04 */
            _.Move(LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_PARAM_CHAR04, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR04);

            /*" -166- MOVE 200 TO LTSOLPAR-PARAM-CHAR05-LEN */
            _.Move(200, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR05.LTSOLPAR_PARAM_CHAR05_LEN);

            /*" -167- MOVE LT3164S-PARAM-CHAR05 TO LTSOLPAR-PARAM-CHAR05-TEXT */
            _.Move(LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_PARAM_CHAR05, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR05.LTSOLPAR_PARAM_CHAR05_TEXT);

            /*" -169- MOVE '01:01:01' TO LTSOLPAR-DTH-SOLICITACAO */
            _.Move("01:01:01", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DTH_SOLICITACAO);

            /*" -228- PERFORM R1000_00_PROCESSAR_DB_INSERT_1 */

            R1000_00_PROCESSAR_DB_INSERT_1();

            /*" -231- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -237- DISPLAY 'R1000-ERRO INSERT LT-SOLICITA_PARAM ' ' PROG:' LTSOLPAR-COD-PROGRAMA ' LOT=' LTSOLPAR-COD-CLIENTE ' APO=' LTSOLPAR-PARAM-DEC01 ' SIT=' LTSOLPAR-SIT-SOLICITACAO ' SQLCODE=' SQLCODE */

                $"R1000-ERRO INSERT LT-SOLICITA_PARAM  PROG:{LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA} LOT={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_CLIENTE} APO={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC01} SIT={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO} SQLCODE={DB.SQLCODE}"
                .Display();

                /*" -238- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -241- END-IF. */
            }


            /*" -242- ADD 1 TO AC-I-LTSOLPAR. */
            AC_I_LTSOLPAR.Value = AC_I_LTSOLPAR + 1;

            /*" -242- . */

        }

        [StopWatch]
        /*" R1000-00-PROCESSAR-DB-INSERT-1 */
        public void R1000_00_PROCESSAR_DB_INSERT_1()
        {
            /*" -228- EXEC SQL INSERT INTO SEGUROS.LT_SOLICITA_PARAM (COD_PRODUTO , COD_CLIENTE , COD_PROGRAMA , TIPO_SOLICITACAO, DATA_SOLICITACAO, COD_USUARIO , DATA_PREV_PROC , SIT_SOLICITACAO , TSTMP_SITUACAO , PARAM_DATE01 , PARAM_DATE02 , PARAM_DATE03 , PARAM_SMINT01 , PARAM_SMINT02 , PARAM_SMINT03 , PARAM_INTG01 , PARAM_INTG02 , PARAM_INTG03 , PARAM_DEC01 , PARAM_DEC02 , PARAM_DEC03 , PARAM_FLOAT01 , PARAM_FLOAT02 , PARAM_CHAR01 , PARAM_CHAR02 , PARAM_CHAR03 , PARAM_CHAR04 , PARAM_CHAR05 , DTH_SOLICITACAO ) VALUES (:LTSOLPAR-COD-PRODUTO , :LTSOLPAR-COD-CLIENTE , :LTSOLPAR-COD-PROGRAMA , :LTSOLPAR-TIPO-SOLICITACAO , :LTSOLPAR-DATA-SOLICITACAO , :LTSOLPAR-COD-USUARIO , :LTSOLPAR-DATA-PREV-PROC , :LTSOLPAR-SIT-SOLICITACAO , CURRENT TIMESTAMP , :LTSOLPAR-PARAM-DATE01 , :LTSOLPAR-PARAM-DATE02 , :LTSOLPAR-PARAM-DATE03 , :LTSOLPAR-PARAM-SMINT01 , :LTSOLPAR-PARAM-SMINT02 , :LTSOLPAR-PARAM-SMINT03 , :LTSOLPAR-PARAM-INTG01 , :LTSOLPAR-PARAM-INTG02 , :LTSOLPAR-PARAM-INTG03 , :LTSOLPAR-PARAM-DEC01 , :LTSOLPAR-PARAM-DEC02 , :LTSOLPAR-PARAM-DEC03 , :LTSOLPAR-PARAM-FLOAT01 , :LTSOLPAR-PARAM-FLOAT02 , :LTSOLPAR-PARAM-CHAR01 , :LTSOLPAR-PARAM-CHAR02 , :LTSOLPAR-PARAM-CHAR03 , :LTSOLPAR-PARAM-CHAR04 , :LTSOLPAR-PARAM-CHAR05 , :LTSOLPAR-DTH-SOLICITACAO) END-EXEC. */

            var r1000_00_PROCESSAR_DB_INSERT_1_Insert1 = new R1000_00_PROCESSAR_DB_INSERT_1_Insert1()
            {
                LTSOLPAR_COD_PRODUTO = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO.ToString(),
                LTSOLPAR_COD_CLIENTE = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_CLIENTE.ToString(),
                LTSOLPAR_COD_PROGRAMA = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA.ToString(),
                LTSOLPAR_TIPO_SOLICITACAO = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_TIPO_SOLICITACAO.ToString(),
                LTSOLPAR_DATA_SOLICITACAO = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO.ToString(),
                LTSOLPAR_COD_USUARIO = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_USUARIO.ToString(),
                LTSOLPAR_DATA_PREV_PROC = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_PREV_PROC.ToString(),
                LTSOLPAR_SIT_SOLICITACAO = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO.ToString(),
                LTSOLPAR_PARAM_DATE01 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01.ToString(),
                LTSOLPAR_PARAM_DATE02 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE02.ToString(),
                LTSOLPAR_PARAM_DATE03 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03.ToString(),
                LTSOLPAR_PARAM_SMINT01 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01.ToString(),
                LTSOLPAR_PARAM_SMINT02 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT02.ToString(),
                LTSOLPAR_PARAM_SMINT03 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT03.ToString(),
                LTSOLPAR_PARAM_INTG01 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01.ToString(),
                LTSOLPAR_PARAM_INTG02 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG02.ToString(),
                LTSOLPAR_PARAM_INTG03 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG03.ToString(),
                LTSOLPAR_PARAM_DEC01 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC01.ToString(),
                LTSOLPAR_PARAM_DEC02 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC02.ToString(),
                LTSOLPAR_PARAM_DEC03 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC03.ToString(),
                LTSOLPAR_PARAM_FLOAT01 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT01.ToString(),
                LTSOLPAR_PARAM_FLOAT02 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT02.ToString(),
                LTSOLPAR_PARAM_CHAR01 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR01.ToString(),
                LTSOLPAR_PARAM_CHAR02 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR02.ToString(),
                LTSOLPAR_PARAM_CHAR03 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR03.ToString(),
                LTSOLPAR_PARAM_CHAR04 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR04.ToString(),
                LTSOLPAR_PARAM_CHAR05 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR05.ToString(),
                LTSOLPAR_DTH_SOLICITACAO = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DTH_SOLICITACAO.ToString(),
            };

            R1000_00_PROCESSAR_DB_INSERT_1_Insert1.Execute(r1000_00_PROCESSAR_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -252- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -254- DISPLAY WABEND */
            _.Display(WABEND);

            /*" -254- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -256- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -260- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -260- GOBACK. */

            throw new GoBack();

        }
    }
}