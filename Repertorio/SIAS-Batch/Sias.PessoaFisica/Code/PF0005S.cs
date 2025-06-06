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
using Sias.PessoaFisica.DB2.PF0005S;

namespace Code
{
    public class PF0005S
    {
        public bool IsCall { get; set; }

        public PF0005S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      * SISTEMA.........: SIAS                                         *      */
        /*"      * MODULO..........: PF                                           *      */
        /*"      * PROGRAMA........: PF0005S                                      *      */
        /*"      * ANALISTA........: HUSNI ALI HUSNI                              *      */
        /*"      * DATA............: 08/08/2024                                   *      */
        /*"      ******************************************************************      */
        /*"      * OBJETIVO........: REALIZAR TRATAMENTO NO HISTOTICO DE PROPOSTAS*      */
        /*"      *                                                                *      */
        /*"      *==> TIPO DE ACAO                                                *      */
        /*"      *    (01) INSERIR INFORMACAO NO HISTORICO DA PROPOSTA            *      */
        /*"      ******************************************************************      */
        /*"      * VERSAO     DATA     RESPONSAVEL       ALTERACAO                *      */
        /*"      ******************************************************************      */
        /*"V.XX  *   VERSAO XX - DEMANDA XXXXXX - XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX*      */
        /*"      *               XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX*      */
        /*"      *               XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX          *      */
        /*"      *                                                                *      */
        /*"      * EM DD/MM/AAAA - XXXXXXXXXXXXXXXXX    PROCURE POR V.XX          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.02  * VERSAO 02     - DEMANDA 595918   ABEND OPTI-4261               *      */
        /*"      *                 LK-PF005-E-IND-TP-SENSIBILIZA = 'S' OR = 'P'   *      */
        /*"      *                                                                *      */
        /*"      * EM 07/01/2025 - HUSNI ALI HUSNI/SERGIO LORETO                  *      */
        /*"      *                                         PROCURE POR V.02       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.01  * VERSAO 01     - DEMANDA 595918   TAREFA 598641                 *      */
        /*"      *                 MOVIMENTAR 'N' PARA VARIAVEL DE TRACE          *      */
        /*"      *                                                                *      */
        /*"      * EM 08/08/2024 - HUSNI ALI HUSNI                                *      */
        /*"      *                                         PROCURE POR V.01       *      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"01    NU006-SIT-COBRANCA-SIVPF       PIC S9(004) COMP-5 VALUE 0*/
        public IntBasis NU006_SIT_COBRANCA_SIVPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01    NU006-DTA-INI-VIGENCIA         PIC S9(004) COMP-5 VALUE 0*/
        public IntBasis NU006_DTA_INI_VIGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01    NU006-DTA-FIM-VIGENCIA         PIC S9(004) COMP-5 VALUE 0*/
        public IntBasis NU006_DTA_FIM_VIGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01    NU006-NUM-PARCELA              PIC S9(004) COMP-5 VALUE 0*/
        public IntBasis NU006_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01    NU006-COD-TP-LANCAMENTO        PIC S9(004) COMP-5 VALUE 0*/
        public IntBasis NU006_COD_TP_LANCAMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01    NU006-VLR-PREMIO               PIC S9(004) COMP-5 VALUE 0*/
        public IntBasis NU006_VLR_PREMIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01    NU006-COD-ERRO                 PIC S9(004) COMP-5 VALUE 0*/
        public IntBasis NU006_COD_ERRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01    NU006-DTA-PROCESSAMENTO-CEF    PIC S9(004) COMP-5 VALUE 0*/
        public IntBasis NU006_DTA_PROCESSAMENTO_CEF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01    WORK*/
        public PF0005S_WORK WORK { get; set; } = new PF0005S_WORK();
        public class PF0005S_WORK : VarBasis
        {
            /*"  05  WS-PROGRAMA                    PIC  X(008) VALUE SPACES*/
            public StringBasis WS_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"  05  WS-DATAS*/
            public PF0005S_WS_DATAS WS_DATAS { get; set; } = new PF0005S_WS_DATAS();
            public class PF0005S_WS_DATAS : VarBasis
            {
                /*"   10 WS-C-DATE-CURRENT              PIC  X(014) VALUE SPACES*/
                public StringBasis WS_C_DATE_CURRENT { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
                /*"   10 WS-C-DATE-COMPILED             PIC  X(014) VALUE SPACES*/
                public StringBasis WS_C_DATE_COMPILED { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
                /*"   10 WS-CURRENT-TIMESTAMP           PIC  X(026) VALUE SPACES*/
                public StringBasis WS_CURRENT_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
                /*"  05  WS-EDIT*/
            }
            public PF0005S_WS_EDIT WS_EDIT { get; set; } = new PF0005S_WS_EDIT();
            public class PF0005S_WS_EDIT : VarBasis
            {
                /*"   10 WS-SMALLINT                    PIC ZZ.ZZ9- OCCURS 20 TIMES*/
                public ListBasis<IntBasis, Int64> WS_SMALLINT { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "6", "ZZ.ZZ9-"), 20);
                /*"   10 WS-INTEGER                     PIC Z.ZZZ.ZZZ.ZZ9-                                                 OCCURS 5 TIMES*/
                public ListBasis<IntBasis, Int64> WS_INTEGER { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "11", "Z.ZZZ.ZZZ.ZZ9-"), 5);
                /*"   10 WS-BIGINT                      PIC 99999999999999                                                 OCCURS 5 TIMES*/
                public ListBasis<IntBasis, Int64> WS_BIGINT { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "14", "99999999999999"), 5);
                /*"   10 WS-DECIMAL                     PIC ZZZZZZZZZZ9,999999                                                 OCCURS 10 TIMES*/
                public ListBasis<DoubleBasis, double> WS_DECIMAL { get; set; } = new ListBasis<DoubleBasis, double>(new PIC("9", "11", "ZZZZZZZZZZ9V999999"), 10);
                /*"  05  WS-ERRO*/
            }
            public PF0005S_WS_ERRO WS_ERRO { get; set; } = new PF0005S_WS_ERRO();
            public class PF0005S_WS_ERRO : VarBasis
            {
                /*"   10 WS-SECTION                     PIC  X(005) VALUE SPACES*/
                public StringBasis WS_SECTION { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"   10 WS-IND-ERRO                    PIC  9(001) VALUE 0*/
                public IntBasis WS_IND_ERRO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
                /*"   10 WS-MENSAGEM                    PIC  X(255) VALUE SPACES*/
                public StringBasis WS_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "255", "X(255)"), @"");
                /*"   10 WS-TABELA                      PIC  X(050) VALUE SPACES*/
                public StringBasis WS_TABELA { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
                /*"   10 WS-SQLCODE                     PIC  ZZZZ9-*/
                public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "6", "ZZZZ9-"));
                /*"   10 WS-SQLERRMC                    PIC  X(076) VALUE SPACES*/
                public StringBasis WS_SQLERRMC { get; set; } = new StringBasis(new PIC("X", "76", "X(076)"), @"");
                /*"   10 WS-SQLSTATE                    PIC  X(005) VALUE SPACES*/
                public StringBasis WS_SQLSTATE { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"  05 WS-INDICADORES*/
            }
            public PF0005S_WS_INDICADORES WS_INDICADORES { get; set; } = new PF0005S_WS_INDICADORES();
            public class PF0005S_WS_INDICADORES : VarBasis
            {
                /*"   10 WS-IND-TITULO                  PIC  9(001) VALUE 0*/
                public IntBasis WS_IND_TITULO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            }
        }


        public Copies.RSGEWSTR RSGEWSTR { get; set; } = new Copies.RSGEWSTR();
        public Copies.RSGEWVDT RSGEWVDT { get; set; } = new Copies.RSGEWVDT();
        public Copies.PF0005W PF0005W { get; set; } = new Copies.PF0005W();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.HISPROFI HISPROFI { get; set; } = new Dclgens.HISPROFI();
        public Dclgens.PFMOTPRO PFMOTPRO { get; set; } = new Dclgens.PFMOTPRO();
        public Dclgens.PROPFID PROPFID { get; set; } = new Dclgens.PROPFID();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(PF0005W PF0005W_P) //PROCEDURE DIVISION USING 
        /*PROCEDURE DIVISION
        LK_PF005_E_TRACE
        LK_PF005_E_ACAO
        LK_PF005_E_NUM_IDENTIFICACAO
        LK_PF005_E_DATA_SITUACAO
        LK_PF005_E_NSAS_SIVPF
        LK_PF005_E_NSL
        LK_PF005_E_SIT_PROPOSTA
        LK_PF005_E_SIT_COBRANCA_SIVPF
        LK_PF005_E_SIT_MOTIVO_SIVPF
        LK_PF005_E_COD_EMPRESA_SIVPF
        LK_PF005_E_COD_PRODUTO_SIVPF
        LK_PF005_E_IND_TP_ACAO
        LK_PF005_E_IND_TP_SENSIBILIZA
        LK_PF005_E_DTA_INI_VIGENCIA
        LK_PF005_E_DTA_FIM_VIGENCIA
        LK_PF005_E_NUM_PARCELA
        LK_PF005_E_COD_TP_LANCAMENTO
        LK_PF005_E_VLR_PREMIO
        LK_PF005_E_COD_ERRO
        LK_PF005_E_DTA_PROCESSA_CEF
        LK_PF005_E_COD_USUARIO
        LK_PF005_E_NOM_PROGRAMA
        LK_PF005_IND_ERRO
        LK_PF005_MENSAGEM
        LK_PF005_NOM_TABELA
        LK_PF005_SQLCODE
        LK_PF005_SQLERRMC
        LK_PF005_SQLSTATE
        */
        {
            try
            {
                this.PF0005W = PF0005W_P;

                /*" -0- FLUXCONTROL_PERFORM P0000-INICIALIZAR-SECTION */

                P0000_INICIALIZAR_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { PF0005W };
            return Result;
        }

        [StopWatch]
        /*" P0000-INICIALIZAR-SECTION */
        private void P0000_INICIALIZAR_SECTION()
        {
            /*" -184- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -185- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -186- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -189- MOVE FUNCTION CURRENT-DATE(1:14) TO WS-C-DATE-CURRENT. */
            _.Move(_.CurrentDate(0, 14), WORK.WS_DATAS.WS_C_DATE_CURRENT);

            /*" -192- MOVE FUNCTION WHEN-COMPILED TO WS-C-DATE-COMPILED. */
            _.Move(_.WhenCompiled(), WORK.WS_DATAS.WS_C_DATE_COMPILED);

            /*" -197- INITIALIZE LK-PF005-IND-ERRO LK-PF005-MENSAGEM LK-PF005-NOM-TABELA LK-PF005-SQLCODE LK-PF005-SQLERRMC LK-PF005-SQLSTATE WS-ERRO */
            _.Initialize(
                PF0005W.LK_PF005_IND_ERRO
                , PF0005W.LK_PF005_MENSAGEM
                , PF0005W.LK_PF005_NOM_TABELA
                , PF0005W.LK_PF005_SQLCODE
                , PF0005W.LK_PF005_SQLERRMC
                , PF0005W.LK_PF005_SQLSTATE
                , WORK.WS_ERRO
            );

            /*" -198- IF NOT ( LK-PF005-E-TRACE = 'S' OR = 'N' ) */

            if (!(PF0005W.LK_PF005_E_TRACE.In("S", "N")))
            {

                /*" -199- MOVE 'N' TO LK-PF005-E-TRACE */
                _.Move("N", PF0005W.LK_PF005_E_TRACE);

                /*" -201- END-IF */
            }


            /*" -203- PERFORM P0050-VERIFICAR-SISTEMA */

            P0050_VERIFICAR_SISTEMA_SECTION();

            /*" -204- IF LK-PF005-E-TRACE = 'S' */

            if (PF0005W.LK_PF005_E_TRACE == "S")
            {

                /*" -205- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -206- DISPLAY '*              P F 0 0 0 5 S                 *' */
                _.Display($"*              P F 0 0 0 5 S                 *");

                /*" -207- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -214- DISPLAY '* DATA COMPILACAO..: ' WS-C-DATE-COMPILED(7:2) '/' WS-C-DATE-COMPILED(5:2) '/' WS-C-DATE-COMPILED(1:4) '-' WS-C-DATE-COMPILED(9:2) ':' WS-C-DATE-COMPILED(11:2) ':' WS-C-DATE-COMPILED(13:2) */

                $"* DATA COMPILACAO..: {WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(7, 2)}/{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(5, 2)}/{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(1, 4)}-{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(9, 2)}:{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(11, 2)}:{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(13, 2)}"
                .Display();

                /*" -221- DISPLAY '* DATA EXECUCAO....: ' WS-C-DATE-CURRENT(7:2) '/' WS-C-DATE-CURRENT(5:2) '/' WS-C-DATE-CURRENT(1:4) '-' WS-C-DATE-CURRENT(9:2) ':' WS-C-DATE-CURRENT(11:2) ':' WS-C-DATE-CURRENT(13:2) */

                $"* DATA EXECUCAO....: {WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(7, 2)}/{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(5, 2)}/{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(1, 4)}-{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(9, 2)}:{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(11, 2)}:{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(13, 2)}"
                .Display();

                /*" -225- DISPLAY '* DATA SISTEMA.....: ' SISTEMAS-DATA-MOV-ABERTO(9:2) '/' SISTEMAS-DATA-MOV-ABERTO(6:2) '/' SISTEMAS-DATA-MOV-ABERTO(1:4) */

                $"* DATA SISTEMA.....: {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2)}/{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2)}/{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4)}"
                .Display();

                /*" -226- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -227- DISPLAY '*             DADOS DE ENTRADA               *' */
                _.Display($"*             DADOS DE ENTRADA               *");

                /*" -228- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -229- DISPLAY '* TRACE..............: ' LK-PF005-E-TRACE */
                _.Display($"* TRACE..............: {PF0005W.LK_PF005_E_TRACE}");

                /*" -230- DISPLAY '* ACAO...............: ' LK-PF005-E-ACAO */
                _.Display($"* ACAO...............: {PF0005W.LK_PF005_E_ACAO}");

                /*" -232- MOVE LK-PF005-E-NUM-IDENTIFICACAO TO WS-BIGINT(01) */
                _.Move(PF0005W.LK_PF005_E_NUM_IDENTIFICACAO, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -233- DISPLAY '* NUM-IDENTIFICACAO..: ' WS-BIGINT(01) */
                _.Display($"* NUM-IDENTIFICACAO..: {WORK.WS_EDIT.WS_BIGINT[1]}");

                /*" -234- DISPLAY '* DATA-SITUACAO......: ' LK-PF005-E-DATA-SITUACAO */
                _.Display($"* DATA-SITUACAO......: {PF0005W.LK_PF005_E_DATA_SITUACAO}");

                /*" -235- MOVE LK-PF005-E-NSAS-SIVPF TO WS-INTEGER(01) */
                _.Move(PF0005W.LK_PF005_E_NSAS_SIVPF, WORK.WS_EDIT.WS_INTEGER[01]);

                /*" -236- DISPLAY '* NSAS-SIVPF.........: ' WS-INTEGER(01) */
                _.Display($"* NSAS-SIVPF.........: {WORK.WS_EDIT.WS_INTEGER[1]}");

                /*" -237- MOVE LK-PF005-E-NSL TO WS-INTEGER(01) */
                _.Move(PF0005W.LK_PF005_E_NSL, WORK.WS_EDIT.WS_INTEGER[01]);

                /*" -238- DISPLAY '* NSL................: ' WS-INTEGER(01) */
                _.Display($"* NSL................: {WORK.WS_EDIT.WS_INTEGER[1]}");

                /*" -239- DISPLAY '* SIT-PROPOSTA.......: ' LK-PF005-E-SIT-PROPOSTA */
                _.Display($"* SIT-PROPOSTA.......: {PF0005W.LK_PF005_E_SIT_PROPOSTA}");

                /*" -241- DISPLAY '* SIT-COBRANCA-SIVPF.: ' LK-PF005-E-SIT-COBRANCA-SIVPF */
                _.Display($"* SIT-COBRANCA-SIVPF.: {PF0005W.LK_PF005_E_SIT_COBRANCA_SIVPF}");

                /*" -243- MOVE LK-PF005-E-SIT-MOTIVO-SIVPF TO WS-INTEGER(01) */
                _.Move(PF0005W.LK_PF005_E_SIT_MOTIVO_SIVPF, WORK.WS_EDIT.WS_INTEGER[01]);

                /*" -244- DISPLAY '* SIT-MOTIVO-SIVPF...: ' WS-INTEGER(01) */
                _.Display($"* SIT-MOTIVO-SIVPF...: {WORK.WS_EDIT.WS_INTEGER[1]}");

                /*" -246- MOVE LK-PF005-E-COD-EMPRESA-SIVPF TO WS-SMALLINT(01) */
                _.Move(PF0005W.LK_PF005_E_COD_EMPRESA_SIVPF, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -247- DISPLAY '* COD-EMPRESA-SIVPF..: ' WS-SMALLINT(01) */
                _.Display($"* COD-EMPRESA-SIVPF..: {WORK.WS_EDIT.WS_SMALLINT[1]}");

                /*" -249- MOVE LK-PF005-E-COD-PRODUTO-SIVPF TO WS-SMALLINT(01) */
                _.Move(PF0005W.LK_PF005_E_COD_PRODUTO_SIVPF, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -250- DISPLAY '* COD-PRODUTO-SIVPF..: ' WS-SMALLINT(01) */
                _.Display($"* COD-PRODUTO-SIVPF..: {WORK.WS_EDIT.WS_SMALLINT[1]}");

                /*" -251- DISPLAY '* IND-TP-ACAO........: ' LK-PF005-E-IND-TP-ACAO */
                _.Display($"* IND-TP-ACAO........: {PF0005W.LK_PF005_E_IND_TP_ACAO}");

                /*" -253- DISPLAY '* IND-TP-SENSIBILIZA.: ' LK-PF005-E-IND-TP-SENSIBILIZA */
                _.Display($"* IND-TP-SENSIBILIZA.: {PF0005W.LK_PF005_E_IND_TP_SENSIBILIZA}");

                /*" -255- DISPLAY '* DTA-INI-VIGENCIA...: ' LK-PF005-E-DTA-INI-VIGENCIA */
                _.Display($"* DTA-INI-VIGENCIA...: {PF0005W.LK_PF005_E_DTA_INI_VIGENCIA}");

                /*" -257- DISPLAY '* DTA-FIM-VIGENCIA...: ' LK-PF005-E-DTA-FIM-VIGENCIA */
                _.Display($"* DTA-FIM-VIGENCIA...: {PF0005W.LK_PF005_E_DTA_FIM_VIGENCIA}");

                /*" -258- MOVE LK-PF005-E-NUM-PARCELA TO WS-INTEGER(01) */
                _.Move(PF0005W.LK_PF005_E_NUM_PARCELA, WORK.WS_EDIT.WS_INTEGER[01]);

                /*" -259- DISPLAY '* NUM-PARCELA........: ' WS-INTEGER(01) */
                _.Display($"* NUM-PARCELA........: {WORK.WS_EDIT.WS_INTEGER[1]}");

                /*" -261- MOVE LK-PF005-E-COD-TP-LANCAMENTO TO WS-SMALLINT(01) */
                _.Move(PF0005W.LK_PF005_E_COD_TP_LANCAMENTO, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -262- DISPLAY '* COD-TP-LANCAMENTO..: ' WS-SMALLINT(01) */
                _.Display($"* COD-TP-LANCAMENTO..: {WORK.WS_EDIT.WS_SMALLINT[1]}");

                /*" -263- MOVE LK-PF005-E-VLR-PREMIO TO WS-DECIMAL(01) */
                _.Move(PF0005W.LK_PF005_E_VLR_PREMIO, WORK.WS_EDIT.WS_DECIMAL[01]);

                /*" -264- DISPLAY '* VLR-PREMIO.........: ' WS-DECIMAL(01) */
                _.Display($"* VLR-PREMIO.........: {WORK.WS_EDIT.WS_DECIMAL[1]}");

                /*" -265- MOVE LK-PF005-E-COD-ERRO TO WS-SMALLINT(01) */
                _.Move(PF0005W.LK_PF005_E_COD_ERRO, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -266- DISPLAY '* COD-ERRO...........: ' WS-SMALLINT(01) */
                _.Display($"* COD-ERRO...........: {WORK.WS_EDIT.WS_SMALLINT[1]}");

                /*" -268- DISPLAY '* DTA-PROCESSAMENTO-CEF...: ' LK-PF005-E-DTA-PROCESSA-CEF */
                _.Display($"* DTA-PROCESSAMENTO-CEF...: {PF0005W.LK_PF005_E_DTA_PROCESSA_CEF}");

                /*" -269- DISPLAY '* COD-USUARIO........: ' LK-PF005-E-COD-USUARIO */
                _.Display($"* COD-USUARIO........: {PF0005W.LK_PF005_E_COD_USUARIO}");

                /*" -270- DISPLAY '* NOM-PROGRAMA.......: ' LK-PF005-E-NOM-PROGRAMA */
                _.Display($"* NOM-PROGRAMA.......: {PF0005W.LK_PF005_E_NOM_PROGRAMA}");

                /*" -271- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -273- END-IF */
            }


            /*" -273- PERFORM P0005-PROCESSAR. */

            P0005_PROCESSAR_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0000_99_EXIT*/

        [StopWatch]
        /*" P0005-PROCESSAR-SECTION */
        private void P0005_PROCESSAR_SECTION()
        {
            /*" -284- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0005_00_START */

            P0005_00_START();

        }

        [StopWatch]
        /*" P0005-00-START */
        private void P0005_00_START(bool isPerform = false)
        {
            /*" -287- MOVE 'P0005' TO WS-SECTION */
            _.Move("P0005", WORK.WS_ERRO.WS_SECTION);

            /*" -287- PERFORM P0005-05-INICIO. */

            P0005_05_INICIO(true);

        }

        [StopWatch]
        /*" P0005-05-INICIO */
        private void P0005_05_INICIO(bool isPerform = false)
        {
            /*" -293- PERFORM P0100-VALIDAR-LINKAGE. */

            P0100_VALIDAR_LINKAGE_SECTION();

            /*" -294- EVALUATE LK-PF005-E-ACAO */
            switch (PF0005W.LK_PF005_E_ACAO.Value)
            {

                /*" -295- WHEN 01 */
                case 01:

                    /*" -296- PERFORM P0301-TRATAR-TIPO-ACAO-01 */

                    P0301_TRATAR_TIPO_ACAO_01_SECTION();

                    /*" -297- WHEN OTHER */
                    break;
                default:

                    /*" -298- MOVE 1 TO WS-IND-ERRO */
                    _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                    /*" -302- STRING WS-SECTION ' - ACAO INFORMADA INVALIDA.' '<ACAO=' LK-PF005-E-ACAO '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                    #region STRING
                    var spl1 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                    spl1 += " - ACAO INFORMADA INVALIDA.";
                    spl1 += "<ACAO=";
                    var spl2 = PF0005W.LK_PF005_E_ACAO.GetMoveValues();
                    spl2 += ">";
                    var results3 = spl1 + spl2;
                    _.Move(results3, WORK.WS_ERRO.WS_MENSAGEM);
                    #endregion

                    /*" -305- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                    _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                    /*" -306- MOVE 0 TO WS-SQLCODE */
                    _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                    /*" -307- GO TO P9999-ERRO */

                    P9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -309- END-EVALUATE */
                    break;
            }


            /*" -309- PERFORM P0010-FINALIZAR. */

            P0010_FINALIZAR_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0005_99_EXIT*/

        [StopWatch]
        /*" P0010-FINALIZAR-SECTION */
        private void P0010_FINALIZAR_SECTION()
        {
            /*" -320- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0010_00_START */

            P0010_00_START();

        }

        [StopWatch]
        /*" P0010-00-START */
        private void P0010_00_START(bool isPerform = false)
        {
            /*" -323- MOVE 'P0010' TO WS-SECTION */
            _.Move("P0010", WORK.WS_ERRO.WS_SECTION);

            /*" -323- PERFORM P0010-05-INICIO. */

            P0010_05_INICIO(true);

        }

        [StopWatch]
        /*" P0010-05-INICIO */
        private void P0010_05_INICIO(bool isPerform = false)
        {
            /*" -328- MOVE 0 TO LK-PF005-IND-ERRO */
            _.Move(0, PF0005W.LK_PF005_IND_ERRO);

            /*" -330- STRING 'OPERACAO SOLICITADA REALIZADA COM SUCESSO.' DELIMITED BY SIZE INTO LK-PF005-MENSAGEM */
            #region STRING
            var spl3 = "OPERACAO SOLICITADA REALIZADA COM SUCESSO.";
            _.Move(spl3, PF0005W.LK_PF005_MENSAGEM);
            #endregion

            /*" -333- MOVE SPACES TO LK-PF005-NOM-TABELA LK-PF005-SQLERRMC LK-PF005-SQLSTATE */
            _.Move("", PF0005W.LK_PF005_NOM_TABELA, PF0005W.LK_PF005_SQLERRMC, PF0005W.LK_PF005_SQLSTATE);

            /*" -335- MOVE 0 TO LK-PF005-SQLCODE */
            _.Move(0, PF0005W.LK_PF005_SQLCODE);

            /*" -335- PERFORM P0010-99-EXIT. */

            P0010_99_EXIT(true);

        }

        [StopWatch]
        /*" P0010-99-EXIT */
        private void P0010_99_EXIT(bool isPerform = false)
        {
            /*" -338- GOBACK. */

            throw new GoBack();

        }

        [StopWatch]
        /*" P0050-VERIFICAR-SISTEMA-SECTION */
        private void P0050_VERIFICAR_SISTEMA_SECTION()
        {
            /*" -346- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0050_00_START */

            P0050_00_START();

        }

        [StopWatch]
        /*" P0050-00-START */
        private void P0050_00_START(bool isPerform = false)
        {
            /*" -350- MOVE 'P0050' TO WS-SECTION */
            _.Move("P0050", WORK.WS_ERRO.WS_SECTION);

            /*" -350- PERFORM P0050-05-INICIO. */

            P0050_05_INICIO(true);

        }

        [StopWatch]
        /*" P0050-05-INICIO */
        private void P0050_05_INICIO(bool isPerform = false)
        {
            /*" -360- PERFORM P0050_05_INICIO_DB_SELECT_1 */

            P0050_05_INICIO_DB_SELECT_1();

            /*" -363- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -364- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -368- STRING WS-SECTION ' - ERRO NO SELECT NA SEGUROS.SISTEMA.' '<SISTEMA=PF>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl4 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl4 += " - ERRO NO SELECT NA SEGUROS.SISTEMA.";
                spl4 += "<SISTEMA=PF>";
                _.Move(spl4, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -369- MOVE 'SEGUROS.SISTEMAS' TO WS-TABELA */
                _.Move("SEGUROS.SISTEMAS", WORK.WS_ERRO.WS_TABELA);

                /*" -370- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -371- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -372- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -373- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -375- END-IF */
            }


            /*" -376- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -377- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -381- STRING WS-SECTION ' - REGISTRO DE CONTROLE SISTEMA NAO CADASTRADO.' '<SISTEMA=PF>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl5 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl5 += " - REGISTRO DE CONTROLE SISTEMA NAO CADASTRADO.";
                spl5 += "<SISTEMA=PF>";
                _.Move(spl5, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -382- MOVE 'SEGUROS.SISTEMAS' TO WS-TABELA */
                _.Move("SEGUROS.SISTEMAS", WORK.WS_ERRO.WS_TABELA);

                /*" -383- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -384- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -385- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -386- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -386- END-IF. */
            }


        }

        [StopWatch]
        /*" P0050-05-INICIO-DB-SELECT-1 */
        public void P0050_05_INICIO_DB_SELECT_1()
        {
            /*" -360- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'PF' WITH UR END-EXEC. */

            var p0050_05_INICIO_DB_SELECT_1_Query1 = new P0050_05_INICIO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = P0050_05_INICIO_DB_SELECT_1_Query1.Execute(p0050_05_INICIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0050_99_EXIT*/

        [StopWatch]
        /*" P0100-VALIDAR-LINKAGE-SECTION */
        private void P0100_VALIDAR_LINKAGE_SECTION()
        {
            /*" -397- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0100_00_START */

            P0100_00_START();

        }

        [StopWatch]
        /*" P0100-00-START */
        private void P0100_00_START(bool isPerform = false)
        {
            /*" -400- MOVE 'P0100' TO WS-SECTION. */
            _.Move("P0100", WORK.WS_ERRO.WS_SECTION);

            /*" -400- PERFORM P0100-05-INICIO. */

            P0100_05_INICIO(true);

        }

        [StopWatch]
        /*" P0100-05-INICIO */
        private void P0100_05_INICIO(bool isPerform = false)
        {
            /*" -405- IF LK-PF005-E-NUM-IDENTIFICACAO = 0 */

            if (PF0005W.LK_PF005_E_NUM_IDENTIFICACAO == 0)
            {

                /*" -406- MOVE 'P0100' TO WS-SECTION */
                _.Move("P0100", WORK.WS_ERRO.WS_SECTION);

                /*" -407- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -409- MOVE LK-PF005-E-NUM-IDENTIFICACAO TO WS-BIGINT(01) */
                _.Move(PF0005W.LK_PF005_E_NUM_IDENTIFICACAO, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -412- STRING WS-SECTION ' - CERTIFICADO NAO INFORMADO.' '<NUM-IDENTIFICACAO=' WS-BIGINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl6 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl6 += " - CERTIFICADO NAO INFORMADO.";
                spl6 += "<NUM-IDENTIFICACAO=";
                var spl7 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                spl7 += ">";
                var results8 = spl6 + spl7;
                _.Move(results8, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -415- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -416- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -417- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -419- END-IF. */
            }


            /*" -428- PERFORM P0110-PESQUISAR-PROP-FIDELIZ */

            P0110_PESQUISAR_PROP_FIDELIZ_SECTION();

            /*" -430- IF NOT ( LK-PF005-E-IND-TP-ACAO = 'I' OR = 'A' OR = 'E' OR = 'R' ) */

            if (!(PF0005W.LK_PF005_E_IND_TP_ACAO.In("I", "A", "E", "R")))
            {

                /*" -431- MOVE 'P0100' TO WS-SECTION */
                _.Move("P0100", WORK.WS_ERRO.WS_SECTION);

                /*" -432- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -435- STRING WS-SECTION ' - TIPO DE ACAO REALIZADA INVALIDO.' '<IND-TP-ACAO=' LK-PF005-E-IND-TP-ACAO '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl8 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl8 += " - TIPO DE ACAO REALIZADA INVALIDO.";
                spl8 += "<IND-TP-ACAO=";
                var spl9 = PF0005W.LK_PF005_E_IND_TP_ACAO.GetMoveValues();
                spl9 += ">";
                var results10 = spl8 + spl9;
                _.Move(results10, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -438- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -439- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -440- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -442- END-IF */
            }


            /*" -443- IF LK-PF005-E-IND-TP-ACAO = 'E' */

            if (PF0005W.LK_PF005_E_IND_TP_ACAO == "E")
            {

                /*" -444- IF LK-PF005-E-NSAS-SIVPF = 000 */

                if (PF0005W.LK_PF005_E_NSAS_SIVPF == 000)
                {

                    /*" -445- MOVE 'P0100' TO WS-SECTION */
                    _.Move("P0100", WORK.WS_ERRO.WS_SECTION);

                    /*" -446- MOVE 1 TO WS-IND-ERRO */
                    _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                    /*" -447- MOVE LK-PF005-E-NSAS-SIVPF TO WS-INTEGER(01) */
                    _.Move(PF0005W.LK_PF005_E_NSAS_SIVPF, WORK.WS_EDIT.WS_INTEGER[01]);

                    /*" -450- STRING WS-SECTION ' - INFORME O NSA SIVPF.' '<NSAS-SIVPF=' WS-INTEGER(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                    #region STRING
                    var spl10 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                    spl10 += " - INFORME O NSA SIVPF.";
                    spl10 += "<NSAS-SIVPF=";
                    var spl11 = WORK.WS_EDIT.WS_INTEGER[01].GetMoveValues();
                    spl11 += ">";
                    var results12 = spl10 + spl11;
                    _.Move(results12, WORK.WS_ERRO.WS_MENSAGEM);
                    #endregion

                    /*" -453- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                    _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                    /*" -454- MOVE 0 TO WS-SQLCODE */
                    _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                    /*" -455- GO TO P9999-ERRO */

                    P9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -456- END-IF */
                }


                /*" -457- IF LK-PF005-E-NSL = 000 */

                if (PF0005W.LK_PF005_E_NSL == 000)
                {

                    /*" -458- MOVE 'P0100' TO WS-SECTION */
                    _.Move("P0100", WORK.WS_ERRO.WS_SECTION);

                    /*" -459- MOVE 1 TO WS-IND-ERRO */
                    _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                    /*" -460- MOVE LK-PF005-E-NSL TO WS-INTEGER(01) */
                    _.Move(PF0005W.LK_PF005_E_NSL, WORK.WS_EDIT.WS_INTEGER[01]);

                    /*" -463- STRING WS-SECTION ' - INFORME O NSL SIVPF.' '<NSL=' WS-INTEGER(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                    #region STRING
                    var spl12 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                    spl12 += " - INFORME O NSL SIVPF.";
                    spl12 += "<NSL=";
                    var spl13 = WORK.WS_EDIT.WS_INTEGER[01].GetMoveValues();
                    spl13 += ">";
                    var results14 = spl12 + spl13;
                    _.Move(results14, WORK.WS_ERRO.WS_MENSAGEM);
                    #endregion

                    /*" -466- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                    _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                    /*" -467- MOVE 0 TO WS-SQLCODE */
                    _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                    /*" -468- GO TO P9999-ERRO */

                    P9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -469- END-IF */
                }


                /*" -471- IF NOT ( LK-PF005-E-IND-TP-SENSIBILIZA = 'S' OR = 'P' OR = ' ' ) */

                if (!(PF0005W.LK_PF005_E_IND_TP_SENSIBILIZA.In("S", "P", " ")))
                {

                    /*" -472- MOVE 'P0100' TO WS-SECTION */
                    _.Move("P0100", WORK.WS_ERRO.WS_SECTION);

                    /*" -473- MOVE 1 TO WS-IND-ERRO */
                    _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                    /*" -478- STRING WS-SECTION ' - TIPO DE SENSIBILIZACAO PARA ' 'ENVIO INVALIDO.' '<IND-TP-SENSIBILIZA=' LK-PF005-E-IND-TP-SENSIBILIZA '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                    #region STRING
                    var spl14 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                    spl14 += " - TIPO DE SENSIBILIZACAO PARA ";
                    spl14 += "ENVIO INVALIDO.";
                    spl14 += "<IND-TP-SENSIBILIZA=";
                    var spl15 = PF0005W.LK_PF005_E_IND_TP_SENSIBILIZA.GetMoveValues();
                    spl15 += ">";
                    var results16 = spl14 + spl15;
                    _.Move(results16, WORK.WS_ERRO.WS_MENSAGEM);
                    #endregion

                    /*" -481- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                    _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                    /*" -482- MOVE 0 TO WS-SQLCODE */
                    _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                    /*" -483- GO TO P9999-ERRO */

                    P9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -484- END-IF */
                }


                /*" -486- END-IF */
            }


            /*" -487- IF LK-PF005-E-DTA-INI-VIGENCIA = 'SPACES' OR = '0001-01-01' */

            if (PF0005W.LK_PF005_E_DTA_INI_VIGENCIA.In("SPACES", "0001-01-01"))
            {

                /*" -489- MOVE '0001-01-01' TO LK-PF005-E-DTA-INI-VIGENCIA */
                _.Move("0001-01-01", PF0005W.LK_PF005_E_DTA_INI_VIGENCIA);

                /*" -490- ELSE */
            }
            else
            {


                /*" -492- MOVE LK-PF005-E-DTA-INI-VIGENCIA(1:4) TO LK-RSGEWVDT-ANO */
                _.Move(PF0005W.LK_PF005_E_DTA_INI_VIGENCIA.Substring(1, 4), RSGEWVDT.LK_RSGEWVDT_ANO);

                /*" -494- MOVE LK-PF005-E-DTA-INI-VIGENCIA(6:2) TO LK-RSGEWVDT-MES */
                _.Move(PF0005W.LK_PF005_E_DTA_INI_VIGENCIA.Substring(6, 2), RSGEWVDT.LK_RSGEWVDT_MES);

                /*" -496- MOVE LK-PF005-E-DTA-INI-VIGENCIA(9:2) TO LK-RSGEWVDT-DIA */
                _.Move(PF0005W.LK_PF005_E_DTA_INI_VIGENCIA.Substring(9, 2), RSGEWVDT.LK_RSGEWVDT_DIA);

                /*" -497- MOVE ZEROS TO LK-RSGEWVDT-IND-RETORNO */
                _.Move(0, RSGEWVDT.LK_RSGEWVDT_IND_RETORNO);

                /*" -498- MOVE SPACES TO LK-RSGEWVDT-OUT-DATA */
                _.Move("", RSGEWVDT.LK_RSGEWVDT_OUT_DATA);

                /*" -499- MOVE 'RSGESVDT' TO WS-PROGRAMA */
                _.Move("RSGESVDT", WORK.WS_PROGRAMA);

                /*" -504- CALL WS-PROGRAMA USING LK-RSGEWVDT-ANO LK-RSGEWVDT-MES LK-RSGEWVDT-DIA LK-RSGEWVDT-IND-RETORNO LK-RSGEWVDT-OUT-DATA */
                _.Call(WORK.WS_PROGRAMA, RSGEWVDT);

                /*" -505- IF LK-RSGEWVDT-IND-RETORNO NOT = 0 */

                if (RSGEWVDT.LK_RSGEWVDT_IND_RETORNO != 0)
                {

                    /*" -506- MOVE 'P0100' TO WS-SECTION */
                    _.Move("P0100", WORK.WS_ERRO.WS_SECTION);

                    /*" -507- MOVE 1 TO WS-IND-ERRO */
                    _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                    /*" -512- STRING WS-SECTION ' - DATA INICIO DE VIGENCIA INVALIDA.' '<DTA-INI-VIGENCIA=' LK-PF005-E-DTA-INI-VIGENCIA '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                    #region STRING
                    var spl16 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                    spl16 += " - DATA INICIO DE VIGENCIA INVALIDA.";
                    spl16 += "<DTA-INI-VIGENCIA=";
                    var spl17 = PF0005W.LK_PF005_E_DTA_INI_VIGENCIA.GetMoveValues();
                    spl17 += ">";
                    var results18 = spl16 + spl17;
                    _.Move(results18, WORK.WS_ERRO.WS_MENSAGEM);
                    #endregion

                    /*" -515- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                    _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                    /*" -516- MOVE 0 TO WS-SQLCODE */
                    _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                    /*" -517- GO TO P9999-ERRO */

                    P9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -518- END-IF */
                }


                /*" -520- END-IF */
            }


            /*" -521- IF LK-PF005-E-DTA-FIM-VIGENCIA = 'SPACES' OR = '0001-01-01' */

            if (PF0005W.LK_PF005_E_DTA_FIM_VIGENCIA.In("SPACES", "0001-01-01"))
            {

                /*" -523- MOVE '0001-01-01' TO LK-PF005-E-DTA-FIM-VIGENCIA */
                _.Move("0001-01-01", PF0005W.LK_PF005_E_DTA_FIM_VIGENCIA);

                /*" -524- ELSE */
            }
            else
            {


                /*" -526- MOVE LK-PF005-E-DTA-FIM-VIGENCIA(1:4) TO LK-RSGEWVDT-ANO */
                _.Move(PF0005W.LK_PF005_E_DTA_FIM_VIGENCIA.Substring(1, 4), RSGEWVDT.LK_RSGEWVDT_ANO);

                /*" -528- MOVE LK-PF005-E-DTA-FIM-VIGENCIA(6:2) TO LK-RSGEWVDT-MES */
                _.Move(PF0005W.LK_PF005_E_DTA_FIM_VIGENCIA.Substring(6, 2), RSGEWVDT.LK_RSGEWVDT_MES);

                /*" -530- MOVE LK-PF005-E-DTA-FIM-VIGENCIA(9:2) TO LK-RSGEWVDT-DIA */
                _.Move(PF0005W.LK_PF005_E_DTA_FIM_VIGENCIA.Substring(9, 2), RSGEWVDT.LK_RSGEWVDT_DIA);

                /*" -531- MOVE ZEROS TO LK-RSGEWVDT-IND-RETORNO */
                _.Move(0, RSGEWVDT.LK_RSGEWVDT_IND_RETORNO);

                /*" -532- MOVE SPACES TO LK-RSGEWVDT-OUT-DATA */
                _.Move("", RSGEWVDT.LK_RSGEWVDT_OUT_DATA);

                /*" -533- MOVE 'RSGESVDT' TO WS-PROGRAMA */
                _.Move("RSGESVDT", WORK.WS_PROGRAMA);

                /*" -538- CALL WS-PROGRAMA USING LK-RSGEWVDT-ANO LK-RSGEWVDT-MES LK-RSGEWVDT-DIA LK-RSGEWVDT-IND-RETORNO LK-RSGEWVDT-OUT-DATA */
                _.Call(WORK.WS_PROGRAMA, RSGEWVDT);

                /*" -539- IF LK-RSGEWVDT-IND-RETORNO NOT = 0 */

                if (RSGEWVDT.LK_RSGEWVDT_IND_RETORNO != 0)
                {

                    /*" -540- MOVE 'P0100' TO WS-SECTION */
                    _.Move("P0100", WORK.WS_ERRO.WS_SECTION);

                    /*" -541- MOVE 1 TO WS-IND-ERRO */
                    _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                    /*" -545- STRING WS-SECTION ' - DATA FIM DE VIGENCIA INVALIDA.' '<DTA-FIM-VIGENCIA=' LK-PF005-E-DTA-FIM-VIGENCIA '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                    #region STRING
                    var spl18 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                    spl18 += " - DATA FIM DE VIGENCIA INVALIDA.";
                    spl18 += "<DTA-FIM-VIGENCIA=";
                    var spl19 = PF0005W.LK_PF005_E_DTA_FIM_VIGENCIA.GetMoveValues();
                    spl19 += ">";
                    var results20 = spl18 + spl19;
                    _.Move(results20, WORK.WS_ERRO.WS_MENSAGEM);
                    #endregion

                    /*" -548- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                    _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                    /*" -549- MOVE 0 TO WS-SQLCODE */
                    _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                    /*" -550- GO TO P9999-ERRO */

                    P9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -556- END-IF */
                }


                /*" -557- IF LK-PF005-E-IND-TP-ACAO = 'R' */

                if (PF0005W.LK_PF005_E_IND_TP_ACAO == "R")
                {

                    /*" -559- IF NOT ( LK-PF005-E-IND-TP-SENSIBILIZA = 'S' OR = 'P' OR = 'C' ) */

                    if (!(PF0005W.LK_PF005_E_IND_TP_SENSIBILIZA.In("S", "P", "C")))
                    {

                        /*" -560- MOVE 'P0100' TO WS-SECTION */
                        _.Move("P0100", WORK.WS_ERRO.WS_SECTION);

                        /*" -561- MOVE 1 TO WS-IND-ERRO */
                        _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                        /*" -566- STRING WS-SECTION ' - TIPO DE SENSIBILIZACAO PARA ' 'RETORNO INVALIDO.' '<IND-TP-SENSIBILIZA=' LK-PF005-E-IND-TP-SENSIBILIZA '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                        #region STRING
                        var spl20 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                        spl20 += " - TIPO DE SENSIBILIZACAO PARA ";
                        spl20 += "RETORNO INVALIDO.";
                        spl20 += "<IND-TP-SENSIBILIZA=";
                        var spl21 = PF0005W.LK_PF005_E_IND_TP_SENSIBILIZA.GetMoveValues();
                        spl21 += ">";
                        var results22 = spl20 + spl21;
                        _.Move(results22, WORK.WS_ERRO.WS_MENSAGEM);
                        #endregion

                        /*" -569- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                        _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                        /*" -570- MOVE 0 TO WS-SQLCODE */
                        _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                        /*" -571- GO TO P9999-ERRO */

                        P9999_ERRO_SECTION(); //GOTO
                        return;

                        /*" -572- END-IF */
                    }


                    /*" -574- IF ( LK-PF005-E-IND-TP-SENSIBILIZA = 'S' OR = 'P' ) AND LK-PF005-E-COD-ERRO < 001 */

                    if ((PF0005W.LK_PF005_E_IND_TP_SENSIBILIZA.In("S", "P")) && PF0005W.LK_PF005_E_COD_ERRO < 001)
                    {

                        /*" -575- MOVE 'P0100' TO WS-SECTION */
                        _.Move("P0100", WORK.WS_ERRO.WS_SECTION);

                        /*" -576- MOVE 1 TO WS-IND-ERRO */
                        _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                        /*" -578- MOVE LK-PF005-E-COD-USUARIO TO WS-SMALLINT(01) */
                        _.Move(PF0005W.LK_PF005_E_COD_USUARIO, WORK.WS_EDIT.WS_SMALLINT[01]);

                        /*" -581- STRING WS-SECTION ' - INFORME O CODIGO DE ERRO.' '<COD-ERRO=' WS-SMALLINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                        #region STRING
                        var spl22 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                        spl22 += " - INFORME O CODIGO DE ERRO.";
                        spl22 += "<COD-ERRO=";
                        var spl23 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                        spl23 += ">";
                        var results24 = spl22 + spl23;
                        _.Move(results24, WORK.WS_ERRO.WS_MENSAGEM);
                        #endregion

                        /*" -584- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                        _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                        /*" -585- MOVE 0 TO WS-SQLCODE */
                        _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                        /*" -586- GO TO P9999-ERRO */

                        P9999_ERRO_SECTION(); //GOTO
                        return;

                        /*" -587- END-IF */
                    }


                    /*" -588- PERFORM P0111-PESQUISAR-PF-MOTIV-PR */

                    P0111_PESQUISAR_PF_MOTIV_PR_SECTION();

                    /*" -590- END-IF */
                }


                /*" -591- IF LK-PF005-E-DTA-PROCESSA-CEF = 'SPACES' OR = '0001-01-01' */

                if (PF0005W.LK_PF005_E_DTA_PROCESSA_CEF.In("SPACES", "0001-01-01"))
                {

                    /*" -593- MOVE '0001-01-01' TO LK-PF005-E-DTA-PROCESSA-CEF */
                    _.Move("0001-01-01", PF0005W.LK_PF005_E_DTA_PROCESSA_CEF);

                    /*" -594- ELSE */
                }
                else
                {


                    /*" -596- MOVE LK-PF005-E-DTA-PROCESSA-CEF(1:4) TO LK-RSGEWVDT-ANO */
                    _.Move(PF0005W.LK_PF005_E_DTA_PROCESSA_CEF.Substring(1, 4), RSGEWVDT.LK_RSGEWVDT_ANO);

                    /*" -598- MOVE LK-PF005-E-DTA-PROCESSA-CEF(6:2) TO LK-RSGEWVDT-MES */
                    _.Move(PF0005W.LK_PF005_E_DTA_PROCESSA_CEF.Substring(6, 2), RSGEWVDT.LK_RSGEWVDT_MES);

                    /*" -600- MOVE LK-PF005-E-DTA-PROCESSA-CEF(9:2) TO LK-RSGEWVDT-DIA */
                    _.Move(PF0005W.LK_PF005_E_DTA_PROCESSA_CEF.Substring(9, 2), RSGEWVDT.LK_RSGEWVDT_DIA);

                    /*" -601- MOVE ZEROS TO LK-RSGEWVDT-IND-RETORNO */
                    _.Move(0, RSGEWVDT.LK_RSGEWVDT_IND_RETORNO);

                    /*" -602- MOVE SPACES TO LK-RSGEWVDT-OUT-DATA */
                    _.Move("", RSGEWVDT.LK_RSGEWVDT_OUT_DATA);

                    /*" -603- MOVE 'RSGESVDT' TO WS-PROGRAMA */
                    _.Move("RSGESVDT", WORK.WS_PROGRAMA);

                    /*" -608- CALL WS-PROGRAMA USING LK-RSGEWVDT-ANO LK-RSGEWVDT-MES LK-RSGEWVDT-DIA LK-RSGEWVDT-IND-RETORNO LK-RSGEWVDT-OUT-DATA */
                    _.Call(WORK.WS_PROGRAMA, RSGEWVDT);

                    /*" -609- IF LK-RSGEWVDT-IND-RETORNO NOT = 0 */

                    if (RSGEWVDT.LK_RSGEWVDT_IND_RETORNO != 0)
                    {

                        /*" -610- MOVE 'P0100' TO WS-SECTION */
                        _.Move("P0100", WORK.WS_ERRO.WS_SECTION);

                        /*" -611- MOVE 1 TO WS-IND-ERRO */
                        _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                        /*" -615- STRING WS-SECTION ' - DATA DE PROCESSAMENTO CEF INVALI' 'DA. <DTA-FIM-VIGENCIA=' LK-PF005-E-DTA-PROCESSA-CEF '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                        #region STRING
                        var spl24 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                        spl24 += " - DATA DE PROCESSAMENTO CEF INVALI";
                        spl24 += "DA. <DTA-FIM-VIGENCIA=";
                        var spl25 = PF0005W.LK_PF005_E_DTA_PROCESSA_CEF.GetMoveValues();
                        spl25 += ">";
                        var results26 = spl24 + spl25;
                        _.Move(results26, WORK.WS_ERRO.WS_MENSAGEM);
                        #endregion

                        /*" -618- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                        _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                        /*" -619- MOVE 0 TO WS-SQLCODE */
                        _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                        /*" -620- GO TO P9999-ERRO */

                        P9999_ERRO_SECTION(); //GOTO
                        return;

                        /*" -622- END-IF */
                    }


                    /*" -623- IF LK-PF005-E-COD-USUARIO = SPACES */

                    if (PF0005W.LK_PF005_E_COD_USUARIO.IsEmpty())
                    {

                        /*" -624- MOVE 'P0100' TO WS-SECTION */
                        _.Move("P0100", WORK.WS_ERRO.WS_SECTION);

                        /*" -625- MOVE 1 TO WS-IND-ERRO */
                        _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                        /*" -628- STRING WS-SECTION ' - INFORME O CODIGO DO USUARIO.' '<COD-USUARIO=' LK-PF005-E-COD-USUARIO '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                        #region STRING
                        var spl26 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                        spl26 += " - INFORME O CODIGO DO USUARIO.";
                        spl26 += "<COD-USUARIO=";
                        var spl27 = PF0005W.LK_PF005_E_COD_USUARIO.GetMoveValues();
                        spl27 += ">";
                        var results28 = spl26 + spl27;
                        _.Move(results28, WORK.WS_ERRO.WS_MENSAGEM);
                        #endregion

                        /*" -631- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                        _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                        /*" -632- MOVE 0 TO WS-SQLCODE */
                        _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                        /*" -633- GO TO P9999-ERRO */

                        P9999_ERRO_SECTION(); //GOTO
                        return;

                        /*" -635- END-IF */
                    }


                    /*" -636- IF LK-PF005-E-NOM-PROGRAMA = SPACES */

                    if (PF0005W.LK_PF005_E_NOM_PROGRAMA.IsEmpty())
                    {

                        /*" -637- MOVE 'P0100' TO WS-SECTION */
                        _.Move("P0100", WORK.WS_ERRO.WS_SECTION);

                        /*" -638- MOVE 1 TO WS-IND-ERRO */
                        _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                        /*" -641- STRING WS-SECTION ' - INFORME O NOME DO PROGRAMA.' '<NOM-PROGRAMA=' LK-PF005-E-NOM-PROGRAMA '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                        #region STRING
                        var spl28 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                        spl28 += " - INFORME O NOME DO PROGRAMA.";
                        spl28 += "<NOM-PROGRAMA=";
                        var spl29 = PF0005W.LK_PF005_E_NOM_PROGRAMA.GetMoveValues();
                        spl29 += ">";
                        var results30 = spl28 + spl29;
                        _.Move(results30, WORK.WS_ERRO.WS_MENSAGEM);
                        #endregion

                        /*" -644- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                        _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                        /*" -645- MOVE 0 TO WS-SQLCODE */
                        _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                        /*" -646- GO TO P9999-ERRO */

                        P9999_ERRO_SECTION(); //GOTO
                        return;

                        /*" -646- END-IF. */
                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0100_99_EXIT*/

        [StopWatch]
        /*" P0110-PESQUISAR-PROP-FIDELIZ-SECTION */
        private void P0110_PESQUISAR_PROP_FIDELIZ_SECTION()
        {
            /*" -660- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0110_00_START */

            P0110_00_START();

        }

        [StopWatch]
        /*" P0110-00-START */
        private void P0110_00_START(bool isPerform = false)
        {
            /*" -663- MOVE 'P0110' TO WS-SECTION */
            _.Move("P0110", WORK.WS_ERRO.WS_SECTION);

            /*" -666- MOVE LK-PF005-E-NUM-IDENTIFICACAO TO NUM-IDENTIFICACAO WS-BIGINT(01). */
            _.Move(PF0005W.LK_PF005_E_NUM_IDENTIFICACAO, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_IDENTIFICACAO, WORK.WS_EDIT.WS_BIGINT[01]);

            /*" -666- PERFORM P0110-05-INICIO. */

            P0110_05_INICIO(true);

        }

        [StopWatch]
        /*" P0110-05-INICIO */
        private void P0110_05_INICIO(bool isPerform = false)
        {
            /*" -680- PERFORM P0110_05_INICIO_DB_SELECT_1 */

            P0110_05_INICIO_DB_SELECT_1();

            /*" -683- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -684- MOVE 'P0110' TO WS-SECTION */
                _.Move("P0110", WORK.WS_ERRO.WS_SECTION);

                /*" -685- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -689- STRING WS-SECTION ' - ERRO NO SELECT NA SEGUROS.PROPOSTA_' 'FIDELIZ. ' '<NUM-IDENTIFICACAO=' WS-BIGINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl30 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl30 += " - ERRO NO SELECT NA SEGUROS.PROPOSTA_";
                spl30 += "FIDELIZ. ";
                spl30 += "<NUM-IDENTIFICACAO=";
                var spl31 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                spl31 += ">";
                var results32 = spl30 + spl31;
                _.Move(results32, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -691- MOVE 'SEGUROS.PROPOSTA_FIDELIZ' TO WS-TABELA */
                _.Move("SEGUROS.PROPOSTA_FIDELIZ", WORK.WS_ERRO.WS_TABELA);

                /*" -692- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -693- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -694- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -695- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -697- END-IF */
            }


            /*" -698- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -699- MOVE 'P0110' TO WS-SECTION */
                _.Move("P0110", WORK.WS_ERRO.WS_SECTION);

                /*" -700- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -704- STRING WS-SECTION ' - NAO ECONTRADO IDENTIFICACAO DA PROPOSTA.' '<NUM-IDENTIFICACAO=' WS-BIGINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl32 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl32 += " - NAO ECONTRADO IDENTIFICACAO DA PROPOSTA.";
                spl32 += "<NUM-IDENTIFICACAO=";
                var spl33 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                spl33 += ">";
                var results34 = spl32 + spl33;
                _.Move(results34, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -706- MOVE 'SEGUROS.PROPOSTA_FIDELIZ' TO WS-TABELA */
                _.Move("SEGUROS.PROPOSTA_FIDELIZ", WORK.WS_ERRO.WS_TABELA);

                /*" -707- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -708- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -709- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -710- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -710- END-IF */
            }


        }

        [StopWatch]
        /*" P0110-05-INICIO-DB-SELECT-1 */
        public void P0110_05_INICIO_DB_SELECT_1()
        {
            /*" -680- EXEC SQL SELECT SITUACAO_ENVIO ,COD_EMPRESA_SIVPF ,COD_PRODUTO_SIVPF INTO :SITUACAO-ENVIO ,:COD-EMPRESA-SIVPF ,:COD-PRODUTO-SIVPF FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_IDENTIFICACAO = :NUM-IDENTIFICACAO WITH UR END-EXEC. */

            var p0110_05_INICIO_DB_SELECT_1_Query1 = new P0110_05_INICIO_DB_SELECT_1_Query1()
            {
                NUM_IDENTIFICACAO = PROPFID.DCLPROPOSTA_FIDELIZ.NUM_IDENTIFICACAO.ToString(),
            };

            var executed_1 = P0110_05_INICIO_DB_SELECT_1_Query1.Execute(p0110_05_INICIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SITUACAO_ENVIO, PROPFID.DCLPROPOSTA_FIDELIZ.SITUACAO_ENVIO);
                _.Move(executed_1.COD_EMPRESA_SIVPF, PROPFID.DCLPROPOSTA_FIDELIZ.COD_EMPRESA_SIVPF);
                _.Move(executed_1.COD_PRODUTO_SIVPF, PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0110_99_EXIT*/

        [StopWatch]
        /*" P0111-PESQUISAR-PF-MOTIV-PR-SECTION */
        private void P0111_PESQUISAR_PF_MOTIV_PR_SECTION()
        {
            /*" -724- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0111_00_START */

            P0111_00_START();

        }

        [StopWatch]
        /*" P0111-00-START */
        private void P0111_00_START(bool isPerform = false)
        {
            /*" -727- MOVE 'P0111' TO WS-SECTION */
            _.Move("P0111", WORK.WS_ERRO.WS_SECTION);

            /*" -730- MOVE LK-PF005-E-COD-ERRO TO PFMOTPRO-SIT-MOTIVO-SIVPF WS-SMALLINT(01) */
            _.Move(PF0005W.LK_PF005_E_COD_ERRO, PFMOTPRO.DCLPF_MOTIVO_PROPOSTA.PFMOTPRO_SIT_MOTIVO_SIVPF, WORK.WS_EDIT.WS_SMALLINT[01]);

            /*" -730- PERFORM P0111-05-INICIO. */

            P0111_05_INICIO(true);

        }

        [StopWatch]
        /*" P0111-05-INICIO */
        private void P0111_05_INICIO(bool isPerform = false)
        {
            /*" -740- PERFORM P0111_05_INICIO_DB_SELECT_1 */

            P0111_05_INICIO_DB_SELECT_1();

            /*" -743- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -744- MOVE 'P0111' TO WS-SECTION */
                _.Move("P0111", WORK.WS_ERRO.WS_SECTION);

                /*" -745- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -749- STRING WS-SECTION ' - ERRO NO SELECT NA SEGUROS.PF_MOTIVO' '_PROPOSTA.' '<SIT-MOTIVO-SIVPF=' WS-SMALLINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl34 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl34 += " - ERRO NO SELECT NA SEGUROS.PF_MOTIVO";
                spl34 += "_PROPOSTA.";
                spl34 += "<SIT-MOTIVO-SIVPF=";
                var spl35 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl35 += ">";
                var results36 = spl34 + spl35;
                _.Move(results36, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -751- MOVE 'SEGUROS.PF_MOTIVO_PROPOSTA' TO WS-TABELA */
                _.Move("SEGUROS.PF_MOTIVO_PROPOSTA", WORK.WS_ERRO.WS_TABELA);

                /*" -752- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -753- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -754- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -755- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -757- END-IF */
            }


            /*" -758- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -759- MOVE 'P0111' TO WS-SECTION */
                _.Move("P0111", WORK.WS_ERRO.WS_SECTION);

                /*" -760- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -764- STRING WS-SECTION ' - NAO ECONTRADO MOTIVO DE ERRO INFORMADO.' '<SIT-MOTIVO-SIVPF=' WS-SMALLINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl36 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl36 += " - NAO ECONTRADO MOTIVO DE ERRO INFORMADO.";
                spl36 += "<SIT-MOTIVO-SIVPF=";
                var spl37 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl37 += ">";
                var results38 = spl36 + spl37;
                _.Move(results38, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -766- MOVE 'SEGUROS.PF_MOTIVO_PROPOSTA' TO WS-TABELA */
                _.Move("SEGUROS.PF_MOTIVO_PROPOSTA", WORK.WS_ERRO.WS_TABELA);

                /*" -767- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -768- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -769- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -770- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -770- END-IF */
            }


        }

        [StopWatch]
        /*" P0111-05-INICIO-DB-SELECT-1 */
        public void P0111_05_INICIO_DB_SELECT_1()
        {
            /*" -740- EXEC SQL SELECT SIT_MOTIVO_SIVPF INTO :PFMOTPRO-SIT-MOTIVO-SIVPF FROM SEGUROS.PF_MOTIVO_PROPOSTA WHERE SIT_MOTIVO_SIVPF = :PFMOTPRO-SIT-MOTIVO-SIVPF WITH UR END-EXEC. */

            var p0111_05_INICIO_DB_SELECT_1_Query1 = new P0111_05_INICIO_DB_SELECT_1_Query1()
            {
                PFMOTPRO_SIT_MOTIVO_SIVPF = PFMOTPRO.DCLPF_MOTIVO_PROPOSTA.PFMOTPRO_SIT_MOTIVO_SIVPF.ToString(),
            };

            var executed_1 = P0111_05_INICIO_DB_SELECT_1_Query1.Execute(p0111_05_INICIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PFMOTPRO_SIT_MOTIVO_SIVPF, PFMOTPRO.DCLPF_MOTIVO_PROPOSTA.PFMOTPRO_SIT_MOTIVO_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0111_99_EXIT*/

        [StopWatch]
        /*" P0301-TRATAR-TIPO-ACAO-01-SECTION */
        private void P0301_TRATAR_TIPO_ACAO_01_SECTION()
        {
            /*" -784- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0301_00_START */

            P0301_00_START();

        }

        [StopWatch]
        /*" P0301-00-START */
        private void P0301_00_START(bool isPerform = false)
        {
            /*" -788- MOVE 'P0301' TO WS-SECTION */
            _.Move("P0301", WORK.WS_ERRO.WS_SECTION);

            /*" -788- PERFORM P0301-05-INICIO. */

            P0301_05_INICIO(true);

        }

        [StopWatch]
        /*" P0301-05-INICIO */
        private void P0301_05_INICIO(bool isPerform = false)
        {
            /*" -795- IF LK-PF005-E-NSAS-SIVPF = 0 OR ( LK-PF005-E-IND-TP-ACAO = 'R' AND ( LK-PF005-E-IND-TP-SENSIBILIZA = 'S' OR = 'P' ) ) */

            if (PF0005W.LK_PF005_E_NSAS_SIVPF == 0 || (PF0005W.LK_PF005_E_IND_TP_ACAO == "R" && (PF0005W.LK_PF005_E_IND_TP_SENSIBILIZA.In("S", "P"))))
            {

                /*" -796- PERFORM P0401-GERAR-SEQ-HISPROFI */

                P0401_GERAR_SEQ_HISPROFI_SECTION();

                /*" -798- END-IF */
            }


            /*" -798- PERFORM P8000-INSERT-HISPROFI */

            P8000_INSERT_HISPROFI_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0301_99_EXIT*/

        [StopWatch]
        /*" P0401-GERAR-SEQ-HISPROFI-SECTION */
        private void P0401_GERAR_SEQ_HISPROFI_SECTION()
        {
            /*" -812- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0401_00_START */

            P0401_00_START();

        }

        [StopWatch]
        /*" P0401-00-START */
        private void P0401_00_START(bool isPerform = false)
        {
            /*" -815- MOVE 'P0401' TO WS-SECTION */
            _.Move("P0401", WORK.WS_ERRO.WS_SECTION);

            /*" -817- MOVE LK-PF005-E-NUM-IDENTIFICACAO TO HISPROFI-NUM-IDENTIFICACAO WS-BIGINT(01) */
            _.Move(PF0005W.LK_PF005_E_NUM_IDENTIFICACAO, HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_NUM_IDENTIFICACAO, WORK.WS_EDIT.WS_BIGINT[01]);

            /*" -818- MOVE LK-PF005-E-DATA-SITUACAO TO HISPROFI-DATA-SITUACAO */
            _.Move(PF0005W.LK_PF005_E_DATA_SITUACAO, HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_DATA_SITUACAO);

            /*" -820- MOVE LK-PF005-E-NSAS-SIVPF TO HISPROFI-NSAS-SIVPF WS-INTEGER(01) */
            _.Move(PF0005W.LK_PF005_E_NSAS_SIVPF, HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_NSAS_SIVPF, WORK.WS_EDIT.WS_INTEGER[01]);

            /*" -822- MOVE LK-PF005-E-SIT-PROPOSTA TO HISPROFI-SIT-PROPOSTA */
            _.Move(PF0005W.LK_PF005_E_SIT_PROPOSTA, HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_SIT_PROPOSTA);

            /*" -822- PERFORM P0401-05-INICIO. */

            P0401_05_INICIO(true);

        }

        [StopWatch]
        /*" P0401-05-INICIO */
        private void P0401_05_INICIO(bool isPerform = false)
        {
            /*" -836- PERFORM P0401_05_INICIO_DB_SELECT_1 */

            P0401_05_INICIO_DB_SELECT_1();

            /*" -839- IF NOT ( SQLCODE = 000 OR = 100 ) */

            if (!(DB.SQLCODE.In("000", "100")))
            {

                /*" -840- MOVE 'P0401' TO WS-SECTION */
                _.Move("P0401", WORK.WS_ERRO.WS_SECTION);

                /*" -841- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -848- STRING WS-SECTION ' - ERRO NO SELECT NA SEGUROS.HIST_PROP' '_FIDELIZ.' '<NUM-IDENTIFICACAO=' WS-BIGINT(01) '>' '<DATA-SITUACAO=' HISPROFI-DATA-SITUACAO '>' '<NSAS-SIVPF=' WS-INTEGER(01) '>' '<SIT-PROPOSTA=' HISPROFI-SIT-PROPOSTA '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl38 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl38 += " - ERRO NO SELECT NA SEGUROS.HIST_PROP";
                spl38 += "_FIDELIZ.";
                spl38 += "<NUM-IDENTIFICACAO=";
                var spl39 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                spl39 += ">";
                spl39 += "<DATA-SITUACAO=";
                var spl40 = HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_DATA_SITUACAO.GetMoveValues();
                spl40 += ">";
                spl40 += "<NSAS-SIVPF=";
                var spl41 = WORK.WS_EDIT.WS_INTEGER[01].GetMoveValues();
                spl41 += ">";
                spl41 += "<SIT-PROPOSTA=";
                var spl42 = HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_SIT_PROPOSTA.GetMoveValues();
                spl42 += ">";
                var results43 = spl38 + spl39 + spl40 + spl41 + spl42;
                _.Move(results43, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -850- MOVE 'SEGUROS.HIST_PROP_FIDELIZ' TO WS-TABELA */
                _.Move("SEGUROS.HIST_PROP_FIDELIZ", WORK.WS_ERRO.WS_TABELA);

                /*" -851- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -852- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -853- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -854- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -856- END-IF */
            }


            /*" -857- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -858- MOVE 1 TO HISPROFI-NSL */
                _.Move(1, HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_NSL);

                /*" -860- END-IF */
            }


            /*" -860- MOVE HISPROFI-NSL TO LK-PF005-E-NSL */
            _.Move(HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_NSL, PF0005W.LK_PF005_E_NSL);

        }

        [StopWatch]
        /*" P0401-05-INICIO-DB-SELECT-1 */
        public void P0401_05_INICIO_DB_SELECT_1()
        {
            /*" -836- EXEC SQL SELECT VALUE(MAX(NSL),0) + 1 INTO :HISPROFI-NSL FROM SEGUROS.HIST_PROP_FIDELIZ WHERE NUM_IDENTIFICACAO = :HISPROFI-NUM-IDENTIFICACAO AND DATA_SITUACAO = :HISPROFI-DATA-SITUACAO AND NSAS_SIVPF = :HISPROFI-NSAS-SIVPF AND SIT_PROPOSTA = :HISPROFI-SIT-PROPOSTA WITH UR END-EXEC. */

            var p0401_05_INICIO_DB_SELECT_1_Query1 = new P0401_05_INICIO_DB_SELECT_1_Query1()
            {
                HISPROFI_NUM_IDENTIFICACAO = HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_NUM_IDENTIFICACAO.ToString(),
                HISPROFI_DATA_SITUACAO = HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_DATA_SITUACAO.ToString(),
                HISPROFI_SIT_PROPOSTA = HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_SIT_PROPOSTA.ToString(),
                HISPROFI_NSAS_SIVPF = HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_NSAS_SIVPF.ToString(),
            };

            var executed_1 = P0401_05_INICIO_DB_SELECT_1_Query1.Execute(p0401_05_INICIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISPROFI_NSL, HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_NSL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0401_99_EXIT*/

        [StopWatch]
        /*" P8000-INSERT-HISPROFI-SECTION */
        private void P8000_INSERT_HISPROFI_SECTION()
        {
            /*" -874- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P8000_00_START */

            P8000_00_START();

        }

        [StopWatch]
        /*" P8000-00-START */
        private void P8000_00_START(bool isPerform = false)
        {
            /*" -878- MOVE 'P8000' TO WS-SECTION */
            _.Move("P8000", WORK.WS_ERRO.WS_SECTION);

            /*" -880- INITIALIZE DCLHIST-PROP-FIDELIZ */
            _.Initialize(
                HISPROFI.DCLHIST_PROP_FIDELIZ
            );

            /*" -880- PERFORM P8000-05-INICIO. */

            P8000_05_INICIO(true);

        }

        [StopWatch]
        /*" P8000-05-INICIO */
        private void P8000_05_INICIO(bool isPerform = false)
        {
            /*" -886- MOVE LK-PF005-E-NUM-IDENTIFICACAO TO HISPROFI-NUM-IDENTIFICACAO */
            _.Move(PF0005W.LK_PF005_E_NUM_IDENTIFICACAO, HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_NUM_IDENTIFICACAO);

            /*" -887- MOVE LK-PF005-E-DATA-SITUACAO TO HISPROFI-DATA-SITUACAO */
            _.Move(PF0005W.LK_PF005_E_DATA_SITUACAO, HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_DATA_SITUACAO);

            /*" -888- MOVE LK-PF005-E-NSAS-SIVPF TO HISPROFI-NSAS-SIVPF */
            _.Move(PF0005W.LK_PF005_E_NSAS_SIVPF, HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_NSAS_SIVPF);

            /*" -889- MOVE LK-PF005-E-NSL TO HISPROFI-NSL */
            _.Move(PF0005W.LK_PF005_E_NSL, HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_NSL);

            /*" -890- MOVE LK-PF005-E-SIT-PROPOSTA TO HISPROFI-SIT-PROPOSTA */
            _.Move(PF0005W.LK_PF005_E_SIT_PROPOSTA, HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_SIT_PROPOSTA);

            /*" -892- MOVE LK-PF005-E-SIT-COBRANCA-SIVPF TO HISPROFI-SIT-COBRANCA-SIVPF */
            _.Move(PF0005W.LK_PF005_E_SIT_COBRANCA_SIVPF, HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_SIT_COBRANCA_SIVPF);

            /*" -894- MOVE LK-PF005-E-SIT-MOTIVO-SIVPF TO HISPROFI-SIT-MOTIVO-SIVPF */
            _.Move(PF0005W.LK_PF005_E_SIT_MOTIVO_SIVPF, HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_SIT_MOTIVO_SIVPF);

            /*" -897- MOVE COD-EMPRESA-SIVPF TO HISPROFI-COD-EMPRESA-SIVPF LK-PF005-E-COD-EMPRESA-SIVPF */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.COD_EMPRESA_SIVPF, HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_COD_EMPRESA_SIVPF, PF0005W.LK_PF005_E_COD_EMPRESA_SIVPF);

            /*" -900- MOVE COD-PRODUTO-SIVPF TO HISPROFI-COD-PRODUTO-SIVPF LK-PF005-E-COD-PRODUTO-SIVPF */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF, HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_COD_PRODUTO_SIVPF, PF0005W.LK_PF005_E_COD_PRODUTO_SIVPF);

            /*" -901- MOVE LK-PF005-E-IND-TP-ACAO TO HISPROFI-IND-TP-ACAO */
            _.Move(PF0005W.LK_PF005_E_IND_TP_ACAO, HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_IND_TP_ACAO);

            /*" -903- MOVE LK-PF005-E-IND-TP-SENSIBILIZA TO HISPROFI-IND-TP-SENSIBILIZACAO */
            _.Move(PF0005W.LK_PF005_E_IND_TP_SENSIBILIZA, HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_IND_TP_SENSIBILIZACAO);

            /*" -904- MOVE SITUACAO-ENVIO TO HISPROFI-IND-ENVIO */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.SITUACAO_ENVIO, HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_IND_ENVIO);

            /*" -906- MOVE LK-PF005-E-DTA-INI-VIGENCIA TO HISPROFI-DTA-INI-VIGENCIA */
            _.Move(PF0005W.LK_PF005_E_DTA_INI_VIGENCIA, HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_DTA_INI_VIGENCIA);

            /*" -908- MOVE LK-PF005-E-DTA-FIM-VIGENCIA TO HISPROFI-DTA-FIM-VIGENCIA */
            _.Move(PF0005W.LK_PF005_E_DTA_FIM_VIGENCIA, HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_DTA_FIM_VIGENCIA);

            /*" -909- MOVE LK-PF005-E-NUM-PARCELA TO HISPROFI-NUM-PARCELA */
            _.Move(PF0005W.LK_PF005_E_NUM_PARCELA, HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_NUM_PARCELA);

            /*" -911- MOVE LK-PF005-E-COD-TP-LANCAMENTO TO HISPROFI-COD-TP-LANCAMENTO */
            _.Move(PF0005W.LK_PF005_E_COD_TP_LANCAMENTO, HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_COD_TP_LANCAMENTO);

            /*" -912- MOVE LK-PF005-E-VLR-PREMIO TO HISPROFI-VLR-PREMIO */
            _.Move(PF0005W.LK_PF005_E_VLR_PREMIO, HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_VLR_PREMIO);

            /*" -913- MOVE LK-PF005-E-COD-ERRO TO HISPROFI-COD-ERRO */
            _.Move(PF0005W.LK_PF005_E_COD_ERRO, HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_COD_ERRO);

            /*" -915- MOVE LK-PF005-E-DTA-PROCESSA-CEF TO HISPROFI-DTA-PROCESSAMENTO-CEF */
            _.Move(PF0005W.LK_PF005_E_DTA_PROCESSA_CEF, HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_DTA_PROCESSAMENTO_CEF);

            /*" -916- MOVE LK-PF005-E-COD-USUARIO TO HISPROFI-COD-USUARIO */
            _.Move(PF0005W.LK_PF005_E_COD_USUARIO, HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_COD_USUARIO);

            /*" -918- MOVE LK-PF005-E-NOM-PROGRAMA TO HISPROFI-NOM-PROGRAMA */
            _.Move(PF0005W.LK_PF005_E_NOM_PROGRAMA, HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_NOM_PROGRAMA);

            /*" -920- PERFORM P9000-NULL-HISPROFI */

            P9000_NULL_HISPROFI_SECTION();

            /*" -969- PERFORM P8000_05_INICIO_DB_INSERT_1 */

            P8000_05_INICIO_DB_INSERT_1();

            /*" -972- IF NOT ( SQLCODE = 0 ) */

            if (!(DB.SQLCODE == 0))
            {

                /*" -973- MOVE 'P8000' TO WS-SECTION */
                _.Move("P8000", WORK.WS_ERRO.WS_SECTION);

                /*" -974- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -977- STRING WS-SECTION ' - ERRO NO INSERT NA SEGUROS.HIST_PROP' '_FIDELIZ. ' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl43 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl43 += " - ERRO NO INSERT NA SEGUROS.HIST_PROP";
                spl43 += "_FIDELIZ. ";
                _.Move(spl43, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -979- MOVE 'SEGUROS.HIST_PROP_FIDELIZ' TO WS-TABELA */
                _.Move("SEGUROS.HIST_PROP_FIDELIZ", WORK.WS_ERRO.WS_TABELA);

                /*" -980- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -981- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -982- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -983- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -983- END-IF */
            }


        }

        [StopWatch]
        /*" P8000-05-INICIO-DB-INSERT-1 */
        public void P8000_05_INICIO_DB_INSERT_1()
        {
            /*" -969- EXEC SQL INSERT INTO SEGUROS.HIST_PROP_FIDELIZ ( NUM_IDENTIFICACAO ,DATA_SITUACAO ,NSAS_SIVPF ,NSL ,SIT_PROPOSTA ,SIT_COBRANCA_SIVPF ,SIT_MOTIVO_SIVPF ,COD_EMPRESA_SIVPF ,COD_PRODUTO_SIVPF ,IND_TP_ACAO ,IND_TP_SENSIBILIZACAO ,IND_ENVIO ,DTA_INI_VIGENCIA ,DTA_FIM_VIGENCIA ,NUM_PARCELA ,COD_TP_LANCAMENTO ,VLR_PREMIO ,COD_ERRO ,COD_USUARIO ,NOM_PROGRAMA ,DTH_CADASTRAMENTO ,DTA_PROCESSAMENTO_CEF ) VALUES ( :HISPROFI-NUM-IDENTIFICACAO ,:HISPROFI-DATA-SITUACAO ,:HISPROFI-NSAS-SIVPF ,:HISPROFI-NSL ,:HISPROFI-SIT-PROPOSTA ,:HISPROFI-SIT-COBRANCA-SIVPF :NU006-SIT-COBRANCA-SIVPF ,:HISPROFI-SIT-MOTIVO-SIVPF ,:HISPROFI-COD-EMPRESA-SIVPF ,:HISPROFI-COD-PRODUTO-SIVPF ,:HISPROFI-IND-TP-ACAO ,:HISPROFI-IND-TP-SENSIBILIZACAO ,:HISPROFI-IND-ENVIO ,:HISPROFI-DTA-INI-VIGENCIA:NU006-DTA-INI-VIGENCIA ,:HISPROFI-DTA-FIM-VIGENCIA:NU006-DTA-FIM-VIGENCIA ,:HISPROFI-NUM-PARCELA:NU006-NUM-PARCELA ,:HISPROFI-COD-TP-LANCAMENTO:NU006-COD-TP-LANCAMENTO ,:HISPROFI-VLR-PREMIO:NU006-VLR-PREMIO ,:HISPROFI-COD-ERRO:NU006-COD-ERRO ,:HISPROFI-COD-USUARIO ,:HISPROFI-NOM-PROGRAMA ,CURRENT_TIMESTAMP ,:HISPROFI-DTA-PROCESSAMENTO-CEF :NU006-DTA-PROCESSAMENTO-CEF ) END-EXEC. */

            var p8000_05_INICIO_DB_INSERT_1_Insert1 = new P8000_05_INICIO_DB_INSERT_1_Insert1()
            {
                HISPROFI_NUM_IDENTIFICACAO = HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_NUM_IDENTIFICACAO.ToString(),
                HISPROFI_DATA_SITUACAO = HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_DATA_SITUACAO.ToString(),
                HISPROFI_NSAS_SIVPF = HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_NSAS_SIVPF.ToString(),
                HISPROFI_NSL = HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_NSL.ToString(),
                HISPROFI_SIT_PROPOSTA = HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_SIT_PROPOSTA.ToString(),
                HISPROFI_SIT_COBRANCA_SIVPF = HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_SIT_COBRANCA_SIVPF.ToString(),
                NU006_SIT_COBRANCA_SIVPF = NU006_SIT_COBRANCA_SIVPF.ToString(),
                HISPROFI_SIT_MOTIVO_SIVPF = HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_SIT_MOTIVO_SIVPF.ToString(),
                HISPROFI_COD_EMPRESA_SIVPF = HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_COD_EMPRESA_SIVPF.ToString(),
                HISPROFI_COD_PRODUTO_SIVPF = HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_COD_PRODUTO_SIVPF.ToString(),
                HISPROFI_IND_TP_ACAO = HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_IND_TP_ACAO.ToString(),
                HISPROFI_IND_TP_SENSIBILIZACAO = HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_IND_TP_SENSIBILIZACAO.ToString(),
                HISPROFI_IND_ENVIO = HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_IND_ENVIO.ToString(),
                HISPROFI_DTA_INI_VIGENCIA = HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_DTA_INI_VIGENCIA.ToString(),
                NU006_DTA_INI_VIGENCIA = NU006_DTA_INI_VIGENCIA.ToString(),
                HISPROFI_DTA_FIM_VIGENCIA = HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_DTA_FIM_VIGENCIA.ToString(),
                NU006_DTA_FIM_VIGENCIA = NU006_DTA_FIM_VIGENCIA.ToString(),
                HISPROFI_NUM_PARCELA = HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_NUM_PARCELA.ToString(),
                NU006_NUM_PARCELA = NU006_NUM_PARCELA.ToString(),
                HISPROFI_COD_TP_LANCAMENTO = HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_COD_TP_LANCAMENTO.ToString(),
                NU006_COD_TP_LANCAMENTO = NU006_COD_TP_LANCAMENTO.ToString(),
                HISPROFI_VLR_PREMIO = HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_VLR_PREMIO.ToString(),
                NU006_VLR_PREMIO = NU006_VLR_PREMIO.ToString(),
                HISPROFI_COD_ERRO = HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_COD_ERRO.ToString(),
                NU006_COD_ERRO = NU006_COD_ERRO.ToString(),
                HISPROFI_COD_USUARIO = HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_COD_USUARIO.ToString(),
                HISPROFI_NOM_PROGRAMA = HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_NOM_PROGRAMA.ToString(),
                HISPROFI_DTA_PROCESSAMENTO_CEF = HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_DTA_PROCESSAMENTO_CEF.ToString(),
                NU006_DTA_PROCESSAMENTO_CEF = NU006_DTA_PROCESSAMENTO_CEF.ToString(),
            };

            P8000_05_INICIO_DB_INSERT_1_Insert1.Execute(p8000_05_INICIO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P8000_99_EXIT*/

        [StopWatch]
        /*" P9000-NULL-HISPROFI-SECTION */
        private void P9000_NULL_HISPROFI_SECTION()
        {
            /*" -997- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P9000_00_START */

            P9000_00_START();

        }

        [StopWatch]
        /*" P9000-00-START */
        private void P9000_00_START(bool isPerform = false)
        {
            /*" -1000- MOVE 'P9000' TO WS-SECTION */
            _.Move("P9000", WORK.WS_ERRO.WS_SECTION);

            /*" -1006- MOVE 0 TO NU006-SIT-COBRANCA-SIVPF NU006-DTA-INI-VIGENCIA NU006-DTA-FIM-VIGENCIA NU006-NUM-PARCELA NU006-COD-TP-LANCAMENTO NU006-VLR-PREMIO NU006-COD-ERRO NU006-DTA-PROCESSAMENTO-CEF. */
            _.Move(0, NU006_SIT_COBRANCA_SIVPF, NU006_DTA_INI_VIGENCIA, NU006_DTA_FIM_VIGENCIA, NU006_NUM_PARCELA, NU006_COD_TP_LANCAMENTO, NU006_VLR_PREMIO, NU006_COD_ERRO, NU006_DTA_PROCESSAMENTO_CEF);

            /*" -1006- PERFORM P9000-05-INICIO. */

            P9000_05_INICIO(true);

        }

        [StopWatch]
        /*" P9000-05-INICIO */
        private void P9000_05_INICIO(bool isPerform = false)
        {
            /*" -1011- IF HISPROFI-SIT-COBRANCA-SIVPF = 0 */

            if (HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_SIT_COBRANCA_SIVPF == 0)
            {

                /*" -1012- MOVE -1 TO NU006-SIT-COBRANCA-SIVPF */
                _.Move(-1, NU006_SIT_COBRANCA_SIVPF);

                /*" -1014- END-IF. */
            }


            /*" -1015- IF HISPROFI-DTA-INI-VIGENCIA = '0001-01-01' */

            if (HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_DTA_INI_VIGENCIA == "0001-01-01")
            {

                /*" -1016- MOVE -1 TO NU006-DTA-INI-VIGENCIA */
                _.Move(-1, NU006_DTA_INI_VIGENCIA);

                /*" -1018- END-IF. */
            }


            /*" -1019- IF HISPROFI-DTA-FIM-VIGENCIA = '0001-01-01' */

            if (HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_DTA_FIM_VIGENCIA == "0001-01-01")
            {

                /*" -1020- MOVE -1 TO NU006-DTA-FIM-VIGENCIA */
                _.Move(-1, NU006_DTA_FIM_VIGENCIA);

                /*" -1022- END-IF. */
            }


            /*" -1023- IF HISPROFI-NUM-PARCELA = 0 */

            if (HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_NUM_PARCELA == 0)
            {

                /*" -1024- MOVE -1 TO NU006-NUM-PARCELA */
                _.Move(-1, NU006_NUM_PARCELA);

                /*" -1026- END-IF. */
            }


            /*" -1027- IF HISPROFI-COD-TP-LANCAMENTO = 0 */

            if (HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_COD_TP_LANCAMENTO == 0)
            {

                /*" -1028- MOVE -1 TO NU006-COD-TP-LANCAMENTO */
                _.Move(-1, NU006_COD_TP_LANCAMENTO);

                /*" -1030- END-IF. */
            }


            /*" -1031- IF HISPROFI-VLR-PREMIO = 0 */

            if (HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_VLR_PREMIO == 0)
            {

                /*" -1032- MOVE -1 TO NU006-VLR-PREMIO */
                _.Move(-1, NU006_VLR_PREMIO);

                /*" -1034- END-IF. */
            }


            /*" -1035- IF HISPROFI-COD-ERRO = 0 */

            if (HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_COD_ERRO == 0)
            {

                /*" -1036- MOVE -1 TO NU006-COD-ERRO */
                _.Move(-1, NU006_COD_ERRO);

                /*" -1038- END-IF. */
            }


            /*" -1039- IF HISPROFI-DTA-PROCESSAMENTO-CEF = SPACES OR = '0001-01-01' */

            if (HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_DTA_PROCESSAMENTO_CEF.In(string.Empty, "0001-01-01"))
            {

                /*" -1041- MOVE -1 TO NU006-DTA-PROCESSAMENTO-CEF */
                _.Move(-1, NU006_DTA_PROCESSAMENTO_CEF);

                /*" -1041- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P9000_99_EXIT*/

        [StopWatch]
        /*" P9999-ERRO-SECTION */
        private void P9999_ERRO_SECTION()
        {
            /*" -1055- DISPLAY '**********************************************' */
            _.Display($"**********************************************");

            /*" -1056- DISPLAY '*              P F 0 0 0 5 S                 *' */
            _.Display($"*              P F 0 0 0 5 S                 *");

            /*" -1057- DISPLAY '**********************************************' */
            _.Display($"**********************************************");

            /*" -1064- DISPLAY '* DATA COMPILACAO..: ' WS-C-DATE-COMPILED(7:2) '/' WS-C-DATE-COMPILED(5:2) '/' WS-C-DATE-COMPILED(1:4) '-' WS-C-DATE-COMPILED(9:2) ':' WS-C-DATE-COMPILED(11:2) ':' WS-C-DATE-COMPILED(13:2) */

            $"* DATA COMPILACAO..: {WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(7, 2)}/{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(5, 2)}/{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(1, 4)}-{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(9, 2)}:{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(11, 2)}:{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(13, 2)}"
            .Display();

            /*" -1071- DISPLAY '* DATA EXECUCAO....: ' WS-C-DATE-CURRENT(7:2) '/' WS-C-DATE-CURRENT(5:2) '/' WS-C-DATE-CURRENT(1:4) '-' WS-C-DATE-CURRENT(9:2) ':' WS-C-DATE-CURRENT(11:2) ':' WS-C-DATE-CURRENT(13:2) */

            $"* DATA EXECUCAO....: {WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(7, 2)}/{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(5, 2)}/{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(1, 4)}-{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(9, 2)}:{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(11, 2)}:{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(13, 2)}"
            .Display();

            /*" -1075- DISPLAY '* DATA SISTEMA.....: ' SISTEMAS-DATA-MOV-ABERTO(9:2) '/' SISTEMAS-DATA-MOV-ABERTO(6:2) '/' SISTEMAS-DATA-MOV-ABERTO(1:4) */

            $"* DATA SISTEMA.....: {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2)}/{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2)}/{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4)}"
            .Display();

            /*" -1076- DISPLAY '**********************************************' */
            _.Display($"**********************************************");

            /*" -1077- DISPLAY '*             DADOS DE ENTRADA               *' */
            _.Display($"*             DADOS DE ENTRADA               *");

            /*" -1078- DISPLAY '**********************************************' */
            _.Display($"**********************************************");

            /*" -1079- DISPLAY '* TRACE..............: ' LK-PF005-E-TRACE */
            _.Display($"* TRACE..............: {PF0005W.LK_PF005_E_TRACE}");

            /*" -1080- DISPLAY '* ACAO...............: ' LK-PF005-E-ACAO */
            _.Display($"* ACAO...............: {PF0005W.LK_PF005_E_ACAO}");

            /*" -1082- MOVE LK-PF005-E-NUM-IDENTIFICACAO TO WS-BIGINT(01) */
            _.Move(PF0005W.LK_PF005_E_NUM_IDENTIFICACAO, WORK.WS_EDIT.WS_BIGINT[01]);

            /*" -1083- DISPLAY '* NUM-IDENTIFICACAO..: ' WS-BIGINT(01) */
            _.Display($"* NUM-IDENTIFICACAO..: {WORK.WS_EDIT.WS_BIGINT[1]}");

            /*" -1084- DISPLAY '* DATA-SITUACAO......: ' LK-PF005-E-DATA-SITUACAO */
            _.Display($"* DATA-SITUACAO......: {PF0005W.LK_PF005_E_DATA_SITUACAO}");

            /*" -1085- MOVE LK-PF005-E-NSAS-SIVPF TO WS-INTEGER(01) */
            _.Move(PF0005W.LK_PF005_E_NSAS_SIVPF, WORK.WS_EDIT.WS_INTEGER[01]);

            /*" -1086- DISPLAY '* NSAS-SIVPF.........: ' WS-INTEGER(01) */
            _.Display($"* NSAS-SIVPF.........: {WORK.WS_EDIT.WS_INTEGER[1]}");

            /*" -1087- MOVE LK-PF005-E-NSL TO WS-INTEGER(01) */
            _.Move(PF0005W.LK_PF005_E_NSL, WORK.WS_EDIT.WS_INTEGER[01]);

            /*" -1088- DISPLAY '* NSL................: ' WS-INTEGER(01) */
            _.Display($"* NSL................: {WORK.WS_EDIT.WS_INTEGER[1]}");

            /*" -1089- DISPLAY '* SIT-PROPOSTA.......: ' LK-PF005-E-SIT-PROPOSTA */
            _.Display($"* SIT-PROPOSTA.......: {PF0005W.LK_PF005_E_SIT_PROPOSTA}");

            /*" -1091- DISPLAY '* SIT-COBRANCA-SIVPF.: ' LK-PF005-E-SIT-COBRANCA-SIVPF */
            _.Display($"* SIT-COBRANCA-SIVPF.: {PF0005W.LK_PF005_E_SIT_COBRANCA_SIVPF}");

            /*" -1093- MOVE LK-PF005-E-SIT-MOTIVO-SIVPF TO WS-INTEGER(01) */
            _.Move(PF0005W.LK_PF005_E_SIT_MOTIVO_SIVPF, WORK.WS_EDIT.WS_INTEGER[01]);

            /*" -1094- DISPLAY '* SIT-MOTIVO-SIVPF...: ' WS-INTEGER(01) */
            _.Display($"* SIT-MOTIVO-SIVPF...: {WORK.WS_EDIT.WS_INTEGER[1]}");

            /*" -1096- MOVE LK-PF005-E-COD-EMPRESA-SIVPF TO WS-SMALLINT(01) */
            _.Move(PF0005W.LK_PF005_E_COD_EMPRESA_SIVPF, WORK.WS_EDIT.WS_SMALLINT[01]);

            /*" -1097- DISPLAY '* COD-EMPRESA-SIVPF..: ' WS-SMALLINT(01) */
            _.Display($"* COD-EMPRESA-SIVPF..: {WORK.WS_EDIT.WS_SMALLINT[1]}");

            /*" -1099- MOVE LK-PF005-E-COD-PRODUTO-SIVPF TO WS-SMALLINT(01) */
            _.Move(PF0005W.LK_PF005_E_COD_PRODUTO_SIVPF, WORK.WS_EDIT.WS_SMALLINT[01]);

            /*" -1100- DISPLAY '* COD-PRODUTO-SIVPF..: ' WS-SMALLINT(01) */
            _.Display($"* COD-PRODUTO-SIVPF..: {WORK.WS_EDIT.WS_SMALLINT[1]}");

            /*" -1101- DISPLAY '* IND-TP-ACAO........: ' LK-PF005-E-IND-TP-ACAO */
            _.Display($"* IND-TP-ACAO........: {PF0005W.LK_PF005_E_IND_TP_ACAO}");

            /*" -1103- DISPLAY '* IND-TP-SENSIBILIZA.: ' LK-PF005-E-IND-TP-SENSIBILIZA */
            _.Display($"* IND-TP-SENSIBILIZA.: {PF0005W.LK_PF005_E_IND_TP_SENSIBILIZA}");

            /*" -1105- DISPLAY '* DTA-INI-VIGENCIA...: ' LK-PF005-E-DTA-INI-VIGENCIA */
            _.Display($"* DTA-INI-VIGENCIA...: {PF0005W.LK_PF005_E_DTA_INI_VIGENCIA}");

            /*" -1107- DISPLAY '* DTA-FIM-VIGENCIA...: ' LK-PF005-E-DTA-FIM-VIGENCIA */
            _.Display($"* DTA-FIM-VIGENCIA...: {PF0005W.LK_PF005_E_DTA_FIM_VIGENCIA}");

            /*" -1108- MOVE LK-PF005-E-NUM-PARCELA TO WS-INTEGER(01) */
            _.Move(PF0005W.LK_PF005_E_NUM_PARCELA, WORK.WS_EDIT.WS_INTEGER[01]);

            /*" -1109- DISPLAY '* NUM-PARCELA........: ' WS-INTEGER(01) */
            _.Display($"* NUM-PARCELA........: {WORK.WS_EDIT.WS_INTEGER[1]}");

            /*" -1111- MOVE LK-PF005-E-COD-TP-LANCAMENTO TO WS-SMALLINT(01) */
            _.Move(PF0005W.LK_PF005_E_COD_TP_LANCAMENTO, WORK.WS_EDIT.WS_SMALLINT[01]);

            /*" -1112- DISPLAY '* COD-TP-LANCAMENTO..: ' WS-SMALLINT(01) */
            _.Display($"* COD-TP-LANCAMENTO..: {WORK.WS_EDIT.WS_SMALLINT[1]}");

            /*" -1113- MOVE LK-PF005-E-VLR-PREMIO TO WS-DECIMAL(01) */
            _.Move(PF0005W.LK_PF005_E_VLR_PREMIO, WORK.WS_EDIT.WS_DECIMAL[01]);

            /*" -1114- DISPLAY '* VLR-PREMIO.........: ' WS-DECIMAL(01) */
            _.Display($"* VLR-PREMIO.........: {WORK.WS_EDIT.WS_DECIMAL[1]}");

            /*" -1115- MOVE LK-PF005-E-COD-ERRO TO WS-SMALLINT(01) */
            _.Move(PF0005W.LK_PF005_E_COD_ERRO, WORK.WS_EDIT.WS_SMALLINT[01]);

            /*" -1116- DISPLAY '* COD-ERRO...........: ' WS-SMALLINT(01) */
            _.Display($"* COD-ERRO...........: {WORK.WS_EDIT.WS_SMALLINT[1]}");

            /*" -1118- DISPLAY '* DTA-PROCESSAMENTO-CEF...: ' LK-PF005-E-DTA-PROCESSA-CEF */
            _.Display($"* DTA-PROCESSAMENTO-CEF...: {PF0005W.LK_PF005_E_DTA_PROCESSA_CEF}");

            /*" -1119- DISPLAY '* COD-USUARIO........: ' LK-PF005-E-COD-USUARIO */
            _.Display($"* COD-USUARIO........: {PF0005W.LK_PF005_E_COD_USUARIO}");

            /*" -1120- DISPLAY '* NOM-PROGRAMA.......: ' LK-PF005-E-NOM-PROGRAMA */
            _.Display($"* NOM-PROGRAMA.......: {PF0005W.LK_PF005_E_NOM_PROGRAMA}");

            /*" -1121- DISPLAY '**********************************************' */
            _.Display($"**********************************************");

            /*" -1122- DISPLAY '*           E R R O    P F 0 0 0 5 S         *' */
            _.Display($"*           E R R O    P F 0 0 0 5 S         *");

            /*" -1123- DISPLAY '**********************************************' */
            _.Display($"**********************************************");

            /*" -1124- DISPLAY '* SECTION............: ' WS-SECTION */
            _.Display($"* SECTION............: {WORK.WS_ERRO.WS_SECTION}");

            /*" -1125- DISPLAY '* IND ERRO...........: ' WS-IND-ERRO */
            _.Display($"* IND ERRO...........: {WORK.WS_ERRO.WS_IND_ERRO}");

            /*" -1126- DISPLAY '* TABELA.............: ' WS-TABELA */
            _.Display($"* TABELA.............: {WORK.WS_ERRO.WS_TABELA}");

            /*" -1127- DISPLAY '* MENSAGEM...........: ' WS-MENSAGEM */
            _.Display($"* MENSAGEM...........: {WORK.WS_ERRO.WS_MENSAGEM}");

            /*" -1128- DISPLAY '* SQLCODE............: ' WS-SQLCODE */
            _.Display($"* SQLCODE............: {WORK.WS_ERRO.WS_SQLCODE}");

            /*" -1129- DISPLAY '* SQLERRMC...........: ' WS-SQLERRMC */
            _.Display($"* SQLERRMC...........: {WORK.WS_ERRO.WS_SQLERRMC}");

            /*" -1130- DISPLAY '* SQLSTATE...........: ' WS-SQLSTATE */
            _.Display($"* SQLSTATE...........: {WORK.WS_ERRO.WS_SQLSTATE}");

            /*" -1132- DISPLAY '**********************************************' */
            _.Display($"**********************************************");

            /*" -1133- MOVE WS-IND-ERRO TO LK-PF005-IND-ERRO */
            _.Move(WORK.WS_ERRO.WS_IND_ERRO, PF0005W.LK_PF005_IND_ERRO);

            /*" -1134- MOVE WS-MENSAGEM TO LK-PF005-MENSAGEM */
            _.Move(WORK.WS_ERRO.WS_MENSAGEM, PF0005W.LK_PF005_MENSAGEM);

            /*" -1135- MOVE WS-TABELA TO LK-PF005-NOM-TABELA */
            _.Move(WORK.WS_ERRO.WS_TABELA, PF0005W.LK_PF005_NOM_TABELA);

            /*" -1136- MOVE WS-SQLCODE TO LK-PF005-SQLCODE */
            _.Move(WORK.WS_ERRO.WS_SQLCODE, PF0005W.LK_PF005_SQLCODE);

            /*" -1137- MOVE WS-SQLERRMC TO LK-PF005-SQLERRMC */
            _.Move(WORK.WS_ERRO.WS_SQLERRMC, PF0005W.LK_PF005_SQLERRMC);

            /*" -1137- MOVE WS-SQLSTATE TO LK-PF005-SQLSTATE */
            _.Move(WORK.WS_ERRO.WS_SQLSTATE, PF0005W.LK_PF005_SQLSTATE);

            /*" -0- FLUXCONTROL_PERFORM P9999_99_EXIT */

            P9999_99_EXIT();

        }

        [StopWatch]
        /*" P9999-99-EXIT */
        private void P9999_99_EXIT(bool isPerform = false)
        {
            /*" -1142- GOBACK. */

            throw new GoBack();

        }
    }
}