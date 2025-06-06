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
using Sias.Outros.DB2.SPBFC003;

namespace Code
{
    public class SPBFC003
    {
        public bool IsCall { get; set; }

        public SPBFC003()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................ SIATC                               *      */
        /*"      *   STORED PROCEDURE ....... SPBFC003                            *      */
        /*"      *   PROGRAMADOR ............ KINKAS                              *      */
        /*"      *   DATA CODIFICACAO ....... JAN / 2004                          *      */
        /*"      *   FUNCAO ................. RESERVA SEQUENCIAS                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                       MANUTENCOES                              *      */
        /*"      *VERSAO: 23/05/2019 - RENATO  - CA10326 - INCLUI ACESSO AS       *      */
        /*"      *                     SEQUENCES DB2                                     */
        /*"      *      : 23/11/2017 - ALCIONE - CA154089 - INCLUI ACESSO AA      *      */
        /*"      *                     SEQUENCE DB2 PARA COD-SEQ HTI - HISTORICO  *      */
        /*"      *      : 01/09/2017 - KINKAS  - CA153893 - INCLUI ACESSO AA      *      */
        /*"      *                     SEQUENCE DB2 PARA COD-SEQ IDSAP            *      */
        /*"      *      : 04/11/2016 - ALCIONE - CA143615 - ALTERA CURSOR         *      */
        /*"      *      :            - COMPILACAO MULTIEMPRESA                    *      */
        /*"      *      : 29/06/2006 - ALTERACAO NO CAMPO LK-IN-QTD-SEQ DE S9(009)*      */
        /*"      *                     PARA S9(004).                              *      */
        /*"      *      : 14/01/2004 AS 20H49                                     *      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"77              W77-SEQ-D               PIC 9(009) VALUE ZEROS.*/
        public IntBasis W77_SEQ_D { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"77              W77-MENSAGEM            PIC X(070) VALUE SPACES.*/
        public StringBasis W77_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
        /*"01              LK-IN-COD-SEQ           PIC  X(005).*/
        public StringBasis LK_IN_COD_SEQ { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
        /*"01              LK-IN-QTD-SEQ           PIC S9(004) COMP.*/
        public IntBasis LK_IN_QTD_SEQ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01              LK-OUT-NUM-SEQ-INI      PIC S9(009) COMP.*/
        public IntBasis LK_OUT_NUM_SEQ_INI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01              LK-OUT-NUM-SEQ-FIM      PIC S9(009) COMP.*/
        public IntBasis LK_OUT_NUM_SEQ_FIM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01              LK-OUT-COD-RETORNO      PIC S9(004) COMP.*/
        public IntBasis LK_OUT_COD_RETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01              LK-OUT-SQLCODE          PIC S9(004) COMP.*/
        public IntBasis LK_OUT_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01              LK-OUT-MENSAGEM         PIC X(070).*/
        public StringBasis LK_OUT_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
        /*"01              LK-OUT-SQLERRMC         PIC X(070).*/
        public StringBasis LK_OUT_SQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
        /*"01              LK-OUT-SQLSTATE         PIC X(005).*/
        public StringBasis LK_OUT_SQLSTATE { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");


        public Dclgens.FCSEQUEN FCSEQUEN { get; set; } = new Dclgens.FCSEQUEN();

        public SPBFC003_CSS_SEQUENCE CSS_SEQUENCE { get; set; } = new SPBFC003_CSS_SEQUENCE(true);
        string GetQuery_CSS_SEQUENCE()
        {
            var query = @$"SELECT NUM_SEQ
							FROM FDRCAP.FC_SEQUENCE WHERE COD_SEQ = '{FCSEQUEN.DCLFC_SEQUENCE.FCSEQUEN_COD_SEQ}' FETCH FIRST 1 ROWS ONLY WITH RR USE AND KEEP EXCLUSIVE LOCKS";

            return query;
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(StringBasis LK_IN_COD_SEQ_P, IntBasis LK_IN_QTD_SEQ_P, IntBasis LK_OUT_NUM_SEQ_INI_P, IntBasis LK_OUT_NUM_SEQ_FIM_P, IntBasis LK_OUT_COD_RETORNO_P, IntBasis LK_OUT_SQLCODE_P, StringBasis LK_OUT_MENSAGEM_P, StringBasis LK_OUT_SQLERRMC_P, StringBasis LK_OUT_SQLSTATE_P) //PROCEDURE DIVISION USING 
        /*LK_IN_COD_SEQ
        LK_IN_QTD_SEQ
        LK_OUT_NUM_SEQ_INI
        LK_OUT_NUM_SEQ_FIM
        LK_OUT_COD_RETORNO
        LK_OUT_SQLCODE
        LK_OUT_MENSAGEM
        LK_OUT_SQLERRMC
        LK_OUT_SQLSTATE*/
        {
            try
            {
                this.LK_IN_COD_SEQ.Value = LK_IN_COD_SEQ_P.Value;
                this.LK_IN_QTD_SEQ.Value = LK_IN_QTD_SEQ_P.Value;
                this.LK_OUT_NUM_SEQ_INI.Value = LK_OUT_NUM_SEQ_INI_P.Value;
                this.LK_OUT_NUM_SEQ_FIM.Value = LK_OUT_NUM_SEQ_FIM_P.Value;
                this.LK_OUT_COD_RETORNO.Value = LK_OUT_COD_RETORNO_P.Value;
                this.LK_OUT_SQLCODE.Value = LK_OUT_SQLCODE_P.Value;
                this.LK_OUT_MENSAGEM.Value = LK_OUT_MENSAGEM_P.Value;
                this.LK_OUT_SQLERRMC.Value = LK_OUT_SQLERRMC_P.Value;
                this.LK_OUT_SQLSTATE.Value = LK_OUT_SQLSTATE_P.Value;
                InitializeGetQuery();

                /*" -0- FLUXCONTROL_PERFORM P000-INICIO */

                P000_INICIO();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LK_IN_COD_SEQ, LK_IN_QTD_SEQ, LK_OUT_NUM_SEQ_INI, LK_OUT_NUM_SEQ_FIM, LK_OUT_COD_RETORNO, LK_OUT_SQLCODE, LK_OUT_MENSAGEM, LK_OUT_SQLERRMC, LK_OUT_SQLSTATE };
            return Result;
        }

        public void InitializeGetQuery()
        {
            CSS_SEQUENCE.GetQueryEvent += GetQuery_CSS_SEQUENCE;
        }

        [StopWatch]
        /*" P000-INICIO */
        private void P000_INICIO(bool isPerform = false)
        {
            /*" -90- INITIALIZE LK-OUT-NUM-SEQ-INI LK-OUT-NUM-SEQ-FIM LK-OUT-COD-RETORNO LK-OUT-SQLCODE LK-OUT-MENSAGEM LK-OUT-SQLERRMC LK-OUT-SQLSTATE LK-OUT-MENSAGEM W77-MENSAGEM. */
            _.Initialize(
                LK_OUT_NUM_SEQ_INI
                , LK_OUT_NUM_SEQ_FIM
                , LK_OUT_COD_RETORNO
                , LK_OUT_SQLCODE
                , LK_OUT_MENSAGEM
                , LK_OUT_SQLERRMC
                , LK_OUT_SQLSTATE
                , LK_OUT_MENSAGEM
                , W77_MENSAGEM
            );

            /*" -101- IF LK-IN-COD-SEQ = 'IDSAP' OR LK-IN-COD-SEQ = 'HTI' OR LK-IN-COD-SEQ = 'AJREC' OR LK-IN-COD-SEQ = 'CLI' OR LK-IN-COD-SEQ = 'COB' OR LK-IN-COD-SEQ = 'END' OR LK-IN-COD-SEQ = 'HCL' OR LK-IN-COD-SEQ = 'HEN' OR LK-IN-COD-SEQ = 'IAR' OR LK-IN-COD-SEQ = 'OPB' OR LK-IN-COD-SEQ = 'OPC' OR LK-IN-COD-SEQ = 'REC' OR LK-IN-COD-SEQ = 'RST' OR LK-IN-COD-SEQ = 'TIS' OR LK-IN-COD-SEQ = 'USR' */

            if (LK_IN_COD_SEQ == "IDSAP" || LK_IN_COD_SEQ == "HTI" || LK_IN_COD_SEQ == "AJREC" || LK_IN_COD_SEQ == "CLI" || LK_IN_COD_SEQ == "COB" || LK_IN_COD_SEQ == "END" || LK_IN_COD_SEQ == "HCL" || LK_IN_COD_SEQ == "HEN" || LK_IN_COD_SEQ == "IAR" || LK_IN_COD_SEQ == "OPB" || LK_IN_COD_SEQ == "OPC" || LK_IN_COD_SEQ == "REC" || LK_IN_COD_SEQ == "RST" || LK_IN_COD_SEQ == "TIS" || LK_IN_COD_SEQ == "USR")
            {

                /*" -102- IF LK-IN-QTD-SEQ > 1 */

                if (LK_IN_QTD_SEQ > 1)
                {

                    /*" -103- MOVE LK-IN-QTD-SEQ TO W77-SEQ-D */
                    _.Move(LK_IN_QTD_SEQ, W77_SEQ_D);

                    /*" -105- STRING 'QTD-SEQ (' W77-SEQ-D ') TEM QUE SER 1.' DELIMITED BY SIZE INTO W77-MENSAGEM */
                    #region STRING
                    var spl1 = "QTD-SEQ(" + W77_SEQ_D.GetMoveValues();
                    spl1 += ") TEM QUE SER 1.";
                    _.Move(spl1, W77_MENSAGEM);
                    #endregion

                    /*" -106- MOVE 1 TO LK-OUT-COD-RETORNO */
                    _.Move(1, LK_OUT_COD_RETORNO);

                    /*" -107- GO TO P999-ENCERRA-PROGRAMA */

                    P999_ENCERRA_PROGRAMA(); //GOTO
                    return;

                    /*" -109- END-IF */
                }


                /*" -111- END-IF */
            }


            /*" -113- EVALUATE LK-IN-COD-SEQ */
            switch (LK_IN_COD_SEQ.Value.Trim())
            {

                /*" -113- WHEN 'IDSAP' */
                case "IDSAP":

                    /*" -113- PERFORM P100-ACESSA-SEQUENCE-FC302SQ */

                    P100_ACESSA_SEQUENCE_FC302SQ(true);

                    /*" -114- WHEN 'HTI' */
                    break;
                case "HTI":

                    /*" -114- PERFORM P100-ACESSA-SEQUENCE-FC103SQ */

                    P100_ACESSA_SEQUENCE_FC103SQ(true);

                    /*" -115- WHEN 'AJREC' */
                    break;
                case "AJREC":

                    /*" -115- PERFORM P100-ACESSA-SEQUENCE-FC222SQ */

                    P100_ACESSA_SEQUENCE_FC222SQ(true);

                    /*" -116- WHEN 'CLI' */
                    break;
                case "CLI":

                    /*" -116- PERFORM P100-ACESSA-SEQUENCE-FC035SQ */

                    P100_ACESSA_SEQUENCE_FC035SQ(true);

                    /*" -117- WHEN 'COB' */
                    break;
                case "COB":

                    /*" -117- PERFORM P100-ACESSA-SEQUENCE-FC085SQ */

                    P100_ACESSA_SEQUENCE_FC085SQ(true);

                    /*" -118- WHEN 'END' */
                    break;
                case "END":

                    /*" -118- PERFORM P100-ACESSA-SEQUENCE-FC036SQ */

                    P100_ACESSA_SEQUENCE_FC036SQ(true);

                    /*" -119- WHEN 'HCL' */
                    break;
                case "HCL":

                    /*" -119- PERFORM P100-ACESSA-SEQUENCE-FC105SQ */

                    P100_ACESSA_SEQUENCE_FC105SQ(true);

                    /*" -120- WHEN 'HEN' */
                    break;
                case "HEN":

                    /*" -120- PERFORM P100-ACESSA-SEQUENCE-FC106SQ */

                    P100_ACESSA_SEQUENCE_FC106SQ(true);

                    /*" -121- WHEN 'IAR' */
                    break;
                case "IAR":

                    /*" -121- PERFORM P100-ACESSA-SEQUENCE-FC092SQ */

                    P100_ACESSA_SEQUENCE_FC092SQ(true);

                    /*" -122- WHEN 'OPB' */
                    break;
                case "OPB":

                    /*" -122- PERFORM P100-ACESSA-SEQUENCE-FC084SQ */

                    P100_ACESSA_SEQUENCE_FC084SQ(true);

                    /*" -123- WHEN 'OPC' */
                    break;
                case "OPC":

                    /*" -123- PERFORM P100-ACESSA-SEQUENCE-FC216SQ */

                    P100_ACESSA_SEQUENCE_FC216SQ(true);

                    /*" -124- WHEN 'REC' */
                    break;
                case "REC":

                    /*" -124- PERFORM P100-ACESSA-SEQUENCE-FC002SQ */

                    P100_ACESSA_SEQUENCE_FC002SQ(true);

                    /*" -125- WHEN 'RST' */
                    break;
                case "RST":

                    /*" -125- PERFORM P100-ACESSA-SEQUENCE-FC074SQ */

                    P100_ACESSA_SEQUENCE_FC074SQ(true);

                    /*" -126- WHEN 'TIS' */
                    break;
                case "TIS":

                    /*" -126- PERFORM P100-ACESSA-SEQUENCE-FC072SQ */

                    P100_ACESSA_SEQUENCE_FC072SQ(true);

                    /*" -127- WHEN 'USR' */
                    break;
                case "USR":

                    /*" -127- PERFORM P100-ACESSA-SEQUENCE-FC037SQ */

                    P100_ACESSA_SEQUENCE_FC037SQ(true);

                    /*" -136- WHEN OTHER */
                    break;
                default:

                    /*" -138- PERFORM P050-PROCESSA-FC-SEQUENCE */

                    P050_PROCESSA_FC_SEQUENCE(true);

                    /*" -141- END-EVALUATE */
                    break;
            }


            /*" -142- GO TO P999-ENCERRA-PROGRAMA */

            P999_ENCERRA_PROGRAMA(); //GOTO
            return;

            /*" -142- . */

        }

        [StopWatch]
        /*" P050-PROCESSA-FC-SEQUENCE */
        private void P050_PROCESSA_FC_SEQUENCE(bool isPerform = false)
        {
            /*" -148- MOVE LK-IN-COD-SEQ TO FCSEQUEN-COD-SEQ */
            _.Move(LK_IN_COD_SEQ, FCSEQUEN.DCLFC_SEQUENCE.FCSEQUEN_COD_SEQ);

            /*" -148- PERFORM P050_PROCESSA_FC_SEQUENCE_DB_OPEN_1 */

            P050_PROCESSA_FC_SEQUENCE_DB_OPEN_1();

            /*" -151- IF SQLCODE NOT = 000 */

            if (DB.SQLCODE != 000)
            {

                /*" -154- STRING 'ERRO NO OPEN <CSS-SEQUENCE>. ' 'COD SEQ <' FCSEQUEN-COD-SEQ '>' DELIMITED BY SIZE INTO W77-MENSAGEM */
                #region STRING
                var spl2 = "ERRO NO OPEN <CSS-SEQUENCE>. " + "COD SEQ <" + FCSEQUEN.DCLFC_SEQUENCE.FCSEQUEN_COD_SEQ.GetMoveValues();
                spl2 += ">";
                _.Move(spl2, W77_MENSAGEM);
                #endregion

                /*" -155- PERFORM P999-DB2-ERROR */

                P999_DB2_ERROR(true);

                /*" -156- GO TO P999-ENCERRA-PROGRAMA */

                P999_ENCERRA_PROGRAMA(); //GOTO
                return;

                /*" -158- END-IF */
            }


            /*" -161- PERFORM P050_PROCESSA_FC_SEQUENCE_DB_FETCH_1 */

            P050_PROCESSA_FC_SEQUENCE_DB_FETCH_1();

            /*" -164- IF SQLCODE NOT = 000 AND +100 */

            if (!DB.SQLCODE.In("000", "+100"))
            {

                /*" -167- STRING 'ERRO NO FETCH <CSS-SEQUENCE>. ' 'COD SEQ <' FCSEQUEN-COD-SEQ '>' DELIMITED BY SIZE INTO W77-MENSAGEM */
                #region STRING
                var spl3 = "ERRO NO FETCH <CSS-SEQUENCE>. " + "COD SEQ <" + FCSEQUEN.DCLFC_SEQUENCE.FCSEQUEN_COD_SEQ.GetMoveValues();
                spl3 += ">";
                _.Move(spl3, W77_MENSAGEM);
                #endregion

                /*" -168- PERFORM P999-DB2-ERROR */

                P999_DB2_ERROR(true);

                /*" -169- GO TO P999-ENCERRA-PROGRAMA */

                P999_ENCERRA_PROGRAMA(); //GOTO
                return;

                /*" -171- END-IF */
            }


            /*" -172- IF SQLCODE = +100 */

            if (DB.SQLCODE == +100)
            {

                /*" -175- STRING 'CODIGO SEQUENCIA <' FCSEQUEN-COD-SEQ '> NAO ENCONTRADO' DELIMITED BY SIZE INTO W77-MENSAGEM */
                #region STRING
                var spl4 = "CODIGO SEQUENCIA <" + FCSEQUEN.DCLFC_SEQUENCE.FCSEQUEN_COD_SEQ.GetMoveValues();
                spl4 += "> NAO ENCONTRADO";
                _.Move(spl4, W77_MENSAGEM);
                #endregion

                /*" -176- PERFORM P999-DB2-ERROR */

                P999_DB2_ERROR(true);

                /*" -177- GO TO P999-ENCERRA-PROGRAMA */

                P999_ENCERRA_PROGRAMA(); //GOTO
                return;

                /*" -179- END-IF */
            }


            /*" -180- MOVE FCSEQUEN-NUM-SEQ TO LK-OUT-NUM-SEQ-INI */
            _.Move(FCSEQUEN.DCLFC_SEQUENCE.FCSEQUEN_NUM_SEQ, LK_OUT_NUM_SEQ_INI);

            /*" -181- ADD 1 TO LK-OUT-NUM-SEQ-INI */
            LK_OUT_NUM_SEQ_INI.Value = LK_OUT_NUM_SEQ_INI + 1;

            /*" -182- ADD LK-IN-QTD-SEQ TO FCSEQUEN-NUM-SEQ */
            FCSEQUEN.DCLFC_SEQUENCE.FCSEQUEN_NUM_SEQ.Value = FCSEQUEN.DCLFC_SEQUENCE.FCSEQUEN_NUM_SEQ + LK_IN_QTD_SEQ;

            /*" -185- MOVE FCSEQUEN-NUM-SEQ TO LK-OUT-NUM-SEQ-FIM */
            _.Move(FCSEQUEN.DCLFC_SEQUENCE.FCSEQUEN_NUM_SEQ, LK_OUT_NUM_SEQ_FIM);

            /*" -189- PERFORM P050_PROCESSA_FC_SEQUENCE_DB_UPDATE_1 */

            P050_PROCESSA_FC_SEQUENCE_DB_UPDATE_1();

            /*" -192- IF SQLCODE NOT = 000 */

            if (DB.SQLCODE != 000)
            {

                /*" -193- MOVE FCSEQUEN-NUM-SEQ TO W77-SEQ-D */
                _.Move(FCSEQUEN.DCLFC_SEQUENCE.FCSEQUEN_NUM_SEQ, W77_SEQ_D);

                /*" -197- STRING 'ERRO NO UPDATE <CSS-SEQUENCE>. ' 'CODSEQ <' FCSEQUEN-COD-SEQ '> ' 'NUMSEQ <' W77-SEQ-D '>' DELIMITED BY SIZE INTO W77-MENSAGEM */
                #region STRING
                var spl5 = "ERRO NO UPDATE <CSS-SEQUENCE>. " + "CODSEQ <" + FCSEQUEN.DCLFC_SEQUENCE.FCSEQUEN_COD_SEQ.GetMoveValues();
                spl5 += "> ";
                spl5 += "NUMSEQ <";
                var spl6 = W77_SEQ_D.GetMoveValues();
                spl6 += ">";
                var results7 = spl5 + spl6;
                _.Move(results7, W77_MENSAGEM);
                #endregion

                /*" -198- PERFORM P999-DB2-ERROR */

                P999_DB2_ERROR(true);

                /*" -199- GO TO P999-ENCERRA-PROGRAMA */

                P999_ENCERRA_PROGRAMA(); //GOTO
                return;

                /*" -201- END-IF */
            }


            /*" -201- PERFORM P050_PROCESSA_FC_SEQUENCE_DB_CLOSE_1 */

            P050_PROCESSA_FC_SEQUENCE_DB_CLOSE_1();

            /*" -204- IF SQLCODE NOT = 000 */

            if (DB.SQLCODE != 000)
            {

                /*" -207- STRING 'ERRO NO CLOSE <CSS-SEQUENCE>. ' 'CODSEQ <' FCSEQUEN-COD-SEQ '>' DELIMITED BY SIZE INTO W77-MENSAGEM */
                #region STRING
                var spl7 = "ERRO NO CLOSE <CSS-SEQUENCE>. " + "CODSEQ <" + FCSEQUEN.DCLFC_SEQUENCE.FCSEQUEN_COD_SEQ.GetMoveValues();
                spl7 += ">";
                _.Move(spl7, W77_MENSAGEM);
                #endregion

                /*" -208- PERFORM P999-DB2-ERROR */

                P999_DB2_ERROR(true);

                /*" -209- GO TO P999-ENCERRA-PROGRAMA */

                P999_ENCERRA_PROGRAMA(); //GOTO
                return;

                /*" -210- END-IF */
            }


            /*" -210- . */

        }

        [StopWatch]
        /*" P050-PROCESSA-FC-SEQUENCE-DB-OPEN-1 */
        public void P050_PROCESSA_FC_SEQUENCE_DB_OPEN_1()
        {
            /*" -148- EXEC SQL OPEN CSS-SEQUENCE END-EXEC */

            CSS_SEQUENCE.Open();

        }

        [StopWatch]
        /*" P050-PROCESSA-FC-SEQUENCE-DB-FETCH-1 */
        public void P050_PROCESSA_FC_SEQUENCE_DB_FETCH_1()
        {
            /*" -161- EXEC SQL FETCH CSS-SEQUENCE INTO :FCSEQUEN-NUM-SEQ END-EXEC */

            if (CSS_SEQUENCE.Fetch())
            {
                _.Move(CSS_SEQUENCE.FCSEQUEN_NUM_SEQ, FCSEQUEN.DCLFC_SEQUENCE.FCSEQUEN_NUM_SEQ);
            }

        }

        [StopWatch]
        /*" P050-PROCESSA-FC-SEQUENCE-DB-UPDATE-1 */
        public void P050_PROCESSA_FC_SEQUENCE_DB_UPDATE_1()
        {
            /*" -189- EXEC SQL UPDATE FDRCAP.FC_SEQUENCE SET NUM_SEQ = :FCSEQUEN-NUM-SEQ WHERE COD_SEQ = :FCSEQUEN-COD-SEQ END-EXEC */

            var p050_PROCESSA_FC_SEQUENCE_DB_UPDATE_1_Update1 = new P050_PROCESSA_FC_SEQUENCE_DB_UPDATE_1_Update1()
            {
                FCSEQUEN_NUM_SEQ = FCSEQUEN.DCLFC_SEQUENCE.FCSEQUEN_NUM_SEQ.ToString(),
                FCSEQUEN_COD_SEQ = FCSEQUEN.DCLFC_SEQUENCE.FCSEQUEN_COD_SEQ.ToString(),
            };

            P050_PROCESSA_FC_SEQUENCE_DB_UPDATE_1_Update1.Execute(p050_PROCESSA_FC_SEQUENCE_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" P050-PROCESSA-FC-SEQUENCE-DB-CLOSE-1 */
        public void P050_PROCESSA_FC_SEQUENCE_DB_CLOSE_1()
        {
            /*" -201- EXEC SQL CLOSE CSS-SEQUENCE END-EXEC */

            CSS_SEQUENCE.Close();

        }

        [StopWatch]
        /*" P100-ACESSA-SEQUENCE-FC302SQ */
        private void P100_ACESSA_SEQUENCE_FC302SQ(bool isPerform = false)
        {
            /*" -220- PERFORM P100_ACESSA_SEQUENCE_FC302SQ_DB_SEQUENCE_1 */

            P100_ACESSA_SEQUENCE_FC302SQ_DB_SEQUENCE_1();

            /*" -223- IF SQLCODE NOT = 000 */

            if (DB.SQLCODE != 000)
            {

                /*" -226- STRING 'ERRO NO ACESSO DA SEQUENCE FDRCAP.FC302SQ PARA ' 'COD SEQ =' LK-IN-COD-SEQ DELIMITED BY SIZE INTO W77-MENSAGEM */
                #region STRING
                var spl8 = "ERRO NO ACESSO DA SEQUENCE FDRCAP.FC302SQ PARA " + "COD SEQ =" + LK_IN_COD_SEQ.GetMoveValues();
                _.Move(spl8, W77_MENSAGEM);
                #endregion

                /*" -227- PERFORM P999-DB2-ERROR */

                P999_DB2_ERROR(true);

                /*" -228- GO TO P999-ENCERRA-PROGRAMA */

                P999_ENCERRA_PROGRAMA(); //GOTO
                return;

                /*" -229- END-IF */
            }


            /*" -230- MOVE LK-OUT-NUM-SEQ-INI TO LK-OUT-NUM-SEQ-FIM */
            _.Move(LK_OUT_NUM_SEQ_INI, LK_OUT_NUM_SEQ_FIM);

            /*" -230- . */

        }

        [StopWatch]
        /*" P100-ACESSA-SEQUENCE-FC302SQ-DB-SEQUENCE-1 */
        public void P100_ACESSA_SEQUENCE_FC302SQ_DB_SEQUENCE_1()
        {
            /*" -220- EXEC SQL SET :LK-OUT-NUM-SEQ-INI = NEXT VALUE FOR FDRCAP.FC302SQ END-EXEC */

            var p100_ACESSA_SEQUENCE_FC302SQ_DB_SEQUENCE_1_Query1 = new P100_ACESSA_SEQUENCE_FC302SQ_DB_SEQUENCE_1_Query1()
            {
            };

            var executed_1 = P100_ACESSA_SEQUENCE_FC302SQ_DB_SEQUENCE_1_Query1.Execute(p100_ACESSA_SEQUENCE_FC302SQ_DB_SEQUENCE_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LK_OUT_NUM_SEQ_INI, LK_OUT_NUM_SEQ_INI);
            }


        }

        [StopWatch]
        /*" P100-ACESSA-SEQUENCE-FC103SQ */
        private void P100_ACESSA_SEQUENCE_FC103SQ(bool isPerform = false)
        {
            /*" -236- PERFORM P100_ACESSA_SEQUENCE_FC103SQ_DB_SEQUENCE_1 */

            P100_ACESSA_SEQUENCE_FC103SQ_DB_SEQUENCE_1();

            /*" -238- IF SQLCODE NOT = 000 */

            if (DB.SQLCODE != 000)
            {

                /*" -241- STRING 'ERRO NO ACESSO DA SEQUENCE FDRCAP.FC103SQ PARA ' 'COD SEQ =' LK-IN-COD-SEQ DELIMITED BY SIZE INTO W77-MENSAGEM */
                #region STRING
                var spl9 = "ERRO NO ACESSO DA SEQUENCE FDRCAP.FC103SQ PARA " + "COD SEQ =" + LK_IN_COD_SEQ.GetMoveValues();
                _.Move(spl9, W77_MENSAGEM);
                #endregion

                /*" -242- PERFORM P999-DB2-ERROR */

                P999_DB2_ERROR(true);

                /*" -243- GO TO P999-ENCERRA-PROGRAMA */

                P999_ENCERRA_PROGRAMA(); //GOTO
                return;

                /*" -244- END-IF */
            }


            /*" -245- MOVE LK-OUT-NUM-SEQ-INI TO LK-OUT-NUM-SEQ-FIM */
            _.Move(LK_OUT_NUM_SEQ_INI, LK_OUT_NUM_SEQ_FIM);

            /*" -245- . */

        }

        [StopWatch]
        /*" P100-ACESSA-SEQUENCE-FC103SQ-DB-SEQUENCE-1 */
        public void P100_ACESSA_SEQUENCE_FC103SQ_DB_SEQUENCE_1()
        {
            /*" -236- EXEC SQL SET :LK-OUT-NUM-SEQ-INI = NEXT VALUE FOR FDRCAP.FC103SQ END-EXEC */

            var p100_ACESSA_SEQUENCE_FC103SQ_DB_SEQUENCE_1_Query1 = new P100_ACESSA_SEQUENCE_FC103SQ_DB_SEQUENCE_1_Query1()
            {
            };

            var executed_1 = P100_ACESSA_SEQUENCE_FC103SQ_DB_SEQUENCE_1_Query1.Execute(p100_ACESSA_SEQUENCE_FC103SQ_DB_SEQUENCE_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LK_OUT_NUM_SEQ_INI, LK_OUT_NUM_SEQ_INI);
            }


        }

        [StopWatch]
        /*" P100-ACESSA-SEQUENCE-FC222SQ */
        private void P100_ACESSA_SEQUENCE_FC222SQ(bool isPerform = false)
        {
            /*" -251- PERFORM P100_ACESSA_SEQUENCE_FC222SQ_DB_SEQUENCE_1 */

            P100_ACESSA_SEQUENCE_FC222SQ_DB_SEQUENCE_1();

            /*" -253- IF SQLCODE NOT = 000 */

            if (DB.SQLCODE != 000)
            {

                /*" -256- STRING 'ERRO NO ACESSO DA SEQUENCE FDRCAP.FC222SQ PARA ' 'COD SEQ =' LK-IN-COD-SEQ DELIMITED BY SIZE INTO W77-MENSAGEM */
                #region STRING
                var spl10 = "ERRO NO ACESSO DA SEQUENCE FDRCAP.FC222SQ PARA " + "COD SEQ =" + LK_IN_COD_SEQ.GetMoveValues();
                _.Move(spl10, W77_MENSAGEM);
                #endregion

                /*" -257- PERFORM P999-DB2-ERROR */

                P999_DB2_ERROR(true);

                /*" -258- GO TO P999-ENCERRA-PROGRAMA */

                P999_ENCERRA_PROGRAMA(); //GOTO
                return;

                /*" -259- END-IF */
            }


            /*" -260- MOVE LK-OUT-NUM-SEQ-INI TO LK-OUT-NUM-SEQ-FIM */
            _.Move(LK_OUT_NUM_SEQ_INI, LK_OUT_NUM_SEQ_FIM);

            /*" -260- . */

        }

        [StopWatch]
        /*" P100-ACESSA-SEQUENCE-FC222SQ-DB-SEQUENCE-1 */
        public void P100_ACESSA_SEQUENCE_FC222SQ_DB_SEQUENCE_1()
        {
            /*" -251- EXEC SQL SET :LK-OUT-NUM-SEQ-INI = NEXT VALUE FOR FDRCAP.FC222SQ END-EXEC */

            var p100_ACESSA_SEQUENCE_FC222SQ_DB_SEQUENCE_1_Query1 = new P100_ACESSA_SEQUENCE_FC222SQ_DB_SEQUENCE_1_Query1()
            {
            };

            var executed_1 = P100_ACESSA_SEQUENCE_FC222SQ_DB_SEQUENCE_1_Query1.Execute(p100_ACESSA_SEQUENCE_FC222SQ_DB_SEQUENCE_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LK_OUT_NUM_SEQ_INI, LK_OUT_NUM_SEQ_INI);
            }


        }

        [StopWatch]
        /*" P100-ACESSA-SEQUENCE-FC035SQ */
        private void P100_ACESSA_SEQUENCE_FC035SQ(bool isPerform = false)
        {
            /*" -266- PERFORM P100_ACESSA_SEQUENCE_FC035SQ_DB_SEQUENCE_1 */

            P100_ACESSA_SEQUENCE_FC035SQ_DB_SEQUENCE_1();

            /*" -268- IF SQLCODE NOT = 000 */

            if (DB.SQLCODE != 000)
            {

                /*" -271- STRING 'ERRO NO ACESSO DA SEQUENCE FDRCAP.FC035SQ PARA ' 'COD SEQ =' LK-IN-COD-SEQ DELIMITED BY SIZE INTO W77-MENSAGEM */
                #region STRING
                var spl11 = "ERRO NO ACESSO DA SEQUENCE FDRCAP.FC035SQ PARA " + "COD SEQ =" + LK_IN_COD_SEQ.GetMoveValues();
                _.Move(spl11, W77_MENSAGEM);
                #endregion

                /*" -272- PERFORM P999-DB2-ERROR */

                P999_DB2_ERROR(true);

                /*" -273- GO TO P999-ENCERRA-PROGRAMA */

                P999_ENCERRA_PROGRAMA(); //GOTO
                return;

                /*" -274- END-IF */
            }


            /*" -275- MOVE LK-OUT-NUM-SEQ-INI TO LK-OUT-NUM-SEQ-FIM */
            _.Move(LK_OUT_NUM_SEQ_INI, LK_OUT_NUM_SEQ_FIM);

            /*" -275- . */

        }

        [StopWatch]
        /*" P100-ACESSA-SEQUENCE-FC035SQ-DB-SEQUENCE-1 */
        public void P100_ACESSA_SEQUENCE_FC035SQ_DB_SEQUENCE_1()
        {
            /*" -266- EXEC SQL SET :LK-OUT-NUM-SEQ-INI = NEXT VALUE FOR FDRCAP.FC035SQ END-EXEC */

            var p100_ACESSA_SEQUENCE_FC035SQ_DB_SEQUENCE_1_Query1 = new P100_ACESSA_SEQUENCE_FC035SQ_DB_SEQUENCE_1_Query1()
            {
            };

            var executed_1 = P100_ACESSA_SEQUENCE_FC035SQ_DB_SEQUENCE_1_Query1.Execute(p100_ACESSA_SEQUENCE_FC035SQ_DB_SEQUENCE_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LK_OUT_NUM_SEQ_INI, LK_OUT_NUM_SEQ_INI);
            }


        }

        [StopWatch]
        /*" P100-ACESSA-SEQUENCE-FC085SQ */
        private void P100_ACESSA_SEQUENCE_FC085SQ(bool isPerform = false)
        {
            /*" -281- PERFORM P100_ACESSA_SEQUENCE_FC085SQ_DB_SEQUENCE_1 */

            P100_ACESSA_SEQUENCE_FC085SQ_DB_SEQUENCE_1();

            /*" -283- IF SQLCODE NOT = 000 */

            if (DB.SQLCODE != 000)
            {

                /*" -286- STRING 'ERRO NO ACESSO DA SEQUENCE FDRCAP.FC085SQ PARA ' 'COD SEQ =' LK-IN-COD-SEQ DELIMITED BY SIZE INTO W77-MENSAGEM */
                #region STRING
                var spl12 = "ERRO NO ACESSO DA SEQUENCE FDRCAP.FC085SQ PARA " + "COD SEQ =" + LK_IN_COD_SEQ.GetMoveValues();
                _.Move(spl12, W77_MENSAGEM);
                #endregion

                /*" -287- PERFORM P999-DB2-ERROR */

                P999_DB2_ERROR(true);

                /*" -288- GO TO P999-ENCERRA-PROGRAMA */

                P999_ENCERRA_PROGRAMA(); //GOTO
                return;

                /*" -289- END-IF */
            }


            /*" -290- MOVE LK-OUT-NUM-SEQ-INI TO LK-OUT-NUM-SEQ-FIM */
            _.Move(LK_OUT_NUM_SEQ_INI, LK_OUT_NUM_SEQ_FIM);

            /*" -290- . */

        }

        [StopWatch]
        /*" P100-ACESSA-SEQUENCE-FC085SQ-DB-SEQUENCE-1 */
        public void P100_ACESSA_SEQUENCE_FC085SQ_DB_SEQUENCE_1()
        {
            /*" -281- EXEC SQL SET :LK-OUT-NUM-SEQ-INI = NEXT VALUE FOR FDRCAP.FC085SQ END-EXEC */

            var p100_ACESSA_SEQUENCE_FC085SQ_DB_SEQUENCE_1_Query1 = new P100_ACESSA_SEQUENCE_FC085SQ_DB_SEQUENCE_1_Query1()
            {
            };

            var executed_1 = P100_ACESSA_SEQUENCE_FC085SQ_DB_SEQUENCE_1_Query1.Execute(p100_ACESSA_SEQUENCE_FC085SQ_DB_SEQUENCE_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LK_OUT_NUM_SEQ_INI, LK_OUT_NUM_SEQ_INI);
            }


        }

        [StopWatch]
        /*" P100-ACESSA-SEQUENCE-FC036SQ */
        private void P100_ACESSA_SEQUENCE_FC036SQ(bool isPerform = false)
        {
            /*" -296- PERFORM P100_ACESSA_SEQUENCE_FC036SQ_DB_SEQUENCE_1 */

            P100_ACESSA_SEQUENCE_FC036SQ_DB_SEQUENCE_1();

            /*" -298- IF SQLCODE NOT = 000 */

            if (DB.SQLCODE != 000)
            {

                /*" -301- STRING 'ERRO NO ACESSO DA SEQUENCE FDRCAP.FC036SQ PARA ' 'COD SEQ =' LK-IN-COD-SEQ DELIMITED BY SIZE INTO W77-MENSAGEM */
                #region STRING
                var spl13 = "ERRO NO ACESSO DA SEQUENCE FDRCAP.FC036SQ PARA " + "COD SEQ =" + LK_IN_COD_SEQ.GetMoveValues();
                _.Move(spl13, W77_MENSAGEM);
                #endregion

                /*" -302- PERFORM P999-DB2-ERROR */

                P999_DB2_ERROR(true);

                /*" -303- GO TO P999-ENCERRA-PROGRAMA */

                P999_ENCERRA_PROGRAMA(); //GOTO
                return;

                /*" -304- END-IF */
            }


            /*" -305- MOVE LK-OUT-NUM-SEQ-INI TO LK-OUT-NUM-SEQ-FIM */
            _.Move(LK_OUT_NUM_SEQ_INI, LK_OUT_NUM_SEQ_FIM);

            /*" -305- . */

        }

        [StopWatch]
        /*" P100-ACESSA-SEQUENCE-FC036SQ-DB-SEQUENCE-1 */
        public void P100_ACESSA_SEQUENCE_FC036SQ_DB_SEQUENCE_1()
        {
            /*" -296- EXEC SQL SET :LK-OUT-NUM-SEQ-INI = NEXT VALUE FOR FDRCAP.FC036SQ END-EXEC */

            var p100_ACESSA_SEQUENCE_FC036SQ_DB_SEQUENCE_1_Query1 = new P100_ACESSA_SEQUENCE_FC036SQ_DB_SEQUENCE_1_Query1()
            {
            };

            var executed_1 = P100_ACESSA_SEQUENCE_FC036SQ_DB_SEQUENCE_1_Query1.Execute(p100_ACESSA_SEQUENCE_FC036SQ_DB_SEQUENCE_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LK_OUT_NUM_SEQ_INI, LK_OUT_NUM_SEQ_INI);
            }


        }

        [StopWatch]
        /*" P100-ACESSA-SEQUENCE-FC105SQ */
        private void P100_ACESSA_SEQUENCE_FC105SQ(bool isPerform = false)
        {
            /*" -311- PERFORM P100_ACESSA_SEQUENCE_FC105SQ_DB_SEQUENCE_1 */

            P100_ACESSA_SEQUENCE_FC105SQ_DB_SEQUENCE_1();

            /*" -313- IF SQLCODE NOT = 000 */

            if (DB.SQLCODE != 000)
            {

                /*" -316- STRING 'ERRO NO ACESSO DA SEQUENCE FDRCAP.FC105SQ PARA ' 'COD SEQ =' LK-IN-COD-SEQ DELIMITED BY SIZE INTO W77-MENSAGEM */
                #region STRING
                var spl14 = "ERRO NO ACESSO DA SEQUENCE FDRCAP.FC105SQ PARA " + "COD SEQ =" + LK_IN_COD_SEQ.GetMoveValues();
                _.Move(spl14, W77_MENSAGEM);
                #endregion

                /*" -317- PERFORM P999-DB2-ERROR */

                P999_DB2_ERROR(true);

                /*" -318- GO TO P999-ENCERRA-PROGRAMA */

                P999_ENCERRA_PROGRAMA(); //GOTO
                return;

                /*" -319- END-IF */
            }


            /*" -320- MOVE LK-OUT-NUM-SEQ-INI TO LK-OUT-NUM-SEQ-FIM */
            _.Move(LK_OUT_NUM_SEQ_INI, LK_OUT_NUM_SEQ_FIM);

            /*" -320- . */

        }

        [StopWatch]
        /*" P100-ACESSA-SEQUENCE-FC105SQ-DB-SEQUENCE-1 */
        public void P100_ACESSA_SEQUENCE_FC105SQ_DB_SEQUENCE_1()
        {
            /*" -311- EXEC SQL SET :LK-OUT-NUM-SEQ-INI = NEXT VALUE FOR FDRCAP.FC105SQ END-EXEC */

            var p100_ACESSA_SEQUENCE_FC105SQ_DB_SEQUENCE_1_Query1 = new P100_ACESSA_SEQUENCE_FC105SQ_DB_SEQUENCE_1_Query1()
            {
            };

            var executed_1 = P100_ACESSA_SEQUENCE_FC105SQ_DB_SEQUENCE_1_Query1.Execute(p100_ACESSA_SEQUENCE_FC105SQ_DB_SEQUENCE_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LK_OUT_NUM_SEQ_INI, LK_OUT_NUM_SEQ_INI);
            }


        }

        [StopWatch]
        /*" P100-ACESSA-SEQUENCE-FC106SQ */
        private void P100_ACESSA_SEQUENCE_FC106SQ(bool isPerform = false)
        {
            /*" -326- PERFORM P100_ACESSA_SEQUENCE_FC106SQ_DB_SEQUENCE_1 */

            P100_ACESSA_SEQUENCE_FC106SQ_DB_SEQUENCE_1();

            /*" -328- IF SQLCODE NOT = 000 */

            if (DB.SQLCODE != 000)
            {

                /*" -331- STRING 'ERRO NO ACESSO DA SEQUENCE FDRCAP.FC106SQ PARA ' 'COD SEQ =' LK-IN-COD-SEQ DELIMITED BY SIZE INTO W77-MENSAGEM */
                #region STRING
                var spl15 = "ERRO NO ACESSO DA SEQUENCE FDRCAP.FC106SQ PARA " + "COD SEQ =" + LK_IN_COD_SEQ.GetMoveValues();
                _.Move(spl15, W77_MENSAGEM);
                #endregion

                /*" -332- PERFORM P999-DB2-ERROR */

                P999_DB2_ERROR(true);

                /*" -333- GO TO P999-ENCERRA-PROGRAMA */

                P999_ENCERRA_PROGRAMA(); //GOTO
                return;

                /*" -334- END-IF */
            }


            /*" -335- MOVE LK-OUT-NUM-SEQ-INI TO LK-OUT-NUM-SEQ-FIM */
            _.Move(LK_OUT_NUM_SEQ_INI, LK_OUT_NUM_SEQ_FIM);

            /*" -335- . */

        }

        [StopWatch]
        /*" P100-ACESSA-SEQUENCE-FC106SQ-DB-SEQUENCE-1 */
        public void P100_ACESSA_SEQUENCE_FC106SQ_DB_SEQUENCE_1()
        {
            /*" -326- EXEC SQL SET :LK-OUT-NUM-SEQ-INI = NEXT VALUE FOR FDRCAP.FC106SQ END-EXEC */

            var p100_ACESSA_SEQUENCE_FC106SQ_DB_SEQUENCE_1_Query1 = new P100_ACESSA_SEQUENCE_FC106SQ_DB_SEQUENCE_1_Query1()
            {
            };

            var executed_1 = P100_ACESSA_SEQUENCE_FC106SQ_DB_SEQUENCE_1_Query1.Execute(p100_ACESSA_SEQUENCE_FC106SQ_DB_SEQUENCE_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LK_OUT_NUM_SEQ_INI, LK_OUT_NUM_SEQ_INI);
            }


        }

        [StopWatch]
        /*" P100-ACESSA-SEQUENCE-FC092SQ */
        private void P100_ACESSA_SEQUENCE_FC092SQ(bool isPerform = false)
        {
            /*" -341- PERFORM P100_ACESSA_SEQUENCE_FC092SQ_DB_SEQUENCE_1 */

            P100_ACESSA_SEQUENCE_FC092SQ_DB_SEQUENCE_1();

            /*" -343- IF SQLCODE NOT = 000 */

            if (DB.SQLCODE != 000)
            {

                /*" -346- STRING 'ERRO NO ACESSO DA SEQUENCE FDRCAP.FC092SQ PARA ' 'COD SEQ =' LK-IN-COD-SEQ DELIMITED BY SIZE INTO W77-MENSAGEM */
                #region STRING
                var spl16 = "ERRO NO ACESSO DA SEQUENCE FDRCAP.FC092SQ PARA " + "COD SEQ =" + LK_IN_COD_SEQ.GetMoveValues();
                _.Move(spl16, W77_MENSAGEM);
                #endregion

                /*" -347- PERFORM P999-DB2-ERROR */

                P999_DB2_ERROR(true);

                /*" -348- GO TO P999-ENCERRA-PROGRAMA */

                P999_ENCERRA_PROGRAMA(); //GOTO
                return;

                /*" -349- END-IF */
            }


            /*" -350- MOVE LK-OUT-NUM-SEQ-INI TO LK-OUT-NUM-SEQ-FIM */
            _.Move(LK_OUT_NUM_SEQ_INI, LK_OUT_NUM_SEQ_FIM);

            /*" -350- . */

        }

        [StopWatch]
        /*" P100-ACESSA-SEQUENCE-FC092SQ-DB-SEQUENCE-1 */
        public void P100_ACESSA_SEQUENCE_FC092SQ_DB_SEQUENCE_1()
        {
            /*" -341- EXEC SQL SET :LK-OUT-NUM-SEQ-INI = NEXT VALUE FOR FDRCAP.FC092SQ END-EXEC */

            var p100_ACESSA_SEQUENCE_FC092SQ_DB_SEQUENCE_1_Query1 = new P100_ACESSA_SEQUENCE_FC092SQ_DB_SEQUENCE_1_Query1()
            {
            };

            var executed_1 = P100_ACESSA_SEQUENCE_FC092SQ_DB_SEQUENCE_1_Query1.Execute(p100_ACESSA_SEQUENCE_FC092SQ_DB_SEQUENCE_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LK_OUT_NUM_SEQ_INI, LK_OUT_NUM_SEQ_INI);
            }


        }

        [StopWatch]
        /*" P100-ACESSA-SEQUENCE-FC084SQ */
        private void P100_ACESSA_SEQUENCE_FC084SQ(bool isPerform = false)
        {
            /*" -356- PERFORM P100_ACESSA_SEQUENCE_FC084SQ_DB_SEQUENCE_1 */

            P100_ACESSA_SEQUENCE_FC084SQ_DB_SEQUENCE_1();

            /*" -358- IF SQLCODE NOT = 000 */

            if (DB.SQLCODE != 000)
            {

                /*" -361- STRING 'ERRO NO ACESSO DA SEQUENCE FDRCAP.FC084SQ PARA ' 'COD SEQ =' LK-IN-COD-SEQ DELIMITED BY SIZE INTO W77-MENSAGEM */
                #region STRING
                var spl17 = "ERRO NO ACESSO DA SEQUENCE FDRCAP.FC084SQ PARA " + "COD SEQ =" + LK_IN_COD_SEQ.GetMoveValues();
                _.Move(spl17, W77_MENSAGEM);
                #endregion

                /*" -362- PERFORM P999-DB2-ERROR */

                P999_DB2_ERROR(true);

                /*" -363- GO TO P999-ENCERRA-PROGRAMA */

                P999_ENCERRA_PROGRAMA(); //GOTO
                return;

                /*" -364- END-IF */
            }


            /*" -365- MOVE LK-OUT-NUM-SEQ-INI TO LK-OUT-NUM-SEQ-FIM */
            _.Move(LK_OUT_NUM_SEQ_INI, LK_OUT_NUM_SEQ_FIM);

            /*" -365- . */

        }

        [StopWatch]
        /*" P100-ACESSA-SEQUENCE-FC084SQ-DB-SEQUENCE-1 */
        public void P100_ACESSA_SEQUENCE_FC084SQ_DB_SEQUENCE_1()
        {
            /*" -356- EXEC SQL SET :LK-OUT-NUM-SEQ-INI = NEXT VALUE FOR FDRCAP.FC084SQ END-EXEC */

            var p100_ACESSA_SEQUENCE_FC084SQ_DB_SEQUENCE_1_Query1 = new P100_ACESSA_SEQUENCE_FC084SQ_DB_SEQUENCE_1_Query1()
            {
            };

            var executed_1 = P100_ACESSA_SEQUENCE_FC084SQ_DB_SEQUENCE_1_Query1.Execute(p100_ACESSA_SEQUENCE_FC084SQ_DB_SEQUENCE_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LK_OUT_NUM_SEQ_INI, LK_OUT_NUM_SEQ_INI);
            }


        }

        [StopWatch]
        /*" P100-ACESSA-SEQUENCE-FC216SQ */
        private void P100_ACESSA_SEQUENCE_FC216SQ(bool isPerform = false)
        {
            /*" -371- PERFORM P100_ACESSA_SEQUENCE_FC216SQ_DB_SEQUENCE_1 */

            P100_ACESSA_SEQUENCE_FC216SQ_DB_SEQUENCE_1();

            /*" -373- IF SQLCODE NOT = 000 */

            if (DB.SQLCODE != 000)
            {

                /*" -376- STRING 'ERRO NO ACESSO DA SEQUENCE FDRCAP.FC216SQ PARA ' 'COD SEQ =' LK-IN-COD-SEQ DELIMITED BY SIZE INTO W77-MENSAGEM */
                #region STRING
                var spl18 = "ERRO NO ACESSO DA SEQUENCE FDRCAP.FC216SQ PARA " + "COD SEQ =" + LK_IN_COD_SEQ.GetMoveValues();
                _.Move(spl18, W77_MENSAGEM);
                #endregion

                /*" -377- PERFORM P999-DB2-ERROR */

                P999_DB2_ERROR(true);

                /*" -378- GO TO P999-ENCERRA-PROGRAMA */

                P999_ENCERRA_PROGRAMA(); //GOTO
                return;

                /*" -379- END-IF */
            }


            /*" -380- MOVE LK-OUT-NUM-SEQ-INI TO LK-OUT-NUM-SEQ-FIM */
            _.Move(LK_OUT_NUM_SEQ_INI, LK_OUT_NUM_SEQ_FIM);

            /*" -380- . */

        }

        [StopWatch]
        /*" P100-ACESSA-SEQUENCE-FC216SQ-DB-SEQUENCE-1 */
        public void P100_ACESSA_SEQUENCE_FC216SQ_DB_SEQUENCE_1()
        {
            /*" -371- EXEC SQL SET :LK-OUT-NUM-SEQ-INI = NEXT VALUE FOR FDRCAP.FC216SQ END-EXEC */

            var p100_ACESSA_SEQUENCE_FC216SQ_DB_SEQUENCE_1_Query1 = new P100_ACESSA_SEQUENCE_FC216SQ_DB_SEQUENCE_1_Query1()
            {
            };

            var executed_1 = P100_ACESSA_SEQUENCE_FC216SQ_DB_SEQUENCE_1_Query1.Execute(p100_ACESSA_SEQUENCE_FC216SQ_DB_SEQUENCE_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LK_OUT_NUM_SEQ_INI, LK_OUT_NUM_SEQ_INI);
            }


        }

        [StopWatch]
        /*" P100-ACESSA-SEQUENCE-FC002SQ */
        private void P100_ACESSA_SEQUENCE_FC002SQ(bool isPerform = false)
        {
            /*" -386- PERFORM P100_ACESSA_SEQUENCE_FC002SQ_DB_SEQUENCE_1 */

            P100_ACESSA_SEQUENCE_FC002SQ_DB_SEQUENCE_1();

            /*" -388- IF SQLCODE NOT = 000 */

            if (DB.SQLCODE != 000)
            {

                /*" -391- STRING 'ERRO NO ACESSO DA SEQUENCE FDRCAP.FC002SQ PARA ' 'COD SEQ =' LK-IN-COD-SEQ DELIMITED BY SIZE INTO W77-MENSAGEM */
                #region STRING
                var spl19 = "ERRO NO ACESSO DA SEQUENCE FDRCAP.FC002SQ PARA " + "COD SEQ =" + LK_IN_COD_SEQ.GetMoveValues();
                _.Move(spl19, W77_MENSAGEM);
                #endregion

                /*" -392- PERFORM P999-DB2-ERROR */

                P999_DB2_ERROR(true);

                /*" -393- GO TO P999-ENCERRA-PROGRAMA */

                P999_ENCERRA_PROGRAMA(); //GOTO
                return;

                /*" -394- END-IF */
            }


            /*" -395- MOVE LK-OUT-NUM-SEQ-INI TO LK-OUT-NUM-SEQ-FIM */
            _.Move(LK_OUT_NUM_SEQ_INI, LK_OUT_NUM_SEQ_FIM);

            /*" -395- . */

        }

        [StopWatch]
        /*" P100-ACESSA-SEQUENCE-FC002SQ-DB-SEQUENCE-1 */
        public void P100_ACESSA_SEQUENCE_FC002SQ_DB_SEQUENCE_1()
        {
            /*" -386- EXEC SQL SET :LK-OUT-NUM-SEQ-INI = NEXT VALUE FOR FDRCAP.FC002SQ END-EXEC */

            var p100_ACESSA_SEQUENCE_FC002SQ_DB_SEQUENCE_1_Query1 = new P100_ACESSA_SEQUENCE_FC002SQ_DB_SEQUENCE_1_Query1()
            {
            };

            var executed_1 = P100_ACESSA_SEQUENCE_FC002SQ_DB_SEQUENCE_1_Query1.Execute(p100_ACESSA_SEQUENCE_FC002SQ_DB_SEQUENCE_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LK_OUT_NUM_SEQ_INI, LK_OUT_NUM_SEQ_INI);
            }


        }

        [StopWatch]
        /*" P100-ACESSA-SEQUENCE-FC074SQ */
        private void P100_ACESSA_SEQUENCE_FC074SQ(bool isPerform = false)
        {
            /*" -401- PERFORM P100_ACESSA_SEQUENCE_FC074SQ_DB_SEQUENCE_1 */

            P100_ACESSA_SEQUENCE_FC074SQ_DB_SEQUENCE_1();

            /*" -403- IF SQLCODE NOT = 000 */

            if (DB.SQLCODE != 000)
            {

                /*" -406- STRING 'ERRO NO ACESSO DA SEQUENCE FDRCAP.FC074SQ PARA ' 'COD SEQ =' LK-IN-COD-SEQ DELIMITED BY SIZE INTO W77-MENSAGEM */
                #region STRING
                var spl20 = "ERRO NO ACESSO DA SEQUENCE FDRCAP.FC074SQ PARA " + "COD SEQ =" + LK_IN_COD_SEQ.GetMoveValues();
                _.Move(spl20, W77_MENSAGEM);
                #endregion

                /*" -407- PERFORM P999-DB2-ERROR */

                P999_DB2_ERROR(true);

                /*" -408- GO TO P999-ENCERRA-PROGRAMA */

                P999_ENCERRA_PROGRAMA(); //GOTO
                return;

                /*" -409- END-IF */
            }


            /*" -410- MOVE LK-OUT-NUM-SEQ-INI TO LK-OUT-NUM-SEQ-FIM */
            _.Move(LK_OUT_NUM_SEQ_INI, LK_OUT_NUM_SEQ_FIM);

            /*" -410- . */

        }

        [StopWatch]
        /*" P100-ACESSA-SEQUENCE-FC074SQ-DB-SEQUENCE-1 */
        public void P100_ACESSA_SEQUENCE_FC074SQ_DB_SEQUENCE_1()
        {
            /*" -401- EXEC SQL SET :LK-OUT-NUM-SEQ-INI = NEXT VALUE FOR FDRCAP.FC074SQ END-EXEC */

            var p100_ACESSA_SEQUENCE_FC074SQ_DB_SEQUENCE_1_Query1 = new P100_ACESSA_SEQUENCE_FC074SQ_DB_SEQUENCE_1_Query1()
            {
            };

            var executed_1 = P100_ACESSA_SEQUENCE_FC074SQ_DB_SEQUENCE_1_Query1.Execute(p100_ACESSA_SEQUENCE_FC074SQ_DB_SEQUENCE_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LK_OUT_NUM_SEQ_INI, LK_OUT_NUM_SEQ_INI);
            }


        }

        [StopWatch]
        /*" P100-ACESSA-SEQUENCE-FC072SQ */
        private void P100_ACESSA_SEQUENCE_FC072SQ(bool isPerform = false)
        {
            /*" -416- PERFORM P100_ACESSA_SEQUENCE_FC072SQ_DB_SEQUENCE_1 */

            P100_ACESSA_SEQUENCE_FC072SQ_DB_SEQUENCE_1();

            /*" -418- IF SQLCODE NOT = 000 */

            if (DB.SQLCODE != 000)
            {

                /*" -421- STRING 'ERRO NO ACESSO DA SEQUENCE FDRCAP.FC072SQ PARA ' 'COD SEQ =' LK-IN-COD-SEQ DELIMITED BY SIZE INTO W77-MENSAGEM */
                #region STRING
                var spl21 = "ERRO NO ACESSO DA SEQUENCE FDRCAP.FC072SQ PARA " + "COD SEQ =" + LK_IN_COD_SEQ.GetMoveValues();
                _.Move(spl21, W77_MENSAGEM);
                #endregion

                /*" -422- PERFORM P999-DB2-ERROR */

                P999_DB2_ERROR(true);

                /*" -423- GO TO P999-ENCERRA-PROGRAMA */

                P999_ENCERRA_PROGRAMA(); //GOTO
                return;

                /*" -424- END-IF */
            }


            /*" -425- MOVE LK-OUT-NUM-SEQ-INI TO LK-OUT-NUM-SEQ-FIM */
            _.Move(LK_OUT_NUM_SEQ_INI, LK_OUT_NUM_SEQ_FIM);

            /*" -425- . */

        }

        [StopWatch]
        /*" P100-ACESSA-SEQUENCE-FC072SQ-DB-SEQUENCE-1 */
        public void P100_ACESSA_SEQUENCE_FC072SQ_DB_SEQUENCE_1()
        {
            /*" -416- EXEC SQL SET :LK-OUT-NUM-SEQ-INI = NEXT VALUE FOR FDRCAP.FC072SQ END-EXEC */

            var p100_ACESSA_SEQUENCE_FC072SQ_DB_SEQUENCE_1_Query1 = new P100_ACESSA_SEQUENCE_FC072SQ_DB_SEQUENCE_1_Query1()
            {
            };

            var executed_1 = P100_ACESSA_SEQUENCE_FC072SQ_DB_SEQUENCE_1_Query1.Execute(p100_ACESSA_SEQUENCE_FC072SQ_DB_SEQUENCE_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LK_OUT_NUM_SEQ_INI, LK_OUT_NUM_SEQ_INI);
            }


        }

        [StopWatch]
        /*" P100-ACESSA-SEQUENCE-FC037SQ */
        private void P100_ACESSA_SEQUENCE_FC037SQ(bool isPerform = false)
        {
            /*" -431- PERFORM P100_ACESSA_SEQUENCE_FC037SQ_DB_SEQUENCE_1 */

            P100_ACESSA_SEQUENCE_FC037SQ_DB_SEQUENCE_1();

            /*" -433- IF SQLCODE NOT = 000 */

            if (DB.SQLCODE != 000)
            {

                /*" -436- STRING 'ERRO NO ACESSO DA SEQUENCE FDRCAP.FC037SQ PARA ' 'COD SEQ =' LK-IN-COD-SEQ DELIMITED BY SIZE INTO W77-MENSAGEM */
                #region STRING
                var spl22 = "ERRO NO ACESSO DA SEQUENCE FDRCAP.FC037SQ PARA " + "COD SEQ =" + LK_IN_COD_SEQ.GetMoveValues();
                _.Move(spl22, W77_MENSAGEM);
                #endregion

                /*" -437- PERFORM P999-DB2-ERROR */

                P999_DB2_ERROR(true);

                /*" -438- GO TO P999-ENCERRA-PROGRAMA */

                P999_ENCERRA_PROGRAMA(); //GOTO
                return;

                /*" -439- END-IF */
            }


            /*" -440- MOVE LK-OUT-NUM-SEQ-INI TO LK-OUT-NUM-SEQ-FIM */
            _.Move(LK_OUT_NUM_SEQ_INI, LK_OUT_NUM_SEQ_FIM);

            /*" -440- . */

        }

        [StopWatch]
        /*" P100-ACESSA-SEQUENCE-FC037SQ-DB-SEQUENCE-1 */
        public void P100_ACESSA_SEQUENCE_FC037SQ_DB_SEQUENCE_1()
        {
            /*" -431- EXEC SQL SET :LK-OUT-NUM-SEQ-INI = NEXT VALUE FOR FDRCAP.FC037SQ END-EXEC */

            var p100_ACESSA_SEQUENCE_FC037SQ_DB_SEQUENCE_1_Query1 = new P100_ACESSA_SEQUENCE_FC037SQ_DB_SEQUENCE_1_Query1()
            {
            };

            var executed_1 = P100_ACESSA_SEQUENCE_FC037SQ_DB_SEQUENCE_1_Query1.Execute(p100_ACESSA_SEQUENCE_FC037SQ_DB_SEQUENCE_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LK_OUT_NUM_SEQ_INI, LK_OUT_NUM_SEQ_INI);
            }


        }

        [StopWatch]
        /*" P999-DB2-ERROR */
        private void P999_DB2_ERROR(bool isPerform = false)
        {
            /*" -446- MOVE 1 TO LK-OUT-COD-RETORNO */
            _.Move(1, LK_OUT_COD_RETORNO);

            /*" -447- MOVE SQLCODE TO LK-OUT-SQLCODE */
            _.Move(DB.SQLCODE, LK_OUT_SQLCODE);

            /*" -448- MOVE SQLERRMC TO LK-OUT-SQLERRMC */
            _.Move(DB.SQLERRMC, LK_OUT_SQLERRMC);

            /*" -449- MOVE SQLSTATE TO LK-OUT-SQLSTATE */
            _.Move(DB.SQLSTATE, LK_OUT_SQLSTATE);

            /*" -449- . */

        }

        [StopWatch]
        /*" P999-ENCERRA-PROGRAMA */
        private void P999_ENCERRA_PROGRAMA(bool isPerform = false)
        {
            /*" -454- IF W77-MENSAGEM NOT = SPACES */

            if (!W77_MENSAGEM.IsEmpty())
            {

                /*" -456- STRING 'SPBFC003: ' W77-MENSAGEM DELIMITED BY SIZE INTO LK-OUT-MENSAGEM */
                #region STRING
                var spl23 = "SPBFC003: " + W77_MENSAGEM.GetMoveValues();
                _.Move(spl23, LK_OUT_MENSAGEM);
                #endregion

                /*" -458- END-IF */
            }


            /*" -459- GOBACK */

            throw new GoBack();

            /*" -459- . */

        }
    }
}