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
using Sias.VidaEmGrupo.DB2.VG0004B;

namespace Code
{
    public class VG0004B
    {
        public bool IsCall { get; set; }

        public VG0004B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  QUITAR OS ENDOSSOS QUE ESTAO PEN-  *      */
        /*"      *          DENTES APOS A MIGRACAO DAS APOLICES ESPECIFICA E EM-  *      */
        /*"      *          PRESARIAL PARA A ESTRUTURA DO VIDAZUL MULTIPREMIADO.  *      */
        /*"      *                                                                *      */
        /*"      *          PARA QUITAR, PROCEDER ASSIM:                          *      */
        /*"      *                                                                *      */
        /*"      *          1 - IDENTIFICAR NA TABELA HISTCONTABILVA OS ENDOSSOS  *      */
        /*"      *              PENDENTES                                         *      */
        /*"      *                                                                *      */
        /*"      *          2 - VERIFICAR NA TABELA ENDOSSOS SE HOUVE A QUITACAO  *      */
        /*"      *              DO ENDOSSO IDENTIFICADO NA HISTCONTABILVA         *      */
        /*"      *                                                                *      */
        /*"      *          3 - ATUALIZAR A SITUACAO DAS TABELAS V0PARCELVA E     *      */
        /*"      *              V0HISTCOBVA PARA '1' (PAGO)                       *      */
        /*"      *                                                                *      */
        /*"      *          2 - ATUALIZAR A OPERACAO DA TABELA V0HISTCONTABILVA   *      */
        /*"      *              PARA 201                                          *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA ...............  MANOEL MESSIAS                     *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  VG0004B                            *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  08/05/2002                         *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *  ALTERACOES                                                    *      */
        /*"      ******************************************************************      */
        /*"      *  001 - 03/05/07 - MARCO    (CADMUS 3120)                       *      */
        /*"      *    TRATA O ABEND OCORRIDO NA SEGUROS.PARCELAS                  *      */
        /*"      *          SQLCODE = 100.                                        *      */
        /*"      *                                             PROCURE POR V.1    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  VIND-DTFATUR                   PIC S9(004)  COMP VALUE +0.*/
        public IntBasis VIND_DTFATUR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WS-WORK-AREAS.*/
        public VG0004B_WS_WORK_AREAS WS_WORK_AREAS { get; set; } = new VG0004B_WS_WORK_AREAS();
        public class VG0004B_WS_WORK_AREAS : VarBasis
        {
            /*"    03 WFIM-HISTCONTABILVA         PIC  X       VALUE SPACE.*/
            public StringBasis WFIM_HISTCONTABILVA { get; set; } = new StringBasis(new PIC("X", "1", "X"), @"");
            /*"    03 AC-L-HISTCTB                PIC  9(006)  VALUE ZEROS.*/
            public IntBasis AC_L_HISTCTB { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-L-ENDOSSO                PIC  9(006)  VALUE ZEROS.*/
            public IntBasis AC_L_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-L-COMMIT                 PIC  9(006)  VALUE ZEROS.*/
            public IntBasis AC_L_COMMIT { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-U-PARCELVA               PIC  9(006)  VALUE ZEROS.*/
            public IntBasis AC_U_PARCELVA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-U-HISTCOBVA              PIC  9(006)  VALUE ZEROS.*/
            public IntBasis AC_U_HISTCOBVA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-U-HISTCTBILVA            PIC  9(006)  VALUE ZEROS.*/
            public IntBasis AC_U_HISTCTBILVA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-W-CONTA                  PIC  9(006)  VALUE ZEROS.*/
            public IntBasis AC_W_CONTA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 WS-TIME                     PIC  X(008).*/
            public StringBasis WS_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"01  WABEND.*/
        }
        public VG0004B_WABEND WABEND { get; set; } = new VG0004B_WABEND();
        public class VG0004B_WABEND : VarBasis
        {
            /*"    10 FILLER                      PIC  X(016)  VALUE      '*** VG0004B *** '.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"*** VG0004B *** ");
            /*"    10 FILLER                      PIC  X(013)  VALUE      'ERRO SQL *** '.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"ERRO SQL *** ");
            /*"    10 FILLER                      PIC  X(010)  VALUE      'SQLCODE = '.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"SQLCODE = ");
            /*"    10 WSQLCODE                    PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"    10 FILLER                      PIC  X(011)  VALUE      'SQLERRD1 = '.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"SQLERRD1 = ");
            /*"    10 WSQLERRD1                   PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"    10 FILLER                      PIC  X(011)  VALUE      'SQLERRD2 = '.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"SQLERRD2 = ");
            /*"    10 WSQLERRD2                   PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"    10 LOCALIZA-ABEND-1.*/
            public VG0004B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new VG0004B_LOCALIZA_ABEND_1();
            public class VG0004B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      15 FILLER                      PIC  X(012)  VALUE        'PARAGRAFO = '.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      15 PARAGRAFO                   PIC  X(040)  VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    10 LOCALIZA-ABEND-2.*/
            }
            public VG0004B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new VG0004B_LOCALIZA_ABEND_2();
            public class VG0004B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"      15 FILLER                      PIC  X(012)  VALUE        'COMANDO   = '.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"      15 COMANDO                     PIC  X(060)  VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
            }
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.HISCONPA HISCONPA { get; set; } = new Dclgens.HISCONPA();
        public Dclgens.PRODUVG PRODUVG { get; set; } = new Dclgens.PRODUVG();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.PARCELAS PARCELAS { get; set; } = new Dclgens.PARCELAS();
        public Dclgens.PARCEHIS PARCEHIS { get; set; } = new Dclgens.PARCEHIS();
        public Dclgens.PARCEVID PARCEVID { get; set; } = new Dclgens.PARCEVID();
        public Dclgens.COBHISVI COBHISVI { get; set; } = new Dclgens.COBHISVI();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public VG0004B_CHISTCTB CHISTCTB { get; set; } = new VG0004B_CHISTCTB();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -0- FLUXCONTROL_PERFORM M-0000-PRINCIPAL-SECTION */

                M_0000_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            return Result;
        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-SECTION */
        private void M_0000_PRINCIPAL_SECTION()
        {
            /*" -123- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -125- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -127- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -131- MOVE '0000-PRINCIPAL' TO PARAGRAFO. */
            _.Move("0000-PRINCIPAL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -133- PERFORM 0900-DECLA-HISTCONTABILVA */

            M_0900_DECLA_HISTCONTABILVA_SECTION();

            /*" -135- PERFORM 0910-FETCH-HISTCONTABILVA */

            M_0910_FETCH_HISTCONTABILVA_SECTION();

            /*" -137- IF WFIM-HISTCONTABILVA NOT EQUAL SPACES */

            if (!WS_WORK_AREAS.WFIM_HISTCONTABILVA.IsEmpty())
            {

                /*" -138- DISPLAY '*** SEM MOVIMENTO NA HISTCONTABILVA ' */
                _.Display($"*** SEM MOVIMENTO NA HISTCONTABILVA ");

                /*" -140- GO TO 0000-FIM-NORMAL. */

                M_0000_FIM_NORMAL(); //GOTO
                return;
            }


            /*" -142- ACCEPT WS-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WS_WORK_AREAS.WS_TIME);

            /*" -144- DISPLAY '** VG0004B - PROCESSANDO ...' WS-TIME. */
            _.Display($"** VG0004B - PROCESSANDO ...{WS_WORK_AREAS.WS_TIME}");

            /*" -146- PERFORM 1000-PROCESSA UNTIL WFIM-HISTCONTABILVA EQUAL 'S' . */

            while (!(WS_WORK_AREAS.WFIM_HISTCONTABILVA == "S"))
            {

                M_1000_PROCESSA_SECTION();
            }

            /*" -0- FLUXCONTROL_PERFORM M_0000_FIM_NORMAL */

            M_0000_FIM_NORMAL();

        }

        [StopWatch]
        /*" M-0000-FIM-NORMAL */
        private void M_0000_FIM_NORMAL(bool isPerform = false)
        {
            /*" -151- MOVE 'COMMIT WORK' TO COMANDO. */
            _.Move("COMMIT WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -151- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -154- DISPLAY '** VG0004B ** LIDOS HISTCTBILVA ' AC-L-HISTCTB */
            _.Display($"** VG0004B ** LIDOS HISTCTBILVA {WS_WORK_AREAS.AC_L_HISTCTB}");

            /*" -155- DISPLAY '** VG0004B ** LIDOS ENDOSSOS    ' AC-L-ENDOSSO */
            _.Display($"** VG0004B ** LIDOS ENDOSSOS    {WS_WORK_AREAS.AC_L_ENDOSSO}");

            /*" -156- DISPLAY '                                ' . */
            _.Display($"                                ");

            /*" -157- DISPLAY '** VG0004B ** UPDT. PARCELVA    ' AC-U-PARCELVA */
            _.Display($"** VG0004B ** UPDT. PARCELVA    {WS_WORK_AREAS.AC_U_PARCELVA}");

            /*" -158- DISPLAY '** VG0004B ** UPDT. HISTCOBVA   ' AC-U-HISTCOBVA */
            _.Display($"** VG0004B ** UPDT. HISTCOBVA   {WS_WORK_AREAS.AC_U_HISTCOBVA}");

            /*" -159- DISPLAY '** VG0004B ** UPDT. HISTCTBILVA ' AC-U-HISTCTBILVA */
            _.Display($"** VG0004B ** UPDT. HISTCTBILVA {WS_WORK_AREAS.AC_U_HISTCTBILVA}");

            /*" -160- DISPLAY '                                ' . */
            _.Display($"                                ");

            /*" -162- DISPLAY '** VG0004B ** TERMINO NORMAL    ' . */
            _.Display($"** VG0004B ** TERMINO NORMAL    ");

            /*" -164- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -164- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_FIM*/

        [StopWatch]
        /*" M-0900-DECLA-HISTCONTABILVA-SECTION */
        private void M_0900_DECLA_HISTCONTABILVA_SECTION()
        {
            /*" -173- MOVE '0900' TO PARAGRAFO. */
            _.Move("0900", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -176- MOVE 'DECLA-HISTCONTABILVA ' TO COMANDO. */
            _.Move("DECLA-HISTCONTABILVA ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -181- ACCEPT WS-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WS_WORK_AREAS.WS_TIME);

            /*" -205- PERFORM M_0900_DECLA_HISTCONTABILVA_DB_DECLARE_1 */

            M_0900_DECLA_HISTCONTABILVA_DB_DECLARE_1();

            /*" -207- PERFORM M_0900_DECLA_HISTCONTABILVA_DB_OPEN_1 */

            M_0900_DECLA_HISTCONTABILVA_DB_OPEN_1();

            /*" -210- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -211- DISPLAY '0900 - PROBLEMAS DECLARE HISTCONTABILVA ' */
                _.Display($"0900 - PROBLEMAS DECLARE HISTCONTABILVA ");

                /*" -212- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -214- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -214- ACCEPT WS-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WS_WORK_AREAS.WS_TIME);

        }

        [StopWatch]
        /*" M-0900-DECLA-HISTCONTABILVA-DB-DECLARE-1 */
        public void M_0900_DECLA_HISTCONTABILVA_DB_DECLARE_1()
        {
            /*" -205- EXEC SQL DECLARE CHISTCTB CURSOR FOR SELECT A.NUM_CERTIFICADO, A.NUM_PARCELA, A.NUM_TITULO, A.NUM_APOLICE, A.COD_SUBGRUPO, A.NUM_ENDOSSO, A.COD_OPERACAO, A.DTFATUR, C.DATA_MOV_ABERTO FROM SEGUROS.HIST_CONT_PARCELVA A, SEGUROS.PRODUTOS_VG B, SEGUROS.SISTEMAS C WHERE A.NUM_ENDOSSO > 1 AND A.COD_OPERACAO = 1000 AND A.SIT_REGISTRO IN ( '1' , ' ' ) AND B.NUM_APOLICE = A.NUM_APOLICE AND B.COD_SUBGRUPO = A.COD_SUBGRUPO AND B.ORIG_PRODU IN ( 'EMPRE' , 'ESPEC' ) AND C.IDE_SISTEMA = 'VG' ORDER BY A.NUM_APOLICE, A.COD_SUBGRUPO, A.NUM_PARCELA END-EXEC. */
            CHISTCTB = new VG0004B_CHISTCTB(false);
            string GetQuery_CHISTCTB()
            {
                var query = @$"SELECT A.NUM_CERTIFICADO
							, 
							A.NUM_PARCELA
							, 
							A.NUM_TITULO
							, 
							A.NUM_APOLICE
							, 
							A.COD_SUBGRUPO
							, 
							A.NUM_ENDOSSO
							, 
							A.COD_OPERACAO
							, 
							A.DTFATUR
							, 
							C.DATA_MOV_ABERTO 
							FROM SEGUROS.HIST_CONT_PARCELVA A
							, 
							SEGUROS.PRODUTOS_VG B
							, 
							SEGUROS.SISTEMAS C 
							WHERE A.NUM_ENDOSSO > 1 
							AND A.COD_OPERACAO = 1000 
							AND A.SIT_REGISTRO IN ( '1'
							, ' ' ) 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.COD_SUBGRUPO = A.COD_SUBGRUPO 
							AND B.ORIG_PRODU IN ( 'EMPRE'
							, 'ESPEC' ) 
							AND C.IDE_SISTEMA = 'VG' 
							ORDER BY A.NUM_APOLICE
							, 
							A.COD_SUBGRUPO
							, 
							A.NUM_PARCELA";

                return query;
            }
            CHISTCTB.GetQueryEvent += GetQuery_CHISTCTB;

        }

        [StopWatch]
        /*" M-0900-DECLA-HISTCONTABILVA-DB-OPEN-1 */
        public void M_0900_DECLA_HISTCONTABILVA_DB_OPEN_1()
        {
            /*" -207- EXEC SQL OPEN CHISTCTB END-EXEC. */

            CHISTCTB.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0900_FIM*/

        [StopWatch]
        /*" M-0910-FETCH-HISTCONTABILVA-SECTION */
        private void M_0910_FETCH_HISTCONTABILVA_SECTION()
        {
            /*" -225- MOVE '0910' TO PARAGRAFO. */
            _.Move("0910", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -227- MOVE 'FETCH-FATURAS ' TO COMANDO. */
            _.Move("FETCH-FATURAS ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -238- PERFORM M_0910_FETCH_HISTCONTABILVA_DB_FETCH_1 */

            M_0910_FETCH_HISTCONTABILVA_DB_FETCH_1();

            /*" -241- IF VIND-DTFATUR LESS ZEROES */

            if (VIND_DTFATUR < 00)
            {

                /*" -244- MOVE SPACES TO HISCONPA-DTFATUR. */
                _.Move("", HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_DTFATUR);
            }


            /*" -245- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -246- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -248- MOVE 'S' TO WFIM-HISTCONTABILVA */
                    _.Move("S", WS_WORK_AREAS.WFIM_HISTCONTABILVA);

                    /*" -248- PERFORM M_0910_FETCH_HISTCONTABILVA_DB_CLOSE_1 */

                    M_0910_FETCH_HISTCONTABILVA_DB_CLOSE_1();

                    /*" -250- GO TO 0910-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0910_FIM*/ //GOTO
                    return;

                    /*" -251- ELSE */
                }
                else
                {


                    /*" -252- DISPLAY '0910 - (PROBLEMAS NO FETCH HISTCONTABILVA ' */
                    _.Display($"0910 - (PROBLEMAS NO FETCH HISTCONTABILVA ");

                    /*" -253- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -253- PERFORM M_0910_FETCH_HISTCONTABILVA_DB_CLOSE_2 */

                    M_0910_FETCH_HISTCONTABILVA_DB_CLOSE_2();

                    /*" -255- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -256- ELSE */
                }

            }
            else
            {


                /*" -259- ADD 1 TO AC-L-HISTCTB AC-W-CONTA. */
                WS_WORK_AREAS.AC_L_HISTCTB.Value = WS_WORK_AREAS.AC_L_HISTCTB + 1;
                WS_WORK_AREAS.AC_W_CONTA.Value = WS_WORK_AREAS.AC_W_CONTA + 1;
            }


            /*" -260- IF AC-W-CONTA > 999 */

            if (WS_WORK_AREAS.AC_W_CONTA > 999)
            {

                /*" -261- MOVE ZEROS TO AC-W-CONTA */
                _.Move(0, WS_WORK_AREAS.AC_W_CONTA);

                /*" -262- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), WS_WORK_AREAS.WS_TIME);

                /*" -262- DISPLAY 'LIDOS HISTCTB  ' AC-L-HISTCTB ' ' WS-TIME. */

                $"LIDOS HISTCTB  {WS_WORK_AREAS.AC_L_HISTCTB} {WS_WORK_AREAS.WS_TIME}"
                .Display();
            }


        }

        [StopWatch]
        /*" M-0910-FETCH-HISTCONTABILVA-DB-FETCH-1 */
        public void M_0910_FETCH_HISTCONTABILVA_DB_FETCH_1()
        {
            /*" -238- EXEC SQL FETCH CHISTCTB INTO :HISCONPA-NUM-CERTIFICADO, :HISCONPA-NUM-PARCELA, :HISCONPA-NUM-TITULO, :HISCONPA-NUM-APOLICE, :HISCONPA-COD-SUBGRUPO, :HISCONPA-NUM-ENDOSSO, :HISCONPA-COD-OPERACAO, :HISCONPA-DTFATUR:VIND-DTFATUR, :SISTEMAS-DATA-MOV-ABERTO END-EXEC. */

            if (CHISTCTB.Fetch())
            {
                _.Move(CHISTCTB.HISCONPA_NUM_CERTIFICADO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO);
                _.Move(CHISTCTB.HISCONPA_NUM_PARCELA, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA);
                _.Move(CHISTCTB.HISCONPA_NUM_TITULO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_TITULO);
                _.Move(CHISTCTB.HISCONPA_NUM_APOLICE, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE);
                _.Move(CHISTCTB.HISCONPA_COD_SUBGRUPO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_SUBGRUPO);
                _.Move(CHISTCTB.HISCONPA_NUM_ENDOSSO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO);
                _.Move(CHISTCTB.HISCONPA_COD_OPERACAO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_OPERACAO);
                _.Move(CHISTCTB.HISCONPA_DTFATUR, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_DTFATUR);
                _.Move(CHISTCTB.VIND_DTFATUR, VIND_DTFATUR);
                _.Move(CHISTCTB.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }

        }

        [StopWatch]
        /*" M-0910-FETCH-HISTCONTABILVA-DB-CLOSE-1 */
        public void M_0910_FETCH_HISTCONTABILVA_DB_CLOSE_1()
        {
            /*" -248- EXEC SQL CLOSE CHISTCTB END-EXEC */

            CHISTCTB.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0910_FIM*/

        [StopWatch]
        /*" M-0910-FETCH-HISTCONTABILVA-DB-CLOSE-2 */
        public void M_0910_FETCH_HISTCONTABILVA_DB_CLOSE_2()
        {
            /*" -253- EXEC SQL CLOSE CHISTCTB END-EXEC */

            CHISTCTB.Close();

        }

        [StopWatch]
        /*" M-1000-PROCESSA-SECTION */
        private void M_1000_PROCESSA_SECTION()
        {
            /*" -274- MOVE '1000' TO PARAGRAFO. */
            _.Move("1000", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -275- PERFORM 1050-SELECT-PROPOVA */

            M_1050_SELECT_PROPOVA_SECTION();

            /*" -276- IF PROPOVA-DTPROXVEN EQUAL '9999-12-31' */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN == "9999-12-31")
            {

                /*" -277- GO TO 1000-NEXT */

                M_1000_NEXT(); //GOTO
                return;

                /*" -281- END-IF. */
            }


            /*" -283- PERFORM 1100-SELECT-ENDOSSOS. */

            M_1100_SELECT_ENDOSSOS_SECTION();

            /*" -285- IF ENDOSSOS-SIT-REGISTRO EQUAL '1' */

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_SIT_REGISTRO == "1")
            {

                /*" -287- MOVE 201 TO HISCONPA-COD-OPERACAO */
                _.Move(201, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_OPERACAO);

                /*" -288- PERFORM 1200-UPDATE-PARCELVA */

                M_1200_UPDATE_PARCELVA_SECTION();

                /*" -289- PERFORM 1300-UPDATE-HISTCOBVA */

                M_1300_UPDATE_HISTCOBVA_SECTION();

                /*" -290- PERFORM 1400-UPDATE-HISTCONTABILVA */

                M_1400_UPDATE_HISTCONTABILVA_SECTION();

                /*" -291- ELSE */
            }
            else
            {


                /*" -293- IF ENDOSSOS-SIT-REGISTRO EQUAL '2' */

                if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_SIT_REGISTRO == "2")
                {

                    /*" -295- MOVE 401 TO HISCONPA-COD-OPERACAO */
                    _.Move(401, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_OPERACAO);

                    /*" -296- PERFORM 1200-UPDATE-PARCELVA */

                    M_1200_UPDATE_PARCELVA_SECTION();

                    /*" -297- PERFORM 1300-UPDATE-HISTCOBVA */

                    M_1300_UPDATE_HISTCOBVA_SECTION();

                    /*" -297- PERFORM 1400-UPDATE-HISTCONTABILVA. */

                    M_1400_UPDATE_HISTCONTABILVA_SECTION();
                }

            }


            /*" -0- FLUXCONTROL_PERFORM M_1000_NEXT */

            M_1000_NEXT();

        }

        [StopWatch]
        /*" M-1000-NEXT */
        private void M_1000_NEXT(bool isPerform = false)
        {
            /*" -301- PERFORM 0910-FETCH-HISTCONTABILVA. */

            M_0910_FETCH_HISTCONTABILVA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1000_FIM*/

        [StopWatch]
        /*" M-1050-SELECT-PROPOVA-SECTION */
        private void M_1050_SELECT_PROPOVA_SECTION()
        {
            /*" -310- MOVE '1050' TO PARAGRAFO. */
            _.Move("1050", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -312- MOVE 'SELECT PROPOVA' TO COMANDO. */
            _.Move("SELECT PROPOVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -314- INITIALIZE DCLPROPOSTAS-VA. */
            _.Initialize(
                PROPOVA.DCLPROPOSTAS_VA
            );

            /*" -321- PERFORM M_1050_SELECT_PROPOVA_DB_SELECT_1 */

            M_1050_SELECT_PROPOVA_DB_SELECT_1();

            /*" -324- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -326- DISPLAY '1050 - NAO CADASTRADO NA PROPOSTA_VA' HISCONPA-NUM-CERTIFICADO */
                _.Display($"1050 - NAO CADASTRADO NA PROPOSTA_VA{HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO}");

                /*" -327- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -327- END-IF. */
            }


        }

        [StopWatch]
        /*" M-1050-SELECT-PROPOVA-DB-SELECT-1 */
        public void M_1050_SELECT_PROPOVA_DB_SELECT_1()
        {
            /*" -321- EXEC SQL SELECT DTPROXVEN INTO :PROPOVA-DTPROXVEN FROM SEGUROS.PROPOSTAS_VA WHERE NUM_APOLICE = :HISCONPA-NUM-APOLICE AND COD_SUBGRUPO = :HISCONPA-COD-SUBGRUPO AND NUM_CERTIFICADO = :HISCONPA-NUM-CERTIFICADO END-EXEC. */

            var m_1050_SELECT_PROPOVA_DB_SELECT_1_Query1 = new M_1050_SELECT_PROPOVA_DB_SELECT_1_Query1()
            {
                HISCONPA_NUM_CERTIFICADO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO.ToString(),
                HISCONPA_COD_SUBGRUPO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_SUBGRUPO.ToString(),
                HISCONPA_NUM_APOLICE = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE.ToString(),
            };

            var executed_1 = M_1050_SELECT_PROPOVA_DB_SELECT_1_Query1.Execute(m_1050_SELECT_PROPOVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOVA_DTPROXVEN, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1050_FIM*/

        [StopWatch]
        /*" M-1100-SELECT-ENDOSSOS-SECTION */
        private void M_1100_SELECT_ENDOSSOS_SECTION()
        {
            /*" -336- MOVE '1100' TO PARAGRAFO. */
            _.Move("1100", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -339- MOVE 'SELECT ENDOSSO    ' TO COMANDO. */
            _.Move("SELECT ENDOSSO    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -350- PERFORM M_1100_SELECT_ENDOSSOS_DB_SELECT_1 */

            M_1100_SELECT_ENDOSSOS_DB_SELECT_1();

            /*" -354- IF SQLCODE EQUAL ZEROES NEXT SENTENCE */

            if (DB.SQLCODE == 00)
            {

                /*" -355- ELSE */
            }
            else
            {


                /*" -356- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -361- MOVE '2' TO ENDOSSOS-SIT-REGISTRO */
                    _.Move("2", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_SIT_REGISTRO);

                    /*" -362- ELSE */
                }
                else
                {


                    /*" -365- DISPLAY '1100 - PROBLEMAS NA LEITURA DA ENDOSSOS ' HISCONPA-NUM-APOLICE ' ' HISCONPA-NUM-ENDOSSO */

                    $"1100 - PROBLEMAS NA LEITURA DA ENDOSSOS {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE} {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO}"
                    .Display();

                    /*" -367- GO TO 9999-ERRO. */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -369- ADD 1 TO AC-L-ENDOSSO. */
            WS_WORK_AREAS.AC_L_ENDOSSO.Value = WS_WORK_AREAS.AC_L_ENDOSSO + 1;

            /*" -372- MOVE 'SELECT PARCELAS   ' TO COMANDO. */
            _.Move("SELECT PARCELAS   ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -380- PERFORM M_1100_SELECT_ENDOSSOS_DB_SELECT_2 */

            M_1100_SELECT_ENDOSSOS_DB_SELECT_2();

            /*" -384- IF SQLCODE EQUAL ZEROES NEXT SENTENCE */

            if (DB.SQLCODE == 00)
            {

                /*" -385- ELSE */
            }
            else
            {


                /*" -386- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -389- DISPLAY '1100 - NAO CADASTRADO NA PARCELAS ' HISCONPA-NUM-APOLICE ' ' HISCONPA-NUM-ENDOSSO */

                    $"1100 - NAO CADASTRADO NA PARCELAS {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE} {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO}"
                    .Display();

                    /*" -390- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -391- ELSE */
                }
                else
                {


                    /*" -394- DISPLAY '1100 - PROBLEMAS NA LEITURA DA PARCELAS ' HISCONPA-NUM-APOLICE ' ' HISCONPA-NUM-ENDOSSO */

                    $"1100 - PROBLEMAS NA LEITURA DA PARCELAS {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE} {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO}"
                    .Display();

                    /*" -396- GO TO 9999-ERRO. */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -399- MOVE 'SELECT HISTOPARC  ' TO COMANDO. */
            _.Move("SELECT HISTOPARC  ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -412- PERFORM M_1100_SELECT_ENDOSSOS_DB_SELECT_3 */

            M_1100_SELECT_ENDOSSOS_DB_SELECT_3();

            /*" -416- IF SQLCODE EQUAL ZEROES NEXT SENTENCE */

            if (DB.SQLCODE == 00)
            {

                /*" -417- ELSE */
            }
            else
            {


                /*" -418- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -423- MOVE SISTEMAS-DATA-MOV-ABERTO TO PARCEHIS-DATA-QUITACAO */
                    _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO);

                    /*" -424- GO TO 1100-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1100_FIM*/ //GOTO
                    return;

                    /*" -425- ELSE */
                }
                else
                {


                    /*" -428- DISPLAY '1100 - PROBLEMAS NA LEITURA DA HISTOPARC ' HISCONPA-NUM-APOLICE ' ' HISCONPA-NUM-ENDOSSO */

                    $"1100 - PROBLEMAS NA LEITURA DA HISTOPARC {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE} {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO}"
                    .Display();

                    /*" -428- GO TO 9999-ERRO. */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-1100-SELECT-ENDOSSOS-DB-SELECT-1 */
        public void M_1100_SELECT_ENDOSSOS_DB_SELECT_1()
        {
            /*" -350- EXEC SQL SELECT SIT_REGISTRO INTO :ENDOSSOS-SIT-REGISTRO FROM SEGUROS.ENDOSSOS WHERE NUM_APOLICE = :HISCONPA-NUM-APOLICE AND COD_SUBGRUPO = :HISCONPA-COD-SUBGRUPO AND NUM_ENDOSSO = :HISCONPA-NUM-ENDOSSO AND TIPO_ENDOSSO = '1' END-EXEC. */

            var m_1100_SELECT_ENDOSSOS_DB_SELECT_1_Query1 = new M_1100_SELECT_ENDOSSOS_DB_SELECT_1_Query1()
            {
                HISCONPA_COD_SUBGRUPO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_SUBGRUPO.ToString(),
                HISCONPA_NUM_APOLICE = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE.ToString(),
                HISCONPA_NUM_ENDOSSO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = M_1100_SELECT_ENDOSSOS_DB_SELECT_1_Query1.Execute(m_1100_SELECT_ENDOSSOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDOSSOS_SIT_REGISTRO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_SIT_REGISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1100_FIM*/

        [StopWatch]
        /*" M-1100-SELECT-ENDOSSOS-DB-SELECT-2 */
        public void M_1100_SELECT_ENDOSSOS_DB_SELECT_2()
        {
            /*" -380- EXEC SQL SELECT OCORR_HISTORICO INTO :PARCELAS-OCORR-HISTORICO FROM SEGUROS.PARCELAS WHERE NUM_APOLICE = :HISCONPA-NUM-APOLICE AND NUM_ENDOSSO = :HISCONPA-NUM-ENDOSSO END-EXEC. */

            var m_1100_SELECT_ENDOSSOS_DB_SELECT_2_Query1 = new M_1100_SELECT_ENDOSSOS_DB_SELECT_2_Query1()
            {
                HISCONPA_NUM_APOLICE = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE.ToString(),
                HISCONPA_NUM_ENDOSSO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = M_1100_SELECT_ENDOSSOS_DB_SELECT_2_Query1.Execute(m_1100_SELECT_ENDOSSOS_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARCELAS_OCORR_HISTORICO, PARCELAS.DCLPARCELAS.PARCELAS_OCORR_HISTORICO);
            }


        }

        [StopWatch]
        /*" M-1200-UPDATE-PARCELVA-SECTION */
        private void M_1200_UPDATE_PARCELVA_SECTION()
        {
            /*" -438- MOVE '1200' TO PARAGRAFO. */
            _.Move("1200", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -440- MOVE 'UPDATE PARCELVA' TO COMANDO. */
            _.Move("UPDATE PARCELVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -450- PERFORM M_1200_UPDATE_PARCELVA_DB_UPDATE_1 */

            M_1200_UPDATE_PARCELVA_DB_UPDATE_1();

            /*" -453- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -454- DISPLAY '1200 - PROBLEMA NO UPDATE PARCELVA ' */
                _.Display($"1200 - PROBLEMA NO UPDATE PARCELVA ");

                /*" -456- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -456- ADD 1 TO AC-U-PARCELVA. */
            WS_WORK_AREAS.AC_U_PARCELVA.Value = WS_WORK_AREAS.AC_U_PARCELVA + 1;

        }

        [StopWatch]
        /*" M-1200-UPDATE-PARCELVA-DB-UPDATE-1 */
        public void M_1200_UPDATE_PARCELVA_DB_UPDATE_1()
        {
            /*" -450- EXEC SQL UPDATE SEGUROS.PARCELAS_VIDAZUL SET SIT_REGISTRO = :ENDOSSOS-SIT-REGISTRO, TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_CERTIFICADO = :HISCONPA-NUM-CERTIFICADO AND NUM_PARCELA = :HISCONPA-NUM-PARCELA END-EXEC. */

            var m_1200_UPDATE_PARCELVA_DB_UPDATE_1_Update1 = new M_1200_UPDATE_PARCELVA_DB_UPDATE_1_Update1()
            {
                ENDOSSOS_SIT_REGISTRO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_SIT_REGISTRO.ToString(),
                HISCONPA_NUM_CERTIFICADO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO.ToString(),
                HISCONPA_NUM_PARCELA = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA.ToString(),
            };

            M_1200_UPDATE_PARCELVA_DB_UPDATE_1_Update1.Execute(m_1200_UPDATE_PARCELVA_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-1100-SELECT-ENDOSSOS-DB-SELECT-3 */
        public void M_1100_SELECT_ENDOSSOS_DB_SELECT_3()
        {
            /*" -412- EXEC SQL SELECT VALUE(DATA_QUITACAO, DATE(:SISTEMAS-DATA-MOV-ABERTO)) INTO :PARCEHIS-DATA-QUITACAO FROM SEGUROS.PARCELA_HISTORICO WHERE NUM_APOLICE = :HISCONPA-NUM-APOLICE AND NUM_ENDOSSO = :HISCONPA-NUM-ENDOSSO AND OCORR_HISTORICO = :PARCELAS-OCORR-HISTORICO AND COD_OPERACAO BETWEEN 200 AND 299 END-EXEC. */

            var m_1100_SELECT_ENDOSSOS_DB_SELECT_3_Query1 = new M_1100_SELECT_ENDOSSOS_DB_SELECT_3_Query1()
            {
                PARCELAS_OCORR_HISTORICO = PARCELAS.DCLPARCELAS.PARCELAS_OCORR_HISTORICO.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                HISCONPA_NUM_APOLICE = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE.ToString(),
                HISCONPA_NUM_ENDOSSO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = M_1100_SELECT_ENDOSSOS_DB_SELECT_3_Query1.Execute(m_1100_SELECT_ENDOSSOS_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARCEHIS_DATA_QUITACAO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1200_FIM*/

        [StopWatch]
        /*" M-1300-UPDATE-HISTCOBVA-SECTION */
        private void M_1300_UPDATE_HISTCOBVA_SECTION()
        {
            /*" -465- MOVE '1300' TO PARAGRAFO. */
            _.Move("1300", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -468- MOVE 'UPDATE HISTCOBVA' TO COMANDO. */
            _.Move("UPDATE HISTCOBVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -478- PERFORM M_1300_UPDATE_HISTCOBVA_DB_UPDATE_1 */

            M_1300_UPDATE_HISTCOBVA_DB_UPDATE_1();

            /*" -481- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -482- DISPLAY '1300 - PROBLEMA NO UPDATE HISTCOBVA ' */
                _.Display($"1300 - PROBLEMA NO UPDATE HISTCOBVA ");

                /*" -484- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -484- ADD 1 TO AC-U-HISTCOBVA. */
            WS_WORK_AREAS.AC_U_HISTCOBVA.Value = WS_WORK_AREAS.AC_U_HISTCOBVA + 1;

        }

        [StopWatch]
        /*" M-1300-UPDATE-HISTCOBVA-DB-UPDATE-1 */
        public void M_1300_UPDATE_HISTCOBVA_DB_UPDATE_1()
        {
            /*" -478- EXEC SQL UPDATE SEGUROS.COBER_HIST_VIDAZUL SET SIT_REGISTRO = :ENDOSSOS-SIT-REGISTRO WHERE NUM_CERTIFICADO = :HISCONPA-NUM-CERTIFICADO AND NUM_PARCELA = :HISCONPA-NUM-PARCELA AND NUM_TITULO = :HISCONPA-NUM-TITULO END-EXEC. */

            var m_1300_UPDATE_HISTCOBVA_DB_UPDATE_1_Update1 = new M_1300_UPDATE_HISTCOBVA_DB_UPDATE_1_Update1()
            {
                ENDOSSOS_SIT_REGISTRO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_SIT_REGISTRO.ToString(),
                HISCONPA_NUM_CERTIFICADO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO.ToString(),
                HISCONPA_NUM_PARCELA = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA.ToString(),
                HISCONPA_NUM_TITULO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_TITULO.ToString(),
            };

            M_1300_UPDATE_HISTCOBVA_DB_UPDATE_1_Update1.Execute(m_1300_UPDATE_HISTCOBVA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1300_FIM*/

        [StopWatch]
        /*" M-1400-UPDATE-HISTCONTABILVA-SECTION */
        private void M_1400_UPDATE_HISTCONTABILVA_SECTION()
        {
            /*" -493- MOVE '1400' TO PARAGRAFO. */
            _.Move("1400", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -496- MOVE 'UPDATE HISTCONTABILVA ' TO COMANDO. */
            _.Move("UPDATE HISTCONTABILVA ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -513- PERFORM M_1400_UPDATE_HISTCONTABILVA_DB_UPDATE_1 */

            M_1400_UPDATE_HISTCONTABILVA_DB_UPDATE_1();

            /*" -516- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -517- DISPLAY '1400 - PROBLEMA NO UPDATE HISTCONTABILVA ' */
                _.Display($"1400 - PROBLEMA NO UPDATE HISTCONTABILVA ");

                /*" -519- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -520- ADD 1 TO AC-U-HISTCTBILVA. */
            WS_WORK_AREAS.AC_U_HISTCTBILVA.Value = WS_WORK_AREAS.AC_U_HISTCTBILVA + 1;

        }

        [StopWatch]
        /*" M-1400-UPDATE-HISTCONTABILVA-DB-UPDATE-1 */
        public void M_1400_UPDATE_HISTCONTABILVA_DB_UPDATE_1()
        {
            /*" -513- EXEC SQL UPDATE SEGUROS.HIST_CONT_PARCELVA SET COD_OPERACAO = :HISCONPA-COD-OPERACAO, SIT_REGISTRO = :ENDOSSOS-SIT-REGISTRO, DATA_MOVIMENTO = :PARCEHIS-DATA-QUITACAO, TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_CERTIFICADO = :HISCONPA-NUM-CERTIFICADO AND NUM_PARCELA = :HISCONPA-NUM-PARCELA AND NUM_TITULO = :HISCONPA-NUM-TITULO AND NUM_ENDOSSO > 1 END-EXEC. */

            var m_1400_UPDATE_HISTCONTABILVA_DB_UPDATE_1_Update1 = new M_1400_UPDATE_HISTCONTABILVA_DB_UPDATE_1_Update1()
            {
                PARCEHIS_DATA_QUITACAO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO.ToString(),
                HISCONPA_COD_OPERACAO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_OPERACAO.ToString(),
                ENDOSSOS_SIT_REGISTRO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_SIT_REGISTRO.ToString(),
                HISCONPA_NUM_CERTIFICADO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO.ToString(),
                HISCONPA_NUM_PARCELA = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA.ToString(),
                HISCONPA_NUM_TITULO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_TITULO.ToString(),
            };

            M_1400_UPDATE_HISTCONTABILVA_DB_UPDATE_1_Update1.Execute(m_1400_UPDATE_HISTCONTABILVA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1400_FIM*/

        [StopWatch]
        /*" M-9999-ERRO-SECTION */
        private void M_9999_ERRO_SECTION()
        {
            /*" -531- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -532- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], WABEND.WSQLERRD1);

            /*" -533- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], WABEND.WSQLERRD2);

            /*" -534- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -539- DISPLAY HISCONPA-NUM-APOLICE ' ' HISCONPA-COD-SUBGRUPO ' ' HISCONPA-NUM-CERTIFICADO ' ' HISCONPA-NUM-PARCELA */

            $"{HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE} {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_SUBGRUPO} {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO} {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA}"
            .Display();

            /*" -541- DISPLAY '*** VG0004B *** ROLLBACK EM ANDAMENTO ...' . */
            _.Display($"*** VG0004B *** ROLLBACK EM ANDAMENTO ...");

            /*" -541- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -544- MOVE '9999' TO PARAGRAFO. */
            _.Move("9999", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -545- MOVE 'ROLLBACK WORK' TO COMANDO. */
            _.Move("ROLLBACK WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -545- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -549- DISPLAY '*** VG0004B *** ERRO DE EXECUCAO' . */
            _.Display($"*** VG0004B *** ERRO DE EXECUCAO");

            /*" -550- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -550- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}