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
using Sias.Sinistro.DB2.SI0181B;

namespace Code
{
    public class SI0181B
    {
        public bool IsCall { get; set; }

        public SI0181B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SINISTRO                           *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  SI0181B.                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  JEFFERSON                          *      */
        /*"      *   PROG/ANALISTA...........  JEFFERSON                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  EMITIR ARQUIVO PARA A GESEG COM TO *      */
        /*"      *                             DAS AS MOVIMENTACOES OCORRIDAS NO  *      */
        /*"      *                             DIA, EXCETO AS DE AJUSTE DE RESERVA*      */
        /*"      *                             ATENDIMENTO AO CADMUS 53552.       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * NO   VERSAO    DATA       RESPONSAVEL           ALTERACAO      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _ARQSAIDA { get; set; } = new FileBasis(new PIC("X", "350", "X(350)"));

        public FileBasis ARQSAIDA
        {
            get
            {
                _.Move(REG_SAIDA, _ARQSAIDA); VarBasis.RedefinePassValue(REG_SAIDA, _ARQSAIDA, REG_SAIDA); return _ARQSAIDA;
            }
        }
        /*"01              REG-SAIDA         PIC  X(350).*/
        public StringBasis REG_SAIDA { get; set; } = new StringBasis(new PIC("X", "350", "X(350)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01      WHOST-SIT-MOVIMENTO    PIC  X(025)      VALUE SPACES.*/
        public StringBasis WHOST_SIT_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
        /*"01      AREA-DE-WORK.*/
        public SI0181B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SI0181B_AREA_DE_WORK();
        public class SI0181B_AREA_DE_WORK : VarBasis
        {
            /*"  05    WFIM-RELAT             PIC  X(001)      VALUE SPACE.*/
            public StringBasis WFIM_RELAT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05    AC-LIDOS-RELAT         PIC  9(006)      VALUE ZEROS.*/
            public IntBasis AC_LIDOS_RELAT { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05    AC-REG-GRAVADO1        PIC  9(006)      VALUE ZEROS.*/
            public IntBasis AC_REG_GRAVADO1 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"01           FILLER.*/
        }
        public SI0181B_FILLER_0 FILLER_0 { get; set; } = new SI0181B_FILLER_0();
        public class SI0181B_FILLER_0 : VarBasis
        {
            /*"  05         SI-DATA-REL.*/
            public SI0181B_SI_DATA_REL SI_DATA_REL { get; set; } = new SI0181B_SI_DATA_REL();
            public class SI0181B_SI_DATA_REL : VarBasis
            {
                /*"     10      SI-DD-REL         PIC  9(002)      VALUE ZEROS.*/
                public IntBasis SI_DD_REL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"     10      FILLER            PIC  X(001)      VALUE '/'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"     10      SI-MM-REL         PIC  9(002)      VALUE ZEROS.*/
                public IntBasis SI_MM_REL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"     10      FILLER            PIC  X(001)      VALUE '/'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"     10      SI-AA-REL         PIC  9(004)      VALUE ZEROS.*/
                public IntBasis SI_AA_REL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05         SI-DATE.*/
            }
            public SI0181B_SI_DATE SI_DATE { get; set; } = new SI0181B_SI_DATE();
            public class SI0181B_SI_DATE : VarBasis
            {
                /*"     10      SI-AA-DATE        PIC  9(004)      VALUE ZEROS.*/
                public IntBasis SI_AA_DATE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"     10      FILLER            PIC  X(001)      VALUE SPACES.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"     10      SI-MM-DATE        PIC  9(002)      VALUE ZEROS.*/
                public IntBasis SI_MM_DATE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"     10      FILLER            PIC  X(001)      VALUE SPACES.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"     10      SI-DD-DATE        PIC  9(002)      VALUE ZEROS.*/
                public IntBasis SI_DD_DATE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"01          LC-01.*/
            }
        }
        public SI0181B_LC_01 LC_01 { get; set; } = new SI0181B_LC_01();
        public class SI0181B_LC_01 : VarBasis
        {
            /*"     05     LC01-DTH-MOVTO        PIC  X(010)   VALUE                                  'DTH-MOVTO '.*/
            public StringBasis LC01_DTH_MOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DTH-MOVTO ");
            /*"     05     FILLER                PIC  X(001)   VALUE SPACES.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"     05     LC01-HOR-MOVTO        PIC  X(008)   VALUE                                  'HOR-MOVT'.*/
            public StringBasis LC01_HOR_MOVTO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"HOR-MOVT");
            /*"     05     FILLER                PIC  X(001)   VALUE ';'.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"     05     LC01-COD-USUARIO      PIC  X(008)   VALUE                                  'USUARIO '.*/
            public StringBasis LC01_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"USUARIO ");
            /*"     05     FILLER                PIC  X(001)   VALUE ';'.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"     05     LC01-NOM-USUARIO      PIC  X(050)   VALUE                                  'NOM-USUARIO'.*/
            public StringBasis LC01_NOM_USUARIO { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"NOM-USUARIO");
            /*"     05     FILLER                PIC  X(001)   VALUE ';'.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"     05     LC01-COD-PRODUTO      PIC  X(004)   VALUE                                  'PROD'.*/
            public StringBasis LC01_COD_PRODUTO { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"PROD");
            /*"     05     FILLER                PIC  X(001)   VALUE ';'.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"     05     LC01-NUM-APOLICE      PIC  X(013)   VALUE                                  'NUM-APOLICE'.*/
            public StringBasis LC01_NUM_APOLICE { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"NUM-APOLICE");
            /*"     05     FILLER                PIC  X(001)   VALUE ';'.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"     05     LC01-NUM-SINISTRO     PIC  X(013)   VALUE                                  'NUM-SINISTRO'.*/
            public StringBasis LC01_NUM_SINISTRO { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"NUM-SINISTRO");
            /*"     05     FILLER                PIC  X(001)   VALUE ';'.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"     05     LC01-VAL-OPERACAO     PIC  X(012)   VALUE                                  'VAL-OPERACAO'.*/
            public StringBasis LC01_VAL_OPERACAO { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"VAL-OPERACAO");
            /*"     05     FILLER                PIC  X(001)   VALUE ';'.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"     05     LC01-NOM-FAVORECIDO   PIC  X(050)   VALUE                                  'NOM-FAVORECIDO'.*/
            public StringBasis LC01_NOM_FAVORECIDO { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"NOM-FAVORECIDO");
            /*"     05     FILLER                PIC  X(001)   VALUE ';'.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"     05     LC01-NOM-PROGRAMA     PIC  X(008)   VALUE                                  'PROGRAMA'.*/
            public StringBasis LC01_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"PROGRAMA");
            /*"     05     FILLER                PIC  X(001)   VALUE ';'.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"     05     LC01-NOM-CAMINHO-SIAS PIC  X(050)   VALUE                                  'NOM-CAMINHO-SIAS'.*/
            public StringBasis LC01_NOM_CAMINHO_SIAS { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"NOM-CAMINHO-SIAS");
            /*"     05     FILLER                PIC  X(001)   VALUE ';'.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"     05     LC01-COD-OPERACAO     PIC  X(004)   VALUE                                  'OPER'.*/
            public StringBasis LC01_COD_OPERACAO { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"OPER");
            /*"     05     FILLER                PIC  X(012)   VALUE SPACES.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"");
            /*"01        LD-01.*/
        }
        public SI0181B_LD_01 LD_01 { get; set; } = new SI0181B_LD_01();
        public class SI0181B_LD_01 : VarBasis
        {
            /*"  05      DET1-DTH-MOVIMENTO      PIC  X(010)  VALUE SPACES.*/
            public StringBasis DET1_DTH_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05      FILLER                  PIC  X(001)  VALUE SPACES.*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05      DET1-HOR-MOVIMENTO      PIC  X(008)  VALUE SPACES.*/
            public StringBasis DET1_HOR_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"  05      FILLER                  PIC  X(001)  VALUE ';'.*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05      DET1-COD-USUARIO        PIC  X(008)  VALUE SPACES.*/
            public StringBasis DET1_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"  05      FILLER                  PIC  X(001)  VALUE ';'.*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05      DET1-NOM-USUARIO        PIC  X(050)  VALUE SPACES.*/
            public StringBasis DET1_NOM_USUARIO { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
            /*"  05      FILLER                  PIC  X(001)  VALUE ';'.*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05      DET1-COD-PRODUTO        PIC  9(004)  VALUE ZEROS.*/
            public IntBasis DET1_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05      FILLER                  PIC  X(001)  VALUE ';'.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05      DET1-NUM-APOLICE        PIC  9(013)  VALUE ZEROS.*/
            public IntBasis DET1_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  05      FILLER                  PIC  X(001)  VALUE ';'.*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05      DET1-NUM-SINISTRO       PIC  9(013)  VALUE ZEROS.*/
            public IntBasis DET1_NUM_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  05      FILLER                  PIC  X(001)  VALUE ';'.*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05      DET1-VAL-OPERACAO       PIC  --------9,99.*/
            public DoubleBasis DET1_VAL_OPERACAO { get; set; } = new DoubleBasis(new PIC("9", "9", "--------9V99."), 2);
            /*"  05      FILLER                  PIC  X(001)  VALUE ';'.*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05      DET1-NOM-FAVORECIDO     PIC  X(050)  VALUE SPACES.*/
            public StringBasis DET1_NOM_FAVORECIDO { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
            /*"  05      FILLER                  PIC  X(001)  VALUE ';'.*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05      DET1-NOM-PROGRAMA       PIC  X(008)  VALUE SPACES.*/
            public StringBasis DET1_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"  05      FILLER                  PIC  X(001)  VALUE ';'.*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05      DET1-NOM-CAMINHO-SIAS   PIC  X(050)  VALUE SPACES.*/
            public StringBasis DET1_NOM_CAMINHO_SIAS { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
            /*"  05      FILLER                  PIC  X(001)  VALUE ';'.*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05      DET1-COD-OPERACAO       PIC  9(004)  VALUE ZEROS.*/
            public IntBasis DET1_COD_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05      FILLER                  PIC  X(001)  VALUE ';'.*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05      DET1-DES-OPERACAO       PIC  X(070)  VALUE SPACES.*/
            public StringBasis DET1_DES_OPERACAO { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
            /*"  05      FILLER                  PIC  X(001)  VALUE ';'.*/
            public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05      DET1-SIT-MOVIMENTO      PIC  X(025)  VALUE SPACES.*/
            public StringBasis DET1_SIT_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
            /*"  05      FILLER                  PIC  X(012)  VALUE SPACES.*/
            public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"");
            /*" 01  WABEND.*/
            public SI0181B_WABEND WABEND { get; set; } = new SI0181B_WABEND();
            public class SI0181B_WABEND : VarBasis
            {
                /*"     03  WS-PROG             PIC X(007) VALUE 'SI0181B'.*/
                public StringBasis WS_PROG { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"SI0181B");
                /*"     03   FILLER             PIC X(017) VALUE ' *** ERRO ROTINA'*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @" *** ERRO ROTINA");
                /*"     03   WNR-EXEC-SQL       PIC X(022) VALUE SPACES.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "22", "X(022)"), @"");
                /*"     03   FILLER             PIC X(013) VALUE ' *** SQLCODE '.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"     03   WSQLCODE           PIC ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"     03   FILLER             PIC X(013) VALUE ' TABELA '.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" TABELA ");
                /*"     03   WTABELA            PIC X(025) VALUE SPACES.*/
                public StringBasis WTABELA { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
                /*" 01  WSQLERRO.*/
            }
            public SI0181B_WSQLERRO WSQLERRO { get; set; } = new SI0181B_WSQLERRO();
            public class SI0181B_WSQLERRO : VarBasis
            {
                /*"     03   FILLER             PIC X(014) VALUE ' *** SQLERRMC '.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @" *** SQLERRMC ");
                /*"     03   WSQLERRMC          PIC X(070) VALUE SPACES.*/
                public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
            }
        }


        public Dclgens.SINIHAB1 SINIHAB1 { get; set; } = new Dclgens.SINIHAB1();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.GEOPERAC GEOPERAC { get; set; } = new Dclgens.GEOPERAC();
        public Dclgens.USUARIOS USUARIOS { get; set; } = new Dclgens.USUARIOS();
        public Dclgens.ESTRUTUR ESTRUTUR { get; set; } = new Dclgens.ESTRUTUR();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public SI0181B_PRINCIPAL PRINCIPAL { get; set; } = new SI0181B_PRINCIPAL();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string ARQSAIDA_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                ARQSAIDA.SetFile(ARQSAIDA_FILE_NAME_P);

                /*" -190- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", LD_01.WABEND.WNR_EXEC_SQL);

                /*" -191- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -194- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -197- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -197- FLUXCONTROL_PERFORM R0000-00-INICIO-SECTION */

                R0000_00_INICIO_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-INICIO-SECTION */
        private void R0000_00_INICIO_SECTION()
        {
            /*" -205- PERFORM 010-000-INICIALIZA. */

            M_010_000_INICIALIZA_SECTION();

            /*" -207- PERFORM 100-000-PROCESSA. */

            M_100_000_PROCESSA_SECTION();

            /*" -208- IF AC-LIDOS-RELAT EQUAL ZEROS */

            if (AREA_DE_WORK.AC_LIDOS_RELAT == 00)
            {

                /*" -209- DISPLAY ' NAO HOUVE SOLICITACAO NESTA DATA ' */
                _.Display($" NAO HOUVE SOLICITACAO NESTA DATA ");

                /*" -210- STOP RUN */

                throw new GoBack();   // => STOP RUN.

                /*" -212- END-IF. */
            }


            /*" -214- PERFORM 900-000-FINALIZA. */

            M_900_000_FINALIZA_SECTION();

            /*" -214- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_EXIT*/

        [StopWatch]
        /*" M-010-000-INICIALIZA-SECTION */
        private void M_010_000_INICIALIZA_SECTION()
        {
            /*" -225- PERFORM R0090-00-OBTER-DATA-SISTEMA. */

            R0090_00_OBTER_DATA_SISTEMA_SECTION();

            /*" -226- MOVE SISTEMAS-DATA-MOV-ABERTO TO SI-DATE. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, FILLER_0.SI_DATE);

            /*" -227- MOVE SI-AA-DATE TO SI-AA-REL. */
            _.Move(FILLER_0.SI_DATE.SI_AA_DATE, FILLER_0.SI_DATA_REL.SI_AA_REL);

            /*" -228- MOVE SI-MM-DATE TO SI-MM-REL. */
            _.Move(FILLER_0.SI_DATE.SI_MM_DATE, FILLER_0.SI_DATA_REL.SI_MM_REL);

            /*" -230- MOVE SI-DD-DATE TO SI-DD-REL. */
            _.Move(FILLER_0.SI_DATE.SI_DD_DATE, FILLER_0.SI_DATA_REL.SI_DD_REL);

            /*" -231- DISPLAY '---------------------------------------------' */
            _.Display($"---------------------------------------------");

            /*" -232- DISPLAY ' INICIO SI0181B       DATA : ' SI-DATA-REL */
            _.Display($" INICIO SI0181B       DATA : {FILLER_0.SI_DATA_REL}");

            /*" -234- DISPLAY '---------------------------------------------' */
            _.Display($"---------------------------------------------");

            /*" -234- OPEN OUTPUT ARQSAIDA. */
            ARQSAIDA.Open(REG_SAIDA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_99_EXIT*/

        [StopWatch]
        /*" R0090-00-OBTER-DATA-SISTEMA-SECTION */
        private void R0090_00_OBTER_DATA_SISTEMA_SECTION()
        {
            /*" -247- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", LD_01.WABEND.WNR_EXEC_SQL);

            /*" -253- PERFORM R0090_00_OBTER_DATA_SISTEMA_DB_SELECT_1 */

            R0090_00_OBTER_DATA_SISTEMA_DB_SELECT_1();

            /*" -256- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, LD_01.WABEND.WSQLCODE);

            /*" -258- MOVE SQLERRMC TO WSQLERRMC. */
            _.Move(DB.SQLERRMC, LD_01.WSQLERRO.WSQLERRMC);

            /*" -259- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -260- DISPLAY '******************************************' */
                _.Display($"******************************************");

                /*" -261- DISPLAY '* ERRO NO ACESSO A TABELA SISTEMAS        ' */
                _.Display($"* ERRO NO ACESSO A TABELA SISTEMAS        ");

                /*" -262- DISPLAY '* WSQLCODE            = ' WSQLCODE */
                _.Display($"* WSQLCODE            = {LD_01.WABEND.WSQLCODE}");

                /*" -263- DISPLAY '* WSQLERRMC           = ' WSQLERRMC */
                _.Display($"* WSQLERRMC           = {LD_01.WSQLERRO.WSQLERRMC}");

                /*" -264- DISPLAY '******************************************' */
                _.Display($"******************************************");

                /*" -265- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -265- END-IF. */
            }


        }

        [StopWatch]
        /*" R0090-00-OBTER-DATA-SISTEMA-DB-SELECT-1 */
        public void R0090_00_OBTER_DATA_SISTEMA_DB_SELECT_1()
        {
            /*" -253- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' WITH UR END-EXEC. */

            var r0090_00_OBTER_DATA_SISTEMA_DB_SELECT_1_Query1 = new R0090_00_OBTER_DATA_SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0090_00_OBTER_DATA_SISTEMA_DB_SELECT_1_Query1.Execute(r0090_00_OBTER_DATA_SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0090_99_EXIT*/

        [StopWatch]
        /*" M-100-000-PROCESSA-SECTION */
        private void M_100_000_PROCESSA_SECTION()
        {
            /*" -276- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", LD_01.WABEND.WNR_EXEC_SQL);

            /*" -276- PERFORM R0110-00-DECLARE-PRINCIPAL. */

            R0110_00_DECLARE_PRINCIPAL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_EXIT*/

        [StopWatch]
        /*" R0110-00-DECLARE-PRINCIPAL-SECTION */
        private void R0110_00_DECLARE_PRINCIPAL_SECTION()
        {
            /*" -287- MOVE '110' TO WNR-EXEC-SQL. */
            _.Move("110", LD_01.WABEND.WNR_EXEC_SQL);

            /*" -341- PERFORM R0110_00_DECLARE_PRINCIPAL_DB_DECLARE_1 */

            R0110_00_DECLARE_PRINCIPAL_DB_DECLARE_1();

            /*" -343- PERFORM R0110_00_DECLARE_PRINCIPAL_DB_OPEN_1 */

            R0110_00_DECLARE_PRINCIPAL_DB_OPEN_1();

            /*" -346- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, LD_01.WABEND.WSQLCODE);

            /*" -348- MOVE SQLERRMC TO WSQLERRMC. */
            _.Move(DB.SQLERRMC, LD_01.WSQLERRO.WSQLERRMC);

            /*" -349- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -350- DISPLAY '******************************************' */
                _.Display($"******************************************");

                /*" -351- DISPLAY '* ERRO NO DECLARE DO CURSOR PRINCIPAL     ' */
                _.Display($"* ERRO NO DECLARE DO CURSOR PRINCIPAL     ");

                /*" -352- DISPLAY '* WSQLCODE            = ' WSQLCODE */
                _.Display($"* WSQLCODE            = {LD_01.WABEND.WSQLCODE}");

                /*" -353- DISPLAY '* WSQLERRMC           = ' WSQLERRMC */
                _.Display($"* WSQLERRMC           = {LD_01.WSQLERRO.WSQLERRMC}");

                /*" -354- DISPLAY '******************************************' */
                _.Display($"******************************************");

                /*" -355- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -357- END-IF. */
            }


            /*" -360- PERFORM R0120-00-FETCH-PRINCIPAL UNTIL WFIM-RELAT EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_RELAT == "S"))
            {

                R0120_00_FETCH_PRINCIPAL_SECTION();
            }

            /*" -360- PERFORM R0110_00_DECLARE_PRINCIPAL_DB_CLOSE_1 */

            R0110_00_DECLARE_PRINCIPAL_DB_CLOSE_1();

            /*" -363- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, LD_01.WABEND.WSQLCODE);

            /*" -365- MOVE SQLERRMC TO WSQLERRMC. */
            _.Move(DB.SQLERRMC, LD_01.WSQLERRO.WSQLERRMC);

            /*" -366- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -367- DISPLAY '******************************************' */
                _.Display($"******************************************");

                /*" -368- DISPLAY '* ERRO NO CLOSE DO CURSOR PRINCIPAL       ' */
                _.Display($"* ERRO NO CLOSE DO CURSOR PRINCIPAL       ");

                /*" -369- DISPLAY '* WSQLCODE            = ' WSQLCODE */
                _.Display($"* WSQLCODE            = {LD_01.WABEND.WSQLCODE}");

                /*" -370- DISPLAY '* WSQLERRMC           = ' WSQLERRMC */
                _.Display($"* WSQLERRMC           = {LD_01.WSQLERRO.WSQLERRMC}");

                /*" -371- DISPLAY '******************************************' */
                _.Display($"******************************************");

                /*" -372- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -372- END-IF. */
            }


        }

        [StopWatch]
        /*" R0110-00-DECLARE-PRINCIPAL-DB-DECLARE-1 */
        public void R0110_00_DECLARE_PRINCIPAL_DB_DECLARE_1()
        {
            /*" -341- EXEC SQL DECLARE PRINCIPAL CURSOR FOR SELECT A.DATA_MOVIMENTO ,A.HORA_OPERACAO ,VALUE(A.COD_USUARIO, ' ' ) ,VALUE(C.NOME_USUARIO, ' ' ) ,A.COD_PRODUTO ,A.NUM_APOLICE ,A.NUM_APOL_SINISTRO ,A.VAL_OPERACAO ,A.NOME_FAVORECIDO ,VALUE(A.NOM_PROGRAMA, ' ' ) ,VALUE(D.NOME_GRUPO, 'NÃO CADASTRADO OU NÃO É ON-LINE' ) ,A.COD_OPERACAO ,E.DES_OPERACAO ,CASE A.SIT_REGISTRO WHEN '2' THEN 'CANCELAMENTO DE OPERACAO' ELSE 'OPERACAO NORMAL' END FROM SEGUROS.SINISTRO_HABIT01 B, SEGUROS.GE_OPERACAO E, SEGUROS.SINISTRO_HISTORICO A LEFT JOIN SEGUROS.USUARIOS C ON A.COD_USUARIO = C.COD_USUARIO LEFT JOIN SEGUROS.ESTRUTURA D ON A.NOM_PROGRAMA = D.COD_APLICACAO WHERE A.COD_OPERACAO NOT IN (130,131,132,133,134,135, 150,151,152,153,1200, 1300,1310,5004,5005, 8004,8005,8014,8015, 8162,9101,9171) AND A.COD_OPERACAO NOT BETWEEN 4000 AND 4289 AND A.DATA_MOVIMENTO = (SELECT MAX(DATA_CALENDARIO) FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO <= (SELECT (DATA_CALENDARIO - 1 DAY) FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO = CURRENT DATE) AND DIA_SEMANA IN ( '2' , '3' , '4' , '5' , '6' ) AND FERIADO = ' ' ) AND A.NUM_APOL_SINISTRO = B.NUM_APOL_SINISTRO AND A.COD_OPERACAO = E.COD_OPERACAO AND E.IDE_SISTEMA = 'SI' ORDER BY A.DATA_MOVIMENTO, A.HORA_OPERACAO, A.COD_USUARIO, A.NUM_APOL_SINISTRO, A.OCORR_HISTORICO, A.COD_OPERACAO WITH UR END-EXEC. */
            PRINCIPAL = new SI0181B_PRINCIPAL(false);
            string GetQuery_PRINCIPAL()
            {
                var query = @$"SELECT 
							A.DATA_MOVIMENTO 
							,A.HORA_OPERACAO 
							,VALUE(A.COD_USUARIO
							, ' ' ) 
							,VALUE(C.NOME_USUARIO
							, ' ' ) 
							,A.COD_PRODUTO 
							,A.NUM_APOLICE 
							,A.NUM_APOL_SINISTRO 
							,A.VAL_OPERACAO 
							,A.NOME_FAVORECIDO 
							,VALUE(A.NOM_PROGRAMA
							, ' ' ) 
							,VALUE(D.NOME_GRUPO
							, 'NÃO CADASTRADO OU NÃO É ON-LINE' ) 
							,A.COD_OPERACAO 
							,E.DES_OPERACAO 
							,CASE A.SIT_REGISTRO 
							WHEN '2' THEN 'CANCELAMENTO DE OPERACAO' 
							ELSE 'OPERACAO NORMAL' 
							END 
							FROM SEGUROS.SINISTRO_HABIT01 B
							, 
							SEGUROS.GE_OPERACAO E
							, 
							SEGUROS.SINISTRO_HISTORICO A 
							LEFT
							JOIN 
							SEGUROS.USUARIOS C 
							ON A.COD_USUARIO = C.COD_USUARIO 
							LEFT
							JOIN 
							SEGUROS.ESTRUTURA D 
							ON A.NOM_PROGRAMA = D.COD_APLICACAO 
							WHERE A.COD_OPERACAO NOT IN (130
							,131
							,132
							,133
							,134
							,135
							, 
							150
							,151
							,152
							,153
							,1200
							, 
							1300
							,1310
							,5004
							,5005
							, 
							8004
							,8005
							,8014
							,8015
							, 
							8162
							,9101
							,9171) 
							AND A.COD_OPERACAO NOT BETWEEN 4000 AND 4289 
							AND A.DATA_MOVIMENTO = 
							(SELECT MAX(DATA_CALENDARIO) 
							FROM SEGUROS.CALENDARIO 
							WHERE DATA_CALENDARIO <= 
							(SELECT (DATA_CALENDARIO - 1 DAY) 
							FROM SEGUROS.CALENDARIO 
							WHERE DATA_CALENDARIO = CURRENT DATE) 
							AND DIA_SEMANA IN ( '2'
							, '3'
							, '4'
							, '5'
							, '6' ) 
							AND FERIADO = ' ' ) 
							AND A.NUM_APOL_SINISTRO = B.NUM_APOL_SINISTRO 
							AND A.COD_OPERACAO = E.COD_OPERACAO 
							AND E.IDE_SISTEMA = 'SI' 
							ORDER BY A.DATA_MOVIMENTO
							, 
							A.HORA_OPERACAO
							, 
							A.COD_USUARIO
							, 
							A.NUM_APOL_SINISTRO
							, 
							A.OCORR_HISTORICO
							, 
							A.COD_OPERACAO";

                return query;
            }
            PRINCIPAL.GetQueryEvent += GetQuery_PRINCIPAL;

        }

        [StopWatch]
        /*" R0110-00-DECLARE-PRINCIPAL-DB-OPEN-1 */
        public void R0110_00_DECLARE_PRINCIPAL_DB_OPEN_1()
        {
            /*" -343- EXEC SQL OPEN PRINCIPAL END-EXEC. */

            PRINCIPAL.Open();

        }

        [StopWatch]
        /*" R0110-00-DECLARE-PRINCIPAL-DB-CLOSE-1 */
        public void R0110_00_DECLARE_PRINCIPAL_DB_CLOSE_1()
        {
            /*" -360- EXEC SQL CLOSE PRINCIPAL END-EXEC. */

            PRINCIPAL.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0110_99_EXIT*/

        [StopWatch]
        /*" R0120-00-FETCH-PRINCIPAL-SECTION */
        private void R0120_00_FETCH_PRINCIPAL_SECTION()
        {
            /*" -383- MOVE '120' TO WNR-EXEC-SQL. */
            _.Move("120", LD_01.WABEND.WNR_EXEC_SQL);

            /*" -399- PERFORM R0120_00_FETCH_PRINCIPAL_DB_FETCH_1 */

            R0120_00_FETCH_PRINCIPAL_DB_FETCH_1();

            /*" -402- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, LD_01.WABEND.WSQLCODE);

            /*" -404- MOVE SQLERRMC TO WSQLERRMC. */
            _.Move(DB.SQLERRMC, LD_01.WSQLERRO.WSQLERRMC);

            /*" -405- IF SQLCODE = 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -406- ADD 1 TO AC-LIDOS-RELAT */
                AREA_DE_WORK.AC_LIDOS_RELAT.Value = AREA_DE_WORK.AC_LIDOS_RELAT + 1;

                /*" -407- IF AC-LIDOS-RELAT = 1 */

                if (AREA_DE_WORK.AC_LIDOS_RELAT == 1)
                {

                    /*" -408- MOVE LC-01 TO REG-SAIDA */
                    _.Move(LC_01, REG_SAIDA);

                    /*" -409- WRITE REG-SAIDA */
                    ARQSAIDA.Write(REG_SAIDA.GetMoveValues().ToString());

                    /*" -410- END-IF */
                }


                /*" -411- PERFORM R0250-00-MONTA-ARQSAIDA */

                R0250_00_MONTA_ARQSAIDA_SECTION();

                /*" -412- ELSE */
            }
            else
            {


                /*" -413- IF SQLCODE = 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -414- MOVE 'S' TO WFIM-RELAT */
                    _.Move("S", AREA_DE_WORK.WFIM_RELAT);

                    /*" -415- GO TO R0120-99-EXIT */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0120_99_EXIT*/ //GOTO
                    return;

                    /*" -416- ELSE */
                }
                else
                {


                    /*" -417- DISPLAY '******************************************' */
                    _.Display($"******************************************");

                    /*" -418- DISPLAY '* ERRO NO FETCH DO CURSOR PRINCIPAL       ' */
                    _.Display($"* ERRO NO FETCH DO CURSOR PRINCIPAL       ");

                    /*" -419- DISPLAY '* WSQLCODE            = ' WSQLCODE */
                    _.Display($"* WSQLCODE            = {LD_01.WABEND.WSQLCODE}");

                    /*" -420- DISPLAY '* WSQLERRMC           = ' WSQLERRMC */
                    _.Display($"* WSQLERRMC           = {LD_01.WSQLERRO.WSQLERRMC}");

                    /*" -421- DISPLAY '******************************************' */
                    _.Display($"******************************************");

                    /*" -422- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -423- END-IF */
                }


                /*" -423- END-IF. */
            }


        }

        [StopWatch]
        /*" R0120-00-FETCH-PRINCIPAL-DB-FETCH-1 */
        public void R0120_00_FETCH_PRINCIPAL_DB_FETCH_1()
        {
            /*" -399- EXEC SQL FETCH PRINCIPAL INTO :SINISHIS-DATA-MOVIMENTO ,:SINISHIS-HORA-OPERACAO ,:SINISHIS-COD-USUARIO ,:USUARIOS-NOME-USUARIO ,:SINISHIS-COD-PRODUTO ,:SINISHIS-NUM-APOLICE ,:SINISHIS-NUM-APOL-SINISTRO ,:SINISHIS-VAL-OPERACAO ,:SINISHIS-NOME-FAVORECIDO ,:SINISHIS-NOM-PROGRAMA ,:ESTRUTUR-NOME-GRUPO ,:SINISHIS-COD-OPERACAO ,:GEOPERAC-DES-OPERACAO ,:WHOST-SIT-MOVIMENTO END-EXEC. */

            if (PRINCIPAL.Fetch())
            {
                _.Move(PRINCIPAL.SINISHIS_DATA_MOVIMENTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO);
                _.Move(PRINCIPAL.SINISHIS_HORA_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_HORA_OPERACAO);
                _.Move(PRINCIPAL.SINISHIS_COD_USUARIO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_USUARIO);
                _.Move(PRINCIPAL.USUARIOS_NOME_USUARIO, USUARIOS.DCLUSUARIOS.USUARIOS_NOME_USUARIO);
                _.Move(PRINCIPAL.SINISHIS_COD_PRODUTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PRODUTO);
                _.Move(PRINCIPAL.SINISHIS_NUM_APOLICE, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOLICE);
                _.Move(PRINCIPAL.SINISHIS_NUM_APOL_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);
                _.Move(PRINCIPAL.SINISHIS_VAL_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);
                _.Move(PRINCIPAL.SINISHIS_NOME_FAVORECIDO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO);
                _.Move(PRINCIPAL.SINISHIS_NOM_PROGRAMA, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOM_PROGRAMA);
                _.Move(PRINCIPAL.ESTRUTUR_NOME_GRUPO, ESTRUTUR.DCLESTRUTURA.ESTRUTUR_NOME_GRUPO);
                _.Move(PRINCIPAL.SINISHIS_COD_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);
                _.Move(PRINCIPAL.GEOPERAC_DES_OPERACAO, GEOPERAC.DCLGE_OPERACAO.GEOPERAC_DES_OPERACAO);
                _.Move(PRINCIPAL.WHOST_SIT_MOVIMENTO, WHOST_SIT_MOVIMENTO);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0120_99_EXIT*/

        [StopWatch]
        /*" R0250-00-MONTA-ARQSAIDA-SECTION */
        private void R0250_00_MONTA_ARQSAIDA_SECTION()
        {
            /*" -434- MOVE '250' TO WNR-EXEC-SQL. */
            _.Move("250", LD_01.WABEND.WNR_EXEC_SQL);

            /*" -435- MOVE SINISHIS-DATA-MOVIMENTO TO DET1-DTH-MOVIMENTO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO, LD_01.DET1_DTH_MOVIMENTO);

            /*" -436- MOVE SINISHIS-HORA-OPERACAO TO DET1-HOR-MOVIMENTO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_HORA_OPERACAO, LD_01.DET1_HOR_MOVIMENTO);

            /*" -437- MOVE SINISHIS-COD-USUARIO TO DET1-COD-USUARIO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_USUARIO, LD_01.DET1_COD_USUARIO);

            /*" -438- MOVE USUARIOS-NOME-USUARIO TO DET1-NOM-USUARIO. */
            _.Move(USUARIOS.DCLUSUARIOS.USUARIOS_NOME_USUARIO, LD_01.DET1_NOM_USUARIO);

            /*" -439- MOVE SINISHIS-COD-PRODUTO TO DET1-COD-PRODUTO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PRODUTO, LD_01.DET1_COD_PRODUTO);

            /*" -440- MOVE SINISHIS-NUM-APOLICE TO DET1-NUM-APOLICE. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOLICE, LD_01.DET1_NUM_APOLICE);

            /*" -441- MOVE SINISHIS-NUM-APOL-SINISTRO TO DET1-NUM-SINISTRO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, LD_01.DET1_NUM_SINISTRO);

            /*" -442- MOVE SINISHIS-VAL-OPERACAO TO DET1-VAL-OPERACAO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, LD_01.DET1_VAL_OPERACAO);

            /*" -443- MOVE SINISHIS-NOME-FAVORECIDO TO DET1-NOM-FAVORECIDO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO, LD_01.DET1_NOM_FAVORECIDO);

            /*" -444- MOVE SINISHIS-NOM-PROGRAMA TO DET1-NOM-PROGRAMA. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOM_PROGRAMA, LD_01.DET1_NOM_PROGRAMA);

            /*" -445- MOVE ESTRUTUR-NOME-GRUPO TO DET1-NOM-CAMINHO-SIAS. */
            _.Move(ESTRUTUR.DCLESTRUTURA.ESTRUTUR_NOME_GRUPO, LD_01.DET1_NOM_CAMINHO_SIAS);

            /*" -446- MOVE SINISHIS-COD-OPERACAO TO DET1-COD-OPERACAO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO, LD_01.DET1_COD_OPERACAO);

            /*" -447- MOVE GEOPERAC-DES-OPERACAO TO DET1-DES-OPERACAO. */
            _.Move(GEOPERAC.DCLGE_OPERACAO.GEOPERAC_DES_OPERACAO, LD_01.DET1_DES_OPERACAO);

            /*" -449- MOVE WHOST-SIT-MOVIMENTO TO DET1-SIT-MOVIMENTO. */
            _.Move(WHOST_SIT_MOVIMENTO, LD_01.DET1_SIT_MOVIMENTO);

            /*" -450- MOVE LD-01 TO REG-SAIDA. */
            _.Move(LD_01, REG_SAIDA);

            /*" -451- WRITE REG-SAIDA. */
            ARQSAIDA.Write(REG_SAIDA.GetMoveValues().ToString());

            /*" -451- ADD 1 TO AC-REG-GRAVADO1. */
            AREA_DE_WORK.AC_REG_GRAVADO1.Value = AREA_DE_WORK.AC_REG_GRAVADO1 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_99_EXIT*/

        [StopWatch]
        /*" M-900-000-FINALIZA-SECTION */
        private void M_900_000_FINALIZA_SECTION()
        {
            /*" -462- MOVE '900' TO WNR-EXEC-SQL. */
            _.Move("900", LD_01.WABEND.WNR_EXEC_SQL);

            /*" -463- DISPLAY '*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*' . */
            _.Display($"*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*");

            /*" -464- DISPLAY '*  TERMINO NORMAL DO PROGRAMA SI0181B  *' . */
            _.Display($"*  TERMINO NORMAL DO PROGRAMA SI0181B  *");

            /*" -465- DISPLAY '*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*' . */
            _.Display($"*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*");

            /*" -466- DISPLAY ' ' . */
            _.Display($" ");

            /*" -467- DISPLAY 'QUANTIDADE DO DECLARE PRIN: ' AC-LIDOS-RELAT. */
            _.Display($"QUANTIDADE DO DECLARE PRIN: {AREA_DE_WORK.AC_LIDOS_RELAT}");

            /*" -469- DISPLAY 'QUANTIDADE DE REG GRAVADO1: ' AC-REG-GRAVADO1. */
            _.Display($"QUANTIDADE DE REG GRAVADO1: {AREA_DE_WORK.AC_REG_GRAVADO1}");

            /*" -469- CLOSE ARQSAIDA. */
            ARQSAIDA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_EXIT*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -480- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, LD_01.WABEND.WSQLCODE);

            /*" -482- DISPLAY WABEND. */
            _.Display(LD_01.WABEND);

            /*" -482- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -484- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -488- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -488- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}