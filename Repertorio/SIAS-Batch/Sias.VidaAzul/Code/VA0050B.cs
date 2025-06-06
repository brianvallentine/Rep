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
using Sias.VidaAzul.DB2.VA0050B;

namespace Code
{
    public class VA0050B
    {
        public bool IsCall { get; set; }

        public VA0050B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  GERA MOVIMENTO CRIVO               *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA/PROGRAMADOR....  FAST COMPUTER                      *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  VA0050B                            *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  12/01/95                           *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *                         ALTERACOES                             *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 02                                                    *      */
        /*"      *             - CAD 153.255                                      *      */
        /*"      *             - MUDAR O NOME DA POL�TICA.                        *      */
        /*"      *                                                                *      */
        /*"      *   EM 10/08/2017 - CLAUDETE RADEL                               *      */
        /*"      *                                       PROCURE POR V.02         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01                                                    *      */
        /*"      *             - CAD 47.893                                       *      */
        /*"      *             - AJUSTAR A COLUNA 'TIPO' DO ARQUIVO DE SAIDA ALTE-*      */
        /*"      *               RANDO O CONTEUDO DE 'p' PARA 'P'.                *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/09/2010 - MARCO PAIVA    (FAST COMPUTER)               *      */
        /*"      *                                       PROCURE POR V.01         *      */
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        public FileBasis _MOV_CRIVO { get; set; } = new FileBasis(new PIC("X", "200", "X(200)"));

        public FileBasis MOV_CRIVO
        {
            get
            {
                _.Move(REG_MOV_CRIVO, _MOV_CRIVO); VarBasis.RedefinePassValue(REG_MOV_CRIVO, _MOV_CRIVO, REG_MOV_CRIVO); return _MOV_CRIVO;
            }
        }
        /*"01          REG-MOV-CRIVO    PIC X(200).*/
        public StringBasis REG_MOV_CRIVO { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01          WS-WORK-AREAS.*/
        public VA0050B_WS_WORK_AREAS WS_WORK_AREAS { get; set; } = new VA0050B_WS_WORK_AREAS();
        public class VA0050B_WS_WORK_AREAS : VarBasis
        {
            /*"    05      WSQLCODE3   PIC S9(009)  COMP  VALUE +0.*/
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    05      AC-LIDOS    PIC  9(008)   VALUE  ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05      AC-CONTA    PIC  9(008)   VALUE  ZEROS.*/
            public IntBasis AC_CONTA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05      AC-GRAVADOS PIC  9(008)   VALUE  ZEROS.*/
            public IntBasis AC_GRAVADOS { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05      WS-TIME     PIC  X(008)   VALUE  SPACES.*/
            public StringBasis WS_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"    05      WS-EOF      PIC  9(001)   VALUE  ZEROS.*/
            public IntBasis WS_EOF { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05      LC01.*/
            public VA0050B_LC01 LC01 { get; set; } = new VA0050B_LC01();
            public class VA0050B_LC01 : VarBasis
            {
                /*"      10    FILLER      PIC X(007)   VALUE 'Usuario'.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"Usuario");
                /*"      10    FILLER      PIC X(001)   VALUE ';'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"      10    FILLER      PIC X(004)   VALUE 'Tipo'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"Tipo");
                /*"      10    FILLER      PIC X(001)   VALUE ';'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"      10    FILLER      PIC X(011)   VALUE 'Certificado'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"Certificado");
                /*"      10    FILLER      PIC X(001)   VALUE ';'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"      10    FILLER      PIC X(003)   VALUE 'CPF'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"CPF");
                /*"      10    FILLER      PIC X(001)   VALUE ';'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"      10    FILLER      PIC X(010)   VALUE 'Modalidade'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"Modalidade");
                /*"      10    FILLER      PIC X(001)   VALUE ';'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"      10    FILLER      PIC X(004)   VALUE 'Nome'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"Nome");
                /*"      10    FILLER      PIC X(001)   VALUE ';'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"      10    FILLER      PIC X(018)   VALUE 'Valor para an�lise'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"Valor para an�lise");
                /*"      10    FILLER      PIC X(001)   VALUE ';'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"      10    FILLER      PIC X(010)   VALUE 'Criterio'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"Criterio");
                /*"      10    FILLER      PIC X(126)   VALUE  SPACES.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "126", "X(126)"), @"");
                /*"    05      LD01.*/
            }
            public VA0050B_LD01 LD01 { get; set; } = new VA0050B_LD01();
            public class VA0050B_LD01 : VarBasis
            {
                /*"      10    LD01-USUARIO               PIC X(007)   VALUE           'SISVI1P'.*/
                public StringBasis LD01_USUARIO { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"SISVI1P");
                /*"      10    FILLER                     PIC X(001)   VALUE ';'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"      10    LD01-TIPO                  PIC X(001)   VALUE 'P'.*/
                public StringBasis LD01_TIPO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"P");
                /*"      10    FILLER                     PIC X(001)   VALUE ';'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"      10    LD01-NUM-CERTIFICADO       PIC 9(015).*/
                public IntBasis LD01_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"      10    FILLER                     PIC X(001)   VALUE ';'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"      10    LD01-CGCCPF                PIC 9(011).*/
                public IntBasis LD01_CGCCPF { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
                /*"      10    FILLER                     PIC X(001)   VALUE ';'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"      10    LD01-MODALIDADE            PIC X(002)   VALUE 'CP'.*/
                public StringBasis LD01_MODALIDADE { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"CP");
                /*"      10    FILLER                     PIC X(001)   VALUE ';'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"      10    LD01-NOME-RAZAO            PIC X(072).*/
                public StringBasis LD01_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                /*"      10    FILLER                     PIC X(001)   VALUE ';'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"      10    LD01-IS-BASICA             PIC ZZZZZZZZZZZZZ.*/
                public StringBasis LD01_IS_BASICA { get; set; } = new StringBasis(new PIC("X", "0", "ZZZZZZZZZZZZZ."), @"");
                /*"      10    FILLER                     PIC X(001)   VALUE ';'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"      10    LD01-CRITERIO              PIC X(039) VALUE           'DIRVI - Pol�tica Rotina Batch 01082017'.*/
                public StringBasis LD01_CRITERIO { get; set; } = new StringBasis(new PIC("X", "39", "X(039)"), @"DIRVI - Pol�tica Rotina Batch 01082017");
                /*"      10    FILLER                     PIC X(053) VALUE  SPACES.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "53", "X(053)"), @"");
                /*" 01          WABEND.*/
                public VA0050B_WABEND WABEND { get; set; } = new VA0050B_WABEND();
                public class VA0050B_WABEND : VarBasis
                {
                    /*"    05      FILLER                   PIC  X(010) VALUE            'VA0050B  '.*/
                }
            }
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VA0050B  ");
            /*"    05      FILLER                   PIC  X(028) VALUE            ' *** ERRO  EXEC SQL *** '.*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL *** ");
            /*"    05      FILLER                   PIC  X(014) VALUE            '    SQLCODE = '.*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
            /*"    05      WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"    05      FILLER                   PIC  X(014)   VALUE            '   SQLERRD1 = '.*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
            /*"    05      WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"    05      FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"    05      WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"    05      FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
            public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"    05      LOCALIZA-ABEND-1.*/
            public VA0050B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new VA0050B_LOCALIZA_ABEND_1();
            public class VA0050B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05      LOCALIZA-ABEND-2.*/
            }
            public VA0050B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new VA0050B_LOCALIZA_ABEND_2();
            public class VA0050B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
            }
        }


        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.HISCOBPR HISCOBPR { get; set; } = new Dclgens.HISCOBPR();
        public VA0050B_CPROPVA CPROPVA { get; set; } = new VA0050B_CPROPVA();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string MOV_CRIVO_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                MOV_CRIVO.SetFile(MOV_CRIVO_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM M-0000-PRINCIPAL */

                M_0000_PRINCIPAL();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" M-0000-PRINCIPAL */
        private void M_0000_PRINCIPAL(bool isPerform = false)
        {
            /*" -168- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -171- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -174- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -177- DISPLAY '------------------------------' */
            _.Display($"------------------------------");

            /*" -178- DISPLAY 'PROGRAMA EM EXECUCAO VA0050B  ' */
            _.Display($"PROGRAMA EM EXECUCAO VA0050B  ");

            /*" -179- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -181- DISPLAY 'VERSAO V.02 153.255 10/08/2017' */
            _.Display($"VERSAO V.02 153.255 10/08/2017");

            /*" -182- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -184- DISPLAY '------------------------------' . */
            _.Display($"------------------------------");

            /*" -186- PERFORM R0900-00-DECLARE-PROPOVA. */

            R0900_00_DECLARE_PROPOVA_SECTION();

            /*" -188- PERFORM R0910-00-FETCH-PROPOVA. */

            R0910_00_FETCH_PROPOVA_SECTION();

            /*" -189- IF WS-EOF = 1 */

            if (WS_WORK_AREAS.WS_EOF == 1)
            {

                /*" -190- DISPLAY 'VA0050B - NAO HOUVE MOVIMENTACAO NESTA DATA' */
                _.Display($"VA0050B - NAO HOUVE MOVIMENTACAO NESTA DATA");

                /*" -191- STOP RUN */

                throw new GoBack();   // => STOP RUN.

                /*" -193- END-IF. */
            }


            /*" -195- OPEN OUTPUT MOV-CRIVO. */
            MOV_CRIVO.Open(REG_MOV_CRIVO);

            /*" -197- WRITE REG-MOV-CRIVO FROM LC01. */
            _.Move(WS_WORK_AREAS.LC01.GetMoveValues(), REG_MOV_CRIVO);

            MOV_CRIVO.Write(REG_MOV_CRIVO.GetMoveValues().ToString());

            /*" -198- DISPLAY '*** VA0050B *** PROCESSANDO ...' . */
            _.Display($"*** VA0050B *** PROCESSANDO ...");

            /*" -201- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WS-EOF = 1. */

            while (!(WS_WORK_AREAS.WS_EOF == 1))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -201- PERFORM 0000-TERMINA. */

            M_0000_TERMINA(true);

        }

        [StopWatch]
        /*" M-0000-TERMINA */
        private void M_0000_TERMINA(bool isPerform = false)
        {
            /*" -206- CLOSE MOV-CRIVO. */
            MOV_CRIVO.Close();

            /*" -207- DISPLAY 'REGISTROS LIDOS     ' AC-LIDOS. */
            _.Display($"REGISTROS LIDOS     {WS_WORK_AREAS.AC_LIDOS}");

            /*" -209- DISPLAY 'REGISTROS GRAVADOS  ' AC-GRAVADOS. */
            _.Display($"REGISTROS GRAVADOS  {WS_WORK_AREAS.AC_GRAVADOS}");

            /*" -211- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -211- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-SECTION */
        private void R0100_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -220- MOVE 'R0100-00-SELECT SISTEMAS' TO PARAGRAFO. */
            _.Move("R0100-00-SELECT SISTEMAS", WS_WORK_AREAS.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -223- MOVE 'SELECT SISTEMAS' TO COMANDO. */
            _.Move("SELECT SISTEMAS", WS_WORK_AREAS.LOCALIZA_ABEND_2.COMANDO);

            /*" -228- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -231- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -231- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -228- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VA' END-EXEC. */

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
        /*" R0900-00-DECLARE-PROPOVA-SECTION */
        private void R0900_00_DECLARE_PROPOVA_SECTION()
        {
            /*" -243- MOVE 'R0900-00-DECLARE-PROPOVA' TO PARAGRAFO. */
            _.Move("R0900-00-DECLARE-PROPOVA", WS_WORK_AREAS.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -246- MOVE 'DECLARE CPROPOVA ' TO COMANDO. */
            _.Move("DECLARE CPROPOVA ", WS_WORK_AREAS.LOCALIZA_ABEND_2.COMANDO);

            /*" -252- PERFORM R0900_00_DECLARE_PROPOVA_DB_DECLARE_1 */

            R0900_00_DECLARE_PROPOVA_DB_DECLARE_1();

            /*" -255- DISPLAY '*** VA0050B *** ABRINDO CURSOR ...' . */
            _.Display($"*** VA0050B *** ABRINDO CURSOR ...");

            /*" -257- MOVE 'OPEN CPROPVA' TO COMANDO. */
            _.Move("OPEN CPROPVA", WS_WORK_AREAS.LOCALIZA_ABEND_2.COMANDO);

            /*" -257- PERFORM R0900_00_DECLARE_PROPOVA_DB_OPEN_1 */

            R0900_00_DECLARE_PROPOVA_DB_OPEN_1();

            /*" -260- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -260- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-PROPOVA-DB-DECLARE-1 */
        public void R0900_00_DECLARE_PROPOVA_DB_DECLARE_1()
        {
            /*" -252- EXEC SQL DECLARE CPROPVA CURSOR FOR SELECT NUM_CERTIFICADO, COD_CLIENTE FROM SEGUROS.PROPOSTAS_VA WHERE SIT_REGISTRO = 'E' END-EXEC. */
            CPROPVA = new VA0050B_CPROPVA(false);
            string GetQuery_CPROPVA()
            {
                var query = @$"SELECT NUM_CERTIFICADO
							, 
							COD_CLIENTE 
							FROM SEGUROS.PROPOSTAS_VA 
							WHERE SIT_REGISTRO = 'E'";

                return query;
            }
            CPROPVA.GetQueryEvent += GetQuery_CPROPVA;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-PROPOVA-DB-OPEN-1 */
        public void R0900_00_DECLARE_PROPOVA_DB_OPEN_1()
        {
            /*" -257- EXEC SQL OPEN CPROPVA END-EXEC. */

            CPROPVA.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-PROPOVA-SECTION */
        private void R0910_00_FETCH_PROPOVA_SECTION()
        {
            /*" -272- MOVE 'R0910-00-FETCH-PROPOVA  ' TO PARAGRAFO. */
            _.Move("R0910-00-FETCH-PROPOVA  ", WS_WORK_AREAS.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -275- MOVE 'FETCH   CPROPOVA ' TO COMANDO. */
            _.Move("FETCH   CPROPOVA ", WS_WORK_AREAS.LOCALIZA_ABEND_2.COMANDO);

            /*" -279- PERFORM R0910_00_FETCH_PROPOVA_DB_FETCH_1 */

            R0910_00_FETCH_PROPOVA_DB_FETCH_1();

            /*" -282- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -283- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -284- MOVE 1 TO WS-EOF */
                    _.Move(1, WS_WORK_AREAS.WS_EOF);

                    /*" -286- MOVE 'CLOSE CPROPVA' TO COMANDO */
                    _.Move("CLOSE CPROPVA", WS_WORK_AREAS.LOCALIZA_ABEND_2.COMANDO);

                    /*" -286- PERFORM R0910_00_FETCH_PROPOVA_DB_CLOSE_1 */

                    R0910_00_FETCH_PROPOVA_DB_CLOSE_1();

                    /*" -288- GO TO R0910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;

                    /*" -289- ELSE */
                }
                else
                {


                    /*" -291- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -294- ADD 1 TO AC-LIDOS AC-CONTA. */
            WS_WORK_AREAS.AC_LIDOS.Value = WS_WORK_AREAS.AC_LIDOS + 1;
            WS_WORK_AREAS.AC_CONTA.Value = WS_WORK_AREAS.AC_CONTA + 1;

            /*" -295- IF AC-conta > 999 */

            if (WS_WORK_AREAS.AC_CONTA > 999)
            {

                /*" -296- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), WS_WORK_AREAS.WS_TIME);

                /*" -299- DISPLAY 'LIDOS PROPOVA ..... ' AC-LIDOS ' ' WS-TIME */

                $"LIDOS PROPOVA ..... {WS_WORK_AREAS.AC_LIDOS} {WS_WORK_AREAS.WS_TIME}"
                .Display();

                /*" -300- MOVE ZEROS TO AC-CONTA */
                _.Move(0, WS_WORK_AREAS.AC_CONTA);

                /*" -300- END-IF. */
            }


        }

        [StopWatch]
        /*" R0910-00-FETCH-PROPOVA-DB-FETCH-1 */
        public void R0910_00_FETCH_PROPOVA_DB_FETCH_1()
        {
            /*" -279- EXEC SQL FETCH CPROPVA INTO :PROPOVA-NUM-CERTIFICADO, :PROPOVA-COD-CLIENTE END-EXEC. */

            if (CPROPVA.Fetch())
            {
                _.Move(CPROPVA.PROPOVA_NUM_CERTIFICADO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);
                _.Move(CPROPVA.PROPOVA_COD_CLIENTE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-PROPOVA-DB-CLOSE-1 */
        public void R0910_00_FETCH_PROPOVA_DB_CLOSE_1()
        {
            /*" -286- EXEC SQL CLOSE CPROPVA END-EXEC */

            CPROPVA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -313- MOVE 'R1000-00-PROCESSA-REGISTRO' TO PARAGRAFO. */
            _.Move("R1000-00-PROCESSA-REGISTRO", WS_WORK_AREAS.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -314- PERFORM R1100-00-SELECT-CLIENTES. */

            R1100_00_SELECT_CLIENTES_SECTION();

            /*" -316- PERFORM R1200-00-SELECT-HISCOBPR. */

            R1200_00_SELECT_HISCOBPR_SECTION();

            /*" -319- MOVE PROPOVA-NUM-CERTIFICADO TO LD01-NUM-CERTIFICADO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, WS_WORK_AREAS.LD01.LD01_NUM_CERTIFICADO);

            /*" -322- MOVE CLIENTES-CGCCPF TO LD01-CGCCPF. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, WS_WORK_AREAS.LD01.LD01_CGCCPF);

            /*" -325- MOVE CLIENTES-NOME-RAZAO TO LD01-NOME-RAZAO. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, WS_WORK_AREAS.LD01.LD01_NOME_RAZAO);

            /*" -326- IF HISCOBPR-IMP-MORNATU EQUAL ZEROS */

            if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU == 00)
            {

                /*" -328- MOVE HISCOBPR-IMPMORACID TO LD01-IS-BASICA */
                _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID, WS_WORK_AREAS.LD01.LD01_IS_BASICA);

                /*" -329- ELSE */
            }
            else
            {


                /*" -331- MOVE HISCOBPR-IMP-MORNATU TO LD01-IS-BASICA */
                _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU, WS_WORK_AREAS.LD01.LD01_IS_BASICA);

                /*" -333- END-IF. */
            }


            /*" -335- ADD 1 TO AC-GRAVADOS. */
            WS_WORK_AREAS.AC_GRAVADOS.Value = WS_WORK_AREAS.AC_GRAVADOS + 1;

            /*" -337- WRITE REG-MOV-CRIVO FROM LD01. */
            _.Move(WS_WORK_AREAS.LD01.GetMoveValues(), REG_MOV_CRIVO);

            MOV_CRIVO.Write(REG_MOV_CRIVO.GetMoveValues().ToString());

            /*" -337- PERFORM R0910-00-FETCH-PROPOVA. */

            R0910_00_FETCH_PROPOVA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-SELECT-CLIENTES-SECTION */
        private void R1100_00_SELECT_CLIENTES_SECTION()
        {
            /*" -350- MOVE 'R1100-00-SELECT-CLIENTES' TO PARAGRAFO. */
            _.Move("R1100-00-SELECT-CLIENTES", WS_WORK_AREAS.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -353- MOVE 'SELECT V0CLIENTE' TO COMANDO */
            _.Move("SELECT V0CLIENTE", WS_WORK_AREAS.LOCALIZA_ABEND_2.COMANDO);

            /*" -360- PERFORM R1100_00_SELECT_CLIENTES_DB_SELECT_1 */

            R1100_00_SELECT_CLIENTES_DB_SELECT_1();

            /*" -363- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -364- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -364- END-IF. */
            }


        }

        [StopWatch]
        /*" R1100-00-SELECT-CLIENTES-DB-SELECT-1 */
        public void R1100_00_SELECT_CLIENTES_DB_SELECT_1()
        {
            /*" -360- EXEC SQL SELECT NOME_RAZAO , CGCCPF INTO :CLIENTES-NOME-RAZAO, :CLIENTES-CGCCPF FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :PROPOVA-COD-CLIENTE END-EXEC */

            var r1100_00_SELECT_CLIENTES_DB_SELECT_1_Query1 = new R1100_00_SELECT_CLIENTES_DB_SELECT_1_Query1()
            {
                PROPOVA_COD_CLIENTE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE.ToString(),
            };

            var executed_1 = R1100_00_SELECT_CLIENTES_DB_SELECT_1_Query1.Execute(r1100_00_SELECT_CLIENTES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(executed_1.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SELECT-HISCOBPR-SECTION */
        private void R1200_00_SELECT_HISCOBPR_SECTION()
        {
            /*" -376- MOVE 'R1200-00-SELECT-HISCOBPR' TO PARAGRAFO. */
            _.Move("R1200-00-SELECT-HISCOBPR", WS_WORK_AREAS.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -379- MOVE 'SELECT HISCOBPR         ' TO COMANDO. */
            _.Move("SELECT HISCOBPR         ", WS_WORK_AREAS.LOCALIZA_ABEND_2.COMANDO);

            /*" -387- PERFORM R1200_00_SELECT_HISCOBPR_DB_SELECT_1 */

            R1200_00_SELECT_HISCOBPR_DB_SELECT_1();

            /*" -390- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -390- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1200-00-SELECT-HISCOBPR-DB-SELECT-1 */
        public void R1200_00_SELECT_HISCOBPR_DB_SELECT_1()
        {
            /*" -387- EXEC SQL SELECT IMP_MORNATU, IMPMORACID INTO :HISCOBPR-IMP-MORNATU, :HISCOBPR-IMPMORACID FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND DATA_TERVIGENCIA = '9999-12-31' END-EXEC */

            var r1200_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 = new R1200_00_SELECT_HISCOBPR_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1200_00_SELECT_HISCOBPR_DB_SELECT_1_Query1.Execute(r1200_00_SELECT_HISCOBPR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISCOBPR_IMP_MORNATU, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU);
                _.Move(executed_1.HISCOBPR_IMPMORACID, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -402- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WS_WORK_AREAS.WSQLCODE);

            /*" -403- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], WS_WORK_AREAS.WSQLERRD1);

            /*" -404- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], WS_WORK_AREAS.WSQLERRD2);

            /*" -405- MOVE SQLCODE TO WSQLCODE3. */
            _.Move(DB.SQLCODE, WS_WORK_AREAS.WSQLCODE3);

            /*" -407- DISPLAY WABEND. */
            _.Display(WS_WORK_AREAS.LD01.WABEND);

            /*" -409- DISPLAY '*** VA0050B *** ROLLBACK EM ANDAMENTO ...' . */
            _.Display($"*** VA0050B *** ROLLBACK EM ANDAMENTO ...");

            /*" -409- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -412- MOVE 'R9999-00-ROT-ERRO' TO PARAGRAFO. */
            _.Move("R9999-00-ROT-ERRO", WS_WORK_AREAS.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -414- MOVE 'ROLLBACK WORK' TO COMANDO. */
            _.Move("ROLLBACK WORK", WS_WORK_AREAS.LOCALIZA_ABEND_2.COMANDO);

            /*" -414- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -417- DISPLAY ' ' . */
            _.Display($" ");

            /*" -418- DISPLAY 'LIDOS ................ ' AC-LIDOS. */
            _.Display($"LIDOS ................ {WS_WORK_AREAS.AC_LIDOS}");

            /*" -419- DISPLAY ' ' . */
            _.Display($" ");

            /*" -420- DISPLAY 'GRAVADOS  ............ ' AC-GRAVADOS. */
            _.Display($"GRAVADOS  ............ {WS_WORK_AREAS.AC_GRAVADOS}");

            /*" -422- DISPLAY ' ' */
            _.Display($" ");

            /*" -423- DISPLAY 'CERTIFICADO... ' PROPOVA-NUM-CERTIFICADO. */
            _.Display($"CERTIFICADO... {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

            /*" -425- DISPLAY '*** VA0050B *** ERRO DE EXECUCAO' . */
            _.Display($"*** VA0050B *** ERRO DE EXECUCAO");

            /*" -426- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -426- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}