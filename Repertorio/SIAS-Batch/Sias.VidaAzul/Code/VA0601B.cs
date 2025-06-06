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
using Sias.VidaAzul.DB2.VA0601B;

namespace Code
{
    public class VA0601B
    {
        public bool IsCall { get; set; }

        public VA0601B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *================================================================*      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO : INTEGRA SISPF E SIAS PARA OS                        *      */
        /*"      *            PRODUTOS DE VIDA PESSOA FISICA                      *      */
        /*"      *                                                                *      */
        /*"      *             ===> VERSAO DO VA0601B CRIADA PARA O AIC           *      */
        /*"      *                                                                *      */
        /*"      *================================================================*      */
        /*"V.142 *  VERSAO 142 - DEMANDA REQ0086- NOVA FAIXA IDADE VIDA EXCLUSIVO *      */
        /*"      *                                                                *      */
        /*"      *  EM 12/11/2024 - CANETTA               PROCURE POR V.142       *      */
        /*"      *                                                                *      */
        /*"      *================================================================*      */
        /*"V.141 *  VERSAO 141 - DEMANDA 571983 / RITM0004370                     *      */
        /*"      *             - NOVOS PRODUTOS VIDA CONFORTO EM SUBSTITUICAO     *      */
        /*"      *               AOS PRODUTOS CONTIDOS NA APOLICE 97010000889.    *      */
        /*"      *                                                                *      */
        /*"      *             - OS SEGURADOS DO MULTIPREMIADO SERAO MIGRADOS     *      */
        /*"      *               PARA APOLICE ABAIXO POR JAH TEREM                *      */
        /*"      *               REENQUADRAMENTO POR FAIXA ETARIA.                *      */
        /*"      *                                                                *      */
        /*"      *               APOLICE       SG  PRD DESCRICAO                  *      */
        /*"      *               3009300007815  1 9320 MULTIPREMIADO ME C/CONJ    *      */
        /*"      *               3009300007815  2 9320 MULTIPREMIADO ME S/CONJ    *      */
        /*"      *                                                                *      */
        /*"      *             - SERAO MIGRADOS PARA AS NOVAS APOLICES OS         *      */
        /*"      *               PRODUTOS VIDAZUL:                                *      */
        /*"      *                                                                *      */
        /*"      *                      - TRADICIONAL;                            *      */
        /*"      *                      - MASTER;                                 *      */
        /*"      *                      - PREMIADO; E                             *      */
        /*"      *                      - EXECUTIVO.                              *      */
        /*"      *                                                                *      */
        /*"      *             - O VIDAZUL SENIOR NAO SERAH MIGRADO EM FUNCAO     *      */
        /*"      *               DOS SEGURADOS ESTAREM TODOS COM IDADE ACIMA DE   *      */
        /*"      *               80 ANOS QUANDO DO CANCELAMENTO DA APOLICE        *      */
        /*"      *               QUE SERAH FEITO EM AGOSTO DE 2024.               *      */
        /*"      *                                                                *      */
        /*"      *               APOLICE       SG  PRD DESCRICAO                  *      */
        /*"      *               3009300007651  1 9753 VIDA CONFORTO ME S/CONJ    *      */
        /*"      *               3009300007651  2 9753 VIDA CONFORTO ME C/CONJ    *      */
        /*"      *               3009300007652  1 9754 VIDA CONFORTO AN S/CONJ    *      */
        /*"      *               3009300007652  2 9754 VIDA CONFORTO AN C/CONJ    *      */
        /*"      *                                                                *      */
        /*"      *             - A DEMANDA REQ0000086 TAMBEM FOI CONTEMPLADA      *      */
        /*"      *               AQUI ATERANDO DE 70 PARA 80 ANOS DE IDADE        *      */
        /*"      *               O LIMITE DE CONTRATACAO PARA                     *      */
        /*"      *               PRODUTO 9310 - VIDA EXCLUSIVO                    *      */
        /*"      *                                                                *      */
        /*"      *  EM 08/10/2024 - TERCIO CARVALHO                               *      */
        /*"      *                                        PROCURE POR V.141       *      */
        /*"      *================================================================*      */
        /*"V.140 *  VERSAO 140 - DEMANDA RITM0000078 - ACUMULO DE RISCO           *      */
        /*"      *             - AJUSTA ACUMULO DE RISCO PARA OS PRODUTOS         *      */
        /*"      *               JVPRD9351, JVPRD9352 E JVPRD9353                 *      */
        /*"      *                                                                *      */
        /*"      *  EM 19/08/2024 - TERCIO CARVALHO                               *      */
        /*"      *                                        PROCURE POR V.140       *      */
        /*"      *================================================================*      */
        /*"V.139 *  VERSAO 139 - DEMANDA 571.176 - DPS ELETRONICA                 *      */
        /*"      *             - CONSULTA PARA IDENTIFICAR SE A PROPOSTA NECESSI- *      */
        /*"      *               TA DE DPS ELETRONICO. CASO NECESSITE E DPS NAO   *      */
        /*"      *               ESTEJA CADASTRADA, GERA STATUS PARA QUE O MOTOR  *      */
        /*"      *               DE DPS SEJA CONSULTA POR SERVICO JAVA.           *      */
        /*"      *             - CRIAR ERROS 1896 E 1897 PARA PROPOSTAS COM ACUMU-*      */
        /*"      *               LO DE IS SUPERIOR A 5MIL E 12,5MIL PARA VIDA,    *      */
        /*"      *               PRESTAMISTA E PREVIDENCIA                        *      */
        /*"      *                                                                *      */
        /*"      *  EM 05/08/2024 - ELIERMES OLIVEIRA                             *      */
        /*"      *                                        PROCURE POR V.139       *      */
        /*"      *================================================================*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 138 - NAO ESTAH EMITINDO NINGUEM. GERAR SYSOUT  PARA  *      */
        /*"      *                ANALISE                                         *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/07/2024 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                            PROCURE POR V.138   *      */
        /*"      *================================================================*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 137 - D 584537 T 586984                               *      */
        /*"      *              - QUANDO PRODUTO SIVPF IGUAL A ( 11 OU 13 OU 46 ) *      */
        /*"      *                     E PERIODICIDADE PAGAMENTO = 12             *      */
        /*"      *                     STA_ANTECIPACAO = 'S'                      *      */
        /*"      *                                                                *      */
        /*"      *   EM 14/05/2024 - HUSNI ALI HUSNI                              *      */
        /*"      *                                            PROCURE POR V.137   *      */
        /*"      *================================================================*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 136 - D 575149 T 584859                               *      */
        /*"      *             - ACERTAR INSERT'S NA HIS_COBER_PROPOST  E         *      */
        /*"      *             V0COBERPROPVA                                      *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/04/2024 - HUSNI ALI HUSNI                              *      */
        /*"      *                                            PROCURE POR V.136   *      */
        /*"      *================================================================*      */
        /*"      *                                                                *      */
        /*"V.135 *   VERSAO 135 - DEMANDA 570.380                                 *      */
        /*"      *              - CORRIGIR AS CRITICAS 1893 E 1894 PARA NAO DECLI-*      */
        /*"      *                NAR AS PROPOSTAS.                               *      */
        /*"      *                                                                *      */
        /*"      *   EM 29/01/2024 - FRANK CARVALHO       PROCURE POR V.135       *      */
        /*"      *                                                                *      */
        /*"      *================================================================*      */
        /*"      *                                                                *      */
        /*"V.134 *   VERSAO 134 - DEMANDA 568.044                                 *      */
        /*"      *              - HABILITAR A CRITICA 1829 PARA OS PRODUTOS DO    *      */
        /*"      *                VIDA PROTECAO EXECUTIVA.                        *      */
        /*"      *                                                                *      */
        /*"      *   EM 19/01/2024 - FRANK CARVALHO       PROCURE POR V.134       *      */
        /*"      *                                                                *      */
        /*"      *================================================================*      */
        /*"      *                                                                *      */
        /*"V.133 *  VERSAO 133 - DEMANDA 484074 - Novo produto Protecao Executiva *      */
        /*"      *                                                                *      */
        /*"      *  EM 02/10/2023 - TERCIO CARVALHO     PROCURE POR V.133         *      */
        /*"      *                                                                *      */
        /*"      *================================================================*      */
        /*"      *                                                                *      */
        /*"V.132 *  VERSAO 132 - DEMANDA 470437 - Novo portal de vendas           *      */
        /*"      *                                                                *      */
        /*"      *  EM 11/03/2023 - CANETTA             PROCURE POR V.132         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      ******************************************************************      */
        /*"V.131 *  VERSAO 131 - INCIDENTE 471184  TAREFA 471331                  *      */
        /*"      *             - GRAVAR ERROS EM TABELAS APOS TER INSERIDO INFOR- *      */
        /*"      *               MACOES DE CERTIFICADO NA PROPOSTAS_VA E          *      */
        /*"      *               HIST_COBER                                       *      */
        /*"      *                                                                *      */
        /*"      *  EM 23/02/2023 - HUSNI ALI HUSNI                               *      */
        /*"      *                                        PROCURE POR V.131       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.130 *  VERSAO 130 - DEMANDA 402.982                                  *      */
        /*"      *             - RETIRAR GRAVACAO DE ERROS DA PROPOSTA DA TABELA  *      */
        /*"      *               ERROS_PROP_VIDAZUL                               *      */
        /*"      *             - GRAVAR ERROS DA PROPOSTA NA NOVA TABELA          *      */
        /*"      *               VG_CRITICA_PROPOSTA PARA POSTERIOR ANALISE DO    *      */
        /*"      *               GESTOR NO ATALHO 04.23                           *      */
        /*"      *                                                                *      */
        /*"      *  EM 14/02/2023 - ELIERMES OLIVEIRA                             *      */
        /*"      *                                        PROCURE POR V.130       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO 129 - INCIDENTE 463567                                 *      */
        /*"      *             - -302 NO INSERT  PROPOSTAS_VA PARA A PROPOSTA     *      */
        /*"      *               080631060000184                                  *      */
        /*"      *                                                                *      */
        /*"      *   EM 24/01/2023 - BRICE HO            PROCURE POR V.129        *      */
        /*"      *================================================================*      */
        /*"      *  VERSAO 128 - DEMANDA 437661                                   *      */
        /*"      *             - AJUSTE CRITICA DE PROFISSAO DE RISCO SOMENTE     *      */
        /*"      *               PARA AGENTE POLICIAL.                            *      */
        /*"      *             - AJUSTE CRITICA DE PROFISSAO DE APOSENTADO QUE    *      */
        /*"      *               PASSOU A SER CONSIDERADO RISCO SE APOSENTADO     *      */
        /*"      *               POR INVALIDEZ (ITEM 2 DA DPS='S').               *      */
        /*"      *                                                                *      */
        /*"      *   EM 17/01/2023 - BRICE HO            PROCURE POR V.128        *      */
        /*"      *================================================================*      */
        /*"V.127 *  VERSAO 127 - PLD Circular 612 - Fase 2 -  Demanda 379166      *      */
        /*"      *             - INCLUIDO ROTINA SPBVG001 PARA CONSULTA DE RISCO  *      */
        /*"      *               DA PROPOSTA. CASO EXISTA RISCO CRITICO NAO       *      */
        /*"      *               SOLUCIONADO AGUARDA CONCLUSAO DO TRATAMENTO      *      */
        /*"      *               PELO GESTOR, CASO NAO ENCONTRE RISCO CADASTRADO, *      */
        /*"      *               VERIFICA SE MOTOR GEROU CLASSIFICACAO, SE GEROU  *      */
        /*"      *               INSERE CLASSIFICACAO, SE NAO GEROU INFORMA QUE A *      */
        /*"      *               PROPOSTA SERAH EMITIDA SEM ANALISE DE RISCO      *      */
        /*"      *                                                                *      */
        /*"      *   EM 04/10/2022 - ELIERMES OLIVEIRA   PROCURE POR V.127        *      */
        /*"      *================================================================*      */
        /*"      *                                                                *      */
        /*"V.126 *   VERSAO 126 - DEMANDA 430.955                                 *      */
        /*"      *              - PERMITIR A VENDA DE PRODUTOS PARA               *      */
        /*"      *                O CPF 000.000.421-96.                           *      */
        /*"      *                                                                *      */
        /*"      *   EM 29/09/2022 - FLAVIO BICALHO                               *      */
        /*"      *                                        PROCURE POR V.126       *      */
        /*"      *================================================================*      */
        /*"      *                                                                *      */
        /*"V.125 *   VERSAO 125 - DEMANDA 401.238                                 *      */
        /*"      *              - EXTENSAO DE IDADE DO GRUPO SEGUR�VEL P/ 70 ANOS *      */
        /*"      *                                                                *      */
        /*"      *   EM 12/09/2022 - CANETTA              PROCURE POR V.125       *      */
        /*"      *                                                                *      */
        /*"      *================================================================*      */
        /*"      *                                                                *      */
        /*"V.124 *   VERSAO 124 - DEMANDA 387.459                                 *      */
        /*"      *              - ALTERACAO DO VALOR DE 100 MIL PARA 200 MIL DA   *      */
        /*"      *                CRITICA 1829 - LIMITE DE CAPITAL ULTRAPASSADO   *      */
        /*"      *                                                                *      */
        /*"      *   EM 13/05/2022 - FRANK CARVALHO       PROCURE POR V.124       *      */
        /*"      *                                                                *      */
        /*"      *================================================================*      */
        /*"      *                                                                *      */
        /*"V.123 *   VERSAO 123 - DEMANDA 378.303                                 *      */
        /*"      *              - ACUMULO DE RISCO SIAS - PRODUTO VIDA DA GENTE - *      */
        /*"      *                MANTER EM R$ 100MIL                             *      */
        /*"      *              - RETIRAR INCL NA GE_RETENCAO_PROPOSTA            *      */
        /*"      *                                                                *      */
        /*"      *   EM 04/04/2022 - CANETTA              PROCURE POR V.123       *      */
        /*"      *                                                                *      */
        /*"      *================================================================*      */
        /*"      *                                                                *      */
        /*"V.122 *   VERSAO 122- DEMANDA 330476                                   *      */
        /*"      *             - IMPLANTACAO MATRIZ DE DESCONTOS E AGRAVOS POR    *      */
        /*"      *                 PROFISSAO.                                     *      */
        /*"      *                                                                *      */
        /*"      *   EM 23/02/2022 - CANETTA             PROCURE POR V.122        *      */
        /*"      *                                                                *      */
        /*"      *================================================================*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 121- DEMANDA 327.863                                  *      */
        /*"      *             - TRATAR O COD-PLANO 111 COMO ANTECIPADO.          *      */
        /*"      *             - SIGNIFICA QUE UM SEGURO COMERCIALIZADO COMO ANUAL*      */
        /*"      *               CHEGOU AO SIAS SEM A MARCACAO DE ANTECIPADO. O   *      */
        /*"      *               VA0600B INSERIU A MARCACAO 111, POIS NAO EXISTE  *      */
        /*"      *               MAIS VENDAS COM PERIODICIDADE ANUAL, APENAS NA   *      */
        /*"      *               MODALIDADE DE ANTECIPADO.                        *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/02/2022 - FRANK CARVALHO      PROCURE POR V.101        *      */
        /*"      *                                                                *      */
        /*"      *================================================================*      */
        /*"      *   DEMAIS HISTORICOS DE MANUTENCAO - VIDE FINAL DO PROGRAMA            */
        /*"      *================================================================*      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  WS-CNAE-MEI             PIC  9(008)           VALUE ZERO.*/
        public IntBasis WS_CNAE_MEI { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"77  WS-NUM-PROPOSTA-AZUL    PIC S9(13)V   COMP-3  VALUE ZERO.*/
        public DoubleBasis WS_NUM_PROPOSTA_AZUL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"77  COBERP-IMPMORNATU       PIC S9(13)V   COMP-3  VALUE ZERO.*/
        public DoubleBasis COBERP_IMPMORNATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"77  WS-PREMIO-TOTAL         PIC S9(13)V99 COMP-3  VALUE ZERO.*/
        public DoubleBasis WS_PREMIO_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  WS-PREMIO-TOTAL-AC      PIC S9(13)V99 COMP-3  VALUE ZERO.*/
        public DoubleBasis WS_PREMIO_TOTAL_AC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  WHOST-BCO-RELAT         PIC S9(4)       USAGE COMP.*/
        public IntBasis WHOST_BCO_RELAT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"77  WHOST-VLR-RELAT         PIC S9(10)V9(5) USAGE COMP-3.*/
        public DoubleBasis WHOST_VLR_RELAT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"77  WHOST-SIN-RELAT         PIC S9(15)V     USAGE COMP-3.*/
        public DoubleBasis WHOST_SIN_RELAT { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"77  WHOST-COD-CLIENTE       PIC S9(09)      USAGE COMP.*/
        public IntBasis WHOST_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  WHOST-OCORR-ENDERECO    PIC S9(04)      USAGE COMP.*/
        public IntBasis WHOST_OCORR_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  WHOST-ENDERECO          PIC  X(72).*/
        public StringBasis WHOST_ENDERECO { get; set; } = new StringBasis(new PIC("X", "72", "X(72)."), @"");
        /*"77  WHOST-BAIRRO            PIC  X(72).*/
        public StringBasis WHOST_BAIRRO { get; set; } = new StringBasis(new PIC("X", "72", "X(72)."), @"");
        /*"77  WHOST-CIDADE            PIC  X(72).*/
        public StringBasis WHOST_CIDADE { get; set; } = new StringBasis(new PIC("X", "72", "X(72)."), @"");
        /*"77  WHOST-SIGLA-UF          PIC  X(02).*/
        public StringBasis WHOST_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
        /*"77  WHOST-CEP               PIC S9(09)      USAGE COMP.*/
        public IntBasis WHOST_CEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  WHOST-DATA-NASCIMENTO   PIC  X(10).*/
        public StringBasis WHOST_DATA_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  WHOST-CGCCPF            PIC S9(15)      USAGE COMP-3.*/
        public IntBasis WHOST_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77  WS-TEM-CARENCIA         PIC  X(01)      VALUE SPACES.*/
        public StringBasis WS_TEM_CARENCIA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        /*"77  WHOST-NUM-CERTIFICADO         PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis WHOST_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"77  WHOST-OCORR-HISTORICO         PIC S9(4) USAGE COMP.*/
        public IntBasis WHOST_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"77  WHOST-DATA-INIVIGENCIA        PIC X(10).*/
        public StringBasis WHOST_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  WHOST-DATA-TERVIGENCIA        PIC X(10).*/
        public StringBasis WHOST_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  WHOST-IMPSEGUR                PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis WHOST_IMPSEGUR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77  WHOST-QUANT-VIDAS             PIC S9(9) USAGE COMP.*/
        public IntBasis WHOST_QUANT_VIDAS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"77  WHOST-IMPSEGIND               PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis WHOST_IMPSEGIND { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77  WHOST-COD-OPERACAO            PIC S9(4) USAGE COMP.*/
        public IntBasis WHOST_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"77  WHOST-OPCAO-COBERTURA         PIC X(1).*/
        public StringBasis WHOST_OPCAO_COBERTURA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"77  WHOST-IMP-MORNATU             PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis WHOST_IMP_MORNATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77  WHOST-IMPMORACID              PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis WHOST_IMPMORACID { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77  WHOST-IMPINVPERM              PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis WHOST_IMPINVPERM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77  WHOST-IMPAMDS                 PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis WHOST_IMPAMDS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77  WHOST-IMPDH                   PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis WHOST_IMPDH { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77  WHOST-IMPDIT                  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis WHOST_IMPDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77  WHOST-VLPREMIO                PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis WHOST_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77  WHOST-PRMVG                   PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis WHOST_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77  WHOST-PRMAP                   PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis WHOST_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77  WHOST-QTDE-TIT-CAPITALIZ      PIC S9(4) USAGE COMP.*/
        public IntBasis WHOST_QTDE_TIT_CAPITALIZ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"77  WHOST-VAL-TIT-CAPITALIZ       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis WHOST_VAL_TIT_CAPITALIZ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77  WHOST-VAL-CUSTO-CAPITALI      PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis WHOST_VAL_CUSTO_CAPITALI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77  WHOST-IMPSEGCDG               PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis WHOST_IMPSEGCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77  WHOST-VLCUSTCDG               PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis WHOST_VLCUSTCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77  WHOST-COD-USUARIO             PIC X(8).*/
        public StringBasis WHOST_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"77  WHOST-TIMESTAMP               PIC X(26).*/
        public StringBasis WHOST_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"77  WHOST-IMPSEGAUXF              PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis WHOST_IMPSEGAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77  WHOST-VLCUSTAUXF              PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis WHOST_VLCUSTAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77  WHOST-PRMDIT                  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis WHOST_PRMDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77  WHOST-QTMDIT                  PIC S9(4) USAGE COMP.*/
        public IntBasis WHOST_QTMDIT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01 WS-FIM-ERRO-DPS                   PIC X(003) VALUE SPACES.*/
        public StringBasis WS_FIM_ERRO_DPS { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"01 AC-DESPR-DPS-ELETR                PIC 9(007) VALUE  0.*/
        public IntBasis AC_DESPR_DPS_ELETR { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"01 WS-TEM-ERRO-DPS-ELETR             PIC X(003) VALUE 'NAO'.*/
        public StringBasis WS_TEM_ERRO_DPS_ELETR { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
        /*"01 WS-STA-PROPOSTA-SIAS              PIC S9(04) USAGE COMP.*/
        public IntBasis WS_STA_PROPOSTA_SIAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01 WS-SQLCODE                        PIC  ---9.*/
        public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "4", "---9."));
        /*"01 WS-EDIT.*/
        public VA0601B_WS_EDIT WS_EDIT { get; set; } = new VA0601B_WS_EDIT();
        public class VA0601B_WS_EDIT : VarBasis
        {
            /*"   10 WS-SMALLINT                    PIC ZZ.ZZ9-                                                 OCCURS 20 TIMES*/
            public ListBasis<IntBasis, Int64> WS_SMALLINT { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "6", "ZZ.ZZ9-"), 20);
            /*"   10 WS-INTEGER                     PIC Z.ZZZ.ZZZ.ZZ9-                                                 OCCURS 5 TIMES.*/
            public ListBasis<IntBasis, Int64> WS_INTEGER { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "11", "Z.ZZZ.ZZZ.ZZ9-"), 5);
            /*"   10 WS-BIGINT                      PIC 99999999999999                                                 OCCURS 5 TIMES.*/
            public ListBasis<IntBasis, Int64> WS_BIGINT { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "14", "99999999999999"), 5);
            /*"   10 WS-DECIMAL                     PIC ZZZZZZZZZZ9,999999                                                 OCCURS 10 TIMES*/
            public ListBasis<DoubleBasis, double> WS_DECIMAL { get; set; } = new ListBasis<DoubleBasis, double>(new PIC("9", "11", "ZZZZZZZZZZ9V999999"), 10);
            /*"   10 WS-TAXA                        PIC 9,99999-                                                 OCCURS 5 TIMES.*/
            public ListBasis<DoubleBasis, double> WS_TAXA { get; set; } = new ListBasis<DoubleBasis, double>(new PIC("9", "1", "9V99999-"), 5);
            /*"01  WS-QT-RISCO-CRITICO              PIC 9(006) VALUE 0.*/
        }
        public IntBasis WS_QT_RISCO_CRITICO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"01  WS-QT-EM-CRITICA                 PIC 9(006) VALUE 0.*/
        public IntBasis WS_QT_EM_CRITICA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"01  WS-QT-EMISSAO-S-RISCO            PIC 9(006) VALUE 0.*/
        public IntBasis WS_QT_EMISSAO_S_RISCO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"01  WS-QT-EMISSAO-C-RISCO            PIC 9(006) VALUE 0.*/
        public IntBasis WS_QT_EMISSAO_C_RISCO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"01  WS-QT-LIBERADO-EMISSAO           PIC 9(006) VALUE 0.*/
        public IntBasis WS_QT_LIBERADO_EMISSAO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"01  WS-QTD-SEM-RCAPS                 PIC 9(006) VALUE 0.*/
        public IntBasis WS_QTD_SEM_RCAPS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"01  WS-ERRO-VG009                    PIC 9(001) VALUE 0.*/
        public IntBasis WS_ERRO_VG009 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"01  WS-PROGRAMA                      PIC X(008) VALUE SPACES.*/
        public StringBasis WS_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"01    WS-HORAS.*/
        public VA0601B_WS_HORAS WS_HORAS { get; set; } = new VA0601B_WS_HORAS();
        public class VA0601B_WS_HORAS : VarBasis
        {
            /*"  03  WS-HORA-INI               PIC  X(008).*/
            public StringBasis WS_HORA_INI { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-INI-R REDEFINES WS-HORA-INI.*/
            private _REDEF_VA0601B_WS_HORA_INI_R _ws_hora_ini_r { get; set; }
            public _REDEF_VA0601B_WS_HORA_INI_R WS_HORA_INI_R
            {
                get { _ws_hora_ini_r = new _REDEF_VA0601B_WS_HORA_INI_R(); _.Move(WS_HORA_INI, _ws_hora_ini_r); VarBasis.RedefinePassValue(WS_HORA_INI, _ws_hora_ini_r, WS_HORA_INI); _ws_hora_ini_r.ValueChanged += () => { _.Move(_ws_hora_ini_r, WS_HORA_INI); }; return _ws_hora_ini_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_ini_r, WS_HORA_INI); }
            }  //Redefines
            public class _REDEF_VA0601B_WS_HORA_INI_R : VarBasis
            {
                /*"      05  HI                    PIC  9(002).*/
                public IntBasis HI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  MI                    PIC  9(002).*/
                public IntBasis MI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  SI                    PIC  9(002).*/
                public IntBasis SI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  DI                    PIC  9(002).*/
                public IntBasis DI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03  WS-HORA-FIM               PIC  X(008).*/

                public _REDEF_VA0601B_WS_HORA_INI_R()
                {
                    HI.ValueChanged += OnValueChanged;
                    MI.ValueChanged += OnValueChanged;
                    SI.ValueChanged += OnValueChanged;
                    DI.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_HORA_FIM { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-FIM-R REDEFINES WS-HORA-FIM.*/
            private _REDEF_VA0601B_WS_HORA_FIM_R _ws_hora_fim_r { get; set; }
            public _REDEF_VA0601B_WS_HORA_FIM_R WS_HORA_FIM_R
            {
                get { _ws_hora_fim_r = new _REDEF_VA0601B_WS_HORA_FIM_R(); _.Move(WS_HORA_FIM, _ws_hora_fim_r); VarBasis.RedefinePassValue(WS_HORA_FIM, _ws_hora_fim_r, WS_HORA_FIM); _ws_hora_fim_r.ValueChanged += () => { _.Move(_ws_hora_fim_r, WS_HORA_FIM); }; return _ws_hora_fim_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_fim_r, WS_HORA_FIM); }
            }  //Redefines
            public class _REDEF_VA0601B_WS_HORA_FIM_R : VarBasis
            {
                /*"      05  HF                    PIC  9(002).*/
                public IntBasis HF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  MF                    PIC  9(002).*/
                public IntBasis MF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  SF                    PIC  9(002).*/
                public IntBasis SF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  DF                    PIC  9(002).*/
                public IntBasis DF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03  SIT                       PIC S9(013)V99 COMP-3 VALUE +0.*/

                public _REDEF_VA0601B_WS_HORA_FIM_R()
                {
                    HF.ValueChanged += OnValueChanged;
                    MF.ValueChanged += OnValueChanged;
                    SF.ValueChanged += OnValueChanged;
                    DF.ValueChanged += OnValueChanged;
                }

            }
            public DoubleBasis SIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  SFT                       PIC S9(013)V99 COMP-3 VALUE +0.*/
            public DoubleBasis SFT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  SII                       PIC S9(004)    COMP   VALUE +0.*/
            public IntBasis SII { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  STT-DISP                  PIC --.---.---.---.--9,99.*/
            public DoubleBasis STT_DISP { get; set; } = new DoubleBasis(new PIC("9", "14", "--.---.---.---.--9V99."), 2);
            /*"  03  WHOST-SQLCODE             PIC -----999.*/
            public IntBasis WHOST_SQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "-----999."));
            /*"01  TOTAIS-ROT.*/
        }
        public VA0601B_TOTAIS_ROT TOTAIS_ROT { get; set; } = new VA0601B_TOTAIS_ROT();
        public class VA0601B_TOTAIS_ROT : VarBasis
        {
            /*"    03  FILLER  OCCURS 105 TIMES.*/
            public ListBasis<VA0601B_FILLER_0> FILLER_0 { get; set; } = new ListBasis<VA0601B_FILLER_0>(105);
            public class VA0601B_FILLER_0 : VarBasis
            {
                /*"        05  STT                       PIC S9(013)V99 COMP-3.*/
                public DoubleBasis STT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                /*"        05  SQT                       PIC S9(015)    COMP-3.*/
                public IntBasis SQT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
                /*"01  WHOST-CONT-ESPACO                 PIC S9(004)    COMP.*/
            }
        }
        public IntBasis WHOST_CONT_ESPACO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-NOME-CLIENTE                PIC  X(040).*/
        public StringBasis WHOST_NOME_CLIENTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"01  WHOST-NRPARCEL-56                 PIC S9(004)    COMP.*/
        public IntBasis WHOST_NRPARCEL_56 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-IMPMORNATU-MAX              PIC S9(013)V99 COMP-3.*/
        public DoubleBasis WHOST_IMPMORNATU_MAX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  WHOST-IMPMORNATU                  PIC S9(013)V99 COMP-3.*/
        public DoubleBasis WHOST_IMPMORNATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  WHOST-PREMIO-1                    PIC S9(013)V99 COMP-3.*/
        public DoubleBasis WHOST_PREMIO_1 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  WHOST-PREMIO-2                    PIC S9(013)V99 COMP-3.*/
        public DoubleBasis WHOST_PREMIO_2 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  WHOST-INFO-COMPL                  PIC  X(050).*/
        public StringBasis WHOST_INFO_COMPL { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
        /*"01  WHOST-PROFISSAO                   PIC  X(020).*/
        public StringBasis WHOST_PROFISSAO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"01  WHOST-PROFISSAO-CONJUGE           PIC  X(020).*/
        public StringBasis WHOST_PROFISSAO_CONJUGE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"01  WHOST-SIT-PROPOSTA                PIC  X(003).*/
        public StringBasis WHOST_SIT_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"01  WHOST-SIT-ENVIO                   PIC  X(001).*/
        public StringBasis WHOST_SIT_ENVIO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  WHOST-SIT-REGISTRO                PIC  X(001).*/
        public StringBasis WHOST_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  WHOST-STA-ANTECIPACAO             PIC  X(001).*/
        public StringBasis WHOST_STA_ANTECIPACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  WHOST-OPCAOPAG                    PIC  X(001).*/
        public StringBasis WHOST_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  WHOST-FONTE                       PIC S9(004)      COMP.*/
        public IntBasis WHOST_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-RAMO                        PIC S9(004)      COMP.*/
        public IntBasis WHOST_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-PROPAUTOM                   PIC S9(004)      COMP.*/
        public IntBasis WHOST_PROPAUTOM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-GRUPO-SUSEP                 PIC S9(004)      COMP.*/
        public IntBasis WHOST_GRUPO_SUSEP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-COD-RAMO                    PIC S9(004)      COMP.*/
        public IntBasis WHOST_COD_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-PREMIO-CONJ                 PIC S9(013)V99   COMP-3.*/
        public DoubleBasis WHOST_PREMIO_CONJ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  WHOST-TAXA-RAMO                   PIC S9(003)V9(4) COMP-3.*/
        public DoubleBasis WHOST_TAXA_RAMO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"01  WHOST-PERC-CDG                    PIC S9(003)V9(4) COMP-3.*/
        public DoubleBasis WHOST_PERC_CDG { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"01  WHOST-PERC-DIT                    PIC S9(003)V9(4) COMP-3.*/
        public DoubleBasis WHOST_PERC_DIT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"01  WHOST-DTPROXVEN                   PIC  X(010).*/
        public StringBasis WHOST_DTPROXVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  PROPVA-NRCERTIF                   PIC S9(15) COMP-3.*/
        public IntBasis PROPVA_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  WS-COUNT                          PIC S9(009) COMP VALUE +0.*/
        public IntBasis WS_COUNT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  WS-CONTA-BRC                      PIC  9(005) VALUE ZEROS.*/
        public IntBasis WS_CONTA_BRC { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
        /*"01  WS-POSICAO                        PIC  9(005) VALUE ZEROS.*/
        public IntBasis WS_POSICAO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
        /*"01  WS-SIGLA-UF                       PIC  X(002) VALUE SPACES.*/
        public StringBasis WS_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
        /*"01  WS-ENCONTROU-LETRA                PIC  X(001) VALUE 'N'.*/

        public SelectorBasis WS_ENCONTROU_LETRA { get; set; } = new SelectorBasis("001", "N")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 WS-SIM-ACHOU                    VALUE 'S'. */
							new SelectorItemBasis("WS_SIM_ACHOU", "S"),
							/*" 88 WS-NAO-ACHOU                    VALUE 'N'. */
							new SelectorItemBasis("WS_NAO_ACHOU", "N")
                }
        };

        /*"01  WS-INSERE-ANDAMENTO               PIC  X(001) VALUE 'N'.*/

        public SelectorBasis WS_INSERE_ANDAMENTO { get; set; } = new SelectorBasis("001", "N")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 WS-PROP-ELETRONICA              VALUE 'S'. */
							new SelectorItemBasis("WS_PROP_ELETRONICA", "S"),
							/*" 88 WS-NAO-PROP-ELETRONICA          VALUE 'N'. */
							new SelectorItemBasis("WS_NAO_PROP_ELETRONICA", "N")
                }
        };

        /*"01  WS-TXT-PROP-ELETRONICA            PIC  X(055) VALUE        'PROPOSTA ELETRONICA COM ASSINATURA DIGITAL/TOKEN.'.*/
        public StringBasis WS_TXT_PROP_ELETRONICA { get; set; } = new StringBasis(new PIC("X", "55", "X(055)"), @"PROPOSTA ELETRONICA COM ASSINATURA DIGITAL/TOKEN.");
        /*"01  WS-TXT-PROP-ELETRONICA-EMAIL      PIC  X(055) VALUE        'PROPOSTA ELETRONICA COM ASSINATURA DIGITAL POR E-MAIL'.*/
        public StringBasis WS_TXT_PROP_ELETRONICA_EMAIL { get; set; } = new StringBasis(new PIC("X", "55", "X(055)"), @"PROPOSTA ELETRONICA COM ASSINATURA DIGITAL POR E-MAIL");
        /*"01  WS-TXT-PROP-ELETRONICA-SMS        PIC  X(055) VALUE        'PROPOSTA ELETRONICA COM ASSINATURA DIGITAL POR SMS'.*/
        public StringBasis WS_TXT_PROP_ELETRONICA_SMS { get; set; } = new StringBasis(new PIC("X", "55", "X(055)"), @"PROPOSTA ELETRONICA COM ASSINATURA DIGITAL POR SMS");
        /*"01  WS-TXT-PROP-ELETRONICA-VOCAL      PIC  X(055) VALUE        'PROPOSTA ASSINADA POR GRAVACAO VOCAL'.*/
        public StringBasis WS_TXT_PROP_ELETRONICA_VOCAL { get; set; } = new StringBasis(new PIC("X", "55", "X(055)"), @"PROPOSTA ASSINADA POR GRAVACAO VOCAL");
        /*"01  WS-TXT-PROP-ELETRONICA-CHAT       PIC  X(055) VALUE        'PROPOSTA ELETRONICA COM ASSINATURA DIGITAL POR CHAT'.*/
        public StringBasis WS_TXT_PROP_ELETRONICA_CHAT { get; set; } = new StringBasis(new PIC("X", "55", "X(055)"), @"PROPOSTA ELETRONICA COM ASSINATURA DIGITAL POR CHAT");
        /*"01  WS-DIAS-PENDENTES                 PIC S9(009) COMP VALUE 0.*/
        public IntBasis WS_DIAS_PENDENTES { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  WS-DATA-TERVIGENCIA               PIC  X(010).*/
        public StringBasis WS_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WS-PREMIO-AP                      PIC  X(001) VALUE 'N'.*/

        public SelectorBasis WS_PREMIO_AP { get; set; } = new SelectorBasis("001", "N")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 WS-SIM-PREMIO-AP                VALUE 'S'. */
							new SelectorItemBasis("WS_SIM_PREMIO_AP", "S"),
							/*" 88 WS-NAO-PREMIO-AP                VALUE 'N'. */
							new SelectorItemBasis("WS_NAO_PREMIO_AP", "N")
                }
        };

        /*"01  WS-PCT-VG                         PIC S9(013)V99   COMP-3.*/
        public DoubleBasis WS_PCT_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  WS-SUBSCRICAO                     PIC  X(001) VALUE 'N'.*/

        public SelectorBasis WS_SUBSCRICAO { get; set; } = new SelectorBasis("001", "N")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 WS-TEM-MATRIZ                   VALUE 'S'. */
							new SelectorItemBasis("WS_TEM_MATRIZ", "S"),
							/*" 88 WS-PREENCHEU-DPS                VALUE 'N'. */
							new SelectorItemBasis("WS_PREENCHEU_DPS", "N")
                }
        };

        /*"01  WS-TXT-DESCONTO.*/
        public VA0601B_WS_TXT_DESCONTO WS_TXT_DESCONTO { get; set; } = new VA0601B_WS_TXT_DESCONTO();
        public class VA0601B_WS_TXT_DESCONTO : VarBasis
        {
            /*" 03 FILLER                            PIC  X(056) VALUE    'PROPOSTA ACEITA PELO CRITERIO DA MATRIZ COM DESCONTO DE '.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "56", "X(056)"), @"PROPOSTA ACEITA PELO CRITERIO DA MATRIZ COM DESCONTO DE ");
            /*" 03 WS-TXT-DESCONTO-PERC              PIC  ZZZB.*/
            public StringBasis WS_TXT_DESCONTO_PERC { get; set; } = new StringBasis(new PIC("X", "0", "ZZZB."), @"");
            /*" 03 FILLER                            PIC  X(001) VALUE '%'.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"%");
            /*"01  WS-TXT-AGRAVO.*/
        }
        public VA0601B_WS_TXT_AGRAVO WS_TXT_AGRAVO { get; set; } = new VA0601B_WS_TXT_AGRAVO();
        public class VA0601B_WS_TXT_AGRAVO : VarBasis
        {
            /*" 03 FILLER                            PIC  X(054) VALUE    'PROPOSTA ACEITA PELO CRITERIO DA MATRIZ COM AGRAVO DE '.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "54", "X(054)"), @"PROPOSTA ACEITA PELO CRITERIO DA MATRIZ COM AGRAVO DE ");
            /*" 03 WS-TXT-AGRAVO-PERC                PIC  ZZZB.*/
            public StringBasis WS_TXT_AGRAVO_PERC { get; set; } = new StringBasis(new PIC("X", "0", "ZZZB."), @"");
            /*" 03 FILLER                            PIC  X(001) VALUE '%'.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"%");
            /*"01  WS-TXT-CONTA-SALARIO              PIC  X(055) VALUE    'VENDA DEB. CTA SALARIO - ASSIST. CHECK-UP LAR EM DOBRO.'.*/
        }
        public StringBasis WS_TXT_CONTA_SALARIO { get; set; } = new StringBasis(new PIC("X", "55", "X(055)"), @"VENDA DEB. CTA SALARIO - ASSIST. CHECK-UP LAR EM DOBRO.");
        /*"01  VIND-NUM-CONTR                    PIC S9(004)      COMP.*/
        public IntBasis VIND_NUM_CONTR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-COD-CORRESP                  PIC S9(004)      COMP.*/
        public IntBasis VIND_COD_CORRESP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-NUM-PRAZO                    PIC S9(004)      COMP.*/
        public IntBasis VIND_NUM_PRAZO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-COD-OPER-CRED                PIC S9(004)      COMP.*/
        public IntBasis VIND_COD_OPER_CRED { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-STA-ANTECIPACAO              PIC S9(004)      COMP.*/
        public IntBasis VIND_STA_ANTECIPACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-DTFATUR                      PIC S9(004)      COMP.*/
        public IntBasis VIND_DTFATUR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-AGECTADEB                    PIC S9(004)      COMP.*/
        public IntBasis VIND_AGECTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-OPRCTADEB                    PIC S9(004)      COMP.*/
        public IntBasis VIND_OPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-NUMCTADEB                    PIC S9(004)      COMP.*/
        public IntBasis VIND_NUMCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-DIGCTADEB                    PIC S9(004)      COMP.*/
        public IntBasis VIND_DIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-CARTAO                       PIC S9(004)      COMP.*/
        public IntBasis VIND_CARTAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-IMPSEGAUXF                   PIC S9(004) VALUE +0 COMP.*/
        public IntBasis VIND_IMPSEGAUXF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-VLCUSTAUXF                   PIC S9(004) VALUE +0 COMP.*/
        public IntBasis VIND_VLCUSTAUXF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-PRMDIT                       PIC S9(004) VALUE +0 COMP.*/
        public IntBasis VIND_PRMDIT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-QTDIT                        PIC S9(004) VALUE +0 COMP.*/
        public IntBasis VIND_QTDIT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-DATA-EXPEDICAO               PIC S9(004) VALUE +0 COMP.*/
        public IntBasis VIND_DATA_EXPEDICAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-DATA-NASCIMENTO              PIC S9(004) VALUE +0 COMP.*/
        public IntBasis VIND_DATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-CGC-CONVENENTE               PIC S9(004)      COMP.*/
        public IntBasis VIND_CGC_CONVENENTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-NOME-CONJUGE                 PIC S9(004)      COMP.*/
        public IntBasis VIND_NOME_CONJUGE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-RENDA-FIXA-IND               PIC S9(004)      COMP.*/
        public IntBasis VIND_RENDA_FIXA_IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-RENDA-FIXA-FAM               PIC S9(004)      COMP.*/
        public IntBasis VIND_RENDA_FIXA_FAM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-TP-PROPOSTA                  PIC S9(004)      COMP.*/
        public IntBasis VIND_TP_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-TP-CONTA                     PIC S9(004)      COMP.*/
        public IntBasis VIND_TP_CONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-DATA-NASC-CONJUGE            PIC S9(004)      COMP.*/
        public IntBasis VIND_DATA_NASC_CONJUGE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-PROFISSAO-CONJUGE            PIC S9(004)      COMP.*/
        public IntBasis VIND_PROFISSAO_CONJUGE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-UF-EXPEDIDORA                PIC S9(004)      COMP.*/
        public IntBasis VIND_UF_EXPEDIDORA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-DATA-DECLINIO                PIC S9(004)      COMP.*/
        public IntBasis VIND_DATA_DECLINIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-RET-SUBSCRICAO               PIC S9(004)      COMP.*/
        public IntBasis VIND_RET_SUBSCRICAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-PCT-AGRAVO                   PIC S9(004)      COMP.*/
        public IntBasis VIND_PCT_AGRAVO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-VLR-PRM-SEM-AGR              PIC S9(004)      COMP.*/
        public IntBasis VIND_VLR_PRM_SEM_AGR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-COD-GRD-GRUPO-CBO            PIC S9(004)      COMP.*/
        public IntBasis VIND_COD_GRD_GRUPO_CBO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-COD-SUBGRUPO-CBO             PIC S9(004)      COMP.*/
        public IntBasis VIND_COD_SUBGRUPO_CBO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-COD-GRUPO-BASE-CBO           PIC S9(004)      COMP.*/
        public IntBasis VIND_COD_GRUPO_BASE_CBO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-COD-SUBGR-BASE-CBO           PIC S9(004)      COMP.*/
        public IntBasis VIND_COD_SUBGR_BASE_CBO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  APOLCOB-IMPSEGURADO           PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis APOLCOB_IMPSEGURADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"01  APOLCOB-DT-TERVIGENCIA        PIC X(10).*/
        public StringBasis APOLCOB_DT_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  WS-DT-TERVIGENCIA             PIC 9(08).*/
        public IntBasis WS_DT_TERVIGENCIA { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
        /*"01  WS-DT-MOVABERTO               PIC 9(08).*/
        public IntBasis WS_DT_MOVABERTO { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
        /*"77         VIND-NOME-RAZAO        PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_NOME_RAZAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-TIPO-PESSOA       PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_TIPO_PESSOA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-IDE-SEXO          PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_IDE_SEXO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-EST-CIVIL         PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_EST_CIVIL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-OCORR-END         PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_OCORR_END { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-ENDERECO          PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-BAIRRO            PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_BAIRRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-CIDADE            PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_CIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-SIGLA-UF          PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_SIGLA_UF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-CEP               PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_CEP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DDD               PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_DDD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-TELEFONE          PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_TELEFONE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-FAX               PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_FAX { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-CGCCPF            PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DTNASC            PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_DTNASC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-CODUSU            PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_CODUSU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-OCORR-END-I      PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis WHOST_OCORR_END_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-OCORR-END-F      PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis WHOST_OCORR_END_F { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WTEM-GECLIMOV                    PIC  X(001)  VALUE SPACES.*/
        public StringBasis WTEM_GECLIMOV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01  WS-PROD-BALCAO                   PIC  X(001)  VALUE ' '.*/
        public StringBasis WS_PROD_BALCAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
        /*"01  WS-SEG-LIBERADO                  PIC  X(001)  VALUE SPACES.*/
        public StringBasis WS_SEG_LIBERADO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01  WEXISTE-PRPVA                    PIC  X(003)  VALUE 'NAO'.*/
        public StringBasis WEXISTE_PRPVA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
        /*"01  WEXISTE-COMISSAO                 PIC  X(003)  VALUE 'NAO'.*/
        public StringBasis WEXISTE_COMISSAO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
        /*"01  WHOST-OPCAO-COBER                PIC  X(001).*/
        public StringBasis WHOST_OPCAO_COBER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  WHOST-IDADE                      PIC S9(004)        COMP.*/
        public IntBasis WHOST_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-IDADE-CONJUGE              PIC S9(004)        COMP.*/
        public IntBasis WHOST_IDADE_CONJUGE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  PRVG-CODPRODU                    PIC S9(004)        COMP.*/
        public IntBasis PRVG_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  PRVG-CODPRODU                    PIC S9(004)        COMP.*/
        public IntBasis PRVG_CODPRODU_0 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  PRVG-PERIPGTO                    PIC S9(004)        COMP.*/
        public IntBasis PRVG_PERIPGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  ESTIP-COD-CCT                    PIC S9(015)        COMP-3.*/
        public IntBasis ESTIP_COD_CCT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01  ESTIP-NOME                       PIC  X(040).*/
        public StringBasis ESTIP_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"01  WHOST-DDD                        PIC S9(004)        COMP.*/
        public IntBasis WHOST_DDD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-DDD-RESIDENCIAL            PIC S9(004)        COMP.*/
        public IntBasis WHOST_DDD_RESIDENCIAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-DDD-COMERCIAL              PIC S9(004)        COMP.*/
        public IntBasis WHOST_DDD_COMERCIAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-DDD-CELULAR                PIC S9(004)        COMP.*/
        public IntBasis WHOST_DDD_CELULAR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-DDD-FAX                    PIC S9(004)        COMP.*/
        public IntBasis WHOST_DDD_FAX { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-EMAIL                      PIC  X(040).*/
        public StringBasis WHOST_EMAIL { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"01  WHOST-FONE                       PIC S9(009)        COMP.*/
        public IntBasis WHOST_FONE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  WHOST-SEQ-RESIDENCIAL            PIC S9(009)        COMP.*/
        public IntBasis WHOST_SEQ_RESIDENCIAL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  WHOST-SEQ-COMERCIAL              PIC S9(009)        COMP.*/
        public IntBasis WHOST_SEQ_COMERCIAL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  WHOST-FONE-RESIDENCIAL           PIC S9(009)        COMP.*/
        public IntBasis WHOST_FONE_RESIDENCIAL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  WHOST-FONE-COMERCIAL             PIC S9(009)        COMP.*/
        public IntBasis WHOST_FONE_COMERCIAL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  WHOST-FONE-CELULAR               PIC S9(009)        COMP.*/
        public IntBasis WHOST_FONE_CELULAR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  WHOST-FONE-FAX                   PIC S9(009)        COMP.*/
        public IntBasis WHOST_FONE_FAX { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  WHOST-FAX                        PIC S9(009)        COMP.*/
        public IntBasis WHOST_FAX { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  WHOST-TELEX                      PIC S9(009)        COMP.*/
        public IntBasis WHOST_TELEX { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  VGPLAR-NUM-RAMO                  PIC S9(04)    COMP.*/
        public IntBasis VGPLAR_NUM_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VGPLAR-NUM-COBERTURA             PIC S9(04)    COMP.*/
        public IntBasis VGPLAR_NUM_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VGPLAR-QTD-COBERTURA             PIC S9(04)    COMP.*/
        public IntBasis VGPLAR_QTD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VGPLAR-IMPSEGURADA               PIC S9(13)V99 COMP-3.*/
        public DoubleBasis VGPLAR_IMPSEGURADA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  VGPLAR-CUSTO                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis VGPLAR_CUSTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  VGPLAR-PREMIO                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis VGPLAR_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  VGPLAR-TAXA                      PIC S9(03)V9999 COMP-3.*/
        public DoubleBasis VGPLAR_TAXA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9999"), 4);
        /*"01  VGPLAA-NUM-ACESSORIO             PIC S9(04)    COMP.*/
        public IntBasis VGPLAA_NUM_ACESSORIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VGPLAA-QTD-COBERTURA             PIC S9(04)    COMP.*/
        public IntBasis VGPLAA_QTD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VGPLAA-IMPSEGURADA               PIC S9(13)V99 COMP-3.*/
        public DoubleBasis VGPLAA_IMPSEGURADA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  VGPLAA-CUSTO                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis VGPLAA_CUSTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  VGPLAA-PREMIO                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis VGPLAA_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  VGPLAA-TAXA                      PIC S9(03)V9999 COMP-3.*/
        public DoubleBasis VGPLAA_TAXA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9999"), 4);
        /*"01  WS-CONSULTA-PU.*/
        public VA0601B_WS_CONSULTA_PU WS_CONSULTA_PU { get; set; } = new VA0601B_WS_CONSULTA_PU();
        public class VA0601B_WS_CONSULTA_PU : VarBasis
        {
            /*"    05 WS-CLIENTES-COD-CLIENTE       PIC S9(09)  USAGE COMP.*/
            public IntBasis WS_CLIENTES_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"    05 WS-CLIENTES-DATA-NASCIMENTO   PIC  X(10)  VALUE SPACES.*/
            public StringBasis WS_CLIENTES_DATA_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    05 WS-PROPOVA-NUM-CERTIFICADO    PIC S9(15)V USAGE COMP-3.*/
            public DoubleBasis WS_PROPOVA_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
            /*"    05 WS-PROPOVA-COD-PRODUTO        PIC S9(04)  USAGE COMP.*/
            public IntBasis WS_PROPOVA_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 WS-SEGURVGA-NUM-APOLICE       PIC S9(13)V USAGE COMP-3.*/
            public DoubleBasis WS_SEGURVGA_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
            /*"    05 WS-SEGURVGA-COD-SUBGRUPO      PIC S9(04)  USAGE COMP.*/
            public IntBasis WS_SEGURVGA_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 WS-SEGURVGA-NUM-ITEM          PIC S9(09)  USAGE COMP.*/
            public IntBasis WS_SEGURVGA_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"    05 WS-APOLICOB-DATA-TERVIGENCIA  PIC  X(10)  VALUE SPACES.*/
            public StringBasis WS_APOLICOB_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    05 WS-QTD-MESES                  PIC S9(03)V9(04)  COMP-3.*/
            public DoubleBasis WS_QTD_MESES { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(04)"), 4);
            /*"    05 WS-FIM-CLIENTEPU              PIC  X(01)  VALUE 'N'.*/
            public StringBasis WS_FIM_CLIENTEPU { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"N");
            /*"    05 WS-FIM-PRODUTOPU              PIC  X(01)  VALUE 'N'.*/
            public StringBasis WS_FIM_PRODUTOPU { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"N");
            /*"    05 WS-ACHOU-PU                   PIC  X(01)  VALUE 'N'.*/
            public StringBasis WS_ACHOU_PU { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"N");
            /*"    05 WS-ACHOU-NUM-ITEM             PIC  X(01)  VALUE 'N'.*/
            public StringBasis WS_ACHOU_NUM_ITEM { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"N");
            /*"    05 WS-IND-DT-NASC                PIC S9(004)       COMP.*/
            public IntBasis WS_IND_DT_NASC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  LPARM01                     PIC  9(007).*/
        }
        public IntBasis LPARM01 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
        /*"01  LPARM01-R                   REDEFINES   LPARM01.*/
        private _REDEF_VA0601B_LPARM01_R _lparm01_r { get; set; }
        public _REDEF_VA0601B_LPARM01_R LPARM01_R
        {
            get { _lparm01_r = new _REDEF_VA0601B_LPARM01_R(); _.Move(LPARM01, _lparm01_r); VarBasis.RedefinePassValue(LPARM01, _lparm01_r, LPARM01); _lparm01_r.ValueChanged += () => { _.Move(_lparm01_r, LPARM01); }; return _lparm01_r; }
            set { VarBasis.RedefinePassValue(value, _lparm01_r, LPARM01); }
        }  //Redefines
        public class _REDEF_VA0601B_LPARM01_R : VarBasis
        {
            /*"    05          LPARM01-1       PIC  9(001).*/
            public IntBasis LPARM01_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05          LPARM01-2       PIC  9(001).*/
            public IntBasis LPARM01_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05          LPARM01-3       PIC  9(001).*/
            public IntBasis LPARM01_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05          LPARM01-4       PIC  9(001).*/
            public IntBasis LPARM01_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05          LPARM01-5       PIC  9(001).*/
            public IntBasis LPARM01_5 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05          LPARM01-6       PIC  9(001).*/
            public IntBasis LPARM01_6 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"01              LPARM03         PIC  9(001).*/

            public _REDEF_VA0601B_LPARM01_R()
            {
                LPARM01_1.ValueChanged += OnValueChanged;
                LPARM01_2.ValueChanged += OnValueChanged;
                LPARM01_3.ValueChanged += OnValueChanged;
                LPARM01_4.ValueChanged += OnValueChanged;
                LPARM01_5.ValueChanged += OnValueChanged;
                LPARM01_6.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis LPARM03 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
        /*"01              LPARM03-R       REDEFINES   LPARM03                                PIC  X(001).*/
        private _REDEF_StringBasis _lparm03_r { get; set; }
        public _REDEF_StringBasis LPARM03_R
        {
            get { _lparm03_r = new _REDEF_StringBasis(new PIC("X", "001", "X(001).")); ; _.Move(LPARM03, _lparm03_r); VarBasis.RedefinePassValue(LPARM03, _lparm03_r, LPARM03); _lparm03_r.ValueChanged += () => { _.Move(_lparm03_r, LPARM03); }; return _lparm03_r; }
            set { VarBasis.RedefinePassValue(value, _lparm03_r, LPARM03); }
        }  //Redefines
        /*"01  W-NUM-CARTAO-CREDITO        PIC  9(016)  VALUE ZEROS.*/
        public IntBasis W_NUM_CARTAO_CREDITO { get; set; } = new IntBasis(new PIC("9", "16", "9(016)"));
        /*"01  W-NRMATRICULA               PIC  9(007)  VALUE ZEROS.*/
        public IntBasis W_NRMATRICULA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"01  FILLER                      REDEFINES   W-NRMATRICULA.*/
        private _REDEF_VA0601B_FILLER_5 _filler_5 { get; set; }
        public _REDEF_VA0601B_FILLER_5 FILLER_5
        {
            get { _filler_5 = new _REDEF_VA0601B_FILLER_5(); _.Move(W_NRMATRICULA, _filler_5); VarBasis.RedefinePassValue(W_NRMATRICULA, _filler_5, W_NRMATRICULA); _filler_5.ValueChanged += () => { _.Move(_filler_5, W_NRMATRICULA); }; return _filler_5; }
            set { VarBasis.RedefinePassValue(value, _filler_5, W_NRMATRICULA); }
        }  //Redefines
        public class _REDEF_VA0601B_FILLER_5 : VarBasis
        {
            /*"    05          W-NRMATRICULA1  PIC  9(006).*/
            public IntBasis W_NRMATRICULA1 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05          W-DV-MATRICULA  PIC  9(001).*/
            public IntBasis W_DV_MATRICULA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"01  WS-I-ERRO                   PIC  9(003) VALUE ZEROS.*/

            public _REDEF_VA0601B_FILLER_5()
            {
                W_NRMATRICULA1.ValueChanged += OnValueChanged;
                W_DV_MATRICULA.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis WS_I_ERRO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"01  WS-FLAG-TEM-ERRO            PIC  X(001) VALUE 'N'.*/
        public StringBasis WS_FLAG_TEM_ERRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"01  WORK-TAB-ERROS-CERT.*/
        public VA0601B_WORK_TAB_ERROS_CERT WORK_TAB_ERROS_CERT { get; set; } = new VA0601B_WORK_TAB_ERROS_CERT();
        public class VA0601B_WORK_TAB_ERROS_CERT : VarBasis
        {
            /*"    05  WS-TAB-ERROS-CERT   OCCURS 100 TIMES.*/
            public ListBasis<VA0601B_WS_TAB_ERROS_CERT> WS_TAB_ERROS_CERT { get; set; } = new ListBasis<VA0601B_WS_TAB_ERROS_CERT>(100);
            public class VA0601B_WS_TAB_ERROS_CERT : VarBasis
            {
                /*"      10  TB-ERRO-CERT          PIC S9(004) COMP VALUE 0.*/
                public IntBasis TB_ERRO_CERT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"01  WORK-TAB-RAMO-CONJ.*/
            }
        }
        public VA0601B_WORK_TAB_RAMO_CONJ WORK_TAB_RAMO_CONJ { get; set; } = new VA0601B_WORK_TAB_RAMO_CONJ();
        public class VA0601B_WORK_TAB_RAMO_CONJ : VarBasis
        {
            /*"    05  N5WORK-TAB-RAMO-CONJ    OCCURS 30 TIMES.*/
            public ListBasis<VA0601B_N5WORK_TAB_RAMO_CONJ> N5WORK_TAB_RAMO_CONJ { get; set; } = new ListBasis<VA0601B_N5WORK_TAB_RAMO_CONJ>(30);
            public class VA0601B_N5WORK_TAB_RAMO_CONJ : VarBasis
            {
                /*"      10  TB-GRUPO-SUSEP              PIC S9(004) COMP.*/
                public IntBasis TB_GRUPO_SUSEP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"      10  TB-RAMO-CONJ                PIC S9(004) COMP.*/
                public IntBasis TB_RAMO_CONJ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"      10  TB-TAXA-RAMO-CONJ           PIC S9(003)V9(4) COMP-3.*/
                public DoubleBasis TB_TAXA_RAMO_CONJ { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
                /*"01  WORK-RAMO-CONJ.*/
            }
        }
        public VA0601B_WORK_RAMO_CONJ WORK_RAMO_CONJ { get; set; } = new VA0601B_WORK_RAMO_CONJ();
        public class VA0601B_WORK_RAMO_CONJ : VarBasis
        {
            /*"    05  WS-GRUPO-SUSEP-ANT            PIC S9(004) COMP.*/
            public IntBasis WS_GRUPO_SUSEP_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05  WS-RAMO-CONJ-ANT              PIC S9(004) COMP.*/
            public IntBasis WS_RAMO_CONJ_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05  WS-IND                        PIC S9(004) COMP.*/
            public IntBasis WS_IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05  WS-IND1                       PIC S9(004) COMP.*/
            public IntBasis WS_IND1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05  WHOST-VLR-PERC-PREMIO         PIC S9(003)V9(04) COMP-3.*/
            public DoubleBasis WHOST_VLR_PERC_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(04)"), 4);
            /*"    05  WHOST-VLR-PERC-PREMIO-TOT     PIC S9(003)V9(04) COMP-3.*/
            public DoubleBasis WHOST_VLR_PERC_PREMIO_TOT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(04)"), 4);
            /*"    05  WS-SALVA                      PIC  X(020).*/
            public StringBasis WS_SALVA { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"01  WORK-AREA.*/
        }
        public VA0601B_WORK_AREA WORK_AREA { get; set; } = new VA0601B_WORK_AREA();
        public class VA0601B_WORK_AREA : VarBasis
        {
            /*"    05  W-NUM-PROPOSTA                PIC 9(014).*/
            public IntBasis W_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    05  FAIXAS  REDEFINES W-NUM-PROPOSTA.*/
            private _REDEF_VA0601B_FAIXAS _faixas { get; set; }
            public _REDEF_VA0601B_FAIXAS FAIXAS
            {
                get { _faixas = new _REDEF_VA0601B_FAIXAS(); _.Move(W_NUM_PROPOSTA, _faixas); VarBasis.RedefinePassValue(W_NUM_PROPOSTA, _faixas, W_NUM_PROPOSTA); _faixas.ValueChanged += () => { _.Move(_faixas, W_NUM_PROPOSTA); }; return _faixas; }
                set { VarBasis.RedefinePassValue(value, _faixas, W_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_VA0601B_FAIXAS : VarBasis
            {
                /*"        07  FILLER                    PIC 9(003).*/
                public IntBasis FILLER_6 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"        07  FAIXA-NUMERACAO           PIC 9(003).*/

                public SelectorBasis FAIXA_NUMERACAO { get; set; } = new SelectorBasis("003")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88 FAIXA-NUMERACAO-MULT       VALUE               848, 850, 845, 846. */
							new SelectorItemBasis("FAIXA_NUMERACAO_MULT", "848,850,845,846"),
							/*" 88 FAIXA-NUMERACAO-BILHETE    VALUE               823, 824, 826, 827, 829, 837, 850, 845, 846. */
							new SelectorItemBasis("FAIXA_NUMERACAO_BILHETE", "823,824,826,827,829,837,850,845,846"),
							/*" 88 FAIXA-NUMERACAO-SENIOR     VALUE               821, 850, 845, 846. */
							new SelectorItemBasis("FAIXA_NUMERACAO_SENIOR", "821,850,845,846"),
							/*" 88 FAIXA-NUMERACAO-EXECUTIVO  VALUE               821, 850, 845, 846. */
							new SelectorItemBasis("FAIXA_NUMERACAO_EXECUTIVO", "821,850,845,846"),
							/*" 88 FAIXA-NUMERACAO-AUTO       VALUE               828, 837, 847, 845, 846. */
							new SelectorItemBasis("FAIXA_NUMERACAO_AUTO", "828,837,847,845,846")
                }
                };

                /*"        07  W-FILLER                  PIC 9(008).*/
                public IntBasis W_FILLER { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    05  CANAL  REDEFINES W-NUM-PROPOSTA.*/

                public _REDEF_VA0601B_FAIXAS()
                {
                    FILLER_6.ValueChanged += OnValueChanged;
                    FAIXA_NUMERACAO.ValueChanged += OnValueChanged;
                    W_FILLER.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_VA0601B_CANAL _canal { get; set; }
            public _REDEF_VA0601B_CANAL CANAL
            {
                get { _canal = new _REDEF_VA0601B_CANAL(); _.Move(W_NUM_PROPOSTA, _canal); VarBasis.RedefinePassValue(W_NUM_PROPOSTA, _canal, W_NUM_PROPOSTA); _canal.ValueChanged += () => { _.Move(_canal, W_NUM_PROPOSTA); }; return _canal; }
                set { VarBasis.RedefinePassValue(value, _canal, W_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_VA0601B_CANAL : VarBasis
            {
                /*"        07  W-CANAL-PROPOSTA          PIC 9(001).*/

                public SelectorBasis W_CANAL_PROPOSTA { get; set; } = new SelectorBasis("001")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88 CANAL-VENDA-PAPEL                    VALUE 0. */
							new SelectorItemBasis("CANAL_VENDA_PAPEL", "0"),
							/*" 88 CANAL-VENDA-CEF                      VALUE 1. */
							new SelectorItemBasis("CANAL_VENDA_CEF", "1"),
							/*" 88 CANAL-SASSE-FILIAL                   VALUE 2. */
							new SelectorItemBasis("CANAL_SASSE_FILIAL", "2"),
							/*" 88 CANAL-CORRETOR                       VALUE 3. */
							new SelectorItemBasis("CANAL_CORRETOR", "3"),
							/*" 88 CANAL-CORREIO                        VALUE 4. */
							new SelectorItemBasis("CANAL_CORREIO", "4"),
							/*" 88 CANAL-GITEL                          VALUE 5. */
							new SelectorItemBasis("CANAL_GITEL", "5"),
							/*" 88 CANAL-INTERNET                       VALUE 7. */
							new SelectorItemBasis("CANAL_INTERNET", "7"),
							/*" 88 CANAL-VENDA-AIC                      VALUE 8. */
							new SelectorItemBasis("CANAL_VENDA_AIC", "8")
                }
                };

                /*"        07  FILLER                    PIC 9(013).*/
                public IntBasis FILLER_7 { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    05  W-ENDERECO                    PIC 9(001).*/

                public _REDEF_VA0601B_CANAL()
                {
                    W_CANAL_PROPOSTA.ValueChanged += OnValueChanged;
                    FILLER_7.ValueChanged += OnValueChanged;
                }

            }

            public SelectorBasis W_ENDERECO { get; set; } = new SelectorBasis("001")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 END-CORRES-CADASTRADO          VALUE 01. */
							new SelectorItemBasis("END_CORRES_CADASTRADO", "01"),
							/*" 88 END-CORRES-N-CADASTRADO        VALUE 02. */
							new SelectorItemBasis("END_CORRES_N_CADASTRADO", "02"),
							/*" 88 DEMAIS-END-CADASTRADO          VALUE 03. */
							new SelectorItemBasis("DEMAIS_END_CADASTRADO", "03"),
							/*" 88 DEMAIS-END-N-CADASTRADO        VALUE 04. */
							new SelectorItemBasis("DEMAIS_END_N_CADASTRADO", "04")
                }
            };

            /*"    05  W-RCAPS                       PIC 9(002).*/

            public SelectorBasis W_RCAPS { get; set; } = new SelectorBasis("002")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 RCAP-CADASTRADO                          VALUE 01. */
							new SelectorItemBasis("RCAP_CADASTRADO", "01")
                }
            };

            /*"    05  W-PLANO                       PIC 9(002).*/

            public SelectorBasis W_PLANO { get; set; } = new SelectorBasis("002")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 EXISTE-PLANO                             VALUE 01. */
							new SelectorItemBasis("EXISTE_PLANO", "01")
                }
            };

            /*"    05  W-COBRANCA                    PIC 9(002).*/

            public SelectorBasis W_COBRANCA { get; set; } = new SelectorBasis("002")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 COBRANCA-EMITIDA                         VALUE 01. */
							new SelectorItemBasis("COBRANCA_EMITIDA", "01")
                }
            };

            /*"    05  W-ORIGEM-PROPOSTA             PIC 9(004).*/

            public SelectorBasis W_ORIGEM_PROPOSTA { get; set; } = new SelectorBasis("004")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 ORIGEM-SIGPF                             VALUE 01. */
							new SelectorItemBasis("ORIGEM_SIGPF", "01"),
							/*" 88 ORIGEM-CAIXA-PREV                        VALUE 02. */
							new SelectorItemBasis("ORIGEM_CAIXA_PREV", "02"),
							/*" 88 ORIGEM-SIGAT                             VALUE 03. */
							new SelectorItemBasis("ORIGEM_SIGAT", "03"),
							/*" 88 ORIGEM-SASSE                             VALUE 04. */
							new SelectorItemBasis("ORIGEM_SASSE", "04"),
							/*" 88 ORIGEM-CAIXA-CAP                         VALUE 05. */
							new SelectorItemBasis("ORIGEM_CAIXA_CAP", "05"),
							/*" 88 ORIGEM-SIFEC                             VALUE 06. */
							new SelectorItemBasis("ORIGEM_SIFEC", "06"),
							/*" 88 ORIGEM-REMOTA                            VALUE 07. */
							new SelectorItemBasis("ORIGEM_REMOTA", "07"),
							/*" 88 ORIGEM-REMOTA-FILIAL                     VALUE 08. */
							new SelectorItemBasis("ORIGEM_REMOTA_FILIAL", "08"),
							/*" 88 ORIGEM-MANUAL                            VALUE 09. */
							new SelectorItemBasis("ORIGEM_MANUAL", "09"),
							/*" 88 ORIGEM-AUTO-COMPRA-IBC                   VALUE 1009. */
							new SelectorItemBasis("ORIGEM_AUTO_COMPRA_IBC", "1009"),
							/*" 88 ORIGEM-AUTO-COMPRA-LOJA                  VALUE 1010. */
							new SelectorItemBasis("ORIGEM_AUTO_COMPRA_LOJA", "1010"),
							/*" 88 VENDA-CAMPANHA                           VALUE 1018. */
							new SelectorItemBasis("VENDA_CAMPANHA", "1018"),
							/*" 88 VENDA-PARCERIA                           VALUE 1021                                                     THRU 1025. */
							new SelectorItemBasis("VENDA_PARCERIA", "1021 THRU 1025"),
							/*" 88 VENDA-ALGAR                              VALUE 1021. */
							new SelectorItemBasis("VENDA_ALGAR", "1021"),
							/*" 88 VENDA-WIZ                                VALUE 1022. */
							new SelectorItemBasis("VENDA_WIZ", "1022"),
							/*" 88 VENDA-ALMA-VIVA                          VALUE 1023. */
							new SelectorItemBasis("VENDA_ALMA_VIVA", "1023"),
							/*" 88 VENDA-AEC                                VALUE 1024. */
							new SelectorItemBasis("VENDA_AEC", "1024"),
							/*" 88 VENDA-SERCOM                             VALUE 1025. */
							new SelectorItemBasis("VENDA_SERCOM", "1025")
                }
            };

            /*"    05  W-TRATA-CLIENTE               PIC 9(002).*/

            public SelectorBasis W_TRATA_CLIENTE { get; set; } = new SelectorBasis("002")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 CLIENTE-INSERIDO                         VALUE 01. */
							new SelectorItemBasis("CLIENTE_INSERIDO", "01"),
							/*" 88 CLIENTE-ERRO                             VALUE 02. */
							new SelectorItemBasis("CLIENTE_ERRO", "02")
                }
            };

            /*"    05  WS-TRATA-NOME                PIC X(040).*/
            public StringBasis WS_TRATA_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    05  WS-TRATA-NOM REDEFINES WS-TRATA-NOME.*/
            private _REDEF_VA0601B_WS_TRATA_NOM _ws_trata_nom { get; set; }
            public _REDEF_VA0601B_WS_TRATA_NOM WS_TRATA_NOM
            {
                get { _ws_trata_nom = new _REDEF_VA0601B_WS_TRATA_NOM(); _.Move(WS_TRATA_NOME, _ws_trata_nom); VarBasis.RedefinePassValue(WS_TRATA_NOME, _ws_trata_nom, WS_TRATA_NOME); _ws_trata_nom.ValueChanged += () => { _.Move(_ws_trata_nom, WS_TRATA_NOME); }; return _ws_trata_nom; }
                set { VarBasis.RedefinePassValue(value, _ws_trata_nom, WS_TRATA_NOME); }
            }  //Redefines
            public class _REDEF_VA0601B_WS_TRATA_NOM : VarBasis
            {
                /*"       10 WS-NOM-1A-POSICAO          PIC X(001).*/
                public StringBasis WS_NOM_1A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-NOM-2A-POSICAO          PIC X(001).*/
                public StringBasis WS_NOM_2A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-NOM-3A-POSICAO          PIC X(001).*/
                public StringBasis WS_NOM_3A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-NOM-4A-POSICAO          PIC X(001).*/
                public StringBasis WS_NOM_4A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-NOM-5A-POSICAO          PIC X(001).*/
                public StringBasis WS_NOM_5A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-NOM-6A-POSICAO          PIC X(001).*/
                public StringBasis WS_NOM_6A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-NOM-7A-POSICAO          PIC X(001).*/
                public StringBasis WS_NOM_7A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-NOM-8A-POSICAO          PIC X(001).*/
                public StringBasis WS_NOM_8A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-NOM-9A-POSICAO          PIC X(001).*/
                public StringBasis WS_NOM_9A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 FILLER                     PIC X(031).*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "31", "X(031)."), @"");
                /*"    05  WS-TRATA-ENDERECO            PIC X(040).*/

                public _REDEF_VA0601B_WS_TRATA_NOM()
                {
                    WS_NOM_1A_POSICAO.ValueChanged += OnValueChanged;
                    WS_NOM_2A_POSICAO.ValueChanged += OnValueChanged;
                    WS_NOM_3A_POSICAO.ValueChanged += OnValueChanged;
                    WS_NOM_4A_POSICAO.ValueChanged += OnValueChanged;
                    WS_NOM_5A_POSICAO.ValueChanged += OnValueChanged;
                    WS_NOM_6A_POSICAO.ValueChanged += OnValueChanged;
                    WS_NOM_7A_POSICAO.ValueChanged += OnValueChanged;
                    WS_NOM_8A_POSICAO.ValueChanged += OnValueChanged;
                    WS_NOM_9A_POSICAO.ValueChanged += OnValueChanged;
                    FILLER_8.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_TRATA_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    05  WS-TRATA-END REDEFINES WS-TRATA-ENDERECO.*/
            private _REDEF_VA0601B_WS_TRATA_END _ws_trata_end { get; set; }
            public _REDEF_VA0601B_WS_TRATA_END WS_TRATA_END
            {
                get { _ws_trata_end = new _REDEF_VA0601B_WS_TRATA_END(); _.Move(WS_TRATA_ENDERECO, _ws_trata_end); VarBasis.RedefinePassValue(WS_TRATA_ENDERECO, _ws_trata_end, WS_TRATA_ENDERECO); _ws_trata_end.ValueChanged += () => { _.Move(_ws_trata_end, WS_TRATA_ENDERECO); }; return _ws_trata_end; }
                set { VarBasis.RedefinePassValue(value, _ws_trata_end, WS_TRATA_ENDERECO); }
            }  //Redefines
            public class _REDEF_VA0601B_WS_TRATA_END : VarBasis
            {
                /*"       10 WS-END-1A-POSICAO          PIC X(001).*/
                public StringBasis WS_END_1A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-END-2A-POSICAO          PIC X(001).*/
                public StringBasis WS_END_2A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-END-3A-POSICAO          PIC X(001).*/
                public StringBasis WS_END_3A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-END-4A-POSICAO          PIC X(001).*/
                public StringBasis WS_END_4A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-END-5A-POSICAO          PIC X(001).*/
                public StringBasis WS_END_5A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-END-6A-POSICAO          PIC X(001).*/
                public StringBasis WS_END_6A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-END-7A-POSICAO          PIC X(001).*/
                public StringBasis WS_END_7A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-END-8A-POSICAO          PIC X(001).*/
                public StringBasis WS_END_8A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-END-9A-POSICAO          PIC X(001).*/
                public StringBasis WS_END_9A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 FILLER                     PIC X(031).*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "31", "X(031)."), @"");
                /*"    05  WS-TRATA-BAIRRO              PIC X(020).*/

                public _REDEF_VA0601B_WS_TRATA_END()
                {
                    WS_END_1A_POSICAO.ValueChanged += OnValueChanged;
                    WS_END_2A_POSICAO.ValueChanged += OnValueChanged;
                    WS_END_3A_POSICAO.ValueChanged += OnValueChanged;
                    WS_END_4A_POSICAO.ValueChanged += OnValueChanged;
                    WS_END_5A_POSICAO.ValueChanged += OnValueChanged;
                    WS_END_6A_POSICAO.ValueChanged += OnValueChanged;
                    WS_END_7A_POSICAO.ValueChanged += OnValueChanged;
                    WS_END_8A_POSICAO.ValueChanged += OnValueChanged;
                    WS_END_9A_POSICAO.ValueChanged += OnValueChanged;
                    FILLER_9.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_TRATA_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"    05  WS-TRATA-BAI REDEFINES WS-TRATA-BAIRRO.*/
            private _REDEF_VA0601B_WS_TRATA_BAI _ws_trata_bai { get; set; }
            public _REDEF_VA0601B_WS_TRATA_BAI WS_TRATA_BAI
            {
                get { _ws_trata_bai = new _REDEF_VA0601B_WS_TRATA_BAI(); _.Move(WS_TRATA_BAIRRO, _ws_trata_bai); VarBasis.RedefinePassValue(WS_TRATA_BAIRRO, _ws_trata_bai, WS_TRATA_BAIRRO); _ws_trata_bai.ValueChanged += () => { _.Move(_ws_trata_bai, WS_TRATA_BAIRRO); }; return _ws_trata_bai; }
                set { VarBasis.RedefinePassValue(value, _ws_trata_bai, WS_TRATA_BAIRRO); }
            }  //Redefines
            public class _REDEF_VA0601B_WS_TRATA_BAI : VarBasis
            {
                /*"       10 WS-BAI-1A-POSICAO          PIC X(001).*/
                public StringBasis WS_BAI_1A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-BAI-2A-POSICAO          PIC X(001).*/
                public StringBasis WS_BAI_2A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-BAI-3A-POSICAO          PIC X(001).*/
                public StringBasis WS_BAI_3A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-BAI-4A-POSICAO          PIC X(001).*/
                public StringBasis WS_BAI_4A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-BAI-5A-POSICAO          PIC X(001).*/
                public StringBasis WS_BAI_5A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-BAI-6A-POSICAO          PIC X(001).*/
                public StringBasis WS_BAI_6A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-BAI-7A-POSICAO          PIC X(001).*/
                public StringBasis WS_BAI_7A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-BAI-8A-POSICAO          PIC X(001).*/
                public StringBasis WS_BAI_8A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-BAI-9A-POSICAO          PIC X(001).*/
                public StringBasis WS_BAI_9A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 FILLER                     PIC X(011).*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)."), @"");
                /*"    05  WS-TRATA-CIDADE              PIC X(020).*/

                public _REDEF_VA0601B_WS_TRATA_BAI()
                {
                    WS_BAI_1A_POSICAO.ValueChanged += OnValueChanged;
                    WS_BAI_2A_POSICAO.ValueChanged += OnValueChanged;
                    WS_BAI_3A_POSICAO.ValueChanged += OnValueChanged;
                    WS_BAI_4A_POSICAO.ValueChanged += OnValueChanged;
                    WS_BAI_5A_POSICAO.ValueChanged += OnValueChanged;
                    WS_BAI_6A_POSICAO.ValueChanged += OnValueChanged;
                    WS_BAI_7A_POSICAO.ValueChanged += OnValueChanged;
                    WS_BAI_8A_POSICAO.ValueChanged += OnValueChanged;
                    WS_BAI_9A_POSICAO.ValueChanged += OnValueChanged;
                    FILLER_10.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_TRATA_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"    05  WS-TRATA-CID REDEFINES WS-TRATA-CIDADE.*/
            private _REDEF_VA0601B_WS_TRATA_CID _ws_trata_cid { get; set; }
            public _REDEF_VA0601B_WS_TRATA_CID WS_TRATA_CID
            {
                get { _ws_trata_cid = new _REDEF_VA0601B_WS_TRATA_CID(); _.Move(WS_TRATA_CIDADE, _ws_trata_cid); VarBasis.RedefinePassValue(WS_TRATA_CIDADE, _ws_trata_cid, WS_TRATA_CIDADE); _ws_trata_cid.ValueChanged += () => { _.Move(_ws_trata_cid, WS_TRATA_CIDADE); }; return _ws_trata_cid; }
                set { VarBasis.RedefinePassValue(value, _ws_trata_cid, WS_TRATA_CIDADE); }
            }  //Redefines
            public class _REDEF_VA0601B_WS_TRATA_CID : VarBasis
            {
                /*"       10 WS-CID-1A-POSICAO          PIC X(001).*/
                public StringBasis WS_CID_1A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-CID-2A-POSICAO          PIC X(001).*/
                public StringBasis WS_CID_2A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-CID-3A-POSICAO          PIC X(001).*/
                public StringBasis WS_CID_3A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-CID-4A-POSICAO          PIC X(001).*/
                public StringBasis WS_CID_4A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-CID-5A-POSICAO          PIC X(001).*/
                public StringBasis WS_CID_5A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-CID-6A-POSICAO          PIC X(001).*/
                public StringBasis WS_CID_6A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-CID-7A-POSICAO          PIC X(001).*/
                public StringBasis WS_CID_7A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-CID-8A-POSICAO          PIC X(001).*/
                public StringBasis WS_CID_8A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-CID-9A-POSICAO          PIC X(001).*/
                public StringBasis WS_CID_9A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 FILLER                     PIC X(011).*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)."), @"");
                /*"    05 WS-CHAVE-ATU VALUE ZEROS.*/

                public _REDEF_VA0601B_WS_TRATA_CID()
                {
                    WS_CID_1A_POSICAO.ValueChanged += OnValueChanged;
                    WS_CID_2A_POSICAO.ValueChanged += OnValueChanged;
                    WS_CID_3A_POSICAO.ValueChanged += OnValueChanged;
                    WS_CID_4A_POSICAO.ValueChanged += OnValueChanged;
                    WS_CID_5A_POSICAO.ValueChanged += OnValueChanged;
                    WS_CID_6A_POSICAO.ValueChanged += OnValueChanged;
                    WS_CID_7A_POSICAO.ValueChanged += OnValueChanged;
                    WS_CID_8A_POSICAO.ValueChanged += OnValueChanged;
                    WS_CID_9A_POSICAO.ValueChanged += OnValueChanged;
                    FILLER_11.ValueChanged += OnValueChanged;
                }

            }
            public VA0601B_WS_CHAVE_ATU WS_CHAVE_ATU { get; set; } = new VA0601B_WS_CHAVE_ATU();
            public class VA0601B_WS_CHAVE_ATU : VarBasis
            {
                /*"       10 WS-ATU-APOLICE             PIC  9(013).*/
                public IntBasis WS_ATU_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"       10 WS-ATU-SUBGRUPO            PIC  9(005).*/
                public IntBasis WS_ATU_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    05 WS-CHAVE-ANT VALUE ZEROS.*/
            }
            public VA0601B_WS_CHAVE_ANT WS_CHAVE_ANT { get; set; } = new VA0601B_WS_CHAVE_ANT();
            public class VA0601B_WS_CHAVE_ANT : VarBasis
            {
                /*"       10 WS-ANT-APOLICE             PIC  9(013).*/
                public IntBasis WS_ANT_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"       10 WS-ANT-SUBGRUPO            PIC  9(005).*/
                public IntBasis WS_ANT_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    05 WS-LIM-CALCULADO              PIC S9(013)V99 COMP-3.*/
            }
            public DoubleBasis WS_LIM_CALCULADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 WS-VLPREMIOTOT-CCT            PIC S9(013)V99 COMP-3.*/
            public DoubleBasis WS_VLPREMIOTOT_CCT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 WS-JA-E-CLIENTE               PIC  9(001) VALUE 0.*/
            public IntBasis WS_JA_E_CLIENTE { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05 WS-JA-E-CLIENTE-EMP           PIC  9(001) VALUE 0.*/
            public IntBasis WS_JA_E_CLIENTE_EMP { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05 WS-EOR                        PIC  9(001) VALUE 0.*/
            public IntBasis WS_EOR { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05 WS-TEM-ERRO-ASS               PIC  9(001) VALUE 0.*/
            public IntBasis WS_TEM_ERRO_ASS { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05 WS-TEM-ERRO                   PIC  9(001) VALUE 0.*/
            public IntBasis WS_TEM_ERRO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05 WS-TEM-ERRO-1855              PIC  X(003) VALUE 'NAO'.*/
            public StringBasis WS_TEM_ERRO_1855 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05 WS-TEM-ERRO-1807              PIC  X(003) VALUE 'NAO'.*/
            public StringBasis WS_TEM_ERRO_1807 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05 WS-TEM-ERRO-1852              PIC  X(003) VALUE 'NAO'.*/
            public StringBasis WS_TEM_ERRO_1852 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05 WS-TEM-ERRO-1893              PIC  X(003) VALUE 'NAO'.*/
            public StringBasis WS_TEM_ERRO_1893 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05 WS-TEM-ERRO-1894              PIC  X(003) VALUE 'NAO'.*/
            public StringBasis WS_TEM_ERRO_1894 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05 WS-TEM-ERRO-1896              PIC  X(003) VALUE 'NAO'.*/
            public StringBasis WS_TEM_ERRO_1896 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05 WS-TEM-ERRO-1897              PIC  X(003) VALUE 'NAO'.*/
            public StringBasis WS_TEM_ERRO_1897 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05 WS-TEM-ERRO-1829              PIC  X(003) VALUE 'NAO'.*/
            public StringBasis WS_TEM_ERRO_1829 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05 WS-TEM-ERRO-1877              PIC  X(003) VALUE 'NAO'.*/
            public StringBasis WS_TEM_ERRO_1877 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05 WS-TEM-ERRO-1878              PIC  X(003) VALUE 'NAO'.*/
            public StringBasis WS_TEM_ERRO_1878 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05 WS-TEM-ERRO-DAD-CAD           PIC  X(003) VALUE 'NAO'.*/
            public StringBasis WS_TEM_ERRO_DAD_CAD { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05 WS-FONTE                      PIC  9(005) VALUE 0.*/
            public IntBasis WS_FONTE { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    05 WFIM-AGENCEF                  PIC  X(001) VALUE ' '.*/
            public StringBasis WFIM_AGENCEF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"    05 WFIM-CBO                      PIC  X(001) VALUE ' '.*/
            public StringBasis WFIM_CBO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"    05 WFIM-FONTES                   PIC  X(001) VALUE ' '.*/
            public StringBasis WFIM_FONTES { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"    05 WFIM-VGPLARAMC                PIC  X(001) VALUE ' '.*/
            public StringBasis WFIM_VGPLARAMC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"    05 WFIM-VGPLAACES                PIC  X(001) VALUE ' '.*/
            public StringBasis WFIM_VGPLAACES { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"    05 WFIM-VGRAMOCOMP               PIC  X(003) VALUE ' '.*/
            public StringBasis WFIM_VGRAMOCOMP { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ");
            /*"    05 WFIM-TAB-RAMO                 PIC  X(003) VALUE ' '.*/
            public StringBasis WFIM_TAB_RAMO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ");
            /*"    05 IND                           PIC  9(005) VALUE 0.*/
            public IntBasis IND { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    05 INDR                          PIC  9      VALUE 0.*/
            public IntBasis INDR { get; set; } = new IntBasis(new PIC("9", "1", "9"));
            /*"    05 WS-IDADE-INICIAL              PIC  9(004) VALUE 0.*/
            public IntBasis WS_IDADE_INICIAL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05 AC-CONTROLE                   PIC  9(006) VALUE 0.*/
            public IntBasis AC_CONTROLE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05 AC-CONTA                      PIC  9(006) VALUE 0.*/
            public IntBasis AC_CONTA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05 AC-L-MOVIMENTO                PIC  9(006) VALUE 0.*/
            public IntBasis AC_L_MOVIMENTO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05 AC-I-PROPOSTAVA               PIC  9(006) VALUE 0.*/
            public IntBasis AC_I_PROPOSTAVA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05 AC-I-COMPL-SICAQ              PIC  9(006) VALUE 0.*/
            public IntBasis AC_I_COMPL_SICAQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05 AC-I-HISTRAMOCOB              PIC  9(006) VALUE 0.*/
            public IntBasis AC_I_HISTRAMOCOB { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05 AC-I-HISTACESCOB              PIC  9(006) VALUE 0.*/
            public IntBasis AC_I_HISTACESCOB { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05 AC-I-MATRIZ                   PIC  9(006) VALUE 0.*/
            public IntBasis AC_I_MATRIZ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05 AC-TOT-RISCO                  PIC  9(013)V99 VALUE 0.*/
            public DoubleBasis AC_TOT_RISCO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05 AC-TOT-ACUM-CPF               PIC  9(013)V99 VALUE 0.*/
            public DoubleBasis AC_TOT_ACUM_CPF { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05 DATA-SQL1                     PIC  X(010).*/
            public StringBasis DATA_SQL1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05 DATA-SQL  REDEFINES DATA-SQL1.*/
            private _REDEF_VA0601B_DATA_SQL _data_sql { get; set; }
            public _REDEF_VA0601B_DATA_SQL DATA_SQL
            {
                get { _data_sql = new _REDEF_VA0601B_DATA_SQL(); _.Move(DATA_SQL1, _data_sql); VarBasis.RedefinePassValue(DATA_SQL1, _data_sql, DATA_SQL1); _data_sql.ValueChanged += () => { _.Move(_data_sql, DATA_SQL1); }; return _data_sql; }
                set { VarBasis.RedefinePassValue(value, _data_sql, DATA_SQL1); }
            }  //Redefines
            public class _REDEF_VA0601B_DATA_SQL : VarBasis
            {
                /*"       10 ANO-SQL                    PIC  9(004).*/
                public IntBasis ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10 FILLER                     PIC  X(001).*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 MES-SQL                    PIC  9(002).*/
                public IntBasis MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 FILLER                     PIC  X(001).*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 DIA-SQL                    PIC  9(002).*/
                public IntBasis DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05 HORA-SQL1                     PIC  X(008).*/

                public _REDEF_VA0601B_DATA_SQL()
                {
                    ANO_SQL.ValueChanged += OnValueChanged;
                    FILLER_12.ValueChanged += OnValueChanged;
                    MES_SQL.ValueChanged += OnValueChanged;
                    FILLER_13.ValueChanged += OnValueChanged;
                    DIA_SQL.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis HORA_SQL1 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05 HORA-SQL  REDEFINES HORA-SQL1.*/
            private _REDEF_VA0601B_HORA_SQL _hora_sql { get; set; }
            public _REDEF_VA0601B_HORA_SQL HORA_SQL
            {
                get { _hora_sql = new _REDEF_VA0601B_HORA_SQL(); _.Move(HORA_SQL1, _hora_sql); VarBasis.RedefinePassValue(HORA_SQL1, _hora_sql, HORA_SQL1); _hora_sql.ValueChanged += () => { _.Move(_hora_sql, HORA_SQL1); }; return _hora_sql; }
                set { VarBasis.RedefinePassValue(value, _hora_sql, HORA_SQL1); }
            }  //Redefines
            public class _REDEF_VA0601B_HORA_SQL : VarBasis
            {
                /*"       10 HH-SQL                     PIC  9(002).*/
                public IntBasis HH_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 FILLER                     PIC  X(001).*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 MM-SQL                     PIC  9(002).*/
                public IntBasis MM_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 FILLER                     PIC  X(001).*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 SS-SQL                     PIC  9(002).*/
                public IntBasis SS_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05 WS-DTNASC.*/

                public _REDEF_VA0601B_HORA_SQL()
                {
                    HH_SQL.ValueChanged += OnValueChanged;
                    FILLER_14.ValueChanged += OnValueChanged;
                    MM_SQL.ValueChanged += OnValueChanged;
                    FILLER_15.ValueChanged += OnValueChanged;
                    SS_SQL.ValueChanged += OnValueChanged;
                }

            }
            public VA0601B_WS_DTNASC WS_DTNASC { get; set; } = new VA0601B_WS_DTNASC();
            public class VA0601B_WS_DTNASC : VarBasis
            {
                /*"       10 WS-AA-DTNASC               PIC  9(004).*/
                public IntBasis WS_AA_DTNASC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10 FILLER                     PIC  X(001).*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-MM-DTNASC               PIC  9(002).*/
                public IntBasis WS_MM_DTNASC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 FILLER                     PIC  X(001).*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-DD-DTNASC               PIC  9(002).*/
                public IntBasis WS_DD_DTNASC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05 WS-DTPROP.*/
            }
            public VA0601B_WS_DTPROP WS_DTPROP { get; set; } = new VA0601B_WS_DTPROP();
            public class VA0601B_WS_DTPROP : VarBasis
            {
                /*"       10 WS-AA-DTPROP               PIC  9(004).*/
                public IntBasis WS_AA_DTPROP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10 FILLER                     PIC  X(001).*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-MM-DTPROP               PIC  9(002).*/
                public IntBasis WS_MM_DTPROP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 FILLER                     PIC  X(001).*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-DD-DTPROP               PIC  9(002).*/
                public IntBasis WS_DD_DTPROP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05 WS-DTINIVIG                   PIC  9(008).*/
            }
            public IntBasis WS_DTINIVIG { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05 WS-DTTERVIG                   PIC  9(008).*/
            public IntBasis WS_DTTERVIG { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05  W-NOM-ORGAO-EXP               PIC X(030).*/
            public StringBasis W_NOM_ORGAO_EXP { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
            /*"    05  FILLER REDEFINES W-NOM-ORGAO-EXP.*/
            private _REDEF_VA0601B_FILLER_20 _filler_20 { get; set; }
            public _REDEF_VA0601B_FILLER_20 FILLER_20
            {
                get { _filler_20 = new _REDEF_VA0601B_FILLER_20(); _.Move(W_NOM_ORGAO_EXP, _filler_20); VarBasis.RedefinePassValue(W_NOM_ORGAO_EXP, _filler_20, W_NOM_ORGAO_EXP); _filler_20.ValueChanged += () => { _.Move(_filler_20, W_NOM_ORGAO_EXP); }; return _filler_20; }
                set { VarBasis.RedefinePassValue(value, _filler_20, W_NOM_ORGAO_EXP); }
            }  //Redefines
            public class _REDEF_VA0601B_FILLER_20 : VarBasis
            {
                /*"        07  W-ORGAO-EXPEDIDOR         PIC X(005).*/
                public StringBasis W_ORGAO_EXPEDIDOR { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                /*"        07  FILLER                    PIC X(025).*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
                /*"    05 DATA-DDMMAA                   PIC  9(008).*/

                public _REDEF_VA0601B_FILLER_20()
                {
                    W_ORGAO_EXPEDIDOR.ValueChanged += OnValueChanged;
                    FILLER_21.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis DATA_DDMMAA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05 DATA-DDMMAA-R REDEFINES DATA-DDMMAA.*/
            private _REDEF_VA0601B_DATA_DDMMAA_R _data_ddmmaa_r { get; set; }
            public _REDEF_VA0601B_DATA_DDMMAA_R DATA_DDMMAA_R
            {
                get { _data_ddmmaa_r = new _REDEF_VA0601B_DATA_DDMMAA_R(); _.Move(DATA_DDMMAA, _data_ddmmaa_r); VarBasis.RedefinePassValue(DATA_DDMMAA, _data_ddmmaa_r, DATA_DDMMAA); _data_ddmmaa_r.ValueChanged += () => { _.Move(_data_ddmmaa_r, DATA_DDMMAA); }; return _data_ddmmaa_r; }
                set { VarBasis.RedefinePassValue(value, _data_ddmmaa_r, DATA_DDMMAA); }
            }  //Redefines
            public class _REDEF_VA0601B_DATA_DDMMAA_R : VarBasis
            {
                /*"       10 DIA-DDMMAA                 PIC  9(002).*/
                public IntBasis DIA_DDMMAA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 MES-DDMMAA                 PIC  9(002).*/
                public IntBasis MES_DDMMAA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 ANO-DDMMAA                 PIC  9(004).*/
                public IntBasis ANO_DDMMAA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05 WS-VLCONJUGE                  PIC  9(013)V99.*/

                public _REDEF_VA0601B_DATA_DDMMAA_R()
                {
                    DIA_DDMMAA.ValueChanged += OnValueChanged;
                    MES_DDMMAA.ValueChanged += OnValueChanged;
                    ANO_DDMMAA.ValueChanged += OnValueChanged;
                }

            }
            public DoubleBasis WS_VLCONJUGE { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"01  WS-TIME.*/
        }
        public VA0601B_WS_TIME WS_TIME { get; set; } = new VA0601B_WS_TIME();
        public class VA0601B_WS_TIME : VarBasis
        {
            /*"    05 WS-TIME-N                     PIC 9(06).*/
            public IntBasis WS_TIME_N { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
            /*"    05 FILLER                        PIC X(02).*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
            /*"01  WS-TIME-EDIT                     PIC 99.99.99.*/
        }
        public IntBasis WS_TIME_EDIT { get; set; } = new IntBasis(new PIC("9", "6", "99.99.99."));
        /*"01         W-GECLIMOV.*/
        public VA0601B_W_GECLIMOV W_GECLIMOV { get; set; } = new VA0601B_W_GECLIMOV();
        public class VA0601B_W_GECLIMOV : VarBasis
        {
            /*"  05       WWORK-COD-CLIENTE      PIC S9(009)    VALUE +0 COMP-4*/
            public IntBasis WWORK_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05       WWORK-TIPO-MOVIMENTO   PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WWORK_TIPO_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05       WWORK-DATA-ULT-MANUTEN PIC  X(010)    VALUE  SPACES.*/
            public StringBasis WWORK_DATA_ULT_MANUTEN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05       WWORK-NOME-RAZAO       PIC  X(040)    VALUE  SPACES.*/
            public StringBasis WWORK_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"  05       WWORK-TIPO-PESSOA      PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WWORK_TIPO_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05       WWORK-IDE-SEXO         PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WWORK_IDE_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05       WWORK-ESTADO-CIVIL     PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WWORK_ESTADO_CIVIL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05       WWORK-OCORR-ENDERECO   PIC S9(004)    VALUE +0 COMP-4*/
            public IntBasis WWORK_OCORR_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05       WWORK-ENDERECO         PIC  X(040)    VALUE  SPACES.*/
            public StringBasis WWORK_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"  05       WWORK-BAIRRO           PIC  X(020)    VALUE  SPACES.*/
            public StringBasis WWORK_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
            /*"  05       WWORK-CIDADE           PIC  X(020)    VALUE  SPACES.*/
            public StringBasis WWORK_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
            /*"  05       WWORK-SIGLA-UF         PIC  X(002)    VALUE  SPACES.*/
            public StringBasis WWORK_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"  05       WWORK-CEP              PIC S9(009)    VALUE +0 COMP-4*/
            public IntBasis WWORK_CEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05       WWORK-DDD              PIC S9(004)    VALUE +0 COMP-4*/
            public IntBasis WWORK_DDD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05       WWORK-TELEFONE         PIC S9(009)    VALUE +0 COMP-4*/
            public IntBasis WWORK_TELEFONE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05       WWORK-FAX              PIC S9(009)    VALUE +0 COMP-4*/
            public IntBasis WWORK_FAX { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05       WWORK-CGCCPF           PIC S9(015)    VALUE +0 COMP-3*/
            public IntBasis WWORK_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            /*"  05       WWORK-DATA-NASCIMENTO  PIC  X(010)    VALUE  SPACES.*/
            public StringBasis WWORK_DATA_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03         WS-MATRICULA-EDT         PIC 9(015)    VALUE ZEROS.*/
            public IntBasis WS_MATRICULA_EDT { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"  03         FILLER     REDEFINES     WS-MATRICULA-EDT.*/
            private _REDEF_VA0601B_FILLER_23 _filler_23 { get; set; }
            public _REDEF_VA0601B_FILLER_23 FILLER_23
            {
                get { _filler_23 = new _REDEF_VA0601B_FILLER_23(); _.Move(WS_MATRICULA_EDT, _filler_23); VarBasis.RedefinePassValue(WS_MATRICULA_EDT, _filler_23, WS_MATRICULA_EDT); _filler_23.ValueChanged += () => { _.Move(_filler_23, WS_MATRICULA_EDT); }; return _filler_23; }
                set { VarBasis.RedefinePassValue(value, _filler_23, WS_MATRICULA_EDT); }
            }  //Redefines
            public class _REDEF_VA0601B_FILLER_23 : VarBasis
            {
                /*"    05       WS-NUM-MAT               PIC 9(014).*/
                public IntBasis WS_NUM_MAT { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                /*"    05       WS-DIG-MAT               PIC 9(001).*/
                public IntBasis WS_DIG_MAT { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"01  AREA-ABEND.*/

                public _REDEF_VA0601B_FILLER_23()
                {
                    WS_NUM_MAT.ValueChanged += OnValueChanged;
                    WS_DIG_MAT.ValueChanged += OnValueChanged;
                }

            }
        }
        public VA0601B_AREA_ABEND AREA_ABEND { get; set; } = new VA0601B_AREA_ABEND();
        public class VA0601B_AREA_ABEND : VarBasis
        {
            /*"    05   WABEND.*/
            public VA0601B_WABEND WABEND { get; set; } = new VA0601B_WABEND();
            public class VA0601B_WABEND : VarBasis
            {
                /*"      10    FILLER                   PIC  X(010) VALUE            'VA0601B  '.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VA0601B  ");
                /*"      10    FILLER                   PIC  X(028) VALUE            ' *** ERRO  EXEC SQL *** '.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL *** ");
                /*"      10    FILLER                   PIC  X(014) VALUE            '    SQLCODE = '.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"      10    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD1 = '.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"      10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"      10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05      LOCALIZA-ABEND-1.*/
            }
            public VA0601B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new VA0601B_LOCALIZA_ABEND_1();
            public class VA0601B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05      LOCALIZA-ABEND-2.*/
            }
            public VA0601B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new VA0601B_LOCALIZA_ABEND_2();
            public class VA0601B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"    05         WSQLERRO.*/
            }
            public VA0601B_WSQLERRO WSQLERRO { get; set; } = new VA0601B_WSQLERRO();
            public class VA0601B_WSQLERRO : VarBasis
            {
                /*"      10       FILLER               PIC  X(014) VALUE               ' *** SQLERRMC '.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @" *** SQLERRMC ");
                /*"      10       WSQLERRMC            PIC  X(070) VALUE  SPACES.*/
                public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                /*"01           CT0006S-LINKAGE.*/
            }
        }
        public VA0601B_CT0006S_LINKAGE CT0006S_LINKAGE { get; set; } = new VA0601B_CT0006S_LINKAGE();
        public class VA0601B_CT0006S_LINKAGE : VarBasis
        {
            /*"  05         CT0006S-CEP-DESTINO    PIC  9(008).*/
            public IntBasis CT0006S_CEP_DESTINO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05         CT0006S-SIGLA-UF       PIC  X(002).*/
            public StringBasis CT0006S_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05         CT0006S-SQLCODE        PIC  S9(04) COMP.*/
            public IntBasis CT0006S_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05         CT0006S-MENSAGEM       PIC  X(070).*/
            public StringBasis CT0006S_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
            /*"  05         CT0006S-TP-LOGRAD      PIC  X(036).*/
            public StringBasis CT0006S_TP_LOGRAD { get; set; } = new StringBasis(new PIC("X", "36", "X(036)."), @"");
            /*"  05         CT0006S-NOM-LOGRAD     PIC  X(100).*/
            public StringBasis CT0006S_NOM_LOGRAD { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
            /*"  05         CT0006S-BAIRRO         PIC  X(072).*/
            public StringBasis CT0006S_BAIRRO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"  05         CT0006S-CIDADE         PIC  X(072).*/
            public StringBasis CT0006S_CIDADE { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"  05         CT0006S-UNIDADE-OPER   PIC  X(072).*/
            public StringBasis CT0006S_UNIDADE_OPER { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"  05         CT0006S-CENTRALIZ      PIC  X(072).*/
            public StringBasis CT0006S_CENTRALIZ { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"01  TAB-FILIAIS.*/
        }
        public VA0601B_TAB_FILIAIS TAB_FILIAIS { get; set; } = new VA0601B_TAB_FILIAIS();
        public class VA0601B_TAB_FILIAIS : VarBasis
        {
            /*"    05      TAB-FILIAL.*/
            public VA0601B_TAB_FILIAL TAB_FILIAL { get; set; } = new VA0601B_TAB_FILIAL();
            public class VA0601B_TAB_FILIAL : VarBasis
            {
                /*"      10    FILLER    OCCURS    9999   TIMES.*/
                public ListBasis<VA0601B_FILLER_33> FILLER_33 { get; set; } = new ListBasis<VA0601B_FILLER_33>(9999);
                public class VA0601B_FILLER_33 : VarBasis
                {
                    /*"        15  TAB-FONTE                PIC S9(4) COMP.*/
                    public IntBasis TAB_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
                    /*"01  TAB-CBO1.*/
                }
            }
        }
        public VA0601B_TAB_CBO1 TAB_CBO1 { get; set; } = new VA0601B_TAB_CBO1();
        public class VA0601B_TAB_CBO1 : VarBasis
        {
            /*"    05      TAB-CBO.*/
            public VA0601B_TAB_CBO TAB_CBO { get; set; } = new VA0601B_TAB_CBO();
            public class VA0601B_TAB_CBO : VarBasis
            {
                /*"      10    FILLER    OCCURS    999   TIMES.*/
                public ListBasis<VA0601B_FILLER_34> FILLER_34 { get; set; } = new ListBasis<VA0601B_FILLER_34>(999);
                public class VA0601B_FILLER_34 : VarBasis
                {
                    /*"        15  TAB-DESCR-CBO-C          PIC  X(20).*/
                    public StringBasis TAB_DESCR_CBO_C { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
                    /*"01  WSRC-INF-SICAQWEB.*/
                }
            }
        }
        public VA0601B_WSRC_INF_SICAQWEB WSRC_INF_SICAQWEB { get; set; } = new VA0601B_WSRC_INF_SICAQWEB();
        public class VA0601B_WSRC_INF_SICAQWEB : VarBasis
        {
            /*"    05  WSRC-COD-OPERADOR            PIC X(009).*/
            public StringBasis WSRC_COD_OPERADOR { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
            /*"    05  WSRC-NUM-CORRESPONDENTE      PIC 9(009).*/
            public IntBasis WSRC_NUM_CORRESPONDENTE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    05  WSRC-DATA-CONTRATACAO.*/
            public VA0601B_WSRC_DATA_CONTRATACAO WSRC_DATA_CONTRATACAO { get; set; } = new VA0601B_WSRC_DATA_CONTRATACAO();
            public class VA0601B_WSRC_DATA_CONTRATACAO : VarBasis
            {
                /*"        07  WSRC-DIA-CONTRATACAO     PIC 9(002).*/
                public IntBasis WSRC_DIA_CONTRATACAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  WSRC-MES-CONTRATACAO     PIC 9(002).*/
                public IntBasis WSRC_MES_CONTRATACAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  WSRC-ANO-CONTRATACAO     PIC 9(004).*/
                public IntBasis WSRC_ANO_CONTRATACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  WSRC-HORA-CONTRATACAO.*/
            }
            public VA0601B_WSRC_HORA_CONTRATACAO WSRC_HORA_CONTRATACAO { get; set; } = new VA0601B_WSRC_HORA_CONTRATACAO();
            public class VA0601B_WSRC_HORA_CONTRATACAO : VarBasis
            {
                /*"        07  WSRC-HH-CONTRATACAO      PIC 9(002).*/
                public IntBasis WSRC_HH_CONTRATACAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  WSRC-MM-CONTRATACAO      PIC 9(002).*/
                public IntBasis WSRC_MM_CONTRATACAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  WSRC-SS-CONTRATACAO      PIC 9(002).*/
                public IntBasis WSRC_SS_CONTRATACAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05  WSRC-NRO-PROPOSTA-SICAQ      PIC 9(010).*/
            }
            public IntBasis WSRC_NRO_PROPOSTA_SICAQ { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"    05  WSRC-TIPO-CORRESPONDENTE     PIC 9(002).*/
            public IntBasis WSRC_TIPO_CORRESPONDENTE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05  WSRC-ORIGEM-PROPOSTA         PIC X(005).*/
            public StringBasis WSRC_ORIGEM_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
            /*"    05  FILLER                       PIC X(206).*/
            public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "206", "X(206)."), @"");
        }


        public Copies.SPVG001V SPVG001V { get; set; } = new Copies.SPVG001V();
        public Copies.SPVG001W SPVG001W { get; set; } = new Copies.SPVG001W();
        public Copies.SPVG009W SPVG009W { get; set; } = new Copies.SPVG009W();
        public Copies.BIEMPCOM BIEMPCOM { get; set; } = new Copies.BIEMPCOM();
        public Copies.SPVG015W SPVG015W { get; set; } = new Copies.SPVG015W();
        public Copies.SPVG017W SPVG017W { get; set; } = new Copies.SPVG017W();
        public Copies.VATBFREN VATBFREN { get; set; } = new Copies.VATBFREN();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.CONDITEC CONDITEC { get; set; } = new Dclgens.CONDITEC();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.COADSICO COADSICO { get; set; } = new Dclgens.COADSICO();
        public Dclgens.PARVDZUL PARVDZUL { get; set; } = new Dclgens.PARVDZUL();
        public Dclgens.CBHSTZUL CBHSTZUL { get; set; } = new Dclgens.CBHSTZUL();
        public Dclgens.HTCTBPVA HTCTBPVA { get; set; } = new Dclgens.HTCTBPVA();
        public Dclgens.FONTES FONTES { get; set; } = new Dclgens.FONTES();
        public Dclgens.ESTIPULA ESTIPULA { get; set; } = new Dclgens.ESTIPULA();
        public Dclgens.ERPROPAZ ERPROPAZ { get; set; } = new Dclgens.ERPROPAZ();
        public Dclgens.RCAPS RCAPS { get; set; } = new Dclgens.RCAPS();
        public Dclgens.RCAPCOMP RCAPCOMP { get; set; } = new Dclgens.RCAPCOMP();
        public Dclgens.FUNCICEF FUNCICEF { get; set; } = new Dclgens.FUNCICEF();
        public Dclgens.CBO CBO { get; set; } = new Dclgens.CBO();
        public Dclgens.PESSOA PESSOA { get; set; } = new Dclgens.PESSOA();
        public Dclgens.PLVAVGAP PLVAVGAP { get; set; } = new Dclgens.PLVAVGAP();
        public Dclgens.PRODUVG PRODUVG { get; set; } = new Dclgens.PRODUVG();
        public Dclgens.CLIENTE CLIENTE { get; set; } = new Dclgens.CLIENTE();
        public Dclgens.ENDERECO ENDERECO { get; set; } = new Dclgens.ENDERECO();
        public Dclgens.PESENDER PESENDER { get; set; } = new Dclgens.PESENDER();
        public Dclgens.PESFONE PESFONE { get; set; } = new Dclgens.PESFONE();
        public Dclgens.PESEMAIL PESEMAIL { get; set; } = new Dclgens.PESEMAIL();
        public Dclgens.CLIENEMA CLIENEMA { get; set; } = new Dclgens.CLIENEMA();
        public Dclgens.PESFIS PESFIS { get; set; } = new Dclgens.PESFIS();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.PROFIDCO PROFIDCO { get; set; } = new Dclgens.PROFIDCO();
        public Dclgens.PROPSSVD PROPSSVD { get; set; } = new Dclgens.PROPSSVD();
        public Dclgens.MALHACEF MALHACEF { get; set; } = new Dclgens.MALHACEF();
        public Dclgens.AGENCEF AGENCEF { get; set; } = new Dclgens.AGENCEF();
        public Dclgens.PROPVA PROPVA { get; set; } = new Dclgens.PROPVA();
        public Dclgens.COBPRPVA COBPRPVA { get; set; } = new Dclgens.COBPRPVA();
        public Dclgens.OPCPAGVI OPCPAGVI { get; set; } = new Dclgens.OPCPAGVI();
        public Dclgens.NUMOUTRO NUMOUTRO { get; set; } = new Dclgens.NUMOUTRO();
        public Dclgens.GEDOCCLI GEDOCCLI { get; set; } = new Dclgens.GEDOCCLI();
        public Dclgens.GECLIMOV GECLIMOV { get; set; } = new Dclgens.GECLIMOV();
        public Dclgens.VG078 VG078 { get; set; } = new Dclgens.VG078();
        public Dclgens.PF062 PF062 { get; set; } = new Dclgens.PF062();
        public Dclgens.VG080 VG080 { get; set; } = new Dclgens.VG080();
        public Dclgens.VG081 VG081 { get; set; } = new Dclgens.VG081();
        public Dclgens.VG082 VG082 { get; set; } = new Dclgens.VG082();
        public Dclgens.VG084 VG084 { get; set; } = new Dclgens.VG084();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.BENPROPZ BENPROPZ { get; set; } = new Dclgens.BENPROPZ();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.SEGVGAP SEGVGAP { get; set; } = new Dclgens.SEGVGAP();
        public Dclgens.SEGVGAPH SEGVGAPH { get; set; } = new Dclgens.SEGVGAPH();
        public Dclgens.VGHIRACO VGHIRACO { get; set; } = new Dclgens.VGHIRACO();
        public Dclgens.VGHIACCO VGHIACCO { get; set; } = new Dclgens.VGHIACCO();
        public Dclgens.GE406 GE406 { get; set; } = new Dclgens.GE406();
        public Dclgens.HISLANCT HISLANCT { get; set; } = new Dclgens.HISLANCT();
        public Dclgens.CONVEVG CONVEVG { get; set; } = new Dclgens.CONVEVG();
        public Dclgens.VA111 VA111 { get; set; } = new Dclgens.VA111();
        public Dclgens.GE085 GE085 { get; set; } = new Dclgens.GE085();
        public Dclgens.BILHETE BILHETE { get; set; } = new Dclgens.BILHETE();
        public Dclgens.VG103 VG103 { get; set; } = new Dclgens.VG103();
        public Dclgens.UNIDAFED UNIDAFED { get; set; } = new Dclgens.UNIDAFED();
        public Dclgens.VG034 VG034 { get; set; } = new Dclgens.VG034();
        public Dclgens.VG036 VG036 { get; set; } = new Dclgens.VG036();
        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public Dclgens.SPGE051W SPGE051W { get; set; } = new Dclgens.SPGE051W();
        public VA0601B_CPROPOSTA CPROPOSTA { get; set; } = new VA0601B_CPROPOSTA();
        public VA0601B_C01_RCAPCOMP C01_RCAPCOMP { get; set; } = new VA0601B_C01_RCAPCOMP();
        public VA0601B_CPESENDER CPESENDER { get; set; } = new VA0601B_CPESENDER();
        public VA0601B_CPESENDERR CPESENDERR { get; set; } = new VA0601B_CPESENDERR();
        public VA0601B_CFONE CFONE { get; set; } = new VA0601B_CFONE();
        public VA0601B_CRISCO CRISCO { get; set; } = new VA0601B_CRISCO();
        public VA0601B_CRISCO1 CRISCO1 { get; set; } = new VA0601B_CRISCO1();
        public VA0601B_CRISCO2 CRISCO2 { get; set; } = new VA0601B_CRISCO2();
        public VA0601B_CRISCO3 CRISCO3 { get; set; } = new VA0601B_CRISCO3();
        public VA0601B_CCLIENTES CCLIENTES { get; set; } = new VA0601B_CCLIENTES();
        public VA0601B_VGPLARAMC VGPLARAMC { get; set; } = new VA0601B_VGPLARAMC();
        public VA0601B_VGPLAACES VGPLAACES { get; set; } = new VA0601B_VGPLAACES();
        public VA0601B_CEMPRESA CEMPRESA { get; set; } = new VA0601B_CEMPRESA();
        public VA0601B_C01_AGENCEF C01_AGENCEF { get; set; } = new VA0601B_C01_AGENCEF();
        public VA0601B_CCBO CCBO { get; set; } = new VA0601B_CCBO();
        public VA0601B_CVGRAMOCOMP CVGRAMOCOMP { get; set; } = new VA0601B_CVGRAMOCOMP();
        public VA0601B_CSR_ERRO_DPS CSR_ERRO_DPS { get; set; } = new VA0601B_CSR_ERRO_DPS();
        public VA0601B_C01_GECLIMOV C01_GECLIMOV { get; set; } = new VA0601B_C01_GECLIMOV();
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
            /*" -1048- DISPLAY ' ' */
            _.Display($" ");

            /*" -1050- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -1061- DISPLAY 'PROGRAMA EM EXECUCAO VA0601B-' 'VERSAO V.141 DEMANDA RITM0004370 / REQ0000086' 'VERSAO V.140 - DEMANDA: RITM0000078 - ' 'VERSAO V.139 - DEMANDA: 571.176 - ' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) '-' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) */

            $"PROGRAMA EM EXECUCAO VA0601B-VERSAO V.141 DEMANDA RITM0004370 / REQ0000086VERSAO V.140 - DEMANDA: RITM0000078 - VERSAO V.139 - DEMANDA: 571.176 - FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)}-FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}"
            .Display();

            /*" -1063- DISPLAY 'INTEGRA SISPF E SIAS PARA OS PRODUTOS DE' ' VIDA PESSOA FISICA ' */
            _.Display($"INTEGRA SISPF E SIAS PARA OS PRODUTOS DE VIDA PESSOA FISICA ");

            /*" -1065- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -1087- DISPLAY ' ' */
            _.Display($" ");

            /*" -1088- MOVE '0000-PRINCIPAL                     ' TO PARAGRAFO. */
            _.Move("0000-PRINCIPAL                     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1089- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1091- PERFORM R0100-00-INICIALIZA. */

            R0100_00_INICIALIZA_SECTION();

            /*" -1092- PERFORM R0900-00-DECLARE-PROPOSTA. */

            R0900_00_DECLARE_PROPOSTA_SECTION();

            /*" -1094- PERFORM R0910-00-FETCH-PROPOSTA. */

            R0910_00_FETCH_PROPOSTA_SECTION();

            /*" -1095- IF WS-EOR = 1 */

            if (WORK_AREA.WS_EOR == 1)
            {

                /*" -1096- DISPLAY '////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\' */
                _.Display($"////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\");

                /*" -1097- DISPLAY '//                                            //' */
                _.Display($"//                                            //");

                /*" -1098- DISPLAY '//           ==> TERMINO NORMAL <==           //' */
                _.Display($"//           ==> TERMINO NORMAL <==           //");

                /*" -1099- DISPLAY '//                                            //' */
                _.Display($"//                                            //");

                /*" -1100- DISPLAY '//            PROGRAMA  => VA0601B            //' */
                _.Display($"//            PROGRAMA  => VA0601B            //");

                /*" -1101- DISPLAY '//                                            //' */
                _.Display($"//                                            //");

                /*" -1102- DISPLAY '//          SEM PROPOSTAS A INTEGRAR          //' */
                _.Display($"//          SEM PROPOSTAS A INTEGRAR          //");

                /*" -1103- DISPLAY '//                                            //' */
                _.Display($"//                                            //");

                /*" -1104- DISPLAY '\\\\\\\\\\\\\\\\\\\\\\\\////////////////////////' */
                _.Display($"\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\////////////////////////");

                /*" -1105- DISPLAY ' ' */
                _.Display($" ");

                /*" -1111- GO TO R0000-99-FINALIZA. */

                R0000_99_FINALIZA(); //GOTO
                return;
            }


            /*" -1114- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WS-EOR = 1. */

            while (!(WORK_AREA.WS_EOR == 1))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -1114- PERFORM R9100-00-UPDATE-NUM-OUTROS. */

            R9100_00_UPDATE_NUM_OUTROS_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_00_FINALIZA */

            R0000_00_FINALIZA();

        }

        [StopWatch]
        /*" R0000-00-FINALIZA */
        private void R0000_00_FINALIZA(bool isPerform = false)
        {
            /*" -1118- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1120- DISPLAY 'PROCESSAMENTO COM COMMIT ' */
            _.Display($"PROCESSAMENTO COM COMMIT ");

            /*" -1121- DISPLAY 'PROCESSAMENTO COM COMMIT ' */
            _.Display($"PROCESSAMENTO COM COMMIT ");

            /*" -1128- DISPLAY 'PROCESSAMENTO COM COMMIT ' */
            _.Display($"PROCESSAMENTO COM COMMIT ");

            /*" -1129- DISPLAY ' ' */
            _.Display($" ");

            /*" -1130- DISPLAY '////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\' */
            _.Display($"////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\");

            /*" -1131- DISPLAY '//                                            //' */
            _.Display($"//                                            //");

            /*" -1132- DISPLAY '//           ==> TERMINO NORMAL <==           //' */
            _.Display($"//           ==> TERMINO NORMAL <==           //");

            /*" -1133- DISPLAY '//                                            //' */
            _.Display($"//                                            //");

            /*" -1134- DISPLAY '//            PROGRAMA ==> VA0601B            //' */
            _.Display($"//            PROGRAMA ==> VA0601B            //");

            /*" -1135- DISPLAY '//                                            //' */
            _.Display($"//                                            //");

            /*" -1137- DISPLAY '\\\\\\\\\\\\\\\\\\\\\\\\////////////////////////' */
            _.Display($"\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\////////////////////////");

            /*" -1138- DISPLAY ' ' */
            _.Display($" ");

            /*" -1139- DISPLAY '-------------------------------------------------' */
            _.Display($"-------------------------------------------------");

            /*" -1140- DISPLAY 'LIDOS PROPOSTAVA-FIDELIZ... ' AC-L-MOVIMENTO */
            _.Display($"LIDOS PROPOSTAVA-FIDELIZ... {WORK_AREA.AC_L_MOVIMENTO}");

            /*" -1141- DISPLAY '-------------------------------------------------' */
            _.Display($"-------------------------------------------------");

            /*" -1142- DISPLAY 'QTD REJEITADA SEM RCAPS.... ' WS-QTD-SEM-RCAPS */
            _.Display($"QTD REJEITADA SEM RCAPS.... {WS_QTD_SEM_RCAPS}");

            /*" -1143- DISPLAY 'GRAVADOS PROPOSTAVA........ ' AC-I-PROPOSTAVA */
            _.Display($"GRAVADOS PROPOSTAVA........ {WORK_AREA.AC_I_PROPOSTAVA}");

            /*" -1144- DISPLAY 'GRAVADOS COMPL-SICAQWEB.... ' AC-I-COMPL-SICAQ */
            _.Display($"GRAVADOS COMPL-SICAQWEB.... {WORK_AREA.AC_I_COMPL_SICAQ}");

            /*" -1145- DISPLAY 'GRAVADOS VG-HIST-RAMO-COB.. ' AC-I-HISTRAMOCOB */
            _.Display($"GRAVADOS VG-HIST-RAMO-COB.. {WORK_AREA.AC_I_HISTRAMOCOB}");

            /*" -1146- DISPLAY 'GRAVADOS VG-HIST-ACES-COB.. ' AC-I-HISTACESCOB */
            _.Display($"GRAVADOS VG-HIST-ACES-COB.. {WORK_AREA.AC_I_HISTACESCOB}");

            /*" -1147- DISPLAY '-------------------------------------------------' */
            _.Display($"-------------------------------------------------");

            /*" -1148- DISPLAY 'MATRIZ DESC/AGRAVO  AIC.... ' AC-I-MATRIZ */
            _.Display($"MATRIZ DESC/AGRAVO  AIC.... {WORK_AREA.AC_I_MATRIZ}");

            /*" -1149- DISPLAY '-------------------------------------------------' */
            _.Display($"-------------------------------------------------");

            /*" -1150- DISPLAY 'QTD RISCO CRITICO.......... ' WS-QT-RISCO-CRITICO */
            _.Display($"QTD RISCO CRITICO.......... {WS_QT_RISCO_CRITICO}");

            /*" -1151- DISPLAY 'QTD PROP. ANALISE RISCO.... ' WS-QT-EM-CRITICA */
            _.Display($"QTD PROP. ANALISE RISCO.... {WS_QT_EM_CRITICA}");

            /*" -1152- DISPLAY 'QTD PROP. COM AVAL. RISCO.. ' WS-QT-EMISSAO-C-RISCO */
            _.Display($"QTD PROP. COM AVAL. RISCO.. {WS_QT_EMISSAO_C_RISCO}");

            /*" -1153- DISPLAY 'QTD PROP. SEM AVAL. RISCO.. ' WS-QT-EMISSAO-S-RISCO */
            _.Display($"QTD PROP. SEM AVAL. RISCO.. {WS_QT_EMISSAO_S_RISCO}");

            /*" -1154- DISPLAY 'QTD LIBERADA EMISSAO....... ' WS-QT-LIBERADO-EMISSAO */
            _.Display($"QTD LIBERADA EMISSAO....... {WS_QT_LIBERADO_EMISSAO}");

            /*" -1155- DISPLAY '-------------------------------------------------' */
            _.Display($"-------------------------------------------------");

            /*" -1157- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1158- PERFORM R9900-00-MOSTRA-TOTAIS */

            R9900_00_MOSTRA_TOTAIS_SECTION();

            /*" -1158- . */

        }

        [StopWatch]
        /*" R0000-99-FINALIZA */
        private void R0000_99_FINALIZA(bool isPerform = false)
        {
            /*" -1163- MOVE 0 TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -1163- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0100-00-INICIALIZA-SECTION */
        private void R0100_00_INICIALIZA_SECTION()
        {
            /*" -1173- INITIALIZE TOTAIS-ROT DCLVA-CAMPANHA-CARENCIA. */
            _.Initialize(
                TOTAIS_ROT
                , VA111.DCLVA_CAMPANHA_CARENCIA
            );

            /*" -1174- MOVE 'R0100-00-SELECT-SISTEMAS      ' TO PARAGRAFO. */
            _.Move("R0100-00-SELECT-SISTEMAS      ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1176- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1177- MOVE 01 TO SII. */
            _.Move(01, WS_HORAS.SII);

            /*" -1178- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1183- PERFORM R0100_00_INICIALIZA_DB_SELECT_1 */

            R0100_00_INICIALIZA_DB_SELECT_1();

            /*" -1186- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1187- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1188- DISPLAY 'PROBLEMAS NO ACESSO  A SISTEMAS ' */
                _.Display($"PROBLEMAS NO ACESSO  A SISTEMAS ");

                /*" -1190- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1192- MOVE 'R0100-00-SELECT-NUM-OUTROS    ' TO PARAGRAFO. */
            _.Move("R0100-00-SELECT-NUM-OUTROS    ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1193- MOVE 02 TO SII. */
            _.Move(02, WS_HORAS.SII);

            /*" -1194- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1198- PERFORM R0100_00_INICIALIZA_DB_SELECT_2 */

            R0100_00_INICIALIZA_DB_SELECT_2();

            /*" -1201- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1202- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1203- DISPLAY 'PROBLEMAS NO ACESSO  A NUMERO OUTROS' */
                _.Display($"PROBLEMAS NO ACESSO  A NUMERO OUTROS");

                /*" -1205- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1207- INITIALIZE TAB-FILIAIS. */
            _.Initialize(
                TAB_FILIAIS
            );

            /*" -1209- PERFORM R6000-00-DECLARE-AGENCEF. */

            R6000_00_DECLARE_AGENCEF_SECTION();

            /*" -1211- PERFORM R6010-00-FETCH-AGENCEF. */

            R6010_00_FETCH_AGENCEF_SECTION();

            /*" -1212- IF WFIM-AGENCEF NOT EQUAL SPACES */

            if (!WORK_AREA.WFIM_AGENCEF.IsEmpty())
            {

                /*" -1213- DISPLAY '0000 - PROBLEMA NO FETCH DA AGENCIACEF' */
                _.Display($"0000 - PROBLEMA NO FETCH DA AGENCIACEF");

                /*" -1215- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1218- PERFORM R6020-00-CARREGA-FILIAL UNTIL WFIM-AGENCEF EQUAL 'S' . */

            while (!(WORK_AREA.WFIM_AGENCEF == "S"))
            {

                R6020_00_CARREGA_FILIAL_SECTION();
            }

            /*" -1220- MOVE ZEROS TO TAB-CBO1. */
            _.Move(0, TAB_CBO1);

            /*" -1222- PERFORM R6100-00-DECLARE-CBO. */

            R6100_00_DECLARE_CBO_SECTION();

            /*" -1224- PERFORM R6110-00-FETCH-CBO. */

            R6110_00_FETCH_CBO_SECTION();

            /*" -1225- IF WFIM-CBO NOT EQUAL SPACES */

            if (!WORK_AREA.WFIM_CBO.IsEmpty())
            {

                /*" -1226- DISPLAY '0100 - PROBLEMA NO FETCH DA CBO         ' */
                _.Display($"0100 - PROBLEMA NO FETCH DA CBO         ");

                /*" -1228- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1229- PERFORM R6120-00-CARREGA-CBO UNTIL WFIM-CBO EQUAL 'S' . */

            while (!(WORK_AREA.WFIM_CBO == "S"))
            {

                R6120_00_CARREGA_CBO_SECTION();
            }

        }

        [StopWatch]
        /*" R0100-00-INICIALIZA-DB-SELECT-1 */
        public void R0100_00_INICIALIZA_DB_SELECT_1()
        {
            /*" -1183- EXEC SQL SELECT DATA_MOV_ABERTO INTO :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'PF' END-EXEC. */

            var r0100_00_INICIALIZA_DB_SELECT_1_Query1 = new R0100_00_INICIALIZA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_INICIALIZA_DB_SELECT_1_Query1.Execute(r0100_00_INICIALIZA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-INICIALIZA-DB-SELECT-2 */
        public void R0100_00_INICIALIZA_DB_SELECT_2()
        {
            /*" -1198- EXEC SQL SELECT NUM_CLIENTE INTO :DCLNUMERO-OUTROS.NUM-CLIENTE FROM SEGUROS.NUMERO_OUTROS END-EXEC. */

            var r0100_00_INICIALIZA_DB_SELECT_2_Query1 = new R0100_00_INICIALIZA_DB_SELECT_2_Query1()
            {
            };

            var executed_1 = R0100_00_INICIALIZA_DB_SELECT_2_Query1.Execute(r0100_00_INICIALIZA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUM_CLIENTE, NUMOUTRO.DCLNUMERO_OUTROS.NUM_CLIENTE);
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-PROPOSTA-SECTION */
        private void R0900_00_DECLARE_PROPOSTA_SECTION()
        {
            /*" -1240- MOVE 'R0900-00-DECLARE-PROPOSTA' TO PARAGRAFO. */
            _.Move("R0900-00-DECLARE-PROPOSTA", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1241- MOVE 'DECLARE CPROPOSTA                  ' TO COMANDO. */
            _.Move("DECLARE CPROPOSTA                  ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1243- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1244- MOVE 03 TO SII. */
            _.Move(03, WS_HORAS.SII);

            /*" -1246- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1654- PERFORM R0900_00_DECLARE_PROPOSTA_DB_DECLARE_1 */

            R0900_00_DECLARE_PROPOSTA_DB_DECLARE_1();

            /*" -1658- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1659- MOVE 'OPEN CPROPOSTA                     ' TO COMANDO. */
            _.Move("OPEN CPROPOSTA                     ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1660- MOVE 04 TO SII. */
            _.Move(04, WS_HORAS.SII);

            /*" -1661- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1661- PERFORM R0900_00_DECLARE_PROPOSTA_DB_OPEN_1 */

            R0900_00_DECLARE_PROPOSTA_DB_OPEN_1();

            /*" -1664- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1665- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1666- DISPLAY '*** VA0601B *** ERRO OPEN CPROPOSTA  ' */
                _.Display($"*** VA0601B *** ERRO OPEN CPROPOSTA  ");

                /*" -1666- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-PROPOSTA-DB-DECLARE-1 */
        public void R0900_00_DECLARE_PROPOSTA_DB_DECLARE_1()
        {
            /*" -1654- EXEC SQL DECLARE CPROPOSTA CURSOR WITH HOLD FOR SELECT B.NUM_APOLICE , B.COD_SUBGRUPO , B.NUM_IDENTIFICACAO , B.DPS_TITULAR , B.DPS_CONJUGE , B.APOS_INVALIDEZ , B.NUM_CONTR_VINCULO , B.COD_CORRESP_BANC , B.NUM_PRAZO_FIN , B.COD_OPER_CREDITO , C.OPCAO_COBER , C.COD_PLANO , B.COD_USUARIO , C.NUM_PROPOSTA_SIVPF , C.COD_PESSOA , C.NUM_SICOB , C.DATA_PROPOSTA , C.COD_PRODUTO_SIVPF , C.COD_EMPRESA_SIVPF , C.AGECOBR , C.DIA_DEBITO , C.OPCAOPAG , C.AGECTADEB , C.OPRCTADEB , C.NUMCTADEB , C.DIGCTADEB , C.PERC_DESCONTO , C.NRMATRVEN , C.AGECTAVEN , C.OPRCTAVEN , C.NUMCTAVEN , C.DIGCTAVEN , C.CGC_CONVENENTE , C.NOME_CONVENENTE , C.NRMATRCON , C.DTQITBCO , C.VAL_PAGO , C.AGEPGTO , C.VAL_TARIFA , C.VAL_IOF , C.DATA_CREDITO , C.VAL_COMISSAO , C.SIT_PROPOSTA , C.COD_USUARIO , C.CANAL_PROPOSTA , C.NSAS_SIVPF , C.ORIGEM_PROPOSTA , C.TIMESTAMP , C.NSL , C.NSAC_SIVPF , C.NOME_CONJUGE , C.DATA_NASC_CONJUGE , C.PROFISSAO_CONJUGE , C.FAIXA_RENDA_IND , C.FAIXA_RENDA_FAM , C.IND_TP_PROPOSTA , C.IND_TIPO_CONTA , A.COD_PRODUTO , A.PERI_PAGAMENTO , A.DESCONTO_ADESAO , A.NOME_PRODUTO , D.RAMO_EMISSOR FROM SEGUROS.PRODUTOS_VG A , SEGUROS.PROP_SASSE_VIDA B , SEGUROS.PROPOSTA_FIDELIZ C , SEGUROS.APOLICES D WHERE A.ESTR_COBR = 'MULT' AND A.RAMO <> 77 AND B.NUM_APOLICE = A.NUM_APOLICE AND B.COD_SUBGRUPO = A.COD_SUBGRUPO AND B.NUM_APOLICE = D.NUM_APOLICE AND C.NUM_IDENTIFICACAO = B.NUM_IDENTIFICACAO AND C.SIT_PROPOSTA = 'ENV' AND C.COD_PRODUTO_SIVPF IN (06, 07, 11, 13, 37, 46, 54) UNION SELECT B.NUM_APOLICE , B.COD_SUBGRUPO , B.NUM_IDENTIFICACAO , B.DPS_TITULAR , B.DPS_CONJUGE , B.APOS_INVALIDEZ , B.NUM_CONTR_VINCULO , B.COD_CORRESP_BANC , B.NUM_PRAZO_FIN , B.COD_OPER_CREDITO , C.OPCAO_COBER , C.COD_PLANO , B.COD_USUARIO , C.NUM_PROPOSTA_SIVPF , C.COD_PESSOA , C.NUM_SICOB , C.DATA_PROPOSTA , C.COD_PRODUTO_SIVPF , C.COD_EMPRESA_SIVPF , C.AGECOBR , C.DIA_DEBITO , C.OPCAOPAG , C.AGECTADEB , C.OPRCTADEB , C.NUMCTADEB , C.DIGCTADEB , C.PERC_DESCONTO , C.NRMATRVEN , C.AGECTAVEN , C.OPRCTAVEN , C.NUMCTAVEN , C.DIGCTAVEN , C.CGC_CONVENENTE , C.NOME_CONVENENTE , C.NRMATRCON , C.DTQITBCO , C.VAL_PAGO , C.AGEPGTO , C.VAL_TARIFA , C.VAL_IOF , C.DATA_CREDITO , C.VAL_COMISSAO , C.SIT_PROPOSTA , C.COD_USUARIO , C.CANAL_PROPOSTA , C.NSAS_SIVPF , C.ORIGEM_PROPOSTA , C.TIMESTAMP , C.NSL , C.NSAC_SIVPF , C.NOME_CONJUGE , C.DATA_NASC_CONJUGE , C.PROFISSAO_CONJUGE , C.FAIXA_RENDA_IND , C.FAIXA_RENDA_FAM , C.IND_TP_PROPOSTA , C.IND_TIPO_CONTA , A.COD_PRODUTO , A.PERI_PAGAMENTO , A.DESCONTO_ADESAO , A.NOME_PRODUTO , D.RAMO_EMISSOR FROM SEGUROS.PRODUTOS_VG A , SEGUROS.PROP_SASSE_VIDA B , SEGUROS.PROPOSTA_FIDELIZ C , SEGUROS.APOLICES D WHERE A.ESTR_COBR = 'MULT' AND A.RAMO <> 77 AND B.NUM_APOLICE = A.NUM_APOLICE AND B.COD_SUBGRUPO = A.COD_SUBGRUPO AND B.NUM_APOLICE = D.NUM_APOLICE AND C.NUM_IDENTIFICACAO = B.NUM_IDENTIFICACAO AND C.SIT_PROPOSTA = 'POV' AND C.COD_PRODUTO_SIVPF IN (06, 07, 11, 13, 37, 46, 54) UNION SELECT B.NUM_APOLICE , B.COD_SUBGRUPO , B.NUM_IDENTIFICACAO , B.DPS_TITULAR , B.DPS_CONJUGE , B.APOS_INVALIDEZ , B.NUM_CONTR_VINCULO , B.COD_CORRESP_BANC , B.NUM_PRAZO_FIN , B.COD_OPER_CREDITO , C.OPCAO_COBER , C.COD_PLANO , B.COD_USUARIO , C.NUM_PROPOSTA_SIVPF , C.COD_PESSOA , C.NUM_SICOB , C.DATA_PROPOSTA , C.COD_PRODUTO_SIVPF , C.COD_EMPRESA_SIVPF , C.AGECOBR , C.DIA_DEBITO , C.OPCAOPAG , C.AGECTADEB , C.OPRCTADEB , C.NUMCTADEB , C.DIGCTADEB , C.PERC_DESCONTO , C.NRMATRVEN , C.AGECTAVEN , C.OPRCTAVEN , C.NUMCTAVEN , C.DIGCTAVEN , C.CGC_CONVENENTE , C.NOME_CONVENENTE , C.NRMATRCON , C.DTQITBCO , C.VAL_PAGO , C.AGEPGTO , C.VAL_TARIFA , C.VAL_IOF , C.DATA_CREDITO , C.VAL_COMISSAO , C.SIT_PROPOSTA , C.COD_USUARIO , C.CANAL_PROPOSTA , C.NSAS_SIVPF , C.ORIGEM_PROPOSTA , C.TIMESTAMP , C.NSL , C.NSAC_SIVPF , C.NOME_CONJUGE , C.DATA_NASC_CONJUGE , C.PROFISSAO_CONJUGE , C.FAIXA_RENDA_IND , C.FAIXA_RENDA_FAM , C.IND_TP_PROPOSTA , C.IND_TIPO_CONTA , A.COD_PRODUTO , A.PERI_PAGAMENTO , A.DESCONTO_ADESAO , A.NOME_PRODUTO , D.RAMO_EMISSOR FROM SEGUROS.PRODUTOS_VG A , SEGUROS.PROP_SASSE_VIDA B , SEGUROS.PROPOSTA_FIDELIZ C , SEGUROS.APOLICES D WHERE A.ESTR_COBR = 'MULT' AND A.RAMO <> 77 AND B.NUM_APOLICE = A.NUM_APOLICE AND B.COD_SUBGRUPO = A.COD_SUBGRUPO AND B.NUM_APOLICE = D.NUM_APOLICE AND C.NUM_IDENTIFICACAO = B.NUM_IDENTIFICACAO AND C.SIT_PROPOSTA = 'DEC' AND C.COD_PRODUTO_SIVPF IN (06, 07, 11, 13, 37, 46, 54) UNION SELECT B.NUM_APOLICE , B.COD_SUBGRUPO , B.NUM_IDENTIFICACAO , B.DPS_TITULAR , B.DPS_CONJUGE , B.APOS_INVALIDEZ , B.NUM_CONTR_VINCULO , B.COD_CORRESP_BANC , B.NUM_PRAZO_FIN , B.COD_OPER_CREDITO , C.OPCAO_COBER , C.COD_PLANO , B.COD_USUARIO , C.NUM_PROPOSTA_SIVPF , C.COD_PESSOA , C.NUM_SICOB , C.DATA_PROPOSTA , C.COD_PRODUTO_SIVPF , C.COD_EMPRESA_SIVPF , C.AGECOBR , C.DIA_DEBITO , C.OPCAOPAG , C.AGECTADEB , C.OPRCTADEB , C.NUMCTADEB , C.DIGCTADEB , C.PERC_DESCONTO , C.NRMATRVEN , C.AGECTAVEN , C.OPRCTAVEN , C.NUMCTAVEN , C.DIGCTAVEN , C.CGC_CONVENENTE , C.NOME_CONVENENTE , C.NRMATRCON , C.DTQITBCO , C.VAL_PAGO , C.AGEPGTO , C.VAL_TARIFA , C.VAL_IOF , C.DATA_CREDITO , C.VAL_COMISSAO , C.SIT_PROPOSTA , C.COD_USUARIO , C.CANAL_PROPOSTA , C.NSAS_SIVPF , C.ORIGEM_PROPOSTA , C.TIMESTAMP , C.NSL , C.NSAC_SIVPF , C.NOME_CONJUGE , C.DATA_NASC_CONJUGE , C.PROFISSAO_CONJUGE , C.FAIXA_RENDA_IND , C.FAIXA_RENDA_FAM , C.IND_TP_PROPOSTA , C.IND_TIPO_CONTA , A.COD_PRODUTO , A.PERI_PAGAMENTO , A.DESCONTO_ADESAO , A.NOME_PRODUTO , D.RAMO_EMISSOR FROM SEGUROS.PRODUTOS_VG A , SEGUROS.PROP_SASSE_VIDA B , SEGUROS.PROPOSTA_FIDELIZ C , SEGUROS.APOLICES D WHERE A.ESTR_COBR = 'MULT' AND A.RAMO <> 77 AND B.NUM_APOLICE = A.NUM_APOLICE AND B.COD_SUBGRUPO = A.COD_SUBGRUPO AND B.NUM_APOLICE = D.NUM_APOLICE AND C.NUM_IDENTIFICACAO = B.NUM_IDENTIFICACAO AND C.SIT_PROPOSTA IN ( 'ENV' , 'POV' , 'DEC' ) AND C.ORIGEM_PROPOSTA = 1000 UNION SELECT B.NUM_APOLICE , B.COD_SUBGRUPO , B.NUM_IDENTIFICACAO , B.DPS_TITULAR , B.DPS_CONJUGE , B.APOS_INVALIDEZ , B.NUM_CONTR_VINCULO , B.COD_CORRESP_BANC , B.NUM_PRAZO_FIN , B.COD_OPER_CREDITO , C.OPCAO_COBER , C.COD_PLANO , B.COD_USUARIO , C.NUM_PROPOSTA_SIVPF , C.COD_PESSOA , C.NUM_SICOB , C.DATA_PROPOSTA , C.COD_PRODUTO_SIVPF , C.COD_EMPRESA_SIVPF , C.AGECOBR , C.DIA_DEBITO , C.OPCAOPAG , C.AGECTADEB , C.OPRCTADEB , C.NUMCTADEB , C.DIGCTADEB , C.PERC_DESCONTO , C.NRMATRVEN , C.AGECTAVEN , C.OPRCTAVEN , C.NUMCTAVEN , C.DIGCTAVEN , C.CGC_CONVENENTE , C.NOME_CONVENENTE , C.NRMATRCON , C.DTQITBCO , C.VAL_PAGO , C.AGEPGTO , C.VAL_TARIFA , C.VAL_IOF , C.DATA_CREDITO , C.VAL_COMISSAO , C.SIT_PROPOSTA , C.COD_USUARIO , C.CANAL_PROPOSTA , C.NSAS_SIVPF , C.ORIGEM_PROPOSTA , C.TIMESTAMP , C.NSL , C.NSAC_SIVPF , C.NOME_CONJUGE , C.DATA_NASC_CONJUGE , C.PROFISSAO_CONJUGE , C.FAIXA_RENDA_IND , C.FAIXA_RENDA_FAM , C.IND_TP_PROPOSTA , C.IND_TIPO_CONTA , A.COD_PRODUTO , A.PERI_PAGAMENTO , A.DESCONTO_ADESAO , A.NOME_PRODUTO , D.RAMO_EMISSOR FROM SEGUROS.PRODUTOS_VG A , SEGUROS.PROP_SASSE_VIDA B , SEGUROS.PROPOSTA_FIDELIZ C , SEGUROS.APOLICES D WHERE A.ESTR_COBR = 'MULT' AND A.RAMO <> 77 AND B.NUM_APOLICE = A.NUM_APOLICE AND B.COD_SUBGRUPO = A.COD_SUBGRUPO AND B.NUM_APOLICE = D.NUM_APOLICE AND C.NUM_IDENTIFICACAO = B.NUM_IDENTIFICACAO AND C.SIT_PROPOSTA = 'ENV' AND C.ORIGEM_PROPOSTA IN (23, 1018, 1021, 1022, 1023, 1024, 1025) AND C.CANAL_PROPOSTA = 2 END-EXEC */
            CPROPOSTA = new VA0601B_CPROPOSTA(false);
            string GetQuery_CPROPOSTA()
            {
                var query = @$"SELECT B.NUM_APOLICE 
							, B.COD_SUBGRUPO 
							, B.NUM_IDENTIFICACAO 
							, B.DPS_TITULAR 
							, B.DPS_CONJUGE 
							, B.APOS_INVALIDEZ 
							, B.NUM_CONTR_VINCULO 
							, B.COD_CORRESP_BANC 
							, B.NUM_PRAZO_FIN 
							, B.COD_OPER_CREDITO 
							, C.OPCAO_COBER 
							, C.COD_PLANO 
							, B.COD_USUARIO 
							, C.NUM_PROPOSTA_SIVPF 
							, C.COD_PESSOA 
							, C.NUM_SICOB 
							, C.DATA_PROPOSTA 
							, C.COD_PRODUTO_SIVPF 
							, C.COD_EMPRESA_SIVPF 
							, C.AGECOBR 
							, C.DIA_DEBITO 
							, C.OPCAOPAG 
							, C.AGECTADEB 
							, C.OPRCTADEB 
							, C.NUMCTADEB 
							, C.DIGCTADEB 
							, C.PERC_DESCONTO 
							, C.NRMATRVEN 
							, C.AGECTAVEN 
							, C.OPRCTAVEN 
							, C.NUMCTAVEN 
							, C.DIGCTAVEN 
							, C.CGC_CONVENENTE 
							, C.NOME_CONVENENTE 
							, C.NRMATRCON 
							, C.DTQITBCO 
							, C.VAL_PAGO 
							, C.AGEPGTO 
							, C.VAL_TARIFA 
							, C.VAL_IOF 
							, C.DATA_CREDITO 
							, C.VAL_COMISSAO 
							, C.SIT_PROPOSTA 
							, C.COD_USUARIO 
							, C.CANAL_PROPOSTA 
							, C.NSAS_SIVPF 
							, C.ORIGEM_PROPOSTA 
							, C.TIMESTAMP 
							, C.NSL 
							, C.NSAC_SIVPF 
							, C.NOME_CONJUGE 
							, C.DATA_NASC_CONJUGE 
							, C.PROFISSAO_CONJUGE 
							, C.FAIXA_RENDA_IND 
							, C.FAIXA_RENDA_FAM 
							, C.IND_TP_PROPOSTA 
							, C.IND_TIPO_CONTA 
							, A.COD_PRODUTO 
							, A.PERI_PAGAMENTO 
							, A.DESCONTO_ADESAO 
							, A.NOME_PRODUTO 
							, D.RAMO_EMISSOR 
							FROM SEGUROS.PRODUTOS_VG A 
							, SEGUROS.PROP_SASSE_VIDA B 
							, SEGUROS.PROPOSTA_FIDELIZ C 
							, SEGUROS.APOLICES D 
							WHERE A.ESTR_COBR = 'MULT' 
							AND A.RAMO <> 77 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.COD_SUBGRUPO = A.COD_SUBGRUPO 
							AND B.NUM_APOLICE = D.NUM_APOLICE 
							AND C.NUM_IDENTIFICACAO = B.NUM_IDENTIFICACAO 
							AND C.SIT_PROPOSTA = 'ENV' 
							AND C.COD_PRODUTO_SIVPF IN (06
							, 07
							, 11
							, 13
							, 
							37
							, 46
							, 54) 
							UNION 
							SELECT B.NUM_APOLICE 
							, B.COD_SUBGRUPO 
							, B.NUM_IDENTIFICACAO 
							, B.DPS_TITULAR 
							, B.DPS_CONJUGE 
							, B.APOS_INVALIDEZ 
							, B.NUM_CONTR_VINCULO 
							, B.COD_CORRESP_BANC 
							, B.NUM_PRAZO_FIN 
							, B.COD_OPER_CREDITO 
							, C.OPCAO_COBER 
							, C.COD_PLANO 
							, B.COD_USUARIO 
							, C.NUM_PROPOSTA_SIVPF 
							, C.COD_PESSOA 
							, C.NUM_SICOB 
							, C.DATA_PROPOSTA 
							, C.COD_PRODUTO_SIVPF 
							, C.COD_EMPRESA_SIVPF 
							, C.AGECOBR 
							, C.DIA_DEBITO 
							, C.OPCAOPAG 
							, C.AGECTADEB 
							, C.OPRCTADEB 
							, C.NUMCTADEB 
							, C.DIGCTADEB 
							, C.PERC_DESCONTO 
							, C.NRMATRVEN 
							, C.AGECTAVEN 
							, C.OPRCTAVEN 
							, C.NUMCTAVEN 
							, C.DIGCTAVEN 
							, C.CGC_CONVENENTE 
							, C.NOME_CONVENENTE 
							, C.NRMATRCON 
							, C.DTQITBCO 
							, C.VAL_PAGO 
							, C.AGEPGTO 
							, C.VAL_TARIFA 
							, C.VAL_IOF 
							, C.DATA_CREDITO 
							, C.VAL_COMISSAO 
							, C.SIT_PROPOSTA 
							, C.COD_USUARIO 
							, C.CANAL_PROPOSTA 
							, C.NSAS_SIVPF 
							, C.ORIGEM_PROPOSTA 
							, C.TIMESTAMP 
							, C.NSL 
							, C.NSAC_SIVPF 
							, C.NOME_CONJUGE 
							, C.DATA_NASC_CONJUGE 
							, C.PROFISSAO_CONJUGE 
							, C.FAIXA_RENDA_IND 
							, C.FAIXA_RENDA_FAM 
							, C.IND_TP_PROPOSTA 
							, C.IND_TIPO_CONTA 
							, A.COD_PRODUTO 
							, A.PERI_PAGAMENTO 
							, A.DESCONTO_ADESAO 
							, A.NOME_PRODUTO 
							, D.RAMO_EMISSOR 
							FROM SEGUROS.PRODUTOS_VG A 
							, SEGUROS.PROP_SASSE_VIDA B 
							, SEGUROS.PROPOSTA_FIDELIZ C 
							, SEGUROS.APOLICES D 
							WHERE A.ESTR_COBR = 'MULT' 
							AND A.RAMO <> 77 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.COD_SUBGRUPO = A.COD_SUBGRUPO 
							AND B.NUM_APOLICE = D.NUM_APOLICE 
							AND C.NUM_IDENTIFICACAO = B.NUM_IDENTIFICACAO 
							AND C.SIT_PROPOSTA = 'POV' 
							AND C.COD_PRODUTO_SIVPF IN (06
							, 07
							, 11
							, 13
							, 
							37
							, 46
							, 54) 
							UNION 
							SELECT B.NUM_APOLICE 
							, B.COD_SUBGRUPO 
							, B.NUM_IDENTIFICACAO 
							, B.DPS_TITULAR 
							, B.DPS_CONJUGE 
							, B.APOS_INVALIDEZ 
							, B.NUM_CONTR_VINCULO 
							, B.COD_CORRESP_BANC 
							, B.NUM_PRAZO_FIN 
							, B.COD_OPER_CREDITO 
							, C.OPCAO_COBER 
							, C.COD_PLANO 
							, B.COD_USUARIO 
							, C.NUM_PROPOSTA_SIVPF 
							, C.COD_PESSOA 
							, C.NUM_SICOB 
							, C.DATA_PROPOSTA 
							, C.COD_PRODUTO_SIVPF 
							, C.COD_EMPRESA_SIVPF 
							, C.AGECOBR 
							, C.DIA_DEBITO 
							, C.OPCAOPAG 
							, C.AGECTADEB 
							, C.OPRCTADEB 
							, C.NUMCTADEB 
							, C.DIGCTADEB 
							, C.PERC_DESCONTO 
							, C.NRMATRVEN 
							, C.AGECTAVEN 
							, C.OPRCTAVEN 
							, C.NUMCTAVEN 
							, C.DIGCTAVEN 
							, C.CGC_CONVENENTE 
							, C.NOME_CONVENENTE 
							, C.NRMATRCON 
							, C.DTQITBCO 
							, C.VAL_PAGO 
							, C.AGEPGTO 
							, C.VAL_TARIFA 
							, C.VAL_IOF 
							, C.DATA_CREDITO 
							, C.VAL_COMISSAO 
							, C.SIT_PROPOSTA 
							, C.COD_USUARIO 
							, C.CANAL_PROPOSTA 
							, C.NSAS_SIVPF 
							, C.ORIGEM_PROPOSTA 
							, C.TIMESTAMP 
							, C.NSL 
							, C.NSAC_SIVPF 
							, C.NOME_CONJUGE 
							, C.DATA_NASC_CONJUGE 
							, C.PROFISSAO_CONJUGE 
							, C.FAIXA_RENDA_IND 
							, C.FAIXA_RENDA_FAM 
							, C.IND_TP_PROPOSTA 
							, C.IND_TIPO_CONTA 
							, A.COD_PRODUTO 
							, A.PERI_PAGAMENTO 
							, A.DESCONTO_ADESAO 
							, A.NOME_PRODUTO 
							, D.RAMO_EMISSOR 
							FROM SEGUROS.PRODUTOS_VG A 
							, SEGUROS.PROP_SASSE_VIDA B 
							, SEGUROS.PROPOSTA_FIDELIZ C 
							, SEGUROS.APOLICES D 
							WHERE A.ESTR_COBR = 'MULT' 
							AND A.RAMO <> 77 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.COD_SUBGRUPO = A.COD_SUBGRUPO 
							AND B.NUM_APOLICE = D.NUM_APOLICE 
							AND C.NUM_IDENTIFICACAO = B.NUM_IDENTIFICACAO 
							AND C.SIT_PROPOSTA = 'DEC' 
							AND C.COD_PRODUTO_SIVPF IN (06
							, 07
							, 11
							, 13
							, 
							37
							, 46
							, 54) 
							UNION 
							SELECT B.NUM_APOLICE 
							, B.COD_SUBGRUPO 
							, B.NUM_IDENTIFICACAO 
							, B.DPS_TITULAR 
							, B.DPS_CONJUGE 
							, B.APOS_INVALIDEZ 
							, B.NUM_CONTR_VINCULO 
							, B.COD_CORRESP_BANC 
							, B.NUM_PRAZO_FIN 
							, B.COD_OPER_CREDITO 
							, C.OPCAO_COBER 
							, C.COD_PLANO 
							, B.COD_USUARIO 
							, C.NUM_PROPOSTA_SIVPF 
							, C.COD_PESSOA 
							, C.NUM_SICOB 
							, C.DATA_PROPOSTA 
							, C.COD_PRODUTO_SIVPF 
							, C.COD_EMPRESA_SIVPF 
							, C.AGECOBR 
							, C.DIA_DEBITO 
							, C.OPCAOPAG 
							, C.AGECTADEB 
							, C.OPRCTADEB 
							, C.NUMCTADEB 
							, C.DIGCTADEB 
							, C.PERC_DESCONTO 
							, C.NRMATRVEN 
							, C.AGECTAVEN 
							, C.OPRCTAVEN 
							, C.NUMCTAVEN 
							, C.DIGCTAVEN 
							, C.CGC_CONVENENTE 
							, C.NOME_CONVENENTE 
							, C.NRMATRCON 
							, C.DTQITBCO 
							, C.VAL_PAGO 
							, C.AGEPGTO 
							, C.VAL_TARIFA 
							, C.VAL_IOF 
							, C.DATA_CREDITO 
							, C.VAL_COMISSAO 
							, C.SIT_PROPOSTA 
							, C.COD_USUARIO 
							, C.CANAL_PROPOSTA 
							, C.NSAS_SIVPF 
							, C.ORIGEM_PROPOSTA 
							, C.TIMESTAMP 
							, C.NSL 
							, C.NSAC_SIVPF 
							, C.NOME_CONJUGE 
							, C.DATA_NASC_CONJUGE 
							, C.PROFISSAO_CONJUGE 
							, C.FAIXA_RENDA_IND 
							, C.FAIXA_RENDA_FAM 
							, C.IND_TP_PROPOSTA 
							, C.IND_TIPO_CONTA 
							, A.COD_PRODUTO 
							, A.PERI_PAGAMENTO 
							, A.DESCONTO_ADESAO 
							, A.NOME_PRODUTO 
							, D.RAMO_EMISSOR 
							FROM SEGUROS.PRODUTOS_VG A 
							, SEGUROS.PROP_SASSE_VIDA B 
							, SEGUROS.PROPOSTA_FIDELIZ C 
							, SEGUROS.APOLICES D 
							WHERE A.ESTR_COBR = 'MULT' 
							AND A.RAMO <> 77 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.COD_SUBGRUPO = A.COD_SUBGRUPO 
							AND B.NUM_APOLICE = D.NUM_APOLICE 
							AND C.NUM_IDENTIFICACAO = B.NUM_IDENTIFICACAO 
							AND C.SIT_PROPOSTA IN ( 'ENV'
							, 'POV'
							, 'DEC' ) 
							AND C.ORIGEM_PROPOSTA = 1000 
							UNION 
							SELECT B.NUM_APOLICE 
							, B.COD_SUBGRUPO 
							, B.NUM_IDENTIFICACAO 
							, B.DPS_TITULAR 
							, B.DPS_CONJUGE 
							, B.APOS_INVALIDEZ 
							, B.NUM_CONTR_VINCULO 
							, B.COD_CORRESP_BANC 
							, B.NUM_PRAZO_FIN 
							, B.COD_OPER_CREDITO 
							, C.OPCAO_COBER 
							, C.COD_PLANO 
							, B.COD_USUARIO 
							, C.NUM_PROPOSTA_SIVPF 
							, C.COD_PESSOA 
							, C.NUM_SICOB 
							, C.DATA_PROPOSTA 
							, C.COD_PRODUTO_SIVPF 
							, C.COD_EMPRESA_SIVPF 
							, C.AGECOBR 
							, C.DIA_DEBITO 
							, C.OPCAOPAG 
							, C.AGECTADEB 
							, C.OPRCTADEB 
							, C.NUMCTADEB 
							, C.DIGCTADEB 
							, C.PERC_DESCONTO 
							, C.NRMATRVEN 
							, C.AGECTAVEN 
							, C.OPRCTAVEN 
							, C.NUMCTAVEN 
							, C.DIGCTAVEN 
							, C.CGC_CONVENENTE 
							, C.NOME_CONVENENTE 
							, C.NRMATRCON 
							, C.DTQITBCO 
							, C.VAL_PAGO 
							, C.AGEPGTO 
							, C.VAL_TARIFA 
							, C.VAL_IOF 
							, C.DATA_CREDITO 
							, C.VAL_COMISSAO 
							, C.SIT_PROPOSTA 
							, C.COD_USUARIO 
							, C.CANAL_PROPOSTA 
							, C.NSAS_SIVPF 
							, C.ORIGEM_PROPOSTA 
							, C.TIMESTAMP 
							, C.NSL 
							, C.NSAC_SIVPF 
							, C.NOME_CONJUGE 
							, C.DATA_NASC_CONJUGE 
							, C.PROFISSAO_CONJUGE 
							, C.FAIXA_RENDA_IND 
							, C.FAIXA_RENDA_FAM 
							, C.IND_TP_PROPOSTA 
							, C.IND_TIPO_CONTA 
							, A.COD_PRODUTO 
							, A.PERI_PAGAMENTO 
							, A.DESCONTO_ADESAO 
							, A.NOME_PRODUTO 
							, D.RAMO_EMISSOR 
							FROM SEGUROS.PRODUTOS_VG A 
							, SEGUROS.PROP_SASSE_VIDA B 
							, SEGUROS.PROPOSTA_FIDELIZ C 
							, SEGUROS.APOLICES D 
							WHERE A.ESTR_COBR = 'MULT' 
							AND A.RAMO <> 77 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.COD_SUBGRUPO = A.COD_SUBGRUPO 
							AND B.NUM_APOLICE = D.NUM_APOLICE 
							AND C.NUM_IDENTIFICACAO = B.NUM_IDENTIFICACAO 
							AND C.SIT_PROPOSTA = 'ENV' 
							AND C.ORIGEM_PROPOSTA IN 
							(23
							, 1018
							, 1021
							, 1022
							, 1023
							, 1024
							, 1025) 
							AND C.CANAL_PROPOSTA = 2";

                return query;
            }
            CPROPOSTA.GetQueryEvent += GetQuery_CPROPOSTA;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-PROPOSTA-DB-OPEN-1 */
        public void R0900_00_DECLARE_PROPOSTA_DB_OPEN_1()
        {
            /*" -1661- EXEC SQL OPEN CPROPOSTA END-EXEC. */

            CPROPOSTA.Open();

        }

        [StopWatch]
        /*" R1510-00-SELECT-RCAPCOMP-DB-DECLARE-1 */
        public void R1510_00_SELECT_RCAPCOMP_DB_DECLARE_1()
        {
            /*" -4286- EXEC SQL DECLARE C01_RCAPCOMP CURSOR FOR SELECT BCO_AVISO, AGE_AVISO, NUM_AVISO_CREDITO, DATA_MOVIMENTO, DATA_RCAP, COD_OPERACAO FROM SEGUROS.RCAP_COMPLEMENTAR WHERE COD_FONTE = :DCLRCAPS.RCAPS-COD-FONTE AND NUM_RCAP = :DCLRCAPS.RCAPS-NUM-RCAP AND NUM_RCAP_COMPLEMEN = 0 ORDER BY COD_OPERACAO DESC END-EXEC */
            C01_RCAPCOMP = new VA0601B_C01_RCAPCOMP(true);
            string GetQuery_C01_RCAPCOMP()
            {
                var query = @$"SELECT BCO_AVISO
							, 
							AGE_AVISO
							, 
							NUM_AVISO_CREDITO
							, 
							DATA_MOVIMENTO
							, 
							DATA_RCAP
							, 
							COD_OPERACAO 
							FROM SEGUROS.RCAP_COMPLEMENTAR 
							WHERE COD_FONTE = '{RCAPS.DCLRCAPS.RCAPS_COD_FONTE}' 
							AND NUM_RCAP = '{RCAPS.DCLRCAPS.RCAPS_NUM_RCAP}' 
							AND NUM_RCAP_COMPLEMEN = 0 
							ORDER BY COD_OPERACAO DESC";

                return query;
            }
            C01_RCAPCOMP.GetQueryEvent += GetQuery_C01_RCAPCOMP;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-PROPOSTA-SECTION */
        private void R0910_00_FETCH_PROPOSTA_SECTION()
        {
            /*" -1680- MOVE 'R0910-00-FETCH-PROPOSTA     ' TO PARAGRAFO. */
            _.Move("R0910-00-FETCH-PROPOSTA     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1683- MOVE 'FETCH CPROPOSTA             ' TO COMANDO. */
            _.Move("FETCH CPROPOSTA             ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1754- PERFORM R0910_00_FETCH_PROPOSTA_DB_FETCH_1 */

            R0910_00_FETCH_PROPOSTA_DB_FETCH_1();

            /*" -1757- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1757- PERFORM R0910_00_FETCH_PROPOSTA_DB_CLOSE_1 */

                R0910_00_FETCH_PROPOSTA_DB_CLOSE_1();

                /*" -1759- MOVE 1 TO WS-EOR */
                _.Move(1, WORK_AREA.WS_EOR);

                /*" -1760- GO TO R0910-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                return;

                /*" -1761- ELSE */
            }
            else
            {


                /*" -1763- IF (SQLCODE NOT EQUAL 100) AND (SQLCODE NOT EQUAL 0) */

                if ((DB.SQLCODE != 100) && (DB.SQLCODE != 0))
                {

                    /*" -1765- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1767- ADD 1 TO AC-L-MOVIMENTO */
            WORK_AREA.AC_L_MOVIMENTO.Value = WORK_AREA.AC_L_MOVIMENTO + 1;

            /*" -1770- MOVE PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO W-NUM-PROPOSTA. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, WORK_AREA.W_NUM_PROPOSTA);

            /*" -1779- MOVE PROPOFID-ORIGEM-PROPOSTA OF DCLPROPOSTA-FIDELIZ TO W-ORIGEM-PROPOSTA */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA, WORK_AREA.W_ORIGEM_PROPOSTA);

            /*" -1781- IF PROPOFID-OPCAOPAG OF DCLPROPOSTA-FIDELIZ EQUAL '3' OR ORIGEM-AUTO-COMPRA-IBC OR ORIGEM-AUTO-COMPRA-LOJA */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAOPAG == "3" || WORK_AREA.W_ORIGEM_PROPOSTA["ORIGEM_AUTO_COMPRA_IBC"] || WORK_AREA.W_ORIGEM_PROPOSTA["ORIGEM_AUTO_COMPRA_LOJA"])
            {

                /*" -1782- CONTINUE */

                /*" -1783- ELSE */
            }
            else
            {


                /*" -1785- PERFORM R0911-00-SELECT-RCAPS */

                R0911_00_SELECT_RCAPS_SECTION();

                /*" -1786- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1787- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -1789- ADD 1 TO WS-QTD-SEM-RCAPS */
                        WS_QTD_SEM_RCAPS.Value = WS_QTD_SEM_RCAPS + 1;

                        /*" -1790- GO TO R0910-00-FETCH-PROPOSTA */
                        new Task(() => R0910_00_FETCH_PROPOSTA_SECTION()).RunSynchronously(); //GOTO
                        return;//Recursividade detectada, cuidado...

                        /*" -1791- ELSE */
                    }
                    else
                    {


                        /*" -1792- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -1793- END-IF */
                    }


                    /*" -1794- END-IF */
                }


                /*" -1794- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R0910_CONTINUA */

            R0910_CONTINUA();

        }

        [StopWatch]
        /*" R0910-00-FETCH-PROPOSTA-DB-FETCH-1 */
        public void R0910_00_FETCH_PROPOSTA_DB_FETCH_1()
        {
            /*" -1754- EXEC SQL FETCH CPROPOSTA INTO :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE , :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO , :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-IDENTIFICACAO , :DCLPROP-SASSE-VIDA.PROPSSVD-DPS-TITULAR , :DCLPROP-SASSE-VIDA.PROPSSVD-DPS-CONJUGE , :DCLPROP-SASSE-VIDA.PROPSSVD-APOS-INVALIDEZ , :PROPSSVD-NUM-CONTR-VINCULO :VIND-NUM-CONTR , :PROPSSVD-COD-CORRESP-BANC :VIND-COD-CORRESP , :PROPSSVD-NUM-PRAZO-FIN :VIND-NUM-PRAZO , :PROPSSVD-COD-OPER-CREDITO :VIND-COD-OPER-CRED , :DCLPROPOSTA-FIDELIZ.PROPOFID-OPCAO-COBER , :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PLANO , :DCLPROP-SASSE-VIDA.PROPSSVD-COD-USUARIO , :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF, :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA , :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-SICOB , :DCLPROPOSTA-FIDELIZ.PROPOFID-DATA-PROPOSTA , :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PRODUTO-SIVPF , :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-EMPRESA-SIVPF , :DCLPROPOSTA-FIDELIZ.PROPOFID-AGECOBR , :DCLPROPOSTA-FIDELIZ.PROPOFID-DIA-DEBITO , :DCLPROPOSTA-FIDELIZ.PROPOFID-OPCAOPAG , :DCLPROPOSTA-FIDELIZ.PROPOFID-AGECTADEB , :DCLPROPOSTA-FIDELIZ.PROPOFID-OPRCTADEB , :DCLPROPOSTA-FIDELIZ.PROPOFID-NUMCTADEB , :DCLPROPOSTA-FIDELIZ.PROPOFID-DIGCTADEB , :DCLPROPOSTA-FIDELIZ.PROPOFID-PERC-DESCONTO , :DCLPROPOSTA-FIDELIZ.PROPOFID-NRMATRVEN , :DCLPROPOSTA-FIDELIZ.PROPOFID-AGECTAVEN , :DCLPROPOSTA-FIDELIZ.PROPOFID-OPRCTAVEN , :DCLPROPOSTA-FIDELIZ.PROPOFID-NUMCTAVEN , :DCLPROPOSTA-FIDELIZ.PROPOFID-DIGCTAVEN , :DCLPROPOSTA-FIDELIZ.PROPOFID-CGC-CONVENENTE , :DCLPROPOSTA-FIDELIZ.PROPOFID-NOME-CONVENENTE , :DCLPROPOSTA-FIDELIZ.PROPOFID-NRMATRCON , :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO , :DCLPROPOSTA-FIDELIZ.PROPOFID-VAL-PAGO , :DCLPROPOSTA-FIDELIZ.PROPOFID-AGEPGTO , :DCLPROPOSTA-FIDELIZ.PROPOFID-VAL-TARIFA , :DCLPROPOSTA-FIDELIZ.PROPOFID-VAL-IOF , :DCLPROPOSTA-FIDELIZ.PROPOFID-DATA-CREDITO , :DCLPROPOSTA-FIDELIZ.PROPOFID-VAL-COMISSAO , :DCLPROPOSTA-FIDELIZ.PROPOFID-SIT-PROPOSTA , :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-USUARIO , :DCLPROPOSTA-FIDELIZ.PROPOFID-CANAL-PROPOSTA , :DCLPROPOSTA-FIDELIZ.PROPOFID-NSAS-SIVPF , :DCLPROPOSTA-FIDELIZ.PROPOFID-ORIGEM-PROPOSTA , :DCLPROPOSTA-FIDELIZ.PROPOFID-TIMESTAMP , :DCLPROPOSTA-FIDELIZ.PROPOFID-NSL , :DCLPROPOSTA-FIDELIZ.PROPOFID-NSAC-SIVPF , :DCLPROPOSTA-FIDELIZ.PROPOFID-NOME-CONJUGE :VIND-NOME-CONJUGE , :DCLPROPOSTA-FIDELIZ.PROPOFID-DATA-NASC-CONJUGE :VIND-DATA-NASC-CONJUGE , :DCLPROPOSTA-FIDELIZ.PROPOFID-PROFISSAO-CONJUGE :VIND-PROFISSAO-CONJUGE , :DCLPROPOSTA-FIDELIZ.PROPOFID-FAIXA-RENDA-IND :VIND-RENDA-FIXA-IND , :DCLPROPOSTA-FIDELIZ.PROPOFID-FAIXA-RENDA-FAM :VIND-RENDA-FIXA-FAM , :DCLPROPOSTA-FIDELIZ.PROPOFID-IND-TP-PROPOSTA :VIND-TP-PROPOSTA , :DCLPROPOSTA-FIDELIZ.PROPOFID-IND-TIPO-CONTA :VIND-TP-CONTA , :DCLPRODUTOS-VG.PRODUVG-COD-PRODUTO , :DCLPRODUTOS-VG.PRODUVG-PERI-PAGAMENTO , :DCLPRODUTOS-VG.PRODUVG-DESCONTO-ADESAO , :DCLPRODUTOS-VG.PRODUVG-NOME-PRODUTO , :WHOST-RAMO END-EXEC. */

            if (CPROPOSTA.Fetch())
            {
                _.Move(CPROPOSTA.DCLPROP_SASSE_VIDA_PROPSSVD_NUM_APOLICE, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE);
                _.Move(CPROPOSTA.DCLPROP_SASSE_VIDA_PROPSSVD_COD_SUBGRUPO, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO);
                _.Move(CPROPOSTA.DCLPROP_SASSE_VIDA_PROPSSVD_NUM_IDENTIFICACAO, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_IDENTIFICACAO);
                _.Move(CPROPOSTA.DCLPROP_SASSE_VIDA_PROPSSVD_DPS_TITULAR, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_TITULAR);
                _.Move(CPROPOSTA.DCLPROP_SASSE_VIDA_PROPSSVD_DPS_CONJUGE, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_CONJUGE);
                _.Move(CPROPOSTA.DCLPROP_SASSE_VIDA_PROPSSVD_APOS_INVALIDEZ, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_APOS_INVALIDEZ);
                _.Move(CPROPOSTA.PROPSSVD_NUM_CONTR_VINCULO, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_CONTR_VINCULO);
                _.Move(CPROPOSTA.VIND_NUM_CONTR, VIND_NUM_CONTR);
                _.Move(CPROPOSTA.PROPSSVD_COD_CORRESP_BANC, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_CORRESP_BANC);
                _.Move(CPROPOSTA.VIND_COD_CORRESP, VIND_COD_CORRESP);
                _.Move(CPROPOSTA.PROPSSVD_NUM_PRAZO_FIN, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_PRAZO_FIN);
                _.Move(CPROPOSTA.VIND_NUM_PRAZO, VIND_NUM_PRAZO);
                _.Move(CPROPOSTA.PROPSSVD_COD_OPER_CREDITO, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_OPER_CREDITO);
                _.Move(CPROPOSTA.VIND_COD_OPER_CRED, VIND_COD_OPER_CRED);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_OPCAO_COBER, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PLANO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO);
                _.Move(CPROPOSTA.DCLPROP_SASSE_VIDA_PROPSSVD_COD_USUARIO, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_USUARIO);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_NUM_PROPOSTA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PESSOA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_NUM_SICOB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_DATA_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PRODUTO_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_COD_EMPRESA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_AGECOBR, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_DIA_DEBITO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIA_DEBITO);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_OPCAOPAG, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAOPAG);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_AGECTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTADEB);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_OPRCTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTADEB);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_NUMCTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTADEB);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_DIGCTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTADEB);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_PERC_DESCONTO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PERC_DESCONTO);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_NRMATRVEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_AGECTAVEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTAVEN);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_OPRCTAVEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTAVEN);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_NUMCTAVEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTAVEN);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_DIGCTAVEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTAVEN);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_CGC_CONVENENTE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CGC_CONVENENTE);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_NOME_CONVENENTE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NOME_CONVENENTE);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_NRMATRCON, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRCON);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_DTQITBCO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_PAGO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_AGEPGTO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGEPGTO);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_TARIFA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_TARIFA);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_IOF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_IOF);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_DATA_CREDITO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_CREDITO);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_COMISSAO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_COMISSAO);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_SIT_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_COD_USUARIO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_USUARIO);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_CANAL_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CANAL_PROPOSTA);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_NSAS_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAS_SIVPF);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_ORIGEM_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_TIMESTAMP, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_TIMESTAMP);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_NSL, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSL);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_NSAC_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAC_SIVPF);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_NOME_CONJUGE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NOME_CONJUGE);
                _.Move(CPROPOSTA.VIND_NOME_CONJUGE, VIND_NOME_CONJUGE);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_DATA_NASC_CONJUGE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_NASC_CONJUGE);
                _.Move(CPROPOSTA.VIND_DATA_NASC_CONJUGE, VIND_DATA_NASC_CONJUGE);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_PROFISSAO_CONJUGE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PROFISSAO_CONJUGE);
                _.Move(CPROPOSTA.VIND_PROFISSAO_CONJUGE, VIND_PROFISSAO_CONJUGE);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_FAIXA_RENDA_IND, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_IND);
                _.Move(CPROPOSTA.VIND_RENDA_FIXA_IND, VIND_RENDA_FIXA_IND);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_FAIXA_RENDA_FAM, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_FAM);
                _.Move(CPROPOSTA.VIND_RENDA_FIXA_FAM, VIND_RENDA_FIXA_FAM);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_IND_TP_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TP_PROPOSTA);
                _.Move(CPROPOSTA.VIND_TP_PROPOSTA, VIND_TP_PROPOSTA);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_IND_TIPO_CONTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TIPO_CONTA);
                _.Move(CPROPOSTA.VIND_TP_CONTA, VIND_TP_CONTA);
                _.Move(CPROPOSTA.DCLPRODUTOS_VG_PRODUVG_COD_PRODUTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO);
                _.Move(CPROPOSTA.DCLPRODUTOS_VG_PRODUVG_PERI_PAGAMENTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO);
                _.Move(CPROPOSTA.DCLPRODUTOS_VG_PRODUVG_DESCONTO_ADESAO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_DESCONTO_ADESAO);
                _.Move(CPROPOSTA.DCLPRODUTOS_VG_PRODUVG_NOME_PRODUTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_NOME_PRODUTO);
                _.Move(CPROPOSTA.WHOST_RAMO, WHOST_RAMO);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-PROPOSTA-DB-CLOSE-1 */
        public void R0910_00_FETCH_PROPOSTA_DB_CLOSE_1()
        {
            /*" -1757- EXEC SQL CLOSE CPROPOSTA END-EXEC */

            CPROPOSTA.Close();

        }

        [StopWatch]
        /*" R0910-CONTINUA */
        private void R0910_CONTINUA(bool isPerform = false)
        {
            /*" -1804- ADD 1 TO AC-CONTROLE. */
            WORK_AREA.AC_CONTROLE.Value = WORK_AREA.AC_CONTROLE + 1;

            /*" -1805- IF VIND-RENDA-FIXA-IND LESS ZERO */

            if (VIND_RENDA_FIXA_IND < 00)
            {

                /*" -1808- MOVE SPACES TO PROPOFID-FAIXA-RENDA-IND OF DCLPROPOSTA-FIDELIZ. */
                _.Move("", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_IND);
            }


            /*" -1809- IF VIND-RENDA-FIXA-FAM LESS ZERO */

            if (VIND_RENDA_FIXA_FAM < 00)
            {

                /*" -1812- MOVE SPACES TO PROPOFID-FAIXA-RENDA-FAM OF DCLPROPOSTA-FIDELIZ. */
                _.Move("", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_FAM);
            }


            /*" -1813- IF VIND-TP-PROPOSTA LESS ZERO */

            if (VIND_TP_PROPOSTA < 00)
            {

                /*" -1815- MOVE SPACES TO PROPOFID-IND-TP-PROPOSTA OF DCLPROPOSTA-FIDELIZ */
                _.Move("", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TP_PROPOSTA);

                /*" -1817- END-IF */
            }


            /*" -1818- SET WS-NAO-PROP-ELETRONICA TO TRUE */
            WS_INSERE_ANDAMENTO["WS_NAO_PROP_ELETRONICA"] = true;

            /*" -1820- SET WS-PREENCHEU-DPS TO TRUE */
            WS_SUBSCRICAO["WS_PREENCHEU_DPS"] = true;

            /*" -1821- IF AC-CONTROLE GREATER 99 */

            if (WORK_AREA.AC_CONTROLE > 99)
            {

                /*" -1822- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), WS_TIME);

                /*" -1827- MOVE WS-TIME-N TO WS-TIME-EDIT */
                _.Move(WS_TIME.WS_TIME_N, WS_TIME_EDIT);

                /*" -1829- MOVE ZEROS TO AC-CONTROLE. */
                _.Move(0, WORK_AREA.AC_CONTROLE);
            }


            /*" -1831- MOVE PROPSSVD-NUM-APOLICE OF DCLPROP-SASSE-VIDA TO WS-ATU-APOLICE. */
            _.Move(PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE, WORK_AREA.WS_CHAVE_ATU.WS_ATU_APOLICE);

            /*" -1834- MOVE PROPSSVD-NUM-APOLICE OF DCLPROP-SASSE-VIDA TO WS-ATU-SUBGRUPO. */
            _.Move(PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE, WORK_AREA.WS_CHAVE_ATU.WS_ATU_SUBGRUPO);

            /*" -1835- INITIALIZE WORK-TAB-ERROS-CERT */
            _.Initialize(
                WORK_TAB_ERROS_CERT
            );

            /*" -1836- MOVE ZEROS TO WS-I-ERRO */
            _.Move(0, WS_I_ERRO);

            /*" -1836- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R0911-00-SELECT-RCAPS-SECTION */
        private void R0911_00_SELECT_RCAPS_SECTION()
        {
            /*" -1846- MOVE 'R0911-00-SELECT-RCAPS       ' TO PARAGRAFO. */
            _.Move("R0911-00-SELECT-RCAPS       ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1847- MOVE 'SELECT RCAPS FILTRO         ' TO COMANDO. */
            _.Move("SELECT RCAPS FILTRO         ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1849- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1856- PERFORM R0911_00_SELECT_RCAPS_DB_SELECT_1 */

            R0911_00_SELECT_RCAPS_DB_SELECT_1();

            /*" -1859- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1860- DISPLAY 'VA0601B - PROBLEMAS NO ACESSO A RCAP - R0911 ' */
                _.Display($"VA0601B - PROBLEMAS NO ACESSO A RCAP - R0911 ");

                /*" -1862- DISPLAY '          NUMERO DO TITULO SICOB .. ' PROPOFID-NUM-SICOB */
                _.Display($"          NUMERO DO TITULO SICOB .. {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB}");

                /*" -1864- DISPLAY '          SQLCODE.................. ' SQLCODE */
                _.Display($"          SQLCODE.................. {DB.SQLCODE}");

                /*" -1870- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1871- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1878- PERFORM R0911_00_SELECT_RCAPS_DB_SELECT_2 */

                R0911_00_SELECT_RCAPS_DB_SELECT_2();

                /*" -1880- IF SQLCODE NOT EQUAL ZEROS AND 100 */

                if (!DB.SQLCODE.In("00", "100"))
                {

                    /*" -1881- DISPLAY 'VA0601B - PROBLEMAS NO ACESSO RCAP - R0911 ' */
                    _.Display($"VA0601B - PROBLEMAS NO ACESSO RCAP - R0911 ");

                    /*" -1883- DISPLAY '          NUMERO DO CERTIFICADO ... ' PROPOFID-NUM-PROPOSTA-SIVPF */
                    _.Display($"          NUMERO DO CERTIFICADO ... {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -1885- DISPLAY '          SQLCODE.................. ' SQLCODE */
                    _.Display($"          SQLCODE.................. {DB.SQLCODE}");

                    /*" -1886- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1887- END-IF */
                }


                /*" -1887- END-IF. */
            }


        }

        [StopWatch]
        /*" R0911-00-SELECT-RCAPS-DB-SELECT-1 */
        public void R0911_00_SELECT_RCAPS_DB_SELECT_1()
        {
            /*" -1856- EXEC SQL SELECT NOME_SEGURADO , AGE_COBRANCA INTO :RCAPS-NOME-SEGURADO, :RCAPS-AGE-COBRANCA FROM SEGUROS.RCAPS WHERE NUM_TITULO = :PROPOFID-NUM-SICOB END-EXEC. */

            var r0911_00_SELECT_RCAPS_DB_SELECT_1_Query1 = new R0911_00_SELECT_RCAPS_DB_SELECT_1_Query1()
            {
                PROPOFID_NUM_SICOB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB.ToString(),
            };

            var executed_1 = R0911_00_SELECT_RCAPS_DB_SELECT_1_Query1.Execute(r0911_00_SELECT_RCAPS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_NOME_SEGURADO, RCAPS.DCLRCAPS.RCAPS_NOME_SEGURADO);
                _.Move(executed_1.RCAPS_AGE_COBRANCA, RCAPS.DCLRCAPS.RCAPS_AGE_COBRANCA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0911_99_SAIDA*/

        [StopWatch]
        /*" R0911-00-SELECT-RCAPS-DB-SELECT-2 */
        public void R0911_00_SELECT_RCAPS_DB_SELECT_2()
        {
            /*" -1878- EXEC SQL SELECT NOME_SEGURADO , AGE_COBRANCA INTO :RCAPS-NOME-SEGURADO, :RCAPS-AGE-COBRANCA FROM SEGUROS.RCAPS WHERE NUM_CERTIFICADO = :PROPOFID-NUM-PROPOSTA-SIVPF END-EXEC */

            var r0911_00_SELECT_RCAPS_DB_SELECT_2_Query1 = new R0911_00_SELECT_RCAPS_DB_SELECT_2_Query1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R0911_00_SELECT_RCAPS_DB_SELECT_2_Query1.Execute(r0911_00_SELECT_RCAPS_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_NOME_SEGURADO, RCAPS.DCLRCAPS.RCAPS_NOME_SEGURADO);
                _.Move(executed_1.RCAPS_AGE_COBRANCA, RCAPS.DCLRCAPS.RCAPS_AGE_COBRANCA);
            }


        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -1898- MOVE 'R1000-00-PROCESSA-REGISTRO  ' TO PARAGRAFO. */
            _.Move("R1000-00-PROCESSA-REGISTRO  ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1899- DISPLAY ' ' */
            _.Display($" ");

            /*" -1904- DISPLAY PARAGRAFO '  PROPOSTA-SIVPF ' PROPOFID-NUM-PROPOSTA-SIVPF ' - ' PRODUVG-COD-PRODUTO OF DCLPRODUTOS-VG */

            $"{AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO}  PROPOSTA-SIVPF {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF} - {PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO}"
            .Display();

            /*" -1906- MOVE ZERO TO W-COBRANCA. */
            _.Move(0, WORK_AREA.W_COBRANCA);

            /*" -1921- MOVE 'NAO' TO WS-TEM-ERRO-1852 WS-TEM-ERRO-1829 WS-TEM-ERRO-DAD-CAD WS-TEM-ERRO-1893 WS-TEM-ERRO-1894 WS-TEM-ERRO-1896 WS-TEM-ERRO-1897 */
            _.Move("NAO", WORK_AREA.WS_TEM_ERRO_1852, WORK_AREA.WS_TEM_ERRO_1829, WORK_AREA.WS_TEM_ERRO_DAD_CAD, WORK_AREA.WS_TEM_ERRO_1893, WORK_AREA.WS_TEM_ERRO_1894, WORK_AREA.WS_TEM_ERRO_1896, WORK_AREA.WS_TEM_ERRO_1897);

            /*" -1922- MOVE 'N' TO WS-PROD-BALCAO */
            _.Move("N", WS_PROD_BALCAO);

            /*" -1944- IF PRODUVG-COD-PRODUTO OF DCLPRODUTOS-VG EQUAL 9314 OR 9353 OR 9352 OR 9351 OR 9310 OR 9329 OR 9320 OR 9321 OR 9332 OR 9359 OR 9360 OR 9361 OR 9327 OR 9328 OR 9334 OR 9356 OR 9357 OR 9358 OR JVPRD9310 OR JVPRD9314 OR JVPRD9353 OR JVPRD9352 OR JVPRD9351 OR JVPRD9320 OR JVPRD9321 OR JVPRD9332 OR JVPRD9359 OR JVPRD9360 OR JVPRD9361 OR JVPRD9327 OR JVPRD9328 OR JVPRD9334 OR JVPRD9356 OR JVPRD9357 OR JVPRD9358 OR JVPRD9329 */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("9314", "9353", "9352", "9351", "9310", "9329", "9320", "9321", "9332", "9359", "9360", "9361", "9327", "9328", "9334", "9356", "9357", "9358", JVBKINCL.JV_PRODUTOS.JVPRD9310.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9314.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9353.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9352.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9351.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9320.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9321.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9332.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9359.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9360.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9361.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9327.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9328.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9334.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9356.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9357.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9358.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9329.ToString()))
            {

                /*" -1945- MOVE 'S' TO WS-PROD-BALCAO */
                _.Move("S", WS_PROD_BALCAO);

                /*" -1949- END-IF */
            }


            /*" -1951- PERFORM R2203-00-SELECT-CONDITEC. */

            R2203_00_SELECT_CONDITEC_SECTION();

            /*" -1954- PERFORM R2205-00-SELECT-HISTCOBVA. */

            R2205_00_SELECT_HISTCOBVA_SECTION();

            /*" -1958- MOVE ZEROS TO WS-TEM-ERRO. */
            _.Move(0, WORK_AREA.WS_TEM_ERRO);

            /*" -1959- PERFORM R2200-00-SELECT-PESSOA. */

            R2200_00_SELECT_PESSOA_SECTION();

            /*" -1960- PERFORM R2210-00-SELECT-PESSOA-FISICA. */

            R2210_00_SELECT_PESSOA_FISICA_SECTION();

            /*" -1961- PERFORM R2215-00-SELECT-PROPOVA. */

            R2215_00_SELECT_PROPOVA_SECTION();

            /*" -1962- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1963- PERFORM R2220-00-OBTER-ENDERECO-CORRES */

                R2220_00_OBTER_ENDERECO_CORRES_SECTION();

                /*" -1964- ELSE */
            }
            else
            {


                /*" -1965- PERFORM R2222-00-OBTER-ENDERECO-CORRES */

                R2222_00_OBTER_ENDERECO_CORRES_SECTION();

                /*" -1967- END-IF */
            }


            /*" -1968- IF END-CORRES-N-CADASTRADO */

            if (WORK_AREA.W_ENDERECO["END_CORRES_N_CADASTRADO"])
            {

                /*" -1970- PERFORM R2225-00-OBTER-DEMAIS-ENDERECO */

                R2225_00_OBTER_DEMAIS_ENDERECO_SECTION();

                /*" -1971- IF DEMAIS-END-N-CADASTRADO */

                if (WORK_AREA.W_ENDERECO["DEMAIS_END_N_CADASTRADO"])
                {

                    /*" -1972- MOVE 501 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(501, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -1973- PERFORM R1100-00-GRAVA-TAB-ERRO */

                    R1100_00_GRAVA_TAB_ERRO_SECTION();

                    /*" -1974- END-IF */
                }


                /*" -1976- END-IF */
            }


            /*" -1978- PERFORM R2230-00-SELECT-PESSOA-FONE */

            R2230_00_SELECT_PESSOA_FONE_SECTION();

            /*" -1982- IF WHOST-DDD = ZEROS AND WHOST-FONE = ZEROS AND WHOST-FAX = ZEROS AND WHOST-TELEX = ZEROS */

            if (WHOST_DDD == 00 && WHOST_FONE == 00 && WHOST_FAX == 00 && WHOST_TELEX == 00)
            {

                /*" -1983- PERFORM R2232-00-SELECT-PESSOA-FONE */

                R2232_00_SELECT_PESSOA_FONE_SECTION();

                /*" -1984- ELSE */
            }
            else
            {


                /*" -1985- PERFORM R2235-00-UPDATE-PESSOA-FONE */

                R2235_00_UPDATE_PESSOA_FONE_SECTION();

                /*" -1987- END-IF */
            }


            /*" -1993- PERFORM R2236-00-SELECT-PESSOA-EMAIL */

            R2236_00_SELECT_PESSOA_EMAIL_SECTION();

            /*" -1996- MOVE PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO W-NUM-PROPOSTA */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, WORK_AREA.W_NUM_PROPOSTA);

            /*" -1997- IF CANAL-CORRETOR */

            if (WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_CORRETOR"])
            {

                /*" -1998- MOVE '3' TO PROFIDCO-IND-TP-INFORMACAO */
                _.Move("3", PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_IND_TP_INFORMACAO);

                /*" -1999- PERFORM R2240-00-SELECT-PROPFIDC */

                R2240_00_SELECT_PROPFIDC_SECTION();

                /*" -2000- IF PROFIDCO-INFORMACAO-COMPL = SPACES */

                if (PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_INFORMACAO_COMPL.IsEmpty())
                {

                    /*" -2001- MOVE '1' TO PROFIDCO-IND-TP-INFORMACAO */
                    _.Move("1", PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_IND_TP_INFORMACAO);

                    /*" -2002- PERFORM R2240-00-SELECT-PROPFIDC */

                    R2240_00_SELECT_PROPFIDC_SECTION();

                    /*" -2003- END-IF */
                }


                /*" -2004- ELSE */
            }
            else
            {


                /*" -2005- MOVE '1' TO PROFIDCO-IND-TP-INFORMACAO */
                _.Move("1", PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_IND_TP_INFORMACAO);

                /*" -2006- PERFORM R2240-00-SELECT-PROPFIDC */

                R2240_00_SELECT_PROPFIDC_SECTION();

                /*" -2015- END-IF */
            }


            /*" -2016- IF CANAL-CORRETOR */

            if (WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_CORRETOR"])
            {

                /*" -2018- MOVE PROFIDCO-INFORMACAO-COMPL TO WSRC-INF-SICAQWEB */
                _.Move(PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_INFORMACAO_COMPL, WSRC_INF_SICAQWEB);

                /*" -2031- IF WSRC-INF-SICAQWEB = SPACES OR (WSRC-NUM-CORRESPONDENTE NOT NUMERIC) OR (WSRC-DATA-CONTRATACAO NOT NUMERIC) OR (WSRC-HORA-CONTRATACAO NOT NUMERIC) OR (WSRC-DIA-CONTRATACAO < 01) OR (WSRC-DIA-CONTRATACAO > 31) OR (WSRC-MES-CONTRATACAO < 01) OR (WSRC-MES-CONTRATACAO > 12) OR (WSRC-ANO-CONTRATACAO = 0000) OR (WSRC-MM-CONTRATACAO > 59) OR (WSRC-SS-CONTRATACAO > 59) */

                if (WSRC_INF_SICAQWEB.IsEmpty() || (!WSRC_INF_SICAQWEB.WSRC_NUM_CORRESPONDENTE.IsNumeric()) || (!WSRC_INF_SICAQWEB.WSRC_DATA_CONTRATACAO.IsNumeric()) || (!WSRC_INF_SICAQWEB.WSRC_HORA_CONTRATACAO.IsNumeric()) || (WSRC_INF_SICAQWEB.WSRC_DATA_CONTRATACAO.WSRC_DIA_CONTRATACAO < 01) || (WSRC_INF_SICAQWEB.WSRC_DATA_CONTRATACAO.WSRC_DIA_CONTRATACAO > 31) || (WSRC_INF_SICAQWEB.WSRC_DATA_CONTRATACAO.WSRC_MES_CONTRATACAO < 01) || (WSRC_INF_SICAQWEB.WSRC_DATA_CONTRATACAO.WSRC_MES_CONTRATACAO > 12) || (WSRC_INF_SICAQWEB.WSRC_DATA_CONTRATACAO.WSRC_ANO_CONTRATACAO == 0000) || (WSRC_INF_SICAQWEB.WSRC_HORA_CONTRATACAO.WSRC_MM_CONTRATACAO > 59) || (WSRC_INF_SICAQWEB.WSRC_HORA_CONTRATACAO.WSRC_SS_CONTRATACAO > 59))
                {

                    /*" -2032- MOVE 1871 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(1871, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -2033- PERFORM R1100-00-GRAVA-TAB-ERRO */

                    R1100_00_GRAVA_TAB_ERRO_SECTION();

                    /*" -2034- PERFORM R3700-00-INSERT-RELATORIOS */

                    R3700_00_INSERT_RELATORIOS_SECTION();

                    /*" -2035- END-IF */
                }


                /*" -2039- END-IF */
            }


            /*" -2040- PERFORM R2300-00-TRATA-CLIENTES */

            R2300_00_TRATA_CLIENTES_SECTION();

            /*" -2041- IF CLIENTE-ERRO */

            if (WORK_AREA.W_TRATA_CLIENTE["CLIENTE_ERRO"])
            {

                /*" -2042- GO TO R1000-10-SAIDA */

                R1000_10_SAIDA(); //GOTO
                return;

                /*" -2047- END-IF */
            }


            /*" -2048- IF PROPOFID-COD-PRODUTO-SIVPF = 47 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 47)
            {

                /*" -2049- MOVE '4' TO PROFIDCO-IND-TP-INFORMACAO */
                _.Move("4", PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_IND_TP_INFORMACAO);

                /*" -2050- PERFORM R2240-00-SELECT-PROPFIDC */

                R2240_00_SELECT_PROPFIDC_SECTION();

                /*" -2051- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -2052- PERFORM R4300-00-TRATA-CLIENTE-EMPRESA */

                    R4300_00_TRATA_CLIENTE_EMPRESA_SECTION();

                    /*" -2053- PERFORM R4600-00-INSERT-CLIENTE-EMP */

                    R4600_00_INSERT_CLIENTE_EMP_SECTION();

                    /*" -2054- END-IF */
                }


                /*" -2058- END-IF */
            }


            /*" -2068- IF CPF OF DCLPESSOA-FISICA = 11111111111 OR 22222222222 OR 33333333333 OR 44444444444 OR 55555555555 OR 66666666666 OR 77777777777 OR 88888888888 OR 99999999999 */

            if (PESFIS.DCLPESSOA_FISICA.CPF.In("11111111111", "22222222222", "33333333333", "44444444444", "55555555555", "66666666666", "77777777777", "88888888888", "99999999999"))
            {

                /*" -2069- MOVE 402 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(402, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -2070- PERFORM R1100-00-GRAVA-TAB-ERRO */

                R1100_00_GRAVA_TAB_ERRO_SECTION();

                /*" -2072- END-IF */
            }


            /*" -2089- IF CPF OF DCLPESSOA-FISICA = 000000000000000 OR 000000000000091 OR 000000000000101 OR 000000000000191 OR 000000000001910 OR 000000000019100 OR 000001910000000 OR 000009100000000 OR 000010000000000 OR 000011000000000 OR 000011111111111 OR 000017500000000 OR 000019100000000 OR 000020000000000 OR 000022222222222 OR 000030000000000 OR 000040000000000 OR 000050000000000 OR 000060000000000 OR 000070000000000 OR 000080000000000 OR 000090000000000 OR 000099000000000 OR 000099900000000 OR 000099990000000 OR 000099999000000 OR 000099999964001 OR 000099999999990 OR 000099999999999 */

            if (PESFIS.DCLPESSOA_FISICA.CPF.In("000000000000000", "000000000000091", "000000000000101", "000000000000191", "000000000001910", "000000000019100", "000001910000000", "000009100000000", "000010000000000", "000011000000000", "000011111111111", "000017500000000", "000019100000000", "000020000000000", "000022222222222", "000030000000000", "000040000000000", "000050000000000", "000060000000000", "000070000000000", "000080000000000", "000090000000000", "000099000000000", "000099900000000", "000099990000000", "000099999000000", "000099999964001", "000099999999990", "000099999999999"))
            {

                /*" -2090- MOVE 402 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(402, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -2091- PERFORM R1100-00-GRAVA-TAB-ERRO */

                R1100_00_GRAVA_TAB_ERRO_SECTION();

                /*" -2112- END-IF */
            }


            /*" -2114- MOVE ' ' TO WS-SEG-LIBERADO */
            _.Move(" ", WS_SEG_LIBERADO);

            /*" -2129- IF PRODUVG-COD-PRODUTO OF DCLPRODUTOS-VG EQUAL 9320 OR 9321 OR 9327 OR 9328 OR 9332 OR 9334 OR 9359 OR 9360 OR 9361 OR 9356 OR 9357 OR 9358 OR JVPRD9320 OR JVPRD9321 OR JVPRD9327 OR JVPRD9328 OR JVPRD9332 OR JVPRD9334 OR JVPRD9359 OR JVPRD9360 OR JVPRD9361 OR JVPRD9356 OR JVPRD9357 OR JVPRD9358 */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("9320", "9321", "9327", "9328", "9332", "9334", "9359", "9360", "9361", "9356", "9357", "9358", JVBKINCL.JV_PRODUTOS.JVPRD9320.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9321.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9327.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9328.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9332.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9334.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9359.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9360.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9361.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9356.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9357.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9358.ToString()))
            {

                /*" -2130- PERFORM R1400-00-SELECT-PLANOS-VA */

                R1400_00_SELECT_PLANOS_VA_SECTION();

                /*" -2131- IF IMPMORNATU OF DCLPLANOS-VA-VGAP GREATER 600000 */

                if (PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU > 600000)
                {

                    /*" -2132- MOVE 'S' TO WS-SEG-LIBERADO */
                    _.Move("S", WS_SEG_LIBERADO);

                    /*" -2133- END-IF */
                }


                /*" -2135- END-IF */
            }


            /*" -2137- IF NOT CANAL-GITEL AND WS-SEG-LIBERADO NOT EQUAL 'S' */

            if (!WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_GITEL"] && WS_SEG_LIBERADO == "S")
            {

                /*" -2139- IF PROPSSVD-APOS-INVALIDEZ OF DCLPROP-SASSE-VIDA EQUAL 'N' */

                if (PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_APOS_INVALIDEZ == "N")
                {

                    /*" -2142- IF COD-CBO OF DCLPESSOA-FISICA GREATER ZEROS AND COD-CBO OF DCLPESSOA-FISICA LESS 1000 */

                    if (PESFIS.DCLPESSOA_FISICA.COD_CBO > 00 && PESFIS.DCLPESSOA_FISICA.COD_CBO < 1000)
                    {

                        /*" -2144- IF TAB-DESCR-CBO-C(COD-CBO OF DCLPESSOA-FISICA)(1:5) EQUAL 'APOSE' */

                        if (TAB_CBO1.TAB_CBO.FILLER_34[PESFIS.DCLPESSOA_FISICA.COD_CBO].TAB_DESCR_CBO_C.Substring(1, 5) == "APOSE")
                        {

                            /*" -2146- MOVE 1801 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                            _.Move(1801, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                            /*" -2147- PERFORM R1100-00-GRAVA-TAB-ERRO */

                            R1100_00_GRAVA_TAB_ERRO_SECTION();

                            /*" -2148- END-IF */
                        }


                        /*" -2149- END-IF */
                    }


                    /*" -2150- END-IF */
                }


                /*" -2152- END-IF */
            }


            /*" -2155- MOVE PROPSSVD-DPS-TITULAR OF DCLPROP-SASSE-VIDA(2:1) TO PROPSSVD-APOS-INVALIDEZ OF DCLPROP-SASSE-VIDA. */
            _.Move(PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_TITULAR.Substring(2, 1), PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_APOS_INVALIDEZ);

            /*" -2157- MOVE 'NAO' TO WS-TEM-ERRO-1807 */
            _.Move("NAO", WORK_AREA.WS_TEM_ERRO_1807);

            /*" -2158- IF WS-SEG-LIBERADO NOT EQUAL 'S' */

            if (WS_SEG_LIBERADO != "S")
            {

                /*" -2159- IF PROPSSVD-APOS-INVALIDEZ OF DCLPROP-SASSE-VIDA = 'S' */

                if (PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_APOS_INVALIDEZ == "S")
                {

                    /*" -2160- MOVE 1807 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(1807, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -2161- PERFORM R1100-00-GRAVA-TAB-ERRO */

                    R1100_00_GRAVA_TAB_ERRO_SECTION();

                    /*" -2162- MOVE 'SIM' TO WS-TEM-ERRO-1807 */
                    _.Move("SIM", WORK_AREA.WS_TEM_ERRO_1807);

                    /*" -2163- PERFORM R3700-00-INSERT-RELATORIOS */

                    R3700_00_INSERT_RELATORIOS_SECTION();

                    /*" -2164- END-IF */
                }


                /*" -2166- END-IF */
            }


            /*" -2167- IF WS-SEG-LIBERADO NOT EQUAL 'S' */

            if (WS_SEG_LIBERADO != "S")
            {

                /*" -2168- IF PROPSSVD-DPS-TITULAR OF DCLPROP-SASSE-VIDA(2:1) = 'S' */

                if (PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_TITULAR.Substring(2, 1) == "S")
                {

                    /*" -2169- MOVE 1807 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(1807, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -2170- PERFORM R1100-00-GRAVA-TAB-ERRO */

                    R1100_00_GRAVA_TAB_ERRO_SECTION();

                    /*" -2171- MOVE 'SIM' TO WS-TEM-ERRO-1807 */
                    _.Move("SIM", WORK_AREA.WS_TEM_ERRO_1807);

                    /*" -2172- PERFORM R3700-00-INSERT-RELATORIOS */

                    R3700_00_INSERT_RELATORIOS_SECTION();

                    /*" -2173- END-IF */
                }


                /*" -2215- END-IF */
            }


            /*" -2217- PERFORM R5634-00-SELECT-SEGUROS-PF-CBO */

            R5634_00_SELECT_SEGUROS_PF_CBO_SECTION();

            /*" -2218- IF WHOST-PROFISSAO EQUAL SPACES */

            if (WHOST_PROFISSAO.IsEmpty())
            {

                /*" -2220- IF COD-CBO OF DCLPESSOA-FISICA > ZEROS AND COD-CBO OF DCLPESSOA-FISICA < 1000 */

                if (PESFIS.DCLPESSOA_FISICA.COD_CBO > 00 && PESFIS.DCLPESSOA_FISICA.COD_CBO < 1000)
                {

                    /*" -2222- MOVE TAB-DESCR-CBO-C (COD-CBO OF DCLPESSOA-FISICA) TO WHOST-PROFISSAO */
                    _.Move(TAB_CBO1.TAB_CBO.FILLER_34[PESFIS.DCLPESSOA_FISICA.COD_CBO].TAB_DESCR_CBO_C, WHOST_PROFISSAO);

                    /*" -2223- END-IF */
                }


                /*" -2231- END-IF */
            }


            /*" -2233- IF PRODUVG-COD-PRODUTO OF DCLPRODUTOS-VG EQUAL 9703 OR 9705 */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("9703", "9705"))
            {

                /*" -2234- GO TO R1000-CONSISTE-DPS */

                R1000_CONSISTE_DPS(); //GOTO
                return;

                /*" -2245- END-IF */
            }


            /*" -2246- IF WS-SEG-LIBERADO EQUAL 'S' */

            if (WS_SEG_LIBERADO == "S")
            {

                /*" -2247- GO TO R1000-CONSISTE-CX-TRAB */

                R1000_CONSISTE_CX_TRAB(); //GOTO
                return;

                /*" -2253- END-IF */
            }


            /*" -2254- IF PROPOFID-COD-PRODUTO-SIVPF = 77 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 77)
            {

                /*" -2255- GO TO R1000-CONSISTE-CX-TRAB */

                R1000_CONSISTE_CX_TRAB(); //GOTO
                return;

                /*" -2262- END-IF */
            }


            /*" -2267- IF PRODUVG-COD-PRODUTO OF DCLPRODUTOS-VG EQUAL 9318 OR 9319 OR 9333 OR 9351 OR 9352 OR 9353 OR JVPRD9351 OR JVPRD9352 OR JVPRD9353 */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("9318", "9319", "9333", "9351", "9352", "9353", JVBKINCL.JV_PRODUTOS.JVPRD9351.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9352.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9353.ToString()))
            {

                /*" -2268- GO TO R1000-CONSISTE-CX-TRAB */

                R1000_CONSISTE_CX_TRAB(); //GOTO
                return;

                /*" -2270- END-IF */
            }


            /*" -2282- IF PROPSSVD-NUM-APOLICE OF DCLPROP-SASSE-VIDA = 109300001391 OR PROPSSVD-NUM-APOLICE OF DCLPROP-SASSE-VIDA = 109300001392 OR PROPSSVD-NUM-APOLICE OF DCLPROP-SASSE-VIDA = 109300001294 OR PROPSSVD-NUM-APOLICE OF DCLPROP-SASSE-VIDA = 109300000598 OR PROPSSVD-NUM-APOLICE OF DCLPROP-SASSE-VIDA = 109300001311 OR PROPSSVD-NUM-APOLICE OF DCLPROP-SASSE-VIDA = 109300002004 OR PROPSSVD-NUM-APOLICE OF DCLPROP-SASSE-VIDA = 109300002005 OR PROPSSVD-NUM-APOLICE OF DCLPROP-SASSE-VIDA = 3009300002005 OR PROPSSVD-NUM-APOLICE OF DCLPROP-SASSE-VIDA = 3009300012005 OR PROPSSVD-NUM-APOLICE OF DCLPROP-SASSE-VIDA = 109300002006 OR PROPSSVD-NUM-APOLICE OF DCLPROP-SASSE-VIDA = 3009300002006 OR PROPSSVD-NUM-APOLICE OF DCLPROP-SASSE-VIDA = 3009300012006 */

            if (PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE == 109300001391 || PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE == 109300001392 || PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE == 109300001294 || PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE == 109300000598 || PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE == 109300001311 || PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE == 109300002004 || PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE == 109300002005 || PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE == 3009300002005 || PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE == 3009300012005 || PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE == 109300002006 || PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE == 3009300002006 || PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE == 3009300012006)
            {

                /*" -2283- GO TO R1000-CONSISTE-CX-TRAB */

                R1000_CONSISTE_CX_TRAB(); //GOTO
                return;

                /*" -2285- END-IF */
            }


            /*" -2287- IF COD-CBO OF DCLPESSOA-FISICA EQUAL ZEROS AND WHOST-PROFISSAO EQUAL SPACES */

            if (PESFIS.DCLPESSOA_FISICA.COD_CBO == 00 && WHOST_PROFISSAO.IsEmpty())
            {

                /*" -2288- MOVE 1811 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1811, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -2289- PERFORM R1100-00-GRAVA-TAB-ERRO */

                R1100_00_GRAVA_TAB_ERRO_SECTION();

                /*" -2290- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -2294- GO TO R1000-CONTINUA. */

                R1000_CONTINUA(); //GOTO
                return;
            }


            /*" -2295- IF COD-CBO OF DCLPESSOA-FISICA EQUAL 994 */

            if (PESFIS.DCLPESSOA_FISICA.COD_CBO == 994)
            {

                /*" -2296- MOVE 1802 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1802, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -2297- PERFORM R1100-00-GRAVA-TAB-ERRO */

                R1100_00_GRAVA_TAB_ERRO_SECTION();

                /*" -2302- DISPLAY 'CERTIFICADO AGENTE POLICIAL        ' PROPOFID-NUM-PROPOSTA-SIVPF ' PRODUTO ' PROPOFID-COD-PRODUTO-SIVPF ' ERRO 1802' */

                $"CERTIFICADO AGENTE POLICIAL        {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF} PRODUTO {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF} ERRO 1802"
                .Display();

                /*" -2310- GO TO R1000-CONTINUA. */

                R1000_CONTINUA(); //GOTO
                return;
            }


            /*" -2311- IF WHOST-PROFISSAO(1:5) EQUAL 'APOSE' */

            if (WHOST_PROFISSAO.Substring(1, 5) == "APOSE")
            {

                /*" -2312- IF PROPSSVD-DPS-TITULAR(2:1) EQUAL 'S' */

                if (PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_TITULAR.Substring(2, 1) == "S")
                {

                    /*" -2317- DISPLAY 'CERTIFICADO APOSENTADO P/INVALIDEZ ' PROPOFID-NUM-PROPOSTA-SIVPF ' PRODUTO ' PROPOFID-COD-PRODUTO-SIVPF ' ERRO 1803' */

                    $"CERTIFICADO APOSENTADO P/INVALIDEZ {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF} PRODUTO {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF} ERRO 1803"
                    .Display();

                    /*" -2318- ELSE */
                }
                else
                {


                    /*" -2323- DISPLAY 'CERTIFICADO APOSENTADO S/INVALIDEZ' PROPOFID-NUM-PROPOSTA-SIVPF ' PRODUTO ' PROPOFID-COD-PRODUTO-SIVPF ' S/ERRO 1803' */

                    $"CERTIFICADO APOSENTADO S/INVALIDEZ{PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF} PRODUTO {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF} S/ERRO 1803"
                    .Display();

                    /*" -2324- END-IF */
                }


                /*" -2326- END-IF. */
            }


            /*" -2329- IF WHOST-PROFISSAO EQUAL SPACES OR WHOST-PROFISSAO EQUAL 'PROFISSAO NAO QUALIFICADA' OR WHOST-PROFISSAO EQUAL 'PROFISSAO NAO ENCONTRADA' */

            if (WHOST_PROFISSAO.IsEmpty() || WHOST_PROFISSAO == "PROFISSAO NAO QUALIFICADA" || WHOST_PROFISSAO == "PROFISSAO NAO ENCONTRADA")
            {

                /*" -2331- IF COD-CBO OF DCLPESSOA-FISICA > ZEROS AND COD-CBO OF DCLPESSOA-FISICA < 1000 */

                if (PESFIS.DCLPESSOA_FISICA.COD_CBO > 00 && PESFIS.DCLPESSOA_FISICA.COD_CBO < 1000)
                {

                    /*" -2333- MOVE TAB-DESCR-CBO-C (COD-CBO OF DCLPESSOA-FISICA) TO WHOST-PROFISSAO */
                    _.Move(TAB_CBO1.TAB_CBO.FILLER_34[PESFIS.DCLPESSOA_FISICA.COD_CBO].TAB_DESCR_CBO_C, WHOST_PROFISSAO);

                    /*" -2337- ELSE */
                }
                else
                {


                    /*" -2338- MOVE SPACES TO WHOST-PROFISSAO */
                    _.Move("", WHOST_PROFISSAO);

                    /*" -2339- MOVE 1811 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(1811, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -2340- PERFORM R1100-00-GRAVA-TAB-ERRO */

                    R1100_00_GRAVA_TAB_ERRO_SECTION();

                    /*" -2341- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                    _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                    /*" -2342- END-IF */
                }


                /*" -2362- IF WHOST-PROFISSAO(1:5) EQUAL 'POLIC' OR 'DELEG' OR 'MILIT' OR 'VIGIA' OR 'VIGIL' OR 'SEGUR' OR 'PILOT' OR 'INSTR' OR 'PARAQ' OR 'MOTOB' OR 'MOTOC' OR 'MOTOQ' OR 'MERGU' OR 'ALPIN' OR 'PERIT' OR 'SERVE' OR 'OUTRO' */

                if (WHOST_PROFISSAO.Substring(1, 5).In("POLIC", "DELEG", "MILIT", "VIGIA", "VIGIL", "SEGUR", "PILOT", "INSTR", "PARAQ", "MOTOB", "MOTOC", "MOTOQ", "MERGU", "ALPIN", "PERIT", "SERVE", "OUTRO"))
                {

                    /*" -2363- MOVE 1802 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(1802, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -2364- PERFORM R1100-00-GRAVA-TAB-ERRO */

                    R1100_00_GRAVA_TAB_ERRO_SECTION();

                    /*" -2365- END-IF */
                }


                /*" -2366- ELSE */
            }
            else
            {


                /*" -2386- IF WHOST-PROFISSAO(1:5) EQUAL 'POLIC' OR 'DELEG' OR 'MILIT' OR 'VIGIA' OR 'VIGIL' OR 'SEGUR' OR 'PILOT' OR 'INSTR' OR 'PARAQ' OR 'MOTOB' OR 'MOTOC' OR 'MOTOQ' OR 'MERGU' OR 'ALPIN' OR 'PERIT' OR 'SERVE' OR 'OUTRO' */

                if (WHOST_PROFISSAO.Substring(1, 5).In("POLIC", "DELEG", "MILIT", "VIGIA", "VIGIL", "SEGUR", "PILOT", "INSTR", "PARAQ", "MOTOB", "MOTOC", "MOTOQ", "MERGU", "ALPIN", "PERIT", "SERVE", "OUTRO"))
                {

                    /*" -2387- MOVE 1802 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(1802, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -2388- PERFORM R1100-00-GRAVA-TAB-ERRO */

                    R1100_00_GRAVA_TAB_ERRO_SECTION();

                    /*" -2389- END-IF */
                }


                /*" -2389- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R1000_CONTINUA */

            R1000_CONTINUA();

        }

        [StopWatch]
        /*" R1000-CONTINUA */
        private void R1000_CONTINUA(bool isPerform = false)
        {
            /*" -2395- IF PROPOFID-COD-PRODUTO-SIVPF = 7 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 7)
            {

                /*" -2396- GO TO R1000-CONSISTE-CX-TRAB */

                R1000_CONSISTE_CX_TRAB(); //GOTO
                return;

                /*" -2399- END-IF */
            }


            /*" -2403- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 46 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 46)
            {

                /*" -2404- INITIALIZE WHOST-IMPMORNATU */
                _.Initialize(
                    WHOST_IMPMORNATU
                );

                /*" -2405- PERFORM R1401-00-SELECT-PLANOS-VA */

                R1401_00_SELECT_PLANOS_VA_SECTION();

                /*" -2406- IF WHOST-IMPMORNATU <= 30000,00 */

                if (WHOST_IMPMORNATU <= 30000.00)
                {

                    /*" -2407- GO TO R1000-CONSISTE-CX-TRAB */

                    R1000_CONSISTE_CX_TRAB(); //GOTO
                    return;

                    /*" -2409- END-IF */
                }


                /*" -2411- END-IF */
            }


            /*" -2413- IF PROPSSVD-NUM-APOLICE OF DCLPROP-SASSE-VIDA = 109300001666 */

            if (PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE == 109300001666)
            {

                /*" -2414- GO TO R1000-CONSISTE-CX-TRAB */

                R1000_CONSISTE_CX_TRAB(); //GOTO
                return;

                /*" -2414- END-IF. */
            }


        }

        [StopWatch]
        /*" R1000-CONSISTE-DPS */
        private void R1000_CONSISTE_DPS(bool isPerform = false)
        {
            /*" -2427- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 7 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 7)
            {

                /*" -2429- GO TO R1000-CONSISTE-CX-TRAB */

                R1000_CONSISTE_CX_TRAB(); //GOTO
                return;

                /*" -2431- END-IF */
            }


            /*" -2433- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 9348 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 9348)
            {

                /*" -2434- GO TO R1000-CONSISTE-CX-TRAB */

                R1000_CONSISTE_CX_TRAB(); //GOTO
                return;

                /*" -2436- END-IF */
            }


            /*" -2438- IF PROPOFID-COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ = 46 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 46)
            {

                /*" -2440- IF PROPSSVD-DPS-TITULAR OF DCLPROP-SASSE-VIDA EQUAL 'SNNNNNNNNNNNNNNNNNNNNNNNN' */

                if (PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_TITULAR == "SNNNNNNNNNNNNNNNNNNNNNNNN")
                {

                    /*" -2441- CONTINUE */

                    /*" -2442- ELSE */
                }
                else
                {


                    /*" -2443- MOVE 1803 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(1803, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -2444- PERFORM R1100-00-GRAVA-TAB-ERRO */

                    R1100_00_GRAVA_TAB_ERRO_SECTION();

                    /*" -2445- END-IF */
                }


                /*" -2446- ELSE */
            }
            else
            {


                /*" -2448- IF PROPOFID-COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ = 37 NEXT SENTENCE */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 37)
                {

                    /*" -2449- ELSE */
                }
                else
                {


                    /*" -2457- IF PROPSSVD-DPS-TITULAR OF DCLPROP-SASSE-VIDA NOT EQUAL 'SNNNNNN' AND PROPSSVD-DPS-TITULAR OF DCLPROP-SASSE-VIDA NOT EQUAL 'SNNNNNS' AND PROPSSVD-DPS-TITULAR OF DCLPROP-SASSE-VIDA NOT EQUAL 'SNNNNN ' AND PROPSSVD-DPS-TITULAR OF DCLPROP-SASSE-VIDA NOT EQUAL 'SNNNNS ' */

                    if (PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_TITULAR != "SNNNNNN" && PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_TITULAR != "SNNNNNS" && PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_TITULAR != "SNNNNN " && PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_TITULAR != "SNNNNS ")
                    {

                        /*" -2458- MOVE 1803 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                        _.Move(1803, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                        /*" -2459- PERFORM R1100-00-GRAVA-TAB-ERRO */

                        R1100_00_GRAVA_TAB_ERRO_SECTION();

                        /*" -2464- DISPLAY 'CERTIFICADO REJEITADO P/DPS        ' PROPOFID-NUM-PROPOSTA-SIVPF ' PRODUTO ' PROPOFID-COD-PRODUTO-SIVPF ' ERRO 1803' */

                        $"CERTIFICADO REJEITADO P/DPS        {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF} PRODUTO {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF} ERRO 1803"
                        .Display();

                        /*" -2465- END-IF */
                    }


                    /*" -2466- END-IF */
                }


                /*" -2470- END-IF */
            }


            /*" -2471- IF CONDITEC-CARREGA-CONJUGE NOT EQUAL ZEROS */

            if (CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE != 00)
            {

                /*" -2472- IF PROPOFID-COD-PRODUTO-SIVPF NOT EQUAL 46 */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF != 46)
                {

                    /*" -2480- IF PROPSSVD-DPS-CONJUGE OF DCLPROP-SASSE-VIDA NOT EQUAL 'SNNNNNN' AND PROPSSVD-DPS-CONJUGE OF DCLPROP-SASSE-VIDA NOT EQUAL 'SNNNNNS' AND PROPSSVD-DPS-CONJUGE OF DCLPROP-SASSE-VIDA NOT EQUAL 'SNNNNN ' AND PROPSSVD-DPS-CONJUGE OF DCLPROP-SASSE-VIDA NOT EQUAL 'SNNNNS ' */

                    if (PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_CONJUGE != "SNNNNNN" && PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_CONJUGE != "SNNNNNS" && PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_CONJUGE != "SNNNNN " && PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_CONJUGE != "SNNNNS ")
                    {

                        /*" -2481- MOVE 1804 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                        _.Move(1804, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                        /*" -2482- PERFORM R1100-00-GRAVA-TAB-ERRO */

                        R1100_00_GRAVA_TAB_ERRO_SECTION();

                        /*" -2483- END-IF */
                    }


                    /*" -2494- END-IF */
                }


                /*" -2499- END-IF */
            }


            /*" -2500- IF CONDITEC-CARREGA-CONJUGE NOT EQUAL ZEROS */

            if (CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE != 00)
            {

                /*" -2501- PERFORM R1150-00-IDADE-CONJUGE */

                R1150_00_IDADE_CONJUGE_SECTION();

                /*" -2502- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 46 */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 46)
                {

                    /*" -2503- IF WHOST-IDADE-CONJUGE GREATER 70 */

                    if (WHOST_IDADE_CONJUGE > 70)
                    {

                        /*" -2504- MOVE 1865 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                        _.Move(1865, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                        /*" -2505- PERFORM R1100-00-GRAVA-TAB-ERRO */

                        R1100_00_GRAVA_TAB_ERRO_SECTION();

                        /*" -2506- END-IF */
                    }


                    /*" -2507- ELSE */
                }
                else
                {


                    /*" -2508- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 13 */

                    if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 13)
                    {

                        /*" -2509- IF WHOST-IDADE-CONJUGE GREATER 65 */

                        if (WHOST_IDADE_CONJUGE > 65)
                        {

                            /*" -2510- MOVE 1851 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                            _.Move(1851, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                            /*" -2511- PERFORM R1100-00-GRAVA-TAB-ERRO */

                            R1100_00_GRAVA_TAB_ERRO_SECTION();

                            /*" -2512- END-IF */
                        }


                        /*" -2513- END-IF */
                    }


                    /*" -2514- END-IF */
                }


                /*" -2519- END-IF */
            }


            /*" -2520- IF CONDITEC-CARREGA-CONJUGE NOT EQUAL ZEROS */

            if (CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE != 00)
            {

                /*" -2521- IF PROPOFID-COD-PRODUTO-SIVPF NOT EQUAL 46 */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF != 46)
                {

                    /*" -2523- IF PROPOFID-NOME-CONJUGE OF DCLPROPOSTA-FIDELIZ NOT EQUAL SPACES */

                    if (!PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NOME_CONJUGE.IsEmpty())
                    {

                        /*" -2525- IF PROPSSVD-DPS-CONJUGE OF DCLPROP-SASSE-VIDA EQUAL SPACES */

                        if (PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_CONJUGE.IsEmpty())
                        {

                            /*" -2526- MOVE 1806 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                            _.Move(1806, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                            /*" -2527- PERFORM R1100-00-GRAVA-TAB-ERRO */

                            R1100_00_GRAVA_TAB_ERRO_SECTION();

                            /*" -2528- END-IF */
                        }


                        /*" -2529- END-IF */
                    }


                    /*" -2530- END-IF */
                }


                /*" -2530- END-IF. */
            }


        }

        [StopWatch]
        /*" R1000-CONSISTE-CX-TRAB */
        private void R1000_CONSISTE_CX_TRAB(bool isPerform = false)
        {
            /*" -2537- MOVE 'R1000-CONSISTE-CX-TRAB' TO PARAGRAFO. */
            _.Move("R1000-CONSISTE-CX-TRAB", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2541- IF PROPOFID-CGC-CONVENENTE OF DCLPROPOSTA-FIDELIZ NOT EQUAL ZEROS AND PRODUVG-DESCONTO-ADESAO OF DCLPRODUTOS-VG GREATER ZEROS */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CGC_CONVENENTE != 00 && PRODUVG.DCLPRODUTOS_VG.PRODUVG_DESCONTO_ADESAO > 00)
            {

                /*" -2542- MOVE ZEROS TO VIND-CGC-CONVENENTE */
                _.Move(0, VIND_CGC_CONVENENTE);

                /*" -2543- PERFORM R1200-00-SELECT-ESTIPULANTE */

                R1200_00_SELECT_ESTIPULANTE_SECTION();

                /*" -2544- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2545- MOVE 1702 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(1702, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -2546- PERFORM R1100-00-GRAVA-TAB-ERRO */

                    R1100_00_GRAVA_TAB_ERRO_SECTION();

                    /*" -2547- END-IF */
                }


                /*" -2548- ELSE */
            }
            else
            {


                /*" -2553- MOVE -1 TO VIND-CGC-CONVENENTE. */
                _.Move(-1, VIND_CGC_CONVENENTE);
            }


            /*" -2554- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 54 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 54)
            {

                /*" -2555- CONTINUE */

                /*" -2556- ELSE */
            }
            else
            {


                /*" -2557- IF NOT CANAL-CORRETOR */

                if (!WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_CORRETOR"])
                {

                    /*" -2558- PERFORM R2100-00-MATRICULA-FUNC THRU R2100-99-SAIDA */

                    R2100_00_MATRICULA_FUNC_SECTION();

                    R2100_01_ACESSA_FUNC(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/


                    /*" -2559- END-IF */
                }


                /*" -2560- END-IF */
            }


            /*" -2564- . */

            /*" -2564- PERFORM R1000-CONSISTE-RCAP. */

            R1000_CONSISTE_RCAP(true);

        }

        [StopWatch]
        /*" R1000-CONSISTE-RCAP */
        private void R1000_CONSISTE_RCAP(bool isPerform = false)
        {
            /*" -2569- MOVE PROPOFID-NUM-SICOB OF DCLPROPOSTA-FIDELIZ TO RCAPS-NUM-TITULO OF DCLRCAPS. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB, RCAPS.DCLRCAPS.RCAPS_NUM_TITULO);

            /*" -2573- MOVE PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO RCAPS-NUM-CERTIFICADO OF DCLRCAPS. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO);

            /*" -2575- MOVE ZERO TO W-RCAPS. */
            _.Move(0, WORK_AREA.W_RCAPS);

            /*" -2577- IF PROPOFID-AGECOBR OF DCLPROPOSTA-FIDELIZ > 0 AND PROPOFID-AGECOBR OF DCLPROPOSTA-FIDELIZ < 10000 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR > 0 && PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR < 10000)
            {

                /*" -2579- MOVE TAB-FONTE (PROPOFID-AGECOBR OF DCLPROPOSTA-FIDELIZ) TO WHOST-FONTE */
                _.Move(TAB_FILIAIS.TAB_FILIAL.FILLER_33[PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR].TAB_FONTE, WHOST_FONTE);

                /*" -2580- ELSE */
            }
            else
            {


                /*" -2583- DISPLAY 'AGENCIA INVALIDA ----> ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ ' ' PROPOFID-AGECOBR OF DCLPROPOSTA-FIDELIZ */

                $"AGENCIA INVALIDA ----> {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF} {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR}"
                .Display();

                /*" -2584- MOVE ZEROS TO WHOST-FONTE */
                _.Move(0, WHOST_FONTE);

                /*" -2586- END-IF */
            }


            /*" -2588- IF (WHOST-FONTE = ZEROS OR 10) OR (WHOST-FONTE > 99) */

            if ((WHOST_FONTE.In("00", "10")) || (WHOST_FONTE > 99))
            {

                /*" -2589- MOVE 5 TO WHOST-FONTE */
                _.Move(5, WHOST_FONTE);

                /*" -2591- END-IF */
            }


            /*" -2593- MOVE WHOST-FONTE TO RCAPS-COD-FONTE OF DCLRCAPS. */
            _.Move(WHOST_FONTE, RCAPS.DCLRCAPS.RCAPS_COD_FONTE);

            /*" -2595- PERFORM R1500-00-SELECT-RCAPS */

            R1500_00_SELECT_RCAPS_SECTION();

            /*" -2596- IF NOT RCAP-CADASTRADO */

            if (!WORK_AREA.W_RCAPS["RCAP_CADASTRADO"])
            {

                /*" -2606- MOVE ZEROS TO RCAPS-COD-FONTE OF DCLRCAPS RCAPS-NUM-RCAP OF DCLRCAPS RCAPS-VAL-RCAP OF DCLRCAPS RCAPCOMP-BCO-AVISO OF DCLRCAP-COMPLEMENTAR RCAPCOMP-AGE-AVISO OF DCLRCAP-COMPLEMENTAR RCAPCOMP-NUM-AVISO-CREDITO OF DCLRCAP-COMPLEMENTAR RCAPCOMP-DATA-MOVIMENTO OF DCLRCAP-COMPLEMENTAR RCAPCOMP-DATA-RCAP OF DCLRCAP-COMPLEMENTAR */
                _.Move(0, RCAPS.DCLRCAPS.RCAPS_COD_FONTE, RCAPS.DCLRCAPS.RCAPS_NUM_RCAP, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_MOVIMENTO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP);

                /*" -2610- IF (PROPOFID-SIT-PROPOSTA OF DCLPROPOSTA-FIDELIZ EQUAL 'POB' OR 'POV' ) OR (PROPOFID-OPCAOPAG OF DCLPROPOSTA-FIDELIZ EQUAL '3' ) */

                if ((PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA.In("POB", "POV")) || (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAOPAG == "3"))
                {

                    /*" -2611- CONTINUE */

                    /*" -2612- ELSE */
                }
                else
                {


                    /*" -2613- MOVE 1501 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(1501, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -2616- IF CANAL-GITEL AND PROPOFID-COD-PRODUTO-SIVPF = 11 OR 46 OR 77 OR 06 */

                    if (WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_GITEL"] && PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF.In("11", "46", "77", "06"))
                    {

                        /*" -2617- CONTINUE */

                        /*" -2618- ELSE */
                    }
                    else
                    {


                        /*" -2619- PERFORM R1100-00-GRAVA-TAB-ERRO */

                        R1100_00_GRAVA_TAB_ERRO_SECTION();

                        /*" -2620- PERFORM R1600-00-UPDATE-PROPFID */

                        R1600_00_UPDATE_PROPFID_SECTION();

                        /*" -2622- END-IF */
                    }


                    /*" -2623- IF WHOST-SIT-PROPOSTA EQUAL 'REJ' */

                    if (WHOST_SIT_PROPOSTA == "REJ")
                    {

                        /*" -2624- GO TO R1000-10-SAIDA */

                        R1000_10_SAIDA(); //GOTO
                        return;

                        /*" -2625- ELSE */
                    }
                    else
                    {


                        /*" -2626- CONTINUE */

                        /*" -2627- END-IF */
                    }


                    /*" -2628- END-IF */
                }


                /*" -2629- ELSE */
            }
            else
            {


                /*" -2630- PERFORM R1510-00-SELECT-RCAPCOMP */

                R1510_00_SELECT_RCAPCOMP_SECTION();

                /*" -2632- END-IF */
            }


            /*" -2633- IF RCAP-CADASTRADO */

            if (WORK_AREA.W_RCAPS["RCAP_CADASTRADO"])
            {

                /*" -2635- IF PROPOFID-DTQITBCO OF DCLPROPOSTA-FIDELIZ = '0001-01-01' OR PROPOFID-DTQITBCO OF DCLPROPOSTA-FIDELIZ = '1900-01-01' */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO == "0001-01-01" || PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO == "1900-01-01")
                {

                    /*" -2637- MOVE RCAPCOMP-DATA-RCAP OF DCLRCAP-COMPLEMENTAR TO PROPOFID-DTQITBCO OF DCLPROPOSTA-FIDELIZ */
                    _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO);

                    /*" -2638- END-IF */
                }


                /*" -2640- END-IF */
            }


            /*" -2641- IF CANAL-GITEL */

            if (WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_GITEL"])
            {

                /*" -2643- MOVE PROPOFID-DATA-PROPOSTA OF DCLPROPOSTA-FIDELIZ TO PROPOFID-DTQITBCO OF DCLPROPOSTA-FIDELIZ */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO);

                /*" -2645- END-IF */
            }


            /*" -2647- MOVE ZERO TO W-PLANO */
            _.Move(0, WORK_AREA.W_PLANO);

            /*" -2652- MOVE +0 TO VIND-IMPSEGAUXF VIND-VLCUSTAUXF VIND-PRMDIT VIND-QTDIT */
            _.Move(+0, VIND_IMPSEGAUXF, VIND_VLCUSTAUXF, VIND_PRMDIT, VIND_QTDIT);

            /*" -2653- IF PROPOFID-COD-PLANO OF DCLPROPOSTA-FIDELIZ = ZEROS */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO == 00)
            {

                /*" -2654- IF PROPOFID-OPCAO-COBER OF DCLPROPOSTA-FIDELIZ = SPACES */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER.IsEmpty())
                {

                    /*" -2655- MOVE 1844 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(1844, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -2657- PERFORM R1100-00-GRAVA-TAB-ERRO */

                    R1100_00_GRAVA_TAB_ERRO_SECTION();

                    /*" -2658- MOVE 1845 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(1845, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -2659- PERFORM R1100-00-GRAVA-TAB-ERRO */

                    R1100_00_GRAVA_TAB_ERRO_SECTION();

                    /*" -2660- END-IF */
                }


                /*" -2662- END-IF */
            }


            /*" -2663- IF PROPOFID-COD-PRODUTO-SIVPF = 77 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 77)
            {

                /*" -2664- PERFORM R1410-00-SELECT-PLANOS-VA */

                R1410_00_SELECT_PLANOS_VA_SECTION();

                /*" -2665- ELSE */
            }
            else
            {


                /*" -2666- PERFORM R1400-00-SELECT-PLANOS-VA */

                R1400_00_SELECT_PLANOS_VA_SECTION();

                /*" -2668- END-IF */
            }


            /*" -2669- IF NOT EXISTE-PLANO */

            if (!WORK_AREA.W_PLANO["EXISTE_PLANO"])
            {

                /*" -2684- MOVE ZEROS TO IMPMORNATU OF DCLPLANOS-VA-VGAP, IMPMORACID OF DCLPLANOS-VA-VGAP, IMPINVPERM OF DCLPLANOS-VA-VGAP, IMPAMDS OF DCLPLANOS-VA-VGAP, IMPDH OF DCLPLANOS-VA-VGAP, IMPDIT OF DCLPLANOS-VA-VGAP, VLPREMIOTOT OF DCLPLANOS-VA-VGAP, PRMVG OF DCLPLANOS-VA-VGAP, PRMAP OF DCLPLANOS-VA-VGAP, QTTITCAP OF DCLPLANOS-VA-VGAP, VLTITCAP OF DCLPLANOS-VA-VGAP, VLCUSTCAP OF DCLPLANOS-VA-VGAP, IMPSEGCDG OF DCLPLANOS-VA-VGAP, VLCUSTCDG OF DCLPLANOS-VA-VGAP */
                _.Move(0, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORACID, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPINVPERM, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPAMDS, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPDH, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPDIT, PLVAVGAP.DCLPLANOS_VA_VGAP.VLPREMIOTOT, PLVAVGAP.DCLPLANOS_VA_VGAP.PRMVG, PLVAVGAP.DCLPLANOS_VA_VGAP.PRMAP, PLVAVGAP.DCLPLANOS_VA_VGAP.QTTITCAP, PLVAVGAP.DCLPLANOS_VA_VGAP.VLTITCAP, PLVAVGAP.DCLPLANOS_VA_VGAP.VLCUSTCAP, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPSEGCDG, PLVAVGAP.DCLPLANOS_VA_VGAP.VLCUSTCDG);

                /*" -2689- MOVE -1 TO VIND-IMPSEGAUXF, VIND-VLCUSTAUXF, VIND-PRMDIT, VIND-QTDIT */
                _.Move(-1, VIND_IMPSEGAUXF, VIND_VLCUSTAUXF, VIND_PRMDIT, VIND_QTDIT);

                /*" -2690- MOVE 604 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(604, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -2691- PERFORM R1100-00-GRAVA-TAB-ERRO */

                R1100_00_GRAVA_TAB_ERRO_SECTION();

                /*" -2693- END-IF */
            }


            /*" -2694- MOVE ZEROS TO WS-VLPREMIOTOT-CCT */
            _.Move(0, WORK_AREA.WS_VLPREMIOTOT_CCT);

            /*" -2695- IF EXISTE-PLANO */

            if (WORK_AREA.W_PLANO["EXISTE_PLANO"])
            {

                /*" -2696- PERFORM R1420-VERIFICA-MATRIZ */

                R1420_VERIFICA_MATRIZ_SECTION();

                /*" -2698- END-IF */
            }


            /*" -2700- IF ORIGEM-AUTO-COMPRA-IBC OR ORIGEM-AUTO-COMPRA-LOJA */

            if (WORK_AREA.W_ORIGEM_PROPOSTA["ORIGEM_AUTO_COMPRA_IBC"] || WORK_AREA.W_ORIGEM_PROPOSTA["ORIGEM_AUTO_COMPRA_LOJA"])
            {

                /*" -2701- CONTINUE */

                /*" -2702- ELSE */
            }
            else
            {


                /*" -2704- IF (PROPOFID-DATA-CREDITO EQUAL '0001-01-01' OR PROPOFID-DATA-CREDITO EQUAL '1901-01-01' ) */

                if ((PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_CREDITO == "0001-01-01" || PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_CREDITO == "1901-01-01"))
                {

                    /*" -2705- IF NOT EXISTE-PLANO */

                    if (!WORK_AREA.W_PLANO["EXISTE_PLANO"])
                    {

                        /*" -2706- IF NOT RCAP-CADASTRADO */

                        if (!WORK_AREA.W_RCAPS["RCAP_CADASTRADO"])
                        {

                            /*" -2707- CONTINUE */

                            /*" -2708- END-IF */
                        }


                        /*" -2710- END-IF */
                    }


                    /*" -2711- IF PROPOFID-VAL-PAGO EQUAL ZEROS */

                    if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO == 00)
                    {

                        /*" -2712- IF EXISTE-PLANO */

                        if (WORK_AREA.W_PLANO["EXISTE_PLANO"])
                        {

                            /*" -2714- MOVE VLPREMIOTOT OF DCLPLANOS-VA-VGAP TO PROPOFID-VAL-PAGO OF DCLPROPOSTA-FIDELIZ */
                            _.Move(PLVAVGAP.DCLPLANOS_VA_VGAP.VLPREMIOTOT, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO);

                            /*" -2715- ELSE */
                        }
                        else
                        {


                            /*" -2717- MOVE RCAPS-VAL-RCAP OF DCLRCAPS TO PROPOFID-VAL-PAGO OF DCLPROPOSTA-FIDELIZ */
                            _.Move(RCAPS.DCLRCAPS.RCAPS_VAL_RCAP, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO);

                            /*" -2718- END-IF */
                        }


                        /*" -2720- END-IF */
                    }


                    /*" -2721- PERFORM R1700-00-UPDATE-PRP-FIDELIZ */

                    R1700_00_UPDATE_PRP_FIDELIZ_SECTION();

                    /*" -2722- END-IF */
                }


                /*" -2724- END-IF */
            }


            /*" -2727- COMPUTE WHOST-PREMIO-1 = VLPREMIOTOT OF DCLPLANOS-VA-VGAP - 1 */
            WHOST_PREMIO_1.Value = PLVAVGAP.DCLPLANOS_VA_VGAP.VLPREMIOTOT - 1;

            /*" -2731- COMPUTE WHOST-PREMIO-2 = VLPREMIOTOT OF DCLPLANOS-VA-VGAP + 1 */
            WHOST_PREMIO_2.Value = PLVAVGAP.DCLPLANOS_VA_VGAP.VLPREMIOTOT + 1;

            /*" -2732- IF PROPOFID-COD-PRODUTO-SIVPF = 54 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 54)
            {

                /*" -2733- CONTINUE */

                /*" -2734- ELSE */
            }
            else
            {


                /*" -2735- IF RCAP-CADASTRADO */

                if (WORK_AREA.W_RCAPS["RCAP_CADASTRADO"])
                {

                    /*" -2736- IF EXISTE-PLANO */

                    if (WORK_AREA.W_PLANO["EXISTE_PLANO"])
                    {

                        /*" -2747- IF (RCAPS-VAL-RCAP OF DCLRCAPS NOT EQUAL VLPREMIOTOT OF DCLPLANOS-VA-VGAP) AND (RCAPS-VAL-RCAP OF DCLRCAPS NOT EQUAL WS-VLPREMIOTOT-CCT) AND ((RCAPS-VAL-RCAP OF DCLRCAPS LESS WHOST-PREMIO-1 ) OR (RCAPS-VAL-RCAP OF DCLRCAPS GREATER WHOST-PREMIO-2 )) */

                        if ((RCAPS.DCLRCAPS.RCAPS_VAL_RCAP != PLVAVGAP.DCLPLANOS_VA_VGAP.VLPREMIOTOT) && (RCAPS.DCLRCAPS.RCAPS_VAL_RCAP != WORK_AREA.WS_VLPREMIOTOT_CCT) && ((RCAPS.DCLRCAPS.RCAPS_VAL_RCAP < WHOST_PREMIO_1) || (RCAPS.DCLRCAPS.RCAPS_VAL_RCAP > WHOST_PREMIO_2)))
                        {

                            /*" -2748- MOVE 1817 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                            _.Move(1817, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                            /*" -2749- PERFORM R1100-00-GRAVA-TAB-ERRO */

                            R1100_00_GRAVA_TAB_ERRO_SECTION();

                            /*" -2750- END-IF */
                        }


                        /*" -2751- END-IF */
                    }


                    /*" -2752- END-IF */
                }


                /*" -2758- END-IF */
            }


            /*" -2760- IF PROPOFID-COD-PRODUTO-SIVPF = 77 OR CANAL-GITEL */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 77 || WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_GITEL"])
            {

                /*" -2761- CONTINUE */

                /*" -2762- ELSE */
            }
            else
            {


                /*" -2763- PERFORM R2350-00-TRATA-ERRO-1864 */

                R2350_00_TRATA_ERRO_1864_SECTION();

                /*" -2770- END-IF. */
            }


            /*" -2771- INITIALIZE WS-NUM-PROPOSTA-AZUL */
            _.Initialize(
                WS_NUM_PROPOSTA_AZUL
            );

            /*" -2774- MOVE PROPOFID-NUM-SICOB OF DCLPROPOSTA-FIDELIZ TO WS-NUM-PROPOSTA-AZUL */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB, WS_NUM_PROPOSTA_AZUL);

            /*" -2780- PERFORM R1000_CONSISTE_RCAP_DB_SELECT_1 */

            R1000_CONSISTE_RCAP_DB_SELECT_1();

            /*" -2783- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -2784- MOVE 913 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(913, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -2785- PERFORM R1100-00-GRAVA-TAB-ERRO */

                R1100_00_GRAVA_TAB_ERRO_SECTION();

                /*" -2793- END-IF */
            }


            /*" -2794- IF WHOST-IMPMORNATU-MAX GREATER ZEROS */

            if (WHOST_IMPMORNATU_MAX > 00)
            {

                /*" -2816- IF PRODUVG-COD-PRODUTO OF DCLPRODUTOS-VG EQUAL 9310 OR 9314 OR 9318 OR 9319 OR 9320 OR 9321 OR 9327 OR 9328 OR 9332 OR 9333 OR 9334 OR 9356 OR 9357 OR 9358 OR 9359 OR 9360 OR 9361 OR 9352 OR 9353 OR 9351 OR JVPRD9310 OR JVPRD9314 OR JVPRD9320 OR JVPRD9321 OR JVPRD9327 OR JVPRD9328 OR JVPRD9332 OR JVPRD9334 OR JVPRD9356 OR JVPRD9357 OR JVPRD9358 OR JVPRD9359 OR JVPRD9360 OR JVPRD9361 OR JVPRD9352 OR JVPRD9353 OR JVPRD9351 */

                if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("9310", "9314", "9318", "9319", "9320", "9321", "9327", "9328", "9332", "9333", "9334", "9356", "9357", "9358", "9359", "9360", "9361", "9352", "9353", "9351", JVBKINCL.JV_PRODUTOS.JVPRD9310.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9314.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9320.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9321.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9327.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9328.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9332.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9334.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9356.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9357.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9358.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9359.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9360.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9361.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9352.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9353.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9351.ToString()))
                {

                    /*" -2817- PERFORM R2242-00-SELECT-ACUM-RISCO */

                    R2242_00_SELECT_ACUM_RISCO_SECTION();

                    /*" -2818- ELSE */
                }
                else
                {


                    /*" -2820- IF PRODUVG-COD-PRODUTO OF DCLPRODUTOS-VG EQUAL 9750 OR 9751 OR 9752 */

                    if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("9750", "9751", "9752"))
                    {

                        /*" -2821- PERFORM R2243-00-SELECT-ACUM-RISCO */

                        R2243_00_SELECT_ACUM_RISCO_SECTION();

                        /*" -2822- PERFORM R2244-00-SELECT-ACUM-RISCO */

                        R2244_00_SELECT_ACUM_RISCO_SECTION();

                        /*" -2823- PERFORM R2245-00-VERIFICA-ACUM-CPF */

                        R2245_00_VERIFICA_ACUM_CPF_SECTION();

                        /*" -2824- ELSE */
                    }
                    else
                    {


                        /*" -2825- PERFORM R2241-00-SELECT-ACUM-RISCO */

                        R2241_00_SELECT_ACUM_RISCO_SECTION();

                        /*" -2826- END-IF */
                    }


                    /*" -2828- END-IF */
                }


                /*" -2829- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 77 */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 77)
                {

                    /*" -2833- DISPLAY 'RISCO 77 ----> ' ' ' PROPOFID-NUM-PROPOSTA-SIVPF ' ' WHOST-IMPMORNATU-MAX ' ' AC-TOT-RISCO */

                    $"RISCO 77 ---->  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF} {WHOST_IMPMORNATU_MAX} {WORK_AREA.AC_TOT_RISCO}"
                    .Display();

                    /*" -2835- END-IF */
                }


                /*" -2836- IF PROPOFID-COD-PRODUTO-SIVPF NOT EQUAL 77 */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF != 77)
                {

                    /*" -2837-  EVALUATE PRODUVG-COD-PRODUTO OF DCLPRODUTOS-VG  */

                    /*" -2838-  WHEN 9351  */

                    /*" -2839-  WHEN 9352  */

                    /*" -2840-  WHEN 9353  */

                    /*" -2841-  WHEN JVPRD9351  */

                    /*" -2842-  WHEN JVPRD9352  */

                    /*" -2843-  WHEN JVPRD9353  */

                    /*" -2843- IF   PRODUVG-COD-PRODUTO OF DCLPRODUTOS-VG EQUALS 9351  OR  9352   OR  9353   OR  JVPRD9351   OR  JVPRD9352 OR  JVPRD9353 */

                    if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("9351", "9352", "9353", JVBKINCL.JV_PRODUTOS.JVPRD9351.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9352.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9353.ToString()))
                    {

                        /*" -2844- IF AC-TOT-RISCO > 100000 */

                        if (WORK_AREA.AC_TOT_RISCO > 100000)
                        {

                            /*" -2845- MOVE 1852 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                            _.Move(1852, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                            /*" -2846- PERFORM R1100-00-GRAVA-TAB-ERRO */

                            R1100_00_GRAVA_TAB_ERRO_SECTION();

                            /*" -2847- MOVE 'SIM' TO WS-TEM-ERRO-1852 */
                            _.Move("SIM", WORK_AREA.WS_TEM_ERRO_1852);

                            /*" -2848- PERFORM R3700-00-INSERT-RELATORIOS */

                            R3700_00_INSERT_RELATORIOS_SECTION();

                            /*" -2849- END-IF */
                        }


                        /*" -2850-  WHEN 9310  */

                        /*" -2851-  WHEN JVPRD9310  */

                        /*" -2851- ELSE IF   PRODUVG-COD-PRODUTO OF DCLPRODUTOS-VG EQUALS 9310 OR  JVPRD9310 */
                    }
                    else

                    if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("9310", JVBKINCL.JV_PRODUTOS.JVPRD9310.ToString()))
                    {

                        /*" -2860- CONTINUE */

                        /*" -2861-  WHEN 9320  */

                        /*" -2862-  WHEN 9321  */

                        /*" -2863-  WHEN 9332  */

                        /*" -2864-  WHEN 9327  */

                        /*" -2865-  WHEN 9328  */

                        /*" -2866-  WHEN 9334  */

                        /*" -2867-  WHEN JVPRD9320  */

                        /*" -2868-  WHEN JVPRD9321  */

                        /*" -2869-  WHEN JVPRD9332  */

                        /*" -2870-  WHEN JVPRD9327  */

                        /*" -2871-  WHEN JVPRD9328  */

                        /*" -2872-  WHEN JVPRD9334  */

                        /*" -2872- ELSE IF   PRODUVG-COD-PRODUTO OF DCLPRODUTOS-VG EQUALS 9320  OR  9321   OR  9332   OR  9327   OR  9328   OR  9334   OR  JVPRD9320   OR  JVPRD9321   OR  JVPRD9332   OR  JVPRD9327   OR  JVPRD9328 OR  JVPRD9334 */
                    }
                    else

                    if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("9320", "9321", "9332", "9327", "9328", "9334", JVBKINCL.JV_PRODUTOS.JVPRD9320.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9321.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9332.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9327.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9328.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9334.ToString()))
                    {

                        /*" -2873- IF AC-TOT-RISCO > 2000000 */

                        if (WORK_AREA.AC_TOT_RISCO > 2000000)
                        {

                            /*" -2874- MOVE 1852 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                            _.Move(1852, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                            /*" -2875- PERFORM R1100-00-GRAVA-TAB-ERRO */

                            R1100_00_GRAVA_TAB_ERRO_SECTION();

                            /*" -2876- MOVE 'SIM' TO WS-TEM-ERRO-1852 */
                            _.Move("SIM", WORK_AREA.WS_TEM_ERRO_1852);

                            /*" -2877- PERFORM R3700-00-INSERT-RELATORIOS */

                            R3700_00_INSERT_RELATORIOS_SECTION();

                            /*" -2878- END-IF */
                        }


                        /*" -2878-  WHEN 9314 */

                        /*" -2878-  WHEN JVPRD9314 */

                        /*" -2880-  IF AC-TOT-RISCO > 25000  */

                        /*" -2880- IF AC-TOT-RISCO > 25000 */

                        if (WORK_AREA.AC_TOT_RISCO > 25000)
                        {

                            /*" -2881- MOVE 1852 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                            _.Move(1852, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                            /*" -2882- PERFORM R1100-00-GRAVA-TAB-ERRO */

                            R1100_00_GRAVA_TAB_ERRO_SECTION();

                            /*" -2883- MOVE 'SIM' TO WS-TEM-ERRO-1852 */
                            _.Move("SIM", WORK_AREA.WS_TEM_ERRO_1852);

                            /*" -2884- PERFORM R3700-00-INSERT-RELATORIOS */

                            R3700_00_INSERT_RELATORIOS_SECTION();

                            /*" -2885- END-IF */
                        }


                        /*" -2885-  WHEN 9359 */

                        /*" -2885-  WHEN JVPRD9359 */

                        /*" -2886-  WHEN 9360 */

                        /*" -2886-  WHEN JVPRD9360 */

                        /*" -2887-  WHEN 9361 */

                        /*" -2887-  WHEN JVPRD9361 */

                        /*" -2888-  WHEN 9356 */

                        /*" -2888-  WHEN JVPRD9356 */

                        /*" -2889-  WHEN 9357 */

                        /*" -2889-  WHEN JVPRD9357 */

                        /*" -2890-  WHEN 9358 */

                        /*" -2890-  WHEN JVPRD9358 */

                        /*" -2892-  IF AC-TOT-RISCO <= 2000000  */

                        /*" -2892- IF AC-TOT-RISCO <= 2000000 */

                        if (WORK_AREA.AC_TOT_RISCO <= 2000000)
                        {

                            /*" -2893- CONTINUE */

                            /*" -2894- ELSE */
                        }
                        else
                        {


                            /*" -2896- IF AC-TOT-RISCO > 600000 AND AC-TOT-RISCO <= 2000000 */

                            if (WORK_AREA.AC_TOT_RISCO > 600000 && WORK_AREA.AC_TOT_RISCO <= 2000000)
                            {

                                /*" -2897- MOVE 1852 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                                _.Move(1852, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                                /*" -2898- PERFORM R1100-00-GRAVA-TAB-ERRO */

                                R1100_00_GRAVA_TAB_ERRO_SECTION();

                                /*" -2899- MOVE 'SIM' TO WS-TEM-ERRO-1852 */
                                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_1852);

                                /*" -2900- PERFORM R3700-00-INSERT-RELATORIOS */

                                R3700_00_INSERT_RELATORIOS_SECTION();

                                /*" -2901- ELSE */
                            }
                            else
                            {


                                /*" -2902- IF AC-TOT-RISCO > 2000000 */

                                if (WORK_AREA.AC_TOT_RISCO > 2000000)
                                {

                                    /*" -2904- MOVE 1852 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                                    _.Move(1852, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                                    /*" -2905- PERFORM R1100-00-GRAVA-TAB-ERRO */

                                    R1100_00_GRAVA_TAB_ERRO_SECTION();

                                    /*" -2906- MOVE 'SIM' TO WS-TEM-ERRO-1852 */
                                    _.Move("SIM", WORK_AREA.WS_TEM_ERRO_1852);

                                    /*" -2907- PERFORM R3700-00-INSERT-RELATORIOS */

                                    R3700_00_INSERT_RELATORIOS_SECTION();

                                    /*" -2908- END-IF */
                                }


                                /*" -2909- END-IF */
                            }


                            /*" -2910- END-IF */
                        }


                        /*" -2911-  WHEN 9750  */

                        /*" -2912-  WHEN 9751  */

                        /*" -2914-  WHEN 9752  */

                        /*" -2914- ELSE IF   PRODUVG-COD-PRODUTO OF DCLPRODUTOS-VG EQUALS 9750  OR  9751 OR  9752 */
                    }
                    else

                    if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("9750", "9751", "9752"))
                    {

                        /*" -2915- IF AC-TOT-RISCO > 5000000 */

                        if (WORK_AREA.AC_TOT_RISCO > 5000000)
                        {

                            /*" -2916- MOVE 1894 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                            _.Move(1894, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                            /*" -2917- PERFORM R1100-00-GRAVA-TAB-ERRO */

                            R1100_00_GRAVA_TAB_ERRO_SECTION();

                            /*" -2919- MOVE 'SIM' TO WS-TEM-ERRO-1894 */
                            _.Move("SIM", WORK_AREA.WS_TEM_ERRO_1894);

                            /*" -2921- ELSE */
                        }
                        else
                        {


                            /*" -2922- IF AC-TOT-RISCO > 2000000 */

                            if (WORK_AREA.AC_TOT_RISCO > 2000000)
                            {

                                /*" -2923- MOVE 1893 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                                _.Move(1893, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                                /*" -2924- PERFORM R1100-00-GRAVA-TAB-ERRO */

                                R1100_00_GRAVA_TAB_ERRO_SECTION();

                                /*" -2926- MOVE 'SIM' TO WS-TEM-ERRO-1893 */
                                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_1893);

                                /*" -2927- END-IF */
                            }


                            /*" -2929- END-IF */
                        }


                        /*" -2930- IF AC-TOT-ACUM-CPF > 12500000 */

                        if (WORK_AREA.AC_TOT_ACUM_CPF > 12500000)
                        {

                            /*" -2931- MOVE 1897 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                            _.Move(1897, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                            /*" -2932- PERFORM R1100-00-GRAVA-TAB-ERRO */

                            R1100_00_GRAVA_TAB_ERRO_SECTION();

                            /*" -2933- MOVE 'SIM' TO WS-TEM-ERRO-1897 */
                            _.Move("SIM", WORK_AREA.WS_TEM_ERRO_1897);

                            /*" -2935- ELSE */
                        }
                        else
                        {


                            /*" -2936- IF AC-TOT-ACUM-CPF > 5000000 */

                            if (WORK_AREA.AC_TOT_ACUM_CPF > 5000000)
                            {

                                /*" -2937- MOVE 1896 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                                _.Move(1896, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                                /*" -2938- PERFORM R1100-00-GRAVA-TAB-ERRO */

                                R1100_00_GRAVA_TAB_ERRO_SECTION();

                                /*" -2939- MOVE 'SIM' TO WS-TEM-ERRO-1896 */
                                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_1896);

                                /*" -2940- END-IF */
                            }


                            /*" -2942- END-IF */
                        }


                        /*" -2943-  WHEN OTHER  */

                        /*" -2943- ELSE */
                    }
                    else
                    {


                        /*" -2944- DISPLAY '** VERIFICAR REGRA DE ACUMULO DE RISCO **' */
                        _.Display($"** VERIFICAR REGRA DE ACUMULO DE RISCO **");

                        /*" -2946- DISPLAY ' PRODUTO = ' PRODUVG-COD-PRODUTO OF DCLPRODUTOS-VG */
                        _.Display($" PRODUTO = {PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO}");

                        /*" -2948- DISPLAY ' CERTIFICADO = ' PROPOFID-NUM-PROPOSTA-SIVPF */
                        _.Display($" CERTIFICADO = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                        /*" -2949- IF AC-TOT-RISCO > 600000 */

                        if (WORK_AREA.AC_TOT_RISCO > 600000)
                        {

                            /*" -2950- DISPLAY 'ACUMULO MAIOR QUE 600 MIL' */
                            _.Display($"ACUMULO MAIOR QUE 600 MIL");

                            /*" -2951- DISPLAY 'ATENCAO - AVALIAR PRODUTO - ATENCAO' */
                            _.Display($"ATENCAO - AVALIAR PRODUTO - ATENCAO");

                            /*" -2952- MOVE 1852 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                            _.Move(1852, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                            /*" -2953- PERFORM R1100-00-GRAVA-TAB-ERRO */

                            R1100_00_GRAVA_TAB_ERRO_SECTION();

                            /*" -2954- MOVE 'SIM' TO WS-TEM-ERRO-1852 */
                            _.Move("SIM", WORK_AREA.WS_TEM_ERRO_1852);

                            /*" -2955- PERFORM R3700-00-INSERT-RELATORIOS */

                            R3700_00_INSERT_RELATORIOS_SECTION();

                            /*" -2956- END-IF */
                        }


                        /*" -2957-  END-EVALUATE  */

                        /*" -2957- END-IF */
                    }


                    /*" -2958- END-IF */
                }


                /*" -2963- END-IF */
            }


            /*" -2965- IF PRODUVG-COD-PRODUTO OF DCLPRODUTOS-VG EQUAL 9310 OR JVPRD9310 */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("9310", JVBKINCL.JV_PRODUTOS.JVPRD9310.ToString()))
            {

                /*" -2966- MOVE DATA-NASCIMENTO OF DCLPESSOA-FISICA TO WS-DTNASC */
                _.Move(PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO, WORK_AREA.WS_DTNASC);

                /*" -2968- MOVE PROPOFID-DATA-PROPOSTA OF DCLPROPOSTA-FIDELIZ TO WS-DTPROP */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA, WORK_AREA.WS_DTPROP);

                /*" -2969- COMPUTE WHOST-IDADE = WS-AA-DTPROP - WS-AA-DTNASC */
                WHOST_IDADE.Value = WORK_AREA.WS_DTPROP.WS_AA_DTPROP - WORK_AREA.WS_DTNASC.WS_AA_DTNASC;

                /*" -2970- IF WS-MM-DTNASC GREATER WS-MM-DTPROP */

                if (WORK_AREA.WS_DTNASC.WS_MM_DTNASC > WORK_AREA.WS_DTPROP.WS_MM_DTPROP)
                {

                    /*" -2971- SUBTRACT 1 FROM WHOST-IDADE */
                    WHOST_IDADE.Value = WHOST_IDADE - 1;

                    /*" -2972- ELSE */
                }
                else
                {


                    /*" -2973- IF WS-MM-DTNASC EQUAL WS-MM-DTPROP */

                    if (WORK_AREA.WS_DTNASC.WS_MM_DTNASC == WORK_AREA.WS_DTPROP.WS_MM_DTPROP)
                    {

                        /*" -2974- IF WS-DD-DTNASC GREATER WS-DD-DTPROP */

                        if (WORK_AREA.WS_DTNASC.WS_DD_DTNASC > WORK_AREA.WS_DTPROP.WS_DD_DTPROP)
                        {

                            /*" -2975- SUBTRACT 1 FROM WHOST-IDADE */
                            WHOST_IDADE.Value = WHOST_IDADE - 1;

                            /*" -2976- END-IF */
                        }


                        /*" -2977- END-IF */
                    }


                    /*" -2978- END-IF */
                }


                /*" -2979- IF WHOST-IDADE < 16 */

                if (WHOST_IDADE < 16)
                {

                    /*" -2980- MOVE 1005 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(1005, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -2981- PERFORM R1100-00-GRAVA-TAB-ERRO */

                    R1100_00_GRAVA_TAB_ERRO_SECTION();

                    /*" -2983- END-IF */
                }


                /*" -2984- IF WHOST-IDADE > 80 */

                if (WHOST_IDADE > 80)
                {

                    /*" -2985- MOVE 1006 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(1006, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -2986- PERFORM R1100-00-GRAVA-TAB-ERRO */

                    R1100_00_GRAVA_TAB_ERRO_SECTION();

                    /*" -2987- END-IF */
                }


                /*" -2993- END-IF. */
            }


            /*" -2998- IF PRODUVG-COD-PRODUTO OF DCLPRODUTOS-VG EQUAL 9318 OR 9319 OR 9333 OR 9351 OR 9352 OR 9353 OR JVPRD9351 OR JVPRD9352 OR JVPRD9353 */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("9318", "9319", "9333", "9351", "9352", "9353", JVBKINCL.JV_PRODUTOS.JVPRD9351.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9352.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9353.ToString()))
            {

                /*" -2999- MOVE DATA-NASCIMENTO OF DCLPESSOA-FISICA TO WS-DTNASC */
                _.Move(PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO, WORK_AREA.WS_DTNASC);

                /*" -3001- MOVE PROPOFID-DATA-PROPOSTA OF DCLPROPOSTA-FIDELIZ TO WS-DTPROP */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA, WORK_AREA.WS_DTPROP);

                /*" -3002- COMPUTE WHOST-IDADE = WS-AA-DTPROP - WS-AA-DTNASC */
                WHOST_IDADE.Value = WORK_AREA.WS_DTPROP.WS_AA_DTPROP - WORK_AREA.WS_DTNASC.WS_AA_DTNASC;

                /*" -3003- IF WS-MM-DTNASC GREATER WS-MM-DTPROP */

                if (WORK_AREA.WS_DTNASC.WS_MM_DTNASC > WORK_AREA.WS_DTPROP.WS_MM_DTPROP)
                {

                    /*" -3004- SUBTRACT 1 FROM WHOST-IDADE */
                    WHOST_IDADE.Value = WHOST_IDADE - 1;

                    /*" -3005- ELSE */
                }
                else
                {


                    /*" -3006- IF WS-MM-DTNASC EQUAL WS-MM-DTPROP */

                    if (WORK_AREA.WS_DTNASC.WS_MM_DTNASC == WORK_AREA.WS_DTPROP.WS_MM_DTPROP)
                    {

                        /*" -3007- IF WS-DD-DTNASC GREATER WS-DD-DTPROP */

                        if (WORK_AREA.WS_DTNASC.WS_DD_DTNASC > WORK_AREA.WS_DTPROP.WS_DD_DTPROP)
                        {

                            /*" -3008- SUBTRACT 1 FROM WHOST-IDADE */
                            WHOST_IDADE.Value = WHOST_IDADE - 1;

                            /*" -3009- END-IF */
                        }


                        /*" -3010- END-IF */
                    }


                    /*" -3011- END-IF */
                }


                /*" -3012- IF WHOST-IDADE < 16 */

                if (WHOST_IDADE < 16)
                {

                    /*" -3013- MOVE 1005 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(1005, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -3014- PERFORM R1100-00-GRAVA-TAB-ERRO */

                    R1100_00_GRAVA_TAB_ERRO_SECTION();

                    /*" -3015- END-IF */
                }


                /*" -3016- IF WHOST-IDADE > 70 */

                if (WHOST_IDADE > 70)
                {

                    /*" -3017- MOVE 1006 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(1006, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -3018- PERFORM R1100-00-GRAVA-TAB-ERRO */

                    R1100_00_GRAVA_TAB_ERRO_SECTION();

                    /*" -3019- END-IF */
                }


                /*" -3023- END-IF. */
            }


            /*" -3025- IF PRODUVG-COD-PRODUTO OF DCLPRODUTOS-VG EQUAL 9314 OR PRODUVG-COD-PRODUTO OF DCLPRODUTOS-VG EQUAL JVPRD9314 */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO == 9314 || PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO == JVBKINCL.JV_PRODUTOS.JVPRD9314)
            {

                /*" -3026- PERFORM R2250-00-SELECT-LIM-RENDA */

                R2250_00_SELECT_LIM_RENDA_SECTION();

                /*" -3030- END-IF. */
            }


            /*" -3032- IF PRODUVG-COD-PRODUTO OF DCLPRODUTOS-VG EQUAL 9310 OR JVPRD9310 */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("9310", JVBKINCL.JV_PRODUTOS.JVPRD9310.ToString()))
            {

                /*" -3034- MOVE 5 TO PROPOFID-FAIXA-RENDA-IND PROPOFID-FAIXA-RENDA-FAM */
                _.Move(5, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_IND, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_FAM);

                /*" -3036- END-IF */
            }


            /*" -3044- IF ((PROPOFID-FAIXA-RENDA-IND EQUAL SPACES OR PROPOFID-FAIXA-RENDA-IND EQUAL LOW-VALUES OR PROPOFID-FAIXA-RENDA-IND LESS 1 OR PROPOFID-FAIXA-RENDA-IND GREATER 5 ) OR (PROPOFID-FAIXA-RENDA-FAM EQUAL SPACES OR PROPOFID-FAIXA-RENDA-FAM EQUAL LOW-VALUES OR PROPOFID-FAIXA-RENDA-FAM LESS 1 OR PROPOFID-FAIXA-RENDA-FAM GREATER 5 )) */

            if (((PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_IND.IsEmpty() || PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_IND.IsLowValues() || PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_IND < 1 || PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_IND > 5) || (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_FAM.IsEmpty() || PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_FAM.IsLowValues() || PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_FAM < 1 || PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_FAM > 5)))
            {

                /*" -3045- MOVE 1875 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1875, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -3046- PERFORM R1100-00-GRAVA-TAB-ERRO */

                R1100_00_GRAVA_TAB_ERRO_SECTION();

                /*" -3047- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -3051- END-IF */
            }


            /*" -3053- IF PROPOFID-COD-PRODUTO-SIVPF = 77 OR CANAL-GITEL */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 77 || WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_GITEL"])
            {

                /*" -3054- CONTINUE */

                /*" -3056- ELSE */
            }
            else
            {


                /*" -3057- IF IMPMORNATU OF DCLPLANOS-VA-VGAP GREATER 199999,99 */

                if (PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU > 199999.99)
                {

                    /*" -3058- MOVE 1829 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(1829, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -3059- PERFORM R1100-00-GRAVA-TAB-ERRO */

                    R1100_00_GRAVA_TAB_ERRO_SECTION();

                    /*" -3060- MOVE 'SIM' TO WS-TEM-ERRO-1829 */
                    _.Move("SIM", WORK_AREA.WS_TEM_ERRO_1829);

                    /*" -3061- END-IF */
                }


                /*" -3063- END-IF */
            }


            /*" -3065- IF PROPOFID-IND-TP-PROPOSTA EQUAL 'C' OR 'D' OR 'E' OR 'S' OR 'V' */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TP_PROPOSTA.In("C", "D", "E", "S", "V"))
            {

                /*" -3066- SET WS-PROP-ELETRONICA TO TRUE */
                WS_INSERE_ANDAMENTO["WS_PROP_ELETRONICA"] = true;

                /*" -3068- END-IF */
            }


            /*" -3069- IF WS-PROP-ELETRONICA */

            if (WS_INSERE_ANDAMENTO["WS_PROP_ELETRONICA"])
            {

                /*" -3070- CONTINUE */

                /*" -3071- ELSE */
            }
            else
            {


                /*" -3072- IF WS-TEM-ERRO-1829 EQUAL 'NAO' */

                if (WORK_AREA.WS_TEM_ERRO_1829 == "NAO")
                {

                    /*" -3073- CONTINUE */

                    /*" -3074- ELSE */
                }
                else
                {


                    /*" -3075- IF WS-TEM-ERRO EQUAL ZEROS */

                    if (WORK_AREA.WS_TEM_ERRO == 00)
                    {

                        /*" -3076- MOVE ZEROS TO WS-TEM-ERRO-ASS */
                        _.Move(0, WORK_AREA.WS_TEM_ERRO_ASS);

                        /*" -3077- ELSE */
                    }
                    else
                    {


                        /*" -3078- MOVE 1 TO WS-TEM-ERRO-ASS */
                        _.Move(1, WORK_AREA.WS_TEM_ERRO_ASS);

                        /*" -3079- END-IF */
                    }


                    /*" -3080- IF NOT CANAL-GITEL */

                    if (!WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_GITEL"])
                    {

                        /*" -3081- MOVE 1800 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                        _.Move(1800, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                        /*" -3082- PERFORM R1100-00-GRAVA-TAB-ERRO */

                        R1100_00_GRAVA_TAB_ERRO_SECTION();

                        /*" -3083- END-IF */
                    }


                    /*" -3084- IF WS-TEM-ERRO-ASS EQUAL ZEROS */

                    if (WORK_AREA.WS_TEM_ERRO_ASS == 00)
                    {

                        /*" -3085- MOVE ZEROS TO WS-TEM-ERRO */
                        _.Move(0, WORK_AREA.WS_TEM_ERRO);

                        /*" -3086- END-IF */
                    }


                    /*" -3087- END-IF */
                }


                /*" -3091- END-IF */
            }


            /*" -3093- PERFORM R5632-00-SELECT-PROPOSTAVA. */

            R5632_00_SELECT_PROPOSTAVA_SECTION();

            /*" -3094- IF WEXISTE-PRPVA EQUAL 'SIM' */

            if (WEXISTE_PRPVA == "SIM")
            {

                /*" -3096- IF SIT-REGISTRO OF DCLPROPOSTAS-VA EQUAL '0' OR '1' OR '3' OR '7' OR '8' */

                if (PROPVA.DCLPROPOSTAS_VA.SIT_REGISTRO.In("0", "1", "3", "7", "8"))
                {

                    /*" -3097- PERFORM R5633-00-UPDATE-PRP-FIDELIZ */

                    R5633_00_UPDATE_PRP_FIDELIZ_SECTION();

                    /*" -3101- GO TO R1000-10-SAIDA. */

                    R1000_10_SAIDA(); //GOTO
                    return;
                }

            }


            /*" -3103- PERFORM R2400-00-TRATA-ENDERECOS. */

            R2400_00_TRATA_ENDERECOS_SECTION();

            /*" -3104- IF WHOST-EMAIL NOT EQUAL SPACES */

            if (!WHOST_EMAIL.IsEmpty())
            {

                /*" -3106- PERFORM R2500-00-TRATA-EMAIL. */

                R2500_00_TRATA_EMAIL_SECTION();
            }


            /*" -3108- IF PROPOFID-IND-TP-PROPOSTA OF DCLPROPOSTA-FIDELIZ EQUAL 'C' OR 'V' OR 'D' OR 'E' OR 'S' */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TP_PROPOSTA.In("C", "V", "D", "E", "S"))
            {

                /*" -3109- PERFORM R2600-00-TRATA-ESTADO-CIVIL */

                R2600_00_TRATA_ESTADO_CIVIL_SECTION();

                /*" -3111- END-IF */
            }


            /*" -3112- IF WWORK-TIPO-MOVIMENTO NOT EQUAL SPACES */

            if (!W_GECLIMOV.WWORK_TIPO_MOVIMENTO.IsEmpty())
            {

                /*" -3117- PERFORM R9300-00-TRATA-MOVTO-CLIENTE. */

                R9300_00_TRATA_MOVTO_CLIENTE_SECTION();
            }


            /*" -3118- MOVE 'NAO' TO WS-TEM-ERRO-1877 */
            _.Move("NAO", WORK_AREA.WS_TEM_ERRO_1877);

            /*" -3120- MOVE 'NAO' TO WS-TEM-ERRO-1878 */
            _.Move("NAO", WORK_AREA.WS_TEM_ERRO_1878);

            /*" -3121- IF PROPOFID-ORIGEM-PROPOSTA = 1018 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA == 1018)
            {

                /*" -3136- IF PRODUVG-COD-PRODUTO OF DCLPRODUTOS-VG EQUAL 9320 OR 9321 OR 9332 OR 9353 OR 9327 OR 9328 OR 9352 OR 9351 OR 9334 OR JVPRD9320 OR JVPRD9321 OR JVPRD9332 OR JVPRD9353 OR JVPRD9327 OR JVPRD9328 OR JVPRD9352 OR JVPRD9351 OR JVPRD9334 */

                if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("9320", "9321", "9332", "9353", "9327", "9328", "9352", "9351", "9334", JVBKINCL.JV_PRODUTOS.JVPRD9320.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9321.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9332.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9353.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9327.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9328.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9352.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9351.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9334.ToString()))
                {

                    /*" -3137- CONTINUE */

                    /*" -3138- ELSE */
                }
                else
                {


                    /*" -3139- MOVE 'SIM' TO WS-TEM-ERRO-1878 */
                    _.Move("SIM", WORK_AREA.WS_TEM_ERRO_1878);

                    /*" -3140- MOVE 1878 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(1878, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -3141- PERFORM R1100-00-GRAVA-TAB-ERRO */

                    R1100_00_GRAVA_TAB_ERRO_SECTION();

                    /*" -3142- END-IF */
                }


                /*" -3150- END-IF. */
            }


            /*" -3175- IF PRODUVG-COD-PRODUTO OF DCLPRODUTOS-VG EQUAL 9320 OR 9321 OR 9332 OR 9353 OR 9352 OR 9351 OR 9327 OR 9328 OR 9334 OR JVPRD9320 OR JVPRD9321 OR JVPRD9332 OR JVPRD9353 OR JVPRD9327 OR JVPRD9328 OR JVPRD9352 OR JVPRD9351 OR JVPRD9334 OR 9356 OR 9357 OR 9358 OR 9359 OR 9360 OR 9361 OR JVPRD9356 OR JVPRD9358 OR JVPRD9360 OR JVPRD9357 OR JVPRD9359 OR JVPRD9361 */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("9320", "9321", "9332", "9353", "9352", "9351", "9327", "9328", "9334", JVBKINCL.JV_PRODUTOS.JVPRD9320.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9321.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9332.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9353.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9327.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9328.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9352.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9351.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9334.ToString(), "9356", "9357", "9358", "9359", "9360", "9361", JVBKINCL.JV_PRODUTOS.JVPRD9356.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9358.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9360.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9357.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9359.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9361.ToString()))
            {

                /*" -3176- PERFORM R1900-CONSULTA-CARENCIA */

                R1900_CONSULTA_CARENCIA_SECTION();

                /*" -3177- IF WS-TEM-CARENCIA = 'N' */

                if (WS_TEM_CARENCIA == "N")
                {

                    /*" -3178- PERFORM R5650-00-INSERE-RELATORIOS */

                    R5650_00_INSERE_RELATORIOS_SECTION();

                    /*" -3179- END-IF */
                }


                /*" -3184- END-IF */
            }


            /*" -3186- PERFORM R8580-00-TEM-RISCO-CRITICO */

            R8580_00_TEM_RISCO_CRITICO_SECTION();

            /*" -3187- IF VG001-IND-EXISTE EQUAL 'N' */

            if (SPVG001V.VG001_IND_EXISTE == "N")
            {

                /*" -3188- PERFORM R8550-00-PROCURA-RISCO-PROP */

                R8550_00_PROCURA_RISCO_PROP_SECTION();

                /*" -3190- ELSE */
            }
            else
            {


                /*" -3191- IF LK-VG001-S-STA-CRITICA NOT EQUAL '6' */

                if (SPVG001W.LK_VG001_S_STA_CRITICA != "6")
                {

                    /*" -3193- DISPLAY 'CERTIF. EM ANALISE DE CRITICA.......: ' PROPVA-NRCERTIF */
                    _.Display($"CERTIF. EM ANALISE DE CRITICA.......: {PROPVA_NRCERTIF}");

                    /*" -3195- ADD 1 TO WS-QT-EM-CRITICA */
                    WS_QT_EM_CRITICA.Value = WS_QT_EM_CRITICA + 1;

                    /*" -3196- IF LK-VG001-S-COD-MSG-CRITICA EQUAL 1 */

                    if (SPVG001W.LK_VG001_S_COD_MSG_CRITICA == 1)
                    {

                        /*" -3197- MOVE 1 TO WS-TEM-ERRO */
                        _.Move(1, WORK_AREA.WS_TEM_ERRO);

                        /*" -3198- END-IF */
                    }


                    /*" -3199- ELSE */
                }
                else
                {


                    /*" -3201- DISPLAY 'LIBERADO PARA EMISSAO APOS ANALISE..: ' PROPVA-NRCERTIF */
                    _.Display($"LIBERADO PARA EMISSAO APOS ANALISE..: {PROPVA_NRCERTIF}");

                    /*" -3202- ADD 1 TO WS-QT-LIBERADO-EMISSAO */
                    WS_QT_LIBERADO_EMISSAO.Value = WS_QT_LIBERADO_EMISSAO + 1;

                    /*" -3203- END-IF */
                }


                /*" -3206- END-IF */
            }


            /*" -3208- MOVE 'NAO' TO WS-TEM-ERRO-DPS-ELETR */
            _.Move("NAO", WS_TEM_ERRO_DPS_ELETR);

            /*" -3210- IF PRODUVG-COD-PRODUTO OF DCLPRODUTOS-VG EQUAL 9750 OR 9751 OR 9752 */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("9750", "9751", "9752"))
            {

                /*" -3211- PERFORM R8330-ANALISA-STATUS-DPS */

                R8330_ANALISA_STATUS_DPS_SECTION();

                /*" -3214- END-IF */
            }


            /*" -3215- IF WEXISTE-PRPVA EQUAL 'NAO' */

            if (WEXISTE_PRPVA == "NAO")
            {

                /*" -3216- PERFORM R3000-00-INSERT-PROPOSTAVA */

                R3000_00_INSERT_PROPOSTAVA_SECTION();

                /*" -3217- ELSE */
            }
            else
            {


                /*" -3218- PERFORM R5635-00-UPDATE-PROPOSTAVA */

                R5635_00_UPDATE_PROPOSTAVA_SECTION();

                /*" -3221- END-IF. */
            }


            /*" -3222- IF CANAL-CORRETOR */

            if (WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_CORRETOR"])
            {

                /*" -3223- PERFORM R3010-00-INSERT-COMPL_SICAQWEB */

                R3010_00_INSERT_COMPL_SICAQWEB_SECTION();

                /*" -3225- END-IF. */
            }


            /*" -3226- IF WS-SUBSCRICAO EQUAL 'S' */

            if (WS_SUBSCRICAO == "S")
            {

                /*" -3227- PERFORM R1440-00-MOVE-DADO-MATRIZ */

                R1440_00_MOVE_DADO_MATRIZ_SECTION();

                /*" -3228- PERFORM R3020-00-INSERE-ANDAMENTO */

                R3020_00_INSERE_ANDAMENTO_SECTION();

                /*" -3229- ADD 1 TO AC-I-MATRIZ */
                WORK_AREA.AC_I_MATRIZ.Value = WORK_AREA.AC_I_MATRIZ + 1;

                /*" -3231- END-IF */
            }


            /*" -3232- IF WS-INSERE-ANDAMENTO EQUAL 'S' */

            if (WS_INSERE_ANDAMENTO == "S")
            {

                /*" -3233- PERFORM R3015-00-MOVE-DADOS-ANDAMENTO */

                R3015_00_MOVE_DADOS_ANDAMENTO_SECTION();

                /*" -3234- PERFORM R3020-00-INSERE-ANDAMENTO */

                R3020_00_INSERE_ANDAMENTO_SECTION();

                /*" -3236- END-IF */
            }


            /*" -3237- IF VIND-TP-CONTA LESS ZERO */

            if (VIND_TP_CONTA < 00)
            {

                /*" -3239- MOVE SPACES TO PROPOFID-IND-TIPO-CONTA OF DCLPROPOSTA-FIDELIZ */
                _.Move("", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TIPO_CONTA);

                /*" -3241- END-IF */
            }


            /*" -3242- IF PROPOFID-IND-TIPO-CONTA OF DCLPROPOSTA-FIDELIZ = 'S' */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TIPO_CONTA == "S")
            {

                /*" -3243- PERFORM R3017-00-MOVE-DADOS-ANDAMENTO */

                R3017_00_MOVE_DADOS_ANDAMENTO_SECTION();

                /*" -3244- PERFORM R3020-00-INSERE-ANDAMENTO */

                R3020_00_INSERE_ANDAMENTO_SECTION();

                /*" -3246- END-IF */
            }


            /*" -3248- PERFORM R3100-00-INSERT-COBERPROPVA */

            R3100_00_INSERT_COBERPROPVA_SECTION();

            /*" -3250- PERFORM R3110-00-DECLARE-VGPLARAMCOB */

            R3110_00_DECLARE_VGPLARAMCOB_SECTION();

            /*" -3252- PERFORM R3150-00-DECLARE-VGPLAACES */

            R3150_00_DECLARE_VGPLAACES_SECTION();

            /*" -3255- MOVE CEP OF DCLPESSOA-ENDERECO TO CT0006S-CEP-DESTINO */
            _.Move(PESENDER.DCLPESSOA_ENDERECO.CEP, CT0006S_LINKAGE.CT0006S_CEP_DESTINO);

            /*" -3258- MOVE SIGLA-UF OF DCLPESSOA-ENDERECO TO CT0006S-SIGLA-UF */
            _.Move(PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF, CT0006S_LINKAGE.CT0006S_SIGLA_UF);

            /*" -3261- MOVE SPACES TO CT0006S-MENSAGEM. */
            _.Move("", CT0006S_LINKAGE.CT0006S_MENSAGEM);

            /*" -3264- MOVE ZEROS TO CT0006S-SQLCODE. */
            _.Move(0, CT0006S_LINKAGE.CT0006S_SQLCODE);

            /*" -3321- CALL 'CT0006S' USING CT0006S-LINKAGE. */
            _.Call("CT0006S", CT0006S_LINKAGE);

            /*" -3323- PERFORM R3200-00-INSERT-OPCAOPAGVA. */

            R3200_00_INSERT_OPCAOPAGVA_SECTION();

            /*" -3325- IF RCAP-CADASTRADO AND (PROPOFID-OPCAOPAG NOT EQUAL '3' ) */

            if (WORK_AREA.W_RCAPS["RCAP_CADASTRADO"] && (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAOPAG != "3"))
            {

                /*" -3326- PERFORM R3300-00-INSERT-COMISICOBVA */

                R3300_00_INSERT_COMISICOBVA_SECTION();

                /*" -3327- PERFORM R3400-00-INSERT-PARCELVA */

                R3400_00_INSERT_PARCELVA_SECTION();

                /*" -3328- PERFORM R3500-00-INSERT-HISTCOBVA */

                R3500_00_INSERT_HISTCOBVA_SECTION();

                /*" -3329- PERFORM R3600-00-INSERT-HISTCONTABILVA */

                R3600_00_INSERT_HISTCONTABILVA_SECTION();

                /*" -3331- END-IF */
            }


            /*" -3332- IF PROPOFID-OPCAOPAG EQUAL '3' */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAOPAG == "3")
            {

                /*" -3333- PERFORM R3410-00-INSERT-PARCELVA */

                R3410_00_INSERT_PARCELVA_SECTION();

                /*" -3334- PERFORM R3510-00-INSERT-HISTCOBVA */

                R3510_00_INSERT_HISTCOBVA_SECTION();

                /*" -3335- PERFORM R3520-00-INSERT-HISTCONTAVA */

                R3520_00_INSERT_HISTCONTAVA_SECTION();

                /*" -3336- PERFORM R3610-00-INSERT-HISTCONTABILVA */

                R3610_00_INSERT_HISTCONTABILVA_SECTION();

                /*" -3338- END-IF */
            }


            /*" -3339- IF RCAP-CADASTRADO OR (PROPOFID-OPCAOPAG EQUAL '3' ) */

            if (WORK_AREA.W_RCAPS["RCAP_CADASTRADO"] || (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAOPAG == "3"))
            {

                /*" -3340- IF PROPOFID-DATA-PROPOSTA GREATER '2010-12-31' */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA > "2010-12-31")
                {

                    /*" -3341- PERFORM R7900-00-DECLARE-VGRAMOCOMP */

                    R7900_00_DECLARE_VGRAMOCOMP_SECTION();

                    /*" -3342- PERFORM R7910-00-FETCH-VGRAMOCOMP */

                    R7910_00_FETCH_VGRAMOCOMP_SECTION();

                    /*" -3343- INITIALIZE WORK-TAB-RAMO-CONJ */
                    _.Initialize(
                        WORK_TAB_RAMO_CONJ
                    );

                    /*" -3346- MOVE ZEROS TO WS-IND WHOST-VLR-PERC-PREMIO-TOT WS-PREMIO-TOTAL-AC */
                    _.Move(0, WORK_RAMO_CONJ.WS_IND, WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO_TOT, WS_PREMIO_TOTAL_AC);

                    /*" -3350- COMPUTE WS-PREMIO-TOTAL = RCAPS-VAL-RCAP + PREMIO-AP OF DCLHIST-CONT-PARCELVA */
                    WS_PREMIO_TOTAL.Value = RCAPS.DCLRCAPS.RCAPS_VAL_RCAP + HTCTBPVA.DCLHIST_CONT_PARCELVA.PREMIO_AP;

                    /*" -3353- PERFORM R8000-00-PROCESSA-VGRAMOCOMP UNTIL WFIM-VGRAMOCOMP EQUAL 'SIM' */

                    while (!(WORK_AREA.WFIM_VGRAMOCOMP == "SIM"))
                    {

                        R8000_00_PROCESSA_VGRAMOCOMP_SECTION();
                    }

                    /*" -3354- IF WS-IND GREATER ZEROS */

                    if (WORK_RAMO_CONJ.WS_IND > 00)
                    {

                        /*" -3356- IF WHOST-RAMO NOT EQUAL TB-RAMO-CONJ (WS-IND) */

                        if (WHOST_RAMO != WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND].TB_RAMO_CONJ)
                        {

                            /*" -3357- MOVE N5WORK-TAB-RAMO-CONJ(WS-IND) TO WS-SALVA */
                            _.Move(WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND], WORK_RAMO_CONJ.WS_SALVA);

                            /*" -3360- PERFORM VARYING WS-IND1 FROM 1 BY 1 UNTIL TB-RAMO-CONJ (WS-IND1) EQUAL WHOST-RAMO OR WS-IND1 EQUAL WS-IND */

                            for (WORK_RAMO_CONJ.WS_IND1.Value = 1; !(WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND1].TB_RAMO_CONJ == WHOST_RAMO || WORK_RAMO_CONJ.WS_IND1 == WORK_RAMO_CONJ.WS_IND); WORK_RAMO_CONJ.WS_IND1.Value += 1)
                            {

                                /*" -3362- END-PERFORM */
                            }

                            /*" -3364- MOVE N5WORK-TAB-RAMO-CONJ(WS-IND1) TO N5WORK-TAB-RAMO-CONJ(WS-IND) */
                            _.Move(WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND1], WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND]);

                            /*" -3366- MOVE WS-SALVA TO N5WORK-TAB-RAMO-CONJ(WS-IND1) */
                            _.Move(WORK_RAMO_CONJ.WS_SALVA, WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND1]);

                            /*" -3367- END-IF */
                        }


                        /*" -3369- END-IF */
                    }


                    /*" -3370- MOVE 'NAO' TO WFIM-TAB-RAMO */
                    _.Move("NAO", WORK_AREA.WFIM_TAB_RAMO);

                    /*" -3371- MOVE ZEROS TO WS-IND1 */
                    _.Move(0, WORK_RAMO_CONJ.WS_IND1);

                    /*" -3373- PERFORM R8200-00-INSERT-VGHISTCONT UNTIL WFIM-TAB-RAMO EQUAL 'SIM' */

                    while (!(WORK_AREA.WFIM_TAB_RAMO == "SIM"))
                    {

                        R8200_00_INSERT_VGHISTCONT_SECTION();
                    }

                    /*" -3374- END-IF */
                }


                /*" -3376- END-IF */
            }


            /*" -3378- IF PROPOFID-NSAS-SIVPF OF DCLPROPOSTA-FIDELIZ EQUAL 01 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAS_SIVPF == 01)
            {

                /*" -3379- PERFORM R3700-00-INSERT-RELATORIOS */

                R3700_00_INSERT_RELATORIOS_SECTION();

                /*" -3381- END-IF */
            }


            /*" -3383- IF PROPOFID-SIT-PROPOSTA OF DCLPROPOSTA-FIDELIZ EQUAL 'DEC' */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA == "DEC")
            {

                /*" -3384- MOVE 1846 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1846, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -3385- PERFORM R1100-00-GRAVA-TAB-ERRO */

                R1100_00_GRAVA_TAB_ERRO_SECTION();

                /*" -3386- PERFORM R3700-00-INSERT-RELATORIOS */

                R3700_00_INSERT_RELATORIOS_SECTION();

                /*" -3388- END-IF */
            }


            /*" -3390- PERFORM R1600-00-UPDATE-PROPFID */

            R1600_00_UPDATE_PROPFID_SECTION();

            /*" -3391- IF VG001-IND-EXISTE EQUAL 'N' */

            if (SPVG001V.VG001_IND_EXISTE == "N")
            {

                /*" -3392- PERFORM R8555-00-GRAVA-RISCO-MOTOR */

                R8555_00_GRAVA_RISCO_MOTOR_SECTION();

                /*" -3394- END-IF */
            }


            /*" -3395- IF WS-I-ERRO > ZEROS */

            if (WS_I_ERRO > 00)
            {

                /*" -3396- MOVE 'S' TO WS-FLAG-TEM-ERRO */
                _.Move("S", WS_FLAG_TEM_ERRO);

                /*" -3398- MOVE 1 TO WS-I-ERRO */
                _.Move(1, WS_I_ERRO);

                /*" -3400- PERFORM R1110-00-INSERT-VG-CRTCA-PROP UNTIL WS-FLAG-TEM-ERRO EQUAL 'N' */

                while (!(WS_FLAG_TEM_ERRO == "N"))
                {

                    R1110_00_INSERT_VG_CRTCA_PROP_SECTION();
                }

                /*" -3402- END-IF. */
            }


            /*" -3403- PERFORM R1650-00-EXECUTA-COMMIT */

            R1650_00_EXECUTA_COMMIT_SECTION();

            /*" -3403- . */

        }

        [StopWatch]
        /*" R1000-CONSISTE-RCAP-DB-SELECT-1 */
        public void R1000_CONSISTE_RCAP_DB_SELECT_1()
        {
            /*" -2780- EXEC SQL SELECT NUM_PROPOSTA_AZUL INTO :WS-NUM-PROPOSTA-AZUL FROM SEGUROS.BENEF_PROP_AZUL WHERE NUM_PROPOSTA_AZUL = :WS-NUM-PROPOSTA-AZUL AND GRAU_PARENTESCO = 'ERROPF' END-EXEC. */

            var r1000_CONSISTE_RCAP_DB_SELECT_1_Query1 = new R1000_CONSISTE_RCAP_DB_SELECT_1_Query1()
            {
                WS_NUM_PROPOSTA_AZUL = WS_NUM_PROPOSTA_AZUL.ToString(),
            };

            var executed_1 = R1000_CONSISTE_RCAP_DB_SELECT_1_Query1.Execute(r1000_CONSISTE_RCAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_NUM_PROPOSTA_AZUL, WS_NUM_PROPOSTA_AZUL);
            }


        }

        [StopWatch]
        /*" R1000-10-SAIDA */
        private void R1000_10_SAIDA(bool isPerform = false)
        {
            /*" -3408- PERFORM R0910-00-FETCH-PROPOSTA. */

            R0910_00_FETCH_PROPOSTA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-GRAVA-TAB-ERRO-SECTION */
        private void R1100_00_GRAVA_TAB_ERRO_SECTION()
        {
            /*" -3418- MOVE 'R1100-00-GRAVA-TAB-ERRO' TO PARAGRAFO. */
            _.Move("R1100-00-GRAVA-TAB-ERRO", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3419- MOVE 'GRAVA TABELA INTERNA DE ERRO' TO COMANDO. */
            _.Move("GRAVA TABELA INTERNA DE ERRO", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3422- DISPLAY PARAGRAFO ' >> ' COD-ERRO OF DCLERROS-PROP-VIDAZUL */

            $"{AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO} >> {ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO}"
            .Display();

            /*" -3424- ADD 1 TO WS-I-ERRO */
            WS_I_ERRO.Value = WS_I_ERRO + 1;

            /*" -3426- MOVE COD-ERRO OF DCLERROS-PROP-VIDAZUL TO TB-ERRO-CERT(WS-I-ERRO) */
            _.Move(ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO, WORK_TAB_ERROS_CERT.WS_TAB_ERROS_CERT[WS_I_ERRO].TB_ERRO_CERT);

            /*" -3427- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1110-00-INSERT-VG-CRTCA-PROP-SECTION */
        private void R1110_00_INSERT_VG_CRTCA_PROP_SECTION()
        {
            /*" -3437- MOVE 'R1110-00-INSERT-VG-CRTCA-PROP' TO PARAGRAFO. */
            _.Move("R1110-00-INSERT-VG-CRTCA-PROP", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3438- MOVE 'INSERT VG_CRITICA_PROPOSTA   ' TO COMANDO. */
            _.Move("INSERT VG_CRITICA_PROPOSTA   ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3440- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3442- MOVE 1 TO WS-TEM-ERRO. */
            _.Move(1, WORK_AREA.WS_TEM_ERRO);

            /*" -3444- INITIALIZE LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
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

            /*" -3445- MOVE 'N' TO LK-VG001-TRACE */
            _.Move("N", SPVG001W.LK_VG001_TRACE);

            /*" -3446- MOVE 02 TO LK-VG001-TIPO-ACAO */
            _.Move(02, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -3448- MOVE PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO LK-VG001-NUM-CERTIFICADO */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, SPVG001W.LK_VG001_NUM_CERTIFICADO);

            /*" -3449- MOVE TB-ERRO-CERT(WS-I-ERRO) TO LK-VG001-COD-MSG-CRITICA */
            _.Move(WORK_TAB_ERROS_CERT.WS_TAB_ERROS_CERT[WS_I_ERRO].TB_ERRO_CERT, SPVG001W.LK_VG001_COD_MSG_CRITICA);

            /*" -3450- MOVE 0 TO LK-VG001-SEQ-CRITICA */
            _.Move(0, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -3451- MOVE 'PF' TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("PF", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -3452- MOVE 0 TO LK-VG001-NUM-CPF-CNPJ */
            _.Move(0, SPVG001W.LK_VG001_NUM_CPF_CNPJ);

            /*" -3453- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -3454- MOVE 'VA0601B' TO LK-VG001-NOM-PROGRAMA */
            _.Move("VA0601B", SPVG001W.LK_VG001_NOM_PROGRAMA);

            /*" -3455- MOVE 'SPBVG001' TO VG001-PROGRAMA */
            _.Move("SPBVG001", SPVG001V.VG001_PROGRAMA);

            /*" -3456- MOVE SPACES TO LK-VG001-STA-CRITICA */
            _.Move("", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -3457- MOVE 50 TO LK-VG001-DES-COMPLEMENTAR-L */
            _.Move(50, SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_L);

            /*" -3460- MOVE 'INSERCAO DE ERRO NA EMISSAO DA PROPOSTA' TO LK-VG001-DES-COMPLEMENTAR-T */
            _.Move("INSERCAO DE ERRO NA EMISSAO DA PROPOSTA", SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_T);

            /*" -3462- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -3463- IF LK-VG001-IND-ERRO NOT EQUAL ZEROS */

            if (SPVG001W.LK_VG001_IND_ERRO != 00)
            {

                /*" -3464- IF LK-VG001-IND-ERRO EQUAL 1 */

                if (SPVG001W.LK_VG001_IND_ERRO == 1)
                {

                    /*" -3469- DISPLAY 'ERRO JAH GRAVADO 1110 >> ' LK-VG001-NUM-CERTIFICADO ' >> ' LK-VG001-COD-MSG-CRITICA ' >> ' LK-VG001-MSG-ERRO ' >> ' LK-VG001-IND-ERRO */

                    $"ERRO JAH GRAVADO 1110 >> {SPVG001W.LK_VG001_NUM_CERTIFICADO} >> {SPVG001W.LK_VG001_COD_MSG_CRITICA} >> {SPVG001W.LK_VG001_MSG_ERRO} >> {SPVG001W.LK_VG001_IND_ERRO}"
                    .Display();

                    /*" -3470- ELSE */
                }
                else
                {


                    /*" -3471- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -3472- DISPLAY '* 1110 -  PROBLEMAS CALL SUBROTINA SPBVG001 *' */
                    _.Display($"* 1110 -  PROBLEMAS CALL SUBROTINA SPBVG001 *");

                    /*" -3473- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -3474- DISPLAY '* NUM-CERTIF..: ' LK-VG001-NUM-CERTIFICADO */
                    _.Display($"* NUM-CERTIF..: {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                    /*" -3475- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                    _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                    /*" -3476- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                    _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                    /*" -3477- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                    _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                    /*" -3478- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                    _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                    /*" -3479- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                    _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                    /*" -3481- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -3482- MOVE 999 TO SQLCODE */
                    _.Move(999, DB.SQLCODE);

                    /*" -3483- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3484- END-IF */
                }


                /*" -3486- END-IF */
            }


            /*" -3488- ADD 1 TO WS-I-ERRO */
            WS_I_ERRO.Value = WS_I_ERRO + 1;

            /*" -3489- IF TB-ERRO-CERT(WS-I-ERRO) EQUAL ZEROS */

            if (WORK_TAB_ERROS_CERT.WS_TAB_ERROS_CERT[WS_I_ERRO].TB_ERRO_CERT == 00)
            {

                /*" -3490- MOVE 'N' TO WS-FLAG-TEM-ERRO */
                _.Move("N", WS_FLAG_TEM_ERRO);

                /*" -3491- END-IF */
            }


            /*" -3492- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_99_SAIDA*/

        [StopWatch]
        /*" R1150-00-IDADE-CONJUGE-SECTION */
        private void R1150_00_IDADE_CONJUGE_SECTION()
        {
            /*" -3582- MOVE '1150-00-IDADE-CONJUGE        ' TO PARAGRAFO. */
            _.Move("1150-00-IDADE-CONJUGE        ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3584- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3585- IF VIND-DATA-NASC-CONJUGE LESS ZEROS */

            if (VIND_DATA_NASC_CONJUGE < 00)
            {

                /*" -3587- MOVE '0001-01-01' TO WS-DTNASC */
                _.Move("0001-01-01", WORK_AREA.WS_DTNASC);

                /*" -3588- ELSE */
            }
            else
            {


                /*" -3590- MOVE PROPOFID-DATA-NASC-CONJUGE OF DCLPROPOSTA-FIDELIZ TO WS-DTNASC. */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_NASC_CONJUGE, WORK_AREA.WS_DTNASC);
            }


            /*" -3593- MOVE PROPOFID-DATA-PROPOSTA OF DCLPROPOSTA-FIDELIZ TO WS-DTPROP. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA, WORK_AREA.WS_DTPROP);

            /*" -3596- COMPUTE WHOST-IDADE-CONJUGE = WS-AA-DTPROP - WS-AA-DTNASC. */
            WHOST_IDADE_CONJUGE.Value = WORK_AREA.WS_DTPROP.WS_AA_DTPROP - WORK_AREA.WS_DTNASC.WS_AA_DTNASC;

            /*" -3597- IF WS-MM-DTNASC GREATER WS-MM-DTPROP */

            if (WORK_AREA.WS_DTNASC.WS_MM_DTNASC > WORK_AREA.WS_DTPROP.WS_MM_DTPROP)
            {

                /*" -3598- SUBTRACT 1 FROM WHOST-IDADE-CONJUGE */
                WHOST_IDADE_CONJUGE.Value = WHOST_IDADE_CONJUGE - 1;

                /*" -3599- ELSE */
            }
            else
            {


                /*" -3600- IF WS-MM-DTNASC EQUAL WS-MM-DTPROP */

                if (WORK_AREA.WS_DTNASC.WS_MM_DTNASC == WORK_AREA.WS_DTPROP.WS_MM_DTPROP)
                {

                    /*" -3601- IF WS-DD-DTNASC GREATER WS-DD-DTPROP */

                    if (WORK_AREA.WS_DTNASC.WS_DD_DTNASC > WORK_AREA.WS_DTPROP.WS_DD_DTPROP)
                    {

                        /*" -3601- SUBTRACT 1 FROM WHOST-IDADE-CONJUGE. */
                        WHOST_IDADE_CONJUGE.Value = WHOST_IDADE_CONJUGE - 1;
                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1150_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SELECT-ESTIPULANTE-SECTION */
        private void R1200_00_SELECT_ESTIPULANTE_SECTION()
        {
            /*" -3611- MOVE '1200-00-SELECT-ESTIPULANTE   ' TO PARAGRAFO. */
            _.Move("1200-00-SELECT-ESTIPULANTE   ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3612- MOVE 'SELECT ESTIPULANTE           ' TO COMANDO. */
            _.Move("SELECT ESTIPULANTE           ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3614- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3615- MOVE 06 TO SII. */
            _.Move(06, WS_HORAS.SII);

            /*" -3616- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -3623- PERFORM R1200_00_SELECT_ESTIPULANTE_DB_SELECT_1 */

            R1200_00_SELECT_ESTIPULANTE_DB_SELECT_1();

            /*" -3626- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -3627- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -3628- DISPLAY 'PROBLEMAS NO SELECT A ESTIPULANTE       ' */
                _.Display($"PROBLEMAS NO SELECT A ESTIPULANTE       ");

                /*" -3628- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1200-00-SELECT-ESTIPULANTE-DB-SELECT-1 */
        public void R1200_00_SELECT_ESTIPULANTE_DB_SELECT_1()
        {
            /*" -3623- EXEC SQL SELECT NOME_ESTIPULANTE INTO :DCLESTIPULANTE.ESTIPULA-NOME-ESTIPULANTE FROM SEGUROS.ESTIPULANTE WHERE COD_CCT = :DCLPROPOSTA-FIDELIZ.PROPOFID-CGC-CONVENENTE AND DATA_TERVIGENCIA = '9999-12-31' END-EXEC. */

            var r1200_00_SELECT_ESTIPULANTE_DB_SELECT_1_Query1 = new R1200_00_SELECT_ESTIPULANTE_DB_SELECT_1_Query1()
            {
                PROPOFID_CGC_CONVENENTE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CGC_CONVENENTE.ToString(),
            };

            var executed_1 = R1200_00_SELECT_ESTIPULANTE_DB_SELECT_1_Query1.Execute(r1200_00_SELECT_ESTIPULANTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ESTIPULA_NOME_ESTIPULANTE, ESTIPULA.DCLESTIPULANTE.ESTIPULA_NOME_ESTIPULANTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-SELECT-FUNCIOCEF-SECTION */
        private void R1300_00_SELECT_FUNCIOCEF_SECTION()
        {
            /*" -3688- MOVE '1300-00-SELECT-FUNCIOCEF     ' TO PARAGRAFO. */
            _.Move("1300-00-SELECT-FUNCIOCEF     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3689- MOVE 'SELECT FUNCIOCEF     ' TO COMANDO. */
            _.Move("SELECT FUNCIOCEF     ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3691- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3692- MOVE 08 TO SII. */
            _.Move(08, WS_HORAS.SII);

            /*" -3693- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -3699- PERFORM R1300_00_SELECT_FUNCIOCEF_DB_SELECT_1 */

            R1300_00_SELECT_FUNCIOCEF_DB_SELECT_1();

            /*" -3702- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -3703- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -3704- DISPLAY 'PROBLEMAS NO SELECT A FUNCIOCEF         ' */
                _.Display($"PROBLEMAS NO SELECT A FUNCIOCEF         ");

                /*" -3704- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1300-00-SELECT-FUNCIOCEF-DB-SELECT-1 */
        public void R1300_00_SELECT_FUNCIOCEF_DB_SELECT_1()
        {
            /*" -3699- EXEC SQL SELECT NOME_FUNCIONARIO INTO :DCLFUNCIONARIOS-CEF.FUNCICEF-NOME-FUNCIONARIO FROM SEGUROS.FUNCIONARIOS_CEF WHERE NUM_MATRICULA = :DCLPROPOSTA-FIDELIZ.PROPOFID-NRMATRVEN END-EXEC. */

            var r1300_00_SELECT_FUNCIOCEF_DB_SELECT_1_Query1 = new R1300_00_SELECT_FUNCIOCEF_DB_SELECT_1_Query1()
            {
                PROPOFID_NRMATRVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN.ToString(),
            };

            var executed_1 = R1300_00_SELECT_FUNCIOCEF_DB_SELECT_1_Query1.Execute(r1300_00_SELECT_FUNCIOCEF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FUNCICEF_NOME_FUNCIONARIO, FUNCICEF.DCLFUNCIONARIOS_CEF.FUNCICEF_NOME_FUNCIONARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-SELECT-PLANOS-VA-SECTION */
        private void R1400_00_SELECT_PLANOS_VA_SECTION()
        {
            /*" -3715- MOVE '1400-00-SELECT-PLANOS-VA     ' TO PARAGRAFO. */
            _.Move("1400-00-SELECT-PLANOS-VA     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3717- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3718- MOVE DATA-NASCIMENTO OF DCLPESSOA-FISICA TO WS-DTNASC. */
            _.Move(PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO, WORK_AREA.WS_DTNASC);

            /*" -3721- MOVE PROPOFID-DATA-PROPOSTA OF DCLPROPOSTA-FIDELIZ TO WS-DTPROP. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA, WORK_AREA.WS_DTPROP);

            /*" -3724- COMPUTE WHOST-IDADE = WS-AA-DTPROP - WS-AA-DTNASC. */
            WHOST_IDADE.Value = WORK_AREA.WS_DTPROP.WS_AA_DTPROP - WORK_AREA.WS_DTNASC.WS_AA_DTNASC;

            /*" -3725- IF WS-MM-DTNASC GREATER WS-MM-DTPROP */

            if (WORK_AREA.WS_DTNASC.WS_MM_DTNASC > WORK_AREA.WS_DTPROP.WS_MM_DTPROP)
            {

                /*" -3726- SUBTRACT 1 FROM WHOST-IDADE */
                WHOST_IDADE.Value = WHOST_IDADE - 1;

                /*" -3727- ELSE */
            }
            else
            {


                /*" -3728- IF WS-MM-DTNASC EQUAL WS-MM-DTPROP */

                if (WORK_AREA.WS_DTNASC.WS_MM_DTNASC == WORK_AREA.WS_DTPROP.WS_MM_DTPROP)
                {

                    /*" -3729- IF WS-DD-DTNASC GREATER WS-DD-DTPROP */

                    if (WORK_AREA.WS_DTNASC.WS_DD_DTNASC > WORK_AREA.WS_DTPROP.WS_DD_DTPROP)
                    {

                        /*" -3731- SUBTRACT 1 FROM WHOST-IDADE. */
                        WHOST_IDADE.Value = WHOST_IDADE - 1;
                    }

                }

            }


            /*" -3733- MOVE '1400-00-SELECT-PLANOS-VA-VGAP' TO PARAGRAFO. */
            _.Move("1400-00-SELECT-PLANOS-VA-VGAP", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3734- MOVE 09 TO SII. */
            _.Move(09, WS_HORAS.SII);

            /*" -3735- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -3785- PERFORM R1400_00_SELECT_PLANOS_VA_DB_SELECT_1 */

            R1400_00_SELECT_PLANOS_VA_DB_SELECT_1();

            /*" -3788- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -3789- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3790- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -3792- DISPLAY 'VA0601B * PROBLEMAS NO SELECT PLANOS_VA_VGAP' SQLCODE */
                    _.Display($"VA0601B * PROBLEMAS NO SELECT PLANOS_VA_VGAP{DB.SQLCODE}");

                    /*" -3794- DISPLAY '          PROPOSTA PROCESSADA...............' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          PROPOSTA PROCESSADA...............{PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -3795- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3796- ELSE */
                }
                else
                {


                    /*" -3797- CONTINUE */

                    /*" -3798- END-IF */
                }


                /*" -3799- ELSE */
            }
            else
            {


                /*" -3800- MOVE 1 TO W-PLANO */
                _.Move(1, WORK_AREA.W_PLANO);

                /*" -3802- END-IF */
            }


            /*" -3804- MOVE '1400-01-SELECT-PLANOS-VA-VGAP' TO PARAGRAFO. */
            _.Move("1400-01-SELECT-PLANOS-VA-VGAP", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3805- MOVE 10 TO SII. */
            _.Move(10, WS_HORAS.SII);

            /*" -3806- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -3820- PERFORM R1400_00_SELECT_PLANOS_VA_DB_SELECT_2 */

            R1400_00_SELECT_PLANOS_VA_DB_SELECT_2();

            /*" -3821- PERFORM R9100-00-TERMINO. */

            R9100_00_TERMINO_SECTION();

        }

        [StopWatch]
        /*" R1400-00-SELECT-PLANOS-VA-DB-SELECT-1 */
        public void R1400_00_SELECT_PLANOS_VA_DB_SELECT_1()
        {
            /*" -3785- EXEC SQL SELECT IMPMORNATU, IMPMORACID, IMPINVPERM, IMPAMDS, IMPDH, IMPDIT, VLPREMIOTOT, PRMVG, PRMAP, QTTITCAP, VLTITCAP, VLCUSTCAP, IMPSEGCDG, VLCUSTCDG, IMPSEGAUXF, VLCUSTAUXF, PRMDIT, QTDIT INTO :DCLPLANOS-VA-VGAP.IMPMORNATU, :DCLPLANOS-VA-VGAP.IMPMORACID, :DCLPLANOS-VA-VGAP.IMPINVPERM, :DCLPLANOS-VA-VGAP.IMPAMDS, :DCLPLANOS-VA-VGAP.IMPDH, :DCLPLANOS-VA-VGAP.IMPDIT, :DCLPLANOS-VA-VGAP.VLPREMIOTOT, :DCLPLANOS-VA-VGAP.PRMVG, :DCLPLANOS-VA-VGAP.PRMAP, :DCLPLANOS-VA-VGAP.QTTITCAP, :DCLPLANOS-VA-VGAP.VLTITCAP, :DCLPLANOS-VA-VGAP.VLCUSTCAP, :DCLPLANOS-VA-VGAP.IMPSEGCDG, :DCLPLANOS-VA-VGAP.VLCUSTCDG, :DCLPLANOS-VA-VGAP.IMPSEGAUXF, :DCLPLANOS-VA-VGAP.VLCUSTAUXF, :DCLPLANOS-VA-VGAP.PRMDIT, :DCLPLANOS-VA-VGAP.QTDIT FROM SEGUROS.PLANOS_VA_VGAP WHERE NUM_APOLICE = :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE AND CODSUBES = :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO AND OPCAO_COBER = :DCLPROPOSTA-FIDELIZ.PROPOFID-OPCAO-COBER AND DTINIVIG <= :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO AND DTTERVIG >= :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO AND IDADE_INICIAL <= :WHOST-IDADE AND IDADE_FINAL >= :WHOST-IDADE END-EXEC. */

            var r1400_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1 = new R1400_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1()
            {
                PROPSSVD_COD_SUBGRUPO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.ToString(),
                PROPOFID_OPCAO_COBER = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER.ToString(),
                PROPSSVD_NUM_APOLICE = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.ToString(),
                PROPOFID_DTQITBCO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.ToString(),
                WHOST_IDADE = WHOST_IDADE.ToString(),
            };

            var executed_1 = R1400_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1.Execute(r1400_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.IMPMORNATU, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU);
                _.Move(executed_1.IMPMORACID, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORACID);
                _.Move(executed_1.IMPINVPERM, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPINVPERM);
                _.Move(executed_1.IMPAMDS, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPAMDS);
                _.Move(executed_1.IMPDH, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPDH);
                _.Move(executed_1.IMPDIT, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPDIT);
                _.Move(executed_1.VLPREMIOTOT, PLVAVGAP.DCLPLANOS_VA_VGAP.VLPREMIOTOT);
                _.Move(executed_1.PRMVG, PLVAVGAP.DCLPLANOS_VA_VGAP.PRMVG);
                _.Move(executed_1.PRMAP, PLVAVGAP.DCLPLANOS_VA_VGAP.PRMAP);
                _.Move(executed_1.QTTITCAP, PLVAVGAP.DCLPLANOS_VA_VGAP.QTTITCAP);
                _.Move(executed_1.VLTITCAP, PLVAVGAP.DCLPLANOS_VA_VGAP.VLTITCAP);
                _.Move(executed_1.VLCUSTCAP, PLVAVGAP.DCLPLANOS_VA_VGAP.VLCUSTCAP);
                _.Move(executed_1.IMPSEGCDG, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPSEGCDG);
                _.Move(executed_1.VLCUSTCDG, PLVAVGAP.DCLPLANOS_VA_VGAP.VLCUSTCDG);
                _.Move(executed_1.IMPSEGAUXF, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPSEGAUXF);
                _.Move(executed_1.VLCUSTAUXF, PLVAVGAP.DCLPLANOS_VA_VGAP.VLCUSTAUXF);
                _.Move(executed_1.PRMDIT, PLVAVGAP.DCLPLANOS_VA_VGAP.PRMDIT);
                _.Move(executed_1.QTDIT, PLVAVGAP.DCLPLANOS_VA_VGAP.QTDIT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-SELECT-PLANOS-VA-DB-SELECT-2 */
        public void R1400_00_SELECT_PLANOS_VA_DB_SELECT_2()
        {
            /*" -3820- EXEC SQL SELECT VALUE (MAX(IMPMORNATU),0) INTO :WHOST-IMPMORNATU-MAX FROM SEGUROS.PLANOS_VA_VGAP WHERE NUM_APOLICE = :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE AND CODSUBES = :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO AND DTINIVIG <= :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO AND DTTERVIG >= :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO AND IDADE_INICIAL <= :WHOST-IDADE AND IDADE_FINAL >= :WHOST-IDADE END-EXEC. */

            var r1400_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1 = new R1400_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1()
            {
                PROPSSVD_COD_SUBGRUPO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.ToString(),
                PROPSSVD_NUM_APOLICE = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.ToString(),
                PROPOFID_DTQITBCO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.ToString(),
                WHOST_IDADE = WHOST_IDADE.ToString(),
            };

            var executed_1 = R1400_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1.Execute(r1400_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_IMPMORNATU_MAX, WHOST_IMPMORNATU_MAX);
            }


        }

        [StopWatch]
        /*" R1401-00-SELECT-PLANOS-VA-SECTION */
        private void R1401_00_SELECT_PLANOS_VA_SECTION()
        {
            /*" -3831- MOVE '1401-00-SELECT-PLANOS-VA     ' TO PARAGRAFO. */
            _.Move("1401-00-SELECT-PLANOS-VA     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3833- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3834- MOVE DATA-NASCIMENTO OF DCLPESSOA-FISICA TO WS-DTNASC */
            _.Move(PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO, WORK_AREA.WS_DTNASC);

            /*" -3837- MOVE PROPOFID-DATA-PROPOSTA OF DCLPROPOSTA-FIDELIZ TO WS-DTPROP */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA, WORK_AREA.WS_DTPROP);

            /*" -3840- COMPUTE WHOST-IDADE = WS-AA-DTPROP - WS-AA-DTNASC */
            WHOST_IDADE.Value = WORK_AREA.WS_DTPROP.WS_AA_DTPROP - WORK_AREA.WS_DTNASC.WS_AA_DTNASC;

            /*" -3841- IF WS-MM-DTNASC GREATER WS-MM-DTPROP */

            if (WORK_AREA.WS_DTNASC.WS_MM_DTNASC > WORK_AREA.WS_DTPROP.WS_MM_DTPROP)
            {

                /*" -3842- SUBTRACT 1 FROM WHOST-IDADE */
                WHOST_IDADE.Value = WHOST_IDADE - 1;

                /*" -3843- ELSE */
            }
            else
            {


                /*" -3844- IF WS-MM-DTNASC EQUAL WS-MM-DTPROP */

                if (WORK_AREA.WS_DTNASC.WS_MM_DTNASC == WORK_AREA.WS_DTPROP.WS_MM_DTPROP)
                {

                    /*" -3845- IF WS-DD-DTNASC GREATER WS-DD-DTPROP */

                    if (WORK_AREA.WS_DTNASC.WS_DD_DTNASC > WORK_AREA.WS_DTPROP.WS_DD_DTPROP)
                    {

                        /*" -3846- SUBTRACT 1 FROM WHOST-IDADE */
                        WHOST_IDADE.Value = WHOST_IDADE - 1;

                        /*" -3847- END-IF */
                    }


                    /*" -3848- END-IF */
                }


                /*" -3850- END-IF */
            }


            /*" -3852- MOVE '1401-00-SELECT-PLANOS-VA-VGAP' TO PARAGRAFO */
            _.Move("1401-00-SELECT-PLANOS-VA-VGAP", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3853- MOVE 11 TO SII */
            _.Move(11, WS_HORAS.SII);

            /*" -3854- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -3870- PERFORM R1401_00_SELECT_PLANOS_VA_DB_SELECT_1 */

            R1401_00_SELECT_PLANOS_VA_DB_SELECT_1();

            /*" -3873- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -3874- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3875- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -3877- DISPLAY 'VA0601B - PROBLEMAS NO SELECT PLANOS_VA_VGAP' SQLCODE */
                    _.Display($"VA0601B - PROBLEMAS NO SELECT PLANOS_VA_VGAP{DB.SQLCODE}");

                    /*" -3879- DISPLAY 'R1401  -  PROPOSTA PROCESSADA...............' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"R1401  -  PROPOSTA PROCESSADA...............{PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -3880- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3881- ELSE */
                }
                else
                {


                    /*" -3887- DISPLAY 'R1401 NAO ENCONTROU PLANOS-VA-VGAP ' PROPSSVD-NUM-APOLICE ' ' PROPSSVD-COD-SUBGRUPO ' ' PROPOFID-OPCAO-COBER ' ' PROPOFID-DTQITBCO ' ' WHOST-IDADE */

                    $"R1401 NAO ENCONTROU PLANOS-VA-VGAP {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE} {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO} {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER} {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO} {WHOST_IDADE}"
                    .Display();

                    /*" -3888- END-IF */
                }


                /*" -3890- END-IF */
            }


            /*" -3890- . */

        }

        [StopWatch]
        /*" R1401-00-SELECT-PLANOS-VA-DB-SELECT-1 */
        public void R1401_00_SELECT_PLANOS_VA_DB_SELECT_1()
        {
            /*" -3870- EXEC SQL SELECT VALUE (IMPMORNATU,0) INTO :WHOST-IMPMORNATU FROM SEGUROS.PLANOS_VA_VGAP WHERE NUM_APOLICE = :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE AND CODSUBES = :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO AND OPCAO_COBER = :DCLPROPOSTA-FIDELIZ.PROPOFID-OPCAO-COBER AND DTINIVIG <= :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO AND DTTERVIG >= :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO AND IDADE_INICIAL <= :WHOST-IDADE AND IDADE_FINAL >= :WHOST-IDADE END-EXEC. */

            var r1401_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1 = new R1401_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1()
            {
                PROPSSVD_COD_SUBGRUPO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.ToString(),
                PROPOFID_OPCAO_COBER = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER.ToString(),
                PROPSSVD_NUM_APOLICE = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.ToString(),
                PROPOFID_DTQITBCO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.ToString(),
                WHOST_IDADE = WHOST_IDADE.ToString(),
            };

            var executed_1 = R1401_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1.Execute(r1401_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_IMPMORNATU, WHOST_IMPMORNATU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1401_99_SAIDA*/

        [StopWatch]
        /*" R1410-00-SELECT-PLANOS-VA-SECTION */
        private void R1410_00_SELECT_PLANOS_VA_SECTION()
        {
            /*" -3900- MOVE '1410-00-SELECT-PLANOS-VA     ' TO PARAGRAFO. */
            _.Move("1410-00-SELECT-PLANOS-VA     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3902- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3903- MOVE DATA-NASCIMENTO OF DCLPESSOA-FISICA TO WS-DTNASC. */
            _.Move(PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO, WORK_AREA.WS_DTNASC);

            /*" -3906- MOVE PROPOFID-DATA-PROPOSTA OF DCLPROPOSTA-FIDELIZ TO WS-DTPROP. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA, WORK_AREA.WS_DTPROP);

            /*" -3909- COMPUTE WHOST-IDADE = WS-AA-DTPROP - WS-AA-DTNASC. */
            WHOST_IDADE.Value = WORK_AREA.WS_DTPROP.WS_AA_DTPROP - WORK_AREA.WS_DTNASC.WS_AA_DTNASC;

            /*" -3910- IF WS-MM-DTNASC GREATER WS-MM-DTPROP */

            if (WORK_AREA.WS_DTNASC.WS_MM_DTNASC > WORK_AREA.WS_DTPROP.WS_MM_DTPROP)
            {

                /*" -3911- SUBTRACT 1 FROM WHOST-IDADE */
                WHOST_IDADE.Value = WHOST_IDADE - 1;

                /*" -3912- ELSE */
            }
            else
            {


                /*" -3913- IF WS-MM-DTNASC EQUAL WS-MM-DTPROP */

                if (WORK_AREA.WS_DTNASC.WS_MM_DTNASC == WORK_AREA.WS_DTPROP.WS_MM_DTPROP)
                {

                    /*" -3914- IF WS-DD-DTNASC GREATER WS-DD-DTPROP */

                    if (WORK_AREA.WS_DTNASC.WS_DD_DTNASC > WORK_AREA.WS_DTPROP.WS_DD_DTPROP)
                    {

                        /*" -3916- SUBTRACT 1 FROM WHOST-IDADE. */
                        WHOST_IDADE.Value = WHOST_IDADE - 1;
                    }

                }

            }


            /*" -3918- MOVE '1410-00-SELECT-PLANOS-VA-VGAP' TO PARAGRAFO. */
            _.Move("1410-00-SELECT-PLANOS-VA-VGAP", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3919- MOVE 12 TO SII. */
            _.Move(12, WS_HORAS.SII);

            /*" -3920- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -3972- PERFORM R1410_00_SELECT_PLANOS_VA_DB_SELECT_1 */

            R1410_00_SELECT_PLANOS_VA_DB_SELECT_1();

            /*" -3975- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -3976- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3977- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -3979- DISPLAY 'VA0601B - ERRO NO SELECT PLANOS_VA_VGAP' SQLCODE */
                    _.Display($"VA0601B - ERRO NO SELECT PLANOS_VA_VGAP{DB.SQLCODE}");

                    /*" -3981- DISPLAY '          PROPOSTA PROCESSADA...............' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          PROPOSTA PROCESSADA...............{PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -3982- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3983- ELSE */
                }
                else
                {


                    /*" -3984- CONTINUE */

                    /*" -3985- END-IF */
                }


                /*" -3986- ELSE */
            }
            else
            {


                /*" -3987- MOVE 1 TO W-PLANO */
                _.Move(1, WORK_AREA.W_PLANO);

                /*" -3989- END-IF */
            }


            /*" -3991- MOVE '1410-01-SELECT-PLANOS-VA-VGAP' TO PARAGRAFO. */
            _.Move("1410-01-SELECT-PLANOS-VA-VGAP", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3992- MOVE 13 TO SII. */
            _.Move(13, WS_HORAS.SII);

            /*" -3993- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -4011- PERFORM R1410_00_SELECT_PLANOS_VA_DB_SELECT_2 */

            R1410_00_SELECT_PLANOS_VA_DB_SELECT_2();

            /*" -4012- PERFORM R9100-00-TERMINO. */

            R9100_00_TERMINO_SECTION();

        }

        [StopWatch]
        /*" R1410-00-SELECT-PLANOS-VA-DB-SELECT-1 */
        public void R1410_00_SELECT_PLANOS_VA_DB_SELECT_1()
        {
            /*" -3972- EXEC SQL SELECT IMPMORNATU, IMPMORACID, IMPINVPERM, IMPAMDS, IMPDH, IMPDIT, VLPREMIOTOT, PRMVG, PRMAP, QTTITCAP, VLTITCAP, VLCUSTCAP, IMPSEGCDG, VLCUSTCDG, IMPSEGAUXF, VLCUSTAUXF, PRMDIT, QTDIT INTO :DCLPLANOS-VA-VGAP.IMPMORNATU, :DCLPLANOS-VA-VGAP.IMPMORACID, :DCLPLANOS-VA-VGAP.IMPINVPERM, :DCLPLANOS-VA-VGAP.IMPAMDS, :DCLPLANOS-VA-VGAP.IMPDH, :DCLPLANOS-VA-VGAP.IMPDIT, :DCLPLANOS-VA-VGAP.VLPREMIOTOT, :DCLPLANOS-VA-VGAP.PRMVG, :DCLPLANOS-VA-VGAP.PRMAP, :DCLPLANOS-VA-VGAP.QTTITCAP, :DCLPLANOS-VA-VGAP.VLTITCAP, :DCLPLANOS-VA-VGAP.VLCUSTCAP, :DCLPLANOS-VA-VGAP.IMPSEGCDG, :DCLPLANOS-VA-VGAP.VLCUSTCDG, :DCLPLANOS-VA-VGAP.IMPSEGAUXF, :DCLPLANOS-VA-VGAP.VLCUSTAUXF, :DCLPLANOS-VA-VGAP.PRMDIT, :DCLPLANOS-VA-VGAP.QTDIT FROM SEGUROS.PLANOS_VA_VGAP WHERE NUM_APOLICE = :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE AND CODSUBES = :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO AND COD_PLANO = :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PLANO AND OPCAO_COBER = :DCLPROPOSTA-FIDELIZ.PROPOFID-OPCAO-COBER AND DTINIVIG <= :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO AND DTTERVIG >= :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO AND IDADE_INICIAL <= :WHOST-IDADE AND IDADE_FINAL >= :WHOST-IDADE END-EXEC. */

            var r1410_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1 = new R1410_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1()
            {
                PROPSSVD_COD_SUBGRUPO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.ToString(),
                PROPOFID_OPCAO_COBER = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER.ToString(),
                PROPSSVD_NUM_APOLICE = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.ToString(),
                PROPOFID_COD_PLANO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO.ToString(),
                PROPOFID_DTQITBCO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.ToString(),
                WHOST_IDADE = WHOST_IDADE.ToString(),
            };

            var executed_1 = R1410_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1.Execute(r1410_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.IMPMORNATU, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU);
                _.Move(executed_1.IMPMORACID, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORACID);
                _.Move(executed_1.IMPINVPERM, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPINVPERM);
                _.Move(executed_1.IMPAMDS, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPAMDS);
                _.Move(executed_1.IMPDH, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPDH);
                _.Move(executed_1.IMPDIT, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPDIT);
                _.Move(executed_1.VLPREMIOTOT, PLVAVGAP.DCLPLANOS_VA_VGAP.VLPREMIOTOT);
                _.Move(executed_1.PRMVG, PLVAVGAP.DCLPLANOS_VA_VGAP.PRMVG);
                _.Move(executed_1.PRMAP, PLVAVGAP.DCLPLANOS_VA_VGAP.PRMAP);
                _.Move(executed_1.QTTITCAP, PLVAVGAP.DCLPLANOS_VA_VGAP.QTTITCAP);
                _.Move(executed_1.VLTITCAP, PLVAVGAP.DCLPLANOS_VA_VGAP.VLTITCAP);
                _.Move(executed_1.VLCUSTCAP, PLVAVGAP.DCLPLANOS_VA_VGAP.VLCUSTCAP);
                _.Move(executed_1.IMPSEGCDG, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPSEGCDG);
                _.Move(executed_1.VLCUSTCDG, PLVAVGAP.DCLPLANOS_VA_VGAP.VLCUSTCDG);
                _.Move(executed_1.IMPSEGAUXF, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPSEGAUXF);
                _.Move(executed_1.VLCUSTAUXF, PLVAVGAP.DCLPLANOS_VA_VGAP.VLCUSTAUXF);
                _.Move(executed_1.PRMDIT, PLVAVGAP.DCLPLANOS_VA_VGAP.PRMDIT);
                _.Move(executed_1.QTDIT, PLVAVGAP.DCLPLANOS_VA_VGAP.QTDIT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1410_99_SAIDA*/

        [StopWatch]
        /*" R1410-00-SELECT-PLANOS-VA-DB-SELECT-2 */
        public void R1410_00_SELECT_PLANOS_VA_DB_SELECT_2()
        {
            /*" -4011- EXEC SQL SELECT VALUE (MAX(IMPMORNATU),0) INTO :WHOST-IMPMORNATU-MAX FROM SEGUROS.PLANOS_VA_VGAP WHERE NUM_APOLICE = :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE AND CODSUBES = :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO AND COD_PLANO = :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PLANO AND OPCAO_COBER = :DCLPROPOSTA-FIDELIZ.PROPOFID-OPCAO-COBER AND DTINIVIG <= :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO AND DTTERVIG >= :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO AND IDADE_INICIAL <= :WHOST-IDADE AND IDADE_FINAL >= :WHOST-IDADE END-EXEC. */

            var r1410_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1 = new R1410_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1()
            {
                PROPSSVD_COD_SUBGRUPO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.ToString(),
                PROPOFID_OPCAO_COBER = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER.ToString(),
                PROPSSVD_NUM_APOLICE = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.ToString(),
                PROPOFID_COD_PLANO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO.ToString(),
                PROPOFID_DTQITBCO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.ToString(),
                WHOST_IDADE = WHOST_IDADE.ToString(),
            };

            var executed_1 = R1410_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1.Execute(r1410_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_IMPMORNATU_MAX, WHOST_IMPMORNATU_MAX);
            }


        }

        [StopWatch]
        /*" R1420-VERIFICA-MATRIZ-SECTION */
        private void R1420_VERIFICA_MATRIZ_SECTION()
        {
            /*" -4023- MOVE 'R1420-VERIFICA-MATRIZ' TO PARAGRAFO */
            _.Move("R1420-VERIFICA-MATRIZ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4025- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4036- PERFORM R1420_VERIFICA_MATRIZ_DB_SELECT_1 */

            R1420_VERIFICA_MATRIZ_DB_SELECT_1();

            /*" -4039- IF VIND-RET-SUBSCRICAO LESS ZEROS */

            if (VIND_RET_SUBSCRICAO < 00)
            {

                /*" -4040- MOVE SPACES TO GE406-IND-RET-SUBSCRICAO */
                _.Move("", GE406.DCLGE_RETENCAO_PROPOSTA.GE406_IND_RET_SUBSCRICAO);

                /*" -4041- END-IF */
            }


            /*" -4042- IF VIND-PCT-AGRAVO LESS ZEROS */

            if (VIND_PCT_AGRAVO < 00)
            {

                /*" -4043- MOVE ZEROS TO GE406-PCT-AGRAVO */
                _.Move(0, GE406.DCLGE_RETENCAO_PROPOSTA.GE406_PCT_AGRAVO);

                /*" -4044- END-IF */
            }


            /*" -4045- IF VIND-VLR-PRM-SEM-AGR LESS ZEROS */

            if (VIND_VLR_PRM_SEM_AGR < 00)
            {

                /*" -4046- MOVE ZEROS TO GE406-VLR-PRM-SEM-AGR */
                _.Move(0, GE406.DCLGE_RETENCAO_PROPOSTA.GE406_VLR_PRM_SEM_AGR);

                /*" -4048- END-IF */
            }


            /*" -4049-  EVALUATE SQLCODE  */

            /*" -4050-  WHEN ZEROS  */

            /*" -4050- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -4051- SET WS-TEM-MATRIZ TO TRUE */
                WS_SUBSCRICAO["WS_TEM_MATRIZ"] = true;

                /*" -4052- PERFORM R1430-00-PREMIO-MATRIZ */

                R1430_00_PREMIO_MATRIZ_SECTION();

                /*" -4053-  WHEN +100  */

                /*" -4053- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -4054- SET WS-PREENCHEU-DPS TO TRUE */
                WS_SUBSCRICAO["WS_PREENCHEU_DPS"] = true;

                /*" -4055-  WHEN OTHER  */

                /*" -4055- ELSE */
            }
            else
            {


                /*" -4056- DISPLAY 'PROBLEMAS NO SELECT GE_RETENCAO_PROP' */
                _.Display($"PROBLEMAS NO SELECT GE_RETENCAO_PROP");

                /*" -4058- DISPLAY ' NUMERO PROPOSTA....... ' PROPOFID-NUM-PROPOSTA-SIVPF */
                _.Display($" NUMERO PROPOSTA....... {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -4059- DISPLAY ' SQLCODE............... ' SQLCODE */
                _.Display($" SQLCODE............... {DB.SQLCODE}");

                /*" -4060- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4062-  END-EVALUATE  */

                /*" -4062- END-IF */
            }


            /*" -4062- . */

        }

        [StopWatch]
        /*" R1420-VERIFICA-MATRIZ-DB-SELECT-1 */
        public void R1420_VERIFICA_MATRIZ_DB_SELECT_1()
        {
            /*" -4036- EXEC SQL SELECT IND_RET_SUBSCRICAO , PCT_AGRAVO , VLR_PRM_SEM_AGR INTO :GE406-IND-RET-SUBSCRICAO :VIND-RET-SUBSCRICAO , :GE406-PCT-AGRAVO :VIND-PCT-AGRAVO , :GE406-VLR-PRM-SEM-AGR :VIND-VLR-PRM-SEM-AGR FROM SEGUROS.GE_RETENCAO_PROPOSTA WHERE NUM_CERTIFICADO = :PROPOFID-NUM-PROPOSTA-SIVPF AND IND_PROCESSAMENTO = 'D' AND COD_USUARIO = 'VA0600B' END-EXEC */

            var r1420_VERIFICA_MATRIZ_DB_SELECT_1_Query1 = new R1420_VERIFICA_MATRIZ_DB_SELECT_1_Query1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R1420_VERIFICA_MATRIZ_DB_SELECT_1_Query1.Execute(r1420_VERIFICA_MATRIZ_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE406_IND_RET_SUBSCRICAO, GE406.DCLGE_RETENCAO_PROPOSTA.GE406_IND_RET_SUBSCRICAO);
                _.Move(executed_1.VIND_RET_SUBSCRICAO, VIND_RET_SUBSCRICAO);
                _.Move(executed_1.GE406_PCT_AGRAVO, GE406.DCLGE_RETENCAO_PROPOSTA.GE406_PCT_AGRAVO);
                _.Move(executed_1.VIND_PCT_AGRAVO, VIND_PCT_AGRAVO);
                _.Move(executed_1.GE406_VLR_PRM_SEM_AGR, GE406.DCLGE_RETENCAO_PROPOSTA.GE406_VLR_PRM_SEM_AGR);
                _.Move(executed_1.VIND_VLR_PRM_SEM_AGR, VIND_VLR_PRM_SEM_AGR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1420_99_SAIDA*/

        [StopWatch]
        /*" R1430-00-PREMIO-MATRIZ-SECTION */
        private void R1430_00_PREMIO_MATRIZ_SECTION()
        {
            /*" -4073- MOVE 'R1430-00-PREMIO-MATRIZ' TO PARAGRAFO */
            _.Move("R1430-00-PREMIO-MATRIZ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4075- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4077- IF GE406-VLR-PRM-SEM-AGR NOT EQUAL VLPREMIOTOT OF DCLPLANOS-VA-VGAP */

            if (GE406.DCLGE_RETENCAO_PROPOSTA.GE406_VLR_PRM_SEM_AGR != PLVAVGAP.DCLPLANOS_VA_VGAP.VLPREMIOTOT)
            {

                /*" -4078- DISPLAY 'FALHA NO CALCULO DE AGRAVAMENTO DO VA0600B, ' */
                _.Display($"FALHA NO CALCULO DE AGRAVAMENTO DO VA0600B, ");

                /*" -4079- DISPLAY 'VERIFICAR PROPOSTA.' */
                _.Display($"VERIFICAR PROPOSTA.");

                /*" -4081- DISPLAY 'NUMERO DA PROPOSTA..... ' PROPOFID-NUM-PROPOSTA-SIVPF */
                _.Display($"NUMERO DA PROPOSTA..... {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -4083- DISPLAY 'INDICADOR RETORNO...... ' GE406-IND-RET-SUBSCRICAO */
                _.Display($"INDICADOR RETORNO...... {GE406.DCLGE_RETENCAO_PROPOSTA.GE406_IND_RET_SUBSCRICAO}");

                /*" -4084- DISPLAY 'PERCENTUAL DE AGRAVO... ' GE406-PCT-AGRAVO */
                _.Display($"PERCENTUAL DE AGRAVO... {GE406.DCLGE_RETENCAO_PROPOSTA.GE406_PCT_AGRAVO}");

                /*" -4086- DISPLAY 'VALOR PREMIO SEM AGRAVO ' GE406-VLR-PRM-SEM-AGR */
                _.Display($"VALOR PREMIO SEM AGRAVO {GE406.DCLGE_RETENCAO_PROPOSTA.GE406_VLR_PRM_SEM_AGR}");

                /*" -4088- END-IF */
            }


            /*" -4090- IF VLPREMIOTOT OF DCLPLANOS-VA-VGAP EQUAL PRMVG OF DCLPLANOS-VA-VGAP */

            if (PLVAVGAP.DCLPLANOS_VA_VGAP.VLPREMIOTOT == PLVAVGAP.DCLPLANOS_VA_VGAP.PRMVG)
            {

                /*" -4091- SET WS-NAO-PREMIO-AP TO TRUE */
                WS_PREMIO_AP["WS_NAO_PREMIO_AP"] = true;

                /*" -4092- ELSE */
            }
            else
            {


                /*" -4093- SET WS-SIM-PREMIO-AP TO TRUE */
                WS_PREMIO_AP["WS_SIM_PREMIO_AP"] = true;

                /*" -4095- MOVE ZEROS TO WS-PCT-VG */
                _.Move(0, WS_PCT_VG);

                /*" -4099- COMPUTE WS-PCT-VG ROUNDED = PRMVG OF DCLPLANOS-VA-VGAP / VLPREMIOTOT OF DCLPLANOS-VA-VGAP */
                WS_PCT_VG.Value = PLVAVGAP.DCLPLANOS_VA_VGAP.PRMVG / PLVAVGAP.DCLPLANOS_VA_VGAP.VLPREMIOTOT;

                /*" -4101- END-IF */
            }


            /*" -4104- MOVE PROPOFID-VAL-PAGO TO VLPREMIOTOT OF DCLPLANOS-VA-VGAP WS-VLPREMIOTOT-CCT */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO, PLVAVGAP.DCLPLANOS_VA_VGAP.VLPREMIOTOT, WORK_AREA.WS_VLPREMIOTOT_CCT);

            /*" -4105- IF WS-SIM-PREMIO-AP */

            if (WS_PREMIO_AP["WS_SIM_PREMIO_AP"])
            {

                /*" -4108- COMPUTE PRMVG OF DCLPLANOS-VA-VGAP ROUNDED = VLPREMIOTOT OF DCLPLANOS-VA-VGAP * WS-PCT-VG */
                PLVAVGAP.DCLPLANOS_VA_VGAP.PRMVG.Value = PLVAVGAP.DCLPLANOS_VA_VGAP.VLPREMIOTOT * WS_PCT_VG;

                /*" -4111- COMPUTE PRMAP OF DCLPLANOS-VA-VGAP = VLPREMIOTOT OF DCLPLANOS-VA-VGAP - PRMVG OF DCLPLANOS-VA-VGAP */
                PLVAVGAP.DCLPLANOS_VA_VGAP.PRMAP.Value = PLVAVGAP.DCLPLANOS_VA_VGAP.VLPREMIOTOT - PLVAVGAP.DCLPLANOS_VA_VGAP.PRMVG;

                /*" -4112- ELSE */
            }
            else
            {


                /*" -4114- MOVE VLPREMIOTOT OF DCLPLANOS-VA-VGAP TO PRMVG OF DCLPLANOS-VA-VGAP */
                _.Move(PLVAVGAP.DCLPLANOS_VA_VGAP.VLPREMIOTOT, PLVAVGAP.DCLPLANOS_VA_VGAP.PRMVG);

                /*" -4116- MOVE ZEROS TO PRMAP OF DCLPLANOS-VA-VGAP */
                _.Move(0, PLVAVGAP.DCLPLANOS_VA_VGAP.PRMAP);

                /*" -4118- END-IF */
            }


            /*" -4118- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1430_99_SAIDA*/

        [StopWatch]
        /*" R1440-00-MOVE-DADO-MATRIZ-SECTION */
        private void R1440_00_MOVE_DADO_MATRIZ_SECTION()
        {
            /*" -4128- MOVE 'R1440-00-MOVE-DADO-MATRIZ ' TO PARAGRAFO */
            _.Move("R1440-00-MOVE-DADO-MATRIZ ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4130- MOVE 'MOVIMENTA DADOS DO ANDAMENTO  ' TO COMANDO */
            _.Move("MOVIMENTA DADOS DO ANDAMENTO  ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4131- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4133- MOVE PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO VG078-NUM-CERTIFICADO */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, VG078.DCLVG_ANDAMENTO_PROP.VG078_NUM_CERTIFICADO);

            /*" -4135- MOVE 72 TO VG078-DES-ANDAMENTO-LEN */
            _.Move(72, VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.VG078_DES_ANDAMENTO_LEN);

            /*" -4136- EVALUATE GE406-IND-RET-SUBSCRICAO */
            switch (GE406.DCLGE_RETENCAO_PROPOSTA.GE406_IND_RET_SUBSCRICAO.Value.Trim())
            {

                /*" -4137- WHEN '1' */
                case "1":

                    /*" -4138- MOVE GE406-PCT-AGRAVO TO WS-TXT-DESCONTO-PERC */
                    _.Move(GE406.DCLGE_RETENCAO_PROPOSTA.GE406_PCT_AGRAVO, WS_TXT_DESCONTO.WS_TXT_DESCONTO_PERC);

                    /*" -4139- MOVE WS-TXT-DESCONTO TO VG078-DES-ANDAMENTO-TEXT */
                    _.Move(WS_TXT_DESCONTO, VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.VG078_DES_ANDAMENTO_TEXT);

                    /*" -4140- WHEN '2' */
                    break;
                case "2":

                    /*" -4141- MOVE GE406-PCT-AGRAVO TO WS-TXT-AGRAVO-PERC */
                    _.Move(GE406.DCLGE_RETENCAO_PROPOSTA.GE406_PCT_AGRAVO, WS_TXT_AGRAVO.WS_TXT_AGRAVO_PERC);

                    /*" -4142- MOVE WS-TXT-AGRAVO TO VG078-DES-ANDAMENTO-TEXT */
                    _.Move(WS_TXT_AGRAVO, VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.VG078_DES_ANDAMENTO_TEXT);

                    /*" -4144- END-EVALUATE */
                    break;
            }


            /*" -4146- MOVE 'VA0601B' TO VG078-COD-USUARIO */
            _.Move("VA0601B", VG078.DCLVG_ANDAMENTO_PROP.VG078_COD_USUARIO);

            /*" -4146- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1440_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-SELECT-RCAPS-SECTION */
        private void R1500_00_SELECT_RCAPS_SECTION()
        {
            /*" -4156- MOVE '1500-00-SELECT-RCAPS         ' TO PARAGRAFO. */
            _.Move("1500-00-SELECT-RCAPS         ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4157- MOVE 'SELECT RCAPS         ' TO COMANDO. */
            _.Move("SELECT RCAPS         ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4159- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4160- MOVE 14 TO SII. */
            _.Move(14, WS_HORAS.SII);

            /*" -4161- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -4172- PERFORM R1500_00_SELECT_RCAPS_DB_SELECT_1 */

            R1500_00_SELECT_RCAPS_DB_SELECT_1();

            /*" -4175- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -4176- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4177- PERFORM R1505-00-SELECT-RCAPS */

                R1505_00_SELECT_RCAPS_SECTION();

                /*" -4178- ELSE */
            }
            else
            {


                /*" -4179- MOVE 1 TO W-RCAPS */
                _.Move(1, WORK_AREA.W_RCAPS);

                /*" -4181- END-IF */
            }


            /*" -4181- . */

        }

        [StopWatch]
        /*" R1500-00-SELECT-RCAPS-DB-SELECT-1 */
        public void R1500_00_SELECT_RCAPS_DB_SELECT_1()
        {
            /*" -4172- EXEC SQL SELECT COD_FONTE, NUM_RCAP, VAL_RCAP INTO :DCLRCAPS.RCAPS-COD-FONTE, :DCLRCAPS.RCAPS-NUM-RCAP, :DCLRCAPS.RCAPS-VAL-RCAP FROM SEGUROS.RCAPS WHERE (NUM_TITULO =:DCLRCAPS.RCAPS-NUM-TITULO OR NUM_CERTIFICADO =:DCLRCAPS.RCAPS-NUM-CERTIFICADO) AND COD_FONTE =:DCLRCAPS.RCAPS-COD-FONTE END-EXEC */

            var r1500_00_SELECT_RCAPS_DB_SELECT_1_Query1 = new R1500_00_SELECT_RCAPS_DB_SELECT_1_Query1()
            {
                RCAPS_NUM_CERTIFICADO = RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO.ToString(),
                RCAPS_NUM_TITULO = RCAPS.DCLRCAPS.RCAPS_NUM_TITULO.ToString(),
                RCAPS_COD_FONTE = RCAPS.DCLRCAPS.RCAPS_COD_FONTE.ToString(),
            };

            var executed_1 = R1500_00_SELECT_RCAPS_DB_SELECT_1_Query1.Execute(r1500_00_SELECT_RCAPS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_COD_FONTE, RCAPS.DCLRCAPS.RCAPS_COD_FONTE);
                _.Move(executed_1.RCAPS_NUM_RCAP, RCAPS.DCLRCAPS.RCAPS_NUM_RCAP);
                _.Move(executed_1.RCAPS_VAL_RCAP, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1505-00-SELECT-RCAPS-SECTION */
        private void R1505_00_SELECT_RCAPS_SECTION()
        {
            /*" -4191- MOVE '1505-00-SELECT-RCAPS         ' TO PARAGRAFO */
            _.Move("1505-00-SELECT-RCAPS         ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4193- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4194- MOVE 15 TO SII */
            _.Move(15, WS_HORAS.SII);

            /*" -4195- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -4205- PERFORM R1505_00_SELECT_RCAPS_DB_SELECT_1 */

            R1505_00_SELECT_RCAPS_DB_SELECT_1();

            /*" -4208- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -4209- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4210- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -4211- DISPLAY 'VA0601B - PROBLEMAS NO ACESSO A RCAP' */
                    _.Display($"VA0601B - PROBLEMAS NO ACESSO A RCAP");

                    /*" -4213- DISPLAY '          NUMERO DO TITULO......... ' RCAPS-NUM-TITULO OF DCLRCAPS */
                    _.Display($"          NUMERO DO TITULO......... {RCAPS.DCLRCAPS.RCAPS_NUM_TITULO}");

                    /*" -4215- DISPLAY '          SQLCODE.................. ' SQLCODE */
                    _.Display($"          SQLCODE.................. {DB.SQLCODE}");

                    /*" -4216- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4217- ELSE */
                }
                else
                {


                    /*" -4218- CONTINUE */

                    /*" -4219- END-IF */
                }


                /*" -4220- ELSE */
            }
            else
            {


                /*" -4221- MOVE 1 TO W-RCAPS */
                _.Move(1, WORK_AREA.W_RCAPS);

                /*" -4223- END-IF */
            }


            /*" -4223- . */

        }

        [StopWatch]
        /*" R1505-00-SELECT-RCAPS-DB-SELECT-1 */
        public void R1505_00_SELECT_RCAPS_DB_SELECT_1()
        {
            /*" -4205- EXEC SQL SELECT COD_FONTE, NUM_RCAP, VAL_RCAP INTO :DCLRCAPS.RCAPS-COD-FONTE, :DCLRCAPS.RCAPS-NUM-RCAP, :DCLRCAPS.RCAPS-VAL-RCAP FROM SEGUROS.RCAPS WHERE (NUM_TITULO =:DCLRCAPS.RCAPS-NUM-TITULO OR NUM_CERTIFICADO =:DCLRCAPS.RCAPS-NUM-CERTIFICADO) END-EXEC */

            var r1505_00_SELECT_RCAPS_DB_SELECT_1_Query1 = new R1505_00_SELECT_RCAPS_DB_SELECT_1_Query1()
            {
                RCAPS_NUM_CERTIFICADO = RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO.ToString(),
                RCAPS_NUM_TITULO = RCAPS.DCLRCAPS.RCAPS_NUM_TITULO.ToString(),
            };

            var executed_1 = R1505_00_SELECT_RCAPS_DB_SELECT_1_Query1.Execute(r1505_00_SELECT_RCAPS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_COD_FONTE, RCAPS.DCLRCAPS.RCAPS_COD_FONTE);
                _.Move(executed_1.RCAPS_NUM_RCAP, RCAPS.DCLRCAPS.RCAPS_NUM_RCAP);
                _.Move(executed_1.RCAPS_VAL_RCAP, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1505_99_SAIDA*/

        [StopWatch]
        /*" R1510-00-SELECT-RCAPCOMP-SECTION */
        private void R1510_00_SELECT_RCAPCOMP_SECTION()
        {
            /*" -4233- MOVE '1510-00-SELECT-RCAP COMP     ' TO PARAGRAFO. */
            _.Move("1510-00-SELECT-RCAP COMP     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4234- MOVE 'SELECT RCAP-COMP     ' TO COMANDO. */
            _.Move("SELECT RCAP-COMP     ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4236- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4237- MOVE 16 TO SII. */
            _.Move(16, WS_HORAS.SII);

            /*" -4238- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -4254- PERFORM R1510_00_SELECT_RCAPCOMP_DB_SELECT_1 */

            R1510_00_SELECT_RCAPCOMP_DB_SELECT_1();

            /*" -4257- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -4258- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -4259- CONTINUE */

                /*" -4260- ELSE */
            }
            else
            {


                /*" -4262- IF SQLCODE NOT EQUAL 100 AND SQLCODE NOT EQUAL -811 */

                if (DB.SQLCODE != 100 && DB.SQLCODE != -811)
                {

                    /*" -4263- DISPLAY 'VA0601B - PROBLEMAS NO ACESSO A RCAPCOMP' */
                    _.Display($"VA0601B - PROBLEMAS NO ACESSO A RCAPCOMP");

                    /*" -4265- DISPLAY '          CODIGO DA FONTE.............. ' RCAPS-COD-FONTE OF DCLRCAPS */
                    _.Display($"          CODIGO DA FONTE.............. {RCAPS.DCLRCAPS.RCAPS_COD_FONTE}");

                    /*" -4267- DISPLAY '          NUMERO DO RCAP............... ' RCAPS-NUM-RCAP OF DCLRCAPS */
                    _.Display($"          NUMERO DO RCAP............... {RCAPS.DCLRCAPS.RCAPS_NUM_RCAP}");

                    /*" -4269- DISPLAY '          SQLCODE...................... ' SQLCODE */
                    _.Display($"          SQLCODE...................... {DB.SQLCODE}");

                    /*" -4270- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4271- ELSE */
                }
                else
                {


                    /*" -4286- PERFORM R1510_00_SELECT_RCAPCOMP_DB_DECLARE_1 */

                    R1510_00_SELECT_RCAPCOMP_DB_DECLARE_1();

                    /*" -4289- MOVE 17 TO SII */
                    _.Move(17, WS_HORAS.SII);

                    /*" -4290- PERFORM R9000-00-INICIO */

                    R9000_00_INICIO_SECTION();

                    /*" -4290- PERFORM R1510_00_SELECT_RCAPCOMP_DB_OPEN_1 */

                    R1510_00_SELECT_RCAPCOMP_DB_OPEN_1();

                    /*" -4293- PERFORM R9100-00-TERMINO */

                    R9100_00_TERMINO_SECTION();

                    /*" -4294- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -4295- DISPLAY 'VA0601B - PROBLEMAS NO OPEN DA RCAPCOMP' */
                        _.Display($"VA0601B - PROBLEMAS NO OPEN DA RCAPCOMP");

                        /*" -4297- DISPLAY '          CODIGO DA FONTE.............. ' RCAPS-COD-FONTE OF DCLRCAPS */
                        _.Display($"          CODIGO DA FONTE.............. {RCAPS.DCLRCAPS.RCAPS_COD_FONTE}");

                        /*" -4299- DISPLAY '          NUMERO DO RCAP............... ' RCAPS-NUM-RCAP OF DCLRCAPS */
                        _.Display($"          NUMERO DO RCAP............... {RCAPS.DCLRCAPS.RCAPS_NUM_RCAP}");

                        /*" -4301- DISPLAY '          SQLCODE...................... ' SQLCODE */
                        _.Display($"          SQLCODE...................... {DB.SQLCODE}");

                        /*" -4302- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -4304- END-IF */
                    }


                    /*" -4305- MOVE 18 TO SII */
                    _.Move(18, WS_HORAS.SII);

                    /*" -4306- PERFORM R9000-00-INICIO */

                    R9000_00_INICIO_SECTION();

                    /*" -4317- PERFORM R1510_00_SELECT_RCAPCOMP_DB_FETCH_1 */

                    R1510_00_SELECT_RCAPCOMP_DB_FETCH_1();

                    /*" -4320- PERFORM R9100-00-TERMINO */

                    R9100_00_TERMINO_SECTION();

                    /*" -4321- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -4322- DISPLAY 'VA0601B - ERRO, RCAPCOMP NAO CADASTRADO' */
                        _.Display($"VA0601B - ERRO, RCAPCOMP NAO CADASTRADO");

                        /*" -4324- DISPLAY '          CODIGO DA FONTE.............. ' RCAPS-COD-FONTE OF DCLRCAPS */
                        _.Display($"          CODIGO DA FONTE.............. {RCAPS.DCLRCAPS.RCAPS_COD_FONTE}");

                        /*" -4326- DISPLAY '          NUMERO DO RCAP............... ' RCAPS-NUM-RCAP OF DCLRCAPS */
                        _.Display($"          NUMERO DO RCAP............... {RCAPS.DCLRCAPS.RCAPS_NUM_RCAP}");

                        /*" -4328- DISPLAY '          SQLCODE...................... ' SQLCODE */
                        _.Display($"          SQLCODE...................... {DB.SQLCODE}");

                        /*" -4329- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -4331- END-IF */
                    }


                    /*" -4331- PERFORM R1510_00_SELECT_RCAPCOMP_DB_CLOSE_1 */

                    R1510_00_SELECT_RCAPCOMP_DB_CLOSE_1();

                    /*" -4334- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -4335- DISPLAY 'VA0601B - PROBLEMAS NO CLOSE DA RCAPCOMP' */
                        _.Display($"VA0601B - PROBLEMAS NO CLOSE DA RCAPCOMP");

                        /*" -4337- DISPLAY '          CODIGO DA FONTE.............. ' RCAPS-COD-FONTE OF DCLRCAPS */
                        _.Display($"          CODIGO DA FONTE.............. {RCAPS.DCLRCAPS.RCAPS_COD_FONTE}");

                        /*" -4339- DISPLAY '          NUMERO DO RCAP............... ' RCAPS-NUM-RCAP OF DCLRCAPS */
                        _.Display($"          NUMERO DO RCAP............... {RCAPS.DCLRCAPS.RCAPS_NUM_RCAP}");

                        /*" -4341- DISPLAY '          SQLCODE...................... ' SQLCODE */
                        _.Display($"          SQLCODE...................... {DB.SQLCODE}");

                        /*" -4341- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


        }

        [StopWatch]
        /*" R1510-00-SELECT-RCAPCOMP-DB-SELECT-1 */
        public void R1510_00_SELECT_RCAPCOMP_DB_SELECT_1()
        {
            /*" -4254- EXEC SQL SELECT BCO_AVISO, AGE_AVISO, NUM_AVISO_CREDITO, DATA_MOVIMENTO, DATA_RCAP INTO :DCLRCAP-COMPLEMENTAR.RCAPCOMP-BCO-AVISO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-AGE-AVISO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-NUM-AVISO-CREDITO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-DATA-MOVIMENTO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-DATA-RCAP FROM SEGUROS.RCAP_COMPLEMENTAR WHERE COD_FONTE = :DCLRCAPS.RCAPS-COD-FONTE AND NUM_RCAP = :DCLRCAPS.RCAPS-NUM-RCAP AND NUM_RCAP_COMPLEMEN = 0 AND COD_OPERACAO BETWEEN 100 AND 199 END-EXEC. */

            var r1510_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1 = new R1510_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1()
            {
                RCAPS_COD_FONTE = RCAPS.DCLRCAPS.RCAPS_COD_FONTE.ToString(),
                RCAPS_NUM_RCAP = RCAPS.DCLRCAPS.RCAPS_NUM_RCAP.ToString(),
            };

            var executed_1 = R1510_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1.Execute(r1510_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPCOMP_BCO_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO);
                _.Move(executed_1.RCAPCOMP_AGE_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO);
                _.Move(executed_1.RCAPCOMP_NUM_AVISO_CREDITO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO);
                _.Move(executed_1.RCAPCOMP_DATA_MOVIMENTO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_MOVIMENTO);
                _.Move(executed_1.RCAPCOMP_DATA_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP);
            }


        }

        [StopWatch]
        /*" R1510-00-SELECT-RCAPCOMP-DB-OPEN-1 */
        public void R1510_00_SELECT_RCAPCOMP_DB_OPEN_1()
        {
            /*" -4290- EXEC SQL OPEN C01_RCAPCOMP END-EXEC */

            C01_RCAPCOMP.Open();

        }

        [StopWatch]
        /*" R2222-00-OBTER-ENDERECO-CORRES-DB-DECLARE-1 */
        public void R2222_00_OBTER_ENDERECO_CORRES_DB_DECLARE_1()
        {
            /*" -4838- EXEC SQL DECLARE CPESENDER CURSOR FOR SELECT OCORR_ENDERECO, ENDERECO, BAIRRO, CIDADE, CEP, SIGLA_UF FROM SEGUROS.PESSOA_ENDERECO WHERE COD_PESSOA = :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA AND TIPO_ENDER = 2 AND OCORR_ENDERECO = :DCLPESSOA-ENDERECO.OCORR-ENDERECO ORDER BY OCORR_ENDERECO DESC END-EXEC. */
            CPESENDER = new VA0601B_CPESENDER(true);
            string GetQuery_CPESENDER()
            {
                var query = @$"SELECT OCORR_ENDERECO
							, 
							ENDERECO
							, 
							BAIRRO
							, 
							CIDADE
							, 
							CEP
							, 
							SIGLA_UF 
							FROM SEGUROS.PESSOA_ENDERECO 
							WHERE COD_PESSOA = 
							'{PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA}' 
							AND TIPO_ENDER = 2 
							AND OCORR_ENDERECO = 
							'{PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO}' 
							ORDER BY OCORR_ENDERECO DESC";

                return query;
            }
            CPESENDER.GetQueryEvent += GetQuery_CPESENDER;

        }

        [StopWatch]
        /*" R1510-00-SELECT-RCAPCOMP-DB-FETCH-1 */
        public void R1510_00_SELECT_RCAPCOMP_DB_FETCH_1()
        {
            /*" -4317- EXEC SQL FETCH C01_RCAPCOMP INTO :DCLRCAP-COMPLEMENTAR.RCAPCOMP-BCO-AVISO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-AGE-AVISO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-NUM-AVISO-CREDITO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-DATA-MOVIMENTO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-DATA-RCAP, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-COD-OPERACAO END-EXEC */

            if (C01_RCAPCOMP.Fetch())
            {
                _.Move(C01_RCAPCOMP.DCLRCAP_COMPLEMENTAR_RCAPCOMP_BCO_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO);
                _.Move(C01_RCAPCOMP.DCLRCAP_COMPLEMENTAR_RCAPCOMP_AGE_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO);
                _.Move(C01_RCAPCOMP.DCLRCAP_COMPLEMENTAR_RCAPCOMP_NUM_AVISO_CREDITO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO);
                _.Move(C01_RCAPCOMP.DCLRCAP_COMPLEMENTAR_RCAPCOMP_DATA_MOVIMENTO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_MOVIMENTO);
                _.Move(C01_RCAPCOMP.DCLRCAP_COMPLEMENTAR_RCAPCOMP_DATA_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP);
                _.Move(C01_RCAPCOMP.DCLRCAP_COMPLEMENTAR_RCAPCOMP_COD_OPERACAO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_OPERACAO);
            }

        }

        [StopWatch]
        /*" R1510-00-SELECT-RCAPCOMP-DB-CLOSE-1 */
        public void R1510_00_SELECT_RCAPCOMP_DB_CLOSE_1()
        {
            /*" -4331- EXEC SQL CLOSE C01_RCAPCOMP END-EXEC */

            C01_RCAPCOMP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1510_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-UPDATE-PROPFID-SECTION */
        private void R1600_00_UPDATE_PROPFID_SECTION()
        {
            /*" -4351- MOVE '1600-00-UPDATE-PROPFID       ' TO PARAGRAFO. */
            _.Move("1600-00-UPDATE-PROPFID       ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4353- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4364- IF WS-TEM-ERRO-1855 EQUAL 'SIM' OR WS-TEM-ERRO-1807 EQUAL 'SIM' OR WS-TEM-ERRO-1852 EQUAL 'SIM' OR WS-TEM-ERRO-1877 EQUAL 'SIM' OR WS-TEM-ERRO-1878 EQUAL 'SIM' OR PROPOFID-NSAS-SIVPF OF DCLPROPOSTA-FIDELIZ EQUAL 01 OR PROPOFID-SIT-PROPOSTA OF DCLPROPOSTA-FIDELIZ EQUAL 'DEC' */

            if (WORK_AREA.WS_TEM_ERRO_1855 == "SIM" || WORK_AREA.WS_TEM_ERRO_1807 == "SIM" || WORK_AREA.WS_TEM_ERRO_1852 == "SIM" || WORK_AREA.WS_TEM_ERRO_1877 == "SIM" || WORK_AREA.WS_TEM_ERRO_1878 == "SIM" || PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAS_SIVPF == 01 || PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA == "DEC")
            {

                /*" -4365- MOVE 'REJ' TO WHOST-SIT-PROPOSTA */
                _.Move("REJ", WHOST_SIT_PROPOSTA);

                /*" -4366- MOVE 'S' TO WHOST-SIT-ENVIO */
                _.Move("S", WHOST_SIT_ENVIO);

                /*" -4367- ELSE */
            }
            else
            {


                /*" -4368- IF WS-TEM-ERRO EQUAL ZEROS */

                if (WORK_AREA.WS_TEM_ERRO == 00)
                {

                    /*" -4369- MOVE 'PAI' TO WHOST-SIT-PROPOSTA */
                    _.Move("PAI", WHOST_SIT_PROPOSTA);

                    /*" -4370- MOVE ' ' TO WHOST-SIT-ENVIO */
                    _.Move(" ", WHOST_SIT_ENVIO);

                    /*" -4371- ELSE */
                }
                else
                {


                    /*" -4372- MOVE 'S' TO WHOST-SIT-ENVIO */
                    _.Move("S", WHOST_SIT_ENVIO);

                    /*" -4373- IF RCAP-CADASTRADO */

                    if (WORK_AREA.W_RCAPS["RCAP_CADASTRADO"])
                    {

                        /*" -4374- MOVE 'PEN' TO WHOST-SIT-PROPOSTA */
                        _.Move("PEN", WHOST_SIT_PROPOSTA);

                        /*" -4375- ELSE */
                    }
                    else
                    {


                        /*" -4383- MOVE 'POB' TO WHOST-SIT-PROPOSTA. */
                        _.Move("POB", WHOST_SIT_PROPOSTA);
                    }

                }

            }


            /*" -4386- MOVE PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO W-NUM-PROPOSTA. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, WORK_AREA.W_NUM_PROPOSTA);

            /*" -4389- MOVE PROPOFID-ORIGEM-PROPOSTA OF DCLPROPOSTA-FIDELIZ TO W-ORIGEM-PROPOSTA. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA, WORK_AREA.W_ORIGEM_PROPOSTA);

            /*" -4390- MOVE 19 TO SII */
            _.Move(19, WS_HORAS.SII);

            /*" -4391- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -4399- PERFORM R1600_00_UPDATE_PROPFID_DB_UPDATE_1 */

            R1600_00_UPDATE_PROPFID_DB_UPDATE_1();

            /*" -4402- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -4403- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4404- DISPLAY 'PROBLEMAS NO UPDATE DA PROPFID      ' */
                _.Display($"PROBLEMAS NO UPDATE DA PROPFID      ");

                /*" -4404- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1600-00-UPDATE-PROPFID-DB-UPDATE-1 */
        public void R1600_00_UPDATE_PROPFID_DB_UPDATE_1()
        {
            /*" -4399- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET SIT_PROPOSTA = :WHOST-SIT-PROPOSTA, SITUACAO_ENVIO = :WHOST-SIT-ENVIO, NRMATRVEN = :DCLPROPOSTA-FIDELIZ.PROPOFID-NRMATRVEN, COD_USUARIO = 'VA0601B' WHERE NUM_PROPOSTA_SIVPF = :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF END-EXEC. */

            var r1600_00_UPDATE_PROPFID_DB_UPDATE_1_Update1 = new R1600_00_UPDATE_PROPFID_DB_UPDATE_1_Update1()
            {
                PROPOFID_NRMATRVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN.ToString(),
                WHOST_SIT_PROPOSTA = WHOST_SIT_PROPOSTA.ToString(),
                WHOST_SIT_ENVIO = WHOST_SIT_ENVIO.ToString(),
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            R1600_00_UPDATE_PROPFID_DB_UPDATE_1_Update1.Execute(r1600_00_UPDATE_PROPFID_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1650-00-EXECUTA-COMMIT-SECTION */
        private void R1650_00_EXECUTA_COMMIT_SECTION()
        {
            /*" -4414- MOVE 'R1650-00-EXECUTA-COMMIT      ' TO PARAGRAFO */
            _.Move("R1650-00-EXECUTA-COMMIT      ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4416- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4416- EXEC SQL COMMIT WORK END-EXEC */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -4419- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4420- DISPLAY 'PROBLEMAS NO COMMIT DO PROCESSO     ' */
                _.Display($"PROBLEMAS NO COMMIT DO PROCESSO     ");

                /*" -4421- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4423- END-IF */
            }


            /*" -4423- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1650_99_SAIDA*/

        [StopWatch]
        /*" R1700-00-UPDATE-PRP-FIDELIZ-SECTION */
        private void R1700_00_UPDATE_PRP_FIDELIZ_SECTION()
        {
            /*" -4433- MOVE '1700-00-UPDATE-PRP-FIDELIZ   ' TO PARAGRAFO. */
            _.Move("1700-00-UPDATE-PRP-FIDELIZ   ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4434- MOVE 'UPDATE PRP-FIDELIZ   ' TO COMANDO. */
            _.Move("UPDATE PRP-FIDELIZ   ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4436- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4437- MOVE 20 TO SII */
            _.Move(20, WS_HORAS.SII);

            /*" -4438- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -4449- PERFORM R1700_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1 */

            R1700_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1();

            /*" -4452- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -4453- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4454- DISPLAY 'VA0601B - PROPOSTA-FIDELIZ NAO FOI ATUALIZADA   ' */
                _.Display($"VA0601B - PROPOSTA-FIDELIZ NAO FOI ATUALIZADA   ");

                /*" -4455- DISPLAY '          SERA ATUALIZADA NO PF0002B.           ' */
                _.Display($"          SERA ATUALIZADA NO PF0002B.           ");

                /*" -4464- DISPLAY '          NUM PROPOSTA........................  ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ '          DTQITBCO / DATA-RCAP................  ' RCAPCOMP-DATA-RCAP '          DATA CREDITO / DATA MOVIMENTO RCAP..  ' RCAPCOMP-DATA-MOVIMENTO '          VALOR PAGO..........................  ' PROPOFID-VAL-PAGO '          SQLCODE.............................  ' SQLCODE. */

                $"          NUM PROPOSTA........................  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}          DTQITBCO / DATA-RCAP................  {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP}          DATA CREDITO / DATA MOVIMENTO RCAP..  {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_MOVIMENTO}          VALOR PAGO..........................  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO}          SQLCODE.............................  {DB.SQLCODE}"
                .Display();
            }


        }

        [StopWatch]
        /*" R1700-00-UPDATE-PRP-FIDELIZ-DB-UPDATE-1 */
        public void R1700_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1()
        {
            /*" -4449- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET DTQITBCO = :DCLRCAP-COMPLEMENTAR.RCAPCOMP-DATA-RCAP, DATA_CREDITO = :DCLRCAP-COMPLEMENTAR.RCAPCOMP-DATA-MOVIMENTO, VAL_PAGO = :DCLPROPOSTA-FIDELIZ.PROPOFID-VAL-PAGO WHERE NUM_PROPOSTA_SIVPF = :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF AND SIT_PROPOSTA IN ( 'ENV' , 'POV' , 'DEC' ) END-EXEC. */

            var r1700_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1 = new R1700_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1()
            {
                RCAPCOMP_DATA_MOVIMENTO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_MOVIMENTO.ToString(),
                RCAPCOMP_DATA_RCAP = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP.ToString(),
                PROPOFID_VAL_PAGO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO.ToString(),
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            R1700_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1.Execute(r1700_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/

        [StopWatch]
        /*" R1900-CONSULTA-CARENCIA-SECTION */
        private void R1900_CONSULTA_CARENCIA_SECTION()
        {
            /*" -4473- MOVE 'R1900-CONSULTA-CARENCIA' TO PARAGRAFO */
            _.Move("R1900-CONSULTA-CARENCIA", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4474- MOVE 'SELECT CARENCIA      ' TO COMANDO */
            _.Move("SELECT CARENCIA      ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4476- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4478- INITIALIZE WS-TEM-CARENCIA */
            _.Initialize(
                WS_TEM_CARENCIA
            );

            /*" -4484- PERFORM R1900_CONSULTA_CARENCIA_DB_SELECT_1 */

            R1900_CONSULTA_CARENCIA_DB_SELECT_1();

            /*" -4487- IF SQLCODE NOT = 0 AND 100 */

            if (!DB.SQLCODE.In("0", "100"))
            {

                /*" -4488- DISPLAY 'PROBLEMAS NO SELECT CARENCIA ' */
                _.Display($"PROBLEMAS NO SELECT CARENCIA ");

                /*" -4489- DISPLAY 'DCLPESSOA-FISICA.CPF ' DCLPESSOA-FISICA */
                _.Display($"DCLPESSOA-FISICA.CPF {PESFIS.DCLPESSOA_FISICA}");

                /*" -4490- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4491- END-IF */
            }


            /*" -4491- . */

        }

        [StopWatch]
        /*" R1900-CONSULTA-CARENCIA-DB-SELECT-1 */
        public void R1900_CONSULTA_CARENCIA_DB_SELECT_1()
        {
            /*" -4484- EXEC SQL SELECT DISTINCT STA_CARENCIA INTO :WS-TEM-CARENCIA FROM SEGUROS.VA_CAMPANHA_CARENCIA WHERE NUM_CPF_CNPJ = :DCLPESSOA-FISICA.CPF END-EXEC */

            var r1900_CONSULTA_CARENCIA_DB_SELECT_1_Query1 = new R1900_CONSULTA_CARENCIA_DB_SELECT_1_Query1()
            {
                CPF = PESFIS.DCLPESSOA_FISICA.CPF.ToString(),
            };

            var executed_1 = R1900_CONSULTA_CARENCIA_DB_SELECT_1_Query1.Execute(r1900_CONSULTA_CARENCIA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_TEM_CARENCIA, WS_TEM_CARENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-MATRICULA-FUNC-SECTION */
        private void R2100_00_MATRICULA_FUNC_SECTION()
        {
            /*" -4500- MOVE 'R2100-00-MATRICULA-FUNC      ' TO PARAGRAFO. */
            _.Move("R2100-00-MATRICULA-FUNC      ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4502- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4504- IF PROPOFID-NRMATRVEN OF DCLPROPOSTA-FIDELIZ = 99999999 OR ZEROS */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN.In("99999999", "00"))
            {

                /*" -4505- MOVE 1302 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1302, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -4506- PERFORM R1100-00-GRAVA-TAB-ERRO */

                R1100_00_GRAVA_TAB_ERRO_SECTION();

                /*" -4507- GO TO R2100-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/ //GOTO
                return;

                /*" -4509- END-IF */
            }


            /*" -4512- MOVE PROPOFID-NRMATRVEN OF DCLPROPOSTA-FIDELIZ TO LPARM01, W-NRMATRICULA. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN, LPARM01, W_NRMATRICULA);

            /*" -4513- IF W-NRMATRICULA1 EQUAL 0777777 OR 777777 */

            if (FILLER_5.W_NRMATRICULA1.In("0777777", "777777"))
            {

                /*" -4514- GO TO R2100-01-ACESSA-FUNC */

                R2100_01_ACESSA_FUNC(); //GOTO
                return;

                /*" -4516- END-IF */
            }


            /*" -4518- MOVE 'CALL PRODIGCX' TO COMANDO. */
            _.Move("CALL PRODIGCX", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4520- CALL 'PRODIGCX' USING LPARM01, LPARM03. */
            _.Call("PRODIGCX", LPARM01, LPARM03);

            /*" -4521- IF LPARM01 EQUAL ALL '9' */

            if (LPARM01.All("9"))
            {

                /*" -4522- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -4523- DISPLAY '* VA0601B - PROBLEMAS CALL SUBROTINA PRODIGCX *' */
                _.Display($"* VA0601B - PROBLEMAS CALL SUBROTINA PRODIGCX *");

                /*" -4524- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -4525- MOVE 999 TO SQLCODE */
                _.Move(999, DB.SQLCODE);

                /*" -4526- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4528- END-IF */
            }


            /*" -4529- IF LPARM03 NOT EQUAL W-DV-MATRICULA */

            if (LPARM03 != FILLER_5.W_DV_MATRICULA)
            {

                /*" -4531- MOVE PROPOFID-NRMATRVEN OF DCLPROPOSTA-FIDELIZ TO W-NRMATRICULA1 */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN, FILLER_5.W_NRMATRICULA1);

                /*" -4532- MOVE LPARM03 TO W-DV-MATRICULA */
                _.Move(LPARM03, FILLER_5.W_DV_MATRICULA);

                /*" -4535- MOVE W-NRMATRICULA TO PROPOFID-NRMATRVEN OF DCLPROPOSTA-FIDELIZ */
                _.Move(W_NRMATRICULA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN);

                /*" -4537- MOVE PROPOFID-NRMATRVEN OF DCLPROPOSTA-FIDELIZ TO LPARM01 */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN, LPARM01);

                /*" -4539- CALL 'PRODIGCX' USING LPARM01, LPARM03 */
                _.Call("PRODIGCX", LPARM01, LPARM03);

                /*" -4540- IF LPARM01 EQUAL ALL '9' */

                if (LPARM01.All("9"))
                {

                    /*" -4542- DISPLAY '*---------------------------------------------*' */
                    _.Display($"*---------------------------------------------*");

                    /*" -4544- DISPLAY '* VA0601B - PROBLEMAS CALL SUBROTINA PRODIGCX *' */
                    _.Display($"* VA0601B - PROBLEMAS CALL SUBROTINA PRODIGCX *");

                    /*" -4546- DISPLAY '*---------------------------------------------*' */
                    _.Display($"*---------------------------------------------*");

                    /*" -4547- MOVE 999 TO SQLCODE */
                    _.Move(999, DB.SQLCODE);

                    /*" -4548- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4550- END-IF */
                }


                /*" -4551- MOVE LPARM03 TO W-DV-MATRICULA */
                _.Move(LPARM03, FILLER_5.W_DV_MATRICULA);

                /*" -4553- MOVE W-NRMATRICULA TO PROPOFID-NRMATRVEN OF DCLPROPOSTA-FIDELIZ */
                _.Move(W_NRMATRICULA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN);

                /*" -4553- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R2100_01_ACESSA_FUNC */

            R2100_01_ACESSA_FUNC();

        }

        [StopWatch]
        /*" R2100-01-ACESSA-FUNC */
        private void R2100_01_ACESSA_FUNC(bool isPerform = false)
        {
            /*" -4558- PERFORM R2110-00-SELECT-FUNCIOCEF. */

            R2110_00_SELECT_FUNCIOCEF_SECTION();

            /*" -4559- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -4560- IF PROPOFID-ORIGEM-PROPOSTA NOT = 1000 */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA != 1000)
                {

                    /*" -4561- MOVE 1302 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(1302, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -4562- PERFORM R1100-00-GRAVA-TAB-ERRO */

                    R1100_00_GRAVA_TAB_ERRO_SECTION();

                    /*" -4563- END-IF */
                }


                /*" -4564- ELSE */
            }
            else
            {


                /*" -4568- IF FUNCICEF-TIPO-VINCULO OF DCLFUNCIONARIOS-CEF EQUAL 'EMPREGADO CEF' AND FUNCICEF-SITUACAO OF DCLFUNCIONARIOS-CEF NOT EQUAL '0' */

                if (FUNCICEF.DCLFUNCIONARIOS_CEF.FUNCICEF_TIPO_VINCULO == "EMPREGADO CEF" && FUNCICEF.DCLFUNCIONARIOS_CEF.FUNCICEF_SITUACAO != "0")
                {

                    /*" -4569- MOVE 1303 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(1303, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -4570- PERFORM R1100-00-GRAVA-TAB-ERRO */

                    R1100_00_GRAVA_TAB_ERRO_SECTION();

                    /*" -4571- END-IF */
                }


                /*" -4571- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2110-00-SELECT-FUNCIOCEF-SECTION */
        private void R2110_00_SELECT_FUNCIOCEF_SECTION()
        {
            /*" -4581- MOVE '1810-00-SELECT-FUNCIOCEF     ' TO PARAGRAFO. */
            _.Move("1810-00-SELECT-FUNCIOCEF     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4582- MOVE 'SELECT FUNCIOCEF     ' TO COMANDO. */
            _.Move("SELECT FUNCIOCEF     ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4584- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4585- MOVE 102 TO SII. */
            _.Move(102, WS_HORAS.SII);

            /*" -4586- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -4592- PERFORM R2110_00_SELECT_FUNCIOCEF_DB_SELECT_1 */

            R2110_00_SELECT_FUNCIOCEF_DB_SELECT_1();

            /*" -4595- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -4596- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -4597- DISPLAY 'PROBLEMAS NO SELECT A FUNCIOCEF         ' */
                _.Display($"PROBLEMAS NO SELECT A FUNCIOCEF         ");

                /*" -4597- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2110-00-SELECT-FUNCIOCEF-DB-SELECT-1 */
        public void R2110_00_SELECT_FUNCIOCEF_DB_SELECT_1()
        {
            /*" -4592- EXEC SQL SELECT NOME_FUNCIONARIO INTO :DCLFUNCIONARIOS-CEF.FUNCICEF-NOME-FUNCIONARIO FROM SEGUROS.FUNCIONARIOS_CEF WHERE NUM_MATRICULA = :DCLPROPOSTA-FIDELIZ.PROPOFID-NRMATRVEN END-EXEC. */

            var r2110_00_SELECT_FUNCIOCEF_DB_SELECT_1_Query1 = new R2110_00_SELECT_FUNCIOCEF_DB_SELECT_1_Query1()
            {
                PROPOFID_NRMATRVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN.ToString(),
            };

            var executed_1 = R2110_00_SELECT_FUNCIOCEF_DB_SELECT_1_Query1.Execute(r2110_00_SELECT_FUNCIOCEF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FUNCICEF_NOME_FUNCIONARIO, FUNCICEF.DCLFUNCIONARIOS_CEF.FUNCICEF_NOME_FUNCIONARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2110_99_SAIDA*/

        [StopWatch]
        /*" R2203-00-SELECT-CONDITEC-SECTION */
        private void R2203_00_SELECT_CONDITEC_SECTION()
        {
            /*" -4607- MOVE '2203-00-SELECT-CONDITEC      ' TO PARAGRAFO. */
            _.Move("2203-00-SELECT-CONDITEC      ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4608- MOVE 'SELECT CONDICOES_TECNICAS' TO COMANDO. */
            _.Move("SELECT CONDICOES_TECNICAS", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4611- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4612- MOVE 21 TO SII */
            _.Move(21, WS_HORAS.SII);

            /*" -4613- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -4621- PERFORM R2203_00_SELECT_CONDITEC_DB_SELECT_1 */

            R2203_00_SELECT_CONDITEC_DB_SELECT_1();

            /*" -4624- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -4625- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4626- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4627- MOVE ZEROS TO CONDITEC-CARREGA-CONJUGE */
                    _.Move(0, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE);

                    /*" -4628- ELSE */
                }
                else
                {


                    /*" -4629- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4630- END-IF */
                }


                /*" -4630- END-IF. */
            }


        }

        [StopWatch]
        /*" R2203-00-SELECT-CONDITEC-DB-SELECT-1 */
        public void R2203_00_SELECT_CONDITEC_DB_SELECT_1()
        {
            /*" -4621- EXEC SQL SELECT CARREGA_CONJUGE INTO :CONDITEC-CARREGA-CONJUGE FROM SEGUROS.CONDICOES_TECNICAS WHERE NUM_APOLICE = :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE AND COD_SUBGRUPO = :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO END-EXEC. */

            var r2203_00_SELECT_CONDITEC_DB_SELECT_1_Query1 = new R2203_00_SELECT_CONDITEC_DB_SELECT_1_Query1()
            {
                PROPSSVD_COD_SUBGRUPO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.ToString(),
                PROPSSVD_NUM_APOLICE = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.ToString(),
            };

            var executed_1 = R2203_00_SELECT_CONDITEC_DB_SELECT_1_Query1.Execute(r2203_00_SELECT_CONDITEC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONDITEC_CARREGA_CONJUGE, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2203_99_SAIDA*/

        [StopWatch]
        /*" R2205-00-SELECT-HISTCOBVA-SECTION */
        private void R2205_00_SELECT_HISTCOBVA_SECTION()
        {
            /*" -4640- MOVE '2205-00-SELECT-HISTCOBVA     ' TO PARAGRAFO. */
            _.Move("2205-00-SELECT-HISTCOBVA     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4641- MOVE 'SELECT COBER_HIST_VIDAZUL' TO COMANDO. */
            _.Move("SELECT COBER_HIST_VIDAZUL", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4643- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4646- MOVE PROPOFID-NUM-SICOB OF DCLPROPOSTA-FIDELIZ TO NUM-TITULO OF DCLCOBER-HIST-VIDAZUL. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB, CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_TITULO);

            /*" -4647- MOVE 22 TO SII */
            _.Move(22, WS_HORAS.SII);

            /*" -4648- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -4654- PERFORM R2205_00_SELECT_HISTCOBVA_DB_SELECT_1 */

            R2205_00_SELECT_HISTCOBVA_DB_SELECT_1();

            /*" -4657- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -4658- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -4658- MOVE 1 TO W-COBRANCA. */
                _.Move(1, WORK_AREA.W_COBRANCA);
            }


        }

        [StopWatch]
        /*" R2205-00-SELECT-HISTCOBVA-DB-SELECT-1 */
        public void R2205_00_SELECT_HISTCOBVA_DB_SELECT_1()
        {
            /*" -4654- EXEC SQL SELECT NUM_TITULO INTO :DCLCOBER-HIST-VIDAZUL.NUM-TITULO FROM SEGUROS.COBER_HIST_VIDAZUL WHERE NUM_TITULO = :DCLCOBER-HIST-VIDAZUL.NUM-TITULO END-EXEC. */

            var r2205_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1 = new R2205_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1()
            {
                NUM_TITULO = CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_TITULO.ToString(),
            };

            var executed_1 = R2205_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1.Execute(r2205_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUM_TITULO, CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_TITULO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2205_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-SELECT-PESSOA-SECTION */
        private void R2200_00_SELECT_PESSOA_SECTION()
        {
            /*" -4668- MOVE '2200-00-SELECT-PESSOA        ' TO PARAGRAFO. */
            _.Move("2200-00-SELECT-PESSOA        ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4669- MOVE 'SELECT SEGUROS.PESSOA        ' TO COMANDO. */
            _.Move("SELECT SEGUROS.PESSOA        ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4671- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4672- MOVE 23 TO SII */
            _.Move(23, WS_HORAS.SII);

            /*" -4673- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -4679- PERFORM R2200_00_SELECT_PESSOA_DB_SELECT_1 */

            R2200_00_SELECT_PESSOA_DB_SELECT_1();

            /*" -4681- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -4682- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4683- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4684- DISPLAY 'PESSOA FISICA NAO CADASTRADA ' */
                    _.Display($"PESSOA FISICA NAO CADASTRADA ");

                    /*" -4685- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4686- ELSE */
                }
                else
                {


                    /*" -4687- DISPLAY 'PROBLEMAS ACESSO PESSOA FISICA ' */
                    _.Display($"PROBLEMAS ACESSO PESSOA FISICA ");

                    /*" -4687- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2200-00-SELECT-PESSOA-DB-SELECT-1 */
        public void R2200_00_SELECT_PESSOA_DB_SELECT_1()
        {
            /*" -4679- EXEC SQL SELECT NOME_PESSOA INTO :DCLPESSOA.PESSOA-NOME-PESSOA FROM SEGUROS.PESSOA WHERE COD_PESSOA = :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA END-EXEC. */

            var r2200_00_SELECT_PESSOA_DB_SELECT_1_Query1 = new R2200_00_SELECT_PESSOA_DB_SELECT_1_Query1()
            {
                PROPOFID_COD_PESSOA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.ToString(),
            };

            var executed_1 = R2200_00_SELECT_PESSOA_DB_SELECT_1_Query1.Execute(r2200_00_SELECT_PESSOA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PESSOA_NOME_PESSOA, PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2210-00-SELECT-PESSOA-FISICA-SECTION */
        private void R2210_00_SELECT_PESSOA_FISICA_SECTION()
        {
            /*" -4697- MOVE '2210-00-SELECT-PESSOA-FISICA ' TO PARAGRAFO. */
            _.Move("2210-00-SELECT-PESSOA-FISICA ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4698- MOVE 'SELECT SEGUROS.PESSOA_FISICA ' TO COMANDO. */
            _.Move("SELECT SEGUROS.PESSOA_FISICA ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4700- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4701- MOVE 24 TO SII */
            _.Move(24, WS_HORAS.SII);

            /*" -4702- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -4726- PERFORM R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1 */

            R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1();

            /*" -4728- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -4729- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4730- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4731- DISPLAY 'PESSOA FISICA NAO CADASTRADA ' */
                    _.Display($"PESSOA FISICA NAO CADASTRADA ");

                    /*" -4732- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4733- ELSE */
                }
                else
                {


                    /*" -4734- DISPLAY 'PROBLEMAS ACESSO PESSOA FISICA ' */
                    _.Display($"PROBLEMAS ACESSO PESSOA FISICA ");

                    /*" -4734- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2210-00-SELECT-PESSOA-FISICA-DB-SELECT-1 */
        public void R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1()
        {
            /*" -4726- EXEC SQL SELECT CPF, DATA_NASCIMENTO, SEXO, COD_CBO, ESTADO_CIVIL, ORGAO_EXPEDIDOR, NUM_IDENTIDADE, DATA_EXPEDICAO, UF_EXPEDIDORA INTO :DCLPESSOA-FISICA.CPF, :DCLPESSOA-FISICA.DATA-NASCIMENTO, :DCLPESSOA-FISICA.SEXO, :DCLPESSOA-FISICA.COD-CBO, :DCLPESSOA-FISICA.ESTADO-CIVIL, :DCLPESSOA-FISICA.ORGAO-EXPEDIDOR, :DCLPESSOA-FISICA.NUM-IDENTIDADE, :DCLPESSOA-FISICA.DATA-EXPEDICAO :VIND-DATA-EXPEDICAO, :DCLPESSOA-FISICA.UF-EXPEDIDORA :VIND-UF-EXPEDIDORA FROM SEGUROS.PESSOA_FISICA WHERE COD_PESSOA = :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA END-EXEC. */

            var r2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1 = new R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1()
            {
                PROPOFID_COD_PESSOA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.ToString(),
            };

            var executed_1 = R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1.Execute(r2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CPF, PESFIS.DCLPESSOA_FISICA.CPF);
                _.Move(executed_1.DATA_NASCIMENTO, PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO);
                _.Move(executed_1.SEXO, PESFIS.DCLPESSOA_FISICA.SEXO);
                _.Move(executed_1.COD_CBO, PESFIS.DCLPESSOA_FISICA.COD_CBO);
                _.Move(executed_1.ESTADO_CIVIL, PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL);
                _.Move(executed_1.ORGAO_EXPEDIDOR, PESFIS.DCLPESSOA_FISICA.ORGAO_EXPEDIDOR);
                _.Move(executed_1.NUM_IDENTIDADE, PESFIS.DCLPESSOA_FISICA.NUM_IDENTIDADE);
                _.Move(executed_1.DATA_EXPEDICAO, PESFIS.DCLPESSOA_FISICA.DATA_EXPEDICAO);
                _.Move(executed_1.VIND_DATA_EXPEDICAO, VIND_DATA_EXPEDICAO);
                _.Move(executed_1.UF_EXPEDIDORA, PESFIS.DCLPESSOA_FISICA.UF_EXPEDIDORA);
                _.Move(executed_1.VIND_UF_EXPEDIDORA, VIND_UF_EXPEDIDORA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2210_99_SAIDA*/

        [StopWatch]
        /*" R2215-00-SELECT-PROPOVA-SECTION */
        private void R2215_00_SELECT_PROPOVA_SECTION()
        {
            /*" -4744- MOVE '2215-00-SELECT-PROPOVA       ' TO PARAGRAFO. */
            _.Move("2215-00-SELECT-PROPOVA       ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4745- MOVE 'SELECT SEGUROS.PROPOSTAS_VA  ' TO COMANDO. */
            _.Move("SELECT SEGUROS.PROPOSTAS_VA  ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4747- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4748- MOVE 25 TO SII */
            _.Move(25, WS_HORAS.SII);

            /*" -4749- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -4755- PERFORM R2215_00_SELECT_PROPOVA_DB_SELECT_1 */

            R2215_00_SELECT_PROPOVA_DB_SELECT_1();

            /*" -4757- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -4758- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4759- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4760- CONTINUE */

                    /*" -4761- ELSE */
                }
                else
                {


                    /*" -4762- DISPLAY 'PROBLEMAS ACESSO PROPOSTAS_VA  ' */
                    _.Display($"PROBLEMAS ACESSO PROPOSTAS_VA  ");

                    /*" -4763- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4764- END-IF */
                }


                /*" -4764- END-IF. */
            }


        }

        [StopWatch]
        /*" R2215-00-SELECT-PROPOVA-DB-SELECT-1 */
        public void R2215_00_SELECT_PROPOVA_DB_SELECT_1()
        {
            /*" -4755- EXEC SQL SELECT OCOREND INTO :DCLPROPOSTAS-VA.OCOREND FROM SEGUROS.PROPOSTAS_VA WHERE NUM_CERTIFICADO = :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF END-EXEC. */

            var r2215_00_SELECT_PROPOVA_DB_SELECT_1_Query1 = new R2215_00_SELECT_PROPOVA_DB_SELECT_1_Query1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R2215_00_SELECT_PROPOVA_DB_SELECT_1_Query1.Execute(r2215_00_SELECT_PROPOVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OCOREND, PROPVA.DCLPROPOSTAS_VA.OCOREND);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2215_99_SAIDA*/

        [StopWatch]
        /*" R2220-00-OBTER-ENDERECO-CORRES-SECTION */
        private void R2220_00_OBTER_ENDERECO_CORRES_SECTION()
        {
            /*" -4775- MOVE '2220-00-SELECT-PESSOA-ENDER  ' TO PARAGRAFO. */
            _.Move("2220-00-SELECT-PESSOA-ENDER  ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4776- MOVE 'SELECT  PESSOA_ENDERECO ' TO COMANDO. */
            _.Move("SELECT  PESSOA_ENDERECO ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4778- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4779- MOVE 26 TO SII */
            _.Move(26, WS_HORAS.SII);

            /*" -4780- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -4798- PERFORM R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1 */

            R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1();

            /*" -4800- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -4801- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4802- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4803- MOVE 2 TO W-ENDERECO */
                    _.Move(2, WORK_AREA.W_ENDERECO);

                    /*" -4804- GO TO R2220-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2220_99_SAIDA*/ //GOTO
                    return;

                    /*" -4805- ELSE */
                }
                else
                {


                    /*" -4806- DISPLAY 'PROBLEMAS ACESSO PESSOA ENDER  ' */
                    _.Display($"PROBLEMAS ACESSO PESSOA ENDER  ");

                    /*" -4808- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -4808- MOVE 1 TO W-ENDERECO. */
            _.Move(1, WORK_AREA.W_ENDERECO);

        }

        [StopWatch]
        /*" R2220-00-OBTER-ENDERECO-CORRES-DB-SELECT-1 */
        public void R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1()
        {
            /*" -4798- EXEC SQL SELECT OCORR_ENDERECO, ENDERECO, BAIRRO, CIDADE, CEP, SIGLA_UF INTO :DCLPESSOA-ENDERECO.OCORR-ENDERECO, :DCLPESSOA-ENDERECO.ENDERECO, :DCLPESSOA-ENDERECO.BAIRRO, :DCLPESSOA-ENDERECO.CIDADE, :DCLPESSOA-ENDERECO.CEP, :DCLPESSOA-ENDERECO.SIGLA-UF FROM SEGUROS.PESSOA_ENDERECO WHERE COD_PESSOA = :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA AND OCORR_ENDERECO = :DCLPROPOSTAS-VA.OCOREND END-EXEC. */

            var r2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1 = new R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1()
            {
                PROPOFID_COD_PESSOA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.ToString(),
                OCOREND = PROPVA.DCLPROPOSTAS_VA.OCOREND.ToString(),
            };

            var executed_1 = R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1.Execute(r2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OCORR_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO);
                _.Move(executed_1.ENDERECO, PESENDER.DCLPESSOA_ENDERECO.ENDERECO);
                _.Move(executed_1.BAIRRO, PESENDER.DCLPESSOA_ENDERECO.BAIRRO);
                _.Move(executed_1.CIDADE, PESENDER.DCLPESSOA_ENDERECO.CIDADE);
                _.Move(executed_1.CEP, PESENDER.DCLPESSOA_ENDERECO.CEP);
                _.Move(executed_1.SIGLA_UF, PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2220_99_SAIDA*/

        [StopWatch]
        /*" R2222-00-OBTER-ENDERECO-CORRES-SECTION */
        private void R2222_00_OBTER_ENDERECO_CORRES_SECTION()
        {
            /*" -4818- MOVE '2222-00-SELECT-PESSOA-ENDER  ' TO PARAGRAFO. */
            _.Move("2222-00-SELECT-PESSOA-ENDER  ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4819- MOVE 'DECLARE CPESENDER            ' TO COMANDO. */
            _.Move("DECLARE CPESENDER            ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4821- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4824- MOVE PROPOFID-DIGCTAVEN OF DCLPROPOSTA-FIDELIZ TO OCORR-ENDERECO OF DCLPESSOA-ENDERECO */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTAVEN, PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO);

            /*" -4838- PERFORM R2222_00_OBTER_ENDERECO_CORRES_DB_DECLARE_1 */

            R2222_00_OBTER_ENDERECO_CORRES_DB_DECLARE_1();

            /*" -4841- MOVE 27 TO SII */
            _.Move(27, WS_HORAS.SII);

            /*" -4842- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -4842- PERFORM R2222_00_OBTER_ENDERECO_CORRES_DB_OPEN_1 */

            R2222_00_OBTER_ENDERECO_CORRES_DB_OPEN_1();

            /*" -4844- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -4845- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4846- MOVE 2 TO W-ENDERECO */
                _.Move(2, WORK_AREA.W_ENDERECO);

                /*" -4847- GO TO R2222-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2222_99_SAIDA*/ //GOTO
                return;

                /*" -4848- ELSE */
            }
            else
            {


                /*" -4849- MOVE 'FETCH CPESENDER              ' TO COMANDO */
                _.Move("FETCH CPESENDER              ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -4857- PERFORM R2222_00_OBTER_ENDERECO_CORRES_DB_FETCH_1 */

                R2222_00_OBTER_ENDERECO_CORRES_DB_FETCH_1();

                /*" -4859- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -4860- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -4860- PERFORM R2222_00_OBTER_ENDERECO_CORRES_DB_CLOSE_1 */

                        R2222_00_OBTER_ENDERECO_CORRES_DB_CLOSE_1();

                        /*" -4862- MOVE 2 TO W-ENDERECO */
                        _.Move(2, WORK_AREA.W_ENDERECO);

                        /*" -4863- GO TO R2222-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2222_99_SAIDA*/ //GOTO
                        return;

                        /*" -4864- ELSE */
                    }
                    else
                    {


                        /*" -4865- DISPLAY 'PROBLEMAS FETCH ENDERECOS      ' */
                        _.Display($"PROBLEMAS FETCH ENDERECOS      ");

                        /*" -4867- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -4867- PERFORM R2222_00_OBTER_ENDERECO_CORRES_DB_CLOSE_2 */

            R2222_00_OBTER_ENDERECO_CORRES_DB_CLOSE_2();

            /*" -4869- MOVE 1 TO W-ENDERECO. */
            _.Move(1, WORK_AREA.W_ENDERECO);

        }

        [StopWatch]
        /*" R2222-00-OBTER-ENDERECO-CORRES-DB-OPEN-1 */
        public void R2222_00_OBTER_ENDERECO_CORRES_DB_OPEN_1()
        {
            /*" -4842- EXEC SQL OPEN CPESENDER END-EXEC. */

            CPESENDER.Open();

        }

        [StopWatch]
        /*" R2225-00-OBTER-DEMAIS-ENDERECO-DB-DECLARE-1 */
        public void R2225_00_OBTER_DEMAIS_ENDERECO_DB_DECLARE_1()
        {
            /*" -4893- EXEC SQL DECLARE CPESENDERR CURSOR FOR SELECT OCORR_ENDERECO, ENDERECO, BAIRRO, CIDADE, CEP, SIGLA_UF FROM SEGUROS.PESSOA_ENDERECO WHERE COD_PESSOA = :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA ORDER BY OCORR_ENDERECO DESC END-EXEC. */
            CPESENDERR = new VA0601B_CPESENDERR(true);
            string GetQuery_CPESENDERR()
            {
                var query = @$"SELECT OCORR_ENDERECO
							, 
							ENDERECO
							, 
							BAIRRO
							, 
							CIDADE
							, 
							CEP
							, 
							SIGLA_UF 
							FROM SEGUROS.PESSOA_ENDERECO 
							WHERE COD_PESSOA = 
							'{PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA}' 
							ORDER BY OCORR_ENDERECO DESC";

                return query;
            }
            CPESENDERR.GetQueryEvent += GetQuery_CPESENDERR;

        }

        [StopWatch]
        /*" R2222-00-OBTER-ENDERECO-CORRES-DB-FETCH-1 */
        public void R2222_00_OBTER_ENDERECO_CORRES_DB_FETCH_1()
        {
            /*" -4857- EXEC SQL FETCH CPESENDER INTO :DCLPESSOA-ENDERECO.OCORR-ENDERECO, :DCLPESSOA-ENDERECO.ENDERECO, :DCLPESSOA-ENDERECO.BAIRRO, :DCLPESSOA-ENDERECO.CIDADE, :DCLPESSOA-ENDERECO.CEP, :DCLPESSOA-ENDERECO.SIGLA-UF END-EXEC */

            if (CPESENDER.Fetch())
            {
                _.Move(CPESENDER.DCLPESSOA_ENDERECO_OCORR_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO);
                _.Move(CPESENDER.DCLPESSOA_ENDERECO_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.ENDERECO);
                _.Move(CPESENDER.DCLPESSOA_ENDERECO_BAIRRO, PESENDER.DCLPESSOA_ENDERECO.BAIRRO);
                _.Move(CPESENDER.DCLPESSOA_ENDERECO_CIDADE, PESENDER.DCLPESSOA_ENDERECO.CIDADE);
                _.Move(CPESENDER.DCLPESSOA_ENDERECO_CEP, PESENDER.DCLPESSOA_ENDERECO.CEP);
                _.Move(CPESENDER.DCLPESSOA_ENDERECO_SIGLA_UF, PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF);
            }

        }

        [StopWatch]
        /*" R2222-00-OBTER-ENDERECO-CORRES-DB-CLOSE-1 */
        public void R2222_00_OBTER_ENDERECO_CORRES_DB_CLOSE_1()
        {
            /*" -4860- EXEC SQL CLOSE CPESENDER END-EXEC */

            CPESENDER.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2222_99_SAIDA*/

        [StopWatch]
        /*" R2222-00-OBTER-ENDERECO-CORRES-DB-CLOSE-2 */
        public void R2222_00_OBTER_ENDERECO_CORRES_DB_CLOSE_2()
        {
            /*" -4867- EXEC SQL CLOSE CPESENDER END-EXEC. */

            CPESENDER.Close();

        }

        [StopWatch]
        /*" R2225-00-OBTER-DEMAIS-ENDERECO-SECTION */
        private void R2225_00_OBTER_DEMAIS_ENDERECO_SECTION()
        {
            /*" -4879- MOVE '2225-00-OBTER-OUTRO-ENDERECO ' TO PARAGRAFO. */
            _.Move("2225-00-OBTER-OUTRO-ENDERECO ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4880- MOVE 'DECLARE PESSOA_ENDERECO      ' TO COMANDO. */
            _.Move("DECLARE PESSOA_ENDERECO      ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4882- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4893- PERFORM R2225_00_OBTER_DEMAIS_ENDERECO_DB_DECLARE_1 */

            R2225_00_OBTER_DEMAIS_ENDERECO_DB_DECLARE_1();

            /*" -4896- MOVE 28 TO SII */
            _.Move(28, WS_HORAS.SII);

            /*" -4897- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -4897- PERFORM R2225_00_OBTER_DEMAIS_ENDERECO_DB_OPEN_1 */

            R2225_00_OBTER_DEMAIS_ENDERECO_DB_OPEN_1();

            /*" -4899- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -4900- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4901- MOVE 4 TO W-ENDERECO */
                _.Move(4, WORK_AREA.W_ENDERECO);

                /*" -4902- GO TO R2225-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2225_99_SAIDA*/ //GOTO
                return;

                /*" -4903- ELSE */
            }
            else
            {


                /*" -4904- MOVE 'FETCH CPESENDERR             ' TO COMANDO */
                _.Move("FETCH CPESENDERR             ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -4912- PERFORM R2225_00_OBTER_DEMAIS_ENDERECO_DB_FETCH_1 */

                R2225_00_OBTER_DEMAIS_ENDERECO_DB_FETCH_1();

                /*" -4914- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -4915- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -4915- PERFORM R2225_00_OBTER_DEMAIS_ENDERECO_DB_CLOSE_1 */

                        R2225_00_OBTER_DEMAIS_ENDERECO_DB_CLOSE_1();

                        /*" -4917- MOVE 4 TO W-ENDERECO */
                        _.Move(4, WORK_AREA.W_ENDERECO);

                        /*" -4918- GO TO R2225-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2225_99_SAIDA*/ //GOTO
                        return;

                        /*" -4919- ELSE */
                    }
                    else
                    {


                        /*" -4920- DISPLAY 'PROBLEMAS FETCH ENDERECOS      ' */
                        _.Display($"PROBLEMAS FETCH ENDERECOS      ");

                        /*" -4922- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -4922- PERFORM R2225_00_OBTER_DEMAIS_ENDERECO_DB_CLOSE_2 */

            R2225_00_OBTER_DEMAIS_ENDERECO_DB_CLOSE_2();

            /*" -4924- MOVE 3 TO W-ENDERECO. */
            _.Move(3, WORK_AREA.W_ENDERECO);

        }

        [StopWatch]
        /*" R2225-00-OBTER-DEMAIS-ENDERECO-DB-OPEN-1 */
        public void R2225_00_OBTER_DEMAIS_ENDERECO_DB_OPEN_1()
        {
            /*" -4897- EXEC SQL OPEN CPESENDERR END-EXEC. */

            CPESENDERR.Open();

        }

        [StopWatch]
        /*" R2232-00-SELECT-PESSOA-FONE-DB-DECLARE-1 */
        public void R2232_00_SELECT_PESSOA_FONE_DB_DECLARE_1()
        {
            /*" -5124- EXEC SQL DECLARE CFONE CURSOR FOR SELECT TIPO_FONE, DDD, NUM_FONE FROM SEGUROS.PESSOA_TELEFONE WHERE COD_PESSOA = :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA ORDER BY SEQ_FONE END-EXEC. */
            CFONE = new VA0601B_CFONE(true);
            string GetQuery_CFONE()
            {
                var query = @$"SELECT TIPO_FONE
							, 
							DDD
							, 
							NUM_FONE 
							FROM SEGUROS.PESSOA_TELEFONE 
							WHERE COD_PESSOA = 
							'{PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA}' 
							ORDER BY SEQ_FONE";

                return query;
            }
            CFONE.GetQueryEvent += GetQuery_CFONE;

        }

        [StopWatch]
        /*" R2225-00-OBTER-DEMAIS-ENDERECO-DB-FETCH-1 */
        public void R2225_00_OBTER_DEMAIS_ENDERECO_DB_FETCH_1()
        {
            /*" -4912- EXEC SQL FETCH CPESENDERR INTO :DCLPESSOA-ENDERECO.OCORR-ENDERECO, :DCLPESSOA-ENDERECO.ENDERECO, :DCLPESSOA-ENDERECO.BAIRRO, :DCLPESSOA-ENDERECO.CIDADE, :DCLPESSOA-ENDERECO.CEP, :DCLPESSOA-ENDERECO.SIGLA-UF END-EXEC */

            if (CPESENDERR.Fetch())
            {
                _.Move(CPESENDERR.DCLPESSOA_ENDERECO_OCORR_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO);
                _.Move(CPESENDERR.DCLPESSOA_ENDERECO_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.ENDERECO);
                _.Move(CPESENDERR.DCLPESSOA_ENDERECO_BAIRRO, PESENDER.DCLPESSOA_ENDERECO.BAIRRO);
                _.Move(CPESENDERR.DCLPESSOA_ENDERECO_CIDADE, PESENDER.DCLPESSOA_ENDERECO.CIDADE);
                _.Move(CPESENDERR.DCLPESSOA_ENDERECO_CEP, PESENDER.DCLPESSOA_ENDERECO.CEP);
                _.Move(CPESENDERR.DCLPESSOA_ENDERECO_SIGLA_UF, PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF);
            }

        }

        [StopWatch]
        /*" R2225-00-OBTER-DEMAIS-ENDERECO-DB-CLOSE-1 */
        public void R2225_00_OBTER_DEMAIS_ENDERECO_DB_CLOSE_1()
        {
            /*" -4915- EXEC SQL CLOSE CPESENDERR END-EXEC */

            CPESENDERR.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2225_99_SAIDA*/

        [StopWatch]
        /*" R2225-00-OBTER-DEMAIS-ENDERECO-DB-CLOSE-2 */
        public void R2225_00_OBTER_DEMAIS_ENDERECO_DB_CLOSE_2()
        {
            /*" -4922- EXEC SQL CLOSE CPESENDERR END-EXEC. */

            CPESENDERR.Close();

        }

        [StopWatch]
        /*" R2230-00-SELECT-PESSOA-FONE-SECTION */
        private void R2230_00_SELECT_PESSOA_FONE_SECTION()
        {
            /*" -4939- MOVE '2230-00-SELECT-PESSOA-FONE   ' TO PARAGRAFO. */
            _.Move("2230-00-SELECT-PESSOA-FONE   ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4941- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4943- MOVE 'SELECT PESSOA_TELEFONE 1' TO COMANDO. */
            _.Move("SELECT PESSOA_TELEFONE 1", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4944- MOVE 29 TO SII */
            _.Move(29, WS_HORAS.SII);

            /*" -4945- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -4959- PERFORM R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1 */

            R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1();

            /*" -4962- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -4963- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4964- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4967- MOVE ZEROS TO WHOST-DDD-RESIDENCIAL WHOST-SEQ-RESIDENCIAL WHOST-FONE-RESIDENCIAL */
                    _.Move(0, WHOST_DDD_RESIDENCIAL, WHOST_SEQ_RESIDENCIAL, WHOST_FONE_RESIDENCIAL);

                    /*" -4968- ELSE */
                }
                else
                {


                    /*" -4969- IF SQLCODE EQUAL -811 */

                    if (DB.SQLCODE == -811)
                    {

                        /*" -4970- CONTINUE */

                        /*" -4971- ELSE */
                    }
                    else
                    {


                        /*" -4972- DISPLAY 'PROBLEMAS NO SELECT  PESSOA TELEFONE 1' */
                        _.Display($"PROBLEMAS NO SELECT  PESSOA TELEFONE 1");

                        /*" -4973- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -4974- END-IF */
                    }


                    /*" -4975- END-IF */
                }


                /*" -4977- END-IF */
            }


            /*" -4979- MOVE 'SELECT PESSOA_TELEFONE 2' TO COMANDO. */
            _.Move("SELECT PESSOA_TELEFONE 2", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4980- MOVE 30 TO SII */
            _.Move(30, WS_HORAS.SII);

            /*" -4981- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -4994- PERFORM R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2 */

            R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2();

            /*" -4997- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -4998- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4999- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5002- MOVE ZEROS TO WHOST-DDD-COMERCIAL WHOST-SEQ-COMERCIAL WHOST-FONE-COMERCIAL */
                    _.Move(0, WHOST_DDD_COMERCIAL, WHOST_SEQ_COMERCIAL, WHOST_FONE_COMERCIAL);

                    /*" -5003- ELSE */
                }
                else
                {


                    /*" -5004- IF SQLCODE EQUAL -811 */

                    if (DB.SQLCODE == -811)
                    {

                        /*" -5005- CONTINUE */

                        /*" -5006- ELSE */
                    }
                    else
                    {


                        /*" -5007- DISPLAY 'PROBLEMAS NO SELECT  PESSOA TELEFONE 2' */
                        _.Display($"PROBLEMAS NO SELECT  PESSOA TELEFONE 2");

                        /*" -5009- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -5011- MOVE 'SELECT PESSOA_TELEFONE 3' TO COMANDO. */
            _.Move("SELECT PESSOA_TELEFONE 3", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5012- MOVE 31 TO SII */
            _.Move(31, WS_HORAS.SII);

            /*" -5013- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -5024- PERFORM R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3 */

            R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3();

            /*" -5027- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -5028- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5029- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5031- MOVE ZEROS TO WHOST-DDD-CELULAR WHOST-FONE-CELULAR */
                    _.Move(0, WHOST_DDD_CELULAR, WHOST_FONE_CELULAR);

                    /*" -5032- ELSE */
                }
                else
                {


                    /*" -5033- IF SQLCODE EQUAL -811 */

                    if (DB.SQLCODE == -811)
                    {

                        /*" -5034- CONTINUE */

                        /*" -5035- ELSE */
                    }
                    else
                    {


                        /*" -5036- DISPLAY 'PROBLEMAS NO SELECT  PESSOA TELEFONE 3' */
                        _.Display($"PROBLEMAS NO SELECT  PESSOA TELEFONE 3");

                        /*" -5038- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -5040- MOVE 'SELECT PESSOA_TELEFONE 4' TO COMANDO. */
            _.Move("SELECT PESSOA_TELEFONE 4", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5041- MOVE 32 TO SII */
            _.Move(32, WS_HORAS.SII);

            /*" -5042- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -5053- PERFORM R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4 */

            R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4();

            /*" -5056- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -5057- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5058- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5060- MOVE ZEROS TO WHOST-DDD-FAX WHOST-FONE-FAX */
                    _.Move(0, WHOST_DDD_FAX, WHOST_FONE_FAX);

                    /*" -5061- ELSE */
                }
                else
                {


                    /*" -5062- IF SQLCODE EQUAL -811 */

                    if (DB.SQLCODE == -811)
                    {

                        /*" -5063- CONTINUE */

                        /*" -5064- ELSE */
                    }
                    else
                    {


                        /*" -5065- DISPLAY 'PROBLEMAS NO SELECT  PESSOA TELEFONE 4' */
                        _.Display($"PROBLEMAS NO SELECT  PESSOA TELEFONE 4");

                        /*" -5067- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -5068- IF WHOST-DDD-RESIDENCIAL > 0 */

            if (WHOST_DDD_RESIDENCIAL > 0)
            {

                /*" -5069- MOVE WHOST-DDD-RESIDENCIAL TO WHOST-DDD */
                _.Move(WHOST_DDD_RESIDENCIAL, WHOST_DDD);

                /*" -5070- ELSE */
            }
            else
            {


                /*" -5071- IF WHOST-DDD-COMERCIAL > 0 */

                if (WHOST_DDD_COMERCIAL > 0)
                {

                    /*" -5072- MOVE WHOST-DDD-COMERCIAL TO WHOST-DDD */
                    _.Move(WHOST_DDD_COMERCIAL, WHOST_DDD);

                    /*" -5073- ELSE */
                }
                else
                {


                    /*" -5074- IF WHOST-DDD-CELULAR > 0 */

                    if (WHOST_DDD_CELULAR > 0)
                    {

                        /*" -5075- MOVE WHOST-DDD-CELULAR TO WHOST-DDD */
                        _.Move(WHOST_DDD_CELULAR, WHOST_DDD);

                        /*" -5076- ELSE */
                    }
                    else
                    {


                        /*" -5077- IF WHOST-DDD-FAX > 0 */

                        if (WHOST_DDD_FAX > 0)
                        {

                            /*" -5078- MOVE WHOST-DDD-FAX TO WHOST-DDD */
                            _.Move(WHOST_DDD_FAX, WHOST_DDD);

                            /*" -5079- ELSE */
                        }
                        else
                        {


                            /*" -5080- MOVE ZEROS TO WHOST-DDD */
                            _.Move(0, WHOST_DDD);

                            /*" -5081- END-IF */
                        }


                        /*" -5082- END-IF */
                    }


                    /*" -5083- END-IF */
                }


                /*" -5085- END-IF. */
            }


            /*" -5086- IF WHOST-FONE-COMERCIAL > 0 */

            if (WHOST_FONE_COMERCIAL > 0)
            {

                /*" -5087- IF WHOST-SEQ-COMERCIAL GREATER WHOST-SEQ-RESIDENCIAL */

                if (WHOST_SEQ_COMERCIAL > WHOST_SEQ_RESIDENCIAL)
                {

                    /*" -5088- MOVE WHOST-FONE-COMERCIAL TO WHOST-FONE */
                    _.Move(WHOST_FONE_COMERCIAL, WHOST_FONE);

                    /*" -5089- ELSE */
                }
                else
                {


                    /*" -5090- MOVE WHOST-FONE-RESIDENCIAL TO WHOST-FONE */
                    _.Move(WHOST_FONE_RESIDENCIAL, WHOST_FONE);

                    /*" -5091- ELSE */
                }

            }
            else
            {


                /*" -5092- MOVE WHOST-FONE-RESIDENCIAL TO WHOST-FONE */
                _.Move(WHOST_FONE_RESIDENCIAL, WHOST_FONE);

                /*" -5094- END-IF. */
            }


            /*" -5096- MOVE WHOST-FONE-CELULAR TO WHOST-TELEX. */
            _.Move(WHOST_FONE_CELULAR, WHOST_TELEX);

            /*" -5096- MOVE WHOST-FONE-FAX TO WHOST-FAX. */
            _.Move(WHOST_FONE_FAX, WHOST_FAX);

        }

        [StopWatch]
        /*" R2230-00-SELECT-PESSOA-FONE-DB-SELECT-1 */
        public void R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1()
        {
            /*" -4959- EXEC SQL SELECT DDD, NUM_FONE, SEQ_FONE INTO :WHOST-DDD-RESIDENCIAL, :WHOST-FONE-RESIDENCIAL, :WHOST-SEQ-RESIDENCIAL FROM SEGUROS.PESSOA_TELEFONE WHERE COD_PESSOA = :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA AND TIPO_FONE = 1 ORDER BY SEQ_FONE DESC FETCH FIRST ROWS ONLY END-EXEC. */

            var r2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1 = new R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1()
            {
                PROPOFID_COD_PESSOA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.ToString(),
            };

            var executed_1 = R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1.Execute(r2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DDD_RESIDENCIAL, WHOST_DDD_RESIDENCIAL);
                _.Move(executed_1.WHOST_FONE_RESIDENCIAL, WHOST_FONE_RESIDENCIAL);
                _.Move(executed_1.WHOST_SEQ_RESIDENCIAL, WHOST_SEQ_RESIDENCIAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2230_99_SAIDA*/

        [StopWatch]
        /*" R2230-00-SELECT-PESSOA-FONE-DB-SELECT-2 */
        public void R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2()
        {
            /*" -4994- EXEC SQL SELECT DDD, NUM_FONE, SEQ_FONE INTO :WHOST-DDD-COMERCIAL, :WHOST-FONE-COMERCIAL, :WHOST-SEQ-COMERCIAL FROM SEGUROS.PESSOA_TELEFONE WHERE COD_PESSOA = :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA AND TIPO_FONE = 2 ORDER BY SEQ_FONE DESC FETCH FIRST ROWS ONLY END-EXEC. */

            var r2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1 = new R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1()
            {
                PROPOFID_COD_PESSOA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.ToString(),
            };

            var executed_1 = R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1.Execute(r2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DDD_COMERCIAL, WHOST_DDD_COMERCIAL);
                _.Move(executed_1.WHOST_FONE_COMERCIAL, WHOST_FONE_COMERCIAL);
                _.Move(executed_1.WHOST_SEQ_COMERCIAL, WHOST_SEQ_COMERCIAL);
            }


        }

        [StopWatch]
        /*" R2232-00-SELECT-PESSOA-FONE-SECTION */
        private void R2232_00_SELECT_PESSOA_FONE_SECTION()
        {
            /*" -5106- MOVE '2232-00-SELECT-PESSOA-FONE   ' TO PARAGRAFO. */
            _.Move("2232-00-SELECT-PESSOA-FONE   ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5108- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5112- MOVE ZEROS TO WHOST-DDD WHOST-FONE WHOST-FAX. */
            _.Move(0, WHOST_DDD, WHOST_FONE, WHOST_FAX);

            /*" -5114- MOVE 'DECLARE CURSOR PESSOA_TELEFONE' TO COMANDO. */
            _.Move("DECLARE CURSOR PESSOA_TELEFONE", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5115- MOVE 33 TO SII */
            _.Move(33, WS_HORAS.SII);

            /*" -5116- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -5124- PERFORM R2232_00_SELECT_PESSOA_FONE_DB_DECLARE_1 */

            R2232_00_SELECT_PESSOA_FONE_DB_DECLARE_1();

            /*" -5127- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -5127- PERFORM R2232_00_SELECT_PESSOA_FONE_DB_OPEN_1 */

            R2232_00_SELECT_PESSOA_FONE_DB_OPEN_1();

            /*" -5129- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5130- DISPLAY 'PROBLEMAS NO DECLARE PESSOA TELEFONE ' */
                _.Display($"PROBLEMAS NO DECLARE PESSOA TELEFONE ");

                /*" -5130- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM R2232_10_FETCH_PESSOA_FONE */

            R2232_10_FETCH_PESSOA_FONE();

        }

        [StopWatch]
        /*" R2232-00-SELECT-PESSOA-FONE-DB-OPEN-1 */
        public void R2232_00_SELECT_PESSOA_FONE_DB_OPEN_1()
        {
            /*" -5127- EXEC SQL OPEN CFONE END-EXEC. */

            CFONE.Open();

        }

        [StopWatch]
        /*" R2241-00-SELECT-ACUM-RISCO-DB-DECLARE-1 */
        public void R2241_00_SELECT_ACUM_RISCO_DB_DECLARE_1()
        {
            /*" -5324- EXEC SQL DECLARE CRISCO CURSOR FOR SELECT A.NUM_CERTIFICADO FROM SEGUROS.PROPOSTAS_VA A, SEGUROS.CLIENTES B, SEGUROS.PRODUTOS_VG C WHERE C.NOME_PRODUTO = :DCLPRODUTOS-VG.PRODUVG-NOME-PRODUTO AND B.CGCCPF = :DCLPESSOA-FISICA.CPF AND A.COD_CLIENTE = B.COD_CLIENTE AND A.NUM_APOLICE = C.NUM_APOLICE AND A.COD_SUBGRUPO = C.COD_SUBGRUPO AND A.SIT_REGISTRO IN ( '0' , '3' , '6' , '7' , '8' , '9' , 'E' ) END-EXEC */
            CRISCO = new VA0601B_CRISCO(true);
            string GetQuery_CRISCO()
            {
                var query = @$"SELECT A.NUM_CERTIFICADO 
							FROM SEGUROS.PROPOSTAS_VA A
							, 
							SEGUROS.CLIENTES B
							, 
							SEGUROS.PRODUTOS_VG C 
							WHERE C.NOME_PRODUTO = 
							'{PRODUVG.DCLPRODUTOS_VG.PRODUVG_NOME_PRODUTO}' 
							AND B.CGCCPF = '{PESFIS.DCLPESSOA_FISICA.CPF}' 
							AND A.COD_CLIENTE = B.COD_CLIENTE 
							AND A.NUM_APOLICE = C.NUM_APOLICE 
							AND A.COD_SUBGRUPO = C.COD_SUBGRUPO 
							AND A.SIT_REGISTRO IN ( '0'
							, '3'
							, '6'
							, '7'
							, '8'
							, '9'
							, 'E' )";

                return query;
            }
            CRISCO.GetQueryEvent += GetQuery_CRISCO;

        }

        [StopWatch]
        /*" R2230-00-SELECT-PESSOA-FONE-DB-SELECT-3 */
        public void R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3()
        {
            /*" -5024- EXEC SQL SELECT DDD, NUM_FONE INTO :WHOST-DDD-CELULAR, :WHOST-FONE-CELULAR FROM SEGUROS.PESSOA_TELEFONE WHERE COD_PESSOA = :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA AND TIPO_FONE = 3 ORDER BY SEQ_FONE DESC FETCH FIRST ROWS ONLY END-EXEC. */

            var r2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1 = new R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1()
            {
                PROPOFID_COD_PESSOA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.ToString(),
            };

            var executed_1 = R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1.Execute(r2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DDD_CELULAR, WHOST_DDD_CELULAR);
                _.Move(executed_1.WHOST_FONE_CELULAR, WHOST_FONE_CELULAR);
            }


        }

        [StopWatch]
        /*" R2232-10-FETCH-PESSOA-FONE */
        private void R2232_10_FETCH_PESSOA_FONE(bool isPerform = false)
        {
            /*" -5135- MOVE 'FETCH CFONE                  ' TO COMANDO. */
            _.Move("FETCH CFONE                  ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5140- PERFORM R2232_10_FETCH_PESSOA_FONE_DB_FETCH_1 */

            R2232_10_FETCH_PESSOA_FONE_DB_FETCH_1();

            /*" -5143- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5144- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5144- PERFORM R2232_10_FETCH_PESSOA_FONE_DB_CLOSE_1 */

                    R2232_10_FETCH_PESSOA_FONE_DB_CLOSE_1();

                    /*" -5146- MOVE 1874 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(1874, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -5147- PERFORM R1100-00-GRAVA-TAB-ERRO */

                    R1100_00_GRAVA_TAB_ERRO_SECTION();

                    /*" -5148- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                    _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                    /*" -5149- GO TO R2232-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2232_99_SAIDA*/ //GOTO
                    return;

                    /*" -5150- ELSE */
                }
                else
                {


                    /*" -5151- DISPLAY 'PROBLEMAS FETCH ENDERECOS      ' */
                    _.Display($"PROBLEMAS FETCH ENDERECOS      ");

                    /*" -5158- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -5159- IF TIPO-FONE EQUAL 1 */

            if (PESFONE.DCLPESSOA_TELEFONE.TIPO_FONE == 1)
            {

                /*" -5160- MOVE DDD OF DCLPESSOA-TELEFONE TO WHOST-DDD */
                _.Move(PESFONE.DCLPESSOA_TELEFONE.DDD, WHOST_DDD);

                /*" -5161- MOVE NUM-FONE OF DCLPESSOA-TELEFONE TO WHOST-FONE */
                _.Move(PESFONE.DCLPESSOA_TELEFONE.NUM_FONE, WHOST_FONE);

                /*" -5163- END-IF */
            }


            /*" -5164- IF TIPO-FONE EQUAL 2 AND > 0 */

            if (PESFONE.DCLPESSOA_TELEFONE.TIPO_FONE == 2 && PESFONE.DCLPESSOA_TELEFONE.TIPO_FONE > 0)
            {

                /*" -5165- MOVE DDD OF DCLPESSOA-TELEFONE TO WHOST-DDD */
                _.Move(PESFONE.DCLPESSOA_TELEFONE.DDD, WHOST_DDD);

                /*" -5166- MOVE NUM-FONE OF DCLPESSOA-TELEFONE TO WHOST-FONE */
                _.Move(PESFONE.DCLPESSOA_TELEFONE.NUM_FONE, WHOST_FONE);

                /*" -5168- END-IF */
            }


            /*" -5169- IF TIPO-FONE EQUAL 3 */

            if (PESFONE.DCLPESSOA_TELEFONE.TIPO_FONE == 3)
            {

                /*" -5170- MOVE DDD OF DCLPESSOA-TELEFONE TO WHOST-DDD */
                _.Move(PESFONE.DCLPESSOA_TELEFONE.DDD, WHOST_DDD);

                /*" -5171- MOVE NUM-FONE OF DCLPESSOA-TELEFONE TO WHOST-TELEX */
                _.Move(PESFONE.DCLPESSOA_TELEFONE.NUM_FONE, WHOST_TELEX);

                /*" -5173- END-IF */
            }


            /*" -5174- IF TIPO-FONE EQUAL 4 */

            if (PESFONE.DCLPESSOA_TELEFONE.TIPO_FONE == 4)
            {

                /*" -5175- MOVE DDD OF DCLPESSOA-TELEFONE TO WHOST-DDD */
                _.Move(PESFONE.DCLPESSOA_TELEFONE.DDD, WHOST_DDD);

                /*" -5176- MOVE NUM-FONE OF DCLPESSOA-TELEFONE TO WHOST-FAX */
                _.Move(PESFONE.DCLPESSOA_TELEFONE.NUM_FONE, WHOST_FAX);

                /*" -5177- END-IF */
            }


            /*" -5177- GO TO R2232-10-FETCH-PESSOA-FONE. */
            new Task(() => R2232_10_FETCH_PESSOA_FONE()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R2232-10-FETCH-PESSOA-FONE-DB-FETCH-1 */
        public void R2232_10_FETCH_PESSOA_FONE_DB_FETCH_1()
        {
            /*" -5140- EXEC SQL FETCH CFONE INTO :DCLPESSOA-TELEFONE.TIPO-FONE, :DCLPESSOA-TELEFONE.DDD, :DCLPESSOA-TELEFONE.NUM-FONE END-EXEC. */

            if (CFONE.Fetch())
            {
                _.Move(CFONE.DCLPESSOA_TELEFONE_TIPO_FONE, PESFONE.DCLPESSOA_TELEFONE.TIPO_FONE);
                _.Move(CFONE.DCLPESSOA_TELEFONE_DDD, PESFONE.DCLPESSOA_TELEFONE.DDD);
                _.Move(CFONE.DCLPESSOA_TELEFONE_NUM_FONE, PESFONE.DCLPESSOA_TELEFONE.NUM_FONE);
            }

        }

        [StopWatch]
        /*" R2232-10-FETCH-PESSOA-FONE-DB-CLOSE-1 */
        public void R2232_10_FETCH_PESSOA_FONE_DB_CLOSE_1()
        {
            /*" -5144- EXEC SQL CLOSE CFONE END-EXEC */

            CFONE.Close();

        }

        [StopWatch]
        /*" R2230-00-SELECT-PESSOA-FONE-DB-SELECT-4 */
        public void R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4()
        {
            /*" -5053- EXEC SQL SELECT DDD, NUM_FONE INTO :WHOST-DDD-FAX, :WHOST-FONE-FAX FROM SEGUROS.PESSOA_TELEFONE WHERE COD_PESSOA = :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA AND TIPO_FONE = 4 ORDER BY SEQ_FONE DESC FETCH FIRST ROWS ONLY END-EXEC. */

            var r2230_00_SELECT_PESSOA_FONE_DB_SELECT_4_Query1 = new R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4_Query1()
            {
                PROPOFID_COD_PESSOA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.ToString(),
            };

            var executed_1 = R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4_Query1.Execute(r2230_00_SELECT_PESSOA_FONE_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DDD_FAX, WHOST_DDD_FAX);
                _.Move(executed_1.WHOST_FONE_FAX, WHOST_FONE_FAX);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2232_99_SAIDA*/

        [StopWatch]
        /*" R2235-00-UPDATE-PESSOA-FONE-SECTION */
        private void R2235_00_UPDATE_PESSOA_FONE_SECTION()
        {
            /*" -5187- MOVE '2235-00-UPDATE-PESSOA-FONE   ' TO PARAGRAFO. */
            _.Move("2235-00-UPDATE-PESSOA-FONE   ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5188- MOVE 'UPDATE PESSOA_TELEFONE       ' TO COMANDO. */
            _.Move("UPDATE PESSOA_TELEFONE       ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5190- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5191- MOVE 34 TO SII */
            _.Move(34, WS_HORAS.SII);

            /*" -5192- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -5197- PERFORM R2235_00_UPDATE_PESSOA_FONE_DB_UPDATE_1 */

            R2235_00_UPDATE_PESSOA_FONE_DB_UPDATE_1();

            /*" -5200- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -5201- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -5202- DISPLAY 'PROBLEMAS NO UPDATE  PESSOA TELEFONE ' */
                _.Display($"PROBLEMAS NO UPDATE  PESSOA TELEFONE ");

                /*" -5202- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2235-00-UPDATE-PESSOA-FONE-DB-UPDATE-1 */
        public void R2235_00_UPDATE_PESSOA_FONE_DB_UPDATE_1()
        {
            /*" -5197- EXEC SQL UPDATE SEGUROS.PESSOA_TELEFONE SET SITUACAO_FONE = 'A' WHERE COD_PESSOA = :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA AND SITUACAO_FONE = 'P' END-EXEC. */

            var r2235_00_UPDATE_PESSOA_FONE_DB_UPDATE_1_Update1 = new R2235_00_UPDATE_PESSOA_FONE_DB_UPDATE_1_Update1()
            {
                PROPOFID_COD_PESSOA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.ToString(),
            };

            R2235_00_UPDATE_PESSOA_FONE_DB_UPDATE_1_Update1.Execute(r2235_00_UPDATE_PESSOA_FONE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2235_99_SAIDA*/

        [StopWatch]
        /*" R2236-00-SELECT-PESSOA-EMAIL-SECTION */
        private void R2236_00_SELECT_PESSOA_EMAIL_SECTION()
        {
            /*" -5212- MOVE '2236-00-SELECT-PESSOA-EMAIL  ' TO PARAGRAFO. */
            _.Move("2236-00-SELECT-PESSOA-EMAIL  ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5213- MOVE 'SELECT PESSOA_EMAIL          ' TO COMANDO. */
            _.Move("SELECT PESSOA_EMAIL          ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5215- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5216- MOVE 35 TO SII */
            _.Move(35, WS_HORAS.SII);

            /*" -5217- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -5225- PERFORM R2236_00_SELECT_PESSOA_EMAIL_DB_SELECT_1 */

            R2236_00_SELECT_PESSOA_EMAIL_DB_SELECT_1();

            /*" -5228- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -5229- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5230- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5231- MOVE SPACES TO WHOST-EMAIL */
                    _.Move("", WHOST_EMAIL);

                    /*" -5232- GO TO R2236-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2236_99_SAIDA*/ //GOTO
                    return;

                    /*" -5233- ELSE */
                }
                else
                {


                    /*" -5234- IF SQLCODE EQUAL -811 */

                    if (DB.SQLCODE == -811)
                    {

                        /*" -5235- CONTINUE */

                        /*" -5236- ELSE */
                    }
                    else
                    {


                        /*" -5237- DISPLAY 'PROBLEMAS NO SELECT  PESSOA EMAIL' */
                        _.Display($"PROBLEMAS NO SELECT  PESSOA EMAIL");

                        /*" -5239- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -5241- MOVE 'UPDATE PESSOA_EMAIL     ' TO COMANDO. */
            _.Move("UPDATE PESSOA_EMAIL     ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5242- MOVE 36 TO SII */
            _.Move(36, WS_HORAS.SII);

            /*" -5243- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -5248- PERFORM R2236_00_SELECT_PESSOA_EMAIL_DB_UPDATE_1 */

            R2236_00_SELECT_PESSOA_EMAIL_DB_UPDATE_1();

            /*" -5251- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -5252- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5253- DISPLAY 'PROBLEMAS NO UPDATE PESSOA EMAIL' */
                _.Display($"PROBLEMAS NO UPDATE PESSOA EMAIL");

                /*" -5253- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2236-00-SELECT-PESSOA-EMAIL-DB-SELECT-1 */
        public void R2236_00_SELECT_PESSOA_EMAIL_DB_SELECT_1()
        {
            /*" -5225- EXEC SQL SELECT EMAIL INTO :WHOST-EMAIL FROM SEGUROS.PESSOA_EMAIL WHERE COD_PESSOA = :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA AND SITUACAO_EMAIL = 'P' ORDER BY SEQ_EMAIL DESC END-EXEC. */

            var r2236_00_SELECT_PESSOA_EMAIL_DB_SELECT_1_Query1 = new R2236_00_SELECT_PESSOA_EMAIL_DB_SELECT_1_Query1()
            {
                PROPOFID_COD_PESSOA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.ToString(),
            };

            var executed_1 = R2236_00_SELECT_PESSOA_EMAIL_DB_SELECT_1_Query1.Execute(r2236_00_SELECT_PESSOA_EMAIL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_EMAIL, WHOST_EMAIL);
            }


        }

        [StopWatch]
        /*" R2236-00-SELECT-PESSOA-EMAIL-DB-UPDATE-1 */
        public void R2236_00_SELECT_PESSOA_EMAIL_DB_UPDATE_1()
        {
            /*" -5248- EXEC SQL UPDATE SEGUROS.PESSOA_EMAIL SET SITUACAO_EMAIL = 'A' WHERE COD_PESSOA = :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA AND SITUACAO_EMAIL = 'P' END-EXEC. */

            var r2236_00_SELECT_PESSOA_EMAIL_DB_UPDATE_1_Update1 = new R2236_00_SELECT_PESSOA_EMAIL_DB_UPDATE_1_Update1()
            {
                PROPOFID_COD_PESSOA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.ToString(),
            };

            R2236_00_SELECT_PESSOA_EMAIL_DB_UPDATE_1_Update1.Execute(r2236_00_SELECT_PESSOA_EMAIL_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2236_99_SAIDA*/

        [StopWatch]
        /*" R2240-00-SELECT-PROPFIDC-SECTION */
        private void R2240_00_SELECT_PROPFIDC_SECTION()
        {
            /*" -5263- MOVE '2240-00-SELECT-PROPFIDC      ' TO PARAGRAFO. */
            _.Move("2240-00-SELECT-PROPFIDC      ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5264- MOVE 'SELECT PROPFIDC              ' TO COMANDO. */
            _.Move("SELECT PROPFIDC              ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5266- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5267- MOVE 37 TO SII */
            _.Move(37, WS_HORAS.SII);

            /*" -5268- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -5276- PERFORM R2240_00_SELECT_PROPFIDC_DB_SELECT_1 */

            R2240_00_SELECT_PROPFIDC_DB_SELECT_1();

            /*" -5280- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -5281- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5282- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5284- MOVE SPACES TO PROFIDCO-INFORMACAO-COMPL OF DCLPROP-FIDELIZ-COMP */
                    _.Move("", PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_INFORMACAO_COMPL);

                    /*" -5285- ELSE */
                }
                else
                {


                    /*" -5286- DISPLAY 'VA0601B - PROBLEMAS NO ACESSOA A PROPFIDC ' */
                    _.Display($"VA0601B - PROBLEMAS NO ACESSOA A PROPFIDC ");

                    /*" -5288- DISPLAY '          NUMERO PROPOSTA...............  ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          NUMERO PROPOSTA...............  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -5290- DISPLAY '          NUMERO IDENTIFICACAO..........  ' PROPSSVD-NUM-IDENTIFICACAO OF DCLPROP-SASSE-VIDA */
                    _.Display($"          NUMERO IDENTIFICACAO..........  {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_IDENTIFICACAO}");

                    /*" -5292- DISPLAY '          IND TIPO INFORMACAO...........  ' PROFIDCO-IND-TP-INFORMACAO OF DCLPROP-FIDELIZ-COMP */
                    _.Display($"          IND TIPO INFORMACAO...........  {PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_IND_TP_INFORMACAO}");

                    /*" -5293- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -5294- END-IF */
                }


                /*" -5296- END-IF */
            }


            /*" -5297- MOVE PROFIDCO-INFORMACAO-COMPL OF DCLPROP-FIDELIZ-COMP TO WHOST-INFO-COMPL. */
            _.Move(PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_INFORMACAO_COMPL, WHOST_INFO_COMPL);

        }

        [StopWatch]
        /*" R2240-00-SELECT-PROPFIDC-DB-SELECT-1 */
        public void R2240_00_SELECT_PROPFIDC_DB_SELECT_1()
        {
            /*" -5276- EXEC SQL SELECT INFORMACAO_COMPL INTO :DCLPROP-FIDELIZ-COMP.PROFIDCO-INFORMACAO-COMPL FROM SEGUROS.PROP_FIDELIZ_COMP WHERE NUM_IDENTIFICACAO = :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-IDENTIFICACAO AND IND_TP_INFORMACAO = :DCLPROP-FIDELIZ-COMP.PROFIDCO-IND-TP-INFORMACAO END-EXEC. */

            var r2240_00_SELECT_PROPFIDC_DB_SELECT_1_Query1 = new R2240_00_SELECT_PROPFIDC_DB_SELECT_1_Query1()
            {
                PROFIDCO_IND_TP_INFORMACAO = PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_IND_TP_INFORMACAO.ToString(),
                PROPSSVD_NUM_IDENTIFICACAO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_IDENTIFICACAO.ToString(),
            };

            var executed_1 = R2240_00_SELECT_PROPFIDC_DB_SELECT_1_Query1.Execute(r2240_00_SELECT_PROPFIDC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROFIDCO_INFORMACAO_COMPL, PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_INFORMACAO_COMPL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2240_99_SAIDA*/

        [StopWatch]
        /*" R2241-00-SELECT-ACUM-RISCO-SECTION */
        private void R2241_00_SELECT_ACUM_RISCO_SECTION()
        {
            /*" -5307- MOVE '2241-00-SELECT-ACUM-RISCO     ' TO PARAGRAFO. */
            _.Move("2241-00-SELECT-ACUM-RISCO     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5309- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5311- MOVE IMPMORNATU OF DCLPLANOS-VA-VGAP TO AC-TOT-RISCO */
            _.Move(PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU, WORK_AREA.AC_TOT_RISCO);

            /*" -5312- MOVE 'DECLARE CURSOR CRISCO         ' TO COMANDO */
            _.Move("DECLARE CURSOR CRISCO         ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5324- PERFORM R2241_00_SELECT_ACUM_RISCO_DB_DECLARE_1 */

            R2241_00_SELECT_ACUM_RISCO_DB_DECLARE_1();

            /*" -5327- MOVE 38 TO SII */
            _.Move(38, WS_HORAS.SII);

            /*" -5328- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -5328- PERFORM R2241_00_SELECT_ACUM_RISCO_DB_OPEN_1 */

            R2241_00_SELECT_ACUM_RISCO_DB_OPEN_1();

            /*" -5331- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -5332- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5332- PERFORM R2241_00_SELECT_ACUM_RISCO_DB_CLOSE_1 */

                R2241_00_SELECT_ACUM_RISCO_DB_CLOSE_1();

                /*" -5334- DISPLAY 'VA0601B - PROBLEMAS NO DECLARE PROPOSTAS_VA' */
                _.Display($"VA0601B - PROBLEMAS NO DECLARE PROPOSTAS_VA");

                /*" -5336- DISPLAY '          NOME_PRODUTO..........   ' PRODUVG-NOME-PRODUTO OF DCLPRODUTOS-VG */
                _.Display($"          NOME_PRODUTO..........   {PRODUVG.DCLPRODUTOS_VG.PRODUVG_NOME_PRODUTO}");

                /*" -5338- DISPLAY '          CPF_CLIENTE...........   ' CPF OF DCLPESSOA-FISICA */
                _.Display($"          CPF_CLIENTE...........   {PESFIS.DCLPESSOA_FISICA.CPF}");

                /*" -5340- DISPLAY '          NUM_APOLICE...........   ' PROPSSVD-NUM-APOLICE OF DCLPROP-SASSE-VIDA */
                _.Display($"          NUM_APOLICE...........   {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE}");

                /*" -5342- DISPLAY '          CODSUBES..............   ' PROPSSVD-COD-SUBGRUPO OF DCLPROP-SASSE-VIDA */
                _.Display($"          CODSUBES..............   {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO}");

                /*" -5343- MOVE SQLCODE TO WHOST-SQLCODE */
                _.Move(DB.SQLCODE, WS_HORAS.WHOST_SQLCODE);

                /*" -5345- DISPLAY '          SQLCODE...............   ' WHOST-SQLCODE */
                _.Display($"          SQLCODE...............   {WS_HORAS.WHOST_SQLCODE}");

                /*" -5346- GO TO R2241-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2241_99_SAIDA*/ //GOTO
                return;

                /*" -5348- END-IF */
            }


            /*" -5348- . */

            /*" -0- FLUXCONTROL_PERFORM R2241_10_FETCH */

            R2241_10_FETCH();

        }

        [StopWatch]
        /*" R2241-00-SELECT-ACUM-RISCO-DB-OPEN-1 */
        public void R2241_00_SELECT_ACUM_RISCO_DB_OPEN_1()
        {
            /*" -5328- EXEC SQL OPEN CRISCO END-EXEC */

            CRISCO.Open();

        }

        [StopWatch]
        /*" R2242-00-SELECT-ACUM-RISCO-DB-DECLARE-1 */
        public void R2242_00_SELECT_ACUM_RISCO_DB_DECLARE_1()
        {
            /*" -5431- EXEC SQL DECLARE CRISCO1 CURSOR FOR SELECT A.NUM_CERTIFICADO FROM SEGUROS.PROPOSTAS_VA A, SEGUROS.CLIENTES B, SEGUROS.PROPOSTA_FIDELIZ C WHERE C.COD_PRODUTO_SIVPF = : PROPOFID-COD-PRODUTO-SIVPF AND B.CGCCPF = :DCLPESSOA-FISICA.CPF AND A.COD_CLIENTE = B.COD_CLIENTE AND A.NUM_CERTIFICADO = C.NUM_PROPOSTA_SIVPF AND A.SIT_REGISTRO IN ( '0' , '3' , '6' , '7' , '9' , 'E' , '8' ) END-EXEC. */
            CRISCO1 = new VA0601B_CRISCO1(true);
            string GetQuery_CRISCO1()
            {
                var query = @$"SELECT A.NUM_CERTIFICADO 
							FROM SEGUROS.PROPOSTAS_VA A
							, 
							SEGUROS.CLIENTES B
							, 
							SEGUROS.PROPOSTA_FIDELIZ C 
							WHERE C.COD_PRODUTO_SIVPF = 
							'{PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF}' 
							AND B.CGCCPF = '{PESFIS.DCLPESSOA_FISICA.CPF}' 
							AND A.COD_CLIENTE = B.COD_CLIENTE 
							AND A.NUM_CERTIFICADO = C.NUM_PROPOSTA_SIVPF 
							AND A.SIT_REGISTRO IN ( '0'
							, '3'
							, '6'
							, '7'
							, '9'
							, 'E'
							, '8' )";

                return query;
            }
            CRISCO1.GetQueryEvent += GetQuery_CRISCO1;

        }

        [StopWatch]
        /*" R2241-00-SELECT-ACUM-RISCO-DB-CLOSE-1 */
        public void R2241_00_SELECT_ACUM_RISCO_DB_CLOSE_1()
        {
            /*" -5332- EXEC SQL CLOSE CRISCO END-EXEC */

            CRISCO.Close();

        }

        [StopWatch]
        /*" R2241-10-FETCH */
        private void R2241_10_FETCH(bool isPerform = false)
        {
            /*" -5353- MOVE 'FETCH  CRISCO                ' TO COMANDO. */
            _.Move("FETCH  CRISCO                ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5356- PERFORM R2241_10_FETCH_DB_FETCH_1 */

            R2241_10_FETCH_DB_FETCH_1();

            /*" -5359- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5360- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5360- PERFORM R2241_10_FETCH_DB_CLOSE_1 */

                    R2241_10_FETCH_DB_CLOSE_1();

                    /*" -5362- GO TO R2241-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2241_99_SAIDA*/ //GOTO
                    return;

                    /*" -5363- ELSE */
                }
                else
                {


                    /*" -5363- PERFORM R2241_10_FETCH_DB_CLOSE_2 */

                    R2241_10_FETCH_DB_CLOSE_2();

                    /*" -5365- DISPLAY 'VA0601B - PROBLEMAS NO FETCH PROPOSTAS_VA' */
                    _.Display($"VA0601B - PROBLEMAS NO FETCH PROPOSTAS_VA");

                    /*" -5367- DISPLAY '          NUM_APOLICE...........   ' PROPSSVD-NUM-APOLICE OF DCLPROP-SASSE-VIDA */
                    _.Display($"          NUM_APOLICE...........   {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE}");

                    /*" -5369- DISPLAY '          CODSUBES..............   ' PROPSSVD-COD-SUBGRUPO OF DCLPROP-SASSE-VIDA */
                    _.Display($"          CODSUBES..............   {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO}");

                    /*" -5371- DISPLAY '          SQLCODE...............   ' SQLCODE */
                    _.Display($"          SQLCODE...............   {DB.SQLCODE}");

                    /*" -5372- GO TO R2241-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2241_99_SAIDA*/ //GOTO
                    return;

                    /*" -5373- END-IF */
                }


                /*" -5375- END-IF */
            }


            /*" -5376- MOVE 39 TO SII */
            _.Move(39, WS_HORAS.SII);

            /*" -5377- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -5384- PERFORM R2241_10_FETCH_DB_SELECT_1 */

            R2241_10_FETCH_DB_SELECT_1();

            /*" -5387- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -5388- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5389- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5391- MOVE ZEROS TO IMP-MORNATU OF DCLHIS-COBER-PROPOST */
                    _.Move(0, COBPRPVA.DCLHIS_COBER_PROPOST.IMP_MORNATU);

                    /*" -5392- ELSE */
                }
                else
                {


                    /*" -5392- PERFORM R2241_10_FETCH_DB_CLOSE_3 */

                    R2241_10_FETCH_DB_CLOSE_3();

                    /*" -5394- DISPLAY 'VA0601B - PROBLEMAS ACESSO HIS_COBER_PROPOST ' */
                    _.Display($"VA0601B - PROBLEMAS ACESSO HIS_COBER_PROPOST ");

                    /*" -5396- DISPLAY '          NUM_CERTIFICADO.......   ' PROPVA-NRCERTIF */
                    _.Display($"          NUM_CERTIFICADO.......   {PROPVA_NRCERTIF}");

                    /*" -5398- DISPLAY '          SQLCODE...............   ' SQLCODE */
                    _.Display($"          SQLCODE...............   {DB.SQLCODE}");

                    /*" -5399- GO TO R2241-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2241_99_SAIDA*/ //GOTO
                    return;

                    /*" -5400- END-IF */
                }


                /*" -5402- END-IF */
            }


            /*" -5405- ADD IMP-MORNATU OF DCLHIS-COBER-PROPOST TO AC-TOT-RISCO */
            WORK_AREA.AC_TOT_RISCO.Value = WORK_AREA.AC_TOT_RISCO + COBPRPVA.DCLHIS_COBER_PROPOST;

            /*" -5405- GO TO R2241-10-FETCH. */
            new Task(() => R2241_10_FETCH()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R2241-10-FETCH-DB-FETCH-1 */
        public void R2241_10_FETCH_DB_FETCH_1()
        {
            /*" -5356- EXEC SQL FETCH CRISCO INTO :PROPVA-NRCERTIF END-EXEC */

            if (CRISCO.Fetch())
            {
                _.Move(CRISCO.PROPVA_NRCERTIF, PROPVA_NRCERTIF);
            }

        }

        [StopWatch]
        /*" R2241-10-FETCH-DB-CLOSE-1 */
        public void R2241_10_FETCH_DB_CLOSE_1()
        {
            /*" -5360- EXEC SQL CLOSE CRISCO END-EXEC */

            CRISCO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2241_99_SAIDA*/

        [StopWatch]
        /*" R2241-10-FETCH-DB-SELECT-1 */
        public void R2241_10_FETCH_DB_SELECT_1()
        {
            /*" -5384- EXEC SQL SELECT IMP_MORNATU INTO :DCLHIS-COBER-PROPOST.IMP-MORNATU FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :PROPVA-NRCERTIF AND DATA_TERVIGENCIA = '9999-12-31' END-EXEC. */

            var r2241_10_FETCH_DB_SELECT_1_Query1 = new R2241_10_FETCH_DB_SELECT_1_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = R2241_10_FETCH_DB_SELECT_1_Query1.Execute(r2241_10_FETCH_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.IMP_MORNATU, COBPRPVA.DCLHIS_COBER_PROPOST.IMP_MORNATU);
            }


        }

        [StopWatch]
        /*" R2241-10-FETCH-DB-CLOSE-2 */
        public void R2241_10_FETCH_DB_CLOSE_2()
        {
            /*" -5363- EXEC SQL CLOSE CRISCO END-EXEC */

            CRISCO.Close();

        }

        [StopWatch]
        /*" R2242-00-SELECT-ACUM-RISCO-SECTION */
        private void R2242_00_SELECT_ACUM_RISCO_SECTION()
        {
            /*" -5415- MOVE '2242-00-SELECT-ACUM-RISCO     ' TO PARAGRAFO */
            _.Move("2242-00-SELECT-ACUM-RISCO     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5416- MOVE 'DECLARE CURSOR CRISCO1        ' TO COMANDO */
            _.Move("DECLARE CURSOR CRISCO1        ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5418- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5420- MOVE IMPMORNATU OF DCLPLANOS-VA-VGAP TO AC-TOT-RISCO */
            _.Move(PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU, WORK_AREA.AC_TOT_RISCO);

            /*" -5431- PERFORM R2242_00_SELECT_ACUM_RISCO_DB_DECLARE_1 */

            R2242_00_SELECT_ACUM_RISCO_DB_DECLARE_1();

            /*" -5434- MOVE 40 TO SII */
            _.Move(40, WS_HORAS.SII);

            /*" -5435- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -5435- PERFORM R2242_00_SELECT_ACUM_RISCO_DB_OPEN_1 */

            R2242_00_SELECT_ACUM_RISCO_DB_OPEN_1();

            /*" -5438- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -5439- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5439- PERFORM R2242_00_SELECT_ACUM_RISCO_DB_CLOSE_1 */

                R2242_00_SELECT_ACUM_RISCO_DB_CLOSE_1();

                /*" -5441- DISPLAY 'VA0601B - PROBLEMAS NO DECLARE PROPOSTAS_VA' */
                _.Display($"VA0601B - PROBLEMAS NO DECLARE PROPOSTAS_VA");

                /*" -5443- DISPLAY '          COD_PRODUTO...........   ' PROPOFID-COD-PRODUTO-SIVPF */
                _.Display($"          COD_PRODUTO...........   {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF}");

                /*" -5445- DISPLAY '          CPF_CLIENTE...........   ' CPF OF DCLPESSOA-FISICA */
                _.Display($"          CPF_CLIENTE...........   {PESFIS.DCLPESSOA_FISICA.CPF}");

                /*" -5447- DISPLAY '          NUM_APOLICE...........   ' PROPSSVD-NUM-APOLICE OF DCLPROP-SASSE-VIDA */
                _.Display($"          NUM_APOLICE...........   {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE}");

                /*" -5449- DISPLAY '          CODSUBES..............   ' PROPSSVD-COD-SUBGRUPO OF DCLPROP-SASSE-VIDA */
                _.Display($"          CODSUBES..............   {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO}");

                /*" -5450- MOVE SQLCODE TO WHOST-SQLCODE */
                _.Move(DB.SQLCODE, WS_HORAS.WHOST_SQLCODE);

                /*" -5452- DISPLAY '          SQLCODE...............   ' WHOST-SQLCODE */
                _.Display($"          SQLCODE...............   {WS_HORAS.WHOST_SQLCODE}");

                /*" -5453- GO TO R2242-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2242_99_SAIDA*/ //GOTO
                return;

                /*" -5455- END-IF */
            }


            /*" -5455- . */

            /*" -0- FLUXCONTROL_PERFORM R2242_10_FETCH */

            R2242_10_FETCH();

        }

        [StopWatch]
        /*" R2242-00-SELECT-ACUM-RISCO-DB-OPEN-1 */
        public void R2242_00_SELECT_ACUM_RISCO_DB_OPEN_1()
        {
            /*" -5435- EXEC SQL OPEN CRISCO1 END-EXEC */

            CRISCO1.Open();

        }

        [StopWatch]
        /*" R2243-00-SELECT-ACUM-RISCO-DB-DECLARE-1 */
        public void R2243_00_SELECT_ACUM_RISCO_DB_DECLARE_1()
        {
            /*" -5586- EXEC SQL DECLARE CRISCO2 CURSOR FOR SELECT A.NUM_CERTIFICADO FROM SEGUROS.PROPOSTAS_VA A, SEGUROS.CLIENTES B WHERE B.CGCCPF = :DCLPESSOA-FISICA.CPF AND B.COD_CLIENTE = A.COD_CLIENTE AND A.SIT_REGISTRO IN ( '0' , '1' , '3' , '6' , '7' , '8' , '9' , 'E' ) END-EXEC */
            CRISCO2 = new VA0601B_CRISCO2(true);
            string GetQuery_CRISCO2()
            {
                var query = @$"SELECT A.NUM_CERTIFICADO 
							FROM SEGUROS.PROPOSTAS_VA A
							, 
							SEGUROS.CLIENTES B 
							WHERE B.CGCCPF = '{PESFIS.DCLPESSOA_FISICA.CPF}' 
							AND B.COD_CLIENTE = A.COD_CLIENTE 
							AND A.SIT_REGISTRO IN ( '0'
							, '1'
							, '3'
							, '6'
							, '7'
							, '8'
							, '9'
							, 'E' )";

                return query;
            }
            CRISCO2.GetQueryEvent += GetQuery_CRISCO2;

        }

        [StopWatch]
        /*" R2242-00-SELECT-ACUM-RISCO-DB-CLOSE-1 */
        public void R2242_00_SELECT_ACUM_RISCO_DB_CLOSE_1()
        {
            /*" -5439- EXEC SQL CLOSE CRISCO1 END-EXEC */

            CRISCO1.Close();

        }

        [StopWatch]
        /*" R2241-10-FETCH-DB-CLOSE-3 */
        public void R2241_10_FETCH_DB_CLOSE_3()
        {
            /*" -5392- EXEC SQL CLOSE CRISCO END-EXEC */

            CRISCO.Close();

        }

        [StopWatch]
        /*" R2242-10-FETCH */
        private void R2242_10_FETCH(bool isPerform = false)
        {
            /*" -5461- MOVE 'FETCH  CRISCO1               ' TO COMANDO */
            _.Move("FETCH  CRISCO1               ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5464- PERFORM R2242_10_FETCH_DB_FETCH_1 */

            R2242_10_FETCH_DB_FETCH_1();

            /*" -5467- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5468- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5468- PERFORM R2242_10_FETCH_DB_CLOSE_1 */

                    R2242_10_FETCH_DB_CLOSE_1();

                    /*" -5470- GO TO R2242-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2242_99_SAIDA*/ //GOTO
                    return;

                    /*" -5471- ELSE */
                }
                else
                {


                    /*" -5471- PERFORM R2242_10_FETCH_DB_CLOSE_2 */

                    R2242_10_FETCH_DB_CLOSE_2();

                    /*" -5473- DISPLAY 'VA0601B - PROBLEMAS NO FETCH PROPOSTAS_VA' */
                    _.Display($"VA0601B - PROBLEMAS NO FETCH PROPOSTAS_VA");

                    /*" -5475- DISPLAY '          NUM_APOLICE...........   ' PROPSSVD-NUM-APOLICE OF DCLPROP-SASSE-VIDA */
                    _.Display($"          NUM_APOLICE...........   {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE}");

                    /*" -5477- DISPLAY '          CODSUBES..............   ' PROPSSVD-COD-SUBGRUPO OF DCLPROP-SASSE-VIDA */
                    _.Display($"          CODSUBES..............   {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO}");

                    /*" -5479- DISPLAY '          SQLCODE...............   ' SQLCODE */
                    _.Display($"          SQLCODE...............   {DB.SQLCODE}");

                    /*" -5480- GO TO R2242-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2242_99_SAIDA*/ //GOTO
                    return;

                    /*" -5481- END-IF */
                }


                /*" -5483- END-IF */
            }


            /*" -5496- PERFORM R2242_10_FETCH_DB_SELECT_1 */

            R2242_10_FETCH_DB_SELECT_1();

            /*" -5499- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5500- IF SQLCODE EQUAL 100 OR -811 */

                if (DB.SQLCODE.In("100", "-811"))
                {

                    /*" -5501- PERFORM R22421-00-ACUM-RISCO-PROPOSTA */

                    R22421_00_ACUM_RISCO_PROPOSTA_SECTION();

                    /*" -5502- ELSE */
                }
                else
                {


                    /*" -5503- DISPLAY 'VA0601B - PROBLEMAS ACESSO APOLICE_COBERTURAS' */
                    _.Display($"VA0601B - PROBLEMAS ACESSO APOLICE_COBERTURAS");

                    /*" -5505- DISPLAY '          NUM_CERTIFICADO.......   ' PROPVA-NRCERTIF */
                    _.Display($"          NUM_CERTIFICADO.......   {PROPVA_NRCERTIF}");

                    /*" -5507- DISPLAY '          SQLCODE...............   ' SQLCODE */
                    _.Display($"          SQLCODE...............   {DB.SQLCODE}");

                    /*" -5507- PERFORM R2242_10_FETCH_DB_CLOSE_3 */

                    R2242_10_FETCH_DB_CLOSE_3();

                    /*" -5509- GO TO R2242-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2242_99_SAIDA*/ //GOTO
                    return;

                    /*" -5510- END-IF */
                }


                /*" -5523- END-IF */
            }


            /*" -5524- ADD APOLCOB-IMPSEGURADO TO AC-TOT-RISCO */
            WORK_AREA.AC_TOT_RISCO.Value = WORK_AREA.AC_TOT_RISCO + APOLCOB_IMPSEGURADO;

            /*" -5524- GO TO R2242-10-FETCH. */
            new Task(() => R2242_10_FETCH()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R2242-10-FETCH-DB-FETCH-1 */
        public void R2242_10_FETCH_DB_FETCH_1()
        {
            /*" -5464- EXEC SQL FETCH CRISCO1 INTO :PROPVA-NRCERTIF END-EXEC */

            if (CRISCO1.Fetch())
            {
                _.Move(CRISCO1.PROPVA_NRCERTIF, PROPVA_NRCERTIF);
            }

        }

        [StopWatch]
        /*" R2242-10-FETCH-DB-CLOSE-1 */
        public void R2242_10_FETCH_DB_CLOSE_1()
        {
            /*" -5468- EXEC SQL CLOSE CRISCO1 END-EXEC */

            CRISCO1.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2242_99_SAIDA*/

        [StopWatch]
        /*" R2242-10-FETCH-DB-SELECT-1 */
        public void R2242_10_FETCH_DB_SELECT_1()
        {
            /*" -5496- EXEC SQL SELECT B.IMP_SEGURADA_IX, B.DATA_TERVIGENCIA INTO :APOLCOB-IMPSEGURADO, :APOLCOB-DT-TERVIGENCIA FROM SEGUROS.SEGURADOS_VGAP A, SEGUROS.APOLICE_COBERTURAS B WHERE A.NUM_CERTIFICADO = :PROPVA-NRCERTIF AND A.NUM_APOLICE = B.NUM_APOLICE AND A.NUM_ITEM = B.NUM_ITEM AND B.DATA_INIVIGENCIA <= :SISTEMAS-DATA-MOV-ABERTO AND B.DATA_TERVIGENCIA >= :SISTEMAS-DATA-MOV-ABERTO WITH UR END-EXEC */

            var r2242_10_FETCH_DB_SELECT_1_Query1 = new R2242_10_FETCH_DB_SELECT_1_Query1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = R2242_10_FETCH_DB_SELECT_1_Query1.Execute(r2242_10_FETCH_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLCOB_IMPSEGURADO, APOLCOB_IMPSEGURADO);
                _.Move(executed_1.APOLCOB_DT_TERVIGENCIA, APOLCOB_DT_TERVIGENCIA);
            }


        }

        [StopWatch]
        /*" R2242-10-FETCH-DB-CLOSE-2 */
        public void R2242_10_FETCH_DB_CLOSE_2()
        {
            /*" -5471- EXEC SQL CLOSE CRISCO1 END-EXEC */

            CRISCO1.Close();

        }

        [StopWatch]
        /*" R22421-00-ACUM-RISCO-PROPOSTA-SECTION */
        private void R22421_00_ACUM_RISCO_PROPOSTA_SECTION()
        {
            /*" -5534- MOVE 'R22421-00-ACUM-RISCO-PROPOSTA ' TO PARAGRAFO */
            _.Move("R22421-00-ACUM-RISCO-PROPOSTA ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5535- MOVE 'SELECT HISCOBPR      1        ' TO COMANDO */
            _.Move("SELECT HISCOBPR      1        ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5536- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5537- MOVE 41 TO SII */
            _.Move(41, WS_HORAS.SII);

            /*" -5539- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -5545- PERFORM R22421_00_ACUM_RISCO_PROPOSTA_DB_SELECT_1 */

            R22421_00_ACUM_RISCO_PROPOSTA_DB_SELECT_1();

            /*" -5549- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -5550- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -5552- MOVE IMPSEGUR OF DCLHIS-COBER-PROPOST TO APOLCOB-IMPSEGURADO */
                _.Move(COBPRPVA.DCLHIS_COBER_PROPOST.IMPSEGUR, APOLCOB_IMPSEGURADO);

                /*" -5553- ELSE */
            }
            else
            {


                /*" -5554- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5555- MOVE ZEROS TO APOLCOB-IMPSEGURADO */
                    _.Move(0, APOLCOB_IMPSEGURADO);

                    /*" -5556- ELSE */
                }
                else
                {


                    /*" -5557- DISPLAY 'VA0601B - PROBLEMAS ACESSO HIS_COBER_PROPOST' */
                    _.Display($"VA0601B - PROBLEMAS ACESSO HIS_COBER_PROPOST");

                    /*" -5559- DISPLAY '          NUM_CERTIFICADO.......   ' PROPVA-NRCERTIF */
                    _.Display($"          NUM_CERTIFICADO.......   {PROPVA_NRCERTIF}");

                    /*" -5561- DISPLAY '          SQLCODE...............   ' SQLCODE */
                    _.Display($"          SQLCODE...............   {DB.SQLCODE}");

                    /*" -5561- PERFORM R22421_00_ACUM_RISCO_PROPOSTA_DB_CLOSE_1 */

                    R22421_00_ACUM_RISCO_PROPOSTA_DB_CLOSE_1();

                    /*" -5563- END-IF */
                }


                /*" -5565- END-IF */
            }


            /*" -5565- . */

        }

        [StopWatch]
        /*" R22421-00-ACUM-RISCO-PROPOSTA-DB-SELECT-1 */
        public void R22421_00_ACUM_RISCO_PROPOSTA_DB_SELECT_1()
        {
            /*" -5545- EXEC SQL SELECT IMPSEGUR INTO :DCLHIS-COBER-PROPOST.IMPSEGUR FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :PROPVA-NRCERTIF AND DATA_TERVIGENCIA = '9999-12-31' END-EXEC. */

            var r22421_00_ACUM_RISCO_PROPOSTA_DB_SELECT_1_Query1 = new R22421_00_ACUM_RISCO_PROPOSTA_DB_SELECT_1_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = R22421_00_ACUM_RISCO_PROPOSTA_DB_SELECT_1_Query1.Execute(r22421_00_ACUM_RISCO_PROPOSTA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.IMPSEGUR, COBPRPVA.DCLHIS_COBER_PROPOST.IMPSEGUR);
            }


        }

        [StopWatch]
        /*" R22421-00-ACUM-RISCO-PROPOSTA-DB-CLOSE-1 */
        public void R22421_00_ACUM_RISCO_PROPOSTA_DB_CLOSE_1()
        {
            /*" -5561- EXEC SQL CLOSE CRISCO1 END-EXEC */

            CRISCO1.Close();

        }

        [StopWatch]
        /*" R2242-10-FETCH-DB-CLOSE-3 */
        public void R2242_10_FETCH_DB_CLOSE_3()
        {
            /*" -5507- EXEC SQL CLOSE CRISCO1 END-EXEC */

            CRISCO1.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R22421_99_SAIDA*/

        [StopWatch]
        /*" R2243-00-SELECT-ACUM-RISCO-SECTION */
        private void R2243_00_SELECT_ACUM_RISCO_SECTION()
        {
            /*" -5574- MOVE '2243-00-SELECT-ACUM-RISCO     ' TO PARAGRAFO. */
            _.Move("2243-00-SELECT-ACUM-RISCO     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5576- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5578- MOVE IMPMORNATU OF DCLPLANOS-VA-VGAP TO AC-TOT-RISCO */
            _.Move(PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU, WORK_AREA.AC_TOT_RISCO);

            /*" -5579- MOVE 'DECLARE CURSOR CRISCO2        ' TO COMANDO */
            _.Move("DECLARE CURSOR CRISCO2        ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5586- PERFORM R2243_00_SELECT_ACUM_RISCO_DB_DECLARE_1 */

            R2243_00_SELECT_ACUM_RISCO_DB_DECLARE_1();

            /*" -5589- MOVE 42 TO SII */
            _.Move(42, WS_HORAS.SII);

            /*" -5590- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -5590- PERFORM R2243_00_SELECT_ACUM_RISCO_DB_OPEN_1 */

            R2243_00_SELECT_ACUM_RISCO_DB_OPEN_1();

            /*" -5593- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -5594- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5594- PERFORM R2243_00_SELECT_ACUM_RISCO_DB_CLOSE_1 */

                R2243_00_SELECT_ACUM_RISCO_DB_CLOSE_1();

                /*" -5596- DISPLAY 'VA0601B - PROBLEMAS NO DECLARE PROPOSTAS_VA' */
                _.Display($"VA0601B - PROBLEMAS NO DECLARE PROPOSTAS_VA");

                /*" -5598- DISPLAY '          NOME_PRODUTO..........   ' PRODUVG-NOME-PRODUTO OF DCLPRODUTOS-VG */
                _.Display($"          NOME_PRODUTO..........   {PRODUVG.DCLPRODUTOS_VG.PRODUVG_NOME_PRODUTO}");

                /*" -5600- DISPLAY '          CPF_CLIENTE...........   ' CPF OF DCLPESSOA-FISICA */
                _.Display($"          CPF_CLIENTE...........   {PESFIS.DCLPESSOA_FISICA.CPF}");

                /*" -5602- DISPLAY '          NUM_APOLICE...........   ' PROPSSVD-NUM-APOLICE OF DCLPROP-SASSE-VIDA */
                _.Display($"          NUM_APOLICE...........   {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE}");

                /*" -5604- DISPLAY '          CODSUBES..............   ' PROPSSVD-COD-SUBGRUPO OF DCLPROP-SASSE-VIDA */
                _.Display($"          CODSUBES..............   {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO}");

                /*" -5605- MOVE SQLCODE TO WHOST-SQLCODE */
                _.Move(DB.SQLCODE, WS_HORAS.WHOST_SQLCODE);

                /*" -5607- DISPLAY '          SQLCODE...............   ' WHOST-SQLCODE */
                _.Display($"          SQLCODE...............   {WS_HORAS.WHOST_SQLCODE}");

                /*" -5608- GO TO R2243-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2243_99_SAIDA*/ //GOTO
                return;

                /*" -5610- END-IF */
            }


            /*" -5610- . */

            /*" -0- FLUXCONTROL_PERFORM R2243_10_FETCH */

            R2243_10_FETCH();

        }

        [StopWatch]
        /*" R2243-00-SELECT-ACUM-RISCO-DB-OPEN-1 */
        public void R2243_00_SELECT_ACUM_RISCO_DB_OPEN_1()
        {
            /*" -5590- EXEC SQL OPEN CRISCO2 END-EXEC */

            CRISCO2.Open();

        }

        [StopWatch]
        /*" R2244-00-SELECT-ACUM-RISCO-DB-DECLARE-1 */
        public void R2244_00_SELECT_ACUM_RISCO_DB_DECLARE_1()
        {
            /*" -5690- EXEC SQL DECLARE CRISCO3 CURSOR FOR SELECT A.NUM_APOLICE FROM SEGUROS.BILHETE A, SEGUROS.CLIENTES B WHERE B.CGCCPF = :DCLPESSOA-FISICA.CPF AND B.COD_CLIENTE = A.COD_CLIENTE AND A.SITUACAO = '9' END-EXEC. */
            CRISCO3 = new VA0601B_CRISCO3(true);
            string GetQuery_CRISCO3()
            {
                var query = @$"SELECT A.NUM_APOLICE 
							FROM SEGUROS.BILHETE A
							, 
							SEGUROS.CLIENTES B 
							WHERE 
							B.CGCCPF = '{PESFIS.DCLPESSOA_FISICA.CPF}' 
							AND B.COD_CLIENTE = A.COD_CLIENTE 
							AND A.SITUACAO = '9'";

                return query;
            }
            CRISCO3.GetQueryEvent += GetQuery_CRISCO3;

        }

        [StopWatch]
        /*" R2243-00-SELECT-ACUM-RISCO-DB-CLOSE-1 */
        public void R2243_00_SELECT_ACUM_RISCO_DB_CLOSE_1()
        {
            /*" -5594- EXEC SQL CLOSE CRISCO2 END-EXEC */

            CRISCO2.Close();

        }

        [StopWatch]
        /*" R2243-10-FETCH */
        private void R2243_10_FETCH(bool isPerform = false)
        {
            /*" -5616- MOVE '2243-10-FETCH                 ' TO PARAGRAFO. */
            _.Move("2243-10-FETCH                 ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5617- MOVE 'FETCH  CRISCO2               ' TO COMANDO. */
            _.Move("FETCH  CRISCO2               ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5620- PERFORM R2243_10_FETCH_DB_FETCH_1 */

            R2243_10_FETCH_DB_FETCH_1();

            /*" -5623- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5624- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5624- PERFORM R2243_10_FETCH_DB_CLOSE_1 */

                    R2243_10_FETCH_DB_CLOSE_1();

                    /*" -5626- GO TO R2243-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2243_99_SAIDA*/ //GOTO
                    return;

                    /*" -5627- ELSE */
                }
                else
                {


                    /*" -5627- PERFORM R2243_10_FETCH_DB_CLOSE_2 */

                    R2243_10_FETCH_DB_CLOSE_2();

                    /*" -5629- DISPLAY 'VA0601B - PROBLEMAS NO FETCH PROPOSTAS_VA' */
                    _.Display($"VA0601B - PROBLEMAS NO FETCH PROPOSTAS_VA");

                    /*" -5631- DISPLAY '          NUM_APOLICE...........   ' PROPSSVD-NUM-APOLICE OF DCLPROP-SASSE-VIDA */
                    _.Display($"          NUM_APOLICE...........   {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE}");

                    /*" -5633- DISPLAY '          CODSUBES..............   ' PROPSSVD-COD-SUBGRUPO OF DCLPROP-SASSE-VIDA */
                    _.Display($"          CODSUBES..............   {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO}");

                    /*" -5635- DISPLAY '          SQLCODE...............   ' SQLCODE */
                    _.Display($"          SQLCODE...............   {DB.SQLCODE}");

                    /*" -5636- GO TO R2243-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2243_99_SAIDA*/ //GOTO
                    return;

                    /*" -5637- END-IF */
                }


                /*" -5639- END-IF */
            }


            /*" -5640- MOVE 43 TO SII */
            _.Move(43, WS_HORAS.SII);

            /*" -5641- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -5648- PERFORM R2243_10_FETCH_DB_SELECT_1 */

            R2243_10_FETCH_DB_SELECT_1();

            /*" -5651- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -5652- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5653- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5655- MOVE ZEROS TO IMP-MORNATU OF DCLHIS-COBER-PROPOST */
                    _.Move(0, COBPRPVA.DCLHIS_COBER_PROPOST.IMP_MORNATU);

                    /*" -5656- ELSE */
                }
                else
                {


                    /*" -5656- PERFORM R2243_10_FETCH_DB_CLOSE_3 */

                    R2243_10_FETCH_DB_CLOSE_3();

                    /*" -5658- DISPLAY 'VA0601B - PROBLEMAS ACESSO HIS_COBER_PROPOST ' */
                    _.Display($"VA0601B - PROBLEMAS ACESSO HIS_COBER_PROPOST ");

                    /*" -5660- DISPLAY '          NUM_CERTIFICADO.......   ' PROPVA-NRCERTIF */
                    _.Display($"          NUM_CERTIFICADO.......   {PROPVA_NRCERTIF}");

                    /*" -5662- DISPLAY '          SQLCODE...............   ' SQLCODE */
                    _.Display($"          SQLCODE...............   {DB.SQLCODE}");

                    /*" -5663- GO TO R2243-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2243_99_SAIDA*/ //GOTO
                    return;

                    /*" -5664- END-IF */
                }


                /*" -5666- END-IF */
            }


            /*" -5669- ADD IMP-MORNATU OF DCLHIS-COBER-PROPOST TO AC-TOT-RISCO */
            WORK_AREA.AC_TOT_RISCO.Value = WORK_AREA.AC_TOT_RISCO + COBPRPVA.DCLHIS_COBER_PROPOST;

            /*" -5669- GO TO R2243-10-FETCH. */
            new Task(() => R2243_10_FETCH()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R2243-10-FETCH-DB-FETCH-1 */
        public void R2243_10_FETCH_DB_FETCH_1()
        {
            /*" -5620- EXEC SQL FETCH CRISCO2 INTO :PROPVA-NRCERTIF END-EXEC */

            if (CRISCO2.Fetch())
            {
                _.Move(CRISCO2.PROPVA_NRCERTIF, PROPVA_NRCERTIF);
            }

        }

        [StopWatch]
        /*" R2243-10-FETCH-DB-CLOSE-1 */
        public void R2243_10_FETCH_DB_CLOSE_1()
        {
            /*" -5624- EXEC SQL CLOSE CRISCO2 END-EXEC */

            CRISCO2.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2243_99_SAIDA*/

        [StopWatch]
        /*" R2243-10-FETCH-DB-SELECT-1 */
        public void R2243_10_FETCH_DB_SELECT_1()
        {
            /*" -5648- EXEC SQL SELECT IMP_MORNATU INTO :DCLHIS-COBER-PROPOST.IMP-MORNATU FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :PROPVA-NRCERTIF AND DATA_TERVIGENCIA = '9999-12-31' END-EXEC. */

            var r2243_10_FETCH_DB_SELECT_1_Query1 = new R2243_10_FETCH_DB_SELECT_1_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = R2243_10_FETCH_DB_SELECT_1_Query1.Execute(r2243_10_FETCH_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.IMP_MORNATU, COBPRPVA.DCLHIS_COBER_PROPOST.IMP_MORNATU);
            }


        }

        [StopWatch]
        /*" R2243-10-FETCH-DB-CLOSE-2 */
        public void R2243_10_FETCH_DB_CLOSE_2()
        {
            /*" -5627- EXEC SQL CLOSE CRISCO END-EXEC */

            CRISCO.Close();

        }

        [StopWatch]
        /*" R2244-00-SELECT-ACUM-RISCO-SECTION */
        private void R2244_00_SELECT_ACUM_RISCO_SECTION()
        {
            /*" -5679- MOVE '2244-00-SELECT-ACUM-RISCO     ' TO PARAGRAFO */
            _.Move("2244-00-SELECT-ACUM-RISCO     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5680- MOVE 'DECLARE CURSOR CRISCO3        ' TO COMANDO */
            _.Move("DECLARE CURSOR CRISCO3        ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5682- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5690- PERFORM R2244_00_SELECT_ACUM_RISCO_DB_DECLARE_1 */

            R2244_00_SELECT_ACUM_RISCO_DB_DECLARE_1();

            /*" -5693- MOVE 44 TO SII */
            _.Move(44, WS_HORAS.SII);

            /*" -5694- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -5694- PERFORM R2244_00_SELECT_ACUM_RISCO_DB_OPEN_1 */

            R2244_00_SELECT_ACUM_RISCO_DB_OPEN_1();

            /*" -5697- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -5698- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5698- PERFORM R2244_00_SELECT_ACUM_RISCO_DB_CLOSE_1 */

                R2244_00_SELECT_ACUM_RISCO_DB_CLOSE_1();

                /*" -5700- DISPLAY 'VA0601B - PROBLEMAS NO DECLARE BILHETE' */
                _.Display($"VA0601B - PROBLEMAS NO DECLARE BILHETE");

                /*" -5702- DISPLAY '          COD_PRODUTO...........   ' PROPOFID-COD-PRODUTO-SIVPF */
                _.Display($"          COD_PRODUTO...........   {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF}");

                /*" -5704- DISPLAY '          CPF_CLIENTE...........   ' CPF OF DCLPESSOA-FISICA */
                _.Display($"          CPF_CLIENTE...........   {PESFIS.DCLPESSOA_FISICA.CPF}");

                /*" -5706- DISPLAY '          NUM_APOLICE...........   ' PROPSSVD-NUM-APOLICE OF DCLPROP-SASSE-VIDA */
                _.Display($"          NUM_APOLICE...........   {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE}");

                /*" -5708- DISPLAY '          CODSUBES..............   ' PROPSSVD-COD-SUBGRUPO OF DCLPROP-SASSE-VIDA */
                _.Display($"          CODSUBES..............   {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO}");

                /*" -5709- MOVE SQLCODE TO WHOST-SQLCODE */
                _.Move(DB.SQLCODE, WS_HORAS.WHOST_SQLCODE);

                /*" -5711- DISPLAY '          SQLCODE...............   ' WHOST-SQLCODE */
                _.Display($"          SQLCODE...............   {WS_HORAS.WHOST_SQLCODE}");

                /*" -5712- GO TO R2244-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2244_99_SAIDA*/ //GOTO
                return;

                /*" -5714- END-IF */
            }


            /*" -5714- . */

            /*" -0- FLUXCONTROL_PERFORM R2244_10_FETCH */

            R2244_10_FETCH();

        }

        [StopWatch]
        /*" R2244-00-SELECT-ACUM-RISCO-DB-OPEN-1 */
        public void R2244_00_SELECT_ACUM_RISCO_DB_OPEN_1()
        {
            /*" -5694- EXEC SQL OPEN CRISCO3 END-EXEC */

            CRISCO3.Open();

        }

        [StopWatch]
        /*" R2300-00-TRATA-CLIENTES-DB-DECLARE-1 */
        public void R2300_00_TRATA_CLIENTES_DB_DECLARE_1()
        {
            /*" -5900- EXEC SQL DECLARE CCLIENTES CURSOR FOR SELECT COD_CLIENTE FROM SEGUROS.CLIENTES WHERE CGCCPF = :DCLPESSOA-FISICA.CPF AND DATA_NASCIMENTO = :DCLPESSOA-FISICA.DATA-NASCIMENTO AND NOME_RAZAO <> ' ' ORDER BY COD_CLIENTE DESC END-EXEC. */
            CCLIENTES = new VA0601B_CCLIENTES(true);
            string GetQuery_CCLIENTES()
            {
                var query = @$"SELECT COD_CLIENTE 
							FROM SEGUROS.CLIENTES 
							WHERE CGCCPF = '{PESFIS.DCLPESSOA_FISICA.CPF}' 
							AND DATA_NASCIMENTO = '{PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO}' 
							AND NOME_RAZAO <> ' ' 
							ORDER BY COD_CLIENTE DESC";

                return query;
            }
            CCLIENTES.GetQueryEvent += GetQuery_CCLIENTES;

        }

        [StopWatch]
        /*" R2244-00-SELECT-ACUM-RISCO-DB-CLOSE-1 */
        public void R2244_00_SELECT_ACUM_RISCO_DB_CLOSE_1()
        {
            /*" -5698- EXEC SQL CLOSE CRISCO3 END-EXEC */

            CRISCO3.Close();

        }

        [StopWatch]
        /*" R2243-10-FETCH-DB-CLOSE-3 */
        public void R2243_10_FETCH_DB_CLOSE_3()
        {
            /*" -5656- EXEC SQL CLOSE CRISCO2 END-EXEC */

            CRISCO2.Close();

        }

        [StopWatch]
        /*" R2244-10-FETCH */
        private void R2244_10_FETCH(bool isPerform = false)
        {
            /*" -5720- MOVE 'FETCH  CRISCO3               ' TO COMANDO */
            _.Move("FETCH  CRISCO3               ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5723- PERFORM R2244_10_FETCH_DB_FETCH_1 */

            R2244_10_FETCH_DB_FETCH_1();

            /*" -5726- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5727- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5727- PERFORM R2244_10_FETCH_DB_CLOSE_1 */

                    R2244_10_FETCH_DB_CLOSE_1();

                    /*" -5729- GO TO R2244-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2244_99_SAIDA*/ //GOTO
                    return;

                    /*" -5730- ELSE */
                }
                else
                {


                    /*" -5730- PERFORM R2244_10_FETCH_DB_CLOSE_2 */

                    R2244_10_FETCH_DB_CLOSE_2();

                    /*" -5732- DISPLAY 'VA0601B - PROBLEMAS NO FETCH BILHETE' */
                    _.Display($"VA0601B - PROBLEMAS NO FETCH BILHETE");

                    /*" -5734- DISPLAY '          NUM_APOLICE...........   ' PROPSSVD-NUM-APOLICE OF DCLPROP-SASSE-VIDA */
                    _.Display($"          NUM_APOLICE...........   {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE}");

                    /*" -5736- DISPLAY '          CODSUBES..............   ' PROPSSVD-COD-SUBGRUPO OF DCLPROP-SASSE-VIDA */
                    _.Display($"          CODSUBES..............   {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO}");

                    /*" -5738- DISPLAY '          SQLCODE...............   ' SQLCODE */
                    _.Display($"          SQLCODE...............   {DB.SQLCODE}");

                    /*" -5739- GO TO R2244-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2244_99_SAIDA*/ //GOTO
                    return;

                    /*" -5740- END-IF */
                }


                /*" -5742- END-IF */
            }


            /*" -5755- PERFORM R2244_10_FETCH_DB_SELECT_1 */

            R2244_10_FETCH_DB_SELECT_1();

            /*" -5758- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5759- IF SQLCODE EQUAL 100 OR -811 */

                if (DB.SQLCODE.In("100", "-811"))
                {

                    /*" -5760- MOVE ZEROS TO APOLCOB-IMPSEGURADO */
                    _.Move(0, APOLCOB_IMPSEGURADO);

                    /*" -5761- ELSE */
                }
                else
                {


                    /*" -5762- DISPLAY 'VA0601B - PROBLEMAS ACESSO APOLICE_COBERTURAS' */
                    _.Display($"VA0601B - PROBLEMAS ACESSO APOLICE_COBERTURAS");

                    /*" -5764- DISPLAY '          NUM_CERTIFICADO.......   ' PROPVA-NRCERTIF */
                    _.Display($"          NUM_CERTIFICADO.......   {PROPVA_NRCERTIF}");

                    /*" -5766- DISPLAY '          SQLCODE...............   ' SQLCODE */
                    _.Display($"          SQLCODE...............   {DB.SQLCODE}");

                    /*" -5766- PERFORM R2244_10_FETCH_DB_CLOSE_3 */

                    R2244_10_FETCH_DB_CLOSE_3();

                    /*" -5768- GO TO R2244-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2244_99_SAIDA*/ //GOTO
                    return;

                    /*" -5769- END-IF */
                }


                /*" -5770- END-IF */
            }


            /*" -5771- ADD APOLCOB-IMPSEGURADO TO AC-TOT-RISCO */
            WORK_AREA.AC_TOT_RISCO.Value = WORK_AREA.AC_TOT_RISCO + APOLCOB_IMPSEGURADO;

            /*" -5771- GO TO R2244-10-FETCH. */
            new Task(() => R2244_10_FETCH()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R2244-10-FETCH-DB-FETCH-1 */
        public void R2244_10_FETCH_DB_FETCH_1()
        {
            /*" -5723- EXEC SQL FETCH CRISCO3 INTO :BILHETE-NUM-APOLICE END-EXEC */

            if (CRISCO3.Fetch())
            {
                _.Move(CRISCO3.BILHETE_NUM_APOLICE, BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE);
            }

        }

        [StopWatch]
        /*" R2244-10-FETCH-DB-CLOSE-1 */
        public void R2244_10_FETCH_DB_CLOSE_1()
        {
            /*" -5727- EXEC SQL CLOSE CRISCO3 END-EXEC */

            CRISCO3.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2244_99_SAIDA*/

        [StopWatch]
        /*" R2244-10-FETCH-DB-SELECT-1 */
        public void R2244_10_FETCH_DB_SELECT_1()
        {
            /*" -5755- EXEC SQL SELECT B.IMP_SEGURADA_IX, B.DATA_TERVIGENCIA INTO :APOLCOB-IMPSEGURADO, :APOLCOB-DT-TERVIGENCIA FROM SEGUROS.ENDOSSOS A, SEGUROS.APOLICE_COBERTURAS B WHERE A.NUM_APOLICE = :BILHETE-NUM-APOLICE AND B.NUM_APOLICE = A.NUM_APOLICE AND B.NUM_ENDOSSO = A.NUM_ENDOSSO AND A.DATA_INIVIGENCIA <= :SISTEMAS-DATA-MOV-ABERTO AND A.DATA_TERVIGENCIA >= :SISTEMAS-DATA-MOV-ABERTO WITH UR END-EXEC */

            var r2244_10_FETCH_DB_SELECT_1_Query1 = new R2244_10_FETCH_DB_SELECT_1_Query1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                BILHETE_NUM_APOLICE = BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE.ToString(),
            };

            var executed_1 = R2244_10_FETCH_DB_SELECT_1_Query1.Execute(r2244_10_FETCH_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLCOB_IMPSEGURADO, APOLCOB_IMPSEGURADO);
                _.Move(executed_1.APOLCOB_DT_TERVIGENCIA, APOLCOB_DT_TERVIGENCIA);
            }


        }

        [StopWatch]
        /*" R2244-10-FETCH-DB-CLOSE-2 */
        public void R2244_10_FETCH_DB_CLOSE_2()
        {
            /*" -5730- EXEC SQL CLOSE CRISCO3 END-EXEC */

            CRISCO3.Close();

        }

        [StopWatch]
        /*" R2245-00-VERIFICA-ACUM-CPF-SECTION */
        private void R2245_00_VERIFICA_ACUM_CPF_SECTION()
        {
            /*" -5780- MOVE 'R2245-00-VERIFICA-ACUM-CPF  ' TO PARAGRAFO */
            _.Move("R2245-00-VERIFICA-ACUM-CPF  ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5782- MOVE 'R2245-00-VERIFICA-ACUM-CPF  ' TO COMANDO */
            _.Move("R2245-00-VERIFICA-ACUM-CPF  ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5784- DISPLAY PARAGRAFO ' >> ' IMPMORNATU OF DCLPLANOS-VA-VGAP */

            $"{AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO} >> {PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU}"
            .Display();

            /*" -5787- MOVE IMPMORNATU OF DCLPLANOS-VA-VGAP TO AC-TOT-ACUM-CPF */
            _.Move(PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU, WORK_AREA.AC_TOT_ACUM_CPF);

            /*" -5788- MOVE 'N' TO LK-GE051-TRACE */
            _.Move("N", SPGE051W.LK_GE051_TRACE);

            /*" -5790- MOVE CPF OF DCLPESSOA-FISICA TO LK-GE051-NUM-CPF-CNPJ */
            _.Move(PESFIS.DCLPESSOA_FISICA.CPF, SPGE051W.LK_GE051_NUM_CPF_CNPJ);

            /*" -5815- PERFORM R2245_00_VERIFICA_ACUM_CPF_DB_CALL_1 */

            R2245_00_VERIFICA_ACUM_CPF_DB_CALL_1();

            /*" -5818- IF SQLCODE NOT = 000 */

            if (DB.SQLCODE != 000)
            {

                /*" -5819- DISPLAY 'VA0601B - SQLCODE ERRO NA CHAMADA DA SPBGE051' */
                _.Display($"VA0601B - SQLCODE ERRO NA CHAMADA DA SPBGE051");

                /*" -5821- DISPLAY '          LK-GE051-NUM-CPF-CNPJ.  ' LK-GE051-NUM-CPF-CNPJ */
                _.Display($"          LK-GE051-NUM-CPF-CNPJ.  {SPGE051W.LK_GE051_NUM_CPF_CNPJ}");

                /*" -5823- DISPLAY '          LK-GE051-SQLCODE.....   ' LK-GE051-SQLCODE */
                _.Display($"          LK-GE051-SQLCODE.....   {SPGE051W.LK_GE051_SQLCODE}");

                /*" -5825- DISPLAY '          LK-GE051-NOM-TABELA...  ' LK-GE051-NOM-TABELA */
                _.Display($"          LK-GE051-NOM-TABELA...  {SPGE051W.LK_GE051_NOM_TABELA}");

                /*" -5827- DISPLAY '          LK-GE051-SQLERRMC.....  ' LK-GE051-SQLERRMC */
                _.Display($"          LK-GE051-SQLERRMC.....  {SPGE051W.LK_GE051_SQLERRMC}");

                /*" -5828- GO TO R2244-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2244_99_SAIDA*/ //GOTO
                return;

                /*" -5829- ELSE */
            }
            else
            {


                /*" -5830- IF LK-GE051-IND-ERRO NOT = 000 */

                if (SPGE051W.LK_GE051_IND_ERRO != 000)
                {

                    /*" -5831- DISPLAY 'VA0601B - ERRO NA CHAMADA DA SPBGE051' */
                    _.Display($"VA0601B - ERRO NA CHAMADA DA SPBGE051");

                    /*" -5833- DISPLAY '          LK-GE051-NUM-CPF-CNPJ.  ' LK-GE051-NUM-CPF-CNPJ */
                    _.Display($"          LK-GE051-NUM-CPF-CNPJ.  {SPGE051W.LK_GE051_NUM_CPF_CNPJ}");

                    /*" -5835- DISPLAY '          LK-GE051-SQLCODE.....   ' LK-GE051-SQLCODE */
                    _.Display($"          LK-GE051-SQLCODE.....   {SPGE051W.LK_GE051_SQLCODE}");

                    /*" -5837- DISPLAY '          LK-GE051-NOM-TABELA...  ' LK-GE051-NOM-TABELA */
                    _.Display($"          LK-GE051-NOM-TABELA...  {SPGE051W.LK_GE051_NOM_TABELA}");

                    /*" -5839- DISPLAY '          LK-GE051-SQLERRMC.....  ' LK-GE051-SQLERRMC */
                    _.Display($"          LK-GE051-SQLERRMC.....  {SPGE051W.LK_GE051_SQLERRMC}");

                    /*" -5840- GO TO R2244-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2244_99_SAIDA*/ //GOTO
                    return;

                    /*" -5841- END-IF */
                }


                /*" -5843- END-IF */
            }


            /*" -5846- COMPUTE AC-TOT-ACUM-CPF = LK-GE051-S-VLR-TOTAL-CNTR + AC-TOT-ACUM-CPF */
            WORK_AREA.AC_TOT_ACUM_CPF.Value = SPGE051W.LK_GE051_S_VLR_TOTAL_CNTR + WORK_AREA.AC_TOT_ACUM_CPF;

            /*" -5847- DISPLAY 'AC-TOT-ACUM-CPF >> ' AC-TOT-ACUM-CPF */
            _.Display($"AC-TOT-ACUM-CPF >> {WORK_AREA.AC_TOT_ACUM_CPF}");

            /*" -5847- . */

        }

        [StopWatch]
        /*" R2245-00-VERIFICA-ACUM-CPF-DB-CALL-1 */
        public void R2245_00_VERIFICA_ACUM_CPF_DB_CALL_1()
        {
            /*" -5815- EXEC SQL CALL SEGUROS.SPBGE051 ( :LK-GE051-TRACE , :LK-GE051-NUM-CPF-CNPJ , :LK-GE051-S-QTD-CNTR-PREST , :LK-GE051-S-VLR-IS-ACUM-PREST , :LK-GE051-S-DTH-CAD-PREST , :LK-GE051-S-QTD-CONTR-VIDA , :LK-GE051-S-VLR-IS-ACUM-VIDA , :LK-GE051-S-DTH-CAD-VIDA , :LK-GE051-S-QTD-CNTR-PREV , :LK-GE051-S-VLR-IS-ACUM-PREV , :LK-GE051-S-DTH-CAD-PREV , :LK-GE051-S-QTD-CONTR-HABIT , :LK-GE051-S-VLR-IS_ACUM-HABIT , :LK-GE051-S-DTH-CAD-HABIT , :LK-GE051-S-QTD-TOTAL-CNTR , :LK-GE051-S-VLR-TOTAL-CNTR , :LK-GE051-S-DTH-CADASTRAMENTO , :LK-GE051-IND-ERRO , :LK-GE051-MSG-ERRO , :LK-GE051-NOM-TABELA , :LK-GE051-SQLCODE , :LK-GE051-SQLERRMC ) END-EXEC */

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

        [StopWatch]
        /*" R2244-10-FETCH-DB-CLOSE-3 */
        public void R2244_10_FETCH_DB_CLOSE_3()
        {
            /*" -5766- EXEC SQL CLOSE CRISCO1 END-EXEC */

            CRISCO1.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2245_99_SAIDA*/

        [StopWatch]
        /*" R2250-00-SELECT-LIM-RENDA-SECTION */
        private void R2250_00_SELECT_LIM_RENDA_SECTION()
        {
            /*" -5857- MOVE 'R2250-00-SELECT-LIM-RENDA     ' TO PARAGRAFO. */
            _.Move("R2250-00-SELECT-LIM-RENDA     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5859- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5861- MOVE 'NAO' TO WS-TEM-ERRO-1855. */
            _.Move("NAO", WORK_AREA.WS_TEM_ERRO_1855);

            /*" -5862- IF PROPOFID-FAIXA-RENDA-IND NOT EQUAL SPACES */

            if (!PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_IND.IsEmpty())
            {

                /*" -5863- MOVE PROPOFID-FAIXA-RENDA-IND TO INDR */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_IND, WORK_AREA.INDR);

                /*" -5864- IF INDR > 0 AND INDR < 6 */

                if (WORK_AREA.INDR > 0 && WORK_AREA.INDR < 6)
                {

                    /*" -5867- IF IMPMORNATU OF DCLPLANOS-VA-VGAP GREATER VATBFREN-REND-IND-LIMITE(INDR) */

                    if (PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU > VATBFREN.VATBFREN_TABELA_FAIXA_RENDA.FILLER_4.VATBFREN_REND_IND_LIMITE[WORK_AREA.INDR])
                    {

                        /*" -5868- MOVE 1855 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                        _.Move(1855, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                        /*" -5876- PERFORM R1100-00-GRAVA-TAB-ERRO */

                        R1100_00_GRAVA_TAB_ERRO_SECTION();

                        /*" -5877- END-IF */
                    }


                    /*" -5878- END-IF */
                }


                /*" -5878- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2250_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-TRATA-CLIENTES-SECTION */
        private void R2300_00_TRATA_CLIENTES_SECTION()
        {
            /*" -5888- MOVE '2300-00-TRATA-CLIENTES       ' TO PARAGRAFO. */
            _.Move("2300-00-TRATA-CLIENTES       ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5889- MOVE 'DECLARE CURSOR CLIENTES      ' TO COMANDO. */
            _.Move("DECLARE CURSOR CLIENTES      ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5891- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5893- MOVE 0 TO WS-JA-E-CLIENTE. */
            _.Move(0, WORK_AREA.WS_JA_E_CLIENTE);

            /*" -5900- PERFORM R2300_00_TRATA_CLIENTES_DB_DECLARE_1 */

            R2300_00_TRATA_CLIENTES_DB_DECLARE_1();

            /*" -5903- MOVE 45 TO SII */
            _.Move(45, WS_HORAS.SII);

            /*" -5904- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -5904- PERFORM R2300_00_TRATA_CLIENTES_DB_OPEN_1 */

            R2300_00_TRATA_CLIENTES_DB_OPEN_1();

            /*" -5907- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -5908- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5909- DISPLAY 'VA0601B - PROBLEMAS NO DECLARE CLIENTES' */
                _.Display($"VA0601B - PROBLEMAS NO DECLARE CLIENTES");

                /*" -5911- DISPLAY '          NUM PROPOSTA..............   ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          NUM PROPOSTA..............   {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -5913- DISPLAY '          COD CLIENTE...............   ' COD-CLIENTE OF DCLCLIENTES */
                _.Display($"          COD CLIENTE...............   {CLIENTE.DCLCLIENTES.COD_CLIENTE}");

                /*" -5915- DISPLAY '          SQLCODE...................   ' SQLCODE */
                _.Display($"          SQLCODE...................   {DB.SQLCODE}");

                /*" -5917- MOVE 2 TO W-TRATA-CLIENTE. */
                _.Move(2, WORK_AREA.W_TRATA_CLIENTE);
            }


            /*" -5918- MOVE 'FETCH CLIENTES               ' TO COMANDO. */
            _.Move("FETCH CLIENTES               ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5921- PERFORM R2300_00_TRATA_CLIENTES_DB_FETCH_1 */

            R2300_00_TRATA_CLIENTES_DB_FETCH_1();

            /*" -5924- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5925- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5925- PERFORM R2300_00_TRATA_CLIENTES_DB_CLOSE_1 */

                    R2300_00_TRATA_CLIENTES_DB_CLOSE_1();

                    /*" -5928- PERFORM R2310-00-INSERT-CLIENTES */

                    R2310_00_INSERT_CLIENTES_SECTION();

                    /*" -5930- IF VIND-DATA-EXPEDICAO EQUAL ZEROS AND CLIENTE-INSERIDO */

                    if (VIND_DATA_EXPEDICAO == 00 && WORK_AREA.W_TRATA_CLIENTE["CLIENTE_INSERIDO"])
                    {

                        /*" -5931- PERFORM R2314-00-TRATA-GE-DOC */

                        R2314_00_TRATA_GE_DOC_SECTION();

                        /*" -5933- END-IF */
                    }


                    /*" -5934- MOVE 'I' TO WWORK-TIPO-MOVIMENTO */
                    _.Move("I", W_GECLIMOV.WWORK_TIPO_MOVIMENTO);

                    /*" -5935- GO TO R2300-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/ //GOTO
                    return;

                    /*" -5936- ELSE */
                }
                else
                {


                    /*" -5937- DISPLAY 'VA0601B - PROBLEMAS NO FETCH   CLIENTES' */
                    _.Display($"VA0601B - PROBLEMAS NO FETCH   CLIENTES");

                    /*" -5939- DISPLAY '          NUM PROPOSTA..............   ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          NUM PROPOSTA..............   {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -5941- DISPLAY '          COD CLIENTE...............   ' COD-CLIENTE OF DCLCLIENTES */
                    _.Display($"          COD CLIENTE...............   {CLIENTE.DCLCLIENTES.COD_CLIENTE}");

                    /*" -5943- DISPLAY '          SQLCODE...................   ' SQLCODE */
                    _.Display($"          SQLCODE...................   {DB.SQLCODE}");

                    /*" -5944- MOVE 2 TO W-TRATA-CLIENTE */
                    _.Move(2, WORK_AREA.W_TRATA_CLIENTE);

                    /*" -5945- ELSE */
                }

            }
            else
            {


                /*" -5947- PERFORM R2304-00-VERIFICA-ESPACO-NOME */

                R2304_00_VERIFICA_ESPACO_NOME_SECTION();

                /*" -5948- IF WHOST-CONT-ESPACO EQUAL ZEROS */

                if (WHOST_CONT_ESPACO == 00)
                {

                    /*" -5949- MOVE 1873 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(1873, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -5950- PERFORM R1100-00-GRAVA-TAB-ERRO */

                    R1100_00_GRAVA_TAB_ERRO_SECTION();

                    /*" -5951- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                    _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                    /*" -5953- END-IF */
                }


                /*" -5954- IF VIND-DATA-EXPEDICAO EQUAL ZEROS */

                if (VIND_DATA_EXPEDICAO == 00)
                {

                    /*" -5955- PERFORM R2314-00-TRATA-GE-DOC */

                    R2314_00_TRATA_GE_DOC_SECTION();

                    /*" -5956- END-IF */
                }


                /*" -5958- END-IF. */
            }


            /*" -5958- PERFORM R2300_00_TRATA_CLIENTES_DB_CLOSE_2 */

            R2300_00_TRATA_CLIENTES_DB_CLOSE_2();

            /*" -5960- MOVE 1 TO WS-JA-E-CLIENTE. */
            _.Move(1, WORK_AREA.WS_JA_E_CLIENTE);

        }

        [StopWatch]
        /*" R2300-00-TRATA-CLIENTES-DB-OPEN-1 */
        public void R2300_00_TRATA_CLIENTES_DB_OPEN_1()
        {
            /*" -5904- EXEC SQL OPEN CCLIENTES END-EXEC. */

            CCLIENTES.Open();

        }

        [StopWatch]
        /*" R3110-00-DECLARE-VGPLARAMCOB-DB-DECLARE-1 */
        public void R3110_00_DECLARE_VGPLARAMCOB_DB_DECLARE_1()
        {
            /*" -7710- EXEC SQL DECLARE VGPLARAMC CURSOR FOR SELECT NUM_RAMO, NUM_COBERTURA, QTD_COBERTURA, VLR_IMP_SEGURADA, VLR_CUSTO, VLR_PREMIO FROM SEGUROS.VG_PLANO_RAMO_COB WHERE NUM_APOLICE = :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE AND CODSUBES = :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO AND OPCAO_COBER = :DCLPROPOSTA-FIDELIZ.PROPOFID-OPCAO-COBER AND DTINIVIG <= :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO AND DTTERVIG >= :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO AND IDADE_INICIAL <= :WHOST-IDADE AND IDADE_FINAL >= :WHOST-IDADE AND PERIPGTO = :DCLPRODUTOS-VG.PRODUVG-PERI-PAGAMENTO ORDER BY NUM_RAMO, NUM_COBERTURA END-EXEC. */
            VGPLARAMC = new VA0601B_VGPLARAMC(true);
            string GetQuery_VGPLARAMC()
            {
                var query = @$"SELECT NUM_RAMO
							, 
							NUM_COBERTURA
							, 
							QTD_COBERTURA
							, 
							VLR_IMP_SEGURADA
							, 
							VLR_CUSTO
							, 
							VLR_PREMIO 
							FROM SEGUROS.VG_PLANO_RAMO_COB 
							WHERE NUM_APOLICE = 
							'{PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE}' 
							AND CODSUBES = 
							'{PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO}' 
							AND OPCAO_COBER = 
							'{PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER}' 
							AND DTINIVIG <= 
							'{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND DTTERVIG >= 
							'{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND IDADE_INICIAL <= '{WHOST_IDADE}' 
							AND IDADE_FINAL >= '{WHOST_IDADE}' 
							AND PERIPGTO = 
							'{PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO}' 
							ORDER BY NUM_RAMO
							, 
							NUM_COBERTURA";

                return query;
            }
            VGPLARAMC.GetQueryEvent += GetQuery_VGPLARAMC;

        }

        [StopWatch]
        /*" R2300-00-TRATA-CLIENTES-DB-FETCH-1 */
        public void R2300_00_TRATA_CLIENTES_DB_FETCH_1()
        {
            /*" -5921- EXEC SQL FETCH CCLIENTES INTO :DCLCLIENTES.COD-CLIENTE END-EXEC. */

            if (CCLIENTES.Fetch())
            {
                _.Move(CCLIENTES.DCLCLIENTES_COD_CLIENTE, CLIENTE.DCLCLIENTES.COD_CLIENTE);
            }

        }

        [StopWatch]
        /*" R2300-00-TRATA-CLIENTES-DB-CLOSE-1 */
        public void R2300_00_TRATA_CLIENTES_DB_CLOSE_1()
        {
            /*" -5925- EXEC SQL CLOSE CCLIENTES END-EXEC */

            CCLIENTES.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-TRATA-CLIENTES-DB-CLOSE-2 */
        public void R2300_00_TRATA_CLIENTES_DB_CLOSE_2()
        {
            /*" -5958- EXEC SQL CLOSE CCLIENTES END-EXEC. */

            CCLIENTES.Close();

        }

        [StopWatch]
        /*" R2304-00-VERIFICA-ESPACO-NOME-SECTION */
        private void R2304_00_VERIFICA_ESPACO_NOME_SECTION()
        {
            /*" -5970- MOVE 'R0911-00-VERIFICA-ESPACO-NOME' TO PARAGRAFO. */
            _.Move("R0911-00-VERIFICA-ESPACO-NOME", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5971- MOVE 'SELECT RCAPS FILTRO          ' TO COMANDO. */
            _.Move("SELECT RCAPS FILTRO          ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5973- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5981- PERFORM R2304_00_VERIFICA_ESPACO_NOME_DB_SELECT_1 */

            R2304_00_VERIFICA_ESPACO_NOME_DB_SELECT_1();

            /*" -5984- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5985- DISPLAY 'VA0601B - PROBLEMAS NO VERIFICA ESPACO NOME ' */
                _.Display($"VA0601B - PROBLEMAS NO VERIFICA ESPACO NOME ");

                /*" -5987- DISPLAY '          COD_CLIENTE            .. ' COD-CLIENTE OF DCLCLIENTES */
                _.Display($"          COD_CLIENTE            .. {CLIENTE.DCLCLIENTES.COD_CLIENTE}");

                /*" -5989- DISPLAY '          SQLCODE.................. ' SQLCODE */
                _.Display($"          SQLCODE.................. {DB.SQLCODE}");

                /*" -5990- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -5992- END-IF */
            }


            /*" -5992- . */

        }

        [StopWatch]
        /*" R2304-00-VERIFICA-ESPACO-NOME-DB-SELECT-1 */
        public void R2304_00_VERIFICA_ESPACO_NOME_DB_SELECT_1()
        {
            /*" -5981- EXEC SQL SELECT LENGTH(TRIM(NOME_RAZAO)) - LENGTH(REPLACE(TRIM(NOME_RAZAO), ' ' , '' )), NOME_RAZAO INTO :WHOST-CONT-ESPACO, :WHOST-NOME-CLIENTE FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :DCLCLIENTES.COD-CLIENTE END-EXEC. */

            var r2304_00_VERIFICA_ESPACO_NOME_DB_SELECT_1_Query1 = new R2304_00_VERIFICA_ESPACO_NOME_DB_SELECT_1_Query1()
            {
                COD_CLIENTE = CLIENTE.DCLCLIENTES.COD_CLIENTE.ToString(),
            };

            var executed_1 = R2304_00_VERIFICA_ESPACO_NOME_DB_SELECT_1_Query1.Execute(r2304_00_VERIFICA_ESPACO_NOME_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_CONT_ESPACO, WHOST_CONT_ESPACO);
                _.Move(executed_1.WHOST_NOME_CLIENTE, WHOST_NOME_CLIENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2304_99_SAIDA*/

        [StopWatch]
        /*" R2305-00-VALIDA-NOME-CLIENTE */
        private void R2305_00_VALIDA_NOME_CLIENTE(bool isPerform = false)
        {
            /*" -6002- MOVE 'R2305-00-VALIDA-NOME-CLIENTE ' TO PARAGRAFO. */
            _.Move("R2305-00-VALIDA-NOME-CLIENTE ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6006- MOVE 'VALIDAR NOME DO CLIENTE      ' TO COMANDO. */
            _.Move("VALIDAR NOME DO CLIENTE      ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6007- IF PESSOA-NOME-PESSOA EQUAL SPACES OR LOW-VALUES */

            if (PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA.IsLowValues())
            {

                /*" -6008- MOVE 1873 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1873, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -6009- PERFORM R1100-00-GRAVA-TAB-ERRO */

                R1100_00_GRAVA_TAB_ERRO_SECTION();

                /*" -6010- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -6011- GO TO R2305-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2305_99_SAIDA*/ //GOTO
                return;

                /*" -6014- END-IF */
            }


            /*" -6016- IF PESSOA-NOME-PESSOA EQUAL 'NOME' OR PESSOA-NOME-PESSOA EQUAL 'NAONAO' */

            if (PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA == "NOME" || PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA == "NAONAO")
            {

                /*" -6017- MOVE 1873 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1873, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -6018- PERFORM R1100-00-GRAVA-TAB-ERRO */

                R1100_00_GRAVA_TAB_ERRO_SECTION();

                /*" -6019- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -6020- GO TO R2305-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2305_99_SAIDA*/ //GOTO
                return;

                /*" -6024- END-IF */
            }


            /*" -6025- MOVE PESSOA-NOME-PESSOA TO WS-TRATA-NOME */
            _.Move(PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA, WORK_AREA.WS_TRATA_NOME);

            /*" -6027- IF WS-NOM-1A-POSICAO EQUAL WS-NOM-2A-POSICAO AND WS-NOM-1A-POSICAO EQUAL WS-NOM-3A-POSICAO */

            if (WORK_AREA.WS_TRATA_NOM.WS_NOM_1A_POSICAO == WORK_AREA.WS_TRATA_NOM.WS_NOM_2A_POSICAO && WORK_AREA.WS_TRATA_NOM.WS_NOM_1A_POSICAO == WORK_AREA.WS_TRATA_NOM.WS_NOM_3A_POSICAO)
            {

                /*" -6028- MOVE 1873 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1873, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -6029- PERFORM R1100-00-GRAVA-TAB-ERRO */

                R1100_00_GRAVA_TAB_ERRO_SECTION();

                /*" -6030- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -6031- GO TO R2305-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2305_99_SAIDA*/ //GOTO
                return;

                /*" -6034- END-IF */
            }


            /*" -6040- IF WS-NOM-1A-POSICAO EQUAL WS-NOM-4A-POSICAO AND WS-NOM-1A-POSICAO EQUAL WS-NOM-7A-POSICAO AND WS-NOM-2A-POSICAO EQUAL WS-NOM-5A-POSICAO AND WS-NOM-2A-POSICAO EQUAL WS-NOM-8A-POSICAO AND WS-NOM-3A-POSICAO EQUAL WS-NOM-6A-POSICAO AND WS-NOM-3A-POSICAO EQUAL WS-NOM-9A-POSICAO */

            if (WORK_AREA.WS_TRATA_NOM.WS_NOM_1A_POSICAO == WORK_AREA.WS_TRATA_NOM.WS_NOM_4A_POSICAO && WORK_AREA.WS_TRATA_NOM.WS_NOM_1A_POSICAO == WORK_AREA.WS_TRATA_NOM.WS_NOM_7A_POSICAO && WORK_AREA.WS_TRATA_NOM.WS_NOM_2A_POSICAO == WORK_AREA.WS_TRATA_NOM.WS_NOM_5A_POSICAO && WORK_AREA.WS_TRATA_NOM.WS_NOM_2A_POSICAO == WORK_AREA.WS_TRATA_NOM.WS_NOM_8A_POSICAO && WORK_AREA.WS_TRATA_NOM.WS_NOM_3A_POSICAO == WORK_AREA.WS_TRATA_NOM.WS_NOM_6A_POSICAO && WORK_AREA.WS_TRATA_NOM.WS_NOM_3A_POSICAO == WORK_AREA.WS_TRATA_NOM.WS_NOM_9A_POSICAO)
            {

                /*" -6041- MOVE 1873 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1873, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -6042- PERFORM R1100-00-GRAVA-TAB-ERRO */

                R1100_00_GRAVA_TAB_ERRO_SECTION();

                /*" -6043- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -6044- GO TO R2305-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2305_99_SAIDA*/ //GOTO
                return;

                /*" -6047- END-IF */
            }


            /*" -6049- MOVE ZEROS TO WS-CONTA-BRC */
            _.Move(0, WS_CONTA_BRC);

            /*" -6052- INSPECT FUNCTION REVERSE(WS-TRATA-NOME) TALLYING WS-CONTA-BRC FOR LEADING SPACES */
            WS_CONTA_BRC.Value = WORK_AREA.WS_TRATA_NOME.ToString().Reverse().TakeWhile(x => x == ' ').Count();

            /*" -6055- COMPUTE WS-CONTA-BRC EQUAL LENGTH OF WS-TRATA-NOME - WS-CONTA-BRC */
            WS_CONTA_BRC.Value = WORK_AREA.WS_TRATA_NOME.Pic.Length - WS_CONTA_BRC;

            /*" -6056- IF WS-CONTA-BRC <= 3 */

            if (WS_CONTA_BRC <= 3)
            {

                /*" -6057- MOVE 1873 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1873, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -6058- PERFORM R1100-00-GRAVA-TAB-ERRO */

                R1100_00_GRAVA_TAB_ERRO_SECTION();

                /*" -6059- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -6060- GO TO R2305-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2305_99_SAIDA*/ //GOTO
                return;

                /*" -6063- END-IF */
            }


            /*" -6064- MOVE 1 TO WS-POSICAO */
            _.Move(1, WS_POSICAO);

            /*" -6066- SET WS-NAO-ACHOU TO TRUE */
            WS_ENCONTROU_LETRA["WS_NAO_ACHOU"] = true;

            /*" -6067- PERFORM UNTIL WS-POSICAO > 40 OR WS-SIM-ACHOU */

            while (!(WS_POSICAO > 40 || WS_ENCONTROU_LETRA["WS_SIM_ACHOU"]))
            {

                /*" -6074- IF WS-TRATA-NOME(WS-POSICAO:1) EQUAL '0' OR '1' OR '2' OR '3' OR '4' OR '5' OR '6' OR '7' OR '8' OR '9' OR '0' OR '/' OR '\' OR '?' OR '!' OR '*' OR '+' OR '�' OR '`' OR ',' OR '=' OR '_' OR '[' OR ']' OR '{' OR '}' OR '<' OR '>' OR '(' OR ')' OR '%' OR '$' OR '#' OR 'a' OR '�' OR ';' OR ':' OR '|' OR '^' OR '~' OR '"' */

                if (WORK_AREA.WS_TRATA_NOME.Substring(WS_POSICAO, 1).In("0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "/", "\\", "?", "!", "*", "+", "�", "`", " , ", "=", "_".ToString(), "[".ToString(), "]", "{", "}", "<", ">", " ( ".ToString(), " )", "%", "$", "#", "a", "�", ";", ":", "|", "^", "~", "\""))
                {

                    /*" -6075- SET WS-SIM-ACHOU TO TRUE */
                    WS_ENCONTROU_LETRA["WS_SIM_ACHOU"] = true;

                    /*" -6076- ELSE */
                }
                else
                {


                    /*" -6077- ADD 1 TO WS-POSICAO */
                    WS_POSICAO.Value = WS_POSICAO + 1;

                    /*" -6079- END-IF */
                }


                /*" -6081- END-PERFORM */
            }

            /*" -6082- IF WS-SIM-ACHOU */

            if (WS_ENCONTROU_LETRA["WS_SIM_ACHOU"])
            {

                /*" -6083- MOVE 1873 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1873, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -6084- PERFORM R1100-00-GRAVA-TAB-ERRO */

                R1100_00_GRAVA_TAB_ERRO_SECTION();

                /*" -6085- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -6086- GO TO R2305-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2305_99_SAIDA*/ //GOTO
                return;

                /*" -6088- END-IF */
            }


            /*" -6088- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2305_99_SAIDA*/

        [StopWatch]
        /*" R2310-00-INSERT-CLIENTES-SECTION */
        private void R2310_00_INSERT_CLIENTES_SECTION()
        {
            /*" -6098- MOVE '2310-00-INSERT-CLIENTES      ' TO PARAGRAFO. */
            _.Move("2310-00-INSERT-CLIENTES      ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6099- MOVE 'INSERT CLIENTES              ' TO COMANDO. */
            _.Move("INSERT CLIENTES              ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6101- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6104- PERFORM R2305-00-VALIDA-NOME-CLIENTE THRU R2305-99-SAIDA */

            R2305_00_VALIDA_NOME_CLIENTE();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R2305_99_SAIDA*/


            /*" -6105- ADD 1 TO NUM-CLIENTE OF DCLNUMERO-OUTROS. */
            NUMOUTRO.DCLNUMERO_OUTROS.NUM_CLIENTE.Value = NUMOUTRO.DCLNUMERO_OUTROS.NUM_CLIENTE + 1;

            /*" -6108- MOVE NUM-CLIENTE OF DCLNUMERO-OUTROS TO COD-CLIENTE OF DCLCLIENTES. */
            _.Move(NUMOUTRO.DCLNUMERO_OUTROS.NUM_CLIENTE, CLIENTE.DCLCLIENTES.COD_CLIENTE);

            /*" -6109- MOVE 46 TO SII */
            _.Move(46, WS_HORAS.SII);

            /*" -6110- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -6148- PERFORM R2310_00_INSERT_CLIENTES_DB_INSERT_1 */

            R2310_00_INSERT_CLIENTES_DB_INSERT_1();

            /*" -6150- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -6151- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6152- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_SQLCODE);

                /*" -6153- DISPLAY 'VA0601B - PROBLEMAS NO INSERT DA V0CLIENTES' */
                _.Display($"VA0601B - PROBLEMAS NO INSERT DA V0CLIENTES");

                /*" -6155- DISPLAY '          NUM PROPOSTA..............       ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          NUM PROPOSTA..............       {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -6157- DISPLAY '          COD CLIENTE...............       ' COD-CLIENTE OF DCLCLIENTES */
                _.Display($"          COD CLIENTE...............       {CLIENTE.DCLCLIENTES.COD_CLIENTE}");

                /*" -6159- DISPLAY '          SQLCODE...................       ' WS-SQLCODE */
                _.Display($"          SQLCODE...................       {WS_SQLCODE}");

                /*" -6159- MOVE 2 TO W-TRATA-CLIENTE. */
                _.Move(2, WORK_AREA.W_TRATA_CLIENTE);
            }


        }

        [StopWatch]
        /*" R2310-00-INSERT-CLIENTES-DB-INSERT-1 */
        public void R2310_00_INSERT_CLIENTES_DB_INSERT_1()
        {
            /*" -6148- EXEC SQL INSERT INTO SEGUROS.CLIENTES (COD_CLIENTE, NOME_RAZAO, TIPO_PESSOA, CGCCPF, SIT_REGISTRO, DATA_NASCIMENTO, COD_EMPRESA, COD_PORTE_EMP, COD_NATUREZA_ATIV, COD_RAMO_ATIVIDADE, COD_ATIVIDADE, IDE_SEXO, ESTADO_CIVIL, COD_GRD_GRUPO_CBO, COD_SUBGRUPO_CBO, COD_GRUPO_BASE_CBO, COD_SUBGR_BASE_CBO) VALUES (:DCLCLIENTES.COD-CLIENTE, :DCLPESSOA.PESSOA-NOME-PESSOA, 'F' , :DCLPESSOA-FISICA.CPF, '0' , :DCLPESSOA-FISICA.DATA-NASCIMENTO :VIND-DATA-NASCIMENTO, 0, NULL, NULL, NULL, NULL, :DCLPESSOA-FISICA.SEXO, :DCLPESSOA-FISICA.ESTADO-CIVIL, NULL, NULL, NULL, NULL) END-EXEC. */

            var r2310_00_INSERT_CLIENTES_DB_INSERT_1_Insert1 = new R2310_00_INSERT_CLIENTES_DB_INSERT_1_Insert1()
            {
                COD_CLIENTE = CLIENTE.DCLCLIENTES.COD_CLIENTE.ToString(),
                PESSOA_NOME_PESSOA = PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA.ToString(),
                CPF = PESFIS.DCLPESSOA_FISICA.CPF.ToString(),
                DATA_NASCIMENTO = PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO.ToString(),
                VIND_DATA_NASCIMENTO = VIND_DATA_NASCIMENTO.ToString(),
                SEXO = PESFIS.DCLPESSOA_FISICA.SEXO.ToString(),
                ESTADO_CIVIL = PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL.ToString(),
            };

            R2310_00_INSERT_CLIENTES_DB_INSERT_1_Insert1.Execute(r2310_00_INSERT_CLIENTES_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2310_99_SAIDA*/

        [StopWatch]
        /*" R2314-00-TRATA-GE-DOC-SECTION */
        private void R2314_00_TRATA_GE_DOC_SECTION()
        {
            /*" -6169- MOVE 'R2314-00-TRATA-GE-DOC        ' TO PARAGRAFO. */
            _.Move("R2314-00-TRATA-GE-DOC        ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6170- MOVE 'SELECT GE_DOC_CLIENTE        ' TO COMANDO. */
            _.Move("SELECT GE_DOC_CLIENTE        ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6172- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6186- PERFORM R2314_00_TRATA_GE_DOC_DB_SELECT_1 */

            R2314_00_TRATA_GE_DOC_DB_SELECT_1();

            /*" -6188- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6189- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -6190- PERFORM R2315-00-INSERT-GE-DOC */

                    R2315_00_INSERT_GE_DOC_SECTION();

                    /*" -6191- ELSE */
                }
                else
                {


                    /*" -6192- DISPLAY 'VA0601B - PROBLEMA SELECT  GE_DOC_CLIENTES' */
                    _.Display($"VA0601B - PROBLEMA SELECT  GE_DOC_CLIENTES");

                    /*" -6194- DISPLAY '          NUM PROPOSTA....................... ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          NUM PROPOSTA....................... {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -6196- DISPLAY '          COD CLIENTE........................ ' COD-CLIENTE OF DCLCLIENTES */
                    _.Display($"          COD CLIENTE........................ {CLIENTE.DCLCLIENTES.COD_CLIENTE}");

                    /*" -6198- DISPLAY '          SQLCODE............................ ' SQLCODE */
                    _.Display($"          SQLCODE............................ {DB.SQLCODE}");

                    /*" -6199- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -6200- END-IF */
                }


                /*" -6201- ELSE */
            }
            else
            {


                /*" -6202- PERFORM R2316-00-UPDATE-GE-DOC */

                R2316_00_UPDATE_GE_DOC_SECTION();

                /*" -6202- END-IF. */
            }


        }

        [StopWatch]
        /*" R2314-00-TRATA-GE-DOC-DB-SELECT-1 */
        public void R2314_00_TRATA_GE_DOC_DB_SELECT_1()
        {
            /*" -6186- EXEC SQL SELECT COD_CLIENTE , COD_IDENTIFICACAO , NOM_ORGAO_EXP , DTH_EXPEDICAO , COD_UF INTO :GEDOCCLI-COD-CLIENTE , :GEDOCCLI-COD-IDENTIFICACAO , :GEDOCCLI-NOM-ORGAO-EXP , :GEDOCCLI-DTH-EXPEDICAO , :GEDOCCLI-COD-UF:VIND-UF-EXPEDIDORA FROM SEGUROS.GE_DOC_CLIENTE WHERE COD_CLIENTE = :DCLCLIENTES.COD-CLIENTE WITH UR END-EXEC */

            var r2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1 = new R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1()
            {
                COD_CLIENTE = CLIENTE.DCLCLIENTES.COD_CLIENTE.ToString(),
            };

            var executed_1 = R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1.Execute(r2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GEDOCCLI_COD_CLIENTE, GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_CLIENTE);
                _.Move(executed_1.GEDOCCLI_COD_IDENTIFICACAO, GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_IDENTIFICACAO);
                _.Move(executed_1.GEDOCCLI_NOM_ORGAO_EXP, GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_NOM_ORGAO_EXP);
                _.Move(executed_1.GEDOCCLI_DTH_EXPEDICAO, GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_DTH_EXPEDICAO);
                _.Move(executed_1.GEDOCCLI_COD_UF, GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_UF);
                _.Move(executed_1.VIND_UF_EXPEDIDORA, VIND_UF_EXPEDIDORA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2314_99_SAIDA*/

        [StopWatch]
        /*" R2315-00-INSERT-GE-DOC-SECTION */
        private void R2315_00_INSERT_GE_DOC_SECTION()
        {
            /*" -6213- MOVE '2315-00-INSERT-GE-DOC        ' TO PARAGRAFO. */
            _.Move("2315-00-INSERT-GE-DOC        ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6214- MOVE 'INSERT GE-DOC                ' TO COMANDO. */
            _.Move("INSERT GE-DOC                ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6216- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6219- MOVE COD-CLIENTE OF DCLCLIENTES TO GEDOCCLI-COD-CLIENTE. */
            _.Move(CLIENTE.DCLCLIENTES.COD_CLIENTE, GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_CLIENTE);

            /*" -6222- MOVE NUM-IDENTIDADE OF DCLPESSOA-FISICA TO GEDOCCLI-COD-IDENTIFICACAO */
            _.Move(PESFIS.DCLPESSOA_FISICA.NUM_IDENTIDADE, GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_IDENTIFICACAO);

            /*" -6225- MOVE ORGAO-EXPEDIDOR OF DCLPESSOA-FISICA TO W-NOM-ORGAO-EXP */
            _.Move(PESFIS.DCLPESSOA_FISICA.ORGAO_EXPEDIDOR, WORK_AREA.W_NOM_ORGAO_EXP);

            /*" -6228- MOVE W-ORGAO-EXPEDIDOR TO GEDOCCLI-NOM-ORGAO-EXP */
            _.Move(WORK_AREA.FILLER_20.W_ORGAO_EXPEDIDOR, GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_NOM_ORGAO_EXP);

            /*" -6231- MOVE DATA-EXPEDICAO OF DCLPESSOA-FISICA TO GEDOCCLI-DTH-EXPEDICAO. */
            _.Move(PESFIS.DCLPESSOA_FISICA.DATA_EXPEDICAO, GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_DTH_EXPEDICAO);

            /*" -6232- IF VIND-UF-EXPEDIDORA NOT LESS ZEROS */

            if (VIND_UF_EXPEDIDORA >= 00)
            {

                /*" -6235- MOVE UF-EXPEDIDORA OF DCLPESSOA-FISICA TO GEDOCCLI-COD-UF. */
                _.Move(PESFIS.DCLPESSOA_FISICA.UF_EXPEDIDORA, GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_UF);
            }


            /*" -6236- MOVE 47 TO SII */
            _.Move(47, WS_HORAS.SII);

            /*" -6237- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -6250- PERFORM R2315_00_INSERT_GE_DOC_DB_INSERT_1 */

            R2315_00_INSERT_GE_DOC_DB_INSERT_1();

            /*" -6253- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -6255- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL -803 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
            {

                /*" -6256- DISPLAY 'VA0601B - PROBLEMAS INSERT GE-DOC-CLIENTE ' */
                _.Display($"VA0601B - PROBLEMAS INSERT GE-DOC-CLIENTE ");

                /*" -6258- DISPLAY '          NUM PROPOSTA....................... ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          NUM PROPOSTA....................... {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -6260- DISPLAY '          COD CLIENTE........................ ' COD-CLIENTE OF DCLCLIENTES */
                _.Display($"          COD CLIENTE........................ {CLIENTE.DCLCLIENTES.COD_CLIENTE}");

                /*" -6262- DISPLAY '          SQLCODE............................ ' SQLCODE */
                _.Display($"          SQLCODE............................ {DB.SQLCODE}");

                /*" -6262- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2315-00-INSERT-GE-DOC-DB-INSERT-1 */
        public void R2315_00_INSERT_GE_DOC_DB_INSERT_1()
        {
            /*" -6250- EXEC SQL INSERT INTO SEGUROS.GE_DOC_CLIENTE (COD_CLIENTE , COD_IDENTIFICACAO , NOM_ORGAO_EXP , DTH_EXPEDICAO , COD_UF) VALUES (:GEDOCCLI-COD-CLIENTE , :GEDOCCLI-COD-IDENTIFICACAO, :GEDOCCLI-NOM-ORGAO-EXP , :GEDOCCLI-DTH-EXPEDICAO , :GEDOCCLI-COD-UF:VIND-UF-EXPEDIDORA) END-EXEC. */

            var r2315_00_INSERT_GE_DOC_DB_INSERT_1_Insert1 = new R2315_00_INSERT_GE_DOC_DB_INSERT_1_Insert1()
            {
                GEDOCCLI_COD_CLIENTE = GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_CLIENTE.ToString(),
                GEDOCCLI_COD_IDENTIFICACAO = GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_IDENTIFICACAO.ToString(),
                GEDOCCLI_NOM_ORGAO_EXP = GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_NOM_ORGAO_EXP.ToString(),
                GEDOCCLI_DTH_EXPEDICAO = GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_DTH_EXPEDICAO.ToString(),
                GEDOCCLI_COD_UF = GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_UF.ToString(),
                VIND_UF_EXPEDIDORA = VIND_UF_EXPEDIDORA.ToString(),
            };

            R2315_00_INSERT_GE_DOC_DB_INSERT_1_Insert1.Execute(r2315_00_INSERT_GE_DOC_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2315_99_SAIDA*/

        [StopWatch]
        /*" R2316-00-UPDATE-GE-DOC-SECTION */
        private void R2316_00_UPDATE_GE_DOC_SECTION()
        {
            /*" -6272- MOVE '2316-00-UPDATE-GE-DOC        ' TO PARAGRAFO. */
            _.Move("2316-00-UPDATE-GE-DOC        ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6273- MOVE 'UPDATE GE-DOC                ' TO COMANDO. */
            _.Move("UPDATE GE-DOC                ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6275- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6278- MOVE COD-CLIENTE OF DCLCLIENTES TO GEDOCCLI-COD-CLIENTE. */
            _.Move(CLIENTE.DCLCLIENTES.COD_CLIENTE, GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_CLIENTE);

            /*" -6281- MOVE NUM-IDENTIDADE OF DCLPESSOA-FISICA TO GEDOCCLI-COD-IDENTIFICACAO */
            _.Move(PESFIS.DCLPESSOA_FISICA.NUM_IDENTIDADE, GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_IDENTIFICACAO);

            /*" -6284- MOVE ORGAO-EXPEDIDOR OF DCLPESSOA-FISICA TO W-NOM-ORGAO-EXP */
            _.Move(PESFIS.DCLPESSOA_FISICA.ORGAO_EXPEDIDOR, WORK_AREA.W_NOM_ORGAO_EXP);

            /*" -6287- MOVE W-ORGAO-EXPEDIDOR TO GEDOCCLI-NOM-ORGAO-EXP. */
            _.Move(WORK_AREA.FILLER_20.W_ORGAO_EXPEDIDOR, GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_NOM_ORGAO_EXP);

            /*" -6290- MOVE DATA-EXPEDICAO OF DCLPESSOA-FISICA TO GEDOCCLI-DTH-EXPEDICAO. */
            _.Move(PESFIS.DCLPESSOA_FISICA.DATA_EXPEDICAO, GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_DTH_EXPEDICAO);

            /*" -6291- IF VIND-UF-EXPEDIDORA NOT LESS ZEROS */

            if (VIND_UF_EXPEDIDORA >= 00)
            {

                /*" -6294- MOVE UF-EXPEDIDORA OF DCLPESSOA-FISICA TO GEDOCCLI-COD-UF. */
                _.Move(PESFIS.DCLPESSOA_FISICA.UF_EXPEDIDORA, GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_UF);
            }


            /*" -6302- PERFORM R2316_00_UPDATE_GE_DOC_DB_UPDATE_1 */

            R2316_00_UPDATE_GE_DOC_DB_UPDATE_1();

            /*" -6305- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6306- DISPLAY 'VA0601B - PROBLEMAS UPDATE DA GE_DOC_CLIENTES' */
                _.Display($"VA0601B - PROBLEMAS UPDATE DA GE_DOC_CLIENTES");

                /*" -6308- DISPLAY '          NUM PROPOSTA....................... ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          NUM PROPOSTA....................... {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -6310- DISPLAY '          COD CLIENTE........................ ' COD-CLIENTE OF DCLCLIENTES */
                _.Display($"          COD CLIENTE........................ {CLIENTE.DCLCLIENTES.COD_CLIENTE}");

                /*" -6312- DISPLAY '          SQLCODE............................ ' SQLCODE */
                _.Display($"          SQLCODE............................ {DB.SQLCODE}");

                /*" -6312- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2316-00-UPDATE-GE-DOC-DB-UPDATE-1 */
        public void R2316_00_UPDATE_GE_DOC_DB_UPDATE_1()
        {
            /*" -6302- EXEC SQL UPDATE SEGUROS.GE_DOC_CLIENTE SET COD_IDENTIFICACAO = :GEDOCCLI-COD-IDENTIFICACAO , NOM_ORGAO_EXP = :GEDOCCLI-NOM-ORGAO-EXP , DTH_EXPEDICAO = :GEDOCCLI-DTH-EXPEDICAO , COD_UF = :GEDOCCLI-COD-UF :VIND-UF-EXPEDIDORA WHERE COD_CLIENTE = :GEDOCCLI-COD-CLIENTE END-EXEC. */

            var r2316_00_UPDATE_GE_DOC_DB_UPDATE_1_Update1 = new R2316_00_UPDATE_GE_DOC_DB_UPDATE_1_Update1()
            {
                GEDOCCLI_COD_UF = GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_UF.ToString(),
                VIND_UF_EXPEDIDORA = VIND_UF_EXPEDIDORA.ToString(),
                GEDOCCLI_COD_IDENTIFICACAO = GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_IDENTIFICACAO.ToString(),
                GEDOCCLI_NOM_ORGAO_EXP = GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_NOM_ORGAO_EXP.ToString(),
                GEDOCCLI_DTH_EXPEDICAO = GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_DTH_EXPEDICAO.ToString(),
                GEDOCCLI_COD_CLIENTE = GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_CLIENTE.ToString(),
            };

            R2316_00_UPDATE_GE_DOC_DB_UPDATE_1_Update1.Execute(r2316_00_UPDATE_GE_DOC_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2316_99_SAIDA*/

        [StopWatch]
        /*" R2350-00-TRATA-ERRO-1864-SECTION */
        private void R2350_00_TRATA_ERRO_1864_SECTION()
        {
            /*" -6322- MOVE 'R2350-00-TRATA-ERRO-1864     ' TO PARAGRAFO. */
            _.Move("R2350-00-TRATA-ERRO-1864     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6323- MOVE 'SELECT COUNT                 ' TO COMANDO. */
            _.Move("SELECT COUNT                 ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6325- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6335- PERFORM R2350_00_TRATA_ERRO_1864_DB_SELECT_1 */

            R2350_00_TRATA_ERRO_1864_DB_SELECT_1();

            /*" -6338- IF WS-COUNT GREATER ZEROS */

            if (WS_COUNT > 00)
            {

                /*" -6339- GO TO R2350-ERRO */

                R2350_ERRO(); //GOTO
                return;

                /*" -6340- ELSE */
            }
            else
            {


                /*" -6341- GO TO R2350-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2350_99_SAIDA*/ //GOTO
                return;

                /*" -6341- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R2350_ERRO */

            R2350_ERRO();

        }

        [StopWatch]
        /*" R2350-00-TRATA-ERRO-1864-DB-SELECT-1 */
        public void R2350_00_TRATA_ERRO_1864_DB_SELECT_1()
        {
            /*" -6335- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :WS-COUNT FROM SEGUROS.PROPOSTAS_VA A, SEGUROS.SINISTRO_MESTRE B, SEGUROS.CLIENTES C WHERE A.NUM_CERTIFICADO = B.NUM_CERTIFICADO AND A.COD_CLIENTE = C.COD_CLIENTE AND C.CGCCPF = :DCLPESSOA-FISICA.CPF WITH UR END-EXEC. */

            var r2350_00_TRATA_ERRO_1864_DB_SELECT_1_Query1 = new R2350_00_TRATA_ERRO_1864_DB_SELECT_1_Query1()
            {
                CPF = PESFIS.DCLPESSOA_FISICA.CPF.ToString(),
            };

            var executed_1 = R2350_00_TRATA_ERRO_1864_DB_SELECT_1_Query1.Execute(r2350_00_TRATA_ERRO_1864_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_COUNT, WS_COUNT);
            }


        }

        [StopWatch]
        /*" R2350-ERRO */
        private void R2350_ERRO(bool isPerform = false)
        {
            /*" -6346- MOVE 1864 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
            _.Move(1864, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

            /*" -6346- PERFORM R1100-00-GRAVA-TAB-ERRO. */

            R1100_00_GRAVA_TAB_ERRO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2350_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-TRATA-ENDERECOS-SECTION */
        private void R2400_00_TRATA_ENDERECOS_SECTION()
        {
            /*" -6356- MOVE '2400-00-TRATA-ENDERECO       ' TO PARAGRAFO. */
            _.Move("2400-00-TRATA-ENDERECO       ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6357- MOVE 'SELECT                       ' TO COMANDO. */
            _.Move("SELECT                       ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6359- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6360- MOVE 48 TO SII */
            _.Move(48, WS_HORAS.SII);

            /*" -6361- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -6362- IF WS-JA-E-CLIENTE EQUAL 1 */

            if (WORK_AREA.WS_JA_E_CLIENTE == 1)
            {

                /*" -6363- MOVE 'SELECT SEGUROS.ENDERECOS     ' TO COMANDO */
                _.Move("SELECT SEGUROS.ENDERECOS     ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -6383- PERFORM R2400_00_TRATA_ENDERECOS_DB_SELECT_1 */

                R2400_00_TRATA_ENDERECOS_DB_SELECT_1();

                /*" -6385- PERFORM R9100-00-TERMINO */

                R9100_00_TERMINO_SECTION();

                /*" -6386- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -6387- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -6388- PERFORM R2420-00-INSERT-ENDERECOS */

                        R2420_00_INSERT_ENDERECOS_SECTION();

                        /*" -6389- MOVE 'I' TO WWORK-TIPO-MOVIMENTO */
                        _.Move("I", W_GECLIMOV.WWORK_TIPO_MOVIMENTO);

                        /*" -6390- ELSE */
                    }
                    else
                    {


                        /*" -6391- IF SQLCODE EQUAL -811 */

                        if (DB.SQLCODE == -811)
                        {

                            /*" -6392- CONTINUE */

                            /*" -6393- ELSE */
                        }
                        else
                        {


                            /*" -6394- DISPLAY 'PROBLEMAS ACESSO ENDERECOS     ' */
                            _.Display($"PROBLEMAS ACESSO ENDERECOS     ");

                            /*" -6395- GO TO R9999-00-ROT-ERRO */

                            R9999_00_ROT_ERRO_SECTION(); //GOTO
                            return;

                            /*" -6396- END-IF */
                        }


                        /*" -6397- END-IF */
                    }


                    /*" -6398- ELSE */
                }
                else
                {


                    /*" -6399- CONTINUE */

                    /*" -6400- ELSE */
                }

            }
            else
            {


                /*" -6401- PERFORM R2420-00-INSERT-ENDERECOS */

                R2420_00_INSERT_ENDERECOS_SECTION();

                /*" -6401- MOVE 'I' TO WWORK-TIPO-MOVIMENTO. */
                _.Move("I", W_GECLIMOV.WWORK_TIPO_MOVIMENTO);
            }


        }

        [StopWatch]
        /*" R2400-00-TRATA-ENDERECOS-DB-SELECT-1 */
        public void R2400_00_TRATA_ENDERECOS_DB_SELECT_1()
        {
            /*" -6383- EXEC SQL SELECT OCORR_ENDERECO, ENDERECO, BAIRRO, CIDADE, SIGLA_UF, CEP INTO :DCLENDERECOS.ENDERECO-OCORR-ENDERECO, :DCLENDERECOS.ENDERECO-ENDERECO, :DCLENDERECOS.ENDERECO-BAIRRO, :DCLENDERECOS.ENDERECO-CIDADE, :DCLENDERECOS.ENDERECO-SIGLA-UF, :DCLENDERECOS.ENDERECO-CEP FROM SEGUROS.ENDERECOS WHERE COD_CLIENTE = :DCLCLIENTES.COD-CLIENTE AND ENDERECO = :DCLPESSOA-ENDERECO.ENDERECO AND BAIRRO = :DCLPESSOA-ENDERECO.BAIRRO AND CIDADE = :DCLPESSOA-ENDERECO.CIDADE AND SIGLA_UF = :DCLPESSOA-ENDERECO.SIGLA-UF AND CEP = :DCLPESSOA-ENDERECO.CEP END-EXEC */

            var r2400_00_TRATA_ENDERECOS_DB_SELECT_1_Query1 = new R2400_00_TRATA_ENDERECOS_DB_SELECT_1_Query1()
            {
                ENDERECO = PESENDER.DCLPESSOA_ENDERECO.ENDERECO.ToString(),
                SIGLA_UF = PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF.ToString(),
                BAIRRO = PESENDER.DCLPESSOA_ENDERECO.BAIRRO.ToString(),
                CIDADE = PESENDER.DCLPESSOA_ENDERECO.CIDADE.ToString(),
                COD_CLIENTE = CLIENTE.DCLCLIENTES.COD_CLIENTE.ToString(),
                CEP = PESENDER.DCLPESSOA_ENDERECO.CEP.ToString(),
            };

            var executed_1 = R2400_00_TRATA_ENDERECOS_DB_SELECT_1_Query1.Execute(r2400_00_TRATA_ENDERECOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDERECO_OCORR_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO);
                _.Move(executed_1.ENDERECO_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO);
                _.Move(executed_1.ENDERECO_BAIRRO, ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO);
                _.Move(executed_1.ENDERECO_CIDADE, ENDERECO.DCLENDERECOS.ENDERECO_CIDADE);
                _.Move(executed_1.ENDERECO_SIGLA_UF, ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);
                _.Move(executed_1.ENDERECO_CEP, ENDERECO.DCLENDERECOS.ENDERECO_CEP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R2420-00-INSERT-ENDERECOS-SECTION */
        private void R2420_00_INSERT_ENDERECOS_SECTION()
        {
            /*" -6412- MOVE 'R2420-00-INSERT-ENDERECOS' TO PARAGRAFO */
            _.Move("R2420-00-INSERT-ENDERECOS", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6413- MOVE 'SELECT MAX OCORR ENDERECO' TO COMANDO */
            _.Move("SELECT MAX OCORR ENDERECO", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6415- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6416- IF END-CORRES-CADASTRADO OR DEMAIS-END-CADASTRADO */

            if (WORK_AREA.W_ENDERECO["END_CORRES_CADASTRADO"] || WORK_AREA.W_ENDERECO["DEMAIS_END_CADASTRADO"])
            {

                /*" -6418- PERFORM R2450-00-VALIDA-ENDERECO THRU R2450-99-SAIDA */

                R2450_00_VALIDA_ENDERECO();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/


                /*" -6420- END-IF */
            }


            /*" -6421- MOVE 49 TO SII */
            _.Move(49, WS_HORAS.SII);

            /*" -6422- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -6427- PERFORM R2420_00_INSERT_ENDERECOS_DB_SELECT_1 */

            R2420_00_INSERT_ENDERECOS_DB_SELECT_1();

            /*" -6430- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -6431- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6432- DISPLAY 'PROBLEMAS NO MAX ENDERECOS              ' */
                _.Display($"PROBLEMAS NO MAX ENDERECOS              ");

                /*" -6434- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -6437- ADD 1 TO ENDERECO-OCORR-ENDERECO OF DCLENDERECOS. */
            ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO.Value = ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO + 1;

            /*" -6438- MOVE '2420-00-INSERT-ENDERECOS     ' TO PARAGRAFO. */
            _.Move("2420-00-INSERT-ENDERECOS     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6440- MOVE 'INSERT ENDERECOS             ' TO COMANDO. */
            _.Move("INSERT ENDERECOS             ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6441- MOVE 50 TO SII */
            _.Move(50, WS_HORAS.SII);

            /*" -6443- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -6461- PERFORM R2420_00_INSERT_ENDERECOS_DB_INSERT_1 */

            R2420_00_INSERT_ENDERECOS_DB_INSERT_1();

            /*" -6464- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -6465- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6466- DISPLAY 'PROBLEMAS NO INSERT A ENDERECOS         ' */
                _.Display($"PROBLEMAS NO INSERT A ENDERECOS         ");

                /*" -6466- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2420-00-INSERT-ENDERECOS-DB-SELECT-1 */
        public void R2420_00_INSERT_ENDERECOS_DB_SELECT_1()
        {
            /*" -6427- EXEC SQL SELECT VALUE (MAX(OCORR_ENDERECO),0) INTO :DCLENDERECOS.ENDERECO-OCORR-ENDERECO FROM SEGUROS.ENDERECOS WHERE COD_CLIENTE = :DCLCLIENTES.COD-CLIENTE END-EXEC */

            var r2420_00_INSERT_ENDERECOS_DB_SELECT_1_Query1 = new R2420_00_INSERT_ENDERECOS_DB_SELECT_1_Query1()
            {
                COD_CLIENTE = CLIENTE.DCLCLIENTES.COD_CLIENTE.ToString(),
            };

            var executed_1 = R2420_00_INSERT_ENDERECOS_DB_SELECT_1_Query1.Execute(r2420_00_INSERT_ENDERECOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDERECO_OCORR_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO);
            }


        }

        [StopWatch]
        /*" R2420-00-INSERT-ENDERECOS-DB-INSERT-1 */
        public void R2420_00_INSERT_ENDERECOS_DB_INSERT_1()
        {
            /*" -6461- EXEC SQL INSERT INTO SEGUROS.ENDERECOS VALUES (:DCLCLIENTES.COD-CLIENTE, 2, :DCLENDERECOS.ENDERECO-OCORR-ENDERECO, :DCLPESSOA-ENDERECO.ENDERECO, :DCLPESSOA-ENDERECO.BAIRRO, :DCLPESSOA-ENDERECO.CIDADE, :DCLPESSOA-ENDERECO.SIGLA-UF, :DCLPESSOA-ENDERECO.CEP, :WHOST-DDD, :WHOST-FONE, :WHOST-FAX, :WHOST-TELEX, '0' , NULL , NULL) END-EXEC. */

            var r2420_00_INSERT_ENDERECOS_DB_INSERT_1_Insert1 = new R2420_00_INSERT_ENDERECOS_DB_INSERT_1_Insert1()
            {
                COD_CLIENTE = CLIENTE.DCLCLIENTES.COD_CLIENTE.ToString(),
                ENDERECO_OCORR_ENDERECO = ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO.ToString(),
                ENDERECO = PESENDER.DCLPESSOA_ENDERECO.ENDERECO.ToString(),
                BAIRRO = PESENDER.DCLPESSOA_ENDERECO.BAIRRO.ToString(),
                CIDADE = PESENDER.DCLPESSOA_ENDERECO.CIDADE.ToString(),
                SIGLA_UF = PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF.ToString(),
                CEP = PESENDER.DCLPESSOA_ENDERECO.CEP.ToString(),
                WHOST_DDD = WHOST_DDD.ToString(),
                WHOST_FONE = WHOST_FONE.ToString(),
                WHOST_FAX = WHOST_FAX.ToString(),
                WHOST_TELEX = WHOST_TELEX.ToString(),
            };

            R2420_00_INSERT_ENDERECOS_DB_INSERT_1_Insert1.Execute(r2420_00_INSERT_ENDERECOS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2420_99_SAIDA*/

        [StopWatch]
        /*" R2450-00-VALIDA-ENDERECO */
        private void R2450_00_VALIDA_ENDERECO(bool isPerform = false)
        {
            /*" -6477- MOVE 'R2450-00-VALIDA-ENDERECO' TO PARAGRAFO */
            _.Move("R2450-00-VALIDA-ENDERECO", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6481- MOVE 'VALIDA DODOS DE ENDERECO' TO COMANDO */
            _.Move("VALIDA DODOS DE ENDERECO", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6483- IF ENDERECO OF DCLPESSOA-ENDERECO EQUAL SPACES OR LOW-VALUES */

            if (PESENDER.DCLPESSOA_ENDERECO.ENDERECO.IsLowValues())
            {

                /*" -6484- MOVE 1872 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1872, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -6485- PERFORM R1100-00-GRAVA-TAB-ERRO */

                R1100_00_GRAVA_TAB_ERRO_SECTION();

                /*" -6486- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -6487- GO TO R2450-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/ //GOTO
                return;

                /*" -6490- END-IF */
            }


            /*" -6493- IF ENDERECO OF DCLPESSOA-ENDERECO EQUAL 'ENDERECO' OR ENDERECO OF DCLPESSOA-ENDERECO EQUAL 'ENDERE�O' OR ENDERECO OF DCLPESSOA-ENDERECO EQUAL 'NAONAO' */

            if (PESENDER.DCLPESSOA_ENDERECO.ENDERECO == "ENDERECO" || PESENDER.DCLPESSOA_ENDERECO.ENDERECO == "ENDERE�O" || PESENDER.DCLPESSOA_ENDERECO.ENDERECO == "NAONAO")
            {

                /*" -6494- MOVE 1872 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1872, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -6495- PERFORM R1100-00-GRAVA-TAB-ERRO */

                R1100_00_GRAVA_TAB_ERRO_SECTION();

                /*" -6496- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -6497- GO TO R2450-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/ //GOTO
                return;

                /*" -6501- END-IF */
            }


            /*" -6503- MOVE ENDERECO OF DCLPESSOA-ENDERECO TO WS-TRATA-ENDERECO */
            _.Move(PESENDER.DCLPESSOA_ENDERECO.ENDERECO, WORK_AREA.WS_TRATA_ENDERECO);

            /*" -6505- IF WS-END-1A-POSICAO EQUAL WS-END-2A-POSICAO AND WS-END-1A-POSICAO EQUAL WS-END-3A-POSICAO */

            if (WORK_AREA.WS_TRATA_END.WS_END_1A_POSICAO == WORK_AREA.WS_TRATA_END.WS_END_2A_POSICAO && WORK_AREA.WS_TRATA_END.WS_END_1A_POSICAO == WORK_AREA.WS_TRATA_END.WS_END_3A_POSICAO)
            {

                /*" -6506- MOVE 1872 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1872, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -6507- PERFORM R1100-00-GRAVA-TAB-ERRO */

                R1100_00_GRAVA_TAB_ERRO_SECTION();

                /*" -6508- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -6509- GO TO R2450-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/ //GOTO
                return;

                /*" -6512- END-IF */
            }


            /*" -6518- IF WS-END-1A-POSICAO EQUAL WS-END-4A-POSICAO AND WS-END-1A-POSICAO EQUAL WS-END-7A-POSICAO AND WS-END-2A-POSICAO EQUAL WS-END-5A-POSICAO AND WS-END-2A-POSICAO EQUAL WS-END-8A-POSICAO AND WS-END-3A-POSICAO EQUAL WS-END-6A-POSICAO AND WS-END-3A-POSICAO EQUAL WS-END-9A-POSICAO */

            if (WORK_AREA.WS_TRATA_END.WS_END_1A_POSICAO == WORK_AREA.WS_TRATA_END.WS_END_4A_POSICAO && WORK_AREA.WS_TRATA_END.WS_END_1A_POSICAO == WORK_AREA.WS_TRATA_END.WS_END_7A_POSICAO && WORK_AREA.WS_TRATA_END.WS_END_2A_POSICAO == WORK_AREA.WS_TRATA_END.WS_END_5A_POSICAO && WORK_AREA.WS_TRATA_END.WS_END_2A_POSICAO == WORK_AREA.WS_TRATA_END.WS_END_8A_POSICAO && WORK_AREA.WS_TRATA_END.WS_END_3A_POSICAO == WORK_AREA.WS_TRATA_END.WS_END_6A_POSICAO && WORK_AREA.WS_TRATA_END.WS_END_3A_POSICAO == WORK_AREA.WS_TRATA_END.WS_END_9A_POSICAO)
            {

                /*" -6519- MOVE 1872 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1872, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -6520- PERFORM R1100-00-GRAVA-TAB-ERRO */

                R1100_00_GRAVA_TAB_ERRO_SECTION();

                /*" -6521- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -6522- GO TO R2450-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/ //GOTO
                return;

                /*" -6525- END-IF */
            }


            /*" -6527- MOVE ZEROS TO WS-CONTA-BRC */
            _.Move(0, WS_CONTA_BRC);

            /*" -6530- INSPECT FUNCTION REVERSE(WS-TRATA-ENDERECO) TALLYING WS-CONTA-BRC FOR LEADING SPACES */
            WS_CONTA_BRC.Value = WORK_AREA.WS_TRATA_ENDERECO.ToString().Reverse().TakeWhile(x => x == ' ').Count();

            /*" -6533- COMPUTE WS-CONTA-BRC EQUAL LENGTH OF WS-TRATA-ENDERECO - WS-CONTA-BRC */
            WS_CONTA_BRC.Value = WORK_AREA.WS_TRATA_ENDERECO.Pic.Length - WS_CONTA_BRC;

            /*" -6534- IF WS-CONTA-BRC <= 3 */

            if (WS_CONTA_BRC <= 3)
            {

                /*" -6535- MOVE 1872 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1872, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -6536- PERFORM R1100-00-GRAVA-TAB-ERRO */

                R1100_00_GRAVA_TAB_ERRO_SECTION();

                /*" -6537- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -6538- GO TO R2450-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/ //GOTO
                return;

                /*" -6541- END-IF */
            }


            /*" -6542- MOVE 1 TO WS-POSICAO */
            _.Move(1, WS_POSICAO);

            /*" -6544- SET WS-NAO-ACHOU TO TRUE */
            WS_ENCONTROU_LETRA["WS_NAO_ACHOU"] = true;

            /*" -6545- PERFORM UNTIL WS-POSICAO > 40 OR WS-SIM-ACHOU */

            while (!(WS_POSICAO > 40 || WS_ENCONTROU_LETRA["WS_SIM_ACHOU"]))
            {

                /*" -6551- IF WS-TRATA-ENDERECO(WS-POSICAO:1) EQUAL 'A' OR 'B' OR 'C' OR 'D' OR 'E' OR 'F' OR 'G' OR 'H' OR 'I' OR 'J' OR 'K' OR 'L' OR 'M' OR 'N' OR 'O' OR 'P' OR 'Q' OR 'R' OR 'S' OR 'T' OR 'U' OR 'V' OR 'W' OR 'X' OR 'Y' OR 'Z' */

                if (WORK_AREA.WS_TRATA_ENDERECO.Substring(WS_POSICAO, 1).In("A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"))
                {

                    /*" -6552- SET WS-SIM-ACHOU TO TRUE */
                    WS_ENCONTROU_LETRA["WS_SIM_ACHOU"] = true;

                    /*" -6553- ELSE */
                }
                else
                {


                    /*" -6554- ADD 1 TO WS-POSICAO */
                    WS_POSICAO.Value = WS_POSICAO + 1;

                    /*" -6556- END-IF */
                }


                /*" -6558- END-PERFORM */
            }

            /*" -6559- IF WS-NAO-ACHOU */

            if (WS_ENCONTROU_LETRA["WS_NAO_ACHOU"])
            {

                /*" -6560- MOVE 1872 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1872, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -6561- PERFORM R1100-00-GRAVA-TAB-ERRO */

                R1100_00_GRAVA_TAB_ERRO_SECTION();

                /*" -6562- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -6563- GO TO R2450-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/ //GOTO
                return;

                /*" -6567- END-IF */
            }


            /*" -6569- IF BAIRRO OF DCLPESSOA-ENDERECO EQUAL SPACES OR LOW-VALUES */

            if (PESENDER.DCLPESSOA_ENDERECO.BAIRRO.IsLowValues())
            {

                /*" -6570- MOVE 1872 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1872, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -6571- PERFORM R1100-00-GRAVA-TAB-ERRO */

                R1100_00_GRAVA_TAB_ERRO_SECTION();

                /*" -6572- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -6573- GO TO R2450-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/ //GOTO
                return;

                /*" -6576- END-IF */
            }


            /*" -6578- IF BAIRRO OF DCLPESSOA-ENDERECO EQUAL 'BAIRRO' OR BAIRRO OF DCLPESSOA-ENDERECO EQUAL 'NAONAO' */

            if (PESENDER.DCLPESSOA_ENDERECO.BAIRRO == "BAIRRO" || PESENDER.DCLPESSOA_ENDERECO.BAIRRO == "NAONAO")
            {

                /*" -6579- MOVE 1872 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1872, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -6580- PERFORM R1100-00-GRAVA-TAB-ERRO */

                R1100_00_GRAVA_TAB_ERRO_SECTION();

                /*" -6581- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -6582- GO TO R2450-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/ //GOTO
                return;

                /*" -6586- END-IF */
            }


            /*" -6588- MOVE BAIRRO OF DCLPESSOA-ENDERECO TO WS-TRATA-BAIRRO */
            _.Move(PESENDER.DCLPESSOA_ENDERECO.BAIRRO, WORK_AREA.WS_TRATA_BAIRRO);

            /*" -6590- IF WS-BAI-1A-POSICAO EQUAL WS-BAI-2A-POSICAO AND WS-BAI-1A-POSICAO EQUAL WS-BAI-3A-POSICAO */

            if (WORK_AREA.WS_TRATA_BAI.WS_BAI_1A_POSICAO == WORK_AREA.WS_TRATA_BAI.WS_BAI_2A_POSICAO && WORK_AREA.WS_TRATA_BAI.WS_BAI_1A_POSICAO == WORK_AREA.WS_TRATA_BAI.WS_BAI_3A_POSICAO)
            {

                /*" -6591- MOVE 1872 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1872, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -6592- PERFORM R1100-00-GRAVA-TAB-ERRO */

                R1100_00_GRAVA_TAB_ERRO_SECTION();

                /*" -6593- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -6594- GO TO R2450-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/ //GOTO
                return;

                /*" -6597- END-IF */
            }


            /*" -6603- IF WS-BAI-1A-POSICAO EQUAL WS-BAI-4A-POSICAO AND WS-BAI-1A-POSICAO EQUAL WS-BAI-7A-POSICAO AND WS-BAI-2A-POSICAO EQUAL WS-BAI-5A-POSICAO AND WS-BAI-2A-POSICAO EQUAL WS-BAI-8A-POSICAO AND WS-BAI-3A-POSICAO EQUAL WS-BAI-6A-POSICAO AND WS-BAI-3A-POSICAO EQUAL WS-BAI-9A-POSICAO */

            if (WORK_AREA.WS_TRATA_BAI.WS_BAI_1A_POSICAO == WORK_AREA.WS_TRATA_BAI.WS_BAI_4A_POSICAO && WORK_AREA.WS_TRATA_BAI.WS_BAI_1A_POSICAO == WORK_AREA.WS_TRATA_BAI.WS_BAI_7A_POSICAO && WORK_AREA.WS_TRATA_BAI.WS_BAI_2A_POSICAO == WORK_AREA.WS_TRATA_BAI.WS_BAI_5A_POSICAO && WORK_AREA.WS_TRATA_BAI.WS_BAI_2A_POSICAO == WORK_AREA.WS_TRATA_BAI.WS_BAI_8A_POSICAO && WORK_AREA.WS_TRATA_BAI.WS_BAI_3A_POSICAO == WORK_AREA.WS_TRATA_BAI.WS_BAI_6A_POSICAO && WORK_AREA.WS_TRATA_BAI.WS_BAI_3A_POSICAO == WORK_AREA.WS_TRATA_BAI.WS_BAI_9A_POSICAO)
            {

                /*" -6604- MOVE 1872 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1872, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -6605- PERFORM R1100-00-GRAVA-TAB-ERRO */

                R1100_00_GRAVA_TAB_ERRO_SECTION();

                /*" -6606- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -6607- GO TO R2450-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/ //GOTO
                return;

                /*" -6610- END-IF */
            }


            /*" -6612- MOVE ZEROS TO WS-CONTA-BRC */
            _.Move(0, WS_CONTA_BRC);

            /*" -6615- INSPECT FUNCTION REVERSE(WS-TRATA-BAIRRO) TALLYING WS-CONTA-BRC FOR LEADING SPACES */
            WS_CONTA_BRC.Value = WORK_AREA.WS_TRATA_BAIRRO.ToString().Reverse().TakeWhile(x => x == ' ').Count();

            /*" -6618- COMPUTE WS-CONTA-BRC EQUAL LENGTH OF WS-TRATA-BAIRRO - WS-CONTA-BRC */
            WS_CONTA_BRC.Value = WORK_AREA.WS_TRATA_BAIRRO.Pic.Length - WS_CONTA_BRC;

            /*" -6619- IF WS-CONTA-BRC <= 3 */

            if (WS_CONTA_BRC <= 3)
            {

                /*" -6620- MOVE 1872 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1872, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -6621- PERFORM R1100-00-GRAVA-TAB-ERRO */

                R1100_00_GRAVA_TAB_ERRO_SECTION();

                /*" -6622- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -6623- GO TO R2450-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/ //GOTO
                return;

                /*" -6626- END-IF */
            }


            /*" -6627- MOVE 1 TO WS-POSICAO */
            _.Move(1, WS_POSICAO);

            /*" -6629- SET WS-NAO-ACHOU TO TRUE */
            WS_ENCONTROU_LETRA["WS_NAO_ACHOU"] = true;

            /*" -6630- PERFORM UNTIL WS-POSICAO > 20 OR WS-SIM-ACHOU */

            while (!(WS_POSICAO > 20 || WS_ENCONTROU_LETRA["WS_SIM_ACHOU"]))
            {

                /*" -6636- IF WS-TRATA-BAIRRO(WS-POSICAO:1) EQUAL 'A' OR 'B' OR 'C' OR 'D' OR 'E' OR 'F' OR 'G' OR 'H' OR 'I' OR 'J' OR 'K' OR 'L' OR 'M' OR 'N' OR 'O' OR 'P' OR 'Q' OR 'R' OR 'S' OR 'T' OR 'U' OR 'V' OR 'W' OR 'X' OR 'Y' OR 'Z' */

                if (WORK_AREA.WS_TRATA_BAIRRO.Substring(WS_POSICAO, 1).In("A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"))
                {

                    /*" -6637- SET WS-SIM-ACHOU TO TRUE */
                    WS_ENCONTROU_LETRA["WS_SIM_ACHOU"] = true;

                    /*" -6638- ELSE */
                }
                else
                {


                    /*" -6639- ADD 1 TO WS-POSICAO */
                    WS_POSICAO.Value = WS_POSICAO + 1;

                    /*" -6641- END-IF */
                }


                /*" -6643- END-PERFORM */
            }

            /*" -6644- IF WS-NAO-ACHOU */

            if (WS_ENCONTROU_LETRA["WS_NAO_ACHOU"])
            {

                /*" -6645- MOVE 1872 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1872, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -6646- PERFORM R1100-00-GRAVA-TAB-ERRO */

                R1100_00_GRAVA_TAB_ERRO_SECTION();

                /*" -6647- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -6648- GO TO R2450-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/ //GOTO
                return;

                /*" -6652- END-IF */
            }


            /*" -6653- IF CEP OF DCLPESSOA-ENDERECO EQUAL ZEROS */

            if (PESENDER.DCLPESSOA_ENDERECO.CEP == 00)
            {

                /*" -6654- MOVE 1872 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1872, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -6655- PERFORM R1100-00-GRAVA-TAB-ERRO */

                R1100_00_GRAVA_TAB_ERRO_SECTION();

                /*" -6656- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -6657- GO TO R2450-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/ //GOTO
                return;

                /*" -6659- END-IF */
            }


            /*" -6660- IF CEP OF DCLPESSOA-ENDERECO GREATER 99999999 */

            if (PESENDER.DCLPESSOA_ENDERECO.CEP > 99999999)
            {

                /*" -6661- MOVE 1872 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1872, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -6662- PERFORM R1100-00-GRAVA-TAB-ERRO */

                R1100_00_GRAVA_TAB_ERRO_SECTION();

                /*" -6663- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -6664- GO TO R2450-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/ //GOTO
                return;

                /*" -6668- END-IF */
            }


            /*" -6670- IF CIDADE OF DCLPESSOA-ENDERECO EQUAL SPACES OR LOW-VALUES */

            if (PESENDER.DCLPESSOA_ENDERECO.CIDADE.IsLowValues())
            {

                /*" -6671- MOVE 1872 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1872, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -6672- PERFORM R1100-00-GRAVA-TAB-ERRO */

                R1100_00_GRAVA_TAB_ERRO_SECTION();

                /*" -6673- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -6674- GO TO R2450-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/ //GOTO
                return;

                /*" -6677- END-IF */
            }


            /*" -6679- IF CIDADE OF DCLPESSOA-ENDERECO EQUAL 'CIDADE' OR CIDADE OF DCLPESSOA-ENDERECO EQUAL 'NAONAO' */

            if (PESENDER.DCLPESSOA_ENDERECO.CIDADE == "CIDADE" || PESENDER.DCLPESSOA_ENDERECO.CIDADE == "NAONAO")
            {

                /*" -6680- MOVE 1872 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1872, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -6681- PERFORM R1100-00-GRAVA-TAB-ERRO */

                R1100_00_GRAVA_TAB_ERRO_SECTION();

                /*" -6682- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -6683- GO TO R2450-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/ //GOTO
                return;

                /*" -6687- END-IF */
            }


            /*" -6689- MOVE CIDADE OF DCLPESSOA-ENDERECO TO WS-TRATA-CIDADE */
            _.Move(PESENDER.DCLPESSOA_ENDERECO.CIDADE, WORK_AREA.WS_TRATA_CIDADE);

            /*" -6691- IF WS-CID-1A-POSICAO EQUAL WS-CID-2A-POSICAO AND WS-CID-1A-POSICAO EQUAL WS-CID-3A-POSICAO */

            if (WORK_AREA.WS_TRATA_CID.WS_CID_1A_POSICAO == WORK_AREA.WS_TRATA_CID.WS_CID_2A_POSICAO && WORK_AREA.WS_TRATA_CID.WS_CID_1A_POSICAO == WORK_AREA.WS_TRATA_CID.WS_CID_3A_POSICAO)
            {

                /*" -6692- MOVE 1872 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1872, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -6693- PERFORM R1100-00-GRAVA-TAB-ERRO */

                R1100_00_GRAVA_TAB_ERRO_SECTION();

                /*" -6694- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -6695- GO TO R2450-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/ //GOTO
                return;

                /*" -6698- END-IF */
            }


            /*" -6704- IF WS-CID-1A-POSICAO EQUAL WS-CID-4A-POSICAO AND WS-CID-1A-POSICAO EQUAL WS-CID-7A-POSICAO AND WS-CID-2A-POSICAO EQUAL WS-CID-5A-POSICAO AND WS-CID-2A-POSICAO EQUAL WS-CID-8A-POSICAO AND WS-CID-3A-POSICAO EQUAL WS-CID-6A-POSICAO AND WS-CID-3A-POSICAO EQUAL WS-CID-9A-POSICAO */

            if (WORK_AREA.WS_TRATA_CID.WS_CID_1A_POSICAO == WORK_AREA.WS_TRATA_CID.WS_CID_4A_POSICAO && WORK_AREA.WS_TRATA_CID.WS_CID_1A_POSICAO == WORK_AREA.WS_TRATA_CID.WS_CID_7A_POSICAO && WORK_AREA.WS_TRATA_CID.WS_CID_2A_POSICAO == WORK_AREA.WS_TRATA_CID.WS_CID_5A_POSICAO && WORK_AREA.WS_TRATA_CID.WS_CID_2A_POSICAO == WORK_AREA.WS_TRATA_CID.WS_CID_8A_POSICAO && WORK_AREA.WS_TRATA_CID.WS_CID_3A_POSICAO == WORK_AREA.WS_TRATA_CID.WS_CID_6A_POSICAO && WORK_AREA.WS_TRATA_CID.WS_CID_3A_POSICAO == WORK_AREA.WS_TRATA_CID.WS_CID_9A_POSICAO)
            {

                /*" -6705- MOVE 1872 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1872, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -6706- PERFORM R1100-00-GRAVA-TAB-ERRO */

                R1100_00_GRAVA_TAB_ERRO_SECTION();

                /*" -6707- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -6708- GO TO R2450-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/ //GOTO
                return;

                /*" -6711- END-IF */
            }


            /*" -6713- MOVE ZEROS TO WS-CONTA-BRC */
            _.Move(0, WS_CONTA_BRC);

            /*" -6716- INSPECT FUNCTION REVERSE(WS-TRATA-CIDADE) TALLYING WS-CONTA-BRC FOR LEADING SPACES */
            WS_CONTA_BRC.Value = WORK_AREA.WS_TRATA_CIDADE.ToString().Reverse().TakeWhile(x => x == ' ').Count();

            /*" -6719- COMPUTE WS-CONTA-BRC EQUAL LENGTH OF WS-TRATA-CIDADE - WS-CONTA-BRC */
            WS_CONTA_BRC.Value = WORK_AREA.WS_TRATA_CIDADE.Pic.Length - WS_CONTA_BRC;

            /*" -6720- IF WS-CONTA-BRC < 3 */

            if (WS_CONTA_BRC < 3)
            {

                /*" -6721- MOVE 1872 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1872, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -6722- PERFORM R1100-00-GRAVA-TAB-ERRO */

                R1100_00_GRAVA_TAB_ERRO_SECTION();

                /*" -6723- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -6724- GO TO R2450-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/ //GOTO
                return;

                /*" -6727- END-IF */
            }


            /*" -6728- MOVE 1 TO WS-POSICAO */
            _.Move(1, WS_POSICAO);

            /*" -6730- SET WS-NAO-ACHOU TO TRUE */
            WS_ENCONTROU_LETRA["WS_NAO_ACHOU"] = true;

            /*" -6731- PERFORM UNTIL WS-POSICAO > 20 OR WS-SIM-ACHOU */

            while (!(WS_POSICAO > 20 || WS_ENCONTROU_LETRA["WS_SIM_ACHOU"]))
            {

                /*" -6737- IF WS-TRATA-CIDADE(WS-POSICAO:1) EQUAL 'A' OR 'B' OR 'C' OR 'D' OR 'E' OR 'F' OR 'G' OR 'H' OR 'I' OR 'J' OR 'K' OR 'L' OR 'M' OR 'N' OR 'O' OR 'P' OR 'Q' OR 'R' OR 'S' OR 'T' OR 'U' OR 'V' OR 'W' OR 'X' OR 'Y' OR 'Z' */

                if (WORK_AREA.WS_TRATA_CIDADE.Substring(WS_POSICAO, 1).In("A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"))
                {

                    /*" -6738- SET WS-SIM-ACHOU TO TRUE */
                    WS_ENCONTROU_LETRA["WS_SIM_ACHOU"] = true;

                    /*" -6739- ELSE */
                }
                else
                {


                    /*" -6740- ADD 1 TO WS-POSICAO */
                    WS_POSICAO.Value = WS_POSICAO + 1;

                    /*" -6742- END-IF */
                }


                /*" -6744- END-PERFORM */
            }

            /*" -6745- IF WS-NAO-ACHOU */

            if (WS_ENCONTROU_LETRA["WS_NAO_ACHOU"])
            {

                /*" -6746- MOVE 1872 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1872, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -6747- PERFORM R1100-00-GRAVA-TAB-ERRO */

                R1100_00_GRAVA_TAB_ERRO_SECTION();

                /*" -6748- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -6749- GO TO R2450-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/ //GOTO
                return;

                /*" -6753- END-IF */
            }


            /*" -6755- IF SIGLA-UF OF DCLPESSOA-ENDERECO EQUAL SPACES OR LOW-VALUES */

            if (PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF.IsLowValues())
            {

                /*" -6756- MOVE 1872 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1872, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -6757- PERFORM R1100-00-GRAVA-TAB-ERRO */

                R1100_00_GRAVA_TAB_ERRO_SECTION();

                /*" -6758- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -6759- GO TO R2450-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/ //GOTO
                return;

                /*" -6761- END-IF */
            }


            /*" -6766- PERFORM R2450_00_VALIDA_ENDERECO_DB_SELECT_1 */

            R2450_00_VALIDA_ENDERECO_DB_SELECT_1();

            /*" -6769- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6770- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -6771- MOVE 1872 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(1872, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -6772- PERFORM R1100-00-GRAVA-TAB-ERRO */

                    R1100_00_GRAVA_TAB_ERRO_SECTION();

                    /*" -6773- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                    _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                    /*" -6774- GO TO R2450-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/ //GOTO
                    return;

                    /*" -6775- ELSE */
                }
                else
                {


                    /*" -6776- DISPLAY 'PROBLEMAS ACESSO UNIDADE_FEDERACAO' */
                    _.Display($"PROBLEMAS ACESSO UNIDADE_FEDERACAO");

                    /*" -6777- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -6778- END-IF */
                }


                /*" -6780- END-IF */
            }


            /*" -6780- . */

        }

        [StopWatch]
        /*" R2450-00-VALIDA-ENDERECO-DB-SELECT-1 */
        public void R2450_00_VALIDA_ENDERECO_DB_SELECT_1()
        {
            /*" -6766- EXEC SQL SELECT SIGLA_UF INTO :WS-SIGLA-UF FROM SEGUROS.UNIDADE_FEDERACAO WHERE SIGLA_UF = :DCLPESSOA-ENDERECO.SIGLA-UF END-EXEC */

            var r2450_00_VALIDA_ENDERECO_DB_SELECT_1_Query1 = new R2450_00_VALIDA_ENDERECO_DB_SELECT_1_Query1()
            {
                SIGLA_UF = PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF.ToString(),
            };

            var executed_1 = R2450_00_VALIDA_ENDERECO_DB_SELECT_1_Query1.Execute(r2450_00_VALIDA_ENDERECO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_SIGLA_UF, WS_SIGLA_UF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-TRATA-EMAIL-SECTION */
        private void R2500_00_TRATA_EMAIL_SECTION()
        {
            /*" -6790- MOVE '2500-00-TRATA-EMAIL          ' TO PARAGRAFO. */
            _.Move("2500-00-TRATA-EMAIL          ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6792- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6793- IF WS-JA-E-CLIENTE EQUAL 1 */

            if (WORK_AREA.WS_JA_E_CLIENTE == 1)
            {

                /*" -6794- MOVE 51 TO SII */
                _.Move(51, WS_HORAS.SII);

                /*" -6795- PERFORM R9000-00-INICIO */

                R9000_00_INICIO_SECTION();

                /*" -6796- MOVE 'SELECT SEGUROS.CLIENTE_EMAIL ' TO COMANDO */
                _.Move("SELECT SEGUROS.CLIENTE_EMAIL ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -6801- PERFORM R2500_00_TRATA_EMAIL_DB_SELECT_1 */

                R2500_00_TRATA_EMAIL_DB_SELECT_1();

                /*" -6803- PERFORM R9100-00-TERMINO */

                R9100_00_TERMINO_SECTION();

                /*" -6804- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -6805- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -6806- PERFORM R2520-00-INSERT-EMAIL */

                        R2520_00_INSERT_EMAIL_SECTION();

                        /*" -6807- ELSE */
                    }
                    else
                    {


                        /*" -6808- DISPLAY 'PROBLEMAS ACESSO CLIENTE_EMAIL ' */
                        _.Display($"PROBLEMAS ACESSO CLIENTE_EMAIL ");

                        /*" -6809- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -6810- END-IF */
                    }


                    /*" -6811- ELSE */
                }
                else
                {


                    /*" -6812- PERFORM R2510-00-ALTERA-EMAIL */

                    R2510_00_ALTERA_EMAIL_SECTION();

                    /*" -6813- ELSE */
                }

            }
            else
            {


                /*" -6813- PERFORM R2520-00-INSERT-EMAIL. */

                R2520_00_INSERT_EMAIL_SECTION();
            }


        }

        [StopWatch]
        /*" R2500-00-TRATA-EMAIL-DB-SELECT-1 */
        public void R2500_00_TRATA_EMAIL_DB_SELECT_1()
        {
            /*" -6801- EXEC SQL SELECT EMAIL INTO :CLIENEMA-EMAIL FROM SEGUROS.CLIENTE_EMAIL WHERE COD_CLIENTE = :DCLCLIENTES.COD-CLIENTE END-EXEC */

            var r2500_00_TRATA_EMAIL_DB_SELECT_1_Query1 = new R2500_00_TRATA_EMAIL_DB_SELECT_1_Query1()
            {
                COD_CLIENTE = CLIENTE.DCLCLIENTES.COD_CLIENTE.ToString(),
            };

            var executed_1 = R2500_00_TRATA_EMAIL_DB_SELECT_1_Query1.Execute(r2500_00_TRATA_EMAIL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENEMA_EMAIL, CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_EMAIL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R2510-00-ALTERA-EMAIL-SECTION */
        private void R2510_00_ALTERA_EMAIL_SECTION()
        {
            /*" -6823- MOVE '2510-00-ALTERA-EMAIL         ' TO PARAGRAFO. */
            _.Move("2510-00-ALTERA-EMAIL         ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6824- MOVE 'UPDATE CLIENTE_EMAIL         ' TO COMANDO. */
            _.Move("UPDATE CLIENTE_EMAIL         ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6826- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6827- MOVE 52 TO SII */
            _.Move(52, WS_HORAS.SII);

            /*" -6828- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -6832- PERFORM R2510_00_ALTERA_EMAIL_DB_UPDATE_1 */

            R2510_00_ALTERA_EMAIL_DB_UPDATE_1();

            /*" -6834- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -6835- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6836- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -6837- DISPLAY 'EMAIL NAO CADASTRADO ' */
                    _.Display($"EMAIL NAO CADASTRADO ");

                    /*" -6838- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -6840- ELSE */
                }
                else
                {


                    /*" -6841- DISPLAY 'PROBLEMAS ACESSO CLIENTE_EMAIL ' */
                    _.Display($"PROBLEMAS ACESSO CLIENTE_EMAIL ");

                    /*" -6841- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2510-00-ALTERA-EMAIL-DB-UPDATE-1 */
        public void R2510_00_ALTERA_EMAIL_DB_UPDATE_1()
        {
            /*" -6832- EXEC SQL UPDATE SEGUROS.CLIENTE_EMAIL SET EMAIL = :WHOST-EMAIL WHERE COD_CLIENTE = :DCLCLIENTES.COD-CLIENTE END-EXEC */

            var r2510_00_ALTERA_EMAIL_DB_UPDATE_1_Update1 = new R2510_00_ALTERA_EMAIL_DB_UPDATE_1_Update1()
            {
                WHOST_EMAIL = WHOST_EMAIL.ToString(),
                COD_CLIENTE = CLIENTE.DCLCLIENTES.COD_CLIENTE.ToString(),
            };

            R2510_00_ALTERA_EMAIL_DB_UPDATE_1_Update1.Execute(r2510_00_ALTERA_EMAIL_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2510_99_SAIDA*/

        [StopWatch]
        /*" R2520-00-INSERT-EMAIL-SECTION */
        private void R2520_00_INSERT_EMAIL_SECTION()
        {
            /*" -6851- MOVE 'R2520-00-INSERT-EMAIL' TO PARAGRAFO. */
            _.Move("R2520-00-INSERT-EMAIL", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6852- MOVE 'SELECT MAX CLIENTE_EMAIL' TO COMANDO */
            _.Move("SELECT MAX CLIENTE_EMAIL", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6854- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6855- MOVE 53 TO SII */
            _.Move(53, WS_HORAS.SII);

            /*" -6856- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -6861- PERFORM R2520_00_INSERT_EMAIL_DB_SELECT_1 */

            R2520_00_INSERT_EMAIL_DB_SELECT_1();

            /*" -6864- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -6865- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6866- DISPLAY 'PROBLEMAS NO MAX CLEINTE_EMAIL          ' */
                _.Display($"PROBLEMAS NO MAX CLEINTE_EMAIL          ");

                /*" -6868- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -6870- ADD 1 TO CLIENEMA-SEQ-EMAIL. */
            CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_SEQ_EMAIL.Value = CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_SEQ_EMAIL + 1;

            /*" -6871- MOVE '2520-00-INSERT-CLIENTE-EMAIL ' TO PARAGRAFO. */
            _.Move("2520-00-INSERT-CLIENTE-EMAIL ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6873- MOVE 'INSERT CLIENTE-EMAIL         ' TO COMANDO. */
            _.Move("INSERT CLIENTE-EMAIL         ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6874- MOVE 54 TO SII */
            _.Move(54, WS_HORAS.SII);

            /*" -6875- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -6881- PERFORM R2520_00_INSERT_EMAIL_DB_INSERT_1 */

            R2520_00_INSERT_EMAIL_DB_INSERT_1();

            /*" -6884- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -6885- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6886- DISPLAY 'PROBLEMAS NO INSERT A CLIENTE_EMAIL     ' */
                _.Display($"PROBLEMAS NO INSERT A CLIENTE_EMAIL     ");

                /*" -6886- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2520-00-INSERT-EMAIL-DB-SELECT-1 */
        public void R2520_00_INSERT_EMAIL_DB_SELECT_1()
        {
            /*" -6861- EXEC SQL SELECT VALUE (MAX(SEQ_EMAIL),0) INTO :CLIENEMA-SEQ-EMAIL FROM SEGUROS.CLIENTE_EMAIL WHERE COD_CLIENTE = :DCLCLIENTES.COD-CLIENTE END-EXEC */

            var r2520_00_INSERT_EMAIL_DB_SELECT_1_Query1 = new R2520_00_INSERT_EMAIL_DB_SELECT_1_Query1()
            {
                COD_CLIENTE = CLIENTE.DCLCLIENTES.COD_CLIENTE.ToString(),
            };

            var executed_1 = R2520_00_INSERT_EMAIL_DB_SELECT_1_Query1.Execute(r2520_00_INSERT_EMAIL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENEMA_SEQ_EMAIL, CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_SEQ_EMAIL);
            }


        }

        [StopWatch]
        /*" R2520-00-INSERT-EMAIL-DB-INSERT-1 */
        public void R2520_00_INSERT_EMAIL_DB_INSERT_1()
        {
            /*" -6881- EXEC SQL INSERT INTO SEGUROS.CLIENTE_EMAIL VALUES (:DCLCLIENTES.COD-CLIENTE, :CLIENEMA-SEQ-EMAIL, :WHOST-EMAIL) END-EXEC. */

            var r2520_00_INSERT_EMAIL_DB_INSERT_1_Insert1 = new R2520_00_INSERT_EMAIL_DB_INSERT_1_Insert1()
            {
                COD_CLIENTE = CLIENTE.DCLCLIENTES.COD_CLIENTE.ToString(),
                CLIENEMA_SEQ_EMAIL = CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_SEQ_EMAIL.ToString(),
                WHOST_EMAIL = WHOST_EMAIL.ToString(),
            };

            R2520_00_INSERT_EMAIL_DB_INSERT_1_Insert1.Execute(r2520_00_INSERT_EMAIL_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2520_99_SAIDA*/

        [StopWatch]
        /*" R2600-00-TRATA-ESTADO-CIVIL-SECTION */
        private void R2600_00_TRATA_ESTADO_CIVIL_SECTION()
        {
            /*" -6896- MOVE '2600-00-TRATA-ESTADO-CIVIL' TO PARAGRAFO. */
            _.Move("2600-00-TRATA-ESTADO-CIVIL", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6898- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6899- IF WS-JA-E-CLIENTE EQUAL 1 */

            if (WORK_AREA.WS_JA_E_CLIENTE == 1)
            {

                /*" -6900- PERFORM R9000-00-INICIO */

                R9000_00_INICIO_SECTION();

                /*" -6901- MOVE 'SELECT SEGUROS.CLIENTES ' TO COMANDO */
                _.Move("SELECT SEGUROS.CLIENTES ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -6906- PERFORM R2600_00_TRATA_ESTADO_CIVIL_DB_SELECT_1 */

                R2600_00_TRATA_ESTADO_CIVIL_DB_SELECT_1();

                /*" -6908- PERFORM R9100-00-TERMINO */

                R9100_00_TERMINO_SECTION();

                /*" -6909- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -6910- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -6911- DISPLAY 'CLIENTE NAO CADASTRADO ' */
                        _.Display($"CLIENTE NAO CADASTRADO ");

                        /*" -6912- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -6913- ELSE */
                    }
                    else
                    {


                        /*" -6914- DISPLAY 'PROBLEMAS ACESSO CLIENTES      ' */
                        _.Display($"PROBLEMAS ACESSO CLIENTES      ");

                        /*" -6915- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -6916- END-IF */
                    }


                    /*" -6917- ELSE */
                }
                else
                {


                    /*" -6919- IF ESTADO-CIVIL OF DCLCLIENTES NOT EQUAL ESTADO-CIVIL OF DCLPESSOA-FISICA */

                    if (CLIENTE.DCLCLIENTES.ESTADO_CIVIL != PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL)
                    {

                        /*" -6920- PERFORM R2610-00-ALTERA-ESTADO-CIVIL */

                        R2610_00_ALTERA_ESTADO_CIVIL_SECTION();

                        /*" -6921- END-IF */
                    }


                    /*" -6922- END-IF */
                }


                /*" -6923- END-IF. */
            }


        }

        [StopWatch]
        /*" R2600-00-TRATA-ESTADO-CIVIL-DB-SELECT-1 */
        public void R2600_00_TRATA_ESTADO_CIVIL_DB_SELECT_1()
        {
            /*" -6906- EXEC SQL SELECT VALUE(ESTADO_CIVIL, ' ' ) INTO :DCLCLIENTES.ESTADO-CIVIL FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :DCLCLIENTES.COD-CLIENTE END-EXEC */

            var r2600_00_TRATA_ESTADO_CIVIL_DB_SELECT_1_Query1 = new R2600_00_TRATA_ESTADO_CIVIL_DB_SELECT_1_Query1()
            {
                COD_CLIENTE = CLIENTE.DCLCLIENTES.COD_CLIENTE.ToString(),
            };

            var executed_1 = R2600_00_TRATA_ESTADO_CIVIL_DB_SELECT_1_Query1.Execute(r2600_00_TRATA_ESTADO_CIVIL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ESTADO_CIVIL, CLIENTE.DCLCLIENTES.ESTADO_CIVIL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2600_99_SAIDA*/

        [StopWatch]
        /*" R2610-00-ALTERA-ESTADO-CIVIL-SECTION */
        private void R2610_00_ALTERA_ESTADO_CIVIL_SECTION()
        {
            /*" -6932- MOVE '2610-00-ALTERA-ESTADO-CIVIL ' TO PARAGRAFO. */
            _.Move("2610-00-ALTERA-ESTADO-CIVIL ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6933- MOVE 'UPDATE CLIENTES             ' TO COMANDO. */
            _.Move("UPDATE CLIENTES             ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6935- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6936- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -6940- PERFORM R2610_00_ALTERA_ESTADO_CIVIL_DB_UPDATE_1 */

            R2610_00_ALTERA_ESTADO_CIVIL_DB_UPDATE_1();

            /*" -6942- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -6943- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6944- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -6945- DISPLAY 'CLIENTE NAO CADASTRADO ' */
                    _.Display($"CLIENTE NAO CADASTRADO ");

                    /*" -6946- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -6947- ELSE */
                }
                else
                {


                    /*" -6948- DISPLAY 'PROBLEMAS ACESSO CLIENTES ' */
                    _.Display($"PROBLEMAS ACESSO CLIENTES ");

                    /*" -6949- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -6950- END-IF */
                }


                /*" -6950- END-IF. */
            }


        }

        [StopWatch]
        /*" R2610-00-ALTERA-ESTADO-CIVIL-DB-UPDATE-1 */
        public void R2610_00_ALTERA_ESTADO_CIVIL_DB_UPDATE_1()
        {
            /*" -6940- EXEC SQL UPDATE SEGUROS.CLIENTES SET ESTADO_CIVIL = :DCLPESSOA-FISICA.ESTADO-CIVIL WHERE COD_CLIENTE = :DCLCLIENTES.COD-CLIENTE END-EXEC */

            var r2610_00_ALTERA_ESTADO_CIVIL_DB_UPDATE_1_Update1 = new R2610_00_ALTERA_ESTADO_CIVIL_DB_UPDATE_1_Update1()
            {
                ESTADO_CIVIL = PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL.ToString(),
                COD_CLIENTE = CLIENTE.DCLCLIENTES.COD_CLIENTE.ToString(),
            };

            R2610_00_ALTERA_ESTADO_CIVIL_DB_UPDATE_1_Update1.Execute(r2610_00_ALTERA_ESTADO_CIVIL_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2610_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-INSERT-PROPOSTAVA-SECTION */
        private void R3000_00_INSERT_PROPOSTAVA_SECTION()
        {
            /*" -6960- MOVE '3000-00-INSERT-PROPOSTAVA    ' TO PARAGRAFO. */
            _.Move("3000-00-INSERT-PROPOSTAVA    ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6966- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6969- MOVE PROPOFID-DTQITBCO OF DCLPROPOSTA-FIDELIZ TO DATA-SQL1. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO, WORK_AREA.DATA_SQL1);

            /*" -6972- COMPUTE MES-SQL = MES-SQL + PRODUVG-PERI-PAGAMENTO OF DCLPRODUTOS-VG. */
            WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL + PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO;

            /*" -6973- IF MES-SQL GREATER 12 */

            if (WORK_AREA.DATA_SQL.MES_SQL > 12)
            {

                /*" -6976- COMPUTE MES-SQL = MES-SQL - 12 */
                WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL - 12;

                /*" -6979- COMPUTE ANO-SQL = ANO-SQL + 1. */
                WORK_AREA.DATA_SQL.ANO_SQL.Value = WORK_AREA.DATA_SQL.ANO_SQL + 1;
            }


            /*" -6981- MOVE DATA-SQL1 TO WHOST-DTPROXVEN. */
            _.Move(WORK_AREA.DATA_SQL1, WHOST_DTPROXVEN);

            /*" -6982- IF PROPOFID-DIA-DEBITO OF DCLPROPOSTA-FIDELIZ GREATER ZEROS */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIA_DEBITO > 00)
            {

                /*" -6985- MOVE PROPOFID-DIA-DEBITO OF DCLPROPOSTA-FIDELIZ TO DIA-SQL. */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIA_DEBITO, WORK_AREA.DATA_SQL.DIA_SQL);
            }


            /*" -6986- IF DIA-SQL GREATER 28 */

            if (WORK_AREA.DATA_SQL.DIA_SQL > 28)
            {

                /*" -6988- MOVE 28 TO DIA-SQL. */
                _.Move(28, WORK_AREA.DATA_SQL.DIA_SQL);
            }


            /*" -6989- IF DATA-SQL LESS WHOST-DTPROXVEN */

            if (WORK_AREA.DATA_SQL < WHOST_DTPROXVEN)
            {

                /*" -6990- ADD 1 TO MES-SQL */
                WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL + 1;

                /*" -6991- IF MES-SQL GREATER 12 */

                if (WORK_AREA.DATA_SQL.MES_SQL > 12)
                {

                    /*" -6992- MOVE 1 TO MES-SQL */
                    _.Move(1, WORK_AREA.DATA_SQL.MES_SQL);

                    /*" -6994- ADD 1 TO ANO-SQL. */
                    WORK_AREA.DATA_SQL.ANO_SQL.Value = WORK_AREA.DATA_SQL.ANO_SQL + 1;
                }

            }


            /*" -7008- MOVE DATA-SQL1 TO WHOST-DTPROXVEN. */
            _.Move(WORK_AREA.DATA_SQL1, WHOST_DTPROXVEN);

            /*" -7010- MOVE -1 TO VIND-DATA-DECLINIO. */
            _.Move(-1, VIND_DATA_DECLINIO);

            /*" -7019- IF WS-TEM-ERRO-1855 EQUAL 'SIM' OR WS-TEM-ERRO-1807 EQUAL 'SIM' OR WS-TEM-ERRO-1852 EQUAL 'SIM' OR WS-TEM-ERRO-1877 EQUAL 'SIM' OR WS-TEM-ERRO-1878 EQUAL 'SIM' OR PROPOFID-NSAS-SIVPF OF DCLPROPOSTA-FIDELIZ EQUAL 01 OR PROPOFID-SIT-PROPOSTA OF DCLPROPOSTA-FIDELIZ EQUAL 'DEC' */

            if (WORK_AREA.WS_TEM_ERRO_1855 == "SIM" || WORK_AREA.WS_TEM_ERRO_1807 == "SIM" || WORK_AREA.WS_TEM_ERRO_1852 == "SIM" || WORK_AREA.WS_TEM_ERRO_1877 == "SIM" || WORK_AREA.WS_TEM_ERRO_1878 == "SIM" || PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAS_SIVPF == 01 || PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA == "DEC")
            {

                /*" -7020- MOVE '2' TO WHOST-SIT-REGISTRO */
                _.Move("2", WHOST_SIT_REGISTRO);

                /*" -7021- MOVE ZEROS TO VIND-DATA-DECLINIO */
                _.Move(0, VIND_DATA_DECLINIO);

                /*" -7022- ELSE */
            }
            else
            {


                /*" -7029- IF WS-TEM-ERRO-1829 EQUAL 'SIM' OR WS-TEM-ERRO-DAD-CAD EQUAL 'SIM' OR WS-TEM-ERRO-1893 EQUAL 'SIM' OR WS-TEM-ERRO-1894 EQUAL 'SIM' OR WS-TEM-ERRO-1896 EQUAL 'SIM' OR WS-TEM-ERRO-1897 EQUAL 'SIM' OR WS-TEM-ERRO-DPS-ELETR EQUAL 'SIM' */

                if (WORK_AREA.WS_TEM_ERRO_1829 == "SIM" || WORK_AREA.WS_TEM_ERRO_DAD_CAD == "SIM" || WORK_AREA.WS_TEM_ERRO_1893 == "SIM" || WORK_AREA.WS_TEM_ERRO_1894 == "SIM" || WORK_AREA.WS_TEM_ERRO_1896 == "SIM" || WORK_AREA.WS_TEM_ERRO_1897 == "SIM" || WS_TEM_ERRO_DPS_ELETR == "SIM")
                {

                    /*" -7030- MOVE '1' TO WHOST-SIT-REGISTRO */
                    _.Move("1", WHOST_SIT_REGISTRO);

                    /*" -7031- ELSE */
                }
                else
                {


                    /*" -7032- IF WS-TEM-ERRO EQUAL ZEROS */

                    if (WORK_AREA.WS_TEM_ERRO == 00)
                    {

                        /*" -7080- MOVE 'E' TO WHOST-SIT-REGISTRO */
                        _.Move("E", WHOST_SIT_REGISTRO);

                        /*" -7081- ELSE */
                    }
                    else
                    {


                        /*" -7086- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 77 OR CANAL-GITEL OR (CANAL-SASSE-FILIAL AND (PROPOFID-ORIGEM-PROPOSTA EQUAL 23 OR 1018)) OR ORIGEM-AUTO-COMPRA-IBC OR ORIGEM-AUTO-COMPRA-LOJA */

                        if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 77 || WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_GITEL"] || (WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_SASSE_FILIAL"] && (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA.In("23", "1018"))) || WORK_AREA.W_ORIGEM_PROPOSTA["ORIGEM_AUTO_COMPRA_IBC"] || WORK_AREA.W_ORIGEM_PROPOSTA["ORIGEM_AUTO_COMPRA_LOJA"])
                        {

                            /*" -7087- MOVE '9' TO WHOST-SIT-REGISTRO */
                            _.Move("9", WHOST_SIT_REGISTRO);

                            /*" -7088- ELSE */
                        }
                        else
                        {


                            /*" -7089- MOVE 'E' TO WHOST-SIT-REGISTRO */
                            _.Move("E", WHOST_SIT_REGISTRO);

                            /*" -7090- END-IF */
                        }


                        /*" -7091- END-IF */
                    }


                    /*" -7093- END-IF. */
                }

            }


            /*" -7094- IF VIND-PROFISSAO-CONJUGE EQUAL ZEROS */

            if (VIND_PROFISSAO_CONJUGE == 00)
            {

                /*" -7098- IF PROPOFID-PROFISSAO-CONJUGE OF DCLPROPOSTA-FIDELIZ > ZEROS AND PROPOFID-PROFISSAO-CONJUGE OF DCLPROPOSTA-FIDELIZ < 1000 */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PROFISSAO_CONJUGE > 00 && PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PROFISSAO_CONJUGE < 1000)
                {

                    /*" -7101- MOVE TAB-DESCR-CBO-C (PROPOFID-PROFISSAO-CONJUGE OF DCLPROPOSTA-FIDELIZ) TO WHOST-PROFISSAO-CONJUGE */
                    _.Move(TAB_CBO1.TAB_CBO.FILLER_34[PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PROFISSAO_CONJUGE].TAB_DESCR_CBO_C, WHOST_PROFISSAO_CONJUGE);

                    /*" -7102- ELSE */
                }
                else
                {


                    /*" -7103- MOVE SPACES TO WHOST-PROFISSAO-CONJUGE */
                    _.Move("", WHOST_PROFISSAO_CONJUGE);

                    /*" -7104- END-IF */
                }


                /*" -7106- END-IF. */
            }


            /*" -7108- IF PROPOFID-AGECOBR OF DCLPROPOSTA-FIDELIZ > 0 AND PROPOFID-AGECOBR OF DCLPROPOSTA-FIDELIZ < 10000 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR > 0 && PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR < 10000)
            {

                /*" -7110- MOVE TAB-FONTE (PROPOFID-AGECOBR OF DCLPROPOSTA-FIDELIZ) TO WHOST-FONTE */
                _.Move(TAB_FILIAIS.TAB_FILIAL.FILLER_33[PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR].TAB_FONTE, WHOST_FONTE);

                /*" -7111- ELSE */
            }
            else
            {


                /*" -7114- DISPLAY 'AGENCIA INVALIDA ----> ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ ' ' PROPOFID-AGECOBR OF DCLPROPOSTA-FIDELIZ */

                $"AGENCIA INVALIDA ----> {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF} {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR}"
                .Display();

                /*" -7115- MOVE ZEROS TO WHOST-FONTE */
                _.Move(0, WHOST_FONTE);

                /*" -7117- END-IF. */
            }


            /*" -7119- IF (WHOST-FONTE = ZEROS OR 10) OR (WHOST-FONTE > 99) */

            if ((WHOST_FONTE.In("00", "10")) || (WHOST_FONTE > 99))
            {

                /*" -7121- MOVE 5 TO WHOST-FONTE. */
                _.Move(5, WHOST_FONTE);
            }


            /*" -7123- IF PRODUVG-PERI-PAGAMENTO = 00 OR PROPOFID-COD-PRODUTO-SIVPF = 77 */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO == 00 || PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 77)
            {

                /*" -7124- MOVE '9999-12-31' TO WHOST-DTPROXVEN */
                _.Move("9999-12-31", WHOST_DTPROXVEN);

                /*" -7126- END-IF. */
            }


            /*" -7128- MOVE -1 TO VIND-STA-ANTECIPACAO. */
            _.Move(-1, VIND_STA_ANTECIPACAO);

            /*" -7132- IF (PROPOFID-COD-PRODUTO-SIVPF = 11 OR 13 OR 46) AND PRODUVG-PERI-PAGAMENTO = 12 */

            if ((PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF.In("11", "13", "46")) && PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO == 12)
            {

                /*" -7133- MOVE 'S' TO WHOST-STA-ANTECIPACAO */
                _.Move("S", WHOST_STA_ANTECIPACAO);

                /*" -7134- MOVE ZEROS TO VIND-STA-ANTECIPACAO */
                _.Move(0, VIND_STA_ANTECIPACAO);

                /*" -7136- END-IF. */
            }


            /*" -7137- MOVE 'INSERT PROPOSTAS_VA           ' TO COMANDO. */
            _.Move("INSERT PROPOSTAS_VA           ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7138- MOVE 55 TO SII */
            _.Move(55, WS_HORAS.SII);

            /*" -7139- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -7275- PERFORM R3000_00_INSERT_PROPOSTAVA_DB_INSERT_1 */

            R3000_00_INSERT_PROPOSTAVA_DB_INSERT_1();

            /*" -7278- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -7280- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL -803 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
            {

                /*" -7281- DISPLAY 'PROBLEMAS NO INSERT PROPOSTAVA ' */
                _.Display($"PROBLEMAS NO INSERT PROPOSTAVA ");

                /*" -7283- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -7283- ADD 1 TO AC-I-PROPOSTAVA. */
            WORK_AREA.AC_I_PROPOSTAVA.Value = WORK_AREA.AC_I_PROPOSTAVA + 1;

        }

        [StopWatch]
        /*" R3000-00-INSERT-PROPOSTAVA-DB-INSERT-1 */
        public void R3000_00_INSERT_PROPOSTAVA_DB_INSERT_1()
        {
            /*" -7275- EXEC SQL INSERT INTO SEGUROS.PROPOSTAS_VA ( NUM_CERTIFICADO , COD_PRODUTO , COD_CLIENTE , OCOREND , COD_FONTE , AGE_COBRANCA , OPCAO_COBERTURA , DATA_QUITACAO , COD_AGE_VENDEDOR , OPE_CONTA_VENDEDOR , NUM_CONTA_VENDEDOR , DIG_CONTA_VENDEDOR , NUM_MATRI_VENDEDOR , COD_OPERACAO , PROFISSAO , DTINCLUS , DATA_MOVIMENTO , SIT_REGISTRO , NUM_APOLICE , COD_SUBGRUPO , OCORR_HISTORICO , NRPRIPARATZ , QTDPARATZ , DTPROXVEN , NUM_PARCELA , DATA_VENCIMENTO , SIT_INTERFACE , DTFENAE , COD_USUARIO , TIMESTAMP , IDADE , IDE_SEXO , ESTADO_CIVIL , OPCAO_MARCADA , SIGLA_CRM , COD_CRM , APOS_INVALIDEZ , ASSINATURA , ACATAMENTO , NOME_ESPOSA , DTNASC_ESPOSA , PROFIS_ESPOSA , DPS_TITULAR , DPS_ESPOSA , NUM_MATRICULA , GRAU_PARENTESCO , DATA_ADMISSAO , NUM_PROPOSTA , EM_ATIVIDADE , LOC_ATIVIDADE , INFO_COMPLEMENTAR , NRMALADIR , NRCERTIFANT , COD_CCT , FAIXA_RENDA_IND , FAIXA_RENDA_FAM , NUM_CONTR_VINCULO , COD_CORRESP_BANC , COD_ORIGEM_PROPOSTA , NUM_PRAZO_FIN , COD_OPER_CREDITO , STA_ANTECIPACAO, STA_MUDANCA_PLANO, DTA_DECLINIO) VALUES (:DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF , :DCLPRODUTOS-VG.PRODUVG-COD-PRODUTO , :DCLCLIENTES.COD-CLIENTE , :DCLENDERECOS.ENDERECO-OCORR-ENDERECO , :WHOST-FONTE , :DCLPROPOSTA-FIDELIZ.PROPOFID-AGECOBR , :DCLPROPOSTA-FIDELIZ.PROPOFID-OPCAO-COBER , :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO , :DCLPROPOSTA-FIDELIZ.PROPOFID-AGECTAVEN , :DCLPROPOSTA-FIDELIZ.PROPOFID-OPRCTAVEN , :DCLPROPOSTA-FIDELIZ.PROPOFID-NUMCTAVEN , :DCLPROPOSTA-FIDELIZ.PROPOFID-DIGCTAVEN , :DCLPROPOSTA-FIDELIZ.PROPOFID-NRMATRVEN , 106 , :WHOST-PROFISSAO , :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO , :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO , :WHOST-SIT-REGISTRO , :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE , :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO , 1 , 0 , 0 , :WHOST-DTPROXVEN , 1 , :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO , '0' , :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO, 'VA0601B' , CURRENT TIMESTAMP, :WHOST-IDADE, :DCLPESSOA-FISICA.SEXO, :DCLPESSOA-FISICA.ESTADO-CIVIL, NULL, NULL, NULL, :DCLPROP-SASSE-VIDA.PROPSSVD-APOS-INVALIDEZ , ' ' , ' ' , :DCLPROPOSTA-FIDELIZ.PROPOFID-NOME-CONJUGE :VIND-NOME-CONJUGE, :DCLPROPOSTA-FIDELIZ.PROPOFID-DATA-NASC-CONJUGE :VIND-DATA-NASC-CONJUGE, :WHOST-PROFISSAO-CONJUGE :VIND-PROFISSAO-CONJUGE, :DCLPROP-SASSE-VIDA.PROPSSVD-DPS-TITULAR , :DCLPROP-SASSE-VIDA.PROPSSVD-DPS-CONJUGE , NULL, NULL, NULL, NULL, NULL, NULL, :WHOST-INFO-COMPL, NULL, NULL, :DCLPROPOSTA-FIDELIZ.PROPOFID-CGC-CONVENENTE :VIND-CGC-CONVENENTE, :DCLPROPOSTA-FIDELIZ.PROPOFID-FAIXA-RENDA-IND, :DCLPROPOSTA-FIDELIZ.PROPOFID-FAIXA-RENDA-FAM, :PROPSSVD-NUM-CONTR-VINCULO :VIND-NUM-CONTR , :PROPSSVD-COD-CORRESP-BANC :VIND-COD-CORRESP , :DCLPROPOSTA-FIDELIZ.PROPOFID-ORIGEM-PROPOSTA , :PROPSSVD-NUM-PRAZO-FIN :VIND-NUM-PRAZO , :PROPSSVD-COD-OPER-CREDITO :VIND-COD-OPER-CRED , :WHOST-STA-ANTECIPACAO :VIND-STA-ANTECIPACAO, NULL, :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO :VIND-DATA-DECLINIO) END-EXEC. */

            var r3000_00_INSERT_PROPOSTAVA_DB_INSERT_1_Insert1 = new R3000_00_INSERT_PROPOSTAVA_DB_INSERT_1_Insert1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                PRODUVG_COD_PRODUTO = PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.ToString(),
                COD_CLIENTE = CLIENTE.DCLCLIENTES.COD_CLIENTE.ToString(),
                ENDERECO_OCORR_ENDERECO = ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO.ToString(),
                WHOST_FONTE = WHOST_FONTE.ToString(),
                PROPOFID_AGECOBR = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR.ToString(),
                PROPOFID_OPCAO_COBER = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER.ToString(),
                PROPOFID_DTQITBCO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.ToString(),
                PROPOFID_AGECTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTAVEN.ToString(),
                PROPOFID_OPRCTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTAVEN.ToString(),
                PROPOFID_NUMCTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTAVEN.ToString(),
                PROPOFID_DIGCTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTAVEN.ToString(),
                PROPOFID_NRMATRVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN.ToString(),
                WHOST_PROFISSAO = WHOST_PROFISSAO.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                WHOST_SIT_REGISTRO = WHOST_SIT_REGISTRO.ToString(),
                PROPSSVD_NUM_APOLICE = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.ToString(),
                PROPSSVD_COD_SUBGRUPO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.ToString(),
                WHOST_DTPROXVEN = WHOST_DTPROXVEN.ToString(),
                WHOST_IDADE = WHOST_IDADE.ToString(),
                SEXO = PESFIS.DCLPESSOA_FISICA.SEXO.ToString(),
                ESTADO_CIVIL = PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL.ToString(),
                PROPSSVD_APOS_INVALIDEZ = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_APOS_INVALIDEZ.ToString(),
                PROPOFID_NOME_CONJUGE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NOME_CONJUGE.ToString(),
                VIND_NOME_CONJUGE = VIND_NOME_CONJUGE.ToString(),
                PROPOFID_DATA_NASC_CONJUGE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_NASC_CONJUGE.ToString(),
                VIND_DATA_NASC_CONJUGE = VIND_DATA_NASC_CONJUGE.ToString(),
                WHOST_PROFISSAO_CONJUGE = WHOST_PROFISSAO_CONJUGE.ToString(),
                VIND_PROFISSAO_CONJUGE = VIND_PROFISSAO_CONJUGE.ToString(),
                PROPSSVD_DPS_TITULAR = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_TITULAR.ToString(),
                PROPSSVD_DPS_CONJUGE = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_CONJUGE.ToString(),
                WHOST_INFO_COMPL = WHOST_INFO_COMPL.ToString(),
                PROPOFID_CGC_CONVENENTE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CGC_CONVENENTE.ToString(),
                VIND_CGC_CONVENENTE = VIND_CGC_CONVENENTE.ToString(),
                PROPOFID_FAIXA_RENDA_IND = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_IND.ToString(),
                PROPOFID_FAIXA_RENDA_FAM = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_FAM.ToString(),
                PROPSSVD_NUM_CONTR_VINCULO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_CONTR_VINCULO.ToString(),
                VIND_NUM_CONTR = VIND_NUM_CONTR.ToString(),
                PROPSSVD_COD_CORRESP_BANC = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_CORRESP_BANC.ToString(),
                VIND_COD_CORRESP = VIND_COD_CORRESP.ToString(),
                PROPOFID_ORIGEM_PROPOSTA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA.ToString(),
                PROPSSVD_NUM_PRAZO_FIN = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_PRAZO_FIN.ToString(),
                VIND_NUM_PRAZO = VIND_NUM_PRAZO.ToString(),
                PROPSSVD_COD_OPER_CREDITO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_OPER_CREDITO.ToString(),
                VIND_COD_OPER_CRED = VIND_COD_OPER_CRED.ToString(),
                WHOST_STA_ANTECIPACAO = WHOST_STA_ANTECIPACAO.ToString(),
                VIND_STA_ANTECIPACAO = VIND_STA_ANTECIPACAO.ToString(),
                VIND_DATA_DECLINIO = VIND_DATA_DECLINIO.ToString(),
            };

            R3000_00_INSERT_PROPOSTAVA_DB_INSERT_1_Insert1.Execute(r3000_00_INSERT_PROPOSTAVA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3010-00-INSERT-COMPL-SICAQWEB-SECTION */
        private void R3010_00_INSERT_COMPL_SICAQWEB_SECTION()
        {
            /*" -7293- MOVE 'R3010-00-INSERT-COMPL_SICAQWEB' TO PARAGRAFO. */
            _.Move("R3010-00-INSERT-COMPL_SICAQWEB", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7294- MOVE 'INSERT COMPL_SICAQWEB         ' TO COMANDO. */
            _.Move("INSERT COMPL_SICAQWEB         ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7296- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7297- MOVE WSRC-COD-OPERADOR TO VG084-COD-OPERADOR */
            _.Move(WSRC_INF_SICAQWEB.WSRC_COD_OPERADOR, VG084.DCLVG_COMPL_SICAQWEB.VG084_COD_OPERADOR);

            /*" -7298- MOVE WSRC-NUM-CORRESPONDENTE TO VG084-NUM-CORRESP-CX-AQUI */
            _.Move(WSRC_INF_SICAQWEB.WSRC_NUM_CORRESPONDENTE, VG084.DCLVG_COMPL_SICAQWEB.VG084_NUM_CORRESP_CX_AQUI);

            /*" -7300- MOVE WSRC-TIPO-CORRESPONDENTE TO VG084-IND-TP-CORRESP-SICAQ */
            _.Move(WSRC_INF_SICAQWEB.WSRC_TIPO_CORRESPONDENTE, VG084.DCLVG_COMPL_SICAQWEB.VG084_IND_TP_CORRESP_SICAQ);

            /*" -7301- MOVE '0001-01-01' TO DATA-SQL1 */
            _.Move("0001-01-01", WORK_AREA.DATA_SQL1);

            /*" -7302- MOVE WSRC-ANO-CONTRATACAO TO ANO-SQL */
            _.Move(WSRC_INF_SICAQWEB.WSRC_DATA_CONTRATACAO.WSRC_ANO_CONTRATACAO, WORK_AREA.DATA_SQL.ANO_SQL);

            /*" -7303- MOVE WSRC-MES-CONTRATACAO TO MES-SQL */
            _.Move(WSRC_INF_SICAQWEB.WSRC_DATA_CONTRATACAO.WSRC_MES_CONTRATACAO, WORK_AREA.DATA_SQL.MES_SQL);

            /*" -7304- MOVE WSRC-DIA-CONTRATACAO TO DIA-SQL */
            _.Move(WSRC_INF_SICAQWEB.WSRC_DATA_CONTRATACAO.WSRC_DIA_CONTRATACAO, WORK_AREA.DATA_SQL.DIA_SQL);

            /*" -7306- MOVE DATA-SQL1 TO VG084-DTA-CONTRATACAO */
            _.Move(WORK_AREA.DATA_SQL1, VG084.DCLVG_COMPL_SICAQWEB.VG084_DTA_CONTRATACAO);

            /*" -7307- MOVE '01:01:01' TO HORA-SQL1 */
            _.Move("01:01:01", WORK_AREA.HORA_SQL1);

            /*" -7308- MOVE WSRC-HH-CONTRATACAO TO HH-SQL */
            _.Move(WSRC_INF_SICAQWEB.WSRC_HORA_CONTRATACAO.WSRC_HH_CONTRATACAO, WORK_AREA.HORA_SQL.HH_SQL);

            /*" -7309- MOVE WSRC-MM-CONTRATACAO TO MM-SQL */
            _.Move(WSRC_INF_SICAQWEB.WSRC_HORA_CONTRATACAO.WSRC_MM_CONTRATACAO, WORK_AREA.HORA_SQL.MM_SQL);

            /*" -7310- MOVE WSRC-SS-CONTRATACAO TO SS-SQL */
            _.Move(WSRC_INF_SICAQWEB.WSRC_HORA_CONTRATACAO.WSRC_SS_CONTRATACAO, WORK_AREA.HORA_SQL.SS_SQL);

            /*" -7312- MOVE HORA-SQL1 TO VG084-HRA-CONTRATACAO */
            _.Move(WORK_AREA.HORA_SQL1, VG084.DCLVG_COMPL_SICAQWEB.VG084_HRA_CONTRATACAO);

            /*" -7313- MOVE WSRC-NRO-PROPOSTA-SICAQ TO VG084-NUM-PROPOSTA-SICAQ */
            _.Move(WSRC_INF_SICAQWEB.WSRC_NRO_PROPOSTA_SICAQ, VG084.DCLVG_COMPL_SICAQWEB.VG084_NUM_PROPOSTA_SICAQ);

            /*" -7314- MOVE WSRC-ORIGEM-PROPOSTA TO VG084-IND-ORIGEM-PROPOSTA */
            _.Move(WSRC_INF_SICAQWEB.WSRC_ORIGEM_PROPOSTA, VG084.DCLVG_COMPL_SICAQWEB.VG084_IND_ORIGEM_PROPOSTA);

            /*" -7316- MOVE 'VA0601B' TO VG084-NOM-PROGRAMA. */
            _.Move("VA0601B", VG084.DCLVG_COMPL_SICAQWEB.VG084_NOM_PROGRAMA);

            /*" -7317- MOVE 56 TO SII */
            _.Move(56, WS_HORAS.SII);

            /*" -7319- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -7341- PERFORM R3010_00_INSERT_COMPL_SICAQWEB_DB_INSERT_1 */

            R3010_00_INSERT_COMPL_SICAQWEB_DB_INSERT_1();

            /*" -7344- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -7345- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7346- DISPLAY 'PROBLEMAS NO INSERT VG_COMPL_SICAQWEB' */
                _.Display($"PROBLEMAS NO INSERT VG_COMPL_SICAQWEB");

                /*" -7348- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -7349- ADD 1 TO AC-I-COMPL-SICAQ. */
            WORK_AREA.AC_I_COMPL_SICAQ.Value = WORK_AREA.AC_I_COMPL_SICAQ + 1;

        }

        [StopWatch]
        /*" R3010-00-INSERT-COMPL-SICAQWEB-DB-INSERT-1 */
        public void R3010_00_INSERT_COMPL_SICAQWEB_DB_INSERT_1()
        {
            /*" -7341- EXEC SQL INSERT INTO SEGUROS.VG_COMPL_SICAQWEB ( NUM_CERTIFICADO , COD_OPERADOR , NUM_CORRESP_CX_AQUI , IND_TP_CORRESP_SICAQ , DTA_CONTRATACAO , HRA_CONTRATACAO , NUM_PROPOSTA_SICAQ , IND_ORIGEM_PROPOSTA , NOM_PROGRAMA , DTH_CADASTRAMENTO ) VALUES ( :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF ,:VG084-COD-OPERADOR ,:VG084-NUM-CORRESP-CX-AQUI ,:VG084-IND-TP-CORRESP-SICAQ ,:VG084-DTA-CONTRATACAO ,:VG084-HRA-CONTRATACAO ,:VG084-NUM-PROPOSTA-SICAQ ,:VG084-IND-ORIGEM-PROPOSTA ,:VG084-NOM-PROGRAMA , CURRENT TIMESTAMP ) END-EXEC. */

            var r3010_00_INSERT_COMPL_SICAQWEB_DB_INSERT_1_Insert1 = new R3010_00_INSERT_COMPL_SICAQWEB_DB_INSERT_1_Insert1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                VG084_COD_OPERADOR = VG084.DCLVG_COMPL_SICAQWEB.VG084_COD_OPERADOR.ToString(),
                VG084_NUM_CORRESP_CX_AQUI = VG084.DCLVG_COMPL_SICAQWEB.VG084_NUM_CORRESP_CX_AQUI.ToString(),
                VG084_IND_TP_CORRESP_SICAQ = VG084.DCLVG_COMPL_SICAQWEB.VG084_IND_TP_CORRESP_SICAQ.ToString(),
                VG084_DTA_CONTRATACAO = VG084.DCLVG_COMPL_SICAQWEB.VG084_DTA_CONTRATACAO.ToString(),
                VG084_HRA_CONTRATACAO = VG084.DCLVG_COMPL_SICAQWEB.VG084_HRA_CONTRATACAO.ToString(),
                VG084_NUM_PROPOSTA_SICAQ = VG084.DCLVG_COMPL_SICAQWEB.VG084_NUM_PROPOSTA_SICAQ.ToString(),
                VG084_IND_ORIGEM_PROPOSTA = VG084.DCLVG_COMPL_SICAQWEB.VG084_IND_ORIGEM_PROPOSTA.ToString(),
                VG084_NOM_PROGRAMA = VG084.DCLVG_COMPL_SICAQWEB.VG084_NOM_PROGRAMA.ToString(),
            };

            R3010_00_INSERT_COMPL_SICAQWEB_DB_INSERT_1_Insert1.Execute(r3010_00_INSERT_COMPL_SICAQWEB_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3010_99_SAIDA*/

        [StopWatch]
        /*" R3015-00-MOVE-DADOS-ANDAMENTO-SECTION */
        private void R3015_00_MOVE_DADOS_ANDAMENTO_SECTION()
        {
            /*" -7358- MOVE 'R3015-00-INSERE-ANDAMENTO     ' TO PARAGRAFO */
            _.Move("R3015-00-INSERE-ANDAMENTO     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7360- MOVE 'MOVIMENTA DADOS DO ANDAMENTO  ' TO COMANDO */
            _.Move("MOVIMENTA DADOS DO ANDAMENTO  ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7361- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7363- MOVE PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO VG078-NUM-CERTIFICADO */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, VG078.DCLVG_ANDAMENTO_PROP.VG078_NUM_CERTIFICADO);

            /*" -7365- MOVE 55 TO VG078-DES-ANDAMENTO-LEN */
            _.Move(55, VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.VG078_DES_ANDAMENTO_LEN);

            /*" -7366- EVALUATE PROPOFID-IND-TP-PROPOSTA */
            switch (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TP_PROPOSTA.Value.Trim())
            {

                /*" -7367- WHEN 'D' */
                case "D":

                    /*" -7369- MOVE WS-TXT-PROP-ELETRONICA TO VG078-DES-ANDAMENTO-TEXT */
                    _.Move(WS_TXT_PROP_ELETRONICA, VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.VG078_DES_ANDAMENTO_TEXT);

                    /*" -7370- WHEN 'E' */
                    break;
                case "E":

                    /*" -7372- MOVE WS-TXT-PROP-ELETRONICA-EMAIL TO VG078-DES-ANDAMENTO-TEXT */
                    _.Move(WS_TXT_PROP_ELETRONICA_EMAIL, VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.VG078_DES_ANDAMENTO_TEXT);

                    /*" -7373- WHEN 'S' */
                    break;
                case "S":

                    /*" -7375- MOVE WS-TXT-PROP-ELETRONICA-SMS TO VG078-DES-ANDAMENTO-TEXT */
                    _.Move(WS_TXT_PROP_ELETRONICA_SMS, VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.VG078_DES_ANDAMENTO_TEXT);

                    /*" -7376- WHEN 'V' */
                    break;
                case "V":

                    /*" -7378- MOVE WS-TXT-PROP-ELETRONICA-VOCAL TO VG078-DES-ANDAMENTO-TEXT */
                    _.Move(WS_TXT_PROP_ELETRONICA_VOCAL, VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.VG078_DES_ANDAMENTO_TEXT);

                    /*" -7379- WHEN 'C' */
                    break;
                case "C":

                    /*" -7381- MOVE WS-TXT-PROP-ELETRONICA-CHAT TO VG078-DES-ANDAMENTO-TEXT */
                    _.Move(WS_TXT_PROP_ELETRONICA_CHAT, VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.VG078_DES_ANDAMENTO_TEXT);

                    /*" -7383- END-EVALUATE */
                    break;
            }


            /*" -7385- MOVE 'VA0601B' TO VG078-COD-USUARIO */
            _.Move("VA0601B", VG078.DCLVG_ANDAMENTO_PROP.VG078_COD_USUARIO);

            /*" -7385- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3015_99_SAIDA*/

        [StopWatch]
        /*" R3017-00-MOVE-DADOS-ANDAMENTO-SECTION */
        private void R3017_00_MOVE_DADOS_ANDAMENTO_SECTION()
        {
            /*" -7395- MOVE 'R3017-00-INSERE-ANDAMENTO     ' TO PARAGRAFO */
            _.Move("R3017-00-INSERE-ANDAMENTO     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7396- MOVE 'MOVIMENTA DADOS DO ANDAMENTO  ' TO COMANDO */
            _.Move("MOVIMENTA DADOS DO ANDAMENTO  ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7398- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7401- MOVE PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO VG078-NUM-CERTIFICADO */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, VG078.DCLVG_ANDAMENTO_PROP.VG078_NUM_CERTIFICADO);

            /*" -7403- MOVE 55 TO VG078-DES-ANDAMENTO-LEN */
            _.Move(55, VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.VG078_DES_ANDAMENTO_LEN);

            /*" -7405- MOVE WS-TXT-CONTA-SALARIO TO VG078-DES-ANDAMENTO-TEXT */
            _.Move(WS_TXT_CONTA_SALARIO, VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.VG078_DES_ANDAMENTO_TEXT);

            /*" -7407- MOVE 'VA0601B' TO VG078-COD-USUARIO */
            _.Move("VA0601B", VG078.DCLVG_ANDAMENTO_PROP.VG078_COD_USUARIO);

            /*" -7407- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3017_99_SAIDA*/

        [StopWatch]
        /*" R3020-00-INSERE-ANDAMENTO-SECTION */
        private void R3020_00_INSERE_ANDAMENTO_SECTION()
        {
            /*" -7417- MOVE 'R3020-00-INSERE-ANDAMENTO     ' TO PARAGRAFO */
            _.Move("R3020-00-INSERE-ANDAMENTO     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7418- MOVE 'INSERT VG_ANDAMENTO_PROP      ' TO COMANDO */
            _.Move("INSERT VG_ANDAMENTO_PROP      ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7420- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7422- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -7437- PERFORM R3020_00_INSERE_ANDAMENTO_DB_INSERT_1 */

            R3020_00_INSERE_ANDAMENTO_DB_INSERT_1();

            /*" -7441- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -7442- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7443- DISPLAY 'PROBLEMAS NO INSERT VG_ANDAMENTO_PROP' */
                _.Display($"PROBLEMAS NO INSERT VG_ANDAMENTO_PROP");

                /*" -7444- DISPLAY 'NUM_CERTIFICADO = ' VG078-NUM-CERTIFICADO */
                _.Display($"NUM_CERTIFICADO = {VG078.DCLVG_ANDAMENTO_PROP.VG078_NUM_CERTIFICADO}");

                /*" -7445- DISPLAY 'SQLCODE         = ' SQLCODE */
                _.Display($"SQLCODE         = {DB.SQLCODE}");

                /*" -7446- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -7446- END-IF. */
            }


        }

        [StopWatch]
        /*" R3020-00-INSERE-ANDAMENTO-DB-INSERT-1 */
        public void R3020_00_INSERE_ANDAMENTO_DB_INSERT_1()
        {
            /*" -7437- EXEC SQL INSERT INTO SEGUROS.VG_ANDAMENTO_PROP ( NUM_CERTIFICADO , DTH_CADASTRAMENTO , DES_ANDAMENTO , COD_USUARIO ) VALUES ( :VG078-NUM-CERTIFICADO , CURRENT TIMESTAMP , :VG078-DES-ANDAMENTO , :VG078-COD-USUARIO ) END-EXEC */

            var r3020_00_INSERE_ANDAMENTO_DB_INSERT_1_Insert1 = new R3020_00_INSERE_ANDAMENTO_DB_INSERT_1_Insert1()
            {
                VG078_NUM_CERTIFICADO = VG078.DCLVG_ANDAMENTO_PROP.VG078_NUM_CERTIFICADO.ToString(),
                VG078_DES_ANDAMENTO = VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.ToString(),
                VG078_COD_USUARIO = VG078.DCLVG_ANDAMENTO_PROP.VG078_COD_USUARIO.ToString(),
            };

            R3020_00_INSERE_ANDAMENTO_DB_INSERT_1_Insert1.Execute(r3020_00_INSERE_ANDAMENTO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3020_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-INSERT-COBERPROPVA-SECTION */
        private void R3100_00_INSERT_COBERPROPVA_SECTION()
        {
            /*" -7456- MOVE '3100-00-INSERT-COBERPROPVA ' TO PARAGRAFO. */
            _.Move("3100-00-INSERT-COBERPROPVA ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7457- MOVE 'INSERT COBERPROPVA         ' TO COMANDO. */
            _.Move("INSERT COBERPROPVA         ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7459- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7460- IF CANAL-GITEL */

            if (WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_GITEL"])
            {

                /*" -7461- IF PROPOFID-COD-PRODUTO-SIVPF = 77 */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 77)
                {

                    /*" -7462- IF WHOST-IDADE < 66 */

                    if (WHOST_IDADE < 66)
                    {

                        /*" -7464- COMPUTE COBERP-IMPMORNATU = PROPOFID-VAL-PAGO / 0,01449 */
                        COBERP_IMPMORNATU.Value = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO / 0.01449f;

                        /*" -7465- ELSE */
                    }
                    else
                    {


                        /*" -7467- COMPUTE COBERP-IMPMORNATU = PROPOFID-VAL-PAGO / 0,06600 */
                        COBERP_IMPMORNATU.Value = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO / 0.06600f;

                        /*" -7468- END-IF */
                    }


                    /*" -7470- MOVE COBERP-IMPMORNATU TO IMPMORNATU OF DCLPLANOS-VA-VGAP */
                    _.Move(COBERP_IMPMORNATU, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU);

                    /*" -7472- MOVE COBERP-IMPMORNATU TO IMPMORACID OF DCLPLANOS-VA-VGAP */
                    _.Move(COBERP_IMPMORNATU, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORACID);

                    /*" -7475- MOVE PROPOFID-VAL-PAGO TO VLPREMIOTOT OF DCLPLANOS-VA-VGAP PRMVG OF DCLPLANOS-VA-VGAP */
                    _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO, PLVAVGAP.DCLPLANOS_VA_VGAP.VLPREMIOTOT, PLVAVGAP.DCLPLANOS_VA_VGAP.PRMVG);

                    /*" -7476- END-IF */
                }


                /*" -7478- END-IF. */
            }


            /*" -7479- IF PROPOFID-COD-PRODUTO-SIVPF = 54 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 54)
            {

                /*" -7480- PERFORM R3105-00-SELECT-HISCOBPR-AZUL */

                R3105_00_SELECT_HISCOBPR_AZUL_SECTION();

                /*" -7482- END-IF */
            }


            /*" -7483- MOVE 58 TO SII */
            _.Move(58, WS_HORAS.SII);

            /*" -7484- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -7549- PERFORM R3100_00_INSERT_COBERPROPVA_DB_INSERT_1 */

            R3100_00_INSERT_COBERPROPVA_DB_INSERT_1();

            /*" -7552- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -7554- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL -803 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
            {

                /*" -7555- DISPLAY 'PROBLEMAS NO INSERT COBERPROPVA' */
                _.Display($"PROBLEMAS NO INSERT COBERPROPVA");

                /*" -7556- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -7556- . */

        }

        [StopWatch]
        /*" R3100-00-INSERT-COBERPROPVA-DB-INSERT-1 */
        public void R3100_00_INSERT_COBERPROPVA_DB_INSERT_1()
        {
            /*" -7549- EXEC SQL INSERT INTO SEGUROS.HIS_COBER_PROPOST (NUM_CERTIFICADO , OCORR_HISTORICO , DATA_INIVIGENCIA , DATA_TERVIGENCIA , IMPSEGUR , QUANT_VIDAS , IMPSEGIND , COD_OPERACAO , OPCAO_COBERTURA , IMP_MORNATU , IMPMORACID , IMPINVPERM , IMPAMDS , IMPDH , IMPDIT , VLPREMIO , PRMVG , PRMAP , QTDE_TIT_CAPITALIZ, VAL_TIT_CAPITALIZ , VAL_CUSTO_CAPITALI, IMPSEGCDG , VLCUSTCDG , COD_USUARIO , TIMESTAMP , IMPSEGAUXF , VLCUSTAUXF , PRMDIT , QTMDIT) VALUES (:DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF, 1, :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO, '9999-12-31' , :DCLPLANOS-VA-VGAP.IMPMORNATU, 0, :DCLPLANOS-VA-VGAP.IMPMORNATU, 106, :DCLPROPOSTA-FIDELIZ.PROPOFID-OPCAO-COBER, :DCLPLANOS-VA-VGAP.IMPMORNATU, :DCLPLANOS-VA-VGAP.IMPMORACID, :DCLPLANOS-VA-VGAP.IMPINVPERM, :DCLPLANOS-VA-VGAP.IMPAMDS, :DCLPLANOS-VA-VGAP.IMPDH, :DCLPLANOS-VA-VGAP.IMPDIT, :DCLPLANOS-VA-VGAP.VLPREMIOTOT, :DCLPLANOS-VA-VGAP.PRMVG, :DCLPLANOS-VA-VGAP.PRMAP, :DCLPLANOS-VA-VGAP.QTTITCAP, :DCLPLANOS-VA-VGAP.VLTITCAP, :DCLPLANOS-VA-VGAP.VLCUSTCAP, :DCLPLANOS-VA-VGAP.IMPSEGCDG, :DCLPLANOS-VA-VGAP.VLCUSTCDG, 'VA0601B' , CURRENT TIMESTAMP, :DCLPLANOS-VA-VGAP.IMPSEGAUXF :VIND-IMPSEGAUXF, :DCLPLANOS-VA-VGAP.VLCUSTAUXF :VIND-VLCUSTAUXF, :DCLPLANOS-VA-VGAP.PRMDIT :VIND-PRMDIT, :DCLPLANOS-VA-VGAP.QTDIT :VIND-QTDIT) END-EXEC. */

            var r3100_00_INSERT_COBERPROPVA_DB_INSERT_1_Insert1 = new R3100_00_INSERT_COBERPROPVA_DB_INSERT_1_Insert1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                PROPOFID_DTQITBCO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.ToString(),
                IMPMORNATU = PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU.ToString(),
                PROPOFID_OPCAO_COBER = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER.ToString(),
                IMPMORACID = PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORACID.ToString(),
                IMPINVPERM = PLVAVGAP.DCLPLANOS_VA_VGAP.IMPINVPERM.ToString(),
                IMPAMDS = PLVAVGAP.DCLPLANOS_VA_VGAP.IMPAMDS.ToString(),
                IMPDH = PLVAVGAP.DCLPLANOS_VA_VGAP.IMPDH.ToString(),
                IMPDIT = PLVAVGAP.DCLPLANOS_VA_VGAP.IMPDIT.ToString(),
                VLPREMIOTOT = PLVAVGAP.DCLPLANOS_VA_VGAP.VLPREMIOTOT.ToString(),
                PRMVG = PLVAVGAP.DCLPLANOS_VA_VGAP.PRMVG.ToString(),
                PRMAP = PLVAVGAP.DCLPLANOS_VA_VGAP.PRMAP.ToString(),
                QTTITCAP = PLVAVGAP.DCLPLANOS_VA_VGAP.QTTITCAP.ToString(),
                VLTITCAP = PLVAVGAP.DCLPLANOS_VA_VGAP.VLTITCAP.ToString(),
                VLCUSTCAP = PLVAVGAP.DCLPLANOS_VA_VGAP.VLCUSTCAP.ToString(),
                IMPSEGCDG = PLVAVGAP.DCLPLANOS_VA_VGAP.IMPSEGCDG.ToString(),
                VLCUSTCDG = PLVAVGAP.DCLPLANOS_VA_VGAP.VLCUSTCDG.ToString(),
                IMPSEGAUXF = PLVAVGAP.DCLPLANOS_VA_VGAP.IMPSEGAUXF.ToString(),
                VIND_IMPSEGAUXF = VIND_IMPSEGAUXF.ToString(),
                VLCUSTAUXF = PLVAVGAP.DCLPLANOS_VA_VGAP.VLCUSTAUXF.ToString(),
                VIND_VLCUSTAUXF = VIND_VLCUSTAUXF.ToString(),
                PRMDIT = PLVAVGAP.DCLPLANOS_VA_VGAP.PRMDIT.ToString(),
                VIND_PRMDIT = VIND_PRMDIT.ToString(),
                QTDIT = PLVAVGAP.DCLPLANOS_VA_VGAP.QTDIT.ToString(),
                VIND_QTDIT = VIND_QTDIT.ToString(),
            };

            R3100_00_INSERT_COBERPROPVA_DB_INSERT_1_Insert1.Execute(r3100_00_INSERT_COBERPROPVA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R3105-00-SELECT-HISCOBPR-AZUL-SECTION */
        private void R3105_00_SELECT_HISCOBPR_AZUL_SECTION()
        {
            /*" -7566- MOVE 'R3105-00-SELECT-HISCOBPR-AZUL' TO PARAGRAFO */
            _.Move("R3105-00-SELECT-HISCOBPR-AZUL", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7567- MOVE 'SELECT HISCOBPR AZUL' TO COMANDO. */
            _.Move("SELECT HISCOBPR AZUL", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7569- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7636- PERFORM R3105_00_SELECT_HISCOBPR_AZUL_DB_SELECT_1 */

            R3105_00_SELECT_HISCOBPR_AZUL_DB_SELECT_1();

            /*" -7639- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7640- DISPLAY 'PROBLEMAS NO SELECT HISCOBPR AZUL' */
                _.Display($"PROBLEMAS NO SELECT HISCOBPR AZUL");

                /*" -7641- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -7643- END-IF */
            }


            /*" -7645- MOVE WHOST-IMP-MORNATU TO IMPMORNATU OF DCLPLANOS-VA-VGAP */
            _.Move(WHOST_IMP_MORNATU, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU);

            /*" -7647- MOVE WHOST-IMPMORACID TO IMPMORACID OF DCLPLANOS-VA-VGAP */
            _.Move(WHOST_IMPMORACID, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORACID);

            /*" -7649- MOVE WHOST-IMPINVPERM TO IMPINVPERM OF DCLPLANOS-VA-VGAP */
            _.Move(WHOST_IMPINVPERM, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPINVPERM);

            /*" -7651- MOVE WHOST-IMPAMDS TO IMPAMDS OF DCLPLANOS-VA-VGAP */
            _.Move(WHOST_IMPAMDS, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPAMDS);

            /*" -7653- MOVE WHOST-IMPDH TO IMPDH OF DCLPLANOS-VA-VGAP */
            _.Move(WHOST_IMPDH, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPDH);

            /*" -7655- MOVE WHOST-IMPDIT TO IMPDIT OF DCLPLANOS-VA-VGAP */
            _.Move(WHOST_IMPDIT, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPDIT);

            /*" -7658- MOVE RCAPS-VAL-RCAP OF DCLRCAPS TO VLPREMIOTOT OF DCLPLANOS-VA-VGAP PRMVG OF DCLPLANOS-VA-VGAP */
            _.Move(RCAPS.DCLRCAPS.RCAPS_VAL_RCAP, PLVAVGAP.DCLPLANOS_VA_VGAP.VLPREMIOTOT, PLVAVGAP.DCLPLANOS_VA_VGAP.PRMVG);

            /*" -7660- MOVE ZEROS TO PRMAP OF DCLPLANOS-VA-VGAP */
            _.Move(0, PLVAVGAP.DCLPLANOS_VA_VGAP.PRMAP);

            /*" -7662- MOVE WHOST-IMPSEGCDG TO IMPSEGCDG OF DCLPLANOS-VA-VGAP */
            _.Move(WHOST_IMPSEGCDG, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPSEGCDG);

            /*" -7664- MOVE WHOST-VLCUSTCDG TO VLCUSTCDG OF DCLPLANOS-VA-VGAP */
            _.Move(WHOST_VLCUSTCDG, PLVAVGAP.DCLPLANOS_VA_VGAP.VLCUSTCDG);

            /*" -7666- MOVE WHOST-IMPSEGAUXF TO IMPSEGAUXF OF DCLPLANOS-VA-VGAP */
            _.Move(WHOST_IMPSEGAUXF, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPSEGAUXF);

            /*" -7668- MOVE WHOST-VLCUSTAUXF TO VLCUSTAUXF OF DCLPLANOS-VA-VGAP */
            _.Move(WHOST_VLCUSTAUXF, PLVAVGAP.DCLPLANOS_VA_VGAP.VLCUSTAUXF);

            /*" -7670- MOVE WHOST-PRMDIT TO PRMDIT OF DCLPLANOS-VA-VGAP */
            _.Move(WHOST_PRMDIT, PLVAVGAP.DCLPLANOS_VA_VGAP.PRMDIT);

            /*" -7672- MOVE WHOST-QTMDIT TO QTDIT OF DCLPLANOS-VA-VGAP */
            _.Move(WHOST_QTMDIT, PLVAVGAP.DCLPLANOS_VA_VGAP.QTDIT);

            /*" -7672- . */

        }

        [StopWatch]
        /*" R3105-00-SELECT-HISCOBPR-AZUL-DB-SELECT-1 */
        public void R3105_00_SELECT_HISCOBPR_AZUL_DB_SELECT_1()
        {
            /*" -7636- EXEC SQL SELECT B.NUM_CERTIFICADO ,B.OCORR_HISTORICO ,B.DATA_INIVIGENCIA ,B.DATA_TERVIGENCIA ,B.IMPSEGUR ,B.QUANT_VIDAS ,B.IMPSEGIND ,B.COD_OPERACAO ,B.OPCAO_COBERTURA ,B.IMP_MORNATU ,B.IMPMORACID ,B.IMPINVPERM ,B.IMPAMDS ,B.IMPDH ,B.IMPDIT ,B.VLPREMIO ,B.PRMVG ,B.PRMAP ,B.QTDE_TIT_CAPITALIZ ,B.VAL_TIT_CAPITALIZ ,B.VAL_CUSTO_CAPITALI ,B.IMPSEGCDG ,B.VLCUSTCDG ,B.COD_USUARIO ,B.TIMESTAMP ,B.IMPSEGAUXF ,B.VLCUSTAUXF ,B.PRMDIT ,B.QTMDIT INTO :WHOST-NUM-CERTIFICADO ,:WHOST-OCORR-HISTORICO ,:WHOST-DATA-INIVIGENCIA ,:WHOST-DATA-TERVIGENCIA ,:WHOST-IMPSEGUR ,:WHOST-QUANT-VIDAS ,:WHOST-IMPSEGIND ,:WHOST-COD-OPERACAO ,:WHOST-OPCAO-COBERTURA ,:WHOST-IMP-MORNATU ,:WHOST-IMPMORACID ,:WHOST-IMPINVPERM ,:WHOST-IMPAMDS ,:WHOST-IMPDH ,:WHOST-IMPDIT ,:WHOST-VLPREMIO ,:WHOST-PRMVG ,:WHOST-PRMAP ,:WHOST-QTDE-TIT-CAPITALIZ ,:WHOST-VAL-TIT-CAPITALIZ ,:WHOST-VAL-CUSTO-CAPITALI ,:WHOST-IMPSEGCDG ,:WHOST-VLCUSTCDG ,:WHOST-COD-USUARIO ,:WHOST-TIMESTAMP ,:WHOST-IMPSEGAUXF ,:WHOST-VLCUSTAUXF ,:WHOST-PRMDIT ,:WHOST-QTMDIT FROM SEGUROS.RELATORIOS A , SEGUROS.HIS_COBER_PROPOST B WHERE A.NUM_SINISTRO = :DCLPESSOA-FISICA.CPF AND B.NUM_CERTIFICADO = A.NUM_CERTIFICADO AND B.DATA_TERVIGENCIA = '9999-12-31' FETCH FIRST ROWS ONLY END-EXEC. */

            var r3105_00_SELECT_HISCOBPR_AZUL_DB_SELECT_1_Query1 = new R3105_00_SELECT_HISCOBPR_AZUL_DB_SELECT_1_Query1()
            {
                CPF = PESFIS.DCLPESSOA_FISICA.CPF.ToString(),
            };

            var executed_1 = R3105_00_SELECT_HISCOBPR_AZUL_DB_SELECT_1_Query1.Execute(r3105_00_SELECT_HISCOBPR_AZUL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_NUM_CERTIFICADO, WHOST_NUM_CERTIFICADO);
                _.Move(executed_1.WHOST_OCORR_HISTORICO, WHOST_OCORR_HISTORICO);
                _.Move(executed_1.WHOST_DATA_INIVIGENCIA, WHOST_DATA_INIVIGENCIA);
                _.Move(executed_1.WHOST_DATA_TERVIGENCIA, WHOST_DATA_TERVIGENCIA);
                _.Move(executed_1.WHOST_IMPSEGUR, WHOST_IMPSEGUR);
                _.Move(executed_1.WHOST_QUANT_VIDAS, WHOST_QUANT_VIDAS);
                _.Move(executed_1.WHOST_IMPSEGIND, WHOST_IMPSEGIND);
                _.Move(executed_1.WHOST_COD_OPERACAO, WHOST_COD_OPERACAO);
                _.Move(executed_1.WHOST_OPCAO_COBERTURA, WHOST_OPCAO_COBERTURA);
                _.Move(executed_1.WHOST_IMP_MORNATU, WHOST_IMP_MORNATU);
                _.Move(executed_1.WHOST_IMPMORACID, WHOST_IMPMORACID);
                _.Move(executed_1.WHOST_IMPINVPERM, WHOST_IMPINVPERM);
                _.Move(executed_1.WHOST_IMPAMDS, WHOST_IMPAMDS);
                _.Move(executed_1.WHOST_IMPDH, WHOST_IMPDH);
                _.Move(executed_1.WHOST_IMPDIT, WHOST_IMPDIT);
                _.Move(executed_1.WHOST_VLPREMIO, WHOST_VLPREMIO);
                _.Move(executed_1.WHOST_PRMVG, WHOST_PRMVG);
                _.Move(executed_1.WHOST_PRMAP, WHOST_PRMAP);
                _.Move(executed_1.WHOST_QTDE_TIT_CAPITALIZ, WHOST_QTDE_TIT_CAPITALIZ);
                _.Move(executed_1.WHOST_VAL_TIT_CAPITALIZ, WHOST_VAL_TIT_CAPITALIZ);
                _.Move(executed_1.WHOST_VAL_CUSTO_CAPITALI, WHOST_VAL_CUSTO_CAPITALI);
                _.Move(executed_1.WHOST_IMPSEGCDG, WHOST_IMPSEGCDG);
                _.Move(executed_1.WHOST_VLCUSTCDG, WHOST_VLCUSTCDG);
                _.Move(executed_1.WHOST_COD_USUARIO, WHOST_COD_USUARIO);
                _.Move(executed_1.WHOST_TIMESTAMP, WHOST_TIMESTAMP);
                _.Move(executed_1.WHOST_IMPSEGAUXF, WHOST_IMPSEGAUXF);
                _.Move(executed_1.WHOST_VLCUSTAUXF, WHOST_VLCUSTAUXF);
                _.Move(executed_1.WHOST_PRMDIT, WHOST_PRMDIT);
                _.Move(executed_1.WHOST_QTMDIT, WHOST_QTMDIT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3105_99_FIM*/

        [StopWatch]
        /*" R3110-00-DECLARE-VGPLARAMCOB-SECTION */
        private void R3110_00_DECLARE_VGPLARAMCOB_SECTION()
        {
            /*" -7682- MOVE 'R3110-00-DECLARE-VGPLARAMCOB ' TO PARAGRAFO */
            _.Move("R3110-00-DECLARE-VGPLARAMCOB ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7683- MOVE 'DECLARE VGPLARAMC' TO COMANDO. */
            _.Move("DECLARE VGPLARAMC", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7685- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7710- PERFORM R3110_00_DECLARE_VGPLARAMCOB_DB_DECLARE_1 */

            R3110_00_DECLARE_VGPLARAMCOB_DB_DECLARE_1();

            /*" -7714- MOVE 'OPEN  VGPLARAMC' TO COMANDO. */
            _.Move("OPEN  VGPLARAMC", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7715- MOVE 59 TO SII */
            _.Move(59, WS_HORAS.SII);

            /*" -7716- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -7716- PERFORM R3110_00_DECLARE_VGPLARAMCOB_DB_OPEN_1 */

            R3110_00_DECLARE_VGPLARAMCOB_DB_OPEN_1();

            /*" -7719- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -7721- MOVE SPACES TO WFIM-VGPLARAMC. */
            _.Move("", WORK_AREA.WFIM_VGPLARAMC);

            /*" -7722- PERFORM R3120-00-FETCH-VGPLARAMC UNTIL WFIM-VGPLARAMC NOT EQUAL SPACES. */

            while (!(!WORK_AREA.WFIM_VGPLARAMC.IsEmpty()))
            {

                R3120_00_FETCH_VGPLARAMC_SECTION();
            }

        }

        [StopWatch]
        /*" R3110-00-DECLARE-VGPLARAMCOB-DB-OPEN-1 */
        public void R3110_00_DECLARE_VGPLARAMCOB_DB_OPEN_1()
        {
            /*" -7716- EXEC SQL OPEN VGPLARAMC END-EXEC. */

            VGPLARAMC.Open();

        }

        [StopWatch]
        /*" R3150-00-DECLARE-VGPLAACES-DB-DECLARE-1 */
        public void R3150_00_DECLARE_VGPLAACES_DB_DECLARE_1()
        {
            /*" -7820- EXEC SQL DECLARE VGPLAACES CURSOR FOR SELECT NUM_ACESSORIO, QTD_COBERTURA, VLR_IMP_SEGURADA, VLR_CUSTO, VLR_PREMIO FROM SEGUROS.VG_PLANO_ACESSORIO WHERE NUM_APOLICE = :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE AND CODSUBES = :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO AND OPCAO_COBER = :DCLPROPOSTA-FIDELIZ.PROPOFID-OPCAO-COBER AND DTINIVIG <= :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO AND DTTERVIG >= :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO AND IDADE_INICIAL <= :WHOST-IDADE AND IDADE_FINAL >= :WHOST-IDADE AND PERIPGTO = :DCLPRODUTOS-VG.PRODUVG-PERI-PAGAMENTO ORDER BY NUM_ACESSORIO END-EXEC. */
            VGPLAACES = new VA0601B_VGPLAACES(true);
            string GetQuery_VGPLAACES()
            {
                var query = @$"SELECT NUM_ACESSORIO
							, 
							QTD_COBERTURA
							, 
							VLR_IMP_SEGURADA
							, 
							VLR_CUSTO
							, 
							VLR_PREMIO 
							FROM SEGUROS.VG_PLANO_ACESSORIO 
							WHERE NUM_APOLICE = 
							'{PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE}' 
							AND CODSUBES = 
							'{PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO}' 
							AND OPCAO_COBER = 
							'{PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER}' 
							AND DTINIVIG <= 
							'{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND DTTERVIG >= 
							'{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND IDADE_INICIAL <= '{WHOST_IDADE}' 
							AND IDADE_FINAL >= '{WHOST_IDADE}' 
							AND PERIPGTO = 
							'{PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO}' 
							ORDER BY NUM_ACESSORIO";

                return query;
            }
            VGPLAACES.GetQueryEvent += GetQuery_VGPLAACES;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3110_99_FIM*/

        [StopWatch]
        /*" R3120-00-FETCH-VGPLARAMC-SECTION */
        private void R3120_00_FETCH_VGPLARAMC_SECTION()
        {
            /*" -7732- MOVE 'R3120-00-FETCH-VGPLARAMC    ' TO PARAGRAFO */
            _.Move("R3120-00-FETCH-VGPLARAMC    ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7733- MOVE 'FETCH VGPLARAMC' TO COMANDO. */
            _.Move("FETCH VGPLARAMC", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7735- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7736- MOVE 60 TO SII */
            _.Move(60, WS_HORAS.SII);

            /*" -7737- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -7745- PERFORM R3120_00_FETCH_VGPLARAMC_DB_FETCH_1 */

            R3120_00_FETCH_VGPLARAMC_DB_FETCH_1();

            /*" -7748- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -7749- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -7750- MOVE 'S' TO WFIM-VGPLARAMC */
                _.Move("S", WORK_AREA.WFIM_VGPLARAMC);

                /*" -7750- PERFORM R3120_00_FETCH_VGPLARAMC_DB_CLOSE_1 */

                R3120_00_FETCH_VGPLARAMC_DB_CLOSE_1();

                /*" -7753- GO TO R3120-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3120_99_SAIDA*/ //GOTO
                return;
            }


            /*" -7753- PERFORM R3130-00-INSERT-VGHISTRAMCOB. */

            R3130_00_INSERT_VGHISTRAMCOB_SECTION();

        }

        [StopWatch]
        /*" R3120-00-FETCH-VGPLARAMC-DB-FETCH-1 */
        public void R3120_00_FETCH_VGPLARAMC_DB_FETCH_1()
        {
            /*" -7745- EXEC SQL FETCH VGPLARAMC INTO :VGPLAR-NUM-RAMO, :VGPLAR-NUM-COBERTURA, :VGPLAR-QTD-COBERTURA, :VGPLAR-IMPSEGURADA, :VGPLAR-CUSTO, :VGPLAR-PREMIO END-EXEC. */

            if (VGPLARAMC.Fetch())
            {
                _.Move(VGPLARAMC.VGPLAR_NUM_RAMO, VGPLAR_NUM_RAMO);
                _.Move(VGPLARAMC.VGPLAR_NUM_COBERTURA, VGPLAR_NUM_COBERTURA);
                _.Move(VGPLARAMC.VGPLAR_QTD_COBERTURA, VGPLAR_QTD_COBERTURA);
                _.Move(VGPLARAMC.VGPLAR_IMPSEGURADA, VGPLAR_IMPSEGURADA);
                _.Move(VGPLARAMC.VGPLAR_CUSTO, VGPLAR_CUSTO);
                _.Move(VGPLARAMC.VGPLAR_PREMIO, VGPLAR_PREMIO);
            }

        }

        [StopWatch]
        /*" R3120-00-FETCH-VGPLARAMC-DB-CLOSE-1 */
        public void R3120_00_FETCH_VGPLARAMC_DB_CLOSE_1()
        {
            /*" -7750- EXEC SQL CLOSE VGPLARAMC END-EXEC */

            VGPLARAMC.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3120_99_SAIDA*/

        [StopWatch]
        /*" R3130-00-INSERT-VGHISTRAMCOB-SECTION */
        private void R3130_00_INSERT_VGHISTRAMCOB_SECTION()
        {
            /*" -7762- MOVE 'R3130-00-INSERT-VGHISTRAMCOB ' TO PARAGRAFO. */
            _.Move("R3130-00-INSERT-VGHISTRAMCOB ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7763- MOVE 'INSERT VG_HIST_RAMO_COB' TO COMANDO. */
            _.Move("INSERT VG_HIST_RAMO_COB", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7765- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7766- MOVE 61 TO SII */
            _.Move(61, WS_HORAS.SII);

            /*" -7767- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -7777- PERFORM R3130_00_INSERT_VGHISTRAMCOB_DB_INSERT_1 */

            R3130_00_INSERT_VGHISTRAMCOB_DB_INSERT_1();

            /*" -7780- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -7782- IF SQLCODE NOT EQUAL ZEROES AND SQLCODE NOT EQUAL -803 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
            {

                /*" -7784- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -7784- ADD 1 TO AC-I-HISTRAMOCOB. */
            WORK_AREA.AC_I_HISTRAMOCOB.Value = WORK_AREA.AC_I_HISTRAMOCOB + 1;

        }

        [StopWatch]
        /*" R3130-00-INSERT-VGHISTRAMCOB-DB-INSERT-1 */
        public void R3130_00_INSERT_VGHISTRAMCOB_DB_INSERT_1()
        {
            /*" -7777- EXEC SQL INSERT INTO SEGUROS.VG_HIST_RAMO_COB VALUES (:DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF, 1, :VGPLAR-NUM-RAMO, :VGPLAR-NUM-COBERTURA, :VGPLAR-QTD-COBERTURA, :VGPLAR-IMPSEGURADA, :VGPLAR-CUSTO, :VGPLAR-PREMIO) END-EXEC. */

            var r3130_00_INSERT_VGHISTRAMCOB_DB_INSERT_1_Insert1 = new R3130_00_INSERT_VGHISTRAMCOB_DB_INSERT_1_Insert1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                VGPLAR_NUM_RAMO = VGPLAR_NUM_RAMO.ToString(),
                VGPLAR_NUM_COBERTURA = VGPLAR_NUM_COBERTURA.ToString(),
                VGPLAR_QTD_COBERTURA = VGPLAR_QTD_COBERTURA.ToString(),
                VGPLAR_IMPSEGURADA = VGPLAR_IMPSEGURADA.ToString(),
                VGPLAR_CUSTO = VGPLAR_CUSTO.ToString(),
                VGPLAR_PREMIO = VGPLAR_PREMIO.ToString(),
            };

            R3130_00_INSERT_VGHISTRAMCOB_DB_INSERT_1_Insert1.Execute(r3130_00_INSERT_VGHISTRAMCOB_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3130_99_FIM*/

        [StopWatch]
        /*" R3150-00-DECLARE-VGPLAACES-SECTION */
        private void R3150_00_DECLARE_VGPLAACES_SECTION()
        {
            /*" -7794- MOVE 'R3150-00-DECLARE-VGPLAACES' TO PARAGRAFO */
            _.Move("R3150-00-DECLARE-VGPLAACES", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7795- MOVE 'DECLARE VGPLAACES ' TO COMANDO. */
            _.Move("DECLARE VGPLAACES ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7797- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7820- PERFORM R3150_00_DECLARE_VGPLAACES_DB_DECLARE_1 */

            R3150_00_DECLARE_VGPLAACES_DB_DECLARE_1();

            /*" -7824- MOVE 'OPEN  VGPLAACES' TO COMANDO. */
            _.Move("OPEN  VGPLAACES", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7825- MOVE 62 TO SII */
            _.Move(62, WS_HORAS.SII);

            /*" -7826- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -7826- PERFORM R3150_00_DECLARE_VGPLAACES_DB_OPEN_1 */

            R3150_00_DECLARE_VGPLAACES_DB_OPEN_1();

            /*" -7829- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -7831- MOVE SPACES TO WFIM-VGPLAACES. */
            _.Move("", WORK_AREA.WFIM_VGPLAACES);

            /*" -7832- PERFORM R3160-00-FETCH-VGPLAACES UNTIL WFIM-VGPLAACES NOT EQUAL SPACES. */

            while (!(!WORK_AREA.WFIM_VGPLAACES.IsEmpty()))
            {

                R3160_00_FETCH_VGPLAACES_SECTION();
            }

        }

        [StopWatch]
        /*" R3150-00-DECLARE-VGPLAACES-DB-OPEN-1 */
        public void R3150_00_DECLARE_VGPLAACES_DB_OPEN_1()
        {
            /*" -7826- EXEC SQL OPEN VGPLAACES END-EXEC. */

            VGPLAACES.Open();

        }

        [StopWatch]
        /*" R4300-00-TRATA-CLIENTE-EMPRESA-DB-DECLARE-1 */
        public void R4300_00_TRATA_CLIENTE_EMPRESA_DB_DECLARE_1()
        {
            /*" -8744- EXEC SQL DECLARE CEMPRESA CURSOR FOR SELECT COD_CLIENTE FROM SEGUROS.CLIENTES WHERE CGCCPF = :WHOST-CGCCPF ORDER BY COD_CLIENTE DESC END-EXEC. */
            CEMPRESA = new VA0601B_CEMPRESA(true);
            string GetQuery_CEMPRESA()
            {
                var query = @$"SELECT COD_CLIENTE 
							FROM SEGUROS.CLIENTES 
							WHERE CGCCPF = '{WHOST_CGCCPF}' 
							ORDER BY COD_CLIENTE DESC";

                return query;
            }
            CEMPRESA.GetQueryEvent += GetQuery_CEMPRESA;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3150_99_FIM*/

        [StopWatch]
        /*" R3160-00-FETCH-VGPLAACES-SECTION */
        private void R3160_00_FETCH_VGPLAACES_SECTION()
        {
            /*" -7842- MOVE 'R3160-00-FETCH-VGPLAACES     ' TO PARAGRAFO. */
            _.Move("R3160-00-FETCH-VGPLAACES     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7843- MOVE 'FETCH VGPLAACES' TO COMANDO. */
            _.Move("FETCH VGPLAACES", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7845- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7846- MOVE 63 TO SII */
            _.Move(63, WS_HORAS.SII);

            /*" -7847- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -7854- PERFORM R3160_00_FETCH_VGPLAACES_DB_FETCH_1 */

            R3160_00_FETCH_VGPLAACES_DB_FETCH_1();

            /*" -7857- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -7858- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -7859- MOVE 'S' TO WFIM-VGPLAACES */
                _.Move("S", WORK_AREA.WFIM_VGPLAACES);

                /*" -7859- PERFORM R3160_00_FETCH_VGPLAACES_DB_CLOSE_1 */

                R3160_00_FETCH_VGPLAACES_DB_CLOSE_1();

                /*" -7862- GO TO R3160-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3160_99_SAIDA*/ //GOTO
                return;
            }


            /*" -7862- PERFORM R3170-00-INSERT-VGHISACESSCOB. */

            R3170_00_INSERT_VGHISACESSCOB_SECTION();

        }

        [StopWatch]
        /*" R3160-00-FETCH-VGPLAACES-DB-FETCH-1 */
        public void R3160_00_FETCH_VGPLAACES_DB_FETCH_1()
        {
            /*" -7854- EXEC SQL FETCH VGPLAACES INTO :VGPLAA-NUM-ACESSORIO, :VGPLAA-QTD-COBERTURA, :VGPLAA-IMPSEGURADA, :VGPLAA-CUSTO, :VGPLAA-PREMIO END-EXEC. */

            if (VGPLAACES.Fetch())
            {
                _.Move(VGPLAACES.VGPLAA_NUM_ACESSORIO, VGPLAA_NUM_ACESSORIO);
                _.Move(VGPLAACES.VGPLAA_QTD_COBERTURA, VGPLAA_QTD_COBERTURA);
                _.Move(VGPLAACES.VGPLAA_IMPSEGURADA, VGPLAA_IMPSEGURADA);
                _.Move(VGPLAACES.VGPLAA_CUSTO, VGPLAA_CUSTO);
                _.Move(VGPLAACES.VGPLAA_PREMIO, VGPLAA_PREMIO);
            }

        }

        [StopWatch]
        /*" R3160-00-FETCH-VGPLAACES-DB-CLOSE-1 */
        public void R3160_00_FETCH_VGPLAACES_DB_CLOSE_1()
        {
            /*" -7859- EXEC SQL CLOSE VGPLAACES END-EXEC */

            VGPLAACES.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3160_99_SAIDA*/

        [StopWatch]
        /*" R3170-00-INSERT-VGHISACESSCOB-SECTION */
        private void R3170_00_INSERT_VGHISACESSCOB_SECTION()
        {
            /*" -7872- MOVE 'R3170-00-INSERT-VGHISACESSCOB' TO PARAGRAFO. */
            _.Move("R3170-00-INSERT-VGHISACESSCOB", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7873- MOVE 'INSERT VG_HIST_ACESS_COB' TO COMANDO. */
            _.Move("INSERT VG_HIST_ACESS_COB", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7875- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7876- MOVE 64 TO SII */
            _.Move(64, WS_HORAS.SII);

            /*" -7877- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -7886- PERFORM R3170_00_INSERT_VGHISACESSCOB_DB_INSERT_1 */

            R3170_00_INSERT_VGHISACESSCOB_DB_INSERT_1();

            /*" -7889- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -7891- IF SQLCODE NOT EQUAL ZEROES AND SQLCODE NOT EQUAL -803 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
            {

                /*" -7893- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -7893- ADD 1 TO AC-I-HISTACESCOB. */
            WORK_AREA.AC_I_HISTACESCOB.Value = WORK_AREA.AC_I_HISTACESCOB + 1;

        }

        [StopWatch]
        /*" R3170-00-INSERT-VGHISACESSCOB-DB-INSERT-1 */
        public void R3170_00_INSERT_VGHISACESSCOB_DB_INSERT_1()
        {
            /*" -7886- EXEC SQL INSERT INTO SEGUROS.VG_HIST_ACESS_COB VALUES (:DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF, 1, :VGPLAA-NUM-ACESSORIO, :VGPLAA-QTD-COBERTURA, :VGPLAA-IMPSEGURADA, :VGPLAA-CUSTO, :VGPLAA-PREMIO) END-EXEC. */

            var r3170_00_INSERT_VGHISACESSCOB_DB_INSERT_1_Insert1 = new R3170_00_INSERT_VGHISACESSCOB_DB_INSERT_1_Insert1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                VGPLAA_NUM_ACESSORIO = VGPLAA_NUM_ACESSORIO.ToString(),
                VGPLAA_QTD_COBERTURA = VGPLAA_QTD_COBERTURA.ToString(),
                VGPLAA_IMPSEGURADA = VGPLAA_IMPSEGURADA.ToString(),
                VGPLAA_CUSTO = VGPLAA_CUSTO.ToString(),
                VGPLAA_PREMIO = VGPLAA_PREMIO.ToString(),
            };

            R3170_00_INSERT_VGHISACESSCOB_DB_INSERT_1_Insert1.Execute(r3170_00_INSERT_VGHISACESSCOB_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3170_99_FIM*/

        [StopWatch]
        /*" R3200-00-INSERT-OPCAOPAGVA-SECTION */
        private void R3200_00_INSERT_OPCAOPAGVA_SECTION()
        {
            /*" -7902- MOVE '3200-00-INSERT-OPCAOPAGVA  ' TO PARAGRAFO. */
            _.Move("3200-00-INSERT-OPCAOPAGVA  ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7903- MOVE 'INSERT OPCAOPAGVA  ' TO COMANDO. */
            _.Move("INSERT OPCAOPAGVA  ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7905- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7912- MOVE PROPOFID-OPCAOPAG OF DCLPROPOSTA-FIDELIZ TO WHOST-OPCAOPAG. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAOPAG, WHOST_OPCAOPAG);

            /*" -7913- EVALUATE WHOST-OPCAOPAG */
            switch (WHOST_OPCAOPAG.Value.Trim())
            {

                /*" -7914- WHEN '3' */
                case "3":

                    /*" -7915- MOVE '5' TO WHOST-OPCAOPAG */
                    _.Move("5", WHOST_OPCAOPAG);

                    /*" -7916- IF WS-PROD-BALCAO = 'S' */

                    if (WS_PROD_BALCAO == "S")
                    {

                        /*" -7920- MOVE +0 TO VIND-AGECTADEB VIND-OPRCTADEB VIND-NUMCTADEB VIND-DIGCTADEB */
                        _.Move(+0, VIND_AGECTADEB, VIND_OPRCTADEB, VIND_NUMCTADEB, VIND_DIGCTADEB);

                        /*" -7921- ELSE */
                    }
                    else
                    {


                        /*" -7925- MOVE -1 TO VIND-AGECTADEB VIND-OPRCTADEB VIND-NUMCTADEB VIND-DIGCTADEB */
                        _.Move(-1, VIND_AGECTADEB, VIND_OPRCTADEB, VIND_NUMCTADEB, VIND_DIGCTADEB);

                        /*" -7929- END-IF */
                    }


                    /*" -7930- WHEN '1' */
                    break;
                case "1":

                    /*" -7934- MOVE +0 TO VIND-AGECTADEB VIND-OPRCTADEB VIND-NUMCTADEB VIND-DIGCTADEB */
                    _.Move(+0, VIND_AGECTADEB, VIND_OPRCTADEB, VIND_NUMCTADEB, VIND_DIGCTADEB);

                    /*" -7936- IF PROPOFID-OPRCTADEB OF DCLPROPOSTA-FIDELIZ EQUAL 13 OR 1288 */

                    if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTADEB.In("13", "1288"))
                    {

                        /*" -7937- MOVE '2' TO WHOST-OPCAOPAG */
                        _.Move("2", WHOST_OPCAOPAG);

                        /*" -7939- END-IF */
                    }


                    /*" -7940- WHEN OTHER */
                    break;
                default:

                    /*" -7941- MOVE '3' TO WHOST-OPCAOPAG */
                    _.Move("3", WHOST_OPCAOPAG);

                    /*" -7942- IF WS-PROD-BALCAO = 'S' */

                    if (WS_PROD_BALCAO == "S")
                    {

                        /*" -7946- MOVE +0 TO VIND-AGECTADEB VIND-OPRCTADEB VIND-NUMCTADEB VIND-DIGCTADEB */
                        _.Move(+0, VIND_AGECTADEB, VIND_OPRCTADEB, VIND_NUMCTADEB, VIND_DIGCTADEB);

                        /*" -7947- ELSE */
                    }
                    else
                    {


                        /*" -7951- MOVE -1 TO VIND-AGECTADEB VIND-OPRCTADEB VIND-NUMCTADEB VIND-DIGCTADEB */
                        _.Move(-1, VIND_AGECTADEB, VIND_OPRCTADEB, VIND_NUMCTADEB, VIND_DIGCTADEB);

                        /*" -7953- END-IF */
                    }


                    /*" -7955- END-EVALUATE */
                    break;
            }


            /*" -7956- MOVE 65 TO SII */
            _.Move(65, WS_HORAS.SII);

            /*" -7957- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -7977- PERFORM R3200_00_INSERT_OPCAOPAGVA_DB_INSERT_1 */

            R3200_00_INSERT_OPCAOPAGVA_DB_INSERT_1();

            /*" -7980- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -7982- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL -803 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
            {

                /*" -7983- DISPLAY 'PROBLEMAS NO INSERT OPCAOPAGVA ' */
                _.Display($"PROBLEMAS NO INSERT OPCAOPAGVA ");

                /*" -7983- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3200-00-INSERT-OPCAOPAGVA-DB-INSERT-1 */
        public void R3200_00_INSERT_OPCAOPAGVA_DB_INSERT_1()
        {
            /*" -7977- EXEC SQL INSERT INTO SEGUROS.OPCAO_PAG_VIDAZUL VALUES (:DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF, :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO, '9999-12-31' , :WHOST-OPCAOPAG, :DCLPRODUTOS-VG.PRODUVG-PERI-PAGAMENTO , :DCLPROPOSTA-FIDELIZ.PROPOFID-DIA-DEBITO, 'VA0601B' , CURRENT TIMESTAMP, :DCLPROPOSTA-FIDELIZ.PROPOFID-AGECTADEB :VIND-AGECTADEB, :DCLPROPOSTA-FIDELIZ.PROPOFID-OPRCTADEB :VIND-OPRCTADEB, :DCLPROPOSTA-FIDELIZ.PROPOFID-NUMCTADEB :VIND-NUMCTADEB, :DCLPROPOSTA-FIDELIZ.PROPOFID-DIGCTADEB :VIND-DIGCTADEB, NULL) END-EXEC. */

            var r3200_00_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1 = new R3200_00_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                PROPOFID_DTQITBCO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.ToString(),
                WHOST_OPCAOPAG = WHOST_OPCAOPAG.ToString(),
                PRODUVG_PERI_PAGAMENTO = PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO.ToString(),
                PROPOFID_DIA_DEBITO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIA_DEBITO.ToString(),
                PROPOFID_AGECTADEB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTADEB.ToString(),
                VIND_AGECTADEB = VIND_AGECTADEB.ToString(),
                PROPOFID_OPRCTADEB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTADEB.ToString(),
                VIND_OPRCTADEB = VIND_OPRCTADEB.ToString(),
                PROPOFID_NUMCTADEB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTADEB.ToString(),
                VIND_NUMCTADEB = VIND_NUMCTADEB.ToString(),
                PROPOFID_DIGCTADEB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTADEB.ToString(),
                VIND_DIGCTADEB = VIND_DIGCTADEB.ToString(),
            };

            R3200_00_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1.Execute(r3200_00_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/

        [StopWatch]
        /*" R3300-00-INSERT-COMISICOBVA-SECTION */
        private void R3300_00_INSERT_COMISICOBVA_SECTION()
        {
            /*" -7993- MOVE '3300-00-INSERT-COMISICOBVA ' TO PARAGRAFO. */
            _.Move("3300-00-INSERT-COMISICOBVA ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7994- MOVE 'INSERT COMISICOBVA ' TO COMANDO. */
            _.Move("INSERT COMISICOBVA ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7996- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7997- MOVE '0' TO SIT-REGISTRO OF DCLCOMISS-ADIAN-SICOB. */
            _.Move("0", COADSICO.DCLCOMISS_ADIAN_SICOB.SIT_REGISTRO);

            /*" -7998- MOVE ' ' TO SIT-FENAE OF DCLCOMISS-ADIAN-SICOB. */
            _.Move(" ", COADSICO.DCLCOMISS_ADIAN_SICOB.SIT_FENAE);

            /*" -8016- MOVE ZEROS TO VAL-COMISSAO-VEN OF DCLCOMISS-ADIAN-SICOB VAL-ADIANTAMENTO OF DCLCOMISS-ADIAN-SICOB ORDEM-PAGAMENTO OF DCLCOMISS-ADIAN-SICOB NUM-ENDOSSO OF DCLCOMISS-ADIAN-SICOB NUM-MATR-GERENTE OF DCLCOMISS-ADIAN-SICOB COD-AGEN-GERENTE OF DCLCOMISS-ADIAN-SICOB OPE-CONTA-GERENTE OF DCLCOMISS-ADIAN-SICOB NUM-CONTA-GERENTE OF DCLCOMISS-ADIAN-SICOB DIG-CONTA-GERENTE OF DCLCOMISS-ADIAN-SICOB VAL-COMIS-GERENTE OF DCLCOMISS-ADIAN-SICOB NUM-MATR-SUN OF DCLCOMISS-ADIAN-SICOB COD-AGEN-SUN OF DCLCOMISS-ADIAN-SICOB OPE-CONTA-SUN OF DCLCOMISS-ADIAN-SICOB NUM-CONTA-SUN OF DCLCOMISS-ADIAN-SICOB DIG-CONTA-SUN OF DCLCOMISS-ADIAN-SICOB VAL-COMIS-SUN OF DCLCOMISS-ADIAN-SICOB. */
            _.Move(0, COADSICO.DCLCOMISS_ADIAN_SICOB.VAL_COMISSAO_VEN, COADSICO.DCLCOMISS_ADIAN_SICOB.VAL_ADIANTAMENTO, COADSICO.DCLCOMISS_ADIAN_SICOB.ORDEM_PAGAMENTO, COADSICO.DCLCOMISS_ADIAN_SICOB.NUM_ENDOSSO, COADSICO.DCLCOMISS_ADIAN_SICOB.NUM_MATR_GERENTE, COADSICO.DCLCOMISS_ADIAN_SICOB.COD_AGEN_GERENTE, COADSICO.DCLCOMISS_ADIAN_SICOB.OPE_CONTA_GERENTE, COADSICO.DCLCOMISS_ADIAN_SICOB.NUM_CONTA_GERENTE, COADSICO.DCLCOMISS_ADIAN_SICOB.DIG_CONTA_GERENTE, COADSICO.DCLCOMISS_ADIAN_SICOB.VAL_COMIS_GERENTE, COADSICO.DCLCOMISS_ADIAN_SICOB.NUM_MATR_SUN, COADSICO.DCLCOMISS_ADIAN_SICOB.COD_AGEN_SUN, COADSICO.DCLCOMISS_ADIAN_SICOB.OPE_CONTA_SUN, COADSICO.DCLCOMISS_ADIAN_SICOB.NUM_CONTA_SUN, COADSICO.DCLCOMISS_ADIAN_SICOB.DIG_CONTA_SUN, COADSICO.DCLCOMISS_ADIAN_SICOB.VAL_COMIS_SUN);

            /*" -8017- MOVE 66 TO SII */
            _.Move(66, WS_HORAS.SII);

            /*" -8018- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -8054- PERFORM R3300_00_INSERT_COMISICOBVA_DB_INSERT_1 */

            R3300_00_INSERT_COMISICOBVA_DB_INSERT_1();

            /*" -8057- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -8058- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -8059- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -8060- MOVE 'SIM' TO WEXISTE-COMISSAO */
                    _.Move("SIM", WEXISTE_COMISSAO);

                    /*" -8061- ELSE */
                }
                else
                {


                    /*" -8062- DISPLAY 'PROBLEMAS NO INSERT COMISICOBVA ' */
                    _.Display($"PROBLEMAS NO INSERT COMISICOBVA ");

                    /*" -8063- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -8064- ELSE */
                }

            }
            else
            {


                /*" -8064- MOVE 'NAO' TO WEXISTE-COMISSAO. */
                _.Move("NAO", WEXISTE_COMISSAO);
            }


        }

        [StopWatch]
        /*" R3300-00-INSERT-COMISICOBVA-DB-INSERT-1 */
        public void R3300_00_INSERT_COMISICOBVA_DB_INSERT_1()
        {
            /*" -8054- EXEC SQL INSERT INTO SEGUROS.COMISS_ADIAN_SICOB VALUES (:DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF, :WHOST-FONTE, :DCLPROPOSTA-FIDELIZ.PROPOFID-AGECOBR , :DCLRCAPS.RCAPS-VAL-RCAP, :DCLCOMISS-ADIAN-SICOB.VAL-ADIANTAMENTO, :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO, :DCLCOMISS-ADIAN-SICOB.SIT-REGISTRO, :DCLPROPOSTA-FIDELIZ.PROPOFID-AGECTAVEN , :DCLPROPOSTA-FIDELIZ.PROPOFID-OPRCTAVEN , :DCLPROPOSTA-FIDELIZ.PROPOFID-NUMCTAVEN , :DCLPROPOSTA-FIDELIZ.PROPOFID-DIGCTAVEN , :DCLPROPOSTA-FIDELIZ.PROPOFID-NRMATRVEN , :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO, CURRENT TIMESTAMP, :DCLCOMISS-ADIAN-SICOB.SIT-FENAE, :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO, :DCLCOMISS-ADIAN-SICOB.VAL-COMISSAO-VEN, :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE, :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO, :DCLCOMISS-ADIAN-SICOB.ORDEM-PAGAMENTO, :DCLCOMISS-ADIAN-SICOB.NUM-ENDOSSO, :DCLCOMISS-ADIAN-SICOB.NUM-MATR-GERENTE, :DCLCOMISS-ADIAN-SICOB.COD-AGEN-GERENTE, :DCLCOMISS-ADIAN-SICOB.OPE-CONTA-GERENTE, :DCLCOMISS-ADIAN-SICOB.NUM-CONTA-GERENTE, :DCLCOMISS-ADIAN-SICOB.DIG-CONTA-GERENTE, :DCLCOMISS-ADIAN-SICOB.VAL-COMIS-GERENTE, :DCLCOMISS-ADIAN-SICOB.NUM-MATR-SUN, :DCLCOMISS-ADIAN-SICOB.COD-AGEN-SUN, :DCLCOMISS-ADIAN-SICOB.OPE-CONTA-SUN, :DCLCOMISS-ADIAN-SICOB.NUM-CONTA-SUN, :DCLCOMISS-ADIAN-SICOB.DIG-CONTA-SUN, :DCLCOMISS-ADIAN-SICOB.VAL-COMIS-SUN) END-EXEC. */

            var r3300_00_INSERT_COMISICOBVA_DB_INSERT_1_Insert1 = new R3300_00_INSERT_COMISICOBVA_DB_INSERT_1_Insert1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                WHOST_FONTE = WHOST_FONTE.ToString(),
                PROPOFID_AGECOBR = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR.ToString(),
                RCAPS_VAL_RCAP = RCAPS.DCLRCAPS.RCAPS_VAL_RCAP.ToString(),
                VAL_ADIANTAMENTO = COADSICO.DCLCOMISS_ADIAN_SICOB.VAL_ADIANTAMENTO.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                SIT_REGISTRO = COADSICO.DCLCOMISS_ADIAN_SICOB.SIT_REGISTRO.ToString(),
                PROPOFID_AGECTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTAVEN.ToString(),
                PROPOFID_OPRCTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTAVEN.ToString(),
                PROPOFID_NUMCTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTAVEN.ToString(),
                PROPOFID_DIGCTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTAVEN.ToString(),
                PROPOFID_NRMATRVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN.ToString(),
                SIT_FENAE = COADSICO.DCLCOMISS_ADIAN_SICOB.SIT_FENAE.ToString(),
                VAL_COMISSAO_VEN = COADSICO.DCLCOMISS_ADIAN_SICOB.VAL_COMISSAO_VEN.ToString(),
                PROPSSVD_NUM_APOLICE = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.ToString(),
                PROPSSVD_COD_SUBGRUPO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.ToString(),
                ORDEM_PAGAMENTO = COADSICO.DCLCOMISS_ADIAN_SICOB.ORDEM_PAGAMENTO.ToString(),
                NUM_ENDOSSO = COADSICO.DCLCOMISS_ADIAN_SICOB.NUM_ENDOSSO.ToString(),
                NUM_MATR_GERENTE = COADSICO.DCLCOMISS_ADIAN_SICOB.NUM_MATR_GERENTE.ToString(),
                COD_AGEN_GERENTE = COADSICO.DCLCOMISS_ADIAN_SICOB.COD_AGEN_GERENTE.ToString(),
                OPE_CONTA_GERENTE = COADSICO.DCLCOMISS_ADIAN_SICOB.OPE_CONTA_GERENTE.ToString(),
                NUM_CONTA_GERENTE = COADSICO.DCLCOMISS_ADIAN_SICOB.NUM_CONTA_GERENTE.ToString(),
                DIG_CONTA_GERENTE = COADSICO.DCLCOMISS_ADIAN_SICOB.DIG_CONTA_GERENTE.ToString(),
                VAL_COMIS_GERENTE = COADSICO.DCLCOMISS_ADIAN_SICOB.VAL_COMIS_GERENTE.ToString(),
                NUM_MATR_SUN = COADSICO.DCLCOMISS_ADIAN_SICOB.NUM_MATR_SUN.ToString(),
                COD_AGEN_SUN = COADSICO.DCLCOMISS_ADIAN_SICOB.COD_AGEN_SUN.ToString(),
                OPE_CONTA_SUN = COADSICO.DCLCOMISS_ADIAN_SICOB.OPE_CONTA_SUN.ToString(),
                NUM_CONTA_SUN = COADSICO.DCLCOMISS_ADIAN_SICOB.NUM_CONTA_SUN.ToString(),
                DIG_CONTA_SUN = COADSICO.DCLCOMISS_ADIAN_SICOB.DIG_CONTA_SUN.ToString(),
                VAL_COMIS_SUN = COADSICO.DCLCOMISS_ADIAN_SICOB.VAL_COMIS_SUN.ToString(),
            };

            R3300_00_INSERT_COMISICOBVA_DB_INSERT_1_Insert1.Execute(r3300_00_INSERT_COMISICOBVA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_99_SAIDA*/

        [StopWatch]
        /*" R3400-00-INSERT-PARCELVA-SECTION */
        private void R3400_00_INSERT_PARCELVA_SECTION()
        {
            /*" -8074- MOVE '3400-00-INSERT-PARCELVA    ' TO PARAGRAFO. */
            _.Move("3400-00-INSERT-PARCELVA    ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8075- MOVE 'INSERT PARCELVA            ' TO COMANDO. */
            _.Move("INSERT PARCELVA            ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8077- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8078- MOVE '1' TO SIT-REGISTRO OF DCLPARCELAS-VIDAZUL. */
            _.Move("1", PARVDZUL.DCLPARCELAS_VIDAZUL.SIT_REGISTRO);

            /*" -8079- MOVE 1 TO NUM-PARCELA OF DCLPARCELAS-VIDAZUL. */
            _.Move(1, PARVDZUL.DCLPARCELAS_VIDAZUL.NUM_PARCELA);

            /*" -8084- MOVE ZEROS TO PREMIO-AP OF DCLPARCELAS-VIDAZUL VLMULTA OF DCLPARCELAS-VIDAZUL OCORR-HISTORICO OF DCLPARCELAS-VIDAZUL. */
            _.Move(0, PARVDZUL.DCLPARCELAS_VIDAZUL.PREMIO_AP, PARVDZUL.DCLPARCELAS_VIDAZUL.VLMULTA, PARVDZUL.DCLPARCELAS_VIDAZUL.OCORR_HISTORICO);

            /*" -8085- MOVE 67 TO SII */
            _.Move(67, WS_HORAS.SII);

            /*" -8086- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -8099- PERFORM R3400_00_INSERT_PARCELVA_DB_INSERT_1 */

            R3400_00_INSERT_PARCELVA_DB_INSERT_1();

            /*" -8102- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -8104- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL -803 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
            {

                /*" -8105- DISPLAY 'PROBLEMAS NO INSERT PARCELVA    ' */
                _.Display($"PROBLEMAS NO INSERT PARCELVA    ");

                /*" -8105- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3400-00-INSERT-PARCELVA-DB-INSERT-1 */
        public void R3400_00_INSERT_PARCELVA_DB_INSERT_1()
        {
            /*" -8099- EXEC SQL INSERT INTO SEGUROS.PARCELAS_VIDAZUL VALUES (:DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF, :DCLPARCELAS-VIDAZUL.NUM-PARCELA, :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO, :DCLRCAPS.RCAPS-VAL-RCAP, :DCLPARCELAS-VIDAZUL.PREMIO-AP, :DCLPARCELAS-VIDAZUL.VLMULTA, :WHOST-OPCAOPAG, :DCLPARCELAS-VIDAZUL.SIT-REGISTRO, :DCLPARCELAS-VIDAZUL.OCORR-HISTORICO, CURRENT TIMESTAMP) END-EXEC. */

            var r3400_00_INSERT_PARCELVA_DB_INSERT_1_Insert1 = new R3400_00_INSERT_PARCELVA_DB_INSERT_1_Insert1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                NUM_PARCELA = PARVDZUL.DCLPARCELAS_VIDAZUL.NUM_PARCELA.ToString(),
                PROPOFID_DTQITBCO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.ToString(),
                RCAPS_VAL_RCAP = RCAPS.DCLRCAPS.RCAPS_VAL_RCAP.ToString(),
                PREMIO_AP = PARVDZUL.DCLPARCELAS_VIDAZUL.PREMIO_AP.ToString(),
                VLMULTA = PARVDZUL.DCLPARCELAS_VIDAZUL.VLMULTA.ToString(),
                WHOST_OPCAOPAG = WHOST_OPCAOPAG.ToString(),
                SIT_REGISTRO = PARVDZUL.DCLPARCELAS_VIDAZUL.SIT_REGISTRO.ToString(),
                OCORR_HISTORICO = PARVDZUL.DCLPARCELAS_VIDAZUL.OCORR_HISTORICO.ToString(),
            };

            R3400_00_INSERT_PARCELVA_DB_INSERT_1_Insert1.Execute(r3400_00_INSERT_PARCELVA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3400_99_SAIDA*/

        [StopWatch]
        /*" R3410-00-INSERT-PARCELVA-SECTION */
        private void R3410_00_INSERT_PARCELVA_SECTION()
        {
            /*" -8115- MOVE '3410-00-INSERT-PARCELVA    ' TO PARAGRAFO */
            _.Move("3410-00-INSERT-PARCELVA    ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8116- MOVE 'INSERT PARCELVA            ' TO COMANDO */
            _.Move("INSERT PARCELVA            ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8118- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8119- MOVE ' ' TO SIT-REGISTRO OF DCLPARCELAS-VIDAZUL */
            _.Move(" ", PARVDZUL.DCLPARCELAS_VIDAZUL.SIT_REGISTRO);

            /*" -8120- MOVE 1 TO NUM-PARCELA OF DCLPARCELAS-VIDAZUL */
            _.Move(1, PARVDZUL.DCLPARCELAS_VIDAZUL.NUM_PARCELA);

            /*" -8124- MOVE ZEROS TO PREMIO-AP OF DCLPARCELAS-VIDAZUL VLMULTA OF DCLPARCELAS-VIDAZUL OCORR-HISTORICO OF DCLPARCELAS-VIDAZUL */
            _.Move(0, PARVDZUL.DCLPARCELAS_VIDAZUL.PREMIO_AP, PARVDZUL.DCLPARCELAS_VIDAZUL.VLMULTA, PARVDZUL.DCLPARCELAS_VIDAZUL.OCORR_HISTORICO);

            /*" -8125- MOVE 68 TO SII */
            _.Move(68, WS_HORAS.SII);

            /*" -8126- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -8152- PERFORM R3410_00_INSERT_PARCELVA_DB_INSERT_1 */

            R3410_00_INSERT_PARCELVA_DB_INSERT_1();

            /*" -8155- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -8156- IF SQLCODE NOT EQUAL ZEROS AND -803 */

            if (!DB.SQLCODE.In("00", "-803"))
            {

                /*" -8157- DISPLAY 'PROBLEMAS NO INSERT PARCELVA    ' */
                _.Display($"PROBLEMAS NO INSERT PARCELVA    ");

                /*" -8158- DISPLAY 'CERTIFICADO = ' PROPOFID-NUM-PROPOSTA-SIVPF */
                _.Display($"CERTIFICADO = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -8159- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -8159- END-IF. */
            }


        }

        [StopWatch]
        /*" R3410-00-INSERT-PARCELVA-DB-INSERT-1 */
        public void R3410_00_INSERT_PARCELVA_DB_INSERT_1()
        {
            /*" -8152- EXEC SQL INSERT INTO SEGUROS.PARCELAS_VIDAZUL ( NUM_CERTIFICADO , NUM_PARCELA , DATA_VENCIMENTO , PREMIO_VG , PREMIO_AP , VLMULTA , OPCAO_PAGAMENTO , SIT_REGISTRO , OCORR_HISTORICO , TIMESTAMP ) VALUES ( :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF , :DCLPARCELAS-VIDAZUL.NUM-PARCELA , :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO , :DCLPROPOSTA-FIDELIZ.PROPOFID-VAL-PAGO , :DCLPARCELAS-VIDAZUL.PREMIO-AP , :DCLPARCELAS-VIDAZUL.VLMULTA , :WHOST-OPCAOPAG , :DCLPARCELAS-VIDAZUL.SIT-REGISTRO , :DCLPARCELAS-VIDAZUL.OCORR-HISTORICO , CURRENT TIMESTAMP ) END-EXEC */

            var r3410_00_INSERT_PARCELVA_DB_INSERT_1_Insert1 = new R3410_00_INSERT_PARCELVA_DB_INSERT_1_Insert1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                NUM_PARCELA = PARVDZUL.DCLPARCELAS_VIDAZUL.NUM_PARCELA.ToString(),
                PROPOFID_DTQITBCO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.ToString(),
                PROPOFID_VAL_PAGO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO.ToString(),
                PREMIO_AP = PARVDZUL.DCLPARCELAS_VIDAZUL.PREMIO_AP.ToString(),
                VLMULTA = PARVDZUL.DCLPARCELAS_VIDAZUL.VLMULTA.ToString(),
                WHOST_OPCAOPAG = WHOST_OPCAOPAG.ToString(),
                SIT_REGISTRO = PARVDZUL.DCLPARCELAS_VIDAZUL.SIT_REGISTRO.ToString(),
                OCORR_HISTORICO = PARVDZUL.DCLPARCELAS_VIDAZUL.OCORR_HISTORICO.ToString(),
            };

            R3410_00_INSERT_PARCELVA_DB_INSERT_1_Insert1.Execute(r3410_00_INSERT_PARCELVA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3410_99_SAIDA*/

        [StopWatch]
        /*" R3500-00-INSERT-HISTCOBVA-SECTION */
        private void R3500_00_INSERT_HISTCOBVA_SECTION()
        {
            /*" -8169- MOVE '3500-00-INSERT-HISTCOBVA   ' TO PARAGRAFO. */
            _.Move("3500-00-INSERT-HISTCOBVA   ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8170- MOVE 'INSERT HISTCOBVA           ' TO COMANDO. */
            _.Move("INSERT HISTCOBVA           ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8172- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8173- MOVE '1' TO SIT-REGISTRO OF DCLCOBER-HIST-VIDAZUL. */
            _.Move("1", CBHSTZUL.DCLCOBER_HIST_VIDAZUL.SIT_REGISTRO);

            /*" -8174- MOVE 201 TO COD-OPERACAO OF DCLCOBER-HIST-VIDAZUL. */
            _.Move(201, CBHSTZUL.DCLCOBER_HIST_VIDAZUL.COD_OPERACAO);

            /*" -8176- MOVE PROPOFID-NUM-SICOB OF DCLPROPOSTA-FIDELIZ TO NUM-TITULO OF DCLCOBER-HIST-VIDAZUL. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB, CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_TITULO);

            /*" -8178- MOVE 1 TO NUM-PARCELA OF DCLCOBER-HIST-VIDAZUL OCORR-HISTORICO OF DCLCOBER-HIST-VIDAZUL. */
            _.Move(1, CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_PARCELA, CBHSTZUL.DCLCOBER_HIST_VIDAZUL.OCORR_HISTORICO);

            /*" -8182- MOVE ZEROS TO COD-DEVOLUCAO OF DCLCOBER-HIST-VIDAZUL NUM-TITULO-COMP OF DCLCOBER-HIST-VIDAZUL. */
            _.Move(0, CBHSTZUL.DCLCOBER_HIST_VIDAZUL.COD_DEVOLUCAO, CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_TITULO_COMP);

            /*" -8183- MOVE 69 TO SII */
            _.Move(69, WS_HORAS.SII);

            /*" -8184- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -8201- PERFORM R3500_00_INSERT_HISTCOBVA_DB_INSERT_1 */

            R3500_00_INSERT_HISTCOBVA_DB_INSERT_1();

            /*" -8204- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -8206- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL -803 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
            {

                /*" -8207- DISPLAY 'PROBLEMAS NO INSERT HISTCOBVA   ' */
                _.Display($"PROBLEMAS NO INSERT HISTCOBVA   ");

                /*" -8207- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3500-00-INSERT-HISTCOBVA-DB-INSERT-1 */
        public void R3500_00_INSERT_HISTCOBVA_DB_INSERT_1()
        {
            /*" -8201- EXEC SQL INSERT INTO SEGUROS.COBER_HIST_VIDAZUL VALUES (:DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF, :DCLPARCELAS-VIDAZUL.NUM-PARCELA, :DCLCOBER-HIST-VIDAZUL.NUM-TITULO, :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO, :DCLRCAPS.RCAPS-VAL-RCAP, :WHOST-OPCAOPAG, :DCLCOBER-HIST-VIDAZUL.SIT-REGISTRO, :DCLCOBER-HIST-VIDAZUL.COD-OPERACAO, :DCLCOBER-HIST-VIDAZUL.OCORR-HISTORICO, :DCLCOBER-HIST-VIDAZUL.COD-DEVOLUCAO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-BCO-AVISO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-AGE-AVISO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-NUM-AVISO-CREDITO, :DCLCOBER-HIST-VIDAZUL.NUM-TITULO-COMP) END-EXEC. */

            var r3500_00_INSERT_HISTCOBVA_DB_INSERT_1_Insert1 = new R3500_00_INSERT_HISTCOBVA_DB_INSERT_1_Insert1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                NUM_PARCELA = PARVDZUL.DCLPARCELAS_VIDAZUL.NUM_PARCELA.ToString(),
                NUM_TITULO = CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_TITULO.ToString(),
                PROPOFID_DTQITBCO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.ToString(),
                RCAPS_VAL_RCAP = RCAPS.DCLRCAPS.RCAPS_VAL_RCAP.ToString(),
                WHOST_OPCAOPAG = WHOST_OPCAOPAG.ToString(),
                SIT_REGISTRO = CBHSTZUL.DCLCOBER_HIST_VIDAZUL.SIT_REGISTRO.ToString(),
                COD_OPERACAO = CBHSTZUL.DCLCOBER_HIST_VIDAZUL.COD_OPERACAO.ToString(),
                OCORR_HISTORICO = CBHSTZUL.DCLCOBER_HIST_VIDAZUL.OCORR_HISTORICO.ToString(),
                COD_DEVOLUCAO = CBHSTZUL.DCLCOBER_HIST_VIDAZUL.COD_DEVOLUCAO.ToString(),
                RCAPCOMP_BCO_AVISO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO.ToString(),
                RCAPCOMP_AGE_AVISO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO.ToString(),
                RCAPCOMP_NUM_AVISO_CREDITO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO.ToString(),
                NUM_TITULO_COMP = CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_TITULO_COMP.ToString(),
            };

            R3500_00_INSERT_HISTCOBVA_DB_INSERT_1_Insert1.Execute(r3500_00_INSERT_HISTCOBVA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3500_99_SAIDA*/

        [StopWatch]
        /*" R3510-00-INSERT-HISTCOBVA-SECTION */
        private void R3510_00_INSERT_HISTCOBVA_SECTION()
        {
            /*" -8217- MOVE '3510-00-INSERT-HISTCOBVA   ' TO PARAGRAFO */
            _.Move("3510-00-INSERT-HISTCOBVA   ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8218- MOVE 'INSERT HISTCOBVA           ' TO COMANDO */
            _.Move("INSERT HISTCOBVA           ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8220- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8221- MOVE '0' TO SIT-REGISTRO OF DCLCOBER-HIST-VIDAZUL */
            _.Move("0", CBHSTZUL.DCLCOBER_HIST_VIDAZUL.SIT_REGISTRO);

            /*" -8222- MOVE 201 TO COD-OPERACAO OF DCLCOBER-HIST-VIDAZUL */
            _.Move(201, CBHSTZUL.DCLCOBER_HIST_VIDAZUL.COD_OPERACAO);

            /*" -8224- MOVE PROPOFID-NUM-SICOB OF DCLPROPOSTA-FIDELIZ TO NUM-TITULO OF DCLCOBER-HIST-VIDAZUL */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB, CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_TITULO);

            /*" -8226- MOVE 1 TO NUM-PARCELA OF DCLCOBER-HIST-VIDAZUL OCORR-HISTORICO OF DCLCOBER-HIST-VIDAZUL */
            _.Move(1, CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_PARCELA, CBHSTZUL.DCLCOBER_HIST_VIDAZUL.OCORR_HISTORICO);

            /*" -8232- MOVE ZEROS TO COD-DEVOLUCAO OF DCLCOBER-HIST-VIDAZUL BCO-AVISO OF DCLCOBER-HIST-VIDAZUL AGE-AVISO OF DCLCOBER-HIST-VIDAZUL NUM-AVISO-CREDITO OF DCLCOBER-HIST-VIDAZUL NUM-TITULO-COMP OF DCLCOBER-HIST-VIDAZUL */
            _.Move(0, CBHSTZUL.DCLCOBER_HIST_VIDAZUL.COD_DEVOLUCAO, CBHSTZUL.DCLCOBER_HIST_VIDAZUL.BCO_AVISO, CBHSTZUL.DCLCOBER_HIST_VIDAZUL.AGE_AVISO, CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_AVISO_CREDITO, CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_TITULO_COMP);

            /*" -8233- MOVE 70 TO SII */
            _.Move(70, WS_HORAS.SII);

            /*" -8234- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -8268- PERFORM R3510_00_INSERT_HISTCOBVA_DB_INSERT_1 */

            R3510_00_INSERT_HISTCOBVA_DB_INSERT_1();

            /*" -8271- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -8273- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL -803 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
            {

                /*" -8274- DISPLAY 'PROBLEMAS NO INSERT HISTCOBVA   ' */
                _.Display($"PROBLEMAS NO INSERT HISTCOBVA   ");

                /*" -8275- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -8276- END-IF. */
            }


        }

        [StopWatch]
        /*" R3510-00-INSERT-HISTCOBVA-DB-INSERT-1 */
        public void R3510_00_INSERT_HISTCOBVA_DB_INSERT_1()
        {
            /*" -8268- EXEC SQL INSERT INTO SEGUROS.COBER_HIST_VIDAZUL ( NUM_CERTIFICADO , NUM_PARCELA , NUM_TITULO , DATA_VENCIMENTO , PRM_TOTAL , OPCAO_PAGAMENTO , SIT_REGISTRO , COD_OPERACAO , OCORR_HISTORICO , COD_DEVOLUCAO , BCO_AVISO , AGE_AVISO , NUM_AVISO_CREDITO , NUM_TITULO_COMP ) VALUES ( :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF , :DCLPARCELAS-VIDAZUL.NUM-PARCELA , :DCLCOBER-HIST-VIDAZUL.NUM-TITULO , :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO , :DCLPROPOSTA-FIDELIZ.PROPOFID-VAL-PAGO , :WHOST-OPCAOPAG , :DCLCOBER-HIST-VIDAZUL.SIT-REGISTRO , :DCLCOBER-HIST-VIDAZUL.COD-OPERACAO , :DCLCOBER-HIST-VIDAZUL.OCORR-HISTORICO , :DCLCOBER-HIST-VIDAZUL.COD-DEVOLUCAO , :DCLCOBER-HIST-VIDAZUL.BCO-AVISO , :DCLCOBER-HIST-VIDAZUL.AGE-AVISO , :DCLCOBER-HIST-VIDAZUL.NUM-AVISO-CREDITO , :DCLCOBER-HIST-VIDAZUL.NUM-TITULO-COMP ) END-EXEC */

            var r3510_00_INSERT_HISTCOBVA_DB_INSERT_1_Insert1 = new R3510_00_INSERT_HISTCOBVA_DB_INSERT_1_Insert1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                NUM_PARCELA = PARVDZUL.DCLPARCELAS_VIDAZUL.NUM_PARCELA.ToString(),
                NUM_TITULO = CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_TITULO.ToString(),
                PROPOFID_DTQITBCO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.ToString(),
                PROPOFID_VAL_PAGO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO.ToString(),
                WHOST_OPCAOPAG = WHOST_OPCAOPAG.ToString(),
                SIT_REGISTRO = CBHSTZUL.DCLCOBER_HIST_VIDAZUL.SIT_REGISTRO.ToString(),
                COD_OPERACAO = CBHSTZUL.DCLCOBER_HIST_VIDAZUL.COD_OPERACAO.ToString(),
                OCORR_HISTORICO = CBHSTZUL.DCLCOBER_HIST_VIDAZUL.OCORR_HISTORICO.ToString(),
                COD_DEVOLUCAO = CBHSTZUL.DCLCOBER_HIST_VIDAZUL.COD_DEVOLUCAO.ToString(),
                BCO_AVISO = CBHSTZUL.DCLCOBER_HIST_VIDAZUL.BCO_AVISO.ToString(),
                AGE_AVISO = CBHSTZUL.DCLCOBER_HIST_VIDAZUL.AGE_AVISO.ToString(),
                NUM_AVISO_CREDITO = CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_AVISO_CREDITO.ToString(),
                NUM_TITULO_COMP = CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_TITULO_COMP.ToString(),
            };

            R3510_00_INSERT_HISTCOBVA_DB_INSERT_1_Insert1.Execute(r3510_00_INSERT_HISTCOBVA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3510_99_SAIDA*/

        [StopWatch]
        /*" R3520-00-INSERT-HISTCONTAVA-SECTION */
        private void R3520_00_INSERT_HISTCONTAVA_SECTION()
        {
            /*" -8286- MOVE '3520-00-INSERT-HISTCONTAVA ' TO PARAGRAFO */
            _.Move("3520-00-INSERT-HISTCONTAVA ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8288- MOVE 'INSERT HISTCONTAVA         ' TO COMANDO */
            _.Move("INSERT HISTCONTAVA         ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8290- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8292- INITIALIZE DCLHIST-LANC-CTA */
            _.Initialize(
                HISLANCT.DCLHIST_LANC_CTA
            );

            /*" -8294- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO HISLANCT-NUM-CERTIFICADO */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO);

            /*" -8295- MOVE PROPOFID-DTQITBCO TO HISLANCT-DATA-VENCIMENTO */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_DATA_VENCIMENTO);

            /*" -8296- MOVE PROPOFID-VAL-PAGO TO HISLANCT-PRM-TOTAL */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_PRM_TOTAL);

            /*" -8298- MOVE 1 TO HISLANCT-NUM-PARCELA HISLANCT-OCORR-HISTORICOCTA */
            _.Move(1, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_OCORR_HISTORICOCTA);

            /*" -8299- MOVE '1' TO HISLANCT-TIPLANC */
            _.Move("1", HISLANCT.DCLHIST_LANC_CTA.HISLANCT_TIPLANC);

            /*" -8300- MOVE '3' TO HISLANCT-SIT-REGISTRO */
            _.Move("3", HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO);

            /*" -8308- MOVE 0 TO HISLANCT-COD-AGENCIA-DEBITO HISLANCT-OPE-CONTA-DEBITO HISLANCT-NUM-CONTA-DEBITO HISLANCT-DIG-CONTA-DEBITO HISLANCT-NUM-CARTAO-CREDITO HISLANCT-OCORR-HISTORICO */
            _.Move(0, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_COD_AGENCIA_DEBITO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_OPE_CONTA_DEBITO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CONTA_DEBITO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_DIG_CONTA_DEBITO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CARTAO_CREDITO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_OCORR_HISTORICO);

            /*" -8310- MOVE 'VA0601B' TO HISLANCT-COD-USUARIO */
            _.Move("VA0601B", HISLANCT.DCLHIST_LANC_CTA.HISLANCT_COD_USUARIO);

            /*" -8312- PERFORM R3525-00-CONSULTA-CONVENIOVG */

            R3525_00_CONSULTA_CONVENIOVG_SECTION();

            /*" -8314- MOVE CONVEVG-COD-CONV-CARTAO TO HISLANCT-CODCONV */
            _.Move(CONVEVG.DCLCONVENIOS_VG.CONVEVG_COD_CONV_CARTAO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_CODCONV);

            /*" -8362- PERFORM R3520_00_INSERT_HISTCONTAVA_DB_INSERT_1 */

            R3520_00_INSERT_HISTCONTAVA_DB_INSERT_1();

            /*" -8366- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL -803 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
            {

                /*" -8367- DISPLAY 'PROBLEMAS NO INSERT HISTCONTAVA ' */
                _.Display($"PROBLEMAS NO INSERT HISTCONTAVA ");

                /*" -8368- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -8369- END-IF. */
            }


        }

        [StopWatch]
        /*" R3520-00-INSERT-HISTCONTAVA-DB-INSERT-1 */
        public void R3520_00_INSERT_HISTCONTAVA_DB_INSERT_1()
        {
            /*" -8362- EXEC SQL INSERT INTO SEGUROS.HIST_LANC_CTA ( NUM_CERTIFICADO , NUM_PARCELA , OCORR_HISTORICOCTA , COD_AGENCIA_DEBITO , OPE_CONTA_DEBITO , NUM_CONTA_DEBITO , DIG_CONTA_DEBITO , DATA_VENCIMENTO , PRM_TOTAL , SIT_REGISTRO , TIPLANC , TIMESTAMP , OCORR_HISTORICO , CODCONV , NSAS , NSL , NSAC , CODRET , COD_USUARIO , NUM_CARTAO_CREDITO , COD_BANCO ) VALUES ( :HISLANCT-NUM-CERTIFICADO , :HISLANCT-NUM-PARCELA , :HISLANCT-OCORR-HISTORICOCTA , :HISLANCT-COD-AGENCIA-DEBITO , :HISLANCT-OPE-CONTA-DEBITO , :HISLANCT-NUM-CONTA-DEBITO , :HISLANCT-DIG-CONTA-DEBITO , :HISLANCT-DATA-VENCIMENTO , :HISLANCT-PRM-TOTAL , :HISLANCT-SIT-REGISTRO , :HISLANCT-TIPLANC , CURRENT TIMESTAMP , :HISLANCT-OCORR-HISTORICO , :HISLANCT-CODCONV , NULL , NULL , NULL , NULL , :HISLANCT-COD-USUARIO , :HISLANCT-NUM-CARTAO-CREDITO , NULL ) END-EXEC. */

            var r3520_00_INSERT_HISTCONTAVA_DB_INSERT_1_Insert1 = new R3520_00_INSERT_HISTCONTAVA_DB_INSERT_1_Insert1()
            {
                HISLANCT_NUM_CERTIFICADO = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO.ToString(),
                HISLANCT_NUM_PARCELA = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA.ToString(),
                HISLANCT_OCORR_HISTORICOCTA = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_OCORR_HISTORICOCTA.ToString(),
                HISLANCT_COD_AGENCIA_DEBITO = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_COD_AGENCIA_DEBITO.ToString(),
                HISLANCT_OPE_CONTA_DEBITO = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_OPE_CONTA_DEBITO.ToString(),
                HISLANCT_NUM_CONTA_DEBITO = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CONTA_DEBITO.ToString(),
                HISLANCT_DIG_CONTA_DEBITO = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_DIG_CONTA_DEBITO.ToString(),
                HISLANCT_DATA_VENCIMENTO = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_DATA_VENCIMENTO.ToString(),
                HISLANCT_PRM_TOTAL = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_PRM_TOTAL.ToString(),
                HISLANCT_SIT_REGISTRO = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO.ToString(),
                HISLANCT_TIPLANC = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_TIPLANC.ToString(),
                HISLANCT_OCORR_HISTORICO = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_OCORR_HISTORICO.ToString(),
                HISLANCT_CODCONV = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_CODCONV.ToString(),
                HISLANCT_COD_USUARIO = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_COD_USUARIO.ToString(),
                HISLANCT_NUM_CARTAO_CREDITO = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CARTAO_CREDITO.ToString(),
            };

            R3520_00_INSERT_HISTCONTAVA_DB_INSERT_1_Insert1.Execute(r3520_00_INSERT_HISTCONTAVA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3520_99_SAIDA*/

        [StopWatch]
        /*" R3525-00-CONSULTA-CONVENIOVG-SECTION */
        private void R3525_00_CONSULTA_CONVENIOVG_SECTION()
        {
            /*" -8378- MOVE 'R3525-00-CONSULTA-CONVENIOVG ' TO PARAGRAFO */
            _.Move("R3525-00-CONSULTA-CONVENIOVG ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8379- MOVE 'CONSULTA CONVENIOS_VG        ' TO COMANDO */
            _.Move("CONSULTA CONVENIOS_VG        ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8381- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8383- INITIALIZE DCLCONVENIOS-VG */
            _.Initialize(
                CONVEVG.DCLCONVENIOS_VG
            );

            /*" -8384- MOVE PROPSSVD-NUM-APOLICE TO CONVEVG-NUM-APOLICE */
            _.Move(PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE, CONVEVG.DCLCONVENIOS_VG.CONVEVG_NUM_APOLICE);

            /*" -8389- MOVE PROPSSVD-COD-SUBGRUPO TO CONVEVG-CODSUBES */
            _.Move(PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO, CONVEVG.DCLCONVENIOS_VG.CONVEVG_CODSUBES);

            /*" -8398- PERFORM R3525_00_CONSULTA_CONVENIOVG_DB_SELECT_1 */

            R3525_00_CONSULTA_CONVENIOVG_DB_SELECT_1();

            /*" -8401-  EVALUATE SQLCODE  */

            /*" -8402-  WHEN ZEROS  */

            /*" -8402- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -8403- CONTINUE */

                /*" -8404-  WHEN +100  */

                /*" -8404- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -8406- MOVE ZEROS TO CONVEVG-COD-SEGURO CONVEVG-COD-CONV-CARTAO */
                _.Move(0, CONVEVG.DCLCONVENIOS_VG.CONVEVG_COD_SEGURO, CONVEVG.DCLCONVENIOS_VG.CONVEVG_COD_CONV_CARTAO);

                /*" -8407-  WHEN OTHER  */

                /*" -8407- ELSE */
            }
            else
            {


                /*" -8408- DISPLAY 'R3525-00 (ERRO - SELECT CONVENIOS_VG)' */
                _.Display($"R3525-00 (ERRO - SELECT CONVENIOS_VG)");

                /*" -8410- DISPLAY 'APOL...: ' CONVEVG-NUM-APOLICE 'SUBGRUP: ' CONVEVG-CODSUBES */

                $"APOL...: {CONVEVG.DCLCONVENIOS_VG.CONVEVG_NUM_APOLICE}SUBGRUP: {CONVEVG.DCLCONVENIOS_VG.CONVEVG_CODSUBES}"
                .Display();

                /*" -8411- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -8412-  END-EVALUATE.  */

                /*" -8412- END-IF. */
            }


        }

        [StopWatch]
        /*" R3525-00-CONSULTA-CONVENIOVG-DB-SELECT-1 */
        public void R3525_00_CONSULTA_CONVENIOVG_DB_SELECT_1()
        {
            /*" -8398- EXEC SQL SELECT COD_SEGURO , COD_CONV_CARTAO INTO :CONVEVG-COD-SEGURO , :CONVEVG-COD-CONV-CARTAO FROM SEGUROS.CONVENIOS_VG WHERE NUM_APOLICE = :CONVEVG-NUM-APOLICE AND CODSUBES = :CONVEVG-CODSUBES WITH UR END-EXEC */

            var r3525_00_CONSULTA_CONVENIOVG_DB_SELECT_1_Query1 = new R3525_00_CONSULTA_CONVENIOVG_DB_SELECT_1_Query1()
            {
                CONVEVG_NUM_APOLICE = CONVEVG.DCLCONVENIOS_VG.CONVEVG_NUM_APOLICE.ToString(),
                CONVEVG_CODSUBES = CONVEVG.DCLCONVENIOS_VG.CONVEVG_CODSUBES.ToString(),
            };

            var executed_1 = R3525_00_CONSULTA_CONVENIOVG_DB_SELECT_1_Query1.Execute(r3525_00_CONSULTA_CONVENIOVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONVEVG_COD_SEGURO, CONVEVG.DCLCONVENIOS_VG.CONVEVG_COD_SEGURO);
                _.Move(executed_1.CONVEVG_COD_CONV_CARTAO, CONVEVG.DCLCONVENIOS_VG.CONVEVG_COD_CONV_CARTAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3525_99_SAIDA*/

        [StopWatch]
        /*" R3600-00-INSERT-HISTCONTABILVA-SECTION */
        private void R3600_00_INSERT_HISTCONTABILVA_SECTION()
        {
            /*" -8421- MOVE '3600-00-SELECT-HISTCONTABILVA' TO PARAGRAFO */
            _.Move("3600-00-SELECT-HISTCONTABILVA", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8422- MOVE 'SELECT HISTCONTABILVA        ' TO COMANDO */
            _.Move("SELECT HISTCONTABILVA        ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8424- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8425- MOVE '0' TO SIT-REGISTRO OF DCLHIST-CONT-PARCELVA */
            _.Move("0", HTCTBPVA.DCLHIST_CONT_PARCELVA.SIT_REGISTRO);

            /*" -8428- MOVE ZEROS TO NUM-ENDOSSO OF DCLHIST-CONT-PARCELVA PREMIO-AP OF DCLHIST-CONT-PARCELVA */
            _.Move(0, HTCTBPVA.DCLHIST_CONT_PARCELVA.NUM_ENDOSSO, HTCTBPVA.DCLHIST_CONT_PARCELVA.PREMIO_AP);

            /*" -8429- MOVE 71 TO SII */
            _.Move(71, WS_HORAS.SII);

            /*" -8430- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -8439- PERFORM R3600_00_INSERT_HISTCONTABILVA_DB_SELECT_1 */

            R3600_00_INSERT_HISTCONTABILVA_DB_SELECT_1();

            /*" -8443- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -8444- IF SQLCODE EQUAL ZEROS OR -811 */

            if (DB.SQLCODE.In("00", "-811"))
            {

                /*" -8446- GO TO R3600-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3600_99_SAIDA*/ //GOTO
                return;
            }


            /*" -8447- MOVE 201 TO COD-OPERACAO OF DCLHIST-CONT-PARCELVA. */
            _.Move(201, HTCTBPVA.DCLHIST_CONT_PARCELVA.COD_OPERACAO);

            /*" -8448- MOVE SPACES TO DTFATUR OF DCLHIST-CONT-PARCELVA. */
            _.Move("", HTCTBPVA.DCLHIST_CONT_PARCELVA.DTFATUR);

            /*" -8451- MOVE -1 TO VIND-DTFATUR. */
            _.Move(-1, VIND_DTFATUR);

            /*" -8453- MOVE '3600-00-INSERT-HISTCONTABILVA' TO PARAGRAFO. */
            _.Move("3600-00-INSERT-HISTCONTABILVA", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8454- MOVE 72 TO SII */
            _.Move(72, WS_HORAS.SII);

            /*" -8455- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -8473- PERFORM R3600_00_INSERT_HISTCONTABILVA_DB_INSERT_1 */

            R3600_00_INSERT_HISTCONTABILVA_DB_INSERT_1();

            /*" -8476- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -8478- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL -803 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
            {

                /*" -8479- DISPLAY 'PROBLEMAS NO INSERT HISTCONTABILVA ' */
                _.Display($"PROBLEMAS NO INSERT HISTCONTABILVA ");

                /*" -8479- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3600-00-INSERT-HISTCONTABILVA-DB-SELECT-1 */
        public void R3600_00_INSERT_HISTCONTABILVA_DB_SELECT_1()
        {
            /*" -8439- EXEC SQL SELECT NUM_PARCELA INTO :WHOST-NRPARCEL-56 FROM SEGUROS.HIST_CONT_PARCELVA WHERE NUM_CERTIFICADO = :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF AND NUM_PARCELA = :DCLPARCELAS-VIDAZUL.NUM-PARCELA WITH UR END-EXEC. */

            var r3600_00_INSERT_HISTCONTABILVA_DB_SELECT_1_Query1 = new R3600_00_INSERT_HISTCONTABILVA_DB_SELECT_1_Query1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                NUM_PARCELA = PARVDZUL.DCLPARCELAS_VIDAZUL.NUM_PARCELA.ToString(),
            };

            var executed_1 = R3600_00_INSERT_HISTCONTABILVA_DB_SELECT_1_Query1.Execute(r3600_00_INSERT_HISTCONTABILVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_NRPARCEL_56, WHOST_NRPARCEL_56);
            }


        }

        [StopWatch]
        /*" R3600-00-INSERT-HISTCONTABILVA-DB-INSERT-1 */
        public void R3600_00_INSERT_HISTCONTABILVA_DB_INSERT_1()
        {
            /*" -8473- EXEC SQL INSERT INTO SEGUROS.HIST_CONT_PARCELVA VALUES (:DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF, :DCLPARCELAS-VIDAZUL.NUM-PARCELA, :DCLCOBER-HIST-VIDAZUL.NUM-TITULO, :DCLCOBER-HIST-VIDAZUL.OCORR-HISTORICO, :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE, :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO, :WHOST-FONTE, :DCLHIST-CONT-PARCELVA.NUM-ENDOSSO, :DCLRCAPS.RCAPS-VAL-RCAP, :DCLHIST-CONT-PARCELVA.PREMIO-AP, :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO, :DCLHIST-CONT-PARCELVA.SIT-REGISTRO, :DCLHIST-CONT-PARCELVA.COD-OPERACAO, CURRENT TIMESTAMP, :DCLHIST-CONT-PARCELVA.DTFATUR:VIND-DTFATUR) END-EXEC. */

            var r3600_00_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1 = new R3600_00_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                NUM_PARCELA = PARVDZUL.DCLPARCELAS_VIDAZUL.NUM_PARCELA.ToString(),
                NUM_TITULO = CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_TITULO.ToString(),
                OCORR_HISTORICO = CBHSTZUL.DCLCOBER_HIST_VIDAZUL.OCORR_HISTORICO.ToString(),
                PROPSSVD_NUM_APOLICE = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.ToString(),
                PROPSSVD_COD_SUBGRUPO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.ToString(),
                WHOST_FONTE = WHOST_FONTE.ToString(),
                NUM_ENDOSSO = HTCTBPVA.DCLHIST_CONT_PARCELVA.NUM_ENDOSSO.ToString(),
                RCAPS_VAL_RCAP = RCAPS.DCLRCAPS.RCAPS_VAL_RCAP.ToString(),
                PREMIO_AP = HTCTBPVA.DCLHIST_CONT_PARCELVA.PREMIO_AP.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                SIT_REGISTRO = HTCTBPVA.DCLHIST_CONT_PARCELVA.SIT_REGISTRO.ToString(),
                COD_OPERACAO = HTCTBPVA.DCLHIST_CONT_PARCELVA.COD_OPERACAO.ToString(),
                DTFATUR = HTCTBPVA.DCLHIST_CONT_PARCELVA.DTFATUR.ToString(),
                VIND_DTFATUR = VIND_DTFATUR.ToString(),
            };

            R3600_00_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1.Execute(r3600_00_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3600_99_SAIDA*/

        [StopWatch]
        /*" R3610-00-INSERT-HISTCONTABILVA-SECTION */
        private void R3610_00_INSERT_HISTCONTABILVA_SECTION()
        {
            /*" -8489- MOVE '3610-00-SELECT-HISTCONTABILVA' TO PARAGRAFO */
            _.Move("3610-00-SELECT-HISTCONTABILVA", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8490- MOVE 'SELECT HISTCONTABILVA        ' TO COMANDO */
            _.Move("SELECT HISTCONTABILVA        ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8492- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8493- MOVE '0' TO SIT-REGISTRO OF DCLHIST-CONT-PARCELVA */
            _.Move("0", HTCTBPVA.DCLHIST_CONT_PARCELVA.SIT_REGISTRO);

            /*" -8496- MOVE ZEROS TO NUM-ENDOSSO OF DCLHIST-CONT-PARCELVA PREMIO-AP OF DCLHIST-CONT-PARCELVA */
            _.Move(0, HTCTBPVA.DCLHIST_CONT_PARCELVA.NUM_ENDOSSO, HTCTBPVA.DCLHIST_CONT_PARCELVA.PREMIO_AP);

            /*" -8497- MOVE 73 TO SII */
            _.Move(73, WS_HORAS.SII);

            /*" -8498- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -8505- PERFORM R3610_00_INSERT_HISTCONTABILVA_DB_SELECT_1 */

            R3610_00_INSERT_HISTCONTABILVA_DB_SELECT_1();

            /*" -8508- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -8509- IF SQLCODE EQUAL ZEROS OR -811 */

            if (DB.SQLCODE.In("00", "-811"))
            {

                /*" -8510- DISPLAY 'R3610-00 (PARCELA FATURADA)' */
                _.Display($"R3610-00 (PARCELA FATURADA)");

                /*" -8511- DISPLAY 'NUM_CERTIFICADO = ' PROPOFID-NUM-PROPOSTA-SIVPF */
                _.Display($"NUM_CERTIFICADO = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -8513- DISPLAY 'NUM_PARCELA     = ' NUM-PARCELA OF DCLPARCELAS-VIDAZUL */
                _.Display($"NUM_PARCELA     = {PARVDZUL.DCLPARCELAS_VIDAZUL.NUM_PARCELA}");

                /*" -8514- DISPLAY 'SQLCODE         = ' SQLCODE */
                _.Display($"SQLCODE         = {DB.SQLCODE}");

                /*" -8515- GO TO R3610-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3610_99_SAIDA*/ //GOTO
                return;

                /*" -8517- END-IF */
            }


            /*" -8518- MOVE 201 TO COD-OPERACAO OF DCLHIST-CONT-PARCELVA */
            _.Move(201, HTCTBPVA.DCLHIST_CONT_PARCELVA.COD_OPERACAO);

            /*" -8519- MOVE SPACES TO DTFATUR OF DCLHIST-CONT-PARCELVA */
            _.Move("", HTCTBPVA.DCLHIST_CONT_PARCELVA.DTFATUR);

            /*" -8521- MOVE -1 TO VIND-DTFATUR */
            _.Move(-1, VIND_DTFATUR);

            /*" -8522- MOVE 74 TO SII */
            _.Move(74, WS_HORAS.SII);

            /*" -8523- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -8543- PERFORM R3610_00_INSERT_HISTCONTABILVA_DB_INSERT_1 */

            R3610_00_INSERT_HISTCONTABILVA_DB_INSERT_1();

            /*" -8546- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -8548- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL -803 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
            {

                /*" -8549- DISPLAY 'PROBLEMAS NO INSERT HISTCONTABILVA ' */
                _.Display($"PROBLEMAS NO INSERT HISTCONTABILVA ");

                /*" -8550- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -8550- END-IF. */
            }


        }

        [StopWatch]
        /*" R3610-00-INSERT-HISTCONTABILVA-DB-SELECT-1 */
        public void R3610_00_INSERT_HISTCONTABILVA_DB_SELECT_1()
        {
            /*" -8505- EXEC SQL SELECT NUM_PARCELA INTO :WHOST-NRPARCEL-56 FROM SEGUROS.HIST_CONT_PARCELVA WHERE NUM_CERTIFICADO = :PROPOFID-NUM-PROPOSTA-SIVPF AND NUM_PARCELA = :DCLPARCELAS-VIDAZUL.NUM-PARCELA WITH UR END-EXEC */

            var r3610_00_INSERT_HISTCONTABILVA_DB_SELECT_1_Query1 = new R3610_00_INSERT_HISTCONTABILVA_DB_SELECT_1_Query1()
            {
                NUM_PARCELA = PARVDZUL.DCLPARCELAS_VIDAZUL.NUM_PARCELA.ToString(),
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R3610_00_INSERT_HISTCONTABILVA_DB_SELECT_1_Query1.Execute(r3610_00_INSERT_HISTCONTABILVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_NRPARCEL_56, WHOST_NRPARCEL_56);
            }


        }

        [StopWatch]
        /*" R3610-00-INSERT-HISTCONTABILVA-DB-INSERT-1 */
        public void R3610_00_INSERT_HISTCONTABILVA_DB_INSERT_1()
        {
            /*" -8543- EXEC SQL INSERT INTO SEGUROS.HIST_CONT_PARCELVA VALUES ( :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF , :DCLPARCELAS-VIDAZUL.NUM-PARCELA , :DCLCOBER-HIST-VIDAZUL.NUM-TITULO , :DCLCOBER-HIST-VIDAZUL.OCORR-HISTORICO , :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE , :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO , :WHOST-FONTE , :DCLHIST-CONT-PARCELVA.NUM-ENDOSSO , :DCLPROPOSTA-FIDELIZ.PROPOFID-VAL-PAGO , :DCLHIST-CONT-PARCELVA.PREMIO-AP , :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO , :DCLHIST-CONT-PARCELVA.SIT-REGISTRO , :DCLHIST-CONT-PARCELVA.COD-OPERACAO , CURRENT TIMESTAMP , :DCLHIST-CONT-PARCELVA.DTFATUR:VIND-DTFATUR ) END-EXEC */

            var r3610_00_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1 = new R3610_00_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                NUM_PARCELA = PARVDZUL.DCLPARCELAS_VIDAZUL.NUM_PARCELA.ToString(),
                NUM_TITULO = CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_TITULO.ToString(),
                OCORR_HISTORICO = CBHSTZUL.DCLCOBER_HIST_VIDAZUL.OCORR_HISTORICO.ToString(),
                PROPSSVD_NUM_APOLICE = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.ToString(),
                PROPSSVD_COD_SUBGRUPO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.ToString(),
                WHOST_FONTE = WHOST_FONTE.ToString(),
                NUM_ENDOSSO = HTCTBPVA.DCLHIST_CONT_PARCELVA.NUM_ENDOSSO.ToString(),
                PROPOFID_VAL_PAGO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO.ToString(),
                PREMIO_AP = HTCTBPVA.DCLHIST_CONT_PARCELVA.PREMIO_AP.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                SIT_REGISTRO = HTCTBPVA.DCLHIST_CONT_PARCELVA.SIT_REGISTRO.ToString(),
                COD_OPERACAO = HTCTBPVA.DCLHIST_CONT_PARCELVA.COD_OPERACAO.ToString(),
                DTFATUR = HTCTBPVA.DCLHIST_CONT_PARCELVA.DTFATUR.ToString(),
                VIND_DTFATUR = VIND_DTFATUR.ToString(),
            };

            R3610_00_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1.Execute(r3610_00_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3610_99_SAIDA*/

        [StopWatch]
        /*" R3700-00-INSERT-RELATORIOS-SECTION */
        private void R3700_00_INSERT_RELATORIOS_SECTION()
        {
            /*" -8560- MOVE '3700-00-INSERT-RELATORIOS    ' TO PARAGRAFO. */
            _.Move("3700-00-INSERT-RELATORIOS    ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8561- MOVE 'SELECT VA0469B               ' TO COMANDO. */
            _.Move("SELECT VA0469B               ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8563- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8564- MOVE 75 TO SII */
            _.Move(75, WS_HORAS.SII);

            /*" -8565- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -8572- PERFORM R3700_00_INSERT_RELATORIOS_DB_SELECT_1 */

            R3700_00_INSERT_RELATORIOS_DB_SELECT_1();

            /*" -8575- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -8576- IF SQLCODE NOT EQUAL ZEROES AND 100 AND -811 */

            if (!DB.SQLCODE.In("00", "100", "-811"))
            {

                /*" -8578- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -8579- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -8580- GO TO R3700-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3700_99_SAIDA*/ //GOTO
                return;

                /*" -8581- ELSE */
            }
            else
            {


                /*" -8582- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -8583- CONTINUE */

                    /*" -8584- ELSE */
                }
                else
                {


                    /*" -8585- IF SQLCODE EQUAL -811 */

                    if (DB.SQLCODE == -811)
                    {

                        /*" -8586- MOVE '3700-00-UPDATE-RELATORIOS    ' TO COMANDO */
                        _.Move("3700-00-UPDATE-RELATORIOS    ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

                        /*" -8587- MOVE 76 TO SII */
                        _.Move(76, WS_HORAS.SII);

                        /*" -8588- PERFORM R9000-00-INICIO */

                        R9000_00_INICIO_SECTION();

                        /*" -8595- PERFORM R3700_00_INSERT_RELATORIOS_DB_UPDATE_1 */

                        R3700_00_INSERT_RELATORIOS_DB_UPDATE_1();

                        /*" -8597- PERFORM R9100-00-TERMINO */

                        R9100_00_TERMINO_SECTION();

                        /*" -8598- IF SQLCODE NOT EQUAL ZEROES */

                        if (DB.SQLCODE != 00)
                        {

                            /*" -8600- GO TO R9999-00-ROT-ERRO. */

                            R9999_00_ROT_ERRO_SECTION(); //GOTO
                            return;
                        }

                    }

                }

            }


            /*" -8601- MOVE 'INSERT RELATORIOS            ' TO COMANDO */
            _.Move("INSERT RELATORIOS            ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8603- MOVE 77 TO SII */
            _.Move(77, WS_HORAS.SII);

            /*" -8605- IF (PROPOFID-NUMCTADEB NOT EQUAL ZEROS AND PROPOFID-OPCAOPAG NOT EQUAL '3' ) */

            if ((PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTADEB != 00 && PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAOPAG != "3"))
            {

                /*" -8606- MOVE 104 TO WHOST-BCO-RELAT */
                _.Move(104, WHOST_BCO_RELAT);

                /*" -8607- MOVE PROPOFID-VAL-PAGO TO WHOST-VLR-RELAT */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO, WHOST_VLR_RELAT);

                /*" -8608- COMPUTE WHOST-VLR-RELAT = WHOST-VLR-RELAT * 100 */
                WHOST_VLR_RELAT.Value = WHOST_VLR_RELAT * 100;

                /*" -8609- MOVE WHOST-VLR-RELAT TO WHOST-SIN-RELAT */
                _.Move(WHOST_VLR_RELAT, WHOST_SIN_RELAT);

                /*" -8610- ELSE */
            }
            else
            {


                /*" -8616- MOVE ZEROS TO WHOST-BCO-RELAT PROPOFID-AGECTADEB PROPOFID-OPRCTADEB PROPOFID-NUMCTADEB PROPOFID-DIGCTADEB WHOST-SIN-RELAT */
                _.Move(0, WHOST_BCO_RELAT, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTADEB, WHOST_SIN_RELAT);

                /*" -8618- END-IF */
            }


            /*" -8619- IF PROPOFID-OPCAOPAG EQUAL '3' */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAOPAG == "3")
            {

                /*" -8620- MOVE 5 TO RELATORI-NUM-COPIAS */
                _.Move(5, RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS);

                /*" -8621- MOVE PROPOFID-VAL-PAGO TO WHOST-VLR-RELAT */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO, WHOST_VLR_RELAT);

                /*" -8622- COMPUTE WHOST-VLR-RELAT = WHOST-VLR-RELAT * 100 */
                WHOST_VLR_RELAT.Value = WHOST_VLR_RELAT * 100;

                /*" -8623- MOVE WHOST-VLR-RELAT TO WHOST-SIN-RELAT */
                _.Move(WHOST_VLR_RELAT, WHOST_SIN_RELAT);

                /*" -8624- ELSE */
            }
            else
            {


                /*" -8625- MOVE 2 TO RELATORI-NUM-COPIAS */
                _.Move(2, RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS);

                /*" -8627- END-IF */
            }


            /*" -8629- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -8716- PERFORM R3700_00_INSERT_RELATORIOS_DB_INSERT_1 */

            R3700_00_INSERT_RELATORIOS_DB_INSERT_1();

            /*" -8719- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -8720- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -8721- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3700-00-INSERT-RELATORIOS-DB-SELECT-1 */
        public void R3700_00_INSERT_RELATORIOS_DB_SELECT_1()
        {
            /*" -8572- EXEC SQL SELECT COD_USUARIO INTO :RELATORI-COD-USUARIO FROM SEGUROS.RELATORIOS WHERE NUM_CERTIFICADO = :PROPOFID-NUM-PROPOSTA-SIVPF AND COD_RELATORIO = 'VA0469B' AND SIT_REGISTRO = '0' END-EXEC */

            var r3700_00_INSERT_RELATORIOS_DB_SELECT_1_Query1 = new R3700_00_INSERT_RELATORIOS_DB_SELECT_1_Query1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R3700_00_INSERT_RELATORIOS_DB_SELECT_1_Query1.Execute(r3700_00_INSERT_RELATORIOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RELATORI_COD_USUARIO, RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO);
            }


        }

        [StopWatch]
        /*" R3700-00-INSERT-RELATORIOS-DB-UPDATE-1 */
        public void R3700_00_INSERT_RELATORIOS_DB_UPDATE_1()
        {
            /*" -8595- EXEC SQL UPDATE SEGUROS.RELATORIOS SET SIT_REGISTRO = '1' WHERE NUM_CERTIFICADO = :PROPOFID-NUM-PROPOSTA-SIVPF AND COD_RELATORIO = 'VA0469B' AND SIT_REGISTRO = '0' END-EXEC */

            var r3700_00_INSERT_RELATORIOS_DB_UPDATE_1_Update1 = new R3700_00_INSERT_RELATORIOS_DB_UPDATE_1_Update1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            R3700_00_INSERT_RELATORIOS_DB_UPDATE_1_Update1.Execute(r3700_00_INSERT_RELATORIOS_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R3700-00-INSERT-RELATORIOS-DB-INSERT-1 */
        public void R3700_00_INSERT_RELATORIOS_DB_INSERT_1()
        {
            /*" -8716- EXEC SQL INSERT INTO SEGUROS.RELATORIOS ( COD_USUARIO , DATA_SOLICITACAO , IDE_SISTEMA , COD_RELATORIO , NUM_COPIAS , QUANTIDADE , PERI_INICIAL , PERI_FINAL , DATA_REFERENCIA , MES_REFERENCIA , ANO_REFERENCIA , ORGAO_EMISSOR , COD_FONTE , COD_PRODUTOR , RAMO_EMISSOR , COD_MODALIDADE , COD_CONGENERE , NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , NUM_CERTIFICADO , NUM_TITULO , COD_SUBGRUPO , COD_OPERACAO , COD_PLANO , OCORR_HISTORICO , NUM_APOL_LIDER , ENDOS_LIDER , NUM_PARC_LIDER , NUM_SINISTRO , NUM_SINI_LIDER , NUM_ORDEM , COD_MOEDA , TIPO_CORRECAO , SIT_REGISTRO , IND_PREV_DEFINIT , IND_ANAL_RESUMO , COD_EMPRESA , PERI_RENOVACAO , PCT_AUMENTO ,TIMESTAMP ) VALUES ( 'VA0601B' , :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO, 'VA' , 'VA0469B' , :RELATORI-NUM-COPIAS, :WHOST-BCO-RELAT, :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO, :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO, :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO, :DCLPROPOSTA-FIDELIZ.PROPOFID-AGECTADEB, :DCLPROPOSTA-FIDELIZ.PROPOFID-OPRCTADEB, :DCLPROPOSTA-FIDELIZ.PROPOFID-DIGCTADEB, 0, 0, 0, 0, 0, :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE, 0, 1, :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF, 0, :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO, 16, 0, 0, ' ' , ' ' , 0, :DCLPROPOSTA-FIDELIZ.PROPOFID-NUMCTADEB, ' ' , :WHOST-SIN-RELAT, 0, ' ' , '0' , ' ' , ' ' , NULL, 0, 0, CURRENT TIMESTAMP) END-EXEC. */

            var r3700_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1 = new R3700_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                RELATORI_NUM_COPIAS = RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS.ToString(),
                WHOST_BCO_RELAT = WHOST_BCO_RELAT.ToString(),
                PROPOFID_AGECTADEB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTADEB.ToString(),
                PROPOFID_OPRCTADEB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTADEB.ToString(),
                PROPOFID_DIGCTADEB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTADEB.ToString(),
                PROPSSVD_NUM_APOLICE = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.ToString(),
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                PROPSSVD_COD_SUBGRUPO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.ToString(),
                PROPOFID_NUMCTADEB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTADEB.ToString(),
                WHOST_SIN_RELAT = WHOST_SIN_RELAT.ToString(),
            };

            R3700_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1.Execute(r3700_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3700_99_SAIDA*/

        [StopWatch]
        /*" R4300-00-TRATA-CLIENTE-EMPRESA-SECTION */
        private void R4300_00_TRATA_CLIENTE_EMPRESA_SECTION()
        {
            /*" -8730- MOVE '4300-00-TRATA-CLIENTE-EMPRESA' TO PARAGRAFO. */
            _.Move("4300-00-TRATA-CLIENTE-EMPRESA", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8731- MOVE 'DECLARE CURSOR CLIENTES EMP  ' TO COMANDO. */
            _.Move("DECLARE CURSOR CLIENTES EMP  ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8733- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8734- MOVE 0 TO WS-JA-E-CLIENTE-EMP. */
            _.Move(0, WORK_AREA.WS_JA_E_CLIENTE_EMP);

            /*" -8736- MOVE PROFIDCO-INFORMACAO-COMPL TO R6C-EMPRESA-COMPACTADO */
            _.Move(PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_INFORMACAO_COMPL, BIEMPCOM.R6C_EMPRESA_COMPACTADO);

            /*" -8739- MOVE R6C-CNPJ-MEI TO WHOST-CGCCPF */
            _.Move(BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_CNPJ_MEI, WHOST_CGCCPF);

            /*" -8744- PERFORM R4300_00_TRATA_CLIENTE_EMPRESA_DB_DECLARE_1 */

            R4300_00_TRATA_CLIENTE_EMPRESA_DB_DECLARE_1();

            /*" -8747- MOVE 78 TO SII */
            _.Move(78, WS_HORAS.SII);

            /*" -8748- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -8748- PERFORM R4300_00_TRATA_CLIENTE_EMPRESA_DB_OPEN_1 */

            R4300_00_TRATA_CLIENTE_EMPRESA_DB_OPEN_1();

            /*" -8751- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -8752- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -8753- DISPLAY 'VA0601B - PROBLEMAS NO DECLARE CLIENTES EMP' */
                _.Display($"VA0601B - PROBLEMAS NO DECLARE CLIENTES EMP");

                /*" -8755- DISPLAY '          NUM PROPOSTA..............   ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          NUM PROPOSTA..............   {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -8757- DISPLAY '          COD CLIENTE...............   ' COD-CLIENTE OF DCLCLIENTES */
                _.Display($"          COD CLIENTE...............   {CLIENTE.DCLCLIENTES.COD_CLIENTE}");

                /*" -8759- DISPLAY '          SQLCODE...................   ' SQLCODE */
                _.Display($"          SQLCODE...................   {DB.SQLCODE}");

                /*" -8761- MOVE 2 TO W-TRATA-CLIENTE. */
                _.Move(2, WORK_AREA.W_TRATA_CLIENTE);
            }


            /*" -8762- MOVE 'FETCH CLIENTES               ' TO COMANDO. */
            _.Move("FETCH CLIENTES               ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8765- PERFORM R4300_00_TRATA_CLIENTE_EMPRESA_DB_FETCH_1 */

            R4300_00_TRATA_CLIENTE_EMPRESA_DB_FETCH_1();

            /*" -8768- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -8769- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -8769- PERFORM R4300_00_TRATA_CLIENTE_EMPRESA_DB_CLOSE_1 */

                    R4300_00_TRATA_CLIENTE_EMPRESA_DB_CLOSE_1();

                    /*" -8771- PERFORM R4310-00-INSERT-CLIENTES */

                    R4310_00_INSERT_CLIENTES_SECTION();

                    /*" -8773- PERFORM R4400-00-TRATA-ENDERECOS */

                    R4400_00_TRATA_ENDERECOS_SECTION();

                    /*" -8774- GO TO R4300-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R4300_99_SAIDA*/ //GOTO
                    return;

                    /*" -8775- ELSE */
                }
                else
                {


                    /*" -8776- DISPLAY 'VA0601B - PROBLEMAS NO FETCH   CLIENTES' */
                    _.Display($"VA0601B - PROBLEMAS NO FETCH   CLIENTES");

                    /*" -8778- DISPLAY '          NUM PROPOSTA..............   ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          NUM PROPOSTA..............   {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -8780- DISPLAY '          COD CLIENTE...............   ' COD-CLIENTE OF DCLCLIENTES */
                    _.Display($"          COD CLIENTE...............   {CLIENTE.DCLCLIENTES.COD_CLIENTE}");

                    /*" -8782- DISPLAY '          SQLCODE...................   ' SQLCODE */
                    _.Display($"          SQLCODE...................   {DB.SQLCODE}");

                    /*" -8783- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -8785- END-IF. */
                }

            }


            /*" -8785- PERFORM R4300_00_TRATA_CLIENTE_EMPRESA_DB_CLOSE_2 */

            R4300_00_TRATA_CLIENTE_EMPRESA_DB_CLOSE_2();

            /*" -8789- MOVE 1 TO WS-JA-E-CLIENTE-EMP. */
            _.Move(1, WORK_AREA.WS_JA_E_CLIENTE_EMP);

            /*" -8790- PERFORM R4400-00-TRATA-ENDERECOS */

            R4400_00_TRATA_ENDERECOS_SECTION();

            /*" -8790- . */

        }

        [StopWatch]
        /*" R4300-00-TRATA-CLIENTE-EMPRESA-DB-OPEN-1 */
        public void R4300_00_TRATA_CLIENTE_EMPRESA_DB_OPEN_1()
        {
            /*" -8748- EXEC SQL OPEN CEMPRESA END-EXEC. */

            CEMPRESA.Open();

        }

        [StopWatch]
        /*" R6000-00-DECLARE-AGENCEF-DB-DECLARE-1 */
        public void R6000_00_DECLARE_AGENCEF_DB_DECLARE_1()
        {
            /*" -9631- EXEC SQL DECLARE C01_AGENCEF CURSOR FOR SELECT A.COD_AGENCIA, B.COD_FONTE FROM SEGUROS.AGENCIAS_CEF A, SEGUROS.MALHA_CEF B WHERE A.COD_ESCNEG > 99 AND A.COD_ESCNEG = B.COD_SUREG ORDER BY A.COD_AGENCIA END-EXEC. */
            C01_AGENCEF = new VA0601B_C01_AGENCEF(false);
            string GetQuery_C01_AGENCEF()
            {
                var query = @$"SELECT A.COD_AGENCIA
							, 
							B.COD_FONTE 
							FROM SEGUROS.AGENCIAS_CEF A
							, 
							SEGUROS.MALHA_CEF B 
							WHERE A.COD_ESCNEG > 99 
							AND A.COD_ESCNEG = B.COD_SUREG 
							ORDER BY A.COD_AGENCIA";

                return query;
            }
            C01_AGENCEF.GetQueryEvent += GetQuery_C01_AGENCEF;

        }

        [StopWatch]
        /*" R4300-00-TRATA-CLIENTE-EMPRESA-DB-FETCH-1 */
        public void R4300_00_TRATA_CLIENTE_EMPRESA_DB_FETCH_1()
        {
            /*" -8765- EXEC SQL FETCH CEMPRESA INTO :WHOST-COD-CLIENTE END-EXEC. */

            if (CEMPRESA.Fetch())
            {
                _.Move(CEMPRESA.WHOST_COD_CLIENTE, WHOST_COD_CLIENTE);
            }

        }

        [StopWatch]
        /*" R4300-00-TRATA-CLIENTE-EMPRESA-DB-CLOSE-1 */
        public void R4300_00_TRATA_CLIENTE_EMPRESA_DB_CLOSE_1()
        {
            /*" -8769- EXEC SQL CLOSE CEMPRESA END-EXEC */

            CEMPRESA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4300_99_SAIDA*/

        [StopWatch]
        /*" R4300-00-TRATA-CLIENTE-EMPRESA-DB-CLOSE-2 */
        public void R4300_00_TRATA_CLIENTE_EMPRESA_DB_CLOSE_2()
        {
            /*" -8785- EXEC SQL CLOSE CEMPRESA END-EXEC. */

            CEMPRESA.Close();

        }

        [StopWatch]
        /*" R4310-00-INSERT-CLIENTES-SECTION */
        private void R4310_00_INSERT_CLIENTES_SECTION()
        {
            /*" -8800- MOVE '4310-00-INSERT-CLIENTES      ' TO PARAGRAFO. */
            _.Move("4310-00-INSERT-CLIENTES      ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8801- MOVE 'INSERT CLIENTES - EMP        ' TO COMANDO. */
            _.Move("INSERT CLIENTES - EMP        ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8802- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8804- MOVE R6C-RAZAO-SOCIAL-MEI TO NOME-RAZAO OF DCLCLIENTES. */
            _.Move(BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_RAZAO_SOCIAL_MEI, CLIENTE.DCLCLIENTES.NOME_RAZAO);

            /*" -8806- MOVE 'J' TO TIPO-PESSOA OF DCLCLIENTES. */
            _.Move("J", CLIENTE.DCLCLIENTES.TIPO_PESSOA);

            /*" -8808- MOVE R6C-CNPJ-MEI TO CGCCPF OF DCLCLIENTES. */
            _.Move(BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_CNPJ_MEI, CLIENTE.DCLCLIENTES.CGCCPF);

            /*" -8810- MOVE '0' TO SIT-REGISTRO OF DCLCLIENTES. */
            _.Move("0", CLIENTE.DCLCLIENTES.SIT_REGISTRO);

            /*" -8812- MOVE R6C-DATA-CONSTITUICAO-MEI(5:4) TO DATA-NASCIMENTO OF DCLCLIENTES (1:4) */
            _.MoveAtPosition(BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_DATA_CONSTITUICAO_MEI.Substring(5, 4), PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO, 1, 4);

            /*" -8814- MOVE '-' TO DATA-NASCIMENTO OF DCLCLIENTES (5:1) */
            _.MoveAtPosition("-", PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO, 5, 1);

            /*" -8816- MOVE R6C-DATA-CONSTITUICAO-MEI(3:2) TO DATA-NASCIMENTO OF DCLCLIENTES (4:2) */
            _.MoveAtPosition(BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_DATA_CONSTITUICAO_MEI.Substring(3, 2), PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO, 4, 2);

            /*" -8818- MOVE '-' TO DATA-NASCIMENTO OF DCLCLIENTES (8:1) */
            _.MoveAtPosition("-", PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO, 8, 1);

            /*" -8821- MOVE R6C-DATA-CONSTITUICAO-MEI(1:2) TO DATA-NASCIMENTO OF DCLCLIENTES (9:2) */
            _.MoveAtPosition(BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_DATA_CONSTITUICAO_MEI.Substring(1, 2), PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO, 9, 2);

            /*" -8826- PERFORM R4310_00_INSERT_CLIENTES_DB_SELECT_1 */

            R4310_00_INSERT_CLIENTES_DB_SELECT_1();

            /*" -8829- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -8830- MOVE -1 TO VIND-DATA-NASCIMENTO */
                _.Move(-1, VIND_DATA_NASCIMENTO);

                /*" -8832- END-IF */
            }


            /*" -8834- MOVE 0 TO COD-EMPRESA OF DCLCLIENTES. */
            _.Move(0, CLIENTE.DCLCLIENTES.COD_EMPRESA);

            /*" -8837- MOVE R6C-COD-PORTE-MEI TO COD-PORTE-EMP OF DCLCLIENTES. */
            _.Move(BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_COD_PORTE_MEI, CLIENTE.DCLCLIENTES.COD_PORTE_EMP);

            /*" -8839- MOVE R6C-CNAE-MEI TO WS-CNAE-MEI */
            _.Move(BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_CNAE_MEI, WS_CNAE_MEI);

            /*" -8844- MOVE +0 TO VIND-COD-GRD-GRUPO-CBO VIND-COD-SUBGRUPO-CBO VIND-COD-GRUPO-BASE-CBO VIND-COD-SUBGR-BASE-CBO */
            _.Move(+0, VIND_COD_GRD_GRUPO_CBO, VIND_COD_SUBGRUPO_CBO, VIND_COD_GRUPO_BASE_CBO, VIND_COD_SUBGR_BASE_CBO);

            /*" -8846- MOVE WS-CNAE-MEI (1:2) TO COD-GRD-GRUPO-CBO OF DCLCLIENTES. */
            _.Move(WS_CNAE_MEI.Substring(1, 2), CLIENTE.DCLCLIENTES.COD_GRD_GRUPO_CBO);

            /*" -8848- MOVE WS-CNAE-MEI (3:2) TO COD-SUBGRUPO-CBO OF DCLCLIENTES. */
            _.Move(WS_CNAE_MEI.Substring(3, 2), CLIENTE.DCLCLIENTES.COD_SUBGRUPO_CBO);

            /*" -8850- MOVE WS-CNAE-MEI (5:2) TO COD-GRUPO-BASE-CBO OF DCLCLIENTES. */
            _.Move(WS_CNAE_MEI.Substring(5, 2), CLIENTE.DCLCLIENTES.COD_GRUPO_BASE_CBO);

            /*" -8851- MOVE WS-CNAE-MEI (7:2) TO COD-SUBGR-BASE-CBO OF DCLCLIENTES. */
            _.Move(WS_CNAE_MEI.Substring(7, 2), CLIENTE.DCLCLIENTES.COD_SUBGR_BASE_CBO);

            /*" -0- FLUXCONTROL_PERFORM R4310_10_INSERT_CLIENTES */

            R4310_10_INSERT_CLIENTES();

        }

        [StopWatch]
        /*" R4310-00-INSERT-CLIENTES-DB-SELECT-1 */
        public void R4310_00_INSERT_CLIENTES_DB_SELECT_1()
        {
            /*" -8826- EXEC SQL SELECT DATE(:DCLCLIENTES.DATA-NASCIMENTO) INTO :WHOST-DATA-NASCIMENTO FROM SYSIBM.SYSDUMMY1 WITH UR END-EXEC. */

            var r4310_00_INSERT_CLIENTES_DB_SELECT_1_Query1 = new R4310_00_INSERT_CLIENTES_DB_SELECT_1_Query1()
            {
                DATA_NASCIMENTO = CLIENTE.DCLCLIENTES.DATA_NASCIMENTO.ToString(),
            };

            var executed_1 = R4310_00_INSERT_CLIENTES_DB_SELECT_1_Query1.Execute(r4310_00_INSERT_CLIENTES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DATA_NASCIMENTO, WHOST_DATA_NASCIMENTO);
            }


        }

        [StopWatch]
        /*" R4310-10-INSERT-CLIENTES */
        private void R4310_10_INSERT_CLIENTES(bool isPerform = false)
        {
            /*" -8856- ADD 1 TO NUM-CLIENTE OF DCLNUMERO-OUTROS. */
            NUMOUTRO.DCLNUMERO_OUTROS.NUM_CLIENTE.Value = NUMOUTRO.DCLNUMERO_OUTROS.NUM_CLIENTE + 1;

            /*" -8859- MOVE NUM-CLIENTE OF DCLNUMERO-OUTROS TO WHOST-COD-CLIENTE. */
            _.Move(NUMOUTRO.DCLNUMERO_OUTROS.NUM_CLIENTE, WHOST_COD_CLIENTE);

            /*" -8860- MOVE 79 TO SII */
            _.Move(79, WS_HORAS.SII);

            /*" -8861- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -8904- PERFORM R4310_10_INSERT_CLIENTES_DB_INSERT_1 */

            R4310_10_INSERT_CLIENTES_DB_INSERT_1();

            /*" -8906- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -8907- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -8908- IF SQLCODE = -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -8909- GO TO R4310-10-INSERT-CLIENTES */
                    new Task(() => R4310_10_INSERT_CLIENTES()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -8910- ELSE */
                }
                else
                {


                    /*" -8911- DISPLAY 'VA0601B - PROBLEMAS NO INSERT CLIENTES EMP ' */
                    _.Display($"VA0601B - PROBLEMAS NO INSERT CLIENTES EMP ");

                    /*" -8913- DISPLAY '          NUM PROPOSTA..............       ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          NUM PROPOSTA..............       {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -8915- DISPLAY '          COD CLIENTE...............       ' COD-CLIENTE OF DCLCLIENTES */
                    _.Display($"          COD CLIENTE...............       {CLIENTE.DCLCLIENTES.COD_CLIENTE}");

                    /*" -8917- DISPLAY '          SQLCODE...................       ' SQLCODE */
                    _.Display($"          SQLCODE...................       {DB.SQLCODE}");

                    /*" -8917- MOVE 2 TO W-TRATA-CLIENTE. */
                    _.Move(2, WORK_AREA.W_TRATA_CLIENTE);
                }

            }


        }

        [StopWatch]
        /*" R4310-10-INSERT-CLIENTES-DB-INSERT-1 */
        public void R4310_10_INSERT_CLIENTES_DB_INSERT_1()
        {
            /*" -8904- EXEC SQL INSERT INTO SEGUROS.CLIENTES (COD_CLIENTE, NOME_RAZAO, TIPO_PESSOA, CGCCPF, SIT_REGISTRO, DATA_NASCIMENTO, COD_EMPRESA, COD_PORTE_EMP, COD_NATUREZA_ATIV, COD_RAMO_ATIVIDADE, COD_ATIVIDADE, IDE_SEXO, ESTADO_CIVIL, COD_GRD_GRUPO_CBO, COD_SUBGRUPO_CBO, COD_GRUPO_BASE_CBO, COD_SUBGR_BASE_CBO) VALUES (:WHOST-COD-CLIENTE, :DCLCLIENTES.NOME-RAZAO, :DCLCLIENTES.TIPO-PESSOA, :DCLCLIENTES.CGCCPF, :DCLCLIENTES.SIT-REGISTRO, :DCLCLIENTES.DATA-NASCIMENTO :VIND-DATA-NASCIMENTO, :DCLCLIENTES.COD-EMPRESA, NULL, NULL, NULL, NULL, NULL, NULL, :DCLCLIENTES.COD-GRD-GRUPO-CBO :VIND-COD-GRD-GRUPO-CBO, :DCLCLIENTES.COD-SUBGRUPO-CBO :VIND-COD-SUBGRUPO-CBO, :DCLCLIENTES.COD-GRUPO-BASE-CBO :VIND-COD-GRUPO-BASE-CBO, :DCLCLIENTES.COD-SUBGR-BASE-CBO :VIND-COD-SUBGR-BASE-CBO ) END-EXEC. */

            var r4310_10_INSERT_CLIENTES_DB_INSERT_1_Insert1 = new R4310_10_INSERT_CLIENTES_DB_INSERT_1_Insert1()
            {
                WHOST_COD_CLIENTE = WHOST_COD_CLIENTE.ToString(),
                NOME_RAZAO = CLIENTE.DCLCLIENTES.NOME_RAZAO.ToString(),
                TIPO_PESSOA = CLIENTE.DCLCLIENTES.TIPO_PESSOA.ToString(),
                CGCCPF = CLIENTE.DCLCLIENTES.CGCCPF.ToString(),
                SIT_REGISTRO = CLIENTE.DCLCLIENTES.SIT_REGISTRO.ToString(),
                DATA_NASCIMENTO = CLIENTE.DCLCLIENTES.DATA_NASCIMENTO.ToString(),
                VIND_DATA_NASCIMENTO = VIND_DATA_NASCIMENTO.ToString(),
                COD_EMPRESA = CLIENTE.DCLCLIENTES.COD_EMPRESA.ToString(),
                COD_GRD_GRUPO_CBO = CLIENTE.DCLCLIENTES.COD_GRD_GRUPO_CBO.ToString(),
                VIND_COD_GRD_GRUPO_CBO = VIND_COD_GRD_GRUPO_CBO.ToString(),
                COD_SUBGRUPO_CBO = CLIENTE.DCLCLIENTES.COD_SUBGRUPO_CBO.ToString(),
                VIND_COD_SUBGRUPO_CBO = VIND_COD_SUBGRUPO_CBO.ToString(),
                COD_GRUPO_BASE_CBO = CLIENTE.DCLCLIENTES.COD_GRUPO_BASE_CBO.ToString(),
                VIND_COD_GRUPO_BASE_CBO = VIND_COD_GRUPO_BASE_CBO.ToString(),
                COD_SUBGR_BASE_CBO = CLIENTE.DCLCLIENTES.COD_SUBGR_BASE_CBO.ToString(),
                VIND_COD_SUBGR_BASE_CBO = VIND_COD_SUBGR_BASE_CBO.ToString(),
            };

            R4310_10_INSERT_CLIENTES_DB_INSERT_1_Insert1.Execute(r4310_10_INSERT_CLIENTES_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4310_99_SAIDA*/

        [StopWatch]
        /*" R4400-00-TRATA-ENDERECOS-SECTION */
        private void R4400_00_TRATA_ENDERECOS_SECTION()
        {
            /*" -8928- MOVE '4400-00-TRATA-ENDERECO       ' TO PARAGRAFO. */
            _.Move("4400-00-TRATA-ENDERECO       ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8929- MOVE 'SELECT                       ' TO COMANDO. */
            _.Move("SELECT                       ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8931- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8933- MOVE R6C-ENDERECO TO WHOST-ENDERECO */
            _.Move(BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_ENDERECO, WHOST_ENDERECO);

            /*" -8935- MOVE R6C-BAIRRO TO WHOST-ENDERECO */
            _.Move(BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_BAIRRO, WHOST_ENDERECO);

            /*" -8937- MOVE R6C-BAIRRO TO WHOST-BAIRRO */
            _.Move(BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_BAIRRO, WHOST_BAIRRO);

            /*" -8939- MOVE R6C-CIDADE TO WHOST-CIDADE */
            _.Move(BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_CIDADE, WHOST_CIDADE);

            /*" -8941- MOVE R6C-UF TO WHOST-SIGLA-UF */
            _.Move(BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_UF, WHOST_SIGLA_UF);

            /*" -8943- MOVE R6C-CEP TO WHOST-CEP */
            _.Move(BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_CEP, WHOST_CEP);

            /*" -8945- MOVE R6C-DDD-COMERCIAL TO WHOST-DDD */
            _.Move(BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_DDD_COMERCIAL, WHOST_DDD);

            /*" -8947- MOVE R6C-TELEFONE-COMERCIAL TO WHOST-FONE */
            _.Move(BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_TELEFONE_COMERCIAL, WHOST_FONE);

            /*" -8948- MOVE 80 TO SII */
            _.Move(80, WS_HORAS.SII);

            /*" -8949- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -8950- IF WS-JA-E-CLIENTE-EMP EQUAL 1 */

            if (WORK_AREA.WS_JA_E_CLIENTE_EMP == 1)
            {

                /*" -8951- MOVE 'SELECT SEGUROS.ENDERECOS     ' TO COMANDO */
                _.Move("SELECT SEGUROS.ENDERECOS     ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -8971- PERFORM R4400_00_TRATA_ENDERECOS_DB_SELECT_1 */

                R4400_00_TRATA_ENDERECOS_DB_SELECT_1();

                /*" -8973- PERFORM R9100-00-TERMINO */

                R9100_00_TERMINO_SECTION();

                /*" -8974- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -8975- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -8976- PERFORM R4420-00-INSERT-ENDERECOS */

                        R4420_00_INSERT_ENDERECOS_SECTION();

                        /*" -8977- ELSE */
                    }
                    else
                    {


                        /*" -8978- IF SQLCODE EQUAL -811 */

                        if (DB.SQLCODE == -811)
                        {

                            /*" -8979- CONTINUE */

                            /*" -8980- ELSE */
                        }
                        else
                        {


                            /*" -8981- DISPLAY 'PROBLEMAS ACESSO ENDERECOS EMP ' */
                            _.Display($"PROBLEMAS ACESSO ENDERECOS EMP ");

                            /*" -8982- GO TO R9999-00-ROT-ERRO */

                            R9999_00_ROT_ERRO_SECTION(); //GOTO
                            return;

                            /*" -8983- END-IF */
                        }


                        /*" -8984- END-IF */
                    }


                    /*" -8985- ELSE */
                }
                else
                {


                    /*" -8986- CONTINUE */

                    /*" -8987- ELSE */
                }

            }
            else
            {


                /*" -8988- PERFORM R4420-00-INSERT-ENDERECOS */

                R4420_00_INSERT_ENDERECOS_SECTION();

                /*" -8990- END-IF */
            }


            /*" -8991- IF R6C-EMAIL NOT EQUAL SPACES */

            if (!BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_EMAIL.IsEmpty())
            {

                /*" -8992- PERFORM R4500-00-TRATA-EMAIL */

                R4500_00_TRATA_EMAIL_SECTION();

                /*" -8993- END-IF */
            }


            /*" -8993- . */

        }

        [StopWatch]
        /*" R4400-00-TRATA-ENDERECOS-DB-SELECT-1 */
        public void R4400_00_TRATA_ENDERECOS_DB_SELECT_1()
        {
            /*" -8971- EXEC SQL SELECT OCORR_ENDERECO, ENDERECO, BAIRRO, CIDADE, SIGLA_UF, CEP INTO :DCLENDERECOS.ENDERECO-OCORR-ENDERECO, :DCLENDERECOS.ENDERECO-ENDERECO, :DCLENDERECOS.ENDERECO-BAIRRO, :DCLENDERECOS.ENDERECO-CIDADE, :DCLENDERECOS.ENDERECO-SIGLA-UF, :DCLENDERECOS.ENDERECO-CEP FROM SEGUROS.ENDERECOS WHERE COD_CLIENTE = :WHOST-COD-CLIENTE AND ENDERECO = :WHOST-ENDERECO AND BAIRRO = :WHOST-BAIRRO AND CIDADE = :WHOST-CIDADE AND SIGLA_UF = :WHOST-SIGLA-UF AND CEP = :WHOST-CEP END-EXEC */

            var r4400_00_TRATA_ENDERECOS_DB_SELECT_1_Query1 = new R4400_00_TRATA_ENDERECOS_DB_SELECT_1_Query1()
            {
                WHOST_COD_CLIENTE = WHOST_COD_CLIENTE.ToString(),
                WHOST_ENDERECO = WHOST_ENDERECO.ToString(),
                WHOST_SIGLA_UF = WHOST_SIGLA_UF.ToString(),
                WHOST_BAIRRO = WHOST_BAIRRO.ToString(),
                WHOST_CIDADE = WHOST_CIDADE.ToString(),
                WHOST_CEP = WHOST_CEP.ToString(),
            };

            var executed_1 = R4400_00_TRATA_ENDERECOS_DB_SELECT_1_Query1.Execute(r4400_00_TRATA_ENDERECOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDERECO_OCORR_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO);
                _.Move(executed_1.ENDERECO_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO);
                _.Move(executed_1.ENDERECO_BAIRRO, ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO);
                _.Move(executed_1.ENDERECO_CIDADE, ENDERECO.DCLENDERECOS.ENDERECO_CIDADE);
                _.Move(executed_1.ENDERECO_SIGLA_UF, ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);
                _.Move(executed_1.ENDERECO_CEP, ENDERECO.DCLENDERECOS.ENDERECO_CEP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4400_99_SAIDA*/

        [StopWatch]
        /*" R4420-00-INSERT-ENDERECOS-SECTION */
        private void R4420_00_INSERT_ENDERECOS_SECTION()
        {
            /*" -9003- MOVE 'R4420-00-INSERT-ENDERECOS' TO PARAGRAFO */
            _.Move("R4420-00-INSERT-ENDERECOS", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9004- MOVE 'SELECT MAX OCORR ENDERECO' TO COMANDO */
            _.Move("SELECT MAX OCORR ENDERECO", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -9006- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9007- MOVE 81 TO SII */
            _.Move(81, WS_HORAS.SII);

            /*" -9008- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -9013- PERFORM R4420_00_INSERT_ENDERECOS_DB_SELECT_1 */

            R4420_00_INSERT_ENDERECOS_DB_SELECT_1();

            /*" -9016- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -9017- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -9018- DISPLAY 'PROBLEMAS NO MAX ENDERECOS EMP          ' */
                _.Display($"PROBLEMAS NO MAX ENDERECOS EMP          ");

                /*" -9020- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -9022- ADD 1 TO WHOST-OCORR-ENDERECO */
            WHOST_OCORR_ENDERECO.Value = WHOST_OCORR_ENDERECO + 1;

            /*" -9023- MOVE '4420-00-INSERT-ENDERECOS EMP ' TO PARAGRAFO. */
            _.Move("4420-00-INSERT-ENDERECOS EMP ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9025- MOVE 'INSERT ENDERECOS EMP         ' TO COMANDO. */
            _.Move("INSERT ENDERECOS EMP         ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -9026- MOVE 82 TO SII */
            _.Move(82, WS_HORAS.SII);

            /*" -9028- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -9046- PERFORM R4420_00_INSERT_ENDERECOS_DB_INSERT_1 */

            R4420_00_INSERT_ENDERECOS_DB_INSERT_1();

            /*" -9049- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -9050- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -9051- DISPLAY 'PROBLEMAS NO INSERT A ENDERECOS         ' */
                _.Display($"PROBLEMAS NO INSERT A ENDERECOS         ");

                /*" -9051- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4420-00-INSERT-ENDERECOS-DB-SELECT-1 */
        public void R4420_00_INSERT_ENDERECOS_DB_SELECT_1()
        {
            /*" -9013- EXEC SQL SELECT VALUE (MAX(OCORR_ENDERECO),0) INTO :WHOST-OCORR-ENDERECO FROM SEGUROS.ENDERECOS WHERE COD_CLIENTE = :WHOST-COD-CLIENTE END-EXEC */

            var r4420_00_INSERT_ENDERECOS_DB_SELECT_1_Query1 = new R4420_00_INSERT_ENDERECOS_DB_SELECT_1_Query1()
            {
                WHOST_COD_CLIENTE = WHOST_COD_CLIENTE.ToString(),
            };

            var executed_1 = R4420_00_INSERT_ENDERECOS_DB_SELECT_1_Query1.Execute(r4420_00_INSERT_ENDERECOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_OCORR_ENDERECO, WHOST_OCORR_ENDERECO);
            }


        }

        [StopWatch]
        /*" R4420-00-INSERT-ENDERECOS-DB-INSERT-1 */
        public void R4420_00_INSERT_ENDERECOS_DB_INSERT_1()
        {
            /*" -9046- EXEC SQL INSERT INTO SEGUROS.ENDERECOS VALUES (:WHOST-COD-CLIENTE, 2, :WHOST-OCORR-ENDERECO, :WHOST-ENDERECO, :WHOST-BAIRRO, :WHOST-CIDADE, :WHOST-SIGLA-UF, :WHOST-CEP, :WHOST-DDD, :WHOST-FONE, 0, 0, '0' , NULL , NULL) END-EXEC. */

            var r4420_00_INSERT_ENDERECOS_DB_INSERT_1_Insert1 = new R4420_00_INSERT_ENDERECOS_DB_INSERT_1_Insert1()
            {
                WHOST_COD_CLIENTE = WHOST_COD_CLIENTE.ToString(),
                WHOST_OCORR_ENDERECO = WHOST_OCORR_ENDERECO.ToString(),
                WHOST_ENDERECO = WHOST_ENDERECO.ToString(),
                WHOST_BAIRRO = WHOST_BAIRRO.ToString(),
                WHOST_CIDADE = WHOST_CIDADE.ToString(),
                WHOST_SIGLA_UF = WHOST_SIGLA_UF.ToString(),
                WHOST_CEP = WHOST_CEP.ToString(),
                WHOST_DDD = WHOST_DDD.ToString(),
                WHOST_FONE = WHOST_FONE.ToString(),
            };

            R4420_00_INSERT_ENDERECOS_DB_INSERT_1_Insert1.Execute(r4420_00_INSERT_ENDERECOS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4420_99_SAIDA*/

        [StopWatch]
        /*" R4500-00-TRATA-EMAIL-SECTION */
        private void R4500_00_TRATA_EMAIL_SECTION()
        {
            /*" -9062- MOVE '4500-00-TRATA-EMAIL          ' TO PARAGRAFO. */
            _.Move("4500-00-TRATA-EMAIL          ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9063- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9066- MOVE R6C-EMAIL TO WHOST-EMAIL */
            _.Move(BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_EMAIL, WHOST_EMAIL);

            /*" -9067- IF WS-JA-E-CLIENTE-EMP EQUAL 1 */

            if (WORK_AREA.WS_JA_E_CLIENTE_EMP == 1)
            {

                /*" -9068- MOVE 83 TO SII */
                _.Move(83, WS_HORAS.SII);

                /*" -9069- PERFORM R9000-00-INICIO */

                R9000_00_INICIO_SECTION();

                /*" -9070- MOVE 'SELECT SEGUROS.CLIENTE_EMAIL ' TO COMANDO */
                _.Move("SELECT SEGUROS.CLIENTE_EMAIL ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -9075- PERFORM R4500_00_TRATA_EMAIL_DB_SELECT_1 */

                R4500_00_TRATA_EMAIL_DB_SELECT_1();

                /*" -9077- PERFORM R9100-00-TERMINO */

                R9100_00_TERMINO_SECTION();

                /*" -9078- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -9079- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -9080- PERFORM R4520-00-INSERT-EMAIL */

                        R4520_00_INSERT_EMAIL_SECTION();

                        /*" -9081- ELSE */
                    }
                    else
                    {


                        /*" -9082- DISPLAY 'PROBLEMAS ACESSO CLIENTE_EMAIL EMP' */
                        _.Display($"PROBLEMAS ACESSO CLIENTE_EMAIL EMP");

                        /*" -9083- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -9084- END-IF */
                    }


                    /*" -9085- ELSE */
                }
                else
                {


                    /*" -9086- PERFORM R4510-00-ALTERA-EMAIL */

                    R4510_00_ALTERA_EMAIL_SECTION();

                    /*" -9087- ELSE */
                }

            }
            else
            {


                /*" -9087- PERFORM R4520-00-INSERT-EMAIL. */

                R4520_00_INSERT_EMAIL_SECTION();
            }


        }

        [StopWatch]
        /*" R4500-00-TRATA-EMAIL-DB-SELECT-1 */
        public void R4500_00_TRATA_EMAIL_DB_SELECT_1()
        {
            /*" -9075- EXEC SQL SELECT EMAIL INTO :CLIENEMA-EMAIL FROM SEGUROS.CLIENTE_EMAIL WHERE COD_CLIENTE = :WHOST-COD-CLIENTE END-EXEC */

            var r4500_00_TRATA_EMAIL_DB_SELECT_1_Query1 = new R4500_00_TRATA_EMAIL_DB_SELECT_1_Query1()
            {
                WHOST_COD_CLIENTE = WHOST_COD_CLIENTE.ToString(),
            };

            var executed_1 = R4500_00_TRATA_EMAIL_DB_SELECT_1_Query1.Execute(r4500_00_TRATA_EMAIL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENEMA_EMAIL, CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_EMAIL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4500_99_SAIDA*/

        [StopWatch]
        /*" R4510-00-ALTERA-EMAIL-SECTION */
        private void R4510_00_ALTERA_EMAIL_SECTION()
        {
            /*" -9097- MOVE '4510-00-ALTERA-EMAIL EMP     ' TO PARAGRAFO. */
            _.Move("4510-00-ALTERA-EMAIL EMP     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9098- MOVE 'UPDATE CLIENTE_EMAIL EMP     ' TO COMANDO. */
            _.Move("UPDATE CLIENTE_EMAIL EMP     ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -9100- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9101- MOVE 84 TO SII */
            _.Move(84, WS_HORAS.SII);

            /*" -9102- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -9106- PERFORM R4510_00_ALTERA_EMAIL_DB_UPDATE_1 */

            R4510_00_ALTERA_EMAIL_DB_UPDATE_1();

            /*" -9108- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -9109- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -9110- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -9111- DISPLAY 'EMAIL NAO CADASTRADO ' */
                    _.Display($"EMAIL NAO CADASTRADO ");

                    /*" -9112- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -9114- ELSE */
                }
                else
                {


                    /*" -9115- DISPLAY 'PROBLEMAS ACESSO CLIENTE_EMAIL ' */
                    _.Display($"PROBLEMAS ACESSO CLIENTE_EMAIL ");

                    /*" -9115- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R4510-00-ALTERA-EMAIL-DB-UPDATE-1 */
        public void R4510_00_ALTERA_EMAIL_DB_UPDATE_1()
        {
            /*" -9106- EXEC SQL UPDATE SEGUROS.CLIENTE_EMAIL SET EMAIL = :WHOST-EMAIL WHERE COD_CLIENTE = :WHOST-COD-CLIENTE END-EXEC */

            var r4510_00_ALTERA_EMAIL_DB_UPDATE_1_Update1 = new R4510_00_ALTERA_EMAIL_DB_UPDATE_1_Update1()
            {
                WHOST_EMAIL = WHOST_EMAIL.ToString(),
                WHOST_COD_CLIENTE = WHOST_COD_CLIENTE.ToString(),
            };

            R4510_00_ALTERA_EMAIL_DB_UPDATE_1_Update1.Execute(r4510_00_ALTERA_EMAIL_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4510_99_SAIDA*/

        [StopWatch]
        /*" R4520-00-INSERT-EMAIL-SECTION */
        private void R4520_00_INSERT_EMAIL_SECTION()
        {
            /*" -9125- MOVE 'R4520-00-INSERT-EMAIL EMP' TO PARAGRAFO. */
            _.Move("R4520-00-INSERT-EMAIL EMP", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9126- MOVE 'SELECT MAX CLIENTE_EMAIL EMP' TO COMANDO */
            _.Move("SELECT MAX CLIENTE_EMAIL EMP", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -9128- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9129- MOVE 85 TO SII */
            _.Move(85, WS_HORAS.SII);

            /*" -9130- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -9135- PERFORM R4520_00_INSERT_EMAIL_DB_SELECT_1 */

            R4520_00_INSERT_EMAIL_DB_SELECT_1();

            /*" -9138- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -9139- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -9140- DISPLAY 'PROBLEMAS NO MAX CLEINTE_EMAIL          ' */
                _.Display($"PROBLEMAS NO MAX CLEINTE_EMAIL          ");

                /*" -9142- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -9144- ADD 1 TO CLIENEMA-SEQ-EMAIL. */
            CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_SEQ_EMAIL.Value = CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_SEQ_EMAIL + 1;

            /*" -9145- MOVE '4520-00-INSERT-CLIENTE-EMAIL ' TO PARAGRAFO. */
            _.Move("4520-00-INSERT-CLIENTE-EMAIL ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9147- MOVE 'INSERT CLIENTE-EMAIL EMP     ' TO COMANDO. */
            _.Move("INSERT CLIENTE-EMAIL EMP     ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -9148- MOVE 86 TO SII */
            _.Move(86, WS_HORAS.SII);

            /*" -9149- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -9155- PERFORM R4520_00_INSERT_EMAIL_DB_INSERT_1 */

            R4520_00_INSERT_EMAIL_DB_INSERT_1();

            /*" -9158- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -9159- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -9160- DISPLAY 'PROBLEMAS NO INSERT A CLIENTE_EMAIL EMP ' */
                _.Display($"PROBLEMAS NO INSERT A CLIENTE_EMAIL EMP ");

                /*" -9160- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4520-00-INSERT-EMAIL-DB-SELECT-1 */
        public void R4520_00_INSERT_EMAIL_DB_SELECT_1()
        {
            /*" -9135- EXEC SQL SELECT VALUE (MAX(SEQ_EMAIL),0) INTO :CLIENEMA-SEQ-EMAIL FROM SEGUROS.CLIENTE_EMAIL WHERE COD_CLIENTE = :WHOST-COD-CLIENTE END-EXEC */

            var r4520_00_INSERT_EMAIL_DB_SELECT_1_Query1 = new R4520_00_INSERT_EMAIL_DB_SELECT_1_Query1()
            {
                WHOST_COD_CLIENTE = WHOST_COD_CLIENTE.ToString(),
            };

            var executed_1 = R4520_00_INSERT_EMAIL_DB_SELECT_1_Query1.Execute(r4520_00_INSERT_EMAIL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENEMA_SEQ_EMAIL, CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_SEQ_EMAIL);
            }


        }

        [StopWatch]
        /*" R4520-00-INSERT-EMAIL-DB-INSERT-1 */
        public void R4520_00_INSERT_EMAIL_DB_INSERT_1()
        {
            /*" -9155- EXEC SQL INSERT INTO SEGUROS.CLIENTE_EMAIL VALUES (:WHOST-COD-CLIENTE, :CLIENEMA-SEQ-EMAIL, :WHOST-EMAIL) END-EXEC. */

            var r4520_00_INSERT_EMAIL_DB_INSERT_1_Insert1 = new R4520_00_INSERT_EMAIL_DB_INSERT_1_Insert1()
            {
                WHOST_COD_CLIENTE = WHOST_COD_CLIENTE.ToString(),
                CLIENEMA_SEQ_EMAIL = CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_SEQ_EMAIL.ToString(),
                WHOST_EMAIL = WHOST_EMAIL.ToString(),
            };

            R4520_00_INSERT_EMAIL_DB_INSERT_1_Insert1.Execute(r4520_00_INSERT_EMAIL_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4520_99_SAIDA*/

        [StopWatch]
        /*" R4600-00-INSERT-CLIENTE-EMP-SECTION */
        private void R4600_00_INSERT_CLIENTE_EMP_SECTION()
        {
            /*" -9170- MOVE 'R4600-00-INSERT-GE-CLIENTE-EMP' TO PARAGRAFO. */
            _.Move("R4600-00-INSERT-GE-CLIENTE-EMP", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9171- MOVE 'INSERT GE_CLIENTE_EMPRESA  ' TO COMANDO */
            _.Move("INSERT GE_CLIENTE_EMPRESA  ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -9172- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9174- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO GE085-NUM-CERTIFICADO */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, GE085.DCLGE_CLIENTE_EMPRESA.GE085_NUM_CERTIFICADO);

            /*" -9176- MOVE 'PF' TO GE085-IND-TP-PROPOSTA */
            _.Move("PF", GE085.DCLGE_CLIENTE_EMPRESA.GE085_IND_TP_PROPOSTA);

            /*" -9178- MOVE WHOST-COD-CLIENTE TO GE085-COD-CLIENTE-PJ */
            _.Move(WHOST_COD_CLIENTE, GE085.DCLGE_CLIENTE_EMPRESA.GE085_COD_CLIENTE_PJ);

            /*" -9180- MOVE 2 TO GE085-COD-ENDERECO-PJ */
            _.Move(2, GE085.DCLGE_CLIENTE_EMPRESA.GE085_COD_ENDERECO_PJ);

            /*" -9182- MOVE COD-CLIENTE OF DCLCLIENTES TO GE085-COD-CLIENTE-PF */
            _.Move(CLIENTE.DCLCLIENTES.COD_CLIENTE, GE085.DCLGE_CLIENTE_EMPRESA.GE085_COD_CLIENTE_PF);

            /*" -9184- MOVE 'VA0601B' TO GE085-COD-USUARIO */
            _.Move("VA0601B", GE085.DCLGE_CLIENTE_EMPRESA.GE085_COD_USUARIO);

            /*" -9187- MOVE 'VA0601B' TO GE085-NOM-PROGRAMA */
            _.Move("VA0601B", GE085.DCLGE_CLIENTE_EMPRESA.GE085_NOM_PROGRAMA);

            /*" -9188- MOVE 87 TO SII */
            _.Move(87, WS_HORAS.SII);

            /*" -9189- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -9202- PERFORM R4600_00_INSERT_CLIENTE_EMP_DB_INSERT_1 */

            R4600_00_INSERT_CLIENTE_EMP_DB_INSERT_1();

            /*" -9205- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -9206- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -9207- DISPLAY 'PROBLEMAS NO INSERT A CLIENTE_PESSOA EMP ' */
                _.Display($"PROBLEMAS NO INSERT A CLIENTE_PESSOA EMP ");

                /*" -9207- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4600-00-INSERT-CLIENTE-EMP-DB-INSERT-1 */
        public void R4600_00_INSERT_CLIENTE_EMP_DB_INSERT_1()
        {
            /*" -9202- EXEC SQL INSERT INTO SEGUROS.GE_CLIENTE_EMPRESA VALUES ( :GE085-NUM-CERTIFICADO, :GE085-IND-TP-PROPOSTA, :GE085-COD-CLIENTE-PJ, :GE085-COD-ENDERECO-PJ, :GE085-COD-CLIENTE-PF, :GE085-COD-USUARIO, :GE085-NOM-PROGRAMA, CURRENT TIMESTAMP ) END-EXEC. */

            var r4600_00_INSERT_CLIENTE_EMP_DB_INSERT_1_Insert1 = new R4600_00_INSERT_CLIENTE_EMP_DB_INSERT_1_Insert1()
            {
                GE085_NUM_CERTIFICADO = GE085.DCLGE_CLIENTE_EMPRESA.GE085_NUM_CERTIFICADO.ToString(),
                GE085_IND_TP_PROPOSTA = GE085.DCLGE_CLIENTE_EMPRESA.GE085_IND_TP_PROPOSTA.ToString(),
                GE085_COD_CLIENTE_PJ = GE085.DCLGE_CLIENTE_EMPRESA.GE085_COD_CLIENTE_PJ.ToString(),
                GE085_COD_ENDERECO_PJ = GE085.DCLGE_CLIENTE_EMPRESA.GE085_COD_ENDERECO_PJ.ToString(),
                GE085_COD_CLIENTE_PF = GE085.DCLGE_CLIENTE_EMPRESA.GE085_COD_CLIENTE_PF.ToString(),
                GE085_COD_USUARIO = GE085.DCLGE_CLIENTE_EMPRESA.GE085_COD_USUARIO.ToString(),
                GE085_NOM_PROGRAMA = GE085.DCLGE_CLIENTE_EMPRESA.GE085_NOM_PROGRAMA.ToString(),
            };

            R4600_00_INSERT_CLIENTE_EMP_DB_INSERT_1_Insert1.Execute(r4600_00_INSERT_CLIENTE_EMP_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4600_99_SAIDA*/

        [StopWatch]
        /*" R5632-00-SELECT-PROPOSTAVA-SECTION */
        private void R5632_00_SELECT_PROPOSTAVA_SECTION()
        {
            /*" -9217- MOVE 'R5632-00-SELECT-PROPOSTAVA  ' TO PARAGRAFO. */
            _.Move("R5632-00-SELECT-PROPOSTAVA  ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9218- MOVE 'SELECT PROPOSTAS-VA         ' TO COMANDO. */
            _.Move("SELECT PROPOSTAS-VA         ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -9220- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9223- MOVE PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO NUM-CERTIFICADO OF DCLPROPOSTAS-VA. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO);

            /*" -9224- MOVE 87 TO SII */
            _.Move(87, WS_HORAS.SII);

            /*" -9225- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -9230- PERFORM R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1 */

            R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1();

            /*" -9233- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -9234- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -9235- MOVE 'SIM' TO WEXISTE-PRPVA */
                _.Move("SIM", WEXISTE_PRPVA);

                /*" -9236- DISPLAY ' ' */
                _.Display($" ");

                /*" -9238- DISPLAY 'PROPOSTA CADASTRADA ESTRUTURA MULT ==>  ' NUM-CERTIFICADO OF DCLPROPOSTAS-VA */
                _.Display($"PROPOSTA CADASTRADA ESTRUTURA MULT ==>  {PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO}");

                /*" -9239- ELSE */
            }
            else
            {


                /*" -9239- MOVE 'NAO' TO WEXISTE-PRPVA. */
                _.Move("NAO", WEXISTE_PRPVA);
            }


        }

        [StopWatch]
        /*" R5632-00-SELECT-PROPOSTAVA-DB-SELECT-1 */
        public void R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1()
        {
            /*" -9230- EXEC SQL SELECT SIT_REGISTRO INTO :DCLPROPOSTAS-VA.SIT-REGISTRO FROM SEGUROS.PROPOSTAS_VA WHERE NUM_CERTIFICADO = :DCLPROPOSTAS-VA.NUM-CERTIFICADO END-EXEC. */

            var r5632_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1 = new R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1()
            {
                NUM_CERTIFICADO = PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1.Execute(r5632_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SIT_REGISTRO, PROPVA.DCLPROPOSTAS_VA.SIT_REGISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5632_99_SAIDA*/

        [StopWatch]
        /*" R5633-00-UPDATE-PRP-FIDELIZ-SECTION */
        private void R5633_00_UPDATE_PRP_FIDELIZ_SECTION()
        {
            /*" -9249- MOVE 'R5633-00-UPDATE-PRP-FIDELIZ   ' TO PARAGRAFO. */
            _.Move("R5633-00-UPDATE-PRP-FIDELIZ   ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9250- MOVE 'UPDATE PRP-FIDELIZ            ' TO COMANDO. */
            _.Move("UPDATE PRP-FIDELIZ            ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -9252- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9253- IF SIT-REGISTRO OF DCLPROPOSTAS-VA EQUAL '0' */

            if (PROPVA.DCLPROPOSTAS_VA.SIT_REGISTRO == "0")
            {

                /*" -9254- MOVE 'PAI' TO WHOST-SIT-PROPOSTA */
                _.Move("PAI", WHOST_SIT_PROPOSTA);

                /*" -9255- MOVE ' ' TO WHOST-SIT-ENVIO */
                _.Move(" ", WHOST_SIT_ENVIO);

                /*" -9256- ELSE */
            }
            else
            {


                /*" -9257- MOVE 'S' TO WHOST-SIT-ENVIO */
                _.Move("S", WHOST_SIT_ENVIO);

                /*" -9258- IF NOT RCAP-CADASTRADO */

                if (!WORK_AREA.W_RCAPS["RCAP_CADASTRADO"])
                {

                    /*" -9259- MOVE 'POB' TO WHOST-SIT-PROPOSTA */
                    _.Move("POB", WHOST_SIT_PROPOSTA);

                    /*" -9260- ELSE */
                }
                else
                {


                    /*" -9261- IF SIT-REGISTRO OF DCLPROPOSTAS-VA EQUAL '1' */

                    if (PROPVA.DCLPROPOSTAS_VA.SIT_REGISTRO == "1")
                    {

                        /*" -9262- MOVE 'PEN' TO WHOST-SIT-PROPOSTA */
                        _.Move("PEN", WHOST_SIT_PROPOSTA);

                        /*" -9263- ELSE */
                    }
                    else
                    {


                        /*" -9264- IF SIT-REGISTRO OF DCLPROPOSTAS-VA EQUAL '3' */

                        if (PROPVA.DCLPROPOSTAS_VA.SIT_REGISTRO == "3")
                        {

                            /*" -9265- MOVE 'EMT' TO WHOST-SIT-PROPOSTA */
                            _.Move("EMT", WHOST_SIT_PROPOSTA);

                            /*" -9266- ELSE */
                        }
                        else
                        {


                            /*" -9267- IF SIT-REGISTRO OF DCLPROPOSTAS-VA EQUAL '5' */

                            if (PROPVA.DCLPROPOSTAS_VA.SIT_REGISTRO == "5")
                            {

                                /*" -9268- MOVE 'POB' TO WHOST-SIT-PROPOSTA */
                                _.Move("POB", WHOST_SIT_PROPOSTA);

                                /*" -9269- ELSE */
                            }
                            else
                            {


                                /*" -9271- MOVE 'EMT' TO WHOST-SIT-PROPOSTA. */
                                _.Move("EMT", WHOST_SIT_PROPOSTA);
                            }

                        }

                    }

                }

            }


            /*" -9272- MOVE 88 TO SII */
            _.Move(88, WS_HORAS.SII);

            /*" -9273- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -9279- PERFORM R5633_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1 */

            R5633_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1();

            /*" -9282- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -9283- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -9285- DISPLAY 'PROBLEMAS NO UPDATE DA PROPFID  - R5633  ' SQLCODE */
                _.Display($"PROBLEMAS NO UPDATE DA PROPFID  - R5633  {DB.SQLCODE}");

                /*" -9285- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R5633-00-UPDATE-PRP-FIDELIZ-DB-UPDATE-1 */
        public void R5633_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1()
        {
            /*" -9279- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET SIT_PROPOSTA = :WHOST-SIT-PROPOSTA, SITUACAO_ENVIO = :WHOST-SIT-ENVIO WHERE NUM_PROPOSTA_SIVPF = :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF END-EXEC. */

            var r5633_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1 = new R5633_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1()
            {
                WHOST_SIT_PROPOSTA = WHOST_SIT_PROPOSTA.ToString(),
                WHOST_SIT_ENVIO = WHOST_SIT_ENVIO.ToString(),
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            R5633_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1.Execute(r5633_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5633_99_SAIDA*/

        [StopWatch]
        /*" R5634-00-SELECT-SEGUROS-PF-CBO-SECTION */
        private void R5634_00_SELECT_SEGUROS_PF_CBO_SECTION()
        {
            /*" -9295- MOVE 'R5634-00-SELECT-SEGUROS-PF-CBO ' TO PARAGRAFO. */
            _.Move("R5634-00-SELECT-SEGUROS-PF-CBO ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9296- MOVE 'SELECT SEGUROS.PF_CBO          ' TO COMANDO. */
            _.Move("SELECT SEGUROS.PF_CBO          ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -9298- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9301- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO PF062-NUM-PROPOSTA-SIVPF */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, PF062.DCLPF_CBO.PF062_NUM_PROPOSTA_SIVPF);

            /*" -9302- MOVE 89 TO SII */
            _.Move(89, WS_HORAS.SII);

            /*" -9303- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -9308- PERFORM R5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1 */

            R5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1();

            /*" -9311- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -9312- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -9313- MOVE PF062-DES-CBO TO WHOST-PROFISSAO */
                _.Move(PF062.DCLPF_CBO.PF062_DES_CBO, WHOST_PROFISSAO);

                /*" -9314- ELSE */
            }
            else
            {


                /*" -9315- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -9316- MOVE SPACES TO WHOST-PROFISSAO */
                    _.Move("", WHOST_PROFISSAO);

                    /*" -9317- ELSE */
                }
                else
                {


                    /*" -9318- DISPLAY 'PROBLEMAS NO ACESSO A PF-CBO ' */
                    _.Display($"PROBLEMAS NO ACESSO A PF-CBO ");

                    /*" -9318- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R5634-00-SELECT-SEGUROS-PF-CBO-DB-SELECT-1 */
        public void R5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1()
        {
            /*" -9308- EXEC SQL SELECT DES_CBO INTO :PF062-DES-CBO FROM SEGUROS.PF_CBO WHERE NUM_PROPOSTA_SIVPF = :PF062-NUM-PROPOSTA-SIVPF END-EXEC. */

            var r5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1_Query1 = new R5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1_Query1()
            {
                PF062_NUM_PROPOSTA_SIVPF = PF062.DCLPF_CBO.PF062_NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1_Query1.Execute(r5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PF062_DES_CBO, PF062.DCLPF_CBO.PF062_DES_CBO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5634_99_SAIDA*/

        [StopWatch]
        /*" R5635-00-UPDATE-PROPOSTAVA-SECTION */
        private void R5635_00_UPDATE_PROPOSTAVA_SECTION()
        {
            /*" -9328- MOVE '5635-00-UPDATE-PROPOSTAVA    ' TO PARAGRAFO. */
            _.Move("5635-00-UPDATE-PROPOSTAVA    ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9334- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9337- MOVE PROPOFID-DTQITBCO OF DCLPROPOSTA-FIDELIZ TO DATA-SQL1. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO, WORK_AREA.DATA_SQL1);

            /*" -9340- COMPUTE MES-SQL = MES-SQL + PRODUVG-PERI-PAGAMENTO OF DCLPRODUTOS-VG. */
            WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL + PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO;

            /*" -9341- IF MES-SQL GREATER 12 */

            if (WORK_AREA.DATA_SQL.MES_SQL > 12)
            {

                /*" -9344- COMPUTE MES-SQL = MES-SQL - 12 */
                WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL - 12;

                /*" -9347- COMPUTE ANO-SQL = ANO-SQL + 1. */
                WORK_AREA.DATA_SQL.ANO_SQL.Value = WORK_AREA.DATA_SQL.ANO_SQL + 1;
            }


            /*" -9349- MOVE DATA-SQL1 TO WHOST-DTPROXVEN. */
            _.Move(WORK_AREA.DATA_SQL1, WHOST_DTPROXVEN);

            /*" -9350- IF PROPOFID-DIA-DEBITO OF DCLPROPOSTA-FIDELIZ GREATER ZEROS */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIA_DEBITO > 00)
            {

                /*" -9353- MOVE PROPOFID-DIA-DEBITO OF DCLPROPOSTA-FIDELIZ TO DIA-SQL. */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIA_DEBITO, WORK_AREA.DATA_SQL.DIA_SQL);
            }


            /*" -9354- IF DIA-SQL GREATER 28 */

            if (WORK_AREA.DATA_SQL.DIA_SQL > 28)
            {

                /*" -9356- MOVE 28 TO DIA-SQL. */
                _.Move(28, WORK_AREA.DATA_SQL.DIA_SQL);
            }


            /*" -9357- IF DATA-SQL LESS WHOST-DTPROXVEN */

            if (WORK_AREA.DATA_SQL < WHOST_DTPROXVEN)
            {

                /*" -9358- ADD 1 TO MES-SQL */
                WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL + 1;

                /*" -9359- IF MES-SQL GREATER 12 */

                if (WORK_AREA.DATA_SQL.MES_SQL > 12)
                {

                    /*" -9360- MOVE 1 TO MES-SQL */
                    _.Move(1, WORK_AREA.DATA_SQL.MES_SQL);

                    /*" -9362- ADD 1 TO ANO-SQL. */
                    WORK_AREA.DATA_SQL.ANO_SQL.Value = WORK_AREA.DATA_SQL.ANO_SQL + 1;
                }

            }


            /*" -9364- MOVE DATA-SQL1 TO WHOST-DTPROXVEN. */
            _.Move(WORK_AREA.DATA_SQL1, WHOST_DTPROXVEN);

            /*" -9365- MOVE -1 TO VIND-DATA-DECLINIO */
            _.Move(-1, VIND_DATA_DECLINIO);

            /*" -9374- IF WS-TEM-ERRO-1855 EQUAL 'SIM' OR WS-TEM-ERRO-1807 EQUAL 'SIM' OR WS-TEM-ERRO-1852 EQUAL 'SIM' OR WS-TEM-ERRO-1877 EQUAL 'SIM' OR WS-TEM-ERRO-1878 EQUAL 'SIM' OR PROPOFID-NSAS-SIVPF OF DCLPROPOSTA-FIDELIZ EQUAL 01 OR PROPOFID-SIT-PROPOSTA OF DCLPROPOSTA-FIDELIZ EQUAL 'DEC' */

            if (WORK_AREA.WS_TEM_ERRO_1855 == "SIM" || WORK_AREA.WS_TEM_ERRO_1807 == "SIM" || WORK_AREA.WS_TEM_ERRO_1852 == "SIM" || WORK_AREA.WS_TEM_ERRO_1877 == "SIM" || WORK_AREA.WS_TEM_ERRO_1878 == "SIM" || PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAS_SIVPF == 01 || PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA == "DEC")
            {

                /*" -9375- MOVE '2' TO WHOST-SIT-REGISTRO */
                _.Move("2", WHOST_SIT_REGISTRO);

                /*" -9376- MOVE ZEROS TO VIND-DATA-DECLINIO */
                _.Move(0, VIND_DATA_DECLINIO);

                /*" -9377- ELSE */
            }
            else
            {


                /*" -9383- IF WS-TEM-ERRO-1829 EQUAL 'SIM' OR WS-TEM-ERRO-DAD-CAD EQUAL 'SIM' OR WS-TEM-ERRO-1893 EQUAL 'SIM' OR WS-TEM-ERRO-1894 EQUAL 'SIM' OR WS-TEM-ERRO-1896 EQUAL 'SIM' OR WS-TEM-ERRO-1897 EQUAL 'SIM' */

                if (WORK_AREA.WS_TEM_ERRO_1829 == "SIM" || WORK_AREA.WS_TEM_ERRO_DAD_CAD == "SIM" || WORK_AREA.WS_TEM_ERRO_1893 == "SIM" || WORK_AREA.WS_TEM_ERRO_1894 == "SIM" || WORK_AREA.WS_TEM_ERRO_1896 == "SIM" || WORK_AREA.WS_TEM_ERRO_1897 == "SIM")
                {

                    /*" -9384- MOVE '1' TO WHOST-SIT-REGISTRO */
                    _.Move("1", WHOST_SIT_REGISTRO);

                    /*" -9385- ELSE */
                }
                else
                {


                    /*" -9404- MOVE 'E' TO WHOST-SIT-REGISTRO */
                    _.Move("E", WHOST_SIT_REGISTRO);

                    /*" -9405- END-IF */
                }


                /*" -9407- END-IF. */
            }


            /*" -9408- IF VIND-PROFISSAO-CONJUGE EQUAL ZEROS */

            if (VIND_PROFISSAO_CONJUGE == 00)
            {

                /*" -9412- IF PROPOFID-PROFISSAO-CONJUGE OF DCLPROPOSTA-FIDELIZ > ZEROS AND PROPOFID-PROFISSAO-CONJUGE OF DCLPROPOSTA-FIDELIZ < 1000 */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PROFISSAO_CONJUGE > 00 && PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PROFISSAO_CONJUGE < 1000)
                {

                    /*" -9415- MOVE TAB-DESCR-CBO-C (PROPOFID-PROFISSAO-CONJUGE OF DCLPROPOSTA-FIDELIZ) TO WHOST-PROFISSAO-CONJUGE */
                    _.Move(TAB_CBO1.TAB_CBO.FILLER_34[PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PROFISSAO_CONJUGE].TAB_DESCR_CBO_C, WHOST_PROFISSAO_CONJUGE);

                    /*" -9416- ELSE */
                }
                else
                {


                    /*" -9417- MOVE SPACES TO WHOST-PROFISSAO-CONJUGE */
                    _.Move("", WHOST_PROFISSAO_CONJUGE);

                    /*" -9418- END-IF */
                }


                /*" -9420- END-IF. */
            }


            /*" -9422- IF PROPOFID-AGECOBR OF DCLPROPOSTA-FIDELIZ > 0 AND PROPOFID-AGECOBR OF DCLPROPOSTA-FIDELIZ < 10000 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR > 0 && PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR < 10000)
            {

                /*" -9424- MOVE TAB-FONTE (PROPOFID-AGECOBR OF DCLPROPOSTA-FIDELIZ) TO WHOST-FONTE */
                _.Move(TAB_FILIAIS.TAB_FILIAL.FILLER_33[PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR].TAB_FONTE, WHOST_FONTE);

                /*" -9425- ELSE */
            }
            else
            {


                /*" -9428- DISPLAY 'AGENCIA INVALIDA ----> ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ ' ' PROPOFID-AGECOBR OF DCLPROPOSTA-FIDELIZ */

                $"AGENCIA INVALIDA ----> {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF} {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR}"
                .Display();

                /*" -9429- MOVE ZEROS TO WHOST-FONTE */
                _.Move(0, WHOST_FONTE);

                /*" -9431- END-IF. */
            }


            /*" -9433- IF (WHOST-FONTE = ZEROS OR 10) OR (WHOST-FONTE > 99) */

            if ((WHOST_FONTE.In("00", "10")) || (WHOST_FONTE > 99))
            {

                /*" -9436- MOVE 5 TO WHOST-FONTE. */
                _.Move(5, WHOST_FONTE);
            }


            /*" -9438- MOVE 'UPDATE PROPOSTAVA            ' TO COMANDO. */
            _.Move("UPDATE PROPOSTAVA            ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -9439- MOVE 90 TO SII */
            _.Move(90, WS_HORAS.SII);

            /*" -9440- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -9490- PERFORM R5635_00_UPDATE_PROPOSTAVA_DB_UPDATE_1 */

            R5635_00_UPDATE_PROPOSTAVA_DB_UPDATE_1();

            /*" -9493- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -9494- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -9495- DISPLAY 'PROBLEMAS NO UPDATE PROPOSTAVA ' */
                _.Display($"PROBLEMAS NO UPDATE PROPOSTAVA ");

                /*" -9497- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -9497- ADD 1 TO AC-I-PROPOSTAVA. */
            WORK_AREA.AC_I_PROPOSTAVA.Value = WORK_AREA.AC_I_PROPOSTAVA + 1;

        }

        [StopWatch]
        /*" R5635-00-UPDATE-PROPOSTAVA-DB-UPDATE-1 */
        public void R5635_00_UPDATE_PROPOSTAVA_DB_UPDATE_1()
        {
            /*" -9490- EXEC SQL UPDATE SEGUROS.PROPOSTAS_VA SET COD_CLIENTE = :DCLCLIENTES.COD-CLIENTE , OCOREND = :DCLENDERECOS.ENDERECO-OCORR-ENDERECO, COD_FONTE = :WHOST-FONTE , PROFISSAO = :WHOST-PROFISSAO , SIT_REGISTRO = :WHOST-SIT-REGISTRO , DTPROXVEN = :WHOST-DTPROXVEN , IDADE = :WHOST-IDADE , NOME_ESPOSA = :DCLPROPOSTA-FIDELIZ.PROPOFID-NOME-CONJUGE :VIND-NOME-CONJUGE , DTNASC_ESPOSA = :DCLPROPOSTA-FIDELIZ.PROPOFID-DATA-NASC-CONJUGE :VIND-DATA-NASC-CONJUGE , PROFIS_ESPOSA = :WHOST-PROFISSAO-CONJUGE :VIND-PROFISSAO-CONJUGE , INFO_COMPLEMENTAR = :WHOST-INFO-COMPL , COD_CCT = :DCLPROPOSTA-FIDELIZ.PROPOFID-CGC-CONVENENTE :VIND-CGC-CONVENENTE , NUM_CONTR_VINCULO = :PROPSSVD-NUM-CONTR-VINCULO :VIND-NUM-CONTR , COD_CORRESP_BANC = :PROPSSVD-COD-CORRESP-BANC :VIND-COD-CORRESP , COD_ORIGEM_PROPOSTA = :PROPOFID-ORIGEM-PROPOSTA , NUM_PRAZO_FIN = :PROPSSVD-NUM-PRAZO-FIN :VIND-NUM-PRAZO , COD_OPER_CREDITO = :PROPSSVD-COD-OPER-CREDITO :VIND-COD-OPER-CRED , DTA_DECLINIO = :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO :VIND-DATA-DECLINIO WHERE NUM_CERTIFICADO = :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF END-EXEC. */

            var r5635_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1 = new R5635_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1()
            {
                PROPOFID_DATA_NASC_CONJUGE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_NASC_CONJUGE.ToString(),
                VIND_DATA_NASC_CONJUGE = VIND_DATA_NASC_CONJUGE.ToString(),
                PROPOFID_CGC_CONVENENTE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CGC_CONVENENTE.ToString(),
                VIND_CGC_CONVENENTE = VIND_CGC_CONVENENTE.ToString(),
                PROPOFID_NOME_CONJUGE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NOME_CONJUGE.ToString(),
                VIND_NOME_CONJUGE = VIND_NOME_CONJUGE.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                VIND_DATA_DECLINIO = VIND_DATA_DECLINIO.ToString(),
                WHOST_PROFISSAO_CONJUGE = WHOST_PROFISSAO_CONJUGE.ToString(),
                VIND_PROFISSAO_CONJUGE = VIND_PROFISSAO_CONJUGE.ToString(),
                PROPSSVD_COD_OPER_CREDITO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_OPER_CREDITO.ToString(),
                VIND_COD_OPER_CRED = VIND_COD_OPER_CRED.ToString(),
                PROPSSVD_COD_CORRESP_BANC = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_CORRESP_BANC.ToString(),
                VIND_COD_CORRESP = VIND_COD_CORRESP.ToString(),
                PROPSSVD_NUM_CONTR_VINCULO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_CONTR_VINCULO.ToString(),
                VIND_NUM_CONTR = VIND_NUM_CONTR.ToString(),
                PROPSSVD_NUM_PRAZO_FIN = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_PRAZO_FIN.ToString(),
                VIND_NUM_PRAZO = VIND_NUM_PRAZO.ToString(),
                ENDERECO_OCORR_ENDERECO = ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO.ToString(),
                PROPOFID_ORIGEM_PROPOSTA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA.ToString(),
                COD_CLIENTE = CLIENTE.DCLCLIENTES.COD_CLIENTE.ToString(),
                WHOST_SIT_REGISTRO = WHOST_SIT_REGISTRO.ToString(),
                WHOST_INFO_COMPL = WHOST_INFO_COMPL.ToString(),
                WHOST_PROFISSAO = WHOST_PROFISSAO.ToString(),
                WHOST_DTPROXVEN = WHOST_DTPROXVEN.ToString(),
                WHOST_FONTE = WHOST_FONTE.ToString(),
                WHOST_IDADE = WHOST_IDADE.ToString(),
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            R5635_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1.Execute(r5635_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5635_99_SAIDA*/

        [StopWatch]
        /*" R5650-00-INSERE-RELATORIOS-SECTION */
        private void R5650_00_INSERE_RELATORIOS_SECTION()
        {
            /*" -9507- MOVE 'R5650-00-INSERE-RELATORIOS   ' TO PARAGRAFO */
            _.Move("R5650-00-INSERE-RELATORIOS   ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9508- MOVE 'INSERT RELATORIOS            ' TO COMANDO */
            _.Move("INSERT RELATORIOS            ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -9511- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9597- PERFORM R5650_00_INSERE_RELATORIOS_DB_INSERT_1 */

            R5650_00_INSERE_RELATORIOS_DB_INSERT_1();

            /*" -9600- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -9601- DISPLAY 'R5650 - PROBLEMAS NO INSERT RELATORIOS' */
                _.Display($"R5650 - PROBLEMAS NO INSERT RELATORIOS");

                /*" -9602- DISPLAY ' SQLCODE     - ' SQLCODE */
                _.Display($" SQLCODE     - {DB.SQLCODE}");

                /*" -9604- DISPLAY ' NUM-CERTIFICADO - ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($" NUM-CERTIFICADO - {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -9606- DISPLAY ' NUM-APOLICE - ' PROPSSVD-NUM-APOLICE OF DCLPROP-SASSE-VIDA */
                _.Display($" NUM-APOLICE - {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE}");

                /*" -9608- DISPLAY ' COD-SUBGRUPO - ' PROPSSVD-COD-SUBGRUPO OF DCLPROP-SASSE-VIDA */
                _.Display($" COD-SUBGRUPO - {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO}");

                /*" -9609- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -9611- END-IF */
            }


            /*" -9611- . */

        }

        [StopWatch]
        /*" R5650-00-INSERE-RELATORIOS-DB-INSERT-1 */
        public void R5650_00_INSERE_RELATORIOS_DB_INSERT_1()
        {
            /*" -9597- EXEC SQL INSERT INTO SEGUROS.RELATORIOS ( COD_USUARIO , DATA_SOLICITACAO , IDE_SISTEMA , COD_RELATORIO , NUM_COPIAS , QUANTIDADE , PERI_INICIAL , PERI_FINAL , DATA_REFERENCIA , MES_REFERENCIA , ANO_REFERENCIA , ORGAO_EMISSOR , COD_FONTE , COD_PRODUTOR , RAMO_EMISSOR , COD_MODALIDADE , COD_CONGENERE , NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , NUM_CERTIFICADO , NUM_TITULO , COD_SUBGRUPO , COD_OPERACAO , COD_PLANO , OCORR_HISTORICO , NUM_APOL_LIDER , ENDOS_LIDER , NUM_PARC_LIDER , NUM_SINISTRO , NUM_SINI_LIDER , NUM_ORDEM , COD_MOEDA , TIPO_CORRECAO , SIT_REGISTRO , IND_PREV_DEFINIT , IND_ANAL_RESUMO , COD_EMPRESA , PERI_RENOVACAO , PCT_AUMENTO ,TIMESTAMP ) VALUES ( 'VA0601B' , :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO, 'VA' , 'CARENCIA' , 0, 0, :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO, :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO, :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO, 0, 0, 0, 0, 0, 0, 0, 0, :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE, 0, 0, :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF, 0, :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO, 0, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '1' , ' ' , ' ' , NULL, 0, 0, CURRENT TIMESTAMP) END-EXEC */

            var r5650_00_INSERE_RELATORIOS_DB_INSERT_1_Insert1 = new R5650_00_INSERE_RELATORIOS_DB_INSERT_1_Insert1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                PROPSSVD_NUM_APOLICE = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.ToString(),
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                PROPSSVD_COD_SUBGRUPO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.ToString(),
            };

            R5650_00_INSERE_RELATORIOS_DB_INSERT_1_Insert1.Execute(r5650_00_INSERE_RELATORIOS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5650_99_SAIDA*/

        [StopWatch]
        /*" R6000-00-DECLARE-AGENCEF-SECTION */
        private void R6000_00_DECLARE_AGENCEF_SECTION()
        {
            /*" -9621- MOVE 'R6000-DECLA-AGENCEF   ' TO PARAGRAFO. */
            _.Move("R6000-DECLA-AGENCEF   ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9623- MOVE 'DECLARE AGENCIACEF    ' TO COMANDO. */
            _.Move("DECLARE AGENCIACEF    ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -9631- PERFORM R6000_00_DECLARE_AGENCEF_DB_DECLARE_1 */

            R6000_00_DECLARE_AGENCEF_DB_DECLARE_1();

            /*" -9634- MOVE 91 TO SII */
            _.Move(91, WS_HORAS.SII);

            /*" -9635- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -9635- PERFORM R6000_00_DECLARE_AGENCEF_DB_OPEN_1 */

            R6000_00_DECLARE_AGENCEF_DB_OPEN_1();

            /*" -9638- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -9639- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -9640- DISPLAY 'R6000 - PROBLEMAS DECLARE (AGENCEF) ..' */
                _.Display($"R6000 - PROBLEMAS DECLARE (AGENCEF) ..");

                /*" -9641- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -9641- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R6000-00-DECLARE-AGENCEF-DB-OPEN-1 */
        public void R6000_00_DECLARE_AGENCEF_DB_OPEN_1()
        {
            /*" -9635- EXEC SQL OPEN C01_AGENCEF END-EXEC. */

            C01_AGENCEF.Open();

        }

        [StopWatch]
        /*" R6100-00-DECLARE-CBO-DB-DECLARE-1 */
        public void R6100_00_DECLARE_CBO_DB_DECLARE_1()
        {
            /*" -9703- EXEC SQL DECLARE CCBO CURSOR FOR SELECT COD_CBO, DESCR_CBO FROM SEGUROS.CBO ORDER BY COD_CBO END-EXEC. */
            CCBO = new VA0601B_CCBO(false);
            string GetQuery_CCBO()
            {
                var query = @$"SELECT COD_CBO
							, 
							DESCR_CBO 
							FROM SEGUROS.CBO 
							ORDER BY COD_CBO";

                return query;
            }
            CCBO.GetQueryEvent += GetQuery_CCBO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6000_99_SAIDA*/

        [StopWatch]
        /*" R6010-00-FETCH-AGENCEF-SECTION */
        private void R6010_00_FETCH_AGENCEF_SECTION()
        {
            /*" -9651- MOVE 'R6010-FETCH-AGENCEF   ' TO PARAGRAFO. */
            _.Move("R6010-FETCH-AGENCEF   ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9653- MOVE 'FETCH   AGENCIACEF    ' TO COMANDO. */
            _.Move("FETCH   AGENCIACEF    ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -9654- MOVE 92 TO SII */
            _.Move(92, WS_HORAS.SII);

            /*" -9655- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -9658- PERFORM R6010_00_FETCH_AGENCEF_DB_FETCH_1 */

            R6010_00_FETCH_AGENCEF_DB_FETCH_1();

            /*" -9661- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -9662- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -9663- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -9664- MOVE 'S' TO WFIM-AGENCEF */
                    _.Move("S", WORK_AREA.WFIM_AGENCEF);

                    /*" -9664- PERFORM R6010_00_FETCH_AGENCEF_DB_CLOSE_1 */

                    R6010_00_FETCH_AGENCEF_DB_CLOSE_1();

                    /*" -9666- ELSE */
                }
                else
                {


                    /*" -9666- PERFORM R6010_00_FETCH_AGENCEF_DB_CLOSE_2 */

                    R6010_00_FETCH_AGENCEF_DB_CLOSE_2();

                    /*" -9668- DISPLAY '3100 - (PROBLEMAS NO FETCH AGENCEF) ..' */
                    _.Display($"3100 - (PROBLEMAS NO FETCH AGENCEF) ..");

                    /*" -9669- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -9669- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R6010-00-FETCH-AGENCEF-DB-FETCH-1 */
        public void R6010_00_FETCH_AGENCEF_DB_FETCH_1()
        {
            /*" -9658- EXEC SQL FETCH C01_AGENCEF INTO :DCLAGENCIAS-CEF.COD-AGENCIA, :DCLMALHA-CEF.MALHACEF-COD-FONTE END-EXEC. */

            if (C01_AGENCEF.Fetch())
            {
                _.Move(C01_AGENCEF.DCLAGENCIAS_CEF_COD_AGENCIA, AGENCEF.DCLAGENCIAS_CEF.COD_AGENCIA);
                _.Move(C01_AGENCEF.DCLMALHA_CEF_MALHACEF_COD_FONTE, MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE);
            }

        }

        [StopWatch]
        /*" R6010-00-FETCH-AGENCEF-DB-CLOSE-1 */
        public void R6010_00_FETCH_AGENCEF_DB_CLOSE_1()
        {
            /*" -9664- EXEC SQL CLOSE C01_AGENCEF END-EXEC */

            C01_AGENCEF.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6010_99_SAIDA*/

        [StopWatch]
        /*" R6010-00-FETCH-AGENCEF-DB-CLOSE-2 */
        public void R6010_00_FETCH_AGENCEF_DB_CLOSE_2()
        {
            /*" -9666- EXEC SQL CLOSE C01_AGENCEF END-EXEC */

            C01_AGENCEF.Close();

        }

        [StopWatch]
        /*" R6020-00-CARREGA-FILIAL-SECTION */
        private void R6020_00_CARREGA_FILIAL_SECTION()
        {
            /*" -9680- MOVE 'R6020-00-CARREGA-FILIAL ' TO PARAGRAFO. */
            _.Move("R6020-00-CARREGA-FILIAL ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9682- IF COD-AGENCIA OF DCLAGENCIAS-CEF > 0 AND COD-AGENCIA OF DCLAGENCIAS-CEF < 10000 */

            if (AGENCEF.DCLAGENCIAS_CEF.COD_AGENCIA > 0 && AGENCEF.DCLAGENCIAS_CEF.COD_AGENCIA < 10000)
            {

                /*" -9684- MOVE MALHACEF-COD-FONTE OF DCLMALHA-CEF TO TAB-FONTE (COD-AGENCIA OF DCLAGENCIAS-CEF) */
                _.Move(MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE, TAB_FILIAIS.TAB_FILIAL.FILLER_33[AGENCEF.DCLAGENCIAS_CEF.COD_AGENCIA].TAB_FONTE);

                /*" -9686- END-IF. */
            }


            /*" -9686- PERFORM R6010-00-FETCH-AGENCEF. */

            R6010_00_FETCH_AGENCEF_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6020_99_SAIDA*/

        [StopWatch]
        /*" R6100-00-DECLARE-CBO-SECTION */
        private void R6100_00_DECLARE_CBO_SECTION()
        {
            /*" -9696- MOVE 'R6100-00-DECLARE-CBO    ' TO PARAGRAFO. */
            _.Move("R6100-00-DECLARE-CBO    ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9698- MOVE 'DECLARE CBO             ' TO COMANDO. */
            _.Move("DECLARE CBO             ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -9703- PERFORM R6100_00_DECLARE_CBO_DB_DECLARE_1 */

            R6100_00_DECLARE_CBO_DB_DECLARE_1();

            /*" -9706- MOVE 93 TO SII */
            _.Move(93, WS_HORAS.SII);

            /*" -9707- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -9707- PERFORM R6100_00_DECLARE_CBO_DB_OPEN_1 */

            R6100_00_DECLARE_CBO_DB_OPEN_1();

            /*" -9710- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -9711- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -9712- DISPLAY 'R6100 - PROBLEMAS DECLARE (CBO      ) ..' */
                _.Display($"R6100 - PROBLEMAS DECLARE (CBO      ) ..");

                /*" -9713- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -9713- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R6100-00-DECLARE-CBO-DB-OPEN-1 */
        public void R6100_00_DECLARE_CBO_DB_OPEN_1()
        {
            /*" -9707- EXEC SQL OPEN CCBO END-EXEC. */

            CCBO.Open();

        }

        [StopWatch]
        /*" R7900-00-DECLARE-VGRAMOCOMP-DB-DECLARE-1 */
        public void R7900_00_DECLARE_VGRAMOCOMP_DB_DECLARE_1()
        {
            /*" -9823- EXEC SQL DECLARE CVGRAMOCOMP CURSOR FOR SELECT DISTINCT B.NUM_APOLICE , B.COD_SUBGRUPO , B.COD_GRUPO_SUSEP , B.RAMO_EMISSOR , B.COD_MODALIDADE , B.DTH_INI_VIGENCIA , B.COD_OPCAO_COBERTURA , B.NUM_IDADE_INICIAL , B.NUM_IDADE_FINAL , B.VLR_PERC_PREMIO , B.COD_USUARIO , B.DTH_ATUALIZACAO FROM SEGUROS.VG_PARAM_RAMO_CONJ A, SEGUROS.VG_PARAM_RAMO_COMP B WHERE A.NUM_APOLICE = :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE AND A.COD_SUBGRUPO = :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO AND A.DTH_INI_VIGENCIA <= :DCLPROPOSTA-FIDELIZ.PROPOFID-DATA-PROPOSTA AND A.DTH_TER_VIGENCIA >= :DCLPROPOSTA-FIDELIZ.PROPOFID-DATA-PROPOSTA AND B.NUM_APOLICE = A.NUM_APOLICE AND B.COD_SUBGRUPO = A.COD_SUBGRUPO AND B.DTH_INI_VIGENCIA = A.DTH_INI_VIGENCIA AND B.RAMO_EMISSOR = A.RAMO_EMISSOR AND B.NUM_IDADE_INICIAL <= :WHOST-IDADE AND B.NUM_IDADE_FINAL >= :WHOST-IDADE AND B.COD_OPCAO_COBERTURA = :WHOST-OPCAO-COBER ORDER BY 1,2,3,4,5,6,7,8,9,10,11,12 END-EXEC */
            CVGRAMOCOMP = new VA0601B_CVGRAMOCOMP(true);
            string GetQuery_CVGRAMOCOMP()
            {
                var query = @$"SELECT DISTINCT 
							B.NUM_APOLICE
							, 
							B.COD_SUBGRUPO
							, 
							B.COD_GRUPO_SUSEP
							, 
							B.RAMO_EMISSOR
							, 
							B.COD_MODALIDADE
							, 
							B.DTH_INI_VIGENCIA
							, 
							B.COD_OPCAO_COBERTURA
							, 
							B.NUM_IDADE_INICIAL
							, 
							B.NUM_IDADE_FINAL
							, 
							B.VLR_PERC_PREMIO
							, 
							B.COD_USUARIO
							, 
							B.DTH_ATUALIZACAO 
							FROM SEGUROS.VG_PARAM_RAMO_CONJ A
							, 
							SEGUROS.VG_PARAM_RAMO_COMP B 
							WHERE A.NUM_APOLICE = 
							'{PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE}' 
							AND A.COD_SUBGRUPO = 
							'{PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO}' 
							AND A.DTH_INI_VIGENCIA <= 
							'{PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA}' 
							AND A.DTH_TER_VIGENCIA >= 
							'{PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA}' 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.COD_SUBGRUPO = A.COD_SUBGRUPO 
							AND B.DTH_INI_VIGENCIA = A.DTH_INI_VIGENCIA 
							AND B.RAMO_EMISSOR = A.RAMO_EMISSOR 
							AND B.NUM_IDADE_INICIAL <= 
							'{WHOST_IDADE}' 
							AND B.NUM_IDADE_FINAL >= 
							'{WHOST_IDADE}' 
							AND B.COD_OPCAO_COBERTURA = 
							'{WHOST_OPCAO_COBER}' 
							ORDER BY 1
							,2
							,3
							,4
							,5
							,6
							,7
							,8
							,9
							,10
							,11
							,12";

                return query;
            }
            CVGRAMOCOMP.GetQueryEvent += GetQuery_CVGRAMOCOMP;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6100_99_SAIDA*/

        [StopWatch]
        /*" R6110-00-FETCH-CBO-SECTION */
        private void R6110_00_FETCH_CBO_SECTION()
        {
            /*" -9723- MOVE 'R6110-00-FETCH-CBO      ' TO PARAGRAFO. */
            _.Move("R6110-00-FETCH-CBO      ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9725- MOVE 'FETCH   CBO             ' TO COMANDO. */
            _.Move("FETCH   CBO             ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -9726- MOVE 94 TO SII */
            _.Move(94, WS_HORAS.SII);

            /*" -9727- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -9730- PERFORM R6110_00_FETCH_CBO_DB_FETCH_1 */

            R6110_00_FETCH_CBO_DB_FETCH_1();

            /*" -9733- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -9734- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -9735- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -9736- MOVE 'S' TO WFIM-CBO */
                    _.Move("S", WORK_AREA.WFIM_CBO);

                    /*" -9736- PERFORM R6110_00_FETCH_CBO_DB_CLOSE_1 */

                    R6110_00_FETCH_CBO_DB_CLOSE_1();

                    /*" -9738- ELSE */
                }
                else
                {


                    /*" -9738- PERFORM R6110_00_FETCH_CBO_DB_CLOSE_2 */

                    R6110_00_FETCH_CBO_DB_CLOSE_2();

                    /*" -9740- DISPLAY '6110 - (PROBLEMAS NO FETCH CCBO     ) ..' */
                    _.Display($"6110 - (PROBLEMAS NO FETCH CCBO     ) ..");

                    /*" -9741- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -9741- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R6110-00-FETCH-CBO-DB-FETCH-1 */
        public void R6110_00_FETCH_CBO_DB_FETCH_1()
        {
            /*" -9730- EXEC SQL FETCH CCBO INTO :DCLCBO.CBO-COD-CBO, :DCLCBO.CBO-DESCR-CBO END-EXEC. */

            if (CCBO.Fetch())
            {
                _.Move(CCBO.DCLCBO_CBO_COD_CBO, CBO.DCLCBO.CBO_COD_CBO);
                _.Move(CCBO.DCLCBO_CBO_DESCR_CBO, CBO.DCLCBO.CBO_DESCR_CBO);
            }

        }

        [StopWatch]
        /*" R6110-00-FETCH-CBO-DB-CLOSE-1 */
        public void R6110_00_FETCH_CBO_DB_CLOSE_1()
        {
            /*" -9736- EXEC SQL CLOSE CCBO END-EXEC */

            CCBO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6110_99_SAIDA*/

        [StopWatch]
        /*" R6110-00-FETCH-CBO-DB-CLOSE-2 */
        public void R6110_00_FETCH_CBO_DB_CLOSE_2()
        {
            /*" -9738- EXEC SQL CLOSE CCBO END-EXEC */

            CCBO.Close();

        }

        [StopWatch]
        /*" R6120-00-CARREGA-CBO-SECTION */
        private void R6120_00_CARREGA_CBO_SECTION()
        {
            /*" -9751- MOVE 'R6120-00-CARREGA-CBO    ' TO PARAGRAFO. */
            _.Move("R6120-00-CARREGA-CBO    ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9753- MOVE 'CARREGA CBO             ' TO COMANDO. */
            _.Move("CARREGA CBO             ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -9755- IF CBO-COD-CBO OF DCLCBO > 0 AND CBO-COD-CBO OF DCLCBO < 1000 */

            if (CBO.DCLCBO.CBO_COD_CBO > 0 && CBO.DCLCBO.CBO_COD_CBO < 1000)
            {

                /*" -9757- MOVE CBO-DESCR-CBO OF DCLCBO TO TAB-DESCR-CBO-C (CBO-COD-CBO OF DCLCBO) */
                _.Move(CBO.DCLCBO.CBO_DESCR_CBO, TAB_CBO1.TAB_CBO.FILLER_34[CBO.DCLCBO.CBO_COD_CBO].TAB_DESCR_CBO_C);

                /*" -9759- END-IF. */
            }


            /*" -9759- PERFORM R6110-00-FETCH-CBO. */

            R6110_00_FETCH_CBO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6120_99_SAIDA*/

        [StopWatch]
        /*" R7900-00-DECLARE-VGRAMOCOMP-SECTION */
        private void R7900_00_DECLARE_VGRAMOCOMP_SECTION()
        {
            /*" -9770- MOVE 'R7900-00-DECLARE-VGRAMOCOMP  ' TO PARAGRAFO. */
            _.Move("R7900-00-DECLARE-VGRAMOCOMP  ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9772- MOVE 'NAO' TO WFIM-VGRAMOCOMP */
            _.Move("NAO", WORK_AREA.WFIM_VGRAMOCOMP);

            /*" -9779- IF PROPSSVD-NUM-APOLICE = 109300000559 OR 3009300000559 OR 3009300001559 OR 109300000709 OR 109300001311 OR 109300001392 OR 109300001393 */

            if (PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.In("109300000559", "3009300000559", "3009300001559", "109300000709", "109300001311", "109300001392", "109300001393"))
            {

                /*" -9781- MOVE PROPOFID-OPCAO-COBER TO WHOST-OPCAO-COBER */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER, WHOST_OPCAO_COBER);

                /*" -9782- ELSE */
            }
            else
            {


                /*" -9784- MOVE ' ' TO WHOST-OPCAO-COBER */
                _.Move(" ", WHOST_OPCAO_COBER);

                /*" -9786- END-IF */
            }


            /*" -9787- MOVE 95 TO SII */
            _.Move(95, WS_HORAS.SII);

            /*" -9788- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -9823- PERFORM R7900_00_DECLARE_VGRAMOCOMP_DB_DECLARE_1 */

            R7900_00_DECLARE_VGRAMOCOMP_DB_DECLARE_1();

            /*" -9826- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -9826- PERFORM R7900_00_DECLARE_VGRAMOCOMP_DB_OPEN_1 */

            R7900_00_DECLARE_VGRAMOCOMP_DB_OPEN_1();

            /*" -9829- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -9830- DISPLAY '7900 - (PROBLEMAS NO DECLARE CVGRAMOCOMP) ..' */
                _.Display($"7900 - (PROBLEMAS NO DECLARE CVGRAMOCOMP) ..");

                /*" -9831- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -9831- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R7900-00-DECLARE-VGRAMOCOMP-DB-OPEN-1 */
        public void R7900_00_DECLARE_VGRAMOCOMP_DB_OPEN_1()
        {
            /*" -9826- EXEC SQL OPEN CVGRAMOCOMP END-EXEC. */

            CVGRAMOCOMP.Open();

        }

        [StopWatch]
        /*" R8350-FECHAR-MSG-ERRO-DPS-DB-DECLARE-1 */
        public void R8350_FECHAR_MSG_ERRO_DPS_DB_DECLARE_1()
        {
            /*" -10368- EXEC SQL DECLARE CSR_ERRO_DPS CURSOR FOR SELECT A.NUM_CERTIFICADO ,A.SEQ_CRITICA ,A.COD_MSG_CRITICA FROM SEGUROS.VG_CRITICA_PROPOSTA A WHERE A.NUM_CERTIFICADO = :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF AND A.COD_MSG_CRITICA IN (8,9,10,11,12) AND A.STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' ) WITH UR END-EXEC. */
            CSR_ERRO_DPS = new VA0601B_CSR_ERRO_DPS(true);
            string GetQuery_CSR_ERRO_DPS()
            {
                var query = @$"SELECT A.NUM_CERTIFICADO 
							,A.SEQ_CRITICA 
							,A.COD_MSG_CRITICA 
							FROM SEGUROS.VG_CRITICA_PROPOSTA A 
							WHERE A.NUM_CERTIFICADO = 
							'{PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}' 
							AND A.COD_MSG_CRITICA IN (8
							,9
							,10
							,11
							,12) 
							AND A.STA_CRITICA IN ( '0'
							, '1'
							, '2'
							, '4'
							, '5'
							, '8' )";

                return query;
            }
            CSR_ERRO_DPS.GetQueryEvent += GetQuery_CSR_ERRO_DPS;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7900_99_SAIDA*/

        [StopWatch]
        /*" R7910-00-FETCH-VGRAMOCOMP-SECTION */
        private void R7910_00_FETCH_VGRAMOCOMP_SECTION()
        {
            /*" -9841- MOVE 'R7910-00-FETCH-VGRAMOCOMP    ' TO PARAGRAFO. */
            _.Move("R7910-00-FETCH-VGRAMOCOMP    ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9843- MOVE 'FETCH VGRAMOCOMP             ' TO COMANDO. */
            _.Move("FETCH VGRAMOCOMP             ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -9844- MOVE 96 TO SII */
            _.Move(96, WS_HORAS.SII);

            /*" -9845- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -9859- PERFORM R7910_00_FETCH_VGRAMOCOMP_DB_FETCH_1 */

            R7910_00_FETCH_VGRAMOCOMP_DB_FETCH_1();

            /*" -9862- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -9863- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -9864- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -9865- MOVE 'SIM' TO WFIM-VGRAMOCOMP */
                    _.Move("SIM", WORK_AREA.WFIM_VGRAMOCOMP);

                    /*" -9865- PERFORM R7910_00_FETCH_VGRAMOCOMP_DB_CLOSE_1 */

                    R7910_00_FETCH_VGRAMOCOMP_DB_CLOSE_1();

                    /*" -9867- GO TO R7910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R7910_99_SAIDA*/ //GOTO
                    return;

                    /*" -9868- ELSE */
                }
                else
                {


                    /*" -9869- DISPLAY '7910 - (PROBLEMAS NO FETCH CVGRAMOCOMP) ..' */
                    _.Display($"7910 - (PROBLEMAS NO FETCH CVGRAMOCOMP) ..");

                    /*" -9870- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -9870- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R7910-00-FETCH-VGRAMOCOMP-DB-FETCH-1 */
        public void R7910_00_FETCH_VGRAMOCOMP_DB_FETCH_1()
        {
            /*" -9859- EXEC SQL FETCH CVGRAMOCOMP INTO :VG081-NUM-APOLICE , :VG081-COD-SUBGRUPO , :VG081-COD-GRUPO-SUSEP , :VG081-RAMO-EMISSOR , :VG081-COD-MODALIDADE , :VG081-DTH-INI-VIGENCIA , :VG081-COD-OPCAO-COBERTURA , :VG081-NUM-IDADE-INICIAL , :VG081-NUM-IDADE-FINAL , :VG081-VLR-PERC-PREMIO , :VG081-COD-USUARIO , :VG081-DTH-ATUALIZACAO END-EXEC */

            if (CVGRAMOCOMP.Fetch())
            {
                _.Move(CVGRAMOCOMP.VG081_NUM_APOLICE, VG081.DCLVG_PARAM_RAMO_COMP.VG081_NUM_APOLICE);
                _.Move(CVGRAMOCOMP.VG081_COD_SUBGRUPO, VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_SUBGRUPO);
                _.Move(CVGRAMOCOMP.VG081_COD_GRUPO_SUSEP, VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_GRUPO_SUSEP);
                _.Move(CVGRAMOCOMP.VG081_RAMO_EMISSOR, VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR);
                _.Move(CVGRAMOCOMP.VG081_COD_MODALIDADE, VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_MODALIDADE);
                _.Move(CVGRAMOCOMP.VG081_DTH_INI_VIGENCIA, VG081.DCLVG_PARAM_RAMO_COMP.VG081_DTH_INI_VIGENCIA);
                _.Move(CVGRAMOCOMP.VG081_COD_OPCAO_COBERTURA, VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_OPCAO_COBERTURA);
                _.Move(CVGRAMOCOMP.VG081_NUM_IDADE_INICIAL, VG081.DCLVG_PARAM_RAMO_COMP.VG081_NUM_IDADE_INICIAL);
                _.Move(CVGRAMOCOMP.VG081_NUM_IDADE_FINAL, VG081.DCLVG_PARAM_RAMO_COMP.VG081_NUM_IDADE_FINAL);
                _.Move(CVGRAMOCOMP.VG081_VLR_PERC_PREMIO, VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO);
                _.Move(CVGRAMOCOMP.VG081_COD_USUARIO, VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_USUARIO);
                _.Move(CVGRAMOCOMP.VG081_DTH_ATUALIZACAO, VG081.DCLVG_PARAM_RAMO_COMP.VG081_DTH_ATUALIZACAO);
            }

        }

        [StopWatch]
        /*" R7910-00-FETCH-VGRAMOCOMP-DB-CLOSE-1 */
        public void R7910_00_FETCH_VGRAMOCOMP_DB_CLOSE_1()
        {
            /*" -9865- EXEC SQL CLOSE CVGRAMOCOMP END-EXEC */

            CVGRAMOCOMP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7910_99_SAIDA*/

        [StopWatch]
        /*" R8000-00-PROCESSA-VGRAMOCOMP-SECTION */
        private void R8000_00_PROCESSA_VGRAMOCOMP_SECTION()
        {
            /*" -9880- MOVE '8000-00-PROCESSA-VGRAMOCOMP  ' TO PARAGRAFO. */
            _.Move("8000-00-PROCESSA-VGRAMOCOMP  ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9882- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9884- MOVE VG081-COD-GRUPO-SUSEP TO WS-GRUPO-SUSEP-ANT */
            _.Move(VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_GRUPO_SUSEP, WORK_RAMO_CONJ.WS_GRUPO_SUSEP_ANT);

            /*" -9887- MOVE VG081-RAMO-EMISSOR TO WS-RAMO-CONJ-ANT */
            _.Move(VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR, WORK_RAMO_CONJ.WS_RAMO_CONJ_ANT);

            /*" -9890- MOVE ZEROS TO WHOST-TAXA-RAMO WHOST-VLR-PERC-PREMIO */
            _.Move(0, WHOST_TAXA_RAMO, WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO);

            /*" -9897- PERFORM R8100-00-PROCESSA-REGISTRO UNTIL WFIM-VGRAMOCOMP EQUAL 'SIM' OR VG081-COD-GRUPO-SUSEP NOT EQUAL WS-GRUPO-SUSEP-ANT OR VG081-RAMO-EMISSOR NOT EQUAL WS-RAMO-CONJ-ANT. */

            while (!(WORK_AREA.WFIM_VGRAMOCOMP == "SIM" || VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_GRUPO_SUSEP != WORK_RAMO_CONJ.WS_GRUPO_SUSEP_ANT || VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR != WORK_RAMO_CONJ.WS_RAMO_CONJ_ANT))
            {

                R8100_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -9898- ADD 1 TO WS-IND */
            WORK_RAMO_CONJ.WS_IND.Value = WORK_RAMO_CONJ.WS_IND + 1;

            /*" -9900- MOVE WS-GRUPO-SUSEP-ANT TO TB-GRUPO-SUSEP (WS-IND). */
            _.Move(WORK_RAMO_CONJ.WS_GRUPO_SUSEP_ANT, WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND].TB_GRUPO_SUSEP);

            /*" -9902- MOVE WS-RAMO-CONJ-ANT TO TB-RAMO-CONJ (WS-IND). */
            _.Move(WORK_RAMO_CONJ.WS_RAMO_CONJ_ANT, WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND].TB_RAMO_CONJ);

            /*" -9903- MOVE WHOST-VLR-PERC-PREMIO TO TB-TAXA-RAMO-CONJ (WS-IND). */
            _.Move(WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO, WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND].TB_TAXA_RAMO_CONJ);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/

        [StopWatch]
        /*" R8100-00-PROCESSA-REGISTRO-SECTION */
        private void R8100_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -9913- MOVE '8100-00-PROCESSA-REGISTRO    ' TO PARAGRAFO. */
            _.Move("8100-00-PROCESSA-REGISTRO    ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9915- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9920- IF (PROPSSVD-NUM-APOLICE = 109300000550 OR PROPSSVD-NUM-APOLICE = 109300000559 OR PROPSSVD-NUM-APOLICE = 3009300000559 OR PROPSSVD-NUM-APOLICE = 3009300001559 ) AND WS-RAMO-CONJ-ANT = 84 */

            if ((PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE == 109300000550 || PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE == 109300000559 || PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE == 3009300000559 || PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE == 3009300001559) && WORK_RAMO_CONJ.WS_RAMO_CONJ_ANT == 84)
            {

                /*" -9921- IF IMPMORNATU OF DCLPLANOS-VA-VGAP > 0 */

                if (PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU > 0)
                {

                    /*" -9924- DIVIDE IMPSEGCDG OF DCLPLANOS-VA-VGAP BY IMPMORNATU OF DCLPLANOS-VA-VGAP GIVING WHOST-PERC-CDG */
                    _.Divide(PLVAVGAP.DCLPLANOS_VA_VGAP.IMPSEGCDG, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU, WHOST_PERC_CDG);

                    /*" -9925- ELSE */
                }
                else
                {


                    /*" -9926- IF IMPMORACID OF DCLPLANOS-VA-VGAP > 0 */

                    if (PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORACID > 0)
                    {

                        /*" -9929- DIVIDE IMPSEGCDG OF DCLPLANOS-VA-VGAP BY IMPMORACID OF DCLPLANOS-VA-VGAP GIVING WHOST-PERC-CDG */
                        _.Divide(PLVAVGAP.DCLPLANOS_VA_VGAP.IMPSEGCDG, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORACID, WHOST_PERC_CDG);

                        /*" -9930- ELSE */
                    }
                    else
                    {


                        /*" -9931- MOVE ZEROS TO WHOST-PERC-CDG */
                        _.Move(0, WHOST_PERC_CDG);

                        /*" -9932- END-IF */
                    }


                    /*" -9933- END-IF */
                }


                /*" -9935- COMPUTE VG081-VLR-PERC-PREMIO = VG081-VLR-PERC-PREMIO * WHOST-PERC-CDG */
                VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO.Value = VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO * WHOST_PERC_CDG;

                /*" -9937- END-IF. */
            }


            /*" -9938- IF WS-RAMO-CONJ-ANT = 82 */

            if (WORK_RAMO_CONJ.WS_RAMO_CONJ_ANT == 82)
            {

                /*" -9939- IF IMPMORNATU OF DCLPLANOS-VA-VGAP > 0 */

                if (PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU > 0)
                {

                    /*" -9942- DIVIDE IMPDIT OF DCLPLANOS-VA-VGAP BY IMPMORNATU OF DCLPLANOS-VA-VGAP GIVING WHOST-PERC-DIT */
                    _.Divide(PLVAVGAP.DCLPLANOS_VA_VGAP.IMPDIT, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU, WHOST_PERC_DIT);

                    /*" -9943- ELSE */
                }
                else
                {


                    /*" -9944- IF IMPMORACID OF DCLPLANOS-VA-VGAP > 0 */

                    if (PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORACID > 0)
                    {

                        /*" -9947- DIVIDE IMPDIT OF DCLPLANOS-VA-VGAP BY IMPMORACID OF DCLPLANOS-VA-VGAP GIVING WHOST-PERC-DIT */
                        _.Divide(PLVAVGAP.DCLPLANOS_VA_VGAP.IMPDIT, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORACID, WHOST_PERC_DIT);

                        /*" -9948- ELSE */
                    }
                    else
                    {


                        /*" -9949- MOVE ZEROS TO WHOST-PERC-DIT */
                        _.Move(0, WHOST_PERC_DIT);

                        /*" -9950- END-IF */
                    }


                    /*" -9951- END-IF */
                }


                /*" -9953- COMPUTE VG081-VLR-PERC-PREMIO = VG081-VLR-PERC-PREMIO * WHOST-PERC-DIT */
                VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO.Value = VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO * WHOST_PERC_DIT;

                /*" -9955- END-IF */
            }


            /*" -9959- ADD VG081-VLR-PERC-PREMIO TO WHOST-VLR-PERC-PREMIO WHOST-VLR-PERC-PREMIO-TOT */
            WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO.Value = WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO + VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO;
            WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO_TOT.Value = WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO_TOT + VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO;

            /*" -9959- PERFORM R7910-00-FETCH-VGRAMOCOMP. */

            R7910_00_FETCH_VGRAMOCOMP_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8100_99_SAIDA*/

        [StopWatch]
        /*" R8200-00-INSERT-VGHISTCONT-SECTION */
        private void R8200_00_INSERT_VGHISTCONT_SECTION()
        {
            /*" -9969- MOVE '8200-00-INSERT-VGHISTCONT    ' TO PARAGRAFO. */
            _.Move("8200-00-INSERT-VGHISTCONT    ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9970- MOVE 'INSERT VGHISTCONT            ' TO COMANDO. */
            _.Move("INSERT VGHISTCONT            ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -9972- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9974- ADD 1 TO WS-IND1. */
            WORK_RAMO_CONJ.WS_IND1.Value = WORK_RAMO_CONJ.WS_IND1 + 1;

            /*" -9976- IF WS-IND1 GREATER 30 OR TB-GRUPO-SUSEP (WS-IND1) EQUAL ZEROS */

            if (WORK_RAMO_CONJ.WS_IND1 > 30 || WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND1].TB_GRUPO_SUSEP == 00)
            {

                /*" -9977- MOVE 'SIM' TO WFIM-TAB-RAMO */
                _.Move("SIM", WORK_AREA.WFIM_TAB_RAMO);

                /*" -9978- ELSE */
            }
            else
            {


                /*" -9979- INITIALIZE DCLVG-HIST-CONT-COBER */
                _.Initialize(
                    VG082.DCLVG_HIST_CONT_COBER
                );

                /*" -9980- MOVE TB-GRUPO-SUSEP (WS-IND1) TO WHOST-GRUPO-SUSEP */
                _.Move(WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND1].TB_GRUPO_SUSEP, WHOST_GRUPO_SUSEP);

                /*" -9981- MOVE TB-RAMO-CONJ (WS-IND1) TO WHOST-COD-RAMO */
                _.Move(WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND1].TB_RAMO_CONJ, WHOST_COD_RAMO);

                /*" -9982- MOVE TB-TAXA-RAMO-CONJ (WS-IND1) TO WHOST-TAXA-RAMO */
                _.Move(WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND1].TB_TAXA_RAMO_CONJ, WHOST_TAXA_RAMO);

                /*" -9986- COMPUTE WHOST-PREMIO-CONJ ROUNDED = WS-PREMIO-TOTAL * WHOST-TAXA-RAMO / WHOST-VLR-PERC-PREMIO-TOT */
                WHOST_PREMIO_CONJ.Value = WS_PREMIO_TOTAL * WHOST_TAXA_RAMO / WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO_TOT;

                /*" -9987- IF WS-IND1 EQUAL WS-IND */

                if (WORK_RAMO_CONJ.WS_IND1 == WORK_RAMO_CONJ.WS_IND)
                {

                    /*" -9989- COMPUTE WHOST-PREMIO-CONJ = WS-PREMIO-TOTAL - WS-PREMIO-TOTAL-AC */
                    WHOST_PREMIO_CONJ.Value = WS_PREMIO_TOTAL - WS_PREMIO_TOTAL_AC;

                    /*" -9990- ELSE */
                }
                else
                {


                    /*" -9991- ADD WHOST-PREMIO-CONJ TO WS-PREMIO-TOTAL-AC */
                    WS_PREMIO_TOTAL_AC.Value = WS_PREMIO_TOTAL_AC + WHOST_PREMIO_CONJ;

                    /*" -9992- END-IF */
                }


                /*" -9993- IF WHOST-PREMIO-CONJ GREATER ZEROS */

                if (WHOST_PREMIO_CONJ > 00)
                {

                    /*" -9994- PERFORM R9000-00-INICIO */

                    R9000_00_INICIO_SECTION();

                    /*" -10019- PERFORM R8200_00_INSERT_VGHISTCONT_DB_INSERT_1 */

                    R8200_00_INSERT_VGHISTCONT_DB_INSERT_1();

                    /*" -10022- PERFORM R9100-00-TERMINO */

                    R9100_00_TERMINO_SECTION();

                    /*" -10024- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL -803 */

                    if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
                    {

                        /*" -10025- DISPLAY 'PROBLEMAS NO INSERT VGHISTCONT     ' */
                        _.Display($"PROBLEMAS NO INSERT VGHISTCONT     ");

                        /*" -10025- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


        }

        [StopWatch]
        /*" R8200-00-INSERT-VGHISTCONT-DB-INSERT-1 */
        public void R8200_00_INSERT_VGHISTCONT_DB_INSERT_1()
        {
            /*" -10019- EXEC SQL INSERT INTO SEGUROS.VG_HIST_CONT_COBER (NUM_CERTIFICADO , NUM_PARCELA , NUM_TITULO , OCORR_HISTORICO , COD_GRUPO_SUSEP , RAMO_EMISSOR , COD_MODALIDADE , COD_COBERTURA , VLR_PREMIO_RAMO , COD_USUARIO , DTH_ATUALIZACAO ) VALUES (:DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF, :DCLPARCELAS-VIDAZUL.NUM-PARCELA, :DCLCOBER-HIST-VIDAZUL.NUM-TITULO, :DCLCOBER-HIST-VIDAZUL.OCORR-HISTORICO, :WHOST-GRUPO-SUSEP , :WHOST-COD-RAMO , :VG082-COD-MODALIDADE, :VG082-COD-COBERTURA, :WHOST-PREMIO-CONJ, 'VA0601B' , CURRENT TIMESTAMP ) END-EXEC */

            var r8200_00_INSERT_VGHISTCONT_DB_INSERT_1_Insert1 = new R8200_00_INSERT_VGHISTCONT_DB_INSERT_1_Insert1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                NUM_PARCELA = PARVDZUL.DCLPARCELAS_VIDAZUL.NUM_PARCELA.ToString(),
                NUM_TITULO = CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_TITULO.ToString(),
                OCORR_HISTORICO = CBHSTZUL.DCLCOBER_HIST_VIDAZUL.OCORR_HISTORICO.ToString(),
                WHOST_GRUPO_SUSEP = WHOST_GRUPO_SUSEP.ToString(),
                WHOST_COD_RAMO = WHOST_COD_RAMO.ToString(),
                VG082_COD_MODALIDADE = VG082.DCLVG_HIST_CONT_COBER.VG082_COD_MODALIDADE.ToString(),
                VG082_COD_COBERTURA = VG082.DCLVG_HIST_CONT_COBER.VG082_COD_COBERTURA.ToString(),
                WHOST_PREMIO_CONJ = WHOST_PREMIO_CONJ.ToString(),
            };

            R8200_00_INSERT_VGHISTCONT_DB_INSERT_1_Insert1.Execute(r8200_00_INSERT_VGHISTCONT_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8200_99_SAIDA*/

        [StopWatch]
        /*" R8300-VERIF-DPS-ELETRONICA-SECTION */
        private void R8300_VERIF_DPS_ELETRONICA_SECTION()
        {
            /*" -10041- MOVE 'R8300-VERIF-DPS-ELETRONICA ' TO PARAGRAFO. */
            _.Move("R8300-VERIF-DPS-ELETRONICA ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -10042- MOVE 'VERIFICAR DPS ELETRONICA     ' TO COMANDO. */
            _.Move("VERIFICAR DPS ELETRONICA     ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -10044- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -10046- INITIALIZE LK-VG015-E-TRACE LK-VG015-E-IDE-SISTEMA LK-VG015-E-COD-USUARIO LK-VG015-E-NOM-PROGRAMA LK-VG015-E-TIPO-ACAO LK-VG015-E-NUM-CPF-CNPJ LK-VG015-E-COD-PRODUTO LK-VG015-E-VLR-IS LK-VG015-S-STA-PROPOSTA LK-VG015-S-SEQ-PRODUTO-DPS LK-VG015-S-VLR-ACUMULADO-IS LK-VG015-IND-ERRO LK-VG015-MENSAGEM LK-VG015-NOM-TABELA LK-VG015-SQLCODE LK-VG015-SQLERRMC LK-VG015-SQLSTATE. */
            _.Initialize(
                SPVG015W.LK_VG015_E_TRACE
                , SPVG015W.LK_VG015_E_IDE_SISTEMA
                , SPVG015W.LK_VG015_E_COD_USUARIO
                , SPVG015W.LK_VG015_E_NOM_PROGRAMA
                , SPVG015W.LK_VG015_E_TIPO_ACAO
                , SPVG015W.LK_VG015_E_NUM_CPF_CNPJ
                , SPVG015W.LK_VG015_E_COD_PRODUTO
                , SPVG015W.LK_VG015_E_VLR_IS
                , SPVG015W.LK_VG015_S_STA_PROPOSTA
                , SPVG015W.LK_VG015_S_SEQ_PRODUTO_DPS
                , SPVG015W.LK_VG015_S_VLR_ACUMULADO_IS
                , SPVG015W.LK_VG015_IND_ERRO
                , SPVG015W.LK_VG015_MENSAGEM
                , SPVG015W.LK_VG015_NOM_TABELA
                , SPVG015W.LK_VG015_SQLCODE
                , SPVG015W.LK_VG015_SQLERRMC
                , SPVG015W.LK_VG015_SQLSTATE
            );

            /*" -10047- MOVE 'N' TO LK-VG015-E-TRACE */
            _.Move("N", SPVG015W.LK_VG015_E_TRACE);

            /*" -10048- MOVE 'VG' TO LK-VG015-E-IDE-SISTEMA */
            _.Move("VG", SPVG015W.LK_VG015_E_IDE_SISTEMA);

            /*" -10049- MOVE 'BATCH' TO LK-VG015-E-COD-USUARIO */
            _.Move("BATCH", SPVG015W.LK_VG015_E_COD_USUARIO);

            /*" -10050- MOVE 'VA0601B' TO LK-VG015-E-NOM-PROGRAMA */
            _.Move("VA0601B", SPVG015W.LK_VG015_E_NOM_PROGRAMA);

            /*" -10051- MOVE 01 TO LK-VG015-E-TIPO-ACAO */
            _.Move(01, SPVG015W.LK_VG015_E_TIPO_ACAO);

            /*" -10053- MOVE CPF OF DCLPESSOA-FISICA TO LK-VG015-E-NUM-CPF-CNPJ */
            _.Move(PESFIS.DCLPESSOA_FISICA.CPF, SPVG015W.LK_VG015_E_NUM_CPF_CNPJ);

            /*" -10055- MOVE PRODUVG-COD-PRODUTO OF DCLPRODUTOS-VG TO LK-VG015-E-COD-PRODUTO */
            _.Move(PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO, SPVG015W.LK_VG015_E_COD_PRODUTO);

            /*" -10058- MOVE IMPMORNATU OF DCLPLANOS-VA-VGAP TO LK-VG015-E-VLR-IS */
            _.Move(PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU, SPVG015W.LK_VG015_E_VLR_IS);

            /*" -10060- MOVE 'SPBVG015' TO VG001-PROGRAMA */
            _.Move("SPBVG015", SPVG001V.VG001_PROGRAMA);

            /*" -10062- CALL VG001-PROGRAMA USING LK-VG015-E-TRACE LK-VG015-E-IDE-SISTEMA LK-VG015-E-COD-USUARIO LK-VG015-E-NOM-PROGRAMA LK-VG015-E-TIPO-ACAO LK-VG015-E-NUM-CPF-CNPJ LK-VG015-E-COD-PRODUTO LK-VG015-E-VLR-IS LK-VG015-S-STA-PROPOSTA LK-VG015-S-SEQ-PRODUTO-DPS LK-VG015-S-VLR-ACUMULADO-IS LK-VG015-IND-ERRO LK-VG015-MENSAGEM LK-VG015-NOM-TABELA LK-VG015-SQLCODE LK-VG015-SQLERRMC LK-VG015-SQLSTATE */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG015W);

            /*" -10063- IF LK-VG015-IND-ERRO NOT EQUAL ZEROS */

            if (SPVG015W.LK_VG015_IND_ERRO != 00)
            {

                /*" -10064- DISPLAY '*-------------------------------------------*' */
                _.Display($"*-------------------------------------------*");

                /*" -10065- DISPLAY '*R8300 -  PROBLEMAS CALL SUBROTINA SPBVG015 *' */
                _.Display($"*R8300 -  PROBLEMAS CALL SUBROTINA SPBVG015 *");

                /*" -10066- DISPLAY '*-------------------------------------------*' */
                _.Display($"*-------------------------------------------*");

                /*" -10067- DISPLAY '* NUM-CERTIF..: ' PROPVA-NRCERTIF */
                _.Display($"* NUM-CERTIF..: {PROPVA_NRCERTIF}");

                /*" -10068- DISPLAY '* NUM-CPFCNPJ.: ' LK-VG015-E-NUM-CPF-CNPJ */
                _.Display($"* NUM-CPFCNPJ.: {SPVG015W.LK_VG015_E_NUM_CPF_CNPJ}");

                /*" -10069- DISPLAY '* COD-PRODUTO.: ' LK-VG015-E-COD-PRODUTO */
                _.Display($"* COD-PRODUTO.: {SPVG015W.LK_VG015_E_COD_PRODUTO}");

                /*" -10070- DISPLAY '* IND-ERRO....: ' LK-VG015-IND-ERRO */
                _.Display($"* IND-ERRO....: {SPVG015W.LK_VG015_IND_ERRO}");

                /*" -10071- DISPLAY '* MSG-ERRO....: ' LK-VG015-MENSAGEM */
                _.Display($"* MSG-ERRO....: {SPVG015W.LK_VG015_MENSAGEM}");

                /*" -10072- DISPLAY '* NOM-TABELA..: ' LK-VG015-NOM-TABELA */
                _.Display($"* NOM-TABELA..: {SPVG015W.LK_VG015_NOM_TABELA}");

                /*" -10073- DISPLAY '* SQLCODE.....: ' LK-VG015-SQLCODE */
                _.Display($"* SQLCODE.....: {SPVG015W.LK_VG015_SQLCODE}");

                /*" -10074- DISPLAY '* SQLERRMC....: ' LK-VG015-SQLERRMC */
                _.Display($"* SQLERRMC....: {SPVG015W.LK_VG015_SQLERRMC}");

                /*" -10076- DISPLAY '*-------------------------------------------*' */
                _.Display($"*-------------------------------------------*");

                /*" -10077- MOVE 999 TO SQLCODE */
                _.Move(999, DB.SQLCODE);

                /*" -10078- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -10079- END-IF */
            }


            /*" -10079- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8300_FIM*/

        [StopWatch]
        /*" R8310-CONSULTA-ANALISE-DPS-SECTION */
        private void R8310_CONSULTA_ANALISE_DPS_SECTION()
        {
            /*" -10091- MOVE 'R8310-CONSULTA-ANALISE-DPS ' TO PARAGRAFO. */
            _.Move("R8310-CONSULTA-ANALISE-DPS ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -10092- MOVE 'CONSULTA DPS ELETRONICA   ' TO COMANDO. */
            _.Move("CONSULTA DPS ELETRONICA   ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -10095- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -10096- INITIALIZE LK-VG017-E-TRACE LK-VG017-E-IDE-SISTEMA LK-VG017-E-COD-USUARIO LK-VG017-E-NOM-PROGRAMA LK-VG017-E-TIPO-ACAO LK-VG017-E-NUM-PROTOCOLO LK-VG017-E-NUM-CPF-CNPJ LK-VG017-E-NUM-PROPOSTA LK-VG017-E-SEQ-PRODUTO-DPS LK-VG017-E-DTH-CONSULTA-DPS LK-VG017-E-IND-TP-PESSOA LK-VG017-E-IND-TP-SEGURADO LK-VG017-E-NUM-CERTIFICADO LK-VG017-E-VLR-IS LK-VG017-E-VLR-ACUMULADO-IS LK-VG017-E-STA-PROPOSTA-SIAS LK-VG017-E-STA-PROPOSTA-MOTOR LK-VG017-IND-ERRO LK-VG017-MENSAGEM LK-VG017-NOM-TABELA LK-VG017-SQLCODE LK-VG017-SQLERRMC LK-VG017-SQLSTATE */
            _.Initialize(
                SPVG017W.LK_VG017_E_TRACE
                , SPVG017W.LK_VG017_E_IDE_SISTEMA
                , SPVG017W.LK_VG017_E_COD_USUARIO
                , SPVG017W.LK_VG017_E_NOM_PROGRAMA
                , SPVG017W.LK_VG017_E_TIPO_ACAO
                , SPVG017W.LK_VG017_E_NUM_PROTOCOLO
                , SPVG017W.LK_VG017_E_NUM_CPF_CNPJ
                , SPVG017W.LK_VG017_E_NUM_PROPOSTA
                , SPVG017W.LK_VG017_E_SEQ_PRODUTO_DPS
                , SPVG017W.LK_VG017_E_DTH_CONSULTA_DPS
                , SPVG017W.LK_VG017_E_IND_TP_PESSOA
                , SPVG017W.LK_VG017_E_IND_TP_SEGURADO
                , SPVG017W.LK_VG017_E_NUM_CERTIFICADO
                , SPVG017W.LK_VG017_E_VLR_IS
                , SPVG017W.LK_VG017_E_VLR_ACUMULADO_IS
                , SPVG017W.LK_VG017_E_STA_PROPOSTA_SIAS
                , SPVG017W.LK_VG017_E_STA_PROPOSTA_MOTOR
                , SPVG017W.LK_VG017_IND_ERRO
                , SPVG017W.LK_VG017_MENSAGEM
                , SPVG017W.LK_VG017_NOM_TABELA
                , SPVG017W.LK_VG017_SQLCODE
                , SPVG017W.LK_VG017_SQLERRMC
                , SPVG017W.LK_VG017_SQLSTATE
            );

            /*" -10099- . */

            /*" -10100- MOVE 'N' TO LK-VG017-E-TRACE */
            _.Move("N", SPVG017W.LK_VG017_E_TRACE);

            /*" -10101- MOVE 'VG' TO LK-VG017-E-IDE-SISTEMA */
            _.Move("VG", SPVG017W.LK_VG017_E_IDE_SISTEMA);

            /*" -10102- MOVE 'BATCH' TO LK-VG017-E-COD-USUARIO */
            _.Move("BATCH", SPVG017W.LK_VG017_E_COD_USUARIO);

            /*" -10103- MOVE 'VA0601B' TO LK-VG017-E-NOM-PROGRAMA */
            _.Move("VA0601B", SPVG017W.LK_VG017_E_NOM_PROGRAMA);

            /*" -10105- MOVE 1 TO LK-VG017-E-TIPO-ACAO */
            _.Move(1, SPVG017W.LK_VG017_E_TIPO_ACAO);

            /*" -10108- MOVE PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO LK-VG017-E-NUM-PROPOSTA */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, SPVG017W.LK_VG017_E_NUM_PROPOSTA);

            /*" -10111- MOVE 'SPBVG017' TO WS-PROGRAMA */
            _.Move("SPBVG017", WS_PROGRAMA);

            /*" -10112- CALL WS-PROGRAMA USING LK-VG017-E-TRACE LK-VG017-E-IDE-SISTEMA LK-VG017-E-COD-USUARIO LK-VG017-E-NOM-PROGRAMA LK-VG017-E-TIPO-ACAO LK-VG017-E-NUM-PROTOCOLO LK-VG017-E-NUM-CPF-CNPJ LK-VG017-E-NUM-PROPOSTA LK-VG017-E-SEQ-PRODUTO-DPS LK-VG017-E-DTH-CONSULTA-DPS LK-VG017-E-IND-TP-PESSOA LK-VG017-E-IND-TP-SEGURADO LK-VG017-E-NUM-CERTIFICADO LK-VG017-E-VLR-IS LK-VG017-E-VLR-ACUMULADO-IS LK-VG017-E-STA-PROPOSTA-SIAS LK-VG017-E-STA-PROPOSTA-MOTOR LK-VG017-IND-ERRO LK-VG017-MENSAGEM LK-VG017-NOM-TABELA LK-VG017-SQLCODE LK-VG017-SQLERRMC LK-VG017-SQLSTATE */
            _.Call(WS_PROGRAMA, SPVG017W);

            /*" -10114- . */

            /*" -10115- IF LK-VG017-IND-ERRO NOT EQUAL ZEROS */

            if (SPVG017W.LK_VG017_IND_ERRO != 00)
            {

                /*" -10116- MOVE LK-VG017-E-TIPO-ACAO TO WS-SMALLINT(01) */
                _.Move(SPVG017W.LK_VG017_E_TIPO_ACAO, WS_EDIT.WS_SMALLINT[01]);

                /*" -10117- MOVE LK-VG017-E-NUM-PROPOSTA TO WS-BIGINT(01) */
                _.Move(SPVG017W.LK_VG017_E_NUM_PROPOSTA, WS_EDIT.WS_BIGINT[01]);

                /*" -10118- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -10119- DISPLAY '*R8310 - PROBLEMAS CALL SUBROTINA SPBVG017   *' */
                _.Display($"*R8310 - PROBLEMAS CALL SUBROTINA SPBVG017   *");

                /*" -10120- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -10121- DISPLAY '* TRACE         = ' LK-VG017-E-TRACE */
                _.Display($"* TRACE         = {SPVG017W.LK_VG017_E_TRACE}");

                /*" -10122- DISPLAY '* IDE-SISTEMA   = ' LK-VG017-E-IDE-SISTEMA */
                _.Display($"* IDE-SISTEMA   = {SPVG017W.LK_VG017_E_IDE_SISTEMA}");

                /*" -10123- DISPLAY '* COD-USUARIO   = ' LK-VG017-E-COD-USUARIO */
                _.Display($"* COD-USUARIO   = {SPVG017W.LK_VG017_E_COD_USUARIO}");

                /*" -10124- DISPLAY '* NOM-PROGRAMA  = ' LK-VG017-E-NOM-PROGRAMA */
                _.Display($"* NOM-PROGRAMA  = {SPVG017W.LK_VG017_E_NOM_PROGRAMA}");

                /*" -10125- DISPLAY '* TIPO-ACAO     = ' WS-SMALLINT(01) */
                _.Display($"* TIPO-ACAO     = {WS_EDIT.WS_SMALLINT[1]}");

                /*" -10126- DISPLAY '* NUM-PROPOSTA  = ' WS-BIGINT(01) */
                _.Display($"* NUM-PROPOSTA  = {WS_EDIT.WS_BIGINT[1]}");

                /*" -10127- DISPLAY '* IND-ERRO      = ' LK-VG017-IND-ERRO */
                _.Display($"* IND-ERRO      = {SPVG017W.LK_VG017_IND_ERRO}");

                /*" -10128- DISPLAY '* MSG-ERRO      = ' LK-VG017-MENSAGEM */
                _.Display($"* MSG-ERRO      = {SPVG017W.LK_VG017_MENSAGEM}");

                /*" -10129- DISPLAY '* NOM-TABELA    = ' LK-VG017-NOM-TABELA */
                _.Display($"* NOM-TABELA    = {SPVG017W.LK_VG017_NOM_TABELA}");

                /*" -10130- DISPLAY '* SQLCODE       = ' LK-VG017-SQLCODE */
                _.Display($"* SQLCODE       = {SPVG017W.LK_VG017_SQLCODE}");

                /*" -10131- DISPLAY '* SQLERRMC      = ' LK-VG017-SQLERRMC */
                _.Display($"* SQLERRMC      = {SPVG017W.LK_VG017_SQLERRMC}");

                /*" -10133- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -10134- MOVE 999 TO SQLCODE */
                _.Move(999, DB.SQLCODE);

                /*" -10135- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -10137- END-IF */
            }


            /*" -10137- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8310_99_EXIT*/

        [StopWatch]
        /*" R8320-GRAVAR-ANALISE-DPS-SECTION */
        private void R8320_GRAVAR_ANALISE_DPS_SECTION()
        {
            /*" -10150- MOVE 'R8320-GRAVAR-ANALISE-DPS ' TO PARAGRAFO. */
            _.Move("R8320-GRAVAR-ANALISE-DPS ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -10151- MOVE 'GRAVAR ANALISE DE DPS ELETRONICA' TO COMANDO. */
            _.Move("GRAVAR ANALISE DE DPS ELETRONICA", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -10156- DISPLAY PARAGRAFO ' PROPOSTA >> ' LK-VG017-E-NUM-PROPOSTA ' STATUS-DPS >> ' WS-STA-PROPOSTA-SIAS */

            $"{AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO} PROPOSTA >> {SPVG017W.LK_VG017_E_NUM_PROPOSTA} STATUS-DPS >> {WS_STA_PROPOSTA_SIAS}"
            .Display();

            /*" -10157- MOVE 'N' TO LK-VG017-E-TRACE */
            _.Move("N", SPVG017W.LK_VG017_E_TRACE);

            /*" -10158- MOVE 'VG' TO LK-VG017-E-IDE-SISTEMA */
            _.Move("VG", SPVG017W.LK_VG017_E_IDE_SISTEMA);

            /*" -10159- MOVE 'BATCH' TO LK-VG017-E-COD-USUARIO */
            _.Move("BATCH", SPVG017W.LK_VG017_E_COD_USUARIO);

            /*" -10160- MOVE 'VA0601B' TO LK-VG017-E-NOM-PROGRAMA */
            _.Move("VA0601B", SPVG017W.LK_VG017_E_NOM_PROGRAMA);

            /*" -10162- MOVE 2 TO LK-VG017-E-TIPO-ACAO */
            _.Move(2, SPVG017W.LK_VG017_E_TIPO_ACAO);

            /*" -10163- MOVE SPACES TO LK-VG017-E-DTH-CONSULTA-DPS */
            _.Move("", SPVG017W.LK_VG017_E_DTH_CONSULTA_DPS);

            /*" -10164- MOVE WS-STA-PROPOSTA-SIAS TO LK-VG017-E-STA-PROPOSTA-SIAS */
            _.Move(WS_STA_PROPOSTA_SIAS, SPVG017W.LK_VG017_E_STA_PROPOSTA_SIAS);

            /*" -10166- MOVE SPACES TO LK-VG017-E-STA-PROPOSTA-MOTOR */
            _.Move("", SPVG017W.LK_VG017_E_STA_PROPOSTA_MOTOR);

            /*" -10169- MOVE 'SPBVG017' TO WS-PROGRAMA */
            _.Move("SPBVG017", WS_PROGRAMA);

            /*" -10170- CALL WS-PROGRAMA USING LK-VG017-E-TRACE LK-VG017-E-IDE-SISTEMA LK-VG017-E-COD-USUARIO LK-VG017-E-NOM-PROGRAMA LK-VG017-E-TIPO-ACAO LK-VG017-E-NUM-PROTOCOLO LK-VG017-E-NUM-CPF-CNPJ LK-VG017-E-NUM-PROPOSTA LK-VG017-E-SEQ-PRODUTO-DPS LK-VG017-E-DTH-CONSULTA-DPS LK-VG017-E-IND-TP-PESSOA LK-VG017-E-IND-TP-SEGURADO LK-VG017-E-NUM-CERTIFICADO LK-VG017-E-VLR-IS LK-VG017-E-VLR-ACUMULADO-IS LK-VG017-E-STA-PROPOSTA-SIAS LK-VG017-E-STA-PROPOSTA-MOTOR LK-VG017-IND-ERRO LK-VG017-MENSAGEM LK-VG017-NOM-TABELA LK-VG017-SQLCODE LK-VG017-SQLERRMC LK-VG017-SQLSTATE */
            _.Call(WS_PROGRAMA, SPVG017W);

            /*" -10172- . */

            /*" -10173- IF LK-VG017-IND-ERRO NOT EQUAL ZEROS */

            if (SPVG017W.LK_VG017_IND_ERRO != 00)
            {

                /*" -10174- MOVE LK-VG017-E-TIPO-ACAO TO WS-SMALLINT(01) */
                _.Move(SPVG017W.LK_VG017_E_TIPO_ACAO, WS_EDIT.WS_SMALLINT[01]);

                /*" -10175- MOVE LK-VG017-E-NUM-PROPOSTA TO WS-BIGINT(01) */
                _.Move(SPVG017W.LK_VG017_E_NUM_PROPOSTA, WS_EDIT.WS_BIGINT[01]);

                /*" -10176- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -10177- DISPLAY '* R8320 - PROBLEMAS CALL SUBROTINA SPBVG017   *' */
                _.Display($"* R8320 - PROBLEMAS CALL SUBROTINA SPBVG017   *");

                /*" -10178- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -10179- DISPLAY '* TRACE         = ' LK-VG017-E-TRACE */
                _.Display($"* TRACE         = {SPVG017W.LK_VG017_E_TRACE}");

                /*" -10180- DISPLAY '* IDE-SISTEMA   = ' LK-VG017-E-IDE-SISTEMA */
                _.Display($"* IDE-SISTEMA   = {SPVG017W.LK_VG017_E_IDE_SISTEMA}");

                /*" -10181- DISPLAY '* COD-USUARIO   = ' LK-VG017-E-COD-USUARIO */
                _.Display($"* COD-USUARIO   = {SPVG017W.LK_VG017_E_COD_USUARIO}");

                /*" -10182- DISPLAY '* NOM-PROGRAMA  = ' LK-VG017-E-NOM-PROGRAMA */
                _.Display($"* NOM-PROGRAMA  = {SPVG017W.LK_VG017_E_NOM_PROGRAMA}");

                /*" -10183- DISPLAY '* TIPO-ACAO     = ' WS-SMALLINT(01) */
                _.Display($"* TIPO-ACAO     = {WS_EDIT.WS_SMALLINT[1]}");

                /*" -10184- DISPLAY '* NUM-PROPOSTA  = ' WS-BIGINT(01) */
                _.Display($"* NUM-PROPOSTA  = {WS_EDIT.WS_BIGINT[1]}");

                /*" -10185- DISPLAY '* IND-ERRO      = ' LK-VG017-IND-ERRO */
                _.Display($"* IND-ERRO      = {SPVG017W.LK_VG017_IND_ERRO}");

                /*" -10186- DISPLAY '* MSG-ERRO      = ' LK-VG017-MENSAGEM */
                _.Display($"* MSG-ERRO      = {SPVG017W.LK_VG017_MENSAGEM}");

                /*" -10187- DISPLAY '* NOM-TABELA    = ' LK-VG017-NOM-TABELA */
                _.Display($"* NOM-TABELA    = {SPVG017W.LK_VG017_NOM_TABELA}");

                /*" -10188- DISPLAY '* SQLCODE       = ' LK-VG017-SQLCODE */
                _.Display($"* SQLCODE       = {SPVG017W.LK_VG017_SQLCODE}");

                /*" -10189- DISPLAY '* SQLERRMC      = ' LK-VG017-SQLERRMC */
                _.Display($"* SQLERRMC      = {SPVG017W.LK_VG017_SQLERRMC}");

                /*" -10191- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -10192- MOVE 999 TO SQLCODE */
                _.Move(999, DB.SQLCODE);

                /*" -10193- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -10195- END-IF */
            }


            /*" -10195- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8320_99_EXIT*/

        [StopWatch]
        /*" R8330-ANALISA-STATUS-DPS-SECTION */
        private void R8330_ANALISA_STATUS_DPS_SECTION()
        {
            /*" -10226- MOVE 'R8330-ANALISA-STATUS-DPS ' TO PARAGRAFO. */
            _.Move("R8330-ANALISA-STATUS-DPS ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -10227- MOVE 'REALIZA ANALISE DE DPS ELETRONICA' TO COMANDO. */
            _.Move("REALIZA ANALISE DE DPS ELETRONICA", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -10229- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -10231- PERFORM R8310-CONSULTA-ANALISE-DPS */

            R8310_CONSULTA_ANALISE_DPS_SECTION();

            /*" -10233- EVALUATE LK-VG017-E-STA-PROPOSTA-SIAS */
            switch (SPVG017W.LK_VG017_E_STA_PROPOSTA_SIAS.Value)
            {

                /*" -10234- WHEN 0 */
                case 0:

                    /*" -10235- PERFORM R8300-VERIF-DPS-ELETRONICA */

                    R8300_VERIF_DPS_ELETRONICA_SECTION();

                    /*" -10238- PERFORM R8340-MOVE-AREA-PRIMEIRO-DPS */

                    R8340_MOVE_AREA_PRIMEIRO_DPS_SECTION();

                    /*" -10239- IF LK-VG015-S-STA-PROPOSTA EQUAL 'S' */

                    if (SPVG015W.LK_VG015_S_STA_PROPOSTA == "S")
                    {

                        /*" -10241- MOVE 'SIM' TO WS-TEM-ERRO-DPS-ELETR */
                        _.Move("SIM", WS_TEM_ERRO_DPS_ELETR);

                        /*" -10242- MOVE 1 TO WS-STA-PROPOSTA-SIAS */
                        _.Move(1, WS_STA_PROPOSTA_SIAS);

                        /*" -10244- PERFORM R8320-GRAVAR-ANALISE-DPS */

                        R8320_GRAVAR_ANALISE_DPS_SECTION();

                        /*" -10245- MOVE 008 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                        _.Move(008, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                        /*" -10248- PERFORM R1100-00-GRAVA-TAB-ERRO */

                        R1100_00_GRAVA_TAB_ERRO_SECTION();

                        /*" -10249- ELSE */
                    }
                    else
                    {


                        /*" -10252- MOVE 'NAO' TO WS-TEM-ERRO-DPS-ELETR */
                        _.Move("NAO", WS_TEM_ERRO_DPS_ELETR);

                        /*" -10253- MOVE 2 TO WS-STA-PROPOSTA-SIAS */
                        _.Move(2, WS_STA_PROPOSTA_SIAS);

                        /*" -10254- PERFORM R8320-GRAVAR-ANALISE-DPS */

                        R8320_GRAVAR_ANALISE_DPS_SECTION();

                        /*" -10257- END-IF */
                    }


                    /*" -10259- WHEN 1 */
                    break;
                case 1:

                    /*" -10262- MOVE 'SIM' TO WS-TEM-ERRO-DPS-ELETR */
                    _.Move("SIM", WS_TEM_ERRO_DPS_ELETR);

                    /*" -10264- WHEN 2 */
                    break;
                case 2:

                    /*" -10267- MOVE 'NAO' TO WS-TEM-ERRO-DPS-ELETR */
                    _.Move("NAO", WS_TEM_ERRO_DPS_ELETR);

                    /*" -10269- WHEN 3 */
                    break;
                case 3:

                    /*" -10272- MOVE 'SIM' TO WS-TEM-ERRO-DPS-ELETR */
                    _.Move("SIM", WS_TEM_ERRO_DPS_ELETR);

                    /*" -10274- WHEN 4 */
                    break;
                case 4:

                    /*" -10277- MOVE 'SIM' TO WS-TEM-ERRO-DPS-ELETR */
                    _.Move("SIM", WS_TEM_ERRO_DPS_ELETR);

                    /*" -10279- WHEN 5 */
                    break;
                case 5:

                    /*" -10282- MOVE 'NAO' TO WS-TEM-ERRO-DPS-ELETR */
                    _.Move("NAO", WS_TEM_ERRO_DPS_ELETR);

                    /*" -10284- WHEN 6 */
                    break;
                case 6:

                    /*" -10287- MOVE 'SIM' TO WS-TEM-ERRO-DPS-ELETR */
                    _.Move("SIM", WS_TEM_ERRO_DPS_ELETR);

                    /*" -10289- WHEN 7 */
                    break;
                case 7:

                    /*" -10292- MOVE 'SIM' TO WS-TEM-ERRO-DPS-ELETR */
                    _.Move("SIM", WS_TEM_ERRO_DPS_ELETR);

                    /*" -10294- WHEN 9 */
                    break;
                case 9:

                    /*" -10301- MOVE 'SIM' TO WS-TEM-ERRO-DPS-ELETR */
                    _.Move("SIM", WS_TEM_ERRO_DPS_ELETR);

                    /*" -10303- WHEN OTHER */
                    break;
                default:

                    /*" -10306- DISPLAY '* R8330-ERRO: STATUS DPS DESCONHECIDO : ' LK-VG017-E-STA-PROPOSTA-SIAS */
                    _.Display($"* R8330-ERRO: STATUS DPS DESCONHECIDO : {SPVG017W.LK_VG017_E_STA_PROPOSTA_SIAS}");

                    /*" -10307- MOVE 999 TO SQLCODE */
                    _.Move(999, DB.SQLCODE);

                    /*" -10308- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -10309- END-EVALUATE */
                    break;
            }


            /*" -10309- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8330_FIM*/

        [StopWatch]
        /*" R8340-MOVE-AREA-PRIMEIRO-DPS-SECTION */
        private void R8340_MOVE_AREA_PRIMEIRO_DPS_SECTION()
        {
            /*" -10318- MOVE 'R8340-MOVE-AREA-PRIMEIRO-DPS' TO PARAGRAFO. */
            _.Move("R8340-MOVE-AREA-PRIMEIRO-DPS", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -10319- MOVE 'MOVE AREA PARA GRAVACAO DO 1O DPS' TO COMANDO. */
            _.Move("AREA PARA GRAVACAO DO 1O DPS", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -10322- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -10323- INITIALIZE LK-VG017-E-TRACE LK-VG017-E-IDE-SISTEMA LK-VG017-E-COD-USUARIO LK-VG017-E-NOM-PROGRAMA LK-VG017-E-TIPO-ACAO LK-VG017-E-NUM-PROTOCOLO LK-VG017-E-NUM-CPF-CNPJ LK-VG017-E-NUM-PROPOSTA LK-VG017-E-SEQ-PRODUTO-DPS LK-VG017-E-DTH-CONSULTA-DPS LK-VG017-E-IND-TP-PESSOA LK-VG017-E-IND-TP-SEGURADO LK-VG017-E-NUM-CERTIFICADO LK-VG017-E-VLR-IS LK-VG017-E-VLR-ACUMULADO-IS LK-VG017-E-STA-PROPOSTA-SIAS LK-VG017-E-STA-PROPOSTA-MOTOR LK-VG017-IND-ERRO LK-VG017-MENSAGEM LK-VG017-NOM-TABELA LK-VG017-SQLCODE LK-VG017-SQLERRMC LK-VG017-SQLSTATE */
            _.Initialize(
                SPVG017W.LK_VG017_E_TRACE
                , SPVG017W.LK_VG017_E_IDE_SISTEMA
                , SPVG017W.LK_VG017_E_COD_USUARIO
                , SPVG017W.LK_VG017_E_NOM_PROGRAMA
                , SPVG017W.LK_VG017_E_TIPO_ACAO
                , SPVG017W.LK_VG017_E_NUM_PROTOCOLO
                , SPVG017W.LK_VG017_E_NUM_CPF_CNPJ
                , SPVG017W.LK_VG017_E_NUM_PROPOSTA
                , SPVG017W.LK_VG017_E_SEQ_PRODUTO_DPS
                , SPVG017W.LK_VG017_E_DTH_CONSULTA_DPS
                , SPVG017W.LK_VG017_E_IND_TP_PESSOA
                , SPVG017W.LK_VG017_E_IND_TP_SEGURADO
                , SPVG017W.LK_VG017_E_NUM_CERTIFICADO
                , SPVG017W.LK_VG017_E_VLR_IS
                , SPVG017W.LK_VG017_E_VLR_ACUMULADO_IS
                , SPVG017W.LK_VG017_E_STA_PROPOSTA_SIAS
                , SPVG017W.LK_VG017_E_STA_PROPOSTA_MOTOR
                , SPVG017W.LK_VG017_IND_ERRO
                , SPVG017W.LK_VG017_MENSAGEM
                , SPVG017W.LK_VG017_NOM_TABELA
                , SPVG017W.LK_VG017_SQLCODE
                , SPVG017W.LK_VG017_SQLERRMC
                , SPVG017W.LK_VG017_SQLSTATE
            );

            /*" -10326- . */

            /*" -10328- MOVE CPF OF DCLPESSOA-FISICA TO LK-VG017-E-NUM-CPF-CNPJ */
            _.Move(PESFIS.DCLPESSOA_FISICA.CPF, SPVG017W.LK_VG017_E_NUM_CPF_CNPJ);

            /*" -10329- MOVE ZEROS TO LK-VG017-E-NUM-PROTOCOLO */
            _.Move(0, SPVG017W.LK_VG017_E_NUM_PROTOCOLO);

            /*" -10331- MOVE PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO LK-VG017-E-NUM-PROPOSTA */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, SPVG017W.LK_VG017_E_NUM_PROPOSTA);

            /*" -10333- MOVE LK-VG015-S-SEQ-PRODUTO-DPS TO LK-VG017-E-SEQ-PRODUTO-DPS */
            _.Move(SPVG015W.LK_VG015_S_SEQ_PRODUTO_DPS, SPVG017W.LK_VG017_E_SEQ_PRODUTO_DPS);

            /*" -10334- MOVE SPACES TO LK-VG017-E-DTH-CONSULTA-DPS */
            _.Move("", SPVG017W.LK_VG017_E_DTH_CONSULTA_DPS);

            /*" -10335- MOVE 'F' TO LK-VG017-E-IND-TP-PESSOA */
            _.Move("F", SPVG017W.LK_VG017_E_IND_TP_PESSOA);

            /*" -10336- MOVE 'S' TO LK-VG017-E-IND-TP-SEGURADO */
            _.Move("S", SPVG017W.LK_VG017_E_IND_TP_SEGURADO);

            /*" -10338- MOVE PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO LK-VG017-E-NUM-CERTIFICADO */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, SPVG017W.LK_VG017_E_NUM_CERTIFICADO);

            /*" -10339- MOVE LK-VG015-E-VLR-IS TO LK-VG017-E-VLR-IS */
            _.Move(SPVG015W.LK_VG015_E_VLR_IS, SPVG017W.LK_VG017_E_VLR_IS);

            /*" -10342- MOVE LK-VG015-S-VLR-ACUMULADO-IS TO LK-VG017-E-VLR-ACUMULADO-IS */
            _.Move(SPVG015W.LK_VG015_S_VLR_ACUMULADO_IS, SPVG017W.LK_VG017_E_VLR_ACUMULADO_IS);

            /*" -10343- MOVE WS-STA-PROPOSTA-SIAS TO LK-VG017-E-STA-PROPOSTA-SIAS */
            _.Move(WS_STA_PROPOSTA_SIAS, SPVG017W.LK_VG017_E_STA_PROPOSTA_SIAS);

            /*" -10344- MOVE SPACES TO LK-VG017-E-STA-PROPOSTA-MOTOR */
            _.Move("", SPVG017W.LK_VG017_E_STA_PROPOSTA_MOTOR);

            /*" -10344- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8340_99_EXIT*/

        [StopWatch]
        /*" R8350-FECHAR-MSG-ERRO-DPS-SECTION */
        private void R8350_FECHAR_MSG_ERRO_DPS_SECTION()
        {
            /*" -10354- MOVE 'R8350-FECHAR-MSG-ERRO-DPS' TO PARAGRAFO */
            _.Move("R8350-FECHAR-MSG-ERRO-DPS", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -10356- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -10358- INITIALIZE WS-FIM-ERRO-DPS */
            _.Initialize(
                WS_FIM_ERRO_DPS
            );

            /*" -10368- PERFORM R8350_FECHAR_MSG_ERRO_DPS_DB_DECLARE_1 */

            R8350_FECHAR_MSG_ERRO_DPS_DB_DECLARE_1();

            /*" -10372- PERFORM R8360-ABRIR-CSR-ERRO-DPS */

            R8360_ABRIR_CSR_ERRO_DPS_SECTION();

            /*" -10375- PERFORM R8370-FETCH-CSR-ERRO-DPS THRU R8370-99-SAIDA UNTIL WS-FIM-ERRO-DPS EQUAL 'SIM' */

            while (!(WS_FIM_ERRO_DPS == "SIM"))
            {

                R8370_FETCH_CSR_ERRO_DPS_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8370_99_SAIDA*/

            }

            /*" -10375- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8350_FIM*/

        [StopWatch]
        /*" R8360-ABRIR-CSR-ERRO-DPS-SECTION */
        private void R8360_ABRIR_CSR_ERRO_DPS_SECTION()
        {
            /*" -10383- MOVE 'R8350-ABRIR-CSR-ERRO-DPS    ' TO PARAGRAFO */
            _.Move("R8350-ABRIR-CSR-ERRO-DPS    ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -10384- MOVE 'OPEN DO CURSOR CSR-ERRO-DPS   ' TO COMANDO */
            _.Move("OPEN DO CURSOR CSR-ERRO-DPS   ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -10386- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -10386- PERFORM R8360_ABRIR_CSR_ERRO_DPS_DB_OPEN_1 */

            R8360_ABRIR_CSR_ERRO_DPS_DB_OPEN_1();

            /*" -10389- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -10390- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_SQLCODE);

                /*" -10390- PERFORM R8360_ABRIR_CSR_ERRO_DPS_DB_CLOSE_1 */

                R8360_ABRIR_CSR_ERRO_DPS_DB_CLOSE_1();

                /*" -10392- DISPLAY 'VA0601B - PROBLEMAS NO OPEN DO CSR_ERRO_DPS' */
                _.Display($"VA0601B - PROBLEMAS NO OPEN DO CSR_ERRO_DPS");

                /*" -10393- DISPLAY ' COD_PRODUTO_SIVPF.. ' PROPOFID-COD-PRODUTO-SIVPF */
                _.Display($" COD_PRODUTO_SIVPF.. {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF}");

                /*" -10395- DISPLAY ' NUM-CERTIFICADO.... ' PROPOFID-NUM-PROPOSTA-SIVPF */
                _.Display($" NUM-CERTIFICADO.... {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -10396- DISPLAY ' SQLCODE............ ' WS-SQLCODE */
                _.Display($" SQLCODE............ {WS_SQLCODE}");

                /*" -10397- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -10398- END-IF */
            }


            /*" -10398- . */

        }

        [StopWatch]
        /*" R8360-ABRIR-CSR-ERRO-DPS-DB-OPEN-1 */
        public void R8360_ABRIR_CSR_ERRO_DPS_DB_OPEN_1()
        {
            /*" -10386- EXEC SQL OPEN CSR_ERRO_DPS END-EXEC */

            CSR_ERRO_DPS.Open();

        }

        [StopWatch]
        /*" R9320-00-SELECT-GECLIMOV-DB-DECLARE-1 */
        public void R9320_00_SELECT_GECLIMOV_DB_DECLARE_1()
        {
            /*" -11062- EXEC SQL DECLARE C01_GECLIMOV CURSOR FOR SELECT TIPO_MOVIMENTO , DATA_ULT_MANUTEN , NOME_RAZAO , TIPO_PESSOA , IDE_SEXO , ESTADO_CIVIL , OCORR_ENDERECO , ENDERECO , BAIRRO , CIDADE , SIGLA_UF , CEP , DDD , TELEFONE , FAX , OCORR_HIST , CGCCPF , DATA_NASCIMENTO FROM SEGUROS.GE_CLIENTES_MOVTO WHERE COD_CLIENTE = :GECLIMOV-COD-CLIENTE AND OCORR_ENDERECO BETWEEN :WHOST-OCORR-END-I AND :WHOST-OCORR-END-F ORDER BY OCORR_HIST DESC END-EXEC. */
            C01_GECLIMOV = new VA0601B_C01_GECLIMOV(true);
            string GetQuery_C01_GECLIMOV()
            {
                var query = @$"SELECT TIPO_MOVIMENTO
							, 
							DATA_ULT_MANUTEN
							, 
							NOME_RAZAO
							, 
							TIPO_PESSOA
							, 
							IDE_SEXO
							, 
							ESTADO_CIVIL
							, 
							OCORR_ENDERECO
							, 
							ENDERECO
							, 
							BAIRRO
							, 
							CIDADE
							, 
							SIGLA_UF
							, 
							CEP
							, 
							DDD
							, 
							TELEFONE
							, 
							FAX
							, 
							OCORR_HIST
							, 
							CGCCPF
							, 
							DATA_NASCIMENTO 
							FROM SEGUROS.GE_CLIENTES_MOVTO 
							WHERE COD_CLIENTE = '{GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE}' 
							AND OCORR_ENDERECO BETWEEN '{WHOST_OCORR_END_I}' 
							AND '{WHOST_OCORR_END_F}' 
							ORDER BY OCORR_HIST DESC";

                return query;
            }
            C01_GECLIMOV.GetQueryEvent += GetQuery_C01_GECLIMOV;

        }

        [StopWatch]
        /*" R8360-ABRIR-CSR-ERRO-DPS-DB-CLOSE-1 */
        public void R8360_ABRIR_CSR_ERRO_DPS_DB_CLOSE_1()
        {
            /*" -10390- EXEC SQL CLOSE CSR_ERRO_DPS END-EXEC */

            CSR_ERRO_DPS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8360_99_SAIDA*/

        [StopWatch]
        /*" R8370-FETCH-CSR-ERRO-DPS-SECTION */
        private void R8370_FETCH_CSR_ERRO_DPS_SECTION()
        {
            /*" -10407- MOVE 'R8370-FETCH-CSR-ERRO-DPS    ' TO PARAGRAFO */
            _.Move("R8370-FETCH-CSR-ERRO-DPS    ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -10408- MOVE 'FETCH DO CURSOR CSR-ERRO-DPS  ' TO COMANDO */
            _.Move("FETCH DO CURSOR CSR-ERRO-DPS  ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -10410- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -10415- PERFORM R8370_FETCH_CSR_ERRO_DPS_DB_FETCH_1 */

            R8370_FETCH_CSR_ERRO_DPS_DB_FETCH_1();

            /*" -10418-  EVALUATE SQLCODE  */

            /*" -10419-  WHEN ZEROS  */

            /*" -10419- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -10420- PERFORM R8380-FECHAR-ERRO-DPS */

                R8380_FECHAR_ERRO_DPS_SECTION();

                /*" -10421-  WHEN +100  */

                /*" -10421- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -10421- PERFORM R8370_FETCH_CSR_ERRO_DPS_DB_CLOSE_1 */

                R8370_FETCH_CSR_ERRO_DPS_DB_CLOSE_1();

                /*" -10423- MOVE 'SIM' TO WS-FIM-ERRO-DPS */
                _.Move("SIM", WS_FIM_ERRO_DPS);

                /*" -10424-  WHEN OTHER  */

                /*" -10424- ELSE */
            }
            else
            {


                /*" -10425- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_SQLCODE);

                /*" -10425- PERFORM R8370_FETCH_CSR_ERRO_DPS_DB_CLOSE_2 */

                R8370_FETCH_CSR_ERRO_DPS_DB_CLOSE_2();

                /*" -10427- MOVE 'FIM' TO WS-FIM-ERRO-DPS */
                _.Move("FIM", WS_FIM_ERRO_DPS);

                /*" -10428- DISPLAY 'VA0601B - PROBLEMAS FETCH DO CURSOR CSR_ERRO_DPS' */
                _.Display($"VA0601B - PROBLEMAS FETCH DO CURSOR CSR_ERRO_DPS");

                /*" -10429- DISPLAY ' SEQ-CRITICA........ ' VG103-SEQ-CRITICA */
                _.Display($" SEQ-CRITICA........ {VG103.DCLVG_CRITICA_PROPOSTA.VG103_SEQ_CRITICA}");

                /*" -10430- DISPLAY ' COD-MSG-CRITICA.... ' VG103-COD-MSG-CRITICA */
                _.Display($" COD-MSG-CRITICA.... {VG103.DCLVG_CRITICA_PROPOSTA.VG103_COD_MSG_CRITICA}");

                /*" -10431- DISPLAY ' NUM-CERTIFICADO.... ' VG103-NUM-CERTIFICADO */
                _.Display($" NUM-CERTIFICADO.... {VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CERTIFICADO}");

                /*" -10433- DISPLAY ' SQLCODE............ ' WS-SQLCODE */
                _.Display($" SQLCODE............ {WS_SQLCODE}");

                /*" -10434- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -10435-  END-EVALUATE  */

                /*" -10435- END-IF */
            }


            /*" -10435- . */

        }

        [StopWatch]
        /*" R8370-FETCH-CSR-ERRO-DPS-DB-FETCH-1 */
        public void R8370_FETCH_CSR_ERRO_DPS_DB_FETCH_1()
        {
            /*" -10415- EXEC SQL FETCH CSR_ERRO_DPS INTO :VG103-NUM-CERTIFICADO, :VG103-SEQ-CRITICA, :VG103-COD-MSG-CRITICA END-EXEC */

            if (CSR_ERRO_DPS.Fetch())
            {
                _.Move(CSR_ERRO_DPS.VG103_NUM_CERTIFICADO, VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CERTIFICADO);
                _.Move(CSR_ERRO_DPS.VG103_SEQ_CRITICA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_SEQ_CRITICA);
                _.Move(CSR_ERRO_DPS.VG103_COD_MSG_CRITICA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_COD_MSG_CRITICA);
            }

        }

        [StopWatch]
        /*" R8370-FETCH-CSR-ERRO-DPS-DB-CLOSE-1 */
        public void R8370_FETCH_CSR_ERRO_DPS_DB_CLOSE_1()
        {
            /*" -10421- EXEC SQL CLOSE CSR_ERRO_DPS END-EXEC */

            CSR_ERRO_DPS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8370_99_SAIDA*/

        [StopWatch]
        /*" R8370-FETCH-CSR-ERRO-DPS-DB-CLOSE-2 */
        public void R8370_FETCH_CSR_ERRO_DPS_DB_CLOSE_2()
        {
            /*" -10425- EXEC SQL CLOSE CSR_ERRO_DPS END-EXEC */

            CSR_ERRO_DPS.Close();

        }

        [StopWatch]
        /*" R8380-FECHAR-ERRO-DPS-SECTION */
        private void R8380_FECHAR_ERRO_DPS_SECTION()
        {
            /*" -10445- MOVE 'R8380-FECHAR-ERRO-DPS' TO PARAGRAFO */
            _.Move("R8380-FECHAR-ERRO-DPS", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -10450- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -10452- INITIALIZE LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
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

            /*" -10453- MOVE 'N' TO LK-VG001-TRACE */
            _.Move("N", SPVG001W.LK_VG001_TRACE);

            /*" -10454- MOVE 03 TO LK-VG001-TIPO-ACAO */
            _.Move(03, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -10456- MOVE PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO LK-VG001-NUM-CERTIFICADO */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, SPVG001W.LK_VG001_NUM_CERTIFICADO);

            /*" -10457- MOVE VG103-SEQ-CRITICA TO LK-VG001-SEQ-CRITICA */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_SEQ_CRITICA, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -10458- MOVE VG103-COD-MSG-CRITICA TO LK-VG001-COD-MSG-CRITICA */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_COD_MSG_CRITICA, SPVG001W.LK_VG001_COD_MSG_CRITICA);

            /*" -10459- MOVE 'PF' TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("PF", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -10461- MOVE CPF OF DCLPESSOA-FISICA TO LK-VG001-NUM-CPF-CNPJ */
            _.Move(PESFIS.DCLPESSOA_FISICA.CPF, SPVG001W.LK_VG001_NUM_CPF_CNPJ);

            /*" -10462- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -10463- MOVE 'VA0601B' TO LK-VG001-NOM-PROGRAMA */
            _.Move("VA0601B", SPVG001W.LK_VG001_NOM_PROGRAMA);

            /*" -10464- MOVE 'SPBVG001' TO VG001-PROGRAMA */
            _.Move("SPBVG001", SPVG001V.VG001_PROGRAMA);

            /*" -10465- MOVE 'B' TO LK-VG001-STA-CRITICA */
            _.Move("B", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -10466- MOVE 45 TO LK-VG001-DES-COMPLEMENTAR-L */
            _.Move(45, SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_L);

            /*" -10469- MOVE 'ERRO TRATADO APOS RECEBIMENTO DE DPS ACEITO' TO LK-VG001-DES-COMPLEMENTAR-T */
            _.Move("ERRO TRATADO APOS RECEBIMENTO DE DPS ACEITO", SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_T);

            /*" -10471- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -10472- IF LK-VG001-IND-ERRO NOT EQUAL ZEROS */

            if (SPVG001W.LK_VG001_IND_ERRO != 00)
            {

                /*" -10473- DISPLAY '*-------------------------------------------*' */
                _.Display($"*-------------------------------------------*");

                /*" -10474- DISPLAY '*R8380 -  PROBLEMAS CALL SUBROTINA SPBVG001 *' */
                _.Display($"*R8380 -  PROBLEMAS CALL SUBROTINA SPBVG001 *");

                /*" -10475- DISPLAY '*-------------------------------------------*' */
                _.Display($"*-------------------------------------------*");

                /*" -10476- DISPLAY '* NUM-CERTIF..: ' LK-VG001-NUM-CERTIFICADO */
                _.Display($"* NUM-CERTIF..: {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                /*" -10477- DISPLAY '* SEQ-CRITICA.: ' LK-VG001-SEQ-CRITICA */
                _.Display($"* SEQ-CRITICA.: {SPVG001W.LK_VG001_SEQ_CRITICA}");

                /*" -10478- DISPLAY '* MSG-CRITICA.: ' LK-VG001-COD-MSG-CRITICA */
                _.Display($"* MSG-CRITICA.: {SPVG001W.LK_VG001_COD_MSG_CRITICA}");

                /*" -10479- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                /*" -10480- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                /*" -10481- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                /*" -10482- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                /*" -10483- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                /*" -10485- DISPLAY '*-------------------------------------------*' */
                _.Display($"*-------------------------------------------*");

                /*" -10486- MOVE 999 TO SQLCODE */
                _.Move(999, DB.SQLCODE);

                /*" -10487- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -10488- END-IF */
            }


            /*" -10488- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8380_99_SAIDA*/

        [StopWatch]
        /*" R8550-00-PROCURA-RISCO-PROP-SECTION */
        private void R8550_00_PROCURA_RISCO_PROP_SECTION()
        {
            /*" -10502- MOVE 'R8550-00-PROCURA-RISCO-PROP  ' TO COMANDO. */
            _.Move("R8550-00-PROCURA-RISCO-PROP  ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -10506- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -10507- MOVE 'N' TO LK-VG009-E-TRACE */
            _.Move("N", SPVG009W.LK_VG009_E_TRACE);

            /*" -10509- MOVE 'VA0601B' TO LK-VG009-E-COD-USUARIO LK-VG009-E-NOM-PROGRAMA */
            _.Move("VA0601B", SPVG009W.LK_VG009_E_COD_USUARIO, SPVG009W.LK_VG009_E_NOM_PROGRAMA);

            /*" -10510- MOVE 01 TO LK-VG009-E-TIPO-ACAO */
            _.Move(01, SPVG009W.LK_VG009_E_TIPO_ACAO);

            /*" -10513- MOVE PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO LK-VG009-E-NUM-PROPOSTA */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, SPVG009W.LK_VG009_E_NUM_PROPOSTA);

            /*" -10514- MOVE 0 TO LK-VG009-IND-ERRO */
            _.Move(0, SPVG009W.LK_VG009_IND_ERRO);

            /*" -10516- MOVE SPACES TO LK-VG009-MSG-ERRO LK-VG009-NOM-TABELA */
            _.Move("", SPVG009W.LK_VG009_MSG_ERRO, SPVG009W.LK_VG009_NOM_TABELA);

            /*" -10517- MOVE 0 TO LK-VG009-SQLCODE */
            _.Move(0, SPVG009W.LK_VG009_SQLCODE);

            /*" -10519- MOVE SPACES TO LK-VG009-SQLERRMC */
            _.Move("", SPVG009W.LK_VG009_SQLERRMC);

            /*" -10521- MOVE 'SPBVG009' TO WS-PROGRAMA */
            _.Move("SPBVG009", WS_PROGRAMA);

            /*" -10542- CALL WS-PROGRAMA USING LK-VG009-E-TRACE LK-VG009-E-COD-USUARIO LK-VG009-E-NOM-PROGRAMA LK-VG009-E-TIPO-ACAO LK-VG009-E-NUM-PROPOSTA LK-VG009-S-COD-PESSOA LK-VG009-S-SEQ-PESSOA-HIST LK-VG009-S-COD-CLASSIF-RISCO LK-VG009-S-NUM-SCORE-RISCO LK-VG009-S-DTA-CLASSIF-RISCO LK-VG009-S-IND-PEND-APROVACAO LK-VG009-S-IND-DECL-AUTOMATICO LK-VG009-S-IND-ATLZ-FXA-RISCO LK-VG009-IND-ERRO LK-VG009-MSG-ERRO LK-VG009-NOM-TABELA LK-VG009-SQLCODE LK-VG009-SQLERRMC */
            _.Call(WS_PROGRAMA, SPVG009W);

            /*" -10543- IF LK-VG009-IND-ERRO NOT EQUAL ZEROS AND 001 */

            if (!SPVG009W.LK_VG009_IND_ERRO.In("00", "001"))
            {

                /*" -10544- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -10545- DISPLAY '* 8550 - PROBLEMAS CALL SUBROTINA SPBVG009    *' */
                _.Display($"* 8550 - PROBLEMAS CALL SUBROTINA SPBVG009    *");

                /*" -10546- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -10547- DISPLAY '* NUM-PROPOST: ' LK-VG009-E-NUM-PROPOSTA */
                _.Display($"* NUM-PROPOST: {SPVG009W.LK_VG009_E_NUM_PROPOSTA}");

                /*" -10548- DISPLAY '* TIPO-ACAO..: ' LK-VG009-E-TIPO-ACAO */
                _.Display($"* TIPO-ACAO..: {SPVG009W.LK_VG009_E_TIPO_ACAO}");

                /*" -10549- DISPLAY '* IND-ERRO...: ' LK-VG009-IND-ERRO */
                _.Display($"* IND-ERRO...: {SPVG009W.LK_VG009_IND_ERRO}");

                /*" -10550- DISPLAY '* MSG-ERRO...: ' LK-VG009-MSG-ERRO */
                _.Display($"* MSG-ERRO...: {SPVG009W.LK_VG009_MSG_ERRO}");

                /*" -10551- DISPLAY '* NOM-TABELA.: ' LK-VG009-NOM-TABELA */
                _.Display($"* NOM-TABELA.: {SPVG009W.LK_VG009_NOM_TABELA}");

                /*" -10552- DISPLAY '* SQLCODE....: ' LK-VG009-SQLCODE */
                _.Display($"* SQLCODE....: {SPVG009W.LK_VG009_SQLCODE}");

                /*" -10553- DISPLAY '* SQLERRMC...: ' LK-VG009-SQLERRMC */
                _.Display($"* SQLERRMC...: {SPVG009W.LK_VG009_SQLERRMC}");

                /*" -10554- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -10555- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -10557- END-IF */
            }


            /*" -10558- IF LK-VG009-S-COD-CLASSIF-RISCO EQUAL 04 */

            if (SPVG009W.LK_VG009_S_COD_CLASSIF_RISCO == 04)
            {

                /*" -10560- DISPLAY 'DESPREZADO RISCO CRITICO.: ' LK-VG009-E-NUM-PROPOSTA */
                _.Display($"DESPREZADO RISCO CRITICO.: {SPVG009W.LK_VG009_E_NUM_PROPOSTA}");

                /*" -10561- MOVE 1 TO WS-TEM-ERRO */
                _.Move(1, WORK_AREA.WS_TEM_ERRO);

                /*" -10562- ADD 1 TO WS-QT-RISCO-CRITICO */
                WS_QT_RISCO_CRITICO.Value = WS_QT_RISCO_CRITICO + 1;

                /*" -10563- END-IF */
            }


            /*" -10563- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8550_99_EXIT*/

        [StopWatch]
        /*" R8555-00-GRAVA-RISCO-MOTOR-SECTION */
        private void R8555_00_GRAVA_RISCO_MOTOR_SECTION()
        {
            /*" -10576- MOVE 'R8555-00-GRAVA-RISCO-MOTOR  ' TO COMANDO. */
            _.Move("R8555-00-GRAVA-RISCO-MOTOR  ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -10578- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -10580- MOVE 0 TO WS-ERRO-VG009 */
            _.Move(0, WS_ERRO_VG009);

            /*" -10581-  EVALUATE TRUE  */

            /*" -10582-  WHEN LK-VG009-IND-ERRO = 00  */

            /*" -10582- IF LK-VG009-IND-ERRO = 00 */

            if (SPVG009W.LK_VG009_IND_ERRO == 00)
            {

                /*" -10583- PERFORM R8560-00-GRAVA-CLASSIF-RISCO */

                R8560_00_GRAVA_CLASSIF_RISCO_SECTION();

                /*" -10584-  WHEN LK-VG009-IND-ERRO = 01  */

                /*" -10584- ELSE IF LK-VG009-IND-ERRO = 01 */
            }
            else

            if (SPVG009W.LK_VG009_IND_ERRO == 01)
            {

                /*" -10585- IF LK-VG009-SQLCODE = +100 */

                if (SPVG009W.LK_VG009_SQLCODE == +100)
                {

                    /*" -10586- PERFORM R8570-00-GRAVA-EMITE-SEM-RISCO */

                    R8570_00_GRAVA_EMITE_SEM_RISCO_SECTION();

                    /*" -10587- ELSE */
                }
                else
                {


                    /*" -10588- MOVE 1 TO WS-ERRO-VG009 */
                    _.Move(1, WS_ERRO_VG009);

                    /*" -10589- END-IF */
                }


                /*" -10590-  WHEN OTHER  */

                /*" -10590- ELSE */
            }
            else
            {


                /*" -10591- MOVE 1 TO WS-ERRO-VG009 */
                _.Move(1, WS_ERRO_VG009);

                /*" -10593-  END-EVALUATE  */

                /*" -10593- END-IF */
            }


            /*" -10594- IF WS-ERRO-VG009 NOT EQUAL ZEROS */

            if (WS_ERRO_VG009 != 00)
            {

                /*" -10595- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -10596- DISPLAY '* 8555 - PROBLEMAS CALL SUBROTINA SPBVG009    *' */
                _.Display($"* 8555 - PROBLEMAS CALL SUBROTINA SPBVG009    *");

                /*" -10597- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -10598- DISPLAY '* NUM-PROPOST: ' LK-VG009-E-NUM-PROPOSTA */
                _.Display($"* NUM-PROPOST: {SPVG009W.LK_VG009_E_NUM_PROPOSTA}");

                /*" -10599- DISPLAY '* TIPO-ACAO..: ' LK-VG009-E-TIPO-ACAO */
                _.Display($"* TIPO-ACAO..: {SPVG009W.LK_VG009_E_TIPO_ACAO}");

                /*" -10600- DISPLAY '* IND-ERRO...: ' LK-VG009-IND-ERRO */
                _.Display($"* IND-ERRO...: {SPVG009W.LK_VG009_IND_ERRO}");

                /*" -10601- DISPLAY '* MSG-ERRO...: ' LK-VG009-MSG-ERRO */
                _.Display($"* MSG-ERRO...: {SPVG009W.LK_VG009_MSG_ERRO}");

                /*" -10602- DISPLAY '* NOM-TABELA.: ' LK-VG009-NOM-TABELA */
                _.Display($"* NOM-TABELA.: {SPVG009W.LK_VG009_NOM_TABELA}");

                /*" -10603- DISPLAY '* SQLCODE....: ' LK-VG009-SQLCODE */
                _.Display($"* SQLCODE....: {SPVG009W.LK_VG009_SQLCODE}");

                /*" -10604- DISPLAY '* SQLERRMC...: ' LK-VG009-SQLERRMC */
                _.Display($"* SQLERRMC...: {SPVG009W.LK_VG009_SQLERRMC}");

                /*" -10606- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -10607- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -10608- END-IF */
            }


            /*" -10608- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8555_99_SAIDA*/

        [StopWatch]
        /*" R8560-00-GRAVA-CLASSIF-RISCO-SECTION */
        private void R8560_00_GRAVA_CLASSIF_RISCO_SECTION()
        {
            /*" -10622- MOVE 'R8560-00-GRAVA-CLASSIF-RISCO  ' TO PARAGRAFO */
            _.Move("R8560-00-GRAVA-CLASSIF-RISCO  ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -10624- MOVE 'GRAVA CLASSIF RISCO           ' TO COMANDO. */
            _.Move("GRAVA CLASSIF RISCO           ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -10626- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -10627- MOVE 'N' TO LK-VG001-TRACE */
            _.Move("N", SPVG001W.LK_VG001_TRACE);

            /*" -10628- MOVE 02 TO LK-VG001-TIPO-ACAO */
            _.Move(02, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -10631- MOVE PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO LK-VG001-NUM-CERTIFICADO VG078-NUM-CERTIFICADO */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, SPVG001W.LK_VG001_NUM_CERTIFICADO, VG078.DCLVG_ANDAMENTO_PROP.VG078_NUM_CERTIFICADO);

            /*" -10632- MOVE 0 TO LK-VG001-SEQ-CRITICA */
            _.Move(0, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -10633- MOVE 'PF' TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("PF", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -10634- MOVE 0 TO LK-VG001-NUM-CPF-CNPJ */
            _.Move(0, SPVG001W.LK_VG001_NUM_CPF_CNPJ);

            /*" -10635- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -10637- MOVE 'VA0601B' TO LK-VG001-NOM-PROGRAMA VG078-COD-USUARIO */
            _.Move("VA0601B", SPVG001W.LK_VG001_NOM_PROGRAMA, VG078.DCLVG_ANDAMENTO_PROP.VG078_COD_USUARIO);

            /*" -10638- MOVE 'SPBVG001' TO VG001-PROGRAMA */
            _.Move("SPBVG001", SPVG001V.VG001_PROGRAMA);

            /*" -10639- MOVE SPACES TO LK-VG001-STA-CRITICA */
            _.Move("", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -10641- MOVE 50 TO LK-VG001-DES-COMPLEMENTAR-L VG078-DES-ANDAMENTO-LEN */
            _.Move(50, SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_L, VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.VG078_DES_ANDAMENTO_LEN);

            /*" -10643- MOVE 'CADASTRAMENTO DE AVALIACAO DE RISCO' TO LK-VG001-DES-COMPLEMENTAR-T */
            _.Move("CADASTRAMENTO DE AVALIACAO DE RISCO", SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_T);

            /*" -10645- ADD 1 TO WS-QT-EMISSAO-C-RISCO */
            WS_QT_EMISSAO_C_RISCO.Value = WS_QT_EMISSAO_C_RISCO + 1;

            /*" -10647- EVALUATE LK-VG009-S-COD-CLASSIF-RISCO */
            switch (SPVG009W.LK_VG009_S_COD_CLASSIF_RISCO.Value)
            {

                /*" -10648- WHEN 01 */
                case 01:

                    /*" -10650- MOVE 'PROPOSTA COM CLASSIFICACAO DE RISCO BAIXA' TO VG078-DES-ANDAMENTO-TEXT */
                    _.Move("PROPOSTA COM CLASSIFICACAO DE RISCO BAIXA", VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.VG078_DES_ANDAMENTO_TEXT);

                    /*" -10652- MOVE 2 TO LK-VG001-COD-MSG-CRITICA */
                    _.Move(2, SPVG001W.LK_VG001_COD_MSG_CRITICA);

                    /*" -10653- WHEN 02 */
                    break;
                case 02:

                    /*" -10655- MOVE 'PROPOSTA COM CLASSIFICACAO DE RISCO MODERADO' TO VG078-DES-ANDAMENTO-TEXT */
                    _.Move("PROPOSTA COM CLASSIFICACAO DE RISCO MODERADO", VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.VG078_DES_ANDAMENTO_TEXT);

                    /*" -10657- MOVE 3 TO LK-VG001-COD-MSG-CRITICA */
                    _.Move(3, SPVG001W.LK_VG001_COD_MSG_CRITICA);

                    /*" -10658- WHEN 03 */
                    break;
                case 03:

                    /*" -10660- MOVE 'PROPOSTA COM CLASSIFICACAO DE RISCO ELEVADO' TO VG078-DES-ANDAMENTO-TEXT */
                    _.Move("PROPOSTA COM CLASSIFICACAO DE RISCO ELEVADO", VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.VG078_DES_ANDAMENTO_TEXT);

                    /*" -10662- MOVE 4 TO LK-VG001-COD-MSG-CRITICA */
                    _.Move(4, SPVG001W.LK_VG001_COD_MSG_CRITICA);

                    /*" -10663- WHEN 04 */
                    break;
                case 04:

                    /*" -10665- MOVE 'PROPOSTA COM CLASSIFICACAO DE RISCO CRITICO' TO VG078-DES-ANDAMENTO-TEXT */
                    _.Move("PROPOSTA COM CLASSIFICACAO DE RISCO CRITICO", VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.VG078_DES_ANDAMENTO_TEXT);

                    /*" -10666- MOVE 1 TO LK-VG001-COD-MSG-CRITICA */
                    _.Move(1, SPVG001W.LK_VG001_COD_MSG_CRITICA);

                    /*" -10667- WHEN OTHER */
                    break;
                default:

                    /*" -10670- DISPLAY 'ERRO - CLASSIFICACAO DE RISCO NAO CADASTRADA' LK-VG009-S-COD-CLASSIF-RISCO */
                    _.Display($"ERRO - CLASSIFICACAO DE RISCO NAO CADASTRADA{SPVG009W.LK_VG009_S_COD_CLASSIF_RISCO}");

                    /*" -10671- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -10673- END-EVALUATE */
                    break;
            }


            /*" -10675- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -10676- IF LK-VG001-IND-ERRO NOT EQUAL ZEROS */

            if (SPVG001W.LK_VG001_IND_ERRO != 00)
            {

                /*" -10677- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -10678- DISPLAY '* 8560 - PROBLEMAS CALL SUBROTINA SPBVG001    *' */
                _.Display($"* 8560 - PROBLEMAS CALL SUBROTINA SPBVG001    *");

                /*" -10679- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -10680- DISPLAY '* NUM-CERTIF..: ' LK-VG001-NUM-CERTIFICADO */
                _.Display($"* NUM-CERTIF..: {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                /*" -10681- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                /*" -10682- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                /*" -10683- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                /*" -10684- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                /*" -10685- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                /*" -10687- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -10688- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -10690- END-IF */
            }


            /*" -10691- PERFORM R3020-00-INSERE-ANDAMENTO */

            R3020_00_INSERE_ANDAMENTO_SECTION();

            /*" -10691- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8560_99_SAIDA*/

        [StopWatch]
        /*" R8570-00-GRAVA-EMITE-SEM-RISCO-SECTION */
        private void R8570_00_GRAVA_EMITE_SEM_RISCO_SECTION()
        {
            /*" -10704- MOVE 'R8570-00-GRAVA-EMITE-SEM-RISCO  ' TO PARAGRAFO */
            _.Move("R8570-00-GRAVA-EMITE-SEM-RISCO  ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -10706- MOVE 'GRAVA EMITE SEM RISCO           ' TO COMANDO. */
            _.Move("GRAVA EMITE SEM RISCO           ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -10710- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -10712- INITIALIZE LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
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

            /*" -10713- MOVE 'N' TO LK-VG001-TRACE */
            _.Move("N", SPVG001W.LK_VG001_TRACE);

            /*" -10714- MOVE 02 TO LK-VG001-TIPO-ACAO */
            _.Move(02, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -10717- MOVE PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO LK-VG001-NUM-CERTIFICADO VG078-NUM-CERTIFICADO */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, SPVG001W.LK_VG001_NUM_CERTIFICADO, VG078.DCLVG_ANDAMENTO_PROP.VG078_NUM_CERTIFICADO);

            /*" -10718- MOVE 0 TO LK-VG001-SEQ-CRITICA */
            _.Move(0, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -10719- MOVE 'PF' TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("PF", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -10720- MOVE 0 TO LK-VG001-NUM-CPF-CNPJ */
            _.Move(0, SPVG001W.LK_VG001_NUM_CPF_CNPJ);

            /*" -10721- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -10723- MOVE 'VA0601B' TO LK-VG001-NOM-PROGRAMA VG078-COD-USUARIO */
            _.Move("VA0601B", SPVG001W.LK_VG001_NOM_PROGRAMA, VG078.DCLVG_ANDAMENTO_PROP.VG078_COD_USUARIO);

            /*" -10724- MOVE 'SPBVG001' TO VG001-PROGRAMA */
            _.Move("SPBVG001", SPVG001V.VG001_PROGRAMA);

            /*" -10725- MOVE SPACES TO LK-VG001-STA-CRITICA */
            _.Move("", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -10727- MOVE 50 TO LK-VG001-DES-COMPLEMENTAR-L VG078-DES-ANDAMENTO-LEN */
            _.Move(50, SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_L, VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.VG078_DES_ANDAMENTO_LEN);

            /*" -10728- MOVE 5 TO LK-VG001-COD-MSG-CRITICA */
            _.Move(5, SPVG001W.LK_VG001_COD_MSG_CRITICA);

            /*" -10731- MOVE 'EMISSAO DE PROPOSTA SEM CLASSIFICACAO DE RISCO' TO LK-VG001-DES-COMPLEMENTAR-T VG078-DES-ANDAMENTO-TEXT */
            _.Move("EMISSAO DE PROPOSTA SEM CLASSIFICACAO DE RISCO", SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_T, VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.VG078_DES_ANDAMENTO_TEXT);

            /*" -10733- ADD 1 TO WS-QT-EMISSAO-S-RISCO */
            WS_QT_EMISSAO_S_RISCO.Value = WS_QT_EMISSAO_S_RISCO + 1;

            /*" -10735- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -10736- IF LK-VG001-IND-ERRO NOT EQUAL ZEROS */

            if (SPVG001W.LK_VG001_IND_ERRO != 00)
            {

                /*" -10737- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -10738- DISPLAY '* 8570 -  PROBLEMAS CALL SUBROTINA SPBVG001   *' */
                _.Display($"* 8570 -  PROBLEMAS CALL SUBROTINA SPBVG001   *");

                /*" -10739- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -10740- DISPLAY '* NUM-CERTIF..: ' LK-VG001-NUM-CERTIFICADO */
                _.Display($"* NUM-CERTIF..: {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                /*" -10741- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                /*" -10742- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                /*" -10743- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                /*" -10744- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                /*" -10745- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                /*" -10747- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -10748- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -10750- END-IF */
            }


            /*" -10751- PERFORM R3020-00-INSERE-ANDAMENTO */

            R3020_00_INSERE_ANDAMENTO_SECTION();

            /*" -10751- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8570_99_SAIDA*/

        [StopWatch]
        /*" R8580-00-TEM-RISCO-CRITICO-SECTION */
        private void R8580_00_TEM_RISCO_CRITICO_SECTION()
        {
            /*" -10760- MOVE 'R8580-00-TEM-RISCO-CRITICO  ' TO PARAGRAFO. */
            _.Move("R8580-00-TEM-RISCO-CRITICO  ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -10762- MOVE 'CALL SPVG001C               ' TO COMANDO. */
            _.Move("CALL SPVG001C               ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -10764- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -10765- MOVE 'N' TO VG001-IND-EXISTE */
            _.Move("N", SPVG001V.VG001_IND_EXISTE);

            /*" -10766- MOVE 'N' TO LK-VG001-TRACE */
            _.Move("N", SPVG001W.LK_VG001_TRACE);

            /*" -10767- MOVE 07 TO LK-VG001-TIPO-ACAO */
            _.Move(07, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -10769- MOVE PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO LK-VG001-NUM-CERTIFICADO */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, SPVG001W.LK_VG001_NUM_CERTIFICADO);

            /*" -10770- MOVE 0 TO LK-VG001-SEQ-CRITICA */
            _.Move(0, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -10771- MOVE SPACES TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -10772- MOVE 0 TO LK-VG001-NUM-CPF-CNPJ */
            _.Move(0, SPVG001W.LK_VG001_NUM_CPF_CNPJ);

            /*" -10773- MOVE 1 TO LK-VG001-COD-MSG-CRITICA */
            _.Move(1, SPVG001W.LK_VG001_COD_MSG_CRITICA);

            /*" -10774- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -10775- MOVE 'VA0601B' TO LK-VG001-NOM-PROGRAMA */
            _.Move("VA0601B", SPVG001W.LK_VG001_NOM_PROGRAMA);

            /*" -10776- MOVE 'SPBVG001' TO VG001-PROGRAMA */
            _.Move("SPBVG001", SPVG001V.VG001_PROGRAMA);

            /*" -10777- MOVE SPACES TO LK-VG001-STA-CRITICA */
            _.Move("", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -10778- MOVE 00 TO LK-VG001-DES-COMPLEMENTAR-L */
            _.Move(00, SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_L);

            /*" -10780- MOVE SPACES TO LK-VG001-DES-COMPLEMENTAR-T */
            _.Move("", SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_T);

            /*" -10782- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -10783- IF LK-VG001-IND-ERRO = 0 */

            if (SPVG001W.LK_VG001_IND_ERRO == 0)
            {

                /*" -10784- IF LK-VG001-S-NUM-CERTIFICADO > 0 */

                if (SPVG001W.LK_VG001_S_NUM_CERTIFICADO > 0)
                {

                    /*" -10785- MOVE 'S' TO VG001-IND-EXISTE */
                    _.Move("S", SPVG001V.VG001_IND_EXISTE);

                    /*" -10786- ELSE */
                }
                else
                {


                    /*" -10787- MOVE 'N' TO VG001-IND-EXISTE */
                    _.Move("N", SPVG001V.VG001_IND_EXISTE);

                    /*" -10788- END-IF */
                }


                /*" -10789- ELSE */
            }
            else
            {


                /*" -10790- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -10791- DISPLAY '* 8580 - PROBLEMAS CALL SUBROTINA SPBVG001    *' */
                _.Display($"* 8580 - PROBLEMAS CALL SUBROTINA SPBVG001    *");

                /*" -10792- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -10793- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                /*" -10794- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                /*" -10795- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                /*" -10796- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                /*" -10797- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                /*" -10798- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -10799- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -10800- END-IF */
            }


            /*" -10800- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8580_99_SAIDA*/

        [StopWatch]
        /*" R9100-00-UPDATE-NUM-OUTROS-SECTION */
        private void R9100_00_UPDATE_NUM_OUTROS_SECTION()
        {
            /*" -10810- MOVE '9100-00-UPDATE-NUM-OUTROS    ' TO PARAGRAFO. */
            _.Move("9100-00-UPDATE-NUM-OUTROS    ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -10811- MOVE 'UPDATE NUMERO OUTROS         ' TO COMANDO. */
            _.Move("UPDATE NUMERO OUTROS         ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -10813- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -10814- MOVE 97 TO SII */
            _.Move(97, WS_HORAS.SII);

            /*" -10815- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -10819- PERFORM R9100_00_UPDATE_NUM_OUTROS_DB_UPDATE_1 */

            R9100_00_UPDATE_NUM_OUTROS_DB_UPDATE_1();

            /*" -10822- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -10823- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -10824- DISPLAY 'PROBLEMAS NO UPDATE DA NUMERO OUTROS' */
                _.Display($"PROBLEMAS NO UPDATE DA NUMERO OUTROS");

                /*" -10824- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R9100-00-UPDATE-NUM-OUTROS-DB-UPDATE-1 */
        public void R9100_00_UPDATE_NUM_OUTROS_DB_UPDATE_1()
        {
            /*" -10819- EXEC SQL UPDATE SEGUROS.NUMERO_OUTROS SET NUM_CLIENTE = :DCLNUMERO-OUTROS.NUM-CLIENTE WHERE 1=1 END-EXEC. */

            var r9100_00_UPDATE_NUM_OUTROS_DB_UPDATE_1_Update1 = new R9100_00_UPDATE_NUM_OUTROS_DB_UPDATE_1_Update1()
            {
                NUM_CLIENTE = NUMOUTRO.DCLNUMERO_OUTROS.NUM_CLIENTE.ToString(),
            };

            R9100_00_UPDATE_NUM_OUTROS_DB_UPDATE_1_Update1.Execute(r9100_00_UPDATE_NUM_OUTROS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9100_99_SAIDA*/

        [StopWatch]
        /*" R9300-00-TRATA-MOVTO-CLIENTE-SECTION */
        private void R9300_00_TRATA_MOVTO_CLIENTE_SECTION()
        {
            /*" -10835- MOVE 'R9300-00-TRATA-MOVTO-CLIENTE' TO PARAGRAFO */
            _.Move("R9300-00-TRATA-MOVTO-CLIENTE", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -10837- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -10839- MOVE COD-CLIENTE OF DCLCLIENTES TO WWORK-COD-CLIENTE */
            _.Move(CLIENTE.DCLCLIENTES.COD_CLIENTE, W_GECLIMOV.WWORK_COD_CLIENTE);

            /*" -10841- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO WWORK-DATA-ULT-MANUTEN */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, W_GECLIMOV.WWORK_DATA_ULT_MANUTEN);

            /*" -10843- MOVE PESSOA-NOME-PESSOA OF DCLPESSOA TO WWORK-NOME-RAZAO */
            _.Move(PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA, W_GECLIMOV.WWORK_NOME_RAZAO);

            /*" -10844- MOVE 'F' TO WWORK-TIPO-PESSOA */
            _.Move("F", W_GECLIMOV.WWORK_TIPO_PESSOA);

            /*" -10845- MOVE SPACES TO WWORK-IDE-SEXO */
            _.Move("", W_GECLIMOV.WWORK_IDE_SEXO);

            /*" -10846- MOVE SPACES TO WWORK-ESTADO-CIVIL */
            _.Move("", W_GECLIMOV.WWORK_ESTADO_CIVIL);

            /*" -10849- MOVE ENDERECO-OCORR-ENDERECO OF DCLENDERECOS TO WWORK-OCORR-ENDERECO */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO, W_GECLIMOV.WWORK_OCORR_ENDERECO);

            /*" -10851- MOVE ENDERECO OF DCLPESSOA-ENDERECO TO WWORK-ENDERECO */
            _.Move(PESENDER.DCLPESSOA_ENDERECO.ENDERECO, W_GECLIMOV.WWORK_ENDERECO);

            /*" -10853- MOVE BAIRRO OF DCLPESSOA-ENDERECO TO WWORK-BAIRRO */
            _.Move(PESENDER.DCLPESSOA_ENDERECO.BAIRRO, W_GECLIMOV.WWORK_BAIRRO);

            /*" -10855- MOVE CIDADE OF DCLPESSOA-ENDERECO TO WWORK-CIDADE */
            _.Move(PESENDER.DCLPESSOA_ENDERECO.CIDADE, W_GECLIMOV.WWORK_CIDADE);

            /*" -10857- MOVE SIGLA-UF OF DCLPESSOA-ENDERECO TO WWORK-SIGLA-UF */
            _.Move(PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF, W_GECLIMOV.WWORK_SIGLA_UF);

            /*" -10859- MOVE CEP OF DCLPESSOA-ENDERECO TO WWORK-CEP */
            _.Move(PESENDER.DCLPESSOA_ENDERECO.CEP, W_GECLIMOV.WWORK_CEP);

            /*" -10860- MOVE WHOST-DDD TO WWORK-DDD */
            _.Move(WHOST_DDD, W_GECLIMOV.WWORK_DDD);

            /*" -10861- MOVE WHOST-FONE TO WWORK-TELEFONE */
            _.Move(WHOST_FONE, W_GECLIMOV.WWORK_TELEFONE);

            /*" -10862- MOVE WHOST-FAX TO WWORK-FAX */
            _.Move(WHOST_FAX, W_GECLIMOV.WWORK_FAX);

            /*" -10863- MOVE CPF OF DCLPESSOA-FISICA TO WWORK-CGCCPF */
            _.Move(PESFIS.DCLPESSOA_FISICA.CPF, W_GECLIMOV.WWORK_CGCCPF);

            /*" -10866- MOVE DATA-NASCIMENTO OF DCLPESSOA-FISICA TO WWORK-DATA-NASCIMENTO */
            _.Move(PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO, W_GECLIMOV.WWORK_DATA_NASCIMENTO);

            /*" -10867- MOVE WWORK-COD-CLIENTE TO GECLIMOV-COD-CLIENTE */
            _.Move(W_GECLIMOV.WWORK_COD_CLIENTE, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE);

            /*" -10868- MOVE WWORK-OCORR-ENDERECO TO GECLIMOV-OCORR-ENDERECO */
            _.Move(W_GECLIMOV.WWORK_OCORR_ENDERECO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_ENDERECO);

            /*" -10870- MOVE WWORK-TIPO-MOVIMENTO TO GECLIMOV-TIPO-MOVIMENTO */
            _.Move(W_GECLIMOV.WWORK_TIPO_MOVIMENTO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TIPO_MOVIMENTO);

            /*" -10875- MOVE WWORK-DATA-ULT-MANUTEN TO GECLIMOV-DATA-ULT-MANUTEN */
            _.Move(W_GECLIMOV.WWORK_DATA_ULT_MANUTEN, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DATA_ULT_MANUTEN);

            /*" -10876- PERFORM R9310-00-MAX-GECLIMOV */

            R9310_00_MAX_GECLIMOV_SECTION();

            /*" -10878- ADD 1 TO GECLIMOV-OCORR-HIST */
            GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_HIST.Value = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_HIST + 1;

            /*" -10879- IF GECLIMOV-OCORR-ENDERECO EQUAL ZEROS */

            if (GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_ENDERECO == 00)
            {

                /*" -10880- MOVE 0 TO WHOST-OCORR-END-I */
                _.Move(0, WHOST_OCORR_END_I);

                /*" -10881- MOVE 9999 TO WHOST-OCORR-END-F */
                _.Move(9999, WHOST_OCORR_END_F);

                /*" -10882- ELSE */
            }
            else
            {


                /*" -10885- MOVE GECLIMOV-OCORR-ENDERECO TO WHOST-OCORR-END-I WHOST-OCORR-END-F. */
                _.Move(GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_ENDERECO, WHOST_OCORR_END_I, WHOST_OCORR_END_F);
            }


            /*" -10886- PERFORM R9320-00-SELECT-GECLIMOV */

            R9320_00_SELECT_GECLIMOV_SECTION();

            /*" -10888- PERFORM R9320-00-SELECT-GECLIMOV */

            R9320_00_SELECT_GECLIMOV_SECTION();

            /*" -10889- IF WWORK-NOME-RAZAO EQUAL SPACES */

            if (W_GECLIMOV.WWORK_NOME_RAZAO.IsEmpty())
            {

                /*" -10890- MOVE -1 TO VIND-NOME-RAZAO */
                _.Move(-1, VIND_NOME_RAZAO);

                /*" -10891- ELSE */
            }
            else
            {


                /*" -10892- MOVE +0 TO VIND-NOME-RAZAO */
                _.Move(+0, VIND_NOME_RAZAO);

                /*" -10894- MOVE WWORK-NOME-RAZAO TO GECLIMOV-NOME-RAZAO. */
                _.Move(W_GECLIMOV.WWORK_NOME_RAZAO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_NOME_RAZAO);
            }


            /*" -10895- IF WWORK-TIPO-PESSOA EQUAL SPACES */

            if (W_GECLIMOV.WWORK_TIPO_PESSOA.IsEmpty())
            {

                /*" -10896- MOVE -1 TO VIND-TIPO-PESSOA */
                _.Move(-1, VIND_TIPO_PESSOA);

                /*" -10897- ELSE */
            }
            else
            {


                /*" -10898- MOVE +0 TO VIND-TIPO-PESSOA */
                _.Move(+0, VIND_TIPO_PESSOA);

                /*" -10900- MOVE WWORK-TIPO-PESSOA TO GECLIMOV-TIPO-PESSOA. */
                _.Move(W_GECLIMOV.WWORK_TIPO_PESSOA, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TIPO_PESSOA);
            }


            /*" -10901- IF WWORK-IDE-SEXO EQUAL SPACES */

            if (W_GECLIMOV.WWORK_IDE_SEXO.IsEmpty())
            {

                /*" -10902- MOVE -1 TO VIND-IDE-SEXO */
                _.Move(-1, VIND_IDE_SEXO);

                /*" -10903- ELSE */
            }
            else
            {


                /*" -10904- MOVE +0 TO VIND-IDE-SEXO */
                _.Move(+0, VIND_IDE_SEXO);

                /*" -10906- MOVE WWORK-IDE-SEXO TO GECLIMOV-IDE-SEXO. */
                _.Move(W_GECLIMOV.WWORK_IDE_SEXO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_IDE_SEXO);
            }


            /*" -10907- IF WWORK-ESTADO-CIVIL EQUAL SPACES */

            if (W_GECLIMOV.WWORK_ESTADO_CIVIL.IsEmpty())
            {

                /*" -10908- MOVE -1 TO VIND-EST-CIVIL */
                _.Move(-1, VIND_EST_CIVIL);

                /*" -10909- ELSE */
            }
            else
            {


                /*" -10910- MOVE +0 TO VIND-EST-CIVIL */
                _.Move(+0, VIND_EST_CIVIL);

                /*" -10912- MOVE WWORK-ESTADO-CIVIL TO GECLIMOV-ESTADO-CIVIL. */
                _.Move(W_GECLIMOV.WWORK_ESTADO_CIVIL, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_ESTADO_CIVIL);
            }


            /*" -10913- IF WWORK-OCORR-ENDERECO EQUAL ZEROS */

            if (W_GECLIMOV.WWORK_OCORR_ENDERECO == 00)
            {

                /*" -10914- MOVE -1 TO VIND-OCORR-END */
                _.Move(-1, VIND_OCORR_END);

                /*" -10915- ELSE */
            }
            else
            {


                /*" -10917- MOVE +0 TO VIND-OCORR-END. */
                _.Move(+0, VIND_OCORR_END);
            }


            /*" -10918- IF WWORK-ENDERECO EQUAL SPACES */

            if (W_GECLIMOV.WWORK_ENDERECO.IsEmpty())
            {

                /*" -10919- MOVE -1 TO VIND-ENDERECO */
                _.Move(-1, VIND_ENDERECO);

                /*" -10920- ELSE */
            }
            else
            {


                /*" -10921- MOVE +0 TO VIND-ENDERECO */
                _.Move(+0, VIND_ENDERECO);

                /*" -10923- MOVE WWORK-ENDERECO TO GECLIMOV-ENDERECO. */
                _.Move(W_GECLIMOV.WWORK_ENDERECO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_ENDERECO);
            }


            /*" -10924- IF WWORK-BAIRRO EQUAL SPACES */

            if (W_GECLIMOV.WWORK_BAIRRO.IsEmpty())
            {

                /*" -10925- MOVE -1 TO VIND-BAIRRO */
                _.Move(-1, VIND_BAIRRO);

                /*" -10926- ELSE */
            }
            else
            {


                /*" -10927- MOVE +0 TO VIND-BAIRRO */
                _.Move(+0, VIND_BAIRRO);

                /*" -10929- MOVE WWORK-BAIRRO TO GECLIMOV-BAIRRO. */
                _.Move(W_GECLIMOV.WWORK_BAIRRO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_BAIRRO);
            }


            /*" -10930- IF WWORK-CIDADE EQUAL SPACES */

            if (W_GECLIMOV.WWORK_CIDADE.IsEmpty())
            {

                /*" -10931- MOVE -1 TO VIND-CIDADE */
                _.Move(-1, VIND_CIDADE);

                /*" -10932- ELSE */
            }
            else
            {


                /*" -10933- MOVE +0 TO VIND-CIDADE */
                _.Move(+0, VIND_CIDADE);

                /*" -10935- MOVE WWORK-CIDADE TO GECLIMOV-CIDADE. */
                _.Move(W_GECLIMOV.WWORK_CIDADE, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CIDADE);
            }


            /*" -10936- IF WWORK-SIGLA-UF EQUAL SPACES */

            if (W_GECLIMOV.WWORK_SIGLA_UF.IsEmpty())
            {

                /*" -10937- MOVE -1 TO VIND-SIGLA-UF */
                _.Move(-1, VIND_SIGLA_UF);

                /*" -10938- ELSE */
            }
            else
            {


                /*" -10939- MOVE +0 TO VIND-SIGLA-UF */
                _.Move(+0, VIND_SIGLA_UF);

                /*" -10941- MOVE WWORK-SIGLA-UF TO GECLIMOV-SIGLA-UF. */
                _.Move(W_GECLIMOV.WWORK_SIGLA_UF, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_SIGLA_UF);
            }


            /*" -10942- IF WWORK-CEP EQUAL ZEROS */

            if (W_GECLIMOV.WWORK_CEP == 00)
            {

                /*" -10943- MOVE -1 TO VIND-CEP */
                _.Move(-1, VIND_CEP);

                /*" -10944- ELSE */
            }
            else
            {


                /*" -10945- MOVE +0 TO VIND-CEP */
                _.Move(+0, VIND_CEP);

                /*" -10947- MOVE WWORK-CEP TO GECLIMOV-CEP. */
                _.Move(W_GECLIMOV.WWORK_CEP, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CEP);
            }


            /*" -10948- IF WWORK-DDD EQUAL ZEROS */

            if (W_GECLIMOV.WWORK_DDD == 00)
            {

                /*" -10949- MOVE -1 TO VIND-DDD */
                _.Move(-1, VIND_DDD);

                /*" -10950- ELSE */
            }
            else
            {


                /*" -10951- MOVE +0 TO VIND-DDD */
                _.Move(+0, VIND_DDD);

                /*" -10953- MOVE WWORK-DDD TO GECLIMOV-DDD. */
                _.Move(W_GECLIMOV.WWORK_DDD, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DDD);
            }


            /*" -10954- IF WWORK-TELEFONE EQUAL ZEROS */

            if (W_GECLIMOV.WWORK_TELEFONE == 00)
            {

                /*" -10955- MOVE -1 TO VIND-TELEFONE */
                _.Move(-1, VIND_TELEFONE);

                /*" -10956- ELSE */
            }
            else
            {


                /*" -10957- MOVE +0 TO VIND-TELEFONE */
                _.Move(+0, VIND_TELEFONE);

                /*" -10959- MOVE WWORK-TELEFONE TO GECLIMOV-TELEFONE. */
                _.Move(W_GECLIMOV.WWORK_TELEFONE, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TELEFONE);
            }


            /*" -10960- IF WWORK-FAX EQUAL ZEROS */

            if (W_GECLIMOV.WWORK_FAX == 00)
            {

                /*" -10961- MOVE -1 TO VIND-FAX */
                _.Move(-1, VIND_FAX);

                /*" -10962- ELSE */
            }
            else
            {


                /*" -10963- MOVE +0 TO VIND-FAX */
                _.Move(+0, VIND_FAX);

                /*" -10965- MOVE WWORK-FAX TO GECLIMOV-FAX. */
                _.Move(W_GECLIMOV.WWORK_FAX, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_FAX);
            }


            /*" -10966- IF WWORK-CGCCPF EQUAL ZEROS */

            if (W_GECLIMOV.WWORK_CGCCPF == 00)
            {

                /*" -10967- MOVE -1 TO VIND-CGCCPF */
                _.Move(-1, VIND_CGCCPF);

                /*" -10968- ELSE */
            }
            else
            {


                /*" -10969- MOVE +0 TO VIND-CGCCPF */
                _.Move(+0, VIND_CGCCPF);

                /*" -10971- MOVE WWORK-CGCCPF TO GECLIMOV-CGCCPF. */
                _.Move(W_GECLIMOV.WWORK_CGCCPF, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CGCCPF);
            }


            /*" -10972- IF WWORK-DATA-NASCIMENTO EQUAL SPACES */

            if (W_GECLIMOV.WWORK_DATA_NASCIMENTO.IsEmpty())
            {

                /*" -10973- MOVE -1 TO VIND-DTNASC */
                _.Move(-1, VIND_DTNASC);

                /*" -10974- ELSE */
            }
            else
            {


                /*" -10975- MOVE +0 TO VIND-DTNASC */
                _.Move(+0, VIND_DTNASC);

                /*" -10977- MOVE WWORK-DATA-NASCIMENTO TO GECLIMOV-DATA-NASCIMENTO. */
                _.Move(W_GECLIMOV.WWORK_DATA_NASCIMENTO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DATA_NASCIMENTO);
            }


            /*" -10979- MOVE 'VA0601B' TO GECLIMOV-COD-USUARIO */
            _.Move("VA0601B", GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_USUARIO);

            /*" -10980- IF WTEM-GECLIMOV EQUAL 'N' */

            if (WTEM_GECLIMOV == "N")
            {

                /*" -10995- IF VIND-NOME-RAZAO LESS ZEROS AND VIND-TIPO-PESSOA LESS ZEROS AND VIND-IDE-SEXO LESS ZEROS AND VIND-EST-CIVIL LESS ZEROS AND VIND-OCORR-END LESS ZEROS AND VIND-ENDERECO LESS ZEROS AND VIND-BAIRRO LESS ZEROS AND VIND-CIDADE LESS ZEROS AND VIND-SIGLA-UF LESS ZEROS AND VIND-CEP LESS ZEROS AND VIND-DDD LESS ZEROS AND VIND-TELEFONE LESS ZEROS AND VIND-FAX LESS ZEROS AND VIND-CGCCPF LESS ZEROS AND VIND-DTNASC LESS ZEROS */

                if (VIND_NOME_RAZAO < 00 && VIND_TIPO_PESSOA < 00 && VIND_IDE_SEXO < 00 && VIND_EST_CIVIL < 00 && VIND_OCORR_END < 00 && VIND_ENDERECO < 00 && VIND_BAIRRO < 00 && VIND_CIDADE < 00 && VIND_SIGLA_UF < 00 && VIND_CEP < 00 && VIND_DDD < 00 && VIND_TELEFONE < 00 && VIND_FAX < 00 && VIND_CGCCPF < 00 && VIND_DTNASC < 00)
                {

                    /*" -10996- CONTINUE */

                    /*" -10997- ELSE */
                }
                else
                {


                    /*" -10998- PERFORM R9400-00-INSERT-GECLIMOV */

                    R9400_00_INSERT_GECLIMOV_SECTION();

                    /*" -10999- ELSE */
                }

            }
            else
            {


                /*" -10999- PERFORM R9450-00-UPDATE-GECLIMOV. */

                R9450_00_UPDATE_GECLIMOV_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9300_99_SAIDA*/

        [StopWatch]
        /*" R9310-00-MAX-GECLIMOV-SECTION */
        private void R9310_00_MAX_GECLIMOV_SECTION()
        {
            /*" -11009- MOVE 'R9310-00-MAX-GECLIMOV' TO PARAGRAFO */
            _.Move("R9310-00-MAX-GECLIMOV", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -11010- MOVE 'SELECT GECLIMOV      ' TO COMANDO. */
            _.Move("SELECT GECLIMOV      ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -11012- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -11013- MOVE 98 TO SII */
            _.Move(98, WS_HORAS.SII);

            /*" -11014- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -11019- PERFORM R9310_00_MAX_GECLIMOV_DB_SELECT_1 */

            R9310_00_MAX_GECLIMOV_DB_SELECT_1();

            /*" -11022- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -11023- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -11024- DISPLAY 'PROBLEMAS NO SELECT MAX (GE_CLIENTES_MOVTO) ' */
                _.Display($"PROBLEMAS NO SELECT MAX (GE_CLIENTES_MOVTO) ");

                /*" -11025- DISPLAY 'CODCLIEN ' GECLIMOV-COD-CLIENTE */
                _.Display($"CODCLIEN {GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE}");

                /*" -11025- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R9310-00-MAX-GECLIMOV-DB-SELECT-1 */
        public void R9310_00_MAX_GECLIMOV_DB_SELECT_1()
        {
            /*" -11019- EXEC SQL SELECT VALUE(MAX(OCORR_HIST), 0) INTO :GECLIMOV-OCORR-HIST FROM SEGUROS.GE_CLIENTES_MOVTO WHERE COD_CLIENTE = :GECLIMOV-COD-CLIENTE END-EXEC. */

            var r9310_00_MAX_GECLIMOV_DB_SELECT_1_Query1 = new R9310_00_MAX_GECLIMOV_DB_SELECT_1_Query1()
            {
                GECLIMOV_COD_CLIENTE = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE.ToString(),
            };

            var executed_1 = R9310_00_MAX_GECLIMOV_DB_SELECT_1_Query1.Execute(r9310_00_MAX_GECLIMOV_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GECLIMOV_OCORR_HIST, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_HIST);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9310_99_SAIDA*/

        [StopWatch]
        /*" R9320-00-SELECT-GECLIMOV-SECTION */
        private void R9320_00_SELECT_GECLIMOV_SECTION()
        {
            /*" -11035- MOVE 'R9320-00-SELECT-GECLIMOV ' TO PARAGRAFO */
            _.Move("R9320-00-SELECT-GECLIMOV ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -11036- MOVE 'DECLARE GECLIMOV         ' TO COMANDO */
            _.Move("DECLARE GECLIMOV         ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -11038- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -11062- PERFORM R9320_00_SELECT_GECLIMOV_DB_DECLARE_1 */

            R9320_00_SELECT_GECLIMOV_DB_DECLARE_1();

            /*" -11065- MOVE 99 TO SII */
            _.Move(99, WS_HORAS.SII);

            /*" -11066- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -11066- PERFORM R9320_00_SELECT_GECLIMOV_DB_OPEN_1 */

            R9320_00_SELECT_GECLIMOV_DB_OPEN_1();

            /*" -11069- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -11070- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -11071- DISPLAY 'PROBLEMAS NO OPEN (GE_CLIENTES_MOVTO) ... ' */
                _.Display($"PROBLEMAS NO OPEN (GE_CLIENTES_MOVTO) ... ");

                /*" -11072- DISPLAY 'CODCLIEN ' GECLIMOV-COD-CLIENTE */
                _.Display($"CODCLIEN {GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE}");

                /*" -11073- DISPLAY 'OCORR-END-I ' WHOST-OCORR-END-I */
                _.Display($"OCORR-END-I {WHOST_OCORR_END_I}");

                /*" -11074- DISPLAY 'OCORR-END-F ' WHOST-OCORR-END-F */
                _.Display($"OCORR-END-F {WHOST_OCORR_END_F}");

                /*" -11075- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -11077- END-IF. */
            }


            /*" -11078- MOVE 'FETCH C01_GECLIMOV ' TO COMANDO */
            _.Move("FETCH C01_GECLIMOV ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -11079- MOVE 100 TO SII */
            _.Move(100, WS_HORAS.SII);

            /*" -11080- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -11099- PERFORM R9320_00_SELECT_GECLIMOV_DB_FETCH_1 */

            R9320_00_SELECT_GECLIMOV_DB_FETCH_1();

            /*" -11102- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -11103- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -11104- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -11104- PERFORM R9320_00_SELECT_GECLIMOV_DB_CLOSE_1 */

                    R9320_00_SELECT_GECLIMOV_DB_CLOSE_1();

                    /*" -11106- MOVE 'N' TO WTEM-GECLIMOV */
                    _.Move("N", WTEM_GECLIMOV);

                    /*" -11107- ELSE */
                }
                else
                {


                    /*" -11108- DISPLAY 'PROBLEMAS NO FETCH (GE_CLIENTES_MOVTO) ... ' */
                    _.Display($"PROBLEMAS NO FETCH (GE_CLIENTES_MOVTO) ... ");

                    /*" -11109- DISPLAY 'CODCLIEN    ' GECLIMOV-COD-CLIENTE */
                    _.Display($"CODCLIEN    {GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE}");

                    /*" -11110- DISPLAY 'OCORR-END-I ' WHOST-OCORR-END-I */
                    _.Display($"OCORR-END-I {WHOST_OCORR_END_I}");

                    /*" -11111- DISPLAY 'OCORR-END-F ' WHOST-OCORR-END-F */
                    _.Display($"OCORR-END-F {WHOST_OCORR_END_F}");

                    /*" -11112- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -11113- END-IF */
                }


                /*" -11114- ELSE */
            }
            else
            {


                /*" -11115- MOVE 'S' TO WTEM-GECLIMOV */
                _.Move("S", WTEM_GECLIMOV);

                /*" -11115- PERFORM R9320_00_SELECT_GECLIMOV_DB_CLOSE_2 */

                R9320_00_SELECT_GECLIMOV_DB_CLOSE_2();

                /*" -11116- END-IF. */
            }


        }

        [StopWatch]
        /*" R9320-00-SELECT-GECLIMOV-DB-OPEN-1 */
        public void R9320_00_SELECT_GECLIMOV_DB_OPEN_1()
        {
            /*" -11066- EXEC SQL OPEN C01_GECLIMOV END-EXEC. */

            C01_GECLIMOV.Open();

        }

        [StopWatch]
        /*" R9320-00-SELECT-GECLIMOV-DB-FETCH-1 */
        public void R9320_00_SELECT_GECLIMOV_DB_FETCH_1()
        {
            /*" -11099- EXEC SQL FETCH C01_GECLIMOV INTO :GECLIMOV-TIPO-MOVIMENTO , :GECLIMOV-DATA-ULT-MANUTEN , :GECLIMOV-NOME-RAZAO:VIND-NOME-RAZAO , :GECLIMOV-TIPO-PESSOA:VIND-TIPO-PESSOA , :GECLIMOV-IDE-SEXO:VIND-IDE-SEXO , :GECLIMOV-ESTADO-CIVIL:VIND-EST-CIVIL , :GECLIMOV-OCORR-ENDERECO:VIND-OCORR-END , :GECLIMOV-ENDERECO:VIND-ENDERECO , :GECLIMOV-BAIRRO:VIND-BAIRRO , :GECLIMOV-CIDADE:VIND-CIDADE , :GECLIMOV-SIGLA-UF:VIND-SIGLA-UF , :GECLIMOV-CEP:VIND-CEP , :GECLIMOV-DDD:VIND-DDD , :GECLIMOV-TELEFONE:VIND-TELEFONE , :GECLIMOV-FAX:VIND-FAX , :GECLIMOV-OCORR-HIST , :GECLIMOV-CGCCPF:VIND-CGCCPF , :GECLIMOV-DATA-NASCIMENTO:VIND-DTNASC END-EXEC. */

            if (C01_GECLIMOV.Fetch())
            {
                _.Move(C01_GECLIMOV.GECLIMOV_TIPO_MOVIMENTO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TIPO_MOVIMENTO);
                _.Move(C01_GECLIMOV.GECLIMOV_DATA_ULT_MANUTEN, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DATA_ULT_MANUTEN);
                _.Move(C01_GECLIMOV.GECLIMOV_NOME_RAZAO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_NOME_RAZAO);
                _.Move(C01_GECLIMOV.VIND_NOME_RAZAO, VIND_NOME_RAZAO);
                _.Move(C01_GECLIMOV.GECLIMOV_TIPO_PESSOA, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TIPO_PESSOA);
                _.Move(C01_GECLIMOV.VIND_TIPO_PESSOA, VIND_TIPO_PESSOA);
                _.Move(C01_GECLIMOV.GECLIMOV_IDE_SEXO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_IDE_SEXO);
                _.Move(C01_GECLIMOV.VIND_IDE_SEXO, VIND_IDE_SEXO);
                _.Move(C01_GECLIMOV.GECLIMOV_ESTADO_CIVIL, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_ESTADO_CIVIL);
                _.Move(C01_GECLIMOV.VIND_EST_CIVIL, VIND_EST_CIVIL);
                _.Move(C01_GECLIMOV.GECLIMOV_OCORR_ENDERECO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_ENDERECO);
                _.Move(C01_GECLIMOV.VIND_OCORR_END, VIND_OCORR_END);
                _.Move(C01_GECLIMOV.GECLIMOV_ENDERECO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_ENDERECO);
                _.Move(C01_GECLIMOV.VIND_ENDERECO, VIND_ENDERECO);
                _.Move(C01_GECLIMOV.GECLIMOV_BAIRRO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_BAIRRO);
                _.Move(C01_GECLIMOV.VIND_BAIRRO, VIND_BAIRRO);
                _.Move(C01_GECLIMOV.GECLIMOV_CIDADE, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CIDADE);
                _.Move(C01_GECLIMOV.VIND_CIDADE, VIND_CIDADE);
                _.Move(C01_GECLIMOV.GECLIMOV_SIGLA_UF, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_SIGLA_UF);
                _.Move(C01_GECLIMOV.VIND_SIGLA_UF, VIND_SIGLA_UF);
                _.Move(C01_GECLIMOV.GECLIMOV_CEP, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CEP);
                _.Move(C01_GECLIMOV.VIND_CEP, VIND_CEP);
                _.Move(C01_GECLIMOV.GECLIMOV_DDD, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DDD);
                _.Move(C01_GECLIMOV.VIND_DDD, VIND_DDD);
                _.Move(C01_GECLIMOV.GECLIMOV_TELEFONE, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TELEFONE);
                _.Move(C01_GECLIMOV.VIND_TELEFONE, VIND_TELEFONE);
                _.Move(C01_GECLIMOV.GECLIMOV_FAX, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_FAX);
                _.Move(C01_GECLIMOV.VIND_FAX, VIND_FAX);
                _.Move(C01_GECLIMOV.GECLIMOV_OCORR_HIST, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_HIST);
                _.Move(C01_GECLIMOV.GECLIMOV_CGCCPF, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CGCCPF);
                _.Move(C01_GECLIMOV.VIND_CGCCPF, VIND_CGCCPF);
                _.Move(C01_GECLIMOV.GECLIMOV_DATA_NASCIMENTO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DATA_NASCIMENTO);
                _.Move(C01_GECLIMOV.VIND_DTNASC, VIND_DTNASC);
            }

        }

        [StopWatch]
        /*" R9320-00-SELECT-GECLIMOV-DB-CLOSE-1 */
        public void R9320_00_SELECT_GECLIMOV_DB_CLOSE_1()
        {
            /*" -11104- EXEC SQL CLOSE C01_GECLIMOV END-EXEC */

            C01_GECLIMOV.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9320_99_SAIDA*/

        [StopWatch]
        /*" R9320-00-SELECT-GECLIMOV-DB-CLOSE-2 */
        public void R9320_00_SELECT_GECLIMOV_DB_CLOSE_2()
        {
            /*" -11115- EXEC SQL CLOSE C01_GECLIMOV END-EXEC */

            C01_GECLIMOV.Close();

        }

        [StopWatch]
        /*" R9400-00-INSERT-GECLIMOV-SECTION */
        private void R9400_00_INSERT_GECLIMOV_SECTION()
        {
            /*" -11127- MOVE 'R9400-00-INSERT-GECLIMOV' TO PARAGRAFO */
            _.Move("R9400-00-INSERT-GECLIMOV", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -11128- MOVE 'INSERT GE_CLIENTES_MOVTO' TO COMANDO */
            _.Move("INSERT GE_CLIENTES_MOVTO", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -11130- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -11131- MOVE 101 TO SII */
            _.Move(101, WS_HORAS.SII);

            /*" -11132- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -11178- PERFORM R9400_00_INSERT_GECLIMOV_DB_INSERT_1 */

            R9400_00_INSERT_GECLIMOV_DB_INSERT_1();

            /*" -11181- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -11183- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL -803 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
            {

                /*" -11184- DISPLAY 'PROBLEMAS NO INSERT (GE_CLIENTES_MOVTO) ... ' */
                _.Display($"PROBLEMAS NO INSERT (GE_CLIENTES_MOVTO) ... ");

                /*" -11185- DISPLAY 'CODCLIEN ' GECLIMOV-COD-CLIENTE */
                _.Display($"CODCLIEN {GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE}");

                /*" -11186- DISPLAY 'OCORHIST ' GECLIMOV-OCORR-HIST */
                _.Display($"OCORHIST {GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_HIST}");

                /*" -11187- DISPLAY 'UF       ' GECLIMOV-SIGLA-UF */
                _.Display($"UF       {GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_SIGLA_UF}");

                /*" -11187- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R9400-00-INSERT-GECLIMOV-DB-INSERT-1 */
        public void R9400_00_INSERT_GECLIMOV_DB_INSERT_1()
        {
            /*" -11178- EXEC SQL INSERT INTO SEGUROS.GE_CLIENTES_MOVTO (COD_CLIENTE , TIPO_MOVIMENTO , DATA_ULT_MANUTEN , NOME_RAZAO , TIPO_PESSOA , IDE_SEXO , ESTADO_CIVIL , OCORR_ENDERECO , ENDERECO , BAIRRO , CIDADE , SIGLA_UF , CEP , DDD , TELEFONE , FAX , OCORR_HIST , CGCCPF , DATA_NASCIMENTO , COD_USUARIO , TIMESTAMP , DES_COMPLEMENTO) VALUES (:GECLIMOV-COD-CLIENTE , :GECLIMOV-TIPO-MOVIMENTO , :GECLIMOV-DATA-ULT-MANUTEN , :GECLIMOV-NOME-RAZAO:VIND-NOME-RAZAO , :GECLIMOV-TIPO-PESSOA:VIND-TIPO-PESSOA , :GECLIMOV-IDE-SEXO:VIND-IDE-SEXO , :GECLIMOV-ESTADO-CIVIL:VIND-EST-CIVIL , :GECLIMOV-OCORR-ENDERECO:VIND-OCORR-END , :GECLIMOV-ENDERECO:VIND-ENDERECO , :GECLIMOV-BAIRRO:VIND-BAIRRO , :GECLIMOV-CIDADE:VIND-CIDADE , :GECLIMOV-SIGLA-UF:VIND-SIGLA-UF , :GECLIMOV-CEP:VIND-CEP , :GECLIMOV-DDD:VIND-DDD , :GECLIMOV-TELEFONE:VIND-TELEFONE , :GECLIMOV-FAX:VIND-FAX , :GECLIMOV-OCORR-HIST , :GECLIMOV-CGCCPF:VIND-CGCCPF , :GECLIMOV-DATA-NASCIMENTO:VIND-DTNASC , :GECLIMOV-COD-USUARIO:VIND-CODUSU , CURRENT TIMESTAMP , NULL) END-EXEC. */

            var r9400_00_INSERT_GECLIMOV_DB_INSERT_1_Insert1 = new R9400_00_INSERT_GECLIMOV_DB_INSERT_1_Insert1()
            {
                GECLIMOV_COD_CLIENTE = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE.ToString(),
                GECLIMOV_TIPO_MOVIMENTO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TIPO_MOVIMENTO.ToString(),
                GECLIMOV_DATA_ULT_MANUTEN = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DATA_ULT_MANUTEN.ToString(),
                GECLIMOV_NOME_RAZAO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_NOME_RAZAO.ToString(),
                VIND_NOME_RAZAO = VIND_NOME_RAZAO.ToString(),
                GECLIMOV_TIPO_PESSOA = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TIPO_PESSOA.ToString(),
                VIND_TIPO_PESSOA = VIND_TIPO_PESSOA.ToString(),
                GECLIMOV_IDE_SEXO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_IDE_SEXO.ToString(),
                VIND_IDE_SEXO = VIND_IDE_SEXO.ToString(),
                GECLIMOV_ESTADO_CIVIL = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_ESTADO_CIVIL.ToString(),
                VIND_EST_CIVIL = VIND_EST_CIVIL.ToString(),
                GECLIMOV_OCORR_ENDERECO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_ENDERECO.ToString(),
                VIND_OCORR_END = VIND_OCORR_END.ToString(),
                GECLIMOV_ENDERECO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_ENDERECO.ToString(),
                VIND_ENDERECO = VIND_ENDERECO.ToString(),
                GECLIMOV_BAIRRO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_BAIRRO.ToString(),
                VIND_BAIRRO = VIND_BAIRRO.ToString(),
                GECLIMOV_CIDADE = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CIDADE.ToString(),
                VIND_CIDADE = VIND_CIDADE.ToString(),
                GECLIMOV_SIGLA_UF = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_SIGLA_UF.ToString(),
                VIND_SIGLA_UF = VIND_SIGLA_UF.ToString(),
                GECLIMOV_CEP = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CEP.ToString(),
                VIND_CEP = VIND_CEP.ToString(),
                GECLIMOV_DDD = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DDD.ToString(),
                VIND_DDD = VIND_DDD.ToString(),
                GECLIMOV_TELEFONE = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TELEFONE.ToString(),
                VIND_TELEFONE = VIND_TELEFONE.ToString(),
                GECLIMOV_FAX = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_FAX.ToString(),
                VIND_FAX = VIND_FAX.ToString(),
                GECLIMOV_OCORR_HIST = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_HIST.ToString(),
                GECLIMOV_CGCCPF = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CGCCPF.ToString(),
                VIND_CGCCPF = VIND_CGCCPF.ToString(),
                GECLIMOV_DATA_NASCIMENTO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DATA_NASCIMENTO.ToString(),
                VIND_DTNASC = VIND_DTNASC.ToString(),
                GECLIMOV_COD_USUARIO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_USUARIO.ToString(),
                VIND_CODUSU = VIND_CODUSU.ToString(),
            };

            R9400_00_INSERT_GECLIMOV_DB_INSERT_1_Insert1.Execute(r9400_00_INSERT_GECLIMOV_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9400_99_SAIDA*/

        [StopWatch]
        /*" R9450-00-UPDATE-GECLIMOV-SECTION */
        private void R9450_00_UPDATE_GECLIMOV_SECTION()
        {
            /*" -11197- MOVE 'R9450-00-UPDATE-GECLIMOV' TO PARAGRAFO */
            _.Move("R9450-00-UPDATE-GECLIMOV", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -11198- MOVE 'UPDATE GECLIMOV         ' TO COMANDO. */
            _.Move("UPDATE GECLIMOV         ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -11200- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -11201- MOVE 102 TO SII */
            _.Move(102, WS_HORAS.SII);

            /*" -11202- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -11226- PERFORM R9450_00_UPDATE_GECLIMOV_DB_UPDATE_1 */

            R9450_00_UPDATE_GECLIMOV_DB_UPDATE_1();

            /*" -11229- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -11230- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -11231- DISPLAY 'PROBLEMAS NO UPDATE (GE_CLIENTES_MOVTO) ... ' */
                _.Display($"PROBLEMAS NO UPDATE (GE_CLIENTES_MOVTO) ... ");

                /*" -11232- DISPLAY 'CODCLIEN ' GECLIMOV-COD-CLIENTE */
                _.Display($"CODCLIEN {GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE}");

                /*" -11233- DISPLAY 'OCORHIST ' GECLIMOV-OCORR-HIST */
                _.Display($"OCORHIST {GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_HIST}");

                /*" -11233- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R9450-00-UPDATE-GECLIMOV-DB-UPDATE-1 */
        public void R9450_00_UPDATE_GECLIMOV_DB_UPDATE_1()
        {
            /*" -11226- EXEC SQL UPDATE SEGUROS.GE_CLIENTES_MOVTO SET TIPO_MOVIMENTO = :GECLIMOV-TIPO-MOVIMENTO, DATA_ULT_MANUTEN = :GECLIMOV-DATA-ULT-MANUTEN, NOME_RAZAO = :GECLIMOV-NOME-RAZAO:VIND-NOME-RAZAO, TIPO_PESSOA = :GECLIMOV-TIPO-PESSOA:VIND-TIPO-PESSOA, IDE_SEXO = :GECLIMOV-IDE-SEXO:VIND-IDE-SEXO, ESTADO_CIVIL = :GECLIMOV-ESTADO-CIVIL:VIND-EST-CIVIL, OCORR_ENDERECO = :GECLIMOV-OCORR-ENDERECO:VIND-OCORR-END, ENDERECO = :GECLIMOV-ENDERECO:VIND-ENDERECO, BAIRRO = :GECLIMOV-BAIRRO:VIND-BAIRRO, CIDADE = :GECLIMOV-CIDADE:VIND-CIDADE, SIGLA_UF = :GECLIMOV-SIGLA-UF:VIND-SIGLA-UF, CEP = :GECLIMOV-CEP:VIND-CEP , DDD = :GECLIMOV-DDD:VIND-DDD , TELEFONE = :GECLIMOV-TELEFONE:VIND-TELEFONE , FAX = :GECLIMOV-FAX:VIND-FAX , CGCCPF = :GECLIMOV-CGCCPF:VIND-CGCCPF , DATA_NASCIMENTO = :GECLIMOV-DATA-NASCIMENTO:VIND-DTNASC, COD_USUARIO = :GECLIMOV-COD-USUARIO , TIMESTAMP = CURRENT TIMESTAMP WHERE COD_CLIENTE = :GECLIMOV-COD-CLIENTE AND OCORR_HIST = :GECLIMOV-OCORR-HIST END-EXEC. */

            var r9450_00_UPDATE_GECLIMOV_DB_UPDATE_1_Update1 = new R9450_00_UPDATE_GECLIMOV_DB_UPDATE_1_Update1()
            {
                GECLIMOV_OCORR_ENDERECO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_ENDERECO.ToString(),
                VIND_OCORR_END = VIND_OCORR_END.ToString(),
                GECLIMOV_TIPO_PESSOA = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TIPO_PESSOA.ToString(),
                VIND_TIPO_PESSOA = VIND_TIPO_PESSOA.ToString(),
                GECLIMOV_ESTADO_CIVIL = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_ESTADO_CIVIL.ToString(),
                VIND_EST_CIVIL = VIND_EST_CIVIL.ToString(),
                GECLIMOV_DATA_NASCIMENTO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DATA_NASCIMENTO.ToString(),
                VIND_DTNASC = VIND_DTNASC.ToString(),
                GECLIMOV_NOME_RAZAO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_NOME_RAZAO.ToString(),
                VIND_NOME_RAZAO = VIND_NOME_RAZAO.ToString(),
                GECLIMOV_IDE_SEXO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_IDE_SEXO.ToString(),
                VIND_IDE_SEXO = VIND_IDE_SEXO.ToString(),
                GECLIMOV_ENDERECO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_ENDERECO.ToString(),
                VIND_ENDERECO = VIND_ENDERECO.ToString(),
                GECLIMOV_SIGLA_UF = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_SIGLA_UF.ToString(),
                VIND_SIGLA_UF = VIND_SIGLA_UF.ToString(),
                GECLIMOV_TELEFONE = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TELEFONE.ToString(),
                VIND_TELEFONE = VIND_TELEFONE.ToString(),
                GECLIMOV_BAIRRO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_BAIRRO.ToString(),
                VIND_BAIRRO = VIND_BAIRRO.ToString(),
                GECLIMOV_CIDADE = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CIDADE.ToString(),
                VIND_CIDADE = VIND_CIDADE.ToString(),
                GECLIMOV_CGCCPF = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CGCCPF.ToString(),
                VIND_CGCCPF = VIND_CGCCPF.ToString(),
                GECLIMOV_DATA_ULT_MANUTEN = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DATA_ULT_MANUTEN.ToString(),
                GECLIMOV_TIPO_MOVIMENTO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TIPO_MOVIMENTO.ToString(),
                GECLIMOV_CEP = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CEP.ToString(),
                VIND_CEP = VIND_CEP.ToString(),
                GECLIMOV_DDD = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DDD.ToString(),
                VIND_DDD = VIND_DDD.ToString(),
                GECLIMOV_FAX = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_FAX.ToString(),
                VIND_FAX = VIND_FAX.ToString(),
                GECLIMOV_COD_USUARIO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_USUARIO.ToString(),
                GECLIMOV_COD_CLIENTE = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE.ToString(),
                GECLIMOV_OCORR_HIST = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_HIST.ToString(),
            };

            R9450_00_UPDATE_GECLIMOV_DB_UPDATE_1_Update1.Execute(r9450_00_UPDATE_GECLIMOV_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9450_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-INICIO-SECTION */
        private void R9000_00_INICIO_SECTION()
        {
            /*" -11243- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -11243- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9100-00-TERMINO-SECTION */
        private void R9100_00_TERMINO_SECTION()
        {
            /*" -11252- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -11252- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9100_99_SAIDA*/

        [StopWatch]
        /*" R9900-00-MOSTRA-TOTAIS-SECTION */
        private void R9900_00_MOSTRA_TOTAIS_SECTION()
        {
            /*" -11262- DISPLAY ' ' . */
            _.Display($" ");

            /*" -11262- MOVE ZEROS TO SII. */
            _.Move(0, WS_HORAS.SII);

            /*" -0- FLUXCONTROL_PERFORM R9900_10_MOSTRA_TOTAIS */

            R9900_10_MOSTRA_TOTAIS();

        }

        [StopWatch]
        /*" R9900-10-MOSTRA-TOTAIS */
        private void R9900_10_MOSTRA_TOTAIS(bool isPerform = false)
        {
            /*" -11268- ADD 1 TO SII. */
            WS_HORAS.SII.Value = WS_HORAS.SII + 1;

            /*" -11269- IF SII < 105 */

            if (WS_HORAS.SII < 105)
            {

                /*" -11270- MOVE STT(SII) TO STT-DISP */
                _.Move(TOTAIS_ROT.FILLER_0[WS_HORAS.SII].STT, WS_HORAS.STT_DISP);

                /*" -11272- DISPLAY 'PARAGRAFO:' SII ' TOTAL= ' STT-DISP ' QTDE= ' SQT(SII) */

                $"PARAGRAFO:{WS_HORAS.SII} TOTAL= {WS_HORAS.STT_DISP} QTDE= {TOTAIS_ROT.FILLER_0[WS_HORAS.SII]}"
                .Display();

                /*" -11274- GO TO R9900-10-MOSTRA-TOTAIS. */
                new Task(() => R9900_10_MOSTRA_TOTAIS()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -11274- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -11289- PERFORM R9900-00-MOSTRA-TOTAIS */

            R9900_00_MOSTRA_TOTAIS_SECTION();

            /*" -11290- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_ABEND.WABEND.WSQLCODE);

            /*" -11291- MOVE SQLCODE TO RETURN-CODE. */
            _.Move(DB.SQLCODE, RETURN_CODE);

            /*" -11292- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], AREA_ABEND.WABEND.WSQLERRD1);

            /*" -11293- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], AREA_ABEND.WABEND.WSQLERRD2);

            /*" -11294- DISPLAY WABEND. */
            _.Display(AREA_ABEND.WABEND);

            /*" -11295- DISPLAY LOCALIZA-ABEND-1. */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1);

            /*" -11297- DISPLAY LOCALIZA-ABEND-2. */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_2);

            /*" -11298- MOVE SQLERRMC TO WSQLERRMC */
            _.Move(DB.SQLERRMC, AREA_ABEND.WSQLERRO.WSQLERRMC);

            /*" -11300- DISPLAY WSQLERRO */
            _.Display(AREA_ABEND.WSQLERRO);

            /*" -11304- DISPLAY 'NUM-PROPOSTA-SIVPF = ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ. */
            _.Display($"NUM-PROPOSTA-SIVPF = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

            /*" -11304- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -11306- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -11310- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -11310- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}