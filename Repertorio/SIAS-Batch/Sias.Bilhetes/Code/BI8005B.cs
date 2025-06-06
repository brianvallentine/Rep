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
using Sias.Bilhetes.DB2.BI8005B;

namespace Code
{
    public class BI8005B
    {
        public bool IsCall { get; set; }

        public BI8005B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  BILHETES DE SEGURO (CRESCER)       *      */
        /*"      *   PROGRAMA ...............  BI8005B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  FAST COMPUTER                      *      */
        /*"      *   PROGRAMADOR ............  FAST COMPUTER                      *      */
        /*"      *   DATA CODIFICACAO .......  JUNHO / 2013                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  A PARTIR DO MOVIMENTO DE BILHETES  *      */
        /*"      *                             (V0BILHETE), ATUALIZA O DB DE APO- *      */
        /*"      *                             LICES.                             *      */
        /*"      *                             PROGRAMA ESPECIFICO PARA:          *      */
        /*"      *                             CAIXA SEGUROS                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      *------------------------------------ ----------------- -------- *      */
        /*"      * SISTEMAS                            V1SISTEMA         INPUT    *      */
        /*"      * FONTES PRODUTORAS                   V1FONTE           I-O      *      */
        /*"      * FUNCIONARIOS CEF                    V0FUNCIOCEF       I-O      *      */
        /*"      * APOLICES                            V0APOLICE         I-O      *      */
        /*"      * ENDOSSOS                            V0ENDOSSO         OUTPUT   *      */
        /*"      * APOLICE CORRETOR                    V0APOLCORRET      OUTPUT   *      */
        /*"      * COSSEGURO PRODUTO                   V1COSSEGPROD      INPUT    *      */
        /*"      * APOLICE COSSEGURO CEDIDO            V0APOLCOSCED      OUTPUT   *      */
        /*"      * PARCELAS                            V0PARCELA         OUTPUT   *      */
        /*"      * HISTORICO DE PARCELAS               V0HISTOPARC       OUTPUT   *      */
        /*"      * COBERTURA APOLICES                  V0COBERAPOL       OUTPUT   *      */
        /*"      * RECIBO PROVISORIO                   V0RCAP            I-O      *      */
        /*"      * RECIBO PROVISORIO COMPLEMENTAR      V0RCAPCOMP        I-O      *      */
        /*"      * ORDEM COSSEGURO CEDIDO              V0ORDECOSCED      OUTPUT   *      */
        /*"      * NUMERO OUTROS                       V0NUMERO_OUTROS   I-O      *      */
        /*"      * NUMERACAO GERAL                     V0NUMERO_AES      I-O      *      */
        /*"      * COMISSAO FENAE                      V0COMISSAO_FENAE  I-O      *      */
        /*"      * COMISSAO_ADIANTA                    V0ADIANTA         OUTPUT   *      */
        /*"      * FORMA_RECUPERACAO                   V0FORMAREC        OUTPUT   *      */
        /*"      * HISTORICO_RECUPERACAO               V0HISTOREC        OUTPUT   *      */
        /*"      *                                                                *      */
        /*"      *================================================================*      */
        /*"      *  VERSAO 31  - DEMANDA 507447                                   *      */
        /*"      *             - UNIFICACAO DA SITUACAO 'E' (FALTA RCAP-CRESCER)  *      */
        /*"      *               SUBSTITUIR POR '0' (AGUARDANDO PAGAMENTO DO      *      */
        /*"      *               VALOR DE ADESAO)                                 *      */
        /*"      *                                                                *      */
        /*"      *  EM 23/10/2023 - BRICE HO                                      *      */
        /*"      *                                        PROCURE POR V.31        *      */
        /*"      *================================================================*      */
        /*"V.30  *  VERSAO 30  - DEMANDA 455.132                                  *      */
        /*"      *             - INCLUIR NOVAS COLUNAS NO INSERT NA TABELA        *      */
        /*"      *               SEGUROS.MOVTO_DEBITOCC_CEF                       *      */
        /*"      *               COM CRITICAS PENDENTES CADASTRADAS               *      */
        /*"      *                                                                *      */
        /*"      *  EM 18/02/2023 - ELIERMES OLIVEIRA                             *      */
        /*"      *                                        PROCURE POR V.30        *      */
        /*"      *================================================================*      */
        /*"V.29  *  VERSAO 29  - DEMANDA 402.982                                  *      */
        /*"      *             - RETIRAR GRAVACAO DE ERROS DA PROPOSTA DA VIEW    *      */
        /*"      *               V0BILHETE_ERROS                                  *      */
        /*"      *             - GRAVAR ERROS DA PROPOSTA NA NOVA TABELA          *      */
        /*"      *               VG_CRITICA_PROPOSTA PARA POSTERIOR ANALISE DO    *      */
        /*"      *               GESTOR NO ATALHO 04.23                           *      */
        /*"      *             - SOMAR 10000 AOS COD-ERRO UTILIZADOS NAS TABELAS  *      */
        /*"      *               DE BILHETE E VIDA AO MESMO TEMPO                 *      */
        /*"      *             - COLOCA BILHETE EM CRITICA QUANDO O MESMO ESTIVER *      */
        /*"      *               COM CRITICAS PENDENTES CADASTRADAS               *      */
        /*"      *                                                                *      */
        /*"      *  EM 17/02/2023 - ELIERMES OLIVEIRA                             *      */
        /*"      *                                        PROCURE POR V.29        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.28  *   VERSAO 28 - PLD Circular 612 - Fase 2 -  Demanda 379166      *      */
        /*"      *             - EXCLUIR CRITICA DE PEPS, JA QUE A MESMA FOI      *      */
        /*"      *               SUBSTITUIDA PELA AVALIACAO DE RISCO DO MOTOR     *      */
        /*"      *             - INCLUIDO ROTINA SPBVG001 PARA CONSULTA DE RISCO  *      */
        /*"      *               DA PROPOSTA. CASO EXISTA RISCO CRITICO NAO       *      */
        /*"      *               SOLUCIONADO AGUARDA CONCLUSAO DO TRATAMENTO      *      */
        /*"      *               PELO GESTOR, CASO NAO ENCONTRE RISCO CADASTRADO, *      */
        /*"      *               VERIFICA SE MOTOR GEROU CLASSIFICACAO, SE GEROU  *      */
        /*"      *               INSERE CLASSIFICACAO, SE NAO GEROU INFORMA QUE A *      */
        /*"      *               PROPOSTA SERAH EMITIDA SEM ANALISE DE RISCO      *      */
        /*"      *                                                                *      */
        /*"      *   EM 04/10/2022 - ELIERMES OLIVEIRA               PROCURE V.28 *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 27...: DEMANDA 306086/TAREFA 307030                     *      */
        /*"      *               CADASTRAR APOLICE CORRETOR COMO CAIXA SEGURIDADE *      */
        /*"      *               (25267) PARA PROPOSTAS COM PRODUTO XS2 E DATA DE *      */
        /*"      *               EMISSAO MAIOR IGUAL A 16/08/2021 E TIPO COMISSAO *      */
        /*"      *               = 1 (CORRETAGEM) QUE HOJE S�O TRATADOS PELO      *      */
        /*"      *               WIZ                                              *      */
        /*"      * DATA .......: 12/08/2021                                       *      */
        /*"      * RESPONSAVEL.: HUSNI ALI HUSNI                                  *      */
        /*"      *                                                   PROCURE V.27 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 26 - HIST�RIA 239409 - TAREFA 275523                  *      */
        /*"      *             - INCLUIDO ROTINA SPBVG001 PARA PESQUISA/INCLUSA DE*      */
        /*"      *               CRITICAS PARA UM BILHETE                         *      */
        /*"      *               NESTE MOMENTO A CRITICA A SER TRATADA � PEP      *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/01/2021 - HUSNI ALI HUSNI     PROCURE POR V.26         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 25   - HISTORIA 239409                                *      */
        /*"      *               - IDENTIFICAR CLIENTE PEP (PESSOA EXPOSTA POLITI-*      */
        /*"      *                 CAMENTE) QUANDO O SEGURO ESTIVER PRONTO PARA   *      */
        /*"      *                 A EMISSAO (TIVER PASSADO DE TODOS OS ERROS).   *      */
        /*"      *               - NAO PERMITIR EMITIR ESSES SEGUROS ATE QUE A BU *      */
        /*"      *                 AVALIE A SITUACAO DELES.                       *      */
        /*"      *               - INSERIR INFORMACAO DE PEPS NA TABELA VG_ANDAMEN-      */
        /*"      *                 TO_PROP (ESSA TABELA FOI A MAIS VIAVEL QUE EN- *      */
        /*"      *                 CONTREI NO PERIODO CURTO DE TEMPO QUE TINHAMOS)*      */
        /*"      *               - QUANDO A BU RETORNAR COM O OK, O SEGURO SERA   *      */
        /*"      *                 EMITIDO.                                       *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/11/2020 - THIAGO BLAIER       PROCURE POR V.25         *      */
        /*"      *   EM 03/12/2020 - CLAUDETE RADEL                               *      */
        /*"      *                                                                *      */
        /*"JV124#*----------------------------------------------------------------*      */
        /*"JV124#*VERSAO 24: JV1 DEMANDA 262179 - KINKAS 23/10/2020               *      */
        /*"JV124#*           EXCLUI APOLICES/PRODUTOS JV1 - FASE 2                *      */
        /*"JV124#*           - PROCURAR POR JV124                                 *      */
        /*"JV124#*----------------------------------------------------------------*      */
        /*"JV123 *----------------------------------------------------------------*      */
        /*"JV123 *VERSAO 23: JV1 DEMANDA 259990 - KINKAS 10/09/2020               *      */
        /*"JV123 *           INCLUI/EXCLUI APOLICES E PRODUTOS JV1                *      */
        /*"JV123 *           - PROCURAR POR JV123                                 *      */
        /*"JV123 *----------------------------------------------------------------*      */
        /*"      *   VERSAO 22   - OCORR�NCIA DE FALHA N� 174958                  *      */
        /*"      *               - R2000-00 (ERRO - INSERT V0PARCELA)...          *      */
        /*"      *   APOL: 0103703786238  ENDO: 0000000000  PARC: 00000           *      */
        /*"      *   BILH: 000095577865958                                        *      */
        /*"      *                                                                *      */
        /*"      *   EM 12/06/2019 - CLOVIS             PROCURE POR V.22          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 21   - HISTORIA 196716                               *       */
        /*"      *               - ALTERAR A APLICA��O PARA TRATAMENTO DA NOVA    *      */
        /*"      *                 EMPRESA (JV1) E SEUS PRODUTOS.                 *      */
        /*"      *                                                                *      */
        /*"      *   EM 11/04/2019 - LUIZ FERNANDO      PROCURE POR V.21          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 20 - HISTORIA 178780                                  *      */
        /*"      *             - MUDANCAS DE PRODUTOS ACOPLADOS - CAP             *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/01/2019 - RIBAMAR MARQUES (ALTRAN)                     *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.20         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 19 - ABEND - 155.208                                  *      */
        /*"      *             - FALHA AO EMITIR BILHETE DE SEGURO VIAGEM COM DATA*      */
        /*"      *               DE INICIO E TERMINO DE VIGENCIA PARA O MESMO DIA.*      */
        /*"      *             - RETIRAR DISPLAY'S.                               *      */
        /*"      *                                                                *      */
        /*"      *    EM 30/10/2017 - FRANK CARVALHO                              *      */
        /*"      *                                        PROCURE POR V.19        *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 18 - CADMUS - 154.685                                 *      */
        /*"      *             - ACEITAR PARA TODOS OS PRODUTOS DO SEGURO VIAGEM  *      */
        /*"      *               IDADE MENOR QUE 14 ANOS QUE TENHAM               *      */
        /*"      *               CPF PREENCHIDO.                                  *      */
        /*"      *                                                                *      */
        /*"      *    EM 11/10/2017 - THIAGO BLAIER                               *      */
        /*"      *                                        PROCURE POR V.18        *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 17 - CADMUS - 150.629                                 *      */
        /*"      *             - ACEITAR PARA O PRODUTO 6922 IDADE MENOR QUE      *      */
        /*"      *               14 ANOS E MAIOR QUE 80 ANOS.                     *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *    EM 12/05/2017 - MAURO ROCHA DA CRUZ                         *      */
        /*"      *                                        PROCURE POR V.17        *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 16 - CADMUS - 149.239                                 *      */
        /*"      *             - IMPLANTA��O DO  NOVOS PRODUTOS SEGURO VIAGEM     *      */
        /*"      *               SEGURA PRE�O                                     *      */
        /*"      *               PRODUTOS 6922                                    *      */
        /*"      *                                                                *      */
        /*"      *    EM 27/03/2017 - MAURO ROCHA DA CRUZ                         *      */
        /*"      *                                        PROCURE POR V.16        *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 15 - CADMUS - 142.531                                 *      */
        /*"      *             - IMPLANTA��O DOS NOVOS PRODUTOS SEGURO VIAGEM ELO.*      */
        /*"      *               PRODUTOS 6917, 6918, 6919, 6920, 6921.           *      */
        /*"      *                                                                *      */
        /*"      *    EM 26/10/2016 - MAURO ROCHA DA CRUZ                         *      */
        /*"      *                                        PROCURE POR V.15        *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * VERSAO 14             EMISS�O DE BILHETES EM CR�TICA POR ERRO  *      */
        /*"      *                       834 (LiMITE DE RISCO).                   *      */
        /*"      *                                                                *      */
        /*"      * PROCURE POR V.14      MAURO ROCHA DA CRUZ       CADMUS 144245  *      */
        /*"      *                       17/11/2016                               *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * VERSAO 13             INICIO DA TRATATIVA DO ABEND 144093      *      */
        /*"      *                       BILHETES COM VIGENCIA DE UM DIA FORAM    *      */
        /*"      *                       RETIRADOS DO CURSOR PARA POSTERIOR TRATA-*      */
        /*"      *                       TIVA E LIBERAR A EMISSAO DOS BILHETES    *      */
        /*"      *                       REPRESADOS.                              *      */
        /*"      *                                                                *      */
        /*"      * PROCURE POR V.13      FRANK CARVALHO             ABEND 144093  *      */
        /*"      *                       11/11/2016                               *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 12             CORRIGIR ERRO QUE ESTAVA OCORRENDO NA IN-*      */
        /*"      *                       CLUSAO DO ENDOSSO 1 DE ALGUNS BILHETES.  *      */
        /*"      *                       O ERRO OCORRIA QUANDO HAVIA A INCLUSAO DE*      */
        /*"      *                       UMA PROPOSTA/FONTE JA EXISTENTE NA TABELA*      */
        /*"      *                       DE ENDOSSO.                              *      */
        /*"      *                                                                *      */
        /*"      * PROCURE POR V.12      CLAUDETE RADEL             ABEND 123737  *      */
        /*"      *                       13/10/2015                               *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 11 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 24/04/2015 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.11         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 10             DISPONIBILIZAR NOVO PRODUTO              *      */
        /*"      *                       DE SEGURO VIAGEM                         *      */
        /*"      *                                                                *      */
        /*"      * PROCURE POR V.10      THIAGO BLAIER DE SA SANTOS CADMUS 100125 *      */
        /*"      *                       26/11/2014                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 09             LIMITE PARA CONTRATA��O DO PRODUTO       *      */
        /*"      *                       MICROSEGURO CRESCER - FAM�LIA TRANQUILA  *      */
        /*"      *                       QTDE INCLUI 3704 E 3705 = MAXIMO 02 PROD *      */
        /*"      *                       VALOR MAXIMO IS POR CPF   = R$ 24.000,00 *      */
        /*"      *                                                                *      */
        /*"      * PROCURE POR V.09      MAURO ROCHA DA CRUZ   CADMUS 95470       *      */
        /*"      *                       02/06/2014                               *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 08             INCLUS�O DO PRODUTO MICROSEGURO CRESCER  *      */
        /*"      *                       O PRODUTO 3705 (PU COM ANTECIPA��O) E O  *      */
        /*"      *                       3704 (MENSAL).                           *      */
        /*"      *                                                                *      */
        /*"      * PROCURE POR V.08      MAURO ROCHA DA CRUZ   CADMUS 95470       *      */
        /*"      *                       16/05/2014                               *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 07             ACERTA GERA��O DO ENDOSSO 0 (ZERO) PARA  *      */
        /*"      *                       O PRODUTO 8184 (PU)  E VIGENCIA DO ENDOS-*      */
        /*"      *                       SO 01.                                   *      */
        /*"      *                                                                *      */
        /*"      * PROCURE POR V.07      MAURO ROCHA DA CRUZ   CADMUS 95125       *      */
        /*"      *                       10/05/2014                               *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 06             PROCESSA O PRODUTO CRESCER MENSAL (8191) *      */
        /*"      *                       O PRODUTO 8184 PASSA SER S� PU COM ANTE- *      */
        /*"      *                       CIPA��O                                  *      */
        /*"      *                                                                *      */
        /*"      * PROCURE POR V.06      MAURO ROCHA DA CRUZ   CADMUS 95125       *      */
        /*"      *                       29/04/2014                               *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   ALTERADO EM 30/04/2014    CLOVIS                       V.05  *      */
        /*"      *                             PREMIO EMITIDO DE FORMA INCORRETA  *      */
        /*"      *   BUSCA PREMIO TOTAL NA  SEGUROS.V0BILHETE                     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   ALTERADO EM 25/04/2014    CLOVIS                       V.04  *      */
        /*"      *                             CADMUS 97186 - IOF ZERO            *      */
        /*"      *   PESQUISA IOF NA TABELA SEGUROS.RAMO_COMPLEMENTAR             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 03                                                    *      */
        /*"      *             - CADMUS 95.972:                                   *      */
        /*"      *               ATENDIMENTO DA CIRC-SUSEP 360                    *      */
        /*"      *               DATA DA PROPOSTA NAO PODE SER MAIOR QUE A DATA   *      */
        /*"      *               DE INICIO DE VIGENCIA NA TABELA DE ENDOSSOS      *      */
        /*"      *                                                                *      */
        /*"      *   EM 02/04/2014 - RIBAMAR MARQUES          PROCURE POR V.03    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 02                                                    *      */
        /*"      *               VERIFICAR NOTA01 NO FINAL DO PROGRAMA.           *      */
        /*"      *                                                                *      */
        /*"      *   EM 06/03/2014 - CLOVIS                   PROCURE POR V.02    *      */
        /*"      *                                                                *      */
        /*"      *   ALTERADA TABELA SEGUROS.PARAM_PRODUTO                        *      */
        /*"      *   TIPO_FUNCIONARIO = '8' - CORRETOR DE 5% PARA 43%             *      */
        /*"      *                                                                *      */
        /*"      *   INCLUSAO TABELA SEGUROS.PARAM_PRODUTO                        *      */
        /*"      *   TIPO_FUNCIONARIO = '4' - BALCAO = 2%                         *      */
        /*"      *   TIPO_FUNCIONARIO = 'T' - TAXA DE ADMINISTRACAO = 1%          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01                                                    *      */
        /*"      *             - CAD 84043                                        *      */
        /*"      *               ACERTO DA SITUACAO DO BILHETE DE '2' PARA 'E'.   *      */
        /*"      *               S�O BILHETES CRESCER QUE NO PROGRAMA BI8600B     *      */
        /*"      *               FICARAM COM PENDENCIA RCAP OU CR�TICA (SIT = E)  *      */
        /*"      *                                                                *      */
        /*"      *   EM 07/01/2014 - MAURO ROCHA DA CRUZ      PROCURE POR V.01    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"1     ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77         W77-DECIMAL         PIC  9(015)      VALUE ZEROS.*/
        public IntBasis W77_DECIMAL { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
        /*"77         W77-DECIMAL-D1      PIC  9(008),99   VALUE ZEROS.*/
        public DoubleBasis W77_DECIMAL_D1 { get; set; } = new DoubleBasis(new PIC("9", "8", "9(008)V99"), 2);
        /*"77         W77-SMALLINT-D1     PIC  9(004)      VALUE ZEROS.*/
        public IntBasis W77_SMALLINT_D1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"77         W77-SMALLINT-D2     PIC  9(004)      VALUE ZEROS.*/
        public IntBasis W77_SMALLINT_D2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"77         WHOST-DTINIVIG      PIC  X(010)      VALUE SPACES.*/
        public StringBasis WHOST_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77         WHOST-DTTERVIG      PIC  X(010)      VALUE SPACES.*/
        public StringBasis WHOST_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77         W77-ERRO            PIC  X(001)      VALUE ' '.*/
        public StringBasis W77_ERRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
        /*"77         WHOST-NRRCAP        PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis WHOST_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         WHOST-COUNT         PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis WHOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         WHOST-SIT-PROP-SIVPF PIC X(003).*/
        public StringBasis WHOST_SIT_PROP_SIVPF { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"77         WHOST-NUMOPG        PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis WHOST_NUMOPG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         WHOST-NUMREC        PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis WHOST_NUMREC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         WHOST-NUMBIL        PIC S9(013)      VALUE +0  COMP-3*/
        public IntBasis WHOST_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         WHOST-PROD-MENSAL   PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis WHOST_PROD_MENSAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-PROD-PUANTE   PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis WHOST_PROD_PUANTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         BILACAT-NUMBIL      PIC S9(015)      VALUE +0  COMP-3*/
        public IntBasis BILACAT_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         WWORK-RAMO-ANT      PIC S9(004)                COMP.*/
        public IntBasis WWORK_RAMO_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WWORK-OPCAO-ANT     PIC S9(004)                COMP.*/
        public IntBasis WWORK_OPCAO_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WIND                PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis WIND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WWORK-MIN-DTINIVIG  PIC X(010).*/
        public StringBasis WWORK_MIN_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WWORK-MAX-DTTERVIG  PIC X(010).*/
        public StringBasis WWORK_MAX_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WWORK-MIN-DTINIVIG-COB  PIC X(010).*/
        public StringBasis WWORK_MIN_DTINIVIG_COB { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WWORK-MAX-DTTERVIG-COB  PIC X(010).*/
        public StringBasis WWORK_MAX_DTTERVIG_COB { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WS-CLIENTE-PEP      PIC  X(001)      VALUE SPACE.*/
        public StringBasis WS_CLIENTE_PEP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77         WS-PROGRAMA            PIC X(008) VALUE SPACES.*/
        public StringBasis WS_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"77         WS-QT-RISCO-CRITICO    PIC 9(006) VALUE 0.*/
        public IntBasis WS_QT_RISCO_CRITICO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"77         WS-QT-EM-CRITICA       PIC 9(006) VALUE 0.*/
        public IntBasis WS_QT_EM_CRITICA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"77         WS-QT-EMISSAO-S-RISCO  PIC 9(006) VALUE 0.*/
        public IntBasis WS_QT_EMISSAO_S_RISCO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"77         WS-QT-EMISSAO-C-RISCO  PIC 9(006) VALUE 0.*/
        public IntBasis WS_QT_EMISSAO_C_RISCO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"77         WS-QT-LIBERADO-EMISSAO PIC 9(006) VALUE 0.*/
        public IntBasis WS_QT_LIBERADO_EMISSAO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"77         WS-ERRO-VG009          PIC 9(001) VALUE 0.*/
        public IntBasis WS_ERRO_VG009 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"77         VIND-COD-EMPRESA    PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DATARCAP       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_DATARCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DTQITBCO       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_DTQITBCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DTVENCTO       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_DTVENCTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-VLCUSEMI       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_VLCUSEMI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-CFPREFIX       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_CFPREFIX { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-COD-ANGAR      PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_COD_ANGAR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-SITUACAO       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_SITUACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DTLIBER        PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_DTLIBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-CARTAO-CREDITO PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_CARTAO_CREDITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-MARGEM         PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_MARGEM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DIADEBITO      PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_DIADEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-AGENCIA        PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-OPERACAO       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-NUMCONTA       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_NUMCONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DIGCONTA       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_DIGCONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DTENVIO        PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_DTENVIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DTRETORNO      PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_DTRETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-CODRETORNO     PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_CODRETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-USUARIO        PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_USUARIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-REQUISICAO     PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_REQUISICAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-SEQUENCIA      PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_SEQUENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-NUM-LOTE       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_NUM_LOTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DTCREDITO      PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_DTCREDITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-STATUS         PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_STATUS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-VLCREDITO      PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_VLCREDITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-NRCERTIF       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1SIST-DTMOVABE     PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-DTMOVACB     PIC  X(010).*/
        public StringBasis V1SIST_DTMOVACB { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-DTCURRENT    PIC  X(010).*/
        public StringBasis V1SIST_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-TIMESTAMP    PIC  X(026).*/
        public StringBasis V1SIST_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77    CBO-COD-CBO               PIC S9(004)    COMP.*/
        public IntBasis CBO_COD_CBO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    CBO-DESCR-CBO             PIC  X(050).*/
        public StringBasis CBO_DESCR_CBO { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
        /*"77    PESSOA-FISICA-COD-CBO     PIC S9(004)    COMP.*/
        public IntBasis PESSOA_FISICA_COD_CBO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    PRPFIDEL-COD-PESSOA       PIC S9(009)    COMP.*/
        public IntBasis PRPFIDEL_COD_PESSOA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    PRPFIDEL-COD-PROD-SIVPF   PIC S9(004)    COMP.*/
        public IntBasis PRPFIDEL_COD_PROD_SIVPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    PRPFIDEL-ORIG-PROPOSTA    PIC S9(004)    COMP.*/
        public IntBasis PRPFIDEL_ORIG_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    PRPFIDEL-DIA-DEBITO       PIC S9(004)    COMP.*/
        public IntBasis PRPFIDEL_DIA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    PRPFIDEL-QTD-MESES        PIC S9(004)    COMP.*/
        public IntBasis PRPFIDEL_QTD_MESES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    PRPFIDEL-PERIPGTO         PIC S9(009)    COMP.*/
        public IntBasis PRPFIDEL_PERIPGTO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    PRPFIDEL-OPCAO-COBER      PIC  X(001).*/
        public StringBasis PRPFIDEL_OPCAO_COBER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    PRPFIDEL-NUM-IDENTIFICA   PIC S9(015) VALUE +0 COMP-3.*/
        public IntBasis PRPFIDEL_NUM_IDENTIFICA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    PRPFIDCO-NUM-IDENTIFICA   PIC S9(015) VALUE +0 COMP-3.*/
        public IntBasis PRPFIDCO_NUM_IDENTIFICA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    PRPFIDCO-INFORM-COMPLEM   PIC X(255)  VALUE SPACES.*/
        public StringBasis PRPFIDCO_INFORM_COMPLEM { get; set; } = new StringBasis(new PIC("X", "255", "X(255)"), @"");
        /*"77    PRPFIDCO-COD-USUARIO      PIC X(8)    VALUE SPACES.*/
        public StringBasis PRPFIDCO_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)"), @"");
        /*"77    PRPFIDCO-TIMESTAMP        PIC X(26).*/
        public StringBasis PRPFIDCO_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"77    PRPFIDCO-IND-TP-INFORMA   PIC X(1)    VALUE SPACES.*/
        public StringBasis PRPFIDCO_IND_TP_INFORMA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)"), @"");
        /*"77         V0SIVPF-SIT-PROPOSTA PIC  X(003)     VALUE    SPACES.*/
        public StringBasis V0SIVPF_SIT_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"77         V0CONV-NUM-SICOB     PIC S9(015)     VALUE +0 COMP-3.*/
        public IntBasis V0CONV_NUM_SICOB { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0CONV-NUM-PROPOSTA-SIVPF PIC S9(015) VALUE +0 COMP-3*/
        public IntBasis V0CONV_NUM_PROPOSTA_SIVPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V1BILH-NUMBIL       PIC S9(015)      VALUE +0 COMP-3.*/
        public IntBasis V1BILH_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0BILH-NUMBIL       PIC S9(015)      VALUE +0 COMP-3.*/
        public IntBasis V0BILH_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0BILH-FONTE        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0BILH_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0BILH-AGECOBR      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0BILH_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0BILH-NUM-MATR     PIC S9(015)      VALUE +0 COMP-3.*/
        public IntBasis V0BILH_NUM_MATR { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0BILH-AGENCIA      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0BILH_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0BILH-CODCLIEN     PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0BILH_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0BILH-PROFISSAO    PIC  X(020).*/
        public StringBasis V0BILH_PROFISSAO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"77         V0BILH-NOME         PIC  X(040).*/
        public StringBasis V0BILH_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77         V0BILH-CGCCPF       PIC S9(015)      VALUE +0 COMP-3.*/
        public IntBasis V0BILH_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0BILH-AGENCIA-DEB  PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0BILH_AGENCIA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0BILH-OPERACAO-DEB PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0BILH_OPERACAO_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0BILH-NUMCTA-DEB   PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0BILH_NUMCTA_DEB { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0BILH-DIGCtA-DEB   PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0BILH_DIGCtA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0BILH-OPCAO-COBER  PIC S9(004)               COMP.*/
        public IntBasis V0BILH_OPCAO_COBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0BILH-DTQITBCO     PIC  X(010).*/
        public StringBasis V0BILH_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0BILH-DTVENCTO     PIC  X(010).*/
        public StringBasis V0BILH_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0BILH-VLRCAP       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0BILH_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0BILH-RAMO         PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0BILH_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0BILH-SITUACAO     PIC  X(001).*/
        public StringBasis V0BILH_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0BILH-CODUSU       PIC  X(008).*/
        public StringBasis V0BILH_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V0BILH-NUM-APO-ANT  PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0BILH_NUM_APO_ANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0BILH-NUMAPOL      PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0BILH_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1COFE-COD-EMPR     PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V1COFE_COD_EMPR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1COFE-NUMBIL       PIC S9(015)      VALUE +0 COMP-3.*/
        public IntBasis V1COFE_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V1COFE-AGECOBR      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V1COFE_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COFE-VALADT       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V1COFE_VALADT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1COFE-DTCRED-ADT   PIC  X(010).*/
        public StringBasis V1COFE_DTCRED_ADT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1COFE-NUM-MATR     PIC S9(015)      VALUE +0 COMP-3.*/
        public IntBasis V1COFE_NUM_MATR { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V1COFE-AGENCIA      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V1COFE_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COFE-OPERACAO     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V1COFE_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COFE-NUMCTA       PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V1COFE_NUMCTA { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1COFE-DIGCTA       PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V1COFE_DIGCTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COFE-AGENCIA-DEB  PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V1COFE_AGENCIA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COFE-OPERACAO-DEB PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V1COFE_OPERACAO_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COFE-NUMCTA-DEB   PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V1COFE_NUMCTA_DEB { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1COFE-DIGCTA-DEB   PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V1COFE_DIGCTA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COFE-NOME-SIND    PIC  X(040).*/
        public StringBasis V1COFE_NOME_SIND { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77         V1COFE-DTQITBCO     PIC  X(010).*/
        public StringBasis V1COFE_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1COFE-VLRCAP       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V1COFE_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1COFE-DTMOVTO      PIC  X(010).*/
        public StringBasis V1COFE_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1COFE-SITUACAO     PIC  X(001).*/
        public StringBasis V1COFE_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0COFE-NUMBIL       PIC S9(015)      VALUE +0 COMP-3.*/
        public IntBasis V0COFE_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0COFE-AGECOBR      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0COFE_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COFE-NUM-MATR     PIC S9(015)      VALUE +0 COMP-3.*/
        public IntBasis V0COFE_NUM_MATR { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0COFE-AGENCIA      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0COFE_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COFE-OPERACAO     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0COFE_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COFE-NUMCTA       PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0COFE_NUMCTA { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0COFE-DIGCTA       PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0COFE_DIGCTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COFE-AGENCIA-DEB  PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0COFE_AGENCIA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COFE-OPERACAO-DEB PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0COFE_OPERACAO_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COFE-NUMCTA-DEB   PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0COFE_NUMCTA_DEB { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0COFE-DIGCTA-DEB   PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0COFE_DIGCTA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COFE-NOME-SIND    PIC  X(040).*/
        public StringBasis V0COFE_NOME_SIND { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77         V0COFE-SITUACAO     PIC  X(001).*/
        public StringBasis V0COFE_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0COFE-VALADT       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COFE_VALADT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1FONT-PROPAUTOM    PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1FONT_PROPAUTOM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1RAMO-RAMO       PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis V1RAMO_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1RCAP-VLRCAP       PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V1RCAP_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1RCAP-DATARCAP     PIC  X(010)       VALUE  SPACES.*/
        public StringBasis V1RCAP_DATARCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77         V1PROD-CODPDT       PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1PROD_CODPDT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PROD-TIPO-PROD    PIC  X(001)       VALUE  SPACES.*/
        public StringBasis V1PROD_TIPO_PROD { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77         V1PROD-ENDERECO     PIC  X(040).*/
        public StringBasis V1PROD_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77         V1PROD-CIDADE       PIC  X(020).*/
        public StringBasis V1PROD_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"77         V1BILP-CODPRODU     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1BILP_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1BILC-COD-EMPR   PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1BILC_COD_EMPR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1BILC-CODPRODU   PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1BILC_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1BILC-RAMOFR     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1BILC_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1BILC-MODALIFR   PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1BILC_MODALIFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1BILC-OPCAO      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1BILC_OPCAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1BILC-COBERTURA  PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1BILC_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1BILC-DTINIVIG   PIC  X(010).*/
        public StringBasis V1BILC_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1BILC-DTTERVIG   PIC  X(010).*/
        public StringBasis V1BILC_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1BILC-IDECOBER   PIC  X(001).*/
        public StringBasis V1BILC_IDECOBER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1BILC-IMPSEG-IX  PIC S9(013)V9(002) VALUE +0 COMP-3.*/
        public DoubleBasis V1BILC_IMPSEG_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(002)"), 2);
        /*"77         V1BILC-PRMTAR-IX  PIC S9(010)V9(005) VALUE +0 COMP-3.*/
        public DoubleBasis V1BILC_PRMTAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(005)"), 5);
        /*"77         V1BILC-CODUNIMO   PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1BILC_CODUNIMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1BILC-PCCOMCOR   PIC S9(003)V9(002) VALUE +0 COMP-3.*/
        public DoubleBasis V1BILC_PCCOMCOR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(002)"), 2);
        /*"77         V1BILC-COBERBAS   PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1BILC_COBERBAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1BILC-PCTMAX     PIC S9(003)V9(002) VALUE +0 COMP-3.*/
        public DoubleBasis V1BILC_PCTMAX { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(002)"), 2);
        /*"77         V1BILC-VALMAX     PIC S9(013)V9(002) VALUE +0 COMP-3.*/
        public DoubleBasis V1BILC_VALMAX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(002)"), 2);
        /*"77         V1BILC-PCIOCC     PIC S9(013)V9(002) VALUE +0 COMP-3.*/
        public DoubleBasis V1BILC_PCIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(002)"), 2);
        /*"77         V1AGEN-AGENCIA      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1AGEN_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1CONG-CONGENER     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1CONG_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1FUNC-NUM-MATRIC   PIC S9(015)       VALUE +0 COMP-3*/
        public IntBasis V1FUNC_NUM_MATRIC { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V1FUNC-NOME-FUN     PIC  X(040).*/
        public StringBasis V1FUNC_NOME_FUN { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77         V1FUNC-ENDERECO     PIC  X(049).*/
        public StringBasis V1FUNC_ENDERECO { get; set; } = new StringBasis(new PIC("X", "49", "X(049)."), @"");
        /*"77         V1FUNC-CIDADE       PIC  X(022).*/
        public StringBasis V1FUNC_CIDADE { get; set; } = new StringBasis(new PIC("X", "22", "X(022)."), @"");
        /*"77         V1FUNC-SIGLA-UF     PIC  X(002).*/
        public StringBasis V1FUNC_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"77         V1FUNC-CEP          PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1FUNC_CEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1FUNC-NUM-CPF      PIC S9(011)       VALUE +0 COMP-3*/
        public IntBasis V1FUNC_NUM_CPF { get; set; } = new IntBasis(new PIC("S9", "11", "S9(011)"));
        /*"77         V1FUNC-COD-ANGAR    PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1FUNC_COD_ANGAR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1NOUT-NUMCLIENTE   PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1NOUT_NUMCLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1NOUT-CODANGAR     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1NOUT_CODANGAR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1NOUT-NUMCERVG     PIC S9(015)       VALUE +0 COMP-3*/
        public IntBasis V1NOUT_NUMCERVG { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V1NOUT-NUMOPG       PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1NOUT_NUMOPG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1NAES-SEQ-APOL     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1NAES_SEQ_APOL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0NAES-SEQ-APOL     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0NAES_SEQ_APOL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1COSP-CODPRODU     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V1COSP_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COSP-RAMO         PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V1COSP_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COSP-CONGENER     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V1COSP_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COSP-PCPARTIC     PIC S9(004)V9(5) VALUE +0 COMP-3.*/
        public DoubleBasis V1COSP_PCPARTIC { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"77         V1COSP-PCCOMCOS     PIC S9(003)V9(2) VALUE +0 COMP-3.*/
        public DoubleBasis V1COSP_PCCOMCOS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         V1COSP-PCADMCOS     PIC S9(003)V9(2) VALUE +0 COMP-3.*/
        public DoubleBasis V1COSP_PCADMCOS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         V1COSP-DTINIVIG     PIC  X(010).*/
        public StringBasis V1COSP_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1COSP-DTTERVIG     PIC  X(010).*/
        public StringBasis V1COSP_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1COSP-SITUACAO     PIC  X(001).*/
        public StringBasis V1COSP_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1ACEF-COD-FONTE    PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1ACEF_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ACEF-CODESCNEG    PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1ACEF_CODESCNEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1SURG-PCDESISS     PIC S9(003)V99    VALUE +0 COMP-3*/
        public DoubleBasis V1SURG_PCDESISS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1MCEF-COD-FONTE    PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1MCEF_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0BILER-COD-ERRO    PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0BILER_COD_ERRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1APOL-NUMBIL       PIC S9(015)       VALUE +0 COMP-3*/
        public IntBasis V1APOL_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V1APOL-NUM-APOL     PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V1APOL_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1COD-ORGAO         PIC S9(004)       VALUE +0 COMP-5*/
        public IntBasis V1COD_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APOL-CODCLIEN     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0APOL_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APOL-NUM-APOL     PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0APOL_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0APOL-NUM-ITEM     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0APOL_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APOL-MODALIDA     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0APOL_MODALIDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APOL-ORGAO        PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0APOL_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APOL-RAMO         PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0APOL_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APOL-NUM-APO-ANT  PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0APOL_NUM_APO_ANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0APOL-NUMBIL       PIC S9(015)       VALUE +0 COMP-3*/
        public IntBasis V0APOL_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0APOL-TIPSGU       PIC  X(001).*/
        public StringBasis V0APOL_TIPSGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0APOL-TIPAPO       PIC  X(001).*/
        public StringBasis V0APOL_TIPAPO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0APOL-TIPCALC      PIC  X(001).*/
        public StringBasis V0APOL_TIPCALC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0APOL-PODPUBL      PIC  X(001).*/
        public StringBasis V0APOL_PODPUBL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0APOL-NUM-ATA      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0APOL_NUM_ATA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APOL-ANO-ATA      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0APOL_ANO_ATA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APOL-IDEMAN       PIC  X(001).*/
        public StringBasis V0APOL_IDEMAN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0APOL-PCDESCON     PIC S9(003)V9(02) VALUE +0 COMP-3*/
        public DoubleBasis V0APOL_PCDESCON { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(02)"), 2);
        /*"77         V0APOL-PCIOCC       PIC S9(003)V9(02) VALUE +0 COMP-3*/
        public DoubleBasis V0APOL_PCIOCC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(02)"), 2);
        /*"77         V0APOL-TPCOSCED     PIC  X(001).*/
        public StringBasis V0APOL_TPCOSCED { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0APOL-QTCOSSEG     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0APOL_QTCOSSEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APOL-PCTCED       PIC S9(004)V9(05) VALUE +0 COMP-3*/
        public DoubleBasis V0APOL_PCTCED { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(05)"), 5);
        /*"77         V0APOL-DATA-SORT    PIC  X(010).*/
        public StringBasis V0APOL_DATA_SORT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0APOL-COD-EMPRESA  PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0APOL_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APOL-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0APOL_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V0APOL-CODPRODU     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0APOL_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APOL-TPCORRET     PIC  X(001).*/
        public StringBasis V0APOL_TPCORRET { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ENDO-NUM-APOL     PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0ENDO_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0ENDO-NRENDOS      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0ENDO-CODSUBES     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-FONTE        PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-NRPROPOS     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0ENDO-DATPRO       PIC  X(010).*/
        public StringBasis V0ENDO_DATPRO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ENDO-DT-LIBER     PIC  X(010).*/
        public StringBasis V0ENDO_DT_LIBER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ENDO-DTEMIS       PIC  X(010).*/
        public StringBasis V0ENDO_DTEMIS { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ENDO-NRRCAP       PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0ENDO-VLRCAP       PIC S9(013)V9(02) VALUE +0 COMP-3*/
        public DoubleBasis V0ENDO_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V0ENDO-BCORCAP      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_BCORCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-AGERCAP      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_AGERCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-DACRCAP      PIC  X(001).*/
        public StringBasis V0ENDO_DACRCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ENDO-IDRCAP       PIC  X(001).*/
        public StringBasis V0ENDO_IDRCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ENDO-BCOCOBR      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_BCOCOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-AGECOBR      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-DACCOBR      PIC  X(001).*/
        public StringBasis V0ENDO_DACCOBR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ENDO-DTINIVIG     PIC  X(010).*/
        public StringBasis V0ENDO_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ENDO-DTTERVIG     PIC  X(010).*/
        public StringBasis V0ENDO_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ENDO-CDFRACIO     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_CDFRACIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-PCENTRAD     PIC S9(003)V9(02) VALUE +0 COMP-3*/
        public DoubleBasis V0ENDO_PCENTRAD { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(02)"), 2);
        /*"77         V0ENDO-PCADICIO     PIC S9(003)V9(02) VALUE +0 COMP-3*/
        public DoubleBasis V0ENDO_PCADICIO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(02)"), 2);
        /*"77         V0ENDO-PRESTA1      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_PRESTA1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-QTPARCEL     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_QTPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-QTPRESTA     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_QTPRESTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-QTITENS      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_QTITENS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-CODTXT       PIC  X(003).*/
        public StringBasis V0ENDO_CODTXT { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"77         V0ENDO-CDACEITA     PIC  X(001).*/
        public StringBasis V0ENDO_CDACEITA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ENDO-MOEDA-IMP    PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_MOEDA_IMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-MOEDA-PRM    PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_MOEDA_PRM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-TIPO-ENDO    PIC  X(001).*/
        public StringBasis V0ENDO_TIPO_ENDO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ENDO-COD-USUAR    PIC  X(008).*/
        public StringBasis V0ENDO_COD_USUAR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V0ENDO-OCORR-END    PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_OCORR_END { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-SITUACAO     PIC  X(001).*/
        public StringBasis V0ENDO_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ENDO-DATARCAP     PIC  X(010).*/
        public StringBasis V0ENDO_DATARCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ENDO-COD-EMPRESA  PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0ENDO-CORRECAO     PIC  X(001).*/
        public StringBasis V0ENDO_CORRECAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ENDO-ISENTA-CST   PIC  X(001).*/
        public StringBasis V0ENDO_ISENTA_CST { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ENDO-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0ENDO_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V0ENDO-DTVENCTO     PIC  X(010).*/
        public StringBasis V0ENDO_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ENDO-CFPREFIX     PIC S9(004)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0ENDO_CFPREFIX { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"77         V0ENDO-VLCUSEMI     PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0ENDO_VLCUSEMI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0ENDO-RAMO         PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-CODPRODU     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0RCAP-FONTE        PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0RCAP_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0RCAP-NRRCAP       PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0RCAP_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0RCAP-NRPROPOS     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0RCAP_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0RCAP-NOME         PIC  X(040).*/
        public StringBasis V0RCAP_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77         V0RCAP-VLRCAP       PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V0RCAP_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0RCAP-VALPRI       PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V0RCAP_VALPRI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0RCAP-DTCADAST     PIC  X(010).*/
        public StringBasis V0RCAP_DTCADAST { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0RCAP-DTMOVTO      PIC  X(010).*/
        public StringBasis V0RCAP_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0RCAP-SITUACAO     PIC  X(001).*/
        public StringBasis V0RCAP_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0RCAP-OPERACAO     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0RCAP_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0RCAP-COD-EMPRESA  PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0RCAP_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0RCAP-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0RCAP_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V0RCAP-NUM-APOL     PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0RCAP_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0RCAP-NRENDOS      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0RCAP_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0RCAP-NRPARCEL     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0RCAP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0RCAP-NRTIT        PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0RCAP_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V2RCAP-VLRCAP       PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V2RCAP_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1RCAC-FONTE        PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1RCAC-NRRCAP       PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1RCAC-NRRCAPCO     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_NRRCAPCO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1RCAC-OPERACAO     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1RCAC-DTMOVTO      PIC  X(010).*/
        public StringBasis V1RCAC_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1RCAC-HORAOPER     PIC  X(008).*/
        public StringBasis V1RCAC_HORAOPER { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V1RCAC-SITUACAO     PIC  X(001).*/
        public StringBasis V1RCAC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1RCAC-BCOAVISO     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_BCOAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1RCAC-AGEAVISO     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_AGEAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1RCAC-NRAVISO      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1RCAC-VLRCAP       PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V1RCAC_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1RCAC-DATARCAP     PIC  X(010).*/
        public StringBasis V1RCAC_DATARCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1RCAC-DTCADAST     PIC  X(010).*/
        public StringBasis V1RCAC_DTCADAST { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1RCAC-SITCONTB     PIC  X(001).*/
        public StringBasis V1RCAC_SITCONTB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1RCAC-COD-EMPRESA  PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1RCAC-TIMESTAMP    PIC  X(026).*/
        public StringBasis V1RCAC_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V0APCR-NUM-APOL     PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0APCR_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0APCR-RAMOFR       PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0APCR_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APCR-MODALIFR     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0APCR_MODALIFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APCR-CODCORR      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0APCR_CODCORR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APCR-CODSUBES     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0APCR_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APCR-DTINIVIG     PIC  X(010).*/
        public StringBasis V0APCR_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0APCR-DTTERVIG     PIC  X(010).*/
        public StringBasis V0APCR_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0APCR-PCPARCOR     PIC S9(003)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0APCR_PCPARCOR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         V0APCR-PCCOMCOR     PIC S9(003)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0APCR_PCCOMCOR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         V0APCR-TIPCOM       PIC  X(001).*/
        public StringBasis V0APCR_TIPCOM { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0APCR-INDCRT       PIC  X(001).*/
        public StringBasis V0APCR_INDCRT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0APCR-COD-EMPRESA  PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0APCR_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APCR-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0APCR_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V0APCR-COD-USUARIO  PIC  X(008).*/
        public StringBasis V0APCR_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V1APCR-NUM-APOL     PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V1APCR_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1APCR-CODCORR      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1APCR_CODCORR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APCC-NUM-APOL     PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0APCC_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0APCC-CODCOSS      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0APCC_CODCOSS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APCC-RAMOFR       PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0APCC_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APCC-DTINIVIG     PIC  X(010).*/
        public StringBasis V0APCC_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0APCC-DTTERVIG     PIC  X(010).*/
        public StringBasis V0APCC_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0APCC-PCPARTIC     PIC S9(004)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0APCC_PCPARTIC { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"77         V0APCC-PCCOMCOS     PIC S9(003)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0APCC_PCCOMCOS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         V0APCC-COD-EMPRESA  PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0APCC_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APCC-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0APCC_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V1NCOS-CONGENER     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1NCOS_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1NCOS-ORGAO        PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1NCOS_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1NCOS-NRORDEM      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1NCOS_NRORDEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0PARC-NUM-APOL     PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0PARC_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0PARC-NRENDOS      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0PARC_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0PARC-NRPARCEL     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0PARC_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PARC-DACPARC      PIC  X(001).*/
        public StringBasis V0PARC_DACPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0PARC-FONTE        PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0PARC_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PARC-NRTIT        PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0PARC_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0PARC-PRM-TAR-IX   PIC S9(010)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0PARC_PRM_TAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0PARC-VAL-DES-IX   PIC S9(010)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0PARC_VAL_DES_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0PARC-OTNPRLIQ     PIC S9(010)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0PARC_OTNPRLIQ { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0PARC-OTNADFRA     PIC S9(010)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0PARC_OTNADFRA { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0PARC-OTNCUSTO     PIC S9(010)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0PARC_OTNCUSTO { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0PARC-OTNIOF       PIC S9(010)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0PARC_OTNIOF { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0PARC-OTNTOTAL     PIC S9(010)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0PARC_OTNTOTAL { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0PARC-OCORHIST     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0PARC_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PARC-QTDDOC       PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0PARC_QTDDOC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PARC-SITUACAO     PIC  X(001).*/
        public StringBasis V0PARC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0PARC-COD-EMPRESA  PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0PARC_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0PARC-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0PARC_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V0PARC-SIT-COBR     PIC  X(001).*/
        public StringBasis V0PARC_SIT_COBR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0HISP-NUM-APOL     PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0HISP_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0HISP-NRENDOS      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0HISP_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HISP-NRPARCEL     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0HISP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HISP-DACPARC      PIC  X(001).*/
        public StringBasis V0HISP_DACPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0HISP-DTMOVTO      PIC  X(010).*/
        public StringBasis V0HISP_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0HISP-OPERACAO     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0HISP_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HISP-HORAOPER     PIC  X(008).*/
        public StringBasis V0HISP_HORAOPER { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V0HISP-OCORHIST     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0HISP_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HISP-PRM-TARIFA   PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0HISP_PRM_TARIFA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0HISP-VAL-DESCON   PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0HISP_VAL_DESCON { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0HISP-VLPRMLIQ     PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0HISP_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0HISP-VLADIFRA     PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0HISP_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0HISP-VLCUSEMI     PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0HISP_VLCUSEMI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0HISP-VLIOCC       PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0HISP_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0HISP-VLPRMTOT     PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0HISP_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0HISP-VLPREMIO     PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0HISP_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0HISP-DTVENCTO     PIC  X(010).*/
        public StringBasis V0HISP_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0HISP-BCOCOBR      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0HISP_BCOCOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HISP-AGECOBR      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0HISP_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HISP-NRAVISO      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0HISP_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HISP-NRENDOCA     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0HISP_NRENDOCA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HISP-SITCONTB     PIC  X(001).*/
        public StringBasis V0HISP_SITCONTB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0HISP-COD-USUAR    PIC  X(008).*/
        public StringBasis V0HISP_COD_USUAR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V0HISP-RNUDOC       PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0HISP_RNUDOC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HISP-DTQITBCO     PIC  X(010).*/
        public StringBasis V0HISP_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0HISP-COD-EMPRESA  PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0HISP_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HISP-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0HISP_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V0COBA-NUM-APOL     PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0COBA_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0COBA-NRENDOS      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0COBA_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0COBA-NUM-ITEM     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0COBA_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0COBA-OCORHIST     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0COBA_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COBA-RAMOFR       PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0COBA_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COBA-MODALIFR     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0COBA_MODALIFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COBA-COD-COBER    PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0COBA_COD_COBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COBA-IMP-SEG-IX   PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0COBA_IMP_SEG_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0COBA-PRM-TAR-IX   PIC S9(010)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0COBA_PRM_TAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0COBA-IMP-SEG-VR   PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0COBA_IMP_SEG_VR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0COBA-PRM-TAR-VR   PIC S9(010)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0COBA_PRM_TAR_VR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0COBA-PCT-COBERT   PIC S9(003)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0COBA_PCT_COBERT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         V0COBA-FATOR-MULT   PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0COBA_FATOR_MULT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COBA-DATA-INIVI   PIC  X(010).*/
        public StringBasis V0COBA_DATA_INIVI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0COBA-DATA-TERVI   PIC  X(010).*/
        public StringBasis V0COBA_DATA_TERVI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0COBA-COD-EMPRESA  PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0COBA_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0COBA-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0COBA_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V0COBA-SITUACAO     PIC  X(001)       VALUE '0'.*/
        public StringBasis V0COBA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"0");
        /*"77         V0ORDC-NUM-APOL     PIC S9(013)      VALUE +0  COMP-3*/
        public IntBasis V0ORDC_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0ORDC-NRENDOS      PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0ORDC_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0ORDC-CODCOSS      PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0ORDC_CODCOSS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ORDC-ORDEM-CED    PIC S9(015)      VALUE +0  COMP-3*/
        public IntBasis V0ORDC_ORDEM_CED { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0ORDC-COD-EMPRESA  PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0ORDC_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0ORDC-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0ORDC_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V1CROT-CGCCPF       PIC S9(015)      VALUE +0 COMP-3.*/
        public IntBasis V1CROT_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V1CROT-BILH-AP      PIC  X(001).*/
        public StringBasis V1CROT_BILH_AP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1CROT-BILH-RES     PIC  X(001).*/
        public StringBasis V1CROT_BILH_RES { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1CROT-BILH-VDAZUL  PIC  X(001).*/
        public StringBasis V1CROT_BILH_VDAZUL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1CROT-DTMOVABE     PIC  X(010).*/
        public StringBasis V1CROT_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0CROT-CGCCPF       PIC S9(015)      VALUE +0 COMP-3.*/
        public IntBasis V0CROT_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0CROT-BILH-AP      PIC  X(001).*/
        public StringBasis V0CROT_BILH_AP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0CROT-BILH-RES     PIC  X(001).*/
        public StringBasis V0CROT_BILH_RES { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0CROT-BILH-VDAZUL  PIC  X(001).*/
        public StringBasis V0CROT_BILH_VDAZUL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0CROT-DTMOVABE     PIC  X(010).*/
        public StringBasis V0CROT_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1COBI-COD-ESCNEG   PIC S9(004) COMP.*/
        public IntBasis V1COBI_COD_ESCNEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COBI-RAMO         PIC S9(004) COMP.*/
        public IntBasis V1COBI_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COBI-DTINIVIG     PIC  X(010).*/
        public StringBasis V1COBI_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1COBI-COBERTURA1   PIC  X(001).*/
        public StringBasis V1COBI_COBERTURA1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1COBI-COBERTURA2   PIC  X(001).*/
        public StringBasis V1COBI_COBERTURA2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1COBI-COBERTURA3   PIC  X(001).*/
        public StringBasis V1COBI_COBERTURA3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0C396-NUMBIL     PIC S9(015)    COMP-3 VALUE  ZEROS.*/
        public IntBasis V0C396_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0C396-DTMOVTO    PIC  X(010)           VALUE SPACES.*/
        public StringBasis V0C396_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77         V0C396-SITUACAO   PIC  X(001)           VALUE SPACES.*/
        public StringBasis V0C396_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77         V0C396-TIMESTAMP  PIC  X(026)           VALUE SPACES.*/
        public StringBasis V0C396_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
        /*"77         V0ADIA-CODPDT        PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0ADIA_CODPDT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0ADIA-FONTE         PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0ADIA_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ADIA-NUMOPG        PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0ADIA_NUMOPG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0ADIA-VALADT        PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis V0ADIA_VALADT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0ADIA-QTPRESTA      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0ADIA_QTPRESTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ADIA-NRPROPOS      PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0ADIA_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0ADIA-NUM-APOL      PIC S9(013)      VALUE +0 COMP-3*/
        public IntBasis V0ADIA_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0ADIA-NRENDOS       PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0ADIA_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0ADIA-NRPARCEL      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0ADIA_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ADIA-DTMOVTO       PIC  X(010).*/
        public StringBasis V0ADIA_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ADIA-SITUACAO      PIC  X(001).*/
        public StringBasis V0ADIA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ADIA-COD-EMP       PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0ADIA_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0ADIA-TIMESTAMP     PIC  X(026).*/
        public StringBasis V0ADIA_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V0ADIA-TIPO-ADT      PIC  X(001).*/
        public StringBasis V0ADIA_TIPO_ADT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0FORM-CODPDT        PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0FORM_CODPDT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0FORM-FONTE         PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0FORM_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0FORM-NUMOPG        PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0FORM_NUMOPG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0FORM-NRPROPOS      PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0FORM_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0FORM-NUM-APOL      PIC S9(013)      VALUE +0 COMP-3*/
        public IntBasis V0FORM_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0FORM-NRENDOS       PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0FORM_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0FORM-NRPARCEL      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0FORM_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0FORM-NUMPTC        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0FORM_NUMPTC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0FORM-VALRCP        PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis V0FORM_VALRCP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0FORM-PCGACM        PIC S9(002)V9(3) VALUE +0 COMP-3*/
        public DoubleBasis V0FORM_PCGACM { get; set; } = new DoubleBasis(new PIC("S9", "2", "S9(002)V9(3)"), 3);
        /*"77         V0FORM-SITUACAO      PIC  X(001).*/
        public StringBasis V0FORM_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0FORM-VALSDO        PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis V0FORM_VALSDO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0FORM-DTMOVTO       PIC  X(010).*/
        public StringBasis V0FORM_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0FORM-DTVENCTO      PIC  X(010).*/
        public StringBasis V0FORM_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0FORM-COD-EMP       PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0FORM_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0FORM-TIMESTAMP     PIC  X(026).*/
        public StringBasis V0FORM_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V0HISR-CODPDT        PIC S9(009)               COMP.*/
        public IntBasis V0HISR_CODPDT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HISR-FONTE         PIC S9(004)               COMP.*/
        public IntBasis V0HISR_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HISR-NUMOPG        PIC S9(009)               COMP.*/
        public IntBasis V0HISR_NUMOPG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HISR-NRPROPOS      PIC S9(009)               COMP.*/
        public IntBasis V0HISR_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HISR-NUM-APOL      PIC S9(013)               COMP-3*/
        public IntBasis V0HISR_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0HISR-NRENDOS       PIC S9(009)               COMP.*/
        public IntBasis V0HISR_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HISR-NRPARCEL      PIC S9(004)               COMP.*/
        public IntBasis V0HISR_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HISR-NUMPTC        PIC S9(004)               COMP.*/
        public IntBasis V0HISR_NUMPTC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HISR-VALRCP        PIC S9(013)V99            COMP-3*/
        public DoubleBasis V0HISR_VALRCP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0HISR-NUMREC        PIC S9(009)               COMP.*/
        public IntBasis V0HISR_NUMREC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HISR-DTMOVTO       PIC  X(010).*/
        public StringBasis V0HISR_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0HISR-OPERACAO      PIC S9(004)               COMP.*/
        public IntBasis V0HISR_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HISR-HORSIS        PIC  X(008).*/
        public StringBasis V0HISR_HORSIS { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V0HISR-COD-EMP       PIC S9(009)               COMP.*/
        public IntBasis V0HISR_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HISR-TIMESTAMP     PIC  X(026).*/
        public StringBasis V0HISR_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V0BILFX-VERSAO       PIC S9(004)               COMP.*/
        public IntBasis V0BILFX_VERSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0BILFX-VALADT       PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis V0BILFX_VALADT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0PROE-CODPRODU      PIC S9(004)               COMP.*/
        public IntBasis V0PROE_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0CLIE-CGCCPF        PIC S9(015)     VALUE +0 COMP-3.*/
        public IntBasis V0CLIE_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0CLIE-DTNASC        PIC  X(010).*/
        public StringBasis V0CLIE_DTNASC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         VIND-DTNASC          PIC S9(004)     VALUE +0 COMP.*/
        public IntBasis VIND_DTNASC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         GELMR-QTD-SEGUROS    PIC S9(004)     VALUE +0 COMP.*/
        public IntBasis GELMR_QTD_SEGUROS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         GELMR-VLR-SOMA-IS    PIC S9(013)V99  VALUE +0 COMP-3.*/
        public DoubleBasis GELMR_VLR_SOMA_IS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         WS-COD-CORRETOR      PIC  9(009)     VALUE 0.*/

        public SelectorBasis WS_COD_CORRETOR { get; set; } = new SelectorBasis("009", "0")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88       N88-COD-CORRETOR    VALUES  2496,  2933,  6327,  7005,                                      9440, 17256, 17604, 17752,                                     18040, 19224, 23914, 23922,                                     23931, 23949, 23957, 24112,                                     24121, 24163, 24236, 24287,                                     24295, 24309, 24317, 24333,                                     24341, 24368, 24384, 24392,                                     24431, 24449, 24457, 24481,                                     24716, 24937, 24945, 24970,                                     24996, 25003, 101150. */
							new SelectorItemBasis("N88_COD_CORRETOR", "2496,2933,6327,7005,9440,17256,17604,17752,18040,19224,23914,23922,23931,23949,23957,24112,24121,24163,24236,24287,24295,24309,24317,24333,24341,24368,24384,24392,24431,24449,24457,24481,24716,24937,24945,24970,24996,25003,101150")
                }
        };

        /*"01  WS-JV1-PROGRAMA                    PIC  X(008) VALUE SPACES.*/
        public StringBasis WS_JV1_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"01  WS-ERRO-COUNT               PIC S9(004) VALUE +0 COMP.*/
        public IntBasis WS_ERRO_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WS-COD-CRITICA              PIC  9(005) VALUE ZEROS.*/
        public IntBasis WS_COD_CRITICA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
        /*"01  WS-I-ERRO                   PIC  9(003) VALUE ZEROS.*/
        public IntBasis WS_I_ERRO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"01  WS-FLAG-TEM-ERRO            PIC  X(001) VALUE 'N'.*/
        public StringBasis WS_FLAG_TEM_ERRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"01  WORK-TAB-ERROS-CERT.*/
        public BI8005B_WORK_TAB_ERROS_CERT WORK_TAB_ERROS_CERT { get; set; } = new BI8005B_WORK_TAB_ERROS_CERT();
        public class BI8005B_WORK_TAB_ERROS_CERT : VarBasis
        {
            /*"    05  WS-TAB-ERROS-CERT   OCCURS 100 TIMES.*/
            public ListBasis<BI8005B_WS_TAB_ERROS_CERT> WS_TAB_ERROS_CERT { get; set; } = new ListBasis<BI8005B_WS_TAB_ERROS_CERT>(100);
            public class BI8005B_WS_TAB_ERROS_CERT : VarBasis
            {
                /*"      10  TB-ERRO-CERT          PIC S9(004) COMP.*/
                public IntBasis TB_ERRO_CERT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"01  TAB-CBO1.*/
            }
        }
        public BI8005B_TAB_CBO1 TAB_CBO1 { get; set; } = new BI8005B_TAB_CBO1();
        public class BI8005B_TAB_CBO1 : VarBasis
        {
            /*"    05      TAB-CBO.*/
            public BI8005B_TAB_CBO TAB_CBO { get; set; } = new BI8005B_TAB_CBO();
            public class BI8005B_TAB_CBO : VarBasis
            {
                /*"      10    FILLER    OCCURS    999   TIMES.*/
                public ListBasis<BI8005B_FILLER_0> FILLER_0 { get; set; } = new ListBasis<BI8005B_FILLER_0>(999);
                public class BI8005B_FILLER_0 : VarBasis
                {
                    /*"        15  TAB-DESCR-CBO-C          PIC  X(20).*/
                    public StringBasis TAB_DESCR_CBO_C { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
                    /*"01           WS-TIME.*/
                }
            }
        }
        public BI8005B_WS_TIME WS_TIME { get; set; } = new BI8005B_WS_TIME();
        public class BI8005B_WS_TIME : VarBasis
        {
            /*"  05         WS000-H            PIC  9(002).*/
            public IntBasis WS000_H { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05         WS000-M            PIC  9(002).*/
            public IntBasis WS000_M { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05         WS000-S            PIC  9(002).*/
            public IntBasis WS000_S { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05         WS000-C            PIC  9(002).*/
            public IntBasis WS000_C { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"01           WS000-HORA-TIME    PIC X(008).*/
        }
        public StringBasis WS000_HORA_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"01           WS000-HORA-TIME-REDF    REDEFINES             WS000-HORA-TIME.*/
        private _REDEF_BI8005B_WS000_HORA_TIME_REDF _ws000_hora_time_redf { get; set; }
        public _REDEF_BI8005B_WS000_HORA_TIME_REDF WS000_HORA_TIME_REDF
        {
            get { _ws000_hora_time_redf = new _REDEF_BI8005B_WS000_HORA_TIME_REDF(); _.Move(WS000_HORA_TIME, _ws000_hora_time_redf); VarBasis.RedefinePassValue(WS000_HORA_TIME, _ws000_hora_time_redf, WS000_HORA_TIME); _ws000_hora_time_redf.ValueChanged += () => { _.Move(_ws000_hora_time_redf, WS000_HORA_TIME); }; return _ws000_hora_time_redf; }
            set { VarBasis.RedefinePassValue(value, _ws000_hora_time_redf, WS000_HORA_TIME); }
        }  //Redefines
        public class _REDEF_BI8005B_WS000_HORA_TIME_REDF : VarBasis
        {
            /*"  05         WS000-HT           PIC  9(002).*/
            public IntBasis WS000_HT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05         WS000-P1           PIC  X(001).*/
            public StringBasis WS000_P1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05         WS000-MT           PIC  9(002).*/
            public IntBasis WS000_MT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05         WS000-P2           PIC  X(001).*/
            public StringBasis WS000_P2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05         WS000-ST           PIC  9(002).*/
            public IntBasis WS000_ST { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"01           WS000-PARM-PROSOMD1.*/

            public _REDEF_BI8005B_WS000_HORA_TIME_REDF()
            {
                WS000_HT.ValueChanged += OnValueChanged;
                WS000_P1.ValueChanged += OnValueChanged;
                WS000_MT.ValueChanged += OnValueChanged;
                WS000_P2.ValueChanged += OnValueChanged;
                WS000_ST.ValueChanged += OnValueChanged;
            }

        }
        public BI8005B_WS000_PARM_PROSOMD1 WS000_PARM_PROSOMD1 { get; set; } = new BI8005B_WS000_PARM_PROSOMD1();
        public class BI8005B_WS000_PARM_PROSOMD1 : VarBasis
        {
            /*"  05         WS000-DATA01       PIC  9(008).*/
            public IntBasis WS000_DATA01 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05         WS000-QTDIAS       PIC S9(005) COMP-3.*/
            public IntBasis WS000_QTDIAS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"  05         WS000-DATA02       PIC  9(008).*/
            public IntBasis WS000_DATA02 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"01         WS002-ACUMULADORES.*/
        }
        public BI8005B_WS002_ACUMULADORES WS002_ACUMULADORES { get; set; } = new BI8005B_WS002_ACUMULADORES();
        public class BI8005B_WS002_ACUMULADORES : VarBasis
        {
            /*"  05       WS002-IMP-SEG-IX  PIC S9(013)V9(2) VALUE +0 COMP-3.*/
            public DoubleBasis WS002_IMP_SEG_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
            /*"  05       WS002-IMP-SEG-VR  PIC S9(013)V9(2) VALUE +0 COMP-3.*/
            public DoubleBasis WS002_IMP_SEG_VR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
            /*"  05       WS002-PRM-TAR-IX  PIC S9(010)V9(5) VALUE +0 COMP-3.*/
            public DoubleBasis WS002_PRM_TAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
            /*"  05       WS002-PRM-TAR-VR  PIC S9(010)V9(5) VALUE +0 COMP-3.*/
            public DoubleBasis WS002_PRM_TAR_VR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
            /*"01     LK-PLANO                PIC S9(4)      USAGE COMP.*/
        }
        public IntBasis LK_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01     LK-SERIE                PIC S9(4)      USAGE COMP.*/
        public IntBasis LK_SERIE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01     LK-TITULO               PIC S9(9)      USAGE COMP.*/
        public IntBasis LK_TITULO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01     LK-NUM-PROPOSTA         PIC S9(15)V    USAGE COMP-3.*/
        public DoubleBasis LK_NUM_PROPOSTA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"01     LK-QTD-TITULOS          PIC S9(4)      USAGE COMP.*/
        public IntBasis LK_QTD_TITULOS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01     LK-VLR-TITULO           PIC S9(8)V9(2) USAGE COMP-3.*/
        public DoubleBasis LK_VLR_TITULO { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(8)V9(2)"), 2);
        /*"01     LK-PARCEIRO             PIC S9(4)      USAGE COMP.*/
        public IntBasis LK_PARCEIRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01     LK-RAMO                 PIC S9(4)      USAGE COMP.*/
        public IntBasis LK_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01     LK-NUM-NSA              PIC S9(4)      USAGE COMP.*/
        public IntBasis LK_NUM_NSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01     LK-TRACE                PIC X(009).*/

        public SelectorBasis LK_TRACE { get; set; } = new SelectorBasis("009")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88   LK-TRACE-ON             VALUE 'TRACE ON '. */
							new SelectorItemBasis("LK_TRACE_ON", "TRACE ON "),
							/*" 88   LK-TRACE-OFF            VALUE 'TRACE OFF'. */
							new SelectorItemBasis("LK_TRACE_OFF", "TRACE OFF")
                }
        };

        /*"01     LK-OUT-COD-RETORNO     PIC S9(004) COMP.*/
        public IntBasis LK_OUT_COD_RETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01     LK-OUT-SQLCODE         PIC S9(004) COMP.*/
        public IntBasis LK_OUT_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01     LK-OUT-MENSAGEM        PIC X(070).*/
        public StringBasis LK_OUT_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
        /*"01     LK-OUT-SQLERRMC        PIC X(070).*/
        public StringBasis LK_OUT_SQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
        /*"01     LK-OUT-SQLSTATE        PIC X(005).*/
        public StringBasis LK_OUT_SQLSTATE { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
        /*"01           AREA-DE-WORK.*/
        public BI8005B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new BI8005B_AREA_DE_WORK();
        public class BI8005B_AREA_DE_WORK : VarBasis
        {
            /*"  05         WSL-SQLCODE       PIC  9(009)    VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WACC-PCTCED       PIC S9(004)V9(05) VALUE +0 COMP-3*/
            public DoubleBasis WACC_PCTCED { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(05)"), 5);
            /*"  05         WACC-QTCOSSEG     PIC  9(004)       VALUE  ZEROS.*/
            public IntBasis WACC_QTCOSSEG { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         WACC-LIDOS        PIC  9(006)       VALUE  ZEROS.*/
            public IntBasis WACC_LIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WACC-DISPLAY      PIC  9(006)       VALUE  ZEROS.*/
            public IntBasis WACC_DISPLAY { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WACC-PROCESSADOS  PIC  9(006)       VALUE  ZEROS.*/
            public IntBasis WACC_PROCESSADOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         LD-BILHETE        PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis LD_BILHETE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         DP-PLCOBER        PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis DP_PLCOBER { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         DP-RISCO          PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis DP_RISCO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         DP-BILCOBE        PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis DP_BILCOBE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         DP-RCAPS          PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis DP_RCAPS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         DP-APOLICE        PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis DP_APOLICE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         DP-ACUMULA        PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis DP_ACUMULA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         DP-ITENS          PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis DP_ITENS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WFIM-CBO          PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_CBO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V0BILHETE    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V0BILHETE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1BILCOBER   PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1BILCOBER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1SISTEMA    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1SISTEMA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1CLIENTE    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1CLIENTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1COMIFENAE  PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1COMIFENAE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1FUNCIOCEF  PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1FUNCIOCEF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1RCAP       PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1RCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1RCAPCOMP   PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1RCAPCOMP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1COMERC-BIL PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1COMERC_BIL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WS-SIVPF          PIC  X(001)    VALUE SPACES.*/
            public StringBasis WS_SIVPF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         AC-LIDOS           PIC  9(013)    VALUE   ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  05         FILLER             REDEFINES      AC-LIDOS.*/
            private _REDEF_BI8005B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_BI8005B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_BI8005B_FILLER_1(); _.Move(AC_LIDOS, _filler_1); VarBasis.RedefinePassValue(AC_LIDOS, _filler_1, AC_LIDOS); _filler_1.ValueChanged += () => { _.Move(_filler_1, AC_LIDOS); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, AC_LIDOS); }
            }  //Redefines
            public class _REDEF_BI8005B_FILLER_1 : VarBasis
            {
                /*"      10     LD-PARTE1          PIC  9(009).*/
                public IntBasis LD_PARTE1 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"      10     LD-PARTE2          PIC  9(004).*/
                public IntBasis LD_PARTE2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05         QT-CRITICA         PIC  9(013) VALUE 0.*/

                public _REDEF_BI8005B_FILLER_1()
                {
                    LD_PARTE1.ValueChanged += OnValueChanged;
                    LD_PARTE2.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis QT_CRITICA { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  05         WWORK-FUNDAO      PIC  X(001)    VALUE SPACE.*/
            public StringBasis WWORK_FUNDAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WPROC-BILHETES    PIC  9(005)    VALUE ZEROS.*/
            public IntBasis WPROC_BILHETES { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         WTEM-PROPESTIP          PIC  X(001)    VALUE SPACES*/
            public StringBasis WTEM_PROPESTIP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WTEM-GELMR              PIC  X(003)    VALUE SPACES*/
            public StringBasis WTEM_GELMR { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05         WWORK-NUM-APOL    PIC  9(013)    VALUE ZEROS.*/
            public IntBasis WWORK_NUM_APOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  05         FILLER            REDEFINES      WWORK-NUM-APOL.*/
            private _REDEF_BI8005B_FILLER_2 _filler_2 { get; set; }
            public _REDEF_BI8005B_FILLER_2 FILLER_2
            {
                get { _filler_2 = new _REDEF_BI8005B_FILLER_2(); _.Move(WWORK_NUM_APOL, _filler_2); VarBasis.RedefinePassValue(WWORK_NUM_APOL, _filler_2, WWORK_NUM_APOL); _filler_2.ValueChanged += () => { _.Move(_filler_2, WWORK_NUM_APOL); }; return _filler_2; }
                set { VarBasis.RedefinePassValue(value, _filler_2, WWORK_NUM_APOL); }
            }  //Redefines
            public class _REDEF_BI8005B_FILLER_2 : VarBasis
            {
                /*"    10       WWORK-ORG-APOL    PIC  9(003).*/
                public IntBasis WWORK_ORG_APOL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10       WWORK-RMO-APOL    PIC  9(002).*/
                public IntBasis WWORK_RMO_APOL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WWORK-SEQ-APOL    PIC  9(008).*/
                public IntBasis WWORK_SEQ_APOL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"  05         WWORK-PCPARCOR-I  PIC S9(003)V99   COMP-3.*/

                public _REDEF_BI8005B_FILLER_2()
                {
                    WWORK_ORG_APOL.ValueChanged += OnValueChanged;
                    WWORK_RMO_APOL.ValueChanged += OnValueChanged;
                    WWORK_SEQ_APOL.ValueChanged += OnValueChanged;
                }

            }
            public DoubleBasis WWORK_PCPARCOR_I { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"  05         WWORK-PCPARCOR-F  PIC S9(003)V99   COMP-3.*/
            public DoubleBasis WWORK_PCPARCOR_F { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"  05         WWORK-PCCOMCOR-I  PIC S9(003)V99   COMP-3.*/
            public DoubleBasis WWORK_PCCOMCOR_I { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"  05         WWORK-PCCOMCOR-F  PIC S9(003)V99   COMP-3.*/
            public DoubleBasis WWORK_PCCOMCOR_F { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"  05         WWORK-PCPARCOR    PIC S9(003)V9(5) COMP-3.*/
            public DoubleBasis WWORK_PCPARCOR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(5)"), 5);
            /*"  05         WWORK-PCCOMCOR    PIC S9(003)V9(5) COMP-3.*/
            public DoubleBasis WWORK_PCCOMCOR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(5)"), 5);
            /*"  05         WWORK-IS-APOL     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis WWORK_IS_APOL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         WWORK-PR-APOL     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis WWORK_PR_APOL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         WWORK-IOCC        PIC S9(013)V99 COMP-3.*/
            public DoubleBasis WWORK_IOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         WWORK-PR-TOT      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis WWORK_PR_TOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         WS-VALORDIF       PIC S9(013)V99 COMP-3.*/
            public DoubleBasis WS_VALORDIF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         WS-VALORMAIS      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis WS_VALORMAIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         WS-VLDIFE         PIC S9(013)V99 COMP-3.*/
            public DoubleBasis WS_VLDIFE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         WS-VLMAIOR        PIC S9(013)V99 COMP-3.*/
            public DoubleBasis WS_VLMAIOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         AUX-VALBAS        PIC S9(013)V99       COMP-3.*/
            public DoubleBasis AUX_VALBAS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         AUX-PERCENT       PIC S9(003)V9999     COMP-3.*/
            public DoubleBasis AUX_PERCENT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9999"), 4);
            /*"  05         WWORK-NUM-ITENS   PIC S9(009)    COMP.*/
            public IntBasis WWORK_NUM_ITENS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05         WWORK-NUM-ORDEM   PIC  9(014)    VALUE ZEROS.*/
            public IntBasis WWORK_NUM_ORDEM { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"  05         FILLER            REDEFINES      WWORK-NUM-ORDEM.*/
            private _REDEF_BI8005B_FILLER_3 _filler_3 { get; set; }
            public _REDEF_BI8005B_FILLER_3 FILLER_3
            {
                get { _filler_3 = new _REDEF_BI8005B_FILLER_3(); _.Move(WWORK_NUM_ORDEM, _filler_3); VarBasis.RedefinePassValue(WWORK_NUM_ORDEM, _filler_3, WWORK_NUM_ORDEM); _filler_3.ValueChanged += () => { _.Move(_filler_3, WWORK_NUM_ORDEM); }; return _filler_3; }
                set { VarBasis.RedefinePassValue(value, _filler_3, WWORK_NUM_ORDEM); }
            }  //Redefines
            public class _REDEF_BI8005B_FILLER_3 : VarBasis
            {
                /*"    10       WWORK-ORD-CONGE   PIC  9(004).*/
                public IntBasis WWORK_ORD_CONGE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WWORK-ORD-ORGAO   PIC  9(003).*/
                public IntBasis WWORK_ORD_ORGAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10       WWORK-ORD-SEQUE   PIC  9(007).*/
                public IntBasis WWORK_ORD_SEQUE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
                /*"  05         WWORK-NUMBIL      PIC  9(015)    VALUE ZEROS.*/

                public _REDEF_BI8005B_FILLER_3()
                {
                    WWORK_ORD_CONGE.ValueChanged += OnValueChanged;
                    WWORK_ORD_ORGAO.ValueChanged += OnValueChanged;
                    WWORK_ORD_SEQUE.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WWORK_NUMBIL { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"  05         FILLER            REDEFINES      WWORK-NUMBIL.*/
            private _REDEF_BI8005B_FILLER_4 _filler_4 { get; set; }
            public _REDEF_BI8005B_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_BI8005B_FILLER_4(); _.Move(WWORK_NUMBIL, _filler_4); VarBasis.RedefinePassValue(WWORK_NUMBIL, _filler_4, WWORK_NUMBIL); _filler_4.ValueChanged += () => { _.Move(_filler_4, WWORK_NUMBIL); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, WWORK_NUMBIL); }
            }  //Redefines
            public class _REDEF_BI8005B_FILLER_4 : VarBasis
            {
                /*"    10       FILLER            PIC  9(004).*/
                public IntBasis FILLER_5 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WWORK-NRRCAP      PIC  9(009).*/
                public IntBasis WWORK_NRRCAP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10       FILLER            PIC  9(002).*/
                public IntBasis FILLER_6 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05   WWORK-INFORM-COMPLEME.*/

                public _REDEF_BI8005B_FILLER_4()
                {
                    FILLER_5.ValueChanged += OnValueChanged;
                    WWORK_NRRCAP.ValueChanged += OnValueChanged;
                    FILLER_6.ValueChanged += OnValueChanged;
                }

            }
            public BI8005B_WWORK_INFORM_COMPLEME WWORK_INFORM_COMPLEME { get; set; } = new BI8005B_WWORK_INFORM_COMPLEME();
            public class BI8005B_WWORK_INFORM_COMPLEME : VarBasis
            {
                /*"     07  W-PAIS-DESTINO        PIC 9(004).*/
                public IntBasis W_PAIS_DESTINO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"     07  W-DATAS-VIAGEM.*/
                public BI8005B_W_DATAS_VIAGEM W_DATAS_VIAGEM { get; set; } = new BI8005B_W_DATAS_VIAGEM();
                public class BI8005B_W_DATAS_VIAGEM : VarBasis
                {
                    /*"       10  W-DATA-IDA-VIAGEM.*/
                    public BI8005B_W_DATA_IDA_VIAGEM W_DATA_IDA_VIAGEM { get; set; } = new BI8005B_W_DATA_IDA_VIAGEM();
                    public class BI8005B_W_DATA_IDA_VIAGEM : VarBasis
                    {
                        /*"         15  W-DIA-IDA-VIAGEM  PIC 99.*/
                        public IntBasis W_DIA_IDA_VIAGEM { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                        /*"         15  W-MES-IDA-VIAGEM  PIC 99.*/
                        public IntBasis W_MES_IDA_VIAGEM { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                        /*"         15  W-ANO-IDA-VIAGEM  PIC 9(4).*/
                        public IntBasis W_ANO_IDA_VIAGEM { get; set; } = new IntBasis(new PIC("9", "4", "9(4)."));
                        /*"       10  W-DATA-VOL-VIAGEM.*/
                    }
                    public BI8005B_W_DATA_VOL_VIAGEM W_DATA_VOL_VIAGEM { get; set; } = new BI8005B_W_DATA_VOL_VIAGEM();
                    public class BI8005B_W_DATA_VOL_VIAGEM : VarBasis
                    {
                        /*"         15  W-DIA-VOL-VIAGEM  PIC 99.*/
                        public IntBasis W_DIA_VOL_VIAGEM { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                        /*"         15  W-MES-VOL-VIAGEM  PIC 99.*/
                        public IntBasis W_MES_VOL_VIAGEM { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                        /*"         15  W-ANO-VOL-VIAGEM  PIC 9(4).*/
                        public IntBasis W_ANO_VOL_VIAGEM { get; set; } = new IntBasis(new PIC("9", "4", "9(4)."));
                        /*"     07  FILLER                PIC X(235).*/
                    }
                }
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "235", "X(235)."), @"");
                /*"  05   WWORK-VIGENCIA-VIAGEM.*/
            }
            public BI8005B_WWORK_VIGENCIA_VIAGEM WWORK_VIGENCIA_VIAGEM { get; set; } = new BI8005B_WWORK_VIGENCIA_VIAGEM();
            public class BI8005B_WWORK_VIGENCIA_VIAGEM : VarBasis
            {
                /*"       10  W-DATA-INI-VIG-VIAGEM.*/
                public BI8005B_W_DATA_INI_VIG_VIAGEM W_DATA_INI_VIG_VIAGEM { get; set; } = new BI8005B_W_DATA_INI_VIG_VIAGEM();
                public class BI8005B_W_DATA_INI_VIG_VIAGEM : VarBasis
                {
                    /*"         15  W-ANO-INI-VIG-VIAGEM  PIC 9(4)   VALUE ZEROS.*/
                    public IntBasis W_ANO_INI_VIG_VIAGEM { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
                    /*"         15  FILLER                PIC X(001) VALUE   '-'.*/
                    public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                    /*"         15  W-MES-INI-VIG-VIAGEM  PIC 99     VALUE ZEROS.*/
                    public IntBasis W_MES_INI_VIG_VIAGEM { get; set; } = new IntBasis(new PIC("9", "2", "99"));
                    /*"         15  FILLER                PIC X(001) VALUE   '-'.*/
                    public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                    /*"         15  W-DIA-INI-VIG-VIAGEM  PIC 99     VALUE ZEROS.*/
                    public IntBasis W_DIA_INI_VIG_VIAGEM { get; set; } = new IntBasis(new PIC("9", "2", "99"));
                    /*"       10  W-DATA-FIM-VIG-VIAGEM.*/
                }
                public BI8005B_W_DATA_FIM_VIG_VIAGEM W_DATA_FIM_VIG_VIAGEM { get; set; } = new BI8005B_W_DATA_FIM_VIG_VIAGEM();
                public class BI8005B_W_DATA_FIM_VIG_VIAGEM : VarBasis
                {
                    /*"         15  W-ANO-FIM-VIG-VIAGEM  PIC 9(4)   VALUE ZEROS.*/
                    public IntBasis W_ANO_FIM_VIG_VIAGEM { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
                    /*"         15  FILLER                PIC X(001) VALUE   '-'.*/
                    public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                    /*"         15  W-MES-FIM-VIG-VIAGEM  PIC 99     VALUE ZEROS.*/
                    public IntBasis W_MES_FIM_VIG_VIAGEM { get; set; } = new IntBasis(new PIC("9", "2", "99"));
                    /*"         15  FILLER                PIC X(001) VALUE   '-'.*/
                    public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                    /*"         15  W-DIA-FIM-VIG-VIAGEM  PIC 99     VALUE ZEROS.*/
                    public IntBasis W_DIA_FIM_VIG_VIAGEM { get; set; } = new IntBasis(new PIC("9", "2", "99"));
                    /*"  05         WWORK-NR-PROPOSTA PIC  9(014)    VALUE ZEROS.*/
                }
            }
            public IntBasis WWORK_NR_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"  05         FILLER            REDEFINES      WWORK-NR-PROPOSTA.*/
            private _REDEF_BI8005B_FILLER_12 _filler_12 { get; set; }
            public _REDEF_BI8005B_FILLER_12 FILLER_12
            {
                get { _filler_12 = new _REDEF_BI8005B_FILLER_12(); _.Move(WWORK_NR_PROPOSTA, _filler_12); VarBasis.RedefinePassValue(WWORK_NR_PROPOSTA, _filler_12, WWORK_NR_PROPOSTA); _filler_12.ValueChanged += () => { _.Move(_filler_12, WWORK_NR_PROPOSTA); }; return _filler_12; }
                set { VarBasis.RedefinePassValue(value, _filler_12, WWORK_NR_PROPOSTA); }
            }  //Redefines
            public class _REDEF_BI8005B_FILLER_12 : VarBasis
            {
                /*"        07  W-CANAL-PROPOSTA          PIC 9(001).*/

                public SelectorBasis W_CANAL_PROPOSTA { get; set; } = new SelectorBasis("001")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88 CANAL-VENDA-PAPEL          VALUE 0. */
							new SelectorItemBasis("CANAL_VENDA_PAPEL", "0"),
							/*" 88 CANAL-VENDA-CEF            VALUE 1. */
							new SelectorItemBasis("CANAL_VENDA_CEF", "1"),
							/*" 88 CANAL-SASSE-FILIAL         VALUE 2. */
							new SelectorItemBasis("CANAL_SASSE_FILIAL", "2"),
							/*" 88 CANAL-CORRETOR             VALUE 3. */
							new SelectorItemBasis("CANAL_CORRETOR", "3"),
							/*" 88 CANAL-CORREIO              VALUE 4. */
							new SelectorItemBasis("CANAL_CORREIO", "4"),
							/*" 88 CANAL-ATM                  VALUE 4. */
							new SelectorItemBasis("CANAL_ATM", "4"),
							/*" 88 CANAL-GITEL                VALUE 5. */
							new SelectorItemBasis("CANAL_GITEL", "5"),
							/*" 88 CANAL-INTERNET             VALUE 7. */
							new SelectorItemBasis("CANAL_INTERNET", "7"),
							/*" 88 CANAL-INTRANET             VALUE 8. */
							new SelectorItemBasis("CANAL_INTRANET", "8")
                }
                };

                /*"        07  FILLER                    PIC 9(013).*/
                public IntBasis FILLER_13 { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"  05         WWORK-DATA.*/

                public _REDEF_BI8005B_FILLER_12()
                {
                    W_CANAL_PROPOSTA.ValueChanged += OnValueChanged;
                    FILLER_13.ValueChanged += OnValueChanged;
                }

            }
            public BI8005B_WWORK_DATA WWORK_DATA { get; set; } = new BI8005B_WWORK_DATA();
            public class BI8005B_WWORK_DATA : VarBasis
            {
                /*"    10       WWORK-ANO         PIC  9(004).*/
                public IntBasis WWORK_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10       WWORK-MES         PIC  9(002).*/
                public IntBasis WWORK_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10       WWORK-DIA         PIC  9(002).*/
                public IntBasis WWORK_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WWORK-ANO-3       PIC  9(004).*/
            }
            public IntBasis WWORK_ANO_3 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         WWORK-ANO-BI      PIC  9(009)    COMP-3.*/
            public IntBasis WWORK_ANO_BI { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WDATA-REL         PIC  X(010)    VALUE SPACES.*/
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WDATA-REL.*/
            private _REDEF_BI8005B_FILLER_16 _filler_16 { get; set; }
            public _REDEF_BI8005B_FILLER_16 FILLER_16
            {
                get { _filler_16 = new _REDEF_BI8005B_FILLER_16(); _.Move(WDATA_REL, _filler_16); VarBasis.RedefinePassValue(WDATA_REL, _filler_16, WDATA_REL); _filler_16.ValueChanged += () => { _.Move(_filler_16, WDATA_REL); }; return _filler_16; }
                set { VarBasis.RedefinePassValue(value, _filler_16, WDATA_REL); }
            }  //Redefines
            public class _REDEF_BI8005B_FILLER_16 : VarBasis
            {
                /*"    10       WDAT-REL-ANO      PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-MES      PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-DIA      PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATA-SISTEMA.*/

                public _REDEF_BI8005B_FILLER_16()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_17.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_18.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public BI8005B_WDATA_SISTEMA WDATA_SISTEMA { get; set; } = new BI8005B_WDATA_SISTEMA();
            public class BI8005B_WDATA_SISTEMA : VarBasis
            {
                /*"    10       WDATA-SIS-ANO     PIC  X(004).*/
                public StringBasis WDATA_SIS_ANO { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-SIS-MES     PIC  X(002).*/
                public StringBasis WDATA_SIS_MES { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-SIS-DIA     PIC  X(002).*/
                public StringBasis WDATA_SIS_DIA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"  05         WWORK-DATAINI     PIC  9(008)  VALUE ZEROS.*/
            }
            public IntBasis WWORK_DATAINI { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         FILLER            REDEFINES    WWORK-DATAINI.*/
            private _REDEF_BI8005B_FILLER_21 _filler_21 { get; set; }
            public _REDEF_BI8005B_FILLER_21 FILLER_21
            {
                get { _filler_21 = new _REDEF_BI8005B_FILLER_21(); _.Move(WWORK_DATAINI, _filler_21); VarBasis.RedefinePassValue(WWORK_DATAINI, _filler_21, WWORK_DATAINI); _filler_21.ValueChanged += () => { _.Move(_filler_21, WWORK_DATAINI); }; return _filler_21; }
                set { VarBasis.RedefinePassValue(value, _filler_21, WWORK_DATAINI); }
            }  //Redefines
            public class _REDEF_BI8005B_FILLER_21 : VarBasis
            {
                /*"    10       WWORK-DIAINI      PIC  9(002).*/
                public IntBasis WWORK_DIAINI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WWORK-MESINI      PIC  9(002).*/
                public IntBasis WWORK_MESINI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WWORK-ANOINI      PIC  9(004).*/
                public IntBasis WWORK_ANOINI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05         WWORK-DATATER     PIC  9(008)  VALUE ZEROS.*/

                public _REDEF_BI8005B_FILLER_21()
                {
                    WWORK_DIAINI.ValueChanged += OnValueChanged;
                    WWORK_MESINI.ValueChanged += OnValueChanged;
                    WWORK_ANOINI.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WWORK_DATATER { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         FILLER            REDEFINES    WWORK-DATATER.*/
            private _REDEF_BI8005B_FILLER_22 _filler_22 { get; set; }
            public _REDEF_BI8005B_FILLER_22 FILLER_22
            {
                get { _filler_22 = new _REDEF_BI8005B_FILLER_22(); _.Move(WWORK_DATATER, _filler_22); VarBasis.RedefinePassValue(WWORK_DATATER, _filler_22, WWORK_DATATER); _filler_22.ValueChanged += () => { _.Move(_filler_22, WWORK_DATATER); }; return _filler_22; }
                set { VarBasis.RedefinePassValue(value, _filler_22, WWORK_DATATER); }
            }  //Redefines
            public class _REDEF_BI8005B_FILLER_22 : VarBasis
            {
                /*"    10       WWORK-DIATER      PIC  9(002).*/
                public IntBasis WWORK_DIATER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WWORK-MESTER      PIC  9(002).*/
                public IntBasis WWORK_MESTER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WWORK-ANOTER      PIC  9(004).*/
                public IntBasis WWORK_ANOTER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05         WWORK-QTCOSSEG    PIC  9(002)  VALUE ZEROS.*/

                public _REDEF_BI8005B_FILLER_22()
                {
                    WWORK_DIATER.ValueChanged += OnValueChanged;
                    WWORK_MESTER.ValueChanged += OnValueChanged;
                    WWORK_ANOTER.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WWORK_QTCOSSEG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05         WDATA-CURR.*/
            public BI8005B_WDATA_CURR WDATA_CURR { get; set; } = new BI8005B_WDATA_CURR();
            public class BI8005B_WDATA_CURR : VarBasis
            {
                /*"    10       WDATA-AA-CURR     PIC  9(004)    VALUE  ZEROS.*/
                public IntBasis WDATA_AA_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-MM-CURR     PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WDATA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-DD-CURR     PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WDATA_DD_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WDATA-CABEC.*/
            }
            public BI8005B_WDATA_CABEC WDATA_CABEC { get; set; } = new BI8005B_WDATA_CABEC();
            public class BI8005B_WDATA_CABEC : VarBasis
            {
                /*"    10       WDATA-DD-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDATA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDATA-AA-CABEC    PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05         WS-CODANGAR-R.*/
            }
            public BI8005B_WS_CODANGAR_R WS_CODANGAR_R { get; set; } = new BI8005B_WS_CODANGAR_R();
            public class BI8005B_WS_CODANGAR_R : VarBasis
            {
                /*"    10       WS-NUM-ANGAR      PIC  9(006)   VALUE 0.*/
                public IntBasis WS_NUM_ANGAR { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
                /*"    10       WS-DAC-ANGAR      PIC  9(001)   VALUE 0.*/
                public IntBasis WS_DAC_ANGAR { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
                /*"  05         WS-CODANGAR       REDEFINES     WS-CODANGAR-R                               PIC  9(007).*/
            }
            private _REDEF_IntBasis _ws_codangar { get; set; }
            public _REDEF_IntBasis WS_CODANGAR
            {
                get { _ws_codangar = new _REDEF_IntBasis(new PIC("9", "007", "9(007).")); ; _.Move(WS_CODANGAR_R, _ws_codangar); VarBasis.RedefinePassValue(WS_CODANGAR_R, _ws_codangar, WS_CODANGAR_R); _ws_codangar.ValueChanged += () => { _.Move(_ws_codangar, WS_CODANGAR_R); }; return _ws_codangar; }
                set { VarBasis.RedefinePassValue(value, _ws_codangar, WS_CODANGAR_R); }
            }  //Redefines
            /*"  05         PROM11W099.*/
            public BI8005B_PROM11W099 PROM11W099 { get; set; } = new BI8005B_PROM11W099();
            public class BI8005B_PROM11W099 : VarBasis
            {
                /*"    10       PROM11W099-NUMERO   PIC  9(015).*/
                public IntBasis PROM11W099_NUMERO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    10       PROM11W099-TAM      PIC S9(004)   COMP.*/
                public IntBasis PROM11W099_TAM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    10       PROM11W099-DAC      PIC  X(001).*/
                public StringBasis PROM11W099_DAC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"  05         WS-NUMREC-R.*/
            }
            public BI8005B_WS_NUMREC_R WS_NUMREC_R { get; set; } = new BI8005B_WS_NUMREC_R();
            public class BI8005B_WS_NUMREC_R : VarBasis
            {
                /*"    10       WS-AA-NUMREC        PIC  9(004)   VALUE 0.*/
                public IntBasis WS_AA_NUMREC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10       WS-NN-NUMREC        PIC  9(004)   VALUE 0.*/
                public IntBasis WS_NN_NUMREC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05         WS-NUMREC           REDEFINES     WS-NUMREC-R                                 PIC  9(008).*/
            }
            private _REDEF_IntBasis _ws_numrec { get; set; }
            public _REDEF_IntBasis WS_NUMREC
            {
                get { _ws_numrec = new _REDEF_IntBasis(new PIC("9", "008", "9(008).")); ; _.Move(WS_NUMREC_R, _ws_numrec); VarBasis.RedefinePassValue(WS_NUMREC_R, _ws_numrec, WS_NUMREC_R); _ws_numrec.ValueChanged += () => { _.Move(_ws_numrec, WS_NUMREC_R); }; return _ws_numrec; }
                set { VarBasis.RedefinePassValue(value, _ws_numrec, WS_NUMREC_R); }
            }  //Redefines
            /*"  05         WLINK-DATATER         PIC  9(008)   VALUE ZEROS.*/
            public IntBasis WLINK_DATATER { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         WLINK-DATAINI         PIC  9(008)   VALUE ZEROS.*/
            public IntBasis WLINK_DATAINI { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         WLINK-QTDDIAS         PIC S9(005)   VALUE +0 COMP-3*/
            public IntBasis WLINK_QTDDIAS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"  05         AC-I-V0APOLICE        PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_I_V0APOLICE { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0ENDOSSO        PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_I_V0ENDOSSO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0RCAPCOMP       PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_I_V0RCAPCOMP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0APOLCORRET     PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_I_V0APOLCORRET { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0APOLCOSCED     PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_I_V0APOLCOSCED { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0ORDECOSCED     PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_I_V0ORDECOSCED { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0PARCELA        PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_I_V0PARCELA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0HISTOPARC      PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_I_V0HISTOPARC { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0COBERAPOL      PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_I_V0COBERAPOL { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0PRODUTOR       PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_I_V0PRODUTOR { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0CLIE-CROT      PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_I_V0CLIE_CROT { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0ADIANTA        PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_I_V0ADIANTA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-GELMR            PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_I_GELMR { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-U-V0APOLICE        PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_U_V0APOLICE { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-U-V0RCAP           PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_U_V0RCAP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-U-V0RCAPCOMP       PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_U_V0RCAPCOMP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-U-V0NUMEROUT       PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_U_V0NUMEROUT { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-U-V0NUMERAES       PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_U_V0NUMERAES { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-U-V0FONTE          PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_U_V0FONTE { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-U-V0FUNCIOCEF      PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_U_V0FUNCIOCEF { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-U-V0BILHETE        PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_U_V0BILHETE { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-U-V0NUMERO-COSSEGURO PIC  9(005) VALUE ZEROS.*/
            public IntBasis AC_U_V0NUMERO_COSSEGURO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-U-V0COMIFENAE      PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_U_V0COMIFENAE { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-U-V0CLIE-CROT      PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_U_V0CLIE_CROT { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-U-GELMR            PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_U_GELMR { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            WDATA-MOVABE.*/
            public BI8005B_WDATA_MOVABE WDATA_MOVABE { get; set; } = new BI8005B_WDATA_MOVABE();
            public class BI8005B_WDATA_MOVABE : VarBasis
            {
                /*"    10          WDATA-AA-MOVABE PIC  9(004)     VALUE    ZEROS.*/
                public IntBasis WDATA_AA_MOVABE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10          FILLER          PIC  X(001)     VALUE   '-'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10          WDATA-MM-MOVABE PIC  9(002)     VALUE    ZEROS.*/
                public IntBasis WDATA_MM_MOVABE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          FILLER          PIC  X(001)     VALUE   '-'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10          WDATA-DD-MOVABE PIC  9(002)     VALUE    ZEROS.*/
                public IntBasis WDATA_DD_MOVABE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05            WDATA-WORK.*/
            }
            public BI8005B_WDATA_WORK WDATA_WORK { get; set; } = new BI8005B_WDATA_WORK();
            public class BI8005B_WDATA_WORK : VarBasis
            {
                /*"    10          WDATA-AA-WORK   PIC  9(004)     VALUE    ZEROS.*/
                public IntBasis WDATA_AA_WORK { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10          FILLER          PIC  X(001)     VALUE   '-'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10          WDATA-MM-WORK   PIC  9(002)     VALUE    ZEROS.*/
                public IntBasis WDATA_MM_WORK { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          FILLER          PIC  X(001)     VALUE   '-'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10          WDATA-DD-WORK   PIC  9(002)     VALUE    ZEROS.*/
                public IntBasis WDATA_DD_WORK { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05   WS-SQLCODE                    PIC  ----9.*/
            }
            public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "5", "----9."));
            /*"  05        WABEND.*/
            public BI8005B_WABEND WABEND { get; set; } = new BI8005B_WABEND();
            public class BI8005B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(008) VALUE           'BI8005B '.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"BI8005B ");
                /*"    10      FILLER              PIC  X(025) VALUE           '*** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"*** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC  X(004) VALUE '0001'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0001");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"01            LPARM.*/
            }
        }
        public BI8005B_LPARM LPARM { get; set; } = new BI8005B_LPARM();
        public class BI8005B_LPARM : VarBasis
        {
            /*"  03          LPARM01.*/
            public BI8005B_LPARM01 LPARM01 { get; set; } = new BI8005B_LPARM01();
            public class BI8005B_LPARM01 : VarBasis
            {
                /*"    10        LPARM01-DD          PIC  9(002).*/
                public IntBasis LPARM01_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10        LPARM01-MM          PIC  9(002).*/
                public IntBasis LPARM01_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10        LPARM01-AA          PIC  9(004).*/
                public IntBasis LPARM01_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  03          LPARM02.*/
            }
            public BI8005B_LPARM02 LPARM02 { get; set; } = new BI8005B_LPARM02();
            public class BI8005B_LPARM02 : VarBasis
            {
                /*"    10        LPARM02-DD          PIC  9(002).*/
                public IntBasis LPARM02_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10        LPARM02-MM          PIC  9(002).*/
                public IntBasis LPARM02_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10        LPARM02-AA          PIC  9(004).*/
                public IntBasis LPARM02_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  03          LPARM03             PIC S9(005)    COMP-3.*/
            }
            public IntBasis LPARM03 { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
        }


        public Copies.GEJVW002 GEJVW002 { get; set; } = new Copies.GEJVW002();
        public Copies.GEJVWCNT GEJVWCNT { get; set; } = new Copies.GEJVWCNT();
        public Copies.SPVG001V SPVG001V { get; set; } = new Copies.SPVG001V();
        public Copies.SPVG001W SPVG001W { get; set; } = new Copies.SPVG001W();
        public Copies.SPVG009W SPVG009W { get; set; } = new Copies.SPVG009W();
        public Dclgens.MOVFEDCA MOVFEDCA { get; set; } = new Dclgens.MOVFEDCA();
        public Dclgens.TITFEDCA TITFEDCA { get; set; } = new Dclgens.TITFEDCA();
        public Dclgens.PARAMPRO PARAMPRO { get; set; } = new Dclgens.PARAMPRO();
        public Dclgens.MOVDEBCE MOVDEBCE { get; set; } = new Dclgens.MOVDEBCE();
        public Dclgens.APOLCOBR APOLCOBR { get; set; } = new Dclgens.APOLCOBR();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.PROFIDCO PROFIDCO { get; set; } = new Dclgens.PROFIDCO();
        public Dclgens.RAMOCOMP RAMOCOMP { get; set; } = new Dclgens.RAMOCOMP();
        public Dclgens.PARAMGER PARAMGER { get; set; } = new Dclgens.PARAMGER();
        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();
        public Dclgens.GE637 GE637 { get; set; } = new Dclgens.GE637();
        public Dclgens.VG078 VG078 { get; set; } = new Dclgens.VG078();
        public Dclgens.BILHETE BILHETE { get; set; } = new Dclgens.BILHETE();
        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public BI8005B_CCBO CCBO { get; set; } = new BI8005B_CCBO();
        public BI8005B_V0BILHETE V0BILHETE { get; set; } = new BI8005B_V0BILHETE();
        public BI8005B_V1COSSEGPROD V1COSSEGPROD { get; set; } = new BI8005B_V1COSSEGPROD();
        public BI8005B_V1RCAPCOMP V1RCAPCOMP { get; set; } = new BI8005B_V1RCAPCOMP();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -1450- DISPLAY '--------------------------------' */
            _.Display($"--------------------------------");

            /*" -1451- DISPLAY 'PROGRAMA EM EXECUCAO BI8005B    ' */
            _.Display($"PROGRAMA EM EXECUCAO BI8005B    ");

            /*" -1452- DISPLAY '                                ' */
            _.Display($"                                ");

            /*" -1453- DISPLAY 'VERSAO V.31 507.447 - 23/10/2023' */
            _.Display($"VERSAO V.31 507.447 - 23/10/2023");

            /*" -1454- DISPLAY '                                ' */
            _.Display($"                                ");

            /*" -1455- DISPLAY '--------------------------------' . */
            _.Display($"--------------------------------");

            /*" -1461- DISPLAY 'COMPILACAO ' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) ' as ' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) */

            $"COMPILACAO FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)} as FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}"
            .Display();

            /*" -1463- DISPLAY '-------------------------------' . */
            _.Display($"-------------------------------");

            /*" -1464- MOVE 'BI8005B' TO LK-GEJVW002-NOM-PROG-ORIGEM */
            _.Move("BI8005B", GEJVW002.LK_GEJVW002_NOM_PROG_ORIGEM);

            /*" -1465- MOVE 'BATCH' TO LK-GEJVW002-COD-USUARIO-ORIGEM */
            _.Move("BATCH", GEJVW002.LK_GEJVW002_COD_USUARIO_ORIGEM);

            /*" -1465- MOVE 'GEJVS002' TO WS-JV1-PROGRAMA. */
            _.Move("GEJVS002", WS_JV1_PROGRAMA);

            /*" -1466- CALL WS-JV1-PROGRAMA USING LK-GEJVW002-NOM-PROG-ORIGEM LK-GEJVW002-COD-USUARIO-ORIGEM LK-GEJVW002-SIAS-NUM-EMP LK-GEJVW002-SIAS-DTA-INI LK-GEJVW002-SIAS-COD-LIDER LK-GEJVW002-SIAS-COD-CGCCPF LK-GEJVW002-SIAS-COD-EMP-CAP LK-GEJVW002-PREV-NUM-EMP LK-GEJVW002-PREV-DTA-INI LK-GEJVW002-PREV-COD-LIDER LK-GEJVW002-PREV-COD-CGCCPF LK-GEJVW002-PREV-COD-EMP-CAP LK-GEJVW002-JV-NUM-EMP LK-GEJVW002-JV-DTA-INI LK-GEJVW002-JV-COD-LIDER LK-GEJVW002-JV-COD-CGCCPF LK-GEJVW002-JV-COD-EMP-CAP LK-GEJVWCNT-IND-ERRO LK-GEJVWCNT-MENSAGEM-RETORNO LK-GEJVWCNT-NOME-TABELA LK-GEJVWCNT-SQLCODE LK-GEJVWCNT-SQLERRMC. */
            _.Call(WS_JV1_PROGRAMA, GEJVW002, GEJVWCNT);

            /*" -1467- IF LK-GEJVWCNT-IND-ERRO NOT = 0 */

            if (GEJVWCNT.LK_GEJVWCNT_IND_ERRO != 0)
            {

                /*" -1468- DISPLAY 'IND ERRO    = ' LK-GEJVWCNT-IND-ERRO */
                _.Display($"IND ERRO    = {GEJVWCNT.LK_GEJVWCNT_IND_ERRO}");

                /*" -1469- DISPLAY 'MENSAGEM    = ' LK-GEJVWCNT-MENSAGEM-RETORNO */
                _.Display($"MENSAGEM    = {GEJVWCNT.LK_GEJVWCNT_MENSAGEM_RETORNO}");

                /*" -1470- DISPLAY 'TABELA      = ' LK-GEJVWCNT-NOME-TABELA */
                _.Display($"TABELA      = {GEJVWCNT.LK_GEJVWCNT_NOME_TABELA}");

                /*" -1471- DISPLAY 'SQLCODE     = ' LK-GEJVWCNT-SQLCODE */
                _.Display($"SQLCODE     = {GEJVWCNT.LK_GEJVWCNT_SQLCODE}");

                /*" -1472- MOVE LK-GEJVWCNT-SQLCODE TO WSQLCODE */
                _.Move(GEJVWCNT.LK_GEJVWCNT_SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

                /*" -1473- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1476- END-IF */
            }


            /*" -1479- PERFORM R0050-00-INICIO. */

            R0050_00_INICIO_SECTION();

            /*" -1480- ACCEPT WS-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WS_TIME);

            /*" -1481- DISPLAY 'INICIO DO DECLARE ...... ' WS-TIME. */
            _.Display($"INICIO DO DECLARE ...... {WS_TIME}");

            /*" -1483- MOVE SPACES TO WFIM-V0BILHETE. */
            _.Move("", AREA_DE_WORK.WFIM_V0BILHETE);

            /*" -1485- PERFORM R0200-00-DECLARE-V0BILHETE. */

            R0200_00_DECLARE_V0BILHETE_SECTION();

            /*" -1486- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_TIME);

            /*" -1488- DISPLAY 'FIM DO DECLARE ......... ' WS-TIME. */
            _.Display($"FIM DO DECLARE ......... {WS_TIME}");

            /*" -1490- PERFORM R0210-00-FETCH-V0BILHETE. */

            R0210_00_FETCH_V0BILHETE_SECTION();

            /*" -1491- IF WFIM-V0BILHETE NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V0BILHETE.IsEmpty())
            {

                /*" -1493- DISPLAY 'BI8005B - NAO FOI SELECIONADO BILHETE P/ EMISSAO...' */
                _.Display($"BI8005B - NAO FOI SELECIONADO BILHETE P/ EMISSAO...");

                /*" -1495- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -1498- PERFORM R0250-00-PROCESSA-REGISTRO UNTIL WFIM-V0BILHETE NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V0BILHETE.IsEmpty()))
            {

                R0250_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -1500- PERFORM R4000-00-TOTAIS-CONTROLE. */

            R4000_00_TOTAIS_CONTROLE_SECTION();

            /*" -1500- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -1506- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -1507- DISPLAY ' ' */
            _.Display($" ");

            /*" -1509- DISPLAY '*------------  BI8005B - FIM NORMAL  -----------*' */
            _.Display($"*------------  BI8005B - FIM NORMAL  -----------*");

            /*" -1509- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0050-00-INICIO-SECTION */
        private void R0050_00_INICIO_SECTION()
        {
            /*" -1518- MOVE '0050' TO WNR-EXEC-SQL. */
            _.Move("0050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1520- PERFORM R0100-00-SELECT-SISTEMAS. */

            R0100_00_SELECT_SISTEMAS_SECTION();

            /*" -1522- INITIALIZE TAB-CBO1. */
            _.Initialize(
                TAB_CBO1
            );

            /*" -1523- MOVE SPACES TO WFIM-CBO. */
            _.Move("", AREA_DE_WORK.WFIM_CBO);

            /*" -1525- PERFORM R0110-00-DECLARE-CBO. */

            R0110_00_DECLARE_CBO_SECTION();

            /*" -1527- PERFORM R0120-00-FETCH-CBO. */

            R0120_00_FETCH_CBO_SECTION();

            /*" -1528- IF WFIM-CBO NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_CBO.IsEmpty())
            {

                /*" -1529- DISPLAY 'R0120 - PROBLEMA NO FETCH DA CBO         ' */
                _.Display($"R0120 - PROBLEMA NO FETCH DA CBO         ");

                /*" -1532- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1536- PERFORM R0130-00-CARREGA-CBO UNTIL WFIM-CBO EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_CBO == "S"))
            {

                R0130_00_CARREGA_CBO_SECTION();
            }

            /*" -1536- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1542- INITIALIZE LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
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

            /*" -1542- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-SECTION */
        private void R0100_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -1555- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1562- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -1565- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1566- DISPLAY 'ERRO SELECT V1SISTEMA EM' */
                _.Display($"ERRO SELECT V1SISTEMA EM");

                /*" -1569- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1576- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_2 */

            R0100_00_SELECT_SISTEMAS_DB_SELECT_2();

            /*" -1579- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1580- DISPLAY 'ERRO SELECT V1SISTEMA BI' */
                _.Display($"ERRO SELECT V1SISTEMA BI");

                /*" -1582- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1585- MOVE 0,50 TO WS-VLDIFE. */
            _.Move(0.50, AREA_DE_WORK.WS_VLDIFE);

            /*" -1586- DISPLAY 'DATA SISTEMA "EM": ' V1SIST-DTMOVABE. */

            $"DATA SISTEMA EM: {V1SIST_DTMOVABE}"
            .Display();

            /*" -1586- DISPLAY 'DATA SISTEMA "BI": ' V1SIST-DTMOVACB. */

            $"DATA SISTEMA {BILHETE.DCLBILHETE.BILHETE_RAMO}: {V1SIST_DTMOVACB}"
            .Display();

        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -1562- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :V1SIST-DTMOVABE, :V1SIST-DTCURRENT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'EM' FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
                _.Move(executed_1.V1SIST_DTCURRENT, V1SIST_DTCURRENT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-2 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_2()
        {
            /*" -1576- EXEC SQL SELECT DTMOVABE,CURRENT TIMESTAMP INTO :V1SIST-DTMOVACB, :V1SIST-TIMESTAMP FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'BI' FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1 = new R0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1.Execute(r0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVACB, V1SIST_DTMOVACB);
                _.Move(executed_1.V1SIST_TIMESTAMP, V1SIST_TIMESTAMP);
            }


        }

        [StopWatch]
        /*" R0110-00-DECLARE-CBO-SECTION */
        private void R0110_00_DECLARE_CBO_SECTION()
        {
            /*" -1598- MOVE '0110' TO WNR-EXEC-SQL. */
            _.Move("0110", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1604- PERFORM R0110_00_DECLARE_CBO_DB_DECLARE_1 */

            R0110_00_DECLARE_CBO_DB_DECLARE_1();

            /*" -1606- PERFORM R0110_00_DECLARE_CBO_DB_OPEN_1 */

            R0110_00_DECLARE_CBO_DB_OPEN_1();

            /*" -1609- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1610- DISPLAY 'R0110 - PROBLEMAS DECLARE (CBO      ) ..' */
                _.Display($"R0110 - PROBLEMAS DECLARE (CBO      ) ..");

                /*" -1611- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -1611- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0110-00-DECLARE-CBO-DB-DECLARE-1 */
        public void R0110_00_DECLARE_CBO_DB_DECLARE_1()
        {
            /*" -1604- EXEC SQL DECLARE CCBO CURSOR FOR SELECT COD_CBO, DESCR_CBO FROM SEGUROS.CBO WHERE COD_CBO BETWEEN 001 AND 999 ORDER BY COD_CBO END-EXEC. */
            CCBO = new BI8005B_CCBO(false);
            string GetQuery_CCBO()
            {
                var query = @$"SELECT COD_CBO
							, 
							DESCR_CBO 
							FROM SEGUROS.CBO 
							WHERE COD_CBO BETWEEN 001 AND 999 
							ORDER BY COD_CBO";

                return query;
            }
            CCBO.GetQueryEvent += GetQuery_CCBO;

        }

        [StopWatch]
        /*" R0110-00-DECLARE-CBO-DB-OPEN-1 */
        public void R0110_00_DECLARE_CBO_DB_OPEN_1()
        {
            /*" -1606- EXEC SQL OPEN CCBO END-EXEC. */

            CCBO.Open();

        }

        [StopWatch]
        /*" R0200-00-DECLARE-V0BILHETE-DB-DECLARE-1 */
        public void R0200_00_DECLARE_V0BILHETE_DB_DECLARE_1()
        {
            /*" -1690- EXEC SQL DECLARE V0BILHETE CURSOR WITH HOLD FOR SELECT NUMBIL , NUM_APOLICE , FONTE , AGECOBR , NUM_MATRICULA , COD_AGENCIA , CODCLIEN , PROFISSAO , COD_AGENCIA_DEB , OPERACAO_CONTA_DEB, NUM_CONTA_DEB , DIG_CONTA_DEB , OPC_COBERTURA , DTQITBCO , DTQITBCO + 1 MONTH, VLRCAP , RAMO , COD_USUARIO , SITUACAO , NUM_APOL_ANTERIOR FROM SEGUROS.V0BILHETE WHERE SITUACAO IN ( 'D' , 'E' ) AND NUM_APOL_ANTERIOR = 0 AND RAMO IN (81, 37, 69) AND TIMESTAMP < :V1SIST-TIMESTAMP END-EXEC. */
            V0BILHETE = new BI8005B_V0BILHETE(true);
            string GetQuery_V0BILHETE()
            {
                var query = @$"SELECT NUMBIL
							, 
							NUM_APOLICE
							, 
							FONTE
							, 
							AGECOBR
							, 
							NUM_MATRICULA
							, 
							COD_AGENCIA
							, 
							CODCLIEN
							, 
							PROFISSAO
							, 
							COD_AGENCIA_DEB
							, 
							OPERACAO_CONTA_DEB
							, 
							NUM_CONTA_DEB
							, 
							DIG_CONTA_DEB
							, 
							OPC_COBERTURA
							, 
							DTQITBCO
							, 
							DTQITBCO + 1 MONTH
							, 
							VLRCAP
							, 
							RAMO
							, 
							COD_USUARIO
							, 
							SITUACAO
							, 
							NUM_APOL_ANTERIOR 
							FROM SEGUROS.V0BILHETE 
							WHERE SITUACAO IN ( 'D'
							, 'E' ) 
							AND NUM_APOL_ANTERIOR = 0 
							AND RAMO IN (81
							, 37
							, 69) 
							AND TIMESTAMP < '{V1SIST_TIMESTAMP}'";

                return query;
            }
            V0BILHETE.GetQueryEvent += GetQuery_V0BILHETE;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0110_99_SAIDA*/

        [StopWatch]
        /*" R0120-00-FETCH-CBO-SECTION */
        private void R0120_00_FETCH_CBO_SECTION()
        {
            /*" -1621- MOVE '0120' TO WNR-EXEC-SQL. */
            _.Move("0120", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1624- PERFORM R0120_00_FETCH_CBO_DB_FETCH_1 */

            R0120_00_FETCH_CBO_DB_FETCH_1();

            /*" -1627- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1628- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1629- MOVE 'S' TO WFIM-CBO */
                    _.Move("S", AREA_DE_WORK.WFIM_CBO);

                    /*" -1629- PERFORM R0120_00_FETCH_CBO_DB_CLOSE_1 */

                    R0120_00_FETCH_CBO_DB_CLOSE_1();

                    /*" -1631- ELSE */
                }
                else
                {


                    /*" -1631- PERFORM R0120_00_FETCH_CBO_DB_CLOSE_2 */

                    R0120_00_FETCH_CBO_DB_CLOSE_2();

                    /*" -1633- DISPLAY '0120 - (PROBLEMAS NO FETCH CCBO     ) ..' */
                    _.Display($"0120 - (PROBLEMAS NO FETCH CCBO     ) ..");

                    /*" -1634- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -1634- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0120-00-FETCH-CBO-DB-FETCH-1 */
        public void R0120_00_FETCH_CBO_DB_FETCH_1()
        {
            /*" -1624- EXEC SQL FETCH CCBO INTO :CBO-COD-CBO, :CBO-DESCR-CBO END-EXEC. */

            if (CCBO.Fetch())
            {
                _.Move(CCBO.CBO_COD_CBO, CBO_COD_CBO);
                _.Move(CCBO.CBO_DESCR_CBO, CBO_DESCR_CBO);
            }

        }

        [StopWatch]
        /*" R0120-00-FETCH-CBO-DB-CLOSE-1 */
        public void R0120_00_FETCH_CBO_DB_CLOSE_1()
        {
            /*" -1629- EXEC SQL CLOSE CCBO END-EXEC */

            CCBO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0120_99_SAIDA*/

        [StopWatch]
        /*" R0120-00-FETCH-CBO-DB-CLOSE-2 */
        public void R0120_00_FETCH_CBO_DB_CLOSE_2()
        {
            /*" -1631- EXEC SQL CLOSE CCBO END-EXEC */

            CCBO.Close();

        }

        [StopWatch]
        /*" R0130-00-CARREGA-CBO-SECTION */
        private void R0130_00_CARREGA_CBO_SECTION()
        {
            /*" -1645- MOVE '0130' TO WNR-EXEC-SQL. */
            _.Move("0130", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1648- MOVE CBO-DESCR-CBO TO TAB-DESCR-CBO-C (CBO-COD-CBO) */
            _.Move(CBO_DESCR_CBO, TAB_CBO1.TAB_CBO.FILLER_0[CBO_COD_CBO].TAB_DESCR_CBO_C);

            /*" -1648- PERFORM R0120-00-FETCH-CBO. */

            R0120_00_FETCH_CBO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0130_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-DECLARE-V0BILHETE-SECTION */
        private void R0200_00_DECLARE_V0BILHETE_SECTION()
        {
            /*" -1660- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1690- PERFORM R0200_00_DECLARE_V0BILHETE_DB_DECLARE_1 */

            R0200_00_DECLARE_V0BILHETE_DB_DECLARE_1();

            /*" -1692- PERFORM R0200_00_DECLARE_V0BILHETE_DB_OPEN_1 */

            R0200_00_DECLARE_V0BILHETE_DB_OPEN_1();

            /*" -1695- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1696- DISPLAY 'R0200-PROBLEMAS NO OPEN (V0BILHETE) ... ' */
                _.Display($"R0200-PROBLEMAS NO OPEN (V0BILHETE) ... ");

                /*" -1696- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0200-00-DECLARE-V0BILHETE-DB-OPEN-1 */
        public void R0200_00_DECLARE_V0BILHETE_DB_OPEN_1()
        {
            /*" -1692- EXEC SQL OPEN V0BILHETE END-EXEC. */

            V0BILHETE.Open();

        }

        [StopWatch]
        /*" R1080-00-GRAVA-V0APOLCOSCED-DB-DECLARE-1 */
        public void R1080_00_GRAVA_V0APOLCOSCED_DB_DECLARE_1()
        {
            /*" -4204- EXEC SQL DECLARE V1COSSEGPROD CURSOR FOR SELECT CODPRODU , RAMO , CONGENER , PCPARTIC , PCCOMCOS , PCADMCOS , DTINIVIG , DTTERVIG , SITUACAO FROM SEGUROS.V1COSSEGPROD WHERE CODPRODU = :V1BILP-CODPRODU AND RAMO = :WWORK-RAMO-ANT AND DTINIVIG <= :V0ENDO-DTINIVIG AND DTTERVIG >= :V0ENDO-DTINIVIG AND SUBPRODU = :WWORK-OPCAO-ANT END-EXEC. */
            V1COSSEGPROD = new BI8005B_V1COSSEGPROD(true);
            string GetQuery_V1COSSEGPROD()
            {
                var query = @$"SELECT CODPRODU
							, 
							RAMO
							, 
							CONGENER
							, 
							PCPARTIC
							, 
							PCCOMCOS
							, 
							PCADMCOS
							, 
							DTINIVIG
							, 
							DTTERVIG
							, 
							SITUACAO 
							FROM SEGUROS.V1COSSEGPROD 
							WHERE CODPRODU = '{V1BILP_CODPRODU}' 
							AND RAMO = '{WWORK_RAMO_ANT}' 
							AND DTINIVIG <= '{V0ENDO_DTINIVIG}' 
							AND DTTERVIG >= '{V0ENDO_DTINIVIG}' 
							AND SUBPRODU = '{WWORK_OPCAO_ANT}'";

                return query;
            }
            V1COSSEGPROD.GetQueryEvent += GetQuery_V1COSSEGPROD;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-FETCH-V0BILHETE-SECTION */
        private void R0210_00_FETCH_V0BILHETE_SECTION()
        {
            /*" -1708- MOVE '0210' TO WNR-EXEC-SQL. */
            _.Move("0210", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1729- PERFORM R0210_00_FETCH_V0BILHETE_DB_FETCH_1 */

            R0210_00_FETCH_V0BILHETE_DB_FETCH_1();

            /*" -1732- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1733- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1733- PERFORM R0210_00_FETCH_V0BILHETE_DB_CLOSE_1 */

                    R0210_00_FETCH_V0BILHETE_DB_CLOSE_1();

                    /*" -1735- MOVE 'S' TO WFIM-V0BILHETE */
                    _.Move("S", AREA_DE_WORK.WFIM_V0BILHETE);

                    /*" -1736- GO TO R0210-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/ //GOTO
                    return;

                    /*" -1737- ELSE */
                }
                else
                {


                    /*" -1738- DISPLAY 'R0210-00 (ERRO -  FETCH V0BILHETE)...' */
                    _.Display($"R0210-00 (ERRO -  FETCH V0BILHETE)...");

                    /*" -1740- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1745- ADD 1 TO WACC-LIDOS WACC-DISPLAY LD-BILHETE WACC-PROCESSADOS. */
            AREA_DE_WORK.WACC_LIDOS.Value = AREA_DE_WORK.WACC_LIDOS + 1;
            AREA_DE_WORK.WACC_DISPLAY.Value = AREA_DE_WORK.WACC_DISPLAY + 1;
            AREA_DE_WORK.LD_BILHETE.Value = AREA_DE_WORK.LD_BILHETE + 1;
            AREA_DE_WORK.WACC_PROCESSADOS.Value = AREA_DE_WORK.WACC_PROCESSADOS + 1;

            /*" -1746- INITIALIZE WORK-TAB-ERROS-CERT */
            _.Initialize(
                WORK_TAB_ERROS_CERT
            );

            /*" -1747- MOVE ZEROS TO WS-I-ERRO */
            _.Move(0, WS_I_ERRO);

            /*" -1748- . */

            /*" -1749- MOVE LD-BILHETE TO AC-LIDOS. */
            _.Move(AREA_DE_WORK.LD_BILHETE, AREA_DE_WORK.AC_LIDOS);

            /*" -1757- IF LD-PARTE2 EQUAL ZEROS OR 0001 OR 0010 OR 0050 OR 0100 OR 0500 OR 1000 OR 5000 */

            if (AREA_DE_WORK.FILLER_1.LD_PARTE2.In("00", "0001", "0010", "0050", "0100", "0500", "1000", "5000"))
            {

                /*" -1758- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), WS_TIME);

                /*" -1759- DISPLAY 'LIDOS BILHETES ... ' LD-BILHETE '  ' WS-TIME. */

                $"LIDOS BILHETES ... {AREA_DE_WORK.LD_BILHETE}  {WS_TIME}"
                .Display();
            }


        }

        [StopWatch]
        /*" R0210-00-FETCH-V0BILHETE-DB-FETCH-1 */
        public void R0210_00_FETCH_V0BILHETE_DB_FETCH_1()
        {
            /*" -1729- EXEC SQL FETCH V0BILHETE INTO :V0BILH-NUMBIL , :V0BILH-NUMAPOL , :V0BILH-FONTE , :V0BILH-AGECOBR , :V0BILH-NUM-MATR , :V0BILH-AGENCIA , :V0BILH-CODCLIEN , :V0BILH-PROFISSAO , :V0BILH-AGENCIA-DEB , :V0BILH-OPERACAO-DEB , :V0BILH-NUMCTA-DEB , :V0BILH-DIGCTA-DEB , :V0BILH-OPCAO-COBER , :V0BILH-DTQITBCO , :V0BILH-DTVENCTO , :V0BILH-VLRCAP , :V0BILH-RAMO , :V0BILH-CODUSU , :V0BILH-SITUACAO , :V0BILH-NUM-APO-ANT END-EXEC. */

            if (V0BILHETE.Fetch())
            {
                _.Move(V0BILHETE.V0BILH_NUMBIL, V0BILH_NUMBIL);
                _.Move(V0BILHETE.V0BILH_NUMAPOL, V0BILH_NUMAPOL);
                _.Move(V0BILHETE.V0BILH_FONTE, V0BILH_FONTE);
                _.Move(V0BILHETE.V0BILH_AGECOBR, V0BILH_AGECOBR);
                _.Move(V0BILHETE.V0BILH_NUM_MATR, V0BILH_NUM_MATR);
                _.Move(V0BILHETE.V0BILH_AGENCIA, V0BILH_AGENCIA);
                _.Move(V0BILHETE.V0BILH_CODCLIEN, V0BILH_CODCLIEN);
                _.Move(V0BILHETE.V0BILH_PROFISSAO, V0BILH_PROFISSAO);
                _.Move(V0BILHETE.V0BILH_AGENCIA_DEB, V0BILH_AGENCIA_DEB);
                _.Move(V0BILHETE.V0BILH_OPERACAO_DEB, V0BILH_OPERACAO_DEB);
                _.Move(V0BILHETE.V0BILH_NUMCTA_DEB, V0BILH_NUMCTA_DEB);
                _.Move(V0BILHETE.V0BILH_DIGCTA_DEB, V0BILH_DIGCtA_DEB);
                _.Move(V0BILHETE.V0BILH_OPCAO_COBER, V0BILH_OPCAO_COBER);
                _.Move(V0BILHETE.V0BILH_DTQITBCO, V0BILH_DTQITBCO);
                _.Move(V0BILHETE.V0BILH_DTVENCTO, V0BILH_DTVENCTO);
                _.Move(V0BILHETE.V0BILH_VLRCAP, V0BILH_VLRCAP);
                _.Move(V0BILHETE.V0BILH_RAMO, V0BILH_RAMO);
                _.Move(V0BILHETE.V0BILH_CODUSU, V0BILH_CODUSU);
                _.Move(V0BILHETE.V0BILH_SITUACAO, V0BILH_SITUACAO);
                _.Move(V0BILHETE.V0BILH_NUM_APO_ANT, V0BILH_NUM_APO_ANT);
            }

        }

        [StopWatch]
        /*" R0210-00-FETCH-V0BILHETE-DB-CLOSE-1 */
        public void R0210_00_FETCH_V0BILHETE_DB_CLOSE_1()
        {
            /*" -1733- EXEC SQL CLOSE V0BILHETE END-EXEC */

            V0BILHETE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/

        [StopWatch]
        /*" R0250-00-PROCESSA-REGISTRO-SECTION */
        private void R0250_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -1772- MOVE '0250' TO WNR-EXEC-SQL. */
            _.Move("0250", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1773- MOVE 'S' TO WS-SIVPF. */
            _.Move("S", AREA_DE_WORK.WS_SIVPF);

            /*" -1775- PERFORM R0260-00-SELECT-PROPOFID. */

            R0260_00_SELECT_PROPOFID_SECTION();

            /*" -1776- IF V0BILH-RAMO EQUAL 69 */

            if (V0BILH_RAMO == 69)
            {

                /*" -1777- IF WS-SIVPF EQUAL 'S' */

                if (AREA_DE_WORK.WS_SIVPF == "S")
                {

                    /*" -1779- PERFORM R0270-00-SELECT-PRPFIDCO. */

                    R0270_00_SELECT_PRPFIDCO_SECTION();
                }

            }


            /*" -1780- IF WS-SIVPF EQUAL 'N' */

            if (AREA_DE_WORK.WS_SIVPF == "N")
            {

                /*" -1782- PERFORM R0280-00-SELECT-CONVERSI. */

                R0280_00_SELECT_CONVERSI_SECTION();
            }


            /*" -1784- PERFORM R0290-00-SELECT-BILPLCOBER. */

            R0290_00_SELECT_BILPLCOBER_SECTION();

            /*" -1786- PERFORM R3060-00-VERIFICA-CRTCA-PEND */

            R3060_00_VERIFICA_CRTCA_PEND_SECTION();

            /*" -1787- IF WS-ERRO-COUNT > ZEROS */

            if (WS_ERRO_COUNT > 00)
            {

                /*" -1788- MOVE '1' TO V0BILH-SITUACAO */
                _.Move("1", V0BILH_SITUACAO);

                /*" -1789- PERFORM R3020-00-UPDATE-V0BILHETE */

                R3020_00_UPDATE_V0BILHETE_SECTION();

                /*" -1792- DISPLAY 'BILHETE POSSUI CRITICA PENDENTE CADASTRADA.' ' ' V0BILH-NUMBIL ' ' V0BILH-CODCLIEN ' ' WS-ERRO-COUNT */

                $"BILHETE POSSUI CRITICA PENDENTE CADASTRADA. {V0BILH_NUMBIL} {V0BILH_CODCLIEN} {WS_ERRO_COUNT}"
                .Display();

                /*" -1793- GO TO R0250-00-LEITURA */

                R0250_00_LEITURA(); //GOTO
                return;

                /*" -1795- END-IF */
            }


            /*" -1796- IF V1BILP-CODPRODU EQUAL ZEROS */

            if (V1BILP_CODPRODU == 00)
            {

                /*" -1797- ADD 1 TO DP-PLCOBER */
                AREA_DE_WORK.DP_PLCOBER.Value = AREA_DE_WORK.DP_PLCOBER + 1;

                /*" -1805- GO TO R0250-00-LEITURA. */

                R0250_00_LEITURA(); //GOTO
                return;
            }


            /*" -1807- PERFORM R0300-00-VER-LIMITE-RISCO. */

            R0300_00_VER_LIMITE_RISCO_SECTION();

            /*" -1808- IF V0BILER-COD-ERRO NOT EQUAL ZEROS */

            if (V0BILER_COD_ERRO != 00)
            {

                /*" -1809- ADD 1 TO DP-RISCO */
                AREA_DE_WORK.DP_RISCO.Value = AREA_DE_WORK.DP_RISCO + 1;

                /*" -1815- GO TO R0250-00-LEITURA. */

                R0250_00_LEITURA(); //GOTO
                return;
            }


            /*" -1818- PERFORM R0350-00-VER-VIGENCIA. */

            R0350_00_VER_VIGENCIA_SECTION();

            /*" -1819- IF V0BILH-NUM-APO-ANT GREATER 0 */

            if (V0BILH_NUM_APO_ANT > 0)
            {

                /*" -1820- PERFORM R0370-00-SELECT-APOLICE-ANT */

                R0370_00_SELECT_APOLICE_ANT_SECTION();

                /*" -1821- MOVE V1APOL-NUM-APOL TO V0APOL-NUM-APO-ANT */
                _.Move(V1APOL_NUM_APOL, V0APOL_NUM_APO_ANT);

                /*" -1822- MOVE V1COD-ORGAO TO V0APOL-ORGAO */
                _.Move(V1COD_ORGAO, V0APOL_ORGAO);

                /*" -1823- ELSE */
            }
            else
            {


                /*" -1824- MOVE 0 TO V0APOL-NUM-APO-ANT */
                _.Move(0, V0APOL_NUM_APO_ANT);

                /*" -1825- IF V0BILH-DTQITBCO > LK-GEJVW002-JV-DTA-INI */

                if (V0BILH_DTQITBCO > GEJVW002.LK_GEJVW002_JV_DTA_INI)
                {

                    /*" -1826- MOVE 300 TO V0APOL-ORGAO */
                    _.Move(300, V0APOL_ORGAO);

                    /*" -1827- ELSE */
                }
                else
                {


                    /*" -1828- MOVE 10 TO V0APOL-ORGAO */
                    _.Move(10, V0APOL_ORGAO);

                    /*" -1829- END-IF */
                }


                /*" -1830- END-IF. */
            }


            /*" -1833- MOVE V0APOL-ORGAO TO WWORK-ORG-APOL. */
            _.Move(V0APOL_ORGAO, AREA_DE_WORK.FILLER_2.WWORK_ORG_APOL);

            /*" -1835- PERFORM R0380-00-SELECT-BILCOBER. */

            R0380_00_SELECT_BILCOBER_SECTION();

            /*" -1836- IF V0BILER-COD-ERRO NOT EQUAL ZEROS */

            if (V0BILER_COD_ERRO != 00)
            {

                /*" -1837- ADD 1 TO DP-BILCOBE */
                AREA_DE_WORK.DP_BILCOBE.Value = AREA_DE_WORK.DP_BILCOBE + 1;

                /*" -1840- GO TO R0250-00-LEITURA. */

                R0250_00_LEITURA(); //GOTO
                return;
            }


            /*" -1842- PERFORM R0400-00-SELECT-RCAPS. */

            R0400_00_SELECT_RCAPS_SECTION();

            /*" -1843- IF WFIM-V1RCAP EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_V1RCAP == "S")
            {

                /*" -1844- ADD 1 TO DP-RCAPS */
                AREA_DE_WORK.DP_RCAPS.Value = AREA_DE_WORK.DP_RCAPS + 1;

                /*" -1847- GO TO R0250-00-LEITURA. */

                R0250_00_LEITURA(); //GOTO
                return;
            }


            /*" -1848- IF V0BILH-NUMAPOL NOT EQUAL ZEROS */

            if (V0BILH_NUMAPOL != 00)
            {

                /*" -1849- ADD 1 TO DP-APOLICE */
                AREA_DE_WORK.DP_APOLICE.Value = AREA_DE_WORK.DP_APOLICE + 1;

                /*" -1850- DISPLAY 'APOLICE BILHETE DIFERENTE DE ZEROS         ' */
                _.Display($"APOLICE BILHETE DIFERENTE DE ZEROS         ");

                /*" -1853- GO TO R0250-00-LEITURA. */

                R0250_00_LEITURA(); //GOTO
                return;
            }


            /*" -1855- PERFORM R0420-00-ACUMULA-BILHETE. */

            R0420_00_ACUMULA_BILHETE_SECTION();

            /*" -1856- IF V0BILER-COD-ERRO NOT EQUAL ZEROS */

            if (V0BILER_COD_ERRO != 00)
            {

                /*" -1857- ADD 1 TO DP-ACUMULA */
                AREA_DE_WORK.DP_ACUMULA.Value = AREA_DE_WORK.DP_ACUMULA + 1;

                /*" -1860- GO TO R0250-00-LEITURA. */

                R0250_00_LEITURA(); //GOTO
                return;
            }


            /*" -1862- PERFORM R3000-00-LIBERA-BILHETE. */

            R3000_00_LIBERA_BILHETE_SECTION();

            /*" -1863- IF WWORK-NUM-ITENS EQUAL ZEROS */

            if (AREA_DE_WORK.WWORK_NUM_ITENS == 00)
            {

                /*" -1864- ADD 1 TO DP-ITENS */
                AREA_DE_WORK.DP_ITENS.Value = AREA_DE_WORK.DP_ITENS + 1;

                /*" -1867- GO TO R0250-00-LEITURA. */

                R0250_00_LEITURA(); //GOTO
                return;
            }


            /*" -1870- PERFORM R0500-00-TRATA-APOLICE. */

            R0500_00_TRATA_APOLICE_SECTION();

            /*" -1871- IF PRPFIDEL-PERIPGTO EQUAL 1 */

            if (PRPFIDEL_PERIPGTO == 1)
            {

                /*" -1872- PERFORM R0520-00-MONTA-ENDOSSO-ZERO */

                R0520_00_MONTA_ENDOSSO_ZERO_SECTION();

                /*" -1873- PERFORM R0600-00-MONTA-ENDOSSO01 */

                R0600_00_MONTA_ENDOSSO01_SECTION();

                /*" -1874- ELSE */
            }
            else
            {


                /*" -1877- PERFORM R0700-00-MONTA-ENDOSSO-UNICO. */

                R0700_00_MONTA_ENDOSSO_UNICO_SECTION();
            }


            /*" -1879- PERFORM R3200-00-BAIXA-RCAP. */

            R3200_00_BAIXA_RCAP_SECTION();

            /*" -1881- PERFORM R3210-00-ALTERA-RCAPS. */

            R3210_00_ALTERA_RCAPS_SECTION();

            /*" -1890- PERFORM R0250_00_PROCESSA_REGISTRO_DB_SELECT_1 */

            R0250_00_PROCESSA_REGISTRO_DB_SELECT_1();

            /*" -1893- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1894- DISPLAY 'R0250-00 (ERRO - SELECT PARAMETROS_GERAIS)' */
                _.Display($"R0250-00 (ERRO - SELECT PARAMETROS_GERAIS)");

                /*" -1896- DISPLAY 'BILHETE: ' V0BILH-NUMBIL '  ' 'RAMO   : ' V0BILH-RAMO '  ' */

                $"BILHETE: {V0BILH_NUMBIL}  RAMO   : {V0BILH_RAMO}  "
                .Display();

                /*" -1898- DISPLAY 'PROPFID: ' V0CONV-NUM-PROPOSTA-SIVPF '  ' 'IDENTIF: ' PRPFIDEL-NUM-IDENTIFICA '  ' */

                $"PROPFID: {V0CONV_NUM_PROPOSTA_SIVPF}  IDENTIF: {PRPFIDEL_NUM_IDENTIFICA}  "
                .Display();

                /*" -1901- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1903- PERFORM R1066-00-TRATA-EVOGEPES016 */

            R1066_00_TRATA_EVOGEPES016_SECTION();

            /*" -1904- IF V1BILC-VALMAX GREATER ZEROS */

            if (V1BILC_VALMAX > 00)
            {

                /*" -1905- PERFORM R4280-00-TRATA-FC0105S */

                R4280_00_TRATA_FC0105S_SECTION();

                /*" -1907- END-IF. */
            }


            /*" -1909- PERFORM R1080-00-GRAVA-V0APOLCOSCED. */

            R1080_00_GRAVA_V0APOLCOSCED_SECTION();

            /*" -1911- IF WACC-PCTCED GREATER ZEROS AND WACC-QTCOSSEG GREATER ZEROS */

            if (AREA_DE_WORK.WACC_PCTCED > 00 && AREA_DE_WORK.WACC_QTCOSSEG > 00)
            {

                /*" -1917- PERFORM R1090-00-UPDATE-V0APOLICE. */

                R1090_00_UPDATE_V0APOLICE_SECTION();
            }


            /*" -1918- IF PRPFIDEL-PERIPGTO = 1 */

            if (PRPFIDEL_PERIPGTO == 1)
            {

                /*" -1919- PERFORM R1155-00-TRATA-MOVDEBCC */

                R1155_00_TRATA_MOVDEBCC_SECTION();

                /*" -1919- PERFORM R1160-00-INSERT-APOLCOBR. */

                R1160_00_INSERT_APOLCOBR_SECTION();
            }


            /*" -0- FLUXCONTROL_PERFORM R0250_00_LEITURA */

            R0250_00_LEITURA();

        }

        [StopWatch]
        /*" R0250-00-PROCESSA-REGISTRO-DB-SELECT-1 */
        public void R0250_00_PROCESSA_REGISTRO_DB_SELECT_1()
        {
            /*" -1890- EXEC SQL SELECT PG.COD_EMPRESA_CAP ,PD.COD_EMPRESA INTO :PARAMGER-COD-EMPRESA-CAP ,:PRODUTO-COD-EMPRESA FROM SEGUROS.PARAMETROS_GERAIS PG, SEGUROS.PRODUTO PD WHERE PG.COD_EMPRESA = PD.COD_EMPRESA AND PD.COD_PRODUTO = :V0ENDO-CODPRODU END-EXEC */

            var r0250_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 = new R0250_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1()
            {
                V0ENDO_CODPRODU = V0ENDO_CODPRODU.ToString(),
            };

            var executed_1 = R0250_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1.Execute(r0250_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARAMGER_COD_EMPRESA_CAP, PARAMGER.DCLPARAMETROS_GERAIS.PARAMGER_COD_EMPRESA_CAP);
                _.Move(executed_1.PRODUTO_COD_EMPRESA, PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA);
            }


        }

        [StopWatch]
        /*" R0250-00-LEITURA */
        private void R0250_00_LEITURA(bool isPerform = false)
        {
            /*" -1925- IF WS-I-ERRO > ZEROS */

            if (WS_I_ERRO > 00)
            {

                /*" -1926- MOVE 'S' TO WS-FLAG-TEM-ERRO */
                _.Move("S", WS_FLAG_TEM_ERRO);

                /*" -1928- MOVE 1 TO WS-I-ERRO */
                _.Move(1, WS_I_ERRO);

                /*" -1930- PERFORM R3050-00-INSERE-ERRO UNTIL WS-FLAG-TEM-ERRO EQUAL 'N' */

                while (!(WS_FLAG_TEM_ERRO == "N"))
                {

                    R3050_00_INSERE_ERRO_SECTION();
                }

                /*" -1932- END-IF */
            }


            /*" -1933- IF WS-SIVPF EQUAL 'S' */

            if (AREA_DE_WORK.WS_SIVPF == "S")
            {

                /*" -1934- IF V0BILH-SITUACAO EQUAL '9' */

                if (V0BILH_SITUACAO == "9")
                {

                    /*" -1935- MOVE 'EMT' TO WHOST-SIT-PROP-SIVPF */
                    _.Move("EMT", WHOST_SIT_PROP_SIVPF);

                    /*" -1936- ELSE */
                }
                else
                {


                    /*" -1937- MOVE 'PEN' TO WHOST-SIT-PROP-SIVPF */
                    _.Move("PEN", WHOST_SIT_PROP_SIVPF);

                    /*" -1939- END-IF */
                }


                /*" -1941- IF V0SIVPF-SIT-PROPOSTA EQUAL WHOST-SIT-PROP-SIVPF NEXT SENTENCE */

                if (V0SIVPF_SIT_PROPOSTA == WHOST_SIT_PROP_SIVPF)
                {

                    /*" -1942- ELSE */
                }
                else
                {


                    /*" -1949- PERFORM R0250_00_LEITURA_DB_UPDATE_1 */

                    R0250_00_LEITURA_DB_UPDATE_1();

                    /*" -1951- IF SQLCODE NOT EQUAL ZEROS AND 100 */

                    if (!DB.SQLCODE.In("00", "100"))
                    {

                        /*" -1953- DISPLAY 'PROBLEMAS NO UPDATE (PROPOSTA_FIDELIZ) ' ' ' V0BILH-NUMBIL */

                        $"PROBLEMAS NO UPDATE (PROPOSTA_FIDELIZ)  {V0BILH_NUMBIL}"
                        .Display();

                        /*" -1956- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -1957- IF V0BILH-RAMO EQUAL 81 OR 82 OR 37 */

            if (V0BILH_RAMO.In("81", "82", "37"))
            {

                /*" -1958- IF V0BILH-SITUACAO EQUAL '9' */

                if (V0BILH_SITUACAO == "9")
                {

                    /*" -1959- ADD 1 TO GELMR-QTD-SEGUROS */
                    GELMR_QTD_SEGUROS.Value = GELMR_QTD_SEGUROS + 1;

                    /*" -1960- IF WTEM-GELMR EQUAL 'SIM' */

                    if (AREA_DE_WORK.WTEM_GELMR == "SIM")
                    {

                        /*" -1961- PERFORM R1400-00-UPDATE-GELIMRISCO */

                        R1400_00_UPDATE_GELIMRISCO_SECTION();

                        /*" -1962- ELSE */
                    }
                    else
                    {


                        /*" -1965- PERFORM R1500-00-INSERT-GELIMRISCO. */

                        R1500_00_INSERT_GELIMRISCO_SECTION();
                    }

                }

            }


            /*" -1965- PERFORM R0210-00-FETCH-V0BILHETE. */

            R0210_00_FETCH_V0BILHETE_SECTION();

        }

        [StopWatch]
        /*" R0250-00-LEITURA-DB-UPDATE-1 */
        public void R0250_00_LEITURA_DB_UPDATE_1()
        {
            /*" -1949- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET SIT_PROPOSTA = :WHOST-SIT-PROP-SIVPF, SITUACAO_ENVIO = 'S' , COD_USUARIO = 'BI8005B' , TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_SICOB = :V0BILH-NUMBIL END-EXEC */

            var r0250_00_LEITURA_DB_UPDATE_1_Update1 = new R0250_00_LEITURA_DB_UPDATE_1_Update1()
            {
                WHOST_SIT_PROP_SIVPF = WHOST_SIT_PROP_SIVPF.ToString(),
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            R0250_00_LEITURA_DB_UPDATE_1_Update1.Execute(r0250_00_LEITURA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_99_SAIDA*/

        [StopWatch]
        /*" R0260-00-SELECT-PROPOFID-SECTION */
        private void R0260_00_SELECT_PROPOFID_SECTION()
        {
            /*" -1978- MOVE '0260' TO WNR-EXEC-SQL. */
            _.Move("0260", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2004- PERFORM R0260_00_SELECT_PROPOFID_DB_SELECT_1 */

            R0260_00_SELECT_PROPOFID_DB_SELECT_1();

            /*" -2007- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2008- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2009- MOVE 'N' TO WS-SIVPF */
                    _.Move("N", AREA_DE_WORK.WS_SIVPF);

                    /*" -2011- MOVE ZEROS TO V0CONV-NUM-PROPOSTA-SIVPF */
                    _.Move(0, V0CONV_NUM_PROPOSTA_SIVPF);

                    /*" -2012- ELSE */
                }
                else
                {


                    /*" -2013- DISPLAY 'R0260-00 (ERRO - SELECT PROPOSTA_FIDELIZ)' */
                    _.Display($"R0260-00 (ERRO - SELECT PROPOSTA_FIDELIZ)");

                    /*" -2015- DISPLAY 'BILHETE: ' V0BILH-NUMBIL '  ' 'RAMO: ' V0BILH-RAMO '  ' */

                    $"BILHETE: {V0BILH_NUMBIL}  RAMO: {V0BILH_RAMO}  "
                    .Display();

                    /*" -2015- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0260-00-SELECT-PROPOFID-DB-SELECT-1 */
        public void R0260_00_SELECT_PROPOFID_DB_SELECT_1()
        {
            /*" -2004- EXEC SQL SELECT NUM_SICOB, SIT_PROPOSTA, NUM_PROPOSTA_SIVPF, COD_PRODUTO_SIVPF, ORIGEM_PROPOSTA , DIGCTAVEN , NUMCTAVEN , OPCAO_COBER , DIA_DEBITO , NUM_IDENTIFICACAO INTO :V0CONV-NUM-SICOB, :V0SIVPF-SIT-PROPOSTA, :V0CONV-NUM-PROPOSTA-SIVPF, :PRPFIDEL-COD-PROD-SIVPF, :PRPFIDEL-ORIG-PROPOSTA, :PRPFIDEL-QTD-MESES , :PRPFIDEL-PERIPGTO , :PRPFIDEL-OPCAO-COBER , :PRPFIDEL-DIA-DEBITO , :PRPFIDEL-NUM-IDENTIFICA FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_SICOB = :V0BILH-NUMBIL AND COD_PRODUTO_SIVPF = 09 FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC */

            var r0260_00_SELECT_PROPOFID_DB_SELECT_1_Query1 = new R0260_00_SELECT_PROPOFID_DB_SELECT_1_Query1()
            {
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            var executed_1 = R0260_00_SELECT_PROPOFID_DB_SELECT_1_Query1.Execute(r0260_00_SELECT_PROPOFID_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CONV_NUM_SICOB, V0CONV_NUM_SICOB);
                _.Move(executed_1.V0SIVPF_SIT_PROPOSTA, V0SIVPF_SIT_PROPOSTA);
                _.Move(executed_1.V0CONV_NUM_PROPOSTA_SIVPF, V0CONV_NUM_PROPOSTA_SIVPF);
                _.Move(executed_1.PRPFIDEL_COD_PROD_SIVPF, PRPFIDEL_COD_PROD_SIVPF);
                _.Move(executed_1.PRPFIDEL_ORIG_PROPOSTA, PRPFIDEL_ORIG_PROPOSTA);
                _.Move(executed_1.PRPFIDEL_QTD_MESES, PRPFIDEL_QTD_MESES);
                _.Move(executed_1.PRPFIDEL_PERIPGTO, PRPFIDEL_PERIPGTO);
                _.Move(executed_1.PRPFIDEL_OPCAO_COBER, PRPFIDEL_OPCAO_COBER);
                _.Move(executed_1.PRPFIDEL_DIA_DEBITO, PRPFIDEL_DIA_DEBITO);
                _.Move(executed_1.PRPFIDEL_NUM_IDENTIFICA, PRPFIDEL_NUM_IDENTIFICA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0260_99_SAIDA*/

        [StopWatch]
        /*" R0270-00-SELECT-PRPFIDCO-SECTION */
        private void R0270_00_SELECT_PRPFIDCO_SECTION()
        {
            /*" -2028- MOVE '0270' TO WNR-EXEC-SQL. */
            _.Move("0270", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2037- PERFORM R0270_00_SELECT_PRPFIDCO_DB_SELECT_1 */

            R0270_00_SELECT_PRPFIDCO_DB_SELECT_1();

            /*" -2040- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2042- MOVE '99993103201531032015' TO PRPFIDCO-INFORM-COMPLEM */
                _.Move("99993103201531032015", PRPFIDCO_INFORM_COMPLEM);

                /*" -2043- ELSE */
            }
            else
            {


                /*" -2044- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2045- DISPLAY 'R0270-00 (ERRO - SELECT INFORMACAO_COMPL)' */
                    _.Display($"R0270-00 (ERRO - SELECT INFORMACAO_COMPL)");

                    /*" -2047- DISPLAY 'BILHETE: ' V0BILH-NUMBIL '  ' 'RAMO   : ' V0BILH-RAMO '  ' */

                    $"BILHETE: {V0BILH_NUMBIL}  RAMO   : {V0BILH_RAMO}  "
                    .Display();

                    /*" -2049- DISPLAY 'PROPFID: ' V0CONV-NUM-PROPOSTA-SIVPF '  ' 'IDENTIF: ' PRPFIDEL-NUM-IDENTIFICA '  ' */

                    $"PROPFID: {V0CONV_NUM_PROPOSTA_SIVPF}  IDENTIF: {PRPFIDEL_NUM_IDENTIFICA}  "
                    .Display();

                    /*" -2051- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2052- MOVE PRPFIDCO-INFORM-COMPLEM TO WWORK-INFORM-COMPLEME */
            _.Move(PRPFIDCO_INFORM_COMPLEM, AREA_DE_WORK.WWORK_INFORM_COMPLEME);

            /*" -2054- IF W-DATA-IDA-VIAGEM NOT NUMERIC OR W-DATA-VOL-VIAGEM NOT NUMERIC */

            if (!AREA_DE_WORK.WWORK_INFORM_COMPLEME.W_DATAS_VIAGEM.W_DATA_IDA_VIAGEM.IsNumeric() || !AREA_DE_WORK.WWORK_INFORM_COMPLEME.W_DATAS_VIAGEM.W_DATA_VOL_VIAGEM.IsNumeric())
            {

                /*" -2057- MOVE '99993103201531032015' TO PRPFIDCO-INFORM-COMPLEM. */
                _.Move("99993103201531032015", PRPFIDCO_INFORM_COMPLEM);
            }


            /*" -2058- MOVE PRPFIDCO-INFORM-COMPLEM TO WWORK-INFORM-COMPLEME */
            _.Move(PRPFIDCO_INFORM_COMPLEM, AREA_DE_WORK.WWORK_INFORM_COMPLEME);

            /*" -2059- MOVE W-DIA-IDA-VIAGEM TO W-DIA-INI-VIG-VIAGEM */
            _.Move(AREA_DE_WORK.WWORK_INFORM_COMPLEME.W_DATAS_VIAGEM.W_DATA_IDA_VIAGEM.W_DIA_IDA_VIAGEM, AREA_DE_WORK.WWORK_VIGENCIA_VIAGEM.W_DATA_INI_VIG_VIAGEM.W_DIA_INI_VIG_VIAGEM);

            /*" -2060- MOVE W-MES-IDA-VIAGEM TO W-MES-INI-VIG-VIAGEM */
            _.Move(AREA_DE_WORK.WWORK_INFORM_COMPLEME.W_DATAS_VIAGEM.W_DATA_IDA_VIAGEM.W_MES_IDA_VIAGEM, AREA_DE_WORK.WWORK_VIGENCIA_VIAGEM.W_DATA_INI_VIG_VIAGEM.W_MES_INI_VIG_VIAGEM);

            /*" -2062- MOVE W-ANO-IDA-VIAGEM TO W-ANO-INI-VIG-VIAGEM */
            _.Move(AREA_DE_WORK.WWORK_INFORM_COMPLEME.W_DATAS_VIAGEM.W_DATA_IDA_VIAGEM.W_ANO_IDA_VIAGEM, AREA_DE_WORK.WWORK_VIGENCIA_VIAGEM.W_DATA_INI_VIG_VIAGEM.W_ANO_INI_VIG_VIAGEM);

            /*" -2063- MOVE W-DIA-VOL-VIAGEM TO W-DIA-FIM-VIG-VIAGEM */
            _.Move(AREA_DE_WORK.WWORK_INFORM_COMPLEME.W_DATAS_VIAGEM.W_DATA_VOL_VIAGEM.W_DIA_VOL_VIAGEM, AREA_DE_WORK.WWORK_VIGENCIA_VIAGEM.W_DATA_FIM_VIG_VIAGEM.W_DIA_FIM_VIG_VIAGEM);

            /*" -2064- MOVE W-MES-VOL-VIAGEM TO W-MES-FIM-VIG-VIAGEM */
            _.Move(AREA_DE_WORK.WWORK_INFORM_COMPLEME.W_DATAS_VIAGEM.W_DATA_VOL_VIAGEM.W_MES_VOL_VIAGEM, AREA_DE_WORK.WWORK_VIGENCIA_VIAGEM.W_DATA_FIM_VIG_VIAGEM.W_MES_FIM_VIG_VIAGEM);

            /*" -2064- MOVE W-ANO-VOL-VIAGEM TO W-ANO-FIM-VIG-VIAGEM. */
            _.Move(AREA_DE_WORK.WWORK_INFORM_COMPLEME.W_DATAS_VIAGEM.W_DATA_VOL_VIAGEM.W_ANO_VOL_VIAGEM, AREA_DE_WORK.WWORK_VIGENCIA_VIAGEM.W_DATA_FIM_VIG_VIAGEM.W_ANO_FIM_VIG_VIAGEM);

        }

        [StopWatch]
        /*" R0270-00-SELECT-PRPFIDCO-DB-SELECT-1 */
        public void R0270_00_SELECT_PRPFIDCO_DB_SELECT_1()
        {
            /*" -2037- EXEC SQL SELECT INFORMACAO_COMPL INTO :PRPFIDCO-INFORM-COMPLEM FROM SEGUROS.PROP_FIDELIZ_COMP WHERE NUM_IDENTIFICACAO = :PRPFIDEL-NUM-IDENTIFICA AND IND_TP_INFORMACAO = '1' FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC */

            var r0270_00_SELECT_PRPFIDCO_DB_SELECT_1_Query1 = new R0270_00_SELECT_PRPFIDCO_DB_SELECT_1_Query1()
            {
                PRPFIDEL_NUM_IDENTIFICA = PRPFIDEL_NUM_IDENTIFICA.ToString(),
            };

            var executed_1 = R0270_00_SELECT_PRPFIDCO_DB_SELECT_1_Query1.Execute(r0270_00_SELECT_PRPFIDCO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRPFIDCO_INFORM_COMPLEM, PRPFIDCO_INFORM_COMPLEM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0270_99_SAIDA*/

        [StopWatch]
        /*" R0280-00-SELECT-CONVERSI-SECTION */
        private void R0280_00_SELECT_CONVERSI_SECTION()
        {
            /*" -2077- MOVE '0280' TO WNR-EXEC-SQL. */
            _.Move("0280", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2084- PERFORM R0280_00_SELECT_CONVERSI_DB_SELECT_1 */

            R0280_00_SELECT_CONVERSI_DB_SELECT_1();

            /*" -2088- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2089- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2090- MOVE 'N' TO WS-SIVPF */
                    _.Move("N", AREA_DE_WORK.WS_SIVPF);

                    /*" -2092- MOVE ZEROS TO V0CONV-NUM-PROPOSTA-SIVPF */
                    _.Move(0, V0CONV_NUM_PROPOSTA_SIVPF);

                    /*" -2093- ELSE */
                }
                else
                {


                    /*" -2094- DISPLAY 'R0280-00 (ERRO - SELECT CONVERSAO_SICOB)' */
                    _.Display($"R0280-00 (ERRO - SELECT CONVERSAO_SICOB)");

                    /*" -2096- DISPLAY 'BILHETE: ' V0BILH-NUMBIL '  ' 'RAMO: ' V0BILH-RAMO '  ' */

                    $"BILHETE: {V0BILH_NUMBIL}  RAMO: {V0BILH_RAMO}  "
                    .Display();

                    /*" -2096- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0280-00-SELECT-CONVERSI-DB-SELECT-1 */
        public void R0280_00_SELECT_CONVERSI_DB_SELECT_1()
        {
            /*" -2084- EXEC SQL SELECT NUM_PROPOSTA_SIVPF INTO :V0CONV-NUM-PROPOSTA-SIVPF FROM SEGUROS.CONVERSAO_SICOB WHERE NUM_SICOB = :V0BILH-NUMBIL FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC */

            var r0280_00_SELECT_CONVERSI_DB_SELECT_1_Query1 = new R0280_00_SELECT_CONVERSI_DB_SELECT_1_Query1()
            {
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            var executed_1 = R0280_00_SELECT_CONVERSI_DB_SELECT_1_Query1.Execute(r0280_00_SELECT_CONVERSI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CONV_NUM_PROPOSTA_SIVPF, V0CONV_NUM_PROPOSTA_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0280_99_SAIDA*/

        [StopWatch]
        /*" R0290-00-SELECT-BILPLCOBER-SECTION */
        private void R0290_00_SELECT_BILPLCOBER_SECTION()
        {
            /*" -2109- MOVE '0290' TO WNR-EXEC-SQL. */
            _.Move("0290", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2120- PERFORM R0290_00_SELECT_BILPLCOBER_DB_SELECT_1 */

            R0290_00_SELECT_BILPLCOBER_DB_SELECT_1();

            /*" -2124- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2125- MOVE ZEROS TO V1BILP-CODPRODU */
                _.Move(0, V1BILP_CODPRODU);

                /*" -2126- ELSE */
            }
            else
            {


                /*" -2127- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2128- DISPLAY 'R0290-00 (ERRO - SELECT V0BILHETE_PLCOBER)' */
                    _.Display($"R0290-00 (ERRO - SELECT V0BILHETE_PLCOBER)");

                    /*" -2131- DISPLAY 'BILHETE: ' V0BILH-NUMBIL '  ' 'RAMO: ' V0BILH-RAMO '  ' 'OPCAO COBER: ' V0BILH-OPCAO-COBER */

                    $"BILHETE: {V0BILH_NUMBIL}  RAMO: {V0BILH_RAMO}  OPCAO COBER: {V0BILH_OPCAO_COBER}"
                    .Display();

                    /*" -2131- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0290-00-SELECT-BILPLCOBER-DB-SELECT-1 */
        public void R0290_00_SELECT_BILPLCOBER_DB_SELECT_1()
        {
            /*" -2120- EXEC SQL SELECT CODPRODU INTO :V1BILP-CODPRODU FROM SEGUROS.V0BILHETE_PLCOBER WHERE COD_EMPRESA = 0 AND RAMOFR = :V0BILH-RAMO AND MODALIFR = 0 AND COD_OPCAO = :V0BILH-OPCAO-COBER AND SITUACAO = '0' FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0290_00_SELECT_BILPLCOBER_DB_SELECT_1_Query1 = new R0290_00_SELECT_BILPLCOBER_DB_SELECT_1_Query1()
            {
                V0BILH_OPCAO_COBER = V0BILH_OPCAO_COBER.ToString(),
                V0BILH_RAMO = V0BILH_RAMO.ToString(),
            };

            var executed_1 = R0290_00_SELECT_BILPLCOBER_DB_SELECT_1_Query1.Execute(r0290_00_SELECT_BILPLCOBER_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1BILP_CODPRODU, V1BILP_CODPRODU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0290_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-VER-LIMITE-RISCO-SECTION */
        private void R0300_00_VER_LIMITE_RISCO_SECTION()
        {
            /*" -2144- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2146- MOVE ZEROS TO V0BILER-COD-ERRO. */
            _.Move(0, V0BILER_COD_ERRO);

            /*" -2147- IF V0BILH-RAMO EQUAL 81 OR 37 */

            if (V0BILH_RAMO.In("81", "37"))
            {

                /*" -2148- PERFORM R0310-00-SELECT-CLIENTE */

                R0310_00_SELECT_CLIENTE_SECTION();

                /*" -2149- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2150- GO TO R0300-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/ //GOTO
                    return;

                    /*" -2151- END-IF */
                }


                /*" -2152- PERFORM R0320-00-SELECT-GELIMRISCO */

                R0320_00_SELECT_GELIMRISCO_SECTION();

                /*" -2153- PERFORM R0330-00-SELECT-BIL-COBER */

                R0330_00_SELECT_BIL_COBER_SECTION();

                /*" -2154- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2155- GO TO R0300-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/ //GOTO
                    return;

                    /*" -2156- END-IF */
                }


                /*" -2158- COMPUTE GELMR-VLR-SOMA-IS = GELMR-VLR-SOMA-IS + V1BILC-IMPSEG-IX */
                GELMR_VLR_SOMA_IS.Value = GELMR_VLR_SOMA_IS + V1BILC_IMPSEG_IX;

                /*" -2159- IF V0BILH-RAMO EQUAL 81 */

                if (V0BILH_RAMO == 81)
                {

                    /*" -2160- IF GELMR-VLR-SOMA-IS > 300000,01 */

                    if (GELMR_VLR_SOMA_IS > 300000.01)
                    {

                        /*" -2161- MOVE 834 TO V0BILER-COD-ERRO */
                        _.Move(834, V0BILER_COD_ERRO);

                        /*" -2163- PERFORM R3045-00-GRAVA-TAB-ERRO */

                        R3045_00_GRAVA_TAB_ERRO_SECTION();

                        /*" -2164- MOVE '0' TO V0BILH-SITUACAO */
                        _.Move("0", V0BILH_SITUACAO);

                        /*" -2165- PERFORM R3020-00-UPDATE-V0BILHETE */

                        R3020_00_UPDATE_V0BILHETE_SECTION();

                        /*" -2166- GO TO R0300-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/ //GOTO
                        return;

                        /*" -2167- END-IF */
                    }


                    /*" -2168- ELSE */
                }
                else
                {


                    /*" -2169- IF V0BILH-RAMO EQUAL 37 */

                    if (V0BILH_RAMO == 37)
                    {

                        /*" -2170- IF GELMR-VLR-SOMA-IS > 24000,01 */

                        if (GELMR_VLR_SOMA_IS > 24000.01)
                        {

                            /*" -2171- MOVE 834 TO V0BILER-COD-ERRO */
                            _.Move(834, V0BILER_COD_ERRO);

                            /*" -2173- PERFORM R3045-00-GRAVA-TAB-ERRO */

                            R3045_00_GRAVA_TAB_ERRO_SECTION();

                            /*" -2174- MOVE '0' TO V0BILH-SITUACAO */
                            _.Move("0", V0BILH_SITUACAO);

                            /*" -2174- PERFORM R3020-00-UPDATE-V0BILHETE. */

                            R3020_00_UPDATE_V0BILHETE_SECTION();
                        }

                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0310-00-SELECT-CLIENTE-SECTION */
        private void R0310_00_SELECT_CLIENTE_SECTION()
        {
            /*" -2186- MOVE '0310' TO WNR-EXEC-SQL. */
            _.Move("0310", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2195- PERFORM R0310_00_SELECT_CLIENTE_DB_SELECT_1 */

            R0310_00_SELECT_CLIENTE_DB_SELECT_1();

            /*" -2198- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2200- DISPLAY 'R0310 - REGISTRO NAO ENCONTRADO V0CLIENTE' V0BILH-NUMBIL ' ' V0BILH-CODCLIEN */

                $"R0310 - REGISTRO NAO ENCONTRADO V0CLIENTE{V0BILH_NUMBIL} {V0BILH_CODCLIEN}"
                .Display();

                /*" -2201- ELSE */
            }
            else
            {


                /*" -2202- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -2203- DISPLAY 'R0310 - ERRO SELECT V0CLIENTE ' SQLCODE */
                    _.Display($"R0310 - ERRO SELECT V0CLIENTE {DB.SQLCODE}");

                    /*" -2204- DISPLAY 'NUMBIL = ' V0BILH-NUMBIL */
                    _.Display($"NUMBIL = {V0BILH_NUMBIL}");

                    /*" -2205- DISPLAY 'CODCLI = ' V0BILH-CODCLIEN */
                    _.Display($"CODCLI = {V0BILH_CODCLIEN}");

                    /*" -2205- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0310-00-SELECT-CLIENTE-DB-SELECT-1 */
        public void R0310_00_SELECT_CLIENTE_DB_SELECT_1()
        {
            /*" -2195- EXEC SQL SELECT CGCCPF, DATA_NASCIMENTO INTO :V0CLIE-CGCCPF, :V0CLIE-DTNASC:VIND-DTNASC FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = :V0BILH-CODCLIEN FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0310_00_SELECT_CLIENTE_DB_SELECT_1_Query1 = new R0310_00_SELECT_CLIENTE_DB_SELECT_1_Query1()
            {
                V0BILH_CODCLIEN = V0BILH_CODCLIEN.ToString(),
            };

            var executed_1 = R0310_00_SELECT_CLIENTE_DB_SELECT_1_Query1.Execute(r0310_00_SELECT_CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CLIE_CGCCPF, V0CLIE_CGCCPF);
                _.Move(executed_1.V0CLIE_DTNASC, V0CLIE_DTNASC);
                _.Move(executed_1.VIND_DTNASC, VIND_DTNASC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/

        [StopWatch]
        /*" R0320-00-SELECT-GELIMRISCO-SECTION */
        private void R0320_00_SELECT_GELIMRISCO_SECTION()
        {
            /*" -2216- MOVE '0320' TO WNR-EXEC-SQL. */
            _.Move("0320", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2218- MOVE 'SIM' TO WTEM-GELMR. */
            _.Move("SIM", AREA_DE_WORK.WTEM_GELMR);

            /*" -2226- PERFORM R0320_00_SELECT_GELIMRISCO_DB_SELECT_1 */

            R0320_00_SELECT_GELIMRISCO_DB_SELECT_1();

            /*" -2229- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2230- MOVE 'NAO' TO WTEM-GELMR */
                _.Move("NAO", AREA_DE_WORK.WTEM_GELMR);

                /*" -2232- MOVE ZEROES TO GELMR-QTD-SEGUROS GELMR-VLR-SOMA-IS */
                _.Move(0, GELMR_QTD_SEGUROS, GELMR_VLR_SOMA_IS);

                /*" -2233- ELSE */
            }
            else
            {


                /*" -2234- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -2236- DISPLAY 'R0320 - ERRO SELECT GE_LIMITE_DE_RISCO..' SQLCODE */
                    _.Display($"R0320 - ERRO SELECT GE_LIMITE_DE_RISCO..{DB.SQLCODE}");

                    /*" -2237- DISPLAY 'NUMBIL = ' V0BILH-NUMBIL */
                    _.Display($"NUMBIL = {V0BILH_NUMBIL}");

                    /*" -2238- DISPLAY 'CODCLI = ' V0BILH-CODCLIEN */
                    _.Display($"CODCLI = {V0BILH_CODCLIEN}");

                    /*" -2239- DISPLAY 'CGCCPF = ' V0CLIE-CGCCPF */
                    _.Display($"CGCCPF = {V0CLIE_CGCCPF}");

                    /*" -2239- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0320-00-SELECT-GELIMRISCO-DB-SELECT-1 */
        public void R0320_00_SELECT_GELIMRISCO_DB_SELECT_1()
        {
            /*" -2226- EXEC SQL SELECT VALUE(QTD_SEGUROS, 0), VALUE(VLR_SOMA_IS, 0) INTO :GELMR-QTD-SEGUROS, :GELMR-VLR-SOMA-IS FROM SEGUROS.GE_LIMITE_DE_RISCO WHERE CGCCPF = :V0CLIE-CGCCPF WITH UR END-EXEC. */

            var r0320_00_SELECT_GELIMRISCO_DB_SELECT_1_Query1 = new R0320_00_SELECT_GELIMRISCO_DB_SELECT_1_Query1()
            {
                V0CLIE_CGCCPF = V0CLIE_CGCCPF.ToString(),
            };

            var executed_1 = R0320_00_SELECT_GELIMRISCO_DB_SELECT_1_Query1.Execute(r0320_00_SELECT_GELIMRISCO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GELMR_QTD_SEGUROS, GELMR_QTD_SEGUROS);
                _.Move(executed_1.GELMR_VLR_SOMA_IS, GELMR_VLR_SOMA_IS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0320_99_SAIDA*/

        [StopWatch]
        /*" R0330-00-SELECT-BIL-COBER-SECTION */
        private void R0330_00_SELECT_BIL_COBER_SECTION()
        {
            /*" -2251- MOVE '0330' TO WNR-EXEC-SQL. */
            _.Move("0330", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2260- PERFORM R0330_00_SELECT_BIL_COBER_DB_SELECT_1 */

            R0330_00_SELECT_BIL_COBER_DB_SELECT_1();

            /*" -2263- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2264- MOVE ZEROES TO V1BILC-IMPSEG-IX */
                _.Move(0, V1BILC_IMPSEG_IX);

                /*" -2265- ELSE */
            }
            else
            {


                /*" -2266- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -2267- DISPLAY 'R0330 - ERRO SELECT BILHETE_COBER' SQLCODE */
                    _.Display($"R0330 - ERRO SELECT BILHETE_COBER{DB.SQLCODE}");

                    /*" -2268- DISPLAY 'NUMBIL = ' V0BILH-NUMBIL */
                    _.Display($"NUMBIL = {V0BILH_NUMBIL}");

                    /*" -2269- DISPLAY 'CODCLI = ' V0BILH-CODCLIEN */
                    _.Display($"CODCLI = {V0BILH_CODCLIEN}");

                    /*" -2270- DISPLAY 'CGCCPF = ' V0CLIE-CGCCPF */
                    _.Display($"CGCCPF = {V0CLIE_CGCCPF}");

                    /*" -2270- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0330-00-SELECT-BIL-COBER-DB-SELECT-1 */
        public void R0330_00_SELECT_BIL_COBER_DB_SELECT_1()
        {
            /*" -2260- EXEC SQL SELECT VALUE(VAL_COBERTURA_IX, 0) INTO :V1BILC-IMPSEG-IX FROM SEGUROS.V0BILHETE_COBER WHERE RAMOFR = :V0BILH-RAMO AND MODALIFR = 0 AND COD_OPCAO = :V0BILH-OPCAO-COBER FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0330_00_SELECT_BIL_COBER_DB_SELECT_1_Query1 = new R0330_00_SELECT_BIL_COBER_DB_SELECT_1_Query1()
            {
                V0BILH_OPCAO_COBER = V0BILH_OPCAO_COBER.ToString(),
                V0BILH_RAMO = V0BILH_RAMO.ToString(),
            };

            var executed_1 = R0330_00_SELECT_BIL_COBER_DB_SELECT_1_Query1.Execute(r0330_00_SELECT_BIL_COBER_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1BILC_IMPSEG_IX, V1BILC_IMPSEG_IX);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0330_99_SAIDA*/

        [StopWatch]
        /*" R0350-00-VER-VIGENCIA-SECTION */
        private void R0350_00_VER_VIGENCIA_SECTION()
        {
            /*" -2283- MOVE '0350' TO WNR-EXEC-SQL. */
            _.Move("0350", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2284- MOVE V0BILH-RAMO TO WWORK-RAMO-ANT */
            _.Move(V0BILH_RAMO, WWORK_RAMO_ANT);

            /*" -2286- MOVE V0BILH-OPCAO-COBER TO WWORK-OPCAO-ANT. */
            _.Move(V0BILH_OPCAO_COBER, WWORK_OPCAO_ANT);

            /*" -2287- MOVE ZEROES TO V0ADIA-VALADT. */
            _.Move(0, V0ADIA_VALADT);

            /*" -2288- MOVE '9999-99-99' TO WWORK-MIN-DTINIVIG. */
            _.Move("9999-99-99", WWORK_MIN_DTINIVIG);

            /*" -2289- MOVE SPACES TO WWORK-MAX-DTTERVIG. */
            _.Move("", WWORK_MAX_DTTERVIG);

            /*" -2291- MOVE ZEROES TO WWORK-NUM-ITENS. */
            _.Move(0, AREA_DE_WORK.WWORK_NUM_ITENS);

            /*" -2292- MOVE V0BILH-DTQITBCO TO WWORK-DATA. */
            _.Move(V0BILH_DTQITBCO, AREA_DE_WORK.WWORK_DATA);

            /*" -2293- MOVE WWORK-ANO TO WWORK-ANOINI. */
            _.Move(AREA_DE_WORK.WWORK_DATA.WWORK_ANO, AREA_DE_WORK.FILLER_21.WWORK_ANOINI);

            /*" -2294- MOVE WWORK-MES TO WWORK-MESINI. */
            _.Move(AREA_DE_WORK.WWORK_DATA.WWORK_MES, AREA_DE_WORK.FILLER_21.WWORK_MESINI);

            /*" -2296- MOVE WWORK-DIA TO WWORK-DIAINI. */
            _.Move(AREA_DE_WORK.WWORK_DATA.WWORK_DIA, AREA_DE_WORK.FILLER_21.WWORK_DIAINI);

            /*" -2297- MOVE WWORK-DATAINI TO WS000-DATA01. */
            _.Move(AREA_DE_WORK.WWORK_DATAINI, WS000_PARM_PROSOMD1.WS000_DATA01);

            /*" -2298- MOVE 1 TO WS000-QTDIAS. */
            _.Move(1, WS000_PARM_PROSOMD1.WS000_QTDIAS);

            /*" -2300- MOVE ZEROS TO WS000-DATA02. */
            _.Move(0, WS000_PARM_PROSOMD1.WS000_DATA02);

            /*" -2302- CALL 'PROSOMC1' USING WS000-PARM-PROSOMD1 */
            _.Call("PROSOMC1", WS000_PARM_PROSOMD1);

            /*" -2303- MOVE WS000-DATA02 TO WWORK-DATAINI. */
            _.Move(WS000_PARM_PROSOMD1.WS000_DATA02, AREA_DE_WORK.WWORK_DATAINI);

            /*" -2304- MOVE WWORK-ANOINI TO WWORK-ANO. */
            _.Move(AREA_DE_WORK.FILLER_21.WWORK_ANOINI, AREA_DE_WORK.WWORK_DATA.WWORK_ANO);

            /*" -2305- MOVE WWORK-MESINI TO WWORK-MES. */
            _.Move(AREA_DE_WORK.FILLER_21.WWORK_MESINI, AREA_DE_WORK.WWORK_DATA.WWORK_MES);

            /*" -2307- MOVE WWORK-DIAINI TO WWORK-DIA. */
            _.Move(AREA_DE_WORK.FILLER_21.WWORK_DIAINI, AREA_DE_WORK.WWORK_DATA.WWORK_DIA);

            /*" -2308- IF WWORK-MES EQUAL 02 */

            if (AREA_DE_WORK.WWORK_DATA.WWORK_MES == 02)
            {

                /*" -2309- IF WWORK-DIA EQUAL 29 */

                if (AREA_DE_WORK.WWORK_DATA.WWORK_DIA == 29)
                {

                    /*" -2310- COMPUTE WWORK-ANO-BI = WWORK-ANO / 4 */
                    AREA_DE_WORK.WWORK_ANO_BI.Value = AREA_DE_WORK.WWORK_DATA.WWORK_ANO / 4;

                    /*" -2311- COMPUTE WWORK-ANO-BI = WWORK-ANO-BI * 4 */
                    AREA_DE_WORK.WWORK_ANO_BI.Value = AREA_DE_WORK.WWORK_ANO_BI * 4;

                    /*" -2312- IF WWORK-ANO NOT EQUAL WWORK-ANO-BI */

                    if (AREA_DE_WORK.WWORK_DATA.WWORK_ANO != AREA_DE_WORK.WWORK_ANO_BI)
                    {

                        /*" -2313- MOVE 03 TO WWORK-MES */
                        _.Move(03, AREA_DE_WORK.WWORK_DATA.WWORK_MES);

                        /*" -2315- MOVE 01 TO WWORK-DIA. */
                        _.Move(01, AREA_DE_WORK.WWORK_DATA.WWORK_DIA);
                    }

                }

            }


            /*" -2316- IF WWORK-DATA < WWORK-MIN-DTINIVIG */

            if (AREA_DE_WORK.WWORK_DATA < WWORK_MIN_DTINIVIG)
            {

                /*" -2318- MOVE WWORK-DATA TO WWORK-MIN-DTINIVIG. */
                _.Move(AREA_DE_WORK.WWORK_DATA, WWORK_MIN_DTINIVIG);
            }


            /*" -2320- MOVE WWORK-MIN-DTINIVIG TO WHOST-DTINIVIG */
            _.Move(WWORK_MIN_DTINIVIG, WHOST_DTINIVIG);

            /*" -2326- PERFORM R0350_00_VER_VIGENCIA_DB_SELECT_1 */

            R0350_00_VER_VIGENCIA_DB_SELECT_1();

            /*" -2329- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2331- DISPLAY 'R0350-00 (ERRO - SELECT DATA-TERVIG ' ' ' V0BILH-NUMBIL */

                $"R0350-00 (ERRO - SELECT DATA-TERVIG  {V0BILH_NUMBIL}"
                .Display();

                /*" -2332- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2334- END-IF. */
            }


            /*" -2343- MOVE WHOST-DTTERVIG TO WWORK-MAX-DTTERVIG. */
            _.Move(WHOST_DTTERVIG, WWORK_MAX_DTTERVIG);

            /*" -2344- IF V0BILH-RAMO EQUAL 69 */

            if (V0BILH_RAMO == 69)
            {

                /*" -2349- IF W-DATA-FIM-VIG-VIAGEM EQUAL W-DATA-INI-VIG-VIAGEM */

                if (AREA_DE_WORK.WWORK_VIGENCIA_VIAGEM.W_DATA_FIM_VIG_VIAGEM == AREA_DE_WORK.WWORK_VIGENCIA_VIAGEM.W_DATA_INI_VIG_VIAGEM)
                {

                    /*" -2350- MOVE W-DATA-INI-VIG-VIAGEM TO WHOST-DTINIVIG */
                    _.Move(AREA_DE_WORK.WWORK_VIGENCIA_VIAGEM.W_DATA_INI_VIG_VIAGEM, WHOST_DTINIVIG);

                    /*" -2355- PERFORM R0350_00_VER_VIGENCIA_DB_SELECT_2 */

                    R0350_00_VER_VIGENCIA_DB_SELECT_2();

                    /*" -2358- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -2362- DISPLAY 'R0250-00 (ERRO - CALCULO DATA-TERVIG ' ' ' V0BILH-NUMBIL ' ' W-DATA-INI-VIG-VIAGEM ' ' W-DATA-FIM-VIG-VIAGEM */

                        $"R0250-00 (ERRO - CALCULO DATA-TERVIG  {V0BILH_NUMBIL} {AREA_DE_WORK.WWORK_VIGENCIA_VIAGEM.W_DATA_INI_VIG_VIAGEM} {AREA_DE_WORK.WWORK_VIGENCIA_VIAGEM.W_DATA_FIM_VIG_VIAGEM}"
                        .Display();

                        /*" -2363- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -2364- END-IF */
                    }


                    /*" -2365- MOVE WHOST-DTTERVIG TO W-DATA-FIM-VIG-VIAGEM */
                    _.Move(WHOST_DTTERVIG, AREA_DE_WORK.WWORK_VIGENCIA_VIAGEM.W_DATA_FIM_VIG_VIAGEM);

                    /*" -2367- END-IF */
                }


                /*" -2369- MOVE W-DATA-FIM-VIG-VIAGEM TO WWORK-MAX-DTTERVIG WHOST-DTTERVIG */
                _.Move(AREA_DE_WORK.WWORK_VIGENCIA_VIAGEM.W_DATA_FIM_VIG_VIAGEM, WWORK_MAX_DTTERVIG, WHOST_DTTERVIG);

                /*" -2370- END-IF. */
            }


        }

        [StopWatch]
        /*" R0350-00-VER-VIGENCIA-DB-SELECT-1 */
        public void R0350_00_VER_VIGENCIA_DB_SELECT_1()
        {
            /*" -2326- EXEC SQL SELECT DATE(:WHOST-DTINIVIG) + :PRPFIDEL-QTD-MESES MONTHS - 1 DAY INTO :WHOST-DTTERVIG FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'BI' END-EXEC */

            var r0350_00_VER_VIGENCIA_DB_SELECT_1_Query1 = new R0350_00_VER_VIGENCIA_DB_SELECT_1_Query1()
            {
                PRPFIDEL_QTD_MESES = PRPFIDEL_QTD_MESES.ToString(),
                WHOST_DTINIVIG = WHOST_DTINIVIG.ToString(),
            };

            var executed_1 = R0350_00_VER_VIGENCIA_DB_SELECT_1_Query1.Execute(r0350_00_VER_VIGENCIA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DTTERVIG, WHOST_DTTERVIG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_99_SAIDA*/

        [StopWatch]
        /*" R0350-00-VER-VIGENCIA-DB-SELECT-2 */
        public void R0350_00_VER_VIGENCIA_DB_SELECT_2()
        {
            /*" -2355- EXEC SQL SELECT DATE(:WHOST-DTINIVIG) + 4 DAYS INTO :WHOST-DTTERVIG FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'BI' END-EXEC */

            var r0350_00_VER_VIGENCIA_DB_SELECT_2_Query1 = new R0350_00_VER_VIGENCIA_DB_SELECT_2_Query1()
            {
                WHOST_DTINIVIG = WHOST_DTINIVIG.ToString(),
            };

            var executed_1 = R0350_00_VER_VIGENCIA_DB_SELECT_2_Query1.Execute(r0350_00_VER_VIGENCIA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DTTERVIG, WHOST_DTTERVIG);
            }


        }

        [StopWatch]
        /*" R0370-00-SELECT-APOLICE-ANT-SECTION */
        private void R0370_00_SELECT_APOLICE_ANT_SECTION()
        {
            /*" -2382- MOVE '0370' TO WNR-EXEC-SQL. */
            _.Move("0370", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2384- MOVE V0BILH-NUM-APO-ANT TO V1APOL-NUMBIL */
            _.Move(V0BILH_NUM_APO_ANT, V1APOL_NUMBIL);

            /*" -2392- PERFORM R0370_00_SELECT_APOLICE_ANT_DB_SELECT_1 */

            R0370_00_SELECT_APOLICE_ANT_DB_SELECT_1();

            /*" -2395- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2396- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2397- MOVE 0 TO V1APOL-NUM-APOL */
                    _.Move(0, V1APOL_NUM_APOL);

                    /*" -2398- ELSE */
                }
                else
                {


                    /*" -2399- DISPLAY 'R0370-00 (ERRO SELECT V0APOLICE)' */
                    _.Display($"R0370-00 (ERRO SELECT V0APOLICE)");

                    /*" -2400- DISPLAY 'NUMBIL     : ' V1APOL-NUMBIL */
                    _.Display($"NUMBIL     : {V1APOL_NUMBIL}");

                    /*" -2400- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0370-00-SELECT-APOLICE-ANT-DB-SELECT-1 */
        public void R0370_00_SELECT_APOLICE_ANT_DB_SELECT_1()
        {
            /*" -2392- EXEC SQL SELECT NUM_APOLICE ,ORGAO INTO :V1APOL-NUM-APOL :V1COD-ORGAO FROM SEGUROS.V0APOLICE WHERE NUMBIL = :V1APOL-NUMBIL END-EXEC. */

            var r0370_00_SELECT_APOLICE_ANT_DB_SELECT_1_Query1 = new R0370_00_SELECT_APOLICE_ANT_DB_SELECT_1_Query1()
            {
                V1APOL_NUMBIL = V1APOL_NUMBIL.ToString(),
            };

            var executed_1 = R0370_00_SELECT_APOLICE_ANT_DB_SELECT_1_Query1.Execute(r0370_00_SELECT_APOLICE_ANT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1APOL_NUM_APOL, V1APOL_NUM_APOL);
                _.Move(executed_1.V1COD_ORGAO, V1COD_ORGAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0370_99_SAIDA*/

        [StopWatch]
        /*" R0380-00-SELECT-BILCOBER-SECTION */
        private void R0380_00_SELECT_BILCOBER_SECTION()
        {
            /*" -2413- MOVE '0380' TO WNR-EXEC-SQL. */
            _.Move("0380", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2414- MOVE 0 TO V1BILC-COD-EMPR */
            _.Move(0, V1BILC_COD_EMPR);

            /*" -2415- MOVE V1BILP-CODPRODU TO V1BILC-CODPRODU */
            _.Move(V1BILP_CODPRODU, V1BILC_CODPRODU);

            /*" -2416- MOVE WWORK-RAMO-ANT TO V1BILC-RAMOFR */
            _.Move(WWORK_RAMO_ANT, V1BILC_RAMOFR);

            /*" -2417- MOVE 0 TO V1BILC-MODALIFR */
            _.Move(0, V1BILC_MODALIFR);

            /*" -2419- MOVE WWORK-OPCAO-ANT TO V1BILC-OPCAO */
            _.Move(WWORK_OPCAO_ANT, V1BILC_OPCAO);

            /*" -2429- PERFORM R0380_00_SELECT_BILCOBER_DB_SELECT_1 */

            R0380_00_SELECT_BILCOBER_DB_SELECT_1();

            /*" -2433- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2434- MOVE 1503 TO V0BILER-COD-ERRO */
                _.Move(1503, V0BILER_COD_ERRO);

                /*" -2436- PERFORM R3045-00-GRAVA-TAB-ERRO */

                R3045_00_GRAVA_TAB_ERRO_SECTION();

                /*" -2437- MOVE '0' TO V0BILH-SITUACAO */
                _.Move("0", V0BILH_SITUACAO);

                /*" -2438- PERFORM R3020-00-UPDATE-V0BILHETE */

                R3020_00_UPDATE_V0BILHETE_SECTION();

                /*" -2439- DISPLAY 'R0380-00 (ERRO SELECT V1BILCOBER)' */
                _.Display($"R0380-00 (ERRO SELECT V1BILCOBER)");

                /*" -2440- DISPLAY 'BILHETE    : ' V0BILH-NUMBIL */
                _.Display($"BILHETE    : {V0BILH_NUMBIL}");

                /*" -2441- DISPLAY 'CODPRODU   : ' V1BILC-CODPRODU */
                _.Display($"CODPRODU   : {V1BILC_CODPRODU}");

                /*" -2442- DISPLAY 'RAMOFR     : ' V1BILC-RAMOFR */
                _.Display($"RAMOFR     : {V1BILC_RAMOFR}");

                /*" -2443- DISPLAY 'MODALIFR   : ' V1BILC-MODALIFR */
                _.Display($"MODALIFR   : {V1BILC_MODALIFR}");

                /*" -2444- DISPLAY 'COD_OPCAO  : ' V1BILC-OPCAO */
                _.Display($"COD_OPCAO  : {V1BILC_OPCAO}");

                /*" -2445- ELSE */
            }
            else
            {


                /*" -2445- MOVE ZEROS TO V0BILER-COD-ERRO. */
                _.Move(0, V0BILER_COD_ERRO);
            }


        }

        [StopWatch]
        /*" R0380-00-SELECT-BILCOBER-DB-SELECT-1 */
        public void R0380_00_SELECT_BILCOBER_DB_SELECT_1()
        {
            /*" -2429- EXEC SQL SELECT SUM(VAL_COBERTURA_IX), SUM(PRM_TARIFARIO_IX) INTO :V1BILC-IMPSEG-IX, :V1BILC-PRMTAR-IX FROM SEGUROS.V0BILHETE_COBER WHERE RAMOFR = :V1BILC-RAMOFR AND MODALIFR = :V1BILC-MODALIFR AND COD_OPCAO = :V1BILC-OPCAO AND CODPRODU = :V1BILC-CODPRODU END-EXEC. */

            var r0380_00_SELECT_BILCOBER_DB_SELECT_1_Query1 = new R0380_00_SELECT_BILCOBER_DB_SELECT_1_Query1()
            {
                V1BILC_MODALIFR = V1BILC_MODALIFR.ToString(),
                V1BILC_CODPRODU = V1BILC_CODPRODU.ToString(),
                V1BILC_RAMOFR = V1BILC_RAMOFR.ToString(),
                V1BILC_OPCAO = V1BILC_OPCAO.ToString(),
            };

            var executed_1 = R0380_00_SELECT_BILCOBER_DB_SELECT_1_Query1.Execute(r0380_00_SELECT_BILCOBER_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1BILC_IMPSEG_IX, V1BILC_IMPSEG_IX);
                _.Move(executed_1.V1BILC_PRMTAR_IX, V1BILC_PRMTAR_IX);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0380_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-SELECT-RCAPS-SECTION */
        private void R0400_00_SELECT_RCAPS_SECTION()
        {
            /*" -2458- MOVE '0400' TO WNR-EXEC-SQL. */
            _.Move("0400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2459- MOVE SPACES TO WFIM-V1RCAP. */
            _.Move("", AREA_DE_WORK.WFIM_V1RCAP);

            /*" -2461- MOVE V0BILH-NUMBIL TO V0RCAP-NRTIT. */
            _.Move(V0BILH_NUMBIL, V0RCAP_NRTIT);

            /*" -2476- PERFORM R0400_00_SELECT_RCAPS_DB_SELECT_1 */

            R0400_00_SELECT_RCAPS_DB_SELECT_1();

            /*" -2480- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2481- MOVE 'S' TO WFIM-V1RCAP */
                _.Move("S", AREA_DE_WORK.WFIM_V1RCAP);

                /*" -2482- ELSE */
            }
            else
            {


                /*" -2483- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2484- DISPLAY 'R0400-00 (ERRO - SELECT V0RCAP)...' */
                    _.Display($"R0400-00 (ERRO - SELECT V0RCAP)...");

                    /*" -2487- DISPLAY 'BILHETE: ' V0BILH-NUMBIL '  ' 'FONTE: ' V0BILH-FONTE '  ' 'NRRCAP: ' WHOST-NRRCAP */

                    $"BILHETE: {V0BILH_NUMBIL}  FONTE: {V0BILH_FONTE}  NRRCAP: {WHOST_NRRCAP}"
                    .Display();

                    /*" -2488- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2489- ELSE */
                }
                else
                {


                    /*" -2490- IF V0RCAP-SITUACAO NOT EQUAL '0' */

                    if (V0RCAP_SITUACAO != "0")
                    {

                        /*" -2491- MOVE 'S' TO WFIM-V1RCAP */
                        _.Move("S", AREA_DE_WORK.WFIM_V1RCAP);

                        /*" -2492- ELSE */
                    }
                    else
                    {


                        /*" -2494- IF V0RCAP-OPERACAO GREATER 199 AND V0RCAP-OPERACAO LESS 300 */

                        if (V0RCAP_OPERACAO > 199 && V0RCAP_OPERACAO < 300)
                        {

                            /*" -2495- MOVE 'S' TO WFIM-V1RCAP */
                            _.Move("S", AREA_DE_WORK.WFIM_V1RCAP);

                            /*" -2496- ELSE */
                        }
                        else
                        {


                            /*" -2498- IF V0RCAP-OPERACAO GREATER 399 AND V0RCAP-OPERACAO LESS 500 */

                            if (V0RCAP_OPERACAO > 399 && V0RCAP_OPERACAO < 500)
                            {

                                /*" -2501- MOVE 'S' TO WFIM-V1RCAP. */
                                _.Move("S", AREA_DE_WORK.WFIM_V1RCAP);
                            }

                        }

                    }

                }

            }


            /*" -2502- IF WFIM-V1RCAP EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_V1RCAP == "S")
            {

                /*" -2504- IF V0BILH-SITUACAO NOT EQUAL 'E' */

                if (V0BILH_SITUACAO != "E")
                {

                    /*" -2505- MOVE '0' TO V0BILH-SITUACAO */
                    _.Move("0", V0BILH_SITUACAO);

                    /*" -2505- PERFORM R3020-00-UPDATE-V0BILHETE. */

                    R3020_00_UPDATE_V0BILHETE_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0400-00-SELECT-RCAPS-DB-SELECT-1 */
        public void R0400_00_SELECT_RCAPS_DB_SELECT_1()
        {
            /*" -2476- EXEC SQL SELECT FONTE, NRRCAP, VLRCAP, SITUACAO, OPERACAO INTO :V0RCAP-FONTE, :V0RCAP-NRRCAP, :V2RCAP-VLRCAP, :V0RCAP-SITUACAO, :V0RCAP-OPERACAO FROM SEGUROS.V0RCAP WHERE NRTIT = :V0RCAP-NRTIT FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0400_00_SELECT_RCAPS_DB_SELECT_1_Query1 = new R0400_00_SELECT_RCAPS_DB_SELECT_1_Query1()
            {
                V0RCAP_NRTIT = V0RCAP_NRTIT.ToString(),
            };

            var executed_1 = R0400_00_SELECT_RCAPS_DB_SELECT_1_Query1.Execute(r0400_00_SELECT_RCAPS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RCAP_FONTE, V0RCAP_FONTE);
                _.Move(executed_1.V0RCAP_NRRCAP, V0RCAP_NRRCAP);
                _.Move(executed_1.V2RCAP_VLRCAP, V2RCAP_VLRCAP);
                _.Move(executed_1.V0RCAP_SITUACAO, V0RCAP_SITUACAO);
                _.Move(executed_1.V0RCAP_OPERACAO, V0RCAP_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0420-00-ACUMULA-BILHETE-SECTION */
        private void R0420_00_ACUMULA_BILHETE_SECTION()
        {
            /*" -2517- MOVE '0420' TO WNR-EXEC-SQL. */
            _.Move("0420", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2519- PERFORM R0310-00-SELECT-CLIENTE. */

            R0310_00_SELECT_CLIENTE_SECTION();

            /*" -2520- IF V0BILH-RAMO = 81 */

            if (V0BILH_RAMO == 81)
            {

                /*" -2521- MOVE V1BILP-CODPRODU TO WHOST-PROD-MENSAL */
                _.Move(V1BILP_CODPRODU, WHOST_PROD_MENSAL);

                /*" -2522- MOVE V1BILP-CODPRODU TO WHOST-PROD-PUANTE */
                _.Move(V1BILP_CODPRODU, WHOST_PROD_PUANTE);

                /*" -2524- IF JVPROD(V1BILP-CODPRODU) > 0 AND V0BILH-DTQITBCO >= LK-GEJVW002-JV-DTA-INI */

                if (JVBKINCL.FILLER.JVPROD[V1BILP_CODPRODU] > 0 && V0BILH_DTQITBCO >= GEJVW002.LK_GEJVW002_JV_DTA_INI)
                {

                    /*" -2526- MOVE JVPROD(V1BILP-CODPRODU) TO WHOST-PROD-MENSAL */
                    _.Move(JVBKINCL.FILLER.JVPROD[V1BILP_CODPRODU], WHOST_PROD_MENSAL);

                    /*" -2528- MOVE JVPROD(V1BILP-CODPRODU) TO WHOST-PROD-PUANTE */
                    _.Move(JVBKINCL.FILLER.JVPROD[V1BILP_CODPRODU], WHOST_PROD_PUANTE);

                    /*" -2529- END-IF */
                }


                /*" -2530- ELSE */
            }
            else
            {


                /*" -2531- IF V0BILH-RAMO = 37 */

                if (V0BILH_RAMO == 37)
                {

                    /*" -2532- MOVE 3704 TO WHOST-PROD-MENSAL */
                    _.Move(3704, WHOST_PROD_MENSAL);

                    /*" -2533- MOVE 3705 TO WHOST-PROD-PUANTE */
                    _.Move(3705, WHOST_PROD_PUANTE);

                    /*" -2534- IF V0BILH-DTQITBCO >= LK-GEJVW002-JV-DTA-INI */

                    if (V0BILH_DTQITBCO >= GEJVW002.LK_GEJVW002_JV_DTA_INI)
                    {

                        /*" -2535- MOVE 3704 TO WHOST-PROD-MENSAL */
                        _.Move(3704, WHOST_PROD_MENSAL);

                        /*" -2536- MOVE 3705 TO WHOST-PROD-PUANTE */
                        _.Move(3705, WHOST_PROD_PUANTE);

                        /*" -2537- END-IF */
                    }


                    /*" -2538- ELSE */
                }
                else
                {


                    /*" -2539- MOVE V1BILP-CODPRODU TO WHOST-PROD-MENSAL */
                    _.Move(V1BILP_CODPRODU, WHOST_PROD_MENSAL);

                    /*" -2540- MOVE V1BILP-CODPRODU TO WHOST-PROD-PUANTE */
                    _.Move(V1BILP_CODPRODU, WHOST_PROD_PUANTE);

                    /*" -2542- IF JVPROD(V1BILP-CODPRODU) > 0 AND V0BILH-DTQITBCO >= LK-GEJVW002-JV-DTA-INI */

                    if (JVBKINCL.FILLER.JVPROD[V1BILP_CODPRODU] > 0 && V0BILH_DTQITBCO >= GEJVW002.LK_GEJVW002_JV_DTA_INI)
                    {

                        /*" -2544- MOVE JVPROD(V1BILP-CODPRODU) TO WHOST-PROD-MENSAL */
                        _.Move(JVBKINCL.FILLER.JVPROD[V1BILP_CODPRODU], WHOST_PROD_MENSAL);

                        /*" -2546- MOVE JVPROD(V1BILP-CODPRODU) TO WHOST-PROD-PUANTE */
                        _.Move(JVBKINCL.FILLER.JVPROD[V1BILP_CODPRODU], WHOST_PROD_PUANTE);

                        /*" -2547- END-IF */
                    }


                    /*" -2548- END-IF */
                }


                /*" -2550- END-IF. */
            }


            /*" -2552- MOVE ZEROS TO WHOST-COUNT. */
            _.Move(0, WHOST_COUNT);

            /*" -2567- PERFORM R0420_00_ACUMULA_BILHETE_DB_SELECT_1 */

            R0420_00_ACUMULA_BILHETE_DB_SELECT_1();

            /*" -2570- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2571- DISPLAY 'R0420-00 (ERRO - COUNT BILHETE ATM)... ' */
                _.Display($"R0420-00 (ERRO - COUNT BILHETE ATM)... ");

                /*" -2574- DISPLAY 'FONTE: ' V0BILH-FONTE '  ' 'NRRCAP: ' WHOST-NRRCAP '  ' 'BILHETE: ' V0BILH-NUMBIL */

                $"FONTE: {V0BILH_FONTE}  NRRCAP: {WHOST_NRRCAP}  BILHETE: {V0BILH_NUMBIL}"
                .Display();

                /*" -2575- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2577- END-IF. */
            }


            /*" -2578- IF V0BILH-RAMO = 81 */

            if (V0BILH_RAMO == 81)
            {

                /*" -2580- IF WHOST-COUNT NOT LESS 5 */

                if (WHOST_COUNT >= 5)
                {

                    /*" -2581- MOVE '0' TO V0BILH-SITUACAO */
                    _.Move("0", V0BILH_SITUACAO);

                    /*" -2582- MOVE 834 TO V0BILER-COD-ERRO */
                    _.Move(834, V0BILER_COD_ERRO);

                    /*" -2583- PERFORM R3045-00-GRAVA-TAB-ERRO */

                    R3045_00_GRAVA_TAB_ERRO_SECTION();

                    /*" -2584- PERFORM R3020-00-UPDATE-V0BILHETE */

                    R3020_00_UPDATE_V0BILHETE_SECTION();

                    /*" -2586- GO TO R0420-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0420_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -2587- IF V0BILH-RAMO = 37 */

            if (V0BILH_RAMO == 37)
            {

                /*" -2589- IF WHOST-COUNT NOT LESS 2 */

                if (WHOST_COUNT >= 2)
                {

                    /*" -2590- MOVE '0' TO V0BILH-SITUACAO */
                    _.Move("0", V0BILH_SITUACAO);

                    /*" -2591- MOVE 834 TO V0BILER-COD-ERRO */
                    _.Move(834, V0BILER_COD_ERRO);

                    /*" -2592- PERFORM R3045-00-GRAVA-TAB-ERRO */

                    R3045_00_GRAVA_TAB_ERRO_SECTION();

                    /*" -2593- PERFORM R3020-00-UPDATE-V0BILHETE */

                    R3020_00_UPDATE_V0BILHETE_SECTION();

                    /*" -2595- GO TO R0420-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0420_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -2597- IF VIND-DTNASC LESS ZEROES */

            if (VIND_DTNASC < 00)
            {

                /*" -2599- MOVE '0' TO V0BILH-SITUACAO */
                _.Move("0", V0BILH_SITUACAO);

                /*" -2600- MOVE 11001 TO V0BILER-COD-ERRO */
                _.Move(11001, V0BILER_COD_ERRO);

                /*" -2601- PERFORM R3045-00-GRAVA-TAB-ERRO */

                R3045_00_GRAVA_TAB_ERRO_SECTION();

                /*" -2602- PERFORM R3020-00-UPDATE-V0BILHETE */

                R3020_00_UPDATE_V0BILHETE_SECTION();

                /*" -2607- GO TO R0420-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0420_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2608- MOVE V0BILH-DTQITBCO TO WDATA-MOVABE */
            _.Move(V0BILH_DTQITBCO, AREA_DE_WORK.WDATA_MOVABE);

            /*" -2609- COMPUTE WDATA-AA-MOVABE = WDATA-AA-MOVABE + 1 */
            AREA_DE_WORK.WDATA_MOVABE.WDATA_AA_MOVABE.Value = AREA_DE_WORK.WDATA_MOVABE.WDATA_AA_MOVABE + 1;

            /*" -2610- MOVE V0CLIE-DTNASC TO WDATA-WORK */
            _.Move(V0CLIE_DTNASC, AREA_DE_WORK.WDATA_WORK);

            /*" -2612- COMPUTE WWORK-ANO-3 = WDATA-AA-MOVABE - WDATA-AA-WORK */
            AREA_DE_WORK.WWORK_ANO_3.Value = AREA_DE_WORK.WDATA_MOVABE.WDATA_AA_MOVABE - AREA_DE_WORK.WDATA_WORK.WDATA_AA_WORK;

            /*" -2613- IF WDATA-MM-MOVABE < WDATA-MM-WORK */

            if (AREA_DE_WORK.WDATA_MOVABE.WDATA_MM_MOVABE < AREA_DE_WORK.WDATA_WORK.WDATA_MM_WORK)
            {

                /*" -2614- SUBTRACT 1 FROM WWORK-ANO-3 */
                AREA_DE_WORK.WWORK_ANO_3.Value = AREA_DE_WORK.WWORK_ANO_3 - 1;

                /*" -2617- END-IF. */
            }


            /*" -2618- IF V0BILH-RAMO NOT EQUAL 69 */

            if (V0BILH_RAMO != 69)
            {

                /*" -2620- IF WWORK-ANO-3 LESS 16 */

                if (AREA_DE_WORK.WWORK_ANO_3 < 16)
                {

                    /*" -2621- MOVE 11101 TO V0BILER-COD-ERRO */
                    _.Move(11101, V0BILER_COD_ERRO);

                    /*" -2623- PERFORM R3045-00-GRAVA-TAB-ERRO */

                    R3045_00_GRAVA_TAB_ERRO_SECTION();

                    /*" -2624- MOVE '0' TO V0BILH-SITUACAO */
                    _.Move("0", V0BILH_SITUACAO);

                    /*" -2625- PERFORM R3020-00-UPDATE-V0BILHETE */

                    R3020_00_UPDATE_V0BILHETE_SECTION();

                    /*" -2626- GO TO R0420-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0420_99_SAIDA*/ //GOTO
                    return;

                    /*" -2628- END-IF. */
                }

            }


            /*" -2629- IF V0BILH-RAMO EQUAL 69 */

            if (V0BILH_RAMO == 69)
            {

                /*" -2630- IF WWORK-ANO-3 LESS 14 */

                if (AREA_DE_WORK.WWORK_ANO_3 < 14)
                {

                    /*" -2632- IF V0CLIE-CGCCPF EQUAL ZEROS */

                    if (V0CLIE_CGCCPF == 00)
                    {

                        /*" -2633- MOVE 10901 TO V0BILER-COD-ERRO */
                        _.Move(10901, V0BILER_COD_ERRO);

                        /*" -2635- PERFORM R3045-00-GRAVA-TAB-ERRO */

                        R3045_00_GRAVA_TAB_ERRO_SECTION();

                        /*" -2636- MOVE '0' TO V0BILH-SITUACAO */
                        _.Move("0", V0BILH_SITUACAO);

                        /*" -2637- PERFORM R3020-00-UPDATE-V0BILHETE */

                        R3020_00_UPDATE_V0BILHETE_SECTION();

                        /*" -2638- GO TO R0420-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0420_99_SAIDA*/ //GOTO
                        return;

                        /*" -2639- END-IF */
                    }


                    /*" -2644- END-IF. */
                }

            }


            /*" -2645- IF V0BILH-RAMO NOT EQUAL 69 */

            if (V0BILH_RAMO != 69)
            {

                /*" -2647- IF WWORK-ANO-3 GREATER 70 */

                if (AREA_DE_WORK.WWORK_ANO_3 > 70)
                {

                    /*" -2648- MOVE 11101 TO V0BILER-COD-ERRO */
                    _.Move(11101, V0BILER_COD_ERRO);

                    /*" -2650- PERFORM R3045-00-GRAVA-TAB-ERRO */

                    R3045_00_GRAVA_TAB_ERRO_SECTION();

                    /*" -2651- MOVE '0' TO V0BILH-SITUACAO */
                    _.Move("0", V0BILH_SITUACAO);

                    /*" -2652- PERFORM R3020-00-UPDATE-V0BILHETE */

                    R3020_00_UPDATE_V0BILHETE_SECTION();

                    /*" -2653- GO TO R0420-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0420_99_SAIDA*/ //GOTO
                    return;

                    /*" -2655- END-IF. */
                }

            }


            /*" -2656- IF V0BILH-RAMO EQUAL 69 */

            if (V0BILH_RAMO == 69)
            {

                /*" -2658- IF V1BILP-CODPRODU EQUAL 6907 OR 6915 OR JVPROD(6907) OR JVPROD(6915) */

                if (V1BILP_CODPRODU.In("6907", "6915", JVBKINCL.FILLER.JVPROD[6907].ToString(), JVBKINCL.FILLER.JVPROD[6915].ToString()))
                {

                    /*" -2660- IF WWORK-ANO-3 GREATER 46 */

                    if (AREA_DE_WORK.WWORK_ANO_3 > 46)
                    {

                        /*" -2661- MOVE 11101 TO V0BILER-COD-ERRO */
                        _.Move(11101, V0BILER_COD_ERRO);

                        /*" -2663- PERFORM R3045-00-GRAVA-TAB-ERRO */

                        R3045_00_GRAVA_TAB_ERRO_SECTION();

                        /*" -2664- MOVE '0' TO V0BILH-SITUACAO */
                        _.Move("0", V0BILH_SITUACAO);

                        /*" -2665- PERFORM R3020-00-UPDATE-V0BILHETE */

                        R3020_00_UPDATE_V0BILHETE_SECTION();

                        /*" -2666- GO TO R0420-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0420_99_SAIDA*/ //GOTO
                        return;

                        /*" -2667- END-IF */
                    }


                    /*" -2668- ELSE */
                }
                else
                {


                    /*" -2671- IF V1BILP-CODPRODU EQUAL 6902 OR 6908 OR 6916 OR 6910 OR JVPROD(6902) OR JVPROD(6908) OR JVPROD(6916) OR JVPROD(6910) */

                    if (V1BILP_CODPRODU.In("6902", "6908", "6916", "6910", JVBKINCL.FILLER.JVPROD[6902].ToString(), JVBKINCL.FILLER.JVPROD[6908].ToString(), JVBKINCL.FILLER.JVPROD[6916].ToString(), JVBKINCL.FILLER.JVPROD[6910].ToString()))
                    {

                        /*" -2673- IF WWORK-ANO-3 GREATER 70 */

                        if (AREA_DE_WORK.WWORK_ANO_3 > 70)
                        {

                            /*" -2674- MOVE 11101 TO V0BILER-COD-ERRO */
                            _.Move(11101, V0BILER_COD_ERRO);

                            /*" -2676- PERFORM R3045-00-GRAVA-TAB-ERRO */

                            R3045_00_GRAVA_TAB_ERRO_SECTION();

                            /*" -2677- MOVE '0' TO V0BILH-SITUACAO */
                            _.Move("0", V0BILH_SITUACAO);

                            /*" -2678- PERFORM R3020-00-UPDATE-V0BILHETE */

                            R3020_00_UPDATE_V0BILHETE_SECTION();

                            /*" -2679- GO TO R0420-99-SAIDA */
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: R0420_99_SAIDA*/ //GOTO
                            return;

                            /*" -2680- END-IF */
                        }


                        /*" -2681- ELSE */
                    }
                    else
                    {


                        /*" -2682- IF WWORK-ANO-3 GREATER 80 */

                        if (AREA_DE_WORK.WWORK_ANO_3 > 80)
                        {

                            /*" -2684- IF NOT ( V1BILP-CODPRODU = 6922 ) */

                            if (!(V1BILP_CODPRODU == 6922))
                            {

                                /*" -2685- MOVE 11101 TO V0BILER-COD-ERRO */
                                _.Move(11101, V0BILER_COD_ERRO);

                                /*" -2687- PERFORM R3045-00-GRAVA-TAB-ERRO */

                                R3045_00_GRAVA_TAB_ERRO_SECTION();

                                /*" -2688- MOVE '0' TO V0BILH-SITUACAO */
                                _.Move("0", V0BILH_SITUACAO);

                                /*" -2689- PERFORM R3020-00-UPDATE-V0BILHETE */

                                R3020_00_UPDATE_V0BILHETE_SECTION();

                                /*" -2690- GO TO R0420-99-SAIDA */
                                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0420_99_SAIDA*/ //GOTO
                                return;

                                /*" -2691- END-IF */
                            }


                            /*" -2692- END-IF */
                        }


                        /*" -2693- END-IF */
                    }


                    /*" -2694- END-IF */
                }


                /*" -2696- END-IF. */
            }


            /*" -2697- IF WS-SIVPF EQUAL 'S' */

            if (AREA_DE_WORK.WS_SIVPF == "S")
            {

                /*" -2700- GO TO R0420-10-CONTINUA. */

                R0420_10_CONTINUA(); //GOTO
                return;
            }


            /*" -2710- PERFORM R0420_00_ACUMULA_BILHETE_DB_SELECT_2 */

            R0420_00_ACUMULA_BILHETE_DB_SELECT_2();

            /*" -2713- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2715- GO TO R0420-10-CONTINUA. */

                R0420_10_CONTINUA(); //GOTO
                return;
            }


            /*" -2716- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2717- DISPLAY 'R0420-00 (ERRO - SELECT BILHETE_FAIXA)... ' */
                _.Display($"R0420-00 (ERRO - SELECT BILHETE_FAIXA)... ");

                /*" -2718- DISPLAY 'BILHETE ' V0BILH-NUMBIL */
                _.Display($"BILHETE {V0BILH_NUMBIL}");

                /*" -2720- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2721- IF V0BILFX-VERSAO NOT EQUAL 01 */

            if (V0BILFX_VERSAO != 01)
            {

                /*" -2723- MOVE V1RCAC-DATARCAP TO V0BILH-DTQITBCO. */
                _.Move(V1RCAC_DATARCAP, V0BILH_DTQITBCO);
            }


            /*" -2725- IF V0BILH-DTQITBCO NOT EQUAL V1RCAC-DATARCAP */

            if (V0BILH_DTQITBCO != V1RCAC_DATARCAP)
            {

                /*" -2726- MOVE '0' TO V0BILH-SITUACAO */
                _.Move("0", V0BILH_SITUACAO);

                /*" -2727- PERFORM R3040-00-MONTA-V0BILHETE */

                R3040_00_MONTA_V0BILHETE_SECTION();

                /*" -2728- PERFORM R3020-00-UPDATE-V0BILHETE */

                R3020_00_UPDATE_V0BILHETE_SECTION();

                /*" -2728- GO TO R0420-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0420_99_SAIDA*/ //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM R0420_10_CONTINUA */

            R0420_10_CONTINUA();

        }

        [StopWatch]
        /*" R0420-00-ACUMULA-BILHETE-DB-SELECT-1 */
        public void R0420_00_ACUMULA_BILHETE_DB_SELECT_1()
        {
            /*" -2567- EXEC SQL SELECT COUNT(*) INTO :WHOST-COUNT FROM SEGUROS.CLIENTES A, SEGUROS.BILHETE B, SEGUROS.ENDOSSOS C WHERE A.CGCCPF = :V0CLIE-CGCCPF AND B.COD_CLIENTE = A.COD_CLIENTE AND B.SITUACAO = '9' AND C.NUM_APOLICE = B.NUM_APOLICE AND C.COD_PRODUTO IN ( :WHOST-PROD-MENSAL , :WHOST-PROD-PUANTE ) AND C.NUM_ENDOSSO = 0 AND C.DATA_TERVIGENCIA >= :V1SIST-DTMOVABE WITH UR END-EXEC */

            var r0420_00_ACUMULA_BILHETE_DB_SELECT_1_Query1 = new R0420_00_ACUMULA_BILHETE_DB_SELECT_1_Query1()
            {
                WHOST_PROD_MENSAL = WHOST_PROD_MENSAL.ToString(),
                WHOST_PROD_PUANTE = WHOST_PROD_PUANTE.ToString(),
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
                V0CLIE_CGCCPF = V0CLIE_CGCCPF.ToString(),
            };

            var executed_1 = R0420_00_ACUMULA_BILHETE_DB_SELECT_1_Query1.Execute(r0420_00_ACUMULA_BILHETE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_COUNT, WHOST_COUNT);
            }


        }

        [StopWatch]
        /*" R0420-10-CONTINUA */
        private void R0420_10_CONTINUA(bool isPerform = false)
        {
            /*" -2736- COMPUTE WS-VALORDIF EQUAL V0BILH-VLRCAP - V2RCAP-VLRCAP. */
            AREA_DE_WORK.WS_VALORDIF.Value = V0BILH_VLRCAP - V2RCAP_VLRCAP;

            /*" -2737- IF WS-VALORDIF LESS ZEROS */

            if (AREA_DE_WORK.WS_VALORDIF < 00)
            {

                /*" -2740- COMPUTE WS-VALORDIF EQUAL WS-VALORDIF * -1. */
                AREA_DE_WORK.WS_VALORDIF.Value = AREA_DE_WORK.WS_VALORDIF * -1;
            }


            /*" -2742- IF WS-VALORDIF GREATER WS-VLDIFE */

            if (AREA_DE_WORK.WS_VALORDIF > AREA_DE_WORK.WS_VLDIFE)
            {

                /*" -2743- MOVE '0' TO V0BILH-SITUACAO */
                _.Move("0", V0BILH_SITUACAO);

                /*" -2744- PERFORM R3040-00-MONTA-V0BILHETE */

                R3040_00_MONTA_V0BILHETE_SECTION();

                /*" -2745- PERFORM R3020-00-UPDATE-V0BILHETE */

                R3020_00_UPDATE_V0BILHETE_SECTION();

                /*" -2764- MOVE 9999 TO V0BILER-COD-ERRO. */
                _.Move(9999, V0BILER_COD_ERRO);
            }


            /*" -2765- IF V0BILH-NUM-APO-ANT EQUAL ZEROS */

            if (V0BILH_NUM_APO_ANT == 00)
            {

                /*" -2766- MOVE 1 TO WS-COD-CRITICA */
                _.Move(1, WS_COD_CRITICA);

                /*" -2768- PERFORM R7100-00-CONS-COD-CRITICA */

                R7100_00_CONS_COD_CRITICA_SECTION();

                /*" -2769- IF VG001-IND-EXISTE EQUAL 'N' */

                if (SPVG001V.VG001_IND_EXISTE == "N")
                {

                    /*" -2770- PERFORM P7000-00-PROCURA-RISCO-PROP */

                    P7000_00_PROCURA_RISCO_PROP_SECTION();

                    /*" -2772- ELSE */
                }
                else
                {


                    /*" -2773- IF LK-VG001-S-STA-CRITICA NOT EQUAL '6' */

                    if (SPVG001W.LK_VG001_S_STA_CRITICA != "6")
                    {

                        /*" -2777- DISPLAY 'BILHETE EM ANALISE DE CRITICA.......: ' V0BILH-NUMBIL ' >> ' V0CONV-NUM-PROPOSTA-SIVPF ' >> ' LK-VG001-S-STA-CRITICA */

                        $"BILHETE EM ANALISE DE CRITICA.......: {V0BILH_NUMBIL} >> {V0CONV_NUM_PROPOSTA_SIVPF} >> {SPVG001W.LK_VG001_S_STA_CRITICA}"
                        .Display();

                        /*" -2778- MOVE '1' TO V0BILH-SITUACAO */
                        _.Move("1", V0BILH_SITUACAO);

                        /*" -2779- ADD 1 TO WS-QT-EM-CRITICA */
                        WS_QT_EM_CRITICA.Value = WS_QT_EM_CRITICA + 1;

                        /*" -2780- PERFORM R3020-00-UPDATE-V0BILHETE */

                        R3020_00_UPDATE_V0BILHETE_SECTION();

                        /*" -2781- ELSE */
                    }
                    else
                    {


                        /*" -2784- DISPLAY 'LIBERADO PARA EMISSAO APOS ANALISE..: ' V0BILH-NUMBIL ' >> ' V0CONV-NUM-PROPOSTA-SIVPF */

                        $"LIBERADO PARA EMISSAO APOS ANALISE..: {V0BILH_NUMBIL} >> {V0CONV_NUM_PROPOSTA_SIVPF}"
                        .Display();

                        /*" -2785- ADD 1 TO WS-QT-LIBERADO-EMISSAO */
                        WS_QT_LIBERADO_EMISSAO.Value = WS_QT_LIBERADO_EMISSAO + 1;

                        /*" -2786- END-IF */
                    }


                    /*" -2787- END-IF */
                }


                /*" -2788- END-IF */
            }


            /*" -2788- . */

        }

        [StopWatch]
        /*" R0420-00-ACUMULA-BILHETE-DB-SELECT-2 */
        public void R0420_00_ACUMULA_BILHETE_DB_SELECT_2()
        {
            /*" -2710- EXEC SQL SELECT VERSAO_BIL , VALADT_IND + VALADT_GER + VALADT_SUN INTO :V0BILFX-VERSAO , :V0BILFX-VALADT FROM SEGUROS.BILHETE_FAIXA WHERE NUMBIL_INI <= :V0BILH-NUMBIL AND NUMBIL_FIM >= :V0BILH-NUMBIL END-EXEC. */

            var r0420_00_ACUMULA_BILHETE_DB_SELECT_2_Query1 = new R0420_00_ACUMULA_BILHETE_DB_SELECT_2_Query1()
            {
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            var executed_1 = R0420_00_ACUMULA_BILHETE_DB_SELECT_2_Query1.Execute(r0420_00_ACUMULA_BILHETE_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0BILFX_VERSAO, V0BILFX_VERSAO);
                _.Move(executed_1.V0BILFX_VALADT, V0BILFX_VALADT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0420_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-TRATA-APOLICE-SECTION */
        private void R0500_00_TRATA_APOLICE_SECTION()
        {
            /*" -2799- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2805- PERFORM R0500_00_TRATA_APOLICE_DB_SELECT_1 */

            R0500_00_TRATA_APOLICE_DB_SELECT_1();

            /*" -2808- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2809- DISPLAY 'R0500-00 (ERRO - SELECT V1NUMERO_AES)...' */
                _.Display($"R0500-00 (ERRO - SELECT V1NUMERO_AES)...");

                /*" -2811- DISPLAY 'ORGAO: ' V0APOL-ORGAO 'RAMO: ' V0BILH-RAMO */

                $"ORGAO: {V0APOL_ORGAO}RAMO: {V0BILH_RAMO}"
                .Display();

                /*" -2813- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2816- COMPUTE V0NAES-SEQ-APOL EQUAL (V1NAES-SEQ-APOL + 1). */
            V0NAES_SEQ_APOL.Value = (V1NAES_SEQ_APOL + 1);

            /*" -2817- MOVE V0CONV-NUM-PROPOSTA-SIVPF TO WWORK-NR-PROPOSTA. */
            _.Move(V0CONV_NUM_PROPOSTA_SIVPF, AREA_DE_WORK.WWORK_NR_PROPOSTA);

            /*" -2818- MOVE ZEROS TO WWORK-NUM-APOL. */
            _.Move(0, AREA_DE_WORK.WWORK_NUM_APOL);

            /*" -2819- MOVE 10 TO WWORK-ORG-APOL. */
            _.Move(10, AREA_DE_WORK.FILLER_2.WWORK_ORG_APOL);

            /*" -2820- MOVE V0BILH-RAMO TO WWORK-RMO-APOL. */
            _.Move(V0BILH_RAMO, AREA_DE_WORK.FILLER_2.WWORK_RMO_APOL);

            /*" -2821- MOVE V0NAES-SEQ-APOL TO WWORK-SEQ-APOL. */
            _.Move(V0NAES_SEQ_APOL, AREA_DE_WORK.FILLER_2.WWORK_SEQ_APOL);

            /*" -2823- MOVE WWORK-NUM-APOL TO V0APOL-NUM-APOL. */
            _.Move(AREA_DE_WORK.WWORK_NUM_APOL, V0APOL_NUM_APOL);

            /*" -2828- PERFORM R0500_00_TRATA_APOLICE_DB_UPDATE_1 */

            R0500_00_TRATA_APOLICE_DB_UPDATE_1();

            /*" -2831- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2832- DISPLAY 'R0500-00 (ERRO - UPDATE V0NUMERO_AES)...' */
                _.Display($"R0500-00 (ERRO - UPDATE V0NUMERO_AES)...");

                /*" -2834- DISPLAY 'ORGAO: ' V0APOL-ORGAO 'RAMO: ' WWORK-RAMO-ANT */

                $"ORGAO: {V0APOL_ORGAO}RAMO: {WWORK_RAMO_ANT}"
                .Display();

                /*" -2836- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2837- ADD +1 TO AC-U-V0NUMERAES. */
            AREA_DE_WORK.AC_U_V0NUMERAES.Value = AREA_DE_WORK.AC_U_V0NUMERAES + +1;

            /*" -2839- ADD +1 TO AC-U-V0FONTE. */
            AREA_DE_WORK.AC_U_V0FONTE.Value = AREA_DE_WORK.AC_U_V0FONTE + +1;

            /*" -2840- COMPUTE WWORK-IS-APOL = V1BILC-IMPSEG-IX * WWORK-NUM-ITENS. */
            AREA_DE_WORK.WWORK_IS_APOL.Value = V1BILC_IMPSEG_IX * AREA_DE_WORK.WWORK_NUM_ITENS;

            /*" -2842- COMPUTE WWORK-PR-APOL = V1BILC-PRMTAR-IX * WWORK-NUM-ITENS. */
            AREA_DE_WORK.WWORK_PR_APOL.Value = V1BILC_PRMTAR_IX * AREA_DE_WORK.WWORK_NUM_ITENS;

            /*" -2843- MOVE V0BILH-VLRCAP TO WWORK-PR-TOT. */
            _.Move(V0BILH_VLRCAP, AREA_DE_WORK.WWORK_PR_TOT);

            /*" -2844- MOVE V0BILH-CODCLIEN TO V0APOL-CODCLIEN. */
            _.Move(V0BILH_CODCLIEN, V0APOL_CODCLIEN);

            /*" -2845- MOVE WWORK-NUM-ITENS TO V0APOL-NUM-ITEM. */
            _.Move(AREA_DE_WORK.WWORK_NUM_ITENS, V0APOL_NUM_ITEM);

            /*" -2846- MOVE ZEROS TO V0APOL-MODALIDA. */
            _.Move(0, V0APOL_MODALIDA);

            /*" -2847- MOVE 10 TO V0APOL-ORGAO. */
            _.Move(10, V0APOL_ORGAO);

            /*" -2849- MOVE WWORK-RAMO-ANT TO V0APOL-RAMO. */
            _.Move(WWORK_RAMO_ANT, V0APOL_RAMO);

            /*" -2850- MOVE '1' TO V0APOL-TIPSGU. */
            _.Move("1", V0APOL_TIPSGU);

            /*" -2851- MOVE '2' TO V0APOL-TIPAPO. */
            _.Move("2", V0APOL_TIPAPO);

            /*" -2852- MOVE '3' TO V0APOL-TIPCALC. */
            _.Move("3", V0APOL_TIPCALC);

            /*" -2853- MOVE 'N' TO V0APOL-PODPUBL. */
            _.Move("N", V0APOL_PODPUBL);

            /*" -2854- MOVE ZEROS TO V0APOL-NUM-ATA. */
            _.Move(0, V0APOL_NUM_ATA);

            /*" -2855- MOVE ZEROS TO V0APOL-ANO-ATA. */
            _.Move(0, V0APOL_ANO_ATA);

            /*" -2856- MOVE SPACES TO V0APOL-IDEMAN. */
            _.Move("", V0APOL_IDEMAN);

            /*" -2857- MOVE ZEROS TO V0APOL-PCDESCON. */
            _.Move(0, V0APOL_PCDESCON);

            /*" -2858- MOVE ZEROS TO V0APOL-PCTCED. */
            _.Move(0, V0APOL_PCTCED);

            /*" -2859- MOVE '4' TO V0APOL-TPCOSCED. */
            _.Move("4", V0APOL_TPCOSCED);

            /*" -2860- MOVE ZEROS TO V0APOL-QTCOSSEG. */
            _.Move(0, V0APOL_QTCOSSEG);

            /*" -2861- MOVE ZEROS TO V0APOL-COD-EMPRESA. */
            _.Move(0, V0APOL_COD_EMPRESA);

            /*" -2864- MOVE '2' TO V0APOL-TPCORRET. */
            _.Move("2", V0APOL_TPCORRET);

            /*" -2881- PERFORM R0500_00_TRATA_APOLICE_DB_SELECT_2 */

            R0500_00_TRATA_APOLICE_DB_SELECT_2();

            /*" -2884- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2885- DISPLAY 'R0500-00 (ERRO - SELECT V0BILHETE_COBER)...' */
                _.Display($"R0500-00 (ERRO - SELECT V0BILHETE_COBER)...");

                /*" -2892- DISPLAY 'EMPR: ' V1BILC-COD-EMPR '  ' 'PROD: ' V1BILC-CODPRODU '  ' 'RAMO: ' V1BILC-RAMOFR '  ' 'MODA: ' V1BILC-MODALIFR '  ' 'OPCA: ' V1BILC-OPCAO '  ' 'DAT1: ' V0ENDO-DTINIVIG '  ' 'DAT2: ' V0ENDO-DTTERVIG */

                $"EMPR: {V1BILC_COD_EMPR}  PROD: {V1BILC_CODPRODU}  RAMO: {V1BILC_RAMOFR}  MODA: {V1BILC_MODALIFR}  OPCA: {V1BILC_OPCAO}  DAT1: {V0ENDO_DTINIVIG}  DAT2: {V0ENDO_DTTERVIG}"
                .Display();

                /*" -2894- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2896- MOVE 0 TO V1BILC-PCIOCC. */
            _.Move(0, V1BILC_PCIOCC);

            /*" -2905- PERFORM R0500_00_TRATA_APOLICE_DB_SELECT_3 */

            R0500_00_TRATA_APOLICE_DB_SELECT_3();

            /*" -2908- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2909- DISPLAY 'R0500-00 (ERRO - SELECT RAMOCOMP)          ' */
                _.Display($"R0500-00 (ERRO - SELECT RAMOCOMP)          ");

                /*" -2911- DISPLAY 'RAMO: ' V1BILC-RAMOFR '  ' 'DATA: ' V0BILH-DTQITBCO */

                $"RAMO: {V1BILC_RAMOFR}  DATA: {V0BILH_DTQITBCO}"
                .Display();

                /*" -2913- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2916- MOVE RAMOCOMP-PCT-IOCC-RAMO TO V1BILC-PCIOCC. */
            _.Move(RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_PCT_IOCC_RAMO, V1BILC_PCIOCC);

            /*" -2917- MOVE V1BILC-PCIOCC TO V0APOL-PCIOCC. */
            _.Move(V1BILC_PCIOCC, V0APOL_PCIOCC);

            /*" -2925- MOVE V1BILP-CODPRODU TO V0APOL-CODPRODU. */
            _.Move(V1BILP_CODPRODU, V0APOL_CODPRODU);

            /*" -2928- COMPUTE WWORK-IOCC ROUNDED = WWORK-PR-TOT * V1BILC-PCIOCC / 100. */
            AREA_DE_WORK.WWORK_IOCC.Value = AREA_DE_WORK.WWORK_PR_TOT * V1BILC_PCIOCC / 100f;

            /*" -2930- COMPUTE WWORK-PR-APOL = WWORK-PR-TOT - WWORK-IOCC. */
            AREA_DE_WORK.WWORK_PR_APOL.Value = AREA_DE_WORK.WWORK_PR_TOT - AREA_DE_WORK.WWORK_IOCC;

            /*" -2933- MOVE WWORK-PR-APOL TO V1BILC-PRMTAR-IX. */
            _.Move(AREA_DE_WORK.WWORK_PR_APOL, V1BILC_PRMTAR_IX);

            /*" -2985- PERFORM R0500_00_TRATA_APOLICE_DB_INSERT_1 */

            R0500_00_TRATA_APOLICE_DB_INSERT_1();

            /*" -2988- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2989- DISPLAY 'R0500-00 (PROBLEMAS INSERT APOLICES) ... ' */
                _.Display($"R0500-00 (PROBLEMAS INSERT APOLICES) ... ");

                /*" -2991- DISPLAY 'APOLICE: ' V0APOL-NUM-APOL '  ' 'OPCAO: ' WWORK-OPCAO-ANT */

                $"APOLICE: {V0APOL_NUM_APOL}  OPCAO: {WWORK_OPCAO_ANT}"
                .Display();

                /*" -2993- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2996- ADD +1 TO AC-I-V0APOLICE. */
            AREA_DE_WORK.AC_I_V0APOLICE.Value = AREA_DE_WORK.AC_I_V0APOLICE + +1;

            /*" -2998- MOVE '9' TO V0BILH-SITUACAO. */
            _.Move("9", V0BILH_SITUACAO);

            /*" -3005- PERFORM R0500_00_TRATA_APOLICE_DB_UPDATE_2 */

            R0500_00_TRATA_APOLICE_DB_UPDATE_2();

            /*" -3008- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3009- DISPLAY 'R0500-00 (ERRO - UPDATE V0BILHETE)...' */
                _.Display($"R0500-00 (ERRO - UPDATE V0BILHETE)...");

                /*" -3010- DISPLAY 'BILHETE: ' V0BILH-NUMBIL '  ' */

                $"BILHETE: {V0BILH_NUMBIL}  "
                .Display();

                /*" -3010- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0500-00-TRATA-APOLICE-DB-SELECT-1 */
        public void R0500_00_TRATA_APOLICE_DB_SELECT_1()
        {
            /*" -2805- EXEC SQL SELECT SEQ_APOLICE INTO :V1NAES-SEQ-APOL FROM SEGUROS.V1NUMERO_AES WHERE COD_ORGAO = :V0APOL-ORGAO AND COD_RAMO = :V0BILH-RAMO END-EXEC. */

            var r0500_00_TRATA_APOLICE_DB_SELECT_1_Query1 = new R0500_00_TRATA_APOLICE_DB_SELECT_1_Query1()
            {
                V0APOL_ORGAO = V0APOL_ORGAO.ToString(),
                V0BILH_RAMO = V0BILH_RAMO.ToString(),
            };

            var executed_1 = R0500_00_TRATA_APOLICE_DB_SELECT_1_Query1.Execute(r0500_00_TRATA_APOLICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1NAES_SEQ_APOL, V1NAES_SEQ_APOL);
            }


        }

        [StopWatch]
        /*" R0500-00-TRATA-APOLICE-DB-UPDATE-1 */
        public void R0500_00_TRATA_APOLICE_DB_UPDATE_1()
        {
            /*" -2828- EXEC SQL UPDATE SEGUROS.V0NUMERO_AES SET SEQ_APOLICE = :V0NAES-SEQ-APOL WHERE COD_ORGAO = :V0APOL-ORGAO AND COD_RAMO = :WWORK-RAMO-ANT END-EXEC. */

            var r0500_00_TRATA_APOLICE_DB_UPDATE_1_Update1 = new R0500_00_TRATA_APOLICE_DB_UPDATE_1_Update1()
            {
                V0NAES_SEQ_APOL = V0NAES_SEQ_APOL.ToString(),
                WWORK_RAMO_ANT = WWORK_RAMO_ANT.ToString(),
                V0APOL_ORGAO = V0APOL_ORGAO.ToString(),
            };

            R0500_00_TRATA_APOLICE_DB_UPDATE_1_Update1.Execute(r0500_00_TRATA_APOLICE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-TRATA-APOLICE-DB-SELECT-2 */
        public void R0500_00_TRATA_APOLICE_DB_SELECT_2()
        {
            /*" -2881- EXEC SQL SELECT CODUNIMO, PCCOMCOR, PCIOCC, VALMAX_COBERBAS INTO :V1BILC-CODUNIMO, :V1BILC-PCCOMCOR, :V1BILC-PCIOCC, :V1BILC-VALMAX FROM SEGUROS.V0BILHETE_COBER WHERE RAMOFR = :V1BILC-RAMOFR AND MODALIFR = :V1BILC-MODALIFR AND COD_OPCAO = :V1BILC-OPCAO AND PCCOMCOR > 0 AND IDE_COBERTURA = '1' FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0500_00_TRATA_APOLICE_DB_SELECT_2_Query1 = new R0500_00_TRATA_APOLICE_DB_SELECT_2_Query1()
            {
                V1BILC_MODALIFR = V1BILC_MODALIFR.ToString(),
                V1BILC_RAMOFR = V1BILC_RAMOFR.ToString(),
                V1BILC_OPCAO = V1BILC_OPCAO.ToString(),
            };

            var executed_1 = R0500_00_TRATA_APOLICE_DB_SELECT_2_Query1.Execute(r0500_00_TRATA_APOLICE_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1BILC_CODUNIMO, V1BILC_CODUNIMO);
                _.Move(executed_1.V1BILC_PCCOMCOR, V1BILC_PCCOMCOR);
                _.Move(executed_1.V1BILC_PCIOCC, V1BILC_PCIOCC);
                _.Move(executed_1.V1BILC_VALMAX, V1BILC_VALMAX);
            }


        }

        [StopWatch]
        /*" R0500-00-TRATA-APOLICE-DB-INSERT-1 */
        public void R0500_00_TRATA_APOLICE_DB_INSERT_1()
        {
            /*" -2985- EXEC SQL INSERT INTO SEGUROS.V0APOLICE (CODCLIEN , NUM_APOLICE , NUM_ITEM , MODALIDA , ORGAO , RAMO , NUM_APOL_ANTERIOR , NUMBIL , TIPSGU , TIPAPO , TIPCALC , PODPUBL , NUM_ATA , ANO_ATA , IDEMAN , PCDESCON , PCIOCC , TPCOSCED , QTCOSSEG , PCTCED , DATA_SORTEIO , COD_EMPRESA , TIMESTAMP , CODPRODU , TPCORRET) VALUES (:V0APOL-CODCLIEN , :V0APOL-NUM-APOL , :V0APOL-NUM-ITEM , :V0APOL-MODALIDA , :V0APOL-ORGAO , :V0APOL-RAMO , :V0APOL-NUM-APO-ANT , :V0APOL-NUMBIL , :V0APOL-TIPSGU , :V0APOL-TIPAPO , :V0APOL-TIPCALC , :V0APOL-PODPUBL , :V0APOL-NUM-ATA , :V0APOL-ANO-ATA , :V0APOL-IDEMAN , :V0APOL-PCDESCON , :V0APOL-PCIOCC , :V0APOL-TPCOSCED , :V0APOL-QTCOSSEG , :V0APOL-PCTCED , NULL , :V0APOL-COD-EMPRESA , CURRENT TIMESTAMP , :V0APOL-CODPRODU , :V0APOL-TPCORRET) END-EXEC. */

            var r0500_00_TRATA_APOLICE_DB_INSERT_1_Insert1 = new R0500_00_TRATA_APOLICE_DB_INSERT_1_Insert1()
            {
                V0APOL_CODCLIEN = V0APOL_CODCLIEN.ToString(),
                V0APOL_NUM_APOL = V0APOL_NUM_APOL.ToString(),
                V0APOL_NUM_ITEM = V0APOL_NUM_ITEM.ToString(),
                V0APOL_MODALIDA = V0APOL_MODALIDA.ToString(),
                V0APOL_ORGAO = V0APOL_ORGAO.ToString(),
                V0APOL_RAMO = V0APOL_RAMO.ToString(),
                V0APOL_NUM_APO_ANT = V0APOL_NUM_APO_ANT.ToString(),
                V0APOL_NUMBIL = V0APOL_NUMBIL.ToString(),
                V0APOL_TIPSGU = V0APOL_TIPSGU.ToString(),
                V0APOL_TIPAPO = V0APOL_TIPAPO.ToString(),
                V0APOL_TIPCALC = V0APOL_TIPCALC.ToString(),
                V0APOL_PODPUBL = V0APOL_PODPUBL.ToString(),
                V0APOL_NUM_ATA = V0APOL_NUM_ATA.ToString(),
                V0APOL_ANO_ATA = V0APOL_ANO_ATA.ToString(),
                V0APOL_IDEMAN = V0APOL_IDEMAN.ToString(),
                V0APOL_PCDESCON = V0APOL_PCDESCON.ToString(),
                V0APOL_PCIOCC = V0APOL_PCIOCC.ToString(),
                V0APOL_TPCOSCED = V0APOL_TPCOSCED.ToString(),
                V0APOL_QTCOSSEG = V0APOL_QTCOSSEG.ToString(),
                V0APOL_PCTCED = V0APOL_PCTCED.ToString(),
                V0APOL_COD_EMPRESA = V0APOL_COD_EMPRESA.ToString(),
                V0APOL_CODPRODU = V0APOL_CODPRODU.ToString(),
                V0APOL_TPCORRET = V0APOL_TPCORRET.ToString(),
            };

            R0500_00_TRATA_APOLICE_DB_INSERT_1_Insert1.Execute(r0500_00_TRATA_APOLICE_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R0520-00-MONTA-ENDOSSO-ZERO-SECTION */
        private void R0520_00_MONTA_ENDOSSO_ZERO_SECTION()
        {
            /*" -3026- MOVE '0520' TO WNR-EXEC-SQL. */
            _.Move("0520", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3027- MOVE V0APOL-NUM-APOL TO V0ENDO-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0ENDO_NUM_APOL);

            /*" -3028- MOVE ZEROS TO V0ENDO-NRENDOS */
            _.Move(0, V0ENDO_NRENDOS);

            /*" -3029- MOVE ZEROS TO V0ENDO-CODSUBES */
            _.Move(0, V0ENDO_CODSUBES);

            /*" -3030- MOVE V0BILH-FONTE TO V0ENDO-FONTE */
            _.Move(V0BILH_FONTE, V0ENDO_FONTE);

            /*" -3031- MOVE V1FONT-PROPAUTOM TO V0ENDO-NRPROPOS */
            _.Move(V1FONT_PROPAUTOM, V0ENDO_NRPROPOS);

            /*" -3032- MOVE V1SIST-DTMOVACB TO V0ENDO-DT-LIBER */
            _.Move(V1SIST_DTMOVACB, V0ENDO_DT_LIBER);

            /*" -3033- MOVE V1SIST-DTMOVACB TO V0ENDO-DTEMIS */
            _.Move(V1SIST_DTMOVACB, V0ENDO_DTEMIS);

            /*" -3035- MOVE 104 TO V0ENDO-BCORCAP V0ENDO-BCOCOBR. */
            _.Move(104, V0ENDO_BCORCAP, V0ENDO_BCOCOBR);

            /*" -3036- MOVE V0BILH-AGECOBR TO V0ENDO-AGERCAP. */
            _.Move(V0BILH_AGECOBR, V0ENDO_AGERCAP);

            /*" -3037- MOVE ZEROS TO V0ENDO-AGECOBR. */
            _.Move(0, V0ENDO_AGECOBR);

            /*" -3038- MOVE '0' TO V0ENDO-DACCOBR */
            _.Move("0", V0ENDO_DACCOBR);

            /*" -3039- MOVE ZEROS TO V0ENDO-NRRCAP */
            _.Move(0, V0ENDO_NRRCAP);

            /*" -3040- MOVE ZEROS TO V0ENDO-VLRCAP. */
            _.Move(0, V0ENDO_VLRCAP);

            /*" -3041- MOVE '0' TO V0ENDO-DACRCAP */
            _.Move("0", V0ENDO_DACRCAP);

            /*" -3042- MOVE '0' TO V0ENDO-IDRCAP */
            _.Move("0", V0ENDO_IDRCAP);

            /*" -3043- MOVE V0BILH-DTQITBCO TO V0ENDO-DATARCAP */
            _.Move(V0BILH_DTQITBCO, V0ENDO_DATARCAP);

            /*" -3044- MOVE +0 TO VIND-DATARCAP. */
            _.Move(+0, VIND_DATARCAP);

            /*" -3045- MOVE WWORK-MIN-DTINIVIG TO V0ENDO-DTINIVIG. */
            _.Move(WWORK_MIN_DTINIVIG, V0ENDO_DTINIVIG);

            /*" -3046- MOVE WWORK-MIN-DTINIVIG TO WWORK-MIN-DTINIVIG-COB. */
            _.Move(WWORK_MIN_DTINIVIG, WWORK_MIN_DTINIVIG_COB);

            /*" -3047- MOVE WWORK-MIN-DTINIVIG TO V0ENDO-DATPRO. */
            _.Move(WWORK_MIN_DTINIVIG, V0ENDO_DATPRO);

            /*" -3048- MOVE WWORK-MAX-DTTERVIG TO V0ENDO-DTTERVIG. */
            _.Move(WWORK_MAX_DTTERVIG, V0ENDO_DTTERVIG);

            /*" -3049- MOVE WWORK-MAX-DTTERVIG TO WWORK-MAX-DTTERVIG-COB. */
            _.Move(WWORK_MAX_DTTERVIG, WWORK_MAX_DTTERVIG_COB);

            /*" -3050- MOVE ZEROS TO V0ENDO-PCENTRAD */
            _.Move(0, V0ENDO_PCENTRAD);

            /*" -3051- MOVE ZEROS TO V0ENDO-PCADICIO */
            _.Move(0, V0ENDO_PCADICIO);

            /*" -3052- MOVE ZEROS TO V0ENDO-PRESTA1 */
            _.Move(0, V0ENDO_PRESTA1);

            /*" -3053- MOVE ZEROS TO V0ENDO-QTPARCEL */
            _.Move(0, V0ENDO_QTPARCEL);

            /*" -3054- MOVE ZEROS TO V0ENDO-CDFRACIO */
            _.Move(0, V0ENDO_CDFRACIO);

            /*" -3055- MOVE ZEROS TO V0ENDO-QTPRESTA */
            _.Move(0, V0ENDO_QTPRESTA);

            /*" -3056- MOVE 1 TO V0ENDO-QTITENS */
            _.Move(1, V0ENDO_QTITENS);

            /*" -3057- MOVE SPACES TO V0ENDO-CODTXT */
            _.Move("", V0ENDO_CODTXT);

            /*" -3058- MOVE ZEROS TO V0ENDO-CDACEITA */
            _.Move(0, V0ENDO_CDACEITA);

            /*" -3060- MOVE V1BILC-CODUNIMO TO V0ENDO-MOEDA-IMP V0ENDO-MOEDA-PRM. */
            _.Move(V1BILC_CODUNIMO, V0ENDO_MOEDA_IMP, V0ENDO_MOEDA_PRM);

            /*" -3061- MOVE '0' TO V0ENDO-TIPO-ENDO */
            _.Move("0", V0ENDO_TIPO_ENDO);

            /*" -3062- MOVE 'BI8005B' TO V0ENDO-COD-USUAR */
            _.Move("BI8005B", V0ENDO_COD_USUAR);

            /*" -3063- MOVE 1 TO V0ENDO-OCORR-END. */
            _.Move(1, V0ENDO_OCORR_END);

            /*" -3064- MOVE ZEROS TO V0ENDO-COD-EMPRESA */
            _.Move(0, V0ENDO_COD_EMPRESA);

            /*" -3065- MOVE '1' TO V0ENDO-CORRECAO */
            _.Move("1", V0ENDO_CORRECAO);

            /*" -3066- MOVE 'S' TO V0ENDO-ISENTA-CST */
            _.Move("S", V0ENDO_ISENTA_CST);

            /*" -3067- MOVE -1 TO VIND-DTVENCTO */
            _.Move(-1, VIND_DTVENCTO);

            /*" -3068- MOVE -1 TO VIND-VLCUSEMI */
            _.Move(-1, VIND_VLCUSEMI);

            /*" -3069- MOVE -1 TO VIND-CFPREFIX. */
            _.Move(-1, VIND_CFPREFIX);

            /*" -3070- MOVE V0APOL-RAMO TO V0ENDO-RAMO. */
            _.Move(V0APOL_RAMO, V0ENDO_RAMO);

            /*" -3071- MOVE V0APOL-CODPRODU TO V0ENDO-CODPRODU. */
            _.Move(V0APOL_CODPRODU, V0ENDO_CODPRODU);

            /*" -3077- MOVE '0' TO V0ENDO-SITUACAO. */
            _.Move("0", V0ENDO_SITUACAO);

            /*" -3078- IF V0BILH-RAMO EQUAL 69 */

            if (V0BILH_RAMO == 69)
            {

                /*" -3080- MOVE W-DATA-INI-VIG-VIAGEM TO WWORK-MIN-DTINIVIG WHOST-DTINIVIG */
                _.Move(AREA_DE_WORK.WWORK_VIGENCIA_VIAGEM.W_DATA_INI_VIG_VIAGEM, WWORK_MIN_DTINIVIG, WHOST_DTINIVIG);

                /*" -3082- MOVE W-DATA-FIM-VIG-VIAGEM TO WWORK-MAX-DTTERVIG WHOST-DTTERVIG */
                _.Move(AREA_DE_WORK.WWORK_VIGENCIA_VIAGEM.W_DATA_FIM_VIG_VIAGEM, WWORK_MAX_DTTERVIG, WHOST_DTTERVIG);

                /*" -3083- MOVE WWORK-MIN-DTINIVIG TO V0ENDO-DTINIVIG */
                _.Move(WWORK_MIN_DTINIVIG, V0ENDO_DTINIVIG);

                /*" -3084- MOVE WWORK-MIN-DTINIVIG TO WWORK-MIN-DTINIVIG-COB */
                _.Move(WWORK_MIN_DTINIVIG, WWORK_MIN_DTINIVIG_COB);

                /*" -3085- MOVE WWORK-MAX-DTTERVIG TO V0ENDO-DTTERVIG */
                _.Move(WWORK_MAX_DTTERVIG, V0ENDO_DTTERVIG);

                /*" -3088- MOVE WWORK-MAX-DTTERVIG TO WWORK-MAX-DTTERVIG-COB. */
                _.Move(WWORK_MAX_DTTERVIG, WWORK_MAX_DTTERVIG_COB);
            }


            /*" -3094- PERFORM R0530-00-INCLUI-ENDOSSO. */

            R0530_00_INCLUI_ENDOSSO_SECTION();

            /*" -3095- MOVE V0ENDO-NUM-APOL TO V0PARC-NUM-APOL */
            _.Move(V0ENDO_NUM_APOL, V0PARC_NUM_APOL);

            /*" -3096- MOVE V0ENDO-NRENDOS TO V0PARC-NRENDOS */
            _.Move(V0ENDO_NRENDOS, V0PARC_NRENDOS);

            /*" -3097- MOVE ZEROS TO V0PARC-NRPARCEL */
            _.Move(0, V0PARC_NRPARCEL);

            /*" -3098- MOVE '0' TO V0PARC-DACPARC */
            _.Move("0", V0PARC_DACPARC);

            /*" -3099- MOVE V0BILH-FONTE TO V0PARC-FONTE */
            _.Move(V0BILH_FONTE, V0PARC_FONTE);

            /*" -3100- MOVE ZEROS TO V0PARC-NRTIT */
            _.Move(0, V0PARC_NRTIT);

            /*" -3101- MOVE ZEROS TO V0PARC-PRM-TAR-IX */
            _.Move(0, V0PARC_PRM_TAR_IX);

            /*" -3102- MOVE ZEROS TO V0PARC-VAL-DES-IX */
            _.Move(0, V0PARC_VAL_DES_IX);

            /*" -3103- MOVE ZEROS TO V0PARC-OTNPRLIQ */
            _.Move(0, V0PARC_OTNPRLIQ);

            /*" -3104- MOVE ZEROS TO V0PARC-OTNADFRA */
            _.Move(0, V0PARC_OTNADFRA);

            /*" -3105- MOVE ZEROS TO V0PARC-OTNCUSTO */
            _.Move(0, V0PARC_OTNCUSTO);

            /*" -3106- MOVE ZEROS TO V0PARC-OTNIOF. */
            _.Move(0, V0PARC_OTNIOF);

            /*" -3107- MOVE ZEROS TO V0PARC-OTNTOTAL. */
            _.Move(0, V0PARC_OTNTOTAL);

            /*" -3108- COMPUTE V0PARC-OTNTOTAL = V0PARC-OTNPRLIQ */
            V0PARC_OTNTOTAL.Value = V0PARC_OTNPRLIQ;

            /*" -3109- MOVE 1 TO V0PARC-OCORHIST */
            _.Move(1, V0PARC_OCORHIST);

            /*" -3110- MOVE ZEROS TO V0PARC-QTDDOC */
            _.Move(0, V0PARC_QTDDOC);

            /*" -3111- MOVE '0' TO V0PARC-SITUACAO */
            _.Move("0", V0PARC_SITUACAO);

            /*" -3114- MOVE ZEROS TO V0PARC-COD-EMPRESA. */
            _.Move(0, V0PARC_COD_EMPRESA);

            /*" -3120- PERFORM R0540-00-INCLUI-PARCELAS. */

            R0540_00_INCLUI_PARCELAS_SECTION();

            /*" -3121- MOVE V0PARC-NUM-APOL TO V0HISP-NUM-APOL */
            _.Move(V0PARC_NUM_APOL, V0HISP_NUM_APOL);

            /*" -3122- MOVE V0PARC-NRENDOS TO V0HISP-NRENDOS */
            _.Move(V0PARC_NRENDOS, V0HISP_NRENDOS);

            /*" -3123- MOVE V0PARC-NRPARCEL TO V0HISP-NRPARCEL */
            _.Move(V0PARC_NRPARCEL, V0HISP_NRPARCEL);

            /*" -3124- MOVE '0' TO V0HISP-DACPARC */
            _.Move("0", V0HISP_DACPARC);

            /*" -3125- MOVE 0101 TO V0HISP-OPERACAO */
            _.Move(0101, V0HISP_OPERACAO);

            /*" -3127- MOVE V1SIST-DTMOVACB TO V0HISP-DTMOVTO */
            _.Move(V1SIST_DTMOVACB, V0HISP_DTMOVTO);

            /*" -3128- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_TIME);

            /*" -3129- MOVE WS000-H TO WS000-HT */
            _.Move(WS_TIME.WS000_H, WS000_HORA_TIME_REDF.WS000_HT);

            /*" -3130- MOVE WS000-M TO WS000-MT */
            _.Move(WS_TIME.WS000_M, WS000_HORA_TIME_REDF.WS000_MT);

            /*" -3131- MOVE WS000-S TO WS000-ST */
            _.Move(WS_TIME.WS000_S, WS000_HORA_TIME_REDF.WS000_ST);

            /*" -3133- MOVE WS000-HORA-TIME TO V0HISP-HORAOPER. */
            _.Move(WS000_HORA_TIME, V0HISP_HORAOPER);

            /*" -3135- MOVE V0PARC-OCORHIST TO V0HISP-OCORHIST. */
            _.Move(V0PARC_OCORHIST, V0HISP_OCORHIST);

            /*" -3136- MOVE ZEROS TO V0HISP-PRM-TARIFA */
            _.Move(0, V0HISP_PRM_TARIFA);

            /*" -3137- MOVE ZEROS TO V0HISP-VAL-DESCON */
            _.Move(0, V0HISP_VAL_DESCON);

            /*" -3138- MOVE ZEROS TO V0HISP-VLPRMLIQ */
            _.Move(0, V0HISP_VLPRMLIQ);

            /*" -3139- MOVE ZEROS TO V0HISP-VLADIFRA */
            _.Move(0, V0HISP_VLADIFRA);

            /*" -3140- MOVE ZEROS TO V0HISP-VLCUSEMI */
            _.Move(0, V0HISP_VLCUSEMI);

            /*" -3141- MOVE ZEROS TO V0HISP-VLIOCC */
            _.Move(0, V0HISP_VLIOCC);

            /*" -3142- MOVE ZEROS TO V0HISP-VLPRMTOT */
            _.Move(0, V0HISP_VLPRMTOT);

            /*" -3143- MOVE ZEROS TO V0HISP-VLPREMIO */
            _.Move(0, V0HISP_VLPREMIO);

            /*" -3144- MOVE V1SIST-DTMOVACB TO V0HISP-DTVENCTO */
            _.Move(V1SIST_DTMOVACB, V0HISP_DTVENCTO);

            /*" -3145- MOVE 104 TO V0HISP-BCOCOBR */
            _.Move(104, V0HISP_BCOCOBR);

            /*" -3146- MOVE V0ENDO-AGECOBR TO V0HISP-AGECOBR */
            _.Move(V0ENDO_AGECOBR, V0HISP_AGECOBR);

            /*" -3147- MOVE ZEROS TO V0HISP-NRAVISO */
            _.Move(0, V0HISP_NRAVISO);

            /*" -3148- MOVE ZEROS TO V0HISP-NRENDOCA */
            _.Move(0, V0HISP_NRENDOCA);

            /*" -3149- MOVE '0' TO V0HISP-SITCONTB */
            _.Move("0", V0HISP_SITCONTB);

            /*" -3150- MOVE 'BI8005B' TO V0HISP-COD-USUAR */
            _.Move("BI8005B", V0HISP_COD_USUAR);

            /*" -3152- MOVE ZEROS TO V0HISP-RNUDOC */
            _.Move(0, V0HISP_RNUDOC);

            /*" -3154- MOVE -1 TO VIND-DTQITBCO */
            _.Move(-1, VIND_DTQITBCO);

            /*" -3157- MOVE ZEROS TO V0HISP-COD-EMPRESA. */
            _.Move(0, V0HISP_COD_EMPRESA);

            /*" -3163- PERFORM R0550-00-INSERT-V0HISTOPARC. */

            R0550_00_INSERT_V0HISTOPARC_SECTION();

            /*" -3164- MOVE V0ENDO-NUM-APOL TO V0COBA-NUM-APOL. */
            _.Move(V0ENDO_NUM_APOL, V0COBA_NUM_APOL);

            /*" -3165- MOVE V0ENDO-NRENDOS TO V0COBA-NRENDOS. */
            _.Move(V0ENDO_NRENDOS, V0COBA_NRENDOS);

            /*" -3166- MOVE ZEROS TO V0COBA-NUM-ITEM */
            _.Move(0, V0COBA_NUM_ITEM);

            /*" -3167- MOVE ZEROS TO V0COBA-OCORHIST */
            _.Move(0, V0COBA_OCORHIST);

            /*" -3168- MOVE WWORK-RAMO-ANT TO V0COBA-RAMOFR. */
            _.Move(WWORK_RAMO_ANT, V0COBA_RAMOFR);

            /*" -3169- MOVE V0APOL-MODALIDA TO V0COBA-MODALIFR */
            _.Move(V0APOL_MODALIDA, V0COBA_MODALIFR);

            /*" -3170- MOVE ZEROS TO V0COBA-COD-COBER */
            _.Move(0, V0COBA_COD_COBER);

            /*" -3171- MOVE ZEROS TO V0COBA-IMP-SEG-IX */
            _.Move(0, V0COBA_IMP_SEG_IX);

            /*" -3172- MOVE ZEROS TO V0COBA-PRM-TAR-IX */
            _.Move(0, V0COBA_PRM_TAR_IX);

            /*" -3173- MOVE ZEROS TO V0COBA-IMP-SEG-VR */
            _.Move(0, V0COBA_IMP_SEG_VR);

            /*" -3174- MOVE ZEROS TO V0COBA-PRM-TAR-VR */
            _.Move(0, V0COBA_PRM_TAR_VR);

            /*" -3175- MOVE ZEROS TO V0COBA-PCT-COBERT. */
            _.Move(0, V0COBA_PCT_COBERT);

            /*" -3176- MOVE ZEROS TO V0COBA-FATOR-MULT */
            _.Move(0, V0COBA_FATOR_MULT);

            /*" -3177- MOVE V0ENDO-DTINIVIG TO V0COBA-DATA-INIVI. */
            _.Move(V0ENDO_DTINIVIG, V0COBA_DATA_INIVI);

            /*" -3178- MOVE V0ENDO-DTTERVIG TO V0COBA-DATA-TERVI. */
            _.Move(V0ENDO_DTTERVIG, V0COBA_DATA_TERVI);

            /*" -3179- MOVE ZEROS TO V0COBA-COD-EMPRESA */
            _.Move(0, V0COBA_COD_EMPRESA);

            /*" -3180- MOVE '0' TO V0COBA-SITUACAO */
            _.Move("0", V0COBA_SITUACAO);

            /*" -3183- MOVE +0 TO VIND-SITUACAO. */
            _.Move(+0, VIND_SITUACAO);

            /*" -3183- PERFORM R0560-00-INSERT-V0COBERAPOL. */

            R0560_00_INSERT_V0COBERAPOL_SECTION();

        }

        [StopWatch]
        /*" R0500-00-TRATA-APOLICE-DB-UPDATE-2 */
        public void R0500_00_TRATA_APOLICE_DB_UPDATE_2()
        {
            /*" -3005- EXEC SQL UPDATE SEGUROS.V0BILHETE SET NUM_APOLICE = :V0APOL-NUM-APOL, SITUACAO = :V0BILH-SITUACAO, COD_USUARIO = 'BI8005B' , TIMESTAMP = CURRENT TIMESTAMP WHERE NUMBIL = :V0BILH-NUMBIL END-EXEC. */

            var r0500_00_TRATA_APOLICE_DB_UPDATE_2_Update1 = new R0500_00_TRATA_APOLICE_DB_UPDATE_2_Update1()
            {
                V0APOL_NUM_APOL = V0APOL_NUM_APOL.ToString(),
                V0BILH_SITUACAO = V0BILH_SITUACAO.ToString(),
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            R0500_00_TRATA_APOLICE_DB_UPDATE_2_Update1.Execute(r0500_00_TRATA_APOLICE_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R0500-00-TRATA-APOLICE-DB-SELECT-3 */
        public void R0500_00_TRATA_APOLICE_DB_SELECT_3()
        {
            /*" -2905- EXEC SQL SELECT PCT_IOCC_RAMO INTO :RAMOCOMP-PCT-IOCC-RAMO FROM SEGUROS.RAMO_COMPLEMENTAR WHERE RAMO_EMISSOR = :V1BILC-RAMOFR AND DATA_INIVIGENCIA <= :V0BILH-DTQITBCO AND DATA_TERVIGENCIA >= :V0BILH-DTQITBCO FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0500_00_TRATA_APOLICE_DB_SELECT_3_Query1 = new R0500_00_TRATA_APOLICE_DB_SELECT_3_Query1()
            {
                V0BILH_DTQITBCO = V0BILH_DTQITBCO.ToString(),
                V1BILC_RAMOFR = V1BILC_RAMOFR.ToString(),
            };

            var executed_1 = R0500_00_TRATA_APOLICE_DB_SELECT_3_Query1.Execute(r0500_00_TRATA_APOLICE_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RAMOCOMP_PCT_IOCC_RAMO, RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_PCT_IOCC_RAMO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0520_99_SAIDA*/

        [StopWatch]
        /*" R0530-00-INCLUI-ENDOSSO-SECTION */
        private void R0530_00_INCLUI_ENDOSSO_SECTION()
        {
            /*" -3196- MOVE '0530' TO WNR-EXEC-SQL. */
            _.Move("0530", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3286- PERFORM R0530_00_INCLUI_ENDOSSO_DB_INSERT_1 */

            R0530_00_INCLUI_ENDOSSO_DB_INSERT_1();

            /*" -3289- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3290- DISPLAY 'R0530-00 (ERRO - INSERT V0ENDOSSO)...' */
                _.Display($"R0530-00 (ERRO - INSERT V0ENDOSSO)...");

                /*" -3291- DISPLAY 'NUMERO DO BILHETE = ' V0BILH-NUMBIL */
                _.Display($"NUMERO DO BILHETE = {V0BILH_NUMBIL}");

                /*" -3292- DISPLAY 'V0ENDO-NUM-APOL   = ' V0ENDO-NUM-APOL */
                _.Display($"V0ENDO-NUM-APOL   = {V0ENDO_NUM_APOL}");

                /*" -3293- DISPLAY 'V0ENDO-NRENDOS    = ' V0ENDO-NRENDOS */
                _.Display($"V0ENDO-NRENDOS    = {V0ENDO_NRENDOS}");

                /*" -3294- DISPLAY 'V0ENDO-FONTE      = ' V0ENDO-FONTE */
                _.Display($"V0ENDO-FONTE      = {V0ENDO_FONTE}");

                /*" -3295- DISPLAY 'V0ENDO-NRPROPOS   = ' V0ENDO-NRPROPOS */
                _.Display($"V0ENDO-NRPROPOS   = {V0ENDO_NRPROPOS}");

                /*" -3296- DISPLAY 'RAMO   : ' WWORK-RAMO-ANT */
                _.Display($"RAMO   : {WWORK_RAMO_ANT}");

                /*" -3297- DISPLAY 'OPCAO  : ' WWORK-OPCAO-ANT */
                _.Display($"OPCAO  : {WWORK_OPCAO_ANT}");

                /*" -3298- DISPLAY 'INI VIG: ' V0ENDO-DTINIVIG */
                _.Display($"INI VIG: {V0ENDO_DTINIVIG}");

                /*" -3299- DISPLAY 'FIM VIG: ' V0ENDO-DTTERVIG */
                _.Display($"FIM VIG: {V0ENDO_DTTERVIG}");

                /*" -3301- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3301- ADD +1 TO AC-I-V0ENDOSSO. */
            AREA_DE_WORK.AC_I_V0ENDOSSO.Value = AREA_DE_WORK.AC_I_V0ENDOSSO + +1;

        }

        [StopWatch]
        /*" R0530-00-INCLUI-ENDOSSO-DB-INSERT-1 */
        public void R0530_00_INCLUI_ENDOSSO_DB_INSERT_1()
        {
            /*" -3286- EXEC SQL INSERT INTO SEGUROS.V0ENDOSSO (NUM_APOLICE , NRENDOS , CODSUBES , FONTE , NRPROPOS , DATPRO , DATA_LIBERACAO , DTEMIS , NRRCAP , VLRCAP , BCORCAP , AGERCAP , DACRCAP , IDRCAP , BCOCOBR , AGECOBR , DACCOBR , DTINIVIG , DTTERVIG , CDFRACIO , PCENTRAD , PCADICIO , PRESTA1 , QTPARCEL , QTPRESTA , QTITENS , CODTXT , CDACEITA , COD_MOEDA_IMP , COD_MOEDA_PRM , TIPO_ENDOSSO , COD_USUARIO , OCORR_ENDERECO , SITUACAO , DATARCAP , COD_EMPRESA , CORRECAO , ISENTA_CUSTO , TIMESTAMP , DTVENCTO , CFPREFIX , VLCUSEMI , RAMO , CODPRODU) VALUES (:V0ENDO-NUM-APOL , :V0ENDO-NRENDOS , :V0ENDO-CODSUBES , :V0ENDO-FONTE , :V0ENDO-NRPROPOS , :V0ENDO-DATPRO , :V0ENDO-DT-LIBER , :V0ENDO-DTEMIS , :V0ENDO-NRRCAP , :V0ENDO-VLRCAP , :V0ENDO-BCORCAP , :V0ENDO-AGERCAP , :V0ENDO-DACRCAP , :V0ENDO-IDRCAP , :V0ENDO-BCOCOBR , :V0ENDO-AGECOBR , :V0ENDO-DACCOBR , :V0ENDO-DTINIVIG , :V0ENDO-DTTERVIG , :V0ENDO-CDFRACIO , :V0ENDO-PCENTRAD , :V0ENDO-PCADICIO , :V0ENDO-PRESTA1 , :V0ENDO-QTPARCEL , :V0ENDO-QTPRESTA , :V0ENDO-QTITENS , :V0ENDO-CODTXT , :V0ENDO-CDACEITA , :V0ENDO-MOEDA-IMP , :V0ENDO-MOEDA-PRM , :V0ENDO-TIPO-ENDO , :V0ENDO-COD-USUAR , :V0ENDO-OCORR-END , :V0ENDO-SITUACAO , :V0ENDO-DATARCAP:VIND-DATARCAP , :V0ENDO-COD-EMPRESA , :V0ENDO-CORRECAO , :V0ENDO-ISENTA-CST , CURRENT TIMESTAMP , :V0ENDO-DTVENCTO:VIND-DTVENCTO , :V0ENDO-CFPREFIX:VIND-CFPREFIX , :V0ENDO-VLCUSEMI:VIND-VLCUSEMI , :V0ENDO-RAMO , :V0ENDO-CODPRODU) END-EXEC. */

            var r0530_00_INCLUI_ENDOSSO_DB_INSERT_1_Insert1 = new R0530_00_INCLUI_ENDOSSO_DB_INSERT_1_Insert1()
            {
                V0ENDO_NUM_APOL = V0ENDO_NUM_APOL.ToString(),
                V0ENDO_NRENDOS = V0ENDO_NRENDOS.ToString(),
                V0ENDO_CODSUBES = V0ENDO_CODSUBES.ToString(),
                V0ENDO_FONTE = V0ENDO_FONTE.ToString(),
                V0ENDO_NRPROPOS = V0ENDO_NRPROPOS.ToString(),
                V0ENDO_DATPRO = V0ENDO_DATPRO.ToString(),
                V0ENDO_DT_LIBER = V0ENDO_DT_LIBER.ToString(),
                V0ENDO_DTEMIS = V0ENDO_DTEMIS.ToString(),
                V0ENDO_NRRCAP = V0ENDO_NRRCAP.ToString(),
                V0ENDO_VLRCAP = V0ENDO_VLRCAP.ToString(),
                V0ENDO_BCORCAP = V0ENDO_BCORCAP.ToString(),
                V0ENDO_AGERCAP = V0ENDO_AGERCAP.ToString(),
                V0ENDO_DACRCAP = V0ENDO_DACRCAP.ToString(),
                V0ENDO_IDRCAP = V0ENDO_IDRCAP.ToString(),
                V0ENDO_BCOCOBR = V0ENDO_BCOCOBR.ToString(),
                V0ENDO_AGECOBR = V0ENDO_AGECOBR.ToString(),
                V0ENDO_DACCOBR = V0ENDO_DACCOBR.ToString(),
                V0ENDO_DTINIVIG = V0ENDO_DTINIVIG.ToString(),
                V0ENDO_DTTERVIG = V0ENDO_DTTERVIG.ToString(),
                V0ENDO_CDFRACIO = V0ENDO_CDFRACIO.ToString(),
                V0ENDO_PCENTRAD = V0ENDO_PCENTRAD.ToString(),
                V0ENDO_PCADICIO = V0ENDO_PCADICIO.ToString(),
                V0ENDO_PRESTA1 = V0ENDO_PRESTA1.ToString(),
                V0ENDO_QTPARCEL = V0ENDO_QTPARCEL.ToString(),
                V0ENDO_QTPRESTA = V0ENDO_QTPRESTA.ToString(),
                V0ENDO_QTITENS = V0ENDO_QTITENS.ToString(),
                V0ENDO_CODTXT = V0ENDO_CODTXT.ToString(),
                V0ENDO_CDACEITA = V0ENDO_CDACEITA.ToString(),
                V0ENDO_MOEDA_IMP = V0ENDO_MOEDA_IMP.ToString(),
                V0ENDO_MOEDA_PRM = V0ENDO_MOEDA_PRM.ToString(),
                V0ENDO_TIPO_ENDO = V0ENDO_TIPO_ENDO.ToString(),
                V0ENDO_COD_USUAR = V0ENDO_COD_USUAR.ToString(),
                V0ENDO_OCORR_END = V0ENDO_OCORR_END.ToString(),
                V0ENDO_SITUACAO = V0ENDO_SITUACAO.ToString(),
                V0ENDO_DATARCAP = V0ENDO_DATARCAP.ToString(),
                VIND_DATARCAP = VIND_DATARCAP.ToString(),
                V0ENDO_COD_EMPRESA = V0ENDO_COD_EMPRESA.ToString(),
                V0ENDO_CORRECAO = V0ENDO_CORRECAO.ToString(),
                V0ENDO_ISENTA_CST = V0ENDO_ISENTA_CST.ToString(),
                V0ENDO_DTVENCTO = V0ENDO_DTVENCTO.ToString(),
                VIND_DTVENCTO = VIND_DTVENCTO.ToString(),
                V0ENDO_CFPREFIX = V0ENDO_CFPREFIX.ToString(),
                VIND_CFPREFIX = VIND_CFPREFIX.ToString(),
                V0ENDO_VLCUSEMI = V0ENDO_VLCUSEMI.ToString(),
                VIND_VLCUSEMI = VIND_VLCUSEMI.ToString(),
                V0ENDO_RAMO = V0ENDO_RAMO.ToString(),
                V0ENDO_CODPRODU = V0ENDO_CODPRODU.ToString(),
            };

            R0530_00_INCLUI_ENDOSSO_DB_INSERT_1_Insert1.Execute(r0530_00_INCLUI_ENDOSSO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0530_99_SAIDA*/

        [StopWatch]
        /*" R0540-00-INCLUI-PARCELAS-SECTION */
        private void R0540_00_INCLUI_PARCELAS_SECTION()
        {
            /*" -3313- MOVE '0540' TO WNR-EXEC-SQL. */
            _.Move("0540", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3334- PERFORM R0540_00_INCLUI_PARCELAS_DB_INSERT_1 */

            R0540_00_INCLUI_PARCELAS_DB_INSERT_1();

            /*" -3337- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -3338- DISPLAY 'R0540-00 (ERRO - INSERT V0PARCELA)...' */
                _.Display($"R0540-00 (ERRO - INSERT V0PARCELA)...");

                /*" -3342- DISPLAY 'APOL: ' V0PARC-NUM-APOL '  ' 'ENDO: ' V0PARC-NRENDOS '  ' 'PARC: ' V0PARC-NRPARCEL '  ' 'BILH: ' V0BILH-NUMBIL */

                $"APOL: {V0PARC_NUM_APOL}  ENDO: {V0PARC_NRENDOS}  PARC: {V0PARC_NRPARCEL}  BILH: {V0BILH_NUMBIL}"
                .Display();

                /*" -3343- ELSE */
            }
            else
            {


                /*" -3344- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -3345- DISPLAY 'R0540-00 (ERRO - INSERT V0PARCELA)...' */
                    _.Display($"R0540-00 (ERRO - INSERT V0PARCELA)...");

                    /*" -3349- DISPLAY 'APOL: ' V0PARC-NUM-APOL '  ' 'ENDO: ' V0PARC-NRENDOS '  ' 'PARC: ' V0PARC-NRPARCEL '  ' 'BILH: ' V0BILH-NUMBIL */

                    $"APOL: {V0PARC_NUM_APOL}  ENDO: {V0PARC_NRENDOS}  PARC: {V0PARC_NRPARCEL}  BILH: {V0BILH_NUMBIL}"
                    .Display();

                    /*" -3351- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3351- ADD +1 TO AC-I-V0PARCELA. */
            AREA_DE_WORK.AC_I_V0PARCELA.Value = AREA_DE_WORK.AC_I_V0PARCELA + +1;

        }

        [StopWatch]
        /*" R0540-00-INCLUI-PARCELAS-DB-INSERT-1 */
        public void R0540_00_INCLUI_PARCELAS_DB_INSERT_1()
        {
            /*" -3334- EXEC SQL INSERT INTO SEGUROS.V0PARCELA VALUES (:V0PARC-NUM-APOL , :V0PARC-NRENDOS , :V0PARC-NRPARCEL , :V0PARC-DACPARC , :V0PARC-FONTE , :V0PARC-NRTIT , :V0PARC-PRM-TAR-IX , :V0PARC-VAL-DES-IX , :V0PARC-OTNPRLIQ , :V0PARC-OTNADFRA , :V0PARC-OTNCUSTO , :V0PARC-OTNIOF , :V0PARC-OTNTOTAL , :V0PARC-OCORHIST , :V0PARC-QTDDOC , :V0PARC-SITUACAO , :V0PARC-COD-EMPRESA , CURRENT TIMESTAMP, NULL) END-EXEC. */

            var r0540_00_INCLUI_PARCELAS_DB_INSERT_1_Insert1 = new R0540_00_INCLUI_PARCELAS_DB_INSERT_1_Insert1()
            {
                V0PARC_NUM_APOL = V0PARC_NUM_APOL.ToString(),
                V0PARC_NRENDOS = V0PARC_NRENDOS.ToString(),
                V0PARC_NRPARCEL = V0PARC_NRPARCEL.ToString(),
                V0PARC_DACPARC = V0PARC_DACPARC.ToString(),
                V0PARC_FONTE = V0PARC_FONTE.ToString(),
                V0PARC_NRTIT = V0PARC_NRTIT.ToString(),
                V0PARC_PRM_TAR_IX = V0PARC_PRM_TAR_IX.ToString(),
                V0PARC_VAL_DES_IX = V0PARC_VAL_DES_IX.ToString(),
                V0PARC_OTNPRLIQ = V0PARC_OTNPRLIQ.ToString(),
                V0PARC_OTNADFRA = V0PARC_OTNADFRA.ToString(),
                V0PARC_OTNCUSTO = V0PARC_OTNCUSTO.ToString(),
                V0PARC_OTNIOF = V0PARC_OTNIOF.ToString(),
                V0PARC_OTNTOTAL = V0PARC_OTNTOTAL.ToString(),
                V0PARC_OCORHIST = V0PARC_OCORHIST.ToString(),
                V0PARC_QTDDOC = V0PARC_QTDDOC.ToString(),
                V0PARC_SITUACAO = V0PARC_SITUACAO.ToString(),
                V0PARC_COD_EMPRESA = V0PARC_COD_EMPRESA.ToString(),
            };

            R0540_00_INCLUI_PARCELAS_DB_INSERT_1_Insert1.Execute(r0540_00_INCLUI_PARCELAS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0540_99_SAIDA*/

        [StopWatch]
        /*" R0550-00-INSERT-V0HISTOPARC-SECTION */
        private void R0550_00_INSERT_V0HISTOPARC_SECTION()
        {
            /*" -3363- MOVE '0550' TO WNR-EXEC-SQL. */
            _.Move("0550", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3392- PERFORM R0550_00_INSERT_V0HISTOPARC_DB_INSERT_1 */

            R0550_00_INSERT_V0HISTOPARC_DB_INSERT_1();

            /*" -3395- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -3396- DISPLAY 'R0550-00 (ERRO - INSERT V0HISTOPARC)...' */
                _.Display($"R0550-00 (ERRO - INSERT V0HISTOPARC)...");

                /*" -3401- DISPLAY 'APOL: ' V0HISP-NUM-APOL '  ' 'ENDO: ' V0HISP-NRENDOS '  ' 'PARC: ' V0HISP-NRPARCEL '  ' 'OCOR: ' V0HISP-OCORHIST '  ' 'BILH: ' V0BILH-NUMBIL */

                $"APOL: {V0HISP_NUM_APOL}  ENDO: {V0HISP_NRENDOS}  PARC: {V0HISP_NRPARCEL}  OCOR: {V0HISP_OCORHIST}  BILH: {V0BILH_NUMBIL}"
                .Display();

                /*" -3402- ELSE */
            }
            else
            {


                /*" -3403- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -3404- DISPLAY 'R0550-00 (ERRO - INSERT V0HISTOPARC)...' */
                    _.Display($"R0550-00 (ERRO - INSERT V0HISTOPARC)...");

                    /*" -3409- DISPLAY 'APOL: ' V0HISP-NUM-APOL '  ' 'ENDO: ' V0HISP-NRENDOS '  ' 'PARC: ' V0HISP-NRPARCEL '  ' 'OCOR: ' V0HISP-OCORHIST '  ' 'BILH: ' V0BILH-NUMBIL */

                    $"APOL: {V0HISP_NUM_APOL}  ENDO: {V0HISP_NRENDOS}  PARC: {V0HISP_NRPARCEL}  OCOR: {V0HISP_OCORHIST}  BILH: {V0BILH_NUMBIL}"
                    .Display();

                    /*" -3411- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3411- ADD +1 TO AC-I-V0HISTOPARC. */
            AREA_DE_WORK.AC_I_V0HISTOPARC.Value = AREA_DE_WORK.AC_I_V0HISTOPARC + +1;

        }

        [StopWatch]
        /*" R0550-00-INSERT-V0HISTOPARC-DB-INSERT-1 */
        public void R0550_00_INSERT_V0HISTOPARC_DB_INSERT_1()
        {
            /*" -3392- EXEC SQL INSERT INTO SEGUROS.V0HISTOPARC VALUES (:V0HISP-NUM-APOL , :V0HISP-NRENDOS , :V0HISP-NRPARCEL , :V0HISP-DACPARC , :V0HISP-DTMOVTO , :V0HISP-OPERACAO , :V0HISP-HORAOPER , :V0HISP-OCORHIST , :V0HISP-PRM-TARIFA , :V0HISP-VAL-DESCON , :V0HISP-VLPRMLIQ , :V0HISP-VLADIFRA , :V0HISP-VLCUSEMI , :V0HISP-VLIOCC , :V0HISP-VLPRMTOT , :V0HISP-VLPREMIO , :V0HISP-DTVENCTO , :V0HISP-BCOCOBR , :V0HISP-AGECOBR , :V0HISP-NRAVISO , :V0HISP-NRENDOCA , :V0HISP-SITCONTB , :V0HISP-COD-USUAR , :V0HISP-RNUDOC , :V0HISP-DTQITBCO:VIND-DTQITBCO , :V0HISP-COD-EMPRESA , CURRENT TIMESTAMP) END-EXEC. */

            var r0550_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1 = new R0550_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1()
            {
                V0HISP_NUM_APOL = V0HISP_NUM_APOL.ToString(),
                V0HISP_NRENDOS = V0HISP_NRENDOS.ToString(),
                V0HISP_NRPARCEL = V0HISP_NRPARCEL.ToString(),
                V0HISP_DACPARC = V0HISP_DACPARC.ToString(),
                V0HISP_DTMOVTO = V0HISP_DTMOVTO.ToString(),
                V0HISP_OPERACAO = V0HISP_OPERACAO.ToString(),
                V0HISP_HORAOPER = V0HISP_HORAOPER.ToString(),
                V0HISP_OCORHIST = V0HISP_OCORHIST.ToString(),
                V0HISP_PRM_TARIFA = V0HISP_PRM_TARIFA.ToString(),
                V0HISP_VAL_DESCON = V0HISP_VAL_DESCON.ToString(),
                V0HISP_VLPRMLIQ = V0HISP_VLPRMLIQ.ToString(),
                V0HISP_VLADIFRA = V0HISP_VLADIFRA.ToString(),
                V0HISP_VLCUSEMI = V0HISP_VLCUSEMI.ToString(),
                V0HISP_VLIOCC = V0HISP_VLIOCC.ToString(),
                V0HISP_VLPRMTOT = V0HISP_VLPRMTOT.ToString(),
                V0HISP_VLPREMIO = V0HISP_VLPREMIO.ToString(),
                V0HISP_DTVENCTO = V0HISP_DTVENCTO.ToString(),
                V0HISP_BCOCOBR = V0HISP_BCOCOBR.ToString(),
                V0HISP_AGECOBR = V0HISP_AGECOBR.ToString(),
                V0HISP_NRAVISO = V0HISP_NRAVISO.ToString(),
                V0HISP_NRENDOCA = V0HISP_NRENDOCA.ToString(),
                V0HISP_SITCONTB = V0HISP_SITCONTB.ToString(),
                V0HISP_COD_USUAR = V0HISP_COD_USUAR.ToString(),
                V0HISP_RNUDOC = V0HISP_RNUDOC.ToString(),
                V0HISP_DTQITBCO = V0HISP_DTQITBCO.ToString(),
                VIND_DTQITBCO = VIND_DTQITBCO.ToString(),
                V0HISP_COD_EMPRESA = V0HISP_COD_EMPRESA.ToString(),
            };

            R0550_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1.Execute(r0550_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0550_99_SAIDA*/

        [StopWatch]
        /*" R0560-00-INSERT-V0COBERAPOL-SECTION */
        private void R0560_00_INSERT_V0COBERAPOL_SECTION()
        {
            /*" -3423- MOVE '0560' TO WNR-EXEC-SQL. */
            _.Move("0560", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3443- PERFORM R0560_00_INSERT_V0COBERAPOL_DB_INSERT_1 */

            R0560_00_INSERT_V0COBERAPOL_DB_INSERT_1();

            /*" -3446- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3447- DISPLAY 'R0560-00 (ERRO - INSERT V0COBERAPOL)...' */
                _.Display($"R0560-00 (ERRO - INSERT V0COBERAPOL)...");

                /*" -3450- DISPLAY 'APOL: ' V0COBA-NUM-APOL '  ' 'ENDO: ' V0COBA-NRENDOS '  ' 'RAMO: ' V0COBA-RAMOFR '  ' */

                $"APOL: {V0COBA_NUM_APOL}  ENDO: {V0COBA_NRENDOS}  RAMO: {V0COBA_RAMOFR}  "
                .Display();

                /*" -3452- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3452- ADD +1 TO AC-I-V0COBERAPOL. */
            AREA_DE_WORK.AC_I_V0COBERAPOL.Value = AREA_DE_WORK.AC_I_V0COBERAPOL + +1;

        }

        [StopWatch]
        /*" R0560-00-INSERT-V0COBERAPOL-DB-INSERT-1 */
        public void R0560_00_INSERT_V0COBERAPOL_DB_INSERT_1()
        {
            /*" -3443- EXEC SQL INSERT INTO SEGUROS.V0COBERAPOL VALUES (:V0COBA-NUM-APOL , :V0COBA-NRENDOS , :V0COBA-NUM-ITEM , :V0COBA-OCORHIST , :V0COBA-RAMOFR , :V0COBA-MODALIFR , :V0COBA-COD-COBER , :V0COBA-IMP-SEG-IX , :V0COBA-PRM-TAR-IX , :V0COBA-IMP-SEG-VR , :V0COBA-PRM-TAR-VR , :V0COBA-PCT-COBERT , :V0COBA-FATOR-MULT , :V0COBA-DATA-INIVI , :V0COBA-DATA-TERVI , :V0COBA-COD-EMPRESA , CURRENT TIMESTAMP , :V0COBA-SITUACAO:VIND-SITUACAO) END-EXEC. */

            var r0560_00_INSERT_V0COBERAPOL_DB_INSERT_1_Insert1 = new R0560_00_INSERT_V0COBERAPOL_DB_INSERT_1_Insert1()
            {
                V0COBA_NUM_APOL = V0COBA_NUM_APOL.ToString(),
                V0COBA_NRENDOS = V0COBA_NRENDOS.ToString(),
                V0COBA_NUM_ITEM = V0COBA_NUM_ITEM.ToString(),
                V0COBA_OCORHIST = V0COBA_OCORHIST.ToString(),
                V0COBA_RAMOFR = V0COBA_RAMOFR.ToString(),
                V0COBA_MODALIFR = V0COBA_MODALIFR.ToString(),
                V0COBA_COD_COBER = V0COBA_COD_COBER.ToString(),
                V0COBA_IMP_SEG_IX = V0COBA_IMP_SEG_IX.ToString(),
                V0COBA_PRM_TAR_IX = V0COBA_PRM_TAR_IX.ToString(),
                V0COBA_IMP_SEG_VR = V0COBA_IMP_SEG_VR.ToString(),
                V0COBA_PRM_TAR_VR = V0COBA_PRM_TAR_VR.ToString(),
                V0COBA_PCT_COBERT = V0COBA_PCT_COBERT.ToString(),
                V0COBA_FATOR_MULT = V0COBA_FATOR_MULT.ToString(),
                V0COBA_DATA_INIVI = V0COBA_DATA_INIVI.ToString(),
                V0COBA_DATA_TERVI = V0COBA_DATA_TERVI.ToString(),
                V0COBA_COD_EMPRESA = V0COBA_COD_EMPRESA.ToString(),
                V0COBA_SITUACAO = V0COBA_SITUACAO.ToString(),
                VIND_SITUACAO = VIND_SITUACAO.ToString(),
            };

            R0560_00_INSERT_V0COBERAPOL_DB_INSERT_1_Insert1.Execute(r0560_00_INSERT_V0COBERAPOL_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0560_99_SAIDA*/

        [StopWatch]
        /*" R0600-00-MONTA-ENDOSSO01-SECTION */
        private void R0600_00_MONTA_ENDOSSO01_SECTION()
        {
            /*" -3468- MOVE '0600' TO WNR-EXEC-SQL. */
            _.Move("0600", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3470- ADD 1 TO V1FONT-PROPAUTOM. */
            V1FONT_PROPAUTOM.Value = V1FONT_PROPAUTOM + 1;

            /*" -3472- PERFORM R3180-00-LE-ENDOSSO. */

            R3180_00_LE_ENDOSSO_SECTION();

            /*" -3473- MOVE V1FONT-PROPAUTOM TO V0ENDO-NRPROPOS. */
            _.Move(V1FONT_PROPAUTOM, V0ENDO_NRPROPOS);

            /*" -3475- MOVE '1' TO V0ENDO-SITUACAO. */
            _.Move("1", V0ENDO_SITUACAO);

            /*" -3479- PERFORM R0600_00_MONTA_ENDOSSO01_DB_UPDATE_1 */

            R0600_00_MONTA_ENDOSSO01_DB_UPDATE_1();

            /*" -3482- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3485- DISPLAY 'R0660-00 (ERRO - UPDATE V0FONTE)...' ' ' V0BILH-NUMBIL ' ' V0BILH-FONTE */

                $"R0660-00 (ERRO - UPDATE V0FONTE)... {V0BILH_NUMBIL} {V0BILH_FONTE}"
                .Display();

                /*" -3487- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3492- PERFORM R0600_00_MONTA_ENDOSSO01_DB_SELECT_1 */

            R0600_00_MONTA_ENDOSSO01_DB_SELECT_1();

            /*" -3495- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3497- DISPLAY 'R0600-00 (ERRO - SELECT DATA-TERVIG ' ' ' V0BILH-NUMBIL */

                $"R0600-00 (ERRO - SELECT DATA-TERVIG  {V0BILH_NUMBIL}"
                .Display();

                /*" -3499- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3500- MOVE WHOST-DTINIVIG TO V0ENDO-DTTERVIG */
            _.Move(WHOST_DTINIVIG, V0ENDO_DTTERVIG);

            /*" -3502- MOVE '1' TO V0ENDO-SITUACAO. */
            _.Move("1", V0ENDO_SITUACAO);

            /*" -3503- MOVE 1 TO V0ENDO-NRENDOS */
            _.Move(1, V0ENDO_NRENDOS);

            /*" -3505- MOVE 104 TO V0ENDO-BCORCAP V0ENDO-BCOCOBR. */
            _.Move(104, V0ENDO_BCORCAP, V0ENDO_BCOCOBR);

            /*" -3506- MOVE V0BILH-AGECOBR TO V0ENDO-AGERCAP. */
            _.Move(V0BILH_AGECOBR, V0ENDO_AGERCAP);

            /*" -3507- MOVE V1RCAC-AGEAVISO TO V0ENDO-AGECOBR. */
            _.Move(V1RCAC_AGEAVISO, V0ENDO_AGECOBR);

            /*" -3508- MOVE '0' TO V0ENDO-DACCOBR */
            _.Move("0", V0ENDO_DACCOBR);

            /*" -3509- MOVE WWORK-NRRCAP TO V0ENDO-NRRCAP */
            _.Move(AREA_DE_WORK.FILLER_4.WWORK_NRRCAP, V0ENDO_NRRCAP);

            /*" -3510- MOVE V0BILH-VLRCAP TO V0ENDO-VLRCAP. */
            _.Move(V0BILH_VLRCAP, V0ENDO_VLRCAP);

            /*" -3511- MOVE '0' TO V0ENDO-DACRCAP */
            _.Move("0", V0ENDO_DACRCAP);

            /*" -3512- MOVE '0' TO V0ENDO-IDRCAP */
            _.Move("0", V0ENDO_IDRCAP);

            /*" -3513- MOVE V0BILH-DTQITBCO TO V0ENDO-DATARCAP */
            _.Move(V0BILH_DTQITBCO, V0ENDO_DATARCAP);

            /*" -3515- MOVE +0 TO VIND-DATARCAP. */
            _.Move(+0, VIND_DATARCAP);

            /*" -3521- PERFORM R0530-00-INCLUI-ENDOSSO. */

            R0530_00_INCLUI_ENDOSSO_SECTION();

            /*" -3522- MOVE V0ENDO-NUM-APOL TO V0PARC-NUM-APOL */
            _.Move(V0ENDO_NUM_APOL, V0PARC_NUM_APOL);

            /*" -3523- MOVE V0ENDO-NRENDOS TO V0PARC-NRENDOS */
            _.Move(V0ENDO_NRENDOS, V0PARC_NRENDOS);

            /*" -3524- MOVE ZEROS TO V0PARC-NRPARCEL */
            _.Move(0, V0PARC_NRPARCEL);

            /*" -3525- MOVE '0' TO V0PARC-DACPARC */
            _.Move("0", V0PARC_DACPARC);

            /*" -3526- MOVE V0BILH-FONTE TO V0PARC-FONTE */
            _.Move(V0BILH_FONTE, V0PARC_FONTE);

            /*" -3527- MOVE V0BILH-NUMBIL TO V0PARC-NRTIT */
            _.Move(V0BILH_NUMBIL, V0PARC_NRTIT);

            /*" -3528- MOVE WWORK-PR-APOL TO V0PARC-PRM-TAR-IX */
            _.Move(AREA_DE_WORK.WWORK_PR_APOL, V0PARC_PRM_TAR_IX);

            /*" -3529- MOVE ZEROS TO V0PARC-VAL-DES-IX */
            _.Move(0, V0PARC_VAL_DES_IX);

            /*" -3530- MOVE WWORK-PR-APOL TO V0PARC-OTNPRLIQ */
            _.Move(AREA_DE_WORK.WWORK_PR_APOL, V0PARC_OTNPRLIQ);

            /*" -3531- MOVE ZEROS TO V0PARC-OTNADFRA */
            _.Move(0, V0PARC_OTNADFRA);

            /*" -3532- MOVE ZEROS TO V0PARC-OTNCUSTO */
            _.Move(0, V0PARC_OTNCUSTO);

            /*" -3533- MOVE WWORK-IOCC TO V0PARC-OTNIOF. */
            _.Move(AREA_DE_WORK.WWORK_IOCC, V0PARC_OTNIOF);

            /*" -3534- MOVE ZEROS TO V0PARC-OTNTOTAL. */
            _.Move(0, V0PARC_OTNTOTAL);

            /*" -3538- COMPUTE V0PARC-OTNTOTAL = V0PARC-OTNPRLIQ + V0PARC-OTNADFRA + V0PARC-OTNCUSTO + V0PARC-OTNIOF. */
            V0PARC_OTNTOTAL.Value = V0PARC_OTNPRLIQ + V0PARC_OTNADFRA + V0PARC_OTNCUSTO + V0PARC_OTNIOF;

            /*" -3539- MOVE 2 TO V0PARC-OCORHIST */
            _.Move(2, V0PARC_OCORHIST);

            /*" -3540- MOVE ZEROS TO V0PARC-QTDDOC */
            _.Move(0, V0PARC_QTDDOC);

            /*" -3541- MOVE '1' TO V0PARC-SITUACAO */
            _.Move("1", V0PARC_SITUACAO);

            /*" -3544- MOVE ZEROS TO V0PARC-COD-EMPRESA. */
            _.Move(0, V0PARC_COD_EMPRESA);

            /*" -3550- PERFORM R0540-00-INCLUI-PARCELAS. */

            R0540_00_INCLUI_PARCELAS_SECTION();

            /*" -3551- MOVE V0PARC-NUM-APOL TO V0HISP-NUM-APOL */
            _.Move(V0PARC_NUM_APOL, V0HISP_NUM_APOL);

            /*" -3552- MOVE V0PARC-NRENDOS TO V0HISP-NRENDOS */
            _.Move(V0PARC_NRENDOS, V0HISP_NRENDOS);

            /*" -3553- MOVE V0PARC-NRPARCEL TO V0HISP-NRPARCEL */
            _.Move(V0PARC_NRPARCEL, V0HISP_NRPARCEL);

            /*" -3554- MOVE '0' TO V0HISP-DACPARC */
            _.Move("0", V0HISP_DACPARC);

            /*" -3555- MOVE 0101 TO V0HISP-OPERACAO */
            _.Move(0101, V0HISP_OPERACAO);

            /*" -3557- MOVE V1SIST-DTMOVACB TO V0HISP-DTMOVTO */
            _.Move(V1SIST_DTMOVACB, V0HISP_DTMOVTO);

            /*" -3558- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_TIME);

            /*" -3559- MOVE WS000-H TO WS000-HT */
            _.Move(WS_TIME.WS000_H, WS000_HORA_TIME_REDF.WS000_HT);

            /*" -3560- MOVE WS000-M TO WS000-MT */
            _.Move(WS_TIME.WS000_M, WS000_HORA_TIME_REDF.WS000_MT);

            /*" -3561- MOVE WS000-S TO WS000-ST */
            _.Move(WS_TIME.WS000_S, WS000_HORA_TIME_REDF.WS000_ST);

            /*" -3563- MOVE WS000-HORA-TIME TO V0HISP-HORAOPER. */
            _.Move(WS000_HORA_TIME, V0HISP_HORAOPER);

            /*" -3565- MOVE 1 TO V0HISP-OCORHIST. */
            _.Move(1, V0HISP_OCORHIST);

            /*" -3566- MOVE V0PARC-PRM-TAR-IX TO V0HISP-PRM-TARIFA */
            _.Move(V0PARC_PRM_TAR_IX, V0HISP_PRM_TARIFA);

            /*" -3567- MOVE V0PARC-VAL-DES-IX TO V0HISP-VAL-DESCON */
            _.Move(V0PARC_VAL_DES_IX, V0HISP_VAL_DESCON);

            /*" -3568- MOVE V0PARC-OTNPRLIQ TO V0HISP-VLPRMLIQ */
            _.Move(V0PARC_OTNPRLIQ, V0HISP_VLPRMLIQ);

            /*" -3569- MOVE V0PARC-OTNADFRA TO V0HISP-VLADIFRA */
            _.Move(V0PARC_OTNADFRA, V0HISP_VLADIFRA);

            /*" -3570- MOVE V0PARC-OTNCUSTO TO V0HISP-VLCUSEMI */
            _.Move(V0PARC_OTNCUSTO, V0HISP_VLCUSEMI);

            /*" -3571- MOVE V0PARC-OTNIOF TO V0HISP-VLIOCC */
            _.Move(V0PARC_OTNIOF, V0HISP_VLIOCC);

            /*" -3572- MOVE V0PARC-OTNTOTAL TO V0HISP-VLPRMTOT */
            _.Move(V0PARC_OTNTOTAL, V0HISP_VLPRMTOT);

            /*" -3573- MOVE ZEROS TO V0HISP-VLPREMIO */
            _.Move(0, V0HISP_VLPREMIO);

            /*" -3574- MOVE V1SIST-DTMOVACB TO V0HISP-DTVENCTO */
            _.Move(V1SIST_DTMOVACB, V0HISP_DTVENCTO);

            /*" -3575- MOVE 104 TO V0HISP-BCOCOBR */
            _.Move(104, V0HISP_BCOCOBR);

            /*" -3576- MOVE V0ENDO-AGECOBR TO V0HISP-AGECOBR */
            _.Move(V0ENDO_AGECOBR, V0HISP_AGECOBR);

            /*" -3577- MOVE ZEROS TO V0HISP-NRAVISO */
            _.Move(0, V0HISP_NRAVISO);

            /*" -3578- MOVE ZEROS TO V0HISP-NRENDOCA */
            _.Move(0, V0HISP_NRENDOCA);

            /*" -3579- MOVE '0' TO V0HISP-SITCONTB */
            _.Move("0", V0HISP_SITCONTB);

            /*" -3580- MOVE 'BI8005B' TO V0HISP-COD-USUAR */
            _.Move("BI8005B", V0HISP_COD_USUAR);

            /*" -3582- MOVE ZEROS TO V0HISP-RNUDOC */
            _.Move(0, V0HISP_RNUDOC);

            /*" -3584- MOVE -1 TO VIND-DTQITBCO */
            _.Move(-1, VIND_DTQITBCO);

            /*" -3587- MOVE ZEROS TO V0HISP-COD-EMPRESA. */
            _.Move(0, V0HISP_COD_EMPRESA);

            /*" -3593- PERFORM R0550-00-INSERT-V0HISTOPARC. */

            R0550_00_INSERT_V0HISTOPARC_SECTION();

            /*" -3594- MOVE V0PARC-NUM-APOL TO V0HISP-NUM-APOL */
            _.Move(V0PARC_NUM_APOL, V0HISP_NUM_APOL);

            /*" -3595- MOVE V0PARC-NRENDOS TO V0HISP-NRENDOS */
            _.Move(V0PARC_NRENDOS, V0HISP_NRENDOS);

            /*" -3596- MOVE V0PARC-NRPARCEL TO V0HISP-NRPARCEL */
            _.Move(V0PARC_NRPARCEL, V0HISP_NRPARCEL);

            /*" -3597- MOVE '0' TO V0HISP-DACPARC */
            _.Move("0", V0HISP_DACPARC);

            /*" -3598- MOVE 0201 TO V0HISP-OPERACAO */
            _.Move(0201, V0HISP_OPERACAO);

            /*" -3600- MOVE V1SIST-DTMOVACB TO V0HISP-DTMOVTO */
            _.Move(V1SIST_DTMOVACB, V0HISP_DTMOVTO);

            /*" -3601- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_TIME);

            /*" -3602- MOVE WS000-H TO WS000-HT */
            _.Move(WS_TIME.WS000_H, WS000_HORA_TIME_REDF.WS000_HT);

            /*" -3603- MOVE WS000-M TO WS000-MT */
            _.Move(WS_TIME.WS000_M, WS000_HORA_TIME_REDF.WS000_MT);

            /*" -3604- MOVE WS000-S TO WS000-ST */
            _.Move(WS_TIME.WS000_S, WS000_HORA_TIME_REDF.WS000_ST);

            /*" -3606- MOVE WS000-HORA-TIME TO V0HISP-HORAOPER. */
            _.Move(WS000_HORA_TIME, V0HISP_HORAOPER);

            /*" -3608- MOVE 2 TO V0HISP-OCORHIST. */
            _.Move(2, V0HISP_OCORHIST);

            /*" -3609- MOVE V0PARC-PRM-TAR-IX TO V0HISP-PRM-TARIFA */
            _.Move(V0PARC_PRM_TAR_IX, V0HISP_PRM_TARIFA);

            /*" -3610- MOVE V0PARC-VAL-DES-IX TO V0HISP-VAL-DESCON */
            _.Move(V0PARC_VAL_DES_IX, V0HISP_VAL_DESCON);

            /*" -3611- MOVE V0PARC-OTNPRLIQ TO V0HISP-VLPRMLIQ */
            _.Move(V0PARC_OTNPRLIQ, V0HISP_VLPRMLIQ);

            /*" -3612- MOVE V0PARC-OTNADFRA TO V0HISP-VLADIFRA */
            _.Move(V0PARC_OTNADFRA, V0HISP_VLADIFRA);

            /*" -3613- MOVE V0PARC-OTNCUSTO TO V0HISP-VLCUSEMI */
            _.Move(V0PARC_OTNCUSTO, V0HISP_VLCUSEMI);

            /*" -3614- MOVE V0PARC-OTNIOF TO V0HISP-VLIOCC */
            _.Move(V0PARC_OTNIOF, V0HISP_VLIOCC);

            /*" -3615- MOVE V0PARC-OTNTOTAL TO V0HISP-VLPRMTOT */
            _.Move(V0PARC_OTNTOTAL, V0HISP_VLPRMTOT);

            /*" -3616- MOVE V2RCAP-VLRCAP TO V0HISP-VLPREMIO */
            _.Move(V2RCAP_VLRCAP, V0HISP_VLPREMIO);

            /*" -3617- MOVE V0ENDO-DATARCAP TO V0HISP-DTVENCTO */
            _.Move(V0ENDO_DATARCAP, V0HISP_DTVENCTO);

            /*" -3618- MOVE V1RCAC-BCOAVISO TO V0HISP-BCOCOBR */
            _.Move(V1RCAC_BCOAVISO, V0HISP_BCOCOBR);

            /*" -3619- MOVE V1RCAC-AGEAVISO TO V0HISP-AGECOBR */
            _.Move(V1RCAC_AGEAVISO, V0HISP_AGECOBR);

            /*" -3620- MOVE V1RCAC-NRAVISO TO V0HISP-NRAVISO */
            _.Move(V1RCAC_NRAVISO, V0HISP_NRAVISO);

            /*" -3621- MOVE ZEROS TO V0HISP-NRENDOCA */
            _.Move(0, V0HISP_NRENDOCA);

            /*" -3622- MOVE '0' TO V0HISP-SITCONTB */
            _.Move("0", V0HISP_SITCONTB);

            /*" -3623- MOVE 'BI8005B' TO V0HISP-COD-USUAR */
            _.Move("BI8005B", V0HISP_COD_USUAR);

            /*" -3624- MOVE ZEROS TO V0HISP-RNUDOC */
            _.Move(0, V0HISP_RNUDOC);

            /*" -3625- MOVE +0 TO VIND-DTQITBCO */
            _.Move(+0, VIND_DTQITBCO);

            /*" -3627- MOVE V0BILH-DTQITBCO TO V0HISP-DTQITBCO. */
            _.Move(V0BILH_DTQITBCO, V0HISP_DTQITBCO);

            /*" -3630- MOVE ZEROS TO V0HISP-COD-EMPRESA. */
            _.Move(0, V0HISP_COD_EMPRESA);

            /*" -3636- PERFORM R0550-00-INSERT-V0HISTOPARC. */

            R0550_00_INSERT_V0HISTOPARC_SECTION();

            /*" -3637- MOVE V0ENDO-NUM-APOL TO V0COBA-NUM-APOL. */
            _.Move(V0ENDO_NUM_APOL, V0COBA_NUM_APOL);

            /*" -3638- MOVE V0ENDO-NRENDOS TO V0COBA-NRENDOS. */
            _.Move(V0ENDO_NRENDOS, V0COBA_NRENDOS);

            /*" -3639- MOVE ZEROS TO V0COBA-NUM-ITEM */
            _.Move(0, V0COBA_NUM_ITEM);

            /*" -3640- MOVE 1 TO V0COBA-OCORHIST */
            _.Move(1, V0COBA_OCORHIST);

            /*" -3641- MOVE WWORK-RAMO-ANT TO V0COBA-RAMOFR. */
            _.Move(WWORK_RAMO_ANT, V0COBA_RAMOFR);

            /*" -3642- MOVE V0APOL-MODALIDA TO V0COBA-MODALIFR */
            _.Move(V0APOL_MODALIDA, V0COBA_MODALIFR);

            /*" -3643- MOVE ZEROS TO V0COBA-COD-COBER */
            _.Move(0, V0COBA_COD_COBER);

            /*" -3644- MOVE WWORK-IS-APOL TO V0COBA-IMP-SEG-IX */
            _.Move(AREA_DE_WORK.WWORK_IS_APOL, V0COBA_IMP_SEG_IX);

            /*" -3645- MOVE WWORK-PR-APOL TO V0COBA-PRM-TAR-IX */
            _.Move(AREA_DE_WORK.WWORK_PR_APOL, V0COBA_PRM_TAR_IX);

            /*" -3646- MOVE WWORK-IS-APOL TO V0COBA-IMP-SEG-VR */
            _.Move(AREA_DE_WORK.WWORK_IS_APOL, V0COBA_IMP_SEG_VR);

            /*" -3647- MOVE WWORK-PR-APOL TO V0COBA-PRM-TAR-VR */
            _.Move(AREA_DE_WORK.WWORK_PR_APOL, V0COBA_PRM_TAR_VR);

            /*" -3648- MOVE 100 TO V0COBA-PCT-COBERT. */
            _.Move(100, V0COBA_PCT_COBERT);

            /*" -3649- MOVE 1 TO V0COBA-FATOR-MULT */
            _.Move(1, V0COBA_FATOR_MULT);

            /*" -3650- MOVE V0ENDO-DTINIVIG TO V0COBA-DATA-INIVI. */
            _.Move(V0ENDO_DTINIVIG, V0COBA_DATA_INIVI);

            /*" -3651- MOVE V0ENDO-DTTERVIG TO V0COBA-DATA-TERVI. */
            _.Move(V0ENDO_DTTERVIG, V0COBA_DATA_TERVI);

            /*" -3652- MOVE ZEROS TO V0COBA-COD-EMPRESA */
            _.Move(0, V0COBA_COD_EMPRESA);

            /*" -3653- MOVE '0' TO V0COBA-SITUACAO */
            _.Move("0", V0COBA_SITUACAO);

            /*" -3656- MOVE +0 TO VIND-SITUACAO. */
            _.Move(+0, VIND_SITUACAO);

            /*" -3656- PERFORM R0560-00-INSERT-V0COBERAPOL. */

            R0560_00_INSERT_V0COBERAPOL_SECTION();

        }

        [StopWatch]
        /*" R0600-00-MONTA-ENDOSSO01-DB-UPDATE-1 */
        public void R0600_00_MONTA_ENDOSSO01_DB_UPDATE_1()
        {
            /*" -3479- EXEC SQL UPDATE SEGUROS.V0FONTE SET PROPAUTOM = :V1FONT-PROPAUTOM WHERE FONTE = :V0BILH-FONTE END-EXEC. */

            var r0600_00_MONTA_ENDOSSO01_DB_UPDATE_1_Update1 = new R0600_00_MONTA_ENDOSSO01_DB_UPDATE_1_Update1()
            {
                V1FONT_PROPAUTOM = V1FONT_PROPAUTOM.ToString(),
                V0BILH_FONTE = V0BILH_FONTE.ToString(),
            };

            R0600_00_MONTA_ENDOSSO01_DB_UPDATE_1_Update1.Execute(r0600_00_MONTA_ENDOSSO01_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R0600-00-MONTA-ENDOSSO01-DB-SELECT-1 */
        public void R0600_00_MONTA_ENDOSSO01_DB_SELECT_1()
        {
            /*" -3492- EXEC SQL SELECT DATE(:V0ENDO-DTINIVIG) + 1 MONTH - 1 DAY INTO :WHOST-DTINIVIG FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'BI' END-EXEC. */

            var r0600_00_MONTA_ENDOSSO01_DB_SELECT_1_Query1 = new R0600_00_MONTA_ENDOSSO01_DB_SELECT_1_Query1()
            {
                V0ENDO_DTINIVIG = V0ENDO_DTINIVIG.ToString(),
            };

            var executed_1 = R0600_00_MONTA_ENDOSSO01_DB_SELECT_1_Query1.Execute(r0600_00_MONTA_ENDOSSO01_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DTINIVIG, WHOST_DTINIVIG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/

        [StopWatch]
        /*" R0700-00-MONTA-ENDOSSO-UNICO-SECTION */
        private void R0700_00_MONTA_ENDOSSO_UNICO_SECTION()
        {
            /*" -3672- MOVE '0700' TO WNR-EXEC-SQL. */
            _.Move("0700", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3673- MOVE V0APOL-NUM-APOL TO V0ENDO-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0ENDO_NUM_APOL);

            /*" -3674- MOVE ZEROS TO V0ENDO-NRENDOS */
            _.Move(0, V0ENDO_NRENDOS);

            /*" -3675- MOVE ZEROS TO V0ENDO-CODSUBES */
            _.Move(0, V0ENDO_CODSUBES);

            /*" -3676- MOVE V0BILH-FONTE TO V0ENDO-FONTE */
            _.Move(V0BILH_FONTE, V0ENDO_FONTE);

            /*" -3677- MOVE V1FONT-PROPAUTOM TO V0ENDO-NRPROPOS */
            _.Move(V1FONT_PROPAUTOM, V0ENDO_NRPROPOS);

            /*" -3678- MOVE V1SIST-DTMOVACB TO V0ENDO-DT-LIBER */
            _.Move(V1SIST_DTMOVACB, V0ENDO_DT_LIBER);

            /*" -3679- MOVE V1SIST-DTMOVACB TO V0ENDO-DTEMIS */
            _.Move(V1SIST_DTMOVACB, V0ENDO_DTEMIS);

            /*" -3681- MOVE 104 TO V0ENDO-BCORCAP V0ENDO-BCOCOBR. */
            _.Move(104, V0ENDO_BCORCAP, V0ENDO_BCOCOBR);

            /*" -3682- MOVE V0BILH-AGECOBR TO V0ENDO-AGERCAP. */
            _.Move(V0BILH_AGECOBR, V0ENDO_AGERCAP);

            /*" -3683- MOVE V1RCAC-AGEAVISO TO V0ENDO-AGECOBR. */
            _.Move(V1RCAC_AGEAVISO, V0ENDO_AGECOBR);

            /*" -3684- MOVE '0' TO V0ENDO-DACCOBR */
            _.Move("0", V0ENDO_DACCOBR);

            /*" -3685- MOVE WWORK-NRRCAP TO V0ENDO-NRRCAP */
            _.Move(AREA_DE_WORK.FILLER_4.WWORK_NRRCAP, V0ENDO_NRRCAP);

            /*" -3686- MOVE V0BILH-VLRCAP TO V0ENDO-VLRCAP. */
            _.Move(V0BILH_VLRCAP, V0ENDO_VLRCAP);

            /*" -3687- MOVE '0' TO V0ENDO-DACRCAP */
            _.Move("0", V0ENDO_DACRCAP);

            /*" -3688- MOVE '0' TO V0ENDO-IDRCAP */
            _.Move("0", V0ENDO_IDRCAP);

            /*" -3689- MOVE V0BILH-DTQITBCO TO V0ENDO-DATARCAP */
            _.Move(V0BILH_DTQITBCO, V0ENDO_DATARCAP);

            /*" -3690- MOVE +0 TO VIND-DATARCAP. */
            _.Move(+0, VIND_DATARCAP);

            /*" -3691- MOVE WWORK-MIN-DTINIVIG TO V0ENDO-DTINIVIG. */
            _.Move(WWORK_MIN_DTINIVIG, V0ENDO_DTINIVIG);

            /*" -3692- MOVE WWORK-MIN-DTINIVIG TO WWORK-MIN-DTINIVIG-COB. */
            _.Move(WWORK_MIN_DTINIVIG, WWORK_MIN_DTINIVIG_COB);

            /*" -3693- MOVE WWORK-MIN-DTINIVIG TO V0ENDO-DATPRO. */
            _.Move(WWORK_MIN_DTINIVIG, V0ENDO_DATPRO);

            /*" -3694- MOVE WWORK-MAX-DTTERVIG TO V0ENDO-DTTERVIG. */
            _.Move(WWORK_MAX_DTTERVIG, V0ENDO_DTTERVIG);

            /*" -3695- MOVE WWORK-MAX-DTTERVIG TO WWORK-MAX-DTTERVIG-COB. */
            _.Move(WWORK_MAX_DTTERVIG, WWORK_MAX_DTTERVIG_COB);

            /*" -3696- MOVE ZEROS TO V0ENDO-PCENTRAD */
            _.Move(0, V0ENDO_PCENTRAD);

            /*" -3697- MOVE ZEROS TO V0ENDO-PCADICIO */
            _.Move(0, V0ENDO_PCADICIO);

            /*" -3698- MOVE ZEROS TO V0ENDO-PRESTA1 */
            _.Move(0, V0ENDO_PRESTA1);

            /*" -3699- MOVE ZEROS TO V0ENDO-QTPARCEL */
            _.Move(0, V0ENDO_QTPARCEL);

            /*" -3700- MOVE ZEROS TO V0ENDO-CDFRACIO */
            _.Move(0, V0ENDO_CDFRACIO);

            /*" -3701- MOVE ZEROS TO V0ENDO-QTPRESTA */
            _.Move(0, V0ENDO_QTPRESTA);

            /*" -3702- MOVE 1 TO V0ENDO-QTITENS */
            _.Move(1, V0ENDO_QTITENS);

            /*" -3703- MOVE SPACES TO V0ENDO-CODTXT */
            _.Move("", V0ENDO_CODTXT);

            /*" -3704- MOVE ZEROS TO V0ENDO-CDACEITA */
            _.Move(0, V0ENDO_CDACEITA);

            /*" -3706- MOVE V1BILC-CODUNIMO TO V0ENDO-MOEDA-IMP V0ENDO-MOEDA-PRM. */
            _.Move(V1BILC_CODUNIMO, V0ENDO_MOEDA_IMP, V0ENDO_MOEDA_PRM);

            /*" -3707- MOVE '0' TO V0ENDO-TIPO-ENDO */
            _.Move("0", V0ENDO_TIPO_ENDO);

            /*" -3708- MOVE 'BI8005B' TO V0ENDO-COD-USUAR */
            _.Move("BI8005B", V0ENDO_COD_USUAR);

            /*" -3709- MOVE 1 TO V0ENDO-OCORR-END. */
            _.Move(1, V0ENDO_OCORR_END);

            /*" -3710- MOVE ZEROS TO V0ENDO-COD-EMPRESA */
            _.Move(0, V0ENDO_COD_EMPRESA);

            /*" -3711- MOVE '1' TO V0ENDO-CORRECAO */
            _.Move("1", V0ENDO_CORRECAO);

            /*" -3712- MOVE 'S' TO V0ENDO-ISENTA-CST */
            _.Move("S", V0ENDO_ISENTA_CST);

            /*" -3713- MOVE -1 TO VIND-DTVENCTO */
            _.Move(-1, VIND_DTVENCTO);

            /*" -3714- MOVE -1 TO VIND-VLCUSEMI */
            _.Move(-1, VIND_VLCUSEMI);

            /*" -3715- MOVE -1 TO VIND-CFPREFIX. */
            _.Move(-1, VIND_CFPREFIX);

            /*" -3716- MOVE V0APOL-RAMO TO V0ENDO-RAMO. */
            _.Move(V0APOL_RAMO, V0ENDO_RAMO);

            /*" -3717- MOVE V0APOL-CODPRODU TO V0ENDO-CODPRODU. */
            _.Move(V0APOL_CODPRODU, V0ENDO_CODPRODU);

            /*" -3723- MOVE '1' TO V0ENDO-SITUACAO. */
            _.Move("1", V0ENDO_SITUACAO);

            /*" -3724- IF V0BILH-RAMO EQUAL 69 */

            if (V0BILH_RAMO == 69)
            {

                /*" -3726- MOVE W-DATA-INI-VIG-VIAGEM TO WWORK-MIN-DTINIVIG WHOST-DTINIVIG */
                _.Move(AREA_DE_WORK.WWORK_VIGENCIA_VIAGEM.W_DATA_INI_VIG_VIAGEM, WWORK_MIN_DTINIVIG, WHOST_DTINIVIG);

                /*" -3728- MOVE W-DATA-FIM-VIG-VIAGEM TO WWORK-MAX-DTTERVIG WHOST-DTTERVIG */
                _.Move(AREA_DE_WORK.WWORK_VIGENCIA_VIAGEM.W_DATA_FIM_VIG_VIAGEM, WWORK_MAX_DTTERVIG, WHOST_DTTERVIG);

                /*" -3729- MOVE WWORK-MIN-DTINIVIG TO V0ENDO-DTINIVIG */
                _.Move(WWORK_MIN_DTINIVIG, V0ENDO_DTINIVIG);

                /*" -3730- MOVE WWORK-MIN-DTINIVIG TO WWORK-MIN-DTINIVIG-COB */
                _.Move(WWORK_MIN_DTINIVIG, WWORK_MIN_DTINIVIG_COB);

                /*" -3731- MOVE WWORK-MAX-DTTERVIG TO V0ENDO-DTTERVIG */
                _.Move(WWORK_MAX_DTTERVIG, V0ENDO_DTTERVIG);

                /*" -3734- MOVE WWORK-MAX-DTTERVIG TO WWORK-MAX-DTTERVIG-COB. */
                _.Move(WWORK_MAX_DTTERVIG, WWORK_MAX_DTTERVIG_COB);
            }


            /*" -3740- PERFORM R0530-00-INCLUI-ENDOSSO. */

            R0530_00_INCLUI_ENDOSSO_SECTION();

            /*" -3741- MOVE V0ENDO-NUM-APOL TO V0PARC-NUM-APOL */
            _.Move(V0ENDO_NUM_APOL, V0PARC_NUM_APOL);

            /*" -3742- MOVE V0ENDO-NRENDOS TO V0PARC-NRENDOS */
            _.Move(V0ENDO_NRENDOS, V0PARC_NRENDOS);

            /*" -3743- MOVE ZEROS TO V0PARC-NRPARCEL */
            _.Move(0, V0PARC_NRPARCEL);

            /*" -3744- MOVE '0' TO V0PARC-DACPARC */
            _.Move("0", V0PARC_DACPARC);

            /*" -3745- MOVE V0BILH-FONTE TO V0PARC-FONTE */
            _.Move(V0BILH_FONTE, V0PARC_FONTE);

            /*" -3746- MOVE V0BILH-NUMBIL TO V0PARC-NRTIT */
            _.Move(V0BILH_NUMBIL, V0PARC_NRTIT);

            /*" -3747- MOVE WWORK-PR-APOL TO V0PARC-PRM-TAR-IX */
            _.Move(AREA_DE_WORK.WWORK_PR_APOL, V0PARC_PRM_TAR_IX);

            /*" -3748- MOVE ZEROS TO V0PARC-VAL-DES-IX */
            _.Move(0, V0PARC_VAL_DES_IX);

            /*" -3749- MOVE WWORK-PR-APOL TO V0PARC-OTNPRLIQ */
            _.Move(AREA_DE_WORK.WWORK_PR_APOL, V0PARC_OTNPRLIQ);

            /*" -3750- MOVE ZEROS TO V0PARC-OTNADFRA */
            _.Move(0, V0PARC_OTNADFRA);

            /*" -3751- MOVE ZEROS TO V0PARC-OTNCUSTO */
            _.Move(0, V0PARC_OTNCUSTO);

            /*" -3752- MOVE WWORK-IOCC TO V0PARC-OTNIOF. */
            _.Move(AREA_DE_WORK.WWORK_IOCC, V0PARC_OTNIOF);

            /*" -3753- MOVE ZEROS TO V0PARC-OTNTOTAL. */
            _.Move(0, V0PARC_OTNTOTAL);

            /*" -3757- COMPUTE V0PARC-OTNTOTAL = V0PARC-OTNPRLIQ + V0PARC-OTNADFRA + V0PARC-OTNCUSTO + V0PARC-OTNIOF. */
            V0PARC_OTNTOTAL.Value = V0PARC_OTNPRLIQ + V0PARC_OTNADFRA + V0PARC_OTNCUSTO + V0PARC_OTNIOF;

            /*" -3758- MOVE 2 TO V0PARC-OCORHIST */
            _.Move(2, V0PARC_OCORHIST);

            /*" -3759- MOVE ZEROS TO V0PARC-QTDDOC */
            _.Move(0, V0PARC_QTDDOC);

            /*" -3760- MOVE '1' TO V0PARC-SITUACAO */
            _.Move("1", V0PARC_SITUACAO);

            /*" -3763- MOVE ZEROS TO V0PARC-COD-EMPRESA. */
            _.Move(0, V0PARC_COD_EMPRESA);

            /*" -3769- PERFORM R0540-00-INCLUI-PARCELAS. */

            R0540_00_INCLUI_PARCELAS_SECTION();

            /*" -3770- MOVE V0PARC-NUM-APOL TO V0HISP-NUM-APOL */
            _.Move(V0PARC_NUM_APOL, V0HISP_NUM_APOL);

            /*" -3771- MOVE V0PARC-NRENDOS TO V0HISP-NRENDOS */
            _.Move(V0PARC_NRENDOS, V0HISP_NRENDOS);

            /*" -3772- MOVE V0PARC-NRPARCEL TO V0HISP-NRPARCEL */
            _.Move(V0PARC_NRPARCEL, V0HISP_NRPARCEL);

            /*" -3773- MOVE '0' TO V0HISP-DACPARC */
            _.Move("0", V0HISP_DACPARC);

            /*" -3774- MOVE 0101 TO V0HISP-OPERACAO */
            _.Move(0101, V0HISP_OPERACAO);

            /*" -3776- MOVE V1SIST-DTMOVACB TO V0HISP-DTMOVTO */
            _.Move(V1SIST_DTMOVACB, V0HISP_DTMOVTO);

            /*" -3777- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_TIME);

            /*" -3778- MOVE WS000-H TO WS000-HT */
            _.Move(WS_TIME.WS000_H, WS000_HORA_TIME_REDF.WS000_HT);

            /*" -3779- MOVE WS000-M TO WS000-MT */
            _.Move(WS_TIME.WS000_M, WS000_HORA_TIME_REDF.WS000_MT);

            /*" -3780- MOVE WS000-S TO WS000-ST */
            _.Move(WS_TIME.WS000_S, WS000_HORA_TIME_REDF.WS000_ST);

            /*" -3782- MOVE WS000-HORA-TIME TO V0HISP-HORAOPER. */
            _.Move(WS000_HORA_TIME, V0HISP_HORAOPER);

            /*" -3784- MOVE 1 TO V0HISP-OCORHIST. */
            _.Move(1, V0HISP_OCORHIST);

            /*" -3785- MOVE V0PARC-PRM-TAR-IX TO V0HISP-PRM-TARIFA */
            _.Move(V0PARC_PRM_TAR_IX, V0HISP_PRM_TARIFA);

            /*" -3786- MOVE V0PARC-VAL-DES-IX TO V0HISP-VAL-DESCON */
            _.Move(V0PARC_VAL_DES_IX, V0HISP_VAL_DESCON);

            /*" -3787- MOVE V0PARC-OTNPRLIQ TO V0HISP-VLPRMLIQ */
            _.Move(V0PARC_OTNPRLIQ, V0HISP_VLPRMLIQ);

            /*" -3788- MOVE V0PARC-OTNADFRA TO V0HISP-VLADIFRA */
            _.Move(V0PARC_OTNADFRA, V0HISP_VLADIFRA);

            /*" -3789- MOVE V0PARC-OTNCUSTO TO V0HISP-VLCUSEMI */
            _.Move(V0PARC_OTNCUSTO, V0HISP_VLCUSEMI);

            /*" -3790- MOVE V0PARC-OTNIOF TO V0HISP-VLIOCC */
            _.Move(V0PARC_OTNIOF, V0HISP_VLIOCC);

            /*" -3791- MOVE V0PARC-OTNTOTAL TO V0HISP-VLPRMTOT */
            _.Move(V0PARC_OTNTOTAL, V0HISP_VLPRMTOT);

            /*" -3792- MOVE ZEROS TO V0HISP-VLPREMIO */
            _.Move(0, V0HISP_VLPREMIO);

            /*" -3793- MOVE V1SIST-DTMOVACB TO V0HISP-DTVENCTO */
            _.Move(V1SIST_DTMOVACB, V0HISP_DTVENCTO);

            /*" -3794- MOVE 104 TO V0HISP-BCOCOBR */
            _.Move(104, V0HISP_BCOCOBR);

            /*" -3795- MOVE V0ENDO-AGECOBR TO V0HISP-AGECOBR */
            _.Move(V0ENDO_AGECOBR, V0HISP_AGECOBR);

            /*" -3796- MOVE ZEROS TO V0HISP-NRAVISO */
            _.Move(0, V0HISP_NRAVISO);

            /*" -3797- MOVE ZEROS TO V0HISP-NRENDOCA */
            _.Move(0, V0HISP_NRENDOCA);

            /*" -3798- MOVE '0' TO V0HISP-SITCONTB */
            _.Move("0", V0HISP_SITCONTB);

            /*" -3799- MOVE 'BI8005B' TO V0HISP-COD-USUAR */
            _.Move("BI8005B", V0HISP_COD_USUAR);

            /*" -3801- MOVE ZEROS TO V0HISP-RNUDOC */
            _.Move(0, V0HISP_RNUDOC);

            /*" -3803- MOVE -1 TO VIND-DTQITBCO */
            _.Move(-1, VIND_DTQITBCO);

            /*" -3806- MOVE ZEROS TO V0HISP-COD-EMPRESA. */
            _.Move(0, V0HISP_COD_EMPRESA);

            /*" -3812- PERFORM R0550-00-INSERT-V0HISTOPARC. */

            R0550_00_INSERT_V0HISTOPARC_SECTION();

            /*" -3813- MOVE V0PARC-NUM-APOL TO V0HISP-NUM-APOL */
            _.Move(V0PARC_NUM_APOL, V0HISP_NUM_APOL);

            /*" -3814- MOVE V0PARC-NRENDOS TO V0HISP-NRENDOS */
            _.Move(V0PARC_NRENDOS, V0HISP_NRENDOS);

            /*" -3815- MOVE V0PARC-NRPARCEL TO V0HISP-NRPARCEL */
            _.Move(V0PARC_NRPARCEL, V0HISP_NRPARCEL);

            /*" -3816- MOVE '0' TO V0HISP-DACPARC */
            _.Move("0", V0HISP_DACPARC);

            /*" -3817- MOVE 0201 TO V0HISP-OPERACAO */
            _.Move(0201, V0HISP_OPERACAO);

            /*" -3819- MOVE V1SIST-DTMOVACB TO V0HISP-DTMOVTO */
            _.Move(V1SIST_DTMOVACB, V0HISP_DTMOVTO);

            /*" -3820- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_TIME);

            /*" -3821- MOVE WS000-H TO WS000-HT */
            _.Move(WS_TIME.WS000_H, WS000_HORA_TIME_REDF.WS000_HT);

            /*" -3822- MOVE WS000-M TO WS000-MT */
            _.Move(WS_TIME.WS000_M, WS000_HORA_TIME_REDF.WS000_MT);

            /*" -3823- MOVE WS000-S TO WS000-ST */
            _.Move(WS_TIME.WS000_S, WS000_HORA_TIME_REDF.WS000_ST);

            /*" -3825- MOVE WS000-HORA-TIME TO V0HISP-HORAOPER. */
            _.Move(WS000_HORA_TIME, V0HISP_HORAOPER);

            /*" -3827- MOVE 2 TO V0HISP-OCORHIST. */
            _.Move(2, V0HISP_OCORHIST);

            /*" -3828- MOVE V0PARC-PRM-TAR-IX TO V0HISP-PRM-TARIFA */
            _.Move(V0PARC_PRM_TAR_IX, V0HISP_PRM_TARIFA);

            /*" -3829- MOVE V0PARC-VAL-DES-IX TO V0HISP-VAL-DESCON */
            _.Move(V0PARC_VAL_DES_IX, V0HISP_VAL_DESCON);

            /*" -3830- MOVE V0PARC-OTNPRLIQ TO V0HISP-VLPRMLIQ */
            _.Move(V0PARC_OTNPRLIQ, V0HISP_VLPRMLIQ);

            /*" -3831- MOVE V0PARC-OTNADFRA TO V0HISP-VLADIFRA */
            _.Move(V0PARC_OTNADFRA, V0HISP_VLADIFRA);

            /*" -3832- MOVE V0PARC-OTNCUSTO TO V0HISP-VLCUSEMI */
            _.Move(V0PARC_OTNCUSTO, V0HISP_VLCUSEMI);

            /*" -3833- MOVE V0PARC-OTNIOF TO V0HISP-VLIOCC */
            _.Move(V0PARC_OTNIOF, V0HISP_VLIOCC);

            /*" -3834- MOVE V0PARC-OTNTOTAL TO V0HISP-VLPRMTOT */
            _.Move(V0PARC_OTNTOTAL, V0HISP_VLPRMTOT);

            /*" -3835- MOVE V2RCAP-VLRCAP TO V0HISP-VLPREMIO */
            _.Move(V2RCAP_VLRCAP, V0HISP_VLPREMIO);

            /*" -3836- MOVE V0ENDO-DATARCAP TO V0HISP-DTVENCTO */
            _.Move(V0ENDO_DATARCAP, V0HISP_DTVENCTO);

            /*" -3837- MOVE V1RCAC-BCOAVISO TO V0HISP-BCOCOBR */
            _.Move(V1RCAC_BCOAVISO, V0HISP_BCOCOBR);

            /*" -3838- MOVE V1RCAC-AGEAVISO TO V0HISP-AGECOBR */
            _.Move(V1RCAC_AGEAVISO, V0HISP_AGECOBR);

            /*" -3839- MOVE V1RCAC-NRAVISO TO V0HISP-NRAVISO */
            _.Move(V1RCAC_NRAVISO, V0HISP_NRAVISO);

            /*" -3840- MOVE ZEROS TO V0HISP-NRENDOCA */
            _.Move(0, V0HISP_NRENDOCA);

            /*" -3841- MOVE '0' TO V0HISP-SITCONTB */
            _.Move("0", V0HISP_SITCONTB);

            /*" -3842- MOVE 'BI8005B' TO V0HISP-COD-USUAR */
            _.Move("BI8005B", V0HISP_COD_USUAR);

            /*" -3843- MOVE ZEROS TO V0HISP-RNUDOC */
            _.Move(0, V0HISP_RNUDOC);

            /*" -3844- MOVE +0 TO VIND-DTQITBCO */
            _.Move(+0, VIND_DTQITBCO);

            /*" -3846- MOVE V0BILH-DTQITBCO TO V0HISP-DTQITBCO. */
            _.Move(V0BILH_DTQITBCO, V0HISP_DTQITBCO);

            /*" -3849- MOVE ZEROS TO V0HISP-COD-EMPRESA. */
            _.Move(0, V0HISP_COD_EMPRESA);

            /*" -3855- PERFORM R0550-00-INSERT-V0HISTOPARC. */

            R0550_00_INSERT_V0HISTOPARC_SECTION();

            /*" -3856- MOVE V0ENDO-NUM-APOL TO V0COBA-NUM-APOL. */
            _.Move(V0ENDO_NUM_APOL, V0COBA_NUM_APOL);

            /*" -3857- MOVE V0ENDO-NRENDOS TO V0COBA-NRENDOS. */
            _.Move(V0ENDO_NRENDOS, V0COBA_NRENDOS);

            /*" -3858- MOVE ZEROS TO V0COBA-NUM-ITEM */
            _.Move(0, V0COBA_NUM_ITEM);

            /*" -3859- MOVE 1 TO V0COBA-OCORHIST */
            _.Move(1, V0COBA_OCORHIST);

            /*" -3860- MOVE WWORK-RAMO-ANT TO V0COBA-RAMOFR. */
            _.Move(WWORK_RAMO_ANT, V0COBA_RAMOFR);

            /*" -3861- MOVE V0APOL-MODALIDA TO V0COBA-MODALIFR */
            _.Move(V0APOL_MODALIDA, V0COBA_MODALIFR);

            /*" -3862- MOVE ZEROS TO V0COBA-COD-COBER */
            _.Move(0, V0COBA_COD_COBER);

            /*" -3863- MOVE WWORK-IS-APOL TO V0COBA-IMP-SEG-IX */
            _.Move(AREA_DE_WORK.WWORK_IS_APOL, V0COBA_IMP_SEG_IX);

            /*" -3864- MOVE WWORK-PR-APOL TO V0COBA-PRM-TAR-IX */
            _.Move(AREA_DE_WORK.WWORK_PR_APOL, V0COBA_PRM_TAR_IX);

            /*" -3865- MOVE WWORK-IS-APOL TO V0COBA-IMP-SEG-VR */
            _.Move(AREA_DE_WORK.WWORK_IS_APOL, V0COBA_IMP_SEG_VR);

            /*" -3866- MOVE WWORK-PR-APOL TO V0COBA-PRM-TAR-VR */
            _.Move(AREA_DE_WORK.WWORK_PR_APOL, V0COBA_PRM_TAR_VR);

            /*" -3867- MOVE 100 TO V0COBA-PCT-COBERT. */
            _.Move(100, V0COBA_PCT_COBERT);

            /*" -3868- MOVE 1 TO V0COBA-FATOR-MULT */
            _.Move(1, V0COBA_FATOR_MULT);

            /*" -3869- MOVE V0ENDO-DTINIVIG TO V0COBA-DATA-INIVI. */
            _.Move(V0ENDO_DTINIVIG, V0COBA_DATA_INIVI);

            /*" -3870- MOVE V0ENDO-DTTERVIG TO V0COBA-DATA-TERVI. */
            _.Move(V0ENDO_DTTERVIG, V0COBA_DATA_TERVI);

            /*" -3871- MOVE ZEROS TO V0COBA-COD-EMPRESA */
            _.Move(0, V0COBA_COD_EMPRESA);

            /*" -3872- MOVE '0' TO V0COBA-SITUACAO */
            _.Move("0", V0COBA_SITUACAO);

            /*" -3875- MOVE +0 TO VIND-SITUACAO. */
            _.Move(+0, VIND_SITUACAO);

            /*" -3875- PERFORM R0560-00-INSERT-V0COBERAPOL. */

            R0560_00_INSERT_V0COBERAPOL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/

        [StopWatch]
        /*" R1066-00-TRATA-EVOGEPES016-SECTION */
        private void R1066_00_TRATA_EVOGEPES016_SECTION()
        {
            /*" -3888- MOVE '1066' TO WNR-EXEC-SQL. */
            _.Move("1066", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3891- PERFORM R1070-00-TRATA-PRO-LABORE. */

            R1070_00_TRATA_PRO_LABORE_SECTION();

            /*" -3897- MOVE 'S' TO WWORK-FUNDAO. */
            _.Move("S", AREA_DE_WORK.WWORK_FUNDAO);

            /*" -3909- PERFORM R1066_00_TRATA_EVOGEPES016_DB_SELECT_1 */

            R1066_00_TRATA_EVOGEPES016_DB_SELECT_1();

            /*" -3912- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3913- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3916- MOVE ZEROS TO PARAMPRO-VALOR-COMISSAO-PRD PARAMPRO-PERCEN-COMIS-FUNC */
                    _.Move(0, PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_VALOR_COMISSAO_PRD, PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC);

                    /*" -3917- ELSE */
                }
                else
                {


                    /*" -3918- DISPLAY 'R1066-00 - PROBLEMAS SELECT PARAMPRO TIPO 1' */
                    _.Display($"R1066-00 - PROBLEMAS SELECT PARAMPRO TIPO 1");

                    /*" -3921- DISPLAY 'BILHETE : ' V0BILH-NUMBIL '  ' 'PRODUTO : ' V0ENDO-CODPRODU 'INICIO  : ' V0ENDO-DTINIVIG */

                    $"BILHETE : {V0BILH_NUMBIL}  PRODUTO : {V0ENDO_CODPRODU}INICIO  : {V0ENDO_DTINIVIG}"
                    .Display();

                    /*" -3923- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3925- MOVE V0BILH-VLRCAP TO AUX-VALBAS */
            _.Move(V0BILH_VLRCAP, AREA_DE_WORK.AUX_VALBAS);

            /*" -3927- IF PARAMPRO-VALOR-COMISSAO-PRD EQUAL ZEROS AND PARAMPRO-PERCEN-COMIS-FUNC EQUAL ZEROS */

            if (PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_VALOR_COMISSAO_PRD == 00 && PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC == 00)
            {

                /*" -3928- MOVE 7005 TO V0APCR-CODCORR */
                _.Move(7005, V0APCR_CODCORR);

                /*" -3929- MOVE 100 TO V0APCR-PCPARCOR */
                _.Move(100, V0APCR_PCPARCOR);

                /*" -3930- PERFORM R1067-00-TRATA-CORRETOR */

                R1067_00_TRATA_CORRETOR_SECTION();

                /*" -3933- GO TO R1066-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1066_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3934- MOVE 19224 TO V0APCR-CODCORR. */
            _.Move(19224, V0APCR_CODCORR);

            /*" -3936- MOVE 50 TO V0APCR-PCPARCOR. */
            _.Move(50, V0APCR_PCPARCOR);

            /*" -3938- MOVE ZEROS TO AUX-PERCENT. */
            _.Move(0, AREA_DE_WORK.AUX_PERCENT);

            /*" -3939- IF PARAMPRO-PERCEN-COMIS-FUNC NOT EQUAL ZEROS */

            if (PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC != 00)
            {

                /*" -3941- COMPUTE AUX-PERCENT EQUAL (PARAMPRO-PERCEN-COMIS-FUNC * 2) */
                AREA_DE_WORK.AUX_PERCENT.Value = (PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC * 2);

                /*" -3942- ELSE */
            }
            else
            {


                /*" -3945- COMPUTE AUX-VALBAS EQUAL (V1BILC-PRMTAR-IX * V0APCR-PCPARCOR) / 100 */
                AREA_DE_WORK.AUX_VALBAS.Value = (V1BILC_PRMTAR_IX * V0APCR_PCPARCOR) / 100f;

                /*" -3949- COMPUTE AUX-PERCENT EQUAL (PARAMPRO-VALOR-COMISSAO-PRD / AUX-VALBAS) * 100. */
                AREA_DE_WORK.AUX_PERCENT.Value = (PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_VALOR_COMISSAO_PRD / AREA_DE_WORK.AUX_VALBAS) * 100;
            }


            /*" -3951- MOVE AUX-PERCENT TO V0APCR-PCCOMCOR. */
            _.Move(AREA_DE_WORK.AUX_PERCENT, V0APCR_PCCOMCOR);

            /*" -3952- MOVE V0APOL-NUM-APOL TO V0APCR-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0APCR_NUM_APOL);

            /*" -3953- MOVE ZEROS TO V0APCR-CODSUBES */
            _.Move(0, V0APCR_CODSUBES);

            /*" -3954- MOVE V0ENDO-DTINIVIG TO V0APCR-DTINIVIG */
            _.Move(V0ENDO_DTINIVIG, V0APCR_DTINIVIG);

            /*" -3955- MOVE V0ENDO-DTTERVIG TO V0APCR-DTTERVIG */
            _.Move(V0ENDO_DTTERVIG, V0APCR_DTTERVIG);

            /*" -3956- MOVE WWORK-RAMO-ANT TO V0APCR-RAMOFR */
            _.Move(WWORK_RAMO_ANT, V0APCR_RAMOFR);

            /*" -3957- MOVE 0 TO V0APCR-MODALIFR */
            _.Move(0, V0APCR_MODALIFR);

            /*" -3958- MOVE '1' TO V0APCR-TIPCOM */
            _.Move("1", V0APCR_TIPCOM);

            /*" -3959- MOVE '2' TO V0APCR-INDCRT */
            _.Move("2", V0APCR_INDCRT);

            /*" -3961- MOVE ZEROS TO V0APCR-COD-EMPRESA. */
            _.Move(0, V0APCR_COD_EMPRESA);

            /*" -3963- MOVE 'BI8005B' TO V0APCR-COD-USUARIO. */
            _.Move("BI8005B", V0APCR_COD_USUARIO);

            /*" -3966- PERFORM R1068-00-INSERT-APOLCORRET. */

            R1068_00_INSERT_APOLCORRET_SECTION();

            /*" -3967- MOVE 17256 TO V0APCR-CODCORR */
            _.Move(17256, V0APCR_CODCORR);

            /*" -3968- MOVE 50 TO V0APCR-PCPARCOR */
            _.Move(50, V0APCR_PCPARCOR);

            /*" -3968- PERFORM R1067-00-TRATA-CORRETOR. */

            R1067_00_TRATA_CORRETOR_SECTION();

        }

        [StopWatch]
        /*" R1066-00-TRATA-EVOGEPES016-DB-SELECT-1 */
        public void R1066_00_TRATA_EVOGEPES016_DB_SELECT_1()
        {
            /*" -3909- EXEC SQL SELECT VALOR_COMISSAO_PRD , PERCEN_COMIS_FUNC INTO :PARAMPRO-VALOR-COMISSAO-PRD , :PARAMPRO-PERCEN-COMIS-FUNC FROM SEGUROS.PARAM_PRODUTO WHERE COD_PRODUTO = :V0ENDO-CODPRODU AND TIPO_FUNCIONARIO = '1' AND DATA_INIVIGENCIA <= :V0ENDO-DTINIVIG AND DATA_TERVIGENCIA >= :V0ENDO-DTINIVIG FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r1066_00_TRATA_EVOGEPES016_DB_SELECT_1_Query1 = new R1066_00_TRATA_EVOGEPES016_DB_SELECT_1_Query1()
            {
                V0ENDO_CODPRODU = V0ENDO_CODPRODU.ToString(),
                V0ENDO_DTINIVIG = V0ENDO_DTINIVIG.ToString(),
            };

            var executed_1 = R1066_00_TRATA_EVOGEPES016_DB_SELECT_1_Query1.Execute(r1066_00_TRATA_EVOGEPES016_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARAMPRO_VALOR_COMISSAO_PRD, PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_VALOR_COMISSAO_PRD);
                _.Move(executed_1.PARAMPRO_PERCEN_COMIS_FUNC, PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1066_99_SAIDA*/

        [StopWatch]
        /*" R1067-00-TRATA-CORRETOR-SECTION */
        private void R1067_00_TRATA_CORRETOR_SECTION()
        {
            /*" -3984- MOVE '1067' TO WNR-EXEC-SQL. */
            _.Move("1067", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3996- PERFORM R1067_00_TRATA_CORRETOR_DB_SELECT_1 */

            R1067_00_TRATA_CORRETOR_DB_SELECT_1();

            /*" -4000- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4001- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4004- MOVE ZEROS TO PARAMPRO-VALOR-COMISSAO-PRD PARAMPRO-PERCEN-COMIS-FUNC */
                    _.Move(0, PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_VALOR_COMISSAO_PRD, PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC);

                    /*" -4005- ELSE */
                }
                else
                {


                    /*" -4006- DISPLAY 'R1067-00 - PROBLEMAS SELECT PARAMPRO TIPO 8' */
                    _.Display($"R1067-00 - PROBLEMAS SELECT PARAMPRO TIPO 8");

                    /*" -4009- DISPLAY 'BILHETE : ' V0BILH-NUMBIL '  ' 'PRODUTO : ' V0ENDO-CODPRODU 'INICIO  : ' V0ENDO-DTINIVIG */

                    $"BILHETE : {V0BILH_NUMBIL}  PRODUTO : {V0ENDO_CODPRODU}INICIO  : {V0ENDO_DTINIVIG}"
                    .Display();

                    /*" -4012- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -4014- MOVE ZEROS TO AUX-PERCENT. */
            _.Move(0, AREA_DE_WORK.AUX_PERCENT);

            /*" -4016- IF PARAMPRO-PERCEN-COMIS-FUNC NOT EQUAL ZEROS AND V0APCR-PCPARCOR EQUAL 100 */

            if (PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC != 00 && V0APCR_PCPARCOR == 100)
            {

                /*" -4018- MOVE PARAMPRO-PERCEN-COMIS-FUNC TO AUX-PERCENT */
                _.Move(PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC, AREA_DE_WORK.AUX_PERCENT);

                /*" -4019- ELSE */
            }
            else
            {


                /*" -4020- IF PARAMPRO-PERCEN-COMIS-FUNC NOT EQUAL ZEROS */

                if (PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC != 00)
                {

                    /*" -4022- COMPUTE AUX-PERCENT EQUAL (PARAMPRO-PERCEN-COMIS-FUNC * 2) */
                    AREA_DE_WORK.AUX_PERCENT.Value = (PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC * 2);

                    /*" -4023- ELSE */
                }
                else
                {


                    /*" -4026- COMPUTE AUX-VALBAS EQUAL (V1BILC-PRMTAR-IX * V0APCR-PCPARCOR) / 100 */
                    AREA_DE_WORK.AUX_VALBAS.Value = (V1BILC_PRMTAR_IX * V0APCR_PCPARCOR) / 100f;

                    /*" -4030- COMPUTE AUX-PERCENT EQUAL (PARAMPRO-VALOR-COMISSAO-PRD / AUX-VALBAS) * 100. */
                    AREA_DE_WORK.AUX_PERCENT.Value = (PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_VALOR_COMISSAO_PRD / AREA_DE_WORK.AUX_VALBAS) * 100;
                }

            }


            /*" -4032- MOVE AUX-PERCENT TO V0APCR-PCCOMCOR. */
            _.Move(AREA_DE_WORK.AUX_PERCENT, V0APCR_PCCOMCOR);

            /*" -4033- MOVE V0APOL-NUM-APOL TO V0APCR-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0APCR_NUM_APOL);

            /*" -4034- MOVE ZEROS TO V0APCR-CODSUBES */
            _.Move(0, V0APCR_CODSUBES);

            /*" -4035- MOVE V0ENDO-DTINIVIG TO V0APCR-DTINIVIG */
            _.Move(V0ENDO_DTINIVIG, V0APCR_DTINIVIG);

            /*" -4036- MOVE V0ENDO-DTTERVIG TO V0APCR-DTTERVIG */
            _.Move(V0ENDO_DTTERVIG, V0APCR_DTTERVIG);

            /*" -4037- MOVE WWORK-RAMO-ANT TO V0APCR-RAMOFR */
            _.Move(WWORK_RAMO_ANT, V0APCR_RAMOFR);

            /*" -4038- MOVE 0 TO V0APCR-MODALIFR */
            _.Move(0, V0APCR_MODALIFR);

            /*" -4039- MOVE '1' TO V0APCR-TIPCOM */
            _.Move("1", V0APCR_TIPCOM);

            /*" -4040- MOVE '1' TO V0APCR-INDCRT */
            _.Move("1", V0APCR_INDCRT);

            /*" -4042- MOVE ZEROS TO V0APCR-COD-EMPRESA. */
            _.Move(0, V0APCR_COD_EMPRESA);

            /*" -4044- MOVE 'BI8005B' TO V0APCR-COD-USUARIO. */
            _.Move("BI8005B", V0APCR_COD_USUARIO);

            /*" -4044- PERFORM R1068-00-INSERT-APOLCORRET. */

            R1068_00_INSERT_APOLCORRET_SECTION();

        }

        [StopWatch]
        /*" R1067-00-TRATA-CORRETOR-DB-SELECT-1 */
        public void R1067_00_TRATA_CORRETOR_DB_SELECT_1()
        {
            /*" -3996- EXEC SQL SELECT VALOR_COMISSAO_PRD , PERCEN_COMIS_FUNC INTO :PARAMPRO-VALOR-COMISSAO-PRD , :PARAMPRO-PERCEN-COMIS-FUNC FROM SEGUROS.PARAM_PRODUTO WHERE COD_PRODUTO = :V0ENDO-CODPRODU AND TIPO_FUNCIONARIO = '8' AND DATA_INIVIGENCIA <= :V0ENDO-DTINIVIG AND DATA_TERVIGENCIA >= :V0ENDO-DTINIVIG FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r1067_00_TRATA_CORRETOR_DB_SELECT_1_Query1 = new R1067_00_TRATA_CORRETOR_DB_SELECT_1_Query1()
            {
                V0ENDO_CODPRODU = V0ENDO_CODPRODU.ToString(),
                V0ENDO_DTINIVIG = V0ENDO_DTINIVIG.ToString(),
            };

            var executed_1 = R1067_00_TRATA_CORRETOR_DB_SELECT_1_Query1.Execute(r1067_00_TRATA_CORRETOR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARAMPRO_VALOR_COMISSAO_PRD, PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_VALOR_COMISSAO_PRD);
                _.Move(executed_1.PARAMPRO_PERCEN_COMIS_FUNC, PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1066_99_SAIDA*/

        [StopWatch]
        /*" R1068-00-INSERT-APOLCORRET-SECTION */
        private void R1068_00_INSERT_APOLCORRET_SECTION()
        {
            /*" -4057- MOVE '1068' TO WNR-EXEC-SQL. */
            _.Move("1068", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4058- IF V0APCR-PCCOMCOR EQUAL ZEROS */

            if (V0APCR_PCCOMCOR == 00)
            {

                /*" -4060- GO TO R1068-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1068_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4061- MOVE V0APCR-CODCORR TO WS-COD-CORRETOR */
            _.Move(V0APCR_CODCORR, WS_COD_CORRETOR);

            /*" -4066- IF PRODUTO-COD-EMPRESA = 11 AND N88-COD-CORRETOR AND V0APCR-TIPCOM = '1' AND V1SIST-DTMOVACB >= '2021-08-16' AND V0BILH-NUM-APO-ANT = 0 */

            if (PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA == 11 && WS_COD_CORRETOR["N88_COD_CORRETOR"] && V0APCR_TIPCOM == "1" && V1SIST_DTMOVACB >= "2021-08-16" && V0BILH_NUM_APO_ANT == 0)
            {

                /*" -4067- MOVE 25267 TO V0APCR-CODCORR */
                _.Move(25267, V0APCR_CODCORR);

                /*" -4069- END-IF */
            }


            /*" -4085- PERFORM R1068_00_INSERT_APOLCORRET_DB_INSERT_1 */

            R1068_00_INSERT_APOLCORRET_DB_INSERT_1();

            /*" -4088- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4089- DISPLAY 'R1068-00 (ERRO - INSERT V0APOLCORRET)...' */
                _.Display($"R1068-00 (ERRO - INSERT V0APOLCORRET)...");

                /*" -4092- DISPLAY 'APOLICE: ' V0APCR-NUM-APOL '  ' 'RAMO:    ' V0APCR-RAMOFR '  ' 'OPCAO:   ' WWORK-OPCAO-ANT */

                $"APOLICE: {V0APCR_NUM_APOL}  RAMO:    {V0APCR_RAMOFR}  OPCAO:   {WWORK_OPCAO_ANT}"
                .Display();

                /*" -4094- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4094- ADD +1 TO AC-I-V0APOLCORRET. */
            AREA_DE_WORK.AC_I_V0APOLCORRET.Value = AREA_DE_WORK.AC_I_V0APOLCORRET + +1;

        }

        [StopWatch]
        /*" R1068-00-INSERT-APOLCORRET-DB-INSERT-1 */
        public void R1068_00_INSERT_APOLCORRET_DB_INSERT_1()
        {
            /*" -4085- EXEC SQL INSERT INTO SEGUROS.V0APOLCORRET VALUES (:V0APCR-NUM-APOL , :V0APCR-RAMOFR , :V0APCR-MODALIFR , :V0APCR-CODCORR , :V0APCR-CODSUBES , :V0APCR-DTINIVIG , :V0APCR-DTTERVIG , :V0APCR-PCPARCOR , :V0APCR-PCCOMCOR , :V0APCR-TIPCOM , :V0APCR-INDCRT , :V0APCR-COD-EMPRESA , CURRENT TIMESTAMP , :V0APCR-COD-USUARIO) END-EXEC. */

            var r1068_00_INSERT_APOLCORRET_DB_INSERT_1_Insert1 = new R1068_00_INSERT_APOLCORRET_DB_INSERT_1_Insert1()
            {
                V0APCR_NUM_APOL = V0APCR_NUM_APOL.ToString(),
                V0APCR_RAMOFR = V0APCR_RAMOFR.ToString(),
                V0APCR_MODALIFR = V0APCR_MODALIFR.ToString(),
                V0APCR_CODCORR = V0APCR_CODCORR.ToString(),
                V0APCR_CODSUBES = V0APCR_CODSUBES.ToString(),
                V0APCR_DTINIVIG = V0APCR_DTINIVIG.ToString(),
                V0APCR_DTTERVIG = V0APCR_DTTERVIG.ToString(),
                V0APCR_PCPARCOR = V0APCR_PCPARCOR.ToString(),
                V0APCR_PCCOMCOR = V0APCR_PCCOMCOR.ToString(),
                V0APCR_TIPCOM = V0APCR_TIPCOM.ToString(),
                V0APCR_INDCRT = V0APCR_INDCRT.ToString(),
                V0APCR_COD_EMPRESA = V0APCR_COD_EMPRESA.ToString(),
                V0APCR_COD_USUARIO = V0APCR_COD_USUARIO.ToString(),
            };

            R1068_00_INSERT_APOLCORRET_DB_INSERT_1_Insert1.Execute(r1068_00_INSERT_APOLCORRET_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1068_99_SAIDA*/

        [StopWatch]
        /*" R1070-00-TRATA-PRO-LABORE-SECTION */
        private void R1070_00_TRATA_PRO_LABORE_SECTION()
        {
            /*" -4111- MOVE '1070' TO WNR-EXEC-SQL. */
            _.Move("1070", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4112- MOVE 100081 TO V0APCR-CODCORR. */
            _.Move(100081, V0APCR_CODCORR);

            /*" -4115- MOVE 100 TO V0APCR-PCPARCOR. */
            _.Move(100, V0APCR_PCPARCOR);

            /*" -4127- PERFORM R1070_00_TRATA_PRO_LABORE_DB_SELECT_1 */

            R1070_00_TRATA_PRO_LABORE_DB_SELECT_1();

            /*" -4131- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4132- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4135- MOVE ZEROS TO PARAMPRO-VALOR-COMISSAO-PRD PARAMPRO-PERCEN-COMIS-FUNC */
                    _.Move(0, PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_VALOR_COMISSAO_PRD, PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC);

                    /*" -4136- ELSE */
                }
                else
                {


                    /*" -4137- DISPLAY 'R1070-00 - PROBLEMAS SELECT PARAMPRO TIPO T' */
                    _.Display($"R1070-00 - PROBLEMAS SELECT PARAMPRO TIPO T");

                    /*" -4140- DISPLAY 'BILHETE : ' V0BILH-NUMBIL '  ' 'PRODUTO : ' V0ENDO-CODPRODU 'INICIO  : ' V0ENDO-DTINIVIG */

                    $"BILHETE : {V0BILH_NUMBIL}  PRODUTO : {V0ENDO_CODPRODU}INICIO  : {V0ENDO_DTINIVIG}"
                    .Display();

                    /*" -4143- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -4145- MOVE ZEROS TO AUX-PERCENT. */
            _.Move(0, AREA_DE_WORK.AUX_PERCENT);

            /*" -4147- IF PARAMPRO-PERCEN-COMIS-FUNC NOT EQUAL ZEROS AND V0APCR-PCPARCOR EQUAL 100 */

            if (PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC != 00 && V0APCR_PCPARCOR == 100)
            {

                /*" -4149- MOVE PARAMPRO-PERCEN-COMIS-FUNC TO AUX-PERCENT */
                _.Move(PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC, AREA_DE_WORK.AUX_PERCENT);

                /*" -4150- ELSE */
            }
            else
            {


                /*" -4151- IF PARAMPRO-PERCEN-COMIS-FUNC NOT EQUAL ZEROS */

                if (PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC != 00)
                {

                    /*" -4153- COMPUTE AUX-PERCENT EQUAL (PARAMPRO-PERCEN-COMIS-FUNC * 2) */
                    AREA_DE_WORK.AUX_PERCENT.Value = (PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC * 2);

                    /*" -4154- ELSE */
                }
                else
                {


                    /*" -4157- COMPUTE AUX-VALBAS EQUAL (V1BILC-PRMTAR-IX * V0APCR-PCPARCOR) / 100 */
                    AREA_DE_WORK.AUX_VALBAS.Value = (V1BILC_PRMTAR_IX * V0APCR_PCPARCOR) / 100f;

                    /*" -4161- COMPUTE AUX-PERCENT EQUAL (PARAMPRO-VALOR-COMISSAO-PRD / AUX-VALBAS) * 100. */
                    AREA_DE_WORK.AUX_PERCENT.Value = (PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_VALOR_COMISSAO_PRD / AREA_DE_WORK.AUX_VALBAS) * 100;
                }

            }


            /*" -4163- MOVE AUX-PERCENT TO V0APCR-PCCOMCOR. */
            _.Move(AREA_DE_WORK.AUX_PERCENT, V0APCR_PCCOMCOR);

            /*" -4164- MOVE V0APOL-NUM-APOL TO V0APCR-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0APCR_NUM_APOL);

            /*" -4165- MOVE ZEROS TO V0APCR-CODSUBES */
            _.Move(0, V0APCR_CODSUBES);

            /*" -4166- MOVE V0ENDO-DTINIVIG TO V0APCR-DTINIVIG */
            _.Move(V0ENDO_DTINIVIG, V0APCR_DTINIVIG);

            /*" -4167- MOVE V0ENDO-DTTERVIG TO V0APCR-DTTERVIG */
            _.Move(V0ENDO_DTTERVIG, V0APCR_DTTERVIG);

            /*" -4168- MOVE WWORK-RAMO-ANT TO V0APCR-RAMOFR */
            _.Move(WWORK_RAMO_ANT, V0APCR_RAMOFR);

            /*" -4169- MOVE 0 TO V0APCR-MODALIFR */
            _.Move(0, V0APCR_MODALIFR);

            /*" -4170- MOVE '2' TO V0APCR-TIPCOM */
            _.Move("2", V0APCR_TIPCOM);

            /*" -4171- MOVE '1' TO V0APCR-INDCRT */
            _.Move("1", V0APCR_INDCRT);

            /*" -4173- MOVE ZEROS TO V0APCR-COD-EMPRESA. */
            _.Move(0, V0APCR_COD_EMPRESA);

            /*" -4175- MOVE 'BI8005B' TO V0APCR-COD-USUARIO. */
            _.Move("BI8005B", V0APCR_COD_USUARIO);

            /*" -4175- PERFORM R1068-00-INSERT-APOLCORRET. */

            R1068_00_INSERT_APOLCORRET_SECTION();

        }

        [StopWatch]
        /*" R1070-00-TRATA-PRO-LABORE-DB-SELECT-1 */
        public void R1070_00_TRATA_PRO_LABORE_DB_SELECT_1()
        {
            /*" -4127- EXEC SQL SELECT VALOR_COMISSAO_PRD , PERCEN_COMIS_FUNC INTO :PARAMPRO-VALOR-COMISSAO-PRD , :PARAMPRO-PERCEN-COMIS-FUNC FROM SEGUROS.PARAM_PRODUTO WHERE COD_PRODUTO = :V0ENDO-CODPRODU AND TIPO_FUNCIONARIO = 'T' AND DATA_INIVIGENCIA <= :V0ENDO-DTINIVIG AND DATA_TERVIGENCIA >= :V0ENDO-DTINIVIG FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r1070_00_TRATA_PRO_LABORE_DB_SELECT_1_Query1 = new R1070_00_TRATA_PRO_LABORE_DB_SELECT_1_Query1()
            {
                V0ENDO_CODPRODU = V0ENDO_CODPRODU.ToString(),
                V0ENDO_DTINIVIG = V0ENDO_DTINIVIG.ToString(),
            };

            var executed_1 = R1070_00_TRATA_PRO_LABORE_DB_SELECT_1_Query1.Execute(r1070_00_TRATA_PRO_LABORE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARAMPRO_VALOR_COMISSAO_PRD, PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_VALOR_COMISSAO_PRD);
                _.Move(executed_1.PARAMPRO_PERCEN_COMIS_FUNC, PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1070_99_SAIDA*/

        [StopWatch]
        /*" R1080-00-GRAVA-V0APOLCOSCED-SECTION */
        private void R1080_00_GRAVA_V0APOLCOSCED_SECTION()
        {
            /*" -4188- MOVE '1080' TO WNR-EXEC-SQL. */
            _.Move("1080", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4204- PERFORM R1080_00_GRAVA_V0APOLCOSCED_DB_DECLARE_1 */

            R1080_00_GRAVA_V0APOLCOSCED_DB_DECLARE_1();

            /*" -4206- PERFORM R1080_00_GRAVA_V0APOLCOSCED_DB_OPEN_1 */

            R1080_00_GRAVA_V0APOLCOSCED_DB_OPEN_1();

            /*" -4209- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4210- DISPLAY 'R1080-00 (ERRO OPEN CURSOR V1COSSEGPROD)...' */
                _.Display($"R1080-00 (ERRO OPEN CURSOR V1COSSEGPROD)...");

                /*" -4214- DISPLAY 'PRODUTO: ' V1BILP-CODPRODU '  ' 'RAMO: ' WWORK-RAMO-ANT ' ' 'OPCA: ' WWORK-OPCAO-ANT ' ' 'INIVIG: ' V0ENDO-DTINIVIG */

                $"PRODUTO: {V1BILP_CODPRODU}  RAMO: {WWORK_RAMO_ANT} OPCA: {WWORK_OPCAO_ANT} INIVIG: {V0ENDO_DTINIVIG}"
                .Display();

                /*" -4216- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4217- MOVE 0 TO WACC-PCTCED WACC-QTCOSSEG. */
            _.Move(0, AREA_DE_WORK.WACC_PCTCED, AREA_DE_WORK.WACC_QTCOSSEG);

            /*" -0- FLUXCONTROL_PERFORM R1080_10_FETCH_V1COSSEGPROD */

            R1080_10_FETCH_V1COSSEGPROD();

        }

        [StopWatch]
        /*" R1080-00-GRAVA-V0APOLCOSCED-DB-OPEN-1 */
        public void R1080_00_GRAVA_V0APOLCOSCED_DB_OPEN_1()
        {
            /*" -4206- EXEC SQL OPEN V1COSSEGPROD END-EXEC. */

            V1COSSEGPROD.Open();

        }

        [StopWatch]
        /*" R3200-10-DECLARE-V0RCAPCOMP-DB-DECLARE-1 */
        public void R3200_10_DECLARE_V0RCAPCOMP_DB_DECLARE_1()
        {
            /*" -5054- EXEC SQL DECLARE V1RCAPCOMP CURSOR FOR SELECT FONTE , NRRCAP , NRRCAPCO , OPERACAO , DTMOVTO , HORAOPER , SITUACAO , BCOAVISO , AGEAVISO , NRAVISO , VLRCAP , DATARCAP , DTCADAST , SITCONTB FROM SEGUROS.V1RCAPCOMP WHERE FONTE = :V0RCAP-FONTE AND NRRCAP = :V0RCAP-NRRCAP END-EXEC. */
            V1RCAPCOMP = new BI8005B_V1RCAPCOMP(true);
            string GetQuery_V1RCAPCOMP()
            {
                var query = @$"SELECT FONTE
							, 
							NRRCAP
							, 
							NRRCAPCO
							, 
							OPERACAO
							, 
							DTMOVTO
							, 
							HORAOPER
							, 
							SITUACAO
							, 
							BCOAVISO
							, 
							AGEAVISO
							, 
							NRAVISO
							, 
							VLRCAP
							, 
							DATARCAP
							, 
							DTCADAST
							, 
							SITCONTB 
							FROM SEGUROS.V1RCAPCOMP 
							WHERE FONTE = '{V0RCAP_FONTE}' 
							AND NRRCAP = '{V0RCAP_NRRCAP}'";

                return query;
            }
            V1RCAPCOMP.GetQueryEvent += GetQuery_V1RCAPCOMP;

        }

        [StopWatch]
        /*" R1080-10-FETCH-V1COSSEGPROD */
        private void R1080_10_FETCH_V1COSSEGPROD(bool isPerform = false)
        {
            /*" -4232- PERFORM R1080_10_FETCH_V1COSSEGPROD_DB_FETCH_1 */

            R1080_10_FETCH_V1COSSEGPROD_DB_FETCH_1();

            /*" -4235- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4236- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4236- PERFORM R1080_10_FETCH_V1COSSEGPROD_DB_CLOSE_1 */

                    R1080_10_FETCH_V1COSSEGPROD_DB_CLOSE_1();

                    /*" -4238- GO TO R1080-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1080_99_SAIDA*/ //GOTO
                    return;

                    /*" -4239- ELSE */
                }
                else
                {


                    /*" -4240- DISPLAY 'R1080-10 (ERRO - FETCH V1COSSEGPROD)...' */
                    _.Display($"R1080-10 (ERRO - FETCH V1COSSEGPROD)...");

                    /*" -4244- DISPLAY 'PRODUTO: ' V1BILP-CODPRODU '  ' 'RAMO: ' WWORK-RAMO-ANT ' ' 'OPCA: ' WWORK-OPCAO-ANT ' ' 'INIVIG: ' V0ENDO-DTINIVIG */

                    $"PRODUTO: {V1BILP_CODPRODU}  RAMO: {WWORK_RAMO_ANT} OPCA: {WWORK_OPCAO_ANT} INIVIG: {V0ENDO_DTINIVIG}"
                    .Display();

                    /*" -4246- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -4247- MOVE V1COSP-CONGENER TO V0APCC-CODCOSS */
            _.Move(V1COSP_CONGENER, V0APCC_CODCOSS);

            /*" -4248- MOVE V0APOL-NUM-APOL TO V0APCC-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0APCC_NUM_APOL);

            /*" -4249- MOVE WWORK-RAMO-ANT TO V0APCC-RAMOFR */
            _.Move(WWORK_RAMO_ANT, V0APCC_RAMOFR);

            /*" -4250- MOVE V0ENDO-DTINIVIG TO V0APCC-DTINIVIG */
            _.Move(V0ENDO_DTINIVIG, V0APCC_DTINIVIG);

            /*" -4251- MOVE V0ENDO-DTTERVIG TO V0APCC-DTTERVIG */
            _.Move(V0ENDO_DTTERVIG, V0APCC_DTTERVIG);

            /*" -4252- MOVE V1COSP-PCPARTIC TO V0APCC-PCPARTIC */
            _.Move(V1COSP_PCPARTIC, V0APCC_PCPARTIC);

            /*" -4253- MOVE V1COSP-PCCOMCOS TO V0APCC-PCCOMCOS */
            _.Move(V1COSP_PCCOMCOS, V0APCC_PCCOMCOS);

            /*" -4255- MOVE ZEROS TO V0APCC-COD-EMPRESA */
            _.Move(0, V0APCC_COD_EMPRESA);

            /*" -4256- ADD V1COSP-PCPARTIC TO WACC-PCTCED */
            AREA_DE_WORK.WACC_PCTCED.Value = AREA_DE_WORK.WACC_PCTCED + V1COSP_PCPARTIC;

            /*" -4258- ADD 1 TO WACC-QTCOSSEG. */
            AREA_DE_WORK.WACC_QTCOSSEG.Value = AREA_DE_WORK.WACC_QTCOSSEG + 1;

            /*" -4260- PERFORM R1082-00-INSERT-V0APOLCOSCED. */

            R1082_00_INSERT_V0APOLCOSCED_SECTION();

            /*" -4260- GO TO R1080-10-FETCH-V1COSSEGPROD. */
            new Task(() => R1080_10_FETCH_V1COSSEGPROD()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R1080-10-FETCH-V1COSSEGPROD-DB-FETCH-1 */
        public void R1080_10_FETCH_V1COSSEGPROD_DB_FETCH_1()
        {
            /*" -4232- EXEC SQL FETCH V1COSSEGPROD INTO :V1COSP-CODPRODU , :V1COSP-RAMO , :V1COSP-CONGENER , :V1COSP-PCPARTIC , :V1COSP-PCCOMCOS , :V1COSP-PCADMCOS , :V1COSP-DTINIVIG , :V1COSP-DTTERVIG , :V1COSP-SITUACAO END-EXEC. */

            if (V1COSSEGPROD.Fetch())
            {
                _.Move(V1COSSEGPROD.V1COSP_CODPRODU, V1COSP_CODPRODU);
                _.Move(V1COSSEGPROD.V1COSP_RAMO, V1COSP_RAMO);
                _.Move(V1COSSEGPROD.V1COSP_CONGENER, V1COSP_CONGENER);
                _.Move(V1COSSEGPROD.V1COSP_PCPARTIC, V1COSP_PCPARTIC);
                _.Move(V1COSSEGPROD.V1COSP_PCCOMCOS, V1COSP_PCCOMCOS);
                _.Move(V1COSSEGPROD.V1COSP_PCADMCOS, V1COSP_PCADMCOS);
                _.Move(V1COSSEGPROD.V1COSP_DTINIVIG, V1COSP_DTINIVIG);
                _.Move(V1COSSEGPROD.V1COSP_DTTERVIG, V1COSP_DTTERVIG);
                _.Move(V1COSSEGPROD.V1COSP_SITUACAO, V1COSP_SITUACAO);
            }

        }

        [StopWatch]
        /*" R1080-10-FETCH-V1COSSEGPROD-DB-CLOSE-1 */
        public void R1080_10_FETCH_V1COSSEGPROD_DB_CLOSE_1()
        {
            /*" -4236- EXEC SQL CLOSE V1COSSEGPROD END-EXEC */

            V1COSSEGPROD.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1080_99_SAIDA*/

        [StopWatch]
        /*" R1082-00-INSERT-V0APOLCOSCED-SECTION */
        private void R1082_00_INSERT_V0APOLCOSCED_SECTION()
        {
            /*" -4271- MOVE '1082' TO WNR-EXEC-SQL. */
            _.Move("1082", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4282- PERFORM R1082_00_INSERT_V0APOLCOSCED_DB_INSERT_1 */

            R1082_00_INSERT_V0APOLCOSCED_DB_INSERT_1();

            /*" -4285- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4286- DISPLAY 'R1082-00 (ERRO INSERT V0APOLCOSCED)...' */
                _.Display($"R1082-00 (ERRO INSERT V0APOLCOSCED)...");

                /*" -4289- DISPLAY 'APOLICE: ' V0APCC-NUM-APOL '  ' 'CODCOSS: ' V0APCC-CODCOSS '  ' 'RAMO: ' V0APCC-RAMOFR */

                $"APOLICE: {V0APCC_NUM_APOL}  CODCOSS: {V0APCC_CODCOSS}  RAMO: {V0APCC_RAMOFR}"
                .Display();

                /*" -4291- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4293- ADD +1 TO AC-I-V0APOLCOSCED. */
            AREA_DE_WORK.AC_I_V0APOLCOSCED.Value = AREA_DE_WORK.AC_I_V0APOLCOSCED + +1;

            /*" -4293- PERFORM R1083-00-INSERT-V0ORDECOSCED. */

            R1083_00_INSERT_V0ORDECOSCED_SECTION();

        }

        [StopWatch]
        /*" R1082-00-INSERT-V0APOLCOSCED-DB-INSERT-1 */
        public void R1082_00_INSERT_V0APOLCOSCED_DB_INSERT_1()
        {
            /*" -4282- EXEC SQL INSERT INTO SEGUROS.V0APOLCOSCED VALUES (:V0APCC-NUM-APOL , :V0APCC-CODCOSS , :V0APCC-RAMOFR , :V0APCC-DTINIVIG , :V0APCC-DTTERVIG , :V0APCC-PCPARTIC , :V0APCC-PCCOMCOS , :V0APCC-COD-EMPRESA , CURRENT TIMESTAMP) END-EXEC. */

            var r1082_00_INSERT_V0APOLCOSCED_DB_INSERT_1_Insert1 = new R1082_00_INSERT_V0APOLCOSCED_DB_INSERT_1_Insert1()
            {
                V0APCC_NUM_APOL = V0APCC_NUM_APOL.ToString(),
                V0APCC_CODCOSS = V0APCC_CODCOSS.ToString(),
                V0APCC_RAMOFR = V0APCC_RAMOFR.ToString(),
                V0APCC_DTINIVIG = V0APCC_DTINIVIG.ToString(),
                V0APCC_DTTERVIG = V0APCC_DTTERVIG.ToString(),
                V0APCC_PCPARTIC = V0APCC_PCPARTIC.ToString(),
                V0APCC_PCCOMCOS = V0APCC_PCCOMCOS.ToString(),
                V0APCC_COD_EMPRESA = V0APCC_COD_EMPRESA.ToString(),
            };

            R1082_00_INSERT_V0APOLCOSCED_DB_INSERT_1_Insert1.Execute(r1082_00_INSERT_V0APOLCOSCED_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1082_99_SAIDA*/

        [StopWatch]
        /*" R1083-00-INSERT-V0ORDECOSCED-SECTION */
        private void R1083_00_INSERT_V0ORDECOSCED_SECTION()
        {
            /*" -4305- MOVE '1083' TO WNR-EXEC-SQL. */
            _.Move("1083", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4306- MOVE ZEROS TO V0ORDC-COD-EMPRESA. */
            _.Move(0, V0ORDC_COD_EMPRESA);

            /*" -4307- MOVE V0APCC-NUM-APOL TO V0ORDC-NUM-APOL */
            _.Move(V0APCC_NUM_APOL, V0ORDC_NUM_APOL);

            /*" -4308- MOVE 0 TO V0ORDC-NRENDOS */
            _.Move(0, V0ORDC_NRENDOS);

            /*" -4311- MOVE V0APCC-CODCOSS TO V0ORDC-CODCOSS WWORK-ORD-CONGE. */
            _.Move(V0APCC_CODCOSS, V0ORDC_CODCOSS);
            _.Move(V0APCC_CODCOSS, AREA_DE_WORK.FILLER_3.WWORK_ORD_CONGE);


            /*" -4312- MOVE V0APCC-CODCOSS TO V1NCOS-CONGENER */
            _.Move(V0APCC_CODCOSS, V1NCOS_CONGENER);

            /*" -4315- MOVE V0APOL-ORGAO TO V1NCOS-ORGAO WWORK-ORD-ORGAO. */
            _.Move(V0APOL_ORGAO, V1NCOS_ORGAO);
            _.Move(V0APOL_ORGAO, AREA_DE_WORK.FILLER_3.WWORK_ORD_ORGAO);


            /*" -4321- PERFORM R1083_00_INSERT_V0ORDECOSCED_DB_SELECT_1 */

            R1083_00_INSERT_V0ORDECOSCED_DB_SELECT_1();

            /*" -4324- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4325- DISPLAY 'R1083-00 (ERRO - SELECT V1NUMERO_COSSEGURO)...' */
                _.Display($"R1083-00 (ERRO - SELECT V1NUMERO_COSSEGURO)...");

                /*" -4328- DISPLAY 'ORGAO: ' V1NCOS-ORGAO '  ' 'CONGENER: ' V1NCOS-CONGENER '  ' 'BILHETE : ' V0BILH-NUMBIL */

                $"ORGAO: {V1NCOS_ORGAO}  CONGENER: {V1NCOS_CONGENER}  BILHETE : {V0BILH_NUMBIL}"
                .Display();

                /*" -4331- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4333- COMPUTE V1NCOS-NRORDEM = V1NCOS-NRORDEM + 1. */
            V1NCOS_NRORDEM.Value = V1NCOS_NRORDEM + 1;

            /*" -4335- MOVE V1NCOS-NRORDEM TO WWORK-ORD-SEQUE. */
            _.Move(V1NCOS_NRORDEM, AREA_DE_WORK.FILLER_3.WWORK_ORD_SEQUE);

            /*" -4337- MOVE WWORK-NUM-ORDEM TO V0ORDC-ORDEM-CED. */
            _.Move(AREA_DE_WORK.WWORK_NUM_ORDEM, V0ORDC_ORDEM_CED);

            /*" -4345- PERFORM R1083_00_INSERT_V0ORDECOSCED_DB_INSERT_1 */

            R1083_00_INSERT_V0ORDECOSCED_DB_INSERT_1();

            /*" -4348- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4349- DISPLAY 'R1083-00 (ERRO - INSERT V0ORDECOSCED)...' */
                _.Display($"R1083-00 (ERRO - INSERT V0ORDECOSCED)...");

                /*" -4353- DISPLAY 'APOLICE: ' V0ORDC-NUM-APOL '  ' 'ENDOSSO: ' V0ORDC-NRENDOS '  ' 'CODCOSS: ' V0ORDC-CODCOSS '  ' 'NRORDEM: ' V0ORDC-ORDEM-CED */

                $"APOLICE: {V0ORDC_NUM_APOL}  ENDOSSO: {V0ORDC_NRENDOS}  CODCOSS: {V0ORDC_CODCOSS}  NRORDEM: {V0ORDC_ORDEM_CED}"
                .Display();

                /*" -4354- DISPLAY 'BILHETE: ' V0BILH-NUMBIL */
                _.Display($"BILHETE: {V0BILH_NUMBIL}");

                /*" -4356- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4359- ADD +1 TO AC-I-V0ORDECOSCED. */
            AREA_DE_WORK.AC_I_V0ORDECOSCED.Value = AREA_DE_WORK.AC_I_V0ORDECOSCED + +1;

            /*" -4360- MOVE V0APCC-CODCOSS TO V1NCOS-CONGENER */
            _.Move(V0APCC_CODCOSS, V1NCOS_CONGENER);

            /*" -4362- MOVE V0APOL-ORGAO TO V1NCOS-ORGAO. */
            _.Move(V0APOL_ORGAO, V1NCOS_ORGAO);

            /*" -4368- PERFORM R1083_00_INSERT_V0ORDECOSCED_DB_UPDATE_1 */

            R1083_00_INSERT_V0ORDECOSCED_DB_UPDATE_1();

            /*" -4371- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4372- DISPLAY 'R1083-00 (ERRO - UPDATE V0NUMERO_COSSEGURO)...' */
                _.Display($"R1083-00 (ERRO - UPDATE V0NUMERO_COSSEGURO)...");

                /*" -4375- DISPLAY 'ORGAO: ' V1NCOS-ORGAO '  ' 'CONGENER: ' V1NCOS-CONGENER '  ' 'BILHETE : ' V0BILH-NUMBIL */

                $"ORGAO: {V1NCOS_ORGAO}  CONGENER: {V1NCOS_CONGENER}  BILHETE : {V0BILH_NUMBIL}"
                .Display();

                /*" -4377- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4377- ADD +1 TO AC-U-V0NUMERO-COSSEGURO. */
            AREA_DE_WORK.AC_U_V0NUMERO_COSSEGURO.Value = AREA_DE_WORK.AC_U_V0NUMERO_COSSEGURO + +1;

        }

        [StopWatch]
        /*" R1083-00-INSERT-V0ORDECOSCED-DB-SELECT-1 */
        public void R1083_00_INSERT_V0ORDECOSCED_DB_SELECT_1()
        {
            /*" -4321- EXEC SQL SELECT NRORDEM INTO :V1NCOS-NRORDEM FROM SEGUROS.V1NUMERO_COSSEGURO WHERE ORGAO = :V1NCOS-ORGAO AND CONGENER = :V1NCOS-CONGENER END-EXEC. */

            var r1083_00_INSERT_V0ORDECOSCED_DB_SELECT_1_Query1 = new R1083_00_INSERT_V0ORDECOSCED_DB_SELECT_1_Query1()
            {
                V1NCOS_CONGENER = V1NCOS_CONGENER.ToString(),
                V1NCOS_ORGAO = V1NCOS_ORGAO.ToString(),
            };

            var executed_1 = R1083_00_INSERT_V0ORDECOSCED_DB_SELECT_1_Query1.Execute(r1083_00_INSERT_V0ORDECOSCED_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1NCOS_NRORDEM, V1NCOS_NRORDEM);
            }


        }

        [StopWatch]
        /*" R1083-00-INSERT-V0ORDECOSCED-DB-INSERT-1 */
        public void R1083_00_INSERT_V0ORDECOSCED_DB_INSERT_1()
        {
            /*" -4345- EXEC SQL INSERT INTO SEGUROS.V0ORDECOSCED VALUES (:V0ORDC-NUM-APOL , :V0ORDC-NRENDOS , :V0ORDC-CODCOSS , :V0ORDC-ORDEM-CED , :V0ORDC-COD-EMPRESA , CURRENT TIMESTAMP) END-EXEC. */

            var r1083_00_INSERT_V0ORDECOSCED_DB_INSERT_1_Insert1 = new R1083_00_INSERT_V0ORDECOSCED_DB_INSERT_1_Insert1()
            {
                V0ORDC_NUM_APOL = V0ORDC_NUM_APOL.ToString(),
                V0ORDC_NRENDOS = V0ORDC_NRENDOS.ToString(),
                V0ORDC_CODCOSS = V0ORDC_CODCOSS.ToString(),
                V0ORDC_ORDEM_CED = V0ORDC_ORDEM_CED.ToString(),
                V0ORDC_COD_EMPRESA = V0ORDC_COD_EMPRESA.ToString(),
            };

            R1083_00_INSERT_V0ORDECOSCED_DB_INSERT_1_Insert1.Execute(r1083_00_INSERT_V0ORDECOSCED_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1083-00-INSERT-V0ORDECOSCED-DB-UPDATE-1 */
        public void R1083_00_INSERT_V0ORDECOSCED_DB_UPDATE_1()
        {
            /*" -4368- EXEC SQL UPDATE SEGUROS.V0NUMERO_COSSEGURO SET NRORDEM = :V1NCOS-NRORDEM , TIMESTAMP = CURRENT TIMESTAMP WHERE ORGAO = :V1NCOS-ORGAO AND CONGENER = :V1NCOS-CONGENER END-EXEC. */

            var r1083_00_INSERT_V0ORDECOSCED_DB_UPDATE_1_Update1 = new R1083_00_INSERT_V0ORDECOSCED_DB_UPDATE_1_Update1()
            {
                V1NCOS_NRORDEM = V1NCOS_NRORDEM.ToString(),
                V1NCOS_CONGENER = V1NCOS_CONGENER.ToString(),
                V1NCOS_ORGAO = V1NCOS_ORGAO.ToString(),
            };

            R1083_00_INSERT_V0ORDECOSCED_DB_UPDATE_1_Update1.Execute(r1083_00_INSERT_V0ORDECOSCED_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1083_99_SAIDA*/

        [StopWatch]
        /*" R1090-00-UPDATE-V0APOLICE-SECTION */
        private void R1090_00_UPDATE_V0APOLICE_SECTION()
        {
            /*" -4388- MOVE '1090' TO WNR-EXEC-SQL. */
            _.Move("1090", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4389- MOVE WACC-QTCOSSEG TO V0APOL-QTCOSSEG */
            _.Move(AREA_DE_WORK.WACC_QTCOSSEG, V0APOL_QTCOSSEG);

            /*" -4391- MOVE WACC-PCTCED TO V0APOL-PCTCED. */
            _.Move(AREA_DE_WORK.WACC_PCTCED, V0APOL_PCTCED);

            /*" -4396- PERFORM R1090_00_UPDATE_V0APOLICE_DB_UPDATE_1 */

            R1090_00_UPDATE_V0APOLICE_DB_UPDATE_1();

            /*" -4399- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4400- DISPLAY 'R1090-00 (ERRO - UPDATE V0APOLICE)...' */
                _.Display($"R1090-00 (ERRO - UPDATE V0APOLICE)...");

                /*" -4401- DISPLAY 'APOLICE: ' V0APOL-NUM-APOL */
                _.Display($"APOLICE: {V0APOL_NUM_APOL}");

                /*" -4403- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4403- ADD +1 TO AC-U-V0APOLICE. */
            AREA_DE_WORK.AC_U_V0APOLICE.Value = AREA_DE_WORK.AC_U_V0APOLICE + +1;

        }

        [StopWatch]
        /*" R1090-00-UPDATE-V0APOLICE-DB-UPDATE-1 */
        public void R1090_00_UPDATE_V0APOLICE_DB_UPDATE_1()
        {
            /*" -4396- EXEC SQL UPDATE SEGUROS.V0APOLICE SET QTCOSSEG = :V0APOL-QTCOSSEG , PCTCED = :V0APOL-PCTCED WHERE NUM_APOLICE = :V0APOL-NUM-APOL END-EXEC. */

            var r1090_00_UPDATE_V0APOLICE_DB_UPDATE_1_Update1 = new R1090_00_UPDATE_V0APOLICE_DB_UPDATE_1_Update1()
            {
                V0APOL_QTCOSSEG = V0APOL_QTCOSSEG.ToString(),
                V0APOL_PCTCED = V0APOL_PCTCED.ToString(),
                V0APOL_NUM_APOL = V0APOL_NUM_APOL.ToString(),
            };

            R1090_00_UPDATE_V0APOLICE_DB_UPDATE_1_Update1.Execute(r1090_00_UPDATE_V0APOLICE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1090_99_SAIDA*/

        [StopWatch]
        /*" R1155-00-TRATA-MOVDEBCC-SECTION */
        private void R1155_00_TRATA_MOVDEBCC_SECTION()
        {
            /*" -4418- MOVE '1155' TO WNR-EXEC-SQL. */
            _.Move("1155", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4419- MOVE V0BILH-NUMBIL TO MOVDEBCE-NUM-CERTIFICADO */
            _.Move(V0BILH_NUMBIL, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CERTIFICADO);

            /*" -4420- MOVE V0ENDO-NUM-APOL TO MOVDEBCE-NUM-APOLICE */
            _.Move(V0ENDO_NUM_APOL, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);

            /*" -4421- MOVE 'BI8005B' TO MOVDEBCE-COD-USUARIO */
            _.Move("BI8005B", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_USUARIO);

            /*" -4422- MOVE 76114 TO MOVDEBCE-COD-CONVENIO */
            _.Move(76114, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);

            /*" -4423- MOVE V1SIST-DTMOVABE TO MOVDEBCE-DATA-MOVIMENTO */
            _.Move(V1SIST_DTMOVABE, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO);

            /*" -4424- MOVE V0BILH-DTVENCTO TO MOVDEBCE-DATA-VENCIMENTO */
            _.Move(V0BILH_DTVENCTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO);

            /*" -4425- MOVE 2 TO MOVDEBCE-NUM-ENDOSSO */
            _.Move(2, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);

            /*" -4427- MOVE '6' TO MOVDEBCE-SITUACAO-COBRANCA */
            _.Move("6", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);

            /*" -4430- MOVE ZEROS TO MOVDEBCE-NUM-CARTAO */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO);

            /*" -4433- MOVE PRPFIDEL-DIA-DEBITO TO MOVDEBCE-DIA-DEBITO */
            _.Move(PRPFIDEL_DIA_DEBITO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIA_DEBITO);

            /*" -4436- MOVE V0BILH-AGENCIA-DEB TO MOVDEBCE-COD-AGENCIA-DEB */
            _.Move(V0BILH_AGENCIA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB);

            /*" -4439- MOVE V0BILH-OPERACAO-DEB TO MOVDEBCE-OPER-CONTA-DEB */
            _.Move(V0BILH_OPERACAO_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB);

            /*" -4442- MOVE V0BILH-NUMCTA-DEB TO MOVDEBCE-NUM-CONTA-DEB */
            _.Move(V0BILH_NUMCTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB);

            /*" -4445- MOVE V0BILH-DIGCTA-DEB TO MOVDEBCE-DIG-CONTA-DEB */
            _.Move(V0BILH_DIGCtA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB);

            /*" -4448- MOVE V0BILH-VLRCAP TO MOVDEBCE-VALOR-DEBITO */
            _.Move(V0BILH_VLRCAP, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO);

            /*" -4457- MOVE ZEROS TO MOVDEBCE-NUM-PARCELA MOVDEBCE-COD-EMPRESA MOVDEBCE-COD-RETORNO-CEF MOVDEBCE-NSAS MOVDEBCE-NUM-REQUISICAO MOVDEBCE-SEQUENCIA MOVDEBCE-NUM-LOTE MOVDEBCE-VLR-CREDITO. */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_EMPRESA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SEQUENCIA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_LOTE, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_CREDITO);

            /*" -4462- MOVE SPACES TO MOVDEBCE-DTCREDITO MOVDEBCE-STATUS-CARTAO MOVDEBCE-DATA-ENVIO MOVDEBCE-DATA-RETORNO */
            _.Move("", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DTCREDITO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_STATUS_CARTAO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_ENVIO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_RETORNO);

            /*" -4470- MOVE ZEROS TO VIND-DIADEBITO VIND-AGENCIA VIND-OPERACAO VIND-NUMCONTA VIND-DIGCONTA VIND-CARTAO-CREDITO VIND-USUARIO. */
            _.Move(0, VIND_DIADEBITO, VIND_AGENCIA, VIND_OPERACAO, VIND_NUMCONTA, VIND_DIGCONTA, VIND_CARTAO_CREDITO, VIND_USUARIO);

            /*" -4480- MOVE -1 TO VIND-DTENVIO VIND-DTRETORNO VIND-CODRETORNO VIND-REQUISICAO VIND-SEQUENCIA VIND-NUM-LOTE VIND-DTCREDITO VIND-STATUS VIND-VLCREDITO. */
            _.Move(-1, VIND_DTENVIO, VIND_DTRETORNO, VIND_CODRETORNO, VIND_REQUISICAO, VIND_SEQUENCIA, VIND_NUM_LOTE, VIND_DTCREDITO, VIND_STATUS, VIND_VLCREDITO);

            /*" -4555- PERFORM R1155_00_TRATA_MOVDEBCC_DB_INSERT_1 */

            R1155_00_TRATA_MOVDEBCC_DB_INSERT_1();

            /*" -4558- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4559- DISPLAY 'R1155-00 (ERRO - INSERT MOVTODEBCC )...' */
                _.Display($"R1155-00 (ERRO - INSERT MOVTODEBCC )...");

                /*" -4564- DISPLAY 'APOL: ' V0HISP-NUM-APOL '  ' 'ENDO: ' V0HISP-NRENDOS '  ' 'PARC: ' V0HISP-NRPARCEL '  ' 'OCOR: ' V0HISP-OCORHIST '  ' 'BILH: ' V0BILH-NUMBIL */

                $"APOL: {V0HISP_NUM_APOL}  ENDO: {V0HISP_NRENDOS}  PARC: {V0HISP_NRPARCEL}  OCOR: {V0HISP_OCORHIST}  BILH: {V0BILH_NUMBIL}"
                .Display();

                /*" -4564- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1155-00-TRATA-MOVDEBCC-DB-INSERT-1 */
        public void R1155_00_TRATA_MOVDEBCC_DB_INSERT_1()
        {
            /*" -4555- EXEC SQL INSERT INTO SEGUROS.MOVTO_DEBITOCC_CEF (COD_EMPRESA ,NUM_APOLICE ,NUM_ENDOSSO ,NUM_PARCELA ,SITUACAO_COBRANCA ,DATA_VENCIMENTO ,VALOR_DEBITO ,DATA_MOVIMENTO ,TIMESTAMP ,DIA_DEBITO ,COD_AGENCIA_DEB ,OPER_CONTA_DEB ,NUM_CONTA_DEB ,DIG_CONTA_DEB ,COD_CONVENIO ,DATA_ENVIO ,DATA_RETORNO ,COD_RETORNO_CEF ,NSAS ,COD_USUARIO ,NUM_REQUISICAO ,NUM_CARTAO ,SEQUENCIA ,NUM_LOTE ,DTCREDITO ,STATUS_CARTAO ,VLR_CREDITO ,NUM_CERTIFICADO ,COD_MOEDA ,PCT_INDICE ,VLR_ORIGINAL ,VLR_PRORATA ,VLR_JUROS ,VLR_MULTA ,DTA_ORIGINAL ,COD_IDLG) VALUES (:MOVDEBCE-COD-EMPRESA , :MOVDEBCE-NUM-APOLICE , :MOVDEBCE-NUM-ENDOSSO , :MOVDEBCE-NUM-PARCELA , :MOVDEBCE-SITUACAO-COBRANCA , :MOVDEBCE-DATA-VENCIMENTO , :MOVDEBCE-VALOR-DEBITO , :MOVDEBCE-DATA-MOVIMENTO , CURRENT TIMESTAMP , :MOVDEBCE-DIA-DEBITO :VIND-DIADEBITO , :MOVDEBCE-COD-AGENCIA-DEB :VIND-AGENCIA , :MOVDEBCE-OPER-CONTA-DEB :VIND-OPERACAO , :MOVDEBCE-NUM-CONTA-DEB :VIND-NUMCONTA , :MOVDEBCE-DIG-CONTA-DEB :VIND-DIGCONTA , :MOVDEBCE-COD-CONVENIO , :MOVDEBCE-DATA-ENVIO :VIND-DTENVIO , :MOVDEBCE-DATA-RETORNO :VIND-DTRETORNO , :MOVDEBCE-COD-RETORNO-CEF :VIND-CODRETORNO, :MOVDEBCE-NSAS , :MOVDEBCE-COD-USUARIO :VIND-USUARIO , :MOVDEBCE-NUM-REQUISICAO :VIND-REQUISICAO, :MOVDEBCE-NUM-CARTAO :VIND-CARTAO-CREDITO, :MOVDEBCE-SEQUENCIA :VIND-SEQUENCIA , :MOVDEBCE-NUM-LOTE :VIND-NUM-LOTE , :MOVDEBCE-DTCREDITO :VIND-DTCREDITO , :MOVDEBCE-STATUS-CARTAO :VIND-STATUS , :MOVDEBCE-VLR-CREDITO :VIND-VLCREDITO , :MOVDEBCE-NUM-CERTIFICADO , NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL ) END-EXEC. */

            var r1155_00_TRATA_MOVDEBCC_DB_INSERT_1_Insert1 = new R1155_00_TRATA_MOVDEBCC_DB_INSERT_1_Insert1()
            {
                MOVDEBCE_COD_EMPRESA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_EMPRESA.ToString(),
                MOVDEBCE_NUM_APOLICE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.ToString(),
                MOVDEBCE_NUM_ENDOSSO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO.ToString(),
                MOVDEBCE_NUM_PARCELA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA.ToString(),
                MOVDEBCE_SITUACAO_COBRANCA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA.ToString(),
                MOVDEBCE_DATA_VENCIMENTO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO.ToString(),
                MOVDEBCE_VALOR_DEBITO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO.ToString(),
                MOVDEBCE_DATA_MOVIMENTO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO.ToString(),
                MOVDEBCE_DIA_DEBITO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIA_DEBITO.ToString(),
                VIND_DIADEBITO = VIND_DIADEBITO.ToString(),
                MOVDEBCE_COD_AGENCIA_DEB = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB.ToString(),
                VIND_AGENCIA = VIND_AGENCIA.ToString(),
                MOVDEBCE_OPER_CONTA_DEB = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB.ToString(),
                VIND_OPERACAO = VIND_OPERACAO.ToString(),
                MOVDEBCE_NUM_CONTA_DEB = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB.ToString(),
                VIND_NUMCONTA = VIND_NUMCONTA.ToString(),
                MOVDEBCE_DIG_CONTA_DEB = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB.ToString(),
                VIND_DIGCONTA = VIND_DIGCONTA.ToString(),
                MOVDEBCE_COD_CONVENIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.ToString(),
                MOVDEBCE_DATA_ENVIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_ENVIO.ToString(),
                VIND_DTENVIO = VIND_DTENVIO.ToString(),
                MOVDEBCE_DATA_RETORNO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_RETORNO.ToString(),
                VIND_DTRETORNO = VIND_DTRETORNO.ToString(),
                MOVDEBCE_COD_RETORNO_CEF = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF.ToString(),
                VIND_CODRETORNO = VIND_CODRETORNO.ToString(),
                MOVDEBCE_NSAS = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS.ToString(),
                MOVDEBCE_COD_USUARIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_USUARIO.ToString(),
                VIND_USUARIO = VIND_USUARIO.ToString(),
                MOVDEBCE_NUM_REQUISICAO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO.ToString(),
                VIND_REQUISICAO = VIND_REQUISICAO.ToString(),
                MOVDEBCE_NUM_CARTAO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO.ToString(),
                VIND_CARTAO_CREDITO = VIND_CARTAO_CREDITO.ToString(),
                MOVDEBCE_SEQUENCIA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SEQUENCIA.ToString(),
                VIND_SEQUENCIA = VIND_SEQUENCIA.ToString(),
                MOVDEBCE_NUM_LOTE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_LOTE.ToString(),
                VIND_NUM_LOTE = VIND_NUM_LOTE.ToString(),
                MOVDEBCE_DTCREDITO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DTCREDITO.ToString(),
                VIND_DTCREDITO = VIND_DTCREDITO.ToString(),
                MOVDEBCE_STATUS_CARTAO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_STATUS_CARTAO.ToString(),
                VIND_STATUS = VIND_STATUS.ToString(),
                MOVDEBCE_VLR_CREDITO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_CREDITO.ToString(),
                VIND_VLCREDITO = VIND_VLCREDITO.ToString(),
                MOVDEBCE_NUM_CERTIFICADO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CERTIFICADO.ToString(),
            };

            R1155_00_TRATA_MOVDEBCC_DB_INSERT_1_Insert1.Execute(r1155_00_TRATA_MOVDEBCC_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1155_99_SAIDA*/

        [StopWatch]
        /*" R1160-00-INSERT-APOLCOBR-SECTION */
        private void R1160_00_INSERT_APOLCOBR_SECTION()
        {
            /*" -4577- MOVE '1160' TO WNR-EXEC-SQL. */
            _.Move("1160", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4578- MOVE V0ENDO-COD-EMPRESA TO APOLCOBR-COD-EMPRESA */
            _.Move(V0ENDO_COD_EMPRESA, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_EMPRESA);

            /*" -4579- MOVE V0ENDO-FONTE TO APOLCOBR-COD-FONTE */
            _.Move(V0ENDO_FONTE, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_FONTE);

            /*" -4580- MOVE V0ENDO-NUM-APOL TO APOLCOBR-NUM-APOLICE */
            _.Move(V0ENDO_NUM_APOL, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_APOLICE);

            /*" -4581- MOVE V0ENDO-CODPRODU TO APOLCOBR-COD-PRODUTO */
            _.Move(V0ENDO_CODPRODU, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_PRODUTO);

            /*" -4582- MOVE V0BILH-NUM-MATR TO APOLCOBR-NUM-MATRICULA */
            _.Move(V0BILH_NUM_MATR, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_MATRICULA);

            /*" -4584- MOVE V0BILH-AGECOBR TO APOLCOBR-AGE-COBRANCA */
            _.Move(V0BILH_AGECOBR, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_AGE_COBRANCA);

            /*" -4586- MOVE '1' TO APOLCOBR-TIPO-COBRANCA. */
            _.Move("1", APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_TIPO_COBRANCA);

            /*" -4589- MOVE ZEROS TO APOLCOBR-NUM-CARTAO */
            _.Move(0, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_CARTAO);

            /*" -4592- MOVE PRPFIDEL-DIA-DEBITO TO APOLCOBR-DIA-DEBITO */
            _.Move(PRPFIDEL_DIA_DEBITO, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_DIA_DEBITO);

            /*" -4595- MOVE V0BILH-AGENCIA-DEB TO APOLCOBR-COD-AGENCIA-DEB */
            _.Move(V0BILH_AGENCIA_DEB, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_AGENCIA_DEB);

            /*" -4598- MOVE V0BILH-OPERACAO-DEB TO APOLCOBR-OPER-CONTA-DEB */
            _.Move(V0BILH_OPERACAO_DEB, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_OPER_CONTA_DEB);

            /*" -4601- MOVE V0BILH-NUMCTA-DEB TO APOLCOBR-NUM-CONTA-DEB */
            _.Move(V0BILH_NUMCTA_DEB, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_CONTA_DEB);

            /*" -4604- MOVE V0BILH-DIGCTA-DEB TO APOLCOBR-DIG-CONTA-DEB */
            _.Move(V0BILH_DIGCtA_DEB, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_DIG_CONTA_DEB);

            /*" -4607- MOVE PRPFIDEL-QTD-MESES TO APOLCOBR-MARGEM-COMERCIAL */
            _.Move(PRPFIDEL_QTD_MESES, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_MARGEM_COMERCIAL);

            /*" -4613- MOVE ZEROS TO APOLCOBR-OPERACAO-CONTA APOLCOBR-NUM-CONTA APOLCOBR-DIG-CONTA APOLCOBR-COD-AGENCIA APOLCOBR-NUM-ENDOSSO. */
            _.Move(0, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_OPERACAO_CONTA, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_CONTA, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_DIG_CONTA, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_AGENCIA, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_ENDOSSO);

            /*" -4615- MOVE SPACES TO APOLCOBR-NR-CERTIF-AUTO. */
            _.Move("", APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NR_CERTIF_AUTO);

            /*" -4624- MOVE ZEROS TO VIND-AGENCIA VIND-OPERACAO VIND-NUMCONTA VIND-DIGCONTA VIND-CARTAO-CREDITO VIND-DIADEBITO VIND-NRCERTIF VIND-MARGEM. */
            _.Move(0, VIND_AGENCIA, VIND_OPERACAO, VIND_NUMCONTA, VIND_DIGCONTA, VIND_CARTAO_CREDITO, VIND_DIADEBITO, VIND_NRCERTIF, VIND_MARGEM);

            /*" -4668- PERFORM R1160_00_INSERT_APOLCOBR_DB_INSERT_1 */

            R1160_00_INSERT_APOLCOBR_DB_INSERT_1();

            /*" -4671- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4672- DISPLAY 'R1160-00 (ERRO - INSERT APOLCOBR   )...' */
                _.Display($"R1160-00 (ERRO - INSERT APOLCOBR   )...");

                /*" -4677- DISPLAY 'APOL: ' V0HISP-NUM-APOL '  ' 'ENDO: ' V0HISP-NRENDOS '  ' 'PARC: ' V0HISP-NRPARCEL '  ' 'OCOR: ' V0HISP-OCORHIST '  ' 'BILH: ' V0BILH-NUMBIL */

                $"APOL: {V0HISP_NUM_APOL}  ENDO: {V0HISP_NRENDOS}  PARC: {V0HISP_NRPARCEL}  OCOR: {V0HISP_OCORHIST}  BILH: {V0BILH_NUMBIL}"
                .Display();

                /*" -4677- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1160-00-INSERT-APOLCOBR-DB-INSERT-1 */
        public void R1160_00_INSERT_APOLCOBR_DB_INSERT_1()
        {
            /*" -4668- EXEC SQL INSERT INTO SEGUROS.APOLICE_COBRANCA (COD_EMPRESA , COD_FONTE , NUM_APOLICE , NUM_ENDOSSO , COD_PRODUTO , NUM_MATRICULA , TIPO_COBRANCA , AGE_COBRANCA , COD_AGENCIA , OPERACAO_CONTA , NUM_CONTA , DIG_CONTA , COD_AGENCIA_DEB , OPER_CONTA_DEB , NUM_CONTA_DEB , DIG_CONTA_DEB , NUM_CARTAO , DIA_DEBITO , NR_CERTIF_AUTO , TIMESTAMP , MARGEM_COMERCIAL) VALUES (:APOLCOBR-COD-EMPRESA , :APOLCOBR-COD-FONTE , :APOLCOBR-NUM-APOLICE , :APOLCOBR-NUM-ENDOSSO , :APOLCOBR-COD-PRODUTO , :APOLCOBR-NUM-MATRICULA , :APOLCOBR-TIPO-COBRANCA , :APOLCOBR-AGE-COBRANCA , :APOLCOBR-COD-AGENCIA , :APOLCOBR-OPERACAO-CONTA , :APOLCOBR-NUM-CONTA , :APOLCOBR-DIG-CONTA , :APOLCOBR-COD-AGENCIA-DEB:VIND-AGENCIA , :APOLCOBR-OPER-CONTA-DEB :VIND-OPERACAO , :APOLCOBR-NUM-CONTA-DEB :VIND-NUMCONTA , :APOLCOBR-DIG-CONTA-DEB :VIND-DIGCONTA , :APOLCOBR-NUM-CARTAO :VIND-CARTAO-CREDITO, :APOLCOBR-DIA-DEBITO :VIND-DIADEBITO, :APOLCOBR-NR-CERTIF-AUTO :VIND-NRCERTIF , CURRENT TIMESTAMP , :APOLCOBR-MARGEM-COMERCIAL) END-EXEC. */

            var r1160_00_INSERT_APOLCOBR_DB_INSERT_1_Insert1 = new R1160_00_INSERT_APOLCOBR_DB_INSERT_1_Insert1()
            {
                APOLCOBR_COD_EMPRESA = APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_EMPRESA.ToString(),
                APOLCOBR_COD_FONTE = APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_FONTE.ToString(),
                APOLCOBR_NUM_APOLICE = APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_APOLICE.ToString(),
                APOLCOBR_NUM_ENDOSSO = APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_ENDOSSO.ToString(),
                APOLCOBR_COD_PRODUTO = APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_PRODUTO.ToString(),
                APOLCOBR_NUM_MATRICULA = APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_MATRICULA.ToString(),
                APOLCOBR_TIPO_COBRANCA = APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_TIPO_COBRANCA.ToString(),
                APOLCOBR_AGE_COBRANCA = APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_AGE_COBRANCA.ToString(),
                APOLCOBR_COD_AGENCIA = APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_AGENCIA.ToString(),
                APOLCOBR_OPERACAO_CONTA = APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_OPERACAO_CONTA.ToString(),
                APOLCOBR_NUM_CONTA = APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_CONTA.ToString(),
                APOLCOBR_DIG_CONTA = APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_DIG_CONTA.ToString(),
                APOLCOBR_COD_AGENCIA_DEB = APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_AGENCIA_DEB.ToString(),
                VIND_AGENCIA = VIND_AGENCIA.ToString(),
                APOLCOBR_OPER_CONTA_DEB = APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_OPER_CONTA_DEB.ToString(),
                VIND_OPERACAO = VIND_OPERACAO.ToString(),
                APOLCOBR_NUM_CONTA_DEB = APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_CONTA_DEB.ToString(),
                VIND_NUMCONTA = VIND_NUMCONTA.ToString(),
                APOLCOBR_DIG_CONTA_DEB = APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_DIG_CONTA_DEB.ToString(),
                VIND_DIGCONTA = VIND_DIGCONTA.ToString(),
                APOLCOBR_NUM_CARTAO = APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_CARTAO.ToString(),
                VIND_CARTAO_CREDITO = VIND_CARTAO_CREDITO.ToString(),
                APOLCOBR_DIA_DEBITO = APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_DIA_DEBITO.ToString(),
                VIND_DIADEBITO = VIND_DIADEBITO.ToString(),
                APOLCOBR_NR_CERTIF_AUTO = APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NR_CERTIF_AUTO.ToString(),
                VIND_NRCERTIF = VIND_NRCERTIF.ToString(),
                APOLCOBR_MARGEM_COMERCIAL = APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_MARGEM_COMERCIAL.ToString(),
            };

            R1160_00_INSERT_APOLCOBR_DB_INSERT_1_Insert1.Execute(r1160_00_INSERT_APOLCOBR_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1160_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-UPDATE-GELIMRISCO-SECTION */
        private void R1400_00_UPDATE_GELIMRISCO_SECTION()
        {
            /*" -4690- MOVE '1400' TO WNR-EXEC-SQL. */
            _.Move("1400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4697- PERFORM R1400_00_UPDATE_GELIMRISCO_DB_UPDATE_1 */

            R1400_00_UPDATE_GELIMRISCO_DB_UPDATE_1();

            /*" -4700- IF SQLCODE NOT EQUAL ZEROES AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -4702- DISPLAY 'R1400 - ERRO UPDATE GE_LIMITE_DE_RISCO..' SQLCODE */
                _.Display($"R1400 - ERRO UPDATE GE_LIMITE_DE_RISCO..{DB.SQLCODE}");

                /*" -4703- DISPLAY 'NUMBIL = ' V0BILH-NUMBIL */
                _.Display($"NUMBIL = {V0BILH_NUMBIL}");

                /*" -4704- DISPLAY 'CODCLI = ' V0BILH-CODCLIEN */
                _.Display($"CODCLI = {V0BILH_CODCLIEN}");

                /*" -4705- DISPLAY 'CGCCPF = ' V0CLIE-CGCCPF */
                _.Display($"CGCCPF = {V0CLIE_CGCCPF}");

                /*" -4707- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4707- ADD +1 TO AC-U-GELMR. */
            AREA_DE_WORK.AC_U_GELMR.Value = AREA_DE_WORK.AC_U_GELMR + +1;

        }

        [StopWatch]
        /*" R1400-00-UPDATE-GELIMRISCO-DB-UPDATE-1 */
        public void R1400_00_UPDATE_GELIMRISCO_DB_UPDATE_1()
        {
            /*" -4697- EXEC SQL UPDATE SEGUROS.GE_LIMITE_DE_RISCO SET QTD_SEGUROS = :GELMR-QTD-SEGUROS, VLR_SOMA_IS = :GELMR-VLR-SOMA-IS, COD_USUARIO = 'BI8005B' , DTH_TIMESTAMP = CURRENT TIMESTAMP WHERE CGCCPF = :V0CLIE-CGCCPF END-EXEC. */

            var r1400_00_UPDATE_GELIMRISCO_DB_UPDATE_1_Update1 = new R1400_00_UPDATE_GELIMRISCO_DB_UPDATE_1_Update1()
            {
                GELMR_QTD_SEGUROS = GELMR_QTD_SEGUROS.ToString(),
                GELMR_VLR_SOMA_IS = GELMR_VLR_SOMA_IS.ToString(),
                V0CLIE_CGCCPF = V0CLIE_CGCCPF.ToString(),
            };

            R1400_00_UPDATE_GELIMRISCO_DB_UPDATE_1_Update1.Execute(r1400_00_UPDATE_GELIMRISCO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-INSERT-GELIMRISCO-SECTION */
        private void R1500_00_INSERT_GELIMRISCO_SECTION()
        {
            /*" -4719- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4728- PERFORM R1500_00_INSERT_GELIMRISCO_DB_INSERT_1 */

            R1500_00_INSERT_GELIMRISCO_DB_INSERT_1();

            /*" -4731- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -4733- DISPLAY 'R1500 - ERRO INSERT GE_LIMITE_DE_RISCO..' SQLCODE */
                _.Display($"R1500 - ERRO INSERT GE_LIMITE_DE_RISCO..{DB.SQLCODE}");

                /*" -4736- DISPLAY 'CGCCPF ' V0CLIE-CGCCPF '  ' 'NUMBIL ' V0BILH-NUMBIL '  ' 'CODCLI ' V0BILH-CODCLIEN */

                $"CGCCPF {V0CLIE_CGCCPF}  NUMBIL {V0BILH_NUMBIL}  CODCLI {V0BILH_CODCLIEN}"
                .Display();

                /*" -4738- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4738- ADD +1 TO AC-I-GELMR. */
            AREA_DE_WORK.AC_I_GELMR.Value = AREA_DE_WORK.AC_I_GELMR + +1;

        }

        [StopWatch]
        /*" R1500-00-INSERT-GELIMRISCO-DB-INSERT-1 */
        public void R1500_00_INSERT_GELIMRISCO_DB_INSERT_1()
        {
            /*" -4728- EXEC SQL INSERT INTO SEGUROS.GE_LIMITE_DE_RISCO VALUES (:V0CLIE-CGCCPF , :V0BILH-RAMO , :GELMR-QTD-SEGUROS , :GELMR-VLR-SOMA-IS , CURRENT DATE , 'BI8005B' , CURRENT TIMESTAMP) END-EXEC. */

            var r1500_00_INSERT_GELIMRISCO_DB_INSERT_1_Insert1 = new R1500_00_INSERT_GELIMRISCO_DB_INSERT_1_Insert1()
            {
                V0CLIE_CGCCPF = V0CLIE_CGCCPF.ToString(),
                V0BILH_RAMO = V0BILH_RAMO.ToString(),
                GELMR_QTD_SEGUROS = GELMR_QTD_SEGUROS.ToString(),
                GELMR_VLR_SOMA_IS = GELMR_VLR_SOMA_IS.ToString(),
            };

            R1500_00_INSERT_GELIMRISCO_DB_INSERT_1_Insert1.Execute(r1500_00_INSERT_GELIMRISCO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-LIBERA-BILHETE-SECTION */
        private void R3000_00_LIBERA_BILHETE_SECTION()
        {
            /*" -4750- MOVE '3000' TO WNR-EXEC-SQL. */
            _.Move("3000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4753- MOVE '.' TO WS000-P1 WS000-P2. */
            _.Move(".", WS000_HORA_TIME_REDF.WS000_P1);
            _.Move(".", WS000_HORA_TIME_REDF.WS000_P2);


            /*" -4756- MOVE V0BILH-NUMBIL TO WWORK-NUMBIL V0APOL-NUMBIL. */
            _.Move(V0BILH_NUMBIL, AREA_DE_WORK.WWORK_NUMBIL, V0APOL_NUMBIL);

            /*" -4757- MOVE V0RCAP-NRRCAP TO WWORK-NRRCAP */
            _.Move(V0RCAP_NRRCAP, AREA_DE_WORK.FILLER_4.WWORK_NRRCAP);

            /*" -4760- MOVE V0RCAP-NRRCAP TO WHOST-NRRCAP. */
            _.Move(V0RCAP_NRRCAP, WHOST_NRRCAP);

            /*" -4775- PERFORM R3000_00_LIBERA_BILHETE_DB_SELECT_1 */

            R3000_00_LIBERA_BILHETE_DB_SELECT_1();

            /*" -4778- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4779- DISPLAY 'R3000-00 (ERRO - SELECT V1RCAPCOMP)... ' */
                _.Display($"R3000-00 (ERRO - SELECT V1RCAPCOMP)... ");

                /*" -4782- DISPLAY 'FONTE: ' V0BILH-FONTE '  ' 'NRRCAP: ' WHOST-NRRCAP '  ' 'BILHETE: ' V0BILH-NUMBIL */

                $"FONTE: {V0BILH_FONTE}  NRRCAP: {WHOST_NRRCAP}  BILHETE: {V0BILH_NUMBIL}"
                .Display();

                /*" -4788- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4788- PERFORM R3170-00-UPDATE-BILHETE. */

            R3170_00_UPDATE_BILHETE_SECTION();

        }

        [StopWatch]
        /*" R3000-00-LIBERA-BILHETE-DB-SELECT-1 */
        public void R3000_00_LIBERA_BILHETE_DB_SELECT_1()
        {
            /*" -4775- EXEC SQL SELECT BCOAVISO , AGEAVISO , NRAVISO , DATARCAP INTO :V1RCAC-BCOAVISO , :V1RCAC-AGEAVISO , :V1RCAC-NRAVISO , :V1RCAC-DATARCAP FROM SEGUROS.V1RCAPCOMP WHERE FONTE = :V0RCAP-FONTE AND NRRCAP = :WHOST-NRRCAP AND NRRCAPCO = 0 AND OPERACAO = :V0RCAP-OPERACAO AND SITUACAO = '0' END-EXEC. */

            var r3000_00_LIBERA_BILHETE_DB_SELECT_1_Query1 = new R3000_00_LIBERA_BILHETE_DB_SELECT_1_Query1()
            {
                V0RCAP_OPERACAO = V0RCAP_OPERACAO.ToString(),
                V0RCAP_FONTE = V0RCAP_FONTE.ToString(),
                WHOST_NRRCAP = WHOST_NRRCAP.ToString(),
            };

            var executed_1 = R3000_00_LIBERA_BILHETE_DB_SELECT_1_Query1.Execute(r3000_00_LIBERA_BILHETE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1RCAC_BCOAVISO, V1RCAC_BCOAVISO);
                _.Move(executed_1.V1RCAC_AGEAVISO, V1RCAC_AGEAVISO);
                _.Move(executed_1.V1RCAC_NRAVISO, V1RCAC_NRAVISO);
                _.Move(executed_1.V1RCAC_DATARCAP, V1RCAC_DATARCAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3020-00-UPDATE-V0BILHETE-SECTION */
        private void R3020_00_UPDATE_V0BILHETE_SECTION()
        {
            /*" -4800- MOVE '3020' TO WNR-EXEC-SQL. */
            _.Move("3020", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4806- PERFORM R3020_00_UPDATE_V0BILHETE_DB_UPDATE_1 */

            R3020_00_UPDATE_V0BILHETE_DB_UPDATE_1();

            /*" -4809- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4810- DISPLAY 'R3020-00 (ERRO - UPDATE V0BILHETE)...' */
                _.Display($"R3020-00 (ERRO - UPDATE V0BILHETE)...");

                /*" -4811- DISPLAY 'BILHETE: ' V0BILH-NUMBIL '  ' */

                $"BILHETE: {V0BILH_NUMBIL}  "
                .Display();

                /*" -4813- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4813- ADD +1 TO AC-U-V0BILHETE. */
            AREA_DE_WORK.AC_U_V0BILHETE.Value = AREA_DE_WORK.AC_U_V0BILHETE + +1;

        }

        [StopWatch]
        /*" R3020-00-UPDATE-V0BILHETE-DB-UPDATE-1 */
        public void R3020_00_UPDATE_V0BILHETE_DB_UPDATE_1()
        {
            /*" -4806- EXEC SQL UPDATE SEGUROS.V0BILHETE SET SITUACAO = :V0BILH-SITUACAO, TIMESTAMP = CURRENT TIMESTAMP, COD_USUARIO = 'BI8005B' WHERE NUMBIL = :V0BILH-NUMBIL END-EXEC. */

            var r3020_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 = new R3020_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1()
            {
                V0BILH_SITUACAO = V0BILH_SITUACAO.ToString(),
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            R3020_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1.Execute(r3020_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3020_99_SAIDA*/

        [StopWatch]
        /*" R3040-00-MONTA-V0BILHETE-SECTION */
        private void R3040_00_MONTA_V0BILHETE_SECTION()
        {
            /*" -4824- MOVE '3040' TO WNR-EXEC-SQL. */
            _.Move("3040", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4826- IF (V0BILH-DTQITBCO NOT EQUAL V1RCAC-DATARCAP) */

            if ((V0BILH_DTQITBCO != V1RCAC_DATARCAP))
            {

                /*" -4827- MOVE 11901 TO V0BILER-COD-ERRO */
                _.Move(11901, V0BILER_COD_ERRO);

                /*" -4829- PERFORM R3045-00-GRAVA-TAB-ERRO. */

                R3045_00_GRAVA_TAB_ERRO_SECTION();
            }


            /*" -4831- IF (V0BILH-VLRCAP NOT EQUAL V2RCAP-VLRCAP) */

            if ((V0BILH_VLRCAP != V2RCAP_VLRCAP))
            {

                /*" -4832- MOVE 12101 TO V0BILER-COD-ERRO */
                _.Move(12101, V0BILER_COD_ERRO);

                /*" -4832- PERFORM R3045-00-GRAVA-TAB-ERRO. */

                R3045_00_GRAVA_TAB_ERRO_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3040_99_SAIDA*/

        [StopWatch]
        /*" R3045-00-GRAVA-TAB-ERRO-SECTION */
        private void R3045_00_GRAVA_TAB_ERRO_SECTION()
        {
            /*" -4845- MOVE '3045' TO WNR-EXEC-SQL. */
            _.Move("3045", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4847- ADD 1 TO WS-I-ERRO */
            WS_I_ERRO.Value = WS_I_ERRO + 1;

            /*" -4848- MOVE V0BILER-COD-ERRO TO TB-ERRO-CERT(WS-I-ERRO) */
            _.Move(V0BILER_COD_ERRO, WORK_TAB_ERROS_CERT.WS_TAB_ERROS_CERT[WS_I_ERRO].TB_ERRO_CERT);

            /*" -4848- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3045_99_SAIDA*/

        [StopWatch]
        /*" R3050-00-INSERE-ERRO-SECTION */
        private void R3050_00_INSERE_ERRO_SECTION()
        {
            /*" -4859- MOVE '3050' TO WNR-EXEC-SQL. */
            _.Move("3050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4861- INITIALIZE LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
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

            /*" -4862- MOVE 'N' TO LK-VG001-TRACE */
            _.Move("N", SPVG001W.LK_VG001_TRACE);

            /*" -4863- MOVE 02 TO LK-VG001-TIPO-ACAO */
            _.Move(02, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -4864- MOVE V0BILH-NUMBIL TO LK-VG001-NUM-CERTIFICADO */
            _.Move(V0BILH_NUMBIL, SPVG001W.LK_VG001_NUM_CERTIFICADO);

            /*" -4865- MOVE TB-ERRO-CERT(WS-I-ERRO) TO LK-VG001-COD-MSG-CRITICA */
            _.Move(WORK_TAB_ERROS_CERT.WS_TAB_ERROS_CERT[WS_I_ERRO].TB_ERRO_CERT, SPVG001W.LK_VG001_COD_MSG_CRITICA);

            /*" -4866- MOVE 0 TO LK-VG001-SEQ-CRITICA */
            _.Move(0, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -4867- MOVE 'BI' TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("BI", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -4868- MOVE 0 TO LK-VG001-NUM-CPF-CNPJ */
            _.Move(0, SPVG001W.LK_VG001_NUM_CPF_CNPJ);

            /*" -4869- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -4870- MOVE 'BI8005B' TO LK-VG001-NOM-PROGRAMA */
            _.Move("BI8005B", SPVG001W.LK_VG001_NOM_PROGRAMA);

            /*" -4871- MOVE 'SPBVG001' TO VG001-PROGRAMA */
            _.Move("SPBVG001", SPVG001V.VG001_PROGRAMA);

            /*" -4872- MOVE SPACES TO LK-VG001-STA-CRITICA */
            _.Move("", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -4873- MOVE 50 TO LK-VG001-DES-COMPLEMENTAR-L */
            _.Move(50, SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_L);

            /*" -4876- MOVE 'INSERCAO DE ERRO NA EMISSAO DA PROPOSTA' TO LK-VG001-DES-COMPLEMENTAR-T */
            _.Move("INSERCAO DE ERRO NA EMISSAO DA PROPOSTA", SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_T);

            /*" -4878- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -4879- IF LK-VG001-IND-ERRO NOT EQUAL ZEROS */

            if (SPVG001W.LK_VG001_IND_ERRO != 00)
            {

                /*" -4880- IF LK-VG001-IND-ERRO EQUAL 1 */

                if (SPVG001W.LK_VG001_IND_ERRO == 1)
                {

                    /*" -4884- DISPLAY 'ERRO JAH GRAVADO 3050 >> ' LK-VG001-NUM-CERTIFICADO ' >> ' LK-VG001-COD-MSG-CRITICA ' >> ' LK-VG001-IND-ERRO */

                    $"ERRO JAH GRAVADO 3050 >> {SPVG001W.LK_VG001_NUM_CERTIFICADO} >> {SPVG001W.LK_VG001_COD_MSG_CRITICA} >> {SPVG001W.LK_VG001_IND_ERRO}"
                    .Display();

                    /*" -4885- DISPLAY 'MSG-ERRO: ' LK-VG001-MSG-ERRO */
                    _.Display($"MSG-ERRO: {SPVG001W.LK_VG001_MSG_ERRO}");

                    /*" -4886- ELSE */
                }
                else
                {


                    /*" -4887- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -4888- DISPLAY '* 3050 -  PROBLEMAS CALL SUBROTINA SPBVG001 *' */
                    _.Display($"* 3050 -  PROBLEMAS CALL SUBROTINA SPBVG001 *");

                    /*" -4889- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -4890- DISPLAY '* NUM-CERTIF..: ' LK-VG001-NUM-CERTIFICADO */
                    _.Display($"* NUM-CERTIF..: {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                    /*" -4891- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                    _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                    /*" -4892- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                    _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                    /*" -4893- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                    _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                    /*" -4894- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                    _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                    /*" -4895- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                    _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                    /*" -4897- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -4898- MOVE 999 TO SQLCODE */
                    _.Move(999, DB.SQLCODE);

                    /*" -4899- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4900- END-IF */
                }


                /*" -4902- END-IF */
            }


            /*" -4904- ADD 1 TO WS-I-ERRO */
            WS_I_ERRO.Value = WS_I_ERRO + 1;

            /*" -4905- IF TB-ERRO-CERT(WS-I-ERRO) EQUAL ZEROS */

            if (WORK_TAB_ERROS_CERT.WS_TAB_ERROS_CERT[WS_I_ERRO].TB_ERRO_CERT == 00)
            {

                /*" -4906- MOVE 'N' TO WS-FLAG-TEM-ERRO */
                _.Move("N", WS_FLAG_TEM_ERRO);

                /*" -4907- END-IF */
            }


            /*" -4907- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3050_99_SAIDA*/

        [StopWatch]
        /*" R3060-00-VERIFICA-CRTCA-PEND-SECTION */
        private void R3060_00_VERIFICA_CRTCA_PEND_SECTION()
        {
            /*" -4934- MOVE '3060' TO WNR-EXEC-SQL. */
            _.Move("3060", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4936- MOVE ZEROS TO WS-ERRO-COUNT */
            _.Move(0, WS_ERRO_COUNT);

            /*" -4946- PERFORM R3060_00_VERIFICA_CRTCA_PEND_DB_SELECT_1 */

            R3060_00_VERIFICA_CRTCA_PEND_DB_SELECT_1();

            /*" -4949- IF SQLCODE NOT EQUAL ZEROS AND +100 */

            if (!DB.SQLCODE.In("00", "+100"))
            {

                /*" -4950- DISPLAY 'R1510-00 - PROBLEMAS NO SELECT(V0ERROS)  ' */
                _.Display($"R1510-00 - PROBLEMAS NO SELECT(V0ERROS)  ");

                /*" -4951- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4952- END-IF */
            }


            /*" -4952- . */

        }

        [StopWatch]
        /*" R3060-00-VERIFICA-CRTCA-PEND-DB-SELECT-1 */
        public void R3060_00_VERIFICA_CRTCA_PEND_DB_SELECT_1()
        {
            /*" -4946- EXEC SQL SELECT VALUE(COUNT(*), 0) INTO :WS-ERRO-COUNT FROM SEGUROS.VG_CRITICA_PROPOSTA A, SEGUROS.VG_DM_MSG_CRITICA B WHERE A.NUM_CERTIFICADO = :V0BILH-NUMBIL AND A.STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' ) AND A.COD_MSG_CRITICA = B.COD_MSG_CRITICA AND B.COD_TP_MSG_CRITICA <> 3 WITH UR END-EXEC. */

            var r3060_00_VERIFICA_CRTCA_PEND_DB_SELECT_1_Query1 = new R3060_00_VERIFICA_CRTCA_PEND_DB_SELECT_1_Query1()
            {
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            var executed_1 = R3060_00_VERIFICA_CRTCA_PEND_DB_SELECT_1_Query1.Execute(r3060_00_VERIFICA_CRTCA_PEND_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_ERRO_COUNT, WS_ERRO_COUNT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3060_99_SAIDA*/

        [StopWatch]
        /*" R3170-00-UPDATE-BILHETE-SECTION */
        private void R3170_00_UPDATE_BILHETE_SECTION()
        {
            /*" -4962- MOVE '3170' TO WNR-EXEC-SQL. */
            _.Move("3170", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4967- PERFORM R3170_00_UPDATE_BILHETE_DB_SELECT_1 */

            R3170_00_UPDATE_BILHETE_DB_SELECT_1();

            /*" -4970- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4971- DISPLAY 'R3170-00 (ERRO - SELECT V1FONTE)...' */
                _.Display($"R3170-00 (ERRO - SELECT V1FONTE)...");

                /*" -4973- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4977- COMPUTE V1FONT-PROPAUTOM = V1FONT-PROPAUTOM + 1. */
            V1FONT_PROPAUTOM.Value = V1FONT_PROPAUTOM + 1;

            /*" -4980- PERFORM R3180-00-LE-ENDOSSO. */

            R3180_00_LE_ENDOSSO_SECTION();

            /*" -4984- PERFORM R3170_00_UPDATE_BILHETE_DB_UPDATE_1 */

            R3170_00_UPDATE_BILHETE_DB_UPDATE_1();

            /*" -4987- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4988- DISPLAY 'R3170-00 (ERRO - UPDATE V0FONTE)...' */
                _.Display($"R3170-00 (ERRO - UPDATE V0FONTE)...");

                /*" -4991- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4992- ADD 1 TO WWORK-NUM-ITENS WPROC-BILHETES. */
            AREA_DE_WORK.WWORK_NUM_ITENS.Value = AREA_DE_WORK.WWORK_NUM_ITENS + 1;
            AREA_DE_WORK.WPROC_BILHETES.Value = AREA_DE_WORK.WPROC_BILHETES + 1;

        }

        [StopWatch]
        /*" R3170-00-UPDATE-BILHETE-DB-SELECT-1 */
        public void R3170_00_UPDATE_BILHETE_DB_SELECT_1()
        {
            /*" -4967- EXEC SQL SELECT PROPAUTOM INTO :V1FONT-PROPAUTOM FROM SEGUROS.V1FONTE WHERE FONTE = :V0BILH-FONTE END-EXEC. */

            var r3170_00_UPDATE_BILHETE_DB_SELECT_1_Query1 = new R3170_00_UPDATE_BILHETE_DB_SELECT_1_Query1()
            {
                V0BILH_FONTE = V0BILH_FONTE.ToString(),
            };

            var executed_1 = R3170_00_UPDATE_BILHETE_DB_SELECT_1_Query1.Execute(r3170_00_UPDATE_BILHETE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1FONT_PROPAUTOM, V1FONT_PROPAUTOM);
            }


        }

        [StopWatch]
        /*" R3170-00-UPDATE-BILHETE-DB-UPDATE-1 */
        public void R3170_00_UPDATE_BILHETE_DB_UPDATE_1()
        {
            /*" -4984- EXEC SQL UPDATE SEGUROS.V0FONTE SET PROPAUTOM = :V1FONT-PROPAUTOM WHERE FONTE = :V0BILH-FONTE END-EXEC. */

            var r3170_00_UPDATE_BILHETE_DB_UPDATE_1_Update1 = new R3170_00_UPDATE_BILHETE_DB_UPDATE_1_Update1()
            {
                V1FONT_PROPAUTOM = V1FONT_PROPAUTOM.ToString(),
                V0BILH_FONTE = V0BILH_FONTE.ToString(),
            };

            R3170_00_UPDATE_BILHETE_DB_UPDATE_1_Update1.Execute(r3170_00_UPDATE_BILHETE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3170_99_SAIDA*/

        [StopWatch]
        /*" R3180-00-LE-ENDOSSO-SECTION */
        private void R3180_00_LE_ENDOSSO_SECTION()
        {
            /*" -5003- MOVE '3180' TO WNR-EXEC-SQL. */
            _.Move("3180", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5009- PERFORM R3180_00_LE_ENDOSSO_DB_SELECT_1 */

            R3180_00_LE_ENDOSSO_DB_SELECT_1();

            /*" -5012- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -5013- DISPLAY '(PROPOSTA DUPLICADA NA ENDOSSO)... ' */
                _.Display($"(PROPOSTA DUPLICADA NA ENDOSSO)... ");

                /*" -5014- DISPLAY ' FONTE    - ' V0BILH-FONTE */
                _.Display($" FONTE    - {V0BILH_FONTE}");

                /*" -5015- DISPLAY ' PROPOSTA - ' V1FONT-PROPAUTOM */
                _.Display($" PROPOSTA - {V1FONT_PROPAUTOM}");

                /*" -5016- COMPUTE V1FONT-PROPAUTOM = V1FONT-PROPAUTOM + 1 */
                V1FONT_PROPAUTOM.Value = V1FONT_PROPAUTOM + 1;

                /*" -5017- GO TO R3180-00-LE-ENDOSSO */
                new Task(() => R3180_00_LE_ENDOSSO_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -5018- ELSE */
            }
            else
            {


                /*" -5019- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -5020- DISPLAY 'R3180-00 (ERRO - SELECT V1ENDOSSO)... ' */
                    _.Display($"R3180-00 (ERRO - SELECT V1ENDOSSO)... ");

                    /*" -5021- DISPLAY 'FONTE    - ' V0BILH-FONTE */
                    _.Display($"FONTE    - {V0BILH_FONTE}");

                    /*" -5022- DISPLAY 'PROPOSTA - ' V1FONT-PROPAUTOM */
                    _.Display($"PROPOSTA - {V1FONT_PROPAUTOM}");

                    /*" -5022- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R3180-00-LE-ENDOSSO-DB-SELECT-1 */
        public void R3180_00_LE_ENDOSSO_DB_SELECT_1()
        {
            /*" -5009- EXEC SQL SELECT NRPROPOS INTO :V0ENDO-NRPROPOS FROM SEGUROS.V1ENDOSSO WHERE FONTE = :V0BILH-FONTE AND NRPROPOS = :V1FONT-PROPAUTOM END-EXEC. */

            var r3180_00_LE_ENDOSSO_DB_SELECT_1_Query1 = new R3180_00_LE_ENDOSSO_DB_SELECT_1_Query1()
            {
                V1FONT_PROPAUTOM = V1FONT_PROPAUTOM.ToString(),
                V0BILH_FONTE = V0BILH_FONTE.ToString(),
            };

            var executed_1 = R3180_00_LE_ENDOSSO_DB_SELECT_1_Query1.Execute(r3180_00_LE_ENDOSSO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ENDO_NRPROPOS, V0ENDO_NRPROPOS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3180_99_SAIDA*/

        [StopWatch]
        /*" R3200-00-BAIXA-RCAP-SECTION */
        private void R3200_00_BAIXA_RCAP_SECTION()
        {
            /*" -5032- MOVE '3200' TO WNR-EXEC-SQL. */
            _.Move("3200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R3200_10_DECLARE_V0RCAPCOMP */

            R3200_10_DECLARE_V0RCAPCOMP();

        }

        [StopWatch]
        /*" R3200-10-DECLARE-V0RCAPCOMP */
        private void R3200_10_DECLARE_V0RCAPCOMP(bool isPerform = false)
        {
            /*" -5054- PERFORM R3200_10_DECLARE_V0RCAPCOMP_DB_DECLARE_1 */

            R3200_10_DECLARE_V0RCAPCOMP_DB_DECLARE_1();

            /*" -5056- PERFORM R3200_10_DECLARE_V0RCAPCOMP_DB_OPEN_1 */

            R3200_10_DECLARE_V0RCAPCOMP_DB_OPEN_1();

        }

        [StopWatch]
        /*" R3200-10-DECLARE-V0RCAPCOMP-DB-OPEN-1 */
        public void R3200_10_DECLARE_V0RCAPCOMP_DB_OPEN_1()
        {
            /*" -5056- EXEC SQL OPEN V1RCAPCOMP END-EXEC. */

            V1RCAPCOMP.Open();

        }

        [StopWatch]
        /*" R3200-20-FETCH-V0RCAPCOMP */
        private void R3200_20_FETCH_V0RCAPCOMP(bool isPerform = false)
        {
            /*" -5076- PERFORM R3200_20_FETCH_V0RCAPCOMP_DB_FETCH_1 */

            R3200_20_FETCH_V0RCAPCOMP_DB_FETCH_1();

            /*" -5079- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5080- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5080- PERFORM R3200_20_FETCH_V0RCAPCOMP_DB_CLOSE_1 */

                    R3200_20_FETCH_V0RCAPCOMP_DB_CLOSE_1();

                    /*" -5082- GO TO R3200-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/ //GOTO
                    return;

                    /*" -5083- ELSE */
                }
                else
                {


                    /*" -5084- DISPLAY 'R3200-20 (PROBLEMAS FETCH V1RCAPCOMP)... ' */
                    _.Display($"R3200-20 (PROBLEMAS FETCH V1RCAPCOMP)... ");

                    /*" -5087- DISPLAY 'FONTE: ' V0RCAP-FONTE '  ' 'RECIBO: ' V0RCAP-NRRCAP '  ' 'BILHETE: ' V0BILH-NUMBIL */

                    $"FONTE: {V0RCAP_FONTE}  RECIBO: {V0RCAP_NRRCAP}  BILHETE: {V0BILH_NUMBIL}"
                    .Display();

                    /*" -5089- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -5090- IF V1RCAC-SITUACAO NOT EQUAL '0' */

            if (V1RCAC_SITUACAO != "0")
            {

                /*" -5092- GO TO R3200-20-FETCH-V0RCAPCOMP. */
                new Task(() => R3200_20_FETCH_V0RCAPCOMP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -5094- IF V1RCAC-OPERACAO GREATER 199 AND V1RCAC-OPERACAO LESS 300 */

            if (V1RCAC_OPERACAO > 199 && V1RCAC_OPERACAO < 300)
            {

                /*" -5096- GO TO R3200-20-FETCH-V0RCAPCOMP. */
                new Task(() => R3200_20_FETCH_V0RCAPCOMP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -5098- IF V1RCAC-OPERACAO GREATER 399 AND V1RCAC-OPERACAO LESS 500 */

            if (V1RCAC_OPERACAO > 399 && V1RCAC_OPERACAO < 500)
            {

                /*" -5098- GO TO R3200-20-FETCH-V0RCAPCOMP. */
                new Task(() => R3200_20_FETCH_V0RCAPCOMP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }

        [StopWatch]
        /*" R3200-20-FETCH-V0RCAPCOMP-DB-FETCH-1 */
        public void R3200_20_FETCH_V0RCAPCOMP_DB_FETCH_1()
        {
            /*" -5076- EXEC SQL FETCH V1RCAPCOMP INTO :V1RCAC-FONTE , :V1RCAC-NRRCAP , :V1RCAC-NRRCAPCO , :V1RCAC-OPERACAO , :V1RCAC-DTMOVTO , :V1RCAC-HORAOPER , :V1RCAC-SITUACAO , :V1RCAC-BCOAVISO , :V1RCAC-AGEAVISO , :V1RCAC-NRAVISO , :V1RCAC-VLRCAP , :V1RCAC-DATARCAP , :V1RCAC-DTCADAST , :V1RCAC-SITCONTB END-EXEC. */

            if (V1RCAPCOMP.Fetch())
            {
                _.Move(V1RCAPCOMP.V1RCAC_FONTE, V1RCAC_FONTE);
                _.Move(V1RCAPCOMP.V1RCAC_NRRCAP, V1RCAC_NRRCAP);
                _.Move(V1RCAPCOMP.V1RCAC_NRRCAPCO, V1RCAC_NRRCAPCO);
                _.Move(V1RCAPCOMP.V1RCAC_OPERACAO, V1RCAC_OPERACAO);
                _.Move(V1RCAPCOMP.V1RCAC_DTMOVTO, V1RCAC_DTMOVTO);
                _.Move(V1RCAPCOMP.V1RCAC_HORAOPER, V1RCAC_HORAOPER);
                _.Move(V1RCAPCOMP.V1RCAC_SITUACAO, V1RCAC_SITUACAO);
                _.Move(V1RCAPCOMP.V1RCAC_BCOAVISO, V1RCAC_BCOAVISO);
                _.Move(V1RCAPCOMP.V1RCAC_AGEAVISO, V1RCAC_AGEAVISO);
                _.Move(V1RCAPCOMP.V1RCAC_NRAVISO, V1RCAC_NRAVISO);
                _.Move(V1RCAPCOMP.V1RCAC_VLRCAP, V1RCAC_VLRCAP);
                _.Move(V1RCAPCOMP.V1RCAC_DATARCAP, V1RCAC_DATARCAP);
                _.Move(V1RCAPCOMP.V1RCAC_DTCADAST, V1RCAC_DTCADAST);
                _.Move(V1RCAPCOMP.V1RCAC_SITCONTB, V1RCAC_SITCONTB);
            }

        }

        [StopWatch]
        /*" R3200-20-FETCH-V0RCAPCOMP-DB-CLOSE-1 */
        public void R3200_20_FETCH_V0RCAPCOMP_DB_CLOSE_1()
        {
            /*" -5080- EXEC SQL CLOSE V1RCAPCOMP END-EXEC */

            V1RCAPCOMP.Close();

        }

        [StopWatch]
        /*" R3200-30-UPDATE-V0RCAPCOMP */
        private void R3200_30_UPDATE_V0RCAPCOMP(bool isPerform = false)
        {
            /*" -5112- PERFORM R3200_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1 */

            R3200_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1();

            /*" -5115- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5116- DISPLAY 'R3200-30 (ERRO - UPDATE V0RCAPCOMP)...' */
                _.Display($"R3200-30 (ERRO - UPDATE V0RCAPCOMP)...");

                /*" -5119- DISPLAY 'FONTE: ' V1RCAC-FONTE ' ' 'RECIBO: ' V1RCAC-NRRCAP 'BILHETE: ' V0BILH-NUMBIL */

                $"FONTE: {V1RCAC_FONTE} RECIBO: {V1RCAC_NRRCAP}BILHETE: {V0BILH_NUMBIL}"
                .Display();

                /*" -5121- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5121- ADD +1 TO AC-U-V0RCAPCOMP. */
            AREA_DE_WORK.AC_U_V0RCAPCOMP.Value = AREA_DE_WORK.AC_U_V0RCAPCOMP + +1;

        }

        [StopWatch]
        /*" R3200-30-UPDATE-V0RCAPCOMP-DB-UPDATE-1 */
        public void R3200_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1()
        {
            /*" -5112- EXEC SQL UPDATE SEGUROS.V0RCAPCOMP SET SITUACAO = '1' , TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :V1RCAC-FONTE AND NRRCAP = :V1RCAC-NRRCAP AND NRRCAPCO = :V1RCAC-NRRCAPCO AND OPERACAO = :V1RCAC-OPERACAO AND DTMOVTO = :V1RCAC-DTMOVTO AND HORAOPER = :V1RCAC-HORAOPER END-EXEC. */

            var r3200_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1 = new R3200_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1()
            {
                V1RCAC_NRRCAPCO = V1RCAC_NRRCAPCO.ToString(),
                V1RCAC_OPERACAO = V1RCAC_OPERACAO.ToString(),
                V1RCAC_HORAOPER = V1RCAC_HORAOPER.ToString(),
                V1RCAC_DTMOVTO = V1RCAC_DTMOVTO.ToString(),
                V1RCAC_NRRCAP = V1RCAC_NRRCAP.ToString(),
                V1RCAC_FONTE = V1RCAC_FONTE.ToString(),
            };

            R3200_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1.Execute(r3200_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R3200-40-INSERT-V0RCAPCOMP */
        private void R3200_40_INSERT_V0RCAPCOMP(bool isPerform = false)
        {
            /*" -5126- MOVE '0' TO V1RCAC-SITCONTB */
            _.Move("0", V1RCAC_SITCONTB);

            /*" -5127- MOVE '0' TO V1RCAC-SITUACAO */
            _.Move("0", V1RCAC_SITUACAO);

            /*" -5128- MOVE 220 TO V1RCAC-OPERACAO */
            _.Move(220, V1RCAC_OPERACAO);

            /*" -5129- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_TIME);

            /*" -5130- MOVE WS000-H TO WS000-HT */
            _.Move(WS_TIME.WS000_H, WS000_HORA_TIME_REDF.WS000_HT);

            /*" -5131- MOVE WS000-M TO WS000-MT */
            _.Move(WS_TIME.WS000_M, WS000_HORA_TIME_REDF.WS000_MT);

            /*" -5132- MOVE WS000-S TO WS000-ST */
            _.Move(WS_TIME.WS000_S, WS000_HORA_TIME_REDF.WS000_ST);

            /*" -5134- MOVE WS000-HORA-TIME TO V1RCAC-HORAOPER. */
            _.Move(WS000_HORA_TIME, V1RCAC_HORAOPER);

            /*" -5152- PERFORM R3200_40_INSERT_V0RCAPCOMP_DB_INSERT_1 */

            R3200_40_INSERT_V0RCAPCOMP_DB_INSERT_1();

            /*" -5155- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5156- DISPLAY 'R3200-40 (ERRO - INSERT V0RCAPCOMP)...' */
                _.Display($"R3200-40 (ERRO - INSERT V0RCAPCOMP)...");

                /*" -5159- DISPLAY 'BILHETE:  ' V0BILH-NUMBIL '  ' 'AGENCIA:  ' V1RCAC-AGEAVISO '  ' 'BANCO:    ' V1RCAC-BCOAVISO */

                $"BILHETE:  {V0BILH_NUMBIL}  AGENCIA:  {V1RCAC_AGEAVISO}  BANCO:    {V1RCAC_BCOAVISO}"
                .Display();

                /*" -5162- DISPLAY 'DATARCAP: ' V1RCAC-DATARCAP '  ' 'FONTE:    ' V1RCAC-FONTE '  ' 'NRRCAP:   ' V1RCAC-NRRCAP */

                $"DATARCAP: {V1RCAC_DATARCAP}  FONTE:    {V1RCAC_FONTE}  NRRCAP:   {V1RCAC_NRRCAP}"
                .Display();

                /*" -5164- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5164- ADD 1 TO AC-I-V0RCAPCOMP. */
            AREA_DE_WORK.AC_I_V0RCAPCOMP.Value = AREA_DE_WORK.AC_I_V0RCAPCOMP + 1;

        }

        [StopWatch]
        /*" R3200-40-INSERT-V0RCAPCOMP-DB-INSERT-1 */
        public void R3200_40_INSERT_V0RCAPCOMP_DB_INSERT_1()
        {
            /*" -5152- EXEC SQL INSERT INTO SEGUROS.V0RCAPCOMP VALUES (:V1RCAC-FONTE , :V1RCAC-NRRCAP , :V1RCAC-NRRCAPCO , :V1RCAC-OPERACAO , :V1SIST-DTMOVACB , :V1RCAC-HORAOPER , :V1RCAC-SITUACAO , :V1RCAC-BCOAVISO , :V1RCAC-AGEAVISO , :V1RCAC-NRAVISO , :V1RCAC-VLRCAP , :V1RCAC-DATARCAP , :V1RCAC-DTCADAST , :V1RCAC-SITCONTB , :V1RCAC-COD-EMPRESA , CURRENT TIMESTAMP) END-EXEC. */

            var r3200_40_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1 = new R3200_40_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1()
            {
                V1RCAC_FONTE = V1RCAC_FONTE.ToString(),
                V1RCAC_NRRCAP = V1RCAC_NRRCAP.ToString(),
                V1RCAC_NRRCAPCO = V1RCAC_NRRCAPCO.ToString(),
                V1RCAC_OPERACAO = V1RCAC_OPERACAO.ToString(),
                V1SIST_DTMOVACB = V1SIST_DTMOVACB.ToString(),
                V1RCAC_HORAOPER = V1RCAC_HORAOPER.ToString(),
                V1RCAC_SITUACAO = V1RCAC_SITUACAO.ToString(),
                V1RCAC_BCOAVISO = V1RCAC_BCOAVISO.ToString(),
                V1RCAC_AGEAVISO = V1RCAC_AGEAVISO.ToString(),
                V1RCAC_NRAVISO = V1RCAC_NRAVISO.ToString(),
                V1RCAC_VLRCAP = V1RCAC_VLRCAP.ToString(),
                V1RCAC_DATARCAP = V1RCAC_DATARCAP.ToString(),
                V1RCAC_DTCADAST = V1RCAC_DTCADAST.ToString(),
                V1RCAC_SITCONTB = V1RCAC_SITCONTB.ToString(),
                V1RCAC_COD_EMPRESA = V1RCAC_COD_EMPRESA.ToString(),
            };

            R3200_40_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1.Execute(r3200_40_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R3200-50-UPDATE-V0AVISOSALDO */
        private void R3200_50_UPDATE_V0AVISOSALDO(bool isPerform = false)
        {
            /*" -5177- PERFORM R3200_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1 */

            R3200_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1();

            /*" -5181- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -5182- DISPLAY 'R3200-50 (ERRO - INSERT V0AVISOSALDO)...' */
                _.Display($"R3200-50 (ERRO - INSERT V0AVISOSALDO)...");

                /*" -5185- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5185- GO TO R3200-20-FETCH-V0RCAPCOMP. */

            R3200_20_FETCH_V0RCAPCOMP(); //GOTO
            return;

        }

        [StopWatch]
        /*" R3200-50-UPDATE-V0AVISOSALDO-DB-UPDATE-1 */
        public void R3200_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1()
        {
            /*" -5177- EXEC SQL UPDATE SEGUROS.V0AVISOS_SALDOS SET SDOATU = (SDOATU - :V1RCAC-VLRCAP) WHERE BCOAVISO = :V1RCAC-BCOAVISO AND AGEAVISO = :V1RCAC-AGEAVISO AND NRAVISO = :V1RCAC-NRAVISO END-EXEC. */

            var r3200_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1 = new R3200_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1()
            {
                V1RCAC_VLRCAP = V1RCAC_VLRCAP.ToString(),
                V1RCAC_BCOAVISO = V1RCAC_BCOAVISO.ToString(),
                V1RCAC_AGEAVISO = V1RCAC_AGEAVISO.ToString(),
                V1RCAC_NRAVISO = V1RCAC_NRAVISO.ToString(),
            };

            R3200_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1.Execute(r3200_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/

        [StopWatch]
        /*" R3210-00-ALTERA-RCAPS-SECTION */
        private void R3210_00_ALTERA_RCAPS_SECTION()
        {
            /*" -5197- MOVE '3210' TO WNR-EXEC-SQL. */
            _.Move("3210", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5207- PERFORM R3210_00_ALTERA_RCAPS_DB_UPDATE_1 */

            R3210_00_ALTERA_RCAPS_DB_UPDATE_1();

            /*" -5210- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5211- DISPLAY 'R3210-00 (ERRO - UPDATE V0RCAP)...' */
                _.Display($"R3210-00 (ERRO - UPDATE V0RCAP)...");

                /*" -5214- DISPLAY 'BILHETE: ' V0BILH-NUMBIL '  ' 'FONTE: ' V0RCAP-FONTE '  ' 'NRRCAP: ' V0RCAP-NRRCAP */

                $"BILHETE: {V0BILH_NUMBIL}  FONTE: {V0RCAP_FONTE}  NRRCAP: {V0RCAP_NRRCAP}"
                .Display();

                /*" -5216- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5216- ADD 1 TO AC-U-V0RCAP. */
            AREA_DE_WORK.AC_U_V0RCAP.Value = AREA_DE_WORK.AC_U_V0RCAP + 1;

            /*" -0- FLUXCONTROL_PERFORM R3210_20_CROT */

            R3210_20_CROT();

        }

        [StopWatch]
        /*" R3210-00-ALTERA-RCAPS-DB-UPDATE-1 */
        public void R3210_00_ALTERA_RCAPS_DB_UPDATE_1()
        {
            /*" -5207- EXEC SQL UPDATE SEGUROS.V0RCAP SET SITUACAO = '1' ,OPERACAO = 220 ,NUM_APOLICE = :V0PARC-NUM-APOL ,NRENDOS = :V0PARC-NRENDOS ,NRPARCEL = :V0PARC-NRPARCEL ,TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :V0RCAP-FONTE AND NRRCAP = :V0RCAP-NRRCAP END-EXEC. */

            var r3210_00_ALTERA_RCAPS_DB_UPDATE_1_Update1 = new R3210_00_ALTERA_RCAPS_DB_UPDATE_1_Update1()
            {
                V0PARC_NUM_APOL = V0PARC_NUM_APOL.ToString(),
                V0PARC_NRPARCEL = V0PARC_NRPARCEL.ToString(),
                V0PARC_NRENDOS = V0PARC_NRENDOS.ToString(),
                V0RCAP_NRRCAP = V0RCAP_NRRCAP.ToString(),
                V0RCAP_FONTE = V0RCAP_FONTE.ToString(),
            };

            R3210_00_ALTERA_RCAPS_DB_UPDATE_1_Update1.Execute(r3210_00_ALTERA_RCAPS_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R3210-20-CROT */
        private void R3210_20_CROT(bool isPerform = false)
        {
            /*" -5228- PERFORM R3210_20_CROT_DB_SELECT_1 */

            R3210_20_CROT_DB_SELECT_1();

            /*" -5231- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -5232- DISPLAY 'R3210-00 - ERRO SELECT V0CLIENTE ' */
                _.Display($"R3210-00 - ERRO SELECT V0CLIENTE ");

                /*" -5233- DISPLAY 'BILHETE ' V0BILH-NUMBIL ' ' V0BILH-CODCLIEN */

                $"BILHETE {V0BILH_NUMBIL} {V0BILH_CODCLIEN}"
                .Display();

                /*" -5236- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5238- MOVE V0BILH-CGCCPF TO V1CROT-CGCCPF */
            _.Move(V0BILH_CGCCPF, V1CROT_CGCCPF);

            /*" -5251- PERFORM R3210_20_CROT_DB_SELECT_2 */

            R3210_20_CROT_DB_SELECT_2();

            /*" -5254- IF SQLCODE NOT EQUAL ZEROES AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -5255- DISPLAY 'R3210-PROBLEMAS DE LEITURA CREDITO ROTATIVO' */
                _.Display($"R3210-PROBLEMAS DE LEITURA CREDITO ROTATIVO");

                /*" -5256- DISPLAY 'CODIGO DE ERRO ... ' SQLCODE */
                _.Display($"CODIGO DE ERRO ... {DB.SQLCODE}");

                /*" -5257- DISPLAY 'NR. BILHETE    ... ' V0BILH-NUMBIL */
                _.Display($"NR. BILHETE    ... {V0BILH_NUMBIL}");

                /*" -5258- DISPLAY 'NR. CGCCPF     ... ' V0BILH-CGCCPF */
                _.Display($"NR. CGCCPF     ... {V0BILH_CGCCPF}");

                /*" -5259- DISPLAY 'NAO FOI INCLUIDO NA TAB. CLIENTE_CROT' */
                _.Display($"NAO FOI INCLUIDO NA TAB. CLIENTE_CROT");

                /*" -5261- DISPLAY 'BILHETE EMITIDO. PROCESSAMENTO CONTINUA' . */
                _.Display($"BILHETE EMITIDO. PROCESSAMENTO CONTINUA");
            }


            /*" -5262- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -5263- IF V0BILH-RAMO EQUAL 81 */

                if (V0BILH_RAMO == 81)
                {

                    /*" -5264- PERFORM R3240-00-UPDATE-CROT-AP */

                    R3240_00_UPDATE_CROT_AP_SECTION();

                    /*" -5265- ELSE */
                }
                else
                {


                    /*" -5266- PERFORM R3250-00-UPDATE-CROT-RES */

                    R3250_00_UPDATE_CROT_RES_SECTION();

                    /*" -5267- ELSE */
                }

            }
            else
            {


                /*" -5268- IF V0BILH-RAMO EQUAL 81 */

                if (V0BILH_RAMO == 81)
                {

                    /*" -5269- MOVE 'S' TO V0CROT-BILH-AP */
                    _.Move("S", V0CROT_BILH_AP);

                    /*" -5270- MOVE 'N' TO V0CROT-BILH-RES */
                    _.Move("N", V0CROT_BILH_RES);

                    /*" -5271- ELSE */
                }
                else
                {


                    /*" -5272- MOVE 'N' TO V0CROT-BILH-AP */
                    _.Move("N", V0CROT_BILH_AP);

                    /*" -5273- MOVE 'S' TO V0CROT-BILH-RES */
                    _.Move("S", V0CROT_BILH_RES);

                    /*" -5274- END-IF */
                }


                /*" -5274- PERFORM R3260-00-INSERT-V0CLIEN-CROT. */

                R3260_00_INSERT_V0CLIEN_CROT_SECTION();
            }


        }

        [StopWatch]
        /*" R3210-20-CROT-DB-SELECT-1 */
        public void R3210_20_CROT_DB_SELECT_1()
        {
            /*" -5228- EXEC SQL SELECT CGCCPF, NOME_RAZAO INTO :V0BILH-CGCCPF, :V0BILH-NOME FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = :V0BILH-CODCLIEN END-EXEC. */

            var r3210_20_CROT_DB_SELECT_1_Query1 = new R3210_20_CROT_DB_SELECT_1_Query1()
            {
                V0BILH_CODCLIEN = V0BILH_CODCLIEN.ToString(),
            };

            var executed_1 = R3210_20_CROT_DB_SELECT_1_Query1.Execute(r3210_20_CROT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0BILH_CGCCPF, V0BILH_CGCCPF);
                _.Move(executed_1.V0BILH_NOME, V0BILH_NOME);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3210_99_SAIDA*/

        [StopWatch]
        /*" R3210-20-CROT-DB-SELECT-2 */
        public void R3210_20_CROT_DB_SELECT_2()
        {
            /*" -5251- EXEC SQL SELECT CGCCPF , BILH_AP , BILH_RES , BILH_VDAZUL , DTMOVABE INTO :V1CROT-CGCCPF , :V1CROT-BILH-AP , :V1CROT-BILH-RES , :V1CROT-BILH-VDAZUL , :V1CROT-DTMOVABE FROM SEGUROS.V1CLIENTE_CROT WHERE CGCCPF = :V0BILH-CGCCPF END-EXEC. */

            var r3210_20_CROT_DB_SELECT_2_Query1 = new R3210_20_CROT_DB_SELECT_2_Query1()
            {
                V0BILH_CGCCPF = V0BILH_CGCCPF.ToString(),
            };

            var executed_1 = R3210_20_CROT_DB_SELECT_2_Query1.Execute(r3210_20_CROT_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1CROT_CGCCPF, V1CROT_CGCCPF);
                _.Move(executed_1.V1CROT_BILH_AP, V1CROT_BILH_AP);
                _.Move(executed_1.V1CROT_BILH_RES, V1CROT_BILH_RES);
                _.Move(executed_1.V1CROT_BILH_VDAZUL, V1CROT_BILH_VDAZUL);
                _.Move(executed_1.V1CROT_DTMOVABE, V1CROT_DTMOVABE);
            }


        }

        [StopWatch]
        /*" R3240-00-UPDATE-CROT-AP-SECTION */
        private void R3240_00_UPDATE_CROT_AP_SECTION()
        {
            /*" -5286- MOVE '3240' TO WNR-EXEC-SQL. */
            _.Move("3240", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5288- MOVE 'S' TO V0CROT-BILH-AP */
            _.Move("S", V0CROT_BILH_AP);

            /*" -5289- IF V1CROT-DTMOVABE < V1SIST-DTMOVACB */

            if (V1CROT_DTMOVABE < V1SIST_DTMOVACB)
            {

                /*" -5290- MOVE V1SIST-DTMOVACB TO V0CROT-DTMOVABE */
                _.Move(V1SIST_DTMOVACB, V0CROT_DTMOVABE);

                /*" -5291- ELSE */
            }
            else
            {


                /*" -5293- MOVE V1CROT-DTMOVABE TO V0CROT-DTMOVABE. */
                _.Move(V1CROT_DTMOVABE, V0CROT_DTMOVABE);
            }


            /*" -5298- PERFORM R3240_00_UPDATE_CROT_AP_DB_UPDATE_1 */

            R3240_00_UPDATE_CROT_AP_DB_UPDATE_1();

            /*" -5301- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5302- DISPLAY 'R3240-00 (ERRO - UPDATE V0CLIENTE_CROT)...' */
                _.Display($"R3240-00 (ERRO - UPDATE V0CLIENTE_CROT)...");

                /*" -5303- DISPLAY 'ATUALIZANDO ACIDENTES PESSOAIS         ...' */
                _.Display($"ATUALIZANDO ACIDENTES PESSOAIS         ...");

                /*" -5304- DISPLAY 'CGCCPF : ' V1CROT-CGCCPF */
                _.Display($"CGCCPF : {V1CROT_CGCCPF}");

                /*" -5306- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5306- ADD +1 TO AC-U-V0CLIE-CROT. */
            AREA_DE_WORK.AC_U_V0CLIE_CROT.Value = AREA_DE_WORK.AC_U_V0CLIE_CROT + +1;

        }

        [StopWatch]
        /*" R3240-00-UPDATE-CROT-AP-DB-UPDATE-1 */
        public void R3240_00_UPDATE_CROT_AP_DB_UPDATE_1()
        {
            /*" -5298- EXEC SQL UPDATE SEGUROS.V0CLIENTE_CROT SET BILH_AP = :V0CROT-BILH-AP , DTMOVABE = :V0CROT-DTMOVABE WHERE CGCCPF = :V0BILH-CGCCPF END-EXEC. */

            var r3240_00_UPDATE_CROT_AP_DB_UPDATE_1_Update1 = new R3240_00_UPDATE_CROT_AP_DB_UPDATE_1_Update1()
            {
                V0CROT_DTMOVABE = V0CROT_DTMOVABE.ToString(),
                V0CROT_BILH_AP = V0CROT_BILH_AP.ToString(),
                V0BILH_CGCCPF = V0BILH_CGCCPF.ToString(),
            };

            R3240_00_UPDATE_CROT_AP_DB_UPDATE_1_Update1.Execute(r3240_00_UPDATE_CROT_AP_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3240_99_SAIDA*/

        [StopWatch]
        /*" R3250-00-UPDATE-CROT-RES-SECTION */
        private void R3250_00_UPDATE_CROT_RES_SECTION()
        {
            /*" -5317- MOVE '3250' TO WNR-EXEC-SQL. */
            _.Move("3250", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5319- MOVE 'S' TO V0CROT-BILH-RES */
            _.Move("S", V0CROT_BILH_RES);

            /*" -5320- IF V1CROT-DTMOVABE < V1SIST-DTMOVACB */

            if (V1CROT_DTMOVABE < V1SIST_DTMOVACB)
            {

                /*" -5321- MOVE V1SIST-DTMOVACB TO V0CROT-DTMOVABE */
                _.Move(V1SIST_DTMOVACB, V0CROT_DTMOVABE);

                /*" -5322- ELSE */
            }
            else
            {


                /*" -5324- MOVE V1CROT-DTMOVABE TO V0CROT-DTMOVABE. */
                _.Move(V1CROT_DTMOVABE, V0CROT_DTMOVABE);
            }


            /*" -5329- PERFORM R3250_00_UPDATE_CROT_RES_DB_UPDATE_1 */

            R3250_00_UPDATE_CROT_RES_DB_UPDATE_1();

            /*" -5332- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5333- DISPLAY 'R3250-00 (ERRO - UPDATE V0CLIENTE_CROT)...' */
                _.Display($"R3250-00 (ERRO - UPDATE V0CLIENTE_CROT)...");

                /*" -5334- DISPLAY 'ATUALIZANDO RESIDENCIAIS               ...' */
                _.Display($"ATUALIZANDO RESIDENCIAIS               ...");

                /*" -5335- DISPLAY 'CGCCPF : ' V1CROT-CGCCPF */
                _.Display($"CGCCPF : {V1CROT_CGCCPF}");

                /*" -5337- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5337- ADD +1 TO AC-U-V0CLIE-CROT. */
            AREA_DE_WORK.AC_U_V0CLIE_CROT.Value = AREA_DE_WORK.AC_U_V0CLIE_CROT + +1;

        }

        [StopWatch]
        /*" R3250-00-UPDATE-CROT-RES-DB-UPDATE-1 */
        public void R3250_00_UPDATE_CROT_RES_DB_UPDATE_1()
        {
            /*" -5329- EXEC SQL UPDATE SEGUROS.V0CLIENTE_CROT SET BILH_RES = :V0CROT-BILH-RES , DTMOVABE = :V0CROT-DTMOVABE WHERE CGCCPF = :V0BILH-CGCCPF END-EXEC. */

            var r3250_00_UPDATE_CROT_RES_DB_UPDATE_1_Update1 = new R3250_00_UPDATE_CROT_RES_DB_UPDATE_1_Update1()
            {
                V0CROT_BILH_RES = V0CROT_BILH_RES.ToString(),
                V0CROT_DTMOVABE = V0CROT_DTMOVABE.ToString(),
                V0BILH_CGCCPF = V0BILH_CGCCPF.ToString(),
            };

            R3250_00_UPDATE_CROT_RES_DB_UPDATE_1_Update1.Execute(r3250_00_UPDATE_CROT_RES_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3250_99_SAIDA*/

        [StopWatch]
        /*" R3260-00-INSERT-V0CLIEN-CROT-SECTION */
        private void R3260_00_INSERT_V0CLIEN_CROT_SECTION()
        {
            /*" -5347- MOVE '3260' TO WNR-EXEC-SQL. */
            _.Move("3260", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5348- MOVE V0BILH-CGCCPF TO V0CROT-CGCCPF */
            _.Move(V0BILH_CGCCPF, V0CROT_CGCCPF);

            /*" -5349- MOVE 'N' TO V0CROT-BILH-VDAZUL */
            _.Move("N", V0CROT_BILH_VDAZUL);

            /*" -5351- MOVE V1SIST-DTMOVACB TO V0CROT-DTMOVABE */
            _.Move(V1SIST_DTMOVACB, V0CROT_DTMOVABE);

            /*" -5358- PERFORM R3260_00_INSERT_V0CLIEN_CROT_DB_INSERT_1 */

            R3260_00_INSERT_V0CLIEN_CROT_DB_INSERT_1();

            /*" -5361- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5362- DISPLAY 'R3260-00 (ERRO - INSERT V0CLIENTE_CROT)...' */
                _.Display($"R3260-00 (ERRO - INSERT V0CLIENTE_CROT)...");

                /*" -5363- DISPLAY 'CGCCPF: ' V0BILH-CGCCPF */
                _.Display($"CGCCPF: {V0BILH_CGCCPF}");

                /*" -5365- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5365- ADD +1 TO AC-I-V0CLIE-CROT. */
            AREA_DE_WORK.AC_I_V0CLIE_CROT.Value = AREA_DE_WORK.AC_I_V0CLIE_CROT + +1;

        }

        [StopWatch]
        /*" R3260-00-INSERT-V0CLIEN-CROT-DB-INSERT-1 */
        public void R3260_00_INSERT_V0CLIEN_CROT_DB_INSERT_1()
        {
            /*" -5358- EXEC SQL INSERT INTO SEGUROS.V0CLIENTE_CROT VALUES (:V0CROT-CGCCPF , :V0CROT-BILH-AP , :V0CROT-BILH-RES , :V0CROT-BILH-VDAZUL , :V0CROT-DTMOVABE) END-EXEC. */

            var r3260_00_INSERT_V0CLIEN_CROT_DB_INSERT_1_Insert1 = new R3260_00_INSERT_V0CLIEN_CROT_DB_INSERT_1_Insert1()
            {
                V0CROT_CGCCPF = V0CROT_CGCCPF.ToString(),
                V0CROT_BILH_AP = V0CROT_BILH_AP.ToString(),
                V0CROT_BILH_RES = V0CROT_BILH_RES.ToString(),
                V0CROT_BILH_VDAZUL = V0CROT_BILH_VDAZUL.ToString(),
                V0CROT_DTMOVABE = V0CROT_DTMOVABE.ToString(),
            };

            R3260_00_INSERT_V0CLIEN_CROT_DB_INSERT_1_Insert1.Execute(r3260_00_INSERT_V0CLIEN_CROT_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3260_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-TOTAIS-CONTROLE-SECTION */
        private void R4000_00_TOTAIS_CONTROLE_SECTION()
        {
            /*" -5379- MOVE '4000' TO WNR-EXEC-SQL. */
            _.Move("4000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5380- MOVE V1SIST-DTCURRENT TO WDATA-CURR */
            _.Move(V1SIST_DTCURRENT, AREA_DE_WORK.WDATA_CURR);

            /*" -5381- MOVE WDATA-DD-CURR TO WDATA-DD-CABEC */
            _.Move(AREA_DE_WORK.WDATA_CURR.WDATA_DD_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -5382- MOVE WDATA-MM-CURR TO WDATA-MM-CABEC */
            _.Move(AREA_DE_WORK.WDATA_CURR.WDATA_MM_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -5384- MOVE WDATA-AA-CURR TO WDATA-AA-CABEC */
            _.Move(AREA_DE_WORK.WDATA_CURR.WDATA_AA_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -5386- DISPLAY '+------------------------------------------------ '-----------------+' */
            _.Display($"+------------------------------------------------ -----------------+");

            /*" -5388- DISPLAY 'I BILHETES DE SEGUROS '                 I' */
            _.Display($"I BILHETES DE SEGUROS I");

            /*" -5390- DISPLAY 'I '                 I' */
            _.Display($"I I");

            /*" -5392- DISPLAY 'I                TOTAIS DE CONTROLE EM ' WDATA-CABEC '                 I' */

            $"I                TOTAIS DE CONTROLE EM {AREA_DE_WORK.WDATA_CABEC}                 I"
            .Display();

            /*" -5395- DISPLAY '+------------------------------------------------ '-----------------+' . */
            _.Display($"+------------------------------------------------ -----------------+");

            /*" -5397- DISPLAY 'I T A B E L A S A T U A L I Z A D A ' S               I' . */

            $"I T A B E L A S A T U A L I Z A D A SI"
            .Display();

            /*" -5399- DISPLAY '+--------------------------------------------+--- '-------+---------+' . */
            _.Display($"+--------------------------------------------+--- -------+---------+");

            /*" -5401- DISPLAY 'I NOME DA TABELA I IN 'SERT   I UPDATE  I' */

            $"I NOME DA TABELA I IN SERTIUPDATEI"
            .Display();

            /*" -5403- DISPLAY '+--------------------------------------------+--- '-------+---------+' . */
            _.Display($"+--------------------------------------------+--- -------+---------+");

            /*" -5406- DISPLAY 'I NUMERO OUTROS             (V0NUMERO_OUTS)  I  ' '     ' '   I  ' AC-U-V0NUMEROUT '  I' */

            $"I NUMERO OUTROS             (V0NUMERO_OUTS)  I          I  {AREA_DE_WORK.AC_U_V0NUMEROUT}  I"
            .Display();

            /*" -5409- DISPLAY 'I NUMERACAO GERAL           (V0NUMERO_AES)   I  ' '     ' '   I  ' AC-U-V0NUMERAES '  I' */

            $"I NUMERACAO GERAL           (V0NUMERO_AES)   I          I  {AREA_DE_WORK.AC_U_V0NUMERAES}  I"
            .Display();

            /*" -5412- DISPLAY 'I APOLICES                  (V0APOLICE)      I  ' AC-I-V0APOLICE '   I  ' AC-U-V0APOLICE '  I' */

            $"I APOLICES                  (V0APOLICE)      I  {AREA_DE_WORK.AC_I_V0APOLICE}   I  {AREA_DE_WORK.AC_U_V0APOLICE}  I"
            .Display();

            /*" -5415- DISPLAY 'I ENDOSSOS                  (V0ENDOSSO)      I  ' AC-I-V0ENDOSSO '   I  ' '     ' '  I' */

            $"I ENDOSSOS                  (V0ENDOSSO)      I  {AREA_DE_WORK.AC_I_V0ENDOSSO}   I         I"
            .Display();

            /*" -5418- DISPLAY 'I RECIBOS COB ANTECIPADA    (V0RCAP)         I  ' '     ' '   I  ' AC-U-V0RCAP '  I' */

            $"I RECIBOS COB ANTECIPADA    (V0RCAP)         I          I  {AREA_DE_WORK.AC_U_V0RCAP}  I"
            .Display();

            /*" -5421- DISPLAY 'I REC COBRANC ANTEC COMPL   (V0RCAPCOMP)     I  ' AC-I-V0RCAPCOMP '   I  ' AC-U-V0RCAPCOMP '  I' */

            $"I REC COBRANC ANTEC COMPL   (V0RCAPCOMP)     I  {AREA_DE_WORK.AC_I_V0RCAPCOMP}   I  {AREA_DE_WORK.AC_U_V0RCAPCOMP}  I"
            .Display();

            /*" -5424- DISPLAY 'I PRODUTORES                (V0PRODUTOR)     I  ' AC-I-V0PRODUTOR '   I  ' '     ' '  I' */

            $"I PRODUTORES                (V0PRODUTOR)     I  {AREA_DE_WORK.AC_I_V0PRODUTOR}   I         I"
            .Display();

            /*" -5427- DISPLAY 'I FUNCIONARIOS CEF          (V0FUNCIOCEF)    I  ' '     ' '   I  ' AC-U-V0FUNCIOCEF '  I' */

            $"I FUNCIONARIOS CEF          (V0FUNCIOCEF)    I          I  {AREA_DE_WORK.AC_U_V0FUNCIOCEF}  I"
            .Display();

            /*" -5430- DISPLAY 'I APOLICE CORRETOR          (V0APOLCORRET)   I  ' AC-I-V0APOLCORRET '   I  ' '     ' '  I' */

            $"I APOLICE CORRETOR          (V0APOLCORRET)   I  {AREA_DE_WORK.AC_I_V0APOLCORRET}   I         I"
            .Display();

            /*" -5433- DISPLAY 'I APOLICE COSSEGURO         (V0APOLCOSCED)   I  ' AC-I-V0APOLCOSCED '   I  ' '     ' '  I' */

            $"I APOLICE COSSEGURO         (V0APOLCOSCED)   I  {AREA_DE_WORK.AC_I_V0APOLCOSCED}   I         I"
            .Display();

            /*" -5436- DISPLAY 'I ORDEM DE COSSEG CEDIDO    (V0ORDECOSCED)   I  ' AC-I-V0ORDECOSCED '   I  ' '     ' '  I' */

            $"I ORDEM DE COSSEG CEDIDO    (V0ORDECOSCED)   I  {AREA_DE_WORK.AC_I_V0ORDECOSCED}   I         I"
            .Display();

            /*" -5439- DISPLAY 'I PARCELAS                  (V0PARCELAS)     I  ' AC-I-V0PARCELA '   I  ' '     ' '  I' */

            $"I PARCELAS                  (V0PARCELAS)     I  {AREA_DE_WORK.AC_I_V0PARCELA}   I         I"
            .Display();

            /*" -5442- DISPLAY 'I HISTORICO DE PARCELAS     (V0HISTOPARC)    I  ' AC-I-V0HISTOPARC '   I  ' '     ' '  I' */

            $"I HISTORICO DE PARCELAS     (V0HISTOPARC)    I  {AREA_DE_WORK.AC_I_V0HISTOPARC}   I         I"
            .Display();

            /*" -5445- DISPLAY 'I COBERTURAS DE APOLICE     (V0COBERAPOL)    I  ' AC-I-V0COBERAPOL '   I  ' '     ' '  I' */

            $"I COBERTURAS DE APOLICE     (V0COBERAPOL)    I  {AREA_DE_WORK.AC_I_V0COBERAPOL}   I         I"
            .Display();

            /*" -5448- DISPLAY 'I COMISSAO FENAE            (V0COMISSAO_FENAEI  ' '     ' '   I  ' AC-U-V0COMIFENAE '  I' */

            $"I COMISSAO FENAE            (V0COMISSAO_FENAEI          I  {AREA_DE_WORK.AC_U_V0COMIFENAE}  I"
            .Display();

            /*" -5451- DISPLAY 'I CLIENTE CROT              (V0CLIENTE_CROT) I  ' AC-I-V0CLIE-CROT '   I  ' AC-U-V0CLIE-CROT '  I' */

            $"I CLIENTE CROT              (V0CLIENTE_CROT) I  {AREA_DE_WORK.AC_I_V0CLIE_CROT}   I  {AREA_DE_WORK.AC_U_V0CLIE_CROT}  I"
            .Display();

            /*" -5454- DISPLAY 'I ADIANTAMENTOS             (V0ADIANTA)      I  ' AC-I-V0ADIANTA '   I  ' '     ' '  I' */

            $"I ADIANTAMENTOS             (V0ADIANTA)      I  {AREA_DE_WORK.AC_I_V0ADIANTA}   I         I"
            .Display();

            /*" -5457- DISPLAY 'I LIMITE DE RISCO                            I  ' AC-I-GELMR '   I  ' AC-U-GELMR '  I' */

            $"I LIMITE DE RISCO                            I  {AREA_DE_WORK.AC_I_GELMR}   I  {AREA_DE_WORK.AC_U_GELMR}  I"
            .Display();

            /*" -5459- DISPLAY '+--------------------------------------------+--- '-------+---------+' . */
            _.Display($"+--------------------------------------------+--- -------+---------+");

            /*" -5461- DISPLAY 'I QUANTIDADE DE BILHETES LIDOS               I ' WACC-LIDOS '   I         I' */

            $"I QUANTIDADE DE BILHETES LIDOS               I {AREA_DE_WORK.WACC_LIDOS}   I         I"
            .Display();

            /*" -5463- DISPLAY 'I QUANTIDADE DE BILHETES REJEITADOS          I  ' AC-U-V0BILHETE '   I         I' */

            $"I QUANTIDADE DE BILHETES REJEITADOS          I  {AREA_DE_WORK.AC_U_V0BILHETE}   I         I"
            .Display();

            /*" -5465- DISPLAY '+--------------------------------------------+--- '-------+---------+' . */
            _.Display($"+--------------------------------------------+--- -------+---------+");

            /*" -5467- DISPLAY 'I QUANTIDADE DE RISCO CRITICO DE ACEITACAO   I  ' WS-QT-RISCO-CRITICO '   I         I' */

            $"I QUANTIDADE DE RISCO CRITICO DE ACEITACAO   I  {WS_QT_RISCO_CRITICO}   I         I"
            .Display();

            /*" -5469- DISPLAY 'I QUANTIDADE DE BILHETES EM ANALISE DE RISCO I  ' WS-QT-EM-CRITICA '   I         I' */

            $"I QUANTIDADE DE BILHETES EM ANALISE DE RISCO I  {WS_QT_EM_CRITICA}   I         I"
            .Display();

            /*" -5471- DISPLAY 'I QUANTIDADE EMISSOES COM AVALIACAO DE RISCO I  ' WS-QT-EMISSAO-C-RISCO '   I         I' */

            $"I QUANTIDADE EMISSOES COM AVALIACAO DE RISCO I  {WS_QT_EMISSAO_C_RISCO}   I         I"
            .Display();

            /*" -5473- DISPLAY 'I QUANTIDADE EMISSOES SEM AVALIACAO DE RISCO I  ' WS-QT-EMISSAO-S-RISCO '   I         I' */

            $"I QUANTIDADE EMISSOES SEM AVALIACAO DE RISCO I  {WS_QT_EMISSAO_S_RISCO}   I         I"
            .Display();

            /*" -5475- DISPLAY 'I QUANT. LIBERADA PARA EMISSAO APOS ANALISE  I  ' WS-QT-LIBERADO-EMISSAO '   I         I' */

            $"I QUANT. LIBERADA PARA EMISSAO APOS ANALISE  I  {WS_QT_LIBERADO_EMISSAO}   I         I"
            .Display();

            /*" -5478- DISPLAY '+--------------------------------------------+--- '-------+---------+' . */
            _.Display($"+--------------------------------------------+--- -------+---------+");

            /*" -5479- DISPLAY ' ' */
            _.Display($" ");

            /*" -5480- DISPLAY 'LIDOS BILHETE  ........ ' LD-BILHETE */
            _.Display($"LIDOS BILHETE  ........ {AREA_DE_WORK.LD_BILHETE}");

            /*" -5481- DISPLAY 'DESPREZA PLCOBER ...... ' DP-PLCOBER */
            _.Display($"DESPREZA PLCOBER ...... {AREA_DE_WORK.DP_PLCOBER}");

            /*" -5482- DISPLAY 'DESPREZA RISCO ........ ' DP-RISCO */
            _.Display($"DESPREZA RISCO ........ {AREA_DE_WORK.DP_RISCO}");

            /*" -5483- DISPLAY 'DESPREZA BILCOBE ...... ' DP-BILCOBE */
            _.Display($"DESPREZA BILCOBE ...... {AREA_DE_WORK.DP_BILCOBE}");

            /*" -5484- DISPLAY 'DESPREZA RCAPS ........ ' DP-RCAPS */
            _.Display($"DESPREZA RCAPS ........ {AREA_DE_WORK.DP_RCAPS}");

            /*" -5485- DISPLAY 'DESPREZA APOLICE ...... ' DP-APOLICE */
            _.Display($"DESPREZA APOLICE ...... {AREA_DE_WORK.DP_APOLICE}");

            /*" -5486- DISPLAY 'DESPREZA ACUMULA ...... ' DP-ACUMULA */
            _.Display($"DESPREZA ACUMULA ...... {AREA_DE_WORK.DP_ACUMULA}");

            /*" -5487- DISPLAY 'DESPREZA ITENS ........ ' DP-ITENS */
            _.Display($"DESPREZA ITENS ........ {AREA_DE_WORK.DP_ITENS}");

            /*" -5489- DISPLAY '+--------------------------------------------+--- '-------+---------+' . */
            _.Display($"+--------------------------------------------+--- -------+---------+");

            /*" -5490- DISPLAY 'DESPREZA POR CRITICA... ' QT-CRITICA */
            _.Display($"DESPREZA POR CRITICA... {AREA_DE_WORK.QT_CRITICA}");

            /*" -5492- DISPLAY '+--------------------------------------------+--- '-------+---------+' . */
            _.Display($"+--------------------------------------------+--- -------+---------+");

            /*" -5492- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R4280-00-TRATA-FC0105S-SECTION */
        private void R4280_00_TRATA_FC0105S_SECTION()
        {
            /*" -5504- MOVE '4280' TO WNR-EXEC-SQL. */
            _.Move("4280", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5506- PERFORM R4290-00-INSERT-MOVFEDCA. */

            R4290_00_INSERT_MOVFEDCA_SECTION();

            /*" -5506- PERFORM R4400-00-INSERT-COMFEDCA. */

            R4400_00_INSERT_COMFEDCA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4280_99_SAIDA*/

        [StopWatch]
        /*" R4290-00-INSERT-MOVFEDCA-SECTION */
        private void R4290_00_INSERT_MOVFEDCA_SECTION()
        {
            /*" -5517- MOVE '4290' TO WNR-EXEC-SQL. */
            _.Move("4290", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5532- INITIALIZE LK-PLANO LK-SERIE LK-TITULO LK-NUM-PROPOSTA LK-QTD-TITULOS LK-VLR-TITULO LK-PARCEIRO LK-RAMO LK-TRACE LK-OUT-COD-RETORNO LK-OUT-SQLCODE LK-OUT-MENSAGEM LK-OUT-SQLERRMC LK-OUT-SQLSTATE. */
            _.Initialize(
                LK_PLANO
                , LK_SERIE
                , LK_TITULO
                , LK_NUM_PROPOSTA
                , LK_QTD_TITULOS
                , LK_VLR_TITULO
                , LK_PARCEIRO
                , LK_RAMO
                , LK_TRACE
                , LK_OUT_COD_RETORNO
                , LK_OUT_SQLCODE
                , LK_OUT_MENSAGEM
                , LK_OUT_SQLERRMC
                , LK_OUT_SQLSTATE
            );

            /*" -5534- MOVE 'TRACE OFF' TO LK-TRACE */
            _.Move("TRACE OFF", LK_TRACE);

            /*" -5538- MOVE 858 TO LK-PLANO W77-SMALLINT-D1 */
            _.Move(858, LK_PLANO, W77_SMALLINT_D1);

            /*" -5541- MOVE V0BILH-NUMBIL TO LK-NUM-PROPOSTA W77-DECIMAL */
            _.Move(V0BILH_NUMBIL, LK_NUM_PROPOSTA, W77_DECIMAL);

            /*" -5543- MOVE 1 TO LK-QTD-TITULOS */
            _.Move(1, LK_QTD_TITULOS);

            /*" -5546- MOVE V1BILC-VALMAX TO LK-VLR-TITULO W77-DECIMAL-D1 */
            _.Move(V1BILC_VALMAX, LK_VLR_TITULO, W77_DECIMAL_D1);

            /*" -5549- MOVE PARAMGER-COD-EMPRESA-CAP TO LK-PARCEIRO. */
            _.Move(PARAMGER.DCLPARAMETROS_GERAIS.PARAMGER_COD_EMPRESA_CAP, LK_PARCEIRO);

            /*" -5552- MOVE V1BILP-CODPRODU TO LK-RAMO W77-SMALLINT-D2 */
            _.Move(V1BILP_CODPRODU, LK_RAMO, W77_SMALLINT_D2);

            /*" -5554- MOVE ZEROS TO LK-NUM-NSA. */
            _.Move(0, LK_NUM_NSA);

            /*" -5571- CALL 'FC0105S' USING LK-PLANO , LK-SERIE , LK-TITULO , LK-NUM-PROPOSTA , LK-QTD-TITULOS , LK-VLR-TITULO , LK-PARCEIRO , LK-RAMO , LK-NUM-NSA , LK-TRACE , LK-OUT-COD-RETORNO , LK-OUT-SQLCODE , LK-OUT-MENSAGEM , LK-OUT-SQLERRMC , LK-OUT-SQLSTATE. */
            _.Call("FC0105S", LK_PLANO, LK_SERIE, LK_TITULO, LK_NUM_PROPOSTA, LK_QTD_TITULOS, LK_VLR_TITULO, LK_PARCEIRO, LK_RAMO, LK_NUM_NSA, LK_TRACE, LK_OUT_COD_RETORNO, LK_OUT_SQLCODE, LK_OUT_MENSAGEM, LK_OUT_SQLERRMC, LK_OUT_SQLSTATE);

            /*" -5572- IF LK-OUT-COD-RETORNO NOT EQUAL ZEROS */

            if (LK_OUT_COD_RETORNO != 00)
            {

                /*" -5574- IF LK-OUT-COD-RETORNO EQUAL 98 NEXT SENTENCE */

                if (LK_OUT_COD_RETORNO == 98)
                {

                    /*" -5575- END-IF */
                }


                /*" -5576- MOVE LK-OUT-SQLCODE TO WS-SQLCODE */
                _.Move(LK_OUT_SQLCODE, AREA_DE_WORK.WS_SQLCODE);

                /*" -5577- DISPLAY 'PROBLEMAS NO ACESSO A FC0105S ' */
                _.Display($"PROBLEMAS NO ACESSO A FC0105S ");

                /*" -5578- DISPLAY 'LK-NUM-PLANO       <' W77-SMALLINT-D1 '>' */

                $"LK-NUM-PLANO       <{W77_SMALLINT_D1}>"
                .Display();

                /*" -5579- DISPLAY 'LK-NUM-PROPOSTA    <' W77-DECIMAL '>' */

                $"LK-NUM-PROPOSTA    <{W77_DECIMAL}>"
                .Display();

                /*" -5580- DISPLAY 'LK-VLR-TITULO      <' W77-DECIMAL-D1 '>' */

                $"LK-VLR-TITULO      <{W77_DECIMAL_D1}>"
                .Display();

                /*" -5581- DISPLAY 'LK-NUM-PARCEIRO    <' LK-PARCEIRO '>' */

                $"LK-NUM-PARCEIRO    <{LK_PARCEIRO}>"
                .Display();

                /*" -5582- DISPLAY 'LK-RAMO            <' W77-SMALLINT-D2 '>' */

                $"LK-RAMO            <{W77_SMALLINT_D2}>"
                .Display();

                /*" -5583- DISPLAY ' ' */
                _.Display($" ");

                /*" -5584- DISPLAY 'LK-OUT-COD-RETORNO <' LK-OUT-COD-RETORNO '>' */

                $"LK-OUT-COD-RETORNO <{LK_OUT_COD_RETORNO}>"
                .Display();

                /*" -5585- DISPLAY 'WS-SQLCODE         <' WS-SQLCODE '>' */

                $"WS-SQLCODE         <{AREA_DE_WORK.WS_SQLCODE}>"
                .Display();

                /*" -5586- DISPLAY 'LK-OUT-MENSAGEM    <' LK-OUT-MENSAGEM '>' */

                $"LK-OUT-MENSAGEM    <{LK_OUT_MENSAGEM}>"
                .Display();

                /*" -5587- DISPLAY 'LK-OUT-SQLERRMC    <' LK-OUT-SQLERRMC '>' */

                $"LK-OUT-SQLERRMC    <{LK_OUT_SQLERRMC}>"
                .Display();

                /*" -5588- DISPLAY 'LK-OUT-SQLSTATE    <' LK-OUT-SQLSTATE '>' */

                $"LK-OUT-SQLSTATE    <{LK_OUT_SQLSTATE}>"
                .Display();

                /*" -5589- DISPLAY ' ' */
                _.Display($" ");

                /*" -5590- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -5590- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4290_99_SAIDA*/

        [StopWatch]
        /*" R4400-00-INSERT-COMFEDCA-SECTION */
        private void R4400_00_INSERT_COMFEDCA_SECTION()
        {
            /*" -5601- MOVE '4400' TO WNR-EXEC-SQL. */
            _.Move("4400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5612- PERFORM R4400_00_INSERT_COMFEDCA_DB_INSERT_1 */

            R4400_00_INSERT_COMFEDCA_DB_INSERT_1();

            /*" -5615- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5616- DISPLAY 'R4400 - ERRO NO INSERT DA TITFEDCA ' */
                _.Display($"R4400 - ERRO NO INSERT DA TITFEDCA ");

                /*" -5617- DISPLAY 'BILHETE ' V0BILH-NUMBIL */
                _.Display($"BILHETE {V0BILH_NUMBIL}");

                /*" -5618- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -5618- END-IF. */
            }


        }

        [StopWatch]
        /*" R4400-00-INSERT-COMFEDCA-DB-INSERT-1 */
        public void R4400_00_INSERT_COMFEDCA_DB_INSERT_1()
        {
            /*" -5612- EXEC SQL INSERT INTO SEGUROS.COMUNIC_FED_CAP_VA ( NUM_CERTIFICADO , SITUACAO , DATA_MOVIMENTO , TIMESTAMP ) VALUES ( :V0BILH-NUMBIL , 'E' , :V1SIST-DTMOVABE , CURRENT TIMESTAMP ) END-EXEC. */

            var r4400_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1 = new R4400_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1()
            {
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
            };

            R4400_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1.Execute(r4400_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4400_99_SAIDA*/

        [StopWatch]
        /*" P7000-00-PROCURA-RISCO-PROP-SECTION */
        private void P7000_00_PROCURA_RISCO_PROP_SECTION()
        {
            /*" -5633- MOVE 'P7000' TO WNR-EXEC-SQL */
            _.Move("P7000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5634- MOVE 'N' TO LK-VG009-E-TRACE */
            _.Move("N", SPVG009W.LK_VG009_E_TRACE);

            /*" -5636- MOVE 'BI8005B' TO LK-VG009-E-COD-USUARIO LK-VG009-E-NOM-PROGRAMA */
            _.Move("BI8005B", SPVG009W.LK_VG009_E_COD_USUARIO, SPVG009W.LK_VG009_E_NOM_PROGRAMA);

            /*" -5637- MOVE 01 TO LK-VG009-E-TIPO-ACAO */
            _.Move(01, SPVG009W.LK_VG009_E_TIPO_ACAO);

            /*" -5639- MOVE V0CONV-NUM-PROPOSTA-SIVPF TO LK-VG009-E-NUM-PROPOSTA */
            _.Move(V0CONV_NUM_PROPOSTA_SIVPF, SPVG009W.LK_VG009_E_NUM_PROPOSTA);

            /*" -5640- MOVE 0 TO LK-VG009-IND-ERRO */
            _.Move(0, SPVG009W.LK_VG009_IND_ERRO);

            /*" -5642- MOVE SPACES TO LK-VG009-MSG-ERRO LK-VG009-NOM-TABELA */
            _.Move("", SPVG009W.LK_VG009_MSG_ERRO, SPVG009W.LK_VG009_NOM_TABELA);

            /*" -5643- MOVE 0 TO LK-VG009-SQLCODE */
            _.Move(0, SPVG009W.LK_VG009_SQLCODE);

            /*" -5645- MOVE SPACES TO LK-VG009-SQLERRMC */
            _.Move("", SPVG009W.LK_VG009_SQLERRMC);

            /*" -5647- MOVE 'SPBVG009' TO WS-PROGRAMA */
            _.Move("SPBVG009", WS_PROGRAMA);

            /*" -5668- CALL WS-PROGRAMA USING LK-VG009-E-TRACE LK-VG009-E-COD-USUARIO LK-VG009-E-NOM-PROGRAMA LK-VG009-E-TIPO-ACAO LK-VG009-E-NUM-PROPOSTA LK-VG009-S-COD-PESSOA LK-VG009-S-SEQ-PESSOA-HIST LK-VG009-S-COD-CLASSIF-RISCO LK-VG009-S-NUM-SCORE-RISCO LK-VG009-S-DTA-CLASSIF-RISCO LK-VG009-S-IND-PEND-APROVACAO LK-VG009-S-IND-DECL-AUTOMATICO LK-VG009-S-IND-ATLZ-FXA-RISCO LK-VG009-IND-ERRO LK-VG009-MSG-ERRO LK-VG009-NOM-TABELA LK-VG009-SQLCODE LK-VG009-SQLERRMC */
            _.Call(WS_PROGRAMA, SPVG009W);

            /*" -5669- IF LK-VG009-IND-ERRO NOT EQUAL ZEROS AND 1 */

            if (!SPVG009W.LK_VG009_IND_ERRO.In("00", "1"))
            {

                /*" -5670- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -5671- DISPLAY '* R7000 - PROBLEMAS CALL SUBROTINA SPBVG009   *' */
                _.Display($"* R7000 - PROBLEMAS CALL SUBROTINA SPBVG009   *");

                /*" -5672- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -5673- DISPLAY '* NUM-PROPOST: ' LK-VG009-E-NUM-PROPOSTA */
                _.Display($"* NUM-PROPOST: {SPVG009W.LK_VG009_E_NUM_PROPOSTA}");

                /*" -5674- DISPLAY '* TIPO-ACAO..: ' LK-VG009-E-TIPO-ACAO */
                _.Display($"* TIPO-ACAO..: {SPVG009W.LK_VG009_E_TIPO_ACAO}");

                /*" -5675- DISPLAY '* IND-ERRO...: ' LK-VG009-IND-ERRO */
                _.Display($"* IND-ERRO...: {SPVG009W.LK_VG009_IND_ERRO}");

                /*" -5676- DISPLAY '* MSG-ERRO...: ' LK-VG009-MSG-ERRO */
                _.Display($"* MSG-ERRO...: {SPVG009W.LK_VG009_MSG_ERRO}");

                /*" -5677- DISPLAY '* NOM-TABELA.: ' LK-VG009-NOM-TABELA */
                _.Display($"* NOM-TABELA.: {SPVG009W.LK_VG009_NOM_TABELA}");

                /*" -5678- DISPLAY '* SQLCODE....: ' LK-VG009-SQLCODE */
                _.Display($"* SQLCODE....: {SPVG009W.LK_VG009_SQLCODE}");

                /*" -5679- DISPLAY '* SQLERRMC...: ' LK-VG009-SQLERRMC */
                _.Display($"* SQLERRMC...: {SPVG009W.LK_VG009_SQLERRMC}");

                /*" -5680- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -5681- MOVE 999 TO SQLCODE */
                _.Move(999, DB.SQLCODE);

                /*" -5682- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -5684- END-IF */
            }


            /*" -5685-  EVALUATE TRUE  */

            /*" -5686-  WHEN LK-VG009-IND-ERRO = 00  */

            /*" -5686- IF LK-VG009-IND-ERRO = 00 */

            if (SPVG009W.LK_VG009_IND_ERRO == 00)
            {

                /*" -5689- PERFORM R7050-00-GRAVA-CLASSIF-RISCO */

                R7050_00_GRAVA_CLASSIF_RISCO_SECTION();

                /*" -5690- IF LK-VG009-S-COD-CLASSIF-RISCO EQUAL 04 */

                if (SPVG009W.LK_VG009_S_COD_CLASSIF_RISCO == 04)
                {

                    /*" -5693- DISPLAY 'DESPREZADO RISCO CRITICO.: ' V0BILH-NUMBIL ' >> ' V0CONV-NUM-PROPOSTA-SIVPF */

                    $"DESPREZADO RISCO CRITICO.: {V0BILH_NUMBIL} >> {V0CONV_NUM_PROPOSTA_SIVPF}"
                    .Display();

                    /*" -5694- MOVE '1' TO V0BILH-SITUACAO */
                    _.Move("1", V0BILH_SITUACAO);

                    /*" -5695- ADD 1 TO WS-QT-RISCO-CRITICO */
                    WS_QT_RISCO_CRITICO.Value = WS_QT_RISCO_CRITICO + 1;

                    /*" -5696- PERFORM R3020-00-UPDATE-V0BILHETE */

                    R3020_00_UPDATE_V0BILHETE_SECTION();

                    /*" -5697- GO TO P7000-99-EXIT */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: P7000_99_EXIT*/ //GOTO
                    return;

                    /*" -5698- END-IF */
                }


                /*" -5699-  WHEN LK-VG009-IND-ERRO = 01  */

                /*" -5699- ELSE IF LK-VG009-IND-ERRO = 01 */
            }
            else

            if (SPVG009W.LK_VG009_IND_ERRO == 01)
            {

                /*" -5700- IF LK-VG009-SQLCODE = +100 */

                if (SPVG009W.LK_VG009_SQLCODE == +100)
                {

                    /*" -5701- PERFORM R7060-00-GRAVA-EMITE-SEM-RISCO */

                    R7060_00_GRAVA_EMITE_SEM_RISCO_SECTION();

                    /*" -5702- ELSE */
                }
                else
                {


                    /*" -5703- MOVE 1 TO WS-ERRO-VG009 */
                    _.Move(1, WS_ERRO_VG009);

                    /*" -5704- END-IF */
                }


                /*" -5705-  WHEN OTHER  */

                /*" -5705- ELSE */
            }
            else
            {


                /*" -5706- MOVE 1 TO WS-ERRO-VG009 */
                _.Move(1, WS_ERRO_VG009);

                /*" -5708-  END-EVALUATE  */

                /*" -5708- END-IF */
            }


            /*" -5709- IF WS-ERRO-VG009 NOT EQUAL ZEROS */

            if (WS_ERRO_VG009 != 00)
            {

                /*" -5710- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -5711- DISPLAY '* P7001 - PROBLEMAS CALL SUBROTINA SPBVG009   *' */
                _.Display($"* P7001 - PROBLEMAS CALL SUBROTINA SPBVG009   *");

                /*" -5712- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -5713- DISPLAY '* NUM-PROPOST: ' LK-VG009-E-NUM-PROPOSTA */
                _.Display($"* NUM-PROPOST: {SPVG009W.LK_VG009_E_NUM_PROPOSTA}");

                /*" -5714- DISPLAY '* TIPO-ACAO..: ' LK-VG009-E-TIPO-ACAO */
                _.Display($"* TIPO-ACAO..: {SPVG009W.LK_VG009_E_TIPO_ACAO}");

                /*" -5715- DISPLAY '* IND-ERRO...: ' LK-VG009-IND-ERRO */
                _.Display($"* IND-ERRO...: {SPVG009W.LK_VG009_IND_ERRO}");

                /*" -5716- DISPLAY '* MSG-ERRO...: ' LK-VG009-MSG-ERRO */
                _.Display($"* MSG-ERRO...: {SPVG009W.LK_VG009_MSG_ERRO}");

                /*" -5717- DISPLAY '* NOM-TABELA.: ' LK-VG009-NOM-TABELA */
                _.Display($"* NOM-TABELA.: {SPVG009W.LK_VG009_NOM_TABELA}");

                /*" -5718- DISPLAY '* SQLCODE....: ' LK-VG009-SQLCODE */
                _.Display($"* SQLCODE....: {SPVG009W.LK_VG009_SQLCODE}");

                /*" -5719- DISPLAY '* SQLERRMC...: ' LK-VG009-SQLERRMC */
                _.Display($"* SQLERRMC...: {SPVG009W.LK_VG009_SQLERRMC}");

                /*" -5721- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -5722- MOVE 999 TO SQLCODE */
                _.Move(999, DB.SQLCODE);

                /*" -5723- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -5724- END-IF */
            }


            /*" -5724- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P7000_99_EXIT*/

        [StopWatch]
        /*" R7050-00-GRAVA-CLASSIF-RISCO-SECTION */
        private void R7050_00_GRAVA_CLASSIF_RISCO_SECTION()
        {
            /*" -5740- MOVE 'R7050' TO WNR-EXEC-SQL */
            _.Move("R7050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5741- MOVE 'N' TO LK-VG001-TRACE */
            _.Move("N", SPVG001W.LK_VG001_TRACE);

            /*" -5742- MOVE 02 TO LK-VG001-TIPO-ACAO */
            _.Move(02, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -5743- MOVE V0BILH-NUMBIL TO LK-VG001-NUM-CERTIFICADO */
            _.Move(V0BILH_NUMBIL, SPVG001W.LK_VG001_NUM_CERTIFICADO);

            /*" -5744- MOVE 0 TO LK-VG001-SEQ-CRITICA */
            _.Move(0, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -5745- MOVE 'BI' TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("BI", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -5746- MOVE V0CLIE-CGCCPF TO LK-VG001-NUM-CPF-CNPJ */
            _.Move(V0CLIE_CGCCPF, SPVG001W.LK_VG001_NUM_CPF_CNPJ);

            /*" -5747- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -5748- MOVE 'BI8005B' TO LK-VG001-NOM-PROGRAMA */
            _.Move("BI8005B", SPVG001W.LK_VG001_NOM_PROGRAMA);

            /*" -5749- MOVE 'SPBVG001' TO VG001-PROGRAMA */
            _.Move("SPBVG001", SPVG001V.VG001_PROGRAMA);

            /*" -5750- MOVE SPACES TO LK-VG001-STA-CRITICA */
            _.Move("", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -5751- MOVE 35 TO LK-VG001-DES-COMPLEMENTAR-L */
            _.Move(35, SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_L);

            /*" -5753- MOVE 'CADASTRAMENTO DE AVALIACAO DE RISCO' TO LK-VG001-DES-COMPLEMENTAR-T */
            _.Move("CADASTRAMENTO DE AVALIACAO DE RISCO", SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_T);

            /*" -5755- ADD 1 TO WS-QT-EMISSAO-C-RISCO */
            WS_QT_EMISSAO_C_RISCO.Value = WS_QT_EMISSAO_C_RISCO + 1;

            /*" -5757- EVALUATE LK-VG009-S-COD-CLASSIF-RISCO */
            switch (SPVG009W.LK_VG009_S_COD_CLASSIF_RISCO.Value)
            {

                /*" -5758- WHEN 01 */
                case 01:

                    /*" -5760- MOVE 'PROPOSTA COM CLASSIFICACAO DE RISCO BAIXA' TO VG078-DES-ANDAMENTO-TEXT */
                    _.Move("PROPOSTA COM CLASSIFICACAO DE RISCO BAIXA", VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.VG078_DES_ANDAMENTO_TEXT);

                    /*" -5762- MOVE 2 TO LK-VG001-COD-MSG-CRITICA */
                    _.Move(2, SPVG001W.LK_VG001_COD_MSG_CRITICA);

                    /*" -5763- WHEN 02 */
                    break;
                case 02:

                    /*" -5765- MOVE 'PROPOSTA COM CLASSIFICACAO DE RISCO MODERADO' TO VG078-DES-ANDAMENTO-TEXT */
                    _.Move("PROPOSTA COM CLASSIFICACAO DE RISCO MODERADO", VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.VG078_DES_ANDAMENTO_TEXT);

                    /*" -5767- MOVE 3 TO LK-VG001-COD-MSG-CRITICA */
                    _.Move(3, SPVG001W.LK_VG001_COD_MSG_CRITICA);

                    /*" -5768- WHEN 03 */
                    break;
                case 03:

                    /*" -5770- MOVE 'PROPOSTA COM CLASSIFICACAO DE RISCO ELEVADO' TO VG078-DES-ANDAMENTO-TEXT */
                    _.Move("PROPOSTA COM CLASSIFICACAO DE RISCO ELEVADO", VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.VG078_DES_ANDAMENTO_TEXT);

                    /*" -5772- MOVE 4 TO LK-VG001-COD-MSG-CRITICA */
                    _.Move(4, SPVG001W.LK_VG001_COD_MSG_CRITICA);

                    /*" -5773- WHEN 04 */
                    break;
                case 04:

                    /*" -5775- MOVE 'PROPOSTA COM CLASSIFICACAO DE RISCO CRITICO' TO VG078-DES-ANDAMENTO-TEXT */
                    _.Move("PROPOSTA COM CLASSIFICACAO DE RISCO CRITICO", VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.VG078_DES_ANDAMENTO_TEXT);

                    /*" -5776- MOVE 1 TO LK-VG001-COD-MSG-CRITICA */
                    _.Move(1, SPVG001W.LK_VG001_COD_MSG_CRITICA);

                    /*" -5777- WHEN OTHER */
                    break;
                default:

                    /*" -5780- DISPLAY 'ERRO - CLASSIFICACAO DE RISCO NAO CADASTRADA' LK-VG009-S-COD-CLASSIF-RISCO */
                    _.Display($"ERRO - CLASSIFICACAO DE RISCO NAO CADASTRADA{SPVG009W.LK_VG009_S_COD_CLASSIF_RISCO}");

                    /*" -5781- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -5783- END-EVALUATE */
                    break;
            }


            /*" -5785- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -5786- IF LK-VG001-IND-ERRO NOT EQUAL ZEROS */

            if (SPVG001W.LK_VG001_IND_ERRO != 00)
            {

                /*" -5787- IF LK-VG001-IND-ERRO EQUAL 1 */

                if (SPVG001W.LK_VG001_IND_ERRO == 1)
                {

                    /*" -5791- DISPLAY 'ERRO JAH GRAVADO 7050 >> ' LK-VG001-NUM-CERTIFICADO ' >> ' LK-VG001-COD-MSG-CRITICA ' >> ' LK-VG001-IND-ERRO */

                    $"ERRO JAH GRAVADO 7050 >> {SPVG001W.LK_VG001_NUM_CERTIFICADO} >> {SPVG001W.LK_VG001_COD_MSG_CRITICA} >> {SPVG001W.LK_VG001_IND_ERRO}"
                    .Display();

                    /*" -5792- DISPLAY 'MSG-ERRO: ' LK-VG001-MSG-ERRO */
                    _.Display($"MSG-ERRO: {SPVG001W.LK_VG001_MSG_ERRO}");

                    /*" -5793- ELSE */
                }
                else
                {


                    /*" -5794- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -5795- DISPLAY '* 7050 -  PROBLEMAS CALL SUBROTINA SPBVG001 *' */
                    _.Display($"* 7050 -  PROBLEMAS CALL SUBROTINA SPBVG001 *");

                    /*" -5796- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -5797- DISPLAY '* NUM-CERTIF..: ' LK-VG001-NUM-CERTIFICADO */
                    _.Display($"* NUM-CERTIF..: {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                    /*" -5798- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                    _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                    /*" -5799- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                    _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                    /*" -5800- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                    _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                    /*" -5801- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                    _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                    /*" -5802- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                    _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                    /*" -5804- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -5805- MOVE 999 TO SQLCODE */
                    _.Move(999, DB.SQLCODE);

                    /*" -5806- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -5807- END-IF */
                }


                /*" -5809- END-IF */
            }


            /*" -5810- MOVE 'BI8005B' TO VG078-COD-USUARIO */
            _.Move("BI8005B", VG078.DCLVG_ANDAMENTO_PROP.VG078_COD_USUARIO);

            /*" -5811- MOVE V0BILH-NUMBIL TO VG078-NUM-CERTIFICADO */
            _.Move(V0BILH_NUMBIL, VG078.DCLVG_ANDAMENTO_PROP.VG078_NUM_CERTIFICADO);

            /*" -5813- MOVE 55 TO VG078-DES-ANDAMENTO-LEN */
            _.Move(55, VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.VG078_DES_ANDAMENTO_LEN);

            /*" -5814- PERFORM R9997-00-INSERE-ANDAMENTO */

            R9997_00_INSERE_ANDAMENTO_SECTION();

            /*" -5814- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7050_99_SAIDA*/

        [StopWatch]
        /*" R7060-00-GRAVA-EMITE-SEM-RISCO-SECTION */
        private void R7060_00_GRAVA_EMITE_SEM_RISCO_SECTION()
        {
            /*" -5826- MOVE 'R7060' TO WNR-EXEC-SQL */
            _.Move("R7060", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5827- MOVE 5 TO WS-COD-CRITICA */
            _.Move(5, WS_COD_CRITICA);

            /*" -5829- PERFORM R7100-00-CONS-COD-CRITICA */

            R7100_00_CONS_COD_CRITICA_SECTION();

            /*" -5830- IF VG001-IND-EXISTE EQUAL 'S' */

            if (SPVG001V.VG001_IND_EXISTE == "S")
            {

                /*" -5831- GO TO R7060-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R7060_99_SAIDA*/ //GOTO
                return;

                /*" -5837- END-IF */
            }


            /*" -5839- INITIALIZE LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
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

            /*" -5840- MOVE 'N' TO LK-VG001-TRACE */
            _.Move("N", SPVG001W.LK_VG001_TRACE);

            /*" -5841- MOVE 02 TO LK-VG001-TIPO-ACAO */
            _.Move(02, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -5842- MOVE V0BILH-NUMBIL TO LK-VG001-NUM-CERTIFICADO */
            _.Move(V0BILH_NUMBIL, SPVG001W.LK_VG001_NUM_CERTIFICADO);

            /*" -5843- MOVE 0 TO LK-VG001-SEQ-CRITICA */
            _.Move(0, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -5844- MOVE 'BI' TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("BI", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -5845- MOVE V0CLIE-CGCCPF TO LK-VG001-NUM-CPF-CNPJ */
            _.Move(V0CLIE_CGCCPF, SPVG001W.LK_VG001_NUM_CPF_CNPJ);

            /*" -5846- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -5847- MOVE 'BI8005B' TO LK-VG001-NOM-PROGRAMA */
            _.Move("BI8005B", SPVG001W.LK_VG001_NOM_PROGRAMA);

            /*" -5848- MOVE 'SPBVG001' TO VG001-PROGRAMA */
            _.Move("SPBVG001", SPVG001V.VG001_PROGRAMA);

            /*" -5849- MOVE SPACES TO LK-VG001-STA-CRITICA */
            _.Move("", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -5850- MOVE 45 TO LK-VG001-DES-COMPLEMENTAR-L */
            _.Move(45, SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_L);

            /*" -5851- MOVE 5 TO LK-VG001-COD-MSG-CRITICA */
            _.Move(5, SPVG001W.LK_VG001_COD_MSG_CRITICA);

            /*" -5853- MOVE 'EMISSAO DE BILHETE SEM CLASSIFICACAO DE RISCO' TO LK-VG001-DES-COMPLEMENTAR-T */
            _.Move("EMISSAO DE BILHETE SEM CLASSIFICACAO DE RISCO", SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_T);

            /*" -5855- ADD 1 TO WS-QT-EMISSAO-S-RISCO */
            WS_QT_EMISSAO_S_RISCO.Value = WS_QT_EMISSAO_S_RISCO + 1;

            /*" -5857- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -5858- IF LK-VG001-IND-ERRO NOT EQUAL ZEROS */

            if (SPVG001W.LK_VG001_IND_ERRO != 00)
            {

                /*" -5859- IF LK-VG001-IND-ERRO EQUAL 1 */

                if (SPVG001W.LK_VG001_IND_ERRO == 1)
                {

                    /*" -5863- DISPLAY 'ERRO JAH GRAVADO 7060 >> ' LK-VG001-NUM-CERTIFICADO ' >> ' LK-VG001-COD-MSG-CRITICA ' >> ' LK-VG001-IND-ERRO */

                    $"ERRO JAH GRAVADO 7060 >> {SPVG001W.LK_VG001_NUM_CERTIFICADO} >> {SPVG001W.LK_VG001_COD_MSG_CRITICA} >> {SPVG001W.LK_VG001_IND_ERRO}"
                    .Display();

                    /*" -5864- DISPLAY 'MSG-ERRO: ' LK-VG001-MSG-ERRO */
                    _.Display($"MSG-ERRO: {SPVG001W.LK_VG001_MSG_ERRO}");

                    /*" -5865- ELSE */
                }
                else
                {


                    /*" -5866- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -5867- DISPLAY '* 7060 -  PROBLEMAS CALL SUBROTINA SPBVG001 *' */
                    _.Display($"* 7060 -  PROBLEMAS CALL SUBROTINA SPBVG001 *");

                    /*" -5868- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -5869- DISPLAY '* NUM-CERTIF..: ' LK-VG001-NUM-CERTIFICADO */
                    _.Display($"* NUM-CERTIF..: {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                    /*" -5870- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                    _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                    /*" -5871- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                    _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                    /*" -5872- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                    _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                    /*" -5873- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                    _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                    /*" -5874- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                    _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                    /*" -5876- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -5877- MOVE 999 TO SQLCODE */
                    _.Move(999, DB.SQLCODE);

                    /*" -5878- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -5879- END-IF */
                }


                /*" -5881- END-IF */
            }


            /*" -5882- MOVE 'BI8005B' TO VG078-COD-USUARIO */
            _.Move("BI8005B", VG078.DCLVG_ANDAMENTO_PROP.VG078_COD_USUARIO);

            /*" -5883- MOVE V0BILH-NUMBIL TO VG078-NUM-CERTIFICADO */
            _.Move(V0BILH_NUMBIL, VG078.DCLVG_ANDAMENTO_PROP.VG078_NUM_CERTIFICADO);

            /*" -5885- MOVE 55 TO VG078-DES-ANDAMENTO-LEN */
            _.Move(55, VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.VG078_DES_ANDAMENTO_LEN);

            /*" -5886- PERFORM R9997-00-INSERE-ANDAMENTO */

            R9997_00_INSERE_ANDAMENTO_SECTION();

            /*" -5886- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7060_99_SAIDA*/

        [StopWatch]
        /*" R7100-00-CONS-COD-CRITICA-SECTION */
        private void R7100_00_CONS_COD_CRITICA_SECTION()
        {
            /*" -5895- MOVE '7100' TO WNR-EXEC-SQL. */
            _.Move("7100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5896- MOVE 'N' TO VG001-IND-EXISTE */
            _.Move("N", SPVG001V.VG001_IND_EXISTE);

            /*" -5897- MOVE 'N' TO LK-VG001-TRACE */
            _.Move("N", SPVG001W.LK_VG001_TRACE);

            /*" -5898- MOVE 07 TO LK-VG001-TIPO-ACAO */
            _.Move(07, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -5899- MOVE V0BILH-NUMBIL TO LK-VG001-NUM-CERTIFICADO */
            _.Move(V0BILH_NUMBIL, SPVG001W.LK_VG001_NUM_CERTIFICADO);

            /*" -5900- MOVE 0 TO LK-VG001-SEQ-CRITICA */
            _.Move(0, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -5901- MOVE SPACES TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -5902- MOVE 0 TO LK-VG001-NUM-CPF-CNPJ */
            _.Move(0, SPVG001W.LK_VG001_NUM_CPF_CNPJ);

            /*" -5903- MOVE WS-COD-CRITICA TO LK-VG001-COD-MSG-CRITICA */
            _.Move(WS_COD_CRITICA, SPVG001W.LK_VG001_COD_MSG_CRITICA);

            /*" -5904- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -5905- MOVE 'BI8005B' TO LK-VG001-NOM-PROGRAMA */
            _.Move("BI8005B", SPVG001W.LK_VG001_NOM_PROGRAMA);

            /*" -5906- MOVE 'SPBVG001' TO VG001-PROGRAMA */
            _.Move("SPBVG001", SPVG001V.VG001_PROGRAMA);

            /*" -5907- MOVE SPACES TO LK-VG001-STA-CRITICA */
            _.Move("", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -5908- MOVE 00 TO LK-VG001-DES-COMPLEMENTAR-L */
            _.Move(00, SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_L);

            /*" -5910- MOVE SPACES TO LK-VG001-DES-COMPLEMENTAR-T */
            _.Move("", SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_T);

            /*" -5912- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -5913- IF LK-VG001-IND-ERRO = 0 */

            if (SPVG001W.LK_VG001_IND_ERRO == 0)
            {

                /*" -5914- IF LK-VG001-S-NUM-CERTIFICADO > 0 */

                if (SPVG001W.LK_VG001_S_NUM_CERTIFICADO > 0)
                {

                    /*" -5915- MOVE 'S' TO VG001-IND-EXISTE */
                    _.Move("S", SPVG001V.VG001_IND_EXISTE);

                    /*" -5916- ELSE */
                }
                else
                {


                    /*" -5917- MOVE 'N' TO VG001-IND-EXISTE */
                    _.Move("N", SPVG001V.VG001_IND_EXISTE);

                    /*" -5918- END-IF */
                }


                /*" -5919- ELSE */
            }
            else
            {


                /*" -5920- DISPLAY '*-------------------------------------------*' */
                _.Display($"*-------------------------------------------*");

                /*" -5921- DISPLAY '* 7100 -  PROBLEMAS CALL SUBROTINA SPBVG001 *' */
                _.Display($"* 7100 -  PROBLEMAS CALL SUBROTINA SPBVG001 *");

                /*" -5922- DISPLAY '*-------------------------------------------*' */
                _.Display($"*-------------------------------------------*");

                /*" -5923- DISPLAY '* NUM-CERTIF..: ' LK-VG001-NUM-CERTIFICADO */
                _.Display($"* NUM-CERTIF..: {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                /*" -5924- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                /*" -5925- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                /*" -5926- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                /*" -5927- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                /*" -5928- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                /*" -5930- DISPLAY '*-------------------------------------------*' */
                _.Display($"*-------------------------------------------*");

                /*" -5931- MOVE 999 TO SQLCODE */
                _.Move(999, DB.SQLCODE);

                /*" -5932- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -5933- END-IF */
            }


            /*" -5933- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7100_99_SAIDA*/

        [StopWatch]
        /*" R9990-00-TEM-CRITICA-SECTION */
        private void R9990_00_TEM_CRITICA_SECTION()
        {
            /*" -5945- MOVE '9990' TO WNR-EXEC-SQL. */
            _.Move("9990", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5946- MOVE 'N' TO VG001-IND-EXISTE */
            _.Move("N", SPVG001V.VG001_IND_EXISTE);

            /*" -5947- MOVE 'N' TO LK-VG001-TRACE */
            _.Move("N", SPVG001W.LK_VG001_TRACE);

            /*" -5948- MOVE 06 TO LK-VG001-TIPO-ACAO */
            _.Move(06, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -5949- MOVE V0BILH-NUMBIL TO LK-VG001-NUM-CERTIFICADO */
            _.Move(V0BILH_NUMBIL, SPVG001W.LK_VG001_NUM_CERTIFICADO);

            /*" -5950- MOVE 0 TO LK-VG001-SEQ-CRITICA */
            _.Move(0, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -5951- MOVE SPACES TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -5952- MOVE 0 TO LK-VG001-NUM-CPF-CNPJ */
            _.Move(0, SPVG001W.LK_VG001_NUM_CPF_CNPJ);

            /*" -5953- MOVE 1 TO LK-VG001-COD-MSG-CRITICA */
            _.Move(1, SPVG001W.LK_VG001_COD_MSG_CRITICA);

            /*" -5954- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -5955- MOVE 'BI8005B' TO LK-VG001-NOM-PROGRAMA */
            _.Move("BI8005B", SPVG001W.LK_VG001_NOM_PROGRAMA);

            /*" -5956- MOVE SPACES TO LK-VG001-STA-CRITICA */
            _.Move("", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -5958- MOVE 00 TO LK-VG001-DES-COMPLEMENTAR-L */
            _.Move(00, SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_L);

            /*" -5961- MOVE SPACES TO LK-VG001-DES-COMPLEMENTAR-T */
            _.Move("", SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_T);

            /*" -5963- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -5964- IF LK-VG001-IND-ERRO = 0 */

            if (SPVG001W.LK_VG001_IND_ERRO == 0)
            {

                /*" -5965- IF LK-VG001-S-NUM-CERTIFICADO > 0 */

                if (SPVG001W.LK_VG001_S_NUM_CERTIFICADO > 0)
                {

                    /*" -5966- MOVE 'S' TO VG001-IND-EXISTE */
                    _.Move("S", SPVG001V.VG001_IND_EXISTE);

                    /*" -5967- ELSE */
                }
                else
                {


                    /*" -5968- MOVE 'N' TO VG001-IND-EXISTE */
                    _.Move("N", SPVG001V.VG001_IND_EXISTE);

                    /*" -5969- END-IF */
                }


                /*" -5970- ELSE */
            }
            else
            {


                /*" -5971- DISPLAY '*-------------------------------------------*' */
                _.Display($"*-------------------------------------------*");

                /*" -5972- DISPLAY '* 9990 -  PROBLEMAS CALL SUBROTINA SPBVG001 *' */
                _.Display($"* 9990 -  PROBLEMAS CALL SUBROTINA SPBVG001 *");

                /*" -5973- DISPLAY '*-------------------------------------------*' */
                _.Display($"*-------------------------------------------*");

                /*" -5974- DISPLAY '* NUM-CERTIF..: ' LK-VG001-NUM-CERTIFICADO */
                _.Display($"* NUM-CERTIF..: {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                /*" -5975- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                /*" -5976- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                /*" -5977- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                /*" -5978- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                /*" -5979- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                /*" -5980- DISPLAY '*-------------------------------------------*' */
                _.Display($"*-------------------------------------------*");

                /*" -5982- END-IF */
            }


            /*" -5982- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9990_99_SAIDA*/

        [StopWatch]
        /*" R9991-00-INSERE-CRITICA-SECTION */
        private void R9991_00_INSERE_CRITICA_SECTION()
        {
            /*" -5993- MOVE '9991' TO WNR-EXEC-SQL. */
            _.Move("9991", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5994- MOVE 'N' TO LK-VG001-TRACE */
            _.Move("N", SPVG001W.LK_VG001_TRACE);

            /*" -5995- MOVE 02 TO LK-VG001-TIPO-ACAO */
            _.Move(02, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -5996- MOVE V0BILH-NUMBIL TO LK-VG001-NUM-CERTIFICADO */
            _.Move(V0BILH_NUMBIL, SPVG001W.LK_VG001_NUM_CERTIFICADO);

            /*" -5997- MOVE 0 TO LK-VG001-SEQ-CRITICA */
            _.Move(0, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -5998- MOVE 'BI' TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("BI", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -5999- MOVE 0 TO LK-VG001-NUM-CPF-CNPJ */
            _.Move(0, SPVG001W.LK_VG001_NUM_CPF_CNPJ);

            /*" -6000- MOVE 1 TO LK-VG001-COD-MSG-CRITICA */
            _.Move(1, SPVG001W.LK_VG001_COD_MSG_CRITICA);

            /*" -6001- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -6002- MOVE 'BI8005B' TO LK-VG001-NOM-PROGRAMA */
            _.Move("BI8005B", SPVG001W.LK_VG001_NOM_PROGRAMA);

            /*" -6003- MOVE SPACES TO LK-VG001-STA-CRITICA */
            _.Move("", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -6004- MOVE 24 TO LK-VG001-DES-COMPLEMENTAR-L */
            _.Move(24, SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_L);

            /*" -6007- MOVE 'CADASTRAMENTO DE CRITICA' TO LK-VG001-DES-COMPLEMENTAR-T */
            _.Move("CADASTRAMENTO DE CRITICA", SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_T);

            /*" -6009- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -6010- IF LK-VG001-IND-ERRO NOT EQUAL ZEROS */

            if (SPVG001W.LK_VG001_IND_ERRO != 00)
            {

                /*" -6011- IF LK-VG001-IND-ERRO EQUAL 1 */

                if (SPVG001W.LK_VG001_IND_ERRO == 1)
                {

                    /*" -6015- DISPLAY 'ERRO JAH GRAVADO 9991 >> ' LK-VG001-NUM-CERTIFICADO ' >> ' LK-VG001-COD-MSG-CRITICA ' >> ' LK-VG001-IND-ERRO */

                    $"ERRO JAH GRAVADO 9991 >> {SPVG001W.LK_VG001_NUM_CERTIFICADO} >> {SPVG001W.LK_VG001_COD_MSG_CRITICA} >> {SPVG001W.LK_VG001_IND_ERRO}"
                    .Display();

                    /*" -6016- DISPLAY 'MSG-ERRO: ' LK-VG001-MSG-ERRO */
                    _.Display($"MSG-ERRO: {SPVG001W.LK_VG001_MSG_ERRO}");

                    /*" -6017- ELSE */
                }
                else
                {


                    /*" -6018- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -6019- DISPLAY '* 9991 -  PROBLEMAS CALL SUBROTINA SPBVG001 *' */
                    _.Display($"* 9991 -  PROBLEMAS CALL SUBROTINA SPBVG001 *");

                    /*" -6020- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -6021- DISPLAY '* NUM-CERTIF..: ' LK-VG001-NUM-CERTIFICADO */
                    _.Display($"* NUM-CERTIF..: {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                    /*" -6022- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                    _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                    /*" -6023- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                    _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                    /*" -6024- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                    _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                    /*" -6025- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                    _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                    /*" -6026- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                    _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                    /*" -6028- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -6029- MOVE 999 TO SQLCODE */
                    _.Move(999, DB.SQLCODE);

                    /*" -6030- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -6031- END-IF */
                }


                /*" -6032- END-IF */
            }


            /*" -6032- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9991_99_SAIDA*/

        [StopWatch]
        /*" R9997-00-INSERE-ANDAMENTO-SECTION */
        private void R9997_00_INSERE_ANDAMENTO_SECTION()
        {
            /*" -6045- MOVE '9997' TO WNR-EXEC-SQL. */
            _.Move("9997", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -6046- MOVE V0BILH-NUMBIL TO VG078-NUM-CERTIFICADO */
            _.Move(V0BILH_NUMBIL, VG078.DCLVG_ANDAMENTO_PROP.VG078_NUM_CERTIFICADO);

            /*" -6047- MOVE 61 TO VG078-DES-ANDAMENTO-LEN */
            _.Move(61, VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.VG078_DES_ANDAMENTO_LEN);

            /*" -6048- MOVE 'CLIENTE PEP.' TO VG078-DES-ANDAMENTO-TEXT */
            _.Move("CLIENTE PEP.", VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.VG078_DES_ANDAMENTO_TEXT);

            /*" -6050- MOVE 'BI3005B' TO VG078-COD-USUARIO */
            _.Move("BI3005B", VG078.DCLVG_ANDAMENTO_PROP.VG078_COD_USUARIO);

            /*" -6065- PERFORM R9997_00_INSERE_ANDAMENTO_DB_INSERT_1 */

            R9997_00_INSERE_ANDAMENTO_DB_INSERT_1();

            /*" -6068- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -6069- CONTINUE */

                /*" -6070- ELSE */
            }
            else
            {


                /*" -6071- DISPLAY 'R9997-00 - PROBLEMAS NO INSERT VG_ANDAMENTO_PROP' */
                _.Display($"R9997-00 - PROBLEMAS NO INSERT VG_ANDAMENTO_PROP");

                /*" -6072- DISPLAY 'NUM-BILHETE     = ' VG078-NUM-CERTIFICADO */
                _.Display($"NUM-BILHETE     = {VG078.DCLVG_ANDAMENTO_PROP.VG078_NUM_CERTIFICADO}");

                /*" -6073- DISPLAY 'SQLCODE         = ' SQLCODE */
                _.Display($"SQLCODE         = {DB.SQLCODE}");

                /*" -6074- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -6076- END-IF */
            }


            /*" -6078- . */

        }

        [StopWatch]
        /*" R9997-00-INSERE-ANDAMENTO-DB-INSERT-1 */
        public void R9997_00_INSERE_ANDAMENTO_DB_INSERT_1()
        {
            /*" -6065- EXEC SQL INSERT INTO SEGUROS.VG_ANDAMENTO_PROP ( NUM_CERTIFICADO , DTH_CADASTRAMENTO , DES_ANDAMENTO , COD_USUARIO ) VALUES ( :VG078-NUM-CERTIFICADO , CURRENT TIMESTAMP , :VG078-DES-ANDAMENTO , :VG078-COD-USUARIO ) END-EXEC */

            var r9997_00_INSERE_ANDAMENTO_DB_INSERT_1_Insert1 = new R9997_00_INSERE_ANDAMENTO_DB_INSERT_1_Insert1()
            {
                VG078_NUM_CERTIFICADO = VG078.DCLVG_ANDAMENTO_PROP.VG078_NUM_CERTIFICADO.ToString(),
                VG078_DES_ANDAMENTO = VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.ToString(),
                VG078_COD_USUARIO = VG078.DCLVG_ANDAMENTO_PROP.VG078_COD_USUARIO.ToString(),
            };

            R9997_00_INSERE_ANDAMENTO_DB_INSERT_1_Insert1.Execute(r9997_00_INSERE_ANDAMENTO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9997_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -6133- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -6135- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -6135- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -6137- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -6141- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -6141- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}