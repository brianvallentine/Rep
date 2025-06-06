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
using Sias.Outros.DB2.SPBVG001;

namespace Code
{
    public class SPBVG001
    {
        public bool IsCall { get; set; }

        public SPBVG001()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      * SISTEMA.........: SIAS                                         *      */
        /*"      * MODULO..........: VIDA                                         *      */
        /*"      * PROGRAMA........: SPBVG001                                     *      */
        /*"      * ANALISTA........: HUSNI ALI HUSNI                              *      */
        /*"      * DATA............: 13/01/2021                                   *      */
        /*"      * DEMANDA.........: 239409     TAREFA..........: 273899          *      */
        /*"      ******************************************************************      */
        /*"      * OBJETIVO........: MANTER ACOES DE CRITICAS REALIZADAS PELO     *      */
        /*"      *                   SISTEMA/USUARIO PARA PROPOSTA/CERTIFICADO    *      */
        /*"      *                   OBSERVA��O:                                  *      */
        /*"      *                   - DOCUMENTACAO DOS CAMPOS NO BOOK DE LINKAGE *      */
        /*"      *                   LK-VG001-TIPO-ACAO                           *      */
        /*"      *                   (01) PESQUISAR CERTIFICADO E RETORNAR SE     *      */
        /*"      *                        ESTA CADASTRADO OU NAO.                 *      */
        /*"      *                        CASO ESTEJA CADASTRADO RETORNAR DADOS   *      */
        /*"      *                        DA TABELA EM SUA ULTIMA SITUACAO        *      */
        /*"      *                   (02) INSERIR CRITICA PARA UM CERTIFICADO     *      */
        /*"      *                        SEMPRE STA_CRITICA = 0 (PENDENTE)       *      */
        /*"      *                   (03) ATUALIZAR CRITICA PARA UM CERTIFICADO   *      */
        /*"      *                        OCORRER A MUDANCA DE STATUS             *      */
        /*"      *                   (04) VERIFICA SE USUARIO POSSUI ALCADA PARA  *      */
        /*"      *                        MUDANCA DE STATUS                       *      */
        /*"      *                   (05) RETORNAR POSSIVEIS MUDANCAS DE STATUS   *      */
        /*"      *                        A PARTIR DE UM CERTIFICADO              *      */
        /*"      *                   (06) VERIFICAR SE CERTIFICA JA POSSUI A      *      */
        /*"      *                        CRITICA CADASTRADA COM STATUS ATIVO     *      */
        /*"V03   *                   (07) VERIFICAR SE CERTIFICADO POSSUI CRITICA *      */
        /*"V03   *                        CADASTRADA EM QUALQUER STATUS           *      */
        /*"V11   *                   (08) ALTERA TODOS AS CRITICAS PENDENTES PARA *      */
        /*"V11   *                        STA-CRITICA COMO SE SEGUE:              *      */
        /*"V11   *                        - CRITICA COM STATUS <> '8' MUDA P/ '9' *      */
        /*"V11   *                        - CRITICA COM STATUS = 8 MUDA PARA      *      */
        /*"V11   *                          STATUS ENVIADO NA ENTRADA: 'A' OU '3' *      */
        /*"      ******************************************************************      */
        /*"      * VERSAO     DATA     RESPONSAVEL      ALTERACAO                 *      */
        /*"      ******************************************************************      */
        /*"V16   * V.016   20/08/2024  ELIERMES OLIVERA  DEMANDA 571176           *      */
        /*"      *                   - RETIRAR DISPLAY DE ENTRADA                 *      */
        /*"      *                                                                *      */
        /*"      *                                      PROCURE V16               *      */
        /*"      ******************************************************************      */
        /*"V15   * V.015   15/08/2024  ELIERMES OLIVERA  DEMANDA 571176           *      */
        /*"      *                   - CORRIGIR O IND_TP_PROPOSTA DE 'MD' P/ 'PF' *      */
        /*"      *                     NO MOMENTO DA INSERCAO                     *      */
        /*"      *                                                                *      */
        /*"      *                                      PROCURE V15               *      */
        /*"      ******************************************************************      */
        /*"V14   * V.014   05/08/2024  ELIERMES OLIVERA  DEMANDA 571176           *      */
        /*"      *                   - INSERIR CRITICA PARA PROPOSTAS COM DPS     *      */
        /*"      *                     ELETRONICO GERADO PELO MOTOR DE DPS        *      */
        /*"      *                                                                *      */
        /*"      *                                      PROCURE V14               *      */
        /*"      ******************************************************************      */
        /*"V.13  * V.13    22/07/2024  CANETTA          I 596501                  *      */
        /*"      *                   - ACEITAR -811 NO ACESSO A BILHETE_COBERTURA *      */
        /*"      *                                                                *      */
        /*"      *                                      PROCURE V.13              *      */
        /*"      ******************************************************************      */
        /*"      * V.012   25/06/2024  HUSNI ALI HUSNI  D 575149 T 593193         *      */
        /*"      *                   - ACERTO DA PESQUISA DA IMPORTANCIA SEGURADA *      */
        /*"      *                     PARA O BILHETE                             *      */
        /*"      *                                      PROCURE V12               *      */
        /*"      ******************************************************************      */
        /*"      * V.011   08/03/2023  ELIERMES OLIVERA  DEMANDA 402982           *      */
        /*"      *                   - CORRECAO DA EXCLUSAO LOGICA TIPO-ACAO 08.  *      */
        /*"      *                     QUANDO LK-VG001-STA-CRITICA RECEBIDA FOR   *      */
        /*"      *                     "A", REALIZAR EXCLUSAO LOGICA COM O STATUS *      */
        /*"      *                     RECEBIDO                                   *      */
        /*"      *                                      PROCURE V11               *      */
        /*"      ******************************************************************      */
        /*"      * V.010   08/03/2023  ELIERMES OLIVERA  DEMANDA 402982           *      */
        /*"      *                   - CORRECAO DA EXCLUSAO LOGICA TIPO-ACAO 08.  *      */
        /*"      *                     QUANDO ENCONTRAR STA_CRITICA 08 MUDAR PARA *      */
        /*"      *                     STA_CRITICA 03 E PARA OS DEMAIS STA_CRITICA*      */
        /*"      *                     MUDAR STA_CRITICA PARA 09                  *      */
        /*"      *                                      PROCURE V10               *      */
        /*"      ******************************************************************      */
        /*"      * V.009   23/02/2023  HUSNI ALI HUSNI  I 471186  T 471242        *      */
        /*"      *                   - ALTERAR TODOS AS CRITICAS PENDENTES PARA   *      */
        /*"      *                     STATUS '7', 'B' OU '9', CONFORME ENTRADA   *      */
        /*"      *                                      PROCURE V09               *      */
        /*"      ******************************************************************      */
        /*"      * V.008   14/02/2023  ELIERMES OLIVERA  DEMANDA 402982           *      */
        /*"      *                   - ALTERAR TODOS AS CRITICAS PENDENTES PARA   *      */
        /*"      *                     STATUS '7', 'B' OU '9', CONFORME ENTRADA   *      */
        /*"      *                                      PROCURE V08               *      */
        /*"      ******************************************************************      */
        /*"      * V.007   07/12/2022  ELIERMES OLIVERA  DEMANDA 402982           *      */
        /*"      *                   - CORRECAO DE ERRO -811 NA P0802 PROPOSTAS_VA*      */
        /*"      *                     QUANDO DA INSERCAO DE ERRO                 *      */
        /*"      *                                      PROCURE V07               *      */
        /*"      * -------------------------------------------------------------- *      */
        /*"      * V.006   11/10/2022  HUSNI ALI HUSNI   D 402982 T 435550        *      */
        /*"      *                   - PREPARAR TRATAMENTO PARA STATUS = 'B'      *      */
        /*"      *                                      PROCURE V06               *      */
        /*"      * -------------------------------------------------------------- *      */
        /*"      * V.005   11/10/2022  HUSNI ALI HUSNI   DEMANDA 379166           *      */
        /*"      *                   - ACERTO DA PESQUISA DO NUMERO DA PROPOSTA   *      */
        /*"      *                     PARA O SEGMENTO BILHETE                    *      */
        /*"      *                                      PROCURE V05               *      */
        /*"      * -------------------------------------------------------------- *      */
        /*"      * V.004   11/10/2022  ELIERMES OLIVEIRA DEMANDA 379166           *      */
        /*"      *                   - PESQUISA SE A PROPOSTA PJ EH UMA APOLICE   *      */
        /*"      *                     ESPECIFICA OU UM EMPRESARIAL GLOBAL        *      */
        /*"      *                   - CRIA TRATAMENTO DE INSERCAO PARA APOLICE   *      */
        /*"      *                     ESPECIFICA                                 *      */
        /*"      *                   - CORRECAO DE SQLCODE -305 NO SELECT DE      *      */
        /*"      *                     P0801-PESQUISAR-BILHETE                    *      */
        /*"      *                                      PROCURE V04               *      */
        /*"      * -------------------------------------------------------------- *      */
        /*"      * V.003   29/07/2022  ELIERMES OLIVEIRA DEMANDA 379166           *      */
        /*"      *                   - CORRECAO DA QUERY DO TIPO-ACAO 06          *      */
        /*"      *                   - CRIACAO DO TIPO-ACAO 07 PARA CONSULTAR SE  *      */
        /*"      *                     CERTIFICADO POSSUI QUALQUER CRITICA        *      */
        /*"      *                     CADASTRADA, INDEPENDENTE DO STATUS         *      */
        /*"      *                                      PROCURE V03               *      */
        /*"      * -------------------------------------------------------------- *      */
        /*"      * V.002   07/02/2021  HUSNI ALI HUSNI  D 294878 T 348687         *      */
        /*"      *                     ALTERADO PESQUISA DO EMPRESARIAL GLOBAL NA *      */
        /*"      *                     SECTION P0803 DE CURSOR PARA SELECT. NAO   *      */
        /*"      *                     EXISTE MAIS A NECESSIDADE DE VERIFICA SE O *      */
        /*"      *                     REPRESENTANTE LEGAL JA ESTA CADASTRADO     *      */
        /*"      *                                      PROCURE V02               *      */
        /*"      * -------------------------------------------------------------- *      */
        /*"      * V.001   13/01/2021  HUSNI ALI HUSNI  CRIACAO DO PROGRAMA       *      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"01    WH-AUXILIAR.*/
        public SPBVG001_WH_AUXILIAR WH_AUXILIAR { get; set; } = new SPBVG001_WH_AUXILIAR();
        public class SPBVG001_WH_AUXILIAR : VarBasis
        {
            /*"  05  WH-CURRENT-TIMESTAMP           PIC  X(026) VALUE SPACES.*/
            public StringBasis WH_CURRENT_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
            /*"  05  WH-VG103-DES-COMPLEMENTAR.*/
            public SPBVG001_WH_VG103_DES_COMPLEMENTAR WH_VG103_DES_COMPLEMENTAR { get; set; } = new SPBVG001_WH_VG103_DES_COMPLEMENTAR();
            public class SPBVG001_WH_VG103_DES_COMPLEMENTAR : VarBasis
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
            /*"  05  WH-IDADE                       PIC S9(004) COMP-5 VALUE 0.*/
            public IntBasis WH_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01    WORK.*/
        }
        public SPBVG001_WORK WORK { get; set; } = new SPBVG001_WORK();
        public class SPBVG001_WORK : VarBasis
        {
            /*"  05  WS-PROGRAMA                    PIC  X(008) VALUE SPACES.*/
            public StringBasis WS_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"  05  WS-ORIG-PRODUTO                PIC  X(010) VALUE SPACES.*/
            public StringBasis WS_ORIG_PRODUTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05  WS-AUXILIARES.*/
            public SPBVG001_WS_AUXILIARES WS_AUXILIARES { get; set; } = new SPBVG001_WS_AUXILIARES();
            public class SPBVG001_WS_AUXILIARES : VarBasis
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
            public SPBVG001_WS_CONTADORES WS_CONTADORES { get; set; } = new SPBVG001_WS_CONTADORES();
            public class SPBVG001_WS_CONTADORES : VarBasis
            {
                /*"   10 WS-I                           PIC S9(004) COMP VALUE 0.*/
                public IntBasis WS_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"   10 WS-J                           PIC S9(004) COMP VALUE 0.*/
                public IntBasis WS_J { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"  05  WS-DATAS.*/
            }
            public SPBVG001_WS_DATAS WS_DATAS { get; set; } = new SPBVG001_WS_DATAS();
            public class SPBVG001_WS_DATAS : VarBasis
            {
                /*"   10 WS-C-DATE-CURRENT              PIC  X(014) VALUE SPACES.*/
                public StringBasis WS_C_DATE_CURRENT { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
                /*"   10 WS-C-DATE-COMPILED             PIC  X(014) VALUE SPACES.*/
                public StringBasis WS_C_DATE_COMPILED { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
                /*"  05  WS-EDIT.*/
            }
            public SPBVG001_WS_EDIT WS_EDIT { get; set; } = new SPBVG001_WS_EDIT();
            public class SPBVG001_WS_EDIT : VarBasis
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
            public SPBVG001_WS_ERRO WS_ERRO { get; set; } = new SPBVG001_WS_ERRO();
            public class SPBVG001_WS_ERRO : VarBasis
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
            public SPBVG001_WS_INDICADORES WS_INDICADORES { get; set; } = new SPBVG001_WS_INDICADORES();
            public class SPBVG001_WS_INDICADORES : VarBasis
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
        public Copies.SPVG001X SPVG001X { get; set; } = new Copies.SPVG001X();
        public Copies.GE0070W GE0070W { get; set; } = new Copies.GE0070W();
        public Copies.GE0071W GE0071W { get; set; } = new Copies.GE0071W();
        public Copies.SPVG001W SPVG001W { get; set; } = new Copies.SPVG001W();
        public Dclgens.BILHETE BILHETE { get; set; } = new Dclgens.BILHETE();
        public Dclgens.BILCOBER BILCOBER { get; set; } = new Dclgens.BILCOBER();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.CONVERSI CONVERSI { get; set; } = new Dclgens.CONVERSI();
        public Dclgens.HISCOBPR HISCOBPR { get; set; } = new Dclgens.HISCOBPR();
        public Dclgens.MOVIMCOB MOVIMCOB { get; set; } = new Dclgens.MOVIMCOB();
        public Dclgens.PESSOFIS PESSOFIS { get; set; } = new Dclgens.PESSOFIS();
        public Dclgens.PRODUVG PRODUVG { get; set; } = new Dclgens.PRODUVG();
        public Dclgens.PROPFID PROPFID { get; set; } = new Dclgens.PROPFID();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.RCAPS RCAPS { get; set; } = new Dclgens.RCAPS();
        public Dclgens.RCAPCOMP RCAPCOMP { get; set; } = new Dclgens.RCAPCOMP();
        public Dclgens.TERMOADE TERMOADE { get; set; } = new Dclgens.TERMOADE();
        public Dclgens.USUARIOS USUARIOS { get; set; } = new Dclgens.USUARIOS();
        public Dclgens.USUFILSE USUFILSE { get; set; } = new Dclgens.USUFILSE();
        public Dclgens.VG099 VG099 { get; set; } = new Dclgens.VG099();
        public Dclgens.VG101 VG101 { get; set; } = new Dclgens.VG101();
        public Dclgens.VG102 VG102 { get; set; } = new Dclgens.VG102();
        public Dclgens.VG103 VG103 { get; set; } = new Dclgens.VG103();
        public Dclgens.VG104 VG104 { get; set; } = new Dclgens.VG104();
        public Dclgens.VGSOLFAT VGSOLFAT { get; set; } = new Dclgens.VGSOLFAT();
        public SPBVG001_SPBVG001_VG001 SPBVG001_VG001 { get; set; } = new SPBVG001_SPBVG001_VG001();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(SPVG001W SPVG001W_P) //PROCEDURE DIVISION USING 
        /*PROCEDURE DIVISION
        LK_VG001_TRACE
        LK_VG001_TIPO_ACAO
        LK_VG001_NUM_CERTIFICADO
        LK_VG001_SEQ_CRITICA
        LK_VG001_IND_TP_PROPOSTA
        LK_VG001_NUM_CPF_CNPJ
        LK_VG001_COD_MSG_CRITICA
        LK_VG001_COD_USUARIO
        LK_VG001_NOM_PROGRAMA
        LK_VG001_STA_CRITICA
        LK_VG001_DES_COMPLEMENTAR
        LK_VG001_S_NUM_CERTIFICADO
        LK_VG001_S_SEQ_CRITICA
        LK_VG001_S_IND_TP_PROPOSTA
        LK_VG001_S_COD_MSG_CRITICA
        LK_VG001_S_DES_MSG_CRITICA
        LK_VG001_S_DES_ABREV_MSG_CRIT
        LK_VG001_S_NUM_CPF_CNPJ
        LK_VG001_S_NUM_PROPOSTA
        LK_VG001_S_VLR_IS
        LK_VG001_S_VLR_PREMIO
        LK_VG001_S_DTA_OCORRENCIA
        LK_VG001_S_DTA_RCAP
        LK_VG001_S_STA_CRITICA
        LK_VG001_S_DES_STA_CRITICA
        LK_VG001_S_DES_COMPLEMENTAR
        LK_VG001_S_COD_USUARIO
        LK_VG001_S_NOM_PROGRAMA
        LK_VG001_S_DTH_CADASTRAMENTO
        LK_VG001_S_STA_PARA
        LK_VG001_IND_ERRO
        LK_VG001_MSG_ERRO
        LK_VG001_NOM_TABELA
        LK_VG001_SQLCODE
        LK_VG001_SQLERRMC*/
        {
            try
            {
                this.SPVG001W = SPVG001W_P;

                /*" -0- FLUXCONTROL_PERFORM P0000-INICIALIZAR-SECTION */

                P0000_INICIALIZAR_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { SPVG001W };
            return Result;
        }

        [StopWatch]
        /*" P0000-INICIALIZAR-SECTION */
        private void P0000_INICIALIZAR_SECTION()
        {
            /*" -381- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -382- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -383- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -386- MOVE FUNCTION CURRENT-DATE(1:14) TO WS-C-DATE-CURRENT. */
            _.Move(_.CurrentDate(0, 14), WORK.WS_DATAS.WS_C_DATE_CURRENT);

            /*" -388- MOVE FUNCTION WHEN-COMPILED TO WS-C-DATE-COMPILED. */
            _.Move(_.WhenCompiled(), WORK.WS_DATAS.WS_C_DATE_COMPILED);

            /*" -388- MOVE ZEROS TO LK-RSGEWSTR-FUNCAO */
            _.Move(0, RSGEWSTR.LK_RSGEWSTR_FUNCAO);

            /*" -388- MOVE ZEROS TO LK-RSGEWSTR-INP-STR-LGTH */
            _.Move(0, RSGEWSTR.LK_RSGEWSTR_INP_STR.LK_RSGEWSTR_INP_STR_LGTH);

            /*" -388- MOVE SPACES TO LK-RSGEWSTR-INP-STR-DATA */
            _.Move("", RSGEWSTR.LK_RSGEWSTR_INP_STR.LK_RSGEWSTR_INP_STR_DATA);

            /*" -388- MOVE ZEROS TO LK-RSGEWSTR-INP-NUM-LGTH */
            _.Move(0, RSGEWSTR.LK_RSGEWSTR_INP_NUM.LK_RSGEWSTR_INP_NUM_LGTH);

            /*" -388- MOVE SPACES TO LK-RSGEWSTR-INP-NUM-DATA */
            _.Move("", RSGEWSTR.LK_RSGEWSTR_INP_NUM.LK_RSGEWSTR_INP_NUM_DATA);

            /*" -388- MOVE ZEROS TO LK-RSGEWSTR-IND-ERRO */
            _.Move(0, RSGEWSTR.LK_RSGEWSTR_IND_ERRO);

            /*" -388- MOVE ZEROS TO LK-RSGEWSTR-OUT-STR-LGTH */
            _.Move(0, RSGEWSTR.LK_RSGEWSTR_OUT_STR.LK_RSGEWSTR_OUT_STR_LGTH);

            /*" -388- MOVE SPACES TO LK-RSGEWSTR-OUT-STR-DATA */
            _.Move("", RSGEWSTR.LK_RSGEWSTR_OUT_STR.LK_RSGEWSTR_OUT_STR_DATA);

            /*" -388- MOVE ZEROS TO LK-RSGEWSTR-OUT-NUM-LGTH */
            _.Move(0, RSGEWSTR.LK_RSGEWSTR_OUT_NUM.LK_RSGEWSTR_OUT_NUM_LGTH);

            /*" -390- MOVE SPACES TO LK-RSGEWSTR-OUT-NUM-DATA */
            _.Move("", RSGEWSTR.LK_RSGEWSTR_OUT_NUM.LK_RSGEWSTR_OUT_NUM_DATA);

            /*" -408- INITIALIZE LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA */
            _.Initialize(
                SPVG001W.LK_VG001_S_NUM_CERTIFICADO
                , SPVG001W.LK_VG001_S_SEQ_CRITICA
                , SPVG001W.LK_VG001_S_IND_TP_PROPOSTA
                , SPVG001W.LK_VG001_S_COD_MSG_CRITICA
                , SPVG001W.LK_VG001_S_DES_MSG_CRITICA
                , SPVG001W.LK_VG001_S_DES_ABREV_MSG_CRIT
                , SPVG001W.LK_VG001_S_NUM_CPF_CNPJ
                , SPVG001W.LK_VG001_S_NUM_PROPOSTA
                , SPVG001W.LK_VG001_S_VLR_IS
                , SPVG001W.LK_VG001_S_VLR_PREMIO
                , SPVG001W.LK_VG001_S_STA_CRITICA
                , SPVG001W.LK_VG001_S_DES_STA_CRITICA
                , SPVG001W.LK_VG001_S_DES_COMPLEMENTAR
                , SPVG001W.LK_VG001_S_COD_USUARIO
                , SPVG001W.LK_VG001_S_NOM_PROGRAMA
                , SPVG001W.LK_VG001_S_DTH_CADASTRAMENTO
                , SPVG001W.LK_VG001_S_STA_PARA
            );

            /*" -413- INITIALIZE LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC WS-ERRO WH-AUXILIAR */
            _.Initialize(
                SPVG001W.LK_VG001_IND_ERRO
                , SPVG001W.LK_VG001_MSG_ERRO
                , SPVG001W.LK_VG001_NOM_TABELA
                , SPVG001W.LK_VG001_SQLCODE
                , SPVG001W.LK_VG001_SQLERRMC
                , WORK.WS_ERRO
                , WH_AUXILIAR
            );

            /*" -416- MOVE '1212-12-12' TO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP */
            _.Move("1212-12-12", SPVG001W.LK_VG001_S_DTA_OCORRENCIA, SPVG001W.LK_VG001_S_DTA_RCAP);

            /*" -417- IF NOT ( LK-VG001-TRACE = 'S' OR = 'N' ) */

            if (!(SPVG001W.LK_VG001_TRACE.In("S", "N")))
            {

                /*" -418- MOVE 'N' TO LK-VG001-TRACE */
                _.Move("N", SPVG001W.LK_VG001_TRACE);

                /*" -420- END-IF */
            }


            /*" -422- PERFORM P0050-VERIFICAR-SISTEMA */

            P0050_VERIFICAR_SISTEMA_SECTION();

            /*" -423- IF (LK-VG001-TRACE = 'S' ) */

            if ((SPVG001W.LK_VG001_TRACE == "S"))
            {

                /*" -424- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -425- DISPLAY '*            S P B V G 0 0 1                 *' */
                _.Display($"*            S P B V G 0 0 1                 *");

                /*" -426- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -433- DISPLAY '* DATA COMPILACAO..: ' WS-C-DATE-COMPILED(7:2) '/' WS-C-DATE-COMPILED(5:2) '/' WS-C-DATE-COMPILED(1:4) '-' WS-C-DATE-COMPILED(9:2) ':' WS-C-DATE-COMPILED(11:2) ':' WS-C-DATE-COMPILED(13:2) */

                $"* DATA COMPILACAO..: {WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(7, 2)}/{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(5, 2)}/{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(1, 4)}-{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(9, 2)}:{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(11, 2)}:{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(13, 2)}"
                .Display();

                /*" -440- DISPLAY '* DATA EXECUCAO....: ' WS-C-DATE-CURRENT(7:2) '/' WS-C-DATE-CURRENT(5:2) '/' WS-C-DATE-CURRENT(1:4) '-' WS-C-DATE-CURRENT(9:2) ':' WS-C-DATE-CURRENT(11:2) ':' WS-C-DATE-CURRENT(13:2) */

                $"* DATA EXECUCAO....: {WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(7, 2)}/{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(5, 2)}/{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(1, 4)}-{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(9, 2)}:{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(11, 2)}:{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(13, 2)}"
                .Display();

                /*" -444- DISPLAY '* DATA SISTEMA.....: ' SISTEMAS-DATA-MOV-ABERTO(9:2) '/' SISTEMAS-DATA-MOV-ABERTO(6:2) '/' SISTEMAS-DATA-MOV-ABERTO(1:4) */

                $"* DATA SISTEMA.....: {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2)}/{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2)}/{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4)}"
                .Display();

                /*" -445- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -446- DISPLAY '*          DADOS DE ENTRADA  SPBVG001        *' */
                _.Display($"*          DADOS DE ENTRADA  SPBVG001        *");

                /*" -447- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -448- DISPLAY '* TRACE............: ' LK-VG001-TRACE */
                _.Display($"* TRACE............: {SPVG001W.LK_VG001_TRACE}");

                /*" -449- MOVE LK-VG001-TIPO-ACAO TO WS-SMALLINT(01) */
                _.Move(SPVG001W.LK_VG001_TIPO_ACAO, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -450- DISPLAY '* TIPO-ACAO........: ' WS-SMALLINT(01) */
                _.Display($"* TIPO-ACAO........: {WORK.WS_EDIT.WS_SMALLINT[1]}");

                /*" -451- MOVE LK-VG001-NUM-CERTIFICADO TO WS-DECIMAL(01) */
                _.Move(SPVG001W.LK_VG001_NUM_CERTIFICADO, WORK.WS_EDIT.WS_DECIMAL[01]);

                /*" -452- DISPLAY '* NUM-CERTIFICADO..: ' WS-DECIMAL(01) */
                _.Display($"* NUM-CERTIFICADO..: {WORK.WS_EDIT.WS_DECIMAL[1]}");

                /*" -453- MOVE LK-VG001-SEQ-CRITICA TO WS-SMALLINT(01) */
                _.Move(SPVG001W.LK_VG001_SEQ_CRITICA, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -454- DISPLAY '* SEQ-CRITICA......: ' WS-SMALLINT(01) */
                _.Display($"* SEQ-CRITICA......: {WORK.WS_EDIT.WS_SMALLINT[1]}");

                /*" -455- DISPLAY '* IND-TP-PROPOSTA..: ' LK-VG001-IND-TP-PROPOSTA */
                _.Display($"* IND-TP-PROPOSTA..: {SPVG001W.LK_VG001_IND_TP_PROPOSTA}");

                /*" -456- MOVE LK-VG001-NUM-CPF-CNPJ TO WS-BIGINT(01) */
                _.Move(SPVG001W.LK_VG001_NUM_CPF_CNPJ, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -457- DISPLAY '* NUM-CPF-CNPJ.....: ' WS-BIGINT(01) */
                _.Display($"* NUM-CPF-CNPJ.....: {WORK.WS_EDIT.WS_BIGINT[1]}");

                /*" -458- MOVE LK-VG001-COD-MSG-CRITICA TO WS-SMALLINT(01) */
                _.Move(SPVG001W.LK_VG001_COD_MSG_CRITICA, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -459- DISPLAY '* COD-MSG-CRITICA..: ' WS-SMALLINT(01) */
                _.Display($"* COD-MSG-CRITICA..: {WORK.WS_EDIT.WS_SMALLINT[1]}");

                /*" -460- DISPLAY '* COD-USUARIO......: ' LK-VG001-COD-USUARIO */
                _.Display($"* COD-USUARIO......: {SPVG001W.LK_VG001_COD_USUARIO}");

                /*" -461- DISPLAY '* NOM-PROGRAMA.....: ' LK-VG001-NOM-PROGRAMA */
                _.Display($"* NOM-PROGRAMA.....: {SPVG001W.LK_VG001_NOM_PROGRAMA}");

                /*" -462- DISPLAY '* STA-CRITICA......: ' LK-VG001-STA-CRITICA */
                _.Display($"* STA-CRITICA......: {SPVG001W.LK_VG001_STA_CRITICA}");

                /*" -464- DISPLAY '* DES-COMPLEMENTAR.: ' LK-VG001-DES-COMPLEMENTAR(1:70) */
                _.Display($"* DES-COMPLEMENTAR.: LK-VG001-DES-COMPLEMENTAR(1:70)");

                /*" -465- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -467- END-IF */
            }


            /*" -467- PERFORM P0005-PROCESSAR. */

            P0005_PROCESSAR_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0000_99_EXIT*/

        [StopWatch]
        /*" P0005-PROCESSAR-SECTION */
        private void P0005_PROCESSAR_SECTION()
        {
            /*" -478- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0005_00_START */

            P0005_00_START();

        }

        [StopWatch]
        /*" P0005-00-START */
        private void P0005_00_START(bool isPerform = false)
        {
            /*" -480- MOVE 'P0005' TO WS-SECTION. */
            _.Move("P0005", WORK.WS_ERRO.WS_SECTION);

            /*" -480- PERFORM P0005-05-INICIO. */

            P0005_05_INICIO(true);

        }

        [StopWatch]
        /*" P0005-05-INICIO */
        private void P0005_05_INICIO(bool isPerform = false)
        {
            /*" -485- PERFORM P0100-VALIDAR-LINKAGE. */

            P0100_VALIDAR_LINKAGE_SECTION();

            /*" -487- MOVE 'P0005' TO WS-SECTION */
            _.Move("P0005", WORK.WS_ERRO.WS_SECTION);

            /*" -488-  EVALUATE TRUE  */

            /*" -490-  WHEN LK-VG001-TIPO-ACAO       = 01  */

            /*" -490- IF LK-VG001-TIPO-ACAO       = 01 */

            if (SPVG001W.LK_VG001_TIPO_ACAO == 01)
            {

                /*" -491- PERFORM P0301-TRATAR-TIPO-ACAO-01 */

                P0301_TRATAR_TIPO_ACAO_01_SECTION();

                /*" -493-  WHEN LK-VG001-TIPO-ACAO       = 02  */

                /*" -493- ELSE IF LK-VG001-TIPO-ACAO       = 02 */
            }
            else

            if (SPVG001W.LK_VG001_TIPO_ACAO == 02)
            {

                /*" -494- PERFORM P0302-TRATAR-TIPO-ACAO-02 */

                P0302_TRATAR_TIPO_ACAO_02_SECTION();

                /*" -496-  WHEN LK-VG001-TIPO-ACAO       = 03  */

                /*" -496- ELSE IF LK-VG001-TIPO-ACAO       = 03 */
            }
            else

            if (SPVG001W.LK_VG001_TIPO_ACAO == 03)
            {

                /*" -497- PERFORM P0303-TRATAR-TIPO-ACAO-03 */

                P0303_TRATAR_TIPO_ACAO_03_SECTION();

                /*" -500-  WHEN LK-VG001-TIPO-ACAO       = 04  */

                /*" -500- ELSE IF LK-VG001-TIPO-ACAO       = 04 */
            }
            else

            if (SPVG001W.LK_VG001_TIPO_ACAO == 04)
            {

                /*" -501- CONTINUE */

                /*" -504-  WHEN LK-VG001-TIPO-ACAO       = 05  */

                /*" -504- ELSE IF LK-VG001-TIPO-ACAO       = 05 */
            }
            else

            if (SPVG001W.LK_VG001_TIPO_ACAO == 05)
            {

                /*" -505- PERFORM P0305-TRATAR-TIPO-ACAO-05 */

                P0305_TRATAR_TIPO_ACAO_05_SECTION();

                /*" -508-  WHEN LK-VG001-TIPO-ACAO       = 06  */

                /*" -508- ELSE IF LK-VG001-TIPO-ACAO       = 06 */
            }
            else

            if (SPVG001W.LK_VG001_TIPO_ACAO == 06)
            {

                /*" -509- CONTINUE */

                /*" -512-  WHEN LK-VG001-TIPO-ACAO       = 07  */

                /*" -512- ELSE IF LK-VG001-TIPO-ACAO       = 07 */
            }
            else

            if (SPVG001W.LK_VG001_TIPO_ACAO == 07)
            {

                /*" -513- CONTINUE */

                /*" -515-  WHEN LK-VG001-TIPO-ACAO       = 08  */

                /*" -515- ELSE IF LK-VG001-TIPO-ACAO       = 08 */
            }
            else

            if (SPVG001W.LK_VG001_TIPO_ACAO == 08)
            {

                /*" -516- PERFORM P0308-TRATAR-TIPO-ACAO-08 */

                P0308_TRATAR_TIPO_ACAO_08_SECTION();

                /*" -517-  WHEN OTHER  */

                /*" -517- ELSE */
            }
            else
            {


                /*" -518- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -519- MOVE LK-VG001-TIPO-ACAO TO WS-SMALLINT(01) */
                _.Move(SPVG001W.LK_VG001_TIPO_ACAO, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -523- STRING WS-SECTION ' - TIPO DE ACAO INFORMADA INVALIDA.' ' TIPO_ACAO = ' WS-SMALLINT(01) DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl1 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl1 += " - TIPO DE ACAO INFORMADA INVALIDA.";
                spl1 += " TIPO_ACAO = ";
                var spl2 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                var results3 = spl1 + spl2;
                _.Move(results3, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -524- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -525- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -526- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -528-  END-EVALUATE  */

                /*" -528- END-IF */
            }


            /*" -528- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0005_99_EXIT*/

        [StopWatch]
        /*" P0010-FINALIZAR-SECTION */
        private void P0010_FINALIZAR_SECTION()
        {
            /*" -539- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0010_00_START */

            P0010_00_START();

        }

        [StopWatch]
        /*" P0010-00-START */
        private void P0010_00_START(bool isPerform = false)
        {
            /*" -540- MOVE 'P0010' TO WS-SECTION. */
            _.Move("P0010", WORK.WS_ERRO.WS_SECTION);

        }

        [StopWatch]
        /*" P0010-05-INICIO */
        private void P0010_05_INICIO(bool isPerform = false)
        {
            /*" -545- MOVE 0 TO WS-IND-ERRO */
            _.Move(0, WORK.WS_ERRO.WS_IND_ERRO);

            /*" -547- STRING 'OPERACAO SOLICITADA REALIZADA COM SUCESSO.' DELIMITED BY SIZE INTO WS-MENSAGEM */
            #region STRING
            var spl3 = "OPERACAO SOLICITADA REALIZADA COM SUCESSO.";
            _.Move(spl3, WORK.WS_ERRO.WS_MENSAGEM);
            #endregion

            /*" -548- MOVE WS-MENSAGEM TO LK-VG001-MSG-ERRO */
            _.Move(WORK.WS_ERRO.WS_MENSAGEM, SPVG001W.LK_VG001_MSG_ERRO);

            /*" -549- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
            _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

            /*" -551- MOVE 0 TO WS-SQLCODE */
            _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

            /*" -551- . */

        }

        [StopWatch]
        /*" P0010-99-EXIT */
        private void P0010_99_EXIT(bool isPerform = false)
        {
            /*" -554- GOBACK. */

            throw new GoBack();

        }

        [StopWatch]
        /*" P0050-VERIFICAR-SISTEMA-SECTION */
        private void P0050_VERIFICAR_SISTEMA_SECTION()
        {
            /*" -562- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0050_00_START */

            P0050_00_START();

        }

        [StopWatch]
        /*" P0050-00-START */
        private void P0050_00_START(bool isPerform = false)
        {
            /*" -566- MOVE 'P0050' TO WS-SECTION. */
            _.Move("P0050", WORK.WS_ERRO.WS_SECTION);

            /*" -566- PERFORM P0050-05-INICIO. */

            P0050_05_INICIO(true);

        }

        [StopWatch]
        /*" P0050-05-INICIO */
        private void P0050_05_INICIO(bool isPerform = false)
        {
            /*" -575- PERFORM P0050_05_INICIO_DB_SELECT_1 */

            P0050_05_INICIO_DB_SELECT_1();

            /*" -578- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -579- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -583- STRING WS-SECTION ' - ERRO NO SELECT NA SEGUROS.SISTEMA.' ' SISTEMA = VG ' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl4 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl4 += " - ERRO NO SELECT NA SEGUROS.SISTEMA.";
                spl4 += " SISTEMA = VG ";
                _.Move(spl4, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -584- MOVE 'SEGUROS.SISTEMA' TO WS-TABELA */
                _.Move("SEGUROS.SISTEMA", WORK.WS_ERRO.WS_TABELA);

                /*" -585- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -586- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -587- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -589- END-IF */
            }


            /*" -590- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -591- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -595- STRING WS-SECTION ' - REGISTRO DE CONTROLE SISTEMA NAO CADASTRADO.' ' SISTEMA = VG ' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl5 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl5 += " - REGISTRO DE CONTROLE SISTEMA NAO CADASTRADO.";
                spl5 += " SISTEMA = VG ";
                _.Move(spl5, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -596- MOVE 'SEGUROS.SISTEMA' TO WS-TABELA */
                _.Move("SEGUROS.SISTEMA", WORK.WS_ERRO.WS_TABELA);

                /*" -597- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -598- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -599- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -599- END-IF. */
            }


        }

        [StopWatch]
        /*" P0050-05-INICIO-DB-SELECT-1 */
        public void P0050_05_INICIO_DB_SELECT_1()
        {
            /*" -575- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VG' WITH UR END-EXEC. */

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
            /*" -610- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0100_00_START */

            P0100_00_START();

        }

        [StopWatch]
        /*" P0100-00-START */
        private void P0100_00_START(bool isPerform = false)
        {
            /*" -612- MOVE 'P0100' TO WS-SECTION. */
            _.Move("P0100", WORK.WS_ERRO.WS_SECTION);

            /*" -612- PERFORM P0100-05-INICIO. */

            P0100_05_INICIO(true);

        }

        [StopWatch]
        /*" P0100-05-INICIO */
        private void P0100_05_INICIO(bool isPerform = false)
        {
            /*" -617- IF LK-VG001-NUM-CERTIFICADO = 0 */

            if (SPVG001W.LK_VG001_NUM_CERTIFICADO == 0)
            {

                /*" -618- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -619- MOVE LK-VG001-NUM-CERTIFICADO TO WS-DECIMAL(01) */
                _.Move(SPVG001W.LK_VG001_NUM_CERTIFICADO, WORK.WS_EDIT.WS_DECIMAL[01]);

                /*" -623- STRING WS-SECTION ' - NUMERO DO CERTIFICADO NAO INFORMADO.' ' NUM_CERTIFICADO = ' WS-DECIMAL(01) DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl6 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl6 += " - NUMERO DO CERTIFICADO NAO INFORMADO.";
                spl6 += " NUM_CERTIFICADO = ";
                var spl7 = WORK.WS_EDIT.WS_DECIMAL[01].GetMoveValues();
                var results8 = spl6 + spl7;
                _.Move(results8, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -624- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -625- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -626- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -628- END-IF */
            }


            /*" -629- IF LK-VG001-COD-USUARIO = SPACES */

            if (SPVG001W.LK_VG001_COD_USUARIO.IsEmpty())
            {

                /*" -630- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -634- STRING WS-SECTION ' - CODIGO DO USUARIO NAO INFORMADO.' ' COD_USUARIO = ' LK-VG001-COD-USUARIO DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl8 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl8 += " - CODIGO DO USUARIO NAO INFORMADO.";
                spl8 += " COD_USUARIO = ";
                var spl9 = SPVG001W.LK_VG001_COD_USUARIO.GetMoveValues();
                var results10 = spl8 + spl9;
                _.Move(results10, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -635- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -636- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -637- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -639- END-IF */
            }


            /*" -640- IF LK-VG001-NOM-PROGRAMA = SPACES */

            if (SPVG001W.LK_VG001_NOM_PROGRAMA.IsEmpty())
            {

                /*" -641- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -645- STRING WS-SECTION ' - NOME DO PROGRAMA NAO INFORMADO.' ' NOM_PROGRAMA = ' LK-VG001-NOM-PROGRAMA DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl10 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl10 += " - NOME DO PROGRAMA NAO INFORMADO.";
                spl10 += " NOM_PROGRAMA = ";
                var spl11 = SPVG001W.LK_VG001_NOM_PROGRAMA.GetMoveValues();
                var results12 = spl10 + spl11;
                _.Move(results12, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -646- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -647- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -648- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -650- END-IF */
            }


            /*" -651- MOVE 1000 TO LK-RSGEWSTR-INP-STR-LGTH */
            _.Move(1000, RSGEWSTR.LK_RSGEWSTR_INP_STR.LK_RSGEWSTR_INP_STR_LGTH);

            /*" -652- MOVE LK-VG001-DES-COMPLEMENTAR-T TO LK-RSGEWSTR-INP-STR-DATA */
            _.Move(SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_T, RSGEWSTR.LK_RSGEWSTR_INP_STR.LK_RSGEWSTR_INP_STR_DATA);

            /*" -653- MOVE 7 TO LK-RSGEWSTR-FUNCAO */
            _.Move(7, RSGEWSTR.LK_RSGEWSTR_FUNCAO);

            /*" -654- MOVE 'RSGESSTR' TO WS-PROGRAMA */
            _.Move("RSGESSTR", WORK.WS_PROGRAMA);

            /*" -660- CALL WS-PROGRAMA USING LK-RSGEWSTR-FUNCAO LK-RSGEWSTR-INP-STR LK-RSGEWSTR-INP-NUM LK-RSGEWSTR-IND-ERRO LK-RSGEWSTR-OUT-STR LK-RSGEWSTR-OUT-NUM */
            _.Call(WORK.WS_PROGRAMA, RSGEWSTR);

            /*" -661- IF LK-RSGEWSTR-IND-ERRO NOT = 0 */

            if (RSGEWSTR.LK_RSGEWSTR_IND_ERRO != 0)
            {

                /*" -662- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -666- STRING WS-SECTION ' - CODIGO DO USUARIO NAO INFORMADO.' ' COD_USUARIO = ' LK-VG001-COD-USUARIO DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl12 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl12 += " - CODIGO DO USUARIO NAO INFORMADO.";
                spl12 += " COD_USUARIO = ";
                var spl13 = SPVG001W.LK_VG001_COD_USUARIO.GetMoveValues();
                var results14 = spl12 + spl13;
                _.Move(results14, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -667- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -668- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -669- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -671- END-IF */
            }


            /*" -673- MOVE LK-RSGEWSTR-OUT-STR-DATA TO WH-VG103-DES-COMPLEMENTAR-TEXT */
            _.Move(RSGEWSTR.LK_RSGEWSTR_OUT_STR.LK_RSGEWSTR_OUT_STR_DATA, WH_AUXILIAR.WH_VG103_DES_COMPLEMENTAR.WH_VG103_DES_COMPLEMENTAR_TEXT);

            /*" -677- MOVE LK-RSGEWSTR-OUT-STR-LGTH TO WH-VG103-DES-COMPLEMENTAR-LEN */
            _.Move(RSGEWSTR.LK_RSGEWSTR_OUT_STR.LK_RSGEWSTR_OUT_STR_LGTH, WH_AUXILIAR.WH_VG103_DES_COMPLEMENTAR.WH_VG103_DES_COMPLEMENTAR_LEN);

            /*" -678-  EVALUATE TRUE  */

            /*" -679-  WHEN LK-VG001-TIPO-ACAO      = 01  */

            /*" -679- IF LK-VG001-TIPO-ACAO      = 01 */

            if (SPVG001W.LK_VG001_TIPO_ACAO == 01)
            {

                /*" -680- IF LK-VG001-SEQ-CRITICA = 0 */

                if (SPVG001W.LK_VG001_SEQ_CRITICA == 0)
                {

                    /*" -681- MOVE 1 TO LK-VG001-SEQ-CRITICA */
                    _.Move(1, SPVG001W.LK_VG001_SEQ_CRITICA);

                    /*" -682- END-IF */
                }


                /*" -683-  WHEN LK-VG001-TIPO-ACAO      = 02  */

                /*" -683- ELSE IF LK-VG001-TIPO-ACAO      = 02 */
            }
            else

            if (SPVG001W.LK_VG001_TIPO_ACAO == 02)
            {

                /*" -686- IF NOT ( LK-VG001-IND-TP-PROPOSTA = 'BI' OR = 'MD' OR = 'PF' OR = 'PJ' ) */

                if (!(SPVG001W.LK_VG001_IND_TP_PROPOSTA.In("BI", "MD", "PF", "PJ")))
                {

                    /*" -687- MOVE 1 TO WS-IND-ERRO */
                    _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                    /*" -692- STRING WS-SECTION ' - TIPO DE PROPOSTA INVALIDA.' ' IND_TP_PROPOSTA = ' LK-VG001-IND-TP-PROPOSTA DELIMITED BY SIZE INTO WS-MENSAGEM */
                    #region STRING
                    var spl14 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                    spl14 += " - TIPO DE PROPOSTA INVALIDA.";
                    spl14 += " IND_TP_PROPOSTA = ";
                    var spl15 = SPVG001W.LK_VG001_IND_TP_PROPOSTA.GetMoveValues();
                    var results16 = spl14 + spl15;
                    _.Move(results16, WORK.WS_ERRO.WS_MENSAGEM);
                    #endregion

                    /*" -693- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                    _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                    /*" -694- MOVE 0 TO WS-SQLCODE */
                    _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                    /*" -695- GO TO P9999-ERRO */

                    P9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -696- END-IF */
                }


                /*" -697- PERFORM P0120-VALIDAR-MSG-CRITICA */

                P0120_VALIDAR_MSG_CRITICA_SECTION();

                /*" -700- PERFORM P0131-VERIFICAR-JA-CADASTRADO */

                P0131_VERIFICAR_JA_CADASTRADO_SECTION();

                /*" -701- IF WS-IND-ERRO = 1 */

                if (WORK.WS_ERRO.WS_IND_ERRO == 1)
                {

                    /*" -702- GO TO P9999-ERRO */

                    P9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -703- END-IF */
                }


                /*" -704-  WHEN LK-VG001-TIPO-ACAO      = 03 OR = 04  */

                /*" -704- ELSE IF LK-VG001-TIPO-ACAO      = 03 OR = 04 */
            }
            else

            if (SPVG001W.LK_VG001_TIPO_ACAO.In("03", "04"))
            {

                /*" -705- IF LK-VG001-SEQ-CRITICA = 0 */

                if (SPVG001W.LK_VG001_SEQ_CRITICA == 0)
                {

                    /*" -706- MOVE 1 TO WS-IND-ERRO */
                    _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                    /*" -708- MOVE LK-VG001-NUM-CERTIFICADO TO WS-DECIMAL(01) */
                    _.Move(SPVG001W.LK_VG001_NUM_CERTIFICADO, WORK.WS_EDIT.WS_DECIMAL[01]);

                    /*" -713- STRING WS-SECTION ' - SEQUENCIA DA CRITICA A SER TRATADA ' 'NAO INFORMADA. NUM_CERTIFICADO = ' WS-DECIMAL(01) DELIMITED BY SIZE INTO WS-MENSAGEM */
                    #region STRING
                    var spl16 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                    spl16 += " - SEQUENCIA DA CRITICA A SER TRATADA ";
                    spl16 += "NAO INFORMADA. NUM_CERTIFICADO = ";
                    var spl17 = WORK.WS_EDIT.WS_DECIMAL[01].GetMoveValues();
                    var results18 = spl16 + spl17;
                    _.Move(results18, WORK.WS_ERRO.WS_MENSAGEM);
                    #endregion

                    /*" -714- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                    _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                    /*" -715- MOVE 0 TO WS-SQLCODE */
                    _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                    /*" -716- GO TO P9999-ERRO */

                    P9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -717- END-IF */
                }


                /*" -718- PERFORM P0130-PESQUISAR-CERTIFICADO */

                P0130_PESQUISAR_CERTIFICADO_SECTION();

                /*" -719- PERFORM P0121-VALIDAR-STA-CRITICA */

                P0121_VALIDAR_STA_CRITICA_SECTION();

                /*" -720- IF LK-VG001-COD-USUARIO NOT = 'BATCH' */

                if (SPVG001W.LK_VG001_COD_USUARIO != "BATCH")
                {

                    /*" -721- PERFORM P0122-VALIDAR-TROCA-STATUS */

                    P0122_VALIDAR_TROCA_STATUS_SECTION();

                    /*" -722- PERFORM P0110-VALIDAR-USUARIO */

                    P0110_VALIDAR_USUARIO_SECTION();

                    /*" -723- PERFORM P0111-VALIDAR-USUFIL-SENHA */

                    P0111_VALIDAR_USUFIL_SENHA_SECTION();

                    /*" -724- PERFORM P0112-VALIDAR-STATUS-ALCADA */

                    P0112_VALIDAR_STATUS_ALCADA_SECTION();

                    /*" -725- END-IF */
                }


                /*" -726-  WHEN LK-VG001-TIPO-ACAO      = 05  */

                /*" -726- ELSE IF LK-VG001-TIPO-ACAO      = 05 */
            }
            else

            if (SPVG001W.LK_VG001_TIPO_ACAO == 05)
            {

                /*" -727- IF LK-VG001-COD-USUARIO NOT = 'BATCH' */

                if (SPVG001W.LK_VG001_COD_USUARIO != "BATCH")
                {

                    /*" -728- IF LK-VG001-SEQ-CRITICA = 0 */

                    if (SPVG001W.LK_VG001_SEQ_CRITICA == 0)
                    {

                        /*" -729- MOVE 1 TO WS-IND-ERRO */
                        _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                        /*" -731- MOVE LK-VG001-NUM-CERTIFICADO TO WS-DECIMAL(01) */
                        _.Move(SPVG001W.LK_VG001_NUM_CERTIFICADO, WORK.WS_EDIT.WS_DECIMAL[01]);

                        /*" -736- STRING WS-SECTION ' - SEQUENCIA DA CRITICA A SER TRATADA ' 'NAO INFORMADA. NUM_CERTIFICADO = ' WS-DECIMAL(01) DELIMITED BY SIZE INTO WS-MENSAGEM */
                        #region STRING
                        var spl18 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                        spl18 += " - SEQUENCIA DA CRITICA A SER TRATADA ";
                        spl18 += "NAO INFORMADA. NUM_CERTIFICADO = ";
                        var spl19 = WORK.WS_EDIT.WS_DECIMAL[01].GetMoveValues();
                        var results20 = spl18 + spl19;
                        _.Move(results20, WORK.WS_ERRO.WS_MENSAGEM);
                        #endregion

                        /*" -737- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                        _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                        /*" -738- MOVE 0 TO WS-SQLCODE */
                        _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                        /*" -739- GO TO P9999-ERRO */

                        P9999_ERRO_SECTION(); //GOTO
                        return;

                        /*" -740- END-IF */
                    }


                    /*" -741- END-IF */
                }


                /*" -742- PERFORM P0110-VALIDAR-USUARIO */

                P0110_VALIDAR_USUARIO_SECTION();

                /*" -743- PERFORM P0111-VALIDAR-USUFIL-SENHA */

                P0111_VALIDAR_USUFIL_SENHA_SECTION();

                /*" -744- PERFORM P0130-PESQUISAR-CERTIFICADO */

                P0130_PESQUISAR_CERTIFICADO_SECTION();

                /*" -745-  WHEN LK-VG001-TIPO-ACAO      = 06  */

                /*" -745- ELSE IF LK-VG001-TIPO-ACAO      = 06 */
            }
            else

            if (SPVG001W.LK_VG001_TIPO_ACAO == 06)
            {

                /*" -746- IF LK-VG001-COD-MSG-CRITICA = 0 */

                if (SPVG001W.LK_VG001_COD_MSG_CRITICA == 0)
                {

                    /*" -747- MOVE 1 TO WS-IND-ERRO */
                    _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                    /*" -749- MOVE LK-VG001-NUM-CERTIFICADO TO WS-DECIMAL(01) */
                    _.Move(SPVG001W.LK_VG001_NUM_CERTIFICADO, WORK.WS_EDIT.WS_DECIMAL[01]);

                    /*" -751- MOVE LK-VG001-COD-MSG-CRITICA TO WS-SMALLINT(01) */
                    _.Move(SPVG001W.LK_VG001_COD_MSG_CRITICA, WORK.WS_EDIT.WS_SMALLINT[01]);

                    /*" -757- STRING WS-SECTION ' - INFORMAR CODIGO DA MENSAGEM DE CRITICA' 'A PESQUISAR. NUM_CERTIFICADO = ' WS-DECIMAL(01) ' COD_MSG_CRITICA = ' WS-SMALLINT(01) DELIMITED BY SIZE INTO WS-MENSAGEM */
                    #region STRING
                    var spl20 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                    spl20 += " - INFORMAR CODIGO DA MENSAGEM DE CRITICA";
                    spl20 += "A PESQUISAR. NUM_CERTIFICADO = ";
                    var spl21 = WORK.WS_EDIT.WS_DECIMAL[01].GetMoveValues();
                    spl21 += " COD_MSG_CRITICA = ";
                    var spl22 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                    var results23 = spl20 + spl21 + spl22;
                    _.Move(results23, WORK.WS_ERRO.WS_MENSAGEM);
                    #endregion

                    /*" -758- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                    _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                    /*" -759- MOVE 0 TO WS-SQLCODE */
                    _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                    /*" -760- GO TO P9999-ERRO */

                    P9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -761- END-IF */
                }


                /*" -767- PERFORM P0131-VERIFICAR-JA-CADASTRADO */

                P0131_VERIFICAR_JA_CADASTRADO_SECTION();

                /*" -768- IF WS-IND-ERRO = 1 */

                if (WORK.WS_ERRO.WS_IND_ERRO == 1)
                {

                    /*" -769- MOVE 0 TO WS-IND-ERRO */
                    _.Move(0, WORK.WS_ERRO.WS_IND_ERRO);

                    /*" -770- END-IF */
                }


                /*" -771-  WHEN LK-VG001-TIPO-ACAO      = 07  */

                /*" -771- ELSE IF LK-VG001-TIPO-ACAO      = 07 */
            }
            else

            if (SPVG001W.LK_VG001_TIPO_ACAO == 07)
            {

                /*" -772- IF LK-VG001-COD-MSG-CRITICA = 0 */

                if (SPVG001W.LK_VG001_COD_MSG_CRITICA == 0)
                {

                    /*" -773- MOVE 1 TO WS-IND-ERRO */
                    _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                    /*" -775- MOVE LK-VG001-NUM-CERTIFICADO TO WS-DECIMAL(01) */
                    _.Move(SPVG001W.LK_VG001_NUM_CERTIFICADO, WORK.WS_EDIT.WS_DECIMAL[01]);

                    /*" -777- MOVE LK-VG001-COD-MSG-CRITICA TO WS-SMALLINT(01) */
                    _.Move(SPVG001W.LK_VG001_COD_MSG_CRITICA, WORK.WS_EDIT.WS_SMALLINT[01]);

                    /*" -783- STRING WS-SECTION ' - INFORMAR CODIGO DA MENSAGEM DE CRITICA' 'A PESQUISAR. NUM_CERTIFICADO = ' WS-DECIMAL(01) ' COD_MSG_CRITICA = ' WS-SMALLINT(01) DELIMITED BY SIZE INTO WS-MENSAGEM */
                    #region STRING
                    var spl23 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                    spl23 += " - INFORMAR CODIGO DA MENSAGEM DE CRITICA";
                    spl23 += "A PESQUISAR. NUM_CERTIFICADO = ";
                    var spl24 = WORK.WS_EDIT.WS_DECIMAL[01].GetMoveValues();
                    spl24 += " COD_MSG_CRITICA = ";
                    var spl25 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                    var results26 = spl23 + spl24 + spl25;
                    _.Move(results26, WORK.WS_ERRO.WS_MENSAGEM);
                    #endregion

                    /*" -784- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                    _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                    /*" -785- MOVE 0 TO WS-SQLCODE */
                    _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                    /*" -786- GO TO P9999-ERRO */

                    P9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -787- END-IF */
                }


                /*" -793- PERFORM P0132-VERIFICAR-QQ-STATUS-CAD */

                P0132_VERIFICAR_QQ_STATUS_CAD_SECTION();

                /*" -794- IF WS-IND-ERRO = 1 */

                if (WORK.WS_ERRO.WS_IND_ERRO == 1)
                {

                    /*" -795- MOVE 0 TO WS-IND-ERRO */
                    _.Move(0, WORK.WS_ERRO.WS_IND_ERRO);

                    /*" -796- END-IF */
                }


                /*" -797-  WHEN LK-VG001-TIPO-ACAO      = 08  */

                /*" -797- ELSE IF LK-VG001-TIPO-ACAO      = 08 */
            }
            else

            if (SPVG001W.LK_VG001_TIPO_ACAO == 08)
            {

                /*" -798- IF LK-VG001-SEQ-CRITICA = 0 */

                if (SPVG001W.LK_VG001_SEQ_CRITICA == 0)
                {

                    /*" -799- MOVE 1 TO WS-IND-ERRO */
                    _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                    /*" -801- MOVE LK-VG001-NUM-CERTIFICADO TO WS-DECIMAL(01) */
                    _.Move(SPVG001W.LK_VG001_NUM_CERTIFICADO, WORK.WS_EDIT.WS_DECIMAL[01]);

                    /*" -806- STRING WS-SECTION ' - SEQUENCIA DA CRITICA A SER TRATADA ' 'NAO INFORMADA. NUM_CERTIFICADO = ' WS-DECIMAL(01) DELIMITED BY SIZE INTO WS-MENSAGEM */
                    #region STRING
                    var spl26 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                    spl26 += " - SEQUENCIA DA CRITICA A SER TRATADA ";
                    spl26 += "NAO INFORMADA. NUM_CERTIFICADO = ";
                    var spl27 = WORK.WS_EDIT.WS_DECIMAL[01].GetMoveValues();
                    var results28 = spl26 + spl27;
                    _.Move(results28, WORK.WS_ERRO.WS_MENSAGEM);
                    #endregion

                    /*" -807- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                    _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                    /*" -808- MOVE 0 TO WS-SQLCODE */
                    _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                    /*" -809- GO TO P9999-ERRO */

                    P9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -810- END-IF */
                }


                /*" -811- PERFORM P0130-PESQUISAR-CERTIFICADO */

                P0130_PESQUISAR_CERTIFICADO_SECTION();

                /*" -812- PERFORM P0121-VALIDAR-STA-CRITICA */

                P0121_VALIDAR_STA_CRITICA_SECTION();

                /*" -813-  WHEN OTHER  */

                /*" -813- ELSE */
            }
            else
            {


                /*" -814- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -815- MOVE LK-VG001-TIPO-ACAO TO WS-SMALLINT(01) */
                _.Move(SPVG001W.LK_VG001_TIPO_ACAO, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -819- STRING WS-SECTION ' - TIPO DE ACAO INFORMADA INVALIDA.' ' TIPO_ACAO = ' WS-SMALLINT(01) DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl28 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl28 += " - TIPO DE ACAO INFORMADA INVALIDA.";
                spl28 += " TIPO_ACAO = ";
                var spl29 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                var results30 = spl28 + spl29;
                _.Move(results30, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -820- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -821- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -822- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -824-  END-EVALUATE  */

                /*" -824- END-IF */
            }


            /*" -824- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0100_99_EXIT*/

        [StopWatch]
        /*" P0110-VALIDAR-USUARIO-SECTION */
        private void P0110_VALIDAR_USUARIO_SECTION()
        {
            /*" -835- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0110_00_START */

            P0110_00_START();

        }

        [StopWatch]
        /*" P0110-00-START */
        private void P0110_00_START(bool isPerform = false)
        {
            /*" -838- MOVE 'P0110' TO WS-SECTION. */
            _.Move("P0110", WORK.WS_ERRO.WS_SECTION);

            /*" -838- MOVE LK-VG001-COD-USUARIO TO USUARIOS-COD-USUARIO. */
            _.Move(SPVG001W.LK_VG001_COD_USUARIO, USUARIOS.DCLUSUARIOS.USUARIOS_COD_USUARIO);

        }

        [StopWatch]
        /*" P0110-05-INICIO */
        private void P0110_05_INICIO(bool isPerform = false)
        {
            /*" -847- PERFORM P0110_05_INICIO_DB_SELECT_1 */

            P0110_05_INICIO_DB_SELECT_1();

            /*" -850- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -851- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -855- STRING WS-SECTION ' - ERRO NO SELECT SEGUROS.USUARIOS.' ' COD_USUARIO = ' USUARIOS-COD-USUARIO DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl30 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl30 += " - ERRO NO SELECT SEGUROS.USUARIOS.";
                spl30 += " COD_USUARIO = ";
                var spl31 = USUARIOS.DCLUSUARIOS.USUARIOS_COD_USUARIO.GetMoveValues();
                var results32 = spl30 + spl31;
                _.Move(results32, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -856- MOVE 'SEGUROS.USUARIOS' TO WS-TABELA */
                _.Move("SEGUROS.USUARIOS", WORK.WS_ERRO.WS_TABELA);

                /*" -857- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -858- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -859- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -861- END-IF */
            }


            /*" -862- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -863- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -867- STRING WS-SECTION ' - CODIGO DO USUARIO NAO CADASTRADO.' ' COD_USUARIO = ' USUARIOS-COD-USUARIO DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl32 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl32 += " - CODIGO DO USUARIO NAO CADASTRADO.";
                spl32 += " COD_USUARIO = ";
                var spl33 = USUARIOS.DCLUSUARIOS.USUARIOS_COD_USUARIO.GetMoveValues();
                var results34 = spl32 + spl33;
                _.Move(results34, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -868- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -869- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -870- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -872- END-IF */
            }


            /*" -872- . */

        }

        [StopWatch]
        /*" P0110-05-INICIO-DB-SELECT-1 */
        public void P0110_05_INICIO_DB_SELECT_1()
        {
            /*" -847- EXEC SQL SELECT COD_USUARIO INTO :USUARIOS-COD-USUARIO FROM SEGUROS.USUARIOS WHERE COD_USUARIO = :USUARIOS-COD-USUARIO END-EXEC */

            var p0110_05_INICIO_DB_SELECT_1_Query1 = new P0110_05_INICIO_DB_SELECT_1_Query1()
            {
                USUARIOS_COD_USUARIO = USUARIOS.DCLUSUARIOS.USUARIOS_COD_USUARIO.ToString(),
            };

            var executed_1 = P0110_05_INICIO_DB_SELECT_1_Query1.Execute(p0110_05_INICIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.USUARIOS_COD_USUARIO, USUARIOS.DCLUSUARIOS.USUARIOS_COD_USUARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0110_99_EXIT*/

        [StopWatch]
        /*" P0111-VALIDAR-USUFIL-SENHA-SECTION */
        private void P0111_VALIDAR_USUFIL_SENHA_SECTION()
        {
            /*" -883- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0111_00_START */

            P0111_00_START();

        }

        [StopWatch]
        /*" P0111-00-START */
        private void P0111_00_START(bool isPerform = false)
        {
            /*" -886- MOVE 'P0111' TO WS-SECTION. */
            _.Move("P0111", WORK.WS_ERRO.WS_SECTION);

            /*" -886- MOVE LK-VG001-COD-USUARIO TO USUFILSE-CODUSU. */
            _.Move(SPVG001W.LK_VG001_COD_USUARIO, USUFILSE.DCLUSU_FIL_SENHA.USUFILSE_CODUSU);

        }

        [StopWatch]
        /*" P0111-05-INICIO */
        private void P0111_05_INICIO(bool isPerform = false)
        {
            /*" -902- PERFORM P0111_05_INICIO_DB_SELECT_1 */

            P0111_05_INICIO_DB_SELECT_1();

            /*" -905- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -906- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -910- STRING WS-SECTION ' - ERRO NO SELECT SEGUROS.USU_FIL_SENHA.' ' COD_USUARIO = ' USUFILSE-CODUSU DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl34 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl34 += " - ERRO NO SELECT SEGUROS.USU_FIL_SENHA.";
                spl34 += " COD_USUARIO = ";
                var spl35 = USUFILSE.DCLUSU_FIL_SENHA.USUFILSE_CODUSU.GetMoveValues();
                var results36 = spl34 + spl35;
                _.Move(results36, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -911- MOVE 'SEGUROS.USU_FIL_SENHA' TO WS-TABELA */
                _.Move("SEGUROS.USU_FIL_SENHA", WORK.WS_ERRO.WS_TABELA);

                /*" -912- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -913- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -914- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -916- END-IF */
            }


            /*" -917- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -918- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -922- STRING WS-SECTION ' - USUARIO NAO AUTORIZADO PARA TRATAMENTO DE CRI' 'TICA DO VIDA. COD_USUARIO = ' USUARIOS-COD-USUARIO DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl36 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl36 += " - USUARIO NAO AUTORIZADO PARA TRATAMENTO DE CRI";
                spl36 += "TICA DO VIDA. COD_USUARIO = ";
                var spl37 = USUARIOS.DCLUSUARIOS.USUARIOS_COD_USUARIO.GetMoveValues();
                var results38 = spl36 + spl37;
                _.Move(results38, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -923- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -924- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -925- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -927- END-IF */
            }


            /*" -927- . */

        }

        [StopWatch]
        /*" P0111-05-INICIO-DB-SELECT-1 */
        public void P0111_05_INICIO_DB_SELECT_1()
        {
            /*" -902- EXEC SQL SELECT COD_CO ,SENHA ,NIVEL_AUTORIZACAO ,TIPO_FUNCAO INTO :USUFILSE-COD-CO ,:USUFILSE-SENHA ,:USUFILSE-NIVEL-AUTORIZACAO ,:USUFILSE-TIPO-FUNCAO FROM SEGUROS.USU_FIL_SENHA WHERE CODUSU = :USUFILSE-CODUSU AND ( TIPO_FUNCAO = 'CRITICA VIDA' ) END-EXEC */

            var p0111_05_INICIO_DB_SELECT_1_Query1 = new P0111_05_INICIO_DB_SELECT_1_Query1()
            {
                USUFILSE_CODUSU = USUFILSE.DCLUSU_FIL_SENHA.USUFILSE_CODUSU.ToString(),
            };

            var executed_1 = P0111_05_INICIO_DB_SELECT_1_Query1.Execute(p0111_05_INICIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.USUFILSE_COD_CO, USUFILSE.DCLUSU_FIL_SENHA.USUFILSE_COD_CO);
                _.Move(executed_1.USUFILSE_SENHA, USUFILSE.DCLUSU_FIL_SENHA.USUFILSE_SENHA);
                _.Move(executed_1.USUFILSE_NIVEL_AUTORIZACAO, USUFILSE.DCLUSU_FIL_SENHA.USUFILSE_NIVEL_AUTORIZACAO);
                _.Move(executed_1.USUFILSE_TIPO_FUNCAO, USUFILSE.DCLUSU_FIL_SENHA.USUFILSE_TIPO_FUNCAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0111_99_EXIT*/

        [StopWatch]
        /*" P0112-VALIDAR-STATUS-ALCADA-SECTION */
        private void P0112_VALIDAR_STATUS_ALCADA_SECTION()
        {
            /*" -938- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0112_00_START */

            P0112_00_START();

        }

        [StopWatch]
        /*" P0112-00-START */
        private void P0112_00_START(bool isPerform = false)
        {
            /*" -941- MOVE 'P0112' TO WS-SECTION. */
            _.Move("P0112", WORK.WS_ERRO.WS_SECTION);

            /*" -942- MOVE LK-VG001-STA-CRITICA TO VG101-STA-CRITICA */
            _.Move(SPVG001W.LK_VG001_STA_CRITICA, VG101.DCLVG_RELAC_STATUS_ALCADA.VG101_STA_CRITICA);

            /*" -943- MOVE USUFILSE-TIPO-FUNCAO TO VG101-COD-TIPO-FUNCAO */
            _.Move(USUFILSE.DCLUSU_FIL_SENHA.USUFILSE_TIPO_FUNCAO, VG101.DCLVG_RELAC_STATUS_ALCADA.VG101_COD_TIPO_FUNCAO);

            /*" -946- MOVE USUFILSE-NIVEL-AUTORIZACAO TO VG101-COD-NIVEL-AUTORIZACAO */
            _.Move(USUFILSE.DCLUSU_FIL_SENHA.USUFILSE_NIVEL_AUTORIZACAO, VG101.DCLVG_RELAC_STATUS_ALCADA.VG101_COD_NIVEL_AUTORIZACAO);

            /*" -946- . */

        }

        [StopWatch]
        /*" P0112-05-INICIO */
        private void P0112_05_INICIO(bool isPerform = false)
        {
            /*" -958- PERFORM P0112_05_INICIO_DB_SELECT_1 */

            P0112_05_INICIO_DB_SELECT_1();

            /*" -961- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -962- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -963- MOVE VG102-COD-MSG-CRITICA TO WS-SMALLINT(01) */
                _.Move(VG102.DCLVG_DM_MSG_CRITICA.VG102_COD_MSG_CRITICA, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -970- STRING WS-SECTION ' - ERRO NO SELECT SEGUROS.VG_RELAC_STATUS_ALCADA.' ' COD_USUARIO = ' LK-VG001-COD-USUARIO '/STA_CRITICA = ' VG101-STA-CRITICA '/COD_TIPO_FUNCAO = ' VG101-COD-TIPO-FUNCAO '/NIVEL_AUTORIZACAO = ' VG101-COD-NIVEL-AUTORIZACAO DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl38 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl38 += " - ERRO NO SELECT SEGUROS.VG_RELAC_STATUS_ALCADA.";
                spl38 += " COD_USUARIO = ";
                var spl39 = SPVG001W.LK_VG001_COD_USUARIO.GetMoveValues();
                spl39 += "/STA_CRITICA = ";
                var spl40 = VG101.DCLVG_RELAC_STATUS_ALCADA.VG101_STA_CRITICA.GetMoveValues();
                spl40 += "/COD_TIPO_FUNCAO = ";
                var spl41 = VG101.DCLVG_RELAC_STATUS_ALCADA.VG101_COD_TIPO_FUNCAO.GetMoveValues();
                spl41 += "/NIVEL_AUTORIZACAO = ";
                var spl42 = VG101.DCLVG_RELAC_STATUS_ALCADA.VG101_COD_NIVEL_AUTORIZACAO.GetMoveValues();
                var results43 = spl38 + spl39 + spl40 + spl41 + spl42;
                _.Move(results43, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -972- MOVE 'SEGUROS.VG_RELAC_STATUS_ALCADA' TO WS-TABELA */
                _.Move("SEGUROS.VG_RELAC_STATUS_ALCADA", WORK.WS_ERRO.WS_TABELA);

                /*" -973- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -974- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -975- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -977- END-IF */
            }


            /*" -978- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -979- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -980- MOVE VG102-COD-MSG-CRITICA TO WS-SMALLINT(01) */
                _.Move(VG102.DCLVG_DM_MSG_CRITICA.VG102_COD_MSG_CRITICA, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -988- STRING WS-SECTION ' - USUARIO NAO POSSUI ALCADA PARA MUDANCA A ESTE ' 'STATUS.' ' COD_USUARIO = ' LK-VG001-COD-USUARIO '/STA_CRITICA = ' VG101-STA-CRITICA '/COD_TIPO_FUNCAO = ' VG101-COD-TIPO-FUNCAO '/NIVEL_AUTORIZACAO = ' VG101-COD-NIVEL-AUTORIZACAO DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl43 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl43 += " - USUARIO NAO POSSUI ALCADA PARA MUDANCA A ESTE ";
                spl43 += "STATUS.";
                spl43 += " COD_USUARIO = ";
                var spl44 = SPVG001W.LK_VG001_COD_USUARIO.GetMoveValues();
                spl44 += "/STA_CRITICA = ";
                var spl45 = VG101.DCLVG_RELAC_STATUS_ALCADA.VG101_STA_CRITICA.GetMoveValues();
                spl45 += "/COD_TIPO_FUNCAO = ";
                var spl46 = VG101.DCLVG_RELAC_STATUS_ALCADA.VG101_COD_TIPO_FUNCAO.GetMoveValues();
                spl46 += "/NIVEL_AUTORIZACAO = ";
                var spl47 = VG101.DCLVG_RELAC_STATUS_ALCADA.VG101_COD_NIVEL_AUTORIZACAO.GetMoveValues();
                var results48 = spl43 + spl44 + spl45 + spl46 + spl47;
                _.Move(results48, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -989- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -990- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -991- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -993- END-IF */
            }


            /*" -993- . */

        }

        [StopWatch]
        /*" P0112-05-INICIO-DB-SELECT-1 */
        public void P0112_05_INICIO_DB_SELECT_1()
        {
            /*" -958- EXEC SQL SELECT VG101.STA_CRITICA INTO :VG101-STA-CRITICA FROM SEGUROS.VG_RELAC_STATUS_ALCADA VG101 WHERE VG101.STA_CRITICA = :VG101-STA-CRITICA AND VG101.COD_TIPO_FUNCAO = :VG101-COD-TIPO-FUNCAO AND VG101.COD_NIVEL_AUTORIZACAO = :VG101-COD-NIVEL-AUTORIZACAO END-EXEC */

            var p0112_05_INICIO_DB_SELECT_1_Query1 = new P0112_05_INICIO_DB_SELECT_1_Query1()
            {
                VG101_COD_NIVEL_AUTORIZACAO = VG101.DCLVG_RELAC_STATUS_ALCADA.VG101_COD_NIVEL_AUTORIZACAO.ToString(),
                VG101_COD_TIPO_FUNCAO = VG101.DCLVG_RELAC_STATUS_ALCADA.VG101_COD_TIPO_FUNCAO.ToString(),
                VG101_STA_CRITICA = VG101.DCLVG_RELAC_STATUS_ALCADA.VG101_STA_CRITICA.ToString(),
            };

            var executed_1 = P0112_05_INICIO_DB_SELECT_1_Query1.Execute(p0112_05_INICIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VG101_STA_CRITICA, VG101.DCLVG_RELAC_STATUS_ALCADA.VG101_STA_CRITICA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0112_99_EXIT*/

        [StopWatch]
        /*" P0120-VALIDAR-MSG-CRITICA-SECTION */
        private void P0120_VALIDAR_MSG_CRITICA_SECTION()
        {
            /*" -1004- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0120_00_START */

            P0120_00_START();

        }

        [StopWatch]
        /*" P0120-00-START */
        private void P0120_00_START(bool isPerform = false)
        {
            /*" -1007- MOVE 'P0120' TO WS-SECTION. */
            _.Move("P0120", WORK.WS_ERRO.WS_SECTION);

            /*" -1009- MOVE LK-VG001-COD-MSG-CRITICA TO VG102-COD-MSG-CRITICA */
            _.Move(SPVG001W.LK_VG001_COD_MSG_CRITICA, VG102.DCLVG_DM_MSG_CRITICA.VG102_COD_MSG_CRITICA);

            /*" -1009- PERFORM P0120-05-INICIO. */

            P0120_05_INICIO(true);

        }

        [StopWatch]
        /*" P0120-05-INICIO */
        private void P0120_05_INICIO(bool isPerform = false)
        {
            /*" -1020- PERFORM P0120_05_INICIO_DB_SELECT_1 */

            P0120_05_INICIO_DB_SELECT_1();

            /*" -1023- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -1024- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -1025- MOVE VG102-COD-MSG-CRITICA TO WS-SMALLINT(01) */
                _.Move(VG102.DCLVG_DM_MSG_CRITICA.VG102_COD_MSG_CRITICA, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -1029- STRING WS-SECTION ' - ERRO NO SELECT SEGUROS.VG_DM_MSG_CRITICA.' ' COD_MSG_CRITICA = ' WS-SMALLINT(01) DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl48 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl48 += " - ERRO NO SELECT SEGUROS.VG_DM_MSG_CRITICA.";
                spl48 += " COD_MSG_CRITICA = ";
                var spl49 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                var results50 = spl48 + spl49;
                _.Move(results50, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -1031- MOVE 'SEGUROS.VG_DM_MSG_CRITICA' TO WS-TABELA */
                _.Move("SEGUROS.VG_DM_MSG_CRITICA", WORK.WS_ERRO.WS_TABELA);

                /*" -1032- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -1033- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -1034- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1036- END-IF */
            }


            /*" -1037- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1038- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -1039- MOVE VG102-COD-MSG-CRITICA TO WS-SMALLINT(01) */
                _.Move(VG102.DCLVG_DM_MSG_CRITICA.VG102_COD_MSG_CRITICA, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -1043- STRING WS-SECTION ' - CODIGO DA MENSAGEM DE CRITICA NAO CADASTRADO.' ' COD_MSG_CRITICA = ' WS-SMALLINT(01) DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl50 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl50 += " - CODIGO DA MENSAGEM DE CRITICA NAO CADASTRADO.";
                spl50 += " COD_MSG_CRITICA = ";
                var spl51 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                var results52 = spl50 + spl51;
                _.Move(results52, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -1044- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -1045- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -1046- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1048- END-IF */
            }


            /*" -1048- . */

        }

        [StopWatch]
        /*" P0120-05-INICIO-DB-SELECT-1 */
        public void P0120_05_INICIO_DB_SELECT_1()
        {
            /*" -1020- EXEC SQL SELECT VG102.DES_ABREV_MSG_CRITICA ,VG102.COD_TP_MSG_CRITICA INTO :VG102-DES-ABREV-MSG-CRITICA ,:VG102-COD-TP-MSG-CRITICA FROM SEGUROS.VG_DM_MSG_CRITICA VG102 WHERE VG102.COD_MSG_CRITICA = :VG102-COD-MSG-CRITICA END-EXEC */

            var p0120_05_INICIO_DB_SELECT_1_Query1 = new P0120_05_INICIO_DB_SELECT_1_Query1()
            {
                VG102_COD_MSG_CRITICA = VG102.DCLVG_DM_MSG_CRITICA.VG102_COD_MSG_CRITICA.ToString(),
            };

            var executed_1 = P0120_05_INICIO_DB_SELECT_1_Query1.Execute(p0120_05_INICIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VG102_DES_ABREV_MSG_CRITICA, VG102.DCLVG_DM_MSG_CRITICA.VG102_DES_ABREV_MSG_CRITICA);
                _.Move(executed_1.VG102_COD_TP_MSG_CRITICA, VG102.DCLVG_DM_MSG_CRITICA.VG102_COD_TP_MSG_CRITICA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0120_99_EXIT*/

        [StopWatch]
        /*" P0121-VALIDAR-STA-CRITICA-SECTION */
        private void P0121_VALIDAR_STA_CRITICA_SECTION()
        {
            /*" -1059- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0121_00_START */

            P0121_00_START();

        }

        [StopWatch]
        /*" P0121-00-START */
        private void P0121_00_START(bool isPerform = false)
        {
            /*" -1062- MOVE 'P0121' TO WS-SECTION. */
            _.Move("P0121", WORK.WS_ERRO.WS_SECTION);

            /*" -1064- MOVE LK-VG001-STA-CRITICA TO VG099-STA-CRITICA */
            _.Move(SPVG001W.LK_VG001_STA_CRITICA, VG099.DCLVG_DM_STA_CRITICA.VG099_STA_CRITICA);

            /*" -1064- . */

        }

        [StopWatch]
        /*" P0121-05-INICIO */
        private void P0121_05_INICIO(bool isPerform = false)
        {
            /*" -1073- PERFORM P0121_05_INICIO_DB_SELECT_1 */

            P0121_05_INICIO_DB_SELECT_1();

            /*" -1076- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -1077- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -1081- STRING WS-SECTION ' - ERRO NO SELECT SEGUROS.VG_DM_STA_CRITICA.' ' STA_CRITICA = ' VG099-STA-CRITICA DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl52 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl52 += " - ERRO NO SELECT SEGUROS.VG_DM_STA_CRITICA.";
                spl52 += " STA_CRITICA = ";
                var spl53 = VG099.DCLVG_DM_STA_CRITICA.VG099_STA_CRITICA.GetMoveValues();
                var results54 = spl52 + spl53;
                _.Move(results54, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -1083- MOVE 'SEGUROS.VG_DM_STA_CRITICA' TO WS-TABELA */
                _.Move("SEGUROS.VG_DM_STA_CRITICA", WORK.WS_ERRO.WS_TABELA);

                /*" -1084- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -1085- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -1086- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1088- END-IF */
            }


            /*" -1089- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1090- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -1094- STRING WS-SECTION ' - STATUS DE CRITICA NAO CADASTRADO.' ' STA_CRITICA = ' VG099-STA-CRITICA DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl54 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl54 += " - STATUS DE CRITICA NAO CADASTRADO.";
                spl54 += " STA_CRITICA = ";
                var spl55 = VG099.DCLVG_DM_STA_CRITICA.VG099_STA_CRITICA.GetMoveValues();
                var results56 = spl54 + spl55;
                _.Move(results56, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -1095- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -1096- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -1097- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1099- END-IF */
            }


            /*" -1099- . */

        }

        [StopWatch]
        /*" P0121-05-INICIO-DB-SELECT-1 */
        public void P0121_05_INICIO_DB_SELECT_1()
        {
            /*" -1073- EXEC SQL SELECT VG099.DES_STA_CRITICA INTO :VG099-DES-STA-CRITICA FROM SEGUROS.VG_DM_STA_CRITICA VG099 WHERE VG099.STA_CRITICA = :VG099-STA-CRITICA END-EXEC */

            var p0121_05_INICIO_DB_SELECT_1_Query1 = new P0121_05_INICIO_DB_SELECT_1_Query1()
            {
                VG099_STA_CRITICA = VG099.DCLVG_DM_STA_CRITICA.VG099_STA_CRITICA.ToString(),
            };

            var executed_1 = P0121_05_INICIO_DB_SELECT_1_Query1.Execute(p0121_05_INICIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VG099_DES_STA_CRITICA, VG099.DCLVG_DM_STA_CRITICA.VG099_DES_STA_CRITICA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0121_99_EXIT*/

        [StopWatch]
        /*" P0122-VALIDAR-TROCA-STATUS-SECTION */
        private void P0122_VALIDAR_TROCA_STATUS_SECTION()
        {
            /*" -1110- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0122_00_START */

            P0122_00_START();

        }

        [StopWatch]
        /*" P0122-00-START */
        private void P0122_00_START(bool isPerform = false)
        {
            /*" -1113- MOVE 'P0122' TO WS-SECTION. */
            _.Move("P0122", WORK.WS_ERRO.WS_SECTION);

            /*" -1114- MOVE 0 TO WS-I WS-J */
            _.Move(0, WORK.WS_CONTADORES.WS_I, WORK.WS_CONTADORES.WS_J);

            /*" -1116- MOVE 'N' TO WS-IND-STATUS */
            _.Move("N", WORK.WS_INDICADORES.WS_IND_STATUS);

            /*" -1116- . */

        }

        [StopWatch]
        /*" P0122-05-INICIO */
        private void P0122_05_INICIO(bool isPerform = false)
        {
            /*" -1122- PERFORM VARYING WS-I FROM 1 BY 1 UNTIL WS-I > VG001-ARR-STA-I OR INDSTATUSSIM */

            for (WORK.WS_CONTADORES.WS_I.Value = 1; !(WORK.WS_CONTADORES.WS_I > SPVG001X.VG001.VG001_ARR_STA_I || WORK.WS_INDICADORES.WS_IND_STATUS["INDSTATUSSIM"]); WORK.WS_CONTADORES.WS_I.Value += 1)
            {

                /*" -1123- IF VG001-ARR-STA-STATUS-DE(WS-I) = VG103-STA-CRITICA */

                if (SPVG001X.VG001.FILLER.VG001_ARR_STA_OCCURS[WORK.WS_CONTADORES.WS_I].VG001_ARR_STA_STATUS_DE == VG103.DCLVG_CRITICA_PROPOSTA.VG103_STA_CRITICA)
                {

                    /*" -1125- PERFORM VARYING WS-J FROM 1 BY 1 UNTIL WS-J > VG001-ARR-STA-J OR INDSTATUSSIM */

                    for (WORK.WS_CONTADORES.WS_J.Value = 1; !(WORK.WS_CONTADORES.WS_J > SPVG001X.VG001.VG001_ARR_STA_J || WORK.WS_INDICADORES.WS_IND_STATUS["INDSTATUSSIM"]); WORK.WS_CONTADORES.WS_J.Value += 1)
                    {

                        /*" -1127- IF VG001-ARR-STA-STATUS-PARA(WS-I, WS-J) = LK-VG001-STA-CRITICA */

                        if (SPVG001X.VG001.FILLER.VG001_ARR_STA_OCCURS[WORK.WS_CONTADORES.WS_I].VG001_ARR_STA_PARA.VG001_ARR_STA_STATUS_PARA[WORK.WS_CONTADORES.WS_J] == SPVG001W.LK_VG001_STA_CRITICA)
                        {

                            /*" -1128- MOVE 'S' TO WS-IND-STATUS */
                            _.Move("S", WORK.WS_INDICADORES.WS_IND_STATUS);

                            /*" -1129- END-IF */
                        }


                        /*" -1130- END-PERFORM */
                    }

                    /*" -1131- END-IF */
                }


                /*" -1133- END-PERFORM */
            }

            /*" -1134- IF INDSTATUSNAO */

            if (WORK.WS_INDICADORES.WS_IND_STATUS["INDSTATUSNAO"])
            {

                /*" -1135- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -1139- STRING WS-SECTION ' - NAO PERMITIDO MUDAR O STATUS DE CRITCA DE ' VG103-STA-CRITICA ' PARA ' LK-VG001-STA-CRITICA DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl56 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl56 += " - NAO PERMITIDO MUDAR O STATUS DE CRITCA DE ";
                var spl57 = VG103.DCLVG_CRITICA_PROPOSTA.VG103_STA_CRITICA.GetMoveValues();
                spl57 += " PARA ";
                var spl58 = SPVG001W.LK_VG001_STA_CRITICA.GetMoveValues();
                var results59 = spl56 + spl57 + spl58;
                _.Move(results59, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -1140- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -1141- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -1142- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1144- END-IF */
            }


            /*" -1144- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0122_99_EXIT*/

        [StopWatch]
        /*" P0130-PESQUISAR-CERTIFICADO-SECTION */
        private void P0130_PESQUISAR_CERTIFICADO_SECTION()
        {
            /*" -1156- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0130_00_START */

            P0130_00_START();

        }

        [StopWatch]
        /*" P0130-00-START */
        private void P0130_00_START(bool isPerform = false)
        {
            /*" -1159- MOVE 'P0130' TO WS-SECTION */
            _.Move("P0130", WORK.WS_ERRO.WS_SECTION);

            /*" -1160- MOVE LK-VG001-NUM-CERTIFICADO TO VG103-NUM-CERTIFICADO */
            _.Move(SPVG001W.LK_VG001_NUM_CERTIFICADO, VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CERTIFICADO);

            /*" -1162- MOVE LK-VG001-SEQ-CRITICA TO VG103-SEQ-CRITICA */
            _.Move(SPVG001W.LK_VG001_SEQ_CRITICA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_SEQ_CRITICA);

            /*" -1162- . */

        }

        [StopWatch]
        /*" P0130-05-INICIO */
        private void P0130_05_INICIO(bool isPerform = false)
        {
            /*" -1212- PERFORM P0130_05_INICIO_DB_SELECT_1 */

            P0130_05_INICIO_DB_SELECT_1();

            /*" -1215- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -1216- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -1217- MOVE VG103-NUM-CERTIFICADO TO WS-DECIMAL(01) */
                _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CERTIFICADO, WORK.WS_EDIT.WS_DECIMAL[01]);

                /*" -1218- MOVE VG103-SEQ-CRITICA TO WS-SMALLINT(01) */
                _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_SEQ_CRITICA, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -1223- STRING WS-SECTION ' - ERRO NO SELECT SEGUROS.VG_CRITICA_PROPOSTA.' ' NUM_CERTIFICADO = ' WS-DECIMAL(01) ' SEQ_CRITICA = ' WS-SMALLINT(01) DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl59 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl59 += " - ERRO NO SELECT SEGUROS.VG_CRITICA_PROPOSTA.";
                spl59 += " NUM_CERTIFICADO = ";
                var spl60 = WORK.WS_EDIT.WS_DECIMAL[01].GetMoveValues();
                spl60 += " SEQ_CRITICA = ";
                var spl61 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                var results62 = spl59 + spl60 + spl61;
                _.Move(results62, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -1225- MOVE 'SEGUROS.VG_CRITICA_PROPOSTA' TO WS-TABELA */
                _.Move("SEGUROS.VG_CRITICA_PROPOSTA", WORK.WS_ERRO.WS_TABELA);

                /*" -1226- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -1227- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -1228- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1230- END-IF. */
            }


            /*" -1231- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1232- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -1233- MOVE VG103-NUM-CERTIFICADO TO WS-DECIMAL(01) */
                _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CERTIFICADO, WORK.WS_EDIT.WS_DECIMAL[01]);

                /*" -1234- MOVE VG103-SEQ-CRITICA TO WS-SMALLINT(01) */
                _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_SEQ_CRITICA, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -1239- STRING WS-SECTION ' - CERTIFICADO/SEQUENCIA NAO CADASTRADO.' ' NUM_CERTIFICADO = ' WS-DECIMAL(01) ' SEQ_CRITICA = ' WS-SMALLINT(01) DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl62 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl62 += " - CERTIFICADO/SEQUENCIA NAO CADASTRADO.";
                spl62 += " NUM_CERTIFICADO = ";
                var spl63 = WORK.WS_EDIT.WS_DECIMAL[01].GetMoveValues();
                spl63 += " SEQ_CRITICA = ";
                var spl64 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                var results65 = spl62 + spl63 + spl64;
                _.Move(results65, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -1241- MOVE 'SEGUROS.VG_CRITICA_PROPOSTA' TO WS-TABELA */
                _.Move("SEGUROS.VG_CRITICA_PROPOSTA", WORK.WS_ERRO.WS_TABELA);

                /*" -1242- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -1243- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -1244- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1246- END-IF */
            }


            /*" -1247- MOVE VG103-NUM-CERTIFICADO TO LK-VG001-S-NUM-CERTIFICADO */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CERTIFICADO, SPVG001W.LK_VG001_S_NUM_CERTIFICADO);

            /*" -1248- MOVE VG103-SEQ-CRITICA TO LK-VG001-S-SEQ-CRITICA */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_SEQ_CRITICA, SPVG001W.LK_VG001_S_SEQ_CRITICA);

            /*" -1249- MOVE VG103-IND-TP-PROPOSTA TO LK-VG001-S-IND-TP-PROPOSTA */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_IND_TP_PROPOSTA, SPVG001W.LK_VG001_S_IND_TP_PROPOSTA);

            /*" -1250- MOVE VG103-COD-MSG-CRITICA TO LK-VG001-S-COD-MSG-CRITICA */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_COD_MSG_CRITICA, SPVG001W.LK_VG001_S_COD_MSG_CRITICA);

            /*" -1252- MOVE VG102-DES-MSG-CRITICA-TEXT(1:VG102-DES-MSG-CRITICA-LEN) TO LK-VG001-S-DES-MSG-CRITICA */
            _.Move(VG102.DCLVG_DM_MSG_CRITICA.VG102_DES_MSG_CRITICA.VG102_DES_MSG_CRITICA_TEXT.Substring(1, VG102.DCLVG_DM_MSG_CRITICA.VG102_DES_MSG_CRITICA.VG102_DES_MSG_CRITICA_LEN), SPVG001W.LK_VG001_S_DES_MSG_CRITICA);

            /*" -1254- MOVE VG102-DES-ABREV-MSG-CRITICA TO LK-VG001-S-DES-ABREV-MSG-CRIT */
            _.Move(VG102.DCLVG_DM_MSG_CRITICA.VG102_DES_ABREV_MSG_CRITICA, SPVG001W.LK_VG001_S_DES_ABREV_MSG_CRIT);

            /*" -1255- MOVE VG103-NUM-CPF-CNPJ TO LK-VG001-S-NUM-CPF-CNPJ */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CPF_CNPJ, SPVG001W.LK_VG001_S_NUM_CPF_CNPJ);

            /*" -1256- MOVE VG103-NUM-PROPOSTA TO LK-VG001-S-NUM-PROPOSTA */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_PROPOSTA, SPVG001W.LK_VG001_S_NUM_PROPOSTA);

            /*" -1257- MOVE VG103-VLR-IS TO LK-VG001-S-VLR-IS */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_VLR_IS, SPVG001W.LK_VG001_S_VLR_IS);

            /*" -1258- MOVE VG103-VLR-PREMIO TO LK-VG001-S-VLR-PREMIO */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_VLR_PREMIO, SPVG001W.LK_VG001_S_VLR_PREMIO);

            /*" -1259- MOVE VG103-DTA-OCORRENCIA TO LK-VG001-S-DTA-OCORRENCIA */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_DTA_OCORRENCIA, SPVG001W.LK_VG001_S_DTA_OCORRENCIA);

            /*" -1260- MOVE VG103-DTA-RCAP TO LK-VG001-S-DTA-RCAP */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_DTA_RCAP, SPVG001W.LK_VG001_S_DTA_RCAP);

            /*" -1261- MOVE VG103-STA-CRITICA TO LK-VG001-S-STA-CRITICA */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_STA_CRITICA, SPVG001W.LK_VG001_S_STA_CRITICA);

            /*" -1263- MOVE VG099-DES-STA-CRITICA-TEXT(1:VG099-DES-STA-CRITICA-LEN) TO LK-VG001-S-DES-STA-CRITICA */
            _.Move(VG099.DCLVG_DM_STA_CRITICA.VG099_DES_STA_CRITICA.VG099_DES_STA_CRITICA_TEXT.Substring(1, VG099.DCLVG_DM_STA_CRITICA.VG099_DES_STA_CRITICA.VG099_DES_STA_CRITICA_LEN), SPVG001W.LK_VG001_S_DES_STA_CRITICA);

            /*" -1264- MOVE VG103-DES-COMPLEMENTAR TO LK-VG001-S-DES-COMPLEMENTAR */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_DES_COMPLEMENTAR, SPVG001W.LK_VG001_S_DES_COMPLEMENTAR);

            /*" -1265- MOVE VG103-COD-USUARIO TO LK-VG001-S-COD-USUARIO */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_COD_USUARIO, SPVG001W.LK_VG001_S_COD_USUARIO);

            /*" -1266- MOVE VG103-NOM-PROGRAMA TO LK-VG001-S-NOM-PROGRAMA */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_NOM_PROGRAMA, SPVG001W.LK_VG001_S_NOM_PROGRAMA);

            /*" -1268- MOVE VG103-DTH-CADASTRAMENTO TO LK-VG001-S-DTH-CADASTRAMENTO */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_DTH_CADASTRAMENTO, SPVG001W.LK_VG001_S_DTH_CADASTRAMENTO);

            /*" -1268- . */

        }

        [StopWatch]
        /*" P0130-05-INICIO-DB-SELECT-1 */
        public void P0130_05_INICIO_DB_SELECT_1()
        {
            /*" -1212- EXEC SQL SELECT VG103.NUM_CERTIFICADO ,VG103.SEQ_CRITICA ,VG103.IND_TP_PROPOSTA ,VG103.COD_MSG_CRITICA ,VG102.DES_MSG_CRITICA ,VG102.DES_ABREV_MSG_CRITICA ,VG103.NUM_CPF_CNPJ ,VALUE(VG103.NUM_PROPOSTA,0) ,VG103.VLR_IS ,VG103.VLR_PREMIO ,VG103.DTA_OCORRENCIA ,VG103.DTA_RCAP ,VG103.STA_CRITICA ,VG099.DES_STA_CRITICA ,VALUE(VG103.DES_COMPLEMENTAR, ' ' ) ,VG103.COD_USUARIO ,VG103.NOM_PROGRAMA ,CHAR(VG103.DTH_CADASTRAMENTO) ,VG102.IND_ALCADA INTO :VG103-NUM-CERTIFICADO ,:VG103-SEQ-CRITICA ,:VG103-IND-TP-PROPOSTA ,:VG103-COD-MSG-CRITICA ,:VG102-DES-MSG-CRITICA ,:VG102-DES-ABREV-MSG-CRITICA ,:VG103-NUM-CPF-CNPJ ,:VG103-NUM-PROPOSTA ,:VG103-VLR-IS ,:VG103-VLR-PREMIO ,:VG103-DTA-OCORRENCIA ,:VG103-DTA-RCAP ,:VG103-STA-CRITICA ,:VG099-DES-STA-CRITICA ,:VG103-DES-COMPLEMENTAR ,:VG103-COD-USUARIO ,:VG103-NOM-PROGRAMA ,:VG103-DTH-CADASTRAMENTO ,:VG102-IND-ALCADA FROM SEGUROS.VG_CRITICA_PROPOSTA VG103 ,SEGUROS.VG_DM_STA_CRITICA VG099 ,SEGUROS.VG_DM_MSG_CRITICA VG102 WHERE VG103.NUM_CERTIFICADO = :VG103-NUM-CERTIFICADO AND VG103.SEQ_CRITICA = :VG103-SEQ-CRITICA AND VG099.STA_CRITICA = VG103.STA_CRITICA AND VG102.COD_MSG_CRITICA = VG103.COD_MSG_CRITICA END-EXEC */

            var p0130_05_INICIO_DB_SELECT_1_Query1 = new P0130_05_INICIO_DB_SELECT_1_Query1()
            {
                VG103_NUM_CERTIFICADO = VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CERTIFICADO.ToString(),
                VG103_SEQ_CRITICA = VG103.DCLVG_CRITICA_PROPOSTA.VG103_SEQ_CRITICA.ToString(),
            };

            var executed_1 = P0130_05_INICIO_DB_SELECT_1_Query1.Execute(p0130_05_INICIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VG103_NUM_CERTIFICADO, VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CERTIFICADO);
                _.Move(executed_1.VG103_SEQ_CRITICA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_SEQ_CRITICA);
                _.Move(executed_1.VG103_IND_TP_PROPOSTA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_IND_TP_PROPOSTA);
                _.Move(executed_1.VG103_COD_MSG_CRITICA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_COD_MSG_CRITICA);
                _.Move(executed_1.VG102_DES_MSG_CRITICA, VG102.DCLVG_DM_MSG_CRITICA.VG102_DES_MSG_CRITICA);
                _.Move(executed_1.VG102_DES_ABREV_MSG_CRITICA, VG102.DCLVG_DM_MSG_CRITICA.VG102_DES_ABREV_MSG_CRITICA);
                _.Move(executed_1.VG103_NUM_CPF_CNPJ, VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CPF_CNPJ);
                _.Move(executed_1.VG103_NUM_PROPOSTA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_PROPOSTA);
                _.Move(executed_1.VG103_VLR_IS, VG103.DCLVG_CRITICA_PROPOSTA.VG103_VLR_IS);
                _.Move(executed_1.VG103_VLR_PREMIO, VG103.DCLVG_CRITICA_PROPOSTA.VG103_VLR_PREMIO);
                _.Move(executed_1.VG103_DTA_OCORRENCIA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_DTA_OCORRENCIA);
                _.Move(executed_1.VG103_DTA_RCAP, VG103.DCLVG_CRITICA_PROPOSTA.VG103_DTA_RCAP);
                _.Move(executed_1.VG103_STA_CRITICA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_STA_CRITICA);
                _.Move(executed_1.VG099_DES_STA_CRITICA, VG099.DCLVG_DM_STA_CRITICA.VG099_DES_STA_CRITICA);
                _.Move(executed_1.VG103_DES_COMPLEMENTAR, VG103.DCLVG_CRITICA_PROPOSTA.VG103_DES_COMPLEMENTAR);
                _.Move(executed_1.VG103_COD_USUARIO, VG103.DCLVG_CRITICA_PROPOSTA.VG103_COD_USUARIO);
                _.Move(executed_1.VG103_NOM_PROGRAMA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_NOM_PROGRAMA);
                _.Move(executed_1.VG103_DTH_CADASTRAMENTO, VG103.DCLVG_CRITICA_PROPOSTA.VG103_DTH_CADASTRAMENTO);
                _.Move(executed_1.VG102_IND_ALCADA, VG102.DCLVG_DM_MSG_CRITICA.VG102_IND_ALCADA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0130_99_EXIT*/

        [StopWatch]
        /*" P0131-VERIFICAR-JA-CADASTRADO-SECTION */
        private void P0131_VERIFICAR_JA_CADASTRADO_SECTION()
        {
            /*" -1280- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0131_00_START */

            P0131_00_START();

        }

        [StopWatch]
        /*" P0131-00-START */
        private void P0131_00_START(bool isPerform = false)
        {
            /*" -1283- MOVE 'P0131' TO WS-SECTION */
            _.Move("P0131", WORK.WS_ERRO.WS_SECTION);

            /*" -1284- MOVE LK-VG001-NUM-CERTIFICADO TO VG103-NUM-CERTIFICADO */
            _.Move(SPVG001W.LK_VG001_NUM_CERTIFICADO, VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CERTIFICADO);

            /*" -1286- MOVE LK-VG001-COD-MSG-CRITICA TO VG103-COD-MSG-CRITICA */
            _.Move(SPVG001W.LK_VG001_COD_MSG_CRITICA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_COD_MSG_CRITICA);

            /*" -1286- . */

        }

        [StopWatch]
        /*" P0131-05-INICIO */
        private void P0131_05_INICIO(bool isPerform = false)
        {
            /*" -1338- PERFORM P0131_05_INICIO_DB_SELECT_1 */

            P0131_05_INICIO_DB_SELECT_1();

            /*" -1341- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -1342- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -1343- MOVE VG103-NUM-CERTIFICADO TO WS-DECIMAL(01) */
                _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CERTIFICADO, WORK.WS_EDIT.WS_DECIMAL[01]);

                /*" -1344- MOVE VG103-COD-MSG-CRITICA TO WS-SMALLINT(01) */
                _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_COD_MSG_CRITICA, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -1349- STRING WS-SECTION ' - ERRO NO SELECT SEGUROS.VG_CRITICA_PROPOSTA.' ' NUM_CERTIFICADO = ' WS-DECIMAL(01) ' COD_MSG_CRITICA = ' WS-SMALLINT(01) DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl65 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl65 += " - ERRO NO SELECT SEGUROS.VG_CRITICA_PROPOSTA.";
                spl65 += " NUM_CERTIFICADO = ";
                var spl66 = WORK.WS_EDIT.WS_DECIMAL[01].GetMoveValues();
                spl66 += " COD_MSG_CRITICA = ";
                var spl67 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                var results68 = spl65 + spl66 + spl67;
                _.Move(results68, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -1351- MOVE 'SEGUROS.VG_CRITICA_PROPOSTA' TO WS-TABELA */
                _.Move("SEGUROS.VG_CRITICA_PROPOSTA", WORK.WS_ERRO.WS_TABELA);

                /*" -1352- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -1353- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -1354- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1356- END-IF. */
            }


            /*" -1357- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1358- GO TO P0131-99-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P0131_99_EXIT*/ //GOTO
                return;

                /*" -1360- END-IF */
            }


            /*" -1361- MOVE VG103-NUM-CERTIFICADO TO LK-VG001-S-NUM-CERTIFICADO */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CERTIFICADO, SPVG001W.LK_VG001_S_NUM_CERTIFICADO);

            /*" -1362- MOVE VG103-SEQ-CRITICA TO LK-VG001-S-SEQ-CRITICA */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_SEQ_CRITICA, SPVG001W.LK_VG001_S_SEQ_CRITICA);

            /*" -1363- MOVE VG103-IND-TP-PROPOSTA TO LK-VG001-S-IND-TP-PROPOSTA */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_IND_TP_PROPOSTA, SPVG001W.LK_VG001_S_IND_TP_PROPOSTA);

            /*" -1364- MOVE VG103-COD-MSG-CRITICA TO LK-VG001-S-COD-MSG-CRITICA */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_COD_MSG_CRITICA, SPVG001W.LK_VG001_S_COD_MSG_CRITICA);

            /*" -1366- MOVE VG102-DES-MSG-CRITICA-TEXT(1:VG102-DES-MSG-CRITICA-LEN) TO LK-VG001-S-DES-MSG-CRITICA */
            _.Move(VG102.DCLVG_DM_MSG_CRITICA.VG102_DES_MSG_CRITICA.VG102_DES_MSG_CRITICA_TEXT.Substring(1, VG102.DCLVG_DM_MSG_CRITICA.VG102_DES_MSG_CRITICA.VG102_DES_MSG_CRITICA_LEN), SPVG001W.LK_VG001_S_DES_MSG_CRITICA);

            /*" -1368- MOVE VG102-DES-ABREV-MSG-CRITICA TO LK-VG001-S-DES-ABREV-MSG-CRIT */
            _.Move(VG102.DCLVG_DM_MSG_CRITICA.VG102_DES_ABREV_MSG_CRITICA, SPVG001W.LK_VG001_S_DES_ABREV_MSG_CRIT);

            /*" -1369- MOVE VG103-NUM-CPF-CNPJ TO LK-VG001-S-NUM-CPF-CNPJ */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CPF_CNPJ, SPVG001W.LK_VG001_S_NUM_CPF_CNPJ);

            /*" -1370- MOVE VG103-NUM-PROPOSTA TO LK-VG001-S-NUM-PROPOSTA */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_PROPOSTA, SPVG001W.LK_VG001_S_NUM_PROPOSTA);

            /*" -1371- MOVE VG103-VLR-IS TO LK-VG001-S-VLR-IS */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_VLR_IS, SPVG001W.LK_VG001_S_VLR_IS);

            /*" -1372- MOVE VG103-VLR-PREMIO TO LK-VG001-S-VLR-PREMIO */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_VLR_PREMIO, SPVG001W.LK_VG001_S_VLR_PREMIO);

            /*" -1373- MOVE VG103-DTA-OCORRENCIA TO LK-VG001-S-DTA-OCORRENCIA */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_DTA_OCORRENCIA, SPVG001W.LK_VG001_S_DTA_OCORRENCIA);

            /*" -1374- MOVE VG103-DTA-RCAP TO LK-VG001-S-DTA-RCAP */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_DTA_RCAP, SPVG001W.LK_VG001_S_DTA_RCAP);

            /*" -1375- MOVE VG103-STA-CRITICA TO LK-VG001-S-STA-CRITICA */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_STA_CRITICA, SPVG001W.LK_VG001_S_STA_CRITICA);

            /*" -1377- MOVE VG099-DES-STA-CRITICA-TEXT(1:VG099-DES-STA-CRITICA-LEN) TO LK-VG001-S-DES-STA-CRITICA */
            _.Move(VG099.DCLVG_DM_STA_CRITICA.VG099_DES_STA_CRITICA.VG099_DES_STA_CRITICA_TEXT.Substring(1, VG099.DCLVG_DM_STA_CRITICA.VG099_DES_STA_CRITICA.VG099_DES_STA_CRITICA_LEN), SPVG001W.LK_VG001_S_DES_STA_CRITICA);

            /*" -1378- MOVE VG103-DES-COMPLEMENTAR TO LK-VG001-S-DES-COMPLEMENTAR */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_DES_COMPLEMENTAR, SPVG001W.LK_VG001_S_DES_COMPLEMENTAR);

            /*" -1379- MOVE VG103-COD-USUARIO TO LK-VG001-S-COD-USUARIO */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_COD_USUARIO, SPVG001W.LK_VG001_S_COD_USUARIO);

            /*" -1380- MOVE VG103-NOM-PROGRAMA TO LK-VG001-S-NOM-PROGRAMA */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_NOM_PROGRAMA, SPVG001W.LK_VG001_S_NOM_PROGRAMA);

            /*" -1382- MOVE VG103-DTH-CADASTRAMENTO TO LK-VG001-S-DTH-CADASTRAMENTO */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_DTH_CADASTRAMENTO, SPVG001W.LK_VG001_S_DTH_CADASTRAMENTO);

            /*" -1383- MOVE 1 TO WS-IND-ERRO */
            _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

            /*" -1384- MOVE VG103-NUM-CERTIFICADO TO WS-DECIMAL(01) */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CERTIFICADO, WORK.WS_EDIT.WS_DECIMAL[01]);

            /*" -1385- MOVE VG103-COD-MSG-CRITICA TO WS-SMALLINT(01) */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_COD_MSG_CRITICA, WORK.WS_EDIT.WS_SMALLINT[01]);

            /*" -1390- STRING WS-SECTION ' - CERTIFICADO/COD-MSG-CRITICA JA CADASTRADO.' ' NUM_CERTIFICADO = ' WS-DECIMAL(01) ' COD_MSG_CRITICA = ' WS-SMALLINT(01) DELIMITED BY SIZE INTO WS-MENSAGEM */
            #region STRING
            var spl68 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
            spl68 += " - CERTIFICADO/COD-MSG-CRITICA JA CADASTRADO.";
            spl68 += " NUM_CERTIFICADO = ";
            var spl69 = WORK.WS_EDIT.WS_DECIMAL[01].GetMoveValues();
            spl69 += " COD_MSG_CRITICA = ";
            var spl70 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
            var results71 = spl68 + spl69 + spl70;
            _.Move(results71, WORK.WS_ERRO.WS_MENSAGEM);
            #endregion

            /*" -1392- MOVE 'SEGUROS.VG_CRITICA_PROPOSTA' TO WS-TABELA */
            _.Move("SEGUROS.VG_CRITICA_PROPOSTA", WORK.WS_ERRO.WS_TABELA);

            /*" -1393- MOVE SQLCODE TO WS-SQLCODE */
            _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

            /*" -1394- MOVE SQLERRMC TO WS-SQLERRMC */
            _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

            /*" -1394- . */

        }

        [StopWatch]
        /*" P0131-05-INICIO-DB-SELECT-1 */
        public void P0131_05_INICIO_DB_SELECT_1()
        {
            /*" -1338- EXEC SQL SELECT VG103.NUM_CERTIFICADO ,VG103.SEQ_CRITICA ,VG103.IND_TP_PROPOSTA ,VG103.COD_MSG_CRITICA ,VG102.DES_MSG_CRITICA ,VG102.DES_ABREV_MSG_CRITICA ,VG103.NUM_CPF_CNPJ ,VALUE(VG103.NUM_PROPOSTA,0) ,VG103.VLR_IS ,VG103.VLR_PREMIO ,VG103.DTA_OCORRENCIA ,VG103.DTA_RCAP ,VG103.STA_CRITICA ,VG099.DES_STA_CRITICA ,VALUE(VG103.DES_COMPLEMENTAR, ' ' ) ,VG103.COD_USUARIO ,VG103.NOM_PROGRAMA ,CHAR(VG103.DTH_CADASTRAMENTO) INTO :VG103-NUM-CERTIFICADO ,:VG103-SEQ-CRITICA ,:VG103-IND-TP-PROPOSTA ,:VG103-COD-MSG-CRITICA ,:VG102-DES-MSG-CRITICA ,:VG102-DES-ABREV-MSG-CRITICA ,:VG103-NUM-CPF-CNPJ ,:VG103-NUM-PROPOSTA ,:VG103-VLR-IS ,:VG103-VLR-PREMIO ,:VG103-DTA-OCORRENCIA ,:VG103-DTA-RCAP ,:VG103-STA-CRITICA ,:VG099-DES-STA-CRITICA ,:VG103-DES-COMPLEMENTAR ,:VG103-COD-USUARIO ,:VG103-NOM-PROGRAMA ,:VG103-DTH-CADASTRAMENTO FROM SEGUROS.VG_CRITICA_PROPOSTA VG103 ,SEGUROS.VG_DM_STA_CRITICA VG099 ,SEGUROS.VG_DM_MSG_CRITICA VG102 WHERE VG103.NUM_CERTIFICADO = :VG103-NUM-CERTIFICADO AND VG103.COD_MSG_CRITICA = :VG103-COD-MSG-CRITICA AND VG103.STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' ) AND VG099.STA_CRITICA = VG103.STA_CRITICA AND VG102.COD_MSG_CRITICA = VG103.COD_MSG_CRITICA END-EXEC */

            var p0131_05_INICIO_DB_SELECT_1_Query1 = new P0131_05_INICIO_DB_SELECT_1_Query1()
            {
                VG103_NUM_CERTIFICADO = VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CERTIFICADO.ToString(),
                VG103_COD_MSG_CRITICA = VG103.DCLVG_CRITICA_PROPOSTA.VG103_COD_MSG_CRITICA.ToString(),
            };

            var executed_1 = P0131_05_INICIO_DB_SELECT_1_Query1.Execute(p0131_05_INICIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VG103_NUM_CERTIFICADO, VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CERTIFICADO);
                _.Move(executed_1.VG103_SEQ_CRITICA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_SEQ_CRITICA);
                _.Move(executed_1.VG103_IND_TP_PROPOSTA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_IND_TP_PROPOSTA);
                _.Move(executed_1.VG103_COD_MSG_CRITICA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_COD_MSG_CRITICA);
                _.Move(executed_1.VG102_DES_MSG_CRITICA, VG102.DCLVG_DM_MSG_CRITICA.VG102_DES_MSG_CRITICA);
                _.Move(executed_1.VG102_DES_ABREV_MSG_CRITICA, VG102.DCLVG_DM_MSG_CRITICA.VG102_DES_ABREV_MSG_CRITICA);
                _.Move(executed_1.VG103_NUM_CPF_CNPJ, VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CPF_CNPJ);
                _.Move(executed_1.VG103_NUM_PROPOSTA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_PROPOSTA);
                _.Move(executed_1.VG103_VLR_IS, VG103.DCLVG_CRITICA_PROPOSTA.VG103_VLR_IS);
                _.Move(executed_1.VG103_VLR_PREMIO, VG103.DCLVG_CRITICA_PROPOSTA.VG103_VLR_PREMIO);
                _.Move(executed_1.VG103_DTA_OCORRENCIA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_DTA_OCORRENCIA);
                _.Move(executed_1.VG103_DTA_RCAP, VG103.DCLVG_CRITICA_PROPOSTA.VG103_DTA_RCAP);
                _.Move(executed_1.VG103_STA_CRITICA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_STA_CRITICA);
                _.Move(executed_1.VG099_DES_STA_CRITICA, VG099.DCLVG_DM_STA_CRITICA.VG099_DES_STA_CRITICA);
                _.Move(executed_1.VG103_DES_COMPLEMENTAR, VG103.DCLVG_CRITICA_PROPOSTA.VG103_DES_COMPLEMENTAR);
                _.Move(executed_1.VG103_COD_USUARIO, VG103.DCLVG_CRITICA_PROPOSTA.VG103_COD_USUARIO);
                _.Move(executed_1.VG103_NOM_PROGRAMA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_NOM_PROGRAMA);
                _.Move(executed_1.VG103_DTH_CADASTRAMENTO, VG103.DCLVG_CRITICA_PROPOSTA.VG103_DTH_CADASTRAMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0131_99_EXIT*/

        [StopWatch]
        /*" P0132-VERIFICAR-QQ-STATUS-CAD-SECTION */
        private void P0132_VERIFICAR_QQ_STATUS_CAD_SECTION()
        {
            /*" -1406- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0132_00_START */

            P0132_00_START();

        }

        [StopWatch]
        /*" P0132-00-START */
        private void P0132_00_START(bool isPerform = false)
        {
            /*" -1409- MOVE 'P0132' TO WS-SECTION */
            _.Move("P0132", WORK.WS_ERRO.WS_SECTION);

            /*" -1410- MOVE LK-VG001-NUM-CERTIFICADO TO VG103-NUM-CERTIFICADO */
            _.Move(SPVG001W.LK_VG001_NUM_CERTIFICADO, VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CERTIFICADO);

            /*" -1412- MOVE LK-VG001-COD-MSG-CRITICA TO VG103-COD-MSG-CRITICA */
            _.Move(SPVG001W.LK_VG001_COD_MSG_CRITICA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_COD_MSG_CRITICA);

            /*" -1412- . */

        }

        [StopWatch]
        /*" P0132-05-INICIO */
        private void P0132_05_INICIO(bool isPerform = false)
        {
            /*" -1468- PERFORM P0132_05_INICIO_DB_SELECT_1 */

            P0132_05_INICIO_DB_SELECT_1();

            /*" -1471- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -1472- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -1473- MOVE VG103-NUM-CERTIFICADO TO WS-DECIMAL(01) */
                _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CERTIFICADO, WORK.WS_EDIT.WS_DECIMAL[01]);

                /*" -1474- MOVE VG103-COD-MSG-CRITICA TO WS-SMALLINT(01) */
                _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_COD_MSG_CRITICA, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -1479- STRING WS-SECTION ' - ERRO NO SELECT SEGUROS.VG_CRITICA_PROPOSTA.' ' NUM_CERTIFICADO = ' WS-DECIMAL(01) ' COD_MSG_CRITICA = ' WS-SMALLINT(01) DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl71 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl71 += " - ERRO NO SELECT SEGUROS.VG_CRITICA_PROPOSTA.";
                spl71 += " NUM_CERTIFICADO = ";
                var spl72 = WORK.WS_EDIT.WS_DECIMAL[01].GetMoveValues();
                spl72 += " COD_MSG_CRITICA = ";
                var spl73 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                var results74 = spl71 + spl72 + spl73;
                _.Move(results74, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -1481- MOVE 'SEGUROS.VG_CRITICA_PROPOSTA' TO WS-TABELA */
                _.Move("SEGUROS.VG_CRITICA_PROPOSTA", WORK.WS_ERRO.WS_TABELA);

                /*" -1482- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -1483- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -1484- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1486- END-IF. */
            }


            /*" -1487- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1488- GO TO P0132-99-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P0132_99_EXIT*/ //GOTO
                return;

                /*" -1490- END-IF */
            }


            /*" -1491- MOVE VG103-NUM-CERTIFICADO TO LK-VG001-S-NUM-CERTIFICADO */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CERTIFICADO, SPVG001W.LK_VG001_S_NUM_CERTIFICADO);

            /*" -1492- MOVE VG103-SEQ-CRITICA TO LK-VG001-S-SEQ-CRITICA */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_SEQ_CRITICA, SPVG001W.LK_VG001_S_SEQ_CRITICA);

            /*" -1493- MOVE VG103-IND-TP-PROPOSTA TO LK-VG001-S-IND-TP-PROPOSTA */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_IND_TP_PROPOSTA, SPVG001W.LK_VG001_S_IND_TP_PROPOSTA);

            /*" -1494- MOVE VG103-COD-MSG-CRITICA TO LK-VG001-S-COD-MSG-CRITICA */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_COD_MSG_CRITICA, SPVG001W.LK_VG001_S_COD_MSG_CRITICA);

            /*" -1496- MOVE VG102-DES-MSG-CRITICA-TEXT(1:VG102-DES-MSG-CRITICA-LEN) TO LK-VG001-S-DES-MSG-CRITICA */
            _.Move(VG102.DCLVG_DM_MSG_CRITICA.VG102_DES_MSG_CRITICA.VG102_DES_MSG_CRITICA_TEXT.Substring(1, VG102.DCLVG_DM_MSG_CRITICA.VG102_DES_MSG_CRITICA.VG102_DES_MSG_CRITICA_LEN), SPVG001W.LK_VG001_S_DES_MSG_CRITICA);

            /*" -1498- MOVE VG102-DES-ABREV-MSG-CRITICA TO LK-VG001-S-DES-ABREV-MSG-CRIT */
            _.Move(VG102.DCLVG_DM_MSG_CRITICA.VG102_DES_ABREV_MSG_CRITICA, SPVG001W.LK_VG001_S_DES_ABREV_MSG_CRIT);

            /*" -1499- MOVE VG103-NUM-CPF-CNPJ TO LK-VG001-S-NUM-CPF-CNPJ */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CPF_CNPJ, SPVG001W.LK_VG001_S_NUM_CPF_CNPJ);

            /*" -1500- MOVE VG103-NUM-PROPOSTA TO LK-VG001-S-NUM-PROPOSTA */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_PROPOSTA, SPVG001W.LK_VG001_S_NUM_PROPOSTA);

            /*" -1501- MOVE VG103-VLR-IS TO LK-VG001-S-VLR-IS */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_VLR_IS, SPVG001W.LK_VG001_S_VLR_IS);

            /*" -1502- MOVE VG103-VLR-PREMIO TO LK-VG001-S-VLR-PREMIO */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_VLR_PREMIO, SPVG001W.LK_VG001_S_VLR_PREMIO);

            /*" -1503- MOVE VG103-DTA-OCORRENCIA TO LK-VG001-S-DTA-OCORRENCIA */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_DTA_OCORRENCIA, SPVG001W.LK_VG001_S_DTA_OCORRENCIA);

            /*" -1504- MOVE VG103-DTA-RCAP TO LK-VG001-S-DTA-RCAP */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_DTA_RCAP, SPVG001W.LK_VG001_S_DTA_RCAP);

            /*" -1505- MOVE VG103-STA-CRITICA TO LK-VG001-S-STA-CRITICA */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_STA_CRITICA, SPVG001W.LK_VG001_S_STA_CRITICA);

            /*" -1507- MOVE VG099-DES-STA-CRITICA-TEXT(1:VG099-DES-STA-CRITICA-LEN) TO LK-VG001-S-DES-STA-CRITICA */
            _.Move(VG099.DCLVG_DM_STA_CRITICA.VG099_DES_STA_CRITICA.VG099_DES_STA_CRITICA_TEXT.Substring(1, VG099.DCLVG_DM_STA_CRITICA.VG099_DES_STA_CRITICA.VG099_DES_STA_CRITICA_LEN), SPVG001W.LK_VG001_S_DES_STA_CRITICA);

            /*" -1508- MOVE VG103-DES-COMPLEMENTAR TO LK-VG001-S-DES-COMPLEMENTAR */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_DES_COMPLEMENTAR, SPVG001W.LK_VG001_S_DES_COMPLEMENTAR);

            /*" -1509- MOVE VG103-COD-USUARIO TO LK-VG001-S-COD-USUARIO */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_COD_USUARIO, SPVG001W.LK_VG001_S_COD_USUARIO);

            /*" -1510- MOVE VG103-NOM-PROGRAMA TO LK-VG001-S-NOM-PROGRAMA */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_NOM_PROGRAMA, SPVG001W.LK_VG001_S_NOM_PROGRAMA);

            /*" -1512- MOVE VG103-DTH-CADASTRAMENTO TO LK-VG001-S-DTH-CADASTRAMENTO */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_DTH_CADASTRAMENTO, SPVG001W.LK_VG001_S_DTH_CADASTRAMENTO);

            /*" -1513- MOVE 1 TO WS-IND-ERRO */
            _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

            /*" -1514- MOVE VG103-NUM-CERTIFICADO TO WS-DECIMAL(01) */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CERTIFICADO, WORK.WS_EDIT.WS_DECIMAL[01]);

            /*" -1515- MOVE VG103-COD-MSG-CRITICA TO WS-SMALLINT(01) */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_COD_MSG_CRITICA, WORK.WS_EDIT.WS_SMALLINT[01]);

            /*" -1520- STRING WS-SECTION ' - CERTIFICADO/COD-MSG-CRITICA JA CADASTRADO.' ' NUM_CERTIFICADO = ' WS-DECIMAL(01) ' COD_MSG_CRITICA = ' WS-SMALLINT(01) DELIMITED BY SIZE INTO WS-MENSAGEM */
            #region STRING
            var spl74 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
            spl74 += " - CERTIFICADO/COD-MSG-CRITICA JA CADASTRADO.";
            spl74 += " NUM_CERTIFICADO = ";
            var spl75 = WORK.WS_EDIT.WS_DECIMAL[01].GetMoveValues();
            spl75 += " COD_MSG_CRITICA = ";
            var spl76 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
            var results77 = spl74 + spl75 + spl76;
            _.Move(results77, WORK.WS_ERRO.WS_MENSAGEM);
            #endregion

            /*" -1522- MOVE 'SEGUROS.VG_CRITICA_PROPOSTA' TO WS-TABELA */
            _.Move("SEGUROS.VG_CRITICA_PROPOSTA", WORK.WS_ERRO.WS_TABELA);

            /*" -1523- MOVE SQLCODE TO WS-SQLCODE */
            _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

            /*" -1524- MOVE SQLERRMC TO WS-SQLERRMC */
            _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

            /*" -1524- . */

        }

        [StopWatch]
        /*" P0132-05-INICIO-DB-SELECT-1 */
        public void P0132_05_INICIO_DB_SELECT_1()
        {
            /*" -1468- EXEC SQL SELECT VG103.NUM_CERTIFICADO ,VG103.SEQ_CRITICA ,VG103.IND_TP_PROPOSTA ,VG103.COD_MSG_CRITICA ,VG102.DES_MSG_CRITICA ,VG102.DES_ABREV_MSG_CRITICA ,VG103.NUM_CPF_CNPJ ,VALUE(VG103.NUM_PROPOSTA,0) ,VG103.VLR_IS ,VG103.VLR_PREMIO ,VG103.DTA_OCORRENCIA ,VG103.DTA_RCAP ,VG103.STA_CRITICA ,VG099.DES_STA_CRITICA ,VALUE(VG103.DES_COMPLEMENTAR, ' ' ) ,VG103.COD_USUARIO ,VG103.NOM_PROGRAMA ,CHAR(VG103.DTH_CADASTRAMENTO) INTO :VG103-NUM-CERTIFICADO ,:VG103-SEQ-CRITICA ,:VG103-IND-TP-PROPOSTA ,:VG103-COD-MSG-CRITICA ,:VG102-DES-MSG-CRITICA ,:VG102-DES-ABREV-MSG-CRITICA ,:VG103-NUM-CPF-CNPJ ,:VG103-NUM-PROPOSTA ,:VG103-VLR-IS ,:VG103-VLR-PREMIO ,:VG103-DTA-OCORRENCIA ,:VG103-DTA-RCAP ,:VG103-STA-CRITICA ,:VG099-DES-STA-CRITICA ,:VG103-DES-COMPLEMENTAR ,:VG103-COD-USUARIO ,:VG103-NOM-PROGRAMA ,:VG103-DTH-CADASTRAMENTO FROM SEGUROS.VG_CRITICA_PROPOSTA VG103 ,SEGUROS.VG_DM_STA_CRITICA VG099 ,SEGUROS.VG_DM_MSG_CRITICA VG102 WHERE VG103.NUM_CERTIFICADO = :VG103-NUM-CERTIFICADO AND VG103.COD_MSG_CRITICA = :VG103-COD-MSG-CRITICA AND VG099.STA_CRITICA = VG103.STA_CRITICA AND VG102.COD_MSG_CRITICA = VG103.COD_MSG_CRITICA AND VG103.DTH_CADASTRAMENTO = ( SELECT MAX(VG103V.DTH_CADASTRAMENTO) FROM SEGUROS.VG_CRITICA_PROPOSTA VG103V WHERE VG103V.NUM_CERTIFICADO = VG103.NUM_CERTIFICADO AND VG103V.COD_MSG_CRITICA = VG103.COD_MSG_CRITICA ) END-EXEC */

            var p0132_05_INICIO_DB_SELECT_1_Query1 = new P0132_05_INICIO_DB_SELECT_1_Query1()
            {
                VG103_NUM_CERTIFICADO = VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CERTIFICADO.ToString(),
                VG103_COD_MSG_CRITICA = VG103.DCLVG_CRITICA_PROPOSTA.VG103_COD_MSG_CRITICA.ToString(),
            };

            var executed_1 = P0132_05_INICIO_DB_SELECT_1_Query1.Execute(p0132_05_INICIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VG103_NUM_CERTIFICADO, VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CERTIFICADO);
                _.Move(executed_1.VG103_SEQ_CRITICA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_SEQ_CRITICA);
                _.Move(executed_1.VG103_IND_TP_PROPOSTA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_IND_TP_PROPOSTA);
                _.Move(executed_1.VG103_COD_MSG_CRITICA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_COD_MSG_CRITICA);
                _.Move(executed_1.VG102_DES_MSG_CRITICA, VG102.DCLVG_DM_MSG_CRITICA.VG102_DES_MSG_CRITICA);
                _.Move(executed_1.VG102_DES_ABREV_MSG_CRITICA, VG102.DCLVG_DM_MSG_CRITICA.VG102_DES_ABREV_MSG_CRITICA);
                _.Move(executed_1.VG103_NUM_CPF_CNPJ, VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CPF_CNPJ);
                _.Move(executed_1.VG103_NUM_PROPOSTA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_PROPOSTA);
                _.Move(executed_1.VG103_VLR_IS, VG103.DCLVG_CRITICA_PROPOSTA.VG103_VLR_IS);
                _.Move(executed_1.VG103_VLR_PREMIO, VG103.DCLVG_CRITICA_PROPOSTA.VG103_VLR_PREMIO);
                _.Move(executed_1.VG103_DTA_OCORRENCIA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_DTA_OCORRENCIA);
                _.Move(executed_1.VG103_DTA_RCAP, VG103.DCLVG_CRITICA_PROPOSTA.VG103_DTA_RCAP);
                _.Move(executed_1.VG103_STA_CRITICA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_STA_CRITICA);
                _.Move(executed_1.VG099_DES_STA_CRITICA, VG099.DCLVG_DM_STA_CRITICA.VG099_DES_STA_CRITICA);
                _.Move(executed_1.VG103_DES_COMPLEMENTAR, VG103.DCLVG_CRITICA_PROPOSTA.VG103_DES_COMPLEMENTAR);
                _.Move(executed_1.VG103_COD_USUARIO, VG103.DCLVG_CRITICA_PROPOSTA.VG103_COD_USUARIO);
                _.Move(executed_1.VG103_NOM_PROGRAMA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_NOM_PROGRAMA);
                _.Move(executed_1.VG103_DTH_CADASTRAMENTO, VG103.DCLVG_CRITICA_PROPOSTA.VG103_DTH_CADASTRAMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0132_99_EXIT*/

        [StopWatch]
        /*" P0301-TRATAR-TIPO-ACAO-01-SECTION */
        private void P0301_TRATAR_TIPO_ACAO_01_SECTION()
        {
            /*" -1536- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0301_00_START */

            P0301_00_START();

        }

        [StopWatch]
        /*" P0301-00-START */
        private void P0301_00_START(bool isPerform = false)
        {
            /*" -1539- MOVE 'P0301' TO WS-SECTION */
            _.Move("P0301", WORK.WS_ERRO.WS_SECTION);

            /*" -1539- . */

        }

        [StopWatch]
        /*" P0301-05-INICIO */
        private void P0301_05_INICIO(bool isPerform = false)
        {
            /*" -1545- PERFORM P0130-PESQUISAR-CERTIFICADO */

            P0130_PESQUISAR_CERTIFICADO_SECTION();

            /*" -1545- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0301_99_EXIT*/

        [StopWatch]
        /*" P0302-TRATAR-TIPO-ACAO-02-SECTION */
        private void P0302_TRATAR_TIPO_ACAO_02_SECTION()
        {
            /*" -1556- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0302_00_START */

            P0302_00_START();

        }

        [StopWatch]
        /*" P0302-00-START */
        private void P0302_00_START(bool isPerform = false)
        {
            /*" -1559- MOVE 'P0302' TO WS-SECTION */
            _.Move("P0302", WORK.WS_ERRO.WS_SECTION);

            /*" -1559- PERFORM P0302-05-INICIO. */

            P0302_05_INICIO(true);

        }

        [StopWatch]
        /*" P0302-05-INICIO */
        private void P0302_05_INICIO(bool isPerform = false)
        {
            /*" -1564-  EVALUATE TRUE  */

            /*" -1565-  WHEN VG102-COD-TP-MSG-CRITICA = 001  */

            /*" -1565- IF VG102-COD-TP-MSG-CRITICA = 001 */

            if (VG102.DCLVG_DM_MSG_CRITICA.VG102_COD_TP_MSG_CRITICA == 001)
            {

                /*" -1566- MOVE '0' TO VG103-STA-CRITICA */
                _.Move("0", VG103.DCLVG_CRITICA_PROPOSTA.VG103_STA_CRITICA);

                /*" -1567-  WHEN VG102-COD-TP-MSG-CRITICA = 002  */

                /*" -1567- ELSE IF VG102-COD-TP-MSG-CRITICA = 002 */
            }
            else

            if (VG102.DCLVG_DM_MSG_CRITICA.VG102_COD_TP_MSG_CRITICA == 002)
            {

                /*" -1568- MOVE '8' TO VG103-STA-CRITICA */
                _.Move("8", VG103.DCLVG_CRITICA_PROPOSTA.VG103_STA_CRITICA);

                /*" -1569-  WHEN VG102-COD-TP-MSG-CRITICA = 003  */

                /*" -1569- ELSE IF VG102-COD-TP-MSG-CRITICA = 003 */
            }
            else

            if (VG102.DCLVG_DM_MSG_CRITICA.VG102_COD_TP_MSG_CRITICA == 003)
            {

                /*" -1570- MOVE '7' TO VG103-STA-CRITICA */
                _.Move("7", VG103.DCLVG_CRITICA_PROPOSTA.VG103_STA_CRITICA);

                /*" -1571-  WHEN OTHER  */

                /*" -1571- ELSE */
            }
            else
            {


                /*" -1572- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -1574- MOVE VG102-COD-TP-MSG-CRITICA TO WS-SMALLINT(01) */
                _.Move(VG102.DCLVG_DM_MSG_CRITICA.VG102_COD_TP_MSG_CRITICA, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -1578- STRING WS-SECTION ' - TIPO DE MENSAGEM DE CRITICA NAO PREVISTA. ' ' COD-TP-MSG-CRITICA = ' WS-SMALLINT(01) DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl77 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl77 += " - TIPO DE MENSAGEM DE CRITICA NAO PREVISTA. ";
                spl77 += " COD-TP-MSG-CRITICA = ";
                var spl78 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                var results79 = spl77 + spl78;
                _.Move(results79, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -1579- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -1580- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -1581- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1583-  END-EVALUATE  */

                /*" -1583- END-IF */
            }


            /*" -1584-  EVALUATE TRUE  */

            /*" -1585-  WHEN LK-VG001-IND-TP-PROPOSTA = 'BI'  */

            /*" -1585- IF LK-VG001-IND-TP-PROPOSTA = 'BI' */

            if (SPVG001W.LK_VG001_IND_TP_PROPOSTA == "BI")
            {

                /*" -1586- PERFORM P0801-PESQUISAR-BILHETE */

                P0801_PESQUISAR_BILHETE_SECTION();

                /*" -1588-  WHEN LK-VG001-IND-TP-PROPOSTA = 'PF'  */

                /*" -1588- ELSE IF LK-VG001-IND-TP-PROPOSTA = 'PF' */
            }
            else

            if (SPVG001W.LK_VG001_IND_TP_PROPOSTA == "PF")
            {

                /*" -1589-  WHEN LK-VG001-IND-TP-PROPOSTA = 'MD'  */

                /*" -1589- ELSE IF LK-VG001-IND-TP-PROPOSTA = 'MD' */
            }
            else

            if (SPVG001W.LK_VG001_IND_TP_PROPOSTA == "MD")
            {

                /*" -1590- PERFORM P0802-PESQUISAR-PROPOSTAS-VA */

                P0802_PESQUISAR_PROPOSTAS_VA_SECTION();

                /*" -1591-  WHEN LK-VG001-IND-TP-PROPOSTA = 'PJ'  */

                /*" -1591- ELSE IF LK-VG001-IND-TP-PROPOSTA = 'PJ' */
            }
            else

            if (SPVG001W.LK_VG001_IND_TP_PROPOSTA == "PJ")
            {

                /*" -1593- PERFORM P0805-PESQUISA-TIPO-PJ */

                P0805_PESQUISA_TIPO_PJ_SECTION();

                /*" -1594- IF WS-ORIG-PRODUTO NOT EQUAL 'ESPEC' AND 'ESPE1' */

                if (!WORK.WS_ORIG_PRODUTO.In("ESPEC", "ESPE1"))
                {

                    /*" -1595- PERFORM P0803-PESQUISAR-VG-SOLIC-FAT */

                    P0803_PESQUISAR_VG_SOLIC_FAT_SECTION();

                    /*" -1596- ELSE */
                }
                else
                {


                    /*" -1597- PERFORM P0804-PESQUISAR-APOL-ESPEC */

                    P0804_PESQUISAR_APOL_ESPEC_SECTION();

                    /*" -1598- END-IF */
                }


                /*" -1599-  WHEN OTHER  */

                /*" -1599- ELSE */
            }
            else
            {


                /*" -1600- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -1604- STRING WS-SECTION ' - TIPO DE PROPOSTA INVALIDA.' ' IND_TP_PROPOSTA = ' LK-VG001-IND-TP-PROPOSTA DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl79 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl79 += " - TIPO DE PROPOSTA INVALIDA.";
                spl79 += " IND_TP_PROPOSTA = ";
                var spl80 = SPVG001W.LK_VG001_IND_TP_PROPOSTA.GetMoveValues();
                var results81 = spl79 + spl80;
                _.Move(results81, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -1605- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -1606- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -1607- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1609-  END-EVALUATE  */

                /*" -1609- END-IF */
            }


            /*" -1609- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0302_99_EXIT*/

        [StopWatch]
        /*" P0303-TRATAR-TIPO-ACAO-03-SECTION */
        private void P0303_TRATAR_TIPO_ACAO_03_SECTION()
        {
            /*" -1620- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0303_00_START */

            P0303_00_START();

        }

        [StopWatch]
        /*" P0303-00-START */
        private void P0303_00_START(bool isPerform = false)
        {
            /*" -1623- MOVE 'P0303' TO WS-SECTION */
            _.Move("P0303", WORK.WS_ERRO.WS_SECTION);

            /*" -1623- PERFORM P0303-05-INICIO. */

            P0303_05_INICIO(true);

        }

        [StopWatch]
        /*" P0303-05-INICIO */
        private void P0303_05_INICIO(bool isPerform = false)
        {
            /*" -1632- MOVE LK-VG001-STA-CRITICA TO VG103-STA-CRITICA */
            _.Move(SPVG001W.LK_VG001_STA_CRITICA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_STA_CRITICA);

            /*" -1633- IF VG103-NUM-PROPOSTA = 0 */

            if (VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_PROPOSTA == 0)
            {

                /*" -1634- MOVE -1 TO WH-VG103INUM-PROPOSTA */
                _.Move(-1, WH_AUXILIAR.WH_VG103INUM_PROPOSTA);

                /*" -1635- ELSE */
            }
            else
            {


                /*" -1636- MOVE 0 TO WH-VG103INUM-PROPOSTA */
                _.Move(0, WH_AUXILIAR.WH_VG103INUM_PROPOSTA);

                /*" -1638- END-IF */
            }


            /*" -1639- MOVE WH-VG103-DES-COMPLEMENTAR TO VG103-DES-COMPLEMENTAR */
            _.Move(WH_AUXILIAR.WH_VG103_DES_COMPLEMENTAR, VG103.DCLVG_CRITICA_PROPOSTA.VG103_DES_COMPLEMENTAR);

            /*" -1641- MOVE 0 TO WH-VG103IDES-COMPLEMENTAR */
            _.Move(0, WH_AUXILIAR.WH_VG103IDES_COMPLEMENTAR);

            /*" -1642- PERFORM P0851-BUSCAR-TIMESTAMP */

            P0851_BUSCAR_TIMESTAMP_SECTION();

            /*" -1643- MOVE WH-CURRENT-TIMESTAMP TO VG103-DTH-CADASTRAMENTO */
            _.Move(WH_AUXILIAR.WH_CURRENT_TIMESTAMP, VG103.DCLVG_CRITICA_PROPOSTA.VG103_DTH_CADASTRAMENTO);

            /*" -1644- MOVE LK-VG001-COD-USUARIO TO VG103-COD-USUARIO */
            _.Move(SPVG001W.LK_VG001_COD_USUARIO, VG103.DCLVG_CRITICA_PROPOSTA.VG103_COD_USUARIO);

            /*" -1646- MOVE LK-VG001-NOM-PROGRAMA TO VG103-NOM-PROGRAMA */
            _.Move(SPVG001W.LK_VG001_NOM_PROGRAMA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_NOM_PROGRAMA);

            /*" -1648- PERFORM P0822-ATUALIZAR-VG103 */

            P0822_ATUALIZAR_VG103_SECTION();

            /*" -1650- PERFORM P0821-INSERIR-VG104 */

            P0821_INSERIR_VG104_SECTION();

            /*" -1650- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0303_99_EXIT*/

        [StopWatch]
        /*" P0305-TRATAR-TIPO-ACAO-05-SECTION */
        private void P0305_TRATAR_TIPO_ACAO_05_SECTION()
        {
            /*" -1662- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0305_00_START */

            P0305_00_START();

        }

        [StopWatch]
        /*" P0305-00-START */
        private void P0305_00_START(bool isPerform = false)
        {
            /*" -1665- MOVE 'P0305' TO WS-SECTION */
            _.Move("P0305", WORK.WS_ERRO.WS_SECTION);

            /*" -1666- MOVE 0 TO WS-I WS-J */
            _.Move(0, WORK.WS_CONTADORES.WS_I, WORK.WS_CONTADORES.WS_J);

            /*" -1667- MOVE 'N' TO WS-IND-STATUS */
            _.Move("N", WORK.WS_INDICADORES.WS_IND_STATUS);

            /*" -1669- MOVE SPACES TO WS-STA-PARA */
            _.Move("", WORK.WS_AUXILIARES.WS_STA_PARA);

            /*" -1669- . */

        }

        [StopWatch]
        /*" P0305-05-INICIO */
        private void P0305_05_INICIO(bool isPerform = false)
        {
            /*" -1678- PERFORM VARYING WS-I FROM 1 BY 1 UNTIL WS-I > VG001-ARR-STA-I OR INDSTATUSSIM */

            for (WORK.WS_CONTADORES.WS_I.Value = 1; !(WORK.WS_CONTADORES.WS_I > SPVG001X.VG001.VG001_ARR_STA_I || WORK.WS_INDICADORES.WS_IND_STATUS["INDSTATUSSIM"]); WORK.WS_CONTADORES.WS_I.Value += 1)
            {

                /*" -1679- IF VG001-ARR-STA-STATUS-DE(WS-I) = VG103-STA-CRITICA */

                if (SPVG001X.VG001.FILLER.VG001_ARR_STA_OCCURS[WORK.WS_CONTADORES.WS_I].VG001_ARR_STA_STATUS_DE == VG103.DCLVG_CRITICA_PROPOSTA.VG103_STA_CRITICA)
                {

                    /*" -1681- MOVE VG001-ARR-STA-PARA(WS-I) TO LK-VG001-S-STA-PARA */
                    _.Move(SPVG001X.VG001.FILLER.VG001_ARR_STA_OCCURS[WORK.WS_CONTADORES.WS_I].VG001_ARR_STA_PARA, SPVG001W.LK_VG001_S_STA_PARA);

                    /*" -1682- MOVE 'S' TO WS-IND-STATUS */
                    _.Move("S", WORK.WS_INDICADORES.WS_IND_STATUS);

                    /*" -1683- END-IF */
                }


                /*" -1685- END-PERFORM */
            }

            /*" -1686- IF INDSTATUSNAO OR LK-VG001-S-STA-PARA = SPACES */

            if (WORK.WS_INDICADORES.WS_IND_STATUS["INDSTATUSNAO"] || SPVG001W.LK_VG001_S_STA_PARA.IsEmpty())
            {

                /*" -1687- MOVE 'P0305' TO WS-SECTION */
                _.Move("P0305", WORK.WS_ERRO.WS_SECTION);

                /*" -1688- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -1692- STRING WS-SECTION ' - NAO E POSSIVEL MUDAR O STATUS ' VG103-STA-CRITICA ' PARA OUTRO STATUS.' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl81 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl81 += " - NAO E POSSIVEL MUDAR O STATUS ";
                var spl82 = VG103.DCLVG_CRITICA_PROPOSTA.VG103_STA_CRITICA.GetMoveValues();
                spl82 += " PARA OUTRO STATUS.";
                var results83 = spl81 + spl82;
                _.Move(results83, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -1693- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -1694- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -1695- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1699- END-IF */
            }


            /*" -1702- IF LK-VG001-S-STA-PARA = 'A' OR = '3' OR = '6' OR = '7' OR = '8' OR = '9' OR = 'B' */

            if (SPVG001W.LK_VG001_S_STA_PARA.In("A", "3", "6", "7", "8", "9", "B"))
            {

                /*" -1703- MOVE SPACES TO LK-VG001-S-STA-PARA */
                _.Move("", SPVG001W.LK_VG001_S_STA_PARA);

                /*" -1704- ELSE */
            }
            else
            {


                /*" -1706- PERFORM VARYING WS-I FROM 1 BY 1 UNTIL WS-I > VG001-ARR-STA-J */

                for (WORK.WS_CONTADORES.WS_I.Value = 1; !(WORK.WS_CONTADORES.WS_I > SPVG001X.VG001.VG001_ARR_STA_J); WORK.WS_CONTADORES.WS_I.Value += 1)
                {

                    /*" -1707- IF LK-VG001-S-STA-PARA(WS-I:1) NOT = ' ' */

                    if (SPVG001W.LK_VG001_S_STA_PARA.Substring(WORK.WS_CONTADORES.WS_I, 1) != " ")
                    {

                        /*" -1708-  EVALUATE TRUE  */

                        /*" -1710-  WHEN VG103-STA-CRITICA = '0'             AND VG102-IND-ALCADA = 'N'  */

                        /*" -1710- IF VG103-STA-CRITICA = '0'             AND VG102-IND-ALCADA = 'N' */

                        if (VG103.DCLVG_CRITICA_PROPOSTA.VG103_STA_CRITICA == "0" && VG102.DCLVG_DM_MSG_CRITICA.VG102_IND_ALCADA == "N")
                        {

                            /*" -1711- IF LK-VG001-S-STA-PARA(WS-I:1) NOT = 'B' */

                            if (SPVG001W.LK_VG001_S_STA_PARA.Substring(WORK.WS_CONTADORES.WS_I, 1) != "B")
                            {

                                /*" -1713- MOVE SPACES TO LK-VG001-S-STA-PARA(WS-I:1) */
                                _.MoveAtPosition("", SPVG001W.LK_VG001_S_STA_PARA, WORK.WS_CONTADORES.WS_I, 1);

                                /*" -1721- END-IF */
                            }


                            /*" -1722-  WHEN OTHER  */

                            /*" -1722- ELSE */
                        }
                        else
                        {


                            /*" -1723- CONTINUE */

                            /*" -1724-  END-EVALUATE  */

                            /*" -1724- END-IF */
                        }


                        /*" -1725- PERFORM P0351-VALIDAR-STATUS-ALCADA */

                        P0351_VALIDAR_STATUS_ALCADA_SECTION();

                        /*" -1726- IF INDP0351NAO */

                        if (WORK.WS_INDICADORES.WS_IND_P0351["INDP0351NAO"])
                        {

                            /*" -1728- MOVE SPACES TO LK-VG001-S-STA-PARA(WS-I:1) */
                            _.MoveAtPosition("", SPVG001W.LK_VG001_S_STA_PARA, WORK.WS_CONTADORES.WS_I, 1);

                            /*" -1729- END-IF */
                        }


                        /*" -1730- END-IF */
                    }


                    /*" -1731- END-PERFORM */
                }

                /*" -1732- IF LK-VG001-S-STA-PARA = SPACES */

                if (SPVG001W.LK_VG001_S_STA_PARA.IsEmpty())
                {

                    /*" -1733- MOVE 'P0305' TO WS-SECTION */
                    _.Move("P0305", WORK.WS_ERRO.WS_SECTION);

                    /*" -1734- MOVE 1 TO WS-IND-ERRO */
                    _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                    /*" -1738- STRING WS-SECTION ' - USUARIO NAO POSSUI ALCADA PARA MUDANCA DE ' 'STATUS.' DELIMITED BY SIZE INTO WS-MENSAGEM */
                    #region STRING
                    var spl83 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                    spl83 += " - USUARIO NAO POSSUI ALCADA PARA MUDANCA DE ";
                    spl83 += "STATUS.";
                    _.Move(spl83, WORK.WS_ERRO.WS_MENSAGEM);
                    #endregion

                    /*" -1739- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                    _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                    /*" -1740- MOVE 0 TO WS-SQLCODE */
                    _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                    /*" -1741- GO TO P9999-ERRO */

                    P9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1742- END-IF */
                }


                /*" -1743- MOVE 0 TO WS-J */
                _.Move(0, WORK.WS_CONTADORES.WS_J);

                /*" -1744- PERFORM VARYING WS-I FROM 1 BY 1 UNTIL WS-I > 4 */

                for (WORK.WS_CONTADORES.WS_I.Value = 1; !(WORK.WS_CONTADORES.WS_I > 4); WORK.WS_CONTADORES.WS_I.Value += 1)
                {

                    /*" -1745- IF LK-VG001-S-STA-PARA(WS-I:1) NOT = SPACES */

                    if (SPVG001W.LK_VG001_S_STA_PARA.Substring(WORK.WS_CONTADORES.WS_I, 1) != string.Empty)
                    {

                        /*" -1746- ADD 1 TO WS-J */
                        WORK.WS_CONTADORES.WS_J.Value = WORK.WS_CONTADORES.WS_J + 1;

                        /*" -1748- MOVE LK-VG001-S-STA-PARA(WS-I:1) TO WS-STA-PARA(WS-J:1) */
                        _.MoveAtPosition(SPVG001W.LK_VG001_S_STA_PARA.Substring(WORK.WS_CONTADORES.WS_I, 1), WORK.WS_AUXILIARES.WS_STA_PARA, WORK.WS_CONTADORES.WS_J, 1);

                        /*" -1749- END-IF */
                    }


                    /*" -1750- END-PERFORM */
                }

                /*" -1751- MOVE WS-STA-PARA TO LK-VG001-S-STA-PARA */
                _.Move(WORK.WS_AUXILIARES.WS_STA_PARA, SPVG001W.LK_VG001_S_STA_PARA);

                /*" -1753- END-IF */
            }


            /*" -1753- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0305_99_EXIT*/

        [StopWatch]
        /*" P0308-TRATAR-TIPO-ACAO-08-SECTION */
        private void P0308_TRATAR_TIPO_ACAO_08_SECTION()
        {
            /*" -1764- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0308_00_START */

            P0308_00_START();

        }

        [StopWatch]
        /*" P0308-00-START */
        private void P0308_00_START(bool isPerform = false)
        {
            /*" -1767- MOVE 'P0308' TO WS-SECTION */
            _.Move("P0308", WORK.WS_ERRO.WS_SECTION);

            /*" -1768- MOVE ZEROS TO TESTA-FIM-CURSOR */
            _.Move(0, WORK.TESTA_FIM_CURSOR);

            /*" -1768- PERFORM P0308-05-INICIO. */

            P0308_05_INICIO(true);

        }

        [StopWatch]
        /*" P0308-05-INICIO */
        private void P0308_05_INICIO(bool isPerform = false)
        {
            /*" -1801- PERFORM P0308_05_INICIO_DB_DECLARE_1 */

            P0308_05_INICIO_DB_DECLARE_1();

            /*" -1803- PERFORM P0308_05_INICIO_DB_OPEN_1 */

            P0308_05_INICIO_DB_OPEN_1();

            /*" -1806- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1807- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -1808- MOVE VG103-NUM-CERTIFICADO TO WS-DECIMAL(01) */
                _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CERTIFICADO, WORK.WS_EDIT.WS_DECIMAL[01]);

                /*" -1813- STRING WS-SECTION ' - ERRO NO OPEN DO CURSOR SPBVG001_VG001.' ' NUM_CERTIFICADO = ' WS-DECIMAL(01) ' STA_CRITICA = 0' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl84 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl84 += " - ERRO NO OPEN DO CURSOR SPBVG001_VG001.";
                spl84 += " NUM_CERTIFICADO = ";
                var spl85 = WORK.WS_EDIT.WS_DECIMAL[01].GetMoveValues();
                spl85 += " STA_CRITICA = 0";
                var results86 = spl84 + spl85;
                _.Move(results86, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -1815- MOVE 'SEGUROS.VG_CRITICA_PROPOSTA' TO WS-TABELA */
                _.Move("SEGUROS.VG_CRITICA_PROPOSTA", WORK.WS_ERRO.WS_TABELA);

                /*" -1816- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -1817- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -1818- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1820- END-IF */
            }


            /*" -1822- PERFORM P0309-FETCH-CURSOR-VG001 */

            P0309_FETCH_CURSOR_VG001_SECTION();

            /*" -1824- PERFORM P0310-ALTERAR-STATUS-PEND UNTIL FIM-CURSOR02 */

            while (!(WORK.TESTA_FIM_CURSOR["FIM_CURSOR02"]))
            {

                P0310_ALTERAR_STATUS_PEND_SECTION();
            }

            /*" -1824- . */

        }

        [StopWatch]
        /*" P0308-05-INICIO-DB-DECLARE-1 */
        public void P0308_05_INICIO_DB_DECLARE_1()
        {
            /*" -1801- EXEC SQL DECLARE SPBVG001_VG001 CURSOR FOR SELECT VG103.NUM_CERTIFICADO ,VG103.SEQ_CRITICA ,VG103.IND_TP_PROPOSTA ,VG103.COD_MSG_CRITICA ,VG102.DES_MSG_CRITICA ,VG102.DES_ABREV_MSG_CRITICA ,VG103.NUM_CPF_CNPJ ,VALUE(VG103.NUM_PROPOSTA,0) ,VG103.VLR_IS ,VG103.VLR_PREMIO ,VG103.DTA_OCORRENCIA ,VG103.DTA_RCAP ,VG103.STA_CRITICA ,VG099.DES_STA_CRITICA ,VALUE(VG103.DES_COMPLEMENTAR, ' ' ) ,VG103.COD_USUARIO ,VG103.NOM_PROGRAMA ,CHAR(VG103.DTH_CADASTRAMENTO) ,VG102.IND_ALCADA FROM SEGUROS.VG_CRITICA_PROPOSTA VG103 ,SEGUROS.VG_DM_STA_CRITICA VG099 ,SEGUROS.VG_DM_MSG_CRITICA VG102 WHERE VG103.NUM_CERTIFICADO = :VG103-NUM-CERTIFICADO AND VG103.STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' ) AND VG099.STA_CRITICA = VG103.STA_CRITICA AND VG102.COD_MSG_CRITICA = VG103.COD_MSG_CRITICA END-EXEC. */
            SPBVG001_VG001 = new SPBVG001_SPBVG001_VG001(true);
            string GetQuery_SPBVG001_VG001()
            {
                var query = @$"SELECT VG103.NUM_CERTIFICADO 
							,VG103.SEQ_CRITICA 
							,VG103.IND_TP_PROPOSTA 
							,VG103.COD_MSG_CRITICA 
							,VG102.DES_MSG_CRITICA 
							,VG102.DES_ABREV_MSG_CRITICA 
							,VG103.NUM_CPF_CNPJ 
							,VALUE(VG103.NUM_PROPOSTA
							,0) 
							,VG103.VLR_IS 
							,VG103.VLR_PREMIO 
							,VG103.DTA_OCORRENCIA 
							,VG103.DTA_RCAP 
							,VG103.STA_CRITICA 
							,VG099.DES_STA_CRITICA 
							,VALUE(VG103.DES_COMPLEMENTAR
							, ' ' ) 
							,VG103.COD_USUARIO 
							,VG103.NOM_PROGRAMA 
							,CHAR(VG103.DTH_CADASTRAMENTO) 
							,VG102.IND_ALCADA 
							FROM SEGUROS.VG_CRITICA_PROPOSTA VG103 
							,SEGUROS.VG_DM_STA_CRITICA VG099 
							,SEGUROS.VG_DM_MSG_CRITICA VG102 
							WHERE VG103.NUM_CERTIFICADO = '{VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CERTIFICADO}' 
							AND VG103.STA_CRITICA IN ( '0'
							, '1'
							, '2'
							, '4'
							, '5'
							, '8' ) 
							AND VG099.STA_CRITICA = VG103.STA_CRITICA 
							AND VG102.COD_MSG_CRITICA = VG103.COD_MSG_CRITICA";

                return query;
            }
            SPBVG001_VG001.GetQueryEvent += GetQuery_SPBVG001_VG001;

        }

        [StopWatch]
        /*" P0308-05-INICIO-DB-OPEN-1 */
        public void P0308_05_INICIO_DB_OPEN_1()
        {
            /*" -1803- EXEC SQL OPEN SPBVG001_VG001 END-EXEC */

            SPBVG001_VG001.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0308_99_EXIT*/

        [StopWatch]
        /*" P0309-FETCH-CURSOR-VG001-SECTION */
        private void P0309_FETCH_CURSOR_VG001_SECTION()
        {
            /*" -1834- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0309_00_START */

            P0309_00_START();

        }

        [StopWatch]
        /*" P0309-00-START */
        private void P0309_00_START(bool isPerform = false)
        {
            /*" -1837- MOVE 'P0309' TO WS-SECTION */
            _.Move("P0309", WORK.WS_ERRO.WS_SECTION);

            /*" -1837- . */

        }

        [StopWatch]
        /*" P0309-05-INICIO */
        private void P0309_05_INICIO(bool isPerform = false)
        {
            /*" -1862- PERFORM P0309_05_INICIO_DB_FETCH_1 */

            P0309_05_INICIO_DB_FETCH_1();

            /*" -1865- IF SQLCODE NOT = 0 AND +100 */

            if (!DB.SQLCODE.In("0", "+100"))
            {

                /*" -1866- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -1867- MOVE VG103-NUM-CERTIFICADO TO WS-DECIMAL(01) */
                _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CERTIFICADO, WORK.WS_EDIT.WS_DECIMAL[01]);

                /*" -1872- STRING WS-SECTION ' - ERRO NO FETCH DO CURSOR SPBVG001_VG001.' ' NUM_CERTIFICADO = ' WS-DECIMAL(01) ' STA_CRITICA = 0' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl86 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl86 += " - ERRO NO FETCH DO CURSOR SPBVG001_VG001.";
                spl86 += " NUM_CERTIFICADO = ";
                var spl87 = WORK.WS_EDIT.WS_DECIMAL[01].GetMoveValues();
                spl87 += " STA_CRITICA = 0";
                var results88 = spl86 + spl87;
                _.Move(results88, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -1874- MOVE 'SEGUROS.VG_CRITICA_PROPOSTA' TO WS-TABELA */
                _.Move("SEGUROS.VG_CRITICA_PROPOSTA", WORK.WS_ERRO.WS_TABELA);

                /*" -1875- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -1876- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -1877- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1879- END-IF */
            }


            /*" -1880- IF SQLCODE EQUAL +100 */

            if (DB.SQLCODE == +100)
            {

                /*" -1882- MOVE 1 TO TESTA-FIM-CURSOR */
                _.Move(1, WORK.TESTA_FIM_CURSOR);

                /*" -1882- PERFORM P0309_05_INICIO_DB_CLOSE_1 */

                P0309_05_INICIO_DB_CLOSE_1();

                /*" -1885- IF SQLCODE NOT = 0 */

                if (DB.SQLCODE != 0)
                {

                    /*" -1886- MOVE 2 TO WS-IND-ERRO */
                    _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                    /*" -1887- MOVE VG103-NUM-CERTIFICADO TO WS-DECIMAL(01) */
                    _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CERTIFICADO, WORK.WS_EDIT.WS_DECIMAL[01]);

                    /*" -1892- STRING WS-SECTION ' - ERRO NO CLOSE DO CURSOR SPBVG001_VG001.' ' NUM_CERTIFICADO = ' WS-DECIMAL(01) ' STA_CRITICA = 0' DELIMITED BY SIZE INTO WS-MENSAGEM */
                    #region STRING
                    var spl88 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                    spl88 += " - ERRO NO CLOSE DO CURSOR SPBVG001_VG001.";
                    spl88 += " NUM_CERTIFICADO = ";
                    var spl89 = WORK.WS_EDIT.WS_DECIMAL[01].GetMoveValues();
                    spl89 += " STA_CRITICA = 0";
                    var results90 = spl88 + spl89;
                    _.Move(results90, WORK.WS_ERRO.WS_MENSAGEM);
                    #endregion

                    /*" -1894- MOVE 'SEGUROS.VG_CRITICA_PROPOSTA' TO WS-TABELA */
                    _.Move("SEGUROS.VG_CRITICA_PROPOSTA", WORK.WS_ERRO.WS_TABELA);

                    /*" -1895- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                    /*" -1896- MOVE SQLERRMC TO WS-SQLERRMC */
                    _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                    /*" -1897- GO TO P9999-ERRO */

                    P9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1898- END-IF */
                }


                /*" -1900- END-IF */
            }


            /*" -1900- . */

        }

        [StopWatch]
        /*" P0309-05-INICIO-DB-FETCH-1 */
        public void P0309_05_INICIO_DB_FETCH_1()
        {
            /*" -1862- EXEC SQL FETCH SPBVG001_VG001 INTO :VG103-NUM-CERTIFICADO ,:VG103-SEQ-CRITICA ,:VG103-IND-TP-PROPOSTA ,:VG103-COD-MSG-CRITICA ,:VG102-DES-MSG-CRITICA ,:VG102-DES-ABREV-MSG-CRITICA ,:VG103-NUM-CPF-CNPJ ,:VG103-NUM-PROPOSTA ,:VG103-VLR-IS ,:VG103-VLR-PREMIO ,:VG103-DTA-OCORRENCIA ,:VG103-DTA-RCAP ,:VG103-STA-CRITICA ,:VG099-DES-STA-CRITICA ,:VG103-DES-COMPLEMENTAR ,:VG103-COD-USUARIO ,:VG103-NOM-PROGRAMA ,:VG103-DTH-CADASTRAMENTO ,:VG102-IND-ALCADA END-EXEC. */

            if (SPBVG001_VG001.Fetch())
            {
                _.Move(SPBVG001_VG001.VG103_NUM_CERTIFICADO, VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CERTIFICADO);
                _.Move(SPBVG001_VG001.VG103_SEQ_CRITICA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_SEQ_CRITICA);
                _.Move(SPBVG001_VG001.VG103_IND_TP_PROPOSTA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_IND_TP_PROPOSTA);
                _.Move(SPBVG001_VG001.VG103_COD_MSG_CRITICA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_COD_MSG_CRITICA);
                _.Move(SPBVG001_VG001.VG102_DES_MSG_CRITICA, VG102.DCLVG_DM_MSG_CRITICA.VG102_DES_MSG_CRITICA);
                _.Move(SPBVG001_VG001.VG102_DES_ABREV_MSG_CRITICA, VG102.DCLVG_DM_MSG_CRITICA.VG102_DES_ABREV_MSG_CRITICA);
                _.Move(SPBVG001_VG001.VG103_NUM_CPF_CNPJ, VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CPF_CNPJ);
                _.Move(SPBVG001_VG001.VG103_NUM_PROPOSTA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_PROPOSTA);
                _.Move(SPBVG001_VG001.VG103_VLR_IS, VG103.DCLVG_CRITICA_PROPOSTA.VG103_VLR_IS);
                _.Move(SPBVG001_VG001.VG103_VLR_PREMIO, VG103.DCLVG_CRITICA_PROPOSTA.VG103_VLR_PREMIO);
                _.Move(SPBVG001_VG001.VG103_DTA_OCORRENCIA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_DTA_OCORRENCIA);
                _.Move(SPBVG001_VG001.VG103_DTA_RCAP, VG103.DCLVG_CRITICA_PROPOSTA.VG103_DTA_RCAP);
                _.Move(SPBVG001_VG001.VG103_STA_CRITICA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_STA_CRITICA);
                _.Move(SPBVG001_VG001.VG099_DES_STA_CRITICA, VG099.DCLVG_DM_STA_CRITICA.VG099_DES_STA_CRITICA);
                _.Move(SPBVG001_VG001.VG103_DES_COMPLEMENTAR, VG103.DCLVG_CRITICA_PROPOSTA.VG103_DES_COMPLEMENTAR);
                _.Move(SPBVG001_VG001.VG103_COD_USUARIO, VG103.DCLVG_CRITICA_PROPOSTA.VG103_COD_USUARIO);
                _.Move(SPBVG001_VG001.VG103_NOM_PROGRAMA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_NOM_PROGRAMA);
                _.Move(SPBVG001_VG001.VG103_DTH_CADASTRAMENTO, VG103.DCLVG_CRITICA_PROPOSTA.VG103_DTH_CADASTRAMENTO);
                _.Move(SPBVG001_VG001.VG102_IND_ALCADA, VG102.DCLVG_DM_MSG_CRITICA.VG102_IND_ALCADA);
            }

        }

        [StopWatch]
        /*" P0309-05-INICIO-DB-CLOSE-1 */
        public void P0309_05_INICIO_DB_CLOSE_1()
        {
            /*" -1882- EXEC SQL CLOSE SPBVG001_VG001 END-EXEC */

            SPBVG001_VG001.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0309_99_EXIT*/

        [StopWatch]
        /*" P0310-ALTERAR-STATUS-PEND-SECTION */
        private void P0310_ALTERAR_STATUS_PEND_SECTION()
        {
            /*" -1910- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0310_00_START */

            P0310_00_START();

        }

        [StopWatch]
        /*" P0310-00-START */
        private void P0310_00_START(bool isPerform = false)
        {
            /*" -1913- MOVE 'P0310' TO WS-SECTION */
            _.Move("P0310", WORK.WS_ERRO.WS_SECTION);

            /*" -1914- MOVE LK-VG001-STA-CRITICA TO WS-STA-CRITICA */
            _.Move(SPVG001W.LK_VG001_STA_CRITICA, WH_AUXILIAR.WS_STA_CRITICA);

            /*" -1914- PERFORM P0310-05-INICIO. */

            P0310_05_INICIO(true);

        }

        [StopWatch]
        /*" P0310-05-INICIO */
        private void P0310_05_INICIO(bool isPerform = false)
        {
            /*" -1920- IF VG103-STA-CRITICA EQUAL '8' */

            if (VG103.DCLVG_CRITICA_PROPOSTA.VG103_STA_CRITICA == "8")
            {

                /*" -1921- IF WS-STA-CRITICA NOT EQUAL 'A' */

                if (WH_AUXILIAR.WS_STA_CRITICA != "A")
                {

                    /*" -1922- MOVE '3' TO LK-VG001-STA-CRITICA */
                    _.Move("3", SPVG001W.LK_VG001_STA_CRITICA);

                    /*" -1923- ELSE */
                }
                else
                {


                    /*" -1924- MOVE 'A' TO LK-VG001-STA-CRITICA */
                    _.Move("A", SPVG001W.LK_VG001_STA_CRITICA);

                    /*" -1925- END-IF */
                }


                /*" -1926- ELSE */
            }
            else
            {


                /*" -1927- MOVE '9' TO LK-VG001-STA-CRITICA */
                _.Move("9", SPVG001W.LK_VG001_STA_CRITICA);

                /*" -1929- END-IF */
            }


            /*" -1931- PERFORM P0303-TRATAR-TIPO-ACAO-03 */

            P0303_TRATAR_TIPO_ACAO_03_SECTION();

            /*" -1932- PERFORM P0309-FETCH-CURSOR-VG001 */

            P0309_FETCH_CURSOR_VG001_SECTION();

            /*" -1932- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0310_99_EXIT*/

        [StopWatch]
        /*" P0351-VALIDAR-STATUS-ALCADA-SECTION */
        private void P0351_VALIDAR_STATUS_ALCADA_SECTION()
        {
            /*" -1944- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0351_00_START */

            P0351_00_START();

        }

        [StopWatch]
        /*" P0351-00-START */
        private void P0351_00_START(bool isPerform = false)
        {
            /*" -1947- MOVE 'P0351' TO WS-SECTION. */
            _.Move("P0351", WORK.WS_ERRO.WS_SECTION);

            /*" -1948- MOVE 'N' TO WS-IND-P0351 */
            _.Move("N", WORK.WS_INDICADORES.WS_IND_P0351);

            /*" -1949- MOVE LK-VG001-S-STA-PARA(WS-I:1) TO VG101-STA-CRITICA */
            _.Move(SPVG001W.LK_VG001_S_STA_PARA.Substring(WORK.WS_CONTADORES.WS_I, 1), VG101.DCLVG_RELAC_STATUS_ALCADA.VG101_STA_CRITICA);

            /*" -1950- MOVE USUFILSE-TIPO-FUNCAO TO VG101-COD-TIPO-FUNCAO */
            _.Move(USUFILSE.DCLUSU_FIL_SENHA.USUFILSE_TIPO_FUNCAO, VG101.DCLVG_RELAC_STATUS_ALCADA.VG101_COD_TIPO_FUNCAO);

            /*" -1953- MOVE USUFILSE-NIVEL-AUTORIZACAO TO VG101-COD-NIVEL-AUTORIZACAO */
            _.Move(USUFILSE.DCLUSU_FIL_SENHA.USUFILSE_NIVEL_AUTORIZACAO, VG101.DCLVG_RELAC_STATUS_ALCADA.VG101_COD_NIVEL_AUTORIZACAO);

            /*" -1953- . */

        }

        [StopWatch]
        /*" P0351-05-INICIO */
        private void P0351_05_INICIO(bool isPerform = false)
        {
            /*" -1965- PERFORM P0351_05_INICIO_DB_SELECT_1 */

            P0351_05_INICIO_DB_SELECT_1();

            /*" -1968- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -1969- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -1970- MOVE VG102-COD-MSG-CRITICA TO WS-SMALLINT(01) */
                _.Move(VG102.DCLVG_DM_MSG_CRITICA.VG102_COD_MSG_CRITICA, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -1977- STRING WS-SECTION ' - ERRO NO SELECT SEGUROS.VG_RELAC_STATUS_ALCADA.' ' COD_USUARIO = ' LK-VG001-COD-USUARIO '/STA_CRITICA = ' VG101-STA-CRITICA '/COD_TIPO_FUNCAO = ' VG101-COD-TIPO-FUNCAO '/NIVEL_AUTORIZACAO = ' VG101-COD-NIVEL-AUTORIZACAO DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl90 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl90 += " - ERRO NO SELECT SEGUROS.VG_RELAC_STATUS_ALCADA.";
                spl90 += " COD_USUARIO = ";
                var spl91 = SPVG001W.LK_VG001_COD_USUARIO.GetMoveValues();
                spl91 += "/STA_CRITICA = ";
                var spl92 = VG101.DCLVG_RELAC_STATUS_ALCADA.VG101_STA_CRITICA.GetMoveValues();
                spl92 += "/COD_TIPO_FUNCAO = ";
                var spl93 = VG101.DCLVG_RELAC_STATUS_ALCADA.VG101_COD_TIPO_FUNCAO.GetMoveValues();
                spl93 += "/NIVEL_AUTORIZACAO = ";
                var spl94 = VG101.DCLVG_RELAC_STATUS_ALCADA.VG101_COD_NIVEL_AUTORIZACAO.GetMoveValues();
                var results95 = spl90 + spl91 + spl92 + spl93 + spl94;
                _.Move(results95, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -1979- MOVE 'SEGUROS.VG_RELAC_STATUS_ALCADA' TO WS-TABELA */
                _.Move("SEGUROS.VG_RELAC_STATUS_ALCADA", WORK.WS_ERRO.WS_TABELA);

                /*" -1980- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -1981- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -1982- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1984- END-IF */
            }


            /*" -1985- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1986- MOVE 'N' TO WS-IND-P0351 */
                _.Move("N", WORK.WS_INDICADORES.WS_IND_P0351);

                /*" -1987- ELSE */
            }
            else
            {


                /*" -1988- MOVE 'S' TO WS-IND-P0351 */
                _.Move("S", WORK.WS_INDICADORES.WS_IND_P0351);

                /*" -1990- END-IF */
            }


            /*" -1990- . */

        }

        [StopWatch]
        /*" P0351-05-INICIO-DB-SELECT-1 */
        public void P0351_05_INICIO_DB_SELECT_1()
        {
            /*" -1965- EXEC SQL SELECT VG101.STA_CRITICA INTO :VG101-STA-CRITICA FROM SEGUROS.VG_RELAC_STATUS_ALCADA VG101 WHERE VG101.STA_CRITICA = :VG101-STA-CRITICA AND VG101.COD_TIPO_FUNCAO = :VG101-COD-TIPO-FUNCAO AND VG101.COD_NIVEL_AUTORIZACAO = :VG101-COD-NIVEL-AUTORIZACAO END-EXEC */

            var p0351_05_INICIO_DB_SELECT_1_Query1 = new P0351_05_INICIO_DB_SELECT_1_Query1()
            {
                VG101_COD_NIVEL_AUTORIZACAO = VG101.DCLVG_RELAC_STATUS_ALCADA.VG101_COD_NIVEL_AUTORIZACAO.ToString(),
                VG101_COD_TIPO_FUNCAO = VG101.DCLVG_RELAC_STATUS_ALCADA.VG101_COD_TIPO_FUNCAO.ToString(),
                VG101_STA_CRITICA = VG101.DCLVG_RELAC_STATUS_ALCADA.VG101_STA_CRITICA.ToString(),
            };

            var executed_1 = P0351_05_INICIO_DB_SELECT_1_Query1.Execute(p0351_05_INICIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VG101_STA_CRITICA, VG101.DCLVG_RELAC_STATUS_ALCADA.VG101_STA_CRITICA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0351_99_EXIT*/

        [StopWatch]
        /*" P0801-PESQUISAR-BILHETE-SECTION */
        private void P0801_PESQUISAR_BILHETE_SECTION()
        {
            /*" -2002- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0801_00_START */

            P0801_00_START();

        }

        [StopWatch]
        /*" P0801-00-START */
        private void P0801_00_START(bool isPerform = false)
        {
            /*" -2005- MOVE 'P0801' TO WS-SECTION */
            _.Move("P0801", WORK.WS_ERRO.WS_SECTION);

            /*" -2007- MOVE LK-VG001-NUM-CERTIFICADO TO BILHETE-NUM-BILHETE */
            _.Move(SPVG001W.LK_VG001_NUM_CERTIFICADO, BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE);

            /*" -2007- PERFORM P0801-05-INICIO. */

            P0801_05_INICIO(true);

        }

        [StopWatch]
        /*" P0801-05-INICIO */
        private void P0801_05_INICIO(bool isPerform = false)
        {
            /*" -2057- PERFORM P0801_05_INICIO_DB_SELECT_1 */

            P0801_05_INICIO_DB_SELECT_1();

            /*" -2060- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -2061- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -2062- MOVE BILHETE-NUM-BILHETE TO WS-DECIMAL(01) */
                _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE, WORK.WS_EDIT.WS_DECIMAL[01]);

                /*" -2066- STRING WS-SECTION ' - ERRO NO SELECT SEGUROS.BILHETE.' ' NUM_CERTIFICADO = ' WS-DECIMAL(01) DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl95 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl95 += " - ERRO NO SELECT SEGUROS.BILHETE.";
                spl95 += " NUM_CERTIFICADO = ";
                var spl96 = WORK.WS_EDIT.WS_DECIMAL[01].GetMoveValues();
                var results97 = spl95 + spl96;
                _.Move(results97, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -2068- MOVE 'SEGUROS.BILHETE' TO WS-TABELA */
                _.Move("SEGUROS.BILHETE", WORK.WS_ERRO.WS_TABELA);

                /*" -2069- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -2070- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -2071- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -2073- END-IF */
            }


            /*" -2074- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2075- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -2076- MOVE BILHETE-NUM-BILHETE TO WS-DECIMAL(01) */
                _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE, WORK.WS_EDIT.WS_DECIMAL[01]);

                /*" -2080- STRING WS-SECTION ' - INFORMACOES DE BILHETE NAO ENCONTRADA.' ' NUM_BILHETE = ' WS-DECIMAL(01) DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl97 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl97 += " - INFORMACOES DE BILHETE NAO ENCONTRADA.";
                spl97 += " NUM_BILHETE = ";
                var spl98 = WORK.WS_EDIT.WS_DECIMAL[01].GetMoveValues();
                var results99 = spl97 + spl98;
                _.Move(results99, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -2081- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -2082- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -2083- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -2085- END-IF */
            }


            /*" -2086- IF BILHETE-COD-PRODUTO > 0 */

            if (BILHETE.DCLBILHETE.BILHETE_COD_PRODUTO > 0)
            {

                /*" -2087- PERFORM P1000-CALL-GE0070S */

                P1000_CALL_GE0070S_SECTION();

                /*" -2089- END-IF */
            }


            /*" -2090- IF LK-0070-S-IND-FLUXO-PARAM = 'S' */

            if (GE0070W.LK_0070_S_IND_FLUXO_PARAM == "S")
            {

                /*" -2091- PERFORM P1001-CALL-GE0071S */

                P1001_CALL_GE0071S_SECTION();

                /*" -2092- MOVE LK-0071-S-VLR-INI-PREMIO TO VG103-VLR-PREMIO */
                _.Move(GE0071W.LK_0071_S_VLR_INI_PREMIO, VG103.DCLVG_CRITICA_PROPOSTA.VG103_VLR_PREMIO);

                /*" -2093- MOVE LK-0071-S-VLR-TOTAL-IS TO VG103-VLR-IS */
                _.Move(GE0071W.LK_0071_S_VLR_TOTAL_IS, VG103.DCLVG_CRITICA_PROPOSTA.VG103_VLR_IS);

                /*" -2094- ELSE */
            }
            else
            {


                /*" -2095- PERFORM P1010-BILHETE-COBERTURA */

                P1010_BILHETE_COBERTURA_SECTION();

                /*" -2097- END-IF */
            }


            /*" -2099- PERFORM P0850-PESQUISAR-MAX-CRITC-PROP */

            P0850_PESQUISAR_MAX_CRITC_PROP_SECTION();

            /*" -2100- MOVE LK-VG001-IND-TP-PROPOSTA TO VG103-IND-TP-PROPOSTA */
            _.Move(SPVG001W.LK_VG001_IND_TP_PROPOSTA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_IND_TP_PROPOSTA);

            /*" -2102- MOVE LK-VG001-COD-MSG-CRITICA TO VG103-COD-MSG-CRITICA */
            _.Move(SPVG001W.LK_VG001_COD_MSG_CRITICA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_COD_MSG_CRITICA);

            /*" -2103- MOVE NUM-PROPOSTA-SIVPF TO VG103-NUM-PROPOSTA */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF, VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_PROPOSTA);

            /*" -2104- IF VG103-NUM-PROPOSTA = 0 */

            if (VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_PROPOSTA == 0)
            {

                /*" -2105- MOVE -1 TO WH-VG103INUM-PROPOSTA */
                _.Move(-1, WH_AUXILIAR.WH_VG103INUM_PROPOSTA);

                /*" -2106- ELSE */
            }
            else
            {


                /*" -2107- MOVE 0 TO WH-VG103INUM-PROPOSTA */
                _.Move(0, WH_AUXILIAR.WH_VG103INUM_PROPOSTA);

                /*" -2110- END-IF */
            }


            /*" -2111- MOVE WH-VG103-DES-COMPLEMENTAR TO VG103-DES-COMPLEMENTAR */
            _.Move(WH_AUXILIAR.WH_VG103_DES_COMPLEMENTAR, VG103.DCLVG_CRITICA_PROPOSTA.VG103_DES_COMPLEMENTAR);

            /*" -2112- IF WH-VG103-DES-COMPLEMENTAR-LEN = 0 */

            if (WH_AUXILIAR.WH_VG103_DES_COMPLEMENTAR.WH_VG103_DES_COMPLEMENTAR_LEN == 0)
            {

                /*" -2113- MOVE -1 TO WH-VG103IDES-COMPLEMENTAR */
                _.Move(-1, WH_AUXILIAR.WH_VG103IDES_COMPLEMENTAR);

                /*" -2114- ELSE */
            }
            else
            {


                /*" -2115- MOVE 0 TO WH-VG103IDES-COMPLEMENTAR */
                _.Move(0, WH_AUXILIAR.WH_VG103IDES_COMPLEMENTAR);

                /*" -2117- END-IF. */
            }


            /*" -2118- PERFORM P0851-BUSCAR-TIMESTAMP */

            P0851_BUSCAR_TIMESTAMP_SECTION();

            /*" -2119- MOVE WH-CURRENT-TIMESTAMP TO VG103-DTH-CADASTRAMENTO */
            _.Move(WH_AUXILIAR.WH_CURRENT_TIMESTAMP, VG103.DCLVG_CRITICA_PROPOSTA.VG103_DTH_CADASTRAMENTO);

            /*" -2120- MOVE LK-VG001-COD-USUARIO TO VG103-COD-USUARIO */
            _.Move(SPVG001W.LK_VG001_COD_USUARIO, VG103.DCLVG_CRITICA_PROPOSTA.VG103_COD_USUARIO);

            /*" -2122- MOVE LK-VG001-NOM-PROGRAMA TO VG103-NOM-PROGRAMA */
            _.Move(SPVG001W.LK_VG001_NOM_PROGRAMA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_NOM_PROGRAMA);

            /*" -2123- IF VG103-DTA-RCAP = '0001-01-01' */

            if (VG103.DCLVG_CRITICA_PROPOSTA.VG103_DTA_RCAP == "0001-01-01")
            {

                /*" -2124- MOVE DATA-CREDITO TO VG103-DTA-RCAP */
                _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.DATA_CREDITO, VG103.DCLVG_CRITICA_PROPOSTA.VG103_DTA_RCAP);

                /*" -2126- END-IF */
            }


            /*" -2128- PERFORM P0820-INSERIR-VG103 */

            P0820_INSERIR_VG103_SECTION();

            /*" -2130- PERFORM P0821-INSERIR-VG104 */

            P0821_INSERIR_VG104_SECTION();

            /*" -2130- . */

        }

        [StopWatch]
        /*" P0801-05-INICIO-DB-SELECT-1 */
        public void P0801_05_INICIO_DB_SELECT_1()
        {
            /*" -2057- EXEC SQL SELECT BI001.NUM_BILHETE ,CL001.CGCCPF ,BI001.DATA_MOVIMENTO ,VALUE(MB001.DATA_QUITACAO, '0001-01-01' ) ,VALUE(PF001.DATA_CREDITO, '0001-01-01' ) ,CASE WHEN VALUE(PF001.NUM_PROPOSTA_SIVPF,0) > 0 THEN PF001.NUM_PROPOSTA_SIVPF ELSE VALUE(CS001.NUM_PROPOSTA_SIVPF,0) END ,VALUE(BI001.COD_PRODUTO,0) ,BI001.RAMO ,BI001.OPC_COBERTURA ,BI001.DATA_QUITACAO ,BI001.DATA_VENDA ,CL001.DATA_NASCIMENTO ,YEAR(BI001.DATA_QUITACAO - CL001.DATA_NASCIMENTO) INTO :VG103-NUM-CERTIFICADO ,:VG103-NUM-CPF-CNPJ ,:VG103-DTA-OCORRENCIA ,:VG103-DTA-RCAP ,:DATA-CREDITO ,:NUM-PROPOSTA-SIVPF ,:BILHETE-COD-PRODUTO ,:BILHETE-RAMO ,:BILHETE-OPC-COBERTURA ,:BILHETE-DATA-QUITACAO ,:BILHETE-DATA-VENDA ,:CLIENTES-DATA-NASCIMENTO ,:WH-IDADE FROM SEGUROS.CLIENTES CL001 ,SEGUROS.BILHETE BI001 LEFT JOIN SEGUROS.MOVIMENTO_COBRANCA MB001 ON MB001.NUM_TITULO = BI001.NUM_BILHETE LEFT JOIN SEGUROS.PROPOSTA_FIDELIZ PF001 ON PF001.NUM_SICOB = BI001.NUM_BILHETE LEFT JOIN SEGUROS.CONVERSAO_SICOB CS001 ON CS001.NUM_SICOB = BI001.NUM_BILHETE WHERE BI001.NUM_BILHETE = :BILHETE-NUM-BILHETE AND CL001.COD_CLIENTE = BI001.COD_CLIENTE WITH UR END-EXEC */

            var p0801_05_INICIO_DB_SELECT_1_Query1 = new P0801_05_INICIO_DB_SELECT_1_Query1()
            {
                BILHETE_NUM_BILHETE = BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE.ToString(),
            };

            var executed_1 = P0801_05_INICIO_DB_SELECT_1_Query1.Execute(p0801_05_INICIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VG103_NUM_CERTIFICADO, VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CERTIFICADO);
                _.Move(executed_1.VG103_NUM_CPF_CNPJ, VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CPF_CNPJ);
                _.Move(executed_1.VG103_DTA_OCORRENCIA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_DTA_OCORRENCIA);
                _.Move(executed_1.VG103_DTA_RCAP, VG103.DCLVG_CRITICA_PROPOSTA.VG103_DTA_RCAP);
                _.Move(executed_1.DATA_CREDITO, PROPFID.DCLPROPOSTA_FIDELIZ.DATA_CREDITO);
                _.Move(executed_1.NUM_PROPOSTA_SIVPF, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF);
                _.Move(executed_1.BILHETE_COD_PRODUTO, BILHETE.DCLBILHETE.BILHETE_COD_PRODUTO);
                _.Move(executed_1.BILHETE_RAMO, BILHETE.DCLBILHETE.BILHETE_RAMO);
                _.Move(executed_1.BILHETE_OPC_COBERTURA, BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA);
                _.Move(executed_1.BILHETE_DATA_QUITACAO, BILHETE.DCLBILHETE.BILHETE_DATA_QUITACAO);
                _.Move(executed_1.BILHETE_DATA_VENDA, BILHETE.DCLBILHETE.BILHETE_DATA_VENDA);
                _.Move(executed_1.CLIENTES_DATA_NASCIMENTO, CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);
                _.Move(executed_1.WH_IDADE, WH_AUXILIAR.WH_IDADE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0801_99_EXIT*/

        [StopWatch]
        /*" P0802-PESQUISAR-PROPOSTAS-VA-SECTION */
        private void P0802_PESQUISAR_PROPOSTAS_VA_SECTION()
        {
            /*" -2142- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0802_00_START */

            P0802_00_START();

        }

        [StopWatch]
        /*" P0802-00-START */
        private void P0802_00_START(bool isPerform = false)
        {
            /*" -2145- MOVE 'P0802' TO WS-SECTION */
            _.Move("P0802", WORK.WS_ERRO.WS_SECTION);

            /*" -2147- MOVE LK-VG001-NUM-CERTIFICADO TO VG103-NUM-CERTIFICADO */
            _.Move(SPVG001W.LK_VG001_NUM_CERTIFICADO, VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CERTIFICADO);

            /*" -2147- . */

        }

        [StopWatch]
        /*" P0802-05-INICIO */
        private void P0802_05_INICIO(bool isPerform = false)
        {
            /*" -2172- PERFORM P0802_05_INICIO_DB_SELECT_1 */

            P0802_05_INICIO_DB_SELECT_1();

            /*" -2175- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -2176- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -2177- MOVE VG103-NUM-CERTIFICADO TO WS-DECIMAL(01) */
                _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CERTIFICADO, WORK.WS_EDIT.WS_DECIMAL[01]);

                /*" -2181- STRING WS-SECTION ' - ERRO NO SELECT SEGUROS.PROPOSTAS_VA.' ' NUM_CERTIFICADO = ' WS-DECIMAL(01) DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl99 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl99 += " - ERRO NO SELECT SEGUROS.PROPOSTAS_VA.";
                spl99 += " NUM_CERTIFICADO = ";
                var spl100 = WORK.WS_EDIT.WS_DECIMAL[01].GetMoveValues();
                var results101 = spl99 + spl100;
                _.Move(results101, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -2183- MOVE 'SEGUROS.PROPOSTAS_VA' TO WS-TABELA */
                _.Move("SEGUROS.PROPOSTAS_VA", WORK.WS_ERRO.WS_TABELA);

                /*" -2184- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -2185- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -2186- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -2188- END-IF */
            }


            /*" -2189- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2190- IF LK-VG001-IND-TP-PROPOSTA = 'MD' */

                if (SPVG001W.LK_VG001_IND_TP_PROPOSTA == "MD")
                {

                    /*" -2194- MOVE ZEROS TO VG103-NUM-CPF-CNPJ VG103-VLR-IS VG103-VLR-PREMIO */
                    _.Move(0, VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CPF_CNPJ, VG103.DCLVG_CRITICA_PROPOSTA.VG103_VLR_IS, VG103.DCLVG_CRITICA_PROPOSTA.VG103_VLR_PREMIO);

                    /*" -2196- MOVE '0001-01-01' TO VG103-DTA-OCORRENCIA VG103-DTA-RCAP */
                    _.Move("0001-01-01", VG103.DCLVG_CRITICA_PROPOSTA.VG103_DTA_OCORRENCIA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_DTA_RCAP);

                    /*" -2197- ELSE */
                }
                else
                {


                    /*" -2198- MOVE 1 TO WS-IND-ERRO */
                    _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                    /*" -2199- MOVE VG103-NUM-CERTIFICADO TO WS-DECIMAL(01) */
                    _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CERTIFICADO, WORK.WS_EDIT.WS_DECIMAL[01]);

                    /*" -2203- STRING WS-SECTION ' - INFORMACOES DE CERTIFICADO NAO ENCONTRADA.' ' NUM_CERTIFICADO = ' WS-DECIMAL(01) DELIMITED BY SIZE INTO WS-MENSAGEM */
                    #region STRING
                    var spl101 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                    spl101 += " - INFORMACOES DE CERTIFICADO NAO ENCONTRADA.";
                    spl101 += " NUM_CERTIFICADO = ";
                    var spl102 = WORK.WS_EDIT.WS_DECIMAL[01].GetMoveValues();
                    var results103 = spl101 + spl102;
                    _.Move(results103, WORK.WS_ERRO.WS_MENSAGEM);
                    #endregion

                    /*" -2204- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                    _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                    /*" -2205- MOVE 0 TO WS-SQLCODE */
                    _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                    /*" -2206- GO TO P9999-ERRO */

                    P9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2207- END-IF */
                }


                /*" -2209- END-IF */
            }


            /*" -2210- IF LK-VG001-IND-TP-PROPOSTA = 'MD' */

            if (SPVG001W.LK_VG001_IND_TP_PROPOSTA == "MD")
            {

                /*" -2211- MOVE 'PF' TO LK-VG001-IND-TP-PROPOSTA */
                _.Move("PF", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

                /*" -2213- END-IF */
            }


            /*" -2215- PERFORM P0850-PESQUISAR-MAX-CRITC-PROP */

            P0850_PESQUISAR_MAX_CRITC_PROP_SECTION();

            /*" -2216- MOVE LK-VG001-IND-TP-PROPOSTA TO VG103-IND-TP-PROPOSTA */
            _.Move(SPVG001W.LK_VG001_IND_TP_PROPOSTA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_IND_TP_PROPOSTA);

            /*" -2217- MOVE LK-VG001-COD-MSG-CRITICA TO VG103-COD-MSG-CRITICA */
            _.Move(SPVG001W.LK_VG001_COD_MSG_CRITICA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_COD_MSG_CRITICA);

            /*" -2218- MOVE VG103-NUM-CERTIFICADO TO VG103-NUM-PROPOSTA */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CERTIFICADO, VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_PROPOSTA);

            /*" -2219- IF VG103-NUM-PROPOSTA = 0 */

            if (VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_PROPOSTA == 0)
            {

                /*" -2220- MOVE -1 TO WH-VG103INUM-PROPOSTA */
                _.Move(-1, WH_AUXILIAR.WH_VG103INUM_PROPOSTA);

                /*" -2221- ELSE */
            }
            else
            {


                /*" -2222- MOVE 0 TO WH-VG103INUM-PROPOSTA */
                _.Move(0, WH_AUXILIAR.WH_VG103INUM_PROPOSTA);

                /*" -2225- END-IF */
            }


            /*" -2226- MOVE WH-VG103-DES-COMPLEMENTAR TO VG103-DES-COMPLEMENTAR */
            _.Move(WH_AUXILIAR.WH_VG103_DES_COMPLEMENTAR, VG103.DCLVG_CRITICA_PROPOSTA.VG103_DES_COMPLEMENTAR);

            /*" -2227- IF WH-VG103-DES-COMPLEMENTAR-LEN = 0 */

            if (WH_AUXILIAR.WH_VG103_DES_COMPLEMENTAR.WH_VG103_DES_COMPLEMENTAR_LEN == 0)
            {

                /*" -2228- MOVE -1 TO WH-VG103IDES-COMPLEMENTAR */
                _.Move(-1, WH_AUXILIAR.WH_VG103IDES_COMPLEMENTAR);

                /*" -2229- ELSE */
            }
            else
            {


                /*" -2230- MOVE 0 TO WH-VG103IDES-COMPLEMENTAR */
                _.Move(0, WH_AUXILIAR.WH_VG103IDES_COMPLEMENTAR);

                /*" -2232- END-IF. */
            }


            /*" -2233- PERFORM P0851-BUSCAR-TIMESTAMP */

            P0851_BUSCAR_TIMESTAMP_SECTION();

            /*" -2234- MOVE WH-CURRENT-TIMESTAMP TO VG103-DTH-CADASTRAMENTO */
            _.Move(WH_AUXILIAR.WH_CURRENT_TIMESTAMP, VG103.DCLVG_CRITICA_PROPOSTA.VG103_DTH_CADASTRAMENTO);

            /*" -2235- MOVE LK-VG001-COD-USUARIO TO VG103-COD-USUARIO */
            _.Move(SPVG001W.LK_VG001_COD_USUARIO, VG103.DCLVG_CRITICA_PROPOSTA.VG103_COD_USUARIO);

            /*" -2237- MOVE LK-VG001-NOM-PROGRAMA TO VG103-NOM-PROGRAMA */
            _.Move(SPVG001W.LK_VG001_NOM_PROGRAMA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_NOM_PROGRAMA);

            /*" -2239- PERFORM P0820-INSERIR-VG103 */

            P0820_INSERIR_VG103_SECTION();

            /*" -2241- PERFORM P0821-INSERIR-VG104 */

            P0821_INSERIR_VG104_SECTION();

            /*" -2241- . */

        }

        [StopWatch]
        /*" P0802-05-INICIO-DB-SELECT-1 */
        public void P0802_05_INICIO_DB_SELECT_1()
        {
            /*" -2172- EXEC SQL SELECT PV001.NUM_CERTIFICADO ,CL001.CGCCPF ,HC001.IMPSEGUR ,HC001.VLPREMIO ,PV001.DTINCLUS ,PV001.DATA_QUITACAO INTO :VG103-NUM-CERTIFICADO ,:VG103-NUM-CPF-CNPJ ,:VG103-VLR-IS ,:VG103-VLR-PREMIO ,:VG103-DTA-OCORRENCIA ,:VG103-DTA-RCAP FROM SEGUROS.HIS_COBER_PROPOST HC001 ,SEGUROS.CLIENTES CL001 ,SEGUROS.PROPOSTAS_VA PV001 WHERE PV001.NUM_CERTIFICADO = :VG103-NUM-CERTIFICADO AND HC001.NUM_CERTIFICADO = PV001.NUM_CERTIFICADO AND CL001.COD_CLIENTE = PV001.COD_CLIENTE AND HC001.DATA_TERVIGENCIA = '9999-12-31' WITH UR END-EXEC */

            var p0802_05_INICIO_DB_SELECT_1_Query1 = new P0802_05_INICIO_DB_SELECT_1_Query1()
            {
                VG103_NUM_CERTIFICADO = VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = P0802_05_INICIO_DB_SELECT_1_Query1.Execute(p0802_05_INICIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VG103_NUM_CERTIFICADO, VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CERTIFICADO);
                _.Move(executed_1.VG103_NUM_CPF_CNPJ, VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CPF_CNPJ);
                _.Move(executed_1.VG103_VLR_IS, VG103.DCLVG_CRITICA_PROPOSTA.VG103_VLR_IS);
                _.Move(executed_1.VG103_VLR_PREMIO, VG103.DCLVG_CRITICA_PROPOSTA.VG103_VLR_PREMIO);
                _.Move(executed_1.VG103_DTA_OCORRENCIA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_DTA_OCORRENCIA);
                _.Move(executed_1.VG103_DTA_RCAP, VG103.DCLVG_CRITICA_PROPOSTA.VG103_DTA_RCAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0802_99_EXIT*/

        [StopWatch]
        /*" P0803-PESQUISAR-VG-SOLIC-FAT-SECTION */
        private void P0803_PESQUISAR_VG_SOLIC_FAT_SECTION()
        {
            /*" -2253- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0803_00_START */

            P0803_00_START();

        }

        [StopWatch]
        /*" P0803-00-START */
        private void P0803_00_START(bool isPerform = false)
        {
            /*" -2256- MOVE 'P0803' TO WS-SECTION */
            _.Move("P0803", WORK.WS_ERRO.WS_SECTION);

            /*" -2258- MOVE LK-VG001-NUM-CERTIFICADO TO VGSOLFAT-NUM-TITULO */
            _.Move(SPVG001W.LK_VG001_NUM_CERTIFICADO, VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_TITULO);

            /*" -2258- . */

        }

        [StopWatch]
        /*" P0803-05-INICIO */
        private void P0803_05_INICIO(bool isPerform = false)
        {
            /*" -2264- MOVE 'P0803' TO WS-SECTION */
            _.Move("P0803", WORK.WS_ERRO.WS_SECTION);

            /*" -2287- PERFORM P0803_05_INICIO_DB_SELECT_1 */

            P0803_05_INICIO_DB_SELECT_1();

            /*" -2290- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -2291- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -2292- MOVE VGSOLFAT-NUM-TITULO TO WS-DECIMAL(01) */
                _.Move(VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_TITULO, WORK.WS_EDIT.WS_DECIMAL[01]);

                /*" -2296- STRING WS-SECTION ' - ERRO NO SELECT SEGUROS.VG_SOLICITA_FATURA.' ' NUM_CERTIFICADO = ' WS-DECIMAL(01) DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl103 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl103 += " - ERRO NO SELECT SEGUROS.VG_SOLICITA_FATURA.";
                spl103 += " NUM_CERTIFICADO = ";
                var spl104 = WORK.WS_EDIT.WS_DECIMAL[01].GetMoveValues();
                var results105 = spl103 + spl104;
                _.Move(results105, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -2298- MOVE 'SEGUROS.VG_SOLICITA_FATURA' TO WS-TABELA */
                _.Move("SEGUROS.VG_SOLICITA_FATURA", WORK.WS_ERRO.WS_TABELA);

                /*" -2299- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -2300- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -2301- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -2303- END-IF */
            }


            /*" -2304- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2305- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -2306- MOVE VGSOLFAT-NUM-TITULO TO WS-DECIMAL(01) */
                _.Move(VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_TITULO, WORK.WS_EDIT.WS_DECIMAL[01]);

                /*" -2310- STRING WS-SECTION ' - INFORMACOES DE CERTIFICADO NAO ENCONTRADO.' ' NUM_CERTIFICADO = ' WS-DECIMAL(01) DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl105 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl105 += " - INFORMACOES DE CERTIFICADO NAO ENCONTRADO.";
                spl105 += " NUM_CERTIFICADO = ";
                var spl106 = WORK.WS_EDIT.WS_DECIMAL[01].GetMoveValues();
                var results107 = spl105 + spl106;
                _.Move(results107, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -2311- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -2312- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -2313- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -2315- END-IF */
            }


            /*" -2317- PERFORM P0850-PESQUISAR-MAX-CRITC-PROP */

            P0850_PESQUISAR_MAX_CRITC_PROP_SECTION();

            /*" -2318- MOVE LK-VG001-IND-TP-PROPOSTA TO VG103-IND-TP-PROPOSTA */
            _.Move(SPVG001W.LK_VG001_IND_TP_PROPOSTA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_IND_TP_PROPOSTA);

            /*" -2319- MOVE LK-VG001-COD-MSG-CRITICA TO VG103-COD-MSG-CRITICA */
            _.Move(SPVG001W.LK_VG001_COD_MSG_CRITICA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_COD_MSG_CRITICA);

            /*" -2320- IF VG103-NUM-PROPOSTA > 0 */

            if (VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_PROPOSTA > 0)
            {

                /*" -2321- MOVE 0 TO WH-VG103INUM-PROPOSTA */
                _.Move(0, WH_AUXILIAR.WH_VG103INUM_PROPOSTA);

                /*" -2322- ELSE */
            }
            else
            {


                /*" -2323- MOVE -1 TO WH-VG103INUM-PROPOSTA */
                _.Move(-1, WH_AUXILIAR.WH_VG103INUM_PROPOSTA);

                /*" -2326- END-IF */
            }


            /*" -2327- MOVE WH-VG103-DES-COMPLEMENTAR TO VG103-DES-COMPLEMENTAR */
            _.Move(WH_AUXILIAR.WH_VG103_DES_COMPLEMENTAR, VG103.DCLVG_CRITICA_PROPOSTA.VG103_DES_COMPLEMENTAR);

            /*" -2328- IF WH-VG103-DES-COMPLEMENTAR-LEN = 0 */

            if (WH_AUXILIAR.WH_VG103_DES_COMPLEMENTAR.WH_VG103_DES_COMPLEMENTAR_LEN == 0)
            {

                /*" -2329- MOVE -1 TO WH-VG103IDES-COMPLEMENTAR */
                _.Move(-1, WH_AUXILIAR.WH_VG103IDES_COMPLEMENTAR);

                /*" -2330- ELSE */
            }
            else
            {


                /*" -2331- MOVE 0 TO WH-VG103IDES-COMPLEMENTAR */
                _.Move(0, WH_AUXILIAR.WH_VG103IDES_COMPLEMENTAR);

                /*" -2333- END-IF. */
            }


            /*" -2334- PERFORM P0851-BUSCAR-TIMESTAMP */

            P0851_BUSCAR_TIMESTAMP_SECTION();

            /*" -2335- MOVE WH-CURRENT-TIMESTAMP TO VG103-DTH-CADASTRAMENTO */
            _.Move(WH_AUXILIAR.WH_CURRENT_TIMESTAMP, VG103.DCLVG_CRITICA_PROPOSTA.VG103_DTH_CADASTRAMENTO);

            /*" -2336- MOVE LK-VG001-COD-USUARIO TO VG103-COD-USUARIO */
            _.Move(SPVG001W.LK_VG001_COD_USUARIO, VG103.DCLVG_CRITICA_PROPOSTA.VG103_COD_USUARIO);

            /*" -2338- MOVE LK-VG001-NOM-PROGRAMA TO VG103-NOM-PROGRAMA */
            _.Move(SPVG001W.LK_VG001_NOM_PROGRAMA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_NOM_PROGRAMA);

            /*" -2340- PERFORM P0820-INSERIR-VG103 */

            P0820_INSERIR_VG103_SECTION();

            /*" -2342- PERFORM P0821-INSERIR-VG104 */

            P0821_INSERIR_VG104_SECTION();

            /*" -2342- . */

        }

        [StopWatch]
        /*" P0803-05-INICIO-DB-SELECT-1 */
        public void P0803_05_INICIO_DB_SELECT_1()
        {
            /*" -2287- EXEC SQL SELECT PF01A.NUM_PROPOSTA_SIVPF ,VG01A.NUM_TITULO ,CL01A.CGCCPF ,VG01A.CAP_BAS_SEGURADO ,VG01A.VALOR_TITULO ,VG01A.DATA_SOLICITACAO ,PF01A.DTQITBCO INTO :VG103-NUM-PROPOSTA ,:VG103-NUM-CERTIFICADO ,:VG103-NUM-CPF-CNPJ ,:VG103-VLR-IS ,:VG103-VLR-PREMIO ,:VG103-DTA-OCORRENCIA ,:VG103-DTA-RCAP FROM SEGUROS.VG_SOLICITA_FATURA VG01A ,SEGUROS.TERMO_ADESAO TA01A ,SEGUROS.PROPOSTA_FIDELIZ PF01A ,SEGUROS.CLIENTES CL01A WHERE VG01A.NUM_TITULO = :VGSOLFAT-NUM-TITULO AND TA01A.NUM_TERMO = VG01A.NUM_TITULO AND PF01A.NUM_SICOB = VG01A.NUM_TITULO AND CL01A.COD_CLIENTE = TA01A.COD_CLIENTE END-EXEC */

            var p0803_05_INICIO_DB_SELECT_1_Query1 = new P0803_05_INICIO_DB_SELECT_1_Query1()
            {
                VGSOLFAT_NUM_TITULO = VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_TITULO.ToString(),
            };

            var executed_1 = P0803_05_INICIO_DB_SELECT_1_Query1.Execute(p0803_05_INICIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VG103_NUM_PROPOSTA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_PROPOSTA);
                _.Move(executed_1.VG103_NUM_CERTIFICADO, VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CERTIFICADO);
                _.Move(executed_1.VG103_NUM_CPF_CNPJ, VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CPF_CNPJ);
                _.Move(executed_1.VG103_VLR_IS, VG103.DCLVG_CRITICA_PROPOSTA.VG103_VLR_IS);
                _.Move(executed_1.VG103_VLR_PREMIO, VG103.DCLVG_CRITICA_PROPOSTA.VG103_VLR_PREMIO);
                _.Move(executed_1.VG103_DTA_OCORRENCIA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_DTA_OCORRENCIA);
                _.Move(executed_1.VG103_DTA_RCAP, VG103.DCLVG_CRITICA_PROPOSTA.VG103_DTA_RCAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0803_99_EXIT*/

        [StopWatch]
        /*" P0804-PESQUISAR-APOL-ESPEC-SECTION */
        private void P0804_PESQUISAR_APOL_ESPEC_SECTION()
        {
            /*" -2353- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0804_00_START */

            P0804_00_START();

        }

        [StopWatch]
        /*" P0804-00-START */
        private void P0804_00_START(bool isPerform = false)
        {
            /*" -2356- MOVE 'P0804' TO WS-SECTION */
            _.Move("P0804", WORK.WS_ERRO.WS_SECTION);

            /*" -2358- MOVE LK-VG001-NUM-CERTIFICADO TO VGSOLFAT-NUM-TITULO */
            _.Move(SPVG001W.LK_VG001_NUM_CERTIFICADO, VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_TITULO);

            /*" -2358- . */

        }

        [StopWatch]
        /*" P0804-05-INICIO */
        private void P0804_05_INICIO(bool isPerform = false)
        {
            /*" -2364- MOVE 'P0804' TO WS-SECTION */
            _.Move("P0804", WORK.WS_ERRO.WS_SECTION);

            /*" -2389- PERFORM P0804_05_INICIO_DB_SELECT_1 */

            P0804_05_INICIO_DB_SELECT_1();

            /*" -2392- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -2393- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -2394- MOVE VGSOLFAT-NUM-TITULO TO WS-DECIMAL(01) */
                _.Move(VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_TITULO, WORK.WS_EDIT.WS_DECIMAL[01]);

                /*" -2398- STRING WS-SECTION ' - ERRO NO SELECT SEGUROS.VG_SOLICITA_FATURA.' ' NUM_CERTIFICADO = ' WS-DECIMAL(01) DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl107 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl107 += " - ERRO NO SELECT SEGUROS.VG_SOLICITA_FATURA.";
                spl107 += " NUM_CERTIFICADO = ";
                var spl108 = WORK.WS_EDIT.WS_DECIMAL[01].GetMoveValues();
                var results109 = spl107 + spl108;
                _.Move(results109, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -2400- MOVE 'SEGUROS.VG_SOLICITA_FATURA' TO WS-TABELA */
                _.Move("SEGUROS.VG_SOLICITA_FATURA", WORK.WS_ERRO.WS_TABELA);

                /*" -2401- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -2402- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -2403- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -2405- END-IF */
            }


            /*" -2406- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2407- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -2408- MOVE VGSOLFAT-NUM-TITULO TO WS-DECIMAL(01) */
                _.Move(VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_TITULO, WORK.WS_EDIT.WS_DECIMAL[01]);

                /*" -2412- STRING WS-SECTION ' - INFORMACOES DE CERTIFICADO NAO ENCONTRADO.' ' NUM_CERTIFICADO = ' WS-DECIMAL(01) DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl109 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl109 += " - INFORMACOES DE CERTIFICADO NAO ENCONTRADO.";
                spl109 += " NUM_CERTIFICADO = ";
                var spl110 = WORK.WS_EDIT.WS_DECIMAL[01].GetMoveValues();
                var results111 = spl109 + spl110;
                _.Move(results111, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -2413- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -2414- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -2415- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -2417- END-IF */
            }


            /*" -2419- PERFORM P0850-PESQUISAR-MAX-CRITC-PROP */

            P0850_PESQUISAR_MAX_CRITC_PROP_SECTION();

            /*" -2420- MOVE LK-VG001-IND-TP-PROPOSTA TO VG103-IND-TP-PROPOSTA */
            _.Move(SPVG001W.LK_VG001_IND_TP_PROPOSTA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_IND_TP_PROPOSTA);

            /*" -2421- MOVE LK-VG001-COD-MSG-CRITICA TO VG103-COD-MSG-CRITICA */
            _.Move(SPVG001W.LK_VG001_COD_MSG_CRITICA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_COD_MSG_CRITICA);

            /*" -2422- IF VG103-NUM-PROPOSTA > 0 */

            if (VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_PROPOSTA > 0)
            {

                /*" -2423- MOVE 0 TO WH-VG103INUM-PROPOSTA */
                _.Move(0, WH_AUXILIAR.WH_VG103INUM_PROPOSTA);

                /*" -2424- ELSE */
            }
            else
            {


                /*" -2425- MOVE -1 TO WH-VG103INUM-PROPOSTA */
                _.Move(-1, WH_AUXILIAR.WH_VG103INUM_PROPOSTA);

                /*" -2428- END-IF */
            }


            /*" -2429- MOVE WH-VG103-DES-COMPLEMENTAR TO VG103-DES-COMPLEMENTAR */
            _.Move(WH_AUXILIAR.WH_VG103_DES_COMPLEMENTAR, VG103.DCLVG_CRITICA_PROPOSTA.VG103_DES_COMPLEMENTAR);

            /*" -2430- IF WH-VG103-DES-COMPLEMENTAR-LEN = 0 */

            if (WH_AUXILIAR.WH_VG103_DES_COMPLEMENTAR.WH_VG103_DES_COMPLEMENTAR_LEN == 0)
            {

                /*" -2431- MOVE -1 TO WH-VG103IDES-COMPLEMENTAR */
                _.Move(-1, WH_AUXILIAR.WH_VG103IDES_COMPLEMENTAR);

                /*" -2432- ELSE */
            }
            else
            {


                /*" -2433- MOVE 0 TO WH-VG103IDES-COMPLEMENTAR */
                _.Move(0, WH_AUXILIAR.WH_VG103IDES_COMPLEMENTAR);

                /*" -2435- END-IF. */
            }


            /*" -2436- PERFORM P0851-BUSCAR-TIMESTAMP */

            P0851_BUSCAR_TIMESTAMP_SECTION();

            /*" -2437- MOVE WH-CURRENT-TIMESTAMP TO VG103-DTH-CADASTRAMENTO */
            _.Move(WH_AUXILIAR.WH_CURRENT_TIMESTAMP, VG103.DCLVG_CRITICA_PROPOSTA.VG103_DTH_CADASTRAMENTO);

            /*" -2438- MOVE LK-VG001-COD-USUARIO TO VG103-COD-USUARIO */
            _.Move(SPVG001W.LK_VG001_COD_USUARIO, VG103.DCLVG_CRITICA_PROPOSTA.VG103_COD_USUARIO);

            /*" -2440- MOVE LK-VG001-NOM-PROGRAMA TO VG103-NOM-PROGRAMA */
            _.Move(SPVG001W.LK_VG001_NOM_PROGRAMA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_NOM_PROGRAMA);

            /*" -2442- PERFORM P0820-INSERIR-VG103 */

            P0820_INSERIR_VG103_SECTION();

            /*" -2444- PERFORM P0821-INSERIR-VG104 */

            P0821_INSERIR_VG104_SECTION();

            /*" -2444- . */

        }

        [StopWatch]
        /*" P0804-05-INICIO-DB-SELECT-1 */
        public void P0804_05_INICIO_DB_SELECT_1()
        {
            /*" -2389- EXEC SQL SELECT E.NUM_PROPOSTA_SIVPF, A.NUM_CERTIFICADO, D.CGCCPF, B.CAP_BAS_SEGURADO, B.VALOR_TITULO, B.DATA_SOLICITACAO, A.DATA_QUITACAO INTO :VG103-NUM-PROPOSTA ,:VG103-NUM-CERTIFICADO ,:VG103-NUM-CPF-CNPJ ,:VG103-VLR-IS ,:VG103-VLR-PREMIO ,:VG103-DTA-OCORRENCIA ,:VG103-DTA-RCAP FROM SEGUROS.PROPOSTAS_VA A, SEGUROS.VG_SOLICITA_FATURA B, SEGUROS.CLIENTES D, SEGUROS.CONVERSAO_SICOB E WHERE A.NUM_CERTIFICADO = :VGSOLFAT-NUM-TITULO AND A.NUM_APOLICE = B.NUM_APOLICE AND A.COD_SUBGRUPO = B.COD_SUBGRUPO AND A.COD_CLIENTE = D.COD_CLIENTE AND A.NUM_APOLICE = E.NUM_SICOB WITH UR END-EXEC */

            var p0804_05_INICIO_DB_SELECT_1_Query1 = new P0804_05_INICIO_DB_SELECT_1_Query1()
            {
                VGSOLFAT_NUM_TITULO = VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_TITULO.ToString(),
            };

            var executed_1 = P0804_05_INICIO_DB_SELECT_1_Query1.Execute(p0804_05_INICIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VG103_NUM_PROPOSTA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_PROPOSTA);
                _.Move(executed_1.VG103_NUM_CERTIFICADO, VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CERTIFICADO);
                _.Move(executed_1.VG103_NUM_CPF_CNPJ, VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CPF_CNPJ);
                _.Move(executed_1.VG103_VLR_IS, VG103.DCLVG_CRITICA_PROPOSTA.VG103_VLR_IS);
                _.Move(executed_1.VG103_VLR_PREMIO, VG103.DCLVG_CRITICA_PROPOSTA.VG103_VLR_PREMIO);
                _.Move(executed_1.VG103_DTA_OCORRENCIA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_DTA_OCORRENCIA);
                _.Move(executed_1.VG103_DTA_RCAP, VG103.DCLVG_CRITICA_PROPOSTA.VG103_DTA_RCAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0804_99_EXIT*/

        [StopWatch]
        /*" P0805-PESQUISA-TIPO-PJ-SECTION */
        private void P0805_PESQUISA_TIPO_PJ_SECTION()
        {
            /*" -2455- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0805_00_START */

            P0805_00_START();

        }

        [StopWatch]
        /*" P0805-00-START */
        private void P0805_00_START(bool isPerform = false)
        {
            /*" -2458- MOVE 'P0805' TO WS-SECTION */
            _.Move("P0805", WORK.WS_ERRO.WS_SECTION);

            /*" -2460- MOVE LK-VG001-NUM-CERTIFICADO TO VGSOLFAT-NUM-TITULO */
            _.Move(SPVG001W.LK_VG001_NUM_CERTIFICADO, VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_TITULO);

            /*" -2460- . */

        }

        [StopWatch]
        /*" P0805-05-INICIO */
        private void P0805_05_INICIO(bool isPerform = false)
        {
            /*" -2466- MOVE 'P0805' TO WS-SECTION */
            _.Move("P0805", WORK.WS_ERRO.WS_SECTION);

            /*" -2480- PERFORM P0805_05_INICIO_DB_SELECT_1 */

            P0805_05_INICIO_DB_SELECT_1();

            /*" -2483- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -2484- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -2485- MOVE VGSOLFAT-NUM-TITULO TO WS-DECIMAL(01) */
                _.Move(VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_TITULO, WORK.WS_EDIT.WS_DECIMAL[01]);

                /*" -2489- STRING WS-SECTION ' - ERRO NO SELECT SEGUROS.PRODUTOS_VG.' ' NUM_CERTIFICADO = ' WS-DECIMAL(01) DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl111 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl111 += " - ERRO NO SELECT SEGUROS.PRODUTOS_VG.";
                spl111 += " NUM_CERTIFICADO = ";
                var spl112 = WORK.WS_EDIT.WS_DECIMAL[01].GetMoveValues();
                var results113 = spl111 + spl112;
                _.Move(results113, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -2491- MOVE 'SEGUROS.VG_SOLICITA_FATURA' TO WS-TABELA */
                _.Move("SEGUROS.VG_SOLICITA_FATURA", WORK.WS_ERRO.WS_TABELA);

                /*" -2492- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -2493- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -2494- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -2496- END-IF */
            }


            /*" -2496- . */

        }

        [StopWatch]
        /*" P0805-05-INICIO-DB-SELECT-1 */
        public void P0805_05_INICIO_DB_SELECT_1()
        {
            /*" -2480- EXEC SQL SELECT VALUE(C.ORIG_PRODU, ' ' ) INTO :WS-ORIG-PRODUTO FROM SEGUROS.VG_SOLICITA_FATURA A, SEGUROS.PROPOSTAS_VA B, SEGUROS.PRODUTOS_VG C, SEGUROS.CONVERSAO_SICOB D WHERE B.NUM_CERTIFICADO = :VGSOLFAT-NUM-TITULO AND A.NUM_APOLICE = B.NUM_APOLICE AND A.COD_SUBGRUPO = B.COD_SUBGRUPO AND A.NUM_APOLICE = C.NUM_APOLICE AND A.COD_SUBGRUPO = C.COD_SUBGRUPO AND A.NUM_APOLICE = D.NUM_SICOB WITH UR END-EXEC */

            var p0805_05_INICIO_DB_SELECT_1_Query1 = new P0805_05_INICIO_DB_SELECT_1_Query1()
            {
                VGSOLFAT_NUM_TITULO = VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_TITULO.ToString(),
            };

            var executed_1 = P0805_05_INICIO_DB_SELECT_1_Query1.Execute(p0805_05_INICIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_ORIG_PRODUTO, WORK.WS_ORIG_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0805_99_EXIT*/

        [StopWatch]
        /*" P0820-INSERIR-VG103-SECTION */
        private void P0820_INSERIR_VG103_SECTION()
        {
            /*" -2506- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0820_00_START */

            P0820_00_START();

        }

        [StopWatch]
        /*" P0820-00-START */
        private void P0820_00_START(bool isPerform = false)
        {
            /*" -2509- MOVE 'P0820' TO WS-SECTION */
            _.Move("P0820", WORK.WS_ERRO.WS_SECTION);

            /*" -2509- PERFORM P0820-05-INICIO. */

            P0820_05_INICIO(true);

        }

        [StopWatch]
        /*" P0820-05-INICIO */
        private void P0820_05_INICIO(bool isPerform = false)
        {
            /*" -2547- PERFORM P0820_05_INICIO_DB_INSERT_1 */

            P0820_05_INICIO_DB_INSERT_1();

            /*" -2550- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -2551- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -2552- MOVE VG103-NUM-CERTIFICADO TO WS-DECIMAL(01) */
                _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CERTIFICADO, WORK.WS_EDIT.WS_DECIMAL[01]);

                /*" -2553- MOVE VG103-SEQ-CRITICA TO WS-SMALLINT(01) */
                _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_SEQ_CRITICA, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -2558- STRING WS-SECTION ' - ERRO NO INSERT SEGUROS.VG_CRITICA_PROPOSTA.' ' NUM_CERTIFICADO = ' WS-DECIMAL(01) ' SEQ_CRITICA = ' WS-SMALLINT(01) DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl113 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl113 += " - ERRO NO INSERT SEGUROS.VG_CRITICA_PROPOSTA.";
                spl113 += " NUM_CERTIFICADO = ";
                var spl114 = WORK.WS_EDIT.WS_DECIMAL[01].GetMoveValues();
                spl114 += " SEQ_CRITICA = ";
                var spl115 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                var results116 = spl113 + spl114 + spl115;
                _.Move(results116, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -2560- MOVE 'SEGUROS.VG_CRITICA_PROPOSTA' TO WS-TABELA */
                _.Move("SEGUROS.VG_CRITICA_PROPOSTA", WORK.WS_ERRO.WS_TABELA);

                /*" -2561- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -2563- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -2564- DISPLAY 'NUM-CERTIFICADO  ' VG103-NUM-CERTIFICADO */
                _.Display($"NUM-CERTIFICADO  {VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CERTIFICADO}");

                /*" -2565- DISPLAY 'SEQ-CRITICA      ' VG103-SEQ-CRITICA */
                _.Display($"SEQ-CRITICA      {VG103.DCLVG_CRITICA_PROPOSTA.VG103_SEQ_CRITICA}");

                /*" -2566- DISPLAY 'IND-TP-PROPOSTA  ' VG103-IND-TP-PROPOSTA */
                _.Display($"IND-TP-PROPOSTA  {VG103.DCLVG_CRITICA_PROPOSTA.VG103_IND_TP_PROPOSTA}");

                /*" -2567- DISPLAY 'COD-MSG-CRITICA  ' VG103-COD-MSG-CRITICA */
                _.Display($"COD-MSG-CRITICA  {VG103.DCLVG_CRITICA_PROPOSTA.VG103_COD_MSG_CRITICA}");

                /*" -2568- DISPLAY 'NUM-CPF-CNPJ     ' VG103-NUM-CPF-CNPJ */
                _.Display($"NUM-CPF-CNPJ     {VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CPF_CNPJ}");

                /*" -2569- DISPLAY 'NUM-PROPOSTA     ' VG103-NUM-PROPOSTA */
                _.Display($"NUM-PROPOSTA     {VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_PROPOSTA}");

                /*" -2570- DISPLAY 'VLR-IS           ' VG103-VLR-IS */
                _.Display($"VLR-IS           {VG103.DCLVG_CRITICA_PROPOSTA.VG103_VLR_IS}");

                /*" -2571- DISPLAY 'VLR-PREMIO       ' VG103-VLR-PREMIO */
                _.Display($"VLR-PREMIO       {VG103.DCLVG_CRITICA_PROPOSTA.VG103_VLR_PREMIO}");

                /*" -2572- DISPLAY 'DTA-OCORRENCIA   ' VG103-DTA-OCORRENCIA */
                _.Display($"DTA-OCORRENCIA   {VG103.DCLVG_CRITICA_PROPOSTA.VG103_DTA_OCORRENCIA}");

                /*" -2573- DISPLAY 'DTA-RCAP         ' VG103-DTA-RCAP */
                _.Display($"DTA-RCAP         {VG103.DCLVG_CRITICA_PROPOSTA.VG103_DTA_RCAP}");

                /*" -2574- DISPLAY 'STA-CRITICA      ' VG103-STA-CRITICA */
                _.Display($"STA-CRITICA      {VG103.DCLVG_CRITICA_PROPOSTA.VG103_STA_CRITICA}");

                /*" -2575- DISPLAY 'DES-COMPLEMENTAR ' VG103-DES-COMPLEMENTAR */
                _.Display($"DES-COMPLEMENTAR {VG103.DCLVG_CRITICA_PROPOSTA.VG103_DES_COMPLEMENTAR}");

                /*" -2576- DISPLAY 'COD-USUARIO      ' VG103-COD-USUARIO */
                _.Display($"COD-USUARIO      {VG103.DCLVG_CRITICA_PROPOSTA.VG103_COD_USUARIO}");

                /*" -2577- DISPLAY 'NOM-PROGRAMA     ' VG103-NOM-PROGRAMA */
                _.Display($"NOM-PROGRAMA     {VG103.DCLVG_CRITICA_PROPOSTA.VG103_NOM_PROGRAMA}");

                /*" -2578- DISPLAY 'DTH-CADASTRAMENT ' VG103-DTH-CADASTRAMENTO */
                _.Display($"DTH-CADASTRAMENT {VG103.DCLVG_CRITICA_PROPOSTA.VG103_DTH_CADASTRAMENTO}");

                /*" -2579- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -2581- END-IF */
            }


            /*" -2581- . */

        }

        [StopWatch]
        /*" P0820-05-INICIO-DB-INSERT-1 */
        public void P0820_05_INICIO_DB_INSERT_1()
        {
            /*" -2547- EXEC SQL INSERT INTO SEGUROS.VG_CRITICA_PROPOSTA ( NUM_CERTIFICADO ,SEQ_CRITICA ,IND_TP_PROPOSTA ,COD_MSG_CRITICA ,NUM_CPF_CNPJ ,NUM_PROPOSTA ,VLR_IS ,VLR_PREMIO ,DTA_OCORRENCIA ,DTA_RCAP ,STA_CRITICA ,DES_COMPLEMENTAR ,COD_USUARIO ,NOM_PROGRAMA ,DTH_CADASTRAMENTO ) VALUES ( :VG103-NUM-CERTIFICADO ,:VG103-SEQ-CRITICA ,:VG103-IND-TP-PROPOSTA ,:VG103-COD-MSG-CRITICA ,:VG103-NUM-CPF-CNPJ ,:VG103-NUM-PROPOSTA :WH-VG103INUM-PROPOSTA ,:VG103-VLR-IS ,:VG103-VLR-PREMIO ,:VG103-DTA-OCORRENCIA ,:VG103-DTA-RCAP ,:VG103-STA-CRITICA ,:VG103-DES-COMPLEMENTAR :WH-VG103IDES-COMPLEMENTAR ,:VG103-COD-USUARIO ,:VG103-NOM-PROGRAMA ,:VG103-DTH-CADASTRAMENTO ) END-EXEC */

            var p0820_05_INICIO_DB_INSERT_1_Insert1 = new P0820_05_INICIO_DB_INSERT_1_Insert1()
            {
                VG103_NUM_CERTIFICADO = VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CERTIFICADO.ToString(),
                VG103_SEQ_CRITICA = VG103.DCLVG_CRITICA_PROPOSTA.VG103_SEQ_CRITICA.ToString(),
                VG103_IND_TP_PROPOSTA = VG103.DCLVG_CRITICA_PROPOSTA.VG103_IND_TP_PROPOSTA.ToString(),
                VG103_COD_MSG_CRITICA = VG103.DCLVG_CRITICA_PROPOSTA.VG103_COD_MSG_CRITICA.ToString(),
                VG103_NUM_CPF_CNPJ = VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CPF_CNPJ.ToString(),
                VG103_NUM_PROPOSTA = VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_PROPOSTA.ToString(),
                WH_VG103INUM_PROPOSTA = WH_AUXILIAR.WH_VG103INUM_PROPOSTA.ToString(),
                VG103_VLR_IS = VG103.DCLVG_CRITICA_PROPOSTA.VG103_VLR_IS.ToString(),
                VG103_VLR_PREMIO = VG103.DCLVG_CRITICA_PROPOSTA.VG103_VLR_PREMIO.ToString(),
                VG103_DTA_OCORRENCIA = VG103.DCLVG_CRITICA_PROPOSTA.VG103_DTA_OCORRENCIA.ToString(),
                VG103_DTA_RCAP = VG103.DCLVG_CRITICA_PROPOSTA.VG103_DTA_RCAP.ToString(),
                VG103_STA_CRITICA = VG103.DCLVG_CRITICA_PROPOSTA.VG103_STA_CRITICA.ToString(),
                VG103_DES_COMPLEMENTAR = VG103.DCLVG_CRITICA_PROPOSTA.VG103_DES_COMPLEMENTAR.ToString(),
                WH_VG103IDES_COMPLEMENTAR = WH_AUXILIAR.WH_VG103IDES_COMPLEMENTAR.ToString(),
                VG103_COD_USUARIO = VG103.DCLVG_CRITICA_PROPOSTA.VG103_COD_USUARIO.ToString(),
                VG103_NOM_PROGRAMA = VG103.DCLVG_CRITICA_PROPOSTA.VG103_NOM_PROGRAMA.ToString(),
                VG103_DTH_CADASTRAMENTO = VG103.DCLVG_CRITICA_PROPOSTA.VG103_DTH_CADASTRAMENTO.ToString(),
            };

            P0820_05_INICIO_DB_INSERT_1_Insert1.Execute(p0820_05_INICIO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0820_99_EXIT*/

        [StopWatch]
        /*" P0821-INSERIR-VG104-SECTION */
        private void P0821_INSERIR_VG104_SECTION()
        {
            /*" -2593- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0821_00_START */

            P0821_00_START();

        }

        [StopWatch]
        /*" P0821-00-START */
        private void P0821_00_START(bool isPerform = false)
        {
            /*" -2596- MOVE 'P0821' TO WS-SECTION */
            _.Move("P0821", WORK.WS_ERRO.WS_SECTION);

            /*" -2596- PERFORM P0821-05-INICIO. */

            P0821_05_INICIO(true);

        }

        [StopWatch]
        /*" P0821-05-INICIO */
        private void P0821_05_INICIO(bool isPerform = false)
        {
            /*" -2634- PERFORM P0821_05_INICIO_DB_INSERT_1 */

            P0821_05_INICIO_DB_INSERT_1();

            /*" -2637- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -2638- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -2639- MOVE VG103-NUM-CERTIFICADO TO WS-DECIMAL(01) */
                _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CERTIFICADO, WORK.WS_EDIT.WS_DECIMAL[01]);

                /*" -2640- MOVE VG103-SEQ-CRITICA TO WS-SMALLINT(01) */
                _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_SEQ_CRITICA, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -2645- STRING WS-SECTION ' - ERRO NO INSERT SEGUROS.VG_CRITICA_PROPOSTA_HIST.' ' NUM_CERTIFICADO = ' WS-DECIMAL(01) ' SEQ_CRITICA = ' WS-SMALLINT(01) DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl116 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl116 += " - ERRO NO INSERT SEGUROS.VG_CRITICA_PROPOSTA_HIST.";
                spl116 += " NUM_CERTIFICADO = ";
                var spl117 = WORK.WS_EDIT.WS_DECIMAL[01].GetMoveValues();
                spl117 += " SEQ_CRITICA = ";
                var spl118 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                var results119 = spl116 + spl117 + spl118;
                _.Move(results119, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -2647- MOVE 'SEGUROS.VG_CRITICA_PROPOSTA_HIST' TO WS-TABELA */
                _.Move("SEGUROS.VG_CRITICA_PROPOSTA_HIST", WORK.WS_ERRO.WS_TABELA);

                /*" -2648- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -2649- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -2650- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -2652- END-IF */
            }


            /*" -2652- . */

        }

        [StopWatch]
        /*" P0821-05-INICIO-DB-INSERT-1 */
        public void P0821_05_INICIO_DB_INSERT_1()
        {
            /*" -2634- EXEC SQL INSERT INTO SEGUROS.VG_CRITICA_PROPOSTA_HIST ( NUM_CERTIFICADO ,SEQ_CRITICA ,DTH_CADASTRAMENTO ,IND_TP_PROPOSTA ,COD_MSG_CRITICA ,NUM_CPF_CNPJ ,NUM_PROPOSTA ,VLR_IS ,VLR_PREMIO ,DTA_OCORRENCIA ,DTA_RCAP ,STA_CRITICA ,DES_COMPLEMENTAR ,COD_USUARIO ,NOM_PROGRAMA ) VALUES ( :VG103-NUM-CERTIFICADO ,:VG103-SEQ-CRITICA ,:VG103-DTH-CADASTRAMENTO ,:VG103-IND-TP-PROPOSTA ,:VG103-COD-MSG-CRITICA ,:VG103-NUM-CPF-CNPJ ,:VG103-NUM-PROPOSTA :WH-VG103INUM-PROPOSTA ,:VG103-VLR-IS ,:VG103-VLR-PREMIO ,:VG103-DTA-OCORRENCIA ,:VG103-DTA-RCAP ,:VG103-STA-CRITICA ,:VG103-DES-COMPLEMENTAR :WH-VG103IDES-COMPLEMENTAR ,:VG103-COD-USUARIO ,:VG103-NOM-PROGRAMA ) END-EXEC */

            var p0821_05_INICIO_DB_INSERT_1_Insert1 = new P0821_05_INICIO_DB_INSERT_1_Insert1()
            {
                VG103_NUM_CERTIFICADO = VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CERTIFICADO.ToString(),
                VG103_SEQ_CRITICA = VG103.DCLVG_CRITICA_PROPOSTA.VG103_SEQ_CRITICA.ToString(),
                VG103_DTH_CADASTRAMENTO = VG103.DCLVG_CRITICA_PROPOSTA.VG103_DTH_CADASTRAMENTO.ToString(),
                VG103_IND_TP_PROPOSTA = VG103.DCLVG_CRITICA_PROPOSTA.VG103_IND_TP_PROPOSTA.ToString(),
                VG103_COD_MSG_CRITICA = VG103.DCLVG_CRITICA_PROPOSTA.VG103_COD_MSG_CRITICA.ToString(),
                VG103_NUM_CPF_CNPJ = VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CPF_CNPJ.ToString(),
                VG103_NUM_PROPOSTA = VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_PROPOSTA.ToString(),
                WH_VG103INUM_PROPOSTA = WH_AUXILIAR.WH_VG103INUM_PROPOSTA.ToString(),
                VG103_VLR_IS = VG103.DCLVG_CRITICA_PROPOSTA.VG103_VLR_IS.ToString(),
                VG103_VLR_PREMIO = VG103.DCLVG_CRITICA_PROPOSTA.VG103_VLR_PREMIO.ToString(),
                VG103_DTA_OCORRENCIA = VG103.DCLVG_CRITICA_PROPOSTA.VG103_DTA_OCORRENCIA.ToString(),
                VG103_DTA_RCAP = VG103.DCLVG_CRITICA_PROPOSTA.VG103_DTA_RCAP.ToString(),
                VG103_STA_CRITICA = VG103.DCLVG_CRITICA_PROPOSTA.VG103_STA_CRITICA.ToString(),
                VG103_DES_COMPLEMENTAR = VG103.DCLVG_CRITICA_PROPOSTA.VG103_DES_COMPLEMENTAR.ToString(),
                WH_VG103IDES_COMPLEMENTAR = WH_AUXILIAR.WH_VG103IDES_COMPLEMENTAR.ToString(),
                VG103_COD_USUARIO = VG103.DCLVG_CRITICA_PROPOSTA.VG103_COD_USUARIO.ToString(),
                VG103_NOM_PROGRAMA = VG103.DCLVG_CRITICA_PROPOSTA.VG103_NOM_PROGRAMA.ToString(),
            };

            P0821_05_INICIO_DB_INSERT_1_Insert1.Execute(p0821_05_INICIO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0821_99_EXIT*/

        [StopWatch]
        /*" P0822-ATUALIZAR-VG103-SECTION */
        private void P0822_ATUALIZAR_VG103_SECTION()
        {
            /*" -2664- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0822_00_START */

            P0822_00_START();

        }

        [StopWatch]
        /*" P0822-00-START */
        private void P0822_00_START(bool isPerform = false)
        {
            /*" -2667- MOVE 'P0822' TO WS-SECTION */
            _.Move("P0822", WORK.WS_ERRO.WS_SECTION);

            /*" -2667- . */

        }

        [StopWatch]
        /*" P0822-05-INICIO */
        private void P0822_05_INICIO(bool isPerform = false)
        {
            /*" -2681- PERFORM P0822_05_INICIO_DB_UPDATE_1 */

            P0822_05_INICIO_DB_UPDATE_1();

            /*" -2684- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -2685- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -2686- MOVE VG103-NUM-CERTIFICADO TO WS-DECIMAL(01) */
                _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CERTIFICADO, WORK.WS_EDIT.WS_DECIMAL[01]);

                /*" -2687- MOVE VG103-SEQ-CRITICA TO WS-SMALLINT(01) */
                _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_SEQ_CRITICA, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -2692- STRING WS-SECTION ' - ERRO NO UPDATE SEGUROS.VG_CRITICA_PROPOSTA.' ' NUM_CERTIFICADO = ' WS-DECIMAL(01) ' SEQ_CRITICA = ' WS-SMALLINT(01) DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl119 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl119 += " - ERRO NO UPDATE SEGUROS.VG_CRITICA_PROPOSTA.";
                spl119 += " NUM_CERTIFICADO = ";
                var spl120 = WORK.WS_EDIT.WS_DECIMAL[01].GetMoveValues();
                spl120 += " SEQ_CRITICA = ";
                var spl121 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                var results122 = spl119 + spl120 + spl121;
                _.Move(results122, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -2694- MOVE 'SEGUROS.VG_CRITICA_PROPOSTA' TO WS-TABELA */
                _.Move("SEGUROS.VG_CRITICA_PROPOSTA", WORK.WS_ERRO.WS_TABELA);

                /*" -2695- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -2696- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -2697- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -2699- END-IF */
            }


            /*" -2699- . */

        }

        [StopWatch]
        /*" P0822-05-INICIO-DB-UPDATE-1 */
        public void P0822_05_INICIO_DB_UPDATE_1()
        {
            /*" -2681- EXEC SQL UPDATE SEGUROS.VG_CRITICA_PROPOSTA SET STA_CRITICA = :VG103-STA-CRITICA ,DES_COMPLEMENTAR = :VG103-DES-COMPLEMENTAR :WH-VG103IDES-COMPLEMENTAR ,DTH_CADASTRAMENTO = :VG103-DTH-CADASTRAMENTO ,COD_USUARIO = :VG103-COD-USUARIO ,NOM_PROGRAMA = :VG103-NOM-PROGRAMA WHERE NUM_CERTIFICADO = :VG103-NUM-CERTIFICADO AND SEQ_CRITICA = :VG103-SEQ-CRITICA END-EXEC */

            var p0822_05_INICIO_DB_UPDATE_1_Update1 = new P0822_05_INICIO_DB_UPDATE_1_Update1()
            {
                VG103_DES_COMPLEMENTAR = VG103.DCLVG_CRITICA_PROPOSTA.VG103_DES_COMPLEMENTAR.ToString(),
                WH_VG103IDES_COMPLEMENTAR = WH_AUXILIAR.WH_VG103IDES_COMPLEMENTAR.ToString(),
                VG103_DTH_CADASTRAMENTO = VG103.DCLVG_CRITICA_PROPOSTA.VG103_DTH_CADASTRAMENTO.ToString(),
                VG103_NOM_PROGRAMA = VG103.DCLVG_CRITICA_PROPOSTA.VG103_NOM_PROGRAMA.ToString(),
                VG103_STA_CRITICA = VG103.DCLVG_CRITICA_PROPOSTA.VG103_STA_CRITICA.ToString(),
                VG103_COD_USUARIO = VG103.DCLVG_CRITICA_PROPOSTA.VG103_COD_USUARIO.ToString(),
                VG103_NUM_CERTIFICADO = VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CERTIFICADO.ToString(),
                VG103_SEQ_CRITICA = VG103.DCLVG_CRITICA_PROPOSTA.VG103_SEQ_CRITICA.ToString(),
            };

            P0822_05_INICIO_DB_UPDATE_1_Update1.Execute(p0822_05_INICIO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0822_99_EXIT*/

        [StopWatch]
        /*" P0850-PESQUISAR-MAX-CRITC-PROP-SECTION */
        private void P0850_PESQUISAR_MAX_CRITC_PROP_SECTION()
        {
            /*" -2711- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0850_00_START */

            P0850_00_START();

        }

        [StopWatch]
        /*" P0850-00-START */
        private void P0850_00_START(bool isPerform = false)
        {
            /*" -2714- MOVE 'P0850' TO WS-SECTION */
            _.Move("P0850", WORK.WS_ERRO.WS_SECTION);

            /*" -2716- MOVE LK-VG001-NUM-CERTIFICADO TO VG103-NUM-CERTIFICADO */
            _.Move(SPVG001W.LK_VG001_NUM_CERTIFICADO, VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CERTIFICADO);

            /*" -2716- . */

        }

        [StopWatch]
        /*" P0850-05-INICIO */
        private void P0850_05_INICIO(bool isPerform = false)
        {
            /*" -2725- PERFORM P0850_05_INICIO_DB_SELECT_1 */

            P0850_05_INICIO_DB_SELECT_1();

            /*" -2728- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -2729- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -2730- MOVE VG103-NUM-CERTIFICADO TO WS-DECIMAL(01) */
                _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CERTIFICADO, WORK.WS_EDIT.WS_DECIMAL[01]);

                /*" -2734- STRING WS-SECTION ' - ERRO NO SELECT MAX SEGUROS.VG_CRITICA_PROPOSTA.' ' STA_CRITICA = ' WS-DECIMAL(01) DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl122 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl122 += " - ERRO NO SELECT MAX SEGUROS.VG_CRITICA_PROPOSTA.";
                spl122 += " STA_CRITICA = ";
                var spl123 = WORK.WS_EDIT.WS_DECIMAL[01].GetMoveValues();
                var results124 = spl122 + spl123;
                _.Move(results124, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -2736- MOVE 'SEGUROS.VG_CRITICA_PROPOSTA' TO WS-TABELA */
                _.Move("SEGUROS.VG_CRITICA_PROPOSTA", WORK.WS_ERRO.WS_TABELA);

                /*" -2737- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -2738- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -2739- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -2741- END-IF */
            }


            /*" -2741- . */

        }

        [StopWatch]
        /*" P0850-05-INICIO-DB-SELECT-1 */
        public void P0850_05_INICIO_DB_SELECT_1()
        {
            /*" -2725- EXEC SQL SELECT VALUE(MAX(VG103.SEQ_CRITICA),0) + 1 INTO :VG103-SEQ-CRITICA FROM SEGUROS.VG_CRITICA_PROPOSTA VG103 WHERE VG103.NUM_CERTIFICADO = :VG103-NUM-CERTIFICADO END-EXEC */

            var p0850_05_INICIO_DB_SELECT_1_Query1 = new P0850_05_INICIO_DB_SELECT_1_Query1()
            {
                VG103_NUM_CERTIFICADO = VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = P0850_05_INICIO_DB_SELECT_1_Query1.Execute(p0850_05_INICIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VG103_SEQ_CRITICA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_SEQ_CRITICA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0850_99_EXIT*/

        [StopWatch]
        /*" P0851-BUSCAR-TIMESTAMP-SECTION */
        private void P0851_BUSCAR_TIMESTAMP_SECTION()
        {
            /*" -2752- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0851_00_START */

            P0851_00_START();

        }

        [StopWatch]
        /*" P0851-00-START */
        private void P0851_00_START(bool isPerform = false)
        {
            /*" -2755- MOVE 'P0851' TO WS-SECTION */
            _.Move("P0851", WORK.WS_ERRO.WS_SECTION);

            /*" -2755- . */

        }

        [StopWatch]
        /*" P0851-01-INICIO */
        private void P0851_01_INICIO(bool isPerform = false)
        {
            /*" -2763- PERFORM P0851_01_INICIO_DB_SELECT_1 */

            P0851_01_INICIO_DB_SELECT_1();

            /*" -2766- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -2767- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -2770- STRING WS-SECTION ' - ERRO NO SELECT SYSIBM.SYSDUMMY1.' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl124 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl124 += " - ERRO NO SELECT SYSIBM.SYSDUMMY1.";
                _.Move(spl124, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -2771- MOVE 'SYSIBM.SYSDUMMY1' TO WS-TABELA */
                _.Move("SYSIBM.SYSDUMMY1", WORK.WS_ERRO.WS_TABELA);

                /*" -2772- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -2773- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -2774- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -2776- END-IF */
            }


            /*" -2776- . */

        }

        [StopWatch]
        /*" P0851-01-INICIO-DB-SELECT-1 */
        public void P0851_01_INICIO_DB_SELECT_1()
        {
            /*" -2763- EXEC SQL SELECT CHAR(CURRENT TIMESTAMP) INTO :WH-CURRENT-TIMESTAMP FROM SYSIBM.SYSDUMMY1 END-EXEC */

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
        /*" P1000-CALL-GE0070S-SECTION */
        private void P1000_CALL_GE0070S_SECTION()
        {
            /*" -2787- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P1000_00_START */

            P1000_00_START();

        }

        [StopWatch]
        /*" P1000-00-START */
        private void P1000_00_START(bool isPerform = false)
        {
            /*" -2791- MOVE 'P1000' TO WS-SECTION */
            _.Move("P1000", WORK.WS_ERRO.WS_SECTION);

            /*" -2792- MOVE 'N' TO LK-0070-E-TRACE */
            _.Move("N", GE0070W.LK_0070_E_TRACE);

            /*" -2793- MOVE 'ON-BATCH' TO LK-0070-E-COD-USUARIO */
            _.Move("ON-BATCH", GE0070W.LK_0070_E_COD_USUARIO);

            /*" -2794- MOVE 'SPBVG001' TO LK-0070-E-NOM-PROGRAMA */
            _.Move("SPBVG001", GE0070W.LK_0070_E_NOM_PROGRAMA);

            /*" -2795- MOVE 01 TO LK-0070-E-ACAO */
            _.Move(01, GE0070W.LK_0070_E_ACAO);

            /*" -2796- MOVE BILHETE-COD-PRODUTO TO LK-0070-I-COD-PRODUTO */
            _.Move(BILHETE.DCLBILHETE.BILHETE_COD_PRODUTO, GE0070W.LK_0070_I_COD_PRODUTO);

            /*" -2798- MOVE 0 TO LK-0070-I-SEQ-PRODUTO-VRS */
            _.Move(0, GE0070W.LK_0070_I_SEQ_PRODUTO_VRS);

            /*" -2800- MOVE BILHETE-DATA-QUITACAO TO LK-0070-I-DTA-PROPOSTA */
            _.Move(BILHETE.DCLBILHETE.BILHETE_DATA_QUITACAO, GE0070W.LK_0070_I_DTA_PROPOSTA);

            /*" -2800- . */

        }

        [StopWatch]
        /*" P1000-05-INICIO */
        private void P1000_05_INICIO(bool isPerform = false)
        {
            /*" -2805- MOVE 'GE0070S' TO WS-PROGRAMA */
            _.Move("GE0070S", WORK.WS_PROGRAMA);

            /*" -2847- CALL WS-PROGRAMA USING LK-0070-E-TRACE LK-0070-E-COD-USUARIO LK-0070-E-NOM-PROGRAMA LK-0070-E-ACAO LK-0070-I-COD-PRODUTO LK-0070-I-SEQ-PRODUTO-VRS LK-0070-I-DTA-PROPOSTA LK-0070-S-DTA-INI-VIGENCIA LK-0070-S-DTA-FIM-VIGENCIA LK-0070-S-IND-FLUXO-PARAM LK-0070-S-COD-PERIOD-VIGENCIA LK-0070-S-QTD-PERIOD-VIGENCIA LK-0070-S-COD-MOEDA LK-0070-S-IND-RENOVA LK-0070-S-IND-RENOVA-AUTOMAT LK-0070-S-QTD-RENOVA-AUTOMAT LK-0070-S-IND-DPS LK-0070-S-IND-REENQUADRA-PREM LK-0070-S-IND-REAJUSTE-PREMIO LK-0070-S-COD-INDICE-REAJUSTE LK-0070-S-COD-PERIOD-REAJUSTE LK-0070-S-COD-INDC-DEVOLUCAO LK-0070-S-PCT-JUROS-DEVOLUCAO LK-0070-S-PCT-MULTA-DEVOLUCAO LK-0070-S-IND-FLUXO-COMISSAO LK-0070-S-IND-ACOPLADO LK-0070-S-IND-FLUXO-SINISTRO LK-0070-S-IND-CONJUGE LK-0070-S-COD-USUARIO LK-0070-S-NOM-PROGRAMA LK-0070-S-DTH-CADASTRAMENTO LK-0070-IND-ERRO LK-0070-MSG-ERRO LK-0070-NOM-TABELA LK-0070-SQLCODE LK-0070-SQLERRMC LK-0070-SQLSTATE. */
            _.Call(WORK.WS_PROGRAMA, GE0070W);

            /*" -2848- IF LK-0070-IND-ERRO NOT = 0 */

            if (GE0070W.LK_0070_IND_ERRO != 0)
            {

                /*" -2849- MOVE LK-0070-IND-ERRO TO WS-IND-ERRO */
                _.Move(GE0070W.LK_0070_IND_ERRO, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -2850- MOVE LK-0070-MSG-ERRO TO WS-MENSAGEM */
                _.Move(GE0070W.LK_0070_MSG_ERRO, WORK.WS_ERRO.WS_MENSAGEM);

                /*" -2851- MOVE LK-0070-NOM-TABELA TO WS-TABELA */
                _.Move(GE0070W.LK_0070_NOM_TABELA, WORK.WS_ERRO.WS_TABELA);

                /*" -2852- MOVE LK-0070-SQLCODE TO WS-SQLCODE */
                _.Move(GE0070W.LK_0070_SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -2854- MOVE LK-0070-SQLERRMC TO WS-SQLERRMC */
                _.Move(GE0070W.LK_0070_SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -2855- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -2857- END-IF */
            }


            /*" -2857- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P1000_99_EXIT*/

        [StopWatch]
        /*" P1001-CALL-GE0071S-SECTION */
        private void P1001_CALL_GE0071S_SECTION()
        {
            /*" -2868- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P1001_00_START */

            P1001_00_START();

        }

        [StopWatch]
        /*" P1001-00-START */
        private void P1001_00_START(bool isPerform = false)
        {
            /*" -2872- MOVE 'P1001' TO WS-SECTION */
            _.Move("P1001", WORK.WS_ERRO.WS_SECTION);

            /*" -2873- MOVE 'N' TO LK-0071-E-TRACE */
            _.Move("N", GE0071W.LK_0071_E_TRACE);

            /*" -2874- MOVE 'ON-BATCH' TO LK-0071-E-COD-USUARIO */
            _.Move("ON-BATCH", GE0071W.LK_0071_E_COD_USUARIO);

            /*" -2875- MOVE 'SPBVG001' TO LK-0071-E-NOM-PROGRAMA */
            _.Move("SPBVG001", GE0071W.LK_0071_E_NOM_PROGRAMA);

            /*" -2876- MOVE 01 TO LK-0071-E-ACAO */
            _.Move(01, GE0071W.LK_0071_E_ACAO);

            /*" -2877- MOVE LK-0070-I-COD-PRODUTO TO LK-0071-I-COD-PRODUTO */
            _.Move(GE0070W.LK_0070_I_COD_PRODUTO, GE0071W.LK_0071_I_COD_PRODUTO);

            /*" -2879- MOVE LK-0070-I-SEQ-PRODUTO-VRS TO LK-0071-I-SEQ-PRODUTO-VRS */
            _.Move(GE0070W.LK_0070_I_SEQ_PRODUTO_VRS, GE0071W.LK_0071_I_SEQ_PRODUTO_VRS);

            /*" -2881- MOVE SPACES TO LK-0071-I-COD-OPC-COBERTURA */
            _.Move("", GE0071W.LK_0071_I_COD_OPC_COBERTURA);

            /*" -2882- MOVE BILHETE-OPC-COBERTURA TO LK-0071-I-COD-OPC-PLANO */
            _.Move(BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA, GE0071W.LK_0071_I_COD_OPC_PLANO);

            /*" -2883- MOVE 'N' TO LK-0071-I-IND-CONJUGE */
            _.Move("N", GE0071W.LK_0071_I_IND_CONJUGE);

            /*" -2885- MOVE WH-IDADE TO LK-0071-I-NUM-IDADE */
            _.Move(WH_AUXILIAR.WH_IDADE, GE0071W.LK_0071_I_NUM_IDADE);

            /*" -2885- . */

        }

        [StopWatch]
        /*" P1001-05-INICIO */
        private void P1001_05_INICIO(bool isPerform = false)
        {
            /*" -2890- MOVE 'GE0071S' TO WS-PROGRAMA */
            _.Move("GE0071S", WORK.WS_PROGRAMA);

            /*" -2922- CALL WS-PROGRAMA USING LK-0071-E-TRACE LK-0071-E-COD-USUARIO LK-0071-E-NOM-PROGRAMA LK-0071-E-ACAO LK-0071-I-COD-PRODUTO LK-0071-I-SEQ-PRODUTO-VRS LK-0071-I-COD-OPC-COBERTURA LK-0071-I-COD-OPC-PLANO LK-0071-I-IND-CONJUGE LK-0071-I-NUM-IDADE LK-0071-S-NUM-IDADE-INI LK-0071-S-NUM-IDADE-FIM LK-0071-S-VLR-INI-PREMIO LK-0071-S-VLR-FIM-PREMIO LK-0071-S-PCT-IOF LK-0071-S-PCT-REENQUADRAMENTO LK-0071-S-IND-PERMIT-VENDA LK-0071-S-VLR-TOTAL-IS LK-0071-S-QTD-OCC LK-0071-S-ARR LK-0071-IND-ERRO LK-0071-MSG-ERRO LK-0071-NOM-TABELA LK-0071-SQLCODE LK-0071-SQLERRMC LK-0071-SQLSTATE */
            _.Call(WORK.WS_PROGRAMA, GE0071W, GE0071W.LK_0071_S_ARR);

            /*" -2923- IF LK-0071-IND-ERRO NOT = 0 */

            if (GE0071W.LK_0071_S_ARR.LK_0071_IND_ERRO != 0)
            {

                /*" -2924- MOVE LK-0071-IND-ERRO TO WS-IND-ERRO */
                _.Move(GE0071W.LK_0071_S_ARR.LK_0071_IND_ERRO, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -2925- MOVE LK-0071-MSG-ERRO TO WS-MENSAGEM */
                _.Move(GE0071W.LK_0071_S_ARR.LK_0071_MSG_ERRO, WORK.WS_ERRO.WS_MENSAGEM);

                /*" -2926- MOVE LK-0071-NOM-TABELA TO WS-TABELA */
                _.Move(GE0071W.LK_0071_S_ARR.LK_0071_NOM_TABELA, WORK.WS_ERRO.WS_TABELA);

                /*" -2927- MOVE LK-0071-SQLCODE TO WS-SQLCODE */
                _.Move(GE0071W.LK_0071_S_ARR.LK_0071_SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -2929- MOVE LK-0071-SQLERRMC TO WS-SQLERRMC */
                _.Move(GE0071W.LK_0071_S_ARR.LK_0071_SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -2930- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -2932- END-IF */
            }


            /*" -2932- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P1001_99_EXIT*/

        [StopWatch]
        /*" P1010-BILHETE-COBERTURA-SECTION */
        private void P1010_BILHETE_COBERTURA_SECTION()
        {
            /*" -2943- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P1010_00_START */

            P1010_00_START();

        }

        [StopWatch]
        /*" P1010-00-START */
        private void P1010_00_START(bool isPerform = false)
        {
            /*" -2947- MOVE 'P1010' TO WS-SECTION */
            _.Move("P1010", WORK.WS_ERRO.WS_SECTION);

            /*" -2948- MOVE BILHETE-NUM-BILHETE TO WS-DECIMAL(01) */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE, WORK.WS_EDIT.WS_DECIMAL[01]);

            /*" -2950- MOVE BILHETE-COD-PRODUTO TO BILCOBER-COD-PRODUTO WS-SMALLINT(01) */
            _.Move(BILHETE.DCLBILHETE.BILHETE_COD_PRODUTO, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_PRODUTO, WORK.WS_EDIT.WS_SMALLINT[01]);

            /*" -2952- MOVE BILHETE-RAMO TO BILCOBER-RAMO-COBERTURA WS-SMALLINT(02) */
            _.Move(BILHETE.DCLBILHETE.BILHETE_RAMO, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_RAMO_COBERTURA, WORK.WS_EDIT.WS_SMALLINT[02]);

            /*" -2954- MOVE BILHETE-OPC-COBERTURA TO BILCOBER-COD-OPCAO-PLANO WS-SMALLINT(03) */
            _.Move(BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_OPCAO_PLANO, WORK.WS_EDIT.WS_SMALLINT[03]);

            /*" -2956- MOVE BILHETE-DATA-QUITACAO TO BILCOBER-DATA-INIVIGENCIA */
            _.Move(BILHETE.DCLBILHETE.BILHETE_DATA_QUITACAO, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_DATA_INIVIGENCIA);

            /*" -2956- . */

        }

        [StopWatch]
        /*" P1010-05-INICIO */
        private void P1010_05_INICIO(bool isPerform = false)
        {
            /*" -2976- PERFORM P1010_05_INICIO_DB_SELECT_1 */

            P1010_05_INICIO_DB_SELECT_1();

            /*" -2979- IF NOT ( SQLCODE = 0 OR = 100 OR = -811 ) */

            if (!(DB.SQLCODE.In("0", "100", "-811")))
            {

                /*" -2980- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -2988- STRING WS-SECTION ' - ERRO NO SELECT SEGUROS.BILHETE_COBERTURA.' '<NUM_CERTIFICADO=' WS-DECIMAL(01) '>' '<COD_PRODUTO=' WS-SMALLINT(01) '>' '<RAMO=' WS-SMALLINT(02) '>' '<OPC_COBERTURA=' WS-SMALLINT(03) '>' '<DATA_QUITACAO=' BILHETE-DATA-QUITACAO '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl125 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl125 += " - ERRO NO SELECT SEGUROS.BILHETE_COBERTURA.";
                spl125 += "<NUM_CERTIFICADO=";
                var spl126 = WORK.WS_EDIT.WS_DECIMAL[01].GetMoveValues();
                spl126 += ">";
                spl126 += "<COD_PRODUTO=";
                var spl127 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl127 += ">";
                spl127 += "<RAMO=";
                var spl128 = WORK.WS_EDIT.WS_SMALLINT[02].GetMoveValues();
                spl128 += ">";
                spl128 += "<OPC_COBERTURA=";
                var spl129 = WORK.WS_EDIT.WS_SMALLINT[03].GetMoveValues();
                spl129 += ">";
                spl129 += "<DATA_QUITACAO=";
                var spl130 = BILHETE.DCLBILHETE.BILHETE_DATA_QUITACAO.GetMoveValues();
                spl130 += ">";
                var results131 = spl125 + spl126 + spl127 + spl128 + spl129 + spl130;
                _.Move(results131, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -2990- MOVE 'SEGUROS.BILHETE_COBERTURA' TO WS-TABELA */
                _.Move("SEGUROS.BILHETE_COBERTURA", WORK.WS_ERRO.WS_TABELA);

                /*" -2991- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -2992- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -2993- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -2995- END-IF */
            }


            /*" -2996- IF SQLCODE = 000 */

            if (DB.SQLCODE == 000)
            {

                /*" -2997- GO TO P1010-99-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P1010_99_EXIT*/ //GOTO
                return;

                /*" -3001- END-IF */
            }


            /*" -3017- PERFORM P1010_05_INICIO_DB_SELECT_2 */

            P1010_05_INICIO_DB_SELECT_2();

            /*" -3020- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -3021- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -3028- STRING WS-SECTION ' - ERRO NO SELECT SEGUROS.BILHETE_COBERTURA.' '<NUM_CERTIFICADO=' WS-DECIMAL(01) '>' '<RAMO=' WS-SMALLINT(02) '>' '<OPC_COBERTURA=' WS-SMALLINT(03) '>' '<DATA_QUITACAO=' BILHETE-DATA-QUITACAO '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl131 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl131 += " - ERRO NO SELECT SEGUROS.BILHETE_COBERTURA.";
                spl131 += "<NUM_CERTIFICADO=";
                var spl132 = WORK.WS_EDIT.WS_DECIMAL[01].GetMoveValues();
                spl132 += ">";
                spl132 += "<RAMO=";
                var spl133 = WORK.WS_EDIT.WS_SMALLINT[02].GetMoveValues();
                spl133 += ">";
                spl133 += "<OPC_COBERTURA=";
                var spl134 = WORK.WS_EDIT.WS_SMALLINT[03].GetMoveValues();
                spl134 += ">";
                spl134 += "<DATA_QUITACAO=";
                var spl135 = BILHETE.DCLBILHETE.BILHETE_DATA_QUITACAO.GetMoveValues();
                spl135 += ">";
                var results136 = spl131 + spl132 + spl133 + spl134 + spl135;
                _.Move(results136, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -3030- MOVE 'SEGUROS.BILHETE_COBERTURA' TO WS-TABELA */
                _.Move("SEGUROS.BILHETE_COBERTURA", WORK.WS_ERRO.WS_TABELA);

                /*" -3031- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -3032- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -3033- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -3035- END-IF */
            }


            /*" -3036- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3037- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -3045- STRING WS-SECTION ' - INFORMACOES ' 'DE BILHETE_COBERTURA NAO ENCONTRADA.' '<NUM_CERTIFICADO=' WS-DECIMAL(01) '>' '<COD_PRODUTO=' WS-SMALLINT(01) '>' '<RAMO=' WS-SMALLINT(02) '>' '<OPC_COBERTURA=' WS-SMALLINT(03) '>' '<DATA_QUITACAO=' BILHETE-DATA-QUITACAO '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl136 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl136 += " - INFORMACOES ";
                spl136 += "DE BILHETE_COBERTURA NAO ENCONTRADA.";
                spl136 += "<NUM_CERTIFICADO=";
                var spl137 = WORK.WS_EDIT.WS_DECIMAL[01].GetMoveValues();
                spl137 += ">";
                spl137 += "<COD_PRODUTO=";
                var spl138 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl138 += ">";
                spl138 += "<RAMO=";
                var spl139 = WORK.WS_EDIT.WS_SMALLINT[02].GetMoveValues();
                spl139 += ">";
                spl139 += "<OPC_COBERTURA=";
                var spl140 = WORK.WS_EDIT.WS_SMALLINT[03].GetMoveValues();
                spl140 += ">";
                spl140 += "<DATA_QUITACAO=";
                var spl141 = BILHETE.DCLBILHETE.BILHETE_DATA_QUITACAO.GetMoveValues();
                spl141 += ">";
                var results142 = spl136 + spl137 + spl138 + spl139 + spl140 + spl141;
                _.Move(results142, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -3046- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -3047- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -3048- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -3050- END-IF */
            }


            /*" -3050- . */

        }

        [StopWatch]
        /*" P1010-05-INICIO-DB-SELECT-1 */
        public void P1010_05_INICIO_DB_SELECT_1()
        {
            /*" -2976- EXEC SQL SELECT BI001.IMP_SEGURADA_IX ,BI001.PRM_TOTAL INTO :VG103-VLR-IS ,:VG103-VLR-PREMIO FROM SEGUROS.BILHETE_COBERTURA BI001 WHERE BI001.COD_PRODUTO = :BILCOBER-COD-PRODUTO AND BI001.RAMO_COBERTURA = :BILCOBER-RAMO-COBERTURA AND BI001.COD_OPCAO_PLANO = :BILCOBER-COD-OPCAO-PLANO AND :BILCOBER-DATA-INIVIGENCIA BETWEEN BI001.DATA_INIVIGENCIA AND BI001.DATA_TERVIGENCIA WITH UR END-EXEC */

            var p1010_05_INICIO_DB_SELECT_1_Query1 = new P1010_05_INICIO_DB_SELECT_1_Query1()
            {
                BILCOBER_DATA_INIVIGENCIA = BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_DATA_INIVIGENCIA.ToString(),
                BILCOBER_COD_OPCAO_PLANO = BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_OPCAO_PLANO.ToString(),
                BILCOBER_RAMO_COBERTURA = BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_RAMO_COBERTURA.ToString(),
                BILCOBER_COD_PRODUTO = BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_PRODUTO.ToString(),
            };

            var executed_1 = P1010_05_INICIO_DB_SELECT_1_Query1.Execute(p1010_05_INICIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VG103_VLR_IS, VG103.DCLVG_CRITICA_PROPOSTA.VG103_VLR_IS);
                _.Move(executed_1.VG103_VLR_PREMIO, VG103.DCLVG_CRITICA_PROPOSTA.VG103_VLR_PREMIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P1010_99_EXIT*/

        [StopWatch]
        /*" P1010-05-INICIO-DB-SELECT-2 */
        public void P1010_05_INICIO_DB_SELECT_2()
        {
            /*" -3017- EXEC SQL SELECT BI001.IMP_SEGURADA_IX ,BI001.PRM_TOTAL INTO :VG103-VLR-IS ,:VG103-VLR-PREMIO FROM SEGUROS.BILHETE_COBERTURA BI001 WHERE BI001.COD_PRODUTO = :BILCOBER-COD-PRODUTO AND BI001.RAMO_COBERTURA = :BILCOBER-RAMO-COBERTURA AND BI001.COD_OPCAO_PLANO = :BILCOBER-COD-OPCAO-PLANO AND :BILCOBER-DATA-INIVIGENCIA BETWEEN BI001.DATA_INIVIGENCIA AND BI001.DATA_TERVIGENCIA FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC */

            var p1010_05_INICIO_DB_SELECT_2_Query1 = new P1010_05_INICIO_DB_SELECT_2_Query1()
            {
                BILCOBER_DATA_INIVIGENCIA = BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_DATA_INIVIGENCIA.ToString(),
                BILCOBER_COD_OPCAO_PLANO = BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_OPCAO_PLANO.ToString(),
                BILCOBER_RAMO_COBERTURA = BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_RAMO_COBERTURA.ToString(),
                BILCOBER_COD_PRODUTO = BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_PRODUTO.ToString(),
            };

            var executed_1 = P1010_05_INICIO_DB_SELECT_2_Query1.Execute(p1010_05_INICIO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VG103_VLR_IS, VG103.DCLVG_CRITICA_PROPOSTA.VG103_VLR_IS);
                _.Move(executed_1.VG103_VLR_PREMIO, VG103.DCLVG_CRITICA_PROPOSTA.VG103_VLR_PREMIO);
            }


        }

        [StopWatch]
        /*" P9999-ERRO-SECTION */
        private void P9999_ERRO_SECTION()
        {
            /*" -3062- IF LK-VG001-TRACE = 'S' */

            if (SPVG001W.LK_VG001_TRACE == "S")
            {

                /*" -3063- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -3064- DISPLAY '*         E R R O    S P B V G 0 0 1         *' */
                _.Display($"*         E R R O    S P B V G 0 0 1         *");

                /*" -3065- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -3066- DISPLAY '* SECTION..........: ' WS-SECTION */
                _.Display($"* SECTION..........: {WORK.WS_ERRO.WS_SECTION}");

                /*" -3067- DISPLAY '* IND ERRO.........: ' WS-IND-ERRO */
                _.Display($"* IND ERRO.........: {WORK.WS_ERRO.WS_IND_ERRO}");

                /*" -3068- DISPLAY '* TABELA...........: ' WS-TABELA */
                _.Display($"* TABELA...........: {WORK.WS_ERRO.WS_TABELA}");

                /*" -3069- DISPLAY '* MENSAGEM.........: ' WS-MENSAGEM */
                _.Display($"* MENSAGEM.........: {WORK.WS_ERRO.WS_MENSAGEM}");

                /*" -3070- DISPLAY '* SQLCODE..........: ' WS-SQLCODE */
                _.Display($"* SQLCODE..........: {WORK.WS_ERRO.WS_SQLCODE}");

                /*" -3071- DISPLAY '* SQLERRMC.........: ' WS-SQLERRMC */
                _.Display($"* SQLERRMC.........: {WORK.WS_ERRO.WS_SQLERRMC}");

                /*" -3072- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -3074- END-IF */
            }


            /*" -3075- MOVE WS-IND-ERRO TO LK-VG001-IND-ERRO */
            _.Move(WORK.WS_ERRO.WS_IND_ERRO, SPVG001W.LK_VG001_IND_ERRO);

            /*" -3076- MOVE WS-MENSAGEM TO LK-VG001-MSG-ERRO */
            _.Move(WORK.WS_ERRO.WS_MENSAGEM, SPVG001W.LK_VG001_MSG_ERRO);

            /*" -3077- MOVE WS-TABELA TO LK-VG001-NOM-TABELA */
            _.Move(WORK.WS_ERRO.WS_TABELA, SPVG001W.LK_VG001_NOM_TABELA);

            /*" -3078- MOVE WS-SQLCODE TO LK-VG001-SQLCODE */
            _.Move(WORK.WS_ERRO.WS_SQLCODE, SPVG001W.LK_VG001_SQLCODE);

            /*" -3080- MOVE WS-SQLERRMC TO LK-VG001-SQLERRMC */
            _.Move(WORK.WS_ERRO.WS_SQLERRMC, SPVG001W.LK_VG001_SQLERRMC);

            /*" -3080- . */

            /*" -0- FLUXCONTROL_PERFORM P9999_99_EXIT */

            P9999_99_EXIT();

        }

        [StopWatch]
        /*" P9999-99-EXIT */
        private void P9999_99_EXIT(bool isPerform = false)
        {
            /*" -3083- GOBACK. */

            throw new GoBack();

        }
    }
}