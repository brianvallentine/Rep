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
using Sias.Geral.DB2.GE0350S;

namespace Code
{
    public class GE0350S
    {
        public bool IsCall { get; set; }

        public GE0350S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *   SISTEMA ................  SIGCB - BOLETO REGISTRADO SAP      *      */
        /*"      *   PROGRAMA ...............  GE0350S                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  ELIERMES OLIVEIRA                  *      */
        /*"      *   PROGRAMADOR ............  ELIERMES OLIVEIRA                  *      */
        /*"      *   DATA CODIFICACAO .......  SETEMBRO 2016                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO: SUB-ROTINA PARA GRAVACAO DA TABELA DE CONTROLE DE    *      */
        /*"      *           EMISSAO DO SIGCB PARA INTERFACE COM SAP              *      */
        /*"      *              (SEGUROS.GE_CONTROLE_EMISSAO_SIGCB)               *      */
        /*"      *                                                                *      */
        /*"      *   CADMUS VIDA - 140.778                                        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *-------------------   FUNCOES CADASTRADAS   --------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * FUNCAO 01 - Consulta se existe NN v�lido                       *      */
        /*"      * FUNCAO 02 - Solicita novo NN para o SAP                        *      */
        /*"      * FUNCAO 03 - Alterar situacao de registro NN                    *      */
        /*"      * FUNCAO 04 - Inserir NN registrado pelo SAP                     *      */
        /*"      * FUNCAO 05 - Consulta se existe NN por IDLG                     *      */
        /*"      * FUNCAO 06 - Consulta por NN registrado retornado pelo SAP      *      */
        /*"      * FUNCAO 07 - Solicita novo NN para o SAP via Servi�o Online no  *      */
        /*"      *             Barramento.                                        *      */
        /*"      * FUNCAO 08 - INSERIR APENAS SITUA��O NO HIST�RICO DO NN         *      */
        /*"      * FUNCAO 09 - ATUALIZAR OS DADOS CORRETAMENTE  QUE FORAM GRAVADOS*      */
        /*"      *             no retorno do SAP, em que n�o havia ainda a emiss�o*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                   HISTORICO DE ALTERACAO                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 23 - DEMANDA 506320                                   *      */
        /*"      *             - TRUNCAR O ULTIMO DIGITO PARA CERTIFICADOS COM    *      */
        /*"      *               MAIS DE 14 DIGITOS POR ESTAR RETORNANDO CRITICA  *      */
        /*"      *               DO SERVICO SAP.                                  *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/08/2023 - FELIPE LARA              PROCURE POR V.23    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.22  *VERSAO 22: ABEND 283392 - TAREFA 283575                         *      */
        /*"      *           01/04/2021   - HUSNI ALI HUSNI                       *      */
        /*"      *           COLOCAR A FUNCAO ACIONADA QUANDO MOSTRAO O ERRO      *      */
        /*"      *                         - PROCURAR POR V.22                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.21  *VERSAO 21: DEMANDA 274927 - KINKAS 19/01/2021                   *      */
        /*"      *           RETIRANDO CARACTERES ESPECIAIS Dos campos de endereco*      */
        /*"      *           - PROCURAR POR V.21                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 20 - DEMANDA 226662/TAREFA 247396                     *      */
        /*"      *               08/06/2020 - HUSNI ALI HUSNI                     *      */
        /*"      *         SE RAMO DO PRODUTO IGUAL A 81, 82, 93, 97              *      */
        /*"      *            SE DATA-VENCIMENTO ENTRE '2020-06-09 A '2020-06-28' *      */
        /*"      *                 MOVE 1 PARA QUANTIDADE DE DIAS DE CUSTODIA     *      */
        /*"      *            SE DATA-VENCIMENTO ENTRE '2020-06-29 A '2020-06-30' *      */
        /*"      *                 MOVE 1 PARA QUANTIDADE DE DIAS DE CUSTODIA     *      */
        /*"      *                 MOVE '2020-07-06'  PARA DATA-VENCIMENTO        *      */
        /*"      *            SE DATA-VENCIMENTO ENTRE '2020-07-01 A '2020-06-09' *      */
        /*"      *                 MOVE 1 PARA QUANTIDADE DE DIAS DE CUSTODIA     *      */
        /*"      *                 MOVE '2020-07-10'  PARA DATA-VENCIMENTO        *      */
        /*"      *            SE DATA-VENCIMENTO MAIOR OU IGUAL '2020-07-11'      *      */
        /*"      *                 MOVE 10 PARA QUANTIDADE DE DIAS DE CUSTODIA    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 19 - CADMUS 182664  - 20/05/2020 - HUSNI ALI HUSNI    *      */
        /*"      *               INCIDENTE JAZZ = 245092                          *      */
        /*"      *                                                                *      */
        /*"      *             - RETIRAR DISPLAY PARA IDENTIFICACAO DE -530       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 18 - CADMUS 182664  - 20/05/2020 - HUSNI ALI HUSNI    *      */
        /*"      *               INCIDENTE JAZZ = 245092                          *      */
        /*"      *                                                                *      */
        /*"      *             - COLOCAR DISPLAY PARA IDENTIFICACAO DE -530       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 01 - CADMUS 140.778                                   *      */
        /*"      *             - QUANDO FOR SOLICITADA A GRAVACAO DE SITUACAO     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 01 - CADMUS 140.778                                   *      */
        /*"      *             - QUANDO FOR SOLICITADA A GRAVACAO DE SITUACAO     *      */
        /*"      *               'I', O SISTEMA GRAVA APENAS HISTORICO DO SIGCB   *      */
        /*"      *                                                                *      */
        /*"      *   EM 17/01/2017 - ELIERMES OLIVEIRA                V.01        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 02 - CADMUS SIGCB AUTO  - CADMUS 140525               *      */
        /*"      *             - AJUSTE PARA ADAPTAR CHAMADA PARA CANCELAMENTO AUTO      */
        /*"      *                                                                *      */
        /*"      *   EM 03/06/2017 - DIRID/ DIEGO DIAS / LISIANE      V.02        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 04 - CADMUS 152.798                                   *      */
        /*"      *             - INCLUIR APENAS NOVA SITUACAO NA HISTORICO DO     *      */
        /*"      *               SIGCB                                            *      */
        /*"      *                                                                *      */
        /*"      *   EM 09/08/2017 - ELIERMES OLIVEIRA                V.04        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 05 - CADMUS 153.641                                   *      */
        /*"      *             - ACEITAR CUSTODIA ZERO PARA PRODUTOS AUTO         *      */
        /*"      *               COM EMISSAO DE SEGUNDA CARTA DE COBRANCA         *      */
        /*"      *                                                                *      */
        /*"      *   EM 12/09/2017 - DIEGO DIAS                       V.05        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 06 - ABEND  154.456 EM 06/10/2017 - DIEGO DIAS MOREIRA       */
        /*"      *                                                                *      */
        /*"      *               ATUALIZAR REIGSTRO NA GE_CONTROLE_EMISAO_SIGCB EM*      */
        /*"      *               QUE O RETORNO DO SAP ACONTECEU ANTES DO SIAS     *      */
        /*"      *               RECEBER O ARQUIVO DE EMISSAO DA SULAMERICA/AUTO. *      */
        /*"      *               ATUALIZAR APENAS DADOS DA AP�LICE                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 07 - HIST�RIA 11911 EM 09/05/2018 - CLAUDETE RADEL    *      */
        /*"      *                                                                *      */
        /*"      *               ATUALIZAR TAMANHO DO CAMPO LK-NUM-CONTA-CONTRATO-*      */
        /*"      *               PARA ENVIAR O N�MERO DO CERTIFICADO              *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 08 - ABEND 167734   EM 29/06/2018 - CLAUDETE RADEL    *      */
        /*"      *                                                                *      */
        /*"      *               SUBIR DISPLAY PARA ACOMPANHAR ABEND.             *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 09 - EXCESSO DE DISPLAY - 22/01/2019 - CLOVIS         *      */
        /*"      *                                                                *      */
        /*"      *               RETIRADA DOS DISPLAY.                            *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 10 - PROJETO CILEO EM 05/11/2019 - FRANK CARVALHO     *      */
        /*"      *                                                                *      */
        /*"      *             - ENVIAR NA COMPRA DE NN ONLINE O NUM-CERTIFICADO  *      */
        /*"      *               AO INVES DO NUM-APOLICE QUANDO O NUM-PROPOSTA FOR*      */
        /*"      *               IGUAL A ZEROS.                                   *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 11 - DEMANDA 221715 - 19/11/2019 - CLAUDETE RADEL     *      */
        /*"      *                                                                *      */
        /*"      *             - COLOCAR DISPLAYS PARA ENTENDER O PROBLEMA.       *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 12 - DEMANDA 226662 - 05/05/2020 - HUSNI ALI HUSNI    *      */
        /*"      *                                                                *      */
        /*"      *             - ZERAR A QUANTIDADE DE DIAS DE CUSTODIA PARA OS   *      */
        /*"      *               PRODUTOS DE RAMO 81, 82, 93 E 97                 *      */
        /*"      *             - DATA DEVE SER MENOR QUE 2020-06-01               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 13 - DEMANDA 226662 - 07/05/2020 - HUSNI ALI HUSNI    *      */
        /*"      *                                                                *      */
        /*"      *             - MOVE 10 PARA QUANTIDADE DE DIAS DE CUSTODIA      *      */
        /*"      *               QUANDO PRODUTOS DE RAMO 81, 82, 93 E 97          *      */
        /*"      *             - DATA DEVE SER MAIOR IGUAL A 2020-06-01           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 14 - DEMANDA 226662 - 14/05/2020 - HUSNI ALI HUSNI    *      */
        /*"      *                                                                *      */
        /*"      *             - SE RAMO DO PRODUTO IGUAL A 81, 82, 93, 97        *      */
        /*"      *                 SE DATA VENCIMENTO MENOR IGUAL 2020-06-10      *      */
        /*"      *                    MOVE 00 PARA QUANTIDADE DE DIAS DE CUSTODIA *      */
        /*"      *                 SE DATA VENCIMENTO MAIOR QUE   2020-06-10      *      */
        /*"      *                    MOVE 10 PARA QUANTIDADE DE DIAS DE CUSTODIA *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 15 - DEMANDA 226662 - 18/05/2020 - HUSNI ALI HUSNI    *      */
        /*"      *                                                                *      */
        /*"      *             - SE RAMO DO PRODUTO IGUAL A 81, 82, 93, 97        *      */
        /*"      *                  MOVE 10 PARA QUANTIDADE DE DIAS DE CUSTODIA   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 16 - CADMUS 182650  - 19/05/2020 - HUSNI ALI HUSNI    *      */
        /*"      *                                                                *      */
        /*"      *             - ACERTO DE END-IF                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * EM 19/05/2020 - DIEGO DIAS                                     *      */
        /*"      *   VERSAO 17 - ABEND   18264 -  DIEGO DIAS MOREIRA              *      */
        /*"      *             - SQLCODE -181 - APOL: 1103101445105  END:0 PARC:04*      */
        /*"      *             - CORRECAO DA VERS�O V.12 e V.15                   *      */
        /*"      * DATA - 19/08/2020 - HORA: 19:21                                *      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"77   WS-NUM-PROPOSTA-14         PIC  9(014) VALUE ZEROS.*/
        public IntBasis WS_NUM_PROPOSTA_14 { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
        /*"77   WS-NUM-PROPOSTA            PIC  9(015) VALUE ZEROS.*/
        public IntBasis WS_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
        /*"77   W-CALL                     PIC  X(008) VALUE SPACES.*/
        public StringBasis W_CALL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"77   W-GE350-NUM-PROPOSTA-ED    PIC ZZZZZZZZZZZZZZZ9-.*/
        public IntBasis W_GE350_NUM_PROPOSTA_ED { get; set; } = new IntBasis(new PIC("9", "17", "ZZZZZZZZZZZZZZZ9-."));
        /*"77   HOST-TIMESTAMP             PIC  X(026) VALUE SPACES.*/
        public StringBasis HOST_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
        /*"77   HOST-SI-DATA-MOV-ABERTO    PIC  X(010) VALUE SPACES.*/
        public StringBasis HOST_SI_DATA_MOV_ABERTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77   HOST-SI-CURRENT-DATE       PIC  X(010) VALUE SPACES.*/
        public StringBasis HOST_SI_CURRENT_DATE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77   HOST-CURRENT-DATE          PIC  X(010) VALUE SPACES.*/
        public StringBasis HOST_CURRENT_DATE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77   HOST-CURRENT-TIME          PIC  X(008) VALUE SPACES.*/
        public StringBasis HOST_CURRENT_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"77   HOST-NUM-IMOVEL            PIC S9(005) VALUE +0 COMP.*/
        public IntBasis HOST_NUM_IMOVEL { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
        /*"77   HOST-NUM-CEP               PIC S9(008) VALUE +0 COMP.*/
        public IntBasis HOST_NUM_CEP { get; set; } = new IntBasis(new PIC("S9", "8", "S9(008)"));
        /*"77   HOST-COUNT                 PIC S9(009) VALUE +0 COMP.*/
        public IntBasis HOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77   VIND-SEQ-TIPO-OBJ-SEG      PIC S9(004) VALUE +0 COMP.*/
        public IntBasis VIND_SEQ_TIPO_OBJ_SEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77   WS-DTA-VENC-CUSTODIA       PIC  X(010) VALUE SPACES.*/
        public StringBasis WS_DTA_VENC_CUSTODIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77   WS-IND-NN-SAP              PIC S9(004) VALUE +0 COMP.*/
        public IntBasis WS_IND_NN_SAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77   WS-IND-COD-CEDENTE         PIC S9(004) VALUE +0 COMP.*/
        public IntBasis WS_IND_COD_CEDENTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77   WS-IND-BOL-INT             PIC S9(004) VALUE +0 COMP.*/
        public IntBasis WS_IND_BOL_INT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77   WS-IND-COD-LIN-DIG         PIC S9(004) VALUE +0 COMP.*/
        public IntBasis WS_IND_COD_LIN_DIG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77   WS-IND-NUM-TITULO          PIC S9(004) VALUE +0 COMP.*/
        public IntBasis WS_IND_NUM_TITULO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77   WS-IND-NUM-IDLG            PIC S9(004) VALUE +0 COMP.*/
        public IntBasis WS_IND_NUM_IDLG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77   WS-IND-OCORR-MOVTO         PIC S9(004) VALUE +0 COMP.*/
        public IntBasis WS_IND_OCORR_MOVTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77   WS-IND-COD-REJEICAO        PIC S9(004) VALUE +0 COMP.*/
        public IntBasis WS_IND_COD_REJEICAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77   WS-IND-NUM-OCORR-MOVTO     PIC S9(004) VALUE +0 COMP.*/
        public IntBasis WS_IND_NUM_OCORR_MOVTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77   WS-SEQ-CONTROLE-HIST       PIC S9(004) VALUE +0 COMP.*/
        public IntBasis WS_SEQ_CONTROLE_HIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77   WS-IND-NULL-ED             PIC 999-.*/
        public IntBasis WS_IND_NULL_ED { get; set; } = new IntBasis(new PIC("9", "4", "999-."));
        /*"77   WS-LENGTH-ED               PIC 9999.*/
        public IntBasis WS_LENGTH_ED { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
        /*"77   WS-SQLCODE-ED              PIC -9999.*/
        public IntBasis WS_SQLCODE_ED { get; set; } = new IntBasis(new PIC("9", "4", "-9999."));
        /*"77   W77-OUT-RETC               PIC 9(04).*/
        public IntBasis W77_OUT_RETC { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
        /*"77   W77-VLR-PREMIO-LIQUIDO     PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis W77_VLR_PREMIO_LIQUIDO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77   NULL-COD-AGENCIA              PIC S9(04) COMP VALUE +0.*/
        public IntBasis NULL_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77   NULL-COD-BANCO                PIC S9(04) COMP VALUE +0.*/
        public IntBasis NULL_COD_BANCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01        W-CONVERTE-CARACTERES.*/
        public GE0350S_W_CONVERTE_CARACTERES W_CONVERTE_CARACTERES { get; set; } = new GE0350S_W_CONVERTE_CARACTERES();
        public class GE0350S_W_CONVERTE_CARACTERES : VarBasis
        {
            /*"    03    W-CONVERTE-CH-DE.*/
            public GE0350S_W_CONVERTE_CH_DE W_CONVERTE_CH_DE { get; set; } = new GE0350S_W_CONVERTE_CH_DE();
            public class GE0350S_W_CONVERTE_CH_DE : VarBasis
            {
                /*"       05 W-D000F PIC X(016) VALUE '
                �	����       05 W-D101F PIC X(016) VALUE '����'.*/
                public StringBasis W_D000F { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"
�	����");
                /*"       05 W-D202F PIC X(016) VALUE '����������'.*/
                public StringBasis W_D202F { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"����������");
                /*"       05 W-D303F PIC X(016) VALUE '�����������'.*/
                public StringBasis W_D303F { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"�����������");
                /*"       05 W-D405F PIC X(011) VALUE '����������'.*/
                public StringBasis W_D405F { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"����������");
                /*"       05 W-D607F PIC X(011) VALUE '����������`'.*/
                public StringBasis W_D607F { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"����������`");
                /*"       05 W-D809F PIC X(014) VALUE 'ث���������Ƥ'.*/
                public StringBasis W_D809F { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"ث���������Ƥ");
                /*"       05 W-DA0BF PIC X(022) VALUE '�~����ޮ^�������������'.*/
                public StringBasis W_DA0BF { get; set; } = new StringBasis(new PIC("X", "22", "X(022)"), @"�~����ޮ^�������������");
                /*"       05 W-DC0DF PIC X(008) VALUE '�������'.*/
                public StringBasis W_DC0DF { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"�������");
                /*"       05 W-DE0FF PIC X(009) VALUE '��ҳ���ڟ'.*/
                public StringBasis W_DE0FF { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"��ҳ���ڟ");
                /*"    03    W-CONVERTE-DE REDEFINES W-CONVERTE-CH-DE PIC X(139).*/
            }
            private _REDEF_StringBasis _w_converte_de { get; set; }
            public _REDEF_StringBasis W_CONVERTE_DE
            {
                get { _w_converte_de = new _REDEF_StringBasis(new PIC("X", "139", "X(139).")); ; _.Move(W_CONVERTE_CH_DE, _w_converte_de); VarBasis.RedefinePassValue(W_CONVERTE_CH_DE, _w_converte_de, W_CONVERTE_CH_DE); _w_converte_de.ValueChanged += () => { _.Move(_w_converte_de, W_CONVERTE_CH_DE); }; return _w_converte_de; }
                set { VarBasis.RedefinePassValue(value, _w_converte_de, W_CONVERTE_CH_DE); }
            }  //Redefines
            /*"    03    W-CONVERTE-CH-PARA.*/
            public GE0350S_W_CONVERTE_CH_PARA W_CONVERTE_CH_PARA { get; set; } = new GE0350S_W_CONVERTE_CH_PARA();
            public class GE0350S_W_CONVERTE_CH_PARA : VarBasis
            {
                /*"       05 W-P000F PIC X(016) VALUE '                '.*/
                public StringBasis W_P000F { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"                ");
                /*"       05 W-P101F PIC X(016) VALUE '                '.*/
                public StringBasis W_P101F { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"                ");
                /*"       05 W-P202F PIC X(016) VALUE '                '.*/
                public StringBasis W_P202F { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"                ");
                /*"       05 W-P303F PIC X(016) VALUE '                '.*/
                public StringBasis W_P303F { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"                ");
                /*"       05 W-P405F PIC X(011) VALUE '           '.*/
                public StringBasis W_P405F { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"           ");
                /*"       05 W-P607F PIC X(011) VALUE '           '.*/
                public StringBasis W_P607F { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"           ");
                /*"       05 W-P809F PIC X(014) VALUE '              '.*/
                public StringBasis W_P809F { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"              ");
                /*"       05 W-PA0BF PIC X(022) VALUE '                      '.*/
                public StringBasis W_PA0BF { get; set; } = new StringBasis(new PIC("X", "22", "X(022)"), @"                      ");
                /*"       05 W-PC0DF PIC X(008) VALUE '        '.*/
                public StringBasis W_PC0DF { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"        ");
                /*"       05 W-PE0FF PIC X(009) VALUE '         '.*/
                public StringBasis W_PE0FF { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"         ");
                /*"    03 W-CONVERTE-PARA REDEFINES W-CONVERTE-CH-PARA PIC X(139).*/
            }
            private _REDEF_StringBasis _w_converte_para { get; set; }
            public _REDEF_StringBasis W_CONVERTE_PARA
            {
                get { _w_converte_para = new _REDEF_StringBasis(new PIC("X", "139", "X(139).")); ; _.Move(W_CONVERTE_CH_PARA, _w_converte_para); VarBasis.RedefinePassValue(W_CONVERTE_CH_PARA, _w_converte_para, W_CONVERTE_CH_PARA); _w_converte_para.ValueChanged += () => { _.Move(_w_converte_para, W_CONVERTE_CH_PARA); }; return _w_converte_para; }
                set { VarBasis.RedefinePassValue(value, _w_converte_para, W_CONVERTE_CH_PARA); }
            }  //Redefines
            /*"01    WS-IND-FLAG                    PIC S9(004) COMP VALUE 0.*/
        }
        public IntBasis WS_IND_FLAG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01    WS-EDITED.*/
        public GE0350S_WS_EDITED WS_EDITED { get; set; } = new GE0350S_WS_EDITED();
        public class GE0350S_WS_EDITED : VarBasis
        {
            /*"  05  WS-SMALLINT                    PIC  ZZZZ9- OCCURS 5 TIMES.*/
            public ListBasis<IntBasis, Int64> WS_SMALLINT { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "6", "ZZZZ9-"), 5);
            /*"  05  WS-INTEGER                     PIC  ZZZZZZZZZ9-                                                 OCCURS 5 TIMES.*/
            public ListBasis<IntBasis, Int64> WS_INTEGER { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "11", "ZZZZZZZZZ9-"), 5);
            /*"  05  WS-BIGINT                      PIC  ZZZZZZZZZZZZZZZ9-                                                 OCCURS 5 TIMES.*/
            public ListBasis<IntBasis, Int64> WS_BIGINT { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "17", "ZZZZZZZZZZZZZZZ9-"), 5);
            /*"01   AREA-DE-WORK.*/
        }
        public GE0350S_AREA_DE_WORK AREA_DE_WORK { get; set; } = new GE0350S_AREA_DE_WORK();
        public class GE0350S_AREA_DE_WORK : VarBasis
        {
            /*"  05  WSL-SQLCODE                   PIC 9(009) VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05  WS-DATA-AUX                   PIC X(010) VALUE SPACES.*/
            public StringBasis WS_DATA_AUX { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05  WS-NN-TITULO-AUX              PIC 9(018).*/
            public IntBasis WS_NN_TITULO_AUX { get; set; } = new IntBasis(new PIC("9", "18", "9(018)."));
            /*"  05  WS-NN-TITULO-AUX-R  REDEFINES WS-NN-TITULO-AUX.*/
            private _REDEF_GE0350S_WS_NN_TITULO_AUX_R _ws_nn_titulo_aux_r { get; set; }
            public _REDEF_GE0350S_WS_NN_TITULO_AUX_R WS_NN_TITULO_AUX_R
            {
                get { _ws_nn_titulo_aux_r = new _REDEF_GE0350S_WS_NN_TITULO_AUX_R(); _.Move(WS_NN_TITULO_AUX, _ws_nn_titulo_aux_r); VarBasis.RedefinePassValue(WS_NN_TITULO_AUX, _ws_nn_titulo_aux_r, WS_NN_TITULO_AUX); _ws_nn_titulo_aux_r.ValueChanged += () => { _.Move(_ws_nn_titulo_aux_r, WS_NN_TITULO_AUX); }; return _ws_nn_titulo_aux_r; }
                set { VarBasis.RedefinePassValue(value, _ws_nn_titulo_aux_r, WS_NN_TITULO_AUX); }
            }  //Redefines
            public class _REDEF_GE0350S_WS_NN_TITULO_AUX_R : VarBasis
            {
                /*"       10 FILLER                     PIC 9(002).*/
                public IntBasis FILLER_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 WS-NUM-TITULO-AUX          PIC 9(015).*/
                public IntBasis WS_NUM_TITULO_AUX { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"       10 FILLER                     PIC 9(001).*/
                public IntBasis FILLER_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  05  WS-PRODUTO.*/

                public _REDEF_GE0350S_WS_NN_TITULO_AUX_R()
                {
                    FILLER_0.ValueChanged += OnValueChanged;
                    WS_NUM_TITULO_AUX.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                }

            }
            public GE0350S_WS_PRODUTO WS_PRODUTO { get; set; } = new GE0350S_WS_PRODUTO();
            public class GE0350S_WS_PRODUTO : VarBasis
            {
                /*"     10 WS-L000                      PIC X(004).*/
                public StringBasis WS_L000 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"     10 WS-COD-PRODUTO               PIC 9(004).*/
                public IntBasis WS_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05  WS-PROD                        PIC 9(004).*/
            }
            public IntBasis WS_PROD { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05   FILLER REDEFINES    WS-PROD.*/
            private _REDEF_GE0350S_FILLER_2 _filler_2 { get; set; }
            public _REDEF_GE0350S_FILLER_2 FILLER_2
            {
                get { _filler_2 = new _REDEF_GE0350S_FILLER_2(); _.Move(WS_PROD, _filler_2); VarBasis.RedefinePassValue(WS_PROD, _filler_2, WS_PROD); _filler_2.ValueChanged += () => { _.Move(_filler_2, WS_PROD); }; return _filler_2; }
                set { VarBasis.RedefinePassValue(value, _filler_2, WS_PROD); }
            }  //Redefines
            public class _REDEF_GE0350S_FILLER_2 : VarBasis
            {
                /*"     10 WS-RAMO-EMISSOR              PIC 9(002).*/
                public IntBasis WS_RAMO_EMISSOR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"     10 FILLER                       PIC 9(002).*/
                public IntBasis FILLER_3 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05  WS-CNPJ                        PIC 9(14).*/

                public _REDEF_GE0350S_FILLER_2()
                {
                    WS_RAMO_EMISSOR.ValueChanged += OnValueChanged;
                    FILLER_3.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_CNPJ { get; set; } = new IntBasis(new PIC("9", "14", "9(14)."));
            /*"  05  WS-CPF                         PIC 9(11).*/
            public IntBasis WS_CPF { get; set; } = new IntBasis(new PIC("9", "11", "9(11)."));
            /*"  05  WS-SI-CEP                      PIC 9(08).*/
            public IntBasis WS_SI_CEP { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
            /*"  05  WS-SI-FONTE                    PIC 9(03).*/
            public IntBasis WS_SI_FONTE { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
            /*"  05         WS-MENS.*/
            public GE0350S_WS_MENS WS_MENS { get; set; } = new GE0350S_WS_MENS();
            public class GE0350S_WS_MENS : VarBasis
            {
                /*"    10       WS-MENS-DESCR     PIC  X(065)    VALUE  SPACE.*/
                public StringBasis WS_MENS_DESCR { get; set; } = new StringBasis(new PIC("X", "65", "X(065)"), @"");
                /*"    10       FILLER            PIC  X(001)    VALUE  SPACES.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WS-MENS-CAMPO     PIC  X(011)    VALUE  SPACE.*/
                public StringBasis WS_MENS_CAMPO { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"");
                /*"   05        CT0007SW099.*/
                public GE0350S_CT0007SW099 CT0007SW099 { get; set; } = new GE0350S_CT0007SW099();
                public class GE0350S_CT0007SW099 : VarBasis
                {
                    /*"     10      CT0007S-NOME       PIC  X(100).*/
                    public StringBasis CT0007S_NOME { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
                    /*"     10      CT0007S-SOBRENOME  PIC  X(040).*/
                    public StringBasis CT0007S_SOBRENOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                    /*"     10      CT0007S-NOME1      PIC  X(040).*/
                    public StringBasis CT0007S_NOME1 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                    /*"01      LK-GE0005S.*/
                }
            }
        }
        public GE0350S_LK_GE0005S LK_GE0005S { get; set; } = new GE0350S_LK_GE0005S();
        public class GE0350S_LK_GE0005S : VarBasis
        {
            /*"  05    LKGE-RAMO-EMISSOR    PIC  9(004)        VALUE  ZEROS.*/
            public IntBasis LKGE_RAMO_EMISSOR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05    LKGE-MODALIDADE      PIC  9(004)        VALUE  ZEROS.*/
            public IntBasis LKGE_MODALIDADE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05    LKGE-PRODUTO         PIC  9(004)        VALUE  ZEROS.*/
            public IntBasis LKGE_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05    LKGE-INIVIGENCIA     PIC  X(010)        VALUE  ZEROS.*/
            public StringBasis LKGE_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05    LKGE-GRUPO-SUSEP     PIC  9(004)        VALUE  ZEROS.*/
            public IntBasis LKGE_GRUPO_SUSEP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05    LKGE-RAMO-SUSEP      PIC  9(004)        VALUE  ZEROS.*/
            public IntBasis LKGE_RAMO_SUSEP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05    LKGE-SQLCODE         PIC  ---9.*/
            public IntBasis LKGE_SQLCODE { get; set; } = new IntBasis(new PIC("9", "4", "---9."));
            /*"  05    LKGE-MENSAGEM        PIC  X(070)        VALUE  SPACES.*/
            public StringBasis LKGE_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
            /*" 01     GE0007SW099.*/
            public GE0350S_GE0007SW099 GE0007SW099 { get; set; } = new GE0350S_GE0007SW099();
            public class GE0350S_GE0007SW099 : VarBasis
            {
                /*"  10      GE0007S-NUM-APOLICE  PIC  9(013).*/
                public IntBasis GE0007S_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"  10      GE0007S-NUM-ENDOSSO  PIC  9(009).*/
                public IntBasis GE0007S_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"  10      GE0007S-NUM-PROPOSTA PIC  9(014).*/
                public IntBasis GE0007S_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                /*"  10      GE0007S-CANAL-VENDA  PIC  9(004).*/
                public IntBasis GE0007S_CANAL_VENDA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  10      GE0007S-SQLCODE      PIC  9(009).*/
                public IntBasis GE0007S_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"  10      GE0007S-RETURN-CODE  PIC  9(002).*/
                public IntBasis GE0007S_RETURN_CODE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  10      GE0007S-MENS-ERRO    PIC  X(050).*/
                public StringBasis GE0007S_MENS_ERRO { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
                /*"01   WCONTADOR.*/
            }
        }
        public GE0350S_WCONTADOR WCONTADOR { get; set; } = new GE0350S_WCONTADOR();
        public class GE0350S_WCONTADOR : VarBasis
        {
            /*"  05 W-LOTE-NUM-SEQUENCIA            PIC 9(09) VALUE 0.*/
            public IntBasis W_LOTE_NUM_SEQUENCIA { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"  05       WSTATUS               PIC  9(002)     VALUE ZEROS.*/
            public IntBasis WSTATUS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05 W-LOTE.*/
            public GE0350S_W_LOTE W_LOTE { get; set; } = new GE0350S_W_LOTE();
            public class GE0350S_W_LOTE : VarBasis
            {
                /*"    10 W-LOTE-NOME-PROGRAMA          PIC X(08) VALUE 'GE0350S'.*/
                public StringBasis W_LOTE_NOME_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"GE0350S");
                /*"    10 W-LOTE-SIGLA-MODULO           PIC X(02) VALUE '??'.*/
                public StringBasis W_LOTE_SIGLA_MODULO { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"??");
                /*"    10 W-LOTE-DATE-AAAA              PIC 9(04) VALUE 9999.*/
                public IntBasis W_LOTE_DATE_AAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"), 9999);
                /*"    10 W-LOTE-DATE-MM                PIC 9(02) VALUE 12.*/
                public IntBasis W_LOTE_DATE_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"), 12);
                /*"    10 W-LOTE-DATE-DD                PIC 9(02) VALUE 31.*/
                public IntBasis W_LOTE_DATE_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"), 31);
                /*"    10 W-LOTE-TIME-HH                PIC 9(02) VALUE 01.*/
                public IntBasis W_LOTE_TIME_HH { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"), 01);
                /*"    10 W-LOTE-TIME-MM                PIC 9(02) VALUE 01.*/
                public IntBasis W_LOTE_TIME_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"), 01);
                /*"    10 W-LOTE-TIME-SS                PIC 9(02) VALUE 01.*/
                public IntBasis W_LOTE_TIME_SS { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"), 01);
                /*"  05  WFIM-LE-MOVDEBCE-1       PIC  X(003)    VALUE SPACES.*/
            }
            public StringBasis WFIM_LE_MOVDEBCE_1 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05  WFIM-IMPOSTOS            PIC  X(003)    VALUE SPACES.*/
            public StringBasis WFIM_IMPOSTOS { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05  W-AC-LIDOS-MOVDEBCE      PIC  9(005)    VALUE ZEROS.*/
            public IntBasis W_AC_LIDOS_MOVDEBCE { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05 W-DATA-AAAAMMDD.*/
            public GE0350S_W_DATA_AAAAMMDD W_DATA_AAAAMMDD { get; set; } = new GE0350S_W_DATA_AAAAMMDD();
            public class GE0350S_W_DATA_AAAAMMDD : VarBasis
            {
                /*"     10 W-DATA-AAAAMMDD-AAAA         PIC 9(04) VALUE ZEROS.*/
                public IntBasis W_DATA_AAAAMMDD_AAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"     10 W-DATA-AAAAMMDD-MM           PIC 9(02) VALUE ZEROS.*/
                public IntBasis W_DATA_AAAAMMDD_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"     10 W-DATA-AAAAMMDD-DD           PIC 9(02) VALUE ZEROS.*/
                public IntBasis W_DATA_AAAAMMDD_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"  05         WHORA-CURR.*/
            }
            public GE0350S_WHORA_CURR WHORA_CURR { get; set; } = new GE0350S_WHORA_CURR();
            public class GE0350S_WHORA_CURR : VarBasis
            {
                /*"    10       WHORA-HH-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_HH_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORA-MM-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORA-SS-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_SS_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WHORAS.*/
            }
            public GE0350S_WHORAS WHORAS { get; set; } = new GE0350S_WHORAS();
            public class GE0350S_WHORAS : VarBasis
            {
                /*"    10       WHORAS-HH         PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORAS_HH { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORAS-MM         PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORAS_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORAS-SS         PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORAS_SS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORAS-CC         PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORAS_CC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WMONTA-DATA       PIC  X(008)    VALUE SPACES.*/
            }
            public StringBasis WMONTA_DATA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"  05         FILLER            REDEFINES      WMONTA-DATA.*/
            private _REDEF_GE0350S_FILLER_5 _filler_5 { get; set; }
            public _REDEF_GE0350S_FILLER_5 FILLER_5
            {
                get { _filler_5 = new _REDEF_GE0350S_FILLER_5(); _.Move(WMONTA_DATA, _filler_5); VarBasis.RedefinePassValue(WMONTA_DATA, _filler_5, WMONTA_DATA); _filler_5.ValueChanged += () => { _.Move(_filler_5, WMONTA_DATA); }; return _filler_5; }
                set { VarBasis.RedefinePassValue(value, _filler_5, WMONTA_DATA); }
            }  //Redefines
            public class _REDEF_GE0350S_FILLER_5 : VarBasis
            {
                /*"    10       WDATA-DIA         PIC  9(002).*/
                public IntBasis WDATA_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WDATA-MES         PIC  9(002).*/
                public IntBasis WDATA_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WDATA-ANO         PIC  9(004).*/
                public IntBasis WDATA_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05  W-EDICAO                 PIC Z.ZZ9.*/

                public _REDEF_GE0350S_FILLER_5()
                {
                    WDATA_DIA.ValueChanged += OnValueChanged;
                    WDATA_MES.ValueChanged += OnValueChanged;
                    WDATA_ANO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_EDICAO { get; set; } = new IntBasis(new PIC("9", "4", "Z.ZZ9."));
            /*"  05  W-EDICAO-QTD             PIC Z.ZZZ.ZZ9.*/
            public IntBasis W_EDICAO_QTD { get; set; } = new IntBasis(new PIC("9", "7", "Z.ZZZ.ZZ9."));
            /*"  05  W-EDICAO-VALOR-1         PIC Z.ZZZ.ZZ9,99-.*/
            public DoubleBasis W_EDICAO_VALOR_1 { get; set; } = new DoubleBasis(new PIC("9", "7", "Z.ZZZ.ZZ9V99-."), 3);
            /*"01          WABEND.*/
        }
        public GE0350S_WABEND WABEND { get; set; } = new GE0350S_WABEND();
        public class GE0350S_WABEND : VarBasis
        {
            /*"  05        FILLER              PIC  X(010)     VALUE           ' GE0350S'.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" GE0350S");
            /*"  05        FILLER              PIC  X(026)     VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"  05        WNR-EXEC-SQL        PIC  X(004)     VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"  05        FILLER              PIC  X(013)     VALUE           ' *** SQLCODE '.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"  05        WSQLCODE            PIC  ZZZZZ999-  VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            /*"01  REGISTRO-LINKAGE-GE0350S.*/
        }
        public GE0350S_REGISTRO_LINKAGE_GE0350S REGISTRO_LINKAGE_GE0350S { get; set; } = new GE0350S_REGISTRO_LINKAGE_GE0350S();
        public class GE0350S_REGISTRO_LINKAGE_GE0350S : VarBasis
        {
            /*"    10 LK-GE350-COD-FUNCAO        PIC  9(02).*/
            public IntBasis LK_GE350_COD_FUNCAO { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    10 LK-GE350-NUM-PROPOSTA      PIC S9(16)V USAGE COMP-3.*/
            public DoubleBasis LK_GE350_NUM_PROPOSTA { get; set; } = new DoubleBasis(new PIC("S9", "16", "S9(16)V"), 0);
            /*"    10 LK-GE350-NUM-CERTIFICADO   PIC S9(15)V USAGE COMP-3.*/
            public DoubleBasis LK_GE350_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
            /*"    10 LK-GE350-NUM-PARCELA       PIC S9(04) USAGE COMP.*/
            public IntBasis LK_GE350_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    10 LK-GE350-NUM-APOLICE       PIC S9(13)V USAGE COMP-3.*/
            public DoubleBasis LK_GE350_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
            /*"    10 LK-GE350-NUM-ENDOSSO       PIC S9(09) USAGE COMP.*/
            public IntBasis LK_GE350_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"    10 LK-GE350-SEQ-CNTRLE-SIGCB  PIC S9(04) USAGE COMP.*/
            public IntBasis LK_GE350_SEQ_CNTRLE_SIGCB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    10 LK-GE350-NUM-OCORR-MOVTO   PIC S9(18)V USAGE COMP-3.*/
            public DoubleBasis LK_GE350_NUM_OCORR_MOVTO { get; set; } = new DoubleBasis(new PIC("S9", "18", "S9(18)V"), 0);
            /*"    10 LK-GE350-NUM-IDLG          PIC  X(40).*/
            public StringBasis LK_GE350_NUM_IDLG { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"    10 LK-GE350-COD-PRODUTO       PIC S9(04) USAGE COMP.*/
            public IntBasis LK_GE350_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    10 LK-GE350-DTA-MOVIMENTO     PIC  X(10).*/
            public StringBasis LK_GE350_DTA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    10 LK-GE350-DTA-VENCIMENTO    PIC  X(10).*/
            public StringBasis LK_GE350_DTA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    10 LK-GE350-VLR-PREMIO-TOTAL  PIC S9(13)V9(2) USAGE COMP-3.*/
            public DoubleBasis LK_GE350_VLR_PREMIO_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
            /*"    10 LK-GE350-VLR-IOF           PIC S9(13)V9(2) USAGE COMP-3.*/
            public DoubleBasis LK_GE350_VLR_IOF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
            /*"    10 LK-GE350-QTD-PARCELA       PIC S9(04) USAGE COMP.*/
            public IntBasis LK_GE350_QTD_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    10 LK-GE350-QTD-DIAS-CUSTODIA PIC S9(04) USAGE COMP.*/
            public IntBasis LK_GE350_QTD_DIAS_CUSTODIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    10 LK-GE350-COD-CLIENTE       PIC S9(09) USAGE COMP.*/
            public IntBasis LK_GE350_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"    10 LK-GE350-COD-CEDENTE-SAP   PIC  X(20).*/
            public StringBasis LK_GE350_COD_CEDENTE_SAP { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
            /*"    10 LK-GE350-NUM-BLTO-INTERNO  PIC S9(10)V USAGE COMP-3.*/
            public DoubleBasis LK_GE350_NUM_BLTO_INTERNO { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V"), 0);
            /*"    10 LK-GE350-NOSSO-NUMERO-SAP  PIC S9(18)V USAGE COMP-3.*/
            public DoubleBasis LK_GE350_NOSSO_NUMERO_SAP { get; set; } = new DoubleBasis(new PIC("S9", "18", "S9(18)V"), 0);
            /*"    10 LK-GE350-COD-LINHA-DGTVEL  PIC  X(54).*/
            public StringBasis LK_GE350_COD_LINHA_DGTVEL { get; set; } = new StringBasis(new PIC("X", "54", "X(54)."), @"");
            /*"    10 LK-GE350-NUM-TITULO        PIC S9(16)V USAGE COMP-3.*/
            public DoubleBasis LK_GE350_NUM_TITULO { get; set; } = new DoubleBasis(new PIC("S9", "16", "S9(16)V"), 0);
            /*"    10 LK-GE350-IDE-SISTEMA       PIC  X(02).*/
            public StringBasis LK_GE350_IDE_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
            /*"    10 LK-GE350-COD-USUARIO       PIC  X(10).*/
            public StringBasis LK_GE350_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    10 LK-GE350-COD-SITUACAO      PIC  X(01).*/
            public StringBasis LK_GE350_COD_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    10 LK-GE350-DTA-VENC-CUSTODIA PIC  X(10).*/
            public StringBasis LK_GE350_DTA_VENC_CUSTODIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    10 LK-GE350-COD-SISTEMA       PIC  X(10).*/
            public StringBasis LK_GE350_COD_SISTEMA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    10 LK-GE350-COD-EVENTO        PIC  X(10).*/
            public StringBasis LK_GE350_COD_EVENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    10 LK-GE350-COD-FONTE         PIC S9(04) USAGE COMP.*/
            public IntBasis LK_GE350_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    10 LK-GE350-COD-CANAL         PIC S9(04) USAGE COMP.*/
            public IntBasis LK_GE350_COD_CANAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    10 LK-GE350-NUM-CONTA-CNTRO   PIC  X(25).*/
            public StringBasis LK_GE350_NUM_CONTA_CNTRO { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
            /*"    10 LK-GE350-COD-TP-CONVENIO   PIC  X(01).*/
            public StringBasis LK_GE350_COD_TP_CONVENIO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    10 LK-GE350-COD-REJEICAO      PIC  X(10).*/
            public StringBasis LK_GE350_COD_REJEICAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    10 LK-GE350-COD-RETORNO       PIC  X(01).*/
            public StringBasis LK_GE350_COD_RETORNO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    10 LK-GE350-MENSAGEM.*/
            public GE0350S_LK_GE350_MENSAGEM LK_GE350_MENSAGEM { get; set; } = new GE0350S_LK_GE350_MENSAGEM();
            public class GE0350S_LK_GE350_MENSAGEM : VarBasis
            {
                /*"       20 LK-GE350-SQLCODE        PIC -ZZ9.*/
                public IntBasis LK_GE350_SQLCODE { get; set; } = new IntBasis(new PIC("9", "3", "-ZZ9."));
                /*"       20 FILLER                  PIC X(01).*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       20 LK-GE350-MSG-RETORNO    PIC X(75).*/
                public StringBasis LK_GE350_MSG_RETORNO { get; set; } = new StringBasis(new PIC("X", "75", "X(75)."), @"");
            }
        }


        public Dclgens.GE403 GE403 { get; set; } = new Dclgens.GE403();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.ENDERECO ENDERECO { get; set; } = new Dclgens.ENDERECO();
        public Dclgens.SIARDEVC SIARDEVC { get; set; } = new Dclgens.SIARDEVC();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.GE404 GE404 { get; set; } = new Dclgens.GE404();
        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();
        public Dclgens.GEWEW001 GEWEW001 { get; set; } = new Dclgens.GEWEW001();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(GE0350S_REGISTRO_LINKAGE_GE0350S GE0350S_REGISTRO_LINKAGE_GE0350S_P) //PROCEDURE DIVISION USING 
        /*REGISTRO_LINKAGE_GE0350S*/
        {
            try
            {
                this.REGISTRO_LINKAGE_GE0350S = GE0350S_REGISTRO_LINKAGE_GE0350S_P;

                /*" -0- FLUXCONTROL_PERFORM R000-PRINCIPAL */

                R000_PRINCIPAL();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { REGISTRO_LINKAGE_GE0350S };
            return Result;
        }

        [StopWatch]
        /*" R000-PRINCIPAL */
        private void R000_PRINCIPAL(bool isPerform = false)
        {
            /*" -482- IF LK-GE350-COD-USUARIO EQUAL 'SPBCM027' OR 'SPBCM047' */

            if (REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_USUARIO.In("SPBCM027", "SPBCM047"))
            {

                /*" -483- PERFORM R000-00-INFORMES */

                R000_00_INFORMES_SECTION();

                /*" -484- DISPLAY '----------- DADOS ENTRADA GE0350S ---------- ' */
                _.Display($"----------- DADOS ENTRADA GE0350S ---------- ");

                /*" -485- PERFORM R001-00-DISPLAY */

                R001_00_DISPLAY_SECTION();

                /*" -487- END-IF. */
            }


            /*" -488- MOVE 0 TO LK-GE350-SQLCODE */
            _.Move(0, REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_SQLCODE);

            /*" -489- MOVE '0' TO LK-GE350-COD-RETORNO */
            _.Move("0", REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO);

            /*" -491- MOVE SPACES TO LK-GE350-MSG-RETORNO. */
            _.Move("", REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

            /*" -493- PERFORM R0020-PROCESSAR-LINKAGE. */

            R0020_PROCESSAR_LINKAGE_SECTION();

            /*" -494- MOVE '0' TO LK-GE350-COD-RETORNO */
            _.Move("0", REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO);

            /*" -496- MOVE 'EXECUTADO COM SUCESSO' TO LK-GE350-MSG-RETORNO. */
            _.Move("EXECUTADO COM SUCESSO", REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

            /*" -496- GOBACK. */

            throw new GoBack();

        }

        [StopWatch]
        /*" R000-00-INFORMES-SECTION */
        private void R000_00_INFORMES_SECTION()
        {
            /*" -524- DISPLAY 'GE0350S-VERSAO 23-DEMANDA 506320 ' FUNCTION WHEN-COMPILED(7:2) '/' FUNCTION WHEN-COMPILED(5:2) '/' FUNCTION WHEN-COMPILED(1:4) ' AS ' FUNCTION WHEN-COMPILED(9:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) ' *' */

            $"GE0350S-VERSAO 23-DEMANDA 506320 FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)} AS FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)} *"
            .Display();

            /*" -531- DISPLAY '-->INICIOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) '<--' */

            $"-->INICIOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}<--"
            .Display();

            /*" -531- . */

        }

        [StopWatch]
        /*" R001-00-DISPLAY-SECTION */
        private void R001_00_DISPLAY_SECTION()
        {
            /*" -538- DISPLAY '--------------------------------------------------' */
            _.Display($"--------------------------------------------------");

            /*" -539- DISPLAY '=> COD-FUNCAO       .. ' LK-GE350-COD-FUNCAO */
            _.Display($"=> COD-FUNCAO       .. {REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_FUNCAO}");

            /*" -540- DISPLAY '=> NUM-PROPOSTA     .. ' LK-GE350-NUM-PROPOSTA */
            _.Display($"=> NUM-PROPOSTA     .. {REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PROPOSTA}");

            /*" -541- DISPLAY '=> NUM-CERTIFICADO  .. ' LK-GE350-NUM-CERTIFICADO */
            _.Display($"=> NUM-CERTIFICADO  .. {REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_CERTIFICADO}");

            /*" -542- DISPLAY '=> NUM-PARCELA      .. ' LK-GE350-NUM-PARCELA */
            _.Display($"=> NUM-PARCELA      .. {REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA}");

            /*" -543- DISPLAY '=> NUM-APOLICE      .. ' LK-GE350-NUM-APOLICE */
            _.Display($"=> NUM-APOLICE      .. {REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE}");

            /*" -544- DISPLAY '=> NUM-ENDOSSO      .. ' LK-GE350-NUM-ENDOSSO */
            _.Display($"=> NUM-ENDOSSO      .. {REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO}");

            /*" -545- DISPLAY '=> SEQ-CNTRLE-SIGCB .. ' LK-GE350-SEQ-CNTRLE-SIGCB */
            _.Display($"=> SEQ-CNTRLE-SIGCB .. {REGISTRO_LINKAGE_GE0350S.LK_GE350_SEQ_CNTRLE_SIGCB}");

            /*" -546- DISPLAY '=> NUM-OCORR-MOVTO  .. ' LK-GE350-NUM-OCORR-MOVTO */
            _.Display($"=> NUM-OCORR-MOVTO  .. {REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_OCORR_MOVTO}");

            /*" -547- DISPLAY '=> NUM-IDLG         .. ' LK-GE350-NUM-IDLG */
            _.Display($"=> NUM-IDLG         .. {REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_IDLG}");

            /*" -548- DISPLAY '=> COD-PRODUTO      .. ' LK-GE350-COD-PRODUTO */
            _.Display($"=> COD-PRODUTO      .. {REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_PRODUTO}");

            /*" -549- DISPLAY '=> DTA-MOVIMENTO    .. ' LK-GE350-DTA-MOVIMENTO */
            _.Display($"=> DTA-MOVIMENTO    .. {REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_MOVIMENTO}");

            /*" -550- DISPLAY '=> DTA-VENCIMENTO   .. ' LK-GE350-DTA-VENCIMENTO */
            _.Display($"=> DTA-VENCIMENTO   .. {REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_VENCIMENTO}");

            /*" -551- DISPLAY '=> VLR-PREMIO-TOTAL .. ' LK-GE350-VLR-PREMIO-TOTAL */
            _.Display($"=> VLR-PREMIO-TOTAL .. {REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_PREMIO_TOTAL}");

            /*" -552- DISPLAY '=> VLR-IOF          .. ' LK-GE350-VLR-IOF */
            _.Display($"=> VLR-IOF          .. {REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_IOF}");

            /*" -553- DISPLAY '=> NUM-PARCELA      .. ' LK-GE350-NUM-PARCELA */
            _.Display($"=> NUM-PARCELA      .. {REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA}");

            /*" -554- DISPLAY '=> QTD-PARCELA      .. ' LK-GE350-QTD-PARCELA */
            _.Display($"=> QTD-PARCELA      .. {REGISTRO_LINKAGE_GE0350S.LK_GE350_QTD_PARCELA}");

            /*" -555- DISPLAY '=> QTD-DIAS-CUSTODIA.. ' LK-GE350-QTD-DIAS-CUSTODIA */
            _.Display($"=> QTD-DIAS-CUSTODIA.. {REGISTRO_LINKAGE_GE0350S.LK_GE350_QTD_DIAS_CUSTODIA}");

            /*" -556- DISPLAY '=> COD-CLIENTE      .. ' LK-GE350-COD-CLIENTE */
            _.Display($"=> COD-CLIENTE      .. {REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_CLIENTE}");

            /*" -557- DISPLAY '=> COD-CEDENTE-SAP  .. ' LK-GE350-COD-CEDENTE-SAP */
            _.Display($"=> COD-CEDENTE-SAP  .. {REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_CEDENTE_SAP}");

            /*" -558- DISPLAY '=> NUM-BLTO-INTERNO .. ' LK-GE350-NUM-BLTO-INTERNO */
            _.Display($"=> NUM-BLTO-INTERNO .. {REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_BLTO_INTERNO}");

            /*" -559- DISPLAY '=> NOSSO-NUMERO-SAP .. ' LK-GE350-NOSSO-NUMERO-SAP */
            _.Display($"=> NOSSO-NUMERO-SAP .. {REGISTRO_LINKAGE_GE0350S.LK_GE350_NOSSO_NUMERO_SAP}");

            /*" -560- DISPLAY '=> COD-LINHA-DGTVEL .. ' LK-GE350-COD-LINHA-DGTVEL */
            _.Display($"=> COD-LINHA-DGTVEL .. {REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_LINHA_DGTVEL}");

            /*" -561- DISPLAY '=> NUM-TITULO       .. ' LK-GE350-NUM-TITULO */
            _.Display($"=> NUM-TITULO       .. {REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_TITULO}");

            /*" -562- DISPLAY '=> IDE-SISTEMA      .. ' LK-GE350-IDE-SISTEMA */
            _.Display($"=> IDE-SISTEMA      .. {REGISTRO_LINKAGE_GE0350S.LK_GE350_IDE_SISTEMA}");

            /*" -563- DISPLAY '=> COD-USUARIO      .. ' LK-GE350-COD-USUARIO */
            _.Display($"=> COD-USUARIO      .. {REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_USUARIO}");

            /*" -564- DISPLAY '=> COD-SITUACAO     .. ' LK-GE350-COD-SITUACAO */
            _.Display($"=> COD-SITUACAO     .. {REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO}");

            /*" -565- DISPLAY '=> DTA-VENC-CUSTODIA.. ' LK-GE350-DTA-VENC-CUSTODIA */
            _.Display($"=> DTA-VENC-CUSTODIA.. {REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_VENC_CUSTODIA}");

            /*" -566- DISPLAY '=> COD-SISTEMA.........' LK-GE350-COD-SISTEMA */
            _.Display($"=> COD-SISTEMA.........{REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SISTEMA}");

            /*" -567- DISPLAY '=> COD-EVENTO..........' LK-GE350-COD-EVENTO */
            _.Display($"=> COD-EVENTO..........{REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_EVENTO}");

            /*" -568- DISPLAY '=> COD-FONTE...........' LK-GE350-COD-FONTE */
            _.Display($"=> COD-FONTE...........{REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_FONTE}");

            /*" -569- DISPLAY '=> COD-CANAL...........' LK-GE350-COD-CANAL */
            _.Display($"=> COD-CANAL...........{REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_CANAL}");

            /*" -570- DISPLAY '=> NUM-CONTA-CNTRO.....' LK-GE350-NUM-CONTA-CNTRO */
            _.Display($"=> NUM-CONTA-CNTRO.....{REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_CONTA_CNTRO}");

            /*" -571- DISPLAY '=> COD-TP-CONVENIO.....' LK-GE350-COD-TP-CONVENIO */
            _.Display($"=> COD-TP-CONVENIO.....{REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_TP_CONVENIO}");

            /*" -572- DISPLAY '=> NUM-RAMO-SUSE  .....' LK-NUM-RAMO-SUSEP-WE001 */
            _.Display($"=> NUM-RAMO-SUSE  .....{GEWEW001.LK_NUM_RAMO_SUSEP_WE001}");

            /*" -573- DISPLAY '=> COD-REJEICAO     .. ' LK-GE350-COD-REJEICAO */
            _.Display($"=> COD-REJEICAO     .. {REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_REJEICAO}");

            /*" -574- DISPLAY '=> COD-RETORNO      .. ' LK-GE350-COD-RETORNO */
            _.Display($"=> COD-RETORNO      .. {REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO}");

            /*" -575- DISPLAY '-------------------------------------------- ' */
            _.Display($"-------------------------------------------- ");

            /*" -575- . */

        }

        [StopWatch]
        /*" R0020-PROCESSAR-LINKAGE-SECTION */
        private void R0020_PROCESSAR_LINKAGE_SECTION()
        {
            /*" -584- IF (LK-GE350-COD-FUNCAO NOT EQUAL 1 AND 2 AND 3 AND 4 AND 5 AND 6 AND 7 AND 8 AND 9) */

            if ((!REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_FUNCAO.In("1", "2", "3", "4", "5", "6", "7", "8", "9")))
            {

                /*" -585- MOVE '1' TO LK-GE350-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO);

                /*" -587- MOVE 'GE0350S - FUNCAO INVALIDA ' TO LK-GE350-MSG-RETORNO */
                _.Move("GE0350S - FUNCAO INVALIDA ", REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                /*" -588- GO TO RXXXX-ROTINA-RETORNO */

                RXXXX_ROTINA_RETORNO_SECTION(); //GOTO
                return;

                /*" -590- END-IF. */
            }


            /*" -597- IF (LK-GE350-NUM-PROPOSTA EQUAL ZEROS) AND (LK-GE350-NUM-CERTIFICADO EQUAL ZEROS) AND (LK-GE350-NUM-PARCELA EQUAL ZEROS) AND (LK-GE350-NUM-APOLICE EQUAL ZEROS) AND (LK-GE350-NUM-ENDOSSO EQUAL ZEROS) AND (LK-GE350-NUM-OCORR-MOVTO EQUAL ZEROS) AND (LK-GE350-NUM-IDLG EQUAL ZEROS) */

            if ((REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PROPOSTA == 00) && (REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_CERTIFICADO == 00) && (REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA == 00) && (REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE == 00) && (REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO == 00) && (REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_OCORR_MOVTO == 00) && (REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_IDLG == 00))
            {

                /*" -598- MOVE '1' TO LK-GE350-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO);

                /*" -600- MOVE 'GE0350S - CHAVE DA TABELA INVALIDA ' TO LK-GE350-MSG-RETORNO */
                _.Move("GE0350S - CHAVE DA TABELA INVALIDA ", REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                /*" -601- GO TO RXXXX-ROTINA-RETORNO */

                RXXXX_ROTINA_RETORNO_SECTION(); //GOTO
                return;

                /*" -603- END-IF. */
            }


            /*" -604- IF (LK-GE350-COD-FUNCAO EQUAL 2 OR 3 OR 4) */

            if ((REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_FUNCAO.In("2", "3", "4")))
            {

                /*" -605- IF (LK-GE350-COD-USUARIO EQUAL SPACES) */

                if ((REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_USUARIO.IsEmpty()))
                {

                    /*" -606- MOVE '1' TO LK-GE350-COD-RETORNO */
                    _.Move("1", REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO);

                    /*" -608- MOVE 'GE0350S - COD-USUARIO NAO INFORMADO ' TO LK-GE350-MSG-RETORNO */
                    _.Move("GE0350S - COD-USUARIO NAO INFORMADO ", REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                    /*" -609- GO TO RXXXX-ROTINA-RETORNO */

                    RXXXX_ROTINA_RETORNO_SECTION(); //GOTO
                    return;

                    /*" -611- END-IF */
                }


                /*" -612- IF (LK-GE350-IDE-SISTEMA EQUAL SPACES) */

                if ((REGISTRO_LINKAGE_GE0350S.LK_GE350_IDE_SISTEMA.IsEmpty()))
                {

                    /*" -613- MOVE '1' TO LK-GE350-COD-RETORNO */
                    _.Move("1", REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO);

                    /*" -615- MOVE 'GE0350S - IDENTIFICADO DO SISTEMA INVALIDO ' TO LK-GE350-MSG-RETORNO */
                    _.Move("GE0350S - IDENTIFICADO DO SISTEMA INVALIDO ", REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                    /*" -616- GO TO RXXXX-ROTINA-RETORNO */

                    RXXXX_ROTINA_RETORNO_SECTION(); //GOTO
                    return;

                    /*" -618- END-IF */
                }


                /*" -620- PERFORM R0120-CRITICA-IDE-SISTEMA */

                R0120_CRITICA_IDE_SISTEMA_SECTION();

                /*" -621- IF (LK-GE350-COD-RETORNO EQUAL '1' ) */

                if ((REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO == "1"))
                {

                    /*" -623- MOVE 'GE0350S - IDENTIFICADO SISTEMA COM ERRO ' TO LK-GE350-MSG-RETORNO */
                    _.Move("GE0350S - IDENTIFICADO SISTEMA COM ERRO ", REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                    /*" -624- GO TO RXXXX-ROTINA-RETORNO */

                    RXXXX_ROTINA_RETORNO_SECTION(); //GOTO
                    return;

                    /*" -626- END-IF */
                }


                /*" -628- END-IF */
            }


            /*" -630- PERFORM R0090-SELECT-SISTEMAS. */

            R0090_SELECT_SISTEMAS_SECTION();

            /*" -631- MOVE 0 TO WS-IND-FLAG */
            _.Move(0, WS_IND_FLAG);

            /*" -632- IF LK-GE350-COD-PRODUTO > 0 */

            if (REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_PRODUTO > 0)
            {

                /*" -633- PERFORM R0500-PESQUISA-PRODUTO */

                R0500_PESQUISA_PRODUTO_SECTION();

                /*" -634- IF PRODUTO-RAMO-EMISSOR = 81 OR = 82 OR = 93 OR = 97 */

                if (PRODUTO.DCLPRODUTO.PRODUTO_RAMO_EMISSOR.In("81", "82", "93", "97"))
                {

                    /*" -635-  EVALUATE TRUE  */

                    /*" -637-  WHEN LK-GE350-DTA-VENCIMENTO >= '2020-06-06'    AND LK-GE350-DTA-VENCIMENTO <= '2020-06-28'  */

                    /*" -637- IF LK-GE350-DTA-VENCIMENTO >= '2020-06-06'    AND LK-GE350-DTA-VENCIMENTO <= '2020-06-28' */

                    if (REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_VENCIMENTO >= "2020-06-06" && REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_VENCIMENTO <= "2020-06-28")
                    {

                        /*" -638- MOVE 1 TO LK-GE350-QTD-DIAS-CUSTODIA */
                        _.Move(1, REGISTRO_LINKAGE_GE0350S.LK_GE350_QTD_DIAS_CUSTODIA);

                        /*" -639- MOVE 1 TO WS-IND-FLAG */
                        _.Move(1, WS_IND_FLAG);

                        /*" -641-  WHEN LK-GE350-DTA-VENCIMENTO >= '2020-06-29'    AND LK-GE350-DTA-VENCIMENTO <= '2020-06-30'  */

                        /*" -641- ELSE IF LK-GE350-DTA-VENCIMENTO >= '2020-06-29'    AND LK-GE350-DTA-VENCIMENTO <= '2020-06-30' */
                    }
                    else

                    if (REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_VENCIMENTO >= "2020-06-29" && REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_VENCIMENTO <= "2020-06-30")
                    {

                        /*" -642- MOVE '2020-07-06' TO LK-GE350-DTA-VENCIMENTO */
                        _.Move("2020-07-06", REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_VENCIMENTO);

                        /*" -643- MOVE 1 TO LK-GE350-QTD-DIAS-CUSTODIA */
                        _.Move(1, REGISTRO_LINKAGE_GE0350S.LK_GE350_QTD_DIAS_CUSTODIA);

                        /*" -644- MOVE 1 TO WS-IND-FLAG */
                        _.Move(1, WS_IND_FLAG);

                        /*" -646-  WHEN LK-GE350-DTA-VENCIMENTO >= '2020-07-01'    AND LK-GE350-DTA-VENCIMENTO <= '2020-07-09'  */

                        /*" -646- ELSE IF LK-GE350-DTA-VENCIMENTO >= '2020-07-01'    AND LK-GE350-DTA-VENCIMENTO <= '2020-07-09' */
                    }
                    else

                    if (REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_VENCIMENTO >= "2020-07-01" && REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_VENCIMENTO <= "2020-07-09")
                    {

                        /*" -647- MOVE '2020-07-10' TO LK-GE350-DTA-VENCIMENTO */
                        _.Move("2020-07-10", REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_VENCIMENTO);

                        /*" -648- MOVE 1 TO LK-GE350-QTD-DIAS-CUSTODIA */
                        _.Move(1, REGISTRO_LINKAGE_GE0350S.LK_GE350_QTD_DIAS_CUSTODIA);

                        /*" -649- MOVE 1 TO WS-IND-FLAG */
                        _.Move(1, WS_IND_FLAG);

                        /*" -650-  WHEN LK-GE350-DTA-VENCIMENTO >= '2020-07-11'  */

                        /*" -650- ELSE IF LK-GE350-DTA-VENCIMENTO >= '2020-07-11' */
                    }
                    else

                    if (REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_VENCIMENTO >= "2020-07-11")
                    {

                        /*" -651- MOVE 10 TO LK-GE350-QTD-DIAS-CUSTODIA */
                        _.Move(10, REGISTRO_LINKAGE_GE0350S.LK_GE350_QTD_DIAS_CUSTODIA);

                        /*" -652- MOVE 1 TO WS-IND-FLAG */
                        _.Move(1, WS_IND_FLAG);

                        /*" -653-  END-EVALUATE  */

                        /*" -653- END-IF */
                    }


                    /*" -654- END-IF */
                }


                /*" -657- END-IF. */
            }


            /*" -661- EVALUATE LK-GE350-COD-FUNCAO */
            switch (REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_FUNCAO.Value)
            {

                /*" -662- WHEN 1 */
                case 1:

                    /*" -665- PERFORM R1000-CONSULTA-NN-VALIDO */

                    R1000_CONSULTA_NN_VALIDO_SECTION();

                    /*" -666- WHEN 2 */
                    break;
                case 2:

                    /*" -669- PERFORM R2000-SOLICITA-NOVO-NN-SAP */

                    R2000_SOLICITA_NOVO_NN_SAP_SECTION();

                    /*" -670- WHEN 3 */
                    break;
                case 3:

                    /*" -671- MOVE ZEROS TO WS-IND-NUM-OCORR-MOVTO */
                    _.Move(0, WS_IND_NUM_OCORR_MOVTO);

                    /*" -673- MOVE ZEROS TO WS-IND-NUM-IDLG */
                    _.Move(0, WS_IND_NUM_IDLG);

                    /*" -674- IF (LK-GE350-COD-SITUACAO EQUAL 'P' OR 'O' ) */

                    if ((REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO.In("P", "O")))
                    {

                        /*" -675- MOVE '1' TO LK-GE350-COD-RETORNO */
                        _.Move("1", REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO);

                        /*" -677- MOVE 'GE0350S - SITUACAO INVALIDA P/ FUNCAO 03' TO LK-GE350-MSG-RETORNO */
                        _.Move("GE0350S - SITUACAO INVALIDA P/ FUNCAO 03", REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                        /*" -678- GO TO RXXXX-ROTINA-RETORNO */

                        RXXXX_ROTINA_RETORNO_SECTION(); //GOTO
                        return;

                        /*" -680- END-IF */
                    }


                    /*" -681- IF (LK-GE350-COD-REJEICAO EQUAL SPACES) */

                    if ((REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_REJEICAO.IsEmpty()))
                    {

                        /*" -682- MOVE -1 TO WS-IND-COD-REJEICAO */
                        _.Move(-1, WS_IND_COD_REJEICAO);

                        /*" -683- ELSE */
                    }
                    else
                    {


                        /*" -684- MOVE ZEROS TO WS-IND-COD-REJEICAO */
                        _.Move(0, WS_IND_COD_REJEICAO);

                        /*" -686- END-IF */
                    }


                    /*" -687- IF (LK-GE350-NUM-IDLG EQUAL SPACES) */

                    if ((REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_IDLG.IsEmpty()))
                    {

                        /*" -688- MOVE -1 TO WS-IND-NUM-IDLG */
                        _.Move(-1, WS_IND_NUM_IDLG);

                        /*" -690- END-IF */
                    }


                    /*" -691- IF (LK-GE350-COD-SITUACAO NOT EQUAL 'I' ) */

                    if ((REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO != "I"))
                    {

                        /*" -692- IF (LK-GE350-NUM-OCORR-MOVTO EQUAL ZEROS) */

                        if ((REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_OCORR_MOVTO == 00))
                        {

                            /*" -693- PERFORM R3000-UPDATE-SIT-CNTRLE-SIGCB */

                            R3000_UPDATE_SIT_CNTRLE_SIGCB_SECTION();

                            /*" -694- ELSE */
                        }
                        else
                        {


                            /*" -695- PERFORM R3500-UPDATE-SIT-AGUARDA-SAP */

                            R3500_UPDATE_SIT_AGUARDA_SAP_SECTION();

                            /*" -696- END-IF */
                        }


                        /*" -698- END-IF */
                    }


                    /*" -701- PERFORM R2500-INSERE-CONTROLE-HIST */

                    R2500_INSERE_CONTROLE_HIST_SECTION();

                    /*" -702- WHEN 4 */
                    break;
                case 4:

                    /*" -705- PERFORM R4000-INSERE-CONTROLE-NN-SAP */

                    R4000_INSERE_CONTROLE_NN_SAP_SECTION();

                    /*" -706- WHEN 5 */
                    break;
                case 5:

                    /*" -709- PERFORM R5000-CONSULTA-NN-NUM-IDLG */

                    R5000_CONSULTA_NN_NUM_IDLG_SECTION();

                    /*" -710- WHEN 6 */
                    break;
                case 6:

                    /*" -714- PERFORM R6000-CONSULTA-POR-NN-SAP */

                    R6000_CONSULTA_POR_NN_SAP_SECTION();

                    /*" -715- WHEN 7 */
                    break;
                case 7:

                    /*" -718- PERFORM R7000-SOLICITA-NN-CICS-SIAS */

                    R7000_SOLICITA_NN_CICS_SIAS_SECTION();

                    /*" -719- WHEN 8 */
                    break;
                case 8:

                    /*" -720- IF (LK-GE350-COD-SITUACAO EQUAL ' ' ) */

                    if ((REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO == " "))
                    {

                        /*" -721- MOVE '1' TO LK-GE350-COD-RETORNO */
                        _.Move("1", REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO);

                        /*" -723- MOVE 'GE0350S - SITUACAO INVALIDA P/ FUNCAO 08' TO LK-GE350-MSG-RETORNO */
                        _.Move("GE0350S - SITUACAO INVALIDA P/ FUNCAO 08", REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                        /*" -724- GO TO RXXXX-ROTINA-RETORNO */

                        RXXXX_ROTINA_RETORNO_SECTION(); //GOTO
                        return;

                        /*" -726- END-IF */
                    }


                    /*" -727- IF (LK-GE350-COD-REJEICAO EQUAL SPACES) */

                    if ((REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_REJEICAO.IsEmpty()))
                    {

                        /*" -728- MOVE -1 TO WS-IND-COD-REJEICAO */
                        _.Move(-1, WS_IND_COD_REJEICAO);

                        /*" -729- ELSE */
                    }
                    else
                    {


                        /*" -730- MOVE ZEROS TO WS-IND-COD-REJEICAO */
                        _.Move(0, WS_IND_COD_REJEICAO);

                        /*" -732- END-IF */
                    }


                    /*" -734- PERFORM R2500-INSERE-CONTROLE-HIST */

                    R2500_INSERE_CONTROLE_HIST_SECTION();

                    /*" -737- WHEN 9 */
                    break;
                case 9:

                    /*" -739- PERFORM R4900-VALIDA-UPDATE-NN-SAP */

                    R4900_VALIDA_UPDATE_NN_SAP_SECTION();

                    /*" -740- END-EVALUATE */
                    break;
            }


            /*" -740- . */

        }

        [StopWatch]
        /*" R0090-SELECT-SISTEMAS-SECTION */
        private void R0090_SELECT_SISTEMAS_SECTION()
        {
            /*" -756- PERFORM R0090_SELECT_SISTEMAS_DB_SELECT_1 */

            R0090_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -759- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -760- DISPLAY 'R0090-ERRO NO ACESSO SISTEMAS - FI' */
                _.Display($"R0090-ERRO NO ACESSO SISTEMAS - FI");

                /*" -761- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -762- END-IF */
            }


            /*" -762- . */

        }

        [StopWatch]
        /*" R0090-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0090_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -756- EXEC SQL SELECT CURRENT DATE, CURRENT TIMESTAMP, CURRENT TIME INTO :HOST-CURRENT-DATE, :HOST-TIMESTAMP, :HOST-CURRENT-TIME FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'FI' WITH UR END-EXEC. */

            var r0090_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new R0090_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0090_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(r0090_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_CURRENT_DATE, HOST_CURRENT_DATE);
                _.Move(executed_1.HOST_TIMESTAMP, HOST_TIMESTAMP);
                _.Move(executed_1.HOST_CURRENT_TIME, HOST_CURRENT_TIME);
            }


        }

        [StopWatch]
        /*" R0100-CRITICA-DATA-SECTION */
        private void R0100_CRITICA_DATA_SECTION()
        {
            /*" -774- PERFORM R0100_CRITICA_DATA_DB_SELECT_1 */

            R0100_CRITICA_DATA_DB_SELECT_1();

            /*" -777- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -778- DISPLAY 'R0100-DATA INVALIDA ' WS-DATA-AUX */
                _.Display($"R0100-DATA INVALIDA {AREA_DE_WORK.WS_DATA_AUX}");

                /*" -779- MOVE '1' TO LK-GE350-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO);

                /*" -781- MOVE 'GE0350S - DATA INVALIDA - 0100    ' TO LK-GE350-MSG-RETORNO */
                _.Move("GE0350S - DATA INVALIDA - 0100    ", REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                /*" -782- END-IF */
            }


            /*" -782- . */

        }

        [StopWatch]
        /*" R0100-CRITICA-DATA-DB-SELECT-1 */
        public void R0100_CRITICA_DATA_DB_SELECT_1()
        {
            /*" -774- EXEC SQL SELECT DATE(:WS-DATA-AUX) + 1 DAY INTO :WS-DATA-AUX FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'FI' WITH UR END-EXEC. */

            var r0100_CRITICA_DATA_DB_SELECT_1_Query1 = new R0100_CRITICA_DATA_DB_SELECT_1_Query1()
            {
                WS_DATA_AUX = AREA_DE_WORK.WS_DATA_AUX.ToString(),
            };

            var executed_1 = R0100_CRITICA_DATA_DB_SELECT_1_Query1.Execute(r0100_CRITICA_DATA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_DATA_AUX, AREA_DE_WORK.WS_DATA_AUX);
            }


        }

        [StopWatch]
        /*" R0110-CRITICA-CLIENTE-SECTION */
        private void R0110_CRITICA_CLIENTE_SECTION()
        {
            /*" -790- MOVE LK-GE350-COD-CLIENTE TO CLIENTES-COD-CLIENTE */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_CLIENTE, CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE);

            /*" -797- PERFORM R0110_CRITICA_CLIENTE_DB_SELECT_1 */

            R0110_CRITICA_CLIENTE_DB_SELECT_1();

            /*" -800- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -802- DISPLAY 'R0110-COD-CLIENTE INVALIDO ' CLIENTES-COD-CLIENTE */
                _.Display($"R0110-COD-CLIENTE INVALIDO {CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE}");

                /*" -803- MOVE '1' TO LK-GE350-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO);

                /*" -805- MOVE 'GE0350S - CLIENTE INVALIDO - 0110 ' TO LK-GE350-MSG-RETORNO */
                _.Move("GE0350S - CLIENTE INVALIDO - 0110 ", REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                /*" -806- END-IF */
            }


            /*" -806- . */

        }

        [StopWatch]
        /*" R0110-CRITICA-CLIENTE-DB-SELECT-1 */
        public void R0110_CRITICA_CLIENTE_DB_SELECT_1()
        {
            /*" -797- EXEC SQL SELECT COD_CLIENTE INTO :CLIENTES-COD-CLIENTE FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :CLIENTES-COD-CLIENTE FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0110_CRITICA_CLIENTE_DB_SELECT_1_Query1 = new R0110_CRITICA_CLIENTE_DB_SELECT_1_Query1()
            {
                CLIENTES_COD_CLIENTE = CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE.ToString(),
            };

            var executed_1 = R0110_CRITICA_CLIENTE_DB_SELECT_1_Query1.Execute(r0110_CRITICA_CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_COD_CLIENTE, CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE);
            }


        }

        [StopWatch]
        /*" R0120-CRITICA-IDE-SISTEMA-SECTION */
        private void R0120_CRITICA_IDE_SISTEMA_SECTION()
        {
            /*" -814- MOVE LK-GE350-IDE-SISTEMA TO SISTEMAS-IDE-SISTEMA */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_IDE_SISTEMA, SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA);

            /*" -820- PERFORM R0120_CRITICA_IDE_SISTEMA_DB_SELECT_1 */

            R0120_CRITICA_IDE_SISTEMA_DB_SELECT_1();

            /*" -823- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -825- DISPLAY 'R0120-IDE-SISTEMA INVALIDO ' SISTEMAS-IDE-SISTEMA */
                _.Display($"R0120-IDE-SISTEMA INVALIDO {SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA}");

                /*" -826- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -828- END-IF. */
            }


            /*" -829- IF (SQLCODE EQUAL +100) */

            if ((DB.SQLCODE == +100))
            {

                /*" -830- MOVE '1' TO LK-GE350-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO);

                /*" -832- MOVE 'GE0350S - IDE SISTEMAS INVALIDO - 0120 ' TO LK-GE350-MSG-RETORNO */
                _.Move("GE0350S - IDE SISTEMAS INVALIDO - 0120 ", REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                /*" -833- END-IF */
            }


            /*" -833- . */

        }

        [StopWatch]
        /*" R0120-CRITICA-IDE-SISTEMA-DB-SELECT-1 */
        public void R0120_CRITICA_IDE_SISTEMA_DB_SELECT_1()
        {
            /*" -820- EXEC SQL SELECT IDE_SISTEMA INTO :SISTEMAS-IDE-SISTEMA FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = :SISTEMAS-IDE-SISTEMA WITH UR END-EXEC. */

            var r0120_CRITICA_IDE_SISTEMA_DB_SELECT_1_Query1 = new R0120_CRITICA_IDE_SISTEMA_DB_SELECT_1_Query1()
            {
                SISTEMAS_IDE_SISTEMA = SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA.ToString(),
            };

            var executed_1 = R0120_CRITICA_IDE_SISTEMA_DB_SELECT_1_Query1.Execute(r0120_CRITICA_IDE_SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_IDE_SISTEMA, SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA);
            }


        }

        [StopWatch]
        /*" R0500-PESQUISA-PRODUTO-SECTION */
        private void R0500_PESQUISA_PRODUTO_SECTION()
        {
            /*" -842- MOVE LK-GE350-COD-PRODUTO TO PRODUTO-COD-PRODUTO WS-SMALLINT(01) */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_PRODUTO, PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO, WS_EDITED.WS_SMALLINT[01]);

            /*" -848- PERFORM R0500_PESQUISA_PRODUTO_DB_SELECT_1 */

            R0500_PESQUISA_PRODUTO_DB_SELECT_1();

            /*" -851- IF NOT ( SQLCODE = 000 OR = 100 ) */

            if (!(DB.SQLCODE.In("000", "100")))
            {

                /*" -852- DISPLAY '*K* GE0350S SQLCODE <> 0 SQLC=<' SQLCODE '>' */

                $"*K* GE0350S SQLCODE <> 0 SQLC=<{DB.SQLCODE}>"
                .Display();

                /*" -854- MOVE 'R0500-ERRO - SEGUROS.PRODUTO ' TO LK-GE350-MSG-RETORNO */
                _.Move("R0500-ERRO - SEGUROS.PRODUTO ", REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                /*" -855- PERFORM R8888-00-DISPLAY-ERRO */

                R8888_00_DISPLAY_ERRO_SECTION();

                /*" -856- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -858- END-IF */
            }


            /*" -859- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -862- STRING 'R0500-ERRO - PRODUTO NAO CADASTRADO. ' ' COD-PRODUTO = ' WS-SMALLINT(01) DELIMITED BY SIZE INTO LK-GE350-MSG-RETORNO */
                #region STRING
                var spl1 = "R0500-ERRO - PRODUTO NAO CADASTRADO. " + " COD-PRODUTO = " + WS_EDITED.WS_SMALLINT[01].GetMoveValues();
                _.Move(spl1, REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);
                #endregion

                /*" -863- PERFORM R8888-00-DISPLAY-ERRO */

                R8888_00_DISPLAY_ERRO_SECTION();

                /*" -864- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -865- END-IF */
            }


            /*" -867- . */

        }

        [StopWatch]
        /*" R0500-PESQUISA-PRODUTO-DB-SELECT-1 */
        public void R0500_PESQUISA_PRODUTO_DB_SELECT_1()
        {
            /*" -848- EXEC SQL SELECT RAMO_EMISSOR INTO :PRODUTO-RAMO-EMISSOR FROM SEGUROS.PRODUTO WHERE COD_PRODUTO = :PRODUTO-COD-PRODUTO WITH UR END-EXEC. */

            var r0500_PESQUISA_PRODUTO_DB_SELECT_1_Query1 = new R0500_PESQUISA_PRODUTO_DB_SELECT_1_Query1()
            {
                PRODUTO_COD_PRODUTO = PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO.ToString(),
            };

            var executed_1 = R0500_PESQUISA_PRODUTO_DB_SELECT_1_Query1.Execute(r0500_PESQUISA_PRODUTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUTO_RAMO_EMISSOR, PRODUTO.DCLPRODUTO.PRODUTO_RAMO_EMISSOR);
            }


        }

        [StopWatch]
        /*" R1000-CONSULTA-NN-VALIDO-SECTION */
        private void R1000_CONSULTA_NN_VALIDO_SECTION()
        {
            /*" -873- MOVE LK-GE350-NUM-PROPOSTA TO GE403-NUM-PROPOSTA WS-BIGINT(01) */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PROPOSTA, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PROPOSTA, WS_EDITED.WS_BIGINT[01]);

            /*" -875- MOVE LK-GE350-NUM-CERTIFICADO TO GE403-NUM-CERTIFICADO WS-BIGINT(02) */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_CERTIFICADO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_CERTIFICADO, WS_EDITED.WS_BIGINT[02]);

            /*" -877- MOVE LK-GE350-NUM-PARCELA TO GE403-NUM-PARCELA WS-SMALLINT(01) */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PARCELA, WS_EDITED.WS_SMALLINT[01]);

            /*" -879- MOVE LK-GE350-NUM-APOLICE TO GE403-NUM-APOLICE WS-BIGINT(03) */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_APOLICE, WS_EDITED.WS_BIGINT[03]);

            /*" -882- MOVE LK-GE350-NUM-ENDOSSO TO GE403-NUM-ENDOSSO WS-SMALLINT(02) */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_ENDOSSO, WS_EDITED.WS_SMALLINT[02]);

            /*" -889- DISPLAY 'R1000 - CHAVE SELECT >' ' PROP...:' WS-BIGINT(01) '/CERTIF.:' WS-BIGINT(02) '/PARC...:' WS-SMALLINT(01) '/APOL...:' WS-BIGINT(04) '/ENDOS..:' WS-SMALLINT(02) */

            $"R1000 - CHAVE SELECT > PROP...:{WS_EDITED.WS_BIGINT[1]}/CERTIF.:{WS_EDITED.WS_BIGINT[2]}/PARC...:{WS_EDITED.WS_SMALLINT[1]}/APOL...:{WS_EDITED.WS_BIGINT[4]}/ENDOS..:{WS_EDITED.WS_SMALLINT[2]}"
            .Display();

            /*" -945- PERFORM R1000_CONSULTA_NN_VALIDO_DB_SELECT_1 */

            R1000_CONSULTA_NN_VALIDO_DB_SELECT_1();

            /*" -948- MOVE SQLCODE TO WS-SMALLINT(03) */
            _.Move(DB.SQLCODE, WS_EDITED.WS_SMALLINT[03]);

            /*" -955- DISPLAY 'R1000 - SQLCODE >' WS-SMALLINT(03) ' > ' ' PROP...:' WS-BIGINT(01) '/CERTIF.:' WS-BIGINT(02) '/PARC...:' WS-SMALLINT(01) '/APOL...:' WS-BIGINT(04) '/ENDOS..:' WS-SMALLINT(02) */

            $"R1000 - SQLCODE >{WS_EDITED.WS_SMALLINT[3]} >  PROP...:{WS_EDITED.WS_BIGINT[1]}/CERTIF.:{WS_EDITED.WS_BIGINT[2]}/PARC...:{WS_EDITED.WS_SMALLINT[1]}/APOL...:{WS_EDITED.WS_BIGINT[4]}/ENDOS..:{WS_EDITED.WS_SMALLINT[2]}"
            .Display();

            /*" -956- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -958- IF (SQLCODE EQUAL +100) */

                if ((DB.SQLCODE == +100))
                {

                    /*" -959- IF (GE403-NUM-PROPOSTA EQUAL ZEROS) */

                    if ((GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PROPOSTA == 00))
                    {

                        /*" -960- PERFORM R1100-CONS-NN-CERTIFICADO */

                        R1100_CONS_NN_CERTIFICADO_SECTION();

                        /*" -961- ELSE */
                    }
                    else
                    {


                        /*" -962- MOVE '2' TO LK-GE350-COD-RETORNO */
                        _.Move("2", REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO);

                        /*" -964- MOVE 'BOLETO NAO ENCONTRADO NO SIGCB ' TO LK-GE350-MSG-RETORNO */
                        _.Move("BOLETO NAO ENCONTRADO NO SIGCB ", REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                        /*" -965- GO TO RXXXX-ROTINA-RETORNO */

                        RXXXX_ROTINA_RETORNO_SECTION(); //GOTO
                        return;

                        /*" -966- END-IF */
                    }


                    /*" -968- ELSE */
                }
                else
                {


                    /*" -969- DISPLAY '*K* GE0350S SQLCODE <> 0 SQLC=<' SQLCODE '>' */

                    $"*K* GE0350S SQLCODE <> 0 SQLC=<{DB.SQLCODE}>"
                    .Display();

                    /*" -971- MOVE 'R1000-ERRO GE_CONTROLE_EMISSAO_SIGCB' TO LK-GE350-MSG-RETORNO */
                    _.Move("R1000-ERRO GE_CONTROLE_EMISSAO_SIGCB", REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                    /*" -972- PERFORM R8888-00-DISPLAY-ERRO */

                    R8888_00_DISPLAY_ERRO_SECTION();

                    /*" -973- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -974- END-IF */
                }


                /*" -975- ELSE */
            }
            else
            {


                /*" -977- MOVE GE403-SEQ-CONTROLE-SIGCB TO LK-GE350-SEQ-CNTRLE-SIGCB */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_SEQ_CONTROLE_SIGCB, REGISTRO_LINKAGE_GE0350S.LK_GE350_SEQ_CNTRLE_SIGCB);

                /*" -978- MOVE GE403-DTA-MOVIMENTO TO LK-GE350-DTA-MOVIMENTO */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_DTA_MOVIMENTO, REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_MOVIMENTO);

                /*" -980- MOVE GE403-NUM-OCORR-MOVTO TO LK-GE350-NUM-OCORR-MOVTO */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_OCORR_MOVTO, REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_OCORR_MOVTO);

                /*" -981- MOVE GE403-NUM-IDLG TO LK-GE350-NUM-IDLG */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_IDLG, REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_IDLG);

                /*" -982- MOVE GE403-COD-PRODUTO TO LK-GE350-COD-PRODUTO */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_PRODUTO, REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_PRODUTO);

                /*" -983- MOVE GE403-DTA-VENCIMENTO TO LK-GE350-DTA-VENCIMENTO */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_DTA_VENCIMENTO, REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_VENCIMENTO);

                /*" -985- MOVE GE403-VLR-PREMIO-TOTAL TO LK-GE350-VLR-PREMIO-TOTAL */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_VLR_PREMIO_TOTAL, REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_PREMIO_TOTAL);

                /*" -986- MOVE GE403-VLR-IOF TO LK-GE350-VLR-IOF */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_VLR_IOF, REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_IOF);

                /*" -987- MOVE GE403-QTD-PARCELA TO LK-GE350-QTD-PARCELA */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_QTD_PARCELA, REGISTRO_LINKAGE_GE0350S.LK_GE350_QTD_PARCELA);

                /*" -989- MOVE GE403-QTD-DIAS-CUSTODIA TO LK-GE350-QTD-DIAS-CUSTODIA */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_QTD_DIAS_CUSTODIA, REGISTRO_LINKAGE_GE0350S.LK_GE350_QTD_DIAS_CUSTODIA);

                /*" -990- MOVE GE403-COD-CLIENTE TO LK-GE350-COD-CLIENTE */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_CLIENTE, REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_CLIENTE);

                /*" -992- MOVE GE403-COD-CEDENTE-SAP TO LK-GE350-COD-CEDENTE-SAP */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_CEDENTE_SAP, REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_CEDENTE_SAP);

                /*" -994- MOVE GE403-NUM-BOLETO-INTERNO TO LK-GE350-NUM-BLTO-INTERNO */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_BOLETO_INTERNO, REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_BLTO_INTERNO);

                /*" -996- MOVE GE403-NUM-NOSSO-NUMERO-SAP TO LK-GE350-NOSSO-NUMERO-SAP */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_NOSSO_NUMERO_SAP, REGISTRO_LINKAGE_GE0350S.LK_GE350_NOSSO_NUMERO_SAP);

                /*" -998- MOVE GE403-COD-LINHA-DIGITAVEL TO LK-GE350-COD-LINHA-DGTVEL */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_LINHA_DIGITAVEL, REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_LINHA_DGTVEL);

                /*" -999- MOVE GE403-NUM-TITULO TO LK-GE350-NUM-TITULO */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_TITULO, REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_TITULO);

                /*" -1000- MOVE GE403-IDE-SISTEMA TO LK-GE350-IDE-SISTEMA */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_IDE_SISTEMA, REGISTRO_LINKAGE_GE0350S.LK_GE350_IDE_SISTEMA);

                /*" -1001- MOVE GE403-COD-USUARIO TO LK-GE350-COD-USUARIO */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_USUARIO, REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_USUARIO);

                /*" -1003- MOVE GE403-COD-SITUACAO TO LK-GE350-COD-SITUACAO */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_SITUACAO, REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO);

                /*" -1029- DISPLAY 'PROP: ' LK-GE350-NUM-PROPOSTA 'CERT: ' LK-GE350-NUM-CERTIFICADO 'PARC: ' LK-GE350-NUM-PARCELA 'APOL: ' LK-GE350-NUM-APOLICE 'ENDO: ' LK-GE350-NUM-ENDOSSO 'CTRL: ' LK-GE350-SEQ-CNTRLE-SIGCB 'MOVT: ' LK-GE350-DTA-MOVIMENTO 'OCOR: ' LK-GE350-NUM-OCORR-MOVTO 'IDLG: ' LK-GE350-NUM-IDLG 'PROD: ' LK-GE350-COD-PRODUTO 'VENC: ' LK-GE350-DTA-VENCIMENTO 'PREM: ' LK-GE350-VLR-PREMIO-TOTAL 'IOF:  ' LK-GE350-VLR-IOF 'PARC: ' LK-GE350-QTD-PARCELA 'QTD:  ' LK-GE350-QTD-DIAS-CUSTODIA 'CODC: ' LK-GE350-COD-CLIENTE 'CEDE: ' LK-GE350-COD-CEDENTE-SAP 'BLTO: ' LK-GE350-NUM-BLTO-INTERNO 'NUMS: ' LK-GE350-NOSSO-NUMERO-SAP 'LINH: ' LK-GE350-COD-LINHA-DGTVEL 'TITU: ' LK-GE350-NUM-TITULO 'SIST: ' LK-GE350-IDE-SISTEMA 'USU:  ' LK-GE350-COD-USUARIO 'SIT:  ' LK-GE350-COD-SITUACAO 'DTVE: ' WS-DTA-VENC-CUSTODIA */

                $"PROP: {REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PROPOSTA}CERT: {REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_CERTIFICADO}PARC: {REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA}APOL: {REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE}ENDO: {REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO}CTRL: {REGISTRO_LINKAGE_GE0350S.LK_GE350_SEQ_CNTRLE_SIGCB}MOVT: {REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_MOVIMENTO}OCOR: {REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_OCORR_MOVTO}IDLG: {REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_IDLG}PROD: {REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_PRODUTO}VENC: {REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_VENCIMENTO}PREM: {REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_PREMIO_TOTAL}IOF:  {REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_IOF}PARC: {REGISTRO_LINKAGE_GE0350S.LK_GE350_QTD_PARCELA}QTD:  {REGISTRO_LINKAGE_GE0350S.LK_GE350_QTD_DIAS_CUSTODIA}CODC: {REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_CLIENTE}CEDE: {REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_CEDENTE_SAP}BLTO: {REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_BLTO_INTERNO}NUMS: {REGISTRO_LINKAGE_GE0350S.LK_GE350_NOSSO_NUMERO_SAP}LINH: {REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_LINHA_DGTVEL}TITU: {REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_TITULO}SIST: {REGISTRO_LINKAGE_GE0350S.LK_GE350_IDE_SISTEMA}USU:  {REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_USUARIO}SIT:  {REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO}DTVE: {WS_DTA_VENC_CUSTODIA}"
                .Display();

                /*" -1031- IF (LK-GE350-COD-SITUACAO NOT EQUAL 'R' ) AND (WS-DTA-VENC-CUSTODIA < HOST-CURRENT-DATE) */

                if ((REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO != "R") && (WS_DTA_VENC_CUSTODIA < HOST_CURRENT_DATE))
                {

                    /*" -1032- DISPLAY 'VENCIMENTO-CUSTODIA: ' WS-DTA-VENC-CUSTODIA */
                    _.Display($"VENCIMENTO-CUSTODIA: {WS_DTA_VENC_CUSTODIA}");

                    /*" -1033- DISPLAY 'CURRENT DATE: ' HOST-CURRENT-DATE */
                    _.Display($"CURRENT DATE: {HOST_CURRENT_DATE}");

                    /*" -1034- DISPLAY 'DATA VENC: ' LK-GE350-DTA-VENCIMENTO */
                    _.Display($"DATA VENC: {REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_VENCIMENTO}");

                    /*" -1035- DISPLAY 'DIAS: ' LK-GE350-QTD-DIAS-CUSTODIA */
                    _.Display($"DIAS: {REGISTRO_LINKAGE_GE0350S.LK_GE350_QTD_DIAS_CUSTODIA}");

                    /*" -1036- MOVE '3' TO LK-GE350-COD-RETORNO */
                    _.Move("3", REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO);

                    /*" -1037- MOVE 'T' TO LK-GE350-COD-SITUACAO */
                    _.Move("T", REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO);

                    /*" -1039- MOVE 'CUST�DIA DE BOLETO VENCIDA ' TO LK-GE350-MSG-RETORNO */
                    _.Move("CUST�DIA DE BOLETO VENCIDA ", REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                    /*" -1040- GO TO RXXXX-ROTINA-RETORNO */

                    RXXXX_ROTINA_RETORNO_SECTION(); //GOTO
                    return;

                    /*" -1041- END-IF */
                }


                /*" -1042- END-IF */
            }


            /*" -1042- . */

        }

        [StopWatch]
        /*" R1000-CONSULTA-NN-VALIDO-DB-SELECT-1 */
        public void R1000_CONSULTA_NN_VALIDO_DB_SELECT_1()
        {
            /*" -945- EXEC SQL SELECT SEQ_CONTROLE_SIGCB , DTA_MOVIMENTO , VALUE(NUM_OCORR_MOVTO, 0) , VALUE(NUM_IDLG, ' ' ) , COD_PRODUTO , DTA_VENCIMENTO , VLR_PREMIO_TOTAL , VLR_IOF , QTD_PARCELA , QTD_DIAS_CUSTODIA , COD_CLIENTE , VALUE(COD_CEDENTE_SAP, ' ' ) , VALUE(NUM_BOLETO_INTERNO, 0) , VALUE(NUM_NOSSO_NUMERO_SAP, 0) , VALUE(COD_LINHA_DIGITAVEL, ' ' ) , VALUE(NUM_TITULO, 0) , IDE_SISTEMA , COD_USUARIO , COD_SITUACAO , DATE(DTA_VENCIMENTO + QTD_DIAS_CUSTODIA DAYS) INTO :GE403-SEQ-CONTROLE-SIGCB , :GE403-DTA-MOVIMENTO , :GE403-NUM-OCORR-MOVTO , :GE403-NUM-IDLG , :GE403-COD-PRODUTO , :GE403-DTA-VENCIMENTO , :GE403-VLR-PREMIO-TOTAL , :GE403-VLR-IOF , :GE403-QTD-PARCELA , :GE403-QTD-DIAS-CUSTODIA , :GE403-COD-CLIENTE , :GE403-COD-CEDENTE-SAP , :GE403-NUM-BOLETO-INTERNO , :GE403-NUM-NOSSO-NUMERO-SAP , :GE403-COD-LINHA-DIGITAVEL , :GE403-NUM-TITULO , :GE403-IDE-SISTEMA , :GE403-COD-USUARIO , :GE403-COD-SITUACAO , :WS-DTA-VENC-CUSTODIA FROM SEGUROS.GE_CONTROLE_EMISSAO_SIGCB A WHERE A.NUM_PROPOSTA = :GE403-NUM-PROPOSTA AND A.NUM_CERTIFICADO = :GE403-NUM-CERTIFICADO AND A.NUM_PARCELA = :GE403-NUM-PARCELA AND A.NUM_APOLICE = :GE403-NUM-APOLICE AND A.NUM_ENDOSSO = :GE403-NUM-ENDOSSO AND A.SEQ_CONTROLE_SIGCB = (SELECT MAX(B.SEQ_CONTROLE_SIGCB) FROM SEGUROS.GE_CONTROLE_EMISSAO_SIGCB B WHERE B.NUM_PROPOSTA = :GE403-NUM-PROPOSTA AND B.NUM_CERTIFICADO = :GE403-NUM-CERTIFICADO AND B.NUM_PARCELA = :GE403-NUM-PARCELA AND B.NUM_APOLICE = :GE403-NUM-APOLICE AND B.NUM_ENDOSSO = :GE403-NUM-ENDOSSO) WITH UR END-EXEC. */

            var r1000_CONSULTA_NN_VALIDO_DB_SELECT_1_Query1 = new R1000_CONSULTA_NN_VALIDO_DB_SELECT_1_Query1()
            {
                GE403_NUM_CERTIFICADO = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_CERTIFICADO.ToString(),
                GE403_NUM_PROPOSTA = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PROPOSTA.ToString(),
                GE403_NUM_PARCELA = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PARCELA.ToString(),
                GE403_NUM_APOLICE = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_APOLICE.ToString(),
                GE403_NUM_ENDOSSO = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = R1000_CONSULTA_NN_VALIDO_DB_SELECT_1_Query1.Execute(r1000_CONSULTA_NN_VALIDO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE403_SEQ_CONTROLE_SIGCB, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_SEQ_CONTROLE_SIGCB);
                _.Move(executed_1.GE403_DTA_MOVIMENTO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_DTA_MOVIMENTO);
                _.Move(executed_1.GE403_NUM_OCORR_MOVTO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_OCORR_MOVTO);
                _.Move(executed_1.GE403_NUM_IDLG, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_IDLG);
                _.Move(executed_1.GE403_COD_PRODUTO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_PRODUTO);
                _.Move(executed_1.GE403_DTA_VENCIMENTO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_DTA_VENCIMENTO);
                _.Move(executed_1.GE403_VLR_PREMIO_TOTAL, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_VLR_PREMIO_TOTAL);
                _.Move(executed_1.GE403_VLR_IOF, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_VLR_IOF);
                _.Move(executed_1.GE403_QTD_PARCELA, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_QTD_PARCELA);
                _.Move(executed_1.GE403_QTD_DIAS_CUSTODIA, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_QTD_DIAS_CUSTODIA);
                _.Move(executed_1.GE403_COD_CLIENTE, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_CLIENTE);
                _.Move(executed_1.GE403_COD_CEDENTE_SAP, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_CEDENTE_SAP);
                _.Move(executed_1.GE403_NUM_BOLETO_INTERNO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_BOLETO_INTERNO);
                _.Move(executed_1.GE403_NUM_NOSSO_NUMERO_SAP, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_NOSSO_NUMERO_SAP);
                _.Move(executed_1.GE403_COD_LINHA_DIGITAVEL, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_LINHA_DIGITAVEL);
                _.Move(executed_1.GE403_NUM_TITULO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_TITULO);
                _.Move(executed_1.GE403_IDE_SISTEMA, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_IDE_SISTEMA);
                _.Move(executed_1.GE403_COD_USUARIO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_USUARIO);
                _.Move(executed_1.GE403_COD_SITUACAO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_SITUACAO);
                _.Move(executed_1.WS_DTA_VENC_CUSTODIA, WS_DTA_VENC_CUSTODIA);
            }


        }

        [StopWatch]
        /*" R1100-CONS-NN-CERTIFICADO-SECTION */
        private void R1100_CONS_NN_CERTIFICADO_SECTION()
        {
            /*" -1105- PERFORM R1100_CONS_NN_CERTIFICADO_DB_SELECT_1 */

            R1100_CONS_NN_CERTIFICADO_DB_SELECT_1();

            /*" -1108- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1109- IF (SQLCODE EQUAL +100) */

                if ((DB.SQLCODE == +100))
                {

                    /*" -1110- MOVE '2' TO LK-GE350-COD-RETORNO */
                    _.Move("2", REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO);

                    /*" -1112- MOVE 'BOLETO NAO ENCONTRADO NO SIGCB ' TO LK-GE350-MSG-RETORNO */
                    _.Move("BOLETO NAO ENCONTRADO NO SIGCB ", REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                    /*" -1113- GO TO RXXXX-ROTINA-RETORNO */

                    RXXXX_ROTINA_RETORNO_SECTION(); //GOTO
                    return;

                    /*" -1114- ELSE */
                }
                else
                {


                    /*" -1116- MOVE 'R1100-ERRO GE_CONTROLE_EMISSAO_SIGCB' TO LK-GE350-MSG-RETORNO */
                    _.Move("R1100-ERRO GE_CONTROLE_EMISSAO_SIGCB", REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                    /*" -1117- PERFORM R8888-00-DISPLAY-ERRO */

                    R8888_00_DISPLAY_ERRO_SECTION();

                    /*" -1118- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1119- END-IF */
                }


                /*" -1120- ELSE */
            }
            else
            {


                /*" -1121- MOVE GE403-NUM-PROPOSTA TO LK-GE350-NUM-PROPOSTA */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PROPOSTA, REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PROPOSTA);

                /*" -1122- MOVE GE403-NUM-APOLICE TO LK-GE350-NUM-APOLICE */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_APOLICE, REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE);

                /*" -1123- MOVE GE403-NUM-ENDOSSO TO LK-GE350-NUM-ENDOSSO */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_ENDOSSO, REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO);

                /*" -1125- MOVE GE403-SEQ-CONTROLE-SIGCB TO LK-GE350-SEQ-CNTRLE-SIGCB */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_SEQ_CONTROLE_SIGCB, REGISTRO_LINKAGE_GE0350S.LK_GE350_SEQ_CNTRLE_SIGCB);

                /*" -1126- MOVE GE403-DTA-MOVIMENTO TO LK-GE350-DTA-MOVIMENTO */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_DTA_MOVIMENTO, REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_MOVIMENTO);

                /*" -1128- MOVE GE403-NUM-OCORR-MOVTO TO LK-GE350-NUM-OCORR-MOVTO */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_OCORR_MOVTO, REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_OCORR_MOVTO);

                /*" -1129- MOVE GE403-NUM-IDLG TO LK-GE350-NUM-IDLG */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_IDLG, REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_IDLG);

                /*" -1130- MOVE GE403-COD-PRODUTO TO LK-GE350-COD-PRODUTO */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_PRODUTO, REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_PRODUTO);

                /*" -1131- MOVE GE403-DTA-VENCIMENTO TO LK-GE350-DTA-VENCIMENTO */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_DTA_VENCIMENTO, REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_VENCIMENTO);

                /*" -1133- MOVE GE403-VLR-PREMIO-TOTAL TO LK-GE350-VLR-PREMIO-TOTAL */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_VLR_PREMIO_TOTAL, REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_PREMIO_TOTAL);

                /*" -1134- MOVE GE403-VLR-IOF TO LK-GE350-VLR-IOF */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_VLR_IOF, REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_IOF);

                /*" -1135- MOVE GE403-QTD-PARCELA TO LK-GE350-QTD-PARCELA */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_QTD_PARCELA, REGISTRO_LINKAGE_GE0350S.LK_GE350_QTD_PARCELA);

                /*" -1137- MOVE GE403-QTD-DIAS-CUSTODIA TO LK-GE350-QTD-DIAS-CUSTODIA */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_QTD_DIAS_CUSTODIA, REGISTRO_LINKAGE_GE0350S.LK_GE350_QTD_DIAS_CUSTODIA);

                /*" -1138- MOVE GE403-COD-CLIENTE TO LK-GE350-COD-CLIENTE */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_CLIENTE, REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_CLIENTE);

                /*" -1140- MOVE GE403-COD-CEDENTE-SAP TO LK-GE350-COD-CEDENTE-SAP */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_CEDENTE_SAP, REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_CEDENTE_SAP);

                /*" -1142- MOVE GE403-NUM-BOLETO-INTERNO TO LK-GE350-NUM-BLTO-INTERNO */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_BOLETO_INTERNO, REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_BLTO_INTERNO);

                /*" -1144- MOVE GE403-NUM-NOSSO-NUMERO-SAP TO LK-GE350-NOSSO-NUMERO-SAP */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_NOSSO_NUMERO_SAP, REGISTRO_LINKAGE_GE0350S.LK_GE350_NOSSO_NUMERO_SAP);

                /*" -1146- MOVE GE403-COD-LINHA-DIGITAVEL TO LK-GE350-COD-LINHA-DGTVEL */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_LINHA_DIGITAVEL, REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_LINHA_DGTVEL);

                /*" -1147- MOVE GE403-NUM-TITULO TO LK-GE350-NUM-TITULO */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_TITULO, REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_TITULO);

                /*" -1148- MOVE GE403-IDE-SISTEMA TO LK-GE350-IDE-SISTEMA */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_IDE_SISTEMA, REGISTRO_LINKAGE_GE0350S.LK_GE350_IDE_SISTEMA);

                /*" -1149- MOVE GE403-COD-USUARIO TO LK-GE350-COD-USUARIO */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_USUARIO, REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_USUARIO);

                /*" -1151- MOVE GE403-COD-SITUACAO TO LK-GE350-COD-SITUACAO */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_SITUACAO, REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO);

                /*" -1153- IF (LK-GE350-COD-SITUACAO NOT EQUAL 'R' ) AND (WS-DTA-VENC-CUSTODIA < HOST-CURRENT-DATE) */

                if ((REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO != "R") && (WS_DTA_VENC_CUSTODIA < HOST_CURRENT_DATE))
                {

                    /*" -1154- MOVE '3' TO LK-GE350-COD-RETORNO */
                    _.Move("3", REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO);

                    /*" -1155- MOVE 'T' TO LK-GE350-COD-SITUACAO */
                    _.Move("T", REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO);

                    /*" -1157- MOVE 'CUST�DIA DE BOLETO VENCIDA ' TO LK-GE350-MSG-RETORNO */
                    _.Move("CUST�DIA DE BOLETO VENCIDA ", REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                    /*" -1158- GO TO RXXXX-ROTINA-RETORNO */

                    RXXXX_ROTINA_RETORNO_SECTION(); //GOTO
                    return;

                    /*" -1160- END-IF */
                }


                /*" -1185- DISPLAY 'R1100 - PROP: ' LK-GE350-NUM-PROPOSTA 'CERT: ' LK-GE350-NUM-CERTIFICADO 'PARC: ' LK-GE350-NUM-PARCELA 'APOL: ' LK-GE350-NUM-APOLICE 'ENDO: ' LK-GE350-NUM-ENDOSSO 'CTRL: ' LK-GE350-SEQ-CNTRLE-SIGCB 'MOVT: ' LK-GE350-DTA-MOVIMENTO 'OCOR: ' LK-GE350-NUM-OCORR-MOVTO 'IDLG: ' LK-GE350-NUM-IDLG 'PROD: ' LK-GE350-COD-PRODUTO 'VENC: ' LK-GE350-DTA-VENCIMENTO 'PREM: ' LK-GE350-VLR-PREMIO-TOTAL 'IOF:  ' LK-GE350-VLR-IOF 'PARC: ' LK-GE350-QTD-PARCELA 'QTD:  ' LK-GE350-QTD-DIAS-CUSTODIA 'CODC: ' LK-GE350-COD-CLIENTE 'CEDE: ' LK-GE350-COD-CEDENTE-SAP 'BLTO: ' LK-GE350-NUM-BLTO-INTERNO 'NUMS: ' LK-GE350-NOSSO-NUMERO-SAP 'LINH: ' LK-GE350-COD-LINHA-DGTVEL 'TITU: ' LK-GE350-NUM-TITULO 'SIST: ' LK-GE350-IDE-SISTEMA 'USU:  ' LK-GE350-COD-USUARIO 'SIT:  ' LK-GE350-COD-SITUACAO 'DTVE: ' WS-DTA-VENC-CUSTODIA */

                $"R1100 - PROP: {REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PROPOSTA}CERT: {REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_CERTIFICADO}PARC: {REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA}APOL: {REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE}ENDO: {REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO}CTRL: {REGISTRO_LINKAGE_GE0350S.LK_GE350_SEQ_CNTRLE_SIGCB}MOVT: {REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_MOVIMENTO}OCOR: {REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_OCORR_MOVTO}IDLG: {REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_IDLG}PROD: {REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_PRODUTO}VENC: {REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_VENCIMENTO}PREM: {REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_PREMIO_TOTAL}IOF:  {REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_IOF}PARC: {REGISTRO_LINKAGE_GE0350S.LK_GE350_QTD_PARCELA}QTD:  {REGISTRO_LINKAGE_GE0350S.LK_GE350_QTD_DIAS_CUSTODIA}CODC: {REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_CLIENTE}CEDE: {REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_CEDENTE_SAP}BLTO: {REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_BLTO_INTERNO}NUMS: {REGISTRO_LINKAGE_GE0350S.LK_GE350_NOSSO_NUMERO_SAP}LINH: {REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_LINHA_DGTVEL}TITU: {REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_TITULO}SIST: {REGISTRO_LINKAGE_GE0350S.LK_GE350_IDE_SISTEMA}USU:  {REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_USUARIO}SIT:  {REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO}DTVE: {WS_DTA_VENC_CUSTODIA}"
                .Display();

                /*" -1186- END-IF */
            }


            /*" -1186- . */

        }

        [StopWatch]
        /*" R1100-CONS-NN-CERTIFICADO-DB-SELECT-1 */
        public void R1100_CONS_NN_CERTIFICADO_DB_SELECT_1()
        {
            /*" -1105- EXEC SQL SELECT NUM_PROPOSTA , NUM_APOLICE , NUM_ENDOSSO , SEQ_CONTROLE_SIGCB , DTA_MOVIMENTO , VALUE(NUM_OCORR_MOVTO, 0) , VALUE(NUM_IDLG, ' ' ) , COD_PRODUTO , DTA_VENCIMENTO , VLR_PREMIO_TOTAL , VLR_IOF , QTD_PARCELA , QTD_DIAS_CUSTODIA , COD_CLIENTE , VALUE(COD_CEDENTE_SAP, ' ' ) , VALUE(NUM_BOLETO_INTERNO, 0) , VALUE(NUM_NOSSO_NUMERO_SAP, 0) , VALUE(COD_LINHA_DIGITAVEL, ' ' ) , VALUE(NUM_TITULO, 0) , IDE_SISTEMA , COD_USUARIO , COD_SITUACAO , DATE(DTA_VENCIMENTO + QTD_DIAS_CUSTODIA DAYS) INTO :GE403-NUM-PROPOSTA , :GE403-NUM-APOLICE , :GE403-NUM-ENDOSSO , :GE403-SEQ-CONTROLE-SIGCB , :GE403-DTA-MOVIMENTO , :GE403-NUM-OCORR-MOVTO , :GE403-NUM-IDLG , :GE403-COD-PRODUTO , :GE403-DTA-VENCIMENTO , :GE403-VLR-PREMIO-TOTAL , :GE403-VLR-IOF , :GE403-QTD-PARCELA , :GE403-QTD-DIAS-CUSTODIA , :GE403-COD-CLIENTE , :GE403-COD-CEDENTE-SAP , :GE403-NUM-BOLETO-INTERNO , :GE403-NUM-NOSSO-NUMERO-SAP , :GE403-COD-LINHA-DIGITAVEL , :GE403-NUM-TITULO , :GE403-IDE-SISTEMA , :GE403-COD-USUARIO , :GE403-COD-SITUACAO , :WS-DTA-VENC-CUSTODIA FROM SEGUROS.GE_CONTROLE_EMISSAO_SIGCB A WHERE A.NUM_CERTIFICADO = :GE403-NUM-CERTIFICADO AND A.NUM_PARCELA = :GE403-NUM-PARCELA AND A.SEQ_CONTROLE_SIGCB = (SELECT MAX(B.SEQ_CONTROLE_SIGCB) FROM SEGUROS.GE_CONTROLE_EMISSAO_SIGCB B WHERE B.NUM_CERTIFICADO = :GE403-NUM-CERTIFICADO AND B.NUM_PARCELA = :GE403-NUM-PARCELA) WITH UR END-EXEC. */

            var r1100_CONS_NN_CERTIFICADO_DB_SELECT_1_Query1 = new R1100_CONS_NN_CERTIFICADO_DB_SELECT_1_Query1()
            {
                GE403_NUM_CERTIFICADO = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_CERTIFICADO.ToString(),
                GE403_NUM_PARCELA = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PARCELA.ToString(),
            };

            var executed_1 = R1100_CONS_NN_CERTIFICADO_DB_SELECT_1_Query1.Execute(r1100_CONS_NN_CERTIFICADO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE403_NUM_PROPOSTA, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PROPOSTA);
                _.Move(executed_1.GE403_NUM_APOLICE, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_APOLICE);
                _.Move(executed_1.GE403_NUM_ENDOSSO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_ENDOSSO);
                _.Move(executed_1.GE403_SEQ_CONTROLE_SIGCB, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_SEQ_CONTROLE_SIGCB);
                _.Move(executed_1.GE403_DTA_MOVIMENTO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_DTA_MOVIMENTO);
                _.Move(executed_1.GE403_NUM_OCORR_MOVTO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_OCORR_MOVTO);
                _.Move(executed_1.GE403_NUM_IDLG, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_IDLG);
                _.Move(executed_1.GE403_COD_PRODUTO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_PRODUTO);
                _.Move(executed_1.GE403_DTA_VENCIMENTO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_DTA_VENCIMENTO);
                _.Move(executed_1.GE403_VLR_PREMIO_TOTAL, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_VLR_PREMIO_TOTAL);
                _.Move(executed_1.GE403_VLR_IOF, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_VLR_IOF);
                _.Move(executed_1.GE403_QTD_PARCELA, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_QTD_PARCELA);
                _.Move(executed_1.GE403_QTD_DIAS_CUSTODIA, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_QTD_DIAS_CUSTODIA);
                _.Move(executed_1.GE403_COD_CLIENTE, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_CLIENTE);
                _.Move(executed_1.GE403_COD_CEDENTE_SAP, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_CEDENTE_SAP);
                _.Move(executed_1.GE403_NUM_BOLETO_INTERNO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_BOLETO_INTERNO);
                _.Move(executed_1.GE403_NUM_NOSSO_NUMERO_SAP, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_NOSSO_NUMERO_SAP);
                _.Move(executed_1.GE403_COD_LINHA_DIGITAVEL, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_LINHA_DIGITAVEL);
                _.Move(executed_1.GE403_NUM_TITULO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_TITULO);
                _.Move(executed_1.GE403_IDE_SISTEMA, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_IDE_SISTEMA);
                _.Move(executed_1.GE403_COD_USUARIO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_USUARIO);
                _.Move(executed_1.GE403_COD_SITUACAO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_SITUACAO);
                _.Move(executed_1.WS_DTA_VENC_CUSTODIA, WS_DTA_VENC_CUSTODIA);
            }


        }

        [StopWatch]
        /*" R2000-SOLICITA-NOVO-NN-SAP-SECTION */
        private void R2000_SOLICITA_NOVO_NN_SAP_SECTION()
        {
            /*" -1193- MOVE ZEROS TO WS-IND-NN-SAP */
            _.Move(0, WS_IND_NN_SAP);

            /*" -1194- MOVE ZEROS TO WS-IND-COD-CEDENTE */
            _.Move(0, WS_IND_COD_CEDENTE);

            /*" -1195- MOVE ZEROS TO WS-IND-BOL-INT */
            _.Move(0, WS_IND_BOL_INT);

            /*" -1196- MOVE ZEROS TO WS-IND-COD-LIN-DIG */
            _.Move(0, WS_IND_COD_LIN_DIG);

            /*" -1197- MOVE ZEROS TO WS-IND-NUM-OCORR-MOVTO */
            _.Move(0, WS_IND_NUM_OCORR_MOVTO);

            /*" -1198- MOVE ZEROS TO WS-IND-NUM-TITULO */
            _.Move(0, WS_IND_NUM_TITULO);

            /*" -1199- MOVE ZEROS TO WS-IND-NUM-IDLG */
            _.Move(0, WS_IND_NUM_IDLG);

            /*" -1200- MOVE -1 TO WS-IND-COD-REJEICAO */
            _.Move(-1, WS_IND_COD_REJEICAO);

            /*" -1201- IF (LK-GE350-DTA-MOVIMENTO EQUAL SPACES) */

            if ((REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_MOVIMENTO.IsEmpty()))
            {

                /*" -1202- MOVE HOST-CURRENT-DATE TO LK-GE350-DTA-MOVIMENTO */
                _.Move(HOST_CURRENT_DATE, REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_MOVIMENTO);

                /*" -1203- ELSE */
            }
            else
            {


                /*" -1204- MOVE LK-GE350-DTA-MOVIMENTO TO WS-DATA-AUX */
                _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_MOVIMENTO, AREA_DE_WORK.WS_DATA_AUX);

                /*" -1205- PERFORM R0100-CRITICA-DATA */

                R0100_CRITICA_DATA_SECTION();

                /*" -1206- IF (LK-GE350-COD-RETORNO EQUAL '1' ) */

                if ((REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO == "1"))
                {

                    /*" -1208- MOVE 'GE0350S - DTA-MOVIMENTO INVALIDO ' TO LK-GE350-MSG-RETORNO */
                    _.Move("GE0350S - DTA-MOVIMENTO INVALIDO ", REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                    /*" -1209- GO TO RXXXX-ROTINA-RETORNO */

                    RXXXX_ROTINA_RETORNO_SECTION(); //GOTO
                    return;

                    /*" -1210- END-IF */
                }


                /*" -1211- END-IF */
            }


            /*" -1212- IF (LK-GE350-DTA-VENCIMENTO EQUAL SPACES) */

            if ((REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_VENCIMENTO.IsEmpty()))
            {

                /*" -1213- MOVE '1' TO LK-GE350-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO);

                /*" -1215- MOVE 'GE0350S - DTA-VENCIMENTO INVALIDO ' TO LK-GE350-MSG-RETORNO */
                _.Move("GE0350S - DTA-VENCIMENTO INVALIDO ", REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                /*" -1216- GO TO RXXXX-ROTINA-RETORNO */

                RXXXX_ROTINA_RETORNO_SECTION(); //GOTO
                return;

                /*" -1217- ELSE */
            }
            else
            {


                /*" -1218- MOVE LK-GE350-DTA-VENCIMENTO TO WS-DATA-AUX */
                _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_VENCIMENTO, AREA_DE_WORK.WS_DATA_AUX);

                /*" -1219- PERFORM R0100-CRITICA-DATA */

                R0100_CRITICA_DATA_SECTION();

                /*" -1220- IF (LK-GE350-COD-RETORNO EQUAL '1' ) */

                if ((REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO == "1"))
                {

                    /*" -1222- MOVE 'GE0350S - DTA-VENCIMENTO INVALIDO ' TO LK-GE350-MSG-RETORNO */
                    _.Move("GE0350S - DTA-VENCIMENTO INVALIDO ", REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                    /*" -1223- GO TO RXXXX-ROTINA-RETORNO */

                    RXXXX_ROTINA_RETORNO_SECTION(); //GOTO
                    return;

                    /*" -1224- END-IF */
                }


                /*" -1225- END-IF */
            }


            /*" -1227- IF (LK-GE350-VLR-PREMIO-TOTAL IS NOT NUMERIC) OR (LK-GE350-VLR-PREMIO-TOTAL EQUAL ZEROS) */

            if ((!REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_PREMIO_TOTAL.IsNumeric()) || (REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_PREMIO_TOTAL == 00))
            {

                /*" -1228- MOVE '1' TO LK-GE350-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO);

                /*" -1230- MOVE 'GE0350S-VLR-PRMO-TOTAL NAO NUMERICO OU ZERADO ' TO LK-GE350-MSG-RETORNO */
                _.Move("GE0350S-VLR-PRMO-TOTAL NAO NUMERICO OU ZERADO ", REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                /*" -1231- GO TO RXXXX-ROTINA-RETORNO */

                RXXXX_ROTINA_RETORNO_SECTION(); //GOTO
                return;

                /*" -1232- END-IF */
            }


            /*" -1237- IF (((LK-GE350-QTD-DIAS-CUSTODIA < 05) OR (LK-GE350-QTD-DIAS-CUSTODIA > 29)) AND ((LK-GE350-COD-USUARIO NOT EQUAL 'CB1261B' AND 'SPBCM027' ))) AND WS-IND-FLAG = 0 */

            if ((((REGISTRO_LINKAGE_GE0350S.LK_GE350_QTD_DIAS_CUSTODIA < 05) || (REGISTRO_LINKAGE_GE0350S.LK_GE350_QTD_DIAS_CUSTODIA > 29)) && ((!REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_USUARIO.In("CB1261B", "SPBCM027")))) && WS_IND_FLAG == 0)
            {

                /*" -1238- MOVE '1' TO LK-GE350-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO);

                /*" -1240- MOVE 'GE0350S - QTD-DIAS-CUSTODIA INV�LIDA' TO LK-GE350-MSG-RETORNO */
                _.Move("GE0350S - QTD-DIAS-CUSTODIA INV�LIDA", REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                /*" -1241- GO TO RXXXX-ROTINA-RETORNO */

                RXXXX_ROTINA_RETORNO_SECTION(); //GOTO
                return;

                /*" -1242- END-IF */
            }


            /*" -1243- IF (LK-GE350-COD-CLIENTE NOT EQUAL ZEROS) */

            if ((REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_CLIENTE != 00))
            {

                /*" -1245- PERFORM R0110-CRITICA-CLIENTE */

                R0110_CRITICA_CLIENTE_SECTION();

                /*" -1246- IF (LK-GE350-COD-RETORNO EQUAL '1' ) */

                if ((REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO == "1"))
                {

                    /*" -1248- MOVE 'GE0350S - COD-CLIENTE INVALIDO ' TO LK-GE350-MSG-RETORNO */
                    _.Move("GE0350S - COD-CLIENTE INVALIDO ", REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                    /*" -1249- GO TO RXXXX-ROTINA-RETORNO */

                    RXXXX_ROTINA_RETORNO_SECTION(); //GOTO
                    return;

                    /*" -1250- END-IF */
                }


                /*" -1251- END-IF */
            }


            /*" -1252- IF (LK-GE350-COD-SITUACAO EQUAL 'A' OR 'G' OR 'H' ) */

            if ((REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO.In("A", "G", "H")))
            {

                /*" -1253- IF (LK-GE350-NOSSO-NUMERO-SAP EQUAL ZEROS) */

                if ((REGISTRO_LINKAGE_GE0350S.LK_GE350_NOSSO_NUMERO_SAP == 00))
                {

                    /*" -1254- MOVE '1' TO LK-GE350-COD-RETORNO */
                    _.Move("1", REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO);

                    /*" -1256- MOVE 'GE0350S-DEVE INFORMAR NN SAP P/ SIT-REGISTRO' TO LK-GE350-MSG-RETORNO */
                    _.Move("GE0350S-DEVE INFORMAR NN SAP P/ SIT-REGISTRO", REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                    /*" -1257- GO TO RXXXX-ROTINA-RETORNO */

                    RXXXX_ROTINA_RETORNO_SECTION(); //GOTO
                    return;

                    /*" -1258- END-IF */
                }


                /*" -1259- END-IF */
            }


            /*" -1260- IF (LK-GE350-NOSSO-NUMERO-SAP EQUAL ZEROS) */

            if ((REGISTRO_LINKAGE_GE0350S.LK_GE350_NOSSO_NUMERO_SAP == 00))
            {

                /*" -1261- MOVE -1 TO WS-IND-NN-SAP */
                _.Move(-1, WS_IND_NN_SAP);

                /*" -1263- END-IF */
            }


            /*" -1264- IF (LK-GE350-COD-CEDENTE-SAP EQUAL SPACES) */

            if ((REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_CEDENTE_SAP.IsEmpty()))
            {

                /*" -1265- MOVE -1 TO WS-IND-COD-CEDENTE */
                _.Move(-1, WS_IND_COD_CEDENTE);

                /*" -1267- END-IF */
            }


            /*" -1268- IF (LK-GE350-NUM-BLTO-INTERNO EQUAL ZEROS) */

            if ((REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_BLTO_INTERNO == 00))
            {

                /*" -1269- MOVE -1 TO WS-IND-BOL-INT */
                _.Move(-1, WS_IND_BOL_INT);

                /*" -1271- END-IF */
            }


            /*" -1272- IF (LK-GE350-COD-LINHA-DGTVEL EQUAL SPACES) */

            if ((REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_LINHA_DGTVEL.IsEmpty()))
            {

                /*" -1273- MOVE -1 TO WS-IND-COD-LIN-DIG */
                _.Move(-1, WS_IND_COD_LIN_DIG);

                /*" -1275- END-IF */
            }


            /*" -1276- IF (LK-GE350-NUM-TITULO EQUAL ZEROS) */

            if ((REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_TITULO == 00))
            {

                /*" -1277- MOVE -1 TO WS-IND-NUM-TITULO */
                _.Move(-1, WS_IND_NUM_TITULO);

                /*" -1279- END-IF */
            }


            /*" -1280- IF (LK-GE350-NUM-IDLG EQUAL SPACES) */

            if ((REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_IDLG.IsEmpty()))
            {

                /*" -1281- MOVE -1 TO WS-IND-NUM-IDLG */
                _.Move(-1, WS_IND_NUM_IDLG);

                /*" -1283- END-IF */
            }


            /*" -1284- IF (LK-GE350-NUM-OCORR-MOVTO EQUAL ZEROS) */

            if ((REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_OCORR_MOVTO == 00))
            {

                /*" -1285- MOVE -1 TO WS-IND-NUM-OCORR-MOVTO */
                _.Move(-1, WS_IND_NUM_OCORR_MOVTO);

                /*" -1287- END-IF */
            }


            /*" -1288- IF (LK-GE350-COD-REJEICAO EQUAL SPACES) */

            if ((REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_REJEICAO.IsEmpty()))
            {

                /*" -1289- MOVE -1 TO WS-IND-COD-REJEICAO */
                _.Move(-1, WS_IND_COD_REJEICAO);

                /*" -1291- END-IF */
            }


            /*" -1292- PERFORM R2100-INSERE-CONTROLE-SIGCB */

            R2100_INSERE_CONTROLE_SIGCB_SECTION();

            /*" -1293- PERFORM R2500-INSERE-CONTROLE-HIST */

            R2500_INSERE_CONTROLE_HIST_SECTION();

            /*" -1293- . */

        }

        [StopWatch]
        /*" R2100-INSERE-CONTROLE-SIGCB-SECTION */
        private void R2100_INSERE_CONTROLE_SIGCB_SECTION()
        {
            /*" -1300- MOVE LK-GE350-NUM-PROPOSTA TO GE403-NUM-PROPOSTA */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PROPOSTA, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PROPOSTA);

            /*" -1301- MOVE LK-GE350-NUM-CERTIFICADO TO GE403-NUM-CERTIFICADO */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_CERTIFICADO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_CERTIFICADO);

            /*" -1302- MOVE LK-GE350-NUM-PARCELA TO GE403-NUM-PARCELA */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PARCELA);

            /*" -1303- MOVE LK-GE350-NUM-APOLICE TO GE403-NUM-APOLICE */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_APOLICE);

            /*" -1305- MOVE LK-GE350-NUM-ENDOSSO TO GE403-NUM-ENDOSSO */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_ENDOSSO);

            /*" -1307- PERFORM R2200-MAX-SEQ-CONTROLE-EMISSAO */

            R2200_MAX_SEQ_CONTROLE_EMISSAO_SECTION();

            /*" -1309- MOVE GE403-SEQ-CONTROLE-SIGCB TO LK-GE350-SEQ-CNTRLE-SIGCB */
            _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_SEQ_CONTROLE_SIGCB, REGISTRO_LINKAGE_GE0350S.LK_GE350_SEQ_CNTRLE_SIGCB);

            /*" -1310- IF WS-IND-NUM-OCORR-MOVTO = 0 */

            if (WS_IND_NUM_OCORR_MOVTO == 0)
            {

                /*" -1311- MOVE LK-GE350-NUM-OCORR-MOVTO TO GE403-NUM-OCORR-MOVTO */
                _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_OCORR_MOVTO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_OCORR_MOVTO);

                /*" -1312- ELSE */
            }
            else
            {


                /*" -1313- INITIALIZE GE403-NUM-OCORR-MOVTO */
                _.Initialize(
                    GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_OCORR_MOVTO
                );

                /*" -1314- END-IF */
            }


            /*" -1315- IF WS-IND-NUM-IDLG = 0 */

            if (WS_IND_NUM_IDLG == 0)
            {

                /*" -1316- MOVE LK-GE350-NUM-IDLG TO GE403-NUM-IDLG */
                _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_IDLG, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_IDLG);

                /*" -1317- ELSE */
            }
            else
            {


                /*" -1318- INITIALIZE GE403-NUM-IDLG */
                _.Initialize(
                    GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_IDLG
                );

                /*" -1319- END-IF */
            }


            /*" -1320- MOVE LK-GE350-COD-PRODUTO TO GE403-COD-PRODUTO */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_PRODUTO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_PRODUTO);

            /*" -1321- MOVE LK-GE350-DTA-MOVIMENTO TO GE403-DTA-MOVIMENTO */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_MOVIMENTO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_DTA_MOVIMENTO);

            /*" -1322- MOVE LK-GE350-DTA-VENCIMENTO TO GE403-DTA-VENCIMENTO */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_VENCIMENTO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_DTA_VENCIMENTO);

            /*" -1323- MOVE LK-GE350-VLR-PREMIO-TOTAL TO GE403-VLR-PREMIO-TOTAL */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_PREMIO_TOTAL, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_VLR_PREMIO_TOTAL);

            /*" -1324- MOVE LK-GE350-VLR-IOF TO GE403-VLR-IOF */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_IOF, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_VLR_IOF);

            /*" -1325- MOVE LK-GE350-QTD-PARCELA TO GE403-QTD-PARCELA */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_QTD_PARCELA, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_QTD_PARCELA);

            /*" -1326- MOVE LK-GE350-QTD-DIAS-CUSTODIA TO GE403-QTD-DIAS-CUSTODIA */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_QTD_DIAS_CUSTODIA, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_QTD_DIAS_CUSTODIA);

            /*" -1327- MOVE LK-GE350-COD-CLIENTE TO GE403-COD-CLIENTE */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_CLIENTE, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_CLIENTE);

            /*" -1328- IF WS-IND-COD-CEDENTE = 0 */

            if (WS_IND_COD_CEDENTE == 0)
            {

                /*" -1329- MOVE LK-GE350-COD-CEDENTE-SAP TO GE403-COD-CEDENTE-SAP */
                _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_CEDENTE_SAP, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_CEDENTE_SAP);

                /*" -1330- ELSE */
            }
            else
            {


                /*" -1331- INITIALIZE GE403-COD-CEDENTE-SAP */
                _.Initialize(
                    GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_CEDENTE_SAP
                );

                /*" -1332- END-IF */
            }


            /*" -1333- IF WS-IND-BOL-INT = 0 */

            if (WS_IND_BOL_INT == 0)
            {

                /*" -1334- MOVE LK-GE350-NUM-BLTO-INTERNO TO GE403-NUM-BOLETO-INTERNO */
                _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_BLTO_INTERNO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_BOLETO_INTERNO);

                /*" -1335- ELSE */
            }
            else
            {


                /*" -1336- INITIALIZE GE403-NUM-BOLETO-INTERNO */
                _.Initialize(
                    GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_BOLETO_INTERNO
                );

                /*" -1337- END-IF */
            }


            /*" -1338- IF WS-IND-NN-SAP = 0 */

            if (WS_IND_NN_SAP == 0)
            {

                /*" -1340- MOVE LK-GE350-NOSSO-NUMERO-SAP TO GE403-NUM-NOSSO-NUMERO-SAP */
                _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NOSSO_NUMERO_SAP, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_NOSSO_NUMERO_SAP);

                /*" -1341- ELSE */
            }
            else
            {


                /*" -1342- INITIALIZE GE403-NUM-NOSSO-NUMERO-SAP */
                _.Initialize(
                    GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_NOSSO_NUMERO_SAP
                );

                /*" -1343- END-IF */
            }


            /*" -1344- IF WS-IND-COD-LIN-DIG = 0 */

            if (WS_IND_COD_LIN_DIG == 0)
            {

                /*" -1346- MOVE LK-GE350-COD-LINHA-DGTVEL TO GE403-COD-LINHA-DIGITAVEL */
                _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_LINHA_DGTVEL, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_LINHA_DIGITAVEL);

                /*" -1347- ELSE */
            }
            else
            {


                /*" -1348- INITIALIZE GE403-COD-LINHA-DIGITAVEL */
                _.Initialize(
                    GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_LINHA_DIGITAVEL
                );

                /*" -1349- END-IF */
            }


            /*" -1350- IF WS-IND-NUM-TITULO = 0 */

            if (WS_IND_NUM_TITULO == 0)
            {

                /*" -1351- MOVE LK-GE350-NUM-TITULO TO GE403-NUM-TITULO */
                _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_TITULO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_TITULO);

                /*" -1352- ELSE */
            }
            else
            {


                /*" -1353- INITIALIZE GE403-NUM-TITULO */
                _.Initialize(
                    GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_TITULO
                );

                /*" -1354- END-IF */
            }


            /*" -1355- MOVE LK-GE350-IDE-SISTEMA TO GE403-IDE-SISTEMA */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_IDE_SISTEMA, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_IDE_SISTEMA);

            /*" -1356- MOVE LK-GE350-COD-USUARIO TO GE403-COD-USUARIO */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_USUARIO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_USUARIO);

            /*" -1358- MOVE LK-GE350-COD-SITUACAO TO GE403-COD-SITUACAO */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_SITUACAO);

            /*" -1386- PERFORM R2100_INSERE_CONTROLE_SIGCB_DB_INSERT_1 */

            R2100_INSERE_CONTROLE_SIGCB_DB_INSERT_1();

            /*" -1389- IF (SQLCODE NOT EQUAL ZEROS AND -803) */

            if ((!DB.SQLCODE.In("00", "-803")))
            {

                /*" -1390- DISPLAY ' R2100-ERRO INSERT GE_CONTROLE_EMISSAO_SIGCB' */
                _.Display($" R2100-ERRO INSERT GE_CONTROLE_EMISSAO_SIGCB");

                /*" -1392- MOVE ' R2100-ERRO INSERT CONTROLE_EMISSAO_SIGCB' TO LK-GE350-MSG-RETORNO */
                _.Move(" R2100-ERRO INSERT CONTROLE_EMISSAO_SIGCB", REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                /*" -1393- PERFORM R8888-00-DISPLAY-ERRO */

                R8888_00_DISPLAY_ERRO_SECTION();

                /*" -1394- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1396- END-IF */
            }


            /*" -1397- IF (SQLCODE EQUAL -803) */

            if ((DB.SQLCODE == -803))
            {

                /*" -1398- DISPLAY 'R2100-ERRO -803 - JA EXISTE SOLICITACAO' */
                _.Display($"R2100-ERRO -803 - JA EXISTE SOLICITACAO");

                /*" -1404- DISPLAY 'CHAVE ' GE403-NUM-PROPOSTA '|' GE403-NUM-CERTIFICADO '|' GE403-NUM-PARCELA '|' GE403-NUM-APOLICE '|' GE403-NUM-ENDOSSO '|' GE403-SEQ-CONTROLE-SIGCB */

                $"CHAVE {GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PROPOSTA}|{GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_CERTIFICADO}|{GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PARCELA}|{GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_APOLICE}|{GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_ENDOSSO}|{GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_SEQ_CONTROLE_SIGCB}"
                .Display();

                /*" -1405- MOVE '1' TO LK-GE350-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO);

                /*" -1407- MOVE 'R2100-ERRO -803 - JA EXISTE SOLICITACAO AO SAP' TO LK-GE350-MSG-RETORNO */
                _.Move("R2100-ERRO -803 - JA EXISTE SOLICITACAO AO SAP", REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                /*" -1408- GO TO RXXXX-ROTINA-RETORNO */

                RXXXX_ROTINA_RETORNO_SECTION(); //GOTO
                return;

                /*" -1409- END-IF */
            }


            /*" -1409- . */

        }

        [StopWatch]
        /*" R2100-INSERE-CONTROLE-SIGCB-DB-INSERT-1 */
        public void R2100_INSERE_CONTROLE_SIGCB_DB_INSERT_1()
        {
            /*" -1386- EXEC SQL INSERT INTO SEGUROS.GE_CONTROLE_EMISSAO_SIGCB VALUES ( :GE403-NUM-PROPOSTA , :GE403-NUM-CERTIFICADO , :GE403-NUM-PARCELA , :GE403-NUM-APOLICE , :GE403-NUM-ENDOSSO , :GE403-SEQ-CONTROLE-SIGCB , :GE403-NUM-OCORR-MOVTO :WS-IND-NUM-OCORR-MOVTO, :GE403-NUM-IDLG :WS-IND-NUM-IDLG, :GE403-COD-PRODUTO , :GE403-DTA-MOVIMENTO , :GE403-DTA-VENCIMENTO , :GE403-VLR-PREMIO-TOTAL , :GE403-VLR-IOF , :GE403-QTD-PARCELA , :GE403-QTD-DIAS-CUSTODIA , :GE403-COD-CLIENTE , :GE403-COD-CEDENTE-SAP :WS-IND-COD-CEDENTE, :GE403-NUM-BOLETO-INTERNO :WS-IND-BOL-INT, :GE403-NUM-NOSSO-NUMERO-SAP :WS-IND-NN-SAP, :GE403-COD-LINHA-DIGITAVEL :WS-IND-COD-LIN-DIG, :GE403-NUM-TITULO :WS-IND-NUM-TITULO, :GE403-IDE-SISTEMA , :GE403-COD-USUARIO , :GE403-COD-SITUACAO , CURRENT_TIMESTAMP) END-EXEC. */

            var r2100_INSERE_CONTROLE_SIGCB_DB_INSERT_1_Insert1 = new R2100_INSERE_CONTROLE_SIGCB_DB_INSERT_1_Insert1()
            {
                GE403_NUM_PROPOSTA = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PROPOSTA.ToString(),
                GE403_NUM_CERTIFICADO = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_CERTIFICADO.ToString(),
                GE403_NUM_PARCELA = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PARCELA.ToString(),
                GE403_NUM_APOLICE = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_APOLICE.ToString(),
                GE403_NUM_ENDOSSO = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_ENDOSSO.ToString(),
                GE403_SEQ_CONTROLE_SIGCB = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_SEQ_CONTROLE_SIGCB.ToString(),
                GE403_NUM_OCORR_MOVTO = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_OCORR_MOVTO.ToString(),
                WS_IND_NUM_OCORR_MOVTO = WS_IND_NUM_OCORR_MOVTO.ToString(),
                GE403_NUM_IDLG = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_IDLG.ToString(),
                WS_IND_NUM_IDLG = WS_IND_NUM_IDLG.ToString(),
                GE403_COD_PRODUTO = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_PRODUTO.ToString(),
                GE403_DTA_MOVIMENTO = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_DTA_MOVIMENTO.ToString(),
                GE403_DTA_VENCIMENTO = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_DTA_VENCIMENTO.ToString(),
                GE403_VLR_PREMIO_TOTAL = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_VLR_PREMIO_TOTAL.ToString(),
                GE403_VLR_IOF = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_VLR_IOF.ToString(),
                GE403_QTD_PARCELA = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_QTD_PARCELA.ToString(),
                GE403_QTD_DIAS_CUSTODIA = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_QTD_DIAS_CUSTODIA.ToString(),
                GE403_COD_CLIENTE = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_CLIENTE.ToString(),
                GE403_COD_CEDENTE_SAP = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_CEDENTE_SAP.ToString(),
                WS_IND_COD_CEDENTE = WS_IND_COD_CEDENTE.ToString(),
                GE403_NUM_BOLETO_INTERNO = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_BOLETO_INTERNO.ToString(),
                WS_IND_BOL_INT = WS_IND_BOL_INT.ToString(),
                GE403_NUM_NOSSO_NUMERO_SAP = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_NOSSO_NUMERO_SAP.ToString(),
                WS_IND_NN_SAP = WS_IND_NN_SAP.ToString(),
                GE403_COD_LINHA_DIGITAVEL = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_LINHA_DIGITAVEL.ToString(),
                WS_IND_COD_LIN_DIG = WS_IND_COD_LIN_DIG.ToString(),
                GE403_NUM_TITULO = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_TITULO.ToString(),
                WS_IND_NUM_TITULO = WS_IND_NUM_TITULO.ToString(),
                GE403_IDE_SISTEMA = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_IDE_SISTEMA.ToString(),
                GE403_COD_USUARIO = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_USUARIO.ToString(),
                GE403_COD_SITUACAO = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_SITUACAO.ToString(),
            };

            R2100_INSERE_CONTROLE_SIGCB_DB_INSERT_1_Insert1.Execute(r2100_INSERE_CONTROLE_SIGCB_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R2200-MAX-SEQ-CONTROLE-EMISSAO-SECTION */
        private void R2200_MAX_SEQ_CONTROLE_EMISSAO_SECTION()
        {
            /*" -1417- INITIALIZE GE403-SEQ-CONTROLE-SIGCB */
            _.Initialize(
                GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_SEQ_CONTROLE_SIGCB
            );

            /*" -1427- PERFORM R2200_MAX_SEQ_CONTROLE_EMISSAO_DB_SELECT_1 */

            R2200_MAX_SEQ_CONTROLE_EMISSAO_DB_SELECT_1();

            /*" -1430- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -1431- DISPLAY 'R2200-ERRO SELECT MAX CONTROLE EMISSAO ' */
                _.Display($"R2200-ERRO SELECT MAX CONTROLE EMISSAO ");

                /*" -1433- MOVE 'R2200-ERRO SELECT MAX CONTROLE EMISSAO ' TO LK-GE350-MSG-RETORNO */
                _.Move("R2200-ERRO SELECT MAX CONTROLE EMISSAO ", REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                /*" -1434- PERFORM R8888-00-DISPLAY-ERRO */

                R8888_00_DISPLAY_ERRO_SECTION();

                /*" -1435- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1436- END-IF */
            }


            /*" -1436- . */

        }

        [StopWatch]
        /*" R2200-MAX-SEQ-CONTROLE-EMISSAO-DB-SELECT-1 */
        public void R2200_MAX_SEQ_CONTROLE_EMISSAO_DB_SELECT_1()
        {
            /*" -1427- EXEC SQL SELECT VALUE(MAX(SEQ_CONTROLE_SIGCB), 0) + 1 INTO :GE403-SEQ-CONTROLE-SIGCB FROM SEGUROS.GE_CONTROLE_EMISSAO_SIGCB WHERE NUM_PROPOSTA = :GE403-NUM-PROPOSTA AND NUM_CERTIFICADO = :GE403-NUM-CERTIFICADO AND NUM_PARCELA = :GE403-NUM-PARCELA AND NUM_APOLICE = :GE403-NUM-APOLICE AND NUM_ENDOSSO = :GE403-NUM-ENDOSSO WITH UR END-EXEC. */

            var r2200_MAX_SEQ_CONTROLE_EMISSAO_DB_SELECT_1_Query1 = new R2200_MAX_SEQ_CONTROLE_EMISSAO_DB_SELECT_1_Query1()
            {
                GE403_NUM_CERTIFICADO = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_CERTIFICADO.ToString(),
                GE403_NUM_PROPOSTA = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PROPOSTA.ToString(),
                GE403_NUM_PARCELA = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PARCELA.ToString(),
                GE403_NUM_APOLICE = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_APOLICE.ToString(),
                GE403_NUM_ENDOSSO = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = R2200_MAX_SEQ_CONTROLE_EMISSAO_DB_SELECT_1_Query1.Execute(r2200_MAX_SEQ_CONTROLE_EMISSAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE403_SEQ_CONTROLE_SIGCB, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_SEQ_CONTROLE_SIGCB);
            }


        }

        [StopWatch]
        /*" R2500-INSERE-CONTROLE-HIST-SECTION */
        private void R2500_INSERE_CONTROLE_HIST_SECTION()
        {
            /*" -1443- MOVE LK-GE350-NUM-PROPOSTA TO GE403-NUM-PROPOSTA */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PROPOSTA, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PROPOSTA);

            /*" -1444- MOVE LK-GE350-NUM-CERTIFICADO TO GE403-NUM-CERTIFICADO */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_CERTIFICADO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_CERTIFICADO);

            /*" -1445- MOVE LK-GE350-NUM-PARCELA TO GE403-NUM-PARCELA */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PARCELA);

            /*" -1446- MOVE LK-GE350-NUM-APOLICE TO GE403-NUM-APOLICE */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_APOLICE);

            /*" -1447- MOVE LK-GE350-NUM-ENDOSSO TO GE403-NUM-ENDOSSO */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_ENDOSSO);

            /*" -1448- MOVE LK-GE350-COD-SITUACAO TO GE403-COD-SITUACAO */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_SITUACAO);

            /*" -1449- IF WS-IND-COD-REJEICAO = 0 */

            if (WS_IND_COD_REJEICAO == 0)
            {

                /*" -1450- MOVE LK-GE350-COD-REJEICAO TO GE404-COD-REJEICAO */
                _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_REJEICAO, GE404.DCLGE_CONTROLE_SIGCB_HIST.GE404_COD_REJEICAO);

                /*" -1451- ELSE */
            }
            else
            {


                /*" -1452- INITIALIZE GE404-COD-REJEICAO */
                _.Initialize(
                    GE404.DCLGE_CONTROLE_SIGCB_HIST.GE404_COD_REJEICAO
                );

                /*" -1453- END-IF */
            }


            /*" -1454- MOVE LK-GE350-IDE-SISTEMA TO GE403-IDE-SISTEMA */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_IDE_SISTEMA, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_IDE_SISTEMA);

            /*" -1456- MOVE LK-GE350-COD-USUARIO TO GE403-COD-USUARIO */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_USUARIO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_USUARIO);

            /*" -1458- PERFORM R2510-MAX-SEQ-CONTROLE-SIGCB */

            R2510_MAX_SEQ_CONTROLE_SIGCB_SECTION();

            /*" -1473- PERFORM R2500_INSERE_CONTROLE_HIST_DB_INSERT_1 */

            R2500_INSERE_CONTROLE_HIST_DB_INSERT_1();

            /*" -1476- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1477- DISPLAY 'R2500-ERRO INSERT CONTROLE_SIGCB_HIST' */
                _.Display($"R2500-ERRO INSERT CONTROLE_SIGCB_HIST");

                /*" -1479- MOVE 'R2500-ERRO INSERT CONTROLE_SIGCB_HIST ' TO LK-GE350-MSG-RETORNO */
                _.Move("R2500-ERRO INSERT CONTROLE_SIGCB_HIST ", REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                /*" -1480- PERFORM R8888-00-DISPLAY-ERRO */

                R8888_00_DISPLAY_ERRO_SECTION();

                /*" -1481- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1482- END-IF */
            }


            /*" -1482- . */

        }

        [StopWatch]
        /*" R2500-INSERE-CONTROLE-HIST-DB-INSERT-1 */
        public void R2500_INSERE_CONTROLE_HIST_DB_INSERT_1()
        {
            /*" -1473- EXEC SQL INSERT INTO SEGUROS.GE_CONTROLE_SIGCB_HIST VALUES ( :GE403-NUM-PROPOSTA , :GE403-NUM-CERTIFICADO , :GE403-NUM-PARCELA , :GE403-NUM-APOLICE , :GE403-NUM-ENDOSSO , :GE403-SEQ-CONTROLE-SIGCB , :WS-SEQ-CONTROLE-HIST , :GE403-COD-SITUACAO , :GE404-COD-REJEICAO :WS-IND-COD-REJEICAO, :GE403-IDE-SISTEMA , :GE403-COD-USUARIO , CURRENT_TIMESTAMP) END-EXEC. */

            var r2500_INSERE_CONTROLE_HIST_DB_INSERT_1_Insert1 = new R2500_INSERE_CONTROLE_HIST_DB_INSERT_1_Insert1()
            {
                GE403_NUM_PROPOSTA = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PROPOSTA.ToString(),
                GE403_NUM_CERTIFICADO = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_CERTIFICADO.ToString(),
                GE403_NUM_PARCELA = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PARCELA.ToString(),
                GE403_NUM_APOLICE = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_APOLICE.ToString(),
                GE403_NUM_ENDOSSO = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_ENDOSSO.ToString(),
                GE403_SEQ_CONTROLE_SIGCB = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_SEQ_CONTROLE_SIGCB.ToString(),
                WS_SEQ_CONTROLE_HIST = WS_SEQ_CONTROLE_HIST.ToString(),
                GE403_COD_SITUACAO = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_SITUACAO.ToString(),
                GE404_COD_REJEICAO = GE404.DCLGE_CONTROLE_SIGCB_HIST.GE404_COD_REJEICAO.ToString(),
                WS_IND_COD_REJEICAO = WS_IND_COD_REJEICAO.ToString(),
                GE403_IDE_SISTEMA = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_IDE_SISTEMA.ToString(),
                GE403_COD_USUARIO = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_USUARIO.ToString(),
            };

            R2500_INSERE_CONTROLE_HIST_DB_INSERT_1_Insert1.Execute(r2500_INSERE_CONTROLE_HIST_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R2510-MAX-SEQ-CONTROLE-SIGCB-SECTION */
        private void R2510_MAX_SEQ_CONTROLE_SIGCB_SECTION()
        {
            /*" -1489- MOVE LK-GE350-NUM-PROPOSTA TO GE403-NUM-PROPOSTA */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PROPOSTA, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PROPOSTA);

            /*" -1490- MOVE LK-GE350-NUM-CERTIFICADO TO GE403-NUM-CERTIFICADO */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_CERTIFICADO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_CERTIFICADO);

            /*" -1491- MOVE LK-GE350-NUM-PARCELA TO GE403-NUM-PARCELA */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PARCELA);

            /*" -1492- MOVE LK-GE350-NUM-APOLICE TO GE403-NUM-APOLICE */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_APOLICE);

            /*" -1493- MOVE LK-GE350-NUM-ENDOSSO TO GE403-NUM-ENDOSSO */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_ENDOSSO);

            /*" -1495- MOVE LK-GE350-SEQ-CNTRLE-SIGCB TO GE403-SEQ-CONTROLE-SIGCB */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_SEQ_CNTRLE_SIGCB, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_SEQ_CONTROLE_SIGCB);

            /*" -1497- INITIALIZE WS-SEQ-CONTROLE-HIST */
            _.Initialize(
                WS_SEQ_CONTROLE_HIST
            );

            /*" -1508- PERFORM R2510_MAX_SEQ_CONTROLE_SIGCB_DB_SELECT_1 */

            R2510_MAX_SEQ_CONTROLE_SIGCB_DB_SELECT_1();

            /*" -1511- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -1512- DISPLAY 'R2510-ERRO SELECT MAX CONTROLE SIGCB HIST' */
                _.Display($"R2510-ERRO SELECT MAX CONTROLE SIGCB HIST");

                /*" -1514- MOVE 'R2510-ERRO SELECT MAX CONTROLE SIGCB HIST' TO LK-GE350-MSG-RETORNO */
                _.Move("R2510-ERRO SELECT MAX CONTROLE SIGCB HIST", REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                /*" -1515- PERFORM R8888-00-DISPLAY-ERRO */

                R8888_00_DISPLAY_ERRO_SECTION();

                /*" -1516- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1517- END-IF */
            }


            /*" -1517- . */

        }

        [StopWatch]
        /*" R2510-MAX-SEQ-CONTROLE-SIGCB-DB-SELECT-1 */
        public void R2510_MAX_SEQ_CONTROLE_SIGCB_DB_SELECT_1()
        {
            /*" -1508- EXEC SQL SELECT VALUE(MAX(SEQ_CONTROLE_SIGCB_HIST), 0) + 1 INTO :WS-SEQ-CONTROLE-HIST FROM SEGUROS.GE_CONTROLE_SIGCB_HIST WHERE NUM_PROPOSTA = :GE403-NUM-PROPOSTA AND NUM_CERTIFICADO = :GE403-NUM-CERTIFICADO AND NUM_PARCELA = :GE403-NUM-PARCELA AND NUM_APOLICE = :GE403-NUM-APOLICE AND NUM_ENDOSSO = :GE403-NUM-ENDOSSO AND SEQ_CONTROLE_SIGCB = :GE403-SEQ-CONTROLE-SIGCB WITH UR END-EXEC. */

            var r2510_MAX_SEQ_CONTROLE_SIGCB_DB_SELECT_1_Query1 = new R2510_MAX_SEQ_CONTROLE_SIGCB_DB_SELECT_1_Query1()
            {
                GE403_SEQ_CONTROLE_SIGCB = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_SEQ_CONTROLE_SIGCB.ToString(),
                GE403_NUM_CERTIFICADO = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_CERTIFICADO.ToString(),
                GE403_NUM_PROPOSTA = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PROPOSTA.ToString(),
                GE403_NUM_PARCELA = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PARCELA.ToString(),
                GE403_NUM_APOLICE = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_APOLICE.ToString(),
                GE403_NUM_ENDOSSO = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = R2510_MAX_SEQ_CONTROLE_SIGCB_DB_SELECT_1_Query1.Execute(r2510_MAX_SEQ_CONTROLE_SIGCB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_SEQ_CONTROLE_HIST, WS_SEQ_CONTROLE_HIST);
            }


        }

        [StopWatch]
        /*" R3000-UPDATE-SIT-CNTRLE-SIGCB-SECTION */
        private void R3000_UPDATE_SIT_CNTRLE_SIGCB_SECTION()
        {
            /*" -1524- MOVE LK-GE350-NUM-PROPOSTA TO GE403-NUM-PROPOSTA */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PROPOSTA, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PROPOSTA);

            /*" -1525- MOVE LK-GE350-NUM-CERTIFICADO TO GE403-NUM-CERTIFICADO */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_CERTIFICADO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_CERTIFICADO);

            /*" -1526- MOVE LK-GE350-NUM-PARCELA TO GE403-NUM-PARCELA */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PARCELA);

            /*" -1527- MOVE LK-GE350-NUM-APOLICE TO GE403-NUM-APOLICE */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_APOLICE);

            /*" -1528- MOVE LK-GE350-NUM-ENDOSSO TO GE403-NUM-ENDOSSO */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_ENDOSSO);

            /*" -1529- MOVE LK-GE350-SEQ-CNTRLE-SIGCB TO GE403-SEQ-CONTROLE-SIGCB */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_SEQ_CNTRLE_SIGCB, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_SEQ_CONTROLE_SIGCB);

            /*" -1530- MOVE LK-GE350-COD-SITUACAO TO GE403-COD-SITUACAO */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_SITUACAO);

            /*" -1532- MOVE LK-GE350-COD-USUARIO TO GE403-COD-USUARIO */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_USUARIO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_USUARIO);

            /*" -1543- PERFORM R3000_UPDATE_SIT_CNTRLE_SIGCB_DB_UPDATE_1 */

            R3000_UPDATE_SIT_CNTRLE_SIGCB_DB_UPDATE_1();

            /*" -1546- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -1547- DISPLAY 'R3000-ERRO UPDATE SIT CNTRLE_EMISSAO_SIGCB' */
                _.Display($"R3000-ERRO UPDATE SIT CNTRLE_EMISSAO_SIGCB");

                /*" -1549- MOVE 'R3000-ERRO UPDATE SIT CNTRLE_EMISSAO_SIGCB' TO LK-GE350-MSG-RETORNO */
                _.Move("R3000-ERRO UPDATE SIT CNTRLE_EMISSAO_SIGCB", REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                /*" -1550- PERFORM R8888-00-DISPLAY-ERRO */

                R8888_00_DISPLAY_ERRO_SECTION();

                /*" -1551- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1553- END-IF. */
            }


            /*" -1554- IF (SQLCODE EQUAL +100) */

            if ((DB.SQLCODE == +100))
            {

                /*" -1555- DISPLAY 'R3000-CNTRLE_EMISSAO NN NAO ENCONTRADO ' */
                _.Display($"R3000-CNTRLE_EMISSAO NN NAO ENCONTRADO ");

                /*" -1556- MOVE '1' TO LK-GE350-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO);

                /*" -1558- MOVE 'R3000-CONTROLE NN NAO ENCONTRADO ' TO LK-GE350-MSG-RETORNO */
                _.Move("R3000-CONTROLE NN NAO ENCONTRADO ", REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                /*" -1559- GO TO RXXXX-ROTINA-RETORNO */

                RXXXX_ROTINA_RETORNO_SECTION(); //GOTO
                return;

                /*" -1560- END-IF */
            }


            /*" -1560- . */

        }

        [StopWatch]
        /*" R3000-UPDATE-SIT-CNTRLE-SIGCB-DB-UPDATE-1 */
        public void R3000_UPDATE_SIT_CNTRLE_SIGCB_DB_UPDATE_1()
        {
            /*" -1543- EXEC SQL UPDATE SEGUROS.GE_CONTROLE_EMISSAO_SIGCB SET COD_SITUACAO = :GE403-COD-SITUACAO, COD_USUARIO = :GE403-COD-USUARIO , DTH_PROCESSAMENTO = CURRENT_TIMESTAMP WHERE NUM_PROPOSTA = :GE403-NUM-PROPOSTA AND NUM_CERTIFICADO = :GE403-NUM-CERTIFICADO AND NUM_PARCELA = :GE403-NUM-PARCELA AND NUM_APOLICE = :GE403-NUM-APOLICE AND NUM_ENDOSSO = :GE403-NUM-ENDOSSO AND SEQ_CONTROLE_SIGCB = :GE403-SEQ-CONTROLE-SIGCB END-EXEC. */

            var r3000_UPDATE_SIT_CNTRLE_SIGCB_DB_UPDATE_1_Update1 = new R3000_UPDATE_SIT_CNTRLE_SIGCB_DB_UPDATE_1_Update1()
            {
                GE403_COD_SITUACAO = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_SITUACAO.ToString(),
                GE403_COD_USUARIO = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_USUARIO.ToString(),
                GE403_SEQ_CONTROLE_SIGCB = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_SEQ_CONTROLE_SIGCB.ToString(),
                GE403_NUM_CERTIFICADO = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_CERTIFICADO.ToString(),
                GE403_NUM_PROPOSTA = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PROPOSTA.ToString(),
                GE403_NUM_PARCELA = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PARCELA.ToString(),
                GE403_NUM_APOLICE = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_APOLICE.ToString(),
                GE403_NUM_ENDOSSO = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_ENDOSSO.ToString(),
            };

            R3000_UPDATE_SIT_CNTRLE_SIGCB_DB_UPDATE_1_Update1.Execute(r3000_UPDATE_SIT_CNTRLE_SIGCB_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R3500-UPDATE-SIT-AGUARDA-SAP-SECTION */
        private void R3500_UPDATE_SIT_AGUARDA_SAP_SECTION()
        {
            /*" -1567- MOVE LK-GE350-NUM-PROPOSTA TO GE403-NUM-PROPOSTA */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PROPOSTA, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PROPOSTA);

            /*" -1568- MOVE LK-GE350-NUM-CERTIFICADO TO GE403-NUM-CERTIFICADO */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_CERTIFICADO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_CERTIFICADO);

            /*" -1569- MOVE LK-GE350-NUM-PARCELA TO GE403-NUM-PARCELA */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PARCELA);

            /*" -1570- MOVE LK-GE350-NUM-APOLICE TO GE403-NUM-APOLICE */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_APOLICE);

            /*" -1571- MOVE LK-GE350-NUM-ENDOSSO TO GE403-NUM-ENDOSSO */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_ENDOSSO);

            /*" -1573- MOVE LK-GE350-SEQ-CNTRLE-SIGCB TO GE403-SEQ-CONTROLE-SIGCB */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_SEQ_CNTRLE_SIGCB, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_SEQ_CONTROLE_SIGCB);

            /*" -1574- MOVE LK-GE350-COD-SITUACAO TO GE403-COD-SITUACAO */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_SITUACAO);

            /*" -1575- MOVE LK-GE350-COD-USUARIO TO GE403-COD-USUARIO */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_USUARIO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_USUARIO);

            /*" -1576- IF WS-IND-NUM-OCORR-MOVTO = 0 */

            if (WS_IND_NUM_OCORR_MOVTO == 0)
            {

                /*" -1577- MOVE LK-GE350-NUM-OCORR-MOVTO TO GE403-NUM-OCORR-MOVTO */
                _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_OCORR_MOVTO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_OCORR_MOVTO);

                /*" -1578- ELSE */
            }
            else
            {


                /*" -1579- INITIALIZE GE403-NUM-OCORR-MOVTO */
                _.Initialize(
                    GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_OCORR_MOVTO
                );

                /*" -1580- END-IF */
            }


            /*" -1581- IF WS-IND-NUM-IDLG = 0 */

            if (WS_IND_NUM_IDLG == 0)
            {

                /*" -1582- MOVE LK-GE350-NUM-IDLG TO GE403-NUM-IDLG */
                _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_IDLG, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_IDLG);

                /*" -1583- ELSE */
            }
            else
            {


                /*" -1584- INITIALIZE GE403-NUM-IDLG */
                _.Initialize(
                    GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_IDLG
                );

                /*" -1586- END-IF */
            }


            /*" -1601- PERFORM R3500_UPDATE_SIT_AGUARDA_SAP_DB_UPDATE_1 */

            R3500_UPDATE_SIT_AGUARDA_SAP_DB_UPDATE_1();

            /*" -1604- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -1605- DISPLAY 'R3500-ERRO UPDATE SIT AGUARD EMISSAO_SIGCB' */
                _.Display($"R3500-ERRO UPDATE SIT AGUARD EMISSAO_SIGCB");

                /*" -1607- MOVE 'R3500-ERRO UPDATE SIT CNTRLE_EMISSAO_SIGCB' TO LK-GE350-MSG-RETORNO */
                _.Move("R3500-ERRO UPDATE SIT CNTRLE_EMISSAO_SIGCB", REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                /*" -1608- PERFORM R8888-00-DISPLAY-ERRO */

                R8888_00_DISPLAY_ERRO_SECTION();

                /*" -1609- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1611- END-IF. */
            }


            /*" -1612- IF (SQLCODE EQUAL +100) */

            if ((DB.SQLCODE == +100))
            {

                /*" -1613- DISPLAY 'R3500-CNTRLE_EMISSAO NN NAO ENCONTRADO ' */
                _.Display($"R3500-CNTRLE_EMISSAO NN NAO ENCONTRADO ");

                /*" -1614- MOVE '1' TO LK-GE350-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO);

                /*" -1616- MOVE 'R3500-CONTROLE NN NAO ENCONTRADO ' TO LK-GE350-MSG-RETORNO */
                _.Move("R3500-CONTROLE NN NAO ENCONTRADO ", REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                /*" -1617- GO TO RXXXX-ROTINA-RETORNO */

                RXXXX_ROTINA_RETORNO_SECTION(); //GOTO
                return;

                /*" -1618- END-IF */
            }


            /*" -1618- . */

        }

        [StopWatch]
        /*" R3500-UPDATE-SIT-AGUARDA-SAP-DB-UPDATE-1 */
        public void R3500_UPDATE_SIT_AGUARDA_SAP_DB_UPDATE_1()
        {
            /*" -1601- EXEC SQL UPDATE SEGUROS.GE_CONTROLE_EMISSAO_SIGCB SET COD_SITUACAO = :GE403-COD-SITUACAO , COD_USUARIO = :GE403-COD-USUARIO , NUM_OCORR_MOVTO = :GE403-NUM-OCORR-MOVTO:WS-IND-NUM-OCORR-MOVTO, NUM_IDLG = :GE403-NUM-IDLG :WS-IND-NUM-IDLG , DTH_PROCESSAMENTO = CURRENT_TIMESTAMP WHERE NUM_PROPOSTA = :GE403-NUM-PROPOSTA AND NUM_CERTIFICADO = :GE403-NUM-CERTIFICADO AND NUM_PARCELA = :GE403-NUM-PARCELA AND NUM_APOLICE = :GE403-NUM-APOLICE AND NUM_ENDOSSO = :GE403-NUM-ENDOSSO AND SEQ_CONTROLE_SIGCB = :GE403-SEQ-CONTROLE-SIGCB END-EXEC. */

            var r3500_UPDATE_SIT_AGUARDA_SAP_DB_UPDATE_1_Update1 = new R3500_UPDATE_SIT_AGUARDA_SAP_DB_UPDATE_1_Update1()
            {
                GE403_NUM_OCORR_MOVTO = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_OCORR_MOVTO.ToString(),
                WS_IND_NUM_OCORR_MOVTO = WS_IND_NUM_OCORR_MOVTO.ToString(),
                GE403_NUM_IDLG = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_IDLG.ToString(),
                WS_IND_NUM_IDLG = WS_IND_NUM_IDLG.ToString(),
                GE403_COD_SITUACAO = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_SITUACAO.ToString(),
                GE403_COD_USUARIO = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_USUARIO.ToString(),
                GE403_SEQ_CONTROLE_SIGCB = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_SEQ_CONTROLE_SIGCB.ToString(),
                GE403_NUM_CERTIFICADO = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_CERTIFICADO.ToString(),
                GE403_NUM_PROPOSTA = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PROPOSTA.ToString(),
                GE403_NUM_PARCELA = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PARCELA.ToString(),
                GE403_NUM_APOLICE = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_APOLICE.ToString(),
                GE403_NUM_ENDOSSO = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_ENDOSSO.ToString(),
            };

            R3500_UPDATE_SIT_AGUARDA_SAP_DB_UPDATE_1_Update1.Execute(r3500_UPDATE_SIT_AGUARDA_SAP_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R4000-INSERE-CONTROLE-NN-SAP-SECTION */
        private void R4000_INSERE_CONTROLE_NN_SAP_SECTION()
        {
            /*" -1625- MOVE ZEROS TO WS-IND-NN-SAP */
            _.Move(0, WS_IND_NN_SAP);

            /*" -1626- MOVE ZEROS TO WS-IND-COD-CEDENTE */
            _.Move(0, WS_IND_COD_CEDENTE);

            /*" -1627- MOVE ZEROS TO WS-IND-BOL-INT */
            _.Move(0, WS_IND_BOL_INT);

            /*" -1628- MOVE ZEROS TO WS-IND-COD-LIN-DIG */
            _.Move(0, WS_IND_COD_LIN_DIG);

            /*" -1629- MOVE ZEROS TO WS-IND-NUM-OCORR-MOVTO */
            _.Move(0, WS_IND_NUM_OCORR_MOVTO);

            /*" -1630- MOVE ZEROS TO WS-IND-NUM-TITULO */
            _.Move(0, WS_IND_NUM_TITULO);

            /*" -1631- MOVE ZEROS TO WS-IND-NUM-IDLG */
            _.Move(0, WS_IND_NUM_IDLG);

            /*" -1632- MOVE ZEROS TO WS-IND-COD-REJEICAO */
            _.Move(0, WS_IND_COD_REJEICAO);

            /*" -1634- MOVE ZEROS TO WS-IND-NUM-OCORR-MOVTO */
            _.Move(0, WS_IND_NUM_OCORR_MOVTO);

            /*" -1635- IF (LK-GE350-NUM-OCORR-MOVTO EQUAL ZEROS) */

            if ((REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_OCORR_MOVTO == 00))
            {

                /*" -1636- MOVE -1 TO WS-IND-NUM-OCORR-MOVTO */
                _.Move(-1, WS_IND_NUM_OCORR_MOVTO);

                /*" -1638- END-IF */
            }


            /*" -1640- IF (LK-GE350-NOSSO-NUMERO-SAP IS NOT NUMERIC) OR (LK-GE350-NOSSO-NUMERO-SAP EQUAL ZEROS) */

            if ((!REGISTRO_LINKAGE_GE0350S.LK_GE350_NOSSO_NUMERO_SAP.IsNumeric()) || (REGISTRO_LINKAGE_GE0350S.LK_GE350_NOSSO_NUMERO_SAP == 00))
            {

                /*" -1641- MOVE -1 TO WS-IND-NN-SAP */
                _.Move(-1, WS_IND_NN_SAP);

                /*" -1643- END-IF */
            }


            /*" -1644- IF (LK-GE350-NUM-TITULO EQUAL ZEROS) */

            if ((REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_TITULO == 00))
            {

                /*" -1645- MOVE -1 TO WS-IND-NUM-TITULO */
                _.Move(-1, WS_IND_NUM_TITULO);

                /*" -1647- END-IF */
            }


            /*" -1648- IF (LK-GE350-COD-CEDENTE-SAP EQUAL SPACES) */

            if ((REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_CEDENTE_SAP.IsEmpty()))
            {

                /*" -1649- MOVE -1 TO WS-IND-COD-CEDENTE */
                _.Move(-1, WS_IND_COD_CEDENTE);

                /*" -1651- END-IF */
            }


            /*" -1652- IF (LK-GE350-NUM-BLTO-INTERNO EQUAL ZEROS) */

            if ((REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_BLTO_INTERNO == 00))
            {

                /*" -1653- MOVE -1 TO WS-IND-BOL-INT */
                _.Move(-1, WS_IND_BOL_INT);

                /*" -1655- END-IF */
            }


            /*" -1656- IF (LK-GE350-COD-LINHA-DGTVEL EQUAL SPACES) */

            if ((REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_LINHA_DGTVEL.IsEmpty()))
            {

                /*" -1657- MOVE -1 TO WS-IND-COD-LIN-DIG */
                _.Move(-1, WS_IND_COD_LIN_DIG);

                /*" -1659- END-IF */
            }


            /*" -1660- IF (LK-GE350-NUM-IDLG EQUAL SPACES) */

            if ((REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_IDLG.IsEmpty()))
            {

                /*" -1661- MOVE -1 TO WS-IND-NUM-IDLG */
                _.Move(-1, WS_IND_NUM_IDLG);

                /*" -1663- END-IF */
            }


            /*" -1664- IF (LK-GE350-COD-REJEICAO EQUAL SPACES) */

            if ((REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_REJEICAO.IsEmpty()))
            {

                /*" -1665- MOVE -1 TO WS-IND-COD-REJEICAO */
                _.Move(-1, WS_IND_COD_REJEICAO);

                /*" -1667- END-IF */
            }


            /*" -1668- PERFORM R4500-UPDATE-NN-REGISTRADO */

            R4500_UPDATE_NN_REGISTRADO_SECTION();

            /*" -1669- PERFORM R2500-INSERE-CONTROLE-HIST */

            R2500_INSERE_CONTROLE_HIST_SECTION();

            /*" -1669- . */

        }

        [StopWatch]
        /*" R4500-UPDATE-NN-REGISTRADO-SECTION */
        private void R4500_UPDATE_NN_REGISTRADO_SECTION()
        {
            /*" -1676- MOVE LK-GE350-NUM-PROPOSTA TO GE403-NUM-PROPOSTA */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PROPOSTA, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PROPOSTA);

            /*" -1677- MOVE LK-GE350-NUM-CERTIFICADO TO GE403-NUM-CERTIFICADO */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_CERTIFICADO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_CERTIFICADO);

            /*" -1678- MOVE LK-GE350-NUM-PARCELA TO GE403-NUM-PARCELA */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PARCELA);

            /*" -1679- MOVE LK-GE350-NUM-APOLICE TO GE403-NUM-APOLICE */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_APOLICE);

            /*" -1680- MOVE LK-GE350-NUM-ENDOSSO TO GE403-NUM-ENDOSSO */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_ENDOSSO);

            /*" -1682- MOVE LK-GE350-SEQ-CNTRLE-SIGCB TO GE403-SEQ-CONTROLE-SIGCB */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_SEQ_CNTRLE_SIGCB, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_SEQ_CONTROLE_SIGCB);

            /*" -1683- IF WS-IND-NUM-OCORR-MOVTO = 0 */

            if (WS_IND_NUM_OCORR_MOVTO == 0)
            {

                /*" -1684- MOVE LK-GE350-NUM-OCORR-MOVTO TO GE403-NUM-OCORR-MOVTO */
                _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_OCORR_MOVTO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_OCORR_MOVTO);

                /*" -1685- ELSE */
            }
            else
            {


                /*" -1686- INITIALIZE GE403-NUM-OCORR-MOVTO */
                _.Initialize(
                    GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_OCORR_MOVTO
                );

                /*" -1687- END-IF */
            }


            /*" -1688- IF WS-IND-NUM-IDLG = 0 */

            if (WS_IND_NUM_IDLG == 0)
            {

                /*" -1689- MOVE LK-GE350-NUM-IDLG TO GE403-NUM-IDLG */
                _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_IDLG, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_IDLG);

                /*" -1690- ELSE */
            }
            else
            {


                /*" -1691- INITIALIZE GE403-NUM-IDLG */
                _.Initialize(
                    GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_IDLG
                );

                /*" -1692- END-IF */
            }


            /*" -1693- IF WS-IND-COD-CEDENTE = 0 */

            if (WS_IND_COD_CEDENTE == 0)
            {

                /*" -1694- MOVE LK-GE350-COD-CEDENTE-SAP TO GE403-COD-CEDENTE-SAP */
                _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_CEDENTE_SAP, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_CEDENTE_SAP);

                /*" -1695- ELSE */
            }
            else
            {


                /*" -1696- INITIALIZE GE403-COD-CEDENTE-SAP */
                _.Initialize(
                    GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_CEDENTE_SAP
                );

                /*" -1697- END-IF */
            }


            /*" -1698- IF WS-IND-BOL-INT = 0 */

            if (WS_IND_BOL_INT == 0)
            {

                /*" -1699- MOVE LK-GE350-NUM-BLTO-INTERNO TO GE403-NUM-BOLETO-INTERNO */
                _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_BLTO_INTERNO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_BOLETO_INTERNO);

                /*" -1700- ELSE */
            }
            else
            {


                /*" -1701- INITIALIZE GE403-NUM-BOLETO-INTERNO */
                _.Initialize(
                    GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_BOLETO_INTERNO
                );

                /*" -1702- END-IF */
            }


            /*" -1703- IF WS-IND-NN-SAP = 0 */

            if (WS_IND_NN_SAP == 0)
            {

                /*" -1705- MOVE LK-GE350-NOSSO-NUMERO-SAP TO GE403-NUM-NOSSO-NUMERO-SAP */
                _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NOSSO_NUMERO_SAP, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_NOSSO_NUMERO_SAP);

                /*" -1706- ELSE */
            }
            else
            {


                /*" -1707- INITIALIZE GE403-NUM-NOSSO-NUMERO-SAP */
                _.Initialize(
                    GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_NOSSO_NUMERO_SAP
                );

                /*" -1708- END-IF */
            }


            /*" -1709- IF WS-IND-COD-LIN-DIG = 0 */

            if (WS_IND_COD_LIN_DIG == 0)
            {

                /*" -1711- MOVE LK-GE350-COD-LINHA-DGTVEL TO GE403-COD-LINHA-DIGITAVEL */
                _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_LINHA_DGTVEL, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_LINHA_DIGITAVEL);

                /*" -1712- ELSE */
            }
            else
            {


                /*" -1713- INITIALIZE GE403-COD-LINHA-DIGITAVEL */
                _.Initialize(
                    GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_LINHA_DIGITAVEL
                );

                /*" -1714- END-IF */
            }


            /*" -1715- IF WS-IND-NUM-TITULO = 0 */

            if (WS_IND_NUM_TITULO == 0)
            {

                /*" -1716- MOVE LK-GE350-NUM-TITULO TO GE403-NUM-TITULO */
                _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_TITULO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_TITULO);

                /*" -1717- ELSE */
            }
            else
            {


                /*" -1718- INITIALIZE GE403-NUM-TITULO */
                _.Initialize(
                    GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_TITULO
                );

                /*" -1719- END-IF */
            }


            /*" -1720- MOVE LK-GE350-COD-USUARIO TO GE403-COD-USUARIO */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_USUARIO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_USUARIO);

            /*" -1722- MOVE LK-GE350-COD-SITUACAO TO GE403-COD-SITUACAO */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_SITUACAO);

            /*" -1747- PERFORM R4500_UPDATE_NN_REGISTRADO_DB_UPDATE_1 */

            R4500_UPDATE_NN_REGISTRADO_DB_UPDATE_1();

            /*" -1750- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -1751- DISPLAY 'R4500-ERRO UPDATE NN REGISTRADO NO CONTROLE' */
                _.Display($"R4500-ERRO UPDATE NN REGISTRADO NO CONTROLE");

                /*" -1752- DISPLAY '1 => ' GE403-NUM-OCORR-MOVTO */
                _.Display($"1 => {GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_OCORR_MOVTO}");

                /*" -1753- DISPLAY '2 => ' GE403-NUM-IDLG */
                _.Display($"2 => {GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_IDLG}");

                /*" -1754- DISPLAY '3 => ' GE403-COD-CEDENTE-SAP */
                _.Display($"3 => {GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_CEDENTE_SAP}");

                /*" -1755- DISPLAY '4 => ' GE403-NUM-BOLETO-INTERNO */
                _.Display($"4 => {GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_BOLETO_INTERNO}");

                /*" -1756- DISPLAY '5 => ' GE403-NUM-NOSSO-NUMERO-SAP */
                _.Display($"5 => {GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_NOSSO_NUMERO_SAP}");

                /*" -1757- DISPLAY '6 => ' GE403-COD-LINHA-DIGITAVEL */
                _.Display($"6 => {GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_LINHA_DIGITAVEL}");

                /*" -1758- DISPLAY '7 => ' GE403-NUM-TITULO */
                _.Display($"7 => {GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_TITULO}");

                /*" -1759- DISPLAY '8 => ' GE403-COD-SITUACAO */
                _.Display($"8 => {GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_SITUACAO}");

                /*" -1760- DISPLAY '9 => ' GE403-IDE-SISTEMA */
                _.Display($"9 => {GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_IDE_SISTEMA}");

                /*" -1761- DISPLAY '0 => ' GE403-COD-USUARIO */
                _.Display($"0 => {GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_USUARIO}");

                /*" -1763- MOVE 'R4500-ERRO UPDATE NN REGISTRADO NO CONTROLE ' TO LK-GE350-MSG-RETORNO */
                _.Move("R4500-ERRO UPDATE NN REGISTRADO NO CONTROLE ", REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                /*" -1764- PERFORM R8888-00-DISPLAY-ERRO */

                R8888_00_DISPLAY_ERRO_SECTION();

                /*" -1765- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1767- END-IF. */
            }


            /*" -1768- IF (SQLCODE EQUAL +100) */

            if ((DB.SQLCODE == +100))
            {

                /*" -1769- DISPLAY 'R4500-CONTROLE NN NAO ENCONTRADO ' */
                _.Display($"R4500-CONTROLE NN NAO ENCONTRADO ");

                /*" -1770- DISPLAY 'NUM_PROPOSTA       ' GE403-NUM-PROPOSTA */
                _.Display($"NUM_PROPOSTA       {GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PROPOSTA}");

                /*" -1771- DISPLAY 'NUM_CERTIFICADO    ' GE403-NUM-CERTIFICADO */
                _.Display($"NUM_CERTIFICADO    {GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_CERTIFICADO}");

                /*" -1772- DISPLAY 'NUM_PARCELA        ' GE403-NUM-PARCELA */
                _.Display($"NUM_PARCELA        {GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PARCELA}");

                /*" -1773- DISPLAY 'NUM_APOLICE        ' GE403-NUM-APOLICE */
                _.Display($"NUM_APOLICE        {GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_APOLICE}");

                /*" -1774- DISPLAY 'NUM_ENDOSSO        ' GE403-NUM-ENDOSSO */
                _.Display($"NUM_ENDOSSO        {GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_ENDOSSO}");

                /*" -1775- DISPLAY 'SEQ_CONTROLE_SIGCB ' GE403-SEQ-CONTROLE-SIGCB */
                _.Display($"SEQ_CONTROLE_SIGCB {GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_SEQ_CONTROLE_SIGCB}");

                /*" -1776- MOVE '1' TO LK-GE350-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO);

                /*" -1778- MOVE 'R4500-CONTROLE NN NAO ENCONTRADO ' TO LK-GE350-MSG-RETORNO */
                _.Move("R4500-CONTROLE NN NAO ENCONTRADO ", REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                /*" -1779- GO TO RXXXX-ROTINA-RETORNO */

                RXXXX_ROTINA_RETORNO_SECTION(); //GOTO
                return;

                /*" -1780- END-IF */
            }


            /*" -1780- . */

        }

        [StopWatch]
        /*" R4500-UPDATE-NN-REGISTRADO-DB-UPDATE-1 */
        public void R4500_UPDATE_NN_REGISTRADO_DB_UPDATE_1()
        {
            /*" -1747- EXEC SQL UPDATE SEGUROS.GE_CONTROLE_EMISSAO_SIGCB SET NUM_OCORR_MOVTO = :GE403-NUM-OCORR-MOVTO:WS-IND-NUM-OCORR-MOVTO, NUM_IDLG = :GE403-NUM-IDLG :WS-IND-NUM-IDLG , COD_CEDENTE_SAP = :GE403-COD-CEDENTE-SAP :WS-IND-COD-CEDENTE , NUM_BOLETO_INTERNO = :GE403-NUM-BOLETO-INTERNO:WS-IND-BOL-INT , NUM_NOSSO_NUMERO_SAP = :GE403-NUM-NOSSO-NUMERO-SAP:WS-IND-NN-SAP , COD_LINHA_DIGITAVEL = :GE403-COD-LINHA-DIGITAVEL:WS-IND-COD-LIN-DIG , NUM_TITULO = :GE403-NUM-TITULO :WS-IND-NUM-TITULO , COD_SITUACAO = :GE403-COD-SITUACAO, COD_USUARIO = :GE403-COD-USUARIO , DTH_PROCESSAMENTO = CURRENT_TIMESTAMP WHERE NUM_PROPOSTA = :GE403-NUM-PROPOSTA AND NUM_CERTIFICADO = :GE403-NUM-CERTIFICADO AND NUM_PARCELA = :GE403-NUM-PARCELA AND NUM_APOLICE = :GE403-NUM-APOLICE AND NUM_ENDOSSO = :GE403-NUM-ENDOSSO AND SEQ_CONTROLE_SIGCB = :GE403-SEQ-CONTROLE-SIGCB END-EXEC. */

            var r4500_UPDATE_NN_REGISTRADO_DB_UPDATE_1_Update1 = new R4500_UPDATE_NN_REGISTRADO_DB_UPDATE_1_Update1()
            {
                GE403_NUM_OCORR_MOVTO = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_OCORR_MOVTO.ToString(),
                WS_IND_NUM_OCORR_MOVTO = WS_IND_NUM_OCORR_MOVTO.ToString(),
                GE403_COD_LINHA_DIGITAVEL = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_LINHA_DIGITAVEL.ToString(),
                WS_IND_COD_LIN_DIG = WS_IND_COD_LIN_DIG.ToString(),
                GE403_COD_CEDENTE_SAP = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_CEDENTE_SAP.ToString(),
                WS_IND_COD_CEDENTE = WS_IND_COD_CEDENTE.ToString(),
                GE403_NUM_NOSSO_NUMERO_SAP = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_NOSSO_NUMERO_SAP.ToString(),
                WS_IND_NN_SAP = WS_IND_NN_SAP.ToString(),
                GE403_NUM_BOLETO_INTERNO = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_BOLETO_INTERNO.ToString(),
                WS_IND_BOL_INT = WS_IND_BOL_INT.ToString(),
                GE403_NUM_TITULO = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_TITULO.ToString(),
                WS_IND_NUM_TITULO = WS_IND_NUM_TITULO.ToString(),
                GE403_NUM_IDLG = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_IDLG.ToString(),
                WS_IND_NUM_IDLG = WS_IND_NUM_IDLG.ToString(),
                GE403_COD_SITUACAO = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_SITUACAO.ToString(),
                GE403_COD_USUARIO = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_USUARIO.ToString(),
                GE403_SEQ_CONTROLE_SIGCB = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_SEQ_CONTROLE_SIGCB.ToString(),
                GE403_NUM_CERTIFICADO = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_CERTIFICADO.ToString(),
                GE403_NUM_PROPOSTA = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PROPOSTA.ToString(),
                GE403_NUM_PARCELA = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PARCELA.ToString(),
                GE403_NUM_APOLICE = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_APOLICE.ToString(),
                GE403_NUM_ENDOSSO = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_ENDOSSO.ToString(),
            };

            R4500_UPDATE_NN_REGISTRADO_DB_UPDATE_1_Update1.Execute(r4500_UPDATE_NN_REGISTRADO_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R4900-VALIDA-UPDATE-NN-SAP-SECTION */
        private void R4900_VALIDA_UPDATE_NN_SAP_SECTION()
        {
            /*" -1788- MOVE ZEROS TO WS-IND-NUM-TITULO */
            _.Move(0, WS_IND_NUM_TITULO);

            /*" -1789- IF (LK-GE350-NUM-TITULO EQUAL ZEROS) */

            if ((REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_TITULO == 00))
            {

                /*" -1790- MOVE -1 TO WS-IND-NUM-TITULO */
                _.Move(-1, WS_IND_NUM_TITULO);

                /*" -1792- END-IF */
            }


            /*" -1793- PERFORM R4910-UPDATE-NN-SAP */

            R4910_UPDATE_NN_SAP_SECTION();

            /*" -1794- PERFORM R4920-INSERE-NN-HIST */

            R4920_INSERE_NN_HIST_SECTION();

            /*" -1794- . */

        }

        [StopWatch]
        /*" R4910-UPDATE-NN-SAP-SECTION */
        private void R4910_UPDATE_NN_SAP_SECTION()
        {
            /*" -1801- MOVE LK-GE350-NOSSO-NUMERO-SAP TO GE403-NUM-NOSSO-NUMERO-SAP */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NOSSO_NUMERO_SAP, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_NOSSO_NUMERO_SAP);

            /*" -1803- MOVE LK-GE350-SEQ-CNTRLE-SIGCB TO GE403-SEQ-CONTROLE-SIGCB */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_SEQ_CNTRLE_SIGCB, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_SEQ_CONTROLE_SIGCB);

            /*" -1804- MOVE LK-GE350-NUM-APOLICE TO GE403-NUM-APOLICE */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_APOLICE);

            /*" -1805- MOVE LK-GE350-NUM-ENDOSSO TO GE403-NUM-ENDOSSO */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_ENDOSSO);

            /*" -1806- MOVE LK-GE350-NUM-PARCELA TO GE403-NUM-PARCELA */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PARCELA);

            /*" -1807- IF WS-IND-NUM-TITULO = 0 */

            if (WS_IND_NUM_TITULO == 0)
            {

                /*" -1808- MOVE LK-GE350-NUM-TITULO TO GE403-NUM-TITULO */
                _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_TITULO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_TITULO);

                /*" -1809- ELSE */
            }
            else
            {


                /*" -1810- INITIALIZE GE403-NUM-TITULO */
                _.Initialize(
                    GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_TITULO
                );

                /*" -1812- END-IF */
            }


            /*" -1822- PERFORM R4910_UPDATE_NN_SAP_DB_UPDATE_1 */

            R4910_UPDATE_NN_SAP_DB_UPDATE_1();

            /*" -1825- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -1826- DISPLAY 'R4910-ERRO UPDATE NN SAP ' */
                _.Display($"R4910-ERRO UPDATE NN SAP ");

                /*" -1827- DISPLAY '2 => ' GE403-NUM-NOSSO-NUMERO-SAP */
                _.Display($"2 => {GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_NOSSO_NUMERO_SAP}");

                /*" -1828- DISPLAY '3 => ' GE403-SEQ-CONTROLE-SIGCB */
                _.Display($"3 => {GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_SEQ_CONTROLE_SIGCB}");

                /*" -1829- DISPLAY '5 => ' GE403-NUM-APOLICE */
                _.Display($"5 => {GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_APOLICE}");

                /*" -1830- DISPLAY '7 => ' GE403-NUM-ENDOSSO */
                _.Display($"7 => {GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_ENDOSSO}");

                /*" -1831- DISPLAY '8 => ' GE403-NUM-PARCELA */
                _.Display($"8 => {GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PARCELA}");

                /*" -1832- DISPLAY '9 => ' GE403-NUM-TITULO */
                _.Display($"9 => {GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_TITULO}");

                /*" -1833- DISPLAY '0 => ' GE403-COD-USUARIO */
                _.Display($"0 => {GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_USUARIO}");

                /*" -1835- MOVE 'R4910-ERRO UPDATE NN SAP FIM ' TO LK-GE350-MSG-RETORNO */
                _.Move("R4910-ERRO UPDATE NN SAP FIM ", REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                /*" -1836- PERFORM R8888-00-DISPLAY-ERRO */

                R8888_00_DISPLAY_ERRO_SECTION();

                /*" -1837- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1839- END-IF. */
            }


            /*" -1840- IF (SQLCODE EQUAL +100) */

            if ((DB.SQLCODE == +100))
            {

                /*" -1841- DISPLAY 'R4910-UPDATE NN SAP NAO ENCONTRADO' */
                _.Display($"R4910-UPDATE NN SAP NAO ENCONTRADO");

                /*" -1842- DISPLAY 'NUM_PROPOSTA       ' GE403-NUM-PROPOSTA */
                _.Display($"NUM_PROPOSTA       {GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PROPOSTA}");

                /*" -1843- DISPLAY 'NUM_TITULO         ' GE403-NUM-TITULO */
                _.Display($"NUM_TITULO         {GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_TITULO}");

                /*" -1844- DISPLAY 'NUM_PARCELA        ' GE403-NUM-PARCELA */
                _.Display($"NUM_PARCELA        {GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PARCELA}");

                /*" -1845- DISPLAY 'NUM_APOLICE        ' GE403-NUM-APOLICE */
                _.Display($"NUM_APOLICE        {GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_APOLICE}");

                /*" -1846- DISPLAY 'NUM_ENDOSSO        ' GE403-NUM-ENDOSSO */
                _.Display($"NUM_ENDOSSO        {GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_ENDOSSO}");

                /*" -1847- DISPLAY 'SEQ_CONTROLE_SIGCB ' GE403-SEQ-CONTROLE-SIGCB */
                _.Display($"SEQ_CONTROLE_SIGCB {GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_SEQ_CONTROLE_SIGCB}");

                /*" -1848- DISPLAY 'NOSSO_NUMERO       ' GE403-NUM-NOSSO-NUMERO-SAP */
                _.Display($"NOSSO_NUMERO       {GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_NOSSO_NUMERO_SAP}");

                /*" -1849- MOVE '1' TO LK-GE350-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO);

                /*" -1851- MOVE 'R4910-UPDATE NN SAP NAO ENCONTRADO' TO LK-GE350-MSG-RETORNO */
                _.Move("R4910-UPDATE NN SAP NAO ENCONTRADO", REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                /*" -1852- GO TO RXXXX-ROTINA-RETORNO */

                RXXXX_ROTINA_RETORNO_SECTION(); //GOTO
                return;

                /*" -1853- END-IF */
            }


            /*" -1853- . */

        }

        [StopWatch]
        /*" R4910-UPDATE-NN-SAP-DB-UPDATE-1 */
        public void R4910_UPDATE_NN_SAP_DB_UPDATE_1()
        {
            /*" -1822- EXEC SQL UPDATE SEGUROS.GE_CONTROLE_EMISSAO_SIGCB SET NUM_APOLICE = :GE403-NUM-APOLICE ,NUM_ENDOSSO = :GE403-NUM-ENDOSSO ,NUM_PARCELA = :GE403-NUM-PARCELA ,NUM_TITULO = :GE403-NUM-TITULO :WS-IND-NUM-TITULO ,DTH_PROCESSAMENTO = CURRENT_TIMESTAMP WHERE NUM_NOSSO_NUMERO_SAP =:GE403-NUM-NOSSO-NUMERO-SAP AND SEQ_CONTROLE_SIGCB = :GE403-SEQ-CONTROLE-SIGCB END-EXEC. */

            var r4910_UPDATE_NN_SAP_DB_UPDATE_1_Update1 = new R4910_UPDATE_NN_SAP_DB_UPDATE_1_Update1()
            {
                GE403_NUM_TITULO = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_TITULO.ToString(),
                WS_IND_NUM_TITULO = WS_IND_NUM_TITULO.ToString(),
                GE403_NUM_APOLICE = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_APOLICE.ToString(),
                GE403_NUM_ENDOSSO = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_ENDOSSO.ToString(),
                GE403_NUM_PARCELA = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PARCELA.ToString(),
                GE403_NUM_NOSSO_NUMERO_SAP = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_NOSSO_NUMERO_SAP.ToString(),
                GE403_SEQ_CONTROLE_SIGCB = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_SEQ_CONTROLE_SIGCB.ToString(),
            };

            R4910_UPDATE_NN_SAP_DB_UPDATE_1_Update1.Execute(r4910_UPDATE_NN_SAP_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R4920-INSERE-NN-HIST-SECTION */
        private void R4920_INSERE_NN_HIST_SECTION()
        {
            /*" -1860- MOVE LK-GE350-NUM-PROPOSTA TO GE403-NUM-PROPOSTA */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PROPOSTA, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PROPOSTA);

            /*" -1861- MOVE LK-GE350-NUM-CERTIFICADO TO GE403-NUM-CERTIFICADO */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_CERTIFICADO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_CERTIFICADO);

            /*" -1862- MOVE LK-GE350-NUM-PARCELA TO GE403-NUM-PARCELA */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PARCELA);

            /*" -1863- MOVE LK-GE350-NUM-APOLICE TO GE403-NUM-APOLICE */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_APOLICE);

            /*" -1864- MOVE LK-GE350-NUM-ENDOSSO TO GE403-NUM-ENDOSSO */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_ENDOSSO);

            /*" -1865- MOVE LK-GE350-SEQ-CNTRLE-SIGCB TO GE403-SEQ-CONTROLE-SIGCB */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_SEQ_CNTRLE_SIGCB, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_SEQ_CONTROLE_SIGCB);

            /*" -1866- MOVE LK-GE350-COD-SITUACAO TO GE403-COD-SITUACAO */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_SITUACAO);

            /*" -1867- IF WS-IND-COD-REJEICAO = 0 */

            if (WS_IND_COD_REJEICAO == 0)
            {

                /*" -1868- MOVE LK-GE350-COD-REJEICAO TO GE404-COD-REJEICAO */
                _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_REJEICAO, GE404.DCLGE_CONTROLE_SIGCB_HIST.GE404_COD_REJEICAO);

                /*" -1869- ELSE */
            }
            else
            {


                /*" -1870- INITIALIZE GE404-COD-REJEICAO */
                _.Initialize(
                    GE404.DCLGE_CONTROLE_SIGCB_HIST.GE404_COD_REJEICAO
                );

                /*" -1871- END-IF */
            }


            /*" -1872- MOVE LK-GE350-COD-SISTEMA TO GE403-IDE-SISTEMA */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SISTEMA, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_IDE_SISTEMA);

            /*" -1874- MOVE LK-GE350-COD-USUARIO TO GE403-COD-USUARIO */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_USUARIO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_USUARIO);

            /*" -1876- INITIALIZE WS-SEQ-CONTROLE-HIST */
            _.Initialize(
                WS_SEQ_CONTROLE_HIST
            );

            /*" -1886- PERFORM R4920_INSERE_NN_HIST_DB_SELECT_1 */

            R4920_INSERE_NN_HIST_DB_SELECT_1();

            /*" -1889- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -1890- DISPLAY 'R4920-ERRO SELECT MAX CONTROLE SIGCB HIST' */
                _.Display($"R4920-ERRO SELECT MAX CONTROLE SIGCB HIST");

                /*" -1892- MOVE 'R4920-ERRO SELECT MAX CONTROLE SIGCB HIST' TO LK-GE350-MSG-RETORNO */
                _.Move("R4920-ERRO SELECT MAX CONTROLE SIGCB HIST", REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                /*" -1893- PERFORM R8888-00-DISPLAY-ERRO */

                R8888_00_DISPLAY_ERRO_SECTION();

                /*" -1894- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1896- END-IF. */
            }


            /*" -1911- PERFORM R4920_INSERE_NN_HIST_DB_INSERT_1 */

            R4920_INSERE_NN_HIST_DB_INSERT_1();

            /*" -1914- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1915- DISPLAY 'R4920-ERRO INSERT CONTROLE_SIGCB_HIST' */
                _.Display($"R4920-ERRO INSERT CONTROLE_SIGCB_HIST");

                /*" -1917- MOVE 'R4920-ERRO INSERT CONTROLE_SIGCB_HIST ' TO LK-GE350-MSG-RETORNO */
                _.Move("R4920-ERRO INSERT CONTROLE_SIGCB_HIST ", REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                /*" -1918- PERFORM R8888-00-DISPLAY-ERRO */

                R8888_00_DISPLAY_ERRO_SECTION();

                /*" -1919- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1920- END-IF */
            }


            /*" -1920- . */

        }

        [StopWatch]
        /*" R4920-INSERE-NN-HIST-DB-SELECT-1 */
        public void R4920_INSERE_NN_HIST_DB_SELECT_1()
        {
            /*" -1886- EXEC SQL SELECT VALUE(MAX(SEQ_CONTROLE_SIGCB_HIST), 0) + 1 INTO :WS-SEQ-CONTROLE-HIST FROM SEGUROS.GE_CONTROLE_SIGCB_HIST WHERE NUM_PROPOSTA = :GE403-NUM-PROPOSTA AND NUM_CERTIFICADO = :GE403-NUM-CERTIFICADO AND NUM_PARCELA = :GE403-NUM-PARCELA AND NUM_ENDOSSO = :GE403-NUM-ENDOSSO AND SEQ_CONTROLE_SIGCB = :GE403-SEQ-CONTROLE-SIGCB WITH UR END-EXEC. */

            var r4920_INSERE_NN_HIST_DB_SELECT_1_Query1 = new R4920_INSERE_NN_HIST_DB_SELECT_1_Query1()
            {
                GE403_SEQ_CONTROLE_SIGCB = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_SEQ_CONTROLE_SIGCB.ToString(),
                GE403_NUM_CERTIFICADO = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_CERTIFICADO.ToString(),
                GE403_NUM_PROPOSTA = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PROPOSTA.ToString(),
                GE403_NUM_PARCELA = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PARCELA.ToString(),
                GE403_NUM_ENDOSSO = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = R4920_INSERE_NN_HIST_DB_SELECT_1_Query1.Execute(r4920_INSERE_NN_HIST_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_SEQ_CONTROLE_HIST, WS_SEQ_CONTROLE_HIST);
            }


        }

        [StopWatch]
        /*" R4920-INSERE-NN-HIST-DB-INSERT-1 */
        public void R4920_INSERE_NN_HIST_DB_INSERT_1()
        {
            /*" -1911- EXEC SQL INSERT INTO SEGUROS.GE_CONTROLE_SIGCB_HIST VALUES ( :GE403-NUM-PROPOSTA , :GE403-NUM-CERTIFICADO , :GE403-NUM-PARCELA , :GE403-NUM-APOLICE , :GE403-NUM-ENDOSSO , :GE403-SEQ-CONTROLE-SIGCB , :WS-SEQ-CONTROLE-HIST , :GE403-COD-SITUACAO , :GE404-COD-REJEICAO :WS-IND-COD-REJEICAO, :GE403-IDE-SISTEMA , :GE403-COD-USUARIO , CURRENT_TIMESTAMP) END-EXEC. */

            var r4920_INSERE_NN_HIST_DB_INSERT_1_Insert1 = new R4920_INSERE_NN_HIST_DB_INSERT_1_Insert1()
            {
                GE403_NUM_PROPOSTA = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PROPOSTA.ToString(),
                GE403_NUM_CERTIFICADO = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_CERTIFICADO.ToString(),
                GE403_NUM_PARCELA = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PARCELA.ToString(),
                GE403_NUM_APOLICE = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_APOLICE.ToString(),
                GE403_NUM_ENDOSSO = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_ENDOSSO.ToString(),
                GE403_SEQ_CONTROLE_SIGCB = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_SEQ_CONTROLE_SIGCB.ToString(),
                WS_SEQ_CONTROLE_HIST = WS_SEQ_CONTROLE_HIST.ToString(),
                GE403_COD_SITUACAO = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_SITUACAO.ToString(),
                GE404_COD_REJEICAO = GE404.DCLGE_CONTROLE_SIGCB_HIST.GE404_COD_REJEICAO.ToString(),
                WS_IND_COD_REJEICAO = WS_IND_COD_REJEICAO.ToString(),
                GE403_IDE_SISTEMA = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_IDE_SISTEMA.ToString(),
                GE403_COD_USUARIO = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_USUARIO.ToString(),
            };

            R4920_INSERE_NN_HIST_DB_INSERT_1_Insert1.Execute(r4920_INSERE_NN_HIST_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R5000-CONSULTA-NN-NUM-IDLG-SECTION */
        private void R5000_CONSULTA_NN_NUM_IDLG_SECTION()
        {
            /*" -1928- MOVE LK-GE350-NUM-IDLG TO GE403-NUM-IDLG */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_IDLG, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_IDLG);

            /*" -1986- PERFORM R5000_CONSULTA_NN_NUM_IDLG_DB_SELECT_1 */

            R5000_CONSULTA_NN_NUM_IDLG_DB_SELECT_1();

            /*" -1989- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1990- IF (SQLCODE EQUAL +100) */

                if ((DB.SQLCODE == +100))
                {

                    /*" -1992- DISPLAY 'R5000-CONTROLE SIGCB NAO ENCONTRADO -> ' GE403-NUM-IDLG */
                    _.Display($"R5000-CONTROLE SIGCB NAO ENCONTRADO -> {GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_IDLG}");

                    /*" -1993- MOVE '2' TO LK-GE350-COD-RETORNO */
                    _.Move("2", REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO);

                    /*" -1995- MOVE 'R5000-CONTROLE SIGCB NAO ENCONTRADO ' TO LK-GE350-MSG-RETORNO */
                    _.Move("R5000-CONTROLE SIGCB NAO ENCONTRADO ", REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                    /*" -1996- GO TO RXXXX-ROTINA-RETORNO */

                    RXXXX_ROTINA_RETORNO_SECTION(); //GOTO
                    return;

                    /*" -1997- ELSE */
                }
                else
                {


                    /*" -1999- DISPLAY 'R5000- ERRO SELECT CONTROLE ' */
                    _.Display($"R5000- ERRO SELECT CONTROLE ");

                    /*" -2001- MOVE 'R5000-ERRO GE_CONTROLE_EMISSAO_SIGCB' TO LK-GE350-MSG-RETORNO */
                    _.Move("R5000-ERRO GE_CONTROLE_EMISSAO_SIGCB", REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                    /*" -2002- PERFORM R8888-00-DISPLAY-ERRO */

                    R8888_00_DISPLAY_ERRO_SECTION();

                    /*" -2003- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2004- END-IF */
                }


                /*" -2005- ELSE */
            }
            else
            {


                /*" -2006- MOVE GE403-NUM-PROPOSTA TO LK-GE350-NUM-PROPOSTA */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PROPOSTA, REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PROPOSTA);

                /*" -2007- MOVE GE403-NUM-CERTIFICADO TO LK-GE350-NUM-CERTIFICADO */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_CERTIFICADO, REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_CERTIFICADO);

                /*" -2008- MOVE GE403-NUM-PARCELA TO LK-GE350-NUM-PARCELA */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PARCELA, REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA);

                /*" -2009- MOVE GE403-NUM-APOLICE TO LK-GE350-NUM-APOLICE */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_APOLICE, REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE);

                /*" -2010- MOVE GE403-NUM-ENDOSSO TO LK-GE350-NUM-ENDOSSO */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_ENDOSSO, REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO);

                /*" -2012- MOVE GE403-SEQ-CONTROLE-SIGCB TO LK-GE350-SEQ-CNTRLE-SIGCB */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_SEQ_CONTROLE_SIGCB, REGISTRO_LINKAGE_GE0350S.LK_GE350_SEQ_CNTRLE_SIGCB);

                /*" -2013- MOVE GE403-DTA-MOVIMENTO TO LK-GE350-DTA-MOVIMENTO */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_DTA_MOVIMENTO, REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_MOVIMENTO);

                /*" -2015- MOVE GE403-NUM-OCORR-MOVTO TO LK-GE350-NUM-OCORR-MOVTO */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_OCORR_MOVTO, REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_OCORR_MOVTO);

                /*" -2016- MOVE GE403-COD-PRODUTO TO LK-GE350-COD-PRODUTO */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_PRODUTO, REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_PRODUTO);

                /*" -2017- MOVE GE403-DTA-VENCIMENTO TO LK-GE350-DTA-VENCIMENTO */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_DTA_VENCIMENTO, REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_VENCIMENTO);

                /*" -2019- MOVE GE403-VLR-PREMIO-TOTAL TO LK-GE350-VLR-PREMIO-TOTAL */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_VLR_PREMIO_TOTAL, REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_PREMIO_TOTAL);

                /*" -2020- MOVE GE403-VLR-IOF TO LK-GE350-VLR-IOF */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_VLR_IOF, REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_IOF);

                /*" -2021- MOVE GE403-QTD-PARCELA TO LK-GE350-QTD-PARCELA */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_QTD_PARCELA, REGISTRO_LINKAGE_GE0350S.LK_GE350_QTD_PARCELA);

                /*" -2023- MOVE GE403-QTD-DIAS-CUSTODIA TO LK-GE350-QTD-DIAS-CUSTODIA */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_QTD_DIAS_CUSTODIA, REGISTRO_LINKAGE_GE0350S.LK_GE350_QTD_DIAS_CUSTODIA);

                /*" -2024- MOVE GE403-COD-CLIENTE TO LK-GE350-COD-CLIENTE */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_CLIENTE, REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_CLIENTE);

                /*" -2026- MOVE GE403-COD-CEDENTE-SAP TO LK-GE350-COD-CEDENTE-SAP */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_CEDENTE_SAP, REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_CEDENTE_SAP);

                /*" -2028- MOVE GE403-NUM-BOLETO-INTERNO TO LK-GE350-NUM-BLTO-INTERNO */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_BOLETO_INTERNO, REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_BLTO_INTERNO);

                /*" -2030- MOVE GE403-NUM-NOSSO-NUMERO-SAP TO LK-GE350-NOSSO-NUMERO-SAP */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_NOSSO_NUMERO_SAP, REGISTRO_LINKAGE_GE0350S.LK_GE350_NOSSO_NUMERO_SAP);

                /*" -2032- MOVE GE403-COD-LINHA-DIGITAVEL TO LK-GE350-COD-LINHA-DGTVEL */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_LINHA_DIGITAVEL, REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_LINHA_DGTVEL);

                /*" -2033- MOVE GE403-NUM-TITULO TO LK-GE350-NUM-TITULO */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_TITULO, REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_TITULO);

                /*" -2034- MOVE GE403-IDE-SISTEMA TO LK-GE350-IDE-SISTEMA */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_IDE_SISTEMA, REGISTRO_LINKAGE_GE0350S.LK_GE350_IDE_SISTEMA);

                /*" -2035- MOVE GE403-COD-USUARIO TO LK-GE350-COD-USUARIO */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_USUARIO, REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_USUARIO);

                /*" -2037- MOVE GE403-COD-SITUACAO TO LK-GE350-COD-SITUACAO */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_SITUACAO, REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO);

                /*" -2038- IF (WS-DTA-VENC-CUSTODIA < HOST-CURRENT-DATE) */

                if ((WS_DTA_VENC_CUSTODIA < HOST_CURRENT_DATE))
                {

                    /*" -2039- DISPLAY 'CUST�DIA DE BOLETO VENCIDA ' */
                    _.Display($"CUST�DIA DE BOLETO VENCIDA ");

                    /*" -2040- MOVE '3' TO LK-GE350-COD-RETORNO */
                    _.Move("3", REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO);

                    /*" -2041- MOVE 'T' TO LK-GE350-COD-SITUACAO */
                    _.Move("T", REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO);

                    /*" -2043- MOVE 'CUST�DIA DE BOLETO VENCIDA ' TO LK-GE350-MSG-RETORNO */
                    _.Move("CUST�DIA DE BOLETO VENCIDA ", REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                    /*" -2044- GO TO RXXXX-ROTINA-RETORNO */

                    RXXXX_ROTINA_RETORNO_SECTION(); //GOTO
                    return;

                    /*" -2045- END-IF */
                }


                /*" -2046- END-IF */
            }


            /*" -2046- . */

        }

        [StopWatch]
        /*" R5000-CONSULTA-NN-NUM-IDLG-DB-SELECT-1 */
        public void R5000_CONSULTA_NN_NUM_IDLG_DB_SELECT_1()
        {
            /*" -1986- EXEC SQL SELECT NUM_PROPOSTA , NUM_CERTIFICADO , NUM_PARCELA , NUM_APOLICE , NUM_ENDOSSO , SEQ_CONTROLE_SIGCB , DTA_MOVIMENTO , VALUE(NUM_OCORR_MOVTO, 0) , VALUE(NUM_IDLG, ' ' ) , COD_PRODUTO , DTA_VENCIMENTO , VLR_PREMIO_TOTAL , VLR_IOF , QTD_PARCELA , QTD_DIAS_CUSTODIA , COD_CLIENTE , VALUE(COD_CEDENTE_SAP, ' ' ) , VALUE(NUM_BOLETO_INTERNO, 0) , VALUE(NUM_NOSSO_NUMERO_SAP, 0) , VALUE(COD_LINHA_DIGITAVEL, ' ' ) , VALUE(NUM_TITULO, 0) , IDE_SISTEMA , COD_USUARIO , COD_SITUACAO , DATE(DTA_VENCIMENTO + QTD_DIAS_CUSTODIA DAYS) INTO :GE403-NUM-PROPOSTA , :GE403-NUM-CERTIFICADO , :GE403-NUM-PARCELA , :GE403-NUM-APOLICE , :GE403-NUM-ENDOSSO , :GE403-SEQ-CONTROLE-SIGCB , :GE403-DTA-MOVIMENTO , :GE403-NUM-OCORR-MOVTO , :GE403-NUM-IDLG , :GE403-COD-PRODUTO , :GE403-DTA-VENCIMENTO , :GE403-VLR-PREMIO-TOTAL , :GE403-VLR-IOF , :GE403-QTD-PARCELA , :GE403-QTD-DIAS-CUSTODIA , :GE403-COD-CLIENTE , :GE403-COD-CEDENTE-SAP , :GE403-NUM-BOLETO-INTERNO , :GE403-NUM-NOSSO-NUMERO-SAP , :GE403-COD-LINHA-DIGITAVEL , :GE403-NUM-TITULO , :GE403-IDE-SISTEMA , :GE403-COD-USUARIO , :GE403-COD-SITUACAO , :WS-DTA-VENC-CUSTODIA FROM SEGUROS.GE_CONTROLE_EMISSAO_SIGCB A WHERE A.NUM_IDLG = :GE403-NUM-IDLG AND A.SEQ_CONTROLE_SIGCB = (SELECT MAX(B.SEQ_CONTROLE_SIGCB) FROM SEGUROS.GE_CONTROLE_EMISSAO_SIGCB B WHERE B.NUM_IDLG = :GE403-NUM-IDLG) WITH UR END-EXEC. */

            var r5000_CONSULTA_NN_NUM_IDLG_DB_SELECT_1_Query1 = new R5000_CONSULTA_NN_NUM_IDLG_DB_SELECT_1_Query1()
            {
                GE403_NUM_IDLG = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_IDLG.ToString(),
            };

            var executed_1 = R5000_CONSULTA_NN_NUM_IDLG_DB_SELECT_1_Query1.Execute(r5000_CONSULTA_NN_NUM_IDLG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE403_NUM_PROPOSTA, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PROPOSTA);
                _.Move(executed_1.GE403_NUM_CERTIFICADO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_CERTIFICADO);
                _.Move(executed_1.GE403_NUM_PARCELA, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PARCELA);
                _.Move(executed_1.GE403_NUM_APOLICE, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_APOLICE);
                _.Move(executed_1.GE403_NUM_ENDOSSO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_ENDOSSO);
                _.Move(executed_1.GE403_SEQ_CONTROLE_SIGCB, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_SEQ_CONTROLE_SIGCB);
                _.Move(executed_1.GE403_DTA_MOVIMENTO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_DTA_MOVIMENTO);
                _.Move(executed_1.GE403_NUM_OCORR_MOVTO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_OCORR_MOVTO);
                _.Move(executed_1.GE403_NUM_IDLG, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_IDLG);
                _.Move(executed_1.GE403_COD_PRODUTO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_PRODUTO);
                _.Move(executed_1.GE403_DTA_VENCIMENTO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_DTA_VENCIMENTO);
                _.Move(executed_1.GE403_VLR_PREMIO_TOTAL, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_VLR_PREMIO_TOTAL);
                _.Move(executed_1.GE403_VLR_IOF, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_VLR_IOF);
                _.Move(executed_1.GE403_QTD_PARCELA, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_QTD_PARCELA);
                _.Move(executed_1.GE403_QTD_DIAS_CUSTODIA, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_QTD_DIAS_CUSTODIA);
                _.Move(executed_1.GE403_COD_CLIENTE, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_CLIENTE);
                _.Move(executed_1.GE403_COD_CEDENTE_SAP, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_CEDENTE_SAP);
                _.Move(executed_1.GE403_NUM_BOLETO_INTERNO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_BOLETO_INTERNO);
                _.Move(executed_1.GE403_NUM_NOSSO_NUMERO_SAP, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_NOSSO_NUMERO_SAP);
                _.Move(executed_1.GE403_COD_LINHA_DIGITAVEL, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_LINHA_DIGITAVEL);
                _.Move(executed_1.GE403_NUM_TITULO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_TITULO);
                _.Move(executed_1.GE403_IDE_SISTEMA, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_IDE_SISTEMA);
                _.Move(executed_1.GE403_COD_USUARIO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_USUARIO);
                _.Move(executed_1.GE403_COD_SITUACAO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_SITUACAO);
                _.Move(executed_1.WS_DTA_VENC_CUSTODIA, WS_DTA_VENC_CUSTODIA);
            }


        }

        [StopWatch]
        /*" R6000-CONSULTA-POR-NN-SAP-SECTION */
        private void R6000_CONSULTA_POR_NN_SAP_SECTION()
        {
            /*" -2054- MOVE LK-GE350-NOSSO-NUMERO-SAP TO GE403-NUM-NOSSO-NUMERO-SAP */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NOSSO_NUMERO_SAP, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_NOSSO_NUMERO_SAP);

            /*" -2114- PERFORM R6000_CONSULTA_POR_NN_SAP_DB_SELECT_1 */

            R6000_CONSULTA_POR_NN_SAP_DB_SELECT_1();

            /*" -2117- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -2118- IF (SQLCODE EQUAL +100) */

                if ((DB.SQLCODE == +100))
                {

                    /*" -2120- DISPLAY 'R6000-CONSULTA-POR-NN-SAP -> ' GE403-NUM-NOSSO-NUMERO-SAP */
                    _.Display($"R6000-CONSULTA-POR-NN-SAP -> {GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_NOSSO_NUMERO_SAP}");

                    /*" -2121- MOVE '2' TO LK-GE350-COD-RETORNO */
                    _.Move("2", REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO);

                    /*" -2123- MOVE 'R6000-CONTROLE SIGCB NAO ENCONTRADO ' TO LK-GE350-MSG-RETORNO */
                    _.Move("R6000-CONTROLE SIGCB NAO ENCONTRADO ", REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                    /*" -2124- GO TO RXXXX-ROTINA-RETORNO */

                    RXXXX_ROTINA_RETORNO_SECTION(); //GOTO
                    return;

                    /*" -2125- ELSE */
                }
                else
                {


                    /*" -2127- DISPLAY 'R6000- ERRO SELECT CONTROLE ' */
                    _.Display($"R6000- ERRO SELECT CONTROLE ");

                    /*" -2129- MOVE 'R6000-ERRO GE_CONTROLE_EMISSAO_SIGCB' TO LK-GE350-MSG-RETORNO */
                    _.Move("R6000-ERRO GE_CONTROLE_EMISSAO_SIGCB", REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                    /*" -2130- PERFORM R8888-00-DISPLAY-ERRO */

                    R8888_00_DISPLAY_ERRO_SECTION();

                    /*" -2131- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2132- END-IF */
                }


                /*" -2133- ELSE */
            }
            else
            {


                /*" -2134- MOVE GE403-NUM-PROPOSTA TO LK-GE350-NUM-PROPOSTA */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PROPOSTA, REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PROPOSTA);

                /*" -2135- MOVE GE403-NUM-CERTIFICADO TO LK-GE350-NUM-CERTIFICADO */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_CERTIFICADO, REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_CERTIFICADO);

                /*" -2136- MOVE GE403-NUM-PARCELA TO LK-GE350-NUM-PARCELA */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PARCELA, REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA);

                /*" -2137- MOVE GE403-NUM-APOLICE TO LK-GE350-NUM-APOLICE */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_APOLICE, REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE);

                /*" -2138- MOVE GE403-NUM-ENDOSSO TO LK-GE350-NUM-ENDOSSO */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_ENDOSSO, REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO);

                /*" -2140- MOVE GE403-SEQ-CONTROLE-SIGCB TO LK-GE350-SEQ-CNTRLE-SIGCB */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_SEQ_CONTROLE_SIGCB, REGISTRO_LINKAGE_GE0350S.LK_GE350_SEQ_CNTRLE_SIGCB);

                /*" -2141- MOVE GE403-DTA-MOVIMENTO TO LK-GE350-DTA-MOVIMENTO */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_DTA_MOVIMENTO, REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_MOVIMENTO);

                /*" -2143- MOVE GE403-NUM-OCORR-MOVTO TO LK-GE350-NUM-OCORR-MOVTO */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_OCORR_MOVTO, REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_OCORR_MOVTO);

                /*" -2144- MOVE GE403-NUM-IDLG TO LK-GE350-NUM-IDLG */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_IDLG, REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_IDLG);

                /*" -2145- MOVE GE403-COD-PRODUTO TO LK-GE350-COD-PRODUTO */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_PRODUTO, REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_PRODUTO);

                /*" -2146- MOVE GE403-DTA-VENCIMENTO TO LK-GE350-DTA-VENCIMENTO */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_DTA_VENCIMENTO, REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_VENCIMENTO);

                /*" -2148- MOVE GE403-VLR-PREMIO-TOTAL TO LK-GE350-VLR-PREMIO-TOTAL */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_VLR_PREMIO_TOTAL, REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_PREMIO_TOTAL);

                /*" -2149- MOVE GE403-VLR-IOF TO LK-GE350-VLR-IOF */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_VLR_IOF, REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_IOF);

                /*" -2150- MOVE GE403-QTD-PARCELA TO LK-GE350-QTD-PARCELA */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_QTD_PARCELA, REGISTRO_LINKAGE_GE0350S.LK_GE350_QTD_PARCELA);

                /*" -2152- MOVE GE403-QTD-DIAS-CUSTODIA TO LK-GE350-QTD-DIAS-CUSTODIA */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_QTD_DIAS_CUSTODIA, REGISTRO_LINKAGE_GE0350S.LK_GE350_QTD_DIAS_CUSTODIA);

                /*" -2153- MOVE GE403-COD-CLIENTE TO LK-GE350-COD-CLIENTE */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_CLIENTE, REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_CLIENTE);

                /*" -2155- MOVE GE403-COD-CEDENTE-SAP TO LK-GE350-COD-CEDENTE-SAP */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_CEDENTE_SAP, REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_CEDENTE_SAP);

                /*" -2157- MOVE GE403-NUM-BOLETO-INTERNO TO LK-GE350-NUM-BLTO-INTERNO */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_BOLETO_INTERNO, REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_BLTO_INTERNO);

                /*" -2159- MOVE GE403-NUM-NOSSO-NUMERO-SAP TO LK-GE350-NOSSO-NUMERO-SAP */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_NOSSO_NUMERO_SAP, REGISTRO_LINKAGE_GE0350S.LK_GE350_NOSSO_NUMERO_SAP);

                /*" -2161- MOVE GE403-COD-LINHA-DIGITAVEL TO LK-GE350-COD-LINHA-DGTVEL */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_LINHA_DIGITAVEL, REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_LINHA_DGTVEL);

                /*" -2162- MOVE GE403-NUM-TITULO TO LK-GE350-NUM-TITULO */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_TITULO, REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_TITULO);

                /*" -2163- MOVE GE403-IDE-SISTEMA TO LK-GE350-IDE-SISTEMA */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_IDE_SISTEMA, REGISTRO_LINKAGE_GE0350S.LK_GE350_IDE_SISTEMA);

                /*" -2164- MOVE GE403-COD-USUARIO TO LK-GE350-COD-USUARIO */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_USUARIO, REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_USUARIO);

                /*" -2166- MOVE GE403-COD-SITUACAO TO LK-GE350-COD-SITUACAO */
                _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_SITUACAO, REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO);

                /*" -2167- IF (WS-DTA-VENC-CUSTODIA < HOST-CURRENT-DATE) */

                if ((WS_DTA_VENC_CUSTODIA < HOST_CURRENT_DATE))
                {

                    /*" -2168- DISPLAY 'CUST�DIA DE BOLETO VENCIDA ' */
                    _.Display($"CUST�DIA DE BOLETO VENCIDA ");

                    /*" -2169- MOVE '3' TO LK-GE350-COD-RETORNO */
                    _.Move("3", REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO);

                    /*" -2170- MOVE 'T' TO LK-GE350-COD-SITUACAO */
                    _.Move("T", REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO);

                    /*" -2172- MOVE 'CUST�DIA DE BOLETO VENCIDA ' TO LK-GE350-MSG-RETORNO */
                    _.Move("CUST�DIA DE BOLETO VENCIDA ", REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                    /*" -2173- GO TO RXXXX-ROTINA-RETORNO */

                    RXXXX_ROTINA_RETORNO_SECTION(); //GOTO
                    return;

                    /*" -2174- END-IF */
                }


                /*" -2175- END-IF */
            }


            /*" -2175- . */

        }

        [StopWatch]
        /*" R6000-CONSULTA-POR-NN-SAP-DB-SELECT-1 */
        public void R6000_CONSULTA_POR_NN_SAP_DB_SELECT_1()
        {
            /*" -2114- EXEC SQL SELECT NUM_PROPOSTA , NUM_CERTIFICADO , NUM_PARCELA , NUM_APOLICE , NUM_ENDOSSO , SEQ_CONTROLE_SIGCB , DTA_MOVIMENTO , VALUE(NUM_OCORR_MOVTO, 0) , VALUE(NUM_IDLG, ' ' ) , COD_PRODUTO , DTA_VENCIMENTO , VLR_PREMIO_TOTAL , VLR_IOF , QTD_PARCELA , QTD_DIAS_CUSTODIA , COD_CLIENTE , VALUE(COD_CEDENTE_SAP, ' ' ) , VALUE(NUM_BOLETO_INTERNO, 0) , VALUE(NUM_NOSSO_NUMERO_SAP, 0) , VALUE(COD_LINHA_DIGITAVEL, ' ' ) , VALUE(NUM_TITULO, 0) , IDE_SISTEMA , COD_USUARIO , COD_SITUACAO , DATE(DTA_VENCIMENTO + QTD_DIAS_CUSTODIA DAYS) INTO :GE403-NUM-PROPOSTA , :GE403-NUM-CERTIFICADO , :GE403-NUM-PARCELA , :GE403-NUM-APOLICE , :GE403-NUM-ENDOSSO , :GE403-SEQ-CONTROLE-SIGCB , :GE403-DTA-MOVIMENTO , :GE403-NUM-OCORR-MOVTO , :GE403-NUM-IDLG , :GE403-COD-PRODUTO , :GE403-DTA-VENCIMENTO , :GE403-VLR-PREMIO-TOTAL , :GE403-VLR-IOF , :GE403-QTD-PARCELA , :GE403-QTD-DIAS-CUSTODIA , :GE403-COD-CLIENTE , :GE403-COD-CEDENTE-SAP , :GE403-NUM-BOLETO-INTERNO , :GE403-NUM-NOSSO-NUMERO-SAP , :GE403-COD-LINHA-DIGITAVEL , :GE403-NUM-TITULO , :GE403-IDE-SISTEMA , :GE403-COD-USUARIO , :GE403-COD-SITUACAO , :WS-DTA-VENC-CUSTODIA FROM SEGUROS.GE_CONTROLE_EMISSAO_SIGCB A WHERE A.NUM_NOSSO_NUMERO_SAP =:GE403-NUM-NOSSO-NUMERO-SAP AND A.SEQ_CONTROLE_SIGCB = (SELECT MAX(B.SEQ_CONTROLE_SIGCB) FROM SEGUROS.GE_CONTROLE_EMISSAO_SIGCB B WHERE B.NUM_NOSSO_NUMERO_SAP = :GE403-NUM-NOSSO-NUMERO-SAP) WITH UR END-EXEC. */

            var r6000_CONSULTA_POR_NN_SAP_DB_SELECT_1_Query1 = new R6000_CONSULTA_POR_NN_SAP_DB_SELECT_1_Query1()
            {
                GE403_NUM_NOSSO_NUMERO_SAP = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_NOSSO_NUMERO_SAP.ToString(),
            };

            var executed_1 = R6000_CONSULTA_POR_NN_SAP_DB_SELECT_1_Query1.Execute(r6000_CONSULTA_POR_NN_SAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE403_NUM_PROPOSTA, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PROPOSTA);
                _.Move(executed_1.GE403_NUM_CERTIFICADO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_CERTIFICADO);
                _.Move(executed_1.GE403_NUM_PARCELA, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PARCELA);
                _.Move(executed_1.GE403_NUM_APOLICE, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_APOLICE);
                _.Move(executed_1.GE403_NUM_ENDOSSO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_ENDOSSO);
                _.Move(executed_1.GE403_SEQ_CONTROLE_SIGCB, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_SEQ_CONTROLE_SIGCB);
                _.Move(executed_1.GE403_DTA_MOVIMENTO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_DTA_MOVIMENTO);
                _.Move(executed_1.GE403_NUM_OCORR_MOVTO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_OCORR_MOVTO);
                _.Move(executed_1.GE403_NUM_IDLG, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_IDLG);
                _.Move(executed_1.GE403_COD_PRODUTO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_PRODUTO);
                _.Move(executed_1.GE403_DTA_VENCIMENTO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_DTA_VENCIMENTO);
                _.Move(executed_1.GE403_VLR_PREMIO_TOTAL, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_VLR_PREMIO_TOTAL);
                _.Move(executed_1.GE403_VLR_IOF, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_VLR_IOF);
                _.Move(executed_1.GE403_QTD_PARCELA, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_QTD_PARCELA);
                _.Move(executed_1.GE403_QTD_DIAS_CUSTODIA, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_QTD_DIAS_CUSTODIA);
                _.Move(executed_1.GE403_COD_CLIENTE, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_CLIENTE);
                _.Move(executed_1.GE403_COD_CEDENTE_SAP, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_CEDENTE_SAP);
                _.Move(executed_1.GE403_NUM_BOLETO_INTERNO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_BOLETO_INTERNO);
                _.Move(executed_1.GE403_NUM_NOSSO_NUMERO_SAP, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_NOSSO_NUMERO_SAP);
                _.Move(executed_1.GE403_COD_LINHA_DIGITAVEL, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_LINHA_DIGITAVEL);
                _.Move(executed_1.GE403_NUM_TITULO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_TITULO);
                _.Move(executed_1.GE403_IDE_SISTEMA, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_IDE_SISTEMA);
                _.Move(executed_1.GE403_COD_USUARIO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_USUARIO);
                _.Move(executed_1.GE403_COD_SITUACAO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_SITUACAO);
                _.Move(executed_1.WS_DTA_VENC_CUSTODIA, WS_DTA_VENC_CUSTODIA);
            }


        }

        [StopWatch]
        /*" R7000-SOLICITA-NN-CICS-SIAS-SECTION */
        private void R7000_SOLICITA_NN_CICS_SIAS_SECTION()
        {
            /*" -2183- PERFORM R7400-INI-LINKAGE-GEWES001. */

            R7400_INI_LINKAGE_GEWES001_SECTION();

            /*" -2185- MOVE LK-GE350-COD-SISTEMA TO LK-COD-SISTEMA-WE001 */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SISTEMA, GEWEW001.LK_COD_SISTEMA_WE001);

            /*" -2186- IF (LK-GE350-NUM-PROPOSTA > ZEROS) */

            if ((REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PROPOSTA > 00))
            {

                /*" -2187- MOVE LK-GE350-NUM-PROPOSTA TO LK-NUM-PROPOSTA-WE001 */
                _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PROPOSTA, GEWEW001.LK_NUM_PROPOSTA_WE001);

                /*" -2190- ELSE */
            }
            else
            {


                /*" -2191- MOVE LK-GE350-NUM-CERTIFICADO TO WS-NUM-PROPOSTA */
                _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_CERTIFICADO, WS_NUM_PROPOSTA);

                /*" -2192- IF WS-NUM-PROPOSTA > 99999999999999 */

                if (WS_NUM_PROPOSTA > 99999999999999)
                {

                    /*" -2193- MOVE WS-NUM-PROPOSTA(1:14) TO WS-NUM-PROPOSTA-14 */
                    _.Move(WS_NUM_PROPOSTA.Substring(1, 14), WS_NUM_PROPOSTA_14);

                    /*" -2194- MOVE WS-NUM-PROPOSTA-14 TO LK-NUM-PROPOSTA-WE001 */
                    _.Move(WS_NUM_PROPOSTA_14, GEWEW001.LK_NUM_PROPOSTA_WE001);

                    /*" -2195- ELSE */
                }
                else
                {


                    /*" -2196- MOVE LK-GE350-NUM-CERTIFICADO TO LK-NUM-PROPOSTA-WE001 */
                    _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_CERTIFICADO, GEWEW001.LK_NUM_PROPOSTA_WE001);

                    /*" -2197- END-IF */
                }


                /*" -2199- END-IF */
            }


            /*" -2200- MOVE LK-GE350-NUM-APOLICE TO LK-NUM-APOLICE-WE001 */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE, GEWEW001.LK_NUM_APOLICE_WE001);

            /*" -2201- MOVE LK-GE350-NUM-ENDOSSO TO LK-NUM-ENDOSSO-WE001 */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO, GEWEW001.LK_NUM_ENDOSSO_WE001);

            /*" -2202- MOVE LK-GE350-NUM-PARCELA TO LK-NUM-PARCELA-WE001 */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA, GEWEW001.LK_NUM_PARCELA_WE001);

            /*" -2204- MOVE LK-GE350-QTD-PARCELA TO LK-NUM-TOTAL-PARCELAS-WE001 */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_QTD_PARCELA, GEWEW001.LK_NUM_TOTAL_PARCELAS_WE001);

            /*" -2205- MOVE 'L000' TO WS-L000 */
            _.Move("L000", AREA_DE_WORK.WS_PRODUTO.WS_L000);

            /*" -2207- MOVE LK-GE350-COD-PRODUTO TO WS-COD-PRODUTO WS-PROD */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_PRODUTO, AREA_DE_WORK.WS_PRODUTO.WS_COD_PRODUTO, AREA_DE_WORK.WS_PROD);

            /*" -2209- MOVE WS-PRODUTO TO LK-COD-CENTRO-LUCRO-WE001 */
            _.Move(AREA_DE_WORK.WS_PRODUTO, GEWEW001.LK_COD_CENTRO_LUCRO_WE001);

            /*" -2211- PERFORM R7100-00-CALL-GE0005S */

            R7100_00_CALL_GE0005S_SECTION();

            /*" -2214- MOVE LKGE-RAMO-SUSEP TO LK-NUM-RAMO-SUSEP-WE001 */
            _.Move(LK_GE0005S.LKGE_RAMO_SUSEP, GEWEW001.LK_NUM_RAMO_SUSEP_WE001);

            /*" -2216- MOVE LK-GE350-COD-TP-CONVENIO TO LK-COD-TIPO-CONVENIO-WE001 */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_TP_CONVENIO, GEWEW001.LK_COD_TIPO_CONVENIO_WE001);

            /*" -2218- MOVE 1 TO LK-COD-COMPROMISSO-WE001 */
            _.Move(1, GEWEW001.LK_COD_COMPROMISSO_WE001);

            /*" -2220- MOVE LK-GE350-NUM-CERTIFICADO TO LK-NUM-CERTIFICADO-WE001 */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_CERTIFICADO, GEWEW001.LK_NUM_CERTIFICADO_WE001);

            /*" -2222- MOVE LK-GE350-NUM-TITULO TO LK-NUM-TITULO-WE001 */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_TITULO, GEWEW001.LK_NUM_TITULO_WE001);

            /*" -2225- COMPUTE W77-VLR-PREMIO-LIQUIDO = LK-GE350-VLR-PREMIO-TOTAL - LK-GE350-VLR-IOF */
            W77_VLR_PREMIO_LIQUIDO.Value = REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_PREMIO_TOTAL - REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_IOF;

            /*" -2227- MOVE W77-VLR-PREMIO-LIQUIDO TO LK-VLR-BOLETO-WE001 */
            _.Move(W77_VLR_PREMIO_LIQUIDO, GEWEW001.LK_VLR_BOLETO_WE001);

            /*" -2228- MOVE LK-GE350-QTD-DIAS-CUSTODIA TO LK-QTD-PERMANENCIA-WE001 */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_QTD_DIAS_CUSTODIA, GEWEW001.LK_QTD_PERMANENCIA_WE001);

            /*" -2229- MOVE LK-GE350-VLR-IOF TO LK-VLR-IOF-WE001 */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_IOF, GEWEW001.LK_VLR_IOF_WE001);

            /*" -2231- MOVE SPACES TO LK-IND-REGISTRA-ONLINE-WE001 */
            _.Move("", GEWEW001.LK_IND_REGISTRA_ONLINE_WE001);

            /*" -2234- IF LK-GE350-COD-TP-CONVENIO = 'R' OR LK-GE350-COD-CLIENTE > 0 */

            if (REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_TP_CONVENIO == "R" || REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_CLIENTE > 0)
            {

                /*" -2235- PERFORM R7200-00-SELECT-CLIENTE */

                R7200_00_SELECT_CLIENTE_SECTION();

                /*" -2236- IF CLIENTES-TIPO-PESSOA EQUAL 'F' */

                if (CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA == "F")
                {

                    /*" -2237- EVALUATE CLIENTES-IDE-SEXO */
                    switch (CLIENTES.DCLCLIENTES.CLIENTES_IDE_SEXO.Value.Trim())
                    {

                        /*" -2238- WHEN 'F' */
                        case "F":

                            /*" -2239- MOVE '0001' TO LK-COD-FORMA-TRATAMENTO-WE001 */
                            _.Move("0001", GEWEW001.LK_COD_FORMA_TRATAMENTO_WE001);

                            /*" -2240- WHEN 'M' */
                            break;
                        case "M":

                            /*" -2241- MOVE '0001' TO LK-COD-FORMA-TRATAMENTO-WE001 */
                            _.Move("0001", GEWEW001.LK_COD_FORMA_TRATAMENTO_WE001);

                            /*" -2242- WHEN OTHER */
                            break;
                        default:

                            /*" -2243- MOVE 'Z003' TO LK-COD-FORMA-TRATAMENTO-WE001 */
                            _.Move("Z003", GEWEW001.LK_COD_FORMA_TRATAMENTO_WE001);

                            /*" -2245- END-EVALUATE */
                            break;
                    }


                    /*" -2247- MOVE CT0007S-NOME1 TO LK-NOM-PESSOA-WE001 */
                    _.Move(AREA_DE_WORK.WS_MENS.CT0007SW099.CT0007S_NOME1, GEWEW001.LK_NOM_PESSOA_WE001);

                    /*" -2248- IF CT0007S-SOBRENOME EQUAL ' ' */

                    if (AREA_DE_WORK.WS_MENS.CT0007SW099.CT0007S_SOBRENOME == " ")
                    {

                        /*" -2249- MOVE '.' TO LK-NOM-ULTIMO-NOME-WE001 */
                        _.Move(".", GEWEW001.LK_NOM_ULTIMO_NOME_WE001);

                        /*" -2250- ELSE */
                    }
                    else
                    {


                        /*" -2251- MOVE CT0007S-SOBRENOME TO LK-NOM-ULTIMO-NOME-WE001 */
                        _.Move(AREA_DE_WORK.WS_MENS.CT0007SW099.CT0007S_SOBRENOME, GEWEW001.LK_NOM_ULTIMO_NOME_WE001);

                        /*" -2253- END-IF */
                    }


                    /*" -2254- MOVE CLIENTES-CGCCPF TO WS-CPF */
                    _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, AREA_DE_WORK.WS_CPF);

                    /*" -2255- MOVE WS-CPF TO LK-NUM-CPF-CNPJ-WE001 */
                    _.Move(AREA_DE_WORK.WS_CPF, GEWEW001.LK_NUM_CPF_CNPJ_WE001);

                    /*" -2256- ELSE */
                }
                else
                {


                    /*" -2257- IF CLIENTES-TIPO-PESSOA EQUAL 'J' */

                    if (CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA == "J")
                    {

                        /*" -2258- MOVE CLIENTES-NOME-RAZAO TO LK-NOM-PESSOA-WE001 */
                        _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, GEWEW001.LK_NOM_PESSOA_WE001);

                        /*" -2259- MOVE '0003' TO LK-COD-FORMA-TRATAMENTO-WE001 */
                        _.Move("0003", GEWEW001.LK_COD_FORMA_TRATAMENTO_WE001);

                        /*" -2260- ELSE */
                    }
                    else
                    {


                        /*" -2261- MOVE 'Z004' TO LK-COD-FORMA-TRATAMENTO-WE001 */
                        _.Move("Z004", GEWEW001.LK_COD_FORMA_TRATAMENTO_WE001);

                        /*" -2263- END-IF */
                    }


                    /*" -2264- MOVE CLIENTES-CGCCPF TO WS-CNPJ */
                    _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, AREA_DE_WORK.WS_CNPJ);

                    /*" -2265- MOVE WS-CNPJ TO LK-NUM-CPF-CNPJ-WE001 */
                    _.Move(AREA_DE_WORK.WS_CNPJ, GEWEW001.LK_NUM_CPF_CNPJ_WE001);

                    /*" -2266- END-IF */
                }


                /*" -2267- IF WS-RAMO-EMISSOR EQUAL 31 OR 53 */

                if (AREA_DE_WORK.FILLER_2.WS_RAMO_EMISSOR.In("31", "53"))
                {

                    /*" -2268- PERFORM R7301-00-ENDOSSO-ENDERECO */

                    R7301_00_ENDOSSO_ENDERECO_SECTION();

                    /*" -2269- ELSE */
                }
                else
                {


                    /*" -2270- PERFORM R7300-00-SELECT-ENDERECOS */

                    R7300_00_SELECT_ENDERECOS_SECTION();

                    /*" -2271- END-IF */
                }


                /*" -2272- IF ENDERECO-ENDERECO NOT EQUAL SPACES */

                if (!ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO.IsEmpty())
                {

                    /*" -2273- MOVE ENDERECO-ENDERECO TO LK-COD-ENDERECO-WE001 */
                    _.Move(ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO, GEWEW001.LK_COD_ENDERECO_WE001);

                    /*" -2274- MOVE ENDERECO-ENDERECO TO LK-DES-ENDERECO-WE001 */
                    _.Move(ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO, GEWEW001.LK_DES_ENDERECO_WE001);

                    /*" -2275- MOVE ENDERECO-BAIRRO TO LK-NOM-BAIRRO-WE001 */
                    _.Move(ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO, GEWEW001.LK_NOM_BAIRRO_WE001);

                    /*" -2276- MOVE ENDERECO-CIDADE TO LK-NOM-CIDADE-WE001 */
                    _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CIDADE, GEWEW001.LK_NOM_CIDADE_WE001);

                    /*" -2277- MOVE ENDERECO-SIGLA-UF TO LK-COD-UF-WE001 */
                    _.Move(ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF, GEWEW001.LK_COD_UF_WE001);

                    /*" -2278- MOVE ENDERECO-CEP TO LK-NUM-CEP-WE001 */
                    _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CEP, GEWEW001.LK_NUM_CEP_WE001);

                    /*" -2280- END-IF */
                }


                /*" -2282- END-IF */
            }


            /*" -2283- MOVE LK-GE350-COD-CANAL TO LK-COD-CANAL-WE001 */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_CANAL, GEWEW001.LK_COD_CANAL_WE001);

            /*" -2284- MOVE LK-GE350-COD-FONTE TO LK-COD-FONTE-WE001 */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_FONTE, GEWEW001.LK_COD_FONTE_WE001);

            /*" -2285- MOVE LK-GE350-COD-EVENTO TO LK-COD-EVENTO-WE001 */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_EVENTO, GEWEW001.LK_COD_EVENTO_WE001);

            /*" -2287- MOVE LK-GE350-NUM-CONTA-CNTRO TO LK-NUM-CONTA-CONTRATO-WE001 */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_CONTA_CNTRO, GEWEW001.LK_NUM_CONTA_CONTRATO_WE001);

            /*" -2289- MOVE LK-GE350-NUM-IDLG TO LK-COD-IDENTIFICADOR-WE001 */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_IDLG, GEWEW001.LK_COD_IDENTIFICADOR_WE001);

            /*" -2290- MOVE LK-GE350-DTA-MOVIMENTO TO LK-DTA-DOCUMENTO-WE001 */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_MOVIMENTO, GEWEW001.LK_DTA_DOCUMENTO_WE001);

            /*" -2291- MOVE LK-GE350-DTA-MOVIMENTO TO LK-DTA-LANCAM-DOCUMENTO-WE001 */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_MOVIMENTO, GEWEW001.LK_DTA_LANCAM_DOCUMENTO_WE001);

            /*" -2293- MOVE LK-GE350-DTA-VENCIMENTO TO LK-DTA-VENCIMENTO-WE001. */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_VENCIMENTO, GEWEW001.LK_DTA_VENCIMENTO_WE001);

            /*" -2295- IF (LK-GE350-COD-USUARIO EQUAL 'EM0010B' AND (WS-RAMO-EMISSOR EQUAL 31 OR 53)) */

            if ((REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_USUARIO == "EM0010B" && (AREA_DE_WORK.FILLER_2.WS_RAMO_EMISSOR.In("31", "53"))))
            {

                /*" -2296- MOVE 'N' TO LK-IND-REGISTRA-ONLINE-WE001 */
                _.Move("N", GEWEW001.LK_IND_REGISTRA_ONLINE_WE001);

                /*" -2297- MOVE ZEROS TO LKN-IND-REGISTRA-ONLINE-WE001 */
                _.Move(0, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_IND_REGISTRA_ONLINE_WE001);

                /*" -2299- END-IF */
            }


            /*" -2301- IF (LK-GE350-COD-TP-CONVENIO = 'G' AND LK-GE350-IDE-SISTEMA = 'SI' ) */

            if ((REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_TP_CONVENIO == "G" && REGISTRO_LINKAGE_GE0350S.LK_GE350_IDE_SISTEMA == "SI"))
            {

                /*" -2302- MOVE LK-GE350-NUM-APOLICE TO SIARDEVC-NUM-APOL-SINISTRO */
                _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO);

                /*" -2303- MOVE LK-GE350-NUM-PROPOSTA TO SIARDEVC-NUM-RESSARC */
                _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PROPOSTA, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_RESSARC);

                /*" -2304- MOVE LK-GE350-NUM-PARCELA TO SIARDEVC-NUM-PARCELA-ACORDO */
                _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_PARCELA_ACORDO);

                /*" -2305- PERFORM R7010-00-SELECT-CLIENTE-RESS */

                R7010_00_SELECT_CLIENTE_RESS_SECTION();

                /*" -2306- END-IF */
            }


            /*" -2340- MOVE ZEROS TO LKN-COD-SISTEMA-WE001 LKN-NUM-PROPOSTA-WE001 LKN-NUM-APOLICE-WE001 LKN-NUM-ENDOSSO-WE001 LKN-NUM-PARCELA-WE001 LKN-NUM-TOTAL-PARCELAS-WE001 LKN-COD-CENTRO-LUCRO-WE001 LKN-NUM-RAMO-SUSEP-WE001 LKN-COD-TIPO-CONVENIO-WE001 LKN-COD-COMPROMISSO-WE001 LKN-NUM-CERTIFICADO-WE001 LKN-NUM-TITULO-WE001 LKN-VLR-BOLETO-WE001 LKN-QTD-PERMANENCIA-WE001 LKN-VLR-IOF-WE001 LKN-COD-FORMA-TRATAMENTO-WE001 LKN-NOM-PESSOA-WE001 LKN-NOM-ULTIMO-NOME-WE001 LKN-NOM-PESSOA-WE001 LKN-NUM-CPF-CNPJ-WE001 LKN-COD-ENDERECO-WE001 LKN-DES-ENDERECO-WE001 LKN-NOM-BAIRRO-WE001 LKN-NOM-CIDADE-WE001 LKN-COD-UF-WE001 LKN-NUM-CEP-WE001 LKN-COD-CANAL-WE001 LKN-COD-FONTE-WE001 LKN-COD-EVENTO-WE001 LKN-NUM-CONTA-CONTRATO-WE001 LKN-COD-IDENTIFICADOR-WE001 LKN-DTA-DOCUMENTO-WE001 LKN-DTA-LANCAM-DOCUMENTO-WE001 LKN-DTA-VENCIMENTO-WE001 . */
            _.Move(0, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_SISTEMA_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_PROPOSTA_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_APOLICE_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_ENDOSSO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_PARCELA_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_TOTAL_PARCELAS_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_CENTRO_LUCRO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_RAMO_SUSEP_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_TIPO_CONVENIO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_COMPROMISSO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_CERTIFICADO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_TITULO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_VLR_BOLETO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_QTD_PERMANENCIA_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_VLR_IOF_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_FORMA_TRATAMENTO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NOM_PESSOA_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NOM_ULTIMO_NOME_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NOM_PESSOA_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_CPF_CNPJ_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_ENDERECO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_DES_ENDERECO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NOM_BAIRRO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NOM_CIDADE_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_UF_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_CEP_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_CANAL_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_FONTE_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_EVENTO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_CONTA_CONTRATO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_IDENTIFICADOR_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_DTA_DOCUMENTO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_DTA_LANCAM_DOCUMENTO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_DTA_VENCIMENTO_WE001);

            /*" -2494- PERFORM R7000_SOLICITA_NN_CICS_SIAS_DB_CALL_1 */

            R7000_SOLICITA_NN_CICS_SIAS_DB_CALL_1();

            /*" -2502- DISPLAY ' RETORNO DO CICS ' LK-COD-RETORNO-WE001 ' NN = ' LK-NUM-NOSSO-NUMERO-WE001 ' RET-CONV = ' LK-COD-TIPO-CONVENIO-WE001 */

            $" RETORNO DO CICS {GEWEW001.LK_COD_RETORNO_WE001} NN = {GEWEW001.LK_NUM_NOSSO_NUMERO_WE001} RET-CONV = {GEWEW001.LK_COD_TIPO_CONVENIO_WE001}"
            .Display();

            /*" -2503- IF (LK-COD-RETORNO-WE001 NOT EQUAL '00' AND '01' AND '08' ) */

            if ((!GEWEW001.LK_COD_RETORNO_WE001.In("00", "01", "08")))
            {

                /*" -2504- DISPLAY '---------------------------------------------' */
                _.Display($"---------------------------------------------");

                /*" -2506- DISPLAY ' COD-RETORNO . ' LK-GE350-COD-RETORNO ' MSG . ' LK-GE350-MSG-RETORNO */

                $" COD-RETORNO . {REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO} MSG . {REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO}"
                .Display();

                /*" -2509- DISPLAY ' GEWES001-RET . ' LK-COD-RETORNO-WE001 ' NN . ' LK-NUM-NOSSO-NUMERO-WE001 ' CONVENIO . ' LK-COD-TIPO-CONVENIO-WE001 */

                $" GEWES001-RET . {GEWEW001.LK_COD_RETORNO_WE001} NN . {GEWEW001.LK_NUM_NOSSO_NUMERO_WE001} CONVENIO . {GEWEW001.LK_COD_TIPO_CONVENIO_WE001}"
                .Display();

                /*" -2512- DISPLAY 'COD-MENSAGEM <' LK-COD-MENSAGEM-WE001 '>' 'NUM-MENSAGEM <' LK-NUM-MENSAGEM-WE001 '>' 'DES-MENSAGEM <' LK-DES-MENSAGEM-TXT-WE001 '>' */

                $"COD-MENSAGEM <{GEWEW001.LK_COD_MENSAGEM_WE001}>NUM-MENSAGEM <{GEWEW001.LK_NUM_MENSAGEM_WE001}>DES-MENSAGEM <{GEWEW001.LK_DES_MENSAGEM_WE001.LK_DES_MENSAGEM_TXT_WE001}>"
                .Display();

                /*" -2515- DISPLAY 'DES-LOG <' LK-DES-LOG-TXT-WE001 '>' 'SEQ-LOG <' LK-SEQ-LOG-WE001 '>' 'NOM-PARAMETRO <' LK-NOM-PARAMETRO-TXT-WE001 '>' */

                $"DES-LOG <{GEWEW001.LK_DES_LOG_WE001.LK_DES_LOG_TXT_WE001}>SEQ-LOG <{GEWEW001.LK_SEQ_LOG_WE001}>NOM-PARAMETRO <{GEWEW001.LK_NOM_PARAMETRO_WE001.LK_NOM_PARAMETRO_TXT_WE001}>"
                .Display();

                /*" -2518- DISPLAY 'NUM-LINHA  <' LK-NUM-LINHA-WE001 '>' 'NOM-CAMPO <' LK-NOM-CAMPO-TXT-WE001 '>' 'NOM-SISTEMA <' LK-NOM-SISTEMA-TXT-WE001 '>' */

                $"NUM-LINHA  <{GEWEW001.LK_NUM_LINHA_WE001}>NOM-CAMPO <{GEWEW001.LK_NOM_CAMPO_WE001.LK_NOM_CAMPO_TXT_WE001}>NOM-SISTEMA <{GEWEW001.LK_NOM_SISTEMA_WE001.LK_NOM_SISTEMA_TXT_WE001}>"
                .Display();

                /*" -2521- DISPLAY 'IND-ERRO <' LK-IND-ERRO-WE001 '>' 'MSG-RET <' LK-MSG-RET-WE001 '>' 'NM-TAB  <' LK-NM-TAB-WE001 '>' */

                $"IND-ERRO <{GEWEW001.LK_IND_ERRO_WE001}>MSG-RET <{GEWEW001.LK_MSG_RET_WE001}>NM-TAB  <{GEWEW001.LK_NM_TAB_WE001}>"
                .Display();

                /*" -2523- DISPLAY 'SQLCODE <' WS-SQLCODE-ED '>' 'SQLERRMC            <' LK-SQLERRMC-WE001 '>' */

                $"SQLCODE <{WS_SQLCODE_ED}>SQLERRMC            <{GEWEW001.LK_SQLERRMC_WE001}>"
                .Display();

                /*" -2524- DISPLAY '----------------------------------------------' */
                _.Display($"----------------------------------------------");

                /*" -2526- END-IF */
            }


            /*" -2532- IF (LK-NUM-NOSSO-NUMERO-WE001 = ' ' AND LK-COD-TIPO-CONVENIO-WE001 = 'R' ) OR (LK-COD-TIPO-CONVENIO-WE001 = 'G' AND LK-COD-RETORNO-WE001 NOT EQUAL '00' AND '08' ) */

            if ((GEWEW001.LK_NUM_NOSSO_NUMERO_WE001 == " " && GEWEW001.LK_COD_TIPO_CONVENIO_WE001 == "R") || (GEWEW001.LK_COD_TIPO_CONVENIO_WE001 == "G" && !GEWEW001.LK_COD_RETORNO_WE001.In("00", "08")))
            {

                /*" -2536- DISPLAY 'GE0306S-CONVENIO: ' LK-COD-TIPO-CONVENIO-WE001 ' NOSSO NUMERO: ' LK-NUM-NOSSO-NUMERO-WE001 ' COD-RETORNO: ' LK-COD-RETORNO-WE001 */

                $"GE0306S-CONVENIO: {GEWEW001.LK_COD_TIPO_CONVENIO_WE001} NOSSO NUMERO: {GEWEW001.LK_NUM_NOSSO_NUMERO_WE001} COD-RETORNO: {GEWEW001.LK_COD_RETORNO_WE001}"
                .Display();

                /*" -2537- DISPLAY ' ' */
                _.Display($" ");

                /*" -2538- DISPLAY '------------------------------------------------' */
                _.Display($"------------------------------------------------");

                /*" -2539- DISPLAY '*       R7000-SOLICITA-NN-CICS-SIAS            *' */
                _.Display($"*       R7000-SOLICITA-NN-CICS-SIAS            *");

                /*" -2540- DISPLAY '*       RETORNO DO CALL DA GEWES001            *' */
                _.Display($"*       RETORNO DO CALL DA GEWES001            *");

                /*" -2541- DISPLAY '------------------------------------------------' */
                _.Display($"------------------------------------------------");

                /*" -2542- DISPLAY '=> LK-RETORNO.... ' LK-COD-RETORNO-WE001 */
                _.Display($"=> LK-RETORNO.... {GEWEW001.LK_COD_RETORNO_WE001}");

                /*" -2543- DISPLAY '=> LK-MENSAGEM... ' LK-DES-MENSAGEM-TXT-WE001 */
                _.Display($"=> LK-MENSAGEM... {GEWEW001.LK_DES_MENSAGEM_WE001.LK_DES_MENSAGEM_TXT_WE001}");

                /*" -2544- DISPLAY '=> LK-NM-TAB..... ' LK-NM-TAB-WE001 */
                _.Display($"=> LK-NM-TAB..... {GEWEW001.LK_NM_TAB_WE001}");

                /*" -2545- DISPLAY '=> LK-SQLCODE.... ' LK-SQLCODE-WE001 */
                _.Display($"=> LK-SQLCODE.... {GEWEW001.LK_SQLCODE_WE001}");

                /*" -2546- DISPLAY '=> LK-MSG-RET.... ' LK-MSG-RET-WE001 */
                _.Display($"=> LK-MSG-RET.... {GEWEW001.LK_MSG_RET_WE001}");

                /*" -2547- DISPLAY '=> LK-SQLERRMC... ' LK-SQLERRMC-WE001 */
                _.Display($"=> LK-SQLERRMC... {GEWEW001.LK_SQLERRMC_WE001}");

                /*" -2548- DISPLAY '------------------------------------------------' */
                _.Display($"------------------------------------------------");

                /*" -2549- DISPLAY 'NOSSO-NUMERO-SAP ' LK-GE350-NOSSO-NUMERO-SAP */
                _.Display($"NOSSO-NUMERO-SAP {REGISTRO_LINKAGE_GE0350S.LK_GE350_NOSSO_NUMERO_SAP}");

                /*" -2550- MOVE LKN-COD-SISTEMA-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_SISTEMA_WE001, WS_IND_NULL_ED);

                /*" -2552- DISPLAY 'COD-SISTEMA         <' WS-IND-NULL-ED '>' LK-COD-SISTEMA-WE001 '>' */

                $"COD-SISTEMA         <{WS_IND_NULL_ED}>{GEWEW001.LK_COD_SISTEMA_WE001}>"
                .Display();

                /*" -2553- MOVE LKN-NUM-PROPOSTA-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_PROPOSTA_WE001, WS_IND_NULL_ED);

                /*" -2555- DISPLAY 'NUM-PROPOSTA        <' WS-IND-NULL-ED '>' LK-NUM-PROPOSTA-WE001 '>' */

                $"NUM-PROPOSTA        <{WS_IND_NULL_ED}>{GEWEW001.LK_NUM_PROPOSTA_WE001}>"
                .Display();

                /*" -2556- MOVE LKN-NUM-APOLICE-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_APOLICE_WE001, WS_IND_NULL_ED);

                /*" -2558- DISPLAY 'NUM-APOLICE         <' WS-IND-NULL-ED '>' LK-NUM-APOLICE-WE001 '>' */

                $"NUM-APOLICE         <{WS_IND_NULL_ED}>{GEWEW001.LK_NUM_APOLICE_WE001}>"
                .Display();

                /*" -2559- MOVE LKN-NUM-ENDOSSO-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_ENDOSSO_WE001, WS_IND_NULL_ED);

                /*" -2561- DISPLAY 'NUM-ENDOSSO         <' WS-IND-NULL-ED '>' LK-NUM-ENDOSSO-WE001 '>' */

                $"NUM-ENDOSSO         <{WS_IND_NULL_ED}>{GEWEW001.LK_NUM_ENDOSSO_WE001}>"
                .Display();

                /*" -2562- MOVE LKN-COD-CANAL-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_CANAL_WE001, WS_IND_NULL_ED);

                /*" -2564- DISPLAY 'COD-CANAL           <' WS-IND-NULL-ED '>' LK-COD-CANAL-WE001 '>' */

                $"COD-CANAL           <{WS_IND_NULL_ED}>{GEWEW001.LK_COD_CANAL_WE001}>"
                .Display();

                /*" -2565- MOVE LKN-NUM-PARCELA-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_PARCELA_WE001, WS_IND_NULL_ED);

                /*" -2567- DISPLAY 'NUM-PARCELA         <' WS-IND-NULL-ED '>' LK-NUM-PARCELA-WE001 '>' */

                $"NUM-PARCELA         <{WS_IND_NULL_ED}>{GEWEW001.LK_NUM_PARCELA_WE001}>"
                .Display();

                /*" -2568- MOVE LKN-NUM-TOTAL-PARCELAS-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_TOTAL_PARCELAS_WE001, WS_IND_NULL_ED);

                /*" -2570- DISPLAY 'NUM-TOTAL-PARCELAS  <' WS-IND-NULL-ED '>' LK-NUM-TOTAL-PARCELAS-WE001 '>' */

                $"NUM-TOTAL-PARCELAS  <{WS_IND_NULL_ED}>{GEWEW001.LK_NUM_TOTAL_PARCELAS_WE001}>"
                .Display();

                /*" -2571- MOVE LKN-COD-FONTE-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_FONTE_WE001, WS_IND_NULL_ED);

                /*" -2573- DISPLAY 'COD-FONTE           <' WS-IND-NULL-ED '>' LK-COD-FONTE-WE001 '>' */

                $"COD-FONTE           <{WS_IND_NULL_ED}>{GEWEW001.LK_COD_FONTE_WE001}>"
                .Display();

                /*" -2574- MOVE LKN-COD-CENTRO-LUCRO-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_CENTRO_LUCRO_WE001, WS_IND_NULL_ED);

                /*" -2576- DISPLAY 'COD-CENTRO-LUCRO    <' WS-IND-NULL-ED '>' LK-COD-CENTRO-LUCRO-WE001 '>' */

                $"COD-CENTRO-LUCRO    <{WS_IND_NULL_ED}>{GEWEW001.LK_COD_CENTRO_LUCRO_WE001}>"
                .Display();

                /*" -2577- MOVE LKN-NUM-RAMO-SUSEP-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_RAMO_SUSEP_WE001, WS_IND_NULL_ED);

                /*" -2579- DISPLAY 'NUM-RAMO-SUSEP      <' WS-IND-NULL-ED '>' LK-NUM-RAMO-SUSEP-WE001 '>' */

                $"NUM-RAMO-SUSEP      <{WS_IND_NULL_ED}>{GEWEW001.LK_NUM_RAMO_SUSEP_WE001}>"
                .Display();

                /*" -2580- MOVE LKN-COD-TIPO-CONVENIO-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_TIPO_CONVENIO_WE001, WS_IND_NULL_ED);

                /*" -2582- DISPLAY 'COD-TIPO-CONVENIO   <' WS-IND-NULL-ED '>' LK-COD-TIPO-CONVENIO-WE001 '>' */

                $"COD-TIPO-CONVENIO   <{WS_IND_NULL_ED}>{GEWEW001.LK_COD_TIPO_CONVENIO_WE001}>"
                .Display();

                /*" -2583- MOVE LKN-COD-COMPROMISSO-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_COMPROMISSO_WE001, WS_IND_NULL_ED);

                /*" -2585- DISPLAY 'COD-COMPROMISSO     <' WS-IND-NULL-ED '>' LK-COD-COMPROMISSO-WE001 '>' */

                $"COD-COMPROMISSO     <{WS_IND_NULL_ED}>{GEWEW001.LK_COD_COMPROMISSO_WE001}>"
                .Display();

                /*" -2586- MOVE LKN-NUM-CERTIFICADO-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_CERTIFICADO_WE001, WS_IND_NULL_ED);

                /*" -2588- DISPLAY 'NUM-CERTIFICADO     <' WS-IND-NULL-ED '>' LK-NUM-CERTIFICADO-WE001 '>' */

                $"NUM-CERTIFICADO     <{WS_IND_NULL_ED}>{GEWEW001.LK_NUM_CERTIFICADO_WE001}>"
                .Display();

                /*" -2589- MOVE LKN-NUM-TITULO-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_TITULO_WE001, WS_IND_NULL_ED);

                /*" -2591- DISPLAY 'NUM-TITULO          <' WS-IND-NULL-ED '>' LK-NUM-TITULO-WE001 '>' */

                $"NUM-TITULO          <{WS_IND_NULL_ED}>{GEWEW001.LK_NUM_TITULO_WE001}>"
                .Display();

                /*" -2592- MOVE LKN-NUM-GRUPO-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_GRUPO_WE001, WS_IND_NULL_ED);

                /*" -2594- DISPLAY 'NUM-GRUPO           <' WS-IND-NULL-ED '>' LK-NUM-GRUPO-WE001 '>' */

                $"NUM-GRUPO           <{WS_IND_NULL_ED}>{GEWEW001.LK_NUM_GRUPO_WE001}>"
                .Display();

                /*" -2595- MOVE LKN-NUM-COTA-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_COTA_WE001, WS_IND_NULL_ED);

                /*" -2597- DISPLAY 'NUM-COTA            <' WS-IND-NULL-ED '>' LK-NUM-COTA-WE001 '>' */

                $"NUM-COTA            <{WS_IND_NULL_ED}>{GEWEW001.LK_NUM_COTA_WE001}>"
                .Display();

                /*" -2598- MOVE LKN-VLR-FUNDO-COMUM-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_VLR_FUNDO_COMUM_WE001, WS_IND_NULL_ED);

                /*" -2600- DISPLAY 'VLR-FUNDO-COMUM     <' WS-IND-NULL-ED '>' LK-VLR-FUNDO-COMUM-WE001 '>' */

                $"VLR-FUNDO-COMUM     <{WS_IND_NULL_ED}>{GEWEW001.LK_VLR_FUNDO_COMUM_WE001}>"
                .Display();

                /*" -2601- MOVE LKN-VLR-FUNDO-RESERVA-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_VLR_FUNDO_RESERVA_WE001, WS_IND_NULL_ED);

                /*" -2603- DISPLAY 'VLR-FUNDO-RESERVA   <' WS-IND-NULL-ED '>' LK-VLR-FUNDO-RESERVA-WE001 '>' */

                $"VLR-FUNDO-RESERVA   <{WS_IND_NULL_ED}>{GEWEW001.LK_VLR_FUNDO_RESERVA_WE001}>"
                .Display();

                /*" -2604- MOVE LKN-VLR-MULTA-JUROS-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_VLR_MULTA_JUROS_WE001, WS_IND_NULL_ED);

                /*" -2606- DISPLAY 'VLR-MULTA-JUROS     <' WS-IND-NULL-ED '>' LK-VLR-MULTA-JUROS-WE001 '>' */

                $"VLR-MULTA-JUROS     <{WS_IND_NULL_ED}>{GEWEW001.LK_VLR_MULTA_JUROS_WE001}>"
                .Display();

                /*" -2607- MOVE LKN-VLR-SEGURO-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_VLR_SEGURO_WE001, WS_IND_NULL_ED);

                /*" -2609- DISPLAY 'VLR-SEGURO          <' WS-IND-NULL-ED '>' LK-VLR-SEGURO-WE001 '>' */

                $"VLR-SEGURO          <{WS_IND_NULL_ED}>{GEWEW001.LK_VLR_SEGURO_WE001}>"
                .Display();

                /*" -2610- MOVE LKN-VLR-TAXA-ADMINISTRAC-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_VLR_TAXA_ADMINISTRAC_WE001, WS_IND_NULL_ED);

                /*" -2612- DISPLAY 'VLR-TAXA-ADMINISTRAC<' WS-IND-NULL-ED '>' LK-VLR-TAXA-ADMINISTRAC-WE001 '>' */

                $"VLR-TAXA-ADMINISTRAC<{WS_IND_NULL_ED}>{GEWEW001.LK_VLR_TAXA_ADMINISTRAC_WE001}>"
                .Display();

                /*" -2613- MOVE LKN-VLR-REPASS-MUL-JUROS-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_VLR_REPASS_MUL_JUROS_WE001, WS_IND_NULL_ED);

                /*" -2615- DISPLAY 'VLR-REPASS-MUL-JUROS<' WS-IND-NULL-ED '>' LK-VLR-REPASS-MUL-JUROS-WE001 '>' */

                $"VLR-REPASS-MUL-JUROS<{WS_IND_NULL_ED}>{GEWEW001.LK_VLR_REPASS_MUL_JUROS_WE001}>"
                .Display();

                /*" -2616- MOVE LKN-VLR-BOLETO-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_VLR_BOLETO_WE001, WS_IND_NULL_ED);

                /*" -2618- DISPLAY 'VLR-BOLETO          <' WS-IND-NULL-ED '>' LK-VLR-BOLETO-WE001 '>' */

                $"VLR-BOLETO          <{WS_IND_NULL_ED}>{GEWEW001.LK_VLR_BOLETO_WE001}>"
                .Display();

                /*" -2619- MOVE LKN-QTD-PERMANENCIA-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_QTD_PERMANENCIA_WE001, WS_IND_NULL_ED);

                /*" -2621- DISPLAY 'QTD-PERMANENCIA     <' WS-IND-NULL-ED '>' LK-QTD-PERMANENCIA-WE001 '>' */

                $"QTD-PERMANENCIA     <{WS_IND_NULL_ED}>{GEWEW001.LK_QTD_PERMANENCIA_WE001}>"
                .Display();

                /*" -2622- MOVE LKN-VLR-IOF-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_VLR_IOF_WE001, WS_IND_NULL_ED);

                /*" -2624- DISPLAY 'VLR-IOF             <' WS-IND-NULL-ED '>' LK-VLR-IOF-WE001 '>' */

                $"VLR-IOF             <{WS_IND_NULL_ED}>{GEWEW001.LK_VLR_IOF_WE001}>"
                .Display();

                /*" -2625- MOVE LKN-IND-REGISTRA-ONLINE-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_IND_REGISTRA_ONLINE_WE001, WS_IND_NULL_ED);

                /*" -2627- DISPLAY 'IND-REGISTRA-ONLINE <' WS-IND-NULL-ED '>' LK-IND-REGISTRA-ONLINE-WE001 '>' */

                $"IND-REGISTRA-ONLINE <{WS_IND_NULL_ED}>{GEWEW001.LK_IND_REGISTRA_ONLINE_WE001}>"
                .Display();

                /*" -2628- MOVE LKN-PCT-MULTA-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_PCT_MULTA_WE001, WS_IND_NULL_ED);

                /*" -2630- DISPLAY 'PCT-MULTA           <' WS-IND-NULL-ED '>' LK-PCT-MULTA-WE001 '>' */

                $"PCT-MULTA           <{WS_IND_NULL_ED}>{GEWEW001.LK_PCT_MULTA_WE001}>"
                .Display();

                /*" -2631- MOVE LKN-VLR-JUROS-DIA-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_VLR_JUROS_DIA_WE001, WS_IND_NULL_ED);

                /*" -2633- DISPLAY 'VLR-JUROS-DIA       <' WS-IND-NULL-ED '>' LK-VLR-JUROS-DIA-WE001 '>' */

                $"VLR-JUROS-DIA       <{WS_IND_NULL_ED}>{GEWEW001.LK_VLR_JUROS_DIA_WE001}>"
                .Display();

                /*" -2634- MOVE LKN-NOM-PESSOA-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NOM_PESSOA_WE001, WS_IND_NULL_ED);

                /*" -2636- DISPLAY 'NOM-PESSOA          <' WS-IND-NULL-ED '>' LK-NOM-PESSOA-WE001 '>' */

                $"NOM-PESSOA          <{WS_IND_NULL_ED}>{GEWEW001.LK_NOM_PESSOA_WE001}>"
                .Display();

                /*" -2637- MOVE LKN-NOM-ULTIMO-NOME-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NOM_ULTIMO_NOME_WE001, WS_IND_NULL_ED);

                /*" -2639- DISPLAY 'NOM-ULTIMO-NOME     <' WS-IND-NULL-ED '>' LK-NOM-ULTIMO-NOME-WE001 '>' */

                $"NOM-ULTIMO-NOME     <{WS_IND_NULL_ED}>{GEWEW001.LK_NOM_ULTIMO_NOME_WE001}>"
                .Display();

                /*" -2640- MOVE LKN-COD-FORMA-TRATAMENTO-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_FORMA_TRATAMENTO_WE001, WS_IND_NULL_ED);

                /*" -2642- DISPLAY 'COD-FORMA-TRATAMENTO<' WS-IND-NULL-ED '>' LK-COD-FORMA-TRATAMENTO-WE001 '>' */

                $"COD-FORMA-TRATAMENTO<{WS_IND_NULL_ED}>{GEWEW001.LK_COD_FORMA_TRATAMENTO_WE001}>"
                .Display();

                /*" -2643- MOVE LKN-COD-ENDERECO-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_ENDERECO_WE001, WS_IND_NULL_ED);

                /*" -2645- DISPLAY 'COD-ENDERECO        <' WS-IND-NULL-ED '>' LK-COD-ENDERECO-WE001 '>' */

                $"COD-ENDERECO        <{WS_IND_NULL_ED}>{GEWEW001.LK_COD_ENDERECO_WE001}>"
                .Display();

                /*" -2646- MOVE LKN-NUM-ENDERECO-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_ENDERECO_WE001, WS_IND_NULL_ED);

                /*" -2648- DISPLAY 'NUM-ENDERECO        <' WS-IND-NULL-ED '>' LK-NUM-ENDERECO-WE001 '>' */

                $"NUM-ENDERECO        <{WS_IND_NULL_ED}>{GEWEW001.LK_NUM_ENDERECO_WE001}>"
                .Display();

                /*" -2649- MOVE LKN-DES-ENDERECO-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_DES_ENDERECO_WE001, WS_IND_NULL_ED);

                /*" -2651- DISPLAY 'DES-ENDERECO        <' WS-IND-NULL-ED '>' LK-DES-ENDERECO-WE001 '>' */

                $"DES-ENDERECO        <{WS_IND_NULL_ED}>{GEWEW001.LK_DES_ENDERECO_WE001}>"
                .Display();

                /*" -2652- MOVE LKN-DES-COMPLEMENTO-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_DES_COMPLEMENTO_WE001, WS_IND_NULL_ED);

                /*" -2654- DISPLAY 'DES-COMPLEMENTO     <' WS-IND-NULL-ED '>' LK-DES-COMPLEMENTO-WE001 '>' */

                $"DES-COMPLEMENTO     <{WS_IND_NULL_ED}>{GEWEW001.LK_DES_COMPLEMENTO_WE001}>"
                .Display();

                /*" -2655- MOVE LKN-NOM-BAIRRO-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NOM_BAIRRO_WE001, WS_IND_NULL_ED);

                /*" -2657- DISPLAY 'NOM-BAIRRO          <' WS-IND-NULL-ED '>' LK-NOM-BAIRRO-WE001 '>' */

                $"NOM-BAIRRO          <{WS_IND_NULL_ED}>{GEWEW001.LK_NOM_BAIRRO_WE001}>"
                .Display();

                /*" -2658- MOVE LKN-NOM-CIDADE-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NOM_CIDADE_WE001, WS_IND_NULL_ED);

                /*" -2660- DISPLAY 'NOM-CIDADE          <' WS-IND-NULL-ED '>' LK-NOM-CIDADE-WE001 '>' */

                $"NOM-CIDADE          <{WS_IND_NULL_ED}>{GEWEW001.LK_NOM_CIDADE_WE001}>"
                .Display();

                /*" -2661- MOVE LKN-COD-UF-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_UF_WE001, WS_IND_NULL_ED);

                /*" -2663- DISPLAY 'COD-UF              <' WS-IND-NULL-ED '>' LK-COD-UF-WE001 '>' */

                $"COD-UF              <{WS_IND_NULL_ED}>{GEWEW001.LK_COD_UF_WE001}>"
                .Display();

                /*" -2664- MOVE LKN-NUM-CEP-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_CEP_WE001, WS_IND_NULL_ED);

                /*" -2666- DISPLAY 'NUM-CEP             <' WS-IND-NULL-ED '>' LK-NUM-CEP-WE001 '>' */

                $"NUM-CEP             <{WS_IND_NULL_ED}>{GEWEW001.LK_NUM_CEP_WE001}>"
                .Display();

                /*" -2667- MOVE LKN-IND-CONCILIA-SIGPF-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_IND_CONCILIA_SIGPF_WE001, WS_IND_NULL_ED);

                /*" -2669- DISPLAY 'IND-CONCILIA-SIGPF  <' WS-IND-NULL-ED '>' LK-IND-CONCILIA-SIGPF-WE001 '>' */

                $"IND-CONCILIA-SIGPF  <{WS_IND_NULL_ED}>{GEWEW001.LK_IND_CONCILIA_SIGPF_WE001}>"
                .Display();

                /*" -2670- MOVE LKN-COD-EVENTO-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_EVENTO_WE001, WS_IND_NULL_ED);

                /*" -2672- DISPLAY 'COD-EVENTO          <' WS-IND-NULL-ED '>' LK-COD-EVENTO-WE001 '>' */

                $"COD-EVENTO          <{WS_IND_NULL_ED}>{GEWEW001.LK_COD_EVENTO_WE001}>"
                .Display();

                /*" -2673- MOVE LKN-COD-IDENTIFICADOR-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_IDENTIFICADOR_WE001, WS_IND_NULL_ED);

                /*" -2675- DISPLAY 'COD-IDENTIFICADOR   <' WS-IND-NULL-ED '>' LK-COD-IDENTIFICADOR-WE001 '>' */

                $"COD-IDENTIFICADOR   <{WS_IND_NULL_ED}>{GEWEW001.LK_COD_IDENTIFICADOR_WE001}>"
                .Display();

                /*" -2676- MOVE LKN-DTA-DOCUMENTO-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_DTA_DOCUMENTO_WE001, WS_IND_NULL_ED);

                /*" -2678- DISPLAY 'DTA-DOCUMENTO       <' WS-IND-NULL-ED '>' LK-DTA-DOCUMENTO-WE001 '>' */

                $"DTA-DOCUMENTO       <{WS_IND_NULL_ED}>{GEWEW001.LK_DTA_DOCUMENTO_WE001}>"
                .Display();

                /*" -2679- MOVE LKN-DTA-LANCAM-DOCUMENTO-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_DTA_LANCAM_DOCUMENTO_WE001, WS_IND_NULL_ED);

                /*" -2681- DISPLAY 'DTA-LANCAM-DOCUMENTO<' WS-IND-NULL-ED '>' LK-DTA-LANCAM-DOCUMENTO-WE001 '>' */

                $"DTA-LANCAM-DOCUMENTO<{WS_IND_NULL_ED}>{GEWEW001.LK_DTA_LANCAM_DOCUMENTO_WE001}>"
                .Display();

                /*" -2682- MOVE LKN-DTA-VENCIMENTO-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_DTA_VENCIMENTO_WE001, WS_IND_NULL_ED);

                /*" -2684- DISPLAY 'DTA-VENCIMENTO      <' WS-IND-NULL-ED '>' LK-DTA-VENCIMENTO-WE001 '>' */

                $"DTA-VENCIMENTO      <{WS_IND_NULL_ED}>{GEWEW001.LK_DTA_VENCIMENTO_WE001}>"
                .Display();

                /*" -2685- MOVE LKN-NUM-CONTA-CONTRATO-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_CONTA_CONTRATO_WE001, WS_IND_NULL_ED);

                /*" -2687- DISPLAY 'NUM-CONTA-CONTRATO  <' WS-IND-NULL-ED '>' LK-NUM-CONTA-CONTRATO-WE001 '>' */

                $"NUM-CONTA-CONTRATO  <{WS_IND_NULL_ED}>{GEWEW001.LK_NUM_CONTA_CONTRATO_WE001}>"
                .Display();

                /*" -2688- MOVE LKN-NUM-CPF-CNPJ-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_CPF_CNPJ_WE001, WS_IND_NULL_ED);

                /*" -2690- DISPLAY 'NUM-CPF-CNPJ        <' WS-IND-NULL-ED '>' LK-NUM-CPF-CNPJ-WE001 '>' */

                $"NUM-CPF-CNPJ        <{WS_IND_NULL_ED}>{GEWEW001.LK_NUM_CPF_CNPJ_WE001}>"
                .Display();

                /*" -2691- MOVE LKN-COD-RETORNO-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_RETORNO_WE001, WS_IND_NULL_ED);

                /*" -2693- DISPLAY 'COD-RETORNO         <' WS-IND-NULL-ED '>' LK-COD-RETORNO-WE001 '>' */

                $"COD-RETORNO         <{WS_IND_NULL_ED}>{GEWEW001.LK_COD_RETORNO_WE001}>"
                .Display();

                /*" -2694- MOVE LKN-DES-MENS-SISTEMA-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_DES_MENS_SISTEMA_WE001, WS_IND_NULL_ED);

                /*" -2695- MOVE LK-DES-MENS-SISTEMA-LEN-WE001 TO WS-LENGTH-ED */
                _.Move(GEWEW001.LK_DES_MENS_SISTEMA_WE001.LK_DES_MENS_SISTEMA_LEN_WE001, WS_LENGTH_ED);

                /*" -2698- DISPLAY 'DES-MENS-SISTEMA    <' WS-IND-NULL-ED '>' WS-LENGTH-ED '>' LK-DES-MENS-SISTEMA-TXT-WE001 '>' */

                $"DES-MENS-SISTEMA    <{WS_IND_NULL_ED}>{WS_LENGTH_ED}>{GEWEW001.LK_DES_MENS_SISTEMA_WE001.LK_DES_MENS_SISTEMA_TXT_WE001}>"
                .Display();

                /*" -2699- MOVE LK-DES-MENS-AMIGAVE-LEN-WE001 TO WS-LENGTH-ED */
                _.Move(GEWEW001.LK_DES_MENS_AMIGAVE_WE001.LK_DES_MENS_AMIGAVE_LEN_WE001, WS_LENGTH_ED);

                /*" -2700- MOVE LKN-DES-MENS-AMIGAVE-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_DES_MENS_AMIGAVE_WE001, WS_IND_NULL_ED);

                /*" -2703- DISPLAY 'DES-MENS-AMIGAVE    <' WS-IND-NULL-ED '>' WS-LENGTH-ED '>' LK-DES-MENS-AMIGAVE-TXT-WE001 '>' */

                $"DES-MENS-AMIGAVE    <{WS_IND_NULL_ED}>{WS_LENGTH_ED}>{GEWEW001.LK_DES_MENS_AMIGAVE_WE001.LK_DES_MENS_AMIGAVE_TXT_WE001}>"
                .Display();

                /*" -2704- MOVE LKN-COD-ORIGEM-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_ORIGEM_WE001, WS_IND_NULL_ED);

                /*" -2706- DISPLAY 'COD-ORIGEM            <' WS-IND-NULL-ED '>' LK-COD-ORIGEM-WE001 '>' */

                $"COD-ORIGEM            <{WS_IND_NULL_ED}>{GEWEW001.LK_COD_ORIGEM_WE001}>"
                .Display();

                /*" -2707- MOVE LKN-COD-EMPRESA-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_EMPRESA_WE001, WS_IND_NULL_ED);

                /*" -2709- DISPLAY 'COD-EMPRESA         <' WS-IND-NULL-ED '>' LK-COD-EMPRESA-WE001 '>' */

                $"COD-EMPRESA         <{WS_IND_NULL_ED}>{GEWEW001.LK_COD_EMPRESA_WE001}>"
                .Display();

                /*" -2710- MOVE LKN-NUM-LOTE-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_LOTE_WE001, WS_IND_NULL_ED);

                /*" -2712- DISPLAY 'NUM-LOTE            <' WS-IND-NULL-ED '>' LK-NUM-LOTE-WE001 '>' */

                $"NUM-LOTE            <{WS_IND_NULL_ED}>{GEWEW001.LK_NUM_LOTE_WE001}>"
                .Display();

                /*" -2713- MOVE LKN-NUM-DOCUMENTO-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_DOCUMENTO_WE001, WS_IND_NULL_ED);

                /*" -2715- DISPLAY 'NUM-DOCUMENTO       <' WS-IND-NULL-ED '>' LK-NUM-DOCUMENTO-WE001 '>' */

                $"NUM-DOCUMENTO       <{WS_IND_NULL_ED}>{GEWEW001.LK_NUM_DOCUMENTO_WE001}>"
                .Display();

                /*" -2716- MOVE LKN-NUM-BOLETO-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_BOLETO_WE001, WS_IND_NULL_ED);

                /*" -2718- DISPLAY 'NUM-BOLETO          <' WS-IND-NULL-ED '>' LK-NUM-BOLETO-WE001 '>' */

                $"NUM-BOLETO          <{WS_IND_NULL_ED}>{GEWEW001.LK_NUM_BOLETO_WE001}>"
                .Display();

                /*" -2719- MOVE LKN-NUM-NOSSO-NUMERO-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_NOSSO_NUMERO_WE001, WS_IND_NULL_ED);

                /*" -2721- DISPLAY 'NUM-NOSSO-NUMERO    <' WS-IND-NULL-ED '>' LK-NUM-NOSSO-NUMERO-WE001 '>' */

                $"NUM-NOSSO-NUMERO    <{WS_IND_NULL_ED}>{GEWEW001.LK_NUM_NOSSO_NUMERO_WE001}>"
                .Display();

                /*" -2722- MOVE LKN-DES-LINHA-DIGITAVEL-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_DES_LINHA_DIGITAVEL_WE001, WS_IND_NULL_ED);

                /*" -2724- DISPLAY 'DES-LINHA-DIGITAVEL <' WS-IND-NULL-ED '>' LK-DES-LINHA-DIGITAVEL-WE001 '>' */

                $"DES-LINHA-DIGITAVEL <{WS_IND_NULL_ED}>{GEWEW001.LK_DES_LINHA_DIGITAVEL_WE001}>"
                .Display();

                /*" -2725- MOVE LKN-NUM-AGENCIA-CEDENTE-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_AGENCIA_CEDENTE_WE001, WS_IND_NULL_ED);

                /*" -2727- DISPLAY 'NUM-AGENCIA-CEDENTE <' WS-IND-NULL-ED '>' LK-NUM-AGENCIA-CEDENTE-WE001 '>' */

                $"NUM-AGENCIA-CEDENTE <{WS_IND_NULL_ED}>{GEWEW001.LK_NUM_AGENCIA_CEDENTE_WE001}>"
                .Display();

                /*" -2728- MOVE LKN-NUM-PARCEIRO-NEGOC-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_PARCEIRO_NEGOC_WE001, WS_IND_NULL_ED);

                /*" -2730- DISPLAY 'NUM-PARCEIRO-NEGOC  <' WS-IND-NULL-ED '>' LK-NUM-PARCEIRO-NEGOC-WE001 '>' */

                $"NUM-PARCEIRO-NEGOC  <{WS_IND_NULL_ED}>{GEWEW001.LK_NUM_PARCEIRO_NEGOC_WE001}>"
                .Display();

                /*" -2731- MOVE LKN-VLR-TOTAL-BOLETO-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_VLR_TOTAL_BOLETO_WE001, WS_IND_NULL_ED);

                /*" -2733- DISPLAY 'VLR-TOTAL-BOLETO    <' WS-IND-NULL-ED '>' LK-VLR-TOTAL-BOLETO-WE001 '>' */

                $"VLR-TOTAL-BOLETO    <{WS_IND_NULL_ED}>{GEWEW001.LK_VLR_TOTAL_BOLETO_WE001}>"
                .Display();

                /*" -2734- MOVE LKN-LST-MENSAGENS-CONT-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_LST_MENSAGENS_CONT_WE001, WS_IND_NULL_ED);

                /*" -2736- DISPLAY 'LST-MENSAGENS-CONT  <' WS-IND-NULL-ED '>' LK-LST-MENSAGENS-CONT-WE001 '>' */

                $"LST-MENSAGENS-CONT  <{WS_IND_NULL_ED}>{GEWEW001.LK_LST_MENSAGENS_CONT_WE001}>"
                .Display();

                /*" -2737- MOVE LK-COD-TIPO-LEN-WE001 TO WS-LENGTH-ED */
                _.Move(GEWEW001.LK_COD_TIPO_WE001.LK_COD_TIPO_LEN_WE001, WS_LENGTH_ED);

                /*" -2738- MOVE LKN-COD-TIPO-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_TIPO_WE001, WS_IND_NULL_ED);

                /*" -2741- DISPLAY 'COD-TIPO    <' WS-IND-NULL-ED '>' WS-LENGTH-ED '>' LK-COD-TIPO-TXT-WE001 '>' */

                $"COD-TIPO    <{WS_IND_NULL_ED}>{WS_LENGTH_ED}>{GEWEW001.LK_COD_TIPO_WE001.LK_COD_TIPO_TXT_WE001}>"
                .Display();

                /*" -2742- MOVE LKN-COD-MENSAGEM-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_MENSAGEM_WE001, WS_IND_NULL_ED);

                /*" -2744- DISPLAY 'COD-MENSAGEM        <' WS-IND-NULL-ED '>' LK-COD-MENSAGEM-WE001 '>' */

                $"COD-MENSAGEM        <{WS_IND_NULL_ED}>{GEWEW001.LK_COD_MENSAGEM_WE001}>"
                .Display();

                /*" -2745- MOVE LKN-NUM-MENSAGEM-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_MENSAGEM_WE001, WS_IND_NULL_ED);

                /*" -2747- DISPLAY 'NUM-MENSAGEM        <' WS-IND-NULL-ED '>' LK-NUM-MENSAGEM-WE001 '>' */

                $"NUM-MENSAGEM        <{WS_IND_NULL_ED}>{GEWEW001.LK_NUM_MENSAGEM_WE001}>"
                .Display();

                /*" -2748- MOVE LK-DES-MENSAGEM-LEN-WE001 TO WS-LENGTH-ED */
                _.Move(GEWEW001.LK_DES_MENSAGEM_WE001.LK_DES_MENSAGEM_LEN_WE001, WS_LENGTH_ED);

                /*" -2749- MOVE LKN-DES-MENSAGEM-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_DES_MENSAGEM_WE001, WS_IND_NULL_ED);

                /*" -2752- DISPLAY 'DES-MENSAGEM    <' WS-IND-NULL-ED '>' WS-LENGTH-ED '>' LK-DES-MENSAGEM-TXT-WE001 '>' */

                $"DES-MENSAGEM    <{WS_IND_NULL_ED}>{WS_LENGTH_ED}>{GEWEW001.LK_DES_MENSAGEM_WE001.LK_DES_MENSAGEM_TXT_WE001}>"
                .Display();

                /*" -2753- MOVE LK-DES-LOG-LEN-WE001 TO WS-LENGTH-ED */
                _.Move(GEWEW001.LK_DES_LOG_WE001.LK_DES_LOG_LEN_WE001, WS_LENGTH_ED);

                /*" -2754- MOVE LKN-DES-LOG-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_DES_LOG_WE001, WS_IND_NULL_ED);

                /*" -2757- DISPLAY 'DES-LOG    <' WS-IND-NULL-ED '>' WS-LENGTH-ED '>' LK-DES-LOG-TXT-WE001 '>' */

                $"DES-LOG    <{WS_IND_NULL_ED}>{WS_LENGTH_ED}>{GEWEW001.LK_DES_LOG_WE001.LK_DES_LOG_TXT_WE001}>"
                .Display();

                /*" -2758- MOVE LKN-SEQ-LOG-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_SEQ_LOG_WE001, WS_IND_NULL_ED);

                /*" -2760- DISPLAY 'SEQ-LOG             <' WS-IND-NULL-ED '>' LK-SEQ-LOG-WE001 '>' */

                $"SEQ-LOG             <{WS_IND_NULL_ED}>{GEWEW001.LK_SEQ_LOG_WE001}>"
                .Display();

                /*" -2761- MOVE LK-NOM-PARAMETRO-LEN-WE001 TO WS-LENGTH-ED */
                _.Move(GEWEW001.LK_NOM_PARAMETRO_WE001.LK_NOM_PARAMETRO_LEN_WE001, WS_LENGTH_ED);

                /*" -2762- MOVE LKN-NOM-PARAMETRO-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NOM_PARAMETRO_WE001, WS_IND_NULL_ED);

                /*" -2765- DISPLAY 'NOM-PARAMETRO    <' WS-IND-NULL-ED '>' WS-LENGTH-ED '>' LK-NOM-PARAMETRO-TXT-WE001 '>' */

                $"NOM-PARAMETRO    <{WS_IND_NULL_ED}>{WS_LENGTH_ED}>{GEWEW001.LK_NOM_PARAMETRO_WE001.LK_NOM_PARAMETRO_TXT_WE001}>"
                .Display();

                /*" -2766- MOVE LKN-NUM-LINHA-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_LINHA_WE001, WS_IND_NULL_ED);

                /*" -2768- DISPLAY 'NUM-LINHA           <' WS-IND-NULL-ED '>' LK-NUM-LINHA-WE001 '>' */

                $"NUM-LINHA           <{WS_IND_NULL_ED}>{GEWEW001.LK_NUM_LINHA_WE001}>"
                .Display();

                /*" -2769- MOVE LK-NOM-CAMPO-LEN-WE001 TO WS-LENGTH-ED */
                _.Move(GEWEW001.LK_NOM_CAMPO_WE001.LK_NOM_CAMPO_LEN_WE001, WS_LENGTH_ED);

                /*" -2770- MOVE LKN-NOM-CAMPO-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NOM_CAMPO_WE001, WS_IND_NULL_ED);

                /*" -2773- DISPLAY 'NOM-CAMPO    <' WS-IND-NULL-ED '>' WS-LENGTH-ED '>' LK-NOM-CAMPO-TXT-WE001 '>' */

                $"NOM-CAMPO    <{WS_IND_NULL_ED}>{WS_LENGTH_ED}>{GEWEW001.LK_NOM_CAMPO_WE001.LK_NOM_CAMPO_TXT_WE001}>"
                .Display();

                /*" -2774- MOVE LK-NOM-SISTEMA-LEN-WE001 TO WS-LENGTH-ED */
                _.Move(GEWEW001.LK_NOM_SISTEMA_WE001.LK_NOM_SISTEMA_LEN_WE001, WS_LENGTH_ED);

                /*" -2775- MOVE LKN-NOM-SISTEMA-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NOM_SISTEMA_WE001, WS_IND_NULL_ED);

                /*" -2778- DISPLAY 'NOM-SISTEMA    <' WS-IND-NULL-ED '>' WS-LENGTH-ED '>' LK-NOM-SISTEMA-TXT-WE001 '>' */

                $"NOM-SISTEMA    <{WS_IND_NULL_ED}>{WS_LENGTH_ED}>{GEWEW001.LK_NOM_SISTEMA_WE001.LK_NOM_SISTEMA_TXT_WE001}>"
                .Display();

                /*" -2779- MOVE LKN-IND-ERRO-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_IND_ERRO_WE001, WS_IND_NULL_ED);

                /*" -2781- DISPLAY 'IND-ERRO            <' WS-IND-NULL-ED '>' LK-IND-ERRO-WE001 '>' */

                $"IND-ERRO            <{WS_IND_NULL_ED}>{GEWEW001.LK_IND_ERRO_WE001}>"
                .Display();

                /*" -2782- MOVE LKN-MSG-RET-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_MSG_RET_WE001, WS_IND_NULL_ED);

                /*" -2784- DISPLAY 'MSG-RET             <' WS-IND-NULL-ED '>' LK-MSG-RET-WE001 '>' */

                $"MSG-RET             <{WS_IND_NULL_ED}>{GEWEW001.LK_MSG_RET_WE001}>"
                .Display();

                /*" -2785- MOVE LKN-NM-TAB-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NM_TAB_WE001, WS_IND_NULL_ED);

                /*" -2787- DISPLAY 'NM-TAB              <' WS-IND-NULL-ED '>' LK-NM-TAB-WE001 '>' */

                $"NM-TAB              <{WS_IND_NULL_ED}>{GEWEW001.LK_NM_TAB_WE001}>"
                .Display();

                /*" -2788- MOVE LKN-SQLCODE-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_SQLCODE_WE001, WS_IND_NULL_ED);

                /*" -2789- MOVE LK-SQLCODE-WE001 TO WS-SQLCODE-ED */
                _.Move(GEWEW001.LK_SQLCODE_WE001, WS_SQLCODE_ED);

                /*" -2791- DISPLAY 'SQLCODE             <' WS-IND-NULL-ED '>' WS-SQLCODE-ED '>' */

                $"SQLCODE             <{WS_IND_NULL_ED}>{WS_SQLCODE_ED}>"
                .Display();

                /*" -2792- MOVE LKN-SQLERRMC-WE001 TO WS-IND-NULL-ED */
                _.Move(GEWEW001.LKN_VALORES_NULOS_WE001.LKN_SQLERRMC_WE001, WS_IND_NULL_ED);

                /*" -2794- DISPLAY 'SQLERRMC            <' WS-IND-NULL-ED '>' LK-SQLERRMC-WE001 '>' */

                $"SQLERRMC            <{WS_IND_NULL_ED}>{GEWEW001.LK_SQLERRMC_WE001}>"
                .Display();

                /*" -2796- DISPLAY '----------------------------------------------' */
                _.Display($"----------------------------------------------");

                /*" -2797- MOVE '1' TO LK-GE350-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO);

                /*" -2800- MOVE LK-DES-MENSAGEM-TXT-WE001(01:75) TO LK-GE350-MSG-RETORNO */
                _.Move(GEWEW001.LK_DES_MENSAGEM_WE001.LK_DES_MENSAGEM_TXT_WE001.Substring(1, 75), REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                /*" -2801- IF WS-RAMO-EMISSOR EQUAL 31 OR 53 */

                if (AREA_DE_WORK.FILLER_2.WS_RAMO_EMISSOR.In("31", "53"))
                {

                    /*" -2802- DISPLAY 'ERRO RETORNO AUTO ' LK-COD-RETORNO-WE001 */
                    _.Display($"ERRO RETORNO AUTO {GEWEW001.LK_COD_RETORNO_WE001}");

                    /*" -2803- DISPLAY 'DESCRICAO MSG' LK-COD-MENSAGEM-TXT-WE001(1:20) */
                    _.Display($"DESCRICAO MSG{GEWEW001.LK_COD_MENSAGEM_WE001.LK_COD_MENSAGEM_TXT_WE001.Substring(1, 20)}");

                    /*" -2804- IF LK-COD-RETORNO-WE001 = SPACES */

                    if (GEWEW001.LK_COD_RETORNO_WE001.IsEmpty())
                    {

                        /*" -2805- MOVE '9' TO LK-GE350-COD-RETORNO */
                        _.Move("9", REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO);

                        /*" -2806- MOVE SPACES TO WS-MENS-DESCR */
                        _.Move("", AREA_DE_WORK.WS_MENS.WS_MENS_DESCR);

                        /*" -2807- IF LK-GE350-COD-USUARIO EQUAL 'SPBCM027' */

                        if (REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_USUARIO == "SPBCM027")
                        {

                            /*" -2810- STRING 'SERVICO INDISPONIVEL NO MOMENTO. ENTRAR ' 'EM CONTATO COM A CENTRAL!' DELIMITED BY SIZE INTO WS-MENS-DESCR */
                            #region STRING
                            var spl2 = "SERVICO INDISPONIVEL NO MOMENTO. ENTRAR " + "EM CONTATO COM A CENTRAL!";
                            _.Move(spl2, AREA_DE_WORK.WS_MENS.WS_MENS_DESCR);
                            #endregion

                            /*" -2812- MOVE WS-MENS-DESCR TO LK-GE350-MSG-RETORNO */
                            _.Move(AREA_DE_WORK.WS_MENS.WS_MENS_DESCR, REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                            /*" -2813- ELSE */
                        }
                        else
                        {


                            /*" -2815- STRING 'RETORNO IMPREVISTO DO BARRAMENTO/CICS/' 'SAP' DELIMITED BY SIZE INTO WS-MENS-DESCR */
                            #region STRING
                            var spl3 = "RETORNO IMPREVISTO DO BARRAMENTO/CICS/" + "SAP";
                            _.Move(spl3, AREA_DE_WORK.WS_MENS.WS_MENS_DESCR);
                            #endregion

                            /*" -2817- MOVE LK-COD-MENSAGEM-TXT-WE001(5:11) TO WS-MENS-CAMPO */
                            _.Move(GEWEW001.LK_COD_MENSAGEM_WE001.LK_COD_MENSAGEM_TXT_WE001.Substring(5, 11), AREA_DE_WORK.WS_MENS.WS_MENS_CAMPO);

                            /*" -2818- MOVE WS-MENS TO LK-GE350-MSG-RETORNO */
                            _.Move(AREA_DE_WORK.WS_MENS, REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                            /*" -2819- END-IF */
                        }


                        /*" -2820- ELSE */
                    }
                    else
                    {


                        /*" -2821- IF LK-COD-RETORNO-WE001 = '99' */

                        if (GEWEW001.LK_COD_RETORNO_WE001 == "99")
                        {

                            /*" -2822- MOVE '8' TO LK-GE350-COD-RETORNO */
                            _.Move("8", REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO);

                            /*" -2823- MOVE SPACES TO WS-MENS-DESCR */
                            _.Move("", AREA_DE_WORK.WS_MENS.WS_MENS_DESCR);

                            /*" -2824- IF LK-GE350-COD-USUARIO EQUAL 'SPBCM027' */

                            if (REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_USUARIO == "SPBCM027")
                            {

                                /*" -2827- STRING 'SERVICO NAO ESTA RESPONDENDO. ENTRAR ' 'EM CONTATO COM A CENTRAL!' DELIMITED BY SIZE INTO WS-MENS-DESCR */
                                #region STRING
                                var spl4 = "SERVICO NAO ESTA RESPONDENDO. ENTRAR " + "EM CONTATO COM A CENTRAL!";
                                _.Move(spl4, AREA_DE_WORK.WS_MENS.WS_MENS_DESCR);
                                #endregion

                                /*" -2828- MOVE WS-MENS-DESCR TO LK-GE350-MSG-RETORNO */
                                _.Move(AREA_DE_WORK.WS_MENS.WS_MENS_DESCR, REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                                /*" -2829- ELSE */
                            }
                            else
                            {


                                /*" -2831- STRING 'RETORNO COM INSUCESSO!' DELIMITED BY SIZE INTO WS-MENS-DESCR */
                                #region STRING
                                var spl5 = "RETORNO COM INSUCESSO!";
                                _.Move(spl5, AREA_DE_WORK.WS_MENS.WS_MENS_DESCR);
                                #endregion

                                /*" -2833- MOVE LK-COD-MENSAGEM-TXT-WE001(5:11) TO WS-MENS-CAMPO */
                                _.Move(GEWEW001.LK_COD_MENSAGEM_WE001.LK_COD_MENSAGEM_TXT_WE001.Substring(5, 11), AREA_DE_WORK.WS_MENS.WS_MENS_CAMPO);

                                /*" -2834- MOVE WS-MENS TO LK-GE350-MSG-RETORNO */
                                _.Move(AREA_DE_WORK.WS_MENS, REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                                /*" -2835- END-IF */
                            }


                            /*" -2836- END-IF */
                        }


                        /*" -2837- END-IF */
                    }


                    /*" -2838- END-IF */
                }


                /*" -2839- DISPLAY 'XXXXX- FIM DA GE350S -XXXX' */
                _.Display($"XXXXX- FIM DA GE350S -XXXX");

                /*" -2840- GO TO RXXXX-ROTINA-RETORNO */

                RXXXX_ROTINA_RETORNO_SECTION(); //GOTO
                return;

                /*" -2841- ELSE */
            }
            else
            {


                /*" -2842- IF LK-COD-TIPO-CONVENIO-WE001 = 'R' */

                if (GEWEW001.LK_COD_TIPO_CONVENIO_WE001 == "R")
                {

                    /*" -2843- MOVE 'O' TO LK-GE350-COD-SITUACAO */
                    _.Move("O", REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO);

                    /*" -2845- MOVE LK-NUM-AGENCIA-CEDENTE-WE001(1:13) TO LK-GE350-COD-CEDENTE-SAP */
                    _.Move(GEWEW001.LK_NUM_AGENCIA_CEDENTE_WE001.Substring(1, 13), REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_CEDENTE_SAP);

                    /*" -2846- MOVE LK-NUM-BOLETO-WE001 TO LK-GE350-NUM-BLTO-INTERNO */
                    _.Move(GEWEW001.LK_NUM_BOLETO_WE001, REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_BLTO_INTERNO);

                    /*" -2848- MOVE LK-NUM-NOSSO-NUMERO-WE001(01:18) TO LK-GE350-NOSSO-NUMERO-SAP */
                    _.Move(GEWEW001.LK_NUM_NOSSO_NUMERO_WE001.Substring(1, 18), REGISTRO_LINKAGE_GE0350S.LK_GE350_NOSSO_NUMERO_SAP);

                    /*" -2850- MOVE LK-DES-LINHA-DIGITAVEL-WE001 TO LK-GE350-COD-LINHA-DGTVEL */
                    _.Move(GEWEW001.LK_DES_LINHA_DIGITAVEL_WE001, REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_LINHA_DGTVEL);

                    /*" -2851- IF LK-IND-REGISTRA-ONLINE-WE001 EQUAL 'N' */

                    if (GEWEW001.LK_IND_REGISTRA_ONLINE_WE001 == "N")
                    {

                        /*" -2852- MOVE 'A' TO LK-GE350-COD-SITUACAO */
                        _.Move("A", REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO);

                        /*" -2853- END-IF */
                    }


                    /*" -2854- ELSE */
                }
                else
                {


                    /*" -2855- MOVE 'C' TO LK-GE350-COD-SITUACAO */
                    _.Move("C", REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO);

                    /*" -2857- END-IF */
                }


                /*" -2859- MOVE SPACES TO LK-GE350-COD-REJEICAO */
                _.Move("", REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_REJEICAO);

                /*" -2860- PERFORM R2000-SOLICITA-NOVO-NN-SAP */

                R2000_SOLICITA_NOVO_NN_SAP_SECTION();

                /*" -2861- END-IF */
            }


            /*" -2861- . */

        }

        [StopWatch]
        /*" R7000-SOLICITA-NN-CICS-SIAS-DB-CALL-1 */
        public void R7000_SOLICITA_NN_CICS_SIAS_DB_CALL_1()
        {
            /*" -2494- EXEC SQL CALL GEWES001 ( :LK-COD-SISTEMA-WE001 :LKN-COD-SISTEMA-WE001 , :LK-NUM-PROPOSTA-WE001 :LKN-NUM-PROPOSTA-WE001 , :LK-NUM-APOLICE-WE001 :LKN-NUM-APOLICE-WE001 , :LK-NUM-ENDOSSO-WE001 :LKN-NUM-ENDOSSO-WE001 , :LK-COD-CANAL-WE001 :LKN-COD-CANAL-WE001 , :LK-NUM-PARCELA-WE001 :LKN-NUM-PARCELA-WE001 , :LK-NUM-TOTAL-PARCELAS-WE001 :LKN-NUM-TOTAL-PARCELAS-WE001 , :LK-COD-FONTE-WE001 :LKN-COD-FONTE-WE001 , :LK-COD-CENTRO-LUCRO-WE001 :LKN-COD-CENTRO-LUCRO-WE001 , :LK-NUM-RAMO-SUSEP-WE001 :LKN-NUM-RAMO-SUSEP-WE001 , :LK-COD-TIPO-CONVENIO-WE001 :LKN-COD-TIPO-CONVENIO-WE001 , :LK-COD-COMPROMISSO-WE001 :LKN-COD-COMPROMISSO-WE001 , :LK-NUM-CERTIFICADO-WE001 :LKN-NUM-CERTIFICADO-WE001 , :LK-NUM-TITULO-WE001 :LKN-NUM-TITULO-WE001 , :LK-NUM-GRUPO-WE001 :LKN-NUM-GRUPO-WE001 , :LK-NUM-COTA-WE001 :LKN-NUM-COTA-WE001 , :LK-VLR-FUNDO-COMUM-WE001 :LKN-VLR-FUNDO-COMUM-WE001 , :LK-VLR-FUNDO-RESERVA-WE001 :LKN-VLR-FUNDO-RESERVA-WE001 , :LK-VLR-MULTA-JUROS-WE001 :LKN-VLR-MULTA-JUROS-WE001 , :LK-VLR-SEGURO-WE001 :LKN-VLR-SEGURO-WE001 , :LK-VLR-TAXA-ADMINISTRAC-WE001 :LKN-VLR-TAXA-ADMINISTRAC-WE001 , :LK-VLR-REPASS-MUL-JUROS-WE001 :LKN-VLR-REPASS-MUL-JUROS-WE001 , :LK-VLR-BOLETO-WE001 :LKN-VLR-BOLETO-WE001 , :LK-QTD-PERMANENCIA-WE001 :LKN-QTD-PERMANENCIA-WE001 , :LK-VLR-IOF-WE001 :LKN-VLR-IOF-WE001 , :LK-IND-REGISTRA-ONLINE-WE001 :LKN-IND-REGISTRA-ONLINE-WE001 , :LK-PCT-MULTA-WE001 :LKN-PCT-MULTA-WE001 , :LK-VLR-JUROS-DIA-WE001 :LKN-VLR-JUROS-DIA-WE001 , :LK-NOM-PESSOA-WE001 :LKN-NOM-PESSOA-WE001 , :LK-NOM-ULTIMO-NOME-WE001 :LKN-NOM-ULTIMO-NOME-WE001 , :LK-COD-FORMA-TRATAMENTO-WE001 :LKN-COD-FORMA-TRATAMENTO-WE001 , :LK-COD-ENDERECO-WE001 :LKN-COD-ENDERECO-WE001 , :LK-NUM-ENDERECO-WE001 :LKN-NUM-ENDERECO-WE001 , :LK-DES-ENDERECO-WE001 :LKN-DES-ENDERECO-WE001 , :LK-DES-COMPLEMENTO-WE001 :LKN-DES-COMPLEMENTO-WE001 , :LK-NOM-BAIRRO-WE001 :LKN-NOM-BAIRRO-WE001 , :LK-NOM-CIDADE-WE001 :LKN-NOM-CIDADE-WE001 , :LK-COD-UF-WE001 :LKN-COD-UF-WE001 , :LK-NUM-CEP-WE001 :LKN-NUM-CEP-WE001 , :LK-IND-CONCILIA-SIGPF-WE001 :LKN-IND-CONCILIA-SIGPF-WE001 , :LK-COD-EVENTO-WE001 :LKN-COD-EVENTO-WE001 , :LK-COD-IDENTIFICADOR-WE001 :LKN-COD-IDENTIFICADOR-WE001 , :LK-DTA-DOCUMENTO-WE001 :LKN-DTA-DOCUMENTO-WE001 , :LK-DTA-LANCAM-DOCUMENTO-WE001 :LKN-DTA-LANCAM-DOCUMENTO-WE001 , :LK-DTA-VENCIMENTO-WE001 :LKN-DTA-VENCIMENTO-WE001 , :LK-NUM-CONTA-CONTRATO-WE001 :LKN-NUM-CONTA-CONTRATO-WE001 , :LK-NUM-CPF-CNPJ-WE001 :LKN-NUM-CPF-CNPJ-WE001 , :LK-COD-RETORNO-WE001 :LKN-COD-RETORNO-WE001 , :LK-DES-MENS-SISTEMA-WE001 :LKN-DES-MENS-SISTEMA-WE001 , :LK-DES-MENS-AMIGAVE-WE001 :LKN-DES-MENS-AMIGAVE-WE001 , :LK-COD-ORIGEM-WE001 :LKN-COD-ORIGEM-WE001 , :LK-COD-EMPRESA-WE001 :LKN-COD-EMPRESA-WE001 , :LK-NUM-LOTE-WE001 :LKN-NUM-LOTE-WE001 , :LK-NUM-DOCUMENTO-WE001 :LKN-NUM-DOCUMENTO-WE001 , :LK-NUM-BOLETO-WE001 :LKN-NUM-BOLETO-WE001 , :LK-NUM-NOSSO-NUMERO-WE001 :LKN-NUM-NOSSO-NUMERO-WE001 , :LK-DES-LINHA-DIGITAVEL-WE001 :LKN-DES-LINHA-DIGITAVEL-WE001 , :LK-NUM-AGENCIA-CEDENTE-WE001 :LKN-NUM-AGENCIA-CEDENTE-WE001 , :LK-NUM-PARCEIRO-NEGOC-WE001 :LKN-NUM-PARCEIRO-NEGOC-WE001 , :LK-VLR-TOTAL-BOLETO-WE001 :LKN-VLR-TOTAL-BOLETO-WE001 , :LK-LST-MENSAGENS-CONT-WE001 :LKN-LST-MENSAGENS-CONT-WE001 , :LK-COD-TIPO-WE001 :LKN-COD-TIPO-WE001 , :LK-COD-MENSAGEM-WE001 :LKN-COD-MENSAGEM-WE001 , :LK-NUM-MENSAGEM-WE001 :LKN-NUM-MENSAGEM-WE001 , :LK-DES-MENSAGEM-WE001 :LKN-DES-MENSAGEM-WE001 , :LK-DES-LOG-WE001 :LKN-DES-LOG-WE001 , :LK-SEQ-LOG-WE001 :LKN-SEQ-LOG-WE001 , :LK-NOM-PARAMETRO-WE001 :LKN-NOM-PARAMETRO-WE001 , :LK-NUM-LINHA-WE001 :LKN-NUM-LINHA-WE001 , :LK-NOM-CAMPO-WE001 :LKN-NOM-CAMPO-WE001 , :LK-NOM-SISTEMA-WE001 :LKN-NOM-SISTEMA-WE001 , :LK-IND-ERRO-WE001 :LKN-IND-ERRO-WE001 , :LK-MSG-RET-WE001 :LKN-MSG-RET-WE001 , :LK-NM-TAB-WE001 :LKN-NM-TAB-WE001 , :LK-SQLCODE-WE001 :LKN-SQLCODE-WE001 , :LK-SQLERRMC-WE001 :LKN-SQLERRMC-WE001 ) END-EXEC. */

            var gEWES001_Call1 = new GEWES001_Call1()
            {
                LK_COD_SISTEMA_WE001 = GEWEW001.LK_COD_SISTEMA_WE001.ToString(),
                LKN_COD_SISTEMA_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_SISTEMA_WE001.ToString(),
                LK_NUM_PROPOSTA_WE001 = GEWEW001.LK_NUM_PROPOSTA_WE001.ToString(),
                LKN_NUM_PROPOSTA_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_PROPOSTA_WE001.ToString(),
                LK_NUM_APOLICE_WE001 = GEWEW001.LK_NUM_APOLICE_WE001.ToString(),
                LKN_NUM_APOLICE_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_APOLICE_WE001.ToString(),
                LK_NUM_ENDOSSO_WE001 = GEWEW001.LK_NUM_ENDOSSO_WE001.ToString(),
                LKN_NUM_ENDOSSO_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_ENDOSSO_WE001.ToString(),
                LK_COD_CANAL_WE001 = GEWEW001.LK_COD_CANAL_WE001.ToString(),
                LKN_COD_CANAL_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_CANAL_WE001.ToString(),
                LK_NUM_PARCELA_WE001 = GEWEW001.LK_NUM_PARCELA_WE001.ToString(),
                LKN_NUM_PARCELA_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_PARCELA_WE001.ToString(),
                LK_NUM_TOTAL_PARCELAS_WE001 = GEWEW001.LK_NUM_TOTAL_PARCELAS_WE001.ToString(),
                LKN_NUM_TOTAL_PARCELAS_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_TOTAL_PARCELAS_WE001.ToString(),
                LK_COD_FONTE_WE001 = GEWEW001.LK_COD_FONTE_WE001.ToString(),
                LKN_COD_FONTE_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_FONTE_WE001.ToString(),
                LK_COD_CENTRO_LUCRO_WE001 = GEWEW001.LK_COD_CENTRO_LUCRO_WE001.ToString(),
                LKN_COD_CENTRO_LUCRO_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_CENTRO_LUCRO_WE001.ToString(),
                LK_NUM_RAMO_SUSEP_WE001 = GEWEW001.LK_NUM_RAMO_SUSEP_WE001.ToString(),
                LKN_NUM_RAMO_SUSEP_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_RAMO_SUSEP_WE001.ToString(),
                LK_COD_TIPO_CONVENIO_WE001 = GEWEW001.LK_COD_TIPO_CONVENIO_WE001.ToString(),
                LKN_COD_TIPO_CONVENIO_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_TIPO_CONVENIO_WE001.ToString(),
                LK_COD_COMPROMISSO_WE001 = GEWEW001.LK_COD_COMPROMISSO_WE001.ToString(),
                LKN_COD_COMPROMISSO_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_COMPROMISSO_WE001.ToString(),
                LK_NUM_CERTIFICADO_WE001 = GEWEW001.LK_NUM_CERTIFICADO_WE001.ToString(),
                LKN_NUM_CERTIFICADO_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_CERTIFICADO_WE001.ToString(),
                LK_NUM_TITULO_WE001 = GEWEW001.LK_NUM_TITULO_WE001.ToString(),
                LKN_NUM_TITULO_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_TITULO_WE001.ToString(),
                LK_NUM_GRUPO_WE001 = GEWEW001.LK_NUM_GRUPO_WE001.ToString(),
                LKN_NUM_GRUPO_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_GRUPO_WE001.ToString(),
                LK_NUM_COTA_WE001 = GEWEW001.LK_NUM_COTA_WE001.ToString(),
                LKN_NUM_COTA_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_COTA_WE001.ToString(),
                LK_VLR_FUNDO_COMUM_WE001 = GEWEW001.LK_VLR_FUNDO_COMUM_WE001.ToString(),
                LKN_VLR_FUNDO_COMUM_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_VLR_FUNDO_COMUM_WE001.ToString(),
                LK_VLR_FUNDO_RESERVA_WE001 = GEWEW001.LK_VLR_FUNDO_RESERVA_WE001.ToString(),
                LKN_VLR_FUNDO_RESERVA_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_VLR_FUNDO_RESERVA_WE001.ToString(),
                LK_VLR_MULTA_JUROS_WE001 = GEWEW001.LK_VLR_MULTA_JUROS_WE001.ToString(),
                LKN_VLR_MULTA_JUROS_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_VLR_MULTA_JUROS_WE001.ToString(),
                LK_VLR_SEGURO_WE001 = GEWEW001.LK_VLR_SEGURO_WE001.ToString(),
                LKN_VLR_SEGURO_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_VLR_SEGURO_WE001.ToString(),
                LK_VLR_TAXA_ADMINISTRAC_WE001 = GEWEW001.LK_VLR_TAXA_ADMINISTRAC_WE001.ToString(),
                LKN_VLR_TAXA_ADMINISTRAC_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_VLR_TAXA_ADMINISTRAC_WE001.ToString(),
                LK_VLR_REPASS_MUL_JUROS_WE001 = GEWEW001.LK_VLR_REPASS_MUL_JUROS_WE001.ToString(),
                LKN_VLR_REPASS_MUL_JUROS_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_VLR_REPASS_MUL_JUROS_WE001.ToString(),
                LK_VLR_BOLETO_WE001 = GEWEW001.LK_VLR_BOLETO_WE001.ToString(),
                LKN_VLR_BOLETO_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_VLR_BOLETO_WE001.ToString(),
                LK_QTD_PERMANENCIA_WE001 = GEWEW001.LK_QTD_PERMANENCIA_WE001.ToString(),
                LKN_QTD_PERMANENCIA_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_QTD_PERMANENCIA_WE001.ToString(),
                LK_VLR_IOF_WE001 = GEWEW001.LK_VLR_IOF_WE001.ToString(),
                LKN_VLR_IOF_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_VLR_IOF_WE001.ToString(),
                LK_IND_REGISTRA_ONLINE_WE001 = GEWEW001.LK_IND_REGISTRA_ONLINE_WE001.ToString(),
                LKN_IND_REGISTRA_ONLINE_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_IND_REGISTRA_ONLINE_WE001.ToString(),
                LK_PCT_MULTA_WE001 = GEWEW001.LK_PCT_MULTA_WE001.ToString(),
                LKN_PCT_MULTA_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_PCT_MULTA_WE001.ToString(),
                LK_VLR_JUROS_DIA_WE001 = GEWEW001.LK_VLR_JUROS_DIA_WE001.ToString(),
                LKN_VLR_JUROS_DIA_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_VLR_JUROS_DIA_WE001.ToString(),
                LK_NOM_PESSOA_WE001 = GEWEW001.LK_NOM_PESSOA_WE001.ToString(),
                LKN_NOM_PESSOA_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NOM_PESSOA_WE001.ToString(),
                LK_NOM_ULTIMO_NOME_WE001 = GEWEW001.LK_NOM_ULTIMO_NOME_WE001.ToString(),
                LKN_NOM_ULTIMO_NOME_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NOM_ULTIMO_NOME_WE001.ToString(),
                LK_COD_FORMA_TRATAMENTO_WE001 = GEWEW001.LK_COD_FORMA_TRATAMENTO_WE001.ToString(),
                LKN_COD_FORMA_TRATAMENTO_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_FORMA_TRATAMENTO_WE001.ToString(),
                LK_COD_ENDERECO_WE001 = GEWEW001.LK_COD_ENDERECO_WE001.ToString(),
                LKN_COD_ENDERECO_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_ENDERECO_WE001.ToString(),
                LK_NUM_ENDERECO_WE001 = GEWEW001.LK_NUM_ENDERECO_WE001.ToString(),
                LKN_NUM_ENDERECO_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_ENDERECO_WE001.ToString(),
                LK_DES_ENDERECO_WE001 = GEWEW001.LK_DES_ENDERECO_WE001.ToString(),
                LKN_DES_ENDERECO_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_DES_ENDERECO_WE001.ToString(),
                LK_DES_COMPLEMENTO_WE001 = GEWEW001.LK_DES_COMPLEMENTO_WE001.ToString(),
                LKN_DES_COMPLEMENTO_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_DES_COMPLEMENTO_WE001.ToString(),
                LK_NOM_BAIRRO_WE001 = GEWEW001.LK_NOM_BAIRRO_WE001.ToString(),
                LKN_NOM_BAIRRO_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NOM_BAIRRO_WE001.ToString(),
                LK_NOM_CIDADE_WE001 = GEWEW001.LK_NOM_CIDADE_WE001.ToString(),
                LKN_NOM_CIDADE_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NOM_CIDADE_WE001.ToString(),
                LK_COD_UF_WE001 = GEWEW001.LK_COD_UF_WE001.ToString(),
                LKN_COD_UF_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_UF_WE001.ToString(),
                LK_NUM_CEP_WE001 = GEWEW001.LK_NUM_CEP_WE001.ToString(),
                LKN_NUM_CEP_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_CEP_WE001.ToString(),
                LK_IND_CONCILIA_SIGPF_WE001 = GEWEW001.LK_IND_CONCILIA_SIGPF_WE001.ToString(),
                LKN_IND_CONCILIA_SIGPF_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_IND_CONCILIA_SIGPF_WE001.ToString(),
                LK_COD_EVENTO_WE001 = GEWEW001.LK_COD_EVENTO_WE001.ToString(),
                LKN_COD_EVENTO_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_EVENTO_WE001.ToString(),
                LK_COD_IDENTIFICADOR_WE001 = GEWEW001.LK_COD_IDENTIFICADOR_WE001.ToString(),
                LKN_COD_IDENTIFICADOR_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_IDENTIFICADOR_WE001.ToString(),
                LK_DTA_DOCUMENTO_WE001 = GEWEW001.LK_DTA_DOCUMENTO_WE001.ToString(),
                LKN_DTA_DOCUMENTO_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_DTA_DOCUMENTO_WE001.ToString(),
                LK_DTA_LANCAM_DOCUMENTO_WE001 = GEWEW001.LK_DTA_LANCAM_DOCUMENTO_WE001.ToString(),
                LKN_DTA_LANCAM_DOCUMENTO_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_DTA_LANCAM_DOCUMENTO_WE001.ToString(),
                LK_DTA_VENCIMENTO_WE001 = GEWEW001.LK_DTA_VENCIMENTO_WE001.ToString(),
                LKN_DTA_VENCIMENTO_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_DTA_VENCIMENTO_WE001.ToString(),
                LK_NUM_CONTA_CONTRATO_WE001 = GEWEW001.LK_NUM_CONTA_CONTRATO_WE001.ToString(),
                LKN_NUM_CONTA_CONTRATO_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_CONTA_CONTRATO_WE001.ToString(),
                LK_NUM_CPF_CNPJ_WE001 = GEWEW001.LK_NUM_CPF_CNPJ_WE001.ToString(),
                LKN_NUM_CPF_CNPJ_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_CPF_CNPJ_WE001.ToString(),
                LK_COD_RETORNO_WE001 = GEWEW001.LK_COD_RETORNO_WE001.ToString(),
                LKN_COD_RETORNO_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_RETORNO_WE001.ToString(),
                LK_DES_MENS_SISTEMA_WE001 = GEWEW001.LK_DES_MENS_SISTEMA_WE001.GetMoveValues(),
                LKN_DES_MENS_SISTEMA_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_DES_MENS_SISTEMA_WE001.ToString(),
                LK_DES_MENS_AMIGAVE_WE001 = GEWEW001.LK_DES_MENS_AMIGAVE_WE001.GetMoveValues(),
                LKN_DES_MENS_AMIGAVE_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_DES_MENS_AMIGAVE_WE001.ToString(),
                LK_COD_ORIGEM_WE001 = GEWEW001.LK_COD_ORIGEM_WE001.ToString(),
                LKN_COD_ORIGEM_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_ORIGEM_WE001.ToString(),
                LK_COD_EMPRESA_WE001 = GEWEW001.LK_COD_EMPRESA_WE001.ToString(),
                LKN_COD_EMPRESA_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_EMPRESA_WE001.ToString(),
                LK_NUM_LOTE_WE001 = GEWEW001.LK_NUM_LOTE_WE001.ToString(),
                LKN_NUM_LOTE_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_LOTE_WE001.ToString(),
                LK_NUM_DOCUMENTO_WE001 = GEWEW001.LK_NUM_DOCUMENTO_WE001.ToString(),
                LKN_NUM_DOCUMENTO_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_DOCUMENTO_WE001.ToString(),
                LK_NUM_BOLETO_WE001 = GEWEW001.LK_NUM_BOLETO_WE001.ToString(),
                LKN_NUM_BOLETO_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_BOLETO_WE001.ToString(),
                LK_NUM_NOSSO_NUMERO_WE001 = GEWEW001.LK_NUM_NOSSO_NUMERO_WE001.ToString(),
                LKN_NUM_NOSSO_NUMERO_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_NOSSO_NUMERO_WE001.ToString(),
                LK_DES_LINHA_DIGITAVEL_WE001 = GEWEW001.LK_DES_LINHA_DIGITAVEL_WE001.ToString(),
                LKN_DES_LINHA_DIGITAVEL_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_DES_LINHA_DIGITAVEL_WE001.ToString(),
                LK_NUM_AGENCIA_CEDENTE_WE001 = GEWEW001.LK_NUM_AGENCIA_CEDENTE_WE001.ToString(),
                LKN_NUM_AGENCIA_CEDENTE_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_AGENCIA_CEDENTE_WE001.ToString(),
                LK_NUM_PARCEIRO_NEGOC_WE001 = GEWEW001.LK_NUM_PARCEIRO_NEGOC_WE001.ToString(),
                LKN_NUM_PARCEIRO_NEGOC_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_PARCEIRO_NEGOC_WE001.ToString(),
                LK_VLR_TOTAL_BOLETO_WE001 = GEWEW001.LK_VLR_TOTAL_BOLETO_WE001.ToString(),
                LKN_VLR_TOTAL_BOLETO_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_VLR_TOTAL_BOLETO_WE001.ToString(),
                LK_LST_MENSAGENS_CONT_WE001 = GEWEW001.LK_LST_MENSAGENS_CONT_WE001.ToString(),
                LKN_LST_MENSAGENS_CONT_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_LST_MENSAGENS_CONT_WE001.ToString(),
                LK_COD_TIPO_WE001 = GEWEW001.LK_COD_TIPO_WE001.GetMoveValues(),
                LKN_COD_TIPO_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_TIPO_WE001.ToString(),
                LK_COD_MENSAGEM_WE001 = GEWEW001.LK_COD_MENSAGEM_WE001.GetMoveValues(),
                LKN_COD_MENSAGEM_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_MENSAGEM_WE001.ToString(),
                LK_NUM_MENSAGEM_WE001 = GEWEW001.LK_NUM_MENSAGEM_WE001.ToString(),
                LKN_NUM_MENSAGEM_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_MENSAGEM_WE001.ToString(),
                LK_DES_MENSAGEM_WE001 = GEWEW001.LK_DES_MENSAGEM_WE001.GetMoveValues(),
                LKN_DES_MENSAGEM_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_DES_MENSAGEM_WE001.ToString(),
                LK_DES_LOG_WE001 = GEWEW001.LK_DES_LOG_WE001.GetMoveValues(),
                LKN_DES_LOG_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_DES_LOG_WE001.ToString(),
                LK_SEQ_LOG_WE001 = GEWEW001.LK_SEQ_LOG_WE001.ToString(),
                LKN_SEQ_LOG_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_SEQ_LOG_WE001.ToString(),
                LK_NOM_PARAMETRO_WE001 = GEWEW001.LK_NOM_PARAMETRO_WE001.GetMoveValues(),
                LKN_NOM_PARAMETRO_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NOM_PARAMETRO_WE001.ToString(),
                LK_NUM_LINHA_WE001 = GEWEW001.LK_NUM_LINHA_WE001.ToString(),
                LKN_NUM_LINHA_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_LINHA_WE001.ToString(),
                LK_NOM_CAMPO_WE001 = GEWEW001.LK_NOM_CAMPO_WE001.GetMoveValues(),
                LKN_NOM_CAMPO_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NOM_CAMPO_WE001.ToString(),
                LK_NOM_SISTEMA_WE001 = GEWEW001.LK_NOM_SISTEMA_WE001.GetMoveValues(),
                LKN_NOM_SISTEMA_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NOM_SISTEMA_WE001.ToString(),
                LK_IND_ERRO_WE001 = GEWEW001.LK_IND_ERRO_WE001.ToString(),
                LKN_IND_ERRO_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_IND_ERRO_WE001.ToString(),
                LK_MSG_RET_WE001 = GEWEW001.LK_MSG_RET_WE001.ToString(),
                LKN_MSG_RET_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_MSG_RET_WE001.ToString(),
                LK_NM_TAB_WE001 = GEWEW001.LK_NM_TAB_WE001.ToString(),
                LKN_NM_TAB_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NM_TAB_WE001.ToString(),
                LK_SQLCODE_WE001 = GEWEW001.LK_SQLCODE_WE001.ToString(),
                LKN_SQLCODE_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_SQLCODE_WE001.ToString(),
                LK_SQLERRMC_WE001 = GEWEW001.LK_SQLERRMC_WE001.ToString(),
                LKN_SQLERRMC_WE001 = GEWEW001.LKN_VALORES_NULOS_WE001.LKN_SQLERRMC_WE001.ToString(),
            };

            var executed_1 = GEWES001_Call1.Execute(gEWES001_Call1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LK_COD_SISTEMA_WE001, GEWEW001.LK_COD_SISTEMA_WE001);
                _.Move(executed_1.LKN_COD_SISTEMA_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_SISTEMA_WE001);
                _.Move(executed_1.LK_NUM_PROPOSTA_WE001, GEWEW001.LK_NUM_PROPOSTA_WE001);
                _.Move(executed_1.LKN_NUM_PROPOSTA_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_PROPOSTA_WE001);
                _.Move(executed_1.LK_NUM_APOLICE_WE001, GEWEW001.LK_NUM_APOLICE_WE001);
                _.Move(executed_1.LKN_NUM_APOLICE_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_APOLICE_WE001);
                _.Move(executed_1.LK_NUM_ENDOSSO_WE001, GEWEW001.LK_NUM_ENDOSSO_WE001);
                _.Move(executed_1.LKN_NUM_ENDOSSO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_ENDOSSO_WE001);
                _.Move(executed_1.LK_COD_CANAL_WE001, GEWEW001.LK_COD_CANAL_WE001);
                _.Move(executed_1.LKN_COD_CANAL_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_CANAL_WE001);
                _.Move(executed_1.LK_NUM_PARCELA_WE001, GEWEW001.LK_NUM_PARCELA_WE001);
                _.Move(executed_1.LKN_NUM_PARCELA_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_PARCELA_WE001);
                _.Move(executed_1.LK_NUM_TOTAL_PARCELAS_WE001, GEWEW001.LK_NUM_TOTAL_PARCELAS_WE001);
                _.Move(executed_1.LKN_NUM_TOTAL_PARCELAS_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_TOTAL_PARCELAS_WE001);
                _.Move(executed_1.LK_COD_FONTE_WE001, GEWEW001.LK_COD_FONTE_WE001);
                _.Move(executed_1.LKN_COD_FONTE_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_FONTE_WE001);
                _.Move(executed_1.LK_COD_CENTRO_LUCRO_WE001, GEWEW001.LK_COD_CENTRO_LUCRO_WE001);
                _.Move(executed_1.LKN_COD_CENTRO_LUCRO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_CENTRO_LUCRO_WE001);
                _.Move(executed_1.LK_NUM_RAMO_SUSEP_WE001, GEWEW001.LK_NUM_RAMO_SUSEP_WE001);
                _.Move(executed_1.LKN_NUM_RAMO_SUSEP_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_RAMO_SUSEP_WE001);
                _.Move(executed_1.LK_COD_TIPO_CONVENIO_WE001, GEWEW001.LK_COD_TIPO_CONVENIO_WE001);
                _.Move(executed_1.LKN_COD_TIPO_CONVENIO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_TIPO_CONVENIO_WE001);
                _.Move(executed_1.LK_COD_COMPROMISSO_WE001, GEWEW001.LK_COD_COMPROMISSO_WE001);
                _.Move(executed_1.LKN_COD_COMPROMISSO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_COMPROMISSO_WE001);
                _.Move(executed_1.LK_NUM_CERTIFICADO_WE001, GEWEW001.LK_NUM_CERTIFICADO_WE001);
                _.Move(executed_1.LKN_NUM_CERTIFICADO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_CERTIFICADO_WE001);
                _.Move(executed_1.LK_NUM_TITULO_WE001, GEWEW001.LK_NUM_TITULO_WE001);
                _.Move(executed_1.LKN_NUM_TITULO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_TITULO_WE001);
                _.Move(executed_1.LK_NUM_GRUPO_WE001, GEWEW001.LK_NUM_GRUPO_WE001);
                _.Move(executed_1.LKN_NUM_GRUPO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_GRUPO_WE001);
                _.Move(executed_1.LK_NUM_COTA_WE001, GEWEW001.LK_NUM_COTA_WE001);
                _.Move(executed_1.LKN_NUM_COTA_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_COTA_WE001);
                _.Move(executed_1.LK_VLR_FUNDO_COMUM_WE001, GEWEW001.LK_VLR_FUNDO_COMUM_WE001);
                _.Move(executed_1.LKN_VLR_FUNDO_COMUM_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_VLR_FUNDO_COMUM_WE001);
                _.Move(executed_1.LK_VLR_FUNDO_RESERVA_WE001, GEWEW001.LK_VLR_FUNDO_RESERVA_WE001);
                _.Move(executed_1.LKN_VLR_FUNDO_RESERVA_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_VLR_FUNDO_RESERVA_WE001);
                _.Move(executed_1.LK_VLR_MULTA_JUROS_WE001, GEWEW001.LK_VLR_MULTA_JUROS_WE001);
                _.Move(executed_1.LKN_VLR_MULTA_JUROS_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_VLR_MULTA_JUROS_WE001);
                _.Move(executed_1.LK_VLR_SEGURO_WE001, GEWEW001.LK_VLR_SEGURO_WE001);
                _.Move(executed_1.LKN_VLR_SEGURO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_VLR_SEGURO_WE001);
                _.Move(executed_1.LK_VLR_TAXA_ADMINISTRAC_WE001, GEWEW001.LK_VLR_TAXA_ADMINISTRAC_WE001);
                _.Move(executed_1.LKN_VLR_TAXA_ADMINISTRAC_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_VLR_TAXA_ADMINISTRAC_WE001);
                _.Move(executed_1.LK_VLR_REPASS_MUL_JUROS_WE001, GEWEW001.LK_VLR_REPASS_MUL_JUROS_WE001);
                _.Move(executed_1.LKN_VLR_REPASS_MUL_JUROS_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_VLR_REPASS_MUL_JUROS_WE001);
                _.Move(executed_1.LK_VLR_BOLETO_WE001, GEWEW001.LK_VLR_BOLETO_WE001);
                _.Move(executed_1.LKN_VLR_BOLETO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_VLR_BOLETO_WE001);
                _.Move(executed_1.LK_QTD_PERMANENCIA_WE001, GEWEW001.LK_QTD_PERMANENCIA_WE001);
                _.Move(executed_1.LKN_QTD_PERMANENCIA_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_QTD_PERMANENCIA_WE001);
                _.Move(executed_1.LK_VLR_IOF_WE001, GEWEW001.LK_VLR_IOF_WE001);
                _.Move(executed_1.LKN_VLR_IOF_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_VLR_IOF_WE001);
                _.Move(executed_1.LK_IND_REGISTRA_ONLINE_WE001, GEWEW001.LK_IND_REGISTRA_ONLINE_WE001);
                _.Move(executed_1.LKN_IND_REGISTRA_ONLINE_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_IND_REGISTRA_ONLINE_WE001);
                _.Move(executed_1.LK_PCT_MULTA_WE001, GEWEW001.LK_PCT_MULTA_WE001);
                _.Move(executed_1.LKN_PCT_MULTA_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_PCT_MULTA_WE001);
                _.Move(executed_1.LK_VLR_JUROS_DIA_WE001, GEWEW001.LK_VLR_JUROS_DIA_WE001);
                _.Move(executed_1.LKN_VLR_JUROS_DIA_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_VLR_JUROS_DIA_WE001);
                _.Move(executed_1.LK_NOM_PESSOA_WE001, GEWEW001.LK_NOM_PESSOA_WE001);
                _.Move(executed_1.LKN_NOM_PESSOA_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NOM_PESSOA_WE001);
                _.Move(executed_1.LK_NOM_ULTIMO_NOME_WE001, GEWEW001.LK_NOM_ULTIMO_NOME_WE001);
                _.Move(executed_1.LKN_NOM_ULTIMO_NOME_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NOM_ULTIMO_NOME_WE001);
                _.Move(executed_1.LK_COD_FORMA_TRATAMENTO_WE001, GEWEW001.LK_COD_FORMA_TRATAMENTO_WE001);
                _.Move(executed_1.LKN_COD_FORMA_TRATAMENTO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_FORMA_TRATAMENTO_WE001);
                _.Move(executed_1.LK_COD_ENDERECO_WE001, GEWEW001.LK_COD_ENDERECO_WE001);
                _.Move(executed_1.LKN_COD_ENDERECO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_ENDERECO_WE001);
                _.Move(executed_1.LK_NUM_ENDERECO_WE001, GEWEW001.LK_NUM_ENDERECO_WE001);
                _.Move(executed_1.LKN_NUM_ENDERECO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_ENDERECO_WE001);
                _.Move(executed_1.LK_DES_ENDERECO_WE001, GEWEW001.LK_DES_ENDERECO_WE001);
                _.Move(executed_1.LKN_DES_ENDERECO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_DES_ENDERECO_WE001);
                _.Move(executed_1.LK_DES_COMPLEMENTO_WE001, GEWEW001.LK_DES_COMPLEMENTO_WE001);
                _.Move(executed_1.LKN_DES_COMPLEMENTO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_DES_COMPLEMENTO_WE001);
                _.Move(executed_1.LK_NOM_BAIRRO_WE001, GEWEW001.LK_NOM_BAIRRO_WE001);
                _.Move(executed_1.LKN_NOM_BAIRRO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NOM_BAIRRO_WE001);
                _.Move(executed_1.LK_NOM_CIDADE_WE001, GEWEW001.LK_NOM_CIDADE_WE001);
                _.Move(executed_1.LKN_NOM_CIDADE_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NOM_CIDADE_WE001);
                _.Move(executed_1.LK_COD_UF_WE001, GEWEW001.LK_COD_UF_WE001);
                _.Move(executed_1.LKN_COD_UF_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_UF_WE001);
                _.Move(executed_1.LK_NUM_CEP_WE001, GEWEW001.LK_NUM_CEP_WE001);
                _.Move(executed_1.LKN_NUM_CEP_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_CEP_WE001);
                _.Move(executed_1.LK_IND_CONCILIA_SIGPF_WE001, GEWEW001.LK_IND_CONCILIA_SIGPF_WE001);
                _.Move(executed_1.LKN_IND_CONCILIA_SIGPF_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_IND_CONCILIA_SIGPF_WE001);
                _.Move(executed_1.LK_COD_EVENTO_WE001, GEWEW001.LK_COD_EVENTO_WE001);
                _.Move(executed_1.LKN_COD_EVENTO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_EVENTO_WE001);
                _.Move(executed_1.LK_COD_IDENTIFICADOR_WE001, GEWEW001.LK_COD_IDENTIFICADOR_WE001);
                _.Move(executed_1.LKN_COD_IDENTIFICADOR_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_IDENTIFICADOR_WE001);
                _.Move(executed_1.LK_DTA_DOCUMENTO_WE001, GEWEW001.LK_DTA_DOCUMENTO_WE001);
                _.Move(executed_1.LKN_DTA_DOCUMENTO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_DTA_DOCUMENTO_WE001);
                _.Move(executed_1.LK_DTA_LANCAM_DOCUMENTO_WE001, GEWEW001.LK_DTA_LANCAM_DOCUMENTO_WE001);
                _.Move(executed_1.LKN_DTA_LANCAM_DOCUMENTO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_DTA_LANCAM_DOCUMENTO_WE001);
                _.Move(executed_1.LK_DTA_VENCIMENTO_WE001, GEWEW001.LK_DTA_VENCIMENTO_WE001);
                _.Move(executed_1.LKN_DTA_VENCIMENTO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_DTA_VENCIMENTO_WE001);
                _.Move(executed_1.LK_NUM_CONTA_CONTRATO_WE001, GEWEW001.LK_NUM_CONTA_CONTRATO_WE001);
                _.Move(executed_1.LKN_NUM_CONTA_CONTRATO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_CONTA_CONTRATO_WE001);
                _.Move(executed_1.LK_NUM_CPF_CNPJ_WE001, GEWEW001.LK_NUM_CPF_CNPJ_WE001);
                _.Move(executed_1.LKN_NUM_CPF_CNPJ_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_CPF_CNPJ_WE001);
                _.Move(executed_1.LK_COD_RETORNO_WE001, GEWEW001.LK_COD_RETORNO_WE001);
                _.Move(executed_1.LKN_COD_RETORNO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_RETORNO_WE001);
                _.Move(executed_1.LK_DES_MENS_SISTEMA_WE001, GEWEW001.LK_DES_MENS_SISTEMA_WE001);
                _.Move(executed_1.LKN_DES_MENS_SISTEMA_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_DES_MENS_SISTEMA_WE001);
                _.Move(executed_1.LK_DES_MENS_AMIGAVE_WE001, GEWEW001.LK_DES_MENS_AMIGAVE_WE001);
                _.Move(executed_1.LKN_DES_MENS_AMIGAVE_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_DES_MENS_AMIGAVE_WE001);
                _.Move(executed_1.LK_COD_ORIGEM_WE001, GEWEW001.LK_COD_ORIGEM_WE001);
                _.Move(executed_1.LKN_COD_ORIGEM_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_ORIGEM_WE001);
                _.Move(executed_1.LK_COD_EMPRESA_WE001, GEWEW001.LK_COD_EMPRESA_WE001);
                _.Move(executed_1.LKN_COD_EMPRESA_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_EMPRESA_WE001);
                _.Move(executed_1.LK_NUM_LOTE_WE001, GEWEW001.LK_NUM_LOTE_WE001);
                _.Move(executed_1.LKN_NUM_LOTE_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_LOTE_WE001);
                _.Move(executed_1.LK_NUM_DOCUMENTO_WE001, GEWEW001.LK_NUM_DOCUMENTO_WE001);
                _.Move(executed_1.LKN_NUM_DOCUMENTO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_DOCUMENTO_WE001);
                _.Move(executed_1.LK_NUM_BOLETO_WE001, GEWEW001.LK_NUM_BOLETO_WE001);
                _.Move(executed_1.LKN_NUM_BOLETO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_BOLETO_WE001);
                _.Move(executed_1.LK_NUM_NOSSO_NUMERO_WE001, GEWEW001.LK_NUM_NOSSO_NUMERO_WE001);
                _.Move(executed_1.LKN_NUM_NOSSO_NUMERO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_NOSSO_NUMERO_WE001);
                _.Move(executed_1.LK_DES_LINHA_DIGITAVEL_WE001, GEWEW001.LK_DES_LINHA_DIGITAVEL_WE001);
                _.Move(executed_1.LKN_DES_LINHA_DIGITAVEL_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_DES_LINHA_DIGITAVEL_WE001);
                _.Move(executed_1.LK_NUM_AGENCIA_CEDENTE_WE001, GEWEW001.LK_NUM_AGENCIA_CEDENTE_WE001);
                _.Move(executed_1.LKN_NUM_AGENCIA_CEDENTE_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_AGENCIA_CEDENTE_WE001);
                _.Move(executed_1.LK_NUM_PARCEIRO_NEGOC_WE001, GEWEW001.LK_NUM_PARCEIRO_NEGOC_WE001);
                _.Move(executed_1.LKN_NUM_PARCEIRO_NEGOC_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_PARCEIRO_NEGOC_WE001);
                _.Move(executed_1.LK_VLR_TOTAL_BOLETO_WE001, GEWEW001.LK_VLR_TOTAL_BOLETO_WE001);
                _.Move(executed_1.LKN_VLR_TOTAL_BOLETO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_VLR_TOTAL_BOLETO_WE001);
                _.Move(executed_1.LK_LST_MENSAGENS_CONT_WE001, GEWEW001.LK_LST_MENSAGENS_CONT_WE001);
                _.Move(executed_1.LKN_LST_MENSAGENS_CONT_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_LST_MENSAGENS_CONT_WE001);
                _.Move(executed_1.LK_COD_TIPO_WE001, GEWEW001.LK_COD_TIPO_WE001);
                _.Move(executed_1.LKN_COD_TIPO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_TIPO_WE001);
                _.Move(executed_1.LK_COD_MENSAGEM_WE001, GEWEW001.LK_COD_MENSAGEM_WE001);
                _.Move(executed_1.LKN_COD_MENSAGEM_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_MENSAGEM_WE001);
                _.Move(executed_1.LK_NUM_MENSAGEM_WE001, GEWEW001.LK_NUM_MENSAGEM_WE001);
                _.Move(executed_1.LKN_NUM_MENSAGEM_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_MENSAGEM_WE001);
                _.Move(executed_1.LK_DES_MENSAGEM_WE001, GEWEW001.LK_DES_MENSAGEM_WE001);
                _.Move(executed_1.LKN_DES_MENSAGEM_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_DES_MENSAGEM_WE001);
                _.Move(executed_1.LK_DES_LOG_WE001, GEWEW001.LK_DES_LOG_WE001);
                _.Move(executed_1.LKN_DES_LOG_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_DES_LOG_WE001);
                _.Move(executed_1.LK_SEQ_LOG_WE001, GEWEW001.LK_SEQ_LOG_WE001);
                _.Move(executed_1.LKN_SEQ_LOG_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_SEQ_LOG_WE001);
                _.Move(executed_1.LK_NOM_PARAMETRO_WE001, GEWEW001.LK_NOM_PARAMETRO_WE001);
                _.Move(executed_1.LKN_NOM_PARAMETRO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NOM_PARAMETRO_WE001);
                _.Move(executed_1.LK_NUM_LINHA_WE001, GEWEW001.LK_NUM_LINHA_WE001);
                _.Move(executed_1.LKN_NUM_LINHA_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_LINHA_WE001);
                _.Move(executed_1.LK_NOM_CAMPO_WE001, GEWEW001.LK_NOM_CAMPO_WE001);
                _.Move(executed_1.LKN_NOM_CAMPO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NOM_CAMPO_WE001);
                _.Move(executed_1.LK_NOM_SISTEMA_WE001, GEWEW001.LK_NOM_SISTEMA_WE001);
                _.Move(executed_1.LKN_NOM_SISTEMA_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NOM_SISTEMA_WE001);
                _.Move(executed_1.LK_IND_ERRO_WE001, GEWEW001.LK_IND_ERRO_WE001);
                _.Move(executed_1.LKN_IND_ERRO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_IND_ERRO_WE001);
                _.Move(executed_1.LK_MSG_RET_WE001, GEWEW001.LK_MSG_RET_WE001);
                _.Move(executed_1.LKN_MSG_RET_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_MSG_RET_WE001);
                _.Move(executed_1.LK_NM_TAB_WE001, GEWEW001.LK_NM_TAB_WE001);
                _.Move(executed_1.LKN_NM_TAB_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NM_TAB_WE001);
                _.Move(executed_1.LK_SQLCODE_WE001, GEWEW001.LK_SQLCODE_WE001);
                _.Move(executed_1.LKN_SQLCODE_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_SQLCODE_WE001);
                _.Move(executed_1.LK_SQLERRMC_WE001, GEWEW001.LK_SQLERRMC_WE001);
                _.Move(executed_1.LKN_SQLERRMC_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_SQLERRMC_WE001);
            }


        }

        [StopWatch]
        /*" R7010-00-SELECT-CLIENTE-RESS-SECTION */
        private void R7010_00_SELECT_CLIENTE_RESS_SECTION()
        {
            /*" -2891- PERFORM R7010_00_SELECT_CLIENTE_RESS_DB_SELECT_1 */

            R7010_00_SELECT_CLIENTE_RESS_DB_SELECT_1();

            /*" -2894- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -2895- DISPLAY 'R7010- ERRO SELECT SI_AR_DETALHE_VC' */
                _.Display($"R7010- ERRO SELECT SI_AR_DETALHE_VC");

                /*" -2896- DISPLAY '  RESSARC ' SIARDEVC-NUM-RESSARC */
                _.Display($"  RESSARC {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_RESSARC}");

                /*" -2897- DISPLAY '  SINISTRO ' SIARDEVC-NUM-APOL-SINISTRO */
                _.Display($"  SINISTRO {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO}");

                /*" -2898- DISPLAY '  OPERACAO ' SIARDEVC-COD-OPERACAO */
                _.Display($"  OPERACAO {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_OPERACAO}");

                /*" -2899- DISPLAY '  PARCELA ' SIARDEVC-NUM-PARCELA-ACORDO */
                _.Display($"  PARCELA {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_PARCELA_ACORDO}");

                /*" -2901- MOVE 'R7010- ERRO SELECT SI_AR_DETALHE_VC' TO LK-GE350-MSG-RETORNO */
                _.Move("R7010- ERRO SELECT SI_AR_DETALHE_VC", REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                /*" -2902- PERFORM R8888-00-DISPLAY-ERRO */

                R8888_00_DISPLAY_ERRO_SECTION();

                /*" -2903- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2905- END-IF. */
            }


            /*" -2906- MOVE '.' TO LK-NOM-ULTIMO-NOME-WE001. */
            _.Move(".", GEWEW001.LK_NOM_ULTIMO_NOME_WE001);

            /*" -2907- MOVE SIARDEVC-NUM-CEP TO WS-SI-CEP. */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CEP, AREA_DE_WORK.WS_SI_CEP);

            /*" -2912- MOVE SIARDEVC-COD-FONTE TO WS-SI-FONTE. */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_FONTE, AREA_DE_WORK.WS_SI_FONTE);

            /*" -2921- IF ((SIARDEVC-NUM-CPFCGC-ACORDO EQUAL ZEROS OR SIARDEVC-NUM-CPFCGC-ACORDO IS NOT NUMERIC) OR (SIARDEVC-NOM-RESP-ACORDO EQUAL SPACES) OR (SIARDEVC-DES-ENDERECO EQUAL SPACES) OR (SIARDEVC-NOM-CIDADE EQUAL SPACES) OR (SIARDEVC-COD-UF EQUAL SPACES) OR (SIARDEVC-TIPO-PESSOA EQUAL SPACES) OR (WS-SI-CEP EQUAL ZEROS OR WS-SI-CEP IS NOT NUMERIC) OR (WS-SI-FONTE IS NOT NUMERIC)) */

            if (((SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CPFCGC_ACORDO == 00 || !SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CPFCGC_ACORDO.IsNumeric()) || (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_RESP_ACORDO.IsEmpty()) || (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DES_ENDERECO.IsEmpty()) || (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_CIDADE.IsEmpty()) || (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_UF.IsEmpty()) || (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_PESSOA.IsEmpty()) || (AREA_DE_WORK.WS_SI_CEP == 00 || !AREA_DE_WORK.WS_SI_CEP.IsNumeric()) || (!AREA_DE_WORK.WS_SI_FONTE.IsNumeric())))
            {

                /*" -2922- MOVE '34020354000110' TO LK-NUM-CPF-CNPJ-WE001 */
                _.Move("34020354000110", GEWEW001.LK_NUM_CPF_CNPJ_WE001);

                /*" -2924- MOVE 'CAIXA SEGURADORA - RESSARCIMENTO AUTO' TO LK-NOM-PESSOA-WE001 */
                _.Move("CAIXA SEGURADORA - RESSARCIMENTO AUTO", GEWEW001.LK_NOM_PESSOA_WE001);

                /*" -2927- MOVE 'SHN - QD.1 - CONJ. A - BI. E' TO LK-COD-ENDERECO-WE001 LK-DES-ENDERECO-WE001 */
                _.Move("SHN - QD.1 - CONJ. A - BI. E", GEWEW001.LK_COD_ENDERECO_WE001, GEWEW001.LK_DES_ENDERECO_WE001);

                /*" -2928- MOVE 'BRASILIA' TO LK-NOM-CIDADE-WE001 */
                _.Move("BRASILIA", GEWEW001.LK_NOM_CIDADE_WE001);

                /*" -2929- MOVE 'DF' TO LK-COD-UF-WE001 */
                _.Move("DF", GEWEW001.LK_COD_UF_WE001);

                /*" -2930- MOVE '71701-050' TO LK-NUM-CEP-WE001 */
                _.Move("71701-050", GEWEW001.LK_NUM_CEP_WE001);

                /*" -2931- MOVE 5 TO LK-COD-FONTE-WE001 */
                _.Move(5, GEWEW001.LK_COD_FONTE_WE001);

                /*" -2932- MOVE 'Z004' TO LK-COD-FORMA-TRATAMENTO-WE001 */
                _.Move("Z004", GEWEW001.LK_COD_FORMA_TRATAMENTO_WE001);

                /*" -2933- ELSE */
            }
            else
            {


                /*" -2935- IF SIARDEVC-NUM-CPFCGC-ACORDO EQUAL ZEROS OR (SIARDEVC-NUM-CPFCGC-ACORDO IS NOT NUMERIC) */

                if (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CPFCGC_ACORDO == 00 || (!SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CPFCGC_ACORDO.IsNumeric()))
                {

                    /*" -2936- MOVE '34020354000110' TO LK-NUM-CPF-CNPJ-WE001 */
                    _.Move("34020354000110", GEWEW001.LK_NUM_CPF_CNPJ_WE001);

                    /*" -2937- ELSE */
                }
                else
                {


                    /*" -2938- MOVE SIARDEVC-NUM-CPFCGC-ACORDO TO LK-NUM-CPF-CNPJ-WE001 */
                    _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CPFCGC_ACORDO, GEWEW001.LK_NUM_CPF_CNPJ_WE001);

                    /*" -2940- END-IF */
                }


                /*" -2941- IF SIARDEVC-NOM-RESP-ACORDO EQUAL SPACES */

                if (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_RESP_ACORDO.IsEmpty())
                {

                    /*" -2943- MOVE 'CAIXA SEGURADORA - RESSARCIMENTO AUTO' TO LK-NOM-PESSOA-WE001 */
                    _.Move("CAIXA SEGURADORA - RESSARCIMENTO AUTO", GEWEW001.LK_NOM_PESSOA_WE001);

                    /*" -2944- ELSE */
                }
                else
                {


                    /*" -2945- MOVE SIARDEVC-NOM-RESP-ACORDO TO LK-NOM-PESSOA-WE001 */
                    _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_RESP_ACORDO, GEWEW001.LK_NOM_PESSOA_WE001);

                    /*" -2947- END-IF */
                }


                /*" -2948- IF SIARDEVC-DES-ENDERECO EQUAL SPACES */

                if (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DES_ENDERECO.IsEmpty())
                {

                    /*" -2951- MOVE 'SHN - QD.1 - CONJ. A - BI. E' TO LK-COD-ENDERECO-WE001 LK-DES-ENDERECO-WE001 */
                    _.Move("SHN - QD.1 - CONJ. A - BI. E", GEWEW001.LK_COD_ENDERECO_WE001, GEWEW001.LK_DES_ENDERECO_WE001);

                    /*" -2952- ELSE */
                }
                else
                {


                    /*" -2953- MOVE SIARDEVC-DES-ENDERECO TO LK-DES-ENDERECO-WE001 */
                    _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DES_ENDERECO, GEWEW001.LK_DES_ENDERECO_WE001);

                    /*" -2955- END-IF */
                }


                /*" -2956- IF SIARDEVC-NOM-CIDADE EQUAL SPACES */

                if (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_CIDADE.IsEmpty())
                {

                    /*" -2957- MOVE 'BRASILIA' TO LK-NOM-CIDADE-WE001 */
                    _.Move("BRASILIA", GEWEW001.LK_NOM_CIDADE_WE001);

                    /*" -2958- ELSE */
                }
                else
                {


                    /*" -2959- MOVE SIARDEVC-NOM-CIDADE TO LK-NOM-CIDADE-WE001 */
                    _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_CIDADE, GEWEW001.LK_NOM_CIDADE_WE001);

                    /*" -2961- END-IF */
                }


                /*" -2962- IF SIARDEVC-COD-UF EQUAL SPACES */

                if (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_UF.IsEmpty())
                {

                    /*" -2963- MOVE 'DF' TO LK-COD-UF-WE001 */
                    _.Move("DF", GEWEW001.LK_COD_UF_WE001);

                    /*" -2964- ELSE */
                }
                else
                {


                    /*" -2965- MOVE SIARDEVC-COD-UF TO LK-COD-UF-WE001 */
                    _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_UF, GEWEW001.LK_COD_UF_WE001);

                    /*" -2967- END-IF */
                }


                /*" -2969- IF WS-SI-CEP EQUAL ZEROS OR (WS-SI-CEP IS NOT NUMERIC) */

                if (AREA_DE_WORK.WS_SI_CEP == 00 || (!AREA_DE_WORK.WS_SI_CEP.IsNumeric()))
                {

                    /*" -2970- MOVE '71701-050' TO LK-NUM-CEP-WE001 */
                    _.Move("71701-050", GEWEW001.LK_NUM_CEP_WE001);

                    /*" -2971- ELSE */
                }
                else
                {


                    /*" -2972- MOVE SIARDEVC-NUM-CEP TO LK-NUM-CEP-WE001 */
                    _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CEP, GEWEW001.LK_NUM_CEP_WE001);

                    /*" -2974- END-IF */
                }


                /*" -2975- IF WS-SI-FONTE IS NOT NUMERIC */

                if (!AREA_DE_WORK.WS_SI_FONTE.IsNumeric())
                {

                    /*" -2976- MOVE 5 TO LK-COD-FONTE-WE001 */
                    _.Move(5, GEWEW001.LK_COD_FONTE_WE001);

                    /*" -2977- ELSE */
                }
                else
                {


                    /*" -2978- MOVE SIARDEVC-COD-FONTE TO LK-COD-FONTE-WE001 */
                    _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_FONTE, GEWEW001.LK_COD_FONTE_WE001);

                    /*" -2980- END-IF */
                }


                /*" -2981- IF SIARDEVC-TIPO-PESSOA EQUAL SPACES */

                if (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_PESSOA.IsEmpty())
                {

                    /*" -2982- MOVE 'Z004' TO LK-COD-FORMA-TRATAMENTO-WE001 */
                    _.Move("Z004", GEWEW001.LK_COD_FORMA_TRATAMENTO_WE001);

                    /*" -2983- ELSE */
                }
                else
                {


                    /*" -2984- IF SIARDEVC-TIPO-PESSOA EQUAL 'F' */

                    if (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_PESSOA == "F")
                    {

                        /*" -2985- MOVE '0001' TO LK-COD-FORMA-TRATAMENTO-WE001 */
                        _.Move("0001", GEWEW001.LK_COD_FORMA_TRATAMENTO_WE001);

                        /*" -2986- ELSE */
                    }
                    else
                    {


                        /*" -2987- MOVE '0003' TO LK-COD-FORMA-TRATAMENTO-WE001 */
                        _.Move("0003", GEWEW001.LK_COD_FORMA_TRATAMENTO_WE001);

                        /*" -2988- END-IF */
                    }


                    /*" -2989- END-IF */
                }


                /*" -2991- END-IF. */
            }


            /*" -2994- DISPLAY 'CPF ' LK-NUM-CPF-CNPJ-WE001 'NOME ' LK-NOM-PESSOA-WE001 'END ' LK-DES-ENDERECO-WE001 */

            $"CPF {GEWEW001.LK_NUM_CPF_CNPJ_WE001}NOME {GEWEW001.LK_NOM_PESSOA_WE001}END {GEWEW001.LK_DES_ENDERECO_WE001}"
            .Display();

            /*" -2999- DISPLAY 'CITY ' LK-NOM-CIDADE-WE001 'UF ' LK-COD-UF-WE001 'CEP ' LK-NUM-CEP-WE001 'FON ' LK-COD-FONTE-WE001 'T ' LK-COD-FORMA-TRATAMENTO-WE001 */

            $"CITY {GEWEW001.LK_NOM_CIDADE_WE001}UF {GEWEW001.LK_COD_UF_WE001}CEP {GEWEW001.LK_NUM_CEP_WE001}FON {GEWEW001.LK_COD_FONTE_WE001}T {GEWEW001.LK_COD_FORMA_TRATAMENTO_WE001}"
            .Display();

            /*" -2999- . */

        }

        [StopWatch]
        /*" R7010-00-SELECT-CLIENTE-RESS-DB-SELECT-1 */
        public void R7010_00_SELECT_CLIENTE_RESS_DB_SELECT_1()
        {
            /*" -2891- EXEC SQL SELECT NUM_CPFCGC_ACORDO, NOM_RESP_ACORDO, DES_ENDERECO, NOM_CIDADE, COD_UF, NUM_CEP, COD_FONTE, TIPO_PESSOA INTO :SIARDEVC-NUM-CPFCGC-ACORDO, :SIARDEVC-NOM-RESP-ACORDO, :SIARDEVC-DES-ENDERECO, :SIARDEVC-NOM-CIDADE, :SIARDEVC-COD-UF, :SIARDEVC-NUM-CEP, :SIARDEVC-COD-FONTE, :SIARDEVC-TIPO-PESSOA FROM SEGUROS.SI_AR_DETALHE_VC WHERE NOM_ARQUIVO = 'SCMOVSIN' AND NUM_RESSARC = :SIARDEVC-NUM-RESSARC AND NUM_APOL_SINISTRO = :SIARDEVC-NUM-APOL-SINISTRO AND COD_OPERACAO = 4000 AND NUM_PARCELA_ACORDO= :SIARDEVC-NUM-PARCELA-ACORDO END-EXEC. */

            var r7010_00_SELECT_CLIENTE_RESS_DB_SELECT_1_Query1 = new R7010_00_SELECT_CLIENTE_RESS_DB_SELECT_1_Query1()
            {
                SIARDEVC_NUM_PARCELA_ACORDO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_PARCELA_ACORDO.ToString(),
                SIARDEVC_NUM_APOL_SINISTRO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO.ToString(),
                SIARDEVC_NUM_RESSARC = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_RESSARC.ToString(),
            };

            var executed_1 = R7010_00_SELECT_CLIENTE_RESS_DB_SELECT_1_Query1.Execute(r7010_00_SELECT_CLIENTE_RESS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SIARDEVC_NUM_CPFCGC_ACORDO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CPFCGC_ACORDO);
                _.Move(executed_1.SIARDEVC_NOM_RESP_ACORDO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_RESP_ACORDO);
                _.Move(executed_1.SIARDEVC_DES_ENDERECO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DES_ENDERECO);
                _.Move(executed_1.SIARDEVC_NOM_CIDADE, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_CIDADE);
                _.Move(executed_1.SIARDEVC_COD_UF, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_UF);
                _.Move(executed_1.SIARDEVC_NUM_CEP, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CEP);
                _.Move(executed_1.SIARDEVC_COD_FONTE, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_FONTE);
                _.Move(executed_1.SIARDEVC_TIPO_PESSOA, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_PESSOA);
            }


        }

        [StopWatch]
        /*" R7100-00-CALL-GE0005S-SECTION */
        private void R7100_00_CALL_GE0005S_SECTION()
        {
            /*" -3014- MOVE ZEROS TO LKGE-RAMO-EMISSOR LKGE-MODALIDADE LKGE-PRODUTO LKGE-GRUPO-SUSEP LKGE-RAMO-SUSEP LKGE-SQLCODE. */
            _.Move(0, LK_GE0005S.LKGE_RAMO_EMISSOR, LK_GE0005S.LKGE_MODALIDADE, LK_GE0005S.LKGE_PRODUTO, LK_GE0005S.LKGE_GRUPO_SUSEP, LK_GE0005S.LKGE_RAMO_SUSEP, LK_GE0005S.LKGE_SQLCODE);

            /*" -3017- MOVE SPACES TO LKGE-INIVIGENCIA LKGE-MENSAGEM. */
            _.Move("", LK_GE0005S.LKGE_INIVIGENCIA, LK_GE0005S.LKGE_MENSAGEM);

            /*" -3019- MOVE WS-RAMO-EMISSOR TO LKGE-RAMO-EMISSOR. */
            _.Move(AREA_DE_WORK.FILLER_2.WS_RAMO_EMISSOR, LK_GE0005S.LKGE_RAMO_EMISSOR);

            /*" -3020- IF (WS-RAMO-EMISSOR EQUAL 48) */

            if ((AREA_DE_WORK.FILLER_2.WS_RAMO_EMISSOR == 48))
            {

                /*" -3021- MOVE WS-PROD TO LKGE-PRODUTO */
                _.Move(AREA_DE_WORK.WS_PROD, LK_GE0005S.LKGE_PRODUTO);

                /*" -3023- END-IF. */
            }


            /*" -3025- MOVE LK-GE350-DTA-MOVIMENTO TO LKGE-INIVIGENCIA. */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_MOVIMENTO, LK_GE0005S.LKGE_INIVIGENCIA);

            /*" -3026- MOVE 'GE0005S' TO W-CALL */
            _.Move("GE0005S", W_CALL);

            /*" -3028- CALL W-CALL USING LK-GE0005S. */
            _.Call(W_CALL, LK_GE0005S);

            /*" -3029- IF (LKGE-MENSAGEM NOT EQUAL SPACES) */

            if ((!LK_GE0005S.LKGE_MENSAGEM.IsEmpty()))
            {

                /*" -3030- DISPLAY 'R6000 - ERRO NO CALL DA SUB-ROTINA GE0005S' */
                _.Display($"R6000 - ERRO NO CALL DA SUB-ROTINA GE0005S");

                /*" -3031- DISPLAY 'ERRO     GE005S....' LKGE-MENSAGEM */
                _.Display($"ERRO     GE005S....{LK_GE0005S.LKGE_MENSAGEM}");

                /*" -3032- DISPLAY 'SQLCODE  GE005S....' LKGE-SQLCODE */
                _.Display($"SQLCODE  GE005S....{LK_GE0005S.LKGE_SQLCODE}");

                /*" -3033- DISPLAY 'RAMO     GE005S....' LKGE-RAMO-EMISSOR */
                _.Display($"RAMO     GE005S....{LK_GE0005S.LKGE_RAMO_EMISSOR}");

                /*" -3034- DISPLAY 'PRODUTO  GE005S....' LKGE-PRODUTO */
                _.Display($"PRODUTO  GE005S....{LK_GE0005S.LKGE_PRODUTO}");

                /*" -3035- DISPLAY 'VIGENCIA GE005S....' LKGE-INIVIGENCIA */
                _.Display($"VIGENCIA GE005S....{LK_GE0005S.LKGE_INIVIGENCIA}");

                /*" -3036- MOVE '1' TO LK-GE350-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO);

                /*" -3038- MOVE 'ERRO NO CALL DA SUB-ROTINA GE0005S' TO LK-GE350-MSG-RETORNO */
                _.Move("ERRO NO CALL DA SUB-ROTINA GE0005S", REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                /*" -3039- GO TO RXXXX-ROTINA-RETORNO */

                RXXXX_ROTINA_RETORNO_SECTION(); //GOTO
                return;

                /*" -3040- END-IF */
            }


            /*" -3040- . */

        }

        [StopWatch]
        /*" R7200-00-SELECT-CLIENTE-SECTION */
        private void R7200_00_SELECT_CLIENTE_SECTION()
        {
            /*" -3048- MOVE LK-GE350-COD-CLIENTE TO CLIENTES-COD-CLIENTE */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_CLIENTE, CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE);

            /*" -3061- PERFORM R7200_00_SELECT_CLIENTE_DB_SELECT_1 */

            R7200_00_SELECT_CLIENTE_DB_SELECT_1();

            /*" -3064- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -3065- DISPLAY 'R7200- ERRO SELECT CLIENTE ' */
                _.Display($"R7200- ERRO SELECT CLIENTE ");

                /*" -3067- MOVE 'R7200- ERRO SELECT CLIENTE ' TO LK-GE350-MSG-RETORNO */
                _.Move("R7200- ERRO SELECT CLIENTE ", REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                /*" -3068- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3070- END-IF. */
            }


            /*" -3072- MOVE CLIENTES-NOME-RAZAO TO CT0007S-NOME */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, AREA_DE_WORK.WS_MENS.CT0007SW099.CT0007S_NOME);

            /*" -3073- MOVE 'CT0007S' TO W-CALL */
            _.Move("CT0007S", W_CALL);

            /*" -3074- CALL W-CALL USING CT0007SW099 */
            _.Call(W_CALL, AREA_DE_WORK.WS_MENS.CT0007SW099);

            /*" -3074- . */

        }

        [StopWatch]
        /*" R7200-00-SELECT-CLIENTE-DB-SELECT-1 */
        public void R7200_00_SELECT_CLIENTE_DB_SELECT_1()
        {
            /*" -3061- EXEC SQL SELECT NOME_RAZAO , TIPO_PESSOA, CGCCPF , VALUE(IDE_SEXO, ' ' ) INTO :CLIENTES-NOME-RAZAO , :CLIENTES-TIPO-PESSOA, :CLIENTES-CGCCPF , :CLIENTES-IDE-SEXO FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :CLIENTES-COD-CLIENTE FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r7200_00_SELECT_CLIENTE_DB_SELECT_1_Query1 = new R7200_00_SELECT_CLIENTE_DB_SELECT_1_Query1()
            {
                CLIENTES_COD_CLIENTE = CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE.ToString(),
            };

            var executed_1 = R7200_00_SELECT_CLIENTE_DB_SELECT_1_Query1.Execute(r7200_00_SELECT_CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(executed_1.CLIENTES_TIPO_PESSOA, CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA);
                _.Move(executed_1.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
                _.Move(executed_1.CLIENTES_IDE_SEXO, CLIENTES.DCLCLIENTES.CLIENTES_IDE_SEXO);
            }


        }

        [StopWatch]
        /*" R7300-00-SELECT-ENDERECOS-SECTION */
        private void R7300_00_SELECT_ENDERECOS_SECTION()
        {
            /*" -3082- MOVE LK-GE350-COD-CLIENTE TO CLIENTES-COD-CLIENTE */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_CLIENTE, CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE);

            /*" -3092- INITIALIZE ENDERECO-ENDERECO ENDERECO-BAIRRO ENDERECO-CIDADE ENDERECO-SIGLA-UF ENDERECO-DES-COMPLEMENTO ENDERECO-DDD ENDERECO-TELEFONE ENDERECO-FAX ENDERECO-CEP */
            _.Initialize(
                ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO
                , ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO
                , ENDERECO.DCLENDERECOS.ENDERECO_CIDADE
                , ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF
                , ENDERECO.DCLENDERECOS.ENDERECO_DES_COMPLEMENTO
                , ENDERECO.DCLENDERECOS.ENDERECO_DDD
                , ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE
                , ENDERECO.DCLENDERECOS.ENDERECO_FAX
                , ENDERECO.DCLENDERECOS.ENDERECO_CEP
            );

            /*" -3118- PERFORM R7300_00_SELECT_ENDERECOS_DB_SELECT_1 */

            R7300_00_SELECT_ENDERECOS_DB_SELECT_1();

            /*" -3121- IF SQLCODE NOT = 000 AND +100 */

            if (!DB.SQLCODE.In("000", "+100"))
            {

                /*" -3122- DISPLAY 'R7300-PROBLEMA NO ACESSO A ENDERECOS' */
                _.Display($"R7300-PROBLEMA NO ACESSO A ENDERECOS");

                /*" -3124- MOVE 'R7300-PROBLEMA NO ACESSO A ENDERECOS' TO LK-GE350-MSG-RETORNO */
                _.Move("R7300-PROBLEMA NO ACESSO A ENDERECOS", REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                /*" -3125- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3127- END-IF */
            }


            /*" -3128- IF ENDERECO-ENDERECO NOT = SPACES */

            if (!ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO.IsEmpty())
            {

                /*" -3130- INSPECT ENDERECO-ENDERECO CONVERTING W-CONVERTE-DE TO W-CONVERTE-PARA */
                ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO.Value = _.InspectConvert(ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO, W_CONVERTE_CARACTERES.W_CONVERTE_DE, W_CONVERTE_CARACTERES.W_CONVERTE_PARA);

                /*" -3131- END-IF */
            }


            /*" -3132- IF ENDERECO-BAIRRO NOT = SPACES */

            if (!ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO.IsEmpty())
            {

                /*" -3134- INSPECT ENDERECO-BAIRRO CONVERTING W-CONVERTE-DE TO W-CONVERTE-PARA */
                ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO.Value = _.InspectConvert(ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO, W_CONVERTE_CARACTERES.W_CONVERTE_DE, W_CONVERTE_CARACTERES.W_CONVERTE_PARA);

                /*" -3135- END-IF */
            }


            /*" -3136- IF ENDERECO-CIDADE NOT = SPACES */

            if (!ENDERECO.DCLENDERECOS.ENDERECO_CIDADE.IsEmpty())
            {

                /*" -3138- INSPECT ENDERECO-CIDADE CONVERTING W-CONVERTE-DE TO W-CONVERTE-PARA */
                ENDERECO.DCLENDERECOS.ENDERECO_CIDADE.Value = _.InspectConvert(ENDERECO.DCLENDERECOS.ENDERECO_CIDADE, W_CONVERTE_CARACTERES.W_CONVERTE_DE, W_CONVERTE_CARACTERES.W_CONVERTE_PARA);

                /*" -3139- END-IF */
            }


            /*" -3140- IF ENDERECO-DES-COMPLEMENTO NOT = SPACES */

            if (!ENDERECO.DCLENDERECOS.ENDERECO_DES_COMPLEMENTO.IsEmpty())
            {

                /*" -3142- INSPECT ENDERECO-DES-COMPLEMENTO CONVERTING W-CONVERTE-DE TO W-CONVERTE-PARA */
                ENDERECO.DCLENDERECOS.ENDERECO_DES_COMPLEMENTO.Value = _.InspectConvert(ENDERECO.DCLENDERECOS.ENDERECO_DES_COMPLEMENTO, W_CONVERTE_CARACTERES.W_CONVERTE_DE, W_CONVERTE_CARACTERES.W_CONVERTE_PARA);

                /*" -3144- END-IF */
            }


            /*" -3145- IF ENDERECO-CEP EQUAL ZEROS */

            if (ENDERECO.DCLENDERECOS.ENDERECO_CEP == 00)
            {

                /*" -3146- MOVE 99999999 TO ENDERECO-CEP */
                _.Move(99999999, ENDERECO.DCLENDERECOS.ENDERECO_CEP);

                /*" -3147- END-IF */
            }


            /*" -3147- . */

        }

        [StopWatch]
        /*" R7300-00-SELECT-ENDERECOS-DB-SELECT-1 */
        public void R7300_00_SELECT_ENDERECOS_DB_SELECT_1()
        {
            /*" -3118- EXEC SQL SELECT ENDERECO , BAIRRO , CIDADE , SIGLA_UF , CEP , DDD , TELEFONE , FAX , VALUE(DES_COMPLEMENTO, ' ' ) INTO :ENDERECO-ENDERECO , :ENDERECO-BAIRRO , :ENDERECO-CIDADE , :ENDERECO-SIGLA-UF , :ENDERECO-CEP , :ENDERECO-DDD , :ENDERECO-TELEFONE , :ENDERECO-FAX , :ENDERECO-DES-COMPLEMENTO FROM SEGUROS.ENDERECOS WHERE COD_CLIENTE = :CLIENTES-COD-CLIENTE AND OCORR_ENDERECO = (SELECT MAX(B.OCORR_ENDERECO) FROM SEGUROS.ENDERECOS B WHERE B.COD_CLIENTE = :CLIENTES-COD-CLIENTE) WITH UR END-EXEC. */

            var r7300_00_SELECT_ENDERECOS_DB_SELECT_1_Query1 = new R7300_00_SELECT_ENDERECOS_DB_SELECT_1_Query1()
            {
                CLIENTES_COD_CLIENTE = CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE.ToString(),
            };

            var executed_1 = R7300_00_SELECT_ENDERECOS_DB_SELECT_1_Query1.Execute(r7300_00_SELECT_ENDERECOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDERECO_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO);
                _.Move(executed_1.ENDERECO_BAIRRO, ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO);
                _.Move(executed_1.ENDERECO_CIDADE, ENDERECO.DCLENDERECOS.ENDERECO_CIDADE);
                _.Move(executed_1.ENDERECO_SIGLA_UF, ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);
                _.Move(executed_1.ENDERECO_CEP, ENDERECO.DCLENDERECOS.ENDERECO_CEP);
                _.Move(executed_1.ENDERECO_DDD, ENDERECO.DCLENDERECOS.ENDERECO_DDD);
                _.Move(executed_1.ENDERECO_TELEFONE, ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE);
                _.Move(executed_1.ENDERECO_FAX, ENDERECO.DCLENDERECOS.ENDERECO_FAX);
                _.Move(executed_1.ENDERECO_DES_COMPLEMENTO, ENDERECO.DCLENDERECOS.ENDERECO_DES_COMPLEMENTO);
            }


        }

        [StopWatch]
        /*" R7301-00-ENDOSSO-ENDERECO-SECTION */
        private void R7301_00_ENDOSSO_ENDERECO_SECTION()
        {
            /*" -3155- DISPLAY ' CLIENTE AUTO = ' LK-GE350-COD-CLIENTE */
            _.Display($" CLIENTE AUTO = {REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_CLIENTE}");

            /*" -3156- MOVE LK-GE350-NUM-APOLICE TO GE403-NUM-APOLICE */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_APOLICE);

            /*" -3157- MOVE LK-GE350-NUM-ENDOSSO TO GE403-NUM-ENDOSSO */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_ENDOSSO);

            /*" -3164- PERFORM R7301_00_ENDOSSO_ENDERECO_DB_SELECT_1 */

            R7301_00_ENDOSSO_ENDERECO_DB_SELECT_1();

            /*" -3166- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -3167- DISPLAY 'R7301-PROBLEMA NO ACESSO ENDOSSO DE ENDERECO' */
                _.Display($"R7301-PROBLEMA NO ACESSO ENDOSSO DE ENDERECO");

                /*" -3169- MOVE 'R7301-PROBLEMA NO ACESSO ENDOSSO - ENDERECOS' TO LK-GE350-MSG-RETORNO */
                _.Move("R7301-PROBLEMA NO ACESSO ENDOSSO - ENDERECOS", REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                /*" -3170- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3172- END-IF. */
            }


            /*" -3174- MOVE LK-GE350-COD-CLIENTE TO CLIENTES-COD-CLIENTE */
            _.Move(REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_CLIENTE, CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE);

            /*" -3197- PERFORM R7301_00_ENDOSSO_ENDERECO_DB_SELECT_2 */

            R7301_00_ENDOSSO_ENDERECO_DB_SELECT_2();

            /*" -3199- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -3200- DISPLAY 'R7301-PROBLEMA NO ACESSO A ENDERECOS AUTO' */
                _.Display($"R7301-PROBLEMA NO ACESSO A ENDERECOS AUTO");

                /*" -3202- MOVE 'R7301-PROBLEMA NO ACESSO A ENDERECOS - AUTO' TO LK-GE350-MSG-RETORNO */
                _.Move("R7301-PROBLEMA NO ACESSO A ENDERECOS - AUTO", REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO);

                /*" -3203- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3205- END-IF. */
            }


            /*" -3206- IF (ENDERECO-CEP EQUAL ZEROS) */

            if ((ENDERECO.DCLENDERECOS.ENDERECO_CEP == 00))
            {

                /*" -3207- MOVE 99999999 TO ENDERECO-CEP */
                _.Move(99999999, ENDERECO.DCLENDERECOS.ENDERECO_CEP);

                /*" -3208- END-IF */
            }


            /*" -3208- . */

        }

        [StopWatch]
        /*" R7301-00-ENDOSSO-ENDERECO-DB-SELECT-1 */
        public void R7301_00_ENDOSSO_ENDERECO_DB_SELECT_1()
        {
            /*" -3164- EXEC SQL SELECT OCORR_ENDERECO INTO :ENDOSSOS-OCORR-ENDERECO FROM SEGUROS.ENDOSSOS WHERE NUM_APOLICE = :GE403-NUM-APOLICE AND NUM_ENDOSSO = :GE403-NUM-ENDOSSO WITH UR END-EXEC. */

            var r7301_00_ENDOSSO_ENDERECO_DB_SELECT_1_Query1 = new R7301_00_ENDOSSO_ENDERECO_DB_SELECT_1_Query1()
            {
                GE403_NUM_APOLICE = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_APOLICE.ToString(),
                GE403_NUM_ENDOSSO = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = R7301_00_ENDOSSO_ENDERECO_DB_SELECT_1_Query1.Execute(r7301_00_ENDOSSO_ENDERECO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDOSSOS_OCORR_ENDERECO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_OCORR_ENDERECO);
            }


        }

        [StopWatch]
        /*" R7400-INI-LINKAGE-GEWES001-SECTION */
        private void R7400_INI_LINKAGE_GEWES001_SECTION()
        {
            /*" -3292- INITIALIZE LK-COD-SISTEMA-WE001 LK-NUM-PROPOSTA-WE001 LK-NUM-APOLICE-WE001 LK-NUM-ENDOSSO-WE001 LK-COD-CANAL-WE001 LK-NUM-PARCELA-WE001 LK-NUM-TOTAL-PARCELAS-WE001 LK-COD-FONTE-WE001 LK-COD-CENTRO-LUCRO-WE001 LK-NUM-RAMO-SUSEP-WE001 LK-COD-TIPO-CONVENIO-WE001 LK-COD-COMPROMISSO-WE001 LK-NUM-CERTIFICADO-WE001 LK-NUM-TITULO-WE001 LK-NUM-GRUPO-WE001 LK-NUM-COTA-WE001 LK-VLR-FUNDO-COMUM-WE001 LK-VLR-FUNDO-RESERVA-WE001 LK-VLR-MULTA-JUROS-WE001 LK-VLR-SEGURO-WE001 LK-VLR-TAXA-ADMINISTRAC-WE001 LK-VLR-REPASS-MUL-JUROS-WE001 LK-VLR-BOLETO-WE001 LK-QTD-PERMANENCIA-WE001 LK-VLR-IOF-WE001 LK-IND-REGISTRA-ONLINE-WE001 LK-PCT-MULTA-WE001 LK-VLR-JUROS-DIA-WE001 LK-NOM-PESSOA-WE001 LK-NOM-ULTIMO-NOME-WE001 LK-COD-FORMA-TRATAMENTO-WE001 LK-COD-ENDERECO-WE001 LK-NUM-ENDERECO-WE001 LK-DES-ENDERECO-WE001 LK-DES-COMPLEMENTO-WE001 LK-NOM-BAIRRO-WE001 LK-NOM-CIDADE-WE001 LK-COD-UF-WE001 LK-NUM-CEP-WE001 LK-IND-CONCILIA-SIGPF-WE001 LK-COD-EVENTO-WE001 LK-COD-IDENTIFICADOR-WE001 LK-DTA-DOCUMENTO-WE001 LK-DTA-LANCAM-DOCUMENTO-WE001 LK-DTA-VENCIMENTO-WE001 LK-NUM-CONTA-CONTRATO-WE001 LK-NUM-CPF-CNPJ-WE001 LK-COD-RETORNO-WE001 LK-DES-MENS-SISTEMA-WE001 LK-DES-MENS-AMIGAVE-WE001 LK-COD-ORIGEM-WE001 LK-COD-EMPRESA-WE001 LK-NUM-LOTE-WE001 LK-NUM-DOCUMENTO-WE001 LK-NUM-BOLETO-WE001 LK-NUM-NOSSO-NUMERO-WE001 LK-DES-LINHA-DIGITAVEL-WE001 LK-NUM-AGENCIA-CEDENTE-WE001 LK-NUM-PARCEIRO-NEGOC-WE001 LK-VLR-TOTAL-BOLETO-WE001 LK-LST-MENSAGENS-CONT-WE001 LK-COD-TIPO-WE001 LK-COD-MENSAGEM-WE001 LK-NUM-MENSAGEM-WE001 LK-DES-MENSAGEM-WE001 LK-DES-LOG-WE001 LK-SEQ-LOG-WE001 LK-NOM-PARAMETRO-WE001 LK-NUM-LINHA-WE001 LK-NOM-CAMPO-WE001 LK-NOM-SISTEMA-WE001 LK-IND-ERRO-WE001 LK-MSG-RET-WE001 LK-NM-TAB-WE001 LK-SQLCODE-WE001 LK-SQLERRMC-WE001 LKN-VALORES-NULOS-WE001 . */
            _.Initialize(
                GEWEW001.LK_COD_SISTEMA_WE001
                , GEWEW001.LK_NUM_PROPOSTA_WE001
                , GEWEW001.LK_NUM_APOLICE_WE001
                , GEWEW001.LK_NUM_ENDOSSO_WE001
                , GEWEW001.LK_COD_CANAL_WE001
                , GEWEW001.LK_NUM_PARCELA_WE001
                , GEWEW001.LK_NUM_TOTAL_PARCELAS_WE001
                , GEWEW001.LK_COD_FONTE_WE001
                , GEWEW001.LK_COD_CENTRO_LUCRO_WE001
                , GEWEW001.LK_NUM_RAMO_SUSEP_WE001
                , GEWEW001.LK_COD_TIPO_CONVENIO_WE001
                , GEWEW001.LK_COD_COMPROMISSO_WE001
                , GEWEW001.LK_NUM_CERTIFICADO_WE001
                , GEWEW001.LK_NUM_TITULO_WE001
                , GEWEW001.LK_NUM_GRUPO_WE001
                , GEWEW001.LK_NUM_COTA_WE001
                , GEWEW001.LK_VLR_FUNDO_COMUM_WE001
                , GEWEW001.LK_VLR_FUNDO_RESERVA_WE001
                , GEWEW001.LK_VLR_MULTA_JUROS_WE001
                , GEWEW001.LK_VLR_SEGURO_WE001
                , GEWEW001.LK_VLR_TAXA_ADMINISTRAC_WE001
                , GEWEW001.LK_VLR_REPASS_MUL_JUROS_WE001
                , GEWEW001.LK_VLR_BOLETO_WE001
                , GEWEW001.LK_QTD_PERMANENCIA_WE001
                , GEWEW001.LK_VLR_IOF_WE001
                , GEWEW001.LK_IND_REGISTRA_ONLINE_WE001
                , GEWEW001.LK_PCT_MULTA_WE001
                , GEWEW001.LK_VLR_JUROS_DIA_WE001
                , GEWEW001.LK_NOM_PESSOA_WE001
                , GEWEW001.LK_NOM_ULTIMO_NOME_WE001
                , GEWEW001.LK_COD_FORMA_TRATAMENTO_WE001
                , GEWEW001.LK_COD_ENDERECO_WE001
                , GEWEW001.LK_NUM_ENDERECO_WE001
                , GEWEW001.LK_DES_ENDERECO_WE001
                , GEWEW001.LK_DES_COMPLEMENTO_WE001
                , GEWEW001.LK_NOM_BAIRRO_WE001
                , GEWEW001.LK_NOM_CIDADE_WE001
                , GEWEW001.LK_COD_UF_WE001
                , GEWEW001.LK_NUM_CEP_WE001
                , GEWEW001.LK_IND_CONCILIA_SIGPF_WE001
                , GEWEW001.LK_COD_EVENTO_WE001
                , GEWEW001.LK_COD_IDENTIFICADOR_WE001
                , GEWEW001.LK_DTA_DOCUMENTO_WE001
                , GEWEW001.LK_DTA_LANCAM_DOCUMENTO_WE001
                , GEWEW001.LK_DTA_VENCIMENTO_WE001
                , GEWEW001.LK_NUM_CONTA_CONTRATO_WE001
                , GEWEW001.LK_NUM_CPF_CNPJ_WE001
                , GEWEW001.LK_COD_RETORNO_WE001
                , GEWEW001.LK_DES_MENS_SISTEMA_WE001
                , GEWEW001.LK_DES_MENS_AMIGAVE_WE001
                , GEWEW001.LK_COD_ORIGEM_WE001
                , GEWEW001.LK_COD_EMPRESA_WE001
                , GEWEW001.LK_NUM_LOTE_WE001
                , GEWEW001.LK_NUM_DOCUMENTO_WE001
                , GEWEW001.LK_NUM_BOLETO_WE001
                , GEWEW001.LK_NUM_NOSSO_NUMERO_WE001
                , GEWEW001.LK_DES_LINHA_DIGITAVEL_WE001
                , GEWEW001.LK_NUM_AGENCIA_CEDENTE_WE001
                , GEWEW001.LK_NUM_PARCEIRO_NEGOC_WE001
                , GEWEW001.LK_VLR_TOTAL_BOLETO_WE001
                , GEWEW001.LK_LST_MENSAGENS_CONT_WE001
                , GEWEW001.LK_COD_TIPO_WE001
                , GEWEW001.LK_COD_MENSAGEM_WE001
                , GEWEW001.LK_NUM_MENSAGEM_WE001
                , GEWEW001.LK_DES_MENSAGEM_WE001
                , GEWEW001.LK_DES_LOG_WE001
                , GEWEW001.LK_SEQ_LOG_WE001
                , GEWEW001.LK_NOM_PARAMETRO_WE001
                , GEWEW001.LK_NUM_LINHA_WE001
                , GEWEW001.LK_NOM_CAMPO_WE001
                , GEWEW001.LK_NOM_SISTEMA_WE001
                , GEWEW001.LK_IND_ERRO_WE001
                , GEWEW001.LK_MSG_RET_WE001
                , GEWEW001.LK_NM_TAB_WE001
                , GEWEW001.LK_SQLCODE_WE001
                , GEWEW001.LK_SQLERRMC_WE001
                , GEWEW001.LKN_VALORES_NULOS_WE001
            );

            /*" -3367- MOVE -1 TO LKN-COD-SISTEMA-WE001 LKN-NUM-PROPOSTA-WE001 LKN-NUM-APOLICE-WE001 LKN-NUM-ENDOSSO-WE001 LKN-COD-CANAL-WE001 LKN-NUM-PARCELA-WE001 LKN-NUM-TOTAL-PARCELAS-WE001 LKN-COD-FONTE-WE001 LKN-COD-CENTRO-LUCRO-WE001 LKN-NUM-RAMO-SUSEP-WE001 LKN-COD-TIPO-CONVENIO-WE001 LKN-COD-COMPROMISSO-WE001 LKN-NUM-CERTIFICADO-WE001 LKN-NUM-TITULO-WE001 LKN-NUM-GRUPO-WE001 LKN-NUM-COTA-WE001 LKN-VLR-FUNDO-COMUM-WE001 LKN-VLR-FUNDO-RESERVA-WE001 LKN-VLR-MULTA-JUROS-WE001 LKN-VLR-SEGURO-WE001 LKN-VLR-TAXA-ADMINISTRAC-WE001 LKN-VLR-REPASS-MUL-JUROS-WE001 LKN-VLR-BOLETO-WE001 LKN-QTD-PERMANENCIA-WE001 LKN-VLR-IOF-WE001 LKN-IND-REGISTRA-ONLINE-WE001 LKN-PCT-MULTA-WE001 LKN-VLR-JUROS-DIA-WE001 LKN-NOM-PESSOA-WE001 LKN-NOM-ULTIMO-NOME-WE001 LKN-COD-FORMA-TRATAMENTO-WE001 LKN-COD-ENDERECO-WE001 LKN-NUM-ENDERECO-WE001 LKN-DES-ENDERECO-WE001 LKN-DES-COMPLEMENTO-WE001 LKN-NOM-BAIRRO-WE001 LKN-NOM-CIDADE-WE001 LKN-COD-UF-WE001 LKN-NUM-CEP-WE001 LKN-IND-CONCILIA-SIGPF-WE001 LKN-COD-EVENTO-WE001 LKN-COD-IDENTIFICADOR-WE001 LKN-DTA-DOCUMENTO-WE001 LKN-DTA-LANCAM-DOCUMENTO-WE001 LKN-DTA-VENCIMENTO-WE001 LKN-NUM-CONTA-CONTRATO-WE001 LKN-NUM-CPF-CNPJ-WE001 LKN-COD-RETORNO-WE001 LKN-DES-MENS-SISTEMA-WE001 LKN-DES-MENS-AMIGAVE-WE001 LKN-COD-ORIGEM-WE001 LKN-COD-EMPRESA-WE001 LKN-NUM-LOTE-WE001 LKN-NUM-DOCUMENTO-WE001 LKN-NUM-BOLETO-WE001 LKN-NUM-NOSSO-NUMERO-WE001 LKN-DES-LINHA-DIGITAVEL-WE001 LKN-NUM-AGENCIA-CEDENTE-WE001 LKN-NUM-PARCEIRO-NEGOC-WE001 LKN-VLR-TOTAL-BOLETO-WE001 LKN-LST-MENSAGENS-CONT-WE001 LKN-COD-TIPO-WE001 LKN-COD-MENSAGEM-WE001 LKN-NUM-MENSAGEM-WE001 LKN-DES-MENSAGEM-WE001 LKN-DES-LOG-WE001 LKN-SEQ-LOG-WE001 LKN-NOM-PARAMETRO-WE001 LKN-NUM-LINHA-WE001 LKN-NOM-CAMPO-WE001 LKN-NOM-SISTEMA-WE001 LKN-IND-ERRO-WE001 LKN-MSG-RET-WE001 LKN-NM-TAB-WE001 LKN-SQLCODE-WE001 LKN-SQLERRMC-WE001. */
            _.Move(-1, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_SISTEMA_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_PROPOSTA_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_APOLICE_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_ENDOSSO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_CANAL_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_PARCELA_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_TOTAL_PARCELAS_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_FONTE_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_CENTRO_LUCRO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_RAMO_SUSEP_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_TIPO_CONVENIO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_COMPROMISSO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_CERTIFICADO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_TITULO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_GRUPO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_COTA_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_VLR_FUNDO_COMUM_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_VLR_FUNDO_RESERVA_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_VLR_MULTA_JUROS_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_VLR_SEGURO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_VLR_TAXA_ADMINISTRAC_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_VLR_REPASS_MUL_JUROS_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_VLR_BOLETO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_QTD_PERMANENCIA_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_VLR_IOF_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_IND_REGISTRA_ONLINE_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_PCT_MULTA_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_VLR_JUROS_DIA_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NOM_PESSOA_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NOM_ULTIMO_NOME_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_FORMA_TRATAMENTO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_ENDERECO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_ENDERECO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_DES_ENDERECO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_DES_COMPLEMENTO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NOM_BAIRRO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NOM_CIDADE_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_UF_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_CEP_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_IND_CONCILIA_SIGPF_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_EVENTO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_IDENTIFICADOR_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_DTA_DOCUMENTO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_DTA_LANCAM_DOCUMENTO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_DTA_VENCIMENTO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_CONTA_CONTRATO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_CPF_CNPJ_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_RETORNO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_DES_MENS_SISTEMA_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_DES_MENS_AMIGAVE_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_ORIGEM_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_EMPRESA_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_LOTE_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_DOCUMENTO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_BOLETO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_NOSSO_NUMERO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_DES_LINHA_DIGITAVEL_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_AGENCIA_CEDENTE_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_PARCEIRO_NEGOC_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_VLR_TOTAL_BOLETO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_LST_MENSAGENS_CONT_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_TIPO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_COD_MENSAGEM_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_MENSAGEM_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_DES_MENSAGEM_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_DES_LOG_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_SEQ_LOG_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NOM_PARAMETRO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NUM_LINHA_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NOM_CAMPO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NOM_SISTEMA_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_IND_ERRO_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_MSG_RET_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_NM_TAB_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_SQLCODE_WE001, GEWEW001.LKN_VALORES_NULOS_WE001.LKN_SQLERRMC_WE001);

        }

        [StopWatch]
        /*" R7301-00-ENDOSSO-ENDERECO-DB-SELECT-2 */
        public void R7301_00_ENDOSSO_ENDERECO_DB_SELECT_2()
        {
            /*" -3197- EXEC SQL SELECT ENDERECO , BAIRRO , CIDADE , SIGLA_UF , CEP , DDD , TELEFONE , FAX , VALUE(DES_COMPLEMENTO, ' ' ) INTO :ENDERECO-ENDERECO , :ENDERECO-BAIRRO , :ENDERECO-CIDADE , :ENDERECO-SIGLA-UF , :ENDERECO-CEP , :ENDERECO-DDD , :ENDERECO-TELEFONE , :ENDERECO-FAX , :ENDERECO-DES-COMPLEMENTO FROM SEGUROS.ENDERECOS WHERE COD_CLIENTE = :CLIENTES-COD-CLIENTE AND OCORR_ENDERECO = :ENDOSSOS-OCORR-ENDERECO WITH UR END-EXEC. */

            var r7301_00_ENDOSSO_ENDERECO_DB_SELECT_2_Query1 = new R7301_00_ENDOSSO_ENDERECO_DB_SELECT_2_Query1()
            {
                ENDOSSOS_OCORR_ENDERECO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_OCORR_ENDERECO.ToString(),
                CLIENTES_COD_CLIENTE = CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE.ToString(),
            };

            var executed_1 = R7301_00_ENDOSSO_ENDERECO_DB_SELECT_2_Query1.Execute(r7301_00_ENDOSSO_ENDERECO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDERECO_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO);
                _.Move(executed_1.ENDERECO_BAIRRO, ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO);
                _.Move(executed_1.ENDERECO_CIDADE, ENDERECO.DCLENDERECOS.ENDERECO_CIDADE);
                _.Move(executed_1.ENDERECO_SIGLA_UF, ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);
                _.Move(executed_1.ENDERECO_CEP, ENDERECO.DCLENDERECOS.ENDERECO_CEP);
                _.Move(executed_1.ENDERECO_DDD, ENDERECO.DCLENDERECOS.ENDERECO_DDD);
                _.Move(executed_1.ENDERECO_TELEFONE, ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE);
                _.Move(executed_1.ENDERECO_FAX, ENDERECO.DCLENDERECOS.ENDERECO_FAX);
                _.Move(executed_1.ENDERECO_DES_COMPLEMENTO, ENDERECO.DCLENDERECOS.ENDERECO_DES_COMPLEMENTO);
            }


        }

        [StopWatch]
        /*" RXXXX-ROTINA-RETORNO-SECTION */
        private void RXXXX_ROTINA_RETORNO_SECTION()
        {
            /*" -3376- MOVE SQLCODE TO LK-GE350-SQLCODE */
            _.Move(DB.SQLCODE, REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_SQLCODE);

            /*" -3384- IF LK-GE350-COD-USUARIO EQUAL 'SPBCM027' OR 'SPBCM047' OR 'CS1101B' OR 'CS1110B' OR 'CS1115B' OR 'CS1120B' OR 'CS1125B' OR 'EM0010B' OR 'EM0120B' OR 'AU2060B' OR 'AU2071B' OR 'CB1276B' OR 'CB1261B' OR 'SI9200B' OR 'SI9210B' OR 'SI9261B' OR 'SI9267B' OR 'SI9268B' OR 'CS1140B' OR 'EM8006B' OR 'EM8100B' OR 'EM8110B' OR 'CS1140B' OR 'EM8006B' OR 'EM8100B' OR 'EM8110B' OR 'SI9262B' OR 'CS1112B' OR 'CB1261B' */

            if (REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_USUARIO.In("SPBCM027", "SPBCM047", "CS1101B", "CS1110B", "CS1115B", "CS1120B", "CS1125B", "EM0010B", "EM0120B", "AU2060B", "AU2071B", "CB1276B", "CB1261B", "SI9200B", "SI9210B", "SI9261B", "SI9267B", "SI9268B", "CS1140B", "EM8006B", "EM8100B", "EM8110B", "CS1140B", "EM8006B", "EM8100B", "EM8110B", "SI9262B", "CS1112B", "CB1261B"))
            {

                /*" -3386- IF ((LK-GE350-COD-RETORNO NOT = '0' ) OR (LK-COD-RETORNO-WE001 NOT = '00' AND '01' AND '08' )) */

                if (((REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO != "0") || (!GEWEW001.LK_COD_RETORNO_WE001.In("00", "01", "08"))))
                {

                    /*" -3388- DISPLAY ' COD-RETORNO -> ' LK-GE350-COD-RETORNO ' MSG -> ' LK-GE350-MSG-RETORNO */

                    $" COD-RETORNO -> {REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO} MSG -> {REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO}"
                    .Display();

                    /*" -3389- END-IF */
                }


                /*" -3391- END-IF. */
            }


            /*" -3392- GOBACK */

            throw new GoBack();

            /*" -3392- . */

        }

        [StopWatch]
        /*" R8888-00-DISPLAY-ERRO-SECTION */
        private void R8888_00_DISPLAY_ERRO_SECTION()
        {
            /*" -3399- DISPLAY '--------------------------------------------------' */
            _.Display($"--------------------------------------------------");

            /*" -3400- DISPLAY '*            DISPLAY ERRO R8888                  *' */
            _.Display($"*            ERRO R8888                  *");

            /*" -3401- DISPLAY '--------------------------------------------------' */
            _.Display($"--------------------------------------------------");

            /*" -3402- DISPLAY 'COD-FUNCAO       = ' LK-GE350-COD-FUNCAO */
            _.Display($"COD-FUNCAO       = {REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_FUNCAO}");

            /*" -3403- DISPLAY 'NUM-PROPOSTA     = ' LK-GE350-NUM-PROPOSTA */
            _.Display($"NUM-PROPOSTA     = {REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PROPOSTA}");

            /*" -3404- DISPLAY 'NUM-CERTIFICADO  = ' LK-GE350-NUM-CERTIFICADO */
            _.Display($"NUM-CERTIFICADO  = {REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_CERTIFICADO}");

            /*" -3405- DISPLAY 'NUM-PARCELA      = ' LK-GE350-NUM-PARCELA */
            _.Display($"NUM-PARCELA      = {REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA}");

            /*" -3406- DISPLAY 'NUM-APOLICE      = ' LK-GE350-NUM-APOLICE */
            _.Display($"NUM-APOLICE      = {REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE}");

            /*" -3407- DISPLAY 'NUM-ENDOSSO      = ' LK-GE350-NUM-ENDOSSO */
            _.Display($"NUM-ENDOSSO      = {REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO}");

            /*" -3408- DISPLAY 'SEQ-CNTRLE-SIGCB = ' LK-GE350-SEQ-CNTRLE-SIGCB */
            _.Display($"SEQ-CNTRLE-SIGCB = {REGISTRO_LINKAGE_GE0350S.LK_GE350_SEQ_CNTRLE_SIGCB}");

            /*" -3410- DISPLAY 'NUM-OCORR-MOVTO  = ' LK-GE350-NUM-OCORR-MOVTO '<NUM-OCORR-MOVTO > ' WS-IND-NUM-OCORR-MOVTO */

            $"NUM-OCORR-MOVTO  = {REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_OCORR_MOVTO}<NUM-OCORR-MOVTO > {WS_IND_NUM_OCORR_MOVTO}"
            .Display();

            /*" -3412- DISPLAY 'NUM-IDLG         = ' LK-GE350-NUM-IDLG '<NUM-NUM-IDLG    > ' WS-IND-NUM-IDLG */

            $"NUM-IDLG         = {REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_IDLG}<NUM-NUM-IDLG    > {WS_IND_NUM_IDLG}"
            .Display();

            /*" -3413- DISPLAY 'COD-PRODUTO      = ' LK-GE350-COD-PRODUTO */
            _.Display($"COD-PRODUTO      = {REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_PRODUTO}");

            /*" -3414- DISPLAY 'DTA-MOVIMENTO    = ' LK-GE350-DTA-MOVIMENTO */
            _.Display($"DTA-MOVIMENTO    = {REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_MOVIMENTO}");

            /*" -3415- DISPLAY 'DTA-VENCIMENTO   = ' LK-GE350-DTA-VENCIMENTO */
            _.Display($"DTA-VENCIMENTO   = {REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_VENCIMENTO}");

            /*" -3416- DISPLAY 'VLR-PREMIO-TOTAL = ' LK-GE350-VLR-PREMIO-TOTAL */
            _.Display($"VLR-PREMIO-TOTAL = {REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_PREMIO_TOTAL}");

            /*" -3417- DISPLAY 'VLR-IOF          = ' LK-GE350-VLR-IOF */
            _.Display($"VLR-IOF          = {REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_IOF}");

            /*" -3418- DISPLAY 'QTD-PARCELA      = ' LK-GE350-QTD-PARCELA */
            _.Display($"QTD-PARCELA      = {REGISTRO_LINKAGE_GE0350S.LK_GE350_QTD_PARCELA}");

            /*" -3419- DISPLAY 'QTD-DIAS-CUSTODIA= ' LK-GE350-QTD-DIAS-CUSTODIA */
            _.Display($"QTD-DIAS-CUSTODIA= {REGISTRO_LINKAGE_GE0350S.LK_GE350_QTD_DIAS_CUSTODIA}");

            /*" -3420- DISPLAY 'COD-CLIENTE      = ' LK-GE350-COD-CLIENTE */
            _.Display($"COD-CLIENTE      = {REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_CLIENTE}");

            /*" -3422- DISPLAY 'COD-CEDENTE-SAP  = ' LK-GE350-COD-CEDENTE-SAP '< IND-CEDENTE-SAP > ' WS-IND-COD-CEDENTE */

            $"COD-CEDENTE-SAP  = {REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_CEDENTE_SAP}< IND-CEDENTE-SAP > {WS_IND_COD_CEDENTE}"
            .Display();

            /*" -3424- DISPLAY 'NUM-BLTO-INTERNO = ' LK-GE350-NUM-BLTO-INTERNO '< IND-BLTO-INTERN > ' WS-IND-BOL-INT */

            $"NUM-BLTO-INTERNO = {REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_BLTO_INTERNO}< IND-BLTO-INTERN > {WS_IND_BOL_INT}"
            .Display();

            /*" -3426- DISPLAY 'NOSSO-NUMERO-SAP = ' LK-GE350-NOSSO-NUMERO-SAP '< IND-NUMERO-SAP > ' WS-IND-NN-SAP */

            $"NOSSO-NUMERO-SAP = {REGISTRO_LINKAGE_GE0350S.LK_GE350_NOSSO_NUMERO_SAP}< IND-NUMERO-SAP > {WS_IND_NN_SAP}"
            .Display();

            /*" -3428- DISPLAY 'COD-LINHA-DGTVEL = ' WS-IND-COD-LIN-DIG '< IND-LINHA-DGTVE > ' WS-IND-NUM-TITULO */

            $"COD-LINHA-DGTVEL = {WS_IND_COD_LIN_DIG}< IND-LINHA-DGTVE > {WS_IND_NUM_TITULO}"
            .Display();

            /*" -3429- DISPLAY 'NUM-TITULO       = ' LK-GE350-NUM-TITULO */
            _.Display($"NUM-TITULO       = {REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_TITULO}");

            /*" -3430- DISPLAY 'IDE-SISTEMA      = ' LK-GE350-IDE-SISTEMA */
            _.Display($"IDE-SISTEMA      = {REGISTRO_LINKAGE_GE0350S.LK_GE350_IDE_SISTEMA}");

            /*" -3431- DISPLAY 'COD-USUARIO      = ' LK-GE350-COD-USUARIO */
            _.Display($"COD-USUARIO      = {REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_USUARIO}");

            /*" -3432- DISPLAY 'COD-SITUACAO     = ' LK-GE350-COD-SITUACAO */
            _.Display($"COD-SITUACAO     = {REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO}");

            /*" -3432- . */

        }

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -3441- MOVE '1' TO LK-GE350-COD-RETORNO */
            _.Move("1", REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO);

            /*" -3443- MOVE SQLCODE TO WSQLCODE LK-GE350-SQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE, REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_SQLCODE);

            /*" -3444- DISPLAY '**************************************************' */
            _.Display($"**************************************************");

            /*" -3445- DISPLAY '*    SUB-ROTINA GE0350S - TERMINO ANORMAL        *' */
            _.Display($"*    SUB-ROTINA GE0350S - TERMINO ANORMAL        *");

            /*" -3446- DISPLAY '**************************************************' */
            _.Display($"**************************************************");

            /*" -3447- DISPLAY '*  ROTINA DE GRAVACAO DAS TABELAS DE CONTROLE DE *' */
            _.Display($"*  ROTINA DE GRAVACAO DAS TABELAS DE CONTROLE DE *");

            /*" -3448- DISPLAY '*  INTERFACE DOS SISTEMAS LEGADOS COM O SAP      *' */
            _.Display($"*  INTERFACE DOS SISTEMAS LEGADOS COM O SAP      *");

            /*" -3449- DISPLAY '*                                                *' */
            _.Display($"*                                                *");

            /*" -3450- DISPLAY '*  ERRO OCORRIDO - RETORNO PELA ROTINA DE ERRO   *' */
            _.Display($"*  ERRO OCORRIDO - RETORNO PELA ROTINA DE ERRO   *");

            /*" -3451- DISPLAY '*' LK-GE350-MSG-RETORNO '*' */

            $"*{REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO}*"
            .Display();

            /*" -3452- DISPLAY '* SQLERRMC -> ' SQLERRMC */
            _.Display($"* SQLERRMC -> {DB.SQLERRMC}");

            /*" -3453- DISPLAY '* SQLCODE -> ' LK-GE350-SQLCODE */
            _.Display($"* SQLCODE -> {REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_SQLCODE}");

            /*" -3454- DISPLAY '*' WABEND '*' */

            $"*{WABEND}*"
            .Display();

            /*" -3456- DISPLAY '**************************************************' */
            _.Display($"**************************************************");

            /*" -3457- GOBACK */

            throw new GoBack();

            /*" -3457- . */

        }
    }
}