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
using Sias.VidaAzul.DB2.VA0061B;

namespace Code
{
    public class VA0061B
    {
        public bool IsCall { get; set; }

        public VA0061B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SIAS - Sem SSI                     *      */
        /*"      *   PROGRAMA ...............  VA0061B                            *      */
        /*"      *   ANALISTA ...............  LUCIA FREIRE                       *      */
        /*"      *   DATA CODIFICACAO .......  20 / setembro/ 2006                *      */
        /*"      *   FUNCAO .................  Deletar da tabela ERROS_PROPVIDAZUL*      */
        /*"      *                             CERTIFICADOS COM ERRO 508          *      */
        /*"      *                                            regras descritas    *      */
        /*"      *                                            no pgm PF0601B.     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.02  *   VERSAO 02 - DEMANDA 402.982                                  *      */
        /*"      *             - RETIRAR GRAVACAO DE ERROS DA PROPOSTA DA TABELA  *      */
        /*"      *               ERROS_PROP_VIDAZUL                               *      */
        /*"      *             - GRAVAR ERROS DA PROPOSTA NA NOVA TABELA          *      */
        /*"      *               VG_CRITICA_PROPOSTA PARA POSTERIOR ANALISE DO    *      */
        /*"      *               GESTOR NO ATALHO 04.23                           *      */
        /*"      *                                                                *      */
        /*"      *   EM 14/02/2023 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                        PROCURE POR V.02        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 01 - CAD 10.003                                       *      */
        /*"      *                                                                *      */
        /*"      *              - CONVERSAO DO DB2 PARA A VERSAO 10               *      */
        /*"      *                                                                *      */
        /*"      *   EM 27/09/2013 -  CLAUDIO FREITAS                             *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.01    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  WHOST-PREMIO-1             PIC S9(013)V99 COMP-3 VALUE ZEROS*/
        public DoubleBasis WHOST_PREMIO_1 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  WHOST-PREMIO-2             PIC S9(013)V99 COMP-3 VALUE ZEROS*/
        public DoubleBasis WHOST_PREMIO_2 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  WS-IDADE                   PIC S9(004)    COMP   VALUE ZEROS*/
        public IntBasis WS_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WS-COUNT                   PIC S9(004)    COMP   VALUE ZEROS*/
        public IntBasis WS_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  TESTA-FIM-CURS01            PIC   9.*/

        public SelectorBasis TESTA_FIM_CURS01 { get; set; } = new SelectorBasis("9")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 FIM-CURSOR01             VALUE 1. */
							new SelectorItemBasis("FIM_CURSOR01", "1")
                }
        };

        /*"01  TESTA-FIM-CURS02            PIC   9.*/

        public SelectorBasis TESTA_FIM_CURS02 { get; set; } = new SelectorBasis("9")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 FIM-CURSOR02             VALUE 1. */
							new SelectorItemBasis("FIM_CURSOR02", "1")
                }
        };

        /*"01  WS-TEM-APOLICE              PIC   X.*/

        public SelectorBasis WS_TEM_APOLICE { get; set; } = new SelectorBasis("X")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 TEM-APOLICE              VALUE 'S'. */
							new SelectorItemBasis("TEM_APOLICE", "S")
                }
        };

        /*"01  WS-AREA-WORK.*/
        public VA0061B_WS_AREA_WORK WS_AREA_WORK { get; set; } = new VA0061B_WS_AREA_WORK();
        public class VA0061B_WS_AREA_WORK : VarBasis
        {
            /*"    05  WS-TOT-LIDOS            PIC  9(008)   VALUE ZEROS.*/
            public IntBasis WS_TOT_LIDOS { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  WS-TOTAL-DELETADOS PIC  9(008)   VALUE ZEROS.*/
            public IntBasis WS_TOTAL_DELETADOS { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  WS-TOTAL-LIBERADOS PIC  9(008)   VALUE ZEROS.*/
            public IntBasis WS_TOTAL_LIBERADOS { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  WS-TOTAL-NAO-LIB-1 PIC  9(008)   VALUE ZEROS.*/
            public IntBasis WS_TOTAL_NAO_LIB_1 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  WS-TOTAL-NAO-LIB-2 PIC  9(008)   VALUE ZEROS.*/
            public IntBasis WS_TOTAL_NAO_LIB_2 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  WS-TOTAL-NAO-LIB-3 PIC  9(008)   VALUE ZEROS.*/
            public IntBasis WS_TOTAL_NAO_LIB_3 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  WS-TOTAL-NAO-LIB-4 PIC  9(008)   VALUE ZEROS.*/
            public IntBasis WS_TOTAL_NAO_LIB_4 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  WS-TOTAL-NAO-LIB-5 PIC  9(008)   VALUE ZEROS.*/
            public IntBasis WS_TOTAL_NAO_LIB_5 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  WS-TOTAL-NAO-LIB-6 PIC  9(008)   VALUE ZEROS.*/
            public IntBasis WS_TOTAL_NAO_LIB_6 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  WS-TOTAL-NAO-LIB-7 PIC  9(008)   VALUE ZEROS.*/
            public IntBasis WS_TOTAL_NAO_LIB_7 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  WS-TOTAL-NAO-LIB-8 PIC  9(008)   VALUE ZEROS.*/
            public IntBasis WS_TOTAL_NAO_LIB_8 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  WS-DATA-HOJE            PIC  X(010)   VALUE SPACES.*/
            public StringBasis WS_DATA_HOJE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    05  WS-DATA-HOJE-AUX.*/
            public VA0061B_WS_DATA_HOJE_AUX WS_DATA_HOJE_AUX { get; set; } = new VA0061B_WS_DATA_HOJE_AUX();
            public class VA0061B_WS_DATA_HOJE_AUX : VarBasis
            {
                /*"        10  WS-ANO-HOJE         PIC  9(004)   VALUE ZEROS.*/
                public IntBasis WS_ANO_HOJE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"        10  FILLER              PIC  X(001)   VALUE '-'.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"        10  WS-MES-HOJE         PIC  9(002)   VALUE ZEROS.*/
                public IntBasis WS_MES_HOJE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"        10  FILLER              PIC  X(001)   VALUE '-'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"        10  WS-DIA-HOJE         PIC  9(002)   VALUE ZEROS.*/
                public IntBasis WS_DIA_HOJE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05 WS-DTPROP.*/
            }
            public VA0061B_WS_DTPROP WS_DTPROP { get; set; } = new VA0061B_WS_DTPROP();
            public class VA0061B_WS_DTPROP : VarBasis
            {
                /*"       10  WS-AA-DTPROP         PIC  9(004)   VALUE ZEROS.*/
                public IntBasis WS_AA_DTPROP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"       10  FILLER               PIC  X(001)   VALUE SPACES.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"       10  WS-MM-DTPROP         PIC  9(002)   VALUE ZEROS.*/
                public IntBasis WS_MM_DTPROP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"       10  FILLER               PIC  X(001)   VALUE SPACES.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"       10  WS-DD-DTPROP         PIC  9(002)   VALUE ZEROS.*/
                public IntBasis WS_DD_DTPROP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05 WS-DTNASC.*/
            }
            public VA0061B_WS_DTNASC WS_DTNASC { get; set; } = new VA0061B_WS_DTNASC();
            public class VA0061B_WS_DTNASC : VarBasis
            {
                /*"       10  WS-AA-DTNASC         PIC  9(004)   VALUE ZEROS.*/
                public IntBasis WS_AA_DTNASC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"       10  FILLER               PIC  X(001)   VALUE SPACES.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"       10  WS-MM-DTNASC         PIC  9(002)   VALUE ZEROS.*/
                public IntBasis WS_MM_DTNASC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"       10  FILLER               PIC  X(001)   VALUE SPACES.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"       10  WS-DD-DTNASC         PIC  9(002)   VALUE ZEROS.*/
                public IntBasis WS_DD_DTNASC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05  WS-DATA-ACCEPT.*/
            }
            public VA0061B_WS_DATA_ACCEPT WS_DATA_ACCEPT { get; set; } = new VA0061B_WS_DATA_ACCEPT();
            public class VA0061B_WS_DATA_ACCEPT : VarBasis
            {
                /*"        10  WS-ANO-ACCEPT       PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_ANO_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"        10  WS-MES-ACCEPT       PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_MES_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"        10  WS-DIA-ACCEPT       PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_DIA_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05  WS-HORA-ACCEPT.*/
            }
            public VA0061B_WS_HORA_ACCEPT WS_HORA_ACCEPT { get; set; } = new VA0061B_WS_HORA_ACCEPT();
            public class VA0061B_WS_HORA_ACCEPT : VarBasis
            {
                /*"        10  WS-HOR-ACCEPT       PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_HOR_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"        10  WS-MIN-ACCEPT       PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_MIN_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"        10  WS-SEG-ACCEPT       PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_SEG_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05  WS-DATA-CURR.*/
            }
            public VA0061B_WS_DATA_CURR WS_DATA_CURR { get; set; } = new VA0061B_WS_DATA_CURR();
            public class VA0061B_WS_DATA_CURR : VarBasis
            {
                /*"        10  WS-DIA-CURR         PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_DIA_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"        10  FILLER              PIC  X(001)    VALUE  '-'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"        10  WS-MES-CURR         PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_MES_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"        10  FILLER              PIC  X(001)    VALUE  '-'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"        10  WS-ANO-CURR         PIC  9(004)    VALUE  ZEROS.*/
                public IntBasis WS_ANO_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    05  WS-HORA-CURR.*/
            }
            public VA0061B_WS_HORA_CURR WS_HORA_CURR { get; set; } = new VA0061B_WS_HORA_CURR();
            public class VA0061B_WS_HORA_CURR : VarBasis
            {
                /*"        10  WS-HOR-CURR         PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_HOR_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"        10  FILLER              PIC  X(001)    VALUE  ':'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"        10  WS-MIN-CURR         PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_MIN_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"        10  FILLER              PIC  X(001)    VALUE  ':'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"        10  WS-SEG-CURR         PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_SEG_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05        WABEND.*/
                public VA0061B_WABEND WABEND { get; set; } = new VA0061B_WABEND();
                public class VA0061B_WABEND : VarBasis
                {
                    /*"    10      FILLER              PIC  X(010)     VALUE           ' VA0061B'.*/
                }
            }
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VA0061B");
            /*"    10      FILLER              PIC  X(026)     VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"    10      WNR-EXEC-SQL        PIC  X(004)     VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"    10      FILLER              PIC  X(013)     VALUE           ' *** SQLCODE '.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"    10      WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
        }


        public Copies.LBWPF002 LBWPF002 { get; set; } = new Copies.LBWPF002();
        public Copies.SPVG001V SPVG001V { get; set; } = new Copies.SPVG001V();
        public Copies.SPVG001W SPVG001W { get; set; } = new Copies.SPVG001W();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.ERRPROVI ERRPROVI { get; set; } = new Dclgens.ERRPROVI();
        public Dclgens.RCAPS RCAPS { get; set; } = new Dclgens.RCAPS();
        public Dclgens.PLAVAVGA PLAVAVGA { get; set; } = new Dclgens.PLAVAVGA();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.PROPSSVD PROPSSVD { get; set; } = new Dclgens.PROPSSVD();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.VG103 VG103 { get; set; } = new Dclgens.VG103();

        public VA0061B_CURSOR01 CURSOR01 { get; set; } = new VA0061B_CURSOR01(false);
        string GetQuery_CURSOR01()
        {
            var query = @$"SELECT NUM_CERTIFICADO
							, COD_MSG_CRITICA
							FROM SEGUROS.VG_CRITICA_PROPOSTA WHERE COD_MSG_CRITICA IN (508
							, 1703
							, 1815) AND STA_CRITICA IN ('0'
							,'1'
							,'2'
							,'4'
							,'5'
							,'8')";

            return query;
        }


        public VA0061B_CURSOR02 CURSOR02 { get; set; } = new VA0061B_CURSOR02(true);
        string GetQuery_CURSOR02()
        {
            var query = @$"SELECT A.NUM_CERTIFICADO
							, A.COD_MSG_CRITICA
							, A.SEQ_CRITICA
							, A.STA_CRITICA
							FROM SEGUROS.VG_CRITICA_PROPOSTA A
							, SEGUROS.VG_DM_MSG_CRITICA B WHERE A.NUM_CERTIFICADO = '{ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_NUM_CERTIFICADO}' AND A.STA_CRITICA IN ('0'
							,'1'
							,'2'
							,'4'
							,'5'
							,'8') AND A.COD_MSG_CRITICA = B.COD_MSG_CRITICA AND B.COD_TP_MSG_CRITICA <> '3'";

            return query;
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                InitializeGetQuery();

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PROCESSO-PROGRAMA-SECTION */

                R0000_00_PROCESSO_PROGRAMA_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            return Result;
        }

        public void InitializeGetQuery()
        {
            CURSOR01.GetQueryEvent += GetQuery_CURSOR01;
            CURSOR02.GetQueryEvent += GetQuery_CURSOR02;
        }

        [StopWatch]
        /*" R0000-00-PROCESSO-PROGRAMA-SECTION */
        private void R0000_00_PROCESSO_PROGRAMA_SECTION()
        {
            /*" -196- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", WS_AREA_WORK.WNR_EXEC_SQL);

            /*" -196- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -197- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -198- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -201- DISPLAY '-------------------------------------------------' */
            _.Display($"-------------------------------------------------");

            /*" -202- DISPLAY '          PROGRAMA EM EXECUCAO VA0061B           ' */
            _.Display($"          PROGRAMA EM EXECUCAO VA0061B           ");

            /*" -203- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -204- DISPLAY 'VERSAO V.02: ' FUNCTION WHEN-COMPILED ' - 402.982' */

            $"VERSAO V.02: FUNCTION{_.WhenCompiled()} - 402.982"
            .Display();

            /*" -205- DISPLAY '-------------------------------------------------' */
            _.Display($"-------------------------------------------------");

            /*" -207- DISPLAY ' ' */
            _.Display($" ");

            /*" -209- PERFORM R0100-00-PROCESSO-INICIAL. */

            R0100_00_PROCESSO_INICIAL_SECTION();

            /*" -211- PERFORM R1000-00-PROCESSO-PRINCIPAL. */

            R1000_00_PROCESSO_PRINCIPAL_SECTION();

            /*" -213- PERFORM R9000-00-PROCESSO-FINAL. */

            R9000_00_PROCESSO_FINAL_SECTION();

            /*" -213- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -215- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0100-00-PROCESSO-INICIAL-SECTION */
        private void R0100_00_PROCESSO_INICIAL_SECTION()
        {
            /*" -222- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", WS_AREA_WORK.WNR_EXEC_SQL);

            /*" -224- MOVE ZERO TO TESTA-FIM-CURS01 */
            _.Move(0, TESTA_FIM_CURS01);

            /*" -225- MOVE '00/00/0000' TO WS-DATA-CURR */
            _.Move("00/00/0000", WS_AREA_WORK.WS_DATA_CURR);

            /*" -226- MOVE '0000-00-00' TO WS-DATA-HOJE */
            _.Move("0000-00-00", WS_AREA_WORK.WS_DATA_HOJE);

            /*" -227- ACCEPT WS-DATA-ACCEPT FROM DATE */
            _.Move(_.AcceptDate("DATE"), WS_AREA_WORK.WS_DATA_ACCEPT);

            /*" -228- MOVE WS-DIA-ACCEPT TO WS-DIA-CURR WS-DIA-HOJE */
            _.Move(WS_AREA_WORK.WS_DATA_ACCEPT.WS_DIA_ACCEPT, WS_AREA_WORK.WS_DATA_CURR.WS_DIA_CURR, WS_AREA_WORK.WS_DATA_HOJE_AUX.WS_DIA_HOJE);

            /*" -229- MOVE WS-MES-ACCEPT TO WS-MES-CURR WS-MES-HOJE */
            _.Move(WS_AREA_WORK.WS_DATA_ACCEPT.WS_MES_ACCEPT, WS_AREA_WORK.WS_DATA_CURR.WS_MES_CURR, WS_AREA_WORK.WS_DATA_HOJE_AUX.WS_MES_HOJE);

            /*" -230- MOVE WS-ANO-ACCEPT TO WS-ANO-CURR WS-ANO-HOJE */
            _.Move(WS_AREA_WORK.WS_DATA_ACCEPT.WS_ANO_ACCEPT, WS_AREA_WORK.WS_DATA_CURR.WS_ANO_CURR, WS_AREA_WORK.WS_DATA_HOJE_AUX.WS_ANO_HOJE);

            /*" -231- ADD 2000 TO WS-ANO-CURR WS-ANO-HOJE */
            WS_AREA_WORK.WS_DATA_CURR.WS_ANO_CURR.Value = WS_AREA_WORK.WS_DATA_CURR.WS_ANO_CURR + 2000;
            WS_AREA_WORK.WS_DATA_HOJE_AUX.WS_ANO_HOJE.Value = WS_AREA_WORK.WS_DATA_HOJE_AUX.WS_ANO_HOJE + 2000;

            /*" -233- MOVE WS-DATA-HOJE-AUX TO WS-DATA-HOJE. */
            _.Move(WS_AREA_WORK.WS_DATA_HOJE_AUX, WS_AREA_WORK.WS_DATA_HOJE);

            /*" -234- MOVE '00:00:00' TO WS-HORA-CURR */
            _.Move("00:00:00", WS_AREA_WORK.WS_HORA_CURR);

            /*" -235- ACCEPT WS-HORA-ACCEPT FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_AREA_WORK.WS_HORA_ACCEPT);

            /*" -236- MOVE WS-HOR-ACCEPT TO WS-HOR-CURR */
            _.Move(WS_AREA_WORK.WS_HORA_ACCEPT.WS_HOR_ACCEPT, WS_AREA_WORK.WS_HORA_CURR.WS_HOR_CURR);

            /*" -237- MOVE WS-MIN-ACCEPT TO WS-MIN-CURR */
            _.Move(WS_AREA_WORK.WS_HORA_ACCEPT.WS_MIN_ACCEPT, WS_AREA_WORK.WS_HORA_CURR.WS_MIN_CURR);

            /*" -239- MOVE WS-SEG-ACCEPT TO WS-SEG-CURR. */
            _.Move(WS_AREA_WORK.WS_HORA_ACCEPT.WS_SEG_ACCEPT, WS_AREA_WORK.WS_HORA_CURR.WS_SEG_CURR);

            /*" -240- DISPLAY 'VA0061B - Inicio de execucao (' WS-DATA-CURR ' - ' WS-HORA-CURR ')' . */

            $"VA0061B - Inicio de execucao ({WS_AREA_WORK.WS_DATA_CURR} - {WS_AREA_WORK.WS_HORA_CURR})"
            .Display();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSO-PRINCIPAL-SECTION */
        private void R1000_00_PROCESSO_PRINCIPAL_SECTION()
        {
            /*" -250- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", WS_AREA_WORK.WNR_EXEC_SQL);

            /*" -253- PERFORM R1400-00-OPEN-CURSOR01. */

            R1400_00_OPEN_CURSOR01_SECTION();

            /*" -254- PERFORM R1500-00-FETCH-CURSOR01. */

            R1500_00_FETCH_CURSOR01_SECTION();

            /*" -255- IF FIM-CURSOR01 */

            if (TESTA_FIM_CURS01["FIM_CURSOR01"])
            {

                /*" -256- GO TO R1000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                return;

                /*" -258- END-IF. */
            }


            /*" -258- PERFORM R1600-00-PROCESSA-CURSOR01 UNTIL FIM-CURSOR01. */

            while (!(TESTA_FIM_CURS01["FIM_CURSOR01"]))
            {

                R1600_00_PROCESSA_CURSOR01_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-OPEN-CURSOR01-SECTION */
        private void R1400_00_OPEN_CURSOR01_SECTION()
        {
            /*" -268- MOVE '1400' TO WNR-EXEC-SQL. */
            _.Move("1400", WS_AREA_WORK.WNR_EXEC_SQL);

            /*" -268- PERFORM R1400_00_OPEN_CURSOR01_DB_OPEN_1 */

            R1400_00_OPEN_CURSOR01_DB_OPEN_1();

            /*" -270- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -271- DISPLAY 'ERRO OPEN CURSOR01' */
                _.Display($"ERRO OPEN CURSOR01");

                /*" -272- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -272- END-IF. */
            }


        }

        [StopWatch]
        /*" R1400-00-OPEN-CURSOR01-DB-OPEN-1 */
        public void R1400_00_OPEN_CURSOR01_DB_OPEN_1()
        {
            /*" -268- EXEC SQL OPEN CURSOR01 END-EXEC. */

            CURSOR01.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-FETCH-CURSOR01-SECTION */
        private void R1500_00_FETCH_CURSOR01_SECTION()
        {
            /*" -282- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", WS_AREA_WORK.WNR_EXEC_SQL);

            /*" -286- PERFORM R1500_00_FETCH_CURSOR01_DB_FETCH_1 */

            R1500_00_FETCH_CURSOR01_DB_FETCH_1();

            /*" -289- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -290- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -291- MOVE 1 TO TESTA-FIM-CURS01 */
                    _.Move(1, TESTA_FIM_CURS01);

                    /*" -291- PERFORM R1500_00_FETCH_CURSOR01_DB_CLOSE_1 */

                    R1500_00_FETCH_CURSOR01_DB_CLOSE_1();

                    /*" -293- GO TO R1500-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/ //GOTO
                    return;

                    /*" -294- ELSE */
                }
                else
                {


                    /*" -295- MOVE SQLCODE TO WSQLCODE */
                    _.Move(DB.SQLCODE, WS_AREA_WORK.WSQLCODE);

                    /*" -296- DISPLAY 'ERRO FETCH CURSOR01 SQLCODE = ' WSQLCODE */
                    _.Display($"ERRO FETCH CURSOR01 SQLCODE = {WS_AREA_WORK.WSQLCODE}");

                    /*" -297- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -298- END-IF */
                }


                /*" -300- END-IF. */
            }


            /*" -300- ADD 1 TO WS-TOT-LIDOS. */
            WS_AREA_WORK.WS_TOT_LIDOS.Value = WS_AREA_WORK.WS_TOT_LIDOS + 1;

        }

        [StopWatch]
        /*" R1500-00-FETCH-CURSOR01-DB-FETCH-1 */
        public void R1500_00_FETCH_CURSOR01_DB_FETCH_1()
        {
            /*" -286- EXEC SQL FETCH CURSOR01 INTO :ERRPROVI-NUM-CERTIFICADO , :ERRPROVI-COD-ERRO END-EXEC. */

            if (CURSOR01.Fetch())
            {
                _.Move(CURSOR01.ERRPROVI_NUM_CERTIFICADO, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_NUM_CERTIFICADO);
                _.Move(CURSOR01.ERRPROVI_COD_ERRO, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);
            }

        }

        [StopWatch]
        /*" R1500-00-FETCH-CURSOR01-DB-CLOSE-1 */
        public void R1500_00_FETCH_CURSOR01_DB_CLOSE_1()
        {
            /*" -291- EXEC SQL CLOSE CURSOR01 END-EXEC */

            CURSOR01.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-PROCESSA-CURSOR01-SECTION */
        private void R1600_00_PROCESSA_CURSOR01_SECTION()
        {
            /*" -309- MOVE '1600' TO WNR-EXEC-SQL. */
            _.Move("1600", WS_AREA_WORK.WNR_EXEC_SQL);

            /*" -311- MOVE ZEROS TO WS-COUNT. */
            _.Move(0, WS_COUNT);

            /*" -313- PERFORM R1750-VE-SE-ESTA-EM-CRITICA. */

            R1750_VE_SE_ESTA_EM_CRITICA_SECTION();

            /*" -314- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -328- GO TO R1600-10-LE-PROXIMO. */

                R1600_10_LE_PROXIMO(); //GOTO
                return;
            }


            /*" -342- PERFORM R1600_00_PROCESSA_CURSOR01_DB_SELECT_1 */

            R1600_00_PROCESSA_CURSOR01_DB_SELECT_1();

            /*" -345- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -346- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WS_AREA_WORK.WSQLCODE);

                /*" -347- DISPLAY 'ERRO SELECT COUNT SEGUROS.VG_CRITICA_PROPOSTA' */
                _.Display($"ERRO SELECT COUNT SEGUROS.VG_CRITICA_PROPOSTA");

                /*" -348- DISPLAY 'CERTIFICADO = ' ERRPROVI-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO = {ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_NUM_CERTIFICADO}");

                /*" -349- DISPLAY 'SQLCODE = ' WSQLCODE */
                _.Display($"SQLCODE = {WS_AREA_WORK.WSQLCODE}");

                /*" -350- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -353- END-IF. */
            }


            /*" -354- IF WS-COUNT GREATER THAN ZERO */

            if (WS_COUNT > 00)
            {

                /*" -355- ADD 1 TO WS-TOTAL-NAO-LIB-7 */
                WS_AREA_WORK.WS_TOTAL_NAO_LIB_7.Value = WS_AREA_WORK.WS_TOTAL_NAO_LIB_7 + 1;

                /*" -356- GO TO R1600-10-LE-PROXIMO */

                R1600_10_LE_PROXIMO(); //GOTO
                return;

                /*" -358- END-IF. */
            }


            /*" -360- PERFORM R1700-00-LE-BUSCA-APOLICE. */

            R1700_00_LE_BUSCA_APOLICE_SECTION();

            /*" -361- IF TEM-APOLICE */

            if (WS_TEM_APOLICE["TEM_APOLICE"])
            {

                /*" -362- IF PROPOVA-SIT-REGISTRO EQUAL '1' OR '9' */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO.In("1", "9"))
                {

                    /*" -363- PERFORM R1755-00-SELECT-CLIENTES */

                    R1755_00_SELECT_CLIENTES_SECTION();

                    /*" -364- PERFORM R1800-LE-TAB-PLANO */

                    R1800_LE_TAB_PLANO_SECTION();

                    /*" -365- ELSE */
                }
                else
                {


                    /*" -366- ADD 1 TO WS-TOTAL-NAO-LIB-4 */
                    WS_AREA_WORK.WS_TOTAL_NAO_LIB_4.Value = WS_AREA_WORK.WS_TOTAL_NAO_LIB_4 + 1;

                    /*" -367- END-IF */
                }


                /*" -368- ELSE */
            }
            else
            {


                /*" -369- ADD 1 TO WS-TOTAL-NAO-LIB-5 */
                WS_AREA_WORK.WS_TOTAL_NAO_LIB_5.Value = WS_AREA_WORK.WS_TOTAL_NAO_LIB_5 + 1;

                /*" -369- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R1600_10_LE_PROXIMO */

            R1600_10_LE_PROXIMO();

        }

        [StopWatch]
        /*" R1600-00-PROCESSA-CURSOR01-DB-SELECT-1 */
        public void R1600_00_PROCESSA_CURSOR01_DB_SELECT_1()
        {
            /*" -342- EXEC SQL SELECT A.NUM_CERTIFICADO, COUNT(*) INTO :ERRPROVI-NUM-CERTIFICADO, :WS-COUNT FROM SEGUROS.VG_CRITICA_PROPOSTA A, SEGUROS.VG_DM_MSG_CRITICA B WHERE A.NUM_CERTIFICADO = :ERRPROVI-NUM-CERTIFICADO AND A.COD_MSG_CRITICA NOT IN (508, 1703, 1800, 1815) AND A.STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' ) AND A.COD_MSG_CRITICA = B.COD_MSG_CRITICA AND B.COD_TP_MSG_CRITICA <> '3' GROUP BY NUM_CERTIFICADO WITH UR END-EXEC. */

            var r1600_00_PROCESSA_CURSOR01_DB_SELECT_1_Query1 = new R1600_00_PROCESSA_CURSOR01_DB_SELECT_1_Query1()
            {
                ERRPROVI_NUM_CERTIFICADO = ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1600_00_PROCESSA_CURSOR01_DB_SELECT_1_Query1.Execute(r1600_00_PROCESSA_CURSOR01_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ERRPROVI_NUM_CERTIFICADO, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_NUM_CERTIFICADO);
                _.Move(executed_1.WS_COUNT, WS_COUNT);
            }


        }

        [StopWatch]
        /*" R1600-10-LE-PROXIMO */
        private void R1600_10_LE_PROXIMO(bool isPerform = false)
        {
            /*" -373- PERFORM R1500-00-FETCH-CURSOR01. */

            R1500_00_FETCH_CURSOR01_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1700-00-LE-BUSCA-APOLICE-SECTION */
        private void R1700_00_LE_BUSCA_APOLICE_SECTION()
        {
            /*" -382- MOVE '1700' TO WNR-EXEC-SQL. */
            _.Move("1700", WS_AREA_WORK.WNR_EXEC_SQL);

            /*" -384- MOVE 'S' TO WS-TEM-APOLICE. */
            _.Move("S", WS_TEM_APOLICE);

            /*" -387- INITIALIZE DCLPROPOSTA-FIDELIZ DCLPROP-SASSE-VIDA. */
            _.Initialize(
                PROPOFID.DCLPROPOSTA_FIDELIZ
                , PROPSSVD.DCLPROP_SASSE_VIDA
            );

            /*" -409- PERFORM R1700_00_LE_BUSCA_APOLICE_DB_SELECT_1 */

            R1700_00_LE_BUSCA_APOLICE_DB_SELECT_1();

            /*" -412- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -413- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WS_AREA_WORK.WSQLCODE);

                /*" -414- DISPLAY 'ERRO BUSCA DA APOLICE  SQLCODE = ' WSQLCODE */
                _.Display($"ERRO BUSCA DA APOLICE  SQLCODE = {WS_AREA_WORK.WSQLCODE}");

                /*" -415- DISPLAY 'PROPOSTA SIVPF = ' ERRPROVI-NUM-CERTIFICADO */
                _.Display($"PROPOSTA SIVPF = {ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_NUM_CERTIFICADO}");

                /*" -416- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -418- END-IF. */
            }


            /*" -419- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -420- MOVE 'N' TO WS-TEM-APOLICE */
                _.Move("N", WS_TEM_APOLICE);

                /*" -421- GO TO R1700-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/ //GOTO
                return;

                /*" -423- END-IF. */
            }


            /*" -423- MOVE PROPOFID-DATA-PROPOSTA TO WS-DTPROP. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA, WS_AREA_WORK.WS_DTPROP);

        }

        [StopWatch]
        /*" R1700-00-LE-BUSCA-APOLICE-DB-SELECT-1 */
        public void R1700_00_LE_BUSCA_APOLICE_DB_SELECT_1()
        {
            /*" -409- EXEC SQL SELECT A.NUM_APOLICE , A.COD_SUBGRUPO , B.NUM_PROPOSTA_SIVPF , B.COD_PESSOA , B.NUM_SICOB , B.OPCAO_COBER , B.DATA_PROPOSTA , B.DTQITBCO INTO :PROPSSVD-NUM-APOLICE , :PROPSSVD-COD-SUBGRUPO , :PROPOFID-NUM-PROPOSTA-SIVPF , :PROPOFID-COD-PESSOA , :PROPOFID-NUM-SICOB , :PROPOFID-OPCAO-COBER , :PROPOFID-DATA-PROPOSTA , :PROPOFID-DTQITBCO FROM SEGUROS.PROP_SASSE_VIDA A , SEGUROS.PROPOSTA_FIDELIZ B WHERE B.NUM_IDENTIFICACAO = A.NUM_IDENTIFICACAO AND B.NUM_PROPOSTA_SIVPF = :ERRPROVI-NUM-CERTIFICADO END-EXEC. */

            var r1700_00_LE_BUSCA_APOLICE_DB_SELECT_1_Query1 = new R1700_00_LE_BUSCA_APOLICE_DB_SELECT_1_Query1()
            {
                ERRPROVI_NUM_CERTIFICADO = ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1700_00_LE_BUSCA_APOLICE_DB_SELECT_1_Query1.Execute(r1700_00_LE_BUSCA_APOLICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPSSVD_NUM_APOLICE, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE);
                _.Move(executed_1.PROPSSVD_COD_SUBGRUPO, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO);
                _.Move(executed_1.PROPOFID_NUM_PROPOSTA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);
                _.Move(executed_1.PROPOFID_COD_PESSOA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA);
                _.Move(executed_1.PROPOFID_NUM_SICOB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB);
                _.Move(executed_1.PROPOFID_OPCAO_COBER, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER);
                _.Move(executed_1.PROPOFID_DATA_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA);
                _.Move(executed_1.PROPOFID_DTQITBCO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/

        [StopWatch]
        /*" R1750-VE-SE-ESTA-EM-CRITICA-SECTION */
        private void R1750_VE_SE_ESTA_EM_CRITICA_SECTION()
        {
            /*" -433- MOVE '1750' TO WNR-EXEC-SQL. */
            _.Move("1750", WS_AREA_WORK.WNR_EXEC_SQL);

            /*" -435- INITIALIZE DCLPROPOSTAS-VA. */
            _.Initialize(
                PROPOVA.DCLPROPOSTAS_VA
            );

            /*" -442- PERFORM R1750_VE_SE_ESTA_EM_CRITICA_DB_SELECT_1 */

            R1750_VE_SE_ESTA_EM_CRITICA_DB_SELECT_1();

            /*" -445- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -446- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WS_AREA_WORK.WSQLCODE);

                /*" -447- DISPLAY 'ERRO SELECT  PROPOSTAS_VA   SQLCODE = ' WSQLCODE */
                _.Display($"ERRO SELECT  PROPOSTAS_VA   SQLCODE = {WS_AREA_WORK.WSQLCODE}");

                /*" -448- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -448- END-IF. */
            }


        }

        [StopWatch]
        /*" R1750-VE-SE-ESTA-EM-CRITICA-DB-SELECT-1 */
        public void R1750_VE_SE_ESTA_EM_CRITICA_DB_SELECT_1()
        {
            /*" -442- EXEC SQL SELECT SIT_REGISTRO, COD_CLIENTE INTO :PROPOVA-SIT-REGISTRO , :PROPOVA-COD-CLIENTE FROM SEGUROS.PROPOSTAS_VA WHERE NUM_CERTIFICADO = :ERRPROVI-NUM-CERTIFICADO END-EXEC. */

            var r1750_VE_SE_ESTA_EM_CRITICA_DB_SELECT_1_Query1 = new R1750_VE_SE_ESTA_EM_CRITICA_DB_SELECT_1_Query1()
            {
                ERRPROVI_NUM_CERTIFICADO = ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1750_VE_SE_ESTA_EM_CRITICA_DB_SELECT_1_Query1.Execute(r1750_VE_SE_ESTA_EM_CRITICA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOVA_SIT_REGISTRO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);
                _.Move(executed_1.PROPOVA_COD_CLIENTE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1750_99_SAIDA*/

        [StopWatch]
        /*" R1755-00-SELECT-CLIENTES-SECTION */
        private void R1755_00_SELECT_CLIENTES_SECTION()
        {
            /*" -460- MOVE '1755' TO WNR-EXEC-SQL. */
            _.Move("1755", WS_AREA_WORK.WNR_EXEC_SQL);

            /*" -462- INITIALIZE DCLCLIENTES. */
            _.Initialize(
                CLIENTES.DCLCLIENTES
            );

            /*" -467- PERFORM R1755_00_SELECT_CLIENTES_DB_SELECT_1 */

            R1755_00_SELECT_CLIENTES_DB_SELECT_1();

            /*" -470- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -471- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WS_AREA_WORK.WSQLCODE);

                /*" -472- DISPLAY 'ERRO AO BUSCAR DATA DE NASCIMENTO' */
                _.Display($"ERRO AO BUSCAR DATA DE NASCIMENTO");

                /*" -473- DISPLAY 'ERRO SELECT  SEGUROS.CLIENTES = ' WSQLCODE */
                _.Display($"ERRO SELECT  SEGUROS.CLIENTES = {WS_AREA_WORK.WSQLCODE}");

                /*" -474- DISPLAY 'CLIENTE     = ' PROPOVA-COD-CLIENTE */
                _.Display($"CLIENTE     = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE}");

                /*" -475- DISPLAY 'CERTIFICADO = ' ERRPROVI-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO = {ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_NUM_CERTIFICADO}");

                /*" -476- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -478- END-IF. */
            }


            /*" -480- MOVE CLIENTES-DATA-NASCIMENTO TO WS-DTNASC. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO, WS_AREA_WORK.WS_DTNASC);

            /*" -482- COMPUTE WS-IDADE = WS-AA-DTPROP - WS-AA-DTNASC. */
            WS_IDADE.Value = WS_AREA_WORK.WS_DTPROP.WS_AA_DTPROP - WS_AREA_WORK.WS_DTNASC.WS_AA_DTNASC;

            /*" -483- IF WS-MM-DTNASC GREATER WS-MM-DTPROP */

            if (WS_AREA_WORK.WS_DTNASC.WS_MM_DTNASC > WS_AREA_WORK.WS_DTPROP.WS_MM_DTPROP)
            {

                /*" -484- SUBTRACT 1 FROM WS-IDADE */
                WS_IDADE.Value = WS_IDADE - 1;

                /*" -485- ELSE */
            }
            else
            {


                /*" -486- IF WS-MM-DTNASC EQUAL WS-MM-DTPROP */

                if (WS_AREA_WORK.WS_DTNASC.WS_MM_DTNASC == WS_AREA_WORK.WS_DTPROP.WS_MM_DTPROP)
                {

                    /*" -487- IF WS-DD-DTNASC GREATER WS-DD-DTPROP */

                    if (WS_AREA_WORK.WS_DTNASC.WS_DD_DTNASC > WS_AREA_WORK.WS_DTPROP.WS_DD_DTPROP)
                    {

                        /*" -488- SUBTRACT 1 FROM WS-IDADE */
                        WS_IDADE.Value = WS_IDADE - 1;

                        /*" -489- END-IF */
                    }


                    /*" -490- END-IF */
                }


                /*" -490- END-IF. */
            }


        }

        [StopWatch]
        /*" R1755-00-SELECT-CLIENTES-DB-SELECT-1 */
        public void R1755_00_SELECT_CLIENTES_DB_SELECT_1()
        {
            /*" -467- EXEC SQL SELECT DATA_NASCIMENTO INTO :CLIENTES-DATA-NASCIMENTO FROM SEGUROS.CLIENTES WHERE COD_CLIENTE= :PROPOVA-COD-CLIENTE END-EXEC. */

            var r1755_00_SELECT_CLIENTES_DB_SELECT_1_Query1 = new R1755_00_SELECT_CLIENTES_DB_SELECT_1_Query1()
            {
                PROPOVA_COD_CLIENTE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE.ToString(),
            };

            var executed_1 = R1755_00_SELECT_CLIENTES_DB_SELECT_1_Query1.Execute(r1755_00_SELECT_CLIENTES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_DATA_NASCIMENTO, CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1755_99_SAIDA*/

        [StopWatch]
        /*" R1800-LE-TAB-PLANO-SECTION */
        private void R1800_LE_TAB_PLANO_SECTION()
        {
            /*" -499- MOVE '1800' TO WNR-EXEC-SQL. */
            _.Move("1800", WS_AREA_WORK.WNR_EXEC_SQL);

            /*" -501- INITIALIZE DCLPLANOS-VA-VGAP. */
            _.Initialize(
                PLAVAVGA.DCLPLANOS_VA_VGAP
            );

            /*" -512- PERFORM R1800_LE_TAB_PLANO_DB_SELECT_1 */

            R1800_LE_TAB_PLANO_DB_SELECT_1();

            /*" -516- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -517- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WS_AREA_WORK.WSQLCODE);

                /*" -518- DISPLAY 'ERRO SELECT  PLANOS_VA_VGAP SQLCODE = ' WSQLCODE */
                _.Display($"ERRO SELECT  PLANOS_VA_VGAP SQLCODE = {WS_AREA_WORK.WSQLCODE}");

                /*" -519- DISPLAY 'APOLICE    = ' PROPSSVD-NUM-APOLICE */
                _.Display($"APOLICE    = {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE}");

                /*" -520- DISPLAY 'SUBGRUPO   = ' PROPSSVD-COD-SUBGRUPO */
                _.Display($"SUBGRUPO   = {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO}");

                /*" -521- DISPLAY 'OPC COBERT = ' PROPOFID-OPCAO-COBER */
                _.Display($"OPC COBERT = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER}");

                /*" -522- DISPLAY 'DTQITBCO   = ' PROPOFID-DTQITBCO */
                _.Display($"DTQITBCO   = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO}");

                /*" -523- DISPLAY 'IDADE CALC.= ' WS-IDADE */
                _.Display($"IDADE CALC.= {WS_IDADE}");

                /*" -524- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -525- ADD 1 TO WS-TOTAL-NAO-LIB-1 */
                    WS_AREA_WORK.WS_TOTAL_NAO_LIB_1.Value = WS_AREA_WORK.WS_TOTAL_NAO_LIB_1 + 1;

                    /*" -526- GO TO R1800-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1800_99_SAIDA*/ //GOTO
                    return;

                    /*" -527- ELSE */
                }
                else
                {


                    /*" -528- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -529- END-IF */
                }


                /*" -531- END-IF. */
            }


            /*" -533- COMPUTE WHOST-PREMIO-1 = PLAVAVGA-VLPREMIOTOT - 1 */
            WHOST_PREMIO_1.Value = PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_VLPREMIOTOT - 1;

            /*" -535- COMPUTE WHOST-PREMIO-2 = PLAVAVGA-VLPREMIOTOT + 1 */
            WHOST_PREMIO_2.Value = PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_VLPREMIOTOT + 1;

            /*" -537- INITIALIZE DCLRCAPS. */
            _.Initialize(
                RCAPS.DCLRCAPS
            );

            /*" -539- MOVE PROPOFID-NUM-SICOB TO RCAPS-NUM-TITULO. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB, RCAPS.DCLRCAPS.RCAPS_NUM_TITULO);

            /*" -548- PERFORM R1800_LE_TAB_PLANO_DB_SELECT_2 */

            R1800_LE_TAB_PLANO_DB_SELECT_2();

            /*" -551- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -552- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WS_AREA_WORK.WSQLCODE);

                /*" -553- DISPLAY 'ERRO SELECT  PLANOS_VA_VGAP SQLCODE = ' WSQLCODE */
                _.Display($"ERRO SELECT  PLANOS_VA_VGAP SQLCODE = {WS_AREA_WORK.WSQLCODE}");

                /*" -555- DISPLAY 'CERTIFIC   = ' ERRPROVI-NUM-CERTIFICADO ' ' RCAPS-NUM-TITULO */

                $"CERTIFIC   = {ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_NUM_CERTIFICADO} {RCAPS.DCLRCAPS.RCAPS_NUM_TITULO}"
                .Display();

                /*" -556- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -557- ADD 1 TO WS-TOTAL-NAO-LIB-2 */
                    WS_AREA_WORK.WS_TOTAL_NAO_LIB_2.Value = WS_AREA_WORK.WS_TOTAL_NAO_LIB_2 + 1;

                    /*" -558- GO TO R1800-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1800_99_SAIDA*/ //GOTO
                    return;

                    /*" -559- ELSE */
                }
                else
                {


                    /*" -560- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -561- END-IF */
                }


                /*" -563- END-IF. */
            }


            /*" -565- IF RCAPS-VAL-RCAP NOT LESS WHOST-PREMIO-1 AND RCAPS-VAL-RCAP NOT GREATER WHOST-PREMIO-2 */

            if (RCAPS.DCLRCAPS.RCAPS_VAL_RCAP >= WHOST_PREMIO_1 && RCAPS.DCLRCAPS.RCAPS_VAL_RCAP <= WHOST_PREMIO_2)
            {

                /*" -566- PERFORM R2000-DELETA-ERROS-PROP-VDAZUL */

                R2000_DELETA_ERROS_PROP_VDAZUL_SECTION();

                /*" -567- ELSE */
            }
            else
            {


                /*" -568- ADD 1 TO WS-TOTAL-NAO-LIB-3 */
                WS_AREA_WORK.WS_TOTAL_NAO_LIB_3.Value = WS_AREA_WORK.WS_TOTAL_NAO_LIB_3 + 1;

                /*" -568- END-IF. */
            }


        }

        [StopWatch]
        /*" R1800-LE-TAB-PLANO-DB-SELECT-1 */
        public void R1800_LE_TAB_PLANO_DB_SELECT_1()
        {
            /*" -512- EXEC SQL SELECT VLPREMIOTOT INTO :PLAVAVGA-VLPREMIOTOT FROM SEGUROS.PLANOS_VA_VGAP WHERE NUM_APOLICE = :PROPSSVD-NUM-APOLICE AND CODSUBES = :PROPSSVD-COD-SUBGRUPO AND OPCAO_COBER = :PROPOFID-OPCAO-COBER AND DTINIVIG <= :PROPOFID-DTQITBCO AND DTTERVIG >= :PROPOFID-DTQITBCO AND IDADE_INICIAL <= :WS-IDADE AND IDADE_FINAL >= :WS-IDADE END-EXEC. */

            var r1800_LE_TAB_PLANO_DB_SELECT_1_Query1 = new R1800_LE_TAB_PLANO_DB_SELECT_1_Query1()
            {
                PROPSSVD_COD_SUBGRUPO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.ToString(),
                PROPSSVD_NUM_APOLICE = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.ToString(),
                PROPOFID_OPCAO_COBER = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER.ToString(),
                PROPOFID_DTQITBCO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.ToString(),
                WS_IDADE = WS_IDADE.ToString(),
            };

            var executed_1 = R1800_LE_TAB_PLANO_DB_SELECT_1_Query1.Execute(r1800_LE_TAB_PLANO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PLAVAVGA_VLPREMIOTOT, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_VLPREMIOTOT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1800_99_SAIDA*/

        [StopWatch]
        /*" R1800-LE-TAB-PLANO-DB-SELECT-2 */
        public void R1800_LE_TAB_PLANO_DB_SELECT_2()
        {
            /*" -548- EXEC SQL SELECT NUM_RCAP, VAL_RCAP INTO :RCAPS-NUM-RCAP, :RCAPS-VAL-RCAP FROM SEGUROS.RCAPS WHERE NUM_TITULO =:RCAPS-NUM-TITULO END-EXEC. */

            var r1800_LE_TAB_PLANO_DB_SELECT_2_Query1 = new R1800_LE_TAB_PLANO_DB_SELECT_2_Query1()
            {
                RCAPS_NUM_TITULO = RCAPS.DCLRCAPS.RCAPS_NUM_TITULO.ToString(),
            };

            var executed_1 = R1800_LE_TAB_PLANO_DB_SELECT_2_Query1.Execute(r1800_LE_TAB_PLANO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_NUM_RCAP, RCAPS.DCLRCAPS.RCAPS_NUM_RCAP);
                _.Move(executed_1.RCAPS_VAL_RCAP, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP);
            }


        }

        [StopWatch]
        /*" R2000-DELETA-ERROS-PROP-VDAZUL-SECTION */
        private void R2000_DELETA_ERROS_PROP_VDAZUL_SECTION()
        {
            /*" -579- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", WS_AREA_WORK.WNR_EXEC_SQL);

            /*" -581- PERFORM R2400-00-OPEN-CURSOR02. */

            R2400_00_OPEN_CURSOR02_SECTION();

            /*" -583- PERFORM R2500-00-FETCH-CURSOR02. */

            R2500_00_FETCH_CURSOR02_SECTION();

            /*" -584- IF FIM-CURSOR02 */

            if (TESTA_FIM_CURS02["FIM_CURSOR02"])
            {

                /*" -585- GO TO R2000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/ //GOTO
                return;

                /*" -587- END-IF. */
            }


            /*" -605- PERFORM R2600-00-DELETE-VGCRITICA UNTIL FIM-CURSOR02. */

            while (!(TESTA_FIM_CURS02["FIM_CURSOR02"]))
            {

                R2600_00_DELETE_VGCRITICA_SECTION();
            }

            /*" -609- PERFORM R2000_DELETA_ERROS_PROP_VDAZUL_DB_UPDATE_1 */

            R2000_DELETA_ERROS_PROP_VDAZUL_DB_UPDATE_1();

            /*" -612- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -613- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WS_AREA_WORK.WSQLCODE);

                /*" -615- DISPLAY 'ERRO UPDATE SEGUROS.PROPOSTAS_VA SQLCODE = ' WSQLCODE */
                _.Display($"ERRO UPDATE SEGUROS.PROPOSTAS_VA SQLCODE = {WS_AREA_WORK.WSQLCODE}");

                /*" -616- DISPLAY 'CERTIFICADO = ' ERRPROVI-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO = {ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_NUM_CERTIFICADO}");

                /*" -617- ADD 1 TO WS-TOTAL-NAO-LIB-6 */
                WS_AREA_WORK.WS_TOTAL_NAO_LIB_6.Value = WS_AREA_WORK.WS_TOTAL_NAO_LIB_6 + 1;

                /*" -618- ELSE */
            }
            else
            {


                /*" -620- DISPLAY 'LIBERADO --------> ' ERRPROVI-NUM-CERTIFICADO */
                _.Display($"LIBERADO --------> {ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_NUM_CERTIFICADO}");

                /*" -621- ADD 1 TO WS-TOTAL-LIBERADOS */
                WS_AREA_WORK.WS_TOTAL_LIBERADOS.Value = WS_AREA_WORK.WS_TOTAL_LIBERADOS + 1;

                /*" -621- END-IF. */
            }


        }

        [StopWatch]
        /*" R2000-DELETA-ERROS-PROP-VDAZUL-DB-UPDATE-1 */
        public void R2000_DELETA_ERROS_PROP_VDAZUL_DB_UPDATE_1()
        {
            /*" -609- EXEC SQL UPDATE SEGUROS.PROPOSTAS_VA SET SIT_REGISTRO = '0' WHERE NUM_CERTIFICADO = :ERRPROVI-NUM-CERTIFICADO END-EXEC. */

            var r2000_DELETA_ERROS_PROP_VDAZUL_DB_UPDATE_1_Update1 = new R2000_DELETA_ERROS_PROP_VDAZUL_DB_UPDATE_1_Update1()
            {
                ERRPROVI_NUM_CERTIFICADO = ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_NUM_CERTIFICADO.ToString(),
            };

            R2000_DELETA_ERROS_PROP_VDAZUL_DB_UPDATE_1_Update1.Execute(r2000_DELETA_ERROS_PROP_VDAZUL_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-OPEN-CURSOR02-SECTION */
        private void R2400_00_OPEN_CURSOR02_SECTION()
        {
            /*" -632- MOVE '2400' TO WNR-EXEC-SQL. */
            _.Move("2400", WS_AREA_WORK.WNR_EXEC_SQL);

            /*" -634- MOVE ZEROS TO TESTA-FIM-CURS02 */
            _.Move(0, TESTA_FIM_CURS02);

            /*" -634- PERFORM R2400_00_OPEN_CURSOR02_DB_OPEN_1 */

            R2400_00_OPEN_CURSOR02_DB_OPEN_1();

            /*" -637- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -638- DISPLAY 'ERRO OPEN CURSOR02' */
                _.Display($"ERRO OPEN CURSOR02");

                /*" -639- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -639- END-IF. */
            }


        }

        [StopWatch]
        /*" R2400-00-OPEN-CURSOR02-DB-OPEN-1 */
        public void R2400_00_OPEN_CURSOR02_DB_OPEN_1()
        {
            /*" -634- EXEC SQL OPEN CURSOR02 END-EXEC. */

            CURSOR02.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-FETCH-CURSOR02-SECTION */
        private void R2500_00_FETCH_CURSOR02_SECTION()
        {
            /*" -650- MOVE '2500' TO WNR-EXEC-SQL. */
            _.Move("2500", WS_AREA_WORK.WNR_EXEC_SQL);

            /*" -655- PERFORM R2500_00_FETCH_CURSOR02_DB_FETCH_1 */

            R2500_00_FETCH_CURSOR02_DB_FETCH_1();

            /*" -658- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -659- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -660- MOVE 1 TO TESTA-FIM-CURS02 */
                    _.Move(1, TESTA_FIM_CURS02);

                    /*" -661- PERFORM R2700-00-CLOSE-CURSOR02 */

                    R2700_00_CLOSE_CURSOR02_SECTION();

                    /*" -662- ELSE */
                }
                else
                {


                    /*" -663- MOVE SQLCODE TO WSQLCODE */
                    _.Move(DB.SQLCODE, WS_AREA_WORK.WSQLCODE);

                    /*" -664- DISPLAY 'ERRO FETCH CURSOR02 SQLCODE = ' WSQLCODE */
                    _.Display($"ERRO FETCH CURSOR02 SQLCODE = {WS_AREA_WORK.WSQLCODE}");

                    /*" -665- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -666- END-IF */
                }


                /*" -666- END-IF. */
            }


        }

        [StopWatch]
        /*" R2500-00-FETCH-CURSOR02-DB-FETCH-1 */
        public void R2500_00_FETCH_CURSOR02_DB_FETCH_1()
        {
            /*" -655- EXEC SQL FETCH CURSOR02 INTO :VG103-NUM-CERTIFICADO, :VG103-COD-MSG-CRITICA, :VG103-SEQ-CRITICA, :VG103-STA-CRITICA END-EXEC. */

            if (CURSOR02.Fetch())
            {
                _.Move(CURSOR02.VG103_NUM_CERTIFICADO, VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CERTIFICADO);
                _.Move(CURSOR02.VG103_COD_MSG_CRITICA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_COD_MSG_CRITICA);
                _.Move(CURSOR02.VG103_SEQ_CRITICA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_SEQ_CRITICA);
                _.Move(CURSOR02.VG103_STA_CRITICA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_STA_CRITICA);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R2600-00-DELETE-VGCRITICA-SECTION */
        private void R2600_00_DELETE_VGCRITICA_SECTION()
        {
            /*" -677- MOVE '2600' TO WNR-EXEC-SQL. */
            _.Move("2600", WS_AREA_WORK.WNR_EXEC_SQL);

            /*" -679- INITIALIZE LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Initialize(
                SPVG001W.LK_VG001_TRACE
                , SPVG001W.LK_VG001_TIPO_ACAO
                , SPVG001W.LK_VG001_NUM_CERTIFICADO
                , SPVG001W.LK_VG001_SEQ_CRITICA
                , SPVG001W.LK_VG001_IND_TP_PROPOSTA
                , SPVG001W.LK_VG001_NUM_CPF_CNPJ
                , SPVG001W.LK_VG001_COD_MSG_CRITICA
                , SPVG001W.LK_VG001_COD_USUARIO
                , SPVG001W.LK_VG001_NOM_PROGRAMA
                , SPVG001W.LK_VG001_STA_CRITICA
                , SPVG001W.LK_VG001_DES_COMPLEMENTAR
                , SPVG001W.LK_VG001_S_NUM_CERTIFICADO
                , SPVG001W.LK_VG001_S_SEQ_CRITICA
                , SPVG001W.LK_VG001_S_IND_TP_PROPOSTA
                , SPVG001W.LK_VG001_S_COD_MSG_CRITICA
                , SPVG001W.LK_VG001_S_DES_MSG_CRITICA
                , SPVG001W.LK_VG001_S_DES_ABREV_MSG_CRIT
                , SPVG001W.LK_VG001_S_NUM_CPF_CNPJ
                , SPVG001W.LK_VG001_S_NUM_PROPOSTA
                , SPVG001W.LK_VG001_S_VLR_IS
                , SPVG001W.LK_VG001_S_VLR_PREMIO
                , SPVG001W.LK_VG001_S_DTA_OCORRENCIA
                , SPVG001W.LK_VG001_S_DTA_RCAP
                , SPVG001W.LK_VG001_S_STA_CRITICA
                , SPVG001W.LK_VG001_S_DES_STA_CRITICA
                , SPVG001W.LK_VG001_S_DES_COMPLEMENTAR
                , SPVG001W.LK_VG001_S_COD_USUARIO
                , SPVG001W.LK_VG001_S_NOM_PROGRAMA
                , SPVG001W.LK_VG001_S_DTH_CADASTRAMENTO
                , SPVG001W.LK_VG001_S_STA_PARA
                , SPVG001W.LK_VG001_IND_ERRO
                , SPVG001W.LK_VG001_MSG_ERRO
                , SPVG001W.LK_VG001_NOM_TABELA
                , SPVG001W.LK_VG001_SQLCODE
                , SPVG001W.LK_VG001_SQLERRMC
            );

            /*" -680- MOVE 'N' TO LK-VG001-TRACE */
            _.Move("N", SPVG001W.LK_VG001_TRACE);

            /*" -681- MOVE 03 TO LK-VG001-TIPO-ACAO */
            _.Move(03, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -682- MOVE VG103-NUM-CERTIFICADO TO LK-VG001-NUM-CERTIFICADO */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CERTIFICADO, SPVG001W.LK_VG001_NUM_CERTIFICADO);

            /*" -683- MOVE VG103-SEQ-CRITICA TO LK-VG001-SEQ-CRITICA */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_SEQ_CRITICA, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -684- MOVE 'PF' TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("PF", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -685- MOVE 0 TO LK-VG001-NUM-CPF-CNPJ */
            _.Move(0, SPVG001W.LK_VG001_NUM_CPF_CNPJ);

            /*" -686- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -687- MOVE 'VA0061B' TO LK-VG001-NOM-PROGRAMA */
            _.Move("VA0061B", SPVG001W.LK_VG001_NOM_PROGRAMA);

            /*" -688- MOVE 'SPBVG001' TO VG001-PROGRAMA */
            _.Move("SPBVG001", SPVG001V.VG001_PROGRAMA);

            /*" -689- MOVE 'B' TO LK-VG001-STA-CRITICA */
            _.Move("B", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -690- MOVE 50 TO LK-VG001-DES-COMPLEMENTAR-L */
            _.Move(50, SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_L);

            /*" -691- MOVE VG103-COD-MSG-CRITICA TO LK-VG001-COD-MSG-CRITICA */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_COD_MSG_CRITICA, SPVG001W.LK_VG001_COD_MSG_CRITICA);

            /*" -694- MOVE 'EXCLUSAO LOGICA DE ERRO DA PROPOSTA ' TO LK-VG001-DES-COMPLEMENTAR-T */
            _.Move("EXCLUSAO LOGICA DE ERRO DA PROPOSTA ", SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_T);

            /*" -696- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -697- IF LK-VG001-IND-ERRO NOT EQUAL ZEROS */

            if (SPVG001W.LK_VG001_IND_ERRO != 00)
            {

                /*" -698- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -699- DISPLAY '* R2300 -  PROBLEMAS CALL SUBROTINA SPBVG001  *' */
                _.Display($"* R2300 -  PROBLEMAS CALL SUBROTINA SPBVG001  *");

                /*" -700- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -701- DISPLAY '* NUM-CERTIF..: ' LK-VG001-NUM-CERTIFICADO */
                _.Display($"* NUM-CERTIF..: {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                /*" -702- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                /*" -703- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                /*" -704- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                /*" -705- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                /*" -706- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                /*" -708- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -709- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -711- END-IF */
            }


            /*" -713- ADD 1 TO WS-TOTAL-DELETADOS */
            WS_AREA_WORK.WS_TOTAL_DELETADOS.Value = WS_AREA_WORK.WS_TOTAL_DELETADOS + 1;

            /*" -713- PERFORM R2500-00-FETCH-CURSOR02. */

            R2500_00_FETCH_CURSOR02_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2600_99_SAIDA*/

        [StopWatch]
        /*" R2700-00-CLOSE-CURSOR02-SECTION */
        private void R2700_00_CLOSE_CURSOR02_SECTION()
        {
            /*" -724- MOVE '2700' TO WNR-EXEC-SQL. */
            _.Move("2700", WS_AREA_WORK.WNR_EXEC_SQL);

            /*" -724- PERFORM R2700_00_CLOSE_CURSOR02_DB_CLOSE_1 */

            R2700_00_CLOSE_CURSOR02_DB_CLOSE_1();

            /*" -727- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -728- DISPLAY 'ERRO CLOSE CURSOR02' */
                _.Display($"ERRO CLOSE CURSOR02");

                /*" -729- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -729- END-IF. */
            }


        }

        [StopWatch]
        /*" R2700-00-CLOSE-CURSOR02-DB-CLOSE-1 */
        public void R2700_00_CLOSE_CURSOR02_DB_CLOSE_1()
        {
            /*" -724- EXEC SQL CLOSE CURSOR02 END-EXEC. */

            CURSOR02.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2700_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-PROCESSO-FINAL-SECTION */
        private void R9000_00_PROCESSO_FINAL_SECTION()
        {
            /*" -739- MOVE '9000' TO WNR-EXEC-SQL. */
            _.Move("9000", WS_AREA_WORK.WNR_EXEC_SQL);

            /*" -740- DISPLAY ' REGS. LIDOS ....... ' WS-TOT-LIDOS. */
            _.Display($" REGS. LIDOS ....... {WS_AREA_WORK.WS_TOT_LIDOS}");

            /*" -741- DISPLAY ' REGS. DELETADOS.... ' WS-TOTAL-DELETADOS. */
            _.Display($" REGS. DELETADOS.... {WS_AREA_WORK.WS_TOTAL_DELETADOS}");

            /*" -742- DISPLAY ' PROPOSTAS LIBERADAS ' WS-TOTAL-LIBERADOS. */
            _.Display($" PROPOSTAS LIBERADAS {WS_AREA_WORK.WS_TOTAL_LIBERADOS}");

            /*" -743- DISPLAY ' PROPOSTAS NAO LIBER.' WS-TOTAL-NAO-LIB-1. */
            _.Display($" PROPOSTAS NAO LIBER.{WS_AREA_WORK.WS_TOTAL_NAO_LIB_1}");

            /*" -744- DISPLAY ' PROPOSTAS NAO LIBER.' WS-TOTAL-NAO-LIB-2. */
            _.Display($" PROPOSTAS NAO LIBER.{WS_AREA_WORK.WS_TOTAL_NAO_LIB_2}");

            /*" -745- DISPLAY ' PROPOSTAS NAO LIBER.' WS-TOTAL-NAO-LIB-3. */
            _.Display($" PROPOSTAS NAO LIBER.{WS_AREA_WORK.WS_TOTAL_NAO_LIB_3}");

            /*" -746- DISPLAY ' PROPOSTAS NAO LIBER.' WS-TOTAL-NAO-LIB-4. */
            _.Display($" PROPOSTAS NAO LIBER.{WS_AREA_WORK.WS_TOTAL_NAO_LIB_4}");

            /*" -747- DISPLAY ' PROPOSTAS NAO LIBER.' WS-TOTAL-NAO-LIB-5. */
            _.Display($" PROPOSTAS NAO LIBER.{WS_AREA_WORK.WS_TOTAL_NAO_LIB_5}");

            /*" -748- DISPLAY ' PROPOSTAS NAO LIBER.' WS-TOTAL-NAO-LIB-6. */
            _.Display($" PROPOSTAS NAO LIBER.{WS_AREA_WORK.WS_TOTAL_NAO_LIB_6}");

            /*" -750- DISPLAY ' PROPOSTAS NAO LIBER.' WS-TOTAL-NAO-LIB-7. */
            _.Display($" PROPOSTAS NAO LIBER.{WS_AREA_WORK.WS_TOTAL_NAO_LIB_7}");

            /*" -751- MOVE '00/00/0000' TO WS-DATA-CURR. */
            _.Move("00/00/0000", WS_AREA_WORK.WS_DATA_CURR);

            /*" -752- ACCEPT WS-DATA-ACCEPT FROM DATE. */
            _.Move(_.AcceptDate("DATE"), WS_AREA_WORK.WS_DATA_ACCEPT);

            /*" -753- MOVE WS-DIA-ACCEPT TO WS-DIA-CURR */
            _.Move(WS_AREA_WORK.WS_DATA_ACCEPT.WS_DIA_ACCEPT, WS_AREA_WORK.WS_DATA_CURR.WS_DIA_CURR);

            /*" -754- MOVE WS-MES-ACCEPT TO WS-MES-CURR */
            _.Move(WS_AREA_WORK.WS_DATA_ACCEPT.WS_MES_ACCEPT, WS_AREA_WORK.WS_DATA_CURR.WS_MES_CURR);

            /*" -755- MOVE WS-ANO-ACCEPT TO WS-ANO-CURR */
            _.Move(WS_AREA_WORK.WS_DATA_ACCEPT.WS_ANO_ACCEPT, WS_AREA_WORK.WS_DATA_CURR.WS_ANO_CURR);

            /*" -757- ADD 2000 TO WS-ANO-CURR. */
            WS_AREA_WORK.WS_DATA_CURR.WS_ANO_CURR.Value = WS_AREA_WORK.WS_DATA_CURR.WS_ANO_CURR + 2000;

            /*" -758- MOVE '00:00:00' TO WS-HORA-CURR. */
            _.Move("00:00:00", WS_AREA_WORK.WS_HORA_CURR);

            /*" -759- ACCEPT WS-HORA-ACCEPT FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WS_AREA_WORK.WS_HORA_ACCEPT);

            /*" -760- MOVE WS-HOR-ACCEPT TO WS-HOR-CURR */
            _.Move(WS_AREA_WORK.WS_HORA_ACCEPT.WS_HOR_ACCEPT, WS_AREA_WORK.WS_HORA_CURR.WS_HOR_CURR);

            /*" -761- MOVE WS-MIN-ACCEPT TO WS-MIN-CURR */
            _.Move(WS_AREA_WORK.WS_HORA_ACCEPT.WS_MIN_ACCEPT, WS_AREA_WORK.WS_HORA_CURR.WS_MIN_CURR);

            /*" -763- MOVE WS-SEG-ACCEPT TO WS-SEG-CURR. */
            _.Move(WS_AREA_WORK.WS_HORA_ACCEPT.WS_SEG_ACCEPT, WS_AREA_WORK.WS_HORA_CURR.WS_SEG_CURR);

            /*" -764- DISPLAY 'VA0061B - Final de execucao  (' WS-DATA-CURR ' - ' WS-HORA-CURR ')' . */

            $"VA0061B - Final de execucao  ({WS_AREA_WORK.WS_DATA_CURR} - {WS_AREA_WORK.WS_HORA_CURR})"
            .Display();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -777- DISPLAY WABEND */
            _.Display(WS_AREA_WORK.WS_HORA_CURR.WABEND);

            /*" -777- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -781- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -781- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -785- DISPLAY 'VA0061B - RETURN CODE = ' RETURN-CODE */
            _.Display($"VA0061B - RETURN CODE = {RETURN_CODE}");

            /*" -785- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}