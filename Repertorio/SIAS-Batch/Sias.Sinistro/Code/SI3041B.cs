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
using Sias.Sinistro.DB2.SI3041B;

namespace Code
{
    public class SI3041B
    {
        public bool IsCall { get; set; }

        public SI3041B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SINISTROS                          *      */
        /*"      *   PROGRAMA ...............  SI3041B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  JEFFERSON                          *      */
        /*"      *   PROGRAMADOR.............  JEFFERSON                          *      */
        /*"      *   DATA CODIFICACAO .......  MAIO / 2006                        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  GERAR ARQUIVO DO SEGAB - SISTEMA DE*      */
        /*"      *                             GERENCIAMENTO DE INADIMPLENCIA PARA*      */
        /*"      *                             CAIXA                              *      */
        /*"      *                             CODIGOS DE NEGATIVA E DESCRICAO    *      */
        /*"      *   NOME DO ARQUIVO SAIDA.    "SEGAB02"                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        /*"      *--------------------------------------                                 */
        #endregion


        #region VARIABLES

        public FileBasis _ARQ_SEGAB02 { get; set; } = new FileBasis(new PIC("X", "1500", "X(1500)"));

        public FileBasis ARQ_SEGAB02
        {
            get
            {
                _.Move(REG_ARQ_SEGAB02, _ARQ_SEGAB02); VarBasis.RedefinePassValue(REG_ARQ_SEGAB02, _ARQ_SEGAB02, REG_ARQ_SEGAB02); return _ARQ_SEGAB02;
            }
        }
        /*"01      REG-ARQ-SEGAB02.*/
        public SI3041B_REG_ARQ_SEGAB02 REG_ARQ_SEGAB02 { get; set; } = new SI3041B_REG_ARQ_SEGAB02();
        public class SI3041B_REG_ARQ_SEGAB02 : VarBasis
        {
            /*" 05     SEGAB02-HEADER.*/
            public SI3041B_SEGAB02_HEADER SEGAB02_HEADER { get; set; } = new SI3041B_SEGAB02_HEADER();
            public class SI3041B_SEGAB02_HEADER : VarBasis
            {
                /*"   10   HDR-IDE-REGISTRO            PIC  X(001).*/
                public StringBasis HDR_IDE_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"   10   HDR-IDE-ARQUIVO             PIC  X(008).*/
                public StringBasis HDR_IDE_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10   HDR-DTH-GERACAO             PIC  9(008).*/
                public IntBasis HDR_DTH_GERACAO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"   10   HDR-COD-SEGURADORA          PIC  9(004).*/
                public IntBasis HDR_COD_SEGURADORA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"   10   HDR-FILLER                  PIC  X(1479).*/
                public StringBasis HDR_FILLER { get; set; } = new StringBasis(new PIC("X", "1479", "X(1479)."), @"");
                /*" 05     SEGAB02-DETALHE-1           REDEFINES SEGAB02-HEADER.*/
            }
            private _REDEF_SI3041B_SEGAB02_DETALHE_1 _segab02_detalhe_1 { get; set; }
            public _REDEF_SI3041B_SEGAB02_DETALHE_1 SEGAB02_DETALHE_1
            {
                get { _segab02_detalhe_1 = new _REDEF_SI3041B_SEGAB02_DETALHE_1(); _.Move(SEGAB02_HEADER, _segab02_detalhe_1); VarBasis.RedefinePassValue(SEGAB02_HEADER, _segab02_detalhe_1, SEGAB02_HEADER); _segab02_detalhe_1.ValueChanged += () => { _.Move(_segab02_detalhe_1, SEGAB02_HEADER); }; return _segab02_detalhe_1; }
                set { VarBasis.RedefinePassValue(value, _segab02_detalhe_1, SEGAB02_HEADER); }
            }  //Redefines
            public class _REDEF_SI3041B_SEGAB02_DETALHE_1 : VarBasis
            {
                /*"   10   DET1-IDE-REGISTRO           PIC  X(001).*/
                public StringBasis DET1_IDE_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"   10   DET1-NUM-ITEM               PIC  9(002).*/
                public IntBasis DET1_NUM_ITEM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"   10   DET1-NUM-SUB-ITEM           PIC  9(007).*/
                public IntBasis DET1_NUM_SUB_ITEM { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
                /*"   10   DET1-DES-MOTIVO             PIC  X(1490).*/
                public StringBasis DET1_DES_MOTIVO { get; set; } = new StringBasis(new PIC("X", "1490", "X(1490)."), @"");
                /*" 05     SEGAB02-TRAILLER            REDEFINES SEGAB02-HEADER.*/

                public _REDEF_SI3041B_SEGAB02_DETALHE_1()
                {
                    DET1_IDE_REGISTRO.ValueChanged += OnValueChanged;
                    DET1_NUM_ITEM.ValueChanged += OnValueChanged;
                    DET1_NUM_SUB_ITEM.ValueChanged += OnValueChanged;
                    DET1_DES_MOTIVO.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_SI3041B_SEGAB02_TRAILLER _segab02_trailler { get; set; }
            public _REDEF_SI3041B_SEGAB02_TRAILLER SEGAB02_TRAILLER
            {
                get { _segab02_trailler = new _REDEF_SI3041B_SEGAB02_TRAILLER(); _.Move(SEGAB02_HEADER, _segab02_trailler); VarBasis.RedefinePassValue(SEGAB02_HEADER, _segab02_trailler, SEGAB02_HEADER); _segab02_trailler.ValueChanged += () => { _.Move(_segab02_trailler, SEGAB02_HEADER); }; return _segab02_trailler; }
                set { VarBasis.RedefinePassValue(value, _segab02_trailler, SEGAB02_HEADER); }
            }  //Redefines
            public class _REDEF_SI3041B_SEGAB02_TRAILLER : VarBasis
            {
                /*"   10   TRA-IDE-REGISTRO            PIC  X(001).*/
                public StringBasis TRA_IDE_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"   10   TRA-QTD-REGISTRO            PIC  9(007).*/
                public IntBasis TRA_QTD_REGISTRO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
                /*"   10   TRA-FILLER                  PIC  X(1492).*/
                public StringBasis TRA_FILLER { get; set; } = new StringBasis(new PIC("X", "1492", "X(1492)."), @"");

                public _REDEF_SI3041B_SEGAB02_TRAILLER()
                {
                    TRA_IDE_REGISTRO.ValueChanged += OnValueChanged;
                    TRA_QTD_REGISTRO.ValueChanged += OnValueChanged;
                    TRA_FILLER.ValueChanged += OnValueChanged;
                }

            }
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01       HOST-VAL-OPERACAO-PRE       PIC S9(013)V99 VALUE +0                                                          COMP-3*/
        public DoubleBasis HOST_VAL_OPERACAO_PRE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01       HOST-VAL-OPERACAO-CAN-PRE   PIC S9(013)V99 VALUE +0                                                          COMP-3*/
        public DoubleBasis HOST_VAL_OPERACAO_CAN_PRE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01       HOST-VAL-OPERACAO-EST       PIC S9(013)V99 VALUE +0                                                          COMP-3*/
        public DoubleBasis HOST_VAL_OPERACAO_EST { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01       HOST-ANO-MOV-ABERTO         PIC S9(004) VALUE +0 COMP.*/
        public IntBasis HOST_ANO_MOV_ABERTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01       HOST-MES-MOV-ABERTO         PIC S9(004) VALUE +0 COMP.*/
        public IntBasis HOST_MES_MOV_ABERTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01       WFIM-MOTIVOS                PIC  X(001) VALUE SPACES.*/
        public StringBasis WFIM_MOTIVOS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01       AC-L-MOTIVOS                PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_L_MOTIVOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-L-TP-MOTIVOS             PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_L_TP_MOTIVOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-G-SEGAB002               PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_G_SEGAB002 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-I-GEARDETA               PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_I_GEARDETA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-U-GEARDETA               PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_U_GEARDETA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       VARIAVEIS-DE-WORK.*/
        public SI3041B_VARIAVEIS_DE_WORK VARIAVEIS_DE_WORK { get; set; } = new SI3041B_VARIAVEIS_DE_WORK();
        public class SI3041B_VARIAVEIS_DE_WORK : VarBasis
        {
            /*" 05      WCOD-TIPO-MOT-ANT           PIC  9(002) VALUE ZEROS.*/
            public IntBasis WCOD_TIPO_MOT_ANT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*" 05      WDATA-ARQUIVO.*/
            public SI3041B_WDATA_ARQUIVO WDATA_ARQUIVO { get; set; } = new SI3041B_WDATA_ARQUIVO();
            public class SI3041B_WDATA_ARQUIVO : VarBasis
            {
                /*"   10    WDATA-ARQUIVO-DD            PIC  9(002) VALUE ZEROS.*/
                public IntBasis WDATA_ARQUIVO_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"   10    WDATA-ARQUIVO-MM            PIC  9(002) VALUE ZEROS.*/
                public IntBasis WDATA_ARQUIVO_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"   10    WDATA-ARQUIVO-AA            PIC  9(004) VALUE ZEROS.*/
                public IntBasis WDATA_ARQUIVO_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*" 05      WDATA-ANO-MES.*/
            }
            public SI3041B_WDATA_ANO_MES WDATA_ANO_MES { get; set; } = new SI3041B_WDATA_ANO_MES();
            public class SI3041B_WDATA_ANO_MES : VarBasis
            {
                /*"   10    WDATA-ANO-MES-AA            PIC  9(004) VALUE ZEROS.*/
                public IntBasis WDATA_ANO_MES_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"   10    WDATA-ANO-MES-MM            PIC  9(002) VALUE ZEROS.*/
                public IntBasis WDATA_ANO_MES_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*" 05      SEGUR-CPF                   PIC  9(015) VALUE ZEROS.*/
            }
            public IntBasis SEGUR_CPF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*" 05      SEGUR-CPF-R REDEFINES SEGUR-CPF.*/
            private _REDEF_SI3041B_SEGUR_CPF_R _segur_cpf_r { get; set; }
            public _REDEF_SI3041B_SEGUR_CPF_R SEGUR_CPF_R
            {
                get { _segur_cpf_r = new _REDEF_SI3041B_SEGUR_CPF_R(); _.Move(SEGUR_CPF, _segur_cpf_r); VarBasis.RedefinePassValue(SEGUR_CPF, _segur_cpf_r, SEGUR_CPF); _segur_cpf_r.ValueChanged += () => { _.Move(_segur_cpf_r, SEGUR_CPF); }; return _segur_cpf_r; }
                set { VarBasis.RedefinePassValue(value, _segur_cpf_r, SEGUR_CPF); }
            }  //Redefines
            public class _REDEF_SI3041B_SEGUR_CPF_R : VarBasis
            {
                /*"   10    SEGUR-CPF-4                 PIC  9(004).*/
                public IntBasis SEGUR_CPF_4 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"   10    SEGUR-CPF-9                 PIC  9(009).*/
                public IntBasis SEGUR_CPF_9 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"   10    SEGUR-CPF-2                 PIC  9(002).*/
                public IntBasis SEGUR_CPF_2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"01          WABEND.*/

                public _REDEF_SI3041B_SEGUR_CPF_R()
                {
                    SEGUR_CPF_4.ValueChanged += OnValueChanged;
                    SEGUR_CPF_9.ValueChanged += OnValueChanged;
                    SEGUR_CPF_2.ValueChanged += OnValueChanged;
                }

            }
        }
        public SI3041B_WABEND WABEND { get; set; } = new SI3041B_WABEND();
        public class SI3041B_WABEND : VarBasis
        {
            /*"  05     FILLER                      PIC  X(010) VALUE           ' SI3041B'.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SI3041B");
            /*"  05     FILLER                      PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"  05     WNR-EXEC-SQL                PIC  X(004) VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"  05     FILLER                      PIC  X(013) VALUE           ' *** SQLCODE '.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"  05     WSQLCODE                    PIC  ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.GEARDETA GEARDETA { get; set; } = new Dclgens.GEARDETA();
        public Dclgens.SIHISMOT SIHISMOT { get; set; } = new Dclgens.SIHISMOT();
        public Dclgens.SIMOTIVO SIMOTIVO { get; set; } = new Dclgens.SIMOTIVO();
        public Dclgens.SITIPMOT SITIPMOT { get; set; } = new Dclgens.SITIPMOT();
        public Dclgens.CALENDAR CALENDAR { get; set; } = new Dclgens.CALENDAR();
        public SI3041B_MOTIVOS MOTIVOS { get; set; } = new SI3041B_MOTIVOS();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string ARQ_SEGAB02_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                ARQ_SEGAB02.SetFile(ARQ_SEGAB02_FILE_NAME_P);

                /*" -127- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -128- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -129- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -129- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -136- MOVE '0000' TO WNR-EXEC-SQL */
            _.Move("0000", WABEND.WNR_EXEC_SQL);

            /*" -138- DISPLAY 'INICIA SI3041B. GERACAO DE ARQUIVO SEGAB002' . */
            _.Display($"INICIA SI3041B. GERACAO DE ARQUIVO SEGAB002");

            /*" -140- PERFORM R0100-00-LE-SISTEMAS. */

            R0100_00_LE_SISTEMAS_SECTION();

            /*" -141- PERFORM R8000-00-LE-DATA-CALENDARIO. */

            R8000_00_LE_DATA_CALENDARIO_SECTION();

            /*" -142- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -143- DISPLAY 'PROGRAMA FINALIZADO NORMALMENTE SEM EXECUCAO ' */
                _.Display($"PROGRAMA FINALIZADO NORMALMENTE SEM EXECUCAO ");

                /*" -146- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -147- MOVE ZEROS TO SQLCODE. */
            _.Move(0, DB.SQLCODE);

            /*" -148- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -149- DISPLAY 'NAO HOUVE SOLICITACAO PARA O PROGRAMA SI3041B' */
                _.Display($"NAO HOUVE SOLICITACAO PARA O PROGRAMA SI3041B");

                /*" -150- DISPLAY '********** FINALIZADO SEM EXECUCAO **********' */
                _.Display($"********** FINALIZADO SEM EXECUCAO **********");

                /*" -152- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -154- OPEN OUTPUT ARQ-SEGAB02. */
            ARQ_SEGAB02.Open(REG_ARQ_SEGAB02);

            /*" -156- MOVE SPACES TO REG-ARQ-SEGAB02. */
            _.Move("", REG_ARQ_SEGAB02);

            /*" -157- MOVE '0' TO HDR-IDE-REGISTRO */
            _.Move("0", REG_ARQ_SEGAB02.SEGAB02_HEADER.HDR_IDE_REGISTRO);

            /*" -158- MOVE 'SEGAB002' TO HDR-IDE-ARQUIVO */
            _.Move("SEGAB002", REG_ARQ_SEGAB02.SEGAB02_HEADER.HDR_IDE_ARQUIVO);

            /*" -159- MOVE SISTEMAS-DATA-MOV-ABERTO(9:2) TO WDATA-ARQUIVO-DD */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2), VARIAVEIS_DE_WORK.WDATA_ARQUIVO.WDATA_ARQUIVO_DD);

            /*" -160- MOVE SISTEMAS-DATA-MOV-ABERTO(6:2) TO WDATA-ARQUIVO-MM */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2), VARIAVEIS_DE_WORK.WDATA_ARQUIVO.WDATA_ARQUIVO_MM);

            /*" -161- MOVE SISTEMAS-DATA-MOV-ABERTO(1:4) TO WDATA-ARQUIVO-AA */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4), VARIAVEIS_DE_WORK.WDATA_ARQUIVO.WDATA_ARQUIVO_AA);

            /*" -162- MOVE WDATA-ARQUIVO TO HDR-DTH-GERACAO */
            _.Move(VARIAVEIS_DE_WORK.WDATA_ARQUIVO, REG_ARQ_SEGAB02.SEGAB02_HEADER.HDR_DTH_GERACAO);

            /*" -165- MOVE 5631 TO HDR-COD-SEGURADORA */
            _.Move(5631, REG_ARQ_SEGAB02.SEGAB02_HEADER.HDR_COD_SEGURADORA);

            /*" -167- MOVE SPACES TO HDR-FILLER. */
            _.Move("", REG_ARQ_SEGAB02.SEGAB02_HEADER.HDR_FILLER);

            /*" -169- WRITE REG-ARQ-SEGAB02. */
            ARQ_SEGAB02.Write(REG_ARQ_SEGAB02.GetMoveValues().ToString());

            /*" -171- MOVE SPACES TO WFIM-MOTIVOS */
            _.Move("", WFIM_MOTIVOS);

            /*" -173- PERFORM R0200-00-DECLARE-MOTIVOS */

            R0200_00_DECLARE_MOTIVOS_SECTION();

            /*" -176- PERFORM R0300-00-PROCESSA-MOTIVOS UNTIL WFIM-MOTIVOS EQUAL 'S' . */

            while (!(WFIM_MOTIVOS == "S"))
            {

                R0300_00_PROCESSA_MOTIVOS_SECTION();
            }

            /*" -177- DISPLAY '***********************************' */
            _.Display($"***********************************");

            /*" -178- DISPLAY '* SI3041B - PROCESSOU OS MOTIVOS  *' */
            _.Display($"* SI3041B - PROCESSOU OS MOTIVOS  *");

            /*" -179- DISPLAY '***********************************' */
            _.Display($"***********************************");

            /*" -180- DISPLAY 'LIDOS OS MOTIVOS......: ' AC-L-MOTIVOS */
            _.Display($"LIDOS OS MOTIVOS......: {AC_L_MOTIVOS}");

            /*" -181- DISPLAY 'LIDOS OS TP MOTIVOS...: ' AC-L-TP-MOTIVOS */
            _.Display($"LIDOS OS TP MOTIVOS...: {AC_L_TP_MOTIVOS}");

            /*" -182- DISPLAY 'GRAVADOS NO SEGAB002..: ' AC-G-SEGAB002 */
            _.Display($"GRAVADOS NO SEGAB002..: {AC_G_SEGAB002}");

            /*" -184- DISPLAY 'INSERIDOS NA GEARDETA.: ' AC-I-GEARDETA */
            _.Display($"INSERIDOS NA GEARDETA.: {AC_I_GEARDETA}");

            /*" -186- MOVE SPACES TO REG-ARQ-SEGAB02. */
            _.Move("", REG_ARQ_SEGAB02);

            /*" -187- MOVE '9' TO TRA-IDE-REGISTRO. */
            _.Move("9", REG_ARQ_SEGAB02.SEGAB02_TRAILLER.TRA_IDE_REGISTRO);

            /*" -188- MOVE AC-G-SEGAB002 TO TRA-QTD-REGISTRO. */
            _.Move(AC_G_SEGAB002, REG_ARQ_SEGAB02.SEGAB02_TRAILLER.TRA_QTD_REGISTRO);

            /*" -190- MOVE SPACES TO TRA-FILLER. */
            _.Move("", REG_ARQ_SEGAB02.SEGAB02_TRAILLER.TRA_FILLER);

            /*" -192- WRITE REG-ARQ-SEGAB02. */
            ARQ_SEGAB02.Write(REG_ARQ_SEGAB02.GetMoveValues().ToString());

            /*" -194- CLOSE ARQ-SEGAB02. */
            ARQ_SEGAB02.Close();

            /*" -195- IF AC-G-SEGAB002 = ZEROS */

            if (AC_G_SEGAB002 == 00)
            {

                /*" -200- MOVE 1 TO RETURN-CODE. */
                _.Move(1, RETURN_CODE);
            }


            /*" -200- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -202- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0100-00-LE-SISTEMAS-SECTION */
        private void R0100_00_LE_SISTEMAS_SECTION()
        {
            /*" -210- MOVE '0100' TO WNR-EXEC-SQL */
            _.Move("0100", WABEND.WNR_EXEC_SQL);

            /*" -222- PERFORM R0100_00_LE_SISTEMAS_DB_SELECT_1 */

            R0100_00_LE_SISTEMAS_DB_SELECT_1();

            /*" -225- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -226- DISPLAY 'ERRO NO SELECT SISTEMAS' */
                _.Display($"ERRO NO SELECT SISTEMAS");

                /*" -228- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -230- DISPLAY 'DATA DO ULT PROCESSAMENTO SI-' ' ' SISTEMAS-DATULT-PROCESSAMEN. */

            $"DATA DO ULT PROCESSAMENTO SI- {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATULT_PROCESSAMEN}"
            .Display();

            /*" -231- DISPLAY 'DATA DO SISTEMA DE SINISTRO -' ' ' SISTEMAS-DATA-MOV-ABERTO. */

            $"DATA DO SISTEMA DE SINISTRO - {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}"
            .Display();

        }

        [StopWatch]
        /*" R0100-00-LE-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_LE_SISTEMAS_DB_SELECT_1()
        {
            /*" -222- EXEC SQL SELECT DATA_MOV_ABERTO, DATULT_PROCESSAMEN, YEAR(DATA_MOV_ABERTO), MONTH(DATA_MOV_ABERTO) INTO :SISTEMAS-DATA-MOV-ABERTO, :SISTEMAS-DATULT-PROCESSAMEN, :HOST-ANO-MOV-ABERTO, :HOST-MES-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' WITH UR END-EXEC */

            var r0100_00_LE_SISTEMAS_DB_SELECT_1_Query1 = new R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1.Execute(r0100_00_LE_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.SISTEMAS_DATULT_PROCESSAMEN, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATULT_PROCESSAMEN);
                _.Move(executed_1.HOST_ANO_MOV_ABERTO, HOST_ANO_MOV_ABERTO);
                _.Move(executed_1.HOST_MES_MOV_ABERTO, HOST_MES_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_00_EXIT*/

        [StopWatch]
        /*" R0110-00-SELECT-RELATORIOS-SECTION */
        private void R0110_00_SELECT_RELATORIOS_SECTION()
        {
            /*" -241- MOVE '110' TO WNR-EXEC-SQL. */
            _.Move("110", WABEND.WNR_EXEC_SQL);

            /*" -253- PERFORM R0110_00_SELECT_RELATORIOS_DB_SELECT_1 */

            R0110_00_SELECT_RELATORIOS_DB_SELECT_1();

            /*" -257- IF SQLCODE NOT = 0 AND SQLCODE NOT = 100 */

            if (DB.SQLCODE != 0 && DB.SQLCODE != 100)
            {

                /*" -258- DISPLAY 'ERRO NO SELECT DA RELATORIOS' */
                _.Display($"ERRO NO SELECT DA RELATORIOS");

                /*" -258- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0110-00-SELECT-RELATORIOS-DB-SELECT-1 */
        public void R0110_00_SELECT_RELATORIOS_DB_SELECT_1()
        {
            /*" -253- EXEC SQL SELECT COD_RELATORIO, PERI_INICIAL, PERI_FINAL INTO :RELATORI-COD-RELATORIO, :RELATORI-PERI-INICIAL, :RELATORI-PERI-FINAL FROM SEGUROS.RELATORIOS WHERE IDE_SISTEMA = 'SI' AND COD_RELATORIO = 'SI3041B' FETCH FIRST 1 ROW ONLY WITH UR END-EXEC. */

            var r0110_00_SELECT_RELATORIOS_DB_SELECT_1_Query1 = new R0110_00_SELECT_RELATORIOS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0110_00_SELECT_RELATORIOS_DB_SELECT_1_Query1.Execute(r0110_00_SELECT_RELATORIOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RELATORI_COD_RELATORIO, RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO);
                _.Move(executed_1.RELATORI_PERI_INICIAL, RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL);
                _.Move(executed_1.RELATORI_PERI_FINAL, RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0110_99_EXIT*/

        [StopWatch]
        /*" R0120-00-DELETE-RELATORIOS-SECTION */
        private void R0120_00_DELETE_RELATORIOS_SECTION()
        {
            /*" -268- MOVE '120' TO WNR-EXEC-SQL. */
            _.Move("120", WABEND.WNR_EXEC_SQL);

            /*" -272- PERFORM R0120_00_DELETE_RELATORIOS_DB_DELETE_1 */

            R0120_00_DELETE_RELATORIOS_DB_DELETE_1();

            /*" -275- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -276- DISPLAY 'ERRO NO DELETE DA RELATORIOS' */
                _.Display($"ERRO NO DELETE DA RELATORIOS");

                /*" -276- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0120-00-DELETE-RELATORIOS-DB-DELETE-1 */
        public void R0120_00_DELETE_RELATORIOS_DB_DELETE_1()
        {
            /*" -272- EXEC SQL DELETE FROM SEGUROS.RELATORIOS WHERE IDE_SISTEMA = 'SI' AND COD_RELATORIO = 'SI3041B' END-EXEC. */

            var r0120_00_DELETE_RELATORIOS_DB_DELETE_1_Delete1 = new R0120_00_DELETE_RELATORIOS_DB_DELETE_1_Delete1()
            {
            };

            R0120_00_DELETE_RELATORIOS_DB_DELETE_1_Delete1.Execute(r0120_00_DELETE_RELATORIOS_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0120_99_EXIT*/

        [StopWatch]
        /*" R0200-00-DECLARE-MOTIVOS-SECTION */
        private void R0200_00_DECLARE_MOTIVOS_SECTION()
        {
            /*" -286- MOVE '0200' TO WNR-EXEC-SQL */
            _.Move("0200", WABEND.WNR_EXEC_SQL);

            /*" -294- PERFORM R0200_00_DECLARE_MOTIVOS_DB_DECLARE_1 */

            R0200_00_DECLARE_MOTIVOS_DB_DECLARE_1();

            /*" -296- PERFORM R0200_00_DECLARE_MOTIVOS_DB_OPEN_1 */

            R0200_00_DECLARE_MOTIVOS_DB_OPEN_1();

            /*" -299- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -300- DISPLAY 'R0200-ERRO NO DECLARE DOS MOTIVOS' */
                _.Display($"R0200-ERRO NO DECLARE DOS MOTIVOS");

                /*" -300- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0200-00-DECLARE-MOTIVOS-DB-DECLARE-1 */
        public void R0200_00_DECLARE_MOTIVOS_DB_DECLARE_1()
        {
            /*" -294- EXEC SQL DECLARE MOTIVOS CURSOR FOR SELECT COD_TIPO_MOTIVO , NUM_MOTIVO , DES_MOTIVO FROM SEGUROS.SI_MOTIVO ORDER BY COD_TIPO_MOTIVO, NUM_MOTIVO WITH UR END-EXEC. */
            MOTIVOS = new SI3041B_MOTIVOS(false);
            string GetQuery_MOTIVOS()
            {
                var query = @$"SELECT COD_TIPO_MOTIVO
							, 
							NUM_MOTIVO
							, 
							DES_MOTIVO 
							FROM SEGUROS.SI_MOTIVO 
							ORDER BY COD_TIPO_MOTIVO
							, 
							NUM_MOTIVO";

                return query;
            }
            MOTIVOS.GetQueryEvent += GetQuery_MOTIVOS;

        }

        [StopWatch]
        /*" R0200-00-DECLARE-MOTIVOS-DB-OPEN-1 */
        public void R0200_00_DECLARE_MOTIVOS_DB_OPEN_1()
        {
            /*" -296- EXEC SQL OPEN MOTIVOS END-EXEC. */

            MOTIVOS.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_00_EXIT*/

        [StopWatch]
        /*" R0300-00-PROCESSA-MOTIVOS-SECTION */
        private void R0300_00_PROCESSA_MOTIVOS_SECTION()
        {
            /*" -310- MOVE '0300' TO WNR-EXEC-SQL */
            _.Move("0300", WABEND.WNR_EXEC_SQL);

            /*" -314- INITIALIZE SIMOTIVO-COD-TIPO-MOTIVO SIMOTIVO-NUM-MOTIVO SIMOTIVO-DES-MOTIVO. */
            _.Initialize(
                SIMOTIVO.DCLSI_MOTIVO.SIMOTIVO_COD_TIPO_MOTIVO
                , SIMOTIVO.DCLSI_MOTIVO.SIMOTIVO_NUM_MOTIVO
                , SIMOTIVO.DCLSI_MOTIVO.SIMOTIVO_DES_MOTIVO
            );

            /*" -318- PERFORM R0300_00_PROCESSA_MOTIVOS_DB_FETCH_1 */

            R0300_00_PROCESSA_MOTIVOS_DB_FETCH_1();

            /*" -321- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -322- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -323- DISPLAY 'R0300-ERRO NO FETCH DOS MOTIVOS' */
                    _.Display($"R0300-ERRO NO FETCH DOS MOTIVOS");

                    /*" -324- DISPLAY 'PERI INICIAL...: ' RELATORI-PERI-INICIAL */
                    _.Display($"PERI INICIAL...: {RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL}");

                    /*" -325- DISPLAY 'PERI FINAL.....: ' RELATORI-PERI-FINAL */
                    _.Display($"PERI FINAL.....: {RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL}");

                    /*" -326- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -327- ELSE */
                }
                else
                {


                    /*" -327- PERFORM R0300_00_PROCESSA_MOTIVOS_DB_CLOSE_1 */

                    R0300_00_PROCESSA_MOTIVOS_DB_CLOSE_1();

                    /*" -329- MOVE 'S' TO WFIM-MOTIVOS */
                    _.Move("S", WFIM_MOTIVOS);

                    /*" -331- GO TO R0300-00-EXIT. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_00_EXIT*/ //GOTO
                    return;
                }

            }


            /*" -333- ADD 1 TO AC-L-MOTIVOS. */
            AC_L_MOTIVOS.Value = AC_L_MOTIVOS + 1;

            /*" -335- MOVE SPACES TO REG-ARQ-SEGAB02. */
            _.Move("", REG_ARQ_SEGAB02);

            /*" -336- IF SIMOTIVO-COD-TIPO-MOTIVO NOT = WCOD-TIPO-MOT-ANT */

            if (SIMOTIVO.DCLSI_MOTIVO.SIMOTIVO_COD_TIPO_MOTIVO != VARIAVEIS_DE_WORK.WCOD_TIPO_MOT_ANT)
            {

                /*" -337- PERFORM R0310-00-TRAZ-DESCR-TIPO-MOT */

                R0310_00_TRAZ_DESCR_TIPO_MOT_SECTION();

                /*" -338- MOVE '1' TO DET1-IDE-REGISTRO */
                _.Move("1", REG_ARQ_SEGAB02.SEGAB02_DETALHE_1.DET1_IDE_REGISTRO);

                /*" -339- MOVE SIMOTIVO-COD-TIPO-MOTIVO TO DET1-NUM-ITEM */
                _.Move(SIMOTIVO.DCLSI_MOTIVO.SIMOTIVO_COD_TIPO_MOTIVO, REG_ARQ_SEGAB02.SEGAB02_DETALHE_1.DET1_NUM_ITEM);

                /*" -340- MOVE ZEROS TO DET1-NUM-SUB-ITEM */
                _.Move(0, REG_ARQ_SEGAB02.SEGAB02_DETALHE_1.DET1_NUM_SUB_ITEM);

                /*" -341- MOVE SITIPMOT-DES-TIPO-MOTIVO TO DET1-DES-MOTIVO */
                _.Move(SITIPMOT.DCLSI_TIPO_MOTIVO.SITIPMOT_DES_TIPO_MOTIVO, REG_ARQ_SEGAB02.SEGAB02_DETALHE_1.DET1_DES_MOTIVO);

                /*" -342- WRITE REG-ARQ-SEGAB02 */
                ARQ_SEGAB02.Write(REG_ARQ_SEGAB02.GetMoveValues().ToString());

                /*" -343- ADD 1 TO AC-L-TP-MOTIVOS */
                AC_L_TP_MOTIVOS.Value = AC_L_TP_MOTIVOS + 1;

                /*" -345- ADD 1 TO AC-G-SEGAB002. */
                AC_G_SEGAB002.Value = AC_G_SEGAB002 + 1;
            }


            /*" -346- MOVE '1' TO DET1-IDE-REGISTRO */
            _.Move("1", REG_ARQ_SEGAB02.SEGAB02_DETALHE_1.DET1_IDE_REGISTRO);

            /*" -347- MOVE SIMOTIVO-COD-TIPO-MOTIVO TO DET1-NUM-ITEM */
            _.Move(SIMOTIVO.DCLSI_MOTIVO.SIMOTIVO_COD_TIPO_MOTIVO, REG_ARQ_SEGAB02.SEGAB02_DETALHE_1.DET1_NUM_ITEM);

            /*" -348- MOVE SIMOTIVO-NUM-MOTIVO TO DET1-NUM-SUB-ITEM */
            _.Move(SIMOTIVO.DCLSI_MOTIVO.SIMOTIVO_NUM_MOTIVO, REG_ARQ_SEGAB02.SEGAB02_DETALHE_1.DET1_NUM_SUB_ITEM);

            /*" -350- MOVE SIMOTIVO-DES-MOTIVO-TEXT TO DET1-DES-MOTIVO */
            _.Move(SIMOTIVO.DCLSI_MOTIVO.SIMOTIVO_DES_MOTIVO.SIMOTIVO_DES_MOTIVO_TEXT, REG_ARQ_SEGAB02.SEGAB02_DETALHE_1.DET1_DES_MOTIVO);

            /*" -351- WRITE REG-ARQ-SEGAB02. */
            ARQ_SEGAB02.Write(REG_ARQ_SEGAB02.GetMoveValues().ToString());

            /*" -353- ADD 1 TO AC-G-SEGAB002. */
            AC_G_SEGAB002.Value = AC_G_SEGAB002 + 1;

            /*" -353- MOVE SIMOTIVO-COD-TIPO-MOTIVO TO WCOD-TIPO-MOT-ANT. */
            _.Move(SIMOTIVO.DCLSI_MOTIVO.SIMOTIVO_COD_TIPO_MOTIVO, VARIAVEIS_DE_WORK.WCOD_TIPO_MOT_ANT);

        }

        [StopWatch]
        /*" R0300-00-PROCESSA-MOTIVOS-DB-FETCH-1 */
        public void R0300_00_PROCESSA_MOTIVOS_DB_FETCH_1()
        {
            /*" -318- EXEC SQL FETCH MOTIVOS INTO :SIMOTIVO-COD-TIPO-MOTIVO , :SIMOTIVO-NUM-MOTIVO , :SIMOTIVO-DES-MOTIVO END-EXEC. */

            if (MOTIVOS.Fetch())
            {
                _.Move(MOTIVOS.SIMOTIVO_COD_TIPO_MOTIVO, SIMOTIVO.DCLSI_MOTIVO.SIMOTIVO_COD_TIPO_MOTIVO);
                _.Move(MOTIVOS.SIMOTIVO_NUM_MOTIVO, SIMOTIVO.DCLSI_MOTIVO.SIMOTIVO_NUM_MOTIVO);
                _.Move(MOTIVOS.SIMOTIVO_DES_MOTIVO, SIMOTIVO.DCLSI_MOTIVO.SIMOTIVO_DES_MOTIVO);
            }

        }

        [StopWatch]
        /*" R0300-00-PROCESSA-MOTIVOS-DB-CLOSE-1 */
        public void R0300_00_PROCESSA_MOTIVOS_DB_CLOSE_1()
        {
            /*" -327- EXEC SQL CLOSE MOTIVOS END-EXEC */

            MOTIVOS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_00_EXIT*/

        [StopWatch]
        /*" R0310-00-TRAZ-DESCR-TIPO-MOT-SECTION */
        private void R0310_00_TRAZ_DESCR_TIPO_MOT_SECTION()
        {
            /*" -363- MOVE '0310' TO WNR-EXEC-SQL */
            _.Move("0310", WABEND.WNR_EXEC_SQL);

            /*" -369- PERFORM R0310_00_TRAZ_DESCR_TIPO_MOT_DB_SELECT_1 */

            R0310_00_TRAZ_DESCR_TIPO_MOT_DB_SELECT_1();

            /*" -372- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -373- DISPLAY 'R0310-ERRO NO SELECT DA SI_TIPO_MOTIVO' */
                _.Display($"R0310-ERRO NO SELECT DA SI_TIPO_MOTIVO");

                /*" -373- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0310-00-TRAZ-DESCR-TIPO-MOT-DB-SELECT-1 */
        public void R0310_00_TRAZ_DESCR_TIPO_MOT_DB_SELECT_1()
        {
            /*" -369- EXEC SQL SELECT DES_TIPO_MOTIVO INTO :SITIPMOT-DES-TIPO-MOTIVO FROM SEGUROS.SI_TIPO_MOTIVO WHERE COD_TIPO_MOTIVO = :SIMOTIVO-COD-TIPO-MOTIVO WITH UR END-EXEC. */

            var r0310_00_TRAZ_DESCR_TIPO_MOT_DB_SELECT_1_Query1 = new R0310_00_TRAZ_DESCR_TIPO_MOT_DB_SELECT_1_Query1()
            {
                SIMOTIVO_COD_TIPO_MOTIVO = SIMOTIVO.DCLSI_MOTIVO.SIMOTIVO_COD_TIPO_MOTIVO.ToString(),
            };

            var executed_1 = R0310_00_TRAZ_DESCR_TIPO_MOT_DB_SELECT_1_Query1.Execute(r0310_00_TRAZ_DESCR_TIPO_MOT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SITIPMOT_DES_TIPO_MOTIVO, SITIPMOT.DCLSI_TIPO_MOTIVO.SITIPMOT_DES_TIPO_MOTIVO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_00_EXIT*/

        [StopWatch]
        /*" R2100-00-MAX-GEARDETA-SECTION */
        private void R2100_00_MAX_GEARDETA_SECTION()
        {
            /*" -383- MOVE '2100' TO WNR-EXEC-SQL */
            _.Move("2100", WABEND.WNR_EXEC_SQL);

            /*" -389- PERFORM R2100_00_MAX_GEARDETA_DB_SELECT_1 */

            R2100_00_MAX_GEARDETA_DB_SELECT_1();

            /*" -392- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -393- DISPLAY 'ERRO MAX GE_AR_DETALHE - ARQUIVO: SEGAB002' */
                _.Display($"ERRO MAX GE_AR_DETALHE - ARQUIVO: SEGAB002");

                /*" -393- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2100-00-MAX-GEARDETA-DB-SELECT-1 */
        public void R2100_00_MAX_GEARDETA_DB_SELECT_1()
        {
            /*" -389- EXEC SQL SELECT VALUE(MAX(SEQ_GERACAO) + 1 , 1) INTO :GEARDETA-SEQ-GERACAO FROM SEGUROS.GE_AR_DETALHE WHERE NOM_ARQUIVO = 'SEGAB002' WITH UR END-EXEC. */

            var r2100_00_MAX_GEARDETA_DB_SELECT_1_Query1 = new R2100_00_MAX_GEARDETA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R2100_00_MAX_GEARDETA_DB_SELECT_1_Query1.Execute(r2100_00_MAX_GEARDETA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GEARDETA_SEQ_GERACAO, GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_00_EXIT*/

        [StopWatch]
        /*" R2200-00-INCLUI-GEARDETA-SECTION */
        private void R2200_00_INCLUI_GEARDETA_SECTION()
        {
            /*" -403- MOVE '2200' TO WNR-EXEC-SQL. */
            _.Move("2200", WABEND.WNR_EXEC_SQL);

            /*" -404- MOVE 'SEGAB002' TO GEARDETA-NOM-ARQUIVO */
            _.Move("SEGAB002", GEARDETA.DCLGE_AR_DETALHE.GEARDETA_NOM_ARQUIVO);

            /*" -405- MOVE SISTEMAS-DATA-MOV-ABERTO TO GEARDETA-DTH-GERACAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_GERACAO);

            /*" -408- MOVE ZEROS TO GEARDETA-QTD-REG-PROCESSADO GEARDETA-QTD-REG-REJEITADOS GEARDETA-QTD-REG-ACEITOS */
            _.Move(0, GEARDETA.DCLGE_AR_DETALHE.GEARDETA_QTD_REG_PROCESSADO, GEARDETA.DCLGE_AR_DETALHE.GEARDETA_QTD_REG_REJEITADOS, GEARDETA.DCLGE_AR_DETALHE.GEARDETA_QTD_REG_ACEITOS);

            /*" -409- MOVE ' ' TO GEARDETA-IND-MEIO-ENVIO */
            _.Move(" ", GEARDETA.DCLGE_AR_DETALHE.GEARDETA_IND_MEIO_ENVIO);

            /*" -410- MOVE 'E' TO GEARDETA-STA-ENVIO-RECEPCAO */
            _.Move("E", GEARDETA.DCLGE_AR_DETALHE.GEARDETA_STA_ENVIO_RECEPCAO);

            /*" -412- MOVE 'TXT' TO GEARDETA-COD-TIPO-ARQUIVO. */
            _.Move("TXT", GEARDETA.DCLGE_AR_DETALHE.GEARDETA_COD_TIPO_ARQUIVO);

            /*" -442- PERFORM R2200_00_INCLUI_GEARDETA_DB_INSERT_1 */

            R2200_00_INCLUI_GEARDETA_DB_INSERT_1();

            /*" -445- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -448- DISPLAY 'PROBLEMAS NO INSERT GE_AR_DETALHE' ' ' GEARDETA-NOM-ARQUIVO ' ' GEARDETA-SEQ-GERACAO */

                $"PROBLEMAS NO INSERT GE_AR_DETALHE {GEARDETA.DCLGE_AR_DETALHE.GEARDETA_NOM_ARQUIVO} {GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO}"
                .Display();

                /*" -450- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -450- ADD 1 TO AC-I-GEARDETA. */
            AC_I_GEARDETA.Value = AC_I_GEARDETA + 1;

        }

        [StopWatch]
        /*" R2200-00-INCLUI-GEARDETA-DB-INSERT-1 */
        public void R2200_00_INCLUI_GEARDETA_DB_INSERT_1()
        {
            /*" -442- EXEC SQL INSERT INTO SEGUROS.GE_AR_DETALHE (NOM_ARQUIVO, SEQ_GERACAO, DTH_ANO_REFERENCIA, DTH_MES_REFERENCIA, DTH_MOVIMENTO, DTH_GERACAO, DTH_RECEPCAO, IND_MEIO_ENVIO, STA_ENVIO_RECEPCAO, COD_TIPO_ARQUIVO, QTD_REG_PROCESSADO, QTD_REG_REJEITADOS, QTD_REG_ACEITOS, DTH_TIMESTAMP) VALUES (:GEARDETA-NOM-ARQUIVO, :GEARDETA-SEQ-GERACAO, :HOST-ANO-MOV-ABERTO, :HOST-MES-MOV-ABERTO, :SISTEMAS-DATA-MOV-ABERTO, :GEARDETA-DTH-GERACAO, :SISTEMAS-DATA-MOV-ABERTO, :GEARDETA-IND-MEIO-ENVIO, :GEARDETA-STA-ENVIO-RECEPCAO, :GEARDETA-COD-TIPO-ARQUIVO, :GEARDETA-QTD-REG-PROCESSADO, :GEARDETA-QTD-REG-REJEITADOS, :GEARDETA-QTD-REG-ACEITOS, CURRENT TIMESTAMP) END-EXEC. */

            var r2200_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1 = new R2200_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1()
            {
                GEARDETA_NOM_ARQUIVO = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_NOM_ARQUIVO.ToString(),
                GEARDETA_SEQ_GERACAO = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO.ToString(),
                HOST_ANO_MOV_ABERTO = HOST_ANO_MOV_ABERTO.ToString(),
                HOST_MES_MOV_ABERTO = HOST_MES_MOV_ABERTO.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                GEARDETA_DTH_GERACAO = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_GERACAO.ToString(),
                GEARDETA_IND_MEIO_ENVIO = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_IND_MEIO_ENVIO.ToString(),
                GEARDETA_STA_ENVIO_RECEPCAO = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_STA_ENVIO_RECEPCAO.ToString(),
                GEARDETA_COD_TIPO_ARQUIVO = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_COD_TIPO_ARQUIVO.ToString(),
                GEARDETA_QTD_REG_PROCESSADO = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_QTD_REG_PROCESSADO.ToString(),
                GEARDETA_QTD_REG_REJEITADOS = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_QTD_REG_REJEITADOS.ToString(),
                GEARDETA_QTD_REG_ACEITOS = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_QTD_REG_ACEITOS.ToString(),
            };

            R2200_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1.Execute(r2200_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_00_EXIT*/

        [StopWatch]
        /*" R8000-00-LE-DATA-CALENDARIO-SECTION */
        private void R8000_00_LE_DATA_CALENDARIO_SECTION()
        {
            /*" -460- MOVE '8000' TO WNR-EXEC-SQL */
            _.Move("8000", WABEND.WNR_EXEC_SQL);

            /*" -466- PERFORM R8000_00_LE_DATA_CALENDARIO_DB_SELECT_1 */

            R8000_00_LE_DATA_CALENDARIO_DB_SELECT_1();

            /*" -471- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -473- DISPLAY 'ERRO SELECT1 DA CALENDARIO. DATA: ' ' ' SISTEMAS-DATA-MOV-ABERTO */

                $"ERRO SELECT1 DA CALENDARIO. DATA:  {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}"
                .Display();

                /*" -475- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -484- PERFORM R8000_00_LE_DATA_CALENDARIO_DB_SELECT_2 */

            R8000_00_LE_DATA_CALENDARIO_DB_SELECT_2();

            /*" -490- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -492- IF SQLCODE NOT = +100 AND SQLCODE NOT = 0 */

            if (DB.SQLCODE != +100 && DB.SQLCODE != 0)
            {

                /*" -494- DISPLAY 'ERRO SELECT DA CALENDARIO. DATA: ' ' ' CALENDAR-DATA-CALENDARIO */

                $"ERRO SELECT DA CALENDARIO. DATA:  {CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO}"
                .Display();

                /*" -494- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R8000-00-LE-DATA-CALENDARIO-DB-SELECT-1 */
        public void R8000_00_LE_DATA_CALENDARIO_DB_SELECT_1()
        {
            /*" -466- EXEC SQL SELECT CURRENT DATE INTO :CALENDAR-DATA-CALENDARIO FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO = :SISTEMAS-DATA-MOV-ABERTO WITH UR END-EXEC. */

            var r8000_00_LE_DATA_CALENDARIO_DB_SELECT_1_Query1 = new R8000_00_LE_DATA_CALENDARIO_DB_SELECT_1_Query1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
            };

            var executed_1 = R8000_00_LE_DATA_CALENDARIO_DB_SELECT_1_Query1.Execute(r8000_00_LE_DATA_CALENDARIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CALENDAR_DATA_CALENDARIO, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_00_EXIT*/

        [StopWatch]
        /*" R8000-00-LE-DATA-CALENDARIO-DB-SELECT-2 */
        public void R8000_00_LE_DATA_CALENDARIO_DB_SELECT_2()
        {
            /*" -484- EXEC SQL SELECT DATA_CALENDARIO, DTH_ULT_DIA_MES INTO :CALENDAR-DATA-CALENDARIO, :CALENDAR-DTH-ULT-DIA-MES FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO = :CALENDAR-DATA-CALENDARIO AND DIA_SEMANA IN ( '6' , 'S' ) WITH UR END-EXEC. */

            var r8000_00_LE_DATA_CALENDARIO_DB_SELECT_2_Query1 = new R8000_00_LE_DATA_CALENDARIO_DB_SELECT_2_Query1()
            {
                CALENDAR_DATA_CALENDARIO = CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO.ToString(),
            };

            var executed_1 = R8000_00_LE_DATA_CALENDARIO_DB_SELECT_2_Query1.Execute(r8000_00_LE_DATA_CALENDARIO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CALENDAR_DATA_CALENDARIO, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);
                _.Move(executed_1.CALENDAR_DTH_ULT_DIA_MES, CALENDAR.DCLCALENDARIO.CALENDAR_DTH_ULT_DIA_MES);
            }


        }

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -504- CLOSE ARQ-SEGAB02. */
            ARQ_SEGAB02.Close();

            /*" -505- DISPLAY '********************************' */
            _.Display($"********************************");

            /*" -506- DISPLAY '*     SI3041B - CANCELADO      *' */
            _.Display($"*     SI3041B - CANCELADO      *");

            /*" -508- DISPLAY '********************************' */
            _.Display($"********************************");

            /*" -509- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -511- DISPLAY WABEND */
            _.Display(WABEND);

            /*" -511- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -515- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -515- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}