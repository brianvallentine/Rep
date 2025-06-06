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
using Sias.Outros.DB2.SPBVG015;

namespace Code
{
    public class SPBVG015
    {
        public bool IsCall { get; set; }

        public SPBVG015()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      * SISTEMA.........: SIAS                                         *      */
        /*"      * MODULO..........: VG                                           *      */
        /*"      * PROGRAMA........: SPBVG015                                     *      */
        /*"      * ANALISTA........: ELIERMES OLIVEIRA                            *      */
        /*"      * DATA............: 29/07/2024                                   *      */
        /*"      ******************************************************************      */
        /*"      * OBJETIVO........: REALIZA ANALISE DE REGRAS PARAMETRIZADAS PARA*      */
        /*"      *                   IDENTIFICAR SE CPF DEVE OU NAO TER PREENCHI- *      */
        /*"      *                   MENTO OBRIGATORIO DE DPS ELETRONICA          *      */
        /*"      *==> TIPO DE ACAO                                                *      */
        /*"      *    (01) ANALISA REGRAS CADASTRADAS PARA IDENTIFICACAO DE NECES-*      */
        /*"      *         SIDADE DE PREENCHIMENTO DE DPS ELETRONICO              *      */
        /*"      ******************************************************************      */
        /*"      * VERSAO     DATA     RESPONSAVEL       ALTERACAO                *      */
        /*"      ******************************************************************      */
        /*"V.XX  *   VERSAO XX - DEMANDA XXXXXX - XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX*      */
        /*"      *               XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX*      */
        /*"      *               XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX          *      */
        /*"      *                                                                *      */
        /*"      * EM DD/MM/AAAA - XXXXXXXXXXXXXXXXX    PROCURE POR V.XX          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * EM 05/08/2024 - ELIERMES OLIVEIRA D 571176   POR V.00          *      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"01    WS-VLR-ACUMULADO-IS-ATUAL      PIC S9(013)V9(2) COMP-3.*/
        public DoubleBasis WS_VLR_ACUMULADO_IS_ATUAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"01    WORK.*/
        public SPBVG015_WORK WORK { get; set; } = new SPBVG015_WORK();
        public class SPBVG015_WORK : VarBasis
        {
            /*"  05  WS-PROGRAMA                    PIC  X(008) VALUE SPACES.*/
            public StringBasis WS_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"  05  WS-COUNT-REGRA                 PIC  9(003) VALUE ZEROS.*/
            public IntBasis WS_COUNT_REGRA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  05  WS-DATAS.*/
            public SPBVG015_WS_DATAS WS_DATAS { get; set; } = new SPBVG015_WS_DATAS();
            public class SPBVG015_WS_DATAS : VarBasis
            {
                /*"   10 WS-C-DATE-CURRENT              PIC  X(014) VALUE SPACES.*/
                public StringBasis WS_C_DATE_CURRENT { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
                /*"   10 WS-C-DATE-COMPILED             PIC  X(014) VALUE SPACES.*/
                public StringBasis WS_C_DATE_COMPILED { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
                /*"   10 WS-CURRENT-TIMESTAMP           PIC  X(026) VALUE SPACES.*/
                public StringBasis WS_CURRENT_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
                /*"  05  WS-EDIT.*/
            }
            public SPBVG015_WS_EDIT WS_EDIT { get; set; } = new SPBVG015_WS_EDIT();
            public class SPBVG015_WS_EDIT : VarBasis
            {
                /*"   10 WS-SMALLINT                    PIC ZZ.ZZ9- OCCURS 20 TIMES*/
                public ListBasis<IntBasis, Int64> WS_SMALLINT { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "6", "ZZ.ZZ9-"), 20);
                /*"   10 WS-INTEGER                     PIC Z.ZZZ.ZZZ.ZZ9-                                                 OCCURS 5 TIMES.*/
                public ListBasis<IntBasis, Int64> WS_INTEGER { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "11", "Z.ZZZ.ZZZ.ZZ9-"), 5);
                /*"   10 WS-BIGINT                      PIC 99999999999999                                                 OCCURS 5 TIMES.*/
                public ListBasis<IntBasis, Int64> WS_BIGINT { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "14", "99999999999999"), 5);
                /*"   10 WS-DECIMAL                     PIC ZZZZZZZZZZ9,999999                                                 OCCURS 10 TIMES*/
                public ListBasis<DoubleBasis, double> WS_DECIMAL { get; set; } = new ListBasis<DoubleBasis, double>(new PIC("9", "11", "ZZZZZZZZZZ9V999999"), 10);
                /*"   10 WS-TAXA                        PIC 9,99999-                                                 OCCURS 5 TIMES.*/
                public ListBasis<DoubleBasis, double> WS_TAXA { get; set; } = new ListBasis<DoubleBasis, double>(new PIC("9", "1", "9V99999-"), 5);
                /*"  05  WS-ERRO.*/
            }
            public SPBVG015_WS_ERRO WS_ERRO { get; set; } = new SPBVG015_WS_ERRO();
            public class SPBVG015_WS_ERRO : VarBasis
            {
                /*"   10 WS-SECTION                     PIC  X(005) VALUE SPACES.*/
                public StringBasis WS_SECTION { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"   10 WS-IND-ERRO                    PIC  9(001) VALUE 0.*/
                public IntBasis WS_IND_ERRO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
                /*"   10 WS-MENSAGEM                    PIC  X(255) VALUE SPACES.*/
                public StringBasis WS_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "255", "X(255)"), @"");
                /*"   10 WS-TABELA                      PIC  X(050) VALUE SPACES.*/
                public StringBasis WS_TABELA { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
                /*"   10 WS-SQLCODE                     PIC  ZZZZ9-.*/
                public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "6", "ZZZZ9-."));
                /*"   10 WS-SQLERRMC                    PIC  X(076) VALUE SPACES.*/
                public StringBasis WS_SQLERRMC { get; set; } = new StringBasis(new PIC("X", "76", "X(076)"), @"");
                /*"   10 WS-SQLSTATE                    PIC  X(005) VALUE SPACES.*/
                public StringBasis WS_SQLSTATE { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"   10 WS-VLR-ATRIB-A                 PIC  X(050) VALUE SPACES.*/
                public StringBasis WS_VLR_ATRIB_A { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
                /*"   10 WS-VLR-ATRIB-N                 PIC S9(012)V9(5) COMP-3                                                 VALUE 0.*/
                public DoubleBasis WS_VLR_ATRIB_N { get; set; } = new DoubleBasis(new PIC("S9", "12", "S9(012)V9(5)"), 5);
                /*"  05 WS-INDICADORES.*/
            }
            public SPBVG015_WS_INDICADORES WS_INDICADORES { get; set; } = new SPBVG015_WS_INDICADORES();
            public class SPBVG015_WS_INDICADORES : VarBasis
            {
                /*"   10 WS-IND-OK                      PIC  X(001) VALUE SPACES.*/
                public StringBasis WS_IND_OK { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            }
        }


        public Copies.RSGEWSTR RSGEWSTR { get; set; } = new Copies.RSGEWSTR();
        public Copies.SPVG015W SPVG015W { get; set; } = new Copies.SPVG015W();
        public Dclgens.SPGE051W SPGE051W { get; set; } = new Dclgens.SPGE051W();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.VG145 VG145 { get; set; } = new Dclgens.VG145();
        public Dclgens.VG147 VG147 { get; set; } = new Dclgens.VG147();
        public Dclgens.VG141 VG141 { get; set; } = new Dclgens.VG141();
        public Dclgens.VG142 VG142 { get; set; } = new Dclgens.VG142();

        public SPBVG015_SPBVG015_SP015A SPBVG015_SP015A { get; set; } = new SPBVG015_SPBVG015_SP015A(true);
        string GetQuery_SPBVG015_SP015A()
        {
            var query = @$"SELECT A.SEQ_PRODUTO_DPS
							, A.COD_PRODUTO
							, B.SEQ_DPS_REGRA
							, B.NOM_DPS_REGRA
							, B.IND_TP_REGRA
							FROM SEGUROS.VG_PRODUTO_REGRA_DPS A
							, SEGUROS.VG_DPS_REGRA B WHERE A.COD_PRODUTO = '{VG142.DCLVG_PRODUTO_REGRA_DPS.VG142_COD_PRODUTO}' AND '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' BETWEEN DTA_INI_VIGENCIA AND DTA_FIM_VIGENCIA AND B.SEQ_DPS_REGRA = A.SEQ_DPS_REGRA ORDER BY A.SEQ_PRODUTO_DPS";

            return query;
        }


        public SPBVG015_SPBVG015_SP015B SPBVG015_SP015B { get; set; } = new SPBVG015_SPBVG015_SP015B(true);
        string GetQuery_SPBVG015_SP015B()
        {
            var query = @$"SELECT C.SEQ_DPS_ITEM
							, VALUE(C.VLR_NUMR_INICIAL
							,0)
							, VALUE(C.VLR_NUMR_FINAL
							,0)
							, VALUE(C.VLR_ALFA_INICIAL
							,' ')
							, VALUE(C.VLR_ALFA_FINAL
							,' ')
							, C.COD_TP_COMPARACAO
							, D.NOM_DPS_ITEM
							, D.IND_TP_ITEM
							FROM SEGUROS.VG_DPS_REGRA_ITEM C
							, SEGUROS.VG_DPS_ITEM D WHERE C.SEQ_DPS_REGRA = '{VG145.DCLVG_DPS_REGRA.VG145_SEQ_DPS_REGRA}' AND D.SEQ_DPS_ITEM = C.SEQ_DPS_ITEM ORDER BY C.SEQ_DPS_ITEM";

            return query;
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(SPVG015W SPVG015W_P) //PROCEDURE DIVISION USING 
        /*PROCEDURE DIVISION
        LK_VG015_E_TRACE
        LK_VG015_E_IDE_SISTEMA
        LK_VG015_E_COD_USUARIO
        LK_VG015_E_NOM_PROGRAMA
        LK_VG015_E_TIPO_ACAO
        LK_VG015_E_NUM_CPF_CNPJ
        LK_VG015_E_COD_PRODUTO
        LK_VG015_E_VLR_IS
        LK_VG015_S_STA_PROPOSTA
        LK_VG015_S_SEQ_PRODUTO_DPS
        LK_VG015_S_VLR_ACUMULADO_IS
        LK_VG015_IND_ERRO
        LK_VG015_MENSAGEM
        LK_VG015_NOM_TABELA
        LK_VG015_SQLCODE
        LK_VG015_SQLERRMC
        LK_VG015_SQLSTATE
        */
        {
            try
            {
                this.SPVG015W = SPVG015W_P;
                InitializeGetQuery();

                /*" -0- FLUXCONTROL_PERFORM P0000-INICIALIZAR-SECTION */

                P0000_INICIALIZAR_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { SPVG015W };
            return Result;
        }

        public void InitializeGetQuery()
        {
            SPBVG015_SP015A.GetQueryEvent += GetQuery_SPBVG015_SP015A;
            SPBVG015_SP015B.GetQueryEvent += GetQuery_SPBVG015_SP015B;
        }

        [StopWatch]
        /*" P0000-INICIALIZAR-SECTION */
        private void P0000_INICIALIZAR_SECTION()
        {
            /*" -195- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -196- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -197- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -200- MOVE FUNCTION CURRENT-DATE(1:14) TO WS-C-DATE-CURRENT. */
            _.Move(_.CurrentDate(0, 14), WORK.WS_DATAS.WS_C_DATE_CURRENT);

            /*" -203- MOVE FUNCTION WHEN-COMPILED TO WS-C-DATE-COMPILED. */
            _.Move(_.WhenCompiled(), WORK.WS_DATAS.WS_C_DATE_COMPILED);

            /*" -208- INITIALIZE LK-VG015-IND-ERRO LK-VG015-MENSAGEM LK-VG015-NOM-TABELA LK-VG015-SQLCODE LK-VG015-SQLERRMC LK-VG015-SQLSTATE WS-ERRO */
            _.Initialize(
                SPVG015W.LK_VG015_IND_ERRO
                , SPVG015W.LK_VG015_MENSAGEM
                , SPVG015W.LK_VG015_NOM_TABELA
                , SPVG015W.LK_VG015_SQLCODE
                , SPVG015W.LK_VG015_SQLERRMC
                , SPVG015W.LK_VG015_SQLSTATE
                , WORK.WS_ERRO
            );

            /*" -214- INITIALIZE DCLSISTEMAS DCLVG-DPS-REGRA-ITEM DCLVG-DPS-REGRA DCLVG-DPS-ITEM */
            _.Initialize(
                SISTEMAS.DCLSISTEMAS
                , VG141.DCLVG_DPS_REGRA_ITEM
                , VG145.DCLVG_DPS_REGRA
                , VG147.DCLVG_DPS_ITEM
            );

            /*" -215- IF NOT ( LK-VG015-E-TRACE = 'S' OR = 'N' ) */

            if (!(SPVG015W.LK_VG015_E_TRACE.In("S", "N")))
            {

                /*" -216- MOVE 'N' TO LK-VG015-E-TRACE */
                _.Move("N", SPVG015W.LK_VG015_E_TRACE);

                /*" -218- END-IF */
            }


            /*" -220- PERFORM P0050-VERIFICAR-SISTEMA */

            P0050_VERIFICAR_SISTEMA_SECTION();

            /*" -221- MOVE LK-VG015-E-VLR-IS TO WS-DECIMAL(01) */
            _.Move(SPVG015W.LK_VG015_E_VLR_IS, WORK.WS_EDIT.WS_DECIMAL[01]);

            /*" -222- MOVE LK-VG015-E-COD-PRODUTO TO WS-SMALLINT(01) */
            _.Move(SPVG015W.LK_VG015_E_COD_PRODUTO, WORK.WS_EDIT.WS_SMALLINT[01]);

            /*" -223- MOVE LK-VG015-E-NUM-CPF-CNPJ TO WS-BIGINT(01) */
            _.Move(SPVG015W.LK_VG015_E_NUM_CPF_CNPJ, WORK.WS_EDIT.WS_BIGINT[01]);

            /*" -224- DISPLAY '**********************************************' */
            _.Display($"**********************************************");

            /*" -225- DISPLAY '*            S P B V G 0 1 5                 *' */
            _.Display($"*            S P B V G 0 1 5                 *");

            /*" -226- DISPLAY '**********************************************' */
            _.Display($"**********************************************");

            /*" -233- DISPLAY '* DATA COMPILACAO..: ' WS-C-DATE-COMPILED(7:2) '/' WS-C-DATE-COMPILED(5:2) '/' WS-C-DATE-COMPILED(1:4) '-' WS-C-DATE-COMPILED(9:2) ':' WS-C-DATE-COMPILED(11:2) ':' WS-C-DATE-COMPILED(13:2) */

            $"* DATA COMPILACAO..: {WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(7, 2)}/{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(5, 2)}/{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(1, 4)}-{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(9, 2)}:{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(11, 2)}:{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(13, 2)}"
            .Display();

            /*" -240- DISPLAY '* DATA EXECUCAO....: ' WS-C-DATE-CURRENT(7:2) '/' WS-C-DATE-CURRENT(5:2) '/' WS-C-DATE-CURRENT(1:4) '-' WS-C-DATE-CURRENT(9:2) ':' WS-C-DATE-CURRENT(11:2) ':' WS-C-DATE-CURRENT(13:2) */

            $"* DATA EXECUCAO....: {WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(7, 2)}/{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(5, 2)}/{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(1, 4)}-{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(9, 2)}:{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(11, 2)}:{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(13, 2)}"
            .Display();

            /*" -244- DISPLAY '* DATA SISTEMA.....: ' SISTEMAS-DATA-MOV-ABERTO(9:2) '/' SISTEMAS-DATA-MOV-ABERTO(6:2) '/' SISTEMAS-DATA-MOV-ABERTO(1:4) */

            $"* DATA SISTEMA.....: {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2)}/{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2)}/{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4)}"
            .Display();

            /*" -245- DISPLAY '**********************************************' */
            _.Display($"**********************************************");

            /*" -246- DISPLAY '*         DADOS DE ENTRADA SPBVG015          *' */
            _.Display($"*         DADOS DE ENTRADA SPBVG015          *");

            /*" -247- DISPLAY '**********************************************' */
            _.Display($"**********************************************");

            /*" -248- DISPLAY '* IDE-SISTEMA......: ' LK-VG015-E-IDE-SISTEMA */
            _.Display($"* IDE-SISTEMA......: {SPVG015W.LK_VG015_E_IDE_SISTEMA}");

            /*" -249- DISPLAY '* COD-USUARIO......: ' LK-VG015-E-COD-USUARIO */
            _.Display($"* COD-USUARIO......: {SPVG015W.LK_VG015_E_COD_USUARIO}");

            /*" -250- DISPLAY '* NOM-PROGRAMA.....: ' LK-VG015-E-NOM-PROGRAMA */
            _.Display($"* NOM-PROGRAMA.....: {SPVG015W.LK_VG015_E_NOM_PROGRAMA}");

            /*" -251- DISPLAY '* TIPO-ACAO........: ' LK-VG015-E-TIPO-ACAO */
            _.Display($"* TIPO-ACAO........: {SPVG015W.LK_VG015_E_TIPO_ACAO}");

            /*" -252- DISPLAY '* NUM-CPF-CNPJ.....: ' WS-BIGINT(01) */
            _.Display($"* NUM-CPF-CNPJ.....: {WORK.WS_EDIT.WS_BIGINT[1]}");

            /*" -253- DISPLAY '* COD-PRODUTO......: ' WS-SMALLINT(01) */
            _.Display($"* COD-PRODUTO......: {WORK.WS_EDIT.WS_SMALLINT[1]}");

            /*" -254- DISPLAY '* VLR-IS...........: ' WS-DECIMAL(01) */
            _.Display($"* VLR-IS...........: {WORK.WS_EDIT.WS_DECIMAL[1]}");

            /*" -256- DISPLAY '**********************************************' */
            _.Display($"**********************************************");

            /*" -256- PERFORM P0005-PROCESSAR */

            P0005_PROCESSAR_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0000_99_EXIT*/

        [StopWatch]
        /*" P0005-PROCESSAR-SECTION */
        private void P0005_PROCESSAR_SECTION()
        {
            /*" -267- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0005_00_START */

            P0005_00_START();

        }

        [StopWatch]
        /*" P0005-00-START */
        private void P0005_00_START(bool isPerform = false)
        {
            /*" -270- MOVE 'P0005' TO WS-SECTION */
            _.Move("P0005", WORK.WS_ERRO.WS_SECTION);

            /*" -271- IF LK-VG015-E-TRACE = 'S' */

            if (SPVG015W.LK_VG015_E_TRACE == "S")
            {

                /*" -272- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -274- END-IF */
            }


            /*" -275- MOVE SPACES TO LK-VG015-S-STA-PROPOSTA */
            _.Move("", SPVG015W.LK_VG015_S_STA_PROPOSTA);

            /*" -277- MOVE ZEROS TO LK-VG015-S-SEQ-PRODUTO-DPS LK-VG015-S-VLR-ACUMULADO-IS */
            _.Move(0, SPVG015W.LK_VG015_S_SEQ_PRODUTO_DPS, SPVG015W.LK_VG015_S_VLR_ACUMULADO_IS);

            /*" -277- PERFORM P0005-05-INICIO */

            P0005_05_INICIO(true);

        }

        [StopWatch]
        /*" P0005-05-INICIO */
        private void P0005_05_INICIO(bool isPerform = false)
        {
            /*" -283- PERFORM P0100-VALIDAR-LINKAGE. */

            P0100_VALIDAR_LINKAGE_SECTION();

            /*" -284- EVALUATE LK-VG015-E-TIPO-ACAO */
            switch (SPVG015W.LK_VG015_E_TIPO_ACAO.Value)
            {

                /*" -285- WHEN 01 */
                case 01:

                    /*" -286- PERFORM P0302-TRATAR-TIPO-ACAO-01 */

                    P0302_TRATAR_TIPO_ACAO_01_SECTION();

                    /*" -287- WHEN OTHER */
                    break;
                default:

                    /*" -288- MOVE 1 TO WS-IND-ERRO */
                    _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                    /*" -289- MOVE LK-VG015-E-TIPO-ACAO TO WS-SMALLINT(01) */
                    _.Move(SPVG015W.LK_VG015_E_TIPO_ACAO, WORK.WS_EDIT.WS_SMALLINT[01]);

                    /*" -293- STRING WS-SECTION ' - TIPO DE ACAO INFORMADA INVALIDA.' '<TIPO_ACAO=' WS-SMALLINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                    #region STRING
                    var spl1 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                    spl1 += " - TIPO DE ACAO INFORMADA INVALIDA.";
                    spl1 += "<TIPO_ACAO=";
                    var spl2 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                    spl2 += ">";
                    var results3 = spl1 + spl2;
                    _.Move(results3, WORK.WS_ERRO.WS_MENSAGEM);
                    #endregion

                    /*" -296- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                    _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                    /*" -297- MOVE 0 TO WS-SQLCODE */
                    _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                    /*" -298- GO TO P9999-ERRO */

                    P9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -300- END-EVALUATE */
                    break;
            }


            /*" -300- PERFORM P0010-FINALIZAR */

            P0010_FINALIZAR_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0005_99_EXIT*/

        [StopWatch]
        /*" P0010-FINALIZAR-SECTION */
        private void P0010_FINALIZAR_SECTION()
        {
            /*" -310- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0010_00_START */

            P0010_00_START();

        }

        [StopWatch]
        /*" P0010-00-START */
        private void P0010_00_START(bool isPerform = false)
        {
            /*" -313- MOVE 'P0010' TO WS-SECTION */
            _.Move("P0010", WORK.WS_ERRO.WS_SECTION);

            /*" -314- IF LK-VG015-E-TRACE = 'S' */

            if (SPVG015W.LK_VG015_E_TRACE == "S")
            {

                /*" -315- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -317- END-IF. */
            }


            /*" -317- PERFORM P0010-05-INICIO */

            P0010_05_INICIO(true);

        }

        [StopWatch]
        /*" P0010-05-INICIO */
        private void P0010_05_INICIO(bool isPerform = false)
        {
            /*" -323- MOVE 0 TO LK-VG015-IND-ERRO */
            _.Move(0, SPVG015W.LK_VG015_IND_ERRO);

            /*" -326- STRING 'OPERACAO SOLICITADA REALIZADA COM SUCESSO.' DELIMITED BY SIZE INTO LK-VG015-MENSAGEM */
            #region STRING
            var spl3 = "OPERACAO SOLICITADA REALIZADA COM SUCESSO.";
            _.Move(spl3, SPVG015W.LK_VG015_MENSAGEM);
            #endregion

            /*" -330- MOVE SPACES TO LK-VG015-NOM-TABELA LK-VG015-SQLERRMC LK-VG015-SQLSTATE */
            _.Move("", SPVG015W.LK_VG015_NOM_TABELA, SPVG015W.LK_VG015_SQLERRMC, SPVG015W.LK_VG015_SQLSTATE);

            /*" -332- MOVE 0 TO LK-VG015-SQLCODE */
            _.Move(0, SPVG015W.LK_VG015_SQLCODE);

            /*" -332- PERFORM P0010-99-EXIT */

            P0010_99_EXIT(true);

        }

        [StopWatch]
        /*" P0010-99-EXIT */
        private void P0010_99_EXIT(bool isPerform = false)
        {
            /*" -335- GOBACK. */

            throw new GoBack();

        }

        [StopWatch]
        /*" P0050-VERIFICAR-SISTEMA-SECTION */
        private void P0050_VERIFICAR_SISTEMA_SECTION()
        {
            /*" -342- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0050_00_START */

            P0050_00_START();

        }

        [StopWatch]
        /*" P0050-00-START */
        private void P0050_00_START(bool isPerform = false)
        {
            /*" -346- MOVE 'P0050' TO WS-SECTION */
            _.Move("P0050", WORK.WS_ERRO.WS_SECTION);

            /*" -347- IF LK-VG015-E-TRACE = 'S' */

            if (SPVG015W.LK_VG015_E_TRACE == "S")
            {

                /*" -348- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -349- END-IF. */
            }


            /*" -349- PERFORM P0050-05-INICIO */

            P0050_05_INICIO(true);

        }

        [StopWatch]
        /*" P0050-05-INICIO */
        private void P0050_05_INICIO(bool isPerform = false)
        {
            /*" -359- PERFORM P0050_05_INICIO_DB_SELECT_1 */

            P0050_05_INICIO_DB_SELECT_1();

            /*" -362- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -363- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -367- STRING WS-SECTION ' - ERRO NO SELECT NA SEGUROS.SISTEMA.' '<SISTEMA=VG>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl4 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl4 += " - ERRO NO SELECT NA SEGUROS.SISTEMA.";
                spl4 += "<SISTEMA=VG>";
                _.Move(spl4, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -368- MOVE 'SEGUROS.SISTEMAS' TO WS-TABELA */
                _.Move("SEGUROS.SISTEMAS", WORK.WS_ERRO.WS_TABELA);

                /*" -369- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -370- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -371- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -372- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -374- END-IF */
            }


            /*" -375- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -376- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -380- STRING WS-SECTION ' - REGISTRO DE CONTROLE SISTEMA NAO CADASTRADO.' '<SISTEMA=VG>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl5 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl5 += " - REGISTRO DE CONTROLE SISTEMA NAO CADASTRADO.";
                spl5 += "<SISTEMA=VG>";
                _.Move(spl5, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -381- MOVE 'SEGUROS.SISTEMAS' TO WS-TABELA */
                _.Move("SEGUROS.SISTEMAS", WORK.WS_ERRO.WS_TABELA);

                /*" -382- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -383- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -384- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -385- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -385- END-IF. */
            }


        }

        [StopWatch]
        /*" P0050-05-INICIO-DB-SELECT-1 */
        public void P0050_05_INICIO_DB_SELECT_1()
        {
            /*" -359- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VG' WITH UR END-EXEC. */

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
            /*" -395- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0100_00_START */

            P0100_00_START();

        }

        [StopWatch]
        /*" P0100-00-START */
        private void P0100_00_START(bool isPerform = false)
        {
            /*" -398- MOVE 'P0100' TO WS-SECTION */
            _.Move("P0100", WORK.WS_ERRO.WS_SECTION);

            /*" -399- IF LK-VG015-E-TRACE = 'S' */

            if (SPVG015W.LK_VG015_E_TRACE == "S")
            {

                /*" -400- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -402- END-IF. */
            }


            /*" -402- PERFORM P0100-05-INICIO */

            P0100_05_INICIO(true);

        }

        [StopWatch]
        /*" P0100-05-INICIO */
        private void P0100_05_INICIO(bool isPerform = false)
        {
            /*" -407- IF LK-VG015-E-IDE-SISTEMA EQUAL SPACES */

            if (SPVG015W.LK_VG015_E_IDE_SISTEMA.IsEmpty())
            {

                /*" -408- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -412- STRING WS-SECTION ' - IDE-SISTEMA NAO PERTENCE NAO PREVISTA.' '<IDE-SISTEMA=' LK-VG015-E-IDE-SISTEMA '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl6 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl6 += " - IDE-SISTEMA NAO PERTENCE NAO PREVISTA.";
                spl6 += "<IDE-SISTEMA=";
                var spl7 = SPVG015W.LK_VG015_E_IDE_SISTEMA.GetMoveValues();
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

                /*" -419- END-IF */
            }


            /*" -420- IF LK-VG015-E-NUM-CPF-CNPJ = 0 */

            if (SPVG015W.LK_VG015_E_NUM_CPF_CNPJ == 0)
            {

                /*" -421- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -423- MOVE LK-VG015-E-NUM-CPF-CNPJ TO WS-BIGINT(01) */
                _.Move(SPVG015W.LK_VG015_E_NUM_CPF_CNPJ, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -426- STRING WS-SECTION ' - CPF/CNPJ NAO INFORMADO.' '<CPF_CNPJ=' WS-BIGINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl8 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl8 += " - CPF/CNPJ NAO INFORMADO.";
                spl8 += "<CPF_CNPJ=";
                var spl9 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                spl9 += ">";
                var results10 = spl8 + spl9;
                _.Move(results10, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -429- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -430- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -431- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -433- END-IF */
            }


            /*" -434- IF LK-VG015-E-COD-PRODUTO = 0 */

            if (SPVG015W.LK_VG015_E_COD_PRODUTO == 0)
            {

                /*" -435- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -436- MOVE LK-VG015-E-COD-PRODUTO TO WS-SMALLINT(01) */
                _.Move(SPVG015W.LK_VG015_E_COD_PRODUTO, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -439- STRING WS-SECTION ' - PRODUTO NAO INFORMADO.' '<COD-PRODUTO=' WS-SMALLINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl10 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl10 += " - PRODUTO NAO INFORMADO.";
                spl10 += "<COD-PRODUTO=";
                var spl11 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl11 += ">";
                var results12 = spl10 + spl11;
                _.Move(results12, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -442- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -443- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -444- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -446- END-IF */
            }


            /*" -447- IF LK-VG015-E-VLR-IS = 0 */

            if (SPVG015W.LK_VG015_E_VLR_IS == 0)
            {

                /*" -448- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -449- MOVE LK-VG015-E-VLR-IS TO WS-DECIMAL(01) */
                _.Move(SPVG015W.LK_VG015_E_VLR_IS, WORK.WS_EDIT.WS_DECIMAL[01]);

                /*" -452- STRING WS-SECTION ' - VALOR DA IS NAO INFORMADO.' '<VLR-IS= ' WS-DECIMAL(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl12 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl12 += " - VALOR DA IS NAO INFORMADO.";
                spl12 += "<VLR-IS= ";
                var spl13 = WORK.WS_EDIT.WS_DECIMAL[01].GetMoveValues();
                spl13 += ">";
                var results14 = spl12 + spl13;
                _.Move(results14, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -455- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -456- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -457- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -459- END-IF */
            }


            /*" -460- IF LK-VG015-E-COD-USUARIO = SPACES */

            if (SPVG015W.LK_VG015_E_COD_USUARIO.IsEmpty())
            {

                /*" -461- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -464- STRING WS-SECTION ' - CODIGO USUARIO NAO INFORMADO.' '<COD-USUARIO= ' LK-VG015-E-COD-USUARIO '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl14 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl14 += " - CODIGO USUARIO NAO INFORMADO.";
                spl14 += "<COD-USUARIO= ";
                var spl15 = SPVG015W.LK_VG015_E_COD_USUARIO.GetMoveValues();
                spl15 += ">";
                var results16 = spl14 + spl15;
                _.Move(results16, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -467- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -468- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -469- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -471- END-IF */
            }


            /*" -472- IF LK-VG015-E-NOM-PROGRAMA = SPACES */

            if (SPVG015W.LK_VG015_E_NOM_PROGRAMA.IsEmpty())
            {

                /*" -473- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -476- STRING WS-SECTION ' - NOME PROGRAMA NAO INFORMADO.' '<NOM-PROGRAMA= ' LK-VG015-E-NOM-PROGRAMA '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl16 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl16 += " - NOME PROGRAMA NAO INFORMADO.";
                spl16 += "<NOM-PROGRAMA= ";
                var spl17 = SPVG015W.LK_VG015_E_NOM_PROGRAMA.GetMoveValues();
                spl17 += ">";
                var results18 = spl16 + spl17;
                _.Move(results18, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -479- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -480- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -481- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -482- END-IF */
            }


            /*" -482- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0100_99_EXIT*/

        [StopWatch]
        /*" P0302-TRATAR-TIPO-ACAO-01-SECTION */
        private void P0302_TRATAR_TIPO_ACAO_01_SECTION()
        {
            /*" -493- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0302_00_START */

            P0302_00_START();

        }

        [StopWatch]
        /*" P0302-00-START */
        private void P0302_00_START(bool isPerform = false)
        {
            /*" -496- MOVE 'P0302' TO WS-SECTION */
            _.Move("P0302", WORK.WS_ERRO.WS_SECTION);

            /*" -497- IF LK-VG015-E-TRACE = 'S' */

            if (SPVG015W.LK_VG015_E_TRACE == "S")
            {

                /*" -498- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -500- END-IF. */
            }


            /*" -502- MOVE ZEROS TO WS-COUNT-REGRA */
            _.Move(0, WORK.WS_COUNT_REGRA);

            /*" -504- PERFORM P8000-OPEN-SP015A */

            P8000_OPEN_SP015A_SECTION();

            /*" -504- PERFORM P0302-05-INICIO */

            P0302_05_INICIO(true);

        }

        [StopWatch]
        /*" P0302-05-INICIO */
        private void P0302_05_INICIO(bool isPerform = false)
        {
            /*" -516- PERFORM P0302_05_INICIO_DB_FETCH_1 */

            P0302_05_INICIO_DB_FETCH_1();

            /*" -519- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -520- MOVE 'P0302' TO WS-SECTION */
                _.Move("P0302", WORK.WS_ERRO.WS_SECTION);

                /*" -521- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -522- MOVE LK-VG015-E-NUM-CPF-CNPJ TO WS-BIGINT(01) */
                _.Move(SPVG015W.LK_VG015_E_NUM_CPF_CNPJ, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -523- MOVE LK-VG015-E-COD-PRODUTO TO WS-SMALLINT(01) */
                _.Move(SPVG015W.LK_VG015_E_COD_PRODUTO, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -527- STRING WS-SECTION ' - ERRO NO FETCH SPBVG015_SP015A' '<CERTIFICADO=' WS-BIGINT(01) '>' '<PRODUTO=' WS-SMALLINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl18 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl18 += " - ERRO NO FETCH SPBVG015_SP015A";
                spl18 += "<CERTIFICADO=";
                var spl19 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                spl19 += ">";
                spl19 += "<PRODUTO=";
                var spl20 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl20 += ">";
                var results21 = spl18 + spl19 + spl20;
                _.Move(results21, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -529- MOVE 'SPBVG015_SP015A' TO WS-TABELA */
                _.Move("SPBVG015_SP015A", WORK.WS_ERRO.WS_TABELA);

                /*" -530- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -531- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -532- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -533- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -535- END-IF */
            }


            /*" -536- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -537- PERFORM P8001-CLOSE-SP015A */

                P8001_CLOSE_SP015A_SECTION();

                /*" -538- GO TO P0302-99-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P0302_99_EXIT*/ //GOTO
                return;

                /*" -540- END-IF */
            }


            /*" -541- IF SQLCODE = +0 */

            if (DB.SQLCODE == +0)
            {

                /*" -542- ADD 1 TO WS-COUNT-REGRA */
                WORK.WS_COUNT_REGRA.Value = WORK.WS_COUNT_REGRA + 1;

                /*" -544- END-IF */
            }


            /*" -545- IF WS-COUNT-REGRA EQUAL 1 */

            if (WORK.WS_COUNT_REGRA == 1)
            {

                /*" -546- PERFORM P0310-CONSULTA-ACUMULO-RISCO */

                P0310_CONSULTA_ACUMULO_RISCO_SECTION();

                /*" -548- END-IF */
            }


            /*" -550- PERFORM P0402-TRATAR-ITEM-REGRA */

            P0402_TRATAR_ITEM_REGRA_SECTION();

            /*" -551- IF WS-IND-OK = 'S' */

            if (WORK.WS_INDICADORES.WS_IND_OK == "S")
            {

                /*" -553- PERFORM P8001-CLOSE-SP015A */

                P8001_CLOSE_SP015A_SECTION();

                /*" -554- MOVE WS-IND-OK TO LK-VG015-S-STA-PROPOSTA */
                _.Move(WORK.WS_INDICADORES.WS_IND_OK, SPVG015W.LK_VG015_S_STA_PROPOSTA);

                /*" -556- MOVE VG142-SEQ-PRODUTO-DPS TO LK-VG015-S-SEQ-PRODUTO-DPS */
                _.Move(VG142.DCLVG_PRODUTO_REGRA_DPS.VG142_SEQ_PRODUTO_DPS, SPVG015W.LK_VG015_S_SEQ_PRODUTO_DPS);

                /*" -557- GO TO P0302-99-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P0302_99_EXIT*/ //GOTO
                return;

                /*" -559- END-IF */
            }


            /*" -561- GO TO P0302-05-INICIO */
            new Task(() => P0302_05_INICIO()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

            /*" -561- . */

        }

        [StopWatch]
        /*" P0302-05-INICIO-DB-FETCH-1 */
        public void P0302_05_INICIO_DB_FETCH_1()
        {
            /*" -516- EXEC SQL FETCH SPBVG015_SP015A INTO :VG142-SEQ-PRODUTO-DPS, :VG142-COD-PRODUTO, :VG145-SEQ-DPS-REGRA, :VG145-NOM-DPS-REGRA, :VG145-IND-TP-REGRA END-EXEC */

            if (SPBVG015_SP015A.Fetch())
            {
                _.Move(SPBVG015_SP015A.VG142_SEQ_PRODUTO_DPS, VG142.DCLVG_PRODUTO_REGRA_DPS.VG142_SEQ_PRODUTO_DPS);
                _.Move(SPBVG015_SP015A.VG142_COD_PRODUTO, VG142.DCLVG_PRODUTO_REGRA_DPS.VG142_COD_PRODUTO);
                _.Move(SPBVG015_SP015A.VG145_SEQ_DPS_REGRA, VG145.DCLVG_DPS_REGRA.VG145_SEQ_DPS_REGRA);
                _.Move(SPBVG015_SP015A.VG145_NOM_DPS_REGRA, VG145.DCLVG_DPS_REGRA.VG145_NOM_DPS_REGRA);
                _.Move(SPBVG015_SP015A.VG145_IND_TP_REGRA, VG145.DCLVG_DPS_REGRA.VG145_IND_TP_REGRA);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0302_99_EXIT*/

        [StopWatch]
        /*" P0310-CONSULTA-ACUMULO-RISCO-SECTION */
        private void P0310_CONSULTA_ACUMULO_RISCO_SECTION()
        {
            /*" -573- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0310_00_START */

            P0310_00_START();

        }

        [StopWatch]
        /*" P0310-00-START */
        private void P0310_00_START(bool isPerform = false)
        {
            /*" -577- MOVE 'P0310' TO WS-SECTION */
            _.Move("P0310", WORK.WS_ERRO.WS_SECTION);

            /*" -578- IF LK-VG015-E-TRACE = 'S' */

            if (SPVG015W.LK_VG015_E_TRACE == "S")
            {

                /*" -579- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -582- END-IF */
            }


            /*" -603- INITIALIZE LK-GE051-S-QTD-CNTR-PREST LK-GE051-S-VLR-IS-ACUM-PREST LK-GE051-S-DTH-CAD-PREST LK-GE051-S-QTD-CONTR-VIDA LK-GE051-S-VLR-IS-ACUM-VIDA LK-GE051-S-DTH-CAD-VIDA LK-GE051-S-QTD-CNTR-PREV LK-GE051-S-VLR-IS-ACUM-PREV LK-GE051-S-DTH-CAD-PREV LK-GE051-S-QTD-CONTR-HABIT LK-GE051-S-VLR-IS_ACUM-HABIT LK-GE051-S-DTH-CAD-HABIT LK-GE051-S-QTD-TOTAL-CNTR LK-GE051-S-VLR-TOTAL-CNTR LK-GE051-S-DTH-CADASTRAMENTO LK-GE051-IND-ERRO LK-GE051-MSG-ERRO LK-GE051-NOM-TABELA LK-GE051-SQLCODE LK-GE051-SQLERRMC */
            _.Initialize(
                SPGE051W.LK_GE051_S_QTD_CNTR_PREST
                , SPGE051W.LK_GE051_S_VLR_IS_ACUM_PREST
                , SPGE051W.LK_GE051_S_DTH_CAD_PREST
                , SPGE051W.LK_GE051_S_QTD_CONTR_VIDA
                , SPGE051W.LK_GE051_S_VLR_IS_ACUM_VIDA
                , SPGE051W.LK_GE051_S_DTH_CAD_VIDA
                , SPGE051W.LK_GE051_S_QTD_CNTR_PREV
                , SPGE051W.LK_GE051_S_VLR_IS_ACUM_PREV
                , SPGE051W.LK_GE051_S_DTH_CAD_PREV
                , SPGE051W.LK_GE051_S_QTD_CONTR_HABIT
                , SPGE051W.LK_GE051_S_VLR_IS_ACUM_HABIT
                , SPGE051W.LK_GE051_S_DTH_CAD_HABIT
                , SPGE051W.LK_GE051_S_QTD_TOTAL_CNTR
                , SPGE051W.LK_GE051_S_VLR_TOTAL_CNTR
                , SPGE051W.LK_GE051_S_DTH_CADASTRAMENTO
                , SPGE051W.LK_GE051_IND_ERRO
                , SPGE051W.LK_GE051_MSG_ERRO
                , SPGE051W.LK_GE051_NOM_TABELA
                , SPGE051W.LK_GE051_SQLCODE
                , SPGE051W.LK_GE051_SQLERRMC
            );

            /*" -603- PERFORM P0310-05-INICIO */

            P0310_05_INICIO(true);

        }

        [StopWatch]
        /*" P0310-05-INICIO */
        private void P0310_05_INICIO(bool isPerform = false)
        {
            /*" -609- MOVE 'N' TO LK-GE051-TRACE */
            _.Move("N", SPGE051W.LK_GE051_TRACE);

            /*" -611- MOVE LK-VG015-E-NUM-CPF-CNPJ TO LK-GE051-NUM-CPF-CNPJ */
            _.Move(SPVG015W.LK_VG015_E_NUM_CPF_CNPJ, SPGE051W.LK_GE051_NUM_CPF_CNPJ);

            /*" -636- PERFORM P0310_05_INICIO_DB_CALL_1 */

            P0310_05_INICIO_DB_CALL_1();

            /*" -639- IF SQLCODE NOT = 000 */

            if (DB.SQLCODE != 000)
            {

                /*" -640- MOVE 'P0310' TO WS-SECTION */
                _.Move("P0310", WORK.WS_ERRO.WS_SECTION);

                /*" -641- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -642- MOVE LK-GE051-NUM-CPF-CNPJ TO WS-BIGINT(01) */
                _.Move(SPGE051W.LK_GE051_NUM_CPF_CNPJ, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -646- STRING WS-SECTION ' - ERRO NA CHAMADA DA SPBGE051: ' '<CPF-CNPJ=' WS-BIGINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl21 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl21 += " - ERRO NA CHAMADA DA SPBGE051: ";
                spl21 += "<CPF-CNPJ=";
                var spl22 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                spl22 += ">";
                var results23 = spl21 + spl22;
                _.Move(results23, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -647- MOVE LK-GE051-NOM-TABELA TO WS-TABELA */
                _.Move(SPGE051W.LK_GE051_NOM_TABELA, WORK.WS_ERRO.WS_TABELA);

                /*" -648- MOVE LK-GE051-SQLCODE TO WS-SQLCODE */
                _.Move(SPGE051W.LK_GE051_SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -649- MOVE LK-GE051-SQLERRMC TO WS-SQLERRMC */
                _.Move(SPGE051W.LK_GE051_SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -650- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -651- ELSE */
            }
            else
            {


                /*" -652- IF LK-GE051-IND-ERRO NOT = 000 */

                if (SPGE051W.LK_GE051_IND_ERRO != 000)
                {

                    /*" -653- MOVE 'P0310' TO WS-SECTION */
                    _.Move("P0310", WORK.WS_ERRO.WS_SECTION);

                    /*" -654- MOVE 1 TO WS-IND-ERRO */
                    _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                    /*" -655- MOVE LK-GE051-NUM-CPF-CNPJ TO WS-BIGINT(01) */
                    _.Move(SPGE051W.LK_GE051_NUM_CPF_CNPJ, WORK.WS_EDIT.WS_BIGINT[01]);

                    /*" -659- STRING WS-SECTION ' - ERRO NA CHAMADA DA SPBGE051: ' '<CPF-CNPJ=' WS-BIGINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                    #region STRING
                    var spl23 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                    spl23 += " - ERRO NA CHAMADA DA SPBGE051: ";
                    spl23 += "<CPF-CNPJ=";
                    var spl24 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                    spl24 += ">";
                    var results25 = spl23 + spl24;
                    _.Move(results25, WORK.WS_ERRO.WS_MENSAGEM);
                    #endregion

                    /*" -660- MOVE LK-GE051-NOM-TABELA TO WS-TABELA */
                    _.Move(SPGE051W.LK_GE051_NOM_TABELA, WORK.WS_ERRO.WS_TABELA);

                    /*" -661- MOVE LK-GE051-SQLCODE TO WS-SQLCODE */
                    _.Move(SPGE051W.LK_GE051_SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                    /*" -662- MOVE LK-GE051-SQLERRMC TO WS-SQLERRMC */
                    _.Move(SPGE051W.LK_GE051_SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                    /*" -663- GO TO P9999-ERRO */

                    P9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -664- END-IF */
                }


                /*" -666- END-IF */
            }


            /*" -669- COMPUTE WS-VLR-ACUMULADO-IS-ATUAL = LK-GE051-S-VLR-TOTAL-CNTR + LK-VG015-E-VLR-IS */
            WS_VLR_ACUMULADO_IS_ATUAL.Value = SPGE051W.LK_GE051_S_VLR_TOTAL_CNTR + SPVG015W.LK_VG015_E_VLR_IS;

            /*" -671- MOVE WS-VLR-ACUMULADO-IS-ATUAL TO LK-VG015-S-VLR-ACUMULADO-IS */
            _.Move(WS_VLR_ACUMULADO_IS_ATUAL, SPVG015W.LK_VG015_S_VLR_ACUMULADO_IS);

            /*" -672- IF LK-VG015-E-TRACE = 'S' */

            if (SPVG015W.LK_VG015_E_TRACE == "S")
            {

                /*" -673- MOVE LK-VG015-E-VLR-IS TO WS-DECIMAL (01) */
                _.Move(SPVG015W.LK_VG015_E_VLR_IS, WORK.WS_EDIT.WS_DECIMAL[01]);

                /*" -674- MOVE LK-GE051-S-QTD-TOTAL-CNTR TO WS-SMALLINT(01) */
                _.Move(SPGE051W.LK_GE051_S_QTD_TOTAL_CNTR, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -675- MOVE LK-GE051-S-VLR-TOTAL-CNTR TO WS-DECIMAL (02) */
                _.Move(SPGE051W.LK_GE051_S_VLR_TOTAL_CNTR, WORK.WS_EDIT.WS_DECIMAL[02]);

                /*" -677- MOVE WS-VLR-ACUMULADO-IS-ATUAL TO WS-DECIMAL (03) */
                _.Move(WS_VLR_ACUMULADO_IS_ATUAL, WORK.WS_EDIT.WS_DECIMAL[03]);

                /*" -678- DISPLAY 'GE051-S-QTD-TOTAL-CNTR >> ' WS-SMALLINT(01) */
                _.Display($"GE051-S-QTD-TOTAL-CNTR >> {WORK.WS_EDIT.WS_SMALLINT[1]}");

                /*" -679- DISPLAY 'VG015-E-VLR-IS         >> ' WS-DECIMAL (01) */
                _.Display($"VG015-E-VLR-IS         >> {WORK.WS_EDIT.WS_DECIMAL[1]}");

                /*" -680- DISPLAY 'GE051-S-VLR-TOTAL-CNTR >> ' WS-DECIMAL (02) */
                _.Display($"GE051-S-VLR-TOTAL-CNTR >> {WORK.WS_EDIT.WS_DECIMAL[2]}");

                /*" -681- DISPLAY 'VLR-ACUMULADO-IS-ATUAL >> ' WS-DECIMAL (03) */
                _.Display($"VLR-ACUMULADO-IS-ATUAL >> {WORK.WS_EDIT.WS_DECIMAL[3]}");

                /*" -682- END-IF */
            }


            /*" -682- . */

        }

        [StopWatch]
        /*" P0310-05-INICIO-DB-CALL-1 */
        public void P0310_05_INICIO_DB_CALL_1()
        {
            /*" -636- EXEC SQL CALL SEGUROS.SPBGE051 ( :LK-GE051-TRACE , :LK-GE051-NUM-CPF-CNPJ , :LK-GE051-S-QTD-CNTR-PREST , :LK-GE051-S-VLR-IS-ACUM-PREST , :LK-GE051-S-DTH-CAD-PREST , :LK-GE051-S-QTD-CONTR-VIDA , :LK-GE051-S-VLR-IS-ACUM-VIDA , :LK-GE051-S-DTH-CAD-VIDA , :LK-GE051-S-QTD-CNTR-PREV , :LK-GE051-S-VLR-IS-ACUM-PREV , :LK-GE051-S-DTH-CAD-PREV , :LK-GE051-S-QTD-CONTR-HABIT , :LK-GE051-S-VLR-IS_ACUM-HABIT , :LK-GE051-S-DTH-CAD-HABIT , :LK-GE051-S-QTD-TOTAL-CNTR , :LK-GE051-S-VLR-TOTAL-CNTR , :LK-GE051-S-DTH-CADASTRAMENTO , :LK-GE051-IND-ERRO , :LK-GE051-MSG-ERRO , :LK-GE051-NOM-TABELA , :LK-GE051-SQLCODE , :LK-GE051-SQLERRMC ) END-EXEC */

            var sEGUROS_SPBGE051_Call1 = new SEGUROS_SPBGE051_Call1()
            {
                LK_GE051_TRACE = SPGE051W.LK_GE051_TRACE.ToString(),
                LK_GE051_NUM_CPF_CNPJ = SPGE051W.LK_GE051_NUM_CPF_CNPJ.ToString(),
                LK_GE051_S_QTD_CNTR_PREST = SPGE051W.LK_GE051_S_QTD_CNTR_PREST.ToString(),
                LK_GE051_S_VLR_IS_ACUM_PREST = SPGE051W.LK_GE051_S_VLR_IS_ACUM_PREST.ToString(),
                LK_GE051_S_DTH_CAD_PREST = SPGE051W.LK_GE051_S_DTH_CAD_PREST.ToString(),
                LK_GE051_S_QTD_CONTR_VIDA = SPGE051W.LK_GE051_S_QTD_CONTR_VIDA.ToString(),
                LK_GE051_S_VLR_IS_ACUM_VIDA = SPGE051W.LK_GE051_S_VLR_IS_ACUM_VIDA.ToString(),
                LK_GE051_S_DTH_CAD_VIDA = SPGE051W.LK_GE051_S_DTH_CAD_VIDA.ToString(),
                LK_GE051_S_QTD_CNTR_PREV = SPGE051W.LK_GE051_S_QTD_CNTR_PREV.ToString(),
                LK_GE051_S_VLR_IS_ACUM_PREV = SPGE051W.LK_GE051_S_VLR_IS_ACUM_PREV.ToString(),
                LK_GE051_S_DTH_CAD_PREV = SPGE051W.LK_GE051_S_DTH_CAD_PREV.ToString(),
                LK_GE051_S_QTD_CONTR_HABIT = SPGE051W.LK_GE051_S_QTD_CONTR_HABIT.ToString(),
                LK_GE051_S_VLR_IS_ACUM_HABIT = SPGE051W.LK_GE051_S_VLR_IS_ACUM_HABIT.ToString(),
                LK_GE051_S_DTH_CAD_HABIT = SPGE051W.LK_GE051_S_DTH_CAD_HABIT.ToString(),
                LK_GE051_S_QTD_TOTAL_CNTR = SPGE051W.LK_GE051_S_QTD_TOTAL_CNTR.ToString(),
                LK_GE051_S_VLR_TOTAL_CNTR = SPGE051W.LK_GE051_S_VLR_TOTAL_CNTR.ToString(),
                LK_GE051_S_DTH_CADASTRAMENTO = SPGE051W.LK_GE051_S_DTH_CADASTRAMENTO.ToString(),
                LK_GE051_IND_ERRO = SPGE051W.LK_GE051_IND_ERRO.ToString(),
                LK_GE051_MSG_ERRO = SPGE051W.LK_GE051_MSG_ERRO.ToString(),
                LK_GE051_NOM_TABELA = SPGE051W.LK_GE051_NOM_TABELA.ToString(),
                LK_GE051_SQLCODE = SPGE051W.LK_GE051_SQLCODE.ToString(),
                LK_GE051_SQLERRMC = SPGE051W.LK_GE051_SQLERRMC.ToString(),
            };

            var executed_1 = SEGUROS_SPBGE051_Call1.Execute(sEGUROS_SPBGE051_Call1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LK_GE051_TRACE, SPGE051W.LK_GE051_TRACE);
                _.Move(executed_1.LK_GE051_NUM_CPF_CNPJ, SPGE051W.LK_GE051_NUM_CPF_CNPJ);
                _.Move(executed_1.LK_GE051_S_QTD_CNTR_PREST, SPGE051W.LK_GE051_S_QTD_CNTR_PREST);
                _.Move(executed_1.LK_GE051_S_VLR_IS_ACUM_PREST, SPGE051W.LK_GE051_S_VLR_IS_ACUM_PREST);
                _.Move(executed_1.LK_GE051_S_DTH_CAD_PREST, SPGE051W.LK_GE051_S_DTH_CAD_PREST);
                _.Move(executed_1.LK_GE051_S_QTD_CONTR_VIDA, SPGE051W.LK_GE051_S_QTD_CONTR_VIDA);
                _.Move(executed_1.LK_GE051_S_VLR_IS_ACUM_VIDA, SPGE051W.LK_GE051_S_VLR_IS_ACUM_VIDA);
                _.Move(executed_1.LK_GE051_S_DTH_CAD_VIDA, SPGE051W.LK_GE051_S_DTH_CAD_VIDA);
                _.Move(executed_1.LK_GE051_S_QTD_CNTR_PREV, SPGE051W.LK_GE051_S_QTD_CNTR_PREV);
                _.Move(executed_1.LK_GE051_S_VLR_IS_ACUM_PREV, SPGE051W.LK_GE051_S_VLR_IS_ACUM_PREV);
                _.Move(executed_1.LK_GE051_S_DTH_CAD_PREV, SPGE051W.LK_GE051_S_DTH_CAD_PREV);
                _.Move(executed_1.LK_GE051_S_QTD_CONTR_HABIT, SPGE051W.LK_GE051_S_QTD_CONTR_HABIT);
                _.Move(executed_1.LK_GE051_S_VLR_IS_ACUM_HABIT, SPGE051W.LK_GE051_S_VLR_IS_ACUM_HABIT);
                _.Move(executed_1.LK_GE051_S_DTH_CAD_HABIT, SPGE051W.LK_GE051_S_DTH_CAD_HABIT);
                _.Move(executed_1.LK_GE051_S_QTD_TOTAL_CNTR, SPGE051W.LK_GE051_S_QTD_TOTAL_CNTR);
                _.Move(executed_1.LK_GE051_S_VLR_TOTAL_CNTR, SPGE051W.LK_GE051_S_VLR_TOTAL_CNTR);
                _.Move(executed_1.LK_GE051_S_DTH_CADASTRAMENTO, SPGE051W.LK_GE051_S_DTH_CADASTRAMENTO);
                _.Move(executed_1.LK_GE051_IND_ERRO, SPGE051W.LK_GE051_IND_ERRO);
                _.Move(executed_1.LK_GE051_MSG_ERRO, SPGE051W.LK_GE051_MSG_ERRO);
                _.Move(executed_1.LK_GE051_NOM_TABELA, SPGE051W.LK_GE051_NOM_TABELA);
                _.Move(executed_1.LK_GE051_SQLCODE, SPGE051W.LK_GE051_SQLCODE);
                _.Move(executed_1.LK_GE051_SQLERRMC, SPGE051W.LK_GE051_SQLERRMC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0310_99_EXIT*/

        [StopWatch]
        /*" P0315-ANALISAR-REGRAS-SECTION */
        private void P0315_ANALISAR_REGRAS_SECTION()
        {
            /*" -693- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0315_00_START */

            P0315_00_START();

        }

        [StopWatch]
        /*" P0315-00-START */
        private void P0315_00_START(bool isPerform = false)
        {
            /*" -696- MOVE 'P0315' TO WS-SECTION */
            _.Move("P0315", WORK.WS_ERRO.WS_SECTION);

            /*" -697- IF LK-VG015-E-TRACE = 'S' */

            if (SPVG015W.LK_VG015_E_TRACE == "S")
            {

                /*" -698- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -699- MOVE VG141-VLR-NUMR-INICIAL TO WS-DECIMAL(01) */
                _.Move(VG141.DCLVG_DPS_REGRA_ITEM.VG141_VLR_NUMR_INICIAL, WORK.WS_EDIT.WS_DECIMAL[01]);

                /*" -700- MOVE VG141-VLR-NUMR-FINAL TO WS-DECIMAL(02) */
                _.Move(VG141.DCLVG_DPS_REGRA_ITEM.VG141_VLR_NUMR_FINAL, WORK.WS_EDIT.WS_DECIMAL[02]);

                /*" -701- DISPLAY '------------------------------------------------' */
                _.Display($"------------------------------------------------");

                /*" -702- DISPLAY 'SEQ-DPS-ITEM      >' VG141-SEQ-DPS-ITEM '<' */

                $"SEQ-DPS-ITEM      >{VG141.DCLVG_DPS_REGRA_ITEM.VG141_SEQ_DPS_ITEM}<"
                .Display();

                /*" -703- DISPLAY 'VLR-NUMR-INICIAL  >' WS-DECIMAL(01) '<' */

                $"VLR-NUMR-INICIAL  >{WORK.WS_EDIT.WS_DECIMAL[1]}<"
                .Display();

                /*" -704- DISPLAY 'VLR-NUMR-FINAL    >' WS-DECIMAL(02) '<' */

                $"VLR-NUMR-FINAL    >{WORK.WS_EDIT.WS_DECIMAL[2]}<"
                .Display();

                /*" -705- DISPLAY 'VLR-ALFA-INICIAL  >' VG141-VLR-ALFA-INICIAL '<' */

                $"VLR-ALFA-INICIAL  >{VG141.DCLVG_DPS_REGRA_ITEM.VG141_VLR_ALFA_INICIAL}<"
                .Display();

                /*" -706- DISPLAY 'VLR-ALFA-FINAL    >' VG141-VLR-ALFA-FINAL '<' */

                $"VLR-ALFA-FINAL    >{VG141.DCLVG_DPS_REGRA_ITEM.VG141_VLR_ALFA_FINAL}<"
                .Display();

                /*" -707- DISPLAY 'COD-TP-COMPARACAO >' VG141-COD-TP-COMPARACAO '<' */

                $"COD-TP-COMPARACAO >{VG141.DCLVG_DPS_REGRA_ITEM.VG141_COD_TP_COMPARACAO}<"
                .Display();

                /*" -708- DISPLAY 'NOM-DPS-ITEM      >' VG147-NOM-DPS-ITEM '<' */

                $"NOM-DPS-ITEM      >{VG147.DCLVG_DPS_ITEM.VG147_NOM_DPS_ITEM}<"
                .Display();

                /*" -709- DISPLAY 'IND-TP-ITEM       >' VG147-IND-TP-ITEM '<' */

                $"IND-TP-ITEM       >{VG147.DCLVG_DPS_ITEM.VG147_IND_TP_ITEM}<"
                .Display();

                /*" -710- DISPLAY '------------------------------------------------' */
                _.Display($"------------------------------------------------");

                /*" -712- END-IF */
            }


            /*" -712- PERFORM P0315-05-INICIO */

            P0315_05_INICIO(true);

        }

        [StopWatch]
        /*" P0315-05-INICIO */
        private void P0315_05_INICIO(bool isPerform = false)
        {
            /*" -718-  EVALUATE TRUE  */

            /*" -719-  WHEN VG147-NOM-DPS-ITEM      = 'VL_IS'  */

            /*" -719- IF VG147-NOM-DPS-ITEM      = 'VL_IS' */

            if (VG147.DCLVG_DPS_ITEM.VG147_NOM_DPS_ITEM == "VL_IS")
            {

                /*" -720- MOVE LK-VG015-E-VLR-IS TO WS-VLR-ATRIB-N */
                _.Move(SPVG015W.LK_VG015_E_VLR_IS, WORK.WS_ERRO.WS_VLR_ATRIB_N);

                /*" -721-  WHEN VG147-NOM-DPS-ITEM      = 'VL_IS_ACUMULADO'  */

                /*" -721- ELSE IF VG147-NOM-DPS-ITEM      = 'VL_IS_ACUMULADO' */
            }
            else

            if (VG147.DCLVG_DPS_ITEM.VG147_NOM_DPS_ITEM == "VL_IS_ACUMULADO")
            {

                /*" -723- MOVE WS-VLR-ACUMULADO-IS-ATUAL TO WS-VLR-ATRIB-N */
                _.Move(WS_VLR_ACUMULADO_IS_ATUAL, WORK.WS_ERRO.WS_VLR_ATRIB_N);

                /*" -724-  WHEN OTHER  */

                /*" -724- ELSE */
            }
            else
            {


                /*" -725- MOVE 'P0315' TO WS-SECTION */
                _.Move("P0315", WORK.WS_ERRO.WS_SECTION);

                /*" -726- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -730- STRING WS-SECTION ' - ITEM DE COMPARACAO NAO PREVISTO: ' '<NOM-DPS-ITEM=' VG147-NOM-DPS-ITEM '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl25 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl25 += " - ITEM DE COMPARACAO NAO PREVISTO: ";
                spl25 += "<NOM-DPS-ITEM=";
                var spl26 = VG147.DCLVG_DPS_ITEM.VG147_NOM_DPS_ITEM.GetMoveValues();
                spl26 += ">";
                var results27 = spl25 + spl26;
                _.Move(results27, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -731- MOVE 'SPBVG015_SP015A' TO WS-TABELA */
                _.Move("SPBVG015_SP015A", WORK.WS_ERRO.WS_TABELA);

                /*" -732- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -733- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -734- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -735- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -741-  END-EVALUATE  */

                /*" -741- END-IF */
            }


            /*" -742- IF VG147-IND-TP-ITEM = 'A' */

            if (VG147.DCLVG_DPS_ITEM.VG147_IND_TP_ITEM == "A")
            {

                /*" -743-  EVALUATE TRUE  */

                /*" -744-  WHEN VG141-COD-TP-COMPARACAO = 'EQ'  */

                /*" -744- IF VG141-COD-TP-COMPARACAO = 'EQ' */

                if (VG141.DCLVG_DPS_REGRA_ITEM.VG141_COD_TP_COMPARACAO == "EQ")
                {

                    /*" -745- IF WS-VLR-ATRIB-A = VG141-VLR-ALFA-INICIAL */

                    if (WORK.WS_ERRO.WS_VLR_ATRIB_A == VG141.DCLVG_DPS_REGRA_ITEM.VG141_VLR_ALFA_INICIAL)
                    {

                        /*" -746- MOVE 'S' TO WS-IND-OK */
                        _.Move("S", WORK.WS_INDICADORES.WS_IND_OK);

                        /*" -747- END-IF */
                    }


                    /*" -748-  WHEN VG141-COD-TP-COMPARACAO = 'NE'  */

                    /*" -748- ELSE IF VG141-COD-TP-COMPARACAO = 'NE' */
                }
                else

                if (VG141.DCLVG_DPS_REGRA_ITEM.VG141_COD_TP_COMPARACAO == "NE")
                {

                    /*" -749- IF WS-VLR-ATRIB-A NOT = VG141-VLR-ALFA-INICIAL */

                    if (WORK.WS_ERRO.WS_VLR_ATRIB_A != VG141.DCLVG_DPS_REGRA_ITEM.VG141_VLR_ALFA_INICIAL)
                    {

                        /*" -750- MOVE 'S' TO WS-IND-OK */
                        _.Move("S", WORK.WS_INDICADORES.WS_IND_OK);

                        /*" -751- END-IF */
                    }


                    /*" -752-  WHEN VG141-COD-TP-COMPARACAO = 'LT'  */

                    /*" -752- ELSE IF VG141-COD-TP-COMPARACAO = 'LT' */
                }
                else

                if (VG141.DCLVG_DPS_REGRA_ITEM.VG141_COD_TP_COMPARACAO == "LT")
                {

                    /*" -753- IF WS-VLR-ATRIB-A < VG141-VLR-ALFA-INICIAL */

                    if (WORK.WS_ERRO.WS_VLR_ATRIB_A < VG141.DCLVG_DPS_REGRA_ITEM.VG141_VLR_ALFA_INICIAL)
                    {

                        /*" -754- MOVE 'S' TO WS-IND-OK */
                        _.Move("S", WORK.WS_INDICADORES.WS_IND_OK);

                        /*" -755- END-IF */
                    }


                    /*" -756-  WHEN VG141-COD-TP-COMPARACAO = 'LE'  */

                    /*" -756- ELSE IF VG141-COD-TP-COMPARACAO = 'LE' */
                }
                else

                if (VG141.DCLVG_DPS_REGRA_ITEM.VG141_COD_TP_COMPARACAO == "LE")
                {

                    /*" -757- IF WS-VLR-ATRIB-A <= VG141-VLR-ALFA-INICIAL */

                    if (WORK.WS_ERRO.WS_VLR_ATRIB_A <= VG141.DCLVG_DPS_REGRA_ITEM.VG141_VLR_ALFA_INICIAL)
                    {

                        /*" -758- MOVE 'S' TO WS-IND-OK */
                        _.Move("S", WORK.WS_INDICADORES.WS_IND_OK);

                        /*" -759- END-IF */
                    }


                    /*" -760-  WHEN VG141-COD-TP-COMPARACAO = 'GT'  */

                    /*" -760- ELSE IF VG141-COD-TP-COMPARACAO = 'GT' */
                }
                else

                if (VG141.DCLVG_DPS_REGRA_ITEM.VG141_COD_TP_COMPARACAO == "GT")
                {

                    /*" -761- IF WS-VLR-ATRIB-A > VG141-VLR-ALFA-INICIAL */

                    if (WORK.WS_ERRO.WS_VLR_ATRIB_A > VG141.DCLVG_DPS_REGRA_ITEM.VG141_VLR_ALFA_INICIAL)
                    {

                        /*" -762- MOVE 'S' TO WS-IND-OK */
                        _.Move("S", WORK.WS_INDICADORES.WS_IND_OK);

                        /*" -763- END-IF */
                    }


                    /*" -764-  WHEN VG141-COD-TP-COMPARACAO = 'GE'  */

                    /*" -764- ELSE IF VG141-COD-TP-COMPARACAO = 'GE' */
                }
                else

                if (VG141.DCLVG_DPS_REGRA_ITEM.VG141_COD_TP_COMPARACAO == "GE")
                {

                    /*" -765- IF WS-VLR-ATRIB-A >= VG141-VLR-ALFA-INICIAL */

                    if (WORK.WS_ERRO.WS_VLR_ATRIB_A >= VG141.DCLVG_DPS_REGRA_ITEM.VG141_VLR_ALFA_INICIAL)
                    {

                        /*" -766- MOVE 'S' TO WS-IND-OK */
                        _.Move("S", WORK.WS_INDICADORES.WS_IND_OK);

                        /*" -767- END-IF */
                    }


                    /*" -768-  WHEN VG141-COD-TP-COMPARACAO = 'BT'  */

                    /*" -768- ELSE IF VG141-COD-TP-COMPARACAO = 'BT' */
                }
                else

                if (VG141.DCLVG_DPS_REGRA_ITEM.VG141_COD_TP_COMPARACAO == "BT")
                {

                    /*" -770- IF (WS-VLR-ATRIB-A >= VG141-VLR-ALFA-INICIAL) AND (WS-VLR-ATRIB-A <= VG141-VLR-ALFA-FINAL) */

                    if ((WORK.WS_ERRO.WS_VLR_ATRIB_A >= VG141.DCLVG_DPS_REGRA_ITEM.VG141_VLR_ALFA_INICIAL) && (WORK.WS_ERRO.WS_VLR_ATRIB_A <= VG141.DCLVG_DPS_REGRA_ITEM.VG141_VLR_ALFA_FINAL))
                    {

                        /*" -771- MOVE 'S' TO WS-IND-OK */
                        _.Move("S", WORK.WS_INDICADORES.WS_IND_OK);

                        /*" -772- END-IF */
                    }


                    /*" -773-  END-EVALUATE  */

                    /*" -773- END-IF */
                }


                /*" -776- END-IF */
            }


            /*" -777- IF VG147-IND-TP-ITEM = 'N' */

            if (VG147.DCLVG_DPS_ITEM.VG147_IND_TP_ITEM == "N")
            {

                /*" -778-  EVALUATE TRUE  */

                /*" -779-  WHEN VG141-COD-TP-COMPARACAO = 'EQ'  */

                /*" -779- IF VG141-COD-TP-COMPARACAO = 'EQ' */

                if (VG141.DCLVG_DPS_REGRA_ITEM.VG141_COD_TP_COMPARACAO == "EQ")
                {

                    /*" -780- IF WS-VLR-ATRIB-N = VG141-VLR-NUMR-INICIAL */

                    if (WORK.WS_ERRO.WS_VLR_ATRIB_N == VG141.DCLVG_DPS_REGRA_ITEM.VG141_VLR_NUMR_INICIAL)
                    {

                        /*" -781- MOVE 'S' TO WS-IND-OK */
                        _.Move("S", WORK.WS_INDICADORES.WS_IND_OK);

                        /*" -782- END-IF */
                    }


                    /*" -783-  WHEN VG141-COD-TP-COMPARACAO = 'NE'  */

                    /*" -783- ELSE IF VG141-COD-TP-COMPARACAO = 'NE' */
                }
                else

                if (VG141.DCLVG_DPS_REGRA_ITEM.VG141_COD_TP_COMPARACAO == "NE")
                {

                    /*" -784- IF WS-VLR-ATRIB-N NOT = VG141-VLR-NUMR-INICIAL */

                    if (WORK.WS_ERRO.WS_VLR_ATRIB_N != VG141.DCLVG_DPS_REGRA_ITEM.VG141_VLR_NUMR_INICIAL)
                    {

                        /*" -785- MOVE 'S' TO WS-IND-OK */
                        _.Move("S", WORK.WS_INDICADORES.WS_IND_OK);

                        /*" -786- END-IF */
                    }


                    /*" -787-  WHEN VG141-COD-TP-COMPARACAO = 'LT'  */

                    /*" -787- ELSE IF VG141-COD-TP-COMPARACAO = 'LT' */
                }
                else

                if (VG141.DCLVG_DPS_REGRA_ITEM.VG141_COD_TP_COMPARACAO == "LT")
                {

                    /*" -788- IF WS-VLR-ATRIB-N < VG141-VLR-NUMR-INICIAL */

                    if (WORK.WS_ERRO.WS_VLR_ATRIB_N < VG141.DCLVG_DPS_REGRA_ITEM.VG141_VLR_NUMR_INICIAL)
                    {

                        /*" -789- MOVE 'S' TO WS-IND-OK */
                        _.Move("S", WORK.WS_INDICADORES.WS_IND_OK);

                        /*" -790- END-IF */
                    }


                    /*" -791-  WHEN VG141-COD-TP-COMPARACAO = 'LE'  */

                    /*" -791- ELSE IF VG141-COD-TP-COMPARACAO = 'LE' */
                }
                else

                if (VG141.DCLVG_DPS_REGRA_ITEM.VG141_COD_TP_COMPARACAO == "LE")
                {

                    /*" -792- IF WS-VLR-ATRIB-N <= VG141-VLR-NUMR-INICIAL */

                    if (WORK.WS_ERRO.WS_VLR_ATRIB_N <= VG141.DCLVG_DPS_REGRA_ITEM.VG141_VLR_NUMR_INICIAL)
                    {

                        /*" -793- MOVE 'S' TO WS-IND-OK */
                        _.Move("S", WORK.WS_INDICADORES.WS_IND_OK);

                        /*" -794- END-IF */
                    }


                    /*" -795-  WHEN VG141-COD-TP-COMPARACAO = 'GT'  */

                    /*" -795- ELSE IF VG141-COD-TP-COMPARACAO = 'GT' */
                }
                else

                if (VG141.DCLVG_DPS_REGRA_ITEM.VG141_COD_TP_COMPARACAO == "GT")
                {

                    /*" -796- IF WS-VLR-ATRIB-N > VG141-VLR-NUMR-INICIAL */

                    if (WORK.WS_ERRO.WS_VLR_ATRIB_N > VG141.DCLVG_DPS_REGRA_ITEM.VG141_VLR_NUMR_INICIAL)
                    {

                        /*" -797- MOVE 'S' TO WS-IND-OK */
                        _.Move("S", WORK.WS_INDICADORES.WS_IND_OK);

                        /*" -798- END-IF */
                    }


                    /*" -799-  WHEN VG141-COD-TP-COMPARACAO = 'GE'  */

                    /*" -799- ELSE IF VG141-COD-TP-COMPARACAO = 'GE' */
                }
                else

                if (VG141.DCLVG_DPS_REGRA_ITEM.VG141_COD_TP_COMPARACAO == "GE")
                {

                    /*" -800- IF WS-VLR-ATRIB-N >= VG141-VLR-NUMR-INICIAL */

                    if (WORK.WS_ERRO.WS_VLR_ATRIB_N >= VG141.DCLVG_DPS_REGRA_ITEM.VG141_VLR_NUMR_INICIAL)
                    {

                        /*" -801- MOVE 'S' TO WS-IND-OK */
                        _.Move("S", WORK.WS_INDICADORES.WS_IND_OK);

                        /*" -802- END-IF */
                    }


                    /*" -803-  WHEN VG141-COD-TP-COMPARACAO = 'BT'  */

                    /*" -803- ELSE IF VG141-COD-TP-COMPARACAO = 'BT' */
                }
                else

                if (VG141.DCLVG_DPS_REGRA_ITEM.VG141_COD_TP_COMPARACAO == "BT")
                {

                    /*" -805- IF (WS-VLR-ATRIB-N >= VG141-VLR-NUMR-INICIAL) AND (WS-VLR-ATRIB-N <= VG141-VLR-NUMR-FINAL) */

                    if ((WORK.WS_ERRO.WS_VLR_ATRIB_N >= VG141.DCLVG_DPS_REGRA_ITEM.VG141_VLR_NUMR_INICIAL) && (WORK.WS_ERRO.WS_VLR_ATRIB_N <= VG141.DCLVG_DPS_REGRA_ITEM.VG141_VLR_NUMR_FINAL))
                    {

                        /*" -806- MOVE 'S' TO WS-IND-OK */
                        _.Move("S", WORK.WS_INDICADORES.WS_IND_OK);

                        /*" -807- END-IF */
                    }


                    /*" -808-  END-EVALUATE  */

                    /*" -808- END-IF */
                }


                /*" -810- END-IF */
            }


            /*" -810- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0315_99_EXIT*/

        [StopWatch]
        /*" P0402-TRATAR-ITEM-REGRA-SECTION */
        private void P0402_TRATAR_ITEM_REGRA_SECTION()
        {
            /*" -820- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0402_00_START */

            P0402_00_START();

        }

        [StopWatch]
        /*" P0402-00-START */
        private void P0402_00_START(bool isPerform = false)
        {
            /*" -823- MOVE 'P0402' TO WS-SECTION */
            _.Move("P0402", WORK.WS_ERRO.WS_SECTION);

            /*" -824- IF LK-VG015-E-TRACE = 'S' */

            if (SPVG015W.LK_VG015_E_TRACE == "S")
            {

                /*" -825- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -827- END-IF. */
            }


            /*" -830- MOVE 'N' TO WS-IND-OK LK-VG015-S-STA-PROPOSTA */
            _.Move("N", WORK.WS_INDICADORES.WS_IND_OK, SPVG015W.LK_VG015_S_STA_PROPOSTA);

            /*" -832- PERFORM P8100-OPEN-SP015B */

            P8100_OPEN_SP015B_SECTION();

            /*" -833- IF LK-VG015-E-TRACE = 'S' */

            if (SPVG015W.LK_VG015_E_TRACE == "S")
            {

                /*" -834- DISPLAY 'VG145-SEQ-DPS-REGRA >> ' VG145-SEQ-DPS-REGRA */
                _.Display($"VG145-SEQ-DPS-REGRA >> {VG145.DCLVG_DPS_REGRA.VG145_SEQ_DPS_REGRA}");

                /*" -836- END-IF */
            }


            /*" -836- PERFORM P0402-05-INICIO */

            P0402_05_INICIO(true);

        }

        [StopWatch]
        /*" P0402-05-INICIO */
        private void P0402_05_INICIO(bool isPerform = false)
        {
            /*" -851- PERFORM P0402_05_INICIO_DB_FETCH_1 */

            P0402_05_INICIO_DB_FETCH_1();

            /*" -854- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -855- MOVE 'P0402' TO WS-SECTION */
                _.Move("P0402", WORK.WS_ERRO.WS_SECTION);

                /*" -856- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -857- MOVE VG145-SEQ-DPS-REGRA TO WS-SMALLINT(01) */
                _.Move(VG145.DCLVG_DPS_REGRA.VG145_SEQ_DPS_REGRA, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -860- STRING WS-SECTION ' - ERRO NO FETCH SPBVG015_SP015B' '<SEQ_DPS_REGRA=' WS-SMALLINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl27 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl27 += " - ERRO NO FETCH SPBVG015_SP015B";
                spl27 += "<SEQ_DPS_REGRA=";
                var spl28 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl28 += ">";
                var results29 = spl27 + spl28;
                _.Move(results29, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -862- MOVE 'SPBVG015_SP015B' TO WS-TABELA */
                _.Move("SPBVG015_SP015B", WORK.WS_ERRO.WS_TABELA);

                /*" -863- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -864- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -865- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -866- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -868- END-IF */
            }


            /*" -869- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -870- PERFORM P8101-CLOSE-SP015B */

                P8101_CLOSE_SP015B_SECTION();

                /*" -871- GO TO P0402-99-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P0402_99_EXIT*/ //GOTO
                return;

                /*" -873- END-IF */
            }


            /*" -875- PERFORM P0315-ANALISAR-REGRAS */

            P0315_ANALISAR_REGRAS_SECTION();

            /*" -876- IF WS-IND-OK = 'S' */

            if (WORK.WS_INDICADORES.WS_IND_OK == "S")
            {

                /*" -877- PERFORM P8101-CLOSE-SP015B */

                P8101_CLOSE_SP015B_SECTION();

                /*" -878- GO TO P0402-99-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P0402_99_EXIT*/ //GOTO
                return;

                /*" -880- END-IF */
            }


            /*" -882- GO TO P0402-05-INICIO */
            new Task(() => P0402_05_INICIO()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

            /*" -882- . */

        }

        [StopWatch]
        /*" P0402-05-INICIO-DB-FETCH-1 */
        public void P0402_05_INICIO_DB_FETCH_1()
        {
            /*" -851- EXEC SQL FETCH SPBVG015_SP015B INTO :VG141-SEQ-DPS-ITEM, :VG141-VLR-NUMR-INICIAL, :VG141-VLR-NUMR-FINAL, :VG141-VLR-ALFA-INICIAL, :VG141-VLR-ALFA-FINAL, :VG141-COD-TP-COMPARACAO, :VG147-NOM-DPS-ITEM, :VG147-IND-TP-ITEM END-EXEC */

            if (SPBVG015_SP015B.Fetch())
            {
                _.Move(SPBVG015_SP015B.VG141_SEQ_DPS_ITEM, VG141.DCLVG_DPS_REGRA_ITEM.VG141_SEQ_DPS_ITEM);
                _.Move(SPBVG015_SP015B.VG141_VLR_NUMR_INICIAL, VG141.DCLVG_DPS_REGRA_ITEM.VG141_VLR_NUMR_INICIAL);
                _.Move(SPBVG015_SP015B.VG141_VLR_NUMR_FINAL, VG141.DCLVG_DPS_REGRA_ITEM.VG141_VLR_NUMR_FINAL);
                _.Move(SPBVG015_SP015B.VG141_VLR_ALFA_INICIAL, VG141.DCLVG_DPS_REGRA_ITEM.VG141_VLR_ALFA_INICIAL);
                _.Move(SPBVG015_SP015B.VG141_VLR_ALFA_FINAL, VG141.DCLVG_DPS_REGRA_ITEM.VG141_VLR_ALFA_FINAL);
                _.Move(SPBVG015_SP015B.VG141_COD_TP_COMPARACAO, VG141.DCLVG_DPS_REGRA_ITEM.VG141_COD_TP_COMPARACAO);
                _.Move(SPBVG015_SP015B.VG147_NOM_DPS_ITEM, VG147.DCLVG_DPS_ITEM.VG147_NOM_DPS_ITEM);
                _.Move(SPBVG015_SP015B.VG147_IND_TP_ITEM, VG147.DCLVG_DPS_ITEM.VG147_IND_TP_ITEM);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0402_99_EXIT*/

        [StopWatch]
        /*" P8000-OPEN-SP015A-SECTION */
        private void P8000_OPEN_SP015A_SECTION()
        {
            /*" -893- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P8000_00_START */

            P8000_00_START();

        }

        [StopWatch]
        /*" P8000-00-START */
        private void P8000_00_START(bool isPerform = false)
        {
            /*" -897- MOVE 'P8000' TO WS-SECTION */
            _.Move("P8000", WORK.WS_ERRO.WS_SECTION);

            /*" -898- IF LK-VG015-E-TRACE = 'S' */

            if (SPVG015W.LK_VG015_E_TRACE == "S")
            {

                /*" -899- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -901- END-IF */
            }


            /*" -903- MOVE LK-VG015-E-COD-PRODUTO TO VG142-COD-PRODUTO */
            _.Move(SPVG015W.LK_VG015_E_COD_PRODUTO, VG142.DCLVG_PRODUTO_REGRA_DPS.VG142_COD_PRODUTO);

            /*" -903- PERFORM P8000-05-INICIO */

            P8000_05_INICIO(true);

        }

        [StopWatch]
        /*" P8000-05-INICIO */
        private void P8000_05_INICIO(bool isPerform = false)
        {
            /*" -910- PERFORM P8000_05_INICIO_DB_OPEN_1 */

            P8000_05_INICIO_DB_OPEN_1();

            /*" -913- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -914- MOVE 'P8000' TO WS-SECTION */
                _.Move("P8000", WORK.WS_ERRO.WS_SECTION);

                /*" -915- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -916- MOVE LK-VG015-E-NUM-CPF-CNPJ TO WS-BIGINT(01) */
                _.Move(SPVG015W.LK_VG015_E_NUM_CPF_CNPJ, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -917- MOVE LK-VG015-E-COD-PRODUTO TO WS-SMALLINT(01) */
                _.Move(SPVG015W.LK_VG015_E_COD_PRODUTO, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -921- STRING WS-SECTION ' - ERRO NO OPEN SPBVG015_SP015A' '<CERTIFICADO=' WS-BIGINT(01) '>' '<PRODUTO=' WS-SMALLINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl29 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl29 += " - ERRO NO OPEN SPBVG015_SP015A";
                spl29 += "<CERTIFICADO=";
                var spl30 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                spl30 += ">";
                spl30 += "<PRODUTO=";
                var spl31 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl31 += ">";
                var results32 = spl29 + spl30 + spl31;
                _.Move(results32, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -923- MOVE 'SPBVG015_SP015A' TO WS-TABELA */
                _.Move("SPBVG015_SP015A", WORK.WS_ERRO.WS_TABELA);

                /*" -924- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -925- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -926- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -927- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -929- END-IF */
            }


            /*" -929- . */

        }

        [StopWatch]
        /*" P8000-05-INICIO-DB-OPEN-1 */
        public void P8000_05_INICIO_DB_OPEN_1()
        {
            /*" -910- EXEC SQL OPEN SPBVG015_SP015A END-EXEC. */

            SPBVG015_SP015A.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P8000_99_EXIT*/

        [StopWatch]
        /*" P8001-CLOSE-SP015A-SECTION */
        private void P8001_CLOSE_SP015A_SECTION()
        {
            /*" -941- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P8001_00_START */

            P8001_00_START();

        }

        [StopWatch]
        /*" P8001-00-START */
        private void P8001_00_START(bool isPerform = false)
        {
            /*" -945- MOVE 'P8001' TO WS-SECTION */
            _.Move("P8001", WORK.WS_ERRO.WS_SECTION);

            /*" -946- IF LK-VG015-E-TRACE = 'S' */

            if (SPVG015W.LK_VG015_E_TRACE == "S")
            {

                /*" -947- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -949- END-IF */
            }


            /*" -949- PERFORM P8001-05-INICIO */

            P8001_05_INICIO(true);

        }

        [StopWatch]
        /*" P8001-05-INICIO */
        private void P8001_05_INICIO(bool isPerform = false)
        {
            /*" -955- PERFORM P8001_05_INICIO_DB_CLOSE_1 */

            P8001_05_INICIO_DB_CLOSE_1();

            /*" -958- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -959- MOVE 'P8001' TO WS-SECTION */
                _.Move("P8001", WORK.WS_ERRO.WS_SECTION);

                /*" -960- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -961- MOVE LK-VG015-E-NUM-CPF-CNPJ TO WS-BIGINT(01) */
                _.Move(SPVG015W.LK_VG015_E_NUM_CPF_CNPJ, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -962- MOVE LK-VG015-E-COD-PRODUTO TO WS-SMALLINT(01) */
                _.Move(SPVG015W.LK_VG015_E_COD_PRODUTO, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -966- STRING WS-SECTION ' - ERRO NO OPEN SPBVG015_SP015A' '<CERTIFICADO=' WS-BIGINT(01) '>' '<PRODUTO=' WS-SMALLINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl32 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl32 += " - ERRO NO OPEN SPBVG015_SP015A";
                spl32 += "<CERTIFICADO=";
                var spl33 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                spl33 += ">";
                spl33 += "<PRODUTO=";
                var spl34 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl34 += ">";
                var results35 = spl32 + spl33 + spl34;
                _.Move(results35, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -968- MOVE 'SPBVG015_SP015A' TO WS-TABELA */
                _.Move("SPBVG015_SP015A", WORK.WS_ERRO.WS_TABELA);

                /*" -969- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -970- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -971- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -972- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -974- END-IF */
            }


            /*" -974- . */

        }

        [StopWatch]
        /*" P8001-05-INICIO-DB-CLOSE-1 */
        public void P8001_05_INICIO_DB_CLOSE_1()
        {
            /*" -955- EXEC SQL CLOSE SPBVG015_SP015A END-EXEC. */

            SPBVG015_SP015A.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P8001_99_EXIT*/

        [StopWatch]
        /*" P8100-OPEN-SP015B-SECTION */
        private void P8100_OPEN_SP015B_SECTION()
        {
            /*" -985- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P8100_00_START */

            P8100_00_START();

        }

        [StopWatch]
        /*" P8100-00-START */
        private void P8100_00_START(bool isPerform = false)
        {
            /*" -989- MOVE 'P8100' TO WS-SECTION */
            _.Move("P8100", WORK.WS_ERRO.WS_SECTION);

            /*" -990- IF LK-VG015-E-TRACE = 'S' */

            if (SPVG015W.LK_VG015_E_TRACE == "S")
            {

                /*" -991- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -993- END-IF */
            }


            /*" -993- PERFORM P8100-05-INICIO */

            P8100_05_INICIO(true);

        }

        [StopWatch]
        /*" P8100-05-INICIO */
        private void P8100_05_INICIO(bool isPerform = false)
        {
            /*" -1000- PERFORM P8100_05_INICIO_DB_OPEN_1 */

            P8100_05_INICIO_DB_OPEN_1();

            /*" -1003- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -1004- MOVE 'P8100' TO WS-SECTION */
                _.Move("P8100", WORK.WS_ERRO.WS_SECTION);

                /*" -1005- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -1006- MOVE VG145-SEQ-DPS-REGRA TO WS-SMALLINT(01) */
                _.Move(VG145.DCLVG_DPS_REGRA.VG145_SEQ_DPS_REGRA, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -1009- STRING WS-SECTION ' - ERRO NO OPEN SPBVG015_SP015B' '<SEQ_DPS_REGRA=' WS-SMALLINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl35 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl35 += " - ERRO NO OPEN SPBVG015_SP015B";
                spl35 += "<SEQ_DPS_REGRA=";
                var spl36 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl36 += ">";
                var results37 = spl35 + spl36;
                _.Move(results37, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -1011- MOVE 'SPBVG015_SP015B' TO WS-TABELA */
                _.Move("SPBVG015_SP015B", WORK.WS_ERRO.WS_TABELA);

                /*" -1012- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -1013- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -1014- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -1015- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1017- END-IF */
            }


            /*" -1017- . */

        }

        [StopWatch]
        /*" P8100-05-INICIO-DB-OPEN-1 */
        public void P8100_05_INICIO_DB_OPEN_1()
        {
            /*" -1000- EXEC SQL OPEN SPBVG015_SP015B END-EXEC. */

            SPBVG015_SP015B.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P8100_99_EXIT*/

        [StopWatch]
        /*" P8101-CLOSE-SP015B-SECTION */
        private void P8101_CLOSE_SP015B_SECTION()
        {
            /*" -1029- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P8101_00_START */

            P8101_00_START();

        }

        [StopWatch]
        /*" P8101-00-START */
        private void P8101_00_START(bool isPerform = false)
        {
            /*" -1033- MOVE 'P8101' TO WS-SECTION */
            _.Move("P8101", WORK.WS_ERRO.WS_SECTION);

            /*" -1034- IF LK-VG015-E-TRACE = 'S' */

            if (SPVG015W.LK_VG015_E_TRACE == "S")
            {

                /*" -1035- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -1037- END-IF */
            }


            /*" -1037- PERFORM P8101-05-INICIO */

            P8101_05_INICIO(true);

        }

        [StopWatch]
        /*" P8101-05-INICIO */
        private void P8101_05_INICIO(bool isPerform = false)
        {
            /*" -1043- PERFORM P8101_05_INICIO_DB_CLOSE_1 */

            P8101_05_INICIO_DB_CLOSE_1();

            /*" -1046- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -1047- MOVE 'P8101' TO WS-SECTION */
                _.Move("P8101", WORK.WS_ERRO.WS_SECTION);

                /*" -1048- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -1049- MOVE VG145-SEQ-DPS-REGRA TO WS-SMALLINT(01) */
                _.Move(VG145.DCLVG_DPS_REGRA.VG145_SEQ_DPS_REGRA, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -1052- STRING WS-SECTION ' - ERRO NO OPEN SPBVG015_SP015B' '<SEQ_DPS_REGRA=' WS-SMALLINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl37 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl37 += " - ERRO NO OPEN SPBVG015_SP015B";
                spl37 += "<SEQ_DPS_REGRA=";
                var spl38 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl38 += ">";
                var results39 = spl37 + spl38;
                _.Move(results39, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -1054- MOVE 'SPBVG015_SP015B' TO WS-TABELA */
                _.Move("SPBVG015_SP015B", WORK.WS_ERRO.WS_TABELA);

                /*" -1055- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -1056- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -1057- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -1058- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1060- END-IF */
            }


            /*" -1060- . */

        }

        [StopWatch]
        /*" P8101-05-INICIO-DB-CLOSE-1 */
        public void P8101_05_INICIO_DB_CLOSE_1()
        {
            /*" -1043- EXEC SQL CLOSE SPBVG015_SP015B END-EXEC. */

            SPBVG015_SP015B.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P8101_99_EXIT*/

        [StopWatch]
        /*" P9999-ERRO-SECTION */
        private void P9999_ERRO_SECTION()
        {
            /*" -1072- MOVE LK-VG015-E-VLR-IS TO WS-DECIMAL(01) */
            _.Move(SPVG015W.LK_VG015_E_VLR_IS, WORK.WS_EDIT.WS_DECIMAL[01]);

            /*" -1073- MOVE LK-VG015-E-COD-PRODUTO TO WS-SMALLINT(01) */
            _.Move(SPVG015W.LK_VG015_E_COD_PRODUTO, WORK.WS_EDIT.WS_SMALLINT[01]);

            /*" -1075- MOVE LK-VG015-E-NUM-CPF-CNPJ TO WS-BIGINT(01) */
            _.Move(SPVG015W.LK_VG015_E_NUM_CPF_CNPJ, WORK.WS_EDIT.WS_BIGINT[01]);

            /*" -1076- DISPLAY '**********************************************' */
            _.Display($"**********************************************");

            /*" -1077- DISPLAY '*            S P B V G 0 1 5                 *' */
            _.Display($"*            S P B V G 0 1 5                 *");

            /*" -1078- DISPLAY '**********************************************' */
            _.Display($"**********************************************");

            /*" -1085- DISPLAY '* DATA COMPILACAO..: ' WS-C-DATE-COMPILED(7:2) '/' WS-C-DATE-COMPILED(5:2) '/' WS-C-DATE-COMPILED(1:4) '-' WS-C-DATE-COMPILED(9:2) ':' WS-C-DATE-COMPILED(11:2) ':' WS-C-DATE-COMPILED(13:2) */

            $"* DATA COMPILACAO..: {WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(7, 2)}/{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(5, 2)}/{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(1, 4)}-{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(9, 2)}:{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(11, 2)}:{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(13, 2)}"
            .Display();

            /*" -1092- DISPLAY '* DATA EXECUCAO....: ' WS-C-DATE-CURRENT(7:2) '/' WS-C-DATE-CURRENT(5:2) '/' WS-C-DATE-CURRENT(1:4) '-' WS-C-DATE-CURRENT(9:2) ':' WS-C-DATE-CURRENT(11:2) ':' WS-C-DATE-CURRENT(13:2) */

            $"* DATA EXECUCAO....: {WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(7, 2)}/{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(5, 2)}/{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(1, 4)}-{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(9, 2)}:{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(11, 2)}:{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(13, 2)}"
            .Display();

            /*" -1096- DISPLAY '* DATA SISTEMA.....: ' SISTEMAS-DATA-MOV-ABERTO(9:2) '/' SISTEMAS-DATA-MOV-ABERTO(6:2) '/' SISTEMAS-DATA-MOV-ABERTO(1:4) */

            $"* DATA SISTEMA.....: {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2)}/{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2)}/{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4)}"
            .Display();

            /*" -1097- DISPLAY '**********************************************' */
            _.Display($"**********************************************");

            /*" -1098- DISPLAY '*             DADOS DE ENTRADA               *' */
            _.Display($"*             DADOS DE ENTRADA               *");

            /*" -1099- DISPLAY '**********************************************' */
            _.Display($"**********************************************");

            /*" -1100- DISPLAY '* IDE-SISTEMA......: ' LK-VG015-E-IDE-SISTEMA */
            _.Display($"* IDE-SISTEMA......: {SPVG015W.LK_VG015_E_IDE_SISTEMA}");

            /*" -1101- DISPLAY '* COD-USUARIO......: ' LK-VG015-E-COD-USUARIO */
            _.Display($"* COD-USUARIO......: {SPVG015W.LK_VG015_E_COD_USUARIO}");

            /*" -1102- DISPLAY '* NOM-PROGRAMA.....: ' LK-VG015-E-NOM-PROGRAMA */
            _.Display($"* NOM-PROGRAMA.....: {SPVG015W.LK_VG015_E_NOM_PROGRAMA}");

            /*" -1103- DISPLAY '* TIPO-ACAO........: ' LK-VG015-E-TIPO-ACAO */
            _.Display($"* TIPO-ACAO........: {SPVG015W.LK_VG015_E_TIPO_ACAO}");

            /*" -1104- DISPLAY '* NUM-CPF-CNPJ.....: ' WS-BIGINT(01) */
            _.Display($"* NUM-CPF-CNPJ.....: {WORK.WS_EDIT.WS_BIGINT[1]}");

            /*" -1105- DISPLAY '* COD-PRODUTO......: ' WS-SMALLINT(01) */
            _.Display($"* COD-PRODUTO......: {WORK.WS_EDIT.WS_SMALLINT[1]}");

            /*" -1106- DISPLAY '* VLR-IS...........: ' WS-DECIMAL(01) */
            _.Display($"* VLR-IS...........: {WORK.WS_EDIT.WS_DECIMAL[1]}");

            /*" -1107- DISPLAY '**********************************************' */
            _.Display($"**********************************************");

            /*" -1108- DISPLAY '*         E R R O    S P B V G 0 1 5         *' */
            _.Display($"*         E R R O    S P B V G 0 1 5         *");

            /*" -1109- DISPLAY '**********************************************' */
            _.Display($"**********************************************");

            /*" -1110- DISPLAY '* SECTION..........: ' WS-SECTION */
            _.Display($"* SECTION..........: {WORK.WS_ERRO.WS_SECTION}");

            /*" -1111- DISPLAY '* IND ERRO.........: ' WS-IND-ERRO */
            _.Display($"* IND ERRO.........: {WORK.WS_ERRO.WS_IND_ERRO}");

            /*" -1112- DISPLAY '* TABELA...........: ' WS-TABELA */
            _.Display($"* TABELA...........: {WORK.WS_ERRO.WS_TABELA}");

            /*" -1113- DISPLAY '* MENSAGEM.........: ' WS-MENSAGEM */
            _.Display($"* MENSAGEM.........: {WORK.WS_ERRO.WS_MENSAGEM}");

            /*" -1114- DISPLAY '* SQLCODE..........: ' WS-SQLCODE */
            _.Display($"* SQLCODE..........: {WORK.WS_ERRO.WS_SQLCODE}");

            /*" -1115- DISPLAY '* SQLERRMC.........: ' WS-SQLERRMC */
            _.Display($"* SQLERRMC.........: {WORK.WS_ERRO.WS_SQLERRMC}");

            /*" -1116- DISPLAY '* SQLSTATE.........: ' WS-SQLSTATE */
            _.Display($"* SQLSTATE.........: {WORK.WS_ERRO.WS_SQLSTATE}");

            /*" -1118- DISPLAY '**********************************************' */
            _.Display($"**********************************************");

            /*" -1119- MOVE WS-IND-ERRO TO LK-VG015-IND-ERRO */
            _.Move(WORK.WS_ERRO.WS_IND_ERRO, SPVG015W.LK_VG015_IND_ERRO);

            /*" -1120- MOVE WS-MENSAGEM TO LK-VG015-MENSAGEM */
            _.Move(WORK.WS_ERRO.WS_MENSAGEM, SPVG015W.LK_VG015_MENSAGEM);

            /*" -1121- MOVE WS-TABELA TO LK-VG015-NOM-TABELA */
            _.Move(WORK.WS_ERRO.WS_TABELA, SPVG015W.LK_VG015_NOM_TABELA);

            /*" -1122- MOVE WS-SQLCODE TO LK-VG015-SQLCODE */
            _.Move(WORK.WS_ERRO.WS_SQLCODE, SPVG015W.LK_VG015_SQLCODE);

            /*" -1123- MOVE WS-SQLERRMC TO LK-VG015-SQLERRMC */
            _.Move(WORK.WS_ERRO.WS_SQLERRMC, SPVG015W.LK_VG015_SQLERRMC);

            /*" -1125- MOVE WS-SQLSTATE TO LK-VG015-SQLSTATE */
            _.Move(WORK.WS_ERRO.WS_SQLSTATE, SPVG015W.LK_VG015_SQLSTATE);

            /*" -1125- . */

            /*" -0- FLUXCONTROL_PERFORM P9999_99_EXIT */

            P9999_99_EXIT();

        }

        [StopWatch]
        /*" P9999-99-EXIT */
        private void P9999_99_EXIT(bool isPerform = false)
        {
            /*" -1128- GOBACK. */

            throw new GoBack();

        }
    }
}