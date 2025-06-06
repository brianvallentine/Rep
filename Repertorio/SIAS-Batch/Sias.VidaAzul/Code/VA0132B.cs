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
using Sias.VidaAzul.DB2.VA0132B;

namespace Code
{
    public class VA0132B
    {
        public bool IsCall { get; set; }

        public VA0132B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * SISTEMA ................  SIAS                                 *      */
        /*"      * PROGRAMA ...............  VA0132B                              *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ANALISTA ...............  JOAO ARAUJO                          *      */
        /*"      * PROGRAMADOR ............  JOAO ARAUJO                          *      */
        /*"      * DATA CODIFICACAO .......  15/05/2019                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO ...............  CARGA NA TABELA DE PRODUTOS SEM CAREN*      */
        /*"      *                           CIA.                                 *      */
        /*"      *                           TABELA: VA_CAMPANHA_CARENCIA         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACOES:                                                  *      */
        /*"      *                                                                *      */
        /*"      *   VERSAO IMPLANTADA  EM XX/XX/XXXX.                            *      */
        /*"      *   MOTTIVO:                                                     *      */
        /*"      *                                          PROCURAR POR V.XX     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _SCARENCIA { get; set; } = new FileBasis(new PIC("X", "080", "X(080)"));

        public FileBasis SCARENCIA
        {
            get
            {
                _.Move(REG_SCARENCIA, _SCARENCIA); VarBasis.RedefinePassValue(REG_SCARENCIA, _SCARENCIA, REG_SCARENCIA); return _SCARENCIA;
            }
        }
        public FileBasis _RCARENCIA { get; set; } = new FileBasis(new PIC("X", "080", "X(080)"));

        public FileBasis RCARENCIA
        {
            get
            {
                _.Move(REG_RCARENCIA, _RCARENCIA); VarBasis.RedefinePassValue(REG_RCARENCIA, _RCARENCIA, REG_RCARENCIA); return _RCARENCIA;
            }
        }
        /*"01        REG-SCARENCIA           PIC X(080).*/
        public StringBasis REG_SCARENCIA { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");
        /*"01        REG-RCARENCIA           PIC X(080).*/
        public StringBasis REG_RCARENCIA { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  WS-AUXILIARES.*/
        public VA0132B_WS_AUXILIARES WS_AUXILIARES { get; set; } = new VA0132B_WS_AUXILIARES();
        public class VA0132B_WS_AUXILIARES : VarBasis
        {
            /*"    05 WS-CONT-INSERT             PIC  S9(04)  COMP VALUE ZEROS.*/
            public IntBasis WS_CONT_INSERT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 WS-CONT-ALT                PIC  S9(04)  COMP VALUE ZEROS.*/
            public IntBasis WS_CONT_ALT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 WS-LIDOS                   PIC  S9(04)  COMP VALUE ZEROS.*/
            public IntBasis WS_LIDOS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 WS-FIM                     PIC   X(01)       VALUE ZEROS.*/
            public StringBasis WS_FIM { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"    05 WS-DISPLAY                 PIC   X(80)       VALUE SPACES*/
            public StringBasis WS_DISPLAY { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"");
            /*"    05 WS-STA-CARENCIA            PIC   X(01)       VALUE SPACES*/
            public StringBasis WS_STA_CARENCIA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"    05 WS-INCONSISTENCIA          PIC   X(01)       VALUE SPACES*/
            public StringBasis WS_INCONSISTENCIA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"    05 WS-CNT-INSCONSISTE         PIC   9(01)  COMP VALUE ZEROS.*/
            public IntBasis WS_CNT_INSCONSISTE { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
            /*"01  WS-CPF-CNPJ-CORR-AUX          PIC   9(014)   VALUE ZEROS.*/
        }
        public IntBasis WS_CPF_CNPJ_CORR_AUX { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
        /*"01  REG-CARENCIA.*/
        public VA0132B_REG_CARENCIA REG_CARENCIA { get; set; } = new VA0132B_REG_CARENCIA();
        public class VA0132B_REG_CARENCIA : VarBasis
        {
            /*"    05 REG-NUM-CPF-CNPJ           PIC   9(014)  VALUE ZEROS.*/
            public IntBasis REG_NUM_CPF_CNPJ { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"    05 REG-STA-CARENCIA           PIC   X(001)  VALUE SPACES.*/
            public StringBasis REG_STA_CARENCIA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"01  WRITE-CARENCIA                PIC   X(080)  VALUE SPACES.*/
        }
        public StringBasis WRITE_CARENCIA { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"");
        /*"01  WABEND.*/
        public VA0132B_WABEND WABEND { get; set; } = new VA0132B_WABEND();
        public class VA0132B_WABEND : VarBasis
        {
            /*"    05      FILLER              PIC  X(010) VALUE           ' VA0132B  '.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VA0132B  ");
            /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
            /*"    05      WNR-EXEC-SQL        PIC  X(004) VALUE    SPACES.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
            /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
            /*"    05      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD1 = '.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
            /*"    05      WSQLERRD1           PIC  ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD2 = '.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"    05      WSQLERRD2           PIC  ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
        }


        public Dclgens.VA111 VA111 { get; set; } = new Dclgens.VA111();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SCARENCIA_FILE_NAME_P, string RCARENCIA_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SCARENCIA.SetFile(SCARENCIA_FILE_NAME_P);
                RCARENCIA.SetFile(RCARENCIA_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -112- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", WABEND.WNR_EXEC_SQL);

            /*" -113- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -115- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -117- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -119- MOVE ALL '-' TO WS-DISPLAY */
            _.MoveAll("-", WS_AUXILIARES.WS_DISPLAY);

            /*" -120- DISPLAY WS-DISPLAY */
            _.Display(WS_AUXILIARES.WS_DISPLAY);

            /*" -121- DISPLAY 'PROGRAMA VA0132B - DEMANDA 200141 ' */
            _.Display($"PROGRAMA VA0132B - DEMANDA 200141 ");

            /*" -123- DISPLAY 'VERSAO V.00 000.000 15/05/2019 ' */
            _.Display($"VERSAO V.00 000.000 15/05/2019 ");

            /*" -130- DISPLAY 'VA0132B VERSAO 1 - INICIO PROCESSAMENTO EM  ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"VA0132B VERSAO 1 - INICIO PROCESSAMENTO EM  {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -132- DISPLAY WS-DISPLAY */
            _.Display(WS_AUXILIARES.WS_DISPLAY);

            /*" -133- PERFORM R1000-00-INICIO */

            R1000_00_INICIO_SECTION();

            /*" -135- PERFORM R2000-00-PROCESSA UNTIL WS-FIM EQUAL 1 */

            while (!(WS_AUXILIARES.WS_FIM == 1))
            {

                R2000_00_PROCESSA_SECTION();
            }

            /*" -136- PERFORM R9000-99-FINALIZA */

            R9000_99_FINALIZA_SECTION();

            /*" -136- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_FIN*/

        [StopWatch]
        /*" R1000-00-INICIO-SECTION */
        private void R1000_00_INICIO_SECTION()
        {
            /*" -146- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", WABEND.WNR_EXEC_SQL);

            /*" -154- INITIALIZE REG-CARENCIA WS-INCONSISTENCIA DCLVA-CAMPANHA-CARENCIA WRITE-CARENCIA WS-CPF-CNPJ-CORR-AUX REPLACING ALPHANUMERIC BY SPACES NUMERIC BY ZEROS */
            _.Initialize(
                REG_CARENCIA
                , WS_AUXILIARES.WS_INCONSISTENCIA
                , VA111.DCLVA_CAMPANHA_CARENCIA
                , WRITE_CARENCIA
                , WS_CPF_CNPJ_CORR_AUX
            );

            /*" -155- OPEN INPUT SCARENCIA */
            SCARENCIA.Open(REG_SCARENCIA);

            /*" -157- OUTPUT RCARENCIA */
            RCARENCIA.Open(REG_RCARENCIA);

            /*" -159- PERFORM R1100-00-LER-ENTRADA */

            R1100_00_LER_ENTRADA_SECTION();

            /*" -160- IF WS-FIM EQUAL 1 */

            if (WS_AUXILIARES.WS_FIM == 1)
            {

                /*" -161- DISPLAY 'ARQUIVO PARA CARGA VAZIO.  ' */
                _.Display($"ARQUIVO PARA CARGA VAZIO.  ");

                /*" -162- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -164- END-IF */
            }


            /*" -164- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-LER-ENTRADA-SECTION */
        private void R1100_00_LER_ENTRADA_SECTION()
        {
            /*" -174- READ SCARENCIA INTO REG-CARENCIA AT END */
            try
            {
                SCARENCIA.Read(() =>
                {

                    /*" -176- MOVE 1 TO WS-FIM */
                    _.Move(1, WS_AUXILIARES.WS_FIM);

                    /*" -177- NOT AT END */
                }, () =>
                {

                    /*" -178- ADD 1 TO WS-LIDOS */
                    WS_AUXILIARES.WS_LIDOS.Value = WS_AUXILIARES.WS_LIDOS + 1;

                    /*" -180- END-READ */
                });

                _.Move(SCARENCIA.Value, REG_CARENCIA); _.Move(SCARENCIA.Value, REG_SCARENCIA);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -181- MOVE REG-NUM-CPF-CNPJ TO WS-CPF-CNPJ-CORR-AUX */
            _.Move(REG_CARENCIA.REG_NUM_CPF_CNPJ, WS_CPF_CNPJ_CORR_AUX);

            /*" -181- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-PROCESSA-SECTION */
        private void R2000_00_PROCESSA_SECTION()
        {
            /*" -191- MOVE '2000' TO WNR-EXEC-SQL */
            _.Move("2000", WABEND.WNR_EXEC_SQL);

            /*" -193- MOVE SPACES TO WS-INCONSISTENCIA */
            _.Move("", WS_AUXILIARES.WS_INCONSISTENCIA);

            /*" -195- PERFORM R2100-00-VALIDA-ENTRADA */

            R2100_00_VALIDA_ENTRADA_SECTION();

            /*" -197- MOVE 'VA0132B' TO VA111-COD-USUARIO */
            _.Move("VA0132B", VA111.DCLVA_CAMPANHA_CARENCIA.VA111_COD_USUARIO);

            /*" -198- IF WS-INCONSISTENCIA NOT = 'S' */

            if (WS_AUXILIARES.WS_INCONSISTENCIA != "S")
            {

                /*" -199- PERFORM R2200-00-PROCESSA-INSERT */

                R2200_00_PROCESSA_INSERT_SECTION();

                /*" -201- END-IF */
            }


            /*" -202- PERFORM R1100-00-LER-ENTRADA */

            R1100_00_LER_ENTRADA_SECTION();

            /*" -202- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-VALIDA-ENTRADA-SECTION */
        private void R2100_00_VALIDA_ENTRADA_SECTION()
        {
            /*" -212- MOVE '2100' TO WNR-EXEC-SQL */
            _.Move("2100", WABEND.WNR_EXEC_SQL);

            /*" -214- MOVE WS-CPF-CNPJ-CORR-AUX TO VA111-NUM-CPF-CNPJ */
            _.Move(WS_CPF_CNPJ_CORR_AUX, VA111.DCLVA_CAMPANHA_CARENCIA.VA111_NUM_CPF_CNPJ);

            /*" -224- IF VA111-NUM-CPF-CNPJ = 11111111111 OR 22222222222 OR 33333333333 OR 44444444444 OR 55555555555 OR 66666666666 OR 77777777777 OR 88888888888 OR 99999999999 */

            if (VA111.DCLVA_CAMPANHA_CARENCIA.VA111_NUM_CPF_CNPJ.In("11111111111", "22222222222", "33333333333", "44444444444", "55555555555", "66666666666", "77777777777", "88888888888", "99999999999"))
            {

                /*" -231- STRING REG-NUM-CPF-CNPJ REG-STA-CARENCIA 'CPF/CNPG INVALIDO. ' DELIMITED BY SIZE INTO WRITE-CARENCIA END-STRING */
                #region STRING
                var spl1 = REG_CARENCIA.REG_NUM_CPF_CNPJ.GetMoveValues();
                var spl2 = REG_CARENCIA.REG_STA_CARENCIA.GetMoveValues();
                spl2 += "CPF/CNPG INVALIDO. ";
                var results3 = spl1 + spl2;
                _.Move(results3, WRITE_CARENCIA);
                #endregion

                /*" -232- WRITE REG-RCARENCIA FROM WRITE-CARENCIA */
                _.Move(WRITE_CARENCIA.GetMoveValues(), REG_RCARENCIA);

                RCARENCIA.Write(REG_RCARENCIA.GetMoveValues().ToString());

                /*" -233- MOVE 'S' TO WS-INCONSISTENCIA */
                _.Move("S", WS_AUXILIARES.WS_INCONSISTENCIA);

                /*" -234- ADD 1 TO WS-CNT-INSCONSISTE */
                WS_AUXILIARES.WS_CNT_INSCONSISTE.Value = WS_AUXILIARES.WS_CNT_INSCONSISTE + 1;

                /*" -235- GO TO R2100-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/ //GOTO
                return;

                /*" -237- END-IF */
            }


            /*" -250- IF VA111-NUM-CPF-CNPJ = 000000000000000 OR 000000000000091 OR 000000000000101 OR 000000000000191 OR 000000000001910 OR 000000000019100 OR 000001910000000 OR 000009100000000 OR 000010000000000 OR 000011000000000 OR 000011111111111 OR 000017500000000 OR 000019100000000 OR 000020000000000 OR 000022222222222 OR 000030000000000 OR 000040000000000 OR 000050000000000 OR 000060000000000 OR 000070000000000 OR 000080000000000 OR 000090000000000 OR 000099000000000 OR 000099900000000 OR 000099990000000 OR 000099999000000 OR 000099999964001 OR 000099999999990 OR 000099999999999 OR 099999999999999 OR 000360306000104 OR 034020354000110 */

            if (VA111.DCLVA_CAMPANHA_CARENCIA.VA111_NUM_CPF_CNPJ.In("000000000000000", "000000000000091", "000000000000101", "000000000000191", "000000000001910", "000000000019100", "000001910000000", "000009100000000", "000010000000000", "000011000000000", "000011111111111", "000017500000000", "000019100000000", "000020000000000", "000022222222222", "000030000000000", "000040000000000", "000050000000000", "000060000000000", "000070000000000", "000080000000000", "000090000000000", "000099000000000", "000099900000000", "000099990000000", "000099999000000", "000099999964001", "000099999999990", "000099999999999", "099999999999999", "000360306000104", "034020354000110"))
            {

                /*" -257- STRING REG-NUM-CPF-CNPJ REG-STA-CARENCIA ' CPF/CNPG INVALIDO. ' DELIMITED BY SIZE INTO WRITE-CARENCIA END-STRING */
                #region STRING
                var spl3 = REG_CARENCIA.REG_NUM_CPF_CNPJ.GetMoveValues();
                var spl4 = REG_CARENCIA.REG_STA_CARENCIA.GetMoveValues();
                spl4 += " CPF/CNPG INVALIDO. ";
                var results5 = spl3 + spl4;
                _.Move(results5, WRITE_CARENCIA);
                #endregion

                /*" -258- WRITE REG-RCARENCIA FROM REG-CARENCIA */
                _.Move(REG_CARENCIA.GetMoveValues(), REG_RCARENCIA);

                RCARENCIA.Write(REG_RCARENCIA.GetMoveValues().ToString());

                /*" -259- MOVE 'S' TO WS-INCONSISTENCIA */
                _.Move("S", WS_AUXILIARES.WS_INCONSISTENCIA);

                /*" -260- ADD 1 TO WS-CNT-INSCONSISTE */
                WS_AUXILIARES.WS_CNT_INSCONSISTE.Value = WS_AUXILIARES.WS_CNT_INSCONSISTE + 1;

                /*" -261- GO TO R2100-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/ //GOTO
                return;

                /*" -262- END-IF */
            }


            /*" -262- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-PROCESSA-INSERT-SECTION */
        private void R2200_00_PROCESSA_INSERT_SECTION()
        {
            /*" -272- MOVE '2200' TO WNR-EXEC-SQL */
            _.Move("2200", WABEND.WNR_EXEC_SQL);

            /*" -284- PERFORM R2200_00_PROCESSA_INSERT_DB_INSERT_1 */

            R2200_00_PROCESSA_INSERT_DB_INSERT_1();

            /*" -287-  EVALUATE SQLCODE  */

            /*" -288-  WHEN ZEROS  */

            /*" -288- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -289- ADD 1 TO WS-CONT-INSERT */
                WS_AUXILIARES.WS_CONT_INSERT.Value = WS_AUXILIARES.WS_CONT_INSERT + 1;

                /*" -290-  WHEN -803  */

                /*" -290- ELSE IF   SQLCODE EQUALS  -803 */
            }
            else

            if (DB.SQLCODE == -803)
            {

                /*" -291- PERFORM R2210-ATUALIZA-REGISTRO */

                R2210_ATUALIZA_REGISTRO_SECTION();

                /*" -292-  WHEN OTHER  */

                /*" -292- ELSE */
            }
            else
            {


                /*" -293- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -294-  END-EVALUATE  */

                /*" -294- END-IF */
            }


            /*" -294- . */

        }

        [StopWatch]
        /*" R2200-00-PROCESSA-INSERT-DB-INSERT-1 */
        public void R2200_00_PROCESSA_INSERT_DB_INSERT_1()
        {
            /*" -284- EXEC SQL INSERT INTO SEGUROS.VA_CAMPANHA_CARENCIA ( NUM_CPF_CNPJ ,COD_USUARIO ,DTH_INCLUSAO ) VALUES ( :VA111-NUM-CPF-CNPJ ,:VA111-COD-USUARIO , CURRENT TIMESTAMP ) END-EXEC */

            var r2200_00_PROCESSA_INSERT_DB_INSERT_1_Insert1 = new R2200_00_PROCESSA_INSERT_DB_INSERT_1_Insert1()
            {
                VA111_NUM_CPF_CNPJ = VA111.DCLVA_CAMPANHA_CARENCIA.VA111_NUM_CPF_CNPJ.ToString(),
                VA111_COD_USUARIO = VA111.DCLVA_CAMPANHA_CARENCIA.VA111_COD_USUARIO.ToString(),
            };

            R2200_00_PROCESSA_INSERT_DB_INSERT_1_Insert1.Execute(r2200_00_PROCESSA_INSERT_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2210-ATUALIZA-REGISTRO-SECTION */
        private void R2210_ATUALIZA_REGISTRO_SECTION()
        {
            /*" -304- MOVE '2210' TO WNR-EXEC-SQL */
            _.Move("2210", WABEND.WNR_EXEC_SQL);

            /*" -306- PERFORM R2211-00-VERIFICA-SITUACAO */

            R2211_00_VERIFICA_SITUACAO_SECTION();

            /*" -307- IF REG-STA-CARENCIA NOT = ( 'S' AND 'N' ) */

            if (!REG_CARENCIA.REG_STA_CARENCIA.In("S", "N"))
            {

                /*" -314- STRING REG-NUM-CPF-CNPJ REG-STA-CARENCIA ' STATUS CARENCIA INVALIDO.' DELIMITED BY SIZE INTO WRITE-CARENCIA END-STRING */
                #region STRING
                var spl5 = REG_CARENCIA.REG_NUM_CPF_CNPJ.GetMoveValues();
                var spl6 = REG_CARENCIA.REG_STA_CARENCIA.GetMoveValues();
                spl6 += " STATUS CARENCIA INVALIDO.";
                var results7 = spl5 + spl6;
                _.Move(results7, WRITE_CARENCIA);
                #endregion

                /*" -315- WRITE REG-RCARENCIA FROM WRITE-CARENCIA */
                _.Move(WRITE_CARENCIA.GetMoveValues(), REG_RCARENCIA);

                RCARENCIA.Write(REG_RCARENCIA.GetMoveValues().ToString());

                /*" -316- ADD 1 TO WS-CNT-INSCONSISTE */
                WS_AUXILIARES.WS_CNT_INSCONSISTE.Value = WS_AUXILIARES.WS_CNT_INSCONSISTE + 1;

                /*" -317- GO TO R2210-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2210_99_SAIDA*/ //GOTO
                return;

                /*" -318- ELSE */
            }
            else
            {


                /*" -320- MOVE REG-STA-CARENCIA TO VA111-STA-CARENCIA */
                _.Move(REG_CARENCIA.REG_STA_CARENCIA, VA111.DCLVA_CAMPANHA_CARENCIA.VA111_STA_CARENCIA);

                /*" -327- PERFORM R2210_ATUALIZA_REGISTRO_DB_UPDATE_1 */

                R2210_ATUALIZA_REGISTRO_DB_UPDATE_1();

                /*" -330- IF SQLCODE NOT = +0 */

                if (DB.SQLCODE != +0)
                {

                    /*" -331- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -333- END-IF */
                }


                /*" -335- ADD 1 TO WS-CONT-ALT */
                WS_AUXILIARES.WS_CONT_ALT.Value = WS_AUXILIARES.WS_CONT_ALT + 1;

                /*" -336- END-IF */
            }


            /*" -336- . */

        }

        [StopWatch]
        /*" R2210-ATUALIZA-REGISTRO-DB-UPDATE-1 */
        public void R2210_ATUALIZA_REGISTRO_DB_UPDATE_1()
        {
            /*" -327- EXEC SQL UPDATE SEGUROS.VA_CAMPANHA_CARENCIA SET STA_CARENCIA = :REG-STA-CARENCIA , COD_USUARIO = :VA111-COD-USUARIO , DTH_INCLUSAO = CURRENT TIMESTAMP WHERE NUM_CPF_CNPJ = :VA111-NUM-CPF-CNPJ AND STA_CARENCIA = :WS-STA-CARENCIA END-EXEC */

            var r2210_ATUALIZA_REGISTRO_DB_UPDATE_1_Update1 = new R2210_ATUALIZA_REGISTRO_DB_UPDATE_1_Update1()
            {
                VA111_COD_USUARIO = VA111.DCLVA_CAMPANHA_CARENCIA.VA111_COD_USUARIO.ToString(),
                REG_STA_CARENCIA = REG_CARENCIA.REG_STA_CARENCIA.ToString(),
                VA111_NUM_CPF_CNPJ = VA111.DCLVA_CAMPANHA_CARENCIA.VA111_NUM_CPF_CNPJ.ToString(),
                WS_STA_CARENCIA = WS_AUXILIARES.WS_STA_CARENCIA.ToString(),
            };

            R2210_ATUALIZA_REGISTRO_DB_UPDATE_1_Update1.Execute(r2210_ATUALIZA_REGISTRO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2210_99_SAIDA*/

        [StopWatch]
        /*" R2211-00-VERIFICA-SITUACAO-SECTION */
        private void R2211_00_VERIFICA_SITUACAO_SECTION()
        {
            /*" -345- MOVE '2211' TO WNR-EXEC-SQL */
            _.Move("2211", WABEND.WNR_EXEC_SQL);

            /*" -347- INITIALIZE WS-STA-CARENCIA */
            _.Initialize(
                WS_AUXILIARES.WS_STA_CARENCIA
            );

            /*" -353- PERFORM R2211_00_VERIFICA_SITUACAO_DB_SELECT_1 */

            R2211_00_VERIFICA_SITUACAO_DB_SELECT_1();

            /*" -356- IF SQLCODE NOT = ( +0 AND +100 ) */

            if (!DB.SQLCODE.In("+0", "+100"))
            {

                /*" -357- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -358- END-IF */
            }


            /*" -358- . */

        }

        [StopWatch]
        /*" R2211-00-VERIFICA-SITUACAO-DB-SELECT-1 */
        public void R2211_00_VERIFICA_SITUACAO_DB_SELECT_1()
        {
            /*" -353- EXEC SQL SELECT DISTINCT STA_CARENCIA INTO :WS-STA-CARENCIA FROM SEGUROS.VA_CAMPANHA_CARENCIA WHERE NUM_CPF_CNPJ = :VA111-NUM-CPF-CNPJ END-EXEC */

            var r2211_00_VERIFICA_SITUACAO_DB_SELECT_1_Query1 = new R2211_00_VERIFICA_SITUACAO_DB_SELECT_1_Query1()
            {
                VA111_NUM_CPF_CNPJ = VA111.DCLVA_CAMPANHA_CARENCIA.VA111_NUM_CPF_CNPJ.ToString(),
            };

            var executed_1 = R2211_00_VERIFICA_SITUACAO_DB_SELECT_1_Query1.Execute(r2211_00_VERIFICA_SITUACAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_STA_CARENCIA, WS_AUXILIARES.WS_STA_CARENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2211_00_SAI*/

        [StopWatch]
        /*" R9000-99-FINALIZA-SECTION */
        private void R9000_99_FINALIZA_SECTION()
        {
            /*" -366- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -370- CLOSE SCARENCIA RCARENCIA */
            SCARENCIA.Close();
            RCARENCIA.Close();

            /*" -372- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -373- DISPLAY ' ' */
            _.Display($" ");

            /*" -374- DISPLAY 'LIDOS ................: ' WS-LIDOS */
            _.Display($"LIDOS ................: {WS_AUXILIARES.WS_LIDOS}");

            /*" -375- DISPLAY 'ADICIONADOS ..........: ' WS-CONT-INSERT */
            _.Display($"ADICIONADOS ..........: {WS_AUXILIARES.WS_CONT_INSERT}");

            /*" -376- DISPLAY 'ALTERADOS ............: ' WS-CONT-ALT */
            _.Display($"ALTERADOS ............: {WS_AUXILIARES.WS_CONT_ALT}");

            /*" -378- DISPLAY 'INCONSISTENTES .......: ' WS-CNT-INSCONSISTE */
            _.Display($"INCONSISTENTES .......: {WS_AUXILIARES.WS_CNT_INSCONSISTE}");

            /*" -379- DISPLAY ' ' */
            _.Display($" ");

            /*" -387- DISPLAY 'VA0132B VERSAO 1 - FIM DO PROCESSAMENTO EM  ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"VA0132B VERSAO 1 - FIM DO PROCESSAMENTO EM  {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -389- DISPLAY WS-DISPLAY */
            _.Display(WS_AUXILIARES.WS_DISPLAY);

            /*" -389- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -399- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -400- MOVE SQLERRD(1) TO WSQLERRD1 */
            _.Move(DB.SQLERRD[1], WABEND.WSQLERRD1);

            /*" -401- MOVE SQLERRD(2) TO WSQLERRD2 */
            _.Move(DB.SQLERRD[2], WABEND.WSQLERRD2);

            /*" -403- DISPLAY WABEND */
            _.Display(WABEND);

            /*" -403- EXEC SQL ROLLBACK WORK END-EXEC */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -408- CLOSE SCARENCIA RCARENCIA */
            SCARENCIA.Close();
            RCARENCIA.Close();

            /*" -410- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -410- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}