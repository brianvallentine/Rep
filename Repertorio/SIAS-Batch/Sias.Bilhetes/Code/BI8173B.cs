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
using Sias.Bilhetes.DB2.BI8173B;

namespace Code
{
    public class BI8173B
    {
        public bool IsCall { get; set; }

        public BI8173B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      ******************************************************************      */
        /*"      *                    OBJETIVO DO PROGRAMA                        F      */
        /*"      ******************************************************************      */
        /*"      *  CAD-143483                                                    *      */
        /*"      *  DATA: 25/11/2016                                              *      */
        /*"      *  ANALISTA/PROGRAMADOR: MAURO ROCHA DA CRUZ                     *      */
        /*"      *                                                                *      */
        /*"      *  GERA ARQUIVO CONTENDO O EXTRATO PARA FATURAMENTO MENSAL ELO.  *      */
        /*"      *                                                                *      */
        /*"      *        PRODUTOS 6917 A 6921 - SEGURO VIAGEM ELO                *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *                         ALTERACOES                             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 03 - HERVAL SOUZA                                     *      */
        /*"      *             - REVER PRODUTOS NAO MIGRAM PARA JV1               *      */
        /*"      *                                                                *      */
        /*"      *    EM 01/01/2021                       PROCURE POR V.03        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 02 - GERALDO NAKAJIMA                                 *      */
        /*"      *             - PREPARAR   PROGRAMA PARA PROCESSAMENTO DA mV1    *      */
        /*"      *                                                                *      */
        /*"      *    EM 06/02/2019 - ATOS BR                                     *      */
        /*"      *                                        PROCURE POR JV1         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _RBI8173A { get; set; } = new FileBasis(new PIC("X", "200", "X(200)"));

        public FileBasis RBI8173A
        {
            get
            {
                _.Move(RBI8173A_RECORD, _RBI8173A); VarBasis.RedefinePassValue(RBI8173A_RECORD, _RBI8173A, RBI8173A_RECORD); return _RBI8173A;
            }
        }
        /*"01                RBI8173A-RECORD     PIC X(200).*/
        public StringBasis RBI8173A_RECORD { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"    05  WS-CABEC-01.*/
        public BI8173B_WS_CABEC_01 WS_CABEC_01 { get; set; } = new BI8173B_WS_CABEC_01();
        public class BI8173B_WS_CABEC_01 : VarBasis
        {
            /*"        10  FILLER              PIC X(57) VALUE       'BI8173B - EXTRATO MENSAL DE OPERA��ES SEGURO VIAGEM ELO'*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "57", "X(57)"), @"BI8173B - EXTRATO MENSAL DE OPERA��ES SEGURO VIAGEM ELO");
            /*"    05  WS-CABEC-03.*/
        }
        public BI8173B_WS_CABEC_03 WS_CABEC_03 { get; set; } = new BI8173B_WS_CABEC_03();
        public class BI8173B_WS_CABEC_03 : VarBasis
        {
            /*"        10  FILLER              PIC X(57) VALUE       '          ELO SERVI�OS S.A - CNPJ 09.227.084/0001-75   '*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "57", "X(57)"), @"          ELO SERVI�OS S.A - CNPJ 09.227.084/0001-75   ");
            /*"    05  WS-CABEC-04.*/
        }
        public BI8173B_WS_CABEC_04 WS_CABEC_04 { get; set; } = new BI8173B_WS_CABEC_04();
        public class BI8173B_WS_CABEC_04 : VarBasis
        {
            /*"        10  FILLER              PIC X(57) VALUE       '          ALAMEDA XINGU, N� 512, 5� andar              '*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "57", "X(57)"), @"          ALAMEDA XINGU, N� 512, 5� andar              ");
            /*"    05  WS-CABEC-05.*/
        }
        public BI8173B_WS_CABEC_05 WS_CABEC_05 { get; set; } = new BI8173B_WS_CABEC_05();
        public class BI8173B_WS_CABEC_05 : VarBasis
        {
            /*"        10  FILLER              PIC X(57) VALUE       '          BARUERI - SP                                 '*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "57", "X(57)"), @"          BARUERI - SP                                 ");
            /*"    05  WS-CABEC-06.*/
        }
        public BI8173B_WS_CABEC_06 WS_CABEC_06 { get; set; } = new BI8173B_WS_CABEC_06();
        public class BI8173B_WS_CABEC_06 : VarBasis
        {
            /*"        10  FILLER              PIC X(57) VALUE       '          CEP - 06455-030                              '*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "57", "X(57)"), @"          CEP - 06455-030                              ");
            /*"    05  WS-CABEC-07.*/
        }
        public BI8173B_WS_CABEC_07 WS_CABEC_07 { get; set; } = new BI8173B_WS_CABEC_07();
        public class BI8173B_WS_CABEC_07 : VarBasis
        {
            /*"        10  FILLER              PIC X(059) VALUE         '     TOTAL      ;DATA EMIS.;      VALOR PAGO    ;QT PRO         'P;'.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "59", "X(059)"), @"     TOTAL      ;DATA EMIS.;      VALOR PAGO    ;QT PRO         ");
            /*"    05  WS-REG-DET-EXTRATO.*/
        }
        public BI8173B_WS_REG_DET_EXTRATO WS_REG_DET_EXTRATO { get; set; } = new BI8173B_WS_REG_DET_EXTRATO();
        public class BI8173B_WS_REG_DET_EXTRATO : VarBasis
        {
            /*"        10 WS-REG-TOT           PIC    X(17)                                VALUE  'TOTAL DO DIA -> ;'.*/
            public StringBasis WS_REG_TOT { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @"TOTAL DO DIA -> ;");
            /*"        10 WS-REG-DIA           PIC    X(02)  VALUE SPACES.*/
            public StringBasis WS_REG_DIA { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
            /*"        10 WS-REG-BARRA-DIA     PIC    X(01)  VALUE '/'.*/
            public StringBasis WS_REG_BARRA_DIA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
            /*"        10 WS-REG-MES           PIC    X(02)  VALUE SPACES.*/
            public StringBasis WS_REG_MES { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
            /*"        10 FILLER               PIC    X(01)  VALUE '/'.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
            /*"        10 WS-REG-ANO           PIC    X(04)  VALUE SPACES.*/
            public StringBasis WS_REG_ANO { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
            /*"        10 FILLER               PIC    X(01)  VALUE ';'.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"        10 WS-DET-VLR-RCAP      PIC    Z.ZZZ.ZZZ.ZZZ.ZZZ,99.*/
            public DoubleBasis WS_DET_VLR_RCAP { get; set; } = new DoubleBasis(new PIC("9", "0", "Z.ZZZ.ZZZ.ZZZ.ZZZV99."), 0);
            /*"        10 FILLER               PIC    X(01)  VALUE ';'.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"        10 WS-DET-QTD-PROP      PIC    9(7).*/
            public IntBasis WS_DET_QTD_PROP { get; set; } = new IntBasis(new PIC("9", "7", "9(7)."));
            /*"        10 FILLER               PIC    X(01)  VALUE ';'.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05  WS-REG-TOT-EXTRATO.*/
        }
        public BI8173B_WS_REG_TOT_EXTRATO WS_REG_TOT_EXTRATO { get; set; } = new BI8173B_WS_REG_TOT_EXTRATO();
        public class BI8173B_WS_REG_TOT_EXTRATO : VarBasis
        {
            /*"        10 WS-REG-TOT-TOT       PIC    X(17)                                VALUE  'TOTAL DO MES -> ;'.*/
            public StringBasis WS_REG_TOT_TOT { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @"TOTAL DO MES -> ;");
            /*"        10 WS-REG-DIA-TOT       PIC    X(02)  VALUE SPACES.*/
            public StringBasis WS_REG_DIA_TOT { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
            /*"        10 WS-REG-BARRA-DIA-TOT PIC    X(01)  VALUE SPACES.*/
            public StringBasis WS_REG_BARRA_DIA_TOT { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"        10 WS-REG-MES-TOT       PIC    X(02)  VALUE SPACES.*/
            public StringBasis WS_REG_MES_TOT { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
            /*"        10 FILLER               PIC    X(01)  VALUE '/'.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
            /*"        10 WS-REG-ANO-TOT       PIC    X(04)  VALUE SPACES.*/
            public StringBasis WS_REG_ANO_TOT { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
            /*"        10 FILLER               PIC    X(01)  VALUE ';'.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"        10 WS-DET-VLR-RCAP-TOT  PIC    Z.ZZZ.ZZZ.ZZZ.ZZZ,99.*/
            public DoubleBasis WS_DET_VLR_RCAP_TOT { get; set; } = new DoubleBasis(new PIC("9", "0", "Z.ZZZ.ZZZ.ZZZ.ZZZV99."), 0);
            /*"        10 FILLER               PIC    X(01)  VALUE ';'.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"        10 WS-DET-QTD-PROP-TOT  PIC    9(7).*/
            public IntBasis WS_DET_QTD_PROP_TOT { get; set; } = new IntBasis(new PIC("9", "7", "9(7)."));
            /*"        10 FILLER               PIC    X(01)  VALUE ';'.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05  WS-VALOR-RCAP           PIC    S9(13)V99 COMP-3.*/
        }
        public DoubleBasis WS_VALOR_RCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"    05  WS-QUANT-PROP           PIC    S9(4)  COMP.*/
        public IntBasis WS_QUANT_PROP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    05  WFIM-PROPOSTA           PIC    X(001) VALUE SPACES.*/
        public StringBasis WFIM_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"    05  AC-CONTA                PIC    9(9)   VALUE ZEROS.*/
        public IntBasis AC_CONTA { get; set; } = new IntBasis(new PIC("9", "9", "9(9)"));
        /*"    05  AC-LIDOS                PIC    9(9)   VALUE ZEROS.*/
        public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(9)"));
        /*"    05  WFIM-PROPOSTA-TOT       PIC    X(001) VALUE SPACES.*/
        public StringBasis WFIM_PROPOSTA_TOT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"    05  AC-CONTA-TOT            PIC    9(9)   VALUE ZEROS.*/
        public IntBasis AC_CONTA_TOT { get; set; } = new IntBasis(new PIC("9", "9", "9(9)"));
        /*"    05  AC-LIDOS-TOT            PIC    9(9)   VALUE ZEROS.*/
        public IntBasis AC_LIDOS_TOT { get; set; } = new IntBasis(new PIC("9", "9", "9(9)"));
        /*"    05  WHORA-CURR              PIC    X(008) VALUE SPACES.*/
        public StringBasis WHORA_CURR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"01                WABEND.*/
        public BI8173B_WABEND WABEND { get; set; } = new BI8173B_WABEND();
        public class BI8173B_WABEND : VarBasis
        {
            /*"      05          FILLER              PIC X(010) VALUE                 ' BI8173B'.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" BI8173B");
            /*"      05          FILLER              PIC X(026) VALUE                 ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"      05          WNR-EXEC-SQL        PIC X(004) VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"      05          FILLER              PIC X(013) VALUE                 ' *** SQLCODE '.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"      05          WSQLCODE            PIC ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
        }


        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.BILHETE BILHETE { get; set; } = new Dclgens.BILHETE();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();
        public BI8173B_CPROPOSTA CPROPOSTA { get; set; } = new BI8173B_CPROPOSTA();
        public BI8173B_CPROPOSTA_TOT CPROPOSTA_TOT { get; set; } = new BI8173B_CPROPOSTA_TOT();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string RBI8173A_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                RBI8173A.SetFile(RBI8173A_FILE_NAME_P);

                /*" -178- DISPLAY '-------------------------------' . */
                _.Display($"-------------------------------");

                /*" -179- DISPLAY 'PROGRAMA EM EXECUCAO BI8173B   ' . */
                _.Display($"PROGRAMA EM EXECUCAO BI8173B   ");

                /*" -180- DISPLAY '                               ' . */
                _.Display($"                               ");

                /*" -181- DISPLAY 'VERSAO V.03  272563 01/01/2021 ' . */
                _.Display($"VERSAO V.03  272563 01/01/2021 ");

                /*" -182- DISPLAY '                               ' . */
                _.Display($"                               ");

                /*" -182- DISPLAY '-------------------------------' . */
                _.Display($"-------------------------------");

                /*" -182- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -190- PERFORM R0900-00-DECLARE-PROPOSTA. */

            R0900_00_DECLARE_PROPOSTA_SECTION();

            /*" -192- PERFORM R0910-00-FETCH-PROPOSTA. */

            R0910_00_FETCH_PROPOSTA_SECTION();

            /*" -193- IF WFIM-PROPOSTA EQUAL 'S' */

            if (WFIM_PROPOSTA == "S")
            {

                /*" -194- PERFORM R9800-00-ENCERRA-SEM-SOLIC */

                R9800_00_ENCERRA_SEM_SOLIC_SECTION();

                /*" -195- MOVE ZEROS TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -196- STOP RUN */

                throw new GoBack();   // => STOP RUN.

                /*" -198- END-IF. */
            }


            /*" -200- PERFORM R8000-00-OPEN-ARQUIVOS. */

            R8000_00_OPEN_ARQUIVOS_SECTION();

            /*" -201- WRITE RBI8173A-RECORD FROM WS-CABEC-01. */
            _.Move(WS_CABEC_01.GetMoveValues(), RBI8173A_RECORD);

            RBI8173A.Write(RBI8173A_RECORD.GetMoveValues().ToString());

            /*" -202- WRITE RBI8173A-RECORD FROM WS-CABEC-03. */
            _.Move(WS_CABEC_03.GetMoveValues(), RBI8173A_RECORD);

            RBI8173A.Write(RBI8173A_RECORD.GetMoveValues().ToString());

            /*" -203- WRITE RBI8173A-RECORD FROM WS-CABEC-04. */
            _.Move(WS_CABEC_04.GetMoveValues(), RBI8173A_RECORD);

            RBI8173A.Write(RBI8173A_RECORD.GetMoveValues().ToString());

            /*" -204- WRITE RBI8173A-RECORD FROM WS-CABEC-05. */
            _.Move(WS_CABEC_05.GetMoveValues(), RBI8173A_RECORD);

            RBI8173A.Write(RBI8173A_RECORD.GetMoveValues().ToString());

            /*" -205- WRITE RBI8173A-RECORD FROM WS-CABEC-06. */
            _.Move(WS_CABEC_06.GetMoveValues(), RBI8173A_RECORD);

            RBI8173A.Write(RBI8173A_RECORD.GetMoveValues().ToString());

            /*" -207- WRITE RBI8173A-RECORD FROM WS-CABEC-07. */
            _.Move(WS_CABEC_07.GetMoveValues(), RBI8173A_RECORD);

            RBI8173A.Write(RBI8173A_RECORD.GetMoveValues().ToString());

            /*" -211- PERFORM R1000-00-PROCESSA-INPUT UNTIL WFIM-PROPOSTA EQUAL 'S' . */

            while (!(WFIM_PROPOSTA == "S"))
            {

                R1000_00_PROCESSA_INPUT_SECTION();
            }

            /*" -213- PERFORM R0950-00-DECLARE-PROPOSTA-TOT. */

            R0950_00_DECLARE_PROPOSTA_TOT_SECTION();

            /*" -215- PERFORM R0960-00-FETCH-PROPOSTA-TOT. */

            R0960_00_FETCH_PROPOSTA_TOT_SECTION();

            /*" -216- IF WFIM-PROPOSTA-TOT EQUAL 'S' */

            if (WFIM_PROPOSTA_TOT == "S")
            {

                /*" -217- PERFORM R9800-00-ENCERRA-SEM-SOLIC */

                R9800_00_ENCERRA_SEM_SOLIC_SECTION();

                /*" -218- MOVE ZEROS TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -219- STOP RUN */

                throw new GoBack();   // => STOP RUN.

                /*" -221- END-IF. */
            }


            /*" -226- PERFORM R1100-00-PROCESSA-INPUT UNTIL WFIM-PROPOSTA-TOT EQUAL 'S' . */

            while (!(WFIM_PROPOSTA_TOT == "S"))
            {

                R1100_00_PROCESSA_INPUT_SECTION();
            }

            /*" -228- PERFORM R9000-00-CLOSE-ARQUIVOS. */

            R9000_00_CLOSE_ARQUIVOS_SECTION();

            /*" -228- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -238- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -240- DISPLAY '******  BI8173B *********' */
            _.Display($"******  BI8173B *********");

            /*" -241- DISPLAY '*** BI8173B - TERMINO NORMAL ***' */
            _.Display($"*** BI8173B - TERMINO NORMAL ***");

            /*" -241- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-PROPOSTA-SECTION */
        private void R0900_00_DECLARE_PROPOSTA_SECTION()
        {
            /*" -255- MOVE '0900' TO WNR-EXEC-SQL. */
            _.Move("0900", WABEND.WNR_EXEC_SQL);

            /*" -280- PERFORM R0900_00_DECLARE_PROPOSTA_DB_DECLARE_1 */

            R0900_00_DECLARE_PROPOSTA_DB_DECLARE_1();

            /*" -282- PERFORM R0900_00_DECLARE_PROPOSTA_DB_OPEN_1 */

            R0900_00_DECLARE_PROPOSTA_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0900-00-DECLARE-PROPOSTA-DB-DECLARE-1 */
        public void R0900_00_DECLARE_PROPOSTA_DB_DECLARE_1()
        {
            /*" -280- EXEC SQL DECLARE CPROPOSTA CURSOR FOR SELECT SUBSTR(CHAR(DIGITS(DAY(A.DATA_EMISSAO))),09,02), SUBSTR(CHAR(DIGITS(MONTH(A.DATA_EMISSAO))),09,02), SUBSTR(YEAR(a.DATA_EMISSAO),01,04), SUM(A.VAL_RCAP) , COUNT(*) FROM SEGUROS.ENDOSSOS A, SEGUROS.SISTEMAS B WHERE (A.COD_PRODUTO BETWEEN 6917 AND 6921) AND A.NUM_ENDOSSO = 0 AND A.VAL_RCAP > 0 AND SUBSTR(CHAR(DIGITS(MONTH(A.DATA_EMISSAO))),09,02) = MONTH(B.DATA_MOV_ABERTO - 1 MONTH) AND B.IDE_SISTEMA = 'BI' GROUP BY SUBSTR(CHAR(DIGITS(DAY(A.DATA_EMISSAO))),09,02), SUBSTR(CHAR(DIGITS(MONTH(A.DATA_EMISSAO))),09,02), SUBSTR(YEAR(A.DATA_EMISSAO),01,04) ORDER BY SUBSTR(YEAR(A.DATA_EMISSAO),01,04), SUBSTR(CHAR(DIGITS(MONTH(A.DATA_EMISSAO))),09,02), SUBSTR(CHAR(DIGITS(DAY(A.DATA_EMISSAO))),09,02) WITH UR END-EXEC. */
            CPROPOSTA = new BI8173B_CPROPOSTA(false);
            string GetQuery_CPROPOSTA()
            {
                var query = @$"SELECT 
							SUBSTR(CHAR(DIGITS(DAY(A.DATA_EMISSAO)))
							,09
							,02)
							, 
							SUBSTR(CHAR(DIGITS(MONTH(A.DATA_EMISSAO)))
							,09
							,02)
							, 
							SUBSTR(YEAR(a.DATA_EMISSAO)
							,01
							,04)
							, 
							SUM(A.VAL_RCAP)
							, 
							COUNT(*) 
							FROM SEGUROS.ENDOSSOS A
							, 
							SEGUROS.SISTEMAS B 
							WHERE (A.COD_PRODUTO BETWEEN 6917 AND 6921) 
							AND A.NUM_ENDOSSO = 0 
							AND A.VAL_RCAP > 0 
							AND SUBSTR(CHAR(DIGITS(MONTH(A.DATA_EMISSAO)))
							,09
							,02) 
							= MONTH(B.DATA_MOV_ABERTO - 1 MONTH) 
							AND B.IDE_SISTEMA = 'BI' 
							GROUP BY SUBSTR(CHAR(DIGITS(DAY(A.DATA_EMISSAO)))
							,09
							,02)
							, 
							SUBSTR(CHAR(DIGITS(MONTH(A.DATA_EMISSAO)))
							,09
							,02)
							, 
							SUBSTR(YEAR(A.DATA_EMISSAO)
							,01
							,04) 
							ORDER BY SUBSTR(YEAR(A.DATA_EMISSAO)
							,01
							,04)
							, 
							SUBSTR(CHAR(DIGITS(MONTH(A.DATA_EMISSAO)))
							,09
							,02)
							, 
							SUBSTR(CHAR(DIGITS(DAY(A.DATA_EMISSAO)))
							,09
							,02)";

                return query;
            }
            CPROPOSTA.GetQueryEvent += GetQuery_CPROPOSTA;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-PROPOSTA-DB-OPEN-1 */
        public void R0900_00_DECLARE_PROPOSTA_DB_OPEN_1()
        {
            /*" -282- EXEC SQL OPEN CPROPOSTA END-EXEC. */

            CPROPOSTA.Open();

        }

        [StopWatch]
        /*" R0950-00-DECLARE-PROPOSTA-TOT-DB-DECLARE-1 */
        public void R0950_00_DECLARE_PROPOSTA_TOT_DB_DECLARE_1()
        {
            /*" -318- EXEC SQL DECLARE CPROPOSTA-TOT CURSOR FOR SELECT SUBSTR(CHAR(DIGITS(MONTH(A.DATA_EMISSAO))),09,02), SUBSTR(YEAR(a.DATA_EMISSAO),01,04), SUM(A.VAL_RCAP) , COUNT(*) FROM SEGUROS.ENDOSSOS A, SEGUROS.SISTEMAS B WHERE (A.COD_PRODUTO BETWEEN 6917 AND 6921) AND A.NUM_ENDOSSO = 0 AND A.VAL_RCAP > 0 AND SUBSTR(CHAR(DIGITS(MONTH(A.DATA_EMISSAO))),09,02) = MONTH(B.DATA_MOV_ABERTO - 1 MONTH) AND B.IDE_SISTEMA = 'BI' GROUP BY SUBSTR(CHAR(DIGITS(MONTH(A.DATA_EMISSAO))),09,02), SUBSTR(YEAR(A.DATA_EMISSAO),01,04) ORDER BY SUBSTR(YEAR(A.DATA_EMISSAO),01,04), SUBSTR(CHAR(DIGITS(MONTH(A.DATA_EMISSAO))),09,02) WITH UR END-EXEC. */
            CPROPOSTA_TOT = new BI8173B_CPROPOSTA_TOT(false);
            string GetQuery_CPROPOSTA_TOT()
            {
                var query = @$"SELECT 
							SUBSTR(CHAR(DIGITS(MONTH(A.DATA_EMISSAO)))
							,09
							,02)
							, 
							SUBSTR(YEAR(a.DATA_EMISSAO)
							,01
							,04)
							, 
							SUM(A.VAL_RCAP)
							, 
							COUNT(*) 
							FROM SEGUROS.ENDOSSOS A
							, 
							SEGUROS.SISTEMAS B 
							WHERE (A.COD_PRODUTO BETWEEN 6917 AND 6921) 
							AND A.NUM_ENDOSSO = 0 
							AND A.VAL_RCAP > 0 
							AND SUBSTR(CHAR(DIGITS(MONTH(A.DATA_EMISSAO)))
							,09
							,02) 
							= MONTH(B.DATA_MOV_ABERTO - 1 MONTH) 
							AND B.IDE_SISTEMA = 'BI' 
							GROUP BY 
							SUBSTR(CHAR(DIGITS(MONTH(A.DATA_EMISSAO)))
							,09
							,02)
							, 
							SUBSTR(YEAR(A.DATA_EMISSAO)
							,01
							,04) 
							ORDER BY SUBSTR(YEAR(A.DATA_EMISSAO)
							,01
							,04)
							, 
							SUBSTR(CHAR(DIGITS(MONTH(A.DATA_EMISSAO)))
							,09
							,02)";

                return query;
            }
            CPROPOSTA_TOT.GetQueryEvent += GetQuery_CPROPOSTA_TOT;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0950-00-DECLARE-PROPOSTA-TOT-SECTION */
        private void R0950_00_DECLARE_PROPOSTA_TOT_SECTION()
        {
            /*" -295- MOVE '0950' TO WNR-EXEC-SQL. */
            _.Move("0950", WABEND.WNR_EXEC_SQL);

            /*" -318- PERFORM R0950_00_DECLARE_PROPOSTA_TOT_DB_DECLARE_1 */

            R0950_00_DECLARE_PROPOSTA_TOT_DB_DECLARE_1();

            /*" -320- PERFORM R0950_00_DECLARE_PROPOSTA_TOT_DB_OPEN_1 */

            R0950_00_DECLARE_PROPOSTA_TOT_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0950-00-DECLARE-PROPOSTA-TOT-DB-OPEN-1 */
        public void R0950_00_DECLARE_PROPOSTA_TOT_DB_OPEN_1()
        {
            /*" -320- EXEC SQL OPEN CPROPOSTA-TOT END-EXEC. */

            CPROPOSTA_TOT.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0950_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-PROPOSTA-SECTION */
        private void R0910_00_FETCH_PROPOSTA_SECTION()
        {
            /*" -331- MOVE '0910' TO WNR-EXEC-SQL. */
            _.Move("0910", WABEND.WNR_EXEC_SQL);

            /*" -339- PERFORM R0910_00_FETCH_PROPOSTA_DB_FETCH_1 */

            R0910_00_FETCH_PROPOSTA_DB_FETCH_1();

            /*" -342- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -343- MOVE 'S' TO WFIM-PROPOSTA */
                _.Move("S", WFIM_PROPOSTA);

                /*" -345- MOVE ZEROS TO AC-CONTA AC-LIDOS */
                _.Move(0, AC_CONTA, AC_LIDOS);

                /*" -345- PERFORM R0910_00_FETCH_PROPOSTA_DB_CLOSE_1 */

                R0910_00_FETCH_PROPOSTA_DB_CLOSE_1();

                /*" -347- GO TO R0910-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                return;

                /*" -350- END-IF. */
            }


            /*" -351- IF AC-CONTA GREATER 199 */

            if (AC_CONTA > 199)
            {

                /*" -352- MOVE ZEROS TO AC-CONTA */
                _.Move(0, AC_CONTA);

                /*" -353- ACCEPT WHORA-CURR FROM TIME */
                _.Move(_.AcceptDate("TIME"), WHORA_CURR);

                /*" -354- DISPLAY '**** LIDOS PROPOSTA ' AC-LIDOS ' ' WHORA-CURR */

                $"**** LIDOS PROPOSTA {AC_LIDOS} {WHORA_CURR}"
                .Display();

                /*" -356- END-IF. */
            }


            /*" -357- MOVE WS-VALOR-RCAP TO WS-DET-VLR-RCAP. */
            _.Move(WS_VALOR_RCAP, WS_REG_DET_EXTRATO.WS_DET_VLR_RCAP);

            /*" -357- MOVE WS-QUANT-PROP TO WS-DET-QTD-PROP. */
            _.Move(WS_QUANT_PROP, WS_REG_DET_EXTRATO.WS_DET_QTD_PROP);

        }

        [StopWatch]
        /*" R0910-00-FETCH-PROPOSTA-DB-FETCH-1 */
        public void R0910_00_FETCH_PROPOSTA_DB_FETCH_1()
        {
            /*" -339- EXEC SQL FETCH CPROPOSTA INTO :WS-REG-DIA, :WS-REG-MES, :WS-REG-ANO, :WS-VALOR-RCAP, :WS-QUANT-PROP END-EXEC. */

            if (CPROPOSTA.Fetch())
            {
                _.Move(CPROPOSTA.WS_REG_DIA, WS_REG_DET_EXTRATO.WS_REG_DIA);
                _.Move(CPROPOSTA.WS_REG_MES, WS_REG_DET_EXTRATO.WS_REG_MES);
                _.Move(CPROPOSTA.WS_REG_ANO, WS_REG_DET_EXTRATO.WS_REG_ANO);
                _.Move(CPROPOSTA.WS_VALOR_RCAP, WS_VALOR_RCAP);
                _.Move(CPROPOSTA.WS_QUANT_PROP, WS_QUANT_PROP);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-PROPOSTA-DB-CLOSE-1 */
        public void R0910_00_FETCH_PROPOSTA_DB_CLOSE_1()
        {
            /*" -345- EXEC SQL CLOSE CPROPOSTA END-EXEC */

            CPROPOSTA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R0960-00-FETCH-PROPOSTA-TOT-SECTION */
        private void R0960_00_FETCH_PROPOSTA_TOT_SECTION()
        {
            /*" -368- MOVE '0960' TO WNR-EXEC-SQL. */
            _.Move("0960", WABEND.WNR_EXEC_SQL);

            /*" -375- PERFORM R0960_00_FETCH_PROPOSTA_TOT_DB_FETCH_1 */

            R0960_00_FETCH_PROPOSTA_TOT_DB_FETCH_1();

            /*" -378- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -379- MOVE 'S' TO WFIM-PROPOSTA-TOT */
                _.Move("S", WFIM_PROPOSTA_TOT);

                /*" -381- MOVE ZEROS TO AC-CONTA-TOT AC-LIDOS-TOT */
                _.Move(0, AC_CONTA_TOT, AC_LIDOS_TOT);

                /*" -381- PERFORM R0960_00_FETCH_PROPOSTA_TOT_DB_CLOSE_1 */

                R0960_00_FETCH_PROPOSTA_TOT_DB_CLOSE_1();

                /*" -383- GO TO R0960-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0960_99_SAIDA*/ //GOTO
                return;

                /*" -386- END-IF. */
            }


            /*" -387- IF AC-CONTA-TOT GREATER 199 */

            if (AC_CONTA_TOT > 199)
            {

                /*" -388- MOVE ZEROS TO AC-CONTA-TOT */
                _.Move(0, AC_CONTA_TOT);

                /*" -389- ACCEPT WHORA-CURR FROM TIME */
                _.Move(_.AcceptDate("TIME"), WHORA_CURR);

                /*" -390- DISPLAY '**** LIDOS PROPTOT ' AC-LIDOS-TOT ' ' WHORA-CURR */

                $"**** LIDOS PROPTOT {AC_LIDOS_TOT} {WHORA_CURR}"
                .Display();

                /*" -392- END-IF. */
            }


            /*" -393- MOVE WS-VALOR-RCAP TO WS-DET-VLR-RCAP-TOT. */
            _.Move(WS_VALOR_RCAP, WS_REG_TOT_EXTRATO.WS_DET_VLR_RCAP_TOT);

            /*" -393- MOVE WS-QUANT-PROP TO WS-DET-QTD-PROP-TOT. */
            _.Move(WS_QUANT_PROP, WS_REG_TOT_EXTRATO.WS_DET_QTD_PROP_TOT);

        }

        [StopWatch]
        /*" R0960-00-FETCH-PROPOSTA-TOT-DB-FETCH-1 */
        public void R0960_00_FETCH_PROPOSTA_TOT_DB_FETCH_1()
        {
            /*" -375- EXEC SQL FETCH CPROPOSTA-TOT INTO :WS-REG-MES-TOT, :WS-REG-ANO-TOT, :WS-VALOR-RCAP, :WS-QUANT-PROP END-EXEC. */

            if (CPROPOSTA_TOT.Fetch())
            {
                _.Move(CPROPOSTA_TOT.WS_REG_MES_TOT, WS_REG_TOT_EXTRATO.WS_REG_MES_TOT);
                _.Move(CPROPOSTA_TOT.WS_REG_ANO_TOT, WS_REG_TOT_EXTRATO.WS_REG_ANO_TOT);
                _.Move(CPROPOSTA_TOT.WS_VALOR_RCAP, WS_VALOR_RCAP);
                _.Move(CPROPOSTA_TOT.WS_QUANT_PROP, WS_QUANT_PROP);
            }

        }

        [StopWatch]
        /*" R0960-00-FETCH-PROPOSTA-TOT-DB-CLOSE-1 */
        public void R0960_00_FETCH_PROPOSTA_TOT_DB_CLOSE_1()
        {
            /*" -381- EXEC SQL CLOSE CPROPOSTA-TOT END-EXEC */

            CPROPOSTA_TOT.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0960_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-INPUT-SECTION */
        private void R1000_00_PROCESSA_INPUT_SECTION()
        {
            /*" -404- WRITE RBI8173A-RECORD FROM WS-REG-DET-EXTRATO. */
            _.Move(WS_REG_DET_EXTRATO.GetMoveValues(), RBI8173A_RECORD);

            RBI8173A.Write(RBI8173A_RECORD.GetMoveValues().ToString());

            /*" -404- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R1000_10_NEXT */

            R1000_10_NEXT();

        }

        [StopWatch]
        /*" R1000-10-NEXT */
        private void R1000_10_NEXT(bool isPerform = false)
        {
            /*" -409- PERFORM R0910-00-FETCH-PROPOSTA. */

            R0910_00_FETCH_PROPOSTA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-PROCESSA-INPUT-SECTION */
        private void R1100_00_PROCESSA_INPUT_SECTION()
        {
            /*" -420- WRITE RBI8173A-RECORD FROM WS-REG-TOT-EXTRATO. */
            _.Move(WS_REG_TOT_EXTRATO.GetMoveValues(), RBI8173A_RECORD);

            RBI8173A.Write(RBI8173A_RECORD.GetMoveValues().ToString());

            /*" -420- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R1100_10_NEXT */

            R1100_10_NEXT();

        }

        [StopWatch]
        /*" R1100-10-NEXT */
        private void R1100_10_NEXT(bool isPerform = false)
        {
            /*" -425- PERFORM R0960-00-FETCH-PROPOSTA-TOT. */

            R0960_00_FETCH_PROPOSTA_TOT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R8000-00-OPEN-ARQUIVOS-SECTION */
        private void R8000_00_OPEN_ARQUIVOS_SECTION()
        {
            /*" -438- MOVE '8000' TO WNR-EXEC-SQL. */
            _.Move("8000", WABEND.WNR_EXEC_SQL);

            /*" -438- OPEN OUTPUT RBI8173A. */
            RBI8173A.Open(RBI8173A_RECORD);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-CLOSE-ARQUIVOS-SECTION */
        private void R9000_00_CLOSE_ARQUIVOS_SECTION()
        {
            /*" -449- MOVE '9000' TO WNR-EXEC-SQL. */
            _.Move("9000", WABEND.WNR_EXEC_SQL);

            /*" -449- CLOSE RBI8173A. */
            RBI8173A.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9800-00-ENCERRA-SEM-SOLIC-SECTION */
        private void R9800_00_ENCERRA_SEM_SOLIC_SECTION()
        {
            /*" -463- MOVE '9800' TO WNR-EXEC-SQL. */
            _.Move("9800", WABEND.WNR_EXEC_SQL);

            /*" -464- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -465- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -466- DISPLAY '*   BI8173B - GERA ARQUIVO EXTRATO ELO     *' */
            _.Display($"*   BI8173B - GERA ARQUIVO EXTRATO ELO     *");

            /*" -467- DISPLAY '*   -------   -----------------------      *' */
            _.Display($"*   -------   -----------------------      *");

            /*" -468- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -469- DISPLAY '*      NAO EXISTEM BILHETES A              *' */
            _.Display($"*      NAO EXISTEM BILHETES A              *");

            /*" -470- DISPLAY '*         SEREM EMITIDOS.                  *' */
            _.Display($"*         SEREM EMITIDOS.                  *");

            /*" -471- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -471- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9800_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -485- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -486- DISPLAY WABEND */
            _.Display(WABEND);

            /*" -487- DISPLAY '*** BI8173B - LIDOS   ' AC-LIDOS. */
            _.Display($"*** BI8173B - LIDOS   {AC_LIDOS}");

            /*" -490- DISPLAY '*** BI8173B - BILHETE ' BILHETE-NUM-BILHETE. */
            _.Display($"*** BI8173B - BILHETE {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

            /*" -490- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -492- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -496- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -496- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}