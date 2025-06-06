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
using Sias.Outros.DB2.SPBVG017;

namespace Code
{
    public class SPBVG017
    {
        public bool IsCall { get; set; }

        public SPBVG017()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      * SISTEMA.........: SIAS                                         *      */
        /*"      * MODULO..........: VIDA                                         *      */
        /*"      * PROGRAMA........: SPBVG017                                     *      */
        /*"      * ANALISTA........: ELIERMES OLIVEIRA                            *      */
        /*"      * DATA............: 05/08/2024                                   *      */
        /*"      * DEMANDA.........: 571176                                       *      */
        /*"      ******************************************************************      */
        /*"      * OBJETIVO........: MANTER STATUS DE DPS PARA PROPOSTA/CPF/CNPJ  *      */
        /*"      *                   NAS TABELAS VG_DPS_PROPOSTA E HISTORICO      *      */
        /*"      *                   OBSERVA��O:                                  *      */
        /*"      *                   - DOCUMENTACAO DOS CAMPOS NO BOOK DE LINKAGE *      */
        /*"      *                     LK-VG017-TIPO-ACAO                         *      */
        /*"      *                   (01) PESQUISAR PROPOSTA E RETORNAR SE        *      */
        /*"      *                        ESTA CADASTRADO OU NAO.                 *      */
        /*"      *                        CASO ESTEJA CADASTRADO RETORNAR DADOS   *      */
        /*"      *                        DA TABELA EM SUA ULTIMA SITUACAO        *      */
        /*"      *                   (02) INSERIR STATUS DE DPS PARA A PROPOSTA   *      */
        /*"      *                   (03) ATUALIZAR STATUS DE DPS PARA A PROPOSTA *      */
        /*"      *                        E INSERIR HISTORICO DE STATUS           *      */
        /*"      *                   (04) CONSULTA DE HISTORICO COM RESULT_SET    *      */
        /*"      *                   (05) CONSULTA PROPOSTAS COM NECESSIDADE DE   *      */
        /*"      *                        VERIFICACAO DE STATUS JUNTO AO MOTOR DPS*      */
        /*"      *                        COM RESULT_SET                          *      */
        /*"      ******************************************************************      */
        /*"      * VERSAO     DATA     RESPONSAVEL       ALTERACAO                *      */
        /*"      ******************************************************************      */
        /*"V.XX  *   VERSAO XX - DEMANDA XXXXXX -   XXXXXXXXXXXXXXXXXXXXXXXXXXXXXX*      */
        /*"      *               XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX*      */
        /*"      *               XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX          *      */
        /*"      *                                                                *      */
        /*"      * EM DD/MM/AAAA - XXXXXXXXXXXXXXXXX    PROCURE POR V.XX          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * EM 05/08/2024 - ELIERMES OLIVEIRA D 571176   POR V.00          *      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"01    WH-AUXILIAR.*/
        public SPBVG017_WH_AUXILIAR WH_AUXILIAR { get; set; } = new SPBVG017_WH_AUXILIAR();
        public class SPBVG017_WH_AUXILIAR : VarBasis
        {
            /*"  05  WH-CURRENT-TIMESTAMP           PIC  X(026) VALUE SPACES.*/
            public StringBasis WH_CURRENT_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
            /*"  05  WH-I-NUM-CERTIFICADO           PIC S9(004) COMP-5 VALUE 0.*/
            public IntBasis WH_I_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05  WH-I-VLR-IS                    PIC S9(004) COMP-5 VALUE 0.*/
            public IntBasis WH_I_VLR_IS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05  WH-I-VLR-ACUMULO-IS            PIC S9(004) COMP-5 VALUE 0.*/
            public IntBasis WH_I_VLR_ACUMULO_IS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05  WH-STA-DPS-PROPOSTA            PIC S9(004) COMP-5 VALUE 0.*/
            public IntBasis WH_STA_DPS_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05  WH-VG103-DES-COMPLEMENTAR.*/
            public SPBVG017_WH_VG103_DES_COMPLEMENTAR WH_VG103_DES_COMPLEMENTAR { get; set; } = new SPBVG017_WH_VG103_DES_COMPLEMENTAR();
            public class SPBVG017_WH_VG103_DES_COMPLEMENTAR : VarBasis
            {
                /*"   49 WH-VG103-DES-COMPLEMENTAR-LEN  PIC S9(004) COMP VALUE 0.*/
                public IntBasis WH_VG103_DES_COMPLEMENTAR_LEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"   49 WH-VG103-DES-COMPLEMENTAR-TEXT PIC  X(1000) VALUE SPACES.*/
                public StringBasis WH_VG103_DES_COMPLEMENTAR_TEXT { get; set; } = new StringBasis(new PIC("X", "1000", "X(1000)"), @"");
                /*"  05  WH-VG103IDES-COMPLEMENTAR      PIC S9(004) COMP-5 VALUE 0.*/
            }
            public IntBasis WH_VG103IDES_COMPLEMENTAR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05  WH-VG103INUM-PROPOSTA          PIC S9(004) COMP-5 VALUE 0.*/
            public IntBasis WH_VG103INUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05  WS-STA-CRITICA                 PIC  X(001) VALUE SPACES.*/
            public StringBasis WS_STA_CRITICA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"01    WORK.*/
        }
        public SPBVG017_WORK WORK { get; set; } = new SPBVG017_WORK();
        public class SPBVG017_WORK : VarBasis
        {
            /*"  05  WS-PROGRAMA                    PIC  X(008) VALUE SPACES.*/
            public StringBasis WS_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"  05  WS-ORIG-PRODUTO                PIC  X(010) VALUE SPACES.*/
            public StringBasis WS_ORIG_PRODUTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05  WS-AUXILIARES.*/
            public SPBVG017_WS_AUXILIARES WS_AUXILIARES { get; set; } = new SPBVG017_WS_AUXILIARES();
            public class SPBVG017_WS_AUXILIARES : VarBasis
            {
                /*"   10 WS-STA-PARA                    PIC  X(004) VALUE SPACES.*/
                public StringBasis WS_STA_PARA { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"  05  TESTA-FIM-CURSOR               PIC  9(001).*/
            }

            public SelectorBasis TESTA_FIM_CURSOR { get; set; } = new SelectorBasis("001")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 FIM-CURSOR02                               VALUE 1. */
							new SelectorItemBasis("FIM_CURSOR02", "1")
                }
            };

            /*"  05  WS-CONTADORES.*/
            public SPBVG017_WS_CONTADORES WS_CONTADORES { get; set; } = new SPBVG017_WS_CONTADORES();
            public class SPBVG017_WS_CONTADORES : VarBasis
            {
                /*"   10 WS-I                           PIC S9(004) COMP VALUE 0.*/
                public IntBasis WS_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"   10 WS-J                           PIC S9(004) COMP VALUE 0.*/
                public IntBasis WS_J { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"  05  WS-DATAS.*/
            }
            public SPBVG017_WS_DATAS WS_DATAS { get; set; } = new SPBVG017_WS_DATAS();
            public class SPBVG017_WS_DATAS : VarBasis
            {
                /*"   10 WS-C-DATE-CURRENT              PIC  X(014) VALUE SPACES.*/
                public StringBasis WS_C_DATE_CURRENT { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
                /*"   10 WS-C-DATE-COMPILED             PIC  X(014) VALUE SPACES.*/
                public StringBasis WS_C_DATE_COMPILED { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
                /*"  05  WS-EDIT.*/
            }
            public SPBVG017_WS_EDIT WS_EDIT { get; set; } = new SPBVG017_WS_EDIT();
            public class SPBVG017_WS_EDIT : VarBasis
            {
                /*"   10 WS-SMALLINT                    PIC ZZ.ZZ9- OCCURS 5 TIMES.*/
                public ListBasis<IntBasis, Int64> WS_SMALLINT { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "6", "ZZ.ZZ9-"), 5);
                /*"   10 WS-INTEGER                     PIC Z.ZZZ.ZZZ.ZZ9-                                                 OCCURS 5 TIMES.*/
                public ListBasis<IntBasis, Int64> WS_INTEGER { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "11", "Z.ZZZ.ZZZ.ZZ9-"), 5);
                /*"   10 WS-BIGINT                      PIC 99999999999999                                                 OCCURS 5 TIMES.*/
                public ListBasis<IntBasis, Int64> WS_BIGINT { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "14", "99999999999999"), 5);
                /*"   10 WS-DECIMAL                     PIC ZZZZZZZZZZZZZZ9,99                                                 OCCURS 5 TIMES.*/
                public ListBasis<DoubleBasis, double> WS_DECIMAL { get; set; } = new ListBasis<DoubleBasis, double>(new PIC("9", "15", "ZZZZZZZZZZZZZZ9V99"), 5);
                /*"  05  WS-ERRO.*/
            }
            public SPBVG017_WS_ERRO WS_ERRO { get; set; } = new SPBVG017_WS_ERRO();
            public class SPBVG017_WS_ERRO : VarBasis
            {
                /*"   10 WS-SECTION                     PIC  X(005) VALUE SPACES.*/
                public StringBasis WS_SECTION { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"   10 WS-SQLCODE                     PIC  ZZZZ9-.*/
                public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "6", "ZZZZ9-."));
                /*"   10 WS-SQLERRMC                    PIC  X(076) VALUE SPACES.*/
                public StringBasis WS_SQLERRMC { get; set; } = new StringBasis(new PIC("X", "76", "X(076)"), @"");
                /*"   10 WS-MENSAGEM                    PIC  X(255) VALUE SPACES.*/
                public StringBasis WS_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "255", "X(255)"), @"");
                /*"   10 WS-TABELA                      PIC  X(050) VALUE SPACES.*/
                public StringBasis WS_TABELA { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
                /*"   10 WS-IND-ERRO                    PIC  9(001) VALUE 0.*/
                public IntBasis WS_IND_ERRO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
                /*"  05  WS-INDICADORES.*/
            }
            public SPBVG017_WS_INDICADORES WS_INDICADORES { get; set; } = new SPBVG017_WS_INDICADORES();
            public class SPBVG017_WS_INDICADORES : VarBasis
            {
                /*"   10 WS-IND-STATUS                  PIC  X(001) VALUE SPACES.*/

                public SelectorBasis WS_IND_STATUS { get; set; } = new SelectorBasis("001", "SPACES")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88 INDSTATUSSIM                  VALUE 'S'. */
							new SelectorItemBasis("INDSTATUSSIM", "S"),
							/*" 88 INDSTATUSNAO                  VALUE 'N'. */
							new SelectorItemBasis("INDSTATUSNAO", "N")
                }
                };

                /*"   10 WS-IND-P0351                   PIC  X(001) VALUE SPACES.*/

                public SelectorBasis WS_IND_P0351 { get; set; } = new SelectorBasis("001", "SPACES")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88 INDP0351SIM                   VALUE 'S'. */
							new SelectorItemBasis("INDP0351SIM", "S"),
							/*" 88 INDP0351NAO                   VALUE 'N'. */
							new SelectorItemBasis("INDP0351NAO", "N")
                }
                };

            }
        }


        public Copies.RSGEWSTR RSGEWSTR { get; set; } = new Copies.RSGEWSTR();
        public Copies.SPVG017W SPVG017W { get; set; } = new Copies.SPVG017W();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.VG142 VG142 { get; set; } = new Dclgens.VG142();
        public Dclgens.VG143 VG143 { get; set; } = new Dclgens.VG143();
        public Dclgens.VG144 VG144 { get; set; } = new Dclgens.VG144();
        public SPBVG017_SPBVG017_EC001 SPBVG017_EC001 { get; set; } = new SPBVG017_SPBVG017_EC001();
        public SPBVG017_SPBVG017_EC002 SPBVG017_EC002 { get; set; } = new SPBVG017_SPBVG017_EC002();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(SPVG017W SPVG017W_P) //PROCEDURE DIVISION USING 
        /*PROCEDURE DIVISION
        LK_VG017_E_TRACE
        LK_VG017_E_IDE_SISTEMA
        LK_VG017_E_COD_USUARIO
        LK_VG017_E_NOM_PROGRAMA
        LK_VG017_E_TIPO_ACAO
        LK_VG017_E_NUM_PROTOCOLO
        LK_VG017_E_NUM_CPF_CNPJ
        LK_VG017_E_NUM_PROPOSTA
        LK_VG017_E_SEQ_PRODUTO_DPS
        LK_VG017_E_DTH_CONSULTA_DPS
        LK_VG017_E_IND_TP_PESSOA
        LK_VG017_E_IND_TP_SEGURADO
        LK_VG017_E_NUM_CERTIFICADO
        LK_VG017_E_VLR_IS
        LK_VG017_E_VLR_ACUMULADO_IS
        LK_VG017_E_STA_PROPOSTA_SIAS
        LK_VG017_E_STA_PROPOSTA_MOTOR
        LK_VG017_IND_ERRO
        LK_VG017_MENSAGEM
        LK_VG017_NOM_TABELA
        LK_VG017_SQLCODE
        LK_VG017_SQLERRMC
        LK_VG017_SQLSTATE
        */
        {
            try
            {
                this.SPVG017W = SPVG017W_P;

                /*" -0- FLUXCONTROL_PERFORM P0000-INICIALIZAR-SECTION */

                P0000_INICIALIZAR_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

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

            /*" -191- MOVE FUNCTION WHEN-COMPILED TO WS-C-DATE-COMPILED. */
            _.Move(_.WhenCompiled(), WORK.WS_DATAS.WS_C_DATE_COMPILED);

            /*" -199- INITIALIZE LK-VG017-IND-ERRO WS-ERRO LK-VG017-MENSAGEM LK-VG017-NOM-TABELA LK-VG017-SQLCODE LK-VG017-SQLERRMC LK-VG017-SQLSTATE WS-MENSAGEM */
            _.Initialize(
                SPVG017W.LK_VG017_IND_ERRO
                , WORK.WS_ERRO
                , SPVG017W.LK_VG017_MENSAGEM
                , SPVG017W.LK_VG017_NOM_TABELA
                , SPVG017W.LK_VG017_SQLCODE
                , SPVG017W.LK_VG017_SQLERRMC
                , SPVG017W.LK_VG017_SQLSTATE
                , WORK.WS_ERRO.WS_MENSAGEM
            );

            /*" -204- INITIALIZE DCLVG-DPS-PROPOSTA DCLVG-DPS-PROPOSTA-HIST DCLVG-PRODUTO-REGRA-DPS DCLSISTEMAS */
            _.Initialize(
                VG143.DCLVG_DPS_PROPOSTA
                , VG144.DCLVG_DPS_PROPOSTA_HIST
                , VG142.DCLVG_PRODUTO_REGRA_DPS
                , SISTEMAS.DCLSISTEMAS
            );

            /*" -205- IF NOT ( LK-VG017-E-TRACE = 'S' OR = 'N' ) */

            if (!(SPVG017W.LK_VG017_E_TRACE.In("S", "N")))
            {

                /*" -206- MOVE 'N' TO LK-VG017-E-TRACE */
                _.Move("N", SPVG017W.LK_VG017_E_TRACE);

                /*" -208- END-IF */
            }


            /*" -210- PERFORM P0050-VERIFICAR-SISTEMA */

            P0050_VERIFICAR_SISTEMA_SECTION();

            /*" -211- DISPLAY '**********************************************' */
            _.Display($"**********************************************");

            /*" -212- DISPLAY '*            S P B V G 0 1 7                 *' */
            _.Display($"*            S P B V G 0 1 7                 *");

            /*" -213- DISPLAY '**********************************************' */
            _.Display($"**********************************************");

            /*" -220- DISPLAY '* DATA COMPILACAO..: ' WS-C-DATE-COMPILED(7:2) '/' WS-C-DATE-COMPILED(5:2) '/' WS-C-DATE-COMPILED(1:4) '-' WS-C-DATE-COMPILED(9:2) ':' WS-C-DATE-COMPILED(11:2) ':' WS-C-DATE-COMPILED(13:2) */

            $"* DATA COMPILACAO..: {WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(7, 2)}/{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(5, 2)}/{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(1, 4)}-{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(9, 2)}:{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(11, 2)}:{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(13, 2)}"
            .Display();

            /*" -227- DISPLAY '* DATA EXECUCAO....: ' WS-C-DATE-CURRENT(7:2) '/' WS-C-DATE-CURRENT(5:2) '/' WS-C-DATE-CURRENT(1:4) '-' WS-C-DATE-CURRENT(9:2) ':' WS-C-DATE-CURRENT(11:2) ':' WS-C-DATE-CURRENT(13:2) */

            $"* DATA EXECUCAO....: {WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(7, 2)}/{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(5, 2)}/{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(1, 4)}-{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(9, 2)}:{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(11, 2)}:{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(13, 2)}"
            .Display();

            /*" -231- DISPLAY '* DATA SISTEMA.....: ' SISTEMAS-DATA-MOV-ABERTO(9:2) '/' SISTEMAS-DATA-MOV-ABERTO(6:2) '/' SISTEMAS-DATA-MOV-ABERTO(1:4) */

            $"* DATA SISTEMA.....: {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2)}/{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2)}/{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4)}"
            .Display();

            /*" -232- MOVE LK-VG017-E-NUM-PROTOCOLO TO WS-BIGINT (01) */
            _.Move(SPVG017W.LK_VG017_E_NUM_PROTOCOLO, WORK.WS_EDIT.WS_BIGINT[01]);

            /*" -233- MOVE LK-VG017-E-NUM-CPF-CNPJ TO WS-BIGINT (02) */
            _.Move(SPVG017W.LK_VG017_E_NUM_CPF_CNPJ, WORK.WS_EDIT.WS_BIGINT[02]);

            /*" -234- MOVE LK-VG017-E-NUM-PROPOSTA TO WS-BIGINT (03) */
            _.Move(SPVG017W.LK_VG017_E_NUM_PROPOSTA, WORK.WS_EDIT.WS_BIGINT[03]);

            /*" -235- MOVE LK-VG017-E-SEQ-PRODUTO-DPS TO WS-SMALLINT(01) */
            _.Move(SPVG017W.LK_VG017_E_SEQ_PRODUTO_DPS, WORK.WS_EDIT.WS_SMALLINT[01]);

            /*" -236- MOVE LK-VG017-E-NUM-CERTIFICADO TO WS-BIGINT (04) */
            _.Move(SPVG017W.LK_VG017_E_NUM_CERTIFICADO, WORK.WS_EDIT.WS_BIGINT[04]);

            /*" -237- MOVE LK-VG017-E-VLR-IS TO WS-DECIMAL (01) */
            _.Move(SPVG017W.LK_VG017_E_VLR_IS, WORK.WS_EDIT.WS_DECIMAL[01]);

            /*" -238- MOVE LK-VG017-E-VLR-ACUMULADO-IS TO WS-DECIMAL (02) */
            _.Move(SPVG017W.LK_VG017_E_VLR_ACUMULADO_IS, WORK.WS_EDIT.WS_DECIMAL[02]);

            /*" -239- MOVE LK-VG017-E-STA-PROPOSTA-SIAS TO WS-SMALLINT(02) */
            _.Move(SPVG017W.LK_VG017_E_STA_PROPOSTA_SIAS, WORK.WS_EDIT.WS_SMALLINT[02]);

            /*" -240- MOVE LK-VG017-E-TIPO-ACAO TO WS-SMALLINT(03) */
            _.Move(SPVG017W.LK_VG017_E_TIPO_ACAO, WORK.WS_EDIT.WS_SMALLINT[03]);

            /*" -241- DISPLAY '**********************************************' */
            _.Display($"**********************************************");

            /*" -242- DISPLAY '*         DADOS DE ENTRADA SPBVG017          *' */
            _.Display($"*         DADOS DE ENTRADA SPBVG017          *");

            /*" -243- DISPLAY '**********************************************' */
            _.Display($"**********************************************");

            /*" -244- DISPLAY '* IDE-SISTEMA.....: ' LK-VG017-E-IDE-SISTEMA */
            _.Display($"* IDE-SISTEMA.....: {SPVG017W.LK_VG017_E_IDE_SISTEMA}");

            /*" -245- DISPLAY '* COD-USUARIO.....: ' LK-VG017-E-COD-USUARIO */
            _.Display($"* COD-USUARIO.....: {SPVG017W.LK_VG017_E_COD_USUARIO}");

            /*" -246- DISPLAY '* NOM-PROGRAMA....: ' LK-VG017-E-NOM-PROGRAMA */
            _.Display($"* NOM-PROGRAMA....: {SPVG017W.LK_VG017_E_NOM_PROGRAMA}");

            /*" -247- DISPLAY '* TPO-ACAO........: ' WS-SMALLINT(03) */
            _.Display($"* TPO-ACAO........: {WORK.WS_EDIT.WS_SMALLINT[3]}");

            /*" -248- DISPLAY '* NUM-PROTOCOLO...: ' WS-BIGINT (01) */
            _.Display($"* NUM-PROTOCOLO...: {WORK.WS_EDIT.WS_BIGINT[1]}");

            /*" -249- DISPLAY '* NUM-CPF-CNPJ....: ' WS-BIGINT (02) */
            _.Display($"* NUM-CPF-CNPJ....: {WORK.WS_EDIT.WS_BIGINT[2]}");

            /*" -250- DISPLAY '* NUM-PROPOSTA....: ' WS-BIGINT (03) */
            _.Display($"* NUM-PROPOSTA....: {WORK.WS_EDIT.WS_BIGINT[3]}");

            /*" -251- DISPLAY '* SEQ-PRODUTO-DPS.: ' WS-SMALLINT(01) */
            _.Display($"* SEQ-PRODUTO-DPS.: {WORK.WS_EDIT.WS_SMALLINT[1]}");

            /*" -252- DISPLAY '* DTH-CONSULTA-DPS: ' LK-VG017-E-DTH-CONSULTA-DPS */
            _.Display($"* DTH-CONSULTA-DPS: {SPVG017W.LK_VG017_E_DTH_CONSULTA_DPS}");

            /*" -253- DISPLAY '* IND-TP-PESSOA...: ' LK-VG017-E-IND-TP-PESSOA */
            _.Display($"* IND-TP-PESSOA...: {SPVG017W.LK_VG017_E_IND_TP_PESSOA}");

            /*" -254- DISPLAY '* IND-TP-SEGURADO.: ' LK-VG017-E-IND-TP-SEGURADO */
            _.Display($"* IND-TP-SEGURADO.: {SPVG017W.LK_VG017_E_IND_TP_SEGURADO}");

            /*" -255- DISPLAY '* NUM-CERTIFICADO.: ' WS-BIGINT (04) */
            _.Display($"* NUM-CERTIFICADO.: {WORK.WS_EDIT.WS_BIGINT[4]}");

            /*" -256- DISPLAY '* VLR-IS..........: ' WS-DECIMAL (01) */
            _.Display($"* VLR-IS..........: {WORK.WS_EDIT.WS_DECIMAL[1]}");

            /*" -257- DISPLAY '* VLR-ACUMULADO-IS: ' WS-DECIMAL (02) */
            _.Display($"* VLR-ACUMULADO-IS: {WORK.WS_EDIT.WS_DECIMAL[2]}");

            /*" -258- DISPLAY '* STA-PROPOSTA-SIA: ' WS-SMALLINT(02) */
            _.Display($"* STA-PROPOSTA-SIA: {WORK.WS_EDIT.WS_SMALLINT[2]}");

            /*" -259- DISPLAY '* STA-PROPOSTA-MTR: ' LK-VG017-E-STA-PROPOSTA-MOTOR */
            _.Display($"* STA-PROPOSTA-MTR: {SPVG017W.LK_VG017_E_STA_PROPOSTA_MOTOR}");

            /*" -260- DISPLAY '**********************************************' */
            _.Display($"**********************************************");

            /*" -260- PERFORM P0005-PROCESSAR. */

            P0005_PROCESSAR_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0000_99_EXIT*/

        [StopWatch]
        /*" P0005-PROCESSAR-SECTION */
        private void P0005_PROCESSAR_SECTION()
        {
            /*" -271- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0005_00_START */

            P0005_00_START();

        }

        [StopWatch]
        /*" P0005-00-START */
        private void P0005_00_START(bool isPerform = false)
        {
            /*" -274- MOVE 'P0005' TO WS-SECTION. */
            _.Move("P0005", WORK.WS_ERRO.WS_SECTION);

            /*" -275- IF LK-VG017-E-TRACE = 'S' */

            if (SPVG017W.LK_VG017_E_TRACE == "S")
            {

                /*" -276- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -277- END-IF */
            }


            /*" -277- PERFORM P0005-05-INICIO. */

            P0005_05_INICIO(true);

        }

        [StopWatch]
        /*" P0005-05-INICIO */
        private void P0005_05_INICIO(bool isPerform = false)
        {
            /*" -282- PERFORM P0100-VALIDAR-LINKAGE. */

            P0100_VALIDAR_LINKAGE_SECTION();

            /*" -284- MOVE 'P0005' TO WS-SECTION */
            _.Move("P0005", WORK.WS_ERRO.WS_SECTION);

            /*" -285-  EVALUATE TRUE  */

            /*" -287-  WHEN LK-VG017-E-TIPO-ACAO       = 01  */

            /*" -287- IF LK-VG017-E-TIPO-ACAO       = 01 */

            if (SPVG017W.LK_VG017_E_TIPO_ACAO == 01)
            {

                /*" -288- PERFORM P0101-VALIDAR-LINKAGE-01 */

                P0101_VALIDAR_LINKAGE_01_SECTION();

                /*" -289- PERFORM P0301-TRATAR-TIPO-ACAO-01 */

                P0301_TRATAR_TIPO_ACAO_01_SECTION();

                /*" -291-  WHEN LK-VG017-E-TIPO-ACAO       = 02  */

                /*" -291- ELSE IF LK-VG017-E-TIPO-ACAO       = 02 */
            }
            else

            if (SPVG017W.LK_VG017_E_TIPO_ACAO == 02)
            {

                /*" -292- PERFORM P0102-VALIDAR-LINKAGE-02 */

                P0102_VALIDAR_LINKAGE_02_SECTION();

                /*" -293- PERFORM P0302-TRATAR-TIPO-ACAO-02 */

                P0302_TRATAR_TIPO_ACAO_02_SECTION();

                /*" -295-  WHEN LK-VG017-E-TIPO-ACAO       = 03  */

                /*" -295- ELSE IF LK-VG017-E-TIPO-ACAO       = 03 */
            }
            else

            if (SPVG017W.LK_VG017_E_TIPO_ACAO == 03)
            {

                /*" -296- PERFORM P0103-VALIDAR-LINKAGE-03 */

                P0103_VALIDAR_LINKAGE_03_SECTION();

                /*" -297- PERFORM P0303-TRATAR-TIPO-ACAO-03 */

                P0303_TRATAR_TIPO_ACAO_03_SECTION();

                /*" -299-  WHEN LK-VG017-E-TIPO-ACAO       = 04  */

                /*" -299- ELSE IF LK-VG017-E-TIPO-ACAO       = 04 */
            }
            else

            if (SPVG017W.LK_VG017_E_TIPO_ACAO == 04)
            {

                /*" -300- PERFORM P0101-VALIDAR-LINKAGE-01 */

                P0101_VALIDAR_LINKAGE_01_SECTION();

                /*" -301- PERFORM P0304-TRATAR-TIPO-ACAO-04 */

                P0304_TRATAR_TIPO_ACAO_04_SECTION();

                /*" -303-  WHEN LK-VG017-E-TIPO-ACAO       = 05  */

                /*" -303- ELSE IF LK-VG017-E-TIPO-ACAO       = 05 */
            }
            else

            if (SPVG017W.LK_VG017_E_TIPO_ACAO == 05)
            {

                /*" -304- PERFORM P0305-TRATAR-TIPO-ACAO-05 */

                P0305_TRATAR_TIPO_ACAO_05_SECTION();

                /*" -305-  WHEN OTHER  */

                /*" -305- ELSE */
            }
            else
            {


                /*" -306- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -307- MOVE LK-VG017-E-TIPO-ACAO TO WS-SMALLINT(01) */
                _.Move(SPVG017W.LK_VG017_E_TIPO_ACAO, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -311- STRING WS-SECTION ' - TIPO DE ACAO INFORMADA INVALIDA.' ' <TIPO_ACAO = ' WS-SMALLINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl1 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl1 += " - TIPO DE ACAO INFORMADA INVALIDA.";
                spl1 += " <TIPO_ACAO = ";
                var spl2 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl2 += ">";
                var results3 = spl1 + spl2;
                _.Move(results3, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -312- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -313- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -314- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -316-  END-EVALUATE  */

                /*" -316- END-IF */
            }


            /*" -316- PERFORM P0010-FINALIZAR. */

            P0010_FINALIZAR_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0005_99_EXIT*/

        [StopWatch]
        /*" P0010-FINALIZAR-SECTION */
        private void P0010_FINALIZAR_SECTION()
        {
            /*" -327- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0010_00_START */

            P0010_00_START();

        }

        [StopWatch]
        /*" P0010-00-START */
        private void P0010_00_START(bool isPerform = false)
        {
            /*" -330- MOVE 'P0010' TO WS-SECTION. */
            _.Move("P0010", WORK.WS_ERRO.WS_SECTION);

            /*" -331- IF LK-VG017-E-TRACE = 'S' */

            if (SPVG017W.LK_VG017_E_TRACE == "S")
            {

                /*" -332- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -333- END-IF */
            }


            /*" -333- PERFORM P0010-05-INICIO. */

            P0010_05_INICIO(true);

        }

        [StopWatch]
        /*" P0010-05-INICIO */
        private void P0010_05_INICIO(bool isPerform = false)
        {
            /*" -338- MOVE 0 TO WS-IND-ERRO */
            _.Move(0, WORK.WS_ERRO.WS_IND_ERRO);

            /*" -341- MOVE SPACES TO WS-MENSAGEM LK-VG017-MENSAGEM */
            _.Move("", WORK.WS_ERRO.WS_MENSAGEM, SPVG017W.LK_VG017_MENSAGEM);

            /*" -344- STRING 'OPERACAO SOLICITADA REALIZADA COM SUCESSO.' DELIMITED BY SIZE INTO WS-MENSAGEM */
            #region STRING
            var spl3 = "OPERACAO SOLICITADA REALIZADA COM SUCESSO.";
            _.Move(spl3, WORK.WS_ERRO.WS_MENSAGEM);
            #endregion

            /*" -345- MOVE WS-MENSAGEM TO LK-VG017-MENSAGEM */
            _.Move(WORK.WS_ERRO.WS_MENSAGEM, SPVG017W.LK_VG017_MENSAGEM);

            /*" -346- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
            _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

            /*" -348- MOVE 0 TO WS-SQLCODE */
            _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

            /*" -348- PERFORM P0010-99-EXIT. */

            P0010_99_EXIT(true);

        }

        [StopWatch]
        /*" P0010-99-EXIT */
        private void P0010_99_EXIT(bool isPerform = false)
        {
            /*" -351- GOBACK. */

            throw new GoBack();

        }

        [StopWatch]
        /*" P0050-VERIFICAR-SISTEMA-SECTION */
        private void P0050_VERIFICAR_SISTEMA_SECTION()
        {
            /*" -359- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0050_00_START */

            P0050_00_START();

        }

        [StopWatch]
        /*" P0050-00-START */
        private void P0050_00_START(bool isPerform = false)
        {
            /*" -363- MOVE 'P0050' TO WS-SECTION. */
            _.Move("P0050", WORK.WS_ERRO.WS_SECTION);

            /*" -364- IF LK-VG017-E-TRACE = 'S' */

            if (SPVG017W.LK_VG017_E_TRACE == "S")
            {

                /*" -365- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -366- END-IF */
            }


            /*" -366- PERFORM P0050-05-INICIO. */

            P0050_05_INICIO(true);

        }

        [StopWatch]
        /*" P0050-05-INICIO */
        private void P0050_05_INICIO(bool isPerform = false)
        {
            /*" -376- PERFORM P0050_05_INICIO_DB_SELECT_1 */

            P0050_05_INICIO_DB_SELECT_1();

            /*" -379- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -380- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -384- STRING WS-SECTION ' - ERRO NO SELECT NA SEGUROS.SISTEMA.' ' <SISTEMA = VG >' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl4 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl4 += " - ERRO NO SELECT NA SEGUROS.SISTEMA.";
                spl4 += " <SISTEMA = VG >";
                _.Move(spl4, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -385- MOVE 'SEGUROS.SISTEMA' TO WS-TABELA */
                _.Move("SEGUROS.SISTEMA", WORK.WS_ERRO.WS_TABELA);

                /*" -386- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -387- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -388- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -390- END-IF */
            }


            /*" -391- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -392- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -396- STRING WS-SECTION ' - REGISTRO DE CONTROLE SISTEMA NAO CADASTRADO.' ' <SISTEMA = VG >' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl5 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl5 += " - REGISTRO DE CONTROLE SISTEMA NAO CADASTRADO.";
                spl5 += " <SISTEMA = VG >";
                _.Move(spl5, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -397- MOVE 'SEGUROS.SISTEMA' TO WS-TABELA */
                _.Move("SEGUROS.SISTEMA", WORK.WS_ERRO.WS_TABELA);

                /*" -398- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -399- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -400- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -400- END-IF. */
            }


        }

        [StopWatch]
        /*" P0050-05-INICIO-DB-SELECT-1 */
        public void P0050_05_INICIO_DB_SELECT_1()
        {
            /*" -376- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VG' WITH UR END-EXEC. */

            var p0050_05_INICIO_DB_SELECT_1_Query1 = new P0050_05_INICIO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = P0050_05_INICIO_DB_SELECT_1_Query1.Execute(p0050_05_INICIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0050_EXIT*/

        [StopWatch]
        /*" P0100-VALIDAR-LINKAGE-SECTION */
        private void P0100_VALIDAR_LINKAGE_SECTION()
        {
            /*" -411- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0100_00_START */

            P0100_00_START();

        }

        [StopWatch]
        /*" P0100-00-START */
        private void P0100_00_START(bool isPerform = false)
        {
            /*" -414- MOVE 'P0100' TO WS-SECTION. */
            _.Move("P0100", WORK.WS_ERRO.WS_SECTION);

            /*" -415- IF LK-VG017-E-TRACE = 'S' */

            if (SPVG017W.LK_VG017_E_TRACE == "S")
            {

                /*" -416- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -417- END-IF */
            }


            /*" -417- PERFORM P0100-05-INICIO. */

            P0100_05_INICIO(true);

        }

        [StopWatch]
        /*" P0100-05-INICIO */
        private void P0100_05_INICIO(bool isPerform = false)
        {
            /*" -422- IF LK-VG017-E-IDE-SISTEMA = SPACES */

            if (SPVG017W.LK_VG017_E_IDE_SISTEMA.IsEmpty())
            {

                /*" -423- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -427- STRING WS-SECTION ' - IDENTIFICAO DO SISTEMA NAO INFORMADO. ' ' <IDE_SISTEMA = ' LK-VG017-E-IDE-SISTEMA '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl6 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl6 += " - IDENTIFICAO DO SISTEMA NAO INFORMADO. ";
                spl6 += " <IDE_SISTEMA = ";
                var spl7 = SPVG017W.LK_VG017_E_IDE_SISTEMA.GetMoveValues();
                spl7 += ">";
                var results8 = spl6 + spl7;
                _.Move(results8, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -428- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -429- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -430- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -432- END-IF */
            }


            /*" -433- IF LK-VG017-E-COD-USUARIO = SPACES */

            if (SPVG017W.LK_VG017_E_COD_USUARIO.IsEmpty())
            {

                /*" -434- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -438- STRING WS-SECTION ' - CODIGO DO USUARIO NAO INFORMADO.' ' <COD_USUARIO = ' LK-VG017-E-COD-USUARIO '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl8 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl8 += " - CODIGO DO USUARIO NAO INFORMADO.";
                spl8 += " <COD_USUARIO = ";
                var spl9 = SPVG017W.LK_VG017_E_COD_USUARIO.GetMoveValues();
                spl9 += ">";
                var results10 = spl8 + spl9;
                _.Move(results10, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -439- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -440- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -441- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -443- END-IF */
            }


            /*" -444- IF LK-VG017-E-NOM-PROGRAMA = SPACES */

            if (SPVG017W.LK_VG017_E_NOM_PROGRAMA.IsEmpty())
            {

                /*" -445- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -449- STRING WS-SECTION ' - NOME DO PROGRAMA NAO INFORMADO.' ' <NOM_PROGRAMA = ' LK-VG017-E-NOM-PROGRAMA '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl10 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl10 += " - NOME DO PROGRAMA NAO INFORMADO.";
                spl10 += " <NOM_PROGRAMA = ";
                var spl11 = SPVG017W.LK_VG017_E_NOM_PROGRAMA.GetMoveValues();
                spl11 += ">";
                var results12 = spl10 + spl11;
                _.Move(results12, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -450- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -451- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -452- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -454- END-IF */
            }


            /*" -454- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0100_99_EXIT*/

        [StopWatch]
        /*" P0101-VALIDAR-LINKAGE-01-SECTION */
        private void P0101_VALIDAR_LINKAGE_01_SECTION()
        {
            /*" -464- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0101_00_START */

            P0101_00_START();

        }

        [StopWatch]
        /*" P0101-00-START */
        private void P0101_00_START(bool isPerform = false)
        {
            /*" -467- MOVE 'P0101' TO WS-SECTION. */
            _.Move("P0101", WORK.WS_ERRO.WS_SECTION);

            /*" -468- IF LK-VG017-E-TRACE = 'S' */

            if (SPVG017W.LK_VG017_E_TRACE == "S")
            {

                /*" -469- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -470- END-IF */
            }


            /*" -470- PERFORM P0101-05-INICIO. */

            P0101_05_INICIO(true);

        }

        [StopWatch]
        /*" P0101-05-INICIO */
        private void P0101_05_INICIO(bool isPerform = false)
        {
            /*" -476- IF LK-VG017-E-NUM-PROPOSTA = 0 AND LK-VG017-E-NUM-CERTIFICADO = 0 */

            if (SPVG017W.LK_VG017_E_NUM_PROPOSTA == 0 && SPVG017W.LK_VG017_E_NUM_CERTIFICADO == 0)
            {

                /*" -477- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -478- MOVE LK-VG017-E-NUM-PROPOSTA TO WS-DECIMAL(01) */
                _.Move(SPVG017W.LK_VG017_E_NUM_PROPOSTA, WORK.WS_EDIT.WS_DECIMAL[01]);

                /*" -479- MOVE LK-VG017-E-NUM-CERTIFICADO TO WS-DECIMAL(02) */
                _.Move(SPVG017W.LK_VG017_E_NUM_CERTIFICADO, WORK.WS_EDIT.WS_DECIMAL[02]);

                /*" -484- STRING WS-SECTION ' - NUMERO DA PROPOSTA/CERTIFICADO NAO INFORMADO.' ' <NUM_PROPOSTA = ' WS-DECIMAL(01) '>' ' <NUM_CERTIFICADO = ' WS-DECIMAL(02) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl12 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl12 += " - NUMERO DA PROPOSTA/CERTIFICADO NAO INFORMADO.";
                spl12 += " <NUM_PROPOSTA = ";
                var spl13 = WORK.WS_EDIT.WS_DECIMAL[01].GetMoveValues();
                spl13 += ">";
                spl13 += " <NUM_CERTIFICADO = ";
                var spl14 = WORK.WS_EDIT.WS_DECIMAL[02].GetMoveValues();
                spl14 += ">";
                var results15 = spl12 + spl13 + spl14;
                _.Move(results15, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -485- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -486- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -487- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -489- END-IF */
            }


            /*" -489- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0101_99_EXIT*/

        [StopWatch]
        /*" P0102-VALIDAR-LINKAGE-02-SECTION */
        private void P0102_VALIDAR_LINKAGE_02_SECTION()
        {
            /*" -499- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0102_00_START */

            P0102_00_START();

        }

        [StopWatch]
        /*" P0102-00-START */
        private void P0102_00_START(bool isPerform = false)
        {
            /*" -502- MOVE 'P0102' TO WS-SECTION. */
            _.Move("P0102", WORK.WS_ERRO.WS_SECTION);

            /*" -503- IF LK-VG017-E-TRACE = 'S' */

            if (SPVG017W.LK_VG017_E_TRACE == "S")
            {

                /*" -504- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -505- END-IF */
            }


            /*" -505- PERFORM P0102-05-INICIO. */

            P0102_05_INICIO(true);

        }

        [StopWatch]
        /*" P0102-05-INICIO */
        private void P0102_05_INICIO(bool isPerform = false)
        {
            /*" -510- IF LK-VG017-E-NUM-CPF-CNPJ = 0 */

            if (SPVG017W.LK_VG017_E_NUM_CPF_CNPJ == 0)
            {

                /*" -511- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -512- MOVE LK-VG017-E-NUM-CPF-CNPJ TO WS-DECIMAL(01) */
                _.Move(SPVG017W.LK_VG017_E_NUM_CPF_CNPJ, WORK.WS_EDIT.WS_DECIMAL[01]);

                /*" -516- STRING WS-SECTION ' - NUMERO DA CPF/CNPJ NAO INFORMADO.' ' <NUM_CPF_CNPJ = ' WS-DECIMAL(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl15 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl15 += " - NUMERO DA CPF/CNPJ NAO INFORMADO.";
                spl15 += " <NUM_CPF_CNPJ = ";
                var spl16 = WORK.WS_EDIT.WS_DECIMAL[01].GetMoveValues();
                spl16 += ">";
                var results17 = spl15 + spl16;
                _.Move(results17, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -517- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -518- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -519- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -521- END-IF */
            }


            /*" -522- IF LK-VG017-E-NUM-PROPOSTA = 0 */

            if (SPVG017W.LK_VG017_E_NUM_PROPOSTA == 0)
            {

                /*" -523- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -524- MOVE LK-VG017-E-NUM-PROPOSTA TO WS-BIGINT(01) */
                _.Move(SPVG017W.LK_VG017_E_NUM_PROPOSTA, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -528- STRING WS-SECTION ' - NUMERO DA PROPOSTA NAO INFORMADO.' ' <NUM_PROPOSTA = ' WS-BIGINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl17 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl17 += " - NUMERO DA PROPOSTA NAO INFORMADO.";
                spl17 += " <NUM_PROPOSTA = ";
                var spl18 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                spl18 += ">";
                var results19 = spl17 + spl18;
                _.Move(results19, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -529- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -530- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -531- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -534- END-IF */
            }


            /*" -535- IF LK-VG017-E-SEQ-PRODUTO-DPS = 0 */

            if (SPVG017W.LK_VG017_E_SEQ_PRODUTO_DPS == 0)
            {

                /*" -536- MOVE 1 TO LK-VG017-E-SEQ-PRODUTO-DPS */
                _.Move(1, SPVG017W.LK_VG017_E_SEQ_PRODUTO_DPS);

                /*" -540- STRING WS-SECTION ' - NUMERO DA PROPOSTA NAO INFORMADO.' ' <NUM_PROPOSTA = ' WS-DECIMAL(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl19 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl19 += " - NUMERO DA PROPOSTA NAO INFORMADO.";
                spl19 += " <NUM_PROPOSTA = ";
                var spl20 = WORK.WS_EDIT.WS_DECIMAL[01].GetMoveValues();
                spl20 += ">";
                var results21 = spl19 + spl20;
                _.Move(results21, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -541- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -542- ELSE */
            }
            else
            {


                /*" -543- PERFORM P0114-VALIDAR-SEQ-PRODUTO */

                P0114_VALIDAR_SEQ_PRODUTO_SECTION();

                /*" -545- END-IF */
            }


            /*" -546- IF LK-VG017-E-IND-TP-PESSOA = SPACES */

            if (SPVG017W.LK_VG017_E_IND_TP_PESSOA.IsEmpty())
            {

                /*" -547- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -551- STRING WS-SECTION ' - TIPO DE PESSOA NAO INFORMADO.' ' <IND_TP_PESSOA = ' LK-VG017-E-IND-TP-PESSOA '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl21 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl21 += " - TIPO DE PESSOA NAO INFORMADO.";
                spl21 += " <IND_TP_PESSOA = ";
                var spl22 = SPVG017W.LK_VG017_E_IND_TP_PESSOA.GetMoveValues();
                spl22 += ">";
                var results23 = spl21 + spl22;
                _.Move(results23, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -552- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -553- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -554- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -556- END-IF */
            }


            /*" -557- IF LK-VG017-E-IND-TP-PESSOA NOT = 'F' AND 'J' */

            if (!SPVG017W.LK_VG017_E_IND_TP_PESSOA.In("F", "J"))
            {

                /*" -558- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -562- STRING WS-SECTION ' - TIPO DE PESSOA INVALIDO.' ' <IND_TP_PESSOA = ' LK-VG017-E-IND-TP-PESSOA '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl23 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl23 += " - TIPO DE PESSOA INVALIDO.";
                spl23 += " <IND_TP_PESSOA = ";
                var spl24 = SPVG017W.LK_VG017_E_IND_TP_PESSOA.GetMoveValues();
                spl24 += ">";
                var results25 = spl23 + spl24;
                _.Move(results25, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -563- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -564- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -565- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -567- END-IF */
            }


            /*" -568- IF LK-VG017-E-IND-TP-SEGURADO = SPACES */

            if (SPVG017W.LK_VG017_E_IND_TP_SEGURADO.IsEmpty())
            {

                /*" -569- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -573- STRING WS-SECTION ' - TIPO DE SEGURADO NAO INFORMADO.' ' <IND_TP_SEGURADO = ' LK-VG017-E-IND-TP-SEGURADO '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl25 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl25 += " - TIPO DE SEGURADO NAO INFORMADO.";
                spl25 += " <IND_TP_SEGURADO = ";
                var spl26 = SPVG017W.LK_VG017_E_IND_TP_SEGURADO.GetMoveValues();
                spl26 += ">";
                var results27 = spl25 + spl26;
                _.Move(results27, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -574- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -575- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -576- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -578- END-IF */
            }


            /*" -579- IF LK-VG017-E-NUM-CERTIFICADO > ZEROS */

            if (SPVG017W.LK_VG017_E_NUM_CERTIFICADO > 00)
            {

                /*" -580- PERFORM P0115-VALIDAR-CERTIFICADO */

                P0115_VALIDAR_CERTIFICADO_SECTION();

                /*" -581- MOVE ZEROS TO WH-I-NUM-CERTIFICADO */
                _.Move(0, WH_AUXILIAR.WH_I_NUM_CERTIFICADO);

                /*" -582- ELSE */
            }
            else
            {


                /*" -583- MOVE -1 TO WH-I-NUM-CERTIFICADO */
                _.Move(-1, WH_AUXILIAR.WH_I_NUM_CERTIFICADO);

                /*" -585- END-IF */
            }


            /*" -586- IF LK-VG017-E-IND-TP-SEGURADO NOT = 'S' AND 'C' */

            if (!SPVG017W.LK_VG017_E_IND_TP_SEGURADO.In("S", "C"))
            {

                /*" -587- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -591- STRING WS-SECTION ' - TIPO DE SEGURADO INVALIDO.' ' <IND_TP_SEGURADO = ' LK-VG017-E-IND-TP-SEGURADO '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl27 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl27 += " - TIPO DE SEGURADO INVALIDO.";
                spl27 += " <IND_TP_SEGURADO = ";
                var spl28 = SPVG017W.LK_VG017_E_IND_TP_SEGURADO.GetMoveValues();
                spl28 += ">";
                var results29 = spl27 + spl28;
                _.Move(results29, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -592- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -593- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -594- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -596- END-IF */
            }


            /*" -598- IF LK-VG017-E-STA-PROPOSTA-SIAS = 0 AND LK-VG017-E-STA-PROPOSTA-MOTOR = SPACES */

            if (SPVG017W.LK_VG017_E_STA_PROPOSTA_SIAS == 0 && SPVG017W.LK_VG017_E_STA_PROPOSTA_MOTOR.IsEmpty())
            {

                /*" -599- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -600- MOVE LK-VG017-E-STA-PROPOSTA-SIAS TO WS-SMALLINT(01) */
                _.Move(SPVG017W.LK_VG017_E_STA_PROPOSTA_SIAS, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -606- STRING WS-SECTION ' - STATUS DA PROPOSTA NAO INFORMADO.' ' <STA_PROPOSTA_SIAS = ' WS-SMALLINT(01) '>' ' <STA_PROPOSTA_MTR  = ' LK-VG017-E-STA-PROPOSTA-MOTOR '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl29 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl29 += " - STATUS DA PROPOSTA NAO INFORMADO.";
                spl29 += " <STA_PROPOSTA_SIAS = ";
                var spl30 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl30 += ">";
                spl30 += " <STA_PROPOSTA_MTR = ";
                var spl31 = SPVG017W.LK_VG017_E_STA_PROPOSTA_MOTOR.GetMoveValues();
                spl31 += ">";
                var results32 = spl29 + spl30 + spl31;
                _.Move(results32, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -607- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -608- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -609- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -611- END-IF */
            }


            /*" -612- IF LK-VG017-E-STA-PROPOSTA-SIAS NOT = 0 */

            if (SPVG017W.LK_VG017_E_STA_PROPOSTA_SIAS != 0)
            {

                /*" -613- PERFORM P0112-VALIDAR-STATUS-SIAS */

                P0112_VALIDAR_STATUS_SIAS_SECTION();

                /*" -615- END-IF */
            }


            /*" -617- IF LK-VG017-E-STA-PROPOSTA-MOTOR NOT = SPACES AND LK-VG017-E-STA-PROPOSTA-SIAS = 0 */

            if (!SPVG017W.LK_VG017_E_STA_PROPOSTA_MOTOR.IsEmpty() && SPVG017W.LK_VG017_E_STA_PROPOSTA_SIAS == 0)
            {

                /*" -618- PERFORM P0113-DE-PARA-STATUS-MOTOR */

                P0113_DE_PARA_STATUS_MOTOR_SECTION();

                /*" -619- END-IF */
            }


            /*" -619- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0102_99_EXIT*/

        [StopWatch]
        /*" P0103-VALIDAR-LINKAGE-03-SECTION */
        private void P0103_VALIDAR_LINKAGE_03_SECTION()
        {
            /*" -629- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0103_00_START */

            P0103_00_START();

        }

        [StopWatch]
        /*" P0103-00-START */
        private void P0103_00_START(bool isPerform = false)
        {
            /*" -632- MOVE 'P0103' TO WS-SECTION. */
            _.Move("P0103", WORK.WS_ERRO.WS_SECTION);

            /*" -633- IF LK-VG017-E-TRACE = 'S' */

            if (SPVG017W.LK_VG017_E_TRACE == "S")
            {

                /*" -634- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -635- END-IF */
            }


            /*" -635- PERFORM P0103-05-INICIO. */

            P0103_05_INICIO(true);

        }

        [StopWatch]
        /*" P0103-05-INICIO */
        private void P0103_05_INICIO(bool isPerform = false)
        {
            /*" -640- IF LK-VG017-E-NUM-CPF-CNPJ = 0 */

            if (SPVG017W.LK_VG017_E_NUM_CPF_CNPJ == 0)
            {

                /*" -641- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -642- MOVE LK-VG017-E-NUM-CPF-CNPJ TO WS-DECIMAL(01) */
                _.Move(SPVG017W.LK_VG017_E_NUM_CPF_CNPJ, WORK.WS_EDIT.WS_DECIMAL[01]);

                /*" -646- STRING WS-SECTION ' - NUMERO DA CPF/CNPJ NAO INFORMADO.' ' <NUM_CPF_CNPJ = ' WS-DECIMAL(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl32 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl32 += " - NUMERO DA CPF/CNPJ NAO INFORMADO.";
                spl32 += " <NUM_CPF_CNPJ = ";
                var spl33 = WORK.WS_EDIT.WS_DECIMAL[01].GetMoveValues();
                spl33 += ">";
                var results34 = spl32 + spl33;
                _.Move(results34, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -647- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -648- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -649- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -651- END-IF */
            }


            /*" -652- IF LK-VG017-E-NUM-PROPOSTA = 0 */

            if (SPVG017W.LK_VG017_E_NUM_PROPOSTA == 0)
            {

                /*" -653- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -654- MOVE LK-VG017-E-NUM-PROPOSTA TO WS-BIGINT(01) */
                _.Move(SPVG017W.LK_VG017_E_NUM_PROPOSTA, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -658- STRING WS-SECTION ' - NUMERO DA PROPOSTA NAO INFORMADO.' ' <NUM_PROPOSTA = ' WS-BIGINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl34 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl34 += " - NUMERO DA PROPOSTA NAO INFORMADO.";
                spl34 += " <NUM_PROPOSTA = ";
                var spl35 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                spl35 += ">";
                var results36 = spl34 + spl35;
                _.Move(results36, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -659- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -660- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -661- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -664- END-IF */
            }


            /*" -665- IF LK-VG017-E-SEQ-PRODUTO-DPS = 0 */

            if (SPVG017W.LK_VG017_E_SEQ_PRODUTO_DPS == 0)
            {

                /*" -666- MOVE 1 TO LK-VG017-E-SEQ-PRODUTO-DPS */
                _.Move(1, SPVG017W.LK_VG017_E_SEQ_PRODUTO_DPS);

                /*" -670- STRING WS-SECTION ' - NUMERO DA PROPOSTA NAO INFORMADO.' ' <NUM_PROPOSTA = ' WS-DECIMAL(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl36 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl36 += " - NUMERO DA PROPOSTA NAO INFORMADO.";
                spl36 += " <NUM_PROPOSTA = ";
                var spl37 = WORK.WS_EDIT.WS_DECIMAL[01].GetMoveValues();
                spl37 += ">";
                var results38 = spl36 + spl37;
                _.Move(results38, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -671- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -672- ELSE */
            }
            else
            {


                /*" -673- PERFORM P0114-VALIDAR-SEQ-PRODUTO */

                P0114_VALIDAR_SEQ_PRODUTO_SECTION();

                /*" -675- END-IF */
            }


            /*" -676- IF LK-VG017-E-IND-TP-PESSOA = SPACES */

            if (SPVG017W.LK_VG017_E_IND_TP_PESSOA.IsEmpty())
            {

                /*" -677- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -681- STRING WS-SECTION ' - TIPO DE PESSOA NAO INFORMADO.' ' <IND_TP_PESSOA = ' LK-VG017-E-IND-TP-PESSOA '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl38 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl38 += " - TIPO DE PESSOA NAO INFORMADO.";
                spl38 += " <IND_TP_PESSOA = ";
                var spl39 = SPVG017W.LK_VG017_E_IND_TP_PESSOA.GetMoveValues();
                spl39 += ">";
                var results40 = spl38 + spl39;
                _.Move(results40, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -682- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -683- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -684- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -686- END-IF */
            }


            /*" -687- IF LK-VG017-E-IND-TP-PESSOA NOT = 'F' AND 'J' */

            if (!SPVG017W.LK_VG017_E_IND_TP_PESSOA.In("F", "J"))
            {

                /*" -688- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -692- STRING WS-SECTION ' - TIPO DE PESSOA INVALIDO.' ' <IND_TP_PESSOA = ' LK-VG017-E-IND-TP-PESSOA '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl40 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl40 += " - TIPO DE PESSOA INVALIDO.";
                spl40 += " <IND_TP_PESSOA = ";
                var spl41 = SPVG017W.LK_VG017_E_IND_TP_PESSOA.GetMoveValues();
                spl41 += ">";
                var results42 = spl40 + spl41;
                _.Move(results42, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -693- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -694- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -695- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -697- END-IF */
            }


            /*" -698- IF LK-VG017-E-IND-TP-SEGURADO = SPACES */

            if (SPVG017W.LK_VG017_E_IND_TP_SEGURADO.IsEmpty())
            {

                /*" -699- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -703- STRING WS-SECTION ' - TIPO DE SEGURADO NAO INFORMADO.' ' <IND_TP_SEGURADO = ' LK-VG017-E-IND-TP-SEGURADO '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl42 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl42 += " - TIPO DE SEGURADO NAO INFORMADO.";
                spl42 += " <IND_TP_SEGURADO = ";
                var spl43 = SPVG017W.LK_VG017_E_IND_TP_SEGURADO.GetMoveValues();
                spl43 += ">";
                var results44 = spl42 + spl43;
                _.Move(results44, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -704- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -705- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -706- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -708- END-IF */
            }


            /*" -709- IF LK-VG017-E-NUM-CERTIFICADO > ZEROS */

            if (SPVG017W.LK_VG017_E_NUM_CERTIFICADO > 00)
            {

                /*" -710- PERFORM P0115-VALIDAR-CERTIFICADO */

                P0115_VALIDAR_CERTIFICADO_SECTION();

                /*" -712- END-IF */
            }


            /*" -713- IF LK-VG017-E-IND-TP-SEGURADO NOT = 'S' AND 'C' */

            if (!SPVG017W.LK_VG017_E_IND_TP_SEGURADO.In("S", "C"))
            {

                /*" -714- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -718- STRING WS-SECTION ' - TIPO DE SEGURADO INVALIDO.' ' <IND_TP_SEGURADO = ' LK-VG017-E-IND-TP-SEGURADO '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl44 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl44 += " - TIPO DE SEGURADO INVALIDO.";
                spl44 += " <IND_TP_SEGURADO = ";
                var spl45 = SPVG017W.LK_VG017_E_IND_TP_SEGURADO.GetMoveValues();
                spl45 += ">";
                var results46 = spl44 + spl45;
                _.Move(results46, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -719- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -720- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -721- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -723- END-IF */
            }


            /*" -725- IF LK-VG017-E-STA-PROPOSTA-SIAS = 0 AND LK-VG017-E-STA-PROPOSTA-MOTOR = SPACES */

            if (SPVG017W.LK_VG017_E_STA_PROPOSTA_SIAS == 0 && SPVG017W.LK_VG017_E_STA_PROPOSTA_MOTOR.IsEmpty())
            {

                /*" -726- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -727- MOVE LK-VG017-E-STA-PROPOSTA-SIAS TO WS-SMALLINT(01) */
                _.Move(SPVG017W.LK_VG017_E_STA_PROPOSTA_SIAS, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -733- STRING WS-SECTION ' - STATUS DA PROPOSTA NAO INFORMADO.' ' <STA_PROPOSTA_SIAS = ' WS-SMALLINT(01) '>' ' <STA_PROPOSTA_MTR  = ' LK-VG017-E-STA-PROPOSTA-MOTOR '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl46 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl46 += " - STATUS DA PROPOSTA NAO INFORMADO.";
                spl46 += " <STA_PROPOSTA_SIAS = ";
                var spl47 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl47 += ">";
                spl47 += " <STA_PROPOSTA_MTR = ";
                var spl48 = SPVG017W.LK_VG017_E_STA_PROPOSTA_MOTOR.GetMoveValues();
                spl48 += ">";
                var results49 = spl46 + spl47 + spl48;
                _.Move(results49, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -734- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -735- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -736- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -738- END-IF */
            }


            /*" -739- IF LK-VG017-E-STA-PROPOSTA-SIAS NOT = 0 */

            if (SPVG017W.LK_VG017_E_STA_PROPOSTA_SIAS != 0)
            {

                /*" -740- PERFORM P0112-VALIDAR-STATUS-SIAS */

                P0112_VALIDAR_STATUS_SIAS_SECTION();

                /*" -742- END-IF */
            }


            /*" -743- IF LK-VG017-E-STA-PROPOSTA-MOTOR NOT = SPACES */

            if (!SPVG017W.LK_VG017_E_STA_PROPOSTA_MOTOR.IsEmpty())
            {

                /*" -744- PERFORM P0113-DE-PARA-STATUS-MOTOR */

                P0113_DE_PARA_STATUS_MOTOR_SECTION();

                /*" -745- END-IF */
            }


            /*" -745- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0103_99_EXIT*/

        [StopWatch]
        /*" P0112-VALIDAR-STATUS-SIAS-SECTION */
        private void P0112_VALIDAR_STATUS_SIAS_SECTION()
        {
            /*" -756- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0112_00_START */

            P0112_00_START();

        }

        [StopWatch]
        /*" P0112-00-START */
        private void P0112_00_START(bool isPerform = false)
        {
            /*" -759- MOVE 'P0112' TO WS-SECTION. */
            _.Move("P0112", WORK.WS_ERRO.WS_SECTION);

            /*" -760- IF LK-VG017-E-TRACE = 'S' */

            if (SPVG017W.LK_VG017_E_TRACE == "S")
            {

                /*" -761- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -763- END-IF */
            }


            /*" -765- MOVE LK-VG017-E-STA-PROPOSTA-SIAS TO WH-STA-DPS-PROPOSTA */
            _.Move(SPVG017W.LK_VG017_E_STA_PROPOSTA_SIAS, WH_AUXILIAR.WH_STA_DPS_PROPOSTA);

            /*" -765- PERFORM P0112-05-INICIO. */

            P0112_05_INICIO(true);

        }

        [StopWatch]
        /*" P0112-05-INICIO */
        private void P0112_05_INICIO(bool isPerform = false)
        {
            /*" -775- PERFORM P0112_05_INICIO_DB_SELECT_1 */

            P0112_05_INICIO_DB_SELECT_1();

            /*" -778- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -779- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -780- MOVE WH-STA-DPS-PROPOSTA TO WS-SMALLINT(01) */
                _.Move(WH_AUXILIAR.WH_STA_DPS_PROPOSTA, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -784- STRING WS-SECTION ' - ERRO NO SELECT SEGUROS.VG_STA_DPS_PROPOSTA.' ' <STA_DPS_PROPOSTA = ' WS-SMALLINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl49 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl49 += " - ERRO NO SELECT SEGUROS.VG_STA_DPS_PROPOSTA.";
                spl49 += " <STA_DPS_PROPOSTA = ";
                var spl50 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl50 += ">";
                var results51 = spl49 + spl50;
                _.Move(results51, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -786- MOVE 'SEGUROS.VG_STA_DPS_PROPOSTA' TO WS-TABELA */
                _.Move("SEGUROS.VG_STA_DPS_PROPOSTA", WORK.WS_ERRO.WS_TABELA);

                /*" -787- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -788- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -789- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -791- END-IF */
            }


            /*" -792- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -793- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -794- MOVE WH-STA-DPS-PROPOSTA TO WS-SMALLINT(01) */
                _.Move(WH_AUXILIAR.WH_STA_DPS_PROPOSTA, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -798- STRING WS-SECTION ' - STATUS DA PROPOSTA NAO CADASTRADO.' ' <STA_DPS_PROPOSTA = ' WS-SMALLINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl51 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl51 += " - STATUS DA PROPOSTA NAO CADASTRADO.";
                spl51 += " <STA_DPS_PROPOSTA = ";
                var spl52 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl52 += ">";
                var results53 = spl51 + spl52;
                _.Move(results53, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -799- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -800- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -801- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -803- END-IF */
            }


            /*" -803- . */

        }

        [StopWatch]
        /*" P0112-05-INICIO-DB-SELECT-1 */
        public void P0112_05_INICIO_DB_SELECT_1()
        {
            /*" -775- EXEC SQL SELECT STA_DPS_PROPOSTA INTO :WH-STA-DPS-PROPOSTA FROM SEGUROS.VG_STA_DPS_PROPOSTA WHERE STA_DPS_PROPOSTA = :WH-STA-DPS-PROPOSTA WITH UR END-EXEC */

            var p0112_05_INICIO_DB_SELECT_1_Query1 = new P0112_05_INICIO_DB_SELECT_1_Query1()
            {
                WH_STA_DPS_PROPOSTA = WH_AUXILIAR.WH_STA_DPS_PROPOSTA.ToString(),
            };

            var executed_1 = P0112_05_INICIO_DB_SELECT_1_Query1.Execute(p0112_05_INICIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WH_STA_DPS_PROPOSTA, WH_AUXILIAR.WH_STA_DPS_PROPOSTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0112_99_EXIT*/

        [StopWatch]
        /*" P0113-DE-PARA-STATUS-MOTOR-SECTION */
        private void P0113_DE_PARA_STATUS_MOTOR_SECTION()
        {
            /*" -813- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0113_00_START */

            P0113_00_START();

        }

        [StopWatch]
        /*" P0113-00-START */
        private void P0113_00_START(bool isPerform = false)
        {
            /*" -816- MOVE 'P0113' TO WS-SECTION */
            _.Move("P0113", WORK.WS_ERRO.WS_SECTION);

            /*" -817- IF LK-VG017-E-TRACE = 'S' */

            if (SPVG017W.LK_VG017_E_TRACE == "S")
            {

                /*" -818- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -819- END-IF */
            }


            /*" -819- PERFORM P0113-05-INICIO. */

            P0113_05_INICIO(true);

        }

        [StopWatch]
        /*" P0113-05-INICIO */
        private void P0113_05_INICIO(bool isPerform = false)
        {
            /*" -825- EVALUATE LK-VG017-E-STA-PROPOSTA-MOTOR */
            switch (SPVG017W.LK_VG017_E_STA_PROPOSTA_MOTOR.Value.Trim())
            {

                /*" -826- WHEN 'NDS' */
                case "NDS":

                    /*" -827- MOVE 1 TO LK-VG017-E-STA-PROPOSTA-SIAS */
                    _.Move(1, SPVG017W.LK_VG017_E_STA_PROPOSTA_SIAS);

                    /*" -828- WHEN 'NDN' */
                    break;
                case "NDN":

                    /*" -829- MOVE 2 TO LK-VG017-E-STA-PROPOSTA-SIAS */
                    _.Move(2, SPVG017W.LK_VG017_E_STA_PROPOSTA_SIAS);

                    /*" -830- WHEN 'PPD' */
                    break;
                case "PPD":

                    /*" -831- MOVE 3 TO LK-VG017-E-STA-PROPOSTA-SIAS */
                    _.Move(3, SPVG017W.LK_VG017_E_STA_PROPOSTA_SIAS);

                    /*" -832- WHEN 'APD' */
                    break;
                case "APD":

                    /*" -833- MOVE 4 TO LK-VG017-E-STA-PROPOSTA-SIAS */
                    _.Move(4, SPVG017W.LK_VG017_E_STA_PROPOSTA_SIAS);

                    /*" -834- WHEN 'DAP' */
                    break;
                case "DAP":

                    /*" -835- MOVE 5 TO LK-VG017-E-STA-PROPOSTA-SIAS */
                    _.Move(5, SPVG017W.LK_VG017_E_STA_PROPOSTA_SIAS);

                    /*" -836- WHEN 'DRE' */
                    break;
                case "DRE":

                    /*" -837- MOVE 6 TO LK-VG017-E-STA-PROPOSTA-SIAS */
                    _.Move(6, SPVG017W.LK_VG017_E_STA_PROPOSTA_SIAS);

                    /*" -838- WHEN 'DIN' */
                    break;
                case "DIN":

                    /*" -839- MOVE 7 TO LK-VG017-E-STA-PROPOSTA-SIAS */
                    _.Move(7, SPVG017W.LK_VG017_E_STA_PROPOSTA_SIAS);

                    /*" -840- WHEN 'DCA' */
                    break;
                case "DCA":

                    /*" -841- MOVE 8 TO LK-VG017-E-STA-PROPOSTA-SIAS */
                    _.Move(8, SPVG017W.LK_VG017_E_STA_PROPOSTA_SIAS);

                    /*" -842- WHEN 'PMP' */
                    break;
                case "PMP":

                    /*" -843- MOVE 9 TO LK-VG017-E-STA-PROPOSTA-SIAS */
                    _.Move(9, SPVG017W.LK_VG017_E_STA_PROPOSTA_SIAS);

                    /*" -844- WHEN 'DAG' */
                    break;
                case "DAG":

                    /*" -845- MOVE 10 TO LK-VG017-E-STA-PROPOSTA-SIAS */
                    _.Move(10, SPVG017W.LK_VG017_E_STA_PROPOSTA_SIAS);

                    /*" -846- WHEN OTHER */
                    break;
                default:

                    /*" -847- MOVE 0 TO LK-VG017-E-STA-PROPOSTA-SIAS */
                    _.Move(0, SPVG017W.LK_VG017_E_STA_PROPOSTA_SIAS);

                    /*" -848- END-EVALUATE */
                    break;
            }


            /*" -848- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0113_99_EXIT*/

        [StopWatch]
        /*" P0114-VALIDAR-SEQ-PRODUTO-SECTION */
        private void P0114_VALIDAR_SEQ_PRODUTO_SECTION()
        {
            /*" -858- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0114_00_START */

            P0114_00_START();

        }

        [StopWatch]
        /*" P0114-00-START */
        private void P0114_00_START(bool isPerform = false)
        {
            /*" -861- MOVE 'P0114' TO WS-SECTION. */
            _.Move("P0114", WORK.WS_ERRO.WS_SECTION);

            /*" -862- IF LK-VG017-E-TRACE = 'S' */

            if (SPVG017W.LK_VG017_E_TRACE == "S")
            {

                /*" -863- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -865- END-IF */
            }


            /*" -867- MOVE LK-VG017-E-SEQ-PRODUTO-DPS TO VG142-SEQ-PRODUTO-DPS */
            _.Move(SPVG017W.LK_VG017_E_SEQ_PRODUTO_DPS, VG142.DCLVG_PRODUTO_REGRA_DPS.VG142_SEQ_PRODUTO_DPS);

            /*" -867- PERFORM P0114-05-INICIO. */

            P0114_05_INICIO(true);

        }

        [StopWatch]
        /*" P0114-05-INICIO */
        private void P0114_05_INICIO(bool isPerform = false)
        {
            /*" -880- PERFORM P0114_05_INICIO_DB_SELECT_1 */

            P0114_05_INICIO_DB_SELECT_1();

            /*" -883- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -884- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -885- MOVE VG142-SEQ-PRODUTO-DPS TO WS-SMALLINT(01) */
                _.Move(VG142.DCLVG_PRODUTO_REGRA_DPS.VG142_SEQ_PRODUTO_DPS, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -890- STRING WS-SECTION ' - ERRO NO SELECT SEGUROS.VG_PRODUTO_REGRA_DPS.' ' <SEQ_PRODUTO_DPS = ' WS-SMALLINT(01) '>' ' <DT-SISTEMA = ' SISTEMAS-DATA-MOV-ABERTO '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl53 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl53 += " - ERRO NO SELECT SEGUROS.VG_PRODUTO_REGRA_DPS.";
                spl53 += " <SEQ_PRODUTO_DPS = ";
                var spl54 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl54 += ">";
                spl54 += " <DT-SISTEMA = ";
                var spl55 = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.GetMoveValues();
                spl55 += ">";
                var results56 = spl53 + spl54 + spl55;
                _.Move(results56, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -892- MOVE 'SEGUROS.VG_PRODUTO_REGRA_DPS' TO WS-TABELA */
                _.Move("SEGUROS.VG_PRODUTO_REGRA_DPS", WORK.WS_ERRO.WS_TABELA);

                /*" -893- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -894- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -895- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -897- END-IF */
            }


            /*" -898- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -899- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -900- MOVE VG142-SEQ-PRODUTO-DPS TO WS-SMALLINT(01) */
                _.Move(VG142.DCLVG_PRODUTO_REGRA_DPS.VG142_SEQ_PRODUTO_DPS, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -905- STRING WS-SECTION ' - REGRA PRODUTO DPS NAO CADASTRADO.' ' <SEQ_PRODUTO_DPS = ' WS-SMALLINT(01) '>' ' <DT-SISTEMA = ' SISTEMAS-DATA-MOV-ABERTO '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl56 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl56 += " - REGRA PRODUTO DPS NAO CADASTRADO.";
                spl56 += " <SEQ_PRODUTO_DPS = ";
                var spl57 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl57 += ">";
                spl57 += " <DT-SISTEMA = ";
                var spl58 = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.GetMoveValues();
                spl58 += ">";
                var results59 = spl56 + spl57 + spl58;
                _.Move(results59, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -907- MOVE 'SEGUROS.VG_PRODUTO_REGRA_DPS' TO WS-TABELA */
                _.Move("SEGUROS.VG_PRODUTO_REGRA_DPS", WORK.WS_ERRO.WS_TABELA);

                /*" -908- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -909- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -910- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -912- END-IF */
            }


            /*" -912- . */

        }

        [StopWatch]
        /*" P0114-05-INICIO-DB-SELECT-1 */
        public void P0114_05_INICIO_DB_SELECT_1()
        {
            /*" -880- EXEC SQL SELECT VG142.COD_PRODUTO INTO :VG142-COD-PRODUTO FROM SEGUROS.VG_PRODUTO_REGRA_DPS VG142 WHERE VG142.SEQ_PRODUTO_DPS = :VG142-SEQ-PRODUTO-DPS AND DATE(:SISTEMAS-DATA-MOV-ABERTO) BETWEEN DTA_INI_VIGENCIA AND DTA_FIM_VIGENCIA WITH UR END-EXEC */

            var p0114_05_INICIO_DB_SELECT_1_Query1 = new P0114_05_INICIO_DB_SELECT_1_Query1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                VG142_SEQ_PRODUTO_DPS = VG142.DCLVG_PRODUTO_REGRA_DPS.VG142_SEQ_PRODUTO_DPS.ToString(),
            };

            var executed_1 = P0114_05_INICIO_DB_SELECT_1_Query1.Execute(p0114_05_INICIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VG142_COD_PRODUTO, VG142.DCLVG_PRODUTO_REGRA_DPS.VG142_COD_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0114_99_EXIT*/

        [StopWatch]
        /*" P0115-VALIDAR-CERTIFICADO-SECTION */
        private void P0115_VALIDAR_CERTIFICADO_SECTION()
        {
            /*" -921- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0115_00_START */

            P0115_00_START();

        }

        [StopWatch]
        /*" P0115-00-START */
        private void P0115_00_START(bool isPerform = false)
        {
            /*" -924- MOVE 'P0115' TO WS-SECTION. */
            _.Move("P0115", WORK.WS_ERRO.WS_SECTION);

            /*" -925- IF LK-VG017-E-TRACE = 'S' */

            if (SPVG017W.LK_VG017_E_TRACE == "S")
            {

                /*" -926- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -928- END-IF */
            }


            /*" -930- MOVE LK-VG017-E-NUM-CERTIFICADO TO VG143-NUM-CERTIFICADO */
            _.Move(SPVG017W.LK_VG017_E_NUM_CERTIFICADO, VG143.DCLVG_DPS_PROPOSTA.VG143_NUM_CERTIFICADO);

            /*" -930- PERFORM P0115-05-INICIO. */

            P0115_05_INICIO(true);

        }

        [StopWatch]
        /*" P0115-05-INICIO */
        private void P0115_05_INICIO(bool isPerform = false)
        {
            /*" -940- PERFORM P0115_05_INICIO_DB_SELECT_1 */

            P0115_05_INICIO_DB_SELECT_1();

            /*" -943- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -944- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -945- MOVE VG143-NUM-CERTIFICADO TO WS-BIGINT(01) */
                _.Move(VG143.DCLVG_DPS_PROPOSTA.VG143_NUM_CERTIFICADO, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -949- STRING WS-SECTION ' - ERRO NO SELECT SEGUROS.PROPOSTAS_VA.' ' <NUM_CERTIFICADO = ' WS-BIGINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl59 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl59 += " - ERRO NO SELECT SEGUROS.PROPOSTAS_VA.";
                spl59 += " <NUM_CERTIFICADO = ";
                var spl60 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                spl60 += ">";
                var results61 = spl59 + spl60;
                _.Move(results61, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -951- MOVE 'SEGUROS.PROPOSTAS_VA' TO WS-TABELA */
                _.Move("SEGUROS.PROPOSTAS_VA", WORK.WS_ERRO.WS_TABELA);

                /*" -952- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -953- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -954- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -956- END-IF */
            }


            /*" -957- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -958- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -959- MOVE VG143-NUM-CERTIFICADO TO WS-BIGINT(01) */
                _.Move(VG143.DCLVG_DPS_PROPOSTA.VG143_NUM_CERTIFICADO, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -963- STRING WS-SECTION ' - NUM_CERTIFICADO NAO CADASTRADO.' ' <NUM_CERTIFICADO = ' WS-BIGINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl61 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl61 += " - NUM_CERTIFICADO NAO CADASTRADO.";
                spl61 += " <NUM_CERTIFICADO = ";
                var spl62 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                spl62 += ">";
                var results63 = spl61 + spl62;
                _.Move(results63, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -965- MOVE 'SEGUROS.PROPOSTAS_VA' TO WS-TABELA */
                _.Move("SEGUROS.PROPOSTAS_VA", WORK.WS_ERRO.WS_TABELA);

                /*" -966- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -967- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -968- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -970- END-IF */
            }


            /*" -970- . */

        }

        [StopWatch]
        /*" P0115-05-INICIO-DB-SELECT-1 */
        public void P0115_05_INICIO_DB_SELECT_1()
        {
            /*" -940- EXEC SQL SELECT NUM_PROPOSTA_SIVPF INTO :VG143-NUM-CERTIFICADO FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_PROPOSTA_SIVPF = :VG143-NUM-CERTIFICADO WITH UR END-EXEC */

            var p0115_05_INICIO_DB_SELECT_1_Query1 = new P0115_05_INICIO_DB_SELECT_1_Query1()
            {
                VG143_NUM_CERTIFICADO = VG143.DCLVG_DPS_PROPOSTA.VG143_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = P0115_05_INICIO_DB_SELECT_1_Query1.Execute(p0115_05_INICIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VG143_NUM_CERTIFICADO, VG143.DCLVG_DPS_PROPOSTA.VG143_NUM_CERTIFICADO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0115_99_EXIT*/

        [StopWatch]
        /*" P0116-DE-PARA-STATUS-SIAS-SECTION */
        private void P0116_DE_PARA_STATUS_SIAS_SECTION()
        {
            /*" -980- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0116_00_START */

            P0116_00_START();

        }

        [StopWatch]
        /*" P0116-00-START */
        private void P0116_00_START(bool isPerform = false)
        {
            /*" -983- MOVE 'P0116' TO WS-SECTION */
            _.Move("P0116", WORK.WS_ERRO.WS_SECTION);

            /*" -984- IF LK-VG017-E-TRACE = 'S' */

            if (SPVG017W.LK_VG017_E_TRACE == "S")
            {

                /*" -985- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -987- END-IF */
            }


            /*" -987- PERFORM P0116-05-INICIO. */

            P0116_05_INICIO(true);

        }

        [StopWatch]
        /*" P0116-05-INICIO */
        private void P0116_05_INICIO(bool isPerform = false)
        {
            /*" -993- EVALUATE LK-VG017-E-STA-PROPOSTA-SIAS */
            switch (SPVG017W.LK_VG017_E_STA_PROPOSTA_SIAS.Value)
            {

                /*" -994- WHEN 1 */
                case 1:

                    /*" -995- MOVE 'NDS' TO LK-VG017-E-STA-PROPOSTA-MOTOR */
                    _.Move("NDS", SPVG017W.LK_VG017_E_STA_PROPOSTA_MOTOR);

                    /*" -996- WHEN 2 */
                    break;
                case 2:

                    /*" -997- MOVE 'NDN' TO LK-VG017-E-STA-PROPOSTA-MOTOR */
                    _.Move("NDN", SPVG017W.LK_VG017_E_STA_PROPOSTA_MOTOR);

                    /*" -998- WHEN 3 */
                    break;
                case 3:

                    /*" -999- MOVE 'PPD' TO LK-VG017-E-STA-PROPOSTA-MOTOR */
                    _.Move("PPD", SPVG017W.LK_VG017_E_STA_PROPOSTA_MOTOR);

                    /*" -1000- WHEN 4 */
                    break;
                case 4:

                    /*" -1001- MOVE 'APD' TO LK-VG017-E-STA-PROPOSTA-MOTOR */
                    _.Move("APD", SPVG017W.LK_VG017_E_STA_PROPOSTA_MOTOR);

                    /*" -1002- WHEN 5 */
                    break;
                case 5:

                    /*" -1003- MOVE 'DAP' TO LK-VG017-E-STA-PROPOSTA-MOTOR */
                    _.Move("DAP", SPVG017W.LK_VG017_E_STA_PROPOSTA_MOTOR);

                    /*" -1004- WHEN 6 */
                    break;
                case 6:

                    /*" -1005- MOVE 'DRE' TO LK-VG017-E-STA-PROPOSTA-MOTOR */
                    _.Move("DRE", SPVG017W.LK_VG017_E_STA_PROPOSTA_MOTOR);

                    /*" -1006- WHEN 7 */
                    break;
                case 7:

                    /*" -1007- MOVE 'DIN' TO LK-VG017-E-STA-PROPOSTA-MOTOR */
                    _.Move("DIN", SPVG017W.LK_VG017_E_STA_PROPOSTA_MOTOR);

                    /*" -1008- WHEN 8 */
                    break;
                case 8:

                    /*" -1009- MOVE 'DCA' TO LK-VG017-E-STA-PROPOSTA-MOTOR */
                    _.Move("DCA", SPVG017W.LK_VG017_E_STA_PROPOSTA_MOTOR);

                    /*" -1010- WHEN 9 */
                    break;
                case 9:

                    /*" -1011- MOVE 'PMP' TO LK-VG017-E-STA-PROPOSTA-MOTOR */
                    _.Move("PMP", SPVG017W.LK_VG017_E_STA_PROPOSTA_MOTOR);

                    /*" -1012- WHEN 10 */
                    break;
                case 10:

                    /*" -1013- MOVE 'DAG' TO LK-VG017-E-STA-PROPOSTA-MOTOR */
                    _.Move("DAG", SPVG017W.LK_VG017_E_STA_PROPOSTA_MOTOR);

                    /*" -1014- WHEN OTHER */
                    break;
                default:

                    /*" -1015- MOVE SPACES TO LK-VG017-E-STA-PROPOSTA-MOTOR */
                    _.Move("", SPVG017W.LK_VG017_E_STA_PROPOSTA_MOTOR);

                    /*" -1016- END-EVALUATE */
                    break;
            }


            /*" -1016- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0116_99_EXIT*/

        [StopWatch]
        /*" P0130-PESQUISAR-DPS-SECTION */
        private void P0130_PESQUISAR_DPS_SECTION()
        {
            /*" -1029- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0130_00_START */

            P0130_00_START();

        }

        [StopWatch]
        /*" P0130-00-START */
        private void P0130_00_START(bool isPerform = false)
        {
            /*" -1032- MOVE 'P0130' TO WS-SECTION */
            _.Move("P0130", WORK.WS_ERRO.WS_SECTION);

            /*" -1033- IF LK-VG017-E-TRACE = 'S' */

            if (SPVG017W.LK_VG017_E_TRACE == "S")
            {

                /*" -1034- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -1035- END-IF */
            }


            /*" -1037- . */

            /*" -1039- MOVE LK-VG017-E-NUM-PROPOSTA TO VG143-NUM-PROPOSTA */
            _.Move(SPVG017W.LK_VG017_E_NUM_PROPOSTA, VG143.DCLVG_DPS_PROPOSTA.VG143_NUM_PROPOSTA);

            /*" -1040- IF LK-VG017-E-NUM-CERTIFICADO > ZEROS */

            if (SPVG017W.LK_VG017_E_NUM_CERTIFICADO > 00)
            {

                /*" -1041- MOVE LK-VG017-E-NUM-CERTIFICADO TO VG143-NUM-CERTIFICADO */
                _.Move(SPVG017W.LK_VG017_E_NUM_CERTIFICADO, VG143.DCLVG_DPS_PROPOSTA.VG143_NUM_CERTIFICADO);

                /*" -1042- ELSE */
            }
            else
            {


                /*" -1043- MOVE -9 TO VG143-NUM-CERTIFICADO */
                _.Move(-9, VG143.DCLVG_DPS_PROPOSTA.VG143_NUM_CERTIFICADO);

                /*" -1045- END-IF */
            }


            /*" -1045- PERFORM P0130-05-INICIO. */

            P0130_05_INICIO(true);

        }

        [StopWatch]
        /*" P0130-05-INICIO */
        private void P0130_05_INICIO(bool isPerform = false)
        {
            /*" -1079- PERFORM P0130_05_INICIO_DB_SELECT_1 */

            P0130_05_INICIO_DB_SELECT_1();

            /*" -1082- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -1083- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -1084- MOVE VG143-NUM-PROPOSTA TO WS-DECIMAL(01) */
                _.Move(VG143.DCLVG_DPS_PROPOSTA.VG143_NUM_PROPOSTA, WORK.WS_EDIT.WS_DECIMAL[01]);

                /*" -1085- MOVE VG143-NUM-CERTIFICADO TO WS-DECIMAL(02) */
                _.Move(VG143.DCLVG_DPS_PROPOSTA.VG143_NUM_CERTIFICADO, WORK.WS_EDIT.WS_DECIMAL[02]);

                /*" -1090- STRING WS-SECTION ' - ERRO NO SELECT SEGUROS.VG_DPS_PROPOSTA.' ' <NUM_PROPOSTA = ' WS-DECIMAL(01) '>' ' <NUM_CERTIFICADO = ' WS-DECIMAL(02) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl63 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl63 += " - ERRO NO SELECT SEGUROS.VG_DPS_PROPOSTA.";
                spl63 += " <NUM_PROPOSTA = ";
                var spl64 = WORK.WS_EDIT.WS_DECIMAL[01].GetMoveValues();
                spl64 += ">";
                spl64 += " <NUM_CERTIFICADO = ";
                var spl65 = WORK.WS_EDIT.WS_DECIMAL[02].GetMoveValues();
                spl65 += ">";
                var results66 = spl63 + spl64 + spl65;
                _.Move(results66, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -1092- MOVE 'SEGUROS.VG_DPS_PROPOSTA' TO WS-TABELA */
                _.Move("SEGUROS.VG_DPS_PROPOSTA", WORK.WS_ERRO.WS_TABELA);

                /*" -1093- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -1094- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -1095- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1097- END-IF */
            }


            /*" -1097- . */

        }

        [StopWatch]
        /*" P0130-05-INICIO-DB-SELECT-1 */
        public void P0130_05_INICIO_DB_SELECT_1()
        {
            /*" -1079- EXEC SQL SELECT VG143.NUM_PROPOSTA ,VG143.NUM_CPF_CNPJ ,VG143.SEQ_PRODUTO_DPS ,VG143.STA_DPS_PROPOSTA ,VG143.IND_TP_PESSOA ,VG143.IND_TP_SEGURADO ,VALUE(VG143.NUM_CERTIFICADO,0) ,VALUE(VG143.VLR_IS,0) ,VALUE(VG143.VLR_ACUMULO_IS,0) ,VG143.COD_USUARIO ,VG143.NOM_PROGRAMA ,VG143.DTH_CADASTRAMENTO INTO :VG143-NUM-PROPOSTA ,:VG143-NUM-CPF-CNPJ ,:VG143-SEQ-PRODUTO-DPS ,:VG143-STA-DPS-PROPOSTA ,:VG143-IND-TP-PESSOA ,:VG143-IND-TP-SEGURADO ,:VG143-NUM-CERTIFICADO ,:VG143-VLR-IS ,:VG143-VLR-ACUMULO-IS ,:VG143-COD-USUARIO ,:VG143-NOM-PROGRAMA ,:VG143-DTH-CADASTRAMENTO FROM SEGUROS.VG_DPS_PROPOSTA VG143 WHERE VG143.NUM_PROPOSTA = :VG143-NUM-PROPOSTA OR VALUE(VG143.NUM_CERTIFICADO, 1) = :VG143-NUM-CERTIFICADO WITH UR END-EXEC */

            var p0130_05_INICIO_DB_SELECT_1_Query1 = new P0130_05_INICIO_DB_SELECT_1_Query1()
            {
                VG143_NUM_CERTIFICADO = VG143.DCLVG_DPS_PROPOSTA.VG143_NUM_CERTIFICADO.ToString(),
                VG143_NUM_PROPOSTA = VG143.DCLVG_DPS_PROPOSTA.VG143_NUM_PROPOSTA.ToString(),
            };

            var executed_1 = P0130_05_INICIO_DB_SELECT_1_Query1.Execute(p0130_05_INICIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VG143_NUM_PROPOSTA, VG143.DCLVG_DPS_PROPOSTA.VG143_NUM_PROPOSTA);
                _.Move(executed_1.VG143_NUM_CPF_CNPJ, VG143.DCLVG_DPS_PROPOSTA.VG143_NUM_CPF_CNPJ);
                _.Move(executed_1.VG143_SEQ_PRODUTO_DPS, VG143.DCLVG_DPS_PROPOSTA.VG143_SEQ_PRODUTO_DPS);
                _.Move(executed_1.VG143_STA_DPS_PROPOSTA, VG143.DCLVG_DPS_PROPOSTA.VG143_STA_DPS_PROPOSTA);
                _.Move(executed_1.VG143_IND_TP_PESSOA, VG143.DCLVG_DPS_PROPOSTA.VG143_IND_TP_PESSOA);
                _.Move(executed_1.VG143_IND_TP_SEGURADO, VG143.DCLVG_DPS_PROPOSTA.VG143_IND_TP_SEGURADO);
                _.Move(executed_1.VG143_NUM_CERTIFICADO, VG143.DCLVG_DPS_PROPOSTA.VG143_NUM_CERTIFICADO);
                _.Move(executed_1.VG143_VLR_IS, VG143.DCLVG_DPS_PROPOSTA.VG143_VLR_IS);
                _.Move(executed_1.VG143_VLR_ACUMULO_IS, VG143.DCLVG_DPS_PROPOSTA.VG143_VLR_ACUMULO_IS);
                _.Move(executed_1.VG143_COD_USUARIO, VG143.DCLVG_DPS_PROPOSTA.VG143_COD_USUARIO);
                _.Move(executed_1.VG143_NOM_PROGRAMA, VG143.DCLVG_DPS_PROPOSTA.VG143_NOM_PROGRAMA);
                _.Move(executed_1.VG143_DTH_CADASTRAMENTO, VG143.DCLVG_DPS_PROPOSTA.VG143_DTH_CADASTRAMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0130_99_EXIT*/

        [StopWatch]
        /*" P0301-TRATAR-TIPO-ACAO-01-SECTION */
        private void P0301_TRATAR_TIPO_ACAO_01_SECTION()
        {
            /*" -1108- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0301_00_START */

            P0301_00_START();

        }

        [StopWatch]
        /*" P0301-00-START */
        private void P0301_00_START(bool isPerform = false)
        {
            /*" -1111- MOVE 'P0301' TO WS-SECTION */
            _.Move("P0301", WORK.WS_ERRO.WS_SECTION);

            /*" -1112- IF LK-VG017-E-TRACE = 'S' */

            if (SPVG017W.LK_VG017_E_TRACE == "S")
            {

                /*" -1113- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -1115- END-IF */
            }


            /*" -1115- PERFORM P0301-05-INICIO. */

            P0301_05_INICIO(true);

        }

        [StopWatch]
        /*" P0301-05-INICIO */
        private void P0301_05_INICIO(bool isPerform = false)
        {
            /*" -1121- PERFORM P0130-PESQUISAR-DPS */

            P0130_PESQUISAR_DPS_SECTION();

            /*" -1122- MOVE VG143-NUM-PROPOSTA TO LK-VG017-E-NUM-PROPOSTA */
            _.Move(VG143.DCLVG_DPS_PROPOSTA.VG143_NUM_PROPOSTA, SPVG017W.LK_VG017_E_NUM_PROPOSTA);

            /*" -1123- MOVE VG143-NUM-CPF-CNPJ TO LK-VG017-E-NUM-CPF-CNPJ */
            _.Move(VG143.DCLVG_DPS_PROPOSTA.VG143_NUM_CPF_CNPJ, SPVG017W.LK_VG017_E_NUM_CPF_CNPJ);

            /*" -1124- MOVE VG143-SEQ-PRODUTO-DPS TO LK-VG017-E-SEQ-PRODUTO-DPS */
            _.Move(VG143.DCLVG_DPS_PROPOSTA.VG143_SEQ_PRODUTO_DPS, SPVG017W.LK_VG017_E_SEQ_PRODUTO_DPS);

            /*" -1125- MOVE VG143-STA-DPS-PROPOSTA TO LK-VG017-E-STA-PROPOSTA-SIAS */
            _.Move(VG143.DCLVG_DPS_PROPOSTA.VG143_STA_DPS_PROPOSTA, SPVG017W.LK_VG017_E_STA_PROPOSTA_SIAS);

            /*" -1126- MOVE VG143-IND-TP-PESSOA TO LK-VG017-E-IND-TP-PESSOA */
            _.Move(VG143.DCLVG_DPS_PROPOSTA.VG143_IND_TP_PESSOA, SPVG017W.LK_VG017_E_IND_TP_PESSOA);

            /*" -1127- MOVE VG143-IND-TP-SEGURADO TO LK-VG017-E-IND-TP-SEGURADO */
            _.Move(VG143.DCLVG_DPS_PROPOSTA.VG143_IND_TP_SEGURADO, SPVG017W.LK_VG017_E_IND_TP_SEGURADO);

            /*" -1128- MOVE VG143-NUM-CERTIFICADO TO LK-VG017-E-NUM-CERTIFICADO */
            _.Move(VG143.DCLVG_DPS_PROPOSTA.VG143_NUM_CERTIFICADO, SPVG017W.LK_VG017_E_NUM_CERTIFICADO);

            /*" -1129- MOVE VG143-VLR-IS TO LK-VG017-E-VLR-IS */
            _.Move(VG143.DCLVG_DPS_PROPOSTA.VG143_VLR_IS, SPVG017W.LK_VG017_E_VLR_IS);

            /*" -1130- MOVE VG143-VLR-ACUMULO-IS TO LK-VG017-E-VLR-ACUMULADO-IS */
            _.Move(VG143.DCLVG_DPS_PROPOSTA.VG143_VLR_ACUMULO_IS, SPVG017W.LK_VG017_E_VLR_ACUMULADO_IS);

            /*" -1131- MOVE VG143-COD-USUARIO TO LK-VG017-E-COD-USUARIO */
            _.Move(VG143.DCLVG_DPS_PROPOSTA.VG143_COD_USUARIO, SPVG017W.LK_VG017_E_COD_USUARIO);

            /*" -1132- MOVE VG143-NOM-PROGRAMA TO LK-VG017-E-NOM-PROGRAMA */
            _.Move(VG143.DCLVG_DPS_PROPOSTA.VG143_NOM_PROGRAMA, SPVG017W.LK_VG017_E_NOM_PROGRAMA);

            /*" -1133- MOVE VG143-DTH-CADASTRAMENTO TO LK-VG017-E-DTH-CONSULTA-DPS */
            _.Move(VG143.DCLVG_DPS_PROPOSTA.VG143_DTH_CADASTRAMENTO, SPVG017W.LK_VG017_E_DTH_CONSULTA_DPS);

            /*" -1135- MOVE ZEROS TO LK-VG017-E-NUM-PROTOCOLO */
            _.Move(0, SPVG017W.LK_VG017_E_NUM_PROTOCOLO);

            /*" -1136- PERFORM P0116-DE-PARA-STATUS-SIAS */

            P0116_DE_PARA_STATUS_SIAS_SECTION();

            /*" -1136- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0301_99_EXIT*/

        [StopWatch]
        /*" P0302-TRATAR-TIPO-ACAO-02-SECTION */
        private void P0302_TRATAR_TIPO_ACAO_02_SECTION()
        {
            /*" -1147- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0302_00_START */

            P0302_00_START();

        }

        [StopWatch]
        /*" P0302-00-START */
        private void P0302_00_START(bool isPerform = false)
        {
            /*" -1150- MOVE 'P0302' TO WS-SECTION */
            _.Move("P0302", WORK.WS_ERRO.WS_SECTION);

            /*" -1150- PERFORM P0302-05-INICIO. */

            P0302_05_INICIO(true);

        }

        [StopWatch]
        /*" P0302-05-INICIO */
        private void P0302_05_INICIO(bool isPerform = false)
        {
            /*" -1156- PERFORM P0851-BUSCAR-TIMESTAMP */

            P0851_BUSCAR_TIMESTAMP_SECTION();

            /*" -1158- PERFORM P0130-PESQUISAR-DPS */

            P0130_PESQUISAR_DPS_SECTION();

            /*" -1159- MOVE LK-VG017-E-NUM-PROPOSTA TO VG143-NUM-PROPOSTA */
            _.Move(SPVG017W.LK_VG017_E_NUM_PROPOSTA, VG143.DCLVG_DPS_PROPOSTA.VG143_NUM_PROPOSTA);

            /*" -1160- MOVE LK-VG017-E-NUM-CPF-CNPJ TO VG143-NUM-CPF-CNPJ */
            _.Move(SPVG017W.LK_VG017_E_NUM_CPF_CNPJ, VG143.DCLVG_DPS_PROPOSTA.VG143_NUM_CPF_CNPJ);

            /*" -1161- MOVE LK-VG017-E-SEQ-PRODUTO-DPS TO VG143-SEQ-PRODUTO-DPS */
            _.Move(SPVG017W.LK_VG017_E_SEQ_PRODUTO_DPS, VG143.DCLVG_DPS_PROPOSTA.VG143_SEQ_PRODUTO_DPS);

            /*" -1162- MOVE LK-VG017-E-STA-PROPOSTA-SIAS TO VG143-STA-DPS-PROPOSTA */
            _.Move(SPVG017W.LK_VG017_E_STA_PROPOSTA_SIAS, VG143.DCLVG_DPS_PROPOSTA.VG143_STA_DPS_PROPOSTA);

            /*" -1163- MOVE LK-VG017-E-IND-TP-PESSOA TO VG143-IND-TP-PESSOA */
            _.Move(SPVG017W.LK_VG017_E_IND_TP_PESSOA, VG143.DCLVG_DPS_PROPOSTA.VG143_IND_TP_PESSOA);

            /*" -1164- MOVE LK-VG017-E-IND-TP-SEGURADO TO VG143-IND-TP-SEGURADO */
            _.Move(SPVG017W.LK_VG017_E_IND_TP_SEGURADO, VG143.DCLVG_DPS_PROPOSTA.VG143_IND_TP_SEGURADO);

            /*" -1165- MOVE LK-VG017-E-NUM-CERTIFICADO TO VG143-NUM-CERTIFICADO */
            _.Move(SPVG017W.LK_VG017_E_NUM_CERTIFICADO, VG143.DCLVG_DPS_PROPOSTA.VG143_NUM_CERTIFICADO);

            /*" -1166- MOVE LK-VG017-E-VLR-IS TO VG143-VLR-IS */
            _.Move(SPVG017W.LK_VG017_E_VLR_IS, VG143.DCLVG_DPS_PROPOSTA.VG143_VLR_IS);

            /*" -1167- MOVE LK-VG017-E-VLR-ACUMULADO-IS TO VG143-VLR-ACUMULO-IS */
            _.Move(SPVG017W.LK_VG017_E_VLR_ACUMULADO_IS, VG143.DCLVG_DPS_PROPOSTA.VG143_VLR_ACUMULO_IS);

            /*" -1168- MOVE LK-VG017-E-COD-USUARIO TO VG143-COD-USUARIO */
            _.Move(SPVG017W.LK_VG017_E_COD_USUARIO, VG143.DCLVG_DPS_PROPOSTA.VG143_COD_USUARIO);

            /*" -1169- MOVE LK-VG017-E-NOM-PROGRAMA TO VG143-NOM-PROGRAMA */
            _.Move(SPVG017W.LK_VG017_E_NOM_PROGRAMA, VG143.DCLVG_DPS_PROPOSTA.VG143_NOM_PROGRAMA);

            /*" -1171- MOVE WH-CURRENT-TIMESTAMP TO VG143-DTH-CADASTRAMENTO */
            _.Move(WH_AUXILIAR.WH_CURRENT_TIMESTAMP, VG143.DCLVG_DPS_PROPOSTA.VG143_DTH_CADASTRAMENTO);

            /*" -1172- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1173- PERFORM P0822-ATUALIZAR-VG143 */

                P0822_ATUALIZAR_VG143_SECTION();

                /*" -1174- ELSE */
            }
            else
            {


                /*" -1175- PERFORM P0820-INSERIR-VG143 */

                P0820_INSERIR_VG143_SECTION();

                /*" -1177- END-IF */
            }


            /*" -1178- PERFORM P0821-INSERIR-VG144 */

            P0821_INSERIR_VG144_SECTION();

            /*" -1178- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0302_99_EXIT*/

        [StopWatch]
        /*" P0303-TRATAR-TIPO-ACAO-03-SECTION */
        private void P0303_TRATAR_TIPO_ACAO_03_SECTION()
        {
            /*" -1189- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0303_00_START */

            P0303_00_START();

        }

        [StopWatch]
        /*" P0303-00-START */
        private void P0303_00_START(bool isPerform = false)
        {
            /*" -1192- MOVE 'P0303' TO WS-SECTION */
            _.Move("P0303", WORK.WS_ERRO.WS_SECTION);

            /*" -1193- IF LK-VG017-E-TRACE = 'S' */

            if (SPVG017W.LK_VG017_E_TRACE == "S")
            {

                /*" -1194- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -1195- END-IF */
            }


            /*" -1195- PERFORM P0303-05-INICIO. */

            P0303_05_INICIO(true);

        }

        [StopWatch]
        /*" P0303-05-INICIO */
        private void P0303_05_INICIO(bool isPerform = false)
        {
            /*" -1200- MOVE LK-VG017-E-NUM-PROPOSTA TO VG143-NUM-PROPOSTA */
            _.Move(SPVG017W.LK_VG017_E_NUM_PROPOSTA, VG143.DCLVG_DPS_PROPOSTA.VG143_NUM_PROPOSTA);

            /*" -1201- MOVE LK-VG017-E-NUM-CPF-CNPJ TO VG143-NUM-CPF-CNPJ */
            _.Move(SPVG017W.LK_VG017_E_NUM_CPF_CNPJ, VG143.DCLVG_DPS_PROPOSTA.VG143_NUM_CPF_CNPJ);

            /*" -1202- MOVE LK-VG017-E-SEQ-PRODUTO-DPS TO VG143-SEQ-PRODUTO-DPS */
            _.Move(SPVG017W.LK_VG017_E_SEQ_PRODUTO_DPS, VG143.DCLVG_DPS_PROPOSTA.VG143_SEQ_PRODUTO_DPS);

            /*" -1203- MOVE LK-VG017-E-STA-PROPOSTA-SIAS TO VG143-STA-DPS-PROPOSTA */
            _.Move(SPVG017W.LK_VG017_E_STA_PROPOSTA_SIAS, VG143.DCLVG_DPS_PROPOSTA.VG143_STA_DPS_PROPOSTA);

            /*" -1204- MOVE LK-VG017-E-IND-TP-PESSOA TO VG143-IND-TP-PESSOA */
            _.Move(SPVG017W.LK_VG017_E_IND_TP_PESSOA, VG143.DCLVG_DPS_PROPOSTA.VG143_IND_TP_PESSOA);

            /*" -1205- MOVE LK-VG017-E-IND-TP-SEGURADO TO VG143-IND-TP-SEGURADO */
            _.Move(SPVG017W.LK_VG017_E_IND_TP_SEGURADO, VG143.DCLVG_DPS_PROPOSTA.VG143_IND_TP_SEGURADO);

            /*" -1206- MOVE LK-VG017-E-NUM-CERTIFICADO TO VG143-NUM-CERTIFICADO */
            _.Move(SPVG017W.LK_VG017_E_NUM_CERTIFICADO, VG143.DCLVG_DPS_PROPOSTA.VG143_NUM_CERTIFICADO);

            /*" -1207- MOVE LK-VG017-E-VLR-IS TO VG143-VLR-IS */
            _.Move(SPVG017W.LK_VG017_E_VLR_IS, VG143.DCLVG_DPS_PROPOSTA.VG143_VLR_IS);

            /*" -1208- MOVE LK-VG017-E-VLR-ACUMULADO-IS TO VG143-VLR-ACUMULO-IS */
            _.Move(SPVG017W.LK_VG017_E_VLR_ACUMULADO_IS, VG143.DCLVG_DPS_PROPOSTA.VG143_VLR_ACUMULO_IS);

            /*" -1209- MOVE LK-VG017-E-COD-USUARIO TO VG143-COD-USUARIO */
            _.Move(SPVG017W.LK_VG017_E_COD_USUARIO, VG143.DCLVG_DPS_PROPOSTA.VG143_COD_USUARIO);

            /*" -1211- MOVE LK-VG017-E-NOM-PROGRAMA TO VG143-NOM-PROGRAMA */
            _.Move(SPVG017W.LK_VG017_E_NOM_PROGRAMA, VG143.DCLVG_DPS_PROPOSTA.VG143_NOM_PROGRAMA);

            /*" -1212- PERFORM P0851-BUSCAR-TIMESTAMP */

            P0851_BUSCAR_TIMESTAMP_SECTION();

            /*" -1214- MOVE WH-CURRENT-TIMESTAMP TO VG143-DTH-CADASTRAMENTO */
            _.Move(WH_AUXILIAR.WH_CURRENT_TIMESTAMP, VG143.DCLVG_DPS_PROPOSTA.VG143_DTH_CADASTRAMENTO);

            /*" -1216- PERFORM P0822-ATUALIZAR-VG143 */

            P0822_ATUALIZAR_VG143_SECTION();

            /*" -1218- PERFORM P0821-INSERIR-VG144 */

            P0821_INSERIR_VG144_SECTION();

            /*" -1218- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0303_99_EXIT*/

        [StopWatch]
        /*" P0304-TRATAR-TIPO-ACAO-04-SECTION */
        private void P0304_TRATAR_TIPO_ACAO_04_SECTION()
        {
            /*" -1228- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0304_00_START */

            P0304_00_START();

        }

        [StopWatch]
        /*" P0304-00-START */
        private void P0304_00_START(bool isPerform = false)
        {
            /*" -1231- MOVE 'P0305' TO WS-SECTION */
            _.Move("P0305", WORK.WS_ERRO.WS_SECTION);

            /*" -1232- IF LK-VG017-E-TRACE = 'S' */

            if (SPVG017W.LK_VG017_E_TRACE == "S")
            {

                /*" -1233- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -1235- END-IF */
            }


            /*" -1236- MOVE LK-VG017-E-NUM-PROPOSTA TO VG143-NUM-PROPOSTA */
            _.Move(SPVG017W.LK_VG017_E_NUM_PROPOSTA, VG143.DCLVG_DPS_PROPOSTA.VG143_NUM_PROPOSTA);

            /*" -1236- PERFORM P0304-05-INICIO. */

            P0304_05_INICIO(true);

        }

        [StopWatch]
        /*" P0304-05-INICIO */
        private void P0304_05_INICIO(bool isPerform = false)
        {
            /*" -1262- PERFORM P0304_05_INICIO_DB_DECLARE_1 */

            P0304_05_INICIO_DB_DECLARE_1();

            /*" -1264- PERFORM P0304_05_INICIO_DB_OPEN_1 */

            P0304_05_INICIO_DB_OPEN_1();

            /*" -1267- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1268- MOVE 'P0304' TO WS-SECTION */
                _.Move("P0304", WORK.WS_ERRO.WS_SECTION);

                /*" -1269- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -1270- MOVE LK-VG017-E-NUM-PROPOSTA TO WS-BIGINT(01) */
                _.Move(SPVG017W.LK_VG017_E_NUM_PROPOSTA, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -1275- STRING WS-SECTION ' - ERRO NO OPEN DO CURSOR SPBVG017_EC001' '.' '<NUM-PROPOSTA = ' WS-BIGINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl66 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl66 += " - ERRO NO OPEN DO CURSOR SPBVG017_EC001";
                spl66 += ".";
                spl66 += "<NUM-PROPOSTA = ";
                var spl67 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                spl67 += ">";
                var results68 = spl66 + spl67;
                _.Move(results68, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -1276- MOVE 'SEGUROS.VG_DPS_PROPOSTA_HIST' TO WS-TABELA */
                _.Move("SEGUROS.VG_DPS_PROPOSTA_HIST", WORK.WS_ERRO.WS_TABELA);

                /*" -1277- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -1278- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -1279- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1281- END-IF */
            }


            /*" -1281- . */

        }

        [StopWatch]
        /*" P0304-05-INICIO-DB-DECLARE-1 */
        public void P0304_05_INICIO_DB_DECLARE_1()
        {
            /*" -1262- EXEC SQL DECLARE SPBVG017_EC001 CURSOR WITH RETURN WITH HOLD FOR SELECT A.NUM_PROPOSTA ,A.NUM_CPF_CNPJ ,A.DTH_CADASTRAMENTO ,C.COD_PRODUTO ,A.STA_DPS_PROPOSTA ,B.DES_DPS_PROPOSTA ,A.IND_TP_PESSOA ,A.IND_TP_SEGURADO ,A.NUM_CERTIFICADO ,A.VLR_IS ,A.VLR_ACUMULO_IS ,A.COD_USUARIO ,A.NOM_PROGRAMA FROM SEGUROS.VG_DPS_PROPOSTA_HIST A, SEGUROS.VG_STA_DPS_PROPOSTA B, SEGUROS.VG_PRODUTO_REGRA_DPS C WHERE A.NUM_PROPOSTA = :VG143-NUM-PROPOSTA AND A.STA_DPS_PROPOSTA = B.STA_DPS_PROPOSTA AND A.SEQ_PRODUTO_DPS = C.SEQ_PRODUTO_DPS END-EXEC */
            SPBVG017_EC001 = new SPBVG017_SPBVG017_EC001(true);
            string GetQuery_SPBVG017_EC001()
            {
                var query = @$"SELECT A.NUM_PROPOSTA 
							,A.NUM_CPF_CNPJ 
							,A.DTH_CADASTRAMENTO 
							,C.COD_PRODUTO 
							,A.STA_DPS_PROPOSTA 
							,B.DES_DPS_PROPOSTA 
							,A.IND_TP_PESSOA 
							,A.IND_TP_SEGURADO 
							,A.NUM_CERTIFICADO 
							,A.VLR_IS 
							,A.VLR_ACUMULO_IS 
							,A.COD_USUARIO 
							,A.NOM_PROGRAMA 
							FROM SEGUROS.VG_DPS_PROPOSTA_HIST A
							, 
							SEGUROS.VG_STA_DPS_PROPOSTA B
							, 
							SEGUROS.VG_PRODUTO_REGRA_DPS C 
							WHERE A.NUM_PROPOSTA = '{VG143.DCLVG_DPS_PROPOSTA.VG143_NUM_PROPOSTA}' 
							AND A.STA_DPS_PROPOSTA = B.STA_DPS_PROPOSTA 
							AND A.SEQ_PRODUTO_DPS = C.SEQ_PRODUTO_DPS";

                return query;
            }
            SPBVG017_EC001.GetQueryEvent += GetQuery_SPBVG017_EC001;

        }

        [StopWatch]
        /*" P0304-05-INICIO-DB-OPEN-1 */
        public void P0304_05_INICIO_DB_OPEN_1()
        {
            /*" -1264- EXEC SQL OPEN SPBVG017_EC001 END-EXEC */

            SPBVG017_EC001.Open();
            Result = SPBVG017_EC001.AllData;

        }

        [StopWatch]
        /*" P0305-05-INICIO-DB-DECLARE-1 */
        public void P0305_05_INICIO_DB_DECLARE_1()
        {
            /*" -1325- EXEC SQL DECLARE SPBVG017_EC002 CURSOR WITH RETURN WITH HOLD FOR SELECT A.NUM_PROPOSTA ,A.NUM_CPF_CNPJ ,A.DTH_CADASTRAMENTO ,C.COD_PRODUTO ,A.STA_DPS_PROPOSTA ,B.DES_DPS_PROPOSTA ,A.IND_TP_PESSOA ,A.IND_TP_SEGURADO ,A.NUM_CERTIFICADO ,A.VLR_IS ,A.VLR_ACUMULO_IS ,A.COD_USUARIO ,A.NOM_PROGRAMA FROM SEGUROS.VG_DPS_PROPOSTA A, SEGUROS.VG_STA_DPS_PROPOSTA B, SEGUROS.VG_PRODUTO_REGRA_DPS C WHERE A.STA_DPS_PROPOSTA = 3 AND A.STA_DPS_PROPOSTA = B.STA_DPS_PROPOSTA AND A.SEQ_PRODUTO_DPS = C.SEQ_PRODUTO_DPS FETCH FIRST 100 ROWS ONLY END-EXEC */
            SPBVG017_EC002 = new SPBVG017_SPBVG017_EC002(false);
            string GetQuery_SPBVG017_EC002()
            {
                var query = @$"SELECT A.NUM_PROPOSTA 
							,A.NUM_CPF_CNPJ 
							,A.DTH_CADASTRAMENTO 
							,C.COD_PRODUTO 
							,A.STA_DPS_PROPOSTA 
							,B.DES_DPS_PROPOSTA 
							,A.IND_TP_PESSOA 
							,A.IND_TP_SEGURADO 
							,A.NUM_CERTIFICADO 
							,A.VLR_IS 
							,A.VLR_ACUMULO_IS 
							,A.COD_USUARIO 
							,A.NOM_PROGRAMA 
							FROM SEGUROS.VG_DPS_PROPOSTA A
							, 
							SEGUROS.VG_STA_DPS_PROPOSTA B
							, 
							SEGUROS.VG_PRODUTO_REGRA_DPS C 
							WHERE A.STA_DPS_PROPOSTA = 3 
							AND A.STA_DPS_PROPOSTA = B.STA_DPS_PROPOSTA 
							AND A.SEQ_PRODUTO_DPS = C.SEQ_PRODUTO_DPS 
							FETCH FIRST 100 ROWS ONLY";

                return query;
            }
            SPBVG017_EC002.GetQueryEvent += GetQuery_SPBVG017_EC002;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0304_99_EXIT*/

        [StopWatch]
        /*" P0305-TRATAR-TIPO-ACAO-05-SECTION */
        private void P0305_TRATAR_TIPO_ACAO_05_SECTION()
        {
            /*" -1292- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0305_00_START */

            P0305_00_START();

        }

        [StopWatch]
        /*" P0305-00-START */
        private void P0305_00_START(bool isPerform = false)
        {
            /*" -1295- MOVE 'P0305' TO WS-SECTION */
            _.Move("P0305", WORK.WS_ERRO.WS_SECTION);

            /*" -1296- IF LK-VG017-E-TRACE = 'S' */

            if (SPVG017W.LK_VG017_E_TRACE == "S")
            {

                /*" -1297- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -1298- END-IF */
            }


            /*" -1298- PERFORM P0305-05-INICIO. */

            P0305_05_INICIO(true);

        }

        [StopWatch]
        /*" P0305-05-INICIO */
        private void P0305_05_INICIO(bool isPerform = false)
        {
            /*" -1325- PERFORM P0305_05_INICIO_DB_DECLARE_1 */

            P0305_05_INICIO_DB_DECLARE_1();

            /*" -1327- PERFORM P0305_05_INICIO_DB_OPEN_1 */

            P0305_05_INICIO_DB_OPEN_1();

            /*" -1330- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1331- MOVE 'P0305' TO WS-SECTION */
                _.Move("P0305", WORK.WS_ERRO.WS_SECTION);

                /*" -1332- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -1333- MOVE LK-VG017-E-NUM-PROPOSTA TO WS-BIGINT(01) */
                _.Move(SPVG017W.LK_VG017_E_NUM_PROPOSTA, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -1336- STRING WS-SECTION ' - ERRO NO OPEN DO CURSOR SPBVG017_EC002.' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl68 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl68 += " - ERRO NO OPEN DO CURSOR SPBVG017_EC002.";
                _.Move(spl68, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -1337- MOVE 'SEGUROS.VG_DPS_PROPOSTA' TO WS-TABELA */
                _.Move("SEGUROS.VG_DPS_PROPOSTA", WORK.WS_ERRO.WS_TABELA);

                /*" -1338- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -1339- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -1340- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1342- END-IF */
            }


            /*" -1342- . */

        }

        [StopWatch]
        /*" P0305-05-INICIO-DB-OPEN-1 */
        public void P0305_05_INICIO_DB_OPEN_1()
        {
            /*" -1327- EXEC SQL OPEN SPBVG017_EC002 END-EXEC */

            SPBVG017_EC002.Open();
            Result = SPBVG017_EC002.AllData;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0305_99_EXIT*/

        [StopWatch]
        /*" P0820-INSERIR-VG143-SECTION */
        private void P0820_INSERIR_VG143_SECTION()
        {
            /*" -1352- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0820_00_START */

            P0820_00_START();

        }

        [StopWatch]
        /*" P0820-00-START */
        private void P0820_00_START(bool isPerform = false)
        {
            /*" -1355- MOVE 'P0820' TO WS-SECTION */
            _.Move("P0820", WORK.WS_ERRO.WS_SECTION);

            /*" -1356- IF LK-VG017-E-TRACE = 'S' */

            if (SPVG017W.LK_VG017_E_TRACE == "S")
            {

                /*" -1357- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -1358- END-IF */
            }


            /*" -1358- PERFORM P0820-05-INICIO. */

            P0820_05_INICIO(true);

        }

        [StopWatch]
        /*" P0820-05-INICIO */
        private void P0820_05_INICIO(bool isPerform = false)
        {
            /*" -1388- PERFORM P0820_05_INICIO_DB_INSERT_1 */

            P0820_05_INICIO_DB_INSERT_1();

            /*" -1391- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1392- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -1393- MOVE VG143-NUM-PROPOSTA TO WS-BIGINT(01) */
                _.Move(VG143.DCLVG_DPS_PROPOSTA.VG143_NUM_PROPOSTA, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -1394- MOVE VG143-NUM-CPF-CNPJ TO WS-BIGINT(02) */
                _.Move(VG143.DCLVG_DPS_PROPOSTA.VG143_NUM_CPF_CNPJ, WORK.WS_EDIT.WS_BIGINT[02]);

                /*" -1395- MOVE VG143-SEQ-PRODUTO-DPS TO WS-SMALLINT(01) */
                _.Move(VG143.DCLVG_DPS_PROPOSTA.VG143_SEQ_PRODUTO_DPS, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -1396- MOVE VG143-STA-DPS-PROPOSTA TO WS-SMALLINT(02) */
                _.Move(VG143.DCLVG_DPS_PROPOSTA.VG143_STA_DPS_PROPOSTA, WORK.WS_EDIT.WS_SMALLINT[02]);

                /*" -1397- MOVE VG143-NUM-CERTIFICADO TO WS-BIGINT(03) */
                _.Move(VG143.DCLVG_DPS_PROPOSTA.VG143_NUM_CERTIFICADO, WORK.WS_EDIT.WS_BIGINT[03]);

                /*" -1398- MOVE VG143-VLR-IS TO WS-DECIMAL(01) */
                _.Move(VG143.DCLVG_DPS_PROPOSTA.VG143_VLR_IS, WORK.WS_EDIT.WS_DECIMAL[01]);

                /*" -1399- MOVE VG143-VLR-ACUMULO-IS TO WS-DECIMAL(02) */
                _.Move(VG143.DCLVG_DPS_PROPOSTA.VG143_VLR_ACUMULO_IS, WORK.WS_EDIT.WS_DECIMAL[02]);

                /*" -1414- STRING WS-SECTION ' - ERRO NO INSERT SEGUROS.VG_DPS_PROPOSTA.' ' <NUM-PROPOSTA      = ' WS-BIGINT(01) '>' ' <NUM-CPF-CNPJ      = ' WS-BIGINT(02) '>' ' <SEQ-PRODUTO-DPS   = ' WS-SMALLINT(01) '>' ' <STA-DPS-PROPOSTA  = ' WS-SMALLINT(02) '>' ' <IND-TP-PESSOA     = ' VG143-IND-TP-PESSOA '>' ' <IND-TP-SEGURADO   = ' VG143-IND-TP-SEGURADO '>' ' <NUM-CERTIFICADO   = ' WS-BIGINT(03) '>' ' <VLR-IS            = ' WS-DECIMAL(01) '>' ' <VLR-ACUMULO-IS    = ' WS-DECIMAL(02) '>' ' <COD-USUARIO       = ' VG143-COD-USUARIO '>' ' <NOM-PROGRAMA      = ' VG143-NOM-PROGRAMA '>' ' <DTH-CADASTRAMENTO = ' VG143-DTH-CADASTRAMENTO '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl69 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl69 += " - ERRO NO INSERT SEGUROS.VG_DPS_PROPOSTA.";
                spl69 += " <NUM-PROPOSTA = ";
                var spl70 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                spl70 += ">";
                spl70 += " <NUM-CPF-CNPJ = ";
                var spl71 = WORK.WS_EDIT.WS_BIGINT[02].GetMoveValues();
                spl71 += ">";
                spl71 += " <SEQ-PRODUTO-DPS = ";
                var spl72 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl72 += ">";
                spl72 += " <STA-DPS-PROPOSTA = ";
                var spl73 = WORK.WS_EDIT.WS_SMALLINT[02].GetMoveValues();
                spl73 += ">";
                spl73 += " <IND-TP-PESSOA = ";
                var spl74 = VG143.DCLVG_DPS_PROPOSTA.VG143_IND_TP_PESSOA.GetMoveValues();
                spl74 += ">";
                spl74 += " <IND-TP-SEGURADO = ";
                var spl75 = VG143.DCLVG_DPS_PROPOSTA.VG143_IND_TP_SEGURADO.GetMoveValues();
                spl75 += ">";
                spl75 += " <NUM-CERTIFICADO = ";
                var spl76 = WORK.WS_EDIT.WS_BIGINT[03].GetMoveValues();
                spl76 += ">";
                spl76 += " <VLR-IS = ";
                var spl77 = WORK.WS_EDIT.WS_DECIMAL[01].GetMoveValues();
                spl77 += ">";
                spl77 += " <VLR-ACUMULO-IS = ";
                var spl78 = WORK.WS_EDIT.WS_DECIMAL[02].GetMoveValues();
                spl78 += ">";
                spl78 += " <COD-USUARIO = ";
                var spl79 = VG143.DCLVG_DPS_PROPOSTA.VG143_COD_USUARIO.GetMoveValues();
                spl79 += ">";
                spl79 += " <NOM-PROGRAMA = ";
                var spl80 = VG143.DCLVG_DPS_PROPOSTA.VG143_NOM_PROGRAMA.GetMoveValues();
                spl80 += ">";
                spl80 += " <DTH-CADASTRAMENTO = ";
                var spl81 = VG143.DCLVG_DPS_PROPOSTA.VG143_DTH_CADASTRAMENTO.GetMoveValues();
                spl81 += ">";
                var results82 = spl69 + spl70 + spl71 + spl72 + spl73 + spl74 + spl75 + spl76 + spl77 + spl78 + spl79 + spl80 + spl81;
                _.Move(results82, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -1416- MOVE 'SEGUROS.VG_DPS_PROPOSTA' TO WS-TABELA */
                _.Move("SEGUROS.VG_DPS_PROPOSTA", WORK.WS_ERRO.WS_TABELA);

                /*" -1417- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -1418- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -1419- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1421- END-IF */
            }


            /*" -1421- . */

        }

        [StopWatch]
        /*" P0820-05-INICIO-DB-INSERT-1 */
        public void P0820_05_INICIO_DB_INSERT_1()
        {
            /*" -1388- EXEC SQL INSERT INTO SEGUROS.VG_DPS_PROPOSTA ( NUM_PROPOSTA ,NUM_CPF_CNPJ ,SEQ_PRODUTO_DPS ,STA_DPS_PROPOSTA ,IND_TP_PESSOA ,IND_TP_SEGURADO ,NUM_CERTIFICADO ,VLR_IS ,VLR_ACUMULO_IS ,COD_USUARIO ,NOM_PROGRAMA ,DTH_CADASTRAMENTO ) VALUES ( :VG143-NUM-PROPOSTA ,:VG143-NUM-CPF-CNPJ ,:VG143-SEQ-PRODUTO-DPS ,:VG143-STA-DPS-PROPOSTA ,:VG143-IND-TP-PESSOA ,:VG143-IND-TP-SEGURADO ,:VG143-NUM-CERTIFICADO ,:VG143-VLR-IS ,:VG143-VLR-ACUMULO-IS ,:VG143-COD-USUARIO ,:VG143-NOM-PROGRAMA ,:VG143-DTH-CADASTRAMENTO ) END-EXEC */

            var p0820_05_INICIO_DB_INSERT_1_Insert1 = new P0820_05_INICIO_DB_INSERT_1_Insert1()
            {
                VG143_NUM_PROPOSTA = VG143.DCLVG_DPS_PROPOSTA.VG143_NUM_PROPOSTA.ToString(),
                VG143_NUM_CPF_CNPJ = VG143.DCLVG_DPS_PROPOSTA.VG143_NUM_CPF_CNPJ.ToString(),
                VG143_SEQ_PRODUTO_DPS = VG143.DCLVG_DPS_PROPOSTA.VG143_SEQ_PRODUTO_DPS.ToString(),
                VG143_STA_DPS_PROPOSTA = VG143.DCLVG_DPS_PROPOSTA.VG143_STA_DPS_PROPOSTA.ToString(),
                VG143_IND_TP_PESSOA = VG143.DCLVG_DPS_PROPOSTA.VG143_IND_TP_PESSOA.ToString(),
                VG143_IND_TP_SEGURADO = VG143.DCLVG_DPS_PROPOSTA.VG143_IND_TP_SEGURADO.ToString(),
                VG143_NUM_CERTIFICADO = VG143.DCLVG_DPS_PROPOSTA.VG143_NUM_CERTIFICADO.ToString(),
                VG143_VLR_IS = VG143.DCLVG_DPS_PROPOSTA.VG143_VLR_IS.ToString(),
                VG143_VLR_ACUMULO_IS = VG143.DCLVG_DPS_PROPOSTA.VG143_VLR_ACUMULO_IS.ToString(),
                VG143_COD_USUARIO = VG143.DCLVG_DPS_PROPOSTA.VG143_COD_USUARIO.ToString(),
                VG143_NOM_PROGRAMA = VG143.DCLVG_DPS_PROPOSTA.VG143_NOM_PROGRAMA.ToString(),
                VG143_DTH_CADASTRAMENTO = VG143.DCLVG_DPS_PROPOSTA.VG143_DTH_CADASTRAMENTO.ToString(),
            };

            P0820_05_INICIO_DB_INSERT_1_Insert1.Execute(p0820_05_INICIO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0820_99_EXIT*/

        [StopWatch]
        /*" P0821-INSERIR-VG144-SECTION */
        private void P0821_INSERIR_VG144_SECTION()
        {
            /*" -1432- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0821_00_START */

            P0821_00_START();

        }

        [StopWatch]
        /*" P0821-00-START */
        private void P0821_00_START(bool isPerform = false)
        {
            /*" -1435- MOVE 'P0821' TO WS-SECTION */
            _.Move("P0821", WORK.WS_ERRO.WS_SECTION);

            /*" -1436- IF LK-VG017-E-TRACE = 'S' */

            if (SPVG017W.LK_VG017_E_TRACE == "S")
            {

                /*" -1437- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -1438- END-IF */
            }


            /*" -1438- PERFORM P0821-05-INICIO. */

            P0821_05_INICIO(true);

        }

        [StopWatch]
        /*" P0821-05-INICIO */
        private void P0821_05_INICIO(bool isPerform = false)
        {
            /*" -1468- PERFORM P0821_05_INICIO_DB_INSERT_1 */

            P0821_05_INICIO_DB_INSERT_1();

            /*" -1471- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1472- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -1473- MOVE VG143-NUM-PROPOSTA TO WS-BIGINT(01) */
                _.Move(VG143.DCLVG_DPS_PROPOSTA.VG143_NUM_PROPOSTA, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -1474- MOVE VG143-NUM-CPF-CNPJ TO WS-BIGINT(02) */
                _.Move(VG143.DCLVG_DPS_PROPOSTA.VG143_NUM_CPF_CNPJ, WORK.WS_EDIT.WS_BIGINT[02]);

                /*" -1475- MOVE VG143-SEQ-PRODUTO-DPS TO WS-SMALLINT(01) */
                _.Move(VG143.DCLVG_DPS_PROPOSTA.VG143_SEQ_PRODUTO_DPS, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -1476- MOVE VG143-STA-DPS-PROPOSTA TO WS-SMALLINT(02) */
                _.Move(VG143.DCLVG_DPS_PROPOSTA.VG143_STA_DPS_PROPOSTA, WORK.WS_EDIT.WS_SMALLINT[02]);

                /*" -1477- MOVE VG143-NUM-CERTIFICADO TO WS-BIGINT(03) */
                _.Move(VG143.DCLVG_DPS_PROPOSTA.VG143_NUM_CERTIFICADO, WORK.WS_EDIT.WS_BIGINT[03]);

                /*" -1478- MOVE VG143-VLR-IS TO WS-DECIMAL(01) */
                _.Move(VG143.DCLVG_DPS_PROPOSTA.VG143_VLR_IS, WORK.WS_EDIT.WS_DECIMAL[01]);

                /*" -1479- MOVE VG143-VLR-ACUMULO-IS TO WS-DECIMAL(02) */
                _.Move(VG143.DCLVG_DPS_PROPOSTA.VG143_VLR_ACUMULO_IS, WORK.WS_EDIT.WS_DECIMAL[02]);

                /*" -1494- STRING WS-SECTION ' - ERRO NO INSERT SEGUROS.VG_DPS_PROPOSTA_HIST.' ' <NUM-PROPOSTA      = ' WS-BIGINT(01) '>' ' <NUM-CPF-CNPJ      = ' WS-BIGINT(02) '>' ' <SEQ-PRODUTO-DPS   = ' WS-SMALLINT(01) '>' ' <STA-DPS-PROPOSTA  = ' WS-SMALLINT(02) '>' ' <IND-TP-PESSOA     = ' VG143-IND-TP-PESSOA '>' ' <IND-TP-SEGURADO   = ' VG143-IND-TP-SEGURADO '>' ' <NUM-CERTIFICADO   = ' WS-BIGINT(03) '>' ' <VLR-IS            = ' WS-DECIMAL(01) '>' ' <VLR-ACUMULO-IS    = ' WS-DECIMAL(02) '>' ' <COD-USUARIO       = ' VG143-COD-USUARIO '>' ' <NOM-PROGRAMA      = ' VG143-NOM-PROGRAMA '>' ' <DTH-CADASTRAMENTO = ' VG143-DTH-CADASTRAMENTO '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl82 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl82 += " - ERRO NO INSERT SEGUROS.VG_DPS_PROPOSTA_HIST.";
                spl82 += " <NUM-PROPOSTA = ";
                var spl83 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                spl83 += ">";
                spl83 += " <NUM-CPF-CNPJ = ";
                var spl84 = WORK.WS_EDIT.WS_BIGINT[02].GetMoveValues();
                spl84 += ">";
                spl84 += " <SEQ-PRODUTO-DPS = ";
                var spl85 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl85 += ">";
                spl85 += " <STA-DPS-PROPOSTA = ";
                var spl86 = WORK.WS_EDIT.WS_SMALLINT[02].GetMoveValues();
                spl86 += ">";
                spl86 += " <IND-TP-PESSOA = ";
                var spl87 = VG143.DCLVG_DPS_PROPOSTA.VG143_IND_TP_PESSOA.GetMoveValues();
                spl87 += ">";
                spl87 += " <IND-TP-SEGURADO = ";
                var spl88 = VG143.DCLVG_DPS_PROPOSTA.VG143_IND_TP_SEGURADO.GetMoveValues();
                spl88 += ">";
                spl88 += " <NUM-CERTIFICADO = ";
                var spl89 = WORK.WS_EDIT.WS_BIGINT[03].GetMoveValues();
                spl89 += ">";
                spl89 += " <VLR-IS = ";
                var spl90 = WORK.WS_EDIT.WS_DECIMAL[01].GetMoveValues();
                spl90 += ">";
                spl90 += " <VLR-ACUMULO-IS = ";
                var spl91 = WORK.WS_EDIT.WS_DECIMAL[02].GetMoveValues();
                spl91 += ">";
                spl91 += " <COD-USUARIO = ";
                var spl92 = VG143.DCLVG_DPS_PROPOSTA.VG143_COD_USUARIO.GetMoveValues();
                spl92 += ">";
                spl92 += " <NOM-PROGRAMA = ";
                var spl93 = VG143.DCLVG_DPS_PROPOSTA.VG143_NOM_PROGRAMA.GetMoveValues();
                spl93 += ">";
                spl93 += " <DTH-CADASTRAMENTO = ";
                var spl94 = VG143.DCLVG_DPS_PROPOSTA.VG143_DTH_CADASTRAMENTO.GetMoveValues();
                spl94 += ">";
                var results95 = spl82 + spl83 + spl84 + spl85 + spl86 + spl87 + spl88 + spl89 + spl90 + spl91 + spl92 + spl93 + spl94;
                _.Move(results95, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -1496- MOVE 'SEGUROS.VG_DPS_PROPOSTA_HIST' TO WS-TABELA */
                _.Move("SEGUROS.VG_DPS_PROPOSTA_HIST", WORK.WS_ERRO.WS_TABELA);

                /*" -1497- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -1498- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -1499- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1501- END-IF */
            }


            /*" -1501- . */

        }

        [StopWatch]
        /*" P0821-05-INICIO-DB-INSERT-1 */
        public void P0821_05_INICIO_DB_INSERT_1()
        {
            /*" -1468- EXEC SQL INSERT INTO SEGUROS.VG_DPS_PROPOSTA_HIST ( NUM_PROPOSTA ,NUM_CPF_CNPJ ,DTH_CADASTRAMENTO ,SEQ_PRODUTO_DPS ,STA_DPS_PROPOSTA ,IND_TP_PESSOA ,IND_TP_SEGURADO ,NUM_CERTIFICADO ,VLR_IS ,VLR_ACUMULO_IS ,COD_USUARIO ,NOM_PROGRAMA ) VALUES ( :VG143-NUM-PROPOSTA ,:VG143-NUM-CPF-CNPJ ,:VG143-DTH-CADASTRAMENTO ,:VG143-SEQ-PRODUTO-DPS ,:VG143-STA-DPS-PROPOSTA ,:VG143-IND-TP-PESSOA ,:VG143-IND-TP-SEGURADO ,:VG143-NUM-CERTIFICADO ,:VG143-VLR-IS ,:VG143-VLR-ACUMULO-IS ,:VG143-COD-USUARIO ,:VG143-NOM-PROGRAMA ) END-EXEC */

            var p0821_05_INICIO_DB_INSERT_1_Insert1 = new P0821_05_INICIO_DB_INSERT_1_Insert1()
            {
                VG143_NUM_PROPOSTA = VG143.DCLVG_DPS_PROPOSTA.VG143_NUM_PROPOSTA.ToString(),
                VG143_NUM_CPF_CNPJ = VG143.DCLVG_DPS_PROPOSTA.VG143_NUM_CPF_CNPJ.ToString(),
                VG143_DTH_CADASTRAMENTO = VG143.DCLVG_DPS_PROPOSTA.VG143_DTH_CADASTRAMENTO.ToString(),
                VG143_SEQ_PRODUTO_DPS = VG143.DCLVG_DPS_PROPOSTA.VG143_SEQ_PRODUTO_DPS.ToString(),
                VG143_STA_DPS_PROPOSTA = VG143.DCLVG_DPS_PROPOSTA.VG143_STA_DPS_PROPOSTA.ToString(),
                VG143_IND_TP_PESSOA = VG143.DCLVG_DPS_PROPOSTA.VG143_IND_TP_PESSOA.ToString(),
                VG143_IND_TP_SEGURADO = VG143.DCLVG_DPS_PROPOSTA.VG143_IND_TP_SEGURADO.ToString(),
                VG143_NUM_CERTIFICADO = VG143.DCLVG_DPS_PROPOSTA.VG143_NUM_CERTIFICADO.ToString(),
                VG143_VLR_IS = VG143.DCLVG_DPS_PROPOSTA.VG143_VLR_IS.ToString(),
                VG143_VLR_ACUMULO_IS = VG143.DCLVG_DPS_PROPOSTA.VG143_VLR_ACUMULO_IS.ToString(),
                VG143_COD_USUARIO = VG143.DCLVG_DPS_PROPOSTA.VG143_COD_USUARIO.ToString(),
                VG143_NOM_PROGRAMA = VG143.DCLVG_DPS_PROPOSTA.VG143_NOM_PROGRAMA.ToString(),
            };

            P0821_05_INICIO_DB_INSERT_1_Insert1.Execute(p0821_05_INICIO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0821_99_EXIT*/

        [StopWatch]
        /*" P0822-ATUALIZAR-VG143-SECTION */
        private void P0822_ATUALIZAR_VG143_SECTION()
        {
            /*" -1512- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0822_00_START */

            P0822_00_START();

        }

        [StopWatch]
        /*" P0822-00-START */
        private void P0822_00_START(bool isPerform = false)
        {
            /*" -1515- MOVE 'P0822' TO WS-SECTION */
            _.Move("P0822", WORK.WS_ERRO.WS_SECTION);

            /*" -1516- IF LK-VG017-E-TRACE = 'S' */

            if (SPVG017W.LK_VG017_E_TRACE == "S")
            {

                /*" -1517- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -1518- MOVE VG143-NUM-PROPOSTA TO WS-BIGINT(01) */
                _.Move(VG143.DCLVG_DPS_PROPOSTA.VG143_NUM_PROPOSTA, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -1519- MOVE VG143-NUM-CPF-CNPJ TO WS-BIGINT(02) */
                _.Move(VG143.DCLVG_DPS_PROPOSTA.VG143_NUM_CPF_CNPJ, WORK.WS_EDIT.WS_BIGINT[02]);

                /*" -1520- MOVE VG143-SEQ-PRODUTO-DPS TO WS-SMALLINT(01) */
                _.Move(VG143.DCLVG_DPS_PROPOSTA.VG143_SEQ_PRODUTO_DPS, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -1521- MOVE VG143-STA-DPS-PROPOSTA TO WS-SMALLINT(02) */
                _.Move(VG143.DCLVG_DPS_PROPOSTA.VG143_STA_DPS_PROPOSTA, WORK.WS_EDIT.WS_SMALLINT[02]);

                /*" -1522- MOVE VG143-NUM-CERTIFICADO TO WS-BIGINT(03) */
                _.Move(VG143.DCLVG_DPS_PROPOSTA.VG143_NUM_CERTIFICADO, WORK.WS_EDIT.WS_BIGINT[03]);

                /*" -1523- MOVE VG143-VLR-IS TO WS-DECIMAL(01) */
                _.Move(VG143.DCLVG_DPS_PROPOSTA.VG143_VLR_IS, WORK.WS_EDIT.WS_DECIMAL[01]);

                /*" -1524- MOVE VG143-VLR-ACUMULO-IS TO WS-DECIMAL(02) */
                _.Move(VG143.DCLVG_DPS_PROPOSTA.VG143_VLR_ACUMULO_IS, WORK.WS_EDIT.WS_DECIMAL[02]);

                /*" -1531- STRING WS-SECTION ' - ANTES DO UPDATE' ' <NUM-PROPOSTA      = ' WS-BIGINT(01) '>' ' <NUM-CPF-CNPJ      = ' WS-BIGINT(02) '>' ' <SEQ-PRODUTO-DPS   = ' WS-SMALLINT(01) '>' ' <STA-DPS-PROPOSTA  = ' WS-SMALLINT(02) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl95 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl95 += " - ANTES DO UPDATE";
                spl95 += " <NUM-PROPOSTA = ";
                var spl96 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                spl96 += ">";
                spl96 += " <NUM-CPF-CNPJ = ";
                var spl97 = WORK.WS_EDIT.WS_BIGINT[02].GetMoveValues();
                spl97 += ">";
                spl97 += " <SEQ-PRODUTO-DPS = ";
                var spl98 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl98 += ">";
                spl98 += " <STA-DPS-PROPOSTA = ";
                var spl99 = WORK.WS_EDIT.WS_SMALLINT[02].GetMoveValues();
                spl99 += ">";
                var results100 = spl95 + spl96 + spl97 + spl98 + spl99;
                _.Move(results100, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -1532- DISPLAY WS-MENSAGEM */
                _.Display(WORK.WS_ERRO.WS_MENSAGEM);

                /*" -1533- END-IF */
            }


            /*" -1533- PERFORM P0822-05-INICIO */

            P0822_05_INICIO(true);

        }

        [StopWatch]
        /*" P0822-05-INICIO */
        private void P0822_05_INICIO(bool isPerform = false)
        {
            /*" -1551- PERFORM P0822_05_INICIO_DB_UPDATE_1 */

            P0822_05_INICIO_DB_UPDATE_1();

            /*" -1554- IF LK-VG017-E-TRACE = 'S' */

            if (SPVG017W.LK_VG017_E_TRACE == "S")
            {

                /*" -1555- MOVE VG143-NUM-PROPOSTA TO WS-BIGINT(01) */
                _.Move(VG143.DCLVG_DPS_PROPOSTA.VG143_NUM_PROPOSTA, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -1556- MOVE VG143-NUM-CPF-CNPJ TO WS-BIGINT(02) */
                _.Move(VG143.DCLVG_DPS_PROPOSTA.VG143_NUM_CPF_CNPJ, WORK.WS_EDIT.WS_BIGINT[02]);

                /*" -1557- MOVE VG143-SEQ-PRODUTO-DPS TO WS-SMALLINT(01) */
                _.Move(VG143.DCLVG_DPS_PROPOSTA.VG143_SEQ_PRODUTO_DPS, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -1558- MOVE VG143-STA-DPS-PROPOSTA TO WS-SMALLINT(02) */
                _.Move(VG143.DCLVG_DPS_PROPOSTA.VG143_STA_DPS_PROPOSTA, WORK.WS_EDIT.WS_SMALLINT[02]);

                /*" -1559- MOVE VG143-NUM-CERTIFICADO TO WS-BIGINT(03) */
                _.Move(VG143.DCLVG_DPS_PROPOSTA.VG143_NUM_CERTIFICADO, WORK.WS_EDIT.WS_BIGINT[03]);

                /*" -1560- MOVE VG143-VLR-IS TO WS-DECIMAL(01) */
                _.Move(VG143.DCLVG_DPS_PROPOSTA.VG143_VLR_IS, WORK.WS_EDIT.WS_DECIMAL[01]);

                /*" -1561- MOVE VG143-VLR-ACUMULO-IS TO WS-DECIMAL(02) */
                _.Move(VG143.DCLVG_DPS_PROPOSTA.VG143_VLR_ACUMULO_IS, WORK.WS_EDIT.WS_DECIMAL[02]);

                /*" -1562- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -1569- STRING WS-SECTION ' - DEPOIS DO UPDATE ' WS-SQLCODE ' <NUM-PROPOSTA      = ' WS-BIGINT (01) '>' ' <NUM-CPF-CNPJ      = ' WS-BIGINT (02) '>' ' <SEQ-PRODUTO-DPS   = ' WS-SMALLINT(01) '>' ' <STA-DPS-PROPOSTA  = ' WS-SMALLINT(02) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl100 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl100 += " - DEPOIS DO UPDATE ";
                var spl101 = WORK.WS_ERRO.WS_SQLCODE.GetMoveValues();
                spl101 += " <NUM-PROPOSTA = ";
                var spl102 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                spl102 += ">";
                spl102 += " <NUM-CPF-CNPJ = ";
                var spl103 = WORK.WS_EDIT.WS_BIGINT[02].GetMoveValues();
                spl103 += ">";
                spl103 += " <SEQ-PRODUTO-DPS = ";
                var spl104 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl104 += ">";
                spl104 += " <STA-DPS-PROPOSTA = ";
                var spl105 = WORK.WS_EDIT.WS_SMALLINT[02].GetMoveValues();
                spl105 += ">";
                var results106 = spl100 + spl101 + spl102 + spl103 + spl104 + spl105;
                _.Move(results106, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -1570- DISPLAY WS-MENSAGEM */
                _.Display(WORK.WS_ERRO.WS_MENSAGEM);

                /*" -1572- END-IF */
            }


            /*" -1573- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -1574- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -1575- MOVE VG143-NUM-PROPOSTA TO WS-BIGINT(01) */
                _.Move(VG143.DCLVG_DPS_PROPOSTA.VG143_NUM_PROPOSTA, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -1576- MOVE VG143-NUM-CPF-CNPJ TO WS-BIGINT(02) */
                _.Move(VG143.DCLVG_DPS_PROPOSTA.VG143_NUM_CPF_CNPJ, WORK.WS_EDIT.WS_BIGINT[02]);

                /*" -1577- MOVE VG143-SEQ-PRODUTO-DPS TO WS-SMALLINT(01) */
                _.Move(VG143.DCLVG_DPS_PROPOSTA.VG143_SEQ_PRODUTO_DPS, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -1578- MOVE VG143-STA-DPS-PROPOSTA TO WS-SMALLINT(02) */
                _.Move(VG143.DCLVG_DPS_PROPOSTA.VG143_STA_DPS_PROPOSTA, WORK.WS_EDIT.WS_SMALLINT[02]);

                /*" -1579- MOVE VG143-NUM-CERTIFICADO TO WS-BIGINT(03) */
                _.Move(VG143.DCLVG_DPS_PROPOSTA.VG143_NUM_CERTIFICADO, WORK.WS_EDIT.WS_BIGINT[03]);

                /*" -1580- MOVE VG143-VLR-IS TO WS-DECIMAL(01) */
                _.Move(VG143.DCLVG_DPS_PROPOSTA.VG143_VLR_IS, WORK.WS_EDIT.WS_DECIMAL[01]);

                /*" -1581- MOVE VG143-VLR-ACUMULO-IS TO WS-DECIMAL(02) */
                _.Move(VG143.DCLVG_DPS_PROPOSTA.VG143_VLR_ACUMULO_IS, WORK.WS_EDIT.WS_DECIMAL[02]);

                /*" -1596- STRING WS-SECTION ' - ERRO NO UPDATE SEGUROS.VG_DPS_PROPOSTA.' ' <NUM-PROPOSTA      = ' WS-BIGINT (01) '>' ' <NUM-CPF-CNPJ      = ' WS-BIGINT (02) '>' ' <SEQ-PRODUTO-DPS   = ' WS-SMALLINT (01) '>' ' <STA-DPS-PROPOSTA  = ' WS-SMALLINT (02) '>' ' <IND-TP-PESSOA     = ' VG143-IND-TP-PESSOA '>' ' <IND-TP-SEGURADO   = ' VG143-IND-TP-SEGURADO '>' ' <NUM-CERTIFICADO   = ' WS-BIGINT (03) '>' ' <VLR-IS            = ' WS-DECIMAL (01) '>' ' <VLR-ACUMULO-IS    = ' WS-DECIMAL (02) '>' ' <COD-USUARIO       = ' VG143-COD-USUARIO '>' ' <NOM-PROGRAMA      = ' VG143-NOM-PROGRAMA '>' ' <DTH-CADASTRAMENTO = ' VG143-DTH-CADASTRAMENTO '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl106 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl106 += " - ERRO NO UPDATE SEGUROS.VG_DPS_PROPOSTA.";
                spl106 += " <NUM-PROPOSTA = ";
                var spl107 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                spl107 += ">";
                spl107 += " <NUM-CPF-CNPJ = ";
                var spl108 = WORK.WS_EDIT.WS_BIGINT[02].GetMoveValues();
                spl108 += ">";
                spl108 += " <SEQ-PRODUTO-DPS = ";
                var spl109 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl109 += ">";
                spl109 += " <STA-DPS-PROPOSTA = ";
                var spl110 = WORK.WS_EDIT.WS_SMALLINT[02].GetMoveValues();
                spl110 += ">";
                spl110 += " <IND-TP-PESSOA = ";
                var spl111 = VG143.DCLVG_DPS_PROPOSTA.VG143_IND_TP_PESSOA.GetMoveValues();
                spl111 += ">";
                spl111 += " <IND-TP-SEGURADO = ";
                var spl112 = VG143.DCLVG_DPS_PROPOSTA.VG143_IND_TP_SEGURADO.GetMoveValues();
                spl112 += ">";
                spl112 += " <NUM-CERTIFICADO = ";
                var spl113 = WORK.WS_EDIT.WS_BIGINT[03].GetMoveValues();
                spl113 += ">";
                spl113 += " <VLR-IS = ";
                var spl114 = WORK.WS_EDIT.WS_DECIMAL[01].GetMoveValues();
                spl114 += ">";
                spl114 += " <VLR-ACUMULO-IS = ";
                var spl115 = WORK.WS_EDIT.WS_DECIMAL[02].GetMoveValues();
                spl115 += ">";
                spl115 += " <COD-USUARIO = ";
                var spl116 = VG143.DCLVG_DPS_PROPOSTA.VG143_COD_USUARIO.GetMoveValues();
                spl116 += ">";
                spl116 += " <NOM-PROGRAMA = ";
                var spl117 = VG143.DCLVG_DPS_PROPOSTA.VG143_NOM_PROGRAMA.GetMoveValues();
                spl117 += ">";
                spl117 += " <DTH-CADASTRAMENTO = ";
                var spl118 = VG143.DCLVG_DPS_PROPOSTA.VG143_DTH_CADASTRAMENTO.GetMoveValues();
                spl118 += ">";
                var results119 = spl106 + spl107 + spl108 + spl109 + spl110 + spl111 + spl112 + spl113 + spl114 + spl115 + spl116 + spl117 + spl118;
                _.Move(results119, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -1598- MOVE 'SEGUROS.VG_DPS_PROPOSTA' TO WS-TABELA */
                _.Move("SEGUROS.VG_DPS_PROPOSTA", WORK.WS_ERRO.WS_TABELA);

                /*" -1599- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -1600- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -1601- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1603- END-IF */
            }


            /*" -1603- . */

        }

        [StopWatch]
        /*" P0822-05-INICIO-DB-UPDATE-1 */
        public void P0822_05_INICIO_DB_UPDATE_1()
        {
            /*" -1551- EXEC SQL UPDATE SEGUROS.VG_DPS_PROPOSTA SET SEQ_PRODUTO_DPS = :VG143-SEQ-PRODUTO-DPS ,STA_DPS_PROPOSTA = :VG143-STA-DPS-PROPOSTA ,IND_TP_PESSOA = :VG143-IND-TP-PESSOA ,IND_TP_SEGURADO = :VG143-IND-TP-SEGURADO ,NUM_CERTIFICADO = :VG143-NUM-CERTIFICADO ,VLR_IS = :VG143-VLR-IS ,VLR_ACUMULO_IS = :VG143-VLR-ACUMULO-IS ,COD_USUARIO = :VG143-COD-USUARIO ,NOM_PROGRAMA = :VG143-NOM-PROGRAMA ,DTH_CADASTRAMENTO = :VG143-DTH-CADASTRAMENTO WHERE NUM_PROPOSTA = :VG143-NUM-PROPOSTA AND NUM_CPF_CNPJ = :VG143-NUM-CPF-CNPJ END-EXEC */

            var p0822_05_INICIO_DB_UPDATE_1_Update1 = new P0822_05_INICIO_DB_UPDATE_1_Update1()
            {
                VG143_DTH_CADASTRAMENTO = VG143.DCLVG_DPS_PROPOSTA.VG143_DTH_CADASTRAMENTO.ToString(),
                VG143_STA_DPS_PROPOSTA = VG143.DCLVG_DPS_PROPOSTA.VG143_STA_DPS_PROPOSTA.ToString(),
                VG143_SEQ_PRODUTO_DPS = VG143.DCLVG_DPS_PROPOSTA.VG143_SEQ_PRODUTO_DPS.ToString(),
                VG143_IND_TP_SEGURADO = VG143.DCLVG_DPS_PROPOSTA.VG143_IND_TP_SEGURADO.ToString(),
                VG143_NUM_CERTIFICADO = VG143.DCLVG_DPS_PROPOSTA.VG143_NUM_CERTIFICADO.ToString(),
                VG143_VLR_ACUMULO_IS = VG143.DCLVG_DPS_PROPOSTA.VG143_VLR_ACUMULO_IS.ToString(),
                VG143_IND_TP_PESSOA = VG143.DCLVG_DPS_PROPOSTA.VG143_IND_TP_PESSOA.ToString(),
                VG143_NOM_PROGRAMA = VG143.DCLVG_DPS_PROPOSTA.VG143_NOM_PROGRAMA.ToString(),
                VG143_COD_USUARIO = VG143.DCLVG_DPS_PROPOSTA.VG143_COD_USUARIO.ToString(),
                VG143_VLR_IS = VG143.DCLVG_DPS_PROPOSTA.VG143_VLR_IS.ToString(),
                VG143_NUM_PROPOSTA = VG143.DCLVG_DPS_PROPOSTA.VG143_NUM_PROPOSTA.ToString(),
                VG143_NUM_CPF_CNPJ = VG143.DCLVG_DPS_PROPOSTA.VG143_NUM_CPF_CNPJ.ToString(),
            };

            P0822_05_INICIO_DB_UPDATE_1_Update1.Execute(p0822_05_INICIO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0822_99_EXIT*/

        [StopWatch]
        /*" P0851-BUSCAR-TIMESTAMP-SECTION */
        private void P0851_BUSCAR_TIMESTAMP_SECTION()
        {
            /*" -1614- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0851_00_START */

            P0851_00_START();

        }

        [StopWatch]
        /*" P0851-00-START */
        private void P0851_00_START(bool isPerform = false)
        {
            /*" -1617- MOVE 'P0851' TO WS-SECTION */
            _.Move("P0851", WORK.WS_ERRO.WS_SECTION);

            /*" -1618- IF LK-VG017-E-TRACE = 'S' */

            if (SPVG017W.LK_VG017_E_TRACE == "S")
            {

                /*" -1619- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -1620- END-IF */
            }


            /*" -1620- PERFORM P0851-01-INICIO. */

            P0851_01_INICIO(true);

        }

        [StopWatch]
        /*" P0851-01-INICIO */
        private void P0851_01_INICIO(bool isPerform = false)
        {
            /*" -1628- PERFORM P0851_01_INICIO_DB_SELECT_1 */

            P0851_01_INICIO_DB_SELECT_1();

            /*" -1631- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1632- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -1635- STRING WS-SECTION ' - ERRO NO SELECT SYSIBM.SYSDUMMY1.' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl119 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl119 += " - ERRO NO SELECT SYSIBM.SYSDUMMY1.";
                _.Move(spl119, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -1636- MOVE 'SYSIBM.SYSDUMMY1' TO WS-TABELA */
                _.Move("SYSIBM.SYSDUMMY1", WORK.WS_ERRO.WS_TABELA);

                /*" -1637- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -1638- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -1639- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1641- END-IF */
            }


            /*" -1641- . */

        }

        [StopWatch]
        /*" P0851-01-INICIO-DB-SELECT-1 */
        public void P0851_01_INICIO_DB_SELECT_1()
        {
            /*" -1628- EXEC SQL SELECT CHAR(CURRENT TIMESTAMP) INTO :WH-CURRENT-TIMESTAMP FROM SYSIBM.SYSDUMMY1 END-EXEC */

            var p0851_01_INICIO_DB_SELECT_1_Query1 = new P0851_01_INICIO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = P0851_01_INICIO_DB_SELECT_1_Query1.Execute(p0851_01_INICIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WH_CURRENT_TIMESTAMP, WH_AUXILIAR.WH_CURRENT_TIMESTAMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0851_99_EXIT*/

        [StopWatch]
        /*" P9999-ERRO-SECTION */
        private void P9999_ERRO_SECTION()
        {
            /*" -1653- IF LK-VG017-E-TRACE = 'S' */

            if (SPVG017W.LK_VG017_E_TRACE == "S")
            {

                /*" -1654- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -1655- DISPLAY '*            S P B V G 0 1 7                 *' */
                _.Display($"*            S P B V G 0 1 7                 *");

                /*" -1656- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -1663- DISPLAY '* DATA COMPILACAO..: ' WS-C-DATE-COMPILED(7:2) '/' WS-C-DATE-COMPILED(5:2) '/' WS-C-DATE-COMPILED(1:4) '-' WS-C-DATE-COMPILED(9:2) ':' WS-C-DATE-COMPILED(11:2) ':' WS-C-DATE-COMPILED(13:2) */

                $"* DATA COMPILACAO..: {WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(7, 2)}/{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(5, 2)}/{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(1, 4)}-{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(9, 2)}:{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(11, 2)}:{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(13, 2)}"
                .Display();

                /*" -1670- DISPLAY '* DATA EXECUCAO....: ' WS-C-DATE-CURRENT(7:2) '/' WS-C-DATE-CURRENT(5:2) '/' WS-C-DATE-CURRENT(1:4) '-' WS-C-DATE-CURRENT(9:2) ':' WS-C-DATE-CURRENT(11:2) ':' WS-C-DATE-CURRENT(13:2) */

                $"* DATA EXECUCAO....: {WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(7, 2)}/{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(5, 2)}/{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(1, 4)}-{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(9, 2)}:{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(11, 2)}:{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(13, 2)}"
                .Display();

                /*" -1675- DISPLAY '* DATA SISTEMA.....: ' SISTEMAS-DATA-MOV-ABERTO(9:2) '/' SISTEMAS-DATA-MOV-ABERTO(6:2) '/' SISTEMAS-DATA-MOV-ABERTO(1:4) */

                $"* DATA SISTEMA.....: {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2)}/{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2)}/{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4)}"
                .Display();

                /*" -1676- MOVE LK-VG017-E-NUM-PROTOCOLO TO WS-BIGINT (01) */
                _.Move(SPVG017W.LK_VG017_E_NUM_PROTOCOLO, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -1677- MOVE LK-VG017-E-NUM-CPF-CNPJ TO WS-BIGINT (02) */
                _.Move(SPVG017W.LK_VG017_E_NUM_CPF_CNPJ, WORK.WS_EDIT.WS_BIGINT[02]);

                /*" -1678- MOVE LK-VG017-E-NUM-PROPOSTA TO WS-BIGINT (03) */
                _.Move(SPVG017W.LK_VG017_E_NUM_PROPOSTA, WORK.WS_EDIT.WS_BIGINT[03]);

                /*" -1679- MOVE LK-VG017-E-SEQ-PRODUTO-DPS TO WS-SMALLINT(01) */
                _.Move(SPVG017W.LK_VG017_E_SEQ_PRODUTO_DPS, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -1680- MOVE LK-VG017-E-NUM-CERTIFICADO TO WS-BIGINT (04) */
                _.Move(SPVG017W.LK_VG017_E_NUM_CERTIFICADO, WORK.WS_EDIT.WS_BIGINT[04]);

                /*" -1681- MOVE LK-VG017-E-VLR-IS TO WS-DECIMAL (01) */
                _.Move(SPVG017W.LK_VG017_E_VLR_IS, WORK.WS_EDIT.WS_DECIMAL[01]);

                /*" -1682- MOVE LK-VG017-E-VLR-ACUMULADO-IS TO WS-DECIMAL (02) */
                _.Move(SPVG017W.LK_VG017_E_VLR_ACUMULADO_IS, WORK.WS_EDIT.WS_DECIMAL[02]);

                /*" -1683- MOVE LK-VG017-E-STA-PROPOSTA-SIAS TO WS-SMALLINT(02) */
                _.Move(SPVG017W.LK_VG017_E_STA_PROPOSTA_SIAS, WORK.WS_EDIT.WS_SMALLINT[02]);

                /*" -1685- MOVE LK-VG017-E-TIPO-ACAO TO WS-SMALLINT(03) */
                _.Move(SPVG017W.LK_VG017_E_TIPO_ACAO, WORK.WS_EDIT.WS_SMALLINT[03]);

                /*" -1686- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -1687- DISPLAY '*             DADOS DE ENTRADA               *' */
                _.Display($"*             DADOS DE ENTRADA               *");

                /*" -1688- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -1689- DISPLAY '* IDE-SISTEMA.....: ' LK-VG017-E-IDE-SISTEMA */
                _.Display($"* IDE-SISTEMA.....: {SPVG017W.LK_VG017_E_IDE_SISTEMA}");

                /*" -1690- DISPLAY '* COD-USUARIO.....: ' LK-VG017-E-COD-USUARIO */
                _.Display($"* COD-USUARIO.....: {SPVG017W.LK_VG017_E_COD_USUARIO}");

                /*" -1691- DISPLAY '* NOM-PROGRAMA....: ' LK-VG017-E-NOM-PROGRAMA */
                _.Display($"* NOM-PROGRAMA....: {SPVG017W.LK_VG017_E_NOM_PROGRAMA}");

                /*" -1692- DISPLAY '* TPO-ACAO........: ' WS-SMALLINT(03) */
                _.Display($"* TPO-ACAO........: {WORK.WS_EDIT.WS_SMALLINT[3]}");

                /*" -1693- DISPLAY '* NUM-PROTOCOLO...: ' WS-BIGINT (01) */
                _.Display($"* NUM-PROTOCOLO...: {WORK.WS_EDIT.WS_BIGINT[1]}");

                /*" -1694- DISPLAY '* NUM-CPF-CNPJ....: ' WS-BIGINT (02) */
                _.Display($"* NUM-CPF-CNPJ....: {WORK.WS_EDIT.WS_BIGINT[2]}");

                /*" -1695- DISPLAY '* NUM-PROPOSTA....: ' WS-BIGINT (03) */
                _.Display($"* NUM-PROPOSTA....: {WORK.WS_EDIT.WS_BIGINT[3]}");

                /*" -1696- DISPLAY '* SEQ-PRODUTO-DPS.: ' WS-SMALLINT(01) */
                _.Display($"* SEQ-PRODUTO-DPS.: {WORK.WS_EDIT.WS_SMALLINT[1]}");

                /*" -1697- DISPLAY '* DTH-CONSULTA-DPS: ' LK-VG017-E-DTH-CONSULTA-DPS */
                _.Display($"* DTH-CONSULTA-DPS: {SPVG017W.LK_VG017_E_DTH_CONSULTA_DPS}");

                /*" -1698- DISPLAY '* IND-TP-PESSOA...: ' LK-VG017-E-IND-TP-PESSOA */
                _.Display($"* IND-TP-PESSOA...: {SPVG017W.LK_VG017_E_IND_TP_PESSOA}");

                /*" -1699- DISPLAY '* IND-TP-SEGURADO.: ' LK-VG017-E-IND-TP-SEGURADO */
                _.Display($"* IND-TP-SEGURADO.: {SPVG017W.LK_VG017_E_IND_TP_SEGURADO}");

                /*" -1700- DISPLAY '* NUM-CERTIFICADO.: ' WS-BIGINT (04) */
                _.Display($"* NUM-CERTIFICADO.: {WORK.WS_EDIT.WS_BIGINT[4]}");

                /*" -1701- DISPLAY '* VLR-IS..........: ' WS-DECIMAL (01) */
                _.Display($"* VLR-IS..........: {WORK.WS_EDIT.WS_DECIMAL[1]}");

                /*" -1702- DISPLAY '* VLR-ACUMULADO-IS: ' WS-DECIMAL (02) */
                _.Display($"* VLR-ACUMULADO-IS: {WORK.WS_EDIT.WS_DECIMAL[2]}");

                /*" -1703- DISPLAY '* STA-PROPOSTA-SIA: ' WS-SMALLINT(02) */
                _.Display($"* STA-PROPOSTA-SIA: {WORK.WS_EDIT.WS_SMALLINT[2]}");

                /*" -1705- DISPLAY '* STA-PROPOSTA-MTR: ' LK-VG017-E-STA-PROPOSTA-MOTOR */
                _.Display($"* STA-PROPOSTA-MTR: {SPVG017W.LK_VG017_E_STA_PROPOSTA_MOTOR}");

                /*" -1706- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -1707- DISPLAY '*         E R R O    S P B V G 0 1 7         *' */
                _.Display($"*         E R R O    S P B V G 0 1 7         *");

                /*" -1708- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -1709- DISPLAY '* SECTION..........: ' WS-SECTION */
                _.Display($"* SECTION..........: {WORK.WS_ERRO.WS_SECTION}");

                /*" -1710- DISPLAY '* IND ERRO.........: ' WS-IND-ERRO */
                _.Display($"* IND ERRO.........: {WORK.WS_ERRO.WS_IND_ERRO}");

                /*" -1711- DISPLAY '* TABELA...........: ' WS-TABELA */
                _.Display($"* TABELA...........: {WORK.WS_ERRO.WS_TABELA}");

                /*" -1712- DISPLAY '* MENSAGEM.........: ' WS-MENSAGEM */
                _.Display($"* MENSAGEM.........: {WORK.WS_ERRO.WS_MENSAGEM}");

                /*" -1713- DISPLAY '* SQLCODE..........: ' WS-SQLCODE */
                _.Display($"* SQLCODE..........: {WORK.WS_ERRO.WS_SQLCODE}");

                /*" -1714- DISPLAY '* SQLERRMC.........: ' WS-SQLERRMC */
                _.Display($"* SQLERRMC.........: {WORK.WS_ERRO.WS_SQLERRMC}");

                /*" -1715- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -1717- END-IF */
            }


            /*" -1718- MOVE WS-IND-ERRO TO LK-VG017-IND-ERRO */
            _.Move(WORK.WS_ERRO.WS_IND_ERRO, SPVG017W.LK_VG017_IND_ERRO);

            /*" -1719- MOVE WS-MENSAGEM TO LK-VG017-MENSAGEM */
            _.Move(WORK.WS_ERRO.WS_MENSAGEM, SPVG017W.LK_VG017_MENSAGEM);

            /*" -1720- MOVE WS-TABELA TO LK-VG017-NOM-TABELA */
            _.Move(WORK.WS_ERRO.WS_TABELA, SPVG017W.LK_VG017_NOM_TABELA);

            /*" -1721- MOVE WS-SQLCODE TO LK-VG017-SQLCODE */
            _.Move(WORK.WS_ERRO.WS_SQLCODE, SPVG017W.LK_VG017_SQLCODE);

            /*" -1723- MOVE WS-SQLERRMC TO LK-VG017-SQLERRMC */
            _.Move(WORK.WS_ERRO.WS_SQLERRMC, SPVG017W.LK_VG017_SQLERRMC);

            /*" -1723- . */

            /*" -0- FLUXCONTROL_PERFORM P9999_99_EXIT */

            P9999_99_EXIT();

        }

        [StopWatch]
        /*" P9999-99-EXIT */
        private void P9999_99_EXIT(bool isPerform = false)
        {
            /*" -1726- GOBACK. */

            throw new GoBack();

        }
    }
}