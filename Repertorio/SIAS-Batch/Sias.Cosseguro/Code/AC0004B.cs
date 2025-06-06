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
using Sias.Cosseguro.DB2.AC0004B;

namespace Code
{
    public class AC0004B
    {
        public bool IsCall { get; set; }

        public AC0004B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  ADMINISTRACAO DE COSSEGURO         *      */
        /*"      *   PROGRAMA ...............  AC0004B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  CARLOS ALBERTO                     *      */
        /*"      *   PROGRAMADOR ............  CARLOS ALBERTO                     *      */
        /*"      *   DATA CODIFICACAO .......  JUNHO / 1998                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  CANCELA A LIBERACAO DE PAGAMENTO   *      */
        /*"      *                             DE COSSEGURO CEDIDO PREMIO/SINISTRO*      */
        /*"      *                             ESTORNANDO OS DOCUMENTOS PROCESSA- *      */
        /*"      *                             DOS, TORNANDO-OS PENDENTE DE LIBE- *      */
        /*"      *                             RACAO NOVAMENTE.                   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      *------------------------------------ ----------------- -------- *      */
        /*"      * SISTEMAS                            V0SISTEMA         INPUT    *      */
        /*"      * RELATORIOS                          V0RELATORIOS      INPUT    *      */
        /*"      * CHEQUE COSSEGURO CEDIDO             V0COSCED-CHEQUE   INPUT    *      */
        /*"      * HISTORICO DE COSSEGURO (PREMIOS)    V1COSSEG-HISTPRE  I-O      *      */
        /*"      * HISTORICO DE COSSEGURO (SINISTRO)   V1COSSEG-HISTSIN  I-O      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * PRODEXTER - 14/06/2005 - SUBSTITUICAO DA PARAMETR_OPER_SINI    *      */
        /*"      *                          PELA GE_SIS_FUNCAO_OPER E             *      */
        /*"      *                          GE_SIS_FUN_OPE_REL                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  EM JAN/2013 POR GILSON PINTO DA SILVA - PROCURAR C78128       *      */
        /*"      *  - ALTERACAO PARA TRATAR O SINISTRO COM RESSARCIMENTO PARA     *      */
        /*"      *    TODOS OS CONVENIOS E CIAS CONGENERES.                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - PREPARAR A COLUNA CODIGO DE EMPRESA PARA RECEBER  *      */
        /*"      *              A INFORMACAO DO CODIGO CORRESPONDENTE             *      */
        /*"      * 03/10/2018 - GILSON PINTO DA SILVA    JAZZ - HISTORIA - 173142 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - PREPARAR A ROTINA PARA TRATAR A SOLICITACAO DO    *      */
        /*"      *              CANCELAMENTO DO PAGAMENTO POR EMPRESA             *      */
        /*"      * 21/01/2019 - GILSON PINTO DA SILVA    JAZZ - HISTORIA - 188194 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77        VIND-DAT-QTBC         PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_DAT_QTBC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        VIND-NUM-OCOR         PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_NUM_OCOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        VIND-SIT-FINC         PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_SIT_FINC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        VIND-SIT-LIBR         PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_SIT_LIBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        VIND-SIT-REGT         PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_SIT_REGT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        VIND-TIP-SEGR         PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_TIP_SEGR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V0SIST-DTMOVABE-AC    PIC  X(010)      VALUE SPACES.*/
        public StringBasis V0SIST_DTMOVABE_AC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77        V0SIST-DTMOVABE-FI    PIC  X(010)      VALUE SPACES.*/
        public StringBasis V0SIST_DTMOVABE_FI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77        V0RELA-CONGENER       PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0RELA_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V0RELA-PERI-INICIAL   PIC  X(010)      VALUE SPACES.*/
        public StringBasis V0RELA_PERI_INICIAL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77        V0RELA-PERI-FINAL     PIC  X(010)      VALUE SPACES.*/
        public StringBasis V0RELA_PERI_FINAL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77        V0RELA-COD-EMPR       PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0RELA_COD_EMPR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77        V0CCHQ-COD-EMPR       PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0CCHQ_COD_EMPR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77        V0CCHQ-CONGENER       PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0CCHQ_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V0CCHQ-DTMOVTO-AC     PIC  X(010)      VALUE SPACES.*/
        public StringBasis V0CCHQ_DTMOVTO_AC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77        V1CHSP-COD-EMPR       PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V1CHSP_COD_EMPR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77        V1CHSP-CONGENER       PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V1CHSP_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V1CHSP-NUM-APOL       PIC S9(013)      VALUE +0 COMP-3*/
        public IntBasis V1CHSP_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77        V1CHSP-NRENDOS        PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V1CHSP_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77        V1CHSP-NRPARCEL       PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V1CHSP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V1CHSP-OCORHIST       PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V1CHSP_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V1CHSP-OPERACAO       PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V1CHSP_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V1CHSP-DTMOVTO        PIC  X(010)      VALUE SPACES.*/
        public StringBasis V1CHSP_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77        V1CHSP-TIPSGU         PIC  X(001)      VALUE SPACES.*/
        public StringBasis V1CHSP_TIPSGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77        V1CHSP-PRM-TAR        PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis V1CHSP_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        V1CHSP-VAL-DESC       PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis V1CHSP_VAL_DESC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        V1CHSP-VLPRMLIQ       PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis V1CHSP_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        V1CHSP-VLADIFRA       PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis V1CHSP_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        V1CHSP-VLCOMIS        PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis V1CHSP_VLCOMIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        V1CHSP-VLPRMTOT       PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis V1CHSP_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        V1CHSP-DTQITBCO       PIC  X(010)      VALUE SPACES.*/
        public StringBasis V1CHSP_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77        V1CHSP-SIT-FINANC     PIC  X(001)      VALUE SPACES.*/
        public StringBasis V1CHSP_SIT_FINANC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77        V1CHSP-SIT-LIBREC     PIC  X(001)      VALUE SPACES.*/
        public StringBasis V1CHSP_SIT_LIBREC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77        V1CHSP-NUMOCOR        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V1CHSP_NUMOCOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V0CHSP-OCORHIST       PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0CHSP_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V0CHSP-OPERACAO       PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0CHSP_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V0CHSP-DTMOVTO        PIC  X(010)      VALUE SPACES.*/
        public StringBasis V0CHSP_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77        V0CHSP-SIT-FINANC     PIC  X(001)      VALUE SPACES.*/
        public StringBasis V0CHSP_SIT_FINANC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77        V0CHSP-SIT-LIBREC     PIC  X(001)      VALUE SPACES.*/
        public StringBasis V0CHSP_SIT_LIBREC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77        V1CHSI-COD-EMPR       PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V1CHSI_COD_EMPR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77        V1CHSI-CONGENER       PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V1CHSI_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V1CHSI-NUM-SINI       PIC S9(013)      VALUE +0 COMP-3*/
        public IntBasis V1CHSI_NUM_SINI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77        V1CHSI-OCORHIST       PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V1CHSI_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V1CHSI-OPERACAO       PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V1CHSI_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V1CHSI-DTMOVTO        PIC  X(010)      VALUE SPACES.*/
        public StringBasis V1CHSI_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77        V1CHSI-VAL-OPER       PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis V1CHSI_VAL_OPER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        V1CHSI-TIPSGU         PIC  X(001)      VALUE SPACES.*/
        public StringBasis V1CHSI_TIPSGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77        V1CHSI-SITUACAO       PIC  X(001)      VALUE SPACES.*/
        public StringBasis V1CHSI_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77        V1CHSI-SIT-LIBREC     PIC  X(001)      VALUE SPACES.*/
        public StringBasis V1CHSI_SIT_LIBREC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77        V0CHSI-OPERACAO       PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0CHSI_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V0CHSI-DTMOVTO        PIC  X(010)      VALUE SPACES.*/
        public StringBasis V0CHSI_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77        V0CHSI-SITUACAO       PIC  X(001)      VALUE SPACES.*/
        public StringBasis V0CHSI_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77        V0CHSI-SIT-LIBREC     PIC  X(001)      VALUE SPACES.*/
        public StringBasis V0CHSI_SIT_LIBREC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01        AREA-DE-WORK.*/
        public AC0004B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new AC0004B_AREA_DE_WORK();
        public class AC0004B_AREA_DE_WORK : VarBasis
        {
            /*"  05      WFIM-V0RELATORIOS     PIC  X(001)      VALUE SPACES.*/
            public StringBasis WFIM_V0RELATORIOS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05      WFIM-V1COSHISTPRE     PIC  X(001)      VALUE SPACES.*/
            public StringBasis WFIM_V1COSHISTPRE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05      WFIM-V1COSHISTSIN     PIC  X(001)      VALUE SPACES.*/
            public StringBasis WFIM_V1COSHISTSIN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05      AC-L-V0RELATORIOS     PIC  9(009)      VALUE ZEROS.*/
            public IntBasis AC_L_V0RELATORIOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05      AC-L-V1COSHISTPRE     PIC  9(009)      VALUE ZEROS.*/
            public IntBasis AC_L_V1COSHISTPRE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05      AC-L-V1COSHISTSIN     PIC  9(009)      VALUE ZEROS.*/
            public IntBasis AC_L_V1COSHISTSIN { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05      AC-I-V0COSHISTPRE     PIC  9(009)      VALUE ZEROS.*/
            public IntBasis AC_I_V0COSHISTPRE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05      AC-I-V0COSHISTSIN     PIC  9(009)      VALUE ZEROS.*/
            public IntBasis AC_I_V0COSHISTSIN { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05      AC-U-V0COSHISTPRE     PIC  9(009)      VALUE ZEROS.*/
            public IntBasis AC_U_V0COSHISTPRE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05      AC-U-V0COSHISTSIN     PIC  9(009)      VALUE ZEROS.*/
            public IntBasis AC_U_V0COSHISTSIN { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"01        WABEND.*/
        }
        public AC0004B_WABEND WABEND { get; set; } = new AC0004B_WABEND();
        public class AC0004B_WABEND : VarBasis
        {
            /*"  05      FILLER                PIC  X(010)      VALUE         ' AC0004B'.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" AC0004B");
            /*"  05      FILLER                PIC  X(026)      VALUE         ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"  05      WNR-EXEC-SQL          PIC  X(004)      VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"  05      FILLER                PIC  X(013)      VALUE         ' *** SQLCODE '.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"  05      WSQLCODE              PIC  ZZZZZ999-   VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
        }


        public Dclgens.GESISFUO GESISFUO { get; set; } = new Dclgens.GESISFUO();
        public Dclgens.GESISORL GESISORL { get; set; } = new Dclgens.GESISORL();
        public AC0004B_V0RELATORIOS V0RELATORIOS { get; set; } = new AC0004B_V0RELATORIOS();
        public AC0004B_V1COSHISTPRE V1COSHISTPRE { get; set; } = new AC0004B_V1COSHISTPRE();
        public AC0004B_V1COSHISTSIN V1COSHISTSIN { get; set; } = new AC0004B_V1COSHISTSIN();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -214- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", WABEND.WNR_EXEC_SQL);

            /*" -215- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -218- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -221- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -225- PERFORM R0100-00-SELECT-V0SISTEMA-AC. */

            R0100_00_SELECT_V0SISTEMA_AC_SECTION();

            /*" -227- PERFORM R0200-00-SELECT-V0SISTEMA-FI. */

            R0200_00_SELECT_V0SISTEMA_FI_SECTION();

            /*" -229- PERFORM R0500-00-DECLARE-V0RELATORIOS. */

            R0500_00_DECLARE_V0RELATORIOS_SECTION();

            /*" -231- PERFORM R0550-00-FETCH-V0RELATORIOS. */

            R0550_00_FETCH_V0RELATORIOS_SECTION();

            /*" -232- IF WFIM-V0RELATORIOS NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V0RELATORIOS.IsEmpty())
            {

                /*" -233- PERFORM R9900-00-ENCERRA-SEM-MOVTO */

                R9900_00_ENCERRA_SEM_MOVTO_SECTION();

                /*" -234- ELSE */
            }
            else
            {


                /*" -235- PERFORM R0700-00-PROC-V0RELATORIOS UNTIL WFIM-V0RELATORIOS NOT EQUAL SPACES. */

                while (!(!AREA_DE_WORK.WFIM_V0RELATORIOS.IsEmpty()))
                {

                    R0700_00_PROC_V0RELATORIOS_SECTION();
                }
            }


            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -242- DISPLAY 'SOLICITACOES DE CANCELAMENTO PROCESSADAS ' AC-L-V0RELATORIOS. */
            _.Display($"SOLICITACOES DE CANCELAMENTO PROCESSADAS {AREA_DE_WORK.AC_L_V0RELATORIOS}");

            /*" -242- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -246- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -246- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-AC-SECTION */
        private void R0100_00_SELECT_V0SISTEMA_AC_SECTION()
        {
            /*" -259- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", WABEND.WNR_EXEC_SQL);

            /*" -264- PERFORM R0100_00_SELECT_V0SISTEMA_AC_DB_SELECT_1 */

            R0100_00_SELECT_V0SISTEMA_AC_DB_SELECT_1();

            /*" -267- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -268- DISPLAY 'R0100 - ERRO NO SELECT DA V0SISTEMA(AC)' */
                _.Display($"R0100 - ERRO NO SELECT DA V0SISTEMA(AC)");

                /*" -269- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -270- ELSE */
            }
            else
            {


                /*" -270- DISPLAY 'DATA DO SISTEMA AC - ' V0SIST-DTMOVABE-AC. */
                _.Display($"DATA DO SISTEMA AC - {V0SIST_DTMOVABE_AC}");
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-AC-DB-SELECT-1 */
        public void R0100_00_SELECT_V0SISTEMA_AC_DB_SELECT_1()
        {
            /*" -264- EXEC SQL SELECT DTMOVABE INTO :V0SIST-DTMOVABE-AC FROM SEGUROS.V0SISTEMA WHERE IDSISTEM = 'AC' END-EXEC. */

            var r0100_00_SELECT_V0SISTEMA_AC_DB_SELECT_1_Query1 = new R0100_00_SELECT_V0SISTEMA_AC_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V0SISTEMA_AC_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V0SISTEMA_AC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SIST_DTMOVABE_AC, V0SIST_DTMOVABE_AC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-SELECT-V0SISTEMA-FI-SECTION */
        private void R0200_00_SELECT_V0SISTEMA_FI_SECTION()
        {
            /*" -283- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", WABEND.WNR_EXEC_SQL);

            /*" -288- PERFORM R0200_00_SELECT_V0SISTEMA_FI_DB_SELECT_1 */

            R0200_00_SELECT_V0SISTEMA_FI_DB_SELECT_1();

            /*" -291- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -292- DISPLAY 'R0200 - ERRO NO SELECT DA V0SISTEMA(FI)' */
                _.Display($"R0200 - ERRO NO SELECT DA V0SISTEMA(FI)");

                /*" -293- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -294- ELSE */
            }
            else
            {


                /*" -294- DISPLAY 'DATA DO SISTEMA FI - ' V0SIST-DTMOVABE-FI. */
                _.Display($"DATA DO SISTEMA FI - {V0SIST_DTMOVABE_FI}");
            }


        }

        [StopWatch]
        /*" R0200-00-SELECT-V0SISTEMA-FI-DB-SELECT-1 */
        public void R0200_00_SELECT_V0SISTEMA_FI_DB_SELECT_1()
        {
            /*" -288- EXEC SQL SELECT DTMOVABE INTO :V0SIST-DTMOVABE-FI FROM SEGUROS.V0SISTEMA WHERE IDSISTEM = 'FI' END-EXEC. */

            var r0200_00_SELECT_V0SISTEMA_FI_DB_SELECT_1_Query1 = new R0200_00_SELECT_V0SISTEMA_FI_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0200_00_SELECT_V0SISTEMA_FI_DB_SELECT_1_Query1.Execute(r0200_00_SELECT_V0SISTEMA_FI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SIST_DTMOVABE_FI, V0SIST_DTMOVABE_FI);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-DECLARE-V0RELATORIOS-SECTION */
        private void R0500_00_DECLARE_V0RELATORIOS_SECTION()
        {
            /*" -307- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", WABEND.WNR_EXEC_SQL);

            /*" -319- PERFORM R0500_00_DECLARE_V0RELATORIOS_DB_DECLARE_1 */

            R0500_00_DECLARE_V0RELATORIOS_DB_DECLARE_1();

            /*" -321- PERFORM R0500_00_DECLARE_V0RELATORIOS_DB_OPEN_1 */

            R0500_00_DECLARE_V0RELATORIOS_DB_OPEN_1();

            /*" -324- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -325- DISPLAY 'R0500 - ERRO NO DECLARE DA V0RELATORIOS' */
                _.Display($"R0500 - ERRO NO DECLARE DA V0RELATORIOS");

                /*" -326- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -327- ELSE */
            }
            else
            {


                /*" -327- MOVE SPACES TO WFIM-V0RELATORIOS. */
                _.Move("", AREA_DE_WORK.WFIM_V0RELATORIOS);
            }


        }

        [StopWatch]
        /*" R0500-00-DECLARE-V0RELATORIOS-DB-DECLARE-1 */
        public void R0500_00_DECLARE_V0RELATORIOS_DB_DECLARE_1()
        {
            /*" -319- EXEC SQL DECLARE V0RELATORIOS CURSOR FOR SELECT PERI_INICIAL, PERI_FINAL, CONGENER, VALUE(COD_EMPRESA,+0) FROM SEGUROS.V0RELATORIOS WHERE CODRELAT = 'AC0004B1' AND DATA_SOLICITACAO = :V0SIST-DTMOVABE-AC ORDER BY PERI_INICIAL, COD_EMPRESA, CONGENER END-EXEC. */
            V0RELATORIOS = new AC0004B_V0RELATORIOS(true);
            string GetQuery_V0RELATORIOS()
            {
                var query = @$"SELECT PERI_INICIAL
							, 
							PERI_FINAL
							, 
							CONGENER
							, 
							VALUE(COD_EMPRESA
							,+0) 
							FROM SEGUROS.V0RELATORIOS 
							WHERE CODRELAT = 'AC0004B1' 
							AND DATA_SOLICITACAO = '{V0SIST_DTMOVABE_AC}' 
							ORDER BY 
							PERI_INICIAL
							, 
							COD_EMPRESA
							, 
							CONGENER";

                return query;
            }
            V0RELATORIOS.GetQueryEvent += GetQuery_V0RELATORIOS;

        }

        [StopWatch]
        /*" R0500-00-DECLARE-V0RELATORIOS-DB-OPEN-1 */
        public void R0500_00_DECLARE_V0RELATORIOS_DB_OPEN_1()
        {
            /*" -321- EXEC SQL OPEN V0RELATORIOS END-EXEC. */

            V0RELATORIOS.Open();

        }

        [StopWatch]
        /*" R1000-00-DECLARE-V1COSHISTPRE-DB-DECLARE-1 */
        public void R1000_00_DECLARE_V1COSHISTPRE_DB_DECLARE_1()
        {
            /*" -513- EXEC SQL DECLARE V1COSHISTPRE CURSOR FOR SELECT COD_EMPRESA , CONGENER , NUM_APOLICE , NRENDOS , NRPARCEL , OCORHIST , OPERACAO , DTMOVTO , TIPSGU , PRM_TARIFARIO , VAL_DESCONTO , VLPRMLIQ , VLADIFRA , VLCOMIS , VLPRMTOT , DTQITBCO , SIT_FINANCEIRA , SIT_LIBRECUP , NUMOCOR FROM SEGUROS.V1COSSEG_HISTPRE WHERE COD_EMPRESA = :V0CCHQ-COD-EMPR AND CONGENER = :V0CCHQ-CONGENER AND DTMOVTO = :V0CCHQ-DTMOVTO-AC AND TIPSGU = '1' AND OPERACAO IN (910,911,950,951, 930,931,940,941, 810,811,850,851, 830,831,840,841) AND SIT_LIBRECUP = '0' AND SIT_FINANCEIRA IN ( '0' , '1' ) ORDER BY CONGENER, NUM_APOLICE, NRENDOS, NRPARCEL, OCORHIST, OPERACAO END-EXEC. */
            V1COSHISTPRE = new AC0004B_V1COSHISTPRE(true);
            string GetQuery_V1COSHISTPRE()
            {
                var query = @$"SELECT COD_EMPRESA
							, 
							CONGENER
							, 
							NUM_APOLICE
							, 
							NRENDOS
							, 
							NRPARCEL
							, 
							OCORHIST
							, 
							OPERACAO
							, 
							DTMOVTO
							, 
							TIPSGU
							, 
							PRM_TARIFARIO
							, 
							VAL_DESCONTO
							, 
							VLPRMLIQ
							, 
							VLADIFRA
							, 
							VLCOMIS
							, 
							VLPRMTOT
							, 
							DTQITBCO
							, 
							SIT_FINANCEIRA
							, 
							SIT_LIBRECUP
							, 
							NUMOCOR 
							FROM SEGUROS.V1COSSEG_HISTPRE 
							WHERE COD_EMPRESA = '{V0CCHQ_COD_EMPR}' 
							AND CONGENER = '{V0CCHQ_CONGENER}' 
							AND DTMOVTO = '{V0CCHQ_DTMOVTO_AC}' 
							AND TIPSGU = '1' 
							AND OPERACAO IN (910
							,911
							,950
							,951
							, 
							930
							,931
							,940
							,941
							, 
							810
							,811
							,850
							,851
							, 
							830
							,831
							,840
							,841) 
							AND SIT_LIBRECUP = '0' 
							AND SIT_FINANCEIRA IN ( '0'
							, '1' ) 
							ORDER BY CONGENER
							, 
							NUM_APOLICE
							, 
							NRENDOS
							, 
							NRPARCEL
							, 
							OCORHIST
							, 
							OPERACAO";

                return query;
            }
            V1COSHISTPRE.GetQueryEvent += GetQuery_V1COSHISTPRE;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0550-00-FETCH-V0RELATORIOS-SECTION */
        private void R0550_00_FETCH_V0RELATORIOS_SECTION()
        {
            /*" -340- MOVE '0550' TO WNR-EXEC-SQL. */
            _.Move("0550", WABEND.WNR_EXEC_SQL);

            /*" -345- PERFORM R0550_00_FETCH_V0RELATORIOS_DB_FETCH_1 */

            R0550_00_FETCH_V0RELATORIOS_DB_FETCH_1();

            /*" -348- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -349- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -350- MOVE 'S' TO WFIM-V0RELATORIOS */
                    _.Move("S", AREA_DE_WORK.WFIM_V0RELATORIOS);

                    /*" -350- PERFORM R0550_00_FETCH_V0RELATORIOS_DB_CLOSE_1 */

                    R0550_00_FETCH_V0RELATORIOS_DB_CLOSE_1();

                    /*" -352- ELSE */
                }
                else
                {


                    /*" -353- DISPLAY 'R0550 - ERRO NO FETCH DA V0RELATORIOS' */
                    _.Display($"R0550 - ERRO NO FETCH DA V0RELATORIOS");

                    /*" -354- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -355- ELSE */
                }

            }
            else
            {


                /*" -355- ADD 1 TO AC-L-V0RELATORIOS. */
                AREA_DE_WORK.AC_L_V0RELATORIOS.Value = AREA_DE_WORK.AC_L_V0RELATORIOS + 1;
            }


        }

        [StopWatch]
        /*" R0550-00-FETCH-V0RELATORIOS-DB-FETCH-1 */
        public void R0550_00_FETCH_V0RELATORIOS_DB_FETCH_1()
        {
            /*" -345- EXEC SQL FETCH V0RELATORIOS INTO :V0RELA-PERI-INICIAL, :V0RELA-PERI-FINAL, :V0RELA-CONGENER, :V0RELA-COD-EMPR END-EXEC. */

            if (V0RELATORIOS.Fetch())
            {
                _.Move(V0RELATORIOS.V0RELA_PERI_INICIAL, V0RELA_PERI_INICIAL);
                _.Move(V0RELATORIOS.V0RELA_PERI_FINAL, V0RELA_PERI_FINAL);
                _.Move(V0RELATORIOS.V0RELA_CONGENER, V0RELA_CONGENER);
                _.Move(V0RELATORIOS.V0RELA_COD_EMPR, V0RELA_COD_EMPR);
            }

        }

        [StopWatch]
        /*" R0550-00-FETCH-V0RELATORIOS-DB-CLOSE-1 */
        public void R0550_00_FETCH_V0RELATORIOS_DB_CLOSE_1()
        {
            /*" -350- EXEC SQL CLOSE V0RELATORIOS END-EXEC */

            V0RELATORIOS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0550_99_SAIDA*/

        [StopWatch]
        /*" R0700-00-PROC-V0RELATORIOS-SECTION */
        private void R0700_00_PROC_V0RELATORIOS_SECTION()
        {
            /*" -368- MOVE '0700' TO WNR-EXEC-SQL. */
            _.Move("0700", WABEND.WNR_EXEC_SQL);

            /*" -370- PERFORM R0800-00-SELECT-COSCED-CHEQUE. */

            R0800_00_SELECT_COSCED_CHEQUE_SECTION();

            /*" -379- MOVE ZEROS TO AC-I-V0COSHISTSIN AC-I-V0COSHISTSIN AC-U-V0COSHISTSIN AC-I-V0COSHISTPRE AC-I-V0COSHISTPRE AC-U-V0COSHISTPRE. */
            _.Move(0, AREA_DE_WORK.AC_I_V0COSHISTSIN, AREA_DE_WORK.AC_I_V0COSHISTSIN, AREA_DE_WORK.AC_U_V0COSHISTSIN, AREA_DE_WORK.AC_I_V0COSHISTPRE, AREA_DE_WORK.AC_I_V0COSHISTPRE, AREA_DE_WORK.AC_U_V0COSHISTPRE);

            /*" -380- DISPLAY 'EMPRESA       - ' V0CCHQ-COD-EMPR. */
            _.Display($"EMPRESA       - {V0CCHQ_COD_EMPR}");

            /*" -381- DISPLAY 'CONGENERE     - ' V0CCHQ-CONGENER. */
            _.Display($"CONGENERE     - {V0CCHQ_CONGENER}");

            /*" -385- DISPLAY 'DTMOVTO-AC    - ' V0CCHQ-DTMOVTO-AC. */
            _.Display($"DTMOVTO-AC    - {V0CCHQ_DTMOVTO_AC}");

            /*" -387- DISPLAY '*** ESTORNO DO PREMIO ***' . */
            _.Display($"*** ESTORNO DO PREMIO ***");

            /*" -389- PERFORM R1000-00-DECLARE-V1COSHISTPRE. */

            R1000_00_DECLARE_V1COSHISTPRE_SECTION();

            /*" -391- PERFORM R1100-00-FETCH-V1COSHISTPRE. */

            R1100_00_FETCH_V1COSHISTPRE_SECTION();

            /*" -392- IF WFIM-V1COSHISTPRE NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1COSHISTPRE.IsEmpty())
            {

                /*" -393- PERFORM R9900-00-ENCERRA-SEM-MOVTO */

                R9900_00_ENCERRA_SEM_MOVTO_SECTION();

                /*" -394- ELSE */
            }
            else
            {


                /*" -397- PERFORM R1200-00-PROCESSA-V1COSHISTPRE UNTIL WFIM-V1COSHISTPRE NOT EQUAL SPACES. */

                while (!(!AREA_DE_WORK.WFIM_V1COSHISTPRE.IsEmpty()))
                {

                    R1200_00_PROCESSA_V1COSHISTPRE_SECTION();
                }
            }


            /*" -398- DISPLAY 'DOCUMENTOS LIDOS - ' AC-L-V1COSHISTPRE. */
            _.Display($"DOCUMENTOS LIDOS - {AREA_DE_WORK.AC_L_V1COSHISTPRE}");

            /*" -399- DISPLAY '       INSERIDOS - ' AC-I-V0COSHISTPRE. */
            _.Display($"       INSERIDOS - {AREA_DE_WORK.AC_I_V0COSHISTPRE}");

            /*" -400- DISPLAY '     ATUALIZADOS - ' AC-U-V0COSHISTPRE. */
            _.Display($"     ATUALIZADOS - {AREA_DE_WORK.AC_U_V0COSHISTPRE}");

            /*" -404- DISPLAY ' ' . */
            _.Display($" ");

            /*" -406- DISPLAY '*** ESTORNO DO SINISTRO ***' . */
            _.Display($"*** ESTORNO DO SINISTRO ***");

            /*" -408- PERFORM R2000-00-DECLARE-V1COSHISTSIN. */

            R2000_00_DECLARE_V1COSHISTSIN_SECTION();

            /*" -410- PERFORM R2100-00-FETCH-V1COSHISTSIN. */

            R2100_00_FETCH_V1COSHISTSIN_SECTION();

            /*" -411- IF WFIM-V1COSHISTSIN NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1COSHISTSIN.IsEmpty())
            {

                /*" -412- PERFORM R9900-00-ENCERRA-SEM-MOVTO */

                R9900_00_ENCERRA_SEM_MOVTO_SECTION();

                /*" -413- ELSE */
            }
            else
            {


                /*" -416- PERFORM R2200-00-PROCESSA-V1COSHISTSIN UNTIL WFIM-V1COSHISTSIN NOT EQUAL SPACES. */

                while (!(!AREA_DE_WORK.WFIM_V1COSHISTSIN.IsEmpty()))
                {

                    R2200_00_PROCESSA_V1COSHISTSIN_SECTION();
                }
            }


            /*" -417- DISPLAY 'DOCUMENTOS LIDOS - ' AC-L-V1COSHISTSIN. */
            _.Display($"DOCUMENTOS LIDOS - {AREA_DE_WORK.AC_L_V1COSHISTSIN}");

            /*" -418- DISPLAY '       INSERIDOS - ' AC-I-V0COSHISTSIN. */
            _.Display($"       INSERIDOS - {AREA_DE_WORK.AC_I_V0COSHISTSIN}");

            /*" -419- DISPLAY '     ATUALIZADOS - ' AC-U-V0COSHISTSIN. */
            _.Display($"     ATUALIZADOS - {AREA_DE_WORK.AC_U_V0COSHISTSIN}");

            /*" -423- DISPLAY ' ' . */
            _.Display($" ");

            /*" -425- PERFORM R3000-00-DELETE-V0RELATORIOS. */

            R3000_00_DELETE_V0RELATORIOS_SECTION();

            /*" -425- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -429- PERFORM R0500-00-DECLARE-V0RELATORIOS. */

            R0500_00_DECLARE_V0RELATORIOS_SECTION();

            /*" -429- PERFORM R0550-00-FETCH-V0RELATORIOS. */

            R0550_00_FETCH_V0RELATORIOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/

        [StopWatch]
        /*" R0800-00-SELECT-COSCED-CHEQUE-SECTION */
        private void R0800_00_SELECT_COSCED_CHEQUE_SECTION()
        {
            /*" -442- MOVE '0800' TO WNR-EXEC-SQL. */
            _.Move("0800", WABEND.WNR_EXEC_SQL);

            /*" -455- PERFORM R0800_00_SELECT_COSCED_CHEQUE_DB_SELECT_1 */

            R0800_00_SELECT_COSCED_CHEQUE_DB_SELECT_1();

            /*" -458- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -459- DISPLAY 'R0800 - ERRO NO SELECT DA V0COSCED_CHEQUE' */
                _.Display($"R0800 - ERRO NO SELECT DA V0COSCED_CHEQUE");

                /*" -460- DISPLAY 'COD EMPRESA - ' V0RELA-COD-EMPR */
                _.Display($"COD EMPRESA - {V0RELA_COD_EMPR}");

                /*" -461- DISPLAY 'CONGENERE   - ' V0RELA-CONGENER */
                _.Display($"CONGENERE   - {V0RELA_CONGENER}");

                /*" -462- DISPLAY 'DT MOVT AC  - ' V0RELA-PERI-INICIAL */
                _.Display($"DT MOVT AC  - {V0RELA_PERI_INICIAL}");

                /*" -463- DISPLAY 'DT MOVT FI  - ' V0RELA-PERI-FINAL */
                _.Display($"DT MOVT FI  - {V0RELA_PERI_FINAL}");

                /*" -463- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0800-00-SELECT-COSCED-CHEQUE-DB-SELECT-1 */
        public void R0800_00_SELECT_COSCED_CHEQUE_DB_SELECT_1()
        {
            /*" -455- EXEC SQL SELECT COD_EMPRESA , CONGENER , DTMOVTO_AC INTO :V0CCHQ-COD-EMPR, :V0CCHQ-CONGENER, :V0CCHQ-DTMOVTO-AC FROM SEGUROS.V0COSCED_CHEQUE WHERE COD_EMPRESA = :V0RELA-COD-EMPR AND CONGENER = :V0RELA-CONGENER AND DTMOVTO_AC = :V0RELA-PERI-INICIAL AND DTMOVTO_FI = :V0RELA-PERI-FINAL AND SITUACAO = '2' END-EXEC. */

            var r0800_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1 = new R0800_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1()
            {
                V0RELA_PERI_INICIAL = V0RELA_PERI_INICIAL.ToString(),
                V0RELA_PERI_FINAL = V0RELA_PERI_FINAL.ToString(),
                V0RELA_COD_EMPR = V0RELA_COD_EMPR.ToString(),
                V0RELA_CONGENER = V0RELA_CONGENER.ToString(),
            };

            var executed_1 = R0800_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1.Execute(r0800_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CCHQ_COD_EMPR, V0CCHQ_COD_EMPR);
                _.Move(executed_1.V0CCHQ_CONGENER, V0CCHQ_CONGENER);
                _.Move(executed_1.V0CCHQ_DTMOVTO_AC, V0CCHQ_DTMOVTO_AC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-DECLARE-V1COSHISTPRE-SECTION */
        private void R1000_00_DECLARE_V1COSHISTPRE_SECTION()
        {
            /*" -476- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", WABEND.WNR_EXEC_SQL);

            /*" -513- PERFORM R1000_00_DECLARE_V1COSHISTPRE_DB_DECLARE_1 */

            R1000_00_DECLARE_V1COSHISTPRE_DB_DECLARE_1();

            /*" -515- PERFORM R1000_00_DECLARE_V1COSHISTPRE_DB_OPEN_1 */

            R1000_00_DECLARE_V1COSHISTPRE_DB_OPEN_1();

            /*" -518- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -519- DISPLAY 'R1000 - ERRO NO DECLARE DA V1COSSEG_HISTPRE' */
                _.Display($"R1000 - ERRO NO DECLARE DA V1COSSEG_HISTPRE");

                /*" -520- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -521- ELSE */
            }
            else
            {


                /*" -521- MOVE SPACES TO WFIM-V1COSHISTPRE. */
                _.Move("", AREA_DE_WORK.WFIM_V1COSHISTPRE);
            }


        }

        [StopWatch]
        /*" R1000-00-DECLARE-V1COSHISTPRE-DB-OPEN-1 */
        public void R1000_00_DECLARE_V1COSHISTPRE_DB_OPEN_1()
        {
            /*" -515- EXEC SQL OPEN V1COSHISTPRE END-EXEC. */

            V1COSHISTPRE.Open();

        }

        [StopWatch]
        /*" R2000-00-DECLARE-V1COSHISTSIN-DB-DECLARE-1 */
        public void R2000_00_DECLARE_V1COSHISTSIN_DB_DECLARE_1()
        {
            /*" -809- EXEC SQL DECLARE V1COSHISTSIN CURSOR FOR SELECT A.COD_EMPRESA , A.CONGENER , A.NUM_SINISTRO , A.OCORHIST , A.OPERACAO , A.DTMOVTO , A.VAL_OPERACAO , A.SITUACAO , A.TIPSGU , A.SIT_LIBRECUP , B.IDE_SISTEMA , B.COD_FUNCAO , B.IDE_SISTEMA_OPER , B.COD_OPERACAO FROM SEGUROS.V1COSSEG_HISTSIN A, SEGUROS.GE_SIS_FUNCAO_OPER B WHERE A.COD_EMPRESA = :V0CCHQ-COD-EMPR AND A.CONGENER = :V0CCHQ-CONGENER AND A.DTMOVTO = :V0CCHQ-DTMOVTO-AC AND A.TIPSGU = '1' AND A.SIT_LIBRECUP = '0' AND A.SITUACAO IN ( '0' , '1' ) AND B.IDE_SISTEMA = 'AC' AND B.COD_FUNCAO IN (01,05) AND B.IDE_SISTEMA_OPER = B.IDE_SISTEMA AND B.COD_OPERACAO = A.OPERACAO ORDER BY A.CONGENER, A.NUM_SINISTRO, A.OCORHIST, A.DTMOVTO, A.OPERACAO END-EXEC. */
            V1COSHISTSIN = new AC0004B_V1COSHISTSIN(true);
            string GetQuery_V1COSHISTSIN()
            {
                var query = @$"SELECT A.COD_EMPRESA
							, 
							A.CONGENER
							, 
							A.NUM_SINISTRO
							, 
							A.OCORHIST
							, 
							A.OPERACAO
							, 
							A.DTMOVTO
							, 
							A.VAL_OPERACAO
							, 
							A.SITUACAO
							, 
							A.TIPSGU
							, 
							A.SIT_LIBRECUP
							, 
							B.IDE_SISTEMA
							, 
							B.COD_FUNCAO
							, 
							B.IDE_SISTEMA_OPER
							, 
							B.COD_OPERACAO 
							FROM SEGUROS.V1COSSEG_HISTSIN A
							, 
							SEGUROS.GE_SIS_FUNCAO_OPER B 
							WHERE A.COD_EMPRESA = '{V0CCHQ_COD_EMPR}' 
							AND A.CONGENER = '{V0CCHQ_CONGENER}' 
							AND A.DTMOVTO = '{V0CCHQ_DTMOVTO_AC}' 
							AND A.TIPSGU = '1' 
							AND A.SIT_LIBRECUP = '0' 
							AND A.SITUACAO IN ( '0'
							, '1' ) 
							AND B.IDE_SISTEMA = 'AC' 
							AND B.COD_FUNCAO IN (01
							,05) 
							AND B.IDE_SISTEMA_OPER = B.IDE_SISTEMA 
							AND B.COD_OPERACAO = A.OPERACAO 
							ORDER BY A.CONGENER
							, 
							A.NUM_SINISTRO
							, 
							A.OCORHIST
							, 
							A.DTMOVTO
							, 
							A.OPERACAO";

                return query;
            }
            V1COSHISTSIN.GetQueryEvent += GetQuery_V1COSHISTSIN;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-FETCH-V1COSHISTPRE-SECTION */
        private void R1100_00_FETCH_V1COSHISTPRE_SECTION()
        {
            /*" -534- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", WABEND.WNR_EXEC_SQL);

            /*" -554- PERFORM R1100_00_FETCH_V1COSHISTPRE_DB_FETCH_1 */

            R1100_00_FETCH_V1COSHISTPRE_DB_FETCH_1();

            /*" -557- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -558- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -559- MOVE 'S' TO WFIM-V1COSHISTPRE */
                    _.Move("S", AREA_DE_WORK.WFIM_V1COSHISTPRE);

                    /*" -559- PERFORM R1100_00_FETCH_V1COSHISTPRE_DB_CLOSE_1 */

                    R1100_00_FETCH_V1COSHISTPRE_DB_CLOSE_1();

                    /*" -561- ELSE */
                }
                else
                {


                    /*" -562- DISPLAY 'R1100 - ERRO NO FETCH DA V1COSSEG_HISTPRE' */
                    _.Display($"R1100 - ERRO NO FETCH DA V1COSSEG_HISTPRE");

                    /*" -563- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -564- ELSE */
                }

            }
            else
            {


                /*" -564- ADD 1 TO AC-L-V1COSHISTPRE. */
                AREA_DE_WORK.AC_L_V1COSHISTPRE.Value = AREA_DE_WORK.AC_L_V1COSHISTPRE + 1;
            }


        }

        [StopWatch]
        /*" R1100-00-FETCH-V1COSHISTPRE-DB-FETCH-1 */
        public void R1100_00_FETCH_V1COSHISTPRE_DB_FETCH_1()
        {
            /*" -554- EXEC SQL FETCH V1COSHISTPRE INTO :V1CHSP-COD-EMPR , :V1CHSP-CONGENER , :V1CHSP-NUM-APOL , :V1CHSP-NRENDOS , :V1CHSP-NRPARCEL , :V1CHSP-OCORHIST , :V1CHSP-OPERACAO , :V1CHSP-DTMOVTO , :V1CHSP-TIPSGU , :V1CHSP-PRM-TAR , :V1CHSP-VAL-DESC , :V1CHSP-VLPRMLIQ , :V1CHSP-VLADIFRA , :V1CHSP-VLCOMIS , :V1CHSP-VLPRMTOT , :V1CHSP-DTQITBCO:VIND-DAT-QTBC, :V1CHSP-SIT-FINANC:VIND-SIT-FINC, :V1CHSP-SIT-LIBREC:VIND-SIT-LIBR, :V1CHSP-NUMOCOR:VIND-NUM-OCOR END-EXEC. */

            if (V1COSHISTPRE.Fetch())
            {
                _.Move(V1COSHISTPRE.V1CHSP_COD_EMPR, V1CHSP_COD_EMPR);
                _.Move(V1COSHISTPRE.V1CHSP_CONGENER, V1CHSP_CONGENER);
                _.Move(V1COSHISTPRE.V1CHSP_NUM_APOL, V1CHSP_NUM_APOL);
                _.Move(V1COSHISTPRE.V1CHSP_NRENDOS, V1CHSP_NRENDOS);
                _.Move(V1COSHISTPRE.V1CHSP_NRPARCEL, V1CHSP_NRPARCEL);
                _.Move(V1COSHISTPRE.V1CHSP_OCORHIST, V1CHSP_OCORHIST);
                _.Move(V1COSHISTPRE.V1CHSP_OPERACAO, V1CHSP_OPERACAO);
                _.Move(V1COSHISTPRE.V1CHSP_DTMOVTO, V1CHSP_DTMOVTO);
                _.Move(V1COSHISTPRE.V1CHSP_TIPSGU, V1CHSP_TIPSGU);
                _.Move(V1COSHISTPRE.V1CHSP_PRM_TAR, V1CHSP_PRM_TAR);
                _.Move(V1COSHISTPRE.V1CHSP_VAL_DESC, V1CHSP_VAL_DESC);
                _.Move(V1COSHISTPRE.V1CHSP_VLPRMLIQ, V1CHSP_VLPRMLIQ);
                _.Move(V1COSHISTPRE.V1CHSP_VLADIFRA, V1CHSP_VLADIFRA);
                _.Move(V1COSHISTPRE.V1CHSP_VLCOMIS, V1CHSP_VLCOMIS);
                _.Move(V1COSHISTPRE.V1CHSP_VLPRMTOT, V1CHSP_VLPRMTOT);
                _.Move(V1COSHISTPRE.V1CHSP_DTQITBCO, V1CHSP_DTQITBCO);
                _.Move(V1COSHISTPRE.VIND_DAT_QTBC, VIND_DAT_QTBC);
                _.Move(V1COSHISTPRE.V1CHSP_SIT_FINANC, V1CHSP_SIT_FINANC);
                _.Move(V1COSHISTPRE.VIND_SIT_FINC, VIND_SIT_FINC);
                _.Move(V1COSHISTPRE.V1CHSP_SIT_LIBREC, V1CHSP_SIT_LIBREC);
                _.Move(V1COSHISTPRE.VIND_SIT_LIBR, VIND_SIT_LIBR);
                _.Move(V1COSHISTPRE.V1CHSP_NUMOCOR, V1CHSP_NUMOCOR);
                _.Move(V1COSHISTPRE.VIND_NUM_OCOR, VIND_NUM_OCOR);
            }

        }

        [StopWatch]
        /*" R1100-00-FETCH-V1COSHISTPRE-DB-CLOSE-1 */
        public void R1100_00_FETCH_V1COSHISTPRE_DB_CLOSE_1()
        {
            /*" -559- EXEC SQL CLOSE V1COSHISTPRE END-EXEC */

            V1COSHISTPRE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-PROCESSA-V1COSHISTPRE-SECTION */
        private void R1200_00_PROCESSA_V1COSHISTPRE_SECTION()
        {
            /*" -577- MOVE '1200' TO WNR-EXEC-SQL. */
            _.Move("1200", WABEND.WNR_EXEC_SQL);

            /*" -579- PERFORM R1300-00-SELECT-V0COSSEGPREM. */

            R1300_00_SELECT_V0COSSEGPREM_SECTION();

            /*" -581- ADD +1 TO V0CHSP-OCORHIST. */
            V0CHSP_OCORHIST.Value = V0CHSP_OCORHIST + +1;

            /*" -583- MOVE ZEROS TO V0CHSP-OPERACAO. */
            _.Move(0, V0CHSP_OPERACAO);

            /*" -585- IF V1CHSP-OPERACAO = 910 OR 911 OR 950 OR 951 OR 810 OR 811 OR 850 OR 851 */

            if (V1CHSP_OPERACAO.In("910", "911", "950", "951", "810", "811", "850", "851"))
            {

                /*" -586- COMPUTE V0CHSP-OPERACAO = V1CHSP-OPERACAO + 10 */
                V0CHSP_OPERACAO.Value = V1CHSP_OPERACAO + 10;

                /*" -587- ELSE */
            }
            else
            {


                /*" -589- IF V1CHSP-OPERACAO = 930 OR 931 OR 940 OR 941 OR 830 OR 831 OR 840 OR 841 */

                if (V1CHSP_OPERACAO.In("930", "931", "940", "941", "830", "831", "840", "841"))
                {

                    /*" -591- COMPUTE V0CHSP-OPERACAO = V1CHSP-OPERACAO + 40. */
                    V0CHSP_OPERACAO.Value = V1CHSP_OPERACAO + 40;
                }

            }


            /*" -593- MOVE V0SIST-DTMOVABE-AC TO V0CHSP-DTMOVTO. */
            _.Move(V0SIST_DTMOVABE_AC, V0CHSP_DTMOVTO);

            /*" -596- MOVE '0' TO V0CHSP-SIT-FINANC V0CHSP-SIT-LIBREC. */
            _.Move("0", V0CHSP_SIT_FINANC, V0CHSP_SIT_LIBREC);

            /*" -599- MOVE +1 TO VIND-SIT-FINC VIND-SIT-LIBR. */
            _.Move(+1, VIND_SIT_FINC, VIND_SIT_LIBR);

            /*" -601- PERFORM R1400-00-INSERT-V0COSHISTPRE. */

            R1400_00_INSERT_V0COSHISTPRE_SECTION();

            /*" -603- PERFORM R1500-00-UPDATE-V0COSHISTPRE. */

            R1500_00_UPDATE_V0COSHISTPRE_SECTION();

            /*" -607- PERFORM R1600-00-UPDATE-V0COSSEGPREM. */

            R1600_00_UPDATE_V0COSSEGPREM_SECTION();

            /*" -607- PERFORM R1100-00-FETCH-V1COSHISTPRE. */

            R1100_00_FETCH_V1COSHISTPRE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-SELECT-V0COSSEGPREM-SECTION */
        private void R1300_00_SELECT_V0COSSEGPREM_SECTION()
        {
            /*" -620- MOVE '1300' TO WNR-EXEC-SQL. */
            _.Move("1300", WABEND.WNR_EXEC_SQL);

            /*" -629- PERFORM R1300_00_SELECT_V0COSSEGPREM_DB_SELECT_1 */

            R1300_00_SELECT_V0COSSEGPREM_DB_SELECT_1();

            /*" -632- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -633- DISPLAY 'R1300 - ERRO NO SELECT DA V0COSSEG_PREM' */
                _.Display($"R1300 - ERRO NO SELECT DA V0COSSEG_PREM");

                /*" -634- DISPLAY 'CONGENERE - ' V1CHSP-CONGENER */
                _.Display($"CONGENERE - {V1CHSP_CONGENER}");

                /*" -635- DISPLAY 'APOLICE   - ' V1CHSP-NUM-APOL */
                _.Display($"APOLICE   - {V1CHSP_NUM_APOL}");

                /*" -636- DISPLAY 'ENDOSSO   - ' V1CHSP-NRENDOS */
                _.Display($"ENDOSSO   - {V1CHSP_NRENDOS}");

                /*" -637- DISPLAY 'PARCELA   - ' V1CHSP-NRPARCEL */
                _.Display($"PARCELA   - {V1CHSP_NRPARCEL}");

                /*" -638- DISPLAY 'TP SEGURO - ' V1CHSP-TIPSGU */
                _.Display($"TP SEGURO - {V1CHSP_TIPSGU}");

                /*" -638- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1300-00-SELECT-V0COSSEGPREM-DB-SELECT-1 */
        public void R1300_00_SELECT_V0COSSEGPREM_DB_SELECT_1()
        {
            /*" -629- EXEC SQL SELECT OCORHIST INTO :V0CHSP-OCORHIST FROM SEGUROS.V0COSSEG_PREM WHERE CONGENER = :V1CHSP-CONGENER AND NUM_APOLICE = :V1CHSP-NUM-APOL AND NRENDOS = :V1CHSP-NRENDOS AND NRPARCEL = :V1CHSP-NRPARCEL AND TIPSGU = :V1CHSP-TIPSGU END-EXEC. */

            var r1300_00_SELECT_V0COSSEGPREM_DB_SELECT_1_Query1 = new R1300_00_SELECT_V0COSSEGPREM_DB_SELECT_1_Query1()
            {
                V1CHSP_CONGENER = V1CHSP_CONGENER.ToString(),
                V1CHSP_NUM_APOL = V1CHSP_NUM_APOL.ToString(),
                V1CHSP_NRPARCEL = V1CHSP_NRPARCEL.ToString(),
                V1CHSP_NRENDOS = V1CHSP_NRENDOS.ToString(),
                V1CHSP_TIPSGU = V1CHSP_TIPSGU.ToString(),
            };

            var executed_1 = R1300_00_SELECT_V0COSSEGPREM_DB_SELECT_1_Query1.Execute(r1300_00_SELECT_V0COSSEGPREM_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CHSP_OCORHIST, V0CHSP_OCORHIST);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-INSERT-V0COSHISTPRE-SECTION */
        private void R1400_00_INSERT_V0COSHISTPRE_SECTION()
        {
            /*" -651- MOVE '1400' TO WNR-EXEC-SQL. */
            _.Move("1400", WABEND.WNR_EXEC_SQL);

            /*" -673- PERFORM R1400_00_INSERT_V0COSHISTPRE_DB_INSERT_1 */

            R1400_00_INSERT_V0COSHISTPRE_DB_INSERT_1();

            /*" -676- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -677- DISPLAY 'R1400 - ERRO NO INSERT DA V0COSSEG_HISTPRE' */
                _.Display($"R1400 - ERRO NO INSERT DA V0COSSEG_HISTPRE");

                /*" -678- DISPLAY 'CONGENERE - ' V1CHSP-CONGENER */
                _.Display($"CONGENERE - {V1CHSP_CONGENER}");

                /*" -679- DISPLAY 'APOLICE   - ' V1CHSP-NUM-APOL */
                _.Display($"APOLICE   - {V1CHSP_NUM_APOL}");

                /*" -680- DISPLAY 'ENDOSSO   - ' V1CHSP-NRENDOS */
                _.Display($"ENDOSSO   - {V1CHSP_NRENDOS}");

                /*" -681- DISPLAY 'PARCELA   - ' V1CHSP-NRPARCEL */
                _.Display($"PARCELA   - {V1CHSP_NRPARCEL}");

                /*" -682- DISPLAY 'OCOR HIST - ' V0CHSP-OCORHIST */
                _.Display($"OCOR HIST - {V0CHSP_OCORHIST}");

                /*" -683- DISPLAY 'OPERACAO  - ' V0CHSP-OPERACAO */
                _.Display($"OPERACAO  - {V0CHSP_OPERACAO}");

                /*" -684- DISPLAY 'DAT MOVTO - ' V0CHSP-DTMOVTO */
                _.Display($"DAT MOVTO - {V0CHSP_DTMOVTO}");

                /*" -685- DISPLAY 'TP SEGURO - ' V1CHSP-TIPSGU */
                _.Display($"TP SEGURO - {V1CHSP_TIPSGU}");

                /*" -686- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -687- ELSE */
            }
            else
            {


                /*" -687- ADD 1 TO AC-I-V0COSHISTPRE. */
                AREA_DE_WORK.AC_I_V0COSHISTPRE.Value = AREA_DE_WORK.AC_I_V0COSHISTPRE + 1;
            }


        }

        [StopWatch]
        /*" R1400-00-INSERT-V0COSHISTPRE-DB-INSERT-1 */
        public void R1400_00_INSERT_V0COSHISTPRE_DB_INSERT_1()
        {
            /*" -673- EXEC SQL INSERT INTO SEGUROS.V0COSSEG_HISTPRE VALUES (:V1CHSP-COD-EMPR , :V1CHSP-CONGENER , :V1CHSP-NUM-APOL , :V1CHSP-NRENDOS , :V1CHSP-NRPARCEL , :V0CHSP-OCORHIST , :V0CHSP-OPERACAO , :V0CHSP-DTMOVTO , :V1CHSP-TIPSGU , :V1CHSP-PRM-TAR , :V1CHSP-VAL-DESC , :V1CHSP-VLPRMLIQ , :V1CHSP-VLADIFRA , :V1CHSP-VLCOMIS , :V1CHSP-VLPRMTOT , CURRENT TIMESTAMP , :V1CHSP-DTQITBCO:VIND-DAT-QTBC, :V0CHSP-SIT-FINANC:VIND-SIT-FINC, :V0CHSP-SIT-LIBREC:VIND-SIT-LIBR, :V1CHSP-NUMOCOR:VIND-NUM-OCOR) END-EXEC. */

            var r1400_00_INSERT_V0COSHISTPRE_DB_INSERT_1_Insert1 = new R1400_00_INSERT_V0COSHISTPRE_DB_INSERT_1_Insert1()
            {
                V1CHSP_COD_EMPR = V1CHSP_COD_EMPR.ToString(),
                V1CHSP_CONGENER = V1CHSP_CONGENER.ToString(),
                V1CHSP_NUM_APOL = V1CHSP_NUM_APOL.ToString(),
                V1CHSP_NRENDOS = V1CHSP_NRENDOS.ToString(),
                V1CHSP_NRPARCEL = V1CHSP_NRPARCEL.ToString(),
                V0CHSP_OCORHIST = V0CHSP_OCORHIST.ToString(),
                V0CHSP_OPERACAO = V0CHSP_OPERACAO.ToString(),
                V0CHSP_DTMOVTO = V0CHSP_DTMOVTO.ToString(),
                V1CHSP_TIPSGU = V1CHSP_TIPSGU.ToString(),
                V1CHSP_PRM_TAR = V1CHSP_PRM_TAR.ToString(),
                V1CHSP_VAL_DESC = V1CHSP_VAL_DESC.ToString(),
                V1CHSP_VLPRMLIQ = V1CHSP_VLPRMLIQ.ToString(),
                V1CHSP_VLADIFRA = V1CHSP_VLADIFRA.ToString(),
                V1CHSP_VLCOMIS = V1CHSP_VLCOMIS.ToString(),
                V1CHSP_VLPRMTOT = V1CHSP_VLPRMTOT.ToString(),
                V1CHSP_DTQITBCO = V1CHSP_DTQITBCO.ToString(),
                VIND_DAT_QTBC = VIND_DAT_QTBC.ToString(),
                V0CHSP_SIT_FINANC = V0CHSP_SIT_FINANC.ToString(),
                VIND_SIT_FINC = VIND_SIT_FINC.ToString(),
                V0CHSP_SIT_LIBREC = V0CHSP_SIT_LIBREC.ToString(),
                VIND_SIT_LIBR = VIND_SIT_LIBR.ToString(),
                V1CHSP_NUMOCOR = V1CHSP_NUMOCOR.ToString(),
                VIND_NUM_OCOR = VIND_NUM_OCOR.ToString(),
            };

            R1400_00_INSERT_V0COSHISTPRE_DB_INSERT_1_Insert1.Execute(r1400_00_INSERT_V0COSHISTPRE_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-UPDATE-V0COSHISTPRE-SECTION */
        private void R1500_00_UPDATE_V0COSHISTPRE_SECTION()
        {
            /*" -700- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", WABEND.WNR_EXEC_SQL);

            /*" -711- PERFORM R1500_00_UPDATE_V0COSHISTPRE_DB_UPDATE_1 */

            R1500_00_UPDATE_V0COSHISTPRE_DB_UPDATE_1();

            /*" -714- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -715- DISPLAY 'R1500 - ERRO NO UPDATE DA V0COSSEG_HISTPRE' */
                _.Display($"R1500 - ERRO NO UPDATE DA V0COSSEG_HISTPRE");

                /*" -716- DISPLAY 'CONGENERE - ' V1CHSP-CONGENER */
                _.Display($"CONGENERE - {V1CHSP_CONGENER}");

                /*" -717- DISPLAY 'APOLICE   - ' V1CHSP-NUM-APOL */
                _.Display($"APOLICE   - {V1CHSP_NUM_APOL}");

                /*" -718- DISPLAY 'ENDOSSO   - ' V1CHSP-NRENDOS */
                _.Display($"ENDOSSO   - {V1CHSP_NRENDOS}");

                /*" -719- DISPLAY 'PARCELA   - ' V1CHSP-NRPARCEL */
                _.Display($"PARCELA   - {V1CHSP_NRPARCEL}");

                /*" -720- DISPLAY 'OCOR HIST - ' V1CHSP-OCORHIST */
                _.Display($"OCOR HIST - {V1CHSP_OCORHIST}");

                /*" -721- DISPLAY 'OPERACAO  - ' V1CHSP-OPERACAO */
                _.Display($"OPERACAO  - {V1CHSP_OPERACAO}");

                /*" -722- DISPLAY 'TP SEGURO - ' V1CHSP-TIPSGU */
                _.Display($"TP SEGURO - {V1CHSP_TIPSGU}");

                /*" -723- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -724- ELSE */
            }
            else
            {


                /*" -724- ADD 1 TO AC-U-V0COSHISTPRE. */
                AREA_DE_WORK.AC_U_V0COSHISTPRE.Value = AREA_DE_WORK.AC_U_V0COSHISTPRE + 1;
            }


        }

        [StopWatch]
        /*" R1500-00-UPDATE-V0COSHISTPRE-DB-UPDATE-1 */
        public void R1500_00_UPDATE_V0COSHISTPRE_DB_UPDATE_1()
        {
            /*" -711- EXEC SQL UPDATE SEGUROS.V0COSSEG_HISTPRE SET SIT_LIBRECUP = '2' , TIMESTAMP = CURRENT TIMESTAMP WHERE CONGENER = :V1CHSP-CONGENER AND NUM_APOLICE = :V1CHSP-NUM-APOL AND NRENDOS = :V1CHSP-NRENDOS AND NRPARCEL = :V1CHSP-NRPARCEL AND OCORHIST = :V1CHSP-OCORHIST AND OPERACAO = :V1CHSP-OPERACAO AND TIPSGU = :V1CHSP-TIPSGU END-EXEC. */

            var r1500_00_UPDATE_V0COSHISTPRE_DB_UPDATE_1_Update1 = new R1500_00_UPDATE_V0COSHISTPRE_DB_UPDATE_1_Update1()
            {
                V1CHSP_CONGENER = V1CHSP_CONGENER.ToString(),
                V1CHSP_NUM_APOL = V1CHSP_NUM_APOL.ToString(),
                V1CHSP_NRPARCEL = V1CHSP_NRPARCEL.ToString(),
                V1CHSP_OCORHIST = V1CHSP_OCORHIST.ToString(),
                V1CHSP_OPERACAO = V1CHSP_OPERACAO.ToString(),
                V1CHSP_NRENDOS = V1CHSP_NRENDOS.ToString(),
                V1CHSP_TIPSGU = V1CHSP_TIPSGU.ToString(),
            };

            R1500_00_UPDATE_V0COSHISTPRE_DB_UPDATE_1_Update1.Execute(r1500_00_UPDATE_V0COSHISTPRE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-UPDATE-V0COSSEGPREM-SECTION */
        private void R1600_00_UPDATE_V0COSSEGPREM_SECTION()
        {
            /*" -737- MOVE '1600' TO WNR-EXEC-SQL. */
            _.Move("1600", WABEND.WNR_EXEC_SQL);

            /*" -747- PERFORM R1600_00_UPDATE_V0COSSEGPREM_DB_UPDATE_1 */

            R1600_00_UPDATE_V0COSSEGPREM_DB_UPDATE_1();

            /*" -750- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -751- DISPLAY 'R1600 - ERRO NO UPDATE DA V0COSSEG_PREM' */
                _.Display($"R1600 - ERRO NO UPDATE DA V0COSSEG_PREM");

                /*" -752- DISPLAY 'CONGENERE - ' V1CHSP-CONGENER */
                _.Display($"CONGENERE - {V1CHSP_CONGENER}");

                /*" -753- DISPLAY 'APOLICE   - ' V1CHSP-NUM-APOL */
                _.Display($"APOLICE   - {V1CHSP_NUM_APOL}");

                /*" -754- DISPLAY 'ENDOSSO   - ' V1CHSP-NRENDOS */
                _.Display($"ENDOSSO   - {V1CHSP_NRENDOS}");

                /*" -755- DISPLAY 'PARCELA   - ' V1CHSP-NRPARCEL */
                _.Display($"PARCELA   - {V1CHSP_NRPARCEL}");

                /*" -756- DISPLAY 'TP SEGURO - ' V1CHSP-TIPSGU */
                _.Display($"TP SEGURO - {V1CHSP_TIPSGU}");

                /*" -756- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1600-00-UPDATE-V0COSSEGPREM-DB-UPDATE-1 */
        public void R1600_00_UPDATE_V0COSSEGPREM_DB_UPDATE_1()
        {
            /*" -747- EXEC SQL UPDATE SEGUROS.V0COSSEG_PREM SET SIT_CONGENERE = '0' , OCORHIST = :V0CHSP-OCORHIST, TIMESTAMP = CURRENT TIMESTAMP WHERE CONGENER = :V1CHSP-CONGENER AND NUM_APOLICE = :V1CHSP-NUM-APOL AND NRENDOS = :V1CHSP-NRENDOS AND NRPARCEL = :V1CHSP-NRPARCEL AND TIPSGU = :V1CHSP-TIPSGU END-EXEC. */

            var r1600_00_UPDATE_V0COSSEGPREM_DB_UPDATE_1_Update1 = new R1600_00_UPDATE_V0COSSEGPREM_DB_UPDATE_1_Update1()
            {
                V0CHSP_OCORHIST = V0CHSP_OCORHIST.ToString(),
                V1CHSP_CONGENER = V1CHSP_CONGENER.ToString(),
                V1CHSP_NUM_APOL = V1CHSP_NUM_APOL.ToString(),
                V1CHSP_NRPARCEL = V1CHSP_NRPARCEL.ToString(),
                V1CHSP_NRENDOS = V1CHSP_NRENDOS.ToString(),
                V1CHSP_TIPSGU = V1CHSP_TIPSGU.ToString(),
            };

            R1600_00_UPDATE_V0COSSEGPREM_DB_UPDATE_1_Update1.Execute(r1600_00_UPDATE_V0COSSEGPREM_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-DECLARE-V1COSHISTSIN-SECTION */
        private void R2000_00_DECLARE_V1COSHISTSIN_SECTION()
        {
            /*" -769- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", WABEND.WNR_EXEC_SQL);

            /*" -809- PERFORM R2000_00_DECLARE_V1COSHISTSIN_DB_DECLARE_1 */

            R2000_00_DECLARE_V1COSHISTSIN_DB_DECLARE_1();

            /*" -811- PERFORM R2000_00_DECLARE_V1COSHISTSIN_DB_OPEN_1 */

            R2000_00_DECLARE_V1COSHISTSIN_DB_OPEN_1();

            /*" -814- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -815- DISPLAY 'R2000 - ERRO NO DECLARE DA V1COSSEG_HISTSIN' */
                _.Display($"R2000 - ERRO NO DECLARE DA V1COSSEG_HISTSIN");

                /*" -816- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -817- ELSE */
            }
            else
            {


                /*" -817- MOVE SPACES TO WFIM-V1COSHISTSIN. */
                _.Move("", AREA_DE_WORK.WFIM_V1COSHISTSIN);
            }


        }

        [StopWatch]
        /*" R2000-00-DECLARE-V1COSHISTSIN-DB-OPEN-1 */
        public void R2000_00_DECLARE_V1COSHISTSIN_DB_OPEN_1()
        {
            /*" -811- EXEC SQL OPEN V1COSHISTSIN END-EXEC. */

            V1COSHISTSIN.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-FETCH-V1COSHISTSIN-SECTION */
        private void R2100_00_FETCH_V1COSHISTSIN_SECTION()
        {
            /*" -830- MOVE '2100' TO WNR-EXEC-SQL. */
            _.Move("2100", WABEND.WNR_EXEC_SQL);

            /*" -845- PERFORM R2100_00_FETCH_V1COSHISTSIN_DB_FETCH_1 */

            R2100_00_FETCH_V1COSHISTSIN_DB_FETCH_1();

            /*" -848- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -849- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -850- MOVE 'S' TO WFIM-V1COSHISTSIN */
                    _.Move("S", AREA_DE_WORK.WFIM_V1COSHISTSIN);

                    /*" -850- PERFORM R2100_00_FETCH_V1COSHISTSIN_DB_CLOSE_1 */

                    R2100_00_FETCH_V1COSHISTSIN_DB_CLOSE_1();

                    /*" -852- ELSE */
                }
                else
                {


                    /*" -853- DISPLAY 'R2100 - ERRO NO FETCH DA V1COSSEG_HISTSIN' */
                    _.Display($"R2100 - ERRO NO FETCH DA V1COSSEG_HISTSIN");

                    /*" -854- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -855- ELSE */
                }

            }
            else
            {


                /*" -855- ADD 1 TO AC-L-V1COSHISTSIN. */
                AREA_DE_WORK.AC_L_V1COSHISTSIN.Value = AREA_DE_WORK.AC_L_V1COSHISTSIN + 1;
            }


        }

        [StopWatch]
        /*" R2100-00-FETCH-V1COSHISTSIN-DB-FETCH-1 */
        public void R2100_00_FETCH_V1COSHISTSIN_DB_FETCH_1()
        {
            /*" -845- EXEC SQL FETCH V1COSHISTSIN INTO :V1CHSI-COD-EMPR , :V1CHSI-CONGENER , :V1CHSI-NUM-SINI , :V1CHSI-OCORHIST , :V1CHSI-OPERACAO , :V1CHSI-DTMOVTO , :V1CHSI-VAL-OPER , :V1CHSI-SITUACAO:VIND-SIT-REGT, :V1CHSI-TIPSGU:VIND-TIP-SEGR, :V1CHSI-SIT-LIBREC:VIND-SIT-LIBR, :GESISFUO-IDE-SISTEMA , :GESISFUO-COD-FUNCAO , :GESISFUO-IDE-SISTEMA-OPER , :GESISFUO-COD-OPERACAO END-EXEC. */

            if (V1COSHISTSIN.Fetch())
            {
                _.Move(V1COSHISTSIN.V1CHSI_COD_EMPR, V1CHSI_COD_EMPR);
                _.Move(V1COSHISTSIN.V1CHSI_CONGENER, V1CHSI_CONGENER);
                _.Move(V1COSHISTSIN.V1CHSI_NUM_SINI, V1CHSI_NUM_SINI);
                _.Move(V1COSHISTSIN.V1CHSI_OCORHIST, V1CHSI_OCORHIST);
                _.Move(V1COSHISTSIN.V1CHSI_OPERACAO, V1CHSI_OPERACAO);
                _.Move(V1COSHISTSIN.V1CHSI_DTMOVTO, V1CHSI_DTMOVTO);
                _.Move(V1COSHISTSIN.V1CHSI_VAL_OPER, V1CHSI_VAL_OPER);
                _.Move(V1COSHISTSIN.V1CHSI_SITUACAO, V1CHSI_SITUACAO);
                _.Move(V1COSHISTSIN.VIND_SIT_REGT, VIND_SIT_REGT);
                _.Move(V1COSHISTSIN.V1CHSI_TIPSGU, V1CHSI_TIPSGU);
                _.Move(V1COSHISTSIN.VIND_TIP_SEGR, VIND_TIP_SEGR);
                _.Move(V1COSHISTSIN.V1CHSI_SIT_LIBREC, V1CHSI_SIT_LIBREC);
                _.Move(V1COSHISTSIN.VIND_SIT_LIBR, VIND_SIT_LIBR);
                _.Move(V1COSHISTSIN.GESISFUO_IDE_SISTEMA, GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_IDE_SISTEMA);
                _.Move(V1COSHISTSIN.GESISFUO_COD_FUNCAO, GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_COD_FUNCAO);
                _.Move(V1COSHISTSIN.GESISFUO_IDE_SISTEMA_OPER, GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_IDE_SISTEMA_OPER);
                _.Move(V1COSHISTSIN.GESISFUO_COD_OPERACAO, GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_COD_OPERACAO);
            }

        }

        [StopWatch]
        /*" R2100-00-FETCH-V1COSHISTSIN-DB-CLOSE-1 */
        public void R2100_00_FETCH_V1COSHISTSIN_DB_CLOSE_1()
        {
            /*" -850- EXEC SQL CLOSE V1COSHISTSIN END-EXEC */

            V1COSHISTSIN.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-PROCESSA-V1COSHISTSIN-SECTION */
        private void R2200_00_PROCESSA_V1COSHISTSIN_SECTION()
        {
            /*" -870- MOVE '2200' TO WNR-EXEC-SQL. */
            _.Move("2200", WABEND.WNR_EXEC_SQL);

            /*" -872- PERFORM R2300-00-SELECT-GESISORL. */

            R2300_00_SELECT_GESISORL_SECTION();

            /*" -875- MOVE GESISORL-COD-OPERACAO-ASS TO V0CHSI-OPERACAO. */
            _.Move(GESISORL.DCLGE_SIS_FUN_OPE_REL.GESISORL_COD_OPERACAO_ASS, V0CHSI_OPERACAO);

            /*" -877- MOVE V0SIST-DTMOVABE-AC TO V0CHSI-DTMOVTO. */
            _.Move(V0SIST_DTMOVABE_AC, V0CHSI_DTMOVTO);

            /*" -880- MOVE '0' TO V0CHSI-SITUACAO V0CHSI-SIT-LIBREC. */
            _.Move("0", V0CHSI_SITUACAO, V0CHSI_SIT_LIBREC);

            /*" -883- MOVE +1 TO VIND-SIT-REGT VIND-SIT-LIBR. */
            _.Move(+1, VIND_SIT_REGT, VIND_SIT_LIBR);

            /*" -885- PERFORM R2400-00-UPDATE-V0COSHISTSIN. */

            R2400_00_UPDATE_V0COSHISTSIN_SECTION();

            /*" -889- PERFORM R2500-00-INSERT-V0COSHISTSIN. */

            R2500_00_INSERT_V0COSHISTSIN_SECTION();

            /*" -889- PERFORM R2100-00-FETCH-V1COSHISTSIN. */

            R2100_00_FETCH_V1COSHISTSIN_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-SELECT-GESISORL-SECTION */
        private void R2300_00_SELECT_GESISORL_SECTION()
        {
            /*" -902- MOVE '2300' TO WNR-EXEC-SQL. */
            _.Move("2300", WABEND.WNR_EXEC_SQL);

            /*" -920- PERFORM R2300_00_SELECT_GESISORL_DB_SELECT_1 */

            R2300_00_SELECT_GESISORL_DB_SELECT_1();

            /*" -923- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -924- DISPLAY 'R2300 - ERRO NO SELECT GE_SIS_FUN_OPE_REL' */
                _.Display($"R2300 - ERRO NO SELECT GE_SIS_FUN_OPE_REL");

                /*" -925- DISPLAY 'CONGENERE    - ' V1CHSI-CONGENER */
                _.Display($"CONGENERE    - {V1CHSI_CONGENER}");

                /*" -926- DISPLAY 'SINISTRO     - ' V1CHSI-NUM-SINI */
                _.Display($"SINISTRO     - {V1CHSI_NUM_SINI}");

                /*" -927- DISPLAY 'OCOR HIST    - ' V1CHSI-OCORHIST */
                _.Display($"OCOR HIST    - {V1CHSI_OCORHIST}");

                /*" -928- DISPLAY 'OPERACAO SI  - ' V1CHSI-OPERACAO */
                _.Display($"OPERACAO SI  - {V1CHSI_OPERACAO}");

                /*" -929- DISPLAY 'DATA MOVTO   - ' V1CHSI-DTMOVTO */
                _.Display($"DATA MOVTO   - {V1CHSI_DTMOVTO}");

                /*" -930- DISPLAY 'ID SISTEMA   - ' GESISFUO-IDE-SISTEMA */
                _.Display($"ID SISTEMA   - {GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_IDE_SISTEMA}");

                /*" -931- DISPLAY 'COD FUNCAO   - ' GESISFUO-COD-FUNCAO */
                _.Display($"COD FUNCAO   - {GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_COD_FUNCAO}");

                /*" -932- DISPLAY 'ID SIST OPER - ' GESISFUO-IDE-SISTEMA-OPER */
                _.Display($"ID SIST OPER - {GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_IDE_SISTEMA_OPER}");

                /*" -933- DISPLAY 'OPERACAO AC  - ' GESISFUO-COD-OPERACAO */
                _.Display($"OPERACAO AC  - {GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_COD_OPERACAO}");

                /*" -933- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2300-00-SELECT-GESISORL-DB-SELECT-1 */
        public void R2300_00_SELECT_GESISORL_DB_SELECT_1()
        {
            /*" -920- EXEC SQL SELECT COD_OPERACAO_ASS INTO :GESISORL-COD-OPERACAO-ASS FROM SEGUROS.GE_SIS_FUN_OPE_REL WHERE IDE_SISTEMA_FUNCAO = :GESISFUO-IDE-SISTEMA AND COD_FUNCAO = :GESISFUO-COD-FUNCAO AND IDE_SISTEMA_OPER = :GESISFUO-IDE-SISTEMA-OPER AND COD_OPERACAO = :GESISFUO-COD-OPERACAO AND TIPO_ENDOSSO = '9' AND IDE_SISTEMA_FC_ASS = 'AC' AND COD_FUNCAO_ASS IN (02,06) AND IDE_SISTEMA_OP_ASS = 'AC' AND TIPO_ENDOSSO_ASS = '9' END-EXEC. */

            var r2300_00_SELECT_GESISORL_DB_SELECT_1_Query1 = new R2300_00_SELECT_GESISORL_DB_SELECT_1_Query1()
            {
                GESISFUO_IDE_SISTEMA_OPER = GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_IDE_SISTEMA_OPER.ToString(),
                GESISFUO_COD_OPERACAO = GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_COD_OPERACAO.ToString(),
                GESISFUO_IDE_SISTEMA = GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_IDE_SISTEMA.ToString(),
                GESISFUO_COD_FUNCAO = GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_COD_FUNCAO.ToString(),
            };

            var executed_1 = R2300_00_SELECT_GESISORL_DB_SELECT_1_Query1.Execute(r2300_00_SELECT_GESISORL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GESISORL_COD_OPERACAO_ASS, GESISORL.DCLGE_SIS_FUN_OPE_REL.GESISORL_COD_OPERACAO_ASS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-UPDATE-V0COSHISTSIN-SECTION */
        private void R2400_00_UPDATE_V0COSHISTSIN_SECTION()
        {
            /*" -946- MOVE '2400' TO WNR-EXEC-SQL. */
            _.Move("2400", WABEND.WNR_EXEC_SQL);

            /*" -955- PERFORM R2400_00_UPDATE_V0COSHISTSIN_DB_UPDATE_1 */

            R2400_00_UPDATE_V0COSHISTSIN_DB_UPDATE_1();

            /*" -958- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -959- DISPLAY 'R2400 - ERRO NO UPDATE DA V0COSSEG_HISTSIN' */
                _.Display($"R2400 - ERRO NO UPDATE DA V0COSSEG_HISTSIN");

                /*" -960- DISPLAY 'CONGENER - ' V1CHSI-CONGENER */
                _.Display($"CONGENER - {V1CHSI_CONGENER}");

                /*" -961- DISPLAY 'SINISTRO - ' V1CHSI-NUM-SINI */
                _.Display($"SINISTRO - {V1CHSI_NUM_SINI}");

                /*" -962- DISPLAY 'OCR HIST - ' V1CHSI-OCORHIST */
                _.Display($"OCR HIST - {V1CHSI_OCORHIST}");

                /*" -963- DISPLAY 'OPERACAO - ' V1CHSI-OPERACAO */
                _.Display($"OPERACAO - {V1CHSI_OPERACAO}");

                /*" -964- DISPLAY 'DT MOVTO - ' V1CHSI-DTMOVTO */
                _.Display($"DT MOVTO - {V1CHSI_DTMOVTO}");

                /*" -965- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -966- ELSE */
            }
            else
            {


                /*" -966- ADD 1 TO AC-U-V0COSHISTSIN. */
                AREA_DE_WORK.AC_U_V0COSHISTSIN.Value = AREA_DE_WORK.AC_U_V0COSHISTSIN + 1;
            }


        }

        [StopWatch]
        /*" R2400-00-UPDATE-V0COSHISTSIN-DB-UPDATE-1 */
        public void R2400_00_UPDATE_V0COSHISTSIN_DB_UPDATE_1()
        {
            /*" -955- EXEC SQL UPDATE SEGUROS.V0COSSEG_HISTSIN SET SIT_LIBRECUP = '2' , TIMESTAMP = CURRENT TIMESTAMP WHERE CONGENER = :V1CHSI-CONGENER AND NUM_SINISTRO = :V1CHSI-NUM-SINI AND OCORHIST = :V1CHSI-OCORHIST AND DTMOVTO = :V1CHSI-DTMOVTO AND OPERACAO = :V1CHSI-OPERACAO END-EXEC. */

            var r2400_00_UPDATE_V0COSHISTSIN_DB_UPDATE_1_Update1 = new R2400_00_UPDATE_V0COSHISTSIN_DB_UPDATE_1_Update1()
            {
                V1CHSI_CONGENER = V1CHSI_CONGENER.ToString(),
                V1CHSI_NUM_SINI = V1CHSI_NUM_SINI.ToString(),
                V1CHSI_OCORHIST = V1CHSI_OCORHIST.ToString(),
                V1CHSI_OPERACAO = V1CHSI_OPERACAO.ToString(),
                V1CHSI_DTMOVTO = V1CHSI_DTMOVTO.ToString(),
            };

            R2400_00_UPDATE_V0COSHISTSIN_DB_UPDATE_1_Update1.Execute(r2400_00_UPDATE_V0COSHISTSIN_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-INSERT-V0COSHISTSIN-SECTION */
        private void R2500_00_INSERT_V0COSHISTSIN_SECTION()
        {
            /*" -979- MOVE '2500' TO WNR-EXEC-SQL. */
            _.Move("2500", WABEND.WNR_EXEC_SQL);

            /*" -992- PERFORM R2500_00_INSERT_V0COSHISTSIN_DB_INSERT_1 */

            R2500_00_INSERT_V0COSHISTSIN_DB_INSERT_1();

            /*" -995- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -996- DISPLAY 'R2500 - ERRO NO INSERT DA V0COSSEG_HISTSIN' */
                _.Display($"R2500 - ERRO NO INSERT DA V0COSSEG_HISTSIN");

                /*" -997- DISPLAY 'CONGENERE - ' V1CHSI-CONGENER */
                _.Display($"CONGENERE - {V1CHSI_CONGENER}");

                /*" -998- DISPLAY 'SINISTRO  - ' V1CHSI-NUM-SINI */
                _.Display($"SINISTRO  - {V1CHSI_NUM_SINI}");

                /*" -999- DISPLAY 'OCOR HIST - ' V1CHSI-OCORHIST */
                _.Display($"OCOR HIST - {V1CHSI_OCORHIST}");

                /*" -1000- DISPLAY 'OPERACAO  - ' V0CHSI-OPERACAO */
                _.Display($"OPERACAO  - {V0CHSI_OPERACAO}");

                /*" -1001- DISPLAY 'DAT MOVTO - ' V0CHSI-DTMOVTO */
                _.Display($"DAT MOVTO - {V0CHSI_DTMOVTO}");

                /*" -1002- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1003- ELSE */
            }
            else
            {


                /*" -1003- ADD 1 TO AC-I-V0COSHISTSIN. */
                AREA_DE_WORK.AC_I_V0COSHISTSIN.Value = AREA_DE_WORK.AC_I_V0COSHISTSIN + 1;
            }


        }

        [StopWatch]
        /*" R2500-00-INSERT-V0COSHISTSIN-DB-INSERT-1 */
        public void R2500_00_INSERT_V0COSHISTSIN_DB_INSERT_1()
        {
            /*" -992- EXEC SQL INSERT INTO SEGUROS.V0COSSEG_HISTSIN VALUES (:V1CHSI-COD-EMPR , :V1CHSI-CONGENER , :V1CHSI-NUM-SINI , :V1CHSI-OCORHIST , :V0CHSI-OPERACAO , :V0CHSI-DTMOVTO , :V1CHSI-VAL-OPER , CURRENT TIMESTAMP , :V0CHSI-SITUACAO:VIND-SIT-REGT, :V1CHSI-TIPSGU:VIND-TIP-SEGR, :V0CHSI-SIT-LIBREC:VIND-SIT-LIBR) END-EXEC. */

            var r2500_00_INSERT_V0COSHISTSIN_DB_INSERT_1_Insert1 = new R2500_00_INSERT_V0COSHISTSIN_DB_INSERT_1_Insert1()
            {
                V1CHSI_COD_EMPR = V1CHSI_COD_EMPR.ToString(),
                V1CHSI_CONGENER = V1CHSI_CONGENER.ToString(),
                V1CHSI_NUM_SINI = V1CHSI_NUM_SINI.ToString(),
                V1CHSI_OCORHIST = V1CHSI_OCORHIST.ToString(),
                V0CHSI_OPERACAO = V0CHSI_OPERACAO.ToString(),
                V0CHSI_DTMOVTO = V0CHSI_DTMOVTO.ToString(),
                V1CHSI_VAL_OPER = V1CHSI_VAL_OPER.ToString(),
                V0CHSI_SITUACAO = V0CHSI_SITUACAO.ToString(),
                VIND_SIT_REGT = VIND_SIT_REGT.ToString(),
                V1CHSI_TIPSGU = V1CHSI_TIPSGU.ToString(),
                VIND_TIP_SEGR = VIND_TIP_SEGR.ToString(),
                V0CHSI_SIT_LIBREC = V0CHSI_SIT_LIBREC.ToString(),
                VIND_SIT_LIBR = VIND_SIT_LIBR.ToString(),
            };

            R2500_00_INSERT_V0COSHISTSIN_DB_INSERT_1_Insert1.Execute(r2500_00_INSERT_V0COSHISTSIN_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-DELETE-V0RELATORIOS-SECTION */
        private void R3000_00_DELETE_V0RELATORIOS_SECTION()
        {
            /*" -1016- MOVE '3000' TO WNR-EXEC-SQL. */
            _.Move("3000", WABEND.WNR_EXEC_SQL);

            /*" -1024- PERFORM R3000_00_DELETE_V0RELATORIOS_DB_DELETE_1 */

            R3000_00_DELETE_V0RELATORIOS_DB_DELETE_1();

            /*" -1027- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1028- DISPLAY 'R3000 - ERRO NO DELETE DA V0RELATORIOS' */
                _.Display($"R3000 - ERRO NO DELETE DA V0RELATORIOS");

                /*" -1029- DISPLAY 'DATA SOLICITACAO - ' V0SIST-DTMOVABE-AC */
                _.Display($"DATA SOLICITACAO - {V0SIST_DTMOVABE_AC}");

                /*" -1030- DISPLAY 'PERI INICIAL     - ' V0RELA-PERI-INICIAL */
                _.Display($"PERI INICIAL     - {V0RELA_PERI_INICIAL}");

                /*" -1031- DISPLAY 'PERI FINAL       - ' V0RELA-PERI-FINAL */
                _.Display($"PERI FINAL       - {V0RELA_PERI_FINAL}");

                /*" -1032- DISPLAY 'CONGENERE        - ' V0RELA-CONGENER */
                _.Display($"CONGENERE        - {V0RELA_CONGENER}");

                /*" -1033- DISPLAY 'COD EMPRESA      - ' V0RELA-COD-EMPR */
                _.Display($"COD EMPRESA      - {V0RELA_COD_EMPR}");

                /*" -1033- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3000-00-DELETE-V0RELATORIOS-DB-DELETE-1 */
        public void R3000_00_DELETE_V0RELATORIOS_DB_DELETE_1()
        {
            /*" -1024- EXEC SQL DELETE FROM SEGUROS.V0RELATORIOS WHERE CODRELAT = 'AC0004B1' AND DATA_SOLICITACAO = :V0SIST-DTMOVABE-AC AND PERI_INICIAL = :V0RELA-PERI-INICIAL AND PERI_FINAL = :V0RELA-PERI-FINAL AND CONGENER = :V0RELA-CONGENER AND COD_EMPRESA = :V0RELA-COD-EMPR END-EXEC. */

            var r3000_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1 = new R3000_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1()
            {
                V0SIST_DTMOVABE_AC = V0SIST_DTMOVABE_AC.ToString(),
                V0RELA_PERI_INICIAL = V0RELA_PERI_INICIAL.ToString(),
                V0RELA_PERI_FINAL = V0RELA_PERI_FINAL.ToString(),
                V0RELA_CONGENER = V0RELA_CONGENER.ToString(),
                V0RELA_COD_EMPR = V0RELA_COD_EMPR.ToString(),
            };

            R3000_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1.Execute(r3000_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R9900-00-ENCERRA-SEM-MOVTO-SECTION */
        private void R9900_00_ENCERRA_SEM_MOVTO_SECTION()
        {
            /*" -1045- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

            /*" -1046- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -1047- DISPLAY '*   AC0004B - COSSEGURO CEDIDO             *' . */
            _.Display($"*   AC0004B - COSSEGURO CEDIDO             *");

            /*" -1048- DISPLAY '*   -------   ----------------             *' . */
            _.Display($"*   -------   ----------------             *");

            /*" -1049- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -1050- DISPLAY '*    NAO HOUVE MOVIMENTACAO NESTA DATA     *' . */
            _.Display($"*    NAO HOUVE MOVIMENTACAO NESTA DATA     *");

            /*" -1051- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -1051- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1065- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -1067- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -1067- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1071- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1071- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}