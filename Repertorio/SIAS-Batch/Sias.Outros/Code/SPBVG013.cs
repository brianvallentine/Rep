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
using Sias.Outros.DB2.SPBVG013;

namespace Code
{
    public class SPBVG013
    {
        public bool IsCall { get; set; }

        public SPBVG013()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      * SISTEMA.........: SIAS                                         *      */
        /*"      * MODULO..........: VG                                           *      */
        /*"      * PROGRAMA........: SPBVG013                                     *      */
        /*"      * ANALISTA........: FRANK CARVALHO                               *      */
        /*"      * DATA............: 05/01/2024                                   *      */
        /*"      * DEMANDA.........: 564320                                       *      */
        /*"      ******************************************************************      */
        /*"      * OBJETIVO........: PROCEDURE SERA CHAMADA PELO GI PARA ATUALIZAR*      */
        /*"      *                   A BASE DB2 COM O RETORNO DA CHAMADA DA API DA*      */
        /*"      *                   CAPITALIZACAO. ESTA API E RESPONSAVEL POR SO-*      */
        /*"      *                   LICITAR A COMPRA DE UM TITULO.               *      */
        /*"      *                                                                *      */
        /*"      *==> TIPO DE ACAO                                                *      */
        /*"      *    (01) SOLICTAR A COMPRA DE UM TITULO ACOPLADO.               *      */
        /*"      *    (02) SOLICITAR A RENOVACAO DE UM TITULO ACOPLADO.           *      */
        /*"      *    (03) ATUALIZAR O RESULTADO DA OPERACAO DE SOLICITACAO DE    *      */
        /*"      *         COMPRA DE TITULO.                                      *      */
        /*"      *    (04) ATUALIZAR O RESULTADO DA OPERACAO DE COMPRA/RENOVACAO. *      */
        /*"      *    (05) SOLICITAR UMA CONSULTA DE UM TITULO ACOPLADO NA CAP.   *      */
        /*"      *    (06) ATUALIZAR O RESULTADO DA OPERACAO DE CONSULTA A CAP.   *      */
        /*"      *    (07) ATUALIZAR O RESULTADO DA OPERACAO DE SOLICITACAO DE    *      */
        /*"      *         RENOVACAO DE TITULO.                                   *      */
        /*"      ******************************************************************      */
        /*"      * VERSAO     DATA     RESPONSAVEL       ALTERACAO                *      */
        /*"      ******************************************************************      */
        /*"V.XX  *   VERSAO XX - DEMANDA XXXXXX - XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX*      */
        /*"      *               XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX*      */
        /*"      *               XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX                 */
        /*"      *                                                                *      */
        /*"      * EM DD/MM/AAAA - XXXXXXXXXXXXXXXXX    PROCURE POR V.XX          *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      * V.000   05/01/2024  FRANK CARVALHO    CRIACAO DO PROGRAMA      *      */
        /*"      * V.002   15/02/2024  RAUL BASILI ROTTA REMOVER DISPLAYS PARA    *      */
        /*"      *                                       EVITAR ESTOURO DO SPOOL  *      */
        /*"      * V.003   04/03/2024  RAUL BASILI ROTTA Alterar TIPO-ACAO - 5    *      */
        /*"      *                                       para passar a atualizar  *      */
        /*"      *                                       direto para STA = 7, ao  *      */
        /*"      *                                       inv�s de 6. O programa   *      */
        /*"      *                                       VG0014B come�ar� a atuali*      */
        /*"      *                                      -zar os status dos titulos*      */
        /*"      *                                       com vig�ncia encerrada,  *      */
        /*"      *                                       deixando de ser necess� -       */
        /*"      *                                       rio o pedido de atualiza-       */
        /*"      *                                       ��o da base antes da            */
        /*"      *                                       renova��o.                      */
        /*"      * V.004   09/09/2024  RAUL BASILI ROTTA AJUSTE PARA CONTROLE DE  *      */
        /*"      *                                       REMESSA                  *      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"01    WORK.*/
        public SPBVG013_WORK WORK { get; set; } = new SPBVG013_WORK();
        public class SPBVG013_WORK : VarBasis
        {
            /*"  05  WS-PROGRAMA                   PIC  X(008) VALUE 'SPBVG013'*/
            public StringBasis WS_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"SPBVG013");
            /*"  05  WS-PROGRAMA-CHAMADO           PIC  X(008) VALUE SPACES.*/
            public StringBasis WS_PROGRAMA_CHAMADO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"  05  WS-ACOPLADO                   PIC  X(001) VALUE 'N'.*/

            public SelectorBasis WS_ACOPLADO { get; set; } = new SelectorBasis("001", "N")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 WS-TEM-ACOPLADO                           VALUE 'S'. */
							new SelectorItemBasis("WS_TEM_ACOPLADO", "S"),
							/*" 88 WS-SEM-ACOPLADO                           VALUE 'N'. */
							new SelectorItemBasis("WS_SEM_ACOPLADO", "N")
                }
            };

            /*"  05  WS-DATAS.*/
            public SPBVG013_WS_DATAS WS_DATAS { get; set; } = new SPBVG013_WS_DATAS();
            public class SPBVG013_WS_DATAS : VarBasis
            {
                /*"    10 WS-C-DATE-CURRENT             PIC  X(014) VALUE SPACES.*/
                public StringBasis WS_C_DATE_CURRENT { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
                /*"    10 WS-C-DATE-COMPILED            PIC  X(014) VALUE SPACES.*/
                public StringBasis WS_C_DATE_COMPILED { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
                /*"    10 WS-CURRENT-TIMESTAMP          PIC  X(026) VALUE SPACES.*/
                public StringBasis WS_CURRENT_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
                /*"  05  WS-EDIT.*/
            }
            public SPBVG013_WS_EDIT WS_EDIT { get; set; } = new SPBVG013_WS_EDIT();
            public class SPBVG013_WS_EDIT : VarBasis
            {
                /*"    10 WS-SMALLINT                   PIC ZZ.ZZ9- OCCURS 20 TIMES*/
                public ListBasis<IntBasis, Int64> WS_SMALLINT { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "6", "ZZ.ZZ9-"), 20);
                /*"    10 WS-INTEGER                    PIC Z.ZZZ.ZZZ.ZZ9-                                                OCCURS 5 TIMES.*/
                public ListBasis<IntBasis, Int64> WS_INTEGER { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "11", "Z.ZZZ.ZZZ.ZZ9-"), 5);
                /*"    10 WS-BIGINT                     PIC 99999999999999                                                 OCCURS 5 TIMES.*/
                public ListBasis<IntBasis, Int64> WS_BIGINT { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "14", "99999999999999"), 5);
                /*"    10 WS-DECIMAL                    PIC ZZZZZZZZZZ9,999999                                                 OCCURS 10 TIMES*/
                public ListBasis<DoubleBasis, double> WS_DECIMAL { get; set; } = new ListBasis<DoubleBasis, double>(new PIC("9", "11", "ZZZZZZZZZZ9V999999"), 10);
                /*"    10 WS-TAXA                       PIC 9,99999-                                                 OCCURS 5 TIMES.*/
                public ListBasis<DoubleBasis, double> WS_TAXA { get; set; } = new ListBasis<DoubleBasis, double>(new PIC("9", "1", "9V99999-"), 5);
                /*"  05  WS-ERRO.*/
            }
            public SPBVG013_WS_ERRO WS_ERRO { get; set; } = new SPBVG013_WS_ERRO();
            public class SPBVG013_WS_ERRO : VarBasis
            {
                /*"    10 WS-SECTION                    PIC  X(005) VALUE SPACES.*/
                public StringBasis WS_SECTION { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"    10 WS-SQLCODE                    PIC  ZZZZ9-.*/
                public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "6", "ZZZZ9-."));
                /*"    10 WS-SQLERRMC                   PIC  X(076) VALUE SPACES.*/
                public StringBasis WS_SQLERRMC { get; set; } = new StringBasis(new PIC("X", "76", "X(076)"), @"");
                /*"    10 WS-SQLSTATE                   PIC  X(005) VALUE SPACES.*/
                public StringBasis WS_SQLSTATE { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"    10 WS-MENSAGEM                   PIC  X(255) VALUE SPACES.*/
                public StringBasis WS_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "255", "X(255)"), @"");
                /*"    10 WS-TABELA                     PIC  X(050) VALUE SPACES.*/
                public StringBasis WS_TABELA { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
                /*"    10 WS-IND-ERRO                   PIC  9(001) VALUE 0.*/
                public IntBasis WS_IND_ERRO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
                /*"  05 WS-AUXILIARES.*/
            }
            public SPBVG013_WS_AUXILIARES WS_AUXILIARES { get; set; } = new SPBVG013_WS_AUXILIARES();
            public class SPBVG013_WS_AUXILIARES : VarBasis
            {
                /*"    10 WS-IND-NULL                  PIC S9(004) COMP VALUE -1.*/
                public IntBasis WS_IND_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), -1);
                /*"    10 WS-NULL-SEQ-REMSSA           PIC S9(04) COMP VALUE -1.*/
                public IntBasis WS_NULL_SEQ_REMSSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"), -1);
                /*"    10 WS-NULL-SEQ-REGISTRO         PIC S9(04) COMP VALUE -1.*/
                public IntBasis WS_NULL_SEQ_REGISTRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"), -1);
                /*"    10 WS-COUNT                     PIC S9(004) COMP VALUE 0.*/
                public IntBasis WS_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    10 WS-VG139-DES-ERRO.*/
                public SPBVG013_WS_VG139_DES_ERRO WS_VG139_DES_ERRO { get; set; } = new SPBVG013_WS_VG139_DES_ERRO();
                public class SPBVG013_WS_VG139_DES_ERRO : VarBasis
                {
                    /*"      49 WS-VG139-DES-ERRO-LEN      PIC S9(004) COMP VALUE 0.*/
                    public IntBasis WS_VG139_DES_ERRO_LEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"      49 WS-VG139-DES-ERRO-TEXT     PIC  X(255) VALUE SPACES.*/
                    public StringBasis WS_VG139_DES_ERRO_TEXT { get; set; } = new StringBasis(new PIC("X", "255", "X(255)"), @"");
                    /*"    10 WS-VG139-DES-ACAO.*/
                }
                public SPBVG013_WS_VG139_DES_ACAO WS_VG139_DES_ACAO { get; set; } = new SPBVG013_WS_VG139_DES_ACAO();
                public class SPBVG013_WS_VG139_DES_ACAO : VarBasis
                {
                    /*"      49 WS-VG139-DES-ACAO-LEN      PIC S9(004) COMP VALUE 0.*/
                    public IntBasis WS_VG139_DES_ACAO_LEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"      49 WS-VG139-DES-ACAO-TEXT     PIC  X(255) VALUE SPACES.*/
                    public StringBasis WS_VG139_DES_ACAO_TEXT { get; set; } = new StringBasis(new PIC("X", "255", "X(255)"), @"");
                }
            }
        }


        public Copies.RSGEWSTR RSGEWSTR { get; set; } = new Copies.RSGEWSTR();
        public Copies.SPVG013W SPVG013W { get; set; } = new Copies.SPVG013W();
        public Copies.LBHCT002 LBHCT002 { get; set; } = new Copies.LBHCT002();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.VG135 VG135 { get; set; } = new Dclgens.VG135();
        public Dclgens.VG137 VG137 { get; set; } = new Dclgens.VG137();
        public Dclgens.VG139 VG139 { get; set; } = new Dclgens.VG139();
        public Dclgens.VG136 VG136 { get; set; } = new Dclgens.VG136();
        public Dclgens.VG140 VG140 { get; set; } = new Dclgens.VG140();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(SPVG013W SPVG013W_P, LBHCT002 LBHCT002_P) //PROCEDURE DIVISION USING 
        /*PROCEDURE DIVISION
        LK_VG013_TRACE
        LK_VG013_SISTEMA_CHAMADOR
        LK_VG013_CANAL
        LK_VG013_ORIGEM
        LK_VG013_COD_USUARIO
        LK_VG013_TIPO_ACAO
        LK_VG013_IDE_SISTEMA
        LK_VG013_NUM_CERTIFICADO
        LK_VG013_COD_PRODUTO
        LK_VG013_COD_PLANO
        LK_VG013_QTD_TITULO
        LK_VG013_VLR_TITULO
        LK_VG013_COD_EMPRESA_CAP
        LK_VG013_COD_RETORNO_API
        LK_VG013_DES_ERRO
        LK_VG013_DES_ACAO
        H_OUT_COD_RETORNO
        H_OUT_COD_RETORNO_SQL
        H_OUT_MENSAGEM
        H_OUT_SQLERRMC
        H_OUT_SQLSTATE*/
        {
            try
            {
                this.SPVG013W = SPVG013W_P;
                this.LBHCT002 = LBHCT002_P;

                /*" -0- FLUXCONTROL_PERFORM P0000-INICIALIZAR-SECTION */

                P0000_INICIALIZAR_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { SPVG013W, LBHCT002 };
            return Result;
        }

        [StopWatch]
        /*" P0000-INICIALIZAR-SECTION */
        private void P0000_INICIALIZAR_SECTION()
        {
            /*" -201- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -202- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -203- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -206- MOVE FUNCTION CURRENT-DATE(1:14) TO WS-C-DATE-CURRENT. */
            _.Move(_.CurrentDate(0, 14), WORK.WS_DATAS.WS_C_DATE_CURRENT);

            /*" -208- MOVE FUNCTION WHEN-COMPILED TO WS-C-DATE-COMPILED. */
            _.Move(_.WhenCompiled(), WORK.WS_DATAS.WS_C_DATE_COMPILED);

            /*" -216- INITIALIZE H-OUT-COD-RETORNO H-OUT-COD-RETORNO-SQL H-OUT-MENSAGEM H-OUT-SQLERRMC H-OUT-SQLSTATE WS-ERRO */
            _.Initialize(
                LBHCT002.H_OUT_COD_RETORNO
                , LBHCT002.H_OUT_COD_RETORNO_SQL
                , LBHCT002.H_OUT_MENSAGEM
                , LBHCT002.H_OUT_SQLERRMC
                , LBHCT002.H_OUT_SQLSTATE
                , WORK.WS_ERRO
            );

            /*" -217- IF NOT ( LK-VG013-TRACE = 'S' OR = 'N' ) */

            if (!(SPVG013W.LK_VG013_TRACE.In("S", "N")))
            {

                /*" -218- MOVE 'N' TO LK-VG013-TRACE */
                _.Move("N", SPVG013W.LK_VG013_TRACE);

                /*" -221- END-IF */
            }


            /*" -223- IF LK-VG013-SISTEMA-CHAMADOR EQUAL 'SIAS - VG0014B' OR 'SIAS - VG0105S' */

            if (SPVG013W.LK_VG013_SISTEMA_CHAMADOR.In("SIAS-VG0014B", "SIAS-VG0105S"))
            {

                /*" -224- MOVE '*' TO LK-VG013-TRACE */
                _.Move("*", SPVG013W.LK_VG013_TRACE);

                /*" -227- END-IF */
            }


            /*" -229- MOVE '*' TO LK-VG013-TRACE */
            _.Move("*", SPVG013W.LK_VG013_TRACE);

            /*" -230- IF LK-VG013-TRACE EQUAL 'S' OR 'N' */

            if (SPVG013W.LK_VG013_TRACE.In("S", "N"))
            {

                /*" -231- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -232- DISPLAY '*            S P B V G 0 1 3                 *' */
                _.Display($"*            S P B V G 0 1 3                 *");

                /*" -233- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -240- DISPLAY '* DATA COMPILACAO..: ' WS-C-DATE-COMPILED(7:2) '/' WS-C-DATE-COMPILED(5:2) '/' WS-C-DATE-COMPILED(1:4) '-' WS-C-DATE-COMPILED(9:2) ':' WS-C-DATE-COMPILED(11:2) ':' WS-C-DATE-COMPILED(13:2) */

                $"* DATA COMPILACAO..: {WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(7, 2)}/{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(5, 2)}/{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(1, 4)}-{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(9, 2)}:{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(11, 2)}:{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(13, 2)}"
                .Display();

                /*" -247- DISPLAY '* DATA EXECUCAO....: ' WS-C-DATE-CURRENT(7:2) '/' WS-C-DATE-CURRENT(5:2) '/' WS-C-DATE-CURRENT(1:4) '-' WS-C-DATE-CURRENT(9:2) ':' WS-C-DATE-CURRENT(11:2) ':' WS-C-DATE-CURRENT(13:2) */

                $"* DATA EXECUCAO....: {WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(7, 2)}/{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(5, 2)}/{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(1, 4)}-{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(9, 2)}:{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(11, 2)}:{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(13, 2)}"
                .Display();

                /*" -252- DISPLAY '* DATA SISTEMA.....: ' SISTEMAS-DATA-MOV-ABERTO(9:2) '/' SISTEMAS-DATA-MOV-ABERTO(6:2) '/' SISTEMAS-DATA-MOV-ABERTO(1:4) */

                $"* DATA SISTEMA.....: {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2)}/{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2)}/{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4)}"
                .Display();

                /*" -253- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -254- DISPLAY '*             DADOS DE ENTRADA               *' */
                _.Display($"*             DADOS DE ENTRADA               *");

                /*" -255- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -256- DISPLAY '* TRACE............: ' LK-VG013-TRACE */
                _.Display($"* TRACE............: {SPVG013W.LK_VG013_TRACE}");

                /*" -257- DISPLAY '* SISTEMA.CHAMADOR.: ' LK-VG013-SISTEMA-CHAMADOR */
                _.Display($"* SISTEMA.CHAMADOR.: {SPVG013W.LK_VG013_SISTEMA_CHAMADOR}");

                /*" -258- DISPLAY '* CANAL............: ' LK-VG013-CANAL */
                _.Display($"* CANAL............: {SPVG013W.LK_VG013_CANAL}");

                /*" -259- DISPLAY '* ORIGEM...........: ' LK-VG013-ORIGEM */
                _.Display($"* ORIGEM...........: {SPVG013W.LK_VG013_ORIGEM}");

                /*" -260- DISPLAY '* COD-USUARIO......: ' LK-VG013-COD-USUARIO */
                _.Display($"* COD-USUARIO......: {SPVG013W.LK_VG013_COD_USUARIO}");

                /*" -261- DISPLAY '* TIPO-ACAO........: ' LK-VG013-TIPO-ACAO */
                _.Display($"* TIPO-ACAO........: {SPVG013W.LK_VG013_TIPO_ACAO}");

                /*" -262- DISPLAY '* IDE-SISTEMA......: ' LK-VG013-IDE-SISTEMA */
                _.Display($"* IDE-SISTEMA......: {SPVG013W.LK_VG013_IDE_SISTEMA}");

                /*" -263- DISPLAY '* NUM-CERTIFICADO..: ' LK-VG013-NUM-CERTIFICADO */
                _.Display($"* NUM-CERTIFICADO..: {SPVG013W.LK_VG013_NUM_CERTIFICADO}");

                /*" -264- DISPLAY '* COD-PRODUTO......: ' LK-VG013-COD-PRODUTO */
                _.Display($"* COD-PRODUTO......: {SPVG013W.LK_VG013_COD_PRODUTO}");

                /*" -265- DISPLAY '* COD-PLANO........: ' LK-VG013-COD-PLANO */
                _.Display($"* COD-PLANO........: {SPVG013W.LK_VG013_COD_PLANO}");

                /*" -266- DISPLAY '* QTD-TITULO.......: ' LK-VG013-QTD-TITULO */
                _.Display($"* QTD-TITULO.......: {SPVG013W.LK_VG013_QTD_TITULO}");

                /*" -267- DISPLAY '* VLR-TITULO.......: ' LK-VG013-VLR-TITULO */
                _.Display($"* VLR-TITULO.......: {SPVG013W.LK_VG013_VLR_TITULO}");

                /*" -268- DISPLAY '* COD-EMPRESA-CAP..: ' LK-VG013-COD-EMPRESA-CAP */
                _.Display($"* COD-EMPRESA-CAP..: {SPVG013W.LK_VG013_COD_EMPRESA_CAP}");

                /*" -269- DISPLAY '* COD-RETORNO-API..: ' LK-VG013-COD-RETORNO-API */
                _.Display($"* COD-RETORNO-API..: {SPVG013W.LK_VG013_COD_RETORNO_API}");

                /*" -270- DISPLAY '* DES-ERRO.........: ' LK-VG013-DES-ERRO */
                _.Display($"* DES-ERRO.........: {SPVG013W.LK_VG013_DES_ERRO}");

                /*" -271- DISPLAY '* DES-ACAO.........: ' LK-VG013-DES-ACAO */
                _.Display($"* DES-ACAO.........: {SPVG013W.LK_VG013_DES_ACAO}");

                /*" -272- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -274- END-IF */
            }


            /*" -276- PERFORM P0050-VERIFICAR-SISTEMA */

            P0050_VERIFICAR_SISTEMA_SECTION();

            /*" -277- IF LK-VG013-TRACE EQUAL 'S' OR 'N' */

            if (SPVG013W.LK_VG013_TRACE.In("S", "N"))
            {

                /*" -281- DISPLAY '* DATA SISTEMA.....: ' SISTEMAS-DATA-MOV-ABERTO(9:2) '/' SISTEMAS-DATA-MOV-ABERTO(6:2) '/' SISTEMAS-DATA-MOV-ABERTO(1:4) */

                $"* DATA SISTEMA.....: {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2)}/{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2)}/{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4)}"
                .Display();

                /*" -282- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -284- END-IF */
            }


            /*" -285- PERFORM P0005-PROCESSAR */

            P0005_PROCESSAR_SECTION();

            /*" -285- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0000_99_EXIT*/

        [StopWatch]
        /*" P0005-PROCESSAR-SECTION */
        private void P0005_PROCESSAR_SECTION()
        {
            /*" -295- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0005_00_START */

            P0005_00_START();

        }

        [StopWatch]
        /*" P0005-00-START */
        private void P0005_00_START(bool isPerform = false)
        {
            /*" -297- MOVE 'P0005' TO WS-SECTION */
            _.Move("P0005", WORK.WS_ERRO.WS_SECTION);

            /*" -298- IF LK-VG013-TRACE EQUAL 'S' */

            if (SPVG013W.LK_VG013_TRACE == "S")
            {

                /*" -299- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -300- END-IF. */
            }


            /*" -300- PERFORM P0005-05-INICIO */

            P0005_05_INICIO(true);

        }

        [StopWatch]
        /*" P0005-05-INICIO */
        private void P0005_05_INICIO(bool isPerform = false)
        {
            /*" -306- PERFORM P0100-VALIDAR-LINKAGE. */

            P0100_VALIDAR_LINKAGE_SECTION();

            /*" -307- EVALUATE LK-VG013-TIPO-ACAO */
            switch (SPVG013W.LK_VG013_TIPO_ACAO.Value)
            {

                /*" -308- WHEN 1 */
                case 1:

                    /*" -310- PERFORM P1000-TRATAR-TIPO-ACAO-01 THRU P1000-99-EXIT */

                    P1000_TRATAR_TIPO_ACAO_01_SECTION();

                    P1000_00_START(true);

                    P1000_05_INICIO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: P1000_99_EXIT*/


                    /*" -311- WHEN 2 */
                    break;
                case 2:

                    /*" -313- PERFORM P2000-TRATAR-TIPO-ACAO-02 THRU P2000-99-EXIT */

                    P2000_TRATAR_TIPO_ACAO_02_SECTION();

                    P2000_00_START(true);

                    P2000_05_INICIO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: P2000_99_EXIT*/


                    /*" -314- WHEN 3 */
                    break;
                case 3:

                    /*" -316- PERFORM P3000-TRATAR-TIPO-ACAO-03 THRU P3000-99-EXIT */

                    P3000_TRATAR_TIPO_ACAO_03_SECTION();

                    P3000_00_START(true);

                    P3000_05_INICIO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: P3000_99_EXIT*/


                    /*" -317- WHEN 4 */
                    break;
                case 4:

                    /*" -319- PERFORM P4000-TRATAR-TIPO-ACAO-04 THRU P4000-99-EXIT */

                    P4000_TRATAR_TIPO_ACAO_04_SECTION();

                    P4000_00_START(true);

                    P4000_05_INICIO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: P4000_99_EXIT*/


                    /*" -320- WHEN 5 */
                    break;
                case 5:

                    /*" -322- PERFORM P5000-TRATAR-TIPO-ACAO-05 THRU P5000-99-EXIT */

                    P5000_TRATAR_TIPO_ACAO_05_SECTION();

                    P5000_00_START(true);

                    P5000_05_INICIO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: P5000_99_EXIT*/


                    /*" -323- WHEN 6 */
                    break;
                case 6:

                    /*" -325- PERFORM P6000-TRATAR-TIPO-ACAO-06 THRU P6000-99-EXIT */

                    P6000_TRATAR_TIPO_ACAO_06_SECTION();

                    P6000_00_START(true);

                    P6000_05_INICIO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: P6000_99_EXIT*/


                    /*" -326- WHEN 7 */
                    break;
                case 7:

                    /*" -328- PERFORM P7000-TRATAR-TIPO-ACAO-07 THRU P7000-99-EXIT */

                    P7000_TRATAR_TIPO_ACAO_07_SECTION();

                    P7000_00_START(true);

                    P7000_05_INICIO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: P7000_99_EXIT*/


                    /*" -329- WHEN OTHER */
                    break;
                default:

                    /*" -330- MOVE 1 TO WS-IND-ERRO */
                    _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                    /*" -331- MOVE LK-VG013-TIPO-ACAO TO WS-SMALLINT(01) */
                    _.Move(SPVG013W.LK_VG013_TIPO_ACAO, WORK.WS_EDIT.WS_SMALLINT[01]);

                    /*" -335- STRING WS-SECTION ' - TIPO DE ACAO INFORMADA INVALIDA.' '<TIPO_ACAO=' WS-SMALLINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                    #region STRING
                    var spl1 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                    spl1 += " - TIPO DE ACAO INFORMADA INVALIDA.";
                    spl1 += "<TIPO_ACAO=";
                    var spl2 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                    spl2 += ">";
                    var results3 = spl1 + spl2;
                    _.Move(results3, WORK.WS_ERRO.WS_MENSAGEM);
                    #endregion

                    /*" -338- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                    _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                    /*" -339- MOVE 0 TO WS-SQLCODE */
                    _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                    /*" -340- GO TO P9999-ERRO */

                    P9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -342- END-EVALUATE */
                    break;
            }


            /*" -342- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0005_99_EXIT*/

        [StopWatch]
        /*" P0010-FINALIZAR-SECTION */
        private void P0010_FINALIZAR_SECTION()
        {
            /*" -352- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0010_00_START */

            P0010_00_START();

        }

        [StopWatch]
        /*" P0010-00-START */
        private void P0010_00_START(bool isPerform = false)
        {
            /*" -354- MOVE 'P0010' TO WS-SECTION */
            _.Move("P0010", WORK.WS_ERRO.WS_SECTION);

            /*" -355- IF LK-VG013-TRACE EQUAL 'S' */

            if (SPVG013W.LK_VG013_TRACE == "S")
            {

                /*" -356- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -356- END-IF. */
            }


        }

        [StopWatch]
        /*" P0010-05-INICIO */
        private void P0010_05_INICIO(bool isPerform = false)
        {
            /*" -361- MOVE 0 TO WS-IND-ERRO */
            _.Move(0, WORK.WS_ERRO.WS_IND_ERRO);

            /*" -363- STRING 'OPERACAO SOLICITADA REALIZADA COM SUCESSO.' DELIMITED BY SIZE INTO WS-MENSAGEM */
            #region STRING
            var spl3 = "OPERACAO SOLICITADA REALIZADA COM SUCESSO.";
            _.Move(spl3, WORK.WS_ERRO.WS_MENSAGEM);
            #endregion

            /*" -364- MOVE WS-MENSAGEM TO H-OUT-MENSAGEM */
            _.Move(WORK.WS_ERRO.WS_MENSAGEM, LBHCT002.H_OUT_MENSAGEM);

            /*" -367- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
            _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

            /*" -369- MOVE 0 TO WS-SQLCODE */
            _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

            /*" -379- MOVE FUNCTION CURRENT-DATE(1:14) TO WS-C-DATE-CURRENT */
            _.Move(_.CurrentDate(0, 14), WORK.WS_DATAS.WS_C_DATE_CURRENT);

            /*" -379- . */

        }

        [StopWatch]
        /*" P0010-99-EXIT */
        private void P0010_99_EXIT(bool isPerform = false)
        {
            /*" -382- GOBACK. */

            throw new GoBack();

        }

        [StopWatch]
        /*" P0050-VERIFICAR-SISTEMA-SECTION */
        private void P0050_VERIFICAR_SISTEMA_SECTION()
        {
            /*" -389- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0050_00_START */

            P0050_00_START();

        }

        [StopWatch]
        /*" P0050-00-START */
        private void P0050_00_START(bool isPerform = false)
        {
            /*" -392- MOVE 'P0050' TO WS-SECTION */
            _.Move("P0050", WORK.WS_ERRO.WS_SECTION);

            /*" -393- IF LK-VG013-TRACE EQUAL 'S' */

            if (SPVG013W.LK_VG013_TRACE == "S")
            {

                /*" -394- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -396- END-IF. */
            }


            /*" -396- PERFORM P0050-05-INICIO. */

            P0050_05_INICIO(true);

        }

        [StopWatch]
        /*" P0050-05-INICIO */
        private void P0050_05_INICIO(bool isPerform = false)
        {
            /*" -406- PERFORM P0050_05_INICIO_DB_SELECT_1 */

            P0050_05_INICIO_DB_SELECT_1();

            /*" -409- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -410- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -414- STRING WS-SECTION ' - ERRO NO SELECT NA SEGUROS.SISTEMA.' '<SISTEMA=VG>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl4 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl4 += " - ERRO NO SELECT NA SEGUROS.SISTEMA.";
                spl4 += "<SISTEMA=VG>";
                _.Move(spl4, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -415- MOVE 'SEGUROS.SISTEMAS' TO WS-TABELA */
                _.Move("SEGUROS.SISTEMAS", WORK.WS_ERRO.WS_TABELA);

                /*" -416- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -417- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -418- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -419- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -421- END-IF */
            }


            /*" -422- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -423- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -427- STRING WS-SECTION ' - REGISTRO DE CONTROLE SISTEMA NAO CADASTRADO.' '<SISTEMA=VG>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl5 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl5 += " - REGISTRO DE CONTROLE SISTEMA NAO CADASTRADO.";
                spl5 += "<SISTEMA=VG>";
                _.Move(spl5, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -428- MOVE 'SEGUROS.SISTEMAS' TO WS-TABELA */
                _.Move("SEGUROS.SISTEMAS", WORK.WS_ERRO.WS_TABELA);

                /*" -429- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -430- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -431- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -432- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -432- END-IF. */
            }


        }

        [StopWatch]
        /*" P0050-05-INICIO-DB-SELECT-1 */
        public void P0050_05_INICIO_DB_SELECT_1()
        {
            /*" -406- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VG' WITH UR END-EXEC. */

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
            /*" -442- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0100_00_START */

            P0100_00_START();

        }

        [StopWatch]
        /*" P0100-00-START */
        private void P0100_00_START(bool isPerform = false)
        {
            /*" -444- MOVE 'P0100' TO WS-SECTION */
            _.Move("P0100", WORK.WS_ERRO.WS_SECTION);

            /*" -445- IF LK-VG013-TRACE EQUAL 'S' */

            if (SPVG013W.LK_VG013_TRACE == "S")
            {

                /*" -446- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -447- END-IF. */
            }


            /*" -447- PERFORM P0100-05-INICIO */

            P0100_05_INICIO(true);

        }

        [StopWatch]
        /*" P0100-05-INICIO */
        private void P0100_05_INICIO(bool isPerform = false)
        {
            /*" -453- IF LK-VG013-SISTEMA-CHAMADOR EQUAL LOW-VALUES OR HIGH-VALUES */

            if (SPVG013W.LK_VG013_SISTEMA_CHAMADOR.IsLowValues() || SPVG013W.LK_VG013_SISTEMA_CHAMADOR.IsHighValues)
            {

                /*" -454- MOVE SPACES TO LK-VG013-SISTEMA-CHAMADOR */
                _.Move("", SPVG013W.LK_VG013_SISTEMA_CHAMADOR);

                /*" -456- END-IF */
            }


            /*" -457- IF LK-VG013-SISTEMA-CHAMADOR EQUAL SPACES */

            if (SPVG013W.LK_VG013_SISTEMA_CHAMADOR.IsEmpty())
            {

                /*" -458- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -462- STRING WS-SECTION ' - SISTEMA CHAMADOR NAO INFORMADO.' '<SISTEMA=' LK-VG013-SISTEMA-CHAMADOR '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl6 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl6 += " - SISTEMA CHAMADOR NAO INFORMADO.";
                spl6 += "<SISTEMA=";
                var spl7 = SPVG013W.LK_VG013_SISTEMA_CHAMADOR.GetMoveValues();
                spl7 += ">";
                var results8 = spl6 + spl7;
                _.Move(results8, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -465- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -466- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -467- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -469- END-IF */
            }


            /*" -470- IF LK-VG013-TIPO-ACAO EQUAL 0 OR GREATER 7 */

            if (SPVG013W.LK_VG013_TIPO_ACAO.IsEmpty() || SPVG013W.LK_VG013_TIPO_ACAO > 7)
            {

                /*" -471- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -472- MOVE LK-VG013-TIPO-ACAO TO WS-SMALLINT(01) */
                _.Move(SPVG013W.LK_VG013_TIPO_ACAO, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -476- STRING WS-SECTION ' - TIPO DE ACAO INFORMADA INVALIDA.' '<TIPO_ACAO=' WS-SMALLINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl8 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl8 += " - TIPO DE ACAO INFORMADA INVALIDA.";
                spl8 += "<TIPO_ACAO=";
                var spl9 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl9 += ">";
                var results10 = spl8 + spl9;
                _.Move(results10, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -479- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -480- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -481- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -482- ELSE */
            }
            else
            {


                /*" -483- CONTINUE */

                /*" -485- END-IF */
            }


            /*" -486- IF LK-VG013-IDE-SISTEMA EQUAL 'VG' OR 'SZ' */

            if (SPVG013W.LK_VG013_IDE_SISTEMA.In("VG", "SZ"))
            {

                /*" -487- CONTINUE */

                /*" -488- ELSE */
            }
            else
            {


                /*" -489- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -493- STRING WS-SECTION ' - IDE-SISTEMA DIFERENTE DE VG E SZ.' '<IDE-SISTEMA=' LK-VG013-IDE-SISTEMA '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl10 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl10 += " - IDE-SISTEMA DIFERENTE DE VG E SZ.";
                spl10 += "<IDE-SISTEMA=";
                var spl11 = SPVG013W.LK_VG013_IDE_SISTEMA.GetMoveValues();
                spl11 += ">";
                var results12 = spl10 + spl11;
                _.Move(results12, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -496- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -497- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -498- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -500- END-IF */
            }


            /*" -501- IF LK-VG013-NUM-CERTIFICADO EQUAL ZEROS */

            if (SPVG013W.LK_VG013_NUM_CERTIFICADO == 00)
            {

                /*" -502- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -503- MOVE LK-VG013-NUM-CERTIFICADO TO WS-BIGINT(01) */
                _.Move(SPVG013W.LK_VG013_NUM_CERTIFICADO, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -508- STRING WS-SECTION ' - CERTIFICADO NAO INFORMADO.' '<CERTIFICADO=' WS-BIGINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl12 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl12 += " - CERTIFICADO NAO INFORMADO.";
                spl12 += "<CERTIFICADO=";
                var spl13 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                spl13 += ">";
                var results14 = spl12 + spl13;
                _.Move(results14, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -511- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -512- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -513- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -515- END-IF */
            }


            /*" -516- IF LK-VG013-COD-PRODUTO EQUAL ZEROS */

            if (SPVG013W.LK_VG013_COD_PRODUTO == 00)
            {

                /*" -517- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -518- MOVE LK-VG013-COD-PRODUTO TO WS-SMALLINT(01) */
                _.Move(SPVG013W.LK_VG013_COD_PRODUTO, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -523- STRING WS-SECTION ' - PRODUTO NAO INFORMADO.' '<COD-PRODUTO=' WS-SMALLINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl14 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl14 += " - PRODUTO NAO INFORMADO.";
                spl14 += "<COD-PRODUTO=";
                var spl15 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl15 += ">";
                var results16 = spl14 + spl15;
                _.Move(results16, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -526- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -527- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -528- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -530- END-IF */
            }


            /*" -531- IF LK-VG013-COD-PLANO EQUAL ZEROS */

            if (SPVG013W.LK_VG013_COD_PLANO == 00)
            {

                /*" -532- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -533- MOVE LK-VG013-COD-PLANO TO WS-SMALLINT(01) */
                _.Move(SPVG013W.LK_VG013_COD_PLANO, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -538- STRING WS-SECTION ' - PLANO NAO INFORMADO.' '<COD-PLANO=' WS-SMALLINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl16 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl16 += " - PLANO NAO INFORMADO.";
                spl16 += "<COD-PLANO=";
                var spl17 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl17 += ">";
                var results18 = spl16 + spl17;
                _.Move(results18, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -541- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -542- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -543- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -545- END-IF */
            }


            /*" -546- IF LK-VG013-TIPO-ACAO EQUAL 1 */

            if (SPVG013W.LK_VG013_TIPO_ACAO == 1)
            {

                /*" -547- IF LK-VG013-QTD-TITULO EQUAL ZEROS */

                if (SPVG013W.LK_VG013_QTD_TITULO == 00)
                {

                    /*" -548- MOVE 1 TO WS-IND-ERRO */
                    _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                    /*" -549- MOVE LK-VG013-QTD-TITULO TO WS-SMALLINT(01) */
                    _.Move(SPVG013W.LK_VG013_QTD_TITULO, WORK.WS_EDIT.WS_SMALLINT[01]);

                    /*" -554- STRING WS-SECTION ' - QUANTIDADE DE TITULO INVALIDA.' '<QTD-TITULO=' WS-SMALLINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                    #region STRING
                    var spl18 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                    spl18 += " - QUANTIDADE DE TITULO INVALIDA.";
                    spl18 += "<QTD-TITULO=";
                    var spl19 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                    spl19 += ">";
                    var results20 = spl18 + spl19;
                    _.Move(results20, WORK.WS_ERRO.WS_MENSAGEM);
                    #endregion

                    /*" -557- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                    _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                    /*" -558- MOVE 0 TO WS-SQLCODE */
                    _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                    /*" -559- GO TO P9999-ERRO */

                    P9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -561- END-IF */
                }


                /*" -562- IF LK-VG013-VLR-TITULO GREATER ZEROS */

                if (SPVG013W.LK_VG013_VLR_TITULO > 00)
                {

                    /*" -563- CONTINUE */

                    /*" -564- ELSE */
                }
                else
                {


                    /*" -565- MOVE 1 TO WS-IND-ERRO */
                    _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                    /*" -566- MOVE LK-VG013-VLR-TITULO TO WS-DECIMAL(01) */
                    _.Move(SPVG013W.LK_VG013_VLR_TITULO, WORK.WS_EDIT.WS_DECIMAL[01]);

                    /*" -571- STRING WS-SECTION ' - VALOR DO TITULO INVALIDO.' '<VLR-TITULO=' WS-DECIMAL(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                    #region STRING
                    var spl20 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                    spl20 += " - VALOR DO TITULO INVALIDO.";
                    spl20 += "<VLR-TITULO=";
                    var spl21 = WORK.WS_EDIT.WS_DECIMAL[01].GetMoveValues();
                    spl21 += ">";
                    var results22 = spl20 + spl21;
                    _.Move(results22, WORK.WS_ERRO.WS_MENSAGEM);
                    #endregion

                    /*" -574- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                    _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                    /*" -575- MOVE 0 TO WS-SQLCODE */
                    _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                    /*" -576- GO TO P9999-ERRO */

                    P9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -578- END-IF */
                }


                /*" -579- IF LK-VG013-COD-EMPRESA-CAP EQUAL ZEROS */

                if (SPVG013W.LK_VG013_COD_EMPRESA_CAP == 00)
                {

                    /*" -580- MOVE 1 TO WS-IND-ERRO */
                    _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                    /*" -581- MOVE LK-VG013-COD-EMPRESA-CAP TO WS-INTEGER(01) */
                    _.Move(SPVG013W.LK_VG013_COD_EMPRESA_CAP, WORK.WS_EDIT.WS_INTEGER[01]);

                    /*" -586- STRING WS-SECTION ' - INFORME A EMPRESA CAP.' '<COD-EMPRESA-CAP=' WS-INTEGER(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                    #region STRING
                    var spl22 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                    spl22 += " - INFORME A EMPRESA CAP.";
                    spl22 += "<COD-EMPRESA-CAP=";
                    var spl23 = WORK.WS_EDIT.WS_INTEGER[01].GetMoveValues();
                    spl23 += ">";
                    var results24 = spl22 + spl23;
                    _.Move(results24, WORK.WS_ERRO.WS_MENSAGEM);
                    #endregion

                    /*" -589- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                    _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                    /*" -590- MOVE 0 TO WS-SQLCODE */
                    _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                    /*" -591- GO TO P9999-ERRO */

                    P9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -592- END-IF */
                }


                /*" -594- END-IF */
            }


            /*" -595- IF LK-VG013-TIPO-ACAO EQUAL 2 */

            if (SPVG013W.LK_VG013_TIPO_ACAO == 2)
            {

                /*" -596- IF LK-VG013-VLR-TITULO GREATER ZEROS */

                if (SPVG013W.LK_VG013_VLR_TITULO > 00)
                {

                    /*" -597- CONTINUE */

                    /*" -598- ELSE */
                }
                else
                {


                    /*" -599- MOVE 1 TO WS-IND-ERRO */
                    _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                    /*" -600- MOVE LK-VG013-VLR-TITULO TO WS-DECIMAL(01) */
                    _.Move(SPVG013W.LK_VG013_VLR_TITULO, WORK.WS_EDIT.WS_DECIMAL[01]);

                    /*" -605- STRING WS-SECTION ' - VALOR DO TITULO INVALIDO.' '<VLR-TITULO=' WS-DECIMAL(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                    #region STRING
                    var spl24 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                    spl24 += " - VALOR DO TITULO INVALIDO.";
                    spl24 += "<VLR-TITULO=";
                    var spl25 = WORK.WS_EDIT.WS_DECIMAL[01].GetMoveValues();
                    spl25 += ">";
                    var results26 = spl24 + spl25;
                    _.Move(results26, WORK.WS_ERRO.WS_MENSAGEM);
                    #endregion

                    /*" -608- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                    _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                    /*" -609- MOVE 0 TO WS-SQLCODE */
                    _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                    /*" -610- GO TO P9999-ERRO */

                    P9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -611- END-IF */
                }


                /*" -613- END-IF */
            }


            /*" -615- IF ((LK-VG013-TIPO-ACAO NOT EQUAL 1 AND 2 AND 5) AND LK-VG013-COD-RETORNO-API EQUAL ZEROS) */

            if (((!SPVG013W.LK_VG013_TIPO_ACAO.In("1", "2", "5")) && SPVG013W.LK_VG013_COD_RETORNO_API == 00))
            {

                /*" -616- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -617- MOVE LK-VG013-COD-RETORNO-API TO WS-SMALLINT(01) */
                _.Move(SPVG013W.LK_VG013_COD_RETORNO_API, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -622- STRING WS-SECTION ' - CODIGO DE RETORNO DA API INVALIDO.' '<COD-RETORNO=' WS-SMALLINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl26 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl26 += " - CODIGO DE RETORNO DA API INVALIDO.";
                spl26 += "<COD-RETORNO=";
                var spl27 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl27 += ">";
                var results28 = spl26 + spl27;
                _.Move(results28, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -625- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -626- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -627- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -629- END-IF */
            }


            /*" -631- IF LK-VG013-COD-USUARIO EQUAL SPACES OR LOW-VALUES OR HIGH-VALUES */

            if (SPVG013W.LK_VG013_COD_USUARIO.IsLowValues() || SPVG013W.LK_VG013_COD_USUARIO.IsHighValues)
            {

                /*" -632- MOVE 'ONLINE' TO LK-VG013-COD-USUARIO */
                _.Move("ONLINE", SPVG013W.LK_VG013_COD_USUARIO);

                /*" -635- END-IF */
            }


            /*" -635- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0100_99_EXIT*/

        [StopWatch]
        /*" P0200-INSERIR-VG0135-SECTION */
        private void P0200_INSERIR_VG0135_SECTION()
        {
            /*" -646- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0200_00_START */

            P0200_00_START();

        }

        [StopWatch]
        /*" P0200-00-START */
        private void P0200_00_START(bool isPerform = false)
        {
            /*" -648- MOVE 'P0200' TO WS-SECTION */
            _.Move("P0200", WORK.WS_ERRO.WS_SECTION);

            /*" -649- IF LK-VG013-TRACE EQUAL 'S' */

            if (SPVG013W.LK_VG013_TRACE == "S")
            {

                /*" -650- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -652- END-IF */
            }


            /*" -654- INITIALIZE DCLVG-ACOPLADO */
            _.Initialize(
                VG135.DCLVG_ACOPLADO
            );

            /*" -655- MOVE LK-VG013-IDE-SISTEMA TO VG135-IDE-SISTEMA */
            _.Move(SPVG013W.LK_VG013_IDE_SISTEMA, VG135.DCLVG_ACOPLADO.VG135_IDE_SISTEMA);

            /*" -656- MOVE LK-VG013-NUM-CERTIFICADO TO VG135-NUM-CERTIFICADO */
            _.Move(SPVG013W.LK_VG013_NUM_CERTIFICADO, VG135.DCLVG_ACOPLADO.VG135_NUM_CERTIFICADO);

            /*" -657- MOVE LK-VG013-COD-PRODUTO TO VG135-COD-PRODUTO */
            _.Move(SPVG013W.LK_VG013_COD_PRODUTO, VG135.DCLVG_ACOPLADO.VG135_COD_PRODUTO);

            /*" -658- MOVE LK-VG013-COD-PLANO TO VG135-COD-PLANO */
            _.Move(SPVG013W.LK_VG013_COD_PLANO, VG135.DCLVG_ACOPLADO.VG135_COD_PLANO);

            /*" -659- MOVE SISTEMAS-DATA-MOV-ABERTO TO VG135-DTA-MOVIMENTO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, VG135.DCLVG_ACOPLADO.VG135_DTA_MOVIMENTO);

            /*" -660- MOVE ZEROS TO VG135-STA-ACOPLADO */
            _.Move(0, VG135.DCLVG_ACOPLADO.VG135_STA_ACOPLADO);

            /*" -661- MOVE LK-VG013-COD-EMPRESA-CAP TO VG135-COD-EMPRESA-CAP */
            _.Move(SPVG013W.LK_VG013_COD_EMPRESA_CAP, VG135.DCLVG_ACOPLADO.VG135_COD_EMPRESA_CAP);

            /*" -662- MOVE LK-VG013-QTD-TITULO TO VG135-QTD-TITULO */
            _.Move(SPVG013W.LK_VG013_QTD_TITULO, VG135.DCLVG_ACOPLADO.VG135_QTD_TITULO);

            /*" -663- MOVE LK-VG013-VLR-TITULO TO VG135-VLR-TITULO */
            _.Move(SPVG013W.LK_VG013_VLR_TITULO, VG135.DCLVG_ACOPLADO.VG135_VLR_TITULO);

            /*" -664- MOVE LK-VG013-COD-USUARIO TO VG135-COD-USUARIO */
            _.Move(SPVG013W.LK_VG013_COD_USUARIO, VG135.DCLVG_ACOPLADO.VG135_COD_USUARIO);

            /*" -665- MOVE WS-PROGRAMA TO VG135-NOM-PROGRAMA */
            _.Move(WORK.WS_PROGRAMA, VG135.DCLVG_ACOPLADO.VG135_NOM_PROGRAMA);

            /*" -667- MOVE WS-CURRENT-TIMESTAMP TO VG135-DTH-CADASTRAMENTO */
            _.Move(WORK.WS_DATAS.WS_CURRENT_TIMESTAMP, VG135.DCLVG_ACOPLADO.VG135_DTH_CADASTRAMENTO);

            /*" -667- . */

        }

        [StopWatch]
        /*" P0200-05-INICIO */
        private void P0200_05_INICIO(bool isPerform = false)
        {
            /*" -700- PERFORM P0200_05_INICIO_DB_INSERT_1 */

            P0200_05_INICIO_DB_INSERT_1();

            /*" -703-  EVALUATE SQLCODE  */

            /*" -704-  WHEN ZEROS  */

            /*" -704- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -705- CONTINUE */

                /*" -706-  WHEN OTHER  */

                /*" -706- ELSE */
            }
            else
            {


                /*" -707- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -708- MOVE VG135-NUM-CERTIFICADO TO WS-BIGINT(01) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_NUM_CERTIFICADO, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -709- MOVE VG135-COD-PRODUTO TO WS-SMALLINT(01) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_COD_PRODUTO, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -710- MOVE VG135-COD-PLANO TO WS-SMALLINT(02) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_COD_PLANO, WORK.WS_EDIT.WS_SMALLINT[02]);

                /*" -716- STRING WS-SECTION ' - ERRO AO INSERIR NA VG_ACOPLADO.' '<CERTIFICADO= ' WS-BIGINT(01) '>' '<PRODUTO= ' WS-SMALLINT(01) '>' '<PLANO= ' WS-SMALLINT(02) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl28 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl28 += " - ERRO AO INSERIR NA VG_ACOPLADO.";
                spl28 += "<CERTIFICADO= ";
                var spl29 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                spl29 += ">";
                spl29 += "<PRODUTO= ";
                var spl30 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl30 += ">";
                spl30 += "<PLANO= ";
                var spl31 = WORK.WS_EDIT.WS_SMALLINT[02].GetMoveValues();
                spl31 += ">";
                var results32 = spl28 + spl29 + spl30 + spl31;
                _.Move(results32, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -718- MOVE 'SEGUROS.VG_ACOPLADO_HIST' TO WS-TABELA */
                _.Move("SEGUROS.VG_ACOPLADO_HIST", WORK.WS_ERRO.WS_TABELA);

                /*" -719- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -720- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -721- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -722- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -724-  END-EVALUATE  */

                /*" -724- END-IF */
            }


            /*" -724- . */

        }

        [StopWatch]
        /*" P0200-05-INICIO-DB-INSERT-1 */
        public void P0200_05_INICIO_DB_INSERT_1()
        {
            /*" -700- EXEC SQL INSERT INTO SEGUROS.VG_ACOPLADO ( IDE_SISTEMA , NUM_CERTIFICADO , COD_PRODUTO , COD_PLANO , DTA_MOVIMENTO , STA_ACOPLADO , COD_EMPRESA_CAP , QTD_TITULO , VLR_TITULO , COD_USUARIO , NOM_PROGRAMA , DTH_CADASTRAMENTO ) VALUES ( :VG135-IDE-SISTEMA , :VG135-NUM-CERTIFICADO , :VG135-COD-PRODUTO , :VG135-COD-PLANO , :VG135-DTA-MOVIMENTO , :VG135-STA-ACOPLADO , :VG135-COD-EMPRESA-CAP , :VG135-QTD-TITULO , :VG135-VLR-TITULO , :VG135-COD-USUARIO , :VG135-NOM-PROGRAMA , :VG135-DTH-CADASTRAMENTO ) END-EXEC */

            var p0200_05_INICIO_DB_INSERT_1_Insert1 = new P0200_05_INICIO_DB_INSERT_1_Insert1()
            {
                VG135_IDE_SISTEMA = VG135.DCLVG_ACOPLADO.VG135_IDE_SISTEMA.ToString(),
                VG135_NUM_CERTIFICADO = VG135.DCLVG_ACOPLADO.VG135_NUM_CERTIFICADO.ToString(),
                VG135_COD_PRODUTO = VG135.DCLVG_ACOPLADO.VG135_COD_PRODUTO.ToString(),
                VG135_COD_PLANO = VG135.DCLVG_ACOPLADO.VG135_COD_PLANO.ToString(),
                VG135_DTA_MOVIMENTO = VG135.DCLVG_ACOPLADO.VG135_DTA_MOVIMENTO.ToString(),
                VG135_STA_ACOPLADO = VG135.DCLVG_ACOPLADO.VG135_STA_ACOPLADO.ToString(),
                VG135_COD_EMPRESA_CAP = VG135.DCLVG_ACOPLADO.VG135_COD_EMPRESA_CAP.ToString(),
                VG135_QTD_TITULO = VG135.DCLVG_ACOPLADO.VG135_QTD_TITULO.ToString(),
                VG135_VLR_TITULO = VG135.DCLVG_ACOPLADO.VG135_VLR_TITULO.ToString(),
                VG135_COD_USUARIO = VG135.DCLVG_ACOPLADO.VG135_COD_USUARIO.ToString(),
                VG135_NOM_PROGRAMA = VG135.DCLVG_ACOPLADO.VG135_NOM_PROGRAMA.ToString(),
                VG135_DTH_CADASTRAMENTO = VG135.DCLVG_ACOPLADO.VG135_DTH_CADASTRAMENTO.ToString(),
            };

            P0200_05_INICIO_DB_INSERT_1_Insert1.Execute(p0200_05_INICIO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0200_99_EXIT*/

        [StopWatch]
        /*" P0210-ATUALIZAR-VG0135-SECTION */
        private void P0210_ATUALIZAR_VG0135_SECTION()
        {
            /*" -735- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0210_00_START */

            P0210_00_START();

        }

        [StopWatch]
        /*" P0210-00-START */
        private void P0210_00_START(bool isPerform = false)
        {
            /*" -737- MOVE 'P0210' TO WS-SECTION */
            _.Move("P0210", WORK.WS_ERRO.WS_SECTION);

            /*" -738- IF LK-VG013-TRACE EQUAL 'S' */

            if (SPVG013W.LK_VG013_TRACE == "S")
            {

                /*" -739- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -742- END-IF */
            }


            /*" -743- MOVE SISTEMAS-DATA-MOV-ABERTO TO VG135-DTA-MOVIMENTO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, VG135.DCLVG_ACOPLADO.VG135_DTA_MOVIMENTO);

            /*" -744- MOVE LK-VG013-COD-USUARIO TO VG135-COD-USUARIO */
            _.Move(SPVG013W.LK_VG013_COD_USUARIO, VG135.DCLVG_ACOPLADO.VG135_COD_USUARIO);

            /*" -745- MOVE WS-PROGRAMA TO VG135-NOM-PROGRAMA */
            _.Move(WORK.WS_PROGRAMA, VG135.DCLVG_ACOPLADO.VG135_NOM_PROGRAMA);

            /*" -748- MOVE WS-CURRENT-TIMESTAMP TO VG135-DTH-CADASTRAMENTO */
            _.Move(WORK.WS_DATAS.WS_CURRENT_TIMESTAMP, VG135.DCLVG_ACOPLADO.VG135_DTH_CADASTRAMENTO);

            /*" -748- . */

        }

        [StopWatch]
        /*" P0210-05-INICIO */
        private void P0210_05_INICIO(bool isPerform = false)
        {
            /*" -764- PERFORM P0210_05_INICIO_DB_UPDATE_1 */

            P0210_05_INICIO_DB_UPDATE_1();

            /*" -767-  EVALUATE SQLCODE  */

            /*" -768-  WHEN ZEROS  */

            /*" -768- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -769- CONTINUE */

                /*" -770-  WHEN OTHER  */

                /*" -770- ELSE */
            }
            else
            {


                /*" -771- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -772- MOVE VG135-NUM-CERTIFICADO TO WS-BIGINT(01) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_NUM_CERTIFICADO, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -773- MOVE VG135-COD-PRODUTO TO WS-SMALLINT(01) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_COD_PRODUTO, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -774- MOVE VG135-COD-PLANO TO WS-SMALLINT(02) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_COD_PLANO, WORK.WS_EDIT.WS_SMALLINT[02]);

                /*" -780- STRING WS-SECTION ' - ERRO NO UPDATE SEGUROS.VG_ACOPLADO.' '<CERTIFICADO= ' WS-BIGINT(01) '>' '<PRODUTO= ' WS-SMALLINT(01) '>' '<PLANO= ' WS-SMALLINT(02) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl32 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl32 += " - ERRO NO UPDATE SEGUROS.VG_ACOPLADO.";
                spl32 += "<CERTIFICADO= ";
                var spl33 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                spl33 += ">";
                spl33 += "<PRODUTO= ";
                var spl34 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl34 += ">";
                spl34 += "<PLANO= ";
                var spl35 = WORK.WS_EDIT.WS_SMALLINT[02].GetMoveValues();
                spl35 += ">";
                var results36 = spl32 + spl33 + spl34 + spl35;
                _.Move(results36, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -782- MOVE 'SEGUROS.VG_ACOPLADO' TO WS-TABELA */
                _.Move("SEGUROS.VG_ACOPLADO", WORK.WS_ERRO.WS_TABELA);

                /*" -783- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -784- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -785- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -786- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -788-  END-EVALUATE  */

                /*" -788- END-IF */
            }


            /*" -788- . */

        }

        [StopWatch]
        /*" P0210-05-INICIO-DB-UPDATE-1 */
        public void P0210_05_INICIO_DB_UPDATE_1()
        {
            /*" -764- EXEC SQL UPDATE SEGUROS.VG_ACOPLADO SET STA_ACOPLADO = :VG135-STA-ACOPLADO , VLR_TITULO = :VG135-VLR-TITULO , DTA_MOVIMENTO = :VG135-DTA-MOVIMENTO , DTH_CADASTRAMENTO = :VG135-DTH-CADASTRAMENTO , COD_USUARIO = :VG135-COD-USUARIO , NOM_PROGRAMA = :VG135-NOM-PROGRAMA WHERE IDE_SISTEMA = :VG135-IDE-SISTEMA AND NUM_CERTIFICADO = :VG135-NUM-CERTIFICADO AND COD_PRODUTO = :VG135-COD-PRODUTO AND COD_PLANO = :VG135-COD-PLANO END-EXEC */

            var p0210_05_INICIO_DB_UPDATE_1_Update1 = new P0210_05_INICIO_DB_UPDATE_1_Update1()
            {
                VG135_DTH_CADASTRAMENTO = VG135.DCLVG_ACOPLADO.VG135_DTH_CADASTRAMENTO.ToString(),
                VG135_DTA_MOVIMENTO = VG135.DCLVG_ACOPLADO.VG135_DTA_MOVIMENTO.ToString(),
                VG135_STA_ACOPLADO = VG135.DCLVG_ACOPLADO.VG135_STA_ACOPLADO.ToString(),
                VG135_NOM_PROGRAMA = VG135.DCLVG_ACOPLADO.VG135_NOM_PROGRAMA.ToString(),
                VG135_COD_USUARIO = VG135.DCLVG_ACOPLADO.VG135_COD_USUARIO.ToString(),
                VG135_VLR_TITULO = VG135.DCLVG_ACOPLADO.VG135_VLR_TITULO.ToString(),
                VG135_NUM_CERTIFICADO = VG135.DCLVG_ACOPLADO.VG135_NUM_CERTIFICADO.ToString(),
                VG135_IDE_SISTEMA = VG135.DCLVG_ACOPLADO.VG135_IDE_SISTEMA.ToString(),
                VG135_COD_PRODUTO = VG135.DCLVG_ACOPLADO.VG135_COD_PRODUTO.ToString(),
                VG135_COD_PLANO = VG135.DCLVG_ACOPLADO.VG135_COD_PLANO.ToString(),
            };

            P0210_05_INICIO_DB_UPDATE_1_Update1.Execute(p0210_05_INICIO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0210_99_EXIT*/

        [StopWatch]
        /*" P0250-CONSULTA-VG135-SECTION */
        private void P0250_CONSULTA_VG135_SECTION()
        {
            /*" -796- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0250_00_START */

            P0250_00_START();

        }

        [StopWatch]
        /*" P0250-00-START */
        private void P0250_00_START(bool isPerform = false)
        {
            /*" -799- MOVE 'P0250' TO WS-SECTION */
            _.Move("P0250", WORK.WS_ERRO.WS_SECTION);

            /*" -800- IF LK-VG013-TRACE EQUAL 'S' */

            if (SPVG013W.LK_VG013_TRACE == "S")
            {

                /*" -801- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -803- END-IF */
            }


            /*" -806- INITIALIZE DCLVG-ACOPLADO WS-ACOPLADO */
            _.Initialize(
                VG135.DCLVG_ACOPLADO
                , WORK.WS_ACOPLADO
            );

            /*" -807- MOVE LK-VG013-IDE-SISTEMA TO VG135-IDE-SISTEMA */
            _.Move(SPVG013W.LK_VG013_IDE_SISTEMA, VG135.DCLVG_ACOPLADO.VG135_IDE_SISTEMA);

            /*" -808- MOVE LK-VG013-NUM-CERTIFICADO TO VG135-NUM-CERTIFICADO */
            _.Move(SPVG013W.LK_VG013_NUM_CERTIFICADO, VG135.DCLVG_ACOPLADO.VG135_NUM_CERTIFICADO);

            /*" -809- MOVE LK-VG013-COD-PRODUTO TO VG135-COD-PRODUTO */
            _.Move(SPVG013W.LK_VG013_COD_PRODUTO, VG135.DCLVG_ACOPLADO.VG135_COD_PRODUTO);

            /*" -811- MOVE LK-VG013-COD-PLANO TO VG135-COD-PLANO */
            _.Move(SPVG013W.LK_VG013_COD_PLANO, VG135.DCLVG_ACOPLADO.VG135_COD_PLANO);

            /*" -812- PERFORM P0250-05-INICIO */

            P0250_05_INICIO(true);

            /*" -812- . */

        }

        [StopWatch]
        /*" P0250-05-INICIO */
        private void P0250_05_INICIO(bool isPerform = false)
        {
            /*" -838- PERFORM P0250_05_INICIO_DB_SELECT_1 */

            P0250_05_INICIO_DB_SELECT_1();

            /*" -841-  EVALUATE SQLCODE  */

            /*" -842-  WHEN ZEROS  */

            /*" -842- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -843- SET WS-TEM-ACOPLADO TO TRUE */
                WORK.WS_ACOPLADO["WS_TEM_ACOPLADO"] = true;

                /*" -844-  WHEN +100  */

                /*" -844- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -845- SET WS-SEM-ACOPLADO TO TRUE */
                WORK.WS_ACOPLADO["WS_SEM_ACOPLADO"] = true;

                /*" -846-  WHEN OTHER  */

                /*" -846- ELSE */
            }
            else
            {


                /*" -847- MOVE 'P0250' TO WS-SECTION */
                _.Move("P0250", WORK.WS_ERRO.WS_SECTION);

                /*" -848- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -849- MOVE VG135-NUM-CERTIFICADO TO WS-BIGINT(01) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_NUM_CERTIFICADO, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -850- MOVE VG135-COD-PRODUTO TO WS-SMALLINT(01) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_COD_PRODUTO, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -851- MOVE VG135-COD-PLANO TO WS-SMALLINT(02) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_COD_PLANO, WORK.WS_EDIT.WS_SMALLINT[02]);

                /*" -857- STRING WS-SECTION ' - ERRO NA CONSULTA DA VG_ACOPLADO. ' '<CERTIFICADO= ' WS-BIGINT(01) '>' '<PRODUTO= ' WS-SMALLINT(01) '>' '<PLANO= ' WS-SMALLINT(02) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl36 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl36 += " - ERRO NA CONSULTA DA VG_ACOPLADO. ";
                spl36 += "<CERTIFICADO= ";
                var spl37 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                spl37 += ">";
                spl37 += "<PRODUTO= ";
                var spl38 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl38 += ">";
                spl38 += "<PLANO= ";
                var spl39 = WORK.WS_EDIT.WS_SMALLINT[02].GetMoveValues();
                spl39 += ">";
                var results40 = spl36 + spl37 + spl38 + spl39;
                _.Move(results40, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -858- MOVE 'SEGUROS.VG_ACOPLADO' TO WS-TABELA */
                _.Move("SEGUROS.VG_ACOPLADO", WORK.WS_ERRO.WS_TABELA);

                /*" -859- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -860- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -861- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -862- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -864-  END-EVALUATE  */

                /*" -864- END-IF */
            }


            /*" -864- . */

        }

        [StopWatch]
        /*" P0250-05-INICIO-DB-SELECT-1 */
        public void P0250_05_INICIO_DB_SELECT_1()
        {
            /*" -838- EXEC SQL SELECT STA_ACOPLADO , COD_EMPRESA_CAP , QTD_TITULO , VLR_TITULO , COD_USUARIO , SEQ_REMESSA , SEQ_REGISTRO INTO :VG135-STA-ACOPLADO , :VG135-COD-EMPRESA-CAP , :VG135-QTD-TITULO , :VG135-VLR-TITULO , :VG135-COD-USUARIO , :VG135-SEQ-REMESSA :WS-NULL-SEQ-REMSSA , :VG135-SEQ-REGISTRO :WS-NULL-SEQ-REGISTRO FROM SEGUROS.VG_ACOPLADO WHERE IDE_SISTEMA = :VG135-IDE-SISTEMA AND NUM_CERTIFICADO = :VG135-NUM-CERTIFICADO AND COD_PRODUTO = :VG135-COD-PRODUTO AND COD_PLANO = :VG135-COD-PLANO WITH UR END-EXEC. */

            var p0250_05_INICIO_DB_SELECT_1_Query1 = new P0250_05_INICIO_DB_SELECT_1_Query1()
            {
                VG135_NUM_CERTIFICADO = VG135.DCLVG_ACOPLADO.VG135_NUM_CERTIFICADO.ToString(),
                VG135_IDE_SISTEMA = VG135.DCLVG_ACOPLADO.VG135_IDE_SISTEMA.ToString(),
                VG135_COD_PRODUTO = VG135.DCLVG_ACOPLADO.VG135_COD_PRODUTO.ToString(),
                VG135_COD_PLANO = VG135.DCLVG_ACOPLADO.VG135_COD_PLANO.ToString(),
            };

            var executed_1 = P0250_05_INICIO_DB_SELECT_1_Query1.Execute(p0250_05_INICIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VG135_STA_ACOPLADO, VG135.DCLVG_ACOPLADO.VG135_STA_ACOPLADO);
                _.Move(executed_1.VG135_COD_EMPRESA_CAP, VG135.DCLVG_ACOPLADO.VG135_COD_EMPRESA_CAP);
                _.Move(executed_1.VG135_QTD_TITULO, VG135.DCLVG_ACOPLADO.VG135_QTD_TITULO);
                _.Move(executed_1.VG135_VLR_TITULO, VG135.DCLVG_ACOPLADO.VG135_VLR_TITULO);
                _.Move(executed_1.VG135_COD_USUARIO, VG135.DCLVG_ACOPLADO.VG135_COD_USUARIO);
                _.Move(executed_1.VG135_SEQ_REMESSA, VG135.DCLVG_ACOPLADO.VG135_SEQ_REMESSA);
                _.Move(executed_1.WS_NULL_SEQ_REMSSA, WORK.WS_AUXILIARES.WS_NULL_SEQ_REMSSA);
                _.Move(executed_1.VG135_SEQ_REGISTRO, VG135.DCLVG_ACOPLADO.VG135_SEQ_REGISTRO);
                _.Move(executed_1.WS_NULL_SEQ_REGISTRO, WORK.WS_AUXILIARES.WS_NULL_SEQ_REGISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0250_99_EXIT*/

        [StopWatch]
        /*" P0300-INSERIR-VG0137-SECTION */
        private void P0300_INSERIR_VG0137_SECTION()
        {
            /*" -875- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0300_00_START */

            P0300_00_START();

        }

        [StopWatch]
        /*" P0300-00-START */
        private void P0300_00_START(bool isPerform = false)
        {
            /*" -877- MOVE 'P0300' TO WS-SECTION */
            _.Move("P0300", WORK.WS_ERRO.WS_SECTION);

            /*" -878- IF LK-VG013-TRACE EQUAL 'S' */

            if (SPVG013W.LK_VG013_TRACE == "S")
            {

                /*" -879- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -881- END-IF */
            }


            /*" -883- INITIALIZE DCLVG-ACOPLADO-HIST */
            _.Initialize(
                VG137.DCLVG_ACOPLADO_HIST
            );

            /*" -884- MOVE VG135-IDE-SISTEMA TO VG137-IDE-SISTEMA */
            _.Move(VG135.DCLVG_ACOPLADO.VG135_IDE_SISTEMA, VG137.DCLVG_ACOPLADO_HIST.VG137_IDE_SISTEMA);

            /*" -885- MOVE VG135-NUM-CERTIFICADO TO VG137-NUM-CERTIFICADO */
            _.Move(VG135.DCLVG_ACOPLADO.VG135_NUM_CERTIFICADO, VG137.DCLVG_ACOPLADO_HIST.VG137_NUM_CERTIFICADO);

            /*" -886- MOVE VG135-COD-PRODUTO TO VG137-COD-PRODUTO */
            _.Move(VG135.DCLVG_ACOPLADO.VG135_COD_PRODUTO, VG137.DCLVG_ACOPLADO_HIST.VG137_COD_PRODUTO);

            /*" -887- MOVE VG135-COD-PLANO TO VG137-COD-PLANO */
            _.Move(VG135.DCLVG_ACOPLADO.VG135_COD_PLANO, VG137.DCLVG_ACOPLADO_HIST.VG137_COD_PLANO);

            /*" -888- MOVE WS-CURRENT-TIMESTAMP TO VG137-DTH-CADASTRAMENTO */
            _.Move(WORK.WS_DATAS.WS_CURRENT_TIMESTAMP, VG137.DCLVG_ACOPLADO_HIST.VG137_DTH_CADASTRAMENTO);

            /*" -889- MOVE VG135-DTA-MOVIMENTO TO VG137-DTA-MOVIMENTO */
            _.Move(VG135.DCLVG_ACOPLADO.VG135_DTA_MOVIMENTO, VG137.DCLVG_ACOPLADO_HIST.VG137_DTA_MOVIMENTO);

            /*" -890- MOVE VG135-STA-ACOPLADO TO VG137-STA-ACOPLADO */
            _.Move(VG135.DCLVG_ACOPLADO.VG135_STA_ACOPLADO, VG137.DCLVG_ACOPLADO_HIST.VG137_STA_ACOPLADO);

            /*" -891- MOVE VG135-COD-EMPRESA-CAP TO VG137-COD-EMPRESA-CAP */
            _.Move(VG135.DCLVG_ACOPLADO.VG135_COD_EMPRESA_CAP, VG137.DCLVG_ACOPLADO_HIST.VG137_COD_EMPRESA_CAP);

            /*" -892- MOVE VG135-QTD-TITULO TO VG137-QTD-TITULO */
            _.Move(VG135.DCLVG_ACOPLADO.VG135_QTD_TITULO, VG137.DCLVG_ACOPLADO_HIST.VG137_QTD_TITULO);

            /*" -893- MOVE VG135-VLR-TITULO TO VG137-VLR-TITULO */
            _.Move(VG135.DCLVG_ACOPLADO.VG135_VLR_TITULO, VG137.DCLVG_ACOPLADO_HIST.VG137_VLR_TITULO);

            /*" -894- MOVE VG135-COD-USUARIO TO VG137-COD-USUARIO */
            _.Move(VG135.DCLVG_ACOPLADO.VG135_COD_USUARIO, VG137.DCLVG_ACOPLADO_HIST.VG137_COD_USUARIO);

            /*" -896- MOVE VG135-NOM-PROGRAMA TO VG137-NOM-PROGRAMA */
            _.Move(VG135.DCLVG_ACOPLADO.VG135_NOM_PROGRAMA, VG137.DCLVG_ACOPLADO_HIST.VG137_NOM_PROGRAMA);

            /*" -897- IF WS-NULL-SEQ-REMSSA NOT EQUAL -1 */

            if (WORK.WS_AUXILIARES.WS_NULL_SEQ_REMSSA != -1)
            {

                /*" -898- MOVE VG135-SEQ-REMESSA TO VG137-SEQ-REMESSA */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_SEQ_REMESSA, VG137.DCLVG_ACOPLADO_HIST.VG137_SEQ_REMESSA);

                /*" -900- END-IF */
            }


            /*" -901- IF WS-NULL-SEQ-REGISTRO NOT EQUAL -1 */

            if (WORK.WS_AUXILIARES.WS_NULL_SEQ_REGISTRO != -1)
            {

                /*" -902- MOVE VG135-SEQ-REGISTRO TO VG137-SEQ-REGISTRO */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_SEQ_REGISTRO, VG137.DCLVG_ACOPLADO_HIST.VG137_SEQ_REGISTRO);

                /*" -904- END-IF */
            }


            /*" -904- . */

        }

        [StopWatch]
        /*" P0300-05-INICIO */
        private void P0300_05_INICIO(bool isPerform = false)
        {
            /*" -941- PERFORM P0300_05_INICIO_DB_INSERT_1 */

            P0300_05_INICIO_DB_INSERT_1();

            /*" -944-  EVALUATE SQLCODE  */

            /*" -945-  WHEN ZEROS  */

            /*" -945- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -946- CONTINUE */

                /*" -947-  WHEN OTHER  */

                /*" -947- ELSE */
            }
            else
            {


                /*" -948- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -949- MOVE VG137-NUM-CERTIFICADO TO WS-BIGINT(01) */
                _.Move(VG137.DCLVG_ACOPLADO_HIST.VG137_NUM_CERTIFICADO, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -950- MOVE VG137-COD-PRODUTO TO WS-SMALLINT(01) */
                _.Move(VG137.DCLVG_ACOPLADO_HIST.VG137_COD_PRODUTO, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -951- MOVE VG137-COD-PLANO TO WS-SMALLINT(02) */
                _.Move(VG137.DCLVG_ACOPLADO_HIST.VG137_COD_PLANO, WORK.WS_EDIT.WS_SMALLINT[02]);

                /*" -957- STRING WS-SECTION ' - ERRO NO INSERT SEGUROS.VG_ACOPLADO_HIST.' '<CERTIFICADO= ' WS-BIGINT(01) '>' '<PRODUTO= ' WS-SMALLINT(01) '>' '<PLANO= ' WS-SMALLINT(02) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl40 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl40 += " - ERRO NO INSERT SEGUROS.VG_ACOPLADO_HIST.";
                spl40 += "<CERTIFICADO= ";
                var spl41 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                spl41 += ">";
                spl41 += "<PRODUTO= ";
                var spl42 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl42 += ">";
                spl42 += "<PLANO= ";
                var spl43 = WORK.WS_EDIT.WS_SMALLINT[02].GetMoveValues();
                spl43 += ">";
                var results44 = spl40 + spl41 + spl42 + spl43;
                _.Move(results44, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -959- MOVE 'SEGUROS.VG_ACOPLADO_HIST' TO WS-TABELA */
                _.Move("SEGUROS.VG_ACOPLADO_HIST", WORK.WS_ERRO.WS_TABELA);

                /*" -960- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -961- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -962- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -963- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -965-  END-EVALUATE  */

                /*" -965- END-IF */
            }


            /*" -965- . */

        }

        [StopWatch]
        /*" P0300-05-INICIO-DB-INSERT-1 */
        public void P0300_05_INICIO_DB_INSERT_1()
        {
            /*" -941- EXEC SQL INSERT INTO SEGUROS.VG_ACOPLADO_HIST ( IDE_SISTEMA , NUM_CERTIFICADO , COD_PRODUTO , COD_PLANO , DTH_CADASTRAMENTO , DTA_MOVIMENTO , STA_ACOPLADO , COD_EMPRESA_CAP , QTD_TITULO , VLR_TITULO , COD_USUARIO , NOM_PROGRAMA , SEQ_REMESSA , SEQ_REGISTRO ) VALUES ( :VG137-IDE-SISTEMA , :VG137-NUM-CERTIFICADO , :VG137-COD-PRODUTO , :VG137-COD-PLANO , :VG137-DTH-CADASTRAMENTO , :VG137-DTA-MOVIMENTO , :VG137-STA-ACOPLADO , :VG137-COD-EMPRESA-CAP , :VG137-QTD-TITULO , :VG137-VLR-TITULO , :VG137-COD-USUARIO , :VG137-NOM-PROGRAMA , :VG137-SEQ-REMESSA :WS-NULL-SEQ-REMSSA , :VG137-SEQ-REGISTRO :WS-NULL-SEQ-REGISTRO ) END-EXEC */

            var p0300_05_INICIO_DB_INSERT_1_Insert1 = new P0300_05_INICIO_DB_INSERT_1_Insert1()
            {
                VG137_IDE_SISTEMA = VG137.DCLVG_ACOPLADO_HIST.VG137_IDE_SISTEMA.ToString(),
                VG137_NUM_CERTIFICADO = VG137.DCLVG_ACOPLADO_HIST.VG137_NUM_CERTIFICADO.ToString(),
                VG137_COD_PRODUTO = VG137.DCLVG_ACOPLADO_HIST.VG137_COD_PRODUTO.ToString(),
                VG137_COD_PLANO = VG137.DCLVG_ACOPLADO_HIST.VG137_COD_PLANO.ToString(),
                VG137_DTH_CADASTRAMENTO = VG137.DCLVG_ACOPLADO_HIST.VG137_DTH_CADASTRAMENTO.ToString(),
                VG137_DTA_MOVIMENTO = VG137.DCLVG_ACOPLADO_HIST.VG137_DTA_MOVIMENTO.ToString(),
                VG137_STA_ACOPLADO = VG137.DCLVG_ACOPLADO_HIST.VG137_STA_ACOPLADO.ToString(),
                VG137_COD_EMPRESA_CAP = VG137.DCLVG_ACOPLADO_HIST.VG137_COD_EMPRESA_CAP.ToString(),
                VG137_QTD_TITULO = VG137.DCLVG_ACOPLADO_HIST.VG137_QTD_TITULO.ToString(),
                VG137_VLR_TITULO = VG137.DCLVG_ACOPLADO_HIST.VG137_VLR_TITULO.ToString(),
                VG137_COD_USUARIO = VG137.DCLVG_ACOPLADO_HIST.VG137_COD_USUARIO.ToString(),
                VG137_NOM_PROGRAMA = VG137.DCLVG_ACOPLADO_HIST.VG137_NOM_PROGRAMA.ToString(),
                VG137_SEQ_REMESSA = VG137.DCLVG_ACOPLADO_HIST.VG137_SEQ_REMESSA.ToString(),
                WS_NULL_SEQ_REMSSA = WORK.WS_AUXILIARES.WS_NULL_SEQ_REMSSA.ToString(),
                VG137_SEQ_REGISTRO = VG137.DCLVG_ACOPLADO_HIST.VG137_SEQ_REGISTRO.ToString(),
                WS_NULL_SEQ_REGISTRO = WORK.WS_AUXILIARES.WS_NULL_SEQ_REGISTRO.ToString(),
            };

            P0300_05_INICIO_DB_INSERT_1_Insert1.Execute(p0300_05_INICIO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0300_99_EXIT*/

        [StopWatch]
        /*" P0400-INSERIR-VG0139-SECTION */
        private void P0400_INSERIR_VG0139_SECTION()
        {
            /*" -976- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0400_00_START */

            P0400_00_START();

        }

        [StopWatch]
        /*" P0400-00-START */
        private void P0400_00_START(bool isPerform = false)
        {
            /*" -978- MOVE 'P0400' TO WS-SECTION */
            _.Move("P0400", WORK.WS_ERRO.WS_SECTION);

            /*" -979- IF LK-VG013-TRACE EQUAL 'S' */

            if (SPVG013W.LK_VG013_TRACE == "S")
            {

                /*" -980- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -982- END-IF */
            }


            /*" -984- INITIALIZE DCLVG-ACOPLADO-ERRO */
            _.Initialize(
                VG139.DCLVG_ACOPLADO_ERRO
            );

            /*" -985- MOVE VG135-IDE-SISTEMA TO VG139-IDE-SISTEMA */
            _.Move(VG135.DCLVG_ACOPLADO.VG135_IDE_SISTEMA, VG139.DCLVG_ACOPLADO_ERRO.VG139_IDE_SISTEMA);

            /*" -986- MOVE VG135-NUM-CERTIFICADO TO VG139-NUM-CERTIFICADO */
            _.Move(VG135.DCLVG_ACOPLADO.VG135_NUM_CERTIFICADO, VG139.DCLVG_ACOPLADO_ERRO.VG139_NUM_CERTIFICADO);

            /*" -987- MOVE VG135-COD-PRODUTO TO VG139-COD-PRODUTO */
            _.Move(VG135.DCLVG_ACOPLADO.VG135_COD_PRODUTO, VG139.DCLVG_ACOPLADO_ERRO.VG139_COD_PRODUTO);

            /*" -989- MOVE VG135-COD-PLANO TO VG139-COD-PLANO */
            _.Move(VG135.DCLVG_ACOPLADO.VG135_COD_PLANO, VG139.DCLVG_ACOPLADO_ERRO.VG139_COD_PLANO);

            /*" -992- PERFORM P0460-CONSULTA-SEQ-ERRO THRU P0460-99-EXIT */

            P0460_CONSULTA_SEQ_ERRO_SECTION();

            P0460_00_START(true);

            P0460_05_INICIO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: P0460_99_EXIT*/


            /*" -993- MOVE 0 TO VG139-COD-SQLCODE */
            _.Move(0, VG139.DCLVG_ACOPLADO_ERRO.VG139_COD_SQLCODE);

            /*" -994- MOVE LK-VG013-COD-RETORNO-API TO VG139-COD-ERRO */
            _.Move(SPVG013W.LK_VG013_COD_RETORNO_API, VG139.DCLVG_ACOPLADO_ERRO.VG139_COD_ERRO);

            /*" -995- MOVE WS-VG139-DES-ERRO TO VG139-DES-ERRO */
            _.Move(WORK.WS_AUXILIARES.WS_VG139_DES_ERRO, VG139.DCLVG_ACOPLADO_ERRO.VG139_DES_ERRO);

            /*" -996- MOVE WS-VG139-DES-ACAO TO VG139-DES-ACAO */
            _.Move(WORK.WS_AUXILIARES.WS_VG139_DES_ACAO, VG139.DCLVG_ACOPLADO_ERRO.VG139_DES_ACAO);

            /*" -997- MOVE LK-VG013-COD-USUARIO TO VG139-COD-USUARIO */
            _.Move(SPVG013W.LK_VG013_COD_USUARIO, VG139.DCLVG_ACOPLADO_ERRO.VG139_COD_USUARIO);

            /*" -998- MOVE WS-PROGRAMA TO VG139-NOM-PROGRAMA */
            _.Move(WORK.WS_PROGRAMA, VG139.DCLVG_ACOPLADO_ERRO.VG139_NOM_PROGRAMA);

            /*" -1000- MOVE WS-CURRENT-TIMESTAMP TO VG139-DTH-CADASTRAMENTO */
            _.Move(WORK.WS_DATAS.WS_CURRENT_TIMESTAMP, VG139.DCLVG_ACOPLADO_ERRO.VG139_DTH_CADASTRAMENTO);

            /*" -1000- . */

        }

        [StopWatch]
        /*" P0400-05-INICIO */
        private void P0400_05_INICIO(bool isPerform = false)
        {
            /*" -1033- PERFORM P0400_05_INICIO_DB_INSERT_1 */

            P0400_05_INICIO_DB_INSERT_1();

            /*" -1036- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1037- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -1038- MOVE VG139-NUM-CERTIFICADO TO WS-BIGINT(01) */
                _.Move(VG139.DCLVG_ACOPLADO_ERRO.VG139_NUM_CERTIFICADO, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -1039- MOVE VG139-COD-PRODUTO TO WS-SMALLINT(01) */
                _.Move(VG139.DCLVG_ACOPLADO_ERRO.VG139_COD_PRODUTO, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -1040- MOVE VG139-COD-PLANO TO WS-SMALLINT(02) */
                _.Move(VG139.DCLVG_ACOPLADO_ERRO.VG139_COD_PLANO, WORK.WS_EDIT.WS_SMALLINT[02]);

                /*" -1046- STRING WS-SECTION ' - ERRO NO INSERT SEGUROS.VG_ACOPLADO_ERRO.' '<CERTIFICADO= ' WS-BIGINT(01) '>' '<PRODUTO= ' WS-SMALLINT(01) '>' '<PLANO= ' WS-SMALLINT(02) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl44 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl44 += " - ERRO NO INSERT SEGUROS.VG_ACOPLADO_ERRO.";
                spl44 += "<CERTIFICADO= ";
                var spl45 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                spl45 += ">";
                spl45 += "<PRODUTO= ";
                var spl46 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl46 += ">";
                spl46 += "<PLANO= ";
                var spl47 = WORK.WS_EDIT.WS_SMALLINT[02].GetMoveValues();
                spl47 += ">";
                var results48 = spl44 + spl45 + spl46 + spl47;
                _.Move(results48, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -1048- MOVE 'SEGUROS.VG_ACOPLADO_ERRO' TO WS-TABELA */
                _.Move("SEGUROS.VG_ACOPLADO_ERRO", WORK.WS_ERRO.WS_TABELA);

                /*" -1049- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -1050- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -1051- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -1052- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1054- END-IF */
            }


            /*" -1054- . */

        }

        [StopWatch]
        /*" P0400-05-INICIO-DB-INSERT-1 */
        public void P0400_05_INICIO_DB_INSERT_1()
        {
            /*" -1033- EXEC SQL INSERT INTO SEGUROS.VG_ACOPLADO_ERRO ( IDE_SISTEMA , NUM_CERTIFICADO , COD_PRODUTO , COD_PLANO , SEQ_ERRO , COD_SQLCODE , COD_ERRO , DES_ERRO , DES_ACAO , COD_USUARIO , NOM_PROGRAMA , DTH_CADASTRAMENTO ) VALUES ( :VG139-IDE-SISTEMA , :VG139-NUM-CERTIFICADO , :VG139-COD-PRODUTO , :VG139-COD-PLANO , :VG139-SEQ-ERRO , :VG139-COD-SQLCODE , :VG139-COD-ERRO , :VG139-DES-ERRO , :VG139-DES-ACAO , :VG139-COD-USUARIO , :VG139-NOM-PROGRAMA , :VG139-DTH-CADASTRAMENTO ) END-EXEC */

            var p0400_05_INICIO_DB_INSERT_1_Insert1 = new P0400_05_INICIO_DB_INSERT_1_Insert1()
            {
                VG139_IDE_SISTEMA = VG139.DCLVG_ACOPLADO_ERRO.VG139_IDE_SISTEMA.ToString(),
                VG139_NUM_CERTIFICADO = VG139.DCLVG_ACOPLADO_ERRO.VG139_NUM_CERTIFICADO.ToString(),
                VG139_COD_PRODUTO = VG139.DCLVG_ACOPLADO_ERRO.VG139_COD_PRODUTO.ToString(),
                VG139_COD_PLANO = VG139.DCLVG_ACOPLADO_ERRO.VG139_COD_PLANO.ToString(),
                VG139_SEQ_ERRO = VG139.DCLVG_ACOPLADO_ERRO.VG139_SEQ_ERRO.ToString(),
                VG139_COD_SQLCODE = VG139.DCLVG_ACOPLADO_ERRO.VG139_COD_SQLCODE.ToString(),
                VG139_COD_ERRO = VG139.DCLVG_ACOPLADO_ERRO.VG139_COD_ERRO.ToString(),
                VG139_DES_ERRO = VG139.DCLVG_ACOPLADO_ERRO.VG139_DES_ERRO.ToString(),
                VG139_DES_ACAO = VG139.DCLVG_ACOPLADO_ERRO.VG139_DES_ACAO.ToString(),
                VG139_COD_USUARIO = VG139.DCLVG_ACOPLADO_ERRO.VG139_COD_USUARIO.ToString(),
                VG139_NOM_PROGRAMA = VG139.DCLVG_ACOPLADO_ERRO.VG139_NOM_PROGRAMA.ToString(),
                VG139_DTH_CADASTRAMENTO = VG139.DCLVG_ACOPLADO_ERRO.VG139_DTH_CADASTRAMENTO.ToString(),
            };

            P0400_05_INICIO_DB_INSERT_1_Insert1.Execute(p0400_05_INICIO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0400_99_EXIT*/

        [StopWatch]
        /*" P0420-PREPARAR-VARCHAR-SECTION */
        private void P0420_PREPARAR_VARCHAR_SECTION()
        {
            /*" -1062- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0420_00_START */

            P0420_00_START();

        }

        [StopWatch]
        /*" P0420-00-START */
        private void P0420_00_START(bool isPerform = false)
        {
            /*" -1065- MOVE 'P0420' TO WS-SECTION */
            _.Move("P0420", WORK.WS_ERRO.WS_SECTION);

            /*" -1066- IF LK-VG013-TRACE EQUAL 'S' */

            if (SPVG013W.LK_VG013_TRACE == "S")
            {

                /*" -1067- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -1069- END-IF */
            }


            /*" -1069- . */

        }

        [StopWatch]
        /*" P0420-05-INICIO */
        private void P0420_05_INICIO(bool isPerform = false)
        {
            /*" -1075- MOVE 255 TO LK-RSGEWSTR-INP-STR-LGTH */
            _.Move(255, RSGEWSTR.LK_RSGEWSTR_INP_STR.LK_RSGEWSTR_INP_STR_LGTH);

            /*" -1077- MOVE LK-VG013-DES-ERRO TO LK-RSGEWSTR-INP-STR-DATA */
            _.Move(SPVG013W.LK_VG013_DES_ERRO, RSGEWSTR.LK_RSGEWSTR_INP_STR.LK_RSGEWSTR_INP_STR_DATA);

            /*" -1079- PERFORM P0852-CONTAR-VARCHAR */

            P0852_CONTAR_VARCHAR_SECTION();

            /*" -1081- MOVE LK-RSGEWSTR-OUT-STR-DATA TO WS-VG139-DES-ERRO-TEXT */
            _.Move(RSGEWSTR.LK_RSGEWSTR_OUT_STR.LK_RSGEWSTR_OUT_STR_DATA, WORK.WS_AUXILIARES.WS_VG139_DES_ERRO.WS_VG139_DES_ERRO_TEXT);

            /*" -1084- MOVE LK-RSGEWSTR-OUT-STR-LGTH TO WS-VG139-DES-ERRO-LEN */
            _.Move(RSGEWSTR.LK_RSGEWSTR_OUT_STR.LK_RSGEWSTR_OUT_STR_LGTH, WORK.WS_AUXILIARES.WS_VG139_DES_ERRO.WS_VG139_DES_ERRO_LEN);

            /*" -1085- MOVE 255 TO LK-RSGEWSTR-INP-STR-LGTH */
            _.Move(255, RSGEWSTR.LK_RSGEWSTR_INP_STR.LK_RSGEWSTR_INP_STR_LGTH);

            /*" -1087- MOVE LK-VG013-DES-ACAO TO LK-RSGEWSTR-INP-STR-DATA */
            _.Move(SPVG013W.LK_VG013_DES_ACAO, RSGEWSTR.LK_RSGEWSTR_INP_STR.LK_RSGEWSTR_INP_STR_DATA);

            /*" -1089- PERFORM P0852-CONTAR-VARCHAR */

            P0852_CONTAR_VARCHAR_SECTION();

            /*" -1091- MOVE LK-RSGEWSTR-OUT-STR-DATA TO WS-VG139-DES-ACAO-TEXT */
            _.Move(RSGEWSTR.LK_RSGEWSTR_OUT_STR.LK_RSGEWSTR_OUT_STR_DATA, WORK.WS_AUXILIARES.WS_VG139_DES_ACAO.WS_VG139_DES_ACAO_TEXT);

            /*" -1094- MOVE LK-RSGEWSTR-OUT-STR-LGTH TO WS-VG139-DES-ACAO-LEN */
            _.Move(RSGEWSTR.LK_RSGEWSTR_OUT_STR.LK_RSGEWSTR_OUT_STR_LGTH, WORK.WS_AUXILIARES.WS_VG139_DES_ACAO.WS_VG139_DES_ACAO_LEN);

            /*" -1094- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0420_99_EXIT*/

        [StopWatch]
        /*" P0460-CONSULTA-SEQ-ERRO-SECTION */
        private void P0460_CONSULTA_SEQ_ERRO_SECTION()
        {
            /*" -1102- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0460_00_START */

            P0460_00_START();

        }

        [StopWatch]
        /*" P0460-00-START */
        private void P0460_00_START(bool isPerform = false)
        {
            /*" -1104- MOVE 'P0460' TO WS-SECTION */
            _.Move("P0460", WORK.WS_ERRO.WS_SECTION);

            /*" -1105- IF LK-VG013-TRACE EQUAL 'S' */

            if (SPVG013W.LK_VG013_TRACE == "S")
            {

                /*" -1106- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -1108- END-IF */
            }


            /*" -1110- INITIALIZE WS-IND-NULL */
            _.Initialize(
                WORK.WS_AUXILIARES.WS_IND_NULL
            );

            /*" -1110- . */

        }

        [StopWatch]
        /*" P0460-05-INICIO */
        private void P0460_05_INICIO(bool isPerform = false)
        {
            /*" -1122- PERFORM P0460_05_INICIO_DB_SELECT_1 */

            P0460_05_INICIO_DB_SELECT_1();

            /*" -1125-  EVALUATE SQLCODE  */

            /*" -1126-  WHEN ZEROS  */

            /*" -1126- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1127- CONTINUE */

                /*" -1128-  WHEN +100  */

                /*" -1128- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -1129- MOVE 1 TO VG139-SEQ-ERRO */
                _.Move(1, VG139.DCLVG_ACOPLADO_ERRO.VG139_SEQ_ERRO);

                /*" -1130-  WHEN OTHER  */

                /*" -1130- ELSE */
            }
            else
            {


                /*" -1131- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -1132- MOVE VG139-NUM-CERTIFICADO TO WS-BIGINT(01) */
                _.Move(VG139.DCLVG_ACOPLADO_ERRO.VG139_NUM_CERTIFICADO, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -1133- MOVE VG139-COD-PRODUTO TO WS-SMALLINT(01) */
                _.Move(VG139.DCLVG_ACOPLADO_ERRO.VG139_COD_PRODUTO, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -1134- MOVE VG139-COD-PLANO TO WS-SMALLINT(02) */
                _.Move(VG139.DCLVG_ACOPLADO_ERRO.VG139_COD_PLANO, WORK.WS_EDIT.WS_SMALLINT[02]);

                /*" -1140- STRING WS-SECTION ' - ERRO AO CONSULTAR VG_ACOPLADO_ERRO.' '<CERTIFICADO= ' WS-BIGINT(01) '>' '<PRODUTO= ' WS-SMALLINT(01) '>' '<PLANO= ' WS-SMALLINT(02) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl48 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl48 += " - ERRO AO CONSULTAR VG_ACOPLADO_ERRO.";
                spl48 += "<CERTIFICADO= ";
                var spl49 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                spl49 += ">";
                spl49 += "<PRODUTO= ";
                var spl50 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl50 += ">";
                spl50 += "<PLANO= ";
                var spl51 = WORK.WS_EDIT.WS_SMALLINT[02].GetMoveValues();
                spl51 += ">";
                var results52 = spl48 + spl49 + spl50 + spl51;
                _.Move(results52, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -1142- MOVE 'SEGUROS.VG_ACOPLADO_ERRO' TO WS-TABELA */
                _.Move("SEGUROS.VG_ACOPLADO_ERRO", WORK.WS_ERRO.WS_TABELA);

                /*" -1143- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -1144- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -1145- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -1146- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1148-  END-EVALUATE  */

                /*" -1148- END-IF */
            }


            /*" -1149- IF WS-IND-NULL LESS ZEROS */

            if (WORK.WS_AUXILIARES.WS_IND_NULL < 00)
            {

                /*" -1150- MOVE 1 TO VG139-SEQ-ERRO */
                _.Move(1, VG139.DCLVG_ACOPLADO_ERRO.VG139_SEQ_ERRO);

                /*" -1152- END-IF */
            }


            /*" -1152- . */

        }

        [StopWatch]
        /*" P0460-05-INICIO-DB-SELECT-1 */
        public void P0460_05_INICIO_DB_SELECT_1()
        {
            /*" -1122- EXEC SQL SELECT MAX(SEQ_ERRO) + 1 INTO :VG139-SEQ-ERRO:WS-IND-NULL FROM SEGUROS.VG_ACOPLADO_ERRO WHERE IDE_SISTEMA = :VG139-IDE-SISTEMA AND NUM_CERTIFICADO = :VG139-NUM-CERTIFICADO AND COD_PRODUTO = :VG139-COD-PRODUTO AND COD_PLANO = :VG139-COD-PLANO END-EXEC */

            var p0460_05_INICIO_DB_SELECT_1_Query1 = new P0460_05_INICIO_DB_SELECT_1_Query1()
            {
                VG139_NUM_CERTIFICADO = VG139.DCLVG_ACOPLADO_ERRO.VG139_NUM_CERTIFICADO.ToString(),
                VG139_IDE_SISTEMA = VG139.DCLVG_ACOPLADO_ERRO.VG139_IDE_SISTEMA.ToString(),
                VG139_COD_PRODUTO = VG139.DCLVG_ACOPLADO_ERRO.VG139_COD_PRODUTO.ToString(),
                VG139_COD_PLANO = VG139.DCLVG_ACOPLADO_ERRO.VG139_COD_PLANO.ToString(),
            };

            var executed_1 = P0460_05_INICIO_DB_SELECT_1_Query1.Execute(p0460_05_INICIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VG139_SEQ_ERRO, VG139.DCLVG_ACOPLADO_ERRO.VG139_SEQ_ERRO);
                _.Move(executed_1.WS_IND_NULL, WORK.WS_AUXILIARES.WS_IND_NULL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0460_99_EXIT*/

        [StopWatch]
        /*" P0540-CONTAR-TITULOS-ATV-SECTION */
        private void P0540_CONTAR_TITULOS_ATV_SECTION()
        {
            /*" -1160- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0540_00_START */

            P0540_00_START();

        }

        [StopWatch]
        /*" P0540-00-START */
        private void P0540_00_START(bool isPerform = false)
        {
            /*" -1162- MOVE 'P0540' TO WS-SECTION */
            _.Move("P0540", WORK.WS_ERRO.WS_SECTION);

            /*" -1163- IF LK-VG013-TRACE EQUAL 'S' */

            if (SPVG013W.LK_VG013_TRACE == "S")
            {

                /*" -1164- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -1166- END-IF */
            }


            /*" -1168- INITIALIZE DCLVG-ACOPLADO-TITULO */
            _.Initialize(
                VG136.DCLVG_ACOPLADO_TITULO
            );

            /*" -1169- MOVE VG135-IDE-SISTEMA TO VG136-IDE-SISTEMA */
            _.Move(VG135.DCLVG_ACOPLADO.VG135_IDE_SISTEMA, VG136.DCLVG_ACOPLADO_TITULO.VG136_IDE_SISTEMA);

            /*" -1170- MOVE VG135-NUM-CERTIFICADO TO VG136-NUM-CERTIFICADO */
            _.Move(VG135.DCLVG_ACOPLADO.VG135_NUM_CERTIFICADO, VG136.DCLVG_ACOPLADO_TITULO.VG136_NUM_CERTIFICADO);

            /*" -1171- MOVE VG135-COD-PRODUTO TO VG136-COD-PRODUTO */
            _.Move(VG135.DCLVG_ACOPLADO.VG135_COD_PRODUTO, VG136.DCLVG_ACOPLADO_TITULO.VG136_COD_PRODUTO);

            /*" -1172- MOVE VG135-COD-PLANO TO VG136-COD-PLANO */
            _.Move(VG135.DCLVG_ACOPLADO.VG135_COD_PLANO, VG136.DCLVG_ACOPLADO_TITULO.VG136_COD_PLANO);

            /*" -1174- MOVE 'ATV' TO VG136-STA-TITULO */
            _.Move("ATV", VG136.DCLVG_ACOPLADO_TITULO.VG136_STA_TITULO);

            /*" -1174- . */

        }

        [StopWatch]
        /*" P0540-05-INICIO */
        private void P0540_05_INICIO(bool isPerform = false)
        {
            /*" -1187- PERFORM P0540_05_INICIO_DB_SELECT_1 */

            P0540_05_INICIO_DB_SELECT_1();

            /*" -1190-  EVALUATE SQLCODE  */

            /*" -1191-  WHEN ZEROS  */

            /*" -1191- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1192- CONTINUE */

                /*" -1193-  WHEN OTHER  */

                /*" -1193- ELSE */
            }
            else
            {


                /*" -1194- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -1195- MOVE VG139-NUM-CERTIFICADO TO WS-BIGINT(01) */
                _.Move(VG139.DCLVG_ACOPLADO_ERRO.VG139_NUM_CERTIFICADO, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -1196- MOVE VG139-COD-PRODUTO TO WS-SMALLINT(01) */
                _.Move(VG139.DCLVG_ACOPLADO_ERRO.VG139_COD_PRODUTO, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -1197- MOVE VG139-COD-PLANO TO WS-SMALLINT(02) */
                _.Move(VG139.DCLVG_ACOPLADO_ERRO.VG139_COD_PLANO, WORK.WS_EDIT.WS_SMALLINT[02]);

                /*" -1203- STRING WS-SECTION ' - ERRO AO CONSULTAR VG_ACOPLADO_TITULO.' '<CERTIFICADO= ' WS-BIGINT(01) '>' '<PRODUTO= ' WS-SMALLINT(01) '>' '<PLANO= ' WS-SMALLINT(02) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl52 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl52 += " - ERRO AO CONSULTAR VG_ACOPLADO_TITULO.";
                spl52 += "<CERTIFICADO= ";
                var spl53 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                spl53 += ">";
                spl53 += "<PRODUTO= ";
                var spl54 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl54 += ">";
                spl54 += "<PLANO= ";
                var spl55 = WORK.WS_EDIT.WS_SMALLINT[02].GetMoveValues();
                spl55 += ">";
                var results56 = spl52 + spl53 + spl54 + spl55;
                _.Move(results56, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -1205- MOVE 'SEGUROS.VG_ACOPLADO_ERRO' TO WS-TABELA */
                _.Move("SEGUROS.VG_ACOPLADO_ERRO", WORK.WS_ERRO.WS_TABELA);

                /*" -1206- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -1207- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -1208- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -1209- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1211-  END-EVALUATE  */

                /*" -1211- END-IF */
            }


            /*" -1211- . */

        }

        [StopWatch]
        /*" P0540-05-INICIO-DB-SELECT-1 */
        public void P0540_05_INICIO_DB_SELECT_1()
        {
            /*" -1187- EXEC SQL SELECT VALUE(COUNT(1),0) INTO :WS-COUNT FROM SEGUROS.VG_ACOPLADO_TITULO WHERE IDE_SISTEMA = :VG136-IDE-SISTEMA AND NUM_CERTIFICADO = :VG136-NUM-CERTIFICADO AND COD_PRODUTO = :VG136-COD-PRODUTO AND COD_PLANO = :VG136-COD-PLANO AND STA_TITULO = :VG136-STA-TITULO END-EXEC */

            var p0540_05_INICIO_DB_SELECT_1_Query1 = new P0540_05_INICIO_DB_SELECT_1_Query1()
            {
                VG136_NUM_CERTIFICADO = VG136.DCLVG_ACOPLADO_TITULO.VG136_NUM_CERTIFICADO.ToString(),
                VG136_IDE_SISTEMA = VG136.DCLVG_ACOPLADO_TITULO.VG136_IDE_SISTEMA.ToString(),
                VG136_COD_PRODUTO = VG136.DCLVG_ACOPLADO_TITULO.VG136_COD_PRODUTO.ToString(),
                VG136_STA_TITULO = VG136.DCLVG_ACOPLADO_TITULO.VG136_STA_TITULO.ToString(),
                VG136_COD_PLANO = VG136.DCLVG_ACOPLADO_TITULO.VG136_COD_PLANO.ToString(),
            };

            var executed_1 = P0540_05_INICIO_DB_SELECT_1_Query1.Execute(p0540_05_INICIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_COUNT, WORK.WS_AUXILIARES.WS_COUNT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0540_99_EXIT*/

        [StopWatch]
        /*" P0851-BUSCAR-TIMESTAMP-SECTION */
        private void P0851_BUSCAR_TIMESTAMP_SECTION()
        {
            /*" -1221- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0851_00_START */

            P0851_00_START();

        }

        [StopWatch]
        /*" P0851-00-START */
        private void P0851_00_START(bool isPerform = false)
        {
            /*" -1223- MOVE 'P0851' TO WS-SECTION */
            _.Move("P0851", WORK.WS_ERRO.WS_SECTION);

            /*" -1224- IF LK-VG013-TRACE EQUAL 'S' */

            if (SPVG013W.LK_VG013_TRACE == "S")
            {

                /*" -1225- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -1227- END-IF */
            }


            /*" -1227- . */

        }

        [StopWatch]
        /*" P0851-01-INICIO */
        private void P0851_01_INICIO(bool isPerform = false)
        {
            /*" -1235- PERFORM P0851_01_INICIO_DB_SELECT_1 */

            P0851_01_INICIO_DB_SELECT_1();

            /*" -1238- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1239- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -1242- STRING WS-SECTION ' - ERRO NO SELECT SYSIBM.SYSDUMMY1.' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl56 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl56 += " - ERRO NO SELECT SYSIBM.SYSDUMMY1.";
                _.Move(spl56, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -1243- MOVE 'SYSIBM.SYSDUMMY1' TO WS-TABELA */
                _.Move("SYSIBM.SYSDUMMY1", WORK.WS_ERRO.WS_TABELA);

                /*" -1244- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -1245- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -1246- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -1247- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1249- END-IF */
            }


            /*" -1249- . */

        }

        [StopWatch]
        /*" P0851-01-INICIO-DB-SELECT-1 */
        public void P0851_01_INICIO_DB_SELECT_1()
        {
            /*" -1235- EXEC SQL SELECT CHAR(CURRENT TIMESTAMP) INTO :WS-CURRENT-TIMESTAMP FROM SYSIBM.SYSDUMMY1 END-EXEC */

            var p0851_01_INICIO_DB_SELECT_1_Query1 = new P0851_01_INICIO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = P0851_01_INICIO_DB_SELECT_1_Query1.Execute(p0851_01_INICIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_CURRENT_TIMESTAMP, WORK.WS_DATAS.WS_CURRENT_TIMESTAMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0851_99_EXIT*/

        [StopWatch]
        /*" P0852-CONTAR-VARCHAR-SECTION */
        private void P0852_CONTAR_VARCHAR_SECTION()
        {
            /*" -1259- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0852_00_START */

            P0852_00_START();

        }

        [StopWatch]
        /*" P0852-00-START */
        private void P0852_00_START(bool isPerform = false)
        {
            /*" -1261- MOVE 'P0852' TO WS-SECTION */
            _.Move("P0852", WORK.WS_ERRO.WS_SECTION);

            /*" -1262- IF LK-VG013-TRACE EQUAL 'S' */

            if (SPVG013W.LK_VG013_TRACE == "S")
            {

                /*" -1263- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -1265- END-IF */
            }


            /*" -1265- . */

        }

        [StopWatch]
        /*" P0852-01-INICIO */
        private void P0852_01_INICIO(bool isPerform = false)
        {
            /*" -1271- MOVE 7 TO LK-RSGEWSTR-FUNCAO */
            _.Move(7, RSGEWSTR.LK_RSGEWSTR_FUNCAO);

            /*" -1273- MOVE 'RSGESSTR' TO WS-PROGRAMA-CHAMADO */
            _.Move("RSGESSTR", WORK.WS_PROGRAMA_CHAMADO);

            /*" -1280- CALL WS-PROGRAMA-CHAMADO USING LK-RSGEWSTR-FUNCAO LK-RSGEWSTR-INP-STR LK-RSGEWSTR-INP-NUM LK-RSGEWSTR-IND-ERRO LK-RSGEWSTR-OUT-STR LK-RSGEWSTR-OUT-NUM. */
            _.Call(WORK.WS_PROGRAMA_CHAMADO, RSGEWSTR);

            /*" -1281- IF LK-RSGEWSTR-IND-ERRO NOT EQUAL ZEROS */

            if (RSGEWSTR.LK_RSGEWSTR_IND_ERRO != 00)
            {

                /*" -1282- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -1283- MOVE VG135-NUM-CERTIFICADO TO WS-BIGINT(01) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_NUM_CERTIFICADO, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -1288- STRING WS-SECTION ' - FALHA AO CONTAR BYTES DO VARCHAR.' '<CERTIFICADO= ' WS-BIGINT(01) '>' '<VARCHAR= ' LK-RSGEWSTR-INP-STR-DATA '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl57 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl57 += " - FALHA AO CONTAR BYTES DO VARCHAR.";
                spl57 += "<CERTIFICADO= ";
                var spl58 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                spl58 += ">";
                spl58 += "<VARCHAR= ";
                var spl59 = RSGEWSTR.LK_RSGEWSTR_INP_STR.LK_RSGEWSTR_INP_STR_DATA.GetMoveValues();
                spl59 += ">";
                var results60 = spl57 + spl58 + spl59;
                _.Move(results60, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -1291- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -1292- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -1293- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1295- END-IF */
            }


            /*" -1295- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0852_99_EXIT*/

        [StopWatch]
        /*" P1000-TRATAR-TIPO-ACAO-01-SECTION */
        private void P1000_TRATAR_TIPO_ACAO_01_SECTION()
        {
            /*" -1303- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P1000_00_START */

            P1000_00_START();

        }

        [StopWatch]
        /*" P1000-00-START */
        private void P1000_00_START(bool isPerform = false)
        {
            /*" -1305- MOVE 'P1000' TO WS-SECTION */
            _.Move("P1000", WORK.WS_ERRO.WS_SECTION);

            /*" -1306- IF LK-VG013-TRACE EQUAL 'S' */

            if (SPVG013W.LK_VG013_TRACE == "S")
            {

                /*" -1307- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -1307- END-IF. */
            }


        }

        [StopWatch]
        /*" P1000-05-INICIO */
        private void P1000_05_INICIO(bool isPerform = false)
        {
            /*" -1314- PERFORM P0250-CONSULTA-VG135 */

            P0250_CONSULTA_VG135_SECTION();

            /*" -1315- IF WS-SEM-ACOPLADO */

            if (WORK.WS_ACOPLADO["WS_SEM_ACOPLADO"])
            {

                /*" -1317- PERFORM P0851-BUSCAR-TIMESTAMP THRU P0851-99-EXIT */

                P0851_BUSCAR_TIMESTAMP_SECTION();

                P0851_00_START(true);

                P0851_01_INICIO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P0851_99_EXIT*/


                /*" -1319- PERFORM P0200-INSERIR-VG0135 THRU P0200-99-EXIT */

                P0200_INSERIR_VG0135_SECTION();

                P0200_00_START(true);

                P0200_05_INICIO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P0200_99_EXIT*/


                /*" -1321- PERFORM P0300-INSERIR-VG0137 THRU P0300-99-EXIT */

                P0300_INSERIR_VG0137_SECTION();

                P0300_00_START(true);

                P0300_05_INICIO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P0300_99_EXIT*/


                /*" -1322- ELSE */
            }
            else
            {


                /*" -1323- MOVE 'P1000' TO WS-SECTION */
                _.Move("P1000", WORK.WS_ERRO.WS_SECTION);

                /*" -1324- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -1325- MOVE VG135-NUM-CERTIFICADO TO WS-BIGINT(01) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_NUM_CERTIFICADO, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -1326- MOVE VG135-COD-PRODUTO TO WS-SMALLINT(01) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_COD_PRODUTO, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -1327- MOVE VG135-COD-PLANO TO WS-SMALLINT(02) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_COD_PLANO, WORK.WS_EDIT.WS_SMALLINT[02]);

                /*" -1333- STRING WS-SECTION ' - CERTIFICADO JA POSSUI COMPRA.' '<CERTIFICADO= ' WS-BIGINT(01) '>' '<PRODUTO= ' WS-SMALLINT(01) '>' '<PLANO= ' WS-SMALLINT(02) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl60 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl60 += " - CERTIFICADO JA POSSUI COMPRA.";
                spl60 += "<CERTIFICADO= ";
                var spl61 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                spl61 += ">";
                spl61 += "<PRODUTO= ";
                var spl62 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl62 += ">";
                spl62 += "<PLANO= ";
                var spl63 = WORK.WS_EDIT.WS_SMALLINT[02].GetMoveValues();
                spl63 += ">";
                var results64 = spl60 + spl61 + spl62 + spl63;
                _.Move(results64, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -1334- MOVE 'SEGUROS.VG_ACOPLADO' TO WS-TABELA */
                _.Move("SEGUROS.VG_ACOPLADO", WORK.WS_ERRO.WS_TABELA);

                /*" -1335- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -1336- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -1337- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -1338- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1340- END-IF */
            }


            /*" -1340- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P1000_99_EXIT*/

        [StopWatch]
        /*" P2000-TRATAR-TIPO-ACAO-02-SECTION */
        private void P2000_TRATAR_TIPO_ACAO_02_SECTION()
        {
            /*" -1348- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P2000_00_START */

            P2000_00_START();

        }

        [StopWatch]
        /*" P2000-00-START */
        private void P2000_00_START(bool isPerform = false)
        {
            /*" -1350- MOVE 'P2000' TO WS-SECTION */
            _.Move("P2000", WORK.WS_ERRO.WS_SECTION);

            /*" -1351- IF LK-VG013-TRACE EQUAL 'S' */

            if (SPVG013W.LK_VG013_TRACE == "S")
            {

                /*" -1352- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -1352- END-IF. */
            }


        }

        [StopWatch]
        /*" P2000-05-INICIO */
        private void P2000_05_INICIO(bool isPerform = false)
        {
            /*" -1362- PERFORM P0250-CONSULTA-VG135 */

            P0250_CONSULTA_VG135_SECTION();

            /*" -1363- IF VG135-STA-ACOPLADO EQUAL 7 */

            if (VG135.DCLVG_ACOPLADO.VG135_STA_ACOPLADO == 7)
            {

                /*" -1364- CONTINUE */

                /*" -1365- ELSE */
            }
            else
            {


                /*" -1366- MOVE 'P2000' TO WS-SECTION */
                _.Move("P2000", WORK.WS_ERRO.WS_SECTION);

                /*" -1367- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -1368- MOVE VG135-NUM-CERTIFICADO TO WS-BIGINT(01) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_NUM_CERTIFICADO, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -1369- MOVE VG135-STA-ACOPLADO TO WS-SMALLINT(01) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_STA_ACOPLADO, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -1370- MOVE VG135-COD-PRODUTO TO WS-SMALLINT(02) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_COD_PRODUTO, WORK.WS_EDIT.WS_SMALLINT[02]);

                /*" -1371- MOVE VG135-COD-PLANO TO WS-SMALLINT(03) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_COD_PLANO, WORK.WS_EDIT.WS_SMALLINT[03]);

                /*" -1378- STRING WS-SECTION ' - SEGURO NAO ESTA LIBERADO PARA RENOVAR.' '<CERT= ' WS-BIGINT(01) '>' '<STAT= ' WS-SMALLINT(01) '>' '<PROD= ' WS-SMALLINT(02) '>' '<PLAN= ' WS-SMALLINT(03) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl64 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl64 += " - SEGURO NAO ESTA LIBERADO PARA RENOVAR.";
                spl64 += "<CERT= ";
                var spl65 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                spl65 += ">";
                spl65 += "<STAT= ";
                var spl66 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl66 += ">";
                spl66 += "<PROD= ";
                var spl67 = WORK.WS_EDIT.WS_SMALLINT[02].GetMoveValues();
                spl67 += ">";
                spl67 += "<PLAN= ";
                var spl68 = WORK.WS_EDIT.WS_SMALLINT[03].GetMoveValues();
                spl68 += ">";
                var results69 = spl64 + spl65 + spl66 + spl67 + spl68;
                _.Move(results69, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -1379- MOVE 'SEGUROS.VG_ACOPLADO' TO WS-TABELA */
                _.Move("SEGUROS.VG_ACOPLADO", WORK.WS_ERRO.WS_TABELA);

                /*" -1380- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -1381- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -1382- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -1383- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1387- END-IF */
            }


            /*" -1388- IF WS-TEM-ACOPLADO */

            if (WORK.WS_ACOPLADO["WS_TEM_ACOPLADO"])
            {

                /*" -1392- MOVE 3 TO VG135-STA-ACOPLADO */
                _.Move(3, VG135.DCLVG_ACOPLADO.VG135_STA_ACOPLADO);

                /*" -1394- PERFORM P0851-BUSCAR-TIMESTAMP THRU P0851-99-EXIT */

                P0851_BUSCAR_TIMESTAMP_SECTION();

                P0851_00_START(true);

                P0851_01_INICIO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P0851_99_EXIT*/


                /*" -1395- MOVE LK-VG013-VLR-TITULO TO VG135-VLR-TITULO */
                _.Move(SPVG013W.LK_VG013_VLR_TITULO, VG135.DCLVG_ACOPLADO.VG135_VLR_TITULO);

                /*" -1397- PERFORM P0210-ATUALIZAR-VG0135 THRU P0210-99-EXIT */

                P0210_ATUALIZAR_VG0135_SECTION();

                P0210_00_START(true);

                P0210_05_INICIO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P0210_99_EXIT*/


                /*" -1399- PERFORM P0300-INSERIR-VG0137 THRU P0300-99-EXIT */

                P0300_INSERIR_VG0137_SECTION();

                P0300_00_START(true);

                P0300_05_INICIO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P0300_99_EXIT*/


                /*" -1400- ELSE */
            }
            else
            {


                /*" -1401- MOVE 'P2000' TO WS-SECTION */
                _.Move("P2000", WORK.WS_ERRO.WS_SECTION);

                /*" -1402- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -1403- MOVE VG135-NUM-CERTIFICADO TO WS-BIGINT(01) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_NUM_CERTIFICADO, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -1404- MOVE VG135-COD-PRODUTO TO WS-SMALLINT(01) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_COD_PRODUTO, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -1405- MOVE VG135-COD-PLANO TO WS-SMALLINT(02) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_COD_PLANO, WORK.WS_EDIT.WS_SMALLINT[02]);

                /*" -1411- STRING WS-SECTION ' - NAO ESTA CADASTRADO NA BASE DE CONTROLE.' '<CERT= ' WS-BIGINT(01) '>' '<PROD= ' WS-SMALLINT(01) '>' '<PLAN= ' WS-SMALLINT(02) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl69 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl69 += " - NAO ESTA CADASTRADO NA BASE DE CONTROLE.";
                spl69 += "<CERT= ";
                var spl70 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                spl70 += ">";
                spl70 += "<PROD= ";
                var spl71 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl71 += ">";
                spl71 += "<PLAN= ";
                var spl72 = WORK.WS_EDIT.WS_SMALLINT[02].GetMoveValues();
                spl72 += ">";
                var results73 = spl69 + spl70 + spl71 + spl72;
                _.Move(results73, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -1412- MOVE 'SEGUROS.VG_ACOPLADO' TO WS-TABELA */
                _.Move("SEGUROS.VG_ACOPLADO", WORK.WS_ERRO.WS_TABELA);

                /*" -1413- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -1414- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -1415- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -1416- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1418- END-IF */
            }


            /*" -1418- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P2000_99_EXIT*/

        [StopWatch]
        /*" P3000-TRATAR-TIPO-ACAO-03-SECTION */
        private void P3000_TRATAR_TIPO_ACAO_03_SECTION()
        {
            /*" -1426- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P3000_00_START */

            P3000_00_START();

        }

        [StopWatch]
        /*" P3000-00-START */
        private void P3000_00_START(bool isPerform = false)
        {
            /*" -1428- MOVE 'P3000' TO WS-SECTION */
            _.Move("P3000", WORK.WS_ERRO.WS_SECTION);

            /*" -1429- IF LK-VG013-TRACE EQUAL 'S' */

            if (SPVG013W.LK_VG013_TRACE == "S")
            {

                /*" -1430- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -1430- END-IF. */
            }


        }

        [StopWatch]
        /*" P3000-05-INICIO */
        private void P3000_05_INICIO(bool isPerform = false)
        {
            /*" -1438- PERFORM P0250-CONSULTA-VG135 THRU P0250-99-EXIT */

            P0250_CONSULTA_VG135_SECTION();

            P0250_00_START(true);

            P0250_05_INICIO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: P0250_99_EXIT*/


            /*" -1439- IF WS-SEM-ACOPLADO */

            if (WORK.WS_ACOPLADO["WS_SEM_ACOPLADO"])
            {

                /*" -1440- MOVE 'P3000' TO WS-SECTION */
                _.Move("P3000", WORK.WS_ERRO.WS_SECTION);

                /*" -1441- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -1442- MOVE VG135-NUM-CERTIFICADO TO WS-BIGINT(01) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_NUM_CERTIFICADO, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -1443- MOVE VG135-COD-PRODUTO TO WS-SMALLINT(01) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_COD_PRODUTO, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -1444- MOVE VG135-COD-PLANO TO WS-SMALLINT(02) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_COD_PLANO, WORK.WS_EDIT.WS_SMALLINT[02]);

                /*" -1450- STRING WS-SECTION ' - NAO ESTA CADASTRADO NA BASE DE CONTROLE.' '<CERT= ' WS-BIGINT(01) '>' '<PROD= ' WS-SMALLINT(01) '>' '<PLAN= ' WS-SMALLINT(02) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl73 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl73 += " - NAO ESTA CADASTRADO NA BASE DE CONTROLE.";
                spl73 += "<CERT= ";
                var spl74 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                spl74 += ">";
                spl74 += "<PROD= ";
                var spl75 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl75 += ">";
                spl75 += "<PLAN= ";
                var spl76 = WORK.WS_EDIT.WS_SMALLINT[02].GetMoveValues();
                spl76 += ">";
                var results77 = spl73 + spl74 + spl75 + spl76;
                _.Move(results77, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -1451- MOVE 'SEGUROS.VG_ACOPLADO' TO WS-TABELA */
                _.Move("SEGUROS.VG_ACOPLADO", WORK.WS_ERRO.WS_TABELA);

                /*" -1452- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -1453- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -1454- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -1455- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1457- END-IF */
            }


            /*" -1458- IF VG135-STA-ACOPLADO EQUAL 0 */

            if (VG135.DCLVG_ACOPLADO.VG135_STA_ACOPLADO == 0)
            {

                /*" -1459- CONTINUE */

                /*" -1460- ELSE */
            }
            else
            {


                /*" -1461- MOVE 'P3000' TO WS-SECTION */
                _.Move("P3000", WORK.WS_ERRO.WS_SECTION);

                /*" -1462- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -1463- MOVE VG135-NUM-CERTIFICADO TO WS-BIGINT(01) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_NUM_CERTIFICADO, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -1464- MOVE VG135-STA-ACOPLADO TO WS-SMALLINT(01) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_STA_ACOPLADO, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -1465- MOVE VG135-COD-PRODUTO TO WS-SMALLINT(02) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_COD_PRODUTO, WORK.WS_EDIT.WS_SMALLINT[02]);

                /*" -1466- MOVE VG135-COD-PLANO TO WS-SMALLINT(03) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_COD_PLANO, WORK.WS_EDIT.WS_SMALLINT[03]);

                /*" -1473- STRING WS-SECTION ' - STA-ACOPLADO NAO PERMITE ATUALIZAR.' '<CERT= ' WS-BIGINT(01) '>' '<STAT= ' WS-SMALLINT(01) '>' '<PROD= ' WS-SMALLINT(02) '>' '<PLAN= ' WS-SMALLINT(03) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl77 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl77 += " - STA-ACOPLADO NAO PERMITE ATUALIZAR.";
                spl77 += "<CERT= ";
                var spl78 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                spl78 += ">";
                spl78 += "<STAT= ";
                var spl79 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl79 += ">";
                spl79 += "<PROD= ";
                var spl80 = WORK.WS_EDIT.WS_SMALLINT[02].GetMoveValues();
                spl80 += ">";
                spl80 += "<PLAN= ";
                var spl81 = WORK.WS_EDIT.WS_SMALLINT[03].GetMoveValues();
                spl81 += ">";
                var results82 = spl77 + spl78 + spl79 + spl80 + spl81;
                _.Move(results82, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -1474- MOVE 'SEGUROS.VG_ACOPLADO' TO WS-TABELA */
                _.Move("SEGUROS.VG_ACOPLADO", WORK.WS_ERRO.WS_TABELA);

                /*" -1475- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -1476- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -1477- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -1478- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1480- END-IF */
            }


            /*" -1483- PERFORM P0851-BUSCAR-TIMESTAMP THRU P0851-99-EXIT */

            P0851_BUSCAR_TIMESTAMP_SECTION();

            P0851_00_START(true);

            P0851_01_INICIO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: P0851_99_EXIT*/


            /*" -1486- PERFORM P0420-PREPARAR-VARCHAR THRU P0420-99-EXIT */

            P0420_PREPARAR_VARCHAR_SECTION();

            P0420_00_START(true);

            P0420_05_INICIO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: P0420_99_EXIT*/


            /*" -1487- IF LK-VG013-COD-RETORNO-API EQUAL 200 */

            if (SPVG013W.LK_VG013_COD_RETORNO_API == 200)
            {

                /*" -1488- MOVE 1 TO VG135-STA-ACOPLADO */
                _.Move(1, VG135.DCLVG_ACOPLADO.VG135_STA_ACOPLADO);

                /*" -1490- PERFORM P0210-ATUALIZAR-VG0135 THRU P0210-99-EXIT */

                P0210_ATUALIZAR_VG0135_SECTION();

                P0210_00_START(true);

                P0210_05_INICIO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P0210_99_EXIT*/


                /*" -1492- PERFORM P0300-INSERIR-VG0137 THRU P0300-99-EXIT */

                P0300_INSERIR_VG0137_SECTION();

                P0300_00_START(true);

                P0300_05_INICIO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P0300_99_EXIT*/


                /*" -1493- ELSE */
            }
            else
            {


                /*" -1494- MOVE 4 TO VG135-STA-ACOPLADO */
                _.Move(4, VG135.DCLVG_ACOPLADO.VG135_STA_ACOPLADO);

                /*" -1496- PERFORM P0210-ATUALIZAR-VG0135 THRU P0210-99-EXIT */

                P0210_ATUALIZAR_VG0135_SECTION();

                P0210_00_START(true);

                P0210_05_INICIO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P0210_99_EXIT*/


                /*" -1498- PERFORM P0300-INSERIR-VG0137 THRU P0300-99-EXIT */

                P0300_INSERIR_VG0137_SECTION();

                P0300_00_START(true);

                P0300_05_INICIO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P0300_99_EXIT*/


                /*" -1500- PERFORM P0400-INSERIR-VG0139 THRU P0400-99-EXIT */

                P0400_INSERIR_VG0139_SECTION();

                P0400_00_START(true);

                P0400_05_INICIO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P0400_99_EXIT*/


                /*" -1502- END-IF */
            }


            /*" -1502- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P3000_99_EXIT*/

        [StopWatch]
        /*" P4000-TRATAR-TIPO-ACAO-04-SECTION */
        private void P4000_TRATAR_TIPO_ACAO_04_SECTION()
        {
            /*" -1510- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P4000_00_START */

            P4000_00_START();

        }

        [StopWatch]
        /*" P4000-00-START */
        private void P4000_00_START(bool isPerform = false)
        {
            /*" -1512- MOVE 'P4000' TO WS-SECTION */
            _.Move("P4000", WORK.WS_ERRO.WS_SECTION);

            /*" -1513- IF LK-VG013-TRACE EQUAL 'S' */

            if (SPVG013W.LK_VG013_TRACE == "S")
            {

                /*" -1514- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -1514- END-IF. */
            }


        }

        [StopWatch]
        /*" P4000-05-INICIO */
        private void P4000_05_INICIO(bool isPerform = false)
        {
            /*" -1522- PERFORM P0250-CONSULTA-VG135 THRU P0250-99-EXIT */

            P0250_CONSULTA_VG135_SECTION();

            P0250_00_START(true);

            P0250_05_INICIO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: P0250_99_EXIT*/


            /*" -1523- IF WS-SEM-ACOPLADO */

            if (WORK.WS_ACOPLADO["WS_SEM_ACOPLADO"])
            {

                /*" -1524- MOVE 'P4000' TO WS-SECTION */
                _.Move("P4000", WORK.WS_ERRO.WS_SECTION);

                /*" -1525- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -1526- MOVE VG135-NUM-CERTIFICADO TO WS-BIGINT(01) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_NUM_CERTIFICADO, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -1527- MOVE VG135-COD-PRODUTO TO WS-SMALLINT(01) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_COD_PRODUTO, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -1528- MOVE VG135-COD-PLANO TO WS-SMALLINT(02) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_COD_PLANO, WORK.WS_EDIT.WS_SMALLINT[02]);

                /*" -1534- STRING WS-SECTION ' - NAO ESTA CADASTRADO NA BASE DE CONTROLE.' '<CERT= ' WS-BIGINT(01) '>' '<PROD= ' WS-SMALLINT(01) '>' '<PLAN= ' WS-SMALLINT(02) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl82 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl82 += " - NAO ESTA CADASTRADO NA BASE DE CONTROLE.";
                spl82 += "<CERT= ";
                var spl83 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                spl83 += ">";
                spl83 += "<PROD= ";
                var spl84 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl84 += ">";
                spl84 += "<PLAN= ";
                var spl85 = WORK.WS_EDIT.WS_SMALLINT[02].GetMoveValues();
                spl85 += ">";
                var results86 = spl82 + spl83 + spl84 + spl85;
                _.Move(results86, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -1535- MOVE 'SEGUROS.VG_ACOPLADO' TO WS-TABELA */
                _.Move("SEGUROS.VG_ACOPLADO", WORK.WS_ERRO.WS_TABELA);

                /*" -1536- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -1537- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -1538- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -1539- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1541- END-IF */
            }


            /*" -1542- IF VG135-STA-ACOPLADO EQUAL 0 OR 1 OR 3 */

            if (VG135.DCLVG_ACOPLADO.VG135_STA_ACOPLADO.In("0", "1", "3"))
            {

                /*" -1543- CONTINUE */

                /*" -1544- ELSE */
            }
            else
            {


                /*" -1545- MOVE 'P4000' TO WS-SECTION */
                _.Move("P4000", WORK.WS_ERRO.WS_SECTION);

                /*" -1546- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -1547- MOVE VG135-NUM-CERTIFICADO TO WS-BIGINT(01) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_NUM_CERTIFICADO, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -1548- MOVE VG135-STA-ACOPLADO TO WS-SMALLINT(01) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_STA_ACOPLADO, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -1549- MOVE VG135-COD-PRODUTO TO WS-SMALLINT(02) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_COD_PRODUTO, WORK.WS_EDIT.WS_SMALLINT[02]);

                /*" -1550- MOVE VG135-COD-PLANO TO WS-SMALLINT(03) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_COD_PLANO, WORK.WS_EDIT.WS_SMALLINT[03]);

                /*" -1557- STRING WS-SECTION ' - STA-ACOPLADO NAO PERMITE ATUALIZAR.' '<CERT= ' WS-BIGINT(01) '>' '<STAT= ' WS-SMALLINT(01) '>' '<PROD= ' WS-SMALLINT(02) '>' '<PLAN= ' WS-SMALLINT(03) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl86 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl86 += " - STA-ACOPLADO NAO PERMITE ATUALIZAR.";
                spl86 += "<CERT= ";
                var spl87 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                spl87 += ">";
                spl87 += "<STAT= ";
                var spl88 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl88 += ">";
                spl88 += "<PROD= ";
                var spl89 = WORK.WS_EDIT.WS_SMALLINT[02].GetMoveValues();
                spl89 += ">";
                spl89 += "<PLAN= ";
                var spl90 = WORK.WS_EDIT.WS_SMALLINT[03].GetMoveValues();
                spl90 += ">";
                var results91 = spl86 + spl87 + spl88 + spl89 + spl90;
                _.Move(results91, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -1558- MOVE 'SEGUROS.VG_ACOPLADO' TO WS-TABELA */
                _.Move("SEGUROS.VG_ACOPLADO", WORK.WS_ERRO.WS_TABELA);

                /*" -1559- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -1560- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -1561- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -1562- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1564- END-IF */
            }


            /*" -1567- PERFORM P0851-BUSCAR-TIMESTAMP THRU P0851-99-EXIT */

            P0851_BUSCAR_TIMESTAMP_SECTION();

            P0851_00_START(true);

            P0851_01_INICIO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: P0851_99_EXIT*/


            /*" -1570- PERFORM P0420-PREPARAR-VARCHAR THRU P0420-99-EXIT */

            P0420_PREPARAR_VARCHAR_SECTION();

            P0420_00_START(true);

            P0420_05_INICIO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: P0420_99_EXIT*/


            /*" -1571- IF LK-VG013-COD-RETORNO-API EQUAL 200 */

            if (SPVG013W.LK_VG013_COD_RETORNO_API == 200)
            {

                /*" -1573- PERFORM P0540-CONTAR-TITULOS-ATV THRU P0540-99-EXIT */

                P0540_CONTAR_TITULOS_ATV_SECTION();

                P0540_00_START(true);

                P0540_05_INICIO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P0540_99_EXIT*/


                /*" -1574- IF VG135-QTD-TITULO GREATER WS-COUNT */

                if (VG135.DCLVG_ACOPLADO.VG135_QTD_TITULO > WORK.WS_AUXILIARES.WS_COUNT)
                {

                    /*" -1575- MOVE 1 TO VG135-STA-ACOPLADO */
                    _.Move(1, VG135.DCLVG_ACOPLADO.VG135_STA_ACOPLADO);

                    /*" -1576- ELSE */
                }
                else
                {


                    /*" -1577- MOVE 2 TO VG135-STA-ACOPLADO */
                    _.Move(2, VG135.DCLVG_ACOPLADO.VG135_STA_ACOPLADO);

                    /*" -1578- END-IF */
                }


                /*" -1580- PERFORM P0210-ATUALIZAR-VG0135 THRU P0210-99-EXIT */

                P0210_ATUALIZAR_VG0135_SECTION();

                P0210_00_START(true);

                P0210_05_INICIO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P0210_99_EXIT*/


                /*" -1582- PERFORM P0300-INSERIR-VG0137 THRU P0300-99-EXIT */

                P0300_INSERIR_VG0137_SECTION();

                P0300_00_START(true);

                P0300_05_INICIO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P0300_99_EXIT*/


                /*" -1583- ELSE */
            }
            else
            {


                /*" -1584- MOVE 5 TO VG135-STA-ACOPLADO */
                _.Move(5, VG135.DCLVG_ACOPLADO.VG135_STA_ACOPLADO);

                /*" -1586- PERFORM P0210-ATUALIZAR-VG0135 THRU P0210-99-EXIT */

                P0210_ATUALIZAR_VG0135_SECTION();

                P0210_00_START(true);

                P0210_05_INICIO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P0210_99_EXIT*/


                /*" -1588- PERFORM P0300-INSERIR-VG0137 THRU P0300-99-EXIT */

                P0300_INSERIR_VG0137_SECTION();

                P0300_00_START(true);

                P0300_05_INICIO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P0300_99_EXIT*/


                /*" -1590- PERFORM P0400-INSERIR-VG0139 THRU P0400-99-EXIT */

                P0400_INSERIR_VG0139_SECTION();

                P0400_00_START(true);

                P0400_05_INICIO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P0400_99_EXIT*/


                /*" -1592- END-IF */
            }


            /*" -1592- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P4000_99_EXIT*/

        [StopWatch]
        /*" P5000-TRATAR-TIPO-ACAO-05-SECTION */
        private void P5000_TRATAR_TIPO_ACAO_05_SECTION()
        {
            /*" -1600- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P5000_00_START */

            P5000_00_START();

        }

        [StopWatch]
        /*" P5000-00-START */
        private void P5000_00_START(bool isPerform = false)
        {
            /*" -1602- MOVE 'P5000' TO WS-SECTION */
            _.Move("P5000", WORK.WS_ERRO.WS_SECTION);

            /*" -1603- IF LK-VG013-TRACE EQUAL 'S' */

            if (SPVG013W.LK_VG013_TRACE == "S")
            {

                /*" -1604- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -1604- END-IF. */
            }


        }

        [StopWatch]
        /*" P5000-05-INICIO */
        private void P5000_05_INICIO(bool isPerform = false)
        {
            /*" -1612- PERFORM P0250-CONSULTA-VG135 */

            P0250_CONSULTA_VG135_SECTION();

            /*" -1613- IF VG135-STA-ACOPLADO EQUAL 9 OR 7 OR 2 OR 1 */

            if (VG135.DCLVG_ACOPLADO.VG135_STA_ACOPLADO.In("9", "7", "2", "1"))
            {

                /*" -1614- CONTINUE */

                /*" -1615- ELSE */
            }
            else
            {


                /*" -1616- MOVE 'P5000' TO WS-SECTION */
                _.Move("P5000", WORK.WS_ERRO.WS_SECTION);

                /*" -1617- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -1618- MOVE VG135-NUM-CERTIFICADO TO WS-BIGINT(01) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_NUM_CERTIFICADO, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -1619- MOVE VG135-STA-ACOPLADO TO WS-SMALLINT(01) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_STA_ACOPLADO, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -1620- MOVE VG135-COD-PRODUTO TO WS-SMALLINT(02) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_COD_PRODUTO, WORK.WS_EDIT.WS_SMALLINT[02]);

                /*" -1621- MOVE VG135-COD-PLANO TO WS-SMALLINT(03) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_COD_PLANO, WORK.WS_EDIT.WS_SMALLINT[03]);

                /*" -1623- DISPLAY 'P5000-05-INICIO - VG135-STA-ACOPLADO.: ' VG135-STA-ACOPLADO */
                _.Display($"P5000-05-INICIO - VG135-STA-ACOPLADO.: {VG135.DCLVG_ACOPLADO.VG135_STA_ACOPLADO}");

                /*" -1630- STRING WS-SECTION ' - VERIFIQUE O STATUS DO ACOPLADO.' '<CERT= ' WS-BIGINT(01) '>' '<STAT= ' WS-SMALLINT(01) '>' '<PROD= ' WS-SMALLINT(02) '>' '<PLAN= ' WS-SMALLINT(03) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl91 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl91 += " - VERIFIQUE O STATUS DO ACOPLADO.";
                spl91 += "<CERT= ";
                var spl92 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                spl92 += ">";
                spl92 += "<STAT= ";
                var spl93 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl93 += ">";
                spl93 += "<PROD= ";
                var spl94 = WORK.WS_EDIT.WS_SMALLINT[02].GetMoveValues();
                spl94 += ">";
                spl94 += "<PLAN= ";
                var spl95 = WORK.WS_EDIT.WS_SMALLINT[03].GetMoveValues();
                spl95 += ">";
                var results96 = spl91 + spl92 + spl93 + spl94 + spl95;
                _.Move(results96, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -1631- MOVE 'SEGUROS.VG_ACOPLADO' TO WS-TABELA */
                _.Move("SEGUROS.VG_ACOPLADO", WORK.WS_ERRO.WS_TABELA);

                /*" -1632- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -1633- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -1634- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -1635- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1637- END-IF */
            }


            /*" -1638- IF WS-TEM-ACOPLADO */

            if (WORK.WS_ACOPLADO["WS_TEM_ACOPLADO"])
            {

                /*" -1639- IF VG135-STA-ACOPLADO NOT EQUAL 7 */

                if (VG135.DCLVG_ACOPLADO.VG135_STA_ACOPLADO != 7)
                {

                    /*" -1641- MOVE 7 TO VG135-STA-ACOPLADO */
                    _.Move(7, VG135.DCLVG_ACOPLADO.VG135_STA_ACOPLADO);

                    /*" -1643- PERFORM P0851-BUSCAR-TIMESTAMP THRU P0851-99-EXIT */

                    P0851_BUSCAR_TIMESTAMP_SECTION();

                    P0851_00_START(true);

                    P0851_01_INICIO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: P0851_99_EXIT*/


                    /*" -1645- PERFORM P0210-ATUALIZAR-VG0135 THRU P0210-99-EXIT */

                    P0210_ATUALIZAR_VG0135_SECTION();

                    P0210_00_START(true);

                    P0210_05_INICIO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: P0210_99_EXIT*/


                    /*" -1647- PERFORM P0300-INSERIR-VG0137 THRU P0300-99-EXIT */

                    P0300_INSERIR_VG0137_SECTION();

                    P0300_00_START(true);

                    P0300_05_INICIO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: P0300_99_EXIT*/


                    /*" -1648- END-IF */
                }


                /*" -1649- ELSE */
            }
            else
            {


                /*" -1650- MOVE 'P5000' TO WS-SECTION */
                _.Move("P5000", WORK.WS_ERRO.WS_SECTION);

                /*" -1651- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -1652- MOVE VG135-NUM-CERTIFICADO TO WS-BIGINT(01) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_NUM_CERTIFICADO, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -1653- MOVE VG135-COD-PRODUTO TO WS-SMALLINT(01) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_COD_PRODUTO, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -1654- MOVE VG135-COD-PLANO TO WS-SMALLINT(02) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_COD_PLANO, WORK.WS_EDIT.WS_SMALLINT[02]);

                /*" -1660- STRING WS-SECTION ' - NAO ESTA CADASTRADO NA BASE DE CONTROLE.' '<CERT= ' WS-BIGINT(01) '>' '<PROD= ' WS-SMALLINT(01) '>' '<PLAN= ' WS-SMALLINT(02) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl96 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl96 += " - NAO ESTA CADASTRADO NA BASE DE CONTROLE.";
                spl96 += "<CERT= ";
                var spl97 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                spl97 += ">";
                spl97 += "<PROD= ";
                var spl98 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl98 += ">";
                spl98 += "<PLAN= ";
                var spl99 = WORK.WS_EDIT.WS_SMALLINT[02].GetMoveValues();
                spl99 += ">";
                var results100 = spl96 + spl97 + spl98 + spl99;
                _.Move(results100, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -1661- MOVE 'SEGUROS.VG_ACOPLADO' TO WS-TABELA */
                _.Move("SEGUROS.VG_ACOPLADO", WORK.WS_ERRO.WS_TABELA);

                /*" -1662- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -1663- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -1664- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -1665- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1667- END-IF */
            }


            /*" -1667- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P5000_99_EXIT*/

        [StopWatch]
        /*" P6000-TRATAR-TIPO-ACAO-06-SECTION */
        private void P6000_TRATAR_TIPO_ACAO_06_SECTION()
        {
            /*" -1675- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P6000_00_START */

            P6000_00_START();

        }

        [StopWatch]
        /*" P6000-00-START */
        private void P6000_00_START(bool isPerform = false)
        {
            /*" -1677- MOVE 'P6000' TO WS-SECTION */
            _.Move("P6000", WORK.WS_ERRO.WS_SECTION);

            /*" -1678- IF LK-VG013-TRACE EQUAL 'S' */

            if (SPVG013W.LK_VG013_TRACE == "S")
            {

                /*" -1679- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -1679- END-IF. */
            }


        }

        [StopWatch]
        /*" P6000-05-INICIO */
        private void P6000_05_INICIO(bool isPerform = false)
        {
            /*" -1687- PERFORM P0250-CONSULTA-VG135 THRU P0250-99-EXIT */

            P0250_CONSULTA_VG135_SECTION();

            P0250_00_START(true);

            P0250_05_INICIO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: P0250_99_EXIT*/


            /*" -1688- IF WS-SEM-ACOPLADO */

            if (WORK.WS_ACOPLADO["WS_SEM_ACOPLADO"])
            {

                /*" -1689- MOVE 'P6000' TO WS-SECTION */
                _.Move("P6000", WORK.WS_ERRO.WS_SECTION);

                /*" -1690- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -1691- MOVE VG135-NUM-CERTIFICADO TO WS-BIGINT(01) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_NUM_CERTIFICADO, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -1692- MOVE VG135-COD-PRODUTO TO WS-SMALLINT(01) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_COD_PRODUTO, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -1693- MOVE VG135-COD-PLANO TO WS-SMALLINT(02) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_COD_PLANO, WORK.WS_EDIT.WS_SMALLINT[02]);

                /*" -1699- STRING WS-SECTION ' - NAO ESTA CADASTRADO NA BASE DE CONTROLE.' '<CERT= ' WS-BIGINT(01) '>' '<PROD= ' WS-SMALLINT(01) '>' '<PLAN= ' WS-SMALLINT(02) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl100 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl100 += " - NAO ESTA CADASTRADO NA BASE DE CONTROLE.";
                spl100 += "<CERT= ";
                var spl101 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                spl101 += ">";
                spl101 += "<PROD= ";
                var spl102 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl102 += ">";
                spl102 += "<PLAN= ";
                var spl103 = WORK.WS_EDIT.WS_SMALLINT[02].GetMoveValues();
                spl103 += ">";
                var results104 = spl100 + spl101 + spl102 + spl103;
                _.Move(results104, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -1700- MOVE 'SEGUROS.VG_ACOPLADO' TO WS-TABELA */
                _.Move("SEGUROS.VG_ACOPLADO", WORK.WS_ERRO.WS_TABELA);

                /*" -1701- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -1702- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -1703- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -1704- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1706- END-IF */
            }


            /*" -1707- IF VG135-STA-ACOPLADO EQUAL 6 */

            if (VG135.DCLVG_ACOPLADO.VG135_STA_ACOPLADO == 6)
            {

                /*" -1708- CONTINUE */

                /*" -1709- ELSE */
            }
            else
            {


                /*" -1710- MOVE 'P6000' TO WS-SECTION */
                _.Move("P6000", WORK.WS_ERRO.WS_SECTION);

                /*" -1711- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -1712- MOVE VG135-NUM-CERTIFICADO TO WS-BIGINT(01) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_NUM_CERTIFICADO, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -1713- MOVE VG135-STA-ACOPLADO TO WS-SMALLINT(01) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_STA_ACOPLADO, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -1714- MOVE VG135-COD-PRODUTO TO WS-SMALLINT(02) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_COD_PRODUTO, WORK.WS_EDIT.WS_SMALLINT[02]);

                /*" -1715- MOVE VG135-COD-PLANO TO WS-SMALLINT(03) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_COD_PLANO, WORK.WS_EDIT.WS_SMALLINT[03]);

                /*" -1722- STRING WS-SECTION ' - STA-ACOPLADO NAO PERMITE ATUALIZAR.' '<CERT= ' WS-BIGINT(01) '>' '<STAT= ' WS-SMALLINT(01) '>' '<PROD= ' WS-SMALLINT(02) '>' '<PLAN= ' WS-SMALLINT(03) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl104 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl104 += " - STA-ACOPLADO NAO PERMITE ATUALIZAR.";
                spl104 += "<CERT= ";
                var spl105 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                spl105 += ">";
                spl105 += "<STAT= ";
                var spl106 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl106 += ">";
                spl106 += "<PROD= ";
                var spl107 = WORK.WS_EDIT.WS_SMALLINT[02].GetMoveValues();
                spl107 += ">";
                spl107 += "<PLAN= ";
                var spl108 = WORK.WS_EDIT.WS_SMALLINT[03].GetMoveValues();
                spl108 += ">";
                var results109 = spl104 + spl105 + spl106 + spl107 + spl108;
                _.Move(results109, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -1723- MOVE 'SEGUROS.VG_ACOPLADO' TO WS-TABELA */
                _.Move("SEGUROS.VG_ACOPLADO", WORK.WS_ERRO.WS_TABELA);

                /*" -1724- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -1725- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -1726- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -1727- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1729- END-IF */
            }


            /*" -1732- PERFORM P0851-BUSCAR-TIMESTAMP THRU P0851-99-EXIT */

            P0851_BUSCAR_TIMESTAMP_SECTION();

            P0851_00_START(true);

            P0851_01_INICIO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: P0851_99_EXIT*/


            /*" -1735- PERFORM P0420-PREPARAR-VARCHAR THRU P0420-99-EXIT */

            P0420_PREPARAR_VARCHAR_SECTION();

            P0420_00_START(true);

            P0420_05_INICIO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: P0420_99_EXIT*/


            /*" -1736- IF LK-VG013-COD-RETORNO-API EQUAL 200 */

            if (SPVG013W.LK_VG013_COD_RETORNO_API == 200)
            {

                /*" -1737- MOVE 7 TO VG135-STA-ACOPLADO */
                _.Move(7, VG135.DCLVG_ACOPLADO.VG135_STA_ACOPLADO);

                /*" -1739- PERFORM P0210-ATUALIZAR-VG0135 THRU P0210-99-EXIT */

                P0210_ATUALIZAR_VG0135_SECTION();

                P0210_00_START(true);

                P0210_05_INICIO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P0210_99_EXIT*/


                /*" -1741- PERFORM P0300-INSERIR-VG0137 THRU P0300-99-EXIT */

                P0300_INSERIR_VG0137_SECTION();

                P0300_00_START(true);

                P0300_05_INICIO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P0300_99_EXIT*/


                /*" -1742- ELSE */
            }
            else
            {


                /*" -1743- MOVE 5 TO VG135-STA-ACOPLADO */
                _.Move(5, VG135.DCLVG_ACOPLADO.VG135_STA_ACOPLADO);

                /*" -1745- PERFORM P0210-ATUALIZAR-VG0135 THRU P0210-99-EXIT */

                P0210_ATUALIZAR_VG0135_SECTION();

                P0210_00_START(true);

                P0210_05_INICIO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P0210_99_EXIT*/


                /*" -1747- PERFORM P0300-INSERIR-VG0137 THRU P0300-99-EXIT */

                P0300_INSERIR_VG0137_SECTION();

                P0300_00_START(true);

                P0300_05_INICIO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P0300_99_EXIT*/


                /*" -1749- PERFORM P0400-INSERIR-VG0139 THRU P0400-99-EXIT */

                P0400_INSERIR_VG0139_SECTION();

                P0400_00_START(true);

                P0400_05_INICIO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P0400_99_EXIT*/


                /*" -1751- END-IF */
            }


            /*" -1751- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P6000_99_EXIT*/

        [StopWatch]
        /*" P7000-TRATAR-TIPO-ACAO-07-SECTION */
        private void P7000_TRATAR_TIPO_ACAO_07_SECTION()
        {
            /*" -1759- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P7000_00_START */

            P7000_00_START();

        }

        [StopWatch]
        /*" P7000-00-START */
        private void P7000_00_START(bool isPerform = false)
        {
            /*" -1761- MOVE 'P7000' TO WS-SECTION */
            _.Move("P7000", WORK.WS_ERRO.WS_SECTION);

            /*" -1762- IF LK-VG013-TRACE EQUAL 'S' */

            if (SPVG013W.LK_VG013_TRACE == "S")
            {

                /*" -1763- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -1763- END-IF. */
            }


        }

        [StopWatch]
        /*" P7000-05-INICIO */
        private void P7000_05_INICIO(bool isPerform = false)
        {
            /*" -1771- PERFORM P0250-CONSULTA-VG135 THRU P0250-99-EXIT */

            P0250_CONSULTA_VG135_SECTION();

            P0250_00_START(true);

            P0250_05_INICIO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: P0250_99_EXIT*/


            /*" -1772- IF WS-SEM-ACOPLADO */

            if (WORK.WS_ACOPLADO["WS_SEM_ACOPLADO"])
            {

                /*" -1773- MOVE 'P7000' TO WS-SECTION */
                _.Move("P7000", WORK.WS_ERRO.WS_SECTION);

                /*" -1774- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -1775- MOVE VG135-NUM-CERTIFICADO TO WS-BIGINT(01) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_NUM_CERTIFICADO, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -1776- MOVE VG135-COD-PRODUTO TO WS-SMALLINT(01) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_COD_PRODUTO, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -1777- MOVE VG135-COD-PLANO TO WS-SMALLINT(02) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_COD_PLANO, WORK.WS_EDIT.WS_SMALLINT[02]);

                /*" -1783- STRING WS-SECTION ' - NAO ESTA CADASTRADO NA BASE DE CONTROLE.' '<CERT= ' WS-BIGINT(01) '>' '<PROD= ' WS-SMALLINT(01) '>' '<PLAN= ' WS-SMALLINT(02) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl109 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl109 += " - NAO ESTA CADASTRADO NA BASE DE CONTROLE.";
                spl109 += "<CERT= ";
                var spl110 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                spl110 += ">";
                spl110 += "<PROD= ";
                var spl111 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl111 += ">";
                spl111 += "<PLAN= ";
                var spl112 = WORK.WS_EDIT.WS_SMALLINT[02].GetMoveValues();
                spl112 += ">";
                var results113 = spl109 + spl110 + spl111 + spl112;
                _.Move(results113, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -1784- MOVE 'SEGUROS.VG_ACOPLADO' TO WS-TABELA */
                _.Move("SEGUROS.VG_ACOPLADO", WORK.WS_ERRO.WS_TABELA);

                /*" -1785- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -1786- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -1787- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -1788- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1790- END-IF */
            }


            /*" -1791- IF VG135-STA-ACOPLADO EQUAL 3 */

            if (VG135.DCLVG_ACOPLADO.VG135_STA_ACOPLADO == 3)
            {

                /*" -1792- CONTINUE */

                /*" -1793- ELSE */
            }
            else
            {


                /*" -1794- MOVE 'P7000' TO WS-SECTION */
                _.Move("P7000", WORK.WS_ERRO.WS_SECTION);

                /*" -1795- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -1796- MOVE VG135-NUM-CERTIFICADO TO WS-BIGINT(01) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_NUM_CERTIFICADO, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -1797- MOVE VG135-STA-ACOPLADO TO WS-SMALLINT(01) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_STA_ACOPLADO, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -1798- MOVE VG135-COD-PRODUTO TO WS-SMALLINT(02) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_COD_PRODUTO, WORK.WS_EDIT.WS_SMALLINT[02]);

                /*" -1799- MOVE VG135-COD-PLANO TO WS-SMALLINT(03) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_COD_PLANO, WORK.WS_EDIT.WS_SMALLINT[03]);

                /*" -1806- STRING WS-SECTION ' - STA-ACOPLADO NAO PERMITE ATUALIZAR.' '<CERT= ' WS-BIGINT(01) '>' '<STAT= ' WS-SMALLINT(01) '>' '<PROD= ' WS-SMALLINT(02) '>' '<PLAN= ' WS-SMALLINT(03) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl113 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl113 += " - STA-ACOPLADO NAO PERMITE ATUALIZAR.";
                spl113 += "<CERT= ";
                var spl114 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                spl114 += ">";
                spl114 += "<STAT= ";
                var spl115 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl115 += ">";
                spl115 += "<PROD= ";
                var spl116 = WORK.WS_EDIT.WS_SMALLINT[02].GetMoveValues();
                spl116 += ">";
                spl116 += "<PLAN= ";
                var spl117 = WORK.WS_EDIT.WS_SMALLINT[03].GetMoveValues();
                spl117 += ">";
                var results118 = spl113 + spl114 + spl115 + spl116 + spl117;
                _.Move(results118, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -1807- MOVE 'SEGUROS.VG_ACOPLADO' TO WS-TABELA */
                _.Move("SEGUROS.VG_ACOPLADO", WORK.WS_ERRO.WS_TABELA);

                /*" -1808- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -1809- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -1810- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -1811- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1813- END-IF */
            }


            /*" -1816- PERFORM P0851-BUSCAR-TIMESTAMP THRU P0851-99-EXIT */

            P0851_BUSCAR_TIMESTAMP_SECTION();

            P0851_00_START(true);

            P0851_01_INICIO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: P0851_99_EXIT*/


            /*" -1819- PERFORM P0420-PREPARAR-VARCHAR THRU P0420-99-EXIT */

            P0420_PREPARAR_VARCHAR_SECTION();

            P0420_00_START(true);

            P0420_05_INICIO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: P0420_99_EXIT*/


            /*" -1820- IF LK-VG013-COD-RETORNO-API EQUAL 200 */

            if (SPVG013W.LK_VG013_COD_RETORNO_API == 200)
            {

                /*" -1821- MOVE 1 TO VG135-STA-ACOPLADO */
                _.Move(1, VG135.DCLVG_ACOPLADO.VG135_STA_ACOPLADO);

                /*" -1823- PERFORM P0210-ATUALIZAR-VG0135 THRU P0210-99-EXIT */

                P0210_ATUALIZAR_VG0135_SECTION();

                P0210_00_START(true);

                P0210_05_INICIO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P0210_99_EXIT*/


                /*" -1825- PERFORM P0300-INSERIR-VG0137 THRU P0300-99-EXIT */

                P0300_INSERIR_VG0137_SECTION();

                P0300_00_START(true);

                P0300_05_INICIO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P0300_99_EXIT*/


                /*" -1826- ELSE */
            }
            else
            {


                /*" -1827- MOVE 4 TO VG135-STA-ACOPLADO */
                _.Move(4, VG135.DCLVG_ACOPLADO.VG135_STA_ACOPLADO);

                /*" -1829- PERFORM P0210-ATUALIZAR-VG0135 THRU P0210-99-EXIT */

                P0210_ATUALIZAR_VG0135_SECTION();

                P0210_00_START(true);

                P0210_05_INICIO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P0210_99_EXIT*/


                /*" -1831- PERFORM P0300-INSERIR-VG0137 THRU P0300-99-EXIT */

                P0300_INSERIR_VG0137_SECTION();

                P0300_00_START(true);

                P0300_05_INICIO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P0300_99_EXIT*/


                /*" -1833- PERFORM P0400-INSERIR-VG0139 THRU P0400-99-EXIT */

                P0400_INSERIR_VG0139_SECTION();

                P0400_00_START(true);

                P0400_05_INICIO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P0400_99_EXIT*/


                /*" -1835- END-IF */
            }


            /*" -1835- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P7000_99_EXIT*/

        [StopWatch]
        /*" P9999-ERRO-SECTION */
        private void P9999_ERRO_SECTION()
        {
            /*" -1846- DISPLAY '**********************************************' */
            _.Display($"**********************************************");

            /*" -1847- DISPLAY '*         E R R O    S P B V G 0 1 3         *' */
            _.Display($"*         E R R O    S P B V G 0 1 3         *");

            /*" -1848- DISPLAY '**********************************************' */
            _.Display($"**********************************************");

            /*" -1849- DISPLAY '* SECTION..........: ' WS-SECTION */
            _.Display($"* SECTION..........: {WORK.WS_ERRO.WS_SECTION}");

            /*" -1850- DISPLAY '* IND ERRO.........: ' WS-IND-ERRO */
            _.Display($"* IND ERRO.........: {WORK.WS_ERRO.WS_IND_ERRO}");

            /*" -1851- DISPLAY '* TABELA...........: ' WS-TABELA */
            _.Display($"* TABELA...........: {WORK.WS_ERRO.WS_TABELA}");

            /*" -1852- DISPLAY '* MENSAGEM.........: ' WS-MENSAGEM */
            _.Display($"* MENSAGEM.........: {WORK.WS_ERRO.WS_MENSAGEM}");

            /*" -1853- DISPLAY '* SQLCODE..........: ' WS-SQLCODE */
            _.Display($"* SQLCODE..........: {WORK.WS_ERRO.WS_SQLCODE}");

            /*" -1854- DISPLAY '* SQLERRMC.........: ' WS-SQLERRMC */
            _.Display($"* SQLERRMC.........: {WORK.WS_ERRO.WS_SQLERRMC}");

            /*" -1855- DISPLAY '* SQLSTATE.........: ' WS-SQLSTATE */
            _.Display($"* SQLSTATE.........: {WORK.WS_ERRO.WS_SQLSTATE}");

            /*" -1857- DISPLAY '**********************************************' */
            _.Display($"**********************************************");

            /*" -1858- DISPLAY '**********************************************' */
            _.Display($"**********************************************");

            /*" -1859- DISPLAY '*            S P B V G 0 1 3                 *' */
            _.Display($"*            S P B V G 0 1 3                 *");

            /*" -1860- DISPLAY '**********************************************' */
            _.Display($"**********************************************");

            /*" -1867- DISPLAY '* DATA COMPILACAO..: ' WS-C-DATE-COMPILED(7:2) '/' WS-C-DATE-COMPILED(5:2) '/' WS-C-DATE-COMPILED(1:4) '-' WS-C-DATE-COMPILED(9:2) ':' WS-C-DATE-COMPILED(11:2) ':' WS-C-DATE-COMPILED(13:2) */

            $"* DATA COMPILACAO..: {WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(7, 2)}/{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(5, 2)}/{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(1, 4)}-{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(9, 2)}:{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(11, 2)}:{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(13, 2)}"
            .Display();

            /*" -1874- DISPLAY '* DATA EXECUCAO....: ' WS-C-DATE-CURRENT(7:2) '/' WS-C-DATE-CURRENT(5:2) '/' WS-C-DATE-CURRENT(1:4) '-' WS-C-DATE-CURRENT(9:2) ':' WS-C-DATE-CURRENT(11:2) ':' WS-C-DATE-CURRENT(13:2) */

            $"* DATA EXECUCAO....: {WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(7, 2)}/{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(5, 2)}/{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(1, 4)}-{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(9, 2)}:{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(11, 2)}:{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(13, 2)}"
            .Display();

            /*" -1879- DISPLAY '* DATA SISTEMA.....: ' SISTEMAS-DATA-MOV-ABERTO(9:2) '/' SISTEMAS-DATA-MOV-ABERTO(6:2) '/' SISTEMAS-DATA-MOV-ABERTO(1:4) */

            $"* DATA SISTEMA.....: {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2)}/{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2)}/{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4)}"
            .Display();

            /*" -1880- DISPLAY '**********************************************' */
            _.Display($"**********************************************");

            /*" -1881- DISPLAY '*             DADOS DE ENTRADA               *' */
            _.Display($"*             DADOS DE ENTRADA               *");

            /*" -1882- DISPLAY '**********************************************' */
            _.Display($"**********************************************");

            /*" -1883- DISPLAY '* TRACE............: ' LK-VG013-TRACE */
            _.Display($"* TRACE............: {SPVG013W.LK_VG013_TRACE}");

            /*" -1884- DISPLAY '* SISTEMA.CHAMADOR.: ' LK-VG013-SISTEMA-CHAMADOR */
            _.Display($"* SISTEMA.CHAMADOR.: {SPVG013W.LK_VG013_SISTEMA_CHAMADOR}");

            /*" -1885- DISPLAY '* CANAL............: ' LK-VG013-CANAL */
            _.Display($"* CANAL............: {SPVG013W.LK_VG013_CANAL}");

            /*" -1886- DISPLAY '* ORIGEM...........: ' LK-VG013-ORIGEM */
            _.Display($"* ORIGEM...........: {SPVG013W.LK_VG013_ORIGEM}");

            /*" -1887- DISPLAY '* COD-USUARIO......: ' LK-VG013-COD-USUARIO */
            _.Display($"* COD-USUARIO......: {SPVG013W.LK_VG013_COD_USUARIO}");

            /*" -1888- DISPLAY '* TIPO-ACAO........: ' LK-VG013-TIPO-ACAO */
            _.Display($"* TIPO-ACAO........: {SPVG013W.LK_VG013_TIPO_ACAO}");

            /*" -1889- DISPLAY '* IDE-SISTEMA......: ' LK-VG013-IDE-SISTEMA */
            _.Display($"* IDE-SISTEMA......: {SPVG013W.LK_VG013_IDE_SISTEMA}");

            /*" -1890- DISPLAY '* NUM-CERTIFICADO..: ' LK-VG013-NUM-CERTIFICADO */
            _.Display($"* NUM-CERTIFICADO..: {SPVG013W.LK_VG013_NUM_CERTIFICADO}");

            /*" -1891- DISPLAY '* COD-PRODUTO......: ' LK-VG013-COD-PRODUTO */
            _.Display($"* COD-PRODUTO......: {SPVG013W.LK_VG013_COD_PRODUTO}");

            /*" -1892- DISPLAY '* COD-PLANO........: ' LK-VG013-COD-PLANO */
            _.Display($"* COD-PLANO........: {SPVG013W.LK_VG013_COD_PLANO}");

            /*" -1893- DISPLAY '* QTD-TITULO.......: ' LK-VG013-QTD-TITULO */
            _.Display($"* QTD-TITULO.......: {SPVG013W.LK_VG013_QTD_TITULO}");

            /*" -1894- DISPLAY '* VLR-TITULO.......: ' LK-VG013-VLR-TITULO */
            _.Display($"* VLR-TITULO.......: {SPVG013W.LK_VG013_VLR_TITULO}");

            /*" -1895- DISPLAY '* COD-EMPRESA-CAP..: ' LK-VG013-COD-EMPRESA-CAP */
            _.Display($"* COD-EMPRESA-CAP..: {SPVG013W.LK_VG013_COD_EMPRESA_CAP}");

            /*" -1896- DISPLAY '* COD-RETORNO-API..: ' LK-VG013-COD-RETORNO-API */
            _.Display($"* COD-RETORNO-API..: {SPVG013W.LK_VG013_COD_RETORNO_API}");

            /*" -1897- DISPLAY '* DES-ERRO.........: ' LK-VG013-DES-ERRO */
            _.Display($"* DES-ERRO.........: {SPVG013W.LK_VG013_DES_ERRO}");

            /*" -1898- DISPLAY '* DES-ACAO.........: ' LK-VG013-DES-ACAO */
            _.Display($"* DES-ACAO.........: {SPVG013W.LK_VG013_DES_ACAO}");

            /*" -1900- DISPLAY '**********************************************' */
            _.Display($"**********************************************");

            /*" -1901- MOVE WS-IND-ERRO TO H-OUT-COD-RETORNO */
            _.Move(WORK.WS_ERRO.WS_IND_ERRO, LBHCT002.H_OUT_COD_RETORNO);

            /*" -1902- MOVE WS-SQLCODE TO H-OUT-COD-RETORNO-SQL */
            _.Move(WORK.WS_ERRO.WS_SQLCODE, LBHCT002.H_OUT_COD_RETORNO_SQL);

            /*" -1903- MOVE WS-MENSAGEM TO H-OUT-MENSAGEM */
            _.Move(WORK.WS_ERRO.WS_MENSAGEM, LBHCT002.H_OUT_MENSAGEM);

            /*" -1904- MOVE WS-SQLERRMC TO H-OUT-SQLERRMC */
            _.Move(WORK.WS_ERRO.WS_SQLERRMC, LBHCT002.H_OUT_SQLERRMC);

            /*" -1906- MOVE WS-SQLSTATE TO H-OUT-SQLSTATE */
            _.Move(WORK.WS_ERRO.WS_SQLSTATE, LBHCT002.H_OUT_SQLSTATE);

            /*" -1906- . */

            /*" -0- FLUXCONTROL_PERFORM P9999_99_EXIT */

            P9999_99_EXIT();

        }

        [StopWatch]
        /*" P9999-99-EXIT */
        private void P9999_99_EXIT(bool isPerform = false)
        {
            /*" -1909- GOBACK. */

            throw new GoBack();

        }
    }
}