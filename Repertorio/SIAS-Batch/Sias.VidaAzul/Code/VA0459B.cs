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
using Sias.VidaAzul.DB2.VA0459B;

namespace Code
{
    public class VA0459B
    {
        public bool IsCall { get; set; }

        public VA0459B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                    OBJETIVO DO PROGRAMA                        *      */
        /*"      ******************************************************************      */
        /*"      *     INCLUI REGISTRO NA TABELA RELATORIOS NA COLUNA COD_OPERACAO*      */
        /*"      *     A MENSAGEM (9 - DOENCA PRE EXISTENTE) PARA AS PROPOSTAS    *      */
        /*"      *     PENDENTES COM 30 DIAS DA EMISSAO.                          *      */
        /*"      *     O PROGRAMA VA0469B, QUE FAZ A DEVOLUCAO DA PARCELA PAGA    *      */
        /*"      *     VAI LER ESTE REGISTRO E PROCESSAR.                         *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO 02 - CAD 30.835                                       *      */
        /*"      *             - AO  ATUALIZAR  A  SITUACAO, ATUALIZAR  TAMBEM OS *      */
        /*"      *               CAMPOS DATA_MOVIMENTO E TIMESTAMP.               *      */
        /*"      *                                                                *      */
        /*"      *   EM 14/10/2009 - CESAR DALAZUANA (FAST COMPUTER)              *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.02    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01 - PASSOU A NAO MAIS GERAR ERROS_PROP_VIDAZUL       *      */
        /*"      *               PELO FATO DA NAO ACEITACAO SER PELOS ERROS       *      */
        /*"      *               1803 OU 1804 .                                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 12/09/2006 - FAST COMPUTER            PROCURE POR V.01    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77            WHOST-SITUACAO      PIC  X(01).*/
        public StringBasis WHOST_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77            WHOST-NRCERTIF      PIC S9(15) COMP-3.*/
        public IntBasis WHOST_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77            WHOST-QTDIAS        PIC S9(09) COMP.*/
        public IntBasis WHOST_QTDIAS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77            WHOST-NUMTIT        PIC S9(13) COMP-3.*/
        public IntBasis WHOST_NUMTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77            WHOST-APOLICE       PIC S9(13) COMP-3.*/
        public IntBasis WHOST_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77            WHOST-CODSUBES      PIC S9(04) COMP.*/
        public IntBasis WHOST_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            WHOST-COD-ESCNEG    PIC S9(04) COMP.*/
        public IntBasis WHOST_COD_ESCNEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            WHOST-DTINICIAL     PIC  X(10).*/
        public StringBasis WHOST_DTINICIAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            WHOST-DTFINAL       PIC  X(10).*/
        public StringBasis WHOST_DTFINAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            WHOST-ERROS         PIC S9(04) COMP.*/
        public IntBasis WHOST_ERROS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            WHOST-ACOMP         PIC S9(04) COMP.*/
        public IntBasis WHOST_ACOMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            VIND-DPS-TITULAR    PIC S9(04) COMP.*/
        public IntBasis VIND_DPS_TITULAR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            VIND-DPS-CONJUGE    PIC S9(04) COMP.*/
        public IntBasis VIND_DPS_CONJUGE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V1SIST-DTMOVABE     PIC  X(10).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V1SIST-DTMOVABE-30  PIC  X(10).*/
        public StringBasis V1SIST_DTMOVABE_30 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V1SIST-DTMOVABE-45  PIC  X(10).*/
        public StringBasis V1SIST_DTMOVABE_45 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V0CONT-DATCEF       PIC  X(10).*/
        public StringBasis V0CONT_DATCEF { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V0PROP-AGECOBR     PIC S9(04)    COMP.*/
        public IntBasis V0PROP_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0PROP-VLPREMIO    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0PROP_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77            V0PROP-IMPSEGUR    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0PROP_IMPSEGUR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77            V0PROP-SITUACAO    PIC  X(01).*/
        public StringBasis V0PROP_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77            V0PROP-APOLICE     PIC S9(13)    COMP-3.*/
        public IntBasis V0PROP_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77            V0PROP-CODSUBES    PIC S9(04)    COMP.*/
        public IntBasis V0PROP_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0PROP-NRCERTIF    PIC S9(15)    COMP-3.*/
        public IntBasis V0PROP_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77            V0PROP-CODUSU      PIC  X(08).*/
        public StringBasis V0PROP_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
        /*"77            V0PROP-CODCLIEN    PIC S9(09)    COMP.*/
        public IntBasis V0PROP_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77            V0PROP-OCOREND     PIC S9(04)    COMP.*/
        public IntBasis V0PROP_OCOREND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0PROP-DTQITBCO    PIC  X(10).*/
        public StringBasis V0PROP_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V0PROP-DTQITBCO30  PIC  X(10).*/
        public StringBasis V0PROP_DTQITBCO30 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V0PROP-DPS-TITULAR PIC  X(25).*/
        public StringBasis V0PROP_DPS_TITULAR { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
        /*"77            V0PROP-DPS-CONJUGE PIC  X(25).*/
        public StringBasis V0PROP_DPS_CONJUGE { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
        /*"77            V0ERROSP-DESCR-ERRO PIC X(40).*/
        public StringBasis V0ERROSP_DESCR_ERRO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77            CONV-NUM-SICOB     PIC S9(15)    COMP-3.*/
        public IntBasis CONV_NUM_SICOB { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77            CONV-NUMTIT        PIC S9(13)    COMP-3.*/
        public IntBasis CONV_NUMTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  WORK-AREA.*/
        public VA0459B_WORK_AREA WORK_AREA { get; set; } = new VA0459B_WORK_AREA();
        public class VA0459B_WORK_AREA : VarBasis
        {
            /*"    05        DATA-SQL.*/
            public VA0459B_DATA_SQL DATA_SQL { get; set; } = new VA0459B_DATA_SQL();
            public class VA0459B_DATA_SQL : VarBasis
            {
                /*"      10      ANO-SQL             PIC  9(004).*/
                public IntBasis ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10      MES-SQL             PIC  9(002).*/
                public IntBasis MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10      DIA-SQL             PIC  9(002).*/
                public IntBasis DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        IND                 PIC  9(005) VALUE ZEROS.*/
            }
            public IntBasis IND { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    05        WFIM-PROPOSTAS-VA    PIC   X(01)  VALUE  ' '.*/
            public StringBasis WFIM_PROPOSTAS_VA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"    05        WFIM-V0ERROSPROP    PIC   X(03)  VALUE  ' '.*/
            public StringBasis WFIM_V0ERROSPROP { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ");
            /*"    05        WFIM-V1SISTEMA      PIC   X(01)  VALUE  ' '.*/
            public StringBasis WFIM_V1SISTEMA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"    05        AC-LIDOS            PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-DESPR-PROPOVA    PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_DESPR_PROPOVA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-DESPR-VG078      PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_DESPR_VG078 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-DESPR-ERRPROVI   PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_DESPR_ERRPROVI { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-DESPR-RCAPS      PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_DESPR_RCAPS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-SELEC            PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_SELEC { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-GRAVA            PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_GRAVA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"01        WABEND.*/
        }
        public VA0459B_WABEND WABEND { get; set; } = new VA0459B_WABEND();
        public class VA0459B_WABEND : VarBasis
        {
            /*"    10      FILLER              PIC  X(010) VALUE           ' VA0459B'.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VA0459B");
            /*"    10      FILLER              PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"    10      WNR-EXEC-SQL        PIC  X(004) VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"    10      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
        }


        public VA0459B_TCOMIS TCOMIS { get; set; } = new VA0459B_TCOMIS();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -0- FLUXCONTROL_PERFORM M-0000-PRINCIPAL */

                M_0000_PRINCIPAL();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            return Result;
        }

        [StopWatch]
        /*" M-0000-PRINCIPAL */
        private void M_0000_PRINCIPAL(bool isPerform = false)
        {
            /*" -181- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -184- EXEC SQL WHENEVER SQLERROR GO TO R9999-00-ROT-ERRO END-EXEC. */

            /*" -187- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -189- PERFORM R0000-00-PRINCIPAL. */

            R0000_00_PRINCIPAL_SECTION();

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -197- MOVE '000' TO WNR-EXEC-SQL. */
            _.Move("000", WABEND.WNR_EXEC_SQL);

            /*" -198- DISPLAY 'PROGRAMA VA0459B - VERSAO V.02  CADMUS 30.835' . */
            _.Display($"PROGRAMA VA0459B - VERSAO V.02  CADMUS 30.835");

            /*" -200- DISPLAY ' ' . */
            _.Display($" ");

            /*" -202- PERFORM R0100-00-SELECT-V1SISTEMA. */

            R0100_00_SELECT_V1SISTEMA_SECTION();

            /*" -203- IF WFIM-V1SISTEMA NOT EQUAL SPACES */

            if (!WORK_AREA.WFIM_V1SISTEMA.IsEmpty())
            {

                /*" -204- DISPLAY '*** PROBLEMAS NA V0SISTEMA' */
                _.Display($"*** PROBLEMAS NA V0SISTEMA");

                /*" -205- MOVE 9 TO RETURN-CODE */
                _.Move(9, RETURN_CODE);

                /*" -207- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -209- PERFORM R0900-00-DECLARE-PROPOSTAS-VA. */

            R0900_00_DECLARE_PROPOSTAS_VA_SECTION();

            /*" -211- PERFORM R0910-00-FETCH-PROPOSTAS-VA. */

            R0910_00_FETCH_PROPOSTAS_VA_SECTION();

            /*" -212- IF WFIM-PROPOSTAS-VA EQUAL 'S' */

            if (WORK_AREA.WFIM_PROPOSTAS_VA == "S")
            {

                /*" -213- PERFORM R9800-00-ENCERRA-SEM-SOLIC */

                R9800_00_ENCERRA_SEM_SOLIC_SECTION();

                /*" -214- MOVE ZEROS TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -216- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -217- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-PROPOSTAS-VA EQUAL 'S' . */

            while (!(WORK_AREA.WFIM_PROPOSTAS_VA == "S"))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -223- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -223- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -226- DISPLAY '*** VA0459B - ' */
            _.Display($"*** VA0459B - ");

            /*" -227- DISPLAY 'LIDOS PROPOVA          ' AC-LIDOS */
            _.Display($"LIDOS PROPOVA          {WORK_AREA.AC_LIDOS}");

            /*" -228- DISPLAY 'SELECIONADOS PROPOVA   ' AC-SELEC */
            _.Display($"SELECIONADOS PROPOVA   {WORK_AREA.AC_SELEC}");

            /*" -229- DISPLAY 'DESPREZADOS  PROPOVA   ' AC-DESPR-PROPOVA */
            _.Display($"DESPREZADOS  PROPOVA   {WORK_AREA.AC_DESPR_PROPOVA}");

            /*" -230- DISPLAY 'DESPREZADOS  VG078     ' AC-DESPR-VG078 */
            _.Display($"DESPREZADOS  VG078     {WORK_AREA.AC_DESPR_VG078}");

            /*" -231- DISPLAY 'DESPREZADOS  ERRPROVI  ' AC-DESPR-ERRPROVI */
            _.Display($"DESPREZADOS  ERRPROVI  {WORK_AREA.AC_DESPR_ERRPROVI}");

            /*" -232- DISPLAY 'DESPREZADOS  RCAPS     ' AC-DESPR-RCAPS */
            _.Display($"DESPREZADOS  RCAPS     {WORK_AREA.AC_DESPR_RCAPS}");

            /*" -234- DISPLAY 'GRAVADOS RELATORIOS    ' AC-GRAVA. */
            _.Display($"GRAVADOS RELATORIOS    {WORK_AREA.AC_GRAVA}");

            /*" -236- DISPLAY '*** VA0459B - TERMINO NORMAL ***' */
            _.Display($"*** VA0459B - TERMINO NORMAL ***");

            /*" -236- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-SECTION */
        private void R0100_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -250- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", WABEND.WNR_EXEC_SQL);

            /*" -259- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -262- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -263- DISPLAY 'VA0459B - SISTEMA VA NAO ESTA CADASTRADO' */
                _.Display($"VA0459B - SISTEMA VA NAO ESTA CADASTRADO");

                /*" -264- MOVE 'S' TO WFIM-V1SISTEMA */
                _.Move("S", WORK_AREA.WFIM_V1SISTEMA);

                /*" -266- GO TO R0100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -266- MOVE V1SIST-DTMOVABE TO DATA-SQL. */
            _.Move(V1SIST_DTMOVABE, WORK_AREA.DATA_SQL);

        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -259- EXEC SQL SELECT DTMOVABE , DTMOVABE - 30 DAYS , DTMOVABE - 45 DAYS INTO :V1SIST-DTMOVABE , :V1SIST-DTMOVABE-30 , :V1SIST-DTMOVABE-45 FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VA' END-EXEC. */

            var r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
                _.Move(executed_1.V1SIST_DTMOVABE_30, V1SIST_DTMOVABE_30);
                _.Move(executed_1.V1SIST_DTMOVABE_45, V1SIST_DTMOVABE_45);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-PROPOSTAS-VA-SECTION */
        private void R0900_00_DECLARE_PROPOSTAS_VA_SECTION()
        {
            /*" -280- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", WABEND.WNR_EXEC_SQL);

            /*" -299- PERFORM R0900_00_DECLARE_PROPOSTAS_VA_DB_DECLARE_1 */

            R0900_00_DECLARE_PROPOSTAS_VA_DB_DECLARE_1();

            /*" -301- PERFORM R0900_00_DECLARE_PROPOSTAS_VA_DB_OPEN_1 */

            R0900_00_DECLARE_PROPOSTAS_VA_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0900-00-DECLARE-PROPOSTAS-VA-DB-DECLARE-1 */
        public void R0900_00_DECLARE_PROPOSTAS_VA_DB_DECLARE_1()
        {
            /*" -299- EXEC SQL DECLARE TCOMIS CURSOR FOR SELECT B.NUM_APOLICE, B.CODSUBES, B.NRCERTIF, B.DTQITBCO, B.DTQITBCO + 30 DAYS, B.SITUACAO, B.DPS_TITULAR, B.DPS_ESPOSA FROM SEGUROS.V0PRODUTOSVG A, SEGUROS.V0PROPOSTAVA B, SEGUROS.V0COBERPROPVA C WHERE B.NUM_APOLICE = A.NUM_APOLICE AND B.CODSUBES = A.CODSUBES AND B.SITUACAO IN ( '1' , '9' , 'E' ) AND C.OCORHIST = B.OCORHIST AND C.NRCERTIF = B.NRCERTIF END-EXEC. */
            TCOMIS = new VA0459B_TCOMIS(false);
            string GetQuery_TCOMIS()
            {
                var query = @$"SELECT 
							B.NUM_APOLICE
							, 
							B.CODSUBES
							, 
							B.NRCERTIF
							, 
							B.DTQITBCO
							, 
							B.DTQITBCO + 30 DAYS
							, 
							B.SITUACAO
							, 
							B.DPS_TITULAR
							, 
							B.DPS_ESPOSA 
							FROM SEGUROS.V0PRODUTOSVG A
							, 
							SEGUROS.V0PROPOSTAVA B
							, 
							SEGUROS.V0COBERPROPVA C 
							WHERE B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.CODSUBES = A.CODSUBES 
							AND B.SITUACAO IN ( '1'
							, '9'
							, 'E' ) 
							AND C.OCORHIST = B.OCORHIST 
							AND C.NRCERTIF = B.NRCERTIF";

                return query;
            }
            TCOMIS.GetQueryEvent += GetQuery_TCOMIS;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-PROPOSTAS-VA-DB-OPEN-1 */
        public void R0900_00_DECLARE_PROPOSTAS_VA_DB_OPEN_1()
        {
            /*" -301- EXEC SQL OPEN TCOMIS END-EXEC. */

            TCOMIS.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-PROPOSTAS-VA-SECTION */
        private void R0910_00_FETCH_PROPOSTAS_VA_SECTION()
        {
            /*" -315- MOVE '091' TO WNR-EXEC-SQL. */
            _.Move("091", WABEND.WNR_EXEC_SQL);

            /*" -325- PERFORM R0910_00_FETCH_PROPOSTAS_VA_DB_FETCH_1 */

            R0910_00_FETCH_PROPOSTAS_VA_DB_FETCH_1();

            /*" -328- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -329- MOVE 'S' TO WFIM-PROPOSTAS-VA */
                _.Move("S", WORK_AREA.WFIM_PROPOSTAS_VA);

                /*" -329- PERFORM R0910_00_FETCH_PROPOSTAS_VA_DB_CLOSE_1 */

                R0910_00_FETCH_PROPOSTAS_VA_DB_CLOSE_1();

                /*" -332- GO TO R0910-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                return;
            }


            /*" -335- IF V0PROP-DTQITBCO <= V1SIST-DTMOVABE-30 AND V0PROP-DTQITBCO >= V1SIST-DTMOVABE-45 NEXT SENTENCE */

            if (V0PROP_DTQITBCO <= V1SIST_DTMOVABE_30 && V0PROP_DTQITBCO >= V1SIST_DTMOVABE_45)
            {

                /*" -336- ELSE */
            }
            else
            {


                /*" -337- ADD 1 TO AC-DESPR-PROPOVA */
                WORK_AREA.AC_DESPR_PROPOVA.Value = WORK_AREA.AC_DESPR_PROPOVA + 1;

                /*" -339- GO TO R0910-00-FETCH-PROPOSTAS-VA. */
                new Task(() => R0910_00_FETCH_PROPOSTAS_VA_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -339- ADD 1 TO AC-LIDOS. */
            WORK_AREA.AC_LIDOS.Value = WORK_AREA.AC_LIDOS + 1;

        }

        [StopWatch]
        /*" R0910-00-FETCH-PROPOSTAS-VA-DB-FETCH-1 */
        public void R0910_00_FETCH_PROPOSTAS_VA_DB_FETCH_1()
        {
            /*" -325- EXEC SQL FETCH TCOMIS INTO :V0PROP-APOLICE, :V0PROP-CODSUBES, :V0PROP-NRCERTIF, :V0PROP-DTQITBCO, :V0PROP-DTQITBCO30, :V0PROP-SITUACAO, :V0PROP-DPS-TITULAR:VIND-DPS-TITULAR, :V0PROP-DPS-CONJUGE:VIND-DPS-CONJUGE END-EXEC. */

            if (TCOMIS.Fetch())
            {
                _.Move(TCOMIS.V0PROP_APOLICE, V0PROP_APOLICE);
                _.Move(TCOMIS.V0PROP_CODSUBES, V0PROP_CODSUBES);
                _.Move(TCOMIS.V0PROP_NRCERTIF, V0PROP_NRCERTIF);
                _.Move(TCOMIS.V0PROP_DTQITBCO, V0PROP_DTQITBCO);
                _.Move(TCOMIS.V0PROP_DTQITBCO30, V0PROP_DTQITBCO30);
                _.Move(TCOMIS.V0PROP_SITUACAO, V0PROP_SITUACAO);
                _.Move(TCOMIS.V0PROP_DPS_TITULAR, V0PROP_DPS_TITULAR);
                _.Move(TCOMIS.VIND_DPS_TITULAR, VIND_DPS_TITULAR);
                _.Move(TCOMIS.V0PROP_DPS_CONJUGE, V0PROP_DPS_CONJUGE);
                _.Move(TCOMIS.VIND_DPS_CONJUGE, VIND_DPS_CONJUGE);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-PROPOSTAS-VA-DB-CLOSE-1 */
        public void R0910_00_FETCH_PROPOSTAS_VA_DB_CLOSE_1()
        {
            /*" -329- EXEC SQL CLOSE TCOMIS END-EXEC */

            TCOMIS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -353- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", WABEND.WNR_EXEC_SQL);

            /*" -355- PERFORM R1050-00-SELECT-V0ERROSPROPVA. */

            R1050_00_SELECT_V0ERROSPROPVA_SECTION();

            /*" -357- IF WHOST-ERROS GREATER 0 NEXT SENTENCE */

            if (WHOST_ERROS > 0)
            {

                /*" -358- ELSE */
            }
            else
            {


                /*" -359- ADD 1 TO AC-DESPR-ERRPROVI */
                WORK_AREA.AC_DESPR_ERRPROVI.Value = WORK_AREA.AC_DESPR_ERRPROVI + 1;

                /*" -360- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -362- END-IF. */
            }


            /*" -364- ADD 1 TO AC-SELEC. */
            WORK_AREA.AC_SELEC.Value = WORK_AREA.AC_SELEC + 1;

            /*" -366- PERFORM R1010-00-SELECT-CONVERSAO. */

            R1010_00_SELECT_CONVERSAO_SECTION();

            /*" -367- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -368- MOVE CONV-NUM-SICOB TO WHOST-NUMTIT */
                _.Move(CONV_NUM_SICOB, WHOST_NUMTIT);

                /*" -369- ELSE */
            }
            else
            {


                /*" -371- MOVE V0PROP-NRCERTIF TO WHOST-NUMTIT. */
                _.Move(V0PROP_NRCERTIF, WHOST_NUMTIT);
            }


            /*" -373- PERFORM R1020-00-SELECT-V0RCAP. */

            R1020_00_SELECT_V0RCAP_SECTION();

            /*" -374- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -375- PERFORM R2000-00-INSERT-RELATORIOS */

                R2000_00_INSERT_RELATORIOS_SECTION();

                /*" -379- END-IF. */
            }


            /*" -379- PERFORM R2200-00-UPDATE-PROPOVA. */

            R2200_00_UPDATE_PROPOVA_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R1000_10_NEXT */

            R1000_10_NEXT();

        }

        [StopWatch]
        /*" R1000-10-NEXT */
        private void R1000_10_NEXT(bool isPerform = false)
        {
            /*" -383- PERFORM R0910-00-FETCH-PROPOSTAS-VA. */

            R0910_00_FETCH_PROPOSTAS_VA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1010-00-SELECT-CONVERSAO-SECTION */
        private void R1010_00_SELECT_CONVERSAO_SECTION()
        {
            /*" -397- MOVE '101' TO WNR-EXEC-SQL. */
            _.Move("101", WABEND.WNR_EXEC_SQL);

            /*" -402- PERFORM R1010_00_SELECT_CONVERSAO_DB_SELECT_1 */

            R1010_00_SELECT_CONVERSAO_DB_SELECT_1();

            /*" -405- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -407- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -408- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -408- MOVE CONV-NUM-SICOB TO CONV-NUMTIT. */
                _.Move(CONV_NUM_SICOB, CONV_NUMTIT);
            }


        }

        [StopWatch]
        /*" R1010-00-SELECT-CONVERSAO-DB-SELECT-1 */
        public void R1010_00_SELECT_CONVERSAO_DB_SELECT_1()
        {
            /*" -402- EXEC SQL SELECT NUM_SICOB INTO :CONV-NUM-SICOB FROM SEGUROS.CONVERSAO_SICOB WHERE NUM_PROPOSTA_SIVPF = :V0PROP-NRCERTIF END-EXEC. */

            var r1010_00_SELECT_CONVERSAO_DB_SELECT_1_Query1 = new R1010_00_SELECT_CONVERSAO_DB_SELECT_1_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R1010_00_SELECT_CONVERSAO_DB_SELECT_1_Query1.Execute(r1010_00_SELECT_CONVERSAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONV_NUM_SICOB, CONV_NUM_SICOB);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_99_SAIDA*/

        [StopWatch]
        /*" R1020-00-SELECT-V0RCAP-SECTION */
        private void R1020_00_SELECT_V0RCAP_SECTION()
        {
            /*" -422- MOVE '102' TO WNR-EXEC-SQL. */
            _.Move("102", WABEND.WNR_EXEC_SQL);

            /*" -431- PERFORM R1020_00_SELECT_V0RCAP_DB_SELECT_1 */

            R1020_00_SELECT_V0RCAP_DB_SELECT_1();

            /*" -434- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -434- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1020-00-SELECT-V0RCAP-DB-SELECT-1 */
        public void R1020_00_SELECT_V0RCAP_DB_SELECT_1()
        {
            /*" -431- EXEC SQL SELECT SITUACAO INTO :WHOST-SITUACAO FROM SEGUROS.V0RCAP WHERE NRTIT = :WHOST-NUMTIT AND OPERACAO >= 100 AND OPERACAO <= 299 AND SITUACAO = '0' END-EXEC. */

            var r1020_00_SELECT_V0RCAP_DB_SELECT_1_Query1 = new R1020_00_SELECT_V0RCAP_DB_SELECT_1_Query1()
            {
                WHOST_NUMTIT = WHOST_NUMTIT.ToString(),
            };

            var executed_1 = R1020_00_SELECT_V0RCAP_DB_SELECT_1_Query1.Execute(r1020_00_SELECT_V0RCAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_SITUACAO, WHOST_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1020_99_SAIDA*/

        [StopWatch]
        /*" R1030-00-SELECT-VG078-SECTION */
        private void R1030_00_SELECT_VG078_SECTION()
        {
            /*" -448- MOVE '103' TO WNR-EXEC-SQL. */
            _.Move("103", WABEND.WNR_EXEC_SQL);

            /*" -453- PERFORM R1030_00_SELECT_VG078_DB_SELECT_1 */

            R1030_00_SELECT_VG078_DB_SELECT_1();

        }

        [StopWatch]
        /*" R1030-00-SELECT-VG078-DB-SELECT-1 */
        public void R1030_00_SELECT_VG078_DB_SELECT_1()
        {
            /*" -453- EXEC SQL SELECT COUNT(*) INTO :WHOST-ACOMP FROM SEGUROS.VG_ANDAMENTO_PROP WHERE NUM_CERTIFICADO = :V0PROP-NRCERTIF END-EXEC. */

            var r1030_00_SELECT_VG078_DB_SELECT_1_Query1 = new R1030_00_SELECT_VG078_DB_SELECT_1_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R1030_00_SELECT_VG078_DB_SELECT_1_Query1.Execute(r1030_00_SELECT_VG078_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_ACOMP, WHOST_ACOMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1030_99_SAIDA*/

        [StopWatch]
        /*" R1050-00-SELECT-V0ERROSPROPVA-SECTION */
        private void R1050_00_SELECT_V0ERROSPROPVA_SECTION()
        {
            /*" -467- MOVE '105' TO WNR-EXEC-SQL. */
            _.Move("105", WABEND.WNR_EXEC_SQL);

            /*" -473- PERFORM R1050_00_SELECT_V0ERROSPROPVA_DB_SELECT_1 */

            R1050_00_SELECT_V0ERROSPROPVA_DB_SELECT_1();

        }

        [StopWatch]
        /*" R1050-00-SELECT-V0ERROSPROPVA-DB-SELECT-1 */
        public void R1050_00_SELECT_V0ERROSPROPVA_DB_SELECT_1()
        {
            /*" -473- EXEC SQL SELECT COUNT(*) INTO :WHOST-ERROS FROM SEGUROS.V0ERROSPROPVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND COD_ERRO IN (1803, 1804) END-EXEC. */

            var r1050_00_SELECT_V0ERROSPROPVA_DB_SELECT_1_Query1 = new R1050_00_SELECT_V0ERROSPROPVA_DB_SELECT_1_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R1050_00_SELECT_V0ERROSPROPVA_DB_SELECT_1_Query1.Execute(r1050_00_SELECT_V0ERROSPROPVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_ERROS, WHOST_ERROS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1050_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-INSERT-RELATORIOS-SECTION */
        private void R2000_00_INSERT_RELATORIOS_SECTION()
        {
            /*" -487- MOVE '200' TO WNR-EXEC-SQL. */
            _.Move("200", WABEND.WNR_EXEC_SQL);

            /*" -530- PERFORM R2000_00_INSERT_RELATORIOS_DB_INSERT_1 */

            R2000_00_INSERT_RELATORIOS_DB_INSERT_1();

            /*" -533- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -535- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -535- ADD 1 TO AC-GRAVA. */
            WORK_AREA.AC_GRAVA.Value = WORK_AREA.AC_GRAVA + 1;

        }

        [StopWatch]
        /*" R2000-00-INSERT-RELATORIOS-DB-INSERT-1 */
        public void R2000_00_INSERT_RELATORIOS_DB_INSERT_1()
        {
            /*" -530- EXEC SQL INSERT INTO SEGUROS.RELATORIOS VALUES ( 'VA0459B' , :V1SIST-DTMOVABE, 'VA' , 'VA0469B' , 0, 0, :V1SIST-DTMOVABE, :V1SIST-DTMOVABE, :V1SIST-DTMOVABE, 0, 0, 0, 0, 0, 0, 0, 0, :V0PROP-APOLICE, 0, 1, :V0PROP-NRCERTIF, 0, :V0PROP-CODSUBES, 9, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '0' , ' ' , ' ' , NULL, 0, 0, CURRENT TIMESTAMP) END-EXEC. */

            var r2000_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1 = new R2000_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1()
            {
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
                V0PROP_APOLICE = V0PROP_APOLICE.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_CODSUBES = V0PROP_CODSUBES.ToString(),
            };

            R2000_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1.Execute(r2000_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-INSERT-ERRPROVI-SECTION */
        private void R2100_00_INSERT_ERRPROVI_SECTION()
        {
            /*" -549- MOVE '210' TO WNR-EXEC-SQL. */
            _.Move("210", WABEND.WNR_EXEC_SQL);

            /*" -553- PERFORM R2100_00_INSERT_ERRPROVI_DB_INSERT_1 */

            R2100_00_INSERT_ERRPROVI_DB_INSERT_1();

            /*" -556- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -556- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2100-00-INSERT-ERRPROVI-DB-INSERT-1 */
        public void R2100_00_INSERT_ERRPROVI_DB_INSERT_1()
        {
            /*" -553- EXEC SQL INSERT INTO SEGUROS.ERROS_PROP_VIDAZUL VALUES ( :V0PROP-NRCERTIF, 1846 ) END-EXEC. */

            var r2100_00_INSERT_ERRPROVI_DB_INSERT_1_Insert1 = new R2100_00_INSERT_ERRPROVI_DB_INSERT_1_Insert1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            R2100_00_INSERT_ERRPROVI_DB_INSERT_1_Insert1.Execute(r2100_00_INSERT_ERRPROVI_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-UPDATE-PROPOVA-SECTION */
        private void R2200_00_UPDATE_PROPOVA_SECTION()
        {
            /*" -570- MOVE '220' TO WNR-EXEC-SQL. */
            _.Move("220", WABEND.WNR_EXEC_SQL);

            /*" -576- PERFORM R2200_00_UPDATE_PROPOVA_DB_UPDATE_1 */

            R2200_00_UPDATE_PROPOVA_DB_UPDATE_1();

            /*" -579- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -579- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2200-00-UPDATE-PROPOVA-DB-UPDATE-1 */
        public void R2200_00_UPDATE_PROPOVA_DB_UPDATE_1()
        {
            /*" -576- EXEC SQL UPDATE SEGUROS.PROPOSTAS_VA SET SIT_REGISTRO = '2' , DATA_MOVIMENTO = :V1SIST-DTMOVABE, TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_CERTIFICADO = :V0PROP-NRCERTIF END-EXEC. */

            var r2200_00_UPDATE_PROPOVA_DB_UPDATE_1_Update1 = new R2200_00_UPDATE_PROPOVA_DB_UPDATE_1_Update1()
            {
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            R2200_00_UPDATE_PROPOVA_DB_UPDATE_1_Update1.Execute(r2200_00_UPDATE_PROPOVA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R9800-00-ENCERRA-SEM-SOLIC-SECTION */
        private void R9800_00_ENCERRA_SEM_SOLIC_SECTION()
        {
            /*" -594- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -595- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -596- DISPLAY '*   VA0459B - MOVIMENTO     DO     DIA     *' */
            _.Display($"*   VA0459B - MOVIMENTO     DO     DIA     *");

            /*" -597- DISPLAY '*   -------   ---------------------------  *' */
            _.Display($"*   -------   ---------------------------  *");

            /*" -598- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -599- DISPLAY '*             NAO EXISTE PRODUCAO PARA     *' */
            _.Display($"*             NAO EXISTE PRODUCAO PARA     *");

            /*" -600- DISPLAY '*             O PERIODO PEDIDO.            *' */
            _.Display($"*             O PERIODO PEDIDO.            *");

            /*" -601- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -601- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9800_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -615- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -617- DISPLAY WABEND */
            _.Display(WABEND);

            /*" -617- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -619- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -623- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -623- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}