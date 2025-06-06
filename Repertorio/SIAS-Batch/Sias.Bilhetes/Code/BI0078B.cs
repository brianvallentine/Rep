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
using Sias.Bilhetes.DB2.BI0078B;

namespace Code
{
    public class BI0078B
    {
        public bool IsCall { get; set; }

        public BI0078B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *  FUNCAO: RENOVACAO DE TITULOS DE CAPITALIZACAO DE BILHETES     *      */
        /*"      *          PRODUTOS DE 8114 A 8123. ESSE PROGRAMA FOI CRIADO     *      */
        /*"      *          PELA NECESSIDADE ESPECIFICA DE RENOVAR OS TITULOS     *      */
        /*"      *          DE CAPITALIZACAO PARA OS CASOS EM QUE OS TITULOS      *      */
        /*"      *          NAO FORAM RENOVADOS NO PERIODO CORRETO (NO MESMO      *      */
        /*"      *          PERIODO DE RENOVACAO DO BILHETE).                     *      */
        /*"      *          A INTENCAO E BUSCAR NA CAP OS TITULOS COM VIGENCIA    *      */
        /*"      *          EXPIRADA E RENOVAR.                                   *      */
        /*"      *          ESTE PROGRAMA PRECISA RODAR DEPOIS DO BI0071B PORQUE  *      */
        /*"      *          DEVE SO PEGAR O QUE NAO FOI RENOVADO PELO BI0071B.    *      */
        /*"      *          ESSE PROGRAMA PODE SER SUSPENSO QUANDO NAO HOUVEREM   *      */
        /*"      *          MAIS ITENS A RENOVAR.                                 *      */
        /*"      *                                         HISTORIA 39487.        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      ******************************************************************      */
        /*"V.07  *  VERSAO 07  - DEMANDA 564.320                                  *      */
        /*"      *             - SUBSTITUIR A CHAMADA DA ROTINA FC0105S DA CAP    *      */
        /*"      *               PELA VG0105S                                     *      */
        /*"      *               E DA SPBFC012 PELA SPBVG012                             */
        /*"      *             - PORQUE A CAP ESTA DEIXANDO O MAINFRAME.          *      */
        /*"      *                                                                *      */
        /*"      *  EM 18/01/2024 - RAUL BASILI ROTTA                             *      */
        /*"      *                                        PROCURE POR V.07        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 06   - DEMANDA 231933                                 *      */
        /*"      *               - SUBSTITUIR AS CHAMADAS DIRETAS NA FDRCAP PELA  *      */
        /*"      *                 SPBFC012.                                      *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/03/2020 - CLAUDETE RADEL     PROCURE POR V.06          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 05   - HISTORIA 196716                               *       */
        /*"      *               - ALTERAR A APLICACAO PARA TRATAMENTO DA NOVA    *      */
        /*"      *                 EMPRESA (JV1) E SEUS PRODUTOS.                 *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/04/2019 - LUIZ FERNANDO      PROCURE POR V.05          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 04 - HISTORIA 178780                                  *      */
        /*"      *             - MUDANCAS DE PRODUTOS ACOPLADOS - CAP             *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/01/2019 - RIBAMAR MARQUES/CLAUDETE                     *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.04         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 03 - MELHORIA DE PERFORMANCE                          *      */
        /*"      *               MELHORIA DE PERFORMANCE DO CURSOR PRINCIPAL.     *      */
        /*"      *                                                                *      */
        /*"      *   EM 24/08/2018 - CLAUDETE RADEL                               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.03         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 02 - INCIDENTE 163608                                 *      */
        /*"      *               SOLUCIONAR ABEND OCORRIDO EM PRODUCAO NA ROTINA  *      */
        /*"      *               DIARIA JPBID02 - TEMPO EXCEDIDO.                 *      */
        /*"      *               FEITA ALTERACAO NO CURSOR PRINCIPAL PARA MELHORIA*      */
        /*"      *               DE PERFORMANCE                                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 10/07/2018 - RIBAMAR MARQUES (ALTRAN)                     *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.02         *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01 SISTEMA-DTMOVABE                PIC  X(010).*/
        public StringBasis SISTEMA_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01 WS-WORK-AREAS.*/
        public BI0078B_WS_WORK_AREAS WS_WORK_AREAS { get; set; } = new BI0078B_WS_WORK_AREAS();
        public class BI0078B_WS_WORK_AREAS : VarBasis
        {
            /*"    05 AC-LIDOS                     PIC  9(006) VALUE  0.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05 AC-GRAVADO                   PIC  9(006) VALUE  0.*/
            public IntBasis AC_GRAVADO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05 AC-DESPREZADO                PIC  9(006) VALUE  0.*/
            public IntBasis AC_DESPREZADO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05 WFIM-BILHETE                 PIC  X(001) VALUE  SPACES.*/
            public StringBasis WFIM_BILHETE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05 WS-DATA-MOVT-10              PIC  X(010) VALUE  SPACES.*/
            public StringBasis WS_DATA_MOVT_10 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    05 WS-IND-CALL                  PIC  9(002) COMP-3.*/
            public IntBasis WS_IND_CALL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    05 WS-QTD-TIT-CAP               PIC  9(004) VALUE ZEROS.*/
            public IntBasis WS_QTD_TIT_CAP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05 TEM-TITULO                   PIC  X(001).*/

            public SelectorBasis TEM_TITULO { get; set; } = new SelectorBasis("001")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88  W88-TEM-TITULO                       VALUE '0'. */
							new SelectorItemBasis("W88_TEM_TITULO", "0"),
							/*" 88  W88-NAO-TEM-TITULO                   VALUE '1'. */
							new SelectorItemBasis("W88_NAO_TEM_TITULO", "1")
                }
            };

            /*"    05 REN-TITULO                   PIC  X(001).*/

            public SelectorBasis REN_TITULO { get; set; } = new SelectorBasis("001")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88  W88-REN-TITULO                       VALUE '0'. */
							new SelectorItemBasis("W88_REN_TITULO", "0"),
							/*" 88  W88-NAO-REN-TITULO                   VALUE '1'. */
							new SelectorItemBasis("W88_NAO_REN_TITULO", "1")
                }
            };

            /*"01 LK-PLANO                        PIC S9(004)      USAGE COMP.*/
        }
        public IntBasis LK_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01 LK-SERIE                        PIC S9(004)      USAGE COMP.*/
        public IntBasis LK_SERIE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01 LK-TITULO                       PIC S9(009)      USAGE COMP.*/
        public IntBasis LK_TITULO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01 LK-NUM-PROPOSTA                 PIC S9(015)V     USAGE COMP-3*/
        public DoubleBasis LK_NUM_PROPOSTA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V"), 0);
        /*"01 LK-QTD-TITULOS                  PIC S9(004)      USAGE COMP.*/
        public IntBasis LK_QTD_TITULOS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01 LK-VLR-TITULO                   PIC S9(008)V9(2) USAGE COMP-3*/
        public DoubleBasis LK_VLR_TITULO { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(008)V9(2)"), 2);
        /*"01 LK-PARCEIRO                     PIC S9(004)      USAGE COMP.*/
        public IntBasis LK_PARCEIRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01 LK-RAMO                         PIC S9(004)      USAGE COMP.*/
        public IntBasis LK_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01 LK-COD-USUARIO                  PIC  X(008).*/
        public StringBasis LK_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"01 LK-NUM-NSA                      PIC S9(004)      USAGE COMP.*/
        public IntBasis LK_NUM_NSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01 LK-TRACE                        PIC  X(009).*/
        public StringBasis LK_TRACE { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
        /*"01 LK-OUT-COD-RETORNO              PIC S9(004) COMP.*/
        public IntBasis LK_OUT_COD_RETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01 LK-OUT-SQLCODE                  PIC S9(004) COMP.*/
        public IntBasis LK_OUT_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01 LK-OUT-MENSAGEM                 PIC  X(070).*/
        public StringBasis LK_OUT_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
        /*"01 LK-OUT-SQLERRMC                 PIC  X(070).*/
        public StringBasis LK_OUT_SQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
        /*"01 LK-OUT-SQLSTATE                 PIC  X(005).*/
        public StringBasis LK_OUT_SQLSTATE { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
        /*"01  LK-NUM-PLANO-FC12              PIC S9(004)  USAGE COMP.*/
        public IntBasis LK_NUM_PLANO_FC12 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-NUM-PROPOSTA-FC12           PIC S9(015)V USAGE COMP-3.*/
        public DoubleBasis LK_NUM_PROPOSTA_FC12 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V"), 0);
        /*"01  LK-COD-RAMO-FC12               PIC S9(004)  USAGE COMP.*/
        public IntBasis LK_COD_RAMO_FC12 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-TRACE-FC12                  PIC  X(009).*/
        public StringBasis LK_TRACE_FC12 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
        /*"01  LK-NUM-PLANO-ED-FC12           PIC  9(009).*/
        public IntBasis LK_NUM_PLANO_ED_FC12 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
        /*"01  LK-NUM-PROPOSTA-ED-FC12        PIC  9(015)V.*/
        public DoubleBasis LK_NUM_PROPOSTA_ED_FC12 { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V."), 0);
        /*"01  LK-COD-RAMO-ED-FC12            PIC  9(009).*/
        public IntBasis LK_COD_RAMO_ED_FC12 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
        /*"01  LK-OUT-COD-RET-FC12            PIC S9(004) COMP.*/
        public IntBasis LK_OUT_COD_RET_FC12 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-OUT-SQLCODE-FC12            PIC S9(004) COMP.*/
        public IntBasis LK_OUT_SQLCODE_FC12 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-OUT-MENSAGEM-FC12           PIC  X(070).*/
        public StringBasis LK_OUT_MENSAGEM_FC12 { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
        /*"01  LK-OUT-SQLERRMC-FC12           PIC  X(070).*/
        public StringBasis LK_OUT_SQLERRMC_FC12 { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
        /*"01  LK-OUT-SQLSTATE-FC12           PIC  X(005).*/
        public StringBasis LK_OUT_SQLSTATE_FC12 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
        /*"01  WF-NUM-PLANO                   PIC S9(004)      USAGE COMP.*/
        public IntBasis WF_NUM_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WF-NUM-SERIE                   PIC S9(004)      USAGE COMP.*/
        public IntBasis WF_NUM_SERIE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WF-NUM-TITULO                  PIC S9(009)            COMP.*/
        public IntBasis WF_NUM_TITULO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  WF-COD-STA-TITULO              PIC  X(003).*/
        public StringBasis WF_COD_STA_TITULO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"01  WF-COD-SUB-STATUS              PIC  X(003).*/
        public StringBasis WF_COD_SUB_STATUS { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"01  WF-DTH-ATIVACAO                PIC  X(026).*/
        public StringBasis WF_DTH_ATIVACAO { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"01  WF-DTH-CADUCACAO               PIC  X(010).*/
        public StringBasis WF_DTH_CADUCACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WF-DTH-CRIACAO                 PIC  X(026).*/
        public StringBasis WF_DTH_CRIACAO { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"01  WF-DTH-FIM-VIGENCIA            PIC  X(010).*/
        public StringBasis WF_DTH_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WF-DTH-INI-SORTEIO             PIC  X(010).*/
        public StringBasis WF_DTH_INI_SORTEIO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WF-DTH-INI-VIGENCIA            PIC  X(010).*/
        public StringBasis WF_DTH_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WF-DTH-SUSPENSAO               PIC  X(010).*/
        public StringBasis WF_DTH_SUSPENSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WF-IND-DV                      PIC S9(004)      USAGE COMP.*/
        public IntBasis WF_IND_DV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WF-VLR-MENSALIDADE             PIC S9(008)V9(2) USAGE COMP-3*/
        public DoubleBasis WF_VLR_MENSALIDADE { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(008)V9(2)"), 2);
        /*"01  WF-NUM-PROPOSTA                PIC S9(015)V     USAGE COMP-3*/
        public DoubleBasis WF_NUM_PROPOSTA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V"), 0);
        /*"01  WF-NUM-MOD-PLANO               PIC S9(004)      USAGE COMP.*/
        public IntBasis WF_NUM_MOD_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WF-DES-COMBINACAO              PIC  X(020).*/
        public StringBasis WF_DES_COMBINACAO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"01  WS-EOF.*/
        public BI0078B_WS_EOF WS_EOF { get; set; } = new BI0078B_WS_EOF();
        public class BI0078B_WS_EOF : VarBasis
        {
            /*"    03  WS-EOF-FD001               PIC  9(001) VALUE ZEROS.*/
            public IntBasis WS_EOF_FD001 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    03  WS-EOF-RESULT              PIC  9(001) VALUE ZEROS.*/
            public IntBasis WS_EOF_RESULT { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"01  WL-LOCATOR     USAGE SQL TYPE IS RESULT-SET-LOCATOR VARYING.*/
        }
        public IntBasis WL_LOCATOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01 WABEND.*/
        public BI0078B_WABEND WABEND { get; set; } = new BI0078B_WABEND();
        public class BI0078B_WABEND : VarBasis
        {
            /*"    05 FILLER                       PIC  X(010)    VALUE       ' BI0078B'.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" BI0078B");
            /*"    05 FILLER                       PIC  X(026)    VALUE       ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"    05 WNR-EXEC-SQL                 PIC  X(004)    VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"    05 FILLER                       PIC  X(013)    VALUE       ' *** SQLCODE '.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"    05 WSQLCODE                     PIC  ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.BILHETE BILHETE { get; set; } = new Dclgens.BILHETE();
        public Dclgens.BILCOBER BILCOBER { get; set; } = new Dclgens.BILCOBER();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.COMFEDCA COMFEDCA { get; set; } = new Dclgens.COMFEDCA();
        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();
        public Dclgens.PARAMGER PARAMGER { get; set; } = new Dclgens.PARAMGER();
        public BI0078B_CBILRENOV CBILRENOV { get; set; } = new BI0078B_CBILRENOV();
        public BI0078B_C01_RESULT C01_RESULT { get; set; } = new BI0078B_C01_RESULT();
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
            /*" -198- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -199- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -200- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -203- DISPLAY '------------------------------------' */
            _.Display($"------------------------------------");

            /*" -204- DISPLAY '   PROGRAMA EM EXECUCAO BI0078B     ' */
            _.Display($"   PROGRAMA EM EXECUCAO BI0078B     ");

            /*" -205- DISPLAY '                                    ' */
            _.Display($"                                    ");

            /*" -207- DISPLAY ' VERSAO V.07 - 564320  18/01/2024   ' */
            _.Display($" VERSAO V.07 - 564320  18/01/2024   ");

            /*" -208- DISPLAY '------------------------------------' . */
            _.Display($"------------------------------------");

            /*" -210- DISPLAY ' ' . */
            _.Display($" ");

            /*" -219- DISPLAY 'INICIOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) ':' FUNCTION CURRENT-DATE(15:2). */

            $"INICIOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}:{_.CurrentDateAsDate():ff}"
            .Display();

            /*" -221- PERFORM R0050-00-SELECT-SISTEMAS. */

            R0050_00_SELECT_SISTEMAS_SECTION();

            /*" -223- PERFORM R0100-00-SELECIONA. */

            R0100_00_SELECIONA_SECTION();

            /*" -225- PERFORM R0200-00-FETCH. */

            R0200_00_FETCH_SECTION();

            /*" -228- PERFORM R0300-00-PROCESSA UNTIL WFIM-BILHETE EQUAL 'S' . */

            while (!(WS_WORK_AREAS.WFIM_BILHETE == "S"))
            {

                R0300_00_PROCESSA_SECTION();
            }

            /*" -229- DISPLAY '** BI0078B ** REG. LIDOS        ' AC-LIDOS */
            _.Display($"** BI0078B ** REG. LIDOS        {WS_WORK_AREAS.AC_LIDOS}");

            /*" -230- DISPLAY '** BI0078B ** REG. DESPREZADO   ' AC-DESPREZADO */
            _.Display($"** BI0078B ** REG. DESPREZADO   {WS_WORK_AREAS.AC_DESPREZADO}");

            /*" -231- DISPLAY '** BI0078B ** REG. GRAVADOS     ' AC-GRAVADO */
            _.Display($"** BI0078B ** REG. GRAVADOS     {WS_WORK_AREAS.AC_GRAVADO}");

            /*" -232- DISPLAY '                                ' . */
            _.Display($"                                ");

            /*" -234- DISPLAY '** BI0078B ** TERMINO NORMAL    ' . */
            _.Display($"** BI0078B ** TERMINO NORMAL    ");

            /*" -236- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -238- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -240- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_FIM*/

        [StopWatch]
        /*" R0050-00-SELECT-SISTEMAS-SECTION */
        private void R0050_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -249- MOVE '0050' TO WNR-EXEC-SQL. */
            _.Move("0050", WABEND.WNR_EXEC_SQL);

            /*" -257- PERFORM R0050_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0050_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -260- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -261- DISPLAY 'BI0078B- PROBLEMAS NO ACESSO A SISTEMAS ' */
                _.Display($"BI0078B- PROBLEMAS NO ACESSO A SISTEMAS ");

                /*" -262- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -262- END-IF. */
            }


        }

        [StopWatch]
        /*" R0050-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0050_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -257- EXEC SQL SELECT DATA_MOV_ABERTO, DATA_MOV_ABERTO - 10 DAYS INTO :SISTEMAS-DATA-MOV-ABERTO, :WS-DATA-MOVT-10 FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'BI' WITH UR END-EXEC. */

            var r0050_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new R0050_00_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0050_00_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(r0050_00_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.WS_DATA_MOVT_10, WS_WORK_AREAS.WS_DATA_MOVT_10);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_00_FIM*/

        [StopWatch]
        /*" R0100-00-SELECIONA-SECTION */
        private void R0100_00_SELECIONA_SECTION()
        {
            /*" -271- MOVE 'R100' TO WNR-EXEC-SQL. */
            _.Move("R100", WABEND.WNR_EXEC_SQL);

            /*" -280- DISPLAY 'INICIOU CURSOR EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) ':' FUNCTION CURRENT-DATE(15:2). */

            $"INICIOU CURSOR EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}:{_.CurrentDateAsDate():ff}"
            .Display();

            /*" -312- PERFORM R0100_00_SELECIONA_DB_DECLARE_1 */

            R0100_00_SELECIONA_DB_DECLARE_1();

            /*" -314- PERFORM R0100_00_SELECIONA_DB_OPEN_1 */

            R0100_00_SELECIONA_DB_OPEN_1();

            /*" -325- DISPLAY 'TERMINOU EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) ':' FUNCTION CURRENT-DATE(15:2). */

            $"TERMINOU EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}:{_.CurrentDateAsDate():ff}"
            .Display();

            /*" -326- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -327- DISPLAY 'R0100 - PROBLEMAS DECLARE (BILHETE)    ' */
                _.Display($"R0100 - PROBLEMAS DECLARE (BILHETE)    ");

                /*" -328- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -328- END-IF. */
            }


        }

        [StopWatch]
        /*" R0100-00-SELECIONA-DB-DECLARE-1 */
        public void R0100_00_SELECIONA_DB_DECLARE_1()
        {
            /*" -312- EXEC SQL DECLARE CBILRENOV CURSOR FOR SELECT DISTINCT B.NUM_BILHETE, C.COD_PRODUTO, C.VAL_MAX_COBER_BAS, G.COD_EMPRESA_CAP FROM SEGUROS.COMUNIC_FED_CAP_VA A JOIN SEGUROS.BILHETE B ON B.NUM_BILHETE = A.NUM_CERTIFICADO JOIN SEGUROS.BILHETE_COBERTURA C ON C.RAMO_COBERTURA = B.RAMO AND C.COD_OPCAO_PLANO = B.OPC_COBERTURA JOIN SEGUROS.ENDOSSOS E ON E.NUM_APOLICE = B.NUM_APOLICE JOIN SEGUROS.PRODUTO F ON F.COD_PRODUTO = C.COD_PRODUTO JOIN SEGUROS.PARAMETROS_GERAIS G ON G.COD_EMPRESA = F.COD_EMPRESA WHERE A.DATA_MOVIMENTO + 1 YEAR BETWEEN :WS-DATA-MOVT-10 AND :SISTEMAS-DATA-MOV-ABERTO AND A.DATA_MOVIMENTO = (SELECT MAX(V.DATA_MOVIMENTO) FROM SEGUROS.COMUNIC_FED_CAP_VA V WHERE V.NUM_CERTIFICADO = A.NUM_CERTIFICADO) AND B.SITUACAO = '9' AND C.MODALI_COBERTURA = 0 AND ((C.COD_PRODUTO BETWEEN 8114 AND 8123) OR (C.COD_PRODUTO BETWEEN 5714 AND 5723)) AND C.DATA_TERVIGENCIA > :SISTEMAS-DATA-MOV-ABERTO AND E.NUM_ENDOSSO = 0 AND E.DATA_TERVIGENCIA > :SISTEMAS-DATA-MOV-ABERTO WITH UR END-EXEC. */
            CBILRENOV = new BI0078B_CBILRENOV(true);
            string GetQuery_CBILRENOV()
            {
                var query = @$"SELECT DISTINCT 
							B.NUM_BILHETE
							, 
							C.COD_PRODUTO
							, 
							C.VAL_MAX_COBER_BAS
							, 
							G.COD_EMPRESA_CAP 
							FROM SEGUROS.COMUNIC_FED_CAP_VA A 
							JOIN SEGUROS.BILHETE B 
							ON B.NUM_BILHETE = A.NUM_CERTIFICADO 
							JOIN SEGUROS.BILHETE_COBERTURA C 
							ON C.RAMO_COBERTURA = B.RAMO 
							AND C.COD_OPCAO_PLANO = B.OPC_COBERTURA 
							JOIN SEGUROS.ENDOSSOS E 
							ON E.NUM_APOLICE = B.NUM_APOLICE 
							JOIN SEGUROS.PRODUTO F 
							ON F.COD_PRODUTO = C.COD_PRODUTO 
							JOIN SEGUROS.PARAMETROS_GERAIS G 
							ON G.COD_EMPRESA = F.COD_EMPRESA 
							WHERE A.DATA_MOVIMENTO + 1 YEAR BETWEEN 
							'{WS_WORK_AREAS.WS_DATA_MOVT_10}' AND '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND A.DATA_MOVIMENTO = 
							(SELECT MAX(V.DATA_MOVIMENTO) 
							FROM SEGUROS.COMUNIC_FED_CAP_VA V 
							WHERE V.NUM_CERTIFICADO = A.NUM_CERTIFICADO) 
							AND B.SITUACAO = '9' 
							AND C.MODALI_COBERTURA = 0 
							AND ((C.COD_PRODUTO BETWEEN 8114 AND 8123) OR 
							(C.COD_PRODUTO BETWEEN 5714 AND 5723)) 
							AND C.DATA_TERVIGENCIA > '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND E.NUM_ENDOSSO = 0 
							AND E.DATA_TERVIGENCIA > '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}'";

                return query;
            }
            CBILRENOV.GetQueryEvent += GetQuery_CBILRENOV;

        }

        [StopWatch]
        /*" R0100-00-SELECIONA-DB-OPEN-1 */
        public void R0100_00_SELECIONA_DB_OPEN_1()
        {
            /*" -314- EXEC SQL OPEN CBILRENOV END-EXEC. */

            CBILRENOV.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_FIM*/

        [StopWatch]
        /*" R0200-00-FETCH-SECTION */
        private void R0200_00_FETCH_SECTION()
        {
            /*" -337- MOVE 'R200' TO WNR-EXEC-SQL. */
            _.Move("R200", WABEND.WNR_EXEC_SQL);

            /*" -343- PERFORM R0200_00_FETCH_DB_FETCH_1 */

            R0200_00_FETCH_DB_FETCH_1();

            /*" -346- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -346- PERFORM R0200_00_FETCH_DB_CLOSE_1 */

                R0200_00_FETCH_DB_CLOSE_1();

                /*" -348- MOVE 'S' TO WFIM-BILHETE */
                _.Move("S", WS_WORK_AREAS.WFIM_BILHETE);

                /*" -349- GO TO R0200-99-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_FIM*/ //GOTO
                return;

                /*" -351- END-IF. */
            }


            /*" -352- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -353- DISPLAY 'R0200 - PROBLEMAS FETCH   (BILHETE)    ' */
                _.Display($"R0200 - PROBLEMAS FETCH   (BILHETE)    ");

                /*" -354- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -356- END-IF. */
            }


            /*" -356- ADD 1 TO AC-LIDOS. */
            WS_WORK_AREAS.AC_LIDOS.Value = WS_WORK_AREAS.AC_LIDOS + 1;

        }

        [StopWatch]
        /*" R0200-00-FETCH-DB-FETCH-1 */
        public void R0200_00_FETCH_DB_FETCH_1()
        {
            /*" -343- EXEC SQL FETCH CBILRENOV INTO :BILHETE-NUM-BILHETE ,:BILCOBER-COD-PRODUTO ,:BILCOBER-VAL-MAX-COBER-BAS ,:PARAMGER-COD-EMPRESA-CAP END-EXEC. */

            if (CBILRENOV.Fetch())
            {
                _.Move(CBILRENOV.BILHETE_NUM_BILHETE, BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE);
                _.Move(CBILRENOV.BILCOBER_COD_PRODUTO, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_PRODUTO);
                _.Move(CBILRENOV.BILCOBER_VAL_MAX_COBER_BAS, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_VAL_MAX_COBER_BAS);
                _.Move(CBILRENOV.PARAMGER_COD_EMPRESA_CAP, PARAMGER.DCLPARAMETROS_GERAIS.PARAMGER_COD_EMPRESA_CAP);
            }

        }

        [StopWatch]
        /*" R0200-00-FETCH-DB-CLOSE-1 */
        public void R0200_00_FETCH_DB_CLOSE_1()
        {
            /*" -346- EXEC SQL CLOSE CBILRENOV END-EXEC */

            CBILRENOV.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_FIM*/

        [StopWatch]
        /*" R0300-00-PROCESSA-SECTION */
        private void R0300_00_PROCESSA_SECTION()
        {
            /*" -365- MOVE 'R0300' TO WNR-EXEC-SQL. */
            _.Move("R0300", WABEND.WNR_EXEC_SQL);

            /*" -367- SET W88-NAO-REN-TITULO TO TRUE. */
            WS_WORK_AREAS.REN_TITULO["W88_NAO_REN_TITULO"] = true;

            /*" -369- PERFORM R1500-00-CHAMA-SPBFC012. */

            R1500_00_CHAMA_SPBFC012_SECTION();

            /*" -370- IF W88-REN-TITULO */

            if (WS_WORK_AREAS.REN_TITULO["W88_REN_TITULO"])
            {

                /*" -371- PERFORM R1400-00-INSERT-COMFEDCA */

                R1400_00_INSERT_COMFEDCA_SECTION();

                /*" -373- END-IF. */
            }


            /*" -375- ADD 1 TO AC-GRAVADO. */
            WS_WORK_AREAS.AC_GRAVADO.Value = WS_WORK_AREAS.AC_GRAVADO + 1;

            /*" -375- PERFORM R0200-00-FETCH. */

            R0200_00_FETCH_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-INSERT-MOVFEDCA-SECTION */
        private void R1300_00_INSERT_MOVFEDCA_SECTION()
        {
            /*" -386- MOVE '1300' TO WNR-EXEC-SQL. */
            _.Move("1300", WABEND.WNR_EXEC_SQL);

            /*" -402- INITIALIZE LK-PLANO LK-SERIE LK-TITULO LK-NUM-PROPOSTA LK-QTD-TITULOS LK-VLR-TITULO LK-PARCEIRO LK-COD-USUARIO LK-RAMO LK-TRACE LK-OUT-COD-RETORNO LK-OUT-SQLCODE LK-OUT-MENSAGEM LK-OUT-SQLERRMC LK-OUT-SQLSTATE. */
            _.Initialize(
                LK_PLANO
                , LK_SERIE
                , LK_TITULO
                , LK_NUM_PROPOSTA
                , LK_QTD_TITULOS
                , LK_VLR_TITULO
                , LK_PARCEIRO
                , LK_COD_USUARIO
                , LK_RAMO
                , LK_TRACE
                , LK_OUT_COD_RETORNO
                , LK_OUT_SQLCODE
                , LK_OUT_MENSAGEM
                , LK_OUT_SQLERRMC
                , LK_OUT_SQLSTATE
            );

            /*" -403- MOVE 'BI0078B' TO LK-COD-USUARIO. */
            _.Move("BI0078B", LK_COD_USUARIO);

            /*" -404- MOVE BILHETE-NUM-BILHETE TO LK-NUM-PROPOSTA. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE, LK_NUM_PROPOSTA);

            /*" -405- MOVE WF-NUM-PLANO TO LK-PLANO. */
            _.Move(WF_NUM_PLANO, LK_PLANO);

            /*" -406- MOVE BILCOBER-VAL-MAX-COBER-BAS TO LK-VLR-TITULO. */
            _.Move(BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_VAL_MAX_COBER_BAS, LK_VLR_TITULO);

            /*" -407- MOVE PARAMGER-COD-EMPRESA-CAP TO LK-PARCEIRO. */
            _.Move(PARAMGER.DCLPARAMETROS_GERAIS.PARAMGER_COD_EMPRESA_CAP, LK_PARCEIRO);

            /*" -408- MOVE 'TRACE OFF' TO LK-TRACE. */
            _.Move("TRACE OFF", LK_TRACE);

            /*" -409- MOVE ZEROS TO LK-NUM-NSA. */
            _.Move(0, LK_NUM_NSA);

            /*" -410- MOVE WF-NUM-SERIE TO LK-SERIE. */
            _.Move(WF_NUM_SERIE, LK_SERIE);

            /*" -413- MOVE WF-NUM-TITULO TO LK-TITULO. */
            _.Move(WF_NUM_TITULO, LK_TITULO);

            /*" -431- CALL 'VG0105S' USING LK-PLANO , LK-SERIE , LK-TITULO , LK-NUM-PROPOSTA , LK-QTD-TITULOS , LK-VLR-TITULO , LK-PARCEIRO , LK-RAMO , LK-COD-USUARIO , LK-NUM-NSA , LK-TRACE , LK-OUT-COD-RETORNO , LK-OUT-SQLCODE , LK-OUT-MENSAGEM , LK-OUT-SQLERRMC , LK-OUT-SQLSTATE. */
            _.Call("VG0105S", LK_PLANO, LK_SERIE, LK_TITULO, LK_NUM_PROPOSTA, LK_QTD_TITULOS, LK_VLR_TITULO, LK_PARCEIRO, LK_RAMO, LK_COD_USUARIO, LK_NUM_NSA, LK_TRACE, LK_OUT_COD_RETORNO, LK_OUT_SQLCODE, LK_OUT_MENSAGEM, LK_OUT_SQLERRMC, LK_OUT_SQLSTATE);

            /*" -432- IF LK-OUT-COD-RETORNO NOT EQUAL ZEROS */

            if (LK_OUT_COD_RETORNO != 00)
            {

                /*" -451- DISPLAY 'PROBLEMAS NO ACESSO A VG0105S ' ' ' BILHETE-NUM-BILHETE ' ' LK-PLANO ' ' LK-SERIE ' ' LK-TITULO ' ' LK-NUM-PROPOSTA ' ' LK-QTD-TITULOS ' ' LK-VLR-TITULO ' ' LK-PARCEIRO ' ' LK-RAMO ' ' LK-COD-USUARIO ' ' LK-NUM-NSA ' ' LK-TRACE ' ' LK-OUT-COD-RETORNO ' ' LK-OUT-SQLCODE ' ' LK-OUT-MENSAGEM ' ' LK-OUT-SQLERRMC ' ' LK-OUT-SQLSTATE */

                $"PROBLEMAS NO ACESSO A VG0105S  {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE} {LK_PLANO} {LK_SERIE} {LK_TITULO} {LK_NUM_PROPOSTA} {LK_QTD_TITULOS} {LK_VLR_TITULO} {LK_PARCEIRO} {LK_RAMO} {LK_COD_USUARIO} {LK_NUM_NSA} {LK_TRACE} {LK_OUT_COD_RETORNO} {LK_OUT_SQLCODE} {LK_OUT_MENSAGEM} {LK_OUT_SQLERRMC} {LK_OUT_SQLSTATE}"
                .Display();

                /*" -452- IF LK-OUT-COD-RETORNO EQUAL 98 OR 99 */

                if (LK_OUT_COD_RETORNO.In("98", "99"))
                {

                    /*" -453- ADD 1 TO AC-DESPREZADO */
                    WS_WORK_AREAS.AC_DESPREZADO.Value = WS_WORK_AREAS.AC_DESPREZADO + 1;

                    /*" -454- ELSE */
                }
                else
                {


                    /*" -455- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -456- END-IF */
                }


                /*" -457- ELSE */
            }
            else
            {


                /*" -458- DISPLAY 'BILHETE ' LK-NUM-PROPOSTA ' RENOVADO' */

                $"BILHETE {LK_NUM_PROPOSTA} RENOVADO"
                .Display();

                /*" -459- SET W88-REN-TITULO TO TRUE */
                WS_WORK_AREAS.REN_TITULO["W88_REN_TITULO"] = true;

                /*" -459- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-INSERT-COMFEDCA-SECTION */
        private void R1400_00_INSERT_COMFEDCA_SECTION()
        {
            /*" -469- MOVE '1400' TO WNR-EXEC-SQL. */
            _.Move("1400", WABEND.WNR_EXEC_SQL);

            /*" -480- PERFORM R1400_00_INSERT_COMFEDCA_DB_INSERT_1 */

            R1400_00_INSERT_COMFEDCA_DB_INSERT_1();

            /*" -483- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -484- DISPLAY 'R1400 - ERRO NO INSERT DA COMFEDCA' */
                _.Display($"R1400 - ERRO NO INSERT DA COMFEDCA");

                /*" -485- DISPLAY 'BILHETE ' BILHETE-NUM-BILHETE */
                _.Display($"BILHETE {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

                /*" -486- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -486- END-IF. */
            }


        }

        [StopWatch]
        /*" R1400-00-INSERT-COMFEDCA-DB-INSERT-1 */
        public void R1400_00_INSERT_COMFEDCA_DB_INSERT_1()
        {
            /*" -480- EXEC SQL INSERT INTO SEGUROS.COMUNIC_FED_CAP_VA ( NUM_CERTIFICADO, SITUACAO , DATA_MOVIMENTO , TIMESTAMP ) VALUES (:BILHETE-NUM-BILHETE, 'R' , CURRENT DATE , CURRENT TIMESTAMP ) END-EXEC. */

            var r1400_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1 = new R1400_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1()
            {
                BILHETE_NUM_BILHETE = BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE.ToString(),
            };

            R1400_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1.Execute(r1400_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-CHAMA-SPBFC012-SECTION */
        private void R1500_00_CHAMA_SPBFC012_SECTION()
        {
            /*" -496- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", WABEND.WNR_EXEC_SQL);

            /*" -518- INITIALIZE WF-NUM-PLANO , WF-NUM-SERIE , WF-NUM-TITULO , WF-COD-STA-TITULO , WF-COD-SUB-STATUS , WF-DTH-ATIVACAO , WF-DTH-CADUCACAO , WF-DTH-CRIACAO , WF-DTH-FIM-VIGENCIA , WF-DTH-INI-SORTEIO , WF-DTH-INI-VIGENCIA , WF-DTH-SUSPENSAO , WF-IND-DV , WF-VLR-MENSALIDADE , WF-NUM-PROPOSTA , WF-NUM-MOD-PLANO , LK-OUT-COD-RET-FC12 , LK-OUT-SQLCODE-FC12 , LK-OUT-MENSAGEM-FC12 , LK-OUT-SQLERRMC-FC12 , LK-OUT-SQLSTATE-FC12 */
            _.Initialize(
                WF_NUM_PLANO
                , WF_NUM_SERIE
                , WF_NUM_TITULO
                , WF_COD_STA_TITULO
                , WF_COD_SUB_STATUS
                , WF_DTH_ATIVACAO
                , WF_DTH_CADUCACAO
                , WF_DTH_CRIACAO
                , WF_DTH_FIM_VIGENCIA
                , WF_DTH_INI_SORTEIO
                , WF_DTH_INI_VIGENCIA
                , WF_DTH_SUSPENSAO
                , WF_IND_DV
                , WF_VLR_MENSALIDADE
                , WF_NUM_PROPOSTA
                , WF_NUM_MOD_PLANO
                , LK_OUT_COD_RET_FC12
                , LK_OUT_SQLCODE_FC12
                , LK_OUT_MENSAGEM_FC12
                , LK_OUT_SQLERRMC_FC12
                , LK_OUT_SQLSTATE_FC12
            );

            /*" -519- MOVE 858 TO LK-NUM-PLANO-FC12 */
            _.Move(858, LK_NUM_PLANO_FC12);

            /*" -520- MOVE BILCOBER-COD-PRODUTO TO LK-COD-RAMO-FC12 */
            _.Move(BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_PRODUTO, LK_COD_RAMO_FC12);

            /*" -521- MOVE BILHETE-NUM-BILHETE TO LK-NUM-PROPOSTA-FC12 */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE, LK_NUM_PROPOSTA_FC12);

            /*" -524- MOVE 'TRACE OFF' TO LK-TRACE-FC12 */
            _.Move("TRACE OFF", LK_TRACE_FC12);

            /*" -536- PERFORM R1500_00_CHAMA_SPBFC012_DB_CALL_1 */

            R1500_00_CHAMA_SPBFC012_DB_CALL_1();

            /*" -539- IF SQLCODE NOT = 000 AND +466 */

            if (!DB.SQLCODE.In("000", "+466"))
            {

                /*" -542- DISPLAY 'ERRO NA CONSULTA - SPBVG012 - ' ' COD-RET <' LK-OUT-COD-RET-FC12 '>' ' SQLCODE <' LK-OUT-SQLCODE-FC12 '>' */

                $"ERRO NA CONSULTA - SPBVG012 -  COD-RET <{LK_OUT_COD_RET_FC12}> SQLCODE <{LK_OUT_SQLCODE_FC12}>"
                .Display();

                /*" -547- DISPLAY ' BILHETE <' BILHETE-NUM-BILHETE '/' LK-OUT-COD-RET-FC12 '/' LK-OUT-MENSAGEM-FC12 '/' LK-OUT-SQLERRMC-FC12 '/' LK-OUT-SQLSTATE-FC12 '>' */

                $" BILHETE <{BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}/{LK_OUT_COD_RET_FC12}/{LK_OUT_MENSAGEM_FC12}/{LK_OUT_SQLERRMC_FC12}/{LK_OUT_SQLSTATE_FC12}>"
                .Display();

                /*" -548- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -550- END-IF */
            }


            /*" -551- IF LK-OUT-COD-RET-FC12 EQUAL ZEROS */

            if (LK_OUT_COD_RET_FC12 == 00)
            {

                /*" -552- SET W88-TEM-TITULO TO TRUE */
                WS_WORK_AREAS.TEM_TITULO["W88_TEM_TITULO"] = true;

                /*" -553- MOVE ZEROS TO WS-EOF-RESULT */
                _.Move(0, WS_EOF.WS_EOF_RESULT);

                /*" -554- MOVE ZEROS TO WS-QTD-TIT-CAP */
                _.Move(0, WS_WORK_AREAS.WS_QTD_TIT_CAP);

                /*" -555- IF SQLCODE = +466 */

                if (DB.SQLCODE == +466)
                {

                    /*" -556- PERFORM R1600-TRATAR-RESULT */

                    R1600_TRATAR_RESULT_SECTION();

                    /*" -558- PERFORM R1700-LER-RESULT UNTIL WS-EOF-RESULT NOT EQUAL ZEROES */

                    while (!(WS_EOF.WS_EOF_RESULT != 00))
                    {

                        R1700_LER_RESULT_SECTION();
                    }

                    /*" -559- PERFORM R1800-FECHAR-CURSOR */

                    R1800_FECHAR_CURSOR_SECTION();

                    /*" -560- ELSE */
                }
                else
                {


                    /*" -562- DISPLAY 'SQLCODE EXEC: ' SQLCODE ' / ' BILHETE-NUM-BILHETE */

                    $"SQLCODE EXEC: {DB.SQLCODE} / {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}"
                    .Display();

                    /*" -563- END-IF */
                }


                /*" -563- END-IF. */
            }


        }

        [StopWatch]
        /*" R1500-00-CHAMA-SPBFC012-DB-CALL-1 */
        public void R1500_00_CHAMA_SPBFC012_DB_CALL_1()
        {
            /*" -536- EXEC SQL CALL SEGUROS.SPBVG012 ( :LK-NUM-PLANO-FC12 , :LK-NUM-PROPOSTA-FC12 , :LK-COD-RAMO-FC12 , :LK-TRACE-FC12 , :LK-OUT-COD-RET-FC12 , :LK-OUT-SQLCODE-FC12 , :LK-OUT-MENSAGEM-FC12 , :LK-OUT-SQLERRMC-FC12 , :LK-OUT-SQLSTATE-FC12 ) END-EXEC */

            var sEGUROS_SPBVG012_Call1 = new SEGUROS_SPBVG012_Call1()
            {
                LK_NUM_PLANO_FC12 = LK_NUM_PLANO_FC12.ToString(),
                LK_NUM_PROPOSTA_FC12 = LK_NUM_PROPOSTA_FC12.ToString(),
                LK_COD_RAMO_FC12 = LK_COD_RAMO_FC12.ToString(),
                LK_TRACE_FC12 = LK_TRACE_FC12.ToString(),
                LK_OUT_COD_RET_FC12 = LK_OUT_COD_RET_FC12.ToString(),
                LK_OUT_SQLCODE_FC12 = LK_OUT_SQLCODE_FC12.ToString(),
                LK_OUT_MENSAGEM_FC12 = LK_OUT_MENSAGEM_FC12.ToString(),
                LK_OUT_SQLERRMC_FC12 = LK_OUT_SQLERRMC_FC12.ToString(),
                LK_OUT_SQLSTATE_FC12 = LK_OUT_SQLSTATE_FC12.ToString(),
            };

            var executed_1 = SEGUROS_SPBVG012_Call1.Execute(sEGUROS_SPBVG012_Call1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LK_NUM_PLANO_FC12, LK_NUM_PLANO_FC12);
                _.Move(executed_1.LK_NUM_PROPOSTA_FC12, LK_NUM_PROPOSTA_FC12);
                _.Move(executed_1.LK_COD_RAMO_FC12, LK_COD_RAMO_FC12);
                _.Move(executed_1.LK_TRACE_FC12, LK_TRACE_FC12);
                _.Move(executed_1.LK_OUT_COD_RET_FC12, LK_OUT_COD_RET_FC12);
                _.Move(executed_1.LK_OUT_SQLCODE_FC12, LK_OUT_SQLCODE_FC12);
                _.Move(executed_1.LK_OUT_MENSAGEM_FC12, LK_OUT_MENSAGEM_FC12);
                _.Move(executed_1.LK_OUT_SQLERRMC_FC12, LK_OUT_SQLERRMC_FC12);
                _.Move(executed_1.LK_OUT_SQLSTATE_FC12, LK_OUT_SQLSTATE_FC12);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1600-TRATAR-RESULT-SECTION */
        private void R1600_TRATAR_RESULT_SECTION()
        {
            /*" -574- MOVE '1600' TO WNR-EXEC-SQL. */
            _.Move("1600", WABEND.WNR_EXEC_SQL);

            /*" -578- EXEC SQL ASSOCIATE LOCATORS (:WL-LOCATOR) WITH PROCEDURE SEGUROS.SPBVG012 END-EXEC */
            /*-Linha desconsiderada por ser -inútil- no .NET por segurança adicionado SQLCODE = 0*/
            DB.SQLCODE.Value = 0;

            /*" -581- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -583- DISPLAY 'ERRO NO P1901 - SPBVG012 - ' ' SQLCODE <' SQLCODE '>' */

                $"ERRO NO P1901 - SPBVG012 -  SQLCODE <{DB.SQLCODE}>"
                .Display();

                /*" -584- DISPLAY ' PROPOST <' BILHETE-NUM-BILHETE '>' */

                $" PROPOST <{BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}>"
                .Display();

                /*" -585- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -587- END-IF */
            }


            /*" -590- EXEC SQL ALLOCATE C01-RESULT CURSOR FOR RESULT SET :WL-LOCATOR END-EXEC */
            C01_RESULT.Allocate($"SEGUROS.SPBVG012");

            /*" -591- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1700-LER-RESULT-SECTION */
        private void R1700_LER_RESULT_SECTION()
        {
            /*" -598- MOVE '1700' TO WNR-EXEC-SQL. */
            _.Move("1700", WABEND.WNR_EXEC_SQL);

            /*" -617- PERFORM R1700_LER_RESULT_DB_FETCH_1 */

            R1700_LER_RESULT_DB_FETCH_1();

            /*" -620- IF SQLCODE NOT EQUAL ZEROES AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -622- DISPLAY 'ERRO CURSOR <C01-RESULT> SQLCODE <' SQLCODE '>' */

                $"ERRO CURSOR <C01-RESULT> SQLCODE <{DB.SQLCODE}>"
                .Display();

                /*" -623- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -624- ELSE */
            }
            else
            {


                /*" -625- IF SQLCODE EQUAL ZEROES */

                if (DB.SQLCODE == 00)
                {

                    /*" -629- IF WF-DTH-FIM-VIGENCIA >= WS-DATA-MOVT-10 AND WF-DTH-FIM-VIGENCIA <= SISTEMAS-DATA-MOV-ABERTO */

                    if (WF_DTH_FIM_VIGENCIA >= WS_WORK_AREAS.WS_DATA_MOVT_10 && WF_DTH_FIM_VIGENCIA <= SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO)
                    {

                        /*" -630- ADD 1 TO WS-QTD-TIT-CAP */
                        WS_WORK_AREAS.WS_QTD_TIT_CAP.Value = WS_WORK_AREAS.WS_QTD_TIT_CAP + 1;

                        /*" -631- PERFORM R1300-00-INSERT-MOVFEDCA */

                        R1300_00_INSERT_MOVFEDCA_SECTION();

                        /*" -632- END-IF */
                    }


                    /*" -633- ELSE */
                }
                else
                {


                    /*" -636- IF SQLCODE EQUAL +100 AND WS-QTD-TIT-CAP EQUAL ZEROS */

                    if (DB.SQLCODE == +100 && WS_WORK_AREAS.WS_QTD_TIT_CAP == 00)
                    {

                        /*" -639- DISPLAY 'NENHUM TITULO ENCONTRADO PARA A PROPOSTA <' WF-NUM-PLANO '/' BILHETE-NUM-BILHETE '/' BILCOBER-COD-PRODUTO */

                        $"NENHUM TITULO ENCONTRADO PARA A PROPOSTA <{WF_NUM_PLANO}/{BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}/{BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_PRODUTO}"
                        .Display();

                        /*" -640- SET W88-NAO-TEM-TITULO TO TRUE */
                        WS_WORK_AREAS.TEM_TITULO["W88_NAO_TEM_TITULO"] = true;

                        /*" -641- MOVE 1 TO WS-EOF-RESULT */
                        _.Move(1, WS_EOF.WS_EOF_RESULT);

                        /*" -643- END-IF */
                    }


                    /*" -650- IF SQLCODE EQUAL +100 AND WS-QTD-TIT-CAP > ZEROS */

                    if (DB.SQLCODE == +100 && WS_WORK_AREAS.WS_QTD_TIT_CAP > 00)
                    {

                        /*" -651- MOVE 1 TO WS-EOF-RESULT */
                        _.Move(1, WS_EOF.WS_EOF_RESULT);

                        /*" -652- END-IF */
                    }


                    /*" -653- END-IF */
                }


                /*" -654- END-IF */
            }


            /*" -654- . */

        }

        [StopWatch]
        /*" R1700-LER-RESULT-DB-FETCH-1 */
        public void R1700_LER_RESULT_DB_FETCH_1()
        {
            /*" -617- EXEC SQL FETCH C01-RESULT INTO :WF-NUM-PLANO , :WF-NUM-SERIE , :WF-NUM-TITULO , :WF-COD-STA-TITULO , :WF-COD-SUB-STATUS , :WF-DTH-ATIVACAO , :WF-DTH-CADUCACAO , :WF-DTH-CRIACAO , :WF-DTH-FIM-VIGENCIA , :WF-DTH-INI-SORTEIO , :WF-DTH-INI-VIGENCIA , :WF-DTH-SUSPENSAO , :WF-IND-DV , :WF-VLR-MENSALIDADE , :WF-NUM-PROPOSTA , :WF-NUM-MOD-PLANO , :WF-DES-COMBINACAO END-EXEC */

            if (C01_RESULT.Fetch())
            {
                _.Move(C01_RESULT.WF_NUM_PLANO, WF_NUM_PLANO);
                _.Move(C01_RESULT.WF_NUM_SERIE, WF_NUM_SERIE);
                _.Move(C01_RESULT.WF_NUM_TITULO, WF_NUM_TITULO);
                _.Move(C01_RESULT.WF_COD_STA_TITULO, WF_COD_STA_TITULO);
                _.Move(C01_RESULT.WF_COD_SUB_STATUS, WF_COD_SUB_STATUS);
                _.Move(C01_RESULT.WF_DTH_ATIVACAO, WF_DTH_ATIVACAO);
                _.Move(C01_RESULT.WF_DTH_CADUCACAO, WF_DTH_CADUCACAO);
                _.Move(C01_RESULT.WF_DTH_CRIACAO, WF_DTH_CRIACAO);
                _.Move(C01_RESULT.WF_DTH_FIM_VIGENCIA, WF_DTH_FIM_VIGENCIA);
                _.Move(C01_RESULT.WF_DTH_INI_SORTEIO, WF_DTH_INI_SORTEIO);
                _.Move(C01_RESULT.WF_DTH_INI_VIGENCIA, WF_DTH_INI_VIGENCIA);
                _.Move(C01_RESULT.WF_DTH_SUSPENSAO, WF_DTH_SUSPENSAO);
                _.Move(C01_RESULT.WF_IND_DV, WF_IND_DV);
                _.Move(C01_RESULT.WF_VLR_MENSALIDADE, WF_VLR_MENSALIDADE);
                _.Move(C01_RESULT.WF_NUM_PROPOSTA, WF_NUM_PROPOSTA);
                _.Move(C01_RESULT.WF_NUM_MOD_PLANO, WF_NUM_MOD_PLANO);
                _.Move(C01_RESULT.WF_DES_COMBINACAO, WF_DES_COMBINACAO);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/

        [StopWatch]
        /*" R1800-FECHAR-CURSOR-SECTION */
        private void R1800_FECHAR_CURSOR_SECTION()
        {
            /*" -662- MOVE '1800' TO WNR-EXEC-SQL. */
            _.Move("1800", WABEND.WNR_EXEC_SQL);

            /*" -662- PERFORM R1800_FECHAR_CURSOR_DB_CLOSE_1 */

            R1800_FECHAR_CURSOR_DB_CLOSE_1();

            /*" -665- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -667- DISPLAY 'R9160 - ERRO NO CLOSE DO CURSOR <C01-RESULT> ' 'SQLCODE <' SQLCODE '>' */

                $"R9160 - ERRO NO CLOSE DO CURSOR <C01-RESULT> SQLCODE <{DB.SQLCODE}>"
                .Display();

                /*" -668- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -668- END-IF. */
            }


        }

        [StopWatch]
        /*" R1800-FECHAR-CURSOR-DB-CLOSE-1 */
        public void R1800_FECHAR_CURSOR_DB_CLOSE_1()
        {
            /*" -662- EXEC SQL CLOSE C01-RESULT END-EXEC */

            C01_RESULT.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1800_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -677- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -679- DISPLAY WABEND */
            _.Display(WABEND);

            /*" -681- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -685- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -685- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}