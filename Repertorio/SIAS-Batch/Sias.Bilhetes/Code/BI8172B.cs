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
using Sias.Bilhetes.DB2.BI8172B;

namespace Code
{
    public class BI8172B
    {
        public bool IsCall { get; set; }

        public BI8172B()
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
        /*"      *  GERA ARQUIVO CONTENDO AS PROPOSTAS COMERCIALIZADAS PELA ELO   *      */
        /*"      *   QUE COMP�E O EXTRATO PARA FATURAMENTO MENSAL.                *      */
        /*"      *                                                                *      */
        /*"      *        PRODUTOS 6917 A 6921 - SEGURO VIAGEM ELO                *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *                         ALTERACOES                             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 04 - HERVAL SOUZA      TAREFA:  272563                *      */
        /*"      *             - REVER PRODUTOS NAO MIGRADOS JV1                  *      */
        /*"      *    EM 01/01/2020 -                                             *      */
        /*"      *                                        PROCURE POR V.04        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 03 - GERALDO NAKAJIMA                                 *      */
        /*"      *             - PREPARAR�� PROGRAMA PARA PROCESSAMENTO DA JV1    *      */
        /*"      *                                                                *      */
        /*"      *    EM 06/02/2019 - ATOS BR                                     *      */
        /*"      *                                        PROCURE POR JV1         *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 02 - CADMUS - 155.507                                 *      */
        /*"      *             - IMPLANTA��O DO  NOVOS PRODUTOS SEGURO VIAGEM     *      */
        /*"      *               SEGURA PRE�O                                     *      */
        /*"      *               PRODUTOS 6922.                                   *      */
        /*"      *                                                                *      */
        /*"      *    EM 01/12/2017 - HERVAL SOUZA                                *      */
        /*"      *                                        PROCURE POR V.02        *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01 - CADMUS - 149.239                                 *      */
        /*"      *             - IMPLANTA��O DO  NOVOS PRODUTOS SEGURO VIAGEM     *      */
        /*"      *               SEGURA PRE�O                                     *      */
        /*"      *               PRODUTOS 6922                                    *      */
        /*"      *                                                                *      */
        /*"      *    EM 27/03/2017 - MAURO ROCHA DA CRUZ                         *      */
        /*"      *                                        PROCURE POR V.01        *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _RBI8172A { get; set; } = new FileBasis(new PIC("X", "200", "X(200)"));

        public FileBasis RBI8172A
        {
            get
            {
                _.Move(RBI8172A_RECORD, _RBI8172A); VarBasis.RedefinePassValue(RBI8172A_RECORD, _RBI8172A, RBI8172A_RECORD); return _RBI8172A;
            }
        }
        public FileBasis _RBI8172B { get; set; } = new FileBasis(new PIC("X", "200", "X(200)"));

        public FileBasis RBI8172B
        {
            get
            {
                _.Move(RBI8172B_RECORD, _RBI8172B); VarBasis.RedefinePassValue(RBI8172B_RECORD, _RBI8172B, RBI8172B_RECORD); return _RBI8172B;
            }
        }
        /*"01                RBI8172A-RECORD     PIC X(200).*/
        public StringBasis RBI8172A_RECORD { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");
        /*"01                RBI8172B-RECORD     PIC X(200).*/
        public StringBasis RBI8172B_RECORD { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"    05  WS-CABEC-01.*/
        public BI8172B_WS_CABEC_01 WS_CABEC_01 { get; set; } = new BI8172B_WS_CABEC_01();
        public class BI8172B_WS_CABEC_01 : VarBasis
        {
            /*"        10  FILLER              PIC X(57) VALUE       'BI8172B - EXTRATO MENSAL DE OPERA��ES SEGURO VIAGEM    '*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "57", "X(57)"), @"BI8172B - EXTRATO MENSAL DE OPERA��ES SEGURO VIAGEM    ");
            /*"    05  WS-CABEC-02.*/
        }
        public BI8172B_WS_CABEC_02 WS_CABEC_02 { get; set; } = new BI8172B_WS_CABEC_02();
        public class BI8172B_WS_CABEC_02 : VarBasis
        {
            /*"        10  FILLER              PIC X(57) VALUE       '          RELA��O DAS PROPOSTAS COMERCIALIZADAS        '*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "57", "X(57)"), @"          RELA��O DAS PROPOSTAS COMERCIALIZADAS        ");
            /*"    05  WS-CABEC-03.*/
        }
        public BI8172B_WS_CABEC_03 WS_CABEC_03 { get; set; } = new BI8172B_WS_CABEC_03();
        public class BI8172B_WS_CABEC_03 : VarBasis
        {
            /*"        10  FILLER              PIC X(57) VALUE       '          ELO SERVI�OS S.A - CNPJ 09.227.084/0001-75   '*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "57", "X(57)"), @"          ELO SERVI�OS S.A - CNPJ 09.227.084/0001-75   ");
            /*"    05  WS-CABEC-04.*/
        }
        public BI8172B_WS_CABEC_04 WS_CABEC_04 { get; set; } = new BI8172B_WS_CABEC_04();
        public class BI8172B_WS_CABEC_04 : VarBasis
        {
            /*"        10  FILLER              PIC X(57) VALUE       '          ALAMEDA XINGU, N� 512, 5� andar              '*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "57", "X(57)"), @"          ALAMEDA XINGU, N� 512, 5� andar              ");
            /*"    05  WS-CABEC-05.*/
        }
        public BI8172B_WS_CABEC_05 WS_CABEC_05 { get; set; } = new BI8172B_WS_CABEC_05();
        public class BI8172B_WS_CABEC_05 : VarBasis
        {
            /*"        10  FILLER              PIC X(57) VALUE       '          BARUERI - SP                                 '*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "57", "X(57)"), @"          BARUERI - SP                                 ");
            /*"    05  WS-CABEC-06.*/
        }
        public BI8172B_WS_CABEC_06 WS_CABEC_06 { get; set; } = new BI8172B_WS_CABEC_06();
        public class BI8172B_WS_CABEC_06 : VarBasis
        {
            /*"        10  FILLER              PIC X(57) VALUE       '          CEP - 06455-030                              '*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "57", "X(57)"), @"          CEP - 06455-030                              ");
            /*"    05  WS-CABEC-07.*/
        }
        public BI8172B_WS_CABEC_07 WS_CABEC_07 { get; set; } = new BI8172B_WS_CABEC_07();
        public class BI8172B_WS_CABEC_07 : VarBasis
        {
            /*"        10  FILLER              PIC X(115) VALUE         '   APOLICE  ;  BILHETE  ;   PROPOSTA   ;PROD;     DESCR         'I��O DO PRODUTO     ;DATA PROP.;DATA EMIS.;   VALOR PAG         'O   ;'.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "115", "X(115)"), @"   APOLICE  ;  BILHETE  ;   PROPOSTA   ;PROD;     DESCR         ");
            /*"    05  WS-CABEC-08.*/
        }
        public BI8172B_WS_CABEC_08 WS_CABEC_08 { get; set; } = new BI8172B_WS_CABEC_08();
        public class BI8172B_WS_CABEC_08 : VarBasis
        {
            /*"        10  FILLER              PIC X(57) VALUE       '  WEB PR�MIOS COM�RCIO E SERVI�OS PROMOCIONAIS LTDA    '*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "57", "X(57)"), @"  WEB PR�MIOS COM�RCIO E SERVI�OS PROMOCIONAIS LTDA    ");
            /*"    05  WS-CABEC-09.*/
        }
        public BI8172B_WS_CABEC_09 WS_CABEC_09 { get; set; } = new BI8172B_WS_CABEC_09();
        public class BI8172B_WS_CABEC_09 : VarBasis
        {
            /*"        10  FILLER              PIC X(57) VALUE       '  CNPJ: 08.845.775/0001-70                             '*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "57", "X(57)"), @"  CNPJ: 08.845.775/0001-70                             ");
            /*"    05  WS-CABEC-10.*/
        }
        public BI8172B_WS_CABEC_10 WS_CABEC_10 { get; set; } = new BI8172B_WS_CABEC_10();
        public class BI8172B_WS_CABEC_10 : VarBasis
        {
            /*"        10  FILLER              PIC X(57) VALUE       '  ALAMEDA RIO NEGRO, 585, BL. C, CONJ.  71, ALPHAVILLE '*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "57", "X(57)"), @"  ALAMEDA RIO NEGRO, 585, BL. C, CONJ.  71, ALPHAVILLE ");
            /*"    05  WS-CABEC-11.*/
        }
        public BI8172B_WS_CABEC_11 WS_CABEC_11 { get; set; } = new BI8172B_WS_CABEC_11();
        public class BI8172B_WS_CABEC_11 : VarBasis
        {
            /*"        10  FILLER              PIC X(57) VALUE       '          BARUERI - SP                                 '*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "57", "X(57)"), @"          BARUERI - SP                                 ");
            /*"    05  WS-CABEC-12.*/
        }
        public BI8172B_WS_CABEC_12 WS_CABEC_12 { get; set; } = new BI8172B_WS_CABEC_12();
        public class BI8172B_WS_CABEC_12 : VarBasis
        {
            /*"        10  FILLER              PIC X(57) VALUE       '          CEP - 06454-000                              '*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "57", "X(57)"), @"          CEP - 06454-000                              ");
            /*"    05  WS-COD-PRODUTO          PIC   s9(04)  COMP VALUE ZEROS.*/
        }
        public IntBasis WS_COD_PRODUTO { get; set; } = new IntBasis(new PIC("s9", "4", "s9(04)"));
        /*"    05  WS-REG-DET-EXTRATO      PIC    X(200) VALUE SPACES.*/
        public StringBasis WS_REG_DET_EXTRATO { get; set; } = new StringBasis(new PIC("X", "200", "X(200)"), @"");
        /*"    05  WFIM-PROPOSTA           PIC    X(001) VALUE SPACES.*/
        public StringBasis WFIM_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"    05  AC-CONTA                PIC    9(9)   VALUE ZEROS.*/
        public IntBasis AC_CONTA { get; set; } = new IntBasis(new PIC("9", "9", "9(9)"));
        /*"    05  AC-LIDOS                PIC    9(9)   VALUE ZEROS.*/
        public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(9)"));
        /*"    05  WHORA-CURR              PIC    X(008) VALUE SPACES.*/
        public StringBasis WHORA_CURR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"    05  WS-SISTEMA-MESFAT       PIC    X(010).*/
        public StringBasis WS_SISTEMA_MESFAT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01                WABEND.*/
        public BI8172B_WABEND WABEND { get; set; } = new BI8172B_WABEND();
        public class BI8172B_WABEND : VarBasis
        {
            /*"      05          FILLER              PIC X(010) VALUE                 ' BI8172B'.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" BI8172B");
            /*"      05          FILLER              PIC X(026) VALUE                 ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"      05          WNR-EXEC-SQL        PIC X(004) VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"      05          FILLER              PIC X(013) VALUE                 ' *** SQLCODE '.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"      05          WSQLCODE            PIC ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
        }


        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.BILHETE BILHETE { get; set; } = new Dclgens.BILHETE();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();
        public BI8172B_CPROPOSTA CPROPOSTA { get; set; } = new BI8172B_CPROPOSTA();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string RBI8172A_FILE_NAME_P, string RBI8172B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                RBI8172A.SetFile(RBI8172A_FILE_NAME_P);
                RBI8172B.SetFile(RBI8172B_FILE_NAME_P);

                /*" -204- DISPLAY '-------------------------------' . */
                _.Display($"-------------------------------");

                /*" -205- DISPLAY 'PROGRAMA EM EXECUCAO BI8172B   ' . */
                _.Display($"PROGRAMA EM EXECUCAO BI8172B   ");

                /*" -206- DISPLAY '                               ' . */
                _.Display($"                               ");

                /*" -210- DISPLAY 'VERSAO V.04  272563 01/01/2021 ' . */
                _.Display($"VERSAO V.04  272563 01/01/2021 ");

                /*" -211- DISPLAY '                               ' . */
                _.Display($"                               ");

                /*" -211- DISPLAY '-------------------------------' . */
                _.Display($"-------------------------------");

                /*" -211- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -219- PERFORM R0900-00-DECLARE-PROPOSTA. */

            R0900_00_DECLARE_PROPOSTA_SECTION();

            /*" -221- PERFORM R0910-00-FETCH-PROPOSTA. */

            R0910_00_FETCH_PROPOSTA_SECTION();

            /*" -222- IF WFIM-PROPOSTA EQUAL 'S' */

            if (WFIM_PROPOSTA == "S")
            {

                /*" -223- PERFORM R9800-00-ENCERRA-SEM-SOLIC */

                R9800_00_ENCERRA_SEM_SOLIC_SECTION();

                /*" -224- MOVE ZEROS TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -225- STOP RUN */

                throw new GoBack();   // => STOP RUN.

                /*" -227- END-IF. */
            }


            /*" -229- PERFORM R8000-00-OPEN-ARQUIVOS. */

            R8000_00_OPEN_ARQUIVOS_SECTION();

            /*" -230- WRITE RBI8172A-RECORD FROM WS-CABEC-01. */
            _.Move(WS_CABEC_01.GetMoveValues(), RBI8172A_RECORD);

            RBI8172A.Write(RBI8172A_RECORD.GetMoveValues().ToString());

            /*" -231- WRITE RBI8172A-RECORD FROM WS-CABEC-02. */
            _.Move(WS_CABEC_02.GetMoveValues(), RBI8172A_RECORD);

            RBI8172A.Write(RBI8172A_RECORD.GetMoveValues().ToString());

            /*" -232- WRITE RBI8172A-RECORD FROM WS-CABEC-03. */
            _.Move(WS_CABEC_03.GetMoveValues(), RBI8172A_RECORD);

            RBI8172A.Write(RBI8172A_RECORD.GetMoveValues().ToString());

            /*" -233- WRITE RBI8172A-RECORD FROM WS-CABEC-04. */
            _.Move(WS_CABEC_04.GetMoveValues(), RBI8172A_RECORD);

            RBI8172A.Write(RBI8172A_RECORD.GetMoveValues().ToString());

            /*" -234- WRITE RBI8172A-RECORD FROM WS-CABEC-05. */
            _.Move(WS_CABEC_05.GetMoveValues(), RBI8172A_RECORD);

            RBI8172A.Write(RBI8172A_RECORD.GetMoveValues().ToString());

            /*" -235- WRITE RBI8172A-RECORD FROM WS-CABEC-06. */
            _.Move(WS_CABEC_06.GetMoveValues(), RBI8172A_RECORD);

            RBI8172A.Write(RBI8172A_RECORD.GetMoveValues().ToString());

            /*" -237- WRITE RBI8172A-RECORD FROM WS-CABEC-07. */
            _.Move(WS_CABEC_07.GetMoveValues(), RBI8172A_RECORD);

            RBI8172A.Write(RBI8172A_RECORD.GetMoveValues().ToString());

            /*" -238- WRITE RBI8172B-RECORD FROM WS-CABEC-01. */
            _.Move(WS_CABEC_01.GetMoveValues(), RBI8172B_RECORD);

            RBI8172B.Write(RBI8172B_RECORD.GetMoveValues().ToString());

            /*" -239- WRITE RBI8172B-RECORD FROM WS-CABEC-02. */
            _.Move(WS_CABEC_02.GetMoveValues(), RBI8172B_RECORD);

            RBI8172B.Write(RBI8172B_RECORD.GetMoveValues().ToString());

            /*" -240- WRITE RBI8172B-RECORD FROM WS-CABEC-08. */
            _.Move(WS_CABEC_08.GetMoveValues(), RBI8172B_RECORD);

            RBI8172B.Write(RBI8172B_RECORD.GetMoveValues().ToString());

            /*" -241- WRITE RBI8172B-RECORD FROM WS-CABEC-09. */
            _.Move(WS_CABEC_09.GetMoveValues(), RBI8172B_RECORD);

            RBI8172B.Write(RBI8172B_RECORD.GetMoveValues().ToString());

            /*" -242- WRITE RBI8172B-RECORD FROM WS-CABEC-10. */
            _.Move(WS_CABEC_10.GetMoveValues(), RBI8172B_RECORD);

            RBI8172B.Write(RBI8172B_RECORD.GetMoveValues().ToString());

            /*" -243- WRITE RBI8172B-RECORD FROM WS-CABEC-11. */
            _.Move(WS_CABEC_11.GetMoveValues(), RBI8172B_RECORD);

            RBI8172B.Write(RBI8172B_RECORD.GetMoveValues().ToString());

            /*" -244- WRITE RBI8172B-RECORD FROM WS-CABEC-12. */
            _.Move(WS_CABEC_12.GetMoveValues(), RBI8172B_RECORD);

            RBI8172B.Write(RBI8172B_RECORD.GetMoveValues().ToString());

            /*" -246- WRITE RBI8172B-RECORD FROM WS-CABEC-07. */
            _.Move(WS_CABEC_07.GetMoveValues(), RBI8172B_RECORD);

            RBI8172B.Write(RBI8172B_RECORD.GetMoveValues().ToString());

            /*" -249- PERFORM R1000-00-PROCESSA-INPUT UNTIL WFIM-PROPOSTA EQUAL 'S' . */

            while (!(WFIM_PROPOSTA == "S"))
            {

                R1000_00_PROCESSA_INPUT_SECTION();
            }

            /*" -251- PERFORM R9000-00-CLOSE-ARQUIVOS. */

            R9000_00_CLOSE_ARQUIVOS_SECTION();

            /*" -251- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -261- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -263- DISPLAY '******  BI8172B *********' */
            _.Display($"******  BI8172B *********");

            /*" -264- DISPLAY '*** BI8172B - TERMINO NORMAL ***' */
            _.Display($"*** BI8172B - TERMINO NORMAL ***");

            /*" -264- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-PROPOSTA-SECTION */
        private void R0900_00_DECLARE_PROPOSTA_SECTION()
        {
            /*" -278- MOVE '0900' TO WNR-EXEC-SQL. */
            _.Move("0900", WABEND.WNR_EXEC_SQL);

            /*" -327- PERFORM R0900_00_DECLARE_PROPOSTA_DB_DECLARE_1 */

            R0900_00_DECLARE_PROPOSTA_DB_DECLARE_1();

            /*" -329- PERFORM R0900_00_DECLARE_PROPOSTA_DB_OPEN_1 */

            R0900_00_DECLARE_PROPOSTA_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0900-00-DECLARE-PROPOSTA-DB-DECLARE-1 */
        public void R0900_00_DECLARE_PROPOSTA_DB_DECLARE_1()
        {
            /*" -327- EXEC SQL DECLARE CPROPOSTA CURSOR FOR SELECT A.COD_PRODUTO, A.NUM_APOLICE || ';' || B.NUM_BILHETE || ';' || C.NUM_PROPOSTA_SIVPF || ';' || A.COD_PRODUTO || ';' || SUBSTR(D.DESCR_PRODUTO,1,30) || ';' || SUBSTR(CHAR(DIGITS(DAY(C.DATA_PROPOSTA))),09,02) || '/' || SUBSTR(CHAR(DIGITS(MONTH(C.DATA_PROPOSTA))),09,02) || '/' || SUBSTR(YEAR(C.DATA_PROPOSTA),01,04) || ';' || SUBSTR(CHAR(DIGITS(DAY(A.DATA_EMISSAO))),09,02) || '/' || SUBSTR(CHAR(DIGITS(MONTH(A.DATA_EMISSAO))),09,02) || '/' || SUBSTR(YEAR(a.DATA_EMISSAO),01,04) || ';' || SUBSTR(CHAR(DIGITS(A.VAL_RCAP)),1,13) || ',' || SUBSTR(CHAR(DIGITS(A.VAL_RCAP)),14,2) || ';' FROM SEGUROS.ENDOSSOS A, SEGUROS.BILHETE B, SEGUROS.PROPOSTA_FIDELIZ C, SEGUROS.PRODUTO D, SEGUROS.SISTEMAS E WHERE (A.COD_PRODUTO BETWEEN 6917 AND 6922) AND A.NUM_ENDOSSO = 0 AND A.VAL_RCAP > 0 AND A.NUM_APOLICE = B.NUM_APOLICE AND B.NUM_BILHETE = C.NUM_SICOB AND A.COD_PRODUTO = D.COD_PRODUTO AND SUBSTR(CHAR(DIGITS(MONTH(A.DATA_EMISSAO))),09,02) = MONTH(E.DATA_MOV_ABERTO - 1 MONTH) AND E.IDE_SISTEMA = 'BI' ORDER BY 1,2 WITH UR END-EXEC. */
            CPROPOSTA = new BI8172B_CPROPOSTA(false);
            string GetQuery_CPROPOSTA()
            {
                var query = @$"SELECT 
							A.COD_PRODUTO
							, 
							A.NUM_APOLICE 
							|| ';' 
							|| B.NUM_BILHETE 
							|| ';' 
							|| C.NUM_PROPOSTA_SIVPF 
							|| ';' 
							|| A.COD_PRODUTO 
							|| ';' 
							|| SUBSTR(D.DESCR_PRODUTO
							,1
							,30) 
							|| ';' 
							|| SUBSTR(CHAR(DIGITS(DAY(C.DATA_PROPOSTA)))
							,09
							,02) 
							|| '/' 
							|| SUBSTR(CHAR(DIGITS(MONTH(C.DATA_PROPOSTA)))
							,09
							,02) 
							|| '/' 
							|| SUBSTR(YEAR(C.DATA_PROPOSTA)
							,01
							,04) 
							|| ';' 
							|| SUBSTR(CHAR(DIGITS(DAY(A.DATA_EMISSAO)))
							,09
							,02) 
							|| '/' 
							|| SUBSTR(CHAR(DIGITS(MONTH(A.DATA_EMISSAO)))
							,09
							,02) 
							|| '/' 
							|| SUBSTR(YEAR(a.DATA_EMISSAO)
							,01
							,04) 
							|| ';' 
							|| SUBSTR(CHAR(DIGITS(A.VAL_RCAP))
							,1
							,13) 
							|| '
							,' 
							|| SUBSTR(CHAR(DIGITS(A.VAL_RCAP))
							,14
							,2) 
							|| ';' 
							FROM SEGUROS.ENDOSSOS A
							, 
							SEGUROS.BILHETE B
							, 
							SEGUROS.PROPOSTA_FIDELIZ C
							, 
							SEGUROS.PRODUTO D
							, 
							SEGUROS.SISTEMAS E 
							WHERE (A.COD_PRODUTO BETWEEN 6917 AND 6922) 
							AND A.NUM_ENDOSSO = 0 
							AND A.VAL_RCAP > 0 
							AND A.NUM_APOLICE = B.NUM_APOLICE 
							AND B.NUM_BILHETE = C.NUM_SICOB 
							AND A.COD_PRODUTO = D.COD_PRODUTO 
							AND SUBSTR(CHAR(DIGITS(MONTH(A.DATA_EMISSAO)))
							,09
							,02) 
							= MONTH(E.DATA_MOV_ABERTO - 1 MONTH) 
							AND E.IDE_SISTEMA = 'BI' 
							ORDER BY 1
							,2";

                return query;
            }
            CPROPOSTA.GetQueryEvent += GetQuery_CPROPOSTA;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-PROPOSTA-DB-OPEN-1 */
        public void R0900_00_DECLARE_PROPOSTA_DB_OPEN_1()
        {
            /*" -329- EXEC SQL OPEN CPROPOSTA END-EXEC. */

            CPROPOSTA.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-PROPOSTA-SECTION */
        private void R0910_00_FETCH_PROPOSTA_SECTION()
        {
            /*" -340- MOVE '0910' TO WNR-EXEC-SQL. */
            _.Move("0910", WABEND.WNR_EXEC_SQL);

            /*" -345- PERFORM R0910_00_FETCH_PROPOSTA_DB_FETCH_1 */

            R0910_00_FETCH_PROPOSTA_DB_FETCH_1();

            /*" -348- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -349- MOVE 'S' TO WFIM-PROPOSTA */
                _.Move("S", WFIM_PROPOSTA);

                /*" -351- MOVE ZEROS TO AC-CONTA AC-LIDOS */
                _.Move(0, AC_CONTA, AC_LIDOS);

                /*" -351- PERFORM R0910_00_FETCH_PROPOSTA_DB_CLOSE_1 */

                R0910_00_FETCH_PROPOSTA_DB_CLOSE_1();

                /*" -353- GO TO R0910-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                return;

                /*" -356- END-IF. */
            }


            /*" -357- IF AC-CONTA GREATER 199 */

            if (AC_CONTA > 199)
            {

                /*" -358- MOVE ZEROS TO AC-CONTA */
                _.Move(0, AC_CONTA);

                /*" -359- ACCEPT WHORA-CURR FROM TIME */
                _.Move(_.AcceptDate("TIME"), WHORA_CURR);

                /*" -360- DISPLAY '**** LIDOS V0RELAT ' AC-LIDOS ' ' WHORA-CURR */

                $"**** LIDOS V0RELAT {AC_LIDOS} {WHORA_CURR}"
                .Display();

                /*" -360- END-IF. */
            }


        }

        [StopWatch]
        /*" R0910-00-FETCH-PROPOSTA-DB-FETCH-1 */
        public void R0910_00_FETCH_PROPOSTA_DB_FETCH_1()
        {
            /*" -345- EXEC SQL FETCH CPROPOSTA INTO :WS-COD-PRODUTO, :WS-REG-DET-EXTRATO END-EXEC. */

            if (CPROPOSTA.Fetch())
            {
                _.Move(CPROPOSTA.WS_COD_PRODUTO, WS_COD_PRODUTO);
                _.Move(CPROPOSTA.WS_REG_DET_EXTRATO, WS_REG_DET_EXTRATO);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-PROPOSTA-DB-CLOSE-1 */
        public void R0910_00_FETCH_PROPOSTA_DB_CLOSE_1()
        {
            /*" -351- EXEC SQL CLOSE CPROPOSTA END-EXEC */

            CPROPOSTA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-INPUT-SECTION */
        private void R1000_00_PROCESSA_INPUT_SECTION()
        {
            /*" -371- IF WS-COD-PRODUTO EQUAL 6922 */

            if (WS_COD_PRODUTO == 6922)
            {

                /*" -372- WRITE RBI8172B-RECORD FROM WS-REG-DET-EXTRATO */
                _.Move(WS_REG_DET_EXTRATO.GetMoveValues(), RBI8172B_RECORD);

                RBI8172B.Write(RBI8172B_RECORD.GetMoveValues().ToString());

                /*" -373- ELSE */
            }
            else
            {


                /*" -376- WRITE RBI8172A-RECORD FROM WS-REG-DET-EXTRATO. */
                _.Move(WS_REG_DET_EXTRATO.GetMoveValues(), RBI8172A_RECORD);

                RBI8172A.Write(RBI8172A_RECORD.GetMoveValues().ToString());
            }


            /*" -376- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R1000_10_NEXT */

            R1000_10_NEXT();

        }

        [StopWatch]
        /*" R1000-10-NEXT */
        private void R1000_10_NEXT(bool isPerform = false)
        {
            /*" -381- PERFORM R0910-00-FETCH-PROPOSTA. */

            R0910_00_FETCH_PROPOSTA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R8000-00-OPEN-ARQUIVOS-SECTION */
        private void R8000_00_OPEN_ARQUIVOS_SECTION()
        {
            /*" -394- MOVE '8000' TO WNR-EXEC-SQL. */
            _.Move("8000", WABEND.WNR_EXEC_SQL);

            /*" -395- OPEN OUTPUT RBI8172A. */
            RBI8172A.Open(RBI8172A_RECORD);

            /*" -395- OPEN OUTPUT RBI8172B. */
            RBI8172B.Open(RBI8172B_RECORD);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-CLOSE-ARQUIVOS-SECTION */
        private void R9000_00_CLOSE_ARQUIVOS_SECTION()
        {
            /*" -406- MOVE '9000' TO WNR-EXEC-SQL. */
            _.Move("9000", WABEND.WNR_EXEC_SQL);

            /*" -407- CLOSE RBI8172A. */
            RBI8172A.Close();

            /*" -407- CLOSE RBI8172B. */
            RBI8172B.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9800-00-ENCERRA-SEM-SOLIC-SECTION */
        private void R9800_00_ENCERRA_SEM_SOLIC_SECTION()
        {
            /*" -421- MOVE '9800' TO WNR-EXEC-SQL. */
            _.Move("9800", WABEND.WNR_EXEC_SQL);

            /*" -422- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -423- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -424- DISPLAY '*   BI8172B - GERA ARQUIVO EXTRATO ELO     *' */
            _.Display($"*   BI8172B - GERA ARQUIVO EXTRATO ELO     *");

            /*" -425- DISPLAY '*   -------   -----------------------      *' */
            _.Display($"*   -------   -----------------------      *");

            /*" -426- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -427- DISPLAY '*      NAO EXISTEM BILHETES A              *' */
            _.Display($"*      NAO EXISTEM BILHETES A              *");

            /*" -428- DISPLAY '*         SEREM EMITIDOS.                  *' */
            _.Display($"*         SEREM EMITIDOS.                  *");

            /*" -429- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -429- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9800_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -443- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -444- DISPLAY WABEND */
            _.Display(WABEND);

            /*" -445- DISPLAY '*** BI8172B - LIDOS   ' AC-LIDOS. */
            _.Display($"*** BI8172B - LIDOS   {AC_LIDOS}");

            /*" -448- DISPLAY '*** BI8172B - BILHETE ' BILHETE-NUM-BILHETE. */
            _.Display($"*** BI8172B - BILHETE {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

            /*" -448- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -450- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -454- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -454- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}